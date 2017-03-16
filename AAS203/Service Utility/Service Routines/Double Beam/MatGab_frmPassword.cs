public class frmPassword : System.Windows.Forms.Form
{

	#Region " Windows Form Designer generated code "

	public frmPassword()
	{
		base.New();

		//This call is required by the Windows Form Designer.
		InitializeComponent();

		//Add any initialization after the InitializeComponent() call
		strPassword = "";
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
	internal System.Windows.Forms.Label Label1;
	internal System.Windows.Forms.TextBox txtPassword;
	internal NETXP.Controls.XPButton btnOk;
	internal NETXP.Controls.XPButton btnClose;
	[System.Diagnostics.DebuggerStepThrough()]
	private void InitializeComponent()
	{
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmPassword));
		this.txtPassword = new System.Windows.Forms.TextBox();
		this.Label1 = new System.Windows.Forms.Label();
		this.btnOk = new NETXP.Controls.XPButton();
		this.btnClose = new NETXP.Controls.XPButton();
		this.SuspendLayout();
		//
		//txtPassword
		//
		this.txtPassword.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.txtPassword.Location = new System.Drawing.Point(80, 22);
		this.txtPassword.Name = "txtPassword";
		this.txtPassword.PasswordChar = Microsoft.VisualBasic.ChrW(42);
		this.txtPassword.Size = new System.Drawing.Size(184, 22);
		this.txtPassword.TabIndex = 0;
		this.txtPassword.Text = "";
		//
		//Label1
		//
		this.Label1.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.Label1.Location = new System.Drawing.Point(8, 24);
		this.Label1.Name = "Label1";
		this.Label1.Size = new System.Drawing.Size(72, 16);
		this.Label1.TabIndex = 1;
		this.Label1.Text = "Password";
		//
		//btnOk
		//
		this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnOk.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnOk.Image = (System.Drawing.Image)resources.GetObject("btnOk.Image");
		this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnOk.Location = new System.Drawing.Point(80, 56);
		this.btnOk.Name = "btnOk";
		this.btnOk.Size = new System.Drawing.Size(88, 32);
		this.btnOk.TabIndex = 7;
		this.btnOk.Text = "&OK";
		//
		//btnClose
		//
		this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnClose.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnClose.Image = (System.Drawing.Image)resources.GetObject("btnClose.Image");
		this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnClose.Location = new System.Drawing.Point(176, 56);
		this.btnClose.Name = "btnClose";
		this.btnClose.Size = new System.Drawing.Size(88, 32);
		this.btnClose.TabIndex = 12;
		this.btnClose.Text = "&Cancel";
		//
		//frmPassword
		//
		this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
		this.BackColor = System.Drawing.Color.AliceBlue;
		this.ClientSize = new System.Drawing.Size(278, 99);
		this.ControlBox = false;
		this.Controls.Add(this.btnClose);
		this.Controls.Add(this.btnOk);
		this.Controls.Add(this.Label1);
		this.Controls.Add(this.txtPassword);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
		this.MaximizeBox = false;
		this.MinimizeBox = false;
		this.Name = "frmPassword";
		this.ShowInTaskbar = false;
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Please Enter Password";
		this.ResumeLayout(false);

	}

	#End Region

	#Region " user Variables "
	string strPassword;
	public string Password {
		get { return strPassword; }
	}
	#End Region

	#Region "Control Events"
	private void  // ERROR: Handles clauses are not supported in C#
frmPassword_Load(System.Object sender, System.EventArgs e)
	{
		strPassword = "";
	}
	private void  // ERROR: Handles clauses are not supported in C#
btnClose_Click(System.Object sender, System.EventArgs e)
	{
		strPassword = "";
		this.Close();
	}
	private void  // ERROR: Handles clauses are not supported in C#
btnOk_Click(System.Object sender, System.EventArgs e)
	{
		try {
			strPassword = txtPassword.Text.ToString();
		} catch (Exception ex) {
			strPassword = "";
		}
		this.Close();
	}
	#End Region

}
