public class frmMessageFlame : System.Windows.Forms.Form
{

	#Region " Property Defination"
	string mptrMessageTest = "Ready for flame. AA or N2O," + vbLf + "else Cancel";
	public string MessageTest {
		get { return mptrMessageTest; }
		set { mptrMessageTest = Value; }
	}
	#End Region

	#Region " Windows Form Designer generated code "

	public frmMessageFlame()
	{
		base.New();

		//This call is required by the Windows Form Designer.
		InitializeComponent();

		//Add any initialization after the InitializeComponent() call
		//Me.CustomPanelBackground.BringToFront()
		InitialiseObject();
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
	internal System.Windows.Forms.Label lblMessage;
	internal NETXP.Controls.XPButton cmdCancel;
	internal NETXP.Controls.XPButton cmdYes;
	internal NETXP.Controls.XPButton cmdNo;
	[System.Diagnostics.DebuggerStepThrough()]
	private void InitializeComponent()
	{
		this.components = new System.ComponentModel.Container();
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMessageFlame));
		this.ImgLstMessage = new System.Windows.Forms.ImageList(this.components);
		this.Office2003HeaderSubMessage = new CodeIntellects.Office2003Controls.Office2003HeaderSub();
		this.cmdCancel = new NETXP.Controls.XPButton();
		this.cmdYes = new NETXP.Controls.XPButton();
		this.picMessage = new System.Windows.Forms.PictureBox();
		this.cmdNo = new NETXP.Controls.XPButton();
		this.lblMessage = new System.Windows.Forms.Label();
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
		this.Office2003HeaderSubMessage.Controls.Add(this.cmdCancel);
		this.Office2003HeaderSubMessage.Controls.Add(this.cmdYes);
		this.Office2003HeaderSubMessage.Controls.Add(this.picMessage);
		this.Office2003HeaderSubMessage.Controls.Add(this.cmdNo);
		this.Office2003HeaderSubMessage.Controls.Add(this.lblMessage);
		this.Office2003HeaderSubMessage.Dock = System.Windows.Forms.DockStyle.Fill;
		this.Office2003HeaderSubMessage.Location = new System.Drawing.Point(0, 0);
		this.Office2003HeaderSubMessage.Name = "Office2003HeaderSubMessage";
		this.Office2003HeaderSubMessage.Size = new System.Drawing.Size(434, 175);
		this.Office2003HeaderSubMessage.TabIndex = 17;
		this.Office2003HeaderSubMessage.TitleColor = System.Drawing.Color.Black;
		this.Office2003HeaderSubMessage.TitleFont = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.Office2003HeaderSubMessage.TitleText = "Message Title";
		//
		//cmdCancel
		//
		this.cmdCancel.BackColor = System.Drawing.Color.AliceBlue;
		this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.cmdCancel.Font = new System.Drawing.Font("Arial", 9.75f);
		this.cmdCancel.Image = (System.Drawing.Image)resources.GetObject("cmdCancel.Image");
		this.cmdCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.cmdCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.cmdCancel.Location = new System.Drawing.Point(278, 120);
		this.cmdCancel.Name = "cmdCancel";
		this.cmdCancel.Size = new System.Drawing.Size(112, 40);
		this.cmdCancel.TabIndex = 18;
		this.cmdCancel.Text = "&Cancel";
		//
		//cmdYes
		//
		this.cmdYes.BackColor = System.Drawing.Color.AliceBlue;
		this.cmdYes.DialogResult = System.Windows.Forms.DialogResult.Yes;
		this.cmdYes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.cmdYes.Font = new System.Drawing.Font("Arial", 9.75f);
		this.cmdYes.Image = (System.Drawing.Image)resources.GetObject("cmdYes.Image");
		this.cmdYes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.cmdYes.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.cmdYes.Location = new System.Drawing.Point(38, 120);
		this.cmdYes.Name = "cmdYes";
		this.cmdYes.Size = new System.Drawing.Size(112, 40);
		this.cmdYes.TabIndex = 17;
		this.cmdYes.Text = "&AA Flame";
		this.cmdYes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
		//cmdNo
		//
		this.cmdNo.BackColor = System.Drawing.Color.AliceBlue;
		this.cmdNo.DialogResult = System.Windows.Forms.DialogResult.No;
		this.cmdNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.cmdNo.Font = new System.Drawing.Font("Arial", 9.75f);
		this.cmdNo.Image = (System.Drawing.Image)resources.GetObject("cmdNo.Image");
		this.cmdNo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.cmdNo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.cmdNo.Location = new System.Drawing.Point(158, 120);
		this.cmdNo.Name = "cmdNo";
		this.cmdNo.Size = new System.Drawing.Size(112, 40);
		this.cmdNo.TabIndex = 19;
		this.cmdNo.Text = "&NA Flame";
		this.cmdNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		//
		//lblMessage
		//
		this.lblMessage.BackColor = System.Drawing.Color.Transparent;
		this.lblMessage.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold);
		this.lblMessage.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.lblMessage.Location = new System.Drawing.Point(64, 24);
		this.lblMessage.Name = "lblMessage";
		this.lblMessage.Size = new System.Drawing.Size(312, 88);
		this.lblMessage.TabIndex = 16;
		this.lblMessage.Text = "AAS";
		this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		//
		//frmMessageFlame
		//
		this.AcceptButton = this.cmdNo;
		this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
		this.BackColor = System.Drawing.Color.AliceBlue;
		this.CancelButton = this.cmdCancel;
		this.ClientSize = new System.Drawing.Size(434, 175);
		this.Controls.Add(this.Office2003HeaderSubMessage);
		this.Font = new System.Drawing.Font("Arial", 9f);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		this.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		this.MaximizeBox = false;
		this.MinimizeBox = false;
		this.Name = "frmMessageFlame";
		this.ShowInTaskbar = false;
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "AAS";
		this.TopMost = true;
		this.Office2003HeaderSubMessage.ResumeLayout(false);
		this.ResumeLayout(false);

	}

	#End Region

	private void InitialiseObject()
	{
		lblMessage.Text = MessageTest;
		if (!this.ImgLstMessage.Images.Count == 0) {
			this.picMessage.Image = this.ImgLstMessage.Images(2);
		}
	}


	private void  // ERROR: Handles clauses are not supported in C#
cmdCancel_Click(System.Object sender, System.EventArgs e)
	{
	}
}
