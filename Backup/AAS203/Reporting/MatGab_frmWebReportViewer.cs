

public class frmWebReportViewer : System.Windows.Forms.Form
{
	//**********************************************************************
	// File Header        
	// File Name 		: frmWebReportViewer.vb
	// Author			: Mangesh Shardul
	// Date/Time			: 18-Mar-2005 8:00 pm
	// Description		: To view the Web Enabled report in a Web Browser
	//**********************************************************************

	#Region " Windows Form Designer generated code "

	public frmWebReportViewer()
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
	internal AxSHDocVw.AxWebBrowser WebPreviewPane;
	[System.Diagnostics.DebuggerStepThrough()]
	private void InitializeComponent()
	{
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmWebReportViewer));
		this.WebPreviewPane = new AxSHDocVw.AxWebBrowser();
		((System.ComponentModel.ISupportInitialize)this.WebPreviewPane).BeginInit();
		this.SuspendLayout();
		//
		//WebPreviewPane
		//
		this.WebPreviewPane.Dock = System.Windows.Forms.DockStyle.Fill;
		this.WebPreviewPane.Enabled = true;
		this.WebPreviewPane.Location = new System.Drawing.Point(0, 0);
		this.WebPreviewPane.OcxState = (System.Windows.Forms.AxHost.State)resources.GetObject("WebPreviewPane.OcxState");
		this.WebPreviewPane.Size = new System.Drawing.Size(756, 361);
		this.WebPreviewPane.TabIndex = 0;
		//
		//frmWebReportViewer
		//
		this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
		this.ClientSize = new System.Drawing.Size(756, 361);
		this.Controls.Add(this.WebPreviewPane);
		this.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		this.Name = "frmWebReportViewer";
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Web Report Viewer";
		((System.ComponentModel.ISupportInitialize)this.WebPreviewPane).EndInit();
		this.ResumeLayout(false);

	}

	#End Region

	#Region " Constructors "

	public frmWebReportViewer(string strReportFilePathIn)
	{
		base.New();

		//This call is required by the Windows Form Designer.
		InitializeComponent();

		//Add any initialization after the InitializeComponent() call
		mstrReportFilePath = strReportFilePathIn;

	}

	#End Region

	#Region " Class Variables "


	private string mstrReportFilePath;
	#End Region

	#Region " Public Property "

	public string ReportFilePath {
		get { return mstrReportFilePath; }
		set {
			mstrReportFilePath = Value;
			WebPreviewPane.Navigate(mstrReportFilePath);
			WebPreviewPane.Show();
		}
	}

	#End Region

	#Region " Form Load and closing Events "

	private void  // ERROR: Handles clauses are not supported in C#
frmWebReportViewer_Load(object sender, System.EventArgs e)
	{
		if (!mstrReportFilePath == "") {
			WebPreviewPane.Navigate(mstrReportFilePath);
			WebPreviewPane.Show();
		}
	}

	private void  // ERROR: Handles clauses are not supported in C#
frmWebReportViewer_Closing(object sender, System.ComponentModel.CancelEventArgs e)
	{
		//'Dim dlgRstSave As DialogResult
		//'dlgRstSave = MessageBox.Show("Do you want to save the web report?", "Save Web Report", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
		bool blnIsSaveReport;

		//blnIsSaveReport = gobjMessageAdapter.ShowMessage(msgIDSaveWebReportFile)
		blnIsSaveReport = gobjMessageAdapter.ShowMessage("Do you want to save the web report?", "Save Web Report", MessageHandler.clsMessageHandler.enumMessageType.QuestionMessage);

		Application.DoEvents();

		if (blnIsSaveReport == true) {
			WebPreviewPane.ExecWB(SHDocVw.OLECMDID.OLECMDID_SAVEAS, SHDocVw.OLECMDEXECOPT.OLECMDEXECOPT_PROMPTUSER);
			WebPreviewPane.Hide();
		} else if (blnIsSaveReport == false) {
			WebPreviewPane.Hide();
		}


	}

	#End Region

}
