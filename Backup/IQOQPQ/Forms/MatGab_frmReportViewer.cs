public class frmReportViewer : System.Windows.Forms.Form
{

	#Region " Windows Form Designer generated code "

	public frmReportViewer()
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
	internal CrystalDecisions.Windows.Forms.CrystalReportViewer CrystalReportViewer;
	[System.Diagnostics.DebuggerStepThrough()]
	private void InitializeComponent()
	{
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmReportViewer));
		this.CrystalReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
		this.SuspendLayout();
		//
		//CrystalReportViewer
		//
		this.CrystalReportViewer.ActiveViewIndex = -1;
		this.CrystalReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
		this.CrystalReportViewer.Location = new System.Drawing.Point(0, 0);
		this.CrystalReportViewer.Name = "CrystalReportViewer";
		this.CrystalReportViewer.ReportSource = null;
		this.CrystalReportViewer.Size = new System.Drawing.Size(672, 365);
		this.CrystalReportViewer.TabIndex = 0;
		//
		//frmReportViewer
		//
		this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
		this.ClientSize = new System.Drawing.Size(672, 365);
		this.Controls.Add(this.CrystalReportViewer);
		this.Name = "frmReportViewer";
		this.Text = "frmReportViewer";
		this.ResumeLayout(false);

	}

	#End Region

}
