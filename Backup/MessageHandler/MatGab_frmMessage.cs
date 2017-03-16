public class frmMessage : System.Windows.Forms.Form
{

	#Region " Windows Form Designer generated code "

	public frmMessage()
	{
		base.New();

		//This call is required by the Windows Form Designer.
		InitializeComponent();

		//Add any initialization after the InitializeComponent() call
		//Me.CustomPanelBackground.BringToFront()

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
	internal System.Windows.Forms.ImageList ImgLstMessage;
	internal System.Windows.Forms.PictureBox picMessage;
	internal CodeIntellects.Office2003Controls.Office2003HeaderSub Office2003HeaderSubMessage;
	internal NETXP.Controls.XPButton cmdyes;
	internal NETXP.Controls.XPButton cmdno;
	internal NETXP.Controls.XPButton cmdok;
	internal System.Windows.Forms.Label lblMessage;
	[System.Diagnostics.DebuggerStepThrough()]
	private void InitializeComponent()
	{
		this.components = new System.ComponentModel.Container();
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMessage));
		this.ImgLstMessage = new System.Windows.Forms.ImageList(this.components);
		this.Office2003HeaderSubMessage = new CodeIntellects.Office2003Controls.Office2003HeaderSub();
		this.cmdno = new NETXP.Controls.XPButton();
		this.cmdyes = new NETXP.Controls.XPButton();
		this.picMessage = new System.Windows.Forms.PictureBox();
		this.lblMessage = new System.Windows.Forms.Label();
		this.cmdok = new NETXP.Controls.XPButton();
		this.Office2003HeaderSubMessage.SuspendLayout();
		this.SuspendLayout();
		//
		//ImgLstMessage
		//
		this.ImgLstMessage.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
		this.ImgLstMessage.ImageSize = new System.Drawing.Size(32, 32);
		this.ImgLstMessage.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("ImgLstMessage.ImageStream");
		this.ImgLstMessage.TransparentColor = System.Drawing.Color.Transparent;
		//
		//Office2003HeaderSubMessage
		//
		this.Office2003HeaderSubMessage.BackColor = System.Drawing.Color.Transparent;
		this.Office2003HeaderSubMessage.Controls.Add(this.cmdno);
		this.Office2003HeaderSubMessage.Controls.Add(this.cmdyes);
		this.Office2003HeaderSubMessage.Controls.Add(this.picMessage);
		this.Office2003HeaderSubMessage.Controls.Add(this.lblMessage);
		this.Office2003HeaderSubMessage.Controls.Add(this.cmdok);
		this.Office2003HeaderSubMessage.Dock = System.Windows.Forms.DockStyle.Fill;
		this.Office2003HeaderSubMessage.Location = new System.Drawing.Point(0, 0);
		this.Office2003HeaderSubMessage.Name = "Office2003HeaderSubMessage";
		this.Office2003HeaderSubMessage.Size = new System.Drawing.Size(434, 199);
		this.Office2003HeaderSubMessage.TabIndex = 17;
		this.Office2003HeaderSubMessage.TitleColor = System.Drawing.Color.Black;
		this.Office2003HeaderSubMessage.TitleFont = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.Office2003HeaderSubMessage.TitleText = "Message Title";
		//
		//cmdno
		//
		this.cmdno.BackColor = System.Drawing.Color.AliceBlue;
		this.cmdno.DialogResult = System.Windows.Forms.DialogResult.No;
		this.cmdno.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.cmdno.Font = new System.Drawing.Font("Arial", 9.75f);
		this.cmdno.Image = (System.Drawing.Image)resources.GetObject("cmdno.Image");
		this.cmdno.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.cmdno.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.cmdno.Location = new System.Drawing.Point(239, 131);
		this.cmdno.Name = "cmdno";
		this.cmdno.Size = new System.Drawing.Size(88, 40);
		this.cmdno.TabIndex = 18;
		this.cmdno.Text = "&NO";
		//
		//cmdyes
		//
		this.cmdyes.BackColor = System.Drawing.Color.AliceBlue;
		this.cmdyes.DialogResult = System.Windows.Forms.DialogResult.Yes;
		this.cmdyes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.cmdyes.Font = new System.Drawing.Font("Arial", 9.75f);
		this.cmdyes.Image = (System.Drawing.Image)resources.GetObject("cmdyes.Image");
		this.cmdyes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.cmdyes.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.cmdyes.Location = new System.Drawing.Point(136, 131);
		this.cmdyes.Name = "cmdyes";
		this.cmdyes.Size = new System.Drawing.Size(88, 40);
		this.cmdyes.TabIndex = 17;
		this.cmdyes.Text = "&YES";
		//
		//picMessage
		//
		this.picMessage.Image = (System.Drawing.Image)resources.GetObject("picMessage.Image");
		this.picMessage.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.picMessage.Location = new System.Drawing.Point(10, 41);
		this.picMessage.Name = "picMessage";
		this.picMessage.Size = new System.Drawing.Size(38, 64);
		this.picMessage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
		this.picMessage.TabIndex = 12;
		this.picMessage.TabStop = false;
		//
		//lblMessage
		//
		this.lblMessage.BackColor = System.Drawing.Color.Transparent;
		this.lblMessage.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold);
		this.lblMessage.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.lblMessage.Location = new System.Drawing.Point(64, 27);
		this.lblMessage.Name = "lblMessage";
		this.lblMessage.Size = new System.Drawing.Size(360, 96);
		this.lblMessage.TabIndex = 16;
		this.lblMessage.Text = "AAS";
		this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		//
		//cmdok
		//
		this.cmdok.BackColor = System.Drawing.Color.AliceBlue;
		this.cmdok.DialogResult = System.Windows.Forms.DialogResult.OK;
		this.cmdok.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.cmdok.Font = new System.Drawing.Font("Arial", 9.75f);
		this.cmdok.Image = (System.Drawing.Image)resources.GetObject("cmdok.Image");
		this.cmdok.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.cmdok.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.cmdok.Location = new System.Drawing.Point(192, 131);
		this.cmdok.Name = "cmdok";
		this.cmdok.Size = new System.Drawing.Size(88, 40);
		this.cmdok.TabIndex = 19;
		this.cmdok.Text = "&OK";
		//
		//frmMessage
		//
		this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
		this.BackColor = System.Drawing.Color.AliceBlue;
		this.ClientSize = new System.Drawing.Size(434, 199);
		this.ControlBox = false;
		this.Controls.Add(this.Office2003HeaderSubMessage);
		this.Font = new System.Drawing.Font("Arial", 9f);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		this.MaximizeBox = false;
		this.MinimizeBox = false;
		this.Name = "frmMessage";
		this.ShowInTaskbar = false;
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "AAS";
		this.TopMost = true;
		this.Office2003HeaderSubMessage.ResumeLayout(false);
		this.ResumeLayout(false);

	}

	#End Region


}
