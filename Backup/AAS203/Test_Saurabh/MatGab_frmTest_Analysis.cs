using AAS203.Common;
using System.Threading;
using AAS203Library;
using AAS203Library.Analysis;
using AAS203Library.Method;
using AAS203Library.Method.clsQuantitativeData;

using BgThread;
public class frmTest_Analysis : System.Windows.Forms.Form, BgThread.Iclient
{

	#Region " Windows Form Designer generated code "

	public frmTest_Analysis()
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
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuBack;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuStandardGraph;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuSampleGraph;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuViewResults;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuBack1;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuReports;
	internal System.Timers.Timer tmrAspirationMsg;
	internal NETXP.Controls.XPButton btnStartStopAnalysis;
	internal NETXP.Controls.XPButton btnReadData;
	internal GradientPanel.CustomPanel CustomPanelMain;
	internal GradientPanel.CustomPanel CustomPanel1;
	internal GradientPanel.CustomPanel custPnlASPMessages;
	internal NETXP.Controls.XPButton btnNewAnalysis;
	internal System.Windows.Forms.Label lblOptimizedWavelength;
	internal NETXP.Controls.XPButton btnNextAnalysis;
	internal NETXP.Controls.XPButton btnExtinguish;
	internal NETXP.Controls.XPButton btnIgnite;
	internal System.Windows.Forms.Label lblAspirationMessage;
	internal System.Windows.Forms.GroupBox grpAbsorbanceValues;
	internal System.Windows.Forms.Label lblCorrectedAbsorbance;
	internal System.Windows.Forms.Label lblAverageAbsorbance;
	internal System.Windows.Forms.Label lblAbsorbance;
	internal System.Windows.Forms.Label lblCorrectedAbsorbanceMain;
	internal System.Windows.Forms.Label lblAverageAbsorbanceMain;
	internal System.Windows.Forms.Label lblAbsorbanceMain;
	internal NETXP.Controls.XPButton btnAutoZero;
	[System.Diagnostics.DebuggerStepThrough()]
	private void InitializeComponent()
	{
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmTest_Analysis));
		this.mnuBack = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuStandardGraph = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuSampleGraph = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuViewResults = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuBack1 = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuReports = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.tmrAspirationMsg = new System.Timers.Timer();
		this.CustomPanel1 = new GradientPanel.CustomPanel();
		this.btnReadData = new NETXP.Controls.XPButton();
		this.btnStartStopAnalysis = new NETXP.Controls.XPButton();
		this.btnIgnite = new NETXP.Controls.XPButton();
		this.btnExtinguish = new NETXP.Controls.XPButton();
		this.btnNextAnalysis = new NETXP.Controls.XPButton();
		this.lblOptimizedWavelength = new System.Windows.Forms.Label();
		this.btnNewAnalysis = new NETXP.Controls.XPButton();
		this.custPnlASPMessages = new GradientPanel.CustomPanel();
		this.lblAspirationMessage = new System.Windows.Forms.Label();
		this.grpAbsorbanceValues = new System.Windows.Forms.GroupBox();
		this.lblCorrectedAbsorbance = new System.Windows.Forms.Label();
		this.lblAverageAbsorbance = new System.Windows.Forms.Label();
		this.lblAbsorbance = new System.Windows.Forms.Label();
		this.lblCorrectedAbsorbanceMain = new System.Windows.Forms.Label();
		this.lblAverageAbsorbanceMain = new System.Windows.Forms.Label();
		this.lblAbsorbanceMain = new System.Windows.Forms.Label();
		this.btnAutoZero = new NETXP.Controls.XPButton();
		this.CustomPanelMain = new GradientPanel.CustomPanel();
		((System.ComponentModel.ISupportInitialize)this.tmrAspirationMsg).BeginInit();
		this.CustomPanel1.SuspendLayout();
		this.custPnlASPMessages.SuspendLayout();
		this.grpAbsorbanceValues.SuspendLayout();
		this.CustomPanelMain.SuspendLayout();
		this.SuspendLayout();
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
		//mnuBack1
		//
		this.mnuBack1.Shortcut = System.Windows.Forms.Shortcut.CtrlZ;
		this.mnuBack1.Text = "Back";
		//
		//mnuReports
		//
		this.mnuReports.Shortcut = System.Windows.Forms.Shortcut.CtrlR;
		this.mnuReports.Text = "Reports";
		//
		//tmrAspirationMsg
		//
		this.tmrAspirationMsg.Enabled = true;
		this.tmrAspirationMsg.Interval = 500;
		this.tmrAspirationMsg.SynchronizingObject = this;
		//
		//CustomPanel1
		//
		this.CustomPanel1.BackColor = System.Drawing.Color.AliceBlue;
		this.CustomPanel1.BackColor2 = System.Drawing.Color.Transparent;
		this.CustomPanel1.BorderColor = System.Drawing.SystemColors.InactiveBorder;
		this.CustomPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.CustomPanel1.Controls.Add(this.btnReadData);
		this.CustomPanel1.Controls.Add(this.btnStartStopAnalysis);
		this.CustomPanel1.Controls.Add(this.btnIgnite);
		this.CustomPanel1.Controls.Add(this.btnExtinguish);
		this.CustomPanel1.Controls.Add(this.btnNextAnalysis);
		this.CustomPanel1.Controls.Add(this.lblOptimizedWavelength);
		this.CustomPanel1.Controls.Add(this.btnNewAnalysis);
		this.CustomPanel1.Controls.Add(this.custPnlASPMessages);
		this.CustomPanel1.Controls.Add(this.grpAbsorbanceValues);
		this.CustomPanel1.Controls.Add(this.btnAutoZero);
		this.CustomPanel1.Location = new System.Drawing.Point(-6, 0);
		this.CustomPanel1.Name = "CustomPanel1";
		this.CustomPanel1.Size = new System.Drawing.Size(454, 232);
		this.CustomPanel1.TabIndex = 8;
		//
		//btnReadData
		//
		this.btnReadData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnReadData.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnReadData.Image = (System.Drawing.Image)resources.GetObject("btnReadData.Image");
		this.btnReadData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnReadData.Location = new System.Drawing.Point(333, 56);
		this.btnReadData.Name = "btnReadData";
		this.btnReadData.Size = new System.Drawing.Size(104, 36);
		this.btnReadData.TabIndex = 7;
		this.btnReadData.Text = "&Read Data";
		this.btnReadData.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//btnStartStopAnalysis
		//
		this.btnStartStopAnalysis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnStartStopAnalysis.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnStartStopAnalysis.Image = (System.Drawing.Image)resources.GetObject("btnStartStopAnalysis.Image");
		this.btnStartStopAnalysis.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnStartStopAnalysis.Location = new System.Drawing.Point(19, 56);
		this.btnStartStopAnalysis.Name = "btnStartStopAnalysis";
		this.btnStartStopAnalysis.RightToLeft = System.Windows.Forms.RightToLeft.No;
		this.btnStartStopAnalysis.Size = new System.Drawing.Size(104, 36);
		this.btnStartStopAnalysis.TabIndex = 6;
		this.btnStartStopAnalysis.Text = "Start Anal&ysis";
		this.btnStartStopAnalysis.TextAlign = System.Drawing.ContentAlignment.TopLeft;
		//
		//btnIgnite
		//
		this.btnIgnite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnIgnite.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnIgnite.Location = new System.Drawing.Point(232, 304);
		this.btnIgnite.Name = "btnIgnite";
		this.btnIgnite.Size = new System.Drawing.Size(48, 20);
		this.btnIgnite.TabIndex = 29;
		this.btnIgnite.TabStop = false;
		this.btnIgnite.Text = "&Ignite";
		//
		//btnExtinguish
		//
		this.btnExtinguish.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnExtinguish.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnExtinguish.Location = new System.Drawing.Point(136, 304);
		this.btnExtinguish.Name = "btnExtinguish";
		this.btnExtinguish.Size = new System.Drawing.Size(56, 20);
		this.btnExtinguish.TabIndex = 28;
		this.btnExtinguish.TabStop = false;
		this.btnExtinguish.Text = "&Extinguish";
		//
		//btnNextAnalysis
		//
		this.btnNextAnalysis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnNextAnalysis.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnNextAnalysis.Image = (System.Drawing.Image)resources.GetObject("btnNextAnalysis.Image");
		this.btnNextAnalysis.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnNextAnalysis.Location = new System.Drawing.Point(400, 304);
		this.btnNextAnalysis.Name = "btnNextAnalysis";
		this.btnNextAnalysis.Size = new System.Drawing.Size(100, 36);
		this.btnNextAnalysis.TabIndex = 27;
		this.btnNextAnalysis.Text = "Ne&xt";
		this.btnNextAnalysis.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//lblOptimizedWavelength
		//
		this.lblOptimizedWavelength.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblOptimizedWavelength.Location = new System.Drawing.Point(40, 264);
		this.lblOptimizedWavelength.Name = "lblOptimizedWavelength";
		this.lblOptimizedWavelength.Size = new System.Drawing.Size(160, 19);
		this.lblOptimizedWavelength.TabIndex = 26;
		this.lblOptimizedWavelength.Text = "Optimized Wavelength : ";
		//
		//btnNewAnalysis
		//
		this.btnNewAnalysis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnNewAnalysis.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnNewAnalysis.Image = (System.Drawing.Image)resources.GetObject("btnNewAnalysis.Image");
		this.btnNewAnalysis.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnNewAnalysis.Location = new System.Drawing.Point(296, 296);
		this.btnNewAnalysis.Name = "btnNewAnalysis";
		this.btnNewAnalysis.Size = new System.Drawing.Size(100, 36);
		this.btnNewAnalysis.TabIndex = 11;
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
		this.custPnlASPMessages.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.custPnlASPMessages.GradientMode = GradientPanel.LinearGradientMode.Horizontal;
		this.custPnlASPMessages.Location = new System.Drawing.Point(18, 16);
		this.custPnlASPMessages.Name = "custPnlASPMessages";
		this.custPnlASPMessages.Size = new System.Drawing.Size(420, 28);
		this.custPnlASPMessages.TabIndex = 10;
		//
		//lblAspirationMessage
		//
		this.lblAspirationMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblAspirationMessage.Dock = System.Windows.Forms.DockStyle.Fill;
		this.lblAspirationMessage.ForeColor = System.Drawing.Color.Maroon;
		this.lblAspirationMessage.Location = new System.Drawing.Point(0, 0);
		this.lblAspirationMessage.Name = "lblAspirationMessage";
		this.lblAspirationMessage.Size = new System.Drawing.Size(420, 28);
		this.lblAspirationMessage.TabIndex = 1;
		this.lblAspirationMessage.Text = "Wait ... ";
		this.lblAspirationMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		//
		//grpAbsorbanceValues
		//
		this.grpAbsorbanceValues.Controls.Add(this.lblCorrectedAbsorbance);
		this.grpAbsorbanceValues.Controls.Add(this.lblAverageAbsorbance);
		this.grpAbsorbanceValues.Controls.Add(this.lblAbsorbance);
		this.grpAbsorbanceValues.Controls.Add(this.lblCorrectedAbsorbanceMain);
		this.grpAbsorbanceValues.Controls.Add(this.lblAverageAbsorbanceMain);
		this.grpAbsorbanceValues.Controls.Add(this.lblAbsorbanceMain);
		this.grpAbsorbanceValues.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.grpAbsorbanceValues.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.grpAbsorbanceValues.Location = new System.Drawing.Point(2, 96);
		this.grpAbsorbanceValues.Name = "grpAbsorbanceValues";
		this.grpAbsorbanceValues.Size = new System.Drawing.Size(454, 137);
		this.grpAbsorbanceValues.TabIndex = 10;
		this.grpAbsorbanceValues.TabStop = false;
		//
		//lblCorrectedAbsorbance
		//
		this.lblCorrectedAbsorbance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblCorrectedAbsorbance.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblCorrectedAbsorbance.Location = new System.Drawing.Point(264, 92);
		this.lblCorrectedAbsorbance.Name = "lblCorrectedAbsorbance";
		this.lblCorrectedAbsorbance.Size = new System.Drawing.Size(110, 18);
		this.lblCorrectedAbsorbance.TabIndex = 8;
		//
		//lblAverageAbsorbance
		//
		this.lblAverageAbsorbance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblAverageAbsorbance.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblAverageAbsorbance.Location = new System.Drawing.Point(264, 57);
		this.lblAverageAbsorbance.Name = "lblAverageAbsorbance";
		this.lblAverageAbsorbance.Size = new System.Drawing.Size(110, 18);
		this.lblAverageAbsorbance.TabIndex = 7;
		//
		//lblAbsorbance
		//
		this.lblAbsorbance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblAbsorbance.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblAbsorbance.Location = new System.Drawing.Point(264, 22);
		this.lblAbsorbance.Name = "lblAbsorbance";
		this.lblAbsorbance.Size = new System.Drawing.Size(110, 18);
		this.lblAbsorbance.TabIndex = 6;
		//
		//lblCorrectedAbsorbanceMain
		//
		this.lblCorrectedAbsorbanceMain.AutoSize = true;
		this.lblCorrectedAbsorbanceMain.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblCorrectedAbsorbanceMain.Location = new System.Drawing.Point(80, 93);
		this.lblCorrectedAbsorbanceMain.Name = "lblCorrectedAbsorbanceMain";
		this.lblCorrectedAbsorbanceMain.Size = new System.Drawing.Size(135, 17);
		this.lblCorrectedAbsorbanceMain.TabIndex = 2;
		this.lblCorrectedAbsorbanceMain.Text = "Corrected Absorbance :";
		//
		//lblAverageAbsorbanceMain
		//
		this.lblAverageAbsorbanceMain.AutoSize = true;
		this.lblAverageAbsorbanceMain.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblAverageAbsorbanceMain.Location = new System.Drawing.Point(80, 58);
		this.lblAverageAbsorbanceMain.Name = "lblAverageAbsorbanceMain";
		this.lblAverageAbsorbanceMain.Size = new System.Drawing.Size(127, 17);
		this.lblAverageAbsorbanceMain.TabIndex = 1;
		this.lblAverageAbsorbanceMain.Text = "Average Absorbance :";
		//
		//lblAbsorbanceMain
		//
		this.lblAbsorbanceMain.AutoSize = true;
		this.lblAbsorbanceMain.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblAbsorbanceMain.Location = new System.Drawing.Point(80, 23);
		this.lblAbsorbanceMain.Name = "lblAbsorbanceMain";
		this.lblAbsorbanceMain.Size = new System.Drawing.Size(77, 17);
		this.lblAbsorbanceMain.TabIndex = 0;
		this.lblAbsorbanceMain.Text = "Absorbance :";
		//
		//btnAutoZero
		//
		this.btnAutoZero.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnAutoZero.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnAutoZero.Image = (System.Drawing.Image)resources.GetObject("btnAutoZero.Image");
		this.btnAutoZero.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnAutoZero.Location = new System.Drawing.Point(176, 56);
		this.btnAutoZero.Name = "btnAutoZero";
		this.btnAutoZero.Size = new System.Drawing.Size(104, 36);
		this.btnAutoZero.TabIndex = 9;
		this.btnAutoZero.Text = "Auto &Zero";
		this.btnAutoZero.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//CustomPanelMain
		//
		this.CustomPanelMain.BackColor = System.Drawing.Color.AliceBlue;
		this.CustomPanelMain.BackColor2 = System.Drawing.Color.AliceBlue;
		this.CustomPanelMain.Controls.Add(this.CustomPanel1);
		this.CustomPanelMain.Location = new System.Drawing.Point(0, 0);
		this.CustomPanelMain.Name = "CustomPanelMain";
		this.CustomPanelMain.Size = new System.Drawing.Size(804, 579);
		this.CustomPanelMain.TabIndex = 17;
		//
		//frmTest_Analysis
		//
		this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
		this.ClientSize = new System.Drawing.Size(444, 231);
		this.Controls.Add(this.CustomPanelMain);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		this.MaximizeBox = false;
		this.MinimizeBox = false;
		this.Name = "frmTest_Analysis";
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Analysis";
		((System.ComponentModel.ISupportInitialize)this.tmrAspirationMsg).EndInit();
		this.CustomPanel1.ResumeLayout(false);
		this.custPnlASPMessages.ResumeLayout(false);
		this.grpAbsorbanceValues.ResumeLayout(false);
		this.CustomPanelMain.ResumeLayout(false);
		this.ResumeLayout(false);

	}

	#End Region

	//#Region "NewCode"
	//#Region " Private Constants "

	//    Private ConstFormLoad As String = gstrTitleInstrumentType & "-Analysis"
	//    Private ConstParentFormLoad As String = gstrTitleInstrumentType & "-Method"

	//#End Region

	//#Region " Private Member Variables "
	//    Dim mxValue, mdblAvgAbs As Double

	//    Dim intDispCount As Integer
	//    Private mdblWvOpt As Double = -1.0
	//    'Private mblnIsAnalysisStarted As Boolean   'Saurabh  10.07.07
	//    Friend mblnIsAnalysisStarted As Boolean    'Saurabh  10.07.07  Commented to Check S/W hang

	//    Private mblnIsAutosampler As Boolean
	//    Private EndAnalysis As Boolean = False
	//    Private mdblAbsorbance As Double

	//    Private mstrAspirationMessage As String
	//    Private mintAspirationTimerCounter As Integer
	//    Private mblnIsBlinkMessage As Boolean

	//    Private SampleType As ClsAAS203.enumSampleType = ClsAAS203.enumSampleType.BLANK
	//    Private LSampType As ClsAAS203.enumSampleType = ClsAAS203.enumSampleType.BLANK
	//    Private mobjParameters As New Spectrum.EnergySpectrumParameter

	//    Private mobjCurrentStandard As AAS203Library.Method.clsAnalysisStdParameters
	//    Private mobjCurrentSample As AAS203Library.Method.clsAnalysisSampleParameters


	//    Private mobjStandardEnumerator As IEnumerator
	//    Private mobjSampleEnumerator As IEnumerator

	//    Private mobjAnalysisRawData As New ANALYSIS.clsRawDataCollection
	//    Private mobjBlankRawData As ANALYSIS.clsRawData
	//    Private mobjStandardRawData As ANALYSIS.clsRawData
	//    Private mobjSampleRawData As ANALYSIS.clsRawData

	//    Private CurRepeat As Integer = 1

	//    Private StdAnalysed As Boolean = False
	//    Private mblnGetStandards As Boolean = False
	//    Private AnaOver As Boolean = False
	//    Private methchange As Boolean = False
	//    Private InQAnaRead As Boolean = False
	//    Private toreported As Boolean = False

	//    '---for checking the method is in analysis mode or not
	//    Public InAnalysis As Boolean = False
	//    Public exitbutton As Boolean = False
	//    Public ANALYSIS As Boolean

	//    Private mintSelectedInstrumentConditionIndex As Integer

	//    Private mobjGraphCurve As AldysGraph.CurveItem
	//    Private Afirst As Boolean

	//    Private mStartTime As Integer
	//    Private mEndTime As Integer

	//    Private XOld, YOld As Double

	//    Private Filter_flag As Boolean = True

	//    Private mdblBlankAbsorbance As Double = 0.0

	//    Public mblnIsStartRunNumber As Boolean = True      'Commented to Check S/W hang
	//    'Public mblnIsStartRunNumber As Boolean = False          

	//    '---For Background Worker Thread functions
	//    Private mController As clsBgThread

	//    'Public mobjBgReadData As New clsBgReadData
	//    Public mobjBgReadData As clsBgReadData

	//    '//----- Added by Sachin Dokhale
	//    'Private mMsgController As clsBgThread
	//    Public mobjBgMsgAspirate As AspirateMessage.clsMassageController
	//    '//-----

	//    Private mintRunNumberIndex As Integer

	//    Private mintSelectedMethodID As Integer     'Saurabh 
	//    Private mlngSelectedRunNumber As Long    'Saurabh
	//    Private mobjClsMethod As clsMethod          'Sauarbh

	//    Private mblnRepeatLastBlank As Boolean
	//    Private mblnRepeatLastStd As Boolean
	//    Private mblnRepeatLastSample As Boolean

	//    Private mobjClsDataFileReport As New clsDataFileReport 'Saurabh 07-06-2007
	//    Private intIEnumCollLocationStd As Integer
	//    Private intIEnumCollLocationSamp As Integer
	//    Private mblnAvoidProcessing As Boolean = False
	//    Private blnIsAspirateTimer As Boolean = False
	//    Dim blnIsLoadPreviousStandards As Boolean = False
	//    Public IsDisplayingMessage As Boolean = False
	//    Private mintTimeDelay As Integer = 1000
	//    Private mobjLastStandardData As clsAnalysisStdParameters
	//    Private mobjLastSampleData As clsAnalysisSampleParameters
	//#End Region

	//#Region " Private Properties "

	//    Private Property AspirationMessage() As String
	//        Get
	//            Return mstrAspirationMessage
	//        End Get
	//        Set(ByVal Value As String)
	//            mstrAspirationMessage = Value
	//        End Set
	//    End Property

	//    Public Property IsAvoidProcessing() As Boolean
	//        Get
	//            Return mblnAvoidProcessing
	//        End Get
	//        Set(ByVal Value As Boolean)
	//            mblnAvoidProcessing = Value
	//        End Set
	//    End Property

	//#End Region

	//#Region " Form Load and Event Handling Functions "

	//    Private Sub frmAnalysis_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
	//        '=====================================================================
	//        ' Procedure Name        : frmAnalysis_Load
	//        ' Parameters Passed     : Object,EventArgs
	//        ' Returns               : None
	//        ' Purpose               : To initialize the form
	//        ' Description           : 
	//        ' Assumptions           : 
	//        ' Dependencies          : 
	//        ' Author                : Deepak Bhati and Mangesh Shardul
	//        ' Created               : 07.10.06
	//        ' Revisions             : 
	//        '=====================================================================
	//        Dim objWait As New CWaitCursor
	//        Application.DoEvents()
	//        Try

	//            ' Disable auto ignition/ extinguish button  for 201 
	//            If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
	//                btnIgnite.Enabled = False
	//                btnExtinguish.Enabled = False
	//            End If

	//            'btnStdGraph.BringToFront()
	//            'btnSplGraph.BringToFront()
	//            'btnStdGraph.Focus()
	//            'btnSave.Enabled = False
	//            'cmdChangeScale.Location = New Point(14, 378)
	//            'btnExportReport.Location = New Point(14, 419)
	//            'Me.FormBorderStyle = FormBorderStyle.FixedSingle
	//            'gobjMain.ShowProgressBar(ConstFormLoad)

	//            ' Init Reading thread
	//            mobjBgReadData = New clsBgReadData

	//            ' Add handlers of form object
	//            Call AddHandlers()
	//            '//----- Sachin Dokhale
	//            If Not (gobjNewMethod.OperationMode = EnumOperationMode.MODE_UVABS Or _
	//                gobjNewMethod.OperationMode = EnumOperationMode.MODE_UVSPECT Or _
	//                gobjNewMethod.OperationMode = EnumOperationMode.MODE_EMMISSION) Then
	//                ' Init graph coordinates for if opration mode is not UVABS/Spect and Emission mode
	//                ''-----Added By Pankaj on 10 May 2007
	//                'AASGraphAnalysis.YAxisMin = -0.2
	//                'AASGraphAnalysis.YAxisMax = 1.2
	//                'gobjClsAAS203.Calculate_Analysis_Graph_Param(AASGraphAnalysis, ClsAAS203.enumChangeAxis.xyAxis)

	//                'Elseif Added by Saurabh
	//            ElseIf gobjNewMethod.OperationMode = EnumOperationMode.MODE_EMMISSION Then
	//                ' Init graph coordinates for if opration mode is Emission mode
	//                'AASGraphAnalysis.YAxisMin = -10     'Changed from 0 to -10 by Saurabh 01.08.07
	//                'AASGraphAnalysis.YAxisMax = 100
	//                'AASGraphAnalysis.YAxisStep = 10
	//                'AASGraphAnalysis.YAxisMinorStep = 10
	//                'AASGraphAnalysis.YAxisLabel = "EMISSION"
	//                'gobjClsAAS203.Calculate_Analysis_Graph_Param(AASGraphAnalysis, ClsAAS203.enumChangeAxis.xyAxis)
	//            Else
	//                ' Init graph coordinates for if opration mode is UVABS/Spect 
	//                'cmdChangeScale.Enabled = False
	//                'cmdChangeScale.Visible = False
	//                'btnPrintGraph.Enabled = False
	//                'btnPrintGraph.Visible = False
	//            End If

	//            ' Init. Aspiration messages
	//            'mMsgController = New clsBgThread(Me)
	//            mobjBgMsgAspirate = New AspirateMessage.clsMassageController(lblAspirationMessage)
	//            'mobjBgMsgAspirate.Initialize(mMsgController)
	//            If Not gobjNewMethod Is Nothing Then
	//                Dim objRow As DataRow
	//                objRow = gobjClsAAS203.funcGetMethodType(gobjNewMethod.OperationMode)
	//                'HeaderRight.TitleText = CStr(objRow.Item("MethodType"))
	//            End If
	//            If (gstructAutoSampler.blnAutoSamplerInitialised = True) Then ''by Pankaj for autosampler on 10Sep 07
	//                mblnIsAutosampler = gstructAutoSampler.blnCommunication
	//            End If
	//            '//-----
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
	//            objWait.Dispose()
	//            Application.DoEvents()
	//            'gobjMain.HideProgressBar()
	//            '---------------------------------------------------------
	//        End Try
	//    End Sub

	//    Private Sub AddHandlers()
	//        '=====================================================================
	//        ' Procedure Name        : AddHandlers
	//        ' Parameters Passed     : None
	//        ' Returns               : None
	//        ' Purpose               : To add event handlers
	//        ' Description           : 
	//        ' Assumptions           : 
	//        ' Dependencies          : 
	//        ' Author                : Saurabh
	//        ' Created               : 05.10.06
	//        ' Revisions             : 
	//        '=====================================================================
	//        Try
	//            'AddHandler XpPanelStandardGraph.Click, AddressOf XpPanelStandardGraphClicked
	//            'AddHandler XpPanelSampleGraph.Click, AddressOf XpPanelSampleGraphClicked
	//            'AddHandler XpPanelViewResults.Click, AddressOf XpPanelViewResultsClicked
	//            'AddHandler XpPanelReports.Click, AddressOf XpPanelReportsClicked

	//            'AddHandler lblStandardGraph.Click, AddressOf tlbbtnStandardGraph_Click
	//            'AddHandler lblSampleGraph.Click, AddressOf tlbbtnSampleGraph_Click
	//            'AddHandler lblViewResults.Click, AddressOf tlbbtnViewResults_Click
	//            'AddHandler lblReports.Click, AddressOf tlbbtnReports_Click

	//            'AddHandler btnStdGraph.Click, AddressOf tlbbtnStandardGraph_Click
	//            'AddHandler btnSplGraph.Click, AddressOf tlbbtnSampleGraph_Click
	//            'AddHandler btnViewResults.Click, AddressOf tlbbtnViewResults_Click
	//            'AddHandler btnReports.Click, AddressOf tlbbtnReports_Click
	//            'AddHandler btnSave.Click, AddressOf tlbbtnSave_Click
	//            'AddHandler btnPrintGraph.Click, AddressOf tlbbtnPrintGraph_Click
	//            'AddHandler btnImport.Click, AddressOf btnImport_Click
	//            AddHandler btnIgnite.Click, AddressOf btnIgnite_Click
	//            AddHandler btnExtinguish.Click, AddressOf btnExtinguish_Click
	//            'AddHandler btnN2OIgnite.Click, AddressOf btnN2OIgnite_Click
	//            'AddHandler btnDelete.Click, AddressOf btnDelete_Click
	//            'AddHandler btnR.Click, AddressOf btnR_Click

	//            'AddHandler PictureBoxStandardGraph.Click, AddressOf tlbbtnStandardGraph_Click
	//            'AddHandler PictureBoxSampleGraph.Click, AddressOf tlbbtnSampleGraph_Click
	//            'AddHandler PictureBoxViewResults.Click, AddressOf tlbbtnViewResults_Click
	//            'AddHandler PictureBoxReports.Click, AddressOf tlbbtnReports_Click

	//            'Invisible Menu Items
	//            AddHandler mnuBack.Click, AddressOf tlbbtnBack_Click
	//            AddHandler mnuStandardGraph.Click, AddressOf tlbbtnStandardGraph_Click
	//            AddHandler mnuSampleGraph.Click, AddressOf tlbbtnSampleGraph_Click
	//            AddHandler mnuViewResults.Click, AddressOf tlbbtnViewResults_Click
	//            AddHandler mnuReports.Click, AddressOf tlbbtnReports_Click

	//            '---Analysis function Buttons 
	//            'AddHandler tlbbtnNewAnalysis.Click, AddressOf NewAnalysis_Clicked
	//            'AddHandler tlbbtnBlankAnalysis.Click, AddressOf BlankAnalysis_Clicked
	//            'AddHandler tlbbtnNextAnalysis.Click, AddressOf NextAnalysis_Clicked
	//            'AddHandler tlbbtnRepeatLastAnalysis.Click, AddressOf RepeatLastAnalysis_Clicked
	//            'AddHandler tlbbtnReoptimiseInstrument.Click, AddressOf ReOptimizeInstrument_Clicked
	//            'AddHandler tlbbtnManualSetupInstrument.Click, AddressOf ManualSetup_Clicked
	//            'AddHandler tlbbtnAutoZero.Click, AddressOf AutoZero_Clicked

	//            AddHandler btnNewAnalysis.Click, AddressOf NewAnalysis_Clicked
	//            'AddHandler btnBlankAnalysis.Click, AddressOf BlankAnalysis_Clicked
	//            AddHandler btnNextAnalysis.Click, AddressOf NextAnalysis_Clicked
	//            'AddHandler btnRepeatLast.Click, AddressOf RepeatLastAnalysis_Clicked
	//            'AddHandler btnReoptimize.Click, AddressOf ReOptimizeInstrument_Clicked
	//            'AddHandler btnSetup.Click, AddressOf ManualSetup_Clicked
	//            'AddHandler btnAutoZero.Click, AddressOf AutoZero_Clicked

	//            'AddHandler btnEditData.Click, AddressOf btnEditData_Clicked

	//            '---Start/Stop Analysis and Read Data during Aspiration Event functions 
	//            AddHandler btnStartStopAnalysis.Click, AddressOf StartStopAnalysis_Click
	//            'AddHandler btnReadData.Click, AddressOf ReadData_Click
	//            'AddHandler tlbbtnStartAnalysis.Click, AddressOf StartStopAnalysis_Click
	//            'AddHandler tlbbtnReadAnalysis.Click, AddressOf ReadData_Click

	//            'AddHandler tlbbtnBack.Click, AddressOf tlbbtnBack_Click
	//            'AddHandler tlbbtnStandardGraph.Click, AddressOf tlbbtnStandardGraph_Click
	//            'AddHandler tlbbtnSampleGraph.Click, AddressOf tlbbtnSampleGraph_Click
	//            'AddHandler tlbbtnReports.Click, AddressOf tlbbtnReports_Click

	//            'AddHandler tlbbtnViewResults.Click, AddressOf tlbbtnViewResults_Click

	//            'AddHandler tmrAspirationMsg.Elapsed, AddressOf tmrAspirationMsg_Elapsed
	//            'AddHandler btnExportReport.Click, AddressOf btnExportReport_Click

	//            If blnIsAspirateTimer = False Then
	//                'AddHandler tmrAspirationMsg.Elapsed, AddressOf tmrAspirationMsg_Elapsed
	//                'tmrAspirationMsg.Enabled = True
	//                blnIsAspirateTimer = True
	//            End If
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

	//    'Private Sub tmrAspirationMsg_Elapsed(ByVal sender As System.Object, ByVal e As System.Timers.ElapsedEventArgs)
	//    '    '=====================================================================
	//    '    ' Procedure Name        : tmrAspirationMsg_Elapsed
	//    '    ' Parameters Passed     : sender As System.Object, System.Timers.ElapsedEventArgs
	//    '    ' Returns               : None
	//    '    ' Purpose               : Timer Aspiration Message events
	//    '    ' Description           : 
	//    '    ' Assumptions           : 
	//    '    ' Dependencies          : 
	//    '    ' Author                : Saurabh
	//    '    ' Created               : 05.10.06
	//    '    ' Revisions             : 
	//    '    '=====================================================================
	//    '    'case	WM_TIMER:
	//    '    '   tAsp++;
	//    '    '   If (tAsp > 1000) Then
	//    '    '       tAsp=1;
	//    '    '   if (tAsp%3==0)							
	//    '    '       ShowAspMessage(FALSE);
	//    '    '   Else
	//    '    '       ShowAspMessage(TRUE);
	//    '    'break;
	//    '    Try
	//    '        ' Application.DoEvents()
	//    '        mintAspirationTimerCounter += 1
	//    '        If (mintAspirationTimerCounter > 1000) Then
	//    '            mintAspirationTimerCounter = 1
	//    '        End If

	//    '        '---Saurabh---20.06.07
	//    '        'If btnReadData.Enabled = True Then
	//    '        '    btnReadData.Focus()
	//    '        '    btnReadData.Refresh()
	//    '        'End If
	//    '        'Application.DoEvents()
	//    '        'Saruabh

	//    '        If (mintAspirationTimerCounter Mod 3 = 0) Then
	//    '            If mblnIsBlinkMessage Then
	//    '                Call ShowAspirationMessages(False)
	//    '            Else
	//    '                Call ShowAspirationMessages(True)
	//    '            End If
	//    '            'Application.DoEvents()
	//    '        Else
	//    '            Call ShowAspirationMessages(True)
	//    '            'Application.DoEvents()
	//    '        End If
	//    '        'Application.DoEvents()
	//    '    Catch ex As Exception
	//    '        '---------------------------------------------------------
	//    '        'Error Handling and logging
	//    '        gobjErrorHandler.ErrorDescription = ex.Message
	//    '        gobjErrorHandler.ErrorMessage = ex.Message
	//    '        gobjErrorHandler.WriteErrorLog(ex)
	//    '        '---------------------------------------------------------
	//    '    Finally
	//    '        '---------------------------------------------------------
	//    '        'Writing Execution log
	//    '        If CONST_CREATE_EXECUTION_LOG = 1 Then
	//    '            gobjErrorHandler.WriteExecutionLog()
	//    '        End If
	//    '        '---------------------------------------------------------
	//    '    End Try
	//    'End Sub

	//    Private Sub tlbbtnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
	//        '=====================================================================
	//        ' Procedure Name        : tlbbtnBack_Click
	//        ' Parameters Passed     : Object,EventArgs
	//        ' Returns               : None
	//        ' Purpose               : To exit frmAnalysis and load frmMDIMain form
	//        ' Description           : 
	//        ' Assumptions           : 
	//        ' Dependencies          : 
	//        ' Author                : Saurabh S
	//        ' Created               : 25.09.06
	//        ' Revisions             : 
	//        '=====================================================================
	//        Dim objWait As New CWaitCursor
	//        Try
	//            'tlbbtnBack.SuspendEvents()
	//            Me.Close()

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
	//            If Not objWait Is Nothing Then
	//                objWait.Dispose()
	//            End If
	//            'tlbbtnBack.ResumeEvents()
	//            '---------------------------------------------------------
	//        End Try
	//    End Sub

	//    Private Sub tlbbtnStandardGraph_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
	//        '=====================================================================
	//        ' Procedure Name        : tlbbtnStandardGraph_Click
	//        ' Parameters Passed     : Object, EventArgs
	//        ' Returns               : None
	//        ' Purpose               : show the Standard graph
	//        ' Description           : 
	//        ' Assumptions           : 
	//        ' Dependencies          : 
	//        ' Author                : Mangesh Shardul
	//        ' Created               : 17-Jan-2007 03:25 pm
	//        ' Revisions             : 1
	//        '=====================================================================
	//        'case IDC_QASTDGRAPH:
	//        '   if (StdAnalysed || ManualEntry){
	//        '       If (Create_Standard_Sample_Curve(hwnd, False)) Then
	//        '           toreported=TRUE;
	//        '   }
	//        'break;

	//        Dim objWait As New CWaitCursor

	//        Try
	//            'tlbbtnStandardGraph.SuspendEvents()

	//            If StdAnalysed Then 'Or ManualEntry Then
	//                If gobjclsStandardGraph.Create_Standard_Sample_Curve(False, True, 0, 0, gobjNewMethod) Then
	//                    toreported = True
	//                End If
	//            End If
	//            If btnReadData.Enabled Then
	//                btnReadData.Focus()
	//                btnReadData.Refresh()
	//            End If
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
	//            objWait.Dispose()
	//            'tlbbtnStandardGraph.ResumeEvents()
	//            '---------------------------------------------------------
	//        End Try
	//    End Sub

	//    Private Sub tlbbtnSampleGraph_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
	//        '=====================================================================
	//        ' Procedure Name        : tlbbtnSampleGraph_Click
	//        ' Parameters Passed     : Object, EventArgs
	//        ' Returns               : None
	//        ' Purpose               : Show the Sample graph
	//        ' Description           : 
	//        ' Assumptions           : 
	//        ' Dependencies          : 
	//        ' Author                : Mangesh Shardul
	//        ' Created               : 17-Jan-2007 03:25 pm
	//        ' Revisions             : 1
	//        '=====================================================================
	//        'case IDC_QASAMPGRAPH:
	//        '   if (StdAnalysed || ManualEntry){
	//        '       If (Create_Standard_Sample_Curve(hwnd, TRUE)) Then
	//        '	        toreported=TRUE;
	//        '   }
	//        '   break;

	//        Dim objWait As New CWaitCursor

	//        Try
	//            'tlbbtnSampleGraph.SuspendEvents()

	//            If StdAnalysed Then 'Or ManualEntry Then
	//                If gobjclsStandardGraph.Create_Standard_Sample_Curve(True, True, 0, 0, gobjNewMethod) Then
	//                    toreported = True
	//                End If
	//            End If
	//            If btnReadData.Enabled Then
	//                btnReadData.Focus()
	//                btnReadData.Refresh()
	//            End If
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
	//            If Not objWait Is Nothing Then
	//                objWait.Dispose()
	//            End If
	//            'tlbbtnSampleGraph.ResumeEvents()
	//            '---------------------------------------------------------
	//        End Try
	//    End Sub

	//    Private Sub tlbbtnViewResults_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
	//        '=====================================================================
	//        ' Procedure Name        : tlbbtnViewResults_Click
	//        ' Parameters Passed     : Object, EventArgs
	//        ' Returns               : None
	//        ' Purpose               : View analysis report in Listview
	//        ' Description           : 
	//        ' Assumptions           : 
	//        ' Dependencies          : 
	//        ' Author                : Mangesh Shardul
	//        ' Created               : 17-Jan-2007 03:25 pm
	//        ' Revisions             : 1
	//        '=====================================================================
	//        'case IDC_QARESULTS:
	//        'if (StdAnalysed||AnaOver ||Started ||ManualEntry)
	//        ' OnViewResults(hwnd);
	//        'break;

	//        Dim objWait As New CWaitCursor

	//        Try
	//            'tlbbtnViewResults.SuspendEvents()
	//            ' View analysis report in Listview if analysis is complite
	//            If StdAnalysed Or AnaOver Or mblnIsAnalysisStarted Then 'Or ManualEntry Then
	//                OnViewResults()
	//            End If
	//            If btnReadData.Enabled Then
	//                btnReadData.Focus()
	//                btnReadData.Refresh()
	//            End If
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
	//            If Not objWait Is Nothing Then
	//                objWait.Dispose()
	//            End If
	//            'tlbbtnViewResults.ResumeEvents()
	//            '---------------------------------------------------------
	//        End Try
	//    End Sub

	//    Private Sub tlbbtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
	//        '=====================================================================
	//        ' Procedure Name        : tlbbtnReports_Click
	//        ' Parameters Passed     : Object, EventArgs
	//        ' Returns               : None
	//        ' Purpose               : Save the Quant. analysis result 
	//        ' Description           : 
	//        ' Assumptions           : 
	//        ' Dependencies          : 
	//        ' Author                : Mangesh Shardul
	//        ' Created               : 17-Jan-2007 03:25 pm
	//        ' Revisions             : 1
	//        '=====================================================================

	//        'case IDC_QAREPORT:
	//        '   if (toreported||!Method->RepReady )
	//        '	{
	//        '	    SaveQuantResults(hwnd, Method, A1,0);
	//        '	    toreported=FALSE;
	//        '	}
	//        '	if (Method->RepReady )
	//        '	    OnReportPrint(hwnd, Method);
	//        '   break;

	//        Dim objWait As New CWaitCursor
	//        Dim A1() As Double = {0, 0, 0, 0, 0, 0}

	//        Try
	//            ' check "toreported" to store the report of quantity result
	//            If (toreported) Then 'OR NOT Method->RepReady )
	//                'Save the Quant. data result into Method Data object
	//                If gobjClsAAS203.SaveQuantResults(gobjNewMethod, A1, 0, False) = True Then

	//                    'Onecs data result is store  then
	//                    ' toreported var. is set to false to avoide resundancy of data storing
	//                    'toreported = False
	//                    mblnIsStartRunNumber = True
	//                End If
	//                toreported = False
	//            End If

	//            If btnReadData.Enabled Then
	//                btnReadData.Focus()
	//                btnReadData.Refresh()
	//            End If
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
	//            If Not objWait Is Nothing Then
	//                objWait.Dispose()
	//            End If
	//            'tlbbtnReports.ResumeEvents()
	//            '---------------------------------------------------------
	//        End Try
	//    End Sub

	//    Private Sub tlbbtnReports_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
	//        '=====================================================================
	//        ' Procedure Name        : tlbbtnReports_Click
	//        ' Parameters Passed     : Object, EventArgs
	//        ' Returns               : None
	//        ' Purpose               : Show the Analysis Report
	//        ' Description           : 
	//        ' Assumptions           : 
	//        ' Dependencies          : 
	//        ' Author                : Mangesh Shardul
	//        ' Created               : 17-Jan-2007 03:25 pm
	//        ' Revisions             : 1
	//        '=====================================================================

	//        'case IDC_QAREPORT:
	//        '   if (toreported||!Method->RepReady )
	//        '	{
	//        '	    SaveQuantResults(hwnd, Method, A1,0);
	//        '	    toreported=FALSE;
	//        '	}
	//        '	if (Method->RepReady )
	//        '	    OnReportPrint(hwnd, Method);
	//        '   break;

	//        Dim objWait As New CWaitCursor
	//        Dim objClsDataFileReport As New clsDataFileReport
	//        Dim intSelectIDIndex As Integer
	//        Dim intCount As Integer
	//        Dim intSelectedRunNumber As Integer
	//        Dim intSelectedMethodID As Integer
	//        Dim A1() As Double = {0, 0, 0, 0, 0, 0}

	//        Try

	//            'If toreported Then
	//            ' Check 21 CFR 
	//            '-----Added By Pankaj Fri 18 May 07
	//            If (gstructSettings.Enable21CFR = True) Then
	//                If Not funcCheckActivityAuthentication(enumActivityAuthentication.Print, gstructUserDetails.Access) Then
	//                    Return
	//                    Exit Sub
	//                End If
	//                gfuncInsertActivityLog(EnumModules.Print, "Print Analysis Report Accessed")
	//            End If
	//            '------
	//            'tlbbtnLoad.SuspendEvents()
	//            ' Save Quant analysis data
	//            If (toreported) Then 'OR NOT Method->RepReady )
	//                If gobjClsAAS203.SaveQuantResults(gobjNewMethod, A1, 1, False) = True Then
	//                    mblnIsStartRunNumber = True
	//                End If
	//                toreported = False
	//                'mblnIsStartRunNumber = True
	//            End If


	//            '----Be Careful NOT TO USE index to assign MethodID or RunNumber

	//            If StdAnalysed Or AnaOver Or mblnIsAnalysisStarted Then
	//                If Not (gobjNewMethod Is Nothing) Then
	//                    For intCount = 0 To gobjMethodCollection.Count - 1
	//                        If gobjNewMethod.MethodID = gobjMethodCollection(intCount).MethodID Then
	//                            intSelectIDIndex = intCount
	//                            'mobjClsDataFileReport.MethodID = intCount
	//                            objClsDataFileReport.MethodID = gobjMethodCollection(intCount).MethodID
	//                            Exit For
	//                        End If
	//                    Next

	//                    objClsDataFileReport.RunNumber = gobjMethodCollection(intCount).QuantitativeDataCollection(mintRunNumberIndex).RunNumber   'intSelectedRunNumber - 1

	//                    objClsDataFileReport.DefaultFont = Me.DefaultFont
	//                    ' print data report from Data file report object
	//                    Call objClsDataFileReport.funcDatafilePrint()
	//                End If
	//            End If
	//            If btnReadData.Enabled Then
	//                btnReadData.Focus()
	//                btnReadData.Refresh()
	//            End If
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
	//            If Not objWait Is Nothing Then
	//                objWait.Dispose()
	//            End If
	//            'tlbbtnReports.ResumeEvents()
	//            '---------------------------------------------------------
	//        End Try
	//    End Sub

	//    Private Sub tlbbtnPrintGraph_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
	//        '=====================================================================
	//        ' Procedure Name        : tlbbtnPrintGraph_Click
	//        ' Parameters Passed     : Object, EventArgs
	//        ' Returns               : None
	//        ' Purpose               : Print the Histograph
	//        ' Description           : 
	//        ' Assumptions           : 
	//        ' Dependencies          : 
	//        ' Author                : Sachin Dokhale
	//        ' Created               : 17-May-2007 03:25 pm
	//        ' Revisions             : 1
	//        '=====================================================================



	//        Dim objWait As New CWaitCursor
	//        Dim A1() As Double = {0, 0, 0, 0, 0, 0}

	//        Try
	//            ' Check for 21 CFR 
	//            '-----Added By Pankaj Fri 18 May 07
	//            If (gstructSettings.Enable21CFR = True) Then
	//                If Not funcCheckActivityAuthentication(enumActivityAuthentication.Print, gstructUserDetails.Access) Then
	//                    Return
	//                    Exit Sub
	//                End If
	//                gfuncInsertActivityLog(EnumModules.Print, "Print Analysis Graph Accessed")
	//            End If
	//            '------

	//            'If (toreported) Then 'OR NOT Method->RepReady )
	//            '    gobjClsAAS203.SaveQuantResults(gobjNewMethod, A1, False)
	//            '    toreported = False

	//            'End If
	//            'If StdAnalysed Or AnaOver Or mblnIsAnalysisStarted Then By Sachin
	//            'AASGraphAnalysis.PrintPreViewGraph()
	//            '-----Added By Pankaj Fri 14 Aug 07
	//            Dim mintRunNumberIndex As Integer
	//            'Print the Histograph
	//            '---For Data Files Mode
	//            mintRunNumberIndex = gobjNewMethod.QuantitativeDataCollection.Count - 1
	//            mobjClsDataFileReport.RunNumber = gobjNewMethod.QuantitativeDataCollection(mintRunNumberIndex).RunNumber
	//            mobjClsDataFileReport.DefaultFont = Me.DefaultFont
	//            'Call mobjClsDataFileReport.funcHistographPrint(AASGraphAnalysis, gobjNewMethod)
	//            '------------

	//            If btnReadData.Enabled Then
	//                btnReadData.Focus()
	//                btnReadData.Refresh()
	//            End If
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
	//            If Not objWait Is Nothing Then
	//                objWait.Dispose()
	//            End If
	//            'tlbbtnSampleGraph.ResumeEvents()
	//            '---------------------------------------------------------
	//        End Try
	//    End Sub

	//    'Private Sub XpPanelStandardGraphClicked(ByVal sender As Object, ByVal e As System.EventArgs)
	//    '    '=====================================================================
	//    '    ' Procedure Name        : XpPanelStandardGraphClicked
	//    '    ' Parameters Passed     : Object,EventArgs
	//    '    ' Returns               : None
	//    '    ' Purpose               : To load the Standard Graph form
	//    '    ' Description           : 
	//    '    ' Assumptions           : 
	//    '    ' Dependencies          : 
	//    '    ' Author                : Deepak & Saurabh
	//    '    ' Created               : 05.10.06
	//    '    ' Revisions             : 
	//    '    '===================================================================== 
	//    '    Dim objWait As New CWaitCursor

	//    '    Try
	//    '        If Me.XpPanelStandardGraph.PanelState = UIComponents.XPPanelState.Collapsed Then
	//    '            Call funcCollapseAllXPPanels()
	//    '            Me.XpPanelStandardGraph.TogglePanelState()
	//    '            Me.XpPanelStandardGraph.PanelHeight = 80
	//    '        End If

	//    '    Catch ex As Exception
	//    '        '---------------------------------------------------------
	//    '        'Error Handling and logging
	//    '        gobjErrorHandler.ErrorDescription = ex.Message
	//    '        gobjErrorHandler.ErrorMessage = ex.Message
	//    '        gobjErrorHandler.WriteErrorLog(ex)
	//    '        '---------------------------------------------------------
	//    '    Finally
	//    '        '---------------------------------------------------------
	//    '        'Writing Execution log
	//    '        If CONST_CREATE_EXECUTION_LOG = 1 Then
	//    '            gobjErrorHandler.WriteExecutionLog()
	//    '        End If
	//    '        If Not objWait Is Nothing Then
	//    '            objWait.Dispose()
	//    '        End If
	//    '        '---------------------------------------------------------
	//    '    End Try
	//    'End Sub

	//    'Private Sub XpPanelSampleGraphClicked(ByVal sender As Object, ByVal e As System.EventArgs)
	//    '    '=====================================================================
	//    '    ' Procedure Name        : XpPanelSampleGraphClicked
	//    '    ' Parameters Passed     : Object,EventArgs
	//    '    ' Returns               : None
	//    '    ' Purpose               : To view the Sample Graphs
	//    '    ' Description           : 
	//    '    ' Assumptions           : 
	//    '    ' Dependencies          : 
	//    '    ' Author                : Deepak & Saurabh
	//    '    ' Created               : 05.10.06
	//    '    ' Revisions             : 
	//    '    '===================================================================== 
	//    '    Dim objWait As New CWaitCursor

	//    '    Try
	//    '        If Me.XpPanelSampleGraph.PanelState = UIComponents.XPPanelState.Collapsed Then
	//    '            Call funcCollapseAllXPPanels()
	//    '            Me.XpPanelSampleGraph.TogglePanelState()
	//    '            Me.XpPanelSampleGraph.PanelHeight = 90
	//    '        End If

	//    '    Catch ex As Exception
	//    '        '---------------------------------------------------------
	//    '        'Error Handling and logging
	//    '        gobjErrorHandler.ErrorDescription = ex.Message
	//    '        gobjErrorHandler.ErrorMessage = ex.Message
	//    '        gobjErrorHandler.WriteErrorLog(ex)
	//    '        '---------------------------------------------------------
	//    '    Finally
	//    '        '---------------------------------------------------------
	//    '        'Writing Execution log
	//    '        If CONST_CREATE_EXECUTION_LOG = 1 Then
	//    '            gobjErrorHandler.WriteExecutionLog()
	//    '        End If
	//    '        If Not objWait Is Nothing Then
	//    '            objWait.Dispose()
	//    '        End If
	//    '        '---------------------------------------------------------
	//    '    End Try
	//    'End Sub

	//    'Private Sub XpPanelViewResultsClicked(ByVal sender As Object, ByVal e As System.EventArgs)
	//    '    '=====================================================================
	//    '    ' Procedure Name        : XpPanelViewResultsClicked
	//    '    ' Parameters Passed     : Object,EventArgs
	//    '    ' Returns               : None
	//    '    ' Purpose               : To view the Results
	//    '    ' Description           : 
	//    '    ' Assumptions           : 
	//    '    ' Dependencies          : 
	//    '    ' Author                : Deepak & Saurabh
	//    '    ' Created               : 05.10.06
	//    '    ' Revisions             : 
	//    '    '===================================================================== 
	//    '    Dim objWait As New CWaitCursor

	//    '    Try
	//    '        If Me.XpPanelViewResults.PanelState = UIComponents.XPPanelState.Collapsed Then
	//    '            Call funcCollapseAllXPPanels()
	//    '            Me.XpPanelViewResults.TogglePanelState()
	//    '            Me.XpPanelViewResults.PanelHeight = 80
	//    '        End If

	//    '    Catch ex As Exception
	//    '        '---------------------------------------------------------
	//    '        'Error Handling and logging
	//    '        gobjErrorHandler.ErrorDescription = ex.Message
	//    '        gobjErrorHandler.ErrorMessage = ex.Message
	//    '        gobjErrorHandler.WriteErrorLog(ex)
	//    '        '---------------------------------------------------------
	//    '    Finally
	//    '        '---------------------------------------------------------
	//    '        'Writing Execution log
	//    '        If CONST_CREATE_EXECUTION_LOG = 1 Then
	//    '            gobjErrorHandler.WriteExecutionLog()
	//    '        End If
	//    '        If Not objWait Is Nothing Then
	//    '            objWait.Dispose()
	//    '        End If
	//    '        '---------------------------------------------------------
	//    '    End Try
	//    'End Sub

	//    'Private Sub XpPanelReportsClicked(ByVal sender As Object, ByVal e As System.EventArgs)
	//    '    '=====================================================================
	//    '    ' Procedure Name        : XpPanelReportsClicked
	//    '    ' Parameters Passed     : Object,EventArgs
	//    '    ' Returns               : None
	//    '    ' Purpose               : To view the Reports
	//    '    ' Description           : 
	//    '    ' Assumptions           : 
	//    '    ' Dependencies          : 
	//    '    ' Author                : Deepak & Saurabh
	//    '    ' Created               : 05.10.06
	//    '    ' Revisions             : 
	//    '    '===================================================================== 
	//    '    Dim objWait As New CWaitCursor
	//    '    Try
	//    '        If Me.XpPanelReports.PanelState = UIComponents.XPPanelState.Collapsed Then
	//    '            Call funcCollapseAllXPPanels()
	//    '            Me.XpPanelReports.TogglePanelState()
	//    '            Me.XpPanelReports.PanelHeight = 80
	//    '        End If

	//    '    Catch ex As Exception
	//    '        '---------------------------------------------------------
	//    '        'Error Handling and logging
	//    '        gobjErrorHandler.ErrorDescription = ex.Message
	//    '        gobjErrorHandler.ErrorMessage = ex.Message
	//    '        gobjErrorHandler.WriteErrorLog(ex)
	//    '        '---------------------------------------------------------
	//    '    Finally
	//    '        '---------------------------------------------------------
	//    '        'Writing Execution log
	//    '        If CONST_CREATE_EXECUTION_LOG = 1 Then
	//    '            gobjErrorHandler.WriteExecutionLog()
	//    '        End If
	//    '        If Not objWait Is Nothing Then
	//    '            objWait.Dispose()
	//    '        End If
	//    '        '---------------------------------------------------------
	//    '    End Try
	//    'End Sub

	//    Private Sub AutoZero_Clicked(ByVal sender As System.Object, ByVal e As System.EventArgs)
	//        '=====================================================================
	//        ' Procedure Name        : AutoZero_Clicked
	//        ' Parameters Passed     : Object, EventArgs
	//        ' Returns               : None
	//        ' Purpose               : Start to Autozero
	//        ' Description           : 
	//        ' Assumptions           : 
	//        ' Dependencies          : 
	//        ' Author                : Mangesh Shardul
	//        ' Created               : 17-Jan-2007 03:25 pm
	//        ' Revisions             : 1
	//        '=====================================================================

	//        'case IDC_AUTOZERO:
	//        '   Auto_Zero(hwnd, FALSE);
	//        '   break;
	//        If mblnAvoidProcessing = True Then
	//            Exit Sub
	//        End If
	//        Try
	//            mblnAvoidProcessing = True
	//            '//----- Commented by Sachin Dokhale
	//            '//----- use Thread except timer for apirate message
	//            'tmrAspirationMsg.Enabled = False
	//            mobjBgMsgAspirate.Cancel()
	//            IsDisplayingMessage = mobjBgMsgAspirate.IsMessageRunning
	//            'If gobjMain.mobjController.IsThreadRunning = True Then  '10.12.07
	//            gobjMain.mobjController.Cancel()
	//            gobjCommProtocol.mobjCommdll.subTime_Delay(500)   '10.12.07
	//            Application.DoEvents()
	//            'End If

	//            'Start to Autozero Set bool flag to False
	//            Call gobjClsAAS203.subAutoZero(False)

	//            mobjBgMsgAspirate.Start()
	//            IsDisplayingMessage = mobjBgMsgAspirate.IsMessageRunning
	//            If gobjMain.mobjController.IsThreadRunning = False Then
	//                gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay)
	//                Application.DoEvents()
	//                gobjMain.mobjController.Start(gobjclsBgFlameStatus)
	//            End If
	//            If btnReadData.Enabled Then
	//                btnReadData.Focus()
	//                btnReadData.Refresh()
	//            End If
	//            mblnAvoidProcessing = False
	//        Catch ex As Exception
	//            '---------------------------------------------------------
	//            'Error Handling and logging
	//            gobjErrorHandler.ErrorDescription = ex.Message
	//            gobjErrorHandler.ErrorMessage = ex.Message
	//            gobjErrorHandler.WriteErrorLog(ex)
	//            '---------------------------------------------------------
	//            mblnAvoidProcessing = False
	//        Finally
	//            '---------------------------------------------------------
	//            'Writing Execution log
	//            If CONST_CREATE_EXECUTION_LOG = 1 Then
	//                gobjErrorHandler.WriteExecutionLog()
	//            End If
	//            '//----- Commented by Sachin Dokhale
	//            '//----- use Thread except timer for apirate message
	//            'tmrAspirationMsg.Enabled = True

	//            'mblnAvoidProcessing = False
	//            Application.DoEvents()
	//            '---------------------------------------------------------
	//        End Try
	//    End Sub

	//    Private Sub ManualSetup_Clicked(ByVal sender As System.Object, ByVal e As System.EventArgs)
	//        '=====================================================================
	//        ' Procedure Name        : ManualSetup_Clicked
	//        ' Parameters Passed     : Object, EventArgs
	//        ' Returns               : None
	//        ' Purpose               : Manual Setup of instrument
	//        ' Description           : 
	//        ' Assumptions           : 
	//        ' Dependencies          : 
	//        ' Author                : Mangesh Shardul
	//        ' Created               : 17-Jan-2007 03:25 pm
	//        ' Revisions             : 1
	//        '=====================================================================
	//        If mblnAvoidProcessing = True Then
	//            Exit Sub
	//        End If
	//        Try
	//            '//----- Commented by Sachin Dokhale
	//            '//----- use Thread except timer for apirate message
	//            'tmrAspirationMsg.Enabled = False
	//            mblnAvoidProcessing = True
	//            mobjBgMsgAspirate.Cancel()
	//            gobjclsTimer.subTimerStop()
	//            IsDisplayingMessage = mobjBgMsgAspirate.IsMessageRunning
	//            'If gobjMain.mobjController.IsThreadRunning = True Then
	//            gobjMain.mobjController.Cancel()
	//            gobjCommProtocol.mobjCommdll.subTime_Delay(500)   '10.12.07
	//            Application.DoEvents()
	//            'End If


	//            '---Manual Optimization or Instrument Setup
	//            Call gobjClsAAS203.AbsorbanceScan()

	//            'gobjclsTimer.subTimerStart(StatusBar1)
	//            'mblnAvoidProcessing = False

	//            mobjBgMsgAspirate.Start()
	//            IsDisplayingMessage = mobjBgMsgAspirate.IsMessageRunning
	//            'gobjclsTimer.subTimerStart()
	//            'mblnAvoidProcessing = False
	//            '//-----
	//            If gobjMain.mobjController.IsThreadRunning = False Then
	//                gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay)
	//                Application.DoEvents()
	//                gobjMain.mobjController.Start(gobjclsBgFlameStatus)
	//            End If
	//            If btnReadData.Enabled Then
	//                btnReadData.Focus()
	//                btnReadData.Refresh()
	//            End If
	//            If gobjclsTimer.TimerStatus = False Then
	//                gobjclsTimer.subTimerStart(gobjMain.StatusBar1)
	//            End If
	//            mblnAvoidProcessing = False
	//        Catch ex As Exception
	//            '---------------------------------------------------------
	//            'Error Handling and logging
	//            gobjErrorHandler.ErrorDescription = ex.Message
	//            gobjErrorHandler.ErrorMessage = ex.Message
	//            gobjErrorHandler.WriteErrorLog(ex)
	//            '---------------------------------------------------------
	//            mblnAvoidProcessing = False
	//        Finally
	//            '---------------------------------------------------------
	//            'Writing Execution log
	//            If CONST_CREATE_EXECUTION_LOG = 1 Then
	//                gobjErrorHandler.WriteExecutionLog()
	//            End If
	//            '//----- Commented by Sachin Dokhale
	//            '//----- use Thread except timer for apirate message
	//            'tmrAspirationMsg.Enabled = True

	//            Application.DoEvents()
	//            '---------------------------------------------------------
	//        End Try
	//    End Sub

	//    Private Sub ReOptimizeInstrument_Clicked(ByVal sender As System.Object, ByVal e As System.EventArgs)
	//        '=====================================================================
	//        ' Procedure Name        : ReOptimizeInstrument_Clicked
	//        ' Parameters Passed     : Object, EventArgs
	//        ' Returns               : None
	//        ' Purpose               : ReOptimize Wavelength i.e. Find Analytical Peak Again
	//        ' Description           : 
	//        ' Assumptions           : 
	//        ' Dependencies          : 
	//        ' Author                : Mangesh Shardul
	//        ' Created               : 17-Jan-2007 03:25 pm
	//        ' Revisions             : 1
	//        '=====================================================================
	//        '---ReOptimize Wavelength i.e. Find Analytical Peak Again
	//        'case IDC_OPTIMIZE:
	//        '   Method->Aas.OptimseFlag=FALSE;
	//        '   CheckInstrumentOptimisation(hwnd);
	//        '   break;
	//        If mblnAvoidProcessing = True Then
	//            Exit Sub
	//        End If
	//        Try
	//            mblnAvoidProcessing = True
	//            '//----- Commented by Sachin Dokhale
	//            '//----- use Thread except timer for apirate message
	//            'tmrAspirationMsg.Enabled = False
	//            mobjBgMsgAspirate.Cancel()
	//            IsDisplayingMessage = mobjBgMsgAspirate.IsMessageRunning
	//            '//-----
	//            'If gobjMain.mobjController.IsThreadRunning = True Then
	//            gobjMain.mobjController.Cancel()
	//            gobjCommProtocol.mobjCommdll.subTime_Delay(500)   '10.12.07
	//            Application.DoEvents()
	//            'End If

	//            'gobjNewMethod.InstrumentConditions.item(mintSelectedInstrumentConditionIndex).IsOptimize = False
	//            gobjNewMethod.InstrumentCondition.IsOptimize = False
	//            ' Start to find Analytical Peak 
	//            Call CheckInstrumentOptimisation()
	//            mobjBgMsgAspirate.Start()
	//            IsDisplayingMessage = mobjBgMsgAspirate.IsMessageRunning

	//            '//-----
	//            'start flame status thread
	//            If gobjMain.mobjController.IsThreadRunning = False Then
	//                gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay)
	//                Application.DoEvents()
	//                gobjMain.mobjController.Start(gobjclsBgFlameStatus)
	//            End If
	//            If btnReadData.Enabled Then
	//                btnReadData.Focus()
	//                btnReadData.Refresh()
	//            End If
	//            mblnAvoidProcessing = False
	//        Catch ex As Exception
	//            '---------------------------------------------------------
	//            'Error Handling and logging
	//            gobjErrorHandler.ErrorDescription = ex.Message
	//            gobjErrorHandler.ErrorMessage = ex.Message
	//            gobjErrorHandler.WriteErrorLog(ex)
	//            '---------------------------------------------------------
	//            mblnAvoidProcessing = False
	//        Finally
	//            '---------------------------------------------------------
	//            'Writing Execution log
	//            If CONST_CREATE_EXECUTION_LOG = 1 Then
	//                gobjErrorHandler.WriteExecutionLog()
	//            End If
	//            '//----- Commented by Sachin Dokhale
	//            '//----- use Thread except timer for apirate message
	//            'tmrAspirationMsg.Enabled = True

	//            Application.DoEvents()
	//            '---------------------------------------------------------
	//        End Try
	//    End Sub

	//    Private Sub RepeatLastAnalysis_Clicked(ByVal sender As System.Object, ByVal e As System.EventArgs)
	//        '=====================================================================
	//        ' Procedure Name        : RepeatLastAnalysis_Clicked
	//        ' Parameters Passed     : Object, EventArgs
	//        ' Returns               : None
	//        ' Purpose               : Repat the last analysis
	//        ' Description           : 
	//        ' Assumptions           : 
	//        ' Dependencies          : 
	//        ' Author                : Mangesh Shardul
	//        ' Created               : 17-Jan-2007 03:25 pm
	//        ' Revisions             : 1
	//        '=====================================================================
	//        '**************************************************************
	//        'case IDC_QARPT:
	//        '   if(LSampType != BLANK )
	//        '	    CurRepeat--;
	//        '	if(CurRepeat <= 0 ){
	//        '	    if(LSampType == SAMP)
	//        '		    CurRepeat = Method->QuantData->Param.Repeat; //mdf by sss
	//        '		if(LSampType == STD)
	//        '		    CurRepeat = Method->QuantData->Param.ConcRepeat; //mdf by sss
	//        '	}
	//        '	if (SampType==BLANK && LSampType==BLANK){
	//        '	    if (CurStd==NULL){
	//        '		    SampType=SAMP;
	//        '       }
	//        '		else{
	//        '		    SampType=STD;
	//        '       }
	//        '   }
	//        '	else{
	//        '	    SampType=LSampType;
	//        '	}
	//        '	if (SampType==SAMP){
	//        '       CurSamp = GetPrevSamp(Method->QuantData->SampTopData, CurSamp);
	//        '	}
	//        '	if (SampType==STD)
	//        '	    CurStd = GetPrevStd(Method->QuantData->StdTopData, CurStd);
	//        '	if (SampType==BLANK){
	//        '	    if (CurStd==NULL)
	//        '		    LSampType=SAMP;
	//        '       Else
	//        '		    LSampType=BLANK;
	//        '	}
	//        '	else
	//        '	    LSampType=BLANK;
	//        'EnableWindow(GetDlgItem(hwnd,IDC_QARPT),FALSE);
	//        '**************************************************************
	//        If mblnAvoidProcessing = True Then
	//            Exit Sub
	//        End If
	//        Try
	//            mblnAvoidProcessing = True
	//            'Added By Pankaj on 11 Jun 07 
	//            'If intIEnumCollLocationSamp > 0 Then
	//            '    If funcMoveSampleEnumerator(mobjSampleEnumerator, intIEnumCollLocationSamp) = True Then
	//            '        mobjCurrentSample = CType(mobjSampleEnumerator.Current, Method.clsAnalysisSampleParameters)
	//            '    End If
	//            'End If
	//            'If intIEnumCollLocationStd > 0 Then
	//            '    If funcMoveEnumerator(mobjStandardEnumerator, intIEnumCollLocationStd) = True Then
	//            '        mobjCurrentStandard = CType(mobjStandardEnumerator.Current, Method.clsAnalysisStdParameters)
	//            '    End If
	//            'End If
	//            'Call funcRefreshEnumerators(mobjStandardEnumerator, mobjSampleEnumerator)

	//            '-----
	//            ' last sample type is not Blank then Set the previous no for current repeat
	//            If (LSampType <> ClsAAS203.enumSampleType.BLANK) Then
	//                CurRepeat -= 1
	//            End If

	//            If (CurRepeat <= 0) Then
	//                If (LSampType = ClsAAS203.enumSampleType.SAMPLE) Then
	//                    'CurRepeat = Method->QuantData->Param.Repeat
	//                    CurRepeat = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfSampleRepeats
	//                End If
	//                If (LSampType = ClsAAS203.enumSampleType.STANDARD) Then
	//                    'CurRepeat = Method->QuantData->Param.ConcRepeat
	//                    CurRepeat = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfStdRepeats
	//                End If
	//            End If

	//            If (SampleType = ClsAAS203.enumSampleType.BLANK _
	//             And LSampType = ClsAAS203.enumSampleType.BLANK) Then

	//                If IsNothing(mobjCurrentStandard) Then
	//                    SampleType = ClsAAS203.enumSampleType.SAMPLE
	//                Else
	//                    SampleType = ClsAAS203.enumSampleType.STANDARD
	//                End If

	//            Else
	//                SampleType = LSampType
	//            End If
	//            '//--------
	//            ' Get previous Sample from method object
	//            '//------------
	//            If (SampleType = ClsAAS203.enumSampleType.SAMPLE) Then
	//                'mobjCurrentSample = GetPrevSamp(Method->QuantData->SampTopData, mobjCurrentSample  )
	//                'If Not (mobjCurrentSample Is Nothing) Then
	//                '    mobjCurrentSample = GetPrevSamp(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection, mobjCurrentSample)
	//                'Else
	//                '    Dim intSampColl As Integer
	//                '    intSampColl = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.Count
	//                '    If intSampColl > 0 Then
	//                '        mobjCurrentSample = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection(intSampColl - 1)
	//                '    End If
	//                'End If
	//                mobjCurrentSample = GetPrevSamp(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection, mobjLastSampleData)
	//                'mobjCurrentSample = GetPrevSamp(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection, mobjCurrentSample)
	//                mblnRepeatLastSample = True
	//            End If
	//            ' Get previous stadard from method object
	//            If (SampleType = ClsAAS203.enumSampleType.STANDARD) Then
	//                'mobjCurrentStandard = GetPrevStd(Method->QuantData->StdTopData,  mobjCurrentStandard )
	//                'If Not (mobjCurrentStandard Is Nothing) Then
	//                '    mobjCurrentStandard = GetPrevStd(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection, mobjLastStandardData)
	//                'Else
	//                '    Dim intStdColl As Integer
	//                '    intStdColl = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.Count
	//                '    If intStdColl > 0 Then
	//                '        mobjCurrentStandard = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection(intStdColl - 1)
	//                '    End If
	//                'End If
	//                mobjCurrentStandard = GetPrevStd(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection, mobjLastStandardData)

	//                mblnRepeatLastStd = True
	//            End If

	//            If (SampleType = ClsAAS203.enumSampleType.BLANK) Then
	//                If IsNothing(mobjCurrentStandard) Then
	//                    LSampType = ClsAAS203.enumSampleType.SAMPLE
	//                Else
	//                    LSampType = ClsAAS203.enumSampleType.BLANK
	//                End If
	//            Else
	//                LSampType = ClsAAS203.enumSampleType.BLANK
	//            End If

	//            'EnableWindow(GetDlgItem(hwnd,IDC_QARPT),FALSE);

	//            'tlbbtnRepeatLastAnalysis.Enabled = False
	//            'btnRepeatLast.Enabled = False

	//            Call Aspirate()
	//            If btnReadData.Enabled Then
	//                btnReadData.Focus()
	//                btnReadData.Refresh()
	//            End If
	//            mblnAvoidProcessing = False
	//        Catch ex As Exception
	//            '---------------------------------------------------------
	//            'Error Handling and logging
	//            gobjErrorHandler.ErrorDescription = ex.Message
	//            gobjErrorHandler.ErrorMessage = ex.Message
	//            gobjErrorHandler.WriteErrorLog(ex)
	//            '---------------------------------------------------------
	//            mblnAvoidProcessing = False
	//        Finally
	//            '---------------------------------------------------------
	//            'Writing Execution log
	//            If CONST_CREATE_EXECUTION_LOG = 1 Then
	//                gobjErrorHandler.WriteExecutionLog()
	//            End If
	//            '---------------------------------------------------------
	//        End Try
	//    End Sub

	//    'Private Sub NewAnalysis_Clicked(ByVal sender As System.Object, ByVal e As System.EventArgs)
	//    '    'case	IDC_QANEW:
	//    '    '#If STD_ADDN Then
	//    '    '   endanalysis= FALSE;
	//    '    '#End If
	//    '    'DeleteAllRawData(FALSE);
	//    '    'mobjCurrentStandard  =Method->QuantData->StdTopData;
	//    '    'mobjCurrentSample =Method->QuantData->SampTopData;
	//    '    'CurRepeat=1;

	//    '    'if(mobjCurrentStandard!=NULL  && StdAnalysed)
	//    '    '{
	//    '    '   if(Method->QuantData->Param.Std_Addn)
	//    '    '	    i = IDNO;
	//    '    '	else{
	//    '    '       If (!methchange) Then        
	//    '    '		    i=MessageBox(hwnd,"Do you want to use the previous standards","INFORMATION", MB_ICONQUESTION | MB_YESNO);
	//    '    '		else
	//    '    '		    i=IDNO;
	//    '    '   }
	//    '    'if(i==IDNO)
	//    '    '   Clear_All_Abs_Std(Method->QuantData->StdTopData);
	//    '    'Else
	//    '    '   mobjCurrentStandard=NULL;
	//    '    '}
	//    '    'methchange = FALSE;	
	//    '    'if(!StdAnalysed) 
	//    '    '   Clear_All_Abs_Std(Method->QuantData->StdTopData);
	//    '    'Clear_All_Abs_Conc_Samp(Method->QuantData->SampTopData);
	//    '    'SampType=BLANK;
	//    '    'Xtime=0;Afirst=TRUE;
	//    '    '	
	//    '    'if(i==6)
	//    '    '   StdAnalysed =TRUE;
	//    '    'Else
	//    '    '	StdAnalysed =FALSE;
	//    '    'Method->RepReady=FALSE;
	//    '    'if (lParam!=100L){
	//    '    '   AppendMethod(Method, QALL);
	//    '    '	Method->QuantData->Fname =-1.0;
	//    '    '}
	//    '    'if (Method->QuantData->Fname<=0)
	//    '    '   GetRunNo(Method);
	//    '    'AnaGraph.Xmin=0; AnaGraph.Xmax=10*10.0;
	//    '    'Calculate_Analysis_Graph_Param(&AnaGraph);
	//    '    'AnaOver=FALSE;
	//    '    'if (hwnd){
	//    '    '   DisplayRunNo(hwnd);
	//    '    '	InvalidateRect(hwnd, NULL, TRUE);
	//    '    '}
	//    '    'Method->QuantData->cMode=-2;

	//    '    'EnableWindow(GetDlgItem(hwnd,IDC_QARPT),FALSE); // add by sss
	//    '    'if(Method->QuantData)
	//    '    '   aafname = Method->QuantData->Fname;
	//    '    'break;

	//    '    '*****************************************
	//    '    '---CODE BY MANGESH 
	//    '    '*****************************************
	//    '    'On NEW Analysis
	//    '    Dim dblFuelRatio As Double
	//    '    Dim objDlgResult As DialogResult

	//    '    Try
	//    '        '----added by deepak for new analysis on 28.04.07
	//    '        lblAbsorbance.Text = ""
	//    '        lblAverageAbsorbance.Text = ""
	//    '        lblCorrectedAbsorbance.Text = ""
	//    '        lblSampleID.Text = ""
	//    '        lblRepeatNo.Text = ""
	//    '        lblConcentration.Text = ""
	//    '        '------------------

	//    '        gobjclsStandardGraph = New clsStandardGraph

	//    '        '---Get the last RunNumber 

	//    '        If gobjNewMethod.QuantitativeDataCollection.Count > 0 Then
	//    '            mintRunNumberIndex = gobjNewMethod.QuantitativeDataCollection.Count - 1
	//    '        ElseIf gobjNewMethod.QuantitativeDataCollection.Count <= 0 Then
	//    '            mintRunNumberIndex = -1
	//    '        End If

	//    '        If gobjNewMethod.StandardAddition Then
	//    '            EndAnalysis = False
	//    '        End If

	//    '        'DeleteAllRawData(False)
	//    '        mobjAnalysisRawData.Clear()
	//    '        mobjBlankRawData = Nothing
	//    '        mobjStandardRawData = Nothing
	//    '        mobjSampleRawData = Nothing

	//    '        '*************************************************************************
	//    '        '---- Commented by Mangesh on 10-May-2007
	//    '        '*************************************************************************
	//    '        '---Gets the First Standard from Standard Collection
	//    '        If Not IsNothing(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection) Then
	//    '            mobjStandardEnumerator = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.GetEnumerator()
	//    '            mobjStandardEnumerator.Reset()
	//    '            intIEnumCollLocationStd = 0
	//    '            If mobjStandardEnumerator.MoveNext() Then
	//    '                intIEnumCollLocationStd = 1
	//    '                mobjCurrentStandard = CType(mobjStandardEnumerator.Current(), Method.clsAnalysisStdParameters)
	//    '            End If
	//    '        End If

	//    '        '---Gets the First Sample from Sample Collection
	//    '        If Not IsNothing(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection) Then
	//    '            mobjSampleEnumerator = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.GetEnumerator()
	//    '            mobjSampleEnumerator.Reset()
	//    '            intIEnumCollLocationSamp = 0
	//    '            If mobjSampleEnumerator.MoveNext() Then
	//    '                intIEnumCollLocationSamp = 1
	//    '                mobjCurrentSample = CType(mobjSampleEnumerator.Current(), Method.clsAnalysisSampleParameters)
	//    '            End If
	//    '        End If
	//    '        '*************************************************************************

	//    '        CurRepeat = 1

	//    '        If ((Not IsNothing(mobjCurrentStandard)) And StdAnalysed) Then
	//    '            If (gobjNewMethod.StandardAddition) Then
	//    '                objDlgResult = DialogResult.No
	//    '            Else
	//    '                If Not (methchange) Then
	//    '                    If gobjMessageAdapter.ShowMessage(constPreviousStandards) Then
	//    '                        objDlgResult = DialogResult.Yes
	//    '                    Else
	//    '                        objDlgResult = DialogResult.No
	//    '                    End If
	//    '                Else
	//    '                    objDlgResult = DialogResult.No
	//    '                End If
	//    '            End If
	//    '            'Comment & move by Pankaj on 08 Jun 07 
	//    '            'If (objDlgResult = DialogResult.No) Then
	//    '            '    Clear_All_Abs_Std(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection)
	//    '            'Else
	//    '            '    mobjCurrentStandard = Nothing
	//    '            'End If
	//    '            '------
	//    '        End If
	//    '        methchange = False

	//    '        If Not (StdAnalysed) Then  '---for removing uncompleted std analysis
	//    '            Call Clear_All_Abs_Std(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection)
	//    '        End If
	//    '        'Moved By Pankaj  on 09 Jun 07
	//    '        'Call Clear_All_Abs_Conc_Samp(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection)


	//    '        SampleType = ClsAAS203.enumSampleType.BLANK

	//    '        Afirst = True
	//    '        mStartTime = 0.0
	//    '        mEndTime = mStartTime + 100

	//    '        'if(i==6)
	//    '        '   StdAnalysed =TRUE;
	//    '        'Else
	//    '        '	StdAnalysed =FALSE;

	//    '        'Comment & move by Pankaj 08 Jun 06 
	//    '        'If (objDlgResult = DialogResult.Yes) Then
	//    '        '    StdAnalysed = True
	//    '        'Else
	//    '        '    StdAnalysed = False
	//    '        'End If
	//    '        '---------

	//    '        'gobjNewMethod.AnalysisParameters.RepReady = False

	//    '        If (mblnIsStartRunNumber) Then
	//    '            'AppendMethod(Method, QALL)

	//    '            If (CInt(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).RunNumber) >= 0) Then
	//    '                Dim objclsQuantitativeData As AAS203Library.Method.clsQuantitativeData
	//    '                objclsQuantitativeData = New AAS203Library.Method.clsQuantitativeData
	//    '                objclsQuantitativeData.AnalysisParameters = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.Clone()
	//    '                objclsQuantitativeData.ReportParameters = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).ReportParameters.Clone()
	//    '                objclsQuantitativeData.StandardDataCollection = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.Clone()
	//    '                objclsQuantitativeData.SampleDataCollection = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.Clone()
	//    '                objclsQuantitativeData.CalculationMode = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).CalculationMode
	//    '                gobjNewMethod.QuantitativeDataCollection.Add(objclsQuantitativeData)
	//    '                mintRunNumberIndex += 1
	//    '                gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).RunNumber = -1.0
	//    '            End If
	//    '            mblnIsStartRunNumber = False
	//    '        End If
	//    '        'Added By Pankaj on 08 Jun 07
	//    '        If ((Not IsNothing(mobjCurrentStandard)) And StdAnalysed) Then
	//    '            If (objDlgResult = DialogResult.No) Then
	//    '                Clear_All_Abs_Std(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection)
	//    '            Else
	//    '                mobjCurrentStandard = Nothing
	//    '            End If
	//    '        End If
	//    '        Call Clear_All_Abs_Conc_Samp(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection)
	//    '        '------------------
	//    '        'Comment & move by Pankaj 08 Jun 06 
	//    '        If (objDlgResult = DialogResult.Yes) Then
	//    '            StdAnalysed = True
	//    '        Else
	//    '            StdAnalysed = False
	//    '        End If
	//    '        '---------
	//    '        If (CInt(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).RunNumber) <= 0) Then
	//    '            Call GetRunNo(gobjNewMethod)
	//    '        End If

	//    '        '*************************************************************************
	//    '        '---- Added by Mangesh on 10-May-2007
	//    '        '*************************************************************************
	//    '        '---Gets the First Standard from Standard Collection
	//    '        If Not IsNothing(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection) Then
	//    '            mobjStandardEnumerator = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.GetEnumerator()
	//    '            mobjStandardEnumerator.Reset()
	//    '            intIEnumCollLocationStd = 0
	//    '            If mobjStandardEnumerator.MoveNext() Then
	//    '                intIEnumCollLocationStd = 1
	//    '                mobjCurrentStandard = CType(mobjStandardEnumerator.Current(), Method.clsAnalysisStdParameters)
	//    '            End If
	//    '        End If

	//    '        '---Gets the First Sample from Sample Collection
	//    '        If Not IsNothing(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection) Then
	//    '            mobjSampleEnumerator = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.GetEnumerator()
	//    '            mobjSampleEnumerator.Reset()
	//    '            intIEnumCollLocationSamp = 0
	//    '            If mobjSampleEnumerator.MoveNext() Then
	//    '                intIEnumCollLocationSamp = 1
	//    '                mobjCurrentSample = CType(mobjSampleEnumerator.Current(), Method.clsAnalysisSampleParameters)
	//    '            End If
	//    '        End If

	//    '        If (objDlgResult = DialogResult.Yes) Then
	//    '            mobjCurrentStandard = Nothing
	//    '        End If
	//    '        '*************************************************************************

	//    '        If AASGraphAnalysis.AldysPane.CurveList.Count > 0 Then
	//    '            AASGraphAnalysis.AldysPane.CurveList.Clear()

	//    '            AASGraphAnalysis.AldysPane.AxisChange()
	//    '            AASGraphAnalysis.Invalidate()
	//    '            Application.DoEvents()
	//    '        End If

	//    '        'AASGraphAnalysis.XAxisStep = 20     'Saurabh 06-06-2007
	//    '        'Call Calculate_Analysis_Graph_Param(AASGraphAnalysis)

	//    '        AASGraphAnalysis.XAxisType = AldysGraph.AxisType.Linear
	//    '        AASGraphAnalysis.XAxisMin = mStartTime
	//    '        AASGraphAnalysis.XAxisMax = mEndTime

	//    '        Call Calculate_Analysis_Graph_Param(AASGraphAnalysis)

	//    '        'AASGraphAnalysis.AldysPane.XAxis.StepAuto = True
	//    '        'AASGraphAnalysis.AldysPane.XAxis.MinorStepAuto = True
	//    '        'AASGraphAnalysis.AldysPane.XAxis.PickScale(AASGraphAnalysis.XAxisMin, AASGraphAnalysis.XAxisMax)

	//    '        AASGraphAnalysis.Refresh()
	//    '        Application.DoEvents()

	//    '        AnaOver = False

	//    '        Call DisplayRunNo()

	//    '        'gobjNewMethod.AnalysisParameters.cMode = -2

	//    '        'tlbbtnRepeatLastAnalysis.Enabled = False
	//    '        btnRepeatLast.Enabled = False
	//    '        '//----- Save Instrument parameter
	//    '        'gobjNewMethod.InstrumentCondition.D2Current = gobjInst.D2Current
	//    '        'gobjNewMethod.InstrumentCondition.LampCurrent = gobjInst.Current
	//    '        'gobjNewMethod.InstrumentCondition.PmtVoltage = gobjInst.PmtVoltage
	//    '        'gobjNewMethod.InstrumentCondition.SlitWidth = gobjClsAAS203.funcGet_SlitWidth
	//    '        If gstructSettings.AppMode = EnumAppMode.FullVersion_203D Then
	//    '            'TODO   Add property to gobjNewMethod.InstrumentCondition object for PMT Volt & Exit Slit Wd for Ref. 
	//    '            'gobjNewMethod.InstrumentCondition.PmtVoltage = gobjInst.PmtVoltageReference
	//    '            'gobjNewMethod.InstrumentCondition.SlitWidth = gobjInst.SlitPositionExit
	//    '        End If

	//    '        gobjNewMethod.InstrumentCondition.BurnerHeight = gobjClsAAS203.funcReadBurnerHeight()

	//    '        If Not (gstructSettings.AppMode = EnumAppMode.DemoMode) Then
	//    '            Call gobjCommProtocol.funcGet_NV_Pos()
	//    '        End If

	//    '        dblFuelRatio = gobjClsAAS203.funcGet_Fuel_Ratio(True)
	//    '        gobjNewMethod.InstrumentCondition.FuelRatio = dblFuelRatio
	//    '        '//-----

	//    '        'If (gobjNewMethod.AnalysisParameters) Then
	//    '        '   aafname = gobjNewMethod.AnalysisParameter.Fname
	//    '        'End If

	//    '        Call Display_Analysis_Info()
	//    '        Call CheckValidStdAbs()
	//    '        If (mblnIsAnalysisStarted) Then
	//    '            ANALYSIS = True
	//    '            '---Show Blinking Message
	//    '            Call Aspirate()
	//    '        Else
	//    '            ANALYSIS = False
	//    '        End If
	//    '        mblnRepeatLastStd = False
	//    '        mblnRepeatLastSample = False

	//    '    Catch ex As Exception
	//    '        '---------------------------------------------------------
	//    '        'Error Handling and logging
	//    '        gobjErrorHandler.ErrorDescription = ex.Message
	//    '        gobjErrorHandler.ErrorMessage = ex.Message
	//    '        gobjErrorHandler.WriteErrorLog(ex)
	//    '        '---------------------------------------------------------
	//    '    Finally
	//    '        '---------------------------------------------------------
	//    '        'Writing Execution log
	//    '        If CONST_CREATE_EXECUTION_LOG = 1 Then
	//    '            gobjErrorHandler.WriteExecutionLog()
	//    '        End If
	//    '        '---------------------------------------------------------
	//    '    End Try
	//    'End Sub

	//    Private Sub NewAnalysis_Clicked(ByVal sender As System.Object, ByVal e As System.EventArgs)
	//        '=====================================================================
	//        ' Procedure Name        : NewAnalysis_Clicked
	//        ' Parameters Passed     : Object, EventArgs
	//        ' Returns               : None
	//        ' Purpose               : Start to new analysis
	//        ' Description           : 
	//        ' Assumptions           : 
	//        ' Dependencies          : 
	//        ' Author                : Mangesh Shardul
	//        ' Created               : 17-Jan-2007 03:25 pm
	//        ' Revisions             : 1
	//        '=====================================================================
	//        'case	IDC_QANEW:
	//        '#If STD_ADDN Then
	//        '   endanalysis= FALSE;
	//        '#End If
	//        'DeleteAllRawData(FALSE);
	//        'mobjCurrentStandard  =Method->QuantData->StdTopData;
	//        'mobjCurrentSample =Method->QuantData->SampTopData;
	//        'CurRepeat=1;

	//        'if(mobjCurrentStandard!=NULL  && StdAnalysed)
	//        '{
	//        '   if(Method->QuantData->Param.Std_Addn)
	//        '	    i = IDNO;
	//        '	else{
	//        '       If (!methchange) Then        
	//        '		    i=MessageBox(hwnd,"Do you want to use the previous standards","INFORMATION", MB_ICONQUESTION | MB_YESNO);
	//        '		else
	//        '		    i=IDNO;
	//        '   }
	//        'if(i==IDNO)
	//        '   Clear_All_Abs_Std(Method->QuantData->StdTopData);
	//        'Else
	//        '   mobjCurrentStandard=NULL;
	//        '}
	//        'methchange = FALSE;	
	//        'if(!StdAnalysed) 
	//        '   Clear_All_Abs_Std(Method->QuantData->StdTopData);
	//        'Clear_All_Abs_Conc_Samp(Method->QuantData->SampTopData);
	//        'SampType=BLANK;
	//        'Xtime=0;Afirst=TRUE;
	//        '	
	//        'if(i==6)
	//        '   StdAnalysed =TRUE;
	//        'Else
	//        '	StdAnalysed =FALSE;
	//        'Method->RepReady=FALSE;
	//        'if (lParam!=100L){
	//        '   AppendMethod(Method, QALL);
	//        '	Method->QuantData->Fname =-1.0;
	//        '}
	//        'if (Method->QuantData->Fname<=0)
	//        '   GetRunNo(Method);
	//        'AnaGraph.Xmin=0; AnaGraph.Xmax=10*10.0;
	//        'Calculate_Analysis_Graph_Param(&AnaGraph);
	//        'AnaOver=FALSE;
	//        'if (hwnd){
	//        '   DisplayRunNo(hwnd);
	//        '	InvalidateRect(hwnd, NULL, TRUE);
	//        '}
	//        'Method->QuantData->cMode=-2;

	//        'EnableWindow(GetDlgItem(hwnd,IDC_QARPT),FALSE); // add by sss
	//        'if(Method->QuantData)
	//        '   aafname = Method->QuantData->Fname;
	//        'break;


	//        '---CODE BY MANGESH 

	//        'On NEW Analysis
	//        Dim dblFuelRatio As Double
	//        Dim objDlgResult As DialogResult

	//        '---18.06.07
	//        Try
	//            '----added by deepak for new analysis on 28.04.07
	//            'lblAbsorbance.Text = ""
	//            'lblAverageAbsorbance.Text = ""
	//            'lblCorrectedAbsorbance.Text = ""
	//            'lblSampleID.Text = ""
	//            'lblRepeatNo.Text = ""
	//            'lblConcentration.Text = ""
	//            '------------------
	//            '//----- Commented by Sachin Dokhale
	//            '//----- Previous Standard
	//            '//-----

	//            '---Get the last RunNumber 


	//            If gobjNewMethod.StandardAddition Then
	//                EndAnalysis = False
	//            End If


	//            '//----- Modifed by Sachin Dokhale
	//            ' ReInit object
	//            mobjAnalysisRawData = Nothing
	//            mobjAnalysisRawData = New Analysis.clsRawDataCollection
	//            '//-----
	//            mobjBlankRawData = Nothing
	//            mobjStandardRawData = Nothing
	//            mobjSampleRawData = Nothing
	//            ''//-----



	//            '---- Commented by Mangesh on 10-May-2007

	//            '---Gets the First Standard from Standard Collection
	//            If Not IsNothing(gobjNewMethod.StandardDataCollection) Then
	//                mobjStandardEnumerator = gobjNewMethod.StandardDataCollection.GetEnumerator()
	//                mobjStandardEnumerator.Reset()
	//                intIEnumCollLocationStd = 0
	//                If mobjStandardEnumerator.MoveNext() Then
	//                    intIEnumCollLocationStd = 1
	//                    mobjCurrentStandard = CType(mobjStandardEnumerator.Current(), Method.clsAnalysisStdParameters)
	//                End If
	//            End If

	//            '---Gets the First Sample from Sample Collection
	//            If Not IsNothing(gobjNewMethod.SampleDataCollection) Then
	//                mobjSampleEnumerator = gobjNewMethod.SampleDataCollection.GetEnumerator()
	//                mobjSampleEnumerator.Reset()
	//                intIEnumCollLocationSamp = 0
	//                If mobjSampleEnumerator.MoveNext() Then
	//                    intIEnumCollLocationSamp = 1
	//                    mobjCurrentSample = CType(mobjSampleEnumerator.Current(), Method.clsAnalysisSampleParameters)
	//                End If
	//            End If

	//            CurRepeat = 1
	//            '//----- if use Previous Standard
	//            'Dim blnIsLoadPreviousStandards As Boolean
	//            If ((Not IsNothing(mobjCurrentStandard)) And StdAnalysed) Then
	//                If (gobjNewMethod.StandardAddition) Then
	//                    objDlgResult = DialogResult.No
	//                    blnIsLoadPreviousStandards = False
	//                Else
	//                    If Not (methchange) And (mblnGetStandards = True) Then
	//                        If gobjMessageAdapter.ShowMessage(constPreviousStandards) Then
	//                            objDlgResult = DialogResult.Yes
	//                            blnIsLoadPreviousStandards = True
	//                        Else
	//                            objDlgResult = DialogResult.No
	//                            blnIsLoadPreviousStandards = False
	//                        End If
	//                    Else
	//                        objDlgResult = DialogResult.No
	//                        blnIsLoadPreviousStandards = False
	//                    End If
	//                End If
	//                'Comment & move by Pankaj on 08 Jun 07 
	//                'If (objDlgResult = DialogResult.No) Then
	//                '    Clear_All_Abs_Std(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection)
	//                'Else
	//                '    mobjCurrentStandard = Nothing
	//                'End If
	//                '------
	//            Else
	//                blnIsLoadPreviousStandards = False
	//            End If
	//            methchange = False
	//            '//----- Added by Sachin Dokhale 
	//            '//----- Previous Standard
	//            If blnIsLoadPreviousStandards = False Then
	//                gobjclsStandardGraph = New clsStandardGraph
	//            Else
	//                If gobjclsStandardGraph Is Nothing Then
	//                    gobjclsStandardGraph = New clsStandardGraph
	//                End If
	//            End If
	//            '//-----
	//            'for removing uncompleted std analysis
	//            If Not (StdAnalysed) Then  '---
	//                Call Clear_All_Abs_Std(gobjNewMethod.StandardDataCollection)
	//            End If
	//            'Moved By Pankaj  on 09 Jun 07
	//            'Call Clear_All_Abs_Conc_Samp(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection)

	//            ' Set 1st at the time of starting new analysis Sample Type is Balnk
	//            'Start Time and End time of analysis is reset
	//            ' then change when analysis perform Sts/Sample or blank

	//            SampleType = ClsAAS203.enumSampleType.BLANK
	//            Afirst = True
	//            mStartTime = 0.0
	//            mEndTime = mStartTime + 100

	//            'if(i==6)
	//            '   StdAnalysed =TRUE;
	//            'Else
	//            '	StdAnalysed =FALSE;

	//            'Comment & move by Pankaj 08 Jun 06 
	//            'If (objDlgResult = DialogResult.Yes) Then
	//            '    StdAnalysed = True
	//            'Else
	//            '    StdAnalysed = False
	//            'End If
	//            '---------

	//            'gobjNewMethod.AnalysisParameters.RepReady = False
	//            ' Follow the process for New Run nuumber
	//            If (mblnIsStartRunNumber) Then
	//                'AppendMethod(Method, QALL)
	//                'If (CInt(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).RunNumber) >= 0) Then
	//                Dim objclsQuantitativeData As AAS203Library.Method.clsQuantitativeData
	//                objclsQuantitativeData = New AAS203Library.Method.clsQuantitativeData
	//                'Set Analysis Parameter object
	//                If Not gobjNewMethod.AnalysisParameters Is Nothing Then
	//                    objclsQuantitativeData.AnalysisParameters = gobjNewMethod.AnalysisParameters.Clone()
	//                End If
	//                'Set Report Parameter object
	//                If Not gobjNewMethod.ReportParameters Is Nothing Then
	//                    objclsQuantitativeData.ReportParameters = gobjNewMethod.ReportParameters.Clone()
	//                End If

	//                'objclsQuantitativeData.StandardDataCollection = gobjNewMethod.StandardDataCollection.Clone()
	//                '//----- Added by Sachin Dokhale for Previous Standard
	//                ' Restore the previous object when analysis use Load previous Standard 
	//                If blnIsLoadPreviousStandards = True And StdAnalysed = True And mintRunNumberIndex >= 0 Then
	//                    mblnGetStandards = False
	//                    objclsQuantitativeData.StandardDataCollection = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.Clone
	//                    intIEnumCollLocationStd = objclsQuantitativeData.StandardDataCollection.Count + 1
	//                    If funcMoveEnumerator(mobjStandardEnumerator, intIEnumCollLocationStd) = True Then
	//                        mobjCurrentStandard = CType(mobjStandardEnumerator.Current, Method.clsAnalysisStdParameters)
	//                    Else
	//                        mobjCurrentStandard = Nothing
	//                    End If
	//                Else
	//                    objclsQuantitativeData.StandardDataCollection = gobjNewMethod.StandardDataCollection.Clone()
	//                End If

	//                '//-----
	//                If Not gobjNewMethod.SampleDataCollection Is Nothing Then
	//                    objclsQuantitativeData.SampleDataCollection = gobjNewMethod.SampleDataCollection.Clone()
	//                End If
	//                'objclsQuantitativeData.CalculationMode = gobjNewMethod.CalculationMode
	//                gobjNewMethod.QuantitativeDataCollection.Add(objclsQuantitativeData)
	//                'mintRunNumberIndex += 1
	//                mintRunNumberIndex = gobjNewMethod.QuantitativeDataCollection.Count - 1
	//                gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).RunNumber = -1.0
	//                'End If
	//                mblnIsStartRunNumber = False
	//            End If
	//            'Added By Pankaj on 08 Jun 07
	//            ' Cleat all stadard object when New Standard use analysis
	//            If ((Not IsNothing(mobjCurrentStandard)) And StdAnalysed) Then
	//                If (objDlgResult = DialogResult.No) Then
	//                    Clear_All_Abs_Std(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection)
	//                Else
	//                    mobjCurrentStandard = Nothing
	//                End If
	//            End If
	//            ' Cleat all Sample object 
	//            Call Clear_All_Abs_Conc_Samp(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection)
	//            '------------------
	//            'Comment & move by Pankaj 08 Jun 06 
	//            If (objDlgResult = DialogResult.Yes) Then
	//                StdAnalysed = True
	//            Else
	//                StdAnalysed = False
	//            End If
	//            '---------
	//            If (CInt(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).RunNumber) <= 0) Then
	//                ' Call GetRunNo(gobjNewMethod)
	//            End If


	//            '---- Added by Mangesh on 10-May-2007

	//            '---Gets the First Standard from Standard Collection
	//            If blnIsLoadPreviousStandards = True And StdAnalysed = True And mintRunNumberIndex > 0 Then
	//            Else
	//                If Not IsNothing(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection) Then
	//                    mobjStandardEnumerator = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.GetEnumerator()
	//                    mobjStandardEnumerator.Reset()
	//                    intIEnumCollLocationStd = 0
	//                    If mobjStandardEnumerator.MoveNext() Then
	//                        intIEnumCollLocationStd = 1
	//                        mobjCurrentStandard = CType(mobjStandardEnumerator.Current(), Method.clsAnalysisStdParameters)
	//                    End If
	//                End If

	//            End If

	//            '---Gets the First Sample from Sample Collection
	//            If Not IsNothing(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection) Then
	//                mobjSampleEnumerator = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.GetEnumerator()
	//                mobjSampleEnumerator.Reset()
	//                intIEnumCollLocationSamp = 0
	//                If mobjSampleEnumerator.MoveNext() Then
	//                    intIEnumCollLocationSamp = 1
	//                    mobjCurrentSample = CType(mobjSampleEnumerator.Current(), Method.clsAnalysisSampleParameters)
	//                End If
	//            End If

	//            If (objDlgResult = DialogResult.Yes) Then
	//                mobjCurrentStandard = Nothing
	//            End If


	//            'If AASGraphAnalysis.AldysPane.CurveList.Count > 0 Then
	//            '    AASGraphAnalysis.AldysPane.CurveList.Clear()

	//            '    AASGraphAnalysis.AldysPane.AxisChange()
	//            '    AASGraphAnalysis.Invalidate()
	//            '    Application.DoEvents()
	//            'End If

	//            'AASGraphAnalysis.XAxisStep = 20     'Saurabh 06-06-2007
	//            'Call Calculate_Analysis_Graph_Param(AASGraphAnalysis)
	//            '--- Set Graph parameters
	//            'AASGraphAnalysis.XAxisType = AldysGraph.AxisType.Linear
	//            'AASGraphAnalysis.XAxisMin = mStartTime
	//            'AASGraphAnalysis.XAxisMax = mEndTime
	//            '--- Cal. graph coordinates 
	//            'Call Calculate_Analysis_Graph_Param(AASGraphAnalysis)
	//            'AASGraphAnalysis.Refresh()
	//            Application.DoEvents()

	//            AnaOver = False

	//            Call DisplayRunNo()

	//            'gobjNewMethod.AnalysisParameters.cMode = -2

	//            'tlbbtnRepeatLastAnalysis.Enabled = False
	//            'btnRepeatLast.Enabled = False
	//            '//----- Save Instrument parameter

	//            If gstructSettings.AppMode = EnumAppMode.FullVersion_203D Then
	//                'TODO   Add property to gobjNewMethod.InstrumentCondition object for PMT Volt & Exit Slit Wd for Ref. 
	//                'gobjNewMethod.InstrumentCondition.PmtVoltage = gobjInst.PmtVoltageReference
	//                'gobjNewMethod.InstrumentCondition.SlitWidth = gobjInst.SlitPositionExit
	//            End If
	//            If gobjMain.mobjController.IsThreadRunning = True Then  '10.12.07
	//                gobjMain.mobjController.Cancel()
	//                gobjCommProtocol.mobjCommdll.subTime_Delay(500)   '10.12.07
	//                Application.DoEvents()
	//            End If

	//            ' set the instrument parameter into Data collection object
	//            gobjNewMethod.InstrumentCondition.BurnerHeight = gobjClsAAS203.funcReadBurnerHeight()

	//            'If Not (gstructSettings.AppMode = EnumAppMode.DemoMode) Then
	//            If Not ((gstructSettings.AppMode = EnumAppMode.DemoMode) Or _
	//                    (gstructSettings.AppMode = EnumAppMode.DemoMode_201) Or _
	//                    (gstructSettings.AppMode = EnumAppMode.DemoMode_203D)) Then
	//                Call gobjCommProtocol.funcGet_NV_Pos()
	//            End If

	//            'dblFuelRatio = gobjClsAAS203.funcGet_Fuel_Ratio(True)  '10.12.07
	//            dblFuelRatio = gobjClsAAS203.funcRead_Fuel_Ratio        '10.12.07
	//            gobjNewMethod.InstrumentCondition.FuelRatio = dblFuelRatio
	//            '//-----

	//            'If (gobjNewMethod.AnalysisParameters) Then
	//            '   aafname = gobjNewMethod.AnalysisParameter.Fname
	//            'End If
	//            'display analysis information 
	//            Call Display_Analysis_Info()
	//            ' Check Valid Std for result from analysis
	//            Call CheckValidStdAbs()

	//            If (mblnIsAnalysisStarted) Then
	//                ANALYSIS = True
	//                '---Show Blinking Message
	//                Call Aspirate()
	//            Else
	//                ANALYSIS = False
	//            End If
	//            mblnRepeatLastStd = False
	//            mblnRepeatLastSample = False
	//            '//----- Initialise the Data Bg Thread for UV Analysis
	//            If (gobjNewMethod.OperationMode = EnumOperationMode.MODE_UVABS) Then
	//                mobjBgReadData = New clsBgReadData(0, 0, SampleType, mobjCurrentStandard, mobjCurrentSample)
	//            End If
	//            '//-----
	//            If btnReadData.Enabled Then
	//                btnReadData.Focus()
	//                btnReadData.Refresh()
	//            End If
	//            If gobjMain.mobjController.IsThreadRunning = False Then     '10.12.07
	//                gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay)
	//                Application.DoEvents()
	//                gobjMain.mobjController.Start(gobjclsBgFlameStatus)
	//            End If
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

	//    Private Sub NextAnalysis_Clicked(ByVal sender As System.Object, ByVal e As System.EventArgs)
	//        '=====================================================================
	//        ' Procedure Name        : NextAnalysis_Clicked
	//        ' Parameters Passed     : Object, EventArgs
	//        ' Returns               : None
	//        ' Purpose               : Set to Next sample
	//        ' Description           : 
	//        ' Assumptions           : 
	//        ' Dependencies          : 
	//        ' Author                : Mangesh Shardul
	//        ' Created               : 17-Jan-2007 03:25 pm
	//        ' Revisions             : 1
	//        '=====================================================================
	//        'case IDC_QANEXT:
	//        'LSampType=SampType;
	//        'if( SampType==BLANK )
	//        '{
	//        '   SampType=STD;
	//        '	if (CurStd==NULL)
	//        '	    SampType=SAMP;
	//        '	if (SampType==SAMP && CurSamp==NULL)
	//        '   {
	//        '	    InQAnaRead=FALSE;
	//        '       AnaOver=TRUE;
	//        '		SendMessage(hwnd, WM_COMMAND, IDC_QASTART, 0L);
	//        '   }
	//        '}
	//        'else
	//        '{
	//        '   CurRepeat++;
	//        '   if ((CurRepeat>Method->QuantData->Param.Repeat && SampType==SAMP) || (CurRepeat>Method->QuantData->Param.ConcRepeat && SampType==STD))
	//        '   {
	//        '	    CurRepeat=1;
	//        '		if (SampType==STD )
	//        '       {
	//        '           If (CurStd! = NULL) Then
	//        '			    CurStd=CurStd->next;
	//        '			if (CurStd==NULL)
	//        '           {
	//        '			    StdAnalysed=TRUE;
	//        '			    if (!GetBlankCalType())
	//        '               {
	//        '				    Create_Standard_Sample_Curve(hwnd,FALSE);
	//        '
	//        '                   #If STD_ADDN Then
	//        '					    if(Method->QuantData->Param.Std_Addn)
	//        '					        endanalysis= TRUE;
	//        '                   #End If        
	//        '
	//        '				}
	//        '				SampType=SAMP;
	//        '			}
	//        '		}
	//        '		else if (SampType==SAMP)
	//        '       {
	//        '           If (CurSamp! = NULL) Then
	//        '			    CurSamp=CurSamp->next;
	//        '		}
	//        '	}
	//        '	if (Method->QuantData->Param.Blank)
	//        '	    SampType=BLANK;
	//        '}
	//        'InQAnaRead=FALSE;
	//        'EnableWindow(GetDlgItem(hwnd,IDC_SAVEREPORT), StdAnalysed);
	//        'EnableWindow(GetDlgItem(hwnd,IDC_QARPT),TRUE); 

	//        '#If STD_ADDN Then
	//        '   if(endanalysis)
	//        '       SendMessage(hwnd, WM_COMMAND, 951, 0L);
	//        '#End If
	//        'break;


	//        '--- CODE BY MANGESH 

	//        Try
	//            '--- Set previous Sample type to tmep and assign next sample type
	//            LSampType = SampleType

	//            If (SampleType = ClsAAS203.enumSampleType.BLANK) Then
	//                SampleType = ClsAAS203.enumSampleType.STANDARD

	//                If IsNothing(mobjCurrentStandard) Then
	//                    SampleType = ClsAAS203.enumSampleType.SAMPLE
	//                End If

	//                If (SampleType = ClsAAS203.enumSampleType.SAMPLE _
	//                    And IsNothing(mobjCurrentSample)) Then

	//                    InQAnaRead = False
	//                    AnaOver = True
	//                    'SendMessage(hwnd, WM_COMMAND, IDC_QASTART, 0L)
	//                    ' Set the StartStop Analysis porcedure
	//                    Call StartStopAnalysis_Click(btnStartStopAnalysis, EventArgs.Empty)
	//                End If

	//            Else

	//                CurRepeat += 1

	//                'if ((CurRepeat>Method->QuantData->Param.Repeat && SampType==SAMP) || (CurRepeat>Method->QuantData->Param.ConcRepeat && SampType==STD)){
	//                If ((CurRepeat > gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfSampleRepeats _
	//                     And SampleType = ClsAAS203.enumSampleType.SAMPLE) _
	//                    Or (CurRepeat > gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfStdRepeats _
	//                     And SampleType = ClsAAS203.enumSampleType.STANDARD)) Then

	//                    CurRepeat = 1

	//                    If (SampleType = ClsAAS203.enumSampleType.STANDARD) Then
	//                        'If (CurStd! = NULL) Then
	//                        '   CurStd=CurStd->next
	//                        '}
	//                        ' Set the current standard
	//                        Call funcGetCurrentStandard(mobjCurrentStandard)



	//                        If IsNothing(mobjCurrentStandard) Then
	//                            StdAnalysed = True
	//                            If Not (gstructSettings.BlankCalculation) Then

	//                                Call gobjclsStandardGraph.Create_Standard_Sample_Curve(False, True, 0, 0, gobjNewMethod)

	//                                '#If STD_ADDN Then
	//                                If gobjNewMethod.StandardAddition Then
	//                                    'if(Method->QuantData->Param.Std_Addn)
	//                                    EndAnalysis = True
	//                                    'End If
	//                                    '#End If
	//                                End If
	//                            End If
	//                            SampleType = ClsAAS203.enumSampleType.SAMPLE
	//                        End If
	//                    ElseIf (SampleType = ClsAAS203.enumSampleType.SAMPLE) Then
	//                        'If (CurSamp! = NULL) Then
	//                        '   CurSamp=CurSamp->next;
	//                        Call funcGetCurrentSample(mobjCurrentSample)
	//                    End If
	//                End If
	//                'EnableWindow(GetDlgItem(hwnd, IDC_SAVEREPORT), StdAnalysed)
	//                'btnSave.Enabled = StdAnalysed

	//                '--- Check Blank After Every Sample or Std and set sample type is blank
	//                If (gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.IsBlankAfterEverySampleOrStd) Then
	//                    SampleType = ClsAAS203.enumSampleType.BLANK
	//                End If

	//            End If

	//            InQAnaRead = False
	//            'tlbbtnSaveReport.Enabled = StdAnalysed
	//            'tlbbtnRepeatLastAnalysis.Enabled = True
	//            'btnEditData.Enabled = StdAnalysed
	//            'btnRepeatLast.Enabled = True
	//            '--- Asipiration message for next analysis
	//            Call Aspirate()
	//            ' check for Standsrd Addition mode and if analysis is end then use start stop analysis porcesure
	//            '#If STD_ADDN Then
	//            If gobjNewMethod.StandardAddition Then
	//                If (EndAnalysis) Then
	//                    'SendMessage(hwnd, WM_COMMAND, 951, 0L)
	//                    Call StartStopAnalysis_Click(btnStartStopAnalysis, EventArgs.Empty)
	//                End If
	//            End If
	//            'End IF

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

	//    Private Function funcGetCurrentStandard(ByRef objCurrentStandard As Method.clsAnalysisStdParameters) As Boolean
	//        '=====================================================================
	//        ' Procedure Name        : funcGetCurrentStandard
	//        ' Parameters Passed     : objCurrentStandard As Method.clsAnalysisStdParameters
	//        ' Returns               : Bool
	//        ' Purpose               : Set to curent standard
	//        ' Description           : 
	//        ' Assumptions           : 
	//        ' Dependencies          : 
	//        ' Author                : Mangesh Shardul
	//        ' Created               : 17-Jan-2007 03:25 pm
	//        ' Revisions             : 1
	//        '=====================================================================
	//        'Static intIEnumCollLocation As Integer
	//        Try
	//            'Set by Ref. object of the current standard 
	//            If Not IsNothing(objCurrentStandard) Then
	//                '--- Check for last repeat Standard
	//                'If mblnRepeatLastStd = True Then
	//                'If funcMoveEnumerator(mobjStandardEnumerator, intIEnumCollLocationStd) = True Then
	//                '    objCurrentStandard = CType(mobjStandardEnumerator.Current, Method.clsAnalysisStdParameters)
	//                'Else
	//                '    objCurrentStandard = Nothing
	//                'End If
	//                'Else
	//                intIEnumCollLocationStd += 1
	//                If funcMoveEnumerator(mobjStandardEnumerator, intIEnumCollLocationStd) = True Then
	//                    objCurrentStandard = CType(mobjStandardEnumerator.Current, Method.clsAnalysisStdParameters)
	//                Else
	//                    objCurrentStandard = Nothing
	//                End If
	//                'End If
	//                'mblnRepeatLastStd = False
	//            End If
	//            mblnRepeatLastStd = False
	//        Catch ex As Exception
	//            '---------------------------------------------------------
	//            'Error Handling and logging
	//            gobjErrorHandler.ErrorDescription = ex.Message
	//            gobjErrorHandler.ErrorMessage = ex.Message
	//            gobjErrorHandler.WriteErrorLog(ex)
	//            Return False
	//            '---------------------------------------------------------
	//        Finally
	//            '---------------------------------------------------------
	//            'Writing Execution log
	//            If CONST_CREATE_EXECUTION_LOG = 1 Then
	//                gobjErrorHandler.WriteExecutionLog()
	//            End If
	//            '---------------------------------------------------------
	//        End Try
	//    End Function

	//    Private Function funcGetCurrentSample(ByRef objCurrentSample As Method.clsAnalysisSampleParameters) As Boolean
	//        '=====================================================================
	//        ' Procedure Name        : funcGetCurrentSample
	//        ' Parameters Passed     : objCurrentStandard As Method.clsAnalysisStdParameters
	//        ' Returns               : Bool
	//        ' Purpose               : Set to curent Sample
	//        ' Description           : 
	//        ' Assumptions           : 
	//        ' Dependencies          : 
	//        ' Author                : Mangesh Shardul
	//        ' Created               : 17-Jan-2007 03:25 pm
	//        ' Revisions             : 1
	//        '=====================================================================
	//        'Static intIEnumCollLocation As Integer
	//        Try
	//            'Set by Ref. object of the current sample
	//            If Not IsNothing(objCurrentSample) Then
	//                '--- Check for last repeat sample
	//                If mblnRepeatLastSample = True Then

	//                    If funcMoveSampleEnumerator(mobjSampleEnumerator, intIEnumCollLocationSamp) = True Then
	//                        objCurrentSample = CType(mobjSampleEnumerator.Current, Method.clsAnalysisSampleParameters)
	//                    Else
	//                        objCurrentSample = Nothing
	//                    End If
	//                Else

	//                    intIEnumCollLocationSamp += 1
	//                    If funcMoveSampleEnumerator(mobjSampleEnumerator, intIEnumCollLocationSamp) = True Then
	//                        objCurrentSample = CType(mobjSampleEnumerator.Current, Method.clsAnalysisSampleParameters)
	//                    Else
	//                        objCurrentSample = Nothing
	//                    End If
	//                End If
	//                'mblnRepeatLastSample = False
	//            End If
	//            mblnRepeatLastSample = False
	//        Catch ex As Exception
	//            '---------------------------------------------------------
	//            'Error Handling and logging
	//            gobjErrorHandler.ErrorDescription = ex.Message
	//            gobjErrorHandler.ErrorMessage = ex.Message
	//            gobjErrorHandler.WriteErrorLog(ex)
	//            Return False
	//            '---------------------------------------------------------
	//        Finally
	//            '---------------------------------------------------------
	//            'Writing Execution log
	//            If CONST_CREATE_EXECUTION_LOG = 1 Then
	//                gobjErrorHandler.WriteExecutionLog()
	//            End If
	//            '---------------------------------------------------------
	//        End Try
	//    End Function

	//    Private Function funcMoveEnumerator(ByRef piEnumarator As IEnumerator, ByVal iLocation As Integer) As Boolean
	//        '=====================================================================
	//        ' Procedure Name        : funcMoveEnumerator
	//        ' Parameters Passed     : piStandardEnumarator As IEnumerator, piSampleEnumarator As IEnumerator
	//        ' Returns               : Bool
	//        ' Purpose               : Move Enumerator object
	//        ' Description           : 
	//        ' Assumptions           : 
	//        ' Dependencies          : 
	//        ' Author                : Mangesh Shardul
	//        ' Created               : 17-Jan-2007 03:25 pm
	//        ' Revisions             : 1
	//        '=====================================================================

	//        Dim tmpEnum As IEnumerator
	//        Dim IsLastRecoed As Boolean = False
	//        Try
	//            If mobjCurrentStandard Is Nothing Then
	//                Return False
	//            End If
	//            Dim i As Integer
	//            'assign enumarator to temporary enumrator
	//            tmpEnum = piEnumarator
	//            If Not tmpEnum Is Nothing Then
	//                'move the pointer to starting position
	//                tmpEnum.Reset()
	//                'validate location
	//                If iLocation <= 0 Then
	//                    IsLastRecoed = True
	//                End If
	//                'move enumrator pointer to said location
	//                For i = 1 To iLocation
	//                    If tmpEnum.MoveNext() = False Then
	//                        IsLastRecoed = True
	//                        Exit For
	//                    End If
	//                Next
	//                'assign temp enumrator to original enumrator
	//                piEnumarator = tmpEnum
	//            End If
	//            If IsLastRecoed = True Then
	//                Return False
	//            End If
	//            Return True
	//        Catch ex As Exception
	//            '---------------------------------------------------------
	//            'Error Handling and logging
	//            gobjErrorHandler.ErrorDescription = ex.Message
	//            gobjErrorHandler.ErrorMessage = ex.Message
	//            gobjErrorHandler.WriteErrorLog(ex)
	//            Return False
	//            '---------------------------------------------------------
	//        Finally
	//            '---------------------------------------------------------
	//            'Writing Execution log
	//            If CONST_CREATE_EXECUTION_LOG = 1 Then
	//                gobjErrorHandler.WriteExecutionLog()
	//            End If
	//            '---------------------------------------------------------
	//        End Try

	//    End Function

	//    Private Function funcMoveSampleEnumerator(ByRef piEnumarator As IEnumerator, ByVal iLocation As Integer) As Boolean
	//        '=====================================================================
	//        ' Procedure Name        : funcMoveSampleEnumerator
	//        ' Parameters Passed     : piStandardEnumarator As IEnumerator, piSampleEnumarator As IEnumerator
	//        ' Returns               : Bool
	//        ' Purpose               : Move sample Enumerator object
	//        ' Description           : 
	//        ' Assumptions           : 
	//        ' Dependencies          : 
	//        ' Author                : Mangesh Shardul
	//        ' Created               : 17-Jan-2007 03:25 pm
	//        ' Revisions             : 1
	//        '=====================================================================
	//        Dim tmpEnum As IEnumerator
	//        Dim IsLastRecoed As Boolean = False
	//        Try

	//            Dim i As Integer
	//            If mobjCurrentSample Is Nothing Then
	//                Return False
	//            End If
	//            If Not IsNothing(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection) Then
	//                mobjSampleEnumerator = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.GetEnumerator()
	//                tmpEnum = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.GetEnumerator()
	//            Else
	//                tmpEnum = piEnumarator
	//            End If

	//            If Not tmpEnum Is Nothing Then

	//                tmpEnum.Reset()
	//                'validate location
	//                If iLocation <= 0 Then
	//                    IsLastRecoed = True
	//                End If
	//                'move enumrator pointer to said location
	//                For i = 1 To iLocation
	//                    If tmpEnum.MoveNext() = False Then
	//                        IsLastRecoed = True
	//                        Exit For
	//                    End If
	//                Next
	//                piEnumarator = tmpEnum
	//            End If
	//            If IsLastRecoed = True Then
	//                Return False
	//            End If
	//            Return True
	//        Catch ex As Exception
	//            '---------------------------------------------------------
	//            'Error Handling and logging
	//            gobjErrorHandler.ErrorDescription = ex.Message
	//            gobjErrorHandler.ErrorMessage = ex.Message
	//            gobjErrorHandler.WriteErrorLog(ex)
	//            Return False
	//            '---------------------------------------------------------
	//        Finally
	//            '---------------------------------------------------------
	//            'Writing Execution log
	//            If CONST_CREATE_EXECUTION_LOG = 1 Then
	//                gobjErrorHandler.WriteExecutionLog()
	//            End If
	//            '---------------------------------------------------------
	//        End Try

	//    End Function

	//    Private Function funcRefreshEnumerators(ByRef piStandardEnumarator As IEnumerator, ByRef piSampleEnumarator As IEnumerator) As Boolean
	//        '=====================================================================
	//        ' Procedure Name        : funcRefreshEnumerators
	//        ' Parameters Passed     : piStandardEnumarator As IEnumerator, piSampleEnumarator As IEnumerator
	//        ' Returns               : Bool
	//        ' Purpose               : Move refresh Enumerator object
	//        ' Description           : 
	//        ' Assumptions           : 
	//        ' Dependencies          : 
	//        ' Author                : Mangesh Shardul
	//        ' Created               : 17-Jan-2007 03:25 pm
	//        ' Revisions             : 1
	//        '=====================================================================
	//        Dim tmpEnum As IEnumerator
	//        Dim IsLastRecoed As Boolean = False
	//        Try
	//            'Dim i As Integer
	//            If Not (mobjCurrentStandard Is Nothing) Then
	//                If Not IsNothing(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection) Then
	//                    piStandardEnumarator = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.GetEnumerator()
	//                    piSampleEnumarator.Reset()
	//                    'Try 'by Pankaj on 30 Jan 08
	//                    '    If Not (piStandardEnumarator.Current Is Nothing) Then
	//                    '        mobjCurrentStandard = CType(piStandardEnumarator.Current, Method.clsAnalysisStdParameters)
	//                    '    End If
	//                    'Catch ex As InvalidOperationException
	//                    '    If piStandardEnumarator.MoveNext = True Then
	//                    '        If Not (piStandardEnumarator.Current Is Nothing) Then
	//                    '            mobjCurrentStandard = CType(piStandardEnumarator.Current, Method.clsAnalysisStdParameters)
	//                    '        End If
	//                    '    End If
	//                    'End Try

	//                    'tmpEnum = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.GetEnumerator()
	//                Else
	//                    'tmpEnum = piEnumarator
	//                End If
	//            End If
	//            If Not IsNothing(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection) Then
	//                piSampleEnumarator = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.GetEnumerator()
	//                piSampleEnumarator.Reset()
	//                'Try 'by Pankaj on 30 Jan 08
	//                '    If Not (piSampleEnumarator.Current Is Nothing) Then
	//                '        mobjCurrentSample = CType(piSampleEnumarator.Current, Method.clsAnalysisSampleParameters)
	//                '    End If
	//                'Catch ex As InvalidOperationException
	//                '    If piSampleEnumarator.MoveNext = True Then
	//                '        If Not (piSampleEnumarator.Current Is Nothing) Then
	//                '            mobjCurrentSample = CType(piSampleEnumarator.Current, Method.clsAnalysisSampleParameters)
	//                '        End If
	//                '    End If
	//                'End Try

	//                'tmpEnum = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.GetEnumerator()
	//            Else
	//                'tmpEnum = piEnumarator
	//            End If
	//            Return True
	//        Catch ex As Exception
	//            '---------------------------------------------------------
	//            'Error Handling and logging
	//            gobjErrorHandler.ErrorDescription = ex.Message
	//            gobjErrorHandler.ErrorMessage = ex.Message
	//            gobjErrorHandler.WriteErrorLog(ex)
	//            Return False
	//            '---------------------------------------------------------
	//        Finally
	//            '---------------------------------------------------------
	//            'Writing Execution log
	//            If CONST_CREATE_EXECUTION_LOG = 1 Then
	//                gobjErrorHandler.WriteExecutionLog()
	//            End If
	//            '---------------------------------------------------------
	//        End Try

	//    End Function

	//    Private Sub BlankAnalysis_Clicked(ByVal sender As System.Object, ByVal e As System.EventArgs)
	//        '=====================================================================
	//        ' Procedure Name        : BlankAnalysis_Clicked
	//        ' Parameters Passed     : Object, EventArgs
	//        ' Returns               : Bool
	//        ' Purpose               : perform blank analysis
	//        ' Description           : 
	//        ' Assumptions           : 
	//        ' Dependencies          : 
	//        ' Author                : Mangesh Shardul
	//        ' Created               : 17-Jan-2007 03:25 pm
	//        ' Revisions             : 1
	//        '=====================================================================
	//        'case	IDC_BLANK:
	//        '   SampType=BLANK;
	//        '   break;
	//        Try
	//            ' Set Blank sample type
	//            If Not (SampleType = ClsAAS203.enumSampleType.BLANK) Then
	//                SampleType = ClsAAS203.enumSampleType.BLANK
	//                'Aspiration message for diff. type of sample
	//                Call Aspirate()
	//            End If
	//            If btnReadData.Enabled Then
	//                btnReadData.Focus()
	//                btnReadData.Refresh()
	//            End If
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

	//    Private Sub StartStopAnalysis_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
	//        '=====================================================================
	//        ' Procedure Name        : StartStopAnalysis_Click
	//        ' Parameters Passed     : Object, EventArgs
	//        ' Returns               : None
	//        ' Purpose               : Start/Stop anslysis
	//        ' Description           : 
	//        ' Assumptions           : 
	//        ' Dependencies          : 
	//        ' Author                : Mangesh Shardul
	//        ' Created               : 17-Jan-2007 03:25 pm
	//        ' Revisions             : 1
	//        '=====================================================================
	//        'Started ^= 1;
	//        'InAnalysis ^= 1;

	//        'if(Started & !exitbutton){
	//        '   if (MessageBox(hwnd," New Analysis?", "STD/SAMPLE ANALYSIS", MB_ICONQUESTION | MB_YESNO)==IDYES){
	//        '   SendMessage(hwnd, WM_COMMAND,IDC_QANEW, 0L);
	//        '   }
	//        '}
	//        'WP1= wParam;
	//        'if (!AnaOver && (CurStd==NULL && CurSamp==NULL)){
	//        '   If (!StdAnalysed) Then
	//        '       CurStd  =Method->QuantData->StdTopData;
	//        '   #If STD_ADDN Then
	//        '       if(!Method->QuantData->Param.Std_Addn)
	//        '   #End If
	//        '       CurSamp =Method->QuantData->SampTopData;
	//        '}
	//        'CheckAnaButtons(hwnd);
	//        'if (Started){
	//        '   if (AnaOver){
	//        '       if (MessageBox(hwnd," Data Exists in Memory . \n Erase them ?", "STD/SAMPLE ANALYSIS", MB_YESNO)==IDYES)
	//        '           SendMessage(hwnd, WM_COMMAND,IDC_QANEW, 0L);
	//        '   }
	//        '   SetWindowText(GetDlgItem(hwnd, IDC_QASTART), "E&nd Ana");
	//        '   if (Method->QuantData->Fname<=0)
	//        '   GetRunNo(Method);
	//        '   DisplayRunNo(hwnd);
	//        '}
	//        'else{
	//        '   SetWindowText(GetDlgItem(hwnd, IDC_QASTART), "&Start");
	//        '   RawDataSave("rawdata.txt");
	//        '   if (toreported||!Method->RepReady ){
	//        '   SaveQuantResults(hwnd, Method, A1,0);
	//        '   toreported=FALSE;
	//        '   }
	//        '   DestroyAspWnd();
	//        '}
	//        'InQAnaRead=FALSE;
	//        '#If QDEMO Then
	//        '   if (AnaOver)
	//        '       EndFiledataRead();
	//        '#End If
	//        'break;
	//        '------------------------------------------
	//        Try
	//            If mblnAvoidProcessing = True Then  '10.12.07
	//                Exit Sub
	//            End If
	//            mblnAvoidProcessing = True
	//            ' Start or stop the analysis depending upon setting
	//            If (gstructAutoSampler.blnAutoSamplerInitialised = True) Then ''by Pankaj for autosampler on 10Sep 07
	//                mblnIsAutosampler = gstructAutoSampler.blnCommunication
	//            Else
	//                mblnIsAutosampler = False
	//            End If
	//            mblnIsAnalysisStarted = Not mblnIsAnalysisStarted
	//            InAnalysis = Not InAnalysis
	//            'Check for start Analysis 
	//            If mblnIsAnalysisStarted Then
	//                'If mblnAvoidProcessing = True Then  '10.12.07
	//                '    Exit Sub
	//                'End If
	//                'mblnAvoidProcessing = True
	//                '---
	//                'Saurabh Add to check if 'No' is selected
	//                If (mblnIsAnalysisStarted And (Not exitbutton)) Then
	//                    'Check for to start New Analysis
	//                    If (gobjMessageAdapter.ShowMessage(constNewAnalysis) = True) Then
	//                        'SendMessage(hwnd, WM_COMMAND,IDC_QANEW, 0L)
	//                        If (mblnIsAutosampler And mblnIsAnalysisStarted) Then 'by pankaj on 3 OCt 07
	//                            btnReadData.Enabled = False
	//                        End If
	//                        Call NewAnalysis_Clicked(btnNewAnalysis, EventArgs.Empty)
	//                    Else
	//                        mblnIsAnalysisStarted = Not mblnIsAnalysisStarted
	//                        InAnalysis = Not InAnalysis
	//                        mblnAvoidProcessing = False     '10.12.07
	//                        Exit Sub
	//                    End If
	//                End If
	//                ' if New Analysis is then ....
	//                'Saurabh Add to check if 'No' is selected
	//                btnStartStopAnalysis.Text = "End Anal&ysis"
	//                mstrAspirationMessage = "Click End Analysis button to Stop Analysis."
	//                mobjBgMsgAspirate.AspirationMessage = mstrAspirationMessage
	//                btnReadData.Enabled = True
	//                'Saurabh 10.07.07
	//                'If Not IsNothing(gobjMain.mobjfrmMethod) Then
	//                '    gobjMain.mobjfrmMethod.btnNewMethod.Enabled = False
	//                '    gobjMain.mobjfrmMethod.btnLoadMethod.Enabled = False
	//                'End If
	//                'mblnAvoidProcessing = False     '10.12.07
	//                'Saurabh 10.07.07
	//            Else
	//                ' Stop the Analysis before complite the analysis
	//                ' Set Aspiration Message and buttons caption
	//                btnStartStopAnalysis.Text = "Start Anal&ysis"
	//                mstrAspirationMessage = "Click Start button to Start Analysis."
	//                mobjBgMsgAspirate.AspirationMessage = mstrAspirationMessage
	//                btnReadData.Enabled = False
	//                'Saurabh 10.07.07
	//                'If Not IsNothing(gobjMain.mobjfrmMethod) Then
	//                '    gobjMain.mobjfrmMethod.btnNewMethod.Enabled = True
	//                '    gobjMain.mobjfrmMethod.btnLoadMethod.Enabled = True
	//                'End If
	//                'Saurabh 10.07.07
	//            End If

	//            'Saurabh Shifted on top of this procedure
	//            'If (mblnIsAnalysisStarted And (Not exitbutton)) Then
	//            '    If (gobjMessageAdapter.ShowMessage(constNewAnalysis) = True) Then
	//            '        'SendMessage(hwnd, WM_COMMAND,IDC_QANEW, 0L)
	//            '        Call NewAnalysis_Clicked(btnNewAnalysis, EventArgs.Empty)
	//            '    End If
	//            'End If
	//            'Saurabh Shifted on top of this procedure

	//            'WP1= wParam;
	//            If (Not AnaOver And (IsNothing(mobjCurrentStandard) And IsNothing(mobjCurrentSample))) Then
	//                If Not (StdAnalysed) Then
	//                    'CurStd  =Method->QuantData->StdTopData;
	//                    mobjCurrentStandard = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(0)
	//                End If
	//                '#If STD_ADDN Then
	//                If Not (gobjNewMethod.StandardAddition) Then
	//                    'CurSamp =Method->QuantData->SampTopData;
	//                    mobjCurrentSample = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(0)

	//                End If
	//                '#End If
	//            End If
	//            ' Set the enable/disable property for buttons reguarding of actual analysis 
	//            Call CheckAnaButtons()
	//            ' Check under any circumtancy if analysis is started mode 
	//            ' but Analysis is over (Standard and Sample Analysis)
	//            If (mblnIsAnalysisStarted) Then
	//                If (AnaOver) Then
	//                    If gobjMessageAdapter.ShowMessage(constDataExists) = True Then
	//                        'If (MessageBox.Show(" Data Exists in Memory." & vbCrLf & "Erase them?", "STANDARD/SAMPLE ANALYSIS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
	//                        'SendMessage(hwnd, WM_COMMAND,IDC_QANEW, 0L)
	//                        mblnIsStartRunNumber = False
	//                        'Call GetRunNo(gobjNewMethod)
	//                        Call NewAnalysis_Clicked(btnNewAnalysis, EventArgs.Empty)
	//                    End If
	//                End If

	//                ' Get the Run No from Data collection object
	//                Call GetRunNo(gobjNewMethod)

	//                ' Display Run No in screen
	//                Call DisplayRunNo()

	//                gobjNewMethod.DateOfLastUse = Now

	//                'SetWindowText(GetDlgItem(hwnd, IDC_QASTART), "E&nd Ana")
	//                btnStartStopAnalysis.Text = "E&nd Analysis"

	//                '//----- Previous Standard
	//                'gobjclsStandardGraph = New clsStandardGraph
	//                '//----- Added by Sachin Dokhale 
	//                '//----- Previous Standard
	//                If blnIsLoadPreviousStandards = False Then
	//                    gobjclsStandardGraph = New clsStandardGraph
	//                Else
	//                    If gobjclsStandardGraph Is Nothing Then
	//                        gobjclsStandardGraph = New clsStandardGraph
	//                    End If
	//                End If

	//                '//-----
	//            Else
	//                btnStartStopAnalysis.Text = "&Start Analysis"

	//                'btnEditData.Enabled = True
	//                'when Stop the analysisSave the Row Data into file system and also into method collection object
	//                Call RawDataSave("rawdata.txt")
	//                Call SaveRawDataFile()
	//                Dim A1() As Double = {0, 0, 0, 0, 0, 0}
	//                'if (toreported or  not (Method->RepReady) )
	//                ' Check data is ready to store into system (File System/Collection object)
	//                If (toreported) Then
	//                    'SaveQuantResults(hwnd, Method, A1, 0)
	//                    gobjNewMethod.DateOfLastUse = Now

	//                    '---added by deepak on 20.07.07 for not dsplaying messages in uv mode
	//                    If Not gobjNewMethod.OperationMode = EnumOperationMode.MODE_UVABS Then

	//                        If gobjClsAAS203.SaveQuantResults(gobjNewMethod, A1, 1) = True Then
	//                            mblnIsStartRunNumber = True
	//                        End If
	//                    Else
	//                        ' This function last parameter is "ShowMessage" is use to show messages after saving result.
	//                        ' It is optional and use only for UV Mode analysis
	//                        If gobjClsAAS203.SaveQuantResults(gobjNewMethod, A1, 0, False) = True Then
	//                            mblnIsStartRunNumber = True
	//                        End If
	//                    End If
	//                    'Call gobjClsAAS203.SaveQuantResults(gobjNewMethod, A1, 0)


	//                    'Dim intMethodCounter As Integer
	//                    'For intMethodCounter = 0 To gobjMethodCollection.Count - 1
	//                    '    If gobjMethodCollection.item(intMethodCounter).MethodID = gobjNewMethod.MethodID Then
	//                    '        gobjNewMethod = gobjMethodCollection.item(intMethodCounter).Clone()
	//                    '        Exit For
	//                    '    End If
	//                    'Next

	//                    'mblnIsStartRunNumber = True
	//                    toreported = False
	//                End If
	//                'End If

	//            End If
	//            InQAnaRead = False

	//            '#If QDEMO Then
	//            '   If (AnaOver) Then
	//            '       EndFiledataRead()
	//            '   End If
	//            '#End If
	//            mblnAvoidProcessing = False
	//            'call "ReadData_Click" this event when Autosampler is use and process under started analysis
	//            If (mblnIsAutosampler And mblnIsAnalysisStarted) Then
	//                'SendMessage(hwnd, WM_COMMAND, IDC_QAREAD, 0L)
	//                Call ReadData_Click(btnReadData, EventArgs.Empty) 'by pankaj on 01 Oct07 
	//            End If
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

	//    Private Sub ReadData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReadData.Click
	//        '=====================================================================
	//        ' Procedure Name        : ReadData_Click
	//        ' Parameters Passed     : Object, EventArgs
	//        ' Returns               : None
	//        ' Purpose               : Read data from instrument for analysis
	//        ' Description           : 
	//        ' Assumptions           : 
	//        ' Dependencies          : 
	//        ' Author                : Mangesh Shardul
	//        ' Created               : 17-Jan-2007 03:25 pm
	//        ' Revisions             : 1
	//        '=====================================================================
	//        'case	IDC_QAREAD:

	//        'if(Method->Mode != MODE_UVABS)
	//        '{
	//        '   t = Ignite_Test();
	//        '	if(!GetHydrideModeStatus() && (t == GREEN || t == RED))
	//        '	    {
	//        '		    MessageBox(hwnd,"Flame is OFF.\nAnalysis not possible.","Aspiration Error",MB_ICONSTOP | MB_OK);
	//        '			break;
	//        '		}
	//        '}
	//        '#If STD_ADDN Then
	//        '	if(Method->QuantData->Param.Std_Addn)
	//        '	{
	//        '	    if(endanalysis)
	//        '		SendMessage(hwnd, WM_COMMAND,IDC_QANEW, 0L);
	//        '	}
	//        '#End If
	//        '	InQAnaRead=TRUE;
	//        '	toreported=TRUE;
	//        '	strcpy(Aspiratemsg,"Reading Wait ... ");
	//        '	Disp_Analysis_Info(hwnd);
	//        '	abs1=Read_Quant_Data(hwnd, &AnaGraph);
	//        '	if (!Method->RepReady )
	//        '	{
	//        '	    SaveQuantResults(hwnd, Method, A1,0);
	//        '	}
	//        '   Else
	//        '	    SaveRawDataFile();

	//        '	if(SampType==STD)
	//        '	{
	//        '	    if(!CheckValidStdAbsEntry(Method->QuantData->StdTopData))
	//        '		{
	//        '		    MessageBox(hwnd,"Abs of the std is less than or equal to the previous std.\nPress 'Rpt Last' button for Aspirating the same std again","Std Aspiration Error",MB_ICONSTOP | MB_OK);
	//        '		}
	//        '	}
	//        '	if(SampType==SAMP)
	//        '	{
	//        '	    if(!CheckValidSampAbsEntry(Method->QuantData->StdTopData,abs1))
	//        '		{
	//        '		    MessageBox(hwnd,"Abs of the sample is more than the maximum standard value.\nCalculated Concentration may not be correct.\nPlease dilute the sample and repeat again.\nPress RptLast button when ready.","Sample Aspiration Error",MB_ICONSTOP | MB_OK);
	//        '		}
	//        '	}
	//        '	SendMessage(hwnd, WM_COMMAND, 900, 0L);//IDC_QANEXT, 0L);
	//        '	break;



	//        '----CODE BY MANEGSH 

	//        'startRead:
	//        Dim intEnumIgiteType As ClsAAS203.enumIgniteType

	//        Try
	//            If mblnAvoidProcessing = True And mblnIsAutosampler = False Then
	//                Exit Sub
	//            End If
	//            mblnAvoidProcessing = True

	//            gobjMain.mobjController.Cancel()
	//            gobjCommProtocol.mobjCommdll.subTime_Delay(500)   '10.12.07

	//            Application.DoEvents()

	//            If Not (gobjNewMethod.OperationMode = EnumOperationMode.MODE_UVABS) Then

	//                If (gstructSettings.AppMode = EnumAppMode.DemoMode) Or _
	//                    (gstructSettings.AppMode = EnumAppMode.DemoMode_201) Or _
	//                    (gstructSettings.AppMode = EnumAppMode.DemoMode_203D) Then
	//                    intEnumIgiteType = ClsAAS203.enumIgniteType.Blue
	//                Else
	//                    If gobjMain.mobjController.IsThreadRunning = False Then

	//                        '--- Modified function of funcIgnite_Test by Sachin Dokhale on 04.02.07
	//                        'intEnumIgiteType = gobjClsAAS203.funcIgnite_Test()
	//                        Dim intIgnite_Test As ClsAAS203.enumIgniteType
	//                        If gobjClsAAS203.funcIgnite_Test(intIgnite_Test) Then
	//                            intEnumIgiteType = intIgnite_Test
	//                        End If
	//                        '---
	//                    Else
	//                        intEnumIgiteType = gobjfrmStatus.FlameType
	//                    End If
	//                End If
	//                gobjfrmStatus.FlameType = intEnumIgiteType
	//                If ((Not HydrideMode) And (intEnumIgiteType = ClsAAS203.enumIgniteType.Green Or gobjMain.IgniteType = ClsAAS203.enumIgniteType.Red)) Then
	//                    'gobjMessageAdapter.ShowMessage("Flame is OFF." & vbCrLf & "Analysis not possible.", "Aspiration Error", MessageHandler.clsMessageHandler.enumMessageType.ErrorMessage)
	//                    gobjMessageAdapter.ShowMessage(constFlameOFF)
	//                    If gobjMain.mobjController.IsThreadRunning = False Then
	//                        gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay)
	//                        Application.DoEvents()
	//                        gobjMain.mobjController.Start(gobjclsBgFlameStatus)
	//                    End If
	//                    mblnAvoidProcessing = False
	//                    Exit Sub
	//                End If
	//            End If

	//            '  Check when standaed addtion Flag is On and Analysis is complite 
	//            '  then continue to start New Analysis from begin.
	//            '#If STD_ADDN Then
	//            If (gobjNewMethod.StandardAddition) Then
	//                If (EndAnalysis) Then
	//                    'SendMessage(hwnd, WM_COMMAND, IDC_QANEW, 0L)
	//                    Call NewAnalysis_Clicked(btnNewAnalysis, EventArgs.Empty)
	//                    gobjMain.mobjController.Cancel()
	//                    gobjCommProtocol.mobjCommdll.subTime_Delay(500)   '10.12.07
	//                    Application.DoEvents()
	//                End If
	//            End If
	//            '#End If

	//            ' Set this flag to show report 
	//            InQAnaRead = True
	//            toreported = True

	//            mstrAspirationMessage = "Reading Wait ... "
	//            mobjBgMsgAspirate.AspirationMessage = mstrAspirationMessage

	//            'Call gobjCommProtocol.mobjCommdll.subTime_Delay(1200)
	//            Call Application.DoEvents()

	//            ' To Display Analysis information.
	//            Call Display_Analysis_Info()
	//            '//----- Added by Sachin Dokhale
	//            'btnReadData.Enabled = False
	//            'RemoveHandler btnReadData.Click, AddressOf ReadData_Click

	//            If Not (Afirst) Then
	//                mEndTime = mobjBgReadData.CEndTime
	//            Else
	//                mEndTime = mStartTime
	//            End If

	//            mdblAbsorbance = Read_Quant_Data(mStartTime, mEndTime)


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

	//    Private Sub frmAnalysis_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
	//        '=====================================================================
	//        ' Procedure Name        : frmAnalysis_Closing
	//        ' Parameters Passed     : object, EventArgs
	//        ' Returns               : None
	//        ' Purpose               : 
	//        ' Description           : 
	//        ' Assumptions           : 
	//        ' Dependencies          : 
	//        ' Author                : Mangesh Shardul
	//        ' Created               : 16-Mar-2007 12:45 pm
	//        ' Revisions             : 1
	//        '=====================================================================
	//        gobjMain.ShowRunTimeInfo(ConstParentFormLoad)
	//    End Sub

	//    Private Sub btnEditData_Clicked(ByVal sender As Object, ByVal e As EventArgs)
	//        '=====================================================================
	//        ' Procedure Name        : btnEditData_Clicked
	//        ' Parameters Passed     : object, EventArgs
	//        ' Returns               : None
	//        ' Purpose               : 
	//        ' Description           : 
	//        ' Assumptions           : 
	//        ' Dependencies          : 
	//        ' Author                : Mangesh Shardul
	//        ' Created               : 16-Mar-2007 12:45 pm
	//        ' Revisions             : 1
	//        '=====================================================================

	//        '---- ORIGINAL CODE

	//        'BOOL	OnViewRepeats(HWND	hpar)
	//        '{
	//        '   BOOL	flag = FALSE;
	//        '   DLGPROC  skp1;
	//        '   if (Method->QuantData==NULL)
	//        '	    return flag;
	//        '   if ((Method->QuantData->Param.Repeat>1 || Method->QuantData->Param.ConcRepeat>1 )&&  FindSamplesAnalysed()>=1) 
	//        '   {
	//        '	    skp1 =(DLGPROC) MakeProcInstance((DLGPROC) OnViewRepeatsProc,hInst);
	//        '	    flag = DialogBox(hInst,"QVIEWRPTS", hpar, skp1);
	//        '	    FreeProcInstance(skp1);
	//        '  }
	//        '   Else
	//        '	    flag = OnEditStdSamples(hpar);
	//        '   return flag;
	//        '}
	//        '****************************************************************
	//        Dim flag As Boolean = False
	//        Dim objfrmDeleteStdNSam As frmDeleteStdNSam
	//        Dim objfrmViewRepeatResults As frmViewRepeatResults

	//        Try
	//            'validate objects Quantitative data collection
	//            If IsNothing(gobjNewMethod.QuantitativeDataCollection) Then
	//                Return
	//            End If

	//            If ((gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfSampleRepeats > 1 _
	//              Or gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfStdRepeats > 1) _
	//              And clsStandardGraph.FindSamplesAnalysed(gobjNewMethod, mintRunNumberIndex) >= 1) Then
	//                'show result
	//                objfrmViewRepeatResults = New frmViewRepeatResults(gobjNewMethod, mintRunNumberIndex)
	//                objfrmViewRepeatResults.ShowDialog()
	//                Application.DoEvents()
	//                objfrmViewRepeatResults.Close()
	//                objfrmViewRepeatResults.Dispose()
	//                objfrmViewRepeatResults = Nothing
	//            Else
	//                'flag = OnEditStdSamples()
	//                objfrmDeleteStdNSam = New frmDeleteStdNSam(gobjNewMethod, mintRunNumberIndex)
	//                If objfrmDeleteStdNSam.ShowDialog() = DialogResult.OK Then
	//                    tlbbtnSampleGraph_Click(sender, e)
	//                End If
	//                objfrmDeleteStdNSam.Close()
	//                Application.DoEvents()
	//                If Not objfrmDeleteStdNSam Is Nothing Then
	//                    objfrmDeleteStdNSam.Dispose()
	//                End If
	//                objfrmDeleteStdNSam = Nothing
	//                flag = True
	//            End If
	//            If btnReadData.Enabled Then
	//                btnReadData.Focus()
	//                btnReadData.Refresh()
	//            End If
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

	//    'Private Sub XpPanelReports_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs)
	//    '    '=====================================================================
	//    '    ' Procedure Name        : XpPanelReportsClicked
	//    '    ' Parameters Passed     : Object,EventArgs
	//    '    ' Returns               : None
	//    '    ' Purpose               : To view the Reports
	//    '    ' Description           : 
	//    '    ' Assumptions           : 
	//    '    ' Dependencies          : 
	//    '    ' Author                : Deepak & Saurabh
	//    '    ' Created               : 05.10.06
	//    '    ' Revisions             : 
	//    '    '===================================================================== 
	//    '    Dim objWait As New CWaitCursor

	//    '    Try
	//    '        If Me.XpPanelReports.PanelState = UIComponents.XPPanelState.Collapsed Then
	//    '            Call funcCollapseAllXPPanels()
	//    '            Me.XpPanelReports.TogglePanelState()
	//    '            Me.XpPanelReports.PanelHeight = 80
	//    '        End If

	//    '    Catch ex As Exception
	//    '        '---------------------------------------------------------
	//    '        'Error Handling and logging
	//    '        gobjErrorHandler.ErrorDescription = ex.Message
	//    '        gobjErrorHandler.ErrorMessage = ex.Message
	//    '        gobjErrorHandler.WriteErrorLog(ex)
	//    '        '---------------------------------------------------------
	//    '    Finally
	//    '        '---------------------------------------------------------
	//    '        'Writing Execution log
	//    '        If CONST_CREATE_EXECUTION_LOG = 1 Then
	//    '            gobjErrorHandler.WriteExecutionLog()
	//    '        End If
	//    '        If Not objWait Is Nothing Then
	//    '            objWait.Dispose()
	//    '        End If
	//    '        '---------------------------------------------------------
	//    '    End Try
	//    'End Sub

	//    'Private Sub XpPanelSampleGraph_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs)
	//    '    '=====================================================================
	//    '    ' Procedure Name        : XpPanelSampleGraphClicked
	//    '    ' Parameters Passed     : Object,EventArgs
	//    '    ' Returns               : None
	//    '    ' Purpose               : To view the Sample Graphs
	//    '    ' Description           : 
	//    '    ' Assumptions           : 
	//    '    ' Dependencies          : 
	//    '    ' Author                : Deepak & Saurabh
	//    '    ' Created               : 05.10.06
	//    '    ' Revisions             : 
	//    '    '===================================================================== 
	//    '    Dim objWait As New CWaitCursor

	//    '    Try
	//    '        If Me.XpPanelSampleGraph.PanelState = UIComponents.XPPanelState.Collapsed Then
	//    '            Call funcCollapseAllXPPanels()
	//    '            Me.XpPanelSampleGraph.TogglePanelState()
	//    '            Me.XpPanelSampleGraph.PanelHeight = 90
	//    '        End If

	//    '    Catch ex As Exception
	//    '        '---------------------------------------------------------
	//    '        'Error Handling and logging
	//    '        gobjErrorHandler.ErrorDescription = ex.Message
	//    '        gobjErrorHandler.ErrorMessage = ex.Message
	//    '        gobjErrorHandler.WriteErrorLog(ex)
	//    '        '---------------------------------------------------------
	//    '    Finally
	//    '        '---------------------------------------------------------
	//    '        'Writing Execution log
	//    '        If CONST_CREATE_EXECUTION_LOG = 1 Then
	//    '            gobjErrorHandler.WriteExecutionLog()
	//    '        End If
	//    '        If Not objWait Is Nothing Then
	//    '            objWait.Dispose()
	//    '        End If
	//    '        '---------------------------------------------------------
	//    '    End Try
	//    'End Sub

	//    'Private Sub XpPanelStandardGraph_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs)
	//    '    '=====================================================================
	//    '    ' Procedure Name        : XpPanelStandardGraphClicked
	//    '    ' Parameters Passed     : Object,EventArgs
	//    '    ' Returns               : None
	//    '    ' Purpose               : To load the Standard Graph form
	//    '    ' Description           : 
	//    '    ' Assumptions           : 
	//    '    ' Dependencies          : 
	//    '    ' Author                : Deepak & Saurabh
	//    '    ' Created               : 05.10.06
	//    '    ' Revisions             : 
	//    '    '===================================================================== 
	//    '    Dim objWait As New CWaitCursor

	//    '    Try
	//    '        If Me.XpPanelStandardGraph.PanelState = UIComponents.XPPanelState.Collapsed Then
	//    '            Call funcCollapseAllXPPanels()
	//    '            Me.XpPanelStandardGraph.TogglePanelState()
	//    '            Me.XpPanelStandardGraph.PanelHeight = 80
	//    '        End If

	//    '    Catch ex As Exception
	//    '        '---------------------------------------------------------
	//    '        'Error Handling and logging
	//    '        gobjErrorHandler.ErrorDescription = ex.Message
	//    '        gobjErrorHandler.ErrorMessage = ex.Message
	//    '        gobjErrorHandler.WriteErrorLog(ex)
	//    '        '---------------------------------------------------------
	//    '    Finally
	//    '        '---------------------------------------------------------
	//    '        'Writing Execution log
	//    '        If CONST_CREATE_EXECUTION_LOG = 1 Then
	//    '            gobjErrorHandler.WriteExecutionLog()
	//    '        End If
	//    '        If Not objWait Is Nothing Then
	//    '            objWait.Dispose()
	//    '        End If
	//    '        '---------------------------------------------------------
	//    '    End Try
	//    'End Sub

	//    'Private Sub XpPanelViewResults_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs)
	//    '    '=====================================================================
	//    '    ' Procedure Name        : XpPanelViewResultsClicked
	//    '    ' Parameters Passed     : Object,EventArgs
	//    '    ' Returns               : None
	//    '    ' Purpose               : To view the Results
	//    '    ' Description           : 
	//    '    ' Assumptions           : 
	//    '    ' Dependencies          : 
	//    '    ' Author                : Deepak & Saurabh
	//    '    ' Created               : 05.10.06
	//    '    ' Revisions             : 
	//    '    '===================================================================== 
	//    '    Dim objWait As New CWaitCursor

	//    '    Try
	//    '        If Me.XpPanelViewResults.PanelState = UIComponents.XPPanelState.Collapsed Then
	//    '            Call funcCollapseAllXPPanels()
	//    '            Me.XpPanelViewResults.TogglePanelState()
	//    '            Me.XpPanelViewResults.PanelHeight = 80
	//    '        End If

	//    '    Catch ex As Exception
	//    '        '---------------------------------------------------------
	//    '        'Error Handling and logging
	//    '        gobjErrorHandler.ErrorDescription = ex.Message
	//    '        gobjErrorHandler.ErrorMessage = ex.Message
	//    '        gobjErrorHandler.WriteErrorLog(ex)
	//    '        '---------------------------------------------------------
	//    '    Finally
	//    '        '---------------------------------------------------------
	//    '        'Writing Execution log
	//    '        If CONST_CREATE_EXECUTION_LOG = 1 Then
	//    '            gobjErrorHandler.WriteExecutionLog()
	//    '        End If
	//    '        If Not objWait Is Nothing Then
	//    '            objWait.Dispose()
	//    '        End If
	//    '        '---------------------------------------------------------
	//    '    End Try
	//    'End Sub

	//    'Private Sub AASGraphAnalysis_GraphScaleChanged(ByVal XMin As Double, ByVal XMax As Double, ByVal YMin As Double, ByVal YMax As Double) Handles AASGraphAnalysis.GraphScaleChanged
	//    '    '=====================================================================
	//    '    ' Procedure Name        : AASGraphAnalysis_GraphScaleChanged
	//    '    ' Parameters Passed     : XMin, XMax, YMin, YMax  
	//    '    ' Returns               : None
	//    '    ' Purpose               : Set the property of graph 
	//    '    ' Description           : 
	//    '    ' Assumptions           : 
	//    '    ' Dependencies          : 
	//    '    ' Author                : Mangesh Shardul
	//    '    ' Created               : 17-Jan-2007 03:25 pm
	//    '    ' Revisions             : 1
	//    '    '=====================================================================
	//    '    Try
	//    '        'Set the property of graph object
	//    '        AASGraphAnalysis.AldysPane.XAxis.MinorStepAuto = False
	//    '        AASGraphAnalysis.AldysPane.XAxis.StepAuto = False
	//    '        AASGraphAnalysis.AldysPane.YAxis.MinorStepAuto = False
	//    '        AASGraphAnalysis.AldysPane.YAxis.StepAuto = False
	//    '        '---changed by deepak on 29.04.07
	//    '        AASGraphAnalysis.YAxisStep = 0.2
	//    '        AASGraphAnalysis.YAxisMinorStep = 0.1
	//    '        '---changed by deepak on 29.04.07
	//    '        'set focus to read data button
	//    '        AASGraphAnalysis.Refresh()
	//    '        If btnReadData.Enabled Then
	//    '            btnReadData.Focus()
	//    '            btnReadData.Refresh()
	//    '        End If
	//    '    Catch ex As Exception
	//    '        '---------------------------------------------------------
	//    '        'Error Handling and logging
	//    '        gobjErrorHandler.ErrorDescription = ex.Message
	//    '        gobjErrorHandler.ErrorMessage = ex.Message
	//    '        gobjErrorHandler.WriteErrorLog(ex)
	//    '        '---------------------------------------------------------
	//    '    Finally
	//    '        '---------------------------------------------------------
	//    '        'Writing Execution log
	//    '        If CONST_CREATE_EXECUTION_LOG = 1 Then
	//    '            gobjErrorHandler.WriteExecutionLog()
	//    '        End If
	//    '        '---------------------------------------------------------
	//    '    End Try
	//    'End Sub

	//    'Private Sub cmdChangeScale_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdChangeScale.Click
	//    '    '=====================================================================
	//    '    ' Procedure Name        : cmdChangeScale_Click
	//    '    ' Parameters Passed     : Object,EventArgs
	//    '    ' Returns               : None
	//    '    ' Purpose               : 
	//    '    ' Description           : calculte change scale
	//    '    ' Assumptions           : 
	//    '    ' Dependencies          : 
	//    '    ' Author                : Pankaj Bamb
	//    '    ' Created               : 1.05.07
	//    '    ' Revisions             : 
	//    '    '=====================================================================
	//    '    If mblnAvoidProcessing = True Then
	//    '        Exit Sub
	//    '    End If
	//    '    Dim objWait As New CWaitCursor
	//    '    Dim objfrmChangeScale As frmChangeScale

	//    '    Try
	//    '        mblnAvoidProcessing = True
	//    '        objfrmChangeScale = New frmChangeScale(mobjParameters, False)
	//    '        objfrmChangeScale.funcSetValidatingScale(gobjInst.Mode)
	//    '        objfrmChangeScale.lblXAxis.Visible = False
	//    '        '-------------Added By Pankaj 11 May 07 for showing default scale on change form
	//    '        objfrmChangeScale.SpectrumParameter.XaxisMin = AASGraphAnalysis.XAxisMin
	//    '        objfrmChangeScale.SpectrumParameter.XaxisMax = AASGraphAnalysis.XAxisMax

	//    '        objfrmChangeScale.SpectrumParameter.YaxisMin = AASGraphAnalysis.YAxisMin
	//    '        objfrmChangeScale.SpectrumParameter.YaxisMax = AASGraphAnalysis.YAxisMax
	//    '        '------------------------
	//    '        If objfrmChangeScale.ShowDialog() = DialogResult.OK Then
	//    '            'update scale data structur by user supplied values
	//    '            If Not objfrmChangeScale.SpectrumParameter Is Nothing Then
	//    '                mobjParameters.XaxisMax = objfrmChangeScale.SpectrumParameter.XaxisMax
	//    '                mobjParameters.XaxisMin = objfrmChangeScale.SpectrumParameter.XaxisMin
	//    '                mobjParameters.YaxisMax = objfrmChangeScale.SpectrumParameter.YaxisMax
	//    '                mobjParameters.YaxisMin = objfrmChangeScale.SpectrumParameter.YaxisMin
	//    '            End If
	//    '            AASGraphAnalysis.XAxisMin = mobjParameters.XaxisMin
	//    '            AASGraphAnalysis.XAxisMax = mobjParameters.XaxisMax
	//    '            AASGraphAnalysis.YAxisMin = mobjParameters.YaxisMin
	//    '            AASGraphAnalysis.YAxisMax = mobjParameters.YaxisMax
	//    '            'adjust scale in proper range
	//    '            Call gobjClsAAS203.Calculate_Analysis_Graph_Param(AASGraphAnalysis, ClsAAS203.enumChangeAxis.xyAxis)

	//    '        End If
	//    '        objfrmChangeScale.Close()
	//    '        'set the focus on read data button
	//    '        If btnReadData.Enabled Then
	//    '            btnReadData.Focus()
	//    '            btnReadData.Refresh()
	//    '        End If
	//    '        mblnAvoidProcessing = False
	//    '    Catch ex As Exception
	//    '        '---------------------------------------------------------
	//    '        'Error Handling and logging
	//    '        gobjErrorHandler.ErrorDescription = ex.Message
	//    '        gobjErrorHandler.ErrorMessage = ex.Message
	//    '        gobjErrorHandler.WriteErrorLog(ex)
	//    '        '---------------------------------------------------------
	//    '    Finally
	//    '        '---------------------------------------------------------
	//    '        'Writing Execution log
	//    '        If CONST_CREATE_EXECUTION_LOG = 1 Then
	//    '            gobjErrorHandler.WriteExecutionLog()
	//    '        End If
	//    '        objfrmChangeScale.Dispose()
	//    '        If Not objWait Is Nothing Then
	//    '            objWait.Dispose()
	//    '        End If
	//    '        'mblnAvoidProcessing = False
	//    '        '---------------------------------------------------------
	//    '    End Try
	//    'End Sub

	//    Private Sub tlbbtnExportReport_Click(ByVal sender As Object, ByVal e As System.EventArgs)
	//        '=====================================================================
	//        ' Procedure Name        : tlbbtnExportReport_Click
	//        ' Parameters Passed     : Object, EventArgs
	//        ' Returns               : 
	//        ' Purpose               : Export data to the text file format
	//        ' Description           : 
	//        ' Assumptions           : 
	//        ' Dependencies          : 
	//        ' Author                : Saurabh S & Sachin Dokhale
	//        ' Created               : 05.10.06
	//        ' Revisions             : 
	//        '=====================================================================
	//        Dim objWait As New CWaitCursor
	//        Dim intSelectId As Integer
	//        Dim intCount As Integer
	//        Try
	//            'Added By Pankaj Fri 18 May 07
	//            ' Check for 21CFR option
	//            If (gstructSettings.Enable21CFR = True) Then
	//                If Not funcCheckActivityAuthentication(enumActivityAuthentication.Export, gstructUserDetails.Access) Then
	//                    Return
	//                    Exit Sub
	//                End If
	//                gfuncInsertActivityLog(EnumModules.Export, "Export Accessed")
	//            End If

	//            '    tlbbtnLoad.SuspendEvents()
	//            'mobjClsDataFileReport.MethodID = mintSelectedMethodID
	//            'mobjClsDataFileReport.RunNumber = mintSelectedRunNumber
	//            'For intCount = 0 To gobjMethodCollection.Count - 1
	//            '    If mintSelectedMethodID = gobjMethodCollection(intCount).MethodID Then
	//            '        intSelectId = intCount
	//            '        mobjClsDataFileReport.MethodID = intCount
	//            '        Exit For
	//            '    End If
	//            'Next
	//            Dim strRunNo As String
	//            'strRunNo = mobjClsMethod.QuantitativeDataCollection.Item(intCount).RunNumber

	//            ' Search Method id
	//            For intCount = 0 To gobjMethodCollection.Count - 1
	//                If mintSelectedMethodID = gobjMethodCollection(intCount).MethodID Then
	//                    'intSelectIDIndex = intCount
	//                    intSelectId = intCount
	//                    'mobjClsDataFileReport.MethodID = intCount
	//                    mobjClsDataFileReport.MethodID = gobjMethodCollection(intCount).MethodID
	//                    Exit For
	//                End If
	//            Next
	//            ' Search run No
	//            strRunNo = gobjNewMethod.QuantitativeDataCollection.Item(0).RunNumber
	//            For intCount = 0 To gobjMethodCollection(intSelectId).QuantitativeDataCollection.Count - 1
	//                If strRunNo = CInt(gobjMethodCollection(intSelectId).QuantitativeDataCollection(intCount).RunNumber) Then
	//                    mobjClsDataFileReport.RunNumber = CLng(strRunNo)
	//                    Exit For
	//                End If
	//            Next

	//            'For intCount = 0 To gobjMethodCollection(intSelectId).QuantitativeDataCollection.Count - 1
	//            '    If mintSelectedRunNumber = CInt(gobjMethodCollection(intSelectId).QuantitativeDataCollection(intCount).RunNumber) Then

	//            '        mobjClsDataFileReport.RunNumber = mintSelectedRunNumber
	//            '        Exit For
	//            '    End If
	//            'Next
	//            ' Send data to export facility.
	//            Call mobjClsDataFileReport.funcDatafileExport(gobjMethodCollection(intSelectId).QuantitativeDataCollection(intCount).ReportParameters)
	//            If btnReadData.Enabled Then
	//                btnReadData.Focus()
	//                btnReadData.Refresh()
	//            End If
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
	//            If Not objWait Is Nothing Then
	//                objWait.Dispose()
	//            End If
	//            '---------------------------------------------------------
	//        End Try
	//    End Sub

	//    Private Sub btnImport_Click(ByVal sender As Object, ByVal e As System.EventArgs)
	//        '=====================================================================
	//        ' Procedure Name        : tlbbtnLoad_Click
	//        ' Parameters Passed     : Object, EventArgs
	//        ' Returns               : 
	//        ' Purpose               : To load the Analysis already saved.
	//        ' Description           : 
	//        ' Assumptions           : 
	//        ' Dependencies          : 
	//        ' Author                : Saurabh S
	//        ' Created               : 05.10.06
	//        ' Revisions             : 
	//        '=====================================================================
	//        Dim objWait As New CWaitCursor
	//        Dim intRunNumberIndex As Long
	//        Dim intCounter As Integer
	//        Dim intCount As Integer
	//        Dim strRunNo As String
	//        Dim objfrmLoadAnalysis As New frmLoadAnalysis
	//        Dim objClsMethod As clsMethod
	//        Dim intSelectedMethodID As Integer
	//        Dim lngSelectedRunNumber As Long
	//        Try
	//            'tlbbtnLoad.SuspendEvents()

	//            ' Restore the Row Data of Run no from Data result collection object

	//            objfrmLoadAnalysis.GroupBox2.Visible = True
	//            objfrmLoadAnalysis.btnDeleteRun.Visible = False
	//            objfrmLoadAnalysis.gbMultiElementReport.Visible = False
	//            If objfrmLoadAnalysis.ShowDialog() = DialogResult.Cancel Then
	//                Exit Sub
	//            End If

	//            intSelectedMethodID = objfrmLoadAnalysis.SelectedMethodID
	//            lngSelectedRunNumber = objfrmLoadAnalysis.SelectedRunNumber
	//            objfrmLoadAnalysis.Close()
	//            objfrmLoadAnalysis.Dispose()
	//            '//-----
	//            mobjAnalysisRawData = Nothing
	//            mobjAnalysisRawData = New Analysis.clsRawDataCollection

	//            mobjBlankRawData = Nothing
	//            mobjStandardRawData = Nothing
	//            mobjSampleRawData = Nothing

	//            intRunNumberIndex = modGlobalFunctions.gfuncGetSelectedMethodRunNumberIndex(mintSelectedMethodID, mlngSelectedRunNumber)

	//            For intCounter = 0 To gobjMethodCollection.Count - 1
	//                If gobjMethodCollection.item(intCounter).MethodID = intSelectedMethodID Then

	//                    'mobjClsMethod = gobjMethodCollection.item(intCounter).Clone()

	//                    'mobjClsMethod.QuantitativeDataCollection.Item(intRunNumberIndex).AnalysisRawData(0).SampleType = clsRawData.enumSampleType.BLANK
	//                    'Dim int As Integer
	//                    For intRunNumberIndex = 0 To gobjMethodCollection.item(intCounter).QuantitativeDataCollection.Count - 1
	//                        If lngSelectedRunNumber = gobjMethodCollection.item(intCounter).QuantitativeDataCollection.Item(intRunNumberIndex).RunNumber Then

	//                            Afirst = False


	//                            Exit For

	//                        End If

	//                    Next
	//                    Dim i As Integer
	//                    intIEnumCollLocationStd = 0
	//                    intIEnumCollLocationSamp = 0
	//                    For i = 0 To gobjMethodCollection.item(intCounter).QuantitativeDataCollection.Item(intRunNumberIndex).AnalysisRawData.Count - 1
	//                        mobjAnalysisRawData.Add(gobjMethodCollection.item(intCounter).QuantitativeDataCollection.Item(intRunNumberIndex).AnalysisRawData(i))
	//                        'mobjClsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisRawData = mobjAnalysisRawData
	//                        If gobjMethodCollection.item(intCounter).QuantitativeDataCollection.Item(intRunNumberIndex).AnalysisRawData(i).SampleType = clsRawData.enumSampleType.SAMPLE Then
	//                            intIEnumCollLocationSamp += 1
	//                        ElseIf gobjMethodCollection.item(intCounter).QuantitativeDataCollection.Item(intRunNumberIndex).AnalysisRawData(i).SampleType = clsRawData.enumSampleType.STANDARD Then
	//                            intIEnumCollLocationStd += 1
	//                        End If
	//                    Next

	//                    '//----

	//                    mobjCurrentStandard = Nothing
	//                    mobjCurrentSample = Nothing
	//                    If intIEnumCollLocationSamp <= 0 Then
	//                        'mobjCurrentStandard = gobjMethodCollection.item(intCounter).QuantitativeDataCollection(intRunNumberIndex).StandardDataCollection(intIEnumCollLocationStd - 1)
	//                        Call funcGetCurrentStandard(mobjCurrentStandard)
	//                    Else
	//                        'mobjCurrentSample = gobjMethodCollection.item(intCounter).QuantitativeDataCollection(intRunNumberIndex).SampleDataCollection(intIEnumCollLocationSamp - 1)
	//                        Call funcGetCurrentSample(mobjCurrentSample)
	//                    End If



	//                    Dim i1 As Integer = gobjMethodCollection.item(intCounter).QuantitativeDataCollection.Item(intRunNumberIndex).AnalysisRawData(i - 1).Readings.Count - 1

	//                    mobjBgReadData.CEndTime = gobjMethodCollection.item(intCounter).QuantitativeDataCollection(intRunNumberIndex).AnalysisRawData(i - 1).Readings(i1).XTime
	//                    mEndTime = mobjBgReadData.CEndTime
	//                    SampleType = gobjMethodCollection.item(intCounter).QuantitativeDataCollection.Item(intRunNumberIndex).AnalysisRawData(i - 1).SampleType
	//                    Call NextAnalysis_Clicked(btnNextAnalysis, EventArgs.Empty)
	//                    Application.DoEvents()
	//                    Call Aspirate()
	//                    Application.DoEvents()
	//                    '//----- Sachin Dokhale
	//                    'StdAnalysed=TRUE;
	//                    'toreported=TRUE;
	//                    'InvalidateRect(hwnd, NULL, TRUE);
	//                    'EnableWindow(GetDlgItem(hwnd,IDC_SAVEREPORT), StdAnalysed);
	//                    StdAnalysed = True
	//                    toreported = True
	//                    'btnSave.Enabled = StdAnalysed
	//                    '//-----



	//                    'Call funcShowMethodGeneralInfo(mobjClsMethod, strRunNo)
	//                    Select Case gobjMethodCollection.item(intCounter).OperationMode
	//                        Case EnumOperationMode.MODE_UVABS
	//                            'AASGraphAnalysis.Visible = False
	//                        Case Else
	//                            strRunNo = gobjMethodCollection.item(intCounter).QuantitativeDataCollection.Item(intRunNumberIndex).RunNumber
	//                            'AASGraphAnalysis.Visible = True
	//                            'Call gobjClsAAS203.subShowGraphPreview(Me.AASGraphAnalysis, mobjGraphCurve, strRunNo, gobjMethodCollection.item(intCounter))
	//                            'AASGraphAnalysis.Invalidate()
	//                            'AASGraphAnalysis.IsShowGrid = True      'Saurabh To show Grid 19.07.07
	//                            'AASGraphAnalysis.Refresh()
	//                            Me.Refresh()
	//                            Application.DoEvents()
	//                    End Select


	//                    Exit For

	//                End If
	//            Next

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
	//            If Not objWait Is Nothing Then
	//                objWait.Dispose()
	//            End If
	//            'tlbbtnLoad.ResumeEvents()
	//            '---------------------------------------------------------
	//        End Try
	//    End Sub

	//    'Private Sub subGetRowDatafileInfoIntoObject(ByVal objClsMethodIn As clsMethod)
	//    '    Try
	//    '        ' objClsMethodIn.InstrumentCondition()

	//    '    Catch ex As Exception
	//    '        '---------------------------------------------------------
	//    '        'Error Handling and logging
	//    '        gobjErrorHandler.ErrorDescription = ex.Message
	//    '        gobjErrorHandler.ErrorMessage = ex.Message
	//    '        gobjErrorHandler.WriteErrorLog(ex)
	//    '        '---------------------------------------------------------
	//    '    Finally
	//    '        '---------------------------------------------------------
	//    '        'Writing Execution log
	//    '        If CONST_CREATE_EXECUTION_LOG = 1 Then
	//    '            gobjErrorHandler.WriteExecutionLog()
	//    '        End If
	//    '        '---------------------------------------------------------
	//    '    End Try
	//    'End Sub

	//    'Private Sub btnExtinguish_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExtinguish.Click
	//    '    '=====================================================================
	//    '    ' Procedure Name        : btnExtinguish_Click
	//    '    ' Parameters Passed     : Object, EventArgs
	//    '    ' Returns               : None
	//    '    ' Purpose               : 
	//    '    ' Description           : 
	//    '    ' Assumptions           : 
	//    '    ' Dependencies          : 
	//    '    ' Author                : Mangesh Shardul
	//    '    ' Created               : 18-Feb-2007 03:15 pm
	//    '    ' Revisions             : 1
	//    '    '=====================================================================
	//    '    Try
	//    '        'RemoveHandler mnuExtinguish.Click, AddressOf btnExtinguish_Click

	//    '        If Not gstructSettings.AppMode = EnumAppMode.DemoMode Then
	//    '            If Not IsNothing(gobjMain.mobjfrmAnalysis) Then gobjMain.mobjfrmAnalysis.tmrAspirationMsg.Enabled = False
	//    '            gobjMain.mobjController.Cancel()
	//    '            Application.DoEvents()
	//    '            Call gobjClsAAS203.funcIgnite(False)
	//    '        Else
	//    '            Call gobjMessageAdapter.ShowMessage("Flame Extinguished", "AUTO EXTINGUISH", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage)
	//    '            Application.DoEvents()
	//    '        End If

	//    '    Catch ex As Exception
	//    '        '---------------------------------------------------------
	//    '        'Error Handling and logging
	//    '        gobjErrorHandler.ErrorDescription = ex.Message
	//    '        gobjErrorHandler.ErrorMessage = ex.Message
	//    '        gobjErrorHandler.WriteErrorLog(ex)
	//    '        '---------------------------------------------------------
	//    '    Finally
	//    '        '---------------------------------------------------------
	//    '        'Writing Execution log
	//    '        If CONST_CREATE_EXECUTION_LOG = 1 Then
	//    '            gobjErrorHandler.WriteExecutionLog()
	//    '        End If
	//    '        If Not gstructSettings.AppMode = EnumAppMode.DemoMode Then
	//    '            If Not IsNothing(gobjMain.mobjfrmAnalysis) Then gobjMain.mobjfrmAnalysis.tmrAspirationMsg.Enabled = True
	//    '            gobjMain.mobjController.Start(gobjclsBgFlameStatus)
	//    '            Application.DoEvents()
	//    '        End If
	//    '        'AddHandler mnuExtinguish.Click, AddressOf btnExtinguish_Click
	//    '        '---------------------------------------------------------
	//    '    End Try
	//    'End Sub

	//    'Private Sub btnIgnite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIgnite.Click
	//    '    '=====================================================================
	//    '    ' Procedure Name        : btnAutoIgnition_Click
	//    '    ' Parameters Passed     : Object, EventArgs
	//    '    ' Returns               : None
	//    '    ' Purpose               : 
	//    '    ' Description           : 
	//    '    ' Assumptions           : 
	//    '    ' Dependencies          : 
	//    '    ' Author                : Mangesh Shardul
	//    '    ' Created               : 18-Feb-2007 03:15 pm
	//    '    ' Revisions             : 1
	//    '    '=====================================================================
	//    '    Try
	//    '        'RemoveHandler mnuIgnite.Click, AddressOf btnAutoIgnition_Click

	//    '        If Not gstructSettings.AppMode = EnumAppMode.DemoMode Then
	//    '            If Not IsNothing(gobjMain.mobjfrmAnalysis) Then gobjMain.mobjfrmAnalysis.tmrAspirationMsg.Enabled = False
	//    '            Call gobjMain.mobjController.Cancel()
	//    '            Call Application.DoEvents()
	//    '            Call gobjCommProtocol.mobjCommdll.subTime_Delay(100)
	//    '            Call gobjClsAAS203.funcIgnite(True)

	//    '        Else
	//    '            Call gobjMessageAdapter.ShowMessage("Flame Ignited", "AUTO IGNITION", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage)
	//    '            Call Application.DoEvents()
	//    '        End If

	//    '    Catch ex As Exception
	//    '        '---------------------------------------------------------
	//    '        'Error Handling and logging
	//    '        gobjErrorHandler.ErrorDescription = ex.Message
	//    '        gobjErrorHandler.ErrorMessage = ex.Message
	//    '        gobjErrorHandler.WriteErrorLog(ex)
	//    '        '---------------------------------------------------------
	//    '    Finally
	//    '        '---------------------------------------------------------
	//    '        'Writing Execution log
	//    '        If CONST_CREATE_EXECUTION_LOG = 1 Then
	//    '            gobjErrorHandler.WriteExecutionLog()
	//    '        End If
	//    '        If Not gstructSettings.AppMode = EnumAppMode.DemoMode Then
	//    '            If Not IsNothing(gobjMain.mobjfrmAnalysis) Then gobjMain.mobjfrmAnalysis.tmrAspirationMsg.Enabled = True
	//    '            gobjMain.mobjController.Start(gobjclsBgFlameStatus)
	//    '            Application.DoEvents()
	//    '        End If
	//    '        'AddHandler mnuIgnite.Click, AddressOf btnAutoIgnition_Click
	//    '        '---------------------------------------------------------
	//    '    End Try
	//    'End Sub

	//    Private Sub btnIgnite_Click(ByVal sender As Object, ByVal e As System.EventArgs)
	//        '=====================================================================
	//        ' Procedure Name        : btnIgnite_Click
	//        ' Parameters Passed     : Object, EventArgs
	//        ' Returns               : 
	//        ' Purpose               : Ignite the flame
	//        ' Description           : 
	//        ' Assumptions           : 
	//        ' Dependencies          : 
	//        ' Author                : Saurabh S & Sachin Dokhale
	//        ' Created               : 05.10.06
	//        ' Revisions             : 
	//        '=====================================================================
	//        If mblnAvoidProcessing = True Then
	//            Exit Sub
	//        End If
	//        Try

	//            mblnAvoidProcessing = True
	//            ' this event Terminate required Thread and start the auto ignition process for AA Flame
	//            gobjMain.AutoIgnition()
	//            mblnAvoidProcessing = False
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
	//            'objWait.Dispose()
	//            '---------------------------------------------------------
	//        End Try

	//    End Sub

	//    Private Sub btnExtinguish_Click(ByVal sender As Object, ByVal e As System.EventArgs)
	//        '=====================================================================
	//        ' Procedure Name        : btnExtinguish_Click
	//        ' Parameters Passed     : Object, EventArgs
	//        ' Returns               : 
	//        ' Purpose               : Extinguish the flame
	//        ' Description           : 
	//        ' Assumptions           : 
	//        ' Dependencies          : 
	//        ' Author                : Saurabh S & Sachin Dokhale
	//        ' Created               : 05.10.06
	//        ' Revisions             : 
	//        '=====================================================================
	//        If mblnAvoidProcessing = True Then
	//            Exit Sub
	//        End If
	//        Try
	//            mblnAvoidProcessing = True

	//            ' this event Extinguish the flame 
	//            gobjMain.Extinguish()
	//            mblnAvoidProcessing = False
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
	//            'objWait.Dispose()
	//            '---------------------------------------------------------
	//        End Try

	//    End Sub

	//    Private Sub btnN2OIgnite_Click(ByVal sender As Object, ByVal e As System.EventArgs)
	//        '=====================================================================
	//        ' Procedure Name        : btnN2OIgnite_Click
	//        ' Parameters Passed     : Object, EventArgs
	//        ' Returns               : 
	//        ' Purpose               : Ignite the N2O flame
	//        ' Description           : 
	//        ' Assumptions           : 
	//        ' Dependencies          : 
	//        ' Author                : Saurabh S & Sachin Dokhale
	//        ' Created               : 05.10.06
	//        ' Revisions             : 
	//        '=====================================================================
	//        If mblnAvoidProcessing = True Then
	//            Exit Sub
	//        End If
	//        Try
	//            mblnAvoidProcessing = True

	//            ' this event Terminate required Thread and start the auto ignition process for N2O Flame
	//            ' Switch to N2O to Air 
	//            gobjMain.N2OAutoIgnition()
	//            mblnAvoidProcessing = False
	//        Catch ex As Exception
	//            '---------------------------------------------------------
	//            'Error Handling and logging
	//            gobjErrorHandler.ErrorDescription = ex.Message
	//            gobjErrorHandler.ErrorMessage = ex.Message
	//            gobjErrorHandler.WriteErrorLog(ex)
	//            '---------------------------------------------------------
	//            mblnAvoidProcessing = False
	//        Finally
	//            '---------------------------------------------------------
	//            'Writing Execution log
	//            If CONST_CREATE_EXECUTION_LOG = 1 Then
	//                gobjErrorHandler.WriteExecutionLog()
	//            End If
	//            'objWait.Dispose()
	//            '---------------------------------------------------------
	//        End Try

	//    End Sub

	//    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
	//        '=====================================================================
	//        ' Procedure Name        : btnDelete_Click
	//        ' Parameters Passed     : Object, EventArgs
	//        ' Returns               : None
	//        ' Purpose               : 
	//        ' Description           : 
	//        ' Assumptions           : 
	//        ' Dependencies          : 
	//        ' Author                : Sachin Dokhale
	//        ' Created               : 18-Dec-2007 03:15 pm
	//        ' Revisions             : 0
	//        '=====================================================================
	//        Try
	//            If mblnAvoidProcessing = True Then
	//                Exit Sub
	//            End If
	//            mblnAvoidProcessing = True
	//            Call gobjMain.funcAltDelete()
	//            mblnAvoidProcessing = False
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

	//    Private Sub btnR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
	//        '=====================================================================
	//        ' Procedure Name        : btnR_Click
	//        ' Parameters Passed     : Object, EventArgs
	//        ' Returns               : None
	//        ' Purpose               : 
	//        ' Description           : 
	//        ' Assumptions           : 
	//        ' Dependencies          : 
	//        ' Author                : Sachin Dokhale
	//        ' Created               : 18-Dec-2007 03:15 pm
	//        ' Revisions             : 0
	//        '=====================================================================
	//        Try
	//            If mblnAvoidProcessing = True Then
	//                Exit Sub
	//            End If
	//            mblnAvoidProcessing = True
	//            Call gobjMain.funcAltR()
	//            mblnAvoidProcessing = False
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

	//    Private Sub btnExportReport_Click(ByVal sender As Object, ByVal e As System.EventArgs)
	//        '=====================================================================
	//        ' Procedure Name        : tlbbtnExportReport_Click
	//        ' Parameters Passed     : Object, EventArgs
	//        ' Returns               : 
	//        ' Purpose               : 
	//        ' Description           : Send the data result to the RTF format
	//        ' Assumptions           : 
	//        ' Dependencies          : 
	//        ' Author                : Saurabh S & Sachin Dokhale
	//        ' Created               : 05.10.06
	//        ' Revisions             : 
	//        '=====================================================================
	//        Dim objWait As New CWaitCursor
	//        Dim intSelectId As Integer
	//        Dim intCount, intCount1 As Integer
	//        Dim A1() As Double = {0, 0, 0, 0, 0, 0}
	//        Try
	//            'Added By Pankaj Fri 18 May 07
	//            ' this block use to check the if Enabel 21 CFR
	//            If (gstructSettings.Enable21CFR = True) Then
	//                If Not funcCheckActivityAuthentication(enumActivityAuthentication.Export, gstructUserDetails.Access) Then
	//                    Return
	//                    Exit Sub
	//                End If
	//                gfuncInsertActivityLog(EnumModules.Export, "Export Accessed")
	//            End If

	//            ' Check whether Data Result is ready to report 
	//            If (toreported) Then 'OR NOT Method->RepReady )
	//                If gobjClsAAS203.SaveQuantResults(gobjNewMethod, A1, 1, False) = True Then
	//                    mblnIsStartRunNumber = True
	//                End If
	//                toreported = False
	//                'mblnIsStartRunNumber = True
	//            End If
	//            If StdAnalysed Or AnaOver Or mblnIsAnalysisStarted Then 'Or ManualEntry Then
	//                'Select required Run No to export data result from data collection object
	//                For intCount = 0 To gobjMethodCollection.Count - 1
	//                    'If mintSelectedMethodID = gobjMethodCollection(intCount).MethodID Then
	//                    If gobjNewMethod.MethodID = gobjMethodCollection(intCount).MethodID Then
	//                        'intSelectIDIndex = intCount
	//                        intSelectId = intCount
	//                        'mobjClsDataFileReport.MethodID = intCount
	//                        mobjClsDataFileReport.MethodID = gobjMethodCollection(intCount).MethodID
	//                        For intCount1 = 0 To gobjMethodCollection(intSelectId).QuantitativeDataCollection.Count - 1
	//                            If mlngSelectedRunNumber = CInt(gobjMethodCollection(intSelectId).QuantitativeDataCollection(intCount1).RunNumber) Then
	//                                ' Set requierd Run No and perticulat Run No object to the Report object
	//                                mobjClsDataFileReport.RunNumber = mlngSelectedRunNumber
	//                                Call mobjClsDataFileReport.funcDatafileExport(gobjMethodCollection(intSelectId).QuantitativeDataCollection(intCount1).ReportParameters)
	//                                Exit For
	//                            End If
	//                        Next
	//                        Exit For
	//                    End If
	//                Next
	//            End If

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
	//            If Not objWait Is Nothing Then
	//                objWait.Dispose()
	//            End If
	//            '---------------------------------------------------------
	//        End Try
	//    End Sub

	//#End Region

	//#Region " Private Functions "

	//    Private Sub ShowAspirationMessages(ByVal blnIsShow As Boolean)
	//        '=====================================================================
	//        ' Procedure Name        : ShowAspirationMessages
	//        ' Parameters Passed     : Flag to Set or Clear the Message.
	//        ' Returns               : None
	//        ' Purpose               : 
	//        ' Description           : 
	//        ' Assumptions           : 
	//        ' Dependencies          : 
	//        ' Author                : Mangesh Shardul
	//        ' Created               : 17-Jan-2007 03:25 pm
	//        ' Revisions             : 1
	//        '=====================================================================
	//        'void	ShowAspMessage(BOOL	flag)
	//        '{
	//        '   char str[128]="";
	//        '   int t=0;
	//        '   if (flag)
	//        '   {
	//        '       GetDlgItemText(Mhwnd, IDC_TASP, str, 120);
	//        '	    ltrim(trim(str));
	//        '	    t = Ignite_Test();
	//        '	    if( (Method->Mode != MODE_UVABS && !GetHydrideModeStatus()) && (t == GREEN || t == RED) )  // mdf by sss for showing the flame error message
	//        '       {
	//        '		    SetDlgItemText(Mhwnd, IDC_TASP, "  Flame is OFF  ");
	//        '	    }
	//        '   	else
	//        '       {
	//        '   		if (strcmpi(str,Aspiratemsg)!=0)
	//        '		     SetDlgItemText(Mhwnd, IDC_TASP, Aspiratemsg);
	//        '	    }
	//        '   }
	//        '   Else
	//        '       SetDlgItemText(Mhwnd, IDC_TASP, "");
	//        '}




	//        Dim intIgniteType As ClsAAS203.enumIgniteType
	//        Dim strAspMessage As String

	//        Try
	//            'Application.DoEvents()
	//            If (blnIsShow) Then
	//                strAspMessage = Trim(lblAspirationMessage.Text)

	//                If gstructSettings.AppMode = EnumAppMode.DemoMode Then
	//                    'intIgniteType = ClsAAS203.enumIgniteType.Blue
	//                Else
	//                    'intIgniteType = gobjClsAAS203.funcIgnite_Test()
	//                End If

	//                'If ((gobjNewMethod.OperationMode <> EnumOperationMode.MODE_UVABS And Not gobjInst.Hydride) _
	//                '    And (intIgniteType = ClsAAS203.enumIgniteType.Green Or intIgniteType = ClsAAS203.enumIgniteType.Red)) Then
	//                'intIgniteType = gobjMain.IgniteType
	//                If ((gobjNewMethod.OperationMode <> EnumOperationMode.MODE_UVABS And Not gobjInst.Hydride) _
	//                    And (gobjMain.IgniteType = ClsAAS203.enumIgniteType.Green Or gobjMain.IgniteType = ClsAAS203.enumIgniteType.Red)) Then

	//                    'for showing the flame error message
	//                    lblAspirationMessage.Text = "  Flame is OFF  "
	//                Else
	//                    If String.Compare(strAspMessage, mstrAspirationMessage) <> 0 Then
	//                        lblAspirationMessage.Text = mstrAspirationMessage
	//                        lblAspirationMessage.Refresh()
	//                    End If
	//                End If

	//            Else
	//                lblAspirationMessage.Text = ""
	//                lblAspirationMessage.Refresh()
	//            End If
	//            'Application.DoEvents()
	//            'set focus to read data button
	//            If btnReadData.Enabled Then
	//                btnReadData.Focus()
	//                btnReadData.Refresh()
	//            End If
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
	//            'Application.DoEvents()     'Commented by Saurabh 20.07.07
	//            '---------------------------------------------------------
	//        End Try
	//    End Sub

	//    'Private Function funcCollapseAllXPPanels() As Boolean
	//    '    '=====================================================================
	//    '    ' Procedure Name        : funcCollapseAllXPPanels
	//    '    ' Parameters Passed     : None
	//    '    ' Returns               : True or False
	//    '    ' Purpose               : To collapse all XP Panels
	//    '    ' Description           : 
	//    '    ' Assumptions           : 
	//    '    ' Dependencies          : 
	//    '    ' Author                : Deepak Bhati
	//    '    ' Created               : 05.10.06
	//    '    ' Revisions             : 
	//    '    '=====================================================================
	//    '    Try
	//    '        If Me.XpPanelStandardGraph.PanelState = UIComponents.XPPanelState.Expanded Then
	//    '            Me.XpPanelStandardGraph.TogglePanelState()
	//    '            Me.XpPanelStandardGraph.Height = 0
	//    '        End If
	//    '        If Me.XpPanelSampleGraph.PanelState = UIComponents.XPPanelState.Expanded Then
	//    '            Me.XpPanelSampleGraph.TogglePanelState()
	//    '            Me.XpPanelSampleGraph.Height = 0
	//    '        End If
	//    '        If Me.XpPanelViewResults.PanelState = UIComponents.XPPanelState.Expanded Then
	//    '            Me.XpPanelViewResults.TogglePanelState()
	//    '            Me.XpPanelViewResults.Height = 0
	//    '        End If
	//    '        If Me.XpPanelReports.PanelState = UIComponents.XPPanelState.Expanded Then
	//    '            Me.XpPanelReports.TogglePanelState()
	//    '            Me.XpPanelReports.Height = 0
	//    '        End If

	//    '        Return True

	//    '    Catch ex As Exception
	//    '        '---------------------------------------------------------
	//    '        'Error Handling and logging
	//    '        gobjErrorHandler.ErrorDescription = ex.Message
	//    '        gobjErrorHandler.ErrorMessage = ex.Message
	//    '        gobjErrorHandler.WriteErrorLog(ex)
	//    '        Return False
	//    '        '---------------------------------------------------------
	//    '    Finally
	//    '        '---------------------------------------------------------
	//    '        'Writing Execution log
	//    '        If CONST_CREATE_EXECUTION_LOG = 1 Then
	//    '            gobjErrorHandler.WriteExecutionLog()
	//    '        End If
	//    '        '---------------------------------------------------------
	//    '    End Try
	//    'End Function

	//    Private Function SetColorPropertiesForXpPanel(ByRef objXpPanelIn As UIComponents.XPPanel, ByVal strCaptionNameIn As String) As Boolean
	//        '=====================================================================
	//        ' Procedure Name        : SetColorPropertiesForXpPanel
	//        ' Parameters Passed     : objXpPanelIn,strCaptionNameIn
	//        ' Returns               : True or False
	//        ' Purpose               : To set color properties to xp panel
	//        ' Description           : 
	//        ' Assumptions           : 
	//        ' Dependencies          : 
	//        ' Author                : Deepak Bhati
	//        ' Created               : 05.10.06
	//        ' Revisions             : 
	//        '=====================================================================
	//        Dim objWait As New CWaitCursor
	//        Try
	//            'update data structures value for objxppanelln
	//            objXpPanelIn.Caption = strCaptionNameIn

	//            objXpPanelIn.CaptionGradient.Color2 = Color.CornflowerBlue
	//            objXpPanelIn.CaptionGradient.Color1 = Color.FromArgb(205, 225, 250)

	//            objXpPanelIn.PanelGradient.Color1 = Color.White 'Color.FromArgb(205, 225, 250)
	//            objXpPanelIn.PanelGradient.Color2 = Color.Gainsboro 'Color.FromArgb(175, 200, 245)

	//            objXpPanelIn.CaptionUnderline = Color.CornflowerBlue
	//            objXpPanelIn.CurveRadius = 8
	//            objXpPanelIn.Dock = DockStyle.None
	//            objXpPanelIn.GradientOffset = 0.2
	//            objXpPanelIn.HorzAlignment = StringAlignment.Near
	//            objXpPanelIn.Spacing = New Point(5, 0)
	//            objXpPanelIn.TextColors.Color1 = Color.FromArgb(33, 93, 198)
	//            objXpPanelIn.TextColors.Color2 = Color.FromArgb(0, 0, 0, 0)
	//            objXpPanelIn.TextHighlightColors.Color1 = Color.FromArgb(66, 142, 255)
	//            objXpPanelIn.TextHighlightColors.Color2 = Color.FromArgb(0, 0, 0, 0)
	//            objXpPanelIn.VertAlignment = StringAlignment.Center
	//            objXpPanelIn.XPPanelStyle = UIComponents.XPPanelStyle.WindowsXP
	//            objXpPanelIn.OutlineColor = Color.FromArgb(175, 200, 245)
	//            objXpPanelIn.Visible = True
	//            objXpPanelIn.PanelState = UIComponents.XPPanelState.Collapsed
	//            objXpPanelIn.Width = Me.Width
	//            objXpPanelIn.Height = 100
	//            objXpPanelIn.AnimationRate = 1

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
	//    End Function

	//    Private Sub subInitAnalysisGraph()
	//        '=====================================================================
	//        ' Procedure Name        : subInitAnalysisGraph
	//        ' Parameters Passed     : None
	//        ' Returns               : None
	//        ' Purpose               : Init. analysis graph
	//        '                           
	//        ' Description           : 
	//        ' Assumptions           : 
	//        ' Dependencies          : 
	//        ' Author                : Mangesh Shardul
	//        ' Created               : 15-Dec-2006
	//        ' Revisions             : 1
	//        '=====================================================================
	//        '---To set the X-axis as Time axis and its default Min, Max & Step values.
	//        Dim dtXMin, dtXMax As Date

	//        Try
	//            ' cal. Analysis apram. of graph.
	//            'Call Calculate_Analysis_Graph_Param(AASGraphAnalysis)

	//            'AASGraphAnalysis.XAxisLabel = "TIME(seconds)"
	//            'AASGraphAnalysis.XAxisType = AldysGraph.AxisType.Linear
	//            'AASGraphAnalysis.IsShowGrid = True
	//            'AASGraphAnalysis.Refresh()
	//            Application.DoEvents()

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

	//    Private Sub InitAnalysis()
	//        '=====================================================================
	//        ' Procedure Name        : InitAnalysis
	//        ' Parameters Passed     : None
	//        ' Returns               : None
	//        ' Purpose               : Init. analysis parameters
	//        '                           
	//        ' Description           : 
	//        ' Assumptions           : 
	//        ' Dependencies          : 
	//        ' Author                : Mangesh Shardul
	//        ' Created               : 15-Dec-2006
	//        ' Revisions             : 1
	//        '=====================================================================
	//        'void	InitAnalyse(HWND hwnd,CURVEDATA 	*AnaGraph)
	//        '{
	//        'HWND hwnd1;
	//        ' if (Method->Mode==MODE_UVABS){
	//        '	ShowWindow(GetDlgItem(hwnd,IDC_UVABS), SW_SHOW);
	//        '	ShowWindow(GetDlgItem(hwnd,IDC_GRAPH), SW_HIDE);
	//        '	ShowWindow(GetDlgItem(hwnd,IDC_SCALE), SW_HIDE);
	//        '	ShowWindow(GetDlgItem(hwnd,IDC_PGRAPH), SW_HIDE);
	//        '	ShowWindow(GetDlgItem(hwnd,IDC_HSXMIN), SW_HIDE);
	//        '	ShowWindow(GetDlgItem(hwnd,IDC_HSXMAX), SW_HIDE);
	//        '  }
	//        ' else{
	//        '	ShowWindow(GetDlgItem(hwnd,IDC_UVABS), SW_HIDE);
	//        '	ShowWindow(GetDlgItem(hwnd,IDC_GRAPH), SW_SHOW);
	//        '	ShowWindow(GetDlgItem(hwnd,IDC_SCALE), SW_SHOW);
	//        '	ShowWindow(GetDlgItem(hwnd,IDC_PGRAPH), SW_SHOW);
	//        '	ShowWindow(GetDlgItem(hwnd,IDC_HSXMIN), SW_SHOW);
	//        '	ShowWindow(GetDlgItem(hwnd,IDC_HSXMAX), SW_SHOW);

	//        '	hwnd1=GetDlgItem(hwnd,IDC_GRAPH);
	//        '	if (hwnd1){
	//        '	 EnableWindow(hwnd1,TRUE);
	//        '	 GetWindowRect(hwnd1, &(AnaGraph->RC));
	//        '	 ShowWindow(hwnd1,SW_HIDE);
	//        '	 AnaGraph->RC.top -= 35; 	AnaGraph->RC.right-=30;
	//        '	 AnaGraph->RC.bottom-=40;
	//        '	}
	//        '            Else
	//        '	 SetRectEmpty(&AnaGraph->RC);
	//        '  if (Method->Mode==MODE_EMISSION){
	//        '		AnaGraph->Ymin=-1.0; AnaGraph->Ymax=100.0;
	//        '	 }
	//        '  else{
	//        '	AnaGraph->Ymin=-0.1; AnaGraph->Ymax=1.0;
	//        '	}
	//        '  AnaGraph->Xmin=0; AnaGraph->Xmax=10*10.0;
	//        '  Calculate_Analysis_Graph_Param(AnaGraph);
	//        ' }
	//        '}
	//        Try
	//            Select Case gobjNewMethod.OperationMode
	//                Case EnumOperationMode.MODE_UVABS
	//                    '---Do not show graph
	//                    'lblUVAbsorbance.Visible = True
	//                    'lblUVAbsorbance.Size = New Size(370, 87)
	//                    'lblUVAbsorbance.Location = New Point(136, 73)
	//                    'lblUVWavelength.Visible = True
	//                    'lblUVWavelength.Size = New Size(370, 87)
	//                    'lblUVWavelength.Location = New Point(136, 188)
	//                    'AASGraphAnalysis.Visible = False
	//                    Call Application.DoEvents()

	//                Case Else
	//                    'AASGraphAnalysis.Visible = True
	//                    'lblUVAbsorbance.Visible = False
	//                    'lblUVWavelength.Visible = False
	//                    Call Application.DoEvents()

	//                    If (gobjNewMethod.OperationMode = EnumOperationMode.MODE_EMMISSION) Then
	//                        'update AASGraph analysis scale values
	//                        'AASGraphAnalysis.YAxisMin = -10.0
	//                        'AASGraphAnalysis.YAxisMax = 100.0
	//                        'AASGraphAnalysis.YAxisStep = 20.0
	//                        'AASGraphAnalysis.YAxisMinorStep = 5.0

	//                        'AASGraphAnalysis.YAxisLabel = "EMISSION"
	//                        'Changed by Saurabh "Energy" to "Emission"
	//                        'lblAbsorbanceMain.Text = "Emission : "
	//                        'lblAverageAbsorbanceMain.Text = "Average Emission : "
	//                        'lblCorrectedAbsorbanceMain.Text = "Corrected Emission : "
	//                    Else
	//                        '---changed by deepak on 29.04.07
	//                        'AASGraphAnalysis.YAxisMin = -0.2
	//                        'AASGraphAnalysis.YAxisMax = 0.8
	//                        'AASGraphAnalysis.YAxisStep = 0.1
	//                        'AASGraphAnalysis.YAxisMinorStep = 0.05
	//                        'AASGraphAnalysis.YAxisStep = 0.2
	//                        'AASGraphAnalysis.YAxisMinorStep = 0.1

	//                        'AASGraphAnalysis.YAxisLabel = "ABSORBANCE"
	//                    End If
	//                    Call subInitAnalysisGraph()
	//            End Select

	//            '---Set Method Title
	//            'txtMethod.Text = gobjNewMethod.MethodName

	//            btnReadData.Enabled = False

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

	//    Private Sub Test(ByRef dblX As Double, ByRef dblY As Double)
	//        '=====================================================================
	//        ' Procedure Name        : Test
	//        ' Parameters Passed     : dtX , dblY as Coordinate
	//        ' Returns               : None
	//        ' Purpose               : Test Analysis
	//        '                           
	//        ' Description           : 
	//        ' Assumptions           : 
	//        ' Dependencies          : 
	//        ' Author                : Mangesh Shardul
	//        ' Created               : 15-Dec-2006
	//        ' Revisions             : 1
	//        '=====================================================================
	//        Try
	//            If (dblX < 40) Then
	//                dblX = dblX + 5
	//                dblY = 0.05 * dblX * dblX
	//            ElseIf (dblX < 50) Then
	//                dblX = dblX + 5
	//                dblY = Math.Sqrt((dblY * dblY) - 1)
	//            Else
	//                dblX = dblX + 5
	//                dblY = dblY - 0.05 * dblY
	//            End If
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

	//    Private Sub Test_Time(ByRef dtXTime As Date, ByRef dblY As Double)
	//        '=====================================================================
	//        ' Procedure Name        : Test_Time
	//        ' Parameters Passed     : dtXTime as Time, dblY as y Coordinate
	//        ' Returns               : None
	//        ' Purpose               : Test Analysis 
	//        '                           
	//        ' Description           : 
	//        ' Assumptions           : 
	//        ' Dependencies          : 
	//        ' Author                : Mangesh Shardul
	//        ' Created               : 15-Dec-2006
	//        ' Revisions             : 1
	//        '=====================================================================
	//        Try
	//            'If (dtXTime < AldysGraph.XDate.XLDateToDateTime(AASGraphAnalysis.XAxisMax)) Then
	//            '    dtXTime = dtXTime.AddMinutes(1.0)
	//            '    Dim objRnd As New Random
	//            '    dblY = objRnd.NextDouble() * 100
	//            'End If
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

	//    Private Sub ResetAnaMode(ByVal intLampNumber As Integer)
	//        '=====================================================================
	//        ' Procedure Name        : ResetAnaMode
	//        ' Parameters Passed     : intLampNumber
	//        ' Returns               : None
	//        ' Purpose               : Reset Analysis Mode
	//        '                           
	//        ' Description           : 
	//        ' Assumptions           : 
	//        ' Dependencies          : 
	//        ' Author                : Mangesh Shardul
	//        ' Created               : 15-Dec-2006
	//        ' Revisions             : 1
	//        '=====================================================================
	//        '------------------------------------------------------------------------
	//        'void ResetAnaMode(int lampno )
	//        '{
	//        'INST_PAR	*Inst=NULL;
	//        'Inst =  GetInstData();
	//        'switch(Method->Mode){
	//        '	case MODE_AA:Inst->Lamp_par.lamp[lampno].mode=AA;break;
	//        '	case MODE_AABGC:Inst->Lamp_par.lamp[lampno].mode=AABGC;break;
	//        '	case MODE_EMISSION:Inst->Lamp_par.lamp[lampno].mode=EMISSION;break;
	//        '	case MODE_UVABS:Inst->Lamp_par.lamp[lampno].mode=MABS;break;
	//        '	case MODE_SPECT:if(GetInstrument() == AA202)
	//        '							Inst->Lamp_par.lamp[lampno].mode=AABGCSR;
	//        '	break;
	//        '}
	//        '}
	//        '------------------------------------------------------------------------

	//        'INST_PAR	*Inst=NULL;
	//        'Inst = GetInstData()

	//        'gobjInst = Nothing
	//        'Call funcInitInstrumentSettings()

	//        '---Get Lamp Index from Lamp Number
	//        Try
	//            intLampNumber -= 1

	//            Select Case gobjNewMethod.OperationMode
	//                Case EnumOperationMode.MODE_AA
	//                    gobjInst.Lamp.LampParametersCollection(intLampNumber).Mode = EnumOperationMode.MODE_AA

	//                Case EnumOperationMode.MODE_AABGC
	//                    gobjInst.Lamp.LampParametersCollection(intLampNumber).Mode = EnumOperationMode.MODE_AABGC

	//                Case EnumOperationMode.MODE_EMMISSION
	//                    gobjInst.Lamp.LampParametersCollection(intLampNumber).Mode = EnumOperationMode.MODE_EMMISSION

	//                Case EnumOperationMode.MODE_UVABS
	//                    gobjInst.Lamp.LampParametersCollection(intLampNumber).Mode = EnumOperationMode.MODE_UVABS

	//                Case EnumOperationMode.MODE_SPECT
	//                    gobjInst.Lamp.LampParametersCollection(intLampNumber).Mode = EnumOperationMode.MODE_SPECT

	//            End Select

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

	//    Private Sub Display_Analysis_Info()
	//        '=====================================================================
	//        ' Procedure Name        : Display_Analysis_Info
	//        ' Parameters Passed     : None
	//        ' Returns               : None
	//        ' Purpose               : To display analysis information. 
	//        '                           
	//        ' Description           : 
	//        ' Assumptions           : 
	//        ' Dependencies          : 
	//        ' Author                : Mangesh Shardul
	//        ' Created               : 15-Dec-2006
	//        ' Revisions             : 1
	//        '=====================================================================

	//        '****************************************************************************************
	//        'AAS 16-Bit Software Code
	//        '****************************************************************************************
	//        'void	Disp_Analysis_Info(HWND hwnd)
	//        '{
	//        'char		str[60]="";
	//        'int		i;

	//        ' for(i=IDC_QSAMPID;i<=IDC_QCONC; i++)
	//        '	SetDlgItemText(hwnd,i, "");
	//        ' if (SampType==BLANK){
	//        '	SetDlgItemText(hwnd,IDC_QSAMPID, "BLANK");
	//        '	SetDlgItemText(hwnd,IDC_QRPTNO, "1");
	//        '	SetDlgItemText(hwnd,IDC_QCORABS, "");
	//        '	SetDlgItemText(hwnd,IDC_QCONC, "");
	//        '  }
	//        ' else if (SampType==STD){
	//        '	if (mobjCurrentStandard!=NULL){
	//        '	  sprintf(str, "%s",mobjCurrentStandard->Data.Std_Name);
	//        '	  SetDlgItemText(hwnd,IDC_QSAMPID, str);
	//        '	  sprintf(str, "%d",CurRepeat);
	//        '	  SetDlgItemText(hwnd,IDC_QRPTNO, str);
	//        '	  StoreResultAccurate(mobjCurrentStandard->Data.Conc, str,
	//        '			  Method->QuantData->Param.No_Decimals);
	//        '	  SetDlgItemText(hwnd,IDC_QCONC, str);
	//        '	 }
	//        '	}
	//        '  else if (SampType==SAMP){
	//        '	 if (mobjCurrentSample!=NULL){
	//        '	  sprintf(str, "%s",mobjCurrentSample->Data.Samp_Name);
	//        '	  SetDlgItemText(hwnd,IDC_QSAMPID, str);
	//        '	  sprintf(str, "%d",CurRepeat);
	//        '	  SetDlgItemText(hwnd,IDC_QRPTNO, str);
	//        '	  SetDlgItemText(hwnd,IDC_QCONC, "Unknown");
	//        '	 }
	//        '	}
	//        '}
	//        '****************************************************************************************
	//        Try
	//            ' display analysis information dependingupon analysis type i.s. Bank/Std/Samp. 
	//            'lblSampleID.Text = ""
	//            'lblRepeatNo.Text = ""
	//            'lblCorrectedAbsorbance.Text = ""
	//            'lblConcentration.Text = ""
	//            'display analysis Info Sample type wise
	//            Select Case SampleType
	//                Case ClsAAS203.enumSampleType.BLANK
	//                    'lblSampleID.Text = "BLANK"
	//                    'lblRepeatNo.Text = "1"
	//                    'lblCorrectedAbsorbance.Text = ""
	//                    'lblConcentration.Text = ""

	//                Case ClsAAS203.enumSampleType.STANDARD
	//                    If Not IsNothing(mobjCurrentStandard) Then
	//                        'lblSampleID.Text = mobjCurrentStandard.StdName
	//                        'lblRepeatNo.Text = CurRepeat

	//                        '---Store Result Accurate upto AnalysisParameters.NumOfDecimalPlaces
	//                        'lblConcentration.Text = FormatNumber(mobjCurrentStandard.Concentration, gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfDecimalPlaces)
	//                    End If

	//                Case ClsAAS203.enumSampleType.SAMPLE
	//                    If Not IsNothing(mobjCurrentSample) Then
	//                        'lblSampleID.Text = mobjCurrentSample.SampleName
	//                        'lblRepeatNo.Text = CurRepeat
	//                        'lblConcentration.Text = "Unknown"
	//                    End If
	//            End Select

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

	//    Private Sub DisplayRunNo()
	//        '=====================================================================
	//        ' Procedure Name        : DisplayRunNo
	//        ' Parameters Passed     : None
	//        ' Returns               : None
	//        ' Purpose               : To display Run No on test object
	//        '                           
	//        ' Description           : 
	//        ' Assumptions           : 
	//        ' Dependencies          : 
	//        ' Author                : Mangesh Shardul
	//        ' Created               : 15-Dec-2006
	//        ' Revisions             : 1
	//        '=====================================================================

	//        'void	DisplayRunNo(HWND hwnd)
	//        '{
	//        'char 	str[80]="";
	//        '  if (!Method->QuantData)
	//        '	 return;
	//        ' if (Method->QuantData->Fname>0){
	//        '	sprintf(str,"%08.0f",Method->QuantData->Fname);
	//        '	SetWindowText(GetDlgItem(hwnd,IDC_TRUN), str);
	//        '  }
	//        '}

	//        Dim strRunNumber As String = ""

	//        Try
	//            ' Set the Run number to the label
	//            If Not IsNothing(gobjNewMethod.QuantitativeDataCollection) Then
	//                If (CInt(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).RunNumber) > 0) Then
	//                    strRunNumber = Format(CInt(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).RunNumber), "00000000")
	//                    'lblRunNumber.Text = strRunNumber
	//                End If
	//            End If

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

	//    Private Sub Clear_All_Abs_Std(ByRef StdTop As Method.clsAnalysisStdParametersCollection)
	//        '=====================================================================
	//        ' Procedure Name        : Clear_All_Abs_Std
	//        ' Parameters Passed     : None
	//        ' Returns               : None
	//        ' Parameters Affected   : Method.clsAnalysisStdParametersCollection
	//        ' Purpose               : Clear Std all Abs parameter
	//        '                           
	//        ' Description           : 
	//        ' Assumptions           : 
	//        ' Dependencies          : 
	//        ' Author                : Mangesh Shardul
	//        ' Created               : 15-Dec-2006
	//        ' Revisions             : 1
	//        '=====================================================================

	//        '-------------------------
	//        'void	  S4FUNC	Clear_All_Abs_Std(STDDATA *StdTop)
	//        '{
	//        'STDDATA   *tempk=NULL;
	//        'ABSREPEATDATA	*rpt=NULL;

	//        ' tempk =StdTop;
	//        ' while(tempk!=NULL){
	//        '	 tempk->Data.Abs=(double) -1.0;
	//        '	 tempk=tempk->next;
	//        '  }
	//        '//---------clr repeat    add by sss on dt 21/12/1999
	//        'tempk =StdTop;
	//        'while(tempk){
	//        '	if(tempk->Data.AbsRepeat){
	//        '		rpt = tempk->Data.AbsRepeat->RptDataTop;
	//        '		DeleteAllAbsRepeatNodes(&rpt);
	//        '		free(tempk->Data.AbsRepeat);
	//        '		tempk->Data.AbsRepeat = NULL;
	//        '	}
	//        '	tempk =  tempk->next;
	//        '};
	//        '//------------------

	//        Dim rpt As Method.clsAbsRepeat

	//        'While (tempk! = NULL){
	//        '	 tempk->Data.Abs= -1.0
	//        '	 tempk=tempk->next
	//        '}
	//        'tempk =StdTop;
	//        'while(tempk){
	//        '	if(tempk->Data.AbsRepeat){
	//        '		rpt = tempk->Data.AbsRepeat->RptDataTop;
	//        '		DeleteAllAbsRepeatNodes(&rpt);
	//        '		free(tempk->Data.AbsRepeat);
	//        '		tempk->Data.AbsRepeat = NULL;
	//        '	}
	//        '	tempk =  tempk->next;
	//        '};

	//        'Dim objIterator As IEnumerator
	//        Dim intCounter As Integer

	//        Try
	//            'objIterator = StdTop.GetEnumerator()
	//            'objIterator.Reset()
	//            'While (objIterator.MoveNext)
	//            '    CType(objIterator.Current, Method.clsAnalysisStdParameters).Abs = -1.0
	//            '    'CType(objIterator.Current, Method.clsAnalysisStdParameters).AbsRepeat.AbsRepeatData.Clear()
	//            'End While

	//            ' Clear all Std parameters (Abs) object
	//            For intCounter = 0 To StdTop.Count - 1
	//                StdTop.item(intCounter).Abs = -1.0
	//                StdTop.item(intCounter).AbsRepeat.AbsRepeatData.Clear()
	//            Next intCounter

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

	//    Private Sub Clear_All_Abs_Conc_Samp(ByRef SampTop As Method.clsAnalysisSampleParametersCollection)
	//        '=====================================================================
	//        ' Procedure Name        : Clear_All_Abs_Conc_Samp
	//        ' Parameters Passed     : SampTop of Method.clsAnalysisSampleParametersCollection data type object
	//        ' Returns               : None
	//        ' Purpose               : Clear Std all Abs and Conc. parameter 
	//        '                           
	//        ' Description           : 
	//        ' Assumptions           : 
	//        ' Dependencies          : 
	//        ' Author                : Mangesh Shardul
	//        ' Created               : 15-Dec-2006
	//        ' Revisions             : 1
	//        '=====================================================================

	//        '//-------------------
	//        'void     S4FUNC	Clear_All_Abs_Conc_Samp(SAMPDATA *SampTop)
	//        '{
	//        'SAMPDATA *tempk=NULL;
	//        'ABSREPEATDATA	*rpt=NULL;
	//        ' tempk =SampTop;
	//        ' while(tempk!=NULL){
	//        '	 tempk->Data.Abs=(double) -1.0;
	//        '	 tempk->Data.Conc=(double) 0.0;
	//        '	 tempk=tempk->next;
	//        '  }

	//        'tempk =SampTop;
	//        'while(tempk){
	//        '	if (tempk->Data.AbsRepeat){
	//        '		rpt = tempk->Data.AbsRepeat->RptDataTop;
	//        '		DeleteAllAbsRepeatNodes(&rpt);
	//        '		free(tempk->Data.AbsRepeat);
	//        '		tempk->Data.AbsRepeat = NULL;
	//        '	}
	//        '	tempk =  tempk->next;
	//        '};
	//        '//------------

	//        'Dim objIterator As IEnumerator
	//        Dim intCounter As Integer

	//        Try
	//            ''objIterator = SampTop.GetEnumerator()
	//            ''objIterator.Reset()
	//            ''While (objIterator.MoveNext)
	//            ''    CType(objIterator.Current, Method.clsAnalysisSampleParameters).Abs = -1.0
	//            ''    CType(objIterator.Current, Method.clsAnalysisSampleParameters).AbsRepeat.AbsRepeatData.Clear()
	//            ''End While
	//            ' Clear all Std parameters (Cons) object
	//            For intCounter = 0 To SampTop.Count - 1
	//                SampTop.item(intCounter).Abs = -1.0
	//                SampTop.item(intCounter).AbsRepeat.AbsRepeatData.Clear()
	//            Next intCounter

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

	//    Private Sub CheckValidStdAbs()
	//        '=====================================================================
	//        ' Procedure Name        : CheckValidStdAbs
	//        ' Parameters Passed     : None
	//        ' Returns               : None
	//        ' Purpose               : Set Validated value to the Std object parameter
	//        '                           
	//        ' Description           : 
	//        ' Assumptions           : 
	//        ' Dependencies          : 
	//        ' Author                : Mangesh Shardul
	//        ' Created               : 15-Dec-2006
	//        ' Revisions             : 1
	//        '=====================================================================

	//        '//----------------------
	//        'void		S4FUNC	CheckValidStdAbs()
	//        '{
	//        'STDDATA   *tempk=NULL;
	//        ' if (!Method->QuantData)
	//        '	return;
	//        ' tempk =Method->QuantData->StdTopData;
	//        ' while(tempk!=NULL){
	//        '	tempk->Data.Used=FALSE;
	//        '	if (tempk->Data.Abs>0.0) ////-1.0)
	//        '	  tempk->Data.Used=TRUE;
	//        '	 tempk=tempk->next;
	//        '  }
	//        '}
	//        '//-------------
	//        Dim intCount As Integer

	//        Try
	//            'Set Validated value to the Std object of used parameter
	//            If Not IsNothing(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection) Then
	//                For intCount = 0 To gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.Count - 1
	//                    gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount).Used = False
	//                    If gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount).Abs > 0.0 Then
	//                        gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount).Used = True
	//                    End If
	//                Next
	//            End If

	//            'If Not IsNothing(objCurStandard) Then
	//            '    objCurStandard.Used = False
	//            '    If objCurStandard.Abs > 0.0 Then
	//            '        objCurStandard.Used = True
	//            '    End If
	//            'End If

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

	//    Private Function GetRunNo(ByVal objMethod As Method.clsMethod) As Double
	//        '=====================================================================
	//        ' Procedure Name        : GetRunNo
	//        ' Parameters Passed     : objMethod of Method.clsMethod data type object
	//        ' Returns               : Double - Return the Run Number
	//        ' Purpose               : Get Run No.
	//        '                           
	//        ' Description           : 
	//        ' Assumptions           : 
	//        ' Dependencies          : 
	//        ' Author                : Mangesh Shardul
	//        ' Created               : 15-Dec-2006
	//        ' Revisions             : 1
	//        '=====================================================================
	//        '//-------------------
	//        'double		S4FUNC	GetRunNo(METHOD *temp)
	//        '{
	//        'DATA4  	*aaresultdata=NULL;
	//        'INDEX4  	*aaresultidx=NULL;
	//        'double	fname=-1.0;
	//        'If (!temp) Then
	//        '   return fname;
	//        'If (!temp->QuantData)
	//        '   return fname;

	//        'If (!QDIopen("AARESULT",&aaresultdata, &aaresultidx))
	//        '{
	//        '   d4close_all(cb);
	//        '   return  FALSE;
	//        '}
	//        'If (d4reccount(aaresultdata) > 0) Then
	//        '   fname = Obtain_Next_Key(aaresultdata,"FNAME", FALSE);
	//        'Else
	//        '   fname=(double) 1.0;

	//        'temp->QuantData->Fname =fname;
	//        'd4close_all(cb);
	//        'return fname;
	//        '}
	//        '//---------------------------
	//        'DATA4  	*aaresultdata=NULL;
	//        'INDEX4  	*aaresultidx=NULL;

	//        Dim dblNewRunNumber As Double = -1.0

	//        Try
	//            'validate method object
	//            If IsNothing(objMethod) Then
	//                Return dblNewRunNumber
	//            End If

	//            If IsNothing(objMethod.QuantitativeDataCollection) Then
	//                Return dblNewRunNumber
	//            End If

	//            ''If Not (QDIopen("AARESULT", aaresultdata, aaresultidx)) Then
	//            ''    d4close_all(cb)
	//            ''    Return -1.0
	//            ''End If
	//            ''If (d4reccount(aaresultdata) > 0) Then
	//            ''    fname = Obtain_Next_Key(aaresultdata, "FNAME", False)
	//            ''Else
	//            ''    fname = 1.0
	//            ''End If
	//            'd4close_all(cb)
	//            '//----- Added by Sachin Dokhale on 25.05.07
	//            'dblNewRunNumber = gobjNewMethod.QuantitativeDataCollection.Count
	//            'gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).RunNumber = Format(dblNewRunNumber, "00000000")
	//            Dim intMethodCount As Integer
	//            Dim lngRunCount As Long
	//            Dim lngTotalRunNumber As Long = 0
	//            'get max Run number
	//            If Not gobjMethodCollection Is Nothing Then
	//                If gobjMethodCollection.Count > 0 Then
	//                    For intMethodCount = 0 To gobjMethodCollection.Count - 1
	//                        If Not gobjMethodCollection(intMethodCount).QuantitativeDataCollection Is Nothing Then
	//                            If gobjMethodCollection(intMethodCount).QuantitativeDataCollection.Count > 0 Then
	//                                For lngRunCount = 0 To gobjMethodCollection(intMethodCount).QuantitativeDataCollection.Count - 1
	//                                    If CLng(gobjMethodCollection(intMethodCount).QuantitativeDataCollection(lngRunCount).RunNumber) > lngTotalRunNumber Then
	//                                        lngTotalRunNumber = CLng(gobjMethodCollection(intMethodCount).QuantitativeDataCollection(lngRunCount).RunNumber)
	//                                    End If
	//                                Next
	//                                'intTotalRunNumber = gobjMethodCollection(intMethodCount).QuantitativeDataCollection.Count
	//                            End If
	//                        End If
	//                    Next
	//                End If
	//            End If
	//            ''''
	//            'add one to max run number 
	//            lngTotalRunNumber += 1
	//            dblNewRunNumber = Format(lngTotalRunNumber, "00000000")
	//            gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).RunNumber = Format(lngTotalRunNumber, "00000000")
	//            mlngSelectedRunNumber = lngTotalRunNumber
	//            Return dblNewRunNumber

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
	//    End Function

	//    Private Sub Aspirate()
	//        '=====================================================================
	//        ' Procedure Name        : Aspirate
	//        ' Parameters Passed     : None
	//        ' Returns               : None
	//        ' Purpose               : Aspiration message for diff. type of sample
	//        ' Description           : 
	//        ' Assumptions           : 
	//        ' Dependencies          : 
	//        ' Author                : Mangesh Shardul
	//        ' Created               : 17-Jan-2007 03:25 pm
	//        ' Revisions             : 1
	//        '=====================================================================
	//        'void   Aspirate(HWND hwnd)        
	//        '{
	//        'char	*aspMsg=NULL;
	//        'char	strAspMsg1[]= "Aspirate";
	//        'char	strAspMsg2[]="Insert Cuvete";
	//        'char	str[180]="";

	//        'if ( Method->Mode==MODE_UVABS)
	//        '	aspMsg =strAspMsg2;
	//        'Else
	//        '   aspMsg =strAspMsg1;

	//        'if (SampType==BLANK)
	//        '{
	//        '	if(Autosampler && Started )
	//        '	{
	//        '       If (!PositionAutosampler(hwnd, Str)) Then
	//        '		Gerror_message_system("Autosampler connection Lost");
	//        '	}
	//        '	else 
	//        '		sprintf(str, "%s Blank and Click &READ or press <SPACEBAR>", aspMsg);
	//        '}        
	//        'else
	//        '{
	//        '	if (SampType==STD)
	//        '	{
	//        '       If (mobjCurrentStandard! = NULL) Then
	//        '		{        
	//        '			if ( Method->QuantData->Param.ConcRepeat>1)
	//        '			{
	//        '				if(Autosampler && Started)
	//        '				{
	//        '					sprintf(str,"%s %s (Rpt #%d)from Position %d ",aspMsg,mobjCurrentStandard->Data.Std_Name, CurRepeat,mobjCurrentStandard->Data.PosNo);
	//        '					strcpy(Aspiratemsg, str);
	//        '					SetAutoSampler(hwnd,mobjCurrentStandard->Data.PosNo,TRUE);
	//        '				}
	//        '               Else
	//        '				    sprintf(str, " %s %s (Rpt #%d) and Click &READ or press <SPACEBAR>", aspMsg,mobjCurrentStandard->Data.Std_Name, CurRepeat); 
	//        '			}
	//        '			else
	//        '			{
	//        '				if(Autosampler && Started)
	//        '				{
	//        '					sprintf(str,"%s %s from Position %d ",aspMsg,mobjCurrentStandard->Data.Std_Name,mobjCurrentStandard->Data.PosNo);
	//        '					strcpy(Aspiratemsg, str);
	//        '					SetAutoSampler(hwnd,mobjCurrentStandard->Data.PosNo,TRUE);
	//        '				}
	//        '               Else
	//        '				    sprintf(str, " %s %s  and Click &READ or press <SPACEBAR>", aspMsg, mobjCurrentStandard->Data.Std_Name ); 
	//        '			}
	//        '		}
	//        '	}
	//        '	else
	//        '	{
	//        '       If (mobjCurrentSample! = NULL) Then
	//        '		{
	//        '			if ( Method->QuantData->Param.Repeat>1 )
	//        '			{
	//        '				if(Autosampler && Started)
	//        '				{
	//        '					sprintf(str,"%s %s (Repeat #%d) from Position %d ",aspMsg,mobjCurrentSample->Data.Samp_Name, CurRepeat,mobjCurrentSample->Data.SampPosNo);
	//        '					strcpy(Aspiratemsg, str);
	//        '					SetAutoSampler(hwnd,mobjCurrentSample->Data.SampPosNo,TRUE);
	//        '				}
	//        '               Else
	//        '					sprintf(str, " %s %s (Repeat #%d) and Click &READ or press <SPACEBAR> ", aspMsg, mobjCurrentSample->Data.Samp_Name, CurRepeat); 
	//        '			}
	//        '			else
	//        '			{
	//        '				if(Autosampler && Started)
	//        '				{
	//        '					sprintf(str, " %s %s from Position %d", aspMsg,mobjCurrentSample->Data.Samp_Name,mobjCurrentSample->Data.SampPosNo);
	//        '					strcpy(Aspiratemsg, str);
	//        '					SetAutoSampler(hwnd,mobjCurrentSample->Data.SampPosNo,TRUE);
	//        '				}
	//        '               Else
	//        '				    sprintf(str, " %s %s and Click &READ or press <SPACE BAR>", aspMsg, mobjCurrentSample->Data.Samp_Name);
	//        '			}
	//        '		}
	//        '	}
	//        '}

	//        'If (!Autosampler) Then
	//        '   strcpy(Aspiratemsg, str);
	//        'Else
	//        '{
	//        '   If (Started) Then
	//        '	    strcpy(Aspiratemsg, str);
	//        '}

	//        'if(Autosampler && Started)
	//        '	SendMessage(hwnd, WM_COMMAND, IDC_QAREAD, 0L);
	//        '}



	//        '---CODE BY MANGESH 

	//        Dim aspMsg As String

	//        Try
	//            ' Aspirattion message when UV ABS Mdoe is selected
	//            If (gobjNewMethod.OperationMode = EnumOperationMode.MODE_UVABS) Then
	//                aspMsg = "Insert Cuvete "
	//            Else
	//                aspMsg = "Aspirate "
	//            End If
	//            ' Aspirattion message when Blank is inserted
	//            If (SampleType = ClsAAS203.enumSampleType.BLANK) Then
	//                If (mblnIsAutosampler And mblnIsAnalysisStarted) Then
	//                    If Not (PositionAutosampler()) Then
	//                        'gobjMessageAdapter.ShowMessage("Autosampler connection Lost", "Autosampler", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage)
	//                        gobjMessageAdapter.ShowMessage(constAutoSamplerConnLost)
	//                    End If
	//                Else
	//                    mstrAspirationMessage = aspMsg & "Blank and Click READ DATA or press <SPACEBAR>"
	//                    '//---- Added by Sachin Dokhale
	//                    mobjBgMsgAspirate.AspirationMessage = mstrAspirationMessage
	//                    '//-----
	//                    '---Saurabh---20.06.07
	//                    If btnReadData.Enabled = True Then
	//                        btnReadData.Focus()
	//                        btnReadData.Refresh()
	//                    End If
	//                    '---Saurabh
	//                End If
	//            Else
	//                ' Aspirattion message when Standard is used
	//                If (SampleType = ClsAAS203.enumSampleType.STANDARD) Then
	//                    If Not IsNothing(mobjCurrentStandard) Then
	//                        If (gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfStdRepeats) > 1 Then '( Method->QuantData->Param.ConcRepeat>1)
	//                            If (mblnIsAutosampler And mblnIsAnalysisStarted) Then
	//                                mstrAspirationMessage = aspMsg & mobjCurrentStandard.StdName & " (Repeat #" & CurRepeat & ") from Position " & mobjCurrentStandard.PositionNumber
	//                                mobjBgMsgAspirate.AspirationMessage = mstrAspirationMessage
	//                                SetAutoSampler(mobjCurrentStandard.PositionNumber, True)
	//                            Else
	//                                mstrAspirationMessage = aspMsg & mobjCurrentStandard.StdName & "(Repeat #" & CurRepeat & ") and Click READ DATA or press <SPACEBAR>"
	//                                mobjBgMsgAspirate.AspirationMessage = mstrAspirationMessage
	//                            End If
	//                        Else
	//                            If (mblnIsAutosampler And mblnIsAnalysisStarted) Then
	//                                mstrAspirationMessage = aspMsg & mobjCurrentStandard.StdName & " from Position " & mobjCurrentStandard.PositionNumber
	//                                mobjBgMsgAspirate.AspirationMessage = mstrAspirationMessage
	//                                SetAutoSampler(mobjCurrentStandard.PositionNumber, True)
	//                            Else
	//                                mstrAspirationMessage = aspMsg & mobjCurrentStandard.StdName & " and Click READ DATA or press <SPACEBAR>"
	//                                mobjBgMsgAspirate.AspirationMessage = mstrAspirationMessage
	//                            End If
	//                        End If
	//                    End If
	//                Else
	//                    ' Aspirattion message when sample is used
	//                    If Not IsNothing(mobjCurrentSample) Then
	//                        If (gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfSampleRepeats > 1) Then
	//                            If (mblnIsAutosampler And mblnIsAnalysisStarted) Then
	//                                mstrAspirationMessage = aspMsg & mobjCurrentSample.SampleName & " (Repeat #" & CurRepeat & ") from Position " & mobjCurrentSample.SampPosNumber
	//                                mobjBgMsgAspirate.AspirationMessage = mstrAspirationMessage
	//                                SetAutoSampler(mobjCurrentSample.SampPosNumber, True)
	//                            Else
	//                                mstrAspirationMessage = aspMsg & mobjCurrentSample.SampleName & " (Repeat #" & CurRepeat & ") and Click READ DATA or press <SPACEBAR> "
	//                                mobjBgMsgAspirate.AspirationMessage = mstrAspirationMessage
	//                            End If
	//                        Else
	//                            If (mblnIsAutosampler And mblnIsAnalysisStarted) Then
	//                                mstrAspirationMessage = aspMsg & mobjCurrentSample.SampleName & " from Position " & mobjCurrentSample.SampPosNumber
	//                                mobjBgMsgAspirate.AspirationMessage = mstrAspirationMessage
	//                                SetAutoSampler(mobjCurrentSample.SampPosNumber, True)
	//                            Else
	//                                mstrAspirationMessage = aspMsg & mobjCurrentSample.SampleName & " and Click READ DATA or press <SPACEBAR>"
	//                                mobjBgMsgAspirate.AspirationMessage = mstrAspirationMessage
	//                            End If
	//                        End If
	//                    End If
	//                End If
	//            End If

	//            If btnReadData.Enabled Then
	//                btnReadData.Focus()
	//                btnReadData.Refresh()
	//            End If
	//            '//----- Commented by Sachin Dokhale
	//            'If (mblnIsAutosampler And mblnIsAnalysisStarted) Then
	//            '    'SendMessage(hwnd, WM_COMMAND, IDC_QAREAD, 0L)
	//            '    Call ReadData_Click(btnReadData, EventArgs.Empty)
	//            'End If
	//            '//-----
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

	//    Private Function SetAutoSampler(ByVal pos As Integer, ByVal flag As Boolean) As Boolean
	//        '=====================================================================
	//        ' Procedure Name        : SetAutoSampler
	//        ' Parameters Passed     : pos as position is integer, flag is use to Set or Reset the position
	//        ' Returns               : None
	//        ' Purpose               : Set Auto Sampler
	//        '                           
	//        ' Description           : 
	//        ' Assumptions           : 
	//        ' Dependencies          : 
	//        ' Author                : Mangesh Shardul
	//        ' Created               : 15-Dec-2006
	//        ' Revisions             : 1
	//        '=====================================================================
	//        '---FUNCTION TEMPORARILY COMMENTED AS NO AUTOSAMPLER
	//        'Return False'by Pankaj for autosampler on 10Sep 07
	//        '---FUNCTION TEMPORARILY COMMENTED AS NO AUTOSAMPLER


	//        'BOOL		SetAutoSampler(HWND hpar, int pos, BOOL flag)
	//        '{
	//        'char	str[40];
	//        '        If (!IsSamplerConnected()) Then
	//        '  return FALSE;

	//        ' if (hpar) EnableWindow(hpar, FALSE);
	//        'if (flag){
	//        '	 sprintf(str,"Sampler => %d        ", pos);
	//        '	 //PrintmsgOnWvAbsTag(str);
	//        '	 ASamplerStart(pos,hpar);
	//        '	}
	//        'else{
	//        '  sprintf(str, "Resetting Sampler    ");
	//        '  //PrintmsgOnWvAbsTag(str);
	//        '  ASamplerEnd(hpar);
	//        ' }
	//        '// }
	//        '// SendMessage(hpar, WM_COMMAND, IDC_QAREAD, 0L);
	//        ' if (hpar) EnableWindow(hpar, TRUE);
	//        'return TRUE;
	//        '}

	//        '-------CODE BY MANGESH 
	//        Dim str As String

	//        Try
	//            ' Set Autosampler messages
	//            Application.DoEvents() 'by Pankaj
	//            'If Not (gstructAutoSampler.blnCommunication = False) Then
	//            'check communication for autosampler
	//            If (gstructAutoSampler.blnCommunication = False) Then 'Modified by pankaj for autosampler
	//                SetAutoSampler = False
	//                Return False
	//            End If

	//            If (flag) Then
	//                str = "Sampler => " & pos & "    "
	//                lblAspirationMessage.Text = str
	//                'get message text
	//                gfuncAutoSamplerStartStatus(pos, lblAspirationMessage, gstructAutoSampler)
	//                Application.DoEvents() 'by Pankaj
	//            Else
	//                str = "Resetting Sampler    "
	//                lblAspirationMessage.Text = str
	//                gfuncAutoSamplerEndStatus(lblAspirationMessage, gstructAutoSampler)
	//                Application.DoEvents() 'by Pankaj
	//            End If
	//            SetAutoSampler = True
	//            Application.DoEvents() 'by Pankaj
	//            Return True

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
	//    End Function

	//    Private Function PositionAutosampler() As Boolean
	//        '=====================================================================
	//        ' Procedure Name        : PositionAutosampler
	//        ' Parameters Passed     : None
	//        ' Returns               : True if success
	//        ' Purpose               : Position to Auto Sampler
	//        '                           
	//        ' Description           : 
	//        ' Assumptions           : 
	//        ' Dependencies          : 
	//        ' Author                : Mangesh Shardul
	//        ' Created               : 15-Dec-2006
	//        ' Revisions             : 1
	//        '=====================================================================
	//        '---FUNCTION TEMPORARILY COMMENTED AS NO AUTOSAMPLER
	//        'Return False 'by Pankaj for autosampler on 10Sep 07
	//        '---FUNCTION TEMPORARILY COMMENTED AS NO AUTOSAMPLER


	//        'BOOL PositionAutosampler(HWND hwnd,char *str)
	//        '{
	//        '   int  WASH_TIME=20;
	//        '	GetProfileStringFromIniFile("AutoSampler", "Wash Time (sec)", "10",str, "asampler.ini");
	//        '	trim(ltrim(str)); 
	//        '   WASH_TIME=atoi(str);
	//        '   If (!IsSamplerConnected()) Then
	//        '	    return FALSE;
	//        '	strcpy(str,"Positioning Autosampler for Aspirating Blank");
	//        '   If (Started) Then
	//        '	    strcpy(Aspiratemsg, str);
	//        '	if(ASampler_GoToYhome(0))    
	//        '	{
	//        '	    if(ASampler_ProbeDown()){
	//        '		    sprintf(str,"Aspirating Blank wait for wash time %d sec",WASH_TIME);
	//        '           If (Started) Then
	//        '		        strcpy(Aspiratemsg, str);
	//        '		    ASampler_PumpON();
	//        '		    WaitForSec(WASH_TIME); 
	//        '		    ASampler_PumpOFF();
	//        '		 }
	//        '        Else
	//        '		    Gerror_message_system("Error in placing probe down");
	//        '	}
	//        '	else
	//        '	    Gerror_message_system("Error in positioning Autosampler");
	//        '	strcpy(str,"");
	//        '	return TRUE ;
	//        '}


	//        Dim WASH_TIME As Integer = 20
	//        Dim strTemp As String = ""

	//        Try
	//            ' Set wash time from ini setting
	//            strTemp = gFuncGetFromINI(CONST_Section_AutoSampler, CONST_Key_WashTime, "10", CONST_AutoSampler_INI_FileName)
	//            WASH_TIME = Val(Trim(strTemp))

	//            '---TEMPORARILY COMMENTED
	//            'If Not (IsSamplerConnected()) Then
	//            '    Return False
	//            'End If
	//            '---TEMPORARILY COMMENTED

	//            If (mblnIsAnalysisStarted) Then
	//                mstrAspirationMessage = "Positioning Autosampler for Aspirating Blank"
	//                lblAspirationMessage.Text = mstrAspirationMessage 'by PAnkaj on 3 Oct 07
	//                mobjBgMsgAspirate.AspirationMessage = mstrAspirationMessage
	//                Application.DoEvents() 'by Pankaj on 3 Oct 07 
	//            End If

	//            '---TEMPORARILY COMMENTED
	//            'If (ASampler_GoToYhome(0)) Then
	//            '    If (ASampler_ProbeDown()) Then
	//            '        If (mblnIsAnalysisStarted) Then
	//            '            mstrAspirationMessage = "Aspirating Blank wait for wash time " & WASH_TIME & " sec"
	//            '        End If
	//            '        ASampler_PumpON()
	//            '        WaitForSec(WASH_TIME)
	//            '        ASampler_PumpOFF()
	//            '    Else
	//            '        MessageBox.Show("Error in placing probe down")
	//            '    End If
	//            'Else
	//            '    MessageBox.Show("Error in positioning Autosampler")
	//            'End If
	//            '---TEMPORARILY COMMENTED
	//            ' position to autosampler
	//            ' Set Home position
	//            If (gobjCommProtocol.funcAutoSamplerHome()) Then
	//                ' Set probe down for Wash
	//                If gobjCommProtocol.funcAutoSamplerProbeDown() Then
	//                    If (mblnIsAnalysisStarted) Then
	//                        mstrAspirationMessage = "Aspirating Blank wait for wash time " & WASH_TIME & " sec"
	//                        Application.DoEvents() 'by Pankaj on 3 Oct 07
	//                    End If
	//                    ' Set pump On  for wash
	//                    Call gobjCommProtocol.funcAutoSamplerPumpON()
	//                    'ASampler_PumpON()
	//                    'WaitForSec(WASH_TIME)
	//                    ' Delay for wash time
	//                    Call gobjCommProtocol.mobjCommdll.subTime_Delay(gstructAutoSampler.intWashTime * 1000)
	//                    ' Set pump off
	//                    Call gobjCommProtocol.funcAutoSamplerPumpOFF()
	//                    'ASampler_PumpOFF()
	//                Else
	//                    gobjMessageAdapter.ShowMessage("Error in placing probe down", "AutoSampler", MessageHandler.clsMessageHandler.enumMessageType.ErrorMessage) ' by Pankaj on 29 Nov 07
	//                    'MessageBox.Show("Error in placing probe down")
	//                End If
	//            Else
	//                gobjMessageAdapter.ShowMessage("Error in positioning Autosampler", "AutoSampler", MessageHandler.clsMessageHandler.enumMessageType.ErrorMessage) 'by pankaj on 29 Nov 07
	//                'MessageBox.Show("Error in positioning Autosampler")
	//            End If
	//            Application.DoEvents() 'by Pankaj on 3 Oct 07
	//            Return True
	//            'Application.DoEvents()
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
	//    End Function

	//    Private Sub SaveRawDataFile()
	//        '=====================================================================
	//        ' Procedure Name        : SaveRawDataFile
	//        ' Parameters Passed     : None
	//        ' Returns               : None
	//        ' Purpose               : To save raw data for current run number.
	//        ' Description           : 
	//        ' Assumptions           : 
	//        ' Dependencies          : 
	//        ' Author                : Mangesh Shardul
	//        ' Created               : 17-Jan-2007 03:25 pm
	//        ' Revisions             : 1
	//        '=====================================================================
	//        'void	SaveRawDataFile(void)
	//        '{
	//        'char	fname[128]="";
	//        'char	rsultfname[80]="";
	//        ' if (Method->QuantData && Method->QuantData->Fname>0){
	//        '	 GetRawDataDirectory(fname);
	//        '	 sprintf(rsultfname,"Saving %08.0f.dat",Method->QuantData->Fname );
	//        '	 SetShortHelp(rsultfname, TRUE);
	//        '	 sprintf(rsultfname,"%08.0f.dat",Method->QuantData->Fname );
	//        '	 strcat(fname, rsultfname);
	//        '	 RawDataSave(fname);
	//        '	 SetShortHelp("", TRUE);
	//        '	}
	//        '}


	//        'CODE BY MANGESH 

	//        Dim fname As String = ""
	//        Dim rsultfname As String = ""

	//        Try
	//            ' check Methods object for data present
	//            If (Not IsNothing(gobjNewMethod) And CInt(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).RunNumber) > 0) Then
	//                ''rsultfname = "Saving " & gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).RunNumber & ".dat"
	//                ''rsultfname = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).RunNumber & ".dat"
	//                ''fname = rsultfname
	//                ''Call RawDataSave(fname)
	//                ' store raw data into analysis data object
	//                gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisRawData = mobjAnalysisRawData
	//            End If

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

	//    'Private Function CheckValidStdAbsEntry(ByVal objStandardData As Method.clsAnalysisStdParametersCollection) As Boolean
	//    '    'BOOL CheckValidStdAbsEntry( STDDATA *std) // this fn added by sss for checking the valid std used or not dt 30/11/2K
	//    '    '{
	//    '    'double abs=0.0;
	//    '    'BOOL   flag = TRUE;
	//    '    'if(std){
	//    '    '	if(std->Data.Used==1){
	//    '    '		abs = std->Data.Abs;
	//    '    '		std = std=std->next;
	//    '    '	}
	//    '    '}
	//    '    'while(std){
	//    '    '	  if(std->Data.Used==1){
	//    '    '		  if( std->Data.Abs <= abs ){
	//    '    '				flag = FALSE;
	//    '    '				Gerror_message_new("Abs of the standard is less than or equal to the previous standard", "Standards");
	//    '    '				return flag;
	//    '    '		  }
	//    '    '		  abs = std->Data.Abs;
	//    '    '	  }
	//    '    '	  std=std->next;
	//    '    '}
	//    '    'return flag;
	//    '    '}

	//    '    '*****************************
	//    '    '---CODE BY MANGESH
	//    '    '*****************************
	//    '    Dim abs As Double = 0.0
	//    '    Dim flag As Boolean = True
	//    '    Dim intCounter As Integer

	//    '    Try
	//    '        For intCounter = 0 To objStandardData.Count - 1
	//    '            If (objStandardData(intCounter).Used = True) Then
	//    '                If (objStandardData(intCounter).Abs <= abs) Then
	//    '                    flag = False
	//    '                    Call gobjMessageAdapter.ShowMessage("Abs of the standard is less than or equal to the previous standard", "Standards", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage)
	//    '                    Call Application.DoEvents()
	//    '                    Return False
	//    '                End If
	//    '                abs = objStandardData(intCounter).Abs
	//    '            End If
	//    '        Next

	//    '        Return flag

	//    '    Catch ex As Exception
	//    '        '---------------------------------------------------------
	//    '        'Error Handling and logging
	//    '        gobjErrorHandler.ErrorDescription = ex.Message
	//    '        gobjErrorHandler.ErrorMessage = ex.Message
	//    '        gobjErrorHandler.WriteErrorLog(ex)
	//    '        '---------------------------------------------------------
	//    '    Finally
	//    '        '---------------------------------------------------------
	//    '        'Writing Execution log
	//    '        If CONST_CREATE_EXECUTION_LOG = 1 Then
	//    '            gobjErrorHandler.WriteExecutionLog()
	//    '        End If
	//    '        '---------------------------------------------------------
	//    '    End Try
	//    'End Function

	//    'Private Function CheckValidSampAbsEntry(ByVal objSampleData As Method.clsAnalysisSampleParametersCollection, ByVal dblSampConc As Double) As Boolean
	//    '    'BOOL CheckValidSampAbsEntry( STDDATA *std,double sampconc) // this fn added by sss for checking the valid samp used or not dt 26/12/2K
	//    '    '{
	//    '    'double abs=0.0;
	//    '    'BOOL   flag = TRUE;
	//    '    'abs=GetMaxStdAbs(std);
	//    '    '//if((abs+abs*0.05) < sampconc)
	//    '    '        If ((abs) < sampconc) Then
	//    '    '	flag = FALSE;
	//    '    'return flag;
	//    '    '}

	//    '    '******************
	//    '    '---CODE BY MANGESH 
	//    '    '******************
	//    '    Dim abs As Double = 0.0
	//    '    Dim flag As Boolean = True

	//    '    Try
	//    '        abs = GetMaxStdAbs(objSampleData)

	//    '        If ((abs) < dblSampConc) Then
	//    '            flag = False
	//    '        End If

	//    '        Return flag

	//    '    Catch ex As Exception
	//    '        '---------------------------------------------------------
	//    '        'Error Handling and logging
	//    '        gobjErrorHandler.ErrorDescription = ex.Message
	//    '        gobjErrorHandler.ErrorMessage = ex.Message
	//    '        gobjErrorHandler.WriteErrorLog(ex)
	//    '        '---------------------------------------------------------
	//    '    Finally
	//    '        '---------------------------------------------------------
	//    '        'Writing Execution log
	//    '        If CONST_CREATE_EXECUTION_LOG = 1 Then
	//    '            gobjErrorHandler.WriteExecutionLog()
	//    '        End If
	//    '        '---------------------------------------------------------
	//    '    End Try
	//    'End Function

	//    'Private Function GetMaxStdAbs(ByVal objSampleData As Method.clsAnalysisSampleParametersCollection) As Double
	//    '    'double GetMaxStdAbs(STDDATA *std)
	//    '    '{
	//    '    'double Abs=0.0;
	//    '    'while(std){
	//    '    '	  if(std->Data.Used==1){
	//    '    '		  if( std->Data.Abs >= Abs )
	//    '    '				Abs = std->Data.Abs;
	//    '    '	  }
	//    '    '	  std=std->next;
	//    '    '}
	//    '    'return Abs;
	//    '    '}

	//    '    '********************
	//    '    '---CODE BY MANGESH 
	//    '    '********************
	//    '    Dim dblMaxAbs As Double
	//    '    Dim intCounter As Integer

	//    '    Try
	//    '        dblMaxAbs = 0.0

	//    '        For intCounter = 0 To objSampleData.Count - 1
	//    '            If (objSampleData.item(intCounter).Used = True) Then
	//    '                If (objSampleData.item(intCounter).Abs >= dblMaxAbs) Then
	//    '                    dblMaxAbs = objSampleData.item(intCounter).Abs
	//    '                End If
	//    '            End If
	//    '        Next

	//    '        Return dblMaxAbs

	//    '    Catch ex As Exception
	//    '        '---------------------------------------------------------
	//    '        'Error Handling and logging
	//    '        gobjErrorHandler.ErrorDescription = ex.Message
	//    '        gobjErrorHandler.ErrorMessage = ex.Message
	//    '        gobjErrorHandler.WriteErrorLog(ex)
	//    '        '---------------------------------------------------------
	//    '    Finally
	//    '        '---------------------------------------------------------
	//    '        'Writing Execution log
	//    '        If CONST_CREATE_EXECUTION_LOG = 1 Then
	//    '            gobjErrorHandler.WriteExecutionLog()
	//    '        End If
	//    '        '---------------------------------------------------------
	//    '    End Try
	//    'End Function

	//    Private Function StoreCalculateDisplayQuantValue() As Double
	//        '=====================================================================
	//        ' Procedure Name        : StoreCalculateDisplayQuantValue
	//        ' Parameters Passed     : None
	//        ' Returns               : bool 
	//        ' Purpose               : Calculate and display of quant. analysis data.
	//        ' Description           : 
	//        ' Assumptions           : 
	//        ' Dependencies          : 
	//        ' Author                : Mangesh Shardul
	//        ' Created               : 17-Jan-2007 03:25 pm
	//        ' Revisions             : 1
	//        '=====================================================================

	//        'double StoreCalculateDisplayQuantValue(HWND hwnd)
	//        '{
	//        'char	str[40]="";
	//        'double	abs=0.0;
	//        'double	abs1=0.0;
	//        'static	STDDATA	*nCurStd=NULL;
	//        'static	SAMPDATA	*nCurSamp=NULL;
	//        'static	double	lblank = (double) 0.0;
	//        'static	int	nSampType = -1 ;;

	//        'if(mobjCurrentStandard==Method->QuantData->StdTopData && CurRepeat==1)
	//        '{
	//        '   nCurStd=NULL;
	//        '	nCurSamp=NULL;
	//        '	lblank=(double) 0.0;
	//        '	nSampType=-1;;
	//        '}

	//        'if (Method->QuantData->Param.Meas_Mode==INTEGRATE)
	//        '{
	//        '   abs = GetAvgValOfCurAnalysis();
	//        '	abs = GetValConvertedTo(abs, Method->Mode);
	//        '}
	//        'else if (Method->QuantData->Param.Meas_Mode==PKAREA)
	//        '{
	//        '   abs = GetPeakAreaOfCurAnalysis();
	//        '	abs = GetValConvertedTo(abs, Method->Mode);
	//        '}
	//        'else if (Method->QuantData->Param.Meas_Mode==PKHEIGHT)
	//        '{
	//        '   abs = GetPeakHeightOfCurAnalysis();
	//        '	abs = GetValConvertedTo(abs, Method->Mode);
	//        '}

	//        'if (SampType == BLANK)
	//        '{
	//        '   BlankAbs = abs;
	//        '	GetValInString(abs, str, Method->Mode);
	//        '	SetDlgItemText(hwnd,IDC_QAVABS, str);
	//        '	SetDlgItemText(hwnd,IDC_QCORABS, "");
	//        '	SetDlgItemText(hwnd,IDC_QCONC, "");

	//        '   if (GetBlankCalType())
	//        '   {
	//        '	    BlankAbs = (lblank + BlankAbs)/2.0;
	//        '		if (nSampType==STD && nCurStd!=NULL)
	//        '       {
	//        '		    abs =nCurStd->Data.Abs;
	//        '			sprintf(str, "%s",nCurStd->Data.Std_Name);
	//        '	    }
	//        '		if (nSampType==SAMP&& nCurSamp!=NULL)
	//        '       {
	//        '		    abs =nCurSamp->Data.Abs;
	//        '			sprintf(str, "%s",nCurSamp->Data.Samp_Name);
	//        '		}
	//        '		SetDlgItemText(hwnd,IDC_QSAMPID, str);
	//        '		abs1 = StoreCalculateStdSampDisplayQuantValue(hwnd, nSampType, &nCurStd, &nCurSamp, abs);

	//        '		if (mobjCurrentStandard==NULL && mobjCurrentSample ==Method->QuantData->SampTopData)
	//        '			 Create_Standard_Sample_Curve(hwnd,FALSE);
	//        '   }
	//        '}
	//        'else
	//        '{
	//        '   If (!GetBlankCalType()) Then
	//        '	    abs1=StoreCalculateStdSampDisplayQuantValue(hwnd, SampType, &mobjCurrentStandard, &mobjCurrentSample, abs);
	//        '   else
	//        '   {
	//        '       if (SampType==STD && mobjCurrentStandard!=NULL)
	//        '		    mobjCurrentStandard->Data.Abs=abs;

	//        '	    if (SampType==SAMP&& mobjCurrentSample!=NULL)
	//        '		    mobjCurrentSample->Data.Abs=abs;

	//        '		 GetValInString(abs, str, Method->Mode);
	//        '		 SetDlgItemText(hwnd,IDC_QAVABS, str);
	//        '		 SetDlgItemText(hwnd,IDC_QCORABS, "");
	//        '		 nCurStd=mobjCurrentStandard;
	//        '		 nCurSamp=mobjCurrentSample;
	//        '		 nSampType = SampType;
	//        '		 lblank = BlankAbs;
	//        '	}
	//        '}
	//        'return abs1;
	//        '}


	//        '---CODE BY MANGESH 

	//        Dim strSampleName As String = ""
	//        Dim abs As Double = 0.0
	//        Dim abs1 As Double = 0.0

	//        Static Dim nCurStd As Method.clsAnalysisStdParameters
	//        Static Dim nCurSamp As Method.clsAnalysisSampleParameters
	//        Static Dim lblank As Double = 0.0
	//        Static Dim nSampType As ClsAAS203.enumSampleType = -1

	//        Try
	//            If (mobjCurrentStandard Is gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(0) And CurRepeat = 1) Then
	//                nCurStd = Nothing
	//                nCurSamp = Nothing
	//                lblank = 0.0
	//                nSampType = -1
	//            End If

	//            If (gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.MeasurementMode = enumMeasurementMode.Integrate) Then
	//                '---Get Average of all readings of clsRawData 
	//                abs = GetAvgValOfCurAnalysis()

	//                '---Later call this method instead of above function.
	//                'abs = GetAvgValOfAnalysis( .item(0) )
	//                '---Later on remove this comment

	//            ElseIf (gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.MeasurementMode = enumMeasurementMode.PeakArea) Then
	//                '---Returns ZERO 
	//                abs = GetPeakAreaOfCurAnalysis()

	//            ElseIf (gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.MeasurementMode = enumMeasurementMode.PeakHeight) Then
	//                '---Returns ZERO 
	//                abs = GetPeakHeightOfCurAnalysis()

	//            End If

	//            If (SampleType = ClsAAS203.enumSampleType.BLANK) Then
	//                mdblBlankAbsorbance = abs

	//                'Saurabh 05 June 2007
	//                'lblAverageAbsorbance.Text = FormatNumber(abs, gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfDecimalPlaces)
	//                'lblAverageAbsorbance.Text = FormatNumber(abs, 3)   'Commented & Added by Saurabh 01.08.07
	//                If gobjNewMethod.OperationMode = EnumOperationMode.MODE_EMMISSION Then
	//                    'lblAverageAbsorbance.Text = FormatNumber(abs, 1)
	//                Else
	//                    'lblAverageAbsorbance.Text = FormatNumber(abs, 3)
	//                End If
	//                'Saurabh 05 June 2007

	//                'lblCorrectedAbsorbance.Text = ""
	//                'lblConcentration.Text = ""

	//                If (gstructSettings.BlankCalculation) Then
	//                    mdblBlankAbsorbance = (lblank + mdblBlankAbsorbance) / 2.0

	//                    If nSampType = ClsAAS203.enumSampleType.STANDARD And (Not IsNothing(nCurStd)) Then
	//                        abs = nCurStd.Abs
	//                        strSampleName = nCurStd.StdName
	//                    End If

	//                    If nSampType = ClsAAS203.enumSampleType.SAMPLE And (Not IsNothing(nCurSamp)) Then
	//                        abs = nCurSamp.Abs
	//                        strSampleName = nCurSamp.SampleName
	//                    End If
	//                    'lblSampleID.Text = strSampleName

	//                    abs1 = StoreCalculateStdSampDisplayQuantValue(nSampType, nCurStd, nCurSamp, abs)

	//                    'if (mobjCurrentStandard==NULL && mobjCurrentSample == Method->QuantData->SampTopData)
	//                    '   Create_Standard_Sample_Curve(hwnd,FALSE);
	//                    If (IsNothing(mobjCurrentStandard) And mobjCurrentSample Is gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(0)) Then
	//                        Call gobjclsStandardGraph.Create_Standard_Sample_Curve(False, True, 0, 0, gobjNewMethod)
	//                    End If
	//                End If
	//            Else
	//                If Not (gstructSettings.BlankCalculation) Then
	//                    abs1 = StoreCalculateStdSampDisplayQuantValue(SampleType, mobjCurrentStandard, mobjCurrentSample, abs)
	//                    If Not mobjCurrentStandard Is Nothing Then
	//                        'mobjLastStandardData = mobjCurrentStandard.Clone
	//                        mobjLastStandardData = mobjCurrentStandard
	//                    Else
	//                        mobjLastStandardData = Nothing
	//                    End If
	//                    If Not mobjCurrentSample Is Nothing Then
	//                        'mobjLastSampleData = mobjCurrentSample.Clone
	//                        mobjLastSampleData = mobjCurrentSample
	//                    Else
	//                        mobjLastSampleData = Nothing
	//                    End If
	//                Else
	//                    If (SampleType = ClsAAS203.enumSampleType.STANDARD) And Not IsNothing(mobjCurrentStandard) Then
	//                        mobjCurrentStandard.Abs = abs
	//                    End If

	//                    If (SampleType = ClsAAS203.enumSampleType.SAMPLE And Not IsNothing(mobjCurrentSample)) Then
	//                        mobjCurrentSample.Abs = abs
	//                    End If

	//                    'Saurabh 05 June 2007
	//                    'lblAverageAbsorbance.Text = FormatNumber(abs, gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfDecimalPlaces)
	//                    'lblAverageAbsorbance.Text = FormatNumber(abs, 3)   'Commented & Added by Saurabh 01.08.07
	//                    If gobjNewMethod.OperationMode = EnumOperationMode.MODE_EMMISSION Then
	//                        'lblAverageAbsorbance.Text = FormatNumber(abs, 1)
	//                    Else
	//                        'lblAverageAbsorbance.Text = FormatNumber(abs, 3)
	//                    End If
	//                    'Saurabh 05 June 2007

	//                    'lblCorrectedAbsorbance.Text = ""
	//                    nCurStd = mobjCurrentStandard
	//                    nCurSamp = mobjCurrentSample
	//                    nSampType = SampleType
	//                    lblank = mdblBlankAbsorbance
	//                    If Not mobjCurrentStandard Is Nothing Then
	//                        mobjLastStandardData = mobjCurrentStandard
	//                    Else
	//                        mobjLastStandardData = Nothing
	//                    End If
	//                    If Not mobjCurrentSample Is Nothing Then
	//                        mobjLastSampleData = mobjCurrentSample
	//                    Else
	//                        mobjLastSampleData = Nothing
	//                    End If
	//                End If

	//            End If

	//            Return abs1

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
	//    End Function

	//    Private Function RawDataSave(ByVal strFullFileName As String) As Boolean
	//        '=====================================================================
	//        ' Procedure Name        : RawDataSave
	//        ' Parameters Passed     : strFullFileName as String 
	//        ' Returns               : bool True if success
	//        ' Purpose               : To Save Quant Data into file system
	//        '                           
	//        ' Description           : 
	//        ' Assumptions           : 
	//        ' Dependencies          : 
	//        ' Author                : Mangesh Shardul
	//        ' Created               : 15-Dec-2006
	//        ' Revisions             : 1
	//        '=====================================================================
	//        'RAW_DATA 		*tempk=NULL;
	//        'RAW_DATA_LINKS *tempk1=NULL;
	//        'FILE *fp;

	//        Dim objRawDataReadings As Analysis.clsRawDataReadings
	//        Dim intCount As Integer
	//        Dim intReadingCounter As Integer
	//        Dim fs As IO.FileStream
	//        Dim sw As IO.StreamWriter

	//        Dim blnIsBlank, blnIsStandard, blnIsSample As Boolean
	//        Dim intPrevSampleID, intSampleID As Integer
	//        Dim strPath As String = ""
	//        Try
	//            '---05.12.07
	//            strPath = Application.StartupPath & "\" & strFullFileName
	//            strFullFileName = strPath

	//            If IsNothing(mobjAnalysisRawData) Then
	//                Return False
	//            End If
	//            'To Save Quant Data into text file format

	//            If IO.File.Exists(strFullFileName) Then IO.File.Delete(strFullFileName)

	//            fs = New IO.FileStream(strFullFileName, IO.FileMode.OpenOrCreate)
	//            sw = New IO.StreamWriter(fs)

	//            If Not IsNothing(sw) Then
	//                For intCount = 0 To mobjAnalysisRawData.Count - 1
	//                    objRawDataReadings = mobjAnalysisRawData.item(intCount).Readings
	//                    If (mobjAnalysisRawData.item(intCount).TotalReadings > 0) Then
	//                        intSampleID = mobjAnalysisRawData.item(intCount).SampleID
	//                        Select Case mobjAnalysisRawData.item(intCount).SampleType
	//                            '--- Write the blank data details
	//                        Case clsRawData.enumSampleType.BLANK
	//                                If Not blnIsBlank Then
	//                                    blnIsBlank = True
	//                                    blnIsStandard = False
	//                                    blnIsSample = False
	//                                    sw.WriteLine("BLANK; ; ; " & objRawDataReadings.Count)
	//                                Else
	//                                    If intSampleID <> intPrevSampleID Then
	//                                        sw.WriteLine()
	//                                        sw.WriteLine("BLANK; ; ; " & objRawDataReadings.Count)
	//                                    End If
	//                                End If
	//                                '--- Write the Stadard data details
	//                            Case clsRawData.enumSampleType.STANDARD
	//                                If Not blnIsStandard Then
	//                                    blnIsBlank = False
	//                                    blnIsStandard = True
	//                                    blnIsSample = False
	//                                    sw.WriteLine()
	//                                    sw.WriteLine("STANDARD ;" & mobjAnalysisRawData(intCount).SampleID & ";" & mobjAnalysisRawData(intCount).SampleName & "; " & objRawDataReadings.Count & "")
	//                                Else
	//                                    If intSampleID <> intPrevSampleID Then
	//                                        sw.WriteLine()
	//                                        sw.WriteLine("STANDARD ;" & mobjAnalysisRawData(intCount).SampleID & ";" & mobjAnalysisRawData(intCount).SampleName & "; " & objRawDataReadings.Count & "")
	//                                    End If
	//                                End If
	//                                '--- Write the Sample data details
	//                            Case clsRawData.enumSampleType.SAMPLE
	//                                If Not blnIsSample Then
	//                                    blnIsBlank = False
	//                                    blnIsStandard = False
	//                                    blnIsSample = True
	//                                    sw.WriteLine()
	//                                    sw.WriteLine("SAMPLE ;" & mobjAnalysisRawData(intCount).SampleID & ";" & mobjAnalysisRawData(intCount).SampleName & "; " & objRawDataReadings.Count & "")
	//                                Else
	//                                    If intSampleID <> intPrevSampleID Then
	//                                        sw.WriteLine()
	//                                        sw.WriteLine("SAMPLE ;" & mobjAnalysisRawData(intCount).SampleID & ";" & mobjAnalysisRawData(intCount).SampleName & "; " & objRawDataReadings.Count & "")
	//                                    End If
	//                                End If
	//                        End Select
	//                    End If
	//                    For intReadingCounter = 0 To objRawDataReadings.Count - 1
	//                        sw.WriteLine(objRawDataReadings(intReadingCounter).XTime & " ,  " & objRawDataReadings(intReadingCounter).Absorbance)
	//                    Next
	//                    '---Draw empty line
	//                    'sw.WriteLine()
	//                    intPrevSampleID = intSampleID
	//                Next intCount

	//            End If

	//            sw.Flush()
	//            fs.Flush()

	//            Return True

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
	//            sw.Close()
	//            fs.Close()
	//            '---------------------------------------------------------
	//        End Try
	//    End Function

	//    Public Function Calculate_Analysis_Graph_Param(ByRef Curve As AASGraph, Optional ByVal XValue As Double = 0.0, Optional ByVal YValue As Double = 0.0) As Double
	//        '=====================================================================
	//        ' Procedure Name        : Calculate_Analysis_Graph_Param
	//        ' Parameters Passed     : AASGraph Reference, XValue,YValue 
	//        ' Returns               : Double value
	//        ' Purpose               : Calculate graph parameter of analysis
	//        ' Description           : 
	//        ' Assumptions           : 
	//        ' Dependencies          : 
	//        ' Author                : Mangesh Shardul
	//        ' Created               : 17-Jan-2007 03:25 pm
	//        ' Revisions             : 1
	//        '=====================================================================
	//        Dim FrqIntv As Double = 0.0
	//        Dim xmax1 As Double = 0
	//        Dim xmin1 As Double = 0
	//        Dim Fmin As Double = 0
	//        Dim Fmax As Double = 0
	//        Dim Fx As Double = 0
	//        Dim fn, tot1 As Integer

	//        Try
	//            ' Calculate the Graph X axis coordinates 
	//            If IsNothing(Curve) Then
	//                Return 0.0
	//            End If

	//            xmax1 = Curve.YAxisMax
	//            xmin1 = Curve.YAxisMin
	//            tot1 = (xmax1 - xmin1) * 60

	//            FrqIntv = gobjclsStandardGraph.GetInterval(xmax1, xmin1, tot1, True)
	//            'FrqIntv = 100

	//            fn = (xmax1 / FrqIntv)
	//            Fmax = CDbl(fn * FrqIntv)
	//            If xmax1 > Fmax Then
	//                Fmax = Fmax + FrqIntv
	//            End If
	//            fn = CInt(xmin1 / FrqIntv)
	//            Fmin = CDbl(fn * FrqIntv)

	//            If (xmin1 < Fmin) Then
	//                Fmin = Fmin - FrqIntv
	//            End If

	//            If (Fmin > xmin1) And (FrqIntv <> -1.0) Then
	//                While (Fmin > xmin1)
	//                    Fmax -= FrqIntv
	//                End While
	//            End If

	//            If (Fmax < xmax1 And FrqIntv <> -1.0) Then
	//                While (Fmax < xmax1)
	//                    Fmax += FrqIntv
	//                End While
	//            End If
	//            'Curve.YAxisMin = -0.2 'Fmin
	//            'Curve.YAxisMax = 1.1  'Fmax
	//            'Curve.YAxisStep = 0.1 'FrqIntv
	//            'Curve.YAxisMinorStep = 0.05

	//            '---changed by deepak on 29.04.07
	//            Curve.YAxisMin = -0.2 'Fmin
	//            Curve.YAxisMax = 0.8  '0.8 'Fmax ' changed by pankaj
	//            Curve.YAxisStep = 0.2 'FrqIntv
	//            Curve.YAxisMinorStep = 0.2
	//            '---changed by deepak on 29.04.07

	//            '//----- Added by Sachin Dokhale
	//            'xmax1 = Curve.XAxisMax
	//            'xmin1 = Curve.XAxisMin
	//            If Not (XValue = 0.0) Then
	//                'Saurabh 10.07.07 for Scrolling Graph
	//                'If (XValue > Curve.XAxisMax) Then
	//                '    xmax1 = Curve.XAxisMax + (gobjNewMethod.AnalysisParameters.IntegrationTime * 3)
	//                'End If
	//                'xmin1 = Curve.XAxisMin
	//                If (XValue > Curve.XAxisMax) Then
	//                    xmax1 = Curve.XAxisMax + (gobjNewMethod.AnalysisParameters.IntegrationTime + 20)
	//                    xmin1 = Curve.XAxisMin + (gobjNewMethod.AnalysisParameters.IntegrationTime + 20)
	//                Else
	//                    xmin1 = Curve.XAxisMin
	//                End If

	//            Else
	//                xmax1 = Curve.XAxisMax
	//                xmin1 = Curve.XAxisMin
	//            End If

	//            tot1 = 60
	//            Fx = gobjclsStandardGraph.GetInterval(xmax1, xmin1, tot1, True)

	//            If (Fx > 0) Then
	//                fn = xmax1 / Fx
	//            Else
	//                fn = 0
	//            End If

	//            Fmax = fn * Fx
	//            If (xmax1 > Fmax) Then
	//                Fmax += Fx
	//            End If

	//            Curve.XAxisMin = xmin1
	//            Curve.XAxisMax = Fmax
	//            Curve.XAxisStep = gobjclsStandardGraph.GetInterval(Curve.XAxisMax, Curve.XAxisMin, tot1, True)

	//            'If is Added by Saurabh for Emission---------------
	//            ' Chanege parameters for Emission mode 
	//            If gobjNewMethod.OperationMode = EnumOperationMode.MODE_EMMISSION Then
	//                'AASGraphAnalysis.YAxisMin = -10.0
	//                'AASGraphAnalysis.YAxisMax = 100
	//                'AASGraphAnalysis.YAxisMinorStep = 2
	//            Else
	//                '-----Added By Pankaj on 10 May 2007
	//                ' Chanege parameters for else mode
	//                'AASGraphAnalysis.YAxisMin = -0.2
	//                'AASGraphAnalysis.YAxisMax = 1.2
	//            End If

	//            'gobjClsAAS203.Calculate_Analysis_Graph_Param(AASGraphAnalysis, ClsAAS203.enumChangeAxis.xyAxis)
	//            '-------------

	//            Return FrqIntv

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
	//    End Function

	//    Public Function Read_Quant_Data(ByVal intStartTime As Integer, ByVal intEndTime As Integer) As Double
	//        '=====================================================================
	//        ' Procedure Name        : Read_Quant_Data
	//        ' Parameters Passed     : intStartTime as int
	//        '                         intEndTime  as int
	//        ' Returns               : Double
	//        ' Purpose               : Read Quant Data event 
	//        '                           
	//        ' Description           : 
	//        ' Assumptions           : 
	//        ' Dependencies          : 
	//        ' Author                : Mangesh Shardul
	//        ' Created               : 15-Dec-2006
	//        ' Revisions             : 1
	//        '=====================================================================
	//        'double	 (HWND hwnd, CURVEDATA *AnaGraph)
	//        '{
	//        'HDC				 hdc;
	//        'HPEN				 hpen, hpenold;
	//        'double          abs1=0.0;

	//        '#If QDEMO Then
	//        'int	adval=0;
	//        '  if (!Dfptr){
	//        '	 Dfptr= fopen("raw0.dat","rt");
	//        '	 if (Dfptr)
	//        '		 fscanf(Dfptr, "%d", &adval);
	//        '	}
	//        '#End If
	//        ' hdc = GetDC(hwnd);
	//        ' ReadFilterSetting();   // new changes
	//        ' if (Method->Mode==MODE_UVABS){
	//        '	Read_Quant_Data_UV_Mode(hwnd);
	//        '  }
	//        ' else{
	//        '	hpen= SetColor(SampType, TRUE);
	//        '   If (hpen! = NULL) Then
	//        '	    hpenold = SelectObject(hdc, hpen);
	//        '	if (Xoldt!=-1 && Yoldt!=-1)
	//        '	    SetXoldYold(Xoldt, Yoldt);
	//        '	if (Method->QuantData->Param.Meas_Mode==INTEGRATE){
	//        '       If (!Filter_flag) Then
	//        '		    Wait_For_Analysis(hwnd, 2);
	//        '       Else
	//        '		    Wait_For_Analysis(hwnd, 2);
	//        '		Read_Quant_Data_Integration_Mode(hwnd,hdc, AnaGraph);
	//        '	}
	//        '	else if (Method->QuantData->Param.Meas_Mode==PKAREA ||
	//        '	         Method->QuantData->Param.Meas_Mode==PKHEIGHT)
	//        '	    Read_Quant_Data_PkHt_Area_Mode(hwnd, hdc, AnaGraph);
	//        '   abs1=StoreCalculateDisplayQuantValue(hwnd);
	//        '	GetXoldYold(&Xoldt, &Yoldt);
	//        '	if (hpen!=NULL){
	//        '	    SelectObject(hdc, hpenold);
	//        '	DeleteObject(hpen);
	//        '  }
	//        ' }
	//        ' ReleaseDC(hwnd, hdc);
	//        ' return abs1;
	//        '}


	//        '---CODE BY MANGESH

	//        'HDC				 hdc;
	//        'HPEN				 hpen, hpenold;
	//        Dim dblAbsorbance As Double = 0.0

	//        Try
	//            '#If QDEMO Then
	//            ' dim adval as integer=0
	//            ' if not (Dfptr)
	//            '	 Dfptr= fopen("raw0.dat","rt")
	//            '	 if (Dfptr)
	//            '		 fscanf(Dfptr, "%d", &adval )
	//            '   end if
	//            '  end if
	//            '#End If

	//            ' Read the filter setting
	//            Call gobjClsAAS203.funcReadFilterSetting()
	//            '--- Start to Aspiration thread
	//            Call StartAspirationThread(intStartTime, intEndTime)

	//            ''If (gobjNewMethod.OperationMode = EnumOperationMode.MODE_UVABS) Then
	//            ''    'Call Read_Quant_Data_UV_Mode()
	//            ''Else
	//            ''    'hpen = SetColor(SampType, True)
	//            ''    'If Not (hpen Is Nothing) Then
	//            ''    '    hpenold = SelectObject(hdc, hpen)
	//            ''    'End If
	//            ''    'If (XOld <> -1 And YOld <> -1) Then
	//            ''    '    SetXoldYold(XOld, YOld)
	//            ''    'End If

	//            ''    'If (XOld <> -1 And YOld <> -1) Then
	//            ''    '    XOld = 0
	//            ''    '    YOld = 0
	//            ''    'End If

	//            ''    Call StartAspirationThread(dtStartTime)

	//            ''    If (gobjNewMethod.AnalysisParameters.MeasurementMode = enumMeasurementMode.Integrate) Then
	//            ''        If Not (Filter_flag) Then
	//            ''            Wait_For_Analysis(2)
	//            ''        Else
	//            ''            Wait_For_Analysis(2)
	//            ''        End If

	//            ''        'Call Read_Quant_Data_Integration_Mode()
	//            ''        Call StartAspirationThread(dtStartTime)

	//            ''    ElseIf (gobjNewMethod.AnalysisParameters.MeasurementMode = enumMeasurementMode.PeakArea Or _
	//            ''            gobjNewMethod.AnalysisParameters.MeasurementMode = enumMeasurementMode.PeakHeight) Then

	//            ''        '#########TO DO Later
	//            ''        Call gobjClsAAS203.Read_Quant_Data_PkHt_Area_Mode()
	//            ''    End If

	//            '----Shited to Completed event function of BgThread
	//            'dblAbsorbance = StoreCalculateDisplayQuantValue()
	//            'Call GetXoldYold(XOld, YOld)
	//            'If Not (hpen Is Nothing) Then
	//            '    'SelectObject(hdc, hpenold)
	//            '    'DeleteObject(hpen)
	//            'End If
	//            '##########################################

	//            ''End If

	//            Return dblAbsorbance

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
	//    End Function

	//    Private Sub SetXoldYold(ByVal dblXold As Double, ByVal dblYold As Double)
	//        '=====================================================================
	//        ' Procedure Name        : SetXoldYold
	//        ' Parameters Passed     : dblXold, dblYold as double
	//        ' Returns               : None
	//        ' Purpose               : Set X and Y Coordinate value to module level variable
	//        '                           
	//        ' Description           : 
	//        ' Assumptions           : 
	//        ' Dependencies          : 
	//        ' Author                : Mangesh Shardul
	//        ' Created               : 15-Dec-2006
	//        ' Revisions             : 1
	//        '=====================================================================

	//        'void SetXoldYold(int Xoldt, int Yoldt)
	//        '{
	//        '   Xold=Xoldt;
	//        '   Yold= Yoldt;
	//        '}
	//        Try
	//            'remember x y 
	//            XOld = dblXold
	//            YOld = dblYold

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

	//    Private Sub GetXoldYold(ByRef dblXold As Double, ByRef dblYold As Double)
	//        '=====================================================================
	//        ' Procedure Name        : GetXoldYold
	//        ' Parameters Passed     : dblXold, dblYold as double
	//        ' Returns               : None
	//        ' Purpose               : get X and Y Coordinate value to module level variable
	//        '                           
	//        ' Description           : 
	//        ' Assumptions           : 
	//        ' Dependencies          : 
	//        ' Author                : Mangesh Shardul
	//        ' Created               : 15-Dec-2006
	//        ' Revisions             : 1
	//        '=====================================================================
	//        'void GetXoldYold(int *Xoldt, int *Yoldt)
	//        '{
	//        '   *Xoldt=Xold;
	//        '   *Yoldt= Yold;
	//        '}
	//        Try
	//            dblXold = XOld
	//            dblYold = YOld

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

	//    Private Function GetAvgValOfCurAnalysis() As Double
	//        '=====================================================================
	//        ' Procedure Name        : GetAvgValOfCurAnalysis
	//        ' Parameters Passed     : None
	//        ' Returns               : Double
	//        ' Purpose               : return then Avg Value of Current Analysis 
	//        '                           
	//        ' Description           : 
	//        ' Assumptions           : 
	//        ' Dependencies          : 
	//        ' Author                : Mangesh Shardul
	//        ' Created               : 15-Dec-2006
	//        ' Revisions             : 1
	//        '=====================================================================
	//        'double	GetAvgValOfCurAnalysis()
	//        '{
	//        ' return GetAvgValOfAnalysis(Raw->RawDataCur);        
	//        '}


	//        '---CODE BY MANGESH

	//        Try
	//            'return GetAvgValOfAnalysis(Raw->RawDataCur) 
	//            ' Return Avg. value of analysis Raw data
	//            If Not IsNothing(mobjAnalysisRawData) Then
	//                If mobjAnalysisRawData.Count > 0 Then
	//                    Return GetAvgValOfAnalysis(mobjAnalysisRawData.item(mobjAnalysisRawData.Count - 1))
	//                End If
	//            End If

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
	//    End Function

	//    Private Function GetAvgValOfAnalysis(ByVal objAnalysisRawData As clsRawData) As Double
	//        '=====================================================================
	//        ' Procedure Name        : GetAvgValOfAnalysis
	//        ' Parameters Passed     : objAnalysisRawData of clsRawData data type
	//        ' Returns               : Double
	//        ' Purpose               : return then Avg Value of Current Analysis of given clsRowData data type
	//        '                           
	//        ' Description           : 
	//        ' Assumptions           : 
	//        ' Dependencies          : 
	//        ' Author                : Mangesh Shardul
	//        ' Created               : 15-Dec-2006
	//        ' Revisions             : 1
	//        '=====================================================================
	//        '{
	//        'double	val=0.0;
	//        'int	tot=0;
	//        'RAW_DATA_LINKS *tempk=NULL;

	//        'if (node==NULL)
	//        '   return val;
	//        'tempk = node->Data.TopRawData;
	//        'while(tempk!=NULL)
	//        '{
	//        '   val+= tempk->Data.Abs;
	//        '   tot++;
	//        '   tempk=tempk->next;
	//        '}
	//        'If (tot > 0) Then
	//        '   val/=tot;
	//        'return val;
	//        '}


	//        '--- CODE BY MANGESH

	//        Dim dblAbsorbance As Double
	//        Dim intTotal As Integer
	//        Dim objRawDataReading As Analysis.clsRawDataReadings.RAW_DATA
	//        Dim intCounter As Integer

	//        Try
	//            'calculate Avg Value of Current Analysis of given clsRowData data type.
	//            intTotal = 0

	//            If Not IsNothing(objAnalysisRawData) Then

	//                For intCounter = 0 To objAnalysisRawData.Readings.Count - 1
	//                    objRawDataReading = objAnalysisRawData.Readings.item(intCounter)
	//                    dblAbsorbance += objRawDataReading.Absorbance
	//                    intTotal += 1
	//                Next intCounter

	//                If (intTotal > 0) Then
	//                    dblAbsorbance = dblAbsorbance / intTotal
	//                End If
	//            End If
	//            Return dblAbsorbance

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
	//    End Function

	//    Private Function GetPeakAreaOfCurAnalysis() As Double
	//        '=====================================================================
	//        ' Procedure Name        : GetPeakAreaOfCurAnalysis
	//        ' Parameters Passed     : objAnalysisRawData of clsRawData data type
	//        ' Returns               : Double
	//        ' Purpose               : get peak area of curve of analysis
	//        '                           
	//        ' Description           : 
	//        ' Assumptions           : 
	//        ' Dependencies          : 
	//        ' Author                : Mangesh Shardul
	//        ' Created               : 15-Dec-2006
	//        ' Revisions             : 1
	//        '=====================================================================

	//        'double	GetPeakAreaOfCurAnalysis()
	//        '{
	//        '/* float	absorb=0.0;
	//        ' float	y1;
	//        ' float	val=0;
	//        ' int	 i;
	//        ' absorb = 0.0 ;
	//        ' // formaulae = dx* ((y1+y2)/2 -(y1+y')/2)
	//        ' read_count = findPeak_end();
	//        ' for (i =0; i<read_count-1; i++){
	//        '	y1=GetBaseExtra((float) (i+1));
	//        '	val = (abs_read[i+1]-y1)/2.0;
	//        '            If (Val() < 0) Then
	//        '	 val=0;
	//        '   absorb+=val;
	//        '  }
	//        ' clearwindow1(20, 294, 190, 306);
	//        ' gxy1(5, 22);
	//        ' absorb = get_float(absorb, TRUE);
	//        ' if (mode==AA||mode==AABGC) gprintf("Peak Area   : %4.3f ", absorb);
	//        ' else if (mode==EMISSION)   gprintf("Peak Area   : %-4.3f ", absorb);
	//        ' return(absorb);
	//        ' }
	//        ' */

	//        'return 0.0;
	//        '}


	//        '--- CODE BY MANGESH 

	//        Try
	//            Return 0.0

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
	//    End Function

	//    Private Function GetPeakHeightOfCurAnalysis() As Double
	//        '=====================================================================
	//        ' Procedure Name        : GetPeakHeightOfCurAnalysis
	//        ' Parameters Passed     : None
	//        ' Returns               : None
	//        ' Purpose               : get peak height of curve of analysis. 
	//        '                           
	//        ' Description           : 
	//        ' Assumptions           : 
	//        ' Dependencies          : 
	//        ' Author                : Mangesh Shardul
	//        ' Created               : 15-Dec-2006
	//        ' Revisions             : 1
	//        '=====================================================================
	//        'double	GetPeakHeightOfCurAnalysis()
	//        '{
	//        '   //---mdf by sk on 3/8/2001
	//        '   // return GetPkHtOfAnalysis(Raw->RawDataCur);
	//        '   //---mdf by sk on 3/8/2001
	//        '   /*float	peakheight()
	//        '   {
	//        '       float	absorb=0.0, sav=0.0, base=0.0;
	//        '       int	i;
	//        '       for (i =4; i<read_count-4; i++)  {
	//        '	        sav=abs_read[i];
	//        '	        if (sav > absorb){
	//        '	            absorb = sav;
	//        '	            base =  abs_read[0]+sav* (abs_read[read_count-1]-abs_read[0])/(read_count-1);
	//        '	            base= get_float(base, TRUE);
	//        '	        }
	//        '       }
	//        '       clearwindow1(20, 294, 190, 306);
	//        '       gxy1(5, 22);
	//        '       absorb -= base;
	//        '       absorb= get_float(absorb, TRUE);
	//        '       if (mode==AA||mode==AABGC) gprintf("Peak Height : %4.3f", absorb);
	//        '       else if (mode==EMISSION)   gprintf("Peak Height : %-4.3f", absorb);
	//        '       return(absorb);
	//        '   }
	//        '   */

	//        '   return 0.0;
	//        '}


	//        '--- CODE BY MANGESH

	//        Try
	//            Return 0.0

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
	//    End Function

	//    Private Function StoreCalculateStdSampDisplayQuantValue(ByVal intSampleType As ClsAAS203.enumSampleType, _
	//                                                            ByRef nCurStd As Method.clsAnalysisStdParameters, _
	//                                                            ByRef nCurSamp As Method.clsAnalysisSampleParameters, _
	//                                                            ByVal dblAbsorbance As Double) As Double
	//        '=====================================================================
	//        ' Procedure Name        : StoreCalculateStdSampDisplayQuantValue
	//        ' Parameters Passed     : enumSampleType, dblAbsorbance 
	//        ' Parameters Affected   : clsAnalysisStdParameters,clsAnalysisSampleParameterss
	//        ' Returns               : double - Corrected Absorbance
	//        ' Purpose               : 
	//        ' Description           : 
	//        ' Assumptions           : 
	//        ' Dependencies          : 
	//        ' Author                : Mangesh Shardul
	//        ' Created               : 17-Jan-2007 03:25 pm
	//        ' Revisions             : 1
	//        '=====================================================================
	//        'char	str[40]="";
	//        'double abs1=0.0;
	//        '  if (nSampType==STD){
	//        '	 if ((*nCurStd)!=NULL){
	//        '		 GetValInString(abs, str, Method->Mode);
	//        '		 SetDlgItemText(hwnd,IDC_QAVABS, str);
	//        '		 if (Method->QuantData->Param.Meas_Mode==INTEGRATE)
	//        '			abs-=BlankAbs;
	//        '		 (*nCurStd)->Data.Abs=abs;
	//        '//		 *nCurStd->Data.Abs = GetResultAccurate(abs, 3);
	//        '		 CheckValidStdAbs();
	//        '		 GetValInString(abs, str, Method->Mode);
	//        '		 SetDlgItemText(hwnd,IDC_QCORABS, str);
	//        '		 StoreResultAccurate((*nCurStd)->Data.Conc, str,
	//        '			  Method->QuantData->Param.No_Decimals);
	//        '		 SetDlgItemText(hwnd,IDC_QCONC, str);
	//        '		 if (Method->QuantData->Param.Repeat>1 || Method->QuantData->Param.ConcRepeat>1){
	//        '			AddAbsRepeatStd((*nCurStd)->Data.Abs, (*nCurStd)->Data.Conc,(*nCurStd));
	//        '			CalculateAvgOfStd((*nCurStd));
	//        '		  }
	//        '		 if (Method->Mode==MODE_EMISSION)
	//        '			(*nCurStd)->Data.Abs = GetResultAccurate((*nCurStd)->Data.Abs, 1);
	//        '                        Else
	//        '			 (*nCurStd)->Data.Abs = GetResultAccurate((*nCurStd)->Data.Abs, 3);
	//        '	  }
	//        '	}
	//        '  else if (nSampType==SAMP){
	//        '	 if (*nCurSamp!=NULL){
	//        '		 GetValInString(abs, str, Method->Mode);
	//        '		 SetDlgItemText(hwnd,IDC_QAVABS, str);
	//        '		 if (Method->QuantData->Param.Meas_Mode==INTEGRATE)
	//        '			abs-=BlankAbs;
	//        '		 (*nCurSamp)->Data.Abs=abs; // GetResultAccurate(abs, 3);
	//        '		 abs1 = abs; // added by sss for saving the abs of sample for checking for outoff scale on dt 27/12/2000
	//        '		 GetValInString(abs, str, Method->Mode);
	//        '		 SetDlgItemText(hwnd,IDC_QCORABS, str);
	//        '		 (*nCurSamp)->Data.Conc = Get_Conc((*nCurSamp)->Data.Abs, 0.0);
	//        '		 if ((*nCurSamp)->Data.Conc>=0 && (*nCurSamp)->Data.Abs>-0.1)
	//        '			(*nCurSamp)->Data.Used=TRUE;

	//        '		 if (Method->QuantData->Param.Repeat>1 || Method->QuantData->Param.ConcRepeat>1){
	//        '			AddAbsRepeatSamp((*nCurSamp)->Data.Abs, (*nCurSamp)->Data.Conc, (*nCurSamp));
	//        '			CalculateAvgOfSamp((*nCurSamp));
	//        '		  }
	//        '		 if (Method->Mode==MODE_EMISSION)
	//        '			(*nCurSamp)->Data.Abs = GetResultAccurate((*nCurSamp)->Data.Abs, 1);
	//        '                                            Else
	//        '			(*nCurSamp)->Data.Abs = GetResultAccurate((*nCurSamp)->Data.Abs, 3);
	//        '		 StoreResultAccurate((*nCurSamp)->Data.Conc, str,
	//        '			  Method->QuantData->Param.No_Decimals);
	//        '		 strcat(str, "   ppm");
	//        '		 SetDlgItemText(hwnd,IDC_QCONC, str);
	//        '	 }
	//        '	}
	//        '	return abs1;


	//        '--- CODE BY MANGESH

	//        Dim dblCorrectedAbsorbance As Double

	//        Try
	//            Select Case intSampleType
	//                Case ClsAAS203.enumSampleType.STANDARD

	//                    If Not IsNothing(nCurStd) Then
	//                        'Saurabh 05 June 2007
	//                        'lblAverageAbsorbance.Text = FormatNumber(abs, gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfDecimalPlaces)
	//                        'lblAverageAbsorbance.Text = FormatNumber(dblAbsorbance, 3) 'Commented & Added by Saurabh
	//                        If gobjNewMethod.OperationMode = EnumOperationMode.MODE_EMMISSION Then
	//                            'lblAverageAbsorbance.Text = FormatNumber(dblAbsorbance, 1)
	//                        Else
	//                            'lblAverageAbsorbance.Text = FormatNumber(dblAbsorbance, 3)
	//                        End If
	//                        'Saurabh 05 June 2007

	//                        If (gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.MeasurementMode = enumMeasurementMode.Integrate) Then
	//                            dblAbsorbance -= mdblBlankAbsorbance
	//                        End If

	//                        nCurStd.Abs = dblAbsorbance
	//                        Call CheckValidStdAbs()
	//                        'Saurabh 05 June 2007
	//                        'lblCorrectedAbsorbance.Text = FormatNumber(dblAbsorbance, gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfDecimalPlaces)
	//                        'lblCorrectedAbsorbance.Text = FormatNumber(dblAbsorbance, 3)      'Commented & Added by Saurabh
	//                        If gobjNewMethod.OperationMode = EnumOperationMode.MODE_EMMISSION Then
	//                            'lblCorrectedAbsorbance.Text = FormatNumber(dblAbsorbance, 1)
	//                        Else
	//                            'lblCorrectedAbsorbance.Text = FormatNumber(dblAbsorbance, 3)
	//                        End If
	//                        'Saurabh 05 June 2007

	//                        '---Store Result Accurate upto AnalysisParameters.NumOfDecimalPlaces
	//                        'lblConcentration.Text = FormatNumber(nCurStd.Concentration, gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfDecimalPlaces)

	//                        If (gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfStdRepeats > 1 Or _
	//                            gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfSampleRepeats > 1) Then

	//                            Call AddAbsRepeatStd(nCurStd.Abs, nCurStd.Concentration, nCurStd.AbsRepeat)
	//                            Call CalculateAvgOfStd(nCurStd)
	//                        End If

	//                        If (gobjNewMethod.OperationMode = EnumOperationMode.MODE_EMMISSION) Then
	//                            ' nCurStd.Abs = FormatNumber(nCurStd.Abs, 1)
	//                        Else
	//                            'nCurStd.Abs = FormatNumber(nCurStd.Abs, 3)
	//                        End If
	//                    End If

	//                Case ClsAAS203.enumSampleType.SAMPLE

	//                    If Not IsNothing(nCurSamp) Then

	//                        'Saurabh 05 June 2007
	//                        'lblAverageAbsorbance.Text = FormatNumber(abs, gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfDecimalPlaces)
	//                        'lblAverageAbsorbance.Text = FormatNumber(dblAbsorbance, 3)     'Commented & Added by Saurabh
	//                        If gobjNewMethod.OperationMode = EnumOperationMode.MODE_EMMISSION Then
	//                            'lblAverageAbsorbance.Text = FormatNumber(dblAbsorbance, 1)
	//                        Else
	//                            'lblAverageAbsorbance.Text = FormatNumber(dblAbsorbance, 3)
	//                        End If
	//                        'Saurabh 05 June 2007

	//                        If (gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.MeasurementMode = enumMeasurementMode.Integrate) Then
	//                            dblAbsorbance -= mdblBlankAbsorbance
	//                        End If

	//                        nCurSamp.Abs = dblAbsorbance
	//                        dblCorrectedAbsorbance = FormatNumber(dblAbsorbance, gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfDecimalPlaces)

	//                        'Saurabh 05 June 2007
	//                        'lblCorrectedAbsorbance.Text = FormatNumber(dblAbsorbance, gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfDecimalPlaces)
	//                        'lblCorrectedAbsorbance.Text = FormatNumber(dblAbsorbance, 3)    'Commented & Added by Saurabh 01.08.07
	//                        If gobjNewMethod.OperationMode = EnumOperationMode.MODE_EMMISSION Then
	//                            'lblCorrectedAbsorbance.Text = FormatNumber(dblAbsorbance, 1)
	//                        Else
	//                            'lblCorrectedAbsorbance.Text = FormatNumber(dblAbsorbance, 3)
	//                        End If
	//                        'Saurabh 05 June 2007

	//                        nCurSamp.Conc = gobjclsStandardGraph.Get_Conc(nCurSamp.Abs, 0.0)

	//                        If (nCurSamp.Conc >= 0 And nCurSamp.Abs > -0.1) Then
	//                            nCurSamp.Used = True
	//                        End If

	//                        'if (Method->QuantData->Param.Repeat>1 || Method->QuantData->Param.ConcRepeat>1){
	//                        If (gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfStdRepeats > 1 Or gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfSampleRepeats > 1) Then
	//                            Call AddAbsRepeatSamp(nCurSamp.Abs, nCurSamp.Conc, nCurSamp.AbsRepeat)
	//                            Call CalculateAvgOfSamp(nCurSamp)
	//                        End If

	//                        If (gobjNewMethod.OperationMode = EnumOperationMode.MODE_EMMISSION) Then
	//                            'nCurSamp.Abs = FormatNumber(nCurSamp.Abs, 1)
	//                        Else
	//                            'nCurSamp.Abs = FormatNumber(nCurSamp.Abs, 3)
	//                        End If

	//                        'lblConcentration.Text = FormatNumber(nCurSamp.Conc, gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfDecimalPlaces) & "  ppm"

	//                    End If

	//            End Select

	//            Return dblCorrectedAbsorbance

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
	//    End Function

	//    Private Sub AddAbsRepeatStd(ByVal dblAbsorbance As Double, ByVal dblConcentration As Double, _
	//                                ByRef objAbsRepeat As Method.clsAbsRepeat)
	//        '=====================================================================
	//        ' Procedure Name        : AddAbsRepeatStd
	//        ' Parameters Passed     : dblAbsorbance,dblConcentration
	//        ' Parameters affected   : Method.clsAbsRepeat
	//        ' Returns               : None
	//        ' Purpose               : Add Repeat Abs data into Standard parameter object
	//        ' Description           : 
	//        ' Assumptions           : 
	//        ' Dependencies          : 
	//        ' Author                : Mangesh Shardul
	//        ' Created               : 17-Jan-2007 03:25 pm
	//        ' Revisions             : 1
	//        '=====================================================================
	//        'void	  S4FUNC	AddAbsRepeatStd(double data, double conc, STDDATA *cur)
	//        '{
	//        ' if (cur==NULL)
	//        '	return;
	//        ' data = GetResultAccurate(data,3);
	//        ' conc =  GetResultAccurate(conc,Method->QuantData->Param.No_Decimals);

	//        ' if (cur->Data.AbsRepeat==NULL){
	//        '	cur->Data.AbsRepeat = (ABSREPEAT *) malloc(sizeof(ABSREPEAT));
	//        '	InitAbsRepeat(cur->Data.AbsRepeat);
	//        '  }
	//        ' AddAbsRepeatData(data, conc, &(cur->Data.AbsRepeat->RptDataTop));
	//        '}

	//        '--- CODE BY MANGESH 

	//        Try
	//            ''dblAbsorbance = Math.Round(dblAbsorbance, 3)
	//            ''dblConcentration = Math.Round(dblConcentration, gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfDecimalPlaces)

	//            Call InitAbsRepeat(objAbsRepeat)

	//            Call AddAbsRepeatData(dblAbsorbance, dblConcentration, objAbsRepeat.AbsRepeatData)

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

	//    Private Sub AddAbsRepeatSamp(ByVal dblAbsorbance As Double, ByVal dblConcentration As Double, _
	//                                 ByRef objAbsRepeat As Method.clsAbsRepeat)
	//        '=====================================================================
	//        ' Procedure Name        : AddAbsRepeatSamp
	//        ' Parameters Passed     : dblAbsorbance, dblConcentration  as double
	//        ' Parameters Affected   : Method.clsAbsRepeat 
	//        ' Returns               : None
	//        ' Purpose               : Add Repeat Abs data into Sample parameter object
	//        ' Description           : 
	//        ' Assumptions           : 
	//        ' Dependencies          : 
	//        ' Author                : Mangesh Shardul
	//        ' Created               : 17-Jan-2007 03:25 pm
	//        ' Revisions             : 1
	//        '=====================================================================
	//        '{
	//        ' if (cur==NULL)
	//        '	return;
	//        ' data = GetResultAccurate(data,3);
	//        ' conc =  GetResultAccurate(conc,Method->QuantData->Param.No_Decimals);
	//        ' if (cur->Data.AbsRepeat==NULL){
	//        '	cur->Data.AbsRepeat = (ABSREPEAT *) malloc(sizeof(ABSREPEAT));
	//        '	InitAbsRepeat(cur->Data.AbsRepeat);
	//        '  }
	//        ' AddAbsRepeatData(data, conc, &(cur->Data.AbsRepeat->RptDataTop));
	//        '}

	//        '--- CODE BY MANGESH 

	//        Try
	//            'dblAbsorbance = Math.Round(dblAbsorbance, 3)
	//            'dblConcentration = Math.Round(dblConcentration, gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfDecimalPlaces)
	//            ' Add Sample Repeat data 
	//            Call InitAbsRepeat(objAbsRepeat)
	//            Call AddAbsRepeatData(dblAbsorbance, dblConcentration, objAbsRepeat.AbsRepeatData)

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

	//    Private Sub InitAbsRepeat(ByRef AbsRpt As Method.clsAbsRepeat)
	//        '=====================================================================
	//        ' Procedure Name        : InitAbsRepeat
	//        ' Parameters Passed     : Method.clsAbsRepeat
	//        ' Returns               : None
	//        ' Purpose               : 
	//        ' Description           : 
	//        ' Assumptions           : 
	//        ' Dependencies          : 
	//        ' Author                : Mangesh Shardul
	//        ' Created               : 17-Jan-2007 03:25 pm
	//        ' Revisions             : 1
	//        '=====================================================================
	//        'void(InitAbsRepeat(ABSREPEAT * AbsRpt))
	//        '{
	//        '   if (AbsRpt==NULL)
	//        '	    return;
	//        '   AbsRpt->RptDataTop=NULL;
	//        '   AbsRpt->Data.TotData[0]=AbsRpt->Data.TotData[1]=(double)0.0;
	//        '   AbsRpt->Data.Zavg[0]=AbsRpt->Data.Zavg[1] =(double)0.0;
	//        '   AbsRpt->Data.CV[0]=AbsRpt->Data.CV[1] =(double)0.0;
	//        '   AbsRpt->Data.Zsigma[0]=AbsRpt->Data.Zsigma[1] =(double)0.0;
	//        '   AbsRpt->Data.Var[0]=AbsRpt->Data.Var[1] =(double)0.0;
	//        '   AbsRpt->Data.Min[0]=AbsRpt->Data.Min[1] =(double)0.0;
	//        '   AbsRpt->Data.Max[0]=AbsRpt->Data.Max[1] =(double)0.0;
	//        '}

	//        '--- CODE BY MANGESH 

	//        Try
	//            '--- Init Repeat data object
	//            If IsNothing(AbsRpt) Then
	//                AbsRpt = New Method.clsAbsRepeat

	//                AbsRpt.AbsRepeatData = Nothing

	//                AbsRpt.BasicStat.TotData(0) = 0.0
	//                AbsRpt.BasicStat.TotData(1) = 0.0

	//                AbsRpt.BasicStat.ZAvg(0) = 0.0
	//                AbsRpt.BasicStat.ZAvg(1) = 0.0

	//                AbsRpt.BasicStat.CV(0) = 0.0
	//                AbsRpt.BasicStat.CV(1) = 0.0

	//                AbsRpt.BasicStat.ZSigma(0) = 0.0
	//                AbsRpt.BasicStat.ZSigma(1) = 0.0

	//                AbsRpt.BasicStat.Var(0) = 0.0
	//                AbsRpt.BasicStat.Var(1) = 0.0

	//                AbsRpt.BasicStat.Min(0) = 0.0
	//                AbsRpt.BasicStat.Min(1) = 0.0

	//                AbsRpt.BasicStat.Max(0) = 0.0
	//                AbsRpt.BasicStat.Max(1) = 0.0

	//            End If

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

	//    Private Sub AddAbsRepeatData(ByVal dblAbsorbance As Double, ByVal dblConcentration As Double, _
	//                                 ByRef objAbsRepeatDataCollection As Method.clsAbsRepeatDataCollection)
	//        '=====================================================================
	//        ' Procedure Name        : AddAbsRepeatData
	//        ' Parameters Passed     : dblAbsorbance,dblConcentration 
	//        ' Parameter Affected    : Method.clsAbsRepeatDataCollection
	//        ' Returns               : None
	//        ' Purpose               : 
	//        ' Description           : 
	//        ' Assumptions           : 
	//        ' Dependencies          : 
	//        ' Author                : Mangesh Shardul
	//        ' Created               : 17-Jan-2007 03:25 pm
	//        ' Revisions             : 1
	//        '=====================================================================
	//        '{
	//        'ABSREPEATDATA  *tempk=NULL;
	//        'ABSREPEATDATA  *cur=NULL;

	//        ' tempk = (ABSREPEATDATA*) malloc(sizeof(ABSREPEATDATA));
	//        ' if (tempk !=NULL){
	//        '  cur = GoAbsRepeatBottom(*Top);
	//        '  tempk->Abs=abs;
	//        '  tempk->Conc=conc;
	//        '  tempk->next=NULL;
	//        '  If (cur! = NULL) Then
	//        '    tempk->next=cur->next;
	//        '  if (*Top==NULL)
	//        '	 *Top= tempk;
	//        '  Else
	//        '    cur->next=tempk;
	//        '  cur = tempk;
	//        ' }
	//        '}

	//        '---CODE BY MANGESH

	//        Dim objAbsRepeatData As Method.clsAbsRepeatData

	//        Try
	//            ' Add Repeat Analysis data into object
	//            objAbsRepeatData = New Method.clsAbsRepeatData
	//            objAbsRepeatData.Abs = dblAbsorbance
	//            objAbsRepeatData.Concentration = dblConcentration
	//            objAbsRepeatData.Used = True
	//            '--- Add Repeat data object into collection
	//            If Not IsNothing(objAbsRepeatDataCollection) Then
	//                objAbsRepeatDataCollection.Add(objAbsRepeatData)
	//            Else
	//                objAbsRepeatDataCollection = New Method.clsAbsRepeatDataCollection
	//                objAbsRepeatDataCollection.Add(objAbsRepeatData)
	//            End If

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

	//    Private Sub CalculateAvgOfStd(ByRef objStandard As Method.clsAnalysisStdParameters)
	//        '=====================================================================
	//        ' Procedure Name        : CalculateAvgOfStd 
	//        ' Parameters Passed     : Reference to the clsAnalysisStdParameters
	//        ' Returns               : None
	//        ' Purpose               : 
	//        ' Description           : 
	//        ' Assumptions           : 
	//        ' Dependencies          : 
	//        ' Author                : Mangesh Shardul
	//        ' Created               : 17-Jan-2007 03:25 pm
	//        ' Revisions             : 1
	//        '=====================================================================
	//        '{
	//        ' if (mobjCurrentStandard==NULL || mobjCurrentStandard->Data.AbsRepeat==NULL)
	//        '	return;
	//        ' CalculateBasicStats(mobjCurrentStandard->Data.AbsRepeat);
	//        ' mobjCurrentStandard->Data.Abs = mobjCurrentStandard->Data.AbsRepeat->Data.Zavg[0];
	//        '}

	//        '---CODE BY MANGESH

	//        Try
	//            If IsNothing(objStandard) Or IsNothing(objStandard.AbsRepeat) Then
	//                Return
	//            End If
	//            '--- Set Avg. of Abs of Standard
	//            If clsBasicStatistics.CalculateBasicStats(objStandard.AbsRepeat) Then
	//                objStandard.Abs = objStandard.AbsRepeat.BasicStat.ZAvg(0)
	//            End If

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

	//    Private Sub CalculateAvgOfSamp(ByRef objSample As Method.clsAnalysisSampleParameters)
	//        '=====================================================================
	//        ' Procedure Name        : CalculateAvgOfSamp
	//        ' Parameters Passed     : Reference of clsAnalysisSampleParameters object
	//        ' Returns               : None
	//        ' Purpose               : 
	//        ' Description           : 
	//        ' Assumptions           : 
	//        ' Dependencies          : 
	//        ' Author                : Mangesh Shardul
	//        ' Created               : 17-Jan-2007 03:25 pm
	//        ' Revisions             : 1
	//        '=====================================================================
	//        'void S4FUNC CalculateAvgOfSamp(SAMPDATA *mobjCurrentSample)
	//        '{
	//        '   if (mobjCurrentSample==NULL || mobjCurrentSample->Data.AbsRepeat==NULL)
	//        '	    return;
	//        '   CalculateBasicStats(mobjCurrentSample->Data.AbsRepeat);
	//        '   mobjCurrentSample->Data.Abs = mobjCurrentSample->Data.AbsRepeat->Data.Zavg[0];
	//        '}

	//        '---CODE BY MANGESH

	//        Try
	//            If IsNothing(objSample) Or IsNothing(objSample.AbsRepeat) Then
	//                Return
	//            End If
	//            '--- Set Avg value of abs
	//            If clsBasicStatistics.CalculateBasicStats(objSample.AbsRepeat) Then
	//                objSample.Abs = objSample.AbsRepeat.BasicStat.ZAvg(0)
	//            End If

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

	//    Private Function GetPrevStd(ByVal objStandardsCollection As Method.clsAnalysisStdParametersCollection, _
	//                                ByVal objCurrentStandard As Method.clsAnalysisStdParameters) As Method.clsAnalysisStdParameters
	//        '=====================================================================
	//        ' Procedure Name        : GetPrevStd
	//        ' Parameters Passed     : StandardDataCollection and Current Standard
	//        ' Returns               : Previous Standard
	//        ' Purpose               : 
	//        ' Description           : 
	//        ' Assumptions           : 
	//        ' Dependencies          : 
	//        ' Author                : Mangesh Shardul
	//        ' Created               : 17-Jan-2007 03:25 pm
	//        ' Revisions             : 1
	//        '=====================================================================

	//        '--- ORIGINAL 16-bit CODE

	//        'STDDATA *S4FUNC GetPrevStd(STDDATA *StdTop, STDDATA *CurStd)
	//        '{
	//        '   STDDATA	*tempk=NULL;
	//        '   tempk = StdTop;
	//        '   if (CurStd == StdTop)
	//        '	    return tempk;
	//        '   while(tempk!=NULL)
	//        '   {
	//        '	    if (tempk->next==CurStd)
	//        '	        break;
	//        '       tempk=tempk->next;
	//        '   }
	//        '   return tempk;
	//        '}
	//        '***************************************************************
	//        Dim intCounter As Integer

	//        Try
	//            If mobjLastStandardData Is mobjCurrentStandard Then
	//                Return objCurrentStandard
	//            End If

	//            '--- Returns the Previous Standard from Standard Collection.
	//            For intCounter = 0 To objStandardsCollection.Count - 1
	//                If objStandardsCollection.item(intCounter) Is objCurrentStandard Then
	//                    Exit For
	//                End If
	//            Next intCounter

	//            '//----- Commented by Sachin Dokhale on 31.07.07
	//            'If intCounter = 0 Then
	//            '    Return objStandardsCollection.item(0).Clone()
	//            'Else
	//            '    Return objStandardsCollection.item(intCounter - 1).Clone()
	//            'End If
	//            '//----- Added by Sachin Dokhale on 31.07.07
	//            If intCounter = 0 Then
	//                intIEnumCollLocationStd = 1
	//                Return objStandardsCollection.item(0)
	//            Else
	//                intIEnumCollLocationStd -= 1
	//                Return objStandardsCollection.item(intCounter - 1)

	//            End If
	//            '//-----
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
	//    End Function

	//    Private Function GetPrevSamp(ByVal objSamplesCollection As Method.clsAnalysisSampleParametersCollection, _
	//                                 ByVal objCurrentSample As Method.clsAnalysisSampleParameters) As Method.clsAnalysisSampleParameters
	//        '=====================================================================
	//        ' Procedure Name        : GetPrevSamp
	//        ' Parameters Passed     : SampleDataCollection and Current Sample
	//        ' Returns               : Previous Sample parameter
	//        ' Purpose               : return previous sample from sample collection object
	//        ' Description           : 
	//        ' Assumptions           : 
	//        ' Dependencies          : 
	//        ' Author                : Mangesh Shardul
	//        ' Created               : 17-Jan-2007 03:25 pm
	//        ' Revisions             : 1
	//        '=====================================================================

	//        '--- ORIGINAL 16-bit CODE

	//        'SAMPDATA	*S4FUNC GetPrevSamp(SAMPDATA *SampTop, SAMPDATA *CurSamp)
	//        '{
	//        '   SAMPDATA	*tempk=NULL;
	//        '   tempk =  SampTop;
	//        '   if (CurSamp==SampTop)
	//        '	    return tempk;
	//        '   while(tempk!=NULL)
	//        '   {
	//        '	    if (tempk->next==CurSamp)
	//        '		    break;
	//        '	    tempk=tempk->next;
	//        '   }
	//        '   return tempk;
	//        '}
	//        '***************************************************************
	//        Dim intCounter As Integer

	//        Try

	//            If mobjLastSampleData Is objCurrentSample Then
	//                Return objCurrentSample
	//            End If
	//            ' Set previous sample from sample collection object
	//            For intCounter = 0 To objSamplesCollection.Count - 1
	//                If objSamplesCollection.item(intCounter) Is objCurrentSample Then
	//                    Exit For
	//                End If
	//            Next intCounter
	//            '//----- Commented by Sachin Dokhale on 31.07.07
	//            '---Returns the Previous Sample from Sample Collection.
	//            'If intCounter = 0 Then
	//            '    Return objSamplesCollection.item(0).Clone()
	//            'Else
	//            '    Return objSamplesCollection.item(intCounter - 1).Clone()
	//            'End If
	//            '//----- Added by Sachin Dokhale on 31.07.07
	//            If mblnRepeatLastSample = False Then
	//                If intCounter = 0 Then
	//                    intIEnumCollLocationStd = 1
	//                    Return objSamplesCollection.item(0)
	//                Else
	//                    intIEnumCollLocationStd -= 1
	//                    Return objSamplesCollection.item(intCounter - 1)
	//                End If
	//            Else

	//            End If
	//            '//-----


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
	//    End Function

	//    Private Function OnViewResults() As Boolean
	//        '=====================================================================
	//        ' Procedure Name        : OnViewResults
	//        ' Parameters Passed     : None
	//        ' Returns               : True if success or False Quantitative Data Collection is Nothing
	//        ' Purpose               : 
	//        ' Description           : 
	//        ' Assumptions           : 
	//        ' Dependencies          : 
	//        ' Author                : Mangesh Shardul
	//        ' Created               : 01-Feb-2007 07:50 pm
	//        ' Revisions             : 1
	//        '=====================================================================


	//        '---- ORIGINAL CODE

	//        'void	OnViewResults(HWND hpar)
	//        '{
	//        '   DLGPROC  skp1;
	//        '	if (Method->QuantData==NULL)
	//        '	    return;
	//        '	if (GetTotStds(Method->QuantData->StdTopData, TRUE)>0)
	//        '	{
	//        '		skp1 =(DLGPROC) MakeProcInstance((DLGPROC) ViewResultsProc,hInst);
	//        '		DialogBox(hInst,"SHOWRESULTS", hpar, skp1);
	//        '		FreeProcInstance(skp1);
	//        '	}
	//        '   Else
	//        '	    Gerror_message_new("No Standards", "STANDARD CURVE");
	//        '}
	//        '*********************************************************
	//        Dim objfrmViewResults As frmViewResults

	//        Try
	//            'DLGPROC  skp1;
	//            'if (Method->QuantData==NULL)
	//            '   return;
	//            'end if
	//            If IsNothing(gobjNewMethod.QuantitativeDataCollection) Then
	//                Return False
	//            End If
	//            'Display Result of quant. analysis in viewlist
	//            If (clsStandardGraph.GetTotStds(gobjNewMethod.QuantitativeDataCollection(mintRunNumberIndex).StandardDataCollection, True) > 0) Then
	//                'skp1 =(DLGPROC) MakeProcInstance((DLGPROC) ViewResultsProc,hInst);
	//                'DialogBox(hInst,"SHOWRESULTS", hpar, skp1);
	//                'FreeProcInstance(skp1);
	//                objfrmViewResults = New frmViewResults(True, 0, 0, gobjNewMethod)
	//                objfrmViewResults.ShowDialog()
	//                Application.DoEvents()
	//                objfrmViewResults.Close()
	//                objfrmViewResults.Dispose()
	//                objfrmViewResults = Nothing
	//            Else
	//                Call gobjMessageAdapter.ShowMessage(constNoStandards)
	//                Call Application.DoEvents()
	//            End If

	//            Return True

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
	//    End Function

	//    Private Sub StoreCalculateDisplayQuantValueUvMode(ByVal dblAbsorbance As Double)
	//        '=====================================================================
	//        ' Procedure Name        : StoreCalculateDisplayQuantValueUvMode
	//        ' Parameters Passed     : Absorbance value in UV mode
	//        ' Returns               : None
	//        ' Purpose               : To store, calculate and Display Quantitative
	//        '                         value in UV Mode
	//        ' Description           : 
	//        ' Assumptions           : 
	//        ' Dependencies          : 
	//        ' Author                : Mangesh Shardul
	//        ' Created               : 23-Apr-2007 11:45 pm
	//        ' Revisions             : 1
	//        '=====================================================================

	//        '---- ORIGINAL CODE

	//        'void	StoreCalculateDisplayQuantValueUvMode(HWND hwnd, double abs)
	//        '{
	//        '	char	str[40]="";
	//        '	abs = GetValConvertedTo(abs, Method->Mode);
	//        '	if (SampType==BLANK)
	//        '	{
	//        '	  BlankAbs=abs;
	//        '	}
	//        '	else if (SampType==STD)
	//        '	{
	//        '		if (CurStd!=NULL){
	//        '			CurStd->Data.Abs=abs;
	//        '			GetValInString(abs, str, Method->Mode);
	//        '			SetDlgItemText(hwnd,IDC_QAVABS, str);
	//        '			CheckValidStdAbs();
	//        '			GetValInString(abs, str, Method->Mode);
	//        '			SetDlgItemText(hwnd,IDC_QCORABS, str);
	//        '			StoreResultAccurate(CurStd->Data.Conc, str, Method->QuantData->Param.No_Decimals);
	//        '			SetDlgItemText(hwnd,IDC_QCONC, str);
	//        '			CurStd->Data.Abs = GetResultAccurate(CurStd->Data.Abs, 3);
	//        '		}
	//        '	}
	//        '	else if (SampType==SAMP)
	//        '	{
	//        '       If (CurSamp! = NULL) Then
	//        '		{
	//        '			GetValInString(abs, str, Method->Mode);
	//        '			SetDlgItemText(hwnd,IDC_QAVABS, str);
	//        '			CurSamp->Data.Abs=abs;
	//        '			GetValInString(abs, str, Method->Mode);
	//        '			SetDlgItemText(hwnd,IDC_QCORABS, str);
	//        '			CurSamp->Data.Conc = Get_Conc(CurSamp->Data.Abs, 0.0);
	//        '			if (CurSamp->Data.Conc>0 && CurSamp->Data.Abs>-0.1)
	//        '				CurSamp->Data.Used=TRUE;
	//        '			CurSamp->Data.Abs = GetResultAccurate(CurSamp->Data.Abs, 3);
	//        '			StoreResultAccurate(CurSamp->Data.Conc, str, Method->QuantData->Param.No_Decimals);
	//        '			strcat(str, "   ppm");
	//        '			SetDlgItemText(hwnd,IDC_QCONC, str);
	//        '		}
	//        '	}
	//        '}
	//        '******************************************************************
	//        'char	str[40]="";
	//        Try
	//            'Calculate and display of Quant. data for UV mode
	//            'dblAbsorbance = gfuncGetValConvertedTo(dblAbsorbance, Method.Mode)

	//            'Display data of Blank/Std./Sample type
	//            If (SampleType = ClsAAS203.enumSampleType.BLANK) Then
	//                mdblBlankAbsorbance = dblAbsorbance
	//            ElseIf (SampleType = ClsAAS203.enumSampleType.STANDARD) Then
	//                If Not IsNothing(mobjCurrentStandard) Then
	//                    'CurStd->Data.Abs=abs;
	//                    mobjCurrentStandard.Abs = dblAbsorbance

	//                    'GetValInString(abs, str, Method->Mode);
	//                    'SetDlgItemText(hwnd,IDC_QAVABS, str);

	//                    'Saurabh 05 June 2007
	//                    If gobjNewMethod.OperationMode = EnumOperationMode.MODE_EMMISSION Then
	//                        'lblAverageAbsorbance.Text = FormatNumber(dblAbsorbance, 1)
	//                    Else
	//                        'lblAverageAbsorbance.Text = FormatNumber(dblAbsorbance, 3)
	//                    End If
	//                    'Saurabh 05 June 2007

	//                    ' validate the data of std. (ABS)
	//                    Call CheckValidStdAbs()

	//                    'GetValInString(abs, str, Method->Mode);
	//                    'SetDlgItemText(hwnd,IDC_QCORABS, str);

	//                    'Saurabh 05 June 2007
	//                    If gobjNewMethod.OperationMode = EnumOperationMode.MODE_EMMISSION Then
	//                        'lblCorrectedAbsorbance.Text = FormatNumber(dblAbsorbance, 1)
	//                    Else
	//                        'lblCorrectedAbsorbance.Text = FormatNumber(dblAbsorbance, 3)
	//                    End If
	//                    'Saurabh 05 June 2007

	//                    'StoreResultAccurate(CurStd->Data.Conc, str, Method->QuantData->Param.No_Decimals);
	//                    'SetDlgItemText(hwnd,IDC_QCONC, str);
	//                    'Saurabh To format the concentration value upto 2 decimal places 20.07.07
	//                    'lblConcentration.Text = FormatNumber(mobjCurrentStandard.Concentration, 2)
	//                    'CurStd->Data.Abs = GetResultAccurate(CurStd->Data.Abs, 3);
	//                    mobjLastStandardData = mobjCurrentStandard
	//                Else
	//                    mobjLastStandardData = Nothing
	//                End If

	//            ElseIf (SampleType = ClsAAS203.enumSampleType.SAMPLE) Then
	//                If Not IsNothing(mobjCurrentSample) Then
	//                    'GetValInString(abs, str, Method->Mode);
	//                    'SetDlgItemText(hwnd,IDC_QAVABS, str);

	//                    'Saurabh 05 June 2007
	//                    If gobjNewMethod.OperationMode = EnumOperationMode.MODE_EMMISSION Then
	//                        'lblAverageAbsorbance.Text = FormatNumber(dblAbsorbance, 1)
	//                    Else
	//                        'lblAverageAbsorbance.Text = FormatNumber(dblAbsorbance, 3)
	//                    End If
	//                    'Saurabh 05 June 2007

	//                    'CurSamp->Data.Abs=abs;
	//                    mobjCurrentSample.Abs = dblAbsorbance

	//                    'GetValInString(abs, str, Method->Mode);
	//                    'SetDlgItemText(hwnd,IDC_QCORABS, str);

	//                    'Saurabh 05 June 2007
	//                    If gobjNewMethod.OperationMode = EnumOperationMode.MODE_EMMISSION Then
	//                        'lblCorrectedAbsorbance.Text = FormatNumber(dblAbsorbance, 1)
	//                    Else
	//                        'lblCorrectedAbsorbance.Text = FormatNumber(dblAbsorbance, 3)
	//                    End If
	//                    'Saurabh 05 June 2007

	//                    'CurSamp->Data.Conc = Get_Conc(CurSamp->Data.Abs, 0.0);
	//                    mobjCurrentSample.Conc = gobjclsStandardGraph.Get_Conc(mobjCurrentSample.Abs, 0.0)

	//                    'if (CurSamp->Data.Conc>0 && CurSamp->Data.Abs>-0.1)
	//                    '	CurSamp->Data.Used=TRUE;
	//                    'end if
	//                    If mobjCurrentSample.Conc > 0 And mobjCurrentSample.Abs > -0.1 Then
	//                        mobjCurrentSample.Used = True
	//                    End If

	//                    'CurSamp->Data.Abs = GetResultAccurate(CurSamp->Data.Abs, 3);

	//                    'StoreResultAccurate(CurSamp->Data.Conc, str, Method->QuantData->Param.No_Decimals);
	//                    'strcat(str, "   ppm");
	//                    'SetDlgItemText(hwnd,IDC_QCONC, str);
	//                    'Saurabh To format the concentration value upto 2 decimal places 20.07.07
	//                    'lblConcentration.Text = FormatNumber(mobjCurrentSample.Conc, 2) & "  ppm"
	//                    mobjLastSampleData = mobjCurrentSample
	//                Else
	//                    mobjLastSampleData = Nothing
	//                End If

	//            End If

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

	//    Friend Function funcRefreshMethodParameter() As Boolean
	//        '=====================================================================
	//        ' Procedure Name        : funcRefreshMethodParameter
	//        ' Parameters Passed     : Nono
	//        ' Returns               : True if success.
	//        ' Purpose               : Reinit. property of Method object
	//        '                         
	//        ' Description           : 
	//        ' Assumptions           : 
	//        ' Dependencies          : 
	//        ' Author                : Sachin Dokhale
	//        ' Created               : Jul 31, 2007 4:00 pm
	//        ' Revisions             : 1
	//        '=====================================================================
	//        Dim intStdsToRemove, intCount, intStdsRemoved, intStdsToAdd As Integer
	//        Try
	//            ' Reinit. property of Method object.
	//            If mblnIsAnalysisStarted = True Then

	//                If Not (gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex) Is Nothing) Then
	//                    If Not gobjNewMethod.AnalysisParameters Is Nothing Then
	//                        gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.IntegrationTime = gobjNewMethod.AnalysisParameters.IntegrationTime
	//                        gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.Unit = gobjNewMethod.AnalysisParameters.Unit
	//                    End If

	//                    '-----23.08.07
	//                    '##### for standard parameters
	//                    If (Not gobjNewMethod.StandardDataCollection Is Nothing) And mblnIsAnalysisStarted = True Then
	//                        'gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection = gobjNewMethod.StandardDataCollection.Clone
	//                        If gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.Count > gobjNewMethod.StandardDataCollection.Count Then
	//                            '---if method std count is less than quantitative std count then
	//                            '---quantitative std which are used should be kept intact
	//                            '---those quantitative std which are not used should be removed.

	//                            intStdsToRemove = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.Count - gobjNewMethod.StandardDataCollection.Count

	//                            For intCount = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.Count - 1 To 0 Step -1
	//                                If intStdsRemoved < intStdsToRemove Then
	//                                    If gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection(intCount).Used = False Then
	//                                        gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.RemoveAt(intCount)
	//                                        intStdsRemoved += 1
	//                                    End If
	//                                Else
	//                                    If gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection(intCount).Used = False Then
	//                                        gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount) = gobjNewMethod.StandardDataCollection.item(intCount).Clone
	//                                    End If
	//                                End If
	//                            Next
	//                            intStdsRemoved = 0

	//                        ElseIf gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.Count = gobjNewMethod.StandardDataCollection.Count Then
	//                            '---if quantitative std count is equal to that of method std count then
	//                            '---update only those std which are not used.
	//                            For intCount = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.Count - 1 To 0 Step -1
	//                                If gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection(intCount).Used = False Then
	//                                    gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount) = gobjNewMethod.StandardDataCollection.item(intCount).Clone
	//                                End If
	//                            Next

	//                        ElseIf gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.Count < gobjNewMethod.StandardDataCollection.Count Then
	//                            '---if method std count is more than quantitative std count then
	//                            '---quantitative std which are used should be kept intact.
	//                            '---update quantitative std from method which are not used.
	//                            '---add extra stds from method to quantitative list.
	//                            '----Added by pankaj on 24 Jan 08
	//                            intStdsToAdd = gobjNewMethod.StandardDataCollection.Count - gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.Count
	//                            For intCount = 0 To gobjNewMethod.StandardDataCollection.Count - 1 Step 1
	//                                If intCount <= gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.Count - 1 Then
	//                                    If gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection(intCount).Used = False Then
	//                                        gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount) = gobjNewMethod.StandardDataCollection.item(intCount).Clone
	//                                    End If
	//                                Else
	//                                    gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.Add(gobjNewMethod.StandardDataCollection.item(intCount).Clone)
	//                                End If
	//                            Next
	//                            '--
	//                        End If
	//                    End If

	//                    ''###########for Sample parameters ##########################################
	//                    ''Added by pankaj on 22 Feb 80
	//                    If (Not gobjNewMethod.SampleDataCollection Is Nothing) And mblnIsAnalysisStarted = True Then
	//                        'gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection = gobjNewMethod.StandardDataCollection.Clone
	//                        If gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.Count > gobjNewMethod.SampleDataCollection.Count Then
	//                            '---if method std count is less than quantitative std count then
	//                            '---quantitative std which are used should be kept intact
	//                            '---those quantitative std which are not used should be removed.

	//                            intStdsToRemove = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.Count - gobjNewMethod.SampleDataCollection.Count

	//                            For intCount = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.Count - 1 To 0 Step -1
	//                                If intStdsRemoved < intStdsToRemove Then
	//                                    If gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection(intCount).Used = False Then
	//                                        gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.RemoveAt(intCount)
	//                                        intStdsRemoved += 1
	//                                    End If
	//                                Else
	//                                    If gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection(intCount).Used = False Then
	//                                        gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCount) = gobjNewMethod.SampleDataCollection.item(intCount).Clone
	//                                    Else
	//                                        gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCount).SampleName = gobjNewMethod.SampleDataCollection.item(intCount).SampleName
	//                                        gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCount).Weight = gobjNewMethod.SampleDataCollection.item(intCount).Weight
	//                                        gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCount).Volume = gobjNewMethod.SampleDataCollection.item(intCount).Volume
	//                                        gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCount).DilutionFactor = gobjNewMethod.SampleDataCollection.item(intCount).DilutionFactor
	//                                    End If
	//                                End If
	//                            Next
	//                            intStdsRemoved = 0

	//                        ElseIf gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.Count = gobjNewMethod.SampleDataCollection.Count Then
	//                            '---if quantitative std count is equal to that of method std count then
	//                            '---update only those std which are not used.
	//                            For intCount = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.Count - 1 To 0 Step -1
	//                                If gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection(intCount).Used = False Then
	//                                    gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCount) = gobjNewMethod.SampleDataCollection.item(intCount).Clone
	//                                Else
	//                                    gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCount).SampleName = gobjNewMethod.SampleDataCollection.item(intCount).SampleName
	//                                    gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCount).Weight = gobjNewMethod.SampleDataCollection.item(intCount).Weight
	//                                    gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCount).Volume = gobjNewMethod.SampleDataCollection.item(intCount).Volume
	//                                    gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCount).DilutionFactor = gobjNewMethod.SampleDataCollection.item(intCount).DilutionFactor
	//                                End If
	//                            Next

	//                        ElseIf gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.Count < gobjNewMethod.SampleDataCollection.Count Then
	//                            '---if method std count is more than quantitative std count then
	//                            '---quantitative std which are used should be kept intact.
	//                            '---update quantitative std from method which are not used.
	//                            '---add extra stds from method to quantitative list.
	//                            '----Added by pankaj on 24 Jan 08
	//                            intStdsToAdd = gobjNewMethod.SampleDataCollection.Count - gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.Count
	//                            For intCount = 0 To gobjNewMethod.SampleDataCollection.Count - 1 Step 1
	//                                If intCount <= gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.Count - 1 Then
	//                                    If gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection(intCount).Used = False Then
	//                                        gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCount) = gobjNewMethod.SampleDataCollection.item(intCount).Clone
	//                                    Else
	//                                        gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCount).SampleName = gobjNewMethod.SampleDataCollection.item(intCount).SampleName
	//                                        gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCount).Weight = gobjNewMethod.SampleDataCollection.item(intCount).Weight
	//                                        gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCount).Volume = gobjNewMethod.SampleDataCollection.item(intCount).Volume
	//                                        gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCount).DilutionFactor = gobjNewMethod.SampleDataCollection.item(intCount).DilutionFactor
	//                                    End If
	//                                Else
	//                                    gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.Add(gobjNewMethod.SampleDataCollection.item(intCount).Clone)
	//                                End If
	//                            Next
	//                            '--
	//                        End If
	//                    End If
	//                    ''------------------------------------------------
	//                    'If Not gobjNewMethod.SampleDataCollection Is Nothing Then
	//                    '    'gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection = gobjNewMethod.SampleDataCollection.Clone
	//                    '    If gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.Count > gobjNewMethod.SampleDataCollection.Count Then
	//                    '        '---if method std count is less than quantitative std count then
	//                    '        '---quantitative std which are used should be kept intact
	//                    '        '---those quantitative std which are not used should be removed.

	//                    '        intStdsToRemove = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.Count - gobjNewMethod.SampleDataCollection.Count

	//                    '        For intCount = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.Count - 1 To 0 Step -1
	//                    '            If intStdsRemoved < intStdsToRemove Then
	//                    '                If gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection(intCount).Used = False Then
	//                    '                    gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.RemoveAt(intCount)
	//                    '                    intStdsRemoved += 1
	//                    '                End If
	//                    '            End If
	//                    '        Next
	//                    '        intStdsRemoved = 0

	//                    '    ElseIf gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.Count = gobjNewMethod.SampleDataCollection.Count Then
	//                    '        '---if quantitative std count is equal to that of method std count then
	//                    '        '---update only those std which are not used.
	//                    '        For intCount = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.Count - 1 To 0 Step -1
	//                    '            If gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection(intCount).Used = False Then
	//                    '                gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCount) = gobjNewMethod.SampleDataCollection.item(intCount).Clone
	//                    '            End If
	//                    '        Next

	//                    '    ElseIf gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.Count < gobjNewMethod.SampleDataCollection.Count Then
	//                    '        '---if method std count is more than quantitative std count then
	//                    '        '---quantitative std which are used should be kept intact.
	//                    '        '---update quantitative std from method which are not used.
	//                    '        '---add extra stds from method to quantitative list.
	//                    '        intStdsToAdd = gobjNewMethod.SampleDataCollection.Count - gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.Count
	//                    '        For intCount = 0 To gobjNewMethod.SampleDataCollection.Count - 1 Step 1
	//                    '            If intCount <= gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.Count - 1 Then
	//                    '                If gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection(intCount).Used = False Then
	//                    '                    gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCount) = gobjNewMethod.SampleDataCollection.item(intCount).Clone
	//                    '                End If
	//                    '            Else
	//                    '                gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.Add(gobjNewMethod.SampleDataCollection.item(intCount).Clone)
	//                    '            End If
	//                    '        Next
	//                    '    End If
	//                    'End If

	//                    If Not gobjNewMethod.AnalysisParameters Is Nothing Then
	//                        'gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters = gobjNewMethod.AnalysisParameters.Clone
	//                        '---24.01.08
	//                        gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfSampleRepeats = gobjNewMethod.AnalysisParameters.NumOfSampleRepeats
	//                        gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfStdRepeats = gobjNewMethod.AnalysisParameters.NumOfStdRepeats
	//                        '---24.01.08
	//                    End If
	//                    '-----23.08.07

	//                    Call funcRefreshEnumerators(mobjStandardEnumerator, mobjSampleEnumerator)

	//                    '--- Set Enumerator Analysis sample Parameters
	//                    If mblnRepeatLastSample = False Then
	//                        If intIEnumCollLocationSamp > gobjNewMethod.SampleDataCollection.Count Then
	//                            intIEnumCollLocationSamp = gobjNewMethod.SampleDataCollection.Count + 1
	//                        End If
	//                        If funcMoveSampleEnumerator(mobjSampleEnumerator, intIEnumCollLocationSamp) = True Then
	//                            mobjCurrentSample = CType(mobjSampleEnumerator.Current, Method.clsAnalysisSampleParameters)
	//                        End If
	//                    End If
	//                    '--- Set Enumerator Analysis Standard Parameters
	//                    If mblnRepeatLastStd = False Then
	//                        If intIEnumCollLocationStd > gobjNewMethod.StandardDataCollection.Count Then
	//                            intIEnumCollLocationStd = gobjNewMethod.StandardDataCollection.Count + 1
	//                        End If
	//                        If funcMoveEnumerator(mobjStandardEnumerator, intIEnumCollLocationStd) = True Then
	//                            mobjCurrentStandard = CType(mobjStandardEnumerator.Current, Method.clsAnalysisStdParameters)
	//                        Else
	//                            'If intIEnumCollLocationStd >= gobjNewMethod.StandardDataCollection.Count Then
	//                            '    '--- Start Flame Status window
	//                            '    If gobjMain.mobjController.IsThreadRunning = True Then
	//                            '        gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay)
	//                            '        Application.DoEvents()
	//                            '        Call gobjMain.mobjController.Cancel()
	//                            '    End If
	//                            '    Application.DoEvents()
	//                            '    Call NextAnalysis_Clicked(btnNextAnalysis, EventArgs.Empty)
	//                            '    '--- Start Flame Status window
	//                            '    If gobjMain.mobjController.IsThreadRunning = False Then
	//                            '        gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay)
	//                            '        Application.DoEvents()
	//                            '        Call gobjMain.mobjController.Start(gobjclsBgFlameStatus)
	//                            '    End If
	//                            '    Application.DoEvents()
	//                            'End If
	//                        End If
	//                    End If
	//                End If
	//            End If
	//            'Call funcRefreshEnumerators(mobjStandardEnumerator, mobjSampleEnumerator)
	//            Return True
	//        Catch ex As Exception
	//            '---------------------------------------------------------
	//            'Error Handling and logging
	//            gobjErrorHandler.ErrorDescription = ex.Message
	//            gobjErrorHandler.ErrorMessage = ex.Message
	//            gobjErrorHandler.WriteErrorLog(ex)
	//            Return False
	//            '---------------------------------------------------------
	//        Finally
	//            '---------------------------------------------------------
	//            'Writing Execution log
	//            If CONST_CREATE_EXECUTION_LOG = 1 Then
	//                gobjErrorHandler.WriteExecutionLog()
	//            End If
	//            '---------------------------------------------------------
	//        End Try
	//    End Function

	//#End Region

	//#Region " Public Functions "

	//    Public Sub StartNewAnalysis()
	//        '=====================================================================
	//        ' Procedure Name        : StartNewAnalysis
	//        ' Parameters Passed     : None
	//        ' Returns               : None
	//        ' Purpose               : To Start new analysis
	//        ' Description           : 
	//        ' Assumptions           : 
	//        ' Dependencies          : 
	//        ' Author                : Mangesh Shardul
	//        ' Created               : 20-Feb-2007 03:00 pm
	//        ' Revisions             : 1
	//        '=====================================================================
	//        Dim intValid As Integer

	//        Try
	//            mController = New clsBgThread(Me)
	//            Call mobjBgReadData.Initialize(mController)
	//            '--- Set Aspiration Message
	//            mstrAspirationMessage = "Click Start button to Start Analysis."
	//            mobjBgMsgAspirate.AspirationMessage = mstrAspirationMessage

	//            'gobjclsStandardGraph = New clsStandardGraph
	//            '//----- Added by Sachin Dokhale 
	//            '//--- Previous Standard
	//            If blnIsLoadPreviousStandards = False Then
	//                gobjclsStandardGraph = New clsStandardGraph
	//            Else
	//                If gobjclsStandardGraph Is Nothing Then
	//                    gobjclsStandardGraph = New clsStandardGraph
	//                End If
	//            End If
	//            '//-----
	//            '--- Return Method Status in integer
	//            intValid = CheckMethod()
	//            If (intValid = 2) Then
	//                'Init. analysis parameters
	//                Call InitAnalysis()
	//            End If
	//            mblnIsAnalysisStarted = False
	//            '--- Set parameter for NEw analysis
	//            Call NewAnalysis_Clicked(btnNewAnalysis, EventArgs.Empty)

	//            'btnEditData.Enabled = False

	//            mintAspirationTimerCounter = 0

	//            '//----- Commented by Sachin Dokhale
	//            '//----- use Thread except timer for aspirate message
	//            mobjBgMsgAspirate.Start()
	//            IsDisplayingMessage = mobjBgMsgAspirate.IsMessageRunning

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

	//    Public Sub CheckAnaButtons()
	//        '=====================================================================
	//        ' Procedure Name        : CheckAnaButtons
	//        ' Parameters Passed     : None
	//        ' Returns               : None
	//        ' Purpose               : To set buttons enable/disable, and show the 
	//        '                           messages accordingly.
	//        ' Description           : 
	//        ' Assumptions           : 
	//        ' Dependencies          : 
	//        ' Author                : Mangesh Shardul
	//        ' Created               : 15-Dec-2006
	//        ' Revisions             : 1
	//        '=====================================================================


	//        'AAS 16-Bit Software Code

	//        ''void	CheckAnaButtons(HWND hwnd)
	//        ''{
	//        '' if (Started){
	//        ''	ANALYSIS = TRUE;
	//        ''	SetShortHelp("", FALSE);
	//        ''	SetShortHelp(" Click End Analysis button to Stop the Analysis", TRUE);
	//        ''//	EnableWindow(GetDlgItem(hwnd, IDC_QAREPORT),FALSE);
	//        ''	}
	//        '' else{
	//        ''	SetShortHelp(" Click START button to start Analysis", TRUE);
	//        ''//	EnableWindow(GetDlgItem(hwnd, IDC_QAREPORT),TRUE);
	//        ''	ANALYSIS = FALSE;
	//        ''	}
	//        ''  //---mdf by sk on 29/2/2000 for autosampler
	//        ''  If (Autosampler & Started) Then
	//        ''	 EnableWindow(GetDlgItem(hwnd, IDC_QAREAD), FALSE);
	//        ''  else   //--mdf by sk on 29/2/2000 for autosampler
	//        ''// EnableWindow(GetDlgItem(hwnd, IDC_QAREAD), Started);
	//        '' EnableWindow(GetDlgItem(hwnd, IDC_QAREAD), Started);
	//        '' EnableWindow(GetDlgItem(hwnd, IDC_QANEXT),Started);
	//        '' EnableWindow(GetDlgItem(hwnd, IDC_BLANK),Started);
	//        '' EnableWindow(GetDlgItem(hwnd, IDC_QARPT),Started);
	//        '' EnableWindow(GetDlgItem(hwnd, IDC_QANEW),Started);
	//        '' EnableWindow(GetDlgItem(hwnd, IDC_QASAMP),Started);
	//        ''}
	//        '****************************************************************************************
	//        Try
	//            'To set buttons enable/disable, and show the 
	//            'messages accordingly.
	//            If (mblnIsAnalysisStarted) Then
	//                ANALYSIS = True
	//                '---Show Blinking Message
	//                Call Aspirate()
	//            Else
	//                ANALYSIS = False
	//            End If

	//            If (mblnIsAutosampler And mblnIsAnalysisStarted) Then
	//                btnReadData.Enabled = False
	//            Else
	//                btnReadData.Enabled = mblnIsAnalysisStarted
	//            End If

	//            'tlbbtnNextAnalysis.Enabled = mblnIsAnalysisStarted
	//            'tlbbtnBlankAnalysis.Enabled = mblnIsAnalysisStarted
	//            'tlbbtnRepeatLastAnalysis.Enabled = mblnIsAnalysisStarted
	//            'tlbbtnNewAnalysis.Enabled = mblnIsAnalysisStarted

	//            btnNextAnalysis.Enabled = mblnIsAnalysisStarted
	//            'btnBlankAnalysis.Enabled = mblnIsAnalysisStarted
	//            'btnRepeatLast.Enabled = mblnIsAnalysisStarted
	//            btnNewAnalysis.Enabled = mblnIsAnalysisStarted

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

	//    Public Sub CheckInstrumentOptimisation()
	//        '=====================================================================
	//        ' Procedure Name        : CheckInstrumentOptimisation
	//        ' Parameters Passed     : None
	//        ' Returns               : None
	//        ' Purpose               : To check and perform Instrument Optimization
	//        ' Description           : Finds analytical OR Emmision Peak
	//        ' Assumptions           : 
	//        ' Dependencies          : 
	//        ' Author                : Mangesh Shardul
	//        ' Created               : 01.12.06
	//        ' Revisions             : 
	//        '=====================================================================

	//        '--- ORIGINAL CODE 

	//        ''void	CheckInstrumentOptimisation(HWND hwnd)
	//        ''{
	//        ''char line1[20]="";
	//        ''if (Method){
	//        ''  if (Method->Mode==MODE_UVABS &&  Method->Aas.Wv !=Get_Cur_Wv())
	//        ''	    Method->Aas.OptimseFlag=FALSE;
	//        ''  if (!Method->Aas.OptimseFlag){
	//        ''	    if ((Method->Mode==MODE_AA || Method->Mode==MODE_AABGC ||
	//        ''			 Method->Mode==MODE_SPECT)
	//        ''		    &&  (Method->Aas.LampNo>=0 && Method->Aas.LampNo<=5) )
	//        ''	    {
	//        ''	        ResetAnaMode(Method->Aas.LampNo);
	//        ''		    Method->Aas.OptimseFlag=Find_Analytical_Peak(hwnd, Method->Aas.LampNo);
	//        ''	    }
	//        ''	    else if (Method->Mode==MODE_EMISSION)
	//        ''	        Method->Aas.OptimseFlag=Find_Emmission_Peak(hwnd);
	//        ''	    else if (Method->Mode==MODE_UVABS)
	//        ''	        SetRest_uvs_Condn(hwnd, Method->Aas.Wv, TRUE, 87, 284);
	//        ''  }
	//        ''}
	//        ''sprintf(line1,"%0.2f nm",Get_Cur_Wv());
	//        ''SetWindowText(GetDlgItem(hwnd,IDC_UVWV),line1);
	//        ''}
	//        '***************************************************************
	//        Dim dblSelectedWavelength As Double
	//        Dim intRowCounter As Integer
	//        Dim intInstrumentIndex As Integer

	//        Try
	//            '//----- Commented by Sachin Dokhale
	//            '//----- use Thread except timer for aspirate message
	//            'tmrAspirationMsg.Enabled = False
	//            If Not IsNothing(mobjBgMsgAspirate) Then
	//                mobjBgMsgAspirate.Cancel()
	//                IsDisplayingMessage = mobjBgMsgAspirate.IsMessageRunning
	//            End If

	//            gobjMain.mobjController.Cancel()
	//            gobjCommProtocol.mobjCommdll.subTime_Delay(500)   '10.12.07
	//            Application.DoEvents()

	//            'dblSelectedWavelength = gfuncGetSelectedUVElementWavelength(gobjNewMethod.InstrumentCondition)
	//            If Not IsNothing(gobjNewMethod) Then

	//                '---Gets Current Wavelength from Instrument.
	//                If (gobjNewMethod.OperationMode = EnumOperationMode.MODE_AA Or _
	//                              gobjNewMethod.OperationMode = EnumOperationMode.MODE_AABGC Or _
	//                              gobjNewMethod.OperationMode = EnumOperationMode.MODE_SPECT Or _
	//                              gobjNewMethod.OperationMode = EnumOperationMode.MODE_EMMISSION) Then
	//                    Call gobjCommProtocol.funcGet_Current_Wv(gobjInst.WavelengthCur)
	//                End If

	//                '---Assign the Lamp Number as Turret Number as Both are same
	//                gobjNewMethod.InstrumentCondition.LampNumber = gobjNewMethod.InstrumentCondition.TurretNumber

	//                If Not IsNothing(gobjNewMethod.InstrumentCondition) Then
	//                    If (gobjNewMethod.OperationMode = EnumOperationMode.MODE_UVABS) Then
	//                        dblSelectedWavelength = gfuncGetSelectedUVElementWavelength(gobjNewMethod.InstrumentCondition)
	//                    Else
	//                        dblSelectedWavelength = gfuncGetSelectedElementWavelength(gobjNewMethod.InstrumentCondition)
	//                    End If

	//                    If (gobjNewMethod.OperationMode = EnumOperationMode.MODE_EMMISSION) Then
	//                        dblSelectedWavelength = gobjNewMethod.InstrumentCondition.EmmWavelength
	//                    End If

	//                    If (gobjNewMethod.OperationMode = EnumOperationMode.MODE_UVABS And _
	//                            dblSelectedWavelength <> gobjInst.WavelengthCur) Then
	//                        gobjNewMethod.InstrumentCondition.IsOptimize = False
	//                    End If

	//                    If Not (gobjNewMethod.InstrumentCondition.IsOptimize) Then
	//                        If ((gobjNewMethod.OperationMode = EnumOperationMode.MODE_AA Or _
	//                              gobjNewMethod.OperationMode = EnumOperationMode.MODE_AABGC Or _
	//                              gobjNewMethod.OperationMode = EnumOperationMode.MODE_SPECT) _
	//                              And _
	//                              (gobjNewMethod.InstrumentCondition.LampNumber >= 1 And _
	//                               gobjNewMethod.InstrumentCondition.LampNumber <= 6)) Then

	//                            Call ResetAnaMode(gobjNewMethod.InstrumentCondition.LampNumber)

	//                            '----Finds the Analytical Peak ...
	//                            gobjNewMethod.InstrumentCondition.IsOptimize = gobjClsAAS203.Find_Analytical_Peak(gobjNewMethod.InstrumentCondition.LampNumber, mdblWvOpt, lblOptimizedWavelength)

	//                        ElseIf (gobjNewMethod.OperationMode = EnumOperationMode.MODE_EMMISSION) Then

	//                            '----Finds the Emission Peak ...
	//                            gobjNewMethod.InstrumentCondition.IsOptimize = gobjClsAAS203.Find_Emmission_Peak()

	//                        ElseIf (gobjNewMethod.OperationMode = EnumOperationMode.MODE_UVABS) Then
	//                            Dim blnUVFlag As Boolean
	//                            'blnUVFlag = True
	//                            'if gobjMain.

	//                            'Call gobjClsAAS203.funcSetRest_uvs_Condn(dblSelectedWavelength, True, lblUVWavelength, blnUVFlag)
	//                        End If
	//                    End If
	//                End If
	//            End If

	//            ''sprintf(line1,"%0.2f nm",Get_Cur_Wv());
	//            ''SetWindowText(GetDlgItem(hwnd,IDC_UVWV),line1);
	//            gobjCommProtocol.funcGet_Current_Wv(gobjInst.WavelengthCur)
	//            lblOptimizedWavelength.Text = "Optimized Wavelength : " & gobjInst.WavelengthCur.ToString & " nm"

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
	//            '//----- Commented by Sachin Dokhale
	//            '//----- use Thread except timer for aspirate message
	//            'tmrAspirationMsg.Enabled = True
	//            If Not IsNothing(mobjBgMsgAspirate) Then
	//                mobjBgMsgAspirate.Start()
	//                IsDisplayingMessage = mobjBgMsgAspirate.IsMessageRunning
	//            End If
	//            If gobjMain.mobjController.IsThreadRunning = False Then
	//                gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay)
	//                Application.DoEvents()
	//                gobjMain.mobjController.Start(gobjclsBgFlameStatus)
	//            End If
	//            Application.DoEvents()
	//            '---------------------------------------------------------
	//        End Try
	//    End Sub

	//#End Region

	//#Region " Aspiration Related Functions "

	//    Private Sub StartAspirationThread(ByVal intStartTime As Integer, ByVal intEndTime As Integer)
	//        '=====================================================================
	//        ' Procedure Name        : StartAspirationThread
	//        ' Parameters Passed     : None
	//        ' Returns               : None
	//        ' Purpose               : Start Aspiration thread
	//        ' Description           : 
	//        ' Assumptions           : 
	//        ' Dependencies          : 
	//        ' Author                : Mangesh Shardul
	//        ' Created               : 17-Jan-2007 03:25 pm
	//        ' Revisions             : 1
	//        '=====================================================================
	//        Dim dtMinTime As Date
	//        Dim dtMaxTime As Date
	//        Dim intOLDStartTime As Integer
	//        Dim intOLDEndTime As Integer
	//        ' Start the Analysis Thread
	//        Try
	//            'check the Analysis Thread for not UV Mode 
	//            '//---- Modified by Sachin Dokhale on 30.07.07
	//            If Not (gobjNewMethod.OperationMode = EnumOperationMode.MODE_UVABS) Then
	//                mobjBgReadData = New clsBgReadData(intStartTime, intEndTime, SampleType, mobjCurrentStandard, mobjCurrentSample)
	//            End If
	//            '//-----
	//            ' use Filter setting to Thread
	//            mobjBgReadData.Filter_flag = Filter_flag
	//            'add eventsetting handler
	//            AddHandler mobjBgReadData.AbsorbanceValueChanged, AddressOf mobjBgReadData_AbsorbanceValueChanged
	//            AddHandler mobjBgReadData.AspirationMessageChanged, AddressOf mobjBgReadData_AspirationMessageChanged
	//            ' Check for UV ABS Mode

	//            If Not (gobjNewMethod.OperationMode = EnumOperationMode.MODE_UVABS) Then
	//                If Afirst Then
	//                    ''AASGraphAnalysis.AldysPane.XAxis.StepAuto = True
	//                    ''AASGraphAnalysis.AldysPane.XAxis.MinorStepAuto = True
	//                    ''AASGraphAnalysis.AldysPane.XAxis.PickScale(AASGraphAnalysis.XAxisMin, AASGraphAnalysis.XAxisMax)
	//                    ''AASGraphAnalysis.AldysPane.YAxis.StepAuto = True
	//                    ''AASGraphAnalysis.AldysPane.YAxis.MinorStepAuto = True
	//                    ''AASGraphAnalysis.AldysPane.YAxis.PickScale(AASGraphAnalysis.YAxisMin, AASGraphAnalysis.YAxisMax)
	//                End If
	//            End If
	//            '//---- Modified by Sachin Dokhale on 30.07.07
	//            If Not (mobjBgReadData Is Nothing) Then
	//                ' Init. Read Data thread
	//                Call mobjBgReadData.Initialize(mController)
	//                mobjBgReadData.SampleType = SampleType
	//                'mobjBgReadData.SampleType = Me.SampleType
	//                ' Start to read data from instrument through thread 
	//                gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay)   '10.12.07
	//                Application.DoEvents()
	//                Call mController.Start(mobjBgReadData)
	//            End If
	//            '//-----
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

	//    Private Sub mobjBgReadData_AbsorbanceValueChanged(ByVal dblAbs As Double)
	//        '=====================================================================
	//        ' Procedure Name        : mobjBgReadData_AbsorbanceValueChanged
	//        ' Parameters Passed     : dblAbs as absorbance.
	//        ' Returns               : None
	//        ' Purpose               : thread events throw the abs
	//        ' Description           : 
	//        ' Assumptions           : 
	//        ' Dependencies          : 
	//        ' Author                : Mangesh Shardul
	//        ' Created               : 17-Jan-2007 03:25 pm
	//        ' Revisions             : 1
	//        '=====================================================================
	//        Try
	//            'lblAbsorbance.Text = Format(dblAbs, "0.000")   'Commented by Saurabh 01.08.07
	//            '--- Show the Absorbance label
	//            If gobjNewMethod.OperationMode = EnumOperationMode.MODE_EMMISSION Then
	//                'lblAbsorbance.Text = FormatNumber(dblAbs, 1)
	//            Else
	//                'lblAbsorbance.Text = FormatNumber(dblAbs, 3)
	//            End If

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

	//    Private Sub mobjBgReadData_AspirationMessageChanged(ByVal strNewMessage As String, ByVal blnIsBlink As Boolean)
	//        '=====================================================================
	//        ' Procedure Name        : mobjBgReadData_AspirationMessageChanged
	//        ' Parameters Passed     : strNewMessage As String, blnIsBlink as bool
	//        ' Returns               : None
	//        ' Purpose               : thread events throw Aspiration Message 
	//        ' Description           : 
	//        ' Assumptions           : 
	//        ' Dependencies          : 
	//        ' Author                : Mangesh Shardul
	//        ' Created               : 17-Jan-2007 03:25 pm
	//        ' Revisions             : 1
	//        '=====================================================================
	//        Try
	//            mstrAspirationMessage = strNewMessage
	//            mblnIsBlinkMessage = blnIsBlink
	//            mobjBgMsgAspirate.AspirationMessage = mstrAspirationMessage
	//            mobjBgMsgAspirate.IsBlinkMessage = blnIsBlink

	//            If btnReadData.Enabled = True Then
	//                btnReadData.Focus()
	//            End If

	//            If mstrAspirationMessage = "Reading Wait ..." Then
	//                Call gobjCommProtocol.mobjCommdll.subTime_Delay(2000)
	//            End If
	//            If btnReadData.Enabled = True Then
	//                btnReadData.Focus()
	//            End If

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

	//    Private Sub AddInAnalysisRawData(ByVal xValue As Double, ByVal yValue As Double)
	//        '=====================================================================
	//        ' Procedure Name        : AddInAnalysisRawData
	//        ' Parameters Passed     : None
	//        ' Returns               : None
	//        ' Purpose               : Add the Row Data Result into the Analysis Raw Data collection object
	//        ' Description           : 
	//        ' Assumptions           : 
	//        ' Dependencies          : 
	//        ' Author                : Mangesh Shardul
	//        ' Created               : 25-Jan-2007 12:45 pm
	//        ' Revisions             : 1
	//        '=====================================================================
	//        Dim strSampleName As String
	//        Dim curveColor As Color
	//        Static Dim intStCurRepeat As Integer
	//        Try
	//            '---Add Each Raw Data in the Analysis Raw Data Collection
	//            ' Check for each Data result if type Blank/Std/Samp
	//            Select Case Me.SampleType  'mobjBgReadData.SampleType
	//                Case clsRawData.enumSampleType.BLANK
	//                    '---For Blank
	//                    If mobjBlankRawData Is Nothing Then
	//                        mobjBlankRawData = New Analysis.clsRawData
	//                    End If
	//                    mobjBlankRawData.SampleID = 0
	//                    mobjBlankRawData.SampleType = clsRawData.enumSampleType.BLANK
	//                    mobjBlankRawData.SampleName = "BLANK"
	//                    strSampleName = "BLANK"
	//                    curveColor = ClsAAS203.BLANKCOLOR
	//                    mobjBlankRawData.AddReadings(xValue, yValue)
	//                    'mobjAnalysisRawData.Add(mobjBlankRawData)

	//                Case clsRawData.enumSampleType.STANDARD
	//                    If Not IsNothing(mobjCurrentStandard) Then
	//                        '--- For Standard
	//                        If IsNothing(mobjStandardRawData) Then
	//                            mobjStandardRawData = New Analysis.clsRawData
	//                        End If

	//                        If CurRepeat > 1 Then
	//                            If Not (intStCurRepeat = CurRepeat) Then
	//                                mobjStandardRawData = New Analysis.clsRawData
	//                                intStCurRepeat = CurRepeat
	//                            End If
	//                        Else
	//                            intStCurRepeat = 0
	//                        End If

	//                        If (mobjStandardRawData.SampleID = mobjCurrentStandard.StdNumber) Then
	//                            mobjStandardRawData.SampleID = mobjCurrentStandard.StdNumber
	//                            mobjStandardRawData.SampleName = mobjCurrentStandard.StdName
	//                            mobjStandardRawData.SampleType = clsRawData.enumSampleType.STANDARD
	//                            strSampleName = mobjCurrentStandard.StdName
	//                            curveColor = ClsAAS203.STDCOLOR
	//                            mobjStandardRawData.AddReadings(xValue, yValue)
	//                        Else
	//                            mobjStandardRawData = New Analysis.clsRawData
	//                            mobjStandardRawData.SampleID = mobjCurrentStandard.StdNumber
	//                            mobjStandardRawData.SampleName = mobjCurrentStandard.StdName
	//                            mobjStandardRawData.SampleType = clsRawData.enumSampleType.STANDARD
	//                            strSampleName = mobjCurrentStandard.StdName
	//                            curveColor = ClsAAS203.STDCOLOR
	//                            mobjStandardRawData.AddReadings(xValue, yValue)
	//                            'mobjAnalysisRawData.Add(mobjStandardRawData)
	//                        End If

	//                    End If

	//                Case clsRawData.enumSampleType.SAMPLE
	//                    If Not IsNothing(mobjCurrentSample) Then
	//                        '---For Sample
	//                        If IsNothing(mobjSampleRawData) Then
	//                            mobjSampleRawData = New Analysis.clsRawData
	//                        End If

	//                        If CurRepeat > 1 Then
	//                            If Not (intStCurRepeat = CurRepeat) Then
	//                                mobjSampleRawData = New Analysis.clsRawData
	//                                intStCurRepeat = CurRepeat
	//                            End If
	//                        Else
	//                            intStCurRepeat = 0
	//                        End If

	//                        If mobjSampleRawData.SampleID = mobjCurrentSample.SampNumber Then
	//                            mobjSampleRawData.SampleID = mobjCurrentSample.SampNumber
	//                            mobjSampleRawData.SampleName = mobjCurrentSample.SampleName
	//                            mobjSampleRawData.SampleType = clsRawData.enumSampleType.SAMPLE
	//                            strSampleName = mobjCurrentSample.SampleName
	//                            curveColor = ClsAAS203.SAMPCOLOR
	//                            mobjSampleRawData.AddReadings(xValue, yValue)
	//                        Else
	//                            mobjSampleRawData = New Analysis.clsRawData
	//                            mobjSampleRawData.SampleID = mobjCurrentSample.SampNumber
	//                            mobjSampleRawData.SampleName = mobjCurrentSample.SampleName
	//                            mobjSampleRawData.SampleType = clsRawData.enumSampleType.SAMPLE
	//                            strSampleName = mobjCurrentSample.SampleName
	//                            curveColor = ClsAAS203.SAMPCOLOR
	//                            mobjSampleRawData.AddReadings(xValue, yValue)
	//                            'mobjAnalysisRawData.Add(mobjSampleRawData)
	//                        End If
	//                    End If
	//            End Select

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

	//#Region " Background Thread IClient Implementation Functions "

	//    Public Sub Start(ByVal clsBgThread As BgThread.clsBgThread) Implements BgThread.Iclient.Start
	//        '=====================================================================
	//        ' Procedure Name        : Start
	//        ' Parameters Passed     : None
	//        ' Returns               : None
	//        ' Purpose               : 
	//        ' Description           : 
	//        ' Assumptions           : 
	//        ' Dependencies          : 
	//        ' Author                : Mangesh Shardul
	//        ' Created               : 17-Jan-2007 03:25 pm
	//        ' Revisions             : 1
	//        '=====================================================================
	//        Try

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

	//    Public Sub Completed(ByVal Cancelled As Boolean) Implements BgThread.Iclient.Completed
	//        '=====================================================================
	//        ' Procedure Name        : Completed
	//        ' Parameters Passed     : None
	//        ' Returns               : None
	//        ' Purpose               : 
	//        ' Description           : 
	//        ' Assumptions           : 
	//        ' Dependencies          : 
	//        ' Author                : Mangesh Shardul
	//        ' Created               : 17-Jan-2007 03:25 pm
	//        ' Revisions             : 1
	//        '=====================================================================
	//        Dim dblAbsorbance As Double
	//        Dim A1() As Double = {0, 0, 0, 0, 0, 0}

	//        Try
	//            '//----- Added by Sachin Dokhale 
	//            '//----- to Save Raw Data collection
	//            mblnAvoidProcessing = True
	//            Select Case Me.SampleType
	//                Case ClsAAS203.enumSampleType.BLANK
	//                    If Not (mobjBlankRawData Is Nothing) Then
	//                        mobjAnalysisRawData.Add(mobjBlankRawData)
	//                        mobjBlankRawData = Nothing
	//                    End If
	//                Case ClsAAS203.enumSampleType.SAMPLE
	//                    If Not (mobjSampleRawData Is Nothing) Then
	//                        mobjAnalysisRawData.Add(mobjSampleRawData)
	//                        mobjSampleRawData = Nothing
	//                    End If
	//                Case ClsAAS203.enumSampleType.STANDARD
	//                    If Not (mobjStandardRawData Is Nothing) Then
	//                        mobjAnalysisRawData.Add(mobjStandardRawData)
	//                        mobjStandardRawData = Nothing
	//                    End If
	//            End Select
	//            '//-----
	//            'Save Row data into file system
	//            Call SaveRawDataFile()

	//            If (gobjNewMethod.OperationMode = EnumOperationMode.MODE_UVABS) Then
	//                If Not Cancelled Then
	//                    '--- Store, calculate and Display Quantitative
	//                    Call StoreCalculateDisplayQuantValueUvMode(mobjBgReadData.UVAbsorbance)
	//                End If
	//            Else
	//                '--- Store, calculate and Display Quantitative
	//                dblAbsorbance = StoreCalculateDisplayQuantValue()
	//            End If
	//            '--- Check and validate analysis data
	//            If (SampleType = ClsAAS203.enumSampleType.STANDARD) Then
	//                If Not clsStandardGraph.CheckValidStdAbsEntry(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection) Then
	//                    'If Not clsStandardGraph.CheckValidStdAbsEntry(mobjCurrentStandard) Then
	//                    'gobjMessageAdapter.ShowMessage("Absorbance of the standard is less than or equal to the previous standard." & vbCrLf & _
	//                    '"Press 'Repeat Last' button for aspirating the same standard again.", _
	//                    '"Standard Aspiration Error", MessageHandler.clsMessageHandler.enumMessageType.ErrorMessage)
	//                    mblnGetStandards = False
	//                    gobjMessageAdapter.ShowMessage(constStandardAbsorbance)
	//                    Application.DoEvents()
	//                Else
	//                    mblnGetStandards = True
	//                End If
	//            End If

	//            If (SampleType = ClsAAS203.enumSampleType.SAMPLE) Then
	//                If Not clsStandardGraph.CheckValidSampAbsEntry(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection, mdblAbsorbance) Then
	//                    'If Not clsStandardGraph.CheckValidSampAbsEntry(mobjCurrentSample, mdblAbsorbance) Then

	//                    'gobjMessageAdapter.ShowMessage("Absorbance of the sample is more than the maximum standard value." & vbCrLf & _
	//                    '"Calculated Concentration may not be correct." & vbCrLf & _
	//                    '"Please dilute the sample and repeat again." & vbCrLf & _
	//                    ' "Press RepeatLast button when ready.", "Sample Aspiration Error", _
	//                    '  MessageHandler.clsMessageHandler.enumMessageType.ErrorMessage)

	//                    gobjMessageAdapter.ShowMessage(constSampleAbsorbance)
	//                    Application.DoEvents()
	//                End If

	//            End If

	//            'btnReadData.Enabled = True
	//            ' Remove Read Data haldlser 
	//            RemoveHandler mobjBgReadData.AbsorbanceValueChanged, AddressOf mobjBgReadData_AbsorbanceValueChanged
	//            RemoveHandler mobjBgReadData.AspirationMessageChanged, AddressOf mobjBgReadData_AspirationMessageChanged

	//            'SendMessage(hwnd, WM_COMMAND, 900, 0L) '//IDC_QANEXT, 0L);
	//            '--- Prepare Next analysis 
	//            Call NextAnalysis_Clicked(btnNextAnalysis, EventArgs.Empty)

	//            If AnaOver Then
	//                'btnRepeatLast.Enabled = False
	//            End If
	//            ' Add handler for Read Data
	//            'AddHandler btnReadData.Click, AddressOf ReadData_Click

	//            'mblnAvoidProcessing = False
	//            Application.DoEvents()
	//            '--- Start Flame Status window
	//            If gobjMain.mobjController.IsThreadRunning = False Then
	//                gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay)
	//                Application.DoEvents()
	//                Call gobjMain.mobjController.Start(gobjclsBgFlameStatus)
	//            End If
	//            mblnAvoidProcessing = False
	//            Application.DoEvents()
	//            ' Continue the Read Data process for next analysis 
	//            If (mblnIsAutosampler And mblnIsAnalysisStarted) Then 'by Pankaj for autosampler on 03 Oct 07
	//                'SendMessage(hwnd, WM_COMMAND, IDC_QAREAD, 0L)
	//                mblnAvoidProcessing = False
	//                Call ReadData_Click(btnReadData, EventArgs.Empty)
	//            Else
	//                ' Add handler for Read Data
	//                'AddHandler btnReadData.Click, AddressOf ReadData_Click
	//                Application.DoEvents()
	//            End If
	//            'Call Aspirate()
	//            gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay)   '10.12.07
	//            '' Add handler for Read Data
	//            'AddHandler btnReadData.Click, AddressOf ReadData_Click
	//            'Application.DoEvents()

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

	//    'Public Sub Display(ByVal Text As String) Implements BgThread.Iclient.Display
	//    '    '=====================================================================
	//    '    ' Procedure Name        : Display
	//    '    ' Parameters Passed     : Text
	//    '    ' Returns               : None
	//    '    ' Purpose               : 
	//    '    ' Description           : 
	//    '    ' Assumptions           : 
	//    '    ' Dependencies          : 
	//    '    ' Author                : Mangesh Shardul
	//    '    ' Created               : 17-Jan-2007 03:25 pm
	//    '    ' Revisions             : 1
	//    '    '=====================================================================
	//    '    Dim strData As String
	//    '    Dim arrData() As String
	//    '    Dim xValue, yValue As Double
	//    '    Dim strSampleName As String
	//    '    Dim curveColor As Color
	//    '    Try
	//    '        If gobjNewMethod.OperationMode = EnumOperationMode.MODE_UVABS Then
	//    '            lblUVAbsorbance.Text = "Absorbance : " & FormatNumber(Text, 2)
	//    '            Call AddInAnalysisRawData(xValue, yValue)
	//    '            Exit Sub
	//    '        Else
	//    '            arrData = Text.Split(",")
	//    '            xValue = Val(arrData(0))
	//    '            yValue = Val(arrData(1))
	//    '        End If

	//    '        '---Display Real Point of Reading
	//    '        'If intIsReal = 1 Then
	//    '        '---Display Abs Value on screen
	//    '        lblAbsorbance.Text = Format(yValue, "0.000")
	//    '        '---Add only Real Point in the Analysis Raw Data Structure
	//    '        Call AddInAnalysisRawData(xValue, yValue)
	//    '        'End If

	//    '        '---Draw Line
	//    '        '---Add single Curve Item for all lines
	//    '        strSampleName = "Aspiration Curve"
	//    '        Select Case Me.SampleType
	//    '            Case ClsAAS203.enumSampleType.BLANK
	//    '                curveColor = ClsAAS203.BLANKCOLOR
	//    '            Case ClsAAS203.enumSampleType.STANDARD
	//    '                curveColor = ClsAAS203.STDCOLOR
	//    '            Case ClsAAS203.enumSampleType.SAMPLE
	//    '                curveColor = ClsAAS203.SAMPCOLOR
	//    '        End Select

	//    '        If (Afirst) Then
	//    '            Afirst = False
	//    '            mobjGraphCurve = AASGraphAnalysis.StartOnlineGraph(strSampleName, Color.Black, AldysGraph.SymbolType.NoSymbol, True)
	//    '            AASGraphAnalysis.PlotPoint(mobjGraphCurve, xValue, yValue, True)
	//    '        Else
	//    '            mobjGraphCurve.CL.Add(curveColor)
	//    '            AASGraphAnalysis.PlotPoint(mobjGraphCurve, xValue, yValue, True)
	//    '        End If

	//    '        'Application.DoEvents()
	//    '        'AASGraphAnalysis.AldysPane.XAxis.PickScale(AASGraphAnalysis.XAxisMin, AASGraphAnalysis.XAxisMax)
	//    '        'AASGraphAnalysis.AldysPane.XAxis.StepAuto = True
	//    '        'AASGraphAnalysis.AldysPane.XAxis.MinorStepAuto = True
	//    '        'AASGraphAnalysis.AldysPane.YAxis.PickScale(AASGraphAnalysis.YAxisMin, AASGraphAnalysis.YAxisMax)
	//    '        'AASGraphAnalysis.AldysPane.YAxis.StepAuto = True
	//    '        'AASGraphAnalysis.AldysPane.YAxis.MinorStepAuto = True

	//    '        AASGraphAnalysis.Refresh()
	//    '        Application.DoEvents()

	//    '    Catch ex As Exception
	//    '        '---------------------------------------------------------
	//    '        'Error Handling and logging
	//    '        gobjErrorHandler.ErrorDescription = ex.Message
	//    '        gobjErrorHandler.ErrorMessage = ex.Message
	//    '        gobjErrorHandler.WriteErrorLog(ex)
	//    '        '---------------------------------------------------------
	//    '    Finally
	//    '        '---------------------------------------------------------
	//    '        'Writing Execution log
	//    '        If CONST_CREATE_EXECUTION_LOG = 1 Then
	//    '            gobjErrorHandler.WriteExecutionLog()
	//    '        End If
	//    '        '---------------------------------------------------------
	//    '    End Try
	//    'End Sub

	//    Public Sub Display(ByVal Text As String) Implements BgThread.Iclient.Display
	//        '=====================================================================
	//        ' Procedure Name        : Display
	//        ' Parameters Passed     : Text
	//        ' Returns               : None
	//        ' Purpose               : 
	//        ' Description           : 
	//        ' Assumptions           : 
	//        ' Dependencies          : 
	//        ' Author                : Deepak
	//        ' Created               : 29.04.07
	//        ' Revisions             : 
	//        '=====================================================================
	//        Dim strData As String
	//        Dim arrData() As String
	//        Dim xValue, yValue As Double
	//        Dim strSampleName As String
	//        Dim curveColor As Color
	//        Dim dblAvgAbs As Double = 0
	//        Dim IsAvgAbs As Boolean = False
	//        Try

	//            intDispCount += 1
	//            ' Use Implementd String object 
	//            ' Use X and Y Value
	//            If gobjNewMethod.OperationMode = EnumOperationMode.MODE_UVABS Then
	//                'lblUVAbsorbance.Text = "Absorbance : " & FormatNumber(Text, 3)
	//                Call AddInAnalysisRawData(xValue, yValue)
	//                Exit Sub
	//            Else
	//                arrData = Text.Split(",")
	//                xValue = Val(arrData(0))
	//                yValue = Val(arrData(1))

	//                IsAvgAbs = False
	//                If arrData.Length > 2 Then
	//                    IsAvgAbs = True
	//                    dblAvgAbs = Val(arrData(2))
	//                End If
	//            End If

	//            '---Display Real Point of Reading
	//            '---Display Abs Value on screen
	//            If gobjNewMethod.OperationMode = EnumOperationMode.MODE_EMMISSION Then
	//                'lblAbsorbance.Text = FormatNumber(yValue, 1)
	//            Else
	//                'lblAbsorbance.Text = FormatNumber(yValue, 3)
	//            End If

	//            '---Add only Real Point in the Analysis Raw Data Structure
	//            'Call AddInAnalysisRawData(xValue, yValue)
	//            Call AddInAnalysisRawData(xValue, dblAvgAbs)

	//            'End If

	//            '---Draw Line
	//            '---Add single Curve Item for all lines
	//            strSampleName = "Aspiration Curve"
	//            Select Case Me.SampleType
	//                Case ClsAAS203.enumSampleType.BLANK
	//                    curveColor = ClsAAS203.BLANKCOLOR
	//                Case ClsAAS203.enumSampleType.STANDARD
	//                    curveColor = ClsAAS203.STDCOLOR
	//                Case ClsAAS203.enumSampleType.SAMPLE
	//                    curveColor = ClsAAS203.SAMPCOLOR
	//            End Select
	//            '--- Set the Graph points
	//            'If xValue > AASGraphAnalysis.XAxisMax Or yValue > AASGraphAnalysis.YAxisMax Then
	//            '    Call Calculate_Analysis_Graph_Param(AASGraphAnalysis, xValue, yValue)
	//            'End If

	//            If IsAvgAbs Then
	//                If (Afirst) Then
	//                    Afirst = False
	//                    'mobjGraphCurve = AASGraphAnalysis.StartOnlineGraph(strSampleName, Color.Black, AldysGraph.SymbolType.NoSymbol, True)
	//                    'AASGraphAnalysis.PlotPoint(mobjGraphCurve, xValue, dblAvgAbs, True)
	//                    'AASGraphAnalysis.PlotPoint(mobjGraphCurve, xValue, yValue, True)
	//                Else
	//                    mobjGraphCurve.CL.Add(curveColor)
	//                    'AASGraphAnalysis.PlotPoint(mobjGraphCurve, xValue, dblAvgAbs, True)
	//                    'AASGraphAnalysis.PlotPoint(mobjGraphCurve, xValue, yValue, True)
	//                End If
	//                mxValue = xValue
	//                mdblAvgAbs = dblAvgAbs
	//            End If

	//            'AASGraphAnalysis.Refresh()
	//            Application.DoEvents()

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

	//    Public Sub Failed(ByVal e As System.Exception) Implements BgThread.Iclient.Failed
	//        '=====================================================================
	//        ' Procedure Name        : Failed
	//        ' Parameters Passed     : None
	//        ' Returns               : None
	//        ' Purpose               : 
	//        ' Description           : 
	//        ' Assumptions           : 
	//        ' Dependencies          : 
	//        ' Author                : Mangesh Shardul
	//        ' Created               : 17-Jan-2007 03:25 pm
	//        ' Revisions             : 1
	//        '=====================================================================
	//        Try
	//            ' Set the process when thread is failed
	//            mblnAvoidProcessing = True
	//            MsgBox("Data Read Thread is failed", MsgBoxStyle.OKOnly)
	//            Application.DoEvents()
	//            'AddHandler btnReadData.Click, AddressOf ReadData_Click
	//            gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay)   '10.12.07
	//            mblnAvoidProcessing = False
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
	//            Application.DoEvents()
	//            '---------------------------------------------------------
	//        End Try
	//    End Sub

	//#End Region

	//#End Region

	#Region "OldCode"

	#Region " Private Constants "

	private string ConstFormLoad = gstrTitleInstrumentType + "-Analysis";

	private string ConstParentFormLoad = gstrTitleInstrumentType + "-Method";
	#End Region

	#Region " Private Member Variables "

	int intDispCount;
	private double mdblWvOpt = -1.0;
	//Private mblnIsAnalysisStarted As Boolean   'Saurabh  10.07.07
		//Saurabh  10.07.07
	internal bool mblnIsAnalysisStarted;

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

	public bool mblnIsStartRunNumber = true;
	//---For Background Worker Thread functions

	private clsBgThread mController;

	public clsBgReadData mobjBgReadData = new clsBgReadData();

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
		//Saurabh 07-06-2007
	private clsDataFileReport mobjClsDataFileReport = new clsDataFileReport();
	private int intIEnumCollLocationStd;
	private int intIEnumCollLocationSamp;

	private bool mblnAvoidProcessing = false;
	//Private blnIsAspirateTimer As Boolean = False 'commented by ; dinesh wagh on 2.8.2010

		//30.7.2010 by dinesh wagh
	public AspirateMessage.clsMassageController mobjBgMsgAspirate;

	#End Region

	#Region " Private Properties "

	private string AspirationMessage {
		get { return mstrAspirationMessage; }
		set { mstrAspirationMessage = Value; }
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

		try {
			//If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
			//    btnIgnite.Enabled = False
			//    btnExtinguish.Enabled = False
			//End If

			//btnStdGraph.BringToFront()
			//btnSplGraph.BringToFront()
			//btnStdGraph.Focus()
			//btnSave.Enabled = False
			//'cmdChangeScale.Location = New Point(14, 378)
			//'btnExportReport.Location = New Point(14, 419)
			//'Me.FormBorderStyle = FormBorderStyle.FixedSingle
			//'gobjMain.ShowProgressBar(ConstFormLoad)

			AddHandlers();
			////----- Sachin Dokhale
			btnStartStopAnalysis.BringToFront();
			btnReadData.BringToFront();

			if (!(gobjNewMethod.OperationMode == EnumOperationMode.MODE_UVABS | gobjNewMethod.OperationMode == EnumOperationMode.MODE_UVSPECT | gobjNewMethod.OperationMode == EnumOperationMode.MODE_EMMISSION)) {
				//'-----Added By Pankaj on 10 May 2007
				//    AASGraphAnalysis.YAxisMin = -0.2
				//    AASGraphAnalysis.YAxisMax = 1.2
				//    gobjClsAAS203.Calculate_Analysis_Graph_Param(AASGraphAnalysis, ClsAAS203.enumChangeAxis.xyAxis)

				//    'Elseif Added by Saurabh
				//ElseIf gobjNewMethod.OperationMode = EnumOperationMode.MODE_EMMISSION Then
				//    AASGraphAnalysis.YAxisMin = 0
				//    AASGraphAnalysis.YAxisMax = 100
				//    'AASGraphAnalysis.YAxisStep = 10
				//    'AASGraphAnalysis.YAxisMinorStep = 10
				//    AASGraphAnalysis.YAxisLabel = "EMISSION"
				//    gobjClsAAS203.Calculate_Analysis_Graph_Param(AASGraphAnalysis, ClsAAS203.enumChangeAxis.xyAxis)
				//Else
				//    cmdChangeScale.Enabled = False
				//    cmdChangeScale.Visible = False
				//    btnPrintGraph.Enabled = False
				//    btnPrintGraph.Visible = False
			}
			//'//--- --
			//'-------------
			//----'30.7.2010 by dinesh wagh
			//to make seperate thread for blinking msg.
			mobjBgMsgAspirate = new AspirateMessage.clsMassageController(lblAspirationMessage);
			mstrAspirationMessage = "Click Start button to Start Analysis.";
			mobjBgMsgAspirate.AspirationMessage = mstrAspirationMessage;
			mobjBgMsgAspirate.Start();
			//------------------------

			//Code added by ; dinesh wagh on 4.5.2010 suggested by v.c.k sir for iqoqpq
			//Purpose : to display analysis screen at bottom.
			//--------------------------
			this.Top = Screen.PrimaryScreen.WorkingArea.Height - (this.Height) - 30;
		//------------------

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
			btnIgnite.Click += btnIgnite_Click;
			btnExtinguish.Click += btnExtinguish_Click;

			//AddHandler btnStartStopAnalysis.Click, AddressOf StartStopAnalysis_Click  'code commented by ; dinesh wagh on 2.8.2010
			btnReadData.Click += ReadData_Click;
			btnAutoZero.Click += AutoZero_Clicked;
			//code added by ; dinesh wagh on 25.2.2010

		//code commented by : dinesh wagh on 2.8.2010
		//---------------------------------------------------
		//If blnIsAspirateTimer = False Then
		//    AddHandler tmrAspirationMsg.Elapsed, AddressOf tmrAspirationMsg_Elapsed
		//    blnIsAspirateTimer = True
		//End If
		//----------------------------------------

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

	//code commented by : dinesh wagh on 2.8.2010 function implemented by some another way by thread.

	//Private Sub tmrAspirationMsg_Elapsed(ByVal sender As System.Object, ByVal e As System.Timers.ElapsedEventArgs)
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
	//        Application.DoEvents()
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

	//        If (mintAspirationTimerCounter Mod 5 = 0) Then
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

	private void NewAnalysis_Clicked(System.Object sender, System.EventArgs e)
	{
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

		//*****************************************
		//---CODE BY MANGESH 
		//*****************************************
		//On NEW Analysis
		double dblFuelRatio;
		DialogResult objDlgResult;

		//---18.06.07
		try {
			//----added by deepak for new analysis on 28.04.07
			//lblAbsorbance.Text = ""
			//lblAverageAbsorbance.Text = ""
			//lblCorrectedAbsorbance.Text = ""
			//lblSampleID.Text = ""
			//lblRepeatNo.Text = ""
			//lblConcentration.Text = ""
			//------------------

			//code added by ; dinesh wagh on 2.2.2010
			//------------------------------------------
			lblAbsorbance.Text = "";
			lblAverageAbsorbance.Text = "";
			lblCorrectedAbsorbance.Text = "";
			//----------------------------------------

			gobjclsStandardGraph = new clsStandardGraph();

			//---Get the last RunNumber 

			//If gobjNewMethod.QuantitativeDataCollection.Count > 0 Then
			//    mintRunNumberIndex = gobjNewMethod.QuantitativeDataCollection.Count - 1
			//ElseIf gobjNewMethod.QuantitativeDataCollection.Count <= 0 Then
			//    mintRunNumberIndex = -1
			//End If

			if (gobjNewMethod.StandardAddition) {
				EndAnalysis = false;
			}

			//DeleteAllRawData(False)
			////----- Modifed by Sachin Dokhale
			//'mobjAnalysisRawData.Clear()
			//mobjAnalysisRawData.Dispose()
			mobjAnalysisRawData = null;
			mobjAnalysisRawData = new Analysis.clsRawDataCollection();
			////-----
			mobjBlankRawData = null;
			mobjStandardRawData = null;
			mobjSampleRawData = null;
			//'//-----


			//*************************************************************************
			//---- Commented by Mangesh on 10-May-2007
			//*************************************************************************
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
			//*************************************************************************

			CurRepeat = 1;

			if (((!IsNothing(mobjCurrentStandard)) & StdAnalysed)) {
				if ((gobjNewMethod.StandardAddition)) {
					objDlgResult = DialogResult.No;
				} else {
					if (!(methchange)) {
						if (gobjMessageAdapter.ShowMessage(constPreviousStandards)) {
							objDlgResult = DialogResult.Yes;
						} else {
							objDlgResult = DialogResult.No;
						}
					} else {
						objDlgResult = DialogResult.No;
					}
				}
				//Comment & move by Pankaj on 08 Jun 07 
				//If (objDlgResult = DialogResult.No) Then
				//    Clear_All_Abs_Std(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection)
				//Else
				//    mobjCurrentStandard = Nothing
				//End If
				//------
			}
			methchange = false;

			//---for removing uncompleted std analysis
			if (!(StdAnalysed)) {
				Clear_All_Abs_Std(gobjNewMethod.StandardDataCollection);
			}
			//Moved By Pankaj  on 09 Jun 07
			//Call Clear_All_Abs_Conc_Samp(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection)


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

			if ((mblnIsStartRunNumber)) {
				//AppendMethod(Method, QALL)
				//If (CInt(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).RunNumber) >= 0) Then
				AAS203Library.Method.clsQuantitativeData objclsQuantitativeData;
				objclsQuantitativeData = new AAS203Library.Method.clsQuantitativeData();
				objclsQuantitativeData.AnalysisParameters = gobjNewMethod.AnalysisParameters.Clone();
				objclsQuantitativeData.ReportParameters = gobjNewMethod.ReportParameters.Clone();
				objclsQuantitativeData.StandardDataCollection = gobjNewMethod.StandardDataCollection.Clone();
				objclsQuantitativeData.SampleDataCollection = gobjNewMethod.SampleDataCollection.Clone();
				//objclsQuantitativeData.CalculationMode = gobjNewMethod.CalculationMode
				gobjNewMethod.QuantitativeDataCollection.Add(objclsQuantitativeData);
				//mintRunNumberIndex += 1
				mintRunNumberIndex = gobjNewMethod.QuantitativeDataCollection.Count - 1;
				gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).RunNumber = -1.0;
				//End If
				mblnIsStartRunNumber = false;
			}
			//Added By Pankaj on 08 Jun 07
			if (((!IsNothing(mobjCurrentStandard)) & StdAnalysed)) {
				if ((objDlgResult == DialogResult.No)) {
					Clear_All_Abs_Std(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection);
				} else {
					mobjCurrentStandard = null;
				}
			}
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

			//*************************************************************************
			//---- Added by Mangesh on 10-May-2007
			//*************************************************************************
			//---Gets the First Standard from Standard Collection
			if (!IsNothing(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection)) {
				mobjStandardEnumerator = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.GetEnumerator();
				mobjStandardEnumerator.Reset();
				intIEnumCollLocationStd = 0;
				if (mobjStandardEnumerator.MoveNext()) {
					intIEnumCollLocationStd = 1;
					mobjCurrentStandard = (Method.clsAnalysisStdParameters)mobjStandardEnumerator.Current();
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
			//*************************************************************************

			//If AASGraphAnalysis.AldysPane.CurveList.Count > 0 Then
			//    AASGraphAnalysis.AldysPane.CurveList.Clear()

			//    AASGraphAnalysis.AldysPane.AxisChange()
			//    AASGraphAnalysis.Invalidate()
			//    Application.DoEvents()
			//End If

			//AASGraphAnalysis.XAxisStep = 20     'Saurabh 06-06-2007
			//Call Calculate_Analysis_Graph_Param(AASGraphAnalysis)

			//AASGraphAnalysis.XAxisType = AldysGraph.AxisType.Linear
			//AASGraphAnalysis.XAxisMin = mStartTime
			//AASGraphAnalysis.XAxisMax = mEndTime

			//Call Calculate_Analysis_Graph_Param(AASGraphAnalysis)

			//'AASGraphAnalysis.AldysPane.XAxis.StepAuto = True
			//'AASGraphAnalysis.AldysPane.XAxis.MinorStepAuto = True
			//'AASGraphAnalysis.AldysPane.XAxis.PickScale(AASGraphAnalysis.XAxisMin, AASGraphAnalysis.XAxisMax)

			//AASGraphAnalysis.Refresh()
			//Application.DoEvents()

			AnaOver = false;

			DisplayRunNo();

			//gobjNewMethod.AnalysisParameters.cMode = -2

			//tlbbtnRepeatLastAnalysis.Enabled = False
			// btnRepeatLast.Enabled = False
			////----- Save Instrument parameter
			//gobjNewMethod.InstrumentCondition.D2Current = gobjInst.D2Current
			//gobjNewMethod.InstrumentCondition.LampCurrent = gobjInst.Current
			//gobjNewMethod.InstrumentCondition.PmtVoltage = gobjInst.PmtVoltage
			//gobjNewMethod.InstrumentCondition.SlitWidth = gobjClsAAS203.funcGet_SlitWidth
			if (gstructSettings.AppMode == EnumAppMode.FullVersion_203D) {
				//TODO   Add property to gobjNewMethod.InstrumentCondition object for PMT Volt & Exit Slit Wd for Ref. 
				//gobjNewMethod.InstrumentCondition.PmtVoltage = gobjInst.PmtVoltageReference
				//gobjNewMethod.InstrumentCondition.SlitWidth = gobjInst.SlitPositionExit
			}

			gobjNewMethod.InstrumentCondition.BurnerHeight = gobjClsAAS203.funcReadBurnerHeight();

			if (!(gstructSettings.AppMode == EnumAppMode.DemoMode)) {
				gobjCommProtocol.funcGet_NV_Pos();
			}

			dblFuelRatio = gobjClsAAS203.funcGet_Fuel_Ratio(true);
			gobjNewMethod.InstrumentCondition.FuelRatio = dblFuelRatio;
			////-----

			//If (gobjNewMethod.AnalysisParameters) Then
			//   aafname = gobjNewMethod.AnalysisParameter.Fname
			//End If
			Display_Analysis_Info();
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
		// Purpose               : 
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

		//******************************************************************
		//--- CODE BY MANGESH 
		//******************************************************************
		try {
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
					StartStopAnalysis_Click(btnStartStopAnalysis, EventArgs.Empty);
				}

			} else {
				CurRepeat += 1;

				//if ((CurRepeat>Method->QuantData->Param.Repeat && SampType==SAMP) || (CurRepeat>Method->QuantData->Param.ConcRepeat && SampType==STD)){

				if (((CurRepeat > gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfSampleRepeats & SampleType == ClsAAS203.enumSampleType.SAMPLE) | (CurRepeat > gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfStdRepeats & SampleType == ClsAAS203.enumSampleType.STANDARD))) {
					CurRepeat = 1;

					if ((SampleType == ClsAAS203.enumSampleType.STANDARD)) {
						//If (CurStd! = NULL) Then
						//   CurStd=CurStd->next
						//}

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
						//}
						//If Not IsNothing(mobjSampleEnumerator) Then
						//    If mblnRepeatLastSample Then
						//        If Not mobjSampleEnumerator.Current Is Nothing Then
						//            mobjCurrentSample = CType(mobjSampleEnumerator.Current, Method.clsAnalysisSampleParameters)
						//        Else
						//            mobjCurrentSample = Nothing
						//        End If
						//    Else
						//        If Not mobjSampleEnumerator.Current Is Nothing Then
						//            If mobjSampleEnumerator.MoveNext() Then
						//                mobjCurrentSample = CType(mobjSampleEnumerator.Current, Method.clsAnalysisSampleParameters)
						//            Else
						//                mobjCurrentSample = Nothing
						//            End If
						//        End If
						//    End If
						//    mblnRepeatLastSample = False
						//End If
						funcGetCurrentSample(mobjCurrentSample);
					}
				}
				//EnableWindow(GetDlgItem(hwnd, IDC_SAVEREPORT), StdAnalysed)
				//btnSave.Enabled = StdAnalysed

				if ((gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.IsBlankAfterEverySampleOrStd)) {
					SampleType = ClsAAS203.enumSampleType.BLANK;
				}

			}

			InQAnaRead = false;
			//tlbbtnSaveReport.Enabled = StdAnalysed
			//tlbbtnRepeatLastAnalysis.Enabled = True
			//btnEditData.Enabled = StdAnalysed
			//btnRepeatLast.Enabled = True

			Aspirate();

			//#If STD_ADDN Then
			if (gobjNewMethod.StandardAddition) {
				if ((EndAnalysis)) {
					//SendMessage(hwnd, WM_COMMAND, 951, 0L)
					//951=>IDC_QASTART
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
		//Static intIEnumCollLocation As Integer
		try {
			if (!IsNothing(objCurrentStandard)) {
				if (mblnRepeatLastStd == true) {
					//If Not mobjStandardEnumerator.Current Is Nothing Then
					//    mobjCurrentStandard = CType(mobjStandardEnumerator.Current, Method.clsAnalysisStdParameters)
					//Else
					//    mobjCurrentStandard = Nothing
					//End If

					if (funcMoveEnumerator(mobjStandardEnumerator, intIEnumCollLocationStd) == true) {
						objCurrentStandard = (Method.clsAnalysisStdParameters)mobjStandardEnumerator.Current;
					} else {
						objCurrentStandard = null;
					}
				} else {
					//If Not mobjStandardEnumerator.Current Is Nothing Then
					//    If mobjStandardEnumerator.MoveNext() Then
					//        mobjCurrentStandard = CType(mobjStandardEnumerator.Current, Method.clsAnalysisStdParameters)
					//    Else
					//        mobjCurrentStandard = Nothing
					//    End If
					//End If

					intIEnumCollLocationStd += 1;
					if (funcMoveEnumerator(mobjStandardEnumerator, intIEnumCollLocationStd) == true) {
						objCurrentStandard = (Method.clsAnalysisStdParameters)mobjStandardEnumerator.Current;
					} else {
						objCurrentStandard = null;
					}
				}
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
		//Static intIEnumCollLocation As Integer
		try {
			if (!IsNothing(objCurrentSample)) {
				if (mblnRepeatLastSample == true) {
					//If Not mobjStandardEnumerator.Current Is Nothing Then
					//    mobjCurrentStandard = CType(mobjStandardEnumerator.Current, Method.clsAnalysisStdParameters)
					//Else
					//    mobjCurrentStandard = Nothing
					//End If

					if (funcMoveSampleEnumerator(mobjSampleEnumerator, intIEnumCollLocationSamp) == true) {
						objCurrentSample = (Method.clsAnalysisSampleParameters)mobjSampleEnumerator.Current;
					} else {
						objCurrentSample = null;
					}
				} else {
					//If Not mobjStandardEnumerator.Current Is Nothing Then
					//    If mobjStandardEnumerator.MoveNext() Then
					//        mobjCurrentStandard = CType(mobjStandardEnumerator.Current, Method.clsAnalysisStdParameters)
					//    Else
					//        mobjCurrentStandard = Nothing
					//    End If
					//End If

					intIEnumCollLocationSamp += 1;
					if (funcMoveSampleEnumerator(mobjSampleEnumerator, intIEnumCollLocationSamp) == true) {
						objCurrentSample = (Method.clsAnalysisSampleParameters)mobjSampleEnumerator.Current;
					} else {
						objCurrentSample = null;
					}
				}
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
		IEnumerator tmpEnum;
		bool IsLastRecoed = false;
		try {
			int i;
			tmpEnum = piEnumarator;

			if (!tmpEnum == null) {
				tmpEnum.Reset();
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

	private bool funcMoveSampleEnumerator(ref IEnumerator piEnumarator, int iLocation)
	{
		IEnumerator tmpEnum;
		bool IsLastRecoed = false;
		try {
			int i;
			if (!IsNothing(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection)) {
				mobjSampleEnumerator = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.GetEnumerator();
				tmpEnum = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.GetEnumerator();
			} else {
				tmpEnum = piEnumarator;
			}


			if (!tmpEnum == null) {
				tmpEnum.Reset();
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

	private void BlankAnalysis_Clicked(System.Object sender, System.EventArgs e)
	{
		//case	IDC_BLANK:
		//   SampType=BLANK;
		//   break;
		try {
			if (!(SampleType == ClsAAS203.enumSampleType.BLANK)) {
				SampleType = ClsAAS203.enumSampleType.BLANK;
				Aspirate();
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
StartStopAnalysis_Click(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : StartStopAnalysis_Click
		// Parameters Passed     : Object, EventArgs
		// Returns               : None
		// Purpose               : 
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
			mblnIsAnalysisStarted = !mblnIsAnalysisStarted;
			InAnalysis = !InAnalysis;

			//code added by ; dinesh wagh on 24.2.2010
			//purpose  : to ask before end analysis.
			//-----------------------------------------
			if (mblnIsAnalysisStarted == false) {
				if (gobjMessageAdapter.ShowMessage("Do you want to stop analysis?", "Note...", MessageHandler.clsMessageHandler.enumMessageType.QuestionMessage) == false) {
					mblnIsAnalysisStarted = true;
					return;
				}
			}
			//-----------------------------------------

			if (mblnIsAnalysisStarted) {
				//Saurabh Add to check if 'No' is selected
				if ((mblnIsAnalysisStarted & (!exitbutton))) {
					//If (gobjMessageAdapter.ShowMessage(constNewAnalysis) = True) Then
					//SendMessage(hwnd, WM_COMMAND,IDC_QANEW, 0L)
					NewAnalysis_Clicked(btnNewAnalysis, EventArgs.Empty);
					//Else
					//mblnIsAnalysisStarted = Not mblnIsAnalysisStarted
					//InAnalysis = Not InAnalysis
					//Exit Sub
					//End If
				}
				//Saurabh Add to check if 'No' is selected
				btnStartStopAnalysis.Text = "End Anal&ysis";

				btnReadData.Enabled = true;
				//Saurabh 10.07.07
				if (!IsNothing(gobjMain.mobjfrmMethod)) {
					gobjMain.mobjfrmMethod.btnNewMethod.Enabled = false;
					gobjMain.mobjfrmMethod.btnLoadMethod.Enabled = false;
				}
			//Saurabh 10.07.07
			} else {
				btnStartStopAnalysis.Text = "Start Anal&ysis";
				mstrAspirationMessage = "Click Start button to Start Analysis.";
				mobjBgMsgAspirate.AspirationMessage = mstrAspirationMessage;
				//30.7.2010

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

			CheckAnaButtons();

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
				GetRunNo(gobjNewMethod);
				DisplayRunNo();


				//SetWindowText(GetDlgItem(hwnd, IDC_QASTART), "E&nd Ana")
				btnStartStopAnalysis.Text = "E&nd Analysis";

				gobjclsStandardGraph = new clsStandardGraph();
				InQAnaRead = false;
			} else {
				btnStartStopAnalysis.Text = "&Start Analysis";

				//btnEditData.Enabled = True

				//If (AnaOver) Then
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
				if ((toreported)) {
					//SaveQuantResults(hwnd, Method, A1, 0)
					gobjNewMethod.DateOfLastUse = Now;

					//---added by deepak on 20.07.07 for not dsplaying messages in uv mode
					gobjClsAAS203.SaveQuantResults(gobjNewMethod, A1, 0, false);

					//Call gobjClsAAS203.SaveQuantResults(gobjNewMethod, A1, 0)


					//Dim intMethodCounter As Integer
					//For intMethodCounter = 0 To gobjMethodCollection.Count - 1
					//    If gobjMethodCollection.item(intMethodCounter).MethodID = gobjNewMethod.MethodID Then
					//        gobjNewMethod = gobjMethodCollection.item(intMethodCounter).Clone()
					//        Exit For
					//    End If
					//Next

					mblnIsStartRunNumber = true;
					toreported = false;
				}
				//End If
				InQAnaRead = false;
				this.Close();
				this.Dispose();
			}


		//#If QDEMO Then
		//   If (AnaOver) Then
		//       EndFiledataRead()
		//   End If
		//#End If

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


		//******************************************************************************
		//----CODE BY MANEGSH 
		//******************************************************************************
		ClsAAS203.enumIgniteType intEnumIgiteType;

		try {
			if (mblnAvoidProcessing == true) {
				return;
			}
			mblnAvoidProcessing = true;

			//*********Saurabh 10.07.07 for change in Integration Time*********
			gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.IntegrationTime = gobjNewMethod.AnalysisParameters.IntegrationTime;
			//*********Saurabh 10.07.07 for change in Integration Time*********

			//Added By Pankaj on 11 Jun 07 
			if (funcMoveSampleEnumerator(mobjSampleEnumerator, intIEnumCollLocationSamp) == true) {
				mobjCurrentSample = (Method.clsAnalysisSampleParameters)mobjSampleEnumerator.Current;
			}
			if (funcMoveEnumerator(mobjStandardEnumerator, intIEnumCollLocationStd) == true) {
				mobjCurrentStandard = (Method.clsAnalysisStdParameters)mobjStandardEnumerator.Current;
			}

			//-----
			gobjMain.mobjController.Cancel();
			Application.DoEvents();


			if (!(gobjNewMethod.OperationMode == EnumOperationMode.MODE_UVABS)) {
				if (gstructSettings.AppMode == EnumAppMode.DemoMode) {
					intEnumIgiteType = ClsAAS203.enumIgniteType.Blue;
				} else {
					intEnumIgiteType = gobjClsAAS203.funcIgnite_Test();
				}

				gobjfrmStatus.FlameType = intEnumIgiteType;

				if ((!HydrideMode & (intEnumIgiteType == ClsAAS203.enumIgniteType.Green | gobjMain.IgniteType == ClsAAS203.enumIgniteType.Red))) {
					//gobjMessageAdapter.ShowMessage("Flame is OFF." & vbCrLf & "Analysis not possible.", "Aspiration Error", MessageHandler.clsMessageHandler.enumMessageType.ErrorMessage)
					gobjMessageAdapter.ShowMessage(constFlameOFF);
					mblnAvoidProcessing = false;
					return;
				}
			}

			//#If STD_ADDN Then
			if ((gobjNewMethod.StandardAddition)) {
				if ((EndAnalysis)) {
					//SendMessage(hwnd, WM_COMMAND, IDC_QANEW, 0L)
					NewAnalysis_Clicked(btnNewAnalysis, EventArgs.Empty);
				}
			}
			//#End If

			InQAnaRead = true;
			toreported = true;

			//mstrAspirationMessage = "Reading Wait ... "

			//Call mobjBgReadData_AspirationMessageChanged("Reading Wait ... ", False)
			mstrAspirationMessage = "Reading Wait ... ";
			mobjBgMsgAspirate.AspirationMessage = mstrAspirationMessage;

			//Saurabh Delay increased from 100 to 2000
			gobjCommProtocol.mobjCommdll.subTime_Delay(2000);
			//Call gobjCommProtocol.mobjCommdll.subTime_Delay(100)
			Application.DoEvents();

			Display_Analysis_Info();
			////----- Added by Sachin Dokhale
			//btnReadData.Enabled = False
			btnReadData.Click -= ReadData_Click;

			if (!(Afirst)) {
				mEndTime = mobjBgReadData.CEndTime;
			} else {
				//mEndTime = mStartTime

				//CEndTime = (int) ((double) Method->QuantData->Param.Int_Time * (double) CLK_TCK);
				//mEndTime = mStartTime + gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.IntegrationTime
				mEndTime = mStartTime;
				//+ gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.IntegrationTime
			}

			//'//----- Added by Sachin Dokhale
			//'btnReadData.Enabled = False
			//RemoveHandler btnReadData.Click, AddressOf ReadData_Click
			////-----
			//mdblAbsorbance = Read_Quant_Data(mdtStartTime, mdtEndTime)
			mdblAbsorbance = Read_Quant_Data(mStartTime, mEndTime);



		//---Shifted to Completed Event Function of BgThread Client 
		//double	A1[6]={0, 0, 0, 0, 0, 0};
		//Dim A1() As Double = {0, 0, 0, 0, 0, 0}
		//If Not (gobjNewMethod.Status) Then '->RepReady )
		//    'SaveQuantResults(gobjNewMethod, A1, 0)
		//Else
		//SaveRawDataFile()
		//'End If

		//If (SampType = ClsAAS203.enumSampleType.STANDARD) Then
		//    If Not (CheckValidStdAbsEntry(gobjNewMethod.StdParametersCollection)) Then

		//        gobjMessageAdapter.ShowMessage("Absorbance of the standard is less than or equal to the previous standard." & vbCrLf & _
		//                                       "Press 'Repeat Last' button for aspirating the same standard again.", _
		//                                       "Standard Aspiration Error", MessageHandler.clsMessageHandler.enumMessageType.ErrorMessage)
		//        'gobjMessageAdapter.ShowMessage(constStandardAbsorbance)
		//    End If
		//End If

		//If (SampType = ClsAAS203.enumSampleType.SAMPLE) Then
		//    If Not (CheckValidSampAbsEntry(gobjNewMethod.SampleParametersCollection, mdblAbsorbance)) Then

		//        gobjMessageAdapter.ShowMessage("Absorbance of the sample is more than the maximum standard value." & vbCrLf & _
		//                                       "Calculated Concentration may not be correct." & vbCrLf & _
		//                                       "Please dilute the sample and repeat again." & vbCrLf & _
		//                                       "Press RepeatLast button when ready.", "Sample Aspiration Error", _
		//                                            MessageHandler.clsMessageHandler.enumMessageType.ErrorMessage)
		//        'gobjMessageAdapter.ShowMessage(constSampleAbsorbance)
		//    End If

		//End If

		//'SendMessage(hwnd, WM_COMMAND, 900, 0L) '//IDC_QANEXT, 0L);
		//Call NextAnalysis_Clicked(tlbbtnNextAnalysis, EventArgs.Empty)

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
		gobjMain.ShowRunTimeInfo(ConstParentFormLoad);
	}

	private void btnIgnite_Click(object sender, System.EventArgs e)
	{
		try {
			gobjMain.AutoIgnition();

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
		try {
			gobjMain.Extinguish();

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

		//****************************************************************
		//---CODE BY MANGESH
		//****************************************************************
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

	//Private Sub subInitAnalysisGraph()
	//    '---To set the X-axis as Time axis and its default Min, Max & Step values.
	//    Dim dtXMin, dtXMax As Date

	//    Try
	//        Call Calculate_Analysis_Graph_Param(AASGraphAnalysis)

	//        AASGraphAnalysis.XAxisLabel = "TIME(seconds)"
	//        AASGraphAnalysis.XAxisType = AldysGraph.AxisType.Linear
	//        AASGraphAnalysis.IsShowGrid = True
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

	private void InitAnalysis()
	{
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
			//Select Case gobjNewMethod.OperationMode
			//    Case EnumOperationMode.MODE_UVABS
			//        '---Do not show graph
			//        lblUVAbsorbance.Visible = True
			//        lblUVAbsorbance.Size = New Size(370, 87)
			//        lblUVAbsorbance.Location = New Point(136, 73)
			//        lblUVWavelength.Visible = True
			//        lblUVWavelength.Size = New Size(370, 87)
			//        lblUVWavelength.Location = New Point(136, 188)
			//        AASGraphAnalysis.Visible = False
			//        Call Application.DoEvents()

			//    Case Else
			//        AASGraphAnalysis.Visible = True
			//        lblUVAbsorbance.Visible = False
			//        lblUVWavelength.Visible = False
			//        Call Application.DoEvents()

			//        If (gobjNewMethod.OperationMode = EnumOperationMode.MODE_EMMISSION) Then
			//            AASGraphAnalysis.YAxisMin = 0.0
			//            AASGraphAnalysis.YAxisMax = 100.0
			//            AASGraphAnalysis.YAxisStep = 20.0
			//            AASGraphAnalysis.YAxisMinorStep = 5.0

			//            AASGraphAnalysis.YAxisLabel = "EMISSION"
			//            'Changed by Saurabh "Energy" to "Emission"
			//            lblAbsorbanceMain.Text = "Emission : "
			//            lblAverageAbsorbanceMain.Text = "Average Emission : "
			//        Else
			//            '---changed by deepak on 29.04.07
			//            AASGraphAnalysis.YAxisMin = -0.2
			//            AASGraphAnalysis.YAxisMax = 0.8
			//            'AASGraphAnalysis.YAxisStep = 0.1
			//            'AASGraphAnalysis.YAxisMinorStep = 0.05
			//            AASGraphAnalysis.YAxisStep = 0.2
			//            AASGraphAnalysis.YAxisMinorStep = 0.1

			//            AASGraphAnalysis.YAxisLabel = "ABSORBANCE"
			//        End If
			//        Call subInitAnalysisGraph()
			//End Select

			//'---Set Method Title
			//txtMethod.Text = gobjNewMethod.MethodName

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
	}

	//Private Sub Test_Time(ByRef dtXTime As Date, ByRef dblY As Double)
	//    If (dtXTime < AldysGraph.XDate.XLDateToDateTime(AASGraphAnalysis.XAxisMax)) Then
	//        dtXTime = dtXTime.AddMinutes(1.0)
	//        Dim objRnd As New Random
	//        dblY = objRnd.NextDouble() * 100
	//    End If
	//End Sub

	private void ResetAnaMode(int intLampNumber)
	{
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
			//lblSampleID.Text = ""
			//lblRepeatNo.Text = ""
			//lblCorrectedAbsorbance.Text = ""
			//lblConcentration.Text = ""

			switch (SampleType) {
				case ClsAAS203.enumSampleType.BLANK:
				//lblSampleID.Text = "BLANK"
				//lblRepeatNo.Text = "1"
				//lblCorrectedAbsorbance.Text = ""
				//lblConcentration.Text = ""

				case ClsAAS203.enumSampleType.STANDARD:
					if (!IsNothing(mobjCurrentStandard)) {
						//lblSampleID.Text = mobjCurrentStandard.StdName
						//lblRepeatNo.Text = CurRepeat

						//'---Store Result Accurate upto AnalysisParameters.NumOfDecimalPlaces
						//lblConcentration.Text = FormatNumber(mobjCurrentStandard.Concentration, gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfDecimalPlaces)

					}
				case ClsAAS203.enumSampleType.SAMPLE:
					if (!IsNothing(mobjCurrentSample)) {
						//lblSampleID.Text = mobjCurrentSample.SampleName
						//lblRepeatNo.Text = CurRepeat
						//lblConcentration.Text = "Unknown"
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
			if (!IsNothing(gobjNewMethod.QuantitativeDataCollection)) {
				if (((int)gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).RunNumber > 0)) {
					strRunNumber = Format((int)gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).RunNumber, "00000000");
					//lblRunNumber.Text = strRunNumber
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
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 17-Jan-2007 03:25 pm
		// Revisions             : 1
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


		//*******************************************************************************
		//---CODE BY MANGESH 
		//*******************************************************************************
		string aspMsg;

		try {
			if ((gobjNewMethod.OperationMode == EnumOperationMode.MODE_UVABS)) {
				aspMsg = "Insert Cuvete ";
			} else {
				aspMsg = "Aspirate ";
			}

			if ((SampleType == ClsAAS203.enumSampleType.BLANK)) {
				if ((mblnIsAutosampler & mblnIsAnalysisStarted)) {
					if (!(PositionAutosampler())) {
						//gobjMessageAdapter.ShowMessage("Autosampler connection Lost", "Autosampler", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage)
						gobjMessageAdapter.ShowMessage(constAutoSamplerConnLost);
					}
				} else {
					mstrAspirationMessage = aspMsg + "Blank and Click Read Data or press <SPACEBAR>";
					mobjBgMsgAspirate.AspirationMessage = mstrAspirationMessage;

					//---Saurabh---20.06.07
					if (btnReadData.Enabled == true) {
						btnReadData.Focus();
						btnReadData.Refresh();
					}
					//---Saurabh
				}
			} else {
				if ((SampleType == ClsAAS203.enumSampleType.STANDARD)) {
					if (!IsNothing(mobjCurrentStandard)) {
						//( Method->QuantData->Param.ConcRepeat>1)
						if ((gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfStdRepeats) > 1) {
							if ((mblnIsAutosampler & mblnIsAnalysisStarted)) {
								mstrAspirationMessage = aspMsg + mobjCurrentStandard.StdName + " (Repeat #" + CurRepeat + ") from Position " + mobjCurrentStandard.PositionNumber;
								SetAutoSampler(mobjCurrentStandard.PositionNumber, true);
							} else {
								mstrAspirationMessage = aspMsg + mobjCurrentStandard.StdName + "(Repeat #" + CurRepeat + ") and Click Read Data or press <SPACEBAR>";
							}
						} else {
							if ((mblnIsAutosampler & mblnIsAnalysisStarted)) {
								mstrAspirationMessage = aspMsg + mobjCurrentStandard.StdName + " from Position " + mobjCurrentStandard.PositionNumber;
								SetAutoSampler(mobjCurrentStandard.PositionNumber, true);
							} else {
								mstrAspirationMessage = aspMsg + mobjCurrentStandard.StdName + " and Click Read Data or press <SPACEBAR>";
							}
						}
						mobjBgMsgAspirate.AspirationMessage = mstrAspirationMessage;
					}
				} else {
					if (!IsNothing(mobjCurrentSample)) {
						if ((gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfSampleRepeats > 1)) {
							if ((mblnIsAutosampler & mblnIsAnalysisStarted)) {
								mstrAspirationMessage = aspMsg + mobjCurrentSample.SampleName + " (Repeat #" + CurRepeat + ") from Position " + mobjCurrentSample.SampPosNumber;
								SetAutoSampler(mobjCurrentSample.SampPosNumber, true);
							} else {
								mstrAspirationMessage = aspMsg + mobjCurrentSample.SampleName + " (Repeat #" + CurRepeat + ") and Click Read Data or press <SPACEBAR> ";
							}
						} else {
							if ((mblnIsAutosampler & mblnIsAnalysisStarted)) {
								mstrAspirationMessage = aspMsg + mobjCurrentSample.SampleName + " from Position " + mobjCurrentSample.SampPosNumber;
								SetAutoSampler(mobjCurrentSample.SampPosNumber, true);
							} else {
								mstrAspirationMessage = aspMsg + mobjCurrentSample.SampleName + " and Click Read Data or press <SPACE BAR>";
							}
						}
					}
					mobjBgMsgAspirate.AspirationMessage = mstrAspirationMessage;
				}
			}

			if (btnReadData.Enabled) {
				btnReadData.Focus();
				btnReadData.Refresh();
			}

			if ((mblnIsAutosampler & mblnIsAnalysisStarted)) {
				//SendMessage(hwnd, WM_COMMAND, IDC_QAREAD, 0L)
				ReadData_Click(btnReadData, EventArgs.Empty);
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

	private bool SetAutoSampler(int pos, bool flag)
	{
		//---FUNCTION TEMPORARILY COMMENTED AS NO AUTOSAMPLER
		return false;
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
			//If Not (IsSamplerConnected()) Then
			//    Return False
			//End If

			if ((flag)) {
				str = "Sampler => " + pos + "    ";
			//ASamplerStart(pos)
			} else {
				str = "Resetting Sampler    ";
				//ASamplerEnd()
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

	private bool PositionAutosampler()
	{
		//---FUNCTION TEMPORARILY COMMENTED AS NO AUTOSAMPLER
		return false;
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
			strTemp = gFuncGetFromINI(CONST_Section_AutoSampler, CONST_Key_WashTime, "10", CONST_AutoSampler_INI_FileName);
			WASH_TIME = Val(Trim(strTemp));

			//---TEMPORARILY COMMENTED
			//If Not (IsSamplerConnected()) Then
			//    Return False
			//End If
			//---TEMPORARILY COMMENTED

			if ((mblnIsAnalysisStarted)) {
				mstrAspirationMessage = "Positioning Autosampler for Aspirating Blank";
				mobjBgMsgAspirate.AspirationMessage = mstrAspirationMessage;

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

		//*************************************
		//CODE BY MANGESH 
		//*************************************
		string fname = "";
		string rsultfname = "";

		try {
			if ((!IsNothing(gobjNewMethod) & (int)gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).RunNumber > 0)) {
				//'rsultfname = "Saving " & gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).RunNumber & ".dat"
				//'rsultfname = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).RunNumber & ".dat"
				//'fname = rsultfname
				//'Call RawDataSave(fname)
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
		// Returns               : None
		// Purpose               : 
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

		//***************************************************
		//---CODE BY MANGESH 
		//***************************************************
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
				//lblAverageAbsorbance.Text = FormatNumber(abs, 3)
				//Saurabh 05 June 2007

				//lblCorrectedAbsorbance.Text = ""
				//lblConcentration.Text = ""

				lblCorrectedAbsorbance.Text = "";
				//by dinesh wagh on 2.2.2010

				//code added by : dinesh wagh on 1.2.2010
				//-------------------------------------------------------
				if (gobjNewMethod.OperationMode == EnumOperationMode.MODE_EMMISSION) {
					lblAverageAbsorbance.Text = FormatNumber(abs, 1);
				} else {
					lblAverageAbsorbance.Text = FormatNumber(abs, 3);
				}
				//----------------------------------------------------


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
					//lblSampleID.Text = strSampleName 

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
				} else {
					if ((SampleType == ClsAAS203.enumSampleType.STANDARD) & !IsNothing(mobjCurrentStandard)) {
						mobjCurrentStandard.Abs = abs;
					}

					if ((SampleType == ClsAAS203.enumSampleType.SAMPLE & !IsNothing(mobjCurrentSample))) {
						mobjCurrentSample.Abs = abs;
					}

					//Saurabh 05 June 2007
					//lblAverageAbsorbance.Text = FormatNumber(abs, gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfDecimalPlaces)
					//lblAverageAbsorbance.Text = FormatNumber(abs, 3)
					//Saurabh 05 June 2007

					//lblCorrectedAbsorbance.Text = ""

					//code added by : dinesh wagh on 1.2.2010
					//------------------------------------------------------
					if (gobjNewMethod.OperationMode == EnumOperationMode.MODE_EMMISSION) {
						lblAverageAbsorbance.Text = FormatNumber(abs, 1);
					} else {
						lblAverageAbsorbance.Text = FormatNumber(abs, 3);
					}
					//----------------------------------------
					lblCorrectedAbsorbance.Text = "";
					//by dinesh wagh on 2.2.2010

					nCurStd = mobjCurrentStandard;
					nCurSamp = mobjCurrentSample;
					nSampType = SampleType;
					lblank = mdblBlankAbsorbance;
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

		try {
			if (IsNothing(mobjAnalysisRawData)) {
				return false;
			}

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
		// Parameters Passed     : AASGraph Reference
		// Returns               : Double value
		// Purpose               : 
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
			if (gobjNewMethod.OperationMode == EnumOperationMode.MODE_EMMISSION) {
			//AASGraphAnalysis.YAxisMin = 0
			//AASGraphAnalysis.YAxisMax = 100
			//AASGraphAnalysis.YAxisMinorStep = 2
			} else {
				//-----Added By Pankaj on 10 May 2007
				//AASGraphAnalysis.YAxisMin = -0.2
				//AASGraphAnalysis.YAxisMax = 1.2
			}

			//gobjClsAAS203.Calculate_Analysis_Graph_Param(AASGraphAnalysis, ClsAAS203.enumChangeAxis.xyAxis)
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

		//*****************************************
		//---CODE BY MANGESH
		//*****************************************
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

			gobjClsAAS203.funcReadFilterSetting();

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
		//void SetXoldYold(int Xoldt, int Yoldt)
		//{
		//   Xold=Xoldt;
		//   Yold= Yoldt;
		//}
		try {
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
		//double	GetAvgValOfCurAnalysis()
		//{
		// return GetAvgValOfAnalysis(Raw->RawDataCur);        
		//}

		//*********************************************************
		//---CODE BY MANGESH
		//*********************************************************
		try {
			//return GetAvgValOfAnalysis(Raw->RawDataCur) 
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

		//*****************************************************
		//--- CODE BY MANGESH
		//*****************************************************
		double dblAbsorbance;
		int intTotal;
		Analysis.clsRawDataReadings.RAW_DATA objRawDataReading;
		int intCounter;

		try {
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

		//************************************************************
		//--- CODE BY MANGESH 
		//************************************************************
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

		//*****************************************************
		//--- CODE BY MANGESH
		//*****************************************************
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

		//*****************************************************************
		//--- CODE BY MANGESH
		//*****************************************************************
		double dblCorrectedAbsorbance;

		try {
			switch (intSampleType) {
				case ClsAAS203.enumSampleType.STANDARD:

					if (!IsNothing(nCurStd)) {
						//Saurabh 05 June 2007
						//lblAverageAbsorbance.Text = FormatNumber(abs, gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfDecimalPlaces)
						//lblAverageAbsorbance.Text = FormatNumber(dblAbsorbance, 3)
						//Saurabh 05 June 2007

						//code added by ; dinesh wagh on 1.2.2010
						//-----------------------------------------------
						if (gobjNewMethod.OperationMode == EnumOperationMode.MODE_EMMISSION) {
							lblAverageAbsorbance.Text = FormatNumber(dblAbsorbance, 1);
						} else {
							lblAverageAbsorbance.Text = FormatNumber(dblAbsorbance, 3);
						}
						//------------------------------------------------

						if ((gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.MeasurementMode == enumMeasurementMode.Integrate)) {
							dblAbsorbance -= mdblBlankAbsorbance;
						}

						nCurStd.Abs = dblAbsorbance;
						CheckValidStdAbs();
						//Saurabh 05 June 2007
						//lblCorrectedAbsorbance.Text = FormatNumber(dblAbsorbance, gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfDecimalPlaces)
						//lblCorrectedAbsorbance.Text = FormatNumber(dblAbsorbance, 3)
						//Saurabh 05 June 2007

						//code added by  : dinesh wagh on 2.2.2010
						//--------------------------------------------------------
						if (gobjNewMethod.OperationMode == EnumOperationMode.MODE_EMMISSION) {
							lblCorrectedAbsorbance.Text = FormatNumber(dblAbsorbance, 1);
						} else {
							lblCorrectedAbsorbance.Text = FormatNumber(dblAbsorbance, 3);
						}
						//--------------------------------------------------------



						//---Store Result Accurate upto AnalysisParameters.NumOfDecimalPlaces
						//lblConcentration.Text = FormatNumber(nCurStd.Concentration, gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfDecimalPlaces)


						if ((gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfStdRepeats > 1 | gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfSampleRepeats > 1)) {
							AddAbsRepeatStd(nCurStd.Abs, nCurStd.Concentration, nCurStd.AbsRepeat);
							CalculateAvgOfStd(nCurStd);
						}

						if ((gobjNewMethod.OperationMode == EnumOperationMode.MODE_EMMISSION)) {
							nCurStd.Abs = FormatNumber(nCurStd.Abs, 1);
						} else {
							nCurStd.Abs = FormatNumber(nCurStd.Abs, 3);
						}

					}
				case ClsAAS203.enumSampleType.SAMPLE:


					if (!IsNothing(nCurSamp)) {
						//Saurabh 05 June 2007
						//lblAverageAbsorbance.Text = FormatNumber(abs, gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfDecimalPlaces)
						//lblAverageAbsorbance.Text = FormatNumber(dblAbsorbance, 3)
						//Saurabh 05 June 2007

						//code added by ; dinesh wagh on 2.2.2010
						//--------------------------------------------------------
						if (gobjNewMethod.OperationMode == EnumOperationMode.MODE_EMMISSION) {
							lblAverageAbsorbance.Text = FormatNumber(dblAbsorbance, 1);
						} else {
							lblAverageAbsorbance.Text = FormatNumber(dblAbsorbance, 3);
						}
						//--------------------------------------------------


						if ((gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.MeasurementMode == enumMeasurementMode.Integrate)) {
							dblAbsorbance -= mdblBlankAbsorbance;
						}

						nCurSamp.Abs = dblAbsorbance;
						dblCorrectedAbsorbance = FormatNumber(dblAbsorbance, gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfDecimalPlaces);

						//Saurabh 05 June 2007
						//lblCorrectedAbsorbance.Text = FormatNumber(dblAbsorbance, gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfDecimalPlaces)
						//lblCorrectedAbsorbance.Text = FormatNumber(dblAbsorbance, 3)
						//Saurabh 05 June 2007

						//code added by ; dinesh wagh on 2.2.2010
						//------------------------------------------------
						if (gobjNewMethod.OperationMode == EnumOperationMode.MODE_EMMISSION) {
							lblCorrectedAbsorbance.Text = FormatNumber(dblAbsorbance, 1);
						} else {
							lblCorrectedAbsorbance.Text = FormatNumber(dblAbsorbance, 3);
						}
						//--------------------------------------------------

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
							nCurSamp.Abs = FormatNumber(nCurSamp.Abs, 1);
						} else {
							nCurSamp.Abs = FormatNumber(nCurSamp.Abs, 3);
						}

						//lblConcentration.Text = FormatNumber(nCurSamp.Conc, gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfDecimalPlaces) & "  ppm"


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
		//****************************************************
		//--- CODE BY MANGESH 
		//****************************************************
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
		//****************************************************
		//--- CODE BY MANGESH 
		//****************************************************
		try {
			//dblAbsorbance = Math.Round(dblAbsorbance, 3)
			//dblConcentration = Math.Round(dblConcentration, gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfDecimalPlaces)

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
		//****************************************************
		//--- CODE BY MANGESH 
		//****************************************************
		try {
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
		//******************************************************************
		//---CODE BY MANGESH
		//******************************************************************
		Method.clsAbsRepeatData objAbsRepeatData;

		try {
			objAbsRepeatData = new Method.clsAbsRepeatData();
			objAbsRepeatData.Abs = dblAbsorbance;
			objAbsRepeatData.Concentration = dblConcentration;
			objAbsRepeatData.Used = true;

			if (!IsNothing(objAbsRepeatDataCollection)) {
				objAbsRepeatDataCollection.Add(objAbsRepeatData);
			} else {
				objAbsRepeatDataCollection = new Method.clsAbsRepeatDataCollection();
				objAbsRepeatDataCollection.Add(objAbsRepeatData);
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
		//***********************************************************************
		//---CODE BY MANGESH
		//***********************************************************************
		try {
			if (IsNothing(objStandard) | IsNothing(objStandard.AbsRepeat)) {
				return;
			}

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
		//********************************************************************
		//---CODE BY MANGESH
		//********************************************************************
		try {
			if (IsNothing(objSample) | IsNothing(objSample.AbsRepeat)) {
				return;
			}

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
		//***************************************************************
		//--- ORIGINAL 16-bit CODE
		//***************************************************************
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
			for (intCounter = 0; intCounter <= objStandardsCollection.Count - 1; intCounter++) {
				if (object.ReferenceEquals(objStandardsCollection.item(intCounter), objCurrentStandard)) {
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			//---Returns the Previous Standard from Standard Collection.
			if (intCounter == 0) {
				return objStandardsCollection.item(0).Clone();
			} else {
				return objStandardsCollection.item(intCounter - 1).Clone();
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

	private Method.clsAnalysisSampleParameters GetPrevSamp(Method.clsAnalysisSampleParametersCollection objSamplesCollection, Method.clsAnalysisSampleParameters objCurrentSample)
	{
		//=====================================================================
		// Procedure Name        : GetPrevSamp
		// Parameters Passed     : SampleDataCollection and Current Sample
		// Returns               : Previous Sample
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 17-Jan-2007 03:25 pm
		// Revisions             : 1
		//=====================================================================
		//***************************************************************
		//--- ORIGINAL 16-bit CODE
		//***************************************************************
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
			for (intCounter = 0; intCounter <= objSamplesCollection.Count - 1; intCounter++) {
				if (object.ReferenceEquals(objSamplesCollection.item(intCounter), objCurrentSample)) {
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			//---Returns the Previous Sample from Sample Collection.
			if (intCounter == 0) {
				return objSamplesCollection.item(0).Clone();
			} else {
				return objSamplesCollection.item(intCounter - 1).Clone();
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

	private bool OnViewResults()
	{
		//=====================================================================
		// Procedure Name        : OnViewResults
		// Parameters Passed     : None
		// Returns               : True or false
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 01-Feb-2007 07:50 pm
		// Revisions             : 1
		//=====================================================================

		//*********************************************************
		//---- ORIGINAL CODE
		//*********************************************************
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

			if ((clsStandardGraph.GetTotStds(gobjNewMethod.QuantitativeDataCollection(mintRunNumberIndex).StandardDataCollection, true) > 0)) {
				//skp1 =(DLGPROC) MakeProcInstance((DLGPROC) ViewResultsProc,hInst);
				//DialogBox(hInst,"SHOWRESULTS", hpar, skp1);
				//FreeProcInstance(skp1);
				objfrmViewResults = new frmViewResults(true, 0, 0, gobjNewMethod);
				objfrmViewResults.ShowDialog();
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
		//******************************************************************
		//---- ORIGINAL CODE
		//******************************************************************
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
			//dblAbsorbance = gfuncGetValConvertedTo(dblAbsorbance, Method.Mode)

			if ((SampleType == ClsAAS203.enumSampleType.BLANK)) {
				mdblBlankAbsorbance = dblAbsorbance;

			} else if ((SampleType == ClsAAS203.enumSampleType.STANDARD)) {
				if (!IsNothing(mobjCurrentStandard)) {
					//CurStd->Data.Abs=abs;
					mobjCurrentStandard.Abs = dblAbsorbance;

					//GetValInString(abs, str, Method->Mode);
					//SetDlgItemText(hwnd,IDC_QAVABS, str);

					//Saurabh 05 June 2007
					//lblAverageAbsorbance.Text = FormatNumber(abs, gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfDecimalPlaces)
					//lblAverageAbsorbance.Text = FormatNumber(dblAbsorbance, 3)
					//Saurabh 05 June 2007


					//code added by ; dinesh wagh on 2.2.2010
					//-----------------------------------------
					if (gobjNewMethod.OperationMode == EnumOperationMode.MODE_EMMISSION) {
						lblAverageAbsorbance.Text = FormatNumber(dblAbsorbance, 1);
					} else {
						lblAverageAbsorbance.Text = FormatNumber(dblAbsorbance, 3);
					}
					//----------------------------------------------


					CheckValidStdAbs();

					//code added by ; dinesh wagh on 2.2.2010
					//--------------------------------------------
					if (gobjNewMethod.OperationMode == EnumOperationMode.MODE_EMMISSION) {
						lblCorrectedAbsorbance.Text = FormatNumber(dblAbsorbance, 1);
					} else {
						lblCorrectedAbsorbance.Text = FormatNumber(dblAbsorbance, 3);
					}
					//--------------------------------------------


					//GetValInString(abs, str, Method->Mode);
					//SetDlgItemText(hwnd,IDC_QCORABS, str);

					//Saurabh 05 June 2007
					//lblCorrectedAbsorbance.Text = FormatNumber(dblAbsorbance, gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfDecimalPlaces)
					//lblCorrectedAbsorbance.Text = FormatNumber(dblAbsorbance, 3)
					//Saurabh 05 June 2007

					//StoreResultAccurate(CurStd->Data.Conc, str, Method->QuantData->Param.No_Decimals);
					//SetDlgItemText(hwnd,IDC_QCONC, str);
					//Saurabh To format the concentration value upto 2 decimal places 20.07.07
					//lblConcentration.Text = FormatNumber(mobjCurrentStandard.Concentration, 2)
					//Saurabh To format the concentration value upto 2 decimal places 20.07.07
					//CurStd->Data.Abs = GetResultAccurate(CurStd->Data.Abs, 3);

				}

			} else if ((SampleType == ClsAAS203.enumSampleType.SAMPLE)) {
				if (!IsNothing(mobjCurrentSample)) {
					//GetValInString(abs, str, Method->Mode);
					//SetDlgItemText(hwnd,IDC_QAVABS, str);

					//Saurabh 05 June 2007
					//lblAverageAbsorbance.Text = FormatNumber(abs, gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfDecimalPlaces)
					//lblAverageAbsorbance.Text = FormatNumber(dblAbsorbance, 3)
					//Saurabh 05 June 2007

					//CurSamp->Data.Abs=abs;

					//code added by ; dinesh wagh on 2.2.2010
					//------------------------------------------
					if (gobjNewMethod.OperationMode == EnumOperationMode.MODE_EMMISSION) {
						lblAverageAbsorbance.Text = FormatNumber(dblAbsorbance, 1);
					} else {
						lblAverageAbsorbance.Text = FormatNumber(dblAbsorbance, 3);
					}
					//---------------------------------------


					mobjCurrentSample.Abs = dblAbsorbance;


					//code added by ; dinesh wagh on 2.2.2010
					//-------------------------------------------------
					if (gobjNewMethod.OperationMode == EnumOperationMode.MODE_EMMISSION) {
						lblCorrectedAbsorbance.Text = FormatNumber(dblAbsorbance, 1);
					} else {
						lblCorrectedAbsorbance.Text = FormatNumber(dblAbsorbance, 3);
					}
					//----------------------------------------------

					//GetValInString(abs, str, Method->Mode);
					//SetDlgItemText(hwnd,IDC_QCORABS, str);

					//Saurabh 05 June 2007
					//lblCorrectedAbsorbance.Text = FormatNumber(dblAbsorbance, gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfDecimalPlaces)
					//lblCorrectedAbsorbance.Text = FormatNumber(dblAbsorbance, 3)
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

					//StoreResultAccurate(CurSamp->Data.Conc, str, Method->QuantData->Param.No_Decimals);
					//strcat(str, "   ppm");
					//SetDlgItemText(hwnd,IDC_QCONC, str);
					//Saurabh To format the concentration value upto 2 decimal places 20.07.07
					//lblConcentration.Text = FormatNumber(mobjCurrentSample.Conc, 2) & "  ppm"
					//Saurabh To format the concentration value upto 2 decimal places 20.07.07

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

	#Region " Public Functions "

	public void StartNewAnalysis()
	{
		//=====================================================================
		// Procedure Name        : StartNewAnalysis
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : 
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

			mstrAspirationMessage = "Click Start button to Start Analysis.";
			gobjclsStandardGraph = new clsStandardGraph();
			intValid = CheckMethod();
			if ((intValid == 2)) {
				InitAnalysis();
			}
			mblnIsAnalysisStarted = false;

			NewAnalysis_Clicked(btnNewAnalysis, EventArgs.Empty);

			//Enable_Disable_Filter(False)
			//tlbbtnSaveReport.Enabled = False
			//btnEditData.Enabled = False

			mintAspirationTimerCounter = 0;

			tmrAspirationMsg.Enabled = true;

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

		//****************************************************************************************
		//AAS 16-Bit Software Code
		//****************************************************************************************
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

			//btnNextAnalysis.Enabled = mblnIsAnalysisStarted
			//btnBlankAnalysis.Enabled = mblnIsAnalysisStarted
			//btnRepeatLast.Enabled = mblnIsAnalysisStarted
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
		//***************************************************************
		//--- ORIGINAL CODE 
		//***************************************************************
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
			tmrAspirationMsg.Enabled = false;
			gobjMain.mobjController.Cancel();
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
							//Call gobjClsAAS203.funcSetRest_uvs_Condn(dblSelectedWavelength, True, lblUVWavelength, blnUVFlag)
						}
					}
				}
			}

			//'sprintf(line1,"%0.2f nm",Get_Cur_Wv());
			//'SetWindowText(GetDlgItem(hwnd,IDC_UVWV),line1);
			gobjCommProtocol.funcGet_Current_Wv(gobjInst.WavelengthCur);
			lblOptimizedWavelength.Text = "Optimized Wavelength : " + gobjInst.WavelengthCur.ToString + " nm";

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
			tmrAspirationMsg.Enabled = true;
			gobjMain.mobjController.Start(gobjclsBgFlameStatus);
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	#End Region

	#Region " Aspiration Related Functions "

	private void StartAspirationThread(int intStartTime, int intEndTime)
	{
		System.DateTime dtMinTime;
		System.DateTime dtMaxTime;
		int intOLDStartTime;
		int intOLDEndTime;

		try {
			mobjBgReadData = new clsBgReadData(intStartTime, intEndTime, SampleType, mobjCurrentStandard, mobjCurrentSample);
			mobjBgReadData.Filter_flag = Filter_flag;

			mobjBgReadData.AbsorbanceValueChanged += mobjBgReadData_AbsorbanceValueChanged;
			mobjBgReadData.AspirationMessageChanged += mobjBgReadData_AspirationMessageChanged;

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

			mobjBgReadData.Initialize(mController);
			mController.Start(mobjBgReadData);

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
		try {
			//lblAbsorbance.Text = Format(dblAbs, "0.000")

			//code added by ; dinesh wagh on 2.2.2010
			//--------------------------------------
			if (gobjNewMethod.OperationMode == EnumOperationMode.MODE_EMMISSION) {
				lblAbsorbance.Text = FormatNumber(dblAbs, 1);
			} else {
				lblAbsorbance.Text = FormatNumber(dblAbs, 3);
			}
		//-----------------------------------------


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
		// Purpose               : 
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
						//---For Standard
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
			////----- to Save Raw Data
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
			SaveRawDataFile();

			if ((gobjNewMethod.OperationMode == EnumOperationMode.MODE_UVABS)) {
				if (!Cancelled) {
					StoreCalculateDisplayQuantValueUvMode(mobjBgReadData.UVAbsorbance);
				}

			} else {
				dblAbsorbance = StoreCalculateDisplayQuantValue();
			}

			if ((SampleType == ClsAAS203.enumSampleType.STANDARD)) {
				if (!clsStandardGraph.CheckValidStdAbsEntry(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection)) {
					//If Not clsStandardGraph.CheckValidStdAbsEntry(mobjCurrentStandard) Then
					//gobjMessageAdapter.ShowMessage("Absorbance of the standard is less than or equal to the previous standard." & vbCrLf & _
					//"Press 'Repeat Last' button for aspirating the same standard again.", _
					//"Standard Aspiration Error", MessageHandler.clsMessageHandler.enumMessageType.ErrorMessage)

					gobjMessageAdapter.ShowMessage(constStandardAbsorbance);
					Application.DoEvents();
				}
			}

			if ((SampleType == ClsAAS203.enumSampleType.SAMPLE)) {
				if (!clsStandardGraph.CheckValidSampAbsEntry(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection, mdblAbsorbance)) {
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

			//SendMessage(hwnd, WM_COMMAND, 900, 0L) '//IDC_QANEXT, 0L);
			NextAnalysis_Clicked(btnNextAnalysis, EventArgs.Empty);

			if (AnaOver) {
				//btnRepeatLast.Enabled = False
			}
			btnReadData.Click += ReadData_Click;
			mblnAvoidProcessing = false;
			Application.DoEvents();
			gobjMain.mobjController.Start(gobjclsBgFlameStatus);

		//Application.DoEvents()
		//Call Aspirate()
		//Application.DoEvents()


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

			if (gobjNewMethod.OperationMode == EnumOperationMode.MODE_UVABS) {
				//lblUVAbsorbance.Text = "Absorbance : " & FormatNumber(Text, 2)
				AddInAnalysisRawData(xValue, yValue);
				return;
			} else {
				arrData = Text.Split(",");
				xValue = Val(arrData(0));
				yValue = Val(arrData(1));


				IsAvgAbs = false;
				if (arrData.Length > 2) {
					IsAvgAbs = true;
					dblAvgAbs = Val(arrData(2));
				}
			}

			//---Display Real Point of Reading
			//If intIsReal = 1 Then
			//---Display Abs Value on screen
			//lblAbsorbance.Text = Format(yValue, "0.000")
			//---Add only Real Point in the Analysis Raw Data Structure
			//Call AddInAnalysisRawData(xValue, yValue)

			//code added by ;dinesh wagh on 1.2.2010
			//---------------------------------------------
			if (gobjNewMethod.OperationMode == EnumOperationMode.MODE_EMMISSION) {
				lblAbsorbance.Text = FormatNumber(yValue, 1);
			} else {
				lblAbsorbance.Text = FormatNumber(yValue, 3);
			}
			//---------------------------------------



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
			//If xValue > AASGraphAnalysis.XAxisMax Or yValue > AASGraphAnalysis.YAxisMax Then
			//Call' Calculate_Analysis_Graph_Param(AASGraphAnalysis, xValue, yValue)
			//End If

			if (IsAvgAbs) {
				if ((Afirst)) {
					Afirst = false;
				//mobjGraphCurve = AASGraphAnalysis.StartOnlineGraph(strSampleName, Color.Black, AldysGraph.SymbolType.NoSymbol, True)
				//AASGraphAnalysis.PlotPoint(mobjGraphCurve, xValue, dblAvgAbs, True)
				//AASGraphAnalysis.PlotPoint(mobjGraphCurve, xValue, yValue, True)
				} else {
					//mobjGraphCurve.CL.Add(curveColor)
					//AASGraphAnalysis.PlotPoint(mobjGraphCurve, xValue, dblAvgAbs, True)
					//AASGraphAnalysis.PlotPoint(mobjGraphCurve, xValue, yValue, True)
				}
			}

		//AASGraphAnalysis.Refresh()
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
			MsgBox("Data Read Thread is failed", MsgBoxStyle.OKOnly);
			Application.DoEvents();
			btnReadData.Click += ReadData_Click;
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

	#Region "Commented Code"

	//Private Sub btnImport_Click(ByVal sender As Object, ByVal e As System.EventArgs)
	//    '=====================================================================
	//    ' Procedure Name        : tlbbtnLoad_Click
	//    ' Parameters Passed     : Object, EventArgs
	//    ' Returns               : 
	//    ' Purpose               : To load the Analysis already saved.
	//    ' Description           : 
	//    ' Assumptions           : 
	//    ' Dependencies          : 
	//    ' Author                : Saurabh S
	//    ' Created               : 05.10.06
	//    ' Revisions             : 
	//    '=====================================================================
	//    Dim objWait As New CWaitCursor
	//    Dim intRunNumberIndex As Long
	//    Dim intCounter As Integer
	//    Dim intCount As Integer
	//    Dim strRunNo As String
	//    Dim objfrmLoadAnalysis As New frmLoadAnalysis
	//    Dim objClsMethod As clsMethod
	//    Dim intSelectedMethodID As Integer
	//    Dim lngSelectedRunNumber As Long
	//    Try
	//        'tlbbtnLoad.SuspendEvents()

	//        objfrmLoadAnalysis.GroupBox2.Visible = False
	//        objfrmLoadAnalysis.gbMultiElementReport.Visible = False
	//        If objfrmLoadAnalysis.ShowDialog() = DialogResult.Cancel Then
	//            Exit Sub
	//        End If

	//        intSelectedMethodID = objfrmLoadAnalysis.SelectedMethodID
	//        lngSelectedRunNumber = objfrmLoadAnalysis.SelectedRunNumber
	//        objfrmLoadAnalysis.Close()
	//        objfrmLoadAnalysis.Dispose()
	//        '//-----
	//        mobjAnalysisRawData = Nothing
	//        mobjAnalysisRawData = New Analysis.clsRawDataCollection

	//        mobjBlankRawData = Nothing
	//        mobjStandardRawData = Nothing
	//        mobjSampleRawData = Nothing

	//        intRunNumberIndex = modGlobalFunctions.gfuncGetSelectedMethodRunNumberIndex(mintSelectedMethodID, mlngSelectedRunNumber)

	//        For intCounter = 0 To gobjMethodCollection.Count - 1
	//            If gobjMethodCollection.item(intCounter).MethodID = intSelectedMethodID Then

	//                'mobjClsMethod = gobjMethodCollection.item(intCounter).Clone()

	//                'mobjClsMethod.QuantitativeDataCollection.Item(intRunNumberIndex).AnalysisRawData(0).SampleType = clsRawData.enumSampleType.BLANK
	//                'Dim int As Integer
	//                For intRunNumberIndex = 0 To gobjMethodCollection.item(intCounter).QuantitativeDataCollection.Count - 1
	//                    If lngSelectedRunNumber = gobjMethodCollection.item(intCounter).QuantitativeDataCollection.Item(intRunNumberIndex).RunNumber Then

	//                        Afirst = False

	//                        'mobjAnalysisRawData.Add(mobjStandardRawData)


	//                        'Select Case mobjAnalysisRawData(i).SampleType
	//                        'Case (ClsAAS203.enumSampleType.STANDARD)
	//                        'If Not IsNothing(mobjCurrentStandard) Then
	//                        '    If (gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfStdRepeats) > 1 Then '( Method->QuantData->Param.ConcRepeat>1)
	//                        '        If (mblnIsAutosampler And mblnIsAnalysisStarted) Then
	//                        '            mstrAspirationMessage = aspMsg & mobjCurrentStandard.StdName & " (Repeat #" & CurRepeat & ") from Position " & mobjCurrentStandard.PositionNumber
	//                        '            SetAutoSampler(mobjCurrentStandard.PositionNumber, True)
	//                        '        Else
	//                        '            mstrAspirationMessage = aspMsg & .StdName & "(Repeat #" & CurRepeat & ") and Click &READ or press <SPACEBAR>"
	//                        '        End If
	//                        '    Else
	//                        '        If (mblnIsAutosampler And mblnIsAnalysisStarted) Then
	//                        '            mstrAspirationMessage = aspMsg & mobjCurrentStandard.StdName & " from Position " & mobjCurrentStandard.PositionNumber
	//                        '            SetAutoSampler(mobjCurrentStandard.PositionNumber, True)
	//                        '        Else
	//                        '            mstrAspirationMessage = aspMsg & mobjCurrentStandard.StdName & " and Click &READ or press <SPACEBAR>"
	//                        '        End If
	//                        '    End If
	//                        'End If

	//                        '    Case (ClsAAS203.enumSampleType.STANDARD)
	//                        '        If Not IsNothing(mobjCurrentSample) Then
	//                        '            If (gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfSampleRepeats > 1) Then
	//                        '                If (mblnIsAutosampler And mblnIsAnalysisStarted) Then
	//                        '                    mstrAspirationMessage = aspMsg & mobjCurrentSample.SampleName & " (Repeat #" & CurRepeat & ") from Position " & mobjCurrentSample.SampPosNumber
	//                        '                    SetAutoSampler(mobjCurrentSample.SampPosNumber, True)
	//                        '                Else
	//                        '                    mstrAspirationMessage = aspMsg & mobjCurrentSample.SampleName & " (Repeat #" & CurRepeat & ") and Click &READ or press <SPACEBAR> "
	//                        '                End If
	//                        '            Else
	//                        '                If (mblnIsAutosampler And mblnIsAnalysisStarted) Then
	//                        '                    mstrAspirationMessage = aspMsg & mobjCurrentSample.SampleName & " from Position " & mobjCurrentSample.SampPosNumber
	//                        '                    SetAutoSampler(mobjCurrentSample.SampPosNumber, True)
	//                        '                Else
	//                        '                    mstrAspirationMessage = aspMsg & mobjCurrentSample.SampleName & " and Click &READ or press <SPACE BAR>"
	//                        '                End If
	//                        '            End If
	//                        '        End If
	//                        '    Case Else

	//                        'End Select
	//                        '//----
	//                        Exit For

	//                    End If

	//                Next
	//                Dim i As Integer
	//                intIEnumCollLocationStd = 0
	//                intIEnumCollLocationSamp = 0
	//                For i = 0 To gobjMethodCollection.item(intCounter).QuantitativeDataCollection.Item(intRunNumberIndex).AnalysisRawData.Count - 1
	//                    mobjAnalysisRawData.Add(gobjMethodCollection.item(intCounter).QuantitativeDataCollection.Item(intRunNumberIndex).AnalysisRawData(i))
	//                    'mobjClsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisRawData = mobjAnalysisRawData
	//                    If gobjMethodCollection.item(intCounter).QuantitativeDataCollection.Item(intRunNumberIndex).AnalysisRawData(i).SampleType = clsRawData.enumSampleType.SAMPLE Then
	//                        intIEnumCollLocationSamp += 1
	//                    ElseIf gobjMethodCollection.item(intCounter).QuantitativeDataCollection.Item(intRunNumberIndex).AnalysisRawData(i).SampleType = clsRawData.enumSampleType.STANDARD Then
	//                        intIEnumCollLocationStd += 1
	//                    End If
	//                Next

	//                '//----
	//                'mobjClsMethod.QuantitativeDataCollection.Item(intRunNumberIndex).StandardDataCollection(0)
	//                'intIEnumCollLocationStd = gobjMethodCollection.item(intCounter).QuantitativeDataCollection(intRunNumberIndex).StandardDataCollection.Count
	//                'intIEnumCollLocationSamp = gobjMethodCollection.item(intCounter).QuantitativeDataCollection(intRunNumberIndex).SampleDataCollection.Count

	//                mobjCurrentStandard = Nothing
	//                mobjCurrentSample = Nothing
	//                If intIEnumCollLocationSamp <= 0 Then
	//                    'mobjCurrentStandard = gobjMethodCollection.item(intCounter).QuantitativeDataCollection(intRunNumberIndex).StandardDataCollection(intIEnumCollLocationStd - 1)
	//                    Call funcGetCurrentStandard(mobjCurrentStandard)
	//                Else
	//                    'mobjCurrentSample = gobjMethodCollection.item(intCounter).QuantitativeDataCollection(intRunNumberIndex).SampleDataCollection(intIEnumCollLocationSamp - 1)
	//                    Call funcGetCurrentSample(mobjCurrentSample)
	//                End If



	//                Dim i1 As Integer = gobjMethodCollection.item(intCounter).QuantitativeDataCollection.Item(intRunNumberIndex).AnalysisRawData(i - 1).Readings.Count - 1

	//                mobjBgReadData.CEndTime = gobjMethodCollection.item(intCounter).QuantitativeDataCollection(intRunNumberIndex).AnalysisRawData(i - 1).Readings(i1).XTime
	//                mEndTime = mobjBgReadData.CEndTime
	//                SampleType = gobjMethodCollection.item(intCounter).QuantitativeDataCollection.Item(intRunNumberIndex).AnalysisRawData(i - 1).SampleType
	//                'Call NextAnalysis_Clicked(btnNextAnalysis, EventArgs.Empty)
	//                Application.DoEvents()
	//                Call Aspirate()
	//                Application.DoEvents()
	//                '//----- Sachin Dokhale
	//                'StdAnalysed=TRUE;
	//                'toreported=TRUE;
	//                'InvalidateRect(hwnd, NULL, TRUE);
	//                'EnableWindow(GetDlgItem(hwnd,IDC_SAVEREPORT), StdAnalysed);
	//                StdAnalysed = True
	//                toreported = True
	//                'btnSave.Enabled = StdAnalysed
	//                '//-----

	//                'If gobjNewMethod Is Nothing Then
	//                '    gobjNewMethod = objClsMethod
	//                'End If
	//                'If gobjNewMethod.MethodID <> objClsMethod.MethodID Then
	//                '    '---Currently Selected Method is Changed.. Notify user for Reprocess Analysis
	//                '    '---If Current Method is in Analysis then Prevent user for Changing method
	//                '    gobjNewMethod = objClsMethod
	//                '    'RaiseEvent CurrentMethodChannged(objClsMethod.MethodID)
	//                'End If


	//                'Call funcShowMethodGeneralInfo(mobjClsMethod, strRunNo)
	//                Select Case gobjMethodCollection.item(intCounter).OperationMode
	//                    Case EnumOperationMode.MODE_UVABS
	//                        'AASGraphAnalysis.Visible = False
	//                    Case Else
	//                        strRunNo = gobjMethodCollection.item(intCounter).QuantitativeDataCollection.Item(intRunNumberIndex).RunNumber
	//                        'AASGraphAnalysis.Visible = True
	//                        'Call gobjClsAAS203.subShowGraphPreview(Me.AASGraphAnalysis, mobjGraphCurve, strRunNo, gobjMethodCollection.item(intCounter))
	//                        'AASGraphAnalysis.Invalidate()
	//                        'AASGraphAnalysis.IsShowGrid = True      'Saurabh To show Grid 19.07.07
	//                        'AASGraphAnalysis.Refresh()
	//                        Me.Refresh()
	//                        Application.DoEvents()
	//                End Select
	//                'btnStandardGraph.Enabled = True
	//                'btnSampleGraph.Enabled = True
	//                'btnViewResults.Enabled = True
	//                'btnReports.Enabled = True
	//                'btnPrintGraph.Enabled = True
	//                'btnReportOptions.Enabled = True
	//                'btnExportReport.Enabled = True
	//                'btnEditData.Enabled = True

	//                Exit For

	//            End If
	//        Next

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
	//        'tlbbtnLoad.ResumeEvents()
	//        '---------------------------------------------------------
	//    End Try
	//End Sub

	//Private Sub subGetRowDatafileInfoIntoObject(ByVal objClsMethodIn As clsMethod)
	//    Try
	//        ' objClsMethodIn.InstrumentCondition()

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

	//Private Sub btnExportReport_Click(ByVal sender As Object, ByVal e As System.EventArgs)
	//    '=====================================================================
	//    ' Procedure Name        : tlbbtnExportReport_Click
	//    ' Parameters Passed     : Object, EventArgs
	//    ' Returns               : 
	//    ' Purpose               : 
	//    ' Description           : 
	//    ' Assumptions           : 
	//    ' Dependencies          : 
	//    ' Author                : Saurabh S & Sachin Dokhale
	//    ' Created               : 05.10.06
	//    ' Revisions             : 
	//    '=====================================================================
	//    Dim objWait As New CWaitCursor
	//    Dim intSelectId As Integer
	//    Dim intCount, intCount1 As Integer
	//    Dim A1() As Double = {0, 0, 0, 0, 0, 0}
	//    Try
	//        'Added By Pankaj Fri 18 May 07
	//        If (gstructSettings.Enable21CFR = True) Then
	//            If Not funcCheckActivityAuthentication(enumActivityAuthentication.Export, gstructUserDetails.Access) Then
	//                Return
	//                Exit Sub
	//            End If
	//            gfuncInsertActivityLog(EnumModules.Export, "Export Accessed")
	//        End If

	//        'tlbbtnLoad.SuspendEvents()
	//        'mobjClsDataFileReport.MethodID = mintSelectedMethodID
	//        'mobjClsDataFileReport.RunNumber = mintSelectedRunNumber
	//        'For intCount = 0 To gobjMethodCollection.Count - 1
	//        '    If mintSelectedMethodID = gobjMethodCollection(intCount).MethodID Then
	//        '        intSelectId = intCount
	//        '        mobjClsDataFileReport.MethodID = intCount
	//        '        Exit For
	//        '    End If
	//        'Next
	//        If (toreported) Then 'OR NOT Method->RepReady )
	//            gobjClsAAS203.SaveQuantResults(gobjNewMethod, A1, 1, False)
	//            toreported = False
	//        End If
	//        If StdAnalysed Or AnaOver Or mblnIsAnalysisStarted Then 'Or ManualEntry Then
	//            For intCount = 0 To gobjMethodCollection.Count - 1
	//                'If mintSelectedMethodID = gobjMethodCollection(intCount).MethodID Then
	//                If gobjNewMethod.MethodID = gobjMethodCollection(intCount).MethodID Then
	//                    'intSelectIDIndex = intCount
	//                    intSelectId = intCount
	//                    'mobjClsDataFileReport.MethodID = intCount
	//                    mobjClsDataFileReport.MethodID = gobjMethodCollection(intCount).MethodID
	//                    For intCount1 = 0 To gobjMethodCollection(intSelectId).QuantitativeDataCollection.Count - 1
	//                        If mlngSelectedRunNumber = CInt(gobjMethodCollection(intSelectId).QuantitativeDataCollection(intCount1).RunNumber) Then
	//                            mobjClsDataFileReport.RunNumber = mlngSelectedRunNumber
	//                            Call mobjClsDataFileReport.funcDatafileExport(gobjMethodCollection(intSelectId).QuantitativeDataCollection(intCount1).ReportParameters)
	//                            Exit For
	//                        End If
	//                    Next
	//                    Exit For
	//                End If
	//            Next

	//            'For intCount = 0 To gobjMethodCollection(intSelectId).QuantitativeDataCollection.Count - 1
	//            '    If mlngSelectedRunNumber = CInt(gobjMethodCollection(intSelectId).QuantitativeDataCollection(intCount).RunNumber) Then
	//            '        mobjClsDataFileReport.RunNumber = mlngSelectedRunNumber
	//            '        Call mobjClsDataFileReport.funcDatafileExport()
	//            '        Exit For
	//            '    End If
	//            'Next
	//            'For intCount = 0 To gobjMethodCollection(intSelectId).QuantitativeDataCollection.Count - 1
	//            '    If mintSelectedRunNumber = CInt(gobjMethodCollection(intSelectId).QuantitativeDataCollection(intCount).RunNumber) Then

	//            '        mobjClsDataFileReport.RunNumber = mintSelectedRunNumber
	//            '        Exit For
	//            '    End If
	//            'Next
	//            'Call mobjClsDataFileReport.funcDatafileExport()
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

	//Private Sub btnEditData_Clicked(ByVal sender As Object, ByVal e As EventArgs)
	//    '=====================================================================
	//    ' Procedure Name        : btnEditData_Clicked
	//    ' Parameters Passed     : object, EventArgs
	//    ' Returns               : None
	//    ' Purpose               : 
	//    ' Description           : 
	//    ' Assumptions           : 
	//    ' Dependencies          : 
	//    ' Author                : Mangesh Shardul
	//    ' Created               : 16-Mar-2007 12:45 pm
	//    ' Revisions             : 1
	//    '=====================================================================
	//    '****************************************************************
	//    '---- ORIGINAL CODE
	//    '****************************************************************
	//    'BOOL	OnViewRepeats(HWND	hpar)
	//    '{
	//    '   BOOL	flag = FALSE;
	//    '   DLGPROC  skp1;
	//    '   if (Method->QuantData==NULL)
	//    '	    return flag;
	//    '   if ((Method->QuantData->Param.Repeat>1 || Method->QuantData->Param.ConcRepeat>1 )&&  FindSamplesAnalysed()>=1) 
	//    '   {
	//    '	    skp1 =(DLGPROC) MakeProcInstance((DLGPROC) OnViewRepeatsProc,hInst);
	//    '	    flag = DialogBox(hInst,"QVIEWRPTS", hpar, skp1);
	//    '	    FreeProcInstance(skp1);
	//    '  }
	//    '   Else
	//    '	    flag = OnEditStdSamples(hpar);
	//    '   return flag;
	//    '}
	//    '****************************************************************
	//    Dim flag As Boolean = False
	//    Dim objfrmDeleteStdNSam As frmDeleteStdNSam
	//    Dim objfrmViewRepeatResults As frmViewRepeatResults

	//    Try
	//        If IsNothing(gobjNewMethod.QuantitativeDataCollection) Then
	//            Return
	//        End If

	//        If ((gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfSampleRepeats > 1 _
	//          Or gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfStdRepeats > 1) _
	//          And clsStandardGraph.FindSamplesAnalysed(gobjNewMethod, mintRunNumberIndex) >= 1) Then

	//            objfrmViewRepeatResults = New frmViewRepeatResults(gobjNewMethod, mintRunNumberIndex)
	//            objfrmViewRepeatResults.ShowDialog()
	//            objfrmViewRepeatResults.Close()
	//            objfrmViewRepeatResults.Dispose()
	//            objfrmViewRepeatResults = Nothing
	//        Else
	//            'flag = OnEditStdSamples()
	//            objfrmDeleteStdNSam = New frmDeleteStdNSam(gobjNewMethod, mintRunNumberIndex)
	//            objfrmDeleteStdNSam.ShowDialog()
	//            objfrmDeleteStdNSam.Close()
	//            objfrmDeleteStdNSam.Dispose()
	//            objfrmDeleteStdNSam = Nothing
	//            flag = True
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
	//        '---------------------------------------------------------
	//    End Try
	//End Sub


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

	//Private Sub AASGraphAnalysis_GraphScaleChanged(ByVal XMin As Double, ByVal XMax As Double, ByVal YMin As Double, ByVal YMax As Double) Handles AASGraphAnalysis.GraphScaleChanged
	//    AASGraphAnalysis.AldysPane.XAxis.MinorStepAuto = False
	//    AASGraphAnalysis.AldysPane.XAxis.StepAuto = False
	//    AASGraphAnalysis.AldysPane.YAxis.MinorStepAuto = False
	//    AASGraphAnalysis.AldysPane.YAxis.StepAuto = False

	//    '---changed by deepak on 29.04.07
	//    'AASGraphAnalysis.YAxisStep = 0.1
	//    AASGraphAnalysis.YAxisStep = 0.2
	//    'AASGraphAnalysis.YAxisMinorStep = 0.05
	//    AASGraphAnalysis.YAxisMinorStep = 0.1
	//    '---changed by deepak on 29.04.07

	//    AASGraphAnalysis.Refresh()
	//End Sub

	//Private Sub cmdChangeScale_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdChangeScale.Click
	//    '=====================================================================
	//    ' Procedure Name        : cmdChangeScale_Click
	//    ' Parameters Passed     : Object,EventArgs
	//    ' Returns               : None
	//    ' Purpose               : 
	//    ' Description           : calculte change scale
	//    ' Assumptions           : 
	//    ' Dependencies          : 
	//    ' Author                : Pankaj Bamb
	//    ' Created               : 1.05.07
	//    ' Revisions             : 
	//    '=====================================================================
	//    Dim objWait As New CWaitCursor
	//    Dim objfrmChangeScale As frmChangeScale

	//    Try
	//        objfrmChangeScale = New frmChangeScale(mobjParameters)
	//        objfrmChangeScale.funcSetValidatingScale(gobjInst.Mode)
	//        objfrmChangeScale.lblXAxis.Visible = False
	//        '-------------Added By Pankaj 11 May 07 for showing default scale on change form
	//        objfrmChangeScale.SpectrumParameter.XaxisMin = AASGraphAnalysis.XAxisMin
	//        objfrmChangeScale.SpectrumParameter.XaxisMax = AASGraphAnalysis.XAxisMax

	//        objfrmChangeScale.SpectrumParameter.YaxisMin = AASGraphAnalysis.YAxisMin
	//        objfrmChangeScale.SpectrumParameter.YaxisMax = AASGraphAnalysis.YAxisMax
	//        '------------------------
	//        If objfrmChangeScale.ShowDialog() = DialogResult.OK Then
	//            If Not objfrmChangeScale.SpectrumParameter Is Nothing Then
	//                mobjParameters.XaxisMax = objfrmChangeScale.SpectrumParameter.XaxisMax
	//                mobjParameters.XaxisMin = objfrmChangeScale.SpectrumParameter.XaxisMin
	//                mobjParameters.YaxisMax = objfrmChangeScale.SpectrumParameter.YaxisMax
	//                mobjParameters.YaxisMin = objfrmChangeScale.SpectrumParameter.YaxisMin
	//            End If
	//            AASGraphAnalysis.XAxisMin = mobjParameters.XaxisMin
	//            AASGraphAnalysis.XAxisMax = mobjParameters.XaxisMax
	//            AASGraphAnalysis.YAxisMin = mobjParameters.YaxisMin
	//            AASGraphAnalysis.YAxisMax = mobjParameters.YaxisMax

	//            Call gobjClsAAS203.Calculate_Analysis_Graph_Param(AASGraphAnalysis, ClsAAS203.enumChangeAxis.xyAxis)

	//        End If
	//        objfrmChangeScale.Close()


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
	//        objfrmChangeScale.Dispose()
	//        If Not objWait Is Nothing Then
	//            objWait.Dispose()
	//        End If
	//        'mblnAvoidProcessing = False
	//        '---------------------------------------------------------
	//    End Try
	//End Sub

	//Private Sub tlbbtnExportReport_Click(ByVal sender As Object, ByVal e As System.EventArgs)
	//    '=====================================================================
	//    ' Procedure Name        : tlbbtnExportReport_Click
	//    ' Parameters Passed     : Object, EventArgs
	//    ' Returns               : 
	//    ' Purpose               : 
	//    ' Description           : 
	//    ' Assumptions           : 
	//    ' Dependencies          : 
	//    ' Author                : Saurabh S & Sachin Dokhale
	//    ' Created               : 05.10.06
	//    ' Revisions             : 
	//    '=====================================================================
	//    Dim objWait As New CWaitCursor
	//    Dim intSelectId As Integer
	//    Dim intCount As Integer
	//    Try
	//        'Added By Pankaj Fri 18 May 07
	//        If (gstructSettings.Enable21CFR = True) Then
	//            If Not funcCheckActivityAuthentication(enumActivityAuthentication.Export, gstructUserDetails.Access) Then
	//                Return
	//                Exit Sub
	//            End If
	//            gfuncInsertActivityLog(EnumModules.Export, "Export Accessed")
	//        End If

	//        '    tlbbtnLoad.SuspendEvents()
	//        'mobjClsDataFileReport.MethodID = mintSelectedMethodID
	//        'mobjClsDataFileReport.RunNumber = mintSelectedRunNumber
	//        'For intCount = 0 To gobjMethodCollection.Count - 1
	//        '    If mintSelectedMethodID = gobjMethodCollection(intCount).MethodID Then
	//        '        intSelectId = intCount
	//        '        mobjClsDataFileReport.MethodID = intCount
	//        '        Exit For
	//        '    End If
	//        'Next
	//        Dim strRunNo As String
	//        'strRunNo = mobjClsMethod.QuantitativeDataCollection.Item(intCount).RunNumber


	//        For intCount = 0 To gobjMethodCollection.Count - 1
	//            If mintSelectedMethodID = gobjMethodCollection(intCount).MethodID Then
	//                'intSelectIDIndex = intCount
	//                intSelectId = intCount
	//                'mobjClsDataFileReport.MethodID = intCount
	//                mobjClsDataFileReport.MethodID = gobjMethodCollection(intCount).MethodID
	//                Exit For
	//            End If
	//        Next
	//        strRunNo = gobjNewMethod.QuantitativeDataCollection.Item(0).RunNumber
	//        For intCount = 0 To gobjMethodCollection(intSelectId).QuantitativeDataCollection.Count - 1
	//            If strRunNo = CInt(gobjMethodCollection(intSelectId).QuantitativeDataCollection(intCount).RunNumber) Then
	//                mobjClsDataFileReport.RunNumber = CLng(strRunNo)
	//                Exit For
	//            End If
	//        Next

	//        'For intCount = 0 To gobjMethodCollection(intSelectId).QuantitativeDataCollection.Count - 1
	//        '    If mintSelectedRunNumber = CInt(gobjMethodCollection(intSelectId).QuantitativeDataCollection(intCount).RunNumber) Then

	//        '        mobjClsDataFileReport.RunNumber = mintSelectedRunNumber
	//        '        Exit For
	//        '    End If
	//        'Next
	//        'Call mobjClsDataFileReport.funcDatafileExport()

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


	//Private Sub btnExtinguish_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExtinguish.Click
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

	//Private Sub btnIgnite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIgnite.Click
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

	//Private Sub tlbbtnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
	//    '=====================================================================
	//    ' Procedure Name        : tlbbtnBack_Click
	//    ' Parameters Passed     : Object,EventArgs
	//    ' Returns               : None
	//    ' Purpose               : To exit frmAnalysis and load frmMDIMain form
	//    ' Description           : 
	//    ' Assumptions           : 
	//    ' Dependencies          : 
	//    ' Author                : Saurabh S
	//    ' Created               : 25.09.06
	//    ' Revisions             : 
	//    '=====================================================================
	//    Dim objWait As New CWaitCursor
	//    Try
	//        'tlbbtnBack.SuspendEvents()
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
	//        'tlbbtnBack.ResumeEvents()
	//        '---------------------------------------------------------
	//    End Try
	//End Sub

	//Private Sub tlbbtnStandardGraph_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
	//    '=====================================================================
	//    ' Procedure Name        : tlbbtnStandardGraph_Click
	//    ' Parameters Passed     : Object, EventArgs
	//    ' Returns               : None
	//    ' Purpose               : 
	//    ' Description           : 
	//    ' Assumptions           : 
	//    ' Dependencies          : 
	//    ' Author                : Mangesh Shardul
	//    ' Created               : 17-Jan-2007 03:25 pm
	//    ' Revisions             : 1
	//    '=====================================================================
	//    'case IDC_QASTDGRAPH:
	//    '   if (StdAnalysed || ManualEntry){
	//    '       If (Create_Standard_Sample_Curve(hwnd, False)) Then
	//    '           toreported=TRUE;
	//    '   }
	//    'break;

	//    Dim objWait As New CWaitCursor

	//    Try
	//        'tlbbtnStandardGraph.SuspendEvents()

	//        If StdAnalysed Then 'Or ManualEntry Then
	//            If gobjclsStandardGraph.Create_Standard_Sample_Curve(False, True, 0, 0, gobjNewMethod) Then
	//                toreported = True
	//            End If
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
	//        objWait.Dispose()
	//        'tlbbtnStandardGraph.ResumeEvents()
	//        '---------------------------------------------------------
	//    End Try
	//End Sub

	//Private Sub tlbbtnSampleGraph_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
	//    '=====================================================================
	//    ' Procedure Name        : tlbbtnSampleGraph_Click
	//    ' Parameters Passed     : Object, EventArgs
	//    ' Returns               : None
	//    ' Purpose               : 
	//    ' Description           : 
	//    ' Assumptions           : 
	//    ' Dependencies          : 
	//    ' Author                : Mangesh Shardul
	//    ' Created               : 17-Jan-2007 03:25 pm
	//    ' Revisions             : 1
	//    '=====================================================================
	//    'case IDC_QASAMPGRAPH:
	//    '   if (StdAnalysed || ManualEntry){
	//    '       If (Create_Standard_Sample_Curve(hwnd, TRUE)) Then
	//    '	        toreported=TRUE;
	//    '   }
	//    '   break;

	//    Dim objWait As New CWaitCursor

	//    Try
	//        'tlbbtnSampleGraph.SuspendEvents()

	//        If StdAnalysed Then 'Or ManualEntry Then
	//            If gobjclsStandardGraph.Create_Standard_Sample_Curve(True, True, 0, 0, gobjNewMethod) Then
	//                toreported = True
	//            End If
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
	//        'tlbbtnSampleGraph.ResumeEvents()
	//        '---------------------------------------------------------
	//    End Try
	//End Sub

	//Private Sub tlbbtnViewResults_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
	//    '=====================================================================
	//    ' Procedure Name        : tlbbtnViewResults_Click
	//    ' Parameters Passed     : Object, EventArgs
	//    ' Returns               : None
	//    ' Purpose               : 
	//    ' Description           : 
	//    ' Assumptions           : 
	//    ' Dependencies          : 
	//    ' Author                : Mangesh Shardul
	//    ' Created               : 17-Jan-2007 03:25 pm
	//    ' Revisions             : 1
	//    '=====================================================================
	//    'case IDC_QARESULTS:
	//    'if (StdAnalysed||AnaOver ||Started ||ManualEntry)
	//    ' OnViewResults(hwnd);
	//    'break;

	//    Dim objWait As New CWaitCursor

	//    Try
	//        'tlbbtnViewResults.SuspendEvents()

	//        If StdAnalysed Or AnaOver Or mblnIsAnalysisStarted Then 'Or ManualEntry Then
	//            OnViewResults()
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
	//        'tlbbtnViewResults.ResumeEvents()
	//        '---------------------------------------------------------
	//    End Try
	//End Sub

	//Private Sub tlbbtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
	//    '=====================================================================
	//    ' Procedure Name        : tlbbtnReports_Click
	//    ' Parameters Passed     : Object, EventArgs
	//    ' Returns               : None
	//    ' Purpose               : 
	//    ' Description           : 
	//    ' Assumptions           : 
	//    ' Dependencies          : 
	//    ' Author                : Mangesh Shardul
	//    ' Created               : 17-Jan-2007 03:25 pm
	//    ' Revisions             : 1
	//    '=====================================================================

	//    'case IDC_QAREPORT:
	//    '   if (toreported||!Method->RepReady )
	//    '	{
	//    '	    SaveQuantResults(hwnd, Method, A1,0);
	//    '	    toreported=FALSE;
	//    '	}
	//    '	if (Method->RepReady )
	//    '	    OnReportPrint(hwnd, Method);
	//    '   break;

	//    Dim objWait As New CWaitCursor
	//    Dim A1() As Double = {0, 0, 0, 0, 0, 0}

	//    Try
	//        'tlbbtnReports.SuspendEvents()

	//        If (toreported) Then 'OR NOT Method->RepReady )
	//            gobjClsAAS203.SaveQuantResults(gobjNewMethod, A1, False)
	//            toreported = False
	//        End If

	//        'if (gobjNewMethod.RepReady )
	//        '   OnReportPrint(gobjNewMethod)
	//        'end if

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
	//        'tlbbtnReports.ResumeEvents()
	//        '---------------------------------------------------------
	//    End Try
	//End Sub

	//Private Sub tlbbtnReports_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
	//    '=====================================================================
	//    ' Procedure Name        : tlbbtnReports_Click
	//    ' Parameters Passed     : Object, EventArgs
	//    ' Returns               : None
	//    ' Purpose               : 
	//    ' Description           : 
	//    ' Assumptions           : 
	//    ' Dependencies          : 
	//    ' Author                : Mangesh Shardul
	//    ' Created               : 17-Jan-2007 03:25 pm
	//    ' Revisions             : 1
	//    '=====================================================================

	//    'case IDC_QAREPORT:
	//    '   if (toreported||!Method->RepReady )
	//    '	{
	//    '	    SaveQuantResults(hwnd, Method, A1,0);
	//    '	    toreported=FALSE;
	//    '	}
	//    '	if (Method->RepReady )
	//    '	    OnReportPrint(hwnd, Method);
	//    '   break;

	//    Dim objWait As New CWaitCursor
	//    Dim objClsDataFileReport As New clsDataFileReport
	//    Dim intSelectIDIndex As Integer
	//    Dim intCount As Integer
	//    Dim intSelectedRunNumber As Integer
	//    Dim intSelectedMethodID As Integer
	//    Dim A1() As Double = {0, 0, 0, 0, 0, 0}

	//    Try

	//        'If toreported Then
	//        '-----Added By Pankaj Fri 18 May 07
	//        If (gstructSettings.Enable21CFR = True) Then
	//            If Not funcCheckActivityAuthentication(enumActivityAuthentication.Print, gstructUserDetails.Access) Then
	//                Return
	//                Exit Sub
	//            End If
	//            gfuncInsertActivityLog(EnumModules.Print, "Print Analysis Report Accessed")
	//        End If
	//        '------
	//        'tlbbtnLoad.SuspendEvents()
	//        'tlbbtnReports.SuspendEvents()
	//        If (toreported) Then 'OR NOT Method->RepReady )
	//            gobjClsAAS203.SaveQuantResults(gobjNewMethod, A1, False)
	//            toreported = False
	//        End If

	//        '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
	//        '----Be Careful NOT TO USE index to assign MethodID or RunNumber
	//        '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
	//        If StdAnalysed Or AnaOver Or mblnIsAnalysisStarted Then
	//            If Not (gobjNewMethod Is Nothing) Then
	//                For intCount = 0 To gobjMethodCollection.Count - 1
	//                    If gobjNewMethod.MethodID = gobjMethodCollection(intCount).MethodID Then
	//                        intSelectIDIndex = intCount
	//                        'mobjClsDataFileReport.MethodID = intCount
	//                        objClsDataFileReport.MethodID = gobjMethodCollection(intCount).MethodID
	//                        Exit For
	//                    End If
	//                Next
	//                'intSelectedRunNumber = GetRunNo(gobjNewMethod)

	//                objClsDataFileReport.RunNumber = gobjMethodCollection(intCount).QuantitativeDataCollection(mintRunNumberIndex).RunNumber   'intSelectedRunNumber - 1
	//                'For intCount = 0 To gobjMethodCollection(intSelectIDIndex).QuantitativeDataCollection.Count - 1
	//                '    If intSelectedRunNumber = CInt(gobjMethodCollection(intSelectIDIndex).QuantitativeDataCollection(intCount).RunNumber) Then
	//                '        objClsDataFileReport.RunNumber = intCount
	//                '        Exit For
	//                '    End If
	//                'Next

	//                objClsDataFileReport.DefaultFont = Me.DefaultFont
	//                Call objClsDataFileReport.funcDatafilePrint()
	//            End If
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
	//        'tlbbtnReports.ResumeEvents()
	//        '---------------------------------------------------------
	//    End Try
	//End Sub

	//Private Sub tlbbtnPrintGraph_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
	//    '=====================================================================
	//    ' Procedure Name        : tlbbtnPrintGraph_Click
	//    ' Parameters Passed     : Object, EventArgs
	//    ' Returns               : None
	//    ' Purpose               : 
	//    ' Description           : 
	//    ' Assumptions           : 
	//    ' Dependencies          : 
	//    ' Author                : Sachin Dokhale
	//    ' Created               : 17-May-2007 03:25 pm
	//    ' Revisions             : 1
	//    '=====================================================================



	//    Dim objWait As New CWaitCursor
	//    Dim A1() As Double = {0, 0, 0, 0, 0, 0}

	//    Try
	//        '-----Added By Pankaj Fri 18 May 07
	//        If (gstructSettings.Enable21CFR = True) Then
	//            If Not funcCheckActivityAuthentication(enumActivityAuthentication.Print, gstructUserDetails.Access) Then
	//                Return
	//                Exit Sub
	//            End If
	//            gfuncInsertActivityLog(EnumModules.Print, "Print Analysis Graph Accessed")
	//        End If
	//        '------

	//        'If (toreported) Then 'OR NOT Method->RepReady )
	//        '    gobjClsAAS203.SaveQuantResults(gobjNewMethod, A1, False)
	//        '    toreported = False

	//        'End If
	//        If StdAnalysed Or AnaOver Or mblnIsAnalysisStarted Then
	//            'AASGraphAnalysis.PrintPreViewGraph()
	//        End If
	//        'if (gobjNewMethod.RepReady )
	//        '   OnReportPrint(gobjNewMethod)
	//        'end if

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
	//        'tlbbtnSampleGraph.ResumeEvents()
	//        '---------------------------------------------------------
	//    End Try
	//End Sub

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

	//Private Sub AutoZero_Clicked(ByVal sender As System.Object, ByVal e As System.EventArgs)
	//    '=====================================================================
	//    ' Procedure Name        : AutoZero_Clicked
	//    ' Parameters Passed     : Object, EventArgs
	//    ' Returns               : None
	//    ' Purpose               : 
	//    ' Description           : 
	//    ' Assumptions           : 
	//    ' Dependencies          : 
	//    ' Author                : Mangesh Shardul
	//    ' Created               : 17-Jan-2007 03:25 pm
	//    ' Revisions             : 
	//    '=====================================================================

	//    'case IDC_AUTOZERO:
	//    '   Auto_Zero(hwnd, FALSE);
	//    '   break;

	//    Try
	//        tmrAspirationMsg.Enabled = False
	//        gobjMain.mobjController.Cancel()
	//        Application.DoEvents()

	//        Call gobjClsAAS203.subAutoZero(False)

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
	//        tmrAspirationMsg.Enabled = True
	//        gobjMain.mobjController.Start(gobjclsBgFlameStatus)
	//        Application.DoEvents()
	//        '---------------------------------------------------------
	//    End Try
	//End Sub

	//Private Sub ManualSetup_Clicked(ByVal sender As System.Object, ByVal e As System.EventArgs)
	//    '=====================================================================
	//    ' Procedure Name        : ManualSetup_Clicked
	//    ' Parameters Passed     : Object, EventArgs
	//    ' Returns               : None
	//    ' Purpose               : 
	//    ' Description           : 
	//    ' Assumptions           : 
	//    ' Dependencies          : 
	//    ' Author                : Mangesh Shardul
	//    ' Created               : 17-Jan-2007 03:25 pm
	//    ' Revisions             : 1
	//    '=====================================================================
	//    Try
	//        tmrAspirationMsg.Enabled = False
	//        gobjMain.mobjController.Cancel()
	//        Application.DoEvents()

	//        '---Manual Optimization or Instrument Setup
	//        Call gobjClsAAS203.AbsorbanceScan()

	//        'gobjclsTimer.subTimerStart(StatusBar1)


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
	//        tmrAspirationMsg.Enabled = True
	//        gobjMain.mobjController.Start(gobjclsBgFlameStatus)
	//        Application.DoEvents()
	//        '---------------------------------------------------------
	//    End Try
	//End Sub

	//Private Sub ReOptimizeInstrument_Clicked(ByVal sender As System.Object, ByVal e As System.EventArgs)
	//    '=====================================================================
	//    ' Procedure Name        : ReOptimizeInstrument_Clicked
	//    ' Parameters Passed     : Object, EventArgs
	//    ' Returns               : None
	//    ' Purpose               : ReOptimize Wavelength i.e. Find Analytical Peak Again
	//    ' Description           : 
	//    ' Assumptions           : 
	//    ' Dependencies          : 
	//    ' Author                : Mangesh Shardul
	//    ' Created               : 17-Jan-2007 03:25 pm
	//    ' Revisions             : 1
	//    '=====================================================================
	//    '---ReOptimize Wavelength i.e. Find Analytical Peak Again
	//    'case IDC_OPTIMIZE:
	//    '   Method->Aas.OptimseFlag=FALSE;
	//    '   CheckInstrumentOptimisation(hwnd);
	//    '   break;

	//    Try
	//        tmrAspirationMsg.Enabled = False
	//        gobjMain.mobjController.Cancel()
	//        gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay)   '10.12.07
	//        Application.DoEvents()


	//        'gobjNewMethod.InstrumentConditions.item(mintSelectedInstrumentConditionIndex).IsOptimize = False
	//        gobjNewMethod.InstrumentCondition.IsOptimize = False

	//        Call CheckInstrumentOptimisation()

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
	//        tmrAspirationMsg.Enabled = True
	//        gobjMain.mobjController.Start(gobjclsBgFlameStatus)
	//        Application.DoEvents()
	//        '---------------------------------------------------------
	//    End Try
	//End Sub

	//Private Sub RepeatLastAnalysis_Clicked(ByVal sender As System.Object, ByVal e As System.EventArgs)
	//    '=====================================================================
	//    ' Procedure Name        : RepeatLastAnalysis_Clicked
	//    ' Parameters Passed     : Object, EventArgs
	//    ' Returns               : None
	//    ' Purpose               : 
	//    ' Description           : 
	//    ' Assumptions           : 
	//    ' Dependencies          : 
	//    ' Author                : Mangesh Shardul
	//    ' Created               : 17-Jan-2007 03:25 pm
	//    ' Revisions             : 1
	//    '=====================================================================
	//    '**************************************************************
	//    'case IDC_QARPT:
	//    '   if(LSampType != BLANK )
	//    '	    CurRepeat--;
	//    '	if(CurRepeat <= 0 ){
	//    '	    if(LSampType == SAMP)
	//    '		    CurRepeat = Method->QuantData->Param.Repeat; //mdf by sss
	//    '		if(LSampType == STD)
	//    '		    CurRepeat = Method->QuantData->Param.ConcRepeat; //mdf by sss
	//    '	}
	//    '	if (SampType==BLANK && LSampType==BLANK){
	//    '	    if (CurStd==NULL){
	//    '		    SampType=SAMP;
	//    '       }
	//    '		else{
	//    '		    SampType=STD;
	//    '       }
	//    '   }
	//    '	else{
	//    '	    SampType=LSampType;
	//    '	}
	//    '	if (SampType==SAMP){
	//    '       CurSamp = GetPrevSamp(Method->QuantData->SampTopData, CurSamp);
	//    '	}
	//    '	if (SampType==STD)
	//    '	    CurStd = GetPrevStd(Method->QuantData->StdTopData, CurStd);
	//    '	if (SampType==BLANK){
	//    '	    if (CurStd==NULL)
	//    '		    LSampType=SAMP;
	//    '       Else
	//    '		    LSampType=BLANK;
	//    '	}
	//    '	else
	//    '	    LSampType=BLANK;
	//    'EnableWindow(GetDlgItem(hwnd,IDC_QARPT),FALSE);
	//    '**************************************************************
	//    Try
	//        'Added By Pankaj on 11 Jun 07 
	//        If funcMoveSampleEnumerator(mobjSampleEnumerator, intIEnumCollLocationSamp) = True Then
	//            mobjCurrentSample = CType(mobjSampleEnumerator.Current, Method.clsAnalysisSampleParameters)
	//        End If
	//        If funcMoveEnumerator(mobjStandardEnumerator, intIEnumCollLocationStd) = True Then
	//            mobjCurrentStandard = CType(mobjStandardEnumerator.Current, Method.clsAnalysisStdParameters)
	//        End If

	//        '-----
	//        If (LSampType <> ClsAAS203.enumSampleType.BLANK) Then
	//            CurRepeat -= 1
	//        End If

	//        If (CurRepeat <= 0) Then
	//            If (LSampType = ClsAAS203.enumSampleType.SAMPLE) Then
	//                'CurRepeat = Method->QuantData->Param.Repeat
	//                CurRepeat = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfSampleRepeats
	//            End If
	//            If (LSampType = ClsAAS203.enumSampleType.STANDARD) Then
	//                'CurRepeat = Method->QuantData->Param.ConcRepeat
	//                CurRepeat = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfStdRepeats
	//            End If
	//        End If

	//        If (SampleType = ClsAAS203.enumSampleType.BLANK _
	//         And LSampType = ClsAAS203.enumSampleType.BLANK) Then

	//            If IsNothing(mobjCurrentStandard) Then
	//                SampleType = ClsAAS203.enumSampleType.SAMPLE
	//            Else
	//                SampleType = ClsAAS203.enumSampleType.STANDARD
	//            End If

	//        Else
	//            SampleType = LSampType
	//        End If
	//        '//--------

	//        '//------------
	//        If (SampleType = ClsAAS203.enumSampleType.SAMPLE) Then
	//            'mobjCurrentSample = GetPrevSamp(Method->QuantData->SampTopData, mobjCurrentSample  )
	//            mobjCurrentSample = GetPrevSamp(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection, mobjCurrentSample)
	//            mblnRepeatLastSample = True
	//        End If

	//        If (SampleType = ClsAAS203.enumSampleType.STANDARD) Then
	//            'mobjCurrentStandard = GetPrevStd(Method->QuantData->StdTopData,  mobjCurrentStandard )
	//            mobjCurrentStandard = GetPrevStd(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection, mobjCurrentStandard)
	//            mblnRepeatLastStd = True
	//        End If

	//        If (SampleType = ClsAAS203.enumSampleType.BLANK) Then
	//            If IsNothing(mobjCurrentStandard) Then
	//                LSampType = ClsAAS203.enumSampleType.SAMPLE
	//            Else
	//                LSampType = ClsAAS203.enumSampleType.BLANK
	//            End If
	//        Else
	//            LSampType = ClsAAS203.enumSampleType.BLANK
	//        End If

	//        'EnableWindow(GetDlgItem(hwnd,IDC_QARPT),FALSE);

	//        'tlbbtnRepeatLastAnalysis.Enabled = False
	//        'btnRepeatLast.Enabled = False

	//        Call Aspirate()

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

	#End Region

	#End Region


	private void AutoZero_Clicked(System.Object sender, System.EventArgs e)
	{
		//code added by ; dinesh wagh on 25.2.2010
		//subprocedure added for performing autozero.
		//also button is added on form.
		try {
			tmrAspirationMsg.Enabled = false;
			gobjMain.mobjController.Cancel();
			Application.DoEvents();

			gobjClsAAS203.subAutoZero(false);

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
			tmrAspirationMsg.Enabled = true;
			gobjMain.mobjController.Start(gobjclsBgFlameStatus);
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}
}
