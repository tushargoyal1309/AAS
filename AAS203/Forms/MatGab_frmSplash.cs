public class frmSplash : System.Windows.Forms.Form
{

	#Region " Windows Form Designer generated code "

	public frmSplash()
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
	internal System.Windows.Forms.PictureBox PictureBox1;
	internal System.Windows.Forms.PictureBox PictureBox2_DB;
	[System.Diagnostics.DebuggerStepThrough()]
	private void InitializeComponent()
	{
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmSplash));
		this.PictureBox1 = new System.Windows.Forms.PictureBox();
		this.PictureBox2_DB = new System.Windows.Forms.PictureBox();
		this.SuspendLayout();
		//
		//PictureBox1
		//
		this.PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.PictureBox1.Image = (System.Drawing.Image)resources.GetObject("PictureBox1.Image");
		this.PictureBox1.Location = new System.Drawing.Point(0, 0);
		this.PictureBox1.Name = "PictureBox1";
		this.PictureBox1.Size = new System.Drawing.Size(442, 242);
		this.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.PictureBox1.TabIndex = 0;
		this.PictureBox1.TabStop = false;
		//
		//PictureBox2_DB
		//
		this.PictureBox2_DB.Dock = System.Windows.Forms.DockStyle.Fill;
		this.PictureBox2_DB.Image = (System.Drawing.Image)resources.GetObject("PictureBox2_DB.Image");
		this.PictureBox2_DB.Location = new System.Drawing.Point(0, 0);
		this.PictureBox2_DB.Name = "PictureBox2_DB";
		this.PictureBox2_DB.Size = new System.Drawing.Size(442, 242);
		this.PictureBox2_DB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.PictureBox2_DB.TabIndex = 1;
		this.PictureBox2_DB.TabStop = false;
		this.PictureBox2_DB.Visible = false;
		//
		//frmSplash
		//
		this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
		this.BackColor = System.Drawing.Color.Gainsboro;
		this.ClientSize = new System.Drawing.Size(442, 242);
		this.ControlBox = false;
		this.Controls.Add(this.PictureBox2_DB);
		this.Controls.Add(this.PictureBox1);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		this.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		this.Name = "frmSplash";
		this.ShowInTaskbar = false;
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.TransparencyKey = System.Drawing.Color.Transparent;
		this.ResumeLayout(false);

	}

	#End Region

	private void  // ERROR: Handles clauses are not supported in C#
frmSplash_Load(object sender, System.EventArgs e)
	{
		try {
			if (gstructSettings.AppMode == EnumAppMode.FullVersion_203D | gstructSettings.AppMode == EnumAppMode.DemoMode_203D) {
				PictureBox2_DB.Visible = true;
				PictureBox1.Visible = false;
				PictureBox2_DB.Refresh();
				PictureBox1.Refresh();
			}
			Application.DoEvents();
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
		}
	}

}
