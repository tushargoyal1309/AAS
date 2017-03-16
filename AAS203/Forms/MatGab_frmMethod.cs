using System.Threading;
using AAS203.Common;
using AAS203Library;
using AAS203Library.Method;
using AAS203Library.Instrument;

public class frmMethod : System.Windows.Forms.Form
{

	#Region " Windows Form Designer generated code "

	public frmMethod()
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
	internal GradientPanel.CustomPanel CustomPanelMethodMain;
	internal GradientPanel.CustomPanel CustomPanelLeft;
	internal CodeIntellects.Office2003Controls.Office2003Header HeaderRight;
	internal GradientPanel.CustomPanel CustomPanel1;
	internal System.Windows.Forms.Label lblMethodComments;
	internal System.Windows.Forms.Label lblMethodInformation;
	internal System.Windows.Forms.Label lblModeOfOperation;
	internal System.Windows.Forms.Label lblMethodName;
	internal CodeIntellects.Office2003Controls.Office2003Header HeaderLeft;
	internal System.Windows.Forms.ListBox lstMethodInformation;
	internal System.Windows.Forms.TextBox TxtModeOfOperation;
	internal System.Windows.Forms.TextBox TxtMethodName;
	internal System.Windows.Forms.TextBox TxtMethodComments;
	//Friend WithEvents mnuNewMethod As NETXP.Controls.Bars.CommandBarButtonItem
	//Friend WithEvents mnuLoadMethod As NETXP.Controls.Bars.CommandBarButtonItem
	//Friend WithEvents mnuInstrumentSettings As NETXP.Controls.Bars.CommandBarButtonItem
	//Friend WithEvents mnuInstrumentParameters As NETXP.Controls.Bars.CommandBarButtonItem
	//Friend WithEvents mnuStandardConcentrations As NETXP.Controls.Bars.CommandBarButtonItem
	//Friend WithEvents mnuSampleParameters As NETXP.Controls.Bars.CommandBarButtonItem
	//Friend WithEvents mnuReportOptions As NETXP.Controls.Bars.CommandBarButtonItem
	//Friend WithEvents mnuHelp As NETXP.Controls.Bars.CommandBarButtonItem
	internal UIComponents.XPPanelGroup XpPanelGroup1;
	internal NETXP.Controls.XPButton btnReportOptions;
	internal NETXP.Controls.XPButton btnLoadMethod;
	internal NETXP.Controls.XPButton btnInstrumentSettings;
	internal NETXP.Controls.XPButton btnInstrumentParameters;
	internal NETXP.Controls.XPButton btnStandardConcentrations;
	internal NETXP.Controls.XPButton btnSampleParameters;
	internal NETXP.Controls.XPButton btnNewMethod;
	//Friend WithEvents CommandBarButtonItem3 As NETXP.Controls.Bars.CommandBarButtonItem
	//Friend WithEvents CommandBarButtonItem4 As NETXP.Controls.Bars.CommandBarButtonItem
	internal NETXP.Controls.XPButton btnExtinguish;
	internal NETXP.Controls.XPButton btnIgnite;
	internal NETXP.Controls.XPButton btnN2OIgnite;
	internal System.Windows.Forms.Label l;
	internal NETXP.Controls.XPButton btnR;

