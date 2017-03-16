public class frmHelpAbout : System.Windows.Forms.Form
{

	#Region " Windows Form Designer generated code "

	public frmHelpAbout()
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
	internal System.Windows.Forms.PictureBox AAS_picture;
	internal System.Windows.Forms.PictureBox aasDB_picture;
	internal System.Windows.Forms.Label lblVersion;
	internal System.Windows.Forms.Label lblCompany;
	[System.Diagnostics.DebuggerStepThrough()]
	private void InitializeComponent()
	{
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmHelpAbout));
		this.AAS_picture = new System.Windows.Forms.PictureBox();
		this.aasDB_picture = new System.Windows.Forms.PictureBox();
		this.lblVersion = new System.Windows.Forms.Label();
		this.lblCompany = new System.Windows.Forms.Label();
		this.SuspendLayout();
		//
		//AAS_picture
		//
		this.AAS_picture.Dock = System.Windows.Forms.DockStyle.Fill;
		this.AAS_picture.Image = (System.Drawing.Image)resources.GetObject("AAS_picture.Image");
		this.AAS_picture.Location = new System.Drawing.Point(0, 0);
		this.AAS_picture.Name = "AAS_picture";
		this.AAS_picture.Size = new System.Drawing.Size(486, 340);
		this.AAS_picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.AAS_picture.TabIndex = 0;
		this.AAS_picture.TabStop = false;
		//
		//aasDB_picture
		//
		this.aasDB_picture.Dock = System.Windows.Forms.DockStyle.Fill;
		this.aasDB_picture.Image = (System.Drawing.Image)resources.GetObject("aasDB_picture.Image");
		this.aasDB_picture.Location = new System.Drawing.Point(0, 0);
		this.aasDB_picture.Name = "aasDB_picture";
		this.aasDB_picture.Size = new System.Drawing.Size(486, 340);
		this.aasDB_picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.aasDB_picture.TabIndex = 1;
		this.aasDB_picture.TabStop = false;
		//
		//lblVersion
		//
		this.lblVersion.BackColor = System.Drawing.Color.White;
		this.lblVersion.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblVersion.Location = new System.Drawing.Point(24, 135);
		this.lblVersion.Name = "lblVersion";
		this.lblVersion.Size = new System.Drawing.Size(472, 24);
		this.lblVersion.TabIndex = 2;
		//
		//lblCompany
		//
		this.lblCompany.BackColor = System.Drawing.Color.White;
		this.lblCompany.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblCompany.Location = new System.Drawing.Point(24, 161);
		this.lblCompany.Name = "lblCompany";
		this.lblCompany.Size = new System.Drawing.Size(472, 24);
		this.lblCompany.TabIndex = 3;
		//
		//frmHelpAbout
		//
		this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
		this.ClientSize = new System.Drawing.Size(486, 340);
		this.Controls.Add(this.aasDB_picture);
		this.Controls.Add(this.lblCompany);
		this.Controls.Add(this.lblVersion);
		this.Controls.Add(this.AAS_picture);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
		this.MaximizeBox = false;
		this.MinimizeBox = false;
		this.Name = "frmHelpAbout";
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "About";
		this.ResumeLayout(false);

	}

	#End Region

	private void  // ERROR: Handles clauses are not supported in C#
frmHelpAbout_Load(object sender, System.EventArgs e)
	{
		lblVersion.BringToFront();
		lblCompany.BringToFront();
		lblVersion.Text = gstrTitleInstrumentType + Space(1) + "Software Version :" + Space(1) + Mid(Application.ProductVersion, 1, 4);
		lblCompany.Text = gConst_AboutCompany;
	}

}
