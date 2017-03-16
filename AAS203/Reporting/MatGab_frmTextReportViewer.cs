
public class frmTextReportViewer : System.Windows.Forms.Form
{
	//**********************************************************************
	// File Header        
	// File Name 		: frmTextReportViewer.vb
	// Author			: Mangesh Shardul
	// Date/Time			: 05-Apr-2005 12:00 Noon
	// Description		: To view the Text report in a Text Editor
	//**********************************************************************

	#Region " Windows Form Designer generated code "

	public frmTextReportViewer()
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
	internal System.Windows.Forms.TextBox txtReportText;
	internal System.Windows.Forms.Panel PanelTextReport;
	[System.Diagnostics.DebuggerStepThrough()]
	private void InitializeComponent()
	{
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmTextReportViewer));
		this.txtReportText = new System.Windows.Forms.TextBox();
		this.PanelTextReport = new System.Windows.Forms.Panel();
		this.PanelTextReport.SuspendLayout();
		this.SuspendLayout();
		//
		//txtReportText
		//
		this.txtReportText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txtReportText.Dock = System.Windows.Forms.DockStyle.Fill;
		this.txtReportText.Location = new System.Drawing.Point(0, 0);
		this.txtReportText.Multiline = true;
		this.txtReportText.Name = "txtReportText";
		this.txtReportText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
		this.txtReportText.Size = new System.Drawing.Size(710, 353);
		this.txtReportText.TabIndex = 0;
		this.txtReportText.Text = "";
		//
		//PanelTextReport
		//
		this.PanelTextReport.Controls.Add(this.txtReportText);
		this.PanelTextReport.Dock = System.Windows.Forms.DockStyle.Fill;
		this.PanelTextReport.Location = new System.Drawing.Point(0, 0);
		this.PanelTextReport.Name = "PanelTextReport";
		this.PanelTextReport.Size = new System.Drawing.Size(710, 353);
		this.PanelTextReport.TabIndex = 1;
		//
		//frmTextReportViewer
		//
		this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
		this.ClientSize = new System.Drawing.Size(710, 353);
		this.Controls.Add(this.PanelTextReport);
		this.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
		this.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		this.Name = "frmTextReportViewer";
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Text Report Viewer";
		this.PanelTextReport.ResumeLayout(false);
		this.ResumeLayout(false);

	}

	#End Region

	#Region " Class Variables "


	private string mstrReportFilePath;
	#End Region

	#Region " Public Property "

	public string ReportFilePath {
		get { return mstrReportFilePath; }
		set { mstrReportFilePath = Value; }
	}

	#End Region

	#Region " Form Load and closing Events "

	private void  // ERROR: Handles clauses are not supported in C#
frmTextReportViewer_Load(object sender, System.EventArgs e)
	{
		System.IO.FileStream fs;

		if (!IsNothing(mstrReportFilePath) == true) {
			IO.StreamReader objStream = new IO.StreamReader(mstrReportFilePath);
			txtReportText.Text = objStream.ReadToEnd;

			txtReportText.Font = new Font("Lucida Console", 12, FontStyle.Regular, GraphicsUnit.Point);
			txtReportText.WordWrap = false;
			txtReportText.ScrollBars = ScrollBars.Both;

			objStream.Close();
			objStream = null;
		}

	}

	private void  // ERROR: Handles clauses are not supported in C#
frmTextReportViewer_Closing(object sender, System.ComponentModel.CancelEventArgs e)
	{
		bool blnIsSaveReport;
		//Dim cWait As CWaitCursor

		//blnIsSaveReport = gobjMessageAdapter.ShowMessage(msgIDSaveTextReportFile)
		blnIsSaveReport = gobjMessageAdapter.ShowMessage("Do you want to save the text report?", "Save Text Report", MessageHandler.clsMessageHandler.enumMessageType.QuestionMessage);
		Application.DoEvents();
		//cWait = New CWaitCursor
		if (blnIsSaveReport == true) {
			SaveFileDialog objSaveFileDlg = new SaveFileDialog();

			objSaveFileDlg.Filter = "Text File (*.txt)|*.txt|All Files (*.*)|*.*";

			if (objSaveFileDlg.ShowDialog == DialogResult.OK) {
				IO.StreamWriter objStreamWriter;
				objStreamWriter = new IO.StreamWriter(objSaveFileDlg.FileName);
				objStreamWriter.Write(txtReportText.Text);
				objStreamWriter.Close();
				objStreamWriter = null;
			} else {
				objSaveFileDlg.Dispose();
			}

		//If Not cWait Is Nothing Then
		//    cWait.Dispose()
		//End If

		} else if (blnIsSaveReport == false) {
		}

		//If Not cWait Is Nothing Then
		//    cWait.Dispose()
		//End If
	}

	#End Region

}
