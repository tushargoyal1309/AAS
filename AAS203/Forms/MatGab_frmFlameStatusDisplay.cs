
public class frmFlameStatusDisplay : System.Windows.Forms.Form
{

	#Region " Windows Form Designer generated code "

	public frmFlameStatusDisplay()
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
	internal GradientPanel.CustomPanel custpnlStatusDisplay;
	internal System.Windows.Forms.Label lblFlameType;
	internal System.Windows.Forms.Label lblSafetyControlsTrap;
	internal System.Windows.Forms.Label lblSafetyControlsDoor;
	internal System.Windows.Forms.Label lblBurnerType;
	internal System.Windows.Forms.Label lblStatusFuel;
	internal System.Windows.Forms.Label lblStatusN2O;
	internal System.Windows.Forms.Label lblStatusAir;
	internal System.Windows.Forms.Label lblPressureFuel;
	internal System.Windows.Forms.Label Label7;
	internal System.Windows.Forms.Label lblPressureAir;
	internal System.Windows.Forms.Label lblFlame;
	internal System.Windows.Forms.Label lblSafetyControls;
	internal System.Windows.Forms.Label Label5;
	internal System.Windows.Forms.Label Label3;
	internal System.Windows.Forms.Label Label1;
	internal System.Windows.Forms.Label lblBurner;
	internal System.Windows.Forms.Label lblPressureValveStatus;
	internal System.Windows.Forms.Label pbFlameType;
	internal System.Windows.Forms.Label pbSafetyControlsDoor;
	internal System.Windows.Forms.Label pbBurnerType;
	internal System.Windows.Forms.Label pbStatusFuel;
	internal System.Windows.Forms.Label pbStatusN2O;
	internal System.Windows.Forms.Label pbStatusAir;
	internal System.Windows.Forms.Label pbPressureFuel;
	internal System.Windows.Forms.Label pbPressureN2O;
	internal System.Windows.Forms.Label pbPressureAir;
	internal System.Windows.Forms.Label lblPressures;
	internal System.Windows.Forms.Label lblBHeight;
	internal System.Windows.Forms.Label Label6;
	internal System.Windows.Forms.Label lblFRatio;
	internal System.Windows.Forms.Label lblPressureN2O;
	internal System.Windows.Forms.Label lblBurnerHeight;
	internal System.Windows.Forms.PictureBox pbSafetyControlsTrap;
	internal System.Windows.Forms.Label lblFlameRatio;
	internal System.Windows.Forms.Label Label2;
	[System.Diagnostics.DebuggerStepThrough()]
	private void InitializeComponent()
	{
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFlameStatusDisplay));
		this.custpnlStatusDisplay = new GradientPanel.CustomPanel();
		this.lblFlameType = new System.Windows.Forms.Label();
		this.lblSafetyControlsTrap = new System.Windows.Forms.Label();
		this.lblSafetyControlsDoor = new System.Windows.Forms.Label();
		this.lblBurnerType = new System.Windows.Forms.Label();
		this.lblStatusFuel = new System.Windows.Forms.Label();
		this.lblStatusN2O = new System.Windows.Forms.Label();
		this.lblStatusAir = new System.Windows.Forms.Label();
		this.lblPressureFuel = new System.Windows.Forms.Label();
		this.Label7 = new System.Windows.Forms.Label();
		this.lblPressureAir = new System.Windows.Forms.Label();
		this.lblFlame = new System.Windows.Forms.Label();
		this.lblSafetyControls = new System.Windows.Forms.Label();
		this.Label5 = new System.Windows.Forms.Label();
		this.Label3 = new System.Windows.Forms.Label();
		this.Label1 = new System.Windows.Forms.Label();
		this.lblBurner = new System.Windows.Forms.Label();
		this.lblPressureValveStatus = new System.Windows.Forms.Label();
		this.pbFlameType = new System.Windows.Forms.Label();
		this.pbSafetyControlsDoor = new System.Windows.Forms.Label();
		this.pbBurnerType = new System.Windows.Forms.Label();
		this.pbStatusFuel = new System.Windows.Forms.Label();
		this.pbStatusN2O = new System.Windows.Forms.Label();
		this.pbStatusAir = new System.Windows.Forms.Label();
		this.pbPressureFuel = new System.Windows.Forms.Label();
		this.pbPressureN2O = new System.Windows.Forms.Label();
		this.pbPressureAir = new System.Windows.Forms.Label();
		this.lblPressures = new System.Windows.Forms.Label();
		this.lblBHeight = new System.Windows.Forms.Label();
		this.Label6 = new System.Windows.Forms.Label();
		this.lblFRatio = new System.Windows.Forms.Label();
		this.lblPressureN2O = new System.Windows.Forms.Label();
		this.lblBurnerHeight = new System.Windows.Forms.Label();
		this.pbSafetyControlsTrap = new System.Windows.Forms.PictureBox();
		this.lblFlameRatio = new System.Windows.Forms.Label();
		this.Label2 = new System.Windows.Forms.Label();
		this.custpnlStatusDisplay.SuspendLayout();
		this.SuspendLayout();
		//
		//custpnlStatusDisplay
		//
		this.custpnlStatusDisplay.BackColor = System.Drawing.Color.AliceBlue;
		this.custpnlStatusDisplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.custpnlStatusDisplay.Controls.Add(this.lblFlameType);
		this.custpnlStatusDisplay.Controls.Add(this.lblSafetyControlsTrap);
		this.custpnlStatusDisplay.Controls.Add(this.lblSafetyControlsDoor);
		this.custpnlStatusDisplay.Controls.Add(this.lblBurnerType);
		this.custpnlStatusDisplay.Controls.Add(this.lblStatusFuel);
		this.custpnlStatusDisplay.Controls.Add(this.lblStatusN2O);
		this.custpnlStatusDisplay.Controls.Add(this.lblStatusAir);
		this.custpnlStatusDisplay.Controls.Add(this.lblPressureFuel);
		this.custpnlStatusDisplay.Controls.Add(this.Label7);
		this.custpnlStatusDisplay.Controls.Add(this.lblPressureAir);
		this.custpnlStatusDisplay.Controls.Add(this.lblFlame);
		this.custpnlStatusDisplay.Controls.Add(this.lblSafetyControls);
		this.custpnlStatusDisplay.Controls.Add(this.Label5);
		this.custpnlStatusDisplay.Controls.Add(this.Label3);
		this.custpnlStatusDisplay.Controls.Add(this.Label1);
		this.custpnlStatusDisplay.Controls.Add(this.lblBurner);
		this.custpnlStatusDisplay.Controls.Add(this.lblPressureValveStatus);
		this.custpnlStatusDisplay.Controls.Add(this.pbFlameType);
		this.custpnlStatusDisplay.Controls.Add(this.pbSafetyControlsDoor);
		this.custpnlStatusDisplay.Controls.Add(this.pbBurnerType);
		this.custpnlStatusDisplay.Controls.Add(this.pbStatusFuel);
		this.custpnlStatusDisplay.Controls.Add(this.pbStatusN2O);
		this.custpnlStatusDisplay.Controls.Add(this.pbStatusAir);
		this.custpnlStatusDisplay.Controls.Add(this.pbPressureFuel);
		this.custpnlStatusDisplay.Controls.Add(this.pbPressureN2O);
		this.custpnlStatusDisplay.Controls.Add(this.pbPressureAir);
		this.custpnlStatusDisplay.Controls.Add(this.lblPressures);
		this.custpnlStatusDisplay.Controls.Add(this.lblBHeight);
		this.custpnlStatusDisplay.Controls.Add(this.Label6);
		this.custpnlStatusDisplay.Controls.Add(this.lblFRatio);
		this.custpnlStatusDisplay.Controls.Add(this.lblPressureN2O);
		this.custpnlStatusDisplay.Controls.Add(this.lblBurnerHeight);
		this.custpnlStatusDisplay.Controls.Add(this.pbSafetyControlsTrap);
		this.custpnlStatusDisplay.Controls.Add(this.lblFlameRatio);
		this.custpnlStatusDisplay.Controls.Add(this.Label2);
		this.custpnlStatusDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
		this.custpnlStatusDisplay.Location = new System.Drawing.Point(0, 0);
		this.custpnlStatusDisplay.Name = "custpnlStatusDisplay";
		this.custpnlStatusDisplay.Size = new System.Drawing.Size(590, 119);
		this.custpnlStatusDisplay.TabIndex = 79;
		//
		//lblFlameType
		//
		this.lblFlameType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblFlameType.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblFlameType.Location = new System.Drawing.Point(489, 54);
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
		this.lblSafetyControlsTrap.Location = new System.Drawing.Point(441, 54);
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
		this.lblSafetyControlsDoor.Location = new System.Drawing.Point(392, 54);
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
		this.lblBurnerType.Location = new System.Drawing.Point(281, 54);
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
		this.lblStatusFuel.Location = new System.Drawing.Point(233, 54);
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
		this.lblStatusN2O.Location = new System.Drawing.Point(188, 54);
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
		this.lblStatusAir.Location = new System.Drawing.Point(143, 54);
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
		this.lblPressureFuel.Location = new System.Drawing.Point(95, 54);
		this.lblPressureFuel.Name = "lblPressureFuel";
		this.lblPressureFuel.Size = new System.Drawing.Size(44, 24);
		this.lblPressureFuel.TabIndex = 16;
		this.lblPressureFuel.Text = "FUEL";
		this.lblPressureFuel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		//
		//Label7
		//
		this.Label7.BackColor = System.Drawing.SystemColors.Control;
		this.Label7.Location = new System.Drawing.Point(389, 0);
		this.Label7.Name = "Label7";
		this.Label7.Size = new System.Drawing.Size(2, 116);
		this.Label7.TabIndex = 6;
		this.Label7.Text = "Label7";
		//
		//lblPressureAir
		//
		this.lblPressureAir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblPressureAir.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblPressureAir.Location = new System.Drawing.Point(5, 54);
		this.lblPressureAir.Name = "lblPressureAir";
		this.lblPressureAir.Size = new System.Drawing.Size(44, 24);
		this.lblPressureAir.TabIndex = 14;
		this.lblPressureAir.Text = "AIR";
		this.lblPressureAir.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		//
		//lblFlame
		//
		this.lblFlame.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblFlame.Location = new System.Drawing.Point(496, 8);
		this.lblFlame.Name = "lblFlame";
		this.lblFlame.Size = new System.Drawing.Size(92, 32);
		this.lblFlame.TabIndex = 11;
		this.lblFlame.Text = "FLAME";
		this.lblFlame.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
		//
		//lblSafetyControls
		//
		this.lblSafetyControls.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblSafetyControls.Location = new System.Drawing.Point(399, 8);
		this.lblSafetyControls.Name = "lblSafetyControls";
		this.lblSafetyControls.Size = new System.Drawing.Size(84, 32);
		this.lblSafetyControls.TabIndex = 10;
		this.lblSafetyControls.Text = "SAFETY CONTROLS";
		this.lblSafetyControls.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
		//
		//Label5
		//
		this.Label5.BackColor = System.Drawing.SystemColors.Control;
		this.Label5.Location = new System.Drawing.Point(278, 0);
		this.Label5.Name = "Label5";
		this.Label5.Size = new System.Drawing.Size(2, 116);
		this.Label5.TabIndex = 4;
		this.Label5.Text = "Label5";
		//
		//Label3
		//
		this.Label3.BackColor = System.Drawing.SystemColors.Control;
		this.Label3.Location = new System.Drawing.Point(140, 0);
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
		this.lblPressureValveStatus.Location = new System.Drawing.Point(156, 8);
		this.lblPressureValveStatus.Name = "lblPressureValveStatus";
		this.lblPressureValveStatus.Size = new System.Drawing.Size(110, 32);
		this.lblPressureValveStatus.TabIndex = 8;
		this.lblPressureValveStatus.Text = "PRESSURE VALVE STATUS";
		this.lblPressureValveStatus.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
		//
		//pbFlameType
		//
		this.pbFlameType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.pbFlameType.Image = (System.Drawing.Image)resources.GetObject("pbFlameType.Image");
		this.pbFlameType.Location = new System.Drawing.Point(495, 80);
		this.pbFlameType.Name = "pbFlameType";
		this.pbFlameType.Size = new System.Drawing.Size(32, 32);
		this.pbFlameType.TabIndex = 77;
		//
		//pbSafetyControlsDoor
		//
		this.pbSafetyControlsDoor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.pbSafetyControlsDoor.Image = (System.Drawing.Image)resources.GetObject("pbSafetyControlsDoor.Image");
		this.pbSafetyControlsDoor.Location = new System.Drawing.Point(400, 80);
		this.pbSafetyControlsDoor.Name = "pbSafetyControlsDoor";
		this.pbSafetyControlsDoor.Size = new System.Drawing.Size(32, 32);
		this.pbSafetyControlsDoor.TabIndex = 76;
		//
		//pbBurnerType
		//
		this.pbBurnerType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.pbBurnerType.Image = (System.Drawing.Image)resources.GetObject("pbBurnerType.Image");
		this.pbBurnerType.Location = new System.Drawing.Point(287, 80);
		this.pbBurnerType.Name = "pbBurnerType";
		this.pbBurnerType.Size = new System.Drawing.Size(32, 32);
		this.pbBurnerType.TabIndex = 75;
		//
		//pbStatusFuel
		//
		this.pbStatusFuel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.pbStatusFuel.Image = (System.Drawing.Image)resources.GetObject("pbStatusFuel.Image");
		this.pbStatusFuel.Location = new System.Drawing.Point(239, 80);
		this.pbStatusFuel.Name = "pbStatusFuel";
		this.pbStatusFuel.Size = new System.Drawing.Size(32, 32);
		this.pbStatusFuel.TabIndex = 74;
		//
		//pbStatusN2O
		//
		this.pbStatusN2O.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.pbStatusN2O.Image = (System.Drawing.Image)resources.GetObject("pbStatusN2O.Image");
		this.pbStatusN2O.Location = new System.Drawing.Point(194, 80);
		this.pbStatusN2O.Name = "pbStatusN2O";
		this.pbStatusN2O.Size = new System.Drawing.Size(32, 32);
		this.pbStatusN2O.TabIndex = 73;
		//
		//pbStatusAir
		//
		this.pbStatusAir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.pbStatusAir.Image = (System.Drawing.Image)resources.GetObject("pbStatusAir.Image");
		this.pbStatusAir.Location = new System.Drawing.Point(149, 80);
		this.pbStatusAir.Name = "pbStatusAir";
		this.pbStatusAir.Size = new System.Drawing.Size(32, 32);
		this.pbStatusAir.TabIndex = 72;
		//
		//pbPressureFuel
		//
		this.pbPressureFuel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.pbPressureFuel.Image = (System.Drawing.Image)resources.GetObject("pbPressureFuel.Image");
		this.pbPressureFuel.Location = new System.Drawing.Point(101, 80);
		this.pbPressureFuel.Name = "pbPressureFuel";
		this.pbPressureFuel.Size = new System.Drawing.Size(32, 32);
		this.pbPressureFuel.TabIndex = 71;
		//
		//pbPressureN2O
		//
		this.pbPressureN2O.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.pbPressureN2O.Image = (System.Drawing.Image)resources.GetObject("pbPressureN2O.Image");
		this.pbPressureN2O.Location = new System.Drawing.Point(55, 80);
		this.pbPressureN2O.Name = "pbPressureN2O";
		this.pbPressureN2O.Size = new System.Drawing.Size(32, 32);
		this.pbPressureN2O.TabIndex = 70;
		//
		//pbPressureAir
		//
		this.pbPressureAir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.pbPressureAir.Image = (System.Drawing.Image)resources.GetObject("pbPressureAir.Image");
		this.pbPressureAir.Location = new System.Drawing.Point(11, 80);
		this.pbPressureAir.Name = "pbPressureAir";
		this.pbPressureAir.Size = new System.Drawing.Size(32, 32);
		this.pbPressureAir.TabIndex = 69;
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
		//lblBHeight
		//
		this.lblBHeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblBHeight.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblBHeight.Location = new System.Drawing.Point(326, 80);
		this.lblBHeight.Name = "lblBHeight";
		this.lblBHeight.Size = new System.Drawing.Size(62, 32);
		this.lblBHeight.TabIndex = 65;
		this.lblBHeight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		//
		//Label6
		//
		this.Label6.BackColor = System.Drawing.SystemColors.Control;
		this.Label6.Location = new System.Drawing.Point(486, 0);
		this.Label6.Name = "Label6";
		this.Label6.Size = new System.Drawing.Size(2, 116);
		this.Label6.TabIndex = 5;
		this.Label6.Text = "Label6";
		//
		//lblFRatio
		//
		this.lblFRatio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblFRatio.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblFRatio.Location = new System.Drawing.Point(535, 80);
		this.lblFRatio.Name = "lblFRatio";
		this.lblFRatio.Size = new System.Drawing.Size(52, 32);
		this.lblFRatio.TabIndex = 64;
		this.lblFRatio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		//
		//lblPressureN2O
		//
		this.lblPressureN2O.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblPressureN2O.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblPressureN2O.Location = new System.Drawing.Point(50, 54);
		this.lblPressureN2O.Name = "lblPressureN2O";
		this.lblPressureN2O.Size = new System.Drawing.Size(44, 24);
		this.lblPressureN2O.TabIndex = 15;
		this.lblPressureN2O.Text = "N2O";
		this.lblPressureN2O.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		//
		//lblBurnerHeight
		//
		this.lblBurnerHeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblBurnerHeight.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblBurnerHeight.Location = new System.Drawing.Point(326, 54);
		this.lblBurnerHeight.Name = "lblBurnerHeight";
		this.lblBurnerHeight.Size = new System.Drawing.Size(62, 24);
		this.lblBurnerHeight.TabIndex = 38;
		this.lblBurnerHeight.Text = "HEIGHT";
		this.lblBurnerHeight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		//
		//pbSafetyControlsTrap
		//
		this.pbSafetyControlsTrap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.pbSafetyControlsTrap.Image = (System.Drawing.Image)resources.GetObject("pbSafetyControlsTrap.Image");
		this.pbSafetyControlsTrap.Location = new System.Drawing.Point(447, 80);
		this.pbSafetyControlsTrap.Name = "pbSafetyControlsTrap";
		this.pbSafetyControlsTrap.Size = new System.Drawing.Size(32, 32);
		this.pbSafetyControlsTrap.TabIndex = 34;
		this.pbSafetyControlsTrap.TabStop = false;
		//
		//lblFlameRatio
		//
		this.lblFlameRatio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblFlameRatio.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblFlameRatio.Location = new System.Drawing.Point(535, 54);
		this.lblFlameRatio.Name = "lblFlameRatio";
		this.lblFlameRatio.Size = new System.Drawing.Size(52, 24);
		this.lblFlameRatio.TabIndex = 24;
		this.lblFlameRatio.Text = "RATIO";
		this.lblFlameRatio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		//
		//Label2
		//
		this.Label2.BackColor = System.Drawing.SystemColors.Control;
		this.Label2.Location = new System.Drawing.Point(0, 115);
		this.Label2.Name = "Label2";
		this.Label2.Size = new System.Drawing.Size(759, 2);
		this.Label2.TabIndex = 40;
		//
		//frmFlameStatusDisplay
		//
		this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
		this.ClientSize = new System.Drawing.Size(590, 119);
		this.ControlBox = false;
		this.Controls.Add(this.custpnlStatusDisplay);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		this.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		this.Name = "frmFlameStatusDisplay";
		this.ShowInTaskbar = false;
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Flame Status Display";
		this.custpnlStatusDisplay.ResumeLayout(false);
		this.ResumeLayout(false);

	}

	#End Region

}