	internal NETXP.Controls.XPButton btnDelete;
	[System.Diagnostics.DebuggerStepThrough()]
	private void InitializeComponent()
	{
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMethod));
		this.CustomPanelMethodMain = new GradientPanel.CustomPanel();
		this.HeaderRight = new CodeIntellects.Office2003Controls.Office2003Header();
		this.CustomPanel1 = new GradientPanel.CustomPanel();
		this.TxtMethodComments = new System.Windows.Forms.TextBox();
		this.TxtMethodName = new System.Windows.Forms.TextBox();
		this.lstMethodInformation = new System.Windows.Forms.ListBox();
		this.lblMethodComments = new System.Windows.Forms.Label();
		this.lblMethodInformation = new System.Windows.Forms.Label();
		this.lblModeOfOperation = new System.Windows.Forms.Label();
		this.TxtModeOfOperation = new System.Windows.Forms.TextBox();
		this.lblMethodName = new System.Windows.Forms.Label();
		this.CustomPanelLeft = new GradientPanel.CustomPanel();
		this.XpPanelGroup1 = new UIComponents.XPPanelGroup();
		this.l = new System.Windows.Forms.Label();
		this.btnSampleParameters = new NETXP.Controls.XPButton();
		this.btnReportOptions = new NETXP.Controls.XPButton();
		this.btnStandardConcentrations = new NETXP.Controls.XPButton();
		this.btnInstrumentParameters = new NETXP.Controls.XPButton();
		this.btnInstrumentSettings = new NETXP.Controls.XPButton();
		this.btnNewMethod = new NETXP.Controls.XPButton();
		this.btnLoadMethod = new NETXP.Controls.XPButton();
		this.btnIgnite = new NETXP.Controls.XPButton();
		this.btnN2OIgnite = new NETXP.Controls.XPButton();
		this.btnExtinguish = new NETXP.Controls.XPButton();
		this.btnDelete = new NETXP.Controls.XPButton();
		this.btnR = new NETXP.Controls.XPButton();
		this.HeaderLeft = new CodeIntellects.Office2003Controls.Office2003Header();
		this.CustomPanelMethodMain.SuspendLayout();
		this.HeaderRight.SuspendLayout();
		this.CustomPanel1.SuspendLayout();
		this.CustomPanelLeft.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.XpPanelGroup1).BeginInit();
		this.XpPanelGroup1.SuspendLayout();
		this.SuspendLayout();
		//
		//CustomPanelMethodMain
		//
		this.CustomPanelMethodMain.BackColor = System.Drawing.Color.AliceBlue;
		this.CustomPanelMethodMain.BackColor2 = System.Drawing.Color.AliceBlue;
		this.CustomPanelMethodMain.Controls.Add(this.HeaderRight);
		this.CustomPanelMethodMain.Controls.Add(this.CustomPanelLeft);
		this.CustomPanelMethodMain.Dock = System.Windows.Forms.DockStyle.Fill;
		this.CustomPanelMethodMain.Location = new System.Drawing.Point(0, 0);
		this.CustomPanelMethodMain.Name = "CustomPanelMethodMain";
		this.CustomPanelMethodMain.Size = new System.Drawing.Size(772, 569);
		this.CustomPanelMethodMain.TabIndex = 0;
		//
		//HeaderRight
		//
		this.HeaderRight.BackColor = System.Drawing.Color.Transparent;
		this.HeaderRight.Controls.Add(this.CustomPanel1);
		this.HeaderRight.Dock = System.Windows.Forms.DockStyle.Fill;
		this.HeaderRight.Location = new System.Drawing.Point(160, 0);
		this.HeaderRight.Name = "HeaderRight";
		this.HeaderRight.Size = new System.Drawing.Size(612, 569);
		this.HeaderRight.TabIndex = 5;
		this.HeaderRight.TitleFont = new System.Drawing.Font("Tahoma", 10f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.HeaderRight.TitleText = "Method";
		//
		//CustomPanel1
		//
		this.CustomPanel1.BackColor = System.Drawing.Color.AliceBlue;
		this.CustomPanel1.BackColor2 = System.Drawing.Color.Transparent;
		this.CustomPanel1.Controls.Add(this.TxtMethodComments);
		this.CustomPanel1.Controls.Add(this.TxtMethodName);
		this.CustomPanel1.Controls.Add(this.lstMethodInformation);
		this.CustomPanel1.Controls.Add(this.lblMethodComments);
		this.CustomPanel1.Controls.Add(this.lblMethodInformation);
		this.CustomPanel1.Controls.Add(this.lblModeOfOperation);
		this.CustomPanel1.Controls.Add(this.TxtModeOfOperation);
		this.CustomPanel1.Controls.Add(this.lblMethodName);
		this.CustomPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.CustomPanel1.Location = new System.Drawing.Point(0, 0);
		this.CustomPanel1.Name = "CustomPanel1";
		this.CustomPanel1.Size = new System.Drawing.Size(612, 569);
		this.CustomPanel1.TabIndex = 8;
		//
		//TxtMethodComments
		//
		this.TxtMethodComments.BackColor = System.Drawing.Color.White;
		this.TxtMethodComments.Enabled = false;
		this.TxtMethodComments.Location = new System.Drawing.Point(176, 284);
		this.TxtMethodComments.Multiline = true;
		this.TxtMethodComments.Name = "TxtMethodComments";
		this.TxtMethodComments.ReadOnly = true;
		this.TxtMethodComments.Size = new System.Drawing.Size(368, 82);
		this.TxtMethodComments.TabIndex = 3;
		this.TxtMethodComments.Text = "";
		//
		//TxtMethodName
		//
		this.TxtMethodName.BackColor = System.Drawing.Color.White;
		this.TxtMethodName.Enabled = false;
		this.TxtMethodName.Location = new System.Drawing.Point(176, 72);
		this.TxtMethodName.Name = "TxtMethodName";
		this.TxtMethodName.ReadOnly = true;
		this.TxtMethodName.Size = new System.Drawing.Size(368, 21);
		this.TxtMethodName.TabIndex = 0;
		this.TxtMethodName.Text = "";
		//
		//lstMethodInformation
		//
		this.lstMethodInformation.BackColor = System.Drawing.Color.White;
		this.lstMethodInformation.Enabled = false;
		this.lstMethodInformation.ItemHeight = 15;
		this.lstMethodInformation.Location = new System.Drawing.Point(176, 184);
		this.lstMethodInformation.Name = "lstMethodInformation";
		this.lstMethodInformation.Size = new System.Drawing.Size(368, 79);
		this.lstMethodInformation.TabIndex = 2;
		//
		//lblMethodComments
		//
		this.lblMethodComments.Location = new System.Drawing.Point(28, 285);
		this.lblMethodComments.Name = "lblMethodComments";
		this.lblMethodComments.Size = new System.Drawing.Size(132, 19);
		this.lblMethodComments.TabIndex = 23;
		this.lblMethodComments.Text = "Method Comments";
		//
		//lblMethodInformation
		//
		this.lblMethodInformation.Location = new System.Drawing.Point(28, 187);
		this.lblMethodInformation.Name = "lblMethodInformation";
		this.lblMethodInformation.Size = new System.Drawing.Size(132, 21);
		this.lblMethodInformation.TabIndex = 22;
		this.lblMethodInformation.Text = "Method Information";
		//
		//lblModeOfOperation
		//
		this.lblModeOfOperation.Location = new System.Drawing.Point(28, 132);
		this.lblModeOfOperation.Name = "lblModeOfOperation";
		this.lblModeOfOperation.Size = new System.Drawing.Size(124, 16);
		this.lblModeOfOperation.TabIndex = 21;
		this.lblModeOfOperation.Text = "Mode of Operation";
		//
		//TxtModeOfOperation
		//
		this.TxtModeOfOperation.BackColor = System.Drawing.Color.White;
		this.TxtModeOfOperation.Enabled = false;
		this.TxtModeOfOperation.Location = new System.Drawing.Point(176, 128);
		this.TxtModeOfOperation.Name = "TxtModeOfOperation";
		this.TxtModeOfOperation.ReadOnly = true;
		this.TxtModeOfOperation.Size = new System.Drawing.Size(368, 21);
		this.TxtModeOfOperation.TabIndex = 1;
		this.TxtModeOfOperation.Text = "";
		//
		//lblMethodName
		//
		this.lblMethodName.Location = new System.Drawing.Point(30, 73);
		this.lblMethodName.Name = "lblMethodName";
		this.lblMethodName.Size = new System.Drawing.Size(96, 24);
		this.lblMethodName.TabIndex = 20;
		this.lblMethodName.Text = "Method Name";
		//
		//CustomPanelLeft
		//
		this.CustomPanelLeft.BackColor = System.Drawing.Color.AliceBlue;
		this.CustomPanelLeft.BackColor2 = System.Drawing.Color.AliceBlue;
		this.CustomPanelLeft.Controls.Add(this.XpPanelGroup1);
		this.CustomPanelLeft.Controls.Add(this.HeaderLeft);
		this.CustomPanelLeft.Dock = System.Windows.Forms.DockStyle.Left;
		this.CustomPanelLeft.Location = new System.Drawing.Point(0, 0);
		this.CustomPanelLeft.Name = "CustomPanelLeft";
		this.CustomPanelLeft.Size = new System.Drawing.Size(160, 569);
		this.CustomPanelLeft.TabIndex = 2;
		//
		//XpPanelGroup1
		//
		this.XpPanelGroup1.AutoScroll = true;
		this.XpPanelGroup1.BackColor = System.Drawing.Color.Transparent;
		this.XpPanelGroup1.Controls.Add(this.l);
		this.XpPanelGroup1.Controls.Add(this.btnSampleParameters);
		this.XpPanelGroup1.Controls.Add(this.btnReportOptions);
		this.XpPanelGroup1.Controls.Add(this.btnStandardConcentrations);
		this.XpPanelGroup1.Controls.Add(this.btnInstrumentParameters);
		this.XpPanelGroup1.Controls.Add(this.btnInstrumentSettings);
		this.XpPanelGroup1.Controls.Add(this.btnNewMethod);
		this.XpPanelGroup1.Controls.Add(this.btnLoadMethod);
		this.XpPanelGroup1.Controls.Add(this.btnIgnite);
		this.XpPanelGroup1.Controls.Add(this.btnN2OIgnite);
		this.XpPanelGroup1.Controls.Add(this.btnExtinguish);
		this.XpPanelGroup1.Controls.Add(this.btnDelete);
		this.XpPanelGroup1.Controls.Add(this.btnR);
		this.XpPanelGroup1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.XpPanelGroup1.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.XpPanelGroup1.Location = new System.Drawing.Point(0, 22);
		this.XpPanelGroup1.Name = "XpPanelGroup1";
		this.XpPanelGroup1.PanelGradient = (UIComponents.GradientColor)resources.GetObject("XpPanelGroup1.PanelGradient");
		this.XpPanelGroup1.Size = new System.Drawing.Size(160, 547);
		this.XpPanelGroup1.TabIndex = 0;
		//
		//l
		//
		this.l.Location = new System.Drawing.Point(26, 418);
		this.l.Name = "l";
		this.l.Size = new System.Drawing.Size(128, 26);
		this.l.TabIndex = 7;
		//
		//btnSampleParameters
		//
		this.btnSampleParameters.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnSampleParameters.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnSampleParameters.Image = (System.Drawing.Image)resources.GetObject("btnSampleParameters.Image");
		this.btnSampleParameters.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnSampleParameters.Location = new System.Drawing.Point(20, 310);
		this.btnSampleParameters.Name = "btnSampleParameters";
		this.btnSampleParameters.Size = new System.Drawing.Size(120, 38);
		this.btnSampleParameters.TabIndex = 5;
		this.btnSampleParameters.Text = "Sam&ples";
		this.btnSampleParameters.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//btnReportOptions
		//
		this.btnReportOptions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnReportOptions.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnReportOptions.Image = (System.Drawing.Image)resources.GetObject("btnReportOptions.Image");
		this.btnReportOptions.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnReportOptions.Location = new System.Drawing.Point(20, 368);
		this.btnReportOptions.Name = "btnReportOptions";
		this.btnReportOptions.Size = new System.Drawing.Size(120, 38);
		this.btnReportOptions.TabIndex = 6;
		this.btnReportOptions.Text = "Report &Options";
		this.btnReportOptions.TextAlign = System.Drawing.ContentAlignment.TopLeft;
		//
		//btnStandardConcentrations
		//
		this.btnStandardConcentrations.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnStandardConcentrations.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnStandardConcentrations.Image = (System.Drawing.Image)resources.GetObject("btnStandardConcentrations.Image");
		this.btnStandardConcentrations.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnStandardConcentrations.Location = new System.Drawing.Point(20, 252);
		this.btnStandardConcentrations.Name = "btnStandardConcentrations";
		this.btnStandardConcentrations.Size = new System.Drawing.Size(120, 38);
		this.btnStandardConcentrations.TabIndex = 4;
		this.btnStandardConcentrations.Text = "Standard Concentration";
		this.btnStandardConcentrations.TextAlign = System.Drawing.ContentAlignment.TopLeft;
		//
		//btnInstrumentParameters
		//
		this.btnInstrumentParameters.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnInstrumentParameters.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnInstrumentParameters.Image = (System.Drawing.Image)resources.GetObject("btnInstrumentParameters.Image");
		this.btnInstrumentParameters.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnInstrumentParameters.Location = new System.Drawing.Point(20, 194);
		this.btnInstrumentParameters.Name = "btnInstrumentParameters";
		this.btnInstrumentParameters.Size = new System.Drawing.Size(120, 38);
		this.btnInstrumentParameters.TabIndex = 3;
		this.btnInstrumentParameters.Text = "&Parameters";
		//
		//btnInstrumentSettings
		//
		this.btnInstrumentSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnInstrumentSettings.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnInstrumentSettings.Image = (System.Drawing.Image)resources.GetObject("btnInstrumentSettings.Image");
		this.btnInstrumentSettings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnInstrumentSettings.Location = new System.Drawing.Point(20, 136);
		this.btnInstrumentSettings.Name = "btnInstrumentSettings";
		this.btnInstrumentSettings.Size = new System.Drawing.Size(120, 38);
		this.btnInstrumentSettings.TabIndex = 2;
		this.btnInstrumentSettings.Text = "Instrument";
		this.btnInstrumentSettings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//btnNewMethod
		//
		this.btnNewMethod.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnNewMethod.Image = (System.Drawing.Image)resources.GetObject("btnNewMethod.Image");
		this.btnNewMethod.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnNewMethod.Location = new System.Drawing.Point(20, 20);
		this.btnNewMethod.Name = "btnNewMethod";
		this.btnNewMethod.Size = new System.Drawing.Size(120, 38);
		this.btnNewMethod.TabIndex = 0;
		this.btnNewMethod.Text = "&New Method";
		//
		//btnLoadMethod
		//
		this.btnLoadMethod.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnLoadMethod.Image = (System.Drawing.Image)resources.GetObject("btnLoadMethod.Image");
		this.btnLoadMethod.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnLoadMethod.Location = new System.Drawing.Point(20, 78);
		this.btnLoadMethod.Name = "btnLoadMethod";
		this.btnLoadMethod.Size = new System.Drawing.Size(120, 38);
		this.btnLoadMethod.TabIndex = 1;
		this.btnLoadMethod.Text = "&Load Method";
		//
		//btnIgnite
		//
		this.btnIgnite.BackColor = System.Drawing.Color.RoyalBlue;
		this.btnIgnite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnIgnite.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnIgnite.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnIgnite.Location = new System.Drawing.Point(76, 424);
		this.btnIgnite.Name = "btnIgnite";
		this.btnIgnite.Size = new System.Drawing.Size(8, 8);
		this.btnIgnite.TabIndex = 12;
		this.btnIgnite.TabStop = false;
		this.btnIgnite.Text = "&Ignition";
		this.btnIgnite.TextAlign = System.Drawing.ContentAlignment.TopLeft;
		//
		//btnN2OIgnite
		//
		this.btnN2OIgnite.BackColor = System.Drawing.Color.RoyalBlue;
		this.btnN2OIgnite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnN2OIgnite.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnN2OIgnite.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnN2OIgnite.Location = new System.Drawing.Point(92, 424);
		this.btnN2OIgnite.Name = "btnN2OIgnite";
		this.btnN2OIgnite.Size = new System.Drawing.Size(8, 8);
		this.btnN2OIgnite.TabIndex = 19;
		this.btnN2OIgnite.TabStop = false;
		this.btnN2OIgnite.Text = "N2O&C";
		this.btnN2OIgnite.TextAlign = System.Drawing.ContentAlignment.TopLeft;
		//
		//btnExtinguish
		//
		this.btnExtinguish.BackColor = System.Drawing.Color.RoyalBlue;
		this.btnExtinguish.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnExtinguish.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnExtinguish.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnExtinguish.Location = new System.Drawing.Point(60, 424);
		this.btnExtinguish.Name = "btnExtinguish";
		this.btnExtinguish.Size = new System.Drawing.Size(8, 8);
		this.btnExtinguish.TabIndex = 13;
		this.btnExtinguish.TabStop = false;
		this.btnExtinguish.Text = "&Extinguish";
		this.btnExtinguish.TextAlign = System.Drawing.ContentAlignment.TopLeft;
		//
		//btnDelete
		//
		this.btnDelete.BackColor = System.Drawing.Color.RoyalBlue;
		this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnDelete.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnDelete.Location = new System.Drawing.Point(102, 424);
		this.btnDelete.Name = "btnDelete";
		this.btnDelete.Size = new System.Drawing.Size(8, 8);
		this.btnDelete.TabIndex = 22;
		this.btnDelete.TabStop = false;
		this.btnDelete.Text = "&Delete";
		this.btnDelete.TextAlign = System.Drawing.ContentAlignment.TopLeft;
		//
		//btnR
		//
		this.btnR.BackColor = System.Drawing.Color.RoyalBlue;
		this.btnR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnR.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnR.Location = new System.Drawing.Point(114, 424);
		this.btnR.Name = "btnR";
		this.btnR.Size = new System.Drawing.Size(8, 8);
		this.btnR.TabIndex = 21;
		this.btnR.TabStop = false;
		this.btnR.Text = "&R";
		this.btnR.TextAlign = System.Drawing.ContentAlignment.TopLeft;
		//
		//HeaderLeft
		//
		this.HeaderLeft.BackColor = System.Drawing.SystemColors.Control;
		this.HeaderLeft.Dock = System.Windows.Forms.DockStyle.Top;
		this.HeaderLeft.Location = new System.Drawing.Point(0, 0);
		this.HeaderLeft.Name = "HeaderLeft";
		this.HeaderLeft.Size = new System.Drawing.Size(160, 22);
		this.HeaderLeft.TabIndex = 11;
		this.HeaderLeft.TitleFont = new System.Drawing.Font("Tahoma", 10f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.HeaderLeft.TitleText = "Method Parameters";
		//
		//frmMethod
		//
		this.AutoScale = false;
		this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
		this.CausesValidation = false;
		this.ClientSize = new System.Drawing.Size(772, 569);
		this.Controls.Add(this.CustomPanelMethodMain);
		this.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		this.Name = "frmMethod";
		this.Text = "Method";
		this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
		this.CustomPanelMethodMain.ResumeLayout(false);
		this.HeaderRight.ResumeLayout(false);
		this.CustomPanel1.ResumeLayout(false);
		this.CustomPanelLeft.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.XpPanelGroup1).EndInit();
		this.XpPanelGroup1.ResumeLayout(false);
		this.ResumeLayout(false);

	}

	#End Region

	#Region " Private Class Member Variables "

	private frmLoadMethod mobjfrmLoadMethod = new frmLoadMethod();

	private int mintMethodMode = 0;
	public event  LoadedMethodChanged;
	private AAS203Library.Method.clsAnalysisSampleParametersCollection mobjPreviousSampParameter;
		#End Region
	private bool mblnAvoidProcessing = false;

	#Region " Private Constants "

	private const  ConstCreatedBy = "Created By  ";
	private const  ConstCreatedOn = "Created On  ";
	private const  ConstStatus = "Status      ";
	private const  ConstChangedOn = "Changed On  ";
	private const  ConstLastUsedOn = "Last Used On";
	private const  ConstActive = "Active";
	private const  ConstNotActive = "Inactive (Method parameters are incomplete)";

	private const  ConstFormLoad = "-Method";
	#End Region

	#Region " Private Properties "

	private EnumMethodMode OpenMethodMode {
		get { return mintMethodMode; }
		set { mintMethodMode = Value; }
	}

	#End Region

	#Region " Form Events "

	private void  // ERROR: Handles clauses are not supported in C#
