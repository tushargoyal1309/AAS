using System.Threading;
using AAS203.Common;
using AAS203Library.Method;

public class frmServiceRoutines : System.Windows.Forms.Form
{

	#Region " Windows Form Designer generated code "

	public frmServiceRoutines()
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
	internal GradientPanel.CustomPanel CustomPanel1;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuOptimise;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuPneumatics;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuEmsPeakSearch;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuAnaPeakSearch;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuInstrumentSetup;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuEmissionSetup;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuAbsScan;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuManualIgnition;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuAutoIgnition;
	internal NETXP.Controls.Bars.StatusBar StatusBar1;
	internal System.Windows.Forms.StatusBarPanel StatusBarPanelInfo;
	internal NETXP.Controls.Bars.ProgressPanel ProgressPanel;
	internal System.Windows.Forms.StatusBarPanel StatusBarPanelDate;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuOptimizeTurretAll;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuOptimizeTurret1;
	internal NETXP.Controls.Bars.CommandBar mnuBarServiceRoutines;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuTurret1;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuAnalog1;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuMonochromator1;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuPrinterType1;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuExit1;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuTurret;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuAnalog;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuMonochromator;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuPrinterType;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuExit;
	internal NETXP.Controls.XPButton btnExtinguish;
	internal NETXP.Controls.XPButton btnIgnite;
	internal GradientPanel.CustomPanel CustomPanel2;
	internal NETXP.Controls.XPButton btnN2OIgnite;
	internal NETXP.Controls.XPButton btnDelete;
	internal NETXP.Controls.XPButton btnR;
	[System.Diagnostics.DebuggerStepThrough()]
	private void InitializeComponent()
	{
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmServiceRoutines));
		this.mnuBarServiceRoutines = new NETXP.Controls.Bars.CommandBar();
		this.mnuTurret1 = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuTurret = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuAnalog1 = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuAnalog = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuMonochromator1 = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuMonochromator = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuOptimise = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuOptimizeTurretAll = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuOptimizeTurret1 = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuEmsPeakSearch = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuAnaPeakSearch = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuInstrumentSetup = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuEmissionSetup = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuAbsScan = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuPneumatics = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuManualIgnition = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuAutoIgnition = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuPrinterType1 = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuPrinterType = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuExit1 = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuExit = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.CustomPanel1 = new GradientPanel.CustomPanel();
		this.CustomPanel2 = new GradientPanel.CustomPanel();
		this.btnExtinguish = new NETXP.Controls.XPButton();
		this.btnIgnite = new NETXP.Controls.XPButton();
		this.btnN2OIgnite = new NETXP.Controls.XPButton();
		this.btnR = new NETXP.Controls.XPButton();
		this.btnDelete = new NETXP.Controls.XPButton();
		this.StatusBar1 = new NETXP.Controls.Bars.StatusBar();
		this.StatusBarPanelInfo = new System.Windows.Forms.StatusBarPanel();
		this.ProgressPanel = new NETXP.Controls.Bars.ProgressPanel();
		this.StatusBarPanelDate = new System.Windows.Forms.StatusBarPanel();
		((System.ComponentModel.ISupportInitialize)this.mnuBarServiceRoutines).BeginInit();
		this.CustomPanel1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.StatusBarPanelInfo).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.ProgressPanel).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.StatusBarPanelDate).BeginInit();
		this.SuspendLayout();
		//
		//mnuBarServiceRoutines
		//
		this.mnuBarServiceRoutines.BackColor = System.Drawing.Color.Transparent;
		this.mnuBarServiceRoutines.CustomBackground = true;
		this.mnuBarServiceRoutines.CustomizeText = "&Customize Toolbar...";
		this.mnuBarServiceRoutines.Dock = System.Windows.Forms.DockStyle.Top;
		this.mnuBarServiceRoutines.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.mnuBarServiceRoutines.FullRow = true;
		this.mnuBarServiceRoutines.ID = 3987;
		this.mnuBarServiceRoutines.Items.AddRange(new NETXP.Controls.Bars.CommandBarItem[] {
			this.mnuTurret1,
			this.mnuAnalog1,
			this.mnuMonochromator1,
			this.mnuOptimise,
			this.mnuPneumatics,
			this.mnuPrinterType1,
			this.mnuExit1
		});
		this.mnuBarServiceRoutines.Location = new System.Drawing.Point(0, 0);
		this.mnuBarServiceRoutines.Margins.Bottom = 1;
		this.mnuBarServiceRoutines.Margins.Left = 1;
		this.mnuBarServiceRoutines.Margins.Right = 1;
		this.mnuBarServiceRoutines.Margins.Top = 1;
		this.mnuBarServiceRoutines.Name = "mnuBarServiceRoutines";
		this.mnuBarServiceRoutines.Size = new System.Drawing.Size(658, 23);
		this.mnuBarServiceRoutines.Style = NETXP.Controls.Bars.CommandBarStyle.Menu;
		this.mnuBarServiceRoutines.TabIndex = 1;
		this.mnuBarServiceRoutines.TabStop = false;
		this.mnuBarServiceRoutines.Text = "";
		//
		//mnuTurret1
		//
		this.mnuTurret1.Items.AddRange(new NETXP.Controls.Bars.CommandBarItem[] { this.mnuTurret });
		this.mnuTurret1.PadHorizontal = 5;
		this.mnuTurret1.Text = "&Turret";
		//
		//mnuTurret
		//
		this.mnuTurret.Image = (System.Drawing.Image)resources.GetObject("mnuTurret.Image");
		this.mnuTurret.Text = "&Turret";
		//
		//mnuAnalog1
		//
		this.mnuAnalog1.Items.AddRange(new NETXP.Controls.Bars.CommandBarItem[] { this.mnuAnalog });
		this.mnuAnalog1.PadHorizontal = 5;
		this.mnuAnalog1.Text = "&Analog";
		//
		//mnuAnalog
		//
		this.mnuAnalog.Image = (System.Drawing.Image)resources.GetObject("mnuAnalog.Image");
		this.mnuAnalog.Text = "&Analog";
		//
		//mnuMonochromator1
		//
		this.mnuMonochromator1.Items.AddRange(new NETXP.Controls.Bars.CommandBarItem[] { this.mnuMonochromator });
		this.mnuMonochromator1.PadHorizontal = 5;
		this.mnuMonochromator1.Text = "&Monochromator";
		//
		//mnuMonochromator
		//
		this.mnuMonochromator.Image = (System.Drawing.Image)resources.GetObject("mnuMonochromator.Image");
		this.mnuMonochromator.Text = "&Monochromator";
		//
		//mnuOptimise
		//
		this.mnuOptimise.Items.AddRange(new NETXP.Controls.Bars.CommandBarItem[] {
			this.mnuOptimizeTurretAll,
			this.mnuOptimizeTurret1,
			this.mnuInstrumentSetup,
			this.mnuAnaPeakSearch,
			this.mnuAbsScan,
			this.mnuEmissionSetup,
			this.mnuEmsPeakSearch
		});
		this.mnuOptimise.PadHorizontal = 5;
		this.mnuOptimise.Text = "&Optimise";
		//
		//mnuOptimizeTurretAll
		//
		this.mnuOptimizeTurretAll.Image = (System.Drawing.Image)resources.GetObject("mnuOptimizeTurretAll.Image");
		this.mnuOptimizeTurretAll.Text = "Turret &All";
		this.mnuOptimizeTurretAll.Visible = false;
		//
		//mnuOptimizeTurret1
		//
		this.mnuOptimizeTurret1.Image = (System.Drawing.Image)resources.GetObject("mnuOptimizeTurret1.Image");
		this.mnuOptimizeTurret1.Text = "&Turret 1";
		this.mnuOptimizeTurret1.Visible = false;
		//
		//mnuEmsPeakSearch
		//
		this.mnuEmsPeakSearch.Image = (System.Drawing.Image)resources.GetObject("mnuEmsPeakSearch.Image");
		this.mnuEmsPeakSearch.Text = "&Emission Peak Search";
		//
		//mnuAnaPeakSearch
		//
		this.mnuAnaPeakSearch.Image = (System.Drawing.Image)resources.GetObject("mnuAnaPeakSearch.Image");
		this.mnuAnaPeakSearch.Text = "A&nalytical Peak Search";
		//
		//mnuInstrumentSetup
		//
		this.mnuInstrumentSetup.Image = (System.Drawing.Image)resources.GetObject("mnuInstrumentSetup.Image");
		this.mnuInstrumentSetup.Text = "&Instrument Condition";
		//
		//mnuEmissionSetup
		//
		this.mnuEmissionSetup.Image = (System.Drawing.Image)resources.GetObject("mnuEmissionSetup.Image");
		this.mnuEmissionSetup.Text = "E&mission Setup";
		//
		//mnuAbsScan
		//
		this.mnuAbsScan.Image = (System.Drawing.Image)resources.GetObject("mnuAbsScan.Image");
		this.mnuAbsScan.Text = "Absorbance &Scan";
		//
		//mnuPneumatics
		//
		this.mnuPneumatics.Items.AddRange(new NETXP.Controls.Bars.CommandBarItem[] {
			this.mnuManualIgnition,
			this.mnuAutoIgnition
		});
		this.mnuPneumatics.PadHorizontal = 5;
		this.mnuPneumatics.Text = "&Pneumatics";
		//
		//mnuManualIgnition
		//
		this.mnuManualIgnition.Image = (System.Drawing.Image)resources.GetObject("mnuManualIgnition.Image");
		this.mnuManualIgnition.Text = "&Manual Ignition";
		//
		//mnuAutoIgnition
		//
		this.mnuAutoIgnition.Image = (System.Drawing.Image)resources.GetObject("mnuAutoIgnition.Image");
		this.mnuAutoIgnition.Text = "&Auto Ignition";
		//
		//mnuPrinterType1
		//
		this.mnuPrinterType1.Items.AddRange(new NETXP.Controls.Bars.CommandBarItem[] { this.mnuPrinterType });
		this.mnuPrinterType1.PadHorizontal = 5;
		this.mnuPrinterType1.Text = "P&rinter Type";
		//
		//mnuPrinterType
		//
		this.mnuPrinterType.Image = (System.Drawing.Image)resources.GetObject("mnuPrinterType.Image");
		this.mnuPrinterType.Text = "P&rinter Type";
		//
		//mnuExit1
		//
		this.mnuExit1.Items.AddRange(new NETXP.Controls.Bars.CommandBarItem[] { this.mnuExit });
		this.mnuExit1.PadHorizontal = 5;
		this.mnuExit1.Text = "E&xit";
		//
		//mnuExit
		//
		this.mnuExit.Image = (System.Drawing.Image)resources.GetObject("mnuExit.Image");
		this.mnuExit.Text = "E&xit";
		//
		//CustomPanel1
		//
		this.CustomPanel1.BackColor = System.Drawing.Color.AliceBlue;
		this.CustomPanel1.Controls.Add(this.CustomPanel2);
		this.CustomPanel1.Controls.Add(this.btnExtinguish);
		this.CustomPanel1.Controls.Add(this.btnIgnite);
		this.CustomPanel1.Controls.Add(this.btnN2OIgnite);
		this.CustomPanel1.Controls.Add(this.btnR);
		this.CustomPanel1.Controls.Add(this.btnDelete);
		this.CustomPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.CustomPanel1.Location = new System.Drawing.Point(0, 0);
		this.CustomPanel1.Name = "CustomPanel1";
		this.CustomPanel1.Size = new System.Drawing.Size(658, 375);
		this.CustomPanel1.TabIndex = 2;
		//
		//CustomPanel2
		//
		this.CustomPanel2.BackColor = System.Drawing.Color.AliceBlue;
		this.CustomPanel2.Location = new System.Drawing.Point(32, 312);
		this.CustomPanel2.Name = "CustomPanel2";
		this.CustomPanel2.Size = new System.Drawing.Size(40, 32);
		this.CustomPanel2.TabIndex = 16;
		//
		//btnExtinguish
		//
		this.btnExtinguish.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnExtinguish.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnExtinguish.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnExtinguish.Location = new System.Drawing.Point(32, 328);
		this.btnExtinguish.Name = "btnExtinguish";
		this.btnExtinguish.Size = new System.Drawing.Size(16, 8);
		this.btnExtinguish.TabIndex = 15;
		this.btnExtinguish.TabStop = false;
		this.btnExtinguish.Text = "&Extinguish";
		this.btnExtinguish.TextAlign = System.Drawing.ContentAlignment.TopLeft;
		//
		//btnIgnite
		//
		this.btnIgnite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnIgnite.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnIgnite.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnIgnite.Location = new System.Drawing.Point(56, 320);
		this.btnIgnite.Name = "btnIgnite";
		this.btnIgnite.Size = new System.Drawing.Size(16, 16);
		this.btnIgnite.TabIndex = 14;
		this.btnIgnite.TabStop = false;
		this.btnIgnite.Text = "&Ignition";
		this.btnIgnite.TextAlign = System.Drawing.ContentAlignment.TopLeft;
		//
		//btnN2OIgnite
		//
		this.btnN2OIgnite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnN2OIgnite.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnN2OIgnite.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnN2OIgnite.Location = new System.Drawing.Point(48, 320);
		this.btnN2OIgnite.Name = "btnN2OIgnite";
		this.btnN2OIgnite.Size = new System.Drawing.Size(5, 5);
		this.btnN2OIgnite.TabIndex = 19;
		this.btnN2OIgnite.TabStop = false;
		this.btnN2OIgnite.Text = "N2O&C";
		this.btnN2OIgnite.TextAlign = System.Drawing.ContentAlignment.TopLeft;
		//
		//btnR
		//
		this.btnR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnR.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnR.Location = new System.Drawing.Point(48, 328);
		this.btnR.Name = "btnR";
		this.btnR.Size = new System.Drawing.Size(8, 8);
		this.btnR.TabIndex = 24;
		this.btnR.TabStop = false;
		this.btnR.Text = "&R";
		this.btnR.TextAlign = System.Drawing.ContentAlignment.TopLeft;
		//
		//btnDelete
		//
		this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnDelete.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnDelete.Location = new System.Drawing.Point(40, 320);
		this.btnDelete.Name = "btnDelete";
		this.btnDelete.Size = new System.Drawing.Size(8, 8);
		this.btnDelete.TabIndex = 25;
		this.btnDelete.TabStop = false;
		this.btnDelete.Text = "&Delete";
		this.btnDelete.TextAlign = System.Drawing.ContentAlignment.TopLeft;
		//
		//StatusBar1
		//
		this.StatusBar1.Location = new System.Drawing.Point(0, 351);
		this.StatusBar1.Name = "StatusBar1";
		this.StatusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
			this.StatusBarPanelInfo,
			this.ProgressPanel,
			this.StatusBarPanelDate
		});
		this.StatusBar1.ShowPanels = true;
		this.StatusBar1.Size = new System.Drawing.Size(658, 24);
		this.StatusBar1.TabIndex = 13;
		this.StatusBar1.Text = "StatusBar1";
		//
		//StatusBarPanelInfo
		//
		this.StatusBarPanelInfo.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
		this.StatusBarPanelInfo.MinWidth = 40;
		this.StatusBarPanelInfo.Style = System.Windows.Forms.StatusBarPanelStyle.OwnerDraw;
		this.StatusBarPanelInfo.Width = 413;
		//
		//ProgressPanel
		//
		this.ProgressPanel.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
		this.ProgressPanel.Maximum = 100;
		this.ProgressPanel.Minimum = 0;
		this.ProgressPanel.Style = System.Windows.Forms.StatusBarPanelStyle.OwnerDraw;
		this.ProgressPanel.Value = 0;
		this.ProgressPanel.Width = 150;
		//
		//StatusBarPanelDate
		//
		this.StatusBarPanelDate.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
		this.StatusBarPanelDate.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
		this.StatusBarPanelDate.MinWidth = 40;
		this.StatusBarPanelDate.Style = System.Windows.Forms.StatusBarPanelStyle.OwnerDraw;
		this.StatusBarPanelDate.Text = "Current Date";
		this.StatusBarPanelDate.Width = 79;
		//
		//frmServiceRoutines
		//
		this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
		this.BackColor = System.Drawing.SystemColors.Control;
		this.ClientSize = new System.Drawing.Size(658, 375);
		this.Controls.Add(this.mnuBarServiceRoutines);
		this.Controls.Add(this.StatusBar1);
		this.Controls.Add(this.CustomPanel1);
		this.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		this.IsMdiContainer = true;
		this.Name = "frmServiceRoutines";
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "AAS 203 Service Routines";
		this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
		((System.ComponentModel.ISupportInitialize)this.mnuBarServiceRoutines).EndInit();
		this.CustomPanel1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.StatusBarPanelInfo).EndInit();
		((System.ComponentModel.ISupportInitialize)this.ProgressPanel).EndInit();
		((System.ComponentModel.ISupportInitialize)this.StatusBarPanelDate).EndInit();
		this.ResumeLayout(false);

	}

	#End Region

	#Region " Private Class Member Variables "

	private int mintMethodMode = 0;
	private bool mblnInProcess = false;

	private bool mblnAvoidProcessing = false;
	#End Region

	#Region " Private Constants "

	private const  ConstAA203FormLoad = "AA 203-Service Routines";
	private const  ConstAA203DFormLoad = "AA 203D-Service Routines";

	private const  ConstAA201FormLoad = "AA 201-Service Routines";
	//---4.85  14.04.09
	private const  ConstAA303FormLoad = "AA 303-Service Routines";
	private const  ConstAA303DFormLoad = "AA 303D-Service Routines";
	private const  ConstAA301FormLoad = "AA 301-Service Routines";
	//---4.85  14.04.09

	#End Region

	#Region " Form Events "

	private void  // ERROR: Handles clauses are not supported in C#
