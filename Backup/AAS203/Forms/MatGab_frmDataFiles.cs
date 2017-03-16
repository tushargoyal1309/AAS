using AAS203.Common;
using AAS203Library.Method;
using System.Threading;

public class frmDataFiles : System.Windows.Forms.Form
{

	#Region " Windows Form Designer generated code "

	public frmDataFiles()
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
	internal GradientPanel.CustomPanel CustomPanelLeft;
	internal GradientPanel.CustomPanel CustomPanelRight;
	internal GradientPanel.CustomPanel CustomPanelRightBottom;
	internal GradientPanel.CustomPanel CustomPanelRightTop;
	internal System.Windows.Forms.Label lblMethod;
	internal GradientPanel.CustomPanel CustomPanelMain;
	internal CodeIntellects.Office2003Controls.Office2003Header HeaderRight;
	internal System.Windows.Forms.Label lblMethodInformation;
	internal System.Windows.Forms.Label lblMethodComments;
	internal System.Windows.Forms.TextBox txtMethodComments;
	internal System.Windows.Forms.TextBox txtRunNo;
	internal System.Windows.Forms.Label lblRunNo;
	internal System.Windows.Forms.ListBox lstMethodInformation;
	internal AAS203.AASGraph PreviewGraph;
	internal System.Windows.Forms.TextBox txtMethod;
	internal NETXP.Controls.XPButton btnEditData;
	internal NETXP.Controls.XPButton btnExportReport;
	internal NETXP.Controls.XPButton btnReportOptions;
	internal NETXP.Controls.XPButton btnReports;
	internal NETXP.Controls.XPButton btnViewResults;
	internal CodeIntellects.Office2003Controls.Office2003Header HeaderLeft;
	internal NETXP.Controls.XPButton btnSampleGraph;
	internal NETXP.Controls.XPButton btnStandardGraph;
	internal NETXP.Controls.XPButton btnLoad;
	internal NETXP.Controls.XPButton cmdChangeScale;
	internal NETXP.Controls.XPButton btnPrintGraph;
	internal NETXP.Controls.XPButton btnExtinguish;
	internal NETXP.Controls.XPButton btnIgnite;
	internal NETXP.Controls.RealPanel RealPanel1;
	internal NETXP.Controls.RealPanel RealPanel2;
	internal NETXP.Controls.RealPanel RealPanel3;
	internal NETXP.Controls.XPButton btnN2OIgnite;
	internal NETXP.Controls.XPButton btnDelete;
	internal NETXP.Controls.XPButton btnR;
	[System.Diagnostics.DebuggerStepThrough()]
	private void InitializeComponent()
	{
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmDataFiles));
		this.CustomPanelMain = new GradientPanel.CustomPanel();
		this.CustomPanelRight = new GradientPanel.CustomPanel();
		this.btnPrintGraph = new NETXP.Controls.XPButton();
		this.cmdChangeScale = new NETXP.Controls.XPButton();
		this.PreviewGraph = new AAS203.AASGraph();
		this.CustomPanelRightTop = new GradientPanel.CustomPanel();
		this.txtMethod = new System.Windows.Forms.TextBox();
		this.txtRunNo = new System.Windows.Forms.TextBox();
		this.lblRunNo = new System.Windows.Forms.Label();
		this.lblMethod = new System.Windows.Forms.Label();
		this.CustomPanelRightBottom = new GradientPanel.CustomPanel();
		this.lstMethodInformation = new System.Windows.Forms.ListBox();
		this.lblMethodComments = new System.Windows.Forms.Label();
		this.txtMethodComments = new System.Windows.Forms.TextBox();
		this.lblMethodInformation = new System.Windows.Forms.Label();
		this.HeaderRight = new CodeIntellects.Office2003Controls.Office2003Header();
		this.CustomPanelLeft = new GradientPanel.CustomPanel();
		this.RealPanel3 = new NETXP.Controls.RealPanel();
		this.btnLoad = new NETXP.Controls.XPButton();
		this.btnR = new NETXP.Controls.XPButton();
		this.btnDelete = new NETXP.Controls.XPButton();
		this.btnN2OIgnite = new NETXP.Controls.XPButton();
		this.RealPanel2 = new NETXP.Controls.RealPanel();
		this.btnEditData = new NETXP.Controls.XPButton();
		this.btnExportReport = new NETXP.Controls.XPButton();
		this.btnReportOptions = new NETXP.Controls.XPButton();
		this.RealPanel1 = new NETXP.Controls.RealPanel();
		this.btnReports = new NETXP.Controls.XPButton();
		this.btnViewResults = new NETXP.Controls.XPButton();
		this.btnSampleGraph = new NETXP.Controls.XPButton();
		this.btnStandardGraph = new NETXP.Controls.XPButton();
		this.btnExtinguish = new NETXP.Controls.XPButton();
		this.HeaderLeft = new CodeIntellects.Office2003Controls.Office2003Header();
		this.btnIgnite = new NETXP.Controls.XPButton();
		this.CustomPanelMain.SuspendLayout();
		this.CustomPanelRight.SuspendLayout();
		this.CustomPanelRightTop.SuspendLayout();
		this.CustomPanelRightBottom.SuspendLayout();
		this.CustomPanelLeft.SuspendLayout();
		this.RealPanel3.SuspendLayout();
		this.RealPanel2.SuspendLayout();
		this.RealPanel1.SuspendLayout();
		this.SuspendLayout();
		//
		//CustomPanelMain
		//
		this.CustomPanelMain.BackColor = System.Drawing.Color.AliceBlue;
		this.CustomPanelMain.BackColor2 = System.Drawing.Color.AliceBlue;
		this.CustomPanelMain.Controls.Add(this.CustomPanelRight);
		this.CustomPanelMain.Controls.Add(this.CustomPanelLeft);
		this.CustomPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
		this.CustomPanelMain.Location = new System.Drawing.Point(0, 0);
		this.CustomPanelMain.Name = "CustomPanelMain";
		this.CustomPanelMain.Size = new System.Drawing.Size(804, 579);
		this.CustomPanelMain.TabIndex = 0;
		//
		//CustomPanelRight
		//
		this.CustomPanelRight.BackColor = System.Drawing.Color.Transparent;
		this.CustomPanelRight.BackColor2 = System.Drawing.Color.Transparent;
		this.CustomPanelRight.Controls.Add(this.btnPrintGraph);
		this.CustomPanelRight.Controls.Add(this.cmdChangeScale);
		this.CustomPanelRight.Controls.Add(this.PreviewGraph);
		this.CustomPanelRight.Controls.Add(this.CustomPanelRightTop);
		this.CustomPanelRight.Controls.Add(this.CustomPanelRightBottom);
		this.CustomPanelRight.Controls.Add(this.HeaderRight);
		this.CustomPanelRight.Dock = System.Windows.Forms.DockStyle.Fill;
		this.CustomPanelRight.Location = new System.Drawing.Point(132, 0);
		this.CustomPanelRight.Name = "CustomPanelRight";
		this.CustomPanelRight.Size = new System.Drawing.Size(672, 579);
		this.CustomPanelRight.TabIndex = 3;
		//
		//btnPrintGraph
		//
		this.btnPrintGraph.Anchor = (System.Windows.Forms.AnchorStyles)System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.btnPrintGraph.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnPrintGraph.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnPrintGraph.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnPrintGraph.Location = new System.Drawing.Point(467, 75);
		this.btnPrintGraph.Name = "btnPrintGraph";
		this.btnPrintGraph.RightToLeft = System.Windows.Forms.RightToLeft.No;
		this.btnPrintGraph.Size = new System.Drawing.Size(110, 25);
		this.btnPrintGraph.TabIndex = 5;
		this.btnPrintGraph.Text = "&Print Graph";
		//
		//cmdChangeScale
		//
		this.cmdChangeScale.Anchor = (System.Windows.Forms.AnchorStyles)System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.cmdChangeScale.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.cmdChangeScale.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.cmdChangeScale.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.cmdChangeScale.Location = new System.Drawing.Point(344, 75);
		this.cmdChangeScale.Name = "cmdChangeScale";
		this.cmdChangeScale.Size = new System.Drawing.Size(110, 25);
		this.cmdChangeScale.TabIndex = 9;
		this.cmdChangeScale.Text = "C&hange  Scale";
		//
		//PreviewGraph
		//
		this.PreviewGraph.AldysGraphCursor = null;
		this.PreviewGraph.AldysGraphPrintColor = System.Drawing.Color.Black;
		this.PreviewGraph.Anchor = (System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right;
		this.PreviewGraph.BackColor = System.Drawing.Color.LightGray;
		this.PreviewGraph.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.PreviewGraph.GraphDataSource = null;
		this.PreviewGraph.GraphImage = null;
		this.PreviewGraph.IsShowGrid = true;
		this.PreviewGraph.Location = new System.Drawing.Point(23, 72);
		this.PreviewGraph.Name = "PreviewGraph";
		this.PreviewGraph.Size = new System.Drawing.Size(623, 379);
		this.PreviewGraph.TabIndex = 5;
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
		//CustomPanelRightTop
		//
		this.CustomPanelRightTop.BackColor = System.Drawing.Color.Transparent;
		this.CustomPanelRightTop.BackColor2 = System.Drawing.Color.Transparent;
		this.CustomPanelRightTop.Controls.Add(this.txtMethod);
		this.CustomPanelRightTop.Controls.Add(this.txtRunNo);
		this.CustomPanelRightTop.Controls.Add(this.lblRunNo);
		this.CustomPanelRightTop.Controls.Add(this.lblMethod);
		this.CustomPanelRightTop.Dock = System.Windows.Forms.DockStyle.Top;
		this.CustomPanelRightTop.Location = new System.Drawing.Point(0, 22);
		this.CustomPanelRightTop.Name = "CustomPanelRightTop";
		this.CustomPanelRightTop.Size = new System.Drawing.Size(672, 50);
		this.CustomPanelRightTop.TabIndex = 0;
		//
		//txtMethod
		//
		this.txtMethod.AutoSize = false;
		this.txtMethod.BackColor = System.Drawing.Color.White;
		this.txtMethod.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.txtMethod.Location = new System.Drawing.Point(91, 16);
		this.txtMethod.Name = "txtMethod";
		this.txtMethod.ReadOnly = true;
		this.txtMethod.Size = new System.Drawing.Size(154, 20);
		this.txtMethod.TabIndex = 0;
		this.txtMethod.Text = "";
		//
		//txtRunNo
		//
		this.txtRunNo.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left;
		this.txtRunNo.AutoSize = false;
		this.txtRunNo.BackColor = System.Drawing.Color.White;
		this.txtRunNo.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.txtRunNo.Location = new System.Drawing.Point(376, 17);
		this.txtRunNo.Name = "txtRunNo";
		this.txtRunNo.ReadOnly = true;
		this.txtRunNo.Size = new System.Drawing.Size(154, 20);
		this.txtRunNo.TabIndex = 1;
		this.txtRunNo.Text = "";
		//
		//lblRunNo
		//
		this.lblRunNo.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblRunNo.Location = new System.Drawing.Point(312, 18);
		this.lblRunNo.Name = "lblRunNo";
		this.lblRunNo.Size = new System.Drawing.Size(70, 24);
		this.lblRunNo.TabIndex = 2;
		this.lblRunNo.Text = "Run No.";
		//
		//lblMethod
		//
		this.lblMethod.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblMethod.Location = new System.Drawing.Point(22, 20);
		this.lblMethod.Name = "lblMethod";
		this.lblMethod.Size = new System.Drawing.Size(70, 24);
		this.lblMethod.TabIndex = 0;
		this.lblMethod.Text = "Method";
		//
		//CustomPanelRightBottom
		//
		this.CustomPanelRightBottom.BackColor = System.Drawing.Color.Transparent;
		this.CustomPanelRightBottom.BackColor2 = System.Drawing.Color.Transparent;
		this.CustomPanelRightBottom.Controls.Add(this.lstMethodInformation);
		this.CustomPanelRightBottom.Controls.Add(this.lblMethodComments);
		this.CustomPanelRightBottom.Controls.Add(this.txtMethodComments);
		this.CustomPanelRightBottom.Controls.Add(this.lblMethodInformation);
		this.CustomPanelRightBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
		this.CustomPanelRightBottom.Location = new System.Drawing.Point(0, 451);
		this.CustomPanelRightBottom.Name = "CustomPanelRightBottom";
		this.CustomPanelRightBottom.Size = new System.Drawing.Size(672, 128);
		this.CustomPanelRightBottom.TabIndex = 1;
		//
		//lstMethodInformation
		//
		this.lstMethodInformation.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lstMethodInformation.ItemHeight = 16;
		this.lstMethodInformation.Location = new System.Drawing.Point(22, 31);
		this.lstMethodInformation.Name = "lstMethodInformation";
		this.lstMethodInformation.Size = new System.Drawing.Size(274, 84);
		this.lstMethodInformation.TabIndex = 0;
		//
		//lblMethodComments
		//
		this.lblMethodComments.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblMethodComments.Location = new System.Drawing.Point(363, 10);
		this.lblMethodComments.Name = "lblMethodComments";
		this.lblMethodComments.Size = new System.Drawing.Size(150, 17);
		this.lblMethodComments.TabIndex = 7;
		this.lblMethodComments.Text = "Method Comments";
		//
		//txtMethodComments
		//
		this.txtMethodComments.AutoSize = false;
		this.txtMethodComments.BackColor = System.Drawing.Color.White;
		this.txtMethodComments.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.txtMethodComments.Location = new System.Drawing.Point(364, 31);
		this.txtMethodComments.Multiline = true;
		this.txtMethodComments.Name = "txtMethodComments";
		this.txtMethodComments.ReadOnly = true;
		this.txtMethodComments.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
		this.txtMethodComments.Size = new System.Drawing.Size(254, 84);
		this.txtMethodComments.TabIndex = 1;
		this.txtMethodComments.Text = "";
		//
		//lblMethodInformation
		//
		this.lblMethodInformation.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblMethodInformation.Location = new System.Drawing.Point(20, 10);
		this.lblMethodInformation.Name = "lblMethodInformation";
		this.lblMethodInformation.Size = new System.Drawing.Size(208, 20);
		this.lblMethodInformation.TabIndex = 2;
		this.lblMethodInformation.Text = "Method Information";
		//
		//HeaderRight
		//
		this.HeaderRight.BackColor = System.Drawing.SystemColors.Control;
		this.HeaderRight.Dock = System.Windows.Forms.DockStyle.Top;
		this.HeaderRight.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.HeaderRight.Location = new System.Drawing.Point(0, 0);
		this.HeaderRight.Name = "HeaderRight";
		this.HeaderRight.Size = new System.Drawing.Size(672, 22);
		this.HeaderRight.TabIndex = 3;
		this.HeaderRight.TitleFont = new System.Drawing.Font("Tahoma", 10f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.HeaderRight.TitleText = "";
		//
		//CustomPanelLeft
		//
		this.CustomPanelLeft.BackColor = System.Drawing.Color.CornflowerBlue;
		this.CustomPanelLeft.BackColor2 = System.Drawing.Color.Empty;
		this.CustomPanelLeft.Controls.Add(this.RealPanel3);
		this.CustomPanelLeft.Controls.Add(this.RealPanel2);
		this.CustomPanelLeft.Controls.Add(this.RealPanel1);
		this.CustomPanelLeft.Controls.Add(this.btnExtinguish);
		this.CustomPanelLeft.Controls.Add(this.HeaderLeft);
		this.CustomPanelLeft.Controls.Add(this.btnIgnite);
		this.CustomPanelLeft.Dock = System.Windows.Forms.DockStyle.Left;
		this.CustomPanelLeft.Location = new System.Drawing.Point(0, 0);
		this.CustomPanelLeft.Name = "CustomPanelLeft";
		this.CustomPanelLeft.Size = new System.Drawing.Size(132, 579);
		this.CustomPanelLeft.TabIndex = 2;
		//
		//RealPanel3
		//
		this.RealPanel3.BackColor = System.Drawing.Color.WhiteSmoke;
		this.RealPanel3.Controls.Add(this.btnLoad);
		this.RealPanel3.Controls.Add(this.btnR);
		this.RealPanel3.Controls.Add(this.btnDelete);
		this.RealPanel3.Controls.Add(this.btnN2OIgnite);
		this.RealPanel3.Location = new System.Drawing.Point(7, 30);
		this.RealPanel3.Name = "RealPanel3";
		this.RealPanel3.Size = new System.Drawing.Size(118, 44);
		this.RealPanel3.TabIndex = 14;
		this.RealPanel3.Text = "RealPanel3";
		//
		//btnLoad
		//
		this.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnLoad.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnLoad.Image = (System.Drawing.Image)resources.GetObject("btnLoad.Image");
		this.btnLoad.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnLoad.Location = new System.Drawing.Point(4, 4);
		this.btnLoad.Name = "btnLoad";
		this.btnLoad.Size = new System.Drawing.Size(110, 36);
		this.btnLoad.TabIndex = 0;
		this.btnLoad.Text = "&Load";
		this.btnLoad.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//btnR
		//
		this.btnR.BackColor = System.Drawing.Color.RoyalBlue;
		this.btnR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnR.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnR.Location = new System.Drawing.Point(78, 16);
		this.btnR.Name = "btnR";
		this.btnR.Size = new System.Drawing.Size(8, 8);
		this.btnR.TabIndex = 23;
		this.btnR.TabStop = false;
		this.btnR.Text = "&R";
		this.btnR.TextAlign = System.Drawing.ContentAlignment.TopLeft;
		//
		//btnDelete
		//
		this.btnDelete.BackColor = System.Drawing.Color.RoyalBlue;
		this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnDelete.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnDelete.Location = new System.Drawing.Point(66, 16);
		this.btnDelete.Name = "btnDelete";
		this.btnDelete.Size = new System.Drawing.Size(8, 8);
		this.btnDelete.TabIndex = 24;
		this.btnDelete.TabStop = false;
		this.btnDelete.Text = "&Delete";
		this.btnDelete.TextAlign = System.Drawing.ContentAlignment.TopLeft;
		//
		//btnN2OIgnite
		//
		this.btnN2OIgnite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnN2OIgnite.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnN2OIgnite.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnN2OIgnite.Location = new System.Drawing.Point(82, 20);
		this.btnN2OIgnite.Name = "btnN2OIgnite";
		this.btnN2OIgnite.Size = new System.Drawing.Size(5, 5);
		this.btnN2OIgnite.TabIndex = 19;
		this.btnN2OIgnite.TabStop = false;
		this.btnN2OIgnite.Text = "N2O&C";
		this.btnN2OIgnite.TextAlign = System.Drawing.ContentAlignment.TopLeft;
		//
		//RealPanel2
		//
		this.RealPanel2.BackColor = System.Drawing.Color.WhiteSmoke;
		this.RealPanel2.Controls.Add(this.btnEditData);
		this.RealPanel2.Controls.Add(this.btnExportReport);
		this.RealPanel2.Controls.Add(this.btnReportOptions);
		this.RealPanel2.Location = new System.Drawing.Point(7, 274);
		this.RealPanel2.Name = "RealPanel2";
		this.RealPanel2.Size = new System.Drawing.Size(118, 131);
		this.RealPanel2.TabIndex = 13;
		this.RealPanel2.Text = "RealPanel2";
		//
		//btnEditData
		//
		this.btnEditData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnEditData.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnEditData.Image = (System.Drawing.Image)resources.GetObject("btnEditData.Image");
		this.btnEditData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnEditData.Location = new System.Drawing.Point(4, 90);
		this.btnEditData.Name = "btnEditData";
		this.btnEditData.Size = new System.Drawing.Size(110, 36);
		this.btnEditData.TabIndex = 8;
		this.btnEditData.Text = "Edi&t Data";
		this.btnEditData.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//btnExportReport
		//
		this.btnExportReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnExportReport.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnExportReport.Image = (System.Drawing.Image)resources.GetObject("btnExportReport.Image");
		this.btnExportReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnExportReport.Location = new System.Drawing.Point(4, 47);
		this.btnExportReport.Name = "btnExportReport";
		this.btnExportReport.Size = new System.Drawing.Size(110, 36);
		this.btnExportReport.TabIndex = 7;
		this.btnExportReport.Text = "E&xport Report";
		this.btnExportReport.TextAlign = System.Drawing.ContentAlignment.TopLeft;
		//
		//btnReportOptions
		//
		this.btnReportOptions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnReportOptions.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnReportOptions.Image = (System.Drawing.Image)resources.GetObject("btnReportOptions.Image");
		this.btnReportOptions.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnReportOptions.Location = new System.Drawing.Point(4, 4);
		this.btnReportOptions.Name = "btnReportOptions";
		this.btnReportOptions.Size = new System.Drawing.Size(110, 36);
		this.btnReportOptions.TabIndex = 6;
		this.btnReportOptions.Text = "Report &Options";
		this.btnReportOptions.TextAlign = System.Drawing.ContentAlignment.TopLeft;
		//
		//RealPanel1
		//
		this.RealPanel1.BackColor = System.Drawing.Color.WhiteSmoke;
		this.RealPanel1.Controls.Add(this.btnReports);
		this.RealPanel1.Controls.Add(this.btnViewResults);
		this.RealPanel1.Controls.Add(this.btnSampleGraph);
		this.RealPanel1.Controls.Add(this.btnStandardGraph);
		this.RealPanel1.Location = new System.Drawing.Point(7, 86);
		this.RealPanel1.Name = "RealPanel1";
		this.RealPanel1.Size = new System.Drawing.Size(118, 176);
		this.RealPanel1.TabIndex = 12;
		this.RealPanel1.Text = "RealPanel1";
		//
		//btnReports
		//
		this.btnReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnReports.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnReports.Image = (System.Drawing.Image)resources.GetObject("btnReports.Image");
		this.btnReports.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnReports.Location = new System.Drawing.Point(4, 136);
		this.btnReports.Name = "btnReports";
		this.btnReports.Size = new System.Drawing.Size(110, 36);
		this.btnReports.TabIndex = 4;
		this.btnReports.Text = "&Reports";
		this.btnReports.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//btnViewResults
		//
		this.btnViewResults.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnViewResults.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnViewResults.Image = (System.Drawing.Image)resources.GetObject("btnViewResults.Image");
		this.btnViewResults.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnViewResults.Location = new System.Drawing.Point(4, 92);
		this.btnViewResults.Name = "btnViewResults";
		this.btnViewResults.Size = new System.Drawing.Size(110, 36);
		this.btnViewResults.TabIndex = 3;
		this.btnViewResults.Text = "&View Results";
		this.btnViewResults.TextAlign = System.Drawing.ContentAlignment.TopLeft;
		//
		//btnSampleGraph
		//
		this.btnSampleGraph.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnSampleGraph.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnSampleGraph.Image = (System.Drawing.Image)resources.GetObject("btnSampleGraph.Image");
		this.btnSampleGraph.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnSampleGraph.Location = new System.Drawing.Point(4, 48);
		this.btnSampleGraph.Name = "btnSampleGraph";
		this.btnSampleGraph.Size = new System.Drawing.Size(110, 36);
		this.btnSampleGraph.TabIndex = 2;
		this.btnSampleGraph.Text = "Sample   &Graph";
		this.btnSampleGraph.TextAlign = System.Drawing.ContentAlignment.TopLeft;
		//
		//btnStandardGraph
		//
		this.btnStandardGraph.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnStandardGraph.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnStandardGraph.Image = (System.Drawing.Image)resources.GetObject("btnStandardGraph.Image");
		this.btnStandardGraph.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnStandardGraph.Location = new System.Drawing.Point(4, 4);
		this.btnStandardGraph.Name = "btnStandardGraph";
		this.btnStandardGraph.Size = new System.Drawing.Size(110, 36);
		this.btnStandardGraph.TabIndex = 1;
		this.btnStandardGraph.Text = "Sta&ndard Graph";
		this.btnStandardGraph.TextAlign = System.Drawing.ContentAlignment.TopLeft;
		//
		//btnExtinguish
		//
		this.btnExtinguish.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnExtinguish.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnExtinguish.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnExtinguish.Location = new System.Drawing.Point(38, 36);
		this.btnExtinguish.Name = "btnExtinguish";
		this.btnExtinguish.Size = new System.Drawing.Size(16, 14);
		this.btnExtinguish.TabIndex = 11;
		this.btnExtinguish.TabStop = false;
		this.btnExtinguish.Text = "&Extinguish";
		this.btnExtinguish.TextAlign = System.Drawing.ContentAlignment.TopLeft;
		//
		//HeaderLeft
		//
		this.HeaderLeft.BackColor = System.Drawing.SystemColors.Control;
		this.HeaderLeft.Dock = System.Windows.Forms.DockStyle.Top;
		this.HeaderLeft.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.HeaderLeft.Location = new System.Drawing.Point(0, 0);
		this.HeaderLeft.Name = "HeaderLeft";
		this.HeaderLeft.Size = new System.Drawing.Size(132, 22);
		this.HeaderLeft.TabIndex = 8;
		this.HeaderLeft.TitleFont = new System.Drawing.Font("Tahoma", 10f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.HeaderLeft.TitleText = "Parameters";
		//
		//btnIgnite
		//
		this.btnIgnite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnIgnite.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnIgnite.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnIgnite.Location = new System.Drawing.Point(66, 36);
		this.btnIgnite.Name = "btnIgnite";
		this.btnIgnite.Size = new System.Drawing.Size(16, 14);
		this.btnIgnite.TabIndex = 10;
		this.btnIgnite.TabStop = false;
		this.btnIgnite.Text = "&Ignition";
		this.btnIgnite.TextAlign = System.Drawing.ContentAlignment.TopLeft;
		//
		//frmDataFiles
		//
		this.AutoScale = false;
		this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
		this.CausesValidation = false;
		this.ClientSize = new System.Drawing.Size(804, 579);
		this.Controls.Add(this.CustomPanelMain);
		this.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		this.IsMdiContainer = true;
		this.Name = "frmDataFiles";
		this.Text = "Data Files";
		this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
		this.CustomPanelMain.ResumeLayout(false);
		this.CustomPanelRight.ResumeLayout(false);
		this.CustomPanelRightTop.ResumeLayout(false);
		this.CustomPanelRightBottom.ResumeLayout(false);
		this.CustomPanelLeft.ResumeLayout(false);
		this.RealPanel3.ResumeLayout(false);
		this.RealPanel2.ResumeLayout(false);
		this.RealPanel1.ResumeLayout(false);
		this.ResumeLayout(false);

	}

	#End Region

	#Region " Private Variables "

	private int mintMethodMode = 0;
	private int mintSelectedRunNumber;
	private int mintSelectedMethodID;
	private AldysGraph.CurveItem mobjPreviewCurve;
	private clsDataFileReport mobjClsDataFileReport = new clsDataFileReport();
	private clsMethod mobjClsMethod;
	private Spectrum.EnergySpectrumParameter mobjParameters = new Spectrum.EnergySpectrumParameter();
		//Saurabh 22.07.07 for store datatable of Load Analysis 
	private frmLoadAnalysis mobjfrmLoadAnalysis;
	private DataTable mdtMultiReport = new DataTable();
	private bool mblnAvoidProcessing = false;
		#End Region
	frmReportOptions mobjfrmReportOptions;

	#Region " Private Properties "

	//Private Property OpenMethodMode() As EnumMethodMode
	//    Get
	//        Return mintMethodMode
	//    End Get
	//    Set(ByVal Value As EnumMethodMode)
	//        mintMethodMode = Value
	//    End Set
	//End Property

	#End Region

	#Region " Private Constants "

	private const  ConstCreatedBy = "Created By  ";
	private const  ConstCreatedOn = "Created On  ";
	private const  ConstStatus = "Status";
	private const  ConstChangedOn = "Changed On  ";
	private const  ConstLastUsedOn = "Last Used On";
	private const  ConstActive = "Active";
	private const  ConstNotActive = "Inactive (Method parameters are incomplete)";
	private string ConstFormLoad = gstrTitleInstrumentType + "-Data Files";
		#End Region
	private string ConstParentFormLoad = gstrTitleInstrumentType + "-Method";

	#Region " Form Events "

	public void  // ERROR: Handles clauses are not supported in C#
frmDataFiles_Load(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : frmDataFiles_Load
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To initialize the form
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : 07.10.06
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();

		try {
			if (gstructSettings.AppMode == EnumAppMode.FullVersion_201) {
				btnIgnite.Enabled = false;
				btnExtinguish.Enabled = false;
			}

			btnLoad.BringToFront();
			btnLoad.Focus();
			this.FormBorderStyle = FormBorderStyle.FixedSingle;
			//Show progress bar
			gobjMain.ShowProgressBar(ConstFormLoad);
			//add handlers to buttons
			AddHandlers();

			//XpPanelStandardGraph.Enabled = False
			//XpPanelSampleGraph.Enabled = False
			//XpPanelViewResults.Enabled = False
			//XpPanelReports.Enabled = False
			//XpPanelReportOptions.Enabled = False
			//XpPanelExportReport.Enabled = False
			//XpPanelEditData.Enabled = False
			//disable all buttons for 1 st time
			btnPrintGraph.BringToFront();
			cmdChangeScale.BringToFront();
			btnStandardGraph.Enabled = false;
			btnSampleGraph.Enabled = false;
			btnViewResults.Enabled = false;
			btnReports.Enabled = false;
			btnReportOptions.Enabled = false;
			btnExportReport.Enabled = false;
			btnPrintGraph.Enabled = false;
			btnEditData.Enabled = false;

			//CustomPanelLeft.Width = 168
			//XpPanelGroup1.Width = 160
			//HeaderLeft.Width = 168
			//'lblMethod.Location = New Point(19, 20)
			//'txtMethod.Location = New Point(91, 16)
			//'lblRunNo.Location = New Point(312, 18)
			//'txtRunNo.Location = New Point(376, 17)
			//'lblMethodInformation.Location = New Point(18, 10)
			//'lstMethodInformation.Location = New Point(22, 31)
			//'lblMethodComments.Location = New Point(369, 10)
			//'txtMethodComments.Location = New Point(364, 31)
			//'lstMethodInformation.Size = New Size(274, 84)
			//'txtMethodComments.Size = New Size(254, 84)
			//PreviewGraph.XAxisMin = mobjParameters.XaxisMin
			//PreviewGraph.XAxisMax = mobjParameters.XaxisMax
			//-----Added By Pankaj on 10 May 2007
			//update graph scale and label
			if (!IsNothing(gobjNewMethod)) {
				if (gobjNewMethod.OperationMode == EnumOperationMode.MODE_EMMISSION) {
					PreviewGraph.YAxisMin = -10.0;
					PreviewGraph.YAxisMax = 100;
					PreviewGraph.YAxisLabel = "EMISSION";
				} else {
					PreviewGraph.YAxisMin = -0.2;
					PreviewGraph.YAxisMax = 1.2;
				}
			} else {
				PreviewGraph.YAxisMin = -0.2;
				PreviewGraph.YAxisMax = 1.2;
			}
			PreviewGraph.IsShowGrid = true;
			cmdChangeScale.BringToFront();
			//adjust the graph scale for proper end points
			gobjClsAAS203.Calculate_Analysis_Graph_Param(PreviewGraph, ClsAAS203.enumChangeAxis.xyAxis);
			//-------------

			//Saurabh 10.07.07 To bring status form in front
			gobjfrmStatus.Show();
		//Saurabh
		//'Added by praveen to solve Methodfrm overlaping prob
		//gobjMain.mobjfrmMethod.SendToBack()
		//gobjMain.mobjfrmMethod.Visible = False
		//'Ended by praveen
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			objWait.Dispose();
			gobjMain.HideProgressBar();
			//---------------------------------------------------------
		}
	}

	private void  // ERROR: Handles clauses are not supported in C#
frmDataFiles_Closing(object sender, System.ComponentModel.CancelEventArgs e)
	{
		//=====================================================================
		// Procedure Name        : frmDataFiles_Closing
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : 
		// Description           :  
		// Assumptions           : 
		// Dependencies          : 
		// Author                :  
		// Created               : 1.05.07
		// Revisions             : 
		//=====================================================================
		gobjMain.ShowRunTimeInfo(ConstParentFormLoad);
	}

	private void  // ERROR: Handles clauses are not supported in C#
cmdChangeScale_Click(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : cmdChangeScale_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : 
		// Description           : calculate change scale
		// Assumptions           : 
		// Dependencies          : 
		// Author                : 
		// Created               : 1.05.07
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		frmChangeScale objfrmChangeScale;

		try {
			//Change the graph coordinates
			objfrmChangeScale = new frmChangeScale(mobjParameters, false);


			objfrmChangeScale.funcSetValidatingScale(gobjInst.Mode);
			objfrmChangeScale.lblXAxis.Visible = false;
			//Set the graph parametes to the change scale form object
			//-------------Added By Pankaj 11 May 07 for showing default scale on change form
			objfrmChangeScale.SpectrumParameter.XaxisMin = PreviewGraph.XAxisMin;
			objfrmChangeScale.SpectrumParameter.XaxisMax = PreviewGraph.XAxisMax;

			objfrmChangeScale.SpectrumParameter.YaxisMin = PreviewGraph.YAxisMin;
			objfrmChangeScale.SpectrumParameter.YaxisMax = PreviewGraph.YAxisMax;
			//------------------------

			if (objfrmChangeScale.ShowDialog() == DialogResult.OK) {
				//Set the change scale form objectparametes to the graph object

				if (!objfrmChangeScale.SpectrumParameter == null) {
					mobjParameters.XaxisMax = objfrmChangeScale.SpectrumParameter.XaxisMax;
					mobjParameters.XaxisMin = objfrmChangeScale.SpectrumParameter.XaxisMin;
					mobjParameters.YaxisMax = objfrmChangeScale.SpectrumParameter.YaxisMax;
					mobjParameters.YaxisMin = objfrmChangeScale.SpectrumParameter.YaxisMin;

				}
				PreviewGraph.XAxisMin = mobjParameters.XaxisMin;
				PreviewGraph.XAxisMax = mobjParameters.XaxisMax;

				PreviewGraph.YAxisMin = mobjParameters.YaxisMin;
				PreviewGraph.YAxisMax = mobjParameters.YaxisMax;

				//calculate graph parameters
				gobjClsAAS203.Calculate_Analysis_Graph_Param(PreviewGraph, ClsAAS203.enumChangeAxis.xyAxis);

			}
			objfrmChangeScale.Close();



		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			objfrmChangeScale.Dispose();
			if (!objWait == null) {
				objWait.Dispose();
			}
			//mblnAvoidProcessing = False
			//---------------------------------------------------------
		}
	}

	#End Region

	#Region " Private Functions "

	private void AddHandlers()
	{
		//=====================================================================
		// Procedure Name        : AddHandlers
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : To add event handlers
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh
		// Created               : 05.10.06
		// Revisions             : 
		//=====================================================================
		try {
			//Add event handlers to buttons
			btnPrintGraph.Click += tlbbtnPrintGraph_Click;
			btnStandardGraph.Click += tlbbtnStandardGraph_Click;
			btnSampleGraph.Click += tlbbtnSampleGraph_Click;
			btnViewResults.Click += tlbbtnViewResults_Click;
			btnReports.Click += tlbbtnReports_Click;
			btnReportOptions.Click += tlbbtnReportOptions_Click;
			btnLoad.Click += tlbbtnLoad_Click;
			btnExportReport.Click += tlbbtnExportReport_Click;
			btnEditData.Click += tlbbtnEditData_Click;
			btnDelete.Click += btnDelete_Click;
			btnR.Click += btnR_Click;

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			//---------------------------------------------------------
		}

	}

	private void tlbbtnBack_Click(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : tlbbtnBack_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To exit frmDataFiles and load frmMDIMain form
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 25.09.06
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();

		try {
			this.Close();
			//close datafile window

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			if (!objWait == null) {
				objWait.Dispose();
			}
			//---------------------------------------------------------
		}
	}

	private bool SetColorPropertiesForXpPanel(ref UIComponents.XPPanel objXpPanelIn, string strCaptionNameIn)
	{
		//=====================================================================
		// Procedure Name        : SetColorPropertiesForXpPanel
		// Parameters Passed     : objXpPanelIn,strCaptionNameIn
		// Returns               : True or False
		// Purpose               : To set color properties to xp panel
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : 05.10.06
		// Revisions             : 
		//=====================================================================
		try {
			//Set the color and other setting to xp panel parameters object
			objXpPanelIn.Caption = strCaptionNameIn;

			objXpPanelIn.CaptionGradient.Color2 = Color.CornflowerBlue;
			objXpPanelIn.CaptionGradient.Color1 = Color.FromArgb(205, 225, 250);

			objXpPanelIn.PanelGradient.Color1 = Color.White;
			//Color.FromArgb(205, 225, 250)
			objXpPanelIn.PanelGradient.Color2 = Color.Gainsboro;
			//Color.FromArgb(175, 200, 245)

			objXpPanelIn.CaptionUnderline = Color.CornflowerBlue;
			objXpPanelIn.CurveRadius = 8;
			objXpPanelIn.Dock = DockStyle.None;
			objXpPanelIn.GradientOffset = 0.2;
			objXpPanelIn.HorzAlignment = StringAlignment.Near;
			objXpPanelIn.Spacing = new Point(5, 0);
			objXpPanelIn.TextColors.Color1 = Color.FromArgb(33, 93, 198);
			objXpPanelIn.TextColors.Color2 = Color.FromArgb(0, 0, 0, 0);
			objXpPanelIn.TextHighlightColors.Color1 = Color.FromArgb(66, 142, 255);
			objXpPanelIn.TextHighlightColors.Color2 = Color.FromArgb(0, 0, 0, 0);
			objXpPanelIn.VertAlignment = StringAlignment.Center;
			objXpPanelIn.XPPanelStyle = UIComponents.XPPanelStyle.WindowsXP;
			objXpPanelIn.OutlineColor = Color.FromArgb(175, 200, 245);
			objXpPanelIn.Visible = true;
			objXpPanelIn.PanelState = UIComponents.XPPanelState.Collapsed;
			objXpPanelIn.Width = this.Width;
			objXpPanelIn.Height = 100;
			objXpPanelIn.AnimationRate = 1;

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			//---------------------------------------------------------
		}

	}

	private void tlbbtnStandardGraph_Click(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : tlbbtnStandardGraph_Click
		// Parameters Passed     : Object, EventArgs
		// Returns               : 
		// Purpose               : To show the Standard Graph form.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 05.10.06
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();

		try {
			//tlbbtnStandardGraph.SuspendEvents()
			// to show the Sample Graph 
			// Create_Standard_Sample_Curve function of clsstandardgraph object is use 
			// 1 param 'blnIsSampleIn' is bool to show Standard and Sample or Standard graph
			// 2 param 'blnIsAnalysisModeIn' is bool to check in analysis mode or not 
			// 3 param 'intSelectedMethodId' is int to set Method ID from collection object
			// 4 param 'intSelectedRunNumber' is int to set selected Run No from Method object
			// 5 param objNewMethod is Method object type by Ref. to return Method object

			gobjclsStandardGraph = new clsStandardGraph();
			gobjclsStandardGraph.Create_Standard_Sample_Curve(false, false, mintSelectedMethodID, mintSelectedRunNumber, mobjClsMethod);

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			if (!objWait == null) {
				objWait.Dispose();
			}
			//tlbbtnStandardGraph.ResumeEvents()
			//---------------------------------------------------------
		}
	}

	private void tlbbtnSampleGraph_Click(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : tlbbtnSampleGraph_Click
		// Parameters Passed     : Object, EventArgs
		// Returns               : 
		// Purpose               : To show the Sample Graph form.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 05.10.06
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();

		try {
			//tlbbtnSampleGraph.SuspendEvents()
			// to show the Sample Graph 
			// Create_Standard_Sample_Curve function of clsstandardgraph object is use 
			// 1 param 'blnIsSampleIn' is bool to show Standard and Sample or Standard graph
			// 2 param 'blnIsAnalysisModeIn' is bool to check in analysis mode or not 
			// 3 param 'intSelectedMethodId' is int to set Method ID from collection object
			// 4 param 'intSelectedRunNumber' is int to set selected Run No from Method object
			// 5 param objNewMethod is Method object type by Ref. to return Method object
			gobjclsStandardGraph = new clsStandardGraph();
			gobjclsStandardGraph.Create_Standard_Sample_Curve(true, false, mintSelectedMethodID, mintSelectedRunNumber, mobjClsMethod);

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			if (!objWait == null) {
				objWait.Dispose();
			}
			//tlbbtnSampleGraph.ResumeEvents()
			//---------------------------------------------------------
		}
	}

	private void tlbbtnViewResults_Click(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : tlbbtnViewResults_Click
		// Parameters Passed     : Object, EventArgs
		// Returns               : 
		// Purpose               : To show the Results of the Analysis.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 05.10.06
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		frmViewResults objfrmViewResults;

		try {
			// Show the Data Report into tabulor format on screen
			objfrmViewResults = new frmViewResults(false, mintSelectedMethodID, mintSelectedRunNumber, mobjClsMethod);
			objfrmViewResults.ShowDialog();
			Application.DoEvents();
			objfrmViewResults.Close();
			objfrmViewResults.Dispose();
			objfrmViewResults = null;

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			if (!objWait == null) {
				objWait.Dispose();
			}
			//---------------------------------------------------------
		}
	}

	private void tlbbtnReports_Click(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : tlbbtnReports_Click
		// Parameters Passed     : Object, EventArgs
		// Returns               : 
		// Purpose               : To show the Reports.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 05.10.06
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		int intSelectIDIndex;
		int intCount;

		try {
			//-----Added By Pankaj Fri 18 May 07
			//check user having authority to use the module
			if ((gstructSettings.Enable21CFR == true)) {
				if (!funcCheckActivityAuthentication(enumActivityAuthentication.Print, gstructUserDetails.Access)) {
					return;
				}
				gfuncInsertActivityLog(EnumModules.Print, "Print DataFiles Report Accessed");
			}
			//------
			//tlbbtnLoad.SuspendEvents()


			//----Be Careful NOT TO USE index to assign MethodID or RunNumber

			// Selecte Method ID
			for (intCount = 0; intCount <= gobjMethodCollection.Count - 1; intCount++) {
				if (mintSelectedMethodID == gobjMethodCollection(intCount).MethodID) {
					intSelectIDIndex = intCount;
					//mobjClsDataFileReport.MethodID = intCount
					mobjClsDataFileReport.MethodID = gobjMethodCollection(intCount).MethodID;
					break; // TODO: might not be correct. Was : Exit For
				}
			}
			// Select Run No from selected Method object
			for (intCount = 0; intCount <= gobjMethodCollection(intSelectIDIndex).QuantitativeDataCollection.Count - 1; intCount++) {
				if (mintSelectedRunNumber == (int)gobjMethodCollection(intSelectIDIndex).QuantitativeDataCollection(intCount).RunNumber) {
					mobjClsDataFileReport.RunNumber = mintSelectedRunNumber;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			mobjClsDataFileReport.DefaultFont = this.DefaultFont;

			// send the Data Report to the Report Object
			//Call mobjClsDataFileReport.funcDatafilePrint()
			mobjClsDataFileReport.funcDatafilePrintForMethod();
			//by Pankaj on 21 feb08

		//Call mobjClsDataFileReport.funcStandardGraphPrint(Me.PreviewGraph)
		//Me.PreviewGraph.XAxisDateScaleFormat = AAS203.AASGraph.enumDateScaleFormat.HHMM
		//Call mobjClsDataFileReport.funcStandardGraphPrint(Me.PreviewGraph, "Hi Sachin")
		//Call mobjClsDataFileReport.funcSampleGraphPrint(Me.PreviewGraph, "Hi Sachin")

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			//tlbbtnLoad.ResumeEvents()
			objWait.Dispose();
			//---------------------------------------------------------
		}
	}

	private void tlbbtnPrintGraph_Click(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : tlbbtnPrintGraph_Click
		// Parameters Passed     : Object, EventArgs
		// Returns               : None
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 17-May-2007 03:25 pm
		// Revisions             : 1
		//=====================================================================



		CWaitCursor objWait = new CWaitCursor();
		//Dim A1() As Double = {0, 0, 0, 0, 0, 0}

		try {
			//-----Added By Pankaj Fri 18 May 07
			//check for 21 CFR
			if ((gstructSettings.Enable21CFR == true)) {
				if (!funcCheckActivityAuthentication(enumActivityAuthentication.Print, gstructUserDetails.Access)) {
					return;
					return;
				}
				gfuncInsertActivityLog(EnumModules.Print, "Print DataFiles Graph Accessed");
			}
			//------

			//If (toreported) Then 'OR NOT Method->RepReady )
			//gobjClsAAS203.SaveQuantResults(gobjNewMethod, A1, False)
			//toreported = False
			//PreviewGraph.PrintPreViewGraph()
			int mintRunNumberIndex;
			//Print the Histograph object including result
			//---For Data Files Mode
			mintRunNumberIndex = gfuncGetSelectedMethodRunNumberIndex(mobjClsMethod.MethodID, mintSelectedRunNumber);
			mobjClsDataFileReport.RunNumber = mobjClsMethod.QuantitativeDataCollection(mintRunNumberIndex).RunNumber;
			//End If

			mobjClsDataFileReport.DefaultFont = this.DefaultFont;

			//Graph.XAxisDateScaleFormat = AAS203.AASGraph.enumDateScaleFormat.HHMM

			mobjClsDataFileReport.funcHistographPrint(PreviewGraph, mobjClsMethod);


		//End If

		//if (gobjNewMethod.RepReady )
		//   OnReportPrint(gobjNewMethod)
		//end if

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			if (!objWait == null) {
				objWait.Dispose();
			}
			//---------------------------------------------------------
		}
	}

	private void tlbbtnReportOptions_Click(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : tlbbtnReportOptions_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To load the frmReportOptions form
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 25.09.06
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		//Dim objfrmReportOptions As frmReportOptions
		int intSelectedRunNumberIndex;
		try {
			// Set the report parameter for Analysis data report
			// To set parameters use frmReportOptions form.

			mobjfrmReportOptions = new frmReportOptions(EnumMethodMode.EditMode, true, mintSelectedMethodID, mintSelectedRunNumber, mobjClsMethod);
			mobjfrmReportOptions.ShowDialog();
			//'If objfrmReportOptions.ShowDialog() = DialogResult.OK Then   '4.85   12.04.09
			//'    'Set the clsMethod object to set report from Method collection object.
			//'    For intCounter As Integer = 0 To gobjMethodCollection.Count - 1
			//'        If gobjMethodCollection.item(intCounter).MethodID = mintSelectedMethodID Then
			//'            intSelectedRunNumberIndex = gfuncGetSelectedMethodRunNumberIndex(mintSelectedMethodID, mintSelectedRunNumber)
			//'            If intSelectedRunNumberIndex >= 0 Then
			//'                gobjMethodCollection.item(intCounter).QuantitativeDataCollection(intSelectedRunNumberIndex).ReportParameters = mobjClsMethod.ReportParameters.Clone    '4.85 12.04.09
			//'                'gobjMethodCollection.item(intCounter).QuantitativeDataCollection(intSelectedRunNumberIndex).ReportParameters = gobjMethodCollection.item(intCounter).ReportParameters.Clone  '4.85 12.04.09
			//'                'mobjClsMethod = gobjMethodCollection.item(intCounter).Clone()  '4.85 12.04.09
			//'                funcSaveAllMethods(gobjMethodCollection) '4.85  12.04.09
			//'                Exit For   '4.85  12.04.09
			//'            End If
			//'        End If
			//'    Next
			//'End If

			Application.DoEvents();
			mobjfrmReportOptions.Close();
			mobjfrmReportOptions.Dispose();
			mobjfrmReportOptions = null;


		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			if (!objWait == null) {
				objWait.Dispose();
			}
			//---------------------------------------------------------
		}
	}

	private void tlbbtnLoad_Click(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : tlbbtnLoad_Click
		// Parameters Passed     : Object, EventArgs
		// Returns               : 
		// Purpose               : To load the Analysis already saved.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 05.10.06
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		int intRunNumberIndex;
		int intCounter;
		int intCount;
		string strRunNo;
		int intAnalysisRawDataCount;
		int intIntegrationTime;
		int intX_Max;
		mobjfrmLoadAnalysis = new frmLoadAnalysis(mdtMultiReport);
		try {
			//tlbbtnLoad.SuspendEvents()
			//Show the frmLoadAnalysis form object to select and load analysis Run No.
			if (mobjfrmLoadAnalysis.ShowDialog() == DialogResult.Cancel) {
				return;
			}
			Application.DoEvents();
			// Set  the selected method ID
			mintSelectedMethodID = mobjfrmLoadAnalysis.SelectedMethodID;
			// Set  the selected Run Numbser
			mintSelectedRunNumber = mobjfrmLoadAnalysis.SelectedRunNumber;
			mobjfrmLoadAnalysis.Close();
			mobjfrmLoadAnalysis.Dispose();
			// Select the index of run No from Method objects
			intRunNumberIndex = modGlobalFunctions.gfuncGetSelectedMethodRunNumberIndex(mintSelectedMethodID, mintSelectedRunNumber);
			// Find details info. about seleted method and analyse Run number
			for (intCounter = 0; intCounter <= gobjMethodCollection.Count - 1; intCounter++) {

				if (gobjMethodCollection.item(intCounter).MethodID == mintSelectedMethodID) {
					mobjClsMethod = gobjMethodCollection.item(intCounter).Clone();
					mobjClsMethod.ReportParameters = gobjMethodCollection.item(intCounter).QuantitativeDataCollection.Item(intRunNumberIndex).ReportParameters.Clone;
					//4.85 12.04.09

					strRunNo = mobjClsMethod.QuantitativeDataCollection.Item(intRunNumberIndex).RunNumber;
					gintCalcMode = 100;
					//29.04.08
					//-----Saurabh--To extend graph beyond 100---21.06.07
					intAnalysisRawDataCount = mobjClsMethod.QuantitativeDataCollection.Item(intRunNumberIndex).AnalysisRawData.Count;
					intIntegrationTime = mobjClsMethod.QuantitativeDataCollection.Item(intRunNumberIndex).AnalysisParameters.IntegrationTime;
					intX_Max = (int)(intIntegrationTime * intAnalysisRawDataCount) + 20;
					//-----Saurabh
					//Set the genetal information of method on display object
					funcShowMethodGeneralInfo(mobjClsMethod, strRunNo);


					// Set form object.
					btnStandardGraph.Enabled = true;
					btnSampleGraph.Enabled = true;
					btnViewResults.Enabled = true;
					btnReports.Enabled = true;
					btnPrintGraph.Enabled = true;
					btnReportOptions.Enabled = true;
					btnExportReport.Enabled = true;
					btnEditData.Enabled = true;

					break; // TODO: might not be correct. Was : Exit For

				}
			}
			//-----Saurabh
			PreviewGraph.XAxisMax = (int)intX_Max;
			//-----Saurabh

			//----added by deepak on 22.07.07
			int intStdCount;
			int intSplCount;
			int intStdCounter;
			int intStdRepCount;
			int intSplRepCount;
			int intRepCounter;
			int intSplCounter;
			intStdCount = mobjClsMethod.QuantitativeDataCollection.Item(intRunNumberIndex).StandardDataCollection.Count;
			intSplCount = mobjClsMethod.QuantitativeDataCollection.Item(intRunNumberIndex).SampleDataCollection.Count;
			for (intStdCounter = 0; intStdCounter <= intStdCount - 1; intStdCounter++) {
				intStdRepCount = mobjClsMethod.QuantitativeDataCollection.Item(intRunNumberIndex).StandardDataCollection.item(intStdCounter).AbsRepeat.AbsRepeatData.Count;
				for (intRepCounter = 0; intRepCounter <= intStdRepCount - 1; intRepCounter++) {
					mobjClsMethod.QuantitativeDataCollection.Item(intRunNumberIndex).StandardDataCollection.item(intStdCounter).AbsRepeat.AbsRepeatData.item(intRepCounter).Used = true;
				}
			}
			for (intSplCounter = 0; intSplCounter <= intSplCount - 1; intSplCounter++) {
				intStdRepCount = mobjClsMethod.QuantitativeDataCollection.Item(intRunNumberIndex).SampleDataCollection.item(intSplCounter).AbsRepeat.AbsRepeatData.Count;
				for (intRepCounter = 0; intRepCounter <= intStdRepCount - 1; intRepCounter++) {
					mobjClsMethod.QuantitativeDataCollection.Item(intRunNumberIndex).SampleDataCollection.item(intSplCounter).AbsRepeat.AbsRepeatData.item(intRepCounter).Used = true;
				}
			}
			//----added by deepak on 22.07.07

			gobjClsAAS203.Calculate_Analysis_Graph_Param(PreviewGraph, ClsAAS203.enumChangeAxis.xyAxis);
			PreviewGraph.IsShowGrid = true;
			PreviewGraph.Refresh();
			//'Added  by praveen for std graph
			//'It was not showing std graph on load .for this problem
			gobjclsStandardGraph = new clsStandardGraph();
			gobjclsStandardGraph.Create_Standard_Sample_Curve(false, false, mintSelectedMethodID, mintSelectedRunNumber, mobjClsMethod);
			//'end praveen
			//Added By Pankaj on 17 Aug 07 for updating title
			if (!mobjClsMethod == null) {
				DataRow objRow;
				objRow = gobjClsAAS203.funcGetMethodType(mobjClsMethod.OperationMode);
				HeaderRight.TitleText = (string)objRow.Item("MethodType");
			}
		//End

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			if (!objWait == null) {
				objWait.Dispose();
			}
			//tlbbtnLoad.ResumeEvents()
			//---------------------------------------------------------
		}
	}

	private void tlbbtnExportReport_Click(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : tlbbtnExportReport_Click
		// Parameters Passed     : Object, EventArgs
		// Returns               : 
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S & Sachin Dokhale
		// Created               : 05.10.06
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		int intSelectId;
		int intCount;
		try {
			// Export the Data Report into Doc.(Word) format
			//Added By Pankaj Fri 18 May 07
			//check for 21 CFR
			if ((gstructSettings.Enable21CFR == true)) {
				if (!funcCheckActivityAuthentication(enumActivityAuthentication.Export, gstructUserDetails.Access)) {
					return;
					return;
				}
				gfuncInsertActivityLog(EnumModules.Export, "Export Accessed");
			}

			//tlbbtnLoad.SuspendEvents()
			//mobjClsDataFileReport.MethodID = mintSelectedMethodID
			//mobjClsDataFileReport.RunNumber = mintSelectedRunNumber
			//For intCount = 0 To gobjMethodCollection.Count - 1
			//    If mintSelectedMethodID = gobjMethodCollection(intCount).MethodID Then
			//        intSelectId = intCount
			//        mobjClsDataFileReport.MethodID = intCount
			//        Exit For
			//    End If
			//Next
			// Selecte Method ID
			for (intCount = 0; intCount <= gobjMethodCollection.Count - 1; intCount++) {
				if (mintSelectedMethodID == gobjMethodCollection(intCount).MethodID) {
					//intSelectIDIndex = intCount
					intSelectId = intCount;
					//mobjClsDataFileReport.MethodID = intCount
					mobjClsDataFileReport.MethodID = gobjMethodCollection(intCount).MethodID;
					break; // TODO: might not be correct. Was : Exit For
				}
			}
			// Select Run No from selected Method object
			for (intCount = 0; intCount <= gobjMethodCollection(intSelectId).QuantitativeDataCollection.Count - 1; intCount++) {
				if (mintSelectedRunNumber == (int)gobjMethodCollection(intSelectId).QuantitativeDataCollection(intCount).RunNumber) {
					mobjClsDataFileReport.RunNumber = mintSelectedRunNumber;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			//For intCount = 0 To gobjMethodCollection(intSelectId).QuantitativeDataCollection.Count - 1
			//    If mintSelectedRunNumber = CInt(gobjMethodCollection(intSelectId).QuantitativeDataCollection(intCount).RunNumber) Then

			//        mobjClsDataFileReport.RunNumber = mintSelectedRunNumber
			//        Exit For
			//    End If
			//Next
			// send the Data Report to the Report Object
			//Call mobjClsDataFileReport.funcDatafileExport(gobjMethodCollection(intSelectId).QuantitativeDataCollection(intCount).ReportParameters)
			mobjClsDataFileReport.funcDatafileExportForMethod(gobjMethodCollection(intSelectId).QuantitativeDataCollection(intCount).ReportParameters);
			// by Pankaj on 21 feb 08

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			if (!objWait == null) {
				objWait.Dispose();
			}
			//---------------------------------------------------------
		}
	}

	private void tlbbtnEditData_Click(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : tlbbtnEditData_Click
		// Parameters Passed     : Object, EventArgs
		// Returns               : 
		// Purpose               : To Edit data of the previously saved Analysis.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 05.10.06
		// Revisions             : 2 ; By Mangesh S. on 09-Mar-2007
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();

		//gobjMain.ShowRunTimeInfo(ConstFormLoad)
		//tlbbtnEditData.SuspendEvents()
		//objfrmDeleteStdNSam.ShowDialog()

		//Call OnViewRepeats()


		//---- ORIGINAL CODE

		//BOOL	OnViewRepeats(HWND	hpar)
		//{
		//   BOOL	flag = FALSE;
		//   DLGPROC  skp1;
		//   if (Method->QuantData==NULL)
		//	    return flag;
		//   if ((Method->QuantData->Param.Repeat>1 || Method->QuantData->Param.ConcRepeat>1 )&&  FindSamplesAnalysed()>=1) 
		//   {
		//	    skp1 =(DLGPROC) MakeProcInstance((DLGPROC) OnViewRepeatsProc,hInst);
		//	    flag = DialogBox(hInst,"QVIEWRPTS", hpar, skp1);
		//	    FreeProcInstance(skp1);
		//  }
		//   Else
		//	    flag = OnEditStdSamples(hpar);
		//   return flag;
		//}
		//****************************************************************
		bool flag = false;
		int intSelectedRunNumberIndex;
		frmDeleteStdNSam objfrmDeleteStdNSam;
		frmViewRepeatResults objfrmViewRepeatResults;

		try {
			// Set the report parameter for Analysis data report
			// To set parameters use frmReportOptions form.
			// Shows and edit the sample and standard value of Abs and Conc. results

			if (IsNothing(mobjClsMethod.QuantitativeDataCollection)) {
				//Return flag
				return;
			}

			intSelectedRunNumberIndex = gfuncGetSelectedMethodRunNumberIndex(mintSelectedMethodID, mintSelectedRunNumber);
			// Shows and edit the sample and standard value of Abs and Conc. for Repeat Results

			if (((mobjClsMethod.QuantitativeDataCollection.Item(intSelectedRunNumberIndex).AnalysisParameters.NumOfSampleRepeats > 1 | mobjClsMethod.QuantitativeDataCollection.Item(intSelectedRunNumberIndex).AnalysisParameters.NumOfStdRepeats > 1) & clsStandardGraph.FindSamplesAnalysed(mobjClsMethod, intSelectedRunNumberIndex) >= 1)) {
				objfrmViewRepeatResults = new frmViewRepeatResults(mobjClsMethod, intSelectedRunNumberIndex);
				objfrmViewRepeatResults.ShowDialog();
				Application.DoEvents();
				objfrmViewRepeatResults.Close();
				objfrmViewRepeatResults.Dispose();
				objfrmViewRepeatResults = null;
			} else {
				// Shows and edit the sample and standard value of Abs and Conc. for single analysis results
				//flag = OnEditStdSamples()
				objfrmDeleteStdNSam = new frmDeleteStdNSam(mobjClsMethod, intSelectedRunNumberIndex);
				if (objfrmDeleteStdNSam.ShowDialog() == DialogResult.OK) {
					tlbbtnSampleGraph_Click(sender, e);
				}
				Application.DoEvents();
				objfrmDeleteStdNSam.Close();
				objfrmDeleteStdNSam.Dispose();
				objfrmDeleteStdNSam = null;
				flag = true;
			}

		//Return flag

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			if (!objWait == null) {
				objWait.Dispose();
			}
			//---------------------------------------------------------
		}
	}

	private bool funcShowMethodGeneralInfo(clsMethod objMethod, string strRunNo)
	{
		//=====================================================================
		// Procedure Name        : funcShowMethodGeneralInfo
		// Parameters Passed     : None
		// Returns               : True or False
		// Purpose               : To show method information 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : 05.10.06
		// Revisions             : 
		//=====================================================================
		DataRow objRow;
		string strStatus = "";

		try {
			//Show the Method and selected Run No. Information on screen

			txtMethod.Text = objMethod.MethodName;
			txtRunNo.Text = strRunNo;
			txtMethodComments.Text = objMethod.Comments;

			objRow = gobjClsAAS203.funcGetMethodType(objMethod.OperationMode);

			if (objMethod.Status == true) {
				strStatus = ConstActive;
			} else {
				strStatus = ConstNotActive;
			}

			string strDateOfModification;
			string strDateOfLastUse;
			if (!objMethod.DateOfModification == System.DateTime.FromOADate(0.0)) {
				strDateOfModification = Format(objMethod.DateOfModification, "dd-MMM-yyyy hh:mm tt");
			}
			if (!objMethod.DateOfLastUse == System.DateTime.FromOADate(0.0)) {
				strDateOfLastUse = Format(objMethod.DateOfLastUse, "dd-MMM-yyyy hh:mm tt");
			}
			//fill list box
			lstMethodInformation.Items.Clear();
			lstMethodInformation.Items.Add(ConstCreatedBy + vbTab + objMethod.UserName);
			lstMethodInformation.Items.Add(ConstCreatedOn + vbTab + Format(objMethod.DateOfCreation, "dd-MMM-yyyy hh:mm tt"));
			//lstMethodInformation.Items.Add(ConstStatus & Space(19) & strStatus)
			lstMethodInformation.Items.Add(ConstStatus + vbTab + vbTab + strStatus);
			lstMethodInformation.Items.Add(ConstChangedOn + vbTab + strDateOfModification);
			lstMethodInformation.Items.Add(ConstLastUsedOn + vbTab + strDateOfLastUse);
			cmdChangeScale.Visible = true;
			btnPrintGraph.Visible = true;
			// Separate the info. of diff. opration Mode by UV ABS, Emission and other mode
			// In UV Abs analysis graph is not shown or appear 
			// Emission mode requires to change the parameters of graph
			switch (objMethod.OperationMode) {
				case EnumOperationMode.MODE_UVABS:
					PreviewGraph.Visible = false;
					cmdChangeScale.Visible = false;
					btnPrintGraph.Visible = false;
				//Saurabh 28 MAy 2007---------------------------------------
				case EnumOperationMode.MODE_EMMISSION:
					PreviewGraph.Visible = true;
					PreviewGraph.YAxisLabel = "EMISSION";
					PreviewGraph.YAxisMin = -10;
					PreviewGraph.YAxisMax = 100;
					PreviewGraph.YAxisMinorStep = 2;
					PreviewGraph.YAxisStep = 10;
					gobjClsAAS203.Calculate_Analysis_Graph_Param(PreviewGraph, ClsAAS203.enumChangeAxis.xyAxis);
					gobjClsAAS203.subShowGraphPreview(this.PreviewGraph, mobjPreviewCurve, strRunNo, objMethod);
					PreviewGraph.Invalidate();
					PreviewGraph.Refresh();
					this.Refresh();
					PreviewGraph.Refresh();
					Application.DoEvents();
				//Saurabh 28 MAy 2007---------------------------------------

				default:
					PreviewGraph.Visible = true;
					PreviewGraph.YAxisMin = -0.2;
					PreviewGraph.YAxisMax = 1.1;
					PreviewGraph.YAxisLabel = "ABSORBANCE";
					gobjClsAAS203.Calculate_Analysis_Graph_Param(PreviewGraph, ClsAAS203.enumChangeAxis.xyAxis);
					gobjClsAAS203.subShowGraphPreview(this.PreviewGraph, mobjPreviewCurve, strRunNo, objMethod);
					PreviewGraph.Invalidate();
					PreviewGraph.Refresh();
					this.Refresh();

					Application.DoEvents();
			}

			return true;

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			return false;
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			//---------------------------------------------------------
		}
	}

	private void  // ERROR: Handles clauses are not supported in C#
btnIgnite_Click(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : btnIgnite_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : Ignite the flame
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 25.09.06
		// Revisions             : 
		//=====================================================================
		if (mblnAvoidProcessing == true) {
			return;
		}
		try {
			//Ignite the flame automatically
			mblnAvoidProcessing = true;
			gobjMain.AutoIgnition();
			mblnAvoidProcessing = false;
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			//---------------------------------------------------------
			mblnAvoidProcessing = false;
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			//objWait.Dispose()
			//---------------------------------------------------------
		}

	}

	private void  // ERROR: Handles clauses are not supported in C#
btnExtinguish_Click(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : btnExtinguish_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : Extinguish flame
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 25.09.06
		// Revisions             : 
		//=====================================================================
		if (mblnAvoidProcessing == true) {
			return;
		}
		try {
			//Extinguish the flame automatically
			mblnAvoidProcessing = true;
			gobjMain.Extinguish();
			mblnAvoidProcessing = false;
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			//---------------------------------------------------------
			mblnAvoidProcessing = false;
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			//objWait.Dispose()
			//---------------------------------------------------------
		}

	}

	private void  // ERROR: Handles clauses are not supported in C#
btnN2OIgnite_Click(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : btnN2OIgnite_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : N2O Auto Ignite
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 25.09.06
		// Revisions             : 
		//=====================================================================
		if (mblnAvoidProcessing == true) {
			return;
		}
		try {
			mblnAvoidProcessing = true;
			gobjMain.N2OAutoIgnition();
			mblnAvoidProcessing = false;
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			//---------------------------------------------------------
			mblnAvoidProcessing = false;
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			//objWait.Dispose()
			//---------------------------------------------------------
		}
	}

	private void btnDelete_Click(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : btnDelete_Click
		// Parameters Passed     : Object, EventArgs
		// Returns               : None
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 18-Dec-2007 03:15 pm
		// Revisions             : 0
		//=====================================================================
		try {
			if (mblnAvoidProcessing == true) {
				return;
			}
			mblnAvoidProcessing = true;
			gobjMain.funcAltDelete();
			mblnAvoidProcessing = false;
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			//---------------------------------------------------------
			mblnAvoidProcessing = false;
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			//---------------------------------------------------------
		}
	}

	private void btnR_Click(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : btnR_Click
		// Parameters Passed     : Object, EventArgs
		// Returns               : None
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 18-Dec-2007 03:15 pm
		// Revisions             : 0
		//=====================================================================
		try {
			if (mblnAvoidProcessing == true) {
				return;
			}
			mblnAvoidProcessing = true;
			gobjMain.funcAltR();
			mblnAvoidProcessing = false;
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			//---------------------------------------------------------
		}
	}


	private void  // ERROR: Handles clauses are not supported in C#
frmDataFiles_Activated(object sender, System.EventArgs e)
	{
	}

	private void  // ERROR: Handles clauses are not supported in C#
mobjfrmLoadAnalysis_StoreMultiReportDataTable(System.Data.DataTable dtMultiReport)
	{
		//=====================================================================
		// Procedure Name        : mobjfrmLoadAnalysis_StoreMultiReportDataTable
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               :  
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 25.09.06
		// Revisions             : 
		//=====================================================================
		try {
			//copy data table image
			mdtMultiReport = dtMultiReport.Copy();
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			//---------------------------------------------------------
			mblnAvoidProcessing = false;
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			//objWait.Dispose()
			//---------------------------------------------------------
		}
	}

	private void  // ERROR: Handles clauses are not supported in C#
mobjfrmReportOptions_ReportOptionsChanged(AAS203Library.Method.clsReportParameters rpt)
	{
		//=====================================================================
		// Procedure Name        : mobjfrmReportOptions_ReportOptionsChanged
		// Parameters Passed     : AAS203Library.Method.clsReportParameters
		// Returns               : None
		// Purpose               :  
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak B.
		// Created               : 13.04.09
		// Revisions             : 
		//=====================================================================
		int intSelectedRunNumberIndex;
		try {
			intSelectedRunNumberIndex = gfuncGetSelectedMethodRunNumberIndex(mintSelectedMethodID, mintSelectedRunNumber);
			if (intSelectedRunNumberIndex >= 0) {
				mobjClsMethod.QuantitativeDataCollection.Item(intSelectedRunNumberIndex).ReportParameters = rpt.Clone;
			}
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			//---------------------------------------------------------
		}
	}

	#End Region

}
