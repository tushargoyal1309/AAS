using System.Threading;
using AAS203.Common;
using IQOQPQ.IQOQPQ.IQOQPQ;
using BgThread;
using System.IO;
using Microsoft.VisualBasic;
using AAS203Library.Instrument;

public class frmMDIMain : System.Windows.Forms.Form, BgThread.Iclient
{

	#Region " Windows Form Designer generated code "

	public frmMDIMain()
	{
		base.New();

		//This call is required by the Windows Form Designer.
		InitializeComponent();

		//Add any initialization after the InitializeComponent() call

		try {
			mobjfrmMethod.IsMdiContainer = false;
			mobjfrmMethod.TopLevel = false;
			mobjfrmMethod.ControlBox = false;
			mobjfrmMethod.Dock = DockStyle.Fill;
			mobjfrmMethod.Text = "";
			CustMain.Controls.Add(mobjfrmMethod);
			mobjfrmMethod.Show();
			mobjfrmMethod.BringToFront();

			mobjfrmAnalysis = new frmAnalysis();
			mobjfrmAnalysis.IsMdiContainer = false;
			mobjfrmAnalysis.TopLevel = false;
			mobjfrmAnalysis.ControlBox = false;
			mobjfrmAnalysis.Dock = DockStyle.Fill;
			mobjfrmAnalysis.Text = "";
			CustMain.Controls.Add(mobjfrmAnalysis);

			mobjfrmDataFiles = new frmDataFiles();
			mobjfrmDataFiles.IsMdiContainer = false;
			mobjfrmDataFiles.TopLevel = false;
			mobjfrmDataFiles.ControlBox = false;
			mobjfrmDataFiles.Dock = DockStyle.Fill;
			mobjfrmDataFiles.Text = "";
			CustMain.Controls.Add(mobjfrmDataFiles);


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
	internal NETXP.Controls.Bars.CommandBar MenuBar;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuAnalysis;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuHistory;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuDataFiles;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuMethod;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuAnalyse;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuSpectrumModes;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuUVSpectrum;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuEnergySpectrum;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuUtilities;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuHydrideMode;
	internal NETXP.Controls.Bars.CommandBarSeparatorItem CommandBarSeparatorItem1;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuManualFlame;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuOpenReportFile;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuPrinterSetup;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuPrintertype;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuCookBook;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuFilterOn;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuAutoSampler;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuEnableAutoSAmpler;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuCheckSamplerFunctions;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuSetAbsorbanceThreshold;
	internal NETXP.Controls.Bars.CommandBar ToolBar;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuHelpMain;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuHelp;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuAboutUs;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuFile;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuExit;
	internal NETXP.Controls.Bars.CommandBarSeparatorItem CommandBarSeparatorItem2;
	internal NETXP.Controls.Bars.CommandBarSeparatorItem CommandBarSeparatorItem3;
	internal NETXP.Controls.Bars.CommandBarSeparatorItem CommandBarSeparatorItem4;
	internal NETXP.Controls.Bars.CommandBarButtonItem tlbbtnMethod;
	internal NETXP.Controls.Bars.CommandBarButtonItem tlbbtnAnalyse;
	internal NETXP.Controls.Bars.CommandBarButtonItem tlbbtnDataFiles;
	internal NETXP.Controls.Bars.CommandBarButtonItem tlbbtnCookBook;
	internal NETXP.Controls.Bars.CommandBarButtonItem tlbbtnHelp;
	internal NETXP.Controls.Bars.CommandBarButtonItem tlbbtnExit;
	internal GradientPanel.CustomPanel CustomPanelTop;
	internal NETXP.Controls.Bars.StatusBar StatusBar1;
	internal System.Windows.Forms.StatusBarPanel StatusBarPanelInfo;
	internal System.Windows.Forms.StatusBarPanel StatusBarPanelDate;
	internal NETXP.Controls.Bars.ProgressPanel ProgressPanel;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuService;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuServiceUtility;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuAdministration;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuAddUser;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuUserPermissions;
	internal NETXP.Controls.Bars.CommandBarSeparatorItem CommandBarSeparatorItem5;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuActivityLog;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuDeleteLog;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuChangePassword;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnu21CFR;
	internal GradientPanel.CustomPanel CustMain;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuChangeBeamType;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuSingleBeam;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuDoubleBeam;
	//Friend WithEvents CommandBarButtonItem1 As NETXP.Controls.Bars.CommandBarButtonItem
	internal NETXP.Controls.Bars.CommandBarSeparatorItem CommandBarSeparatorItem6;
	internal NETXP.Controls.Bars.CommandBarSeparatorItem CommandBarSeparatorItem7;
	internal NETXP.Controls.Bars.CommandBarButtonItem tlbbtnManualFlame;
	internal NETXP.Controls.Bars.CommandBarButtonItem tlbbtnUVSpectrum;
	internal NETXP.Controls.Bars.CommandBarButtonItem tlbbtnEnergySpectrum;
	internal NETXP.Controls.Bars.CommandBarSeparatorItem CommandBarSeparatorItem8;
	internal NETXP.Controls.Bars.CommandBarButtonItem IQOQPQ;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuIQOQPQ;
	internal NETXP.Controls.Bars.CommandBarButtonItem tlbbtnService;
	internal NETXP.Controls.Bars.CommandBarButtonItem tlbbtnIQOQPQ;
	internal NETXP.Controls.Bars.CommandBarSeparatorItem CommandBarSeparatorItem9;
	internal GradientPanel.CustomPanel CustomPanel1;
	internal NETXP.Controls.XPButton btnExtinguish;
	internal NETXP.Controls.XPButton btnIgnite;
	internal NETXP.Controls.XPButton btnN2OIgnite;
	internal NETXP.Controls.XPButton btnDelete;
	internal NETXP.Controls.XPButton btnR;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuLampElements;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuHelpAbout;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuAbout;
	[System.Diagnostics.DebuggerStepThrough()]
	private void InitializeComponent()
	{
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMDIMain));
		this.ToolBar = new NETXP.Controls.Bars.CommandBar();
		this.tlbbtnMethod = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.tlbbtnAnalyse = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.tlbbtnDataFiles = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.CommandBarSeparatorItem6 = new NETXP.Controls.Bars.CommandBarSeparatorItem();
		this.tlbbtnUVSpectrum = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.tlbbtnEnergySpectrum = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.CommandBarSeparatorItem8 = new NETXP.Controls.Bars.CommandBarSeparatorItem();
		this.tlbbtnManualFlame = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.tlbbtnCookBook = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.CommandBarSeparatorItem7 = new NETXP.Controls.Bars.CommandBarSeparatorItem();
		this.tlbbtnService = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.tlbbtnIQOQPQ = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.CommandBarSeparatorItem9 = new NETXP.Controls.Bars.CommandBarSeparatorItem();
		this.tlbbtnHelp = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.CommandBarSeparatorItem4 = new NETXP.Controls.Bars.CommandBarSeparatorItem();
		this.tlbbtnExit = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.CustomPanelMain = new GradientPanel.CustomPanel();
		this.CustMain = new GradientPanel.CustomPanel();
		this.CustomPanel1 = new GradientPanel.CustomPanel();
		this.btnExtinguish = new NETXP.Controls.XPButton();
		this.btnIgnite = new NETXP.Controls.XPButton();
		this.btnN2OIgnite = new NETXP.Controls.XPButton();
		this.btnDelete = new NETXP.Controls.XPButton();
		this.btnR = new NETXP.Controls.XPButton();
		this.CustomPanelTop = new GradientPanel.CustomPanel();
		this.MenuBar = new NETXP.Controls.Bars.CommandBar();
		this.mnuFile = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuMethod = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.CommandBarSeparatorItem2 = new NETXP.Controls.Bars.CommandBarSeparatorItem();
		this.mnuExit = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuAnalysis = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuAnalyse = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuHistory = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuDataFiles = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuSpectrumModes = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuUVSpectrum = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuEnergySpectrum = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuUtilities = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuHydrideMode = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.CommandBarSeparatorItem1 = new NETXP.Controls.Bars.CommandBarSeparatorItem();
		this.mnuManualFlame = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuOpenReportFile = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuPrinterSetup = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuPrintertype = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuCookBook = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuFilterOn = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuAutoSampler = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuEnableAutoSAmpler = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuCheckSamplerFunctions = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuSetAbsorbanceThreshold = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuLampElements = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuService = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuServiceUtility = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.IQOQPQ = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuIQOQPQ = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuAdministration = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuAddUser = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuUserPermissions = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.CommandBarSeparatorItem5 = new NETXP.Controls.Bars.CommandBarSeparatorItem();
		this.mnuActivityLog = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuDeleteLog = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuChangePassword = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnu21CFR = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuHelpMain = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuHelp = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.CommandBarSeparatorItem3 = new NETXP.Controls.Bars.CommandBarSeparatorItem();
		this.mnuAboutUs = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuChangeBeamType = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuSingleBeam = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuDoubleBeam = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuHelpAbout = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuAbout = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.StatusBar1 = new NETXP.Controls.Bars.StatusBar();
		this.StatusBarPanelInfo = new System.Windows.Forms.StatusBarPanel();
		this.ProgressPanel = new NETXP.Controls.Bars.ProgressPanel();
		this.StatusBarPanelDate = new System.Windows.Forms.StatusBarPanel();
		((System.ComponentModel.ISupportInitialize)this.ToolBar).BeginInit();
		this.CustomPanelMain.SuspendLayout();
		this.CustMain.SuspendLayout();
		this.CustomPanelTop.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.MenuBar).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.StatusBarPanelInfo).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.ProgressPanel).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.StatusBarPanelDate).BeginInit();
		this.SuspendLayout();
		//
		//ToolBar
		//
		this.ToolBar.BackColor = System.Drawing.Color.Transparent;
		this.ToolBar.Cursor = System.Windows.Forms.Cursors.Hand;
		this.ToolBar.CustomizeText = "&Customize Toolbar...";
		this.ToolBar.Dock = System.Windows.Forms.DockStyle.Top;
		this.ToolBar.Font = new System.Drawing.Font("Arial", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.ToolBar.FullRow = true;
		this.ToolBar.ID = 1671;
		this.ToolBar.Items.AddRange(new NETXP.Controls.Bars.CommandBarItem[] {
			this.tlbbtnMethod,
			this.tlbbtnAnalyse,
			this.tlbbtnDataFiles,
			this.CommandBarSeparatorItem6,
			this.tlbbtnUVSpectrum,
			this.tlbbtnEnergySpectrum,
			this.CommandBarSeparatorItem8,
			this.tlbbtnManualFlame,
			this.tlbbtnCookBook,
			this.CommandBarSeparatorItem7,
			this.tlbbtnService,
			this.tlbbtnIQOQPQ,
			this.CommandBarSeparatorItem9,
			this.tlbbtnHelp,
			this.CommandBarSeparatorItem4,
			this.tlbbtnExit
		});
		this.ToolBar.Location = new System.Drawing.Point(0, 23);
		this.ToolBar.Margins.Bottom = 1;
		this.ToolBar.Margins.Left = 1;
		this.ToolBar.Margins.Right = 1;
		this.ToolBar.Margins.Top = 1;
		this.ToolBar.MdiContainer = this;
		this.ToolBar.Name = "ToolBar";
		this.ToolBar.Size = new System.Drawing.Size(712, 34);
		this.ToolBar.TabIndex = 2;
		this.ToolBar.TabStop = false;
		this.ToolBar.Text = "";
		//
		//tlbbtnMethod
		//
		this.tlbbtnMethod.Image = (System.Drawing.Image)resources.GetObject("tlbbtnMethod.Image");
		this.tlbbtnMethod.Text = "METHOD [Ctrl+M]";
		//
		//tlbbtnAnalyse
		//
		this.tlbbtnAnalyse.Image = (System.Drawing.Image)resources.GetObject("tlbbtnAnalyse.Image");
		this.tlbbtnAnalyse.Text = "ANALYSE [Ctrl+A]";
		//
		//tlbbtnDataFiles
		//
		this.tlbbtnDataFiles.Image = (System.Drawing.Image)resources.GetObject("tlbbtnDataFiles.Image");
		this.tlbbtnDataFiles.Text = "DATA FILES [Ctrl+D]";
		//
		//tlbbtnUVSpectrum
		//
		this.tlbbtnUVSpectrum.Image = (System.Drawing.Image)resources.GetObject("tlbbtnUVSpectrum.Image");
		this.tlbbtnUVSpectrum.Text = "UV SPECTRUM[Ctrl+U]";
		//
		//tlbbtnEnergySpectrum
		//
		this.tlbbtnEnergySpectrum.Image = (System.Drawing.Image)resources.GetObject("tlbbtnEnergySpectrum.Image");
		this.tlbbtnEnergySpectrum.Text = "ENERGY SPECTRUM[Ctrl+E]";
		//
		//tlbbtnManualFlame
		//
		this.tlbbtnManualFlame.Image = (System.Drawing.Image)resources.GetObject("tlbbtnManualFlame.Image");
		this.tlbbtnManualFlame.Text = "MANUAL FLAME[Ctrl+F]";
		//
		//tlbbtnCookBook
		//
		this.tlbbtnCookBook.Image = (System.Drawing.Image)resources.GetObject("tlbbtnCookBook.Image");
		this.tlbbtnCookBook.Text = "COOK BOOK [Ctrl+C]";
		//
		//tlbbtnService
		//
		this.tlbbtnService.Image = (System.Drawing.Image)resources.GetObject("tlbbtnService.Image");
		this.tlbbtnService.Text = "SERVICE UTILITY[Ctrl+Y]";
		this.tlbbtnService.Visible = false;
		//
		//tlbbtnIQOQPQ
		//
		this.tlbbtnIQOQPQ.Image = (System.Drawing.Image)resources.GetObject("tlbbtnIQOQPQ.Image");
		this.tlbbtnIQOQPQ.Text = "IQOQPQ[Ctrl+I]";
		//
		//tlbbtnHelp
		//
		this.tlbbtnHelp.Image = (System.Drawing.Image)resources.GetObject("tlbbtnHelp.Image");
		this.tlbbtnHelp.Text = "HELP";
		this.tlbbtnHelp.Visible = false;
		//
		//CommandBarSeparatorItem4
		//
		this.CommandBarSeparatorItem4.Visible = false;
		//
		//tlbbtnExit
		//
		this.tlbbtnExit.Image = (System.Drawing.Image)resources.GetObject("tlbbtnExit.Image");
		this.tlbbtnExit.Shortcut = System.Windows.Forms.Shortcut.CtrlX;
		this.tlbbtnExit.Text = "EXIT [Ctrl+X]";
		//
		//CustomPanelMain
		//
		this.CustomPanelMain.BackColor = System.Drawing.Color.AliceBlue;
		this.CustomPanelMain.BackColor2 = System.Drawing.Color.AliceBlue;
		this.CustomPanelMain.Controls.Add(this.CustMain);
		this.CustomPanelMain.Controls.Add(this.CustomPanelTop);
		this.CustomPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
		this.CustomPanelMain.Location = new System.Drawing.Point(0, 0);
		this.CustomPanelMain.Name = "CustomPanelMain";
		this.CustomPanelMain.Size = new System.Drawing.Size(712, 399);
		this.CustomPanelMain.TabIndex = 3;
		//
		//CustMain
		//
		this.CustMain.BackColor = System.Drawing.Color.AliceBlue;
		this.CustMain.BackgroundImage = (System.Drawing.Image)resources.GetObject("CustMain.BackgroundImage");
		this.CustMain.Controls.Add(this.CustomPanel1);
		this.CustMain.Controls.Add(this.btnExtinguish);
		this.CustMain.Controls.Add(this.btnIgnite);
		this.CustMain.Controls.Add(this.btnN2OIgnite);
		this.CustMain.Controls.Add(this.btnDelete);
		this.CustMain.Controls.Add(this.btnR);
		this.CustMain.Dock = System.Windows.Forms.DockStyle.Fill;
		this.CustMain.Location = new System.Drawing.Point(0, 56);
		this.CustMain.Name = "CustMain";
		this.CustMain.Size = new System.Drawing.Size(712, 343);
		this.CustMain.TabIndex = 5;
		//
		//CustomPanel1
		//
		this.CustomPanel1.BackColor = System.Drawing.Color.AliceBlue;
		this.CustomPanel1.Location = new System.Drawing.Point(640, 24);
		this.CustomPanel1.Name = "CustomPanel1";
		this.CustomPanel1.Size = new System.Drawing.Size(64, 72);
		this.CustomPanel1.TabIndex = 16;
		//
		//btnExtinguish
		//
		this.btnExtinguish.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnExtinguish.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnExtinguish.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnExtinguish.Location = new System.Drawing.Point(688, 30);
		this.btnExtinguish.Name = "btnExtinguish";
		this.btnExtinguish.Size = new System.Drawing.Size(5, 5);
		this.btnExtinguish.TabIndex = 18;
		this.btnExtinguish.TabStop = false;
		this.btnExtinguish.Text = "&Extinguish";
		this.btnExtinguish.TextAlign = System.Drawing.ContentAlignment.TopLeft;
		//
		//btnIgnite
		//
		this.btnIgnite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnIgnite.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnIgnite.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnIgnite.Location = new System.Drawing.Point(680, 30);
		this.btnIgnite.Name = "btnIgnite";
		this.btnIgnite.Size = new System.Drawing.Size(5, 5);
		this.btnIgnite.TabIndex = 17;
		this.btnIgnite.TabStop = false;
		this.btnIgnite.Text = "&Ignition";
		this.btnIgnite.TextAlign = System.Drawing.ContentAlignment.TopLeft;
		//
		//btnN2OIgnite
		//
		this.btnN2OIgnite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnN2OIgnite.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnN2OIgnite.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnN2OIgnite.Location = new System.Drawing.Point(680, 40);
		this.btnN2OIgnite.Name = "btnN2OIgnite";
		this.btnN2OIgnite.Size = new System.Drawing.Size(5, 5);
		this.btnN2OIgnite.TabIndex = 19;
		this.btnN2OIgnite.TabStop = false;
		this.btnN2OIgnite.Text = "N2O&C";
		this.btnN2OIgnite.TextAlign = System.Drawing.ContentAlignment.TopLeft;
		//
		//btnDelete
		//
		this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnDelete.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnDelete.Location = new System.Drawing.Point(688, 40);
		this.btnDelete.Name = "btnDelete";
		this.btnDelete.Size = new System.Drawing.Size(8, 8);
		this.btnDelete.TabIndex = 25;
		this.btnDelete.TabStop = false;
		this.btnDelete.Text = "&Delete";
		this.btnDelete.TextAlign = System.Drawing.ContentAlignment.TopLeft;
		//
		//btnR
		//
		this.btnR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnR.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnR.Location = new System.Drawing.Point(680, 48);
		this.btnR.Name = "btnR";
		this.btnR.Size = new System.Drawing.Size(8, 8);
		this.btnR.TabIndex = 24;
		this.btnR.TabStop = false;
		this.btnR.Text = "&R";
		this.btnR.TextAlign = System.Drawing.ContentAlignment.TopLeft;
		//
		//CustomPanelTop
		//
		this.CustomPanelTop.BackColor = System.Drawing.Color.Gainsboro;
		this.CustomPanelTop.Controls.Add(this.ToolBar);
		this.CustomPanelTop.Controls.Add(this.MenuBar);
		this.CustomPanelTop.Dock = System.Windows.Forms.DockStyle.Top;
		this.CustomPanelTop.Location = new System.Drawing.Point(0, 0);
		this.CustomPanelTop.Name = "CustomPanelTop";
		this.CustomPanelTop.Size = new System.Drawing.Size(712, 56);
		this.CustomPanelTop.TabIndex = 4;
		//
		//MenuBar
		//
		this.MenuBar.BackColor = System.Drawing.Color.Transparent;
		this.MenuBar.CustomBackground = true;
		this.MenuBar.CustomizeText = "&Customize Toolbar...";
		this.MenuBar.Dock = System.Windows.Forms.DockStyle.Top;
		this.MenuBar.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.MenuBar.FullRow = true;
		this.MenuBar.ID = 2261;
		this.MenuBar.Items.AddRange(new NETXP.Controls.Bars.CommandBarItem[] {
			this.mnuFile,
			this.mnuAnalysis,
			this.mnuHistory,
			this.mnuSpectrumModes,
			this.mnuUtilities,
			this.mnuService,
			this.IQOQPQ,
			this.mnuAdministration,
			this.mnuHelpMain,
			this.mnuChangeBeamType,
			this.mnuHelpAbout
		});
		this.MenuBar.Location = new System.Drawing.Point(0, 0);
		this.MenuBar.Margins.Bottom = 1;
		this.MenuBar.Margins.Left = 1;
		this.MenuBar.Margins.Right = 1;
		this.MenuBar.Margins.Top = 1;
		this.MenuBar.Name = "MenuBar";
		this.MenuBar.Size = new System.Drawing.Size(712, 23);
		this.MenuBar.Style = NETXP.Controls.Bars.CommandBarStyle.Menu;
		this.MenuBar.TabIndex = 0;
		this.MenuBar.TabStop = false;
		this.MenuBar.Text = "";
		//
		//mnuFile
		//
		this.mnuFile.Infrequent = true;
		this.mnuFile.Items.AddRange(new NETXP.Controls.Bars.CommandBarItem[] {
			this.mnuMethod,
			this.CommandBarSeparatorItem2,
			this.mnuExit
		});
		this.mnuFile.PadHorizontal = 5;
		this.mnuFile.Text = "&Method";
		//
		//mnuMethod
		//
		this.mnuMethod.Image = (System.Drawing.Image)resources.GetObject("mnuMethod.Image");
		this.mnuMethod.Shortcut = System.Windows.Forms.Shortcut.CtrlM;
		this.mnuMethod.Text = "&Method";
		//
		//mnuExit
		//
		this.mnuExit.Image = (System.Drawing.Image)resources.GetObject("mnuExit.Image");
		this.mnuExit.Shortcut = System.Windows.Forms.Shortcut.CtrlX;
		this.mnuExit.Text = "E&xit";
		//
		//mnuAnalysis
		//
		this.mnuAnalysis.Items.AddRange(new NETXP.Controls.Bars.CommandBarItem[] { this.mnuAnalyse });
		this.mnuAnalysis.PadHorizontal = 5;
		this.mnuAnalysis.ShowText = true;
		this.mnuAnalysis.Text = "&Analysis";
		//
		//mnuAnalyse
		//
		this.mnuAnalyse.Image = (System.Drawing.Image)resources.GetObject("mnuAnalyse.Image");
		this.mnuAnalyse.Shortcut = System.Windows.Forms.Shortcut.CtrlA;
		this.mnuAnalyse.Text = "&Analysis";
		//
		//mnuHistory
		//
		this.mnuHistory.Items.AddRange(new NETXP.Controls.Bars.CommandBarItem[] { this.mnuDataFiles });
		this.mnuHistory.PadHorizontal = 5;
		this.mnuHistory.Text = "Da&ta Files";
		//
		//mnuDataFiles
		//
		this.mnuDataFiles.Image = (System.Drawing.Image)resources.GetObject("mnuDataFiles.Image");
		this.mnuDataFiles.Shortcut = System.Windows.Forms.Shortcut.CtrlD;
		this.mnuDataFiles.Text = "&Data Files";
		//
		//mnuSpectrumModes
		//
		this.mnuSpectrumModes.Items.AddRange(new NETXP.Controls.Bars.CommandBarItem[] {
			this.mnuUVSpectrum,
			this.mnuEnergySpectrum
		});
		this.mnuSpectrumModes.PadHorizontal = 5;
		this.mnuSpectrumModes.ShowText = true;
		this.mnuSpectrumModes.Text = "&Spectrum";
		//
		//mnuUVSpectrum
		//
		this.mnuUVSpectrum.Image = (System.Drawing.Image)resources.GetObject("mnuUVSpectrum.Image");
		this.mnuUVSpectrum.Shortcut = System.Windows.Forms.Shortcut.CtrlU;
		this.mnuUVSpectrum.Text = "&UV Spectrum";
		//
		//mnuEnergySpectrum
		//
		this.mnuEnergySpectrum.Image = (System.Drawing.Image)resources.GetObject("mnuEnergySpectrum.Image");
		this.mnuEnergySpectrum.Shortcut = System.Windows.Forms.Shortcut.CtrlE;
		this.mnuEnergySpectrum.Text = "&Energy Spectrum";
		//
		//mnuUtilities
		//
		this.mnuUtilities.Items.AddRange(new NETXP.Controls.Bars.CommandBarItem[] {
			this.mnuHydrideMode,
			this.CommandBarSeparatorItem1,
			this.mnuManualFlame,
			this.mnuOpenReportFile,
			this.mnuPrinterSetup,
			this.mnuPrintertype,
			this.mnuCookBook,
			this.mnuFilterOn,
			this.mnuAutoSampler,
			this.mnuSetAbsorbanceThreshold,
			this.mnuLampElements
		});
		this.mnuUtilities.PadHorizontal = 5;
		this.mnuUtilities.ShowText = true;
		this.mnuUtilities.Text = "&Utilities";
		//
		//mnuHydrideMode
		//
		this.mnuHydrideMode.Text = "&Hydride Mode";
		//
		//mnuManualFlame
		//
		this.mnuManualFlame.Image = (System.Drawing.Image)resources.GetObject("mnuManualFlame.Image");
		this.mnuManualFlame.Shortcut = System.Windows.Forms.Shortcut.CtrlF;
		this.mnuManualFlame.Text = "&Manual Flame";
		//
		//mnuOpenReportFile
		//
		this.mnuOpenReportFile.Image = (System.Drawing.Image)resources.GetObject("mnuOpenReportFile.Image");
		this.mnuOpenReportFile.Text = "&Open Export/Multielement Report File";
		//
		//mnuPrinterSetup
		//
		this.mnuPrinterSetup.Image = (System.Drawing.Image)resources.GetObject("mnuPrinterSetup.Image");
		this.mnuPrinterSetup.Text = "&Printer Setup";
		//
		//mnuPrintertype
		//
		this.mnuPrintertype.Image = (System.Drawing.Image)resources.GetObject("mnuPrintertype.Image");
		this.mnuPrintertype.Text = "P&rinter Type";
		//
		//mnuCookBook
		//
		this.mnuCookBook.Image = (System.Drawing.Image)resources.GetObject("mnuCookBook.Image");
		this.mnuCookBook.Shortcut = System.Windows.Forms.Shortcut.CtrlC;
		this.mnuCookBook.Text = "&Cook Book";
		//
		//mnuFilterOn
		//
		this.mnuFilterOn.Text = "&Filter On(201)";
		//
		//mnuAutoSampler
		//
		this.mnuAutoSampler.Items.AddRange(new NETXP.Controls.Bars.CommandBarItem[] {
			this.mnuEnableAutoSAmpler,
			this.mnuCheckSamplerFunctions
		});
		this.mnuAutoSampler.Text = "&Auto Sampler";
		//
		//mnuEnableAutoSAmpler
		//
		this.mnuEnableAutoSAmpler.Image = (System.Drawing.Image)resources.GetObject("mnuEnableAutoSAmpler.Image");
		this.mnuEnableAutoSAmpler.Text = "&Enable Auto Sampler";
		//
		//mnuCheckSamplerFunctions
		//
		this.mnuCheckSamplerFunctions.Image = (System.Drawing.Image)resources.GetObject("mnuCheckSamplerFunctions.Image");
		this.mnuCheckSamplerFunctions.Text = "&Check Sampler Functions";
		//
		//mnuSetAbsorbanceThreshold
		//
		this.mnuSetAbsorbanceThreshold.Image = (System.Drawing.Image)resources.GetObject("mnuSetAbsorbanceThreshold.Image");
		this.mnuSetAbsorbanceThreshold.Text = "&Set Absorbance Threshold";
		//
		//mnuLampElements
		//
		this.mnuLampElements.Shortcut = System.Windows.Forms.Shortcut.F8;
		this.mnuLampElements.Text = "View Lamp Position";
		//
		//mnuService
		//
		this.mnuService.Items.AddRange(new NETXP.Controls.Bars.CommandBarItem[] { this.mnuServiceUtility });
		this.mnuService.PadHorizontal = 5;
		this.mnuService.ShowText = true;
		this.mnuService.Text = "Service";
		this.mnuService.Visible = false;
		//
		//mnuServiceUtility
		//
		this.mnuServiceUtility.Image = (System.Drawing.Image)resources.GetObject("mnuServiceUtility.Image");
		this.mnuServiceUtility.Shortcut = System.Windows.Forms.Shortcut.CtrlY;
		this.mnuServiceUtility.Text = "Ser&vice Utility";
		//
		//IQOQPQ
		//
		this.IQOQPQ.Items.AddRange(new NETXP.Controls.Bars.CommandBarItem[] { this.mnuIQOQPQ });
		this.IQOQPQ.PadHorizontal = 5;
		this.IQOQPQ.Text = "I&QOQPQ";
		//
		//mnuIQOQPQ
		//
		this.mnuIQOQPQ.Image = (System.Drawing.Image)resources.GetObject("mnuIQOQPQ.Image");
		this.mnuIQOQPQ.Shortcut = System.Windows.Forms.Shortcut.CtrlI;
		this.mnuIQOQPQ.Text = "IQOQPQ";
		//
		//mnuAdministration
		//
		this.mnuAdministration.Items.AddRange(new NETXP.Controls.Bars.CommandBarItem[] {
			this.mnuAddUser,
			this.mnuUserPermissions,
			this.CommandBarSeparatorItem5,
			this.mnuActivityLog,
			this.mnuDeleteLog,
			this.mnuChangePassword,
			this.mnu21CFR
		});
		this.mnuAdministration.PadHorizontal = 5;
		this.mnuAdministration.ShowText = true;
		this.mnuAdministration.Text = "Admi&nistration";
		//
		//mnuAddUser
		//
		this.mnuAddUser.Image = (System.Drawing.Image)resources.GetObject("mnuAddUser.Image");
		this.mnuAddUser.Tag = "";
		this.mnuAddUser.Text = "&Add User";
		//
		//mnuUserPermissions
		//
		this.mnuUserPermissions.Image = (System.Drawing.Image)resources.GetObject("mnuUserPermissions.Image");
		this.mnuUserPermissions.Text = "&User Permissions";
		//
		//mnuActivityLog
		//
		this.mnuActivityLog.Image = (System.Drawing.Image)resources.GetObject("mnuActivityLog.Image");
		this.mnuActivityLog.Tag = "";
		this.mnuActivityLog.Text = "&Activity Log";
		//
		//mnuDeleteLog
		//
		this.mnuDeleteLog.Image = (System.Drawing.Image)resources.GetObject("mnuDeleteLog.Image");
		this.mnuDeleteLog.Tag = "";
		this.mnuDeleteLog.Text = "&Delete Log";
		//
		//mnuChangePassword
		//
		this.mnuChangePassword.Image = (System.Drawing.Image)resources.GetObject("mnuChangePassword.Image");
		this.mnuChangePassword.Text = "&Change Password";
		//
		//mnu21CFR
		//
		this.mnu21CFR.Image = (System.Drawing.Image)resources.GetObject("mnu21CFR.Image");
		this.mnu21CFR.Text = "Disable 21CFR";
		//
		//mnuHelpMain
		//
		this.mnuHelpMain.Items.AddRange(new NETXP.Controls.Bars.CommandBarItem[] {
			this.mnuHelp,
			this.CommandBarSeparatorItem3,
			this.mnuAboutUs
		});
		this.mnuHelpMain.PadHorizontal = 5;
		this.mnuHelpMain.Text = "&Help";
		this.mnuHelpMain.Visible = false;
		//
		//mnuHelp
		//
		this.mnuHelp.Text = "&Help";
		//
		//mnuAboutUs
		//
		this.mnuAboutUs.Text = "&About Us";
		//
		//mnuChangeBeamType
		//
		this.mnuChangeBeamType.Items.AddRange(new NETXP.Controls.Bars.CommandBarItem[] {
			this.mnuSingleBeam,
			this.mnuDoubleBeam
		});
		this.mnuChangeBeamType.PadHorizontal = 5;
		this.mnuChangeBeamType.Text = "&Beam Type";
		this.mnuChangeBeamType.Visible = false;
		//
		//mnuSingleBeam
		//
		this.mnuSingleBeam.CheckType = NETXP.Controls.Bars.ButtonItemCheckType.Radio;
		this.mnuSingleBeam.Text = "Single Beam";
		//
		//mnuDoubleBeam
		//
		this.mnuDoubleBeam.Checked = true;
		this.mnuDoubleBeam.CheckType = NETXP.Controls.Bars.ButtonItemCheckType.Radio;
		this.mnuDoubleBeam.DefaultItem = true;
		this.mnuDoubleBeam.Text = "Double Beam";
		//
		//mnuHelpAbout
		//
		this.mnuHelpAbout.Items.AddRange(new NETXP.Controls.Bars.CommandBarItem[] { this.mnuAbout });
		this.mnuHelpAbout.Text = "Help";
		//
		//mnuAbout
		//
		this.mnuAbout.Text = "About";
		//
		//StatusBar1
		//
		this.StatusBar1.Location = new System.Drawing.Point(0, 399);
		this.StatusBar1.Name = "StatusBar1";
		this.StatusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
			this.StatusBarPanelInfo,
			this.ProgressPanel,
			this.StatusBarPanelDate
		});
		this.StatusBar1.ShowPanels = true;
		this.StatusBar1.Size = new System.Drawing.Size(712, 24);
		this.StatusBar1.TabIndex = 5;
		this.StatusBar1.Text = "StatusBar1";
		//
		//StatusBarPanelInfo
		//
		this.StatusBarPanelInfo.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
		this.StatusBarPanelInfo.MinWidth = 40;
		this.StatusBarPanelInfo.Style = System.Windows.Forms.StatusBarPanelStyle.OwnerDraw;
		this.StatusBarPanelInfo.Width = 456;
		//
		//ProgressPanel
		//
		this.ProgressPanel.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
		this.ProgressPanel.Maximum = 100;
		this.ProgressPanel.Minimum = 0;
		this.ProgressPanel.Style = System.Windows.Forms.StatusBarPanelStyle.OwnerDraw;
		this.ProgressPanel.Value = 0;
		this.ProgressPanel.Width = 200;
		//
		//StatusBarPanelDate
		//
		this.StatusBarPanelDate.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
		this.StatusBarPanelDate.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
		this.StatusBarPanelDate.MinWidth = 40;
		this.StatusBarPanelDate.Style = System.Windows.Forms.StatusBarPanelStyle.OwnerDraw;
		this.StatusBarPanelDate.Width = 40;
		//
		//frmMDIMain
		//
		this.AutoScale = false;
		this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
		this.CausesValidation = false;
		this.ClientSize = new System.Drawing.Size(712, 423);
		this.Controls.Add(this.CustomPanelMain);
		this.Controls.Add(this.StatusBar1);
		this.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		this.IsMdiContainer = true;
		this.Name = "frmMDIMain";
		this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
		((System.ComponentModel.ISupportInitialize)this.ToolBar).EndInit();
		this.CustomPanelMain.ResumeLayout(false);
		this.CustMain.ResumeLayout(false);
		this.CustomPanelTop.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.MenuBar).EndInit();
		((System.ComponentModel.ISupportInitialize)this.StatusBarPanelInfo).EndInit();
		((System.ComponentModel.ISupportInitialize)this.ProgressPanel).EndInit();
		((System.ComponentModel.ISupportInitialize)this.StatusBarPanelDate).EndInit();
		this.ResumeLayout(false);

	}

	#End Region

	#Region " Private Constants "

	private const  ConstFormLoad = "-Method";
	private const  ConstFormLoadDataFiles = "-DataFiles";
	private const  ConstFormLoadAnalysis = "-Analysis";

	private const  CONST_Export = ".TXT";
	public enum EnumTimerStartStop
	{
		Timer_Start = 1,
		Timer_Stop = 2
	}

	#End Region

	#Region " Member Variables "
	// Dim objfrmEnergySpectrumDBMode As frmEnergySpectrumDBMode 

	private int mintElementID;
	internal frmMethod mobjfrmMethod = new frmMethod();
	private frmDataFiles mobjfrmDataFiles;

	public frmAnalysis mobjfrmAnalysis;

	private bool mblnIsApplicationClosed;
	//Private mobjThread As Threading.Thread
	//Private mobjTimerToCheckFlame As New System.Timers.Timer

	private bool mblnIsStartAnalysisRunNumber;

	private bool mblnIsMethodInstrumentSettingsChanged;

	private ClsAAS203.enumIgniteType mintIgniteType;

	private IO.Directory strPath;

	public clsBgThread mobjController;
		//Saurabh 04.07.07
	private int mintMethodMode = 0;
	NETXP.Controls.Bars.CommandBarButtonItem mnuStopAspiration = new NETXP.Controls.Bars.CommandBarButtonItem();
		#End Region
	private bool mblnAvoidProcessing = false;

	#Region " Properties "

	private int ElementID {
		get { return mintElementID; }
		set { mintElementID = Value; }
	}

	public bool IsStartAnalysisRunNumber {
		get { return mblnIsStartAnalysisRunNumber; }
		set { mblnIsStartAnalysisRunNumber = Value; }
	}

	public bool MethodInstrumentSettingsChanged {
		get { return mblnIsMethodInstrumentSettingsChanged; }
		set { mblnIsMethodInstrumentSettingsChanged = Value; }
	}

	public ClsAAS203.enumIgniteType IgniteType {
		get { return mintIgniteType; }
		set { mintIgniteType = Value; }
	}

	private EnumMethodMode OpenMethodMode {
		get { return mintMethodMode; }
		set { mintMethodMode = Value; }
	}
	//Added by Saurabh for IQOQPQ Test

	#End Region

	#Region " Form Load, Closing and other Events "

	private void  // ERROR: Handles clauses are not supported in C#
