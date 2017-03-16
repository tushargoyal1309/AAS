
//'class behind the PMT form.

public class frmPMT : System.Windows.Forms.Form
{

	#Region " Windows Form Designer generated code "

	public frmPMT()
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
	internal NETXP.Controls.XPButton btnCancel;
	internal System.Windows.Forms.Label lblMsg;
	internal System.Windows.Forms.Label lblTitle;
	internal System.Windows.Forms.Panel PanelBack;
	internal NETXP.Controls.XPButton lblBlink;
	[System.Diagnostics.DebuggerStepThrough()]
	private void InitializeComponent()
	{
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmPMT));
		this.btnCancel = new NETXP.Controls.XPButton();
		this.lblMsg = new System.Windows.Forms.Label();
		this.lblTitle = new System.Windows.Forms.Label();
		this.PanelBack = new System.Windows.Forms.Panel();
		this.lblBlink = new NETXP.Controls.XPButton();
		this.PanelBack.SuspendLayout();
		this.SuspendLayout();
		//
		//btnCancel
		//
		this.btnCancel.BackColor = System.Drawing.Color.AliceBlue;
		this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.btnCancel.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnCancel.Image = (System.Drawing.Image)resources.GetObject("btnCancel.Image");
		this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnCancel.Location = new System.Drawing.Point(240, 64);
		this.btnCancel.Name = "btnCancel";
		this.btnCancel.Size = new System.Drawing.Size(96, 32);
		this.btnCancel.TabIndex = 0;
		this.btnCancel.Text = "&Cancel";
		//
		//lblMsg
		//
		this.lblMsg.BackColor = System.Drawing.Color.White;
		this.lblMsg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblMsg.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblMsg.ForeColor = System.Drawing.Color.Blue;
		this.lblMsg.Location = new System.Drawing.Point(240, 24);
		this.lblMsg.Name = "lblMsg";
		this.lblMsg.Size = new System.Drawing.Size(320, 32);
		this.lblMsg.TabIndex = 2;
		this.lblMsg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//lblTitle
		//
		this.lblTitle.BackColor = System.Drawing.Color.White;
		this.lblTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblTitle.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblTitle.ForeColor = System.Drawing.Color.Blue;
		this.lblTitle.Location = new System.Drawing.Point(16, 24);
		this.lblTitle.Name = "lblTitle";
		this.lblTitle.Size = new System.Drawing.Size(144, 32);
		this.lblTitle.TabIndex = 0;
		this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//PanelBack
		//
		this.PanelBack.BackColor = System.Drawing.Color.AliceBlue;
		this.PanelBack.Controls.Add(this.lblBlink);
		this.PanelBack.Controls.Add(this.lblMsg);
		this.PanelBack.Controls.Add(this.btnCancel);
		this.PanelBack.Controls.Add(this.lblTitle);
		this.PanelBack.Dock = System.Windows.Forms.DockStyle.Fill;
		this.PanelBack.Location = new System.Drawing.Point(0, 0);
		this.PanelBack.Name = "PanelBack";
		this.PanelBack.Size = new System.Drawing.Size(576, 112);
		this.PanelBack.TabIndex = 10;
		//
		//lblBlink
		//
		this.lblBlink.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.lblBlink.Font = new System.Drawing.Font("Arial", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblBlink.ForeColor = System.Drawing.Color.Blue;
		this.lblBlink.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.lblBlink.Location = new System.Drawing.Point(184, 24);
		this.lblBlink.Name = "lblBlink";
		this.lblBlink.Size = new System.Drawing.Size(32, 32);
		this.lblBlink.TabIndex = 4;
		//
		//frmPMT
		//
		this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
		this.ClientSize = new System.Drawing.Size(576, 112);
		this.ControlBox = false;
		this.Controls.Add(this.PanelBack);
		this.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		this.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		this.MaximizeBox = false;
		this.MinimizeBox = false;
		this.MinimumSize = new System.Drawing.Size(100, 40);
		this.Name = "frmPMT";
		this.ShowInTaskbar = false;
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Setting PMT";
		this.TopMost = true;
		this.PanelBack.ResumeLayout(false);
		this.ResumeLayout(false);

	}

	#End Region

	#Region "Public Variable"
		#End Region
	public bool mCancelProcess = false;

	#Region "Event Handlers"
	private void  // ERROR: Handles clauses are not supported in C#
btnCancel_Click(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : btnCancel_Click
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : 
		// Description           : to handle the cancel button event. 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 21.11.06
		// Revisions             : praveen
		//=====================================================================
		//'note:
		//'this is called when user clicked on cancel button
		mCancelProcess = true;
		Application.DoEvents();
		//'cancel the process and allow application to perfrom its panding work.
	}
	private void lblBlink_Click(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : lblBlink_Click
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : 
		// Description           : to handle the blink label event. 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 21.11.06
		// Revisions             : praveen
		//=====================================================================
		mCancelProcess = true;
		Application.DoEvents();
		//'cancel the process and allow application to perfrom its panding work.
	}

	#End Region


}
