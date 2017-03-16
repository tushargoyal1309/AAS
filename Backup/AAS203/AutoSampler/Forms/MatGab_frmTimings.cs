public class frmTimings : System.Windows.Forms.Form
{

	#Region " Windows Form Designer generated code "

	public frmTimings()
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
	internal System.Windows.Forms.GroupBox GroupBox1;
	internal System.Windows.Forms.Label lblIntakeTime;
	internal System.Windows.Forms.Label lblWaitTime;
	internal System.Windows.Forms.Label lblWashTime;
	internal System.Windows.Forms.Button btnOk;
	internal System.Windows.Forms.Button btnCancel;
	internal System.Windows.Forms.NumericUpDown NumUpDnWaitTime;
	internal System.Windows.Forms.NumericUpDown NumUpDnWashTime;
	internal System.Windows.Forms.NumericUpDown NumUpDnIntakeTime;
	[System.Diagnostics.DebuggerStepThrough()]
	private void InitializeComponent()
	{
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmTimings));
		this.GroupBox1 = new System.Windows.Forms.GroupBox();
		this.NumUpDnIntakeTime = new System.Windows.Forms.NumericUpDown();
		this.NumUpDnWashTime = new System.Windows.Forms.NumericUpDown();
		this.NumUpDnWaitTime = new System.Windows.Forms.NumericUpDown();
		this.lblWashTime = new System.Windows.Forms.Label();
		this.lblWaitTime = new System.Windows.Forms.Label();
		this.lblIntakeTime = new System.Windows.Forms.Label();
		this.btnOk = new System.Windows.Forms.Button();
		this.btnCancel = new System.Windows.Forms.Button();
		this.GroupBox1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.NumUpDnIntakeTime).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.NumUpDnWashTime).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.NumUpDnWaitTime).BeginInit();
		this.SuspendLayout();
		//
		//GroupBox1
		//
		this.GroupBox1.Controls.Add(this.NumUpDnIntakeTime);
		this.GroupBox1.Controls.Add(this.NumUpDnWashTime);
		this.GroupBox1.Controls.Add(this.NumUpDnWaitTime);
		this.GroupBox1.Controls.Add(this.lblWashTime);
		this.GroupBox1.Controls.Add(this.lblWaitTime);
		this.GroupBox1.Controls.Add(this.lblIntakeTime);
		this.GroupBox1.Location = new System.Drawing.Point(0, 0);
		this.GroupBox1.Name = "GroupBox1";
		this.GroupBox1.Size = new System.Drawing.Size(288, 144);
		this.GroupBox1.TabIndex = 0;
		this.GroupBox1.TabStop = false;
		this.GroupBox1.Text = "Timings";
		//
		//NumUpDnIntakeTime
		//
		this.NumUpDnIntakeTime.BackColor = System.Drawing.Color.FloralWhite;
		this.NumUpDnIntakeTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.NumUpDnIntakeTime.Location = new System.Drawing.Point(232, 24);
		this.NumUpDnIntakeTime.Maximum = new decimal(new int[] {
			999,
			0,
			0,
			0
		});
		this.NumUpDnIntakeTime.Minimum = new decimal(new int[] {
			1,
			0,
			0,
			0
		});
		this.NumUpDnIntakeTime.Name = "NumUpDnIntakeTime";
		this.NumUpDnIntakeTime.ReadOnly = true;
		this.NumUpDnIntakeTime.Size = new System.Drawing.Size(48, 21);
		this.NumUpDnIntakeTime.TabIndex = 6;
		this.NumUpDnIntakeTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
		this.NumUpDnIntakeTime.Value = new decimal(new int[] {
			1,
			0,
			0,
			0
		});
		//
		//NumUpDnWashTime
		//
		this.NumUpDnWashTime.BackColor = System.Drawing.Color.FloralWhite;
		this.NumUpDnWashTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.NumUpDnWashTime.Location = new System.Drawing.Point(232, 107);
		this.NumUpDnWashTime.Maximum = new decimal(new int[] {
			999,
			0,
			0,
			0
		});
		this.NumUpDnWashTime.Minimum = new decimal(new int[] {
			1,
			0,
			0,
			0
		});
		this.NumUpDnWashTime.Name = "NumUpDnWashTime";
		this.NumUpDnWashTime.ReadOnly = true;
		this.NumUpDnWashTime.Size = new System.Drawing.Size(48, 21);
		this.NumUpDnWashTime.TabIndex = 5;
		this.NumUpDnWashTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
		this.NumUpDnWashTime.Value = new decimal(new int[] {
			1,
			0,
			0,
			0
		});
		//
		//NumUpDnWaitTime
		//
		this.NumUpDnWaitTime.BackColor = System.Drawing.Color.FloralWhite;
		this.NumUpDnWaitTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.NumUpDnWaitTime.Location = new System.Drawing.Point(232, 67);
		this.NumUpDnWaitTime.Maximum = new decimal(new int[] {
			999,
			0,
			0,
			0
		});
		this.NumUpDnWaitTime.Minimum = new decimal(new int[] {
			1,
			0,
			0,
			0
		});
		this.NumUpDnWaitTime.Name = "NumUpDnWaitTime";
		this.NumUpDnWaitTime.ReadOnly = true;
		this.NumUpDnWaitTime.Size = new System.Drawing.Size(48, 21);
		this.NumUpDnWaitTime.TabIndex = 4;
		this.NumUpDnWaitTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
		this.NumUpDnWaitTime.Value = new decimal(new int[] {
			1,
			0,
			0,
			0
		});
		//
		//lblWashTime
		//
		this.lblWashTime.Location = new System.Drawing.Point(16, 104);
		this.lblWashTime.Name = "lblWashTime";
		this.lblWashTime.Size = new System.Drawing.Size(208, 24);
		this.lblWashTime.TabIndex = 2;
		this.lblWashTime.Text = "Wash Time (secs) :";
		this.lblWashTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//lblWaitTime
		//
		this.lblWaitTime.Location = new System.Drawing.Point(16, 64);
		this.lblWaitTime.Name = "lblWaitTime";
		this.lblWaitTime.Size = new System.Drawing.Size(208, 24);
		this.lblWaitTime.TabIndex = 1;
		this.lblWaitTime.Text = "Pre Measurement Wait Time(secs) :";
		this.lblWaitTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//lblIntakeTime
		//
		this.lblIntakeTime.Location = new System.Drawing.Point(16, 21);
		this.lblIntakeTime.Name = "lblIntakeTime";
		this.lblIntakeTime.Size = new System.Drawing.Size(208, 24);
		this.lblIntakeTime.TabIndex = 0;
		this.lblIntakeTime.Text = "Sample Intake Time(secs) :";
		this.lblIntakeTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//btnOk
		//
		this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
		this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.btnOk.Image = (System.Drawing.Image)resources.GetObject("btnOk.Image");
		this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnOk.Location = new System.Drawing.Point(128, 152);
		this.btnOk.Name = "btnOk";
		this.btnOk.Size = new System.Drawing.Size(72, 24);
		this.btnOk.TabIndex = 1;
		this.btnOk.Text = "&Ok";
		//
		//btnCancel
		//
		this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.btnCancel.Image = (System.Drawing.Image)resources.GetObject("btnCancel.Image");
		this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnCancel.Location = new System.Drawing.Point(216, 152);
		this.btnCancel.Name = "btnCancel";
		this.btnCancel.Size = new System.Drawing.Size(72, 24);
		this.btnCancel.TabIndex = 2;
		this.btnCancel.Text = "&Cancel";
		this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		//
		//frmTimings
		//
		this.AcceptButton = this.btnOk;
		this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
		this.BackColor = System.Drawing.Color.AliceBlue;
		this.ClientSize = new System.Drawing.Size(292, 183);
		this.Controls.Add(this.btnCancel);
		this.Controls.Add(this.btnOk);
		this.Controls.Add(this.GroupBox1);
		this.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
		this.MaximizeBox = false;
		this.MinimizeBox = false;
		this.Name = "frmTimings";
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Timings";
		this.GroupBox1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.NumUpDnIntakeTime).EndInit();
		((System.ComponentModel.ISupportInitialize)this.NumUpDnWashTime).EndInit();
		((System.ComponentModel.ISupportInitialize)this.NumUpDnWaitTime).EndInit();
		this.ResumeLayout(false);

	}

	#End Region

	private void  // ERROR: Handles clauses are not supported in C#
frmTimings_Load(System.Object sender, System.EventArgs e)
	{
		NumUpDnIntakeTime.Value = gstructAutoSampler.intIntakeTime.ToString;
		NumUpDnWaitTime.Value = gstructAutoSampler.intWaitingTime.ToString;
		NumUpDnWashTime.Value = gstructAutoSampler.intWashTime.ToString;
	}

	private void  // ERROR: Handles clauses are not supported in C#
btnOk_Click(System.Object sender, System.EventArgs e)
	{
		gstructAutoSampler.intIntakeTime = NumUpDnIntakeTime.Value;
		gstructAutoSampler.intWaitingTime = NumUpDnWaitTime.Value;
		gstructAutoSampler.intWashTime = NumUpDnWashTime.Value;
		gfuncWriteSamplerParametersToINI(gstructAutoSampler);
		this.Close();
	}

	private void  // ERROR: Handles clauses are not supported in C#
btnCancel_Click(System.Object sender, System.EventArgs e)
	{
		this.Close();
	}
}
