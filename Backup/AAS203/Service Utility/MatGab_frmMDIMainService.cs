using System.Threading;
using AAS203.Common;
using AAS203Library.Method;
public class frmMDIMainService : System.Windows.Forms.Form
{

	#Region " Windows Form Designer generated code "

	public frmMDIMainService()
	{
		base.New();

		//This call is required by the Windows Form Designer.
		InitializeComponent();
		this.mnuTest_AAS2031.Text = "Test " + gstrTitleInstrumentType;
		//by Pankaj on 18.1.08
		this.mnuTest_AAS203.Text = "Test " + gstrTitleInstrumentType;
		//by Pankaj on 18.1.08

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
	internal NETXP.Controls.Bars.CommandBar CommandBar1;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuSpectrum;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuAbout;
	internal NETXP.Controls.Bars.StatusBar StatusBar1;
	internal System.Windows.Forms.StatusBarPanel StatusBarPanelInfo;
	internal NETXP.Controls.Bars.ProgressPanel ProgressPanel;
	internal System.Windows.Forms.StatusBarPanel StatusBarPanelDate;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuUVSpectrum;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuEnergySpectrum;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuIngnition;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuTest_AAS2031;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuService1;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuInstSetup1;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuExit1;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuTest_AAS203;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuService;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuInstSetup;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuExit;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuChangePort1;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuChangePort;
	internal GradientPanel.CustomPanel CustomPanel2;
	internal NETXP.Controls.XPButton btnN2OIgnite;
	internal NETXP.Controls.XPButton btnIgnite;
	internal NETXP.Controls.XPButton btnExtinguish;
	internal NETXP.Controls.XPButton btnR;
	internal NETXP.Controls.XPButton btnDelete;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuBeamType;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuSingleBeam;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuDoubleBeam;
	[System.Diagnostics.DebuggerStepThrough()]
	private void InitializeComponent()
	{
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMDIMainService));
		this.CustomPanel1 = new GradientPanel.CustomPanel();
		this.CustomPanel2 = new GradientPanel.CustomPanel();
		this.btnN2OIgnite = new NETXP.Controls.XPButton();
		this.btnR = new NETXP.Controls.XPButton();
		this.btnIgnite = new NETXP.Controls.XPButton();
		this.btnExtinguish = new NETXP.Controls.XPButton();
		this.btnDelete = new NETXP.Controls.XPButton();
		this.CommandBar1 = new NETXP.Controls.Bars.CommandBar();
		this.mnuChangePort1 = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuChangePort = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuTest_AAS2031 = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuTest_AAS203 = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuService1 = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuService = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuInstSetup1 = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuInstSetup = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuSpectrum = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuUVSpectrum = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuEnergySpectrum = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuAbout = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuBeamType = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuSingleBeam = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuDoubleBeam = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuExit1 = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuExit = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.StatusBar1 = new NETXP.Controls.Bars.StatusBar();
		this.StatusBarPanelInfo = new System.Windows.Forms.StatusBarPanel();
		this.ProgressPanel = new NETXP.Controls.Bars.ProgressPanel();
		this.StatusBarPanelDate = new System.Windows.Forms.StatusBarPanel();
		this.mnuIngnition = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.CustomPanel1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.CommandBar1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.StatusBarPanelInfo).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.ProgressPanel).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.StatusBarPanelDate).BeginInit();
		this.SuspendLayout();
		//
		//CustomPanel1
		//
		this.CustomPanel1.BackColor = System.Drawing.Color.AliceBlue;
		this.CustomPanel1.Controls.Add(this.CustomPanel2);
		this.CustomPanel1.Controls.Add(this.btnN2OIgnite);
		this.CustomPanel1.Controls.Add(this.btnR);
		this.CustomPanel1.Controls.Add(this.btnIgnite);
		this.CustomPanel1.Controls.Add(this.btnExtinguish);
		this.CustomPanel1.Controls.Add(this.btnDelete);
		this.CustomPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.CustomPanel1.Location = new System.Drawing.Point(0, 0);
		this.CustomPanel1.Name = "CustomPanel1";
		this.CustomPanel1.Size = new System.Drawing.Size(658, 359);
		this.CustomPanel1.TabIndex = 1;
		//
		//CustomPanel2
		//
		this.CustomPanel2.BackColor = System.Drawing.Color.AliceBlue;
		this.CustomPanel2.Location = new System.Drawing.Point(56, 272);
		this.CustomPanel2.Name = "CustomPanel2";
		this.CustomPanel2.Size = new System.Drawing.Size(64, 16);
		this.CustomPanel2.TabIndex = 16;
		//
		//btnN2OIgnite
		//
		this.btnN2OIgnite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnN2OIgnite.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnN2OIgnite.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnN2OIgnite.Location = new System.Drawing.Point(72, 280);
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
		this.btnR.Location = new System.Drawing.Point(96, 280);
		this.btnR.Name = "btnR";
		this.btnR.Size = new System.Drawing.Size(8, 8);
		this.btnR.TabIndex = 22;
		this.btnR.TabStop = false;
		this.btnR.Text = "&R";
		this.btnR.TextAlign = System.Drawing.ContentAlignment.TopLeft;
		//
		//btnIgnite
		//
		this.btnIgnite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnIgnite.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnIgnite.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnIgnite.Location = new System.Drawing.Point(88, 280);
		this.btnIgnite.Name = "btnIgnite";
		this.btnIgnite.Size = new System.Drawing.Size(8, 8);
		this.btnIgnite.TabIndex = 20;
		this.btnIgnite.TabStop = false;
		this.btnIgnite.Text = "&Ignition";
		this.btnIgnite.TextAlign = System.Drawing.ContentAlignment.TopLeft;
		//
		//btnExtinguish
		//
		this.btnExtinguish.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnExtinguish.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnExtinguish.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnExtinguish.Location = new System.Drawing.Point(80, 280);
		this.btnExtinguish.Name = "btnExtinguish";
		this.btnExtinguish.Size = new System.Drawing.Size(8, 8);
		this.btnExtinguish.TabIndex = 21;
		this.btnExtinguish.TabStop = false;
		this.btnExtinguish.Text = "&Extinguish";
		this.btnExtinguish.TextAlign = System.Drawing.ContentAlignment.TopLeft;
		//
		//btnDelete
		//
		this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnDelete.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnDelete.Location = new System.Drawing.Point(104, 280);
		this.btnDelete.Name = "btnDelete";
		this.btnDelete.Size = new System.Drawing.Size(8, 8);
		this.btnDelete.TabIndex = 23;
		this.btnDelete.TabStop = false;
		this.btnDelete.Text = "&Delete";
		this.btnDelete.TextAlign = System.Drawing.ContentAlignment.TopLeft;
		//
		//CommandBar1
		//
		this.CommandBar1.BackColor = System.Drawing.Color.Transparent;
		this.CommandBar1.CustomBackground = true;
		this.CommandBar1.CustomizeText = "&Customize Toolbar...";
		this.CommandBar1.Dock = System.Windows.Forms.DockStyle.Top;
		this.CommandBar1.FullRow = true;
		this.CommandBar1.ID = 629;
		this.CommandBar1.Items.AddRange(new NETXP.Controls.Bars.CommandBarItem[] {
			this.mnuChangePort1,
			this.mnuTest_AAS2031,
			this.mnuService1,
			this.mnuInstSetup1,
			this.mnuSpectrum,
			this.mnuAbout,
			this.mnuBeamType,
			this.mnuExit1
		});
		this.CommandBar1.Location = new System.Drawing.Point(0, 0);
		this.CommandBar1.Margins.Bottom = 1;
		this.CommandBar1.Margins.Left = 1;
		this.CommandBar1.Margins.Right = 1;
		this.CommandBar1.Margins.Top = 1;
		this.CommandBar1.Name = "CommandBar1";
		this.CommandBar1.Size = new System.Drawing.Size(658, 23);
		this.CommandBar1.Style = NETXP.Controls.Bars.CommandBarStyle.Menu;
		this.CommandBar1.TabIndex = 2;
		this.CommandBar1.TabStop = false;
		this.CommandBar1.Text = "";
		//
		//mnuChangePort1
		//
		this.mnuChangePort1.Items.AddRange(new NETXP.Controls.Bars.CommandBarItem[] { this.mnuChangePort });
		this.mnuChangePort1.PadHorizontal = 5;
		this.mnuChangePort1.Text = "&Change Port";
		//
		//mnuChangePort
		//
		this.mnuChangePort.Text = "&Change Port";
		//
		//mnuTest_AAS2031
		//
		this.mnuTest_AAS2031.Items.AddRange(new NETXP.Controls.Bars.CommandBarItem[] { this.mnuTest_AAS203 });
		this.mnuTest_AAS2031.PadHorizontal = 5;
		this.mnuTest_AAS2031.Shortcut = System.Windows.Forms.Shortcut.CtrlT;
		this.mnuTest_AAS2031.Text = "Test";
		//
		//mnuTest_AAS203
		//
		this.mnuTest_AAS203.Image = (System.Drawing.Image)resources.GetObject("mnuTest_AAS203.Image");
		this.mnuTest_AAS203.Text = "Test";
		//
		//mnuService1
		//
		this.mnuService1.Items.AddRange(new NETXP.Controls.Bars.CommandBarItem[] { this.mnuService });
		this.mnuService1.PadHorizontal = 5;
		this.mnuService1.Shortcut = System.Windows.Forms.Shortcut.CtrlS;
		this.mnuService1.Text = "&Service";
		//
		//mnuService
		//
		this.mnuService.Image = (System.Drawing.Image)resources.GetObject("mnuService.Image");
		this.mnuService.Text = "&Service";
		//
		//mnuInstSetup1
		//
		this.mnuInstSetup1.Items.AddRange(new NETXP.Controls.Bars.CommandBarItem[] { this.mnuInstSetup });
		this.mnuInstSetup1.PadHorizontal = 5;
		this.mnuInstSetup1.Text = "I&nst Setup";
		//
		//mnuInstSetup
		//
		this.mnuInstSetup.Image = (System.Drawing.Image)resources.GetObject("mnuInstSetup.Image");
		this.mnuInstSetup.Text = "&Inst Setup";
		//
		//mnuSpectrum
		//
		this.mnuSpectrum.Items.AddRange(new NETXP.Controls.Bars.CommandBarItem[] {
			this.mnuUVSpectrum,
			this.mnuEnergySpectrum
		});
		this.mnuSpectrum.PadHorizontal = 5;
		this.mnuSpectrum.Text = "S&pectrum";
		//
		//mnuUVSpectrum
		//
		this.mnuUVSpectrum.Image = (System.Drawing.Image)resources.GetObject("mnuUVSpectrum.Image");
		this.mnuUVSpectrum.Text = "&UV Spectrum";
		//
		//mnuEnergySpectrum
		//
		this.mnuEnergySpectrum.Image = (System.Drawing.Image)resources.GetObject("mnuEnergySpectrum.Image");
		this.mnuEnergySpectrum.Text = "&Energy Spectrum";
		//
		//mnuAbout
		//
		this.mnuAbout.PadHorizontal = 5;
		this.mnuAbout.Text = "A&bout";
		this.mnuAbout.Visible = false;
		//
		//mnuBeamType
		//
		this.mnuBeamType.Items.AddRange(new NETXP.Controls.Bars.CommandBarItem[] {
			this.mnuSingleBeam,
			this.mnuDoubleBeam
		});
		this.mnuBeamType.Text = "Beam Type";
		this.mnuBeamType.Visible = false;
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
		this.mnuDoubleBeam.Text = "Double Beam";
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
		//StatusBar1
		//
		this.StatusBar1.Location = new System.Drawing.Point(0, 335);
		this.StatusBar1.Name = "StatusBar1";
		this.StatusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
			this.StatusBarPanelInfo,
			this.ProgressPanel,
			this.StatusBarPanelDate
		});
		this.StatusBar1.ShowPanels = true;
		this.StatusBar1.Size = new System.Drawing.Size(658, 24);
		this.StatusBar1.TabIndex = 9;
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
		//mnuIngnition
		//
		this.mnuIngnition.Shortcut = System.Windows.Forms.Shortcut.CtrlI;
		this.mnuIngnition.Text = null;
		//
		//frmMDIMainService
		//
		this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
		this.BackColor = System.Drawing.SystemColors.Control;
		this.ClientSize = new System.Drawing.Size(658, 359);
		this.Controls.Add(this.StatusBar1);
		this.Controls.Add(this.CommandBar1);
		this.Controls.Add(this.CustomPanel1);
		this.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		this.IsMdiContainer = true;
		this.Name = "frmMDIMainService";
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "AA203 Service and Maintenance Software";
		this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
		this.CustomPanel1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.CommandBar1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.StatusBarPanelInfo).EndInit();
		((System.ComponentModel.ISupportInitialize)this.ProgressPanel).EndInit();
		((System.ComponentModel.ISupportInitialize)this.StatusBarPanelDate).EndInit();
		this.ResumeLayout(false);

	}

	#End Region

	#Region " Public Variables "

	//Public gobjCommdll As New RS232SerialComm.clsRS232Main(9600, 0, gintCommPortSelected, 8)

	public clsRS232Main gobjCommdll = new clsRS232Main(9600, 0, gintCommPortSelected, 8);
	private bool mblnAvoidProcessing = false;
		#End Region
	frmAASInitialisation objfrmAASInitialisation;

	#Region " Private Constants "

	private const  ConstAA203FormLoad = "AA 203-Service and Maintaince Software";
	//Private Const ConstAA203DFormLoad = "AAS203D-Service and Maintaince Software" by Pankaj on 16.1.08
		// by Pankaj on 16.1.08
	private const  ConstAA203DFormLoad = "AA 203D-Service and Maintaince Software";

	private const  ConstAA201FormLoad = "AA 201-Service and Maintaince Software";
	//---4.85 14.04.09
	private const  ConstAA303FormLoad = "AA 303-Service and Maintaince Software";
	private const  ConstAA303DFormLoad = "AA 303D-Service and Maintaince Software";
	private const  ConstAA301FormLoad = "AA 301-Service and Maintaince Software";
	//---4.85 14.04.09

	#End Region

	#Region " Form Events "

	private void  // ERROR: Handles clauses are not supported in C#
