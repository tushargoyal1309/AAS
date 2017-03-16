using System;
using System.Threading;
using AAS203.Common;
using AAS203Library;
using BgThread;

public class frmManualIgnition : System.Windows.Forms.Form, Iclient
{

	#Region " Windows Form Designer generated code "

	public frmManualIgnition()
	{
		base.New();

		//This call is required by the Windows Form Designer.
		InitializeComponent();

		//Add any initialization after the InitializeComponent() call
		try {
			LoadInConst();
			InitFromObject();
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
	internal System.Windows.Forms.Label Label1;
	internal System.Windows.Forms.Label Label3;
	internal System.Windows.Forms.Label Label5;
	internal System.Windows.Forms.Label Label6;
	internal System.Windows.Forms.Label Label7;
	internal System.Windows.Forms.Label lblFlameRatio;
	internal System.Windows.Forms.Label lblFlameType;
	internal System.Windows.Forms.Label lblSafetyControlsTrap;
	internal System.Windows.Forms.Label lblSafetyControlsDoor;
	internal System.Windows.Forms.Label lblBurnerType;
	internal System.Windows.Forms.Label lblStatusFuel;
	internal System.Windows.Forms.Label lblStatusN2O;
	internal System.Windows.Forms.Label lblStatusAir;
	internal System.Windows.Forms.Label lblPressureFuel;
	internal System.Windows.Forms.Label lblPressureN2O;
	internal System.Windows.Forms.Label lblPressureAir;
	internal System.Windows.Forms.Label lblFlame;
	internal System.Windows.Forms.Label lblSafetyControls;
	internal System.Windows.Forms.Label lblBurner;
	internal System.Windows.Forms.Label lblPressureValveStatus;
	internal System.Windows.Forms.Label lblPressures;
	internal System.Windows.Forms.Label lblBurnerHeight;
	internal System.Windows.Forms.PictureBox pbSafetyControlsTrap;
	internal System.Windows.Forms.Label Label2;
	internal System.Windows.Forms.Label lblBurnerAttached;
	internal System.Windows.Forms.Label lblFuelPressure;
	internal System.Windows.Forms.Label lblN2OPressure;
	internal System.Windows.Forms.Label lblAirPressure;
	internal System.Windows.Forms.Label Label4;
	internal NETXP.Controls.XPButton btnClose;
	internal NETXP.Controls.XPButton btnSetMaxBurnerHeight;
	internal NETXP.Controls.XPButton btnSetMaxFuel;
	internal NETXP.Controls.XPButton btnDecreaseFuel;
	internal NETXP.Controls.XPButton btnIncreaseFuel;
	internal NETXP.Controls.XPButton btnIgnite;
	internal NETXP.Controls.XPButton btnFuel;
	internal NETXP.Controls.XPButton btnN2O;
	internal NETXP.Controls.XPButton btnAirOnOff;
	internal System.Windows.Forms.Label lblBurnerStatus;
	internal System.Windows.Forms.Label lblFuel;
	internal System.Windows.Forms.Label lblN2O;
	internal System.Windows.Forms.Label lblAir;
	internal System.Windows.Forms.Label lblIgnite;
	internal System.Windows.Forms.Label lblIgniteStatus;
	internal NETXP.Controls.XPButton btnIncreaseBurnerHeight;
	internal NETXP.Controls.XPButton btnDecreaseBurnerHeight;
	internal System.Timers.Timer tmrCheckManualIgnite;
	internal System.Windows.Forms.Label lblFRatio;
	internal System.Windows.Forms.Label lblBHeight;
	internal System.Windows.Forms.Label lblNVStep;
	internal System.Windows.Forms.Label lblNVStep1;
	internal NETXP.Controls.Bars.CommandBar CommandBar1;
	internal System.Windows.Forms.Label pbPressureAir;
	internal System.Windows.Forms.Label pbPressureN2O;
	internal System.Windows.Forms.Label pbPressureFuel;
	internal System.Windows.Forms.Label pbStatusAir;
	internal System.Windows.Forms.Label pbStatusFuel;
	internal System.Windows.Forms.Label pbBurnerType;
	internal System.Windows.Forms.Label pbSafetyControlsDoor;
	internal System.Windows.Forms.Label pbFlameType;
	internal NETXP.Controls.Bars.CommandBarButtonItem cmdBarBtnIgnite;
	internal NETXP.Controls.Bars.CommandBarButtonItem cmdBarBtnExtinguish;
	internal GradientPanel.CustomPanel custpnlStatusDisplay;
	internal System.Windows.Forms.Label pbStatusN2O;
	internal NETXP.Controls.XPButton btnN2OIgnite;
	internal NETXP.Controls.XPButton btnDelete;
	internal NETXP.Controls.XPButton btnR;
	internal System.Windows.Forms.Label Label8;
	internal NETXP.Controls.XPButton btnExtinguish;
	internal NETXP.Controls.XPButton btnAutoIgnite;
	internal System.Windows.Forms.Label lblFlameType1;
	internal System.Windows.Forms.Label lblBurnerType1;
	internal System.Windows.Forms.Label lblStatusFuel1;
	internal System.Windows.Forms.Label lblStatusN2O1;
	internal System.Windows.Forms.Label lblStatusAir1;
	internal System.Windows.Forms.Label lblPressureFuel1;
	internal System.Windows.Forms.Label Label17;
	internal System.Windows.Forms.Label lblPressureAir1;
	internal System.Windows.Forms.Label lblFlame1;
	internal System.Windows.Forms.Label Label21;
	internal System.Windows.Forms.Label Label22;
	internal System.Windows.Forms.Label Label23;
	internal System.Windows.Forms.Label lblBurner1;
	internal System.Windows.Forms.Label lblPressureValveStatus1;
	internal System.Windows.Forms.Label pbFlameType1;
	internal System.Windows.Forms.Label pbBurnerType1;
	internal System.Windows.Forms.Label pbStatusFuel1;
	internal System.Windows.Forms.Label pbStatusN2O1;
	internal System.Windows.Forms.Label pbStatusAir1;
	internal System.Windows.Forms.Label pbPressureFuel1;
	internal System.Windows.Forms.Label pbPressureN2O1;
	internal System.Windows.Forms.Label pbPressureAir1;
	internal System.Windows.Forms.Label lblPressures1;
	internal System.Windows.Forms.Label lblFRatio1;
	internal System.Windows.Forms.Label lblPressureN2O1;
	internal System.Windows.Forms.Label lblFlameRatio1;
	internal System.Windows.Forms.Label Label42;
	internal GradientPanel.CustomPanel pnl201;
	internal GradientPanel.CustomPanel pnl203;
	[System.Diagnostics.DebuggerStepThrough()]
	private void InitializeComponent()
	{
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmManualIgnition));
		this.CustomPanel1 = new GradientPanel.CustomPanel();
		this.Label8 = new System.Windows.Forms.Label();
		this.btnExtinguish = new NETXP.Controls.XPButton();
		this.btnAutoIgnite = new NETXP.Controls.XPButton();
		this.btnDelete = new NETXP.Controls.XPButton();
		this.btnR = new NETXP.Controls.XPButton();
		this.CommandBar1 = new NETXP.Controls.Bars.CommandBar();
		this.cmdBarBtnIgnite = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.cmdBarBtnExtinguish = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.lblNVStep1 = new System.Windows.Forms.Label();
		this.lblIgniteStatus = new System.Windows.Forms.Label();
		this.lblIgnite = new System.Windows.Forms.Label();
		this.lblBurnerStatus = new System.Windows.Forms.Label();
		this.lblFuel = new System.Windows.Forms.Label();
		this.lblN2O = new System.Windows.Forms.Label();
		this.lblAir = new System.Windows.Forms.Label();
		this.lblNVStep = new System.Windows.Forms.Label();
		this.lblBurnerAttached = new System.Windows.Forms.Label();
		this.lblFuelPressure = new System.Windows.Forms.Label();
		this.lblN2OPressure = new System.Windows.Forms.Label();
		this.lblAirPressure = new System.Windows.Forms.Label();
		this.Label4 = new System.Windows.Forms.Label();
		this.btnSetMaxBurnerHeight = new NETXP.Controls.XPButton();
		this.btnSetMaxFuel = new NETXP.Controls.XPButton();
		this.btnIncreaseBurnerHeight = new NETXP.Controls.XPButton();
		this.btnDecreaseBurnerHeight = new NETXP.Controls.XPButton();
		this.btnDecreaseFuel = new NETXP.Controls.XPButton();
		this.btnIncreaseFuel = new NETXP.Controls.XPButton();
		this.btnIgnite = new NETXP.Controls.XPButton();
		this.btnFuel = new NETXP.Controls.XPButton();
		this.btnN2O = new NETXP.Controls.XPButton();
		this.btnAirOnOff = new NETXP.Controls.XPButton();
		this.btnN2OIgnite = new NETXP.Controls.XPButton();
		this.btnClose = new NETXP.Controls.XPButton();
		this.pbFlameType = new System.Windows.Forms.Label();
		this.pbSafetyControlsDoor = new System.Windows.Forms.Label();
		this.pbBurnerType = new System.Windows.Forms.Label();
		this.pbStatusFuel = new System.Windows.Forms.Label();
		this.pbStatusAir = new System.Windows.Forms.Label();
		this.pbPressureFuel = new System.Windows.Forms.Label();
		this.pbPressureN2O = new System.Windows.Forms.Label();
		this.pbPressureAir = new System.Windows.Forms.Label();
		this.lblBHeight = new System.Windows.Forms.Label();
		this.lblFRatio = new System.Windows.Forms.Label();
		this.Label2 = new System.Windows.Forms.Label();
		this.lblBurnerHeight = new System.Windows.Forms.Label();
		this.pbSafetyControlsTrap = new System.Windows.Forms.PictureBox();
		this.lblFlameRatio = new System.Windows.Forms.Label();
		this.lblFlameType = new System.Windows.Forms.Label();
		this.lblSafetyControlsTrap = new System.Windows.Forms.Label();
		this.lblSafetyControlsDoor = new System.Windows.Forms.Label();
		this.lblBurnerType = new System.Windows.Forms.Label();
		this.lblStatusFuel = new System.Windows.Forms.Label();
		this.lblStatusN2O = new System.Windows.Forms.Label();
		this.lblStatusAir = new System.Windows.Forms.Label();
		this.lblPressureFuel = new System.Windows.Forms.Label();
		this.lblPressureN2O = new System.Windows.Forms.Label();
		this.lblPressureAir = new System.Windows.Forms.Label();
		this.lblFlame = new System.Windows.Forms.Label();
		this.lblSafetyControls = new System.Windows.Forms.Label();
		this.lblBurner = new System.Windows.Forms.Label();
		this.lblPressureValveStatus = new System.Windows.Forms.Label();
		this.lblPressures = new System.Windows.Forms.Label();
		this.Label7 = new System.Windows.Forms.Label();
		this.Label6 = new System.Windows.Forms.Label();
		this.Label5 = new System.Windows.Forms.Label();
		this.Label3 = new System.Windows.Forms.Label();
		this.Label1 = new System.Windows.Forms.Label();
		this.tmrCheckManualIgnite = new System.Timers.Timer();
		this.custpnlStatusDisplay = new GradientPanel.CustomPanel();
		this.pnl201 = new GradientPanel.CustomPanel();
		this.lblFlameType1 = new System.Windows.Forms.Label();
		this.lblBurnerType1 = new System.Windows.Forms.Label();
		this.lblStatusFuel1 = new System.Windows.Forms.Label();
		this.lblStatusN2O1 = new System.Windows.Forms.Label();
		this.lblStatusAir1 = new System.Windows.Forms.Label();
		this.lblPressureFuel1 = new System.Windows.Forms.Label();
		this.Label17 = new System.Windows.Forms.Label();
		this.lblPressureAir1 = new System.Windows.Forms.Label();
		this.lblFlame1 = new System.Windows.Forms.Label();
		this.Label21 = new System.Windows.Forms.Label();
		this.Label22 = new System.Windows.Forms.Label();
		this.Label23 = new System.Windows.Forms.Label();
		this.lblBurner1 = new System.Windows.Forms.Label();
		this.lblPressureValveStatus1 = new System.Windows.Forms.Label();
		this.pbFlameType1 = new System.Windows.Forms.Label();
		this.pbBurnerType1 = new System.Windows.Forms.Label();
		this.pbStatusFuel1 = new System.Windows.Forms.Label();
		this.pbStatusN2O1 = new System.Windows.Forms.Label();
		this.pbStatusAir1 = new System.Windows.Forms.Label();
		this.pbPressureFuel1 = new System.Windows.Forms.Label();
		this.pbPressureN2O1 = new System.Windows.Forms.Label();
		this.pbPressureAir1 = new System.Windows.Forms.Label();
		this.lblPressures1 = new System.Windows.Forms.Label();
		this.lblFRatio1 = new System.Windows.Forms.Label();
		this.lblPressureN2O1 = new System.Windows.Forms.Label();
		this.lblFlameRatio1 = new System.Windows.Forms.Label();
		this.Label42 = new System.Windows.Forms.Label();
		this.pnl203 = new GradientPanel.CustomPanel();
		this.pbStatusN2O = new System.Windows.Forms.Label();
		this.CustomPanel1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.CommandBar1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.tmrCheckManualIgnite).BeginInit();
		this.custpnlStatusDisplay.SuspendLayout();
		this.pnl201.SuspendLayout();
		this.pnl203.SuspendLayout();
		this.SuspendLayout();
		//
		//CustomPanel1
		//
		this.CustomPanel1.BackColor = System.Drawing.Color.AliceBlue;
		this.CustomPanel1.Controls.Add(this.Label8);
		this.CustomPanel1.Controls.Add(this.btnExtinguish);
		this.CustomPanel1.Controls.Add(this.btnAutoIgnite);
		this.CustomPanel1.Controls.Add(this.btnDelete);
		this.CustomPanel1.Controls.Add(this.btnR);
		this.CustomPanel1.Controls.Add(this.CommandBar1);
		this.CustomPanel1.Controls.Add(this.lblNVStep1);
		this.CustomPanel1.Controls.Add(this.lblIgniteStatus);
		this.CustomPanel1.Controls.Add(this.lblIgnite);
		this.CustomPanel1.Controls.Add(this.lblBurnerStatus);
		this.CustomPanel1.Controls.Add(this.lblFuel);
		this.CustomPanel1.Controls.Add(this.lblN2O);
		this.CustomPanel1.Controls.Add(this.lblAir);
		this.CustomPanel1.Controls.Add(this.lblNVStep);
		this.CustomPanel1.Controls.Add(this.lblBurnerAttached);
		this.CustomPanel1.Controls.Add(this.lblFuelPressure);
		this.CustomPanel1.Controls.Add(this.lblN2OPressure);
		this.CustomPanel1.Controls.Add(this.lblAirPressure);
		this.CustomPanel1.Controls.Add(this.Label4);
		this.CustomPanel1.Controls.Add(this.btnSetMaxBurnerHeight);
		this.CustomPanel1.Controls.Add(this.btnSetMaxFuel);
		this.CustomPanel1.Controls.Add(this.btnIncreaseBurnerHeight);
		this.CustomPanel1.Controls.Add(this.btnDecreaseBurnerHeight);
		this.CustomPanel1.Controls.Add(this.btnDecreaseFuel);
		this.CustomPanel1.Controls.Add(this.btnIncreaseFuel);
		this.CustomPanel1.Controls.Add(this.btnIgnite);
		this.CustomPanel1.Controls.Add(this.btnFuel);
		this.CustomPanel1.Controls.Add(this.btnN2O);
		this.CustomPanel1.Controls.Add(this.btnAirOnOff);
		this.CustomPanel1.Controls.Add(this.btnN2OIgnite);
		this.CustomPanel1.Controls.Add(this.btnClose);
		this.CustomPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.CustomPanel1.Location = new System.Drawing.Point(0, 160);
		this.CustomPanel1.Name = "CustomPanel1";
		this.CustomPanel1.Size = new System.Drawing.Size(658, 184);
		this.CustomPanel1.TabIndex = 0;
		//
		//Label8
		//
		this.Label8.Location = new System.Drawing.Point(16, 145);
		this.Label8.Name = "Label8";
		this.Label8.Size = new System.Drawing.Size(112, 24);
		this.Label8.TabIndex = 77;
		//
		//btnExtinguish
		//
		this.btnExtinguish.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnExtinguish.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnExtinguish.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnExtinguish.Location = new System.Drawing.Point(56, 152);
		this.btnExtinguish.Name = "btnExtinguish";
		this.btnExtinguish.Size = new System.Drawing.Size(8, 8);
		this.btnExtinguish.TabIndex = 79;
		this.btnExtinguish.TabStop = false;
		this.btnExtinguish.Text = "&Extinguish";
		this.btnExtinguish.TextAlign = System.Drawing.ContentAlignment.TopLeft;
		//
		//btnAutoIgnite
		//
		this.btnAutoIgnite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnAutoIgnite.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnAutoIgnite.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnAutoIgnite.Location = new System.Drawing.Point(40, 152);
		this.btnAutoIgnite.Name = "btnAutoIgnite";
		this.btnAutoIgnite.Size = new System.Drawing.Size(8, 8);
		this.btnAutoIgnite.TabIndex = 78;
		this.btnAutoIgnite.TabStop = false;
		this.btnAutoIgnite.Text = "&Ignition";
		this.btnAutoIgnite.TextAlign = System.Drawing.ContentAlignment.TopLeft;
		//
		//btnDelete
		//
		this.btnDelete.BackColor = System.Drawing.Color.Transparent;
		this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnDelete.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnDelete.Location = new System.Drawing.Point(80, 152);
		this.btnDelete.Name = "btnDelete";
		this.btnDelete.Size = new System.Drawing.Size(8, 8);
		this.btnDelete.TabIndex = 76;
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
		this.btnR.Location = new System.Drawing.Point(96, 152);
		this.btnR.Name = "btnR";
		this.btnR.Size = new System.Drawing.Size(8, 8);
		this.btnR.TabIndex = 75;
		this.btnR.TabStop = false;
		this.btnR.Text = "&R";
		this.btnR.TextAlign = System.Drawing.ContentAlignment.TopLeft;
		//
		//CommandBar1
		//
		this.CommandBar1.BackColor = System.Drawing.Color.Transparent;
		this.CommandBar1.CustomizeText = "&Customize Toolbar...";
		this.CommandBar1.FullRow = true;
		this.CommandBar1.ID = 2250;
		this.CommandBar1.Items.AddRange(new NETXP.Controls.Bars.CommandBarItem[] {
			this.cmdBarBtnIgnite,
			this.cmdBarBtnExtinguish
		});
		this.CommandBar1.Location = new System.Drawing.Point(176, 137);
		this.CommandBar1.Margins.Bottom = 1;
		this.CommandBar1.Margins.Left = 1;
		this.CommandBar1.Margins.Right = 1;
		this.CommandBar1.Margins.Top = 1;
		this.CommandBar1.Name = "CommandBar1";
		this.CommandBar1.Size = new System.Drawing.Size(64, 45);
		this.CommandBar1.Style = NETXP.Controls.Bars.CommandBarStyle.Menu;
		this.CommandBar1.TabIndex = 68;
		this.CommandBar1.TabStop = false;
		this.CommandBar1.Text = "CommandBar1";
		this.CommandBar1.Visible = false;
		//
		//cmdBarBtnIgnite
		//
		this.cmdBarBtnIgnite.Shortcut = System.Windows.Forms.Shortcut.CtrlI;
		this.cmdBarBtnIgnite.Text = "CTRL+I";
		//
		//cmdBarBtnExtinguish
		//
		this.cmdBarBtnExtinguish.Shortcut = System.Windows.Forms.Shortcut.CtrlE;
		this.cmdBarBtnExtinguish.Text = "CTRL+E";
		//
		//lblNVStep1
		//
		this.lblNVStep1.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblNVStep1.Location = new System.Drawing.Point(8, 5);
		this.lblNVStep1.Name = "lblNVStep1";
		this.lblNVStep1.Size = new System.Drawing.Size(72, 20);
		this.lblNVStep1.TabIndex = 66;
		this.lblNVStep1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		//
		//lblIgniteStatus
		//
		this.lblIgniteStatus.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblIgniteStatus.Location = new System.Drawing.Point(120, 104);
		this.lblIgniteStatus.Name = "lblIgniteStatus";
		this.lblIgniteStatus.Size = new System.Drawing.Size(56, 16);
		this.lblIgniteStatus.TabIndex = 63;
		this.lblIgniteStatus.Visible = false;
		//
		//lblIgnite
		//
		this.lblIgnite.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblIgnite.Location = new System.Drawing.Point(8, 104);
		this.lblIgnite.Name = "lblIgnite";
		this.lblIgnite.Size = new System.Drawing.Size(104, 16);
		this.lblIgnite.TabIndex = 62;
		this.lblIgnite.Text = "IGNITE";
		this.lblIgnite.Visible = false;
		//
		//lblBurnerStatus
		//
		this.lblBurnerStatus.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblBurnerStatus.Location = new System.Drawing.Point(120, 128);
		this.lblBurnerStatus.Name = "lblBurnerStatus";
		this.lblBurnerStatus.Size = new System.Drawing.Size(56, 16);
		this.lblBurnerStatus.TabIndex = 61;
		this.lblBurnerStatus.Visible = false;
		//
		//lblFuel
		//
		this.lblFuel.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblFuel.Location = new System.Drawing.Point(120, 80);
		this.lblFuel.Name = "lblFuel";
		this.lblFuel.Size = new System.Drawing.Size(56, 16);
		this.lblFuel.TabIndex = 60;
		this.lblFuel.Visible = false;
		//
		//lblN2O
		//
		this.lblN2O.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblN2O.Location = new System.Drawing.Point(120, 56);
		this.lblN2O.Name = "lblN2O";
		this.lblN2O.Size = new System.Drawing.Size(56, 16);
		this.lblN2O.TabIndex = 59;
		this.lblN2O.Visible = false;
		//
		//lblAir
		//
		this.lblAir.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblAir.Location = new System.Drawing.Point(120, 32);
		this.lblAir.Name = "lblAir";
		this.lblAir.Size = new System.Drawing.Size(56, 16);
		this.lblAir.TabIndex = 58;
		this.lblAir.Visible = false;
		//
		//lblNVStep
		//
		this.lblNVStep.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblNVStep.Location = new System.Drawing.Point(96, 5);
		this.lblNVStep.Name = "lblNVStep";
		this.lblNVStep.Size = new System.Drawing.Size(88, 20);
		this.lblNVStep.TabIndex = 57;
		this.lblNVStep.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		//
		//lblBurnerAttached
		//
		this.lblBurnerAttached.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblBurnerAttached.Location = new System.Drawing.Point(8, 128);
		this.lblBurnerAttached.Name = "lblBurnerAttached";
		this.lblBurnerAttached.Size = new System.Drawing.Size(104, 16);
		this.lblBurnerAttached.TabIndex = 56;
		this.lblBurnerAttached.Text = "Burner attached";
		this.lblBurnerAttached.Visible = false;
		//
		//lblFuelPressure
		//
		this.lblFuelPressure.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblFuelPressure.Location = new System.Drawing.Point(8, 80);
		this.lblFuelPressure.Name = "lblFuelPressure";
		this.lblFuelPressure.Size = new System.Drawing.Size(104, 16);
		this.lblFuelPressure.TabIndex = 55;
		this.lblFuelPressure.Text = "FUEL Pressure";
		this.lblFuelPressure.Visible = false;
		//
		//lblN2OPressure
		//
		this.lblN2OPressure.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblN2OPressure.Location = new System.Drawing.Point(8, 56);
		this.lblN2OPressure.Name = "lblN2OPressure";
		this.lblN2OPressure.Size = new System.Drawing.Size(104, 16);
		this.lblN2OPressure.TabIndex = 54;
		this.lblN2OPressure.Text = "N2O Pressure";
		this.lblN2OPressure.Visible = false;
		//
		//lblAirPressure
		//
		this.lblAirPressure.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblAirPressure.Location = new System.Drawing.Point(8, 32);
		this.lblAirPressure.Name = "lblAirPressure";
		this.lblAirPressure.Size = new System.Drawing.Size(104, 16);
		this.lblAirPressure.TabIndex = 53;
		this.lblAirPressure.Text = "AIR Pressure";
		this.lblAirPressure.Visible = false;
		//
		//Label4
		//
		this.Label4.BackColor = System.Drawing.SystemColors.Control;
		this.Label4.Location = new System.Drawing.Point(190, 24);
		this.Label4.Name = "Label4";
		this.Label4.Size = new System.Drawing.Size(2, 120);
		this.Label4.TabIndex = 52;
		this.Label4.Text = "Label4";
		//
		//btnSetMaxBurnerHeight
		//
		this.btnSetMaxBurnerHeight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnSetMaxBurnerHeight.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnSetMaxBurnerHeight.Image = (System.Drawing.Image)resources.GetObject("btnSetMaxBurnerHeight.Image");
		this.btnSetMaxBurnerHeight.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnSetMaxBurnerHeight.Location = new System.Drawing.Point(466, 89);
		this.btnSetMaxBurnerHeight.Name = "btnSetMaxBurnerHeight";
		this.btnSetMaxBurnerHeight.Size = new System.Drawing.Size(120, 38);
		this.btnSetMaxBurnerHeight.TabIndex = 8;
		this.btnSetMaxBurnerHeight.Text = "Max.&Burner Height";
		this.btnSetMaxBurnerHeight.TextAlign = System.Drawing.ContentAlignment.TopLeft;
		//
		//btnSetMaxFuel
		//
		this.btnSetMaxFuel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnSetMaxFuel.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnSetMaxFuel.Image = (System.Drawing.Image)resources.GetObject("btnSetMaxFuel.Image");
		this.btnSetMaxFuel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnSetMaxFuel.Location = new System.Drawing.Point(337, 89);
		this.btnSetMaxFuel.Name = "btnSetMaxFuel";
		this.btnSetMaxFuel.Size = new System.Drawing.Size(120, 38);
		this.btnSetMaxFuel.TabIndex = 7;
		this.btnSetMaxFuel.Text = "Set Max.F&uel";
		this.btnSetMaxFuel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//btnIncreaseBurnerHeight
		//
		this.btnIncreaseBurnerHeight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnIncreaseBurnerHeight.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnIncreaseBurnerHeight.Image = (System.Drawing.Image)resources.GetObject("btnIncreaseBurnerHeight.Image");
		this.btnIncreaseBurnerHeight.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnIncreaseBurnerHeight.Location = new System.Drawing.Point(466, 5);
		this.btnIncreaseBurnerHeight.Name = "btnIncreaseBurnerHeight";
		this.btnIncreaseBurnerHeight.Size = new System.Drawing.Size(120, 38);
		this.btnIncreaseBurnerHeight.TabIndex = 2;
		this.btnIncreaseBurnerHeight.Text = "Decrease Burner &Height";
		this.btnIncreaseBurnerHeight.TextAlign = System.Drawing.ContentAlignment.TopLeft;
		//
		//btnDecreaseBurnerHeight
		//
		this.btnDecreaseBurnerHeight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnDecreaseBurnerHeight.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnDecreaseBurnerHeight.Image = (System.Drawing.Image)resources.GetObject("btnDecreaseBurnerHeight.Image");
		this.btnDecreaseBurnerHeight.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnDecreaseBurnerHeight.Location = new System.Drawing.Point(466, 47);
		this.btnDecreaseBurnerHeight.Name = "btnDecreaseBurnerHeight";
		this.btnDecreaseBurnerHeight.Size = new System.Drawing.Size(120, 38);
		this.btnDecreaseBurnerHeight.TabIndex = 5;
		this.btnDecreaseBurnerHeight.Text = "Increase Burner Heigh&t";
		this.btnDecreaseBurnerHeight.TextAlign = System.Drawing.ContentAlignment.TopLeft;
		//
		//btnDecreaseFuel
		//
		this.btnDecreaseFuel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnDecreaseFuel.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnDecreaseFuel.Image = (System.Drawing.Image)resources.GetObject("btnDecreaseFuel.Image");
		this.btnDecreaseFuel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnDecreaseFuel.Location = new System.Drawing.Point(337, 47);
		this.btnDecreaseFuel.Name = "btnDecreaseFuel";
		this.btnDecreaseFuel.Size = new System.Drawing.Size(120, 38);
		this.btnDecreaseFuel.TabIndex = 4;
		this.btnDecreaseFuel.Text = "Decrea&se Fuel";
		this.btnDecreaseFuel.TextAlign = System.Drawing.ContentAlignment.TopLeft;
		//
		//btnIncreaseFuel
		//
		this.btnIncreaseFuel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnIncreaseFuel.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnIncreaseFuel.Image = (System.Drawing.Image)resources.GetObject("btnIncreaseFuel.Image");
		this.btnIncreaseFuel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnIncreaseFuel.Location = new System.Drawing.Point(337, 5);
		this.btnIncreaseFuel.Name = "btnIncreaseFuel";
		this.btnIncreaseFuel.Size = new System.Drawing.Size(120, 38);
		this.btnIncreaseFuel.TabIndex = 1;
		this.btnIncreaseFuel.Text = "Increase    Fue&l";
		this.btnIncreaseFuel.TextAlign = System.Drawing.ContentAlignment.TopLeft;
		//
		//btnIgnite
		//
		this.btnIgnite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnIgnite.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnIgnite.Image = (System.Drawing.Image)resources.GetObject("btnIgnite.Image");
		this.btnIgnite.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnIgnite.Location = new System.Drawing.Point(272, 131);
		this.btnIgnite.Name = "btnIgnite";
		this.btnIgnite.Size = new System.Drawing.Size(120, 38);
		this.btnIgnite.TabIndex = 9;
		this.btnIgnite.Text = "I&GNITE ON";
		//
		//btnFuel
		//
		this.btnFuel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnFuel.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnFuel.Image = (System.Drawing.Image)resources.GetObject("btnFuel.Image");
		this.btnFuel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnFuel.Location = new System.Drawing.Point(208, 89);
		this.btnFuel.Name = "btnFuel";
		this.btnFuel.Size = new System.Drawing.Size(120, 38);
		this.btnFuel.TabIndex = 6;
		this.btnFuel.Text = "&FUEL ";
		//
		//btnN2O
		//
		this.btnN2O.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnN2O.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnN2O.Image = (System.Drawing.Image)resources.GetObject("btnN2O.Image");
		this.btnN2O.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnN2O.Location = new System.Drawing.Point(208, 47);
		this.btnN2O.Name = "btnN2O";
		this.btnN2O.Size = new System.Drawing.Size(120, 38);
		this.btnN2O.TabIndex = 3;
		this.btnN2O.Text = "&N2O";
		//
		//btnAirOnOff
		//
		this.btnAirOnOff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnAirOnOff.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnAirOnOff.Image = (System.Drawing.Image)resources.GetObject("btnAirOnOff.Image");
		this.btnAirOnOff.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnAirOnOff.Location = new System.Drawing.Point(208, 5);
		this.btnAirOnOff.Name = "btnAirOnOff";
		this.btnAirOnOff.Size = new System.Drawing.Size(120, 38);
		this.btnAirOnOff.TabIndex = 0;
		this.btnAirOnOff.Text = "&AIR";
		//
		//btnN2OIgnite
		//
		this.btnN2OIgnite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnN2OIgnite.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnN2OIgnite.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnN2OIgnite.Location = new System.Drawing.Point(72, 152);
		this.btnN2OIgnite.Name = "btnN2OIgnite";
		this.btnN2OIgnite.Size = new System.Drawing.Size(5, 5);
		this.btnN2OIgnite.TabIndex = 71;
		this.btnN2OIgnite.TabStop = false;
		this.btnN2OIgnite.Text = "N2O&C";
		this.btnN2OIgnite.TextAlign = System.Drawing.ContentAlignment.TopLeft;
		//
		//btnClose
		//
		this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnClose.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnClose.Image = (System.Drawing.Image)resources.GetObject("btnClose.Image");
		this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnClose.Location = new System.Drawing.Point(403, 131);
		this.btnClose.Name = "btnClose";
		this.btnClose.Size = new System.Drawing.Size(120, 38);
		this.btnClose.TabIndex = 10;
		this.btnClose.Text = "C&LOSE";
		//
		//pbFlameType
		//
		this.pbFlameType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.pbFlameType.Location = new System.Drawing.Point(496, 80);
		this.pbFlameType.Name = "pbFlameType";
		this.pbFlameType.Size = new System.Drawing.Size(32, 32);
		this.pbFlameType.TabIndex = 77;
		this.pbFlameType.Visible = false;
		//
		//pbSafetyControlsDoor
		//
		this.pbSafetyControlsDoor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.pbSafetyControlsDoor.Location = new System.Drawing.Point(408, 80);
		this.pbSafetyControlsDoor.Name = "pbSafetyControlsDoor";
		this.pbSafetyControlsDoor.Size = new System.Drawing.Size(32, 32);
		this.pbSafetyControlsDoor.TabIndex = 76;
		this.pbSafetyControlsDoor.Visible = false;
		//
		//pbBurnerType
		//
		this.pbBurnerType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.pbBurnerType.Location = new System.Drawing.Point(288, 80);
		this.pbBurnerType.Name = "pbBurnerType";
		this.pbBurnerType.Size = new System.Drawing.Size(32, 32);
		this.pbBurnerType.TabIndex = 75;
		this.pbBurnerType.Visible = false;
		//
		//pbStatusFuel
		//
		this.pbStatusFuel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.pbStatusFuel.Location = new System.Drawing.Point(240, 80);
		this.pbStatusFuel.Name = "pbStatusFuel";
		this.pbStatusFuel.Size = new System.Drawing.Size(32, 32);
		this.pbStatusFuel.TabIndex = 74;
		this.pbStatusFuel.Visible = false;
		//
		//pbStatusAir
		//
		this.pbStatusAir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.pbStatusAir.Location = new System.Drawing.Point(152, 80);
		this.pbStatusAir.Name = "pbStatusAir";
		this.pbStatusAir.Size = new System.Drawing.Size(32, 32);
		this.pbStatusAir.TabIndex = 72;
		this.pbStatusAir.Visible = false;
		//
		//pbPressureFuel
		//
		this.pbPressureFuel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.pbPressureFuel.Location = new System.Drawing.Point(104, 80);
		this.pbPressureFuel.Name = "pbPressureFuel";
		this.pbPressureFuel.Size = new System.Drawing.Size(32, 32);
		this.pbPressureFuel.TabIndex = 71;
		this.pbPressureFuel.Visible = false;
		//
		//pbPressureN2O
		//
		this.pbPressureN2O.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.pbPressureN2O.Location = new System.Drawing.Point(56, 80);
		this.pbPressureN2O.Name = "pbPressureN2O";
		this.pbPressureN2O.Size = new System.Drawing.Size(32, 32);
		this.pbPressureN2O.TabIndex = 70;
		this.pbPressureN2O.Visible = false;
		//
		//pbPressureAir
		//
		this.pbPressureAir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.pbPressureAir.Location = new System.Drawing.Point(16, 80);
		this.pbPressureAir.Name = "pbPressureAir";
		this.pbPressureAir.Size = new System.Drawing.Size(32, 32);
		this.pbPressureAir.TabIndex = 69;
		this.pbPressureAir.Visible = false;
		//
		//lblBHeight
		//
		this.lblBHeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblBHeight.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblBHeight.Location = new System.Drawing.Point(328, 80);
		this.lblBHeight.Name = "lblBHeight";
		this.lblBHeight.Size = new System.Drawing.Size(62, 32);
		this.lblBHeight.TabIndex = 65;
		this.lblBHeight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		//
		//lblFRatio
		//
		this.lblFRatio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblFRatio.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblFRatio.Location = new System.Drawing.Point(536, 80);
		this.lblFRatio.Name = "lblFRatio";
		this.lblFRatio.Size = new System.Drawing.Size(52, 32);
		this.lblFRatio.TabIndex = 64;
		this.lblFRatio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		//
		//Label2
		//
		this.Label2.BackColor = System.Drawing.SystemColors.Control;
		this.Label2.Location = new System.Drawing.Point(0, 112);
		this.Label2.Name = "Label2";
		this.Label2.Size = new System.Drawing.Size(759, 2);
		this.Label2.TabIndex = 40;
		//
		//lblBurnerHeight
		//
		this.lblBurnerHeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblBurnerHeight.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblBurnerHeight.Location = new System.Drawing.Point(328, 56);
		this.lblBurnerHeight.Name = "lblBurnerHeight";
		this.lblBurnerHeight.Size = new System.Drawing.Size(62, 24);
		this.lblBurnerHeight.TabIndex = 38;
		this.lblBurnerHeight.Text = "HEIGHT";
		this.lblBurnerHeight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		//
		//pbSafetyControlsTrap
		//
		this.pbSafetyControlsTrap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.pbSafetyControlsTrap.Location = new System.Drawing.Point(448, 80);
		this.pbSafetyControlsTrap.Name = "pbSafetyControlsTrap";
		this.pbSafetyControlsTrap.Size = new System.Drawing.Size(32, 32);
		this.pbSafetyControlsTrap.TabIndex = 34;
		this.pbSafetyControlsTrap.TabStop = false;
		this.pbSafetyControlsTrap.Visible = false;
		//
		//lblFlameRatio
		//
		this.lblFlameRatio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblFlameRatio.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblFlameRatio.Location = new System.Drawing.Point(536, 56);
		this.lblFlameRatio.Name = "lblFlameRatio";
		this.lblFlameRatio.Size = new System.Drawing.Size(52, 24);
		this.lblFlameRatio.TabIndex = 24;
		this.lblFlameRatio.Text = "RATIO";
		this.lblFlameRatio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		//
		//lblFlameType
		//
		this.lblFlameType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblFlameType.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblFlameType.Location = new System.Drawing.Point(496, 56);
		this.lblFlameType.Name = "lblFlameType";
		this.lblFlameType.Size = new System.Drawing.Size(44, 24);
		this.lblFlameType.TabIndex = 23;
		this.lblFlameType.Text = "TYPE";
		this.lblFlameType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		//
		//lblSafetyControlsTrap
		//
		this.lblSafetyControlsTrap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblSafetyControlsTrap.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblSafetyControlsTrap.Location = new System.Drawing.Point(448, 56);
		this.lblSafetyControlsTrap.Name = "lblSafetyControlsTrap";
		this.lblSafetyControlsTrap.Size = new System.Drawing.Size(44, 24);
		this.lblSafetyControlsTrap.TabIndex = 22;
		this.lblSafetyControlsTrap.Text = "TRAP";
		this.lblSafetyControlsTrap.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		//
		//lblSafetyControlsDoor
		//
		this.lblSafetyControlsDoor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblSafetyControlsDoor.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblSafetyControlsDoor.Location = new System.Drawing.Point(400, 56);
		this.lblSafetyControlsDoor.Name = "lblSafetyControlsDoor";
		this.lblSafetyControlsDoor.Size = new System.Drawing.Size(48, 24);
		this.lblSafetyControlsDoor.TabIndex = 21;
		this.lblSafetyControlsDoor.Text = "DOOR";
		this.lblSafetyControlsDoor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		//
		//lblBurnerType
		//
		this.lblBurnerType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblBurnerType.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblBurnerType.Location = new System.Drawing.Point(288, 56);
		this.lblBurnerType.Name = "lblBurnerType";
		this.lblBurnerType.Size = new System.Drawing.Size(44, 24);
		this.lblBurnerType.TabIndex = 20;
		this.lblBurnerType.Text = "TYPE";
		this.lblBurnerType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		//
		//lblStatusFuel
		//
		this.lblStatusFuel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblStatusFuel.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblStatusFuel.Location = new System.Drawing.Point(240, 56);
		this.lblStatusFuel.Name = "lblStatusFuel";
		this.lblStatusFuel.Size = new System.Drawing.Size(44, 24);
		this.lblStatusFuel.TabIndex = 19;
		this.lblStatusFuel.Text = "FUEL";
		this.lblStatusFuel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		//
		//lblStatusN2O
		//
		this.lblStatusN2O.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblStatusN2O.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblStatusN2O.Location = new System.Drawing.Point(192, 56);
		this.lblStatusN2O.Name = "lblStatusN2O";
		this.lblStatusN2O.Size = new System.Drawing.Size(44, 24);
		this.lblStatusN2O.TabIndex = 18;
		this.lblStatusN2O.Text = "N2O";
		this.lblStatusN2O.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		//
		//lblStatusAir
		//
		this.lblStatusAir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblStatusAir.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblStatusAir.Location = new System.Drawing.Point(144, 56);
		this.lblStatusAir.Name = "lblStatusAir";
		this.lblStatusAir.Size = new System.Drawing.Size(44, 24);
		this.lblStatusAir.TabIndex = 17;
		this.lblStatusAir.Text = "AIR";
		this.lblStatusAir.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		//
		//lblPressureFuel
		//
		this.lblPressureFuel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblPressureFuel.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblPressureFuel.Location = new System.Drawing.Point(96, 56);
		this.lblPressureFuel.Name = "lblPressureFuel";
		this.lblPressureFuel.Size = new System.Drawing.Size(44, 24);
		this.lblPressureFuel.TabIndex = 16;
		this.lblPressureFuel.Text = "FUEL";
		this.lblPressureFuel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		//
		//lblPressureN2O
		//
		this.lblPressureN2O.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblPressureN2O.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblPressureN2O.Location = new System.Drawing.Point(56, 56);
		this.lblPressureN2O.Name = "lblPressureN2O";
		this.lblPressureN2O.Size = new System.Drawing.Size(44, 24);
		this.lblPressureN2O.TabIndex = 15;
		this.lblPressureN2O.Text = "N2O";
		this.lblPressureN2O.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		//
		//lblPressureAir
		//
		this.lblPressureAir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblPressureAir.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblPressureAir.Location = new System.Drawing.Point(8, 56);
		this.lblPressureAir.Name = "lblPressureAir";
		this.lblPressureAir.Size = new System.Drawing.Size(44, 24);
		this.lblPressureAir.TabIndex = 14;
		this.lblPressureAir.Text = "AIR";
		this.lblPressureAir.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		//
		//lblFlame
		//
		this.lblFlame.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblFlame.Location = new System.Drawing.Point(504, 8);
		this.lblFlame.Name = "lblFlame";
		this.lblFlame.Size = new System.Drawing.Size(80, 32);
		this.lblFlame.TabIndex = 11;
		this.lblFlame.Text = "FLAME";
		this.lblFlame.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
		//
		//lblSafetyControls
		//
		this.lblSafetyControls.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblSafetyControls.Location = new System.Drawing.Point(400, 8);
		this.lblSafetyControls.Name = "lblSafetyControls";
		this.lblSafetyControls.Size = new System.Drawing.Size(84, 32);
		this.lblSafetyControls.TabIndex = 10;
		this.lblSafetyControls.Text = "SAFETY CONTROLS";
		this.lblSafetyControls.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
		//
		//lblBurner
		//
		this.lblBurner.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblBurner.Location = new System.Drawing.Point(288, 8);
		this.lblBurner.Name = "lblBurner";
		this.lblBurner.Size = new System.Drawing.Size(96, 32);
		this.lblBurner.TabIndex = 9;
		this.lblBurner.Text = "BURNER";
		this.lblBurner.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
		//
		//lblPressureValveStatus
		//
		this.lblPressureValveStatus.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblPressureValveStatus.Location = new System.Drawing.Point(160, 8);
		this.lblPressureValveStatus.Name = "lblPressureValveStatus";
		this.lblPressureValveStatus.Size = new System.Drawing.Size(108, 32);
		this.lblPressureValveStatus.TabIndex = 8;
		this.lblPressureValveStatus.Text = "PRESSURE VALVE STATUS";
		this.lblPressureValveStatus.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
		//
		//lblPressures
		//
		this.lblPressures.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblPressures.Location = new System.Drawing.Point(16, 8);
		this.lblPressures.Name = "lblPressures";
		this.lblPressures.Size = new System.Drawing.Size(110, 32);
		this.lblPressures.TabIndex = 7;
		this.lblPressures.Text = "PRESSURES";
		this.lblPressures.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
		//
		//Label7
		//
		this.Label7.BackColor = System.Drawing.SystemColors.Control;
		this.Label7.Location = new System.Drawing.Point(392, 0);
		this.Label7.Name = "Label7";
		this.Label7.Size = new System.Drawing.Size(2, 116);
		this.Label7.TabIndex = 6;
		this.Label7.Text = "Label7";
		//
		//Label6
		//
		this.Label6.BackColor = System.Drawing.SystemColors.Control;
		this.Label6.Location = new System.Drawing.Point(488, 0);
		this.Label6.Name = "Label6";
		this.Label6.Size = new System.Drawing.Size(2, 116);
		this.Label6.TabIndex = 5;
		this.Label6.Text = "Label6";
		//
		//Label5
		//
		this.Label5.BackColor = System.Drawing.SystemColors.Control;
		this.Label5.Location = new System.Drawing.Point(280, 0);
		this.Label5.Name = "Label5";
		this.Label5.Size = new System.Drawing.Size(2, 116);
		this.Label5.TabIndex = 4;
		this.Label5.Text = "Label5";
		//
		//Label3
		//
		this.Label3.BackColor = System.Drawing.SystemColors.Control;
		this.Label3.Location = new System.Drawing.Point(144, 0);
		this.Label3.Name = "Label3";
		this.Label3.Size = new System.Drawing.Size(2, 116);
		this.Label3.TabIndex = 2;
		this.Label3.Text = "Label3";
		//
		//Label1
		//
		this.Label1.BackColor = System.Drawing.SystemColors.Control;
		this.Label1.Location = new System.Drawing.Point(0, 48);
		this.Label1.Name = "Label1";
		this.Label1.Size = new System.Drawing.Size(759, 2);
		this.Label1.TabIndex = 0;
		//
		//tmrCheckManualIgnite
		//
		this.tmrCheckManualIgnite.Interval = 400;
		this.tmrCheckManualIgnite.SynchronizingObject = this;
		//
		//custpnlStatusDisplay
		//
		this.custpnlStatusDisplay.BackColor = System.Drawing.Color.AliceBlue;
		this.custpnlStatusDisplay.Controls.Add(this.pnl201);
		this.custpnlStatusDisplay.Controls.Add(this.pnl203);
		this.custpnlStatusDisplay.Dock = System.Windows.Forms.DockStyle.Top;
		this.custpnlStatusDisplay.Location = new System.Drawing.Point(0, 0);
		this.custpnlStatusDisplay.Name = "custpnlStatusDisplay";
		this.custpnlStatusDisplay.Size = new System.Drawing.Size(658, 160);
		this.custpnlStatusDisplay.TabIndex = 78;
		//
		//pnl201
		//
		this.pnl201.BackColor = System.Drawing.Color.AliceBlue;
		this.pnl201.Controls.Add(this.lblFlameType1);
		this.pnl201.Controls.Add(this.lblBurnerType1);
		this.pnl201.Controls.Add(this.lblStatusFuel1);
		this.pnl201.Controls.Add(this.lblStatusN2O1);
		this.pnl201.Controls.Add(this.lblStatusAir1);
		this.pnl201.Controls.Add(this.lblPressureFuel1);
		this.pnl201.Controls.Add(this.Label17);
		this.pnl201.Controls.Add(this.lblPressureAir1);
		this.pnl201.Controls.Add(this.lblFlame1);
		this.pnl201.Controls.Add(this.Label21);
		this.pnl201.Controls.Add(this.Label22);
		this.pnl201.Controls.Add(this.Label23);
		this.pnl201.Controls.Add(this.lblBurner1);
		this.pnl201.Controls.Add(this.lblPressureValveStatus1);
		this.pnl201.Controls.Add(this.pbFlameType1);
		this.pnl201.Controls.Add(this.pbBurnerType1);
		this.pnl201.Controls.Add(this.pbStatusFuel1);
		this.pnl201.Controls.Add(this.pbStatusN2O1);
		this.pnl201.Controls.Add(this.pbStatusAir1);
		this.pnl201.Controls.Add(this.pbPressureFuel1);
		this.pnl201.Controls.Add(this.pbPressureN2O1);
		this.pnl201.Controls.Add(this.pbPressureAir1);
		this.pnl201.Controls.Add(this.lblPressures1);
		this.pnl201.Controls.Add(this.lblFRatio1);
		this.pnl201.Controls.Add(this.lblPressureN2O1);
		this.pnl201.Controls.Add(this.lblFlameRatio1);
		this.pnl201.Controls.Add(this.Label42);
		this.pnl201.Location = new System.Drawing.Point(16, 32);
		this.pnl201.Name = "pnl201";
		this.pnl201.Size = new System.Drawing.Size(472, 120);
		this.pnl201.TabIndex = 80;
		//
		//lblFlameType1
		//
		this.lblFlameType1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblFlameType1.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblFlameType1.Location = new System.Drawing.Point(360, 56);
		this.lblFlameType1.Name = "lblFlameType1";
		this.lblFlameType1.Size = new System.Drawing.Size(44, 24);
		this.lblFlameType1.TabIndex = 23;
		this.lblFlameType1.Text = "TYPE";
		this.lblFlameType1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		//
		//lblBurnerType1
		//
		this.lblBurnerType1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblBurnerType1.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblBurnerType1.Location = new System.Drawing.Point(296, 56);
		this.lblBurnerType1.Name = "lblBurnerType1";
		this.lblBurnerType1.Size = new System.Drawing.Size(44, 24);
		this.lblBurnerType1.TabIndex = 20;
		this.lblBurnerType1.Text = "TYPE";
		this.lblBurnerType1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		//
		//lblStatusFuel1
		//
		this.lblStatusFuel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblStatusFuel1.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblStatusFuel1.Location = new System.Drawing.Point(233, 54);
		this.lblStatusFuel1.Name = "lblStatusFuel1";
		this.lblStatusFuel1.Size = new System.Drawing.Size(44, 24);
		this.lblStatusFuel1.TabIndex = 19;
		this.lblStatusFuel1.Text = "FUEL";
		this.lblStatusFuel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		//
		//lblStatusN2O1
		//
		this.lblStatusN2O1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblStatusN2O1.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblStatusN2O1.Location = new System.Drawing.Point(188, 54);
		this.lblStatusN2O1.Name = "lblStatusN2O1";
		this.lblStatusN2O1.Size = new System.Drawing.Size(44, 24);
		this.lblStatusN2O1.TabIndex = 18;
		this.lblStatusN2O1.Text = "N2O";
		this.lblStatusN2O1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		//
		//lblStatusAir1
		//
		this.lblStatusAir1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblStatusAir1.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblStatusAir1.Location = new System.Drawing.Point(143, 54);
		this.lblStatusAir1.Name = "lblStatusAir1";
		this.lblStatusAir1.Size = new System.Drawing.Size(44, 24);
		this.lblStatusAir1.TabIndex = 17;
		this.lblStatusAir1.Text = "AIR";
		this.lblStatusAir1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		//
		//lblPressureFuel1
		//
		this.lblPressureFuel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblPressureFuel1.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblPressureFuel1.Location = new System.Drawing.Point(95, 54);
		this.lblPressureFuel1.Name = "lblPressureFuel1";
		this.lblPressureFuel1.Size = new System.Drawing.Size(44, 24);
		this.lblPressureFuel1.TabIndex = 16;
		this.lblPressureFuel1.Text = "FUEL";
		this.lblPressureFuel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		//
		//Label17
		//
		this.Label17.BackColor = System.Drawing.SystemColors.Control;
		this.Label17.Location = new System.Drawing.Point(352, 0);
		this.Label17.Name = "Label17";
		this.Label17.Size = new System.Drawing.Size(2, 116);
		this.Label17.TabIndex = 6;
		this.Label17.Text = "Label7";
		//
		//lblPressureAir1
		//
		this.lblPressureAir1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblPressureAir1.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblPressureAir1.Location = new System.Drawing.Point(5, 54);
		this.lblPressureAir1.Name = "lblPressureAir1";
		this.lblPressureAir1.Size = new System.Drawing.Size(44, 24);
		this.lblPressureAir1.TabIndex = 14;
		this.lblPressureAir1.Text = "AIR";
		this.lblPressureAir1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		//
		//lblFlame1
		//
		this.lblFlame1.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblFlame1.Location = new System.Drawing.Point(360, 24);
		this.lblFlame1.Name = "lblFlame1";
		this.lblFlame1.Size = new System.Drawing.Size(80, 16);
		this.lblFlame1.TabIndex = 11;
		this.lblFlame1.Text = "FLAME";
		this.lblFlame1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
		//
		//Label21
		//
		this.Label21.BackColor = System.Drawing.SystemColors.Control;
		this.Label21.Location = new System.Drawing.Point(278, 0);
		this.Label21.Name = "Label21";
		this.Label21.Size = new System.Drawing.Size(2, 116);
		this.Label21.TabIndex = 4;
		this.Label21.Text = "Label5";
		//
		//Label22
		//
		this.Label22.BackColor = System.Drawing.SystemColors.Control;
		this.Label22.Location = new System.Drawing.Point(140, 0);
		this.Label22.Name = "Label22";
		this.Label22.Size = new System.Drawing.Size(2, 116);
		this.Label22.TabIndex = 2;
		this.Label22.Text = "Label3";
		//
		//Label23
		//
		this.Label23.BackColor = System.Drawing.SystemColors.Control;
		this.Label23.Location = new System.Drawing.Point(0, 48);
		this.Label23.Name = "Label23";
		this.Label23.Size = new System.Drawing.Size(759, 2);
		this.Label23.TabIndex = 0;
		//
		//lblBurner1
		//
		this.lblBurner1.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblBurner1.Location = new System.Drawing.Point(288, 24);
		this.lblBurner1.Name = "lblBurner1";
		this.lblBurner1.Size = new System.Drawing.Size(64, 16);
		this.lblBurner1.TabIndex = 9;
		this.lblBurner1.Text = "BURNER";
		this.lblBurner1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
		//
		//lblPressureValveStatus1
		//
		this.lblPressureValveStatus1.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblPressureValveStatus1.Location = new System.Drawing.Point(156, 8);
		this.lblPressureValveStatus1.Name = "lblPressureValveStatus1";
		this.lblPressureValveStatus1.Size = new System.Drawing.Size(108, 32);
		this.lblPressureValveStatus1.TabIndex = 8;
		this.lblPressureValveStatus1.Text = "PRESSURE VALVE STATUS";
		this.lblPressureValveStatus1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
		//
		//pbFlameType1
		//
		this.pbFlameType1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.pbFlameType1.Location = new System.Drawing.Point(368, 80);
		this.pbFlameType1.Name = "pbFlameType1";
		this.pbFlameType1.Size = new System.Drawing.Size(32, 32);
		this.pbFlameType1.TabIndex = 77;
		this.pbFlameType1.Visible = false;
		//
		//pbBurnerType1
		//
		this.pbBurnerType1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.pbBurnerType1.Location = new System.Drawing.Point(304, 80);
		this.pbBurnerType1.Name = "pbBurnerType1";
		this.pbBurnerType1.Size = new System.Drawing.Size(32, 32);
		this.pbBurnerType1.TabIndex = 75;
		this.pbBurnerType1.Visible = false;
		//
		//pbStatusFuel1
		//
		this.pbStatusFuel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.pbStatusFuel1.Location = new System.Drawing.Point(239, 80);
		this.pbStatusFuel1.Name = "pbStatusFuel1";
		this.pbStatusFuel1.Size = new System.Drawing.Size(32, 32);
		this.pbStatusFuel1.TabIndex = 74;
		this.pbStatusFuel1.Visible = false;
		//
		//pbStatusN2O1
		//
		this.pbStatusN2O1.BackColor = System.Drawing.Color.Transparent;
		this.pbStatusN2O1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.pbStatusN2O1.Location = new System.Drawing.Point(194, 80);
		this.pbStatusN2O1.Name = "pbStatusN2O1";
		this.pbStatusN2O1.Size = new System.Drawing.Size(32, 32);
		this.pbStatusN2O1.TabIndex = 73;
		this.pbStatusN2O1.Visible = false;
		//
		//pbStatusAir1
		//
		this.pbStatusAir1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.pbStatusAir1.Location = new System.Drawing.Point(149, 80);
		this.pbStatusAir1.Name = "pbStatusAir1";
		this.pbStatusAir1.Size = new System.Drawing.Size(32, 32);
		this.pbStatusAir1.TabIndex = 72;
		this.pbStatusAir1.Visible = false;
		//
		//pbPressureFuel1
		//
		this.pbPressureFuel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.pbPressureFuel1.Location = new System.Drawing.Point(101, 80);
		this.pbPressureFuel1.Name = "pbPressureFuel1";
		this.pbPressureFuel1.Size = new System.Drawing.Size(32, 32);
		this.pbPressureFuel1.TabIndex = 71;
		this.pbPressureFuel1.Visible = false;
		//
		//pbPressureN2O1
		//
		this.pbPressureN2O1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.pbPressureN2O1.Location = new System.Drawing.Point(55, 80);
		this.pbPressureN2O1.Name = "pbPressureN2O1";
		this.pbPressureN2O1.Size = new System.Drawing.Size(32, 32);
		this.pbPressureN2O1.TabIndex = 70;
		this.pbPressureN2O1.Visible = false;
		//
		//pbPressureAir1
		//
		this.pbPressureAir1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.pbPressureAir1.Location = new System.Drawing.Point(11, 80);
		this.pbPressureAir1.Name = "pbPressureAir1";
		this.pbPressureAir1.Size = new System.Drawing.Size(32, 32);
		this.pbPressureAir1.TabIndex = 69;
		this.pbPressureAir1.Visible = false;
		//
		//lblPressures1
		//
		this.lblPressures1.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblPressures1.Location = new System.Drawing.Point(16, 8);
		this.lblPressures1.Name = "lblPressures1";
		this.lblPressures1.Size = new System.Drawing.Size(110, 32);
		this.lblPressures1.TabIndex = 7;
		this.lblPressures1.Text = "PRESSURES";
		this.lblPressures1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
		//
		//lblFRatio1
		//
		this.lblFRatio1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblFRatio1.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblFRatio1.Location = new System.Drawing.Point(408, 80);
		this.lblFRatio1.Name = "lblFRatio1";
		this.lblFRatio1.Size = new System.Drawing.Size(52, 32);
		this.lblFRatio1.TabIndex = 64;
		this.lblFRatio1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		//
		//lblPressureN2O1
		//
		this.lblPressureN2O1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblPressureN2O1.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblPressureN2O1.Location = new System.Drawing.Point(50, 54);
		this.lblPressureN2O1.Name = "lblPressureN2O1";
		this.lblPressureN2O1.Size = new System.Drawing.Size(44, 24);
		this.lblPressureN2O1.TabIndex = 15;
		this.lblPressureN2O1.Text = "N2O";
		this.lblPressureN2O1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		//
		//lblFlameRatio1
		//
		this.lblFlameRatio1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblFlameRatio1.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblFlameRatio1.Location = new System.Drawing.Point(408, 56);
		this.lblFlameRatio1.Name = "lblFlameRatio1";
		this.lblFlameRatio1.Size = new System.Drawing.Size(52, 24);
		this.lblFlameRatio1.TabIndex = 24;
		this.lblFlameRatio1.Text = "RATIO";
		this.lblFlameRatio1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		//
		//Label42
		//
		this.Label42.BackColor = System.Drawing.SystemColors.Control;
		this.Label42.Location = new System.Drawing.Point(0, 115);
		this.Label42.Name = "Label42";
		this.Label42.Size = new System.Drawing.Size(759, 2);
		this.Label42.TabIndex = 40;
		//
		//pnl203
		//
		this.pnl203.BackColor = System.Drawing.Color.AliceBlue;
		this.pnl203.Controls.Add(this.pbSafetyControlsTrap);
		this.pnl203.Controls.Add(this.lblFlameRatio);
		this.pnl203.Controls.Add(this.lblFlameType);
		this.pnl203.Controls.Add(this.lblSafetyControlsTrap);
		this.pnl203.Controls.Add(this.lblSafetyControlsDoor);
		this.pnl203.Controls.Add(this.lblBurnerType);
		this.pnl203.Controls.Add(this.lblStatusFuel);
		this.pnl203.Controls.Add(this.lblStatusN2O);
		this.pnl203.Controls.Add(this.lblStatusAir);
		this.pnl203.Controls.Add(this.lblPressureFuel);
		this.pnl203.Controls.Add(this.lblPressureN2O);
		this.pnl203.Controls.Add(this.lblPressureAir);
		this.pnl203.Controls.Add(this.lblFlame);
		this.pnl203.Controls.Add(this.lblSafetyControls);
		this.pnl203.Controls.Add(this.lblBurner);
		this.pnl203.Controls.Add(this.lblPressureValveStatus);
		this.pnl203.Controls.Add(this.lblPressures);
		this.pnl203.Controls.Add(this.Label7);
		this.pnl203.Controls.Add(this.Label6);
		this.pnl203.Controls.Add(this.Label5);
		this.pnl203.Controls.Add(this.Label3);
		this.pnl203.Controls.Add(this.Label1);
		this.pnl203.Controls.Add(this.pbStatusN2O);
		this.pnl203.Controls.Add(this.pbFlameType);
		this.pnl203.Controls.Add(this.pbSafetyControlsDoor);
		this.pnl203.Controls.Add(this.pbBurnerType);
		this.pnl203.Controls.Add(this.pbStatusFuel);
		this.pnl203.Controls.Add(this.pbStatusAir);
		this.pnl203.Controls.Add(this.pbPressureFuel);
		this.pnl203.Controls.Add(this.pbPressureN2O);
		this.pnl203.Controls.Add(this.pbPressureAir);
		this.pnl203.Controls.Add(this.lblBHeight);
		this.pnl203.Controls.Add(this.lblFRatio);
		this.pnl203.Controls.Add(this.Label2);
		this.pnl203.Controls.Add(this.lblBurnerHeight);
		this.pnl203.Location = new System.Drawing.Point(8, 8);
		this.pnl203.Name = "pnl203";
		this.pnl203.Size = new System.Drawing.Size(600, 128);
		this.pnl203.TabIndex = 81;
		//
		//pbStatusN2O
		//
		this.pbStatusN2O.BackColor = System.Drawing.Color.Transparent;
		this.pbStatusN2O.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.pbStatusN2O.Location = new System.Drawing.Point(200, 80);
		this.pbStatusN2O.Name = "pbStatusN2O";
		this.pbStatusN2O.Size = new System.Drawing.Size(32, 32);
		this.pbStatusN2O.TabIndex = 73;
		this.pbStatusN2O.Visible = false;
		//
		//frmManualIgnition
		//
		this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
		this.ClientSize = new System.Drawing.Size(658, 344);
		this.Controls.Add(this.CustomPanel1);
		this.Controls.Add(this.custpnlStatusDisplay);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		this.MaximizeBox = false;
		this.MinimizeBox = false;
		this.Name = "frmManualIgnition";
		this.ShowInTaskbar = false;
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.CustomPanel1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.CommandBar1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.tmrCheckManualIgnite).EndInit();
		this.custpnlStatusDisplay.ResumeLayout(false);
		this.pnl201.ResumeLayout(false);
		this.pnl203.ResumeLayout(false);
		this.ResumeLayout(false);

	}

	#End Region

	#Region " Public Enums, Constants.. "

	public enum enumManualIgnitionProcess
	{
		ManualIgnitionCheck,
		SetAirOnOff,
		SetN2OOnOff,
		SetFuelOnOff,
		SetIgniteOnOff,
		IncreaseFuel,
		DecreaseFuel,
		SetMaxFuel,
		IncreaseBurnerHeight,
		DecreaseBurnerHeight,
		SetMaxBurnerHeight,
		AutoIgnition,
		AutoExtinguish
	}

	#End Region

	#Region " Private Class Variables "

	//--- Declaration for the controller object of the BgThread
	private BgThread.clsBgThread mobjController = new BgThread.clsBgThread(this);

	private ClsBgManualIgnition mobjclsBgManualIgnition;

	private bool mblnN2OPresure = false;
	private bool blnPressureSensor1 = true;
	private bool blnPressureSensor2 = true;
	private bool blnPressureSensor3 = true;
	private bool blnBurner = false;
	private bool aa;
	private bool ps1;
	private bool ps2;
	private bool ps3;
	private bool air;
	private bool n2;
	private bool fuel;
	private bool BIgnite;
	private Threading.Thread mobjThread;
	private static enumManualIgnitionProcess mintManualIgnitionProcess;
	private static bool mblnIsStopThreadAndExit;
	private bool mblnIsfrmFlameStatusWork = false;
	private bool mblnInProcess = false;
	private bool mblnIsManualIgnitionActivated = false;
	private bool mblnIgnitionWait = false;
	private bool mblnIgnitionTerminate = false;
	private int mintIgniteType;
	//Private mblnAvoidProcessing As Boolean
	private int intFlameType;

	private bool mblnAvoidProcessing = false;
	//Private mblnFuelFlowRateMsgDisp As Boolean = False   'Commented on 30.03.09
		//30.03.09
	private bool mblnFlamePresent;
	//Private mblnIsN2OBurnerPresent As Boolean  '30.03.09    'commented on 26.04.09 for ver 4.87
		//30.03.09
	private bool mblnFuelPressure;
		#End Region
	private bool mblnIsAir_Not_OK = false;

	#Region " Form Load and Events Handling Functions "

	private void  // ERROR: Handles clauses are not supported in C#
