public class AutoSampler : System.Windows.Forms.Form
{

	#Region " Windows Form Designer generated code "

	public AutoSampler()
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
	internal System.Windows.Forms.Label lblHome;
	internal System.Windows.Forms.Label lblPosition;
	internal System.Windows.Forms.Label lblProbe;
	internal System.Windows.Forms.Label lblWashTime;
	internal System.Windows.Forms.Label lblIntakeTime;
	internal System.Windows.Forms.Button btnCancel;
	internal System.Windows.Forms.Label lblPump;
	internal System.Windows.Forms.TextBox txtWashTime;
	internal System.Windows.Forms.TextBox txtIntakeTime;
	internal System.Windows.Forms.TextBox txtHome;
	internal System.Windows.Forms.TextBox txtPump;
	internal System.Windows.Forms.TextBox txtPosition;
	internal System.Windows.Forms.TextBox txtProbe;
	internal System.Windows.Forms.GroupBox GroupBox1;
	internal System.Windows.Forms.GroupBox GroupBox2;
	internal System.Windows.Forms.GroupBox GroupBox3;
	internal System.Windows.Forms.Button btnHome;
	internal System.Windows.Forms.Button btnGoto;
	internal System.Windows.Forms.Button btnProbe;
	internal System.Windows.Forms.Button btnPumpForward;
	internal System.Windows.Forms.Button btnPumpReverse;
	internal System.Windows.Forms.Button btnTestPosns;
	[System.Diagnostics.DebuggerStepThrough()]
	private void InitializeComponent()
	{
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(AutoSampler));
		this.lblHome = new System.Windows.Forms.Label();
		this.lblPosition = new System.Windows.Forms.Label();
		this.lblProbe = new System.Windows.Forms.Label();
		this.lblWashTime = new System.Windows.Forms.Label();
		this.lblIntakeTime = new System.Windows.Forms.Label();
		this.btnCancel = new System.Windows.Forms.Button();
		this.lblPump = new System.Windows.Forms.Label();
		this.txtPump = new System.Windows.Forms.TextBox();
		this.txtWashTime = new System.Windows.Forms.TextBox();
		this.txtIntakeTime = new System.Windows.Forms.TextBox();
		this.txtHome = new System.Windows.Forms.TextBox();
		this.txtPosition = new System.Windows.Forms.TextBox();
		this.txtProbe = new System.Windows.Forms.TextBox();
		this.GroupBox1 = new System.Windows.Forms.GroupBox();
		this.btnTestPosns = new System.Windows.Forms.Button();
		this.btnPumpReverse = new System.Windows.Forms.Button();
		this.btnPumpForward = new System.Windows.Forms.Button();
		this.btnProbe = new System.Windows.Forms.Button();
		this.btnGoto = new System.Windows.Forms.Button();
		this.btnHome = new System.Windows.Forms.Button();
		this.GroupBox2 = new System.Windows.Forms.GroupBox();
		this.GroupBox3 = new System.Windows.Forms.GroupBox();
		this.GroupBox1.SuspendLayout();
		this.GroupBox2.SuspendLayout();
		this.GroupBox3.SuspendLayout();
		this.SuspendLayout();
		//
		//lblHome
		//
		this.lblHome.Location = new System.Drawing.Point(16, 21);
		this.lblHome.Name = "lblHome";
		this.lblHome.Size = new System.Drawing.Size(80, 32);
		this.lblHome.TabIndex = 10;
		this.lblHome.Text = "Home :";
		this.lblHome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//lblPosition
		//
		this.lblPosition.Location = new System.Drawing.Point(16, 69);
		this.lblPosition.Name = "lblPosition";
		this.lblPosition.Size = new System.Drawing.Size(80, 32);
		this.lblPosition.TabIndex = 11;
		this.lblPosition.Text = "Position :";
		this.lblPosition.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//lblProbe
		//
		this.lblProbe.Location = new System.Drawing.Point(16, 117);
		this.lblProbe.Name = "lblProbe";
		this.lblProbe.Size = new System.Drawing.Size(80, 32);
		this.lblProbe.TabIndex = 12;
		this.lblProbe.Text = "Probe :";
		this.lblProbe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//lblWashTime
		//
		this.lblWashTime.Location = new System.Drawing.Point(16, 56);
		this.lblWashTime.Name = "lblWashTime";
		this.lblWashTime.Size = new System.Drawing.Size(126, 24);
		this.lblWashTime.TabIndex = 19;
		this.lblWashTime.Text = "Sample Wash Time :";
		this.lblWashTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//lblIntakeTime
		//
		this.lblIntakeTime.Location = new System.Drawing.Point(16, 21);
		this.lblIntakeTime.Name = "lblIntakeTime";
		this.lblIntakeTime.Size = new System.Drawing.Size(126, 24);
		this.lblIntakeTime.TabIndex = 18;
		this.lblIntakeTime.Text = "Sample Intake Time :";
		this.lblIntakeTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//btnCancel
		//
		this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.btnCancel.Image = (System.Drawing.Image)resources.GetObject("btnCancel.Image");
		this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnCancel.Location = new System.Drawing.Point(272, 280);
		this.btnCancel.Name = "btnCancel";
		this.btnCancel.Size = new System.Drawing.Size(88, 32);
		this.btnCancel.TabIndex = 13;
		this.btnCancel.Text = "&Cancel";
		//
		//lblPump
		//
		this.lblPump.Location = new System.Drawing.Point(16, 165);
		this.lblPump.Name = "lblPump";
		this.lblPump.Size = new System.Drawing.Size(80, 32);
		this.lblPump.TabIndex = 14;
		this.lblPump.Text = "Pump :";
		this.lblPump.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//txtPump
		//
		this.txtPump.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txtPump.Location = new System.Drawing.Point(96, 176);
		this.txtPump.MaxLength = 10;
		this.txtPump.Name = "txtPump";
		this.txtPump.Size = new System.Drawing.Size(64, 21);
		this.txtPump.TabIndex = 20;
		this.txtPump.Text = "";
		//
		//txtWashTime
		//
		this.txtWashTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txtWashTime.Location = new System.Drawing.Point(160, 59);
		this.txtWashTime.Name = "txtWashTime";
		this.txtWashTime.Size = new System.Drawing.Size(80, 21);
		this.txtWashTime.TabIndex = 22;
		this.txtWashTime.Text = "";
		//
		//txtIntakeTime
		//
		this.txtIntakeTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txtIntakeTime.Location = new System.Drawing.Point(160, 24);
		this.txtIntakeTime.MaxLength = 10;
		this.txtIntakeTime.Name = "txtIntakeTime";
		this.txtIntakeTime.Size = new System.Drawing.Size(80, 21);
		this.txtIntakeTime.TabIndex = 21;
		this.txtIntakeTime.Text = "";
		//
		//txtHome
		//
		this.txtHome.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txtHome.Location = new System.Drawing.Point(96, 32);
		this.txtHome.MaxLength = 7;
		this.txtHome.Name = "txtHome";
		this.txtHome.Size = new System.Drawing.Size(64, 21);
		this.txtHome.TabIndex = 15;
		this.txtHome.Text = "";
		//
		//txtPosition
		//
		this.txtPosition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txtPosition.Location = new System.Drawing.Point(96, 80);
		this.txtPosition.MaxLength = 10;
		this.txtPosition.Name = "txtPosition";
		this.txtPosition.Size = new System.Drawing.Size(64, 21);
		this.txtPosition.TabIndex = 16;
		this.txtPosition.Text = "";
		//
		//txtProbe
		//
		this.txtProbe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txtProbe.Location = new System.Drawing.Point(96, 128);
		this.txtProbe.MaxLength = 10;
		this.txtProbe.Name = "txtProbe";
		this.txtProbe.Size = new System.Drawing.Size(64, 21);
		this.txtProbe.TabIndex = 17;
		this.txtProbe.Text = "";
		//
		//GroupBox1
		//
		this.GroupBox1.BackColor = System.Drawing.Color.AliceBlue;
		this.GroupBox1.Controls.Add(this.btnTestPosns);
		this.GroupBox1.Controls.Add(this.btnPumpReverse);
		this.GroupBox1.Controls.Add(this.btnPumpForward);
		this.GroupBox1.Controls.Add(this.btnProbe);
		this.GroupBox1.Controls.Add(this.btnGoto);
		this.GroupBox1.Controls.Add(this.btnHome);
		this.GroupBox1.Location = new System.Drawing.Point(0, 0);
		this.GroupBox1.Name = "GroupBox1";
		this.GroupBox1.Size = new System.Drawing.Size(176, 216);
		this.GroupBox1.TabIndex = 23;
		this.GroupBox1.TabStop = false;
		this.GroupBox1.Text = "Auto Sampler Commands";
		//
		//btnTestPosns
		//
		this.btnTestPosns.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.btnTestPosns.Location = new System.Drawing.Point(16, 184);
		this.btnTestPosns.Name = "btnTestPosns";
		this.btnTestPosns.Size = new System.Drawing.Size(144, 24);
		this.btnTestPosns.TabIndex = 5;
		this.btnTestPosns.Text = "Test All Positions";
		//
		//btnPumpReverse
		//
		this.btnPumpReverse.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.btnPumpReverse.Location = new System.Drawing.Point(16, 152);
		this.btnPumpReverse.Name = "btnPumpReverse";
		this.btnPumpReverse.Size = new System.Drawing.Size(144, 24);
		this.btnPumpReverse.TabIndex = 4;
		this.btnPumpReverse.Text = "Pump ON (R)";
		//
		//btnPumpForward
		//
		this.btnPumpForward.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.btnPumpForward.Location = new System.Drawing.Point(16, 120);
		this.btnPumpForward.Name = "btnPumpForward";
		this.btnPumpForward.Size = new System.Drawing.Size(144, 24);
		this.btnPumpForward.TabIndex = 3;
		this.btnPumpForward.Text = "Pump ON (F)";
		//
		//btnProbe
		//
		this.btnProbe.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.btnProbe.Location = new System.Drawing.Point(16, 88);
		this.btnProbe.Name = "btnProbe";
		this.btnProbe.Size = new System.Drawing.Size(144, 24);
		this.btnProbe.TabIndex = 2;
		this.btnProbe.Text = "Probe Down";
		//
		//btnGoto
		//
		this.btnGoto.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.btnGoto.Location = new System.Drawing.Point(16, 56);
		this.btnGoto.Name = "btnGoto";
		this.btnGoto.Size = new System.Drawing.Size(144, 24);
		this.btnGoto.TabIndex = 1;
		this.btnGoto.Text = "Go To";
		//
		//btnHome
		//
		this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.btnHome.Location = new System.Drawing.Point(16, 24);
		this.btnHome.Name = "btnHome";
		this.btnHome.Size = new System.Drawing.Size(144, 24);
		this.btnHome.TabIndex = 0;
		this.btnHome.Text = "Sampler Home";
		//
		//GroupBox2
		//
		this.GroupBox2.BackColor = System.Drawing.Color.AliceBlue;
		this.GroupBox2.Controls.Add(this.lblPosition);
		this.GroupBox2.Controls.Add(this.lblHome);
		this.GroupBox2.Controls.Add(this.txtHome);
		this.GroupBox2.Controls.Add(this.txtPosition);
		this.GroupBox2.Controls.Add(this.lblProbe);
		this.GroupBox2.Controls.Add(this.txtProbe);
		this.GroupBox2.Controls.Add(this.lblPump);
		this.GroupBox2.Controls.Add(this.txtPump);
		this.GroupBox2.Location = new System.Drawing.Point(184, 0);
		this.GroupBox2.Name = "GroupBox2";
		this.GroupBox2.Size = new System.Drawing.Size(176, 216);
		this.GroupBox2.TabIndex = 24;
		this.GroupBox2.TabStop = false;
		this.GroupBox2.Text = "Sampler Status";
		//
		//GroupBox3
		//
		this.GroupBox3.Controls.Add(this.lblWashTime);
		this.GroupBox3.Controls.Add(this.lblIntakeTime);
		this.GroupBox3.Controls.Add(this.txtWashTime);
		this.GroupBox3.Controls.Add(this.txtIntakeTime);
		this.GroupBox3.Location = new System.Drawing.Point(0, 224);
		this.GroupBox3.Name = "GroupBox3";
		this.GroupBox3.Size = new System.Drawing.Size(256, 88);
		this.GroupBox3.TabIndex = 25;
		this.GroupBox3.TabStop = false;
		//
		//AutoSampler
		//
		this.AcceptButton = this.btnCancel;
		this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
		this.BackColor = System.Drawing.Color.AliceBlue;
		this.ClientSize = new System.Drawing.Size(370, 319);
		this.Controls.Add(this.GroupBox3);
		this.Controls.Add(this.GroupBox2);
		this.Controls.Add(this.GroupBox1);
		this.Controls.Add(this.btnCancel);
		this.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
		this.MaximizeBox = false;
		this.MinimizeBox = false;
		this.Name = "AutoSampler";
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "AutoSampler Interface";
		this.GroupBox1.ResumeLayout(false);
		this.GroupBox2.ResumeLayout(false);
		this.GroupBox3.ResumeLayout(false);
		this.ResumeLayout(false);

	}

	#End Region


	private void  // ERROR: Handles clauses are not supported in C#
Button1_Click(System.Object sender, System.EventArgs e)
	{
	}


	private void  // ERROR: Handles clauses are not supported in C#
Button4_Click(System.Object sender, System.EventArgs e)
	{
	}
}
