public class frmImportFile : System.Windows.Forms.Form
{

	#Region " Windows Form Designer generated code "

	public frmImportFile()
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
	internal GradientPanel.CustomPanel CustomPanelMain;
	internal GradientPanel.CustomPanel CustomPanelTop;
	internal GradientPanel.CustomPanel CustomPanelMethod;
	internal System.Windows.Forms.Label lbMethodComments;
	internal System.Windows.Forms.Label lblMethodComments;
	internal System.Windows.Forms.Label lblMethodInformation;
	internal System.Windows.Forms.Label lblRuns;
	internal System.Windows.Forms.ListBox lbMethodInformation;
	internal System.Windows.Forms.ListBox lbRunNos;
	internal GradientPanel.CustomPanel CustomPanelBottom;
	internal AAS203.AASGraph PreviewGraph;
	internal NETXP.Controls.XPButton btnCancel;
	internal NETXP.Controls.XPButton btnOk;
	[System.Diagnostics.DebuggerStepThrough()]
	private void InitializeComponent()
	{
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmImportFile));
		this.CustomPanelMain = new GradientPanel.CustomPanel();
		this.CustomPanelTop = new GradientPanel.CustomPanel();
		this.CustomPanelMethod = new GradientPanel.CustomPanel();
		this.lbMethodComments = new System.Windows.Forms.Label();
		this.lblMethodComments = new System.Windows.Forms.Label();
		this.lblMethodInformation = new System.Windows.Forms.Label();
		this.lblRuns = new System.Windows.Forms.Label();
		this.lbMethodInformation = new System.Windows.Forms.ListBox();
		this.lbRunNos = new System.Windows.Forms.ListBox();
		this.CustomPanelBottom = new GradientPanel.CustomPanel();
		this.PreviewGraph = new AAS203.AASGraph();
		this.btnCancel = new NETXP.Controls.XPButton();
		this.btnOk = new NETXP.Controls.XPButton();
		this.CustomPanelMain.SuspendLayout();
		this.CustomPanelTop.SuspendLayout();
		this.CustomPanelMethod.SuspendLayout();
		this.CustomPanelBottom.SuspendLayout();
		this.SuspendLayout();
		//
		//CustomPanelMain
		//
		this.CustomPanelMain.BackColor = System.Drawing.Color.AliceBlue;
		this.CustomPanelMain.Controls.Add(this.CustomPanelTop);
		this.CustomPanelMain.Controls.Add(this.CustomPanelBottom);
		this.CustomPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
		this.CustomPanelMain.Location = new System.Drawing.Point(0, 0);
		this.CustomPanelMain.Name = "CustomPanelMain";
		this.CustomPanelMain.Size = new System.Drawing.Size(400, 395);
		this.CustomPanelMain.TabIndex = 1;
		//
		//CustomPanelTop
		//
		this.CustomPanelTop.BackColor = System.Drawing.Color.AliceBlue;
		this.CustomPanelTop.Controls.Add(this.CustomPanelMethod);
		this.CustomPanelTop.Dock = System.Windows.Forms.DockStyle.Fill;
		this.CustomPanelTop.Location = new System.Drawing.Point(0, 0);
		this.CustomPanelTop.Name = "CustomPanelTop";
		this.CustomPanelTop.Size = new System.Drawing.Size(400, 251);
		this.CustomPanelTop.TabIndex = 21;
		//
		//CustomPanelMethod
		//
		this.CustomPanelMethod.BackColor = System.Drawing.Color.AliceBlue;
		this.CustomPanelMethod.Controls.Add(this.lbMethodComments);
		this.CustomPanelMethod.Controls.Add(this.lblMethodComments);
		this.CustomPanelMethod.Controls.Add(this.lblMethodInformation);
		this.CustomPanelMethod.Controls.Add(this.lblRuns);
		this.CustomPanelMethod.Controls.Add(this.lbMethodInformation);
		this.CustomPanelMethod.Controls.Add(this.lbRunNos);
		this.CustomPanelMethod.Dock = System.Windows.Forms.DockStyle.Fill;
		this.CustomPanelMethod.Location = new System.Drawing.Point(0, 0);
		this.CustomPanelMethod.Name = "CustomPanelMethod";
		this.CustomPanelMethod.Size = new System.Drawing.Size(400, 251);
		this.CustomPanelMethod.TabIndex = 20;
		//
		//lbMethodComments
		//
		this.lbMethodComments.BackColor = System.Drawing.Color.White;
		this.lbMethodComments.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
		this.lbMethodComments.Location = new System.Drawing.Point(160, 173);
		this.lbMethodComments.Name = "lbMethodComments";
		this.lbMethodComments.Size = new System.Drawing.Size(225, 40);
		this.lbMethodComments.TabIndex = 33;
		//
		//lblMethodComments
		//
		this.lblMethodComments.Location = new System.Drawing.Point(160, 152);
		this.lblMethodComments.Name = "lblMethodComments";
		this.lblMethodComments.Size = new System.Drawing.Size(104, 16);
		this.lblMethodComments.TabIndex = 30;
		this.lblMethodComments.Text = "Method Comments";
		//
		//lblMethodInformation
		//
		this.lblMethodInformation.Location = new System.Drawing.Point(160, 7);
		this.lblMethodInformation.Name = "lblMethodInformation";
		this.lblMethodInformation.Size = new System.Drawing.Size(104, 16);
		this.lblMethodInformation.TabIndex = 29;
		this.lblMethodInformation.Text = "Method Information";
		//
		//lblRuns
		//
		this.lblRuns.Location = new System.Drawing.Point(16, 7);
		this.lblRuns.Name = "lblRuns";
		this.lblRuns.Size = new System.Drawing.Size(96, 16);
		this.lblRuns.TabIndex = 28;
		this.lblRuns.Text = "Runs";
		//
		//lbMethodInformation
		//
		this.lbMethodInformation.Location = new System.Drawing.Point(160, 27);
		this.lbMethodInformation.Name = "lbMethodInformation";
		this.lbMethodInformation.Size = new System.Drawing.Size(225, 108);
		this.lbMethodInformation.TabIndex = 25;
		//
		//lbRunNos
		//
		this.lbRunNos.BackColor = System.Drawing.Color.White;
		this.lbRunNos.Location = new System.Drawing.Point(16, 27);
		this.lbRunNos.Name = "lbRunNos";
		this.lbRunNos.Size = new System.Drawing.Size(129, 186);
		this.lbRunNos.TabIndex = 24;
		//
		//CustomPanelBottom
		//
		this.CustomPanelBottom.BackColor = System.Drawing.Color.AliceBlue;
		this.CustomPanelBottom.Controls.Add(this.PreviewGraph);
		this.CustomPanelBottom.Controls.Add(this.btnCancel);
		this.CustomPanelBottom.Controls.Add(this.btnOk);
		this.CustomPanelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
		this.CustomPanelBottom.Location = new System.Drawing.Point(0, 251);
		this.CustomPanelBottom.Name = "CustomPanelBottom";
		this.CustomPanelBottom.Size = new System.Drawing.Size(400, 144);
		this.CustomPanelBottom.TabIndex = 20;
		//
		//PreviewGraph
		//
		this.PreviewGraph.AldysGraphCursor = System.Windows.Forms.Cursors.Hand;
		this.PreviewGraph.AldysGraphPrintColor = System.Drawing.Color.Black;
		this.PreviewGraph.BackColor = System.Drawing.Color.LightGray;
		this.PreviewGraph.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.PreviewGraph.GraphDataSource = null;
		this.PreviewGraph.GraphImage = null;
		this.PreviewGraph.IsShowGrid = true;
		this.PreviewGraph.Location = new System.Drawing.Point(16, 8);
		this.PreviewGraph.Name = "PreviewGraph";
		this.PreviewGraph.Size = new System.Drawing.Size(224, 128);
		this.PreviewGraph.TabIndex = 24;
		this.PreviewGraph.UseDefaultSettings = false;
		this.PreviewGraph.XAxisDateMax = new System.DateTime(2007, 3, 16, 23, 59, 59, 0);
		this.PreviewGraph.XAxisDateMin = new System.DateTime(2007, 3, 16, 0, 0, 0, 0);
		this.PreviewGraph.XAxisDateScaleFormat = AAS203.AASGraph.enumDateScaleFormat.HHMM;
		this.PreviewGraph.XAxisLabel = "TIME(seconds)";
		this.PreviewGraph.XAxisMax = 100;
		this.PreviewGraph.XAxisMin = 0;
		this.PreviewGraph.XAxisMinorStep = 2;
		this.PreviewGraph.XAxisScaleFormat = "";
		this.PreviewGraph.XAxisStep = 10;
		this.PreviewGraph.XAxisType = AldysGraph.AxisType.Linear;
		this.PreviewGraph.YAxisLabel = "ABSORBANCE";
		this.PreviewGraph.YAxisMax = 1.1;
		this.PreviewGraph.YAxisMin = -0.2;
		this.PreviewGraph.YAxisMinorStep = 0.05;
		this.PreviewGraph.YAxisScaleFormat = null;
		this.PreviewGraph.YAxisStep = 0.1;
		this.PreviewGraph.YAxisType = AldysGraph.AxisType.Linear;
		//
		//btnCancel
		//
		this.btnCancel.BackColor = System.Drawing.Color.Transparent;
		this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnCancel.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnCancel.Image = (System.Drawing.Image)resources.GetObject("btnCancel.Image");
		this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnCancel.Location = new System.Drawing.Point(248, 101);
		this.btnCancel.Name = "btnCancel";
		this.btnCancel.Size = new System.Drawing.Size(86, 34);
		this.btnCancel.TabIndex = 1;
		this.btnCancel.Text = "&Cancel";
		//
		//btnOk
		//
		this.btnOk.BackColor = System.Drawing.Color.Transparent;
		this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
		this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnOk.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnOk.Image = (System.Drawing.Image)resources.GetObject("btnOk.Image");
		this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnOk.Location = new System.Drawing.Point(248, 56);
		this.btnOk.Name = "btnOk";
		this.btnOk.Size = new System.Drawing.Size(86, 34);
		this.btnOk.TabIndex = 0;
		this.btnOk.Text = "&OK";
		//
		//frmImportFile
		//
		this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
		this.ClientSize = new System.Drawing.Size(400, 395);
		this.Controls.Add(this.CustomPanelMain);
		this.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		this.Name = "frmImportFile";
		this.ShowInTaskbar = false;
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Import File";
		this.CustomPanelMain.ResumeLayout(false);
		this.CustomPanelTop.ResumeLayout(false);
		this.CustomPanelMethod.ResumeLayout(false);
		this.CustomPanelBottom.ResumeLayout(false);
		this.ResumeLayout(false);

	}

	#End Region

}