frmMDIMainService_Load(object sender, System.EventArgs e)
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
		CWaitCursor objWait;

		try {
			//gobjInst.WavelengthCur = 0.0
			if (gstructSettings.AppMode == EnumAppMode.FullVersion_201) {
				btnIgnite.Enabled = false;
				btnExtinguish.Enabled = false;
			}

			if (gstructSettings.ExeToRun == EnumApplicationMode.AAS) {
				mnuChangePort1.Enabled = false;
			}
			CommandBar1.BackColor = System.Drawing.Color.Gainsboro;

			gobjclsTimer = new clsTimer(StatusBar1, 1000);
			//gobjMain.mobjController.Cancel()
			gobjfrmStatus.Visible = false;

			if (gstructSettings.AppMode == EnumAppMode.FullVersion_203D) {
				//Call ShowProgressBar(ConstAA203DFormLoad)
				//Me.Text = ConstAA203DFormLoad

				//---4.85  14.04.09
				if (gstructSettings.NewModelName == false) {
					ShowProgressBar(ConstAA203DFormLoad);
					this.Text = ConstAA203DFormLoad;
				} else {
					ShowProgressBar(ConstAA203DFormLoad);
					this.Text = ConstAA303DFormLoad;
				}
				//---4.85  14.04.09

				mnuBeamType.Visible = true;
			} else if (gstructSettings.AppMode == EnumAppMode.FullVersion_201) {
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

			} else {
				//Call ShowProgressBar(ConstAA203FormLoad)
				//Me.Text = ConstAA203FormLoad

				//---4.85  14.04.09
				if (gstructSettings.NewModelName == false) {
					ShowProgressBar(ConstAA203FormLoad);
					this.Text = ConstAA203FormLoad;
				} else {
					ShowProgressBar(ConstAA303FormLoad);
					this.Text = ConstAA303FormLoad;
				}
				//---4.85  14.04.09

				mnuUVSpectrum.Enabled = true;
			}

			this.BringToFront();

			//gobjMain.Visible = False
			AddHandlers();


			//---added by deepak on 21.01.08
			gobjNewMethod = new clsMethod();
			//---added by deepak on 21.01.08

			HideProgressBar();

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
			Application.DoEvents();
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
			mnuExit.Click += mnuExit_Click;
			mnuAbout.Click += mnuAbout_Click;
			mnuService.Click += mnuService_Click;
			mnuChangePort.Click += mnuChangePort_Click;
			mnuTest_AAS203.Click += mnuTest_AAS203_Click;
			mnuInstSetup.Click += mnuInstSetup_TimeScan_Click;
			mnuUVSpectrum.Click += mnuUVSpectrum_Click;
			mnuEnergySpectrum.Click += mnuEnergySpectrum_Click;
			mnuSingleBeam.Click += mnuSingleBeam_Click;
			mnuDoubleBeam.Click += mnuDoubleBeam_Click;
		//AddHandler mnuExtinguish.Click, AddressOf btnExtinguish_Click
		//AddHandler btnDelete.Click, AddressOf btnDelete_Click
		//AddHandler btnR.Click, AddressOf btnR_Click
		//AddHandler btnIgnite.Click, AddressOf btnIgnite_Click
		//AddHandler btnExtinguish.Click, AddressOf btnExtinguish_Click
		//AddHandler btnN2OIgnite.Click, AddressOf btnN2OIgnite_Click


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
		// Purpose               : To exit from the software 
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

	private void mnuService_Click(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : mnuService_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To load the Service Routines form
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 25.09.06
		// Revisions             : 
		//=====================================================================
		//Dim objWait As New CWaitCursor
		//Dim objfrmServiceRoutines As New frmServiceRoutines
		gobjService = new frmServiceRoutines();
		try {
			gobjService.ShowDialog();
			gobjService.Close();
			gobjService.Dispose();
			gobjService = null;
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
			//If Not objWait Is Nothing Then
			//    objWait.Dispose()
			//End If
			//---------------------------------------------------------
		}
	}

	private void mnuChangePort_Click(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : mnuChangePort_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To select the Communication Port
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 30.11.06
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		frmCommPorts_Selection objfrmCommPorts_Selection = new frmCommPorts_Selection();
		bool blnFlag;
		try {
			//'--------------------------------------------
			//'Do While (True)
			//frmCommPorts_Selection.ShowDialog() '--- there is no com port available so select one from this 

			//' if comm port selection is cancelled
			//If gintCommPortSelected = 0 Then
			//    Exit Sub       '-- -End the Communication loop
			//Else

			//    If gobjCommdll.gFuncIsPortOpen() Then
			//        MsgBox("You have successfully selected the port.")
			//        '-- -End the Communication loopS
			//    End If

			//End If
			//frmCommPorts_Selection.Dispose()
			//'---------------------------------------------



			//lngtime1 = System.DateTime.Now.Ticks / 10000



			//Do While (True)  'Commented by Saurabh

			if (objfrmCommPorts_Selection.ShowDialog() == DialogResult.OK) {
				Application.DoEvents();
				if (gobjCommProtocol.mobjCommdll.gFuncIsPortOpen()) {
					gobjCommProtocol.mobjCommdll.gFuncCloseComm();
					//Me.SendToBack()
					//
					blnFlag = gobjCommProtocol.funcInitInstrument();
					Application.DoEvents();
					if (blnFlag == true) {
						if (objfrmAASInitialisation == null) {
							objfrmAASInitialisation = new frmAASInitialisation();
						}
						objfrmAASInitialisation.Show();
						objfrmAASInitialisation.BringToFront();
						if (gobjCommProtocol.mobjCommdll.gFuncIsPortOpen()) {
							gobjCommProtocol.mobjCommdll.gFuncCloseComm();
						}

						//If objfrmAASInitialisation Is Nothing Then
						//    objfrmAASInitialisation = New frmAASInitialisation
						//End If
						//Me.Hide()
						//objfrmAASInitialisation.Show()
						if (objfrmAASInitialisation.funcInstrumentInitialization()) {
							objfrmAASInitialisation.Close();
							objfrmAASInitialisation.Dispose();
						} else {
							objfrmAASInitialisation.Close();
							objfrmAASInitialisation.Dispose();
							//End
							this.Close();
							return;
						}
						//Me.Show()
					}

				} else {
					gobjMessageAdapter.ShowMessage(constComPortNotAvailable);
					Application.DoEvents();
				}
			}
			// objfrmCommPorts_Selection.ShowDialog()       '--- there is no com port available so select one from this 

			if (gintCommPortSelected == 0) {
				objfrmCommPorts_Selection.Close();
				objfrmCommPorts_Selection.Dispose();
				return;
				//-- -End the Communication loop
			}

			if (gobjCommdll.gFuncIsPortOpen() == true) {
			//GoTo AgnComm
			// communicate again with the instrument by sending reset command
			//gobjMessageAdapter.ShowMessage()
			//MsgBox("DONE")
			} else {
				gobjMessageAdapter.MessageTextAlignment = ContentAlignment.MiddleLeft;
				gobjMessageAdapter.ShowMessage(constCommError);
				Application.DoEvents();
			}


			//Loop       'Saurabh
			objfrmCommPorts_Selection.Close();
			objfrmCommPorts_Selection.Dispose();


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
			if (!(objfrmCommPorts_Selection == null)) {
				objfrmCommPorts_Selection = null;
			}
			if (!objWait == null) {
				objWait.Dispose();
			}
			//---------------------------------------------------------
		}
	}

	private void mnuAbout_Click(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : mnuAbout_Click
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
		frmAbout objfrmAbout = new frmAbout();
		try {
			objfrmAbout.ShowDialog();
			objfrmAbout.Close();
			objfrmAbout.Dispose();
			objfrmAbout = null;
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

	private void mnuTest_AAS203_Click(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : mnuTest_AAS203_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To show Command Test form.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 05.12.06
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		frmCommandTest objfrmCommandTest = new frmCommandTest();
		try {
			//MessageBox.Show("Work Under Progress")
			//Exit Sub
			objfrmCommandTest.ShowDialog();
			objfrmCommandTest.Close();
			objfrmCommandTest.Dispose();
			objfrmCommandTest = null;
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

	private void mnuInstSetup_TimeScan_Click(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : mnuInstSetup_TimeScan_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To load the Time scan form
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 25.09.06
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		object objfrmTimeScan;
		//frmTimeScanMode
		try {
			if ((gstructSettings.Enable21CFR == true)) {
				if (!funcCheckActivityAuthentication(enumActivityAuthentication.Energy_Spectrum_Mode, gstructUserDetails.Access)) {
					return;
				}
				gfuncInsertActivityLog(EnumModules.TimeScan, "TimeScan_Mode Accessed");
			}

			Application.DoEvents();

			gintSpectrumMode = modGlobalDeclarations.EnumSpectrumMode.TimeScan;
			if (gstructSettings.AppMode == EnumAppMode.FullVersion_203D) {
				//If gintInstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.SingleBeam Or _
				//            gintInstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.ReferenceBeam Then
				//    'objfrmTimeScan = New frmTimeScanMode
				//    objfrmTimeScan = New frmTimeScanDBMode
				//Else

				//    objfrmTimeScan = New frmTimeScanDBMode
				//End If
				//by Pankaj on 18.1.08 for beam type
				if (gintServiceBeamType == AAS203Library.Instrument.enumInstrumentBeamType.DoubleBeam) {
					objfrmTimeScan = new frmTimeScanDBMode();
				} else {
					objfrmTimeScan = new frmTimeScanMode();
				}
			} else {
				objfrmTimeScan = new frmTimeScanMode();
			}
			objfrmTimeScan.ShowDialog();
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
		frmUVScanningSpectrumMode objfrmUVSpectrumMode = new frmUVScanningSpectrumMode();
		frmUVScanningSpectrumDBMode objfrmUVSpectrumDBMode = new frmUVScanningSpectrumDBMode();
		//MessageBox.Show("Work Under Progress")
		//Exit Sub
		try {
			if (!gstructSettings.ExeToRun == EnumApplicationMode.ServiceUtility) {
				if ((gstructSettings.Enable21CFR == true)) {
					if (!funcCheckActivityAuthentication(enumActivityAuthentication.UV_Scanning_Spectrum_Mode, gstructUserDetails.Access)) {
						return;
						return;
					}
					gfuncInsertActivityLog(EnumModules.UV_Scanning_Spectrum_Mode, "UV_Scanning_Spectrum_Mode Accessed");
				}
			}

			gintSpectrumMode = modGlobalDeclarations.EnumSpectrumMode.UVSpetrum;
			if (gstructSettings.AppMode == EnumAppMode.FullVersion_203D) {
				//objfrmUVSpectrumDBMode = New frmUVScanningSpectrumDBMode
				//objfrmUVSpectrumDBMode.ShowDialog()
				//by Pankaj on 18.1.08 for beam type
				if (gintServiceBeamType == AAS203Library.Instrument.enumInstrumentBeamType.DoubleBeam) {
					objfrmUVSpectrumDBMode = new frmUVScanningSpectrumDBMode();
					objfrmUVSpectrumDBMode.ShowDialog();
				} else {
					objfrmUVSpectrumMode = new frmUVScanningSpectrumMode();
					objfrmUVSpectrumMode.ShowDialog();
				}
			} else {
				objfrmUVSpectrumMode = new frmUVScanningSpectrumMode();
				objfrmUVSpectrumMode.ShowDialog();
			}

			//objfrmUVSpectrumMode.ShowDialog()
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
			//---------------------------------------------------------
		}
	}

	private void mnuEnergySpectrum_Click(object sender, System.EventArgs e)
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
		CWaitCursor objWait = new CWaitCursor();
		frmEnergySpectrumMode objfrmEnergySpectrumMode;
		frmEnergySpectrumDBMode objfrmEnergySpectrumDBMode;
		//MessageBox.Show("Work Under Progress")
		//Exit Sub
		try {
			if (!gstructSettings.ExeToRun == EnumApplicationMode.ServiceUtility) {
				if ((gstructSettings.Enable21CFR == true)) {
					if (!funcCheckActivityAuthentication(enumActivityAuthentication.Energy_Spectrum_Mode, gstructUserDetails.Access)) {
						return;
					}
					gfuncInsertActivityLog(EnumModules.Energy_Spectrum_Mode, "Energy_Spectrum_Mode Accessed");
				}
			}

			gintSpectrumMode = modGlobalDeclarations.EnumSpectrumMode.EnergySpectrum;
			if (gstructSettings.AppMode == EnumAppMode.FullVersion_203D) {
				//by Pankaj on 18.1.08 for beam type
				if (gintServiceBeamType == AAS203Library.Instrument.enumInstrumentBeamType.DoubleBeam) {
					objfrmEnergySpectrumDBMode = new frmEnergySpectrumDBMode();
					objfrmEnergySpectrumDBMode.ShowDialog();
				} else {
					objfrmEnergySpectrumMode = new frmEnergySpectrumMode();
					objfrmEnergySpectrumMode.ShowDialog();
				}
			//objfrmEnergySpectrumDBMode = New frmEnergySpectrumDBMode
			//objfrmEnergySpectrumDBMode.ShowDialog()
			} else {
				objfrmEnergySpectrumMode = new frmEnergySpectrumMode();
				objfrmEnergySpectrumMode.ShowDialog();
			}

			//objfrmEnergySpectrumMode.ShowDialog()
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
			//---------------------------------------------------------
		}
	}

	private void btnAutoIgnition_Click(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : btnAutoIgnition_Click
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

			//If Not IsNothing(mobjfrmAnalysis) Then mobjfrmAnalysis.tmrAspirationMsg.Enabled = False
			// mobjController.Cancel()
			Application.DoEvents();

			gobjClsAAS203.funcIgnite(true);

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
			//If Not IsNothing(mobjfrmAnalysis) Then mobjfrmAnalysis.tmrAspirationMsg.Enabled = True
			//mobjController.Start(gobjclsBgFlameStatus)
			Application.DoEvents();
			//AddHandler mnuIgnite.Click, AddressOf btnAutoIgnition_Click
			//---------------------------------------------------------
		}
	}

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
	private void mnuSingleBeam_Click(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : mnuSingleBeam_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : beam type
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Pankaj Bamb
		// Created               : 18.01.08
		// Revisions             : 
		//=====================================================================

		mnuSingleBeam.Checked = true;
		mnuDoubleBeam.Checked = false;
		gintServiceBeamType = AAS203Library.Instrument.enumInstrumentBeamType.SingleBeam;
	}

	private void mnuDoubleBeam_Click(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : mnuDoubleBeam_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : beam type
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Pankaj Bamb
		// Created               : 18.01.08
		// Revisions             : 
		//=====================================================================

		mnuDoubleBeam.Checked = true;
		mnuSingleBeam.Checked = false;
		gintServiceBeamType = AAS203Library.Instrument.enumInstrumentBeamType.DoubleBeam;
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

	//Private Sub mnuService_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuService.Enter
	//    '=====================================================================
	//    ' Procedure Name        : mnuServiceUtility_Click
	//    ' Parameters Passed     : Object,EventArgs
	//    ' Returns               : None
	//    ' Purpose               : To load the Service Utility form
	//    ' Description           : 
	//    ' Assumptions           : 
	//    ' Dependencies          : 
	//    ' Author                : Saurabh S
	//    ' Created               : 25.09.06
	//    ' Revisions             : 
	//    '=====================================================================
	//    Dim objWait As New CWaitCursor
	//    Dim objfrmServiceRoutines As New frmServiceRoutines
	//    Try
	//        objfrmServiceRoutines.ShowDialog()
	//        Application.DoEvents()
	//        Me.Visible = True
	//        objWait = New CWaitCursor
	//        objfrmServiceRoutines.Close()
	//        objfrmServiceRoutines.Dispose()
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
	//        If Not objWait Is Nothing Then
	//            objWait.Dispose()
	//        End If
	//        '---------------------------------------------------------
	//    End Try
	//End Sub

	//Private Sub mnuAbout_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuAbout.Enter
	//    '=====================================================================
	//    ' Procedure Name        : mnuAbout_Click
	//    ' Parameters Passed     : Object,EventArgs
	//    ' Returns               : None
	//    ' Purpose               : To show About Us form.
	//    ' Description           : 
	//    ' Assumptions           : 
	//    ' Dependencies          : 
	//    ' Author                : Saurabh S
	//    ' Created               : 05.12.06
	//    ' Revisions             : 
	//    '=====================================================================
	//    Dim objWait As New CWaitCursor
	//    Dim objfrmAbout As New frmAbout
	//    Try
	//        objfrmAbout.ShowDialog()
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
	//        If Not objWait Is Nothing Then
	//            objWait.Dispose()
	//        End If
	//        '---------------------------------------------------------
	//    End Try
	//End Sub

	//Private Sub mnuExit_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuExit.Enter
	//    '=====================================================================
	//    ' Procedure Name        : mnuExit_Click
	//    ' Parameters Passed     : Object,EventArgs
	//    ' Returns               : None
	//    ' Purpose               : To exit from the software 
	//    ' Description           : 
	//    ' Assumptions           : 
	//    ' Dependencies          : 
	//    ' Author                : Saurabh S
	//    ' Created               : 25.09.06
	//    ' Revisions             : 
	//    '=====================================================================
	//    Dim objWait As New CWaitCursor
	//    Try
	//        Me.Close()

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

	//Private Sub mnuInstSetup_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuInstSetup.Enter
	//    '=====================================================================
	//    ' Procedure Name        : mnuInstSetup_TimeScan_Click
	//    ' Parameters Passed     : Object,EventArgs
	//    ' Returns               : None
	//    ' Purpose               : To load the Time scan form
	//    ' Description           : 
	//    ' Assumptions           : 
	//    ' Dependencies          : 
	//    ' Author                : Saurabh S
	//    ' Created               : 25.09.06
	//    ' Revisions             : 
	//    '=====================================================================
	//    Dim objfrmTimeScan As New frmTimeScanMode
	//    Dim objWait As New CWaitCursor
	//    Try
	//        If (gstructSettings.Enable21CFR = True) Then
	//            If Not funcCheckActivityAuthentication(enumActivityAuthentication.Energy_Spectrum_Mode, gstructUserDetails.Access) Then
	//                Exit Sub
	//            End If
	//            gfuncInsertActivityLog(EnumModules.TimeScan, "TimeScan_Mode Accessed")
	//        End If

	//        Application.DoEvents()
	//        gintSpectrumMode = modGlobalDeclarations.EnumSpectrumMode.TimeSacn
	//        objfrmTimeScan.ShowDialog()
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
	//        If Not objWait Is Nothing Then
	//            objWait.Dispose()
	//        End If
	//        '---------------------------------------------------------
	//    End Try
	//End Sub

	private void  // ERROR: Handles clauses are not supported in C#
frmMDIMainService_Closing(object sender, System.ComponentModel.CancelEventArgs e)
	{
		//gobjMain.mobjController.Start(gobjclsBgFlameStatus)
		//gobjfrmStatus.Visible = True
		//Application.DoEvents()
		if (!gobjclsTimer == null) {
			gobjclsTimer.subTimerStop();
		}
	}

	private void btnIgnite_Click(System.Object sender, System.EventArgs e)
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

	private void btnN2OIgnite_Click(System.Object sender, System.EventArgs e)
	{
		if (mblnAvoidProcessing == true) {
			return;
		}

		try {
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

	private void btnExtinguish_Click(System.Object sender, System.EventArgs e)
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
					funcAltDelete();
				case Keys.R:
					funcAltR();

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

			if (!gstructSettings.AppMode == EnumAppMode.DemoMode) {
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

			if (!gstructSettings.AppMode == EnumAppMode.DemoMode) {
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

			if (!gstructSettings.AppMode == EnumAppMode.DemoMode) {
				Application.DoEvents();
				gobjCommProtocol.mobjCommdll.subTime_Delay(100);
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

			Application.DoEvents();
			//AddHandler mnuIgnite.Click, AddressOf btnAutoIgnition_Click
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
			//RemoveHandler mnuIgnite.Click, AddressOf btnAutoIgnition_Click

			//If Not gstructSettings.AppMode = EnumAppMode.DemoMode Then
			if (!((gstructSettings.AppMode == EnumAppMode.DemoMode) | (gstructSettings.AppMode == EnumAppMode.DemoMode_201) | (gstructSettings.AppMode == EnumAppMode.DemoMode_203D))) {
				Application.DoEvents();
				gobjCommProtocol.mobjCommdll.subTime_Delay(50);
				gobjClsAAS203.ReInitInstParameters();
			} else {
				//Call gobjMessageAdapter.ShowMessage(constFlameIgnited)
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
			//If Not gstructSettings.AppMode = EnumAppMode.DemoMode Then
			if (!((gstructSettings.AppMode == EnumAppMode.DemoMode) | (gstructSettings.AppMode == EnumAppMode.DemoMode_201) | (gstructSettings.AppMode == EnumAppMode.DemoMode_203D))) {
				Application.DoEvents();
				gobjCommProtocol.mobjCommdll.subTime_Delay(50);
				gobjClsAAS203.funcInstReset();
			} else {
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
			Application.DoEvents();
			funcAltDelete();
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
			Application.DoEvents();
			//Alt - R
			funcAltR();
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

	private void Button1_Click(System.Object sender, System.EventArgs e)
	{
		MessageBox.Show(gobjInst.Mode.ToString);
	}
}