frmServiceRoutines_Load(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : frmServiceRoutines_Load
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To initialize the form
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S.
		// Created               : 07.09.06
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();

		try {
			if (gstructSettings.AppMode == EnumAppMode.FullVersion_201) {
				btnIgnite.Enabled = false;
				btnExtinguish.Enabled = false;
				mnuOptimizeTurretAll.Enabled = false;
				//Saurabh 22.06.07
				mnuOptimizeTurret1.Enabled = false;
				//Saurabh 22.06.07
			}

			mnuBarServiceRoutines.BackColor = System.Drawing.Color.Gainsboro;
			gobjclsTimer = new clsTimer(StatusBar1, 1000);

			AddHandlers();

			//---added on 29.01.08
			if (gobjCommProtocol.mobjCommdll.gFuncIsPortOpen()) {
				gobjCommProtocol.funcGet_Current_Wv(gobjInst.WavelengthCur);
			}
			//---added on 29.01.08

			if (gstructSettings.AppMode == EnumAppMode.FullVersion_201) {
				//Call ShowProgressBar(ConstAA201FormLoad)
				//Me.Text = ConstAA201FormLoad

				//---4.85  14.04.09
				if (gstructSettings.NewModelName == false) {
					ShowProgressBar(ConstAA201FormLoad);
					this.Text = ConstAA201FormLoad;
				} else {
					ShowProgressBar(ConstAA301FormLoad);
					this.Text = ConstAA301FormLoad;
				}
				//---4.85  14.04.09


				mnuTurret1.Text = "Lamp";
				//Added By Pankaj on 31 May 07
				mnuTurret.Text = "Lamp";
				mnuAutoIgnition.Visible = false;

			} else if (gstructSettings.AppMode == EnumAppMode.FullVersion_203) {
				//Call ShowProgressBar(ConstAA203FormLoad)
				//Me.Text = ConstAA203FormLoad

				//---4.85  14.04.09
				if (gstructSettings.NewModelName == false) {
					ShowProgressBar(ConstAA201FormLoad);
					this.Text = ConstAA201FormLoad;
				} else {
					ShowProgressBar(ConstAA301FormLoad);
					this.Text = ConstAA301FormLoad;
				}
			//---4.85  14.04.09

			} else if (gstructSettings.AppMode == EnumAppMode.FullVersion_203D) {
				//Call ShowProgressBar(ConstAA203DFormLoad)
				//Me.Text = ConstAA203DFormLoad

				//---4.85  14.04.09
				if (gstructSettings.NewModelName == false) {
					ShowProgressBar(ConstAA203DFormLoad);
					this.Text = ConstAA203DFormLoad;
				} else {
					ShowProgressBar(ConstAA303DFormLoad);
					this.Text = ConstAA303DFormLoad;
				}
			//---4.85  14.04.09

			} else {
				ShowProgressBar("Demo Mode - Service Routines");
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
			HideProgressBar();
			if (!objWait == null) {
				objWait.Dispose();
			}
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
		// Author                : Saurabh S.
		// Created               : 20.11.06
		// Revisions             : 
		//=====================================================================
		try {
			mnuExit.Click += mnuExit_Click;
			mnuAnalog.Click += mnuAnalog_Click;
			mnuPrinterType.Click += mnuPrinterType_Click;
			mnuMonochromator.Click += mnuMonochromator_Click;
			mnuAnaPeakSearch.Click += mnuAnaPeakSearch_Click;
			mnuEmsPeakSearch.Click += mnuEmsPeakSearch_Click;
			mnuEmissionSetup.Click += mnuEmissionSetup_Click;
			mnuAbsScan.Click += mnuAbsScan_Click;
			mnuManualIgnition.Click += mnuManualIgnition_Click;
			mnuAutoIgnition.Click += mnuAutoIgnition_Click;
			mnuInstrumentSetup.Click += mnuInstrumentSetup_Click;

			mnuTurret.Click += mnuTurret_Click;
			mnuOptimizeTurretAll.Click += mnuOptimizeTurretAll_Click;
			mnuOptimizeTurret1.Click += mnuOptimizeTurret1_Click;
		//AddHandler btnDelete.Click, AddressOf btnDelete_Click
		//AddHandler btnR.Click, AddressOf btnR_Click
		//AddHandler mnuExtinguish.Click, AddressOf btnExtinguish_Click
		//AddHandler mnuIgnite.Click, AddressOf btnAutoIgnition_Click

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

	private void mnuExit_Click(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : mnuExit_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To exit from Service Routine window. 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 20.11.06
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		try {
			this.DialogResult = DialogResult.Cancel;
		//Me.Close()
		//Me.Dispose()

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

	private void mnuTurret_Click(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : mnuTurret_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To load the Turret form
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 21.11.06
		// Revisions             : 
		//=====================================================================
		frmTurret objfrmTurret = new frmTurret();
		CWaitCursor objWait = new CWaitCursor();
		try {
			objfrmTurret.ShowDialog();
			objfrmTurret.Close();
			objfrmTurret.Dispose();
			objfrmTurret = null;
			this.Visible = true;
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

	private void mnuAnalog_Click(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : mnuAnalog_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To load the Method form
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 21.11.06
		// Revisions             : 
		//=====================================================================
		object objfrmAnalog;
		//New frmAnalog
		CWaitCursor objWait = new CWaitCursor();
		try {
			if (gstructSettings.AppMode == EnumAppMode.FullVersion_203D) {
				objfrmAnalog = new frmAnalogDB();
			} else {
				objfrmAnalog = new frmAnalog();
			}

			objfrmAnalog.ShowDialog();
			objfrmAnalog.Close();
			objfrmAnalog.Dispose();
			objfrmAnalog = null;
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

	private void mnuMonochromator_Click(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : mnuMonochromator_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To load the Monochromator form
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 21.11.06
		// Revisions             : 
		//=====================================================================
		object objfrmMonochromator;
		//New frmMonochromator
		CWaitCursor objWait = new CWaitCursor();
		try {
			if (gstructSettings.AppMode == EnumAppMode.FullVersion_203D) {
				objfrmMonochromator = new frmMonochromatorDB();
			} else {
				objfrmMonochromator = new frmMonochromator();
			}
			objfrmMonochromator.ShowDialog();
			objfrmMonochromator.Close();
			objfrmMonochromator.Dispose();
			objfrmMonochromator = null;
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

	private void mnuPrinterType_Click(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : mnuPrinterType_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To load the Printer type form
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 04.04.07
		// Revisions             : 
		//=====================================================================
		frmPrinterType objfrmPrinterType = new frmPrinterType();
		CWaitCursor objWait = new CWaitCursor();
		try {
			//objfrmPrinterType.ShowDialog()
			//objfrmPrinterType.Close()
			//objfrmPrinterType.Dispose()
			//objfrmPrinterType = Nothing
			//Application.DoEvents()
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
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	private void mnuManualIgnition_Click(object sender, System.EventArgs e)
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
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		frmManualIgnition objfrmManualIgnition = new frmManualIgnition();
		try {
			// code added by : dinesh wagh on 22.3.2009
			// code start
			if (gstructSettings.AppMode == EnumAppMode.DemoMode_201 | gstructSettings.AppMode == EnumAppMode.FullVersion_201) {
				objfrmManualIgnition.Width = objfrmManualIgnition.Width - 175;
				objfrmManualIgnition.StartPosition = FormStartPosition.CenterScreen;
			}
			//........code ends.

			objfrmManualIgnition.ShowDialog();
			objfrmManualIgnition.Close();
			objfrmManualIgnition.Dispose();
			objfrmManualIgnition = null;
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

	private void mnuAutoIgnition_Click(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : mnuAutoIgnition_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To load the AutoIgnition form
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 04.02.07
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		frmAutoIgnition objfrmAutoIgnition = new frmAutoIgnition();
		try {
			objfrmAutoIgnition.ShowDialog();
			//'for showing a dialog.
			objfrmAutoIgnition.Close();
			objfrmAutoIgnition.Dispose();
			objfrmAutoIgnition = null;
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
				//'destructure.
			}
			//---------------------------------------------------------
		}
	}

	private void mnuInstrumentSetup_Click(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : mnuInstrumentSetup_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To load the Instrument Parameters form
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 30.11.06
		// Revisions             : Deepak B. on 15.01.07
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		frmInstrumentParameters objfrmInstrumentParameters;

		try {
			objfrmInstrumentParameters = new frmInstrumentParameters();
			objfrmInstrumentParameters.ShowDialog();
			objfrmInstrumentParameters.Close();
			objfrmInstrumentParameters.Dispose();
			objfrmInstrumentParameters = null;
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
			objWait.Dispose();
			//---------------------------------------------------------
		}
	}

	private void mnuEmissionSetup_Click(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : mnuEmissionSetup_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To load the Emission Setup form
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 30.11.06
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		frmEmissionMode objfrmEmissionMode;

		try {
			objfrmEmissionMode = new frmEmissionMode(EnumMethodMode.NewMode);
			objfrmEmissionMode.ShowDialog();
			objfrmEmissionMode.Close();
			objfrmEmissionMode.Dispose();
			objfrmEmissionMode = null;
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
			objWait.Dispose();
			//---------------------------------------------------------
		}
	}

	private void mnuEmsPeakSearch_Click(object sender, EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : mnuEmsPeakSearch_Click
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : To find the Emmision Peak
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 24-Jan-2007 12:35 pm
		// Revisions             : 1
		//=====================================================================
		CWaitCursor objWaitCursor = new CWaitCursor();

		try {
			gobjClsAAS203.Find_Emmission_Peak();

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
			objWaitCursor.Dispose();
			//---------------------------------------------------------
		}
	}

	private void mnuAnaPeakSearch_Click(object sender, EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : mnuAnaPeakSearch_Click
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 24-Jan-2007 12:35 pm
		// Revisions             : 1
		//=====================================================================
		CWaitCursor objWaitCursor = new CWaitCursor();
		double dblWvOpt;

		try {
			//Saurabh--25.06.07
			if (!IsNothing(gobjMain)) {
				gobjMain.mobjController.Cancel();
				gobjCommProtocol.mobjCommdll.subTime_Delay(500);
				//10.12.07
				Application.DoEvents();
			}
			//Saurabh--25.06.07
			gobjClsAAS203.Find_Analytical_Peak(gobjInst.Lamp_Position, dblWvOpt);

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
			//Saurabh--25.06.07
			if (!IsNothing(gobjMain)) {
				gobjMain.mobjController.Start(gobjclsBgFlameStatus);
				Application.DoEvents();
			}
			//Saurabh--25.06.07
			objWaitCursor.Dispose();
			//---------------------------------------------------------
		}
	}

	private void mnuOptimizeTurretAll_Click(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : mnuOptimizeTurretAll_Click
		// Parameters Passed     : 
		// Returns               : None
		// Purpose               : To call Turret optimisation procedure 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak B.
		// Created               : 16.12.06
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		try {
			frmZeroOrder mobjfrmZeroOrder;
			mobjfrmZeroOrder = new frmZeroOrder();
			mobjfrmZeroOrder.StartPosition = FormStartPosition.Manual;
			mobjfrmZeroOrder.Location = new Point(ZeroOrderThreadWindowLocationX, ZeroOrderThreadWindowLocationY);
			mobjfrmZeroOrder.StartOptimizeTread();
			mobjfrmZeroOrder.ShowDialog();
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

	private void mnuOptimizeTurret1_Click(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : mnuOptimizeTurret1_Click
		// Parameters Passed     : 
		// Returns               : None
		// Purpose               : To call Turret optimisation procedure 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak B.
		// Created               : 15.01.07
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		int intCounter;
		double dblCurrent;
		int intTurretNumber;

		try {
			if (gstructSettings.ExeToRun == EnumApplicationMode.AAS) {
				if (!IsNothing(gobjNewMethod)) {
					dblCurrent = gobjNewMethod.InstrumentCondition.LampCurrent;
					intTurretNumber = gobjNewMethod.InstrumentCondition.TurretNumber;
				} else {
					intTurretNumber = 1;
				}
			} else {
				if (gintTurretToOptimizeForServiceUtility > 0) {
					intTurretNumber = gintTurretToOptimizeForServiceUtility;
					dblCurrent = gobjInst.Lamp.LampParametersCollection.item(gintTurretToOptimizeForServiceUtility - 1).Current;
				}
			}

			gfuncLamp_connected(intTurretNumber);

			frmTurretOptimisation mobjfrmturretOptimisation;
			mobjfrmturretOptimisation = new frmTurretOptimisation(dblCurrent, intTurretNumber);
			mobjfrmturretOptimisation.StartOptimizeTread();
			mobjfrmturretOptimisation.StartPosition = FormStartPosition.CenterScreen;
			mobjfrmturretOptimisation.ShowDialog();

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

	private void mnuAbsScan_Click(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : mnuAbsScan_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To load the Abs Scan form
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 30.11.06
		// Revisions             : Sachin Dokhale on 18.03.07
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		object objfrmTimeScanMode;
		//frmTimeScanMode
		int intCalibrationMode;
		try {
			intCalibrationMode = gobjInst.Mode;
			if (gobjCommProtocol.funcCalibrationMode(EnumCalibrationMode.AA)) {
				gintSpectrumMode = modGlobalDeclarations.EnumSpectrumMode.TimeScan;
				if (gstructSettings.AppMode == EnumAppMode.FullVersion_203D) {
					//If gintInstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.SingleBeam Or _
					//        gintInstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.ReferenceBeam Then
					//    'objfrmTimeScanMode = New frmTimeScanMode
					//    objfrmTimeScanMode = New frmTimeScanDBMode
					//Else
					//    objfrmTimeScanMode = New frmTimeScanDBMode
					//End If

					//by Pankaj on 18.1.08 for beam type
					if (gintServiceBeamType == AAS203Library.Instrument.enumInstrumentBeamType.DoubleBeam) {
						objfrmTimeScanMode = new frmTimeScanDBMode();
					} else {
						objfrmTimeScanMode = new frmTimeScanMode();
					}

				} else {
					objfrmTimeScanMode = new frmTimeScanMode();
				}

				objfrmTimeScanMode.ShowDialog();
				objfrmTimeScanMode.Close();
			}
			Application.DoEvents();
			gobjCommProtocol.funcCalibrationMode(intCalibrationMode);



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
			if (!objfrmTimeScanMode == null) {
				objfrmTimeScanMode.Dispose();
				objfrmTimeScanMode = null;
			}
			objWait.Dispose();
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	//Private Sub btnAutoIgnition_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
	//    '=====================================================================
	//    ' Procedure Name        : btnAutoIgnition_Click
	//    ' Parameters Passed     : Object, EventArgs
	//    ' Returns               : None
	//    ' Purpose               : 
	//    ' Description           : 
	//    ' Assumptions           : 
	//    ' Dependencies          : 
	//    ' Author                : Mangesh Shardul
	//    ' Created               : 18-Feb-2007 03:15 pm
	//    ' Revisions             : 1
	//    '=====================================================================
	//    Try
	//        RemoveHandler mnuIgnite.Click, AddressOf btnAutoIgnition_Click

	//        'If Not IsNothing(mobjfrmAnalysis) Then mobjfrmAnalysis.tmrAspirationMsg.Enabled = False
	//        ' mobjController.Cancel()
	//        Application.DoEvents()

	//        Call gobjClsAAS203.funcIgnite(True)

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
	//        'If Not IsNothing(mobjfrmAnalysis) Then mobjfrmAnalysis.tmrAspirationMsg.Enabled = True
	//        'mobjController.Start(gobjclsBgFlameStatus)
	//        Application.DoEvents()
	//        AddHandler mnuIgnite.Click, AddressOf btnAutoIgnition_Click
	//        '---------------------------------------------------------
	//    End Try
	//End Sub

	//Private Sub btnExtinguish_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
	//    '=====================================================================
	//    ' Procedure Name        : btnExtinguish_Click
	//    ' Parameters Passed     : Object, EventArgs
	//    ' Returns               : None
	//    ' Purpose               : 
	//    ' Description           : 
	//    ' Assumptions           : 
	//    ' Dependencies          : 
	//    ' Author                : Mangesh Shardul
	//    ' Created               : 18-Feb-2007 03:15 pm
	//    ' Revisions             : 1
	//    '=====================================================================
	//    Try
	//        RemoveHandler mnuExtinguish.Click, AddressOf btnExtinguish_Click
	//        'If Not IsNothing(mobjfrmAnalysis) Then mobjfrmAnalysis.tmrAspirationMsg.Enabled = False
	//        'mobjController.Cancel()
	//        Application.DoEvents()

	//        Call gobjClsAAS203.funcIgnite(False)

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
	//        'If Not IsNothing(mobjfrmAnalysis) Then mobjfrmAnalysis.tmrAspirationMsg.Enabled = True
	//        'mobjController.Start(gobjclsBgFlameStatus)
	//        Application.DoEvents()
	//        AddHandler mnuExtinguish.Click, AddressOf btnExtinguish_Click
	//        '---------------------------------------------------------
	//    End Try
	//End Sub

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
			StatusBarPanelInfo.Text = message;
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
			//ProgressPanel.Value = 20
			StatusBarPanelInfo.Text = message;
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

	//Private Sub mnuTurret_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuTurret.Enter
	//    '=====================================================================
	//    ' Procedure Name        : mnuTurret_Click
	//    ' Parameters Passed     : Object,EventArgs
	//    ' Returns               : None
	//    ' Purpose               : To load the Turret form
	//    ' Description           : 
	//    ' Assumptions           : 
	//    ' Dependencies          : 
	//    ' Author                : Saurabh S
	//    ' Created               : 21.11.06
	//    ' Revisions             : 
	//    '=====================================================================
	//    Dim objfrmTurret As New frmTurret
	//    Dim objWait As New CWaitCursor
	//    Try
	//        objfrmTurret.ShowDialog()
	//        Application.DoEvents()
	//        Me.Visible = True
	//        objfrmTurret.Dispose()

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
btnIgnite_Click(object sender, System.EventArgs e)
	{
		if (mblnAvoidProcessing == true) {
			return;
		}
		try {
			mblnAvoidProcessing = true;
			gobjClsAAS203.funcIgnite(true);
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
		if (mblnAvoidProcessing == true) {
			return;
		}
		try {
			mblnAvoidProcessing = true;
			gobjClsAAS203.funcIgnite(false);
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
		if (mblnAvoidProcessing == true) {
			return;
		}
		try {
			mblnAvoidProcessing = true;
			gobjCommProtocol.mobjCommdll.subTime_Delay(100);
			gobjCommProtocol.funcSwitchOver();

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
			if (mblnInProcess == true) {
				return;
			}
			mblnInProcess = true;
			Application.DoEvents();
			gobjMainService.funcAltDelete();
			mblnInProcess = false;
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			//---------------------------------------------------------
			mblnInProcess = false;
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
			if (mblnInProcess == true) {
				return;
			}
			mblnInProcess = true;
			Application.DoEvents();
			gobjMainService.funcAltR();
			mblnInProcess = false;
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			//---------------------------------------------------------
			mblnInProcess = false;
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
MenuBar_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
	{
		if (mblnAvoidProcessing == true) {
			return;
		}
		mblnAvoidProcessing = true;
		if (e.Alt == true) {
			switch (e.KeyCode) {
				case Keys.I:
					AutoIgnition();
				case Keys.C:
					N2OAutoIgnition();
				case Keys.E:
					Extinguish();
				case Keys.D:
					gobjMainService.funcAltDelete();
				case Keys.R:
					gobjMainService.funcAltR();

				case Keys.Q:
			}
		}
		mblnAvoidProcessing = false;
		return;
	}

	public bool AutoIgnition()
	{
		//=====================================================================
		// Procedure Name        : AutoIgnition
		// Parameters Passed     : Object, EventArgs
		// Returns               : None
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 18-Feb-2007 03:15 pm
		// Revisions             : 1
		//=====================================================================
		try {
			//RemoveHandler mnuIgnite.Click, AddressOf btnAutoIgnition_Click

			//If Not gstructSettings.AppMode = EnumAppMode.DemoMode Then
			if (!((gstructSettings.AppMode == EnumAppMode.DemoMode) | (gstructSettings.AppMode == EnumAppMode.DemoMode_201) | (gstructSettings.AppMode == EnumAppMode.DemoMode_203D))) {
				Application.DoEvents();
				gobjCommProtocol.mobjCommdll.subTime_Delay(100);
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
			Application.DoEvents();
			//AddHandler mnuIgnite.Click, AddressOf btnAutoIgnition_Click
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
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 18-Feb-2007 03:15 pm
		// Revisions             : 1
		//=====================================================================
		try {
			//RemoveHandler mnuExtinguish.Click, AddressOf btnExtinguish_Click

			//If Not gstructSettings.AppMode = EnumAppMode.DemoMode Then
			if (!((gstructSettings.AppMode == EnumAppMode.DemoMode) | (gstructSettings.AppMode == EnumAppMode.DemoMode_201) | (gstructSettings.AppMode == EnumAppMode.DemoMode_203D))) {
				Application.DoEvents();
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
			Application.DoEvents();
			//AddHandler mnuExtinguish.Click, AddressOf btnExtinguish_Click
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
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 18-Aug-2007 03:15 pm
		// Revisions             : 1
		//=====================================================================
		try {
			//RemoveHandler mnuIgnite.Click, AddressOf btnAutoIgnition_Click

			//If Not gstructSettings.AppMode = EnumAppMode.DemoMode Then
			if (!((gstructSettings.AppMode == EnumAppMode.DemoMode) | (gstructSettings.AppMode == EnumAppMode.DemoMode_201) | (gstructSettings.AppMode == EnumAppMode.DemoMode_203D))) {
				Application.DoEvents();
				gobjCommProtocol.mobjCommdll.subTime_Delay(100);
				gobjCommProtocol.funcSwitchOver();

			} else {
				//    Call gobjMessageAdapter.ShowMessage(constFlameIgnited)
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

			Application.DoEvents();
			//AddHandler mnuIgnite.Click, AddressOf btnAutoIgnition_Click
			//---------------------------------------------------------
		}
	}

	private void  // ERROR: Handles clauses are not supported in C#
mnuOptimise_DropDown(object sender, System.ComponentModel.CancelEventArgs e)
	{
		if (gblnIsInstrumentConditionsActive == true) {
			mnuAnaPeakSearch.Enabled = true;
			mnuEmsPeakSearch.Enabled = false;
		} else {
			mnuAnaPeakSearch.Enabled = false;
			mnuEmsPeakSearch.Enabled = true;
		}
	}
}