frmMDIMain_Load(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : frmMDIMain_Load
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To initialize the form
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : 07.09.06
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();


		try {
			if (gstructSettings.AppMode == EnumAppMode.FullVersion_203D | gstructSettings.AppMode == EnumAppMode.DemoMode_203D | gstructSettings.AppMode == EnumAppMode.FullVersion_203 | gstructSettings.AppMode == EnumAppMode.DemoMode) {
			} else {
				mnuLampElements.Visible = false;
			}

			//---added on 12.05.09 for ver 6.89
			if (gstructSettings.AppMode == EnumAppMode.FullVersion_201 | gstructSettings.AppMode == EnumAppMode.DemoMode_201) {
				if (gstructSettings.NewModelName == true) {
					mnuUVSpectrum.Visible = false;
				}
			}
			//---added on 12.05.09 for ver 6.89


			Application.DoEvents();
			gobjclsTimer = new clsTimer(StatusBar1, 1000);
			gobjclsTimer.subTimerStop();
			mnuCheckSamplerFunctions.Enabled = false;

			mnuAbout.Text = mnuAbout.Text + Space(1) + gstrTitleInstrumentType;

			if (gstructSettings.AppMode == EnumAppMode.FullVersion_201) {
				btnIgnite.Enabled = false;
				btnExtinguish.Enabled = false;
			}

			//---Added by Saurabh to show or hide Administration menu on MDI------
			if (gstructSettings.CFR21Installation == false) {
				mnuAdministration.Enabled = false;
				mnuAdministration.Visible = false;
			}



			StatusBarPanelInfo.Text = "";
			ShowProgressBar(gstrTitleInstrumentType + ConstFormLoad);

			this.Text = gstrTitleInstrumentType;

			//--- if User is other then an Administrator he or she won't get Access to the 
			//--- Administrator Mneu on the Main Screen
			if (gstructUserDetails.UserID != 0) {
				mnuAdministration.Visible = false;
			}

			//---initialize form and add handlers
			funcInitialise();
			//Call AddHandlers()
			HideProgressBar();

			if (gstructSettings.Enable21CFR == true) {
				mnu21CFR.Text = "Disable History";
				mnu21CFR.Image = Image.FromFile(Application.StartupPath + "\\" + "images\\Disable History.ico");
			} else {
				mnu21CFR.Text = "Enable History";
				mnu21CFR.Image = Image.FromFile(Application.StartupPath + "\\" + "images\\Enable History.ico");
			}

			mnuStopAspiration.Click += btnStopAspiration_Click;

			mobjController = new clsBgThread(this);

			//---to start flame status thread
			subStartFlameStatusThread();

			HideProgressBar();

			//Added by Saurabh 
			if (gstructSettings.AppMode == EnumAppMode.FullVersion_203D | gstructSettings.AppMode == EnumAppMode.DemoMode_203D) {
				mnuDoubleBeam.Visible = true;
			} else {
				mnuDoubleBeam.Visible = false;
			}

			//Saurabh 10.07.07 To bring status form in front
			gobjfrmStatus.Show();
			//Saurabh
			//mnuAbout.Text = mnuAbout.Text & Space(1) & Me.Text
			//gobjclsTimer = New clsTimer(StatusBar1, 1000)
			gobjclsTimer.subTimerStart(StatusBar1);
			AddHandlers();
			mobjfrmMethod.BringToFront();
			Application.DoEvents();
		//gobjclsTimer = New clsTimer(StatusBar1, 1000)
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
			HideProgressBar();
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	private void frmMDIMain_Closing(object sender, System.ComponentModel.CancelEventArgs e)
	{
		//=====================================================================
		// Procedure Name        : frmMDIMain_Closing
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To close the form
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 14.11.06
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();

		try {
			e.Cancel = true;
			this.DialogResult = DialogResult.None;

			if (!mblnIsApplicationClosed) {
				subExit_Click(mnuExit, EventArgs.Empty);
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
			//---------------------------------------------------------
		}
	}

	private void frmMDIMain_Move(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : frmMDIMain_Move
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To  assign hight width to form the form
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 14.11.06
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();

		try {
			this.Top = 0;
			this.Left = 0;
			this.Width = 800;
			this.Height = 575;

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
			//add event handler to toolbar buttons and menus
			tlbbtnMethod.Click += mnuMethod_Click;
			mnuMethod.Click += mnuMethod_Click;

			tlbbtnAnalyse.Click += mnuAnalyse_Click;
			mnuAnalyse.Click += mnuAnalyse_Click;

			tlbbtnDataFiles.Click += mnuDataFiles_Click;
			mnuDataFiles.Click += mnuDataFiles_Click;

			tlbbtnCookBook.Click += mnuCookBook_Click;
			mnuCookBook.Click += mnuCookBook_Click;

			mnuExit.Click += subExit_Click;
			tlbbtnExit.Click += subExit_Click;

			tlbbtnUVSpectrum.Click += mnuUVSpectrum_Click;
			mnuUVSpectrum.Click += mnuUVSpectrum_Click;

			tlbbtnEnergySpectrum.Click += mnuEnergySpectrum_Click;
			//AddHandler mnuEnergySpectrum.Click, AddressOf mnuEnergySpectrum_Click

			tlbbtnService.Click += mnuServiceUtility_Click;
			mnuServiceUtility.Click += mnuServiceUtility_Click;
			//AddHandler mnuAboutUs.Click, AddressOf mnuAboutUs_Click

			tlbbtnIQOQPQ.Click += mnuIQOQPQ_Click;
			mnuIQOQPQ.Click += mnuIQOQPQ_Click;

			mnuAddUser.Click += mnuAddUser_Click;

			mnuUserPermissions.Click += mnuUserPermissions_Click;
			mnuActivityLog.Click += mnuActivityLog_Click;
			mnuDeleteLog.Click += mnuDeleteLog_Click;
			mnuChangePassword.Click += mnuChangePassword_Click;
			mnu21CFR.Click += mnu21CFR_Click;
			mnuPrinterSetup.Click += mnuPrinterSetup_Click;
			mnuPrintertype.Click += mnuPrintertype_Click;

			tlbbtnManualFlame.Click += mnuManualFlame_Click;
			mnuManualFlame.Click += mnuManualFlame_Click;

			base.Move += frmMDIMain_Move;
			base.Closing += frmMDIMain_Closing;
			mnuOpenReportFile.Click += mnuOpenReportFile_Click;

			mnuSingleBeam.Click += mnuSingleBeam_Click;
			mnuDoubleBeam.Click += mnuDoubleBeam_Click;
			//AddHandler Tmp1.Click, AddressOf btnIgnite_Click
			mnuLampElements.Click += mnuLampPosition_Click;

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

	private bool funcInitialise()
	{
		//=====================================================================
		// Procedure Name        : funcInitialise
		// Parameters Passed     : None
		// Returns               : True/False
		// Purpose               : 
		// Description           : Initialise the form Object
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 23.01.07
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();

		try {
			mnuFilterOn.CheckType = NETXP.Controls.Bars.ButtonItemCheckType.Checkmark;

			if (gobjClsAAS203.IsFilter == true) {
				mnuFilterOn.Checked = true;
				mnuFilterOn.Text = "Filter Off";
			} else {
				mnuFilterOn.Checked = false;
				mnuFilterOn.Text = "Filter On (201)";
			}

			mnuHydrideMode.CheckType = NETXP.Controls.Bars.ButtonItemCheckType.Checkmark;
			//---set hydride mode status on menu
			if (gstructSettings.HydrideMode == 1) {
				mnuHydrideMode.Checked = true;
				gobjInst.Hydride = true;
				HydrideMode = true;

				if (!gobjfrmStatus == null) {
					gobjfrmStatus.IsHydrideMode = true;
				}

			} else {
				mnuHydrideMode.Checked = false;
				gobjInst.Hydride = false;
				HydrideMode = false;

				if (!gobjfrmStatus == null) {
					gobjfrmStatus.IsHydrideMode = false;
				}
			}
			//Check for enable or disable for IQOQPQ Menu '10.12.07
			if (gstructSettings.EnableIQOQPQ == false) {
				IQOQPQ.Visible = false;
				//Added by Pankaj on 20 Feb 08
				tlbbtnIQOQPQ.Visible = false;
			} else {
				IQOQPQ.Visible = true;
				//Added by Pankaj on 20 Feb 08
				tlbbtnIQOQPQ.Visible = true;
			}

			//enable special feature for 203D
			if (gstructSettings.AppMode == EnumAppMode.FullVersion_203D) {
				mnuUVSpectrum.Enabled = true;
			} else {
				mnuUVSpectrum.Enabled = true;
			}

			if (gstructSettings.AppMode == EnumAppMode.FullVersion_203D | gstructSettings.AppMode == EnumAppMode.DemoMode_203D) {
				mnuChangeBeamType.Visible = true;
				mnuChangeBeamType.Items.Item(0).Enabled = true;
				mnuChangeBeamType.Items.Item(1).Enabled = true;
				//---changed on 20.03.08 to make beam type selection permanent
				if (gintInstrumentBeamType == enumInstrumentBeamType.SingleBeam) {
					mnuSingleBeam.Checked = true;
					mnuDoubleBeam.Checked = false;
				} else if (gintInstrumentBeamType == enumInstrumentBeamType.DoubleBeam) {
					mnuSingleBeam.Checked = false;
					mnuDoubleBeam.Checked = true;
				}

			} else {
				mnuChangeBeamType.SuspendEvents();
				mnuChangeBeamType.Visible = false;
				mnuChangeBeamType.ResumeEvents();
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
			objWait.Dispose();
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	private void mnuMethod_Click(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : mnuMethod_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To load the Method form
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 25.09.06
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		try {
			//---to bring method form in front
			ShowProgressBar(gstrTitleInstrumentType + ConstFormLoad);
			tlbbtnMethod.SuspendEvents();

			if ((gstructSettings.Enable21CFR == true)) {
				if (!funcCheckActivityAuthentication(enumActivityAuthentication.Method, gstructUserDetails.Access)) {
					return;
					return;
				}
				gfuncInsertActivityLog(EnumModules.Method, "Method Accessed");
			}
			mobjfrmMethod.Enabled = true;
			//Saurabh 'uncomment By Pankaj sun 20 May 07 
			mobjfrmMethod.BringToFront();
			//mobjfrmMethod.Activate()            'Saurabh
			mobjfrmMethod.btnNewMethod.Focus();
			//Saurabh
			//mobjfrmDataFiles.Enabled = False   'Saurabh
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
			if (!objWait == null) {
				objWait.Dispose();
			}
			//objfrmMethod.Dispose()
			tlbbtnMethod.ResumeEvents();
			HideProgressBar();
			this.Focus();
			//---------------------------------------------------------
		}
	}

	private void mnuAnalyse_Click(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : mnuAnalyse_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To load the Analysis form
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 25.09.06
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		int retval;
		bool blnIsMethodOK;
		Control ctrl;

		try {
			ShowProgressBar(gstrTitleInstrumentType + ConstFormLoadAnalysis);
			tlbbtnAnalyse.SuspendEvents();

			if ((gstructSettings.Enable21CFR == true)) {
				if (!funcCheckActivityAuthentication(enumActivityAuthentication.Analysis, gstructUserDetails.Access)) {
					return;
					return;
				}
				gfuncInsertActivityLog(EnumModules.Analysis, "Analysis Accessed");
			}

			//---First Check the Method is loaded properly and
			//---is ready to start the Analysis.
			gobjclsTimer.subTimerStop();
			if (!IsNothing(gobjNewMethod)) {
				if (gobjNewMethod.Status == true) {
				//---Allow user to proceed to Analysis
				} else {
					//---Don't allow user to enter Analysis.
					//MessageBox.Show("The method setting is not entered or loaded properly.", "No Method Loaded", MessageBoxButtons.OK, MessageBoxIcon.Error)
					gobjMessageAdapter.ShowMessage(constMethodNotLoaded);
					Application.DoEvents();
					return;
				}
			} else {
				//---Don't allow user to enter Analysis.
				//MessageBox.Show("The method setting is not entered or loaded properly.", "No Method Loaded", MessageBoxButtons.OK, MessageBoxIcon.Error)
				gobjMessageAdapter.ShowMessage(constMethodNotLoaded);
				Application.DoEvents();
				return;
			}


			//TO DO --- Add code for checking the Hardware lock later.

			//#If HARDWARELOCK Then
			//   if(!IsChemitoLock(0))
			//       break;
			//#End If


			if (!IsNothing(mobjfrmAnalysis)) {
				mobjfrmAnalysis.IsAvoidProcessing = true;
				retval = CheckMethod();
				if ((retval == 2)) {
					blnIsMethodOK = true;
					//---Hide Previous Window
					//Vis=FALSE;
					//DestroyWindow(Mhwnd);
					//Mhwnd=NULL;
					//mobjfrmAnalysis.Close()
					//mobjfrmAnalysis.Dispose()
					//mobjfrmAnalysis = Nothing
					mobjfrmAnalysis.funcRefreshMethodParameter();
					//If gblnSetSpeedIssue = True Then
					//28.09.07
					if (gobjMain.mobjController.IsThreadRunning == true) {
						gobjMain.mobjController.Cancel();
						//commented by Saurabh
						gobjCommProtocol.mobjCommdll.subTime_Delay(500);
						//10.12.07
						Application.DoEvents();
					}
					//End If

					mobjfrmAnalysis.Show();
					//---bring analysis from in front
					mobjfrmAnalysis.BringToFront();
					Application.DoEvents();
					mobjfrmAnalysis.btnStdGraph.Focus();
					Application.DoEvents();
					//mobjfrmAnalysis.tmrAspirationMsg.Enabled = True
					//If gblnSetSpeedIssue = True Then
					//28.09.07
					if (gobjMain.mobjController.IsThreadRunning == false) {
						gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay);
						//10.12.07
						Application.DoEvents();
						gobjMain.mobjController.Start(gobjclsBgFlameStatus);
						//commented by Saurabh
						Application.DoEvents();
					}
					//End If

					//--- Added by Mangesh on 14-Mar-2007
					//--- For Peak Latching when Instrument Settings of Method are changed 

					if (mblnIsMethodInstrumentSettingsChanged) {
						mblnIsMethodInstrumentSettingsChanged = false;
						if (gstructSettings.AppMode == EnumAppMode.DemoMode | gstructSettings.AppMode == EnumAppMode.DemoMode_201 | gstructSettings.AppMode == EnumAppMode.DemoMode_203D) {
						//---Don't perform Peak Latching operation for Demo Method
						} else {
							//---Search and Find Analytical Peak
							mobjfrmAnalysis.CheckInstrumentOptimisation();
						}
					}

				} else {
					blnIsMethodOK = false;
					if ((retval == 1)) {
						//MessageBox.Show("No Standards.", "ANALYSIS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						gobjMessageAdapter.ShowMessage(constNoStandards);
						Application.DoEvents();
					} else {
						gobjMessageAdapter.ShowMessage(constNoMethods);
						Application.DoEvents();
						//MessageBox.Show("No Method defined.", "ANALYSIS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					}
				}
				mobjfrmAnalysis.IsAvoidProcessing = false;
			}

			if (IsNothing(mobjfrmAnalysis)) {
				//---if analysis form is being opened for the first time
				//---then build new object of it and initialize it
				OnQuantAnalyse();
			}
			mobjfrmMethod.Enabled = false;
			//Saurabh'Pankaj on Sun 20 May 07
			//gobjclsTimer.subTimerStart(StatusBar1)
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
			gobjclsTimer.subTimerStart(StatusBar1);
			tlbbtnAnalyse.ResumeEvents();
			HideProgressBar();
			objWait.Dispose();
			this.Focus();
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	public void OnQuantAnalyse()
	{
		//=====================================================================
		// Procedure Name        : OnQuantAnalyse
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 13-Feb-2007 12:15 pm
		// Revisions             : 1
		//=====================================================================

		//---- ORIGINAL CODE

		//void	OnQuantAnalyse(HWND hwnd)
		//{
		//	int	mvalid;
		//	MSG	msg;
		//	int msgcount=0;

		//	mvalid = CheckMethod();

		//	if (mvalid==0)
		//		return;

		//	if (mvalid==2)
		//	{
		//		//ANALYSIS = TRUE;
		//		SetShortHelp("", TRUE);
		//                If (skp) Then
		//			FreeProcInstance(skp);
		//		skp = (DLGPROC) MakeProcInstance((DLGPROC) QuantAnalyseProc,hInst);
		//                    If (!QanaWnd) Then
		//		{
		//			Vis = FALSE;
		//			Mhwnd = CreateDialog(hInst,"QANALYSE", hwnd, skp);
		//			QanaWnd = Mhwnd;
		//			Vis = TRUE;
		//		}
		//                    Else
		//		{
		//			Mhwnd = QanaWnd;
		//			CurStd = Check_Std( Method->QuantData->StdTopData, CurStd);
		//			CurSamp = Check_Samp(Method->QuantData->SampTopData , CurSamp);
		//		}
		//		ShowWindow (Mhwnd, SW_SHOW); //MAXIMIZED) ;
		//		UpdateWindow (Mhwnd) ;
		//		SetMethodTittle1();
		//		Vis=TRUE;
		//		WP1=-1;
		//		CheckAnaButtons(Mhwnd);
		//		CheckInstrumentOptimisation(Mhwnd);

		//       While (1)
		//		{
		//			mvalid= CheckMsg1(Mhwnd, &msg);
		//			if (mvalid==2 && msg.message==WM_COMMAND ||WP1==800)
		//			{
		//               If (cmode! = CM_ANALYSE) Then
		//				    break;
		//			}
		//           ElseIf (Started) Then
		//			{
		//				Aspirate(Mhwnd);//Aspirate(); //mdf by sk on 29/2/2000 for autosampler
		//			}
		//		}
		//		DestroyAspWnd();
		//	}
		//	else if (mvalid==1)
		//		Gerror_message("No Standard Information available");

		//	SetShortHelp("", FALSE);

		//	if (WP1==800 && LP1==1000)
		//		PostMessage(hwnd,WM_COMMAND, CM_EXIT, 0L);

		//	WP1=0;
		//	ANALYSIS = FALSE;
		//}

		int mvalid;
		int msgcount;
		Message msg;

		try {
			//---check valid method
			mvalid = CheckMethod();

			if ((mvalid == 0)) {
				return;
			}

			if ((mvalid == 2)) {

				//SetShortHelp("", TRUE);
				//If (skp) Then
				//    'FreeProcInstance(skp);
				//End If
				//skp = (DLGPROC) MakeProcInstance((DLGPROC) QuantAnalyseProc,hInst);
				if (IsNothing(mobjfrmAnalysis)) {
					//Vis = False;
					//Mhwnd = CreateDialog(hInst,"QANALYSE", hwnd, skp);
					//QanaWnd = Mhwnd;
					//Vis = True;

					//Vis = False
					Application.DoEvents();
					//mobjfrmMethod.SendToBack()
					//---create new object of analysis form
					mobjfrmAnalysis = new frmAnalysis();
					mobjfrmAnalysis.IsAvoidProcessing = true;
					mobjfrmAnalysis.IsMdiContainer = false;
					mobjfrmAnalysis.TopLevel = false;
					//mobjfrmAnalysis.ToolBarAnalysis.Visible = False
					//mobjfrmAnalysis.StatusBar1.Visible = False
					mobjfrmAnalysis.ControlBox = false;
					mobjfrmAnalysis.Dock = DockStyle.Fill;
					mobjfrmAnalysis.Text = "";
					CustMain.Controls.Add(mobjfrmAnalysis);
					Application.DoEvents();
				//Vis = True
				} else {
					//Mhwnd = QanaWnd;
					//CurStd = Check_Std( Method->QuantData->StdTopData, CurStd);
					//CurSamp = Check_Samp(Method->QuantData->SampTopData , CurSamp);
				}

				if (mblnIsStartAnalysisRunNumber) {
					mobjfrmAnalysis.mblnIsStartRunNumber = true;
				}
				Application.DoEvents();
				// Set issue for Speed 
				//If gblnSetSpeedIssue = True Then
				//28.09.07
				if (gobjMain.mobjController.IsThreadRunning == true) {
					gobjMain.mobjController.Cancel();
					//commented by Saurabh
					gobjCommProtocol.mobjCommdll.subTime_Delay(500);
					//10.12.07
					Application.DoEvents();
				}
				//End If

				mobjfrmAnalysis.Show();
				mobjfrmAnalysis.IsAvoidProcessing = true;
				//---bring analysis form in front
				mobjfrmAnalysis.BringToFront();

				Application.DoEvents();
				//Vis = True
				//WP1 = -1
				//---set new analysis settings
				mobjfrmAnalysis.mblnExecuteRunNo = true;
				mobjfrmAnalysis.StartNewAnalysis();
				//---eneable/disable analysis buttons
				mobjfrmAnalysis.CheckAnaButtons();
				mobjfrmAnalysis.mblnExecuteRunNo = false;
				// Set issue for Speed 
				//If gblnSetSpeedIssue = True Then
				///If gobjMain.mobjController.IsThreadRunning = False Then  '25.11.07
				///    gobjMain.mobjController.Start(gobjclsBgFlameStatus)      'commented by Saurabh
				///    Application.DoEvents()
				///End If
				//End If
				if (gstructSettings.AppMode == EnumAppMode.DemoMode | gstructSettings.AppMode == EnumAppMode.DemoMode_201 | gstructSettings.AppMode == EnumAppMode.DemoMode_203D) {
				//---Don't perform Peak Latching operation for Demo Method
				} else {
					//---Search and Find Analytical Peak
					mobjfrmAnalysis.CheckInstrumentOptimisation();
				}

				//25.11.07
				if (gobjMain.mobjController.IsThreadRunning == false) {
					gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay);
					//10.12.07
					Application.DoEvents();
					gobjMain.mobjController.Start(gobjclsBgFlameStatus);
					Application.DoEvents();
				}
				mobjfrmAnalysis.IsAvoidProcessing = false;
			//While (1)
			//    'mvalid= CheckMsg1(Mhwnd, &msg)
			//    If (mvalid = 2 And msg.message = WM_COMMAND Or WP1 = 800) Then
			//        If (cmode <> CM_ANALYSE) Then
			//            Exit While
			//        End If
			//    ElseIf (Started) Then
			//        Aspirate() '//Aspirate(); //mdf by sk on 29/2/2000 for autosampler
			//    End If
			//End While
			//DestroyAspWnd()

			} else if ((mvalid == 1)) {
				//Gerror_message("No Standard Information available");
				gobjMessageAdapter.ShowMessage("No Standard Information available", "Analysis", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage);
				Application.DoEvents();
			}

		//SetShortHelp("", FALSE);
		//If (WP1 = 800 And LP1 = 1000) Then
		//    'PostMessage(hwnd,WM_COMMAND, CM_EXIT, 0L);
		//End If
		//WP1 = 0
		//ANALYSIS = False

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

	private void mnuDataFiles_Click(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : mnuDataFiles_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To load the Data Files form
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 25.09.06
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		Control objCntrl;

		try {
			//Saurabh 10.07.07 While Analysis under progress
			if (!IsNothing(mobjfrmAnalysis)) {
				if (mobjfrmAnalysis.InAnalysis) {
					gobjMessageAdapter.ShowMessage(constAnalysisUnderProgress);
					Application.DoEvents();
					return;
				}
			}
			//Saurabh 10.07.07 While Analysis under progress

			tlbbtnDataFiles.SuspendEvents();
			ShowProgressBar(gstrTitleInstrumentType + ConstFormLoadDataFiles);

			if ((gstructSettings.Enable21CFR == true)) {
				if (!funcCheckActivityAuthentication(enumActivityAuthentication.DataFiles, gstructUserDetails.Access)) {
					return;
					return;
				}
				gfuncInsertActivityLog(EnumModules.DataFiles, "DataFiles Accessed");
			}

			//---display data files form
			mobjfrmDataFiles.Show();
			//---bring data files form in front
			mobjfrmDataFiles.BringToFront();
			Application.DoEvents();
			mobjfrmDataFiles.btnLoad.Focus();
			//Saurabh
			mobjfrmMethod.SendToBack();
			mobjfrmDataFiles.BringToFront();
			//Added by pankaj on 26 Aug 07

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
			tlbbtnDataFiles.ResumeEvents();
			HideProgressBar();
			this.Focus();
			//---------------------------------------------------------
		}
	}

	private void subExit_Click(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : subExit_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To exit from the software 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 25.09.06
		// Revisions             : 
		//=====================================================================
		try {
			//---shut down application
			tlbbtnExit.SuspendEvents();

			ShutDownApplication();

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
			tlbbtnExit.ResumeEvents();
			//---------------------------------------------------------
		}
	}

	private void mnuCookBook_Click(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : mnuCookBook_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To load the Cook Book form
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 25.09.06
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		frmCookBook objfrmCookBook = new frmCookBook();
		DataTable objDtElement = new DataTable();
		DataTable objDtElementDetails = new DataTable();
		Control objCntrl;
		try {
			if ((gstructSettings.Enable21CFR == true)) {
				//check user authentication
				if (!funcCheckActivityAuthentication(enumActivityAuthentication.CookBook, gstructUserDetails.Access)) {
					return;
					return;
				}
				gfuncInsertActivityLog(EnumModules.CookBook, "CookBook Accessed");
			}

			tlbbtnCookBook.SuspendEvents();
			gblnCookBookReport = true;
			Application.DoEvents();

			//---to display cook book form
			objfrmCookBook = new frmCookBook();
			if (objfrmCookBook.ShowDialog() == DialogResult.OK) {
				//get element details from cookbook
				Application.DoEvents();
				ElementID = objfrmCookBook.ElementID;
				objDtElement = gobjClsAAS203.funcGetElement(ElementID);
				objDtElementDetails = gobjClsAAS203.funcGetElementWavelengths(ElementID);
			}
			gblnCookBookReport = false;
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
			tlbbtnCookBook.ResumeEvents();
			this.Focus();
			//---------------------------------------------------------
		}
	}

	private void mnuUVSpectrum_Click(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : mnuUVSpectrum_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To load the UV Spectrum form
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 25.09.06
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		frmUVScanningSpectrumMode objfrmUVSpectrumMode;
		frmUVScanningSpectrumDBMode objfrmUVSpectrumDBMode;

		try {
			if ((gstructSettings.Enable21CFR == true)) {
				//check for 21 CFR
				if (!funcCheckActivityAuthentication(enumActivityAuthentication.UV_Scanning_Spectrum_Mode, gstructUserDetails.Access)) {
					return;
					return;
				}
				gfuncInsertActivityLog(EnumModules.UV_Scanning_Spectrum_Mode, "UV_Scanning_Spectrum_Mode Accessed");
			}
			//---stop aspiration thread in analysis
			if (!IsNothing(mobjfrmAnalysis)) {
				if (!IsNothing(mobjfrmAnalysis.mobjBgMsgAspirate)) {
					if (mobjfrmAnalysis.IsDisplayingMessage == true) {
						mobjfrmAnalysis.mobjBgMsgAspirate.Cancel();
					}
				}
			}
			//--- Set issue for Speed 
			//If gblnSetSpeedIssue = True Then
			//28.09.07
			if (!gstructSettings.ExeToRun == EnumApplicationMode.ServiceUtility) {
				if (!IsNothing(gobjMain)) {
					if (gobjMain.mobjController.IsThreadRunning == true) {
						gobjMain.mobjController.Cancel();
						//commented by Saurabh
						gobjCommProtocol.mobjCommdll.subTime_Delay(500);
						//10.12.07
						Application.DoEvents();
					}
				}
			}
			//End If
			////---
			gobjclsTimer.subTimerStop();

			//---load uv spectrum form according to the instrument type
			gintSpectrumMode = modGlobalDeclarations.EnumSpectrumMode.UVSpetrum;
			if (gstructSettings.AppMode == EnumAppMode.FullVersion_203D) {
				objfrmUVSpectrumDBMode = new frmUVScanningSpectrumDBMode();
				objfrmUVSpectrumDBMode.ShowDialog();
				Application.DoEvents();
			} else if (gstructSettings.AppMode == EnumAppMode.FullVersion_203D | gstructSettings.AppMode == EnumAppMode.FullVersion_201) {
				objfrmUVSpectrumMode = new frmUVScanningSpectrumMode();
				objfrmUVSpectrumMode.ShowDialog();
				Application.DoEvents();
			} else {
				if (gintInstrumentBeamType == AAS203Library.Instrument.enumInstrumentBeamType.DoubleBeam) {
					objfrmUVSpectrumDBMode = new frmUVScanningSpectrumDBMode();
					objfrmUVSpectrumDBMode.ShowDialog();
					Application.DoEvents();
				} else {
					objfrmUVSpectrumMode = new frmUVScanningSpectrumMode();
					objfrmUVSpectrumMode.ShowDialog();
					Application.DoEvents();
				}
			}

			gobjclsTimer.subTimerStart(StatusBar1);
			//---start aspiration thread here
			if (!IsNothing(mobjfrmAnalysis)) {
				if (!IsNothing(mobjfrmAnalysis.mobjBgMsgAspirate)) {
					if (mobjfrmAnalysis.IsDisplayingMessage == true) {
						mobjfrmAnalysis.mobjBgMsgAspirate.Start();
					}
				}
			}
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
			if (!objWait == null) {
				objWait.Dispose();
			}
			this.Focus();
			//---------------------------------------------------------
		}
	}

	private void  // ERROR: Handles clauses are not supported in C#
mnuEnergySpectrum_Click(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : mnuEnergySpectrum_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To load the Energy Spectrum form
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 25.09.06
		// Revisions             : 
		//=====================================================================
		frmEnergySpectrumMode objfrmEnergySpectrumMode;
		frmEnergySpectrumDBMode objfrmEnergySpectrumDBMode;
		CWaitCursor objWait = new CWaitCursor();
		try {
			if ((gstructSettings.Enable21CFR == true)) {
				//check for 21 CFR
				if (!funcCheckActivityAuthentication(enumActivityAuthentication.Energy_Spectrum_Mode, gstructUserDetails.Access)) {
					return;
					return;
				}
				gfuncInsertActivityLog(EnumModules.Energy_Spectrum_Mode, "Energy_Spectrum_Mode Accessed");
			}

			//--- Set issue for Speed 
			//If gblnSetSpeedIssue = True Then
			//28.09.07
			if (!gstructSettings.ExeToRun == EnumApplicationMode.ServiceUtility) {
				if (!IsNothing(gobjMain)) {
					if (gobjMain.mobjController.IsThreadRunning == true) {
						gobjMain.mobjController.Cancel();
						//commented by Saurabh
						gobjCommProtocol.mobjCommdll.subTime_Delay(500);
						//10.12.07
						Application.DoEvents();
					}
				}
			}
			//End If
			////---

			//---stop aspiration thread
			gintSpectrumMode = modGlobalDeclarations.EnumSpectrumMode.EnergySpectrum;
			if (!IsNothing(mobjfrmAnalysis)) {
				if (!IsNothing(mobjfrmAnalysis.mobjBgMsgAspirate)) {
					if (mobjfrmAnalysis.IsDisplayingMessage == true) {
						mobjfrmAnalysis.mobjBgMsgAspirate.Cancel();
					}
				}
			}

			//---display energy spectrum form according to the instrument type
			gobjclsTimer.subTimerStop();

			if (gstructSettings.AppMode == EnumAppMode.FullVersion_203D) {
				objfrmEnergySpectrumDBMode = new frmEnergySpectrumDBMode();
				objfrmEnergySpectrumDBMode.ShowDialog();
				Application.DoEvents();
			////----- added by Sachin Dokhale

			} else if (gstructSettings.AppMode == EnumAppMode.FullVersion_201 | gstructSettings.AppMode == EnumAppMode.FullVersion_203) {
				objfrmEnergySpectrumMode = new frmEnergySpectrumMode();
				objfrmEnergySpectrumMode.ShowDialog();
				Application.DoEvents();
			} else {
				if (gintInstrumentBeamType == AAS203Library.Instrument.enumInstrumentBeamType.DoubleBeam) {
					objfrmEnergySpectrumDBMode = new frmEnergySpectrumDBMode();
					objfrmEnergySpectrumDBMode.ShowDialog();
					Application.DoEvents();
				} else {
					objfrmEnergySpectrumMode = new frmEnergySpectrumMode();
					objfrmEnergySpectrumMode.ShowDialog();
					Application.DoEvents();
				}
			}

			//---start aspiration thread here
			if (!IsNothing(mobjfrmAnalysis)) {
				if (!IsNothing(mobjfrmAnalysis.mobjBgMsgAspirate)) {
					if (mobjfrmAnalysis.IsDisplayingMessage == true) {
						mobjfrmAnalysis.mobjBgMsgAspirate.Start();
					}
				}
			}
			gobjclsTimer.subTimerStart(StatusBar1);
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
			if (!objWait == null) {
				objWait.Dispose();
			}
			this.Focus();
			//---------------------------------------------------------
		}
	}

	private void mnuAboutUs_Click(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : mnuAboutUs_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To show About Us form.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 05.12.06
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		frmAboutUs objfrmAboutUs = new frmAboutUs();
		try {
			objfrmAboutUs.ShowDialog();
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
			if (!objWait == null) {
				objWait.Dispose();
			}
			this.Focus();
			//---------------------------------------------------------
		}
	}

	private void mnuServiceUtility_Click(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : mnuServiceUtility_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To load the Service Utility form
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 25.09.06
		// Revisions             : 
		//=====================================================================
		//Dim objWait As New CWaitCursor
		frmMDIMainService objfrmMDIMainService = new frmMDIMainService();
		try {
			//check for 21 CFR
			if ((gstructSettings.Enable21CFR == true)) {
				if (!funcCheckActivityAuthentication(enumActivityAuthentication.ServiceUtilities, gstructUserDetails.Access)) {
					return;
					return;
				}
				gfuncInsertActivityLog(EnumModules.Service_Utilities, "ServiceUtilities Accessed");
			}


			objfrmMDIMainService.ShowDialog();
			Application.DoEvents();
			this.Visible = true;
			objfrmMDIMainService.Dispose();
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
			//If Not objWait Is Nothing Then
			//    objWait.Dispose()
			//End If
			this.Focus();
			//---------------------------------------------------------
		}
	}

	private void mnuOpenReportFile_Click(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : mnuOpenReportFile_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To Open the Expoted or Multi Report file
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 25.09.06
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		frmTextReportViewer objfrmTextReportViewer;
		System.IO.Stream objStream;
		string strReportFilePath;
		OpenFileDialog objofdSpectrum = new OpenFileDialog();
		try {
			//check for 21 CFR
			if ((gstructSettings.Enable21CFR == true)) {
				if (!funcCheckActivityAuthentication(enumActivityAuthentication.ServiceUtilities, gstructUserDetails.Access)) {
					return;
					return;
				}
				gfuncInsertActivityLog(EnumModules.Service_Utilities, "ServiceUtilities Accessed");
			}
			//---To Show the Report 

			//



			objofdSpectrum.InitialDirectory = strPath.GetCurrentDirectory.ToString + "\\TextReports";
			objofdSpectrum.Filter = "Exported or Multi Report Files(*" + CONST_Export + ")|*" + CONST_Export;
			objofdSpectrum.FilterIndex = 1;
			objofdSpectrum.RestoreDirectory = true;

			if (objofdSpectrum.ShowDialog() == DialogResult.OK) {

				if ((objofdSpectrum.CheckFileExists())) {
					strReportFilePath = objofdSpectrum.FileName;

					objfrmTextReportViewer = new frmTextReportViewer();
					objfrmTextReportViewer.ReportFilePath = strReportFilePath;

					objfrmTextReportViewer.ShowDialog();
					objfrmTextReportViewer.Close();
				}
			}

			Application.DoEvents();
			this.Visible = true;

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
			if (!objfrmTextReportViewer == null) {
				objfrmTextReportViewer.Dispose();
				objfrmTextReportViewer = null;
			}
			if (!objWait == null) {
				objWait.Dispose();
			}
			Application.DoEvents();
			this.Focus();
			//---------------------------------------------------------
		}
	}

	private void mnuIQOQPQ_Click(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : mnuIQOQPQ_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To load the IQOQPQ form
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 25.09.06
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		string strIQPQOQDataBaseName;
		string strIQPQOQDatabasePassword;
		string strProvider;
		int intDataSourceType;
		string strUserName;
		string strPassword;
		string strSqlDataSource;

		Configuration.ConfigurationSettings objConfig;
		string strConfigPath;
		string strDatabasePath;

		try {
			IsInIQOQPQ = true;
			//Saruabh 22.07.07
			strConfigPath = Application.ExecutablePath + ".config";
			if (!System.IO.File.Exists(strConfigPath)) {
			//---display message "app.config file not found"
			//gobjMessageAdapter.ShowMessage(msgIDAppConfigFileNotFound)
			} else {
				intDataSourceType = (int)objConfig.AppSettings("DataSorceType");
				strProvider = objConfig.AppSettings.Item("Provider");
				strUserName = objConfig.AppSettings.Item("User Name");
				strPassword = objConfig.AppSettings.Item("Password");
				strDatabasePath = objConfig.AppSettings.Item("DatabasePath");

				//---Added Database Name, Path, and Password in App.Config
				strIQPQOQDataBaseName = objConfig.AppSettings.Item("IQPQOQDatabaseName");
				strIQPQOQDatabasePassword = objConfig.AppSettings.Item("IQPQOQDatabasePassword");
				gobjIQOQPQ = new IQOQPQ.IQOQPQ.IQOQPQ();
				gobjIQOQPQ.Test_IQOQPQ_Attachment1 += IQOQPQ_Attachment1_Test_Clicked;
				gobjIQOQPQ.Test_IQOQPQ_AttachmentII += IQOQPQ_AttachmentII_Test_Clicked;
				gobjIQOQPQ.Test_IQOQPQ_AttachmentIII += IQOQPQ_AttachmentIII_Test_Clicked;
				gobjIQOQPQ.InstrumentType += IQOQPQ_InstrumentType;

				//addhandler gobjIQOQPQ. 
				//---For IQOQPQ Database name, Path and password
			}

			//--- Writing to Activity Log
			if ((gstructSettings.Enable21CFR == true)) {
				//--- Check for activity authentication
				if (!funcCheckActivityAuthentication(enumActivityAuthentication.IQOQPQ, gstructUserDetails.Access)) {
					return;
					return;
				}
				gfuncInsertActivityLog(EnumModules.IQOQPQ, "IQOQPQ Accessed");
			}


			gobjIQOQPQ.ShowIQOQPQ(strDatabasePath, strProvider, strIQPQOQDataBaseName, strUserName, strIQPQOQDatabasePassword);

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
			IsInIQOQPQ = false;
			this.Focus();
			//---------------------------------------------------------
		}

	}
	private void mnuAddUser_Click(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : mnuAddUser_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To open the Add User form 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 25.12.06
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		frmAddUser frmAddUser = new frmAddUser();
		try {
			frmAddUser.ShowDialog();

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
			tlbbtnExit.ResumeEvents();
			//---------------------------------------------------------
		}

	}

	private void mnuUserPermissions_Click(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : mnuUserPermissions_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To open the User Permissions form 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 25.12.06
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		frmUserPermissions frmUserPermissions = new frmUserPermissions();
		try {
			frmUserPermissions.ShowDialog();
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
			tlbbtnExit.ResumeEvents();
			//---------------------------------------------------------
		}

	}

	private void mnuActivityLog_Click(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : mnuActivityLog_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To open the Activity Log form 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 25.12.06
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		frmActivityLog frmActivityLog = new frmActivityLog();
		try {
			frmActivityLog.ShowDialog();

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

	private void mnuDeleteLog_Click(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : mnuDeleteLog_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To open the Delete log form 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 25.12.06
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		frmDeleteLogs frmDeleteLog = new frmDeleteLogs();
		try {
			frmDeleteLog.ShowDialog();

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

	private void mnuChangePassword_Click(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : mnuChangePassword_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To open Change Password form
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 25.12.06
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		frmChangePassword frmChangePassword = new frmChangePassword();
		try {
			frmChangePassword.ShowDialog();
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

	private void mnu21CFR_Click(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : mnu21CFR_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : Enable or disable 21 CFR
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 25.12.06
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		try {
			if (gstructSettings.Enable21CFR == true) {
				//mnu21CFR.Image.FromFile = Application.StartupPath & "\Images\Enable History.ico"
				mnu21CFR.Image = Image.FromFile(Application.StartupPath + "\\" + "images\\Enable History.ico");
				mnu21CFR.Text = "Enable History";
				gstructSettings.Enable21CFR = false;
			//       Call gfuncSetEnable21CFRToINI(gstructApplicationSettings.Enable21CFR)
			} else {
				mnu21CFR.Image = Image.FromFile(Application.StartupPath + "\\" + "images\\Disable History.ico");
				mnu21CFR.Text = "Disable History";
				gstructSettings.Enable21CFR = true;
				//        Call gfuncSetEnable21CFRToINI(gstructApplicationSettings.Enable21CFR)
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

	private void mnuPrintertype_Click(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : mnuPrinterType_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To load the Printer type form
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 21.11.06
		// Revisions             : 
		//=====================================================================
		frmPrinterType objfrmPrinterType = new frmPrinterType();
		CWaitCursor objWait = new CWaitCursor();
		try {
			//---to select printer type
			if (gstructSettings.blnSelectColorPrinter == true) {
				objfrmPrinterType.rbColor.Checked = true;
				objfrmPrinterType.rbNormal.Checked = false;
			} else {
				objfrmPrinterType.rbColor.Checked = false;
				objfrmPrinterType.rbNormal.Checked = true;
			}

			if (objfrmPrinterType.ShowDialog() == DialogResult.OK) {
				if (objfrmPrinterType.rbColor.Checked == true) {
					gstructSettings.blnSelectColorPrinter = true;
				} else if (objfrmPrinterType.rbNormal.Checked == true) {
					gstructSettings.blnSelectColorPrinter = false;
				}
			}
			gobjPageSetting.Color = gstructSettings.blnSelectColorPrinter;
			objfrmPrinterType.Close();
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
			if (!objfrmPrinterType == null) {
				objfrmPrinterType.Dispose();
			}
			if (!objWait == null) {
				objWait.Dispose();
			}
			//---------------------------------------------------------
		}
	}

	private void mnuPrinterSetup_Click(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : mnuPrinterSetup_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To load the Printer setting form
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 27.01.07
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		PageSetupDialog objPageSetupDialog = new PageSetupDialog();
		System.Drawing.Printing.PrintDocument objPrintDocument = new System.Drawing.Printing.PrintDocument();
		try {
			objPageSetupDialog.Document = objPrintDocument;
			if (objPageSetupDialog.ShowDialog == DialogResult.OK) {
				gobjPageSetting = objPageSetupDialog.PageSettings;
			}

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
			if (!objPageSetupDialog == null) {
				objPageSetupDialog.Dispose();
			}
			if (!objPrintDocument == null) {
				objPrintDocument.Dispose();
			}
			if (!objWait == null) {
				objWait.Dispose();
			}
			//---------------------------------------------------------
		}
	}

	private void  // ERROR: Handles clauses are not supported in C#
mnuHydrideMode_Click(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : mnuHydrideMode_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To set or unset the Hydride Mode
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 22.01.07
		// Revisions             : 2
		// Revisions By          : Mangesh on 17-Mar-2007
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();

		try {
			//Added By Pankaj on Sat 19 May 2007
			//check for 21 CFR
			if ((gstructSettings.Enable21CFR == true)) {
				//28.3.2010 insted of accessories in enum hydride mode selected.
				if (!funcCheckActivityAuthentication(enumActivityAuthentication.HydrideMode, gstructUserDetails.Access)) {
					return;
				}
				gfuncInsertActivityLog(EnumModules.Analysis, "Hydride Mode Accessed");
			}
			//----------------
			mnuHydrideMode.CheckType = NETXP.Controls.Bars.ButtonItemCheckType.Checkmark;
			//chrck for hydride mode
			if (mnuHydrideMode.Checked == true) {
				mnuHydrideMode.Checked = false;
				gobjInst.Hydride = false;
				gstructSettings.HydrideMode = 0;
				gobjfrmStatus.IsHydrideMode = false;
				HydrideMode = false;
			} else {
				mnuHydrideMode.Checked = true;
				gobjInst.Hydride = true;
				HydrideMode = true;
				gstructSettings.HydrideMode = 1;
				gobjfrmStatus.IsHydrideMode = true;
				gobjMessageAdapter.ShowMessage("HYDRIDE MODE", "CONFIGURATION", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage);
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
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	private void  // ERROR: Handles clauses are not supported in C#
mnuFilterOn_Click(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : mnuFilterOn_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To load the Printer type form
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 22.01.07
		// Revisions             : 
		//=====================================================================

		CWaitCursor objWait = new CWaitCursor();
		try {
			//---to enable or disable filter
			mnuFilterOn.CheckType = NETXP.Controls.Bars.ButtonItemCheckType.Checkmark;
			//check for filter
			if (mnuFilterOn.Checked == true) {
				mnuFilterOn.Checked = false;
				gobjClsAAS203.funcEnableDisableFilter(false);
				//mnuFilterOn.Text = "Filster Off"
				mnuFilterOn.Text = "Filter On (201)";
			} else {
				mnuFilterOn.Checked = true;
				gobjClsAAS203.funcEnableDisableFilter(true);
				//mnuFilterOn.Text = "Filter On (201)"
				mnuFilterOn.Text = "Filter Off";
			}

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
			if (!objWait == null) {
				objWait.Dispose();
			}

		}
	}

	private void  // ERROR: Handles clauses are not supported in C#
mnuEnableAutoSAmpler_Click(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : mnuEnableAutoSAmpler_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To set AutoSampler Enable/ Disable
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 22.01.07
		// Revisions             : 
		//=====================================================================

		CWaitCursor objWait = new CWaitCursor();
		try {
			//Added By Pankaj on Sat 19 May 2007
			//check for 21CFR
			if ((gstructSettings.Enable21CFR == true)) {
				if (!funcCheckActivityAuthentication(enumActivityAuthentication.Accessories, gstructUserDetails.Access)) {
					return;
				}
				gfuncInsertActivityLog(EnumModules.Analysis, "Enable Auto Sampler Accessed");
			}

			//---to enable or disable autosampler
			//'by Pankaj for autosampler on 10Sep 07
			if ((gstructAutoSampler.blnAutoSamplerInitialised == false)) {
				mnuEnableAutoSAmpler.Text = "Disable Autosampler";
				gstructAutoSampler.blnAutoSamplerInitialised = true;
				gFuncInitSampler(gstructAutoSampler);
			} else {
				mnuEnableAutoSAmpler.Text = "Enable Autosampler";
				gstructAutoSampler.blnAutoSamplerInitialised = false;
				gobjCommProtocol.mobjCommdll.gFuncCloseComm2();
			}
			mnuCheckSamplerFunctions.Enabled = gstructAutoSampler.blnAutoSamplerInitialised;
			//gfuncWriteAutoSamplerFlag()

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
			if (!objWait == null) {
				objWait.Dispose();
			}
			//---------------------------------------------------------
		}
	}

	private void  // ERROR: Handles clauses are not supported in C#
mnuSetAbsorbanceThreshold_Click(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : mnuSetAbsorbanceThreshold_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To open absorbance threshold form. 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 22.01.07
		// Revisions             : 
		//=====================================================================

		frmThreshold objfrmThreshold = new frmThreshold();
		CWaitCursor objWait = new CWaitCursor();
		try {
			//---display absorbance threshold value
			objfrmThreshold.txtThresholdValue.Text = gstructSettings.AbsThresholdValue;


			if (objfrmThreshold.ShowDialog() == DialogResult.OK) {
				gstructSettings.AbsThresholdValue = objfrmThreshold.txtThresholdValue.Text;

			}
			objfrmThreshold.Close();
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

			if (!objfrmThreshold == null) {
				objfrmThreshold.Dispose();
			}

			if (!objWait == null) {
				objWait.Dispose();
			}
			//---------------------------------------------------------
		}
	}

	private void mnuManualFlame_Click(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : mnuManualIgnition_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To load the ManualIgnition form
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 27.11.06
		// Revisions             : Sachin Dokhale 
		//=====================================================================
		frmManualIgnition objfrmManualIgnition = new frmManualIgnition();
		CWaitCursor objWait = new CWaitCursor();

		try {
			//---to display manual flame form
			//RemoveHandler mnuManualFlame.Click, AddressOf mnuManualFlame_Click
			//If Not gstructSettings.AppMode = EnumAppMode.DemoMode Or _
			//Not gstructSettings.AppMode = EnumAppMode.DemoMode_201 Or _
			//Not gstructSettings.AppMode = EnumAppMode.DemoMode_203D Then
			//---stop aspiration thread
			if (!IsNothing(mobjfrmAnalysis)) {
				if (!IsNothing(mobjfrmAnalysis.mobjBgMsgAspirate)) {
					if (mobjfrmAnalysis.IsDisplayingMessage == true) {
						mobjfrmAnalysis.mobjBgMsgAspirate.Cancel();
					}
				}
			}
			gobjclsTimer.subTimerStop();
			mobjController.Cancel();
			gobjCommProtocol.mobjCommdll.subTime_Delay(1000);
			//10.12.07
			Application.DoEvents();
			//If Not objWait Is Nothing Then
			//    objWait.Dispose()
			//End If
			Application.DoEvents();

			// code added by : dinesh wagh on 22.3.2009
			// code start
			if (gstructSettings.AppMode == EnumAppMode.DemoMode_201 | gstructSettings.AppMode == EnumAppMode.FullVersion_201) {
				objfrmManualIgnition.Width = objfrmManualIgnition.Width - 175;
				objfrmManualIgnition.StartPosition = FormStartPosition.CenterScreen;
			}
			//........code ends.

			objfrmManualIgnition.ShowDialog();
			//Else
			//    Call gobjMessageAdapter.ShowMessage("Manual Flame", "Manual Flame", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage)
			//End If

			gobjclsTimer.subTimerStart(StatusBar1);
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
			if (!gstructSettings.AppMode == EnumAppMode.DemoMode) {
				//---start aspiration thread
				if (!IsNothing(mobjfrmAnalysis)) {
					if (!IsNothing(mobjfrmAnalysis.mobjBgMsgAspirate)) {
						if (mobjfrmAnalysis.IsDisplayingMessage == true) {
							mobjfrmAnalysis.mobjBgMsgAspirate.Start();
						}
					}
				}
				//---start flame status thread
				//10.12.07
				if (gobjMain.mobjController.IsThreadRunning == false) {
					gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay);
					Application.DoEvents();
					mobjController.Start(gobjclsBgFlameStatus);
				}
				Application.DoEvents();
			}
			//AddHandler mnuManualFlame.Click, AddressOf mnuManualFlame_Click
			if (!objWait == null) {
				objWait.Dispose();
			}

		}
	}

	private void btnStopAspiration_Click(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : btnStopAspiration_Click
		// Parameters Passed     : Object, EventArgs
		// Returns               : None
		// Purpose               : To stop the aspiration when the Measurement
		//                         mode of Method is PeakArea or PeakHeight
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 03-Apr-2007 06:45 pm
		// Revisions             : 1
		//=====================================================================
		try {
			if (!IsNothing(mobjfrmAnalysis)) {
				if (!IsNothing(mobjfrmAnalysis.mobjBgReadData)) {
					mobjfrmAnalysis.mobjBgReadData.IsAlt_S_Pressed = true;
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

	private bool ShutDownApplication()
	{
		//=====================================================================
		// Procedure Name        : ShutDownApplication
		// Parameters Passed     : None
		// Returns               : True or false
		// Purpose               : 
		// Description           : to shut down the application by
		//                         stopping all running threads, release resources and free memory
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 17-Jan-2007 03:25 pm
		// Revisions             : 1
		//=====================================================================
		try {
			//If (InAnalysis) Then
			//{
			//	MessageBox(hwnd,"Analysis under progress","PROTECTION",MB_ICONSTOP|MB_OK);
			//	break;
			//}
			if (!IsNothing(mobjfrmAnalysis)) {
				if (mobjfrmAnalysis.InAnalysis) {
					gobjMessageAdapter.ShowMessage(constAnalysisUnderProgress);
					Application.DoEvents();
					return false;
					return;
				}
			}

			if (gobjMessageAdapter.ShowMessage(constExit) == true) {
				Application.DoEvents();

				//Call mobjTimerToCheckFlame.Stop()

				//---dispose data files form
				if (!IsNothing(mobjfrmDataFiles)) {
					mobjfrmDataFiles.Close();
					mobjfrmDataFiles.Dispose();
					mobjfrmDataFiles = null;
				}

				//---stop aspiration thread
				if (!IsNothing(mobjfrmAnalysis)) {
					if (!IsNothing(mobjfrmAnalysis.mobjBgMsgAspirate)) {
						if (mobjfrmAnalysis.IsDisplayingMessage == true) {
							mobjfrmAnalysis.mobjBgMsgAspirate.Cancel();
						}
					}
				}
				//---dispose analysis form
				if (!IsNothing(mobjfrmAnalysis)) {
					mobjfrmAnalysis.Close();
					mobjfrmAnalysis.Dispose();
					mobjfrmAnalysis = null;
				}
				//---dispose method form
				if (!IsNothing(mobjfrmMethod)) {
					mobjfrmMethod.Close();
					mobjfrmMethod.Dispose();
					mobjfrmMethod = null;
				}
				//---stop global timer for clock 
				if (!(gobjclsTimer == null)) {
					gobjclsTimer.subTimerStop();
				}

				//---stop flame status thread
				mobjController.Cancel();
				gobjCommProtocol.mobjCommdll.subTime_Delay(1000);
				Application.DoEvents();
				mobjController = null;
				gobjCommProtocol.mobjCommdll.subTime_Delay(1000);
				Application.DoEvents();
				//---Shut_Down Instrument
				//#If !GRAPHITE Then
				//   Flame_Off();
				//#Else
				//	gSerialClose();
				//#End If

				//If (ReadIniForD2Gain()) Then
				//   GainX10Off()
				//end if
				//If (ReadIniForMesh()) Then
				//   SetMicroOff()
				//end if

				//---set all lamps off
				//---set pmt as 0.0
				//---reset instrument
				//---close the comm port
				if (gobjCommProtocol.mobjCommdll.gFuncIsPortOpen()) {
					gobjCommProtocol.funcAll_Lamp_Off();
					gobjCommProtocol.funcSet_PMT(0.0);
					////----- Added by Sachin Dokhale 
					////----- Flame Off the instrument at time of exit from application if is ignited
					gobjCommProtocol.funcResetInstrument();
					//gobjCommProtocol.funcResetInstrument()
					////----
					gobjCommProtocol.mobjCommdll.gFuncCloseComm();
					gobjCommProtocol.mobjCommdllAutoSampler.gFuncCloseComm2();
				}
				//BH_File_save()

				mblnIsApplicationClosed = true;
				this.DialogResult = DialogResult.OK;
				this.Close();
				this.Dispose();

				Application.DoEvents();
				Application.Exit();

				return true;
			} else {
				return false;
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
mobjfrmMethod_LoadedMethodChanged()
	{
		//=====================================================================
		// Procedure Name        : mobjfrmMethod_LoadedMethodChanged
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : To load the Analysis again for New Method
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 15-Mar-2007 09:15 pm
		// Revisions             : 1
		//=====================================================================
		try {
			//---dispose existing analysis form
			if (!IsNothing(mobjfrmAnalysis)) {
				mobjfrmAnalysis.Close();
				mobjfrmAnalysis.Dispose();
				mobjfrmAnalysis = null;
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

	public void subStartFlameStatusThread()
	{
		//=====================================================================
		// Procedure Name        : subStartFlameStatusThread
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : To start flame status thread 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 15-Mar-2007 09:15 pm
		// Revisions             : 1
		//=====================================================================
		try {
			//---start flame status thread
			mobjController = new clsBgThread(this);

			gobjclsBgFlameStatus = new clsBgFlameStatus();
			gobjclsBgFlameStatus.Initialize(mobjController);
			gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay);
			//10.12.07
			Application.DoEvents();
			mobjController.Start(gobjclsBgFlameStatus);

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

	private void mnuSingleBeam_Click(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : mnuSingleBeam_Click
		// Parameters Passed     : Object, EventArgs
		// Returns               : None
		// Purpose               : To change the Beam type to Single or Double 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 13-Apr-2007 06:35 pm
		// Revisions             : 1
		//=====================================================================
		try {
			//---to change beam type
			if (!gintInstrumentBeamType == AAS203Library.Instrument.enumInstrumentBeamType.SingleBeam) {
				gobjClsAAS203.funcSelectDoubleBeamType(false);
			}
			mnuDoubleBeam.Checked = false;
			mnuSingleBeam.Checked = true;
			mnuDoubleBeam.DefaultItem = false;
			mnuSingleBeam.DefaultItem = true;
			if (gstructSettings.AppMode == EnumAppMode.FullVersion_203D) {
				mnuUVSpectrum.Enabled = true;
				if (gintInstrumentBeamType == AAS203Library.Instrument.enumInstrumentBeamType.SingleBeam) {
					gobjInst.PmtVoltageReference = 0.0;
				}
			} else {
				mnuUVSpectrum.Enabled = true;
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

	private void mnuDoubleBeam_Click(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : mnuDoubleBeam_Click
		// Parameters Passed     : Object, EventArgs
		// Returns               : None
		// Purpose               : To change the Beam type to Single or Double 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 13-Apr-2007 06:35 pm
		// Revisions             : 1
		//=====================================================================
		try {
			//---to change beam type
			if (!gintInstrumentBeamType == AAS203Library.Instrument.enumInstrumentBeamType.DoubleBeam) {
				gobjClsAAS203.funcSelectDoubleBeamType(true);
			}
			mnuSingleBeam.Checked = false;
			mnuDoubleBeam.Checked = true;
			mnuDoubleBeam.DefaultItem = true;
			mnuSingleBeam.DefaultItem = false;
			if (gstructSettings.AppMode == EnumAppMode.FullVersion_203D) {
				mnuUVSpectrum.Enabled = true;
			} else {
				mnuUVSpectrum.Enabled = true;
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

	private void mnuLampPosition_Click(System.Object sender, System.EventArgs e)
	{
		frmTurretElements objFrmTurret = new frmTurretElements();
		objFrmTurret.ShowDialog();
	}

	#End Region

	#Region " ProgressBar Functions "

	public void ShowProgressBar(string message)
	{
		//=====================================================================
		// Procedure Name        : ShowProgressBar
		// Parameters Passed     : message
		// Returns               : None
		// Purpose               : to show the progress bar
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : Saturday, January 22, 2005
		// Revisions             : 
		//=====================================================================
		try {
			ProgressPanel.Value = 20;

			//StatusBarPanelInfo.Text = message
			if (gblnShowThreadOnfrmMDIStatusBar) {
				StatusBarPanelInfo.Text = StatusBarPanelInfo.Text + " " + message;
			} else {
				StatusBarPanelInfo.Text = message;
			}
			//start a new thread to increment the progressbar
			Thread progressThread = new Thread(BackGroundIncrementProgressBar);
			progressThread.IsBackground = true;
			progressThread.Name = "Progress Bar";
			progressThread.Start();

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

	private void BackGroundIncrementProgressBar()
	{
		//=====================================================================
		// Procedure Name        : BackGroundIncrementProgressBar
		// Parameters Passed     : None
		// Returns               : None 
		// Purpose               : to increment the progress of progress bar
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : Saturday, January 22, 2005
		// Revisions             : 
		//=====================================================================
		try {
			//note: this will run on a worker thread
			while (ProgressPanel.Value != 100) {
				if (ProgressPanel.Value < 80)
					ProgressPanel.Value += 8;
				Thread.Sleep(30);
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

	public void HideProgressBar()
	{
		//=====================================================================
		// Procedure Name        : HideProgressBar
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : to finish the progress bar
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : Sunday, January 23, 2005
		// Revisions             : 
		//=====================================================================
		try {
			//this sleep code is only eye candy but note that we must set m_ProgressBar.Value = 100
			//so that BackGroundIncrementProgressBar() can die
			int i;
			for (i = 0; i <= 16; i++) {
				Thread.Sleep(30);
				Application.DoEvents();

				//show 100% for a glance
				if (i == 15)
					ProgressPanel.Value = 100;
			}
			ProgressPanel.Value = 0;

			//ProgressPanel.Text = Application.ProductName & Space(1) & Application.ProductVersion
			ProgressPanel.Text = gstrTitleInstrumentType + Space(1) + "S/W Ver. : " + Mid(Application.ProductVersion, 1, 4);

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

	public void ShowRunTimeInfo(string message)
	{
		//=====================================================================
		// Procedure Name        : ShowRunTimeInfo
		// Parameters Passed     : message
		// Returns               : None
		// Purpose               :  
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : Saturday, January 22, 2005
		// Revisions             : 
		//=====================================================================
		try {
			//ProgressPanel.Value = 20
			if (gblnShowThreadOnfrmMDIStatusBar) {
				StatusBarPanelInfo.Text = StatusBarPanelInfo.Text + " " + message;
			} else {
				StatusBarPanelInfo.Text = message;
			}
		//start a new thread to increment the progressbar
		//Dim progressThread As New Thread(AddressOf BackGroundIncrementProgressBar)
		//progressThread.IsBackground = True
		//progressThread.Name = "Progress Bar"
		//progressThread.Start()

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

	public void BgThread.Iclient.Completed(bool Cancelled)
	{
		///---Temporarily ...
		//'Call gobjMessageAdapter.ShowStatusMessageBox("Flame Status Thread Stopped.", "Flame Status", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage, 1000)
		//'Application.DoEvents()
		//'Call gobjMessageAdapter.CloseStatusMessageBox()
		//'Application.DoEvents()
		///---Temporarily ...
	}

	public void BgThread.Iclient.Display(string Text)
	{
		//=====================================================================
		// Procedure Name        : Display
		// Parameters Passed     : message
		// Returns               : None
		// Purpose               :  to display flame type
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : Saturday, January 22, 2005
		// Revisions             : 
		//=====================================================================
		try {
			//---to display flame type
			gobjfrmStatus.FlameType = (int)Text;
			if (IsNumeric((int)Text) == true) {
				IgniteType = (int)Text;
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

	public void BgThread.Iclient.Failed(System.Exception e)
	{
		//---Temporarily ...
		//MessageBox.Show("Flame Status Thread Failed.", "Flame Status")
		//---Temporarily ...
	}

	public void BgThread.Iclient.Start(BgThread.clsBgThread clsBgThread)
	{
	}

	#End Region

	#Region " Global Functions"

	public bool AutoIgnition()
	{
		//=====================================================================
		// Procedure Name        : AutoIgnition
		// Parameters Passed     : Object, EventArgs
		// Returns               : None
		// Purpose               : 
		// Description           : to auto ignite the flame
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 18-Feb-2007 03:15 pm
		// Revisions             : 1
		//=====================================================================
		try {
			if (!gstructSettings.AppMode == EnumAppMode.DemoMode) {
				if (!IsNothing(mobjfrmAnalysis))
					mobjfrmAnalysis.tmrAspirationMsg.Enabled = false;
				mobjController.Cancel();
				gobjCommProtocol.mobjCommdll.subTime_Delay(100);
				Application.DoEvents();
				//---auto ignite the flame
				gobjClsAAS203.funcIgnite(true);

			} else {
				gobjMessageAdapter.ShowMessage(constFlameIgnited);
				Application.DoEvents();
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
			if (!gstructSettings.AppMode == EnumAppMode.DemoMode) {
				if (!IsNothing(mobjfrmAnalysis))
					mobjfrmAnalysis.tmrAspirationMsg.Enabled = true;
				//10.12.07
				if (gobjMain.mobjController.IsThreadRunning == false) {
					gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay);
					Application.DoEvents();
					mobjController.Start(gobjclsBgFlameStatus);
				}
				Application.DoEvents();
			}
			//---------------------------------------------------------
		}
	}

	public bool Extinguish()
	{
		//=====================================================================
		// Procedure Name        : btnExtinguish_Click
		// Parameters Passed     : Object, EventArgs
		// Returns               : None
		// Purpose               : 
		// Description           : To extinguish the flame
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 18-Feb-2007 03:15 pm
		// Revisions             : 1
		//=====================================================================
		try {
			if (!gstructSettings.AppMode == EnumAppMode.DemoMode) {
				if (!IsNothing(mobjfrmAnalysis))
					mobjfrmAnalysis.tmrAspirationMsg.Enabled = false;
				mobjController.Cancel();
				gobjCommProtocol.mobjCommdll.subTime_Delay(100);
				Application.DoEvents();
				//---To extinguish the flame
				gobjClsAAS203.funcIgnite(false);
			} else {
				gobjMessageAdapter.ShowMessage(constFlameExtinguished);
				Application.DoEvents();
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
			if (!gstructSettings.AppMode == EnumAppMode.DemoMode) {
				if (!IsNothing(mobjfrmAnalysis))
					mobjfrmAnalysis.tmrAspirationMsg.Enabled = true;
				//10.12.07
				if (gobjMain.mobjController.IsThreadRunning == false) {
					gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay);
					Application.DoEvents();
					mobjController.Start(gobjclsBgFlameStatus);
				}
				Application.DoEvents();
			}
			//---------------------------------------------------------
		}
	}

	public bool N2OAutoIgnition()
	{
		//=====================================================================
		// Procedure Name        : N2oAutoIgnition
		// Parameters Passed     : Object, EventArgs
		// Returns               : None
		// Purpose               : 
		// Description           : to switch over from aa flame to N2O flame
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 18-Aug-2007 03:15 pm
		// Revisions             : 1
		//=====================================================================
		try {
			if (!gstructSettings.AppMode == EnumAppMode.DemoMode) {
				if (!IsNothing(mobjfrmAnalysis))
					mobjfrmAnalysis.tmrAspirationMsg.Enabled = false;
				mobjController.Cancel();
				gobjCommProtocol.mobjCommdll.subTime_Delay(1000);
				Application.DoEvents();
				//---switch over to N2O flame
				gobjCommProtocol.funcSwitchOver();
			} else {
				gobjMessageAdapter.ShowMessage(constFlameIgnited);
				Application.DoEvents();
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
			if (!gstructSettings.AppMode == EnumAppMode.DemoMode) {
				if (!IsNothing(mobjfrmAnalysis))
					mobjfrmAnalysis.tmrAspirationMsg.Enabled = true;
				//10.12.07
				if (gobjMain.mobjController.IsThreadRunning == false) {
					gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay);
					Application.DoEvents();
					mobjController.Start(gobjclsBgFlameStatus);
				}
				Application.DoEvents();
			}
			//---------------------------------------------------------
		}
	}

	public bool funcAltDelete()
	{
		//=====================================================================
		// Procedure Name        : funcAltDelete
		// Parameters Passed     : Object, EventArgs
		// Returns               : None
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 18-Dec-2007 03:15 pm
		// Revisions             : 1
		//=====================================================================
		try {
			if (!gstructSettings.AppMode == EnumAppMode.DemoMode) {
				if (!IsNothing(mobjfrmAnalysis))
					mobjfrmAnalysis.tmrAspirationMsg.Enabled = false;
				mobjController.Cancel();
				gobjCommProtocol.mobjCommdll.subTime_Delay(1000);
				Application.DoEvents();
				//---switch over to N2O flame
				gobjClsAAS203.ReInitInstParameters();
			} else {
				//Call gobjMessageAdapter.ShowMessage("Alt - Delete", "Alt - Delete")
				Application.DoEvents();
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
			if (!gstructSettings.AppMode == EnumAppMode.DemoMode) {
				if (!IsNothing(mobjfrmAnalysis))
					mobjfrmAnalysis.tmrAspirationMsg.Enabled = true;
				//10.12.07
				if (gobjMain.mobjController.IsThreadRunning == false) {
					gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay);
					Application.DoEvents();
					mobjController.Start(gobjclsBgFlameStatus);
				}
				Application.DoEvents();
			}
			//---------------------------------------------------------
		}
	}

	public bool funcAltR()
	{
		//=====================================================================
		// Procedure Name        : funcAltR
		// Parameters Passed     : Object, EventArgs
		// Returns               : None
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 18-Dec-2007 03:15 pm
		// Revisions             : 1
		//=====================================================================
		try {
			if (!gstructSettings.AppMode == EnumAppMode.DemoMode) {
				if (!IsNothing(mobjfrmAnalysis))
					mobjfrmAnalysis.tmrAspirationMsg.Enabled = false;
				mobjController.Cancel();
				gobjCommProtocol.mobjCommdll.subTime_Delay(1000);
				Application.DoEvents();
				gobjClsAAS203.funcInstReset();
			} else {
				//Call gobjMessageAdapter.ShowMessage("Alt - R", "Alt - R")
				Application.DoEvents();
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
			if (!gstructSettings.AppMode == EnumAppMode.DemoMode) {
				if (!IsNothing(mobjfrmAnalysis))
					mobjfrmAnalysis.tmrAspirationMsg.Enabled = true;
				//10.12.07
				if (gobjMain.mobjController.IsThreadRunning == false) {
					gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay);
					Application.DoEvents();
					mobjController.Start(gobjclsBgFlameStatus);
				}
				Application.DoEvents();
			}
			//---------------------------------------------------------
		}
	}

	#End Region

	private void btnIgnite_Click(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : btnIgnite_Click
		// Parameters Passed     : Object, EventArgs
		// Returns               : None
		// Purpose               : 
		// Description           : to auto ignite the flame
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 18-Aug-2007 03:15 pm
		// Revisions             : 0
		//=====================================================================
		try {
			if (mblnAvoidProcessing == true) {
				return;
			}
			mblnAvoidProcessing = true;
			AutoIgnition();
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

	private void btnExtinguish_Click(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : btnExtinguish_Click
		// Parameters Passed     : Object, EventArgs
		// Returns               : None
		// Purpose               : 
		// Description           : to extinguish the flame
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 18-Aug-2007 03:15 pm
		// Revisions             : 0
		//=====================================================================
		try {
			if (mblnAvoidProcessing == true) {
				return;
			}
			mblnAvoidProcessing = true;
			Extinguish();
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

	private void btnN2OIgnite_Click(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : btnN2OIgnite_Click
		// Parameters Passed     : Object, EventArgs
		// Returns               : None
		// Purpose               : 
		// Description           : to N2O auto ignition
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 18-Aug-2007 03:15 pm
		// Revisions             : 0
		//=====================================================================
		try {
			if (mblnAvoidProcessing == true) {
				return;
			}
			mblnAvoidProcessing = true;
			N2OAutoIgnition();
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
			funcAltDelete();
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
			funcAltR();
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

	#Region " IQOQPQ Test Attachments"

	private void IQOQPQ_Attachment1_Test_Clicked(ref DataTable dtParameters, int intCounter)
	{
		//=====================================================================
		// Procedure Name        : IQOQPQ_Attachment1_Test_Clicked
		// Parameters Passed     : intCounter - To give the Serial No.
		// Returns               : dtParameters - Data table to return parameters
		// Purpose               : To perform the test for IQOQPQ Attachment 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 05.07.07
		// Revisions             : Deepak B.
		//=====================================================================
		DataRow objDrNewRow;
		//Dim objDataRow As DataRow
		int intCount = 0;
		DataTable mobjTmpDt = new DataTable();

		//Purpose : flag is added to check whether method is created sucessfully or not if at any 
		//part of method creation use cancel the process then no row is added in datagrid.
		bool blnIsMethodCreated = false;
		//22.1.2010 by dinesh wagh '


		try {
			//Test_IQOQPQ_Attachment1() 'commented by : dinesh wagh on 22.1.2010
			Test_IQOQPQ_Attachment1(blnIsMethodCreated);
			//code added by : dinesh wagh on 22.1.2010

			//only if condition added by  : dinesh wagh on 22.1.2010
			if (blnIsMethodCreated == true) {

				//----------------------------------------------
				//added by : dinesh wagh on 2.2.2010
				//------------------------------------
				//as analysis is completed , flame should be extinguish.
				gobjMessageAdapter.ShowMessage("Extinguishing flame.", "Note", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage);
				gobjClsAAS203.funcIgnite(false);
				//-------------------------------

				//Purpose : if new method is added then only create new row otherwise datagrid should be blank.
				objDrNewRow = dtParameters.NewRow();
				objDrNewRow("SampleID") = (int)intCounter;
				objDrNewRow("LampCurrent") = Format((double)gobjInst.Current, "0.0");
				objDrNewRow("PMTVoltage") = Format((double)gobjInst.PmtVoltage, "0.0");
				objDrNewRow("Wavelength") = Format((double)gobjInst.WavelengthCur, "0.0");
				objDrNewRow("SlitWidth") = Format((double)(80.0 - (double)gobjInst.SlitPosition) / 40, "0.0");
				objDrNewRow("BurnerHeight") = Format(gobjInst.BhStep / (200.0 * BHRATIO), "0.0");
				objDrNewRow("Fuel") = Format((double)gobjClsAAS203.funcRead_Fuel, "0.00");
				objDrNewRow("Absorbance") = Format((double)gDblAbsValue_IQOQPQ_Attachment1, "0.000");
				objDrNewRow("Remark") = "OK";
				objDrNewRow("Date") = Format((System.DateTime)System.DateTime.Today, "d-MMMM-yy");
				//objDrNewRow("TestID") = CInt(intCounter)
				dtParameters.Rows.Add(objDrNewRow);
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
			//objWait.Dispose()
			//---------------------------------------------------------
		}

	}

	private void IQOQPQ_AttachmentII_Test_Clicked(ref DataTable dtParameters, int intCounter)
	{
		//=====================================================================
		// Procedure Name        : IQOQPQ_Attachment1_Test_Clicked
		// Parameters Passed     : intCounter - To give the Serial No.
		// Returns               : dtParameters - Data table to return parameters
		// Purpose               : To perform the test for IQOQPQ Attachment 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 05.07.07
		// Revisions             : Deepak B.
		//=====================================================================
		DataRow objDrNewRow;
		//Dim objDataRow As DataRow
		int intCount = 0;
		DataTable mobjTmpDt = new DataTable();
		double dblStdAbs;
		double dblStdAbs1;
		try {
			gobjMessageAdapter.ShowMessage("Please Note: Enter the concentration value in the Standard Concentration form that you are going" + " to use while performing the test.", "Test 2", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage);
			Application.DoEvents();

			//MsgBox("Please Note: Enter the concentration value in the Standard Concentration form that you are going" _
			//& " to use while performing the test.", MsgBoxStyle.Information, "Reminder")

			Test_IQOQPQ_AttachmentII(EnumIQOQPQtestId.ePQ2);

			//code added by ; dinesh wagh on 2.2.2010
			//-----------------------------------
			if (gobjNewMethod == null) {
				return;
			}
			//---------------------------------------


			if (gobjNewMethod.QuantitativeDataCollection.Count > 0) {
				//added by : dinesh wagh on 2.2.2010
				//------------------------------------
				//as analysis is completed , flame should be extinguish.
				gobjMessageAdapter.ShowMessage("Extinguishing flame.", "Note", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage);
				gobjClsAAS203.funcIgnite(false);
				//-------------------------------

				dblStdAbs = gobjNewMethod.QuantitativeDataCollection(0).StandardDataCollection(0).Abs;

				for (intCount = 0; intCount <= gobjNewMethod.QuantitativeDataCollection(0).SampleDataCollection.Count - 1; intCount++) {
					objDrNewRow = dtParameters.NewRow();

					//objDrNewRow("SampleID") = CInt(intCount + 1) 'by dinesh wagh on 27.1.2010 'causes error log.
					objDrNewRow("Repeat No") = (int)intCount + 1;
					//by dinesh wagh on 27.1.2010

					if (gobjNewMethod.QuantitativeDataCollection(0).SampleDataCollection.item(intCount).Abs == -1.0) {
						objDrNewRow("Absorbance") = "";
						objDrNewRow("Deviation") = "";
					} else {
						objDrNewRow("Absorbance") = Format(gobjNewMethod.QuantitativeDataCollection(0).SampleDataCollection.item(intCount).Abs, "0.000");
						objDrNewRow("Deviation") = Format(dblStdAbs - gobjNewMethod.QuantitativeDataCollection(0).SampleDataCollection.item(intCount).Abs, "0.000");
					}
					dtParameters.Rows.Add(objDrNewRow);
				}


				//code added by ; dinesh wagh on 28.1.2010
				//purpose : to display edit data screen.
				//----------------------------------------------
				frmDeleteStdNSam objfrmDeleteStdNSam;
				frmViewRepeatResults objfrmViewRepeatResults;

				if (((gobjNewMethod.QuantitativeDataCollection.Item(0).AnalysisParameters.NumOfSampleRepeats > 1 | gobjNewMethod.QuantitativeDataCollection.Item(0).AnalysisParameters.NumOfStdRepeats > 1) & clsStandardGraph.FindSamplesAnalysed(gobjNewMethod, 0) >= 1)) {
					objfrmViewRepeatResults = new frmViewRepeatResults(gobjNewMethod, 0);
					objfrmViewRepeatResults.ShowDialog();
					Application.DoEvents();
					objfrmViewRepeatResults.Close();
					objfrmViewRepeatResults.Dispose();
					objfrmViewRepeatResults = null;
				} else {
					objfrmDeleteStdNSam = new frmDeleteStdNSam(gobjNewMethod, 0);
					if (objfrmDeleteStdNSam.ShowDialog() == DialogResult.OK) {
						gobjclsStandardGraph = new clsStandardGraph();
						gobjclsStandardGraph.Create_Standard_Sample_Curve(true, false, gobjNewMethod.MethodID, gobjNewMethod.QuantitativeDataCollection.Count - 1, gobjNewMethod);
					}
					Application.DoEvents();
					objfrmDeleteStdNSam.Close();
					objfrmDeleteStdNSam.Dispose();
					objfrmDeleteStdNSam = null;
				}
				//----------------------------------------------

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
			//objWait.Dispose()
			//---------------------------------------------------------
		}

	}

	private void IQOQPQ_AttachmentIII_Test_Clicked(ref DataTable dtParameters, int intCounter)
	{
		//=====================================================================
		// Procedure Name        : IQOQPQ_Attachment1_Test_Clicked
		// Parameters Passed     : intCounter - To give the Serial No.
		// Returns               : dtParameters - Data table to return parameters
		// Purpose               : To perform the test for IQOQPQ Attachment 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 05.07.07
		// Revisions             : Deepak B.
		//=====================================================================
		DataRow objDrNewRow;
		int intCount = 0;
		DataTable mobjTmpDt = new DataTable();
		double dblStdAbs;
		double dblStdAbs1;

		try {
			//code commented by : dinesh wagh on 21.1.2010
			//----------------------------------------------------
			//'gobjMessageAdapter.ShowMessage("Please Note: Enter the concentration value in the Standard Concentration form that you are going" _
			//'& " to use while performing the test.", "Test 3", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage)
			//-----------------------------------------------------

			Application.DoEvents();

			Test_IQOQPQ_AttachmentII(EnumIQOQPQtestId.ePQ3);
			//5.4.2010



			if (gobjNewMethod.QuantitativeDataCollection.Count > 0) {
				//added by : dinesh wagh on 2.2.2010
				//------------------------------------
				//as analysis is completed , flame should be extinguish.
				gobjMessageAdapter.ShowMessage("Extinguishing flame.", "Note", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage);
				gobjClsAAS203.funcIgnite(false);
				//-------------------------------

				for (intCount = 0; intCount <= gobjNewMethod.QuantitativeDataCollection(0).StandardDataCollection.Count - 1; intCount++) {
					objDrNewRow = dtParameters.NewRow();
					//objDrNewRow("SampleID") = CInt(intCount + 1) 'code commented by : dinesh wagh on 22.1.2010
					//code added by : dinesh wagh on 22.1.2010
					//------------------------------
					objDrNewRow("Standard No") = (int)intCount + 1;
					//-----------------------------------
					objDrNewRow("Absorbance") = Format(gobjNewMethod.QuantitativeDataCollection(0).StandardDataCollection.item(intCount).Abs, "0.000");
					objDrNewRow("Concentration") = Format(gobjNewMethod.QuantitativeDataCollection(0).StandardDataCollection.item(intCount).Concentration, "0.00");
					dtParameters.Rows.Add(objDrNewRow);
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
			//objWait.Dispose()
			//---------------------------------------------------------
		}

	}
	private void Test_IQOQPQ_Attachment1(ref bool blnIsMethodCreated)
	{
		//parameter added by ; dinesh wgah on 22.1.2010 
		//Purpose to check wheter user accept all parameter and method is sucessfully created or not.

		//=====================================================================
		// Procedure Name        : Test_IQOQPQ_Attachment1
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : To create new method to perform test in IQOQPQ Attachment1
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh Singh
		// Created               : 04.07.07
		// Revisions             : 
		//=====================================================================
		frmNewMethod objfrmNewMethod = new frmNewMethod();
		frmInstrumentParameters objfrmInstrParameters;
		frmMethodAnalysisParameters objfrmAnalysisParameters;
		frmStandardConcentration objfrmStdParameters;
		frmSampleParameters objfrmSampleParameters;
		frmReportOptions objfrmReportOptions;
		frmUVQuantitativeAnalysis objfrmUVQuantitativeAnalysis;
		frmEmissionMode objfrmEmissionMode;
		CWaitCursor objWait = new CWaitCursor();

		try {
			objfrmNewMethod.cmbOperationMode.Enabled = false;

			if (objfrmNewMethod.ShowDialog() == DialogResult.OK) {
				OpenMethodMode = modGlobalConstants.EnumMethodMode.NewMode;


				if (!gobjNewMethod == null) {
					//---Enum Values Changed and Added by Mangesh on 23-Jan-2007
					switch (gobjNewMethod.OperationMode) {
						case EnumOperationMode.MODE_AA:
						case EnumOperationMode.MODE_AABGC:
							//1, 3
							objfrmInstrParameters = new frmInstrumentParameters(OpenMethodMode);
							Application.DoEvents();
							if (objfrmInstrParameters.ShowDialog() == DialogResult.OK) {
							//---do nothing & move forward to create new method
							} else {
								gobjNewMethod.Status = false;
								//Added By Pankaj Thu 24 May 07
								return;

							}
						case EnumOperationMode.MODE_UVABS:
							//2
							objfrmUVQuantitativeAnalysis = new frmUVQuantitativeAnalysis(OpenMethodMode);
							Application.DoEvents();
							if (objfrmUVQuantitativeAnalysis.ShowDialog() == DialogResult.OK) {
							//---do nothing & move forward to create new method
							} else {
								gobjNewMethod.Status = false;
								//Added By Pankaj Thu 24 May 07
								return;

							}
						case EnumOperationMode.MODE_EMMISSION:
							//4
							objfrmEmissionMode = new frmEmissionMode(OpenMethodMode);
							Application.DoEvents();
							if (objfrmEmissionMode.ShowDialog() == DialogResult.OK) {
							//---do nothing & move forward to create new method
							} else {
								//Added By Pankaj Thu 24 May 07
								gobjNewMethod.Status = false;
								//-----
								return;

							}
					}

					objfrmAnalysisParameters = new frmMethodAnalysisParameters(OpenMethodMode);
					Application.DoEvents();

					if (objfrmAnalysisParameters.ShowDialog() == DialogResult.OK) {
						//objfrmStdParameters = New frmStandardConcentration 'commented by ; dinesh wagh on 2.2.2010
						objfrmStdParameters = new frmStandardConcentration(EnumIQOQPQtestId.ePQAtt1);
						//added by ; dinesh wagh on 2.2.2010



						Application.DoEvents();

						if (objfrmStdParameters.ShowDialog() == DialogResult.OK) {
							gobjNewMethod.Status = true;
							//Added By Pankaj 23 May 07 
							objfrmSampleParameters = new frmSampleParameters(EnumMethodMode.NewMode);
							Application.DoEvents();

							if (objfrmSampleParameters.ShowDialog() == DialogResult.OK) {
								objfrmReportOptions = new frmReportOptions(EnumMethodMode.NewMode, false, 0, 0);
								Application.DoEvents();

								if (objfrmReportOptions.ShowDialog() == DialogResult.OK) {
									//----Commented by Mangesh on 04-Apr-2007

									//'---add new method to method collection


									//---For Double Beam Added by Mangesh on 06-Apr-2007

									if (gintInstrumentBeamType == enumInstrumentBeamType.DoubleBeam) {
										gobjNewMethod.InstrumentBeamType = enumInstrumentBeamType.DoubleBeam;
									} else if (gintInstrumentBeamType == enumInstrumentBeamType.SingleBeam) {
										gobjNewMethod.InstrumentBeamType = enumInstrumentBeamType.SingleBeam;
									}

									//------Added By Pankaj Thu 28 May 07
									gobjchkActiveMethod.NewMethod = false;
									gobjchkActiveMethod.CancelMethod = false;
									//gobjchkActiveMethod.fillInstruments = False  '27.07.07
									//gobjchkActiveMethod.fillParameters = False  '27.07.07
									gobjchkActiveMethod.fillStdConcentration = false;
									gobjMethodCollection.Add(gobjNewMethod);

									//'---serialize method collection 
									funcSaveAllMethods(gobjMethodCollection);



									//----Added by Mangesh on 04-Apr-2007

									OpenMethodMode = modGlobalConstants.EnumMethodMode.EditMode;


									//---display confirmation dialog box of method creation
									gobjMessageAdapter.ShowMessage(contMethodCreatedSuccessfully);
									blnIsMethodCreated = true;
									//code added by ;dinesh wagh on 22.1.2010

									Application.DoEvents();
									gIntMethodID = gobjNewMethod.MethodID;


									//---START --- Added by Mangesh on 27-Feb-2007

									OnQuantAnalyse_IQOQPQ_Test_Attachment1();

								//---END  ---  Added by Mangesh on 27-Feb-2007

								} else {
								}
							} else {
							}
						} else {
							gobjNewMethod.Status = false;
						}
					} else {
						gobjNewMethod.Status = false;
					}
				} else {
					gobjNewMethod.Status = false;
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
			//tlbbtnNewMethod.ResumeEvents()
			gobjfrmStatus.TopMost = true;
			//---------------------------------------------------------
		}

	}


	private void Test_IQOQPQ_Attachment1()
	{
		//=====================================================================
		// Procedure Name        : Test_IQOQPQ_Attachment1
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : To create new method to perform test in IQOQPQ Attachment1
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh Singh
		// Created               : 04.07.07
		// Revisions             : 
		//=====================================================================
		frmNewMethod objfrmNewMethod = new frmNewMethod();
		frmInstrumentParameters objfrmInstrParameters;
		frmMethodAnalysisParameters objfrmAnalysisParameters;
		frmStandardConcentration objfrmStdParameters;
		frmSampleParameters objfrmSampleParameters;
		frmReportOptions objfrmReportOptions;
		frmUVQuantitativeAnalysis objfrmUVQuantitativeAnalysis;
		frmEmissionMode objfrmEmissionMode;
		CWaitCursor objWait = new CWaitCursor();

		try {
			objfrmNewMethod.cmbOperationMode.Enabled = false;

			if (objfrmNewMethod.ShowDialog() == DialogResult.OK) {
				OpenMethodMode = modGlobalConstants.EnumMethodMode.NewMode;


				if (!gobjNewMethod == null) {
					//---Enum Values Changed and Added by Mangesh on 23-Jan-2007
					switch (gobjNewMethod.OperationMode) {
						case EnumOperationMode.MODE_AA:
						case EnumOperationMode.MODE_AABGC:
							//1, 3
							objfrmInstrParameters = new frmInstrumentParameters(OpenMethodMode);
							Application.DoEvents();
							if (objfrmInstrParameters.ShowDialog() == DialogResult.OK) {
							//---do nothing & move forward to create new method
							} else {
								gobjNewMethod.Status = false;
								//Added By Pankaj Thu 24 May 07

								return;


							}
						case EnumOperationMode.MODE_UVABS:
							//2
							objfrmUVQuantitativeAnalysis = new frmUVQuantitativeAnalysis(OpenMethodMode);
							Application.DoEvents();
							if (objfrmUVQuantitativeAnalysis.ShowDialog() == DialogResult.OK) {
							//---do nothing & move forward to create new method
							} else {
								gobjNewMethod.Status = false;
								//Added By Pankaj Thu 24 May 07
								return;

							}
						case EnumOperationMode.MODE_EMMISSION:
							//4
							objfrmEmissionMode = new frmEmissionMode(OpenMethodMode);
							Application.DoEvents();
							if (objfrmEmissionMode.ShowDialog() == DialogResult.OK) {
							//---do nothing & move forward to create new method
							} else {
								//Added By Pankaj Thu 24 May 07
								gobjNewMethod.Status = false;
								//-----
								return;

							}
					}

					objfrmAnalysisParameters = new frmMethodAnalysisParameters(OpenMethodMode);
					Application.DoEvents();

					if (objfrmAnalysisParameters.ShowDialog() == DialogResult.OK) {
						objfrmStdParameters = new frmStandardConcentration();
						Application.DoEvents();
						if (objfrmStdParameters.ShowDialog() == DialogResult.OK) {
							gobjNewMethod.Status = true;
							//Added By Pankaj 23 May 07 
							objfrmSampleParameters = new frmSampleParameters(EnumMethodMode.NewMode);
							Application.DoEvents();

							if (objfrmSampleParameters.ShowDialog() == DialogResult.OK) {
								objfrmReportOptions = new frmReportOptions(EnumMethodMode.NewMode, false, 0, 0);
								Application.DoEvents();

								if (objfrmReportOptions.ShowDialog() == DialogResult.OK) {

									//----Commented by Mangesh on 04-Apr-2007

									//'---add new method to method collection


									//---For Double Beam Added by Mangesh on 06-Apr-2007

									if (gintInstrumentBeamType == enumInstrumentBeamType.DoubleBeam) {
										gobjNewMethod.InstrumentBeamType = enumInstrumentBeamType.DoubleBeam;
									} else if (gintInstrumentBeamType == enumInstrumentBeamType.SingleBeam) {
										gobjNewMethod.InstrumentBeamType = enumInstrumentBeamType.SingleBeam;
									}

									//------Added By Pankaj Thu 28 May 07
									gobjchkActiveMethod.NewMethod = false;
									gobjchkActiveMethod.CancelMethod = false;
									//gobjchkActiveMethod.fillInstruments = False  '27.07.07
									//gobjchkActiveMethod.fillParameters = False  '27.07.07
									gobjchkActiveMethod.fillStdConcentration = false;
									gobjMethodCollection.Add(gobjNewMethod);

									//'---serialize method collection 
									funcSaveAllMethods(gobjMethodCollection);



									//----Added by Mangesh on 04-Apr-2007

									OpenMethodMode = modGlobalConstants.EnumMethodMode.EditMode;


									//---display confirmation dialog box of method creation
									gobjMessageAdapter.ShowMessage(contMethodCreatedSuccessfully);
									Application.DoEvents();
									gIntMethodID = gobjNewMethod.MethodID;


									//---START --- Added by Mangesh on 27-Feb-2007

									OnQuantAnalyse_IQOQPQ_Test_Attachment1();

								//---END  ---  Added by Mangesh on 27-Feb-2007


								} else {
								}

							} else {
							}
						} else {
							gobjNewMethod.Status = false;
						}
					} else {
						gobjNewMethod.Status = false;

					}
				} else {
					gobjNewMethod.Status = false;

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
			//tlbbtnNewMethod.ResumeEvents()
			gobjfrmStatus.TopMost = true;
			//---------------------------------------------------------
		}

	}

	public void OnQuantAnalyse_IQOQPQ_Test_Attachment1()
	{
		//=====================================================================
		// Procedure Name        : OnQuantAnalyse_IQOQPQ_Test_Attachment1
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 13-Feb-2007 12:15 pm
		// Revisions             : 1
		//=====================================================================
		int mvalid;
		int msgcount;
		Message msg;

		try {
			mvalid = CheckMethod_IQOQPQ_Test_Attachment1();
			if ((mvalid == 0)) {
				return;
			}
			if ((mvalid == 2)) {
				if (IsNothing(mobjfrmAnalysis)) {
					Application.DoEvents();
					mobjfrmAnalysis = new frmAnalysis();
				} else {
				}
				if (gstructSettings.AppMode == EnumAppMode.DemoMode) {
				//---Don't perform Peak Latching operation for Demo Method
				} else {
					//---Search and Find Analytical Peak
					mobjfrmAnalysis.CheckInstrumentOptimisation();
				}
			} else if ((mvalid == 1)) {
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

	public int CheckMethod_IQOQPQ_Test_Attachment1()
	{
		//=====================================================================
		// Procedure Name        : CheckMethod_IQOQPQ_Test_Attachment1
		// Parameters Passed     : None
		// Returns               : Status Value as Integer 
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 17-Jan-2007 03:25 pm
		// Revisions             : 1
		//=====================================================================
		try {

			if ((gobjNewMethod.MethodID >= 0)) {
				if (clsStandardGraph.GetTotStds(gobjNewMethod.StandardDataCollection, false) > 0) {
					return 2;
				}

			}

			if ((gobjNewMethod.MethodID > 0)) {
				return 1;
			}

			return 3;

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

	private void Test_IQOQPQ_AttachmentII(int intAttachmentNo)
	{
		//=====================================================================
		// Procedure Name        : Test_IQOQPQ_AttachmentII
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : To create new method to perform test in IQOQPQ Attachment1
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh Singh
		// Created               : 04.07.07
		// Revisions             : 
		//=====================================================================
		frmNewMethod objfrmNewMethod = new frmNewMethod();
		frmInstrumentParameters objfrmInstrParameters;
		frmMethodAnalysisParameters objfrmAnalysisParameters;
		frmStandardConcentration objfrmStdParameters;
		frmSampleParameters objfrmSampleParameters;
		frmReportOptions objfrmReportOptions;
		frmUVQuantitativeAnalysis objfrmUVQuantitativeAnalysis;
		frmEmissionMode objfrmEmissionMode;
		CWaitCursor objWait = new CWaitCursor();

		try {
			objfrmNewMethod.cmbOperationMode.Enabled = false;

			if (objfrmNewMethod.ShowDialog() == DialogResult.OK) {
				OpenMethodMode = modGlobalConstants.EnumMethodMode.NewMode;


				if (!gobjNewMethod == null) {
					//---Enum Values Changed and Added by Mangesh on 23-Jan-2007
					switch (gobjNewMethod.OperationMode) {
						case EnumOperationMode.MODE_AA:
						case EnumOperationMode.MODE_AABGC:
							//1, 3
							objfrmInstrParameters = new frmInstrumentParameters(OpenMethodMode);
							Application.DoEvents();
							if (objfrmInstrParameters.ShowDialog() == DialogResult.OK) {
							//---do nothing & move forward to create new method
							} else {
								gobjNewMethod.Status = false;
								//Added By Pankaj Thu 24 May 07

								return;


							}
						//Case EnumOperationMode.MODE_UVABS   '2
						//    objfrmUVQuantitativeAnalysis = New frmUVQuantitativeAnalysis(OpenMethodMode)
						//    Application.DoEvents()
						//    If objfrmUVQuantitativeAnalysis.ShowDialog() = DialogResult.OK Then
						//        '---do nothing & move forward to create new method
						//    Else
						//        gobjNewMethod.Status = False 'Added By Pankaj Thu 24 May 07
						//        Exit Sub
						//    End If

						//Case EnumOperationMode.MODE_EMMISSION   '4
						//    objfrmEmissionMode = New frmEmissionMode(OpenMethodMode)
						//    Application.DoEvents()
						//    If objfrmEmissionMode.ShowDialog() = DialogResult.OK Then
						//        '---do nothing & move forward to create new method
						//    Else
						//        'Added By Pankaj Thu 24 May 07
						//        gobjNewMethod.Status = False
						//        '-----
						//        Exit Sub
						//    End If

					}

					//--------5.4.2010 by dinesh wagh
					int intNumOfSamples;
					switch (intAttachmentNo) {
						case EnumIQOQPQtestId.ePQ2:
							intNumOfSamples = 1;
						case EnumIQOQPQtestId.ePQ3:
							intNumOfSamples = 15;
						default:
							intNumOfSamples = 15;
					}
					//-------------

					//objfrmAnalysisParameters = New frmMethodAnalysisParameters(OpenMethodMode) 'commented by : dinesh wagh on 2.2.2010
					objfrmAnalysisParameters = new frmMethodAnalysisParameters(OpenMethodMode, intNumOfSamples);
					//added by ; dinesh wagh on 2.2.2010 ' as below we set no of sample as 15 samples.

					Application.DoEvents();

					objfrmAnalysisParameters.nudNumofSamples.Maximum = 15;
					objfrmAnalysisParameters.nudNumofSamples.Minimum = 1;
					objfrmAnalysisParameters.Label1.Text = "1..15";

					//---------5.4.2010 by dinesh wagh
					switch (intAttachmentNo) {
						case EnumIQOQPQtestId.ePQ2:
							objfrmAnalysisParameters.nudNumSampRepeat.Value = 10;
						case EnumIQOQPQtestId.ePQ3:
							objfrmAnalysisParameters.nudNumSampRepeat.Value = 1;
						default:
							objfrmAnalysisParameters.nudNumSampRepeat.Value = 10;
					}
					//-------------------




					if (objfrmAnalysisParameters.ShowDialog() == DialogResult.OK) {
						objfrmStdParameters = new frmStandardConcentration();
						Application.DoEvents();
						if (objfrmStdParameters.ShowDialog() == DialogResult.OK) {
							gobjNewMethod.Status = true;
							//Added By Pankaj 23 May 07 
							objfrmSampleParameters = new frmSampleParameters(EnumMethodMode.NewMode);
							Application.DoEvents();

							if (objfrmSampleParameters.ShowDialog() == DialogResult.OK) {
								objfrmReportOptions = new frmReportOptions(EnumMethodMode.NewMode, false, 0, 0);
								Application.DoEvents();

								if (objfrmReportOptions.ShowDialog() == DialogResult.OK) {

									//----Commented by Mangesh on 04-Apr-2007

									//'---add new method to method collection


									//---For Double Beam Added by Mangesh on 06-Apr-2007

									if (gintInstrumentBeamType == enumInstrumentBeamType.DoubleBeam) {
										gobjNewMethod.InstrumentBeamType = enumInstrumentBeamType.DoubleBeam;
									} else if (gintInstrumentBeamType == enumInstrumentBeamType.SingleBeam) {
										gobjNewMethod.InstrumentBeamType = enumInstrumentBeamType.SingleBeam;
									}

									//------Added By Pankaj Thu 28 May 07
									gobjchkActiveMethod.NewMethod = false;
									gobjchkActiveMethod.CancelMethod = false;
									//gobjchkActiveMethod.fillInstruments = False  '27.07.07
									//gobjchkActiveMethod.fillParameters = False   '27.07.07
									gobjchkActiveMethod.fillStdConcentration = false;
									gobjMethodCollection.Add(gobjNewMethod);

									//'---serialize method collection 
									funcSaveAllMethods(gobjMethodCollection);



									//----Added by Mangesh on 04-Apr-2007

									OpenMethodMode = modGlobalConstants.EnumMethodMode.EditMode;


									//---display confirmation dialog box of method creation
									gobjMessageAdapter.ShowMessage(contMethodCreatedSuccessfully);
									Application.DoEvents();
									gIntMethodID = gobjNewMethod.MethodID;


									//---START --- Added by Mangesh on 27-Feb-2007

									OnQuantAnalyse_IQOQPQ_Test_AttachmentII();

								//---END  ---  Added by Mangesh on 27-Feb-2007


								} else {
								}

							} else {
							}
						} else {
							gobjNewMethod.Status = false;
						}
					} else {
						gobjNewMethod.Status = false;

					}
				} else {
					gobjNewMethod.Status = false;

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
			//tlbbtnNewMethod.ResumeEvents()
			gobjfrmStatus.TopMost = true;
			//---------------------------------------------------------
		}

	}

	public void OnQuantAnalyse_IQOQPQ_Test_AttachmentII()
	{
		//=====================================================================
		// Procedure Name        : OnQuantAnalyse_IQOQPQ_Test_AttachmentII
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh Singh
		// Created               : 12-July-2007 12:15 pm
		// Revisions             : 1
		//=====================================================================
		int mvalid;
		int msgcount;
		Message msg;
		frmTest_Analysis objfrmAnalysis = new frmTest_Analysis();


		try {
			mvalid = CheckMethod();

			if ((mvalid == 0)) {
				return;
			}


			if ((mvalid == 2)) {
				objfrmAnalysis.StartNewAnalysis();
				objfrmAnalysis.CheckAnaButtons();

				if (gstructSettings.AppMode == EnumAppMode.DemoMode) {
				//---Don't perform Peak Latching operation for Demo Method
				} else {
					//---Search and Find Analytical Peak
					objfrmAnalysis.CheckInstrumentOptimisation();
				}



			} else if ((mvalid == 1)) {
				gobjMessageAdapter.ShowMessage("No Standard Information available", "Analysis", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage);
				Application.DoEvents();
			}

			//Saurabh 10.07.07 To bring status form in front
			gobjfrmStatus.Show();
			//Saurabh
			if (objfrmAnalysis.ShowDialog) {
				//To bring the Analysis form infront
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

	private void IQOQPQ_InstrumentType(ref string strInstrumentType)
	{
		//=====================================================================
		// Procedure Name        : IQOQPQ_InstrumentType
		// Parameters Passed     :  
		// Returns               : None
		// Purpose               : get instrument type
		// Description           :  
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 18-Aug-2007 03:15 pm
		// Revisions             : 0
		//=====================================================================
		strInstrumentType = gstrTitleInstrumentType;
	}

	#End Region

	private void  // ERROR: Handles clauses are not supported in C#
MenuBar_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
	{
		//=====================================================================
		// Procedure Name        : MenuBar_KeyUp
		// Parameters Passed     : Object, EventArgs
		// Returns               : None
		// Purpose               : 
		// Description           : to activate shortcut keys
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 18-Aug-2007 03:15 pm
		// Revisions             : 0
		//=====================================================================
		if (mblnAvoidProcessing == true) {
			return;
		}
		try {
			if (e.Alt == true) {
				mblnAvoidProcessing = true;
				switch (e.KeyCode) {
					case Keys.I:
						AutoIgnition();
					case Keys.C:
						N2OAutoIgnition();
					case Keys.E:
						Extinguish();
					case Keys.D:
						funcAltDelete();
					case Keys.R:

						funcAltR();

					case Keys.Q:
				}
				mblnAvoidProcessing = true;
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
mnuCheckSamplerFunctions_Click(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : mnuCheckSamplerFunctions_Click
		// Parameters Passed     : message
		// Returns               : None
		// Purpose               : to open autosampler interface
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : 05.09.07
		// Revisions             : 
		//=====================================================================
		try {
			//If gblnTestAutoSampler = True Then'Comment by pankaj for autosampler on 10 Sep 07
			if (gstructAutoSampler.blnAutoSamplerInitialised == true) {
				AutoSamplerInterface objFrmAutoSamplerInterface = new AutoSamplerInterface();
				Application.DoEvents();
				objFrmAutoSamplerInterface.ShowDialog();
				Application.DoEvents();
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
mnuAbout_Click(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : mnuAbout_Click
		// Parameters Passed     : message
		// Returns               : None
		// Purpose               : to open help about window
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : 27.09.08
		// Revisions             : 
		//=====================================================================
		try {
			frmHelpAbout objFrmAbout = new frmHelpAbout();
			if (gstructSettings.AppMode == EnumAppMode.FullVersion_203D | gstructSettings.AppMode == EnumAppMode.DemoMode_203D) {
				objFrmAbout.aasDB_picture.BringToFront();
			} else {
				objFrmAbout.AAS_picture.BringToFront();
			}
			objFrmAbout.Text = objFrmAbout.Text + Space(1) + this.Text;
			objFrmAbout.ShowDialog();
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

}
