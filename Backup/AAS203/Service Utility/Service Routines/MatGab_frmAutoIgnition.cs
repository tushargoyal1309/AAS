using AAS203.Common;
using System.Threading;
using BgThread;

public class frmAutoIgnition : System.Windows.Forms.Form, Iclient
{
	#Region " Windows Form Designer generated code "

	public frmAutoIgnition()
	{
		base.New();

		//This call is required by the Windows Form Designer.
		InitializeComponent();

		//Add any initialization after the InitializeComponent() call
		funcInitialise();
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
	internal System.Windows.Forms.Label Label2;
	internal NETXP.Controls.XPButton btnSetMaxBurnerHeight;
	internal NETXP.Controls.XPButton btnSetMaxFuel;
	internal NETXP.Controls.XPButton btnIncreaseBurnerHeight;
	internal NETXP.Controls.XPButton btnDecreaseBurnerHeight;
	internal NETXP.Controls.XPButton btnDecreaseFuel;
	internal NETXP.Controls.XPButton btnIncreaseFuel;
	internal NETXP.Controls.XPButton btnAAFLAME;
	internal NETXP.Controls.XPButton btnNAFLAME;
	internal System.Windows.Forms.Label lblBHeight;
	internal System.Windows.Forms.Label lblFRatio;
	internal System.Windows.Forms.Label Label3;
	internal System.Windows.Forms.Label lblBurnerHeight;
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
	internal System.Windows.Forms.Label Label7;
	internal System.Windows.Forms.Label Label6;
	internal System.Windows.Forms.Label Label5;
	internal System.Windows.Forms.Label Label4;
	internal System.Windows.Forms.Label Label8;
	internal System.Windows.Forms.Label lblStatus;
	internal NETXP.Controls.XPButton btnClose;
	internal System.Windows.Forms.Label lblNVStep1;
	internal System.Windows.Forms.PictureBox pbPressureAir;
	internal System.Windows.Forms.PictureBox pbSafetyControlsDoor;
	internal System.Windows.Forms.PictureBox pbBurnerType;
	internal System.Windows.Forms.PictureBox pbStatusFuel;
	internal System.Windows.Forms.PictureBox pbStatusN2O;
	internal System.Windows.Forms.PictureBox pbPressureFuel;
	internal System.Windows.Forms.PictureBox pbFlameType;
	internal System.Windows.Forms.PictureBox pbSafetyControlsTrap;
	internal System.Windows.Forms.PictureBox pbStatusAir;
	internal System.Windows.Forms.PictureBox pbPressureN2O;
	[System.Diagnostics.DebuggerStepThrough()]
	private void InitializeComponent()
	{
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmAutoIgnition));
		this.CustomPanel1 = new GradientPanel.CustomPanel();
		this.lblNVStep1 = new System.Windows.Forms.Label();
		this.btnClose = new NETXP.Controls.XPButton();
		this.lblStatus = new System.Windows.Forms.Label();
		this.lblBHeight = new System.Windows.Forms.Label();
		this.lblFRatio = new System.Windows.Forms.Label();
		this.Label3 = new System.Windows.Forms.Label();
		this.lblBurnerHeight = new System.Windows.Forms.Label();
		this.pbFlameType = new System.Windows.Forms.PictureBox();
		this.pbSafetyControlsTrap = new System.Windows.Forms.PictureBox();
		this.pbSafetyControlsDoor = new System.Windows.Forms.PictureBox();
		this.pbBurnerType = new System.Windows.Forms.PictureBox();
		this.pbStatusFuel = new System.Windows.Forms.PictureBox();
		this.pbStatusN2O = new System.Windows.Forms.PictureBox();
		this.pbPressureFuel = new System.Windows.Forms.PictureBox();
		this.pbPressureN2O = new System.Windows.Forms.PictureBox();
		this.pbPressureAir = new System.Windows.Forms.PictureBox();
		this.pbStatusAir = new System.Windows.Forms.PictureBox();
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
		this.Label4 = new System.Windows.Forms.Label();
		this.Label8 = new System.Windows.Forms.Label();
		this.btnNAFLAME = new NETXP.Controls.XPButton();
		this.btnAAFLAME = new NETXP.Controls.XPButton();
		this.btnSetMaxBurnerHeight = new NETXP.Controls.XPButton();
		this.btnSetMaxFuel = new NETXP.Controls.XPButton();
		this.btnIncreaseBurnerHeight = new NETXP.Controls.XPButton();
		this.btnDecreaseBurnerHeight = new NETXP.Controls.XPButton();
		this.btnDecreaseFuel = new NETXP.Controls.XPButton();
		this.btnIncreaseFuel = new NETXP.Controls.XPButton();
		this.Label2 = new System.Windows.Forms.Label();
		this.CustomPanel1.SuspendLayout();
		this.SuspendLayout();
		//
		//CustomPanel1
		//
		this.CustomPanel1.BackColor = System.Drawing.Color.AliceBlue;
		this.CustomPanel1.Controls.Add(this.lblNVStep1);
		this.CustomPanel1.Controls.Add(this.btnClose);
		this.CustomPanel1.Controls.Add(this.lblStatus);
		this.CustomPanel1.Controls.Add(this.lblBHeight);
		this.CustomPanel1.Controls.Add(this.lblFRatio);
		this.CustomPanel1.Controls.Add(this.Label3);
		this.CustomPanel1.Controls.Add(this.lblBurnerHeight);
		this.CustomPanel1.Controls.Add(this.pbFlameType);
		this.CustomPanel1.Controls.Add(this.pbSafetyControlsTrap);
		this.CustomPanel1.Controls.Add(this.pbSafetyControlsDoor);
		this.CustomPanel1.Controls.Add(this.pbBurnerType);
		this.CustomPanel1.Controls.Add(this.pbStatusFuel);
		this.CustomPanel1.Controls.Add(this.pbStatusN2O);
		this.CustomPanel1.Controls.Add(this.pbPressureFuel);
		this.CustomPanel1.Controls.Add(this.pbPressureN2O);
		this.CustomPanel1.Controls.Add(this.pbPressureAir);
		this.CustomPanel1.Controls.Add(this.pbStatusAir);
		this.CustomPanel1.Controls.Add(this.lblFlameRatio);
		this.CustomPanel1.Controls.Add(this.lblFlameType);
		this.CustomPanel1.Controls.Add(this.lblSafetyControlsTrap);
		this.CustomPanel1.Controls.Add(this.lblSafetyControlsDoor);
		this.CustomPanel1.Controls.Add(this.lblBurnerType);
		this.CustomPanel1.Controls.Add(this.lblStatusFuel);
		this.CustomPanel1.Controls.Add(this.lblStatusN2O);
		this.CustomPanel1.Controls.Add(this.lblStatusAir);
		this.CustomPanel1.Controls.Add(this.lblPressureFuel);
		this.CustomPanel1.Controls.Add(this.lblPressureN2O);
		this.CustomPanel1.Controls.Add(this.lblPressureAir);
		this.CustomPanel1.Controls.Add(this.lblFlame);
		this.CustomPanel1.Controls.Add(this.lblSafetyControls);
		this.CustomPanel1.Controls.Add(this.lblBurner);
		this.CustomPanel1.Controls.Add(this.lblPressureValveStatus);
		this.CustomPanel1.Controls.Add(this.lblPressures);
		this.CustomPanel1.Controls.Add(this.Label7);
		this.CustomPanel1.Controls.Add(this.Label6);
		this.CustomPanel1.Controls.Add(this.Label5);
		this.CustomPanel1.Controls.Add(this.Label4);
		this.CustomPanel1.Controls.Add(this.Label8);
		this.CustomPanel1.Controls.Add(this.btnNAFLAME);
		this.CustomPanel1.Controls.Add(this.btnAAFLAME);
		this.CustomPanel1.Controls.Add(this.btnSetMaxBurnerHeight);
		this.CustomPanel1.Controls.Add(this.btnSetMaxFuel);
		this.CustomPanel1.Controls.Add(this.btnIncreaseBurnerHeight);
		this.CustomPanel1.Controls.Add(this.btnDecreaseBurnerHeight);
		this.CustomPanel1.Controls.Add(this.btnDecreaseFuel);
		this.CustomPanel1.Controls.Add(this.btnIncreaseFuel);
		this.CustomPanel1.Controls.Add(this.Label2);
		this.CustomPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.CustomPanel1.Location = new System.Drawing.Point(0, 0);
		this.CustomPanel1.Name = "CustomPanel1";
		this.CustomPanel1.Size = new System.Drawing.Size(634, 287);
		this.CustomPanel1.TabIndex = 0;
		//
		//lblNVStep1
		//
		this.lblNVStep1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblNVStep1.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblNVStep1.Location = new System.Drawing.Point(72, 112);
		this.lblNVStep1.Name = "lblNVStep1";
		this.lblNVStep1.Size = new System.Drawing.Size(72, 20);
		this.lblNVStep1.TabIndex = 103;
		this.lblNVStep1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		//
		//btnClose
		//
		this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnClose.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnClose.Image = (System.Drawing.Image)resources.GetObject("btnClose.Image");
		this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnClose.Location = new System.Drawing.Point(376, 240);
		this.btnClose.Name = "btnClose";
		this.btnClose.Size = new System.Drawing.Size(110, 38);
		this.btnClose.TabIndex = 6;
		this.btnClose.Text = "C&LOSE";
		//
		//lblStatus
		//
		this.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblStatus.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblStatus.ForeColor = System.Drawing.Color.Red;
		this.lblStatus.Location = new System.Drawing.Point(240, 111);
		this.lblStatus.Name = "lblStatus";
		this.lblStatus.Size = new System.Drawing.Size(390, 32);
		this.lblStatus.TabIndex = 101;
		this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		//
		//lblBHeight
		//
		this.lblBHeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblBHeight.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblBHeight.Location = new System.Drawing.Point(347, 70);
		this.lblBHeight.Name = "lblBHeight";
		this.lblBHeight.Size = new System.Drawing.Size(66, 32);
		this.lblBHeight.TabIndex = 100;
		this.lblBHeight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		//
		//lblFRatio
		//
		this.lblFRatio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblFRatio.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblFRatio.Location = new System.Drawing.Point(576, 70);
		this.lblFRatio.Name = "lblFRatio";
		this.lblFRatio.Size = new System.Drawing.Size(56, 32);
		this.lblFRatio.TabIndex = 99;
		this.lblFRatio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		//
		//Label3
		//
		this.Label3.BackColor = System.Drawing.SystemColors.Control;
		this.Label3.Location = new System.Drawing.Point(0, 104);
		this.Label3.Name = "Label3";
		this.Label3.Size = new System.Drawing.Size(700, 2);
		this.Label3.TabIndex = 98;
		//
		//lblBurnerHeight
		//
		this.lblBurnerHeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblBurnerHeight.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblBurnerHeight.Location = new System.Drawing.Point(347, 44);
		this.lblBurnerHeight.Name = "lblBurnerHeight";
		this.lblBurnerHeight.Size = new System.Drawing.Size(66, 24);
		this.lblBurnerHeight.TabIndex = 97;
		this.lblBurnerHeight.Text = "HEIGHT";
		this.lblBurnerHeight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		//
		//pbFlameType
		//
		this.pbFlameType.BackColor = System.Drawing.Color.Transparent;
		this.pbFlameType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.pbFlameType.Location = new System.Drawing.Point(535, 70);
		this.pbFlameType.Name = "pbFlameType";
		this.pbFlameType.Size = new System.Drawing.Size(32, 32);
		this.pbFlameType.TabIndex = 96;
		this.pbFlameType.TabStop = false;
		//
		//pbSafetyControlsTrap
		//
		this.pbSafetyControlsTrap.BackColor = System.Drawing.Color.Transparent;
		this.pbSafetyControlsTrap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.pbSafetyControlsTrap.Location = new System.Drawing.Point(481, 70);
		this.pbSafetyControlsTrap.Name = "pbSafetyControlsTrap";
		this.pbSafetyControlsTrap.Size = new System.Drawing.Size(32, 32);
		this.pbSafetyControlsTrap.TabIndex = 95;
		this.pbSafetyControlsTrap.TabStop = false;
		//
		//pbSafetyControlsDoor
		//
		this.pbSafetyControlsDoor.BackColor = System.Drawing.Color.Transparent;
		this.pbSafetyControlsDoor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.pbSafetyControlsDoor.Location = new System.Drawing.Point(429, 70);
		this.pbSafetyControlsDoor.Name = "pbSafetyControlsDoor";
		this.pbSafetyControlsDoor.Size = new System.Drawing.Size(32, 32);
		this.pbSafetyControlsDoor.TabIndex = 94;
		this.pbSafetyControlsDoor.TabStop = false;
		//
		//pbBurnerType
		//
		this.pbBurnerType.BackColor = System.Drawing.Color.Transparent;
		this.pbBurnerType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.pbBurnerType.Location = new System.Drawing.Point(292, 70);
		this.pbBurnerType.Name = "pbBurnerType";
		this.pbBurnerType.Size = new System.Drawing.Size(32, 32);
		this.pbBurnerType.TabIndex = 93;
		this.pbBurnerType.TabStop = false;
		//
		//pbStatusFuel
		//
		this.pbStatusFuel.BackColor = System.Drawing.Color.Transparent;
		this.pbStatusFuel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.pbStatusFuel.Location = new System.Drawing.Point(229, 70);
		this.pbStatusFuel.Name = "pbStatusFuel";
		this.pbStatusFuel.Size = new System.Drawing.Size(32, 32);
		this.pbStatusFuel.TabIndex = 92;
		this.pbStatusFuel.TabStop = false;
		//
		//pbStatusN2O
		//
		this.pbStatusN2O.BackColor = System.Drawing.Color.Transparent;
		this.pbStatusN2O.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.pbStatusN2O.Location = new System.Drawing.Point(186, 70);
		this.pbStatusN2O.Name = "pbStatusN2O";
		this.pbStatusN2O.Size = new System.Drawing.Size(32, 32);
		this.pbStatusN2O.TabIndex = 91;
		this.pbStatusN2O.TabStop = false;
		//
		//pbPressureFuel
		//
		this.pbPressureFuel.BackColor = System.Drawing.Color.Transparent;
		this.pbPressureFuel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.pbPressureFuel.Location = new System.Drawing.Point(94, 70);
		this.pbPressureFuel.Name = "pbPressureFuel";
		this.pbPressureFuel.Size = new System.Drawing.Size(32, 32);
		this.pbPressureFuel.TabIndex = 90;
		this.pbPressureFuel.TabStop = false;
		//
		//pbPressureN2O
		//
		this.pbPressureN2O.BackColor = System.Drawing.Color.Transparent;
		this.pbPressureN2O.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.pbPressureN2O.Location = new System.Drawing.Point(51, 70);
		this.pbPressureN2O.Name = "pbPressureN2O";
		this.pbPressureN2O.Size = new System.Drawing.Size(32, 32);
		this.pbPressureN2O.TabIndex = 89;
		this.pbPressureN2O.TabStop = false;
		//
		//pbPressureAir
		//
		this.pbPressureAir.BackColor = System.Drawing.Color.Transparent;
		this.pbPressureAir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.pbPressureAir.Location = new System.Drawing.Point(8, 70);
		this.pbPressureAir.Name = "pbPressureAir";
		this.pbPressureAir.Size = new System.Drawing.Size(32, 32);
		this.pbPressureAir.TabIndex = 88;
		this.pbPressureAir.TabStop = false;
		//
		//pbStatusAir
		//
		this.pbStatusAir.BackColor = System.Drawing.Color.Transparent;
		this.pbStatusAir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.pbStatusAir.Location = new System.Drawing.Point(143, 70);
		this.pbStatusAir.Name = "pbStatusAir";
		this.pbStatusAir.Size = new System.Drawing.Size(32, 32);
		this.pbStatusAir.TabIndex = 87;
		this.pbStatusAir.TabStop = false;
		//
		//lblFlameRatio
		//
		this.lblFlameRatio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblFlameRatio.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblFlameRatio.Location = new System.Drawing.Point(576, 44);
		this.lblFlameRatio.Name = "lblFlameRatio";
		this.lblFlameRatio.Size = new System.Drawing.Size(56, 24);
		this.lblFlameRatio.TabIndex = 86;
		this.lblFlameRatio.Text = "RATIO";
		this.lblFlameRatio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		//
		//lblFlameType
		//
		this.lblFlameType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblFlameType.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblFlameType.Location = new System.Drawing.Point(527, 44);
		this.lblFlameType.Name = "lblFlameType";
		this.lblFlameType.Size = new System.Drawing.Size(48, 24);
		this.lblFlameType.TabIndex = 85;
		this.lblFlameType.Text = "TYPE";
		this.lblFlameType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		//
		//lblSafetyControlsTrap
		//
		this.lblSafetyControlsTrap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblSafetyControlsTrap.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblSafetyControlsTrap.Location = new System.Drawing.Point(473, 44);
		this.lblSafetyControlsTrap.Name = "lblSafetyControlsTrap";
		this.lblSafetyControlsTrap.Size = new System.Drawing.Size(48, 24);
		this.lblSafetyControlsTrap.TabIndex = 84;
		this.lblSafetyControlsTrap.Text = "TRAP";
		this.lblSafetyControlsTrap.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		//
		//lblSafetyControlsDoor
		//
		this.lblSafetyControlsDoor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblSafetyControlsDoor.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblSafetyControlsDoor.Location = new System.Drawing.Point(419, 44);
		this.lblSafetyControlsDoor.Name = "lblSafetyControlsDoor";
		this.lblSafetyControlsDoor.Size = new System.Drawing.Size(53, 24);
		this.lblSafetyControlsDoor.TabIndex = 83;
		this.lblSafetyControlsDoor.Text = "DOOR";
		this.lblSafetyControlsDoor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		//
		//lblBurnerType
		//
		this.lblBurnerType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblBurnerType.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblBurnerType.Location = new System.Drawing.Point(271, 44);
		this.lblBurnerType.Name = "lblBurnerType";
		this.lblBurnerType.Size = new System.Drawing.Size(75, 24);
		this.lblBurnerType.TabIndex = 82;
		this.lblBurnerType.Text = "TYPE";
		this.lblBurnerType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		//
		//lblStatusFuel
		//
		this.lblStatusFuel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblStatusFuel.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblStatusFuel.Location = new System.Drawing.Point(224, 44);
		this.lblStatusFuel.Name = "lblStatusFuel";
		this.lblStatusFuel.Size = new System.Drawing.Size(43, 24);
		this.lblStatusFuel.TabIndex = 81;
		this.lblStatusFuel.Text = "FUEL";
		this.lblStatusFuel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		//
		//lblStatusN2O
		//
		this.lblStatusN2O.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblStatusN2O.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblStatusN2O.Location = new System.Drawing.Point(181, 44);
		this.lblStatusN2O.Name = "lblStatusN2O";
		this.lblStatusN2O.Size = new System.Drawing.Size(42, 24);
		this.lblStatusN2O.TabIndex = 80;
		this.lblStatusN2O.Text = "N2O";
		this.lblStatusN2O.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		//
		//lblStatusAir
		//
		this.lblStatusAir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblStatusAir.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblStatusAir.Location = new System.Drawing.Point(138, 44);
		this.lblStatusAir.Name = "lblStatusAir";
		this.lblStatusAir.Size = new System.Drawing.Size(42, 24);
		this.lblStatusAir.TabIndex = 79;
		this.lblStatusAir.Text = "AIR";
		this.lblStatusAir.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		//
		//lblPressureFuel
		//
		this.lblPressureFuel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblPressureFuel.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblPressureFuel.Location = new System.Drawing.Point(89, 44);
		this.lblPressureFuel.Name = "lblPressureFuel";
		this.lblPressureFuel.Size = new System.Drawing.Size(43, 24);
		this.lblPressureFuel.TabIndex = 78;
		this.lblPressureFuel.Text = "FUEL";
		this.lblPressureFuel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		//
		//lblPressureN2O
		//
		this.lblPressureN2O.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblPressureN2O.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblPressureN2O.Location = new System.Drawing.Point(46, 44);
		this.lblPressureN2O.Name = "lblPressureN2O";
		this.lblPressureN2O.Size = new System.Drawing.Size(42, 24);
		this.lblPressureN2O.TabIndex = 77;
		this.lblPressureN2O.Text = "N2O";
		this.lblPressureN2O.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		//
		//lblPressureAir
		//
		this.lblPressureAir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblPressureAir.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblPressureAir.Location = new System.Drawing.Point(3, 44);
		this.lblPressureAir.Name = "lblPressureAir";
		this.lblPressureAir.Size = new System.Drawing.Size(42, 24);
		this.lblPressureAir.TabIndex = 76;
		this.lblPressureAir.Text = "AIR";
		this.lblPressureAir.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		//
		//lblFlame
		//
		this.lblFlame.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblFlame.Location = new System.Drawing.Point(528, 8);
		this.lblFlame.Name = "lblFlame";
		this.lblFlame.Size = new System.Drawing.Size(104, 32);
		this.lblFlame.TabIndex = 75;
		this.lblFlame.Text = "FLAME";
		this.lblFlame.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
		//
		//lblSafetyControls
		//
		this.lblSafetyControls.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblSafetyControls.Location = new System.Drawing.Point(424, 8);
		this.lblSafetyControls.Name = "lblSafetyControls";
		this.lblSafetyControls.Size = new System.Drawing.Size(84, 32);
		this.lblSafetyControls.TabIndex = 74;
		this.lblSafetyControls.Text = "SAFETY CONTROLS";
		this.lblSafetyControls.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
		//
		//lblBurner
		//
		this.lblBurner.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblBurner.Location = new System.Drawing.Point(272, 8);
		this.lblBurner.Name = "lblBurner";
		this.lblBurner.Size = new System.Drawing.Size(135, 32);
		this.lblBurner.TabIndex = 73;
		this.lblBurner.Text = "BURNER";
		this.lblBurner.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
		//
		//lblPressureValveStatus
		//
		this.lblPressureValveStatus.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblPressureValveStatus.Location = new System.Drawing.Point(144, 8);
		this.lblPressureValveStatus.Name = "lblPressureValveStatus";
		this.lblPressureValveStatus.Size = new System.Drawing.Size(110, 32);
		this.lblPressureValveStatus.TabIndex = 72;
		this.lblPressureValveStatus.Text = "PRESSURE VALVE STATUS";
		this.lblPressureValveStatus.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
		//
		//lblPressures
		//
		this.lblPressures.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblPressures.Location = new System.Drawing.Point(8, 8);
		this.lblPressures.Name = "lblPressures";
		this.lblPressures.Size = new System.Drawing.Size(110, 32);
		this.lblPressures.TabIndex = 71;
		this.lblPressures.Text = "PRESSURES";
		this.lblPressures.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
		//
		//Label7
		//
		this.Label7.BackColor = System.Drawing.SystemColors.Control;
		this.Label7.Location = new System.Drawing.Point(415, 0);
		this.Label7.Name = "Label7";
		this.Label7.Size = new System.Drawing.Size(2, 104);
		this.Label7.TabIndex = 70;
		this.Label7.Text = "Label7";
		//
		//Label6
		//
		this.Label6.BackColor = System.Drawing.SystemColors.Control;
		this.Label6.Location = new System.Drawing.Point(523, 0);
		this.Label6.Name = "Label6";
		this.Label6.Size = new System.Drawing.Size(2, 104);
		this.Label6.TabIndex = 69;
		this.Label6.Text = "Label6";
		//
		//Label5
		//
		this.Label5.BackColor = System.Drawing.SystemColors.Control;
		this.Label5.Location = new System.Drawing.Point(268, 0);
		this.Label5.Name = "Label5";
		this.Label5.Size = new System.Drawing.Size(2, 104);
		this.Label5.TabIndex = 68;
		this.Label5.Text = "Label5";
		//
		//Label4
		//
		this.Label4.BackColor = System.Drawing.SystemColors.Control;
		this.Label4.Location = new System.Drawing.Point(134, 0);
		this.Label4.Name = "Label4";
		this.Label4.Size = new System.Drawing.Size(2, 104);
		this.Label4.TabIndex = 67;
		this.Label4.Text = "Label4";
		//
		//Label8
		//
		this.Label8.BackColor = System.Drawing.SystemColors.Control;
		this.Label8.Location = new System.Drawing.Point(0, 40);
		this.Label8.Name = "Label8";
		this.Label8.Size = new System.Drawing.Size(700, 2);
		this.Label8.TabIndex = 66;
		//
		//btnNAFLAME
		//
		this.btnNAFLAME.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnNAFLAME.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnNAFLAME.Image = (System.Drawing.Image)resources.GetObject("btnNAFLAME.Image");
		this.btnNAFLAME.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnNAFLAME.Location = new System.Drawing.Point(61, 200);
		this.btnNAFLAME.Name = "btnNAFLAME";
		this.btnNAFLAME.Size = new System.Drawing.Size(123, 38);
		this.btnNAFLAME.TabIndex = 8;
		this.btnNAFLAME.Text = "&NA FLAME";
		this.btnNAFLAME.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//btnAAFLAME
		//
		this.btnAAFLAME.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnAAFLAME.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnAAFLAME.Image = (System.Drawing.Image)resources.GetObject("btnAAFLAME.Image");
		this.btnAAFLAME.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnAAFLAME.Location = new System.Drawing.Point(61, 144);
		this.btnAAFLAME.Name = "btnAAFLAME";
		this.btnAAFLAME.Size = new System.Drawing.Size(123, 38);
		this.btnAAFLAME.TabIndex = 7;
		this.btnAAFLAME.Text = "&AA FLAME";
		this.btnAAFLAME.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//btnSetMaxBurnerHeight
		//
		this.btnSetMaxBurnerHeight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnSetMaxBurnerHeight.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnSetMaxBurnerHeight.Image = (System.Drawing.Image)resources.GetObject("btnSetMaxBurnerHeight.Image");
		this.btnSetMaxBurnerHeight.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnSetMaxBurnerHeight.Location = new System.Drawing.Point(504, 195);
		this.btnSetMaxBurnerHeight.Name = "btnSetMaxBurnerHeight";
		this.btnSetMaxBurnerHeight.Size = new System.Drawing.Size(110, 38);
		this.btnSetMaxBurnerHeight.TabIndex = 5;
		this.btnSetMaxBurnerHeight.Text = "Set Max. &Burner Ht.";
		this.btnSetMaxBurnerHeight.TextAlign = System.Drawing.ContentAlignment.TopLeft;
		//
		//btnSetMaxFuel
		//
		this.btnSetMaxFuel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnSetMaxFuel.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnSetMaxFuel.Image = (System.Drawing.Image)resources.GetObject("btnSetMaxFuel.Image");
		this.btnSetMaxFuel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnSetMaxFuel.Location = new System.Drawing.Point(504, 150);
		this.btnSetMaxFuel.Name = "btnSetMaxFuel";
		this.btnSetMaxFuel.Size = new System.Drawing.Size(110, 38);
		this.btnSetMaxFuel.TabIndex = 2;
		this.btnSetMaxFuel.Text = "Set Max. &Fuel";
		this.btnSetMaxFuel.TextAlign = System.Drawing.ContentAlignment.TopLeft;
		//
		//btnIncreaseBurnerHeight
		//
		this.btnIncreaseBurnerHeight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnIncreaseBurnerHeight.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnIncreaseBurnerHeight.Image = (System.Drawing.Image)resources.GetObject("btnIncreaseBurnerHeight.Image");
		this.btnIncreaseBurnerHeight.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnIncreaseBurnerHeight.Location = new System.Drawing.Point(248, 195);
		this.btnIncreaseBurnerHeight.Name = "btnIncreaseBurnerHeight";
		this.btnIncreaseBurnerHeight.Size = new System.Drawing.Size(110, 38);
		this.btnIncreaseBurnerHeight.TabIndex = 3;
		this.btnIncreaseBurnerHeight.Text = "Increase Burner H&t.";
		this.btnIncreaseBurnerHeight.TextAlign = System.Drawing.ContentAlignment.TopLeft;
		//
		//btnDecreaseBurnerHeight
		//
		this.btnDecreaseBurnerHeight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnDecreaseBurnerHeight.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnDecreaseBurnerHeight.Image = (System.Drawing.Image)resources.GetObject("btnDecreaseBurnerHeight.Image");
		this.btnDecreaseBurnerHeight.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnDecreaseBurnerHeight.Location = new System.Drawing.Point(376, 195);
		this.btnDecreaseBurnerHeight.Name = "btnDecreaseBurnerHeight";
		this.btnDecreaseBurnerHeight.Size = new System.Drawing.Size(110, 38);
		this.btnDecreaseBurnerHeight.TabIndex = 4;
		this.btnDecreaseBurnerHeight.Text = "Decrease Burner &Ht.";
		this.btnDecreaseBurnerHeight.TextAlign = System.Drawing.ContentAlignment.TopLeft;
		//
		//btnDecreaseFuel
		//
		this.btnDecreaseFuel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnDecreaseFuel.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnDecreaseFuel.Image = (System.Drawing.Image)resources.GetObject("btnDecreaseFuel.Image");
		this.btnDecreaseFuel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnDecreaseFuel.Location = new System.Drawing.Point(376, 150);
		this.btnDecreaseFuel.Name = "btnDecreaseFuel";
		this.btnDecreaseFuel.Size = new System.Drawing.Size(110, 38);
		this.btnDecreaseFuel.TabIndex = 1;
		this.btnDecreaseFuel.Text = "Decrea&se Fuel";
		this.btnDecreaseFuel.TextAlign = System.Drawing.ContentAlignment.TopLeft;
		//
		//btnIncreaseFuel
		//
		this.btnIncreaseFuel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnIncreaseFuel.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnIncreaseFuel.Image = (System.Drawing.Image)resources.GetObject("btnIncreaseFuel.Image");
		this.btnIncreaseFuel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnIncreaseFuel.Location = new System.Drawing.Point(248, 150);
		this.btnIncreaseFuel.Name = "btnIncreaseFuel";
		this.btnIncreaseFuel.Size = new System.Drawing.Size(110, 38);
		this.btnIncreaseFuel.TabIndex = 0;
		this.btnIncreaseFuel.Text = "Increse      F&uel";
		this.btnIncreaseFuel.TextAlign = System.Drawing.ContentAlignment.TopLeft;
		//
		//Label2
		//
		this.Label2.BackColor = System.Drawing.Color.Black;
		this.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
		this.Label2.Location = new System.Drawing.Point(235, 99);
		this.Label2.Name = "Label2";
		this.Label2.Size = new System.Drawing.Size(2, 188);
		this.Label2.TabIndex = 1;
		this.Label2.Text = "Label2";
		//
		//frmAutoIgnition
		//
		this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
		this.ClientSize = new System.Drawing.Size(634, 287);
		this.Controls.Add(this.CustomPanel1);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		this.MaximizeBox = false;
		this.MinimizeBox = false;
		this.Name = "frmAutoIgnition";
		this.ShowInTaskbar = false;
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "AUTO IGNITION";
		this.CustomPanel1.ResumeLayout(false);
		this.ResumeLayout(false);

	}

	#End Region

	#Region "Variables"
	private BgThread.clsBgThread mobjController = new BgThread.clsBgThread(this);

	private ClsBgManualIgnition mobjclsBgAutoIgnition;

	private bool mblnN2OPresure = false;
	bool blnPressureSensor1 = true;
	bool blnPressureSensor2 = true;
	bool blnPressureSensor3 = true;
	bool blnBurner = false;
	bool aa;
	bool ps1;
	bool ps2;
	bool ps3;
	bool air;
	bool n2;
	bool fuel;
	bool BIgnite;
	bool ato = true;
	int k;
	byte data;
	bool flag;
	bool aaft = false;
	bool n2oft = false;
	bool posted = false;
	Threading.Thread mobjThread;
	int count;
	private bool mblnExitBackGround = false;

	private bool mblnAvoidPorcess = false;
	private bool mblnInProcess = false;
	private bool mblnIgnitionWait = false;
	private bool mblnIgnitionTerminate = false;
	private int mintIgniteType;
	//Private mblnAvoidProcessing As Boolean
	private int intFlameType;

	private bool mblnIsfrmFlameStatusWork;
	#End Region

	#Region "Constants"

	#End Region

	#Region "Properties"

	#End Region

	#Region " Form Events"

	private void  // ERROR: Handles clauses are not supported in C#
