public class frmChangePort : System.Windows.Forms.Form
{

	#Region " Windows Form Designer generated code "

	public frmChangePort()
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
	internal NETXP.Controls.XPButton btnCancel;
	internal NETXP.Controls.XPButton btnOk;
	internal System.Windows.Forms.GroupBox gbRS232C;
	internal System.Windows.Forms.ComboBox cmbSelectPort;
	internal System.Windows.Forms.Label lblSelectPort;
	[System.Diagnostics.DebuggerStepThrough()]
	private void InitializeComponent()
	{
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmChangePort));
		this.CustomPanel1 = new GradientPanel.CustomPanel();
		this.btnCancel = new NETXP.Controls.XPButton();
		this.btnOk = new NETXP.Controls.XPButton();
		this.gbRS232C = new System.Windows.Forms.GroupBox();
		this.cmbSelectPort = new System.Windows.Forms.ComboBox();
		this.lblSelectPort = new System.Windows.Forms.Label();
		this.CustomPanel1.SuspendLayout();
		this.gbRS232C.SuspendLayout();
		this.SuspendLayout();
		//
		//CustomPanel1
		//
		this.CustomPanel1.BackColor = System.Drawing.Color.AliceBlue;
		this.CustomPanel1.Controls.Add(this.btnCancel);
		this.CustomPanel1.Controls.Add(this.btnOk);
		this.CustomPanel1.Controls.Add(this.gbRS232C);
		this.CustomPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.CustomPanel1.Location = new System.Drawing.Point(0, 0);
		this.CustomPanel1.Name = "CustomPanel1";
		this.CustomPanel1.Size = new System.Drawing.Size(312, 181);
		this.CustomPanel1.TabIndex = 0;
		//
		//btnCancel
		//
		this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnCancel.Image = (System.Drawing.Image)resources.GetObject("btnCancel.Image");
		this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnCancel.Location = new System.Drawing.Point(160, 120);
		this.btnCancel.Name = "btnCancel";
		this.btnCancel.Size = new System.Drawing.Size(86, 34);
		this.btnCancel.TabIndex = 10;
		this.btnCancel.Text = "Cancel";
		//
		//btnOk
		//
		this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnOk.Image = (System.Drawing.Image)resources.GetObject("btnOk.Image");
		this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnOk.Location = new System.Drawing.Point(56, 120);
		this.btnOk.Name = "btnOk";
		this.btnOk.Size = new System.Drawing.Size(86, 34);
		this.btnOk.TabIndex = 9;
		this.btnOk.Text = "OK";
		//
		//gbRS232C
		//
		this.gbRS232C.Controls.Add(this.cmbSelectPort);
		this.gbRS232C.Controls.Add(this.lblSelectPort);
		this.gbRS232C.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.gbRS232C.Location = new System.Drawing.Point(28, 27);
		this.gbRS232C.Name = "gbRS232C";
		this.gbRS232C.Size = new System.Drawing.Size(256, 77);
		this.gbRS232C.TabIndex = 1;
		this.gbRS232C.TabStop = false;
		this.gbRS232C.Text = "RS232C";
		//
		//cmbSelectPort
		//
		this.cmbSelectPort.Location = new System.Drawing.Point(147, 29);
		this.cmbSelectPort.Name = "cmbSelectPort";
		this.cmbSelectPort.Size = new System.Drawing.Size(80, 23);
		this.cmbSelectPort.TabIndex = 1;
		//
		//lblSelectPort
		//
		this.lblSelectPort.Location = new System.Drawing.Point(16, 24);
		this.lblSelectPort.Name = "lblSelectPort";
		this.lblSelectPort.Size = new System.Drawing.Size(224, 32);
		this.lblSelectPort.TabIndex = 0;
		this.lblSelectPort.Text = "   Select a COM port";
		this.lblSelectPort.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//frmChangePort
		//
		this.AcceptButton = this.btnOk;
		this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
		this.CancelButton = this.btnCancel;
		this.ClientSize = new System.Drawing.Size(312, 181);
		this.Controls.Add(this.CustomPanel1);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		this.MaximizeBox = false;
		this.MinimizeBox = false;
		this.Name = "frmChangePort";
		this.ShowInTaskbar = false;
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Communication Parameters";
		this.CustomPanel1.ResumeLayout(false);
		this.gbRS232C.ResumeLayout(false);
		this.ResumeLayout(false);

	}

	#End Region

}
