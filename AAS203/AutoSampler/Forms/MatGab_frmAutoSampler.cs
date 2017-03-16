public class frmAutoSampler : System.Windows.Forms.Form
{

	#Region " Windows Form Designer generated code "

	public frmAutoSampler()
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
	internal System.Windows.Forms.TextBox txtWashTime;
	internal System.Windows.Forms.TextBox txtIntakeTime;
	internal System.Windows.Forms.Label lblWashTime;
	internal System.Windows.Forms.Label lblIntakeTime;
	internal System.Windows.Forms.Label Label1;
	internal System.Windows.Forms.TextBox TextBox1;
	internal System.Windows.Forms.Button Button1;
	[System.Diagnostics.DebuggerStepThrough()]
	private void InitializeComponent()
	{
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmAutoSampler));
		this.txtWashTime = new System.Windows.Forms.TextBox();
		this.txtIntakeTime = new System.Windows.Forms.TextBox();
		this.lblWashTime = new System.Windows.Forms.Label();
		this.lblIntakeTime = new System.Windows.Forms.Label();
		this.btnCancel = new System.Windows.Forms.Button();
		this.lblHome = new System.Windows.Forms.Label();
		this.lblPosition = new System.Windows.Forms.Label();
		this.lblProbe = new System.Windows.Forms.Label();
		this.z = new System.Windows.Forms.Label();
		this.txtHome = new System.Windows.Forms.TextBox();
		this.TextBox4 = new System.Windows.Forms.TextBox();
		this.TextBox5 = new System.Windows.Forms.TextBox();
		this.TextBox6 = new System.Windows.Forms.TextBox();
		this.Label1 = new System.Windows.Forms.Label();
		this.TextBox1 = new System.Windows.Forms.TextBox();
		this.Button1 = new System.Windows.Forms.Button();
		this.SuspendLayout();
		//
		//txtWashTime
		//
		this.txtWashTime.Location = new System.Drawing.Point(136, 67);
		this.txtWashTime.Name = "txtWashTime";
		this.txtWashTime.Size = new System.Drawing.Size(80, 20);
		this.txtWashTime.TabIndex = 9;
		this.txtWashTime.Text = "";
		//
		//txtIntakeTime
		//
		this.txtIntakeTime.Location = new System.Drawing.Point(136, 27);
		this.txtIntakeTime.MaxLength = 10;
		this.txtIntakeTime.Name = "txtIntakeTime";
		this.txtIntakeTime.Size = new System.Drawing.Size(80, 20);
		this.txtIntakeTime.TabIndex = 8;
		this.txtIntakeTime.Text = "";
		//
		//lblWashTime
		//
		this.lblWashTime.Location = new System.Drawing.Point(32, 23);
		this.lblWashTime.Name = "lblWashTime";
		this.lblWashTime.Size = new System.Drawing.Size(126, 24);
		this.lblWashTime.TabIndex = 7;
		this.lblWashTime.Text = "Sample Wash Time :";
		this.lblWashTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//lblIntakeTime
		//
		this.lblIntakeTime.Location = new System.Drawing.Point(10, 24);
		this.lblIntakeTime.Name = "lblIntakeTime";
		this.lblIntakeTime.Size = new System.Drawing.Size(126, 24);
		this.lblIntakeTime.TabIndex = 6;
		this.lblIntakeTime.Text = "Sample Intake Time :";
		this.lblIntakeTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//btnCancel
		//
		this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.btnCancel.Image = (System.Drawing.Image)resources.GetObject("btnCancel.Image");
		this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnCancel.Location = new System.Drawing.Point(272, 344);
		this.btnCancel.Name = "btnCancel";
		this.btnCancel.Size = new System.Drawing.Size(88, 32);
		this.btnCancel.TabIndex = 3;
		this.btnCancel.Text = "&Cancel";
		//
		//lblHome
		//
		this.lblHome.Location = new System.Drawing.Point(34, 45);
		this.lblHome.Name = "lblHome";
		this.lblHome.Size = new System.Drawing.Size(80, 32);
		this.lblHome.TabIndex = 0;
		this.lblHome.Text = "Home :";
		this.lblHome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//lblPosition
		//
		this.lblPosition.Location = new System.Drawing.Point(16, 72);
		this.lblPosition.Name = "lblPosition";
		this.lblPosition.Size = new System.Drawing.Size(80, 32);
		this.lblPosition.TabIndex = 1;
		this.lblPosition.Text = "Position :";
		this.lblPosition.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//lblProbe
		//
		this.lblProbe.Location = new System.Drawing.Point(16, 120);
		this.lblProbe.Name = "lblProbe";
		this.lblProbe.Size = new System.Drawing.Size(80, 32);
		this.lblProbe.TabIndex = 2;
		this.lblProbe.Text = "Probe :";
		this.lblProbe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//z
		//
		this.z.Location = new System.Drawing.Point(16, 168);
		this.z.Name = "z";
		this.z.Size = new System.Drawing.Size(80, 32);
		this.z.TabIndex = 3;
		this.z.Text = "Pump :";
		this.z.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//txtHome
		//
		this.txtHome.Location = new System.Drawing.Point(104, 32);
		this.txtHome.MaxLength = 7;
		this.txtHome.Name = "txtHome";
		this.txtHome.Size = new System.Drawing.Size(64, 20);
		this.txtHome.TabIndex = 4;
		this.txtHome.Text = "";
		//
		//TextBox4
		//
		this.TextBox4.Location = new System.Drawing.Point(104, 80);
		this.TextBox4.MaxLength = 10;
		this.TextBox4.Name = "TextBox4";
		this.TextBox4.Size = new System.Drawing.Size(64, 20);
		this.TextBox4.TabIndex = 5;
		this.TextBox4.Text = "";
		//
		//TextBox5
		//
		this.TextBox5.Location = new System.Drawing.Point(104, 128);
		this.TextBox5.MaxLength = 10;
		this.TextBox5.Name = "TextBox5";
		this.TextBox5.Size = new System.Drawing.Size(64, 20);
		this.TextBox5.TabIndex = 6;
		this.TextBox5.Text = "";
		//
		//TextBox6
		//
		this.TextBox6.Location = new System.Drawing.Point(104, 176);
		this.TextBox6.MaxLength = 10;
		this.TextBox6.Name = "TextBox6";
		this.TextBox6.Size = new System.Drawing.Size(64, 20);
		this.TextBox6.TabIndex = 7;
		this.TextBox6.Text = "";
		//
		//Label1
		//
		this.Label1.Location = new System.Drawing.Point(48, 64);
		this.Label1.Name = "Label1";
		this.Label1.Size = new System.Drawing.Size(96, 48);
		this.Label1.TabIndex = 4;
		this.Label1.Text = "Label1";
		//
		//TextBox1
		//
		this.TextBox1.Location = new System.Drawing.Point(96, 160);
		this.TextBox1.Name = "TextBox1";
		this.TextBox1.Size = new System.Drawing.Size(216, 21);
		this.TextBox1.TabIndex = 5;
		this.TextBox1.Text = "TextBox1";
		//
		//Button1
		//
		this.Button1.Location = new System.Drawing.Point(184, 64);
		this.Button1.Name = "Button1";
		this.Button1.Size = new System.Drawing.Size(80, 32);
		this.Button1.TabIndex = 6;
		this.Button1.Text = "Button1";
		//
		//frmAutoSampler
		//
		this.AcceptButton = this.btnCancel;
		this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
		this.BackColor = System.Drawing.Color.AliceBlue;
		this.ClientSize = new System.Drawing.Size(362, 383);
		this.Controls.Add(this.Button1);
		this.Controls.Add(this.TextBox1);
		this.Controls.Add(this.Label1);
		this.Controls.Add(this.btnCancel);
		this.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
		this.MaximizeBox = false;
		this.MinimizeBox = false;
		this.Name = "frmAutoSampler";
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "AutoSampler Interface";
		this.ResumeLayout(false);

	}

	#End Region

	internal System.Windows.Forms.TextBox TextBox6;
	internal System.Windows.Forms.TextBox TextBox5;
	internal System.Windows.Forms.TextBox TextBox4;
	internal System.Windows.Forms.TextBox txtHome;
	internal System.Windows.Forms.Label z;
	internal System.Windows.Forms.Label lblProbe;
	internal System.Windows.Forms.Label lblPosition;
	internal System.Windows.Forms.Label lblHome;

	internal System.Windows.Forms.Button btnCancel;

	private void  // ERROR: Handles clauses are not supported in C#
btnCancel_Click(System.Object sender, System.EventArgs e)
	{
	}
}