frmAutoIgnition_Load(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : frmAutoIgnition_Load
		// Parameters Passed     : Object, EventArgs
		// Returns               : 
		// Purpose               : To load the Auto Ignition form. 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 07-02-2007
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		try {
			//Call funcInitialise()
			btnAAFLAME.Focus();

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

		//        void 	S4FUNC Auto_Init(HWND hpar)
		//   {
		//       int     	k; //,i;
		//       BYTE    	data;
		//       HWND 		hwnd,hwnd1;
		//       MSG		msg;
		//       BOOL    	flag=FALSE;
		//       DLGPROC 	skp ;
		//       DWORD		w1,w2;
		//       BOOL 		ato=TRUE,aaft=OFF, n2oft=OFF, posted=FALSE;
		//       HDC 		hdc;

		//       // hwnd1 = Create_Window_Pneum(NULL,"AA-203  AA FLAME");
		//       If (!Commflag) Then
		//	        return;
		//       if(GetInstrument()==AA202)
		//	        hwnd1 = Create_Window_Pneum("AA-202  AA FLAME");
		//       Else
		//	        hwnd1 = Create_Window_Pneum("AA-203  AA FLAME");
		//       StHwnd=hwnd1;
		//       skp = (DLGPROC) MakeProcInstance((FARPROC) ManualProc, hInst);
		//       hwnd = CreateDialog(hInst, "AUTO", NULL, skp);
		//       if (hwnd!=NULL)
		//       {
		//	        EnableWindow(hpar, FALSE);	 	
		//           ShowWindow(hwnd, SW_SHOW);
		//	        UpdateWindow(hwnd); 
		//           WP1=-1;		
		//           hdc = GetDC(hwnd);
		//	        SetBkColor(hdc, RGB(192,192,192));
		//	        aa =  OFF;
		//	        ps1= ps2= ps3 = ON;
		//	        data = CHECK_BUR_PAR();
		//	        if (data & AA_CONNECTED) 
		//               aa = ON;
		//	        else 
		//               aa=OFF;
		//	        data  = CHECK_PS();
		//	        if (data & AIR_NOK)  
		//               ps1 = OFF;
		//	        if (data & N2O_NOK)  
		//               ps2 = OFF;
		//	        if (data & FUEL_NOK) 
		//           {
		//               ato = OFF; 
		//               ps3 = OFF;
		//           }
		//	        if (ps1==OFF) 
		//               ato = OFF;
		//	        if (ps3==OFF) 
		//               ato = OFF;
		//	        if (aa!=ON && ps2==OFF) 
		//               ato = OFF;
		//	        w1 = GetTickCount();
		//	        Auto_Init_Check(&ato);
		//	        while(1)
		//           {
		//		        w2 = GetTickCount();
		//		        if ((w2-w1) > (DWORD) 200)
		//               {
		//		            w1=w2;
		//		            Status_Disp();
		//		        }
		//		        Auto_Init_Check(&ato);
		//               if (!ato)
		//                   if (!posted)
		//                   {
		//                       PostMessage(hwnd, WM_COMMAND, IDOK, 0L);
		//                       posted=TRUE;
		//                   }
		//		        if (flag|| Inst.Aaf!=aaft || Inst.N2of!=n2oft)
		//               {
		//		            ShowWindow(GetDlgItem(hwnd, IDC_BTN2),SW_SHOW);
		//		            ShowWindow(GetDlgItem(hwnd, IDC_BTN2),SW_SHOW);
		//		            flag = FALSE;
		//		            aaft = Inst.Aaf; 
		//                   n2oft=Inst.N2of;
		//		            if (Inst.Aaf) 
		//                   {
		//			            SetWindowText(GetDlgItem(hwnd, IDC_STATUS), "AA -FLAME");
		//			            SetWindowText(GetDlgItem(hwnd, IDC_BTN1), "EXTINGUISH AA");
		//			            ShowWindow(GetDlgItem(hwnd, IDC_BTN2),SW_HIDE);
		//			        }
		//		            else if (Inst.N2of)	
		//                   {
		//			            SetWindowText(GetDlgItem(hwnd, IDC_STATUS), "NA -FLAME");
		//			            SetWindowText(GetDlgItem(hwnd, IDC_BTN1), "EXTINGUISH NA");
		//			            ShowWindow(GetDlgItem(hwnd, IDC_BTN2),SW_HIDE);
		//			        }
		//		            else 
		//                   {
		//			            SetWindowText(GetDlgItem(hwnd, IDC_STATUS), "READY FOR IGNITION");
		//                       if (!aa) 
		//				            SetWindowText(GetDlgItem(hwnd, IDC_BTN2), "NA FLAME");
		//                       else
		//				            ShowWindow(GetDlgItem(hwnd, IDC_BTN2),SW_HIDE);
		//			            SetWindowText(GetDlgItem(hwnd, IDC_BTN1), "AA FLAME");
		//		    	    }
		//			    UpdateWindow(hwnd);
		//		    }
		//           if (CheckMsg(hwnd, &msg))
		//           {
		//		        flag = TRUE;
		//		        switch(WP1)
		//               {
		//			         case  IDC_BTN1:if (Inst.Aaf)  Inst.Aaf=AA_FLAME_OFF();
		//								 else if (Inst.N2of ) Inst.N2of=N2_FLAME_OFF();
		//								 else	Inst.Aaf = AA_FLAME_ON();
		//								 Beep(); break;
		//			 case  IDC_BTN2:	if (!Inst.N2of ) Inst.N2of=N2_FLAME_ON();
		//									else{ if(GetInstrument() == AA202)
		//												Gerror_message_new("Sorry already in NA Flame", "AA-202 PNEUM");
		//											else
		//												Gerror_message_new("Sorry already in NA Flame", "AA-203 PNEUM");}
		//									break;
		//			case IDC_INCRF:  Incr_Fuel();
		//								  Wprintf(hdc, 10, 70, "%3.2f    ", (double)Inst.Nvstep/(double)NVRED);break;
		//			case IDC_DFUEL:  Decr_Fuel();
		//								  Wprintf(hdc, 10, 70, "%3.2f     ", (double)Inst.Nvstep/(double) NVRED); break;
		//			case IDC_INCRH : Incr_Height(); break;
		//			case IDC_DECRH : Decr_Height(); break;
		//			case IDC_FUEL  : if (NV_HOME()) Inst.Nvstep=0;
		//								  else Inst.Nvstep = -1;break;
		//			case IDC_BUR:   if(BH_HOME()) Inst.Bhstep =0;
		//								 else Inst.Bhstep=-1; break;
		//			}
		//		  if (WP1==IDOK){
		//			 WP1=-1;
		//			 for(k=0; k<10;k++)
		//				 CheckMsg(hpar, &msg);
		//			 EnableWindow(hpar, TRUE);
		//			 ReleaseDC(hwnd, hdc);
		//			 DestroyWindow(hwnd);
		//			 UpdateWindow(hpar);
		//			 break;
		//		  }
		//		  WP1=-1;
		//		}
		//	 }
		//  }
		// FreeProcInstance((FARPROC)skp);
		// Close_Window(hwnd1, NULL);
		// StHwnd=NULL;
		//}

	}

	//Private Sub frmAutoIgnition_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
	//    'objThread.Abort()
	//    mblnExitBackGround = True
	//    'objThread.Abort()
	//    'objThread.Join()
	//    Application.DoEvents()
	//    If mblnAvoidPorcess = True Then
	//        Exit Sub
	//    End If
	//    Me.DialogResult = DialogResult.Cancel
	//    Me.Close()
	//End Sub

	#End Region

	#Region " Private Functions"

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
			btnAAFLAME.Click += btnAAFLAME_Click;
			btnNAFLAME.Click += btnNAFLAME_Click;
			btnClose.Click += btnClose_Click;
			//AddHandler btnIgnite.Click, AddressOf btnIgnite_Click
			//AddHandler btnAirOnOff.Click, AddressOf btnAirOnOff_Click
			btnSetMaxFuel.Click += btnSetMaxFuel_Click;
			btnDecreaseFuel.Click += btnDecreaseFuel_Click;
			btnIncreaseFuel.Click += btnIncreaseFuel_Click;
			btnSetMaxBurnerHeight.Click += btnSetMaxBurnerHeight_Click;
			btnDecreaseBurnerHeight.Click += btnDecreaseBurnerHeight_Click;
			btnIncreaseBurnerHeight.Click += btnIncreaseBurnerHeight_Click;
		//AddHandler tmrCheckManualIgnite.Elapsed, AddressOf tmrCheckManualIgnite_Elapsed

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

	private bool funcInitialise()
	{
		//=====================================================================
		// Procedure Name        : funcInitialise
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : To initialise the form 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 16.02.07
		// Revisions             : 
		//=====================================================================
		try {
			if (!IsNothing(gobjMain)) {
				//If Not IsNothing(gobjMain.mobjfrmAnalysis) Then gobjMain.mobjfrmAnalysis.tmrAspirationMsg.Enabled = False
				if (gobjMain.mobjController.IsThreadRunning == true) {
					mblnIsfrmFlameStatusWork = true;
					gobjMain.mobjController.Cancel();
					gobjCommProtocol.mobjCommdll.subTime_Delay(500);
					//10.12.07
					Application.DoEvents();
				}
				Application.DoEvents();
			}
			AddHandlers();
			if (funcAuto_Init() == false) {
				return false;
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
			//Application.DoEvents()
			//'mblnExitBackGround = True
			//'objThread.Join()
			//'objThread.Abort()
			//Me.DialogResult = DialogResult.Cancel
			//Me.Close()
			//Application.DoEvents()
			if (mblnIgnitionTerminate == false) {
				//    Call subStopScan()
				mobjclsBgAutoIgnition.ThTerminate = true;
				mobjclsBgAutoIgnition.IgnitionWait = true;
				mblnIgnitionWait = true;
				Application.DoEvents();
				//Call btnClose_Click(sender, e)
				return;
			} else {
				if (!(mobjController == null)) {
					if (mobjController.IsThreadRunning) {
						mobjclsBgAutoIgnition.ThTerminate = true;
						mobjclsBgAutoIgnition.IgnitionWait = true;
						mblnIgnitionWait = true;
						mobjController.Cancel();
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
			//---------------------------------------------------------
		}
	}

	private bool Auto_Init_Check(ref bool ato)
	{
		//=====================================================================
		// Procedure Name        : Auto_Init_Check
		// Parameters Passed     : ato as Boolean
		// Returns               : True or False
		// Purpose               : To check the necessary conditions required 
		//                       : for auto ignition.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 07-02-2007
		// Revisions             : 
		//=====================================================================
		//        void(Auto_Init_Check(BOOL * ato))
		//{
		//BYTE data;

		// ps1 = ps2 = ps3 = aa = ON;
		// data = CHECK_BUR_PAR();
		// if (data & AA_CONNECTED) aa = ON;
		// else aa = OFF;
		// data  = CHECK_PS();
		// if (data & AIR_NOK)  {
		//	ps1 = OFF;
		//	if (Inst.Aaf) {
		//	  Inst.Aaf=AA_FLAME_OFF();
		//	  if(GetInstrument() == AA202)
		//		  Gerror_message_new("Low Air Pressure..", "AA-202 PNEUM");
		//                    Else
		//		  Gerror_message_new("Low Air Pressure..", "AA-203 PNEUM");
		//	 }
		//  }
		// if (data & N2O_NOK)  {
		//	ps2 = OFF;
		//	if (Inst.N2of) {
		//	  Inst.N2of=N2_FLAME_OFF();
		//	  if( GetInstrument() == AA202 )
		//		  Gerror_message_new("Low N2O Pressure..", "AA-202 PNEUM");
		//                                Else
		//		  Gerror_message_new("Low N2O Pressure..", "AA-203 PNEUM");
		//	 }
		//  }
		// if (data & FUEL_NOK) {
		//	*ato = OFF; ps3 = OFF;
		//	if(GetInstrument() == AA202)
		//		Gerror_message_new("Low Fuel Pressure..", "AA-202 PNEUM");
		//                                        Else
		//		Gerror_message_new("Low Fuel Pressure..", "AA-203 PNEUM");
		//  }
		// if (aa==ON && ps1==OFF) *ato = OFF;
		// if (aa!=ON && ps2==OFF) *ato = OFF;
		//}
		////------------------------------
		byte BData;

		try {
			//If Not IsNothing(mobjThread) Then
			//    If Not mobjThread.IsAlive Then
			//        Exit Function
			//    End If
			//End If

			Status_Disp();
			aa = true;
			// To check for AA burner parameter status
			ps1 = true;
			// To check for Air pressure 
			ps2 = true;
			// To check for N2O pressure 
			ps3 = true;
			// To check for Fuel pressure 

			gobjCommProtocol.mobjCommdll.subTime_Delay(20);
			if (mblnIgnitionWait == false) {
				if (gobjCommProtocol.funcCheckBurnerParameters(BData) == false) {
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
			gobjCommProtocol.mobjCommdll.subTime_Delay(20);
			if (mblnIgnitionWait == false) {
				if (gobjCommProtocol.funcPressSensorStatus(BData, false) == false) {
					return;
				}
			} else {
				return;
			}
			if ((BData & EnumErrorStatus.AIR_NOK)) {
				ps1 = false;
				if ((gobjInst.Aaf)) {
					gobjCommProtocol.mobjCommdll.subTime_Delay(20);
					if (mblnIgnitionWait == false) {
						if (gobjCommProtocol.func_AA_FLAME_OFF == true) {
							gobjInst.Aaf = false;
						}
						gobjMessageAdapter.ShowMessage(constLowAirPressure);
					} else {
						return;
					}
					//MsgBox("Low Air Pressure")
				}
			}
			if ((BData & EnumErrorStatus.N2O_NOK)) {
				ps2 = false;
				if ((gobjInst.N2of)) {
					gobjCommProtocol.mobjCommdll.subTime_Delay(20);
					if (mblnIgnitionWait == false) {
						if (gobjCommProtocol.func_N2_FLAME_OFF() == false) {
							gobjInst.N2of = false;
						}
					}
					gobjMessageAdapter.ShowMessage(constLowN2OPressure);
					return;
					//gobjMessageAdapter.ShowMessage(constLowN2OPressure)
					//MsgBox("Low N2O Pressure")
				}
			}

			if ((BData & EnumErrorStatus.FUEL_NOK)) {
				ato = false;
				ps3 = false;
				if (count < 4) {
					gobjMessageAdapter.ShowMessage(constLowFuelPressure);
					//MsgBox("Low fuel Pressure")
					count += 1;
				} else {
					//Me.Close()
					btnClose_Click(btnClose, System.EventArgs.Empty);
				}
			} else {
				//count = 0
			}

			if ((aa == false & ps1 == false)) {
				ato = false;
			}

			if ((!aa == true & ps2 == false)) {
				ato = false;
			}
			return true;

		//Catch threadex As Threading.ThreadAbortException

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
			//objWait.Dispose()
			//---------------------------------------------------------
		}



		//   void(Auto_Init_Check(BOOL * ato))
		//   {
		//       BYTE data;

		//       ps1 = ps2 = ps3 = aa = ON;
		//       data = CHECK_BUR_PAR();
		//       if (data & AA_CONNECTED) 
		//           aa = ON;
		//       else 
		//           aa = OFF;
		//       data  = CHECK_PS();
		//       if (data & AIR_NOK)     
		//           {
		//	            ps1 = OFF;
		//	            if (Inst.Aaf) 
		//               {
		//	                Inst.Aaf=AA_FLAME_OFF();
		//	                if(GetInstrument() == AA202)
		//		                Gerror_message_new("Low Air Pressure..", "AA-202 PNEUM");
		//                   Else
		//                       Gerror_message_new("Low Air Pressure..", "AA-203 PNEUM");
		//	            }
		//           }
		//       if (data & N2O_NOK)  
		//       {
		//	        ps2 = OFF;
		//	        if (Inst.N2of) 
		//           {
		//	            Inst.N2of=N2_FLAME_OFF();
		//	            if( GetInstrument() == AA202 )
		//		            Gerror_message_new("Low N2O Pressure..", "AA-202 PNEUM");
		//               Else
		//		            Gerror_message_new("Low N2O Pressure..", "AA-203 PNEUM");
		//	        }
		//       }
		//       if (data & FUEL_NOK) 
		//       {
		//	        *ato = OFF; ps3 = OFF;
		//	        if(GetInstrument() == AA202)
		//		        Gerror_message_new("Low Fuel Pressure..", "AA-202 PNEUM");
		//           Else
		//		        Gerror_message_new("Low Fuel Pressure..", "AA-203 PNEUM");
		//       }
		//       if (aa==ON && ps1==OFF) 
		//           *ato = OFF;
		//       if (aa!=ON && ps2==OFF) 
		//           *ato = OFF;
		//   }

	}

	public bool Status_Disp()
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
		//***************************************************************
		//void(Status_Disp())
		//{
		//	char  line1[80];
		//	BYTE  status,st, st1;
		//	BOOL	flag=TRUE;

		//   If (!Commflag) Then
		//		return;
		//   If (StHwnd! = NULL) Then
		//	{
		//		status = GET_PNEUM_STATUS();
		//		//st=random(255); st1=random(255);
		//		st = CHECK_PS();
		//		st1 = CHECK_BUR_PAR();
		//		if (st & AIR_NOK)	 		{  flag=FALSE; SetVal(IDC_PAIR, "ERROR");}
		//		else 	SetVal(IDC_PAIR, "OK");
		//		if (st & N2O_NOK)	 		{  flag=FALSE; SetVal(IDC_PN2O, "ERROR");}
		//		else 	SetVal(IDC_PN2O, "OK");
		//		if (st & FUEL_NOK)	 		{  flag=FALSE; SetVal(IDC_PFUEL, "ERROR");}
		//		else 	SetVal(IDC_PFUEL, "OK");
		//                            If (status & SAIR_NON) Then
		//		{
		//			flag=FALSE; SetVal(IDC_PVAIR,"CLOSE");
		//		}
		//		else	SetVal(IDC_PVAIR,"OPEN");
		//		if (status & SN2O_ON)	 	SetVal(IDC_PVN2O, "OPEN");
		//		else	{  flag=FALSE; SetVal(IDC_PVN2O, "CLOSE");}
		//		if (status & SFUEL_ON)	SetVal(IDC_PVFUEL, "OPEN");
		//		else	{  flag=FALSE; SetVal(IDC_PVFUEL, "CLOSE");}
		//		if (st1 & AA_CONNECTED) 	SetVal(IDC_BTYPE, "BTAA");
		//		else 	SetVal(IDC_BTYPE, "BTNA");
		//		if (st1 & TRAP_NOK) {  flag=FALSE; SetVal(IDC_TRAP, "TOPEN");}
		//		else SetVal(IDC_TRAP, "OK");
		//		if (st1 &DOOR_NOK) {  flag=FALSE; SetVal(IDC_DTYPE, "DOPEN");}
		//		else SetVal(IDC_DTYPE, "DCLOSE");
		//		if ((st&YELLOW_OK) ==YELLOW_OK) 		SetVal(IDC_FLAME, "YELLOW");
		//		else if ((st&BLUE_OK)==BLUE_OK)  	SetVal(IDC_FLAME, "BLUE");
		//		else if ((st & FLAME_OK)==FLAME_OK) 	SetVal(IDC_FLAME, "BYELLOW");
		//		else if (flag)	SetVal(IDC_FLAME, "GREEN");
		//		else SetVal(IDC_FLAME, "RED");
		//		Get_NV_Pos();
		//		sprintf(line1,"%3.2f", Read_Fuel());	// Nv pos
		//		SetWindowText(GetDlgItem(StHwnd, IDC_FR),line1);
		//		Get_BH_Pos();
		//		sprintf(line1,"%2.1f", ReadBurnerHeight());
		//		SetWindowText(GetDlgItem(StHwnd, IDC_BH),line1);
		//		UpdateWindow (StHwnd) ;
		//	}
		//}
		//***************************************************************
		string line1;
		byte status;
		byte st;
		byte st1;
		bool flag = true;

		try {
			//If Not IsNothing(mobjThread) Then
			//    If Not mobjThread.IsAlive Then
			//        Exit Function
			//    End If
			//End If
			gobjCommProtocol.mobjCommdll.subTime_Delay(20);
			if (mblnIgnitionWait == false) {
				status = gobjCommProtocol.funcGet_Pneum_Status();
			} else {
				return;
			}
			gobjCommProtocol.mobjCommdll.subTime_Delay(20);
			if (mblnIgnitionWait == false) {
				gobjCommProtocol.funcPressSensorStatus(st, false);
			} else {
				return;
			}
			gobjCommProtocol.mobjCommdll.subTime_Delay(20);
			if (mblnIgnitionWait == false) {
				gobjCommProtocol.funcCheckBurnerParameters(st1);
			} else {
				return;
			}

			//----added by deepak b on 06.05.07 for flame status update
			//Dim intFlameType As Integer
			//If gstructSettings.AppMode = EnumAppMode.DemoMode Then
			//    intFlameType = ClsAAS203.enumIgniteType.Blue
			//Else
			//    intFlameType = gobjClsAAS203.funcIgnite_Test()
			//End If
			//gobjfrmStatus.FlameType = intFlameType
			//----added by deepak b on 06.05.07 for flame status update

			if ((st & EnumErrorStatus.AIR_NOK)) {
				flag = false;
				pbPressureAir.Image = Image.FromFile(Application.StartupPath + "\\" + "images\\ERROR.BMP");
			} else {
				pbPressureAir.Image = Image.FromFile(Application.StartupPath + "\\" + "images\\OK.BMP");
			}

			if ((st & EnumErrorStatus.N2O_NOK)) {
				flag = false;
				pbPressureN2O.Image = Image.FromFile(Application.StartupPath + "\\" + "images\\ERROR.BMP");
			} else {
				pbPressureN2O.Image = Image.FromFile(Application.StartupPath + "\\" + "images\\OK.BMP");
			}

			if ((st & EnumErrorStatus.FUEL_NOK)) {
				flag = false;
				pbPressureFuel.Image = Image.FromFile(Application.StartupPath + "\\" + "images\\ERROR.BMP");
			} else {
				pbPressureFuel.Image = Image.FromFile(Application.StartupPath + "\\" + "images\\OK.BMP");
			}

			if ((status & EnumErrorStatus.SAIR_NON)) {
				flag = false;
				pbStatusAir.Image = Image.FromFile(Application.StartupPath + "\\" + "images\\close.BMP");
			} else {
				pbStatusAir.Image = Image.FromFile(Application.StartupPath + "\\" + "images\\open.BMP");
			}

			if ((status & EnumErrorStatus.SN2O_NON)) {
				pbStatusN2O.Image = Image.FromFile(Application.StartupPath + "\\" + "images\\open.BMP");
			} else {
				flag = false;
				pbStatusN2O.Image = Image.FromFile(Application.StartupPath + "\\" + "images\\close.BMP");
			}

			if ((status & EnumErrorStatus.SFUEL_ON)) {
				pbStatusFuel.Image = Image.FromFile(Application.StartupPath + "\\" + "images\\open.BMP");
			} else {
				flag = false;
				pbStatusFuel.Image = Image.FromFile(Application.StartupPath + "\\" + "images\\close.BMP");
			}

			if ((st1 & EnumErrorStatus.AA_CONNECTED)) {
				pbBurnerType.Image = Image.FromFile(Application.StartupPath + "\\" + "images\\BTAA.bmp");
			} else {
				pbBurnerType.Image = Image.FromFile(Application.StartupPath + "\\" + "images\\BTNA.bmp");
			}

			if ((st1 & EnumErrorStatus.TRAP_NOK)) {
				flag = false;
				pbSafetyControlsTrap.Image = Image.FromFile(Application.StartupPath + "\\" + "images\\topen.bmp");
			} else {
				pbSafetyControlsTrap.Image = Image.FromFile(Application.StartupPath + "\\" + "images\\OK.BMP");
			}

			if ((st1 & EnumErrorStatus.DOOR_NOK)) {
				flag = false;
				pbSafetyControlsDoor.Image = Image.FromFile(Application.StartupPath + "\\" + "images\\DOPEN.bmp");
			} else {
				pbSafetyControlsDoor.Image = Image.FromFile(Application.StartupPath + "\\" + "images\\DCLOSE.bmp");
			}

			if ((st & EnumErrorStatus.YELLOW_OK) == EnumErrorStatus.YELLOW_OK) {
				pbFlameType.Image = Image.FromFile(Application.StartupPath + "\\" + "images\\YELLOW.BMP");

			} else if ((st & EnumErrorStatus.BLUE_OK) == EnumErrorStatus.BLUE_OK) {
				pbFlameType.Image = Image.FromFile(Application.StartupPath + "\\" + "images\\BLUE.BMP");

			} else if ((st & EnumErrorStatus.FLAME_OK) == EnumErrorStatus.FLAME_OK) {
				pbFlameType.Image = Image.FromFile(Application.StartupPath + "\\" + "images\\BYELLOW.BMP");

			} else if (flag) {
				pbFlameType.Image = Image.FromFile(Application.StartupPath + "\\" + "images\\GREEN.BMP");
			} else {
				pbFlameType.Image = Image.FromFile(Application.StartupPath + "\\" + "images\\RED.BMP");
			}
			gobjCommProtocol.mobjCommdll.subTime_Delay(20);
			if (mblnIgnitionWait == false) {
				gobjCommProtocol.funcGet_NV_Pos();
				lblFRatio.Text = Format(gobjClsAAS203.funcRead_Fuel(), "0.00");
			} else {
				return;
			}
			gobjCommProtocol.mobjCommdll.subTime_Delay(20);
			if (mblnIgnitionWait == false) {
				gobjCommProtocol.func_Get_BH_Pos();
				//lblBHeight.Text = Format(gobjClsAAS203.funcReadBurnerHeight(), "0.00")
				lblBHeight.Text = Format(gobjClsAAS203.funcReadBurnerHeight(), "0.0");
			} else {
				return;
			}

			//lblNVStep.Text = "NV : " & gobjInst.NvStep & ""

			//Catch threadex As Threading.ThreadAbortException
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
			Application.DoEvents();
			//objWait.Dispose()
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
		if (mblnAvoidPorcess == true) {
			return;
		}
		CWaitCursor objWait = new CWaitCursor();
		try {
			//mobjThread.Suspend()
			mblnAvoidPorcess = true;
			mblnIgnitionWait = true;
			mobjclsBgAutoIgnition.IgnitionWait = true;

			gobjClsAAS203.funcDecr_Height();

			//Saurabh to set Bh step in the file "Bh.bhp" 11.07.07
			//Call gobjCommProtocol.funcSave_BH_Pos()
			//Saurabh

			//mobjThread.Resume()
			mblnAvoidPorcess = false;
			mblnIgnitionWait = false;
			mobjclsBgAutoIgnition.IgnitionWait = false;

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			//---------------------------------------------------------
			mblnAvoidPorcess = false;
			mblnIgnitionWait = false;
			mobjclsBgAutoIgnition.IgnitionWait = false;
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			//mblnAvoidPorcess = False
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
		if (mblnAvoidPorcess == true) {
			return;
		}
		CWaitCursor objWait = new CWaitCursor();
		try {
			mblnAvoidPorcess = true;
			mblnIgnitionWait = true;
			mobjclsBgAutoIgnition.IgnitionWait = true;

			//mobjThread.Suspend()
			gobjClsAAS203.funcSetFuel(gobjClsAAS203.funcRead_Fuel() - 0.1);
			lblNVStep1.Text = Format((double)gobjInst.NvStep / (double)NVSTEP, "000.00");
			//mobjThread.Resume()
			mblnAvoidPorcess = false;
			mblnIgnitionWait = false;
			mobjclsBgAutoIgnition.IgnitionWait = false;

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			//---------------------------------------------------------
			mblnAvoidPorcess = false;
			mblnIgnitionWait = false;
			mobjclsBgAutoIgnition.IgnitionWait = false;
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
		if (mblnAvoidPorcess == true) {
			return;
		}
		CWaitCursor objWait = new CWaitCursor();
		try {
			mblnAvoidPorcess = true;
			mblnIgnitionWait = true;
			mobjclsBgAutoIgnition.IgnitionWait = true;

			//mobjThread.Suspend()
			gobjClsAAS203.funcIncr_Height();

			//Saurabh to set Bh step in the file "Bh.bhp" 11.07.07
			//Call gobjCommProtocol.funcSave_BH_Pos()
			//Saurabh

			//mobjThread.Resume()
			mblnAvoidPorcess = false;
			mblnIgnitionWait = false;
			mobjclsBgAutoIgnition.IgnitionWait = false;

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			//---------------------------------------------------------
			mblnAvoidPorcess = false;
			mblnIgnitionWait = false;
			mobjclsBgAutoIgnition.IgnitionWait = false;
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
		if (mblnAvoidPorcess == true) {
			return;
		}
		CWaitCursor objWait = new CWaitCursor();
		try {
			mblnAvoidPorcess = true;
			mblnIgnitionWait = true;
			mobjclsBgAutoIgnition.IgnitionWait = true;

			//mobjThread.Suspend()
			gobjClsAAS203.funcSetFuel((gobjClsAAS203.funcRead_Fuel() + 0.1));
			lblNVStep1.Text = Format((double)gobjInst.NvStep / (double)NVSTEP, "#0.00");
			//mobjThread.Resume()
			mblnAvoidPorcess = false;
			mblnIgnitionWait = false;
			mobjclsBgAutoIgnition.IgnitionWait = false;
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			//---------------------------------------------------------
			mblnAvoidPorcess = false;
			mblnIgnitionWait = false;
			mobjclsBgAutoIgnition.IgnitionWait = false;
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
		if (mblnAvoidPorcess == true) {
			return;
		}
		CWaitCursor objWait = new CWaitCursor();
		try {
			//mobjThread.Suspend()
			mblnAvoidPorcess = true;
			mblnIgnitionWait = true;
			mobjclsBgAutoIgnition.IgnitionWait = true;
			if (gobjCommProtocol.funcSetBH_HOME()) {
				gobjInst.BhStep = 0;
			} else {
				gobjInst.BhStep = -1;
			}
			//mobjThread.Resume()
			mblnAvoidPorcess = false;
			mblnIgnitionWait = false;
			mobjclsBgAutoIgnition.IgnitionWait = false;

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			//---------------------------------------------------------
			mblnAvoidPorcess = false;
			mblnIgnitionWait = false;
			mobjclsBgAutoIgnition.IgnitionWait = false;
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
		if (mblnAvoidPorcess == true) {
			return;
		}
		CWaitCursor objWait = new CWaitCursor();
		try {
			//mobjThread.Suspend()
			mblnAvoidPorcess = true;
			mblnIgnitionWait = true;
			mobjclsBgAutoIgnition.IgnitionWait = true;
			if (gobjCommProtocol.funcSetNV_HOME()) {
				gobjInst.NvStep = 0;
			} else {
				gobjInst.NvStep = -1;
			}
			//mobjThread.Resume()
			mblnAvoidPorcess = false;
			mblnIgnitionWait = false;
			mobjclsBgAutoIgnition.IgnitionWait = false;

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			//---------------------------------------------------------
			mblnAvoidPorcess = false;
			mblnIgnitionWait = false;
			mobjclsBgAutoIgnition.IgnitionWait = false;
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

	////----- Commented by Sachin Dokhale
	//Private Sub subWorkInBackground()
	//    '=====================================================================
	//    ' Procedure Name        : subWorkInBackground
	//    ' Parameters Passed     : Object,EventArgs
	//    ' Returns               : None
	//    ' Purpose               : To run the Manual_Init_Check in a  continious 
	//    '                       : loop and in background.      
	//    ' Description           : 
	//    ' Assumptions           : 
	//    ' Dependencies          : 
	//    ' Author                : Saurabh S
	//    ' Created               : 02.02.07
	//    ' Revisions             : 
	//    '=====================================================================
	//    Try
	//        mblnAvoidPorcess = True
	//        While (True)
	//            If gblnInComm = False Then
	//                If mblnExitBackGround = True Then
	//                    mblnAvoidPorcess = False
	//                    mobjThread.Join()
	//                    mobjThread.Abort()
	//                    Exit While
	//                End If
	//                Threading.Thread.Sleep(400)
	//                Auto_Init_Check(ato)
	//                If Not ato Then
	//                    If Not posted Then
	//                        posted = True
	//                    End If
	//                End If
	//                If (flag Or (Not (gobjInst.Aaf = aaft)) Or (Not (gobjInst.N2of = n2oft))) Then
	//                    btnAAFLAME.Visible = True
	//                    btnNAFLAME.Visible = True

	//                    flag = False
	//                    aaft = gobjInst.Aaf
	//                    n2oft = gobjInst.N2of
	//                    If gobjInst.Aaf Then
	//                        lblStatus.Text = "AA - FLAME"
	//                        btnAAFLAME.Text = "EXTINGUISH &AA FLAME"

	//                        btnNAFLAME.Visible = False
	//                    ElseIf gobjInst.N2of Then
	//                        lblStatus.Text = "NA - FLAME"
	//                        btnNAFLAME.Text = "EXTINGUISH &NA FLAME"
	//                        btnNAFLAME.Visible = False
	//                    Else
	//                        lblStatus.Text = "READY FOR IGNITION"
	//                        If Not aa Then
	//                            btnNAFLAME.Text = "&NA - FLAME"
	//                        Else
	//                            btnNAFLAME.Visible = False
	//                        End If
	//                        btnAAFLAME.Text = "&AA - FLAME"
	//                    End If
	//                End If
	//            Else
	//                If Not ato Then
	//                    If Not posted Then
	//                        posted = True
	//                    End If
	//                End If
	//                If (flag Or (Not (gobjInst.Aaf = aaft)) Or (Not (gobjInst.N2of = n2oft))) Then
	//                    btnAAFLAME.Visible = True
	//                    btnNAFLAME.Visible = True

	//                    flag = False
	//                    aaft = gobjInst.Aaf
	//                    n2oft = gobjInst.N2of
	//                    If gobjInst.Aaf Then
	//                        lblStatus.Text = "AA - FLAME"
	//                        btnAAFLAME.Text = "EXTINGUISH &AA FLAME"
	//                        btnAAFLAME.TextAlign = ContentAlignment.TopLeft

	//                        btnNAFLAME.Visible = False
	//                    ElseIf gobjInst.N2of Then
	//                        lblStatus.Text = "NA - FLAME"
	//                        btnNAFLAME.Text = "EXTINGUISH &NA FLAME"
	//                        btnNAFLAME.TextAlign = ContentAlignment.TopLeft
	//                        btnNAFLAME.Visible = False
	//                    Else
	//                        lblStatus.Text = "READY FOR IGNITION"
	//                        If Not aa Then
	//                            btnNAFLAME.Text = "&NA - FLAME"
	//                        Else
	//                            btnNAFLAME.Visible = False
	//                        End If
	//                        btnAAFLAME.Text = "&AA - FLAME"
	//                    End If
	//                End If
	//            End If
	//            Application.DoEvents()
	//        End While

	//    Catch threadex As Threading.ThreadAbortException

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

	//End Sub

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
	////-----

	private void subWorkInBackground()
	{
		//=====================================================================
		// Procedure Name        : subWorkInBackground
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To run the Manual_Init_Check in a  continious 
		//                       : loop and in background.      
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 02.02.07
		// Revisions             : 
		//=====================================================================

		try {
			//While (True)
			//If gblnInComm = False Then
			//If mblnExitBackGround = True Then
			//    Exit Sub
			//End If
			if (mblnIgnitionWait == true) {
				return;
			}
			flag = true;
			if (Auto_Init_Check(ato) == false) {
				return;
			}
			if (!ato) {
				if (!posted) {
					posted = true;
				}
			}
			if ((flag | (!(gobjInst.Aaf == aaft)) | (!(gobjInst.N2of == n2oft)))) {
				//btnAAFLAME.Visible = True
				//btnNAFLAME.Visible = True

				flag = false;
				aaft = gobjInst.Aaf;
				n2oft = gobjInst.N2of;
				if (gobjInst.Aaf) {
					lblStatus.Text = "AA - FLAME";
					btnAAFLAME.Text = "EXTINGUISH &AA FLAME";
					btnNAFLAME.Visible = false;
					btnAAFLAME.Visible = true;

				} else if (gobjInst.N2of) {
					lblStatus.Text = "NA - FLAME";
					btnNAFLAME.Text = "EXTINGUISH &NA FLAME";
					btnNAFLAME.Visible = true;
					btnAAFLAME.Visible = false;
				} else {
					lblStatus.Text = "READY FOR IGNITION";
					if (!aa) {
						btnNAFLAME.Text = "&NA - FLAME";
						btnNAFLAME.Visible = true;
						btnAAFLAME.Visible = false;
					} else {
						btnAAFLAME.Text = "&AA - FLAME";
						btnNAFLAME.Visible = false;
						btnAAFLAME.Visible = true;
					}
					//btnAAFLAME.Text = "&AA - FLAME"
				}
			}
			//Else
			//If Not ato Then
			//    If Not posted Then
			//        posted = True
			//    End If
			//End If
			//If (flag Or (Not (gobjInst.Aaf = aaft)) Or (Not (gobjInst.N2of = n2oft))) Then
			//    btnAAFLAME.Visible = True
			//    btnNAFLAME.Visible = True

			//    flag = False
			//    aaft = gobjInst.Aaf
			//    n2oft = gobjInst.N2of
			//    If gobjInst.Aaf Then
			//        lblStatus.Text = "AA - FLAME"
			//        btnAAFLAME.Text = "EXTINGUISH &AA FLAME"
			//        btnAAFLAME.TextAlign = ContentAlignment.TopLeft

			//        btnNAFLAME.Visible = False
			//    ElseIf gobjInst.N2of Then
			//        lblStatus.Text = "NA - FLAME"
			//        btnNAFLAME.Text = "EXTINGUISH &NA FLAME"
			//        btnNAFLAME.TextAlign = ContentAlignment.TopLeft
			//        btnNAFLAME.Visible = False
			//    Else
			//        lblStatus.Text = "READY FOR IGNITION"
			//        If Not aa Then
			//            btnNAFLAME.Text = "&NA - FLAME"
			//        Else
			//            btnNAFLAME.Visible = False
			//        End If
			//        btnAAFLAME.Text = "&AA - FLAME"
			//    End If
			//End If
			//End If
			Application.DoEvents();
		//End While

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
			//objWait.Dispose()
			//---------------------------------------------------------
		}

	}

	private void btnAAFLAME_Click(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : btnAAFLAME_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : 
		// Purpose               : To get the AA Flame
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 07-02-2007
		// Revisions             : 
		//=====================================================================
		if (mblnAvoidPorcess == true) {
			return;
		}
		CWaitCursor objWait = new CWaitCursor();
		try {
			mblnAvoidPorcess = true;
			mblnIgnitionWait = true;
			mobjclsBgAutoIgnition.IgnitionWait = true;

			if (gobjInst.Aaf) {
				//gobjInst.Aaf = gobjCommProtocol.func_AA_FLAME_OFF
				if (gobjCommProtocol.func_AA_FLAME_OFF() == true) {
					gobjInst.Aaf = false;
				}
			} else if (gobjInst.N2of) {
				gobjInst.N2of = gobjCommProtocol.func_N2_FLAME_OFF;
			} else {
				gobjInst.Aaf = gobjCommProtocol.func_AA_FLAME_ON;
			}
			Beep();
			mblnAvoidPorcess = false;
			mblnIgnitionWait = false;
			mobjclsBgAutoIgnition.IgnitionWait = false;
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			//---------------------------------------------------------
			mblnAvoidPorcess = false;
			mblnIgnitionWait = false;
			mobjclsBgAutoIgnition.IgnitionWait = false;
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

		//if (Inst.Aaf)  
		//   Inst.Aaf=AA_FLAME_OFF();
		//else if (Inst.N2of ) 
		//   Inst.N2of=N2_FLAME_OFF();
		//else	
		//   Inst.Aaf = AA_FLAME_ON();
		//Beep(); break;
	}

	private void btnNAFLAME_Click(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : btnNAFLAME_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : 
		// Purpose               : To get the NA Flame
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 07-02-2007
		// Revisions             : 
		//=====================================================================
		if (mblnAvoidPorcess == true) {
			return;
		}
		CWaitCursor objWait = new CWaitCursor();

		try {
			mblnAvoidPorcess = true;
			mblnIgnitionWait = true;
			mobjclsBgAutoIgnition.IgnitionWait = true;
			if (!gobjInst.N2of) {
				gobjInst.N2of = gobjCommProtocol.func_N2_FLAME_ON;
			} else {
				gobjMessageAdapter.ShowMessage(constAlreadyNAFlame);
				//MsgBox("Sorry already in NA FLAME")
			}
			mblnAvoidPorcess = false;
			mblnIgnitionWait = false;
			mobjclsBgAutoIgnition.IgnitionWait = false;
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			//---------------------------------------------------------
			mblnAvoidPorcess = false;
			mblnIgnitionWait = false;
			mobjclsBgAutoIgnition.IgnitionWait = false;
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
			//objWait.Dispose()
			//---------------------------------------------------------
		}

		//if (!Inst.N2of ) 
		//   Inst.N2of=N2_FLAME_ON();
		//else
		//{  if(GetInstrument() == AA202)
		//	    Gerror_message_new("Sorry already in NA Flame", "AA-202 PNEUM");
		//   else
		//	    Gerror_message_new("Sorry already in NA Flame", "AA-203 PNEUM");
		//}
		//	break;
	}

	//Private Sub CommandBarButtonItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
	//    '//----- Commented by Sachin Dokhale
	//    'Call gobjCommProtocol.func_AA_FLAME_ON()
	//    '//----- added by Sachin Dokhale
	//    If gobjInst.Aaf Then
	//        'gobjInst.Aaf = gobjCommProtocol.func_AA_FLAME_OFF
	//        If gobjCommProtocol.func_AA_FLAME_OFF() = True Then
	//            gobjInst.Aaf = False
	//        End If
	//    ElseIf gobjInst.N2of Then
	//        gobjInst.N2of = gobjCommProtocol.func_N2_FLAME_OFF
	//    Else
	//        gobjInst.Aaf = gobjCommProtocol.func_AA_FLAME_ON
	//    End If
	//    '//-----
	//End Sub

	private bool funcAuto_Init()
	{
		//=====================================================================
		// Procedure Name        : subWorkInBackground
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To init the Auto flame
		//                       : loop and in background.      
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale & Saurabh S 
		// Created               : 16.02.07
		// Revisions             : Sachin Dokhale 
		//=====================================================================
		//        void 	S4FUNC Auto_Init(HWND hpar)
		//   {
		//       int     	k; //,i;
		//       BYTE    	data;
		//       HWND 		hwnd,hwnd1;
		//       MSG		msg;
		//       BOOL    	flag=FALSE;
		//       DLGPROC 	skp ;
		//       DWORD		w1,w2;
		//       BOOL 		ato=TRUE,aaft=OFF, n2oft=OFF, posted=FALSE;
		//       HDC 		hdc;

		//       // hwnd1 = Create_Window_Pneum(NULL,"AA-203  AA FLAME");
		//       If (!Commflag) Then
		//	        return;
		//       if(GetInstrument()==AA202)
		//	        hwnd1 = Create_Window_Pneum("AA-202  AA FLAME");
		//       Else
		//	        hwnd1 = Create_Window_Pneum("AA-203  AA FLAME");
		//       StHwnd=hwnd1;
		//       skp = (DLGPROC) MakeProcInstance((FARPROC) ManualProc, hInst);
		//       hwnd = CreateDialog(hInst, "AUTO", NULL, skp);
		//       if (hwnd!=NULL)
		//       {
		//	        EnableWindow(hpar, FALSE);	 	
		//           ShowWindow(hwnd, SW_SHOW);
		//	        UpdateWindow(hwnd); 
		//           WP1=-1;		
		//           hdc = GetDC(hwnd);
		//	        SetBkColor(hdc, RGB(192,192,192));
		//	        aa =  OFF;
		//	        ps1= ps2= ps3 = ON;
		//	        data = CHECK_BUR_PAR();
		//	        if (data & AA_CONNECTED) 
		//               aa = ON;
		//	        else 
		//               aa=OFF;
		//	        data  = CHECK_PS();
		//	        if (data & AIR_NOK)  
		//               ps1 = OFF;
		//	        if (data & N2O_NOK)  
		//               ps2 = OFF;
		//	        if (data & FUEL_NOK) 
		//           {
		//               ato = OFF; 
		//               ps3 = OFF;
		//           }
		//	        if (ps1==OFF) 
		//               ato = OFF;
		//	        if (ps3==OFF) 
		//               ato = OFF;
		//	        if (aa!=ON && ps2==OFF) 
		//               ato = OFF;
		//	        w1 = GetTickCount();
		//	        Auto_Init_Check(&ato);
		//	        while(1)
		//           {
		//		        w2 = GetTickCount();
		//		        if ((w2-w1) > (DWORD) 200)
		//               {
		//		            w1=w2;
		//		            Status_Disp();
		//		        }
		//		        Auto_Init_Check(&ato);
		//               if (!ato)
		//                   if (!posted)
		//                   {
		//                       PostMessage(hwnd, WM_COMMAND, IDOK, 0L);
		//                       posted=TRUE;
		//                   }
		//		        if (flag|| Inst.Aaf!=aaft || Inst.N2of!=n2oft)
		//               {
		//		            ShowWindow(GetDlgItem(hwnd, IDC_BTN2),SW_SHOW);
		//		            ShowWindow(GetDlgItem(hwnd, IDC_BTN2),SW_SHOW);
		//		            flag = FALSE;
		//		            aaft = Inst.Aaf; 
		//                   n2oft=Inst.N2of;
		//		            if (Inst.Aaf) 
		//                   {
		//			            SetWindowText(GetDlgItem(hwnd, IDC_STATUS), "AA -FLAME");
		//			            SetWindowText(GetDlgItem(hwnd, IDC_BTN1), "EXTINGUISH AA");
		//			            ShowWindow(GetDlgItem(hwnd, IDC_BTN2),SW_HIDE);
		//			        }
		//		            else if (Inst.N2of)	
		//                   {
		//			            SetWindowText(GetDlgItem(hwnd, IDC_STATUS), "NA -FLAME");
		//			            SetWindowText(GetDlgItem(hwnd, IDC_BTN1), "EXTINGUISH NA");
		//			            ShowWindow(GetDlgItem(hwnd, IDC_BTN2),SW_HIDE);
		//			        }
		//		            else 
		//                   {
		//			            SetWindowText(GetDlgItem(hwnd, IDC_STATUS), "READY FOR IGNITION");
		//                       if (!aa) 
		//				            SetWindowText(GetDlgItem(hwnd, IDC_BTN2), "NA FLAME");
		//                       else
		//				            ShowWindow(GetDlgItem(hwnd, IDC_BTN2),SW_HIDE);
		//			            SetWindowText(GetDlgItem(hwnd, IDC_BTN1), "AA FLAME");
		//		    	    }
		//			    UpdateWindow(hwnd);
		//		    }
		//           if (CheckMsg(hwnd, &msg))
		//           {
		//		        flag = TRUE;
		//		        switch(WP1)
		//               {
		//			         case  IDC_BTN1:if (Inst.Aaf)  Inst.Aaf=AA_FLAME_OFF();
		//								 else if (Inst.N2of ) Inst.N2of=N2_FLAME_OFF();
		//								 else	Inst.Aaf = AA_FLAME_ON();
		//								 Beep(); break;
		//			 case  IDC_BTN2:	if (!Inst.N2of ) Inst.N2of=N2_FLAME_ON();
		//									else{ if(GetInstrument() == AA202)
		//												Gerror_message_new("Sorry already in NA Flame", "AA-202 PNEUM");
		//											else
		//												Gerror_message_new("Sorry already in NA Flame", "AA-203 PNEUM");}
		//									break;
		//			case IDC_INCRF:  Incr_Fuel();
		//								  Wprintf(hdc, 10, 70, "%3.2f    ", (double)Inst.Nvstep/(double)NVRED);break;
		//			case IDC_DFUEL:  Decr_Fuel();
		//								  Wprintf(hdc, 10, 70, "%3.2f     ", (double)Inst.Nvstep/(double) NVRED); break;
		//			case IDC_INCRH : Incr_Height(); break;
		//			case IDC_DECRH : Decr_Height(); break;
		//			case IDC_FUEL  : if (NV_HOME()) Inst.Nvstep=0;
		//								  else Inst.Nvstep = -1;break;
		//			case IDC_BUR:   if(BH_HOME()) Inst.Bhstep =0;
		//								 else Inst.Bhstep=-1; break;
		//			}
		//		  if (WP1==IDOK){
		//			 WP1=-1;
		//			 for(k=0; k<10;k++)
		//				 CheckMsg(hpar, &msg);
		//			 EnableWindow(hpar, TRUE);
		//			 ReleaseDC(hwnd, hdc);
		//			 DestroyWindow(hwnd);
		//			 UpdateWindow(hpar);
		//			 break;
		//		  }
		//		  WP1=-1;
		//		}
		//	 }
		//  }
		// FreeProcInstance((FARPROC)skp);
		// Close_Window(hwnd1, NULL);
		// StHwnd=NULL;
		//}

		try {
			count = 0;
			aa = false;
			ps1 = true;
			// To check for Air pressure 
			ps2 = true;
			// To check for N2O pressure 
			ps3 = true;
			// To check for Fuel pressure 

			btnAAFLAME.Visible = true;
			btnNAFLAME.Visible = true;
			if (gobjCommProtocol.funcCheckBurnerParameters(data) == false) {
				return;
			}
			if ((data & EnumErrorStatus.AA_CONNECTED)) {
				aa = true;
			} else {
				aa = false;
			}

			if (gobjCommProtocol.funcPressSensorStatus(data, false) == false) {
				return;
			}

			if ((data & EnumErrorStatus.AIR_NOK)) {
				ps1 = false;
			}
			if ((data & EnumErrorStatus.N2O_NOK)) {
				ps2 = false;
			}
			if ((data & EnumErrorStatus.FUEL_NOK)) {
				ato = false;
				ps3 = false;
			}

			if ((ps1 == false)) {
				ato = false;
			}

			if ((ps3 == false)) {
				ato = false;
			}

			if ((!aa == true & ps2 == false)) {
				ato = false;
			}

			if (Auto_Init_Check(ato) == false) {
				return;
			}

			//mobjThread = New Threading.Thread(AddressOf subWorkInBackground)
			//mobjThread.IsBackground = True
			//mobjThread.Start()
			mobjController = new clsBgThread(this);
			mobjclsBgAutoIgnition = new ClsBgManualIgnition();
			gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay);
			//10.12.07
			Application.DoEvents();
			mobjController.Start(mobjclsBgAutoIgnition);
			mobjclsBgAutoIgnition.ManualIgnition += subWaitManualThread;

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
			//objWait.Dispose()
			//---------------------------------------------------------
		}
	}

	private void subWaitManualThread(ref bool IsContinue)
	{
		//=====================================================================
		// Procedure Name        : subWaitManualThread
		// Parameters Passed     : Boolean
		// Returns               : 
		// Purpose               : 
		// Description           : To Get Thread Event
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 
		// Revisions             : 
		//=====================================================================
		try {
			if (mblnIgnitionWait == false) {
				subWorkInBackground();
			}

			if (mblnIgnitionWait == false) {
				//intFlameType = gobjClsAAS203.funcIgnite_Test()
				//gobjfrmStatus.FlameType = intFlameType
				//--- Modified function of funcIgnite_Test by Sachin Dokhale on 04.02.07
				//intEnumIgiteType = gobjClsAAS203.funcIgnite_Test()
				ClsAAS203.enumIgniteType intIgnite_Test;
				if (gobjClsAAS203.funcIgnite_Test(intIgnite_Test)) {
					intFlameType = intIgnite_Test;
					gobjfrmStatus.FlameType = intFlameType;
				}
				//---
			}
			//End If

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
			mblnIgnitionTerminate = true;
			mblnIgnitionWait = true;
			btnClose_Click(btnClose, System.EventArgs.Empty);
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
			mblnIgnitionTerminate = true;
			mblnIgnitionWait = true;
			btnClose_Click(btnClose, System.EventArgs.Empty);
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

	private void  // ERROR: Handles clauses are not supported in C#
frmAutoIgnition_Closing(object sender, System.ComponentModel.CancelEventArgs e)
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
		try {
			if (mblnIgnitionTerminate == false) {
				if (!(mobjController == null)) {
					if (mobjController.IsThreadRunning) {
						mobjclsBgAutoIgnition.ThTerminate = true;
						mobjclsBgAutoIgnition.IgnitionWait = true;
						mblnIgnitionWait = true;
						e.Cancel = true;
						Application.DoEvents();
						//Call btnClose_Click(sender, e)
						return;
					}
				}
			} else {
				if (!(mobjController == null)) {
					if (mobjController.IsThreadRunning) {
						mobjclsBgAutoIgnition.ThTerminate = true;
						mobjclsBgAutoIgnition.IgnitionWait = true;
						mblnIgnitionWait = true;
						mobjController.Cancel();
					}
				}
			}
			if (gobjCommProtocol.func_IGNITE_OFF()) {
			}
			if (mblnIsfrmFlameStatusWork == true) {
				if (!IsNothing(gobjMain)) {
					//If Not IsNothing(gobjMain.mobjfrmAnalysis) Then gobjMain.mobjfrmAnalysis.tmrAspirationMsg.Enabled = False
					if (gobjMain.mobjController.IsThreadRunning == false) {
						gobjMain.mobjController.Start(gobjclsBgFlameStatus);
					}
					mblnIsfrmFlameStatusWork = false;
					Application.DoEvents();
				}
			}
			Application.DoEvents();
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


	private void  // ERROR: Handles clauses are not supported in C#
frmAutoIgnition_Activated(object sender, System.EventArgs e)
	{
	}
}
