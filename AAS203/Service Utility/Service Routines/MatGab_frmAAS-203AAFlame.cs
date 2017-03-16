public class frmAAS_203AAFlame : System.Windows.Forms.Form
{

	#Region " Windows Form Designer generated code "

	public frmAAS_203AAFlame()
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
	internal System.Windows.Forms.PictureBox pbFlameRatio;
	internal System.Windows.Forms.PictureBox pbFlameType;
	internal System.Windows.Forms.PictureBox pbSafetyControlsTrap;
	internal System.Windows.Forms.PictureBox pbSafetyControlsDoor;
	internal System.Windows.Forms.PictureBox pbBurnerType;
	internal System.Windows.Forms.PictureBox pbStatusFuel;
	internal System.Windows.Forms.PictureBox pbStatusN2O;
	internal System.Windows.Forms.PictureBox pbPressureFuel;
	internal System.Windows.Forms.PictureBox pbPressureN2O;
	internal System.Windows.Forms.PictureBox pbPressureAir;
	internal System.Windows.Forms.PictureBox pbStatusAir;
	internal System.Windows.Forms.PictureBox pbBurnerHeight;
	[System.Diagnostics.DebuggerStepThrough()]
	private void InitializeComponent()
	{
		this.CustomPanel1 = new GradientPanel.CustomPanel();
		this.pbFlameRatio = new System.Windows.Forms.PictureBox();
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
		this.Label3 = new System.Windows.Forms.Label();
		this.Label1 = new System.Windows.Forms.Label();
		this.pbBurnerHeight = new System.Windows.Forms.PictureBox();
		this.lblBurnerHeight = new System.Windows.Forms.Label();
		this.CustomPanel1.SuspendLayout();
		this.SuspendLayout();
		//
		//CustomPanel1
		//
		this.CustomPanel1.BackColor = System.Drawing.Color.AliceBlue;
		this.CustomPanel1.Controls.Add(this.pbBurnerHeight);
		this.CustomPanel1.Controls.Add(this.lblBurnerHeight);
		this.CustomPanel1.Controls.Add(this.pbFlameRatio);
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
		this.CustomPanel1.Controls.Add(this.Label3);
		this.CustomPanel1.Controls.Add(this.Label1);
		this.CustomPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.CustomPanel1.Location = new System.Drawing.Point(0, 0);
		this.CustomPanel1.Name = "CustomPanel1";
		this.CustomPanel1.Size = new System.Drawing.Size(634, 101);
		this.CustomPanel1.TabIndex = 0;
		//
		//pbFlameRatio
		//
		this.pbFlameRatio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.pbFlameRatio.Location = new System.Drawing.Point(575, 74);
		this.pbFlameRatio.Name = "pbFlameRatio";
		this.pbFlameRatio.Size = new System.Drawing.Size(56, 24);
		this.pbFlameRatio.TabIndex = 36;
		this.pbFlameRatio.TabStop = false;
		//
		//pbFlameType
		//
		this.pbFlameType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.pbFlameType.Location = new System.Drawing.Point(525, 74);
		this.pbFlameType.Name = "pbFlameType";
		this.pbFlameType.Size = new System.Drawing.Size(48, 24);
		this.pbFlameType.TabIndex = 35;
		this.pbFlameType.TabStop = false;
		//
		//pbSafetyControlsTrap
		//
		this.pbSafetyControlsTrap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.pbSafetyControlsTrap.Location = new System.Drawing.Point(471, 74);
		this.pbSafetyControlsTrap.Name = "pbSafetyControlsTrap";
		this.pbSafetyControlsTrap.Size = new System.Drawing.Size(48, 24);
		this.pbSafetyControlsTrap.TabIndex = 34;
		this.pbSafetyControlsTrap.TabStop = false;
		//
		//pbSafetyControlsDoor
		//
		this.pbSafetyControlsDoor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.pbSafetyControlsDoor.Location = new System.Drawing.Point(416, 74);
		this.pbSafetyControlsDoor.Name = "pbSafetyControlsDoor";
		this.pbSafetyControlsDoor.Size = new System.Drawing.Size(53, 24);
		this.pbSafetyControlsDoor.TabIndex = 33;
		this.pbSafetyControlsDoor.TabStop = false;
		//
		//pbBurnerType
		//
		this.pbBurnerType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.pbBurnerType.Location = new System.Drawing.Point(266, 74);
		this.pbBurnerType.Name = "pbBurnerType";
		this.pbBurnerType.Size = new System.Drawing.Size(75, 24);
		this.pbBurnerType.TabIndex = 32;
		this.pbBurnerType.TabStop = false;
		//
		//pbStatusFuel
		//
		this.pbStatusFuel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.pbStatusFuel.Location = new System.Drawing.Point(211, 74);
		this.pbStatusFuel.Name = "pbStatusFuel";
		this.pbStatusFuel.Size = new System.Drawing.Size(37, 24);
		this.pbStatusFuel.TabIndex = 31;
		this.pbStatusFuel.TabStop = false;
		//
		//pbStatusN2O
		//
		this.pbStatusN2O.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.pbStatusN2O.Location = new System.Drawing.Point(173, 74);
		this.pbStatusN2O.Name = "pbStatusN2O";
		this.pbStatusN2O.Size = new System.Drawing.Size(37, 24);
		this.pbStatusN2O.TabIndex = 30;
		this.pbStatusN2O.TabStop = false;
		//
		//pbPressureFuel
		//
		this.pbPressureFuel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.pbPressureFuel.Location = new System.Drawing.Point(79, 74);
		this.pbPressureFuel.Name = "pbPressureFuel";
		this.pbPressureFuel.Size = new System.Drawing.Size(37, 24);
		this.pbPressureFuel.TabIndex = 29;
		this.pbPressureFuel.TabStop = false;
		//
		//pbPressureN2O
		//
		this.pbPressureN2O.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.pbPressureN2O.Location = new System.Drawing.Point(41, 74);
		this.pbPressureN2O.Name = "pbPressureN2O";
		this.pbPressureN2O.Size = new System.Drawing.Size(37, 24);
		this.pbPressureN2O.TabIndex = 28;
		this.pbPressureN2O.TabStop = false;
		//
		//pbPressureAir
		//
		this.pbPressureAir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.pbPressureAir.Location = new System.Drawing.Point(3, 74);
		this.pbPressureAir.Name = "pbPressureAir";
		this.pbPressureAir.Size = new System.Drawing.Size(37, 24);
		this.pbPressureAir.TabIndex = 27;
		this.pbPressureAir.TabStop = false;
		//
		//pbStatusAir
		//
		this.pbStatusAir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.pbStatusAir.Location = new System.Drawing.Point(135, 74);
		this.pbStatusAir.Name = "pbStatusAir";
		this.pbStatusAir.Size = new System.Drawing.Size(37, 24);
		this.pbStatusAir.TabIndex = 26;
		this.pbStatusAir.TabStop = false;
		//
		//lblFlameRatio
		//
		this.lblFlameRatio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblFlameRatio.Font = new System.Drawing.Font("Times New Roman", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblFlameRatio.Location = new System.Drawing.Point(575, 49);
		this.lblFlameRatio.Name = "lblFlameRatio";
		this.lblFlameRatio.Size = new System.Drawing.Size(56, 24);
		this.lblFlameRatio.TabIndex = 24;
		this.lblFlameRatio.Text = "RATIO";
		this.lblFlameRatio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		//
		//lblFlameType
		//
		this.lblFlameType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblFlameType.Font = new System.Drawing.Font("Times New Roman", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblFlameType.Location = new System.Drawing.Point(525, 49);
		this.lblFlameType.Name = "lblFlameType";
		this.lblFlameType.Size = new System.Drawing.Size(48, 24);
		this.lblFlameType.TabIndex = 23;
		this.lblFlameType.Text = "TYPE";
		this.lblFlameType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		//
		//lblSafetyControlsTrap
		//
		this.lblSafetyControlsTrap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblSafetyControlsTrap.Font = new System.Drawing.Font("Times New Roman", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblSafetyControlsTrap.Location = new System.Drawing.Point(471, 49);
		this.lblSafetyControlsTrap.Name = "lblSafetyControlsTrap";
		this.lblSafetyControlsTrap.Size = new System.Drawing.Size(48, 24);
		this.lblSafetyControlsTrap.TabIndex = 22;
		this.lblSafetyControlsTrap.Text = "TRAP";
		this.lblSafetyControlsTrap.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		//
		//lblSafetyControlsDoor
		//
		this.lblSafetyControlsDoor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblSafetyControlsDoor.Font = new System.Drawing.Font("Times New Roman", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblSafetyControlsDoor.Location = new System.Drawing.Point(416, 49);
		this.lblSafetyControlsDoor.Name = "lblSafetyControlsDoor";
		this.lblSafetyControlsDoor.Size = new System.Drawing.Size(53, 24);
		this.lblSafetyControlsDoor.TabIndex = 21;
		this.lblSafetyControlsDoor.Text = "DOOR";
		this.lblSafetyControlsDoor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		//
		//lblBurnerType
		//
		this.lblBurnerType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblBurnerType.Font = new System.Drawing.Font("Times New Roman", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblBurnerType.Location = new System.Drawing.Point(266, 49);
		this.lblBurnerType.Name = "lblBurnerType";
		this.lblBurnerType.Size = new System.Drawing.Size(75, 24);
		this.lblBurnerType.TabIndex = 20;
		this.lblBurnerType.Text = "TYPE";
		this.lblBurnerType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		//
		//lblStatusFuel
		//
		this.lblStatusFuel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblStatusFuel.Font = new System.Drawing.Font("Times New Roman", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblStatusFuel.Location = new System.Drawing.Point(211, 49);
		this.lblStatusFuel.Name = "lblStatusFuel";
		this.lblStatusFuel.Size = new System.Drawing.Size(48, 24);
		this.lblStatusFuel.TabIndex = 19;
		this.lblStatusFuel.Text = "FUEL";
		this.lblStatusFuel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		//
		//lblStatusN2O
		//
		this.lblStatusN2O.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblStatusN2O.Font = new System.Drawing.Font("Times New Roman", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblStatusN2O.Location = new System.Drawing.Point(173, 49);
		this.lblStatusN2O.Name = "lblStatusN2O";
		this.lblStatusN2O.Size = new System.Drawing.Size(37, 24);
		this.lblStatusN2O.TabIndex = 18;
		this.lblStatusN2O.Text = "N2O";
		this.lblStatusN2O.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		//
		//lblStatusAir
		//
		this.lblStatusAir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblStatusAir.Font = new System.Drawing.Font("Times New Roman", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblStatusAir.Location = new System.Drawing.Point(135, 49);
		this.lblStatusAir.Name = "lblStatusAir";
		this.lblStatusAir.Size = new System.Drawing.Size(37, 24);
		this.lblStatusAir.TabIndex = 17;
		this.lblStatusAir.Text = "AIR";
		this.lblStatusAir.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		//
		//lblPressureFuel
		//
		this.lblPressureFuel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblPressureFuel.Font = new System.Drawing.Font("Times New Roman", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblPressureFuel.Location = new System.Drawing.Point(79, 49);
		this.lblPressureFuel.Name = "lblPressureFuel";
		this.lblPressureFuel.Size = new System.Drawing.Size(48, 24);
		this.lblPressureFuel.TabIndex = 16;
		this.lblPressureFuel.Text = "FUEL";
		this.lblPressureFuel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		//
		//lblPressureN2O
		//
		this.lblPressureN2O.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblPressureN2O.Font = new System.Drawing.Font("Times New Roman", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblPressureN2O.Location = new System.Drawing.Point(41, 49);
		this.lblPressureN2O.Name = "lblPressureN2O";
		this.lblPressureN2O.Size = new System.Drawing.Size(37, 24);
		this.lblPressureN2O.TabIndex = 15;
		this.lblPressureN2O.Text = "N2O";
		this.lblPressureN2O.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		//
		//lblPressureAir
		//
		this.lblPressureAir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblPressureAir.Font = new System.Drawing.Font("Times New Roman", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblPressureAir.Location = new System.Drawing.Point(3, 49);
		this.lblPressureAir.Name = "lblPressureAir";
		this.lblPressureAir.Size = new System.Drawing.Size(37, 24);
		this.lblPressureAir.TabIndex = 14;
		this.lblPressureAir.Text = "AIR";
		this.lblPressureAir.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		//
		//lblFlame
		//
		this.lblFlame.Font = new System.Drawing.Font("Times New Roman", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblFlame.Location = new System.Drawing.Point(525, 8);
		this.lblFlame.Name = "lblFlame";
		this.lblFlame.Size = new System.Drawing.Size(104, 32);
		this.lblFlame.TabIndex = 11;
		this.lblFlame.Text = "FLAME";
		this.lblFlame.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
		//
		//lblSafetyControls
		//
		this.lblSafetyControls.Font = new System.Drawing.Font("Times New Roman", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblSafetyControls.Location = new System.Drawing.Point(426, 8);
		this.lblSafetyControls.Name = "lblSafetyControls";
		this.lblSafetyControls.Size = new System.Drawing.Size(84, 32);
		this.lblSafetyControls.TabIndex = 10;
		this.lblSafetyControls.Text = "SAFETY CONTROLS";
		this.lblSafetyControls.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
		//
		//lblBurner
		//
		this.lblBurner.Font = new System.Drawing.Font("Times New Roman", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblBurner.Location = new System.Drawing.Point(271, 8);
		this.lblBurner.Name = "lblBurner";
		this.lblBurner.Size = new System.Drawing.Size(135, 32);
		this.lblBurner.TabIndex = 9;
		this.lblBurner.Text = "BURNER";
		this.lblBurner.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
		//
		//lblPressureValveStatus
		//
		this.lblPressureValveStatus.Font = new System.Drawing.Font("Times New Roman", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblPressureValveStatus.Location = new System.Drawing.Point(145, 8);
		this.lblPressureValveStatus.Name = "lblPressureValveStatus";
		this.lblPressureValveStatus.Size = new System.Drawing.Size(104, 32);
		this.lblPressureValveStatus.TabIndex = 8;
		this.lblPressureValveStatus.Text = "PRESSURE VALVE STATUS";
		this.lblPressureValveStatus.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
		//
		//lblPressures
		//
		this.lblPressures.Font = new System.Drawing.Font("Times New Roman", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblPressures.Location = new System.Drawing.Point(11, 8);
		this.lblPressures.Name = "lblPressures";
		this.lblPressures.Size = new System.Drawing.Size(110, 32);
		this.lblPressures.TabIndex = 7;
		this.lblPressures.Text = "PRESSURES";
		this.lblPressures.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
		//
		//Label7
		//
		this.Label7.BackColor = System.Drawing.SystemColors.Control;
		this.Label7.Location = new System.Drawing.Point(412, 0);
		this.Label7.Name = "Label7";
		this.Label7.Size = new System.Drawing.Size(2, 120);
		this.Label7.TabIndex = 6;
		this.Label7.Text = "Label7";
		//
		//Label6
		//
		this.Label6.BackColor = System.Drawing.SystemColors.Control;
		this.Label6.Location = new System.Drawing.Point(521, 0);
		this.Label6.Name = "Label6";
		this.Label6.Size = new System.Drawing.Size(2, 120);
		this.Label6.TabIndex = 5;
		this.Label6.Text = "Label6";
		//
		//Label5
		//
		this.Label5.BackColor = System.Drawing.SystemColors.Control;
		this.Label5.Location = new System.Drawing.Point(262, 0);
		this.Label5.Name = "Label5";
		this.Label5.Size = new System.Drawing.Size(2, 120);
		this.Label5.TabIndex = 4;
		this.Label5.Text = "Label5";
		//
		//Label3
		//
		this.Label3.BackColor = System.Drawing.SystemColors.Control;
		this.Label3.Location = new System.Drawing.Point(130, 0);
		this.Label3.Name = "Label3";
		this.Label3.Size = new System.Drawing.Size(2, 120);
		this.Label3.TabIndex = 2;
		this.Label3.Text = "Label3";
		//
		//Label1
		//
		this.Label1.BackColor = System.Drawing.SystemColors.Control;
		this.Label1.Location = new System.Drawing.Point(1, 45);
		this.Label1.Name = "Label1";
		this.Label1.Size = new System.Drawing.Size(700, 2);
		this.Label1.TabIndex = 0;
		//
		//pbBurnerHeight
		//
		this.pbBurnerHeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.pbBurnerHeight.Location = new System.Drawing.Point(343, 74);
		this.pbBurnerHeight.Name = "pbBurnerHeight";
		this.pbBurnerHeight.Size = new System.Drawing.Size(66, 24);
		this.pbBurnerHeight.TabIndex = 39;
		this.pbBurnerHeight.TabStop = false;
		//
		//lblBurnerHeight
		//
		this.lblBurnerHeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblBurnerHeight.Font = new System.Drawing.Font("Times New Roman", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblBurnerHeight.Location = new System.Drawing.Point(343, 49);
		this.lblBurnerHeight.Name = "lblBurnerHeight";
		this.lblBurnerHeight.Size = new System.Drawing.Size(66, 24);
		this.lblBurnerHeight.TabIndex = 38;
		this.lblBurnerHeight.Text = "HEIGHT";
		this.lblBurnerHeight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		//
		//frmAAS_203AAFlame
		//
		this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
		this.ClientSize = new System.Drawing.Size(634, 101);
		this.ControlBox = false;
		this.Controls.Add(this.CustomPanel1);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		this.Name = "frmAAS_203AAFlame";
		this.ShowInTaskbar = false;
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "AAS-203 AA Flame";
		this.CustomPanel1.ResumeLayout(false);
		this.ResumeLayout(false);

	}

	#End Region

}
