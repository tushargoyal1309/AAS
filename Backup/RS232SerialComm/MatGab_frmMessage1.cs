public class frmMessage1 : System.Windows.Forms.Form
{

	#Region " Windows Form Designer generated code "

	public frmMessage1()
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
	internal System.Windows.Forms.Button cmdNo;
	internal System.Windows.Forms.Button cmdYes;
	internal System.Windows.Forms.Button cmdOk;
	internal System.Windows.Forms.PictureBox picMessage;
	internal System.Windows.Forms.Label lblMessage;
	internal System.Windows.Forms.ImageList ImgLstMessage;
	internal System.Windows.Forms.GroupBox GroupBox1;
	[System.Diagnostics.DebuggerStepThrough()]
	private void InitializeComponent()
	{
		this.components = new System.ComponentModel.Container();
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMessage1));
		this.cmdNo = new System.Windows.Forms.Button();
		this.cmdYes = new System.Windows.Forms.Button();
		this.cmdOk = new System.Windows.Forms.Button();
		this.picMessage = new System.Windows.Forms.PictureBox();
		this.lblMessage = new System.Windows.Forms.Label();
		this.ImgLstMessage = new System.Windows.Forms.ImageList(this.components);
		this.GroupBox1 = new System.Windows.Forms.GroupBox();
		this.GroupBox1.SuspendLayout();
		this.SuspendLayout();
		//
		//cmdNo
		//
		this.cmdNo.AccessibleDescription = resources.GetString("cmdNo.AccessibleDescription");
		this.cmdNo.AccessibleName = resources.GetString("cmdNo.AccessibleName");
		this.cmdNo.Anchor = (System.Windows.Forms.AnchorStyles)resources.GetObject("cmdNo.Anchor");
		this.cmdNo.BackgroundImage = (System.Drawing.Image)resources.GetObject("cmdNo.BackgroundImage");
		this.cmdNo.Cursor = System.Windows.Forms.Cursors.Hand;
		this.cmdNo.DialogResult = System.Windows.Forms.DialogResult.No;
		this.cmdNo.Dock = (System.Windows.Forms.DockStyle)resources.GetObject("cmdNo.Dock");
		this.cmdNo.Enabled = (bool)resources.GetObject("cmdNo.Enabled");
		this.cmdNo.FlatStyle = (System.Windows.Forms.FlatStyle)resources.GetObject("cmdNo.FlatStyle");
		this.cmdNo.Font = (System.Drawing.Font)resources.GetObject("cmdNo.Font");
		this.cmdNo.Image = (System.Drawing.Image)resources.GetObject("cmdNo.Image");
		this.cmdNo.ImageAlign = (System.Drawing.ContentAlignment)resources.GetObject("cmdNo.ImageAlign");
		this.cmdNo.ImageIndex = (int)resources.GetObject("cmdNo.ImageIndex");
		this.cmdNo.ImeMode = (System.Windows.Forms.ImeMode)resources.GetObject("cmdNo.ImeMode");
		this.cmdNo.Location = (System.Drawing.Point)resources.GetObject("cmdNo.Location");
		this.cmdNo.Name = "cmdNo";
		this.cmdNo.RightToLeft = (System.Windows.Forms.RightToLeft)resources.GetObject("cmdNo.RightToLeft");
		this.cmdNo.Size = (System.Drawing.Size)resources.GetObject("cmdNo.Size");
		this.cmdNo.TabIndex = (int)resources.GetObject("cmdNo.TabIndex");
		this.cmdNo.Text = resources.GetString("cmdNo.Text");
		this.cmdNo.TextAlign = (System.Drawing.ContentAlignment)resources.GetObject("cmdNo.TextAlign");
		this.cmdNo.Visible = (bool)resources.GetObject("cmdNo.Visible");
		//
		//cmdYes
		//
		this.cmdYes.AccessibleDescription = resources.GetString("cmdYes.AccessibleDescription");
		this.cmdYes.AccessibleName = resources.GetString("cmdYes.AccessibleName");
		this.cmdYes.Anchor = (System.Windows.Forms.AnchorStyles)resources.GetObject("cmdYes.Anchor");
		this.cmdYes.BackgroundImage = (System.Drawing.Image)resources.GetObject("cmdYes.BackgroundImage");
		this.cmdYes.Cursor = System.Windows.Forms.Cursors.Hand;
		this.cmdYes.DialogResult = System.Windows.Forms.DialogResult.Yes;
		this.cmdYes.Dock = (System.Windows.Forms.DockStyle)resources.GetObject("cmdYes.Dock");
		this.cmdYes.Enabled = (bool)resources.GetObject("cmdYes.Enabled");
		this.cmdYes.FlatStyle = (System.Windows.Forms.FlatStyle)resources.GetObject("cmdYes.FlatStyle");
		this.cmdYes.Font = (System.Drawing.Font)resources.GetObject("cmdYes.Font");
		this.cmdYes.Image = (System.Drawing.Image)resources.GetObject("cmdYes.Image");
		this.cmdYes.ImageAlign = (System.Drawing.ContentAlignment)resources.GetObject("cmdYes.ImageAlign");
		this.cmdYes.ImageIndex = (int)resources.GetObject("cmdYes.ImageIndex");
		this.cmdYes.ImeMode = (System.Windows.Forms.ImeMode)resources.GetObject("cmdYes.ImeMode");
		this.cmdYes.Location = (System.Drawing.Point)resources.GetObject("cmdYes.Location");
		this.cmdYes.Name = "cmdYes";
		this.cmdYes.RightToLeft = (System.Windows.Forms.RightToLeft)resources.GetObject("cmdYes.RightToLeft");
		this.cmdYes.Size = (System.Drawing.Size)resources.GetObject("cmdYes.Size");
		this.cmdYes.TabIndex = (int)resources.GetObject("cmdYes.TabIndex");
		this.cmdYes.Text = resources.GetString("cmdYes.Text");
		this.cmdYes.TextAlign = (System.Drawing.ContentAlignment)resources.GetObject("cmdYes.TextAlign");
		this.cmdYes.Visible = (bool)resources.GetObject("cmdYes.Visible");
		//
		//cmdOk
		//
		this.cmdOk.AccessibleDescription = resources.GetString("cmdOk.AccessibleDescription");
		this.cmdOk.AccessibleName = resources.GetString("cmdOk.AccessibleName");
		this.cmdOk.Anchor = (System.Windows.Forms.AnchorStyles)resources.GetObject("cmdOk.Anchor");
		this.cmdOk.BackgroundImage = (System.Drawing.Image)resources.GetObject("cmdOk.BackgroundImage");
		this.cmdOk.Cursor = System.Windows.Forms.Cursors.Hand;
		this.cmdOk.DialogResult = System.Windows.Forms.DialogResult.OK;
		this.cmdOk.Dock = (System.Windows.Forms.DockStyle)resources.GetObject("cmdOk.Dock");
		this.cmdOk.Enabled = (bool)resources.GetObject("cmdOk.Enabled");
		this.cmdOk.FlatStyle = (System.Windows.Forms.FlatStyle)resources.GetObject("cmdOk.FlatStyle");
		this.cmdOk.Font = (System.Drawing.Font)resources.GetObject("cmdOk.Font");
		this.cmdOk.Image = (System.Drawing.Image)resources.GetObject("cmdOk.Image");
		this.cmdOk.ImageAlign = (System.Drawing.ContentAlignment)resources.GetObject("cmdOk.ImageAlign");
		this.cmdOk.ImageIndex = (int)resources.GetObject("cmdOk.ImageIndex");
		this.cmdOk.ImeMode = (System.Windows.Forms.ImeMode)resources.GetObject("cmdOk.ImeMode");
		this.cmdOk.Location = (System.Drawing.Point)resources.GetObject("cmdOk.Location");
		this.cmdOk.Name = "cmdOk";
		this.cmdOk.RightToLeft = (System.Windows.Forms.RightToLeft)resources.GetObject("cmdOk.RightToLeft");
		this.cmdOk.Size = (System.Drawing.Size)resources.GetObject("cmdOk.Size");
		this.cmdOk.TabIndex = (int)resources.GetObject("cmdOk.TabIndex");
		this.cmdOk.Text = resources.GetString("cmdOk.Text");
		this.cmdOk.TextAlign = (System.Drawing.ContentAlignment)resources.GetObject("cmdOk.TextAlign");
		this.cmdOk.Visible = (bool)resources.GetObject("cmdOk.Visible");
		//
		//picMessage
		//
		this.picMessage.AccessibleDescription = resources.GetString("picMessage.AccessibleDescription");
		this.picMessage.AccessibleName = resources.GetString("picMessage.AccessibleName");
		this.picMessage.Anchor = (System.Windows.Forms.AnchorStyles)resources.GetObject("picMessage.Anchor");
		this.picMessage.BackgroundImage = (System.Drawing.Image)resources.GetObject("picMessage.BackgroundImage");
		this.picMessage.Dock = (System.Windows.Forms.DockStyle)resources.GetObject("picMessage.Dock");
		this.picMessage.Enabled = (bool)resources.GetObject("picMessage.Enabled");
		this.picMessage.Font = (System.Drawing.Font)resources.GetObject("picMessage.Font");
		this.picMessage.Image = (System.Drawing.Image)resources.GetObject("picMessage.Image");
		this.picMessage.ImeMode = (System.Windows.Forms.ImeMode)resources.GetObject("picMessage.ImeMode");
		this.picMessage.Location = (System.Drawing.Point)resources.GetObject("picMessage.Location");
		this.picMessage.Name = "picMessage";
		this.picMessage.RightToLeft = (System.Windows.Forms.RightToLeft)resources.GetObject("picMessage.RightToLeft");
		this.picMessage.Size = (System.Drawing.Size)resources.GetObject("picMessage.Size");
		this.picMessage.SizeMode = (System.Windows.Forms.PictureBoxSizeMode)resources.GetObject("picMessage.SizeMode");
		this.picMessage.TabIndex = (int)resources.GetObject("picMessage.TabIndex");
		this.picMessage.TabStop = false;
		this.picMessage.Text = resources.GetString("picMessage.Text");
		this.picMessage.Visible = (bool)resources.GetObject("picMessage.Visible");
		//
		//lblMessage
		//
		this.lblMessage.AccessibleDescription = resources.GetString("lblMessage.AccessibleDescription");
		this.lblMessage.AccessibleName = resources.GetString("lblMessage.AccessibleName");
		this.lblMessage.Anchor = (System.Windows.Forms.AnchorStyles)resources.GetObject("lblMessage.Anchor");
		this.lblMessage.AutoSize = (bool)resources.GetObject("lblMessage.AutoSize");
		this.lblMessage.Dock = (System.Windows.Forms.DockStyle)resources.GetObject("lblMessage.Dock");
		this.lblMessage.Enabled = (bool)resources.GetObject("lblMessage.Enabled");
		this.lblMessage.Font = (System.Drawing.Font)resources.GetObject("lblMessage.Font");
		this.lblMessage.Image = (System.Drawing.Image)resources.GetObject("lblMessage.Image");
		this.lblMessage.ImageAlign = (System.Drawing.ContentAlignment)resources.GetObject("lblMessage.ImageAlign");
		this.lblMessage.ImageIndex = (int)resources.GetObject("lblMessage.ImageIndex");
		this.lblMessage.ImeMode = (System.Windows.Forms.ImeMode)resources.GetObject("lblMessage.ImeMode");
		this.lblMessage.Location = (System.Drawing.Point)resources.GetObject("lblMessage.Location");
		this.lblMessage.Name = "lblMessage";
		this.lblMessage.RightToLeft = (System.Windows.Forms.RightToLeft)resources.GetObject("lblMessage.RightToLeft");
		this.lblMessage.Size = (System.Drawing.Size)resources.GetObject("lblMessage.Size");
		this.lblMessage.TabIndex = (int)resources.GetObject("lblMessage.TabIndex");
		this.lblMessage.Text = resources.GetString("lblMessage.Text");
		this.lblMessage.TextAlign = (System.Drawing.ContentAlignment)resources.GetObject("lblMessage.TextAlign");
		this.lblMessage.Visible = (bool)resources.GetObject("lblMessage.Visible");
		//
		//ImgLstMessage
		//
		this.ImgLstMessage.ImageSize = (System.Drawing.Size)resources.GetObject("ImgLstMessage.ImageSize");
		this.ImgLstMessage.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("ImgLstMessage.ImageStream");
		this.ImgLstMessage.TransparentColor = System.Drawing.Color.Transparent;
		//
		//GroupBox1
		//
		this.GroupBox1.AccessibleDescription = resources.GetString("GroupBox1.AccessibleDescription");
		this.GroupBox1.AccessibleName = resources.GetString("GroupBox1.AccessibleName");
		this.GroupBox1.Anchor = (System.Windows.Forms.AnchorStyles)resources.GetObject("GroupBox1.Anchor");
		this.GroupBox1.BackgroundImage = (System.Drawing.Image)resources.GetObject("GroupBox1.BackgroundImage");
		this.GroupBox1.Controls.Add(this.picMessage);
		this.GroupBox1.Controls.Add(this.lblMessage);
		this.GroupBox1.Dock = (System.Windows.Forms.DockStyle)resources.GetObject("GroupBox1.Dock");
		this.GroupBox1.Enabled = (bool)resources.GetObject("GroupBox1.Enabled");
		this.GroupBox1.Font = (System.Drawing.Font)resources.GetObject("GroupBox1.Font");
		this.GroupBox1.ImeMode = (System.Windows.Forms.ImeMode)resources.GetObject("GroupBox1.ImeMode");
		this.GroupBox1.Location = (System.Drawing.Point)resources.GetObject("GroupBox1.Location");
		this.GroupBox1.Name = "GroupBox1";
		this.GroupBox1.RightToLeft = (System.Windows.Forms.RightToLeft)resources.GetObject("GroupBox1.RightToLeft");
		this.GroupBox1.Size = (System.Drawing.Size)resources.GetObject("GroupBox1.Size");
		this.GroupBox1.TabIndex = (int)resources.GetObject("GroupBox1.TabIndex");
		this.GroupBox1.TabStop = false;
		this.GroupBox1.Text = resources.GetString("GroupBox1.Text");
		this.GroupBox1.Visible = (bool)resources.GetObject("GroupBox1.Visible");
		//
		//frmMessage1
		//
		this.AccessibleDescription = resources.GetString("$this.AccessibleDescription");
		this.AccessibleName = resources.GetString("$this.AccessibleName");
		this.AutoScaleBaseSize = (System.Drawing.Size)resources.GetObject("$this.AutoScaleBaseSize");
		this.AutoScroll = (bool)resources.GetObject("$this.AutoScroll");
		this.AutoScrollMargin = (System.Drawing.Size)resources.GetObject("$this.AutoScrollMargin");
		this.AutoScrollMinSize = (System.Drawing.Size)resources.GetObject("$this.AutoScrollMinSize");
		this.BackColor = System.Drawing.Color.Linen;
		this.BackgroundImage = (System.Drawing.Image)resources.GetObject("$this.BackgroundImage");
		this.ClientSize = (System.Drawing.Size)resources.GetObject("$this.ClientSize");
		this.ControlBox = false;
		this.Controls.Add(this.GroupBox1);
		this.Controls.Add(this.cmdNo);
		this.Controls.Add(this.cmdYes);
		this.Controls.Add(this.cmdOk);
		this.Enabled = (bool)resources.GetObject("$this.Enabled");
		this.Font = (System.Drawing.Font)resources.GetObject("$this.Font");
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
		this.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		this.ImeMode = (System.Windows.Forms.ImeMode)resources.GetObject("$this.ImeMode");
		this.Location = (System.Drawing.Point)resources.GetObject("$this.Location");
		this.MaximumSize = (System.Drawing.Size)resources.GetObject("$this.MaximumSize");
		this.MinimumSize = (System.Drawing.Size)resources.GetObject("$this.MinimumSize");
		this.Name = "frmMessage1";
		this.RightToLeft = (System.Windows.Forms.RightToLeft)resources.GetObject("$this.RightToLeft");
		this.StartPosition = (System.Windows.Forms.FormStartPosition)resources.GetObject("$this.StartPosition");
		this.Text = resources.GetString("$this.Text");
		this.GroupBox1.ResumeLayout(false);
		this.ResumeLayout(false);

	}

	#End Region



}
