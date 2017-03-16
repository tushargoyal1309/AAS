using AAS203.Common;
using System.Threading;
using AAS203Library;
using AAS203Library.Analysis;
using AAS203Library.Method;
using AAS203Library.Method.clsQuantitativeData;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;
//Imports IQOQPQ

using BgThread;

public class frmAnalysis : System.Windows.Forms.Form, BgThread.Iclient
{


	#Region " Windows Form Designer generated code "

	public frmAnalysis()
	{
		base.New();

		//This call is required by the Windows Form Designer.
		Application.DoEvents();
		InitializeComponent();
		Application.DoEvents();
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
	internal CodeIntellects.Office2003Controls.Office2003Header HeaderRight;
	internal UIComponents.XPPanelGroup XpPanelGroup1;
	internal GradientPanel.CustomPanel CustomPanelMain;
	internal GradientPanel.CustomPanel CustomPanelRight;
	internal GradientPanel.CustomPanel CustomPanelLeft;
	internal CodeIntellects.Office2003Controls.Office2003Header HeaderLeft;
	internal GradientPanel.CustomPanel CustomPanel1;
	internal GradientPanel.CustomPanel CustomPanelRightTop;
	internal System.Windows.Forms.Label lblMethod;
	internal GradientPanel.CustomPanel CustomPanelRightBottom;
	internal System.Windows.Forms.Label lblConcentration;
	internal System.Windows.Forms.Label lblRepeatNo;
	internal System.Windows.Forms.Label lblSampleID;
	internal System.Windows.Forms.Label lblCorrectedAbsorbance;
	internal System.Windows.Forms.Label lblAverageAbsorbance;
	internal System.Windows.Forms.Label lblAbsorbance;
	internal System.Windows.Forms.Label lblRepeatNoMain;
	internal System.Windows.Forms.Label lblConcentrationMain;
	internal System.Windows.Forms.Label lblSampleIDMain;
	internal System.Windows.Forms.Label lblCorrectedAbsorbanceMain;
	internal System.Windows.Forms.Label lblAverageAbsorbanceMain;
	internal System.Windows.Forms.Label lblAbsorbanceMain;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuBack1;
	internal AAS203.AASGraph AASGraphAnalysis;
	internal NETXP.Controls.XPButton btnStartStopAnalysis;
	internal NETXP.Controls.XPButton btnReadData;
	internal System.Windows.Forms.Label lblRunNumberMain;
	internal System.Windows.Forms.Label lblRunNumber;
	internal GradientPanel.CustomPanel custPnlASPMessages;
	internal System.Windows.Forms.Label lblAspirationMessage;
	internal System.Timers.Timer tmrAspirationMsg;
	internal System.Windows.Forms.Label lblOptimizedWavelength;
	internal System.Windows.Forms.Label lblUVAbsorbance;
	internal System.Windows.Forms.Label lblUVWavelength;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuBack;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuStandardGraph;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuSampleGraph;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuViewResults;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuReports;
	internal System.Windows.Forms.Label txtMethod;
	internal System.Windows.Forms.GroupBox grpAbsorbanceValues;
	internal System.Windows.Forms.GroupBox grpAnalysis;
	internal NETXP.Controls.XPButton btnNewAnalysis;
	internal NETXP.Controls.XPButton btnBlankAnalysis;
	internal NETXP.Controls.XPButton btnRepeatLast;
	internal NETXP.Controls.XPButton btnNextAnalysis;
	internal System.Windows.Forms.GroupBox grpInstrument;
	internal NETXP.Controls.XPButton btnImport;
	internal NETXP.Controls.XPButton btnAutoZero;
	internal NETXP.Controls.XPButton btnSetup;
	internal NETXP.Controls.XPButton btnReoptimize;
	internal NETXP.Controls.XPButton btnEditData;
	internal NETXP.Controls.XPButton btnViewResults;
	internal NETXP.Controls.XPButton btnSplGraph;
	internal NETXP.Controls.XPButton btnStdGraph;
	internal NETXP.Controls.XPButton cmdChangeScale;
	internal NETXP.Controls.XPButton btnReports;
	internal NETXP.Controls.XPButton btnSave;
	internal NETXP.Controls.XPButton btnPrintGraph;
	internal NETXP.Controls.XPButton btnExtinguish;
	internal NETXP.Controls.XPButton btnIgnite;
	internal NETXP.Controls.XPButton btnExportReport;
	internal NETXP.Controls.RealPanel RealPanel1;
	internal NETXP.Controls.RealPanel RealPanel2;
	internal NETXP.Controls.RealPanel RealPanel3;
	internal NETXP.Controls.XPButton btnN2OIgnite;
	internal NETXP.Controls.XPButton btnDelete;

	internal NETXP.Controls.XPButton btnR;
	[System.Diagnostics.DebuggerStepThrough()]
	private void InitializeComponent()
	{
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmAnalysis));
		this.CustomPanelMain = new GradientPanel.CustomPanel();
		this.CustomPanelRight = new GradientPanel.CustomPanel();
		this.HeaderRight = new CodeIntellects.Office2003Controls.Office2003Header();
		this.CustomPanel1 = new GradientPanel.CustomPanel();
		this.btnPrintGraph = new NETXP.Controls.XPButton();
		this.cmdChangeScale = new NETXP.Controls.XPButton();
		this.AASGraphAnalysis = new AAS203.AASGraph();
		this.lblUVWavelength = new System.Windows.Forms.Label();
		this.lblUVAbsorbance = new System.Windows.Forms.Label();
		this.CustomPanelRightBottom = new GradientPanel.CustomPanel();
		this.grpInstrument = new System.Windows.Forms.GroupBox();
		this.btnImport = new NETXP.Controls.XPButton();
		this.btnAutoZero = new NETXP.Controls.XPButton();
		this.btnSetup = new NETXP.Controls.XPButton();
		this.btnReoptimize = new NETXP.Controls.XPButton();
		this.grpAnalysis = new System.Windows.Forms.GroupBox();
		this.btnRepeatLast = new NETXP.Controls.XPButton();
		this.btnNextAnalysis = new NETXP.Controls.XPButton();
		this.btnBlankAnalysis = new NETXP.Controls.XPButton();
		this.btnNewAnalysis = new NETXP.Controls.XPButton();
		this.custPnlASPMessages = new GradientPanel.CustomPanel();
		this.lblAspirationMessage = new System.Windows.Forms.Label();
		this.btnIgnite = new NETXP.Controls.XPButton();
		this.btnN2OIgnite = new NETXP.Controls.XPButton();
		this.btnDelete = new NETXP.Controls.XPButton();
		this.btnR = new NETXP.Controls.XPButton();
		this.btnExtinguish = new NETXP.Controls.XPButton();
		this.grpAbsorbanceValues = new System.Windows.Forms.GroupBox();
		this.lblConcentration = new System.Windows.Forms.Label();
		this.lblRepeatNo = new System.Windows.Forms.Label();
		this.lblSampleID = new System.Windows.Forms.Label();
		this.lblCorrectedAbsorbance = new System.Windows.Forms.Label();
		this.lblAverageAbsorbance = new System.Windows.Forms.Label();
		this.lblAbsorbance = new System.Windows.Forms.Label();
		this.lblRepeatNoMain = new System.Windows.Forms.Label();
		this.lblConcentrationMain = new System.Windows.Forms.Label();
		this.lblSampleIDMain = new System.Windows.Forms.Label();
		this.lblCorrectedAbsorbanceMain = new System.Windows.Forms.Label();
		this.lblAverageAbsorbanceMain = new System.Windows.Forms.Label();
		this.lblAbsorbanceMain = new System.Windows.Forms.Label();
		this.CustomPanelRightTop = new GradientPanel.CustomPanel();
		this.lblRunNumber = new System.Windows.Forms.Label();
		this.lblRunNumberMain = new System.Windows.Forms.Label();
		this.lblMethod = new System.Windows.Forms.Label();
		this.txtMethod = new System.Windows.Forms.Label();
		this.lblOptimizedWavelength = new System.Windows.Forms.Label();
		this.CustomPanelLeft = new GradientPanel.CustomPanel();
		this.XpPanelGroup1 = new UIComponents.XPPanelGroup();
		this.RealPanel3 = new NETXP.Controls.RealPanel();
		this.btnStartStopAnalysis = new NETXP.Controls.XPButton();
		this.btnReadData = new NETXP.Controls.XPButton();
		this.RealPanel2 = new NETXP.Controls.RealPanel();
		this.btnSave = new NETXP.Controls.XPButton();
		this.btnExportReport = new NETXP.Controls.XPButton();
		this.btnEditData = new NETXP.Controls.XPButton();
		this.RealPanel1 = new NETXP.Controls.RealPanel();
		this.btnStdGraph = new NETXP.Controls.XPButton();
		this.btnReports = new NETXP.Controls.XPButton();
		this.btnViewResults = new NETXP.Controls.XPButton();
		this.btnSplGraph = new NETXP.Controls.XPButton();
		this.HeaderLeft = new CodeIntellects.Office2003Controls.Office2003Header();
		this.mnuBack1 = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.tmrAspirationMsg = new System.Timers.Timer();
		this.mnuBack = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuStandardGraph = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuSampleGraph = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuViewResults = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuReports = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.CustomPanelMain.SuspendLayout();
		this.CustomPanelRight.SuspendLayout();
		this.HeaderRight.SuspendLayout();
		this.CustomPanel1.SuspendLayout();
		this.CustomPanelRightBottom.SuspendLayout();
		this.grpInstrument.SuspendLayout();
		this.grpAnalysis.SuspendLayout();
		this.custPnlASPMessages.SuspendLayout();
		this.grpAbsorbanceValues.SuspendLayout();
		this.CustomPanelRightTop.SuspendLayout();
		this.CustomPanelLeft.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.XpPanelGroup1).BeginInit();
		this.XpPanelGroup1.SuspendLayout();
		this.RealPanel3.SuspendLayout();
		this.RealPanel2.SuspendLayout();
		this.RealPanel1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.tmrAspirationMsg).BeginInit();
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
		this.CustomPanelRight.Controls.Add(this.HeaderRight);
		this.CustomPanelRight.Dock = System.Windows.Forms.DockStyle.Fill;
		this.CustomPanelRight.Location = new System.Drawing.Point(132, 0);
		this.CustomPanelRight.Name = "CustomPanelRight";
		this.CustomPanelRight.Size = new System.Drawing.Size(672, 579);
		this.CustomPanelRight.TabIndex = 11;
		//
		//HeaderRight
		//
		this.HeaderRight.BackColor = System.Drawing.Color.Transparent;
		this.HeaderRight.Controls.Add(this.CustomPanel1);
		this.HeaderRight.Dock = System.Windows.Forms.DockStyle.Fill;
		this.HeaderRight.Location = new System.Drawing.Point(0, 0);
		this.HeaderRight.Name = "HeaderRight";
		this.HeaderRight.Size = new System.Drawing.Size(672, 579);
		this.HeaderRight.TabIndex = 10;
		this.HeaderRight.TitleFont = new System.Drawing.Font("Tahoma", 10f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.HeaderRight.TitleText = "Analysis Details";
		//
		//CustomPanel1
		//
		this.CustomPanel1.BackColor = System.Drawing.Color.AliceBlue;
		this.CustomPanel1.BackColor2 = System.Drawing.Color.Transparent;
		this.CustomPanel1.Controls.Add(this.btnPrintGraph);
		this.CustomPanel1.Controls.Add(this.cmdChangeScale);
		this.CustomPanel1.Controls.Add(this.AASGraphAnalysis);
		this.CustomPanel1.Controls.Add(this.lblUVWavelength);
		this.CustomPanel1.Controls.Add(this.lblUVAbsorbance);
		this.CustomPanel1.Controls.Add(this.CustomPanelRightBottom);
		this.CustomPanel1.Controls.Add(this.CustomPanelRightTop);
		this.CustomPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.CustomPanel1.Location = new System.Drawing.Point(0, 0);
		this.CustomPanel1.Name = "CustomPanel1";
		this.CustomPanel1.Size = new System.Drawing.Size(672, 579);
		this.CustomPanel1.TabIndex = 8;
		//
		//btnPrintGraph
		//
		this.btnPrintGraph.Anchor = (System.Windows.Forms.AnchorStyles)System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.btnPrintGraph.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnPrintGraph.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnPrintGraph.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnPrintGraph.Location = new System.Drawing.Point(486, 57);
		this.btnPrintGraph.Name = "btnPrintGraph";
		this.btnPrintGraph.RightToLeft = System.Windows.Forms.RightToLeft.No;
		this.btnPrintGraph.Size = new System.Drawing.Size(110, 25);
		this.btnPrintGraph.TabIndex = 5;
		this.btnPrintGraph.Text = "Print &Graph";
		//
		//cmdChangeScale
		//
		this.cmdChangeScale.Anchor = (System.Windows.Forms.AnchorStyles)System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.cmdChangeScale.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.cmdChangeScale.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.cmdChangeScale.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.cmdChangeScale.Location = new System.Drawing.Point(360, 57);
		this.cmdChangeScale.Name = "cmdChangeScale";
		this.cmdChangeScale.Size = new System.Drawing.Size(110, 25);
		this.cmdChangeScale.TabIndex = 9;
		this.cmdChangeScale.Text = "C&hange Scale";
		this.cmdChangeScale.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//AASGraphAnalysis
		//
		this.AASGraphAnalysis.AldysGraphCursor = null;
		this.AASGraphAnalysis.AldysGraphPrintColor = System.Drawing.Color.Black;
		this.AASGraphAnalysis.Anchor = (System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right;
		this.AASGraphAnalysis.BackColor = System.Drawing.Color.LightGray;
		this.AASGraphAnalysis.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.AASGraphAnalysis.GraphDataSource = null;
		this.AASGraphAnalysis.GraphImage = null;
		this.AASGraphAnalysis.IsShowGrid = true;
		this.AASGraphAnalysis.Location = new System.Drawing.Point(14, 48);
		this.AASGraphAnalysis.Name = "AASGraphAnalysis";
		this.AASGraphAnalysis.Size = new System.Drawing.Size(645, 341);
		this.AASGraphAnalysis.TabIndex = 23;
		this.AASGraphAnalysis.UseDefaultSettings = true;
		this.AASGraphAnalysis.XAxisDateMax = new System.DateTime(2007, 3, 15, 23, 59, 59, 0);
		this.AASGraphAnalysis.XAxisDateMin = new System.DateTime(2007, 3, 15, 0, 0, 0, 0);
		this.AASGraphAnalysis.XAxisDateScaleFormat = AAS203.AASGraph.enumDateScaleFormat.HHMM;
		this.AASGraphAnalysis.XAxisLabel = "TIME(seconds)";
		this.AASGraphAnalysis.XAxisMax = 100;
		this.AASGraphAnalysis.XAxisMin = 0;
		this.AASGraphAnalysis.XAxisMinorStep = 5;
		this.AASGraphAnalysis.XAxisScaleFormat = "";
		this.AASGraphAnalysis.XAxisStep = 20;
		this.AASGraphAnalysis.XAxisType = AldysGraph.AxisType.Linear;
		this.AASGraphAnalysis.YAxisLabel = "ABSORBANCE";
		this.AASGraphAnalysis.YAxisMax = 0.8;
		this.AASGraphAnalysis.YAxisMin = -0.2;
		this.AASGraphAnalysis.YAxisMinorStep = 0.1;
		this.AASGraphAnalysis.YAxisScaleFormat = null;
		this.AASGraphAnalysis.YAxisStep = 0.2;
		this.AASGraphAnalysis.YAxisType = AldysGraph.AxisType.Linear;
		//
		//lblUVWavelength
		//
		this.lblUVWavelength.BackColor = System.Drawing.Color.White;
		this.lblUVWavelength.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblUVWavelength.Font = new System.Drawing.Font("Arial", 18f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblUVWavelength.Location = new System.Drawing.Point(116, 188);
		this.lblUVWavelength.Name = "lblUVWavelength";
		this.lblUVWavelength.Size = new System.Drawing.Size(442, 87);
		this.lblUVWavelength.TabIndex = 27;
		this.lblUVWavelength.Text = "Wavelength : ";
		this.lblUVWavelength.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//lblUVAbsorbance
		//
		this.lblUVAbsorbance.Anchor = (System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right;
		this.lblUVAbsorbance.BackColor = System.Drawing.Color.White;
		this.lblUVAbsorbance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblUVAbsorbance.Font = new System.Drawing.Font("Arial", 18f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblUVAbsorbance.Location = new System.Drawing.Point(116, 73);
		this.lblUVAbsorbance.Name = "lblUVAbsorbance";
		this.lblUVAbsorbance.Size = new System.Drawing.Size(442, 152);
		this.lblUVAbsorbance.TabIndex = 26;
		this.lblUVAbsorbance.Text = "Absorbance : 0.000";
		this.lblUVAbsorbance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.lblUVAbsorbance.Visible = false;
		//
		//CustomPanelRightBottom
		//
		this.CustomPanelRightBottom.BackColor = System.Drawing.Color.Transparent;
		this.CustomPanelRightBottom.BackColor2 = System.Drawing.Color.Transparent;
		this.CustomPanelRightBottom.BorderWidth = 15;
		this.CustomPanelRightBottom.Controls.Add(this.grpInstrument);
		this.CustomPanelRightBottom.Controls.Add(this.grpAnalysis);
		this.CustomPanelRightBottom.Controls.Add(this.custPnlASPMessages);
		this.CustomPanelRightBottom.Controls.Add(this.grpAbsorbanceValues);
		this.CustomPanelRightBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
		this.CustomPanelRightBottom.Location = new System.Drawing.Point(0, 397);
		this.CustomPanelRightBottom.Name = "CustomPanelRightBottom";
		this.CustomPanelRightBottom.Size = new System.Drawing.Size(672, 182);
		this.CustomPanelRightBottom.TabIndex = 20;
		//
		//grpInstrument
		//
		this.grpInstrument.Anchor = (System.Windows.Forms.AnchorStyles)System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.grpInstrument.Controls.Add(this.btnImport);
		this.grpInstrument.Controls.Add(this.btnAutoZero);
		this.grpInstrument.Controls.Add(this.btnSetup);
		this.grpInstrument.Controls.Add(this.btnReoptimize);
		this.grpInstrument.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.grpInstrument.Location = new System.Drawing.Point(544, 4);
		this.grpInstrument.Name = "grpInstrument";
		this.grpInstrument.Size = new System.Drawing.Size(114, 175);
		this.grpInstrument.TabIndex = 1;
		this.grpInstrument.TabStop = false;
		this.grpInstrument.Text = "Instrument ";
		//
		//btnImport
		//
		this.btnImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnImport.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnImport.Image = (System.Drawing.Image)resources.GetObject("btnImport.Image");
		this.btnImport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnImport.Location = new System.Drawing.Point(6, 134);
		this.btnImport.Name = "btnImport";
		this.btnImport.Size = new System.Drawing.Size(100, 36);
		this.btnImport.TabIndex = 3;
		this.btnImport.Text = "Import &File";
		this.btnImport.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//btnAutoZero
		//
		this.btnAutoZero.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnAutoZero.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnAutoZero.Image = (System.Drawing.Image)resources.GetObject("btnAutoZero.Image");
		this.btnAutoZero.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnAutoZero.Location = new System.Drawing.Point(6, 96);
		this.btnAutoZero.Name = "btnAutoZero";
		this.btnAutoZero.Size = new System.Drawing.Size(100, 36);
		this.btnAutoZero.TabIndex = 2;
		this.btnAutoZero.Text = "Auto &Zero";
		this.btnAutoZero.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//btnSetup
		//
		this.btnSetup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnSetup.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnSetup.Image = (System.Drawing.Image)resources.GetObject("btnSetup.Image");
		this.btnSetup.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnSetup.Location = new System.Drawing.Point(6, 58);
		this.btnSetup.Name = "btnSetup";
		this.btnSetup.Size = new System.Drawing.Size(100, 36);
		this.btnSetup.TabIndex = 1;
		this.btnSetup.Text = "Se&tUp";
		this.btnSetup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//btnReoptimize
		//
		this.btnReoptimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnReoptimize.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnReoptimize.Image = (System.Drawing.Image)resources.GetObject("btnReoptimize.Image");
		this.btnReoptimize.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnReoptimize.Location = new System.Drawing.Point(6, 20);
		this.btnReoptimize.Name = "btnReoptimize";
		this.btnReoptimize.Size = new System.Drawing.Size(100, 36);
		this.btnReoptimize.TabIndex = 0;
		this.btnReoptimize.Text = "Re &Optimize";
		this.btnReoptimize.TextAlign = System.Drawing.ContentAlignment.TopLeft;
		//
		//grpAnalysis
		//
		this.grpAnalysis.Anchor = (System.Windows.Forms.AnchorStyles)System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.grpAnalysis.Controls.Add(this.btnRepeatLast);
		this.grpAnalysis.Controls.Add(this.btnNextAnalysis);
		this.grpAnalysis.Controls.Add(this.btnBlankAnalysis);
		this.grpAnalysis.Controls.Add(this.btnNewAnalysis);
		this.grpAnalysis.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.grpAnalysis.Location = new System.Drawing.Point(425, 4);
		this.grpAnalysis.Name = "grpAnalysis";
		this.grpAnalysis.Size = new System.Drawing.Size(114, 175);
		this.grpAnalysis.TabIndex = 0;
		this.grpAnalysis.TabStop = false;
		this.grpAnalysis.Text = "Analysis";
		//
		//btnRepeatLast
		//
		this.btnRepeatLast.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnRepeatLast.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnRepeatLast.Image = (System.Drawing.Image)resources.GetObject("btnRepeatLast.Image");
		this.btnRepeatLast.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnRepeatLast.Location = new System.Drawing.Point(6, 134);
		this.btnRepeatLast.Name = "btnRepeatLast";
		this.btnRepeatLast.Size = new System.Drawing.Size(100, 36);
		this.btnRepeatLast.TabIndex = 3;
		this.btnRepeatLast.Text = "Repeat &Last";
		this.btnRepeatLast.TextAlign = System.Drawing.ContentAlignment.TopLeft;
		//
		//btnNextAnalysis
		//
		this.btnNextAnalysis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnNextAnalysis.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnNextAnalysis.Image = (System.Drawing.Image)resources.GetObject("btnNextAnalysis.Image");
		this.btnNextAnalysis.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnNextAnalysis.Location = new System.Drawing.Point(6, 96);
		this.btnNextAnalysis.Name = "btnNextAnalysis";
		this.btnNextAnalysis.Size = new System.Drawing.Size(100, 36);
		this.btnNextAnalysis.TabIndex = 2;
		this.btnNextAnalysis.Text = "Next";
		this.btnNextAnalysis.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//btnBlankAnalysis
		//
		this.btnBlankAnalysis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnBlankAnalysis.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnBlankAnalysis.Image = (System.Drawing.Image)resources.GetObject("btnBlankAnalysis.Image");
		this.btnBlankAnalysis.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnBlankAnalysis.Location = new System.Drawing.Point(6, 58);
		this.btnBlankAnalysis.Name = "btnBlankAnalysis";
		this.btnBlankAnalysis.Size = new System.Drawing.Size(100, 36);
		this.btnBlankAnalysis.TabIndex = 1;
		this.btnBlankAnalysis.Text = "Blan&k";
		this.btnBlankAnalysis.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//btnNewAnalysis
		//
		this.btnNewAnalysis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnNewAnalysis.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnNewAnalysis.Image = (System.Drawing.Image)resources.GetObject("btnNewAnalysis.Image");
		this.btnNewAnalysis.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnNewAnalysis.Location = new System.Drawing.Point(6, 20);
		this.btnNewAnalysis.Name = "btnNewAnalysis";
		this.btnNewAnalysis.Size = new System.Drawing.Size(100, 36);
		this.btnNewAnalysis.TabIndex = 0;
		this.btnNewAnalysis.Text = "Ne&w Analysis";
		this.btnNewAnalysis.TextAlign = System.Drawing.ContentAlignment.TopLeft;
		//
		//custPnlASPMessages
		//
		this.custPnlASPMessages.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right;
		this.custPnlASPMessages.BackColor = System.Drawing.Color.White;
		this.custPnlASPMessages.BackColor2 = System.Drawing.Color.Gainsboro;
		this.custPnlASPMessages.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
		this.custPnlASPMessages.Controls.Add(this.lblAspirationMessage);
		this.custPnlASPMessages.Controls.Add(this.btnIgnite);
		this.custPnlASPMessages.Controls.Add(this.btnN2OIgnite);
		this.custPnlASPMessages.Controls.Add(this.btnDelete);
		this.custPnlASPMessages.Controls.Add(this.btnR);
		this.custPnlASPMessages.Controls.Add(this.btnExtinguish);
		this.custPnlASPMessages.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.custPnlASPMessages.GradientMode = GradientPanel.LinearGradientMode.Horizontal;
		this.custPnlASPMessages.Location = new System.Drawing.Point(10, 4);
		this.custPnlASPMessages.Name = "custPnlASPMessages";
		this.custPnlASPMessages.Size = new System.Drawing.Size(410, 38);
		this.custPnlASPMessages.TabIndex = 10;
		//
		//lblAspirationMessage
		//
		this.lblAspirationMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblAspirationMessage.Dock = System.Windows.Forms.DockStyle.Fill;
		this.lblAspirationMessage.ForeColor = System.Drawing.Color.Maroon;
		this.lblAspirationMessage.Location = new System.Drawing.Point(0, 0);
		this.lblAspirationMessage.Name = "lblAspirationMessage";
		this.lblAspirationMessage.Size = new System.Drawing.Size(410, 38);
		this.lblAspirationMessage.TabIndex = 0;
		this.lblAspirationMessage.Text = "Wait ... ";
		this.lblAspirationMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		//
		//btnIgnite
		//
		this.btnIgnite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnIgnite.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnIgnite.Location = new System.Drawing.Point(86, 12);
		this.btnIgnite.Name = "btnIgnite";
		this.btnIgnite.Size = new System.Drawing.Size(27, 3);
		this.btnIgnite.TabIndex = 11;
		this.btnIgnite.TabStop = false;
		this.btnIgnite.Text = "&Ignite";
		//
		//btnN2OIgnite
		//
		this.btnN2OIgnite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnN2OIgnite.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnN2OIgnite.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnN2OIgnite.Location = new System.Drawing.Point(108, 8);
		this.btnN2OIgnite.Name = "btnN2OIgnite";
		this.btnN2OIgnite.Size = new System.Drawing.Size(5, 10);
		this.btnN2OIgnite.TabIndex = 19;
		this.btnN2OIgnite.TabStop = false;
		this.btnN2OIgnite.Text = "N2O&C";
		this.btnN2OIgnite.TextAlign = System.Drawing.ContentAlignment.TopLeft;
		//
		//btnDelete
		//
		this.btnDelete.BackColor = System.Drawing.Color.Transparent;
		this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnDelete.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnDelete.Location = new System.Drawing.Point(96, 15);
		this.btnDelete.Name = "btnDelete";
		this.btnDelete.Size = new System.Drawing.Size(8, 8);
		this.btnDelete.TabIndex = 24;
		this.btnDelete.TabStop = false;
		this.btnDelete.Text = "&Delete";
		this.btnDelete.TextAlign = System.Drawing.ContentAlignment.TopLeft;
		//
		//btnR
		//
		this.btnR.BackColor = System.Drawing.Color.Transparent;
		this.btnR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnR.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnR.Location = new System.Drawing.Point(108, 15);
		this.btnR.Name = "btnR";
		this.btnR.Size = new System.Drawing.Size(8, 8);
		this.btnR.TabIndex = 23;
		this.btnR.TabStop = false;
		this.btnR.Text = "&R";
		this.btnR.TextAlign = System.Drawing.ContentAlignment.TopLeft;
		//
		//btnExtinguish
		//
		this.btnExtinguish.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnExtinguish.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnExtinguish.Location = new System.Drawing.Point(58, 16);
		this.btnExtinguish.Name = "btnExtinguish";
		this.btnExtinguish.Size = new System.Drawing.Size(20, 3);
		this.btnExtinguish.TabIndex = 10;
		this.btnExtinguish.TabStop = false;
		this.btnExtinguish.Text = "&Extinguish";
		//
		//grpAbsorbanceValues
		//
		this.grpAbsorbanceValues.Controls.Add(this.lblConcentration);
		this.grpAbsorbanceValues.Controls.Add(this.lblRepeatNo);
		this.grpAbsorbanceValues.Controls.Add(this.lblSampleID);
		this.grpAbsorbanceValues.Controls.Add(this.lblCorrectedAbsorbance);
		this.grpAbsorbanceValues.Controls.Add(this.lblAverageAbsorbance);
		this.grpAbsorbanceValues.Controls.Add(this.lblAbsorbance);
		this.grpAbsorbanceValues.Controls.Add(this.lblRepeatNoMain);
		this.grpAbsorbanceValues.Controls.Add(this.lblConcentrationMain);
		this.grpAbsorbanceValues.Controls.Add(this.lblSampleIDMain);
		this.grpAbsorbanceValues.Controls.Add(this.lblCorrectedAbsorbanceMain);
		this.grpAbsorbanceValues.Controls.Add(this.lblAverageAbsorbanceMain);
		this.grpAbsorbanceValues.Controls.Add(this.lblAbsorbanceMain);
		this.grpAbsorbanceValues.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.grpAbsorbanceValues.Location = new System.Drawing.Point(10, 42);
		this.grpAbsorbanceValues.Name = "grpAbsorbanceValues";
		this.grpAbsorbanceValues.Size = new System.Drawing.Size(410, 137);
		this.grpAbsorbanceValues.TabIndex = 9;
		this.grpAbsorbanceValues.TabStop = false;
		this.grpAbsorbanceValues.Text = "Current Std/Sample Information";
		//
		//lblConcentration
		//
		this.lblConcentration.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblConcentration.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblConcentration.Location = new System.Drawing.Point(296, 96);
		this.lblConcentration.Name = "lblConcentration";
		this.lblConcentration.Size = new System.Drawing.Size(108, 18);
		this.lblConcentration.TabIndex = 11;
		//
		//lblRepeatNo
		//
		this.lblRepeatNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblRepeatNo.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblRepeatNo.Location = new System.Drawing.Point(296, 60);
		this.lblRepeatNo.Name = "lblRepeatNo";
		this.lblRepeatNo.Size = new System.Drawing.Size(108, 18);
		this.lblRepeatNo.TabIndex = 10;
		//
		//lblSampleID
		//
		this.lblSampleID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblSampleID.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblSampleID.Location = new System.Drawing.Point(296, 24);
		this.lblSampleID.Name = "lblSampleID";
		this.lblSampleID.Size = new System.Drawing.Size(108, 18);
		this.lblSampleID.TabIndex = 9;
		//
		//lblCorrectedAbsorbance
		//
		this.lblCorrectedAbsorbance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblCorrectedAbsorbance.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblCorrectedAbsorbance.Location = new System.Drawing.Point(94, 96);
		this.lblCorrectedAbsorbance.Name = "lblCorrectedAbsorbance";
		this.lblCorrectedAbsorbance.Size = new System.Drawing.Size(102, 18);
		this.lblCorrectedAbsorbance.TabIndex = 8;
		//
		//lblAverageAbsorbance
		//
		this.lblAverageAbsorbance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblAverageAbsorbance.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblAverageAbsorbance.Location = new System.Drawing.Point(94, 60);
		this.lblAverageAbsorbance.Name = "lblAverageAbsorbance";
		this.lblAverageAbsorbance.Size = new System.Drawing.Size(102, 18);
		this.lblAverageAbsorbance.TabIndex = 7;
		//
		//lblAbsorbance
		//
		this.lblAbsorbance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblAbsorbance.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblAbsorbance.Location = new System.Drawing.Point(94, 24);
		this.lblAbsorbance.Name = "lblAbsorbance";
		this.lblAbsorbance.Size = new System.Drawing.Size(102, 18);
		this.lblAbsorbance.TabIndex = 6;
		//
		//lblRepeatNoMain
		//
		this.lblRepeatNoMain.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblRepeatNoMain.Location = new System.Drawing.Point(208, 65);
		this.lblRepeatNoMain.Name = "lblRepeatNoMain";
		this.lblRepeatNoMain.Size = new System.Drawing.Size(84, 18);
		this.lblRepeatNoMain.TabIndex = 5;
		this.lblRepeatNoMain.Text = "Repeat No. :";
		//
		//lblConcentrationMain
		//
		this.lblConcentrationMain.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblConcentrationMain.Location = new System.Drawing.Point(208, 100);
		this.lblConcentrationMain.Name = "lblConcentrationMain";
		this.lblConcentrationMain.Size = new System.Drawing.Size(86, 18);
		this.lblConcentrationMain.TabIndex = 4;
		this.lblConcentrationMain.Text = "Concentration:";
		//
		//lblSampleIDMain
		//
		this.lblSampleIDMain.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblSampleIDMain.Location = new System.Drawing.Point(208, 28);
		this.lblSampleIDMain.Name = "lblSampleIDMain";
		this.lblSampleIDMain.Size = new System.Drawing.Size(86, 18);
		this.lblSampleIDMain.TabIndex = 3;
		this.lblSampleIDMain.Text = "Sample ID :";
		//
		//lblCorrectedAbsorbanceMain
		//
		this.lblCorrectedAbsorbanceMain.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblCorrectedAbsorbanceMain.Location = new System.Drawing.Point(8, 87);
		this.lblCorrectedAbsorbanceMain.Name = "lblCorrectedAbsorbanceMain";
		this.lblCorrectedAbsorbanceMain.Size = new System.Drawing.Size(90, 34);
		this.lblCorrectedAbsorbanceMain.TabIndex = 2;
		this.lblCorrectedAbsorbanceMain.Text = "Corrected Absorbance :";
		//
		//lblAverageAbsorbanceMain
		//
		this.lblAverageAbsorbanceMain.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblAverageAbsorbanceMain.Location = new System.Drawing.Point(8, 50);
		this.lblAverageAbsorbanceMain.Name = "lblAverageAbsorbanceMain";
		this.lblAverageAbsorbanceMain.Size = new System.Drawing.Size(90, 36);
		this.lblAverageAbsorbanceMain.TabIndex = 1;
		this.lblAverageAbsorbanceMain.Text = "Average Absorbance :";
		//
		//lblAbsorbanceMain
		//
		this.lblAbsorbanceMain.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblAbsorbanceMain.Location = new System.Drawing.Point(8, 28);
		this.lblAbsorbanceMain.Name = "lblAbsorbanceMain";
		this.lblAbsorbanceMain.Size = new System.Drawing.Size(90, 18);
		this.lblAbsorbanceMain.TabIndex = 0;
		this.lblAbsorbanceMain.Text = "Absorbance :";
		//
		//CustomPanelRightTop
		//
		this.CustomPanelRightTop.BackColor = System.Drawing.Color.Transparent;
		this.CustomPanelRightTop.BackColor2 = System.Drawing.Color.Transparent;
		this.CustomPanelRightTop.Controls.Add(this.lblRunNumber);
		this.CustomPanelRightTop.Controls.Add(this.lblRunNumberMain);
		this.CustomPanelRightTop.Controls.Add(this.lblMethod);
		this.CustomPanelRightTop.Controls.Add(this.txtMethod);
		this.CustomPanelRightTop.Controls.Add(this.lblOptimizedWavelength);
		this.CustomPanelRightTop.Dock = System.Windows.Forms.DockStyle.Top;
		this.CustomPanelRightTop.Location = new System.Drawing.Point(0, 0);
		this.CustomPanelRightTop.Name = "CustomPanelRightTop";
		this.CustomPanelRightTop.Size = new System.Drawing.Size(672, 54);
		this.CustomPanelRightTop.TabIndex = 22;
		//
		//lblRunNumber
		//
		this.lblRunNumber.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblRunNumber.Location = new System.Drawing.Point(285, 24);
		this.lblRunNumber.Name = "lblRunNumber";
		this.lblRunNumber.Size = new System.Drawing.Size(80, 16);
		this.lblRunNumber.TabIndex = 24;
		//
		//lblRunNumberMain
		//
		this.lblRunNumberMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblRunNumberMain.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblRunNumberMain.Location = new System.Drawing.Point(172, 23);
		this.lblRunNumberMain.Name = "lblRunNumberMain";
		this.lblRunNumberMain.Size = new System.Drawing.Size(196, 19);
		this.lblRunNumberMain.TabIndex = 23;
		this.lblRunNumberMain.Text = "Run Number : ";
		//
		//lblMethod
		//
		this.lblMethod.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblMethod.Location = new System.Drawing.Point(12, 23);
		this.lblMethod.Name = "lblMethod";
		this.lblMethod.Size = new System.Drawing.Size(61, 18);
		this.lblMethod.TabIndex = 19;
		this.lblMethod.Text = "Method :";
		this.lblMethod.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//txtMethod
		//
		this.txtMethod.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.txtMethod.Location = new System.Drawing.Point(75, 23);
		this.txtMethod.Name = "txtMethod";
		this.txtMethod.Size = new System.Drawing.Size(92, 18);
		this.txtMethod.TabIndex = 25;
		this.txtMethod.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//lblOptimizedWavelength
		//
		this.lblOptimizedWavelength.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblOptimizedWavelength.Location = new System.Drawing.Point(409, 22);
		this.lblOptimizedWavelength.Name = "lblOptimizedWavelength";
		this.lblOptimizedWavelength.Size = new System.Drawing.Size(217, 19);
		this.lblOptimizedWavelength.TabIndex = 25;
		this.lblOptimizedWavelength.Text = "Optimized Wavelength : ";
		//
		//CustomPanelLeft
		//
		this.CustomPanelLeft.BackColor = System.Drawing.Color.Transparent;
		this.CustomPanelLeft.BackColor2 = System.Drawing.Color.Transparent;
		this.CustomPanelLeft.Controls.Add(this.XpPanelGroup1);
		this.CustomPanelLeft.Controls.Add(this.HeaderLeft);
		this.CustomPanelLeft.Dock = System.Windows.Forms.DockStyle.Left;
		this.CustomPanelLeft.Location = new System.Drawing.Point(0, 0);
		this.CustomPanelLeft.Name = "CustomPanelLeft";
		this.CustomPanelLeft.Size = new System.Drawing.Size(132, 579);
		this.CustomPanelLeft.TabIndex = 10;
		//
		//XpPanelGroup1
		//
		this.XpPanelGroup1.AutoScroll = true;
		this.XpPanelGroup1.BackColor = System.Drawing.Color.Transparent;
		this.XpPanelGroup1.Controls.Add(this.RealPanel3);
		this.XpPanelGroup1.Controls.Add(this.RealPanel2);
		this.XpPanelGroup1.Controls.Add(this.RealPanel1);
		this.XpPanelGroup1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.XpPanelGroup1.Location = new System.Drawing.Point(0, 22);
		this.XpPanelGroup1.Name = "XpPanelGroup1";
		this.XpPanelGroup1.PanelGradient = (UIComponents.GradientColor)resources.GetObject("XpPanelGroup1.PanelGradient");
		this.XpPanelGroup1.PanelSpacing = 4;
		this.XpPanelGroup1.Size = new System.Drawing.Size(132, 557);
		this.XpPanelGroup1.TabIndex = 0;
		//
		//RealPanel3
		//
		this.RealPanel3.BackColor = System.Drawing.Color.WhiteSmoke;
		this.RealPanel3.Controls.Add(this.btnStartStopAnalysis);
		this.RealPanel3.Controls.Add(this.btnReadData);
		this.RealPanel3.Location = new System.Drawing.Point(6, 345);
		this.RealPanel3.Name = "RealPanel3";
		this.RealPanel3.Size = new System.Drawing.Size(117, 95);
		this.RealPanel3.TabIndex = 30;
		this.RealPanel3.Text = "RealPanel3";
		//
		//btnStartStopAnalysis
		//
		this.btnStartStopAnalysis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnStartStopAnalysis.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnStartStopAnalysis.Image = (System.Drawing.Image)resources.GetObject("btnStartStopAnalysis.Image");
		this.btnStartStopAnalysis.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnStartStopAnalysis.Location = new System.Drawing.Point(4, 5);
		this.btnStartStopAnalysis.Name = "btnStartStopAnalysis";
		this.btnStartStopAnalysis.RightToLeft = System.Windows.Forms.RightToLeft.No;
		this.btnStartStopAnalysis.Size = new System.Drawing.Size(110, 36);
		this.btnStartStopAnalysis.TabIndex = 6;
		this.btnStartStopAnalysis.Text = "Start Anal&ysis";
		this.btnStartStopAnalysis.TextAlign = System.Drawing.ContentAlignment.TopLeft;
		//
		//btnReadData
		//
		this.btnReadData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnReadData.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnReadData.Image = (System.Drawing.Image)resources.GetObject("btnReadData.Image");
		this.btnReadData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnReadData.Location = new System.Drawing.Point(4, 49);
		this.btnReadData.Name = "btnReadData";
		this.btnReadData.Size = new System.Drawing.Size(110, 36);
		this.btnReadData.TabIndex = 7;
		this.btnReadData.Text = "Read Data";
		this.btnReadData.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//RealPanel2
		//
		this.RealPanel2.BackColor = System.Drawing.Color.WhiteSmoke;
		this.RealPanel2.Controls.Add(this.btnSave);
		this.RealPanel2.Controls.Add(this.btnExportReport);
		this.RealPanel2.Controls.Add(this.btnEditData);
		this.RealPanel2.Location = new System.Drawing.Point(6, 196);
		this.RealPanel2.Name = "RealPanel2";
		this.RealPanel2.Size = new System.Drawing.Size(117, 138);
		this.RealPanel2.TabIndex = 29;
		this.RealPanel2.Text = "RealPanel2";
		//
		//btnSave
		//
		this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnSave.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnSave.Image = (System.Drawing.Image)resources.GetObject("btnSave.Image");
		this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnSave.Location = new System.Drawing.Point(4, 6);
		this.btnSave.Name = "btnSave";
		this.btnSave.RightToLeft = System.Windows.Forms.RightToLeft.No;
		this.btnSave.Size = new System.Drawing.Size(110, 36);
		this.btnSave.TabIndex = 3;
		this.btnSave.Text = "&Save Reports";
		this.btnSave.TextAlign = System.Drawing.ContentAlignment.TopLeft;
		//
		//btnExportReport
		//
		this.btnExportReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnExportReport.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnExportReport.Image = (System.Drawing.Image)resources.GetObject("btnExportReport.Image");
		this.btnExportReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnExportReport.Location = new System.Drawing.Point(4, 50);
		this.btnExportReport.Name = "btnExportReport";
		this.btnExportReport.Size = new System.Drawing.Size(110, 36);
		this.btnExportReport.TabIndex = 10;
		this.btnExportReport.Text = "E&xport Report";
		this.btnExportReport.TextAlign = System.Drawing.ContentAlignment.TopLeft;
		//
		//btnEditData
		//
		this.btnEditData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnEditData.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnEditData.Image = (System.Drawing.Image)resources.GetObject("btnEditData.Image");
		this.btnEditData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnEditData.Location = new System.Drawing.Point(4, 95);
		this.btnEditData.Name = "btnEditData";
		this.btnEditData.Size = new System.Drawing.Size(110, 36);
		this.btnEditData.TabIndex = 8;
		this.btnEditData.Text = "Edit Data";
		this.btnEditData.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//RealPanel1
		//
		this.RealPanel1.BackColor = System.Drawing.Color.WhiteSmoke;
		this.RealPanel1.Controls.Add(this.btnStdGraph);
		this.RealPanel1.Controls.Add(this.btnReports);
		this.RealPanel1.Controls.Add(this.btnViewResults);
		this.RealPanel1.Controls.Add(this.btnSplGraph);
		this.RealPanel1.Location = new System.Drawing.Point(6, 10);
		this.RealPanel1.Name = "RealPanel1";
		this.RealPanel1.Size = new System.Drawing.Size(117, 176);
		this.RealPanel1.TabIndex = 28;
		this.RealPanel1.Text = "RealPanel1";
		//
		//btnStdGraph
		//
		this.btnStdGraph.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnStdGraph.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnStdGraph.Image = (System.Drawing.Image)resources.GetObject("btnStdGraph.Image");
		this.btnStdGraph.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnStdGraph.Location = new System.Drawing.Point(4, 6);
		this.btnStdGraph.Name = "btnStdGraph";
		this.btnStdGraph.RightToLeft = System.Windows.Forms.RightToLeft.No;
		this.btnStdGraph.Size = new System.Drawing.Size(110, 36);
		this.btnStdGraph.TabIndex = 0;
		this.btnStdGraph.Text = "Sta&ndard Graph";
		this.btnStdGraph.TextAlign = System.Drawing.ContentAlignment.TopLeft;
		//
		//btnReports
		//
		this.btnReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnReports.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnReports.Image = (System.Drawing.Image)resources.GetObject("btnReports.Image");
		this.btnReports.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnReports.Location = new System.Drawing.Point(4, 134);
		this.btnReports.Name = "btnReports";
		this.btnReports.RightToLeft = System.Windows.Forms.RightToLeft.No;
		this.btnReports.Size = new System.Drawing.Size(110, 36);
		this.btnReports.TabIndex = 4;
		this.btnReports.Text = "Re&ports";
		this.btnReports.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//btnViewResults
		//
		this.btnViewResults.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnViewResults.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnViewResults.Image = (System.Drawing.Image)resources.GetObject("btnViewResults.Image");
		this.btnViewResults.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnViewResults.Location = new System.Drawing.Point(4, 90);
		this.btnViewResults.Name = "btnViewResults";
		this.btnViewResults.RightToLeft = System.Windows.Forms.RightToLeft.No;
		this.btnViewResults.Size = new System.Drawing.Size(110, 36);
		this.btnViewResults.TabIndex = 2;
		this.btnViewResults.Text = "&View Results";
		this.btnViewResults.TextAlign = System.Drawing.ContentAlignment.TopLeft;
		//
		//btnSplGraph
		//
		this.btnSplGraph.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnSplGraph.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnSplGraph.Image = (System.Drawing.Image)resources.GetObject("btnSplGraph.Image");
		this.btnSplGraph.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnSplGraph.Location = new System.Drawing.Point(4, 48);
		this.btnSplGraph.Name = "btnSplGraph";
		this.btnSplGraph.RightToLeft = System.Windows.Forms.RightToLeft.No;
		this.btnSplGraph.Size = new System.Drawing.Size(110, 36);
		this.btnSplGraph.TabIndex = 1;
		this.btnSplGraph.Text = "Sa&mple Graph";
		this.btnSplGraph.TextAlign = System.Drawing.ContentAlignment.TopLeft;
		//
		//HeaderLeft
		//
		this.HeaderLeft.BackColor = System.Drawing.SystemColors.Control;
		this.HeaderLeft.Dock = System.Windows.Forms.DockStyle.Top;
		this.HeaderLeft.Location = new System.Drawing.Point(0, 0);
		this.HeaderLeft.Name = "HeaderLeft";
		this.HeaderLeft.Size = new System.Drawing.Size(132, 22);
		this.HeaderLeft.TabIndex = 7;
		this.HeaderLeft.TitleFont = new System.Drawing.Font("Tahoma", 10f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.HeaderLeft.TitleText = "Options";
		//
		//mnuBack1
		//
		this.mnuBack1.Shortcut = System.Windows.Forms.Shortcut.CtrlZ;
		this.mnuBack1.Text = "Back";
		//
		//tmrAspirationMsg
		//
		this.tmrAspirationMsg.Interval = 500;
		this.tmrAspirationMsg.SynchronizingObject = this;
		//
		//mnuBack
		//
		this.mnuBack.Shortcut = System.Windows.Forms.Shortcut.CtrlB;
		this.mnuBack.Text = "Back";
		//
		//mnuStandardGraph
		//
		this.mnuStandardGraph.Shortcut = System.Windows.Forms.Shortcut.CtrlT;
		this.mnuStandardGraph.Text = "Standard Graph";
		//
		//mnuSampleGraph
		//
		this.mnuSampleGraph.Shortcut = System.Windows.Forms.Shortcut.CtrlA;
		this.mnuSampleGraph.Text = "Sample Graph";
		//
		//mnuViewResults
		//
		this.mnuViewResults.Shortcut = System.Windows.Forms.Shortcut.CtrlU;
		this.mnuViewResults.Text = "View Results";
		//
		//mnuReports
		//
		this.mnuReports.Shortcut = System.Windows.Forms.Shortcut.CtrlR;
		this.mnuReports.Text = "Reports";
		//
		//frmAnalysis
		//
		this.AutoScale = false;
		this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
		this.CausesValidation = false;
		this.ClientSize = new System.Drawing.Size(804, 579);
		this.Controls.Add(this.CustomPanelMain);
		this.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		this.IsMdiContainer = true;
		this.Name = "frmAnalysis";
		this.Text = "Analysis";
		this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
		this.CustomPanelMain.ResumeLayout(false);
		this.CustomPanelRight.ResumeLayout(false);
		this.HeaderRight.ResumeLayout(false);
		this.CustomPanel1.ResumeLayout(false);
		this.CustomPanelRightBottom.ResumeLayout(false);
		this.grpInstrument.ResumeLayout(false);
		this.grpAnalysis.ResumeLayout(false);
		this.custPnlASPMessages.ResumeLayout(false);
		this.grpAbsorbanceValues.ResumeLayout(false);
		this.CustomPanelRightTop.ResumeLayout(false);
		this.CustomPanelLeft.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.XpPanelGroup1).EndInit();
		this.XpPanelGroup1.ResumeLayout(false);
		this.RealPanel3.ResumeLayout(false);
		this.RealPanel2.ResumeLayout(false);
		this.RealPanel1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.tmrAspirationMsg).EndInit();
		this.ResumeLayout(false);

	}

	#End Region

	#Region " Private Constants "

	private string ConstFormLoad = gstrTitleInstrumentType + "-Analysis";

	private string ConstParentFormLoad = gstrTitleInstrumentType + "-Method";

	#End Region

	#Region " Private Member Variables "
	double mxValue;

	double mdblAvgAbs;
	int intDispCount;
	private double mdblWvOpt = -1.0;
	//Private mblnIsAnalysisStarted As Boolean   'Saurabh  10.07.07
		//Saurabh  10.07.07  Commented to Check S/W hang
	internal bool mblnIsAnalysisStarted;
	internal bool mblnIsCreateNewRunNo = false;
	internal bool mblnExecuteRunNo = false;
	private bool mblnIsAutosampler;
	private bool EndAnalysis = false;

	private double mdblAbsorbance;
	private string mstrAspirationMessage;
	private int mintAspirationTimerCounter;

	private bool mblnIsBlinkMessage;
	private ClsAAS203.enumSampleType SampleType = ClsAAS203.enumSampleType.BLANK;
	private ClsAAS203.enumSampleType LSampType = ClsAAS203.enumSampleType.BLANK;

	private Spectrum.EnergySpectrumParameter mobjParameters = new Spectrum.EnergySpectrumParameter();
	private AAS203Library.Method.clsAnalysisStdParameters mobjCurrentStandard;

	private AAS203Library.Method.clsAnalysisSampleParameters mobjCurrentSample;

	private IEnumerator mobjStandardEnumerator;

	private IEnumerator mobjSampleEnumerator;
	private ANALYSIS.clsRawDataCollection mobjAnalysisRawData = new ANALYSIS.clsRawDataCollection();
	private ANALYSIS.clsRawData mobjBlankRawData;
	private ANALYSIS.clsRawData mobjStandardRawData;

	private ANALYSIS.clsRawData mobjSampleRawData;

	private int CurRepeat = 1;
	private bool StdAnalysed = false;
	private bool mblnGetStandards = false;
	private bool AnaOver = false;
	private bool methchange = false;
	private bool InQAnaRead = false;

	private bool toreported = false;
	//---for checking the method is in analysis mode or not
	public bool InAnalysis = false;
	public bool exitbutton = false;

	public bool ANALYSIS;

	private int mintSelectedInstrumentConditionIndex;
	private AldysGraph.CurveItem mobjGraphCurve;

	private bool Afirst;
	private int mStartTime;

	private int mEndTime;
	private double XOld;

	private double YOld;

	private bool Filter_flag = true;

	private double mdblBlankAbsorbance = 0.0;
		//Commented to Check S/W hang
	public bool mblnIsStartRunNumber = true;
	//Public mblnIsStartRunNumber As Boolean = False          

	//---For Background Worker Thread functions

	private clsBgThread mController;
	//Public mobjBgReadData As New clsBgReadData

	public clsBgReadData mobjBgReadData;
	////----- Added by Sachin Dokhale
	//Private mMsgController As clsBgThread
	public AspirateMessage.clsMassageController mobjBgMsgAspirate;
	////-----


	private int mintRunNumberIndex;
		//Saurabh 
	private int mintSelectedMethodID;
		//Saurabh
	private long mlngSelectedRunNumber;
		//Sauarbh
	private clsMethod mobjClsMethod;

	private bool mblnRepeatLastBlank;
	private bool mblnRepeatLastStd;
	private bool mblnRepeatLastSample;
	private bool mblnRepeatResultStd;

	private bool mblnRepeatResultSample;
		//Saurabh 07-06-2007
	private clsDataFileReport mobjClsDataFileReport = new clsDataFileReport();
	private int intIEnumCollLocationStd;
	private int intIEnumCollLocationSamp;
	private bool mblnAvoidProcessing = false;
	private bool blnIsAspirateTimer = false;
	bool blnIsLoadPreviousStandards = false;
	public bool IsDisplayingMessage = false;
	private int mintTimeDelay = 1000;
	private clsAnalysisStdParameters mobjLastStandardData;

	private clsAnalysisSampleParameters mobjLastSampleData;
		//16.03.08
	private int mintSelectedDemoFile = 0;

	#End Region

	#Region " Private Properties "

	private string AspirationMessage {
		get { return mstrAspirationMessage; }
		set { mstrAspirationMessage = Value; }
	}

	public bool IsAvoidProcessing {
		get { return mblnAvoidProcessing; }
		set { mblnAvoidProcessing = Value; }
	}

	#End Region

	#Region " Form Load and Event Handling Functions "

	private void  // ERROR: Handles clauses are not supported in C#
frmAnalysis_Load(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : frmAnalysis_Load
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To initialize the form
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati and Mangesh Shardul
		// Created               : 07.10.06
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		Application.DoEvents();

		try {
			// Disable auto ignition/ extinguish button  for 201 
			if (gstructSettings.AppMode == EnumAppMode.FullVersion_201) {
				btnIgnite.Enabled = false;
				btnExtinguish.Enabled = false;
			}

			btnStdGraph.BringToFront();
			btnSplGraph.BringToFront();
			btnStdGraph.Focus();
			btnSave.Enabled = false;
			//cmdChangeScale.Location = New Point(14, 378)
			//btnExportReport.Location = New Point(14, 419)
			//Me.FormBorderStyle = FormBorderStyle.FixedSingle
			//gobjMain.ShowProgressBar(ConstFormLoad)

			// Init Reading thread
			mobjBgReadData = new clsBgReadData();

			// Add handlers of form object
			AddHandlers();
			////----- Sachin Dokhale
			if (!(gobjNewMethod.OperationMode == EnumOperationMode.MODE_UVABS | gobjNewMethod.OperationMode == EnumOperationMode.MODE_UVSPECT | gobjNewMethod.OperationMode == EnumOperationMode.MODE_EMMISSION)) {
				// Init graph coordinates for if opration mode is not UVABS/Spect and Emission mode
				//'-----Added By Pankaj on 10 May 2007
				AASGraphAnalysis.YAxisMin = -0.2;
				AASGraphAnalysis.YAxisMax = 1.2;
				gobjClsAAS203.Calculate_Analysis_Graph_Param(AASGraphAnalysis, ClsAAS203.enumChangeAxis.xyAxis);

			//Elseif Added by Saurabh
			} else if (gobjNewMethod.OperationMode == EnumOperationMode.MODE_EMMISSION) {
				// Init graph coordinates for if opration mode is Emission mode
				AASGraphAnalysis.YAxisMin = -10;
				//Changed from 0 to -10 by Saurabh 01.08.07
				AASGraphAnalysis.YAxisMax = 100;
				//AASGraphAnalysis.YAxisStep = 10
				//AASGraphAnalysis.YAxisMinorStep = 10
				AASGraphAnalysis.YAxisLabel = "EMISSION";
				gobjClsAAS203.Calculate_Analysis_Graph_Param(AASGraphAnalysis, ClsAAS203.enumChangeAxis.xyAxis);
			} else {
				// Init graph coordinates for if opration mode is UVABS/Spect 
				cmdChangeScale.Enabled = false;
				cmdChangeScale.Visible = false;
				btnPrintGraph.Enabled = false;
				btnPrintGraph.Visible = false;
			}

			// Init. Aspiration messages
			//mMsgController = New clsBgThread(Me)
			mobjBgMsgAspirate = new AspirateMessage.clsMassageController(lblAspirationMessage);
			//mobjBgMsgAspirate.Initialize(mMsgController)
			if (!gobjNewMethod == null) {
				DataRow objRow;
				objRow = gobjClsAAS203.funcGetMethodType(gobjNewMethod.OperationMode);
				HeaderRight.TitleText = (string)objRow.Item("MethodType");
			}
			//'by Pankaj for autosampler on 10Sep 07
			if ((gstructAutoSampler.blnAutoSamplerInitialised == true)) {
				mblnIsAutosampler = gstructAutoSampler.blnCommunication;
			}

			//16.03.08
			if (gblnIsDemoWithRealData == true) {
				DataTable objele = new DataTable();
				string strEleName;
				objele = gobjClsAAS203.funcGetElement(gobjNewMethod.InstrumentCondition.ElementID);
				if (!objele == null) {
					if (objele.Rows.Count > 0) {
						strEleName = LCase(objele.Rows(0).Item("Name"));
					}
				}
				switch (strEleName) {
					case "cu":
						mintSelectedDemoFile = 1;
					case "pb":
						mintSelectedDemoFile = 2;
					case "zn":
						mintSelectedDemoFile = 3;
				}
			}
			//16.03.08

		////-----
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
			Application.DoEvents();
			//gobjMain.HideProgressBar()
			//---------------------------------------------------------
		}
	}

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
			btnStdGraph.Click += tlbbtnStandardGraph_Click;
			btnSplGraph.Click += tlbbtnSampleGraph_Click;
			btnViewResults.Click += tlbbtnViewResults_Click;
			btnReports.Click += tlbbtnReports_Click;
			btnSave.Click += tlbbtnSave_Click;
			btnPrintGraph.Click += tlbbtnPrintGraph_Click;
			btnImport.Click += btnImport_Click;
			btnIgnite.Click += btnIgnite_Click;
			btnExtinguish.Click += btnExtinguish_Click;
			btnN2OIgnite.Click += btnN2OIgnite_Click;
			btnDelete.Click += btnDelete_Click;
			btnR.Click += btnR_Click;

			//Invisible Menu Items
			mnuBack.Click += tlbbtnBack_Click;
			mnuStandardGraph.Click += tlbbtnStandardGraph_Click;
			mnuSampleGraph.Click += tlbbtnSampleGraph_Click;
			mnuViewResults.Click += tlbbtnViewResults_Click;
			mnuReports.Click += tlbbtnReports_Click;

			btnNewAnalysis.Click += NewAnalysis_Clicked;
			btnBlankAnalysis.Click += BlankAnalysis_Clicked;
			btnNextAnalysis.Click += NextAnalysis_Clicked;
			btnRepeatLast.Click += RepeatLastAnalysis_Clicked;
			btnReoptimize.Click += ReOptimizeInstrument_Clicked;
			btnSetup.Click += ManualSetup_Clicked;
			btnAutoZero.Click += AutoZero_Clicked;

			btnEditData.Click += btnEditData_Clicked;

			//---Start/Stop Analysis and Read Data during Aspiration Event functions 
			btnStartStopAnalysis.Click += StartStopAnalysis_Click;
			btnReadData.Click += ReadData_Click;
			btnExportReport.Click += btnExportReport_Click;

			if (blnIsAspirateTimer == false) {
				blnIsAspirateTimer = true;
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

	//Private Sub tmrAspirationMsg_Elapsed(ByVal sender As System.Object, ByVal e As System.Timers.ElapsedEventArgs)
	//    '=====================================================================
	//    ' Procedure Name        : tmrAspirationMsg_Elapsed
	//    ' Parameters Passed     : sender As System.Object, System.Timers.ElapsedEventArgs
	//    ' Returns               : None
	//    ' Purpose               : Timer Aspiration Message events
	//    ' Description           : 
	//    ' Assumptions           : 
	//    ' Dependencies          : 
	//    ' Author                : Saurabh
	//    ' Created               : 05.10.06
	//    ' Revisions             : 
	//    '=====================================================================
	//    'case	WM_TIMER:
	//    '   tAsp++;
	//    '   If (tAsp > 1000) Then
	//    '       tAsp=1;
	//    '   if (tAsp%3==0)							
	//    '       ShowAspMessage(FALSE);
	//    '   Else
	//    '       ShowAspMessage(TRUE);
	//    'break;
	//    Try
	//        ' Application.DoEvents()
	//        mintAspirationTimerCounter += 1
	//        If (mintAspirationTimerCounter > 1000) Then
	//            mintAspirationTimerCounter = 1
	//        End If

	//        '---Saurabh---20.06.07
	//        'If btnReadData.Enabled = True Then
	//        '    btnReadData.Focus()
	//        '    btnReadData.Refresh()
	//        'End If
	//        'Application.DoEvents()
	//        'Saruabh

	//        If (mintAspirationTimerCounter Mod 3 = 0) Then
	//            If mblnIsBlinkMessage Then
	//                Call ShowAspirationMessages(False)
	//            Else
	//                Call ShowAspirationMessages(True)
	//            End If
	//            'Application.DoEvents()
	//        Else
	//            Call ShowAspirationMessages(True)
	//            'Application.DoEvents()
	//        End If
	//        'Application.DoEvents()
	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        'Error Handling and logging
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = ex.Message
	//        gobjErrorHandler.WriteErrorLog(ex)
	//        '---------------------------------------------------------
	//    Finally
	//        '---------------------------------------------------------
	//        'Writing Execution log
	//        If CONST_CREATE_EXECUTION_LOG = 1 Then
	//            gobjErrorHandler.WriteExecutionLog()
	//        End If
	//        '---------------------------------------------------------
	//    End Try
	//End Sub

	private void tlbbtnBack_Click(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : tlbbtnBack_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To exit frmAnalysis and load frmMDIMain form
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 25.09.06
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		try {
			//tlbbtnBack.SuspendEvents()
			this.Close();

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
			//tlbbtnBack.ResumeEvents()
			//---------------------------------------------------------
		}
	}

	private void tlbbtnStandardGraph_Click(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : tlbbtnStandardGraph_Click
		// Parameters Passed     : Object, EventArgs
		// Returns               : None
		// Purpose               : show the Standard graph
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 17-Jan-2007 03:25 pm
		// Revisions             : 1
		//=====================================================================
		//case IDC_QASTDGRAPH:
		//   if (StdAnalysed || ManualEntry){
		//       If (Create_Standard_Sample_Curve(hwnd, False)) Then
		//           toreported=TRUE;
		//   }
		//break;

		CWaitCursor objWait = new CWaitCursor();
		int intMethodID;
		try {
			//tlbbtnStandardGraph.SuspendEvents()

			//Or ManualEntry Then
			if (StdAnalysed) {
				//If gobjclsStandardGraph.Create_Standard_Sample_Curve(False, True, 0, 0, gobjNewMethod) Then  '---commented for ver 4.90
				//    toreported = True
				//End If

				intMethodID = gobjNewMethod.MethodID;
				//---added for version 4.90

				//---added for ver 4.90
				if (gobjclsStandardGraph.Create_Standard_Sample_Curve(false, true, intMethodID, mlngSelectedRunNumber, gobjNewMethod)) {
					toreported = true;
				}
				//------

			}
			if (btnReadData.Enabled) {
				btnReadData.Focus();
				btnReadData.Refresh();
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
			objWait.Dispose();
			//tlbbtnStandardGraph.ResumeEvents()
			//---------------------------------------------------------
		}
	}

	private void tlbbtnSampleGraph_Click(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : tlbbtnSampleGraph_Click
		// Parameters Passed     : Object, EventArgs
		// Returns               : None
		// Purpose               : Show the Sample graph
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 17-Jan-2007 03:25 pm
		// Revisions             : 1
		//=====================================================================
		//case IDC_QASAMPGRAPH:
		//   if (StdAnalysed || ManualEntry){
		//       If (Create_Standard_Sample_Curve(hwnd, TRUE)) Then
		//	        toreported=TRUE;
		//   }
		//   break;

		CWaitCursor objWait = new CWaitCursor();
		int intMethodID;
		try {
			//tlbbtnSampleGraph.SuspendEvents()

			intMethodID = gobjNewMethod.MethodID;
			//---added for version 4.90

			//Or ManualEntry Then
			if (StdAnalysed) {
				//If gobjclsStandardGraph.Create_Standard_Sample_Curve(True, True, 0, 0, gobjNewMethod) Then  '---commented for version 4.90
				//    toreported = True
				//End If

				//---added for version 4.90
				if (gobjclsStandardGraph.Create_Standard_Sample_Curve(true, true, intMethodID, mlngSelectedRunNumber, gobjNewMethod)) {
					toreported = true;
				}
				//--------

			}
			if (btnReadData.Enabled) {
				btnReadData.Focus();
				btnReadData.Refresh();
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
			if (!objWait == null) {
				objWait.Dispose();
			}
			//tlbbtnSampleGraph.ResumeEvents()
			//---------------------------------------------------------
		}
	}

	private void tlbbtnViewResults_Click(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : tlbbtnViewResults_Click
		// Parameters Passed     : Object, EventArgs
		// Returns               : None
		// Purpose               : View analysis report in Listview
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 17-Jan-2007 03:25 pm
		// Revisions             : 1
		//=====================================================================
		//case IDC_QARESULTS:
		//if (StdAnalysed||AnaOver ||Started ||ManualEntry)
		// OnViewResults(hwnd);
		//break;

		CWaitCursor objWait = new CWaitCursor();

		try {
			//tlbbtnViewResults.SuspendEvents()
			// View analysis report in Listview if analysis is complite
			//Or ManualEntry Then
			if (StdAnalysed | AnaOver | mblnIsAnalysisStarted) {
				OnViewResults();
			}
			if (btnReadData.Enabled) {
				btnReadData.Focus();
				btnReadData.Refresh();
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
			if (!objWait == null) {
				objWait.Dispose();
			}
			//tlbbtnViewResults.ResumeEvents()
			//---------------------------------------------------------
		}
	}

	private void tlbbtnSave_Click(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : tlbbtnReports_Click
		// Parameters Passed     : Object, EventArgs
		// Returns               : None
		// Purpose               : Save the Quant. analysis result 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 17-Jan-2007 03:25 pm
		// Revisions             : 1
		//=====================================================================

		//case IDC_QAREPORT:
		//   if (toreported||!Method->RepReady )
		//	{
		//	    SaveQuantResults(hwnd, Method, A1,0);
		//	    toreported=FALSE;
		//	}
		//	if (Method->RepReady )
		//	    OnReportPrint(hwnd, Method);
		//   break;

		CWaitCursor objWait = new CWaitCursor();
		double[] A1 = {
			0,
			0,
			0,
			0,
			0,
			0
		};

		try {
			// check "toreported" to store the report of quantity result
			//OR NOT Method->RepReady )
			if ((toreported)) {
				//Save the Quant. data result into Method Data object

				if (gobjClsAAS203.SaveQuantResults(gobjNewMethod, A1, 0, false) == true) {
					//Onecs data result is store  then
					// toreported var. is set to false to avoide resundancy of data storing
					//toreported = False
					mblnIsStartRunNumber = true;
				}
				toreported = false;
			}

			gobjClsAAS203.funcSave_Fuel_Conditions();
			//---30.04.10

			if (btnReadData.Enabled) {
				btnReadData.Focus();
				btnReadData.Refresh();
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
			if (!objWait == null) {
				objWait.Dispose();
			}
			//tlbbtnReports.ResumeEvents()
			//---------------------------------------------------------
		}
	}

	private void tlbbtnReports_Click(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : tlbbtnReports_Click
		// Parameters Passed     : Object, EventArgs
		// Returns               : None
		// Purpose               : Show the Analysis Report
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 17-Jan-2007 03:25 pm
		// Revisions             : 1
		//=====================================================================

		//case IDC_QAREPORT:
		//   if (toreported||!Method->RepReady )
		//	{
		//	    SaveQuantResults(hwnd, Method, A1,0);
		//	    toreported=FALSE;
		//	}
		//	if (Method->RepReady )
		//	    OnReportPrint(hwnd, Method);
		//   break;

		CWaitCursor objWait = new CWaitCursor();
		clsDataFileReport objClsDataFileReport = new clsDataFileReport();
		int intSelectIDIndex;
		int intCount;
		int intSelectedRunNumber;
		int intSelectedMethodID;
		double[] A1 = {
			0,
			0,
			0,
			0,
			0,
			0
		};


		try {
			//If toreported Then
			// Check 21 CFR 
			//-----Added By Pankaj Fri 18 May 07
			if ((gstructSettings.Enable21CFR == true)) {
				if (!funcCheckActivityAuthentication(enumActivityAuthentication.Print, gstructUserDetails.Access)) {
					return;
					return;
				}
				gfuncInsertActivityLog(EnumModules.Print, "Print Analysis Report Accessed");
			}
			//------
			//tlbbtnLoad.SuspendEvents()
			// Save Quant analysis data
			//OR NOT Method->RepReady )
			if ((toreported)) {
				if (gobjClsAAS203.SaveQuantResults(gobjNewMethod, A1, 1, false) == true) {
					mblnIsStartRunNumber = true;
				}
				toreported = false;
				//mblnIsStartRunNumber = True
			}


			//----Be Careful NOT TO USE index to assign MethodID or RunNumber

			if (StdAnalysed | AnaOver | mblnIsAnalysisStarted) {
				if (!(gobjNewMethod == null)) {
					for (intCount = 0; intCount <= gobjMethodCollection.Count - 1; intCount++) {
						if (gobjNewMethod.MethodID == gobjMethodCollection(intCount).MethodID) {
							intSelectIDIndex = intCount;
							//mobjClsDataFileReport.MethodID = intCount
							objClsDataFileReport.MethodID = gobjMethodCollection(intCount).MethodID;
							break; // TODO: might not be correct. Was : Exit For
						}
					}

					objClsDataFileReport.RunNumber = gobjMethodCollection(intCount).QuantitativeDataCollection(mintRunNumberIndex).RunNumber;
					//intSelectedRunNumber - 1

					objClsDataFileReport.DefaultFont = this.DefaultFont;
					// print data report from Data file report object
					objClsDataFileReport.funcDatafilePrint();
				}
			}
			if (btnReadData.Enabled) {
				btnReadData.Focus();
				btnReadData.Refresh();
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
			if (!objWait == null) {
				objWait.Dispose();
			}
			//tlbbtnReports.ResumeEvents()
			//---------------------------------------------------------
		}
	}

	private void tlbbtnPrintGraph_Click(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : tlbbtnPrintGraph_Click
		// Parameters Passed     : Object, EventArgs
		// Returns               : None
		// Purpose               : Print the Histograph
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 17-May-2007 03:25 pm
		// Revisions             : 1
		//=====================================================================



		CWaitCursor objWait = new CWaitCursor();
		double[] A1 = {
			0,
			0,
			0,
			0,
			0,
			0
		};

		try {
			// Check for 21 CFR 
			//-----Added By Pankaj Fri 18 May 07
			if ((gstructSettings.Enable21CFR == true)) {
				if (!funcCheckActivityAuthentication(enumActivityAuthentication.Print, gstructUserDetails.Access)) {
					return;
					return;
				}
				gfuncInsertActivityLog(EnumModules.Print, "Print Analysis Graph Accessed");
			}
			//------

			//If (toreported) Then 'OR NOT Method->RepReady )
			//    gobjClsAAS203.SaveQuantResults(gobjNewMethod, A1, False)
			//    toreported = False

			//End If
			//If StdAnalysed Or AnaOver Or mblnIsAnalysisStarted Then By Sachin
			//AASGraphAnalysis.PrintPreViewGraph()
			//-----Added By Pankaj Fri 14 Aug 07
			int mintRunNumberIndex;
			//Print the Histograph
			//---For Data Files Mode
			mintRunNumberIndex = gobjNewMethod.QuantitativeDataCollection.Count - 1;
			mobjClsDataFileReport.RunNumber = gobjNewMethod.QuantitativeDataCollection(mintRunNumberIndex).RunNumber;
			mobjClsDataFileReport.DefaultFont = this.DefaultFont;
			mobjClsDataFileReport.funcHistographPrint(AASGraphAnalysis, gobjNewMethod);
			//------------

			if (btnReadData.Enabled) {
				btnReadData.Focus();
				btnReadData.Refresh();
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
			if (!objWait == null) {
				objWait.Dispose();
			}
			//tlbbtnSampleGraph.ResumeEvents()
			//---------------------------------------------------------
		}
	}

	//Private Sub XpPanelStandardGraphClicked(ByVal sender As Object, ByVal e As System.EventArgs)
	//    '=====================================================================
	//    ' Procedure Name        : XpPanelStandardGraphClicked
	//    ' Parameters Passed     : Object,EventArgs
	//    ' Returns               : None
	//    ' Purpose               : To load the Standard Graph form
	//    ' Description           : 
	//    ' Assumptions           : 
	//    ' Dependencies          : 
	//    ' Author                : Deepak & Saurabh
	//    ' Created               : 05.10.06
	//    ' Revisions             : 
	//    '===================================================================== 
	//    Dim objWait As New CWaitCursor

	//    Try
	//        If Me.XpPanelStandardGraph.PanelState = UIComponents.XPPanelState.Collapsed Then
	//            Call funcCollapseAllXPPanels()
	//            Me.XpPanelStandardGraph.TogglePanelState()
	//            Me.XpPanelStandardGraph.PanelHeight = 80
	//        End If

	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        'Error Handling and logging
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = ex.Message
	//        gobjErrorHandler.WriteErrorLog(ex)
	//        '---------------------------------------------------------
	//    Finally
	//        '---------------------------------------------------------
	//        'Writing Execution log
	//        If CONST_CREATE_EXECUTION_LOG = 1 Then
	//            gobjErrorHandler.WriteExecutionLog()
	//        End If
	//        If Not objWait Is Nothing Then
	//            objWait.Dispose()
	//        End If
	//        '---------------------------------------------------------
	//    End Try
	//End Sub

	//Private Sub XpPanelSampleGraphClicked(ByVal sender As Object, ByVal e As System.EventArgs)
	//    '=====================================================================
	//    ' Procedure Name        : XpPanelSampleGraphClicked
	//    ' Parameters Passed     : Object,EventArgs
	//    ' Returns               : None
	//    ' Purpose               : To view the Sample Graphs
	//    ' Description           : 
	//    ' Assumptions           : 
	//    ' Dependencies          : 
	//    ' Author                : Deepak & Saurabh
	//    ' Created               : 05.10.06
	//    ' Revisions             : 
	//    '===================================================================== 
	//    Dim objWait As New CWaitCursor

	//    Try
	//        If Me.XpPanelSampleGraph.PanelState = UIComponents.XPPanelState.Collapsed Then
	//            Call funcCollapseAllXPPanels()
	//            Me.XpPanelSampleGraph.TogglePanelState()
	//            Me.XpPanelSampleGraph.PanelHeight = 90
	//        End If

	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        'Error Handling and logging
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = ex.Message
	//        gobjErrorHandler.WriteErrorLog(ex)
	//        '---------------------------------------------------------
	//    Finally
	//        '---------------------------------------------------------
	//        'Writing Execution log
	//        If CONST_CREATE_EXECUTION_LOG = 1 Then
	//            gobjErrorHandler.WriteExecutionLog()
	//        End If
	//        If Not objWait Is Nothing Then
	//            objWait.Dispose()
	//        End If
	//        '---------------------------------------------------------
	//    End Try
	//End Sub

	//Private Sub XpPanelViewResultsClicked(ByVal sender As Object, ByVal e As System.EventArgs)
	//    '=====================================================================
	//    ' Procedure Name        : XpPanelViewResultsClicked
	//    ' Parameters Passed     : Object,EventArgs
	//    ' Returns               : None
	//    ' Purpose               : To view the Results
	//    ' Description           : 
	//    ' Assumptions           : 
	//    ' Dependencies          : 
	//    ' Author                : Deepak & Saurabh
	//    ' Created               : 05.10.06
	//    ' Revisions             : 
	//    '===================================================================== 
	//    Dim objWait As New CWaitCursor

	//    Try
	//        If Me.XpPanelViewResults.PanelState = UIComponents.XPPanelState.Collapsed Then
	//            Call funcCollapseAllXPPanels()
	//            Me.XpPanelViewResults.TogglePanelState()
	//            Me.XpPanelViewResults.PanelHeight = 80
	//        End If

	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        'Error Handling and logging
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = ex.Message
	//        gobjErrorHandler.WriteErrorLog(ex)
	//        '---------------------------------------------------------
	//    Finally
	//        '---------------------------------------------------------
	//        'Writing Execution log
	//        If CONST_CREATE_EXECUTION_LOG = 1 Then
	//            gobjErrorHandler.WriteExecutionLog()
	//        End If
	//        If Not objWait Is Nothing Then
	//            objWait.Dispose()
	//        End If
	//        '---------------------------------------------------------
	//    End Try
	//End Sub

	//Private Sub XpPanelReportsClicked(ByVal sender As Object, ByVal e As System.EventArgs)
	//    '=====================================================================
	//    ' Procedure Name        : XpPanelReportsClicked
	//    ' Parameters Passed     : Object,EventArgs
	//    ' Returns               : None
	//    ' Purpose               : To view the Reports
	//    ' Description           : 
	//    ' Assumptions           : 
	//    ' Dependencies          : 
	//    ' Author                : Deepak & Saurabh
	//    ' Created               : 05.10.06
	//    ' Revisions             : 
	//    '===================================================================== 
	//    Dim objWait As New CWaitCursor
	//    Try
	//        If Me.XpPanelReports.PanelState = UIComponents.XPPanelState.Collapsed Then
	//            Call funcCollapseAllXPPanels()
	//            Me.XpPanelReports.TogglePanelState()
	//            Me.XpPanelReports.PanelHeight = 80
	//        End If

	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        'Error Handling and logging
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = ex.Message
	//        gobjErrorHandler.WriteErrorLog(ex)
	//        '---------------------------------------------------------
	//    Finally
	//        '---------------------------------------------------------
	//        'Writing Execution log
	//        If CONST_CREATE_EXECUTION_LOG = 1 Then
	//            gobjErrorHandler.WriteExecutionLog()
	//        End If
	//        If Not objWait Is Nothing Then
	//            objWait.Dispose()
	//        End If
	//        '---------------------------------------------------------
	//    End Try
	//End Sub

	private void AutoZero_Clicked(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : AutoZero_Clicked
		// Parameters Passed     : Object, EventArgs
		// Returns               : None
		// Purpose               : Start to Autozero
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 17-Jan-2007 03:25 pm
		// Revisions             : 1
		//=====================================================================

		//case IDC_AUTOZERO:
		//   Auto_Zero(hwnd, FALSE);
		//   break;
		if (mblnAvoidProcessing == true) {
			return;
		}
		try {
			mblnAvoidProcessing = true;
			////----- Commented by Sachin Dokhale
			////----- use Thread except timer for apirate message
			//tmrAspirationMsg.Enabled = False
			mobjBgMsgAspirate.Cancel();
			IsDisplayingMessage = mobjBgMsgAspirate.IsMessageRunning;
			//If gobjMain.mobjController.IsThreadRunning = True Then  '10.12.07
			gobjMain.mobjController.Cancel();
			Application.DoEvents();
			gobjCommProtocol.mobjCommdll.subTime_Delay(500);
			//10.12.07
			Application.DoEvents();
			//End If

			//Start to Autozero Set bool flag to False
			gobjClsAAS203.subAutoZero(false);

			mobjBgMsgAspirate.Start();
			IsDisplayingMessage = mobjBgMsgAspirate.IsMessageRunning;
			if (gobjMain.mobjController.IsThreadRunning == false) {
				gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay);
				Application.DoEvents();
				gobjMain.mobjController.Start(gobjclsBgFlameStatus);
			}
			if (btnReadData.Enabled) {
				btnReadData.Focus();
				btnReadData.Refresh();
			}
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
			////----- Commented by Sachin Dokhale
			////----- use Thread except timer for apirate message
			//tmrAspirationMsg.Enabled = True

			//mblnAvoidProcessing = False
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	private void ManualSetup_Clicked(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : ManualSetup_Clicked
		// Parameters Passed     : Object, EventArgs
		// Returns               : None
		// Purpose               : Manual Setup of instrument
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 17-Jan-2007 03:25 pm
		// Revisions             : 1
		//=====================================================================
		if (mblnAvoidProcessing == true) {
			return;
		}
		try {
			////----- Commented by Sachin Dokhale
			////----- use Thread except timer for apirate message
			//tmrAspirationMsg.Enabled = False
			mblnAvoidProcessing = true;
			mobjBgMsgAspirate.Cancel();
			gobjclsTimer.subTimerStop();
			IsDisplayingMessage = mobjBgMsgAspirate.IsMessageRunning;
			//If gobjMain.mobjController.IsThreadRunning = True Then
			gobjMain.mobjController.Cancel();
			gobjCommProtocol.mobjCommdll.subTime_Delay(500);
			//10.12.07
			Application.DoEvents();
			//End If


			//---Manual Optimization or Instrument Setup
			gobjClsAAS203.AbsorbanceScan();

			//gobjclsTimer.subTimerStart(StatusBar1)
			//mblnAvoidProcessing = False

			mobjBgMsgAspirate.Start();
			IsDisplayingMessage = mobjBgMsgAspirate.IsMessageRunning;
			//gobjclsTimer.subTimerStart()
			//mblnAvoidProcessing = False
			////-----
			if (gobjMain.mobjController.IsThreadRunning == false) {
				gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay);
				Application.DoEvents();
				gobjMain.mobjController.Start(gobjclsBgFlameStatus);
			}
			if (btnReadData.Enabled) {
				btnReadData.Focus();
				btnReadData.Refresh();
			}
			if (gobjclsTimer.TimerStatus == false) {
				gobjclsTimer.subTimerStart(gobjMain.StatusBar1);
			}
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
			////----- Commented by Sachin Dokhale
			////----- use Thread except timer for apirate message
			//tmrAspirationMsg.Enabled = True

			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	private void ReOptimizeInstrument_Clicked(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : ReOptimizeInstrument_Clicked
		// Parameters Passed     : Object, EventArgs
		// Returns               : None
		// Purpose               : ReOptimize Wavelength i.e. Find Analytical Peak Again
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 17-Jan-2007 03:25 pm
		// Revisions             : 1
		//=====================================================================
		//---ReOptimize Wavelength i.e. Find Analytical Peak Again
		//case IDC_OPTIMIZE:
		//   Method->Aas.OptimseFlag=FALSE;
		//   CheckInstrumentOptimisation(hwnd);
		//   break;
		if (mblnAvoidProcessing == true) {
			return;
		}
		try {
			mblnAvoidProcessing = true;
			////----- Commented by Sachin Dokhale
			////----- use Thread except timer for apirate message
			//tmrAspirationMsg.Enabled = False
			mobjBgMsgAspirate.Cancel();
			IsDisplayingMessage = mobjBgMsgAspirate.IsMessageRunning;
			////-----
			//If gobjMain.mobjController.IsThreadRunning = True Then
			gobjMain.mobjController.Cancel();
			gobjCommProtocol.mobjCommdll.subTime_Delay(500);
			//10.12.07
			Application.DoEvents();
			//End If

			//gobjNewMethod.InstrumentConditions.item(mintSelectedInstrumentConditionIndex).IsOptimize = False
			gobjNewMethod.InstrumentCondition.IsOptimize = false;
			// Start to find Analytical Peak 

			CheckInstrumentOptimisation();
			mobjBgMsgAspirate.Start();
			IsDisplayingMessage = mobjBgMsgAspirate.IsMessageRunning;

			////-----
			//start flame status thread
			if (gobjMain.mobjController.IsThreadRunning == false) {
				gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay);
				Application.DoEvents();
				gobjMain.mobjController.Start(gobjclsBgFlameStatus);
			}
			if (btnReadData.Enabled) {
				btnReadData.Focus();
				btnReadData.Refresh();
			}
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
			////----- Commented by Sachin Dokhale
			////----- use Thread except timer for apirate message
			//tmrAspirationMsg.Enabled = True

			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	private void RepeatLastAnalysis_Clicked(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : RepeatLastAnalysis_Clicked
		// Parameters Passed     : Object, EventArgs
		// Returns               : None
		// Purpose               : Repat the last analysis
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 17-Jan-2007 03:25 pm
		// Revisions             : 1
		//=====================================================================
		//**************************************************************
		//case IDC_QARPT:
		//   if(LSampType != BLANK )
		//	    CurRepeat--;
		//	if(CurRepeat <= 0 ){
		//	    if(LSampType == SAMP)
		//		    CurRepeat = Method->QuantData->Param.Repeat; //mdf by sss
		//		if(LSampType == STD)
		//		    CurRepeat = Method->QuantData->Param.ConcRepeat; //mdf by sss
		//	}
		//	if (SampType==BLANK && LSampType==BLANK){
		//	    if (CurStd==NULL){
		//		    SampType=SAMP;
		//       }
		//		else{
		//		    SampType=STD;
		//       }
		//   }
		//	else{
		//	    SampType=LSampType;
		//	}
		//	if (SampType==SAMP){
		//       CurSamp = GetPrevSamp(Method->QuantData->SampTopData, CurSamp);
		//	}
		//	if (SampType==STD)
		//	    CurStd = GetPrevStd(Method->QuantData->StdTopData, CurStd);
		//	if (SampType==BLANK){
		//	    if (CurStd==NULL)
		//		    LSampType=SAMP;
		//       Else
		//		    LSampType=BLANK;
		//	}
		//	else
		//	    LSampType=BLANK;
		//EnableWindow(GetDlgItem(hwnd,IDC_QARPT),FALSE);
		//**************************************************************
		if (mblnAvoidProcessing == true) {
			return;
		}
		try {
			mblnAvoidProcessing = true;
			//Added By Pankaj on 11 Jun 07 
			//If intIEnumCollLocationSamp > 0 Then
			//    If funcMoveSampleEnumerator(mobjSampleEnumerator, intIEnumCollLocationSamp) = True Then
			//        mobjCurrentSample = CType(mobjSampleEnumerator.Current, Method.clsAnalysisSampleParameters)
			//    End If
			//End If
			//If intIEnumCollLocationStd > 0 Then
			//    If funcMoveEnumerator(mobjStandardEnumerator, intIEnumCollLocationStd) = True Then
			//        mobjCurrentStandard = CType(mobjStandardEnumerator.Current, Method.clsAnalysisStdParameters)
			//    End If
			//End If
			//Call funcRefreshEnumerators(mobjStandardEnumerator, mobjSampleEnumerator)

			//-----
			// last sample type is not Blank then Set the previous no for current repeat
			if ((LSampType != ClsAAS203.enumSampleType.BLANK)) {
				CurRepeat -= 1;
			}

			if ((CurRepeat <= 0)) {
				if ((LSampType == ClsAAS203.enumSampleType.SAMPLE)) {
					//CurRepeat = Method->QuantData->Param.Repeat
					CurRepeat = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfSampleRepeats;
				}
				if ((LSampType == ClsAAS203.enumSampleType.STANDARD)) {
					//CurRepeat = Method->QuantData->Param.ConcRepeat
					CurRepeat = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfStdRepeats;
				}
			}


			if ((SampleType == ClsAAS203.enumSampleType.BLANK & LSampType == ClsAAS203.enumSampleType.BLANK)) {
				if (IsNothing(mobjCurrentStandard)) {
					SampleType = ClsAAS203.enumSampleType.SAMPLE;
				} else {
					SampleType = ClsAAS203.enumSampleType.STANDARD;
				}

			} else {
				SampleType = LSampType;
			}
			////--------
			// Get previous Sample from method object
			////------------
			if ((SampleType == ClsAAS203.enumSampleType.SAMPLE)) {
				//mobjCurrentSample = GetPrevSamp(Method->QuantData->SampTopData, mobjCurrentSample  )
				//If Not (mobjCurrentSample Is Nothing) Then
				//    mobjCurrentSample = GetPrevSamp(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection, mobjCurrentSample)
				//Else
				//    Dim intSampColl As Integer
				//    intSampColl = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.Count
				//    If intSampColl > 0 Then
				//        mobjCurrentSample = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection(intSampColl - 1)
				//    End If
				//End If
				mobjCurrentSample = GetPrevSamp(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection, mobjLastSampleData);
				//mobjCurrentSample = GetPrevSamp(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection, mobjCurrentSample)
				//mblnRepeatLastSample = True
				if (gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfSampleRepeats > 1) {
					mblnRepeatResultSample = true;
				} else {
					mblnRepeatLastSample = true;
				}
			}
			// Get previous stadard from method object
			if ((SampleType == ClsAAS203.enumSampleType.STANDARD)) {
				//mobjCurrentStandard = GetPrevStd(Method->QuantData->StdTopData,  mobjCurrentStandard )
				//If Not (mobjCurrentStandard Is Nothing) Then
				//    mobjCurrentStandard = GetPrevStd(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection, mobjLastStandardData)
				//Else
				//    Dim intStdColl As Integer
				//    intStdColl = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.Count
				//    If intStdColl > 0 Then
				//        mobjCurrentStandard = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection(intStdColl - 1)
				//    End If
				//End If
				mobjCurrentStandard = GetPrevStd(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection, mobjLastStandardData);
				//mblnRepeatLastStd = True
				if (gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfStdRepeats > 1) {
					mblnRepeatResultStd = true;
				} else {
					mblnRepeatLastStd = true;
				}

				//---added by Deepak on 26.07.09 with ref vck/ramesh
				if (gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfStdRepeats == 1) {
					mblnRepeatResultStd = true;
				}
				//--------

			}

			if ((SampleType == ClsAAS203.enumSampleType.BLANK)) {
				if (IsNothing(mobjCurrentStandard)) {
					LSampType = ClsAAS203.enumSampleType.SAMPLE;
				} else {
					LSampType = ClsAAS203.enumSampleType.BLANK;
				}
			} else {
				LSampType = ClsAAS203.enumSampleType.BLANK;
			}

			//EnableWindow(GetDlgItem(hwnd,IDC_QARPT),FALSE);

			//tlbbtnRepeatLastAnalysis.Enabled = False
			btnRepeatLast.Enabled = false;

			Aspirate();
			if (btnReadData.Enabled) {
				btnReadData.Focus();
				btnReadData.Refresh();
			}
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

	//Private Sub NewAnalysis_Clicked(ByVal sender As System.Object, ByVal e As System.EventArgs)
	//    'case	IDC_QANEW:
	//    '#If STD_ADDN Then
	//    '   endanalysis= FALSE;
	//    '#End If
	//    'DeleteAllRawData(FALSE);
	//    'mobjCurrentStandard  =Method->QuantData->StdTopData;
	//    'mobjCurrentSample =Method->QuantData->SampTopData;
	//    'CurRepeat=1;

	//    'if(mobjCurrentStandard!=NULL  && StdAnalysed)
	//    '{
	//    '   if(Method->QuantData->Param.Std_Addn)
	//    '	    i = IDNO;
	//    '	else{
	//    '       If (!methchange) Then        
	//    '		    i=MessageBox(hwnd,"Do you want to use the previous standards","INFORMATION", MB_ICONQUESTION | MB_YESNO);
	//    '		else
	//    '		    i=IDNO;
	//    '   }
	//    'if(i==IDNO)
	//    '   Clear_All_Abs_Std(Method->QuantData->StdTopData);
	//    'Else
	//    '   mobjCurrentStandard=NULL;
	//    '}
	//    'methchange = FALSE;	
	//    'if(!StdAnalysed) 
	//    '   Clear_All_Abs_Std(Method->QuantData->StdTopData);
	//    'Clear_All_Abs_Conc_Samp(Method->QuantData->SampTopData);
	//    'SampType=BLANK;
	//    'Xtime=0;Afirst=TRUE;
	//    '	
	//    'if(i==6)
	//    '   StdAnalysed =TRUE;
	//    'Else
	//    '	StdAnalysed =FALSE;
	//    'Method->RepReady=FALSE;
	//    'if (lParam!=100L){
	//    '   AppendMethod(Method, QALL);
	//    '	Method->QuantData->Fname =-1.0;
	//    '}
	//    'if (Method->QuantData->Fname<=0)
	//    '   GetRunNo(Method);
	//    'AnaGraph.Xmin=0; AnaGraph.Xmax=10*10.0;
	//    'Calculate_Analysis_Graph_Param(&AnaGraph);
	//    'AnaOver=FALSE;
	//    'if (hwnd){
	//    '   DisplayRunNo(hwnd);
	//    '	InvalidateRect(hwnd, NULL, TRUE);
	//    '}
	//    'Method->QuantData->cMode=-2;

	//    'EnableWindow(GetDlgItem(hwnd,IDC_QARPT),FALSE); // add by sss
	//    'if(Method->QuantData)
	//    '   aafname = Method->QuantData->Fname;
	//    'break;

	//    '*****************************************
	//    '---CODE BY MANGESH 
	//    '*****************************************
	//    'On NEW Analysis
	//    Dim dblFuelRatio As Double
	//    Dim objDlgResult As DialogResult

	//    Try
	//        '----added by deepak for new analysis on 28.04.07
	//        lblAbsorbance.Text = ""
	//        lblAverageAbsorbance.Text = ""
	//        lblCorrectedAbsorbance.Text = ""
	//        lblSampleID.Text = ""
	//        lblRepeatNo.Text = ""
	//        lblConcentration.Text = ""
	//        '------------------

	//        gobjclsStandardGraph = New clsStandardGraph

	//        '---Get the last RunNumber 

	//        If gobjNewMethod.QuantitativeDataCollection.Count > 0 Then
	//            mintRunNumberIndex = gobjNewMethod.QuantitativeDataCollection.Count - 1
	//        ElseIf gobjNewMethod.QuantitativeDataCollection.Count <= 0 Then
	//            mintRunNumberIndex = -1
	//        End If

	//        If gobjNewMethod.StandardAddition Then
	//            EndAnalysis = False
	//        End If

	//        'DeleteAllRawData(False)
	//        mobjAnalysisRawData.Clear()
	//        mobjBlankRawData = Nothing
	//        mobjStandardRawData = Nothing
	//        mobjSampleRawData = Nothing

	//        '*************************************************************************
	//        '---- Commented by Mangesh on 10-May-2007
	//        '*************************************************************************
	//        '---Gets the First Standard from Standard Collection
	//        If Not IsNothing(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection) Then
	//            mobjStandardEnumerator = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.GetEnumerator()
	//            mobjStandardEnumerator.Reset()
	//            intIEnumCollLocationStd = 0
	//            If mobjStandardEnumerator.MoveNext() Then
	//                intIEnumCollLocationStd = 1
	//                mobjCurrentStandard = CType(mobjStandardEnumerator.Current(), Method.clsAnalysisStdParameters)
	//            End If
	//        End If

	//        '---Gets the First Sample from Sample Collection
	//        If Not IsNothing(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection) Then
	//            mobjSampleEnumerator = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.GetEnumerator()
	//            mobjSampleEnumerator.Reset()
	//            intIEnumCollLocationSamp = 0
	//            If mobjSampleEnumerator.MoveNext() Then
	//                intIEnumCollLocationSamp = 1
	//                mobjCurrentSample = CType(mobjSampleEnumerator.Current(), Method.clsAnalysisSampleParameters)
	//            End If
	//        End If
	//        '*************************************************************************

	//        CurRepeat = 1

	//        If ((Not IsNothing(mobjCurrentStandard)) And StdAnalysed) Then
	//            If (gobjNewMethod.StandardAddition) Then
	//                objDlgResult = DialogResult.No
	//            Else
	//                If Not (methchange) Then
	//                    If gobjMessageAdapter.ShowMessage(constPreviousStandards) Then
	//                        objDlgResult = DialogResult.Yes
	//                    Else
	//                        objDlgResult = DialogResult.No
	//                    End If
	//                Else
	//                    objDlgResult = DialogResult.No
	//                End If
	//            End If
	//            'Comment & move by Pankaj on 08 Jun 07 
	//            'If (objDlgResult = DialogResult.No) Then
	//            '    Clear_All_Abs_Std(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection)
	//            'Else
	//            '    mobjCurrentStandard = Nothing
	//            'End If
	//            '------
	//        End If
	//        methchange = False

	//        If Not (StdAnalysed) Then  '---for removing uncompleted std analysis
	//            Call Clear_All_Abs_Std(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection)
	//        End If
	//        'Moved By Pankaj  on 09 Jun 07
	//        'Call Clear_All_Abs_Conc_Samp(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection)


	//        SampleType = ClsAAS203.enumSampleType.BLANK

	//        Afirst = True
	//        mStartTime = 0.0
	//        mEndTime = mStartTime + 100

	//        'if(i==6)
	//        '   StdAnalysed =TRUE;
	//        'Else
	//        '	StdAnalysed =FALSE;

	//        'Comment & move by Pankaj 08 Jun 06 
	//        'If (objDlgResult = DialogResult.Yes) Then
	//        '    StdAnalysed = True
	//        'Else
	//        '    StdAnalysed = False
	//        'End If
	//        '---------

	//        'gobjNewMethod.AnalysisParameters.RepReady = False

	//        If (mblnIsStartRunNumber) Then
	//            'AppendMethod(Method, QALL)

	//            If (CInt(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).RunNumber) >= 0) Then
	//                Dim objclsQuantitativeData As AAS203Library.Method.clsQuantitativeData
	//                objclsQuantitativeData = New AAS203Library.Method.clsQuantitativeData
	//                objclsQuantitativeData.AnalysisParameters = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.Clone()
	//                objclsQuantitativeData.ReportParameters = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).ReportParameters.Clone()
	//                objclsQuantitativeData.StandardDataCollection = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.Clone()
	//                objclsQuantitativeData.SampleDataCollection = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.Clone()
	//                objclsQuantitativeData.CalculationMode = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).CalculationMode
	//                gobjNewMethod.QuantitativeDataCollection.Add(objclsQuantitativeData)
	//                mintRunNumberIndex += 1
	//                gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).RunNumber = -1.0
	//            End If
	//            mblnIsStartRunNumber = False
	//        End If
	//        'Added By Pankaj on 08 Jun 07
	//        If ((Not IsNothing(mobjCurrentStandard)) And StdAnalysed) Then
	//            If (objDlgResult = DialogResult.No) Then
	//                Clear_All_Abs_Std(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection)
	//            Else
	//                mobjCurrentStandard = Nothing
	//            End If
	//        End If
	//        Call Clear_All_Abs_Conc_Samp(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection)
	//        '------------------
	//        'Comment & move by Pankaj 08 Jun 06 
	//        If (objDlgResult = DialogResult.Yes) Then
	//            StdAnalysed = True
	//        Else
	//            StdAnalysed = False
	//        End If
	//        '---------
	//        If (CInt(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).RunNumber) <= 0) Then
	//            Call GetRunNo(gobjNewMethod)
	//        End If

	//        '*************************************************************************
	//        '---- Added by Mangesh on 10-May-2007
	//        '*************************************************************************
	//        '---Gets the First Standard from Standard Collection
	//        If Not IsNothing(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection) Then
	//            mobjStandardEnumerator = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.GetEnumerator()
	//            mobjStandardEnumerator.Reset()
	//            intIEnumCollLocationStd = 0
	//            If mobjStandardEnumerator.MoveNext() Then
	//                intIEnumCollLocationStd = 1
	//                mobjCurrentStandard = CType(mobjStandardEnumerator.Current(), Method.clsAnalysisStdParameters)
	//            End If
	//        End If

	//        '---Gets the First Sample from Sample Collection
	//        If Not IsNothing(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection) Then
	//            mobjSampleEnumerator = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.GetEnumerator()
	//            mobjSampleEnumerator.Reset()
	//            intIEnumCollLocationSamp = 0
	//            If mobjSampleEnumerator.MoveNext() Then
	//                intIEnumCollLocationSamp = 1
	//                mobjCurrentSample = CType(mobjSampleEnumerator.Current(), Method.clsAnalysisSampleParameters)
	//            End If
	//        End If

	//        If (objDlgResult = DialogResult.Yes) Then
	//            mobjCurrentStandard = Nothing
	//        End If
	//        '*************************************************************************

	//        If AASGraphAnalysis.AldysPane.CurveList.Count > 0 Then
	//            AASGraphAnalysis.AldysPane.CurveList.Clear()

	//            AASGraphAnalysis.AldysPane.AxisChange()
	//            AASGraphAnalysis.Invalidate()
	//            Application.DoEvents()
	//        End If

	//        'AASGraphAnalysis.XAxisStep = 20     'Saurabh 06-06-2007
	//        'Call Calculate_Analysis_Graph_Param(AASGraphAnalysis)

	//        AASGraphAnalysis.XAxisType = AldysGraph.AxisType.Linear
	//        AASGraphAnalysis.XAxisMin = mStartTime
	//        AASGraphAnalysis.XAxisMax = mEndTime

	//        Call Calculate_Analysis_Graph_Param(AASGraphAnalysis)

	//        'AASGraphAnalysis.AldysPane.XAxis.StepAuto = True
	//        'AASGraphAnalysis.AldysPane.XAxis.MinorStepAuto = True
	//        'AASGraphAnalysis.AldysPane.XAxis.PickScale(AASGraphAnalysis.XAxisMin, AASGraphAnalysis.XAxisMax)

	//        AASGraphAnalysis.Refresh()
	//        Application.DoEvents()

	//        AnaOver = False

	//        Call DisplayRunNo()

	//        'gobjNewMethod.AnalysisParameters.cMode = -2

	//        'tlbbtnRepeatLastAnalysis.Enabled = False
	//        btnRepeatLast.Enabled = False
	//        '//----- Save Instrument parameter
	//        'gobjNewMethod.InstrumentCondition.D2Current = gobjInst.D2Current
	//        'gobjNewMethod.InstrumentCondition.LampCurrent = gobjInst.Current
	//        'gobjNewMethod.InstrumentCondition.PmtVoltage = gobjInst.PmtVoltage
	//        'gobjNewMethod.InstrumentCondition.SlitWidth = gobjClsAAS203.funcGet_SlitWidth
	//        If gstructSettings.AppMode = EnumAppMode.FullVersion_203D Then
	//            'TODO   Add property to gobjNewMethod.InstrumentCondition object for PMT Volt & Exit Slit Wd for Ref. 
	//            'gobjNewMethod.InstrumentCondition.PmtVoltage = gobjInst.PmtVoltageReference
	//            'gobjNewMethod.InstrumentCondition.SlitWidth = gobjInst.SlitPositionExit
	//        End If

	//        gobjNewMethod.InstrumentCondition.BurnerHeight = gobjClsAAS203.funcReadBurnerHeight()

	//        If Not (gstructSettings.AppMode = EnumAppMode.DemoMode) Then
	//            Call gobjCommProtocol.funcGet_NV_Pos()
	//        End If

	//        dblFuelRatio = gobjClsAAS203.funcGet_Fuel_Ratio(True)
	//        gobjNewMethod.InstrumentCondition.FuelRatio = dblFuelRatio
	//        '//-----

	//        'If (gobjNewMethod.AnalysisParameters) Then
	//        '   aafname = gobjNewMethod.AnalysisParameter.Fname
	//        'End If

	//        Call Display_Analysis_Info()
	//        Call CheckValidStdAbs()
	//        If (mblnIsAnalysisStarted) Then
	//            ANALYSIS = True
	//            '---Show Blinking Message
	//            Call Aspirate()
	//        Else
	//            ANALYSIS = False
	//        End If
	//        mblnRepeatLastStd = False
	//        mblnRepeatLastSample = False

	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        'Error Handling and logging
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = ex.Message
	//        gobjErrorHandler.WriteErrorLog(ex)
	//        '---------------------------------------------------------
	//    Finally
	//        '---------------------------------------------------------
	//        'Writing Execution log
	//        If CONST_CREATE_EXECUTION_LOG = 1 Then
	//            gobjErrorHandler.WriteExecutionLog()
	//        End If
	//        '---------------------------------------------------------
	//    End Try
	//End Sub

	private void NewAnalysis_Clicked(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : NewAnalysis_Clicked
		// Parameters Passed     : Object, EventArgs
		// Returns               : None
		// Purpose               : Start to new analysis
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 17-Jan-2007 03:25 pm
		// Revisions             : 1
		//=====================================================================
		//case	IDC_QANEW:
		//#If STD_ADDN Then
		//   endanalysis= FALSE;
		//#End If
		//DeleteAllRawData(FALSE);
		//mobjCurrentStandard  =Method->QuantData->StdTopData;
		//mobjCurrentSample =Method->QuantData->SampTopData;
		//CurRepeat=1;

		//if(mobjCurrentStandard!=NULL  && StdAnalysed)
		//{
		//   if(Method->QuantData->Param.Std_Addn)
		//	    i = IDNO;
		//	else{
		//       If (!methchange) Then        
		//		    i=MessageBox(hwnd,"Do you want to use the previous standards","INFORMATION", MB_ICONQUESTION | MB_YESNO);
		//		else
		//		    i=IDNO;
		//   }
		//if(i==IDNO)
		//   Clear_All_Abs_Std(Method->QuantData->StdTopData);
		//Else
		//   mobjCurrentStandard=NULL;
		//}
		//methchange = FALSE;	
		//if(!StdAnalysed) 
		//   Clear_All_Abs_Std(Method->QuantData->StdTopData);
		//Clear_All_Abs_Conc_Samp(Method->QuantData->SampTopData);
		//SampType=BLANK;
		//Xtime=0;Afirst=TRUE;
		//	
		//if(i==6)
		//   StdAnalysed =TRUE;
		//Else
		//	StdAnalysed =FALSE;
		//Method->RepReady=FALSE;
		//if (lParam!=100L){
		//   AppendMethod(Method, QALL);
		//	Method->QuantData->Fname =-1.0;
		//}
		//if (Method->QuantData->Fname<=0)
		//   GetRunNo(Method);
		//AnaGraph.Xmin=0; AnaGraph.Xmax=10*10.0;
		//Calculate_Analysis_Graph_Param(&AnaGraph);
		//AnaOver=FALSE;
		//if (hwnd){
		//   DisplayRunNo(hwnd);
		//	InvalidateRect(hwnd, NULL, TRUE);
		//}
		//Method->QuantData->cMode=-2;

		//EnableWindow(GetDlgItem(hwnd,IDC_QARPT),FALSE); // add by sss
		//if(Method->QuantData)
		//   aafname = Method->QuantData->Fname;
		//break;


		//---CODE BY MANGESH 

		//On NEW Analysis
		double dblFuelRatio;
		DialogResult objDlgResult;

		//---18.06.07

		try {
			//----added by deepak for new analysis on 28.04.07
			lblAbsorbance.Text = "";
			lblAverageAbsorbance.Text = "";
			lblCorrectedAbsorbance.Text = "";
			lblSampleID.Text = "";
			lblRepeatNo.Text = "";
			lblConcentration.Text = "";
			//------------------
			////----- Commented by Sachin Dokhale
			////----- Previous Standard
			////-----

			//---Get the last RunNumber 


			if (gobjNewMethod.StandardAddition) {
				EndAnalysis = false;
			}


			////----- Modifed by Sachin Dokhale
			// ReInit object
			mobjAnalysisRawData = null;
			mobjAnalysisRawData = new Analysis.clsRawDataCollection();
			////-----
			mobjBlankRawData = null;
			mobjStandardRawData = null;
			mobjSampleRawData = null;
			//'//-----



			//---- Commented by Mangesh on 10-May-2007

			//---Gets the First Standard from Standard Collection
			if (!IsNothing(gobjNewMethod.StandardDataCollection)) {
				mobjStandardEnumerator = gobjNewMethod.StandardDataCollection.GetEnumerator();
				mobjStandardEnumerator.Reset();
				intIEnumCollLocationStd = 0;
				if (mobjStandardEnumerator.MoveNext()) {
					intIEnumCollLocationStd = 1;
					mobjCurrentStandard = (Method.clsAnalysisStdParameters)mobjStandardEnumerator.Current();
				}
			}

			//---Gets the First Sample from Sample Collection
			if (!IsNothing(gobjNewMethod.SampleDataCollection)) {
				mobjSampleEnumerator = gobjNewMethod.SampleDataCollection.GetEnumerator();
				mobjSampleEnumerator.Reset();
				intIEnumCollLocationSamp = 0;
				if (mobjSampleEnumerator.MoveNext()) {
					intIEnumCollLocationSamp = 1;
					mobjCurrentSample = (Method.clsAnalysisSampleParameters)mobjSampleEnumerator.Current();
				}
			}

			CurRepeat = 1;
			////----- if use Previous Standard
			//Dim blnIsLoadPreviousStandards As Boolean
			if (((!IsNothing(mobjCurrentStandard)) & StdAnalysed)) {
				if ((gobjNewMethod.StandardAddition)) {
					objDlgResult = DialogResult.No;
					blnIsLoadPreviousStandards = false;
				} else {
					if (!(methchange) & (mblnGetStandards == true)) {
						if (gobjMessageAdapter.ShowMessage(constPreviousStandards)) {
							objDlgResult = DialogResult.Yes;
							blnIsLoadPreviousStandards = true;
						} else {
							objDlgResult = DialogResult.No;
							blnIsLoadPreviousStandards = false;
						}
					} else {
						objDlgResult = DialogResult.No;
						blnIsLoadPreviousStandards = false;
					}
				}
			//Comment & move by Pankaj on 08 Jun 07 
			//If (objDlgResult = DialogResult.No) Then
			//    Clear_All_Abs_Std(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection)
			//Else
			//    mobjCurrentStandard = Nothing
			//End If
			//------
			} else {
				blnIsLoadPreviousStandards = false;
			}
			methchange = false;
			////----- Added by Sachin Dokhale 
			////----- Previous Standard
			if (blnIsLoadPreviousStandards == false) {
				gobjclsStandardGraph = new clsStandardGraph();
			} else {
				if (gobjclsStandardGraph == null) {
					gobjclsStandardGraph = new clsStandardGraph();
				}
			}
			////-----
			//for removing uncompleted std analysis
			//---
			if (!(StdAnalysed)) {
				Clear_All_Abs_Std(gobjNewMethod.StandardDataCollection);
			}
			//Moved By Pankaj  on 09 Jun 07
			//Call Clear_All_Abs_Conc_Samp(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection)

			// Set 1st at the time of starting new analysis Sample Type is Balnk
			//Start Time and End time of analysis is reset
			// then change when analysis perform Sts/Sample or blank

			SampleType = ClsAAS203.enumSampleType.BLANK;
			Afirst = true;
			mStartTime = 0.0;
			mEndTime = mStartTime + 100;

			//if(i==6)
			//   StdAnalysed =TRUE;
			//Else
			//	StdAnalysed =FALSE;

			//Comment & move by Pankaj 08 Jun 06 
			//If (objDlgResult = DialogResult.Yes) Then
			//    StdAnalysed = True
			//Else
			//    StdAnalysed = False
			//End If
			//---------

			//gobjNewMethod.AnalysisParameters.RepReady = False
			// Follow the process for New Run nuumber
			if ((mblnIsStartRunNumber)) {
				//AppendMethod(Method, QALL)
				//If (CInt(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).RunNumber) >= 0) Then
				AAS203Library.Method.clsQuantitativeData objclsQuantitativeData;
				objclsQuantitativeData = new AAS203Library.Method.clsQuantitativeData();
				//Set Analysis Parameter object
				if (!gobjNewMethod.AnalysisParameters == null) {
					objclsQuantitativeData.AnalysisParameters = gobjNewMethod.AnalysisParameters.Clone();
				}
				//Set Report Parameter object
				if (!gobjNewMethod.ReportParameters == null) {
					objclsQuantitativeData.ReportParameters = gobjNewMethod.ReportParameters.Clone();
				}

				//objclsQuantitativeData.StandardDataCollection = gobjNewMethod.StandardDataCollection.Clone()
				////----- Added by Sachin Dokhale for Previous Standard
				// Restore the previous object when analysis use Load previous Standard 
				if (blnIsLoadPreviousStandards == true & StdAnalysed == true & mintRunNumberIndex >= 0) {
					mblnGetStandards = false;
					objclsQuantitativeData.StandardDataCollection = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.Clone;

					intIEnumCollLocationStd = objclsQuantitativeData.StandardDataCollection.Count + 1;
					if (funcMoveEnumerator(mobjStandardEnumerator, intIEnumCollLocationStd) == true) {
						mobjCurrentStandard = (Method.clsAnalysisStdParameters)mobjStandardEnumerator.Current;
					} else {
						mobjCurrentStandard = null;
					}
				} else {
					objclsQuantitativeData.StandardDataCollection = gobjNewMethod.StandardDataCollection.Clone();
				}

				////-----
				if (!gobjNewMethod.SampleDataCollection == null) {
					objclsQuantitativeData.SampleDataCollection = gobjNewMethod.SampleDataCollection.Clone();
				}

				//objclsQuantitativeData.CalculationMode = gobjNewMethod.CalculationMode
				gobjNewMethod.QuantitativeDataCollection.Add(objclsQuantitativeData);
				//mintRunNumberIndex += 1
				mintRunNumberIndex = gobjNewMethod.QuantitativeDataCollection.Count - 1;


				gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).RunNumber = -1.0;
				//End If
				mblnIsStartRunNumber = false;
				////--- Create Run No to start new analysis during the analysis 
				if (mblnExecuteRunNo == false) {
					// Get the Run No from Data collection object
					GetRunNo(gobjNewMethod);
					mblnIsCreateNewRunNo = false;
					// Display Run No in screen
					DisplayRunNo();
				}
			}
			//Added By Pankaj on 08 Jun 07
			// Cleat all stadard object when New Standard use analysis
			if (((!IsNothing(mobjCurrentStandard)) & StdAnalysed)) {
				if ((objDlgResult == DialogResult.No)) {
					Clear_All_Abs_Std(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection);
				} else {
					mobjCurrentStandard = null;
				}
			}
			// Cleat all Sample object 
			Clear_All_Abs_Conc_Samp(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection);
			//------------------
			//Comment & move by Pankaj 08 Jun 06 
			if ((objDlgResult == DialogResult.Yes)) {
				StdAnalysed = true;
			} else {
				StdAnalysed = false;
			}
			//---------
			if (((int)gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).RunNumber <= 0)) {
				// Call GetRunNo(gobjNewMethod)
			}


			//---- Added by Mangesh on 10-May-2007

			//---Gets the First Standard from Standard Collection
			if (blnIsLoadPreviousStandards == true & StdAnalysed == true & mintRunNumberIndex > 0) {
			} else {
				if (!IsNothing(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection)) {
					mobjStandardEnumerator = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.GetEnumerator();
					mobjStandardEnumerator.Reset();
					intIEnumCollLocationStd = 0;
					if (mobjStandardEnumerator.MoveNext()) {
						intIEnumCollLocationStd = 1;
						mobjCurrentStandard = (Method.clsAnalysisStdParameters)mobjStandardEnumerator.Current();
					}
				}

			}

			//---Gets the First Sample from Sample Collection
			if (!IsNothing(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection)) {
				mobjSampleEnumerator = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.GetEnumerator();
				mobjSampleEnumerator.Reset();
				intIEnumCollLocationSamp = 0;
				if (mobjSampleEnumerator.MoveNext()) {
					intIEnumCollLocationSamp = 1;
					mobjCurrentSample = (Method.clsAnalysisSampleParameters)mobjSampleEnumerator.Current();
				}
			}

			if ((objDlgResult == DialogResult.Yes)) {
				mobjCurrentStandard = null;
			}

			//10.2.2010
			//-------------------------------------------
			gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.Analysis_Date = System.DateTime.Now;
			//---------------------------------------------


			if (AASGraphAnalysis.AldysPane.CurveList.Count > 0) {
				AASGraphAnalysis.AldysPane.CurveList.Clear();

				AASGraphAnalysis.AldysPane.AxisChange();
				AASGraphAnalysis.Invalidate();
				Application.DoEvents();
			}

			//AASGraphAnalysis.XAxisStep = 20     'Saurabh 06-06-2007
			//Call Calculate_Analysis_Graph_Param(AASGraphAnalysis)
			//--- Set Graph parameters
			AASGraphAnalysis.XAxisType = AldysGraph.AxisType.Linear;
			AASGraphAnalysis.XAxisMin = mStartTime;
			AASGraphAnalysis.XAxisMax = mEndTime;
			//--- Cal. graph coordinates 
			Calculate_Analysis_Graph_Param(AASGraphAnalysis);
			AASGraphAnalysis.Refresh();
			Application.DoEvents();

			AnaOver = false;
			mblnIsCreateNewRunNo = true;
			DisplayRunNo();

			//gobjNewMethod.AnalysisParameters.cMode = -2

			//tlbbtnRepeatLastAnalysis.Enabled = False
			btnRepeatLast.Enabled = false;
			////----- Save Instrument parameter

			if (gstructSettings.AppMode == EnumAppMode.FullVersion_203D) {
				//TODO   Add property to gobjNewMethod.InstrumentCondition object for PMT Volt & Exit Slit Wd for Ref. 
				//gobjNewMethod.InstrumentCondition.PmtVoltage = gobjInst.PmtVoltageReference
				//gobjNewMethod.InstrumentCondition.SlitWidth = gobjInst.SlitPositionExit
			}
			//10.12.07
			if (gobjMain.mobjController.IsThreadRunning == true) {
				gobjMain.mobjController.Cancel();
				Application.DoEvents();
				gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay);
				//10.12.07
				Application.DoEvents();
			}

			// set the instrument parameter into Data collection object
			gobjNewMethod.InstrumentCondition.BurnerHeight = gobjClsAAS203.funcReadBurnerHeight();

			//If Not (gstructSettings.AppMode = EnumAppMode.DemoMode) Then
			if (!((gstructSettings.AppMode == EnumAppMode.DemoMode) | (gstructSettings.AppMode == EnumAppMode.DemoMode_201) | (gstructSettings.AppMode == EnumAppMode.DemoMode_203D))) {
				gobjCommProtocol.funcGet_NV_Pos();
			}

			//dblFuelRatio = gobjClsAAS203.funcGet_Fuel_Ratio(True)  '10.12.07
			dblFuelRatio = gobjClsAAS203.funcRead_Fuel_Ratio;
			//10.12.07
			gobjNewMethod.InstrumentCondition.FuelRatio = dblFuelRatio;
			////-----

			//If (gobjNewMethod.AnalysisParameters) Then
			//   aafname = gobjNewMethod.AnalysisParameter.Fname
			//End If
			//display analysis information 
			Display_Analysis_Info();
			// Check Valid Std for result from analysis
			CheckValidStdAbs();

			if ((mblnIsAnalysisStarted)) {
				ANALYSIS = true;
				//---Show Blinking Message
				Aspirate();
			} else {
				ANALYSIS = false;
			}
			mblnRepeatLastStd = false;
			mblnRepeatLastSample = false;
			////----- Initialise the Data Bg Thread for UV Analysis
			if ((gobjNewMethod.OperationMode == EnumOperationMode.MODE_UVABS)) {
				mobjBgReadData = new clsBgReadData(0, 0, SampleType, mobjCurrentStandard, mobjCurrentSample);
			}
			////-----
			if (btnReadData.Enabled) {
				btnReadData.Focus();
				btnReadData.Refresh();
			}
			//10.12.07
			if (gobjMain.mobjController.IsThreadRunning == false) {
				gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay);
				Application.DoEvents();
				gobjMain.mobjController.Start(gobjclsBgFlameStatus);
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

	private void NextAnalysis_Clicked(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : NextAnalysis_Clicked
		// Parameters Passed     : Object, EventArgs
		// Returns               : None
		// Purpose               : Set to Next sample
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 17-Jan-2007 03:25 pm
		// Revisions             : 1
		//=====================================================================
		//case IDC_QANEXT:
		//LSampType=SampType;
		//if( SampType==BLANK )
		//{
		//   SampType=STD;
		//	if (CurStd==NULL)
		//	    SampType=SAMP;
		//	if (SampType==SAMP && CurSamp==NULL)
		//   {
		//	    InQAnaRead=FALSE;
		//       AnaOver=TRUE;
		//		SendMessage(hwnd, WM_COMMAND, IDC_QASTART, 0L);
		//   }
		//}
		//else
		//{
		//   CurRepeat++;
		//   if ((CurRepeat>Method->QuantData->Param.Repeat && SampType==SAMP) || (CurRepeat>Method->QuantData->Param.ConcRepeat && SampType==STD))
		//   {
		//	    CurRepeat=1;
		//		if (SampType==STD )
		//       {
		//           If (CurStd! = NULL) Then
		//			    CurStd=CurStd->next;
		//			if (CurStd==NULL)
		//           {
		//			    StdAnalysed=TRUE;
		//			    if (!GetBlankCalType())
		//               {
		//				    Create_Standard_Sample_Curve(hwnd,FALSE);
		//
		//                   #If STD_ADDN Then
		//					    if(Method->QuantData->Param.Std_Addn)
		//					        endanalysis= TRUE;
		//                   #End If        
		//
		//				}
		//				SampType=SAMP;
		//			}
		//		}
		//		else if (SampType==SAMP)
		//       {
		//           If (CurSamp! = NULL) Then
		//			    CurSamp=CurSamp->next;
		//		}
		//	}
		//	if (Method->QuantData->Param.Blank)
		//	    SampType=BLANK;
		//}
		//InQAnaRead=FALSE;
		//EnableWindow(GetDlgItem(hwnd,IDC_SAVEREPORT), StdAnalysed);
		//EnableWindow(GetDlgItem(hwnd,IDC_QARPT),TRUE); 

		//#If STD_ADDN Then
		//   if(endanalysis)
		//       SendMessage(hwnd, WM_COMMAND, 951, 0L);
		//#End If
		//break;


		//--- CODE BY MANGESH 

		try {
			//--- Set previous Sample type to tmep and assign next sample type
			LSampType = SampleType;

			if ((SampleType == ClsAAS203.enumSampleType.BLANK)) {
				SampleType = ClsAAS203.enumSampleType.STANDARD;

				if (IsNothing(mobjCurrentStandard)) {
					SampleType = ClsAAS203.enumSampleType.SAMPLE;
				}


				if ((SampleType == ClsAAS203.enumSampleType.SAMPLE & IsNothing(mobjCurrentSample))) {
					InQAnaRead = false;
					AnaOver = true;
					//SendMessage(hwnd, WM_COMMAND, IDC_QASTART, 0L)
					// Set the StartStop Analysis porcedure
					mblnAvoidProcessing = false;
					StartStopAnalysis_Click(btnStartStopAnalysis, EventArgs.Empty);
				}


			} else {
				CurRepeat += 1;

				//if ////////////////////////////////((CurRepeat>Method->QuantData->Param.Repeat && SampType==SAMP) || (CurRepeat>Method->QuantData->Param.ConcRepeat && SampType==STD)){

				if (((CurRepeat > gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfSampleRepeats & SampleType == ClsAAS203.enumSampleType.SAMPLE) | (CurRepeat > gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfStdRepeats & SampleType == ClsAAS203.enumSampleType.STANDARD))) {
					CurRepeat = 1;

					if ((SampleType == ClsAAS203.enumSampleType.STANDARD)) {
						//If (CurStd! = NULL) Then
						//   CurStd=CurStd->next
						//}
						// Set the current standard
						funcGetCurrentStandard(mobjCurrentStandard);



						if (IsNothing(mobjCurrentStandard)) {
							StdAnalysed = true;

							if (!(gstructSettings.BlankCalculation)) {
								gobjclsStandardGraph.Create_Standard_Sample_Curve(false, true, 0, 0, gobjNewMethod);

								//#If STD_ADDN Then
								if (gobjNewMethod.StandardAddition) {
									//if(Method->QuantData->Param.Std_Addn)                   

									EndAnalysis = true;
									//End If
									//#End If
								}
							}
							SampleType = ClsAAS203.enumSampleType.SAMPLE;
						}
					} else if ((SampleType == ClsAAS203.enumSampleType.SAMPLE)) {
						//If (CurSamp! = NULL) Then
						//   CurSamp=CurSamp->next;
						funcGetCurrentSample(mobjCurrentSample);
					}
				}
				//EnableWindow(GetDlgItem(hwnd, IDC_SAVEREPORT), StdAnalysed)
				btnSave.Enabled = StdAnalysed;

				//--- Check Blank After Every Sample or Std and set sample type is blank
				if ((gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.IsBlankAfterEverySampleOrStd)) {
					SampleType = ClsAAS203.enumSampleType.BLANK;
				} else {

					if ((SampleType == ClsAAS203.enumSampleType.SAMPLE & IsNothing(mobjCurrentSample))) {
						InQAnaRead = false;
						AnaOver = true;
						//SendMessage(hwnd, WM_COMMAND, IDC_QASTART, 0L)
						// Set the StartStop Analysis porcedure
						mblnAvoidProcessing = false;
						StartStopAnalysis_Click(btnStartStopAnalysis, EventArgs.Empty);
					}
				}

			}

			InQAnaRead = false;
			//tlbbtnSaveReport.Enabled = StdAnalysed
			//tlbbtnRepeatLastAnalysis.Enabled = True
			btnEditData.Enabled = StdAnalysed;
			btnRepeatLast.Enabled = true;
			//--- Asipiration message for next analysis
			Aspirate();
			// check for Standsrd Addition mode and if analysis is end then use start stop analysis porcesure
			//#If STD_ADDN Then
			if (gobjNewMethod.StandardAddition) {
				if ((EndAnalysis)) {
					//SendMessage(hwnd, WM_COMMAND, 951, 0L)
					mblnAvoidProcessing = false;
					//---02.08.09
					StartStopAnalysis_Click(btnStartStopAnalysis, EventArgs.Empty);
				}
			}
		//End IF

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

	private bool funcGetCurrentStandard(ref Method.clsAnalysisStdParameters objCurrentStandard)
	{
		//=====================================================================
		// Procedure Name        : funcGetCurrentStandard
		// Parameters Passed     : objCurrentStandard As Method.clsAnalysisStdParameters
		// Returns               : Bool
		// Purpose               : Set to curent standard
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 17-Jan-2007 03:25 pm
		// Revisions             : 1
		//=====================================================================
		//Static intIEnumCollLocation As Integer
		try {
			//Set by Ref. object of the current standard 
			if (!IsNothing(objCurrentStandard)) {
				//--- Check for last repeat Standard
				//If mblnRepeatLastStd = True Then
				//If funcMoveEnumerator(mobjStandardEnumerator, intIEnumCollLocationStd) = True Then
				//    objCurrentStandard = CType(mobjStandardEnumerator.Current, Method.clsAnalysisStdParameters)
				//Else
				//    objCurrentStandard = Nothing
				//End If
				//Else
				intIEnumCollLocationStd += 1;
				if (funcMoveEnumerator(mobjStandardEnumerator, intIEnumCollLocationStd) == true) {
					objCurrentStandard = (Method.clsAnalysisStdParameters)mobjStandardEnumerator.Current;
				} else {
					objCurrentStandard = null;
				}
				//End If
				//mblnRepeatLastStd = False
			}
			mblnRepeatLastStd = false;
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

	private bool funcGetCurrentSample(ref Method.clsAnalysisSampleParameters objCurrentSample)
	{
		//=====================================================================
		// Procedure Name        : funcGetCurrentSample
		// Parameters Passed     : objCurrentStandard As Method.clsAnalysisStdParameters
		// Returns               : Bool
		// Purpose               : Set to curent Sample
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 17-Jan-2007 03:25 pm
		// Revisions             : 1
		//=====================================================================
		//Static intIEnumCollLocation As Integer
		try {
			//Set by Ref. object of the current sample
			if (!IsNothing(objCurrentSample)) {
				//--- Check for last repeat sample
				//If mblnRepeatLastSample = True Then

				//    If funcMoveSampleEnumerator(mobjSampleEnumerator, intIEnumCollLocationSamp) = True Then
				//        objCurrentSample = CType(mobjSampleEnumerator.Current, Method.clsAnalysisSampleParameters)
				//    Else
				//        objCurrentSample = Nothing
				//    End If
				//Else

				intIEnumCollLocationSamp += 1;
				if (funcMoveSampleEnumerator(mobjSampleEnumerator, intIEnumCollLocationSamp) == true) {
					objCurrentSample = (Method.clsAnalysisSampleParameters)mobjSampleEnumerator.Current;
				} else {
					objCurrentSample = null;
				}
				//End If
				//mblnRepeatLastSample = False
			}
			mblnRepeatLastSample = false;
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

	private bool funcMoveEnumerator(ref IEnumerator piEnumarator, int iLocation)
	{
		//=====================================================================
		// Procedure Name        : funcMoveEnumerator
		// Parameters Passed     : piStandardEnumarator As IEnumerator, piSampleEnumarator As IEnumerator
		// Returns               : Bool
		// Purpose               : Move Enumerator object
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 17-Jan-2007 03:25 pm
		// Revisions             : 1
		//=====================================================================

		IEnumerator tmpEnum;
		bool IsLastRecoed = false;
		try {
			if (mobjCurrentStandard == null) {
				return false;
			}
			int i;
			//assign enumarator to temporary enumrator
			tmpEnum = piEnumarator;
			if (!tmpEnum == null) {
				//move the pointer to starting position
				tmpEnum.Reset();
				//validate location
				if (iLocation <= 0) {
					IsLastRecoed = true;
				}
				//move enumrator pointer to said location
				for (i = 1; i <= iLocation; i++) {
					if (tmpEnum.MoveNext() == false) {
						IsLastRecoed = true;
						break; // TODO: might not be correct. Was : Exit For
					}
				}
				//assign temp enumrator to original enumrator
				piEnumarator = tmpEnum;
			}
			if (IsLastRecoed == true) {
				return false;
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

	private bool funcMoveSampleEnumerator(ref IEnumerator piEnumarator, int iLocation)
	{
		//=====================================================================
		// Procedure Name        : funcMoveSampleEnumerator
		// Parameters Passed     : piStandardEnumarator As IEnumerator, piSampleEnumarator As IEnumerator
		// Returns               : Bool
		// Purpose               : Move sample Enumerator object
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 17-Jan-2007 03:25 pm
		// Revisions             : 1
		//=====================================================================
		IEnumerator tmpEnum;
		bool IsLastRecoed = false;

		try {
			int i;
			if (mobjCurrentSample == null) {
				return false;
			}
			if (!IsNothing(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection)) {
				mobjSampleEnumerator = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.GetEnumerator();
				tmpEnum = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.GetEnumerator();
			} else {
				tmpEnum = piEnumarator;
			}


			if (!tmpEnum == null) {
				tmpEnum.Reset();
				//validate location
				if (iLocation <= 0) {
					IsLastRecoed = true;
				}
				//move enumrator pointer to said location
				for (i = 1; i <= iLocation; i++) {
					if (tmpEnum.MoveNext() == false) {
						IsLastRecoed = true;
						break; // TODO: might not be correct. Was : Exit For
					}
				}
				piEnumarator = tmpEnum;
			}
			if (IsLastRecoed == true) {
				return false;
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

	private bool funcRefreshEnumerators(ref IEnumerator piStandardEnumarator, ref IEnumerator piSampleEnumarator)
	{
		//=====================================================================
		// Procedure Name        : funcRefreshEnumerators
		// Parameters Passed     : piStandardEnumarator As IEnumerator, piSampleEnumarator As IEnumerator
		// Returns               : Bool
		// Purpose               : Move refresh Enumerator object
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 17-Jan-2007 03:25 pm
		// Revisions             : 1
		//=====================================================================
		IEnumerator tmpEnum;
		bool IsLastRecoed = false;
		try {
			//Dim i As Integer
			if (!(mobjCurrentStandard == null)) {
				if (!IsNothing(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection)) {
					piStandardEnumarator = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.GetEnumerator();
					piStandardEnumarator.Reset();
				//Try 'by Pankaj on 30 Jan 08
				//    If Not (piStandardEnumarator.Current Is Nothing) Then
				//        mobjCurrentStandard = CType(piStandardEnumarator.Current, Method.clsAnalysisStdParameters)
				//    End If
				//Catch ex As InvalidOperationException
				//    If piStandardEnumarator.MoveNext = True Then
				//        If Not (piStandardEnumarator.Current Is Nothing) Then
				//            mobjCurrentStandard = CType(piStandardEnumarator.Current, Method.clsAnalysisStdParameters)
				//        End If
				//    End If
				//End Try

				//tmpEnum = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.GetEnumerator()
				} else {
					//tmpEnum = piEnumarator
				}
			}
			if (!IsNothing(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection)) {
				piSampleEnumarator = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.GetEnumerator();
				piSampleEnumarator.Reset();
			//Try 'by Pankaj on 30 Jan 08
			//    If Not (piSampleEnumarator.Current Is Nothing) Then
			//        mobjCurrentSample = CType(piSampleEnumarator.Current, Method.clsAnalysisSampleParameters)
			//    End If
			//Catch ex As InvalidOperationException
			//    If piSampleEnumarator.MoveNext = True Then
			//        If Not (piSampleEnumarator.Current Is Nothing) Then
			//            mobjCurrentSample = CType(piSampleEnumarator.Current, Method.clsAnalysisSampleParameters)
			//        End If
			//    End If
			//End Try

			//tmpEnum = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.GetEnumerator()
			} else {
				//tmpEnum = piEnumarator
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

	private void BlankAnalysis_Clicked(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : BlankAnalysis_Clicked
		// Parameters Passed     : Object, EventArgs
		// Returns               : Bool
		// Purpose               : perform blank analysis
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 17-Jan-2007 03:25 pm
		// Revisions             : 1
		//=====================================================================
		//case	IDC_BLANK:
		//   SampType=BLANK;
		//   break;
		try {
			// Set Blank sample type
			if (!(SampleType == ClsAAS203.enumSampleType.BLANK)) {
				SampleType = ClsAAS203.enumSampleType.BLANK;
				//Aspiration message for diff. type of sample
				Aspirate();
			}
			if (btnReadData.Enabled) {
				btnReadData.Focus();
				btnReadData.Refresh();
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

	private void StartStopAnalysis_Click(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : StartStopAnalysis_Click
		// Parameters Passed     : Object, EventArgs
		// Returns               : None
		// Purpose               : Start/Stop anslysis
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 17-Jan-2007 03:25 pm
		// Revisions             : 1
		//=====================================================================
		//Started ^= 1;
		//InAnalysis ^= 1;

		//if(Started & !exitbutton){
		//   if (MessageBox(hwnd," New Analysis?", "STD/SAMPLE ANALYSIS", MB_ICONQUESTION | MB_YESNO)==IDYES){
		//   SendMessage(hwnd, WM_COMMAND,IDC_QANEW, 0L);
		//   }
		//}
		//WP1= wParam;
		//if (!AnaOver && (CurStd==NULL && CurSamp==NULL)){
		//   If (!StdAnalysed) Then
		//       CurStd  =Method->QuantData->StdTopData;
		//   #If STD_ADDN Then
		//       if(!Method->QuantData->Param.Std_Addn)
		//   #End If
		//       CurSamp =Method->QuantData->SampTopData;
		//}
		//CheckAnaButtons(hwnd);
		//if (Started){
		//   if (AnaOver){
		//       if (MessageBox(hwnd," Data Exists in Memory . \n Erase them ?", "STD/SAMPLE ANALYSIS", MB_YESNO)==IDYES)
		//           SendMessage(hwnd, WM_COMMAND,IDC_QANEW, 0L);
		//   }
		//   SetWindowText(GetDlgItem(hwnd, IDC_QASTART), "E&nd Ana");
		//   if (Method->QuantData->Fname<=0)
		//   GetRunNo(Method);
		//   DisplayRunNo(hwnd);
		//}
		//else{
		//   SetWindowText(GetDlgItem(hwnd, IDC_QASTART), "&Start");
		//   RawDataSave("rawdata.txt");
		//   if (toreported||!Method->RepReady ){
		//   SaveQuantResults(hwnd, Method, A1,0);
		//   toreported=FALSE;
		//   }
		//   DestroyAspWnd();
		//}
		//InQAnaRead=FALSE;
		//#If QDEMO Then
		//   if (AnaOver)
		//       EndFiledataRead();
		//#End If
		//break;
		//------------------------------------------
		try {
			//If mblnAvoidProcessing = True Then  '10.12.07 'commented by pankaj on 23 Mar 08  
			//    Exit Sub
			//End If
			//-----by Pankaj on 23 Mar 08 for autosampler
			if (mblnAvoidProcessing == true & mblnIsAutosampler == false) {
				return;
			}
			//----end
			mblnExecuteRunNo = true;
			mblnAvoidProcessing = true;
			// Start or stop the analysis depending upon setting
			//'by Pankaj for autosampler on 10Sep 07
			if ((gstructAutoSampler.blnAutoSamplerInitialised == true)) {
				mblnIsAutosampler = gstructAutoSampler.blnCommunication;
			} else {
				mblnIsAutosampler = false;
			}
			mblnIsAnalysisStarted = !mblnIsAnalysisStarted;
			InAnalysis = !InAnalysis;
			//Check for start Analysis 
			if (mblnIsAnalysisStarted) {
				//If mblnAvoidProcessing = True Then  '10.12.07
				//    Exit Sub
				//End If
				//mblnAvoidProcessing = True
				//---
				//Saurabh Add to check if 'No' is selected
				if ((mblnIsAnalysisStarted & (!exitbutton))) {
					//Check for to start New Analysis
					if ((gobjMessageAdapter.ShowMessage(constNewAnalysis) == true)) {
						//SendMessage(hwnd, WM_COMMAND,IDC_QANEW, 0L)
						//by pankaj on 3 OCt 07
						if ((mblnIsAutosampler & mblnIsAnalysisStarted)) {
							btnReadData.Enabled = false;
						}
						NewAnalysis_Clicked(btnNewAnalysis, EventArgs.Empty);
					} else {
						////-----------
						if (!mobjAnalysisRawData == null) {
							if (mobjAnalysisRawData.Count == 0) {
								NewAnalysis_Clicked(btnNewAnalysis, EventArgs.Empty);
							}
						} else {
							NewAnalysis_Clicked(btnNewAnalysis, EventArgs.Empty);
						}
						//Else
						//    'mobjAnalysisRawData(0).
						//    Dim intSampleCount As Integer = gobjNewMethod.QuantitativeDataCollection(0).SampleDataCollection.Count
						//    'If gobjNewMethod.QuantitativeDataCollection(0).SampleDataCollection >= intSampleCount Then
						//    'gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection()
						//    Dim CountSampData, IdxRawData As Integer
						//    CountSampData = 0
						//    For IdxRawData = 0 To mobjAnalysisRawData.Count - 1
						//        If mobjAnalysisRawData(IdxRawData).SampleType = clsRawData.enumSampleType.SAMPLE Then
						//            CountSampData += 1
						//        End If
						//    Next

						//    If CountSampData >= gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.Count Then
						//        If gobjMessageAdapter.ShowMessage("Data exist in memory, Erase it?", "Erase Memory", MessageHandler.clsMessageHandler.enumMessageType.QuestionMessage) = True Then
						//            Call NewAnalysis_Clicked(btnNewAnalysis, EventArgs.Empty)
						//        End If
						//    End If
						//End If
						////---------------------
						//mblnIsAnalysisStarted = Not mblnIsAnalysisStarted
						//InAnalysis = Not InAnalysis
						//mblnAvoidProcessing = False     '10.12.07
						//Exit Sub
					}
				}
				// if New Analysis is then ....
				//Saurabh Add to check if 'No' is selected
				btnStartStopAnalysis.Text = "End Anal&ysis";
				mstrAspirationMessage = "Click End Analysis button to Stop Analysis.";
				mobjBgMsgAspirate.AspirationMessage = mstrAspirationMessage;
				btnReadData.Enabled = true;
				//Saurabh 10.07.07
				if (!IsNothing(gobjMain.mobjfrmMethod)) {
					gobjMain.mobjfrmMethod.btnNewMethod.Enabled = false;
					gobjMain.mobjfrmMethod.btnLoadMethod.Enabled = false;
				}
			//mblnAvoidProcessing = False     '10.12.07
			//Saurabh 10.07.07
			} else {
				// Stop the Analysis before complite the analysis
				// Set Aspiration Message and buttons caption
				btnStartStopAnalysis.Text = "Start Anal&ysis";
				mstrAspirationMessage = "Click Start button to Start Analysis.";
				mobjBgMsgAspirate.AspirationMessage = mstrAspirationMessage;
				btnReadData.Enabled = false;
				//Saurabh 10.07.07
				if (!IsNothing(gobjMain.mobjfrmMethod)) {
					gobjMain.mobjfrmMethod.btnNewMethod.Enabled = true;
					gobjMain.mobjfrmMethod.btnLoadMethod.Enabled = true;
				}
				//Saurabh 10.07.07
			}

			//Saurabh Shifted on top of this procedure
			//If (mblnIsAnalysisStarted And (Not exitbutton)) Then
			//    If (gobjMessageAdapter.ShowMessage(constNewAnalysis) = True) Then
			//        'SendMessage(hwnd, WM_COMMAND,IDC_QANEW, 0L)
			//        Call NewAnalysis_Clicked(btnNewAnalysis, EventArgs.Empty)
			//    End If
			//End If
			//Saurabh Shifted on top of this procedure

			//WP1= wParam;
			if ((!AnaOver & (IsNothing(mobjCurrentStandard) & IsNothing(mobjCurrentSample)))) {
				if (!(StdAnalysed)) {
					//CurStd  =Method->QuantData->StdTopData;
					mobjCurrentStandard = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(0);
				}
				//#If STD_ADDN Then
				if (!(gobjNewMethod.StandardAddition)) {
					//CurSamp =Method->QuantData->SampTopData;
					mobjCurrentSample = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(0);
				}
				//#End If
			}
			// Set the enable/disable property for buttons reguarding of actual analysis 
			CheckAnaButtons();
			// Check under any circumtancy if analysis is started mode 
			// but Analysis is over (Standard and Sample Analysis)
			if ((mblnIsAnalysisStarted)) {
				if ((AnaOver)) {
					if (gobjMessageAdapter.ShowMessage(constDataExists) == true) {
						//If (MessageBox.Show(" Data Exists in Memory." & vbCrLf & "Erase them?", "STANDARD/SAMPLE ANALYSIS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
						//SendMessage(hwnd, WM_COMMAND,IDC_QANEW, 0L)
						mblnIsStartRunNumber = false;
						//Call GetRunNo(gobjNewMethod)
						NewAnalysis_Clicked(btnNewAnalysis, EventArgs.Empty);
					}
				}
				if (mblnIsCreateNewRunNo == true) {
					// Get the Run No from Data collection object
					GetRunNo(gobjNewMethod);
					mblnIsCreateNewRunNo = false;
				}

				// Display Run No in screen
				DisplayRunNo();

				gobjNewMethod.DateOfLastUse = Now;

				//SetWindowText(GetDlgItem(hwnd, IDC_QASTART), "E&nd Ana")
				btnStartStopAnalysis.Text = "E&nd Analysis";

				////----- Previous Standard
				//gobjclsStandardGraph = New clsStandardGraph
				////----- Added by Sachin Dokhale 
				////----- Previous Standard
				//If blnIsLoadPreviousStandards = False Then
				if (gobjclsStandardGraph == null) {
					gobjclsStandardGraph = new clsStandardGraph();
				}
				//Else
				//If gobjclsStandardGraph Is Nothing Then
				//    gobjclsStandardGraph = New clsStandardGraph
				//End If
				//End If

				gobjClsAAS203.funcSave_Fuel_Conditions();
				//---30.04.10


			////-----

			} else {
				btnStartStopAnalysis.Text = "&Start Analysis";

				gobjClsAAS203.funcSave_Fuel_Conditions();
				//---30.04.10


				btnEditData.Enabled = true;
				//when Stop the analysisSave the Row Data into file system and also into method collection object
				RawDataSave("rawdata.txt");
				SaveRawDataFile();
				double[] A1 = {
					0,
					0,
					0,
					0,
					0,
					0
				};
				//if (toreported or  not (Method->RepReady) )
				// Check data is ready to store into system (File System/Collection object)
				if ((toreported)) {
					//SaveQuantResults(hwnd, Method, A1, 0)
					gobjNewMethod.DateOfLastUse = Now;

					//---added by deepak on 20.07.07 for not dsplaying messages in uv mode

					if (!gobjNewMethod.OperationMode == EnumOperationMode.MODE_UVABS) {
						if (gobjClsAAS203.SaveQuantResults(gobjNewMethod, A1, 1) == true) {
							mblnIsStartRunNumber = true;
						}
					} else {
						// This function last parameter is "ShowMessage" is use to show messages after saving result.
						// It is optional and use only for UV Mode analysis
						if (gobjClsAAS203.SaveQuantResults(gobjNewMethod, A1, 0, false) == true) {
							mblnIsStartRunNumber = true;
						}
					}
					//Call gobjClsAAS203.SaveQuantResults(gobjNewMethod, A1, 0)


					//Dim intMethodCounter As Integer
					//For intMethodCounter = 0 To gobjMethodCollection.Count - 1
					//    If gobjMethodCollection.item(intMethodCounter).MethodID = gobjNewMethod.MethodID Then
					//        gobjNewMethod = gobjMethodCollection.item(intMethodCounter).Clone()
					//        Exit For
					//    End If
					//Next

					//mblnIsStartRunNumber = True
					toreported = false;
				}
				//End If
			}
			InQAnaRead = false;
			mblnExecuteRunNo = false;
			//#If QDEMO Then
			//   If (AnaOver) Then
			//       EndFiledataRead()
			//   End If
			//#End If
			mblnAvoidProcessing = false;
			//call "ReadData_Click" this event when Autosampler is use and process under started analysis
			if ((mblnIsAutosampler & mblnIsAnalysisStarted)) {
				//SendMessage(hwnd, WM_COMMAND, IDC_QAREAD, 0L)
				ReadData_Click(btnReadData, EventArgs.Empty);
				//by pankaj on 01 Oct07 
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

	private void ReadData_Click(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : ReadData_Click
		// Parameters Passed     : Object, EventArgs
		// Returns               : None
		// Purpose               : Read data from instrument for analysis
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 17-Jan-2007 03:25 pm
		// Revisions             : 1
		//=====================================================================
		//case	IDC_QAREAD:

		//if(Method->Mode != MODE_UVABS)
		//{
		//   t = Ignite_Test();
		//	if(!GetHydrideModeStatus() && (t == GREEN || t == RED))
		//	    {
		//		    MessageBox(hwnd,"Flame is OFF.\nAnalysis not possible.","Aspiration Error",MB_ICONSTOP | MB_OK);
		//			break;
		//		}
		//}
		//#If STD_ADDN Then
		//	if(Method->QuantData->Param.Std_Addn)
		//	{
		//	    if(endanalysis)
		//		SendMessage(hwnd, WM_COMMAND,IDC_QANEW, 0L);
		//	}
		//#End If
		//	InQAnaRead=TRUE;
		//	toreported=TRUE;
		//	strcpy(Aspiratemsg,"Reading Wait ... ");
		//	Disp_Analysis_Info(hwnd);
		//	abs1=Read_Quant_Data(hwnd, &AnaGraph);
		//	if (!Method->RepReady )
		//	{
		//	    SaveQuantResults(hwnd, Method, A1,0);
		//	}
		//   Else
		//	    SaveRawDataFile();

		//	if(SampType==STD)
		//	{
		//	    if(!CheckValidStdAbsEntry(Method->QuantData->StdTopData))
		//		{
		//		    MessageBox(hwnd,"Abs of the std is less than or equal to the previous std.\nPress 'Rpt Last' button for Aspirating the same std again","Std Aspiration Error",MB_ICONSTOP | MB_OK);
		//		}
		//	}
		//	if(SampType==SAMP)
		//	{
		//	    if(!CheckValidSampAbsEntry(Method->QuantData->StdTopData,abs1))
		//		{
		//		    MessageBox(hwnd,"Abs of the sample is more than the maximum standard value.\nCalculated Concentration may not be correct.\nPlease dilute the sample and repeat again.\nPress RptLast button when ready.","Sample Aspiration Error",MB_ICONSTOP | MB_OK);
		//		}
		//	}
		//	SendMessage(hwnd, WM_COMMAND, 900, 0L);//IDC_QANEXT, 0L);
		//	break;



		//----CODE BY MANEGSH 

		//startRead:
		ClsAAS203.enumIgniteType intEnumIgiteType;

		try {
			if (mblnAvoidProcessing == true & mblnIsAutosampler == false) {
				return;
			}
			mblnAvoidProcessing = true;

			gobjMain.mobjController.Cancel();
			gobjCommProtocol.mobjCommdll.subTime_Delay(500);
			//10.12.07
			Application.DoEvents();


			if (!(gobjNewMethod.OperationMode == EnumOperationMode.MODE_UVABS)) {
				if ((gstructSettings.AppMode == EnumAppMode.DemoMode) | (gstructSettings.AppMode == EnumAppMode.DemoMode_201) | (gstructSettings.AppMode == EnumAppMode.DemoMode_203D)) {
					intEnumIgiteType = ClsAAS203.enumIgniteType.Blue;
				} else {

					if (gobjMain.mobjController.IsThreadRunning == false) {
						//--- Modified function of funcIgnite_Test by Sachin Dokhale on 04.02.07
						//intEnumIgiteType = gobjClsAAS203.funcIgnite_Test()
						ClsAAS203.enumIgniteType intIgnite_Test;
						if (gobjClsAAS203.funcIgnite_Test(intIgnite_Test)) {
							intEnumIgiteType = intIgnite_Test;
						}
					//---
					} else {
						intEnumIgiteType = gobjfrmStatus.FlameType;
					}
				}
				gobjfrmStatus.FlameType = intEnumIgiteType;
				if (((!HydrideMode) & (intEnumIgiteType == ClsAAS203.enumIgniteType.Green | gobjMain.IgniteType == ClsAAS203.enumIgniteType.Red))) {
					//gobjMessageAdapter.ShowMessage("Flame is OFF." & vbCrLf & "Analysis not possible.", "Aspiration Error", MessageHandler.clsMessageHandler.enumMessageType.ErrorMessage)
					gobjMessageAdapter.ShowMessage(constFlameOFF);
					if (gobjMain.mobjController.IsThreadRunning == false) {
						gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay);
						Application.DoEvents();
						gobjMain.mobjController.Start(gobjclsBgFlameStatus);
					}
					mblnAvoidProcessing = false;
					return;
				}
			}

			//  Check when standaed addtion Flag is On and Analysis is complite 
			//  then continue to start New Analysis from begin.
			//#If STD_ADDN Then
			if ((gobjNewMethod.StandardAddition)) {
				if ((EndAnalysis)) {
					//SendMessage(hwnd, WM_COMMAND, IDC_QANEW, 0L)
					NewAnalysis_Clicked(btnNewAnalysis, EventArgs.Empty);
					gobjMain.mobjController.Cancel();
					gobjCommProtocol.mobjCommdll.subTime_Delay(500);
					//10.12.07
					Application.DoEvents();
				}
			}
			//#End If

			// Set this flag to show report 
			InQAnaRead = true;
			toreported = true;

			mstrAspirationMessage = "Reading Wait ... ";
			mobjBgMsgAspirate.AspirationMessage = mstrAspirationMessage;

			//Call gobjCommProtocol.mobjCommdll.subTime_Delay(1200)
			Application.DoEvents();

			// To Display Analysis information.
			Display_Analysis_Info();
			////----- Added by Sachin Dokhale
			//btnReadData.Enabled = False
			btnReadData.Click -= ReadData_Click;

			if (!(Afirst)) {
				mEndTime = mobjBgReadData.CEndTime;
			} else {
				mEndTime = mStartTime;
			}

			mdblAbsorbance = Read_Quant_Data(mStartTime, mEndTime);


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
frmAnalysis_Closing(object sender, System.ComponentModel.CancelEventArgs e)
	{
		//=====================================================================
		// Procedure Name        : frmAnalysis_Closing
		// Parameters Passed     : object, EventArgs
		// Returns               : None
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 16-Mar-2007 12:45 pm
		// Revisions             : 1
		//=====================================================================
		try {
			gobjMain.ShowRunTimeInfo(ConstParentFormLoad);
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

	private void btnEditData_Clicked(object sender, EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : btnEditData_Clicked
		// Parameters Passed     : object, EventArgs
		// Returns               : None
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 16-Mar-2007 12:45 pm
		// Revisions             : 1
		//=====================================================================

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
		frmDeleteStdNSam objfrmDeleteStdNSam;

		frmViewRepeatResults objfrmViewRepeatResults;

		try {
			//validate objects Quantitative data collection
			if (IsNothing(gobjNewMethod.QuantitativeDataCollection)) {
				return;
			}

			if (((gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfSampleRepeats > 1 | gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfStdRepeats > 1) & clsStandardGraph.FindSamplesAnalysed(gobjNewMethod, mintRunNumberIndex) >= 1)) {
				//show result
				objfrmViewRepeatResults = new frmViewRepeatResults(gobjNewMethod, mintRunNumberIndex);
				objfrmViewRepeatResults.ShowDialog();
				Application.DoEvents();
				objfrmViewRepeatResults.Close();
				objfrmViewRepeatResults.Dispose();
				objfrmViewRepeatResults = null;
			} else {
				//flag = OnEditStdSamples()
				objfrmDeleteStdNSam = new frmDeleteStdNSam(gobjNewMethod, mintRunNumberIndex);
				if (objfrmDeleteStdNSam.ShowDialog() == DialogResult.OK) {
					tlbbtnSampleGraph_Click(sender, e);
				}
				objfrmDeleteStdNSam.Close();
				Application.DoEvents();
				if (!objfrmDeleteStdNSam == null) {
					objfrmDeleteStdNSam.Dispose();
				}
				objfrmDeleteStdNSam = null;
				flag = true;
			}
			if (btnReadData.Enabled) {
				btnReadData.Focus();
				btnReadData.Refresh();
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

	//Private Sub XpPanelReports_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs)
	//    '=====================================================================
	//    ' Procedure Name        : XpPanelReportsClicked
	//    ' Parameters Passed     : Object,EventArgs
	//    ' Returns               : None
	//    ' Purpose               : To view the Reports
	//    ' Description           : 
	//    ' Assumptions           : 
	//    ' Dependencies          : 
	//    ' Author                : Deepak & Saurabh
	//    ' Created               : 05.10.06
	//    ' Revisions             : 
	//    '===================================================================== 
	//    Dim objWait As New CWaitCursor

	//    Try
	//        If Me.XpPanelReports.PanelState = UIComponents.XPPanelState.Collapsed Then
	//            Call funcCollapseAllXPPanels()
	//            Me.XpPanelReports.TogglePanelState()
	//            Me.XpPanelReports.PanelHeight = 80
	//        End If

	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        'Error Handling and logging
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = ex.Message
	//        gobjErrorHandler.WriteErrorLog(ex)
	//        '---------------------------------------------------------
	//    Finally
	//        '---------------------------------------------------------
	//        'Writing Execution log
	//        If CONST_CREATE_EXECUTION_LOG = 1 Then
	//            gobjErrorHandler.WriteExecutionLog()
	//        End If
	//        If Not objWait Is Nothing Then
	//            objWait.Dispose()
	//        End If
	//        '---------------------------------------------------------
	//    End Try
	//End Sub

	//Private Sub XpPanelSampleGraph_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs)
	//    '=====================================================================
	//    ' Procedure Name        : XpPanelSampleGraphClicked
	//    ' Parameters Passed     : Object,EventArgs
	//    ' Returns               : None
	//    ' Purpose               : To view the Sample Graphs
	//    ' Description           : 
	//    ' Assumptions           : 
	//    ' Dependencies          : 
	//    ' Author                : Deepak & Saurabh
	//    ' Created               : 05.10.06
	//    ' Revisions             : 
	//    '===================================================================== 
	//    Dim objWait As New CWaitCursor

	//    Try
	//        If Me.XpPanelSampleGraph.PanelState = UIComponents.XPPanelState.Collapsed Then
	//            Call funcCollapseAllXPPanels()
	//            Me.XpPanelSampleGraph.TogglePanelState()
	//            Me.XpPanelSampleGraph.PanelHeight = 90
	//        End If

	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        'Error Handling and logging
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = ex.Message
	//        gobjErrorHandler.WriteErrorLog(ex)
	//        '---------------------------------------------------------
	//    Finally
	//        '---------------------------------------------------------
	//        'Writing Execution log
	//        If CONST_CREATE_EXECUTION_LOG = 1 Then
	//            gobjErrorHandler.WriteExecutionLog()
	//        End If
	//        If Not objWait Is Nothing Then
	//            objWait.Dispose()
	//        End If
	//        '---------------------------------------------------------
	//    End Try
	//End Sub

	//Private Sub XpPanelStandardGraph_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs)
	//    '=====================================================================
	//    ' Procedure Name        : XpPanelStandardGraphClicked
	//    ' Parameters Passed     : Object,EventArgs
	//    ' Returns               : None
	//    ' Purpose               : To load the Standard Graph form
	//    ' Description           : 
	//    ' Assumptions           : 
	//    ' Dependencies          : 
	//    ' Author                : Deepak & Saurabh
	//    ' Created               : 05.10.06
	//    ' Revisions             : 
	//    '===================================================================== 
	//    Dim objWait As New CWaitCursor

	//    Try
	//        If Me.XpPanelStandardGraph.PanelState = UIComponents.XPPanelState.Collapsed Then
	//            Call funcCollapseAllXPPanels()
	//            Me.XpPanelStandardGraph.TogglePanelState()
	//            Me.XpPanelStandardGraph.PanelHeight = 80
	//        End If

	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        'Error Handling and logging
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = ex.Message
	//        gobjErrorHandler.WriteErrorLog(ex)
	//        '---------------------------------------------------------
	//    Finally
	//        '---------------------------------------------------------
	//        'Writing Execution log
	//        If CONST_CREATE_EXECUTION_LOG = 1 Then
	//            gobjErrorHandler.WriteExecutionLog()
	//        End If
	//        If Not objWait Is Nothing Then
	//            objWait.Dispose()
	//        End If
	//        '---------------------------------------------------------
	//    End Try
	//End Sub

	//Private Sub XpPanelViewResults_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs)
	//    '=====================================================================
	//    ' Procedure Name        : XpPanelViewResultsClicked
	//    ' Parameters Passed     : Object,EventArgs
	//    ' Returns               : None
	//    ' Purpose               : To view the Results
	//    ' Description           : 
	//    ' Assumptions           : 
	//    ' Dependencies          : 
	//    ' Author                : Deepak & Saurabh
	//    ' Created               : 05.10.06
	//    ' Revisions             : 
	//    '===================================================================== 
	//    Dim objWait As New CWaitCursor

	//    Try
	//        If Me.XpPanelViewResults.PanelState = UIComponents.XPPanelState.Collapsed Then
	//            Call funcCollapseAllXPPanels()
	//            Me.XpPanelViewResults.TogglePanelState()
	//            Me.XpPanelViewResults.PanelHeight = 80
	//        End If

	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        'Error Handling and logging
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = ex.Message
	//        gobjErrorHandler.WriteErrorLog(ex)
	//        '---------------------------------------------------------
	//    Finally
	//        '---------------------------------------------------------
	//        'Writing Execution log
	//        If CONST_CREATE_EXECUTION_LOG = 1 Then
	//            gobjErrorHandler.WriteExecutionLog()
	//        End If
	//        If Not objWait Is Nothing Then
	//            objWait.Dispose()
	//        End If
	//        '---------------------------------------------------------
	//    End Try
	//End Sub

	private void  // ERROR: Handles clauses are not supported in C#
AASGraphAnalysis_GraphScaleChanged(double XMin, double XMax, double YMin, double YMax)
	{
		//=====================================================================
		// Procedure Name        : AASGraphAnalysis_GraphScaleChanged
		// Parameters Passed     : XMin, XMax, YMin, YMax  
		// Returns               : None
		// Purpose               : Set the property of graph 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 17-Jan-2007 03:25 pm
		// Revisions             : 1
		//=====================================================================
		try {
			//Set the property of graph object
			AASGraphAnalysis.AldysPane.XAxis.MinorStepAuto = false;
			AASGraphAnalysis.AldysPane.XAxis.StepAuto = false;
			AASGraphAnalysis.AldysPane.YAxis.MinorStepAuto = false;
			AASGraphAnalysis.AldysPane.YAxis.StepAuto = false;
			//---changed by deepak on 29.04.07
			AASGraphAnalysis.YAxisStep = 0.2;
			AASGraphAnalysis.YAxisMinorStep = 0.1;
			//---changed by deepak on 29.04.07
			//set focus to read data button
			AASGraphAnalysis.Refresh();
			if (btnReadData.Enabled) {
				btnReadData.Focus();
				btnReadData.Refresh();
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

	private void  // ERROR: Handles clauses are not supported in C#
cmdChangeScale_Click(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : cmdChangeScale_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : 
		// Description           : calculte change scale
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Pankaj Bamb
		// Created               : 1.05.07
		// Revisions             : 
		//=====================================================================
		if (mblnAvoidProcessing == true) {
			return;
		}
		CWaitCursor objWait = new CWaitCursor();
		frmChangeScale objfrmChangeScale;

		try {
			mblnAvoidProcessing = true;
			objfrmChangeScale = new frmChangeScale(mobjParameters, false);
			objfrmChangeScale.funcSetValidatingScale(gobjInst.Mode);
			objfrmChangeScale.lblXAxis.Visible = false;
			//-------------Added By Pankaj 11 May 07 for showing default scale on change form
			objfrmChangeScale.SpectrumParameter.XaxisMin = AASGraphAnalysis.XAxisMin;
			objfrmChangeScale.SpectrumParameter.XaxisMax = AASGraphAnalysis.XAxisMax;

			objfrmChangeScale.SpectrumParameter.YaxisMin = AASGraphAnalysis.YAxisMin;
			objfrmChangeScale.SpectrumParameter.YaxisMax = AASGraphAnalysis.YAxisMax;
			//------------------------
			if (objfrmChangeScale.ShowDialog() == DialogResult.OK) {
				//update scale data structur by user supplied values
				if (!objfrmChangeScale.SpectrumParameter == null) {
					mobjParameters.XaxisMax = objfrmChangeScale.SpectrumParameter.XaxisMax;
					mobjParameters.XaxisMin = objfrmChangeScale.SpectrumParameter.XaxisMin;
					mobjParameters.YaxisMax = objfrmChangeScale.SpectrumParameter.YaxisMax;
					mobjParameters.YaxisMin = objfrmChangeScale.SpectrumParameter.YaxisMin;
				}
				AASGraphAnalysis.XAxisMin = mobjParameters.XaxisMin;
				AASGraphAnalysis.XAxisMax = mobjParameters.XaxisMax;
				AASGraphAnalysis.YAxisMin = mobjParameters.YaxisMin;
				AASGraphAnalysis.YAxisMax = mobjParameters.YaxisMax;
				//adjust scale in proper range
				gobjClsAAS203.Calculate_Analysis_Graph_Param(AASGraphAnalysis, ClsAAS203.enumChangeAxis.xyAxis);

			}
			objfrmChangeScale.Close();
			//set the focus on read data button
			if (btnReadData.Enabled) {
				btnReadData.Focus();
				btnReadData.Refresh();
			}
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
			objfrmChangeScale.Dispose();
			if (!objWait == null) {
				objWait.Dispose();
			}
			//mblnAvoidProcessing = False
			//---------------------------------------------------------
		}
	}

	private void tlbbtnExportReport_Click(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : tlbbtnExportReport_Click
		// Parameters Passed     : Object, EventArgs
		// Returns               : 
		// Purpose               : Export data to the text file format
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
			//Added By Pankaj Fri 18 May 07
			// Check for 21CFR option
			if ((gstructSettings.Enable21CFR == true)) {
				if (!funcCheckActivityAuthentication(enumActivityAuthentication.Export, gstructUserDetails.Access)) {
					return;
					return;
				}
				gfuncInsertActivityLog(EnumModules.Export, "Export Accessed");
			}

			//    tlbbtnLoad.SuspendEvents()
			//mobjClsDataFileReport.MethodID = mintSelectedMethodID
			//mobjClsDataFileReport.RunNumber = mintSelectedRunNumber
			//For intCount = 0 To gobjMethodCollection.Count - 1
			//    If mintSelectedMethodID = gobjMethodCollection(intCount).MethodID Then
			//        intSelectId = intCount
			//        mobjClsDataFileReport.MethodID = intCount
			//        Exit For
			//    End If
			//Next
			string strRunNo;
			//strRunNo = mobjClsMethod.QuantitativeDataCollection.Item(intCount).RunNumber

			// Search Method id
			for (intCount = 0; intCount <= gobjMethodCollection.Count - 1; intCount++) {
				if (mintSelectedMethodID == gobjMethodCollection(intCount).MethodID) {
					//intSelectIDIndex = intCount
					intSelectId = intCount;
					//mobjClsDataFileReport.MethodID = intCount
					mobjClsDataFileReport.MethodID = gobjMethodCollection(intCount).MethodID;
					break; // TODO: might not be correct. Was : Exit For
				}
			}
			// Search run No
			strRunNo = gobjNewMethod.QuantitativeDataCollection.Item(0).RunNumber;
			for (intCount = 0; intCount <= gobjMethodCollection(intSelectId).QuantitativeDataCollection.Count - 1; intCount++) {
				if (strRunNo == (int)gobjMethodCollection(intSelectId).QuantitativeDataCollection(intCount).RunNumber) {
					mobjClsDataFileReport.RunNumber = (long)strRunNo;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			//For intCount = 0 To gobjMethodCollection(intSelectId).QuantitativeDataCollection.Count - 1
			//    If mintSelectedRunNumber = CInt(gobjMethodCollection(intSelectId).QuantitativeDataCollection(intCount).RunNumber) Then

			//        mobjClsDataFileReport.RunNumber = mintSelectedRunNumber
			//        Exit For
			//    End If
			//Next
			// Send data to export facility.
			mobjClsDataFileReport.funcDatafileExport(gobjMethodCollection(intSelectId).QuantitativeDataCollection(intCount).ReportParameters);
			if (btnReadData.Enabled) {
				btnReadData.Focus();
				btnReadData.Refresh();
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
			if (!objWait == null) {
				objWait.Dispose();
			}
			//---------------------------------------------------------
		}
	}

	#End Region

	#Region " Private Functions "

	private void ShowAspirationMessages(bool blnIsShow)
	{
		//=====================================================================
		// Procedure Name        : ShowAspirationMessages
		// Parameters Passed     : Flag to Set or Clear the Message.
		// Returns               : None
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 17-Jan-2007 03:25 pm
		// Revisions             : 1
		//=====================================================================
		//void	ShowAspMessage(BOOL	flag)
		//{
		//   char str[128]="";
		//   int t=0;
		//   if (flag)
		//   {
		//       GetDlgItemText(Mhwnd, IDC_TASP, str, 120);
		//	    ltrim(trim(str));
		//	    t = Ignite_Test();
		//	    if( (Method->Mode != MODE_UVABS && !GetHydrideModeStatus()) && (t == GREEN || t == RED) )  // mdf by sss for showing the flame error message
		//       {
		//		    SetDlgItemText(Mhwnd, IDC_TASP, "  Flame is OFF  ");
		//	    }
		//   	else
		//       {
		//   		if (strcmpi(str,Aspiratemsg)!=0)
		//		     SetDlgItemText(Mhwnd, IDC_TASP, Aspiratemsg);
		//	    }
		//   }
		//   Else
		//       SetDlgItemText(Mhwnd, IDC_TASP, "");
		//}




		ClsAAS203.enumIgniteType intIgniteType;
		string strAspMessage;

		try {
			//Application.DoEvents()
			if ((blnIsShow)) {
				strAspMessage = Trim(lblAspirationMessage.Text);

				if (gstructSettings.AppMode == EnumAppMode.DemoMode) {
				//intIgniteType = ClsAAS203.enumIgniteType.Blue
				} else {
					//intIgniteType = gobjClsAAS203.funcIgnite_Test()
				}

				//If ((gobjNewMethod.OperationMode <> EnumOperationMode.MODE_UVABS And Not gobjInst.Hydride) _
				//    And (intIgniteType = ClsAAS203.enumIgniteType.Green Or intIgniteType = ClsAAS203.enumIgniteType.Red)) Then
				//intIgniteType = gobjMain.IgniteType

				if (((gobjNewMethod.OperationMode != EnumOperationMode.MODE_UVABS & !gobjInst.Hydride) & (gobjMain.IgniteType == ClsAAS203.enumIgniteType.Green | gobjMain.IgniteType == ClsAAS203.enumIgniteType.Red))) {
					//for showing the flame error message
					lblAspirationMessage.Text = "  Flame is OFF  ";
				} else {
					if (string.Compare(strAspMessage, mstrAspirationMessage) != 0) {
						lblAspirationMessage.Text = mstrAspirationMessage;
						lblAspirationMessage.Refresh();
					}
				}

			} else {
				lblAspirationMessage.Text = "";
				lblAspirationMessage.Refresh();
			}
			//Application.DoEvents()
			//set focus to read data button
			if (btnReadData.Enabled) {
				btnReadData.Focus();
				btnReadData.Refresh();
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
			//Application.DoEvents()     'Commented by Saurabh 20.07.07
			//---------------------------------------------------------
		}
	}

	//Private Function funcCollapseAllXPPanels() As Boolean
	//    '=====================================================================
	//    ' Procedure Name        : funcCollapseAllXPPanels
	//    ' Parameters Passed     : None
	//    ' Returns               : True or False
	//    ' Purpose               : To collapse all XP Panels
	//    ' Description           : 
	//    ' Assumptions           : 
	//    ' Dependencies          : 
	//    ' Author                : Deepak Bhati
	//    ' Created               : 05.10.06
	//    ' Revisions             : 
	//    '=====================================================================
	//    Try
	//        If Me.XpPanelStandardGraph.PanelState = UIComponents.XPPanelState.Expanded Then
	//            Me.XpPanelStandardGraph.TogglePanelState()
	//            Me.XpPanelStandardGraph.Height = 0
	//        End If
	//        If Me.XpPanelSampleGraph.PanelState = UIComponents.XPPanelState.Expanded Then
	//            Me.XpPanelSampleGraph.TogglePanelState()
	//            Me.XpPanelSampleGraph.Height = 0
	//        End If
	//        If Me.XpPanelViewResults.PanelState = UIComponents.XPPanelState.Expanded Then
	//            Me.XpPanelViewResults.TogglePanelState()
	//            Me.XpPanelViewResults.Height = 0
	//        End If
	//        If Me.XpPanelReports.PanelState = UIComponents.XPPanelState.Expanded Then
	//            Me.XpPanelReports.TogglePanelState()
	//            Me.XpPanelReports.Height = 0
	//        End If

	//        Return True

	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        'Error Handling and logging
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = ex.Message
	//        gobjErrorHandler.WriteErrorLog(ex)
	//        Return False
	//        '---------------------------------------------------------
	//    Finally
	//        '---------------------------------------------------------
	//        'Writing Execution log
	//        If CONST_CREATE_EXECUTION_LOG = 1 Then
	//            gobjErrorHandler.WriteExecutionLog()
	//        End If
	//        '---------------------------------------------------------
	//    End Try
	//End Function

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
		CWaitCursor objWait = new CWaitCursor();
		try {
			//update data structures value for objxppanelln
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

	private void subInitAnalysisGraph()
	{
		//=====================================================================
		// Procedure Name        : subInitAnalysisGraph
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : Init. analysis graph
		//                           
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 15-Dec-2006
		// Revisions             : 1
		//=====================================================================
		//---To set the X-axis as Time axis and its default Min, Max & Step values.
		System.DateTime dtXMin;
		System.DateTime dtXMax;

		try {
			// cal. Analysis apram. of graph.
			Calculate_Analysis_Graph_Param(AASGraphAnalysis);

			AASGraphAnalysis.XAxisLabel = "TIME(seconds)";
			AASGraphAnalysis.XAxisType = AldysGraph.AxisType.Linear;
			AASGraphAnalysis.IsShowGrid = true;
			AASGraphAnalysis.Refresh();
			Application.DoEvents();

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

	private void InitAnalysis()
	{
		//=====================================================================
		// Procedure Name        : InitAnalysis
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : Init. analysis parameters
		//                           
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 15-Dec-2006
		// Revisions             : 1
		//=====================================================================
		//void	InitAnalyse(HWND hwnd,CURVEDATA 	*AnaGraph)
		//{
		//HWND hwnd1;
		// if (Method->Mode==MODE_UVABS){
		//	ShowWindow(GetDlgItem(hwnd,IDC_UVABS), SW_SHOW);
		//	ShowWindow(GetDlgItem(hwnd,IDC_GRAPH), SW_HIDE);
		//	ShowWindow(GetDlgItem(hwnd,IDC_SCALE), SW_HIDE);
		//	ShowWindow(GetDlgItem(hwnd,IDC_PGRAPH), SW_HIDE);
		//	ShowWindow(GetDlgItem(hwnd,IDC_HSXMIN), SW_HIDE);
		//	ShowWindow(GetDlgItem(hwnd,IDC_HSXMAX), SW_HIDE);
		//  }
		// else{
		//	ShowWindow(GetDlgItem(hwnd,IDC_UVABS), SW_HIDE);
		//	ShowWindow(GetDlgItem(hwnd,IDC_GRAPH), SW_SHOW);
		//	ShowWindow(GetDlgItem(hwnd,IDC_SCALE), SW_SHOW);
		//	ShowWindow(GetDlgItem(hwnd,IDC_PGRAPH), SW_SHOW);
		//	ShowWindow(GetDlgItem(hwnd,IDC_HSXMIN), SW_SHOW);
		//	ShowWindow(GetDlgItem(hwnd,IDC_HSXMAX), SW_SHOW);

		//	hwnd1=GetDlgItem(hwnd,IDC_GRAPH);
		//	if (hwnd1){
		//	 EnableWindow(hwnd1,TRUE);
		//	 GetWindowRect(hwnd1, &(AnaGraph->RC));
		//	 ShowWindow(hwnd1,SW_HIDE);
		//	 AnaGraph->RC.top -= 35; 	AnaGraph->RC.right-=30;
		//	 AnaGraph->RC.bottom-=40;
		//	}
		//            Else
		//	 SetRectEmpty(&AnaGraph->RC);
		//  if (Method->Mode==MODE_EMISSION){
		//		AnaGraph->Ymin=-1.0; AnaGraph->Ymax=100.0;
		//	 }
		//  else{
		//	AnaGraph->Ymin=-0.1; AnaGraph->Ymax=1.0;
		//	}
		//  AnaGraph->Xmin=0; AnaGraph->Xmax=10*10.0;
		//  Calculate_Analysis_Graph_Param(AnaGraph);
		// }
		//}
		try {
			switch (gobjNewMethod.OperationMode) {
				case EnumOperationMode.MODE_UVABS:
					//---Do not show graph
					lblUVAbsorbance.Visible = true;
					lblUVAbsorbance.Size = new Size(370, 87);
					lblUVAbsorbance.Location = new Point(136, 73);
					lblUVWavelength.Visible = true;
					lblUVWavelength.Size = new Size(370, 87);
					lblUVWavelength.Location = new Point(136, 188);
					AASGraphAnalysis.Visible = false;

					Application.DoEvents();
				default:
					AASGraphAnalysis.Visible = true;
					lblUVAbsorbance.Visible = false;
					lblUVWavelength.Visible = false;
					Application.DoEvents();

					if ((gobjNewMethod.OperationMode == EnumOperationMode.MODE_EMMISSION)) {
						//update AASGraph analysis scale values
						AASGraphAnalysis.YAxisMin = -10.0;
						AASGraphAnalysis.YAxisMax = 100.0;
						AASGraphAnalysis.YAxisStep = 20.0;
						AASGraphAnalysis.YAxisMinorStep = 5.0;

						AASGraphAnalysis.YAxisLabel = "EMISSION";
						//Changed by Saurabh "Energy" to "Emission"
						lblAbsorbanceMain.Text = "Emission : ";
						lblAverageAbsorbanceMain.Text = "Average Emission : ";
						lblCorrectedAbsorbanceMain.Text = "Corrected Emission : ";
					} else {
						//---changed by deepak on 29.04.07
						AASGraphAnalysis.YAxisMin = -0.2;
						AASGraphAnalysis.YAxisMax = 0.8;
						//AASGraphAnalysis.YAxisStep = 0.1
						//AASGraphAnalysis.YAxisMinorStep = 0.05
						AASGraphAnalysis.YAxisStep = 0.2;
						AASGraphAnalysis.YAxisMinorStep = 0.1;

						AASGraphAnalysis.YAxisLabel = "ABSORBANCE";
					}
					subInitAnalysisGraph();
			}

			//---Set Method Title
			txtMethod.Text = gobjNewMethod.MethodName;

			btnReadData.Enabled = false;

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

	private void Test(ref double dblX, ref double dblY)
	{
		//=====================================================================
		// Procedure Name        : Test
		// Parameters Passed     : dtX , dblY as Coordinate
		// Returns               : None
		// Purpose               : Test Analysis
		//                           
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 15-Dec-2006
		// Revisions             : 1
		//=====================================================================
		try {
			if ((dblX < 40)) {
				dblX = dblX + 5;
				dblY = 0.05 * dblX * dblX;
			} else if ((dblX < 50)) {
				dblX = dblX + 5;
				dblY = Math.Sqrt((dblY * dblY) - 1);
			} else {
				dblX = dblX + 5;
				dblY = dblY - 0.05 * dblY;
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

	private void Test_Time(ref System.DateTime dtXTime, ref double dblY)
	{
		//=====================================================================
		// Procedure Name        : Test_Time
		// Parameters Passed     : dtXTime as Time, dblY as y Coordinate
		// Returns               : None
		// Purpose               : Test Analysis 
		//                           
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 15-Dec-2006
		// Revisions             : 1
		//=====================================================================
		try {
			if ((dtXTime < AldysGraph.XDate.XLDateToDateTime(AASGraphAnalysis.XAxisMax))) {
				dtXTime = dtXTime.AddMinutes(1.0);
				Random objRnd = new Random();
				dblY = objRnd.NextDouble() * 100;
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

	private void ResetAnaMode(int intLampNumber)
	{
		//=====================================================================
		// Procedure Name        : ResetAnaMode
		// Parameters Passed     : intLampNumber
		// Returns               : None
		// Purpose               : Reset Analysis Mode
		//                           
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 15-Dec-2006
		// Revisions             : 1
		//=====================================================================
		//------------------------------------------------------------------------
		//void ResetAnaMode(int lampno )
		//{
		//INST_PAR	*Inst=NULL;
		//Inst =  GetInstData();
		//switch(Method->Mode){
		//	case MODE_AA:Inst->Lamp_par.lamp[lampno].mode=AA;break;
		//	case MODE_AABGC:Inst->Lamp_par.lamp[lampno].mode=AABGC;break;
		//	case MODE_EMISSION:Inst->Lamp_par.lamp[lampno].mode=EMISSION;break;
		//	case MODE_UVABS:Inst->Lamp_par.lamp[lampno].mode=MABS;break;
		//	case MODE_SPECT:if(GetInstrument() == AA202)
		//							Inst->Lamp_par.lamp[lampno].mode=AABGCSR;
		//	break;
		//}
		//}
		//------------------------------------------------------------------------

		//INST_PAR	*Inst=NULL;
		//Inst = GetInstData()

		//gobjInst = Nothing
		//Call funcInitInstrumentSettings()

		//---Get Lamp Index from Lamp Number
		try {
			intLampNumber -= 1;

			switch (gobjNewMethod.OperationMode) {
				case EnumOperationMode.MODE_AA:

					gobjInst.Lamp.LampParametersCollection(intLampNumber).Mode = EnumOperationMode.MODE_AA;
				case EnumOperationMode.MODE_AABGC:

					gobjInst.Lamp.LampParametersCollection(intLampNumber).Mode = EnumOperationMode.MODE_AABGC;
				case EnumOperationMode.MODE_EMMISSION:

					gobjInst.Lamp.LampParametersCollection(intLampNumber).Mode = EnumOperationMode.MODE_EMMISSION;
				case EnumOperationMode.MODE_UVABS:

					gobjInst.Lamp.LampParametersCollection(intLampNumber).Mode = EnumOperationMode.MODE_UVABS;
				case EnumOperationMode.MODE_SPECT:

					gobjInst.Lamp.LampParametersCollection(intLampNumber).Mode = EnumOperationMode.MODE_SPECT;
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

	private void Display_Analysis_Info()
	{
		//=====================================================================
		// Procedure Name        : Display_Analysis_Info
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : To display analysis information. 
		//                           
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 15-Dec-2006
		// Revisions             : 1
		//=====================================================================

		//****************************************************************************************
		//AAS 16-Bit Software Code
		//****************************************************************************************
		//void	Disp_Analysis_Info(HWND hwnd)
		//{
		//char		str[60]="";
		//int		i;

		// for(i=IDC_QSAMPID;i<=IDC_QCONC; i++)
		//	SetDlgItemText(hwnd,i, "");
		// if (SampType==BLANK){
		//	SetDlgItemText(hwnd,IDC_QSAMPID, "BLANK");
		//	SetDlgItemText(hwnd,IDC_QRPTNO, "1");
		//	SetDlgItemText(hwnd,IDC_QCORABS, "");
		//	SetDlgItemText(hwnd,IDC_QCONC, "");
		//  }
		// else if (SampType==STD){
		//	if (mobjCurrentStandard!=NULL){
		//	  sprintf(str, "%s",mobjCurrentStandard->Data.Std_Name);
		//	  SetDlgItemText(hwnd,IDC_QSAMPID, str);
		//	  sprintf(str, "%d",CurRepeat);
		//	  SetDlgItemText(hwnd,IDC_QRPTNO, str);
		//	  StoreResultAccurate(mobjCurrentStandard->Data.Conc, str,
		//			  Method->QuantData->Param.No_Decimals);
		//	  SetDlgItemText(hwnd,IDC_QCONC, str);
		//	 }
		//	}
		//  else if (SampType==SAMP){
		//	 if (mobjCurrentSample!=NULL){
		//	  sprintf(str, "%s",mobjCurrentSample->Data.Samp_Name);
		//	  SetDlgItemText(hwnd,IDC_QSAMPID, str);
		//	  sprintf(str, "%d",CurRepeat);
		//	  SetDlgItemText(hwnd,IDC_QRPTNO, str);
		//	  SetDlgItemText(hwnd,IDC_QCONC, "Unknown");
		//	 }
		//	}
		//}
		//****************************************************************************************
		try {
			// display analysis information dependingupon analysis type i.s. Bank/Std/Samp. 
			lblSampleID.Text = "";
			lblRepeatNo.Text = "";
			lblCorrectedAbsorbance.Text = "";
			lblConcentration.Text = "";
			//display analysis Info Sample type wise
			switch (SampleType) {
				case ClsAAS203.enumSampleType.BLANK:
					lblSampleID.Text = "BLANK";
					lblRepeatNo.Text = "1";
					lblCorrectedAbsorbance.Text = "";

					lblConcentration.Text = "";
				case ClsAAS203.enumSampleType.STANDARD:
					if (!IsNothing(mobjCurrentStandard)) {
						lblSampleID.Text = mobjCurrentStandard.StdName;
						lblRepeatNo.Text = CurRepeat;

						lblConcentration.Text = FormatNumber(mobjCurrentStandard.Concentration, gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfDecimalPlaces);

					}
				case ClsAAS203.enumSampleType.SAMPLE:
					if (!IsNothing(mobjCurrentSample)) {
						lblSampleID.Text = mobjCurrentSample.SampleName;
						lblRepeatNo.Text = CurRepeat;
						lblConcentration.Text = "Unknown";
					}
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

	private void DisplayRunNo()
	{
		//=====================================================================
		// Procedure Name        : DisplayRunNo
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : To display Run No on test object
		//                           
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 15-Dec-2006
		// Revisions             : 1
		//=====================================================================

		//void	DisplayRunNo(HWND hwnd)
		//{
		//char 	str[80]="";
		//  if (!Method->QuantData)
		//	 return;
		// if (Method->QuantData->Fname>0){
		//	sprintf(str,"%08.0f",Method->QuantData->Fname);
		//	SetWindowText(GetDlgItem(hwnd,IDC_TRUN), str);
		//  }
		//}

		string strRunNumber = "";

		try {
			// Set the Run number to the label
			if (!IsNothing(gobjNewMethod.QuantitativeDataCollection)) {
				if (((int)gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).RunNumber > 0)) {
					strRunNumber = Format((int)gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).RunNumber, "00000000");
					lblRunNumber.Text = strRunNumber;
				}
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

	private void Clear_All_Abs_Std(ref Method.clsAnalysisStdParametersCollection StdTop)
	{
		//=====================================================================
		// Procedure Name        : Clear_All_Abs_Std
		// Parameters Passed     : None
		// Returns               : None
		// Parameters Affected   : Method.clsAnalysisStdParametersCollection
		// Purpose               : Clear Std all Abs parameter
		//                           
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 15-Dec-2006
		// Revisions             : 1
		//=====================================================================

		//-------------------------
		//void	  S4FUNC	Clear_All_Abs_Std(STDDATA *StdTop)
		//{
		//STDDATA   *tempk=NULL;
		//ABSREPEATDATA	*rpt=NULL;

		// tempk =StdTop;
		// while(tempk!=NULL){
		//	 tempk->Data.Abs=(double) -1.0;
		//	 tempk=tempk->next;
		//  }
		////---------clr repeat    add by sss on dt 21/12/1999
		//tempk =StdTop;
		//while(tempk){
		//	if(tempk->Data.AbsRepeat){
		//		rpt = tempk->Data.AbsRepeat->RptDataTop;
		//		DeleteAllAbsRepeatNodes(&rpt);
		//		free(tempk->Data.AbsRepeat);
		//		tempk->Data.AbsRepeat = NULL;
		//	}
		//	tempk =  tempk->next;
		//};
		////------------------

		Method.clsAbsRepeat rpt;

		//While (tempk! = NULL){
		//	 tempk->Data.Abs= -1.0
		//	 tempk=tempk->next
		//}
		//tempk =StdTop;
		//while(tempk){
		//	if(tempk->Data.AbsRepeat){
		//		rpt = tempk->Data.AbsRepeat->RptDataTop;
		//		DeleteAllAbsRepeatNodes(&rpt);
		//		free(tempk->Data.AbsRepeat);
		//		tempk->Data.AbsRepeat = NULL;
		//	}
		//	tempk =  tempk->next;
		//};

		//Dim objIterator As IEnumerator
		int intCounter;

		try {
			//objIterator = StdTop.GetEnumerator()
			//objIterator.Reset()
			//While (objIterator.MoveNext)
			//    CType(objIterator.Current, Method.clsAnalysisStdParameters).Abs = -1.0
			//    'CType(objIterator.Current, Method.clsAnalysisStdParameters).AbsRepeat.AbsRepeatData.Clear()
			//End While

			// Clear all Std parameters (Abs) object
			for (intCounter = 0; intCounter <= StdTop.Count - 1; intCounter++) {
				StdTop.item(intCounter).Abs = -1.0;
				StdTop.item(intCounter).AbsRepeat.AbsRepeatData.Clear();
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

	private void Clear_All_Abs_Conc_Samp(ref Method.clsAnalysisSampleParametersCollection SampTop)
	{
		//=====================================================================
		// Procedure Name        : Clear_All_Abs_Conc_Samp
		// Parameters Passed     : SampTop of Method.clsAnalysisSampleParametersCollection data type object
		// Returns               : None
		// Purpose               : Clear Std all Abs and Conc. parameter 
		//                           
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 15-Dec-2006
		// Revisions             : 1
		//=====================================================================

		////-------------------
		//void     S4FUNC	Clear_All_Abs_Conc_Samp(SAMPDATA *SampTop)
		//{
		//SAMPDATA *tempk=NULL;
		//ABSREPEATDATA	*rpt=NULL;
		// tempk =SampTop;
		// while(tempk!=NULL){
		//	 tempk->Data.Abs=(double) -1.0;
		//	 tempk->Data.Conc=(double) 0.0;
		//	 tempk=tempk->next;
		//  }

		//tempk =SampTop;
		//while(tempk){
		//	if (tempk->Data.AbsRepeat){
		//		rpt = tempk->Data.AbsRepeat->RptDataTop;
		//		DeleteAllAbsRepeatNodes(&rpt);
		//		free(tempk->Data.AbsRepeat);
		//		tempk->Data.AbsRepeat = NULL;
		//	}
		//	tempk =  tempk->next;
		//};
		////------------

		//Dim objIterator As IEnumerator
		int intCounter;

		try {
			//'objIterator = SampTop.GetEnumerator()
			//'objIterator.Reset()
			//'While (objIterator.MoveNext)
			//'    CType(objIterator.Current, Method.clsAnalysisSampleParameters).Abs = -1.0
			//'    CType(objIterator.Current, Method.clsAnalysisSampleParameters).AbsRepeat.AbsRepeatData.Clear()
			//'End While
			// Clear all Std parameters (Cons) object
			for (intCounter = 0; intCounter <= SampTop.Count - 1; intCounter++) {
				SampTop.item(intCounter).Abs = -1.0;
				SampTop.item(intCounter).AbsRepeat.AbsRepeatData.Clear();
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

	private void CheckValidStdAbs()
	{
		//=====================================================================
		// Procedure Name        : CheckValidStdAbs
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : Set Validated value to the Std object parameter
		//                           
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 15-Dec-2006
		// Revisions             : 1
		//=====================================================================

		////----------------------
		//void		S4FUNC	CheckValidStdAbs()
		//{
		//STDDATA   *tempk=NULL;
		// if (!Method->QuantData)
		//	return;
		// tempk =Method->QuantData->StdTopData;
		// while(tempk!=NULL){
		//	tempk->Data.Used=FALSE;
		//	if (tempk->Data.Abs>0.0) ////-1.0)
		//	  tempk->Data.Used=TRUE;
		//	 tempk=tempk->next;
		//  }
		//}
		////-------------
		int intCount;

		try {
			//Set Validated value to the Std object of used parameter
			if (!IsNothing(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection)) {
				for (intCount = 0; intCount <= gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.Count - 1; intCount++) {
					gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount).Used = false;
					if (gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount).Abs > 0.0) {
						gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount).Used = true;
					}
				}
			}

		//If Not IsNothing(objCurStandard) Then
		//    objCurStandard.Used = False
		//    If objCurStandard.Abs > 0.0 Then
		//        objCurStandard.Used = True
		//    End If
		//End If

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

	private double GetRunNo(Method.clsMethod objMethod)
	{
		//=====================================================================
		// Procedure Name        : GetRunNo
		// Parameters Passed     : objMethod of Method.clsMethod data type object
		// Returns               : Double - Return the Run Number
		// Purpose               : Get Run No.
		//                           
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 15-Dec-2006
		// Revisions             : 1
		//=====================================================================
		////-------------------
		//double		S4FUNC	GetRunNo(METHOD *temp)
		//{
		//DATA4  	*aaresultdata=NULL;
		//INDEX4  	*aaresultidx=NULL;
		//double	fname=-1.0;
		//If (!temp) Then
		//   return fname;
		//If (!temp->QuantData)
		//   return fname;

		//If (!QDIopen("AARESULT",&aaresultdata, &aaresultidx))
		//{
		//   d4close_all(cb);
		//   return  FALSE;
		//}
		//If (d4reccount(aaresultdata) > 0) Then
		//   fname = Obtain_Next_Key(aaresultdata,"FNAME", FALSE);
		//Else
		//   fname=(double) 1.0;

		//temp->QuantData->Fname =fname;
		//d4close_all(cb);
		//return fname;
		//}
		////---------------------------
		//DATA4  	*aaresultdata=NULL;
		//INDEX4  	*aaresultidx=NULL;

		double dblNewRunNumber = -1.0;

		try {
			//validate method object
			if (IsNothing(objMethod)) {
				return dblNewRunNumber;
			}

			if (IsNothing(objMethod.QuantitativeDataCollection)) {
				return dblNewRunNumber;
			}

			//'If Not (QDIopen("AARESULT", aaresultdata, aaresultidx)) Then
			//'    d4close_all(cb)
			//'    Return -1.0
			//'End If
			//'If (d4reccount(aaresultdata) > 0) Then
			//'    fname = Obtain_Next_Key(aaresultdata, "FNAME", False)
			//'Else
			//'    fname = 1.0
			//'End If
			//d4close_all(cb)
			////----- Added by Sachin Dokhale on 25.05.07
			//dblNewRunNumber = gobjNewMethod.QuantitativeDataCollection.Count
			//gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).RunNumber = Format(dblNewRunNumber, "00000000")
			int intMethodCount;
			long lngRunCount;
			long lngTotalRunNumber = 0;
			//get max Run number
			if (!gobjMethodCollection == null) {
				if (gobjMethodCollection.Count > 0) {
					for (intMethodCount = 0; intMethodCount <= gobjMethodCollection.Count - 1; intMethodCount++) {
						if (!gobjMethodCollection(intMethodCount).QuantitativeDataCollection == null) {
							if (gobjMethodCollection(intMethodCount).QuantitativeDataCollection.Count > 0) {
								for (lngRunCount = 0; lngRunCount <= gobjMethodCollection(intMethodCount).QuantitativeDataCollection.Count - 1; lngRunCount++) {
									if ((long)gobjMethodCollection(intMethodCount).QuantitativeDataCollection(lngRunCount).RunNumber > lngTotalRunNumber) {
										lngTotalRunNumber = (long)gobjMethodCollection(intMethodCount).QuantitativeDataCollection(lngRunCount).RunNumber;
									}
								}
								//intTotalRunNumber = gobjMethodCollection(intMethodCount).QuantitativeDataCollection.Count
							}
						}
					}
				}
			}
			///'
			//add one to max run number 
			lngTotalRunNumber += 1;
			dblNewRunNumber = Format(lngTotalRunNumber, "00000000");
			gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).RunNumber = Format(lngTotalRunNumber, "00000000");
			mlngSelectedRunNumber = lngTotalRunNumber;
			return dblNewRunNumber;

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

	private void Aspirate()
	{
		//=====================================================================
		// Procedure Name        : Aspirate
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : Aspiration message for diff. type of sample
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 17-Jan-2007 03:25 pm
		// Revisions             : 2 by deepak on 09.09.08 for adding conc. in
		// braces in front of standard name
		//=====================================================================
		//void   Aspirate(HWND hwnd)        
		//{
		//char	*aspMsg=NULL;
		//char	strAspMsg1[]= "Aspirate";
		//char	strAspMsg2[]="Insert Cuvete";
		//char	str[180]="";

		//if ( Method->Mode==MODE_UVABS)
		//	aspMsg =strAspMsg2;
		//Else
		//   aspMsg =strAspMsg1;

		//if (SampType==BLANK)
		//{
		//	if(Autosampler && Started )
		//	{
		//       If (!PositionAutosampler(hwnd, Str)) Then
		//		Gerror_message_system("Autosampler connection Lost");
		//	}
		//	else 
		//		sprintf(str, "%s Blank and Click &READ or press <SPACEBAR>", aspMsg);
		//}        
		//else
		//{
		//	if (SampType==STD)
		//	{
		//       If (mobjCurrentStandard! = NULL) Then
		//		{        
		//			if ( Method->QuantData->Param.ConcRepeat>1)
		//			{
		//				if(Autosampler && Started)
		//				{
		//					sprintf(str,"%s %s (Rpt #%d)from Position %d ",aspMsg,mobjCurrentStandard->Data.Std_Name, CurRepeat,mobjCurrentStandard->Data.PosNo);
		//					strcpy(Aspiratemsg, str);
		//					SetAutoSampler(hwnd,mobjCurrentStandard->Data.PosNo,TRUE);
		//				}
		//               Else
		//				    sprintf(str, " %s %s (Rpt #%d) and Click &READ or press <SPACEBAR>", aspMsg,mobjCurrentStandard->Data.Std_Name, CurRepeat); 
		//			}
		//			else
		//			{
		//				if(Autosampler && Started)
		//				{
		//					sprintf(str,"%s %s from Position %d ",aspMsg,mobjCurrentStandard->Data.Std_Name,mobjCurrentStandard->Data.PosNo);
		//					strcpy(Aspiratemsg, str);
		//					SetAutoSampler(hwnd,mobjCurrentStandard->Data.PosNo,TRUE);
		//				}
		//               Else
		//				    sprintf(str, " %s %s  and Click &READ or press <SPACEBAR>", aspMsg, mobjCurrentStandard->Data.Std_Name ); 
		//			}
		//		}
		//	}
		//	else
		//	{
		//       If (mobjCurrentSample! = NULL) Then
		//		{
		//			if ( Method->QuantData->Param.Repeat>1 )
		//			{
		//				if(Autosampler && Started)
		//				{
		//					sprintf(str,"%s %s (Repeat #%d) from Position %d ",aspMsg,mobjCurrentSample->Data.Samp_Name, CurRepeat,mobjCurrentSample->Data.SampPosNo);
		//					strcpy(Aspiratemsg, str);
		//					SetAutoSampler(hwnd,mobjCurrentSample->Data.SampPosNo,TRUE);
		//				}
		//               Else
		//					sprintf(str, " %s %s (Repeat #%d) and Click &READ or press <SPACEBAR> ", aspMsg, mobjCurrentSample->Data.Samp_Name, CurRepeat); 
		//			}
		//			else
		//			{
		//				if(Autosampler && Started)
		//				{
		//					sprintf(str, " %s %s from Position %d", aspMsg,mobjCurrentSample->Data.Samp_Name,mobjCurrentSample->Data.SampPosNo);
		//					strcpy(Aspiratemsg, str);
		//					SetAutoSampler(hwnd,mobjCurrentSample->Data.SampPosNo,TRUE);
		//				}
		//               Else
		//				    sprintf(str, " %s %s and Click &READ or press <SPACE BAR>", aspMsg, mobjCurrentSample->Data.Samp_Name);
		//			}
		//		}
		//	}
		//}

		//If (!Autosampler) Then
		//   strcpy(Aspiratemsg, str);
		//Else
		//{
		//   If (Started) Then
		//	    strcpy(Aspiratemsg, str);
		//}

		//if(Autosampler && Started)
		//	SendMessage(hwnd, WM_COMMAND, IDC_QAREAD, 0L);
		//}



		//---CODE BY MANGESH 

		string aspMsg;
		double dblConc;
		try {
			// Aspirattion message when UV ABS Mdoe is selected
			if ((gobjNewMethod.OperationMode == EnumOperationMode.MODE_UVABS)) {
				aspMsg = "Insert Cuvete ";
			} else {
				aspMsg = "Aspirate ";
			}
			// Aspirattion message when Blank is inserted
			if ((SampleType == ClsAAS203.enumSampleType.BLANK)) {
				if ((mblnIsAutosampler & mblnIsAnalysisStarted)) {
					if (!(PositionAutosampler())) {
						//gobjMessageAdapter.ShowMessage("Autosampler connection Lost", "Autosampler", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage)
						gobjMessageAdapter.ShowMessage(constAutoSamplerConnLost);
					}
				} else {
					mstrAspirationMessage = aspMsg + "Blank and Click READ DATA or press <SPACEBAR>";
					////---- Added by Sachin Dokhale
					mobjBgMsgAspirate.AspirationMessage = mstrAspirationMessage;
					////-----
					//---Saurabh---20.06.07
					if (btnReadData.Enabled == true) {
						btnReadData.Focus();
						btnReadData.Refresh();
					}
					//---Saurabh
				}
				//BlankAlert()  '10.09.08
				gintAspirationType = 1;
			} else {
				// Aspirattion message when Standard is used
				if ((SampleType == ClsAAS203.enumSampleType.STANDARD)) {
					if (!IsNothing(mobjCurrentStandard)) {
						//( Method->QuantData->Param.ConcRepeat>1)
						if ((gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfStdRepeats) > 1) {
							if ((mblnIsAutosampler & mblnIsAnalysisStarted)) {
								//+ Commented by Amit 26/03/09 ################################################
								//mstrAspirationMessage = aspMsg & mobjCurrentStandard.StdName & " [" & FormatNumber(mobjCurrentStandard.Concentration, 2) & " ppm" & "] " & " (Repeat #" & CurRepeat & ") from Position " & mobjCurrentStandard.PositionNumber
								//- Commented by Amit 26/03/09 ################################################

								//+ Added by Amit 26/03/09 ################################################
								if (gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.Unit == enumUnit.PPB) {
									mstrAspirationMessage = aspMsg + mobjCurrentStandard.StdName + " [" + FormatNumber(mobjCurrentStandard.Concentration, CONST_Format_Value_Concentration_PPB) + Space(1) + Const_PPB + "] " + " (Repeat #" + CurRepeat + ") from Position " + mobjCurrentStandard.PositionNumber;
								} else {
									mstrAspirationMessage = aspMsg + mobjCurrentStandard.StdName + " [" + FormatNumber(mobjCurrentStandard.Concentration, CONST_Format_Value_Concentration) + Space(1) + Const_PPM + "] " + " (Repeat #" + CurRepeat + ") from Position " + mobjCurrentStandard.PositionNumber;
								}
								//- Added by Amit 26/03/09 ################################################

								mobjBgMsgAspirate.AspirationMessage = mstrAspirationMessage;
								SetAutoSampler(mobjCurrentStandard.PositionNumber, true);
							} else {
								//+ Commented by Amit 26/03/09 ################################################
								//mstrAspirationMessage = aspMsg & mobjCurrentStandard.StdName & " [" & FormatNumber(mobjCurrentStandard.Concentration, 2) & " ppm" & "] " & "(Repeat #" & CurRepeat & ") and Click READ DATA or press <SPACEBAR>"
								//- Commented by Amit 26/03/09 ################################################

								//+ Added by Amit 26/03/09 ################################################
								if (gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.Unit == enumUnit.PPB) {
									mstrAspirationMessage = aspMsg + mobjCurrentStandard.StdName + " [" + FormatNumber(mobjCurrentStandard.Concentration, CONST_Format_Value_Concentration_PPB) + Space(1) + Const_PPB + "] " + "(Repeat #" + CurRepeat + ") and Click READ DATA or press <SPACEBAR>";
								} else {
									mstrAspirationMessage = aspMsg + mobjCurrentStandard.StdName + " [" + FormatNumber(mobjCurrentStandard.Concentration, CONST_Format_Value_Concentration) + Space(1) + Const_PPM + "] " + "(Repeat #" + CurRepeat + ") and Click READ DATA or press <SPACEBAR>";
								}
								//- Added by Amit 26/03/09 ################################################
								mobjBgMsgAspirate.AspirationMessage = mstrAspirationMessage;
							}
						} else {
							if ((mblnIsAutosampler & mblnIsAnalysisStarted)) {
								//+ Commented by Amit 26/03/09 ################################################
								//mstrAspirationMessage = aspMsg & mobjCurrentStandard.StdName & " [" & FormatNumber(mobjCurrentStandard.Concentration, 2) & " ppm" & "] " & " from Position " & mobjCurrentStandard.PositionNumber
								//- Commented by Amit 26/03/09 ################################################

								//+ Added by Amit 26/03/09 ################################################
								if (gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.Unit == enumUnit.PPB) {
									mstrAspirationMessage = aspMsg + mobjCurrentStandard.StdName + " [" + FormatNumber(mobjCurrentStandard.Concentration, CONST_Format_Value_Concentration_PPB) + Space(1) + Const_PPB + "] " + " from Position " + mobjCurrentStandard.PositionNumber;
								} else {
									mstrAspirationMessage = aspMsg + mobjCurrentStandard.StdName + " [" + FormatNumber(mobjCurrentStandard.Concentration, CONST_Format_Value_Concentration) + Space(1) + Const_PPM + "] " + " from Position " + mobjCurrentStandard.PositionNumber;
								}
								//- Added by Amit 26/03/09 ################################################
								mobjBgMsgAspirate.AspirationMessage = mstrAspirationMessage;
								SetAutoSampler(mobjCurrentStandard.PositionNumber, true);
							} else {
								//+ Commented by Amit 26/03/09 ################################################
								//mstrAspirationMessage = aspMsg & mobjCurrentStandard.StdName & " [" & FormatNumber(mobjCurrentStandard.Concentration, 2) & " ppm" & "] " & " and Click READ DATA or press <SPACEBAR>"
								//- Commented by Amit 26/03/09 ################################################

								//+ Added by Amit 26/03/09 ################################################
								if (gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.Unit == enumUnit.PPB) {
									mstrAspirationMessage = aspMsg + mobjCurrentStandard.StdName + " [" + FormatNumber(mobjCurrentStandard.Concentration, CONST_Format_Value_Concentration_PPB) + Space(1) + Const_PPB + "] " + " and Click READ DATA or press <SPACEBAR>";
								} else {
									mstrAspirationMessage = aspMsg + mobjCurrentStandard.StdName + " [" + FormatNumber(mobjCurrentStandard.Concentration, CONST_Format_Value_Concentration) + Space(1) + Const_PPM + "] " + " and Click READ DATA or press <SPACEBAR>";
								}
								//- Added by Amit 26/03/09 ################################################
								mobjBgMsgAspirate.AspirationMessage = mstrAspirationMessage;
							}
						}
						//StandardAlert()  '10.09.08
						gintAspirationType = 2;
					}
				} else {
					// Aspirattion message when sample is used
					if (!IsNothing(mobjCurrentSample)) {
						if ((gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfSampleRepeats > 1)) {
							if ((mblnIsAutosampler & mblnIsAnalysisStarted)) {
								mstrAspirationMessage = aspMsg + mobjCurrentSample.SampleName + " (Repeat #" + CurRepeat + ") from Position " + mobjCurrentSample.SampPosNumber;
								mobjBgMsgAspirate.AspirationMessage = mstrAspirationMessage;
								SetAutoSampler(mobjCurrentSample.SampPosNumber, true);
							} else {
								mstrAspirationMessage = aspMsg + mobjCurrentSample.SampleName + " (Repeat #" + CurRepeat + ") and Click READ DATA or press <SPACEBAR> ";
								mobjBgMsgAspirate.AspirationMessage = mstrAspirationMessage;
							}
						} else {
							if ((mblnIsAutosampler & mblnIsAnalysisStarted)) {
								mstrAspirationMessage = aspMsg + mobjCurrentSample.SampleName + " from Position " + mobjCurrentSample.SampPosNumber;
								mobjBgMsgAspirate.AspirationMessage = mstrAspirationMessage;
								SetAutoSampler(mobjCurrentSample.SampPosNumber, true);
							} else {
								mstrAspirationMessage = aspMsg + mobjCurrentSample.SampleName + " and Click READ DATA or press <SPACEBAR>";
								mobjBgMsgAspirate.AspirationMessage = mstrAspirationMessage;
							}
						}
						//SampleAlert()  '10.09.08
						gintAspirationType = 3;
					}
				}
			}

			if (btnReadData.Enabled) {
				btnReadData.Focus();
				btnReadData.Refresh();
			}
		////----- Commented by Sachin Dokhale
		//If (mblnIsAutosampler And mblnIsAnalysisStarted) Then
		//    'SendMessage(hwnd, WM_COMMAND, IDC_QAREAD, 0L)
		//    Call ReadData_Click(btnReadData, EventArgs.Empty)
		//End If
		////-----
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

	private bool SetAutoSampler(int pos, bool flag)
	{
		//=====================================================================
		// Procedure Name        : SetAutoSampler
		// Parameters Passed     : pos as position is integer, flag is use to Set or Reset the position
		// Returns               : None
		// Purpose               : Set Auto Sampler
		//                           
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 15-Dec-2006
		// Revisions             : 1
		//=====================================================================
		//---FUNCTION TEMPORARILY COMMENTED AS NO AUTOSAMPLER
		//Return False'by Pankaj for autosampler on 10Sep 07
		//---FUNCTION TEMPORARILY COMMENTED AS NO AUTOSAMPLER


		//BOOL		SetAutoSampler(HWND hpar, int pos, BOOL flag)
		//{
		//char	str[40];
		//        If (!IsSamplerConnected()) Then
		//  return FALSE;

		// if (hpar) EnableWindow(hpar, FALSE);
		//if (flag){
		//	 sprintf(str,"Sampler => %d        ", pos);
		//	 //PrintmsgOnWvAbsTag(str);
		//	 ASamplerStart(pos,hpar);
		//	}
		//else{
		//  sprintf(str, "Resetting Sampler    ");
		//  //PrintmsgOnWvAbsTag(str);
		//  ASamplerEnd(hpar);
		// }
		//// }
		//// SendMessage(hpar, WM_COMMAND, IDC_QAREAD, 0L);
		// if (hpar) EnableWindow(hpar, TRUE);
		//return TRUE;
		//}

		//-------CODE BY MANGESH 
		string str;

		try {
			// Set Autosampler messages
			Application.DoEvents();
			//by Pankaj
			//If Not (gstructAutoSampler.blnCommunication = False) Then
			//check communication for autosampler
			//Modified by pankaj for autosampler
			if ((gstructAutoSampler.blnCommunication == false)) {
				SetAutoSampler = false;
				return false;
			}

			if ((flag)) {
				str = "Sampler => " + pos + "    ";
				lblAspirationMessage.Text = str;
				//get message text
				gfuncAutoSamplerStartStatus(pos, lblAspirationMessage, gstructAutoSampler);
				Application.DoEvents();
				//by Pankaj
			} else {
				str = "Resetting Sampler    ";
				lblAspirationMessage.Text = str;
				gfuncAutoSamplerEndStatus(lblAspirationMessage, gstructAutoSampler);
				Application.DoEvents();
				//by Pankaj
			}
			SetAutoSampler = true;
			Application.DoEvents();
			//by Pankaj
			return true;

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

	private bool PositionAutosampler()
	{
		//=====================================================================
		// Procedure Name        : PositionAutosampler
		// Parameters Passed     : None
		// Returns               : True if success
		// Purpose               : Position to Auto Sampler
		//                           
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 15-Dec-2006
		// Revisions             : 1
		//=====================================================================
		//---FUNCTION TEMPORARILY COMMENTED AS NO AUTOSAMPLER
		//Return False 'by Pankaj for autosampler on 10Sep 07
		//---FUNCTION TEMPORARILY COMMENTED AS NO AUTOSAMPLER


		//BOOL PositionAutosampler(HWND hwnd,char *str)
		//{
		//   int  WASH_TIME=20;
		//	GetProfileStringFromIniFile("AutoSampler", "Wash Time (sec)", "10",str, "asampler.ini");
		//	trim(ltrim(str)); 
		//   WASH_TIME=atoi(str);
		//   If (!IsSamplerConnected()) Then
		//	    return FALSE;
		//	strcpy(str,"Positioning Autosampler for Aspirating Blank");
		//   If (Started) Then
		//	    strcpy(Aspiratemsg, str);
		//	if(ASampler_GoToYhome(0))    
		//	{
		//	    if(ASampler_ProbeDown()){
		//		    sprintf(str,"Aspirating Blank wait for wash time %d sec",WASH_TIME);
		//           If (Started) Then
		//		        strcpy(Aspiratemsg, str);
		//		    ASampler_PumpON();
		//		    WaitForSec(WASH_TIME); 
		//		    ASampler_PumpOFF();
		//		 }
		//        Else
		//		    Gerror_message_system("Error in placing probe down");
		//	}
		//	else
		//	    Gerror_message_system("Error in positioning Autosampler");
		//	strcpy(str,"");
		//	return TRUE ;
		//}


		int WASH_TIME = 20;
		string strTemp = "";

		try {
			// Set wash time from ini setting
			strTemp = gFuncGetFromINI(CONST_Section_AutoSampler, CONST_Key_WashTime, "10", CONST_AutoSampler_INI_FileName);
			WASH_TIME = Val(Trim(strTemp));

			//---TEMPORARILY COMMENTED
			//If Not (IsSamplerConnected()) Then
			//    Return False
			//End If
			//---TEMPORARILY COMMENTED

			if ((mblnIsAnalysisStarted)) {
				mstrAspirationMessage = "Positioning Autosampler for Aspirating Blank";
				lblAspirationMessage.Text = mstrAspirationMessage;
				//by PAnkaj on 3 Oct 07
				mobjBgMsgAspirate.AspirationMessage = mstrAspirationMessage;
				Application.DoEvents();
				//by Pankaj on 3 Oct 07 
			}

			//---TEMPORARILY COMMENTED
			//If (ASampler_GoToYhome(0)) Then
			//    If (ASampler_ProbeDown()) Then
			//        If (mblnIsAnalysisStarted) Then
			//            mstrAspirationMessage = "Aspirating Blank wait for wash time " & WASH_TIME & " sec"
			//        End If
			//        ASampler_PumpON()
			//        WaitForSec(WASH_TIME)
			//        ASampler_PumpOFF()
			//    Else
			//        MessageBox.Show("Error in placing probe down")
			//    End If
			//Else
			//    MessageBox.Show("Error in positioning Autosampler")
			//End If
			//---TEMPORARILY COMMENTED
			// position to autosampler
			// Set Home position
			if ((gobjCommProtocol.funcAutoSamplerHome())) {
				// Set probe down for Wash
				if (gobjCommProtocol.funcAutoSamplerProbeDown()) {
					if ((mblnIsAnalysisStarted)) {
						mstrAspirationMessage = "Aspirating Blank wait for wash time " + WASH_TIME + " sec";
						Application.DoEvents();
						//by Pankaj on 3 Oct 07
					}
					// Set pump On  for wash
					gobjCommProtocol.funcAutoSamplerPumpON();
					//ASampler_PumpON()
					//WaitForSec(WASH_TIME)
					// Delay for wash time
					//Call gobjCommProtocol.mobjCommdll.subTime_Delay(gstructAutoSampler.intWashTime * 1000)
					gobjCommProtocol.mobjCommdllAutoSampler.subTime_Delay(gstructAutoSampler.intWashTime * 1000);
					//added by pankaj on 25 Mar 08
					// Set pump off
					gobjCommProtocol.funcAutoSamplerPumpOFF();
				//ASampler_PumpOFF()
				} else {
					gobjMessageAdapter.ShowMessage("Error in placing probe down", "AutoSampler", MessageHandler.clsMessageHandler.enumMessageType.ErrorMessage);
					// by Pankaj on 29 Nov 07
					//MessageBox.Show("Error in placing probe down")
				}
			} else {
				gobjMessageAdapter.ShowMessage("Error in positioning Autosampler", "AutoSampler", MessageHandler.clsMessageHandler.enumMessageType.ErrorMessage);
				//by pankaj on 29 Nov 07
				//MessageBox.Show("Error in positioning Autosampler")
			}
			Application.DoEvents();
			//by Pankaj on 3 Oct 07
			return true;
		//Application.DoEvents()
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

	private void SaveRawDataFile()
	{
		//=====================================================================
		// Procedure Name        : SaveRawDataFile
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : To save raw data for current run number.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 17-Jan-2007 03:25 pm
		// Revisions             : 1
		//=====================================================================
		//void	SaveRawDataFile(void)
		//{
		//char	fname[128]="";
		//char	rsultfname[80]="";
		// if (Method->QuantData && Method->QuantData->Fname>0){
		//	 GetRawDataDirectory(fname);
		//	 sprintf(rsultfname,"Saving %08.0f.dat",Method->QuantData->Fname );
		//	 SetShortHelp(rsultfname, TRUE);
		//	 sprintf(rsultfname,"%08.0f.dat",Method->QuantData->Fname );
		//	 strcat(fname, rsultfname);
		//	 RawDataSave(fname);
		//	 SetShortHelp("", TRUE);
		//	}
		//}


		//CODE BY MANGESH 

		string fname = "";
		string rsultfname = "";

		try {
			// check Methods object for data present
			if ((!IsNothing(gobjNewMethod) & (int)gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).RunNumber > 0)) {
				//'rsultfname = "Saving " & gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).RunNumber & ".dat"
				//'rsultfname = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).RunNumber & ".dat"
				//'fname = rsultfname
				//'Call RawDataSave(fname)
				// store raw data into analysis data object
				gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisRawData = mobjAnalysisRawData;
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

	//Private Function CheckValidStdAbsEntry(ByVal objStandardData As Method.clsAnalysisStdParametersCollection) As Boolean
	//    'BOOL CheckValidStdAbsEntry( STDDATA *std) // this fn added by sss for checking the valid std used or not dt 30/11/2K
	//    '{
	//    'double abs=0.0;
	//    'BOOL   flag = TRUE;
	//    'if(std){
	//    '	if(std->Data.Used==1){
	//    '		abs = std->Data.Abs;
	//    '		std = std=std->next;
	//    '	}
	//    '}
	//    'while(std){
	//    '	  if(std->Data.Used==1){
	//    '		  if( std->Data.Abs <= abs ){
	//    '				flag = FALSE;
	//    '				Gerror_message_new("Abs of the standard is less than or equal to the previous standard", "Standards");
	//    '				return flag;
	//    '		  }
	//    '		  abs = std->Data.Abs;
	//    '	  }
	//    '	  std=std->next;
	//    '}
	//    'return flag;
	//    '}

	//    '*****************************
	//    '---CODE BY MANGESH
	//    '*****************************
	//    Dim abs As Double = 0.0
	//    Dim flag As Boolean = True
	//    Dim intCounter As Integer

	//    Try
	//        For intCounter = 0 To objStandardData.Count - 1
	//            If (objStandardData(intCounter).Used = True) Then
	//                If (objStandardData(intCounter).Abs <= abs) Then
	//                    flag = False
	//                    Call gobjMessageAdapter.ShowMessage("Abs of the standard is less than or equal to the previous standard", "Standards", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage)
	//                    Call Application.DoEvents()
	//                    Return False
	//                End If
	//                abs = objStandardData(intCounter).Abs
	//            End If
	//        Next

	//        Return flag

	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        'Error Handling and logging
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = ex.Message
	//        gobjErrorHandler.WriteErrorLog(ex)
	//        '---------------------------------------------------------
	//    Finally
	//        '---------------------------------------------------------
	//        'Writing Execution log
	//        If CONST_CREATE_EXECUTION_LOG = 1 Then
	//            gobjErrorHandler.WriteExecutionLog()
	//        End If
	//        '---------------------------------------------------------
	//    End Try
	//End Function

	//Private Function CheckValidSampAbsEntry(ByVal objSampleData As Method.clsAnalysisSampleParametersCollection, ByVal dblSampConc As Double) As Boolean
	//    'BOOL CheckValidSampAbsEntry( STDDATA *std,double sampconc) // this fn added by sss for checking the valid samp used or not dt 26/12/2K
	//    '{
	//    'double abs=0.0;
	//    'BOOL   flag = TRUE;
	//    'abs=GetMaxStdAbs(std);
	//    '//if((abs+abs*0.05) < sampconc)
	//    '        If ((abs) < sampconc) Then
	//    '	flag = FALSE;
	//    'return flag;
	//    '}

	//    '******************
	//    '---CODE BY MANGESH 
	//    '******************
	//    Dim abs As Double = 0.0
	//    Dim flag As Boolean = True

	//    Try
	//        abs = GetMaxStdAbs(objSampleData)

	//        If ((abs) < dblSampConc) Then
	//            flag = False
	//        End If

	//        Return flag

	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        'Error Handling and logging
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = ex.Message
	//        gobjErrorHandler.WriteErrorLog(ex)
	//        '---------------------------------------------------------
	//    Finally
	//        '---------------------------------------------------------
	//        'Writing Execution log
	//        If CONST_CREATE_EXECUTION_LOG = 1 Then
	//            gobjErrorHandler.WriteExecutionLog()
	//        End If
	//        '---------------------------------------------------------
	//    End Try
	//End Function

	//Private Function GetMaxStdAbs(ByVal objSampleData As Method.clsAnalysisSampleParametersCollection) As Double
	//    'double GetMaxStdAbs(STDDATA *std)
	//    '{
	//    'double Abs=0.0;
	//    'while(std){
	//    '	  if(std->Data.Used==1){
	//    '		  if( std->Data.Abs >= Abs )
	//    '				Abs = std->Data.Abs;
	//    '	  }
	//    '	  std=std->next;
	//    '}
	//    'return Abs;
	//    '}

	//    '********************
	//    '---CODE BY MANGESH 
	//    '********************
	//    Dim dblMaxAbs As Double
	//    Dim intCounter As Integer

	//    Try
	//        dblMaxAbs = 0.0

	//        For intCounter = 0 To objSampleData.Count - 1
	//            If (objSampleData.item(intCounter).Used = True) Then
	//                If (objSampleData.item(intCounter).Abs >= dblMaxAbs) Then
	//                    dblMaxAbs = objSampleData.item(intCounter).Abs
	//                End If
	//            End If
	//        Next

	//        Return dblMaxAbs

	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        'Error Handling and logging
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = ex.Message
	//        gobjErrorHandler.WriteErrorLog(ex)
	//        '---------------------------------------------------------
	//    Finally
	//        '---------------------------------------------------------
	//        'Writing Execution log
	//        If CONST_CREATE_EXECUTION_LOG = 1 Then
	//            gobjErrorHandler.WriteExecutionLog()
	//        End If
	//        '---------------------------------------------------------
	//    End Try
	//End Function

	private double StoreCalculateDisplayQuantValue()
	{
		//=====================================================================
		// Procedure Name        : StoreCalculateDisplayQuantValue
		// Parameters Passed     : None
		// Returns               : bool 
		// Purpose               : Calculate and display of quant. analysis data.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 17-Jan-2007 03:25 pm
		// Revisions             : 1
		//=====================================================================

		//double StoreCalculateDisplayQuantValue(HWND hwnd)
		//{
		//char	str[40]="";
		//double	abs=0.0;
		//double	abs1=0.0;
		//static	STDDATA	*nCurStd=NULL;
		//static	SAMPDATA	*nCurSamp=NULL;
		//static	double	lblank = (double) 0.0;
		//static	int	nSampType = -1 ;;

		//if(mobjCurrentStandard==Method->QuantData->StdTopData && CurRepeat==1)
		//{
		//   nCurStd=NULL;
		//	nCurSamp=NULL;
		//	lblank=(double) 0.0;
		//	nSampType=-1;;
		//}

		//if (Method->QuantData->Param.Meas_Mode==INTEGRATE)
		//{
		//   abs = GetAvgValOfCurAnalysis();
		//	abs = GetValConvertedTo(abs, Method->Mode);
		//}
		//else if (Method->QuantData->Param.Meas_Mode==PKAREA)
		//{
		//   abs = GetPeakAreaOfCurAnalysis();
		//	abs = GetValConvertedTo(abs, Method->Mode);
		//}
		//else if (Method->QuantData->Param.Meas_Mode==PKHEIGHT)
		//{
		//   abs = GetPeakHeightOfCurAnalysis();
		//	abs = GetValConvertedTo(abs, Method->Mode);
		//}

		//if (SampType == BLANK)
		//{
		//   BlankAbs = abs;
		//	GetValInString(abs, str, Method->Mode);
		//	SetDlgItemText(hwnd,IDC_QAVABS, str);
		//	SetDlgItemText(hwnd,IDC_QCORABS, "");
		//	SetDlgItemText(hwnd,IDC_QCONC, "");

		//   if (GetBlankCalType())
		//   {
		//	    BlankAbs = (lblank + BlankAbs)/2.0;
		//		if (nSampType==STD && nCurStd!=NULL)
		//       {
		//		    abs =nCurStd->Data.Abs;
		//			sprintf(str, "%s",nCurStd->Data.Std_Name);
		//	    }
		//		if (nSampType==SAMP&& nCurSamp!=NULL)
		//       {
		//		    abs =nCurSamp->Data.Abs;
		//			sprintf(str, "%s",nCurSamp->Data.Samp_Name);
		//		}
		//		SetDlgItemText(hwnd,IDC_QSAMPID, str);
		//		abs1 = StoreCalculateStdSampDisplayQuantValue(hwnd, nSampType, &nCurStd, &nCurSamp, abs);

		//		if (mobjCurrentStandard==NULL && mobjCurrentSample ==Method->QuantData->SampTopData)
		//			 Create_Standard_Sample_Curve(hwnd,FALSE);
		//   }
		//}
		//else
		//{
		//   If (!GetBlankCalType()) Then
		//	    abs1=StoreCalculateStdSampDisplayQuantValue(hwnd, SampType, &mobjCurrentStandard, &mobjCurrentSample, abs);
		//   else
		//   {
		//       if (SampType==STD && mobjCurrentStandard!=NULL)
		//		    mobjCurrentStandard->Data.Abs=abs;

		//	    if (SampType==SAMP&& mobjCurrentSample!=NULL)
		//		    mobjCurrentSample->Data.Abs=abs;

		//		 GetValInString(abs, str, Method->Mode);
		//		 SetDlgItemText(hwnd,IDC_QAVABS, str);
		//		 SetDlgItemText(hwnd,IDC_QCORABS, "");
		//		 nCurStd=mobjCurrentStandard;
		//		 nCurSamp=mobjCurrentSample;
		//		 nSampType = SampType;
		//		 lblank = BlankAbs;
		//	}
		//}
		//return abs1;
		//}


		//---CODE BY MANGESH 

		string strSampleName = "";
		double abs = 0.0;
		double abs1 = 0.0;

		static Method.clsAnalysisStdParameters nCurStd;
		static Method.clsAnalysisSampleParameters nCurSamp;
		static double lblank = 0.0;
		static ClsAAS203.enumSampleType nSampType = -1;

		try {
			if ((object.ReferenceEquals(mobjCurrentStandard, gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(0)) & CurRepeat == 1)) {
				nCurStd = null;
				nCurSamp = null;
				lblank = 0.0;
				nSampType = -1;
			}

			if ((gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.MeasurementMode == enumMeasurementMode.Integrate)) {
				//---Get Average of all readings of clsRawData 
				abs = GetAvgValOfCurAnalysis();

			//---Later call this method instead of above function.
			//abs = GetAvgValOfAnalysis( .item(0) )
			//---Later on remove this comment

			} else if ((gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.MeasurementMode == enumMeasurementMode.PeakArea)) {
				//---Returns ZERO 
				abs = GetPeakAreaOfCurAnalysis();

			} else if ((gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.MeasurementMode == enumMeasurementMode.PeakHeight)) {
				//---Returns ZERO 
				abs = GetPeakHeightOfCurAnalysis();

			}

			if ((SampleType == ClsAAS203.enumSampleType.BLANK)) {
				mdblBlankAbsorbance = abs;

				//Saurabh 05 June 2007
				//lblAverageAbsorbance.Text = FormatNumber(abs, gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfDecimalPlaces)
				//lblAverageAbsorbance.Text = FormatNumber(abs, 3)   'Commented & Added by Saurabh 01.08.07
				if (gobjNewMethod.OperationMode == EnumOperationMode.MODE_EMMISSION) {
					lblAverageAbsorbance.Text = FormatNumber(abs, 1);
				} else {
					lblAverageAbsorbance.Text = FormatNumber(abs, 3);
				}
				//Saurabh 05 June 2007

				lblCorrectedAbsorbance.Text = "";
				lblConcentration.Text = "";

				if ((gstructSettings.BlankCalculation)) {
					mdblBlankAbsorbance = (lblank + mdblBlankAbsorbance) / 2.0;

					if (nSampType == ClsAAS203.enumSampleType.STANDARD & (!IsNothing(nCurStd))) {
						abs = nCurStd.Abs;
						strSampleName = nCurStd.StdName;
					}

					if (nSampType == ClsAAS203.enumSampleType.SAMPLE & (!IsNothing(nCurSamp))) {
						abs = nCurSamp.Abs;
						strSampleName = nCurSamp.SampleName;
					}
					lblSampleID.Text = strSampleName;

					abs1 = StoreCalculateStdSampDisplayQuantValue(nSampType, nCurStd, nCurSamp, abs);

					//if (mobjCurrentStandard==NULL && mobjCurrentSample == Method->QuantData->SampTopData)
					//   Create_Standard_Sample_Curve(hwnd,FALSE);
					if ((IsNothing(mobjCurrentStandard) & object.ReferenceEquals(mobjCurrentSample, gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(0)))) {
						gobjclsStandardGraph.Create_Standard_Sample_Curve(false, true, 0, 0, gobjNewMethod);
					}
				}
			} else {
				if (!(gstructSettings.BlankCalculation)) {
					abs1 = StoreCalculateStdSampDisplayQuantValue(SampleType, mobjCurrentStandard, mobjCurrentSample, abs);
					if (!mobjCurrentStandard == null) {
						//mobjLastStandardData = mobjCurrentStandard.Clone
						mobjLastStandardData = mobjCurrentStandard;
					} else {
						mobjLastStandardData = null;
					}
					if (!mobjCurrentSample == null) {
						//mobjLastSampleData = mobjCurrentSample.Clone
						mobjLastSampleData = mobjCurrentSample;
					} else {
						mobjLastSampleData = null;
					}
				} else {
					if ((SampleType == ClsAAS203.enumSampleType.STANDARD) & !IsNothing(mobjCurrentStandard)) {
						mobjCurrentStandard.Abs = abs;
					}

					if ((SampleType == ClsAAS203.enumSampleType.SAMPLE & !IsNothing(mobjCurrentSample))) {
						mobjCurrentSample.Abs = abs;
					}

					//Saurabh 05 June 2007
					//lblAverageAbsorbance.Text = FormatNumber(abs, gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfDecimalPlaces)
					//lblAverageAbsorbance.Text = FormatNumber(abs, 3)   'Commented & Added by Saurabh 01.08.07
					if (gobjNewMethod.OperationMode == EnumOperationMode.MODE_EMMISSION) {
						lblAverageAbsorbance.Text = FormatNumber(abs, 1);
					} else {
						lblAverageAbsorbance.Text = FormatNumber(abs, 3);
					}
					//Saurabh 05 June 2007

					lblCorrectedAbsorbance.Text = "";
					nCurStd = mobjCurrentStandard;
					nCurSamp = mobjCurrentSample;
					nSampType = SampleType;
					lblank = mdblBlankAbsorbance;
					if (!mobjCurrentStandard == null) {
						mobjLastStandardData = mobjCurrentStandard;
					} else {
						mobjLastStandardData = null;
					}
					if (!mobjCurrentSample == null) {
						mobjLastSampleData = mobjCurrentSample;
					} else {
						mobjLastSampleData = null;
					}
				}

			}

			return abs1;

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

	private bool RawDataSave(string strFullFileName)
	{
		//=====================================================================
		// Procedure Name        : RawDataSave
		// Parameters Passed     : strFullFileName as String 
		// Returns               : bool True if success
		// Purpose               : To Save Quant Data into file system
		//                           
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 15-Dec-2006
		// Revisions             : 1
		//=====================================================================
		//RAW_DATA 		*tempk=NULL;
		//RAW_DATA_LINKS *tempk1=NULL;
		//FILE *fp;

		Analysis.clsRawDataReadings objRawDataReadings;
		int intCount;
		int intReadingCounter;
		IO.FileStream fs;
		IO.StreamWriter sw;

		bool blnIsBlank;
		bool blnIsStandard;
		bool blnIsSample;
		int intPrevSampleID;
		int intSampleID;
		string strPath = "";
		try {
			//---05.12.07
			strPath = Application.StartupPath + "\\" + strFullFileName;
			strFullFileName = strPath;

			if (IsNothing(mobjAnalysisRawData)) {
				return false;
			}
			//To Save Quant Data into text file format

			if (IO.File.Exists(strFullFileName))
				IO.File.Delete(strFullFileName);

			fs = new IO.FileStream(strFullFileName, IO.FileMode.OpenOrCreate);
			sw = new IO.StreamWriter(fs);

			if (!IsNothing(sw)) {
				for (intCount = 0; intCount <= mobjAnalysisRawData.Count - 1; intCount++) {
					objRawDataReadings = mobjAnalysisRawData.item(intCount).Readings;
					if ((mobjAnalysisRawData.item(intCount).TotalReadings > 0)) {
						intSampleID = mobjAnalysisRawData.item(intCount).SampleID;
						switch (mobjAnalysisRawData.item(intCount).SampleType) {
							//--- Write the blank data details
							case clsRawData.enumSampleType.BLANK:
								if (!blnIsBlank) {
									blnIsBlank = true;
									blnIsStandard = false;
									blnIsSample = false;
									sw.WriteLine("BLANK; ; ; " + objRawDataReadings.Count);
								} else {
									if (intSampleID != intPrevSampleID) {
										sw.WriteLine();
										sw.WriteLine("BLANK; ; ; " + objRawDataReadings.Count);
									}
								}
							//--- Write the Stadard data details
							case clsRawData.enumSampleType.STANDARD:
								if (!blnIsStandard) {
									blnIsBlank = false;
									blnIsStandard = true;
									blnIsSample = false;
									sw.WriteLine();
									sw.WriteLine("STANDARD ;" + mobjAnalysisRawData(intCount).SampleID + ";" + mobjAnalysisRawData(intCount).SampleName + "; " + objRawDataReadings.Count + "");
								} else {
									if (intSampleID != intPrevSampleID) {
										sw.WriteLine();
										sw.WriteLine("STANDARD ;" + mobjAnalysisRawData(intCount).SampleID + ";" + mobjAnalysisRawData(intCount).SampleName + "; " + objRawDataReadings.Count + "");
									}
								}
							//--- Write the Sample data details
							case clsRawData.enumSampleType.SAMPLE:
								if (!blnIsSample) {
									blnIsBlank = false;
									blnIsStandard = false;
									blnIsSample = true;
									sw.WriteLine();
									sw.WriteLine("SAMPLE ;" + mobjAnalysisRawData(intCount).SampleID + ";" + mobjAnalysisRawData(intCount).SampleName + "; " + objRawDataReadings.Count + "");
								} else {
									if (intSampleID != intPrevSampleID) {
										sw.WriteLine();
										sw.WriteLine("SAMPLE ;" + mobjAnalysisRawData(intCount).SampleID + ";" + mobjAnalysisRawData(intCount).SampleName + "; " + objRawDataReadings.Count + "");
									}
								}
						}
					}
					for (intReadingCounter = 0; intReadingCounter <= objRawDataReadings.Count - 1; intReadingCounter++) {
						sw.WriteLine(objRawDataReadings(intReadingCounter).XTime + " ,  " + objRawDataReadings(intReadingCounter).Absorbance);
					}
					//---Draw empty line
					//sw.WriteLine()
					intPrevSampleID = intSampleID;
				}

			}

			sw.Flush();
			fs.Flush();

			return true;

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
			sw.Close();
			fs.Close();
			//---------------------------------------------------------
		}
	}

	public double Calculate_Analysis_Graph_Param(ref AASGraph Curve, double XValue = 0.0, double YValue = 0.0)
	{
		//=====================================================================
		// Procedure Name        : Calculate_Analysis_Graph_Param
		// Parameters Passed     : AASGraph Reference, XValue,YValue 
		// Returns               : Double value
		// Purpose               : Calculate graph parameter of analysis
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 17-Jan-2007 03:25 pm
		// Revisions             : 1
		//=====================================================================
		double FrqIntv = 0.0;
		double xmax1 = 0;
		double xmin1 = 0;
		double Fmin = 0;
		double Fmax = 0;
		double Fx = 0;
		int fn;
		int tot1;

		try {
			// Calculate the Graph X axis coordinates 
			if (IsNothing(Curve)) {
				return 0.0;
			}

			xmax1 = Curve.YAxisMax;
			xmin1 = Curve.YAxisMin;
			tot1 = (xmax1 - xmin1) * 60;

			FrqIntv = gobjclsStandardGraph.GetInterval(xmax1, xmin1, tot1, true);
			//FrqIntv = 100

			fn = (xmax1 / FrqIntv);
			Fmax = (double)fn * FrqIntv;
			if (xmax1 > Fmax) {
				Fmax = Fmax + FrqIntv;
			}
			fn = (int)xmin1 / FrqIntv;
			Fmin = (double)fn * FrqIntv;

			if ((xmin1 < Fmin)) {
				Fmin = Fmin - FrqIntv;
			}

			if ((Fmin > xmin1) & (FrqIntv != -1.0)) {
				while ((Fmin > xmin1)) {
					Fmax -= FrqIntv;
				}
			}

			if ((Fmax < xmax1 & FrqIntv != -1.0)) {
				while ((Fmax < xmax1)) {
					Fmax += FrqIntv;
				}
			}
			//Curve.YAxisMin = -0.2 'Fmin
			//Curve.YAxisMax = 1.1  'Fmax
			//Curve.YAxisStep = 0.1 'FrqIntv
			//Curve.YAxisMinorStep = 0.05

			//---changed by deepak on 29.04.07
			Curve.YAxisMin = -0.2;
			//Fmin
			Curve.YAxisMax = 0.8;
			//0.8 'Fmax ' changed by pankaj
			Curve.YAxisStep = 0.2;
			//FrqIntv
			Curve.YAxisMinorStep = 0.2;
			//---changed by deepak on 29.04.07

			////----- Added by Sachin Dokhale
			//xmax1 = Curve.XAxisMax
			//xmin1 = Curve.XAxisMin
			if (!(XValue == 0.0)) {
				//Saurabh 10.07.07 for Scrolling Graph
				//If (XValue > Curve.XAxisMax) Then
				//    xmax1 = Curve.XAxisMax + (gobjNewMethod.AnalysisParameters.IntegrationTime * 3)
				//End If
				//xmin1 = Curve.XAxisMin
				if ((XValue > Curve.XAxisMax)) {
					xmax1 = Curve.XAxisMax + (gobjNewMethod.AnalysisParameters.IntegrationTime + 20);
					xmin1 = Curve.XAxisMin + (gobjNewMethod.AnalysisParameters.IntegrationTime + 20);
				} else {
					xmin1 = Curve.XAxisMin;
				}

			} else {
				xmax1 = Curve.XAxisMax;
				xmin1 = Curve.XAxisMin;
			}

			tot1 = 60;
			Fx = gobjclsStandardGraph.GetInterval(xmax1, xmin1, tot1, true);

			if ((Fx > 0)) {
				fn = xmax1 / Fx;
			} else {
				fn = 0;
			}

			Fmax = fn * Fx;
			if ((xmax1 > Fmax)) {
				Fmax += Fx;
			}

			Curve.XAxisMin = xmin1;
			Curve.XAxisMax = Fmax;
			Curve.XAxisStep = gobjclsStandardGraph.GetInterval(Curve.XAxisMax, Curve.XAxisMin, tot1, true);

			//If is Added by Saurabh for Emission---------------
			// Chanege parameters for Emission mode 
			if (gobjNewMethod.OperationMode == EnumOperationMode.MODE_EMMISSION) {
				AASGraphAnalysis.YAxisMin = -10.0;
				AASGraphAnalysis.YAxisMax = 100;
				AASGraphAnalysis.YAxisMinorStep = 2;
			} else {
				//-----Added By Pankaj on 10 May 2007
				// Chanege parameters for else mode
				AASGraphAnalysis.YAxisMin = -0.2;
				AASGraphAnalysis.YAxisMax = 1.2;
			}

			gobjClsAAS203.Calculate_Analysis_Graph_Param(AASGraphAnalysis, ClsAAS203.enumChangeAxis.xyAxis);
			//-------------

			return FrqIntv;

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

	public double Read_Quant_Data(int intStartTime, int intEndTime)
	{
		//=====================================================================
		// Procedure Name        : Read_Quant_Data
		// Parameters Passed     : intStartTime as int
		//                         intEndTime  as int
		// Returns               : Double
		// Purpose               : Read Quant Data event 
		//                           
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 15-Dec-2006
		// Revisions             : 1
		//=====================================================================
		//double	 (HWND hwnd, CURVEDATA *AnaGraph)
		//{
		//HDC				 hdc;
		//HPEN				 hpen, hpenold;
		//double          abs1=0.0;

		//#If QDEMO Then
		//int	adval=0;
		//  if (!Dfptr){
		//	 Dfptr= fopen("raw0.dat","rt");
		//	 if (Dfptr)
		//		 fscanf(Dfptr, "%d", &adval);
		//	}
		//#End If
		// hdc = GetDC(hwnd);
		// ReadFilterSetting();   // new changes
		// if (Method->Mode==MODE_UVABS){
		//	Read_Quant_Data_UV_Mode(hwnd);
		//  }
		// else{
		//	hpen= SetColor(SampType, TRUE);
		//   If (hpen! = NULL) Then
		//	    hpenold = SelectObject(hdc, hpen);
		//	if (Xoldt!=-1 && Yoldt!=-1)
		//	    SetXoldYold(Xoldt, Yoldt);
		//	if (Method->QuantData->Param.Meas_Mode==INTEGRATE){
		//       If (!Filter_flag) Then
		//		    Wait_For_Analysis(hwnd, 2);
		//       Else
		//		    Wait_For_Analysis(hwnd, 2);
		//		Read_Quant_Data_Integration_Mode(hwnd,hdc, AnaGraph);
		//	}
		//	else if (Method->QuantData->Param.Meas_Mode==PKAREA ||
		//	         Method->QuantData->Param.Meas_Mode==PKHEIGHT)
		//	    Read_Quant_Data_PkHt_Area_Mode(hwnd, hdc, AnaGraph);
		//   abs1=StoreCalculateDisplayQuantValue(hwnd);
		//	GetXoldYold(&Xoldt, &Yoldt);
		//	if (hpen!=NULL){
		//	    SelectObject(hdc, hpenold);
		//	DeleteObject(hpen);
		//  }
		// }
		// ReleaseDC(hwnd, hdc);
		// return abs1;
		//}


		//---CODE BY MANGESH

		//HDC				 hdc;
		//HPEN				 hpen, hpenold;
		double dblAbsorbance = 0.0;

		try {
			//#If QDEMO Then
			// dim adval as integer=0
			// if not (Dfptr)
			//	 Dfptr= fopen("raw0.dat","rt")
			//	 if (Dfptr)
			//		 fscanf(Dfptr, "%d", &adval )
			//   end if
			//  end if
			//#End If

			// Read the filter setting
			gobjClsAAS203.funcReadFilterSetting();
			//--- Start to Aspiration thread
			StartAspirationThread(intStartTime, intEndTime);

			//'If (gobjNewMethod.OperationMode = EnumOperationMode.MODE_UVABS) Then
			//'    'Call Read_Quant_Data_UV_Mode()
			//'Else
			//'    'hpen = SetColor(SampType, True)
			//'    'If Not (hpen Is Nothing) Then
			//'    '    hpenold = SelectObject(hdc, hpen)
			//'    'End If
			//'    'If (XOld <> -1 And YOld <> -1) Then
			//'    '    SetXoldYold(XOld, YOld)
			//'    'End If

			//'    'If (XOld <> -1 And YOld <> -1) Then
			//'    '    XOld = 0
			//'    '    YOld = 0
			//'    'End If

			//'    Call StartAspirationThread(dtStartTime)

			//'    If (gobjNewMethod.AnalysisParameters.MeasurementMode = enumMeasurementMode.Integrate) Then
			//'        If Not (Filter_flag) Then
			//'            Wait_For_Analysis(2)
			//'        Else
			//'            Wait_For_Analysis(2)
			//'        End If

			//'        'Call Read_Quant_Data_Integration_Mode()
			//'        Call StartAspirationThread(dtStartTime)

			//'    ElseIf (gobjNewMethod.AnalysisParameters.MeasurementMode = enumMeasurementMode.PeakArea Or _
			//'            gobjNewMethod.AnalysisParameters.MeasurementMode = enumMeasurementMode.PeakHeight) Then

			//'        '#########TO DO Later
			//'        Call gobjClsAAS203.Read_Quant_Data_PkHt_Area_Mode()
			//'    End If

			//----Shited to Completed event function of BgThread
			//dblAbsorbance = StoreCalculateDisplayQuantValue()
			//Call GetXoldYold(XOld, YOld)
			//If Not (hpen Is Nothing) Then
			//    'SelectObject(hdc, hpenold)
			//    'DeleteObject(hpen)
			//End If
			//##########################################

			//'End If

			return dblAbsorbance;

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

	private void SetXoldYold(double dblXold, double dblYold)
	{
		//=====================================================================
		// Procedure Name        : SetXoldYold
		// Parameters Passed     : dblXold, dblYold as double
		// Returns               : None
		// Purpose               : Set X and Y Coordinate value to module level variable
		//                           
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 15-Dec-2006
		// Revisions             : 1
		//=====================================================================

		//void SetXoldYold(int Xoldt, int Yoldt)
		//{
		//   Xold=Xoldt;
		//   Yold= Yoldt;
		//}
		try {
			//remember x y 
			XOld = dblXold;
			YOld = dblYold;

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

	private void GetXoldYold(ref double dblXold, ref double dblYold)
	{
		//=====================================================================
		// Procedure Name        : GetXoldYold
		// Parameters Passed     : dblXold, dblYold as double
		// Returns               : None
		// Purpose               : get X and Y Coordinate value to module level variable
		//                           
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 15-Dec-2006
		// Revisions             : 1
		//=====================================================================
		//void GetXoldYold(int *Xoldt, int *Yoldt)
		//{
		//   *Xoldt=Xold;
		//   *Yoldt= Yold;
		//}
		try {
			dblXold = XOld;
			dblYold = YOld;

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

	private double GetAvgValOfCurAnalysis()
	{
		//=====================================================================
		// Procedure Name        : GetAvgValOfCurAnalysis
		// Parameters Passed     : None
		// Returns               : Double
		// Purpose               : return then Avg Value of Current Analysis 
		//                           
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 15-Dec-2006
		// Revisions             : 1
		//=====================================================================
		//double	GetAvgValOfCurAnalysis()
		//{
		// return GetAvgValOfAnalysis(Raw->RawDataCur);        
		//}


		//---CODE BY MANGESH

		try {
			//return GetAvgValOfAnalysis(Raw->RawDataCur) 
			// Return Avg. value of analysis Raw data
			if (!IsNothing(mobjAnalysisRawData)) {
				if (mobjAnalysisRawData.Count > 0) {
					return GetAvgValOfAnalysis(mobjAnalysisRawData.item(mobjAnalysisRawData.Count - 1));
				}
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

	private double GetAvgValOfAnalysis(clsRawData objAnalysisRawData)
	{
		//=====================================================================
		// Procedure Name        : GetAvgValOfAnalysis
		// Parameters Passed     : objAnalysisRawData of clsRawData data type
		// Returns               : Double
		// Purpose               : return then Avg Value of Current Analysis of given clsRowData data type
		//                           
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 15-Dec-2006
		// Revisions             : 1
		//=====================================================================
		//{
		//double	val=0.0;
		//int	tot=0;
		//RAW_DATA_LINKS *tempk=NULL;

		//if (node==NULL)
		//   return val;
		//tempk = node->Data.TopRawData;
		//while(tempk!=NULL)
		//{
		//   val+= tempk->Data.Abs;
		//   tot++;
		//   tempk=tempk->next;
		//}
		//If (tot > 0) Then
		//   val/=tot;
		//return val;
		//}


		//--- CODE BY MANGESH

		double dblAbsorbance;
		int intTotal;
		Analysis.clsRawDataReadings.RAW_DATA objRawDataReading;
		int intCounter;

		try {
			//calculate Avg Value of Current Analysis of given clsRowData data type.
			intTotal = 0;


			if (!IsNothing(objAnalysisRawData)) {
				for (intCounter = 0; intCounter <= objAnalysisRawData.Readings.Count - 1; intCounter++) {
					objRawDataReading = objAnalysisRawData.Readings.item(intCounter);
					dblAbsorbance += objRawDataReading.Absorbance;
					intTotal += 1;
				}

				if ((intTotal > 0)) {
					dblAbsorbance = dblAbsorbance / intTotal;
				}
			}
			return dblAbsorbance;

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

	private double GetPeakAreaOfCurAnalysis()
	{
		//=====================================================================
		// Procedure Name        : GetPeakAreaOfCurAnalysis
		// Parameters Passed     : objAnalysisRawData of clsRawData data type
		// Returns               : Double
		// Purpose               : get peak area of curve of analysis
		//                           
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 15-Dec-2006
		// Revisions             : 1
		//=====================================================================

		//double	GetPeakAreaOfCurAnalysis()
		//{
		///* float	absorb=0.0;
		// float	y1;
		// float	val=0;
		// int	 i;
		// absorb = 0.0 ;
		// // formaulae = dx* ((y1+y2)/2 -(y1+y')/2)
		// read_count = findPeak_end();
		// for (i =0; i<read_count-1; i++){
		//	y1=GetBaseExtra((float) (i+1));
		//	val = (abs_read[i+1]-y1)/2.0;
		//            If (Val() < 0) Then
		//	 val=0;
		//   absorb+=val;
		//  }
		// clearwindow1(20, 294, 190, 306);
		// gxy1(5, 22);
		// absorb = get_float(absorb, TRUE);
		// if (mode==AA||mode==AABGC) gprintf("Peak Area   : %4.3f ", absorb);
		// else if (mode==EMISSION)   gprintf("Peak Area   : %-4.3f ", absorb);
		// return(absorb);
		// }
		// */

		//return 0.0;
		//}


		//--- CODE BY MANGESH 

		try {
			return 0.0;

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

	private double GetPeakHeightOfCurAnalysis()
	{
		//=====================================================================
		// Procedure Name        : GetPeakHeightOfCurAnalysis
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : get peak height of curve of analysis. 
		//                           
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 15-Dec-2006
		// Revisions             : 1
		//=====================================================================
		//double	GetPeakHeightOfCurAnalysis()
		//{
		//   //---mdf by sk on 3/8/2001
		//   // return GetPkHtOfAnalysis(Raw->RawDataCur);
		//   //---mdf by sk on 3/8/2001
		//   /*float	peakheight()
		//   {
		//       float	absorb=0.0, sav=0.0, base=0.0;
		//       int	i;
		//       for (i =4; i<read_count-4; i++)  {
		//	        sav=abs_read[i];
		//	        if (sav > absorb){
		//	            absorb = sav;
		//	            base =  abs_read[0]+sav* (abs_read[read_count-1]-abs_read[0])/(read_count-1);
		//	            base= get_float(base, TRUE);
		//	        }
		//       }
		//       clearwindow1(20, 294, 190, 306);
		//       gxy1(5, 22);
		//       absorb -= base;
		//       absorb= get_float(absorb, TRUE);
		//       if (mode==AA||mode==AABGC) gprintf("Peak Height : %4.3f", absorb);
		//       else if (mode==EMISSION)   gprintf("Peak Height : %-4.3f", absorb);
		//       return(absorb);
		//   }
		//   */

		//   return 0.0;
		//}


		//--- CODE BY MANGESH

		try {
			return 0.0;

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

	private double StoreCalculateStdSampDisplayQuantValue(ClsAAS203.enumSampleType intSampleType, ref Method.clsAnalysisStdParameters nCurStd, ref Method.clsAnalysisSampleParameters nCurSamp, double dblAbsorbance)
	{
		//=====================================================================
		// Procedure Name        : StoreCalculateStdSampDisplayQuantValue
		// Parameters Passed     : enumSampleType, dblAbsorbance 
		// Parameters Affected   : clsAnalysisStdParameters,clsAnalysisSampleParameterss
		// Returns               : double - Corrected Absorbance
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 17-Jan-2007 03:25 pm
		// Revisions             : 1
		//=====================================================================
		//char	str[40]="";
		//double abs1=0.0;
		//  if (nSampType==STD){
		//	 if ((*nCurStd)!=NULL){
		//		 GetValInString(abs, str, Method->Mode);
		//		 SetDlgItemText(hwnd,IDC_QAVABS, str);
		//		 if (Method->QuantData->Param.Meas_Mode==INTEGRATE)
		//			abs-=BlankAbs;
		//		 (*nCurStd)->Data.Abs=abs;
		////		 *nCurStd->Data.Abs = GetResultAccurate(abs, 3);
		//		 CheckValidStdAbs();
		//		 GetValInString(abs, str, Method->Mode);
		//		 SetDlgItemText(hwnd,IDC_QCORABS, str);
		//		 StoreResultAccurate((*nCurStd)->Data.Conc, str,
		//			  Method->QuantData->Param.No_Decimals);
		//		 SetDlgItemText(hwnd,IDC_QCONC, str);
		//		 if (Method->QuantData->Param.Repeat>1 || Method->QuantData->Param.ConcRepeat>1){
		//			AddAbsRepeatStd((*nCurStd)->Data.Abs, (*nCurStd)->Data.Conc,(*nCurStd));
		//			CalculateAvgOfStd((*nCurStd));
		//		  }
		//		 if (Method->Mode==MODE_EMISSION)
		//			(*nCurStd)->Data.Abs = GetResultAccurate((*nCurStd)->Data.Abs, 1);
		//                        Else
		//			 (*nCurStd)->Data.Abs = GetResultAccurate((*nCurStd)->Data.Abs, 3);
		//	  }
		//	}
		//  else if (nSampType==SAMP){
		//	 if (*nCurSamp!=NULL){
		//		 GetValInString(abs, str, Method->Mode);
		//		 SetDlgItemText(hwnd,IDC_QAVABS, str);
		//		 if (Method->QuantData->Param.Meas_Mode==INTEGRATE)
		//			abs-=BlankAbs;
		//		 (*nCurSamp)->Data.Abs=abs; // GetResultAccurate(abs, 3);
		//		 abs1 = abs; // added by sss for saving the abs of sample for checking for outoff scale on dt 27/12/2000
		//		 GetValInString(abs, str, Method->Mode);
		//		 SetDlgItemText(hwnd,IDC_QCORABS, str);
		//		 (*nCurSamp)->Data.Conc = Get_Conc((*nCurSamp)->Data.Abs, 0.0);
		//		 if ((*nCurSamp)->Data.Conc>=0 && (*nCurSamp)->Data.Abs>-0.1)
		//			(*nCurSamp)->Data.Used=TRUE;

		//		 if (Method->QuantData->Param.Repeat>1 || Method->QuantData->Param.ConcRepeat>1){
		//			AddAbsRepeatSamp((*nCurSamp)->Data.Abs, (*nCurSamp)->Data.Conc, (*nCurSamp));
		//			CalculateAvgOfSamp((*nCurSamp));
		//		  }
		//		 if (Method->Mode==MODE_EMISSION)
		//			(*nCurSamp)->Data.Abs = GetResultAccurate((*nCurSamp)->Data.Abs, 1);
		//                                            Else
		//			(*nCurSamp)->Data.Abs = GetResultAccurate((*nCurSamp)->Data.Abs, 3);
		//		 StoreResultAccurate((*nCurSamp)->Data.Conc, str,
		//			  Method->QuantData->Param.No_Decimals);
		//		 strcat(str, "   ppm");
		//		 SetDlgItemText(hwnd,IDC_QCONC, str);
		//	 }
		//	}
		//	return abs1;


		//--- CODE BY MANGESH

		double dblCorrectedAbsorbance;

		try {
			switch (intSampleType) {
				case ClsAAS203.enumSampleType.STANDARD:

					if (!IsNothing(nCurStd)) {
						//Saurabh 05 June 2007
						//lblAverageAbsorbance.Text = FormatNumber(abs, gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfDecimalPlaces)
						//lblAverageAbsorbance.Text = FormatNumber(dblAbsorbance, 3) 'Commented & Added by Saurabh
						if (gobjNewMethod.OperationMode == EnumOperationMode.MODE_EMMISSION) {
							lblAverageAbsorbance.Text = FormatNumber(dblAbsorbance, 1);
						} else {
							lblAverageAbsorbance.Text = FormatNumber(dblAbsorbance, 3);
						}
						//Saurabh 05 June 2007

						if ((gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.MeasurementMode == enumMeasurementMode.Integrate)) {
							dblAbsorbance -= mdblBlankAbsorbance;
						}

						nCurStd.Abs = dblAbsorbance;
						CheckValidStdAbs();
						//Saurabh 05 June 2007
						//lblCorrectedAbsorbance.Text = FormatNumber(dblAbsorbance, gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfDecimalPlaces)
						//lblCorrectedAbsorbance.Text = FormatNumber(dblAbsorbance, 3)      'Commented & Added by Saurabh
						if (gobjNewMethod.OperationMode == EnumOperationMode.MODE_EMMISSION) {
							lblCorrectedAbsorbance.Text = FormatNumber(dblAbsorbance, 1);
						} else {
							lblCorrectedAbsorbance.Text = FormatNumber(dblAbsorbance, 3);
						}
						//Saurabh 05 June 2007

						//---Store Result Accurate upto AnalysisParameters.NumOfDecimalPlaces


						// + Commented by Amit 26/03/2009 ##################################################
						//lblConcentration.Text = FormatNumber(nCurStd.Concentration, gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfDecimalPlaces)
						// - Added by Amit 26/03/2009 ##################################################


						//+ Added by Amit 26/03/2009 ##################################################
						//If gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.Unit = enumUnit.PPB Then
						lblConcentration.Text = FormatNumber(nCurStd.Concentration, gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfDecimalPlaces);
						//Else
						//lblConcentration.Text = FormatNumber(nCurStd.Concentration, CONST_Format_Value_Concentration)
						//End If
						//+ Added by Amit 26/03/2009 ##################################################


						if ((gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfStdRepeats > 1 | gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfSampleRepeats > 1)) {
							AddAbsRepeatStd(nCurStd.Abs, nCurStd.Concentration, nCurStd.AbsRepeat);
							CalculateAvgOfStd(nCurStd);
						}

						if ((gobjNewMethod.OperationMode == EnumOperationMode.MODE_EMMISSION)) {
						// nCurStd.Abs = FormatNumber(nCurStd.Abs, 1)
						} else {
							//nCurStd.Abs = FormatNumber(nCurStd.Abs, 3)
						}

					}
				case ClsAAS203.enumSampleType.SAMPLE:


					if (!IsNothing(nCurSamp)) {
						//Saurabh 05 June 2007
						//lblAverageAbsorbance.Text = FormatNumber(abs, gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfDecimalPlaces)
						//lblAverageAbsorbance.Text = FormatNumber(dblAbsorbance, 3)     'Commented & Added by Saurabh
						if (gobjNewMethod.OperationMode == EnumOperationMode.MODE_EMMISSION) {
							lblAverageAbsorbance.Text = FormatNumber(dblAbsorbance, 1);
						} else {
							lblAverageAbsorbance.Text = FormatNumber(dblAbsorbance, 3);
						}
						//Saurabh 05 June 2007

						if ((gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.MeasurementMode == enumMeasurementMode.Integrate)) {
							dblAbsorbance -= mdblBlankAbsorbance;
						}

						nCurSamp.Abs = dblAbsorbance;

						//---dblCorrectedAbsorbance = FormatNumber(dblAbsorbance, gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfDecimalPlaces) '---03.07.09
						//---03.07.09
						if (gobjNewMethod.OperationMode == EnumOperationMode.MODE_EMMISSION) {
							dblCorrectedAbsorbance = FormatNumber(dblAbsorbance, 1);
						} else {
							dblCorrectedAbsorbance = FormatNumber(dblAbsorbance, 3);
						}
						//-----------------------------

						//Saurabh 05 June 2007
						//lblCorrectedAbsorbance.Text = FormatNumber(dblAbsorbance, gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfDecimalPlaces)
						//lblCorrectedAbsorbance.Text = FormatNumber(dblAbsorbance, 3)    'Commented & Added by Saurabh 01.08.07
						if (gobjNewMethod.OperationMode == EnumOperationMode.MODE_EMMISSION) {
							lblCorrectedAbsorbance.Text = FormatNumber(dblAbsorbance, 1);
						} else {
							lblCorrectedAbsorbance.Text = FormatNumber(dblAbsorbance, 3);
						}
						//Saurabh 05 June 2007

						nCurSamp.Conc = gobjclsStandardGraph.Get_Conc(nCurSamp.Abs, 0.0);

						if ((nCurSamp.Conc >= 0 & nCurSamp.Abs > -0.1)) {
							nCurSamp.Used = true;
						}

						//if (Method->QuantData->Param.Repeat>1 || Method->QuantData->Param.ConcRepeat>1){
						if ((gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfStdRepeats > 1 | gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfSampleRepeats > 1)) {
							AddAbsRepeatSamp(nCurSamp.Abs, nCurSamp.Conc, nCurSamp.AbsRepeat);
							CalculateAvgOfSamp(nCurSamp);
						}

						if ((gobjNewMethod.OperationMode == EnumOperationMode.MODE_EMMISSION)) {
						//nCurSamp.Abs = FormatNumber(nCurSamp.Abs, 1)
						} else {
							//nCurSamp.Abs = FormatNumber(nCurSamp.Abs, 3)
						}

						//+ Commented by Amit 26/03/09 ################################################
						//lblConcentration.Text = FormatNumber(nCurSamp.Conc, gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfDecimalPlaces) & " ppm"
						//- Commented by Amit 26/03/09 ################################################

						//+ Added by Amit 26/03/09 ################################################
						if (gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.Unit == enumUnit.PPB) {
							lblConcentration.Text = FormatNumber(nCurSamp.Conc, gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfDecimalPlaces) + Space(1) + Const_PPB;
						} else {
							lblConcentration.Text = FormatNumber(nCurSamp.Conc, gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfDecimalPlaces) + Space(1) + Const_PPM;
						}
						//- Added by Amit 26/03/09 ################################################


					}
			}

			return dblCorrectedAbsorbance;

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

	private void AddAbsRepeatStd(double dblAbsorbance, double dblConcentration, ref Method.clsAbsRepeat objAbsRepeat)
	{
		//=====================================================================
		// Procedure Name        : AddAbsRepeatStd
		// Parameters Passed     : dblAbsorbance,dblConcentration
		// Parameters affected   : Method.clsAbsRepeat
		// Returns               : None
		// Purpose               : Add Repeat Abs data into Standard parameter object
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 17-Jan-2007 03:25 pm
		// Revisions             : 1
		//=====================================================================
		//void	  S4FUNC	AddAbsRepeatStd(double data, double conc, STDDATA *cur)
		//{
		// if (cur==NULL)
		//	return;
		// data = GetResultAccurate(data,3);
		// conc =  GetResultAccurate(conc,Method->QuantData->Param.No_Decimals);

		// if (cur->Data.AbsRepeat==NULL){
		//	cur->Data.AbsRepeat = (ABSREPEAT *) malloc(sizeof(ABSREPEAT));
		//	InitAbsRepeat(cur->Data.AbsRepeat);
		//  }
		// AddAbsRepeatData(data, conc, &(cur->Data.AbsRepeat->RptDataTop));
		//}

		//--- CODE BY MANGESH 

		try {
			//'dblAbsorbance = Math.Round(dblAbsorbance, 3)
			//'dblConcentration = Math.Round(dblConcentration, gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfDecimalPlaces)

			InitAbsRepeat(objAbsRepeat);

			AddAbsRepeatData(dblAbsorbance, dblConcentration, objAbsRepeat.AbsRepeatData);

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

	private void AddAbsRepeatSamp(double dblAbsorbance, double dblConcentration, ref Method.clsAbsRepeat objAbsRepeat)
	{
		//=====================================================================
		// Procedure Name        : AddAbsRepeatSamp
		// Parameters Passed     : dblAbsorbance, dblConcentration  as double
		// Parameters Affected   : Method.clsAbsRepeat 
		// Returns               : None
		// Purpose               : Add Repeat Abs data into Sample parameter object
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 17-Jan-2007 03:25 pm
		// Revisions             : 1
		//=====================================================================
		//{
		// if (cur==NULL)
		//	return;
		// data = GetResultAccurate(data,3);
		// conc =  GetResultAccurate(conc,Method->QuantData->Param.No_Decimals);
		// if (cur->Data.AbsRepeat==NULL){
		//	cur->Data.AbsRepeat = (ABSREPEAT *) malloc(sizeof(ABSREPEAT));
		//	InitAbsRepeat(cur->Data.AbsRepeat);
		//  }
		// AddAbsRepeatData(data, conc, &(cur->Data.AbsRepeat->RptDataTop));
		//}

		//--- CODE BY MANGESH 

		try {
			//dblAbsorbance = Math.Round(dblAbsorbance, 3)
			//dblConcentration = Math.Round(dblConcentration, gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfDecimalPlaces)
			// Add Sample Repeat data 
			InitAbsRepeat(objAbsRepeat);
			AddAbsRepeatData(dblAbsorbance, dblConcentration, objAbsRepeat.AbsRepeatData);

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

	private void InitAbsRepeat(ref Method.clsAbsRepeat AbsRpt)
	{
		//=====================================================================
		// Procedure Name        : InitAbsRepeat
		// Parameters Passed     : Method.clsAbsRepeat
		// Returns               : None
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 17-Jan-2007 03:25 pm
		// Revisions             : 1
		//=====================================================================
		//void(InitAbsRepeat(ABSREPEAT * AbsRpt))
		//{
		//   if (AbsRpt==NULL)
		//	    return;
		//   AbsRpt->RptDataTop=NULL;
		//   AbsRpt->Data.TotData[0]=AbsRpt->Data.TotData[1]=(double)0.0;
		//   AbsRpt->Data.Zavg[0]=AbsRpt->Data.Zavg[1] =(double)0.0;
		//   AbsRpt->Data.CV[0]=AbsRpt->Data.CV[1] =(double)0.0;
		//   AbsRpt->Data.Zsigma[0]=AbsRpt->Data.Zsigma[1] =(double)0.0;
		//   AbsRpt->Data.Var[0]=AbsRpt->Data.Var[1] =(double)0.0;
		//   AbsRpt->Data.Min[0]=AbsRpt->Data.Min[1] =(double)0.0;
		//   AbsRpt->Data.Max[0]=AbsRpt->Data.Max[1] =(double)0.0;
		//}

		//--- CODE BY MANGESH 

		try {
			//--- Init Repeat data object
			if (IsNothing(AbsRpt)) {
				AbsRpt = new Method.clsAbsRepeat();

				AbsRpt.AbsRepeatData = null;

				AbsRpt.BasicStat.TotData(0) = 0.0;
				AbsRpt.BasicStat.TotData(1) = 0.0;

				AbsRpt.BasicStat.ZAvg(0) = 0.0;
				AbsRpt.BasicStat.ZAvg(1) = 0.0;

				AbsRpt.BasicStat.CV(0) = 0.0;
				AbsRpt.BasicStat.CV(1) = 0.0;

				AbsRpt.BasicStat.ZSigma(0) = 0.0;
				AbsRpt.BasicStat.ZSigma(1) = 0.0;

				AbsRpt.BasicStat.Var(0) = 0.0;
				AbsRpt.BasicStat.Var(1) = 0.0;

				AbsRpt.BasicStat.Min(0) = 0.0;
				AbsRpt.BasicStat.Min(1) = 0.0;

				AbsRpt.BasicStat.Max(0) = 0.0;
				AbsRpt.BasicStat.Max(1) = 0.0;

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

	private void AddAbsRepeatData(double dblAbsorbance, double dblConcentration, ref Method.clsAbsRepeatDataCollection objAbsRepeatDataCollection)
	{
		//=====================================================================
		// Procedure Name        : AddAbsRepeatData
		// Parameters Passed     : dblAbsorbance,dblConcentration 
		// Parameter Affected    : Method.clsAbsRepeatDataCollection
		// Returns               : None
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 17-Jan-2007 03:25 pm
		// Revisions             : 1
		//=====================================================================
		//{
		//ABSREPEATDATA  *tempk=NULL;
		//ABSREPEATDATA  *cur=NULL;

		// tempk = (ABSREPEATDATA*) malloc(sizeof(ABSREPEATDATA));
		// if (tempk !=NULL){
		//  cur = GoAbsRepeatBottom(*Top);
		//  tempk->Abs=abs;
		//  tempk->Conc=conc;
		//  tempk->next=NULL;
		//  If (cur! = NULL) Then
		//    tempk->next=cur->next;
		//  if (*Top==NULL)
		//	 *Top= tempk;
		//  Else
		//    cur->next=tempk;
		//  cur = tempk;
		// }
		//}

		//---CODE BY MANGESH

		Method.clsAbsRepeatData objAbsRepeatData;

		try {
			// Add Repeat Analysis data into object
			objAbsRepeatData = new Method.clsAbsRepeatData();
			objAbsRepeatData.Abs = dblAbsorbance;
			objAbsRepeatData.Concentration = dblConcentration;
			objAbsRepeatData.Used = true;
			//--- Add Repeat data object into collection
			if (!IsNothing(objAbsRepeatDataCollection)) {
				//objAbsRepeatDataCollection.Add(objAbsRepeatData)
				if ((mblnRepeatResultSample | mblnRepeatResultStd) & (objAbsRepeatDataCollection.Count > 0)) {
					objAbsRepeatDataCollection.item(objAbsRepeatDataCollection.Count - 1) = objAbsRepeatData;
				} else {
					objAbsRepeatDataCollection.Add(objAbsRepeatData);
				}

			} else {
				objAbsRepeatDataCollection = new Method.clsAbsRepeatDataCollection();
				objAbsRepeatDataCollection.Add(objAbsRepeatData);
			}
			mblnRepeatResultSample = false;
			mblnRepeatResultStd = false;
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

	private void CalculateAvgOfStd(ref Method.clsAnalysisStdParameters objStandard)
	{
		//=====================================================================
		// Procedure Name        : CalculateAvgOfStd 
		// Parameters Passed     : Reference to the clsAnalysisStdParameters
		// Returns               : None
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 17-Jan-2007 03:25 pm
		// Revisions             : 1
		//=====================================================================
		//{
		// if (mobjCurrentStandard==NULL || mobjCurrentStandard->Data.AbsRepeat==NULL)
		//	return;
		// CalculateBasicStats(mobjCurrentStandard->Data.AbsRepeat);
		// mobjCurrentStandard->Data.Abs = mobjCurrentStandard->Data.AbsRepeat->Data.Zavg[0];
		//}

		//---CODE BY MANGESH

		try {
			if (IsNothing(objStandard) | IsNothing(objStandard.AbsRepeat)) {
				return;
			}
			//--- Set Avg. of Abs of Standard
			if (clsBasicStatistics.CalculateBasicStats(objStandard.AbsRepeat)) {
				objStandard.Abs = objStandard.AbsRepeat.BasicStat.ZAvg(0);
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

	private void CalculateAvgOfSamp(ref Method.clsAnalysisSampleParameters objSample)
	{
		//=====================================================================
		// Procedure Name        : CalculateAvgOfSamp
		// Parameters Passed     : Reference of clsAnalysisSampleParameters object
		// Returns               : None
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 17-Jan-2007 03:25 pm
		// Revisions             : 1
		//=====================================================================
		//void S4FUNC CalculateAvgOfSamp(SAMPDATA *mobjCurrentSample)
		//{
		//   if (mobjCurrentSample==NULL || mobjCurrentSample->Data.AbsRepeat==NULL)
		//	    return;
		//   CalculateBasicStats(mobjCurrentSample->Data.AbsRepeat);
		//   mobjCurrentSample->Data.Abs = mobjCurrentSample->Data.AbsRepeat->Data.Zavg[0];
		//}

		//---CODE BY MANGESH

		try {
			if (IsNothing(objSample) | IsNothing(objSample.AbsRepeat)) {
				return;
			}
			//--- Set Avg value of abs
			if (clsBasicStatistics.CalculateBasicStats(objSample.AbsRepeat)) {
				objSample.Abs = objSample.AbsRepeat.BasicStat.ZAvg(0);
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

	private Method.clsAnalysisStdParameters GetPrevStd(Method.clsAnalysisStdParametersCollection objStandardsCollection, Method.clsAnalysisStdParameters objCurrentStandard)
	{
		//=====================================================================
		// Procedure Name        : GetPrevStd
		// Parameters Passed     : StandardDataCollection and Current Standard
		// Returns               : Previous Standard
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 17-Jan-2007 03:25 pm
		// Revisions             : 1
		//=====================================================================

		//--- ORIGINAL 16-bit CODE

		//STDDATA *S4FUNC GetPrevStd(STDDATA *StdTop, STDDATA *CurStd)
		//{
		//   STDDATA	*tempk=NULL;
		//   tempk = StdTop;
		//   if (CurStd == StdTop)
		//	    return tempk;
		//   while(tempk!=NULL)
		//   {
		//	    if (tempk->next==CurStd)
		//	        break;
		//       tempk=tempk->next;
		//   }
		//   return tempk;
		//}
		//***************************************************************
		int intCounter;

		try {
			if (object.ReferenceEquals(mobjLastStandardData, mobjCurrentStandard)) {
				return objCurrentStandard;
			}

			//--- Returns the Previous Standard from Standard Collection.
			for (intCounter = 0; intCounter <= objStandardsCollection.Count - 1; intCounter++) {
				if (object.ReferenceEquals(objStandardsCollection.item(intCounter), objCurrentStandard)) {
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			////----- Commented by Sachin Dokhale on 31.07.07
			//If intCounter = 0 Then
			//    Return objStandardsCollection.item(0).Clone()
			//Else
			//    Return objStandardsCollection.item(intCounter - 1).Clone()
			//End If
			////----- Added by Sachin Dokhale on 31.07.07
			if (intCounter == 0) {
				intIEnumCollLocationStd = 1;
				return objStandardsCollection.item(0);
			} else {
				intIEnumCollLocationStd -= 1;
				////---- Modified by Sachin Dokahle on 19.05.08
				//Return objStandardsCollection.item(intCounter - 1)
				//If mblnRepeatLastStd = True Then
				return objStandardsCollection.item(intCounter);
				//End If
				////---
			}
		////-----
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

	private Method.clsAnalysisSampleParameters GetPrevSamp(Method.clsAnalysisSampleParametersCollection objSamplesCollection, Method.clsAnalysisSampleParameters objCurrentSample)
	{
		//=====================================================================
		// Procedure Name        : GetPrevSamp
		// Parameters Passed     : SampleDataCollection and Current Sample
		// Returns               : Previous Sample parameter
		// Purpose               : return previous sample from sample collection object
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 17-Jan-2007 03:25 pm
		// Revisions             : 1
		//=====================================================================

		//--- ORIGINAL 16-bit CODE

		//SAMPDATA	*S4FUNC GetPrevSamp(SAMPDATA *SampTop, SAMPDATA *CurSamp)
		//{
		//   SAMPDATA	*tempk=NULL;
		//   tempk =  SampTop;
		//   if (CurSamp==SampTop)
		//	    return tempk;
		//   while(tempk!=NULL)
		//   {
		//	    if (tempk->next==CurSamp)
		//		    break;
		//	    tempk=tempk->next;
		//   }
		//   return tempk;
		//}
		//***************************************************************
		int intCounter;


		try {
			if (object.ReferenceEquals(mobjLastSampleData, mobjCurrentSample)) {
				return objCurrentSample;
			}
			// Set previous sample from sample collection object
			for (intCounter = 0; intCounter <= objSamplesCollection.Count - 1; intCounter++) {
				if (object.ReferenceEquals(objSamplesCollection.item(intCounter), objCurrentSample)) {
					break; // TODO: might not be correct. Was : Exit For
				}
			}
			////----- Commented by Sachin Dokhale on 31.07.07
			//---Returns the Previous Sample from Sample Collection.
			//If intCounter = 0 Then
			//    Return objSamplesCollection.item(0).Clone()
			//Else
			//    Return objSamplesCollection.item(intCounter - 1).Clone()
			//End If
			////----- Added by Sachin Dokhale on 31.07.07
			//If mblnRepeatLastSample = False Then
			if (intCounter == 0) {
				intIEnumCollLocationSamp = 1;
				return objSamplesCollection.item(0);
			} else {
				intIEnumCollLocationSamp -= 1;
				////---- Modified by Sachin Dokahle on 19.05.08
				//Return objSamplesCollection.item(intCounter - 1)
				return objSamplesCollection.item(intCounter);
				////---- Modified by Sachin Dokahle on 19.05.08
			}
		//Else

		//End If
		////-----


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

	private bool OnViewResults()
	{
		//=====================================================================
		// Procedure Name        : OnViewResults
		// Parameters Passed     : None
		// Returns               : True if success or False Quantitative Data Collection is Nothing
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 01-Feb-2007 07:50 pm
		// Revisions             : 1
		//=====================================================================


		//---- ORIGINAL CODE

		//void	OnViewResults(HWND hpar)
		//{
		//   DLGPROC  skp1;
		//	if (Method->QuantData==NULL)
		//	    return;
		//	if (GetTotStds(Method->QuantData->StdTopData, TRUE)>0)
		//	{
		//		skp1 =(DLGPROC) MakeProcInstance((DLGPROC) ViewResultsProc,hInst);
		//		DialogBox(hInst,"SHOWRESULTS", hpar, skp1);
		//		FreeProcInstance(skp1);
		//	}
		//   Else
		//	    Gerror_message_new("No Standards", "STANDARD CURVE");
		//}
		//*********************************************************
		frmViewResults objfrmViewResults;

		try {
			//DLGPROC  skp1;
			//if (Method->QuantData==NULL)
			//   return;
			//end if
			if (IsNothing(gobjNewMethod.QuantitativeDataCollection)) {
				return false;
			}
			//Display Result of quant. analysis in viewlist
			if ((clsStandardGraph.GetTotStds(gobjNewMethod.QuantitativeDataCollection(mintRunNumberIndex).StandardDataCollection, true) > 0)) {
				//skp1 =(DLGPROC) MakeProcInstance((DLGPROC) ViewResultsProc,hInst);
				//DialogBox(hInst,"SHOWRESULTS", hpar, skp1);
				//FreeProcInstance(skp1);
				objfrmViewResults = new frmViewResults(true, 0, 0, gobjNewMethod);
				objfrmViewResults.ShowDialog();
				Application.DoEvents();
				objfrmViewResults.Close();
				objfrmViewResults.Dispose();
				objfrmViewResults = null;
			} else {
				gobjMessageAdapter.ShowMessage(constNoStandards);
				Application.DoEvents();
			}

			return true;

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

	private void StoreCalculateDisplayQuantValueUvMode(double dblAbsorbance)
	{
		//=====================================================================
		// Procedure Name        : StoreCalculateDisplayQuantValueUvMode
		// Parameters Passed     : Absorbance value in UV mode
		// Returns               : None
		// Purpose               : To store, calculate and Display Quantitative
		//                         value in UV Mode
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 23-Apr-2007 11:45 pm
		// Revisions             : 1
		//=====================================================================

		//---- ORIGINAL CODE

		//void	StoreCalculateDisplayQuantValueUvMode(HWND hwnd, double abs)
		//{
		//	char	str[40]="";
		//	abs = GetValConvertedTo(abs, Method->Mode);
		//	if (SampType==BLANK)
		//	{
		//	  BlankAbs=abs;
		//	}
		//	else if (SampType==STD)
		//	{
		//		if (CurStd!=NULL){
		//			CurStd->Data.Abs=abs;
		//			GetValInString(abs, str, Method->Mode);
		//			SetDlgItemText(hwnd,IDC_QAVABS, str);
		//			CheckValidStdAbs();
		//			GetValInString(abs, str, Method->Mode);
		//			SetDlgItemText(hwnd,IDC_QCORABS, str);
		//			StoreResultAccurate(CurStd->Data.Conc, str, Method->QuantData->Param.No_Decimals);
		//			SetDlgItemText(hwnd,IDC_QCONC, str);
		//			CurStd->Data.Abs = GetResultAccurate(CurStd->Data.Abs, 3);
		//		}
		//	}
		//	else if (SampType==SAMP)
		//	{
		//       If (CurSamp! = NULL) Then
		//		{
		//			GetValInString(abs, str, Method->Mode);
		//			SetDlgItemText(hwnd,IDC_QAVABS, str);
		//			CurSamp->Data.Abs=abs;
		//			GetValInString(abs, str, Method->Mode);
		//			SetDlgItemText(hwnd,IDC_QCORABS, str);
		//			CurSamp->Data.Conc = Get_Conc(CurSamp->Data.Abs, 0.0);
		//			if (CurSamp->Data.Conc>0 && CurSamp->Data.Abs>-0.1)
		//				CurSamp->Data.Used=TRUE;
		//			CurSamp->Data.Abs = GetResultAccurate(CurSamp->Data.Abs, 3);
		//			StoreResultAccurate(CurSamp->Data.Conc, str, Method->QuantData->Param.No_Decimals);
		//			strcat(str, "   ppm");
		//			SetDlgItemText(hwnd,IDC_QCONC, str);
		//		}
		//	}
		//}
		//******************************************************************
		//char	str[40]="";
		try {
			//Calculate and display of Quant. data for UV mode
			//dblAbsorbance = gfuncGetValConvertedTo(dblAbsorbance, Method.Mode)

			//Display data of Blank/Std./Sample type
			if ((SampleType == ClsAAS203.enumSampleType.BLANK)) {
				mdblBlankAbsorbance = dblAbsorbance;
			} else if ((SampleType == ClsAAS203.enumSampleType.STANDARD)) {
				if (!IsNothing(mobjCurrentStandard)) {
					//CurStd->Data.Abs=abs;
					mobjCurrentStandard.Abs = dblAbsorbance;

					//GetValInString(abs, str, Method->Mode);
					//SetDlgItemText(hwnd,IDC_QAVABS, str);

					//Saurabh 05 June 2007
					if (gobjNewMethod.OperationMode == EnumOperationMode.MODE_EMMISSION) {
						lblAverageAbsorbance.Text = FormatNumber(dblAbsorbance, 1);
					} else {
						lblAverageAbsorbance.Text = FormatNumber(dblAbsorbance, 3);
					}
					//Saurabh 05 June 2007

					// validate the data of std. (ABS)
					CheckValidStdAbs();

					//GetValInString(abs, str, Method->Mode);
					//SetDlgItemText(hwnd,IDC_QCORABS, str);

					//Saurabh 05 June 2007
					if (gobjNewMethod.OperationMode == EnumOperationMode.MODE_EMMISSION) {
						lblCorrectedAbsorbance.Text = FormatNumber(dblAbsorbance, 1);
					} else {
						lblCorrectedAbsorbance.Text = FormatNumber(dblAbsorbance, 3);
					}
					//Saurabh 05 June 2007


					if ((gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfStdRepeats > 1 | gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfSampleRepeats > 1)) {
						AddAbsRepeatStd(mobjCurrentStandard.Abs, mobjCurrentStandard.Concentration, mobjCurrentStandard.AbsRepeat);
						CalculateAvgOfStd(mobjCurrentStandard);
					}

					//StoreResultAccurate(CurStd->Data.Conc, str, Method->QuantData->Param.No_Decimals);
					//SetDlgItemText(hwnd,IDC_QCONC, str);
					//Saurabh To format the concentration value upto 2 decimal places 20.07.07


					//+ Commented by Amit 26/03/09 ################################################
					//lblConcentration.Text = FormatNumber(mobjCurrentStandard.Concentration, 2)
					//- Commented by Amit 26/03/09 ################################################

					//+ Added by Amit 26/03/09 ################################################
					if (gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.Unit == enumUnit.PPB) {
						lblConcentration.Text = FormatNumber(mobjCurrentStandard.Concentration, CONST_Format_Value_Concentration_PPB);
					} else {
						lblConcentration.Text = FormatNumber(mobjCurrentStandard.Concentration, CONST_Format_Value_Concentration);
					}
					//- Added by Amit 26/03/09 ################################################


					//CurStd->Data.Abs = GetResultAccurate(CurStd->Data.Abs, 3);
					mobjLastStandardData = mobjCurrentStandard;
				} else {
					mobjLastStandardData = null;
				}

			} else if ((SampleType == ClsAAS203.enumSampleType.SAMPLE)) {
				if (!IsNothing(mobjCurrentSample)) {
					//GetValInString(abs, str, Method->Mode);
					//SetDlgItemText(hwnd,IDC_QAVABS, str);

					//Saurabh 05 June 2007
					if (gobjNewMethod.OperationMode == EnumOperationMode.MODE_EMMISSION) {
						lblAverageAbsorbance.Text = FormatNumber(dblAbsorbance, 1);
					} else {
						lblAverageAbsorbance.Text = FormatNumber(dblAbsorbance, 3);
					}
					//Saurabh 05 June 2007

					//CurSamp->Data.Abs=abs;
					mobjCurrentSample.Abs = dblAbsorbance;

					//GetValInString(abs, str, Method->Mode);
					//SetDlgItemText(hwnd,IDC_QCORABS, str);

					//Saurabh 05 June 2007
					if (gobjNewMethod.OperationMode == EnumOperationMode.MODE_EMMISSION) {
						lblCorrectedAbsorbance.Text = FormatNumber(dblAbsorbance, 1);
					} else {
						lblCorrectedAbsorbance.Text = FormatNumber(dblAbsorbance, 3);
					}
					//Saurabh 05 June 2007

					//CurSamp->Data.Conc = Get_Conc(CurSamp->Data.Abs, 0.0);
					mobjCurrentSample.Conc = gobjclsStandardGraph.Get_Conc(mobjCurrentSample.Abs, 0.0);

					//if (CurSamp->Data.Conc>0 && CurSamp->Data.Abs>-0.1)
					//	CurSamp->Data.Used=TRUE;
					//end if
					if (mobjCurrentSample.Conc > 0 & mobjCurrentSample.Abs > -0.1) {
						mobjCurrentSample.Used = true;
					}

					//CurSamp->Data.Abs = GetResultAccurate(CurSamp->Data.Abs, 3);

					if ((gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfStdRepeats > 1 | gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfSampleRepeats > 1)) {
						AddAbsRepeatSamp(mobjCurrentSample.Abs, mobjCurrentSample.Conc, mobjCurrentSample.AbsRepeat);
						CalculateAvgOfSamp(mobjCurrentSample);
					}
					//StoreResultAccurate(CurSamp->Data.Conc, str, Method->QuantData->Param.No_Decimals);
					//strcat(str, "   ppm");
					//SetDlgItemText(hwnd,IDC_QCONC, str);
					//Saurabh To format the concentration value upto 2 decimal places 20.07.07


					//+ Added by Amit 26/03/09 ################################################
					//lblConcentration.Text = FormatNumber(mobjCurrentSample.Conc, 2) & "  ppm"
					//- Added by Amit 26/03/09 ################################################


					//+ Added by Amit 26/03/09 ################################################
					if (gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.Unit == enumUnit.PPB) {
						lblConcentration.Text = FormatNumber(mobjCurrentSample.Conc, CONST_Format_Value_Concentration_PPB) + Space(1) + Const_PPB;
					} else {
						lblConcentration.Text = FormatNumber(mobjCurrentSample.Conc, CONST_Format_Value_Concentration) + Space(1) + Const_PPM;
					}
					//- Added by Amit 26/03/09 ################################################
					mobjLastSampleData = mobjCurrentSample;
				} else {
					mobjLastSampleData = null;
				}

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

	internal bool funcRefreshMethodParameter()
	{
		//=====================================================================
		// Procedure Name        : funcRefreshMethodParameter
		// Parameters Passed     : Nono
		// Returns               : True if success.
		// Purpose               : Reinit. property of Method object
		//                         
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : Jul 31, 2007 4:00 pm
		// Revisions             : 1
		//=====================================================================
		int intStdsToRemove;
		int intCount;
		int intStdsRemoved;
		int intStdsToAdd;
		Method.clsAnalysisStdParameters StandardData;
		int intRepeatCounter;
		try {
			// Reinit. property of Method object.

			if (mblnIsAnalysisStarted == true) {
				if (!(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex) == null)) {
					if (!gobjNewMethod.AnalysisParameters == null) {
						gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.IntegrationTime = gobjNewMethod.AnalysisParameters.IntegrationTime;
						gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.Unit = gobjNewMethod.AnalysisParameters.Unit;
						gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.IsBlankAfterEverySampleOrStd = gobjNewMethod.AnalysisParameters.IsBlankAfterEverySampleOrStd;
					}

					//-----23.08.07
					//##### for standard parameters
					if ((!gobjNewMethod.StandardDataCollection == null) & mblnIsAnalysisStarted == true) {
						//gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection = gobjNewMethod.StandardDataCollection.Clone
						if (gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.Count > gobjNewMethod.StandardDataCollection.Count) {
							//---if method std count is less than quantitative std count then
							//---quantitative std which are used should be kept intact
							//---those quantitative std which are not used should be removed.

							intStdsToRemove = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.Count - gobjNewMethod.StandardDataCollection.Count;

							for (intCount = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.Count - 1; intCount >= 0; intCount += -1) {
								StandardData = new Method.clsAnalysisStdParameters();
								StandardData = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount).Clone;
								//gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount) = gobjNewMethod.StandardDataCollection.item(intCount).Clone
								if (intStdsRemoved < intStdsToRemove) {
									if (gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection(intCount).Used == false) {
										gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.RemoveAt(intCount);
										intStdsRemoved += 1;
									}
								} else {
									////----- Commented by Sachin Dokhale
									if (gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection(intCount).Used == false) {
										gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount) = gobjNewMethod.StandardDataCollection.item(intCount).Clone;
									}
									////----- Added by Sachin Dokhale

									if (!gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount).AbsRepeat == null) {
										for (intRepeatCounter = 0; intRepeatCounter <= StandardData.AbsRepeat.AbsRepeatData.Count - 1; intRepeatCounter++) {
											//gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount).AbsRepeat.AbsRepeatData(intRepeatCounter).Abs = StandardData.AbsRepeat.AbsRepeatData(intRepeatCounter).Abs
											gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount).AbsRepeat.AbsRepeatData.Add(StandardData.AbsRepeat.AbsRepeatData(intRepeatCounter));
										}
										gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount).Used = StandardData.Used;
										gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount).Abs = StandardData.Abs;
										if (intRepeatCounter > 0) {
											CalculateAvgOfStd(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount));
										}
									} else {
										gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount).Used = StandardData.Used;
										gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount).Abs = StandardData.Abs;
									}
									////-----
								}
							}
							intStdsRemoved = 0;

						} else if (gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.Count == gobjNewMethod.StandardDataCollection.Count) {
							//---if quantitative std count is equal to that of method std count then
							//---update only those std which are not used.
							for (intCount = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.Count - 1; intCount >= 0; intCount += -1) {
								////----- Commented by Sachin Dokhale
								//If gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection(intCount).Used = False Then
								//gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount) = gobjNewMethod.StandardDataCollection.item(intCount).Clone
								//End If
								////----- Added by Sachin Dokhale
								//Dim StandardData As Method.clsAnalysisStdParameters
								StandardData = new Method.clsAnalysisStdParameters();
								StandardData = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount).Clone;
								gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount) = gobjNewMethod.StandardDataCollection.item(intCount).Clone;

								if (!gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount).AbsRepeat == null) {
									for (intRepeatCounter = 0; intRepeatCounter <= StandardData.AbsRepeat.AbsRepeatData.Count - 1; intRepeatCounter++) {
										//gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount).AbsRepeat.AbsRepeatData(intRepeatCounter).Abs = StandardData.AbsRepeat.AbsRepeatData(intRepeatCounter).Abs
										gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount).AbsRepeat.AbsRepeatData.Add(StandardData.AbsRepeat.AbsRepeatData(intRepeatCounter));
									}
									gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount).Used = StandardData.Used;
									gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount).Abs = StandardData.Abs;
									if (intRepeatCounter > 0) {
										CalculateAvgOfStd(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount));
									}
								} else {
									gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount).Used = StandardData.Used;
									gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount).Abs = StandardData.Abs;
								}
								////-----
							}

						} else if (gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.Count < gobjNewMethod.StandardDataCollection.Count) {
							//---if method std count is more than quantitative std count then
							//---quantitative std which are used should be kept intact.
							//---update quantitative std from method which are not used.
							//---add extra stds from method to quantitative list.
							//----Added by pankaj on 24 Jan 08
							intStdsToAdd = gobjNewMethod.StandardDataCollection.Count - gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.Count;
							for (intCount = 0; intCount <= gobjNewMethod.StandardDataCollection.Count - 1; intCount += 1) {
								if (intCount <= gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.Count - 1) {
									////----- Commented by Sachin Dokhale
									//If gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection(intCount).Used = False Then
									//    gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount) = gobjNewMethod.StandardDataCollection.item(intCount).Clone
									//End If
									////----- Added by Sachin Dokhale
									StandardData = new Method.clsAnalysisStdParameters();
									StandardData = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount).Clone;
									gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount) = gobjNewMethod.StandardDataCollection.item(intCount).Clone;

									if (!gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount).AbsRepeat == null) {
										for (intRepeatCounter = 0; intRepeatCounter <= StandardData.AbsRepeat.AbsRepeatData.Count - 1; intRepeatCounter++) {
											//gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount).AbsRepeat.AbsRepeatData(intRepeatCounter).Abs = StandardData.AbsRepeat.AbsRepeatData(intRepeatCounter).Abs
											gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount).AbsRepeat.AbsRepeatData.Add(StandardData.AbsRepeat.AbsRepeatData(intRepeatCounter));
										}
										gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount).Used = StandardData.Used;
										gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount).Abs = StandardData.Abs;
										if (intRepeatCounter > 0) {
											CalculateAvgOfStd(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount));
										}
									} else {
										gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount).Used = StandardData.Used;
										gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount).Abs = StandardData.Abs;
									}
								////-----
								} else {
									gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.Add(gobjNewMethod.StandardDataCollection.item(intCount).Clone);
								}
							}
							//--
						}
					}
					StandardData = null;

					//'###########for Sample parameters ##########################################
					//'Added by pankaj on 22 Feb 80
					if ((!gobjNewMethod.SampleDataCollection == null) & mblnIsAnalysisStarted == true) {
						//gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection = gobjNewMethod.StandardDataCollection.Clone
						if (gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.Count > gobjNewMethod.SampleDataCollection.Count) {
							//---if method std count is less than quantitative std count then
							//---quantitative std which are used should be kept intact
							//---those quantitative std which are not used should be removed.

							intStdsToRemove = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.Count - gobjNewMethod.SampleDataCollection.Count;

							for (intCount = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.Count - 1; intCount >= 0; intCount += -1) {
								if (intStdsRemoved < intStdsToRemove) {
									if (gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection(intCount).Used == false) {
										gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.RemoveAt(intCount);
										intStdsRemoved += 1;
									}
								} else {
									if (gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection(intCount).Used == false) {
										gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCount) = gobjNewMethod.SampleDataCollection.item(intCount).Clone;
									} else {
										gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCount).SampleName = gobjNewMethod.SampleDataCollection.item(intCount).SampleName;
										gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCount).Weight = gobjNewMethod.SampleDataCollection.item(intCount).Weight;
										gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCount).Volume = gobjNewMethod.SampleDataCollection.item(intCount).Volume;
										gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCount).DilutionFactor = gobjNewMethod.SampleDataCollection.item(intCount).DilutionFactor;
										//If Not gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCount).AbsRepeat Is Nothing Then
										//    For intRepeatCounter = 0 To gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCount).AbsRepeat.AbsRepeatData.Count - 1
										//        gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCount).AbsRepeat.AbsRepeatData(intRepeatCounter).Abs = StandardData.AbsRepeat.AbsRepeatData(intRepeatCounter).Abs
										//        'gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount).AbsRepeat.AbsRepeatData.Add(StandardData.AbsRepeat.AbsRepeatData(intRepeatCounter))
										//    Next
										//    'gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCount).AbsRepeat()
										//End If
									}
								}
							}
							intStdsRemoved = 0;

						} else if (gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.Count == gobjNewMethod.SampleDataCollection.Count) {
							//---if quantitative std count is equal to that of method std count then
							//---update only those std which are not used.
							for (intCount = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.Count - 1; intCount >= 0; intCount += -1) {
								if (gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection(intCount).Used == false) {
									gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCount) = gobjNewMethod.SampleDataCollection.item(intCount).Clone;
								} else {
									gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCount).SampleName = gobjNewMethod.SampleDataCollection.item(intCount).SampleName;
									gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCount).Weight = gobjNewMethod.SampleDataCollection.item(intCount).Weight;
									gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCount).Volume = gobjNewMethod.SampleDataCollection.item(intCount).Volume;
									gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCount).DilutionFactor = gobjNewMethod.SampleDataCollection.item(intCount).DilutionFactor;
								}
							}

						} else if (gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.Count < gobjNewMethod.SampleDataCollection.Count) {
							//---if method std count is more than quantitative std count then
							//---quantitative std which are used should be kept intact.
							//---update quantitative std from method which are not used.
							//---add extra stds from method to quantitative list.
							//----Added by pankaj on 24 Jan 08
							intStdsToAdd = gobjNewMethod.SampleDataCollection.Count - gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.Count;
							for (intCount = 0; intCount <= gobjNewMethod.SampleDataCollection.Count - 1; intCount += 1) {
								if (intCount <= gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.Count - 1) {
									if (gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection(intCount).Used == false) {
										gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCount) = gobjNewMethod.SampleDataCollection.item(intCount).Clone;
									} else {
										gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCount).SampleName = gobjNewMethod.SampleDataCollection.item(intCount).SampleName;
										gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCount).Weight = gobjNewMethod.SampleDataCollection.item(intCount).Weight;
										gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCount).Volume = gobjNewMethod.SampleDataCollection.item(intCount).Volume;
										gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCount).DilutionFactor = gobjNewMethod.SampleDataCollection.item(intCount).DilutionFactor;
									}
								} else {
									gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.Add(gobjNewMethod.SampleDataCollection.item(intCount).Clone);
								}
							}
							//--
						}
					}

					if (!gobjNewMethod.AnalysisParameters == null) {
						//gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters = gobjNewMethod.AnalysisParameters.Clone
						//---24.01.08
						gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfSampleRepeats = gobjNewMethod.AnalysisParameters.NumOfSampleRepeats;
						gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfStdRepeats = gobjNewMethod.AnalysisParameters.NumOfStdRepeats;
						//---24.01.08
					}
					//-----23.08.07

					funcRefreshEnumerators(mobjStandardEnumerator, mobjSampleEnumerator);

					//--- Set Enumerator Analysis sample Parameters
					if (mblnRepeatLastSample == false) {
						if (intIEnumCollLocationSamp > gobjNewMethod.SampleDataCollection.Count) {
							intIEnumCollLocationSamp = gobjNewMethod.SampleDataCollection.Count + 1;
						}
						if (funcMoveSampleEnumerator(mobjSampleEnumerator, intIEnumCollLocationSamp) == true) {
							mobjCurrentSample = (Method.clsAnalysisSampleParameters)mobjSampleEnumerator.Current;
						}
					}
					//--- Set Enumerator Analysis Standard Parameters
					if (mblnRepeatLastStd == false) {
						if (intIEnumCollLocationStd > gobjNewMethod.StandardDataCollection.Count) {
							intIEnumCollLocationStd = gobjNewMethod.StandardDataCollection.Count + 1;
						}
						if (funcMoveEnumerator(mobjStandardEnumerator, intIEnumCollLocationStd) == true) {
							mobjCurrentStandard = (Method.clsAnalysisStdParameters)mobjStandardEnumerator.Current;
						} else {
						}
					}
				}
			} else {
				//---else block is added on 28.04.08=========
				if (!(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex) == null)) {
					if (!gobjNewMethod.AnalysisParameters == null) {
						gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.IntegrationTime = gobjNewMethod.AnalysisParameters.IntegrationTime;
						gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.Unit = gobjNewMethod.AnalysisParameters.Unit;
					}

					//-----23.08.07
					//##### for standard parameters
					if ((!gobjNewMethod.StandardDataCollection == null)) {
						//gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection = gobjNewMethod.StandardDataCollection.Clone
						if (gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.Count > gobjNewMethod.StandardDataCollection.Count) {
							//---if method std count is less than quantitative std count then
							//---quantitative std which are used should be kept intact
							//---those quantitative std which are not used should be removed.

							intStdsToRemove = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.Count - gobjNewMethod.StandardDataCollection.Count;

							for (intCount = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.Count - 1; intCount >= 0; intCount += -1) {
								StandardData = new Method.clsAnalysisStdParameters();
								StandardData = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount).Clone;
								//gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount) = gobjNewMethod.StandardDataCollection.item(intCount).Clone
								if (intStdsRemoved < intStdsToRemove) {
									if (gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection(intCount).Used == false) {
										gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.RemoveAt(intCount);
										intStdsRemoved += 1;
									}
								} else {
									////----- Commented by Sachin Dokhale
									if (gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection(intCount).Used == false) {
										gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount) = gobjNewMethod.StandardDataCollection.item(intCount).Clone;
									}
									////----- Added by Sachin Dokhale

									if (!gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount).AbsRepeat == null) {
										clsAbsRepeatData absdata;
										for (intRepeatCounter = 0; intRepeatCounter <= StandardData.AbsRepeat.AbsRepeatData.Count - 1; intRepeatCounter++) {
											//gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount).AbsRepeat.AbsRepeatData(intRepeatCounter).Abs = StandardData.AbsRepeat.AbsRepeatData(intRepeatCounter).Abs   '---commented on 19.03.09
											//--------------'---added on 19.03.09
											absdata = new clsAbsRepeatData();
											absdata = StandardData.AbsRepeat.AbsRepeatData(intRepeatCounter).Clone;
											gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount).AbsRepeat.AbsRepeatData.Add(absdata);
											//-------------------
										}
										gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount).Used = StandardData.Used;
										gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount).Abs = StandardData.Abs;
										if (intRepeatCounter > 0) {
											CalculateAvgOfStd(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount));
										}
									} else {
										gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount).Used = StandardData.Used;
										gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount).Abs = StandardData.Abs;
									}
									////-----
								}
							}
							intStdsRemoved = 0;

						} else if (gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.Count == gobjNewMethod.StandardDataCollection.Count) {
							//---if quantitative std count is equal to that of method std count then
							//---update only those std which are not used.
							for (intCount = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.Count - 1; intCount >= 0; intCount += -1) {
								////----- Commented by Sachin Dokhale
								//If gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection(intCount).Used = False Then
								//gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount) = gobjNewMethod.StandardDataCollection.item(intCount).Clone
								//End If
								////----- Added by Sachin Dokhale
								//Dim StandardData As Method.clsAnalysisStdParameters
								StandardData = new Method.clsAnalysisStdParameters();
								StandardData = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount).Clone;
								gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount) = gobjNewMethod.StandardDataCollection.item(intCount).Clone;
								if (!gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount).AbsRepeat == null) {
									clsAbsRepeatData absdata;
									for (intRepeatCounter = 0; intRepeatCounter <= StandardData.AbsRepeat.AbsRepeatData.Count - 1; intRepeatCounter++) {
										//gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount).AbsRepeat.AbsRepeatData(intRepeatCounter).Abs = StandardData.AbsRepeat.AbsRepeatData(intRepeatCounter).Abs '---commented on 19.03.09
										//--------------'---added on 19.03.09
										absdata = new clsAbsRepeatData();
										absdata = StandardData.AbsRepeat.AbsRepeatData(intRepeatCounter).Clone;
										gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount).AbsRepeat.AbsRepeatData.Add(absdata);
										//-------------------
									}
									gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount).Used = StandardData.Used;
									gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount).Abs = StandardData.Abs;
									if (intRepeatCounter > 0) {
										CalculateAvgOfStd(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount));
									}
								} else {
									gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount).Used = StandardData.Used;
									gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount).Abs = StandardData.Abs;
								}
								////-----
							}

						} else if (gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.Count < gobjNewMethod.StandardDataCollection.Count) {
							//---if method std count is more than quantitative std count then
							//---quantitative std which are used should be kept intact.
							//---update quantitative std from method which are not used.
							//---add extra stds from method to quantitative list.
							//----Added by pankaj on 24 Jan 08
							intStdsToAdd = gobjNewMethod.StandardDataCollection.Count - gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.Count;
							for (intCount = 0; intCount <= gobjNewMethod.StandardDataCollection.Count - 1; intCount += 1) {
								if (intCount <= gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.Count - 1) {
									////----- Commented by Sachin Dokhale
									//If gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection(intCount).Used = False Then
									//    gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount) = gobjNewMethod.StandardDataCollection.item(intCount).Clone
									//End If
									////----- Added by Sachin Dokhale
									StandardData = new Method.clsAnalysisStdParameters();
									StandardData = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount).Clone;
									gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount) = gobjNewMethod.StandardDataCollection.item(intCount).Clone;
									if (!gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount).AbsRepeat == null) {
										clsAbsRepeatData absdata;
										for (intRepeatCounter = 0; intRepeatCounter <= StandardData.AbsRepeat.AbsRepeatData.Count - 1; intRepeatCounter++) {
											//gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount).AbsRepeat.AbsRepeatData(intRepeatCounter).Abs = StandardData.AbsRepeat.AbsRepeatData(intRepeatCounter).Abs   '---commented on 19.03.09
											//--------------'---added on 19.03.09
											absdata = new clsAbsRepeatData();
											absdata = StandardData.AbsRepeat.AbsRepeatData(intRepeatCounter).Clone;
											gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount).AbsRepeat.AbsRepeatData.Add(absdata);
											//-------------------
										}
										gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount).Used = StandardData.Used;
										gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount).Abs = StandardData.Abs;
										if (intRepeatCounter > 0) {
											CalculateAvgOfStd(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount));
										}
									} else {
										gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount).Used = StandardData.Used;
										gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount).Abs = StandardData.Abs;
									}
								////-----
								} else {
									gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.Add(gobjNewMethod.StandardDataCollection.item(intCount).Clone);
								}
							}
							//--
						}
					}
					StandardData = null;
				}
				//============================================28.04.08
			}

			//16.03.08
			if (gblnIsDemoWithRealData == true) {
				DataTable objele = new DataTable();
				string strEleName;
				objele = gobjClsAAS203.funcGetElement(gobjNewMethod.InstrumentCondition.ElementID);
				if (!objele == null) {
					if (objele.Rows.Count > 0) {
						strEleName = LCase(objele.Rows(0).Item("Name"));
					}
				}
				switch (strEleName) {
					case "cu":
						mintSelectedDemoFile = 1;
					case "pb":
						mintSelectedDemoFile = 2;
					case "zn":
						mintSelectedDemoFile = 3;
				}
			}
			//16.03.08

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

	private void btnImport_Click(object sender, System.EventArgs e)
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
		long intRunNumberIndex;
		int intCounter;
		int intCount;
		string strRunNo;
		frmLoadAnalysis objfrmLoadAnalysis = new frmLoadAnalysis();
		clsMethod objClsMethod;
		int intSelectedMethodID;
		long lngSelectedRunNumber;
		try {
			//tlbbtnLoad.SuspendEvents()

			// Restore the Row Data of Run no from Data result collection object

			objfrmLoadAnalysis.GroupBox2.Visible = true;
			objfrmLoadAnalysis.btnDeleteRun.Visible = false;
			objfrmLoadAnalysis.gbMultiElementReport.Visible = false;
			if (objfrmLoadAnalysis.ShowDialog() == DialogResult.Cancel) {
				return;
			}

			intSelectedMethodID = objfrmLoadAnalysis.SelectedMethodID;
			lngSelectedRunNumber = objfrmLoadAnalysis.SelectedRunNumber;
			objfrmLoadAnalysis.Close();
			objfrmLoadAnalysis.Dispose();
			////-----
			mobjAnalysisRawData = null;
			mobjAnalysisRawData = new Analysis.clsRawDataCollection();

			mobjBlankRawData = null;
			mobjStandardRawData = null;
			mobjSampleRawData = null;

			intRunNumberIndex = modGlobalFunctions.gfuncGetSelectedMethodRunNumberIndex(mintSelectedMethodID, mlngSelectedRunNumber);

			for (intCounter = 0; intCounter <= gobjMethodCollection.Count - 1; intCounter++) {

				if (gobjMethodCollection.item(intCounter).MethodID == intSelectedMethodID) {
					//mobjClsMethod = gobjMethodCollection.item(intCounter).Clone()

					//mobjClsMethod.QuantitativeDataCollection.Item(intRunNumberIndex).AnalysisRawData(0).SampleType = clsRawData.enumSampleType.BLANK
					//Dim int As Integer
					for (intRunNumberIndex = 0; intRunNumberIndex <= gobjMethodCollection.item(intCounter).QuantitativeDataCollection.Count - 1; intRunNumberIndex++) {

						if (lngSelectedRunNumber == gobjMethodCollection.item(intCounter).QuantitativeDataCollection.Item(intRunNumberIndex).RunNumber) {
							Afirst = false;


							break; // TODO: might not be correct. Was : Exit For

						}

					}
					int i;
					intIEnumCollLocationStd = 0;
					intIEnumCollLocationSamp = 0;
					for (i = 0; i <= gobjMethodCollection.item(intCounter).QuantitativeDataCollection.Item(intRunNumberIndex).AnalysisRawData.Count - 1; i++) {
						mobjAnalysisRawData.Add(gobjMethodCollection.item(intCounter).QuantitativeDataCollection.Item(intRunNumberIndex).AnalysisRawData(i));
						//mobjClsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisRawData = mobjAnalysisRawData
						if (gobjMethodCollection.item(intCounter).QuantitativeDataCollection.Item(intRunNumberIndex).AnalysisRawData(i).SampleType == clsRawData.enumSampleType.SAMPLE) {
							intIEnumCollLocationSamp += 1;
						} else if (gobjMethodCollection.item(intCounter).QuantitativeDataCollection.Item(intRunNumberIndex).AnalysisRawData(i).SampleType == clsRawData.enumSampleType.STANDARD) {
							intIEnumCollLocationStd += 1;
						}
					}

					////----

					mobjCurrentStandard = null;
					mobjCurrentSample = null;
					if (intIEnumCollLocationSamp <= 0) {
						//mobjCurrentStandard = gobjMethodCollection.item(intCounter).QuantitativeDataCollection(intRunNumberIndex).StandardDataCollection(intIEnumCollLocationStd - 1)
						funcGetCurrentStandard(mobjCurrentStandard);
					} else {
						//mobjCurrentSample = gobjMethodCollection.item(intCounter).QuantitativeDataCollection(intRunNumberIndex).SampleDataCollection(intIEnumCollLocationSamp - 1)
						funcGetCurrentSample(mobjCurrentSample);
					}



					int i1 = gobjMethodCollection.item(intCounter).QuantitativeDataCollection.Item(intRunNumberIndex).AnalysisRawData(i - 1).Readings.Count - 1;

					mobjBgReadData.CEndTime = gobjMethodCollection.item(intCounter).QuantitativeDataCollection(intRunNumberIndex).AnalysisRawData(i - 1).Readings(i1).XTime;
					mEndTime = mobjBgReadData.CEndTime;
					SampleType = gobjMethodCollection.item(intCounter).QuantitativeDataCollection.Item(intRunNumberIndex).AnalysisRawData(i - 1).SampleType;
					NextAnalysis_Clicked(btnNextAnalysis, EventArgs.Empty);
					Application.DoEvents();
					Aspirate();
					Application.DoEvents();
					////----- Sachin Dokhale
					//StdAnalysed=TRUE;
					//toreported=TRUE;
					//InvalidateRect(hwnd, NULL, TRUE);
					//EnableWindow(GetDlgItem(hwnd,IDC_SAVEREPORT), StdAnalysed);
					StdAnalysed = true;
					toreported = true;
					btnSave.Enabled = StdAnalysed;
					////-----



					//Call funcShowMethodGeneralInfo(mobjClsMethod, strRunNo)
					switch (gobjMethodCollection.item(intCounter).OperationMode) {
						case EnumOperationMode.MODE_UVABS:
							AASGraphAnalysis.Visible = false;
						default:
							strRunNo = gobjMethodCollection.item(intCounter).QuantitativeDataCollection.Item(intRunNumberIndex).RunNumber;
							AASGraphAnalysis.Visible = true;
							gobjClsAAS203.subShowGraphPreview(this.AASGraphAnalysis, mobjGraphCurve, strRunNo, gobjMethodCollection.item(intCounter));
							AASGraphAnalysis.Invalidate();
							AASGraphAnalysis.IsShowGrid = true;
							//Saurabh To show Grid 19.07.07
							AASGraphAnalysis.Refresh();
							this.Refresh();
							Application.DoEvents();
					}


					break; // TODO: might not be correct. Was : Exit For

				}
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
			if (!objWait == null) {
				objWait.Dispose();
			}
			//tlbbtnLoad.ResumeEvents()
			//---------------------------------------------------------
		}
	}

	private void btnIgnite_Click(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : btnIgnite_Click
		// Parameters Passed     : Object, EventArgs
		// Returns               : 
		// Purpose               : Ignite the flame
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S & Sachin Dokhale
		// Created               : 05.10.06
		// Revisions             : 
		//=====================================================================
		if (mblnAvoidProcessing == true) {
			return;
		}

		try {
			mblnAvoidProcessing = true;
			// this event Terminate required Thread and start the auto ignition process for AA Flame
			gobjMain.AutoIgnition();
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
			//objWait.Dispose()
			//---------------------------------------------------------
		}

	}

	private void btnExtinguish_Click(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : btnExtinguish_Click
		// Parameters Passed     : Object, EventArgs
		// Returns               : 
		// Purpose               : Extinguish the flame
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S & Sachin Dokhale
		// Created               : 05.10.06
		// Revisions             : 
		//=====================================================================
		if (mblnAvoidProcessing == true) {
			return;
		}
		try {
			mblnAvoidProcessing = true;

			// this event Extinguish the flame 
			gobjMain.Extinguish();
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
			//objWait.Dispose()
			//---------------------------------------------------------
		}

	}

	private void btnN2OIgnite_Click(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : btnN2OIgnite_Click
		// Parameters Passed     : Object, EventArgs
		// Returns               : 
		// Purpose               : Ignite the N2O flame
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S & Sachin Dokhale
		// Created               : 05.10.06
		// Revisions             : 
		//=====================================================================
		if (mblnAvoidProcessing == true) {
			return;
		}
		try {
			mblnAvoidProcessing = true;

			// this event Terminate required Thread and start the auto ignition process for N2O Flame
			// Switch to N2O to Air 
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

	private void btnExportReport_Click(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : tlbbtnExportReport_Click
		// Parameters Passed     : Object, EventArgs
		// Returns               : 
		// Purpose               : 
		// Description           : Send the data result to the RTF format
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S & Sachin Dokhale
		// Created               : 05.10.06
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		int intSelectId;
		int intCount;
		int intCount1;
		double[] A1 = {
			0,
			0,
			0,
			0,
			0,
			0
		};
		try {
			//Added By Pankaj Fri 18 May 07
			// this block use to check the if Enabel 21 CFR
			if ((gstructSettings.Enable21CFR == true)) {
				if (!funcCheckActivityAuthentication(enumActivityAuthentication.Export, gstructUserDetails.Access)) {
					return;
					return;
				}
				gfuncInsertActivityLog(EnumModules.Export, "Export Accessed");
			}

			// Check whether Data Result is ready to report 
			//OR NOT Method->RepReady )
			if ((toreported)) {
				if (gobjClsAAS203.SaveQuantResults(gobjNewMethod, A1, 1, false) == true) {
					mblnIsStartRunNumber = true;
				}
				toreported = false;
				//mblnIsStartRunNumber = True
			}
			//Or ManualEntry Then
			if (StdAnalysed | AnaOver | mblnIsAnalysisStarted) {
				//Select required Run No to export data result from data collection object
				for (intCount = 0; intCount <= gobjMethodCollection.Count - 1; intCount++) {
					//If mintSelectedMethodID = gobjMethodCollection(intCount).MethodID Then
					if (gobjNewMethod.MethodID == gobjMethodCollection(intCount).MethodID) {
						//intSelectIDIndex = intCount
						intSelectId = intCount;
						//mobjClsDataFileReport.MethodID = intCount
						mobjClsDataFileReport.MethodID = gobjMethodCollection(intCount).MethodID;
						for (intCount1 = 0; intCount1 <= gobjMethodCollection(intSelectId).QuantitativeDataCollection.Count - 1; intCount1++) {
							if (mlngSelectedRunNumber == (int)gobjMethodCollection(intSelectId).QuantitativeDataCollection(intCount1).RunNumber) {
								// Set requierd Run No and perticulat Run No object to the Report object
								mobjClsDataFileReport.RunNumber = mlngSelectedRunNumber;
								mobjClsDataFileReport.funcDatafileExport(gobjMethodCollection(intSelectId).QuantitativeDataCollection(intCount1).ReportParameters);
								break; // TODO: might not be correct. Was : Exit For
							}
						}
						break; // TODO: might not be correct. Was : Exit For
					}
				}
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
			if (!objWait == null) {
				objWait.Dispose();
			}
			//---------------------------------------------------------
		}
	}


	#End Region

	#Region " Public Functions "

	public void StartNewAnalysis()
	{
		//=====================================================================
		// Procedure Name        : StartNewAnalysis
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : To Start new analysis
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 20-Feb-2007 03:00 pm
		// Revisions             : 1
		//=====================================================================
		int intValid;

		try {
			mController = new clsBgThread(this);
			mobjBgReadData.Initialize(mController);
			//--- Set Aspiration Message
			mstrAspirationMessage = "Click Start button to Start Analysis.";
			mobjBgMsgAspirate.AspirationMessage = mstrAspirationMessage;

			//gobjclsStandardGraph = New clsStandardGraph
			////----- Added by Sachin Dokhale 
			////--- Previous Standard
			if (blnIsLoadPreviousStandards == false) {
				gobjclsStandardGraph = new clsStandardGraph();
			} else {
				if (gobjclsStandardGraph == null) {
					gobjclsStandardGraph = new clsStandardGraph();
				}
			}
			////-----
			//--- Return Method Status in integer
			intValid = CheckMethod();
			if ((intValid == 2)) {
				//Init. analysis parameters
				InitAnalysis();
			}
			mblnIsAnalysisStarted = false;
			//--- Set parameter for NEw analysis
			NewAnalysis_Clicked(btnNewAnalysis, EventArgs.Empty);

			btnEditData.Enabled = false;

			mintAspirationTimerCounter = 0;

			////----- Commented by Sachin Dokhale
			////----- use Thread except timer for aspirate message
			mobjBgMsgAspirate.Start();
			IsDisplayingMessage = mobjBgMsgAspirate.IsMessageRunning;

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

	public void CheckAnaButtons()
	{
		//=====================================================================
		// Procedure Name        : CheckAnaButtons
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : To set buttons enable/disable, and show the 
		//                           messages accordingly.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 15-Dec-2006
		// Revisions             : 1
		//=====================================================================


		//AAS 16-Bit Software Code

		//'void	CheckAnaButtons(HWND hwnd)
		//'{
		//' if (Started){
		//'	ANALYSIS = TRUE;
		//'	SetShortHelp("", FALSE);
		//'	SetShortHelp(" Click End Analysis button to Stop the Analysis", TRUE);
		//'//	EnableWindow(GetDlgItem(hwnd, IDC_QAREPORT),FALSE);
		//'	}
		//' else{
		//'	SetShortHelp(" Click START button to start Analysis", TRUE);
		//'//	EnableWindow(GetDlgItem(hwnd, IDC_QAREPORT),TRUE);
		//'	ANALYSIS = FALSE;
		//'	}
		//'  //---mdf by sk on 29/2/2000 for autosampler
		//'  If (Autosampler & Started) Then
		//'	 EnableWindow(GetDlgItem(hwnd, IDC_QAREAD), FALSE);
		//'  else   //--mdf by sk on 29/2/2000 for autosampler
		//'// EnableWindow(GetDlgItem(hwnd, IDC_QAREAD), Started);
		//' EnableWindow(GetDlgItem(hwnd, IDC_QAREAD), Started);
		//' EnableWindow(GetDlgItem(hwnd, IDC_QANEXT),Started);
		//' EnableWindow(GetDlgItem(hwnd, IDC_BLANK),Started);
		//' EnableWindow(GetDlgItem(hwnd, IDC_QARPT),Started);
		//' EnableWindow(GetDlgItem(hwnd, IDC_QANEW),Started);
		//' EnableWindow(GetDlgItem(hwnd, IDC_QASAMP),Started);
		//'}
		//****************************************************************************************
		try {
			//To set buttons enable/disable, and show the 
			//messages accordingly.
			if ((mblnIsAnalysisStarted)) {
				ANALYSIS = true;
				//---Show Blinking Message
				Aspirate();
			} else {
				ANALYSIS = false;
			}

			if ((mblnIsAutosampler & mblnIsAnalysisStarted)) {
				btnReadData.Enabled = false;
			} else {
				btnReadData.Enabled = mblnIsAnalysisStarted;
			}

			//tlbbtnNextAnalysis.Enabled = mblnIsAnalysisStarted
			//tlbbtnBlankAnalysis.Enabled = mblnIsAnalysisStarted
			//tlbbtnRepeatLastAnalysis.Enabled = mblnIsAnalysisStarted
			//tlbbtnNewAnalysis.Enabled = mblnIsAnalysisStarted

			btnNextAnalysis.Enabled = mblnIsAnalysisStarted;
			btnBlankAnalysis.Enabled = mblnIsAnalysisStarted;
			btnRepeatLast.Enabled = mblnIsAnalysisStarted;
			btnNewAnalysis.Enabled = mblnIsAnalysisStarted;

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

	public void CheckInstrumentOptimisation()
	{
		//=====================================================================
		// Procedure Name        : CheckInstrumentOptimisation
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : To check and perform Instrument Optimization
		// Description           : Finds analytical OR Emmision Peak
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 01.12.06
		// Revisions             : 
		//=====================================================================

		//--- ORIGINAL CODE 

		//'void	CheckInstrumentOptimisation(HWND hwnd)
		//'{
		//'char line1[20]="";
		//'if (Method){
		//'  if (Method->Mode==MODE_UVABS &&  Method->Aas.Wv !=Get_Cur_Wv())
		//'	    Method->Aas.OptimseFlag=FALSE;
		//'  if (!Method->Aas.OptimseFlag){
		//'	    if ((Method->Mode==MODE_AA || Method->Mode==MODE_AABGC ||
		//'			 Method->Mode==MODE_SPECT)
		//'		    &&  (Method->Aas.LampNo>=0 && Method->Aas.LampNo<=5) )
		//'	    {
		//'	        ResetAnaMode(Method->Aas.LampNo);
		//'		    Method->Aas.OptimseFlag=Find_Analytical_Peak(hwnd, Method->Aas.LampNo);
		//'	    }
		//'	    else if (Method->Mode==MODE_EMISSION)
		//'	        Method->Aas.OptimseFlag=Find_Emmission_Peak(hwnd);
		//'	    else if (Method->Mode==MODE_UVABS)
		//'	        SetRest_uvs_Condn(hwnd, Method->Aas.Wv, TRUE, 87, 284);
		//'  }
		//'}
		//'sprintf(line1,"%0.2f nm",Get_Cur_Wv());
		//'SetWindowText(GetDlgItem(hwnd,IDC_UVWV),line1);
		//'}
		//***************************************************************
		double dblSelectedWavelength;
		int intRowCounter;
		int intInstrumentIndex;


		try {
			////----- Commented by Sachin Dokhale
			////----- use Thread except timer for aspirate message
			//tmrAspirationMsg.Enabled = False
			if (!IsNothing(mobjBgMsgAspirate)) {
				mobjBgMsgAspirate.Cancel();
				IsDisplayingMessage = mobjBgMsgAspirate.IsMessageRunning;
			}

			gobjMain.mobjController.Cancel();
			gobjCommProtocol.mobjCommdll.subTime_Delay(500);
			//10.12.07
			Application.DoEvents();

			//dblSelectedWavelength = gfuncGetSelectedUVElementWavelength(gobjNewMethod.InstrumentCondition)

			if (!IsNothing(gobjNewMethod)) {
				//---Gets Current Wavelength from Instrument.
				if ((gobjNewMethod.OperationMode == EnumOperationMode.MODE_AA | gobjNewMethod.OperationMode == EnumOperationMode.MODE_AABGC | gobjNewMethod.OperationMode == EnumOperationMode.MODE_SPECT | gobjNewMethod.OperationMode == EnumOperationMode.MODE_EMMISSION)) {
					gobjCommProtocol.funcGet_Current_Wv(gobjInst.WavelengthCur);
				}

				//---Assign the Lamp Number as Turret Number as Both are same
				gobjNewMethod.InstrumentCondition.LampNumber = gobjNewMethod.InstrumentCondition.TurretNumber;

				if (!IsNothing(gobjNewMethod.InstrumentCondition)) {
					if ((gobjNewMethod.OperationMode == EnumOperationMode.MODE_UVABS)) {
						dblSelectedWavelength = gfuncGetSelectedUVElementWavelength(gobjNewMethod.InstrumentCondition);
					} else {
						dblSelectedWavelength = gfuncGetSelectedElementWavelength(gobjNewMethod.InstrumentCondition);
					}

					if ((gobjNewMethod.OperationMode == EnumOperationMode.MODE_EMMISSION)) {
						dblSelectedWavelength = gobjNewMethod.InstrumentCondition.EmmWavelength;
					}

					if ((gobjNewMethod.OperationMode == EnumOperationMode.MODE_UVABS & dblSelectedWavelength != gobjInst.WavelengthCur)) {
						gobjNewMethod.InstrumentCondition.IsOptimize = false;
					}

					if (!(gobjNewMethod.InstrumentCondition.IsOptimize)) {

						if (((gobjNewMethod.OperationMode == EnumOperationMode.MODE_AA | gobjNewMethod.OperationMode == EnumOperationMode.MODE_AABGC | gobjNewMethod.OperationMode == EnumOperationMode.MODE_SPECT) & (gobjNewMethod.InstrumentCondition.LampNumber >= 1 & gobjNewMethod.InstrumentCondition.LampNumber <= 6))) {
							ResetAnaMode(gobjNewMethod.InstrumentCondition.LampNumber);

							//----Finds the Analytical Peak ...
							gobjNewMethod.InstrumentCondition.IsOptimize = gobjClsAAS203.Find_Analytical_Peak(gobjNewMethod.InstrumentCondition.LampNumber, mdblWvOpt, lblOptimizedWavelength);


						} else if ((gobjNewMethod.OperationMode == EnumOperationMode.MODE_EMMISSION)) {
							//----Finds the Emission Peak ...
							gobjNewMethod.InstrumentCondition.IsOptimize = gobjClsAAS203.Find_Emmission_Peak();

						} else if ((gobjNewMethod.OperationMode == EnumOperationMode.MODE_UVABS)) {
							bool blnUVFlag;
							//blnUVFlag = True
							//if gobjMain.

							gobjClsAAS203.funcSetRest_uvs_Condn(dblSelectedWavelength, true, lblUVWavelength, blnUVFlag);
						}
					}
				}
			}

			//'sprintf(line1,"%0.2f nm",Get_Cur_Wv());
			//'SetWindowText(GetDlgItem(hwnd,IDC_UVWV),line1);
			gobjCommProtocol.funcGet_Current_Wv(gobjInst.WavelengthCur);
			lblOptimizedWavelength.Text = "Optimized Wavelength : " + FormatNumber(gobjInst.WavelengthCur.ToString, 2) + " nm";
			//---02.02.09

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
			////----- Commented by Sachin Dokhale
			////----- use Thread except timer for aspirate message
			//tmrAspirationMsg.Enabled = True
			if (!IsNothing(mobjBgMsgAspirate)) {
				mobjBgMsgAspirate.Start();
				IsDisplayingMessage = mobjBgMsgAspirate.IsMessageRunning;
			}
			if (gobjMain.mobjController.IsThreadRunning == false) {
				gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay);
				Application.DoEvents();
				gobjMain.mobjController.Start(gobjclsBgFlameStatus);
			}
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	#End Region

	#Region " Aspiration Related Functions "

	private void StartAspirationThread(int intStartTime, int intEndTime)
	{
		//=====================================================================
		// Procedure Name        : StartAspirationThread
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : Start Aspiration thread
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 17-Jan-2007 03:25 pm
		// Revisions             : 1
		//=====================================================================
		System.DateTime dtMinTime;
		System.DateTime dtMaxTime;
		int intOLDStartTime;
		int intOLDEndTime;
		// Start the Analysis Thread
		try {
			//check the Analysis Thread for not UV Mode 
			////---- Modified by Sachin Dokhale on 30.07.07
			if (!(gobjNewMethod.OperationMode == EnumOperationMode.MODE_UVABS)) {
				mobjBgReadData = new clsBgReadData(intStartTime, intEndTime, SampleType, mobjCurrentStandard, mobjCurrentSample);
			}
			////-----
			// use Filter setting to Thread
			mobjBgReadData.Filter_flag = Filter_flag;
			//add eventsetting handler
			mobjBgReadData.AbsorbanceValueChanged += mobjBgReadData_AbsorbanceValueChanged;
			mobjBgReadData.AspirationMessageChanged += mobjBgReadData_AspirationMessageChanged;
			// Check for UV ABS Mode

			if (!(gobjNewMethod.OperationMode == EnumOperationMode.MODE_UVABS)) {
				if (Afirst) {
					//'AASGraphAnalysis.AldysPane.XAxis.StepAuto = True
					//'AASGraphAnalysis.AldysPane.XAxis.MinorStepAuto = True
					//'AASGraphAnalysis.AldysPane.XAxis.PickScale(AASGraphAnalysis.XAxisMin, AASGraphAnalysis.XAxisMax)
					//'AASGraphAnalysis.AldysPane.YAxis.StepAuto = True
					//'AASGraphAnalysis.AldysPane.YAxis.MinorStepAuto = True
					//'AASGraphAnalysis.AldysPane.YAxis.PickScale(AASGraphAnalysis.YAxisMin, AASGraphAnalysis.YAxisMax)
				}
			}
			////---- Modified by Sachin Dokhale on 30.07.07
			if (!(mobjBgReadData == null)) {
				// Init. Read Data thread
				mobjBgReadData.Initialize(mController);
				mobjBgReadData.SampleType = SampleType;
				//mobjBgReadData.SampleType = Me.SampleType
				// Start to read data from instrument through thread 
				gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay);
				//10.12.07
				Application.DoEvents();
				mController.Start(mobjBgReadData);
			}
		////-----
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

	private void mobjBgReadData_AbsorbanceValueChanged(double dblAbs)
	{
		//=====================================================================
		// Procedure Name        : mobjBgReadData_AbsorbanceValueChanged
		// Parameters Passed     : dblAbs as absorbance.
		// Returns               : None
		// Purpose               : thread events throw the abs
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 17-Jan-2007 03:25 pm
		// Revisions             : 1
		//=====================================================================
		try {
			//lblAbsorbance.Text = Format(dblAbs, "0.000")   'Commented by Saurabh 01.08.07
			//--- Show the Absorbance label
			if (gobjNewMethod.OperationMode == EnumOperationMode.MODE_EMMISSION) {
				lblAbsorbance.Text = FormatNumber(dblAbs, 1);
			} else {
				lblAbsorbance.Text = FormatNumber(dblAbs, 3);
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

	private void mobjBgReadData_AspirationMessageChanged(string strNewMessage, bool blnIsBlink)
	{
		//=====================================================================
		// Procedure Name        : mobjBgReadData_AspirationMessageChanged
		// Parameters Passed     : strNewMessage As String, blnIsBlink as bool
		// Returns               : None
		// Purpose               : thread events throw Aspiration Message 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 17-Jan-2007 03:25 pm
		// Revisions             : 1
		//=====================================================================
		try {
			mstrAspirationMessage = strNewMessage;
			mblnIsBlinkMessage = blnIsBlink;
			mobjBgMsgAspirate.AspirationMessage = mstrAspirationMessage;
			mobjBgMsgAspirate.IsBlinkMessage = blnIsBlink;

			if (btnReadData.Enabled == true) {
				btnReadData.Focus();
			}


			if (mstrAspirationMessage == "Reading Wait ...") {
				gobjCommProtocol.mobjCommdll.subTime_Delay(2000);
			}
			if (btnReadData.Enabled == true) {
				btnReadData.Focus();
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

	private void AddInAnalysisRawData(double xValue, double yValue)
	{
		//=====================================================================
		// Procedure Name        : AddInAnalysisRawData
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : Add the Row Data Result into the Analysis Raw Data collection object
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 25-Jan-2007 12:45 pm
		// Revisions             : 1
		//=====================================================================
		string strSampleName;
		Color curveColor;
		static int intStCurRepeat;
		try {
			//---Add Each Raw Data in the Analysis Raw Data Collection
			// Check for each Data result if type Blank/Std/Samp
			switch (this.SampleType) {
				//mobjBgReadData.SampleType
				case clsRawData.enumSampleType.BLANK:
					//---For Blank
					if (mobjBlankRawData == null) {
						mobjBlankRawData = new Analysis.clsRawData();
					}
					mobjBlankRawData.SampleID = 0;
					mobjBlankRawData.SampleType = clsRawData.enumSampleType.BLANK;
					mobjBlankRawData.SampleName = "BLANK";
					strSampleName = "BLANK";
					curveColor = ClsAAS203.BLANKCOLOR;
					mobjBlankRawData.AddReadings(xValue, yValue);
				//mobjAnalysisRawData.Add(mobjBlankRawData)

				case clsRawData.enumSampleType.STANDARD:
					if (!IsNothing(mobjCurrentStandard)) {
						//--- For Standard
						if (IsNothing(mobjStandardRawData)) {
							mobjStandardRawData = new Analysis.clsRawData();
						}

						if (CurRepeat > 1) {
							if (!(intStCurRepeat == CurRepeat)) {
								mobjStandardRawData = new Analysis.clsRawData();
								intStCurRepeat = CurRepeat;
							}
						} else {
							intStCurRepeat = 0;
						}

						if ((mobjStandardRawData.SampleID == mobjCurrentStandard.StdNumber)) {
							mobjStandardRawData.SampleID = mobjCurrentStandard.StdNumber;
							mobjStandardRawData.SampleName = mobjCurrentStandard.StdName;
							mobjStandardRawData.SampleType = clsRawData.enumSampleType.STANDARD;
							strSampleName = mobjCurrentStandard.StdName;
							curveColor = ClsAAS203.STDCOLOR;
							mobjStandardRawData.AddReadings(xValue, yValue);
						} else {
							mobjStandardRawData = new Analysis.clsRawData();
							mobjStandardRawData.SampleID = mobjCurrentStandard.StdNumber;
							mobjStandardRawData.SampleName = mobjCurrentStandard.StdName;
							mobjStandardRawData.SampleType = clsRawData.enumSampleType.STANDARD;
							strSampleName = mobjCurrentStandard.StdName;
							curveColor = ClsAAS203.STDCOLOR;
							mobjStandardRawData.AddReadings(xValue, yValue);
							//mobjAnalysisRawData.Add(mobjStandardRawData)
						}


					}
				case clsRawData.enumSampleType.SAMPLE:
					if (!IsNothing(mobjCurrentSample)) {
						//---For Sample
						if (IsNothing(mobjSampleRawData)) {
							mobjSampleRawData = new Analysis.clsRawData();
						}

						if (CurRepeat > 1) {
							if (!(intStCurRepeat == CurRepeat)) {
								mobjSampleRawData = new Analysis.clsRawData();
								intStCurRepeat = CurRepeat;
							}
						} else {
							intStCurRepeat = 0;
						}

						if (mobjSampleRawData.SampleID == mobjCurrentSample.SampNumber) {
							mobjSampleRawData.SampleID = mobjCurrentSample.SampNumber;
							mobjSampleRawData.SampleName = mobjCurrentSample.SampleName;
							mobjSampleRawData.SampleType = clsRawData.enumSampleType.SAMPLE;
							strSampleName = mobjCurrentSample.SampleName;
							curveColor = ClsAAS203.SAMPCOLOR;
							mobjSampleRawData.AddReadings(xValue, yValue);
						} else {
							mobjSampleRawData = new Analysis.clsRawData();
							mobjSampleRawData.SampleID = mobjCurrentSample.SampNumber;
							mobjSampleRawData.SampleName = mobjCurrentSample.SampleName;
							mobjSampleRawData.SampleType = clsRawData.enumSampleType.SAMPLE;
							strSampleName = mobjCurrentSample.SampleName;
							curveColor = ClsAAS203.SAMPCOLOR;
							mobjSampleRawData.AddReadings(xValue, yValue);
							//mobjAnalysisRawData.Add(mobjSampleRawData)
						}
					}
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

	#Region " Background Thread IClient Implementation Functions "

	public void BgThread.Iclient.Start(BgThread.clsBgThread clsBgThread)
	{
		//=====================================================================
		// Procedure Name        : Start
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 17-Jan-2007 03:25 pm
		// Revisions             : 1
		//=====================================================================

		try {
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

	public void BgThread.Iclient.Completed(bool Cancelled)
	{
		//=====================================================================
		// Procedure Name        : Completed
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 17-Jan-2007 03:25 pm
		// Revisions             : 1
		//=====================================================================
		double dblAbsorbance;
		double[] A1 = {
			0,
			0,
			0,
			0,
			0,
			0
		};

		try {
			////----- Added by Sachin Dokhale 
			////----- to Save Raw Data collection
			mblnAvoidProcessing = true;
			switch (this.SampleType) {
				case ClsAAS203.enumSampleType.BLANK:
					if (!(mobjBlankRawData == null)) {
						mobjAnalysisRawData.Add(mobjBlankRawData);
						mobjBlankRawData = null;
					}
				case ClsAAS203.enumSampleType.SAMPLE:
					if (!(mobjSampleRawData == null)) {
						mobjAnalysisRawData.Add(mobjSampleRawData);
						mobjSampleRawData = null;
					}
				case ClsAAS203.enumSampleType.STANDARD:
					if (!(mobjStandardRawData == null)) {
						mobjAnalysisRawData.Add(mobjStandardRawData);
						mobjStandardRawData = null;
					}
			}
			////-----
			//Save Row data into file system
			SaveRawDataFile();

			if ((gobjNewMethod.OperationMode == EnumOperationMode.MODE_UVABS)) {
				if (!Cancelled) {
					//--- Store, calculate and Display Quantitative
					StoreCalculateDisplayQuantValueUvMode(mobjBgReadData.UVAbsorbance);
				}
			} else {
				//--- Store, calculate and Display Quantitative
				dblAbsorbance = StoreCalculateDisplayQuantValue();
			}
			//--- Check and validate analysis data
			if ((SampleType == ClsAAS203.enumSampleType.STANDARD)) {
				if (!clsStandardGraph.CheckValidStdAbsEntry(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection)) {
					//If Not clsStandardGraph.CheckValidStdAbsEntry(mobjCurrentStandard) Then
					//gobjMessageAdapter.ShowMessage("Absorbance of the standard is less than or equal to the previous standard." & vbCrLf & _
					//"Press 'Repeat Last' button for aspirating the same standard again.", _
					//"Standard Aspiration Error", MessageHandler.clsMessageHandler.enumMessageType.ErrorMessage)
					mblnGetStandards = false;
					gobjMessageAdapter.ShowMessage(constStandardAbsorbance);
					Application.DoEvents();
				} else {
					mblnGetStandards = true;
				}
			}

			if ((SampleType == ClsAAS203.enumSampleType.SAMPLE)) {
				//If Not clsStandardGraph.CheckValidSampAbsEntry(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection, mdblAbsorbance) Then
				//04.02.09
				if (!clsStandardGraph.CheckValidSampAbsEntry(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection, dblAbsorbance)) {

					//If Not clsStandardGraph.CheckValidSampAbsEntry(mobjCurrentSample, mdblAbsorbance) Then

					//gobjMessageAdapter.ShowMessage("Absorbance of the sample is more than the maximum standard value." & vbCrLf & _
					//"Calculated Concentration may not be correct." & vbCrLf & _
					//"Please dilute the sample and repeat again." & vbCrLf & _
					// "Press RepeatLast button when ready.", "Sample Aspiration Error", _
					//  MessageHandler.clsMessageHandler.enumMessageType.ErrorMessage)

					gobjMessageAdapter.ShowMessage(constSampleAbsorbance);
					Application.DoEvents();
				}
			}

			//btnReadData.Enabled = True
			// Remove Read Data haldlser 
			mobjBgReadData.AbsorbanceValueChanged -= mobjBgReadData_AbsorbanceValueChanged;
			mobjBgReadData.AspirationMessageChanged -= mobjBgReadData_AspirationMessageChanged;

			//SendMessage(hwnd, WM_COMMAND, 900, 0L) '//IDC_QANEXT, 0L);
			//--- Prepare Next analysis 
			NextAnalysis_Clicked(btnNextAnalysis, EventArgs.Empty);

			if (AnaOver) {
				btnRepeatLast.Enabled = false;
			}
			// Add handler for Read Data
			//AddHandler btnReadData.Click, AddressOf ReadData_Click

			//mblnAvoidProcessing = False
			Application.DoEvents();
			//--- Start Flame Status window
			if (gobjMain.mobjController.IsThreadRunning == false) {
				gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay);
				Application.DoEvents();
				gobjMain.mobjController.Start(gobjclsBgFlameStatus);
			}
			mblnAvoidProcessing = false;
			Application.DoEvents();
			// Continue the Read Data process for next analysis 
			//by Pankaj for autosampler on 03 Oct 07
			if ((mblnIsAutosampler & mblnIsAnalysisStarted)) {
				//SendMessage(hwnd, WM_COMMAND, IDC_QAREAD, 0L)
				mblnAvoidProcessing = false;
				ReadData_Click(btnReadData, EventArgs.Empty);
			} else {
				// Add handler for Read Data
				btnReadData.Click += ReadData_Click;
				Application.DoEvents();
			}
			//Call Aspirate()
			gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay);
			//10.12.07
		//' Add handler for Read Data
		//AddHandler btnReadData.Click, AddressOf ReadData_Click
		//Application.DoEvents()

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

	//Public Sub Display(ByVal Text As String) Implements BgThread.Iclient.Display
	//    '=====================================================================
	//    ' Procedure Name        : Display
	//    ' Parameters Passed     : Text
	//    ' Returns               : None
	//    ' Purpose               : 
	//    ' Description           : 
	//    ' Assumptions           : 
	//    ' Dependencies          : 
	//    ' Author                : Mangesh Shardul
	//    ' Created               : 17-Jan-2007 03:25 pm
	//    ' Revisions             : 1
	//    '=====================================================================
	//    Dim strData As String
	//    Dim arrData() As String
	//    Dim xValue, yValue As Double
	//    Dim strSampleName As String
	//    Dim curveColor As Color
	//    Try
	//        If gobjNewMethod.OperationMode = EnumOperationMode.MODE_UVABS Then
	//            lblUVAbsorbance.Text = "Absorbance : " & FormatNumber(Text, 2)
	//            Call AddInAnalysisRawData(xValue, yValue)
	//            Exit Sub
	//        Else
	//            arrData = Text.Split(",")
	//            xValue = Val(arrData(0))
	//            yValue = Val(arrData(1))
	//        End If

	//        '---Display Real Point of Reading
	//        'If intIsReal = 1 Then
	//        '---Display Abs Value on screen
	//        lblAbsorbance.Text = Format(yValue, "0.000")
	//        '---Add only Real Point in the Analysis Raw Data Structure
	//        Call AddInAnalysisRawData(xValue, yValue)
	//        'End If

	//        '---Draw Line
	//        '---Add single Curve Item for all lines
	//        strSampleName = "Aspiration Curve"
	//        Select Case Me.SampleType
	//            Case ClsAAS203.enumSampleType.BLANK
	//                curveColor = ClsAAS203.BLANKCOLOR
	//            Case ClsAAS203.enumSampleType.STANDARD
	//                curveColor = ClsAAS203.STDCOLOR
	//            Case ClsAAS203.enumSampleType.SAMPLE
	//                curveColor = ClsAAS203.SAMPCOLOR
	//        End Select

	//        If (Afirst) Then
	//            Afirst = False
	//            mobjGraphCurve = AASGraphAnalysis.StartOnlineGraph(strSampleName, Color.Black, AldysGraph.SymbolType.NoSymbol, True)
	//            AASGraphAnalysis.PlotPoint(mobjGraphCurve, xValue, yValue, True)
	//        Else
	//            mobjGraphCurve.CL.Add(curveColor)
	//            AASGraphAnalysis.PlotPoint(mobjGraphCurve, xValue, yValue, True)
	//        End If

	//        'Application.DoEvents()
	//        'AASGraphAnalysis.AldysPane.XAxis.PickScale(AASGraphAnalysis.XAxisMin, AASGraphAnalysis.XAxisMax)
	//        'AASGraphAnalysis.AldysPane.XAxis.StepAuto = True
	//        'AASGraphAnalysis.AldysPane.XAxis.MinorStepAuto = True
	//        'AASGraphAnalysis.AldysPane.YAxis.PickScale(AASGraphAnalysis.YAxisMin, AASGraphAnalysis.YAxisMax)
	//        'AASGraphAnalysis.AldysPane.YAxis.StepAuto = True
	//        'AASGraphAnalysis.AldysPane.YAxis.MinorStepAuto = True

	//        AASGraphAnalysis.Refresh()
	//        Application.DoEvents()

	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        'Error Handling and logging
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = ex.Message
	//        gobjErrorHandler.WriteErrorLog(ex)
	//        '---------------------------------------------------------
	//    Finally
	//        '---------------------------------------------------------
	//        'Writing Execution log
	//        If CONST_CREATE_EXECUTION_LOG = 1 Then
	//            gobjErrorHandler.WriteExecutionLog()
	//        End If
	//        '---------------------------------------------------------
	//    End Try
	//End Sub

	public void BgThread.Iclient.Display(string Text)
	{
		//=====================================================================
		// Procedure Name        : Display
		// Parameters Passed     : Text
		// Returns               : None
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak
		// Created               : 29.04.07
		// Revisions             : 
		//=====================================================================
		string strData;
		string[] arrData;
		double xValue;
		double yValue;
		string strSampleName;
		Color curveColor;
		double dblAvgAbs = 0;
		bool IsAvgAbs = false;

		try {
			intDispCount += 1;
			// Use Implementd String object 
			// Use X and Y Value
			if (gobjNewMethod.OperationMode == EnumOperationMode.MODE_UVABS) {
				lblUVAbsorbance.Text = "Absorbance : " + FormatNumber(Text, 3);
				AddInAnalysisRawData(xValue, yValue);
				return;
			} else {
				arrData = Text.Split(",");
				xValue = Val(arrData(0));
				yValue = Val(arrData(1));

				//---16.03.08
				if (gblnIsDemoWithRealData == true) {
					if (gstructSettings.AppMode == EnumAppMode.DemoMode | gstructSettings.AppMode == EnumAppMode.DemoMode_201 | gstructSettings.AppMode == EnumAppMode.DemoMode_203D) {
						StreamReader sr;
						switch (mintSelectedDemoFile) {
							case 1:
								sr = new StreamReader("cu.txt");
							case 2:
								sr = new StreamReader("pb.txt");
							case 3:
								sr = new StreamReader("zn.txt");
							default:
								sr = new StreamReader("cu.txt");
						}

						//Dim sr As StreamReader = New StreamReader("cu.txt")
						string line;
						string line1;
						string line2;
						string[] arr;
						line = sr.ReadToEnd;
						arr = line.Split(";");
						if (arr.Length == 2) {
							line1 = arr(0);
							line2 = arr(1);
						}

						if (this.SampleType == ClsAAS203.enumSampleType.STANDARD) {
							string[] std;
							int i;
							int CurrStdNo;

							for (i = 0; i <= gobjNewMethod.QuantitativeDataCollection.Item(gobjNewMethod.QuantitativeDataCollection.Count - 1).StandardDataCollection.Count - 1; i++) {
								if (gobjNewMethod.QuantitativeDataCollection.Item(gobjNewMethod.QuantitativeDataCollection.Count - 1).StandardDataCollection.item(i).Abs == -1.0) {
									CurrStdNo = i + 1;
									break; // TODO: might not be correct. Was : Exit For
								}
							}

							std = line1.Split(",");
							yValue = (double)std(CurrStdNo - 1);
						}

						if (this.SampleType == ClsAAS203.enumSampleType.SAMPLE) {
							string[] spl;
							int j;
							int CurrSplNo;

							for (j = 0; j <= gobjNewMethod.QuantitativeDataCollection.Item(gobjNewMethod.QuantitativeDataCollection.Count - 1).SampleDataCollection.Count - 1; j++) {
								if (gobjNewMethod.QuantitativeDataCollection.Item(gobjNewMethod.QuantitativeDataCollection.Count - 1).SampleDataCollection.item(j).Abs == -1.0) {
									CurrSplNo = j + 1;
									break; // TODO: might not be correct. Was : Exit For
								}
							}

							spl = line2.Split(",");
							yValue = (double)spl(CurrSplNo - 1);
						}
						sr.Close();
					}
				}
				//---16.03.08


				IsAvgAbs = false;
				if (arrData.Length > 2) {
					IsAvgAbs = true;
					dblAvgAbs = Val(arrData(2));
					//---16.03.08
					if (gblnIsDemoWithRealData == true) {
						if (gstructSettings.AppMode == EnumAppMode.DemoMode | gstructSettings.AppMode == EnumAppMode.DemoMode_201 | gstructSettings.AppMode == EnumAppMode.DemoMode_203D) {
							dblAvgAbs = yValue;
						}
					}
					//---16.03.08
				}
			}

			//---Display Real Point of Reading
			//---Display Abs Value on screen
			if (gobjNewMethod.OperationMode == EnumOperationMode.MODE_EMMISSION) {
				lblAbsorbance.Text = FormatNumber(yValue, 1);
			} else {
				lblAbsorbance.Text = FormatNumber(yValue, 3);
			}

			//---Add only Real Point in the Analysis Raw Data Structure
			//Call AddInAnalysisRawData(xValue, yValue)
			AddInAnalysisRawData(xValue, dblAvgAbs);

			//End If

			//---Draw Line
			//---Add single Curve Item for all lines
			strSampleName = "Aspiration Curve";
			switch (this.SampleType) {
				case ClsAAS203.enumSampleType.BLANK:
					curveColor = ClsAAS203.BLANKCOLOR;
				case ClsAAS203.enumSampleType.STANDARD:
					curveColor = ClsAAS203.STDCOLOR;
				case ClsAAS203.enumSampleType.SAMPLE:
					curveColor = ClsAAS203.SAMPCOLOR;
			}
			//--- Set the Graph points
			if (xValue > AASGraphAnalysis.XAxisMax | yValue > AASGraphAnalysis.YAxisMax) {
				Calculate_Analysis_Graph_Param(AASGraphAnalysis, xValue, yValue);
			}

			if (IsAvgAbs) {
				if ((Afirst)) {
					Afirst = false;
					mobjGraphCurve = AASGraphAnalysis.StartOnlineGraph(strSampleName, Color.Black, AldysGraph.SymbolType.NoSymbol, true);
					AASGraphAnalysis.PlotPoint(mobjGraphCurve, xValue, dblAvgAbs, true);
				//AASGraphAnalysis.PlotPoint(mobjGraphCurve, xValue, yValue, True)
				} else {
					mobjGraphCurve.CL.Add(curveColor);
					AASGraphAnalysis.PlotPoint(mobjGraphCurve, xValue, dblAvgAbs, true);
					//AASGraphAnalysis.PlotPoint(mobjGraphCurve, xValue, yValue, True)
				}
				mxValue = xValue;
				mdblAvgAbs = dblAvgAbs;
			}

			AASGraphAnalysis.Refresh();
			Application.DoEvents();

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

	public void BgThread.Iclient.Failed(System.Exception e)
	{
		//=====================================================================
		// Procedure Name        : Failed
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 17-Jan-2007 03:25 pm
		// Revisions             : 1
		//=====================================================================
		try {
			// Set the process when thread is failed
			mblnAvoidProcessing = true;
			MsgBox("Data Read Thread is failed", MsgBoxStyle.OKOnly);
			Application.DoEvents();
			btnReadData.Click += ReadData_Click;
			gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay);
			//10.12.07
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
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	#End Region



	private void  // ERROR: Handles clauses are not supported in C#
btnStartStopAnalysis_Click(System.Object sender, System.EventArgs e)
	{
	}


	private void  // ERROR: Handles clauses are not supported in C#
btnSave_Click(System.Object sender, System.EventArgs e)
	{
	}
}