frmManualIgnition_Load(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : frmManualIgnition_Load
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To initialize the form
		// Description           : this is called when the form is loaded
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 27.11.06
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		int intCtrlCount;
		byte status;

		try {
			this.Focus();
			btnClose.BringToFront();

			this.Text = gstrTitleInstrumentType + " Manual Ignition";
			//'this will show Manual Ignition 
			mblnIsStopThreadAndExit = false;

			this.Focus();
			//Me.Refresh()

			//Call Manual_Init_Check()     'Commented by Saurabh

			//Application.DoEvents()
			//'allow application to perfrom its panding work
			AddHandlers();
			//'add all the events
			btnAirOnOff.Focus();
			//'get the focus on air button

			mintManualIgnitionProcess = enumManualIgnitionProcess.ManualIgnitionCheck;

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
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	private void InitFromObject()
	{
		byte status;
		if (mblnAvoidProcessing) {
			return;
		}
		try {
			Application.DoEvents();
			if (!IsNothing(gobjMain)) {
				if (gobjMain.mobjController.IsThreadRunning == true) {
					mblnIsfrmFlameStatusWork = true;
					gobjMain.mobjController.Cancel();
					gobjCommProtocol.mobjCommdll.subTime_Delay(500);
					//10.12.07
					Application.DoEvents();
				}
				Application.DoEvents();
			}

			air = false;
			n2 = false;
			fuel = false;
			BIgnite = false;

			//'set some initial flag
			if (gobjCommProtocol.func_IGNITE_OFF()) {
				//'this is a serial communication function which put off a ingition 
				//gobjInst.Aaf = False
			}

			//If BIgnite = False Then
			btnIgnite.Text = "IGNITE ON";
			//'set text on button
			//Else
			//   btnIgnite.Text = "IGNITE ON"
			//End If
			gobjCommProtocol.mobjCommdll.subTime_Delay(20);
			//'delay
			status = gobjCommProtocol.funcGet_Pneum_Status();
			//'this is used To get the pnueumatics status
			//'and set a status flag as par return 

			//---Commented on 30.03.09
			//'If (status And EnumErrorStatus.SAIR_NON) Then
			//'    ''check for thta status should be true and display it on screen
			//'    air = True
			//'    btnAirOnOff.Text = ""
			//'Else
			//'    air = False
			//'    btnAirOnOff.Text = ""
			//'End If

			//'If (status And EnumErrorStatus.SN2O_NON) Then
			//'    ''check for thta status should be true and display it on screen
			//'    n2 = True
			//'    btnN2O.Text = ""
			//'Else
			//'    n2 = False
			//'    btnN2O.Text = ""
			//'End If

			//'If (status And EnumErrorStatus.SFUEL_ON) Then
			//'    ''check for thta status should be true and display it on screen
			//'    fuel = True
			//'    btnFuel.Text = ""
			//'Else
			//'    fuel = False
			//'    btnFuel.Text = ""
			//'End If
			//-------------------------------------

			//---Written on 30.03.09
			if ((status & EnumErrorStatus.SAIR_NON)) {
				air = false;
			} else {
				air = true;
			}


			//If (status And EnumErrorStatus.SN2O_NON) Then  '---25.06.09 commented for version 4.91
			//    n2 = False
			//Else
			//    n2 = True
			//End If

			//---25.06.09 added for version 4.91
			if (gstructSettings.AppMode == EnumAppMode.FullVersion_201) {
				if ((status & EnumErrorStatus.SN2O_NON)) {
					n2 = false;
				} else {
					n2 = true;
				}
			} else {
				if ((status & EnumErrorStatus.SN2O_NON)) {
					n2 = true;
				} else {
					n2 = false;
				}
			}


			if ((status & EnumErrorStatus.SFUEL_ON)) {
				fuel = true;
			} else {
				fuel = false;
			}
			//-------------------------



			if (mblnIsManualIgnitionActivated == false) {
				mblnAvoidProcessing = true;

				if (mobjController == null) {
					mobjController = new clsBgThread(this);
				}
				if (mobjclsBgManualIgnition == null) {
					mobjclsBgManualIgnition = new ClsBgManualIgnition();
				}
				gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay);
				//10.12.07
				Application.DoEvents();
				if (mobjController.IsThreadRunning == false) {
					mobjController.Start(mobjclsBgManualIgnition);
					mobjclsBgManualIgnition.ManualIgnition += subWaitManualThread;
				}
				mblnIsManualIgnitionActivated = true;
				mblnAvoidProcessing = false;
			}
			this.Focus();
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

	private void setVisibleFalse201Controls()
	{
		//=====================================================================
		// Procedure Name        : disable201Controls
		// Parameters Passed     :  
		// Returns               : None
		// Purpose               :  
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Pankaj
		// Created               : 30 May 07
		// Revisions             : 
		//=====================================================================


		//'note:
		//'screen contains some control for 201 also
		//'and during the 203 it should hide

		bool flag = false;
		if ((gstructSettings.AppMode == EnumAppMode.FullVersion_201) | (gstructSettings.AppMode == EnumAppMode.DemoMode_201)) {
			btnAirOnOff.Visible = flag;
			btnAutoIgnite.Visible = flag;
			btnDecreaseBurnerHeight.Visible = flag;
			btnDecreaseFuel.Visible = flag;
			btnExtinguish.Visible = flag;
			btnIgnite.Visible = flag;
			btnIncreaseBurnerHeight.Visible = flag;
			btnIncreaseFuel.Visible = flag;
			btnSetMaxBurnerHeight.Visible = flag;
			btnSetMaxFuel.Visible = flag;

			lblBHeight.Visible = flag;
			lblBurnerHeight.Visible = flag;
			lblFlameRatio.Visible = flag;
			lblFRatio.Visible = flag;
			lblSafetyControlsTrap.Visible = flag;
			pbSafetyControlsTrap.Visible = flag;
			lblNVStep.Visible = flag;
			lblNVStep1.Visible = flag;
			lblSafetyControlsDoor.Visible = flag;
			pbSafetyControlsDoor.Visible = flag;

			//' code added by : dinesh wagh on 20.3.2009
			//... code start
			btnClose.Location = btnSetMaxFuel.Location;
			pbPressureAir1.Visible = true;
			pbPressureN2O1.Visible = true;
			pbPressureFuel1.Visible = true;
			pbStatusAir1.Visible = true;
			pbStatusN2O1.Visible = true;
			pbStatusFuel1.Visible = true;
			pbBurnerType1.Visible = true;
			pbFlameType1.Visible = true;
			lblFRatio1.Visible = true;
			// code ends
			//......
		}

	}

	private void btnClose_Click(object sender, System.EventArgs e)
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
			Application.DoEvents();
			if (mblnIgnitionTerminate == false) {
				mobjclsBgManualIgnition.ThTerminate = true;
				mobjclsBgManualIgnition.IgnitionWait = true;
				mblnIgnitionWait = true;
				gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay);
				//10.12.07
				Application.DoEvents();
				btnClose_Click(sender, e);
				return;
			} else {
				if (!(mobjController == null)) {
					if (mobjController.IsThreadRunning) {
						mobjclsBgManualIgnition.ThTerminate = true;
						mobjclsBgManualIgnition.IgnitionWait = true;
						mblnIgnitionWait = true;
						mobjController.Cancel();
						gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay);
						//10.12.07
						Application.DoEvents();
					}
				}
				//Exit Sub
			}
			gobjclsTimer.subTimerStop();
			Application.DoEvents();
			this.DialogResult = DialogResult.OK;
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
			//Me.DialogResult = DialogResult.Cancel
			//Me.Close()
			//---------------------------------------------------------
		}
	}

	private void btnAirOnOff_Click(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : btnAirOnOff_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To make the AIR Flow ON or OFF
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 27.11.06
		// Revisions             : 
		//=====================================================================

		//'note:
		//'this is called when user clicked on Air button
		//'this is used to Put air on or off as paer cond
		//'step 1:first stop the thread 
		//'step 2:check air is on
		//'step 3:if yes then put air off else put air off
		//'step 4:do some onscreen validation as par cond






		if (mblnInProcess == true) {
			//'htis is a flag which check for other running process
			return;
		}
		CWaitCursor objWait = new CWaitCursor();
		try {
			mblnInProcess = true;

			//mblnIsStopThreadAndExit = True
			//mobjThread.Sleep(100)
			//mobjThread.Join()
			//If Not mobjThread.ThreadState = ThreadState.Suspended Then
			//    mobjThread.Suspend()
			//End If

			//mintManualIgnitionProcess = enumManualIgnitionProcess.SetAirOnOff
			mblnIgnitionWait = true;
			mobjclsBgManualIgnition.IgnitionWait = true;
			gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay);
			//10.12.07
			Application.DoEvents();
			//'allow manual thread to be wait

			Application.DoEvents();
			//'allow application to perfrom its panding work

			subSetAirOnOff();

			//'this function is used for on or off the air

			mblnIgnitionWait = false;
			mblnInProcess = false;
			mobjclsBgManualIgnition.IgnitionWait = false;
			gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay);
			//10.12.07
			Application.DoEvents();
		//Call Manual_Init_Check()


		//mobjThread = New Threading.Thread(AddressOf subThreadStart)
		//mobjThread.IsBackground = True
		//mobjThread.Name = "Manual Ignition"

		//mobjThread.Resume()

		//Thread.Sleep(200)

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			mblnIgnitionWait = false;
			mblnInProcess = false;
			mobjclsBgManualIgnition.IgnitionWait = false;
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			if (!(objWait == null)) {
				objWait.Dispose();
				objWait = null;
			}
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	private void btnN2O_Click(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : btnN2O_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To make the N2O Flow ON or OFF
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 27.11.06
		// Revisions             : 
		//=====================================================================
		//'note:
		//'this is called when user clicked on N2O button
		//'this is used to Put N2O on or off as par cond
		//'step 1:first stop the thread 
		//'step 2:check N2O is on
		//'step 3:if yes then put N2O off else put N2O off
		//'step 4:do some onscreen validation as par cond


		if (mblnInProcess == true) {
			return;
		}
		CWaitCursor objWait = new CWaitCursor();

		try {
			mblnInProcess = true;
			mblnIgnitionWait = true;
			mobjclsBgManualIgnition.IgnitionWait = true;
			Application.DoEvents();
			gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay);
			//10.12.07
			Application.DoEvents();

			subSetN2OOnOff();

			//'this function is used for the  on or off the N2            
			gobjCommProtocol.mobjCommdll.subTime_Delay(500);
			//10.12.07
			mblnIgnitionWait = false;
			mobjclsBgManualIgnition.IgnitionWait = false;
			mblnInProcess = false;
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			mblnIgnitionWait = false;
			mobjclsBgManualIgnition.IgnitionWait = false;
			mblnInProcess = false;
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}

			if (!(objWait == null)) {
				objWait.Dispose();
				objWait = null;
			}
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	private void btnFuel_Click(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : btnFuel_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To make the FUEL Flow ON or OFF
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 29.11.06
		// Revisions             : 
		//=====================================================================
		//'note:
		//'this is called when user clicked on FUEL button
		//'this is used to Put FUEL on or off as par cond
		//'step 1:first stop the thread 
		//'step 2:check FUEL is on
		//'step 3:if yes then put FUEL off else put FUEL off
		//'step 4:do some onscreen validation as par cond

		if (mblnInProcess == true) {
			return;
		}
		CWaitCursor objWait = new CWaitCursor();

		try {
			//----------------
			//---02.08.09
			if (gstructSettings.AppMode == EnumAppMode.FullVersion_201) {
				if (mblnIsAir_Not_OK == true) {
					gobjMessageAdapter.ShowMessage(98);
					Application.DoEvents();
					mblnInProcess = false;
					return;
				}
			}
			//----------------

			//30.03.09
			if (mblnFuelPressure == true) {
				mblnInProcess = true;
				mblnIgnitionWait = true;
				mobjclsBgManualIgnition.IgnitionWait = true;
				Application.DoEvents();
				gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay);
				//10.12.07
				Application.DoEvents();

				subSetFuelOnOff();

				////--- Set the wait to  the manual flame ignit for AA201 03.10.08
				if (gstructSettings.AppMode == EnumAppMode.FullVersion_201) {
					//'If (Not (gobjInst.Aaf)) And (Not (gobjInst.N2of)) Then      '---commented on 30.03.09
					//'    gobjCommProtocol.mobjCommdll.subTime_Delay(5000)   '03.10.07
					//'End If

					//---added on 30.03.09
					if (mblnFlamePresent == false) {
						//gobjCommProtocol.mobjCommdll.subTime_Delay(5000)   '30.03.09
						//gobjCommProtocol.mobjCommdll.subTime_Delay(3000)   '30.03.09  vck suggested
						gobjCommProtocol.mobjCommdll.subTime_Delay(5000);
						//19.04.09  vck suggested
					}

				}
				////---
				mblnIgnitionWait = false;
				mblnInProcess = false;
				mobjclsBgManualIgnition.IgnitionWait = false;
			} else {
				gobjMessageAdapter.ShowMessage(constLowFuelPressureRetry);
				//30.03.09
			}

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			mblnIgnitionWait = false;
			mblnInProcess = false;
			mobjclsBgManualIgnition.IgnitionWait = false;
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			if (!(objWait == null)) {
				objWait.Dispose();
				objWait = null;
			}
			Application.DoEvents();
			//'alloew application to perfrom its panding work
			//---------------------------------------------------------
		}
	}

	private void btnIgnite_Click(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : btnIgnite_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To make the IGNITE ON or OFF
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 29.11.06
		// Revisions             : 
		//=====================================================================

		//'note:
		//'this is called when user clicked on IGNITE button
		//'this is used to Put IGNITE on or off as par cond
		//'step 1:first stop the thread 
		//'step 2:check IGNITE is on
		//'step 3:if yes then put IGNITE off else put IGNITE off
		//'step 4:do some onscreen validation as par cond

		if (mblnInProcess == true) {
			return;
		}
		CWaitCursor objWait = new CWaitCursor();

		try {
			mblnInProcess = true;
			mblnIgnitionWait = true;
			mblnInProcess = true;
			mobjclsBgManualIgnition.IgnitionWait = true;
			Application.DoEvents();
			gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay);
			//10.12.07
			Application.DoEvents();
			//mblnIsStopThreadAndExit = True
			//mobjThread.Sleep(100)
			//mobjThread.Join()
			//mobjThread.Abort()
			//If Not mobjThread.ThreadState = ThreadState.Suspended Then
			//    mobjThread.Suspend()
			//End If

			//mintManualIgnitionProcess = enumManualIgnitionProcess.SetIgniteOnOff
			subSetIgniteOnOff();
			//'function for setting ignition

			//'this function on or off by sending proper protocols 
			//Call Manual_Init_Check()

			//mblnIsStopThreadAndExit = False
			//mobjThread = New Threading.Thread(AddressOf subThreadStart)
			//mobjThread.IsBackground = True
			//mobjThread.Name = "Manual Ignition"
			//mobjThread.Start()
			//mobjThread.Resume()
			//Thread.Sleep(200)
			gobjCommProtocol.mobjCommdll.subTime_Delay(500);
			//10.12.07
			mblnIgnitionWait = false;
			mblnInProcess = false;
			mobjclsBgManualIgnition.IgnitionWait = false;
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			mblnIgnitionWait = false;
			mblnInProcess = false;
			mobjclsBgManualIgnition.IgnitionWait = false;
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			//mblnInProcess = False
			if (!(objWait == null)) {
				objWait.Dispose();
				objWait = null;
			}
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	private void btnDecreaseBurnerHeight_Click(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : btnDecreaseBurnerHeight_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To decrease the burner height.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 17.12.06
		// Revisions             : 
		//=====================================================================

		//'note :
		//'this is called when user click on DecreaseBurnerHeight
		//'this will decrease the burner height by sending a protocol


		if (mblnInProcess == true) {
			return;
		}
		CWaitCursor objWait = new CWaitCursor();

		try {
			mblnInProcess = true;

			//mblnIsStopThreadAndExit = True
			//mobjThread.Sleep(100)
			//mobjThread.Join()
			//mobjThread.Abort()
			//If Not mobjThread.ThreadState = ThreadState.Suspended Then
			//mobjThread.Suspend()
			//End If
			mblnIgnitionWait = true;
			mobjclsBgManualIgnition.IgnitionWait = true;
			Application.DoEvents();
			gobjCommProtocol.mobjCommdll.subTime_Delay(50);
			//10.12.07
			Application.DoEvents();
			//mintManualIgnitionProcess = enumManualIgnitionProcess.DecreaseBurnerHeight
			subDecreaseBurnerHeight();
			//'this will decerease the burner height 
			//Saurabh to set Bh step in the file "Bh.bhp" 11.07.07
			//Call gobjCommProtocol.funcSave_BH_Pos()
			//Saurabh

			//Call Manual_Init_Check()

			//mblnIsStopThreadAndExit = False
			//mobjThread = New Threading.Thread(AddressOf subThreadStart)
			//mobjThread.IsBackground = True
			//mobjThread.Name = "Manual Ignition"
			//mobjThread.Start()
			//If mobjThread.ThreadState = ThreadState.Suspended Then
			//    mobjThread.Resume()
			//End If
			//Thread.Sleep(200)
			Application.DoEvents();
			gobjCommProtocol.mobjCommdll.subTime_Delay(50);
			//10.12.07
			Application.DoEvents();
			mblnInProcess = false;
			mblnIgnitionWait = false;
			mobjclsBgManualIgnition.IgnitionWait = false;
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			mblnInProcess = false;
			mblnIgnitionWait = false;
			mobjclsBgManualIgnition.IgnitionWait = false;
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			if (!(objWait == null)) {
				objWait.Dispose();
				objWait = null;
			}
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	private void btnDecreaseFuel_Click(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : btnDecreaseFuel_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To Decrease the Fuel.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 17.12.06
		// Revisions             : 
		//=====================================================================
		//'note:
		//'this is called when user click on decreasefuel button
		//'before perfroming this ensure that thread should be stop

		if (mblnInProcess == true) {
			return;
		}
		CWaitCursor objWait = new CWaitCursor();

		try {
			mblnInProcess = true;
			mblnIgnitionWait = true;
			mobjclsBgManualIgnition.IgnitionWait = true;
			Application.DoEvents();
			gobjCommProtocol.mobjCommdll.subTime_Delay(50);
			//10.12.07
			Application.DoEvents();
			//'allowing thread to stop

			//mblnIsStopThreadAndExit = True
			//mobjThread.Sleep(100)
			//mobjThread.Join()
			//mobjThread.Abort()
			//If Not mobjThread.ThreadState = ThreadState.Suspended Then
			//mobjThread.Suspend()
			//End If
			//mintManualIgnitionProcess = enumManualIgnitionProcess.DecreaseFuel
			subDecreaseFuel();
			//'this will decerease the fuel

			//Call Manual_Init_Check()

			//mblnIsStopThreadAndExit = False
			//mobjThread = New Threading.Thread(AddressOf subThreadStart)
			//mobjThread.IsBackground = True
			//mobjThread.Name = "Manual Ignition"
			//mobjThread.Start()
			//mobjThread.Resume()
			//Thread.Sleep(200)
			Application.DoEvents();
			gobjCommProtocol.mobjCommdll.subTime_Delay(50);
			//10.12.07
			Application.DoEvents();
			mblnIgnitionWait = false;
			mblnInProcess = false;
			//'restart the thread
			mobjclsBgManualIgnition.IgnitionWait = false;
			Application.DoEvents();
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			mblnIgnitionWait = false;
			mblnInProcess = false;
			mobjclsBgManualIgnition.IgnitionWait = false;
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			if (!(objWait == null)) {
				objWait.Dispose();
				objWait = null;
			}
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	private void btnIncreaseBurnerHeight_Click(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : btnIncreaseBurnerHeight_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To increase the burner height.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 17.12.06
		// Revisions             : 
		//=====================================================================

		//'note:
		//'this is called when user click on increaseBurnerHeight button 
		if (mblnInProcess == true) {
			return;
		}
		CWaitCursor objWait = new CWaitCursor();

		try {
			mblnInProcess = true;
			mblnIgnitionWait = true;
			mobjclsBgManualIgnition.IgnitionWait = true;
			Application.DoEvents();
			gobjCommProtocol.mobjCommdll.subTime_Delay(50);
			//10.12.07
			Application.DoEvents();
			//'allow thread to stop

			//mblnIsStopThreadAndExit = True
			//mobjThread.Sleep(100)
			//mobjThread.Join()
			//mobjThread.Abort()
			//If Not mobjThread.ThreadState = ThreadState.Suspended Then
			//mobjThread.Suspend()
			//End If

			//mintManualIgnitionProcess = enumManualIgnitionProcess.IncreaseBurnerHeight
			subIncreaseBurnerHeight();
			//this will increase the burner height

			//Saurabh to set Bh step in the file "Bh.bhp" 11.07.07
			//Call gobjCommProtocol.funcSave_BH_Pos()
			//Saurabh

			//Call Manual_Init_Check()

			//mblnIsStopThreadAndExit = False
			//mobjThread = New Threading.Thread(AddressOf subThreadStart)
			//mobjThread.IsBackground = True
			//mobjThread.Name = "Manual Ignition"
			//mobjThread.Start()
			//If mobjThread.ThreadState = ThreadState.Suspended Then
			//    mobjThread.Resume()
			//End If
			//Thread.Sleep(200)
			Application.DoEvents();
			gobjCommProtocol.mobjCommdll.subTime_Delay(50);
			//10.12.07
			Application.DoEvents();
			mblnIgnitionWait = false;
			mblnInProcess = false;
			mobjclsBgManualIgnition.IgnitionWait = false;
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			mblnInProcess = false;
			mblnIgnitionWait = false;
			mobjclsBgManualIgnition.IgnitionWait = false;
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			if (!(objWait == null)) {
				objWait.Dispose();
				objWait = null;
			}
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	private void btnIncreaseFuel_Click(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : btnIncreaseFuel_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To Increase the Fuel.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 17.12.06
		// Revisions             : 
		//=====================================================================
		//'note:
		//'this is called when user click on increasefuel button
		if (mblnInProcess == true) {
			return;
		}
		CWaitCursor objWait = new CWaitCursor();
		try {
			mblnInProcess = true;
			mblnIgnitionWait = true;
			mobjclsBgManualIgnition.IgnitionWait = true;
			Application.DoEvents();
			gobjCommProtocol.mobjCommdll.subTime_Delay(50);
			//10.12.07
			Application.DoEvents();
			//'first stop the thread

			//mblnIsStopThreadAndExit = True
			//mobjThread.Sleep(100)
			//mobjThread.Join()
			//mobjThread.Abort()
			//If Not mobjThread.ThreadState = ThreadState.Suspended Then
			//    mobjThread.Suspend()
			//End If

			//mintManualIgnitionProcess = enumManualIgnitionProcess.IncreaseFuel

			subIncreaseFuel();
			//'this will increase the fuel
			//Call Manual_Init_Check()

			//mblnIsStopThreadAndExit = False
			//mobjThread = New Threading.Thread(AddressOf subThreadStart)
			//mobjThread.IsBackground = True
			//mobjThread.Name = "Manual Ignition"
			//mobjThread.Start()
			//mobjThread.Resume()
			//Thread.Sleep(200)
			Application.DoEvents();
			gobjCommProtocol.mobjCommdll.subTime_Delay(50);
			//10.12.07
			Application.DoEvents();
			mblnIgnitionWait = false;
			mblnInProcess = false;
			mobjclsBgManualIgnition.IgnitionWait = false;
		//'restart the thread
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			//---------------------------------------------------------
			mblnIgnitionWait = false;
			mblnInProcess = false;
			mobjclsBgManualIgnition.IgnitionWait = false;
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			if (!(objWait == null)) {
				objWait.Dispose();
				objWait = null;
			}
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	private void btnSetMaxBurnerHeight_Click(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : btnSetMaxBurnerHeight_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To set the MAX burner height.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 25.01.07
		// Revisions             : 
		//=====================================================================
		//'note:
		//'this is called when user click on set max burner height

		if (mblnInProcess == true) {
			return;
		}
		CWaitCursor objWait = new CWaitCursor();
		try {
			mblnInProcess = true;
			mblnIgnitionWait = true;
			mobjclsBgManualIgnition.IgnitionWait = true;
			Application.DoEvents();
			gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay);
			//10.12.07
			Application.DoEvents();
			//'stop the thread

			//mblnIsStopThreadAndExit = True
			//mobjThread.Sleep(100)
			//mobjThread.Join()
			//mobjThread.Abort()
			//If Not mobjThread.ThreadState = ThreadState.Suspended Then
			//    mobjThread.Suspend()
			//End If

			//mintManualIgnitionProcess = enumManualIgnitionProcess.SetMaxBurnerHeight
			subSetMaxBurnerHeight();
			//'this function will set the burner to its max height

			//Call Manual_Init_Check()

			//mblnIsStopThreadAndExit = False
			//mobjThread = New Threading.Thread(AddressOf subThreadStart)
			//mobjThread.IsBackground = True
			//mobjThread.Name = "Manual Ignition"
			//mobjThread.Start()
			//mobjThread.Resume()
			//Thread.Sleep(200)
			Application.DoEvents();
			gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay);
			//10.12.07
			Application.DoEvents();
			mblnIgnitionWait = false;
			mblnInProcess = false;
			mobjclsBgManualIgnition.IgnitionWait = false;
		//'restart the thread

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			//---------------------------------------------------------
			mblnIgnitionWait = false;
			mblnInProcess = false;
			mobjclsBgManualIgnition.IgnitionWait = false;
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			//mblnInProcess = False
			if (!(objWait == null)) {
				objWait.Dispose();
				objWait = null;
			}
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	private void btnSetMaxFuel_Click(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : btnSetMaxFuel_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To set the MAX fuel.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 25.01.07
		// Revisions             : 
		//=====================================================================
		//'note:
		//'this is called when user click on maxfuel button


		if (mblnInProcess == true) {
			return;
		}
		CWaitCursor objWait = new CWaitCursor();
		try {
			mblnInProcess = true;
			mblnIgnitionWait = true;
			mobjclsBgManualIgnition.IgnitionWait = true;
			Application.DoEvents();
			gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay);
			//10.12.07
			Application.DoEvents();
			//'stop the thread first

			//mblnIsStopThreadAndExit = True
			//mobjThread.Sleep(100)
			//mobjThread.Join()
			//mobjThread.Abort()
			//If Not mobjThread.ThreadState = ThreadState.Suspended Then
			//    mobjThread.Suspend()
			//End If

			//mintManualIgnitionProcess = enumManualIgnitionProcess.SetMaxFuel
			subSetMaxFuel();
			//'

			//'this will set the max fuel

			//Call Manual_Init_Check()

			//mblnIsStopThreadAndExit = False
			//mobjThread = New Threading.Thread(AddressOf subThreadStart)
			//mobjThread.IsBackground = True
			//mobjThread.Name = "Manual Ignition"
			//mobjThread.Start()
			//mobjThread.Resume()
			//Thread.Sleep(200)
			Application.DoEvents();
			gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay);
			//10.12.07
			Application.DoEvents();
			mblnIgnitionWait = false;
			mblnInProcess = false;
			mobjclsBgManualIgnition.IgnitionWait = false;
		//'restart the thread

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			//---------------------------------------------------------
			mblnIgnitionWait = false;
			mblnInProcess = false;
			mobjclsBgManualIgnition.IgnitionWait = false;
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			if (!(objWait == null)) {
				objWait.Dispose();
				objWait = null;
			}
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	//Private Sub btnALT_I_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnALT_I.Click
	//    '=====================================================================
	//    ' Procedure Name        : btnALT_I_Click
	//    ' Parameters Passed     : Object, EventArgs
	//    ' Returns               : 
	//    ' Purpose               : To make the necessary adjustments and auto 
	//    '                       : ignite the flame.
	//    ' Description           : 
	//    ' Assumptions           : 
	//    ' Dependencies          : 
	//    ' Author                : Saurabh S
	//    ' Created               : 07-02-2007
	//    ' Revisions             : 
	//    '=====================================================================
	//    Try
	//        mblnIsStopThreadAndExit = True
	//        mobjThread.Sleep(100)
	//        mobjThread.Join()
	//        mobjThread.Abort()

	//        mintManualIgnitionProcess = enumManualIgnitionProcess.AutoIgnition

	//        Call subAutoIgnition()

	//        mblnIsStopThreadAndExit = False
	//        mobjThread = New Threading.Thread(AddressOf subThreadStart)
	//        mobjThread.IsBackground = True
	//        mobjThread.Name = "Manual Ignition"
	//        mobjThread.Start()
	//        Thread.Sleep(500)

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
	//        '---------------------------------------------------------
	//    End Try
	//End Sub

	//Private Sub cmdBarBtnIgnite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
	//    Try
	//        cmdBarBtnIgnite.SuspendEvents()

	//        'mblnIsStopThreadAndExit = True
	//        mobjThread.Sleep(100)
	//        'mobjThread.Join()
	//        'mobjThread.Abort()
	//        mobjThread.Suspend()

	//        'mintManualIgnitionProcess = enumManualIgnitionProcess.AutoIgnition

	//        Call subAutoIgnition()

	//        'mblnIsStopThreadAndExit = False
	//        'mintManualIgnitionProcess = enumManualIgnitionProcess.ManualIgnitionCheck
	//        'mobjThread = New Threading.Thread(AddressOf subThreadStart)
	//        'mobjThread.IsBackground = True
	//        'mobjThread.Name = "Manual Ignition"
	//        'mobjThread.Start()
	//        mobjThread.Resume()
	//        Thread.Sleep(500)

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
	//        cmdBarBtnIgnite.ResumeEvents()
	//        '---------------------------------------------------------
	//    End Try
	//End Sub

	//Private Sub cmdBarBtnExtinguish_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
	//    '=====================================================================
	//    ' Procedure Name        : btnALT_I_Click
	//    ' Parameters Passed     : Object, EventArgs
	//    ' Returns               : 
	//    ' Purpose               : To make the necessary adjustments and auto 
	//    '                       : ignite the flame.
	//    ' Description           : 
	//    ' Assumptions           : 
	//    ' Dependencies          : 
	//    ' Author                : Saurabh S
	//    ' Created               : 07-02-2007
	//    ' Revisions             : 
	//    '=====================================================================
	//    Try
	//        cmdBarBtnExtinguish.SuspendEvents()
	//        mblnIsStopThreadAndExit = True
	//        mobjThread.Sleep(100)
	//        'mobjThread.Join()
	//        'mobjThread.Abort()
	//        mobjThread.Suspend()

	//        'mintManualIgnitionProcess = enumManualIgnitionProcess.AutoExtinguish

	//        Call subAutoExtinguish()

	//        'mblnIsStopThreadAndExit = False
	//        'mintManualIgnitionProcess = enumManualIgnitionProcess.ManualIgnitionCheck
	//        'mobjThread = New Threading.Thread(AddressOf subThreadStart)
	//        'mobjThread.IsBackground = True
	//        'mobjThread.Name = "Manual Ignition"
	//        'mobjThread.Start()
	//        mobjThread.Resume()
	//        Thread.Sleep(500)

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
	//        cmdBarBtnExtinguish.ResumeEvents()
	//        '---------------------------------------------------------
	//    End Try
	//End Sub

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
		// Created               : 27.11.06
		// Revisions             : 
		//=====================================================================
		try {
			//'this function is used for adding a event to a control
			//'for eg btnClose_Click is called when user click on close button 
			btnClose.Click += btnClose_Click;

			btnN2O.Click += btnN2O_Click;
			btnFuel.Click += btnFuel_Click;
			btnIgnite.Click += btnIgnite_Click;
			btnN2OIgnite.Click += btnN2OIgnite_Click;
			btnAirOnOff.Click += btnAirOnOff_Click;
			btnSetMaxFuel.Click += btnSetMaxFuel_Click;
			btnDecreaseFuel.Click += btnDecreaseFuel_Click;
			btnIncreaseFuel.Click += btnIncreaseFuel_Click;
			btnSetMaxBurnerHeight.Click += btnSetMaxBurnerHeight_Click;
			btnDecreaseBurnerHeight.Click += btnDecreaseBurnerHeight_Click;
			btnIncreaseBurnerHeight.Click += btnIncreaseBurnerHeight_Click;
			btnDelete.Click += btnDelete_Click;
			btnR.Click += btnR_Click;
			btnExtinguish.Click += btnExtinguish_Click;
			btnAutoIgnite.Click += btnAutoIgnite_Click;
			btnN2OIgnite.Click += btnN2OIgnite_Click;


		//AddHandler cmdBarBtnIgnite.Click, AddressOf cmdBarBtnIgnite_Click
		//AddHandler cmdBarBtnExtinguish.Click, AddressOf cmdBarBtnExtinguish_Click



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

	private void funcInitialise()
	{
		//=====================================================================
		// Procedure Name        : frmManualIgnition_Load
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To initialize the form
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 27.11.06
		// Revisions             : 
		//=====================================================================
		bool blnFlag = true;
		byte bData;

		//void	Manual_Init_Check(HDC hdc)
		//{
		//BYTE data;
		//  if (!Commflag)
		//	 return;
		//	Status_Disp();
		//	aa = ps1 = ps2 = ps3 = ON;
		//	data  = CHECK_PS();
		//	if (data & AIR_NOK) ps1 = OFF;
		//	if (data & N2O_NOK) ps2 = OFF;
		//	if (data & FUEL_NOK) ps3 = OFF;
		//	data = CHECK_BUR_PAR();
		//	if (data & AA_CONNECTED) aa = ON;
		//	if (!ps1)  {
		//	  Wprintf(hdc, 20, 0, " No AIR Pressure  ");
		//	  if (! ( air))  air = AIR_ON();
		//	 }
		//	if (!ps2) {
		//	  Wprintf(hdc, 20, 15, " No N�O Pressure  ");
		//	  if( n2)  n2 = N2O_OFF();
		//	 }
		//	if (!ps3) {
		//	  Wprintf(hdc, 20, 30," No FUEL Pressure  ");
		//	  if ( fuel)  fuel = FUEL_OFF();
		//	 }
		//	if (aa) Wprintf(hdc, 20, 45 ," AA  Burner  attached ");
		//	else Wprintf(hdc, 20, 45 ," N2o Burner attached ");
		//}

		//'note:
		//'this function is called during the loading of a form
		//'in this we perfrom some initial setup like text name
		//'image etc.


		try {
			gobjCommProtocol.funcCheckBurnerParameters(bData);
			//'this function is for To check Burner parameters
			//'here we have to passed byte arry
			//'which will return byte holding data.



			//===commented on 24.04.09
			//'If (bData And EnumErrorStatus.AA_CONNECTED) Then
			//'    lblBurnerStatus.Text = "AA"
			//'    pbBurnerType.Image = Image.FromFile(Application.StartupPath & "\" & "images\BTAA.bmp")
			//'Else
			//'    lblBurnerStatus.Text = "NA"
			//'    pbBurnerType.Image = Image.FromFile(Application.StartupPath & "\" & "images\BTNA.bmp")
			//'End If
			//===commented on 24.04.09

			//===written on 24.04.09
			if (gblnBurnerMsg == false) {
				if ((bData & EnumErrorStatus.AA_CONNECTED)) {
					lblBurnerStatus.Text = "AA";
					pbBurnerType.Image = Image.FromFile(Application.StartupPath + "\\" + "images\\BTAA.bmp");
				} else {
					lblBurnerStatus.Text = "NA";
					pbBurnerType.Image = Image.FromFile(Application.StartupPath + "\\" + "images\\BTNA.bmp");
				}
			} else {
				lblBurnerStatus.Text = "NONE";
				pbBurnerType.Image = Image.FromFile(Application.StartupPath + "\\" + "images\\ERROR.BMP");
			}
			//===written on 24.04.09


			// If gobjCommProtocol.funcPressSensorStatus(bData) Then
			if ((bData & EnumErrorStatus.AIR_NOK)) {
				blnPressureSensor1 = true;
			} else {
				blnPressureSensor1 = false;
			}

			if ((bData & EnumErrorStatus.N2O_NOK)) {
				blnPressureSensor2 = true;
			} else {
				blnPressureSensor2 = false;
			}

			if ((bData & EnumErrorStatus.FUEL_NOK)) {
				blnPressureSensor3 = true;
			} else {
				blnPressureSensor3 = false;
			}

			if (blnPressureSensor1 == false) {
				lblAir.Text = "NO";
				pbPressureAir.Image = Image.FromFile(Application.StartupPath + "\\" + "images\\ERROR.BMP");
			} else {
				lblAir.Text = "YES";
				pbPressureAir.Image = Image.FromFile(Application.StartupPath + "\\" + "images\\OK.BMP");
			}

			if (blnBurner == false & blnPressureSensor2 == false) {
				lblN2O.Text = "NO";
				pbPressureN2O.Image = Image.FromFile(Application.StartupPath + "\\" + "images\\ERROR.BMP");
				mblnN2OPresure = false;
			} else {
				lblN2O.Text = "YES";
				pbPressureN2O.Image = Image.FromFile(Application.StartupPath + "\\" + "images\\OK.BMP");
				mblnN2OPresure = true;
			}

			if (blnPressureSensor3 == false) {
				lblFuel.Text = "NO";
				pbPressureFuel.Image = Image.FromFile(Application.StartupPath + "\\" + "images\\ERROR.BMP");
			} else {
				lblFuel.Text = "YES";
				pbPressureFuel.Image = Image.FromFile(Application.StartupPath + "\\" + "images\\OK.BMP");
			}


		// End If

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

	private bool Manual_Init_Check()
	{
		//=====================================================================
		// Procedure Name        : Manual_Init_Check
		// Parameters Passed     : None
		// Returns               : True if success
		// Purpose               : To set the parameters on form load.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 02.02.07
		// Revisions             : 
		//=====================================================================
		//void	Manual_Init_Check(HDC hdc)
		//{
		//BYTE data;
		//  if (!Commflag)
		//	 return;
		//	Status_Disp();
		//	aa = ps1 = ps2 = ps3 = ON;
		//	data  = CHECK_PS();
		//	if (data & AIR_NOK) ps1 = OFF;
		//	if (data & N2O_NOK) ps2 = OFF;
		//	if (data & FUEL_NOK) ps3 = OFF;
		//	data = CHECK_BUR_PAR();
		//	if (data & AA_CONNECTED) aa = ON;
		//	if (!ps1)  {
		//	  Wprintf(hdc, 20, 0, " No AIR Pressure  ");
		//	  if (! ( air))  air = AIR_ON();
		//	 }
		//	if (!ps2) {
		//	  Wprintf(hdc, 20, 15, " No N�O Pressure  ");
		//	  if( n2)  n2 = N2O_OFF();
		//	 }
		//	if (!ps3) {
		//	  Wprintf(hdc, 20, 30," No FUEL Pressure  ");
		//	  if ( fuel)  fuel = FUEL_OFF();
		//	 }
		//	if (aa) Wprintf(hdc, 20, 45 ," AA  Burner  attached ");
		//	else Wprintf(hdc, 20, 45 ," N2o Burner attached ");
		//}

		byte BData;

		try {
			this.custpnlStatusDisplay.Height = 120;
			this.Height = 320;

			if (Status_Disp() == false) {
				//'To set the parameters on form load.
				return;
			}

			aa = true;
			// To check for AA burner parameter status
			ps1 = true;
			// To check for Air pressure 
			ps2 = true;
			// To check for N2O pressure 
			ps3 = true;
			// To check for Fuel pressure 

			gobjCommProtocol.mobjCommdll.subTime_Delay(100);
			//'for delay
			if (mblnIgnitionWait == false) {
				//'set flag for stop thread
				//Retrive Pressure sensor status from Instrument
				if (gobjCommProtocol.funcPressSensorStatus(BData, false) == false) {
					//'To check pressure sensors for AIR, N2O, Fuel etc.
					return;
				}
			} else {
				return;
			}

			if ((BData & EnumErrorStatus.AIR_NOK)) {
				ps1 = false;
			}
			if ((BData & EnumErrorStatus.N2O_NOK)) {
				ps2 = false;
			}
			if ((BData & EnumErrorStatus.FUEL_NOK)) {
				ps3 = false;
			}
			gobjCommProtocol.mobjCommdll.subTime_Delay(20);
			//'delay
			if (mblnIgnitionWait == false) {
				if (gobjCommProtocol.funcCheckBurnerParameters(BData) == false) {
					//'To check Burner parameters 
					return;
				}
			} else {
				return;
			}

			if ((BData & EnumErrorStatus.AA_CONNECTED)) {
				aa = true;
			} else {
				aa = false;
			}
			//--- To check air pressure status
			if (!ps1) {
				lblAirPressure.Visible = true;
				lblAir.Visible = true;
				lblAir.Text = "NO";
				if (!air) {
					gobjCommProtocol.mobjCommdll.subTime_Delay(20);
					//'delay

					if (mblnIgnitionWait == false) {
						//---Commented on 30.03.09
						//air = gobjCommProtocol.funcAir_ON()  
						//--------

						//---Written on 30.03.09
						if (gobjCommProtocol.funcAir_ON() == true) {
							air = true;
						}
					//--------------

					//'To set AIR on
					} else {
						return;
					}
				}
			//Else part added by Saurabh-----22.06.07
			} else {
				lblAirPressure.Visible = false;
				lblAir.Visible = false;
				//lblAir.Text = "Yes"
			}

			//--- To check N2O status
			if (!ps2) {
				lblN2OPressure.Visible = true;
				lblN2O.Visible = true;
				lblN2O.Text = "NO";
				// hold the staus of N2O flame ignition
				if (n2) {
					gobjCommProtocol.mobjCommdll.subTime_Delay(20);
					//'delay
					if (mblnIgnitionWait == false) {
						//---Commented on 30.03.09
						//n2 = gobjCommProtocol.func_N2O_OFF()    
						//------------

						//---Written on 30.03.09
						if (gobjCommProtocol.func_N2O_OFF() == true) {
							n2 = false;
						}
					//------------

					//'serial communication function for setting N2O off
					} else {
						return;
					}
					n2 = false;
				}
			}
			//--- To check Fuel status
			if (!ps3) {
				lblFuelPressure.Visible = true;
				lblFuel.Visible = true;
				lblFuel.Text = "NO";
				if (fuel) {
					//'delay
					if (mblnIgnitionWait == false) {
						gobjCommProtocol.mobjCommdll.subTime_Delay(20);
						//'serial communication for setting FUEL off
						if (gobjCommProtocol.func_FUEL_OFF() == true) {
						}
					} else {
						return;
					}
					fuel = false;
				}
			}

			//===commented on 24.04.09
			//--- To check Burner parameter status
			//'If aa Then
			//'    lblBurnerAttached.Visible = True
			//'    lblBurnerStatus.Text = "AA"
			//'    lblBurnerStatus.Visible = True
			//'Else
			//'    lblBurnerAttached.Visible = True
			//'    lblBurnerStatus.Text = "NA"
			//'    lblBurnerStatus.Visible = True
			//'End If
			//===commented on 24.04.09

			//===written on 24.04.09
			if (gblnBurnerMsg == false) {
				if (aa) {
					lblBurnerAttached.Visible = true;
					lblBurnerStatus.Text = "AA";
					lblBurnerStatus.Visible = true;
				} else {
					lblBurnerAttached.Visible = true;
					lblBurnerStatus.Text = "NA";
					lblBurnerStatus.Visible = true;
				}
			} else {
				lblBurnerAttached.Visible = true;
				lblBurnerStatus.Text = "NONE";
				lblBurnerStatus.Visible = true;
			}
			//===written on 24.04.09

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
			Application.DoEvents();
		}
	}

	private bool Status_Disp()
	{
		//=====================================================================
		// Procedure Name        : Status_Disp
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To set the parameters on form load.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 02.02.07
		// Revisions             : 
		//=====================================================================
		string line1;
		byte status;
		byte st;
		byte st1;
		bool flag = true;
		int intFlameStatus;
		int intflag = 0;
		try {
			gobjCommProtocol.mobjCommdll.subTime_Delay(20);
			//'delay
			if (mblnIgnitionWait == false) {
				status = gobjCommProtocol.funcGet_Pneum_Status();
			//'check the status of pneumentic setting
			} else {
				return;
			}
			gobjCommProtocol.mobjCommdll.subTime_Delay(20);
			//'delay

			if (gstructSettings.AppMode == EnumAppMode.FullVersion_203 | gstructSettings.AppMode == EnumAppMode.FullVersion_203D) {
				//---Added by deepak on 29.12.08
				gobjClsAAS203.funcCheck_Flame();
				//------------
			}


			if (mblnIgnitionWait == false) {
				gobjCommProtocol.funcPressSensorStatus(st, false);
			//'check the pressure sensor status
			} else {
				return;
			}
			gobjCommProtocol.mobjCommdll.subTime_Delay(20);
			if (mblnIgnitionWait == false) {
				if (gobjCommProtocol.funcCheckBurnerParameters(st1) == false) {
					//'cheack for a burner parameter status
					return;
				}
			} else {
				return;
			}

			//---Burner Head Confirmation    'added on 30.03.09
			//---------------------------------------------------------
			if (gstructSettings.AppMode == EnumAppMode.FullVersion_201) {
				//---changed for ver 6.89
				if (gstructSettings.NewModelName == true) {
					if ((st1 & EnumErrorStatus.BurnerHead_Present)) {
						btnFuel.Enabled = true;
						//btnN2O.Enabled = True
						//---condition added as it is required by vck for testing 07.05.09
						if (gstructSettings.ExeToRun == EnumApplicationMode.ServiceUtility) {
							btnN2O.Enabled = true;
						} else {
							//---added on 26.04.09 for ver 4.87
							if (mblnFlamePresent == true) {
								btnN2O.Enabled = true;
							} else {
								btnN2O.Enabled = false;
							}
						}
						//---------------

						gblnBurnerMsg = false;
					} else {
						btnFuel.Enabled = false;
						btnN2O.Enabled = false;
						gobjCommProtocol.func_N2O_OFF();
						gobjCommProtocol.func_FUEL_OFF();
						if (gblnBurnerMsg == false) {
							//Call gobjMessageAdapter.ShowMessage("Burner Head/Tether not present", "Warning", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage)
							gobjMessageAdapter.ShowMessage(constBurnerHeadMsg);
							gblnBurnerMsg = true;
						}
					}
				}
			}
			//---------------------------------------------------------

			if ((st & EnumErrorStatus.AIR_NOK)) {
				flag = false;
				mblnIsAir_Not_OK = true;
				// code commented by: dinesh wagh on 20.3.2009
				//'......
				//'pbPressureAir.Image = Image.FromFile(Application.StartupPath & "\" & "images\ERROR.BMP")
				//'If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
				//'    'btnFuel.Visible = False         'Saruabh----22.06.07
				//'End If
				//'.........

				// code added by : dinesh wagh on 20.3.2009
				// code start
				if (gstructSettings.AppMode == EnumAppMode.FullVersion_201 | gstructSettings.AppMode == EnumAppMode.DemoMode_201) {
					pbPressureAir1.Image = Image.FromFile(Application.StartupPath + "\\" + "images\\ERROR.BMP");
				} else {
					pbPressureAir.Image = Image.FromFile(Application.StartupPath + "\\" + "images\\ERROR.BMP");
				}
			// code ends

			} else {
				mblnIsAir_Not_OK = false;


				// code commented by : dinesh wagh on 20.3.2009
				///pbPressureAir.Image = Image.FromFile(Application.StartupPath & "\" & "images\OK.BMP")
				///If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
				///    btnFuel.Visible = True          'Saruabh----22.06.07
				///End If
				//........

				// code added by : dinesh wagh on 20.3.2009
				//... code start


				if (gstructSettings.AppMode == EnumAppMode.FullVersion_201 | gstructSettings.AppMode == EnumAppMode.DemoMode_201) {
					pbPressureAir1.Image = Image.FromFile(Application.StartupPath + "\\" + "images\\OK.BMP");
					btnFuel.Visible = true;
				} else {
					pbPressureAir.Image = Image.FromFile(Application.StartupPath + "\\" + "images\\OK.BMP");
				}
				//.... code ends
			}

			if ((st & EnumErrorStatus.N2O_NOK)) {
				flag = false;

				// code commented by: dinesh wagh on 20.3.2009
				//'pbPressureN2O.Image = Image.FromFile(Application.StartupPath & "\" & "images\ERROR.BMP")
				//'If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
				//'    btnN2O.Visible = False         'Saruabh----22.06.07
				//'

				// code added by: dinesh wagh on 20.3.2009

				if (gstructSettings.AppMode == EnumAppMode.FullVersion_201 | gstructSettings.AppMode == EnumAppMode.DemoMode_201) {
					//---21.09.09
					if (gstructSettings.ExeToRun == EnumApplicationMode.AAS) {
						btnN2O.Visible = false;
					}
					pbPressureN2O1.Image = Image.FromFile(Application.StartupPath + "\\" + "images\\ERROR.BMP");
					// code added by : dinesh wagh on 20.3.2009
				} else {
					pbPressureN2O.Image = Image.FromFile(Application.StartupPath + "\\" + "images\\ERROR.BMP");
				}
			} else {
				// code commented by : dinesh wagh on 20.3.2009
				// comment start
				//'pbPressureN2O.Image = Image.FromFile(Application.StartupPath & "\" & "images\OK.BMP")
				//'If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
				//'    'btnN2O.Visible = True         'Saruabh----22.06.07
				//'    If (st1 And EnumErrorStatus.AA_CONNECTED) Then
				//'        btnN2O.Visible = False         'Saruabh----22.06.07
				//'    Else
				//'        btnN2O.Visible = True         'Saruabh----22.06.07
				//'    End If

				//'End If
				// comment end


				// code added by: dinesh wagh on 20.3.2009
				//code start

				if (gstructSettings.AppMode == EnumAppMode.FullVersion_201 | gstructSettings.AppMode == EnumAppMode.DemoMode_201) {
					pbPressureN2O1.Image = Image.FromFile(Application.StartupPath + "\\" + "images\\OK.BMP");
					if ((st1 & EnumErrorStatus.AA_CONNECTED)) {
						//---21.09.09
						if (gstructSettings.ExeToRun == EnumApplicationMode.AAS) {
							btnN2O.Visible = false;
						}
					} else {
						btnN2O.Visible = true;

						//---condition added as it is required by vck for testing 07.05.09
						if (gstructSettings.ExeToRun == EnumApplicationMode.ServiceUtility) {
							btnN2O.Enabled = true;
						} else {
							//---added on 26.04.09 for ver 4.87
							if (mblnFlamePresent == true) {
								btnN2O.Enabled = true;
							} else {
								btnN2O.Enabled = false;
							}
							//---------------
						}


					}
				} else {
					pbPressureN2O.Image = Image.FromFile(Application.StartupPath + "\\" + "images\\OK.BMP");
				}
				//code ends

			}

			pbPressureN2O.Refresh();
			pbPressureN2O1.Refresh();
			//20.3.2009 by dinesh

			if ((st & EnumErrorStatus.FUEL_NOK)) {
				mblnFuelPressure = false;
				//---added on 30.03.09
				flag = false;
				//pbPressureFuel.Image = Image.FromFile(Application.StartupPath & "\" & "images\ERROR.BMP") 'by dinesh on 20.3.2009


				//added by: dinesh wagh on 20.3.2009
				if (gstructSettings.AppMode == EnumAppMode.FullVersion_201 | gstructSettings.AppMode == EnumAppMode.DemoMode_201) {
					pbPressureFuel1.Image = Image.FromFile(Application.StartupPath + "\\" + "images\\ERROR.BMP");
				} else {
					pbPressureFuel.Image = Image.FromFile(Application.StartupPath + "\\" + "images\\ERROR.BMP");
				}


			} else {
				mblnFuelPressure = true;
				//---added on 30.03.09
				//pbPressureFuel.Image = Image.FromFile(Application.StartupPath & "\" & "images\OK.BMP") 'by dinesh wagh on 20.3.2009

				//added by: dinesh wagh on 20.3.2009
				if (gstructSettings.AppMode == EnumAppMode.FullVersion_201 | gstructSettings.AppMode == EnumAppMode.DemoMode_201) {
					pbPressureFuel1.Image = Image.FromFile(Application.StartupPath + "\\" + "images\\OK.BMP");
				} else {
					pbPressureFuel.Image = Image.FromFile(Application.StartupPath + "\\" + "images\\OK.BMP");
				}



			}
			pbPressureFuel.Refresh();
			pbPressureFuel1.Refresh();
			//by dinesh wagh on 20.3.2009



			if ((status & EnumErrorStatus.SAIR_NON)) {
				flag = false;
				air = false;
				btnAirOnOff.Text = "AIR ON";

				//pbStatusAir.Image = Image.FromFile(Application.StartupPath & "\" & "images\close.BMP")' by dinesh wagh on 20.3.2009


				// code added by : dinesh wagh on 20.3.2009
				if (gstructSettings.AppMode == EnumAppMode.FullVersion_201 | gstructSettings.AppMode == EnumAppMode.DemoMode_201) {
					pbStatusAir1.Image = Image.FromFile(Application.StartupPath + "\\" + "images\\close.BMP");
				} else {
					pbStatusAir.Image = Image.FromFile(Application.StartupPath + "\\" + "images\\close.BMP");
				}

			} else {
				air = true;

				btnAirOnOff.Text = "AIR OFF";

				//pbStatusAir.Image = Image.FromFile(Application.StartupPath & "\" & "images\open.BMP") ' by dinesh wagh on 20.3.2009

				//added by: dinesh wagh on 20.3.209
				if (gstructSettings.AppMode == EnumAppMode.FullVersion_201 | gstructSettings.AppMode == EnumAppMode.DemoMode_201) {
					pbStatusAir1.Image = Image.FromFile(Application.StartupPath + "\\" + "images\\open.BMP");
				} else {
					pbStatusAir.Image = Image.FromFile(Application.StartupPath + "\\" + "images\\open.BMP");
				}

			}

			//'If (status And EnumErrorStatus.SN2O_NON) Then    '---25.06.09 commented for version 4.91
			//'    btnN2O.Text = "N2O ON"
			//'    ' code added by: dinesh wagh on 20.3.2009
			//'    If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Or _
			//'        gstructSettings.AppMode = EnumAppMode.DemoMode_201 Then
			//'        pbStatusN2O1.Image = Image.FromFile(Application.StartupPath & "\" & "images\open.BMP")
			//'    Else
			//'        pbStatusN2O.Image = Image.FromFile(Application.StartupPath & "\" & "images\open.BMP")
			//'    End If
			//'Else
			//'    flag = False
			//'    btnN2O.Text = "N2O OFF"
			//'    ' code added by : dinesh wagh on 20.3.2009
			//'    If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Or _
			//'        gstructSettings.AppMode = EnumAppMode.DemoMode_201 Then

			//'        pbStatusN2O1.Image = Image.FromFile(Application.StartupPath & "\" & "images\close.BMP")
			//'    Else
			//'        pbStatusN2O.Image = Image.FromFile(Application.StartupPath & "\" & "images\close.BMP")
			//'    End If
			//'End If

			//---25.06.09  added for version 4.91
			if (gstructSettings.AppMode == EnumAppMode.FullVersion_201) {
				if ((status & EnumErrorStatus.SN2O_NON)) {
					btnN2O.Text = "N2O ON";
					// code added by: dinesh wagh on 20.3.2009
					if (gstructSettings.AppMode == EnumAppMode.FullVersion_201 | gstructSettings.AppMode == EnumAppMode.DemoMode_201) {
						pbStatusN2O1.Image = Image.FromFile(Application.StartupPath + "\\" + "images\\open.BMP");
					} else {
						pbStatusN2O.Image = Image.FromFile(Application.StartupPath + "\\" + "images\\open.BMP");
					}
				} else {
					flag = false;
					btnN2O.Text = "N2O OFF";
					// code added by : dinesh wagh on 20.3.2009

					if (gstructSettings.AppMode == EnumAppMode.FullVersion_201 | gstructSettings.AppMode == EnumAppMode.DemoMode_201) {
						pbStatusN2O1.Image = Image.FromFile(Application.StartupPath + "\\" + "images\\close.BMP");
					} else {
						pbStatusN2O.Image = Image.FromFile(Application.StartupPath + "\\" + "images\\close.BMP");
					}
				}
			} else {
				if ((status & EnumErrorStatus.SN2O_NON)) {
					btnN2O.Text = "N2O OFF";
					// code added by: dinesh wagh on 20.3.2009
					if (gstructSettings.AppMode == EnumAppMode.FullVersion_201 | gstructSettings.AppMode == EnumAppMode.DemoMode_201) {
						pbStatusN2O1.Image = Image.FromFile(Application.StartupPath + "\\" + "images\\open.BMP");
					} else {
						pbStatusN2O.Image = Image.FromFile(Application.StartupPath + "\\" + "images\\open.BMP");
					}
				} else {
					flag = false;
					btnN2O.Text = "N2O ON";
					// code added by : dinesh wagh on 20.3.2009

					if (gstructSettings.AppMode == EnumAppMode.FullVersion_201 | gstructSettings.AppMode == EnumAppMode.DemoMode_201) {
						pbStatusN2O1.Image = Image.FromFile(Application.StartupPath + "\\" + "images\\close.BMP");
					} else {
						pbStatusN2O.Image = Image.FromFile(Application.StartupPath + "\\" + "images\\close.BMP");
					}
				}
			}

			btnN2O.Refresh();
			pbStatusN2O.Refresh();
			pbStatusN2O1.Refresh();
			//dinesh wagh on 20.3.2009


			if ((status & EnumErrorStatus.SFUEL_ON)) {
				btnFuel.Text = "FUEL OFF";

				//pbStatusFuel.Image = Image.FromFile(Application.StartupPath & "\" & "images\open.BMP") by dinesh wagh on 20.3.2009

				// code added by: dinesh wagh on 20.3.2009
				if (gstructSettings.AppMode == EnumAppMode.FullVersion_201 | gstructSettings.AppMode == EnumAppMode.DemoMode_201) {
					pbStatusFuel1.Image = Image.FromFile(Application.StartupPath + "\\" + "images\\open.BMP");
				} else {
					pbStatusFuel.Image = Image.FromFile(Application.StartupPath + "\\" + "images\\open.BMP");
				}

			} else {
				flag = false;

				btnFuel.Text = "FUEL ON";

				//pbStatusFuel.Image = Image.FromFile(Application.StartupPath & "\" & "images\close.BMP") 'by dinesh wagh on 20.3.2009

				// code added by: dinesh wagh on 20.3.2009
				if (gstructSettings.AppMode == EnumAppMode.FullVersion_201 | gstructSettings.AppMode == EnumAppMode.DemoMode_201) {
					pbStatusFuel1.Image = Image.FromFile(Application.StartupPath + "\\" + "images\\close.BMP");
				} else {
					pbStatusFuel.Image = Image.FromFile(Application.StartupPath + "\\" + "images\\close.BMP");
				}

			}
			btnFuel.Refresh();
			pbStatusFuel.Refresh();

			pbStatusFuel1.Refresh();
			//by dinesh wagh on 20.3.2009


			//====commented on 24.04.09
			///If (st1 And EnumErrorStatus.AA_CONNECTED) Then
			///    mblnIsN2OBurnerPresent = False   '---added on 30.03.09
			///    'pbBurnerType.Image = Image.FromFile(Application.StartupPath & "\" & "images\BTAA.bmp") 'by dinesh wagh on 20.3.2009
			///    ' code added by: dinesh wagh on 20.3.2009
			///    If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Or _
			///        gstructSettings.AppMode = EnumAppMode.DemoMode_201 Then
			///        pbBurnerType1.Image = Image.FromFile(Application.StartupPath & "\" & "images\BTAA.bmp")
			///    Else
			///        pbBurnerType.Image = Image.FromFile(Application.StartupPath & "\" & "images\BTAA.bmp")
			///    End If
			///Else
			///    mblnIsN2OBurnerPresent = True  '---added on 30.03.09

			///    'pbBurnerType.Image = Image.FromFile(Application.StartupPath & "\" & "images\BTNA.bmp") ' by dinesh wagh on 20.3.2009

			///    ''If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then '---02.02.09 as suggested by Mr. VCK   '---commented on 30.03.09
			///    ''    If mblnFuelFlowRateMsgDisp = False Then
			///    ''        gobjMessageAdapter.ShowMessage(constSetFuelFlow)
			///    ''        mblnFuelFlowRateMsgDisp = True
			///    ''    End If
			///    ''End If

			///    ' code added by: dinesh wagh on 20.3.2009
			///    If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Or _
			///        gstructSettings.AppMode = EnumAppMode.DemoMode_201 Then
			///        pbBurnerType1.Image = Image.FromFile(Application.StartupPath & "\" & "images\BTNA.bmp")
			///    Else
			///        pbBurnerType.Image = Image.FromFile(Application.StartupPath & "\" & "images\BTNA.bmp")
			///    End If
			///End If
			//====commented on 24.04.09


			//====written on 24.04.09
			if (gblnBurnerMsg == false) {
				if ((st1 & EnumErrorStatus.AA_CONNECTED)) {
					//mblnIsN2OBurnerPresent = False   '---added on 30.03.09  'commented on 26.04.09 for ver 4.87
					// code added by: dinesh wagh on 20.3.2009
					if (gstructSettings.AppMode == EnumAppMode.FullVersion_201 | gstructSettings.AppMode == EnumAppMode.DemoMode_201) {
						pbBurnerType1.Image = Image.FromFile(Application.StartupPath + "\\" + "images\\BTAA.bmp");
					} else {
						pbBurnerType.Image = Image.FromFile(Application.StartupPath + "\\" + "images\\BTAA.bmp");
					}
				} else {
					//mblnIsN2OBurnerPresent = True  '---added on 30.03.09   'commented on 26.04.09 for ver 4.87

					// code added by: dinesh wagh on 20.3.2009
					if (gstructSettings.AppMode == EnumAppMode.FullVersion_201 | gstructSettings.AppMode == EnumAppMode.DemoMode_201) {
						pbBurnerType1.Image = Image.FromFile(Application.StartupPath + "\\" + "images\\BTNA.bmp");
					} else {
						pbBurnerType.Image = Image.FromFile(Application.StartupPath + "\\" + "images\\BTNA.bmp");
					}
				}
			} else {
				if (gstructSettings.AppMode == EnumAppMode.FullVersion_201 | gstructSettings.AppMode == EnumAppMode.DemoMode_201) {
					pbBurnerType1.Image = Image.FromFile(Application.StartupPath + "\\" + "images\\ERROR.bmp");
				} else {
					pbBurnerType.Image = Image.FromFile(Application.StartupPath + "\\" + "images\\ERROR.bmp");
				}
			}
			//====written on 24.04.09


			pbBurnerType.Refresh();
			pbBurnerType1.Refresh();
			//dinesh wagh on 20.3.2009
			if ((st1 & EnumErrorStatus.TRAP_NOK)) {
				flag = false;
				pbSafetyControlsTrap.Image = Image.FromFile(Application.StartupPath + "\\" + "images\\topen.bmp");
			} else {
				pbSafetyControlsTrap.Image = Image.FromFile(Application.StartupPath + "\\" + "images\\OK.BMP");

			}
			pbSafetyControlsTrap.Refresh();
			if ((st1 & EnumErrorStatus.DOOR_NOK)) {
				flag = false;
				pbSafetyControlsDoor.Image = Image.FromFile(Application.StartupPath + "\\" + "images\\DOPEN.bmp");
			} else {
				pbSafetyControlsDoor.Image = Image.FromFile(Application.StartupPath + "\\" + "images\\DCLOSE.bmp");
			}
			pbSafetyControlsDoor.Refresh();
			if ((st & EnumErrorStatus.YELLOW_OK) == EnumErrorStatus.YELLOW_OK) {
				//pbFlameType.Image = Image.FromFile(Application.StartupPath & "\" & "images\YELLOW.BMP") 'by dinesh wagh on 20.3.2009
				////--- get the flame status for AA201 03.10.08
				intFlameStatus = 1;
				////---
				// code added by: dinesh wagh on 20.3.2009
				if (gstructSettings.AppMode == EnumAppMode.FullVersion_201 | gstructSettings.AppMode == EnumAppMode.DemoMode_201) {
					pbFlameType1.Image = Image.FromFile(Application.StartupPath + "\\" + "images\\YELLOW.BMP");
					//---commented on 26.04.09 (suggested by Mr. Ben) for ver 4.87
					//---Added on 30.03.09 (suggested by Mr. Vck)
					//'If gblnMessageDisplayed = False And mblnIsN2OBurnerPresent = True Then
					//'    gobjMessageAdapter.ShowMessage(constSetFuelFlow)
					//'    gblnMessageDisplayed = True
					//'End If
					//----------
					//----------
					mblnFlamePresent = true;
					//---added on 30.03.09
				} else {
					pbFlameType.Image = Image.FromFile(Application.StartupPath + "\\" + "images\\YELLOW.BMP");
				}


			} else if ((st & EnumErrorStatus.BLUE_OK) == EnumErrorStatus.BLUE_OK) {
				//pbFlameType.Image = Image.FromFile(Application.StartupPath & "\" & "images\BLUE.BMP") 'by dinesh wagh on 20.3.20009

				////--- get the flame status for AA201 03.10.08
				intFlameStatus = 1;
				////---

				// code added by: dinesh wagh on 20.3.2009
				if (gstructSettings.AppMode == EnumAppMode.FullVersion_201 | gstructSettings.AppMode == EnumAppMode.DemoMode_201) {
					pbFlameType1.Image = Image.FromFile(Application.StartupPath + "\\" + "images\\BLUE.BMP");
					//---Commented on 26.04.09 (suggested by Mr. Ben) for ver 4.87
					//---Added on 30.03.09 (suggested by Mr. Vck)
					//'If gblnMessageDisplayed = False And mblnIsN2OBurnerPresent = True Then
					//'    gobjMessageAdapter.ShowMessage(constSetFuelFlow)
					//'    gblnMessageDisplayed = True
					//'End If
					//----------
					//----------
					mblnFlamePresent = true;
					//---added on 30.03.09
				} else {
					pbFlameType.Image = Image.FromFile(Application.StartupPath + "\\" + "images\\BLUE.BMP");
				}

			} else if ((st & EnumErrorStatus.FLAME_OK) == EnumErrorStatus.FLAME_OK) {
				//pbFlameType.Image = Image.FromFile(Application.StartupPath & "\" & "images\BYELLOW.BMP") 'by dinesh wagh on 20.3.2009



				////--- get the flame status for AA201 03.10.08
				intFlameStatus = 1;
				////---

				// code added by: dinesh wagh on 20.3.2009
				if (gstructSettings.AppMode == EnumAppMode.FullVersion_201 | gstructSettings.AppMode == EnumAppMode.DemoMode_201) {
					pbFlameType1.Image = Image.FromFile(Application.StartupPath + "\\" + "images\\BYELLOW.BMP");
					//---Commented on 26.04.09 (suggested by Mr. Ben) for ver 4.87
					//---Added on 30.03.09 (suggested by Mr. Vck)
					//'If gblnMessageDisplayed = False And mblnIsN2OBurnerPresent = True Then
					//'    gobjMessageAdapter.ShowMessage(constSetFuelFlow)
					//'    gblnMessageDisplayed = True
					//'End If
					//----------
					//----------
					mblnFlamePresent = true;
					//---added on 30.03.09
				} else {
					pbFlameType.Image = Image.FromFile(Application.StartupPath + "\\" + "images\\BYELLOW.BMP");
				}


			} else if (flag) {
				//pbFlameType.Image = Image.FromFile(Application.StartupPath & "\" & "images\GREEN.BMP")'by dinesh wagh on 20.3.2009

				////--- get the flame status for AA201 03.10.08
				intFlameStatus = 0;
				////---
				// code added by: dinesh wagh on 20.3.2009
				if (gstructSettings.AppMode == EnumAppMode.FullVersion_201 | gstructSettings.AppMode == EnumAppMode.DemoMode_201) {
					pbFlameType1.Image = Image.FromFile(Application.StartupPath + "\\" + "images\\GREEN.BMP");
					//---added on 30.03.09
					//gblnMessageDisplayed = False   '---commented on 26.04.09 for ver 4.87
					//---------
					mblnFlamePresent = false;
					//30.03.09
				} else {
					pbFlameType.Image = Image.FromFile(Application.StartupPath + "\\" + "images\\GREEN.BMP");
				}

			} else {
				//pbFlameType.Image = Image.FromFile(Application.StartupPath & "\" & "images\RED.BMP") 'by dinesh wagh on 20.3.2009


				////--- get the flame status for AA201 03.10.08
				intFlameStatus = 0;
				////---
				// code added by: dinesh wagh on 20.3.2009
				if (gstructSettings.AppMode == EnumAppMode.FullVersion_201 | gstructSettings.AppMode == EnumAppMode.DemoMode_201) {
					pbFlameType1.Image = Image.FromFile(Application.StartupPath + "\\" + "images\\RED.BMP");
					//---added on 30.03.09
					//gblnMessageDisplayed = False   '---commented on 26.04.09 for ver 4.87
					//---------
					mblnFlamePresent = false;
					//---added on 30.03.09
				} else {
					pbFlameType.Image = Image.FromFile(Application.StartupPath + "\\" + "images\\RED.BMP");
				}

			}

			// code added by : dinesh wagh on 22.3.2009
			//If gstructSettings.AppMode = EnumAppMode.DemoMode_201 Then

			//    lblFRatio1.Text = Format(gobjClsAAS203.funcRead_Fuel(), "0.00")
			//End If


			//22.02.09

			if (gstructSettings.AppMode == EnumAppMode.FullVersion_201) {
				int fl;
				fl = 0;

				//---Changed on 30.03.09
				funcCheck_Flame_Test201(fl);
				//------------

				////--- if Hydride mode is not set then check the flame status
				if (gstructSettings.HydrideMode) {
					//'check for hydride mode
					if (!HydrideMode) {
						if (intFlameStatus == 1) {
							intflag = 1;
						}
					}
					//---27.05.09
					if (intFlameStatus == 1) {
						intflag = 1;
					}
				} else {
					if (!(gobjInst.Hydride)) {
						if (intFlameStatus == 1) {
							intflag = 1;
						}
					}
				}

				////--- if flame is not present and fuel volve is open then set the fuel volve close
				//If gobjInst.N2of = False Then '---commented on 30.03.09
				if ((fuel) & (intflag == 1)) {
					gobjInst.Aaf = true;
				} else {
					if ((fuel)) {
						if (gobjCommProtocol.func_FUEL_OFF() == true) {
							fuel = false;
							gobjInst.Aaf = false;
						}
					}
				}
				//End If
				////--- if flame is not present and N2O volve is open then set the N2O volve close
				//If n2 And air Then
				//If gobjInst.Aaf = False Then '---commented on 30.03.09
				if ((n2) & (intflag == 1)) {
					gobjInst.N2of = true;
				} else {
					if ((n2)) {
						if (gobjCommProtocol.func_N2O_OFF() == true) {
							n2 = false;
							gobjInst.N2of = false;
						}
					}
				}
				//End If

				//---commented on 30.03.09
				//If fl = True Then
				//    Call gobjMessageAdapter.ShowMessage("Flame is off", "Flame Off", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage)
				//End If
				//--------------

				//---added on 30.03.09
				switch (fl) {
					case 1:
						//---added on 30.03.09
						gobjCommProtocol.func_N2O_OFF();
						gobjCommProtocol.func_FUEL_OFF();
						//-------------

						gobjMessageAdapter.ShowMessage("Flame is off", "Flame Off", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage);
					case 2:
						//---added on 30.03.09
						gobjCommProtocol.func_N2O_OFF();
						gobjCommProtocol.func_FUEL_OFF();
						//-------------

						if (fuel == false) {
							gobjMessageAdapter.ShowMessage(constFlameErrorFuelOff);
						}
					case 3:
						//---added on 30.03.09
						gobjCommProtocol.func_N2O_OFF();
						gobjCommProtocol.func_FUEL_OFF();
						//-------------

						gobjMessageAdapter.ShowMessage(constFlameErrorAirOff);
					case 4:
						//---added on 30.03.09
						gobjCommProtocol.func_N2O_OFF();
						gobjCommProtocol.func_FUEL_OFF();
						//-------------

						if (n2 == false) {
							gobjMessageAdapter.ShowMessage(constFlameErrorN2OOff);
						}
				}

			}
			////---

			gobjCommProtocol.mobjCommdll.subTime_Delay(20);
			if (mblnIgnitionWait == false) {
				if (gobjCommProtocol.funcGet_NV_Pos() == false) {
					//'serial communication function for getting NV pos
					return;
				}
			} else {
				return;
			}

			if (mblnIgnitionWait == false) {
				///lblFRatio.Text = Format(gobjClsAAS203.funcRead_Fuel(), "0.00") commneted by dinesh wagh on 20.3.2009

				// code added by : dinesh wagh on 22.3.2009
				if (gstructSettings.AppMode == EnumAppMode.DemoMode_201 | gstructSettings.AppMode == EnumAppMode.FullVersion_201) {
					lblFRatio1.Text = Format(gobjClsAAS203.funcRead_Fuel(), "0.00");
				} else {
					lblFRatio.Text = Format(gobjClsAAS203.funcRead_Fuel(), "0.00");
				}
			//-------------
			//'this will give a current value of fuel
			} else {
				return;
			}
			gobjCommProtocol.mobjCommdll.subTime_Delay(20);
			//'delay
			if (mblnIgnitionWait == false) {
				if (gobjCommProtocol.func_Get_BH_Pos() == false) {
					//'this is for getting burner position
					return;
				}
			} else {
				return;
			}

			//lblBHeight.Text = Format(gobjClsAAS203.funcReadBurnerHeight(), "0.00") dinesh wagh on 20.3.2009

			if (!gstructSettings.AppMode == EnumAppMode.DemoMode_201 | !gstructSettings.AppMode == EnumAppMode.FullVersion_201) {
				lblBHeight.Text = Format(gobjClsAAS203.funcReadBurnerHeight(), "0.0");
			}


			//Commented by Amit
			lblBHeight.Refresh();
			pbFlameType.Refresh();

			pbFlameType1.Refresh();
			// dinesh wagh on 20.3.2009

			pbSafetyControlsDoor.Refresh();

			Application.DoEvents();

			lblNVStep.Text = "NV : " + gobjInst.NvStep + "";
			lblNVStep.Refresh();
			Application.DoEvents();
			return true;
		//Catch ThreadEx As Threading.ThreadAbortException

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
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	private void subSetAirOnOff()
	{
		//=====================================================================
		// Procedure Name        : subSetAirOnOff
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 24-Mar-2007 03:15 pm
		// Revisions             : 1
		//=====================================================================

		//'note:
		//'set a flag that stand for current state of air
		//'check a cond from air flag 
		//'and perfrom ON / OFF by sending serial communication protocol

		try {
			if (ps1) {
				//'here ps1 stand for air pressure flag
				if (air) {
					//'air is a flag for air ,it stand true if air is on else 
					if (gobjCommProtocol.funcAir_OFF() == true) {
						air = false;
					}
				} else {
					if (gobjCommProtocol.funcAir_ON() == true) {
						air = true;
					}
				}
			} else {
				gobjMessageAdapter.ShowMessage(constLowAirPressure);
				//'show the low air message
				Application.DoEvents();
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


	private void subSetN2OOnOff()
	{
		//=====================================================================
		// Procedure Name        : subSetN2OOnOff
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 24-Mar-2007 03:15 pm
		// Revisions             : 1
		//=====================================================================
		//'note:
		//'check for a pressure 
		//'check for a N2 flag 
		//'and as per flag send a serial communication protocol

		try {
			if (ps2) {
				//To check N2O flame status
				if (n2) {
					//If gobjCommProtocol.func_N2O_OFF() = True Then   '---25.06.09 '---commented for version 4.91
					//    n2 = False
					//End If

					//---25.06.09  added for version 4.91
					if (gstructSettings.AppMode == EnumAppMode.FullVersion_201) {
						if (gobjCommProtocol.func_N2O_OFF() == true) {
							n2 = false;
						}
					} else {
						n2 = gobjCommProtocol.func_N2O_OFF();
					}
				//End If
				} else {
					//---added on 26.04.09 ver 4.87
					if (gstructSettings.AppMode == EnumAppMode.FullVersion_201 | gstructSettings.AppMode == EnumAppMode.DemoMode_201) {
						gobjMessageAdapter.ShowMessage(constSetFuelFlow);
					}
					//-----------------

					//'If gobjCommProtocol.func_N2O_ON() = True Then  '---25.06.09  commented for version 4.91
					//'    '---Commented on 30.03.09
					//'    'n2 = gobjCommProtocol.func_N2O_OFF
					//'    '------------

					//'    '---Written on 30.03.09
					//'    n2 = True
					//'    '------------
					//'End If

					//---25.06.09 added for version 4.91
					if (gstructSettings.AppMode == EnumAppMode.FullVersion_201) {
						if (gobjCommProtocol.func_N2O_ON() == true) {
							//---Commented on 30.03.09
							//n2 = gobjCommProtocol.func_N2O_OFF
							//------------

							//---Written on 30.03.09
							n2 = true;
							//------------
						}
					} else {
						n2 = gobjCommProtocol.func_N2O_ON();
					}
				}
			//End If
			} else {
				if (n2) {
					//---Commented on 30.03.09
					//n2 = gobjCommProtocol.func_N2O_OFF
					//-------------------

					//---Written on 30.03.09
					if (gobjCommProtocol.func_N2O_OFF == true) {
						n2 = false;
					}
					//-------------------
				}
				gobjMessageAdapter.ShowMessage(constLowN2OPressure);
				Application.DoEvents();
			}
			////--- Added by Sachin Dokhale on 22.05.08
			if (gstructSettings.AppMode == EnumAppMode.FullVersion_201) {
				//If fuel And air Then
				if (fuel) {
					gobjInst.Aaf = true;
				} else {
					gobjInst.Aaf = false;
				}
				//If n2 And air Then
				if (n2) {
					gobjInst.N2of = true;
				} else {
					gobjInst.N2of = false;
				}
			}
		////---
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


	private void subSetFuelOnOff()
	{
		//=====================================================================
		// Procedure Name        : subSetFuelOnOff
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 24-Mar-2007 03:15 pm
		// Revisions             : 1
		//=====================================================================
		//'note:
		//'check for pressure
		//'check fuel flag
		//'and as par cond send a proper protocol
		try {
			if (ps3) {
				if (fuel) {
					if (gobjCommProtocol.func_FUEL_OFF() == true) {
						fuel = false;
					}
				} else {
					if (gobjCommProtocol.func_FUEL_ON() == true) {
						fuel = true;
					}
				}
			} else {
				if (fuel) {
					if (gobjCommProtocol.func_FUEL_OFF() == true) {
						fuel = false;
					}
				}
				gobjMessageAdapter.ShowMessage(constLowFuelPressure);
				Application.DoEvents();
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


	private void subSetIgniteOnOff()
	{
		//=====================================================================
		// Procedure Name        : subSetIgniteOnOff
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 24-Mar-2007 03:15 pm
		// Revisions             : 1
		//=====================================================================
		//'this is used to set a ignition on/off
		try {
			if (BIgnite) {
				if (gobjCommProtocol.func_IGNITE_OFF()) {
					//'check for a ignition if true(ignition off)
					btnIgnite.Text = "IGNITE ON";
					BIgnite = false;
				}
			} else if (BIgnite == false) {
				if (gobjCommProtocol.func_IGNITE_ON()) {
					btnIgnite.Text = "IGNITE OFF";
					BIgnite = true;
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

	private void subIncreaseFuel()
	{
		//=====================================================================
		// Procedure Name        : subIncreaseFuel
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 24-Mar-2007 03:15 pm
		// Revisions             : 1
		//=====================================================================
		//'this will increase the fuel by 0.1
		//'here gobjClsAAS203.funcRead_Fuel()  will return current fuel
		//=====================================================================
		//void     S4FUNC Incr_Fuel()
		//{
		// Get_NV_Pos();
		//        If (Inst.Nvstep >= NVSTEP) Then
		//		NV_RotateClock_Steps(NVSTEP);
		// Get_NV_Pos();
		//}
		//=====================================================================

		try {
			gobjClsAAS203.funcIncr_Fuel();
			lblNVStep1.Text = Format((double)gobjInst.NvStep / (double)NVSTEP, "000.00");
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

	private void subDecreaseFuel()
	{
		//=====================================================================
		// Procedure Name        : subDecreaseFuel
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 24-Mar-2007 03:15 pm
		// Revisions             : 1
		//=====================================================================
		//'this will decrease the fuel 
		//        ''gobjClsAAS203.funcRead_Fuel() will return the current fuel.
		//=====================================================================
		//void	S4FUNC Decr_Fuel()
		//{
		//int k;
		// Get_NV_Pos();
		//        If (Inst.Nvstep <= (NVRED * MAXNVHOME - NVSTEP)) Then
		//	  for (k=1; k<=NVSTEP; k++){
		//		if (!Flame_Present(FALSE)) {
		//			NV_RotateClock();
		//			pc_delay(200);
		//			break;
		//		  }
		//		NV_RotateAnticlock();
		//	}
		//#If DEMO Then
		//	 NVpos+=NVSTEP;
		//#End If
		// Get_NV_Pos();
		//}
		//=====================================================================

		try {
			gobjClsAAS203.funcDecr_Fuel();
			lblNVStep1.Text = Format((double)gobjInst.NvStep / (double)NVSTEP, "000.00");
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

	private void subSetMaxFuel()
	{
		//=====================================================================
		// Procedure Name        : subSetMaxFuel
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 24-Mar-2007 03:15 pm
		// Revisions             : 1
		//=====================================================================
		try {
			if (gobjCommProtocol.funcSetNV_HOME()) {
				//'by setting NV at home position we can set fuel to its mximum 
				gobjInst.NvStep = 0;
			} else {
				gobjInst.NvStep = -1;
			}
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
			//---------------------------------------------------------
		}
	}

	private void subIncreaseBurnerHeight()
	{
		//=====================================================================
		// Procedure Name        : subIncreaseBurnerHeight
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 24-Mar-2007 03:15 pm
		// Revisions             : 1
		//=====================================================================
		try {
			gobjClsAAS203.funcIncr_Height();
		//'function for increasing a burner height 
		//'this will increase the burner height in a step
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

	private void subDecreaseBurnerHeight()
	{
		//=====================================================================
		// Procedure Name        : subDecreaseBurnerHeight
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 24-Mar-2007 03:15 pm
		// Revisions             : 1
		//=====================================================================
		try {
			gobjClsAAS203.funcDecr_Height();
		//'function for drecrease a burner height 
		//'this will drecrease the burner height in a step
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

	private void subSetMaxBurnerHeight()
	{
		//=====================================================================
		// Procedure Name        : subSetMaxBurnerHeight
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 24-Mar-2007 03:15 pm
		// Revisions             : 1
		//=====================================================================
		try {
			if (gobjCommProtocol.funcSetBH_HOME()) {
				//'if we set burner at its home position then burner is in max position
				gobjInst.BhStep = 0;
			} else {
				gobjInst.BhStep = -1;
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

	private void subAutoIgnition()
	{
		//=====================================================================
		// Procedure Name        : subAutoIgnition
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 24-Mar-2007 03:15 pm
		// Revisions             : 1
		//=====================================================================
		try {
			this.custpnlStatusDisplay.Height = 0;
			this.Height = 200;
			this.Enabled = false;
			//29.12.08
			Application.DoEvents();

			gobjClsAAS203.funcIgnite(true);

			Application.DoEvents();
			this.Enabled = true;
			//29.12.08
			this.custpnlStatusDisplay.Height = 120;
			this.Height = 320;
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

	private void subAutoExtinguish()
	{
		//=====================================================================
		// Procedure Name        : subAutoExtinguish
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : this is used to put off the ignition
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 24-Mar-2007 03:15 pm
		// Revisions             : 1
		//=====================================================================
		try {
			this.custpnlStatusDisplay.Height = 0;
			this.Height = 200;
			this.Enabled = false;
			//29.12.08
			Application.DoEvents();

			gobjClsAAS203.funcIgnite(false);

			this.Enabled = true;
			//29.12.08
			this.custpnlStatusDisplay.Height = 120;
			this.Height = 320;
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

	private void btnAutoIgnite_Click(System.Object sender, System.EventArgs e)
	{
		try {
			if (mblnInProcess == true) {
				return;
			}
			mblnInProcess = true;
			cmdBarBtnIgnite.SuspendEvents();

			//---changed by Deepak on 28.12.08
			//mblnIgnitionWait = True
			//mobjclsBgManualIgnition.IgnitionWait = True
			if (mobjController.IsThreadRunning == true) {
				mobjController.Cancel();
				gobjCommProtocol.mobjCommdll.subTime_Delay(50);
				Application.DoEvents();
			}
			//---end changes

			subAutoIgnition();

			Application.DoEvents();
			gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay);
			//10.12.07
			Application.DoEvents();
			mblnInProcess = false;
			cmdBarBtnIgnite.ResumeEvents();

			//---changed by Deepak on 28.12.08
			//mblnIgnitionWait = False
			//mobjclsBgManualIgnition.IgnitionWait = False
			if (mobjController.IsThreadRunning == false) {
				mobjController.Start(mobjclsBgManualIgnition);
				Application.DoEvents();
			}
		//---end changes

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			//---------------------------------------------------------
			mblnIgnitionWait = false;
			mblnInProcess = false;
			mobjclsBgManualIgnition.IgnitionWait = false;
			cmdBarBtnIgnite.ResumeEvents();
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	private void btnExtinguish_Click(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : btnALT_I_Click
		// Parameters Passed     : Object, EventArgs
		// Returns               : 
		// Purpose               : To make the necessary adjustments and auto 
		//                       : ignite the flame.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 07-02-2007
		// Revisions             : 
		//=====================================================================
		try {
			if (mblnInProcess == true) {
				return;
			}
			mblnInProcess = true;
			cmdBarBtnExtinguish.SuspendEvents();

			//---30.12.08
			//mblnIgnitionWait = True
			//mobjclsBgManualIgnition.IgnitionWait = True
			//Application.DoEvents()
			//gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay)   '10.12.07
			//Application.DoEvents()

			//---changed by Deepak on 30.12.08
			//mblnIgnitionWait = True
			//mobjclsBgManualIgnition.IgnitionWait = True
			if (mobjController.IsThreadRunning == true) {
				mobjController.Cancel();
				gobjCommProtocol.mobjCommdll.subTime_Delay(50);
				Application.DoEvents();
			}
			//---end changes

			subAutoExtinguish();

			Application.DoEvents();
			gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay);
			//10.12.07
			Application.DoEvents();
			mblnInProcess = false;
			cmdBarBtnExtinguish.ResumeEvents();

			//---30.12.08
			//mblnIgnitionWait = False
			//mobjclsBgManualIgnition.IgnitionWait = False

			//---changed by Deepak on 30.12.08
			//mblnIgnitionWait = False
			//mobjclsBgManualIgnition.IgnitionWait = False
			if (mobjController.IsThreadRunning == false) {
				mobjController.Start(mobjclsBgManualIgnition);
				Application.DoEvents();
			}
		//---end changes


		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			//---------------------------------------------------------
			mblnIgnitionWait = false;
			mblnInProcess = false;
			mobjclsBgManualIgnition.IgnitionWait = false;
			cmdBarBtnExtinguish.ResumeEvents();
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}


	private void btnN2OIgnite_Click(System.Object sender, System.EventArgs e)
	{
		try {
			if (mblnInProcess == true) {
				return;
			}
			mblnInProcess = true;
			cmdBarBtnExtinguish.SuspendEvents();
			mblnIgnitionWait = true;
			mobjclsBgManualIgnition.IgnitionWait = true;
			Application.DoEvents();
			gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay);
			//10.12.07
			Application.DoEvents();
			//'delay
			gobjCommProtocol.funcSwitchOver();
			//'function To Switch to N20 Flame
			Application.DoEvents();
			gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay);
			//10.12.07
			Application.DoEvents();
			mblnIgnitionWait = false;
			mblnInProcess = false;
			mobjclsBgManualIgnition.IgnitionWait = false;
			cmdBarBtnExtinguish.ResumeEvents();
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			//---------------------------------------------------------
			mblnIgnitionWait = false;
			mblnInProcess = false;
			mobjclsBgManualIgnition.IgnitionWait = false;
			cmdBarBtnExtinguish.ResumeEvents();
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
			cmdBarBtnExtinguish.SuspendEvents();
			mblnIgnitionWait = true;
			mobjclsBgManualIgnition.IgnitionWait = true;
			Application.DoEvents();
			gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay);
			//10.12.07
			Application.DoEvents();
			//If Not gstructSettings.AppMode = EnumAppMode.DemoMode Then
			Application.DoEvents();
			//If Not gstructSettings.AppMode = EnumAppMode.DemoMode Then
			if (!((gstructSettings.AppMode == EnumAppMode.DemoMode) | (gstructSettings.AppMode == EnumAppMode.DemoMode_201) | (gstructSettings.AppMode == EnumAppMode.DemoMode_203D))) {
				gobjCommProtocol.mobjCommdll.subTime_Delay(50);
				gobjClsAAS203.ReInitInstParameters();
			}
			//Else
			//    'Call gobjMessageAdapter.ShowMessage(constFlameIgnited)
			//    'Call Application.DoEvents()
			//End If
			Application.DoEvents();
			gobjCommProtocol.mobjCommdll.subTime_Delay(50);
			//10.12.07
			Application.DoEvents();
			mblnIgnitionWait = false;
			mblnInProcess = false;
			mobjclsBgManualIgnition.IgnitionWait = false;
			cmdBarBtnExtinguish.ResumeEvents();
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			//---------------------------------------------------------
			mblnIgnitionWait = false;
			mblnInProcess = false;
			mobjclsBgManualIgnition.IgnitionWait = false;
			cmdBarBtnExtinguish.ResumeEvents();
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
			cmdBarBtnExtinguish.SuspendEvents();
			mblnIgnitionWait = true;
			mobjclsBgManualIgnition.IgnitionWait = true;
			Application.DoEvents();
			gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay);
			//10.12.07
			Application.DoEvents();
			//Alt - R
			//If Not gstructSettings.AppMode = EnumAppMode.DemoMode Then
			if (!(gstructSettings.AppMode == EnumAppMode.DemoMode) | (gstructSettings.AppMode == EnumAppMode.DemoMode_201) | (gstructSettings.AppMode == EnumAppMode.DemoMode_203D)) {
				Application.DoEvents();
				gobjCommProtocol.mobjCommdll.subTime_Delay(50);
				gobjClsAAS203.funcInstReset();
			} else {
				Application.DoEvents();
			}
			Application.DoEvents();
			gobjCommProtocol.mobjCommdll.subTime_Delay(50);
			//10.12.07
			Application.DoEvents();
			mblnIgnitionWait = false;
			mblnInProcess = false;
			mobjclsBgManualIgnition.IgnitionWait = false;
			cmdBarBtnExtinguish.ResumeEvents();
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			//---------------------------------------------------------
			mblnIgnitionWait = false;
			mblnInProcess = false;
			mobjclsBgManualIgnition.IgnitionWait = false;
			cmdBarBtnExtinguish.ResumeEvents();
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
frmManualIgnition_Activated(object sender, System.EventArgs e)
	{
		//'note
		//'this will start the manual ignition thread
		//If mblnAvoidProcessing Then
		//    Exit Sub
		//End If
		try {
		//    If mblnIsManualIgnitionActivated = False Then
		//        mblnAvoidProcessing = True

		//        'mobjThread = New Threading.Thread(AddressOf subThreadStart)
		//        'mobjThread.IsBackground = False
		//        'mobjThread.Name = "Manual Ignition"
		//        'mobjThread.Start()

		//        'Thread.Sleep(500)
		//        If mobjController Is Nothing Then
		//            mobjController = New clsBgThread(Me)
		//        End If
		//        If mobjclsBgManualIgnition Is Nothing Then
		//            mobjclsBgManualIgnition = New ClsBgManualIgnition
		//        End If
		//        gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay)   '10.12.07
		//        Application.DoEvents()
		//        If mobjController.IsThreadRunning = False Then
		//            mobjController.Start(mobjclsBgManualIgnition)
		//            AddHandler mobjclsBgManualIgnition.ManualIgnition, AddressOf subWaitManualThread
		//        End If
		//        mblnIsManualIgnitionActivated = True
		//        mblnAvoidProcessing = False
		//    End If
		//    Me.Focus()
		//    Me.Refresh()
		//    Application.DoEvents()
		//Me.Refresh()

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


	private void LoadInConst()
	{

		try {
			// code added by :dinesh wagh on 20.3.2009
			// code start

			if (gstructSettings.AppMode == EnumAppMode.FullVersion_201 | gstructSettings.AppMode == EnumAppMode.DemoMode_201) {
				pnl203.Visible = false;
				pnl201.Visible = true;
				pnl201.Dock = DockStyle.Top;
			} else {
				pnl203.Visible = true;
				pnl201.Visible = false;
				pnl203.Dock = DockStyle.Top;
			}

			//code ends


			pbPressureAir.Visible = true;
			pbPressureN2O.Visible = true;
			pbPressureFuel.Visible = true;
			pbStatusAir.Visible = true;
			pbStatusN2O.Visible = true;
			pbStatusFuel.Visible = true;
			pbBurnerType.Visible = true;
			pbSafetyControlsTrap.Visible = true;
			pbSafetyControlsDoor.Visible = true;
			pbFlameType.Visible = true;



			setVisibleFalse201Controls();

			if (!IsNothing(gobjMain)) {
				//If Not IsNothing(gobjMain.mobjfrmAnalysis) Then gobjMain.mobjfrmAnalysis.tmrAspirationMsg.Enabled = False
				if (gobjMain.mobjController.IsThreadRunning == true) {
					mblnIsfrmFlameStatusWork = true;
					gobjMain.mobjController.Cancel();
					Application.DoEvents();
					gobjCommProtocol.mobjCommdll.subTime_Delay(500);
					//10.12.07
					Application.DoEvents();
				}
				Application.DoEvents();
			}
			Manual_Init_Check();
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

	private void subWaitManualThread(ref bool IsContinue)
	{
		//=====================================================================
		// Procedure Name        : subWaitManualThread
		// Parameters Passed     : bool for IS Continue status
		// Returns               : 
		// Purpose               : this is used for allow thread to wait
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 
		// Revisions             : 
		//=====================================================================
		try {
			if (mblnIgnitionWait == false) {
				Manual_Init_Check();
			}

			if (mblnIgnitionWait == false) {
			}
			IsContinue = mblnIgnitionWait;
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
frmManualIgnition_Closing(object sender, System.ComponentModel.CancelEventArgs e)
	{
		//=====================================================================
		// Procedure Name        : 
		// Parameters Passed     : 
		// Returns               : 
		// Purpose               : 
		//                         
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : Thursday, 10 aug, 2007
		// Revisions             : 1
		//=====================================================================
		//'note:
		//'this is called when user close the manual ignition form 
		//'first stop the thread
		//'put the ignition off etc...


		try {
			if (mblnIgnitionTerminate == false) {
				//'check the status of thread
				if (!(mobjController == null)) {
					if (mobjController.IsThreadRunning) {
						mobjclsBgManualIgnition.ThTerminate = true;
						mobjclsBgManualIgnition.IgnitionWait = true;
						mblnIgnitionWait = true;
						gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay);
						//10.12.07
						Application.DoEvents();
						e.Cancel = true;
						Application.DoEvents();
						//'allow application to perfrom its panding work
						btnClose_Click(sender, e);
						return;
					}
				}
			} else {
				if (!(mobjController == null)) {
					if (mobjController.IsThreadRunning) {
						mobjclsBgManualIgnition.ThTerminate = true;
						mobjclsBgManualIgnition.IgnitionWait = true;
						//'allowing thread to wait
						mblnIgnitionWait = true;
						mobjController.Cancel();
						gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay);
						//10.12.07
						Application.DoEvents();
					}
				}
			}
			if (gobjCommProtocol.func_IGNITE_OFF()) {
				//'function for putting ignition off
			}
			ClsAAS203.enumIgniteType intIgnite_Test;
			if (gobjClsAAS203.funcIgnite_Test(intIgnite_Test)) {
				intFlameType = intIgnite_Test;
				gobjfrmStatus.FlameType = intFlameType;
			}

			if (mblnIsfrmFlameStatusWork == true) {
				if (!IsNothing(gobjMain)) {
					//If Not IsNothing(gobjMain.mobjfrmAnalysis) Then gobjMain.mobjfrmAnalysis.tmrAspirationMsg.Enabled = False
					if (gobjMain.mobjController.IsThreadRunning == false) {
						gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay);
						//10.12.07
						Application.DoEvents();
						gobjMain.mobjController.Start(gobjclsBgFlameStatus);
					}
					mblnIsfrmFlameStatusWork = false;
					Application.DoEvents();
				}
			}
			e.Cancel = false;
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
			Application.DoEvents();
			//---------------------------------------------------------
		}

	}

	public bool funcCheck_Flame_Test201(ref int flg)
	{
		//---Changed on 30.03.09
		try {
			//BYTE 		st;

			//BOOL 	ps1, ps2, ps3, flag=0;

			//if (Inst.Aaf || Inst.N2of) {
			//	ps1 = ps2 = ps3 = ON;
			//	st  = CHECK_PS();
			//	if (st & AIR_NOK) ps1 = OFF;
			//	if (st & N2O_NOK) ps2 = OFF;
			//	if (st & FUEL_NOK) ps3 = OFF;
			//#If HYRD_MODE Then
			//	if (!HydrideMode){
			//#Else
			//	if (!Inst.Hydride){
			//#End If
			//	  if ((st&FLAME_OK) !=FLAME_OK ) flag=1;
			//	  }
			//	if (!ps3) flag=2;
			//	if (Inst.Aaf) if (!ps1) flag = 3;
			//	if (Inst.N2of) if (!ps2) flag = 4;
			//#If DEMO Then
			//		flag=FALSE;
			//#End If

			//	if (flag){
			//	  Flame_Off();
			//	  switch(flag) {
			//		 case 1 : Inst.Nvstep-= (5*NVSTEP);Save_NV_Pos();
			//					 Gerror_message(" **FLAME ERROR *** \n Flame OFF "); break;
			//		 case 2 : Gerror_message(" **FLAME ERROR *** \n Fuel not enough "); break;
			//		 case 3 : Gerror_message(" **FLAME ERROR *** \n Air  not enough "); break;
			//		 case 4 : Gerror_message(" **FLAME ERROR *** \n N2o  not enough "); break;
			//	  }
			//	}
			// }
			//}

			byte bdata;
			bool ps1;
			bool ps2;
			bool ps3;
			int intflag = 0;

			//if (Inst.Aaf || Inst.N2of) {
			//	ps1 = ps2 = ps3 = ON;
			if (((gobjInst.Aaf) | (gobjInst.N2of))) {
				//if true
				ps1 = true;
				// To check for Air pressure 
				ps2 = true;
				// To check for N2O pressure 
				ps3 = true;
				// To check for Fuel pressure 

				if (gobjCommProtocol.funcPressSensorStatus(bdata)) {
					//'get a presssensor status
					if ((bdata & EnumErrorStatus.AIR_NOK)) {
						//'check for air nok
						ps1 = false;
					}
					if ((bdata & EnumErrorStatus.N2O_NOK)) {
						//'check for n2o nok
						ps2 = false;
					}
					if ((bdata & EnumErrorStatus.FUEL_NOK)) {
						//'check for fuel nok
						ps3 = false;
					}
					//End If

					//#If HYRD_MODE Then
					//	if (!HydrideMode){
					//#Else
					//	if (!Inst.Hydride){
					//#End If
					//	  if ((st&FLAME_OK) !=FLAME_OK ) flag=1;
					//	  }


					if (gstructSettings.HydrideMode) {
						//'check for hydride mode
						if (!HydrideMode) {
							if ((!(bdata & EnumErrorStatus.FLAME_OK) == EnumErrorStatus.FLAME_OK)) {
								intflag = 1;
							}
						}
					} else {
						if (!(gobjInst.Hydride)) {
							if ((!(bdata & EnumErrorStatus.FLAME_OK) == EnumErrorStatus.FLAME_OK)) {
								intflag = 1;
							}
						}
					}

					//	if (!ps3) flag=2;
					//	if (Inst.Aaf) if (!ps1) flag = 3;
					//	if (Inst.N2of) if (!ps2) flag = 4;

					if (!(ps3)) {
						intflag = 2;
					}

					if ((gobjInst.Aaf)) {
						if (!(ps1)) {
							intflag = 3;
						}
					}

					//If Not (gobjInst.Aaf) Then
					if ((gobjInst.N2of)) {
						if (!(ps2)) {
							intflag = 4;
						}
					}
					//End If


					//#If DEMO Then
					//		flag=FALSE;
					//#endif
					//If gstructSettings.AppMode = EnumAppMode.DemoMode Then
					if ((gstructSettings.AppMode == EnumAppMode.DemoMode) | (gstructSettings.AppMode == EnumAppMode.DemoMode_201) | (gstructSettings.AppMode == EnumAppMode.DemoMode_203D)) {
						intflag = false;
					}

					if ((intflag)) {
						gobjCommProtocol.funcFlame_OFF();
						//'for flame off
						////--- check the flame status for AA201 03.10.08
						if (gstructSettings.AppMode == EnumAppMode.FullVersion_201) {
							////--- Set the Fuel volve off  when flame is not present
							if (gobjCommProtocol.func_FUEL_OFF() == true) {
							}
							////--- Set the N2O volve off when flame is not present
							if ((gobjInst.N2of)) {
								if (gobjCommProtocol.func_N2O_OFF() == true) {
								}
							}
						}
						////---
						switch (intflag) {
							//'select case as per flag
							case 1:
								flg = 1;
							////--- check the flame status for AA201 03.10.08
							//If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
							//    Call gobjMessageAdapter.ShowMessage("Flame is off", "Flame Off", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage)
							//Else
							//    gobjInst.NvStep -= (5 * NVSTEP)
							//    '**************************************************************************
							//    '---Added function by Mangesh on 23-Apr-2007
							//    '**************************************************************************
							//    Call gobjCommProtocol.funcSave_NV_Pos()
							//    ''for saving a NV position
							//    '**************************************************************************
							//    Call gobjMessageAdapter.ShowMessage(constFlameErrorFlameOff)
							//    'break;
							//End If
							////---
							case 2:
								// Gerror_message(" **FLAME ERROR *** \n Fuel not enough "); break;
								//Call gobjMessageAdapter.ShowMessage(constFlameErrorFuelOff)

								flg = 2;
							case 3:
								// Gerror_message(" **FLAME ERROR *** \n Air  not enough "); break;
								//Call gobjMessageAdapter.ShowMessage(constFlameErrorAirOff)
								flg = 3;
							case 4:
								// Gerror_message(" **FLAME ERROR *** \n N2o  not enough "); break;
								//Call gobjMessageAdapter.ShowMessage(constFlameErrorN2OOff)
								flg = 4;
							default:
								flg = 0;
						}
					}
				}
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

	#Region " IClient Events for receiving the wavelength and Abs value from Receiving thread "

	private void BgThread.Iclient.TaskStarted(clsBgThread BgThread)
	{
		try {
			//mblnAvoidProcessing = True
			mblnIgnitionWait = false;
			mblnIgnitionTerminate = false;
		//func_Enable_Disable(EnumProcesses.StartScan, EnumStart_End.Process_Running)
		} catch (Exception ex) {
		//gFuncShowMessage("Communication Error...", "Error in starting spectrum scanning.", modConstants.EnumMessageType.Information)
		//---------------------------------------------------------
		//Error logging
		//gobjErrorHandler.ErrorDescription = ex.Message
		//gobjErrorHandler.ErrorMessage = ex.Message
		//gobjErrorHandler.WriteErrorLog(ex)
		//gobjErrorHandler.ProcessError(ErrorHandler.EnumErrorType.Critical, ex)
		//---------------------------------------------------------

		} finally {
			//    '---------------------------------------------------------
			//    'Writing Execution log
			//    If CONST_CREATE_EXECUTION_LOG = 1 Then
			//        gobjErrorHandler.WriteExecutionLog()
			//    End If
			//    '---------------------------------------------------------
		}

	}

	private void Iclient.TaskStatus(string Text)
	{
		try {
		//If gstructApplicationSessionState.intInstrument_Group = EnumInstrumentGroup.Initialize_2600_2700 Then
		//Call funcIclientTaskDisplayData(Text)
		//If Not (mobjclsBgSpectrum Is Nothing) Then
		//    mobjclsBgSpectrum.EndProcess = True
		//End If
		//ElseIf gstructApplicationSessionState.intInstrument_Group = EnumInstrumentGroup.Initialize_2100_2200_2300 Then
		//Call funcIclientTaskDisplay2100(Text)
		//End If


		} catch (Exception ex) {
		//gFuncShowMessage("Error...", "Error in displaying the spectrum on the screen.", modConstants.EnumMessageType.Information)
		//---------------------------------------------------------
		//Error logging
		//gobjErrorHandler.ErrorDescription = ex.Message
		//gobjErrorHandler.ErrorMessage = ex.Message
		//gobjErrorHandler.WriteErrorLog(ex)
		//gobjErrorHandler.ProcessError(ErrorHandler.EnumErrorType.Critical, ex)
		//---------------------------------------------------------
		} finally {
			//'---------------------------------------------------------
			//'Writing Execution log
			//If CONST_CREATE_EXECUTION_LOG = 1 Then
			//    gobjErrorHandler.WriteExecutionLog()
			//End If
			//'--------------------------------------------------------
			Application.DoEvents();
		}

	}


	// commented Iclient.Display before implementation of UV2100
	//Implements Iclient.Display
	//    Try
	//'-----------------------------------------------------
	//'Data in the Text arg would be "Wavelength|Abs"
	//'-----------------------------------------------------
	//Dim objData As New Data
	//Dim arrData() As String
	//Dim O As Integer   ' same as in function funcSmoothgraphonline
	//Dim intCount As Integer

	//'--- Split the data for Wv and Abs
	//        arrData = Split(Text, "|")

	//        If arrData(0).Length > 0 And arrData(1).Length > 0 And arrData(2).Length > 0 Then

	//            objData.XaxisData = Format(Val(arrData(0)), "#000.0")  ' wv

	//            Select Case mobjTemporaryChannel.Parameter.ScanMode
	//                Case EnumScanMode.Absorbance
	//                    objData.YaxisData = Format(Val(arrData(1)), "#0.000")
	//                Case EnumScanMode.Transmittance
	//                    objData.YaxisData = Format(Val(arrData(1)), "#0.0")
	//                Case EnumScanMode.Energy
	//                    objData.YaxisData = Format(Val(arrData(1)), "#0.0")
	//            End Select

	//            O = (ORDER - 1) / 2

	//            If Val(arrData(2)) = EnumUVProtocol.Data Then

	//'--- Add the reading to the temp readings collection
	//                mobjTemporaryReadings.Add(objData)

	//                lblOnlineWv.Text = Format(mobjTemporaryReadings.item(mobjTemporaryReadings.Count - 1).XaxisData, "#000.0")

	//                Select Case mobjTemporaryChannel.Parameter.ScanMode
	//                    Case EnumScanMode.Absorbance
	//                        lblOnlineABS.Text = Format(mobjTemporaryReadings.item(mobjTemporaryReadings.Count - 1).YaxisData, "#0.000")
	//                    Case EnumScanMode.Transmittance, EnumScanMode.Energy
	//                        lblOnlineABS.Text = Format(mobjTemporaryReadings.item(mobjTemporaryReadings.Count - 1).YaxisData, "#0.0")
	//                End Select


	//                If gblnSmoothFlag Then
	//                    If mobjTemporaryReadings.Count < ORDER Then
	//                        NPSmoothningdata(mobjTemporaryReadings.Count) = objData.YaxisData
	//                    End If

	//                    If (mobjTemporaryReadings.Count - 1) < ((ORDER - 1) / 2) Then

	//                        funcDisplayGraph_RealTime(mobjTemporaryReadings.item(mobjTemporaryReadings.Count - 1).XaxisData, _
	//                                                  mobjTemporaryReadings.item(mobjTemporaryReadings.Count - 1).YaxisData)

	//                    ElseIf mobjTemporaryReadings.Count >= ORDER Then
	//                        gfuncSmoothOnlineGraph(mobjTemporaryReadings, NPSmoothningdata)
	//                        funcDisplayGraph_RealTime(mobjTemporaryReadings.item((mobjTemporaryReadings.Count - 1) - O).XaxisData, _
	//                                                  mobjTemporaryReadings.item((mobjTemporaryReadings.Count - 1) - O).YaxisData)
	//                    End If
	//                Else  ' if not gblnsmoothgraph then there is no need to smooth the graph
	//                    funcDisplayGraph_RealTime(mobjTemporaryReadings.item(mobjTemporaryReadings.Count - 1).XaxisData, _
	//                                              mobjTemporaryReadings.item(mobjTemporaryReadings.Count - 1).YaxisData)
	//                End If
	//            End If

	//            If Val(arrData(2)) = EnumUVProtocol.CMD_End _
	//            Or Val(arrData(2)) = EnumUVProtocol.Spect_End _
	//            Or Val(arrData(2)) = EnumUVProtocol.CMD_Acknowledge Then

	//                If gblnSmoothFlag Then
	//                    For intCount = (((ORDER - 1) / 2) - 1) To 0 Step -1
	//                        funcDisplayGraph_RealTime(mobjTemporaryReadings.item((mobjTemporaryReadings.Count - 1) - intCount).XaxisData, _
	//                                                  mobjTemporaryReadings.item((mobjTemporaryReadings.Count - 1) - intCount).YaxisData)
	//                    Next
	//                End If
	//            End If
	//        End If

	//    Catch ex As Exception
	//        gFuncShowMessage("Error...", "Error in displaying the Spectrum on the screen.", modConstants.EnumMessageType.Information)
	//'---------------------------------------------------------
	//'Error logging
	//'gobjErrorHandler.ErrorDescription = ex.Message
	//'gobjErrorHandler.ErrorMessage = ex.Message
	//'gobjErrorHandler.WriteErrorLog(ex)
	//'gobjErrorHandler.ProcessError(ErrorHandler.EnumErrorType.Critical, ex)
	//'---------------------------------------------------------
	//    Finally
	///---------------------------------------------------------
	///Writing Execution log
	//'If CONST_CREATE_EXECUTION_LOG = 1 Then
	//'    gobjErrorHandler.WriteExecutionLog()
	//'End If
	///--------------------------------------------------------

	//    End Try

	//End Sub

	private void Iclient.TaskFailed(Exception e)
	{
		try {
			//--- Dispose all the objects
			//mobjTemporaryChannel = New Channel
			//mobjTemporaryReadings = New Readings
			//mobjTemporaryReadings_2100 = New Readings
			//funcIclientTaskFalied()

			//mblnSpectrumStarted = False
			//mblnAvoidProcessing = False
			//Call mnuExit_Click(btnReturn, EventArgs.Empty)
			//gFuncShowMessage("Error...", "Spectrum scanning failed.", modConstants.EnumMessageType.Information)
			mblnIgnitionTerminate = true;
			mblnIgnitionWait = true;
		} catch (Exception ex) {
		//---------------------------------------------------------
		//Error logging
		//gobjErrorHandler.ErrorDescription = ex.Message
		//gobjErrorHandler.ErrorMessage = ex.Message
		//gobjErrorHandler.WriteErrorLog(ex)
		//gobjErrorHandler.ProcessError(ErrorHandler.EnumErrorType.Critical, ex)
		//---------------------------------------------------------
		} finally {
			//'---------------------------------------------------------
			//'Writing Execution log
			//If CONST_CREATE_EXECUTION_LOG = 1 Then
			//    gobjErrorHandler.WriteExecutionLog()
			//End If
			//'---------------------------------------------------------
			Application.DoEvents();
		}

	}


	private void Iclient.TaskCompleted(bool Cancelled)
	{
		try {
			//If gstructApplicationSessionState.intInstrument_Group = EnumInstrumentGroup.Initialize_2600_2700 Then
			//    'Call funcIclientTaskCompleted2600()
			//ElseIf gstructApplicationSessionState.intInstrument_Group = EnumInstrumentGroup.Initialize_2100_2200_2300 Then
			//    'Call funcIclientTaskCompleted2100()
			//End If
			//Call funcIclientTaskCompleted()

			//mblnSpectrumStarted = False
			//mblnAvoidProcessing = False
			//Call mnuExit_Click(btnReturn, EventArgs.Empty)
			mblnIgnitionTerminate = true;
			mblnIgnitionWait = true;
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error logging
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
			Application.DoEvents();
		}

	}

	#End Region

	#Region " Commented Code "

	//    void	Manual_Init_Check(HDC hdc)
	//{
	//BYTE data;
	//  if (!Commflag)
	//	 return;
	//	Status_Disp();
	//	aa = ps1 = ps2 = ps3 = ON;
	//	data  = CHECK_PS();
	//	if (data & AIR_NOK) ps1 = OFF;
	//	if (data & N2O_NOK) ps2 = OFF;
	//	if (data & FUEL_NOK) ps3 = OFF;
	//	data = CHECK_BUR_PAR();
	//	if (data & AA_CONNECTED) aa = ON;
	//	if (!ps1)  {
	//	  Wprintf(hdc, 20, 0, " No AIR Pressure  ");
	//	  if (! ( air))  air = AIR_ON();
	//	 }
	//	if (!ps2) {
	//	  Wprintf(hdc, 20, 15, " No N�O Pressure  ");
	//	  if( n2)  n2 = N2O_OFF();
	//	 }
	//	if (!ps3) {
	//	  Wprintf(hdc, 20, 30," No FUEL Pressure  ");
	//	  if ( fuel)  fuel = FUEL_OFF();
	//	 }
	//	if (aa) Wprintf(hdc, 20, 45 ," AA  Burner  attached ");
	//	else Wprintf(hdc, 20, 45 ," N2o Burner attached ");
	//}
	//====================================================================

	//    void	Status_Disp()
	//{
	//char  line1[80];
	//BYTE  status,st, st1;
	//BOOL	flag=TRUE;

	//if (!Commflag)
	//	 return;
	//if (StHwnd!=NULL){
	//  status = GET_PNEUM_STATUS();
	////  st=random(255); st1=random(255);
	//  st = CHECK_PS();
	//  st1 = CHECK_BUR_PAR();
	//  if (st & AIR_NOK)	 		{  flag=FALSE; SetVal(IDC_PAIR, "ERROR");}
	//  else 	SetVal(IDC_PAIR, "OK");
	//  if (st & N2O_NOK)	 		{  flag=FALSE; SetVal(IDC_PN2O, "ERROR");}
	//  else 	SetVal(IDC_PN2O, "OK");
	//  if (st & FUEL_NOK)	 		{  flag=FALSE; SetVal(IDC_PFUEL, "ERROR");}
	//  else 	SetVal(IDC_PFUEL, "OK");
	//  if (status & SAIR_NON) 	{
	//		flag=FALSE; SetVal(IDC_PVAIR,"CLOSE");}
	//  else	SetVal(IDC_PVAIR,"OPEN");
	//  if (status & SN2O_ON)	 	SetVal(IDC_PVN2O, "OPEN");
	//  else	{  flag=FALSE; SetVal(IDC_PVN2O, "CLOSE");}
	//  if (status & SFUEL_ON)	SetVal(IDC_PVFUEL, "OPEN");
	//  else	{  flag=FALSE; SetVal(IDC_PVFUEL, "CLOSE");}
	//  if (st1 & AA_CONNECTED) 	SetVal(IDC_BTYPE, "BTAA");
	//  else 	SetVal(IDC_BTYPE, "BTNA");
	//  if (st1 & TRAP_NOK) {  flag=FALSE; SetVal(IDC_TRAP, "TOPEN");}
	//  else SetVal(IDC_TRAP, "OK");
	//  if (st1 &DOOR_NOK) {  flag=FALSE; SetVal(IDC_DTYPE, "DOPEN");}
	//  else SetVal(IDC_DTYPE, "DCLOSE");
	//  if ((st&YELLOW_OK) ==YELLOW_OK) 		SetVal(IDC_FLAME, "YELLOW");
	//  else if ((st&BLUE_OK)==BLUE_OK)  	SetVal(IDC_FLAME, "BLUE");
	//  else if ((st & FLAME_OK)==FLAME_OK) 	SetVal(IDC_FLAME, "BYELLOW");
	//  else if (flag)	SetVal(IDC_FLAME, "GREEN");
	//  else SetVal(IDC_FLAME, "RED");
	//  Get_NV_Pos();
	//  sprintf(line1,"%3.2f", Read_Fuel());	// Nv pos
	//  SetWindowText(GetDlgItem(StHwnd, IDC_FR),line1);
	//  Get_BH_Pos();
	//  sprintf(line1,"%2.1f", ReadBurnerHeight());
	//  SetWindowText(GetDlgItem(StHwnd, IDC_BH),line1);
	//  UpdateWindow (StHwnd) ;
	// }
	//}
	//=++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
	//    BYTE	GET_PNEUM_STATUS()
	//{
	//  Transmit(PNEMSTATUS, 0, 0 , 0);
	// Recev(TRUE);
	////  c = PNEMSTATUS; trans(c); recev();
	//return Param1;
	//}
	#Region ""
	//=====on air on/off
	//if (ps1)	{
	//									  if (air){ air = AIR_OFF();if(GetInstrument() == AA202) SetWindowText(GetDlgItem(hwnd,IDC_BAIR),"N2O OFF");}
	//									  else{ air = AIR_ON();if(GetInstrument() == AA202) SetWindowText(GetDlgItem(hwnd,IDC_BAIR),"N2O ON");}
	//									 }
	//								  else{  if(GetInstrument() == AA202)
	//												Gerror_message_new("No AIR Pressure ..","AA-202 PNEUM");
	//											else
	//												Gerror_message_new("No AIR Pressure ..","AA-203 PNEUM");
	//												}break;
	//=====on n20 button on/off
	//if (ps2)  {
	//					  if(n2){ n2 = N2O_OFF();}
	//					  else{ n2 = N2O_ON();}
	//					 }
	//					else {
	//					  if(n2) n2 = N2O_OFF();
	//					  if(GetInstrument() == AA202)
	//						Gerror_message_new("No N2O Pressure ..", "AA-202 PNEUM");
	//					  else
	//						Gerror_message_new("No N2O Pressure ..", "AA-203 PNEUM");
	//					} break;
	//=========on fuel on/off button
	//if (ps3){
	//					  if (fuel){ if(GetInstrument() == AA202){  air = AIR_ON(); SetWindowText(GetDlgItem(hwnd,IDC_BAIR),"N2O ON");SetWindowText(GetDlgItem(hwnd,IDC_BFUEL),"FUEL ON");pc_delay(6000);pc_delay(6000);}fuel = FUEL_OFF();}
	//					  else{ if( GetInstrument() == AA202 ){SetWindowText(GetDlgItem(hwnd,IDC_BFUEL),"FUEL OFF");}fuel = FUEL_ON();}
	//					 }
	//					else  {
	//					  if (fuel) fuel = FUEL_OFF();
	//						 if(GetInstrument() == AA202)
	//							 Gerror_message_new("No FUEL Pressure ..", "AA-202 PNEUM");
	//						 else
	//							 Gerror_message_new("No FUEL Pressure ..", "AA-203 PNEUM");
	//					 } break;
	//=======on ignite on/off button
	//if (fuel && air) Inst.Aaf = ON;
	//				  if (fuel && n2) Inst.N2of = ON;
	//				  if (Bignite) Bignite=IGNITE_OFF();
	//				  else   if (!Inst.Aaf && !Inst.N2of)  Bignite = IGNITE_ON();
	//				  pc_delay(250);break;
	//=====on increment fuel button 
	//Incr_Fuel();
	//				  Wprintf(hdc, 10, 70, "%3.2f      ", (double)Inst.Nvstep/(double)NVSTEP);break;
	//======on decrement fuel button
	//Decr_Fuel();
	//				  Wprintf(hdc, 10, 70, "%3.2f      ", (double)Inst.Nvstep/(double)NVSTEP); break;
	//
	//====on form closing
	//   if (Bignite) Bignite=IGNITE_OFF();
	//if (fuel && air) Inst.Aaf = ON;
	//if (fuel && n2) Inst.N2of = ON;





	#End Region

	//Private Function Read_Fuel() As Double
	//    '=====================================================================
	//    ' Procedure Name        : Read_Fuel
	//    ' Parameters Passed     : Object,EventArgs
	//    ' Returns               : Fuel
	//    ' Purpose               : To get the fuel.
	//    ' Description           : 
	//    ' Assumptions           : 
	//    ' Dependencies          : 
	//    ' Author                : Saurabh S
	//    ' Created               : 02.02.07
	//    ' Revisions             : 
	//    '=====================================================================
	//    Dim fuel As Double = 0.0
	//    Try
	//        gobjCommProtocol.funcGet_NV_Pos()
	//        fuel = ConvertToFuel(gobjInst.NvStep)
	//        Return fuel

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
	//        'objWait.Dispose()
	//        '---------------------------------------------------------
	//    End Try

	//End Function

	//Private Function ConvertToFuel(ByVal intNVSteps As Integer)
	//    '=====================================================================
	//    ' Procedure Name        : ConvertToFuel
	//    ' Parameters Passed     : Object,EventArgs
	//    ' Returns               : Fuel value
	//    ' Purpose               : To convert the steps into fuel.
	//    ' Description           : 
	//    ' Assumptions           : 
	//    ' Dependencies          : 
	//    ' Author                : Saurabh S
	//    ' Created               : 02.02.07
	//    ' Revisions             : 
	//    '=====================================================================
	//    Dim fuel As Double = 0.0
	//    Try
	//        If intNVSteps < 0 Then
	//            Return 0.0
	//        End If
	//        fuel = MAXNVHOME * 1.0 - (intNVSteps / NVRED)
	//        If Burner_Type() Then
	//            fuel = (fuel + 0.1561) / 0.6733
	//        Else
	//            fuel = (fuel + 0.1732) / 0.7232
	//        End If
	//        Return fuel

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
	//        'objWait.Dispose()
	//        '---------------------------------------------------------
	//    End Try

	//End Function

	//Private Function Burner_Type() As Boolean
	//    '=====================================================================
	//    ' Procedure Name        : Burner_Type
	//    ' Parameters Passed     : Object,EventArgs
	//    ' Returns               : True or False
	//    ' Purpose               : To get the type of Burner AA or NA.
	//    ' Description           : 
	//    ' Assumptions           : 
	//    ' Dependencies          : 
	//    ' Author                : Saurabh S
	//    ' Created               : 02.02.07
	//    ' Revisions             : 
	//    '=====================================================================
	//    Dim st1 As Byte
	//    Try
	//        gobjCommProtocol.funcCheckBurnerParameters(st1)
	//        If (st1 And EnumErrorStatus.AA_CONNECTED) Then
	//            Return True
	//        Else
	//            Return False
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
	//        'objWait.Dispose()
	//        '---------------------------------------------------------
	//    End Try

	//End Function

	//Private Function ReadBurnerHeight() As Double
	//    '=====================================================================
	//    ' Procedure Name        : ReadBurnerHeight
	//    ' Parameters Passed     : Object,EventArgs
	//    ' Returns               : Burner Height
	//    ' Purpose               : To get the Burner Height.
	//    ' Description           : 
	//    ' Assumptions           : 
	//    ' Dependencies          : 
	//    ' Author                : Saurabh S
	//    ' Created               : 02.02.07
	//    ' Revisions             : 
	//    '=====================================================================
	//    Dim dblBH As Double = 0.0
	//    Try
	//        dblBH = ConvertToBurnerHeight(gobjInst.BhStep)
	//        Return dblBH

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
	//        'objWait.Dispose()
	//        '---------------------------------------------------------
	//    End Try

	//End Function

	//Private Function ConvertToBurnerHeight(ByVal steps As Integer)
	//    '=====================================================================
	//    ' Procedure Name        : ConvertToBurnerHeight
	//    ' Parameters Passed     : Object,EventArgs
	//    ' Returns               : Height
	//    ' Purpose               : To convert the steps in height.
	//    ' Description           : 
	//    ' Assumptions           : 
	//    ' Dependencies          : 
	//    ' Author                : Saurabh S
	//    ' Created               : 02.02.07
	//    ' Revisions             : 
	//    '=====================================================================
	//    Dim dblBH As Double = 0.0
	//    Try
	//        dblBH = steps / (200.0 * BHRATIO)
	//        Return dblBH

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
	//        'objWait.Dispose()
	//        '---------------------------------------------------------
	//    End Try
	//End Function

	#End Region


}