frmMethod_Load(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : frmMethod_Load
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To load the form
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh
		// Created               : 06.10.06
		// Revisions             : Deepak B. on 11.01.07 added code for default method
		//=====================================================================
		//'note:
		//'this is called when form is loaded
		//'do some initialization here'
		//'for eg add all the event to form.
		CWaitCursor objWait = new CWaitCursor();
		int intCount;
		try {
			//Saurabh
			if (gstructSettings.AppMode == EnumAppMode.FullVersion_201) {
				//'for 201
				btnIgnite.Enabled = false;
				btnExtinguish.Enabled = false;
			}

			btnNewMethod.BringToFront();
			btnLoadMethod.BringToFront();
			btnNewMethod.Focus();
			//Saurabh

			this.FormBorderStyle = FormBorderStyle.FixedSingle;
			AddHandlers();
			//'for adding a event
			btnInstrumentSettings.Enabled = false;
			btnInstrumentParameters.Enabled = false;
			btnStandardConcentrations.Enabled = false;
			btnSampleParameters.Enabled = false;
			btnReportOptions.Enabled = false;

			if (gIntMethodID != 0) {
				for (intCount = 0; intCount <= gobjMethodCollection.Count - 1; intCount++) {
					if (gobjMethodCollection.item(intCount).MethodID == gIntMethodID) {
						gobjNewMethod = gobjMethodCollection.item(intCount);
						break; // TODO: might not be correct. Was : Exit For
					}
				}
				mobjfrmLoadMethod_LoadMethod(gobjNewMethod);
				//'To display general information of load method event of frmLoadMethod form

			}

			//Saurabh 10.07.07 To bring status form in front
			gobjfrmStatus.Show();
		//'for statusn form.
		//Saurabh

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
frmMethod_Closing(object sender, System.ComponentModel.CancelEventArgs e)
	{
		//=====================================================================
		// Procedure Name        : frmMethod_Closing
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : this is called for closing a form.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh
		// Created               : 06.10.06
		// Revisions             : Deepak B. on 11.01.07 added code for default method
		//=====================================================================
		mobjfrmLoadMethod.Close();
		mobjfrmLoadMethod.Dispose();
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
			mobjfrmLoadMethod.LoadMethod += mobjfrmLoadMethod_LoadMethod;
			//'this will add a event to a control
			btnReportOptions.Click += tlbbtnReportOptions_Click;
			btnInstrumentSettings.Click += tlbbtnInstrumentParameters_Click;
			btnInstrumentParameters.Click += tlbbtnAnalysisParameters_Click;
			btnStandardConcentrations.Click += tlbbtnStdConcentration_Click;
			btnSampleParameters.Click += tlbbtnSampParameters_Click;
			btnNewMethod.Click += tlbbtnNewMethod_Click;
			btnLoadMethod.Click += tlbbtnLoadMethod_Click;

			btnIgnite.Click += btnIgnite_Click;
			btnExtinguish.Click += btnExtinguish_Click;
			btnN2OIgnite.Click += btnN2OIgnite_Click;
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

	private void tlbbtnBack_Click(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : tlbbtnBack_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To exit frmMethod and load frmMDIMain form
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 25.09.06
		// Revisions             : 
		//=====================================================================
		//'note;
		//'this is called when user click on back button.
		//'To exit frmMethod and load frmMDIMain form
		CWaitCursor objWait = new CWaitCursor();
		try {
			gobjMain.ShowProgressBar(gstrTitleInstrumentType + ConstFormLoad);
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
			gobjMain.HideProgressBar();
			//---------------------------------------------------------
		}
	}

	private void tlbbtnNewMethod_Click(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : tlbbtnNewMethod_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To create new method
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : 05.10.06
		// Revisions             : 
		//=====================================================================
		//note:
		//'this is called when user clicked on new method button.
		//'this will start a routine for new method creation.
		frmNewMethod objfrmNewMethod = new frmNewMethod();
		frmInstrumentParameters objfrmInstrParameters;
		frmMethodAnalysisParameters objfrmAnalysisParameters;
		frmStandardConcentration objfrmStdParameters;
		frmSampleParameters objfrmSampleParameters;
		frmReportOptions objfrmReportOptions;
		frmUVQuantitativeAnalysis objfrmUVQuantitativeAnalysis;
		frmEmissionMode objfrmEmissionMode;
		CWaitCursor objWait = new CWaitCursor();
		if (mblnAvoidProcessing == true) {
			return;
		}
		mblnAvoidProcessing = true;
		try {
			//------Added By Pankaj Thu 24 May 07
			gobjchkActiveMethod.NewMethod = false;
			gobjchkActiveMethod.CancelMethod = false;
			//gobjchkActiveMethod.fillInstruments = False '27.07.07
			gobjchkActiveMethod.fillParameters = false;
			gobjchkActiveMethod.fillStdConcentration = false;
			//gobjchkActiveMethod.DisconnectedModeMethod = False

			//------Added By Pankaj Fri 18 May 07
			if ((gstructSettings.Enable21CFR == true)) {
				if (!funcCheckActivityAuthentication(enumActivityAuthentication.Method, gstructUserDetails.Access)) {
					//'check for user authentication.
					mblnAvoidProcessing = false;
					return;
					return;
				}
				gfuncInsertActivityLog(EnumModules.Method, "Method Accessed");
			}
			//--------
			gobjMain.ShowRunTimeInfo(gstrTitleInstrumentType + ConstFormLoad);
			//tlbbtnNewMethod.SuspendEvents()
			if (!gobjNewMethod == null) {
				mobjPreviousSampParameter = gobjNewMethod.SampleDataCollection;
			}

			Application.DoEvents();
			//'allow application to perfrom its panding work.

			if (objfrmNewMethod.ShowDialog() == DialogResult.OK) {
				//'this will show a new method form.
				Application.DoEvents();
				gobjchkActiveMethod.NewMethod = true;
				//Added Pankaj 23 May 07
				gobjNewMethod.Status = false;
				gobjchkActiveMethod.IsMethodAddedToCollectionInDisconnectedMode = false;
				OpenMethodMode = modGlobalConstants.EnumMethodMode.NewMode;

				btnInstrumentSettings.Enabled = true;
				btnInstrumentParameters.Enabled = true;
				btnStandardConcentrations.Enabled = true;
				btnSampleParameters.Enabled = true;
				btnReportOptions.Enabled = true;

				if (!gobjNewMethod == null) {
					if (funcShowMethodGeneralInfo(gobjNewMethod) == true) {
						//'show a method general info 
						if (OpenMethodMode == EnumMethodMode.NewMode) {
							//'check either it is new method or method for edit
							//'check a flag for it
							//'
							//---Enum Values Changed and Added by Mangesh on 23-Jan-2007
							switch (gobjNewMethod.OperationMode) {
								//'check ofr method s operation mode.
								case EnumOperationMode.MODE_AA:
								case EnumOperationMode.MODE_AABGC:
									//1, 3
									objfrmInstrParameters = new frmInstrumentParameters(OpenMethodMode);
									//'creat a object for instrument parameter
									Application.DoEvents();
									if (objfrmInstrParameters.ShowDialog() == DialogResult.OK) {
									//'show a form of instrument parameter.
									//---do nothing & move forward to create new method
									} else {
										gobjNewMethod.Status = false;
										//Added By Pankaj Thu 24 May 07
										funcShowMethodGeneralInfo(gobjNewMethod);
										//gobjchkActiveMethod.DisconnectedModeMethod = True
										mblnAvoidProcessing = false;
										return;
									}
									Application.DoEvents();
								case EnumOperationMode.MODE_UVABS:
									//2
									objfrmUVQuantitativeAnalysis = new frmUVQuantitativeAnalysis(OpenMethodMode);
									Application.DoEvents();

									if (objfrmUVQuantitativeAnalysis.ShowDialog() == DialogResult.OK) {
									//---do nothing & move forward to create new method
									} else {
										gobjNewMethod.Status = false;
										//Added By Pankaj Thu 24 May 07
										funcShowMethodGeneralInfo(gobjNewMethod);
										//'for showing method info.
										//gobjchkActiveMethod.DisconnectedModeMethod = True
										mblnAvoidProcessing = false;
										return;
									}
									Application.DoEvents();
								case EnumOperationMode.MODE_EMMISSION:
									//4
									objfrmEmissionMode = new frmEmissionMode(OpenMethodMode);
									Application.DoEvents();
									if (objfrmEmissionMode.ShowDialog() == DialogResult.OK) {
									//'show the emission mode instrument parameter screen.
									//---do nothing & move forward to create new method
									} else {
										//Added By Pankaj Thu 24 May 07
										gobjNewMethod.Status = false;
										funcShowMethodGeneralInfo(gobjNewMethod);
										//gobjchkActiveMethod.DisconnectedModeMethod = True
										mblnAvoidProcessing = false;
										return;
									}
									Application.DoEvents();
								//'allow application to perfrom its panding work.
							}

							objfrmAnalysisParameters = new frmMethodAnalysisParameters(OpenMethodMode);
							//'creat a object of analysis form.
							Application.DoEvents();
							objfrmAnalysisParameters.nudNumofSamples.Value = 25;
							//Added by Saurabh 22.07.07

							if (objfrmAnalysisParameters.ShowDialog() == DialogResult.OK) {
								//'show the analysis dialog.
								Application.DoEvents();
								objfrmStdParameters = new frmStandardConcentration();
								//'creat a object for std parameter
								Application.DoEvents();
								if (objfrmStdParameters.ShowDialog() == DialogResult.OK) {
									//'show a std parameter form.
									Application.DoEvents();
									//'allow application to perfrom it panding work.
									gobjNewMethod.Status = true;
									//Added By Pankaj 23 May 07 
									funcShowMethodGeneralInfo(gobjNewMethod);
									//objfrmSampleParameters = New frmSampleParameters(EnumMethodMode.NewMode, mobjPreviousSampParameter)
									objfrmSampleParameters = new frmSampleParameters(EnumMethodMode.NewMode);

									if (objfrmSampleParameters.ShowDialog() == DialogResult.OK) {
										Application.DoEvents();
										//'show the sampler parameter form.
										objfrmReportOptions = new frmReportOptions(EnumMethodMode.NewMode, false, 0, 0);

										if (objfrmReportOptions.ShowDialog() == DialogResult.OK) {
											//'show the report option dialog.
											Application.DoEvents();
										}
										//By pankaj for showing analysis message without report option ok on 17 Aug 07


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
										gobjchkActiveMethod.fillParameters = false;
										gobjchkActiveMethod.fillStdConcentration = false;
										gobjchkActiveMethod.IsMethodAddedToCollectionInDisconnectedMode = false;
										//gobjchkActiveMethod.DisconnectedModeMethod = False   '27.07.07
										gobjMethodCollection.Add(gobjNewMethod);

										//'---serialize method collection 
										//Call funcSerialize(ConstMethodsFileName, gobjMethodCollection)
										funcSaveAllMethods(gobjMethodCollection);

										//'for saveing a method to the data structure.




										//----Added by Mangesh on 04-Apr-2007

										OpenMethodMode = modGlobalConstants.EnumMethodMode.EditMode;


										//---display confirmation dialog box of method creation
										gobjMessageAdapter.ShowMessage(contMethodCreatedSuccessfully);
										Application.DoEvents();
										//'allow application to perfrom its panding work.
										gIntMethodID = gobjNewMethod.MethodID;
										//'get a method id.
										//---Added by Mangesh on 24-Apr-2007
										if (LoadedMethodChanged != null) {
											LoadedMethodChanged();
										}

										//'this is  a event.

										//---START --- Added by Mangesh on 27-Feb-2007

										if (gobjMessageAdapter.ShowMessage(constContinueAnalysis) == true) {
											//'ask user for analysis or not'
											//'prompt a message.
											Application.DoEvents();
											//---Open Analysis Form 
											//------Added By Pankaj Fri 18 May 07
											if ((gstructSettings.Enable21CFR == true)) {
												if (!funcCheckActivityAuthentication(enumActivityAuthentication.Analysis, gstructUserDetails.Access)) {
													mblnAvoidProcessing = false;
													return;
													return;
												}
												gfuncInsertActivityLog(EnumModules.Analysis, "Analysis Accessed");
											}
											//--------
											gobjMain.OnQuantAnalyse();
										}
										Application.DoEvents();

									//---END  ---  Added by Mangesh on 27-Feb-2007

									//Comment By pankaj for showing analysis message without report option ok on 17 Aug 07
									//Else
									//    'gobjNewMethod.Status = True
									//    Call saveMethod("CancelReport")
									//    'funcShowMethodGeneralInfo(gobjNewMethod)
									//End If
									//End
									} else {
										//gobjNewMethod.Status = True
										saveMethod("CancelSampleParameter");
										//funcShowMethodGeneralInfo(gobjNewMethod)
									}
								} else {
									gobjNewMethod.Status = false;
									funcShowMethodGeneralInfo(gobjNewMethod);
								}
							} else {
								gobjNewMethod.Status = false;
								funcShowMethodGeneralInfo(gobjNewMethod);
							}
						} else {
							gobjNewMethod.Status = false;
							funcShowMethodGeneralInfo(gobjNewMethod);
						}
					}
				}
			}
			mblnAvoidProcessing = false;
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			mblnAvoidProcessing = false;
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
			gobjfrmStatus.TopMost = true;
			//---------------------------------------------------------
		}
	}

	private void saveMethod(string strModuleName)
	{
		//=====================================================================
		// Procedure Name        : saveMethod
		// Parameters Passed     : 
		// Returns               : None
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Pankaj Bamb
		// Created               : 29.05.07
		// Revisions             : 
		//=====================================================================
		//'note:
		//'this is called for saving a method
		try {
			gobjchkActiveMethod.NewMethod = false;
			gobjchkActiveMethod.CancelMethod = false;
			//gobjchkActiveMethod.fillInstruments = False
			gobjchkActiveMethod.fillParameters = false;
			gobjchkActiveMethod.fillStdConcentration = false;
			gobjNewMethod.Status = true;
			//'do some onscreen validation 

			if ((strModuleName == "CancelSampleParameter")) {
				frmMethodAnalysisParameters objMethodAnalysis = new frmMethodAnalysisParameters(OpenMethodMode);
				int intUnitID;
				int intNoOfSamples;
				intUnitID = gobjNewMethod.AnalysisParameters.Unit;
				intNoOfSamples = gobjNewMethod.AnalysisParameters.NumOfSamples();
				objMethodAnalysis.updateSampleParameter(intNoOfSamples, intUnitID);
			}

			gobjMethodCollection.Add(gobjNewMethod);
			//'add to method data structure
			funcSaveAllMethods(gobjMethodCollection);
			//'save all method to collection 
			Application.DoEvents();
			//'allow application to nperfrom its panding work.
			gIntMethodID = gobjNewMethod.MethodID;
			if (LoadedMethodChanged != null) {
				LoadedMethodChanged();
			}
			funcShowMethodGeneralInfo(gobjNewMethod);
		//'show a info of method which is just saved.
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

			//tlbbtnNewMethod.ResumeEvents()
			gobjfrmStatus.TopMost = true;
			//---------------------------------------------------------
		}
	}

	private void tlbbtnLoadMethod_Click(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : tlbbtnLoadMethod_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To load the frmLoadMethod form
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : 05.10.06
		// Revisions             : Sachin Dokhale on 09.12.06
		//=====================================================================
		//'note:
		//'this is a event which called when user click on load method button
		//'this will show a load method form.
		CWaitCursor objWait = new CWaitCursor();
		if (mblnAvoidProcessing == true) {
			//'for avoiding a process
			return;
		}
		mblnAvoidProcessing = true;
		try {
			//------Added By Pankaj Fri 18 May 07
			if ((gstructSettings.Enable21CFR == true)) {
				if (!funcCheckActivityAuthentication(enumActivityAuthentication.Method, gstructUserDetails.Access)) {
					//'check for user authentication
					mblnAvoidProcessing = false;
					return;
					return;
				}
				gfuncInsertActivityLog(EnumModules.Method, "Method Accessed");
			}
			//--------


			gobjMain.ShowRunTimeInfo(gstrTitleInstrumentType + ConstFormLoad);
			if (!gobjNewMethod == null) {
				mobjPreviousSampParameter = gobjNewMethod.SampleDataCollection;
			}

			mobjfrmLoadMethod.ShowDialog();
			//'show a load method form.
			mblnAvoidProcessing = false;
			Application.DoEvents();
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
			if (!objWait == null) {
				objWait.Dispose();
			}
			//---------------------------------------------------------
		}
	}

	private void tlbbtnInstrumentParameters_Click(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : tlbbtnInstrumentParameters_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To load the Instrument Parameters form
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 25.09.06
		// Revisions             : 
		//=====================================================================
		//'note:
		//'this is called when user clicked on instrument parameter button.
		//'this will show a instrument parameter form.
		CWaitCursor objWait = new CWaitCursor();
		frmInstrumentParameters objfrmInstrumentParameters;
		frmUVQuantitativeAnalysis objfrmUVQuantitativeAnalysis;
		frmEmissionMode objfrmEmissionMode;
		frmD2PeakSearch objfrmD2PeakSearch;
		if (mblnAvoidProcessing == true) {
			return;
		}
		mblnAvoidProcessing = true;
		try {
			gobjMain.ShowRunTimeInfo(gstrTitleInstrumentType + ConstFormLoad);
			//tlbbtnInstrumentParameters.SuspendEvents()

			//gobjMain.mobjController.Cancel()   'Commented by Saurabh
			//Application.DoEvents()

			//If Not IsNothing(gobjMain.mobjfrmAnalysis) Then gobjMain.mobjfrmAnalysis.tmrAspirationMsg.Enabled = False

			Application.DoEvents();

			if (gobjNewMethod.OperationMode == EnumOperationMode.MODE_AA | gobjNewMethod.OperationMode == EnumOperationMode.MODE_AABGC) {
				//'check for mode
				objfrmInstrumentParameters = new frmInstrumentParameters(OpenMethodMode);
				objfrmInstrumentParameters.MethodInstrumentSettingsChanged += objfrmInstrumentParameters_MethodInstrumentSettingsChanged;
				objfrmInstrumentParameters.ShowDialog();
				//'show instrument parameter form.
				Application.DoEvents();
				funcShowMethodGeneralInfo(gobjNewMethod);
				//'show method info.
				objfrmInstrumentParameters.Close();
				objfrmInstrumentParameters.Dispose();
				objfrmInstrumentParameters = null;

			//TxtModeOfOperation.Text = "UV ABS Quantitative Mode" Then
			} else if (gobjNewMethod.OperationMode == EnumOperationMode.MODE_UVABS) {
				//'do for UV mode
				objfrmUVQuantitativeAnalysis = new frmUVQuantitativeAnalysis(OpenMethodMode);
				objfrmUVQuantitativeAnalysis.ShowDialog();
				Application.DoEvents();
				objfrmUVQuantitativeAnalysis.Close();
				objfrmUVQuantitativeAnalysis.Dispose();
				objfrmUVQuantitativeAnalysis = null;

			//ElseIf TxtModeOfOperation.Text = "Emission Quantitative Mode" Then
			} else if (gobjNewMethod.OperationMode == EnumOperationMode.MODE_EMMISSION) {
				//'do for emission mode
				objfrmEmissionMode = new frmEmissionMode(OpenMethodMode);
				objfrmEmissionMode.ShowDialog();
				Application.DoEvents();
				objfrmEmissionMode.Close();
				objfrmEmissionMode.Dispose();
				objfrmEmissionMode = null;

			}

			//gobjMain.mobjController.Start(gobjclsBgFlameStatus)    'Commented by Saurabh
			//Application.DoEvents()
			//If Not IsNothing(gobjMain.mobjfrmAnalysis) Then gobjMain.mobjfrmAnalysis.tmrAspirationMsg.Enabled = True

			Application.DoEvents();
			funcShowMethodGeneralInfo(gobjNewMethod);
			//Added by Pankaj on 31 May 07
			mblnAvoidProcessing = false;
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			mblnAvoidProcessing = false;
		//--------------------------------------- ------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			objWait.Dispose();



			//tlbbtnInstrumentParameters.ResumeEvents()
			//---------------------------------------------------------
		}

	}

	//Private Sub tlbbtnAnalysisParameters_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
	//    '=====================================================================
	//    ' Procedure Name        : tlbbtnAnalysisParameters_Click
	//    ' Parameters Passed     : Object,EventArgs
	//    ' Returns               : None
	//    ' Purpose               : To load the frmAnalysisParameters form
	//    ' Description           : 
	//    ' Assumptions           : 
	//    ' Dependencies          : 
	//    ' Author                : Saurabh S
	//    ' Created               : 25.09.06
	//    ' Revisions             : 
	//    '=====================================================================
	//    If gobjchkActiveMethod.fillParameters = True And OpenMethodMode = modGlobalConstants.EnumMethodMode.NewMode Then                   'Added By Pankaj on 26 May 07
	//        OpenMethodMode = modGlobalConstants.EnumMethodMode.EditMode    'Added By Pankaj on 26 May 07
	//    ElseIf gobjchkActiveMethod.NewMethod = False And OpenMethodMode = modGlobalConstants.EnumMethodMode.NewMode Then                  'Added By Pankaj on 26 May 07
	//        OpenMethodMode = modGlobalConstants.EnumMethodMode.EditMode   'Added By Pankaj on 26 May 07
	//    End If   '27.07.07

	//    Dim objfrmMethodAnalysisParameters As New frmMethodAnalysisParameters(OpenMethodMode)
	//    Dim objWait As New CWaitCursor
	//    Try
	//        gobjMain.ShowRunTimeInfo(ConstFormLoad)
	//        objfrmMethodAnalysisParameters.ShowDialog()
	//        funcShowMethodGeneralInfo(gobjNewMethod)
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

	private void tlbbtnAnalysisParameters_Click(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : tlbbtnAnalysisParameters_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To load the frmAnalysisParameters form
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 25.09.06
		// Revisions             : 
		//=====================================================================
		//If gobjchkActiveMethod.fillParameters = True And OpenMethodMode = modGlobalConstants.EnumMethodMode.NewMode Then                   'Added By Pankaj on 26 May 07
		//    OpenMethodMode = modGlobalConstants.EnumMethodMode.EditMode    'Added By Pankaj on 26 May 07
		//ElseIf gobjchkActiveMethod.NewMethod = False And OpenMethodMode = modGlobalConstants.EnumMethodMode.NewMode Then                  'Added By Pankaj on 26 May 07
		//    OpenMethodMode = modGlobalConstants.EnumMethodMode.EditMode   'Added By Pankaj on 26 May 07
		//End If   '27.07.07

		frmMethodAnalysisParameters objfrmMethodAnalysisParameters = new frmMethodAnalysisParameters(OpenMethodMode);
		CWaitCursor objWait = new CWaitCursor();
		if (mblnAvoidProcessing == true) {
			return;
		}
		mblnAvoidProcessing = true;
		try {
			gobjMain.ShowRunTimeInfo(gstrTitleInstrumentType + ConstFormLoad);
			objfrmMethodAnalysisParameters.ShowDialog();
			Application.DoEvents();
			funcShowMethodGeneralInfo(gobjNewMethod);
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
			if (!objWait == null) {
				objWait.Dispose();
			}
			//---------------------------------------------------------
		}
	}


	private void tlbbtnStdConcentration_Click(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : tlbbtnStdConcentration_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To load the frmStdConcentration form
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 25.09.06
		// Revisions             : 
		//=====================================================================
		frmStandardConcentration objfrmStandardConcentration;
		if (mblnAvoidProcessing == true) {
			return;
		}
		mblnAvoidProcessing = true;
		try {
			gobjMain.ShowRunTimeInfo(gstrTitleInstrumentType + ConstFormLoad);
			//tlbbtnStandardConcentrations.SuspendEvents()

			objfrmStandardConcentration = new frmStandardConcentration();
			objfrmStandardConcentration.ShowDialog();
			Application.DoEvents();
			objfrmStandardConcentration.Close();
			objfrmStandardConcentration.Dispose();
			objfrmStandardConcentration = null;
			funcShowMethodGeneralInfo(gobjNewMethod);
			//Added By Pankaj23 May 07
			//            gobjMethodCollection = gobjNewMethod
			//Call gobjMethodCollection.Add(gobjNewMethod) 'comment by pankaj 25 MAy 07
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
			//tlbbtnStandardConcentrations.ResumeEvents()
			//---------------------------------------------------------
		}
	}

	private void tlbbtnSampParameters_Click(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : tlbbtnSampParameters_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To load the frmSampParameters form
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 25.09.06
		// Revisions             : 
		//=====================================================================
		//'note;
		//'this is called when user clicked on sample parameter button
		//'to load sampler parameter form.
		frmSampleParameters objfrmSampleParameters;
		if (mblnAvoidProcessing == true) {
			return;
		}
		mblnAvoidProcessing = true;
		try {
			gobjMain.ShowRunTimeInfo(gstrTitleInstrumentType + ConstFormLoad);
			//tlbbtnSampleParameters.SuspendEvents()

			objfrmSampleParameters = new frmSampleParameters(0, mobjPreviousSampParameter);
			objfrmSampleParameters.ShowDialog();
			//'show the form.
			Application.DoEvents();
			objfrmSampleParameters.Close();
			objfrmSampleParameters.Dispose();
			objfrmSampleParameters = null;
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
			Application.DoEvents();
			//tlbbtnSampleParameters.ResumeEvents()
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
		//'note:
		//'this is called when user clicked on report option button
		//'for showing a report option dialog.
		frmReportOptions objfrmReportOptions;
		if (mblnAvoidProcessing == true) {
			return;
		}
		mblnAvoidProcessing = true;
		try {
			gobjMain.ShowRunTimeInfo(gstrTitleInstrumentType + ConstFormLoad);
			//tlbbtnReportOptions.SuspendEvents()

			objfrmReportOptions = new frmReportOptions(EnumMethodMode.EditMode, false, 0, 0);
			objfrmReportOptions.ShowDialog();
			Application.DoEvents();
			objfrmReportOptions.Close();
			objfrmReportOptions.Dispose();
			objfrmReportOptions = null;
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
			//tlbbtnReportOptions.ResumeEvents()
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
	//        If Me.XpPanelInstrumentSettings.PanelState = UIComponents.XPPanelState.Expanded Then
	//            Me.XpPanelInstrumentSettings.TogglePanelState()
	//            Me.XpPanelInstrumentSettings.Height = 0
	//        End If
	//        If XpPanelInstrumentParameters.PanelState = UIComponents.XPPanelState.Expanded Then
	//            Me.XpPanelInstrumentParameters.TogglePanelState()
	//            Me.XpPanelInstrumentParameters.Height = 0
	//        End If
	//        If Me.XpPanelStandardConcentrations.PanelState = UIComponents.XPPanelState.Expanded Then
	//            Me.XpPanelStandardConcentrations.TogglePanelState()
	//            Me.XpPanelStandardConcentrations.Height = 0
	//        End If
	//        If Me.XpPanelSampleParameters.PanelState = UIComponents.XPPanelState.Expanded Then
	//            Me.XpPanelSampleParameters.TogglePanelState()
	//            Me.XpPanelSampleParameters.Height = 0
	//        End If
	//        If Me.XpPanelReportOptions.PanelState = UIComponents.XPPanelState.Expanded Then
	//            Me.XpPanelReportOptions.TogglePanelState()
	//            Me.XpPanelReportOptions.Height = 0
	//        End If
	//        If Me.XpPanelNewMethod.PanelState = UIComponents.XPPanelState.Expanded Then
	//            Me.XpPanelNewMethod.TogglePanelState()
	//            Me.XpPanelNewMethod.Height = 0
	//        End If
	//        If Me.XpPanelLoadMethod.PanelState = UIComponents.XPPanelState.Expanded Then
	//            Me.XpPanelLoadMethod.TogglePanelState()
	//            Me.XpPanelLoadMethod.Height = 0
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
		try {
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

	//Private Sub XpPanelInstrumentSettingsClicked(ByVal sender As Object, ByVal e As System.EventArgs)
	//    '=====================================================================
	//    ' Procedure Name        : XpPanelInstrumentSettingsClicked
	//    ' Parameters Passed     : Object,EventArgs
	//    ' Returns               : None
	//    ' Purpose               : To load the Instrument Settings form
	//    ' Description           : 
	//    ' Assumptions           : 
	//    ' Dependencies          : 
	//    ' Author                : Deepak & Saurabh
	//    ' Created               : 05.10.06
	//    ' Revisions             : 
	//    '=====================================================================
	//    Dim objWait As New CWaitCursor
	//    Try
	//        If Me.XpPanelInstrumentSettings.PanelState = UIComponents.XPPanelState.Collapsed Then
	//            Call funcCollapseAllXPPanels()
	//            Me.XpPanelInstrumentSettings.TogglePanelState()
	//            Me.XpPanelInstrumentSettings.PanelHeight = 90
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

	//Private Sub XpPanelParametersClicked(ByVal sender As Object, ByVal e As System.EventArgs)
	//    '=====================================================================
	//    ' Procedure Name        : XpPanelParametersClicked
	//    ' Parameters Passed     : Object,EventArgs
	//    ' Returns               : None
	//    ' Purpose               : To load the Method Parameters form
	//    ' Description           : 
	//    ' Assumptions           : 
	//    ' Dependencies          : 
	//    ' Author                : Deepak & Saurabh
	//    ' Created               : 05.10.06
	//    ' Revisions             : 
	//    '===================================================================== 
	//    Dim objWait As New CWaitCursor
	//    Try
	//        If Me.XpPanelInstrumentParameters.PanelState = UIComponents.XPPanelState.Collapsed Then
	//            Call funcCollapseAllXPPanels()
	//            Me.XpPanelInstrumentParameters.TogglePanelState()
	//            Me.XpPanelInstrumentParameters.PanelHeight = 80
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

	//Private Sub XpPanelStandardConcentrationClicked(ByVal sender As Object, ByVal e As System.EventArgs)
	//    '=====================================================================
	//    ' Procedure Name        : XpPanelStandardConcentrationClicked
	//    ' Parameters Passed     : Object,EventArgs
	//    ' Returns               : None
	//    ' Purpose               : To load the Standard Concentration form
	//    ' Description           : 
	//    ' Assumptions           : 
	//    ' Dependencies          : 
	//    ' Author                : Deepak & Saurabh
	//    ' Created               : 05.10.06
	//    ' Revisions             : 
	//    '===================================================================== 
	//    Dim objWait As New CWaitCursor
	//    Try
	//        If Me.XpPanelStandardConcentrations.PanelState = UIComponents.XPPanelState.Collapsed Then
	//            Call funcCollapseAllXPPanels()
	//            Me.XpPanelStandardConcentrations.TogglePanelState()
	//            Me.XpPanelStandardConcentrations.PanelHeight = 90
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

	//Private Sub XpPanelSampleParametersClicked(ByVal sender As Object, ByVal e As System.EventArgs)
	//    '=====================================================================
	//    ' Procedure Name        : XpPanelSampleParametersClicked
	//    ' Parameters Passed     : Object,EventArgs
	//    ' Returns               : None
	//    ' Purpose               : To load the Sample Parameters form
	//    ' Description           : 
	//    ' Assumptions           : 
	//    ' Dependencies          : 
	//    ' Author                : Deepak & Saurabh
	//    ' Created               : 05.10.06
	//    ' Revisions             : 
	//    '===================================================================== 
	//    Dim objWait As New CWaitCursor
	//    Try
	//        If Me.XpPanelSampleParameters.PanelState = UIComponents.XPPanelState.Collapsed Then
	//            Call funcCollapseAllXPPanels()
	//            Me.XpPanelSampleParameters.TogglePanelState()
	//            Me.XpPanelSampleParameters.PanelHeight = 80
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

	//Private Sub XpPanelReportOptionsClicked(ByVal sender As Object, ByVal e As System.EventArgs)
	//    '=====================================================================
	//    ' Procedure Name        : XpPanelReportOptionsClicked
	//    ' Parameters Passed     : Object,EventArgs
	//    ' Returns               : None
	//    ' Purpose               : To load the Report Options form
	//    ' Description           : 
	//    ' Assumptions           : 
	//    ' Dependencies          : 
	//    ' Author                : Deepak & Saurabh
	//    ' Created               : 05.10.06
	//    ' Revisions             : 
	//    '=====================================================================
	//    Dim objWait As New CWaitCursor
	//    Try
	//        If Me.XpPanelReportOptions.PanelState = UIComponents.XPPanelState.Collapsed Then
	//            Call funcCollapseAllXPPanels()
	//            Me.XpPanelReportOptions.TogglePanelState()
	//            Me.XpPanelReportOptions.PanelHeight = 80

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

	//Private Sub XpPanelNewMethodClicked(ByVal sender As Object, ByVal e As System.EventArgs)
	//    '=====================================================================
	//    ' Procedure Name        : XpPanelNewMethodClicked
	//    ' Parameters Passed     : Object,EventArgs
	//    ' Returns               : None
	//    ' Purpose               : To create new method
	//    ' Description           : 
	//    ' Assumptions           : 
	//    ' Dependencies          : 
	//    ' Author                : Deepak & Saurabh
	//    ' Created               : 05.10.06
	//    ' Revisions             : 
	//    '=====================================================================
	//    'Dim objWait As New CWaitCursor
	//    Try
	//        If Me.XpPanelNewMethod.PanelState = UIComponents.XPPanelState.Collapsed Then
	//            Call funcCollapseAllXPPanels()
	//            Me.XpPanelNewMethod.TogglePanelState()
	//            Me.XpPanelNewMethod.PanelHeight = 80
	//            'Me.XpPanelNewMethod.Height = 112
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
	//        'If Not objWait Is Nothing Then
	//        '    objWait.Dispose()
	//        'End If
	//        '---------------------------------------------------------
	//    End Try
	//End Sub

	//Private Sub XpPanelLoadMethodClicked(ByVal sender As Object, ByVal e As System.EventArgs)
	//    '=====================================================================
	//    ' Procedure Name        : XpPanelLoadMethodClicked
	//    ' Parameters Passed     : Object,EventArgs
	//    ' Returns               : None
	//    ' Purpose               : To Load method
	//    ' Description           : 
	//    ' Assumptions           : 
	//    ' Dependencies          : 
	//    ' Author                : Deepak & Saurabh
	//    ' Created               : 05.10.06
	//    ' Revisions             : 
	//    '=====================================================================
	//    'Dim objWait As New CWaitCursor
	//    Try
	//        If Me.XpPanelLoadMethod.PanelState = UIComponents.XPPanelState.Collapsed Then
	//            Call funcCollapseAllXPPanels()
	//            Me.XpPanelLoadMethod.TogglePanelState()
	//            Me.XpPanelLoadMethod.PanelHeight = 80
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
	//        'If Not objWait Is Nothing Then
	//        '    objWait.Dispose()
	//        'End If
	//        '---------------------------------------------------------
	//    End Try
	//End Sub

	private bool funcShowMethodGeneralInfo(clsMethod objMethod)
	{
		//=====================================================================
		// Procedure Name        : funcShowMethodGeneralInfo
		// Parameters Passed     : object of clsMethod
		// Returns               : True or False
		// Purpose               : To show method information 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : 05.10.06
		// Revisions             : 
		//=====================================================================
		//'note:
		//'this is used to show method information 
		//'in this we take a value from objMethod object
		//'and displa it on screen,.
		DataRow objRow;
		string strStatus = "";

		try {
			TxtMethodName.Text = objMethod.MethodName;
			//'show method name in methodname text box 
			//'and so on.
			TxtMethodComments.Text = objMethod.Comments;

			objRow = gobjClsAAS203.funcGetMethodType(objMethod.OperationMode);
			//'this is to get method type
			if (!objRow == null) {
				//Saurabh 25.07.07 Check for Standard Addition"
				if (gobjNewMethod.StandardAddition) {
					//'check for std add
					TxtModeOfOperation.Text = "STANDARD ADDITION [" + objRow.Item(ConstColumnMethodType) + "]";
				} else {
					TxtModeOfOperation.Text = objRow.Item(ConstColumnMethodType);
				}
			}
			if (objMethod.Status == true) {
				//'check a flag for status of a flag.
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

			lstMethodInformation.Items.Clear();
			lstMethodInformation.Items.Add(ConstCreatedBy + vbTab + objMethod.UserName);
			lstMethodInformation.Items.Add(ConstCreatedOn + vbTab + Format(objMethod.DateOfCreation, "dd-MMM-yyyy hh:mm tt"));
			lstMethodInformation.Items.Add(ConstStatus + vbTab + vbTab + strStatus);
			lstMethodInformation.Items.Add(ConstChangedOn + vbTab + strDateOfModification);
			lstMethodInformation.Items.Add(ConstLastUsedOn + vbTab + strDateOfLastUse);

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

	private object createTestMethod()
	{
		//=====================================================================
		// Procedure Name        : createTestMethod
		// Parameters Passed     : None
		// Returns               : True or False
		// Purpose               : for creat a test method.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : 05.10.06
		// Revisions             : 
		//=====================================================================
		try {
			//Call funcSerialize(ConstMethodsFileName, gobjMethodCollection)
			funcSaveAllMethods(gobjMethodCollection);
		//'function for saving a method.

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

	private void mobjfrmLoadMethod_LoadMethod(AAS203Library.Method.clsMethod objClsMethod)
	{
		//=====================================================================
		// Procedure Name        : mobjfrmLoadMethod_LoadMethod
		// Parameters Passed     : object of clsMethod
		// Returns               : None
		// Purpose               : To display general information of load method event of frmLoadMethod form
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : 05.10.06
		// Revisions             : 
		//=====================================================================
		try {
			funcShowMethodGeneralInfo(objClsMethod);
			//'this will show a information from method object to Screen.
			OpenMethodMode = modGlobalConstants.EnumMethodMode.EditMode;
			//'set a mode of a method to edit mode.

			//--- Added by Mangesh on 27-Feb-2007
			//--- For incrementing Run Number for recently loaded Method.

			gobjMain.IsStartAnalysisRunNumber = true;
			//'flag for analysis


			//XpPanelInstrumentSettings.Enabled = True
			//XpPanelInstrumentParameters.Enabled = True
			//XpPanelStandardConcentrations.Enabled = True
			//XpPanelSampleParameters.Enabled = True
			//XpPanelReportOptions.Enabled = True
			//'
			//'onscreen validation during loading.
			btnInstrumentSettings.Enabled = true;
			btnInstrumentParameters.Enabled = true;
			btnStandardConcentrations.Enabled = true;
			btnSampleParameters.Enabled = true;
			btnReportOptions.Enabled = true;

			//tlbbtnInstrumentSettings.Enabled = True
			//tlbbtnInstrumentParameters.Enabled = True
			//tlbbtnStandardConcentrations.Enabled = True
			//tlbbtnSampleParameters.Enabled = True
			//tlbbtnReportOptions.Enabled = True

			if (LoadedMethodChanged != null) {
				LoadedMethodChanged();
			}
		//'raise a event
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

	private void objfrmInstrumentParameters_MethodInstrumentSettingsChanged()
	{
		//=====================================================================
		// Procedure Name        : objfrmInstrumentParameters_MethodInstrumentSettingsChanged
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : To notify the MDIMain form about status of Method Instrument
		//                         Settings are changed and perform Peak Latching in Analysis form
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 14-Mar-2007 04:25 pm
		// Revisions             : 1
		//=====================================================================
		try {
			gobjMain.MethodInstrumentSettingsChanged = true;

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

	//Private Sub XpPanelInstrumentSettings_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs)
	//    '=====================================================================
	//    ' Procedure Name        : XpPanelInstrumentSettingsClicked
	//    ' Parameters Passed     : Object,EventArgs
	//    ' Returns               : None
	//    ' Purpose               : To load the Instrument Settings form
	//    ' Description           : 
	//    ' Assumptions           : 
	//    ' Dependencies          : 
	//    ' Author                : Deepak & Saurabh
	//    ' Created               : 05.10.06
	//    ' Revisions             : 
	//    '=====================================================================
	//    Dim objWait As New CWaitCursor
	//    Try
	//        If Me.XpPanelInstrumentSettings.PanelState = UIComponents.XPPanelState.Collapsed Then
	//            Call funcCollapseAllXPPanels()
	//            Me.XpPanelInstrumentSettings.TogglePanelState()
	//            Me.XpPanelInstrumentSettings.PanelHeight = 90
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

	//Private Sub XpPanelInstrumentParameters_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs)
	//    '=====================================================================
	//    ' Procedure Name        : XpPanelParametersClicked
	//    ' Parameters Passed     : Object,EventArgs
	//    ' Returns               : None
	//    ' Purpose               : To load the Method Parameters form
	//    ' Description           : 
	//    ' Assumptions           : 
	//    ' Dependencies          : 
	//    ' Author                : Deepak & Saurabh
	//    ' Created               : 05.10.06
	//    ' Revisions             : 
	//    '===================================================================== 
	//    Dim objWait As New CWaitCursor
	//    Try
	//        If Me.XpPanelInstrumentParameters.PanelState = UIComponents.XPPanelState.Collapsed Then
	//            Call funcCollapseAllXPPanels()
	//            Me.XpPanelInstrumentParameters.TogglePanelState()
	//            Me.XpPanelInstrumentParameters.PanelHeight = 80
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

	//Private Sub XpPanelLoadMethod_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs)
	//    '=====================================================================
	//    ' Procedure Name        : XpPanelLoadMethodClicked
	//    ' Parameters Passed     : Object,EventArgs
	//    ' Returns               : None
	//    ' Purpose               : To Load method
	//    ' Description           : 
	//    ' Assumptions           : 
	//    ' Dependencies          : 
	//    ' Author                : Deepak & Saurabh
	//    ' Created               : 05.10.06
	//    ' Revisions             : 
	//    '=====================================================================
	//    'Dim objWait As New CWaitCursor
	//    Try
	//        If Me.XpPanelLoadMethod.PanelState = UIComponents.XPPanelState.Collapsed Then
	//            Call funcCollapseAllXPPanels()
	//            Me.XpPanelLoadMethod.TogglePanelState()
	//            Me.XpPanelLoadMethod.PanelHeight = 80
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
	//        'If Not objWait Is Nothing Then
	//        '    objWait.Dispose()
	//        'End If
	//        '---------------------------------------------------------
	//    End Try
	//End Sub

	//Private Sub XpPanelNewMethod_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs)
	//    '=====================================================================
	//    ' Procedure Name        : XpPanelNewMethodClicked
	//    ' Parameters Passed     : Object,EventArgs
	//    ' Returns               : None
	//    ' Purpose               : To create new method
	//    ' Description           : 
	//    ' Assumptions           : 
	//    ' Dependencies          : 
	//    ' Author                : Deepak & Saurabh
	//    ' Created               : 05.10.06
	//    ' Revisions             : 
	//    '=====================================================================
	//    'Dim objWait As New CWaitCursor
	//    Try
	//        If Me.XpPanelNewMethod.PanelState = UIComponents.XPPanelState.Collapsed Then
	//            Call funcCollapseAllXPPanels()
	//            Me.XpPanelNewMethod.TogglePanelState()
	//            Me.XpPanelNewMethod.PanelHeight = 80
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
	//        'If Not objWait Is Nothing Then
	//        '    objWait.Dispose()
	//        'End If
	//        '---------------------------------------------------------
	//    End Try
	//End Sub

	//Private Sub XpPanelReportOptions_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs)
	//    '=====================================================================
	//    ' Procedure Name        : XpPanelReportOptionsClicked
	//    ' Parameters Passed     : Object,EventArgs
	//    ' Returns               : None
	//    ' Purpose               : To load the Report Options form
	//    ' Description           : 
	//    ' Assumptions           : 
	//    ' Dependencies          : 
	//    ' Author                : Deepak & Saurabh
	//    ' Created               : 05.10.06
	//    ' Revisions             : 
	//    '=====================================================================
	//    Dim objWait As New CWaitCursor
	//    Try
	//        If Me.XpPanelReportOptions.PanelState = UIComponents.XPPanelState.Collapsed Then
	//            Call funcCollapseAllXPPanels()
	//            Me.XpPanelReportOptions.TogglePanelState()
	//            Me.XpPanelReportOptions.PanelHeight = 80
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

	//Private Sub XpPanelSampleParameters_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs)
	//    '=====================================================================
	//    ' Procedure Name        : XpPanelSampleParametersClicked
	//    ' Parameters Passed     : Object,EventArgs
	//    ' Returns               : None
	//    ' Purpose               : To load the Sample Parameters form
	//    ' Description           : 
	//    ' Assumptions           : 
	//    ' Dependencies          : 
	//    ' Author                : Deepak & Saurabh
	//    ' Created               : 05.10.06
	//    ' Revisions             : 
	//    '===================================================================== 
	//    Dim objWait As New CWaitCursor
	//    Try
	//        If Me.XpPanelSampleParameters.PanelState = UIComponents.XPPanelState.Collapsed Then
	//            Call funcCollapseAllXPPanels()
	//            Me.XpPanelSampleParameters.TogglePanelState()
	//            Me.XpPanelSampleParameters.PanelHeight = 80
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

	//Private Sub XpPanelStandardConcentrations_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs)
	//    '=====================================================================
	//    ' Procedure Name        : XpPanelStandardConcentrationClicked
	//    ' Parameters Passed     : Object,EventArgs
	//    ' Returns               : None
	//    ' Purpose               : To load the Standard Concentration form
	//    ' Description           : 
	//    ' Assumptions           : 
	//    ' Dependencies          : 
	//    ' Author                : Deepak & Saurabh
	//    ' Created               : 05.10.06
	//    ' Revisions             : 
	//    '===================================================================== 
	//    Dim objWait As New CWaitCursor
	//    Try
	//        If Me.XpPanelStandardConcentrations.PanelState = UIComponents.XPPanelState.Collapsed Then
	//            Call funcCollapseAllXPPanels()
	//            Me.XpPanelStandardConcentrations.TogglePanelState()
	//            Me.XpPanelStandardConcentrations.PanelHeight = 90
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

	private void btnIgnite_Click(object sender, System.EventArgs e)
	{
		//=====================================================================
		//    ' Procedure Name        : btnIgnite_Click
		//    ' Parameters Passed     : Object,EventArgs
		//    ' Returns               : None
		//    ' Purpose               : 
		//    ' Description           : 
		//    ' Assumptions           : 
		//    ' Dependencies          : 
		//    ' Author                : Deepak & Saurabh
		//    ' Created               : 05.10.06
		//    ' Revisions             : 
		//    '=====================================================================
		//'note:
		//'this is called when user click on ignite button
		//'this will ignite by calling a function
		if (mblnAvoidProcessing == true) {
			return;
		}
		try {
			if (!IsNothing(gobjMain)) {
				//MsgBox("frmStatus")
				mblnAvoidProcessing = true;
				gobjMain.AutoIgnition();
				//'function for ignite
				mblnAvoidProcessing = false;

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

	private void btnExtinguish_Click(object sender, System.EventArgs e)
	{
		//=====================================================================
		//    ' Procedure Name        : btnExtinguish_Click
		//    ' Parameters Passed     : Object,EventArgs
		//    ' Returns               : None
		//    ' Purpose               : this is called when user click on Extinguish button.
		//    ' Description           : 
		//    ' Assumptions           : 
		//    ' Dependencies          : 
		//    ' Author                : Deepak & Saurabh
		//    ' Created               : 05.10.06
		//    ' Revisions             : 
		//    '=====================================================================
		if (mblnAvoidProcessing == true) {
			return;
		}
		try {
			mblnAvoidProcessing = true;


			gobjMain.Extinguish();
			//'function for Extinguish
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

	private void btnN2OIgnite_Click(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		//    ' Procedure Name        : btnN2OIgnite_Click
		//    ' Parameters Passed     : Object,EventArgs
		//    ' Returns               : None
		//    ' Purpose               : this is calledwhen user clicked on N2O button.
		//    ' Description           : 
		//    ' Assumptions           : 
		//    ' Dependencies          : 
		//    ' Author                : Deepak & Saurabh
		//    ' Created               : 05.10.06
		//    ' Revisions             : 
		//    '=====================================================================
		if (mblnAvoidProcessing == true) {
			return;
		}
		try {
			mblnAvoidProcessing = true;
			gobjMain.N2OAutoIgnition();
			//'function for N2O ignition.
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

	#End Region

	#Region "Commented Code"
	//#Region " ProgressBar Functions "

	//    Public Sub ShowProgressBar(ByVal message As String)
	//        '=====================================================================
	//        ' Procedure Name        : ShowProgressBar
	//        ' Parameters Passed     : message
	//        ' Returns               : None
	//        ' Purpose               : to show the progress bar
	//        ' Description           : 
	//        ' Assumptions           : 
	//        ' Dependencies          : 
	//        ' Author                : Deepak Bhati
	//        ' Created               : Saturday, January 22, 2005
	//        ' Revisions             : 
	//        '=====================================================================
	//        Try
	//            ProgressPanel.Value = 20
	//            StatusBarPanelInfo.Text = message
	//            'start a new thread to increment the progressbar
	//            Dim progressThread As New Thread(AddressOf BackGroundIncrementProgressBar)
	//            progressThread.IsBackground = True
	//            progressThread.Name = "Progress Bar"
	//            progressThread.Start()

	//        Catch ex As Exception
	//            '---------------------------------------------------------
	//            'Error Handling and logging
	//            gobjErrorHandler.ErrorDescription = ex.Message
	//            gobjErrorHandler.ErrorMessage = ex.Message
	//            gobjErrorHandler.WriteErrorLog(ex)
	//            '---------------------------------------------------------
	//        Finally
	//            '---------------------------------------------------------
	//            'Writing Execution log
	//            If CONST_CREATE_EXECUTION_LOG = 1 Then
	//                gobjErrorHandler.WriteExecutionLog()
	//            End If
	//            '---------------------------------------------------------
	//        End Try
	//    End Sub

	//    Private Sub BackGroundIncrementProgressBar()
	//        '=====================================================================
	//        ' Procedure Name        : BackGroundIncrementProgressBar
	//        ' Parameters Passed     : None
	//        ' Returns               : None 
	//        ' Purpose               : to increment the progress of progress bar
	//        ' Description           : 
	//        ' Assumptions           : 
	//        ' Dependencies          : 
	//        ' Author                : Deepak Bhati
	//        ' Created               : Saturday, January 22, 2005
	//        ' Revisions             : 
	//        '=====================================================================
	//        Try
	//            'note: this will run on a worker thread
	//            While ProgressPanel.Value <> 100
	//                If ProgressPanel.Value < 80 Then ProgressPanel.Value += 8
	//                Thread.Sleep(30)
	//            End While

	//        Catch ex As Exception
	//            '---------------------------------------------------------
	//            'Error Handling and logging
	//            gobjErrorHandler.ErrorDescription = ex.Message
	//            gobjErrorHandler.ErrorMessage = ex.Message
	//            gobjErrorHandler.WriteErrorLog(ex)
	//            '---------------------------------------------------------
	//        Finally
	//            '---------------------------------------------------------
	//            'Writing Execution log
	//            If CONST_CREATE_EXECUTION_LOG = 1 Then
	//                gobjErrorHandler.WriteExecutionLog()
	//            End If
	//            '---------------------------------------------------------
	//        End Try
	//    End Sub

	//    Public Sub HideProgressBar()
	//        '=====================================================================
	//        ' Procedure Name        : HideProgressBar
	//        ' Parameters Passed     : None
	//        ' Returns               : None
	//        ' Purpose               : to finish the progress bar
	//        ' Description           : 
	//        ' Assumptions           : 
	//        ' Dependencies          : 
	//        ' Author                : Deepak Bhati
	//        ' Created               : Sunday, January 23, 2005
	//        ' Revisions             : 
	//        '=====================================================================
	//        Try
	//            'this sleep code is only eye candy but note that we must set m_ProgressBar.Value = 100
	//            'so that BackGroundIncrementProgressBar() can die
	//            Dim i As Integer
	//            For i = 0 To 16
	//                Thread.Sleep(30)
	//                Application.DoEvents()

	//                'show 100% for a glance
	//                If i = 15 Then ProgressPanel.Value = 100
	//            Next
	//            ProgressPanel.Value = 0
	//            ProgressPanel.Text = Application.ProductName & Space(1) & Application.ProductVersion

	//        Catch ex As Exception
	//            '---------------------------------------------------------
	//            'Error Handling and logging
	//            gobjErrorHandler.ErrorDescription = ex.Message
	//            gobjErrorHandler.ErrorMessage = ex.Message
	//            gobjErrorHandler.WriteErrorLog(ex)
	//            '---------------------------------------------------------
	//        Finally
	//            '---------------------------------------------------------
	//            'Writing Execution log
	//            If CONST_CREATE_EXECUTION_LOG = 1 Then
	//                gobjErrorHandler.WriteExecutionLog()
	//            End If
	//            '---------------------------------------------------------
	//        End Try
	//    End Sub

	//    Public Sub ShowRunTimeInfo(ByVal message As String)
	//        '=====================================================================
	//        ' Procedure Name        : ShowProgressBar
	//        ' Parameters Passed     : message
	//        ' Returns               : None
	//        ' Purpose               : to show the progress bar
	//        ' Description           : 
	//        ' Assumptions           : 
	//        ' Dependencies          : 
	//        ' Author                : Deepak Bhati
	//        ' Created               : Saturday, January 22, 2005
	//        ' Revisions             : 
	//        '=====================================================================
	//        Try
	//            'ProgressPanel.Value = 20
	//            StatusBarPanelInfo.Text = message
	//            'start a new thread to increment the progressbar
	//            'Dim progressThread As New Thread(AddressOf BackGroundIncrementProgressBar)
	//            'progressThread.IsBackground = True
	//            'progressThread.Name = "Progress Bar"
	//            'progressThread.Start()

	//        Catch ex As Exception
	//            '---------------------------------------------------------
	//            'Error Handling and logging
	//            gobjErrorHandler.ErrorDescription = ex.Message
	//            gobjErrorHandler.ErrorMessage = ex.Message
	//            gobjErrorHandler.WriteErrorLog(ex)
	//            '---------------------------------------------------------
	//        Finally
	//            '---------------------------------------------------------
	//            'Writing Execution log
	//            If CONST_CREATE_EXECUTION_LOG = 1 Then
	//                gobjErrorHandler.WriteExecutionLog()
	//            End If
	//            '---------------------------------------------------------
	//        End Try
	//    End Sub

	//#End Region

	//Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
	//    Dim objfrmabout As New frmAboutUs
	//    objfrmabout.Show()
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
	//        'RemoveHandler mnuExtinguish.Click, AddressOf btnExtinguish_Click

	//        If Not gstructSettings.AppMode = EnumAppMode.DemoMode Then
	//            If Not IsNothing(gobjMain.mobjfrmAnalysis) Then gobjMain.mobjfrmAnalysis.tmrAspirationMsg.Enabled = False
	//            gobjMain.mobjController.Cancel()
	//            Application.DoEvents()
	//            Call gobjClsAAS203.funcIgnite(False)
	//        Else
	//            Call gobjMessageAdapter.ShowMessage("Flame Extinguished", "AUTO EXTINGUISH", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage)
	//            Application.DoEvents()
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
	//        If Not gstructSettings.AppMode = EnumAppMode.DemoMode Then
	//            If Not IsNothing(gobjMain.mobjfrmAnalysis) Then gobjMain.mobjfrmAnalysis.tmrAspirationMsg.Enabled = True
	//            gobjMain.mobjController.Start(gobjclsBgFlameStatus)
	//            Application.DoEvents()
	//        End If
	//        'AddHandler mnuExtinguish.Click, AddressOf btnExtinguish_Click
	//        '---------------------------------------------------------
	//    End Try
	//End Sub

	//Private Sub btnIgnite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
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
	//        'RemoveHandler mnuIgnite.Click, AddressOf btnAutoIgnition_Click

	//        If Not gstructSettings.AppMode = EnumAppMode.DemoMode Then
	//            If Not IsNothing(gobjMain.mobjfrmAnalysis) Then gobjMain.mobjfrmAnalysis.tmrAspirationMsg.Enabled = False
	//            Call gobjMain.mobjController.Cancel()
	//            Call Application.DoEvents()
	//            Call gobjCommProtocol.mobjCommdll.subTime_Delay(100)
	//            Call gobjClsAAS203.funcIgnite(True)

	//        Else
	//            Call gobjMessageAdapter.ShowMessage("Flame Ignited", "AUTO IGNITION", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage)
	//            Call Application.DoEvents()
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
	//        If Not gstructSettings.AppMode = EnumAppMode.DemoMode Then
	//            If Not IsNothing(gobjMain.mobjfrmAnalysis) Then gobjMain.mobjfrmAnalysis.tmrAspirationMsg.Enabled = True
	//            gobjMain.mobjController.Start(gobjclsBgFlameStatus)
	//            Application.DoEvents()
	//        End If
	//        'AddHandler mnuIgnite.Click, AddressOf btnAutoIgnition_Click
	//        '---------------------------------------------------------
	//    End Try
	//End Sub
	#End Region


	private void Button1_Click(System.Object sender, System.EventArgs e)
	{
		gobjClsAAS203.funcLoadLastOptimizedConditions(true);

	}
}
