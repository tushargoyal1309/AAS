using System.Threading;
using AAS203.Common;
using BgThread;
using System.IO;
using Microsoft.VisualBasic;
using AAS203.Spectrum;

public class frmEnergySpectrumDBMode : System.Windows.Forms.Form, Iclient
{

	#Region " Private Variable "
	//--- Declaration for the controller object of the BgThread
	private BgThread.clsBgThread mobjController = new BgThread.clsBgThread(this);

	private clsBgSpectrum mobjclsBgSpectrum;

	//Public WithEvents Status As System.Windows.Forms.TextBox

	public System.Windows.Forms.TextBox Status;
	private double mdblFuelRatio = 0.0;

	private double dblBhHeight = 0.0;
	private bool mblnSpectrumStarted;
	private bool mblnAvoidProcessing = false;
	private bool mblnParameterProcessing = false;
	////----- Graph Items
	private double mdblYaxis;
	private double mdblXaxis;
	private AldysGraph.CurveItem mGraphCurveItem;
	private ArrayList ArrlstGraphCurveItem = new ArrayList();
	private int intCurveIndex = -1;
	////-----
	private bool m_blnBaseline = true;
	private bool statStartGraph = false;
	private bool mAvoidProcessBtn = false;
	private struct _Data
	{
		bool mGraphPlot;
		int mXaxisData;
		int mYaxisData;
	}
	//Dim Data As _Data
	//--- declaration of the channels object (collection)
	private Spectrum.Channels mobjChannnels = new Spectrum.Channels();
	private Spectrum.EnergyChannels mobjEnegyChannel = new Spectrum.EnergyChannels();
	private Spectrum.Channel mobjOnlineChannel = new Spectrum.Channel(true);
	private Spectrum.Readings mobjOnlineReadings = new Spectrum.Readings();

	private clsSpectrum mobjSpectrum = new clsSpectrum();
	//--- declaration of the Parameter object used to populate the 
	//--- parameter screen on the spectrum screen
	private Spectrum.EnergySpectrumParameter mobjParameters = new Spectrum.EnergySpectrumParameter();
	//--- Current channel index
	private int mintChannelIndex = -1;
	//----- Store the Peak and Valley

	private clsSpectrum.PeakValley[] mStuctPeaksValley = new clsSpectrum.PeakValley[99];

	private IO.Directory strPath;
	private bool blnYetFileNotSave = false;
	private string mYValueLable = const_Absorbance;
	private string mXValueLable = "Wavelength (nm) : ";
	private bool CheckMaxPosition = false;
	private frmEditValues mobjfrmEditValues;
	private enumSelectBeamType mSelectedBeamType;
	private string mstrSelectedBeamType;

	private bool blnIsRefBeamSelected = false;
		//Saurabh11.08.07
	private bool blnActivateStartEnergySpectrum = false;

	private bool mblnReSetSpectrumParameter = false;

	private int m_bytCalibMode;
	#End Region

	#Region " Constant"
	private const  ConstFormLoad = " Energy Spectrum Mode";
	//Private Const const_WvMin = 217.18
	//Private Const const_WvMax = 317.18
	private const  const_WvMin = 0.0;
	private const  const_WvMax = 100.0;
	private const  const_YMinAbs = 0.0;
	private const  const_YMaxAbs = 1.0;
	private const  const_YMaxEnergy = 100;
	private const  const_YMinEnergy = 0.0;
	private const  const_YMinEmission = 0.0;
	private const  const_YMaxEmission = 100.0;
	private const  const_YMinmVolt = -5000.0;
	private const  const_YMaxmVolt = 5000.0;
	//Private Const const_YMinmVolt = 0.0
	//Private Const const_YMaxmVolt = 4000.0

	private const  const_Absorbance = "Absorbance: ";
	private const  const_Energy = "Energy : ";
	private const  const_Emission = "Emission : ";
		#End Region
	private const  const_Volt = "Volt(mv) : ";

	#Region "Properties"
	private bool IsRefBeamSelected {
		get { return blnIsRefBeamSelected; }
		set {
			blnIsRefBeamSelected = Value;

			if (IsRefBeamSelected == true) {
				btnRef.Checked = true;
				btnSample.Checked = false;
			} else {
				btnRef.Checked = false;
				btnSample.Checked = true;
			}
		}
	}

	private double WvStartRange {
			// Module level variable
		get { return M_WvStartRange; }
		set { M_WvStartRange = Value; }
	}

	private double WvLastRange {
			// Module level variable
		get { return M_WvLastRange; }
		set { M_WvLastRange = Value; }
	}
	#End Region

	#Region " Windows Form Designer generated code "

	public frmEnergySpectrumDBMode()
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
	internal System.Windows.Forms.Label lblSlitWidthnm;
	internal System.Windows.Forms.Label lblD2CurmA;
	internal System.Windows.Forms.ComboBox cmbModes;
	internal System.Windows.Forms.Label lblModes;
	internal System.Windows.Forms.Label lblSpeed;
	internal System.Windows.Forms.ComboBox cmbSpeed;
	internal System.Windows.Forms.Label lblSlitWidth;
	internal System.Windows.Forms.Label lblD2Cur;
	internal System.Windows.Forms.Label lblPMT;
	internal GradientPanel.CustomPanel CustomPanelBottom;
	internal NETXP.Controls.XPButton btnStart;
	internal NETXP.Controls.XPButton btnClearSpectrum;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuDataProcessing;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuSmooth;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuPeakPick;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuLoadSpectrunFile;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuSaveSpectrumFile;
	internal NETXP.Controls.Bars.CommandBarSeparatorItem CommandBarSeparatorItem1;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuFile;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuParameters;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuExit;
	internal NETXP.Controls.XPButton btnLampParameters;
	internal System.Windows.Forms.Label lblHCLCur;
	internal System.Windows.Forms.Label lblHCLCurmA;
	internal NETXP.Controls.XPButton btnReturn;
	internal NETXP.Controls.Bars.CommandBar MenuBarEnergySpectrumMode;
	internal System.Windows.Forms.Label lblFuelRatio;
	internal System.Windows.Forms.Label lblBurnerHeight;
	internal System.Windows.Forms.Label lblBurnerHeightmm;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuOthers;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuPositionToMaxima;
	internal NETXP.Controls.Bars.CommandBarSeparatorItem CommandBarSeparatorItem2;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuContiniousTimeScan;
	internal NETXP.Controls.Bars.StatusBar StatusBar1;
	internal System.Windows.Forms.StatusBarPanel StatusBarPanelInfo;
	internal NETXP.Controls.Bars.ProgressPanel ProgressPanel;
	internal System.Windows.Forms.StatusBarPanel StatusBarPanelDate;
	internal NETXP.Controls.XPButton cmdChangeScale;
	internal AAS203.AASGraph AASEnergySpectrum;
	internal System.Windows.Forms.Label lblYValue;
	internal System.Windows.Forms.Label lblWvPos;
	internal CodeIntellects.Office2003Controls.Office2003Header HeaderLeft;
	internal CodeIntellects.Office2003Controls.Office2003Header Office2003Header1;
	internal NETXP.Controls.Bars.CommandBar ToolBar;
	internal NETXP.Controls.Bars.CommandBarButtonItem tlbbtnReturn;
	internal NETXP.Controls.Bars.CommandBarSeparatorItem CommandBarSeparatorItem3;
	internal NETXP.Controls.Bars.CommandBarButtonItem tlbbtnStart;
	internal NETXP.Controls.Bars.CommandBarButtonItem tlbbtnLampParameters;
	internal NETXP.Controls.Bars.CommandBarButtonItem tlbbtnClearSpectrum;
	internal NETXP.Controls.Bars.CommandBarButtonItem tlbbtnChangeScale;
	internal NETXP.Controls.Bars.CommandBarButtonItem tlbbtnLoadspectrumFile;
	internal NETXP.Controls.Bars.CommandBarButtonItem tlbbtnSaveSpectrumFile;
	internal NETXP.Controls.Bars.CommandBarSeparatorItem CommandBarSeparatorItem4;
	internal NETXP.Controls.Bars.CommandBarSeparatorItem CommandBarSeparatorItem5;
	internal NETXP.Controls.Bars.CommandBarButtonItem tlbbtnSmooth;
	internal NETXP.Controls.Bars.CommandBarButtonItem tlbbtnPeakPick;
	internal NETXP.Controls.Bars.CommandBarButtonItem tlbbtnPositionToMaxima;
	internal NETXP.Controls.Bars.CommandBarButtonItem tlbbtnContiniousTimeScan;
	internal NETXP.Controls.Bars.CommandBarButtonItem tlbbtnParameters;
	internal ValueEditor.ValueEditor nudPMT;
	internal ValueEditor.ValueEditor nudFuelRatio;
	internal ValueEditor.ValueEditor nudSlit;
	internal ValueEditor.ValueEditor nudD2Cur;
	internal ValueEditor.ValueEditor nudHCLCur;
	internal ValueEditor.ValueEditor nudBurnerHeight;
	internal ValueEditor.ValueEditor nudSlit_Ref;
	internal ValueEditor.ValueEditor nudPMT_Ref;
	internal System.Windows.Forms.Label lblPMT_Ref;
	internal System.Windows.Forms.Label Label1;
	internal System.Windows.Forms.Label lblPMTVolts;
	internal System.Windows.Forms.Label Label2;
	internal System.Windows.Forms.Label Label3;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuGraphOptions;
	internal NETXP.Controls.Bars.CommandBarButtonItem CommandBarButtonItem1;
	internal NETXP.Controls.Bars.CommandBar mnuAutoIgnition;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuIgnite;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuExtinguish;
	internal NETXP.Controls.Bars.CommandBarButtonItem CommandBarButtonItem2;
	internal NETXP.Controls.Bars.CommandBarButtonItem CommandBarButtonItem3;
	internal NETXP.Controls.Bars.CommandBarButtonItem tlbbtnPrintGraph;
	internal NETXP.Controls.Bars.CommandBarButtonItem CommandBarButtonItem4;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuPeakEdit;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuGrid;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuStart;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuClearSpectrum;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuLampParameters;
	internal NETXP.Controls.Bars.CommandBarSeparatorItem CommandBarSeparatorItem6;
	internal NETXP.Controls.Bars.CommandBarButtonItem tlbbtnPeakEdit;
	internal NETXP.Controls.Bars.CommandBarButtonItem tlbbtnGrid;
	internal NETXP.Controls.Bars.CommandBarButtonItem tlbbtnLegends;
	internal NETXP.Controls.Bars.CommandBarButtonItem tlbbtnShowXYValues;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuPrintGraph;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuLegends;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuShowXYValues;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuChangeScale;
		//by pankaj on 30 Nov 07
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuOverlay;
	internal System.Windows.Forms.GroupBox grpBeamType;
	internal System.Windows.Forms.RadioButton btnSample;
	internal System.Windows.Forms.RadioButton btnRef;
	internal NETXP.Controls.XPButton btnDelete;
	internal NETXP.Controls.XPButton btnR;
	internal NETXP.Controls.XPButton btnExtinguish;
	internal NETXP.Controls.XPButton btnIgnite;
	internal NETXP.Controls.XPButton btnN2OIgnite;
	internal System.Windows.Forms.Timer TimerEnergyDisplay;
	[System.Diagnostics.DebuggerStepThrough()]
	private void InitializeComponent()
	{
		this.components = new System.ComponentModel.Container();
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmEnergySpectrumDBMode));
		this.CustomPanelMain = new GradientPanel.CustomPanel();
		this.CustomPanelBottom = new GradientPanel.CustomPanel();
		this.cmdChangeScale = new NETXP.Controls.XPButton();
		this.btnStart = new NETXP.Controls.XPButton();
		this.btnLampParameters = new NETXP.Controls.XPButton();
		this.btnClearSpectrum = new NETXP.Controls.XPButton();
		this.btnReturn = new NETXP.Controls.XPButton();
		this.btnDelete = new NETXP.Controls.XPButton();
		this.btnR = new NETXP.Controls.XPButton();
		this.Office2003Header1 = new CodeIntellects.Office2003Controls.Office2003Header();
		this.CustomPanelTop = new GradientPanel.CustomPanel();
		this.grpBeamType = new System.Windows.Forms.GroupBox();
		this.btnRef = new System.Windows.Forms.RadioButton();
		this.btnSample = new System.Windows.Forms.RadioButton();
		this.Label3 = new System.Windows.Forms.Label();
		this.Label2 = new System.Windows.Forms.Label();
		this.Label1 = new System.Windows.Forms.Label();
		this.lblPMT_Ref = new System.Windows.Forms.Label();
		this.nudSlit_Ref = new ValueEditor.ValueEditor();
		this.nudPMT_Ref = new ValueEditor.ValueEditor();
		this.nudBurnerHeight = new ValueEditor.ValueEditor();
		this.nudHCLCur = new ValueEditor.ValueEditor();
		this.nudD2Cur = new ValueEditor.ValueEditor();
		this.nudSlit = new ValueEditor.ValueEditor();
		this.nudFuelRatio = new ValueEditor.ValueEditor();
		this.nudPMT = new ValueEditor.ValueEditor();
		this.HeaderLeft = new CodeIntellects.Office2003Controls.Office2003Header();
		this.lblYValue = new System.Windows.Forms.Label();
		this.lblWvPos = new System.Windows.Forms.Label();
		this.lblBurnerHeightmm = new System.Windows.Forms.Label();
		this.lblBurnerHeight = new System.Windows.Forms.Label();
		this.lblFuelRatio = new System.Windows.Forms.Label();
		this.lblHCLCurmA = new System.Windows.Forms.Label();
		this.lblHCLCur = new System.Windows.Forms.Label();
		this.lblSlitWidthnm = new System.Windows.Forms.Label();
		this.lblPMTVolts = new System.Windows.Forms.Label();
		this.lblD2CurmA = new System.Windows.Forms.Label();
		this.cmbModes = new System.Windows.Forms.ComboBox();
		this.lblModes = new System.Windows.Forms.Label();
		this.lblSpeed = new System.Windows.Forms.Label();
		this.cmbSpeed = new System.Windows.Forms.ComboBox();
		this.lblSlitWidth = new System.Windows.Forms.Label();
		this.lblD2Cur = new System.Windows.Forms.Label();
		this.lblPMT = new System.Windows.Forms.Label();
		this.AASEnergySpectrum = new AAS203.AASGraph();
		this.btnExtinguish = new NETXP.Controls.XPButton();
		this.btnIgnite = new NETXP.Controls.XPButton();
		this.btnN2OIgnite = new NETXP.Controls.XPButton();
		this.mnuDataProcessing = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuStart = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuLampParameters = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuSmooth = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuPeakPick = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuClearSpectrum = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuPrintGraph = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuLoadSpectrunFile = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuSaveSpectrumFile = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.CommandBarSeparatorItem1 = new NETXP.Controls.Bars.CommandBarSeparatorItem();
		this.mnuFile = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuParameters = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuExit = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.MenuBarEnergySpectrumMode = new NETXP.Controls.Bars.CommandBar();
		this.mnuAutoIgnition = new NETXP.Controls.Bars.CommandBar();
		this.mnuIgnite = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuExtinguish = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuGraphOptions = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuPeakEdit = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuGrid = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuLegends = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuShowXYValues = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuChangeScale = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuOverlay = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuOthers = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuPositionToMaxima = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.CommandBarSeparatorItem2 = new NETXP.Controls.Bars.CommandBarSeparatorItem();
		this.mnuContiniousTimeScan = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.StatusBar1 = new NETXP.Controls.Bars.StatusBar();
		this.StatusBarPanelInfo = new System.Windows.Forms.StatusBarPanel();
		this.ProgressPanel = new NETXP.Controls.Bars.ProgressPanel();
		this.StatusBarPanelDate = new System.Windows.Forms.StatusBarPanel();
		this.ToolBar = new NETXP.Controls.Bars.CommandBar();
		this.tlbbtnReturn = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.CommandBarSeparatorItem3 = new NETXP.Controls.Bars.CommandBarSeparatorItem();
		this.tlbbtnParameters = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.tlbbtnLoadspectrumFile = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.tlbbtnSaveSpectrumFile = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.CommandBarSeparatorItem4 = new NETXP.Controls.Bars.CommandBarSeparatorItem();
		this.tlbbtnStart = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.tlbbtnLampParameters = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.tlbbtnSmooth = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.tlbbtnPeakPick = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.tlbbtnClearSpectrum = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.tlbbtnChangeScale = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.tlbbtnPrintGraph = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.CommandBarSeparatorItem5 = new NETXP.Controls.Bars.CommandBarSeparatorItem();
		this.tlbbtnPeakEdit = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.tlbbtnGrid = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.tlbbtnLegends = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.tlbbtnShowXYValues = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.CommandBarSeparatorItem6 = new NETXP.Controls.Bars.CommandBarSeparatorItem();
		this.tlbbtnPositionToMaxima = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.tlbbtnContiniousTimeScan = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.CommandBarButtonItem1 = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.CommandBarButtonItem2 = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.CommandBarButtonItem3 = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.CommandBarButtonItem4 = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.TimerEnergyDisplay = new System.Windows.Forms.Timer(this.components);
		this.CustomPanelMain.SuspendLayout();
		this.CustomPanelBottom.SuspendLayout();
		this.CustomPanelTop.SuspendLayout();
		this.grpBeamType.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.MenuBarEnergySpectrumMode).BeginInit();
		this.MenuBarEnergySpectrumMode.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.mnuAutoIgnition).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.StatusBarPanelInfo).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.ProgressPanel).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.StatusBarPanelDate).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.ToolBar).BeginInit();
		this.SuspendLayout();
		//
		//CustomPanelMain
		//
		this.CustomPanelMain.BackColor = System.Drawing.Color.AliceBlue;
		this.CustomPanelMain.Controls.Add(this.CustomPanelBottom);
		this.CustomPanelMain.Controls.Add(this.Office2003Header1);
		this.CustomPanelMain.Controls.Add(this.CustomPanelTop);
		this.CustomPanelMain.Controls.Add(this.AASEnergySpectrum);
		this.CustomPanelMain.Controls.Add(this.btnExtinguish);
		this.CustomPanelMain.Controls.Add(this.btnIgnite);
		this.CustomPanelMain.Controls.Add(this.btnN2OIgnite);
		this.CustomPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
		this.CustomPanelMain.Location = new System.Drawing.Point(0, 57);
		this.CustomPanelMain.Name = "CustomPanelMain";
		this.CustomPanelMain.Size = new System.Drawing.Size(804, 504);
		this.CustomPanelMain.TabIndex = 3;
		//
		//CustomPanelBottom
		//
		this.CustomPanelBottom.BackColor = System.Drawing.Color.AliceBlue;
		this.CustomPanelBottom.Controls.Add(this.cmdChangeScale);
		this.CustomPanelBottom.Controls.Add(this.btnStart);
		this.CustomPanelBottom.Controls.Add(this.btnLampParameters);
		this.CustomPanelBottom.Controls.Add(this.btnClearSpectrum);
		this.CustomPanelBottom.Controls.Add(this.btnReturn);
		this.CustomPanelBottom.Controls.Add(this.btnDelete);
		this.CustomPanelBottom.Controls.Add(this.btnR);
		this.CustomPanelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
		this.CustomPanelBottom.Location = new System.Drawing.Point(184, 423);
		this.CustomPanelBottom.Name = "CustomPanelBottom";
		this.CustomPanelBottom.Size = new System.Drawing.Size(620, 81);
		this.CustomPanelBottom.TabIndex = 1;
		//
		//cmdChangeScale
		//
		this.cmdChangeScale.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.cmdChangeScale.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.cmdChangeScale.Image = (System.Drawing.Image)resources.GetObject("cmdChangeScale.Image");
		this.cmdChangeScale.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.cmdChangeScale.Location = new System.Drawing.Point(24, 28);
		this.cmdChangeScale.Name = "cmdChangeScale";
		this.cmdChangeScale.Size = new System.Drawing.Size(108, 38);
		this.cmdChangeScale.TabIndex = 0;
		this.cmdChangeScale.Text = "Chan&ge Scale";
		this.cmdChangeScale.TextAlign = System.Drawing.ContentAlignment.TopLeft;
		//
		//btnStart
		//
		this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnStart.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnStart.Image = (System.Drawing.Image)resources.GetObject("btnStart.Image");
		this.btnStart.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnStart.Location = new System.Drawing.Point(137, 28);
		this.btnStart.Name = "btnStart";
		this.btnStart.Size = new System.Drawing.Size(108, 38);
		this.btnStart.TabIndex = 1;
		this.btnStart.Text = "&Start";
		//
		//btnLampParameters
		//
		this.btnLampParameters.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnLampParameters.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnLampParameters.Image = (System.Drawing.Image)resources.GetObject("btnLampParameters.Image");
		this.btnLampParameters.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnLampParameters.Location = new System.Drawing.Point(250, 28);
		this.btnLampParameters.Name = "btnLampParameters";
		this.btnLampParameters.Size = new System.Drawing.Size(108, 38);
		this.btnLampParameters.TabIndex = 2;
		this.btnLampParameters.Text = "&Lamp Parameters";
		this.btnLampParameters.TextAlign = System.Drawing.ContentAlignment.TopLeft;
		//
		//btnClearSpectrum
		//
		this.btnClearSpectrum.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnClearSpectrum.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnClearSpectrum.Image = (System.Drawing.Image)resources.GetObject("btnClearSpectrum.Image");
		this.btnClearSpectrum.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnClearSpectrum.Location = new System.Drawing.Point(366, 28);
		this.btnClearSpectrum.Name = "btnClearSpectrum";
		this.btnClearSpectrum.Size = new System.Drawing.Size(108, 38);
		this.btnClearSpectrum.TabIndex = 3;
		this.btnClearSpectrum.Text = "Clear S&pectrum";
		this.btnClearSpectrum.TextAlign = System.Drawing.ContentAlignment.TopLeft;
		//
		//btnReturn
		//
		this.btnReturn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.btnReturn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnReturn.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnReturn.Image = (System.Drawing.Image)resources.GetObject("btnReturn.Image");
		this.btnReturn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnReturn.Location = new System.Drawing.Point(476, 28);
		this.btnReturn.Name = "btnReturn";
		this.btnReturn.Size = new System.Drawing.Size(108, 38);
		this.btnReturn.TabIndex = 4;
		this.btnReturn.Text = "Return";
		//
		//btnDelete
		//
		this.btnDelete.BackColor = System.Drawing.Color.Transparent;
		this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnDelete.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnDelete.Location = new System.Drawing.Point(216, 44);
		this.btnDelete.Name = "btnDelete";
		this.btnDelete.Size = new System.Drawing.Size(8, 8);
		this.btnDelete.TabIndex = 138;
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
		this.btnR.Location = new System.Drawing.Point(228, 44);
		this.btnR.Name = "btnR";
		this.btnR.Size = new System.Drawing.Size(8, 8);
		this.btnR.TabIndex = 137;
		this.btnR.TabStop = false;
		this.btnR.Text = "&R";
		this.btnR.TextAlign = System.Drawing.ContentAlignment.TopLeft;
		//
		//Office2003Header1
		//
		this.Office2003Header1.BackColor = System.Drawing.SystemColors.Control;
		this.Office2003Header1.Dock = System.Windows.Forms.DockStyle.Top;
		this.Office2003Header1.Location = new System.Drawing.Point(184, 0);
		this.Office2003Header1.Name = "Office2003Header1";
		this.Office2003Header1.Size = new System.Drawing.Size(620, 22);
		this.Office2003Header1.TabIndex = 47;
		this.Office2003Header1.TitleFont = new System.Drawing.Font("Tahoma", 10f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.Office2003Header1.TitleText = "Spectrum";
		//
		//CustomPanelTop
		//
		this.CustomPanelTop.BackColor = System.Drawing.Color.AliceBlue;
		this.CustomPanelTop.Controls.Add(this.grpBeamType);
		this.CustomPanelTop.Controls.Add(this.Label3);
		this.CustomPanelTop.Controls.Add(this.Label2);
		this.CustomPanelTop.Controls.Add(this.Label1);
		this.CustomPanelTop.Controls.Add(this.lblPMT_Ref);
		this.CustomPanelTop.Controls.Add(this.nudSlit_Ref);
		this.CustomPanelTop.Controls.Add(this.nudPMT_Ref);
		this.CustomPanelTop.Controls.Add(this.nudBurnerHeight);
		this.CustomPanelTop.Controls.Add(this.nudHCLCur);
		this.CustomPanelTop.Controls.Add(this.nudD2Cur);
		this.CustomPanelTop.Controls.Add(this.nudSlit);
		this.CustomPanelTop.Controls.Add(this.nudFuelRatio);
		this.CustomPanelTop.Controls.Add(this.nudPMT);
		this.CustomPanelTop.Controls.Add(this.HeaderLeft);
		this.CustomPanelTop.Controls.Add(this.lblYValue);
		this.CustomPanelTop.Controls.Add(this.lblWvPos);
		this.CustomPanelTop.Controls.Add(this.lblBurnerHeightmm);
		this.CustomPanelTop.Controls.Add(this.lblBurnerHeight);
		this.CustomPanelTop.Controls.Add(this.lblFuelRatio);
		this.CustomPanelTop.Controls.Add(this.lblHCLCurmA);
		this.CustomPanelTop.Controls.Add(this.lblHCLCur);
		this.CustomPanelTop.Controls.Add(this.lblSlitWidthnm);
		this.CustomPanelTop.Controls.Add(this.lblPMTVolts);
		this.CustomPanelTop.Controls.Add(this.lblD2CurmA);
		this.CustomPanelTop.Controls.Add(this.cmbModes);
		this.CustomPanelTop.Controls.Add(this.lblModes);
		this.CustomPanelTop.Controls.Add(this.lblSpeed);
		this.CustomPanelTop.Controls.Add(this.cmbSpeed);
		this.CustomPanelTop.Controls.Add(this.lblSlitWidth);
		this.CustomPanelTop.Controls.Add(this.lblD2Cur);
		this.CustomPanelTop.Controls.Add(this.lblPMT);
		this.CustomPanelTop.Dock = System.Windows.Forms.DockStyle.Left;
		this.CustomPanelTop.Location = new System.Drawing.Point(0, 0);
		this.CustomPanelTop.Name = "CustomPanelTop";
		this.CustomPanelTop.Size = new System.Drawing.Size(184, 504);
		this.CustomPanelTop.TabIndex = 0;
		//
		//grpBeamType
		//
		this.grpBeamType.Controls.Add(this.btnRef);
		this.grpBeamType.Controls.Add(this.btnSample);
		this.grpBeamType.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.grpBeamType.Location = new System.Drawing.Point(12, 338);
		this.grpBeamType.Name = "grpBeamType";
		this.grpBeamType.Size = new System.Drawing.Size(162, 70);
		this.grpBeamType.TabIndex = 62;
		this.grpBeamType.TabStop = false;
		this.grpBeamType.Text = "Beam Type";
		//
		//btnRef
		//
		this.btnRef.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnRef.Location = new System.Drawing.Point(16, 44);
		this.btnRef.Name = "btnRef";
		this.btnRef.Size = new System.Drawing.Size(120, 18);
		this.btnRef.TabIndex = 1;
		this.btnRef.Text = "Reference Beam";
		//
		//btnSample
		//
		this.btnSample.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnSample.Location = new System.Drawing.Point(16, 17);
		this.btnSample.Name = "btnSample";
		this.btnSample.Size = new System.Drawing.Size(124, 24);
		this.btnSample.TabIndex = 0;
		this.btnSample.Text = "Sample Beam";
		//
		//Label3
		//
		this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.Label3.Location = new System.Drawing.Point(147, 158);
		this.Label3.Name = "Label3";
		this.Label3.Size = new System.Drawing.Size(24, 18);
		this.Label3.TabIndex = 61;
		this.Label3.Text = "nm";
		this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//Label2
		//
		this.Label2.BackColor = System.Drawing.Color.Transparent;
		this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.Label2.Location = new System.Drawing.Point(147, 71);
		this.Label2.Name = "Label2";
		this.Label2.Size = new System.Drawing.Size(32, 18);
		this.Label2.TabIndex = 60;
		this.Label2.Text = "volts";
		this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//Label1
		//
		this.Label1.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.Label1.Location = new System.Drawing.Point(8, 185);
		this.Label1.Name = "Label1";
		this.Label1.Size = new System.Drawing.Size(57, 28);
		this.Label1.TabIndex = 59;
		this.Label1.Text = "Exit Slit Width";
		this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//lblPMT_Ref
		//
		this.lblPMT_Ref.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblPMT_Ref.Location = new System.Drawing.Point(8, 67);
		this.lblPMT_Ref.Name = "lblPMT_Ref";
		this.lblPMT_Ref.Size = new System.Drawing.Size(57, 20);
		this.lblPMT_Ref.TabIndex = 58;
		this.lblPMT_Ref.Text = "Ref. PMT";
		this.lblPMT_Ref.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//nudSlit_Ref
		//
		this.nudSlit_Ref.BackColor = System.Drawing.SystemColors.Window;
		this.nudSlit_Ref.BackgroundColor = System.Drawing.SystemColors.Window;
		this.nudSlit_Ref.ButtonClicked = ValueEditor.ValueEditor.EnumValueEditorButtons.MainButton;
		this.nudSlit_Ref.ChangeFactor = 0;
		this.nudSlit_Ref.DecimalPlace = 0;
		this.nudSlit_Ref.DnButtonText = "6";
		this.nudSlit_Ref.Enabled = false;
		this.nudSlit_Ref.ForeColor = System.Drawing.SystemColors.ControlText;
		this.nudSlit_Ref.ForegroundColor = System.Drawing.SystemColors.ControlText;
		this.nudSlit_Ref.IsReverseOperation = false;
		this.nudSlit_Ref.IsUpDownButtonToBeDisabledOnValueChange = false;
		this.nudSlit_Ref.Location = new System.Drawing.Point(72, 188);
		this.nudSlit_Ref.MaxValue = 0;
		this.nudSlit_Ref.MinValue = 0;
		this.nudSlit_Ref.Name = "nudSlit_Ref";
		this.nudSlit_Ref.Size = new System.Drawing.Size(72, 22);
		this.nudSlit_Ref.TabIndex = 17;
		this.nudSlit_Ref.UpButtonText = "5";
		this.nudSlit_Ref.Value = 0;
		this.nudSlit_Ref.ValueEditorEnabled = false;
		this.nudSlit_Ref.ValueEditorFont = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.nudSlit_Ref.Visible = false;
		//
		//nudPMT_Ref
		//
		this.nudPMT_Ref.BackColor = System.Drawing.SystemColors.Window;
		this.nudPMT_Ref.BackgroundColor = System.Drawing.SystemColors.Window;
		this.nudPMT_Ref.ButtonClicked = ValueEditor.ValueEditor.EnumValueEditorButtons.MainButton;
		this.nudPMT_Ref.ChangeFactor = 0;
		this.nudPMT_Ref.DecimalPlace = 0;
		this.nudPMT_Ref.DnButtonText = "6";
		this.nudPMT_Ref.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.nudPMT_Ref.ForeColor = System.Drawing.SystemColors.ControlText;
		this.nudPMT_Ref.ForegroundColor = System.Drawing.SystemColors.ControlText;
		this.nudPMT_Ref.IsReverseOperation = false;
		this.nudPMT_Ref.IsUpDownButtonToBeDisabledOnValueChange = false;
		this.nudPMT_Ref.Location = new System.Drawing.Point(72, 64);
		this.nudPMT_Ref.MaxValue = 0;
		this.nudPMT_Ref.MinValue = 0;
		this.nudPMT_Ref.Name = "nudPMT_Ref";
		this.nudPMT_Ref.Size = new System.Drawing.Size(72, 22);
		this.nudPMT_Ref.TabIndex = 5;
		this.nudPMT_Ref.UpButtonText = "5";
		this.nudPMT_Ref.Value = 0;
		this.nudPMT_Ref.ValueEditorEnabled = true;
		this.nudPMT_Ref.ValueEditorFont = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.nudPMT_Ref.Visible = false;
		//
		//nudBurnerHeight
		//
		this.nudBurnerHeight.BackColor = System.Drawing.SystemColors.Window;
		this.nudBurnerHeight.BackgroundColor = System.Drawing.SystemColors.Window;
		this.nudBurnerHeight.ButtonClicked = ValueEditor.ValueEditor.EnumValueEditorButtons.MainButton;
		this.nudBurnerHeight.ChangeFactor = 0;
		this.nudBurnerHeight.DecimalPlace = 0;
		this.nudBurnerHeight.DnButtonText = "6";
		this.nudBurnerHeight.ForeColor = System.Drawing.SystemColors.ControlText;
		this.nudBurnerHeight.ForegroundColor = System.Drawing.SystemColors.ControlText;
		this.nudBurnerHeight.IsReverseOperation = false;
		this.nudBurnerHeight.IsUpDownButtonToBeDisabledOnValueChange = false;
		this.nudBurnerHeight.Location = new System.Drawing.Point(72, 250);
		this.nudBurnerHeight.MaxValue = 0;
		this.nudBurnerHeight.MinValue = 0;
		this.nudBurnerHeight.Name = "nudBurnerHeight";
		this.nudBurnerHeight.Size = new System.Drawing.Size(72, 22);
		this.nudBurnerHeight.TabIndex = 23;
		this.nudBurnerHeight.UpButtonText = "5";
		this.nudBurnerHeight.Value = 0;
		this.nudBurnerHeight.ValueEditorEnabled = true;
		this.nudBurnerHeight.ValueEditorFont = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.nudBurnerHeight.Visible = false;
		//
		//nudHCLCur
		//
		this.nudHCLCur.BackColor = System.Drawing.SystemColors.Window;
		this.nudHCLCur.BackgroundColor = System.Drawing.SystemColors.Window;
		this.nudHCLCur.ButtonClicked = ValueEditor.ValueEditor.EnumValueEditorButtons.MainButton;
		this.nudHCLCur.ChangeFactor = 0;
		this.nudHCLCur.DecimalPlace = 1;
		this.nudHCLCur.DnButtonText = "6";
		this.nudHCLCur.ForeColor = System.Drawing.SystemColors.ControlText;
		this.nudHCLCur.ForegroundColor = System.Drawing.SystemColors.ControlText;
		this.nudHCLCur.IsReverseOperation = false;
		this.nudHCLCur.IsUpDownButtonToBeDisabledOnValueChange = false;
		this.nudHCLCur.Location = new System.Drawing.Point(72, 95);
		this.nudHCLCur.MaxValue = 0;
		this.nudHCLCur.MinValue = 0;
		this.nudHCLCur.Name = "nudHCLCur";
		this.nudHCLCur.Size = new System.Drawing.Size(72, 22);
		this.nudHCLCur.TabIndex = 8;
		this.nudHCLCur.UpButtonText = "5";
		this.nudHCLCur.Value = 0;
		this.nudHCLCur.ValueEditorEnabled = true;
		this.nudHCLCur.ValueEditorFont = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.nudHCLCur.Visible = false;
		//
		//nudD2Cur
		//
		this.nudD2Cur.BackColor = System.Drawing.SystemColors.Window;
		this.nudD2Cur.BackgroundColor = System.Drawing.SystemColors.Window;
		this.nudD2Cur.ButtonClicked = ValueEditor.ValueEditor.EnumValueEditorButtons.MainButton;
		this.nudD2Cur.ChangeFactor = 0;
		this.nudD2Cur.DecimalPlace = 0;
		this.nudD2Cur.DnButtonText = "6";
		this.nudD2Cur.ForeColor = System.Drawing.SystemColors.ControlText;
		this.nudD2Cur.ForegroundColor = System.Drawing.SystemColors.ControlText;
		this.nudD2Cur.IsReverseOperation = false;
		this.nudD2Cur.IsUpDownButtonToBeDisabledOnValueChange = false;
		this.nudD2Cur.Location = new System.Drawing.Point(72, 126);
		this.nudD2Cur.MaxValue = 0;
		this.nudD2Cur.MinValue = 0;
		this.nudD2Cur.Name = "nudD2Cur";
		this.nudD2Cur.Size = new System.Drawing.Size(72, 22);
		this.nudD2Cur.TabIndex = 11;
		this.nudD2Cur.UpButtonText = "5";
		this.nudD2Cur.Value = 0;
		this.nudD2Cur.ValueEditorEnabled = true;
		this.nudD2Cur.ValueEditorFont = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.nudD2Cur.Visible = false;
		//
		//nudSlit
		//
		this.nudSlit.BackColor = System.Drawing.SystemColors.Window;
		this.nudSlit.BackgroundColor = System.Drawing.SystemColors.Window;
		this.nudSlit.ButtonClicked = ValueEditor.ValueEditor.EnumValueEditorButtons.MainButton;
		this.nudSlit.ChangeFactor = 0;
		this.nudSlit.DecimalPlace = 0;
		this.nudSlit.DnButtonText = "6";
		this.nudSlit.ForeColor = System.Drawing.SystemColors.ControlText;
		this.nudSlit.ForegroundColor = System.Drawing.SystemColors.ControlText;
		this.nudSlit.IsReverseOperation = false;
		this.nudSlit.IsUpDownButtonToBeDisabledOnValueChange = false;
		this.nudSlit.Location = new System.Drawing.Point(72, 157);
		this.nudSlit.MaxValue = 0;
		this.nudSlit.MinValue = 0;
		this.nudSlit.Name = "nudSlit";
		this.nudSlit.Size = new System.Drawing.Size(72, 22);
		this.nudSlit.TabIndex = 14;
		this.nudSlit.UpButtonText = "5";
		this.nudSlit.Value = 0;
		this.nudSlit.ValueEditorEnabled = true;
		this.nudSlit.ValueEditorFont = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.nudSlit.Visible = false;
		//
		//nudFuelRatio
		//
		this.nudFuelRatio.BackColor = System.Drawing.SystemColors.Window;
		this.nudFuelRatio.BackgroundColor = System.Drawing.SystemColors.Window;
		this.nudFuelRatio.ButtonClicked = ValueEditor.ValueEditor.EnumValueEditorButtons.MainButton;
		this.nudFuelRatio.ChangeFactor = 0;
		this.nudFuelRatio.DecimalPlace = 0;
		this.nudFuelRatio.DnButtonText = "6";
		this.nudFuelRatio.ForeColor = System.Drawing.SystemColors.ControlText;
		this.nudFuelRatio.ForegroundColor = System.Drawing.SystemColors.ControlText;
		this.nudFuelRatio.IsReverseOperation = false;
		this.nudFuelRatio.IsUpDownButtonToBeDisabledOnValueChange = false;
		this.nudFuelRatio.Location = new System.Drawing.Point(72, 219);
		this.nudFuelRatio.MaxValue = 0;
		this.nudFuelRatio.MinValue = 0;
		this.nudFuelRatio.Name = "nudFuelRatio";
		this.nudFuelRatio.Size = new System.Drawing.Size(72, 22);
		this.nudFuelRatio.TabIndex = 20;
		this.nudFuelRatio.UpButtonText = "5";
		this.nudFuelRatio.Value = 0;
		this.nudFuelRatio.ValueEditorEnabled = true;
		this.nudFuelRatio.ValueEditorFont = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.nudFuelRatio.Visible = false;
		//
		//nudPMT
		//
		this.nudPMT.BackColor = System.Drawing.SystemColors.Window;
		this.nudPMT.BackgroundColor = System.Drawing.SystemColors.Window;
		this.nudPMT.ButtonClicked = ValueEditor.ValueEditor.EnumValueEditorButtons.MainButton;
		this.nudPMT.ChangeFactor = 0;
		this.nudPMT.DecimalPlace = 0;
		this.nudPMT.DnButtonText = "6";
		this.nudPMT.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.nudPMT.ForeColor = System.Drawing.SystemColors.ControlText;
		this.nudPMT.ForegroundColor = System.Drawing.SystemColors.ControlText;
		this.nudPMT.IsReverseOperation = false;
		this.nudPMT.IsUpDownButtonToBeDisabledOnValueChange = false;
		this.nudPMT.Location = new System.Drawing.Point(72, 33);
		this.nudPMT.MaxValue = 0;
		this.nudPMT.MinValue = 0;
		this.nudPMT.Name = "nudPMT";
		this.nudPMT.Size = new System.Drawing.Size(72, 22);
		this.nudPMT.TabIndex = 2;
		this.nudPMT.UpButtonText = "5";
		this.nudPMT.Value = 0;
		this.nudPMT.ValueEditorEnabled = true;
		this.nudPMT.ValueEditorFont = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.nudPMT.Visible = false;
		//
		//HeaderLeft
		//
		this.HeaderLeft.BackColor = System.Drawing.SystemColors.Control;
		this.HeaderLeft.Dock = System.Windows.Forms.DockStyle.Top;
		this.HeaderLeft.Location = new System.Drawing.Point(0, 0);
		this.HeaderLeft.Name = "HeaderLeft";
		this.HeaderLeft.Size = new System.Drawing.Size(184, 22);
		this.HeaderLeft.TabIndex = 46;
		this.HeaderLeft.TitleFont = new System.Drawing.Font("Tahoma", 10f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.HeaderLeft.TitleText = "Parameters";
		//
		//lblYValue
		//
		this.lblYValue.BackColor = System.Drawing.Color.White;
		this.lblYValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblYValue.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblYValue.ForeColor = System.Drawing.Color.Blue;
		this.lblYValue.Location = new System.Drawing.Point(12, 447);
		this.lblYValue.Name = "lblYValue";
		this.lblYValue.Size = new System.Drawing.Size(166, 20);
		this.lblYValue.TabIndex = 45;
		this.lblYValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//lblWvPos
		//
		this.lblWvPos.BackColor = System.Drawing.Color.White;
		this.lblWvPos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblWvPos.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblWvPos.ForeColor = System.Drawing.Color.Blue;
		this.lblWvPos.Location = new System.Drawing.Point(12, 416);
		this.lblWvPos.Name = "lblWvPos";
		this.lblWvPos.Size = new System.Drawing.Size(166, 20);
		this.lblWvPos.TabIndex = 44;
		this.lblWvPos.Text = "Wavelength (nm) :  ";
		this.lblWvPos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//lblBurnerHeightmm
		//
		this.lblBurnerHeightmm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblBurnerHeightmm.Location = new System.Drawing.Point(147, 255);
		this.lblBurnerHeightmm.Name = "lblBurnerHeightmm";
		this.lblBurnerHeightmm.Size = new System.Drawing.Size(24, 18);
		this.lblBurnerHeightmm.TabIndex = 36;
		this.lblBurnerHeightmm.Text = "mm";
		//
		//lblBurnerHeight
		//
		this.lblBurnerHeight.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblBurnerHeight.Location = new System.Drawing.Point(8, 252);
		this.lblBurnerHeight.Name = "lblBurnerHeight";
		this.lblBurnerHeight.Size = new System.Drawing.Size(62, 20);
		this.lblBurnerHeight.TabIndex = 34;
		this.lblBurnerHeight.Text = "Burner Ht.";
		this.lblBurnerHeight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//lblFuelRatio
		//
		this.lblFuelRatio.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblFuelRatio.Location = new System.Drawing.Point(8, 221);
		this.lblFuelRatio.Name = "lblFuelRatio";
		this.lblFuelRatio.Size = new System.Drawing.Size(62, 20);
		this.lblFuelRatio.TabIndex = 32;
		this.lblFuelRatio.Text = "Fuel Ratio";
		this.lblFuelRatio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//lblHCLCurmA
		//
		this.lblHCLCurmA.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblHCLCurmA.Location = new System.Drawing.Point(147, 100);
		this.lblHCLCurmA.Name = "lblHCLCurmA";
		this.lblHCLCurmA.Size = new System.Drawing.Size(26, 18);
		this.lblHCLCurmA.TabIndex = 31;
		this.lblHCLCurmA.Text = "mA";
		this.lblHCLCurmA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//lblHCLCur
		//
		this.lblHCLCur.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblHCLCur.Location = new System.Drawing.Point(8, 97);
		this.lblHCLCur.Name = "lblHCLCur";
		this.lblHCLCur.Size = new System.Drawing.Size(57, 20);
		this.lblHCLCur.TabIndex = 30;
		this.lblHCLCur.Text = "HCL Cur";
		this.lblHCLCur.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//lblSlitWidthnm
		//
		this.lblSlitWidthnm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblSlitWidthnm.Location = new System.Drawing.Point(147, 187);
		this.lblSlitWidthnm.Name = "lblSlitWidthnm";
		this.lblSlitWidthnm.Size = new System.Drawing.Size(24, 18);
		this.lblSlitWidthnm.TabIndex = 28;
		this.lblSlitWidthnm.Text = "nm";
		this.lblSlitWidthnm.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//lblPMTVolts
		//
		this.lblPMTVolts.BackColor = System.Drawing.Color.Transparent;
		this.lblPMTVolts.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblPMTVolts.Location = new System.Drawing.Point(147, 39);
		this.lblPMTVolts.Name = "lblPMTVolts";
		this.lblPMTVolts.Size = new System.Drawing.Size(32, 18);
		this.lblPMTVolts.TabIndex = 27;
		this.lblPMTVolts.Text = "volts";
		this.lblPMTVolts.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//lblD2CurmA
		//
		this.lblD2CurmA.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblD2CurmA.Location = new System.Drawing.Point(147, 132);
		this.lblD2CurmA.Name = "lblD2CurmA";
		this.lblD2CurmA.Size = new System.Drawing.Size(22, 18);
		this.lblD2CurmA.TabIndex = 26;
		this.lblD2CurmA.Text = "mA";
		this.lblD2CurmA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//cmbModes
		//
		this.cmbModes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cmbModes.Items.AddRange(new object[] {
			"AA",
			"HCLE",
			"D2E",
			"EMISSION",
			"AABGC",
			"MABS",
			"SELFTEST"
		});
		this.cmbModes.Location = new System.Drawing.Point(72, 311);
		this.cmbModes.Name = "cmbModes";
		this.cmbModes.Size = new System.Drawing.Size(82, 21);
		this.cmbModes.TabIndex = 25;
		this.cmbModes.Visible = false;
		//
		//lblModes
		//
		this.lblModes.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblModes.Location = new System.Drawing.Point(8, 313);
		this.lblModes.Name = "lblModes";
		this.lblModes.Size = new System.Drawing.Size(57, 20);
		this.lblModes.TabIndex = 8;
		this.lblModes.Text = "Modes";
		this.lblModes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//lblSpeed
		//
		this.lblSpeed.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblSpeed.Location = new System.Drawing.Point(8, 283);
		this.lblSpeed.Name = "lblSpeed";
		this.lblSpeed.Size = new System.Drawing.Size(57, 20);
		this.lblSpeed.TabIndex = 7;
		this.lblSpeed.Text = "Speed";
		this.lblSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//cmbSpeed
		//
		this.cmbSpeed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cmbSpeed.Items.AddRange(new object[] {
			"FAST",
			"MEDIUM",
			"SLOW"
		});
		this.cmbSpeed.Location = new System.Drawing.Point(72, 281);
		this.cmbSpeed.Name = "cmbSpeed";
		this.cmbSpeed.Size = new System.Drawing.Size(82, 21);
		this.cmbSpeed.TabIndex = 24;
		this.cmbSpeed.Visible = false;
		//
		//lblSlitWidth
		//
		this.lblSlitWidth.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblSlitWidth.Location = new System.Drawing.Point(8, 153);
		this.lblSlitWidth.Name = "lblSlitWidth";
		this.lblSlitWidth.Size = new System.Drawing.Size(57, 28);
		this.lblSlitWidth.TabIndex = 5;
		this.lblSlitWidth.Text = "Entrance Slit Width";
		this.lblSlitWidth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//lblD2Cur
		//
		this.lblD2Cur.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblD2Cur.Location = new System.Drawing.Point(8, 127);
		this.lblD2Cur.Name = "lblD2Cur";
		this.lblD2Cur.Size = new System.Drawing.Size(57, 20);
		this.lblD2Cur.TabIndex = 2;
		this.lblD2Cur.Text = "D2 Cur";
		this.lblD2Cur.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//lblPMT
		//
		this.lblPMT.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblPMT.Location = new System.Drawing.Point(10, 35);
		this.lblPMT.Name = "lblPMT";
		this.lblPMT.Size = new System.Drawing.Size(57, 24);
		this.lblPMT.TabIndex = 1;
		this.lblPMT.Text = "Sample PMT";
		this.lblPMT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//AASEnergySpectrum
		//
		this.AASEnergySpectrum.AldysGraphCursor = null;
		this.AASEnergySpectrum.AldysGraphPrintColor = System.Drawing.Color.Black;
		this.AASEnergySpectrum.Anchor = (System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right;
		this.AASEnergySpectrum.BackColor = System.Drawing.Color.LightGray;
		this.AASEnergySpectrum.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.AASEnergySpectrum.GraphDataSource = null;
		this.AASEnergySpectrum.GraphImage = null;
		this.AASEnergySpectrum.IsShowGrid = true;
		this.AASEnergySpectrum.Location = new System.Drawing.Point(184, 16);
		this.AASEnergySpectrum.Name = "AASEnergySpectrum";
		this.AASEnergySpectrum.Size = new System.Drawing.Size(618, 402);
		this.AASEnergySpectrum.TabIndex = 25;
		this.AASEnergySpectrum.UseDefaultSettings = true;
		this.AASEnergySpectrum.XAxisDateMax = new System.DateTime((long)0);
		this.AASEnergySpectrum.XAxisDateMin = new System.DateTime((long)0);
		this.AASEnergySpectrum.XAxisDateScaleFormat = AAS203.AASGraph.enumDateScaleFormat.YYYY;
		this.AASEnergySpectrum.XAxisLabel = "X Values";
		this.AASEnergySpectrum.XAxisMax = 100;
		this.AASEnergySpectrum.XAxisMin = 0;
		this.AASEnergySpectrum.XAxisMinorStep = 5;
		this.AASEnergySpectrum.XAxisScaleFormat = null;
		this.AASEnergySpectrum.XAxisStep = 10;
		this.AASEnergySpectrum.XAxisType = AldysGraph.AxisType.Linear;
		this.AASEnergySpectrum.YAxisLabel = "Y Values";
		this.AASEnergySpectrum.YAxisMax = 100;
		this.AASEnergySpectrum.YAxisMin = -1;
		this.AASEnergySpectrum.YAxisMinorStep = 5;
		this.AASEnergySpectrum.YAxisScaleFormat = null;
		this.AASEnergySpectrum.YAxisStep = 10;
		this.AASEnergySpectrum.YAxisType = AldysGraph.AxisType.Linear;
		//
		//btnExtinguish
		//
		this.btnExtinguish.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnExtinguish.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnExtinguish.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnExtinguish.Location = new System.Drawing.Point(382, 243);
		this.btnExtinguish.Name = "btnExtinguish";
		this.btnExtinguish.Size = new System.Drawing.Size(40, 18);
		this.btnExtinguish.TabIndex = 48;
		this.btnExtinguish.TabStop = false;
		this.btnExtinguish.Text = "&Extinguish";
		this.btnExtinguish.TextAlign = System.Drawing.ContentAlignment.TopLeft;
		//
		//btnIgnite
		//
		this.btnIgnite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnIgnite.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnIgnite.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnIgnite.Location = new System.Drawing.Point(380, 244);
		this.btnIgnite.Name = "btnIgnite";
		this.btnIgnite.Size = new System.Drawing.Size(44, 17);
		this.btnIgnite.TabIndex = 49;
		this.btnIgnite.TabStop = false;
		this.btnIgnite.Text = "&Ignition";
		this.btnIgnite.TextAlign = System.Drawing.ContentAlignment.TopLeft;
		//
		//btnN2OIgnite
		//
		this.btnN2OIgnite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnN2OIgnite.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnN2OIgnite.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnN2OIgnite.Location = new System.Drawing.Point(400, 250);
		this.btnN2OIgnite.Name = "btnN2OIgnite";
		this.btnN2OIgnite.Size = new System.Drawing.Size(5, 5);
		this.btnN2OIgnite.TabIndex = 137;
		this.btnN2OIgnite.TabStop = false;
		this.btnN2OIgnite.Text = "N2O&C";
		this.btnN2OIgnite.TextAlign = System.Drawing.ContentAlignment.TopLeft;
		//
		//mnuDataProcessing
		//
		this.mnuDataProcessing.Items.AddRange(new NETXP.Controls.Bars.CommandBarItem[] {
			this.mnuStart,
			this.mnuLampParameters,
			this.mnuSmooth,
			this.mnuPeakPick,
			this.mnuClearSpectrum,
			this.mnuPrintGraph
		});
		this.mnuDataProcessing.Text = "Data &Processing";
		//
		//mnuStart
		//
		this.mnuStart.Image = (System.Drawing.Image)resources.GetObject("mnuStart.Image");
		this.mnuStart.Shortcut = System.Windows.Forms.Shortcut.CtrlT;
		this.mnuStart.Text = "&Start";
		//
		//mnuLampParameters
		//
		this.mnuLampParameters.Image = (System.Drawing.Image)resources.GetObject("mnuLampParameters.Image");
		this.mnuLampParameters.Shortcut = System.Windows.Forms.Shortcut.CtrlA;
		this.mnuLampParameters.Text = "Lamp Parameter";
		//
		//mnuSmooth
		//
		this.mnuSmooth.Image = (System.Drawing.Image)resources.GetObject("mnuSmooth.Image");
		this.mnuSmooth.Shortcut = System.Windows.Forms.Shortcut.CtrlM;
		this.mnuSmooth.Text = "S&mooth";
		//
		//mnuPeakPick
		//
		this.mnuPeakPick.Image = (System.Drawing.Image)resources.GetObject("mnuPeakPick.Image");
		this.mnuPeakPick.Shortcut = System.Windows.Forms.Shortcut.CtrlK;
		this.mnuPeakPick.Text = "Peak &Pick";
		//
		//mnuClearSpectrum
		//
		this.mnuClearSpectrum.Image = (System.Drawing.Image)resources.GetObject("mnuClearSpectrum.Image");
		this.mnuClearSpectrum.Shortcut = System.Windows.Forms.Shortcut.CtrlC;
		this.mnuClearSpectrum.Text = "Clear Spectrum";
		//
		//mnuPrintGraph
		//
		this.mnuPrintGraph.Image = (System.Drawing.Image)resources.GetObject("mnuPrintGraph.Image");
		this.mnuPrintGraph.Shortcut = System.Windows.Forms.Shortcut.CtrlG;
		this.mnuPrintGraph.Text = "Print Graph";
		//
		//mnuLoadSpectrunFile
		//
		this.mnuLoadSpectrunFile.Image = (System.Drawing.Image)resources.GetObject("mnuLoadSpectrunFile.Image");
		this.mnuLoadSpectrunFile.Shortcut = System.Windows.Forms.Shortcut.CtrlL;
		this.mnuLoadSpectrunFile.Text = "&Load Spectrum File";
		//
		//mnuSaveSpectrumFile
		//
		this.mnuSaveSpectrumFile.Image = (System.Drawing.Image)resources.GetObject("mnuSaveSpectrumFile.Image");
		this.mnuSaveSpectrumFile.Shortcut = System.Windows.Forms.Shortcut.CtrlS;
		this.mnuSaveSpectrumFile.Text = "&Save Spectrum File";
		//
		//mnuFile
		//
		this.mnuFile.Infrequent = true;
		this.mnuFile.Items.AddRange(new NETXP.Controls.Bars.CommandBarItem[] {
			this.mnuParameters,
			this.mnuLoadSpectrunFile,
			this.mnuSaveSpectrumFile,
			this.CommandBarSeparatorItem1,
			this.mnuExit
		});
		this.mnuFile.Text = "&File";
		//
		//mnuParameters
		//
		this.mnuParameters.Image = (System.Drawing.Image)resources.GetObject("mnuParameters.Image");
		this.mnuParameters.Shortcut = System.Windows.Forms.Shortcut.CtrlP;
		this.mnuParameters.Text = "Parame&ters";
		//
		//mnuExit
		//
		this.mnuExit.Image = (System.Drawing.Image)resources.GetObject("mnuExit.Image");
		this.mnuExit.Shortcut = System.Windows.Forms.Shortcut.CtrlR;
		this.mnuExit.ShowText = true;
		this.mnuExit.Text = "Return";
		//
		//MenuBarEnergySpectrumMode
		//
		this.MenuBarEnergySpectrumMode.BackColor = System.Drawing.Color.Transparent;
		this.MenuBarEnergySpectrumMode.Controls.Add(this.mnuAutoIgnition);
		this.MenuBarEnergySpectrumMode.CustomizeText = "&Customize Toolbar...";
		this.MenuBarEnergySpectrumMode.Dock = System.Windows.Forms.DockStyle.Top;
		this.MenuBarEnergySpectrumMode.FullRow = true;
		this.MenuBarEnergySpectrumMode.ID = 621;
		this.MenuBarEnergySpectrumMode.Items.AddRange(new NETXP.Controls.Bars.CommandBarItem[] {
			this.mnuFile,
			this.mnuDataProcessing,
			this.mnuGraphOptions,
			this.mnuOthers
		});
		this.MenuBarEnergySpectrumMode.Location = new System.Drawing.Point(0, 0);
		this.MenuBarEnergySpectrumMode.Margins.Bottom = 1;
		this.MenuBarEnergySpectrumMode.Margins.Left = 1;
		this.MenuBarEnergySpectrumMode.Margins.Right = 1;
		this.MenuBarEnergySpectrumMode.Margins.Top = 1;
		this.MenuBarEnergySpectrumMode.Name = "MenuBarEnergySpectrumMode";
		this.MenuBarEnergySpectrumMode.Size = new System.Drawing.Size(804, 23);
		this.MenuBarEnergySpectrumMode.Style = NETXP.Controls.Bars.CommandBarStyle.Menu;
		this.MenuBarEnergySpectrumMode.TabIndex = 0;
		this.MenuBarEnergySpectrumMode.TabStop = false;
		this.MenuBarEnergySpectrumMode.Text = "";
		//
		//mnuAutoIgnition
		//
		this.mnuAutoIgnition.BackColor = System.Drawing.Color.Transparent;
		this.mnuAutoIgnition.CustomizeText = "&Customize Toolbar...";
		this.mnuAutoIgnition.FullRow = true;
		this.mnuAutoIgnition.ID = 5117;
		this.mnuAutoIgnition.Items.AddRange(new NETXP.Controls.Bars.CommandBarItem[] {
			this.mnuIgnite,
			this.mnuExtinguish
		});
		this.mnuAutoIgnition.Location = new System.Drawing.Point(540, 28);
		this.mnuAutoIgnition.Margins.Bottom = 1;
		this.mnuAutoIgnition.Margins.Left = 1;
		this.mnuAutoIgnition.Margins.Right = 1;
		this.mnuAutoIgnition.Margins.Top = 1;
		this.mnuAutoIgnition.Name = "mnuAutoIgnition";
		this.mnuAutoIgnition.Size = new System.Drawing.Size(112, 23);
		this.mnuAutoIgnition.Style = NETXP.Controls.Bars.CommandBarStyle.Menu;
		this.mnuAutoIgnition.TabIndex = 2;
		this.mnuAutoIgnition.TabStop = false;
		this.mnuAutoIgnition.Text = "AutoIgnition";
		//
		//mnuIgnite
		//
		this.mnuIgnite.Shortcut = System.Windows.Forms.Shortcut.CtrlI;
		this.mnuIgnite.Text = "Ignite";
		//
		//mnuExtinguish
		//
		this.mnuExtinguish.PadHorizontal = 5;
		this.mnuExtinguish.Shortcut = System.Windows.Forms.Shortcut.CtrlE;
		this.mnuExtinguish.Text = "Extinguish";
		//
		//mnuGraphOptions
		//
		this.mnuGraphOptions.Items.AddRange(new NETXP.Controls.Bars.CommandBarItem[] {
			this.mnuPeakEdit,
			this.mnuGrid,
			this.mnuLegends,
			this.mnuShowXYValues,
			this.mnuChangeScale,
			this.mnuOverlay
		});
		this.mnuGraphOptions.Shortcut = System.Windows.Forms.Shortcut.CtrlG;
		this.mnuGraphOptions.Text = "&Graph Options";
		//
		//mnuPeakEdit
		//
		this.mnuPeakEdit.Image = (System.Drawing.Image)resources.GetObject("mnuPeakEdit.Image");
		this.mnuPeakEdit.Shortcut = System.Windows.Forms.Shortcut.CtrlE;
		this.mnuPeakEdit.Text = "Peak &Edit";
		//
		//mnuGrid
		//
		this.mnuGrid.Image = (System.Drawing.Image)resources.GetObject("mnuGrid.Image");
		this.mnuGrid.Shortcut = System.Windows.Forms.Shortcut.CtrlI;
		this.mnuGrid.Text = "&Grid";
		//
		//mnuLegends
		//
		this.mnuLegends.Image = (System.Drawing.Image)resources.GetObject("mnuLegends.Image");
		this.mnuLegends.Shortcut = System.Windows.Forms.Shortcut.CtrlD;
		this.mnuLegends.Text = "&Legends";
		//
		//mnuShowXYValues
		//
		this.mnuShowXYValues.Image = (System.Drawing.Image)resources.GetObject("mnuShowXYValues.Image");
		this.mnuShowXYValues.Shortcut = System.Windows.Forms.Shortcut.CtrlO;
		this.mnuShowXYValues.Text = "SHOW X, Y VALUES";
		//
		//mnuChangeScale
		//
		this.mnuChangeScale.Image = (System.Drawing.Image)resources.GetObject("mnuChangeScale.Image");
		this.mnuChangeScale.Text = "Change Scale";
		//
		//mnuOverlay
		//
		this.mnuOverlay.Checked = true;
		this.mnuOverlay.Text = "&Overlay";
		this.mnuOverlay.Visible = false;
		//
		//mnuOthers
		//
		this.mnuOthers.Items.AddRange(new NETXP.Controls.Bars.CommandBarItem[] {
			this.mnuPositionToMaxima,
			this.CommandBarSeparatorItem2,
			this.mnuContiniousTimeScan
		});
		this.mnuOthers.Text = "&Others";
		//
		//mnuPositionToMaxima
		//
		this.mnuPositionToMaxima.Image = (System.Drawing.Image)resources.GetObject("mnuPositionToMaxima.Image");
		this.mnuPositionToMaxima.Shortcut = System.Windows.Forms.Shortcut.CtrlX;
		this.mnuPositionToMaxima.Text = "&Position To Maxima";
		//
		//mnuContiniousTimeScan
		//
		this.mnuContiniousTimeScan.Image = (System.Drawing.Image)resources.GetObject("mnuContiniousTimeScan.Image");
		this.mnuContiniousTimeScan.Shortcut = System.Windows.Forms.Shortcut.CtrlN;
		this.mnuContiniousTimeScan.Text = "&Continious Time Scan";
		//
		//StatusBar1
		//
		this.StatusBar1.Location = new System.Drawing.Point(0, 561);
		this.StatusBar1.Name = "StatusBar1";
		this.StatusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
			this.StatusBarPanelInfo,
			this.ProgressPanel,
			this.StatusBarPanelDate
		});
		this.StatusBar1.ShowPanels = true;
		this.StatusBar1.Size = new System.Drawing.Size(804, 24);
		this.StatusBar1.TabIndex = 6;
		this.StatusBar1.Text = "StatusBar1";
		//
		//StatusBarPanelInfo
		//
		this.StatusBarPanelInfo.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
		this.StatusBarPanelInfo.MinWidth = 40;
		this.StatusBarPanelInfo.Style = System.Windows.Forms.StatusBarPanelStyle.OwnerDraw;
		this.StatusBarPanelInfo.Width = 388;
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
		this.StatusBarPanelDate.MinWidth = 200;
		this.StatusBarPanelDate.Style = System.Windows.Forms.StatusBarPanelStyle.OwnerDraw;
		this.StatusBarPanelDate.Width = 200;
		//
		//ToolBar
		//
		this.ToolBar.BackColor = System.Drawing.Color.Transparent;
		this.ToolBar.CustomizeText = "&Customize Toolbar...";
		this.ToolBar.Dock = System.Windows.Forms.DockStyle.Top;
		this.ToolBar.ID = 7406;
		this.ToolBar.Items.AddRange(new NETXP.Controls.Bars.CommandBarItem[] {
			this.tlbbtnReturn,
			this.CommandBarSeparatorItem3,
			this.tlbbtnParameters,
			this.tlbbtnLoadspectrumFile,
			this.tlbbtnSaveSpectrumFile,
			this.CommandBarSeparatorItem4,
			this.tlbbtnStart,
			this.tlbbtnLampParameters,
			this.tlbbtnSmooth,
			this.tlbbtnPeakPick,
			this.tlbbtnClearSpectrum,
			this.tlbbtnChangeScale,
			this.tlbbtnPrintGraph,
			this.CommandBarSeparatorItem5,
			this.tlbbtnPeakEdit,
			this.tlbbtnGrid,
			this.tlbbtnLegends,
			this.tlbbtnShowXYValues,
			this.CommandBarSeparatorItem6,
			this.tlbbtnPositionToMaxima,
			this.tlbbtnContiniousTimeScan
		});
		this.ToolBar.Location = new System.Drawing.Point(0, 23);
		this.ToolBar.Margins.Bottom = 1;
		this.ToolBar.Margins.Left = 1;
		this.ToolBar.Margins.Right = 1;
		this.ToolBar.Margins.Top = 1;
		this.ToolBar.MenuEnabled = false;
		this.ToolBar.Name = "ToolBar";
		this.ToolBar.Size = new System.Drawing.Size(804, 34);
		this.ToolBar.TabIndex = 1;
		this.ToolBar.TabStop = false;
		this.ToolBar.Text = "";
		//
		//tlbbtnReturn
		//
		this.tlbbtnReturn.Image = (System.Drawing.Image)resources.GetObject("tlbbtnReturn.Image");
		this.tlbbtnReturn.Shortcut = System.Windows.Forms.Shortcut.CtrlR;
		this.tlbbtnReturn.Text = "RETURN[CTRL+R]";
		//
		//tlbbtnParameters
		//
		this.tlbbtnParameters.Image = (System.Drawing.Image)resources.GetObject("tlbbtnParameters.Image");
		this.tlbbtnParameters.Shortcut = System.Windows.Forms.Shortcut.CtrlP;
		this.tlbbtnParameters.Text = "PARAMETERS[CTRL+P]";
		//
		//tlbbtnLoadspectrumFile
		//
		this.tlbbtnLoadspectrumFile.Image = (System.Drawing.Image)resources.GetObject("tlbbtnLoadspectrumFile.Image");
		this.tlbbtnLoadspectrumFile.Shortcut = System.Windows.Forms.Shortcut.CtrlF;
		this.tlbbtnLoadspectrumFile.Text = "LOAD SPECTRUM FILE[CTRL+F]";
		//
		//tlbbtnSaveSpectrumFile
		//
		this.tlbbtnSaveSpectrumFile.Image = (System.Drawing.Image)resources.GetObject("tlbbtnSaveSpectrumFile.Image");
		this.tlbbtnSaveSpectrumFile.Shortcut = System.Windows.Forms.Shortcut.CtrlS;
		this.tlbbtnSaveSpectrumFile.Text = "SAVE SPECTRUM FILE[CTRL+S]";
		//
		//tlbbtnStart
		//
		this.tlbbtnStart.Image = (System.Drawing.Image)resources.GetObject("tlbbtnStart.Image");
		this.tlbbtnStart.Shortcut = System.Windows.Forms.Shortcut.CtrlT;
		this.tlbbtnStart.Text = "START[CTRL+T]";
		//
		//tlbbtnLampParameters
		//
		this.tlbbtnLampParameters.Image = (System.Drawing.Image)resources.GetObject("tlbbtnLampParameters.Image");
		this.tlbbtnLampParameters.Shortcut = System.Windows.Forms.Shortcut.CtrlL;
		this.tlbbtnLampParameters.Text = "LAMP PARAMETERES[CTRL+L]";
		//
		//tlbbtnSmooth
		//
		this.tlbbtnSmooth.Image = (System.Drawing.Image)resources.GetObject("tlbbtnSmooth.Image");
		this.tlbbtnSmooth.Shortcut = System.Windows.Forms.Shortcut.CtrlM;
		this.tlbbtnSmooth.Text = "SMOOTH[CTRL+M]";
		//
		//tlbbtnPeakPick
		//
		this.tlbbtnPeakPick.Image = (System.Drawing.Image)resources.GetObject("tlbbtnPeakPick.Image");
		this.tlbbtnPeakPick.Shortcut = System.Windows.Forms.Shortcut.CtrlK;
		this.tlbbtnPeakPick.Text = "PEAK PICK[CTRL+K]";
		//
		//tlbbtnClearSpectrum
		//
		this.tlbbtnClearSpectrum.Image = (System.Drawing.Image)resources.GetObject("tlbbtnClearSpectrum.Image");
		this.tlbbtnClearSpectrum.Shortcut = System.Windows.Forms.Shortcut.CtrlC;
		this.tlbbtnClearSpectrum.Text = "CLEAR SPECTRUM[CTRL+C]";
		//
		//tlbbtnChangeScale
		//
		this.tlbbtnChangeScale.Image = (System.Drawing.Image)resources.GetObject("tlbbtnChangeScale.Image");
		this.tlbbtnChangeScale.Shortcut = System.Windows.Forms.Shortcut.CtrlH;
		this.tlbbtnChangeScale.Text = "CHANGE SCALE[CTRL+H]";
		//
		//tlbbtnPrintGraph
		//
		this.tlbbtnPrintGraph.Image = (System.Drawing.Image)resources.GetObject("tlbbtnPrintGraph.Image");
		this.tlbbtnPrintGraph.Text = "Print Graph";
		//
		//tlbbtnPeakEdit
		//
		this.tlbbtnPeakEdit.Image = (System.Drawing.Image)resources.GetObject("tlbbtnPeakEdit.Image");
		this.tlbbtnPeakEdit.Text = "PEAK EDIT[CTRL+E]";
		//
		//tlbbtnGrid
		//
		this.tlbbtnGrid.Image = (System.Drawing.Image)resources.GetObject("tlbbtnGrid.Image");
		this.tlbbtnGrid.Text = "GRID[CTRL+I]";
		//
		//tlbbtnLegends
		//
		this.tlbbtnLegends.Image = (System.Drawing.Image)resources.GetObject("tlbbtnLegends.Image");
		this.tlbbtnLegends.Text = "LEGENDS[CTRL+D]";
		//
		//tlbbtnShowXYValues
		//
		this.tlbbtnShowXYValues.Image = (System.Drawing.Image)resources.GetObject("tlbbtnShowXYValues.Image");
		this.tlbbtnShowXYValues.Text = "SHOW X, Y VALUES[CTRL+O]";
		//
		//tlbbtnPositionToMaxima
		//
		this.tlbbtnPositionToMaxima.Image = (System.Drawing.Image)resources.GetObject("tlbbtnPositionToMaxima.Image");
		this.tlbbtnPositionToMaxima.Shortcut = System.Windows.Forms.Shortcut.CtrlX;
		this.tlbbtnPositionToMaxima.Text = "POSITION TO MAXIMA[CTRL+";
		//
		//tlbbtnContiniousTimeScan
		//
		this.tlbbtnContiniousTimeScan.Image = (System.Drawing.Image)resources.GetObject("tlbbtnContiniousTimeScan.Image");
		this.tlbbtnContiniousTimeScan.Shortcut = System.Windows.Forms.Shortcut.CtrlO;
		this.tlbbtnContiniousTimeScan.Text = "CONTINIOUS TIME SCAN[CTRL+O]";
		//
		//CommandBarButtonItem1
		//
		this.CommandBarButtonItem1.Shortcut = System.Windows.Forms.Shortcut.CtrlG;
		this.CommandBarButtonItem1.Text = "&Graph Options";
		//
		//CommandBarButtonItem2
		//
		this.CommandBarButtonItem2.Image = (System.Drawing.Image)resources.GetObject("CommandBarButtonItem2.Image");
		this.CommandBarButtonItem2.Shortcut = System.Windows.Forms.Shortcut.CtrlG;
		this.CommandBarButtonItem2.Text = "Print Graph";
		//
		//CommandBarButtonItem3
		//
		this.CommandBarButtonItem3.Image = (System.Drawing.Image)resources.GetObject("CommandBarButtonItem3.Image");
		this.CommandBarButtonItem3.Shortcut = System.Windows.Forms.Shortcut.CtrlG;
		this.CommandBarButtonItem3.Text = "Print Graph";
		//
		//CommandBarButtonItem4
		//
		this.CommandBarButtonItem4.Text = "&Graph Options";
		//
		//TimerEnergyDisplay
		//
		this.TimerEnergyDisplay.Interval = 1000;
		//
		//frmEnergySpectrumDBMode
		//
		this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
		this.ClientSize = new System.Drawing.Size(804, 585);
		this.Controls.Add(this.CustomPanelMain);
		this.Controls.Add(this.StatusBar1);
		this.Controls.Add(this.ToolBar);
		this.Controls.Add(this.MenuBarEnergySpectrumMode);
		this.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		this.MinimizeBox = false;
		this.Name = "frmEnergySpectrumDBMode";
		this.ShowInTaskbar = false;
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Energy Spectrum Mode";
		this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
		this.CustomPanelMain.ResumeLayout(false);
		this.CustomPanelBottom.ResumeLayout(false);
		this.CustomPanelTop.ResumeLayout(false);
		this.grpBeamType.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.MenuBarEnergySpectrumMode).EndInit();
		this.MenuBarEnergySpectrumMode.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.mnuAutoIgnition).EndInit();
		((System.ComponentModel.ISupportInitialize)this.StatusBarPanelInfo).EndInit();
		((System.ComponentModel.ISupportInitialize)this.ProgressPanel).EndInit();
		((System.ComponentModel.ISupportInitialize)this.StatusBarPanelDate).EndInit();
		((System.ComponentModel.ISupportInitialize)this.ToolBar).EndInit();
		this.ResumeLayout(false);

	}

	#End Region

	#Region " Form Events"

	private void  // ERROR: Handles clauses are not supported in C#
frmEnergySpectrumMode_Load(object sender, System.EventArgs e)
	{
		if (mblnAvoidProcessing == true) {
			return;
		}
		CWaitCursor objWait = new CWaitCursor();
		try {
			Application.DoEvents();
			cmdChangeScale.BringToFront();
			btnStart.BringToFront();

			MenuBarEnergySpectrumMode.BackColor = System.Drawing.Color.Gainsboro;

			mblnAvoidProcessing = true;
			ShowProgressBar(gstrTitleInstrumentType + ConstFormLoad);
			funcInitialise();
			TimerEnergyDisplay.Enabled = true;
			HideProgressBar();
			//Saurabh 10.07.07 To bring status form in front
			gobjfrmStatus.Show();
			//Saurabh

			gobjclsTimer.subTimerStart(StatusBar1);
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			mblnAvoidProcessing = false;

			if (!objWait == null) {
				objWait.Dispose();
			}
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	private void  // ERROR: Handles clauses are not supported in C#
frmEnergySpectrumMode_Closing(object sender, System.ComponentModel.CancelEventArgs e)
	{
		try {
			//        Call gobjMessageAdapter.ShowMessage(constCuvetteBurner)

			if (mblnAvoidProcessing == true) {
				e.Cancel = true;
				return;
			}
			if (!gobjclsTimer == null) {
				gobjclsTimer.subTimerStop();
			}

			////---- Added by Sachin Dokhale. Stop the Timer Energy Display when closing the mode
			TimerEnergyDisplay.Enabled = false;
			TimerEnergyDisplay.Stop();
			////---- Added by Sachin Dokhale Set the previous default Calibration mode
			gobjCommProtocol.funcCalibrationMode(m_bytCalibMode);


			//If Not (gstructSettings.AppMode = EnumAppMode.DemoMode) Then
			if (!((gstructSettings.AppMode == EnumAppMode.DemoMode) | (gstructSettings.AppMode == EnumAppMode.DemoMode_201) | (gstructSettings.AppMode == EnumAppMode.DemoMode_203D))) {
				////----- Added by Sachin Dokhale on 14.07.07
				if (!gstructSettings.ExeToRun == EnumApplicationMode.ServiceUtility) {
					if (!IsNothing(gobjMain)) {
						if (gobjMain.mobjController.IsThreadRunning == false) {
							gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay);
							Application.DoEvents();
							gobjMain.mobjController.Start(gobjclsBgFlameStatus);
						}
					}
					gobjfrmStatus.Visible = true;
					Application.DoEvents();
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
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	private void mnuExit_Click(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : mnuExit_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To close the Energy Spectrum Mode form
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 07.10.06
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		try {
			gobjclsTimer.subTimerStop();

			TimerEnergyDisplay.Enabled = false;
			TimerEnergyDisplay.Stop();
			if (mblnAvoidProcessing == true) {
				return;
			}
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

	private void mnuSaveSpectrumFile_Click(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : mnuSaveSpectrumFile_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 15.11.06
		// Revisions             : 
		//=====================================================================
		SaveFileDialog SaveFileDialog1 = new SaveFileDialog();
		CWaitCursor objWait = new CWaitCursor();
		if (mblnAvoidProcessing == true) {
			return;
		}

		try {
			mblnAvoidProcessing = true;
			//SaveFileDialog1.Filter = "Energy Spectrum File(*.spt)|*.spt"
			//SaveFileDialog1.Title = "Show an Energy Spectrum File"
			//SaveFileDialog1.ShowDialog()
			if (gintInstrumentBeamType == AAS203Library.Instrument.enumInstrumentBeamType.DoubleBeam) {
				funcSaveSpectrumFile_Double();
			} else {
				funcSaveSpectrumFile();
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
			mblnAvoidProcessing = false;
			//---------------------------------------------------------
		}
	}

	private void mnuLoadSpectrumFile_Click(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : mnuLoadSpectrunFile_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 15.11.06
		// Revisions             : 
		//=====================================================================

		OpenFileDialog OpenFileDialog1 = new OpenFileDialog();
		CWaitCursor objWait = new CWaitCursor();
		if (mblnAvoidProcessing == true) {
			return;
		}

		try {
			mblnAvoidProcessing = true;

			//OpenFileDialog1.Filter = "Energy Spectrum File(*.spt)|*.spt"
			//OpenFileDialog1.Title = "Show an Energy Spectrum File"
			//OpenFileDialog1.ShowDialog()
			if (gintInstrumentBeamType == AAS203Library.Instrument.enumInstrumentBeamType.DoubleBeam) {
				funcLoadSpectrumFile_Double();
			} else {
				funcLoadSpectrumFile();
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
			mblnAvoidProcessing = false;
			//---------------------------------------------------------
		}
		//If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
		//    Dim sr As New System.IO.StreamReader(OpenFileDialog1.FileName)
		//    MessageBox.Show(sr.ReadToEnd, Name, MessageBoxButtons.AbortRetryIgnore, _
		//    MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1, _
		//    MessageBoxOptions.ServiceNotification)
		//    sr.Close()
		//End If

	}

	private void mnuAbsTransmission_Click(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : mnuAbsTransmission_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 15.11.06
		// Revisions             : 
		//=====================================================================

		CWaitCursor objWait = new CWaitCursor();
		if (mblnAvoidProcessing == true) {
			return;
		}

		try {


			mblnAvoidProcessing = true;
			funcAbsConvertTransmission();

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
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
			mblnAvoidProcessing = false;
			//---------------------------------------------------------
		}
	}

	private void mnuSmoothGraph_Click(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : mnuSmoothGraph_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 15.11.06
		// Revisions             : 
		//=====================================================================

		CWaitCursor objWait = new CWaitCursor();

		try {
			subSmoothGraph();

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
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
			mblnAvoidProcessing = false;
			//---------------------------------------------------------
		}
	}

	private void mnuContiniousTimeScan_Click(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : mnuContiniousTimeScan_Click
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
		object objfrmTimeScan;
		//New frmTimeScanMode
		CWaitCursor objWait = new CWaitCursor();

		try {
			if ((gstructSettings.Enable21CFR == true)) {
				if (!funcCheckActivityAuthentication(enumActivityAuthentication.Energy_Spectrum_Mode, gstructUserDetails.Access)) {
					return;
				}
				gfuncInsertActivityLog(EnumModules.TimeScan, "TimeScan_Mode Accessed");
			}

			TimerEnergyDisplay.Enabled = false;
			TimerEnergyDisplay.Stop();
			gintSpectrumMode = modGlobalDeclarations.EnumSpectrumMode.TimeScan;
			if (gstructSettings.AppMode == EnumAppMode.FullVersion_203D) {
				if (gintInstrumentBeamType == AAS203Library.Instrument.enumInstrumentBeamType.SingleBeam | gintInstrumentBeamType == AAS203Library.Instrument.enumInstrumentBeamType.ReferenceBeam) {
					//objfrmTimeScan = New frmTimeScanMode
					objfrmTimeScan = new frmTimeScanDBMode();
				} else {
					objfrmTimeScan = new frmTimeScanDBMode();
				}
			////----- Modify by Sachin Dokhale 

			} else if (gstructSettings.AppMode == EnumAppMode.FullVersion_203 | gstructSettings.AppMode == EnumAppMode.FullVersion_201) {
				objfrmTimeScan = new frmTimeScanMode();
			} else {
				if (gintInstrumentBeamType == AAS203Library.Instrument.enumInstrumentBeamType.DoubleBeam) {
					objfrmTimeScan = new frmTimeScanDBMode();
				} else {
					//objfrmTimeScan = New frmTimeScanMode
					objfrmTimeScan = new frmTimeScanDBMode();
				}
				////-----
			}

			//gobjclsTimer.subTimerStart(StatusBar1)
			gobjclsTimer.subTimerStop();
			if (objfrmTimeScan.ShowDialog() == DialogResult.OK) {
				Application.DoEvents();
				gobjclsTimer.subTimerStart(StatusBar1);
			}
			mblnReSetSpectrumParameter = true;
			funcGetInstParameter();
			funcSetSpectrumParameter(gobjInst.Mode);
			gintSpectrumMode = modGlobalDeclarations.EnumSpectrumMode.EnergySpectrum;

			gobjfrmStatus.Visible = true;
			TimerEnergyDisplay.Start();
			TimerEnergyDisplay.Enabled = true;
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

	private void btnStart_Click(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : btnStart_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 07.10.06
		// Revisions             : 
		//=====================================================================

		try {
			if (mAvoidProcessBtn) {
				return;
			}
			mAvoidProcessBtn = true;
			//Added by pankaj on 2 Dec 07
			if (mblnParameterProcessing == true) {
				return;
			}
			//----
			TimerEnergyDisplay.Enabled = false;
			if (mblnSpectrumStarted == false) {
				subStartScan();
			} else {
				subStopScan();
			}
			mAvoidProcessBtn = false;

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			mAvoidProcessBtn = false;
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			//mblnAvoidProcessing = False
			btnStart.Focus();
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	private void btnLampParameters_Click(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : btnLampParameters_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 07.10.06
		// Revisions             : 
		//=====================================================================
		try {
			if (ReInitLampInstParameters == true) {
				return;
			}
			//If Not (gstructSettings.AppMode = EnumAppMode.DemoMode) Then
			//If Not ((gstructSettings.AppMode = EnumAppMode.DemoMode) Or _
			//        (gstructSettings.AppMode = EnumAppMode.DemoMode_201) Or _
			//        (gstructSettings.AppMode = EnumAppMode.DemoMode_203D)) Then
			//    '//----- Added by Sachin Dokhale on 14.07.07
			//    If Not gstructSettings.ExeToRun = EnumApplicationMode.ServiceUtility Then
			//        If Not IsNothing(gobjMain) Then
			//            If gobjMain.mobjController.IsThreadRunning = True Then
			//                gobjMain.mobjController.Cancel()
			//                gobjCommProtocol.mobjCommdll.subTime_Delay(500)   '10.12.07
			//                Application.DoEvents()
			//            End If
			//        End If
			//    End If
			//End If
			TimerEnergyDisplay.Enabled = false;
			subLampParameterChanged();
			TimerEnergyDisplay.Enabled = false;
		//If Not (gstructSettings.AppMode = EnumAppMode.DemoMode) Then
		//If Not ((gstructSettings.AppMode = EnumAppMode.DemoMode) Or _
		//        (gstructSettings.AppMode = EnumAppMode.DemoMode_201) Or _
		//        (gstructSettings.AppMode = EnumAppMode.DemoMode_203D)) Then
		//    '//----- Added by Sachin Dokhale on 14.07.07
		//    If Not gstructSettings.ExeToRun = EnumApplicationMode.ServiceUtility Then
		//        If Not IsNothing(gobjMain) Then
		//            If gobjMain.mobjController.IsThreadRunning = False Then
		//                gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay)
		//                Application.DoEvents()
		//                gobjMain.mobjController.Start(gobjclsBgFlameStatus)
		//            End If
		//        End If
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
			//If Not (gstructSettings.AppMode = EnumAppMode.DemoMode) Then
			//If Not ((gstructSettings.AppMode = EnumAppMode.DemoMode) Or _
			//        (gstructSettings.AppMode = EnumAppMode.DemoMode_201) Or _
			//        (gstructSettings.AppMode = EnumAppMode.DemoMode_203D)) Then
			//    '//----- Added by Sachin Dokhale on 14.07.07
			//    If Not gstructSettings.ExeToRun = EnumApplicationMode.ServiceUtility Then
			//        If Not IsNothing(gobjMain) Then
			//            If gobjMain.mobjController.IsThreadRunning = True Then
			//                gobjMain.mobjController.Cancel()
			//                gobjCommProtocol.mobjCommdll.subTime_Delay(500)   '10.12.07
			//                Application.DoEvents()
			//            End If
			//        End If
			//    End If
			//End If

			//mblnAvoidProcessing = False
			//---------------------------------------------------------
		}
	}

	private void btnClearSpectrum_Click(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : btnClearSpectrum_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 07.10.06
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		try {
			subClearScan();
			AASEnergySpectrum.RemoveHighPeakLineLabel();
			this.AASEnergySpectrum.disablePeakEdit();
			//ADDED   by pankaj on 26 Aug 07 for pick edit bar
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
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
			btnClearSpectrum.Focus();
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	private void mnuPeakPick_Click(object sender, System.EventArgs e)
	{
		subPeakValley();

	}

	private void cmbSpeed_SelectedIndexChanged(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : cmbSpeed_SelectedIndexChanged
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 12.12.06
		// Revisions             : 
		//=====================================================================

		CWaitCursor objWait = new CWaitCursor();
		if (mblnAvoidProcessing == true) {
			return;
		}

		try {

			mblnAvoidProcessing = true;

			cmbSpeed.SelectedIndexChanged -= cmbSpeed_SelectedIndexChanged;

			if (funcSetSpeed(cmbSpeed.SelectedIndex) == true) {
			}
			cmbSpeed.SelectedIndexChanged += cmbSpeed_SelectedIndexChanged;

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
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
			mblnAvoidProcessing = false;
			//---------------------------------------------------------
		}
	}

	private void cmdOverlay_Click(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : cmdOverlay_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : 
		// Description           : check for overlay grapph
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Pankaj Bamb
		// Created               : 30.11.07
		// Revisions             : 
		//=====================================================================
		mnuOverlay.Checked = !mnuOverlay.Checked;
	}

	private void cmdChangeScale_Click(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : cmdChangeScale_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : 
		// Description           : select index id for Calibration mode
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 21.11.06
		// Revisions             : 
		//=====================================================================
		if (mblnAvoidProcessing == true) {
			return;
		}
		CWaitCursor objWait = new CWaitCursor();
		frmChangeScale objfrmChangeScale;


		try {
			mblnAvoidProcessing = true;
			TimerEnergyDisplay.Enabled = false;
			objfrmChangeScale = new frmChangeScale(mobjParameters, true);
			objfrmChangeScale.funcSetValidatingScale(gobjInst.Mode);
			if (objfrmChangeScale.ShowDialog() == DialogResult.OK) {
				TimerEnergyDisplay.Enabled = false;
				if (!objfrmChangeScale.SpectrumParameter == null) {
					//If mobjParameters.XaxisMax < objfrmChangeScale.SpectrumParameter.XaxisMax Then

					//End If

					//If mobjParameters.XaxisMin > objfrmChangeScale.SpectrumParameter.XaxisMin Then

					//End If

					mobjParameters.XaxisMax = objfrmChangeScale.SpectrumParameter.XaxisMax;
					mobjParameters.XaxisMin = objfrmChangeScale.SpectrumParameter.XaxisMin;
					mobjParameters.YaxisMax = objfrmChangeScale.SpectrumParameter.YaxisMax;
					WvStartRange = mobjParameters.XaxisMin;
					WvLastRange = mobjParameters.XaxisMax;
					mobjParameters.YaxisMin = objfrmChangeScale.SpectrumParameter.YaxisMin;
					lblWvPos.Text = mXValueLable + gobjInst.WavelengthCur;
					if (!funcGraphPreRequisite(mobjParameters.Cal_Mode, mobjParameters.XaxisMin, mobjParameters.XaxisMax, mobjParameters.YaxisMin, mobjParameters.YaxisMax)) {
						//Call gFuncShowMessage("Error in setting spectrum parameters", "Please Check Entered Spectrum Parameters", modConstants.EnumMessageType.Information)
						return;
					}
				}
				// ------------Added By Pankaj on 8 May 07
				AASEnergySpectrum.XAxisMin = mobjParameters.XaxisMin;
				AASEnergySpectrum.XAxisMax = mobjParameters.XaxisMax;

				AASEnergySpectrum.YAxisMin = mobjParameters.YaxisMin;
				AASEnergySpectrum.YAxisMax = mobjParameters.YaxisMax;
				gobjClsAAS203.Calculate_Analysis_Graph_Param(AASEnergySpectrum, ClsAAS203.enumChangeAxis.xyAxis);
				//--------------
			}
			objfrmChangeScale.Close();
			TimerEnergyDisplay.Enabled = true;


		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
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
			cmdChangeScale.Focus();
			mblnAvoidProcessing = false;
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	private void mnuParameters_Click(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : mnuParameters_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : 
		// Description           : select index id for Calibration mode
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 13.02.06
		// Revisions             : 
		//=====================================================================
		if (mblnAvoidProcessing == true) {
			return;
		}
		CWaitCursor objWait = new CWaitCursor();
		frmParameter objfrmParameter;

		try {
			mblnAvoidProcessing = true;

			objfrmParameter = new frmParameter(mobjParameters);
			if (objfrmParameter.ShowDialog() == DialogResult.OK) {
				if (!objfrmParameter.SpectrumParameter == null) {
					if (mobjParameters == null) {
						mobjParameters = new Spectrum.EnergySpectrumParameter();
					}
					mobjParameters.SpectrumName = objfrmParameter.SpectrumParameter.SpectrumName;
					mobjParameters.Comments = objfrmParameter.SpectrumParameter.Comments;
				}
			}
			objfrmParameter.Close();
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
			objfrmParameter.Dispose();
			if (!objWait == null) {
				objWait.Dispose();
			}
			mblnAvoidProcessing = false;
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	private void mnuPositionToMaxima_Click(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : mnuPositionToMaxima_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : 
		// Description           : Set Maxisise position
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 05.01.07
		// Revisions             : 
		//=====================================================================
		if (mblnAvoidProcessing == true) {
			return;
		}
		CWaitCursor objWait = new CWaitCursor();
		int intIsSetMaximisePosition;
		double dblMaximisePosition;
		int i;
		bool blnIsPeakFound = false;
		int CourveCount;

		try {
			mblnAvoidProcessing = true;

			if (mintChannelIndex > -1 & intCurveIndex > -1) {
				//If (ArrlstGraphCurveItem.Count > 0) Then
				if (!ArrlstGraphCurveItem(intCurveIndex) == null) {
					if ((CheckMaxPosition == false) & (intCurveIndex > -1)) {
						//intIsSetMaximisePosition = MsgBox(" Set Maximise Position ", MsgBoxStyle.YesNo)
						if (gobjMessageAdapter.ShowMessage(constSetMaximisePosition)) {
							//If intIsSetMaximisePosition = MsgBoxResult.Yes Then
							CheckMaxPosition = CheckMaxPosition ^ true;
						}
					} else {
						CheckMaxPosition = CheckMaxPosition ^ true;
					}


					if (CheckMaxPosition == true) {
						//AASEnergySpectrum.StopOnlineGraph(ArrlstGraphCurveItem(intCurveIndex))
						//AASEnergySpectrum.DrawHighestPeakLine(ArrlstGraphCurveItem(intCurveIndex)
						if (intCurveIndex > -1) {
							//intIsSetMaximisePosition = MsgBox(" Set Maximise Position ", MsgBoxStyle.YesNo)
							//If intIsSetMaximisePosition = MsgBoxResult.Yes Then
							//CheckMaxPosition = CheckMaxPosition Xor True
							mnuPositionToMaxima.CheckType = NETXP.Controls.Bars.ButtonItemCheckType.Checkmark;
							mnuPositionToMaxima.Checked = true;

							AASEnergySpectrum.DrawHighestPeakLine(ArrlstGraphCurveItem(intCurveIndex));
							AASEnergySpectrum.ShowHighPeakLineLabel("Maximise Position", false, 0);
							for (i = 0; i <= AASEnergySpectrum.AldysPane.CurveList.Count - 1; i++) {
								if (AASEnergySpectrum.AldysPane.CurveList(i).IsHighPeakLine) {
									dblMaximisePosition = AASEnergySpectrum.AldysPane.CurveList(i).HighPeakXValue;
									blnIsPeakFound = true;
									break; // TODO: might not be correct. Was : Exit For
								}
							}
							if (blnIsPeakFound == true) {
								if (gobjCommProtocol.Wavelength_Position(dblMaximisePosition, lblWvPos) == true) {
									gobjCommProtocol.mobjCommdll.subTime_Delay(100);
								}
								lblWvPos.Text = mXValueLable + gobjInst.WavelengthCur;
								lblWvPos.Refresh();
								//lblYValue.Text = mYValueLable & FormatNumber(AASEnergySpectrum.AldysPane.CurveList(i).HighPeakYValue, 2)
								//lblYValue.Refresh()
								TimerEnergyDisplay.Enabled = true;
							}
						}
					} else {
						mnuPositionToMaxima.Checked = false;
						AASEnergySpectrum.RemoveHighPeakLineLabel();

						//If AASEnergySpectrum.AldysPane.CurveList.Count > 0 Then
						for (i = 0; i <= AASEnergySpectrum.AldysPane.CurveList.Count - 1; i++) {
							//If AASEnergySpectrum.AldysPane.CurveList.Count > 0 Then
							if (AASEnergySpectrum.AldysPane.CurveList(i).IsHighPeakLine() == true) {
								AASEnergySpectrum.AldysPane.CurveList.RemoveAt(i);
							}
							//End If
						}
						//End If
						//AASEnergySpectrum.AldysPane.CurveList(0).IsHighPeakLine = False
						AASEnergySpectrum.Refresh();
						//CheckMaxPosition = False
					}
				}
				//End If
			}
			TimerEnergyDisplay.Enabled = true;
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
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
			mblnAvoidProcessing = false;
			//---------------------------------------------------------
		}
	}

	private void AASEnergySpectrum_GraphScaleChanged(double XMin, double XMax, double YMin, double YMax)
	{
		//=====================================================================
		// Procedure Name        :   AASEnergySpectrum_GraphScaleChanged
		// Description           :   Get Graph Scale
		// Purpose               :   
		// Parameters Passed     :   
		// Returns               :   
		// Parameters Affected   :   
		// Assumptions           :   
		// Dependencies          :   None.
		// Author                :   Sachin Dokhale
		// Created               :   16.02.07
		// Revisions             :
		//=====================================================================
		try {
			mobjParameters.XaxisMax = XMax;
			mobjParameters.XaxisMin = XMin;
			WvStartRange = mobjParameters.XaxisMin;
			WvLastRange = mobjParameters.XaxisMax;
			mobjParameters.YaxisMax = YMax;
			mobjParameters.YaxisMin = YMin;

			if (!funcGraphPreRequisite(mobjParameters.Cal_Mode, mobjParameters.XaxisMin, mobjParameters.XaxisMax, mobjParameters.YaxisMin, mobjParameters.YaxisMax)) {
				//Call gFuncShowMessage("Error in setting spectrum parameters", "Please Check Entered Spectrum Parameters", modConstants.EnumMessageType.Information)
				return;
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
		clsDataFileReport objclsDataFileReport = new clsDataFileReport();
		//Dim A1() As Double = {0, 0, 0, 0, 0, 0}

		try {
			if ((gstructSettings.Enable21CFR == true)) {
				if (!funcCheckActivityAuthentication(enumActivityAuthentication.Print, gstructUserDetails.Access)) {
					return;
					return;
				}
				gfuncInsertActivityLog(EnumModules.Print, "Print Energy Spectrum Mode Graph Accessed");
			}

			//If (toreported) Then 'OR NOT Method->RepReady )
			//gobjClsAAS203.SaveQuantResults(gobjNewMethod, A1, False)
			//toreported = False
			//AASEnergySpectrum.PrintPreViewGraph()
			objclsDataFileReport.DefaultFont = this.DefaultFont();

			objclsDataFileReport.funcPrintEnergy(AASEnergySpectrum, mobjParameters, "");


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

	#Region " Form Object "

	//Private Sub nudPMT_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

	//    nudPMT.Enabled = False
	//    mblnAvoidProcessing = True
	//    Call funcSetPmtVParameter(nudPMT.Value)
	//    mblnAvoidProcessing = False
	//    nudPMT.Enabled = True
	//End Sub

	private void nudPMT_ValueChanged(double ChangePmt)
	{

		try {
			//nudPMT.Enabled = False
			//If mblnAvoidProcessing = True Then
			//    Exit Sub
			//End If
			//mblnAvoidProcessing = True
			if (!(mobjclsBgSpectrum == null)) {
				mobjclsBgSpectrum.SpectrumWait = true;
				Application.DoEvents();
			}
			mblnParameterProcessing = true;
			//Added by pankaj on 2 Dec 07
			gobjCommProtocol.mobjCommdll.subTime_Delay(30);
			Application.DoEvents();
			funcSetPmtVParameter(nudPMT.Value);

			if (!(mobjclsBgSpectrum == null)) {
				mobjclsBgSpectrum.SpectrumWait = false;
				Application.DoEvents();
				gobjCommProtocol.mobjCommdll.subTime_Delay(30);
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
			//mblnAvoidProcessing = False
			//nudPMT.Enabled = True
			mblnParameterProcessing = false;
			//Added by pankaj on 2 Dec 07
		}

	}

	private void nudPMT_ValueEditorClick()
	{
		//=====================================================================
		// Procedure Name        : cmbModes_SelectedIndexChanged
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : 
		// Description           : select index id for Calibration mode
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 21.11.06
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		double dblReturnValue;
		try {
			//nudPMT.Enabled = False
			//If mblnAvoidProcessing = True Then
			//    Exit Sub
			//End If
			//mblnAvoidProcessing = True

			nudPMT.ValueEditorClick -= nudPMT_ValueEditorClick;
			Application.DoEvents();
			mblnParameterProcessing = true;
			//Added by pankaj on 2 Dec 07
			dblReturnValue = (int)gobjInst.PmtVoltage;
			if (funcSetFrmEditValue(dblReturnValue, "Set PMT (0 - 700)V", nudPMT.MinValue, nudPMT.MaxValue) == true) {
				nudPMT.Value = dblReturnValue;
			}

		//
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}

			nudPMT.ValueEditorClick += nudPMT_ValueEditorClick;
			//nudPMT.Enabled = True
			//mblnAvoidProcessing = False
			if (!objWait == null) {
				objWait.Dispose();
			}
			nudPMT.Focus();
			Application.DoEvents();
			mblnParameterProcessing = false;
			//Added by pankaj on 2 Dec 07
		}
	}

	private void nudPMT_Ref_ValueChanged(double ChangePmt)
	{

		try {
			//nudPMT_Ref.Enabled = False
			//If mblnAvoidProcessing = True Then
			//    Exit Sub
			//End If
			//mblnAvoidProcessing = True
			mblnParameterProcessing = true;
			//Added by pankaj on 2 Dec 07
			funcSetPmtVParameter_Ref(nudPMT_Ref.Value);


		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
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
			//mblnAvoidProcessing = False
			//nudPMT_Ref.Enabled = True
			mblnParameterProcessing = false;
			//Added by pankaj on 2 Dec 07
		}

	}

	private void nudPMT_Ref_ValueEditorClick()
	{
		//=====================================================================
		// Procedure Name        : cmbModes_SelectedIndexChanged
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : 
		// Description           : select index id for Calibration mode
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 21.11.06
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		double dblReturnValue;
		try {
			//nudPMT_Ref.Enabled = False
			//If mblnAvoidProcessing = True Then
			//    Exit Sub
			//End If
			//mblnAvoidProcessing = True

			nudPMT_Ref.ValueEditorClick -= nudPMT_Ref_ValueEditorClick;
			Application.DoEvents();
			mblnParameterProcessing = true;
			//Added by pankaj on 2 Dec 07
			dblReturnValue = (int)gobjInst.PmtVoltageReference;
			if (funcSetFrmEditValue(dblReturnValue, "Set Ref_PMT (0 - 700)V", nudPMT_Ref.MinValue, nudPMT_Ref.MaxValue) == true) {
				nudPMT_Ref.Value = dblReturnValue;
			}

		//
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			//mblnAvoidProcessing = False
			nudPMT_Ref.ValueEditorClick += nudPMT_Ref_ValueEditorClick;
			//nudPMT_Ref.Enabled = True
			if (!objWait == null) {
				objWait.Dispose();
			}
			nudPMT_Ref.Focus();
			Application.DoEvents();
			mblnParameterProcessing = false;
			//Added by pankaj on 2 Dec 07
		}
	}

	//Private Sub nudSlit_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
	//    nudSlit.Enabled = False
	//    mblnAvoidProcessing = True
	//    Call funcSetSlit_WidthParameter(nudSlit.Value)
	//    mblnAvoidProcessing = False
	//    nudSlit.Enabled = True
	//End Sub

	private void nudSlit_ValueChanged(double ChangeSlit)
	{
		try {
			//nudSlit.Enabled = False
			//If mblnAvoidProcessing = True Then
			//    Exit Sub
			//End If
			//mblnAvoidProcessing = True

			//RemoveHandler btnStart.Click, AddressOf btnStart_Click
			//RemoveHandler btnLampParameters.Click, AddressOf btnLampParameters_Click

			//RemoveHandler nudBurnerHeight.ValueEditorClick, AddressOf nudBurnerHeight_ValueEditorClick
			//RemoveHandler nudSlit_Ref.ValueEditorClick, AddressOf nudSlit_Ref_ValueEditorClick
			//RemoveHandler nudFuelRatio.ValueEditorClick, AddressOf nudFuelRatio_ValueEditorClick
			//RemoveHandler nudBurnerHeight.ValueEditorValueChanged, AddressOf nudBurnerHeight_ValueChanged
			//RemoveHandler nudSlit_Ref.ValueEditorValueChanged, AddressOf nudSlit_Ref_ValueChanged
			//RemoveHandler nudFuelRatio.ValueEditorValueChanged, AddressOf nudFuelRatio_ValueChanged
			mblnParameterProcessing = true;
			//Added by pankaj on 2 Dec 07
			funcSetSlit_WidthParameter(nudSlit.Value);
			//by pankaj on 18.1.08
			nudSlit_Ref.Value = (double)gobjClsAAS203.funcGet_SlitWidth;
			//CDbl(nudSlit.Value)  'by pankaj on 18.1.08
			nudSlit.ValueEditorValueChanged -= nudSlit_ValueChanged;
			//by pankaj on 18.1.08
			nudSlit.Value = (double)gobjClsAAS203.funcGet_SlitWidth;
			//CDbl(nudSlit.Value)  'by pankaj on 18.1.08
			nudSlit.ValueEditorValueChanged += nudSlit_ValueChanged;
			//by pankaj on 18.1.08
			nudSlit_Ref.Enabled = false;
			//by pankaj on 18.1.08
		//-----
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
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
			//nudSlit.Enabled = True
			//AddHandler btnStart.Click, AddressOf btnStart_Click
			//AddHandler btnLampParameters.Click, AddressOf btnLampParameters_Click

			//AddHandler nudBurnerHeight.ValueEditorClick, AddressOf nudBurnerHeight_ValueEditorClick
			//AddHandler nudSlit_Ref.ValueEditorClick, AddressOf nudSlit_Ref_ValueEditorClick
			//AddHandler nudFuelRatio.ValueEditorClick, AddressOf nudFuelRatio_ValueEditorClick
			//AddHandler nudBurnerHeight.ValueEditorValueChanged, AddressOf nudBurnerHeight_ValueChanged
			//AddHandler nudSlit_Ref.ValueEditorValueChanged, AddressOf nudSlit_Ref_ValueChanged
			//AddHandler nudFuelRatio.ValueEditorValueChanged, AddressOf nudFuelRatio_ValueChanged
			//mblnAvoidProcessing = False
			Application.DoEvents();
			mblnParameterProcessing = false;
			//Added by pankaj on 2 Dec 07
		}

	}

	private void nudSlit_ValueEditorClick()
	{
		//=====================================================================
		// Procedure Name        : cmbModes_SelectedIndexChanged
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : 
		// Description           : select index id for Calibration mode
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 21.11.06
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		double dblReturnValue;
		try {
			//nudSlit.Enabled = False
			//If mblnAvoidProcessing = True Then
			//    Exit Sub
			//End If
			//mblnAvoidProcessing = True

			nudSlit.ValueEditorClick -= nudSlit_ValueEditorClick;
			//RemoveHandler btnStart.Click, AddressOf btnStart_Click
			//RemoveHandler btnLampParameters.Click, AddressOf btnLampParameters_Click

			//RemoveHandler nudBurnerHeight.ValueEditorClick, AddressOf nudBurnerHeight_ValueEditorClick
			//RemoveHandler nudSlit_Ref.ValueEditorClick, AddressOf nudSlit_Ref_ValueEditorClick
			//RemoveHandler nudFuelRatio.ValueEditorClick, AddressOf nudFuelRatio_ValueEditorClick
			//RemoveHandler nudBurnerHeight.ValueEditorValueChanged, AddressOf nudBurnerHeight_ValueChanged
			//RemoveHandler nudSlit_Ref.ValueEditorValueChanged, AddressOf nudSlit_Ref_ValueChanged
			//RemoveHandler nudFuelRatio.ValueEditorValueChanged, AddressOf nudFuelRatio_ValueChanged
			mblnParameterProcessing = true;
			//Added by pankaj on 2 Dec 07
			Application.DoEvents();

			dblReturnValue = gobjClsAAS203.funcGet_SlitWidth(0);
			if (funcSetFrmEditValue(dblReturnValue, "Set Entrance Slit Width (0.0 - 2.0)nm", nudSlit.MinValue, nudSlit.MaxValue) == true) {
				nudSlit.Value = dblReturnValue;
			} else {
				nudSlit.Value = gobjClsAAS203.funcGet_SlitWidth(0);
			}

		//
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			//mblnAvoidProcessing = False
			nudSlit.ValueEditorClick += nudSlit_ValueEditorClick;
			//AddHandler btnStart.Click, AddressOf btnStart_Click
			//AddHandler btnLampParameters.Click, AddressOf btnLampParameters_Click

			//AddHandler nudBurnerHeight.ValueEditorClick, AddressOf nudBurnerHeight_ValueEditorClick
			//AddHandler nudSlit_Ref.ValueEditorClick, AddressOf nudSlit_Ref_ValueEditorClick
			//AddHandler nudFuelRatio.ValueEditorClick, AddressOf nudFuelRatio_ValueEditorClick
			//AddHandler nudBurnerHeight.ValueEditorValueChanged, AddressOf nudBurnerHeight_ValueChanged
			//AddHandler nudSlit_Ref.ValueEditorValueChanged, AddressOf nudSlit_Ref_ValueChanged
			//AddHandler nudFuelRatio.ValueEditorValueChanged, AddressOf nudFuelRatio_ValueChanged
			//nudSlit.Enabled = True
			if (!objWait == null) {
				objWait.Dispose();
			}
			nudSlit.Focus();
			mblnParameterProcessing = false;
			//Added by pankaj on 2 Dec 07
			Application.DoEvents();
		}
	}

	private void nudSlit_Ref_ValueChanged(double ChangeSlit)
	{
		try {
			//nudSlit_Ref.Enabled = False
			//If mblnAvoidProcessing = True Then
			//    Exit Sub
			//End If
			//mblnAvoidProcessing = True

			//RemoveHandler btnStart.Click, AddressOf btnStart_Click
			//RemoveHandler btnLampParameters.Click, AddressOf btnLampParameters_Click

			//RemoveHandler nudBurnerHeight.ValueEditorClick, AddressOf nudBurnerHeight_ValueEditorClick
			//RemoveHandler nudSlit.ValueEditorClick, AddressOf nudSlit_ValueEditorClick
			//RemoveHandler nudFuelRatio.ValueEditorClick, AddressOf nudFuelRatio_ValueEditorClick
			//RemoveHandler nudBurnerHeight.ValueEditorValueChanged, AddressOf nudBurnerHeight_ValueChanged
			//RemoveHandler nudSlit.ValueEditorValueChanged, AddressOf nudSlit_ValueChanged
			//RemoveHandler nudFuelRatio.ValueEditorValueChanged, AddressOf nudFuelRatio_ValueChanged
			mblnParameterProcessing = true;
			//Added by pankaj on 2 Dec 07
			funcSetSlit_WidthParameter_Ref(nudSlit_Ref.Value);


		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
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
			//nudSlit_Ref.Enabled = True
			//AddHandler btnStart.Click, AddressOf btnStart_Click
			//AddHandler btnLampParameters.Click, AddressOf btnLampParameters_Click

			//AddHandler nudBurnerHeight.ValueEditorClick, AddressOf nudBurnerHeight_ValueEditorClick
			//AddHandler nudSlit.ValueEditorClick, AddressOf nudSlit_ValueEditorClick
			//AddHandler nudFuelRatio.ValueEditorClick, AddressOf nudFuelRatio_ValueEditorClick
			//AddHandler nudBurnerHeight.ValueEditorValueChanged, AddressOf nudBurnerHeight_ValueChanged
			//AddHandler nudSlit.ValueEditorValueChanged, AddressOf nudSlit_ValueChanged
			//AddHandler nudFuelRatio.ValueEditorValueChanged, AddressOf nudFuelRatio_ValueChanged
			//mblnAvoidProcessing = False
			Application.DoEvents();
			mblnParameterProcessing = false;
			//Added by pankaj on 2 Dec 07
		}

	}

	private void nudSlit_Ref_ValueEditorClick()
	{
		//=====================================================================
		// Procedure Name        : nudSlit_Ref_ValueEditorClick
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : 
		// Description           : select index id for Calibration mode
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 21.11.06
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		double dblReturnValue;
		try {
			//nudSlit_Ref.Enabled = False
			//If mblnAvoidProcessing = True Then
			//    Exit Sub
			//End If
			//mblnAvoidProcessing = True

			nudSlit_Ref.ValueEditorClick -= nudSlit_Ref_ValueEditorClick;
			//RemoveHandler btnStart.Click, AddressOf btnStart_Click
			//RemoveHandler btnLampParameters.Click, AddressOf btnLampParameters_Click

			//RemoveHandler nudBurnerHeight.ValueEditorClick, AddressOf nudBurnerHeight_ValueEditorClick
			//RemoveHandler nudSlit.ValueEditorClick, AddressOf nudSlit_ValueEditorClick
			//RemoveHandler nudFuelRatio.ValueEditorClick, AddressOf nudFuelRatio_ValueEditorClick
			//RemoveHandler nudBurnerHeight.ValueEditorValueChanged, AddressOf nudBurnerHeight_ValueChanged
			//RemoveHandler nudSlit.ValueEditorValueChanged, AddressOf nudSlit_ValueChanged
			//RemoveHandler nudFuelRatio.ValueEditorValueChanged, AddressOf nudFuelRatio_ValueChanged
			Application.DoEvents();
			mblnParameterProcessing = true;
			//Added by pankaj on 2 Dec 07
			dblReturnValue = gobjClsAAS203.funcGet_SlitWidth(1);
			if (funcSetFrmEditValue(dblReturnValue, "Set Exit Slit Width (0.0 - 2.0)nm", nudSlit_Ref.MinValue, nudSlit_Ref.MaxValue) == true) {
				nudSlit_Ref.Value = dblReturnValue;
			} else {
				nudSlit_Ref.Value = gobjClsAAS203.funcGet_SlitWidth(1);
			}

		//
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			//mblnAvoidProcessing = False
			nudSlit_Ref.ValueEditorClick += nudSlit_Ref_ValueEditorClick;
			//AddHandler btnStart.Click, AddressOf btnStart_Click
			//AddHandler btnLampParameters.Click, AddressOf btnLampParameters_Click

			//AddHandler nudBurnerHeight.ValueEditorClick, AddressOf nudBurnerHeight_ValueEditorClick
			//AddHandler nudSlit.ValueEditorClick, AddressOf nudFuelRatio_ValueEditorClick
			//AddHandler nudFuelRatio.ValueEditorClick, AddressOf nudFuelRatio_ValueEditorClick
			//AddHandler nudBurnerHeight.ValueEditorValueChanged, AddressOf nudBurnerHeight_ValueChanged
			//AddHandler nudSlit.ValueEditorValueChanged, AddressOf nudSlit_ValueChanged
			//AddHandler nudFuelRatio.ValueEditorValueChanged, AddressOf nudFuelRatio_ValueChanged
			//nudSlit_Ref.Enabled = True
			if (!objWait == null) {
				objWait.Dispose();
			}
			nudSlit_Ref.Focus();
			Application.DoEvents();
			mblnParameterProcessing = false;
			//Added by pankaj on 2 Dec 07
		}
	}

	//Private Sub nudHCLCur_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
	//    nudHCLCur.Enabled = False
	//    mblnAvoidProcessing = True
	//    Call funcSetHCL_CurParameter(nudHCLCur.Value)
	//    mblnAvoidProcessing = False
	//    nudHCLCur.Enabled = True
	//End Sub

	private void nudHCLCur_ValueChanged(double ChangeHCLCur)
	{
		//=====================================================================
		// Procedure Name        : nudHCLCur_ValueChanged
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : 
		// Description           :  
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 21.11.06
		// Revisions             : 
		//=====================================================================
		try {
			//nudHCLCur.Enabled = False
			//If mblnAvoidProcessing = True Then
			//    Exit Sub
			//End If
			//mblnAvoidProcessing = True

			nudHCLCur.ValueEditorValueChanged -= nudHCLCur_ValueChanged;
			Application.DoEvents();
			if (ReInitLampInstParameters == true) {
				return;
			}
			mblnParameterProcessing = true;
			//Added by pankaj on 2 Dec 07
			funcSetHCL_CurParameter(nudHCLCur.Value);

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
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
			//mblnAvoidProcessing = False
			nudHCLCur.ValueEditorValueChanged += nudHCLCur_ValueChanged;
			//nudHCLCur.Enabled = True
			mblnParameterProcessing = false;
			//Added by pankaj on 2 Dec 07
			Application.DoEvents();
		}

	}

	private void nudHCLCur_ValueEditorClick()
	{
		//=====================================================================
		// Procedure Name        : nudHCLCur_ValueEditorClick
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : 
		// Description           : select index id for Calibration mode
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 21.11.06
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		double dblReturnValue;
		try {
			//nudHCLCur.Enabled = False
			//If mblnAvoidProcessing = True Then
			//    Exit Sub
			//End If
			//mblnAvoidProcessing = True

			nudHCLCur.ValueEditorClick -= nudHCLCur_ValueEditorClick;
			Application.DoEvents();
			if (ReInitLampInstParameters == true) {
				return;
			}
			mblnParameterProcessing = true;
			//Added by pankaj on 2 Dec 07
			dblReturnValue = gobjInst.Current;
			if (funcSetFrmEditValue(dblReturnValue, "Set HCL Current (0 - 25)mA", nudHCLCur.MinValue, nudHCLCur.MaxValue) == true) {
				nudHCLCur.Value = dblReturnValue;
			} else {
				nudHCLCur.Value = gobjInst.Current;
			}

		//
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			//mblnAvoidProcessing = False
			nudHCLCur.ValueEditorClick += nudHCLCur_ValueEditorClick;
			//nudHCLCur.Enabled = True
			if (!objWait == null) {
				objWait.Dispose();
			}
			nudHCLCur.Focus();
			Application.DoEvents();
			mblnParameterProcessing = false;
			//Added by pankaj on 2 Dec 07
		}
	}

	//Private Sub nudD2Cur_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
	//    nudHCLCur.Enabled = False
	//    mblnAvoidProcessing = True
	//    Call funcSetD2_CurParameter(nudD2Cur.Value)
	//    mblnAvoidProcessing = False
	//    nudHCLCur.Enabled = True
	//End Sub

	private void nudD2Cur_ValueChanged(double ChangeD2Cur)
	{
		//=====================================================================
		// Procedure Name        : nudD2Cur_ValueChanged
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : 
		// Description           :  
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 21.11.06
		// Revisions             : 
		//=====================================================================
		try {
			//nudD2Cur.Enabled = False
			//If mblnAvoidProcessing = True Then
			//    Exit Sub
			//End If
			//mblnAvoidProcessing = True
			if (ReInitLampInstParameters == true) {
				return;
			}
			mblnParameterProcessing = true;
			//Added by pankaj on 2 Dec 07
			funcSetD2_CurParameter(nudD2Cur.Value);
			if (nudD2Cur.Value == 100.0) {
				nudD2Cur.Text = "D2 Off";
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
			//mblnAvoidProcessing = False
			//nudD2Cur.Enabled = True
			mblnParameterProcessing = false;
			//Added by pankaj on 2 Dec 07
			//---------------------------------------------------------
		}

	}

	private void nudD2Cur_ValueEditorClick()
	{
		//=====================================================================
		// Procedure Name        : nudD2Cur_ValueEditorClick
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : 
		// Description           : select index id for Calibration mode
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 21.11.06
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		double dblReturnValue;
		try {
			//nudD2Cur.Enabled = False
			//If mblnAvoidProcessing = True Then
			//    Exit Sub
			//End If
			//mblnAvoidProcessing = True
			mblnParameterProcessing = true;
			//Added by pankaj on 2 Dec 07
			nudD2Cur.ValueEditorClick -= nudD2Cur_ValueEditorClick;
			Application.DoEvents();
			if (ReInitLampInstParameters == true) {
				return;
			}
			dblReturnValue = gobjInst.D2Current;
			if (funcSetFrmEditValue(dblReturnValue, "Set D2 Current (100 - 300)mA", nudD2Cur.MinValue, nudD2Cur.MaxValue) == true) {
				nudD2Cur.Value = dblReturnValue;
			} else {
				nudD2Cur.Value = gobjInst.D2Current;
			}

		//
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			//mblnAvoidProcessing = False
			nudD2Cur.ValueEditorClick += nudD2Cur_ValueEditorClick;
			//nudD2Cur.Enabled = True
			if (!objWait == null) {
				objWait.Dispose();
			}
			nudD2Cur.Focus();
			Application.DoEvents();
			mblnParameterProcessing = false;
			//Added by pankaj on 2 Dec 07
		}
	}

	//Private Sub nudFuelRatio_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
	//    Try
	//        nudHCLCur.Enabled = False
	//        mblnAvoidProcessing = True
	//        RemoveHandler nudFuelRatio.ValueChanged, AddressOf nudBurnerHeight_ValueChanged
	//        'If Not (CDbl(nudFuelRatio.Value) = mdblFuelRatio) Then
	//        '    Call gobjClsAAS203.funcSetFuel(CDbl(nudFuelRatio.Value))
	//        '    mdblFuelRatio = gobjClsAAS203.funcGet_Fuel_Ratio(True)
	//        'Else
	//        '    mdblFuelRatio = gobjClsAAS203.funcGet_Fuel_Ratio(True)
	//        'End If

	//        Call funcSetFuelParameter(CDbl(nudFuelRatio.Value))
	//        mobjParameters.FualRatio = Val(mdblFuelRatio)
	//        nudFuelRatio.Value = mdblFuelRatio
	//        nudFuelRatio.Refresh()
	//        AddHandler nudFuelRatio.ValueChanged, AddressOf nudBurnerHeight_ValueChanged

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
	//        mblnAvoidProcessing = False
	//        nudFuelRatio.Enabled = True
	//        '---------------------------------------------------------
	//    End Try
	//End Sub

	private void nudFuelRatio_ValueChanged(double ChangeFuelRatio)
	{
		//=====================================================================
		// Procedure Name        : nudFuelRatio_ValueChanged
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : 
		// Description           :  
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 21.11.06
		// Revisions             : 
		//=====================================================================
		try {
			nudFuelRatio.ValueEditorValueChanged -= nudFuelRatio_ValueChanged;

			gobjCommProtocol.mobjCommdll.subTime_Delay(50);
			Application.DoEvents();
			mblnParameterProcessing = true;
			//Added by pankaj on 2 Dec 07

			//'Call funcSetFuelParameter(CDbl(nudFuelRatio.Value))

			//'If mdblFuelRatio < 0.0 Then
			//'    nudFuelRatio.Value = 0.0
			//'    mobjParameters.FualRatio = 0.0
			//'    mdblFuelRatio = 0.0
			//'Else
			//'    nudFuelRatio.Value = mdblFuelRatio
			//'    mobjParameters.FualRatio = mdblFuelRatio
			//'End If

			//'nudFuelRatio.Refresh()

			//---above code is commented and called following 
			//---function to set fuel according to value editor 
			//---button clicked
			FuncIncrDecrFuel((double)nudFuelRatio.Value);

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			nudFuelRatio.ValueEditorValueChanged += nudFuelRatio_ValueChanged;
			mblnParameterProcessing = false;
			//Added by pankaj on 2 Dec 07
			//---------------------------------------------------------
		}
	}

	private void nudFuelRatio_ValueEditorClick()
	{
		//=====================================================================
		// Procedure Name        : nudFuelRatio_ValueEditorClick
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : 
		// Description           : select index id for Calibration mode
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 21.11.06
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		double dblReturnValue;
		try {
			//nudFuelRatio.Enabled = False
			//If mblnAvoidProcessing = True Then
			//    Exit Sub
			//End If
			//mblnAvoidProcessing = True

			nudFuelRatio.ValueEditorClick -= nudFuelRatio_ValueEditorClick;
			//RemoveHandler btnStart.Click, AddressOf btnStart_Click
			//RemoveHandler btnLampParameters.Click, AddressOf btnLampParameters_Click
			//RemoveHandler nudBurnerHeight.ValueEditorClick, AddressOf nudBurnerHeight_ValueEditorClick
			//RemoveHandler nudSlit.ValueEditorClick, AddressOf nudSlit_ValueEditorClick
			//RemoveHandler nudSlit_Ref.ValueEditorClick, AddressOf nudSlit_Ref_ValueEditorClick
			//RemoveHandler nudBurnerHeight.ValueEditorValueChanged, AddressOf nudBurnerHeight_ValueChanged
			//RemoveHandler nudSlit.ValueEditorValueChanged, AddressOf nudSlit_ValueChanged
			//RemoveHandler nudSlit_Ref.ValueEditorValueChanged, AddressOf nudSlit_Ref_ValueChanged

			Application.DoEvents();
			mblnParameterProcessing = true;
			//Added by pankaj on 2 Dec 07
			//dblReturnValue = gobjClsAAS203.funcGet_Fuel_Ratio(True)
			dblReturnValue = nudFuelRatio.Value;
			if (dblReturnValue < 0.0) {
				//'setting some validation
				//mobjParameters.FualRatio = 0.0
				dblReturnValue = 0.0;
			}
			//dblReturnValue = mdblFuelRatio
			//dblReturnValue = gobjClsAAS203.funcGet_Fuel_Ratio(True)
			if (funcSetFrmEditValue(dblReturnValue, "Set Fuel Ratio (0 - 7.66)", nudFuelRatio.MinValue, nudFuelRatio.MaxValue) == true) {
				nudFuelRatio.Value = dblReturnValue;
			} else {
				//nudFuelRatio.Value = gobjClsAAS203.funcGet_Fuel_Ratio(True)
			}

		//
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			nudFuelRatio.ValueEditorClick += nudFuelRatio_ValueEditorClick;
			//AddHandler btnStart.Click, AddressOf btnStart_Click
			//AddHandler btnLampParameters.Click, AddressOf btnLampParameters_Click

			//AddHandler nudBurnerHeight.ValueEditorClick, AddressOf nudBurnerHeight_ValueEditorClick
			//AddHandler nudSlit.ValueEditorClick, AddressOf nudSlit_ValueEditorClick
			//AddHandler nudSlit_Ref.ValueEditorClick, AddressOf nudSlit_Ref_ValueEditorClick
			//AddHandler nudBurnerHeight.ValueEditorValueChanged, AddressOf nudBurnerHeight_ValueChanged
			//AddHandler nudSlit.ValueEditorValueChanged, AddressOf nudSlit_ValueChanged
			//AddHandler nudSlit_Ref.ValueEditorValueChanged, AddressOf nudSlit_Ref_ValueChanged
			//nudFuelRatio.Enabled = True
			//mblnAvoidProcessing = False
			if (!objWait == null) {
				objWait.Dispose();
			}
			nudFuelRatio.Focus();
			Application.DoEvents();
			mblnParameterProcessing = false;
			//Added by pankaj on 2 Dec 07
		}
	}

	//Private Sub nudBurnerHeight_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
	//    Try
	//        nudHCLCur.Enabled = False
	//        mblnAvoidProcessing = True
	//        If Not (dblBhHeight = CDbl(nudBurnerHeight.Value)) Then
	//            'If dblBhHeight > nudBurnerHeight.Value Then
	//            '    dblBhHeight = funcSetBurner_HeightParameter(-1)
	//            '    dblBhHeight = Format(dblBhHeight, "#.00")
	//            '    nudBurnerHeight.Value = Format(dblBhHeight, "#.00")
	//            'ElseIf dblBhHeight < nudBurnerHeight.Value Then
	//            '    dblBhHeight = funcSetBurner_HeightParameter(1)
	//            '    dblBhHeight = Format(dblBhHeight, "#.00")
	//            '    nudBurnerHeight.Value = Format(dblBhHeight, "#.00")
	//            'End If
	//            nudBurnerHeight.Text = funcSetBurner_HeightParameter(CDbl(nudBurnerHeight.Value))
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
	//        mblnAvoidProcessing = False
	//        nudHCLCur.Enabled = True
	//        '---------------------------------------------------------
	//    End Try
	//End Sub

	private void nudBurnerHeight_ValueChanged(double ChangeBurnerHeight)
	{
		//=====================================================================
		// Procedure Name        :   nudBurnerHeight_ValueChanged
		// Description           :    
		// Purpose               :    
		//                           
		// Parameters Passed     :   None.
		// Returns               :    
		// Parameters Affected   :   None.
		// Assumptions           :
		// Dependencies          :
		// Author                :   Gitesh, Uday
		// Created               :   Saturday, November 15, 2003 18:49
		// Revisions             :
		//=====================================================================
		try {
			if (mblnAvoidProcessing == true) {
				return;
			}


			//nudBurnerHeight.Enabled = False
			//RemoveHandler nudBurnerHeight.ValueEditorValueChanged, AddressOf nudBurnerHeight_ValueChanged
			//RemoveHandler btnStart.Click, AddressOf btnStart_Click
			//RemoveHandler btnLampParameters.Click, AddressOf btnLampParameters_Click
			//RemoveHandler nudFuelRatio.ValueEditorClick, AddressOf nudFuelRatio_ValueEditorClick
			//RemoveHandler nudSlit.ValueEditorClick, AddressOf nudSlit_ValueEditorClick
			//RemoveHandler nudSlit_Ref.ValueEditorClick, AddressOf nudSlit_Ref_ValueEditorClick
			//RemoveHandler nudFuelRatio.ValueEditorValueChanged, AddressOf nudFuelRatio_ValueChanged
			//RemoveHandler nudSlit.ValueEditorValueChanged, AddressOf nudSlit_ValueChanged
			//RemoveHandler nudSlit_Ref.ValueEditorValueChanged, AddressOf nudSlit_Ref_ValueChanged

			mblnAvoidProcessing = true;
			mblnParameterProcessing = true;
			//Added by pankaj on 2 Dec 07
			if (!(dblBhHeight == (double)nudBurnerHeight.Value)) {
				//If dblBhHeight > nudBurnerHeight.Value Then
				//    dblBhHeight = funcSetBurner_HeightParameter(-1)
				//    dblBhHeight = Format(dblBhHeight, "#.00")
				//    nudBurnerHeight.Value = Format(dblBhHeight, "#.00")
				//ElseIf dblBhHeight < nudBurnerHeight.Value Then
				//    dblBhHeight = funcSetBurner_HeightParameter(1)
				//    dblBhHeight = Format(dblBhHeight, "#.00")
				//    nudBurnerHeight.Value = Format(dblBhHeight, "#.00")
				//End If
				nudBurnerHeight.Value = funcSetBurner_HeightParameter((double)nudBurnerHeight.Value);
			}

		//AddHandler nudBurnerHeight.ValueEditorValueChanged, AddressOf nudBurnerHeight_ValueChanged
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			mblnAvoidProcessing = false;
			mblnParameterProcessing = false;
			//Added by pankaj on 2 Dec 07
			//AddHandler btnStart.Click, AddressOf btnStart_Click
			//AddHandler btnLampParameters.Click, AddressOf btnLampParameters_Click
			//AddHandler nudFuelRatio.ValueEditorClick, AddressOf nudFuelRatio_ValueEditorClick
			//AddHandler nudSlit.ValueEditorClick, AddressOf nudSlit_ValueEditorClick
			//AddHandler nudSlit_Ref.ValueEditorClick, AddressOf nudSlit_Ref_ValueEditorClick
			//AddHandler nudFuelRatio.ValueEditorValueChanged, AddressOf nudFuelRatio_ValueChanged
			//AddHandler nudSlit.ValueEditorValueChanged, AddressOf nudSlit_ValueChanged
			//AddHandler nudSlit_Ref.ValueEditorValueChanged, AddressOf nudSlit_Ref_ValueChanged
			//nudBurnerHeight.Enabled = True
			//---------------------------------------------------------
		}
	}

	private void nudBurnerHeight_ValueEditorClick()
	{
		//=====================================================================
		// Procedure Name        : cmbModes_SelectedIndexChanged
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : 
		// Description           : select index id for Calibration mode
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 21.11.06
		// Revisions             : 
		//=====================================================================
		//Dim objWait As New CWaitCursor
		double dblReturnValue;
		try {
			if (mblnAvoidProcessing == true) {
				return;
			}
			//nudBurnerHeight.Enabled = False
			mblnAvoidProcessing = true;
			mblnParameterProcessing = true;
			//Added by pankaj on 2 Dec 07
			//DisableButtonsForBurnerHeight() 'Saurabh 21.07.07

			//RemoveHandler nudBurnerHeight.ValueEditorClick, AddressOf nudBurnerHeight_ValueEditorClick
			//RemoveHandler btnStart.Click, AddressOf btnStart_Click
			//RemoveHandler btnLampParameters.Click, AddressOf btnLampParameters_Click

			//RemoveHandler nudFuelRatio.ValueEditorClick, AddressOf nudFuelRatio_ValueEditorClick
			//RemoveHandler nudSlit.ValueEditorClick, AddressOf nudSlit_ValueEditorClick
			//RemoveHandler nudSlit_Ref.ValueEditorClick, AddressOf nudSlit_Ref_ValueEditorClick
			//RemoveHandler nudFuelRatio.ValueEditorValueChanged, AddressOf nudFuelRatio_ValueChanged
			//RemoveHandler nudSlit.ValueEditorValueChanged, AddressOf nudSlit_ValueChanged
			//RemoveHandler nudSlit_Ref.ValueEditorValueChanged, AddressOf nudSlit_Ref_ValueChanged

			//RemoveHandler nudBurnerHeight.VisibleChanged, AddressOf nudBurnerHeight_ValueChanged
			Application.DoEvents();

			dblReturnValue = Format(gobjClsAAS203.funcReadBurnerHeight(), "0.00");
			if (funcSetFrmEditValue(dblReturnValue, "Set Burner Height (0.0 - 6.0)nm", nudBurnerHeight.MinValue, nudBurnerHeight.MaxValue) == true) {
				//nudBurnerHeight.Value = dblReturnValue     Commented By Saurabh
				nudBurnerHeight.Value = funcSetBurner_HeightParameter((double)dblReturnValue);
				//Added by Saurabh
			}

		//AddHandler nudBurnerHeight.ValueEditorClick, AddressOf nudBurnerHeight_ValueEditorClick
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}

			//nudBurnerHeight.Enabled = True
			//If Not objWait Is Nothing Then
			//    objWait.Dispose()
			//End If
			//EnableButtonsForBurnerHeight() 'Saurabh 21.07.07
			//AddHandler btnStart.Click, AddressOf btnStart_Click
			//AddHandler btnLampParameters.Click, AddressOf btnLampParameters_Click
			//AddHandler nudFuelRatio.ValueEditorClick, AddressOf nudFuelRatio_ValueEditorClick
			//AddHandler nudSlit.ValueEditorClick, AddressOf nudSlit_ValueEditorClick
			//AddHandler nudSlit_Ref.ValueEditorClick, AddressOf nudSlit_Ref_ValueEditorClick
			//AddHandler nudFuelRatio.ValueEditorValueChanged, AddressOf nudFuelRatio_ValueChanged
			//AddHandler nudSlit.ValueEditorValueChanged, AddressOf nudSlit_ValueChanged
			//AddHandler nudSlit_Ref.ValueEditorValueChanged, AddressOf nudSlit_Ref_ValueChanged
			mblnAvoidProcessing = false;
			mblnParameterProcessing = false;
			//Added by pankaj on 2 Dec 07
			nudBurnerHeight.Focus();
			Application.DoEvents();
		}
	}


	private void cmbModes_SelectedIndexChanged(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : cmbModes_SelectedIndexChanged
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : 
		// Description           : select index id for Calibration mode
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 21.11.06
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		int intSelectedModeType;
		try {
			if (mblnAvoidProcessing == true) {
				return;
			}
			mblnAvoidProcessing = true;
			//nudHCLCur.Enabled = False
			cmbModes.SelectedIndexChanged -= cmbModes_SelectedIndexChanged;
			if (cmbModes.SelectedIndex > -1) {
				//gobjInst.Mode = cmbModes.SelectedIndex
				////----- Use for Double Beam. It has not use other mode
				if (gintInstrumentBeamType == AAS203Library.Instrument.enumInstrumentBeamType.DoubleBeam) {
					////----- Commented by Sachin Dokhale on change of 2nd time requirement for DB for 
					//Select Case cmbModes.SelectedIndex
					//    Case 0
					//        intSelectedModeType = EnumCalibrationMode.AA
					//    Case 1
					//        intSelectedModeType = EnumCalibrationMode.HCLE
					//    Case 2
					//        intSelectedModeType = EnumCalibrationMode.AABGC
					//End Select
					//Call funcSetSpectrumParameter(intSelectedModeType)
					////------
					funcSetSpectrumParameter(cmbModes.SelectedIndex);
				} else {
					funcSetSpectrumParameter(cmbModes.SelectedIndex);
				}

			}
			cmbModes.SelectedIndexChanged += cmbModes_SelectedIndexChanged;
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
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
			mblnAvoidProcessing = false;

			//nudHCLCur.Enabled = True
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
	//    Dim blnIsFlameStatusCheck As Boolean = False

	//    Try
	//        RemoveHandler mnuIgnite.Click, AddressOf btnAutoIgnition_Click
	//        If mblnAvoidProcessing = True Then
	//            Exit Sub
	//        End If
	//        mblnAvoidProcessing = True

	//        'If Not IsNothing(mobjfrmAnalysis) Then mobjfrmAnalysis.tmrAspirationMsg.Enabled = False
	//        gobjMain.mobjController.Cancel()
	//        Application.DoEvents()
	//        blnIsFlameStatusCheck = True
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
	//        mblnAvoidProcessing = False
	//        If blnIsFlameStatusCheck = True Then
	//            gobjMain.mobjController.Start(gobjclsBgFlameStatus)
	//        End If
	//        AddHandler mnuIgnite.Click, AddressOf btnAutoIgnition_Click
	//        Application.DoEvents()
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
	//    Dim blnIsFlameStatusCheck As Boolean = False
	//    Try
	//        RemoveHandler mnuExtinguish.Click, AddressOf btnExtinguish_Click
	//        If mblnAvoidProcessing = True Then
	//            Exit Sub
	//        End If
	//        mblnAvoidProcessing = True

	//        gobjMain.mobjController.Cancel()
	//        blnIsFlameStatusCheck = True
	//        Application.DoEvents()

	//        Call gobjClsAAS203.funcIgnite(False)
	//        mblnAvoidProcessing = False
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
	//        If blnIsFlameStatusCheck = True Then
	//            gobjMain.mobjController.Start(gobjclsBgFlameStatus)
	//        End If
	//        Application.DoEvents()
	//        AddHandler mnuExtinguish.Click, AddressOf btnExtinguish_Click
	//        '---------------------------------------------------------
	//    End Try
	//End Sub

	#End Region

	#End Region

	#Region " Private functions"

	private object funcInitialise()
	{
		//=====================================================================
		// Procedure Name        : funcInitialise
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : 
		// Description           : Initialise the form Object
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 21.11.06
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		int intSelectedModeType;

		try {
			//gobjMain.mobjController.Cancel()       Commented By Saurabh
			//Application.DoEvents()

			nudBurnerHeight.IsReverseOperation = true;
			nudBurnerHeight.IsUpDownButtonToBeDisabledOnValueChange = true;
			nudFuelRatio.IsUpDownButtonToBeDisabledOnValueChange = true;
			TimerEnergyDisplay.Enabled = false;
			gblnUVS = false;
			IsRefBeamSelected = false;
			if (gintInstrumentBeamType == AAS203Library.Instrument.enumInstrumentBeamType.DoubleBeam) {
				grpBeamType.Visible = true;
			} else {
				grpBeamType.Visible = false;
			}
			////----- Added by Sachin Dokhale on 14.07.07
			if (!gstructSettings.ExeToRun == EnumApplicationMode.ServiceUtility) {
				if (!IsNothing(gobjMain)) {
					if (gobjMain.mobjController.IsThreadRunning == true) {
						gobjMain.mobjController.Cancel();
						gobjCommProtocol.mobjCommdll.subTime_Delay(100);
						//10.12.07
						Application.DoEvents();
					}
				}
				gobjfrmStatus.Visible = true;
				Application.DoEvents();
			}

			if (gobjInst.Mode > -1) {
				////----- Added by Sachin Dokhale. Get the init. calibration mode.
				m_bytCalibMode = gobjInst.Mode;
				////-----
				cmbModes.SelectedIndex = gobjInst.Mode;
			}
			nudPMT.Visible = true;
			if (!(gintInstrumentBeamType == AAS203Library.Instrument.enumInstrumentBeamType.SingleBeam)) {
				nudPMT_Ref.Visible = true;
				nudPMT_Ref.Enabled = true;
			} else {
				nudPMT_Ref.Visible = true;
				nudPMT_Ref.Enabled = false;
			}

			nudBurnerHeight.Visible = true;
			nudD2Cur.Visible = true;
			nudFuelRatio.Visible = true;
			nudHCLCur.Visible = true;
			nudSlit.Visible = true;
			nudSlit_Ref.Visible = true;
			cmbSpeed.Visible = true;
			cmbModes.Visible = true;
			Application.DoEvents();
			////----- Set the HCLE as default mode for Energy Spectrum
			funcSetDefaultSpectrumParameter(EnumCalibrationMode.HCLE);
			funcSetDefaultParameter();
			AddHandlers();
			gblnSpectrumTerminated = false;
			gblnSpectrumWait = false;
			//TimerEnergyDisplay.Enabled = True
			func_Enable_Disable(EnumProcesses.FormInitialize, EnumStart_End.Start_of_Process);
			this.Refresh();
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
		// Created               : 15.11.06
		// Revisions             : 
		//=====================================================================
		try {
			mnuLoadSpectrunFile.Click += mnuLoadSpectrumFile_Click;
			mnuSaveSpectrumFile.Click += mnuSaveSpectrumFile_Click;
			cmbModes.SelectedIndexChanged += cmbModes_SelectedIndexChanged;
			mnuExit.Click += mnuExit_Click;
			btnReturn.Click += mnuExit_Click;
			mnuPeakPick.Click += mnuPeakPick_Click;
			btnStart.Click += btnStart_Click;
			btnLampParameters.Click += btnLampParameters_Click;
			btnClearSpectrum.Click += btnClearSpectrum_Click;
			//Added By Pankaj on 22 May 07
			mnuStart.Click += btnStart_Click;
			mnuClearSpectrum.Click += btnClearSpectrum_Click;
			mnuLampParameters.Click += btnLampParameters_Click;
			mnuChangeScale.Click += cmdChangeScale_Click;
			mnuOverlay.Click += cmdOverlay_Click;
			//By Pankaj on 30 Nov 07
			//----

			//AddHandler nudFuelRatio.ValueChanged, AddressOf nudFuelRatio_ValueChanged
			nudFuelRatio.ValueEditorClick += nudFuelRatio_ValueEditorClick;
			nudFuelRatio.ValueEditorValueChanged += nudFuelRatio_ValueChanged;

			//AddHandler nudBurnerHeight.ValueChanged, AddressOf nudBurnerHeight_ValueChanged
			nudBurnerHeight.ValueEditorClick += nudBurnerHeight_ValueEditorClick;
			nudBurnerHeight.ValueEditorValueChanged += nudBurnerHeight_ValueChanged;

			//AddHandler nudD2Cur.ValueChanged, AddressOf nudD2Cur_ValueChanged
			nudD2Cur.ValueEditorClick += nudD2Cur_ValueEditorClick;
			nudD2Cur.ValueEditorValueChanged += nudD2Cur_ValueChanged;

			//AddHandler nudHCLCur.ValueChanged, AddressOf nudHCLCur_ValueChanged
			nudHCLCur.ValueEditorClick += nudHCLCur_ValueEditorClick;
			nudHCLCur.ValueEditorValueChanged += nudHCLCur_ValueChanged;

			//AddHandler nudSlit.ValueChanged, AddressOf nudSlit_ValueChanged
			nudSlit.ValueEditorClick += nudSlit_ValueEditorClick;
			nudSlit.ValueEditorValueChanged += nudSlit_ValueChanged;

			nudSlit_Ref.ValueEditorClick += nudSlit_Ref_ValueEditorClick;
			nudSlit_Ref.ValueEditorValueChanged += nudSlit_Ref_ValueChanged;

			//AddHandler nudPMT.ValueChanged, AddressOf nudPMT_ValueChanged
			nudPMT.ValueEditorClick += nudPMT_ValueEditorClick;
			nudPMT.ValueEditorValueChanged += nudPMT_ValueChanged;

			nudPMT_Ref.ValueEditorClick += nudPMT_Ref_ValueEditorClick;
			nudPMT_Ref.ValueEditorValueChanged += nudPMT_Ref_ValueChanged;

			cmbSpeed.SelectedIndexChanged += cmbSpeed_SelectedIndexChanged;
			cmdChangeScale.Click += cmdChangeScale_Click;
			//AddHandler btnLampParameters.Click, AddressOf btnLampParameters_Click
			mnuContiniousTimeScan.Click += mnuContiniousTimeScan_Click;
			mnuSmooth.Click += mnuSmoothGraph_Click;
			mnuPositionToMaxima.Click += mnuPositionToMaxima_Click;
			mnuParameters.Click += mnuParameters_Click;
			AASEnergySpectrum.GraphScaleChanged += AASEnergySpectrum_GraphScaleChanged;

			tlbbtnReturn.Click += mnuExit_Click;
			tlbbtnStart.Click += btnStart_Click;
			tlbbtnLampParameters.Click += btnLampParameters_Click;
			tlbbtnClearSpectrum.Click += btnClearSpectrum_Click;
			tlbbtnChangeScale.Click += cmdChangeScale_Click;
			tlbbtnLoadspectrumFile.Click += mnuLoadSpectrumFile_Click;
			tlbbtnSaveSpectrumFile.Click += mnuSaveSpectrumFile_Click;
			tlbbtnSmooth.Click += mnuSmoothGraph_Click;
			tlbbtnPositionToMaxima.Click += mnuPositionToMaxima_Click;
			tlbbtnContiniousTimeScan.Click += mnuContiniousTimeScan_Click;
			tlbbtnParameters.Click += mnuParameters_Click;
			tlbbtnPrintGraph.Click += tlbbtnPrintGraph_Click;
			tlbbtnPeakPick.Click += mnuPeakPick_Click;
			mnuPrintGraph.Click += tlbbtnPrintGraph_Click;

			//Menu for Graph Options
			mnuPeakEdit.Click += mnuPeakEdit_Click;
			mnuGrid.Click += mnuGrid_Click;
			mnuShowXYValues.Click += mnuShowXYValues_Click;
			mnuLegends.Click += mnuLegends_Click;

			//Tlbbtn for Graph Options
			tlbbtnPeakEdit.Click += mnuPeakEdit_Click;
			tlbbtnGrid.Click += mnuGrid_Click;
			tlbbtnShowXYValues.Click += mnuShowXYValues_Click;
			tlbbtnLegends.Click += mnuLegends_Click;

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

	private void subStartScan()
	{
		//=====================================================================
		// Procedure Name        : subStartScan
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 07.10.06
		// Revisions             : 
		//=====================================================================
		//Dim objWait As New CWaitCursor

		try {
			if (mblnAvoidProcessing == true) {
				return;
			}
			func_Enable_Disable(EnumProcesses.StartScan, EnumStart_End.Start_of_Process);
			funcGetInstParameter();
			func_Enable_DisableControl(false);
			//by Pankaj on 30 Nov 07
			if (mnuOverlay.Checked == false) {
				subClearGraph();
			}
			//Display graph
			if (mobjChannnels.Count > 0) {
				if (!(mobjChannnels(mintChannelIndex) == null)) {
					funcDisplayGraph(mobjChannnels(mintChannelIndex));
				}
			}
			//Added by pankaj on 21 Jan 08
			if (gstructSettings.AppMode == EnumAppMode.FullVersion_203D) {
				if (IsRefBeamSelected == false) {
					nudPMT_Ref.Value = 0;
					this.Refresh();
					Application.DoEvents();
				}

			}
			//---for setting ref. pmt to zero

			//---16.03.08
			if (gblnIsDemoWithRealData == true) {
				mobjParameters.YaxisMin = 0;
				mobjParameters.YaxisMax = 100;
				switch (gobjInst.Lamp_Position) {
					case 1:
						mobjParameters.XaxisMin = 210;
						mobjParameters.XaxisMax = 220;
					case 2:
						mobjParameters.XaxisMin = 320;
						mobjParameters.XaxisMax = 330;
					case 3:
						mobjParameters.XaxisMin = 210;
						mobjParameters.XaxisMax = 220;
					case 4:
						mobjParameters.XaxisMin = 190;
						mobjParameters.XaxisMax = 200;
					case 5:
						mobjParameters.XaxisMin = 246;
						mobjParameters.XaxisMax = 254;
					case 6:
						mobjParameters.XaxisMin = 276;
						mobjParameters.XaxisMax = 284;
				}
				WvStartRange = mobjParameters.XaxisMin;
				WvLastRange = mobjParameters.XaxisMax;
			}

			if (funcOnSpect(false, lblWvPos, lblYValue) == false) {
				func_Enable_Disable(EnumProcesses.StartScan, EnumStart_End.End_of_Process);
				func_Enable_DisableControl(true);
				return;
			}

			btnStart.Text = "&Stop";
			btnStart.Image = Image.FromFile(Application.StartupPath + "\\Images\\cancel_1.ico");
			btnStart.Enabled = true;
			btnStart.Refresh();
		//AASEnergySpectrum

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
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

	private void subStopScan()
	{
		//=====================================================================
		// Procedure Name        : subStartScan
		// Parameters Passed     : 
		// Returns               : None
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 07.10.06
		// Revisions             : 
		//=====================================================================
		//Dim objWait As New CWaitCursor

		try {
			//gblnSpectrumTerminated = True
			// Set interupte for Termination of the thread
			if (!mobjclsBgSpectrum == null) {
				mobjclsBgSpectrum.ThTerminate = true;
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
			//If Not objWait Is Nothing Then
			//    objWait.Dispose()
			//End If
			//---------------------------------------------------------
		}


	}

	private void subClearScan()
	{
		//=====================================================================
		// Procedure Name        : subClearScan
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 07.10.06
		// Revisions             : 
		//=====================================================================
		//Dim objWait As New CWaitCursor

		try {
			if (mblnAvoidProcessing == true) {
				return;
			}
			mblnAvoidProcessing = true;
			//intChannel_no = funcAddChannelToCollection(mobjOnlineChannel)

			if (mintChannelIndex > -1) {
				if (mobjChannnels.Count > 0) {
					if (blnYetFileNotSave == true) {
						if (gobjMessageAdapter.ShowMessage(constFileNotSaved) == true) {
							if (gintInstrumentBeamType == AAS203Library.Instrument.enumInstrumentBeamType.DoubleBeam) {
								funcSaveSpectrumFile_Double();
							} else {
								funcSaveSpectrumFile();
							}
						}
					}
					//mobjChannnels.RemoveAt(mintChannelIndex)
					mintChannelIndex = -1;

					mobjChannnels.Clear();
					if (ArrlstGraphCurveItem.Count >= intCurveIndex + 1) {
						//ArrlstGraphCurveItem.RemoveAt(intCurveIndex)
						ArrlstGraphCurveItem.Clear();
						intCurveIndex = -1;
					}
				}
			}
			blnYetFileNotSave = false;
			funcClearGraph();
			func_Enable_Disable(EnumProcesses.EditSystemParamters, EnumStart_End.Start_of_Process);


		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
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
			mblnAvoidProcessing = false;
			//---------------------------------------------------------
		}
	}

	private void subClearGraph()
	{
		//=====================================================================
		// Procedure Name        : subClearScan
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Pankaj
		// Created               : 30.11.07
		// Revisions             : 
		//=====================================================================
		//Dim objWait As New CWaitCursor

		try {
			if (mblnAvoidProcessing == true) {
				//Exit Sub
			}
			//mblnAvoidProcessing = True
			//intChannel_no = funcAddChannelToCollection(mobjOnlineChannel)


			if (mintChannelIndex > -1) {
				if (mobjChannnels.Count > 0) {
					if (blnYetFileNotSave == true) {
						if (gobjMessageAdapter.ShowMessage(constFileNotSaved) == true) {
							if (gintInstrumentBeamType == AAS203Library.Instrument.enumInstrumentBeamType.DoubleBeam) {
								funcSaveSpectrumFile_Double();
							} else {
								funcSaveSpectrumFile();
							}
						}
					}
					mobjChannnels.RemoveAt(mintChannelIndex);
					mintChannelIndex = -1;

					mobjChannnels.Clear();
					if (ArrlstGraphCurveItem.Count >= intCurveIndex + 1) {
						//ArrlstGraphCurveItem.RemoveAt(intCurveIndex)
						ArrlstGraphCurveItem.Clear();
						intCurveIndex = -1;
					}
				}
			}
			//blnYetFileNotSave = False
			funcClearGraph();
		//Call func_Enable_Disable(EnumProcesses.EditSystemParamters, EnumStart_End.Start_of_Process)


		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
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
			mblnAvoidProcessing = false;
			//---------------------------------------------------------
		}
	}

	private void subSmoothGraph()
	{
		//=====================================================================
		// Procedure Name        : subSmoothGraph
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 16.10.06
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		if (mblnAvoidProcessing == true) {
			return;
		}
		try {
			Channel objchanel0;
			//Dim objchanel_Ref As Channel
			Channel objchanel_Sample;

			mblnAvoidProcessing = true;
			if (mintChannelIndex > -1) {
				//If Not gintInstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.DoubleBeam Then
				//    objchanel0 = mobjSpectrum.funcCloneESChannel(mobjChannnels(mintChannelIndex))
				//    If Not (objchanel0) Is Nothing Then
				//        mobjSpectrum.funcSmooth1(objchanel0, 0)
				//        mobjChannnels(mintChannelIndex) = mobjSpectrum.funcCloneESChannel(objchanel0)
				//        funcClearGraph()

				//        If funcDisplayGraph(mobjChannnels.item(mintChannelIndex)) = True Then
				//            ArrlstGraphCurveItem.Add(mGraphCurveItem)
				//            intCurveIndex += 1
				//        End If
				//        funcGraphPreRequisite(mobjParameters.Cal_Mode, _
				//                                                    mobjParameters.XaxisMin, _
				//                                                    mobjParameters.XaxisMax, _
				//                                                    mobjParameters.YaxisMin, _
				//                                                    mobjParameters.YaxisMax)
				//    End If
				//Else
				////----- Smoothing for Double beam, two channel.

				//objchanel_Ref = mobjSpectrum.funcCloneESChannel(mobjEnegyChannel(mintChannelIndex - 1))

				//objchanel_Sample = mobjSpectrum.funcCloneESChannel(mobjEnegyChannel(mintChannelIndex - 1))
				objchanel_Sample = mobjSpectrum.funcCloneESChannel(mobjChannnels(mintChannelIndex));

				funcClearGraph();
				//If Not (objchanel_Ref) Is Nothing Then
				//    mobjSpectrum.funcSmooth1(objchanel_Ref, 0)
				//    'mobjChannnels(mintChannelIndex - 1) = mobjSpectrum.funcCloneESChannel(objchanel_Ref)
				//    mobjChannnels(mintChannelIndex) = (objchanel_Ref)

				//    'ArrlstGraphCurveItem(intCurveIndex) = mGraphCurveItem

				//    If funcDisplayGraphOffline(mobjChannnels.item(mintChannelIndex), mGraphCurveItem) = True Then
				//        ArrlstGraphCurveItem.Add(mGraphCurveItem)
				//        intCurveIndex += 1
				//    End If
				//    'ArrlstGraphCurveItem(intCurveIndex - 1) = mGraphCurveItem
				//    funcGraphPreRequisite(mobjParameters.Cal_Mode, _
				//                                                mobjParameters.XaxisMin, _
				//                                                mobjParameters.XaxisMax, _
				//                                                mobjParameters.YaxisMin, _
				//                                                mobjParameters.YaxisMax)
				//End If
				if (!(objchanel_Sample) == null) {
					mobjSpectrum.funcSmooth1(objchanel_Sample, 0);
					//mobjChannnels(mintChannelIndex) = mobjSpectrum.funcCloneESChannel(objchanel_Sample)
					mobjChannnels(mintChannelIndex) = objchanel_Sample;
					//funcClearGraph()
					//funcDisplayGraph(mobjChannnels.item(mintChannelIndex))
					//funcDisplayGraph(mobjChannnels.item(mintChannelIndex))
					if (funcDisplayGraphOffline(mobjChannnels.item(mintChannelIndex), mGraphCurveItem) == true) {
						ArrlstGraphCurveItem.Add(mGraphCurveItem);
						intCurveIndex += 1;
					}
					//ArrlstGraphCurveItem(intCurveIndex) = mGraphCurveItem

					funcGraphPreRequisite(mobjParameters.Cal_Mode, mobjParameters.XaxisMin, mobjParameters.XaxisMax, mobjParameters.YaxisMin, mobjParameters.YaxisMax);

				}
				AASEnergySpectrum.Refresh();
				Application.DoEvents();
				//End If
			}
		//Call func_Enable_Disable(EnumProcesses.StartScan, EnumStart_End.Start_of_Process)


		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			mblnAvoidProcessing = false;
			if (!objWait == null) {
				objWait.Dispose();
			}

			//---------------------------------------------------------
		}
	}

	private void subPeakValley()
	{
		//=====================================================================
		// Procedure Name        : subPeakValley
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 14.12.06
		// Revisions             : 
		//=====================================================================
		//Dim objWait As New CWaitCursor
		DataTable objDataTable = new DataTable();
		DataTable objDataTable_Ref = new DataTable();
		Channel objPeakVallyChannel;
		int intCounter = 0;
		long lngPeakValleyCounts;
		long lngPeakValleyCounts_Ref;
		int intShowdialog;
		clsDataFileReport objclsDataFileReport = new clsDataFileReport();
		if (mblnAvoidProcessing == true) {
			return;
		}


		try {

			mblnAvoidProcessing = true;

			if (mintChannelIndex > -1) {
				////----- Searching for Ref Peak.

				//If gintInstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.DoubleBeam Then
				//    If Not (mobjEnegyChannel(0) Is Nothing) Then
				//        If mobjSpectrum.funcPeaks(mobjEnegyChannel(0), mStuctPeaksValley) = False Then
				//            gobjMessageAdapter.ShowMessage(constErrorPopulatingPeakValleyData)
				//            'MsgBox("Error in Peak Valley Methods", MsgBoxStyle.Critical)
				//        End If
				//    Else
				//        Exit Sub
				//    End If
				//    '--- Check for Peak-Valley points
				//    lngPeakValleyCounts_Ref = mobjSpectrum.PeakValleyCount
				//    If lngPeakValleyCounts_Ref > 0 Then

				//        'Exit Sub
				//        '/----- Ini for Energy Spectrum

				//        objPeakVallyChannel = mobjEnegyChannel(0) 'mobjChannnels.item(mintChannelIndex)

				//        If Not mobjSpectrum.funcGetDataPeakPickResults(objDataTable_Ref, mStuctPeaksValley, lngPeakValleyCounts_Ref, objPeakVallyChannel) Then
				//            gobjMessageAdapter.ShowMessage(constErrorPopulatingPeakValleyData)
				//            'gFuncShowMessage("Error...", "Error in populating the peak valley data in the data table to display on the screen.", EnumMessageType.Information)
				//        End If
				//    Else
				//        gobjMessageAdapter.ShowMessage(constNOPeakORValley)
				//    End If
				//    objPeakVallyChannel = Nothing
				//    intCounter = 0
				//    lngPeakValleyCounts = 0
				//End If
				////----- End of searching peak

				if (!(mobjChannnels.item(mintChannelIndex) == null)) {
					if (mobjSpectrum.funcPeaks(mobjChannnels.item(mintChannelIndex), mStuctPeaksValley) == false) {
						gobjMessageAdapter.ShowMessage(constErrorPopulatingPeakValleyData);
						//MsgBox("Error in Peak Valley Methods", MsgBoxStyle.Critical)
					}
				} else {
					return;
				}
				//--- Check for Peak-Valley points
				lngPeakValleyCounts = mobjSpectrum.PeakValleyCount;

				if (lngPeakValleyCounts > 0) {
					//gFuncShowMessage("Peak Pick", "No Peaks Or Valleys detected.", EnumMessageType.Information)
					//Exit Sub

					///----- Ini for Energy Spectrum
					objPeakVallyChannel = mobjChannnels.item(mintChannelIndex);

					if (!mobjSpectrum.funcGetDataPeakPickResults(objDataTable, mStuctPeaksValley, lngPeakValleyCounts, objPeakVallyChannel)) {
						gobjMessageAdapter.ShowMessage(constErrorPopulatingPeakValleyData);
						//gFuncShowMessage("Error...", "Error in populating the peak valley data in the data table to display on the screen.", EnumMessageType.Information)
					}
				} else {
					gobjMessageAdapter.ShowMessage(constNOPeakORValley);
				}
				//If lngPeakValleyCounts > 0 And lngPeakValleyCounts_Ref > 0 Then
				if (lngPeakValleyCounts > 0) {
					frmPeakPicks frmPeakPick = new frmPeakPicks();
					if (!objDataTable == null) {
						frmPeakPick.funcDisplayPicPeakResults(objDataTable);
					}

					//If Not objDataTable_Ref Is Nothing Then
					//    Call frmPeakPick.funcDisplayPicPeakResults_Ref(objDataTable_Ref)
					//End If

					intShowdialog = frmPeakPick.ShowDialog();
					if (intShowdialog == DialogResult.Yes) {
						objclsDataFileReport.DefaultFont = this.DefaultFont();
						objclsDataFileReport.funcPeakValleyPrintEnergy(AASEnergySpectrum, objDataTable, mobjParameters, "");
					}
					//Call func_Enable_Disable(EnumProcesses.StartScan, EnumStart_End.Start_of_Process)

					////----------
					//Dim intShowdialog As Integer
					//Dim objPrintDialog As New PrintDialog
					//intShowdialog = frmPeakPick.ShowDialog
					//If intShowdialog = DialogResult.Yes Then
					//    objPrintDialog.Document = PrintDocument1
					//    objPrintDialog.PrinterSettings = PrintDocument1.PrinterSettings
					//    objPrintDialog.AllowSomePages = True
					//    Dim result As DialogResult = objPrintDialog.ShowDialog()

					//    If (result = DialogResult.OK) Then
					//        AxSpectrumGraph.PrinterName = objPrintDialog.PrinterSettings.PrinterName
					//        Call subPrintSpectrumPeakPick(objDataTable, objChannel)
					//    End If
					//ElseIf intShowdialog = DialogResult.OK Then
					//    objPrintDialog.Document = PrintDocument1
					//    objPrintDialog.PrinterSettings = PrintDocument1.PrinterSettings
					//    objPrintDialog.AllowSomePages = True
					//    Dim result As DialogResult = objPrintDialog.ShowDialog()

					//    If (result = DialogResult.OK) Then
					//        AxSpectrumGraph.PrinterName = objPrintDialog.PrinterSettings.PrinterName
					//        Call subPrintSpectrumPeakPick_WithOutGraph(objDataTable, objChannel)
					//    End If
					//End If
					////---------



					frmPeakPick.Close();
					frmPeakPick.Dispose();
				}
			}
			objPeakVallyChannel = null;
			objDataTable = null;
		//Call subClearScan()

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			mblnAvoidProcessing = false;
			//If Not objWait Is Nothing Then
			//    objWait.Dispose()
			//End If
			//---------------------------------------------------------
		}
	}

	private void subLampParameterChanged()
	{
		//=====================================================================
		// Procedure Name        : subLampParameterChanged
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 07.12.06
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		frmChangeLampParameters objfrmChangeLampPara = new frmChangeLampParameters();
		try {
			if (mblnAvoidProcessing == true) {
				return;
			}
			mblnAvoidProcessing = true;

			if (objfrmChangeLampPara.ShowDialog() == DialogResult.OK) {
				TimerEnergyDisplay.Enabled = false;
				nudHCLCur.Value = gobjInst.Current;
			}
			mobjParameters.LampEle = gobjInst.Lamp.LampParametersCollection(gobjInst.Lamp_Position - 1).ElementName;
			mobjParameters.LampTurrNo = gobjInst.Lamp_Position;
			TimerEnergyDisplay.Enabled = true;
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			objfrmChangeLampPara.Dispose();
			if (!objWait == null) {
				objWait.Dispose();
			}
			mblnAvoidProcessing = false;
			//---------------------------------------------------------
		}
	}

	private bool funcSetParameter()
	{
		//=====================================================================
		// Procedure Name        : funcSetParameter
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : 
		// Description           : Set Spectrum Parameter
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 21.11.06
		// Revisions             : 
		//=====================================================================
		int intMaxD2Current;
		int intMinD2Current;
		int intSelectedModeType;
		try {
			funcSetParameter = false;


			////----- Set the default parameter to the spectrum.
			///----- Set the Form object parameter
			////----- Set PMT Object




			if (mobjChannnels(mintChannelIndex).ChannelNo > -1) {

				//nudPMT.Value = gobjInst.PmtVoltage

				nudPMT.Value = mobjChannnels(mintChannelIndex).EnegryParameter.PMTV();
				if (!(gintInstrumentBeamType == AAS203Library.Instrument.enumInstrumentBeamType.SingleBeam)) {
					nudPMT_Ref.Value = mobjChannnels(mintChannelIndex).EnegryParameter.PMTV_Ref;
				}
				////-----

				////----- Set D2 current Object
				//If gobjCommProtocol.SRLamp Then
				//    intMaxD2Current = 600
				//    intMinD2Current = 100
				//Else
				//    intMaxD2Current = 300
				//    intMinD2Current = 100
				//End If

				//nudD2Cur.Value = gobjInst.D2Current

				nudD2Cur.Value = mobjChannnels(mintChannelIndex).EnegryParameter.D2Curr;
				////-----

				////----- Set Slit width Object
				//nudSlit.Value = gobjClsAAS203.funcGet_SlitWidth()

				nudSlit.Value = Val(mobjChannnels(mintChannelIndex).EnegryParameter.SlitWidth);
				nudSlit_Ref.Value = Val(mobjChannnels(mintChannelIndex).EnegryParameter.SlitWidthRef);

				dblBhHeight = Val(mobjChannnels(mintChannelIndex).EnegryParameter.BurnerHeight);

				nudBurnerHeight.Value = dblBhHeight;
				//Val(mobjChannnels(mintChannelIndex).EnegryParameter.BurnerHeight)


				nudFuelRatio.Value = Val(mobjChannnels(mintChannelIndex).EnegryParameter.FualRatio);

				nudHCLCur.Value = Val(mobjChannnels(mintChannelIndex).EnegryParameter.HCLCurr);



				////-----
				////----- Commented by Sachin Dokhale against VCK
				//Dim intSelectedModeType As Integer
				//If gintInstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.DoubleBeam Then
				//    Select Case mobjChannnels(mintChannelIndex).EnegryParameter.Cal_Mode()
				//        Case EnumCalibrationMode.AA
				//            intSelectedModeType = 0
				//        Case EnumCalibrationMode.HCLE
				//            intSelectedModeType = 1
				//        Case EnumCalibrationMode.AABGC
				//            intSelectedModeType = 2
				//            'Case EnumCalibrationMode.SELFTEST
				//            '    intSelectedModeType = 2
				//    End Select
				//Else
				//    intSelectedModeType = mobjChannnels(mintChannelIndex).EnegryParameter.Cal_Mode()
				//End If
				cmbModes.SelectedIndex = mobjChannnels(mintChannelIndex).EnegryParameter.Cal_Mode();

				//cmbModes.SelectedIndex = intSelectedModeType


				////----- Set the d2E default mode
				////----- Set slow Speed s
				switch (mobjChannnels(mintChannelIndex).EnegryParameter.ScanSpeed) {
					case CONST_FASTStep:
						cmbSpeed.SelectedIndex = 0;
					case CONST_MEDIUMStep:
						cmbSpeed.SelectedIndex = 1;
					case CONST_SLOWStep:
						cmbSpeed.SelectedIndex = 2;
				}


			}
			Application.DoEvents();
			funcSetParameter = true;

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

	private bool funcGetInstParameter()
	{
		//=====================================================================
		// Procedure Name        : funcGetInstParameter
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : 
		// Description           : Set Instrument Parameter
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 21.11.06
		// Revisions             : 
		//=====================================================================
		int intMaxD2Current;
		int intMinD2Current;
		try {
			funcGetInstParameter = false;


			////----- Set the default parameter to the spectrum.
			///----- Set the Form object parameter
			////----- added by Sachin dokhale to remove handlers on 08.10.07
			//28.09.07
			//If gblnSetSpeedIssue = True Then
			nudFuelRatio.ValueEditorClick -= nudFuelRatio_ValueEditorClick;
			nudFuelRatio.ValueEditorValueChanged -= nudFuelRatio_ValueChanged;

			//AddHandler nudBurnerHeight.ValueChanged, AddressOf nudBurnerHeight_ValueChanged
			nudBurnerHeight.ValueEditorClick -= nudBurnerHeight_ValueEditorClick;
			nudBurnerHeight.ValueEditorValueChanged -= nudBurnerHeight_ValueChanged;

			//AddHandler nudD2Cur.ValueChanged, AddressOf nudD2Cur_ValueChanged
			nudD2Cur.ValueEditorClick -= nudD2Cur_ValueEditorClick;
			nudD2Cur.ValueEditorValueChanged -= nudD2Cur_ValueChanged;

			//AddHandler nudHCLCur.ValueChanged, AddressOf nudHCLCur_ValueChanged
			nudHCLCur.ValueEditorClick -= nudHCLCur_ValueEditorClick;
			nudHCLCur.ValueEditorValueChanged -= nudHCLCur_ValueChanged;

			//AddHandler nudSlit.ValueChanged, AddressOf nudSlit_ValueChanged
			nudSlit.ValueEditorClick -= nudSlit_ValueEditorClick;
			nudSlit.ValueEditorValueChanged -= nudSlit_ValueChanged;
			nudSlit_Ref.ValueEditorClick -= nudSlit_Ref_ValueEditorClick;
			nudSlit_Ref.ValueEditorValueChanged -= nudSlit_Ref_ValueChanged;

			//AddHandler nudPMT.ValueChanged, AddressOf nudPMT_ValueChanged
			nudPMT.ValueEditorClick -= nudPMT_ValueEditorClick;
			nudPMT.ValueEditorValueChanged -= nudPMT_ValueChanged;
			nudPMT_Ref.ValueEditorClick -= nudPMT_Ref_ValueEditorClick;
			nudPMT_Ref.ValueEditorValueChanged -= nudPMT_Ref_ValueChanged;

			//End If
			////-----

			////----- Set PMT Object
			nudPMT.Value = gobjInst.PmtVoltage;
			if (!(gintInstrumentBeamType == AAS203Library.Instrument.enumInstrumentBeamType.SingleBeam)) {
				nudPMT_Ref.Value = gobjInst.PmtVoltageReference;
			}
			//mobjParameters.PMTV = gobjInst.PmtVoltage
			//nudPMT.Value = mobjChannnels(mintChannelIndex).EnegryParameter.PMTV()
			////-----

			////----- Set D2 current Object
			//If gobjCommProtocol.SRLamp Then
			//    intMaxD2Current = 600
			//    intMinD2Current = 100
			//Else
			//    intMaxD2Current = 300
			//    intMinD2Current = 100
			//End If

			nudD2Cur.Value = gobjInst.D2Current;
			//mobjParameters.D2Curr = gobjInst.D2Current
			//nudD2Cur.Value = mobjChannnels(mintChannelIndex).EnegryParameter.D2Curr
			////-----

			////----- Set Slit width Object
			//nudSlit.Value = mobjChannnels(mintChannelIndex).EnegryParameter.SlitWidth
			nudSlit.Value = gobjClsAAS203.funcGet_SlitWidth();
			nudSlit_Ref.Value = gobjClsAAS203.funcGet_SlitWidth(1);


			//nudBurnerHeight.Value = mobjChannnels(mintChannelIndex).EnegryParameter.BurnerHeight
			nudBurnerHeight.Value = gobjClsAAS203.funcReadBurnerHeight();
			//mobjParameters.BurnerHeight = CDbl(nudBurnerHeight.Value)

			//nudFuelRatio.Value = mobjChannnels(mintChannelIndex).EnegryParameter.FualRatio
			funcSetFuelParameter(mdblFuelRatio);
			mdblFuelRatio = Format(mdblFuelRatio, "#.00");
			nudFuelRatio.Value = Format(mdblFuelRatio, "#.00");
			//mobjParameters.FualRatio = Format(mdblFuelRatio, "#.00")

			//nudHCLCur.Value = mobjChannnels(mintChannelIndex).EnegryParameter.HCLCurr
			nudHCLCur.Value = gobjInst.Current;
			//mobjParameters.HCLCurr = gobjInst.Current

			if (!(mobjParameters == null)) {
				mobjParameters.PMTV = gobjInst.PmtVoltage;
				mobjParameters.PMTV_Ref = gobjInst.PmtVoltageReference;
				mobjParameters.HCLCurr = gobjInst.Current;
				mobjParameters.D2Curr = gobjInst.D2Current;
				mobjParameters.SlitWidth = Val(nudSlit.Value);
				mobjParameters.SlitWidthRef = Val(nudSlit_Ref.Value);
				mobjParameters.BurnerHeight = (double)nudBurnerHeight.Value;
				mobjParameters.FualRatio = Format(mdblFuelRatio, "#.00");
				mobjParameters.LampEle = gobjInst.Lamp.LampParametersCollection(gobjInst.Lamp_Position - 1).ElementName;
				mobjParameters.LampTurrNo = gobjInst.Lamp_Position;

				lblWvPos.Text = mXValueLable + gobjInst.WavelengthCur;
				lblWvPos.Refresh();
				lblYValue.Text = mYValueLable;
				lblYValue.Refresh();
			}
			////-----

			//cmbModes.SelectedIndex = mobjChannnels(mintChannelIndex).EnegryParameter.Cal_Mode()
			//cmbModes.SelectedIndex = 

			//End If
			cmbModes.SelectedIndex = gobjInst.Mode;

			//If gblnSetSpeedIssue = True Then
			////----- added by Sachin dokhale to add handlers on 08.10.07
			//28.09.07
			nudFuelRatio.ValueEditorClick += nudFuelRatio_ValueEditorClick;
			nudFuelRatio.ValueEditorValueChanged += nudFuelRatio_ValueChanged;

			//AddHandler nudBurnerHeight.ValueChanged, AddressOf nudBurnerHeight_ValueChanged
			nudBurnerHeight.ValueEditorClick += nudBurnerHeight_ValueEditorClick;
			nudBurnerHeight.ValueEditorValueChanged += nudBurnerHeight_ValueChanged;

			//AddHandler nudD2Cur.ValueChanged, AddressOf nudD2Cur_ValueChanged
			nudD2Cur.ValueEditorClick += nudD2Cur_ValueEditorClick;
			nudD2Cur.ValueEditorValueChanged += nudD2Cur_ValueChanged;

			//AddHandler nudHCLCur.ValueChanged, AddressOf nudHCLCur_ValueChanged
			nudHCLCur.ValueEditorClick += nudHCLCur_ValueEditorClick;
			nudHCLCur.ValueEditorValueChanged += nudHCLCur_ValueChanged;

			//AddHandler nudSlit.ValueChanged, AddressOf nudSlit_ValueChanged
			nudSlit.ValueEditorClick += nudSlit_ValueEditorClick;
			nudSlit.ValueEditorValueChanged += nudSlit_ValueChanged;
			nudSlit_Ref.ValueEditorClick += nudSlit_Ref_ValueEditorClick;
			nudSlit_Ref.ValueEditorValueChanged += nudSlit_Ref_ValueChanged;

			//AddHandler nudPMT.ValueChanged, AddressOf nudPMT_ValueChanged
			nudPMT.ValueEditorClick += nudPMT_ValueEditorClick;
			nudPMT.ValueEditorValueChanged += nudPMT_ValueChanged;
			nudPMT_Ref.ValueEditorClick += nudPMT_Ref_ValueEditorClick;
			nudPMT_Ref.ValueEditorValueChanged += nudPMT_Ref_ValueChanged;
			//End If
			////-----
			Application.DoEvents();
			funcGetInstParameter = true;

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

	private bool funcSetSpeed(int intSpeed)
	{
		//=====================================================================
		// Procedure Name        : funcSetSpeed
		// Parameters Passed     : intSpeed 
		// Returns               : Boolean
		// Purpose               : 
		// Description           : Set scan Speed
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 22.11.06
		// Revisions             : 
		//=====================================================================

		try {
			funcSetSpeed = false;
			switch (intSpeed) {
				case 0:
					mobjParameters.ScanSpeed = CONST_FASTStep;
				case 1:
					mobjParameters.ScanSpeed = CONST_MEDIUMStep;
				case 2:
					mobjParameters.ScanSpeed = CONST_SLOWStep;
			}
			funcSetSpeed = true;

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

	//Private Function funcSetModes(ByVal intModes As Integer) As Boolean
	//    '=====================================================================
	//    ' Procedure Name        : funcSetModes
	//    ' Parameters Passed     : intSpeed 
	//    ' Returns               : Boolean
	//    ' Purpose               : 
	//    ' Description           : Set scan Speed
	//    ' Assumptions           : 
	//    ' Dependencies          : 
	//    ' Author                : Sachin Dokhale
	//    ' Created               : 22.11.06
	//    ' Revisions             : 
	//    '=====================================================================

	//    Try
	//        funcSetModes = False
	//        Select Case intModes
	//            Case 0
	//                mobjParameters.ScanSpeed = CONST_FASTStep
	//            Case 1
	//                mobjParameters.ScanSpeed = CONST_MEDIUMStep
	//            Case 2
	//                mobjParameters.ScanSpeed = CONST_SLOWStep
	//        End Select
	//        mobjParameters.Cal_Mode = intModes
	//        funcSetModes = True

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

	private void subLabelDisplay(Spectrum.Channel objChannel)
	{
		//=====================================================================
		// Procedure Name        :   subLabelDisplay
		// Description           :    
		// Purpose               :    
		//                           
		// Parameters Passed     :   None.
		// Returns               :    
		// Parameters Affected   :   None.
		// Assumptions           :
		// Dependencies          :
		// Author                :   Gitesh, Uday
		// Created               :   Saturday, November 15, 2003 18:49
		// Revisions             :
		//=====================================================================
		try {
		//Select Case objChannel.Parameter.ScanSpeed
		//    Case EnumScanSpeed.Fast
		//        lblScanSpeed.Text = CONST_SCAN_SPEED_FAST
		//    Case EnumScanSpeed.Medium
		//        lblScanSpeed.Text = CONST_SCAN_SPEED_MEDIUM
		//    Case EnumScanSpeed.Slow
		//        lblScanSpeed.Text = CONST_SCAN_SPEED_SLOW
		//    Case EnumScanSpeed.VerySlow
		//        lblScanSpeed.Text = CONST_SCAN_SPEED_VERY_SLOW
		//End Select

		//lblAnalystName.Text = objChannel.Parameter.AnalystName
		//lblAnalystName.Refresh()
		//lblSpectrumName.Text = objChannel.Parameter.ChannelName
		//lblSpectrumName.Refresh()
		//added and commented by kamal on 19March2004
		//----------------------------
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
		//gobjErrorHandler.ProcessError(ErrorHandler.EnumErrorType.Critical, ex)
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

	private int funcAddChannelToCollection(ref Spectrum.Channel objInChannel)
	{
		//ByRef objInChannel As Spectrum.EnergyChannels
		//=====================================================================
		// Procedure Name        :   funcAddChannelToCollection
		// Description           :   Add the channel to the channels collection
		//                           mobjChannels to the next index of the current 
		//                           active index of the channel.
		// Purpose               :   To add the channel object to the channels
		//                           collection (stored in the module level).
		// Parameters Passed     :   None.
		// Returns               :   new index of the channel added.
		// Parameters Affected   :   None.
		// Assumptions           :   None.
		// Dependencies          :   None. 
		// Author                :   Sachin Dokhale
		// Created               :   13.12.06
		// Revisions             :
		//=====================================================================
		int intChannel_no = -1;

		try {
			//--- Set the channel index location in the main
			//--- channel collection

			//If mobjChannnels.Count = CONST_CHANNEL_COUNT Then
			//    intChannel_no = CInt(gfuncGetINISystemParameters(CONST_SECTION_SpectrumChannel, CONST_Key_CurrentChannel))
			//    If intChannel_no >= CONST_CHANNEL_COUNT - 1 Then
			//        intChannel_no = 0
			//    Else
			//        intChannel_no += 1
			//    End If

			//Else
			intChannel_no = mobjChannnels.Count;
			mobjChannnels.Add(objInChannel);
			objInChannel.ChannelNo = intChannel_no;
			//mobjChannnels.Add(objInChannel)

			//End If

			//--- Save or overwrite the channel to the file using serializability
			//If Not gfuncSaveChannelToFile(objInChannel) Then
			//    '--- log the error saving the channel file.
			//    gFuncShowMessage("Error...", "Error in save channel file.", modConstants.EnumMessageType.Information)
			//End If

			//gfuncWriteINISystemParameters(CONST_SECTION_SpectrumChannel, CONST_Key_CurrentChannel, intChannel_no)

			return intChannel_no;

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			//gobjErrorHandler.ProcessError(EnumErrorType.Critical, ex)
			//---------------------------------------------------------
			return -1;
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			//---------------------------------------------------------
		}

	}

	//Private Function funcCloneParameter(ByVal inobjparamter As Spectrum.EnergySpectrumParameter) As Spectrum.EnergySpectrumParameter
	//    '=====================================================================
	//    ' Procedure Name        :   funcCloneParameter
	//    ' Description           :    
	//    ' Purpose               :    
	//    '                           
	//    ' Parameters Passed     :   None.
	//    ' Returns               :   True, if successful.
	//    ' Parameters Affected   :   None.
	//    ' Assumptions           :
	//    ' Dependencies          :
	//    ' Author                :   Gitesh, Uday
	//    ' Created               :   Saturday, November 15, 2003 18:49
	//    ' Revisions             :
	//    '=====================================================================
	//    Try
	//        Dim objCloneParameter As New EnergySpectrumParameter
	//        '----------------------Cloning  parameter object ----------------------------------
	//        objCloneParameter.AnalysisDate = inobjparamter.AnalysisDate
	//        objCloneParameter.BurnerHeight = inobjparamter.BurnerHeight
	//        objCloneParameter.FualRatio = inobjparamter.FualRatio
	//        objCloneParameter.HCLCurr = inobjparamter.HCLCurr
	//        objCloneParameter.LampEle = inobjparamter.LampEle
	//        objCloneParameter.LampTurrNo = inobjparamter.LampTurrNo
	//        objCloneParameter.Cal_Mode = inobjparamter.Cal_Mode
	//        objCloneParameter.Comments = inobjparamter.Comments
	//        objCloneParameter.D2Curr = inobjparamter.D2Curr
	//        objCloneParameter.PMTV = inobjparamter.PMTV
	//        objCloneParameter.PMTV_Ref = inobjparamter.PMTV_Ref
	//        objCloneParameter.ScanSpeed = inobjparamter.ScanSpeed
	//        objCloneParameter.SlitWidth = inobjparamter.SlitWidth
	//        objCloneParameter.SlitWidthRef = inobjparamter.SlitWidthRef
	//        objCloneParameter.SpectrumName = inobjparamter.SpectrumName
	//        objCloneParameter.XaxisMax = inobjparamter.XaxisMax
	//        objCloneParameter.XaxisMin = inobjparamter.XaxisMin
	//        objCloneParameter.YaxisMax = inobjparamter.YaxisMax
	//        objCloneParameter.YaxisMin = inobjparamter.YaxisMin

	//        '----------------------Clonong  parameter object ends -----------------------------
	//        Return objCloneParameter

	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        'Error Handling and logging
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = ex.Message
	//        gobjErrorHandler.WriteErrorLog(ex)
	//        'gobjErrorHandler.ProcessError(EnumErrorType.Critical, ex)
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

	private bool funcAbsConvertTransmission()
	{
		//=====================================================================
		// Procedure Name        :   funcAbsConvertTransmission
		// Description           :   
		// Purpose               :   
		// Parameters Passed     :   None.
		// Returns               :   Boolean
		// Parameters Affected   :   None.
		// Assumptions           :   None.
		// Dependencies          :   None. 
		// Author                :   Sachin Dokhale
		// Created               :   13.12.06
		// Revisions             :
		//=====================================================================
		double dblCurrYaxis;
		double dblNewYaxis;
		double intXaxisIdx;

		try {
			//void  abs_trans(HWND hwnd)
			//{
			//int i, k;

			//if (addata.ad!=NULL) {
			//  for (i=0; i<addata.counter; i++){
			//	 k= 2047.0 + exp((2.0- ((addata.ad[i]-2047.0)*2.0/1638.4)) *log(10))*2048.0/100.0;
			//	 addata.ad[i] =k;
			//	}
			//  UVABS=FALSE;
			//  SpectGraph.Ymin = 0;
			//  SpectGraph.Ymax = 100;
			//  Scroll_Mode1(hwnd,IDC_MODE, -1 );
			//  }
			//}

			gblnUVABS = false;
			if (mobjChannnels.Count > 0) {
				if (mobjChannnels.item(mintChannelIndex).Spectrums.Count > 0) {
					//For intXaxisIdx = gFuncGetIndexWv(mobjChannnels.item(mintChannelIndex).UVParameter.XaxisMin, False) To gFuncGetIndexWv(mobjChannnels.item(mintChannelIndex).UVParameter.XaxisMax, False)
					for (intXaxisIdx = 0; intXaxisIdx <= mobjChannnels.item(mintChannelIndex).Spectrums.item(0).Readings.Count - 1; intXaxisIdx++) {
						dblCurrYaxis = mobjChannnels.item(mintChannelIndex).Spectrums.item(0).Readings.item(intXaxisIdx).YaxisData;
						//k= 2047.0 + exp((2.0- ((addata.ad[i]-2047.0)*2.0/1638.4)) *log(10))*2048.0/100.0;
						dblNewYaxis = 2047.0 + Math.Exp((2.0 - ((dblCurrYaxis - 2047.0) * 2.0 / 1638.4)) * Math.Log(10)) * 2048.0 / 100.0;
						mobjChannnels.item(mintChannelIndex).Spectrums.item(0).Readings.item(intXaxisIdx).YaxisData = dblNewYaxis;
					}
				}
			}
			funcClearGraph();

			mobjChannnels.item(mintChannelIndex).EnegryParameter.YaxisMax = 100;
			mobjChannnels.item(mintChannelIndex).EnegryParameter.YaxisMin = 0;

			funcClearGraph();

			funcDisplayGraph(mobjChannnels.item(mintChannelIndex));
			funcGraphPreRequisite(mobjParameters.Cal_Mode, mobjParameters.XaxisMin, mobjParameters.XaxisMax, mobjParameters.YaxisMin, mobjParameters.YaxisMax);
			return true;
		//           if (addata.ad!=NULL) {
		// for (i=0; i<addata.counter; i++){
		// k= 2047.0 + exp((2.0- ((addata.ad[i]-2047.0)*2.0/1638.4)) *log(10))*2048.0/100.0;
		// addata.ad[i] =k;
		//}
		// UVABS=FALSE;
		// SpectGraph.Ymin = 0;
		// SpectGraph.Ymax = 100;
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			//gobjErrorHandler.ProcessError(EnumErrorType.Critical, ex)
			//---------------------------------------------------------
			return false;
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			//---------------------------------------------------------
		}


	}

	private bool funcSetDefaultSpectrumParameter(int intCalibrationMode)
	{
		//=====================================================================
		// Procedure Name        : funcSetDefaultSpectrumParameter
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : 
		// Description           : Set Spectrum Parameter
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 21.11.06
		// Revisions             : 
		//=====================================================================
		static bool blnSetDefaultSpectrumParameter;
		try {
			funcSetDefaultSpectrumParameter = false;
			////----- Set the default parameter to the spectrum.
			if ((gobjInst.Mode == intCalibrationMode) & (blnSetDefaultSpectrumParameter == true)) {
				funcSetDefaultSpectrumParameter = true;
				return;
			}

			if (gobjCommProtocol.funcCalibrationMode(intCalibrationMode)) {
				//addataSpect.dblWvMin = 230.0
				//addataSpect.dblWvMax = 250.0

				//mobjParameters.XaxisMin = const_WvMin
				//mobjParameters.XaxisMax = const_WvMax

				///commented and added following code on '08.05.08
				//-----------------
				///If WvStartRange = 0.0 Then
				///    WvLastRange = const_WvMax
				///ElseIf Not (gobjInst.WavelengthCur = 0.0) Then
				///    If (gobjInst.WavelengthCur < WvStartRange Or _
				///        gobjInst.WavelengthCur > WvLastRange) Then
				///        Dim dblRangeDiff As Double = WvLastRange - WvStartRange
				///        WvLastRange = WvStartRange + dblRangeDiff
				///        WvStartRange = gobjInst.WavelengthCur
				///    End If
				///End If
				//-----------------

				//08.05.08
				//-----------------

				WvStartRange = Fix(gobjInst.WavelengthCur);
				WvLastRange = WvStartRange + 10;
				lblWvPos.Text = mXValueLable + FormatNumber(gobjInst.WavelengthCur, 2);
				//-----------------

				mobjParameters.XaxisMin = WvStartRange;
				mobjParameters.XaxisMax = WvLastRange;

				switch (gobjInst.Mode) {
					case EnumCalibrationMode.AA:
					case EnumCalibrationMode.AABGC:
					case EnumCalibrationMode.MABS:

						mobjParameters.YaxisMax = const_YMaxAbs;
						mobjParameters.YaxisMin = const_YMinAbs;
						mYValueLable = const_Absorbance;
					case EnumCalibrationMode.HCLE:
					case EnumCalibrationMode.D2E:
						mobjParameters.YaxisMin = const_YMinEnergy;
						mobjParameters.YaxisMax = const_YMaxEnergy;
						mYValueLable = const_Energy;
					case EnumCalibrationMode.EMISSION:

						mobjParameters.YaxisMin = const_YMinEmission;
						mobjParameters.YaxisMax = const_YMaxEmission;
						mYValueLable = const_Emission;
					case EnumCalibrationMode.SELFTEST:
						mobjParameters.YaxisMin = const_YMinmVolt;
						mobjParameters.YaxisMax = const_YMaxmVolt;
						mYValueLable = const_Volt;
				}

				//addataSpect.intSpeed = 0
				//addataSpect.intMode = gobjInst.Mode
				//mobjParameters.ScanSpeed = CONST_SLOWStep 

				mobjParameters.Cal_Mode = gobjInst.Mode;
				//addataSpect.blnPloted = True
				////-----
				AASEnergySpectrum.AldysPane.Legend.IsVisible = false;
				funcClearGraph();
				funcGraphPreRequisite(mobjParameters.Cal_Mode, mobjParameters.XaxisMin, mobjParameters.XaxisMax, mobjParameters.YaxisMin, mobjParameters.YaxisMax);

				blnSetDefaultSpectrumParameter = true;
				funcSetDefaultSpectrumParameter = true;
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

	private bool funcSetSpectrumParameter(int intCalibrationMode)
	{
		//=====================================================================
		// Procedure Name        : funcSetSpectrumParameter
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : 
		// Description           : Set Spectrum Parameter
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 21.11.06
		// Revisions             : 
		//=====================================================================

		try {
			funcSetSpectrumParameter = false;
			////----- Set the default parameter to the spectrum.
			if (mblnReSetSpectrumParameter == false) {
				if ((gobjInst.Mode == intCalibrationMode)) {
					funcSetSpectrumParameter = true;
					mblnReSetSpectrumParameter = true;
					return;
				}
			}


			if (gobjCommProtocol.funcCalibrationMode(intCalibrationMode)) {
				//addataSpect.dblWvMin = 230.0
				//addataSpect.dblWvMax = 250.0

				switch (gobjInst.Mode) {
					case EnumCalibrationMode.AA:
					case EnumCalibrationMode.AABGC:
					case EnumCalibrationMode.MABS:

						mobjParameters.YaxisMax = const_YMaxAbs;
						mobjParameters.YaxisMin = const_YMinAbs;
						mYValueLable = const_Absorbance;
					case EnumCalibrationMode.HCLE:
					case EnumCalibrationMode.D2E:
						mobjParameters.YaxisMin = const_YMinEnergy;
						mobjParameters.YaxisMax = const_YMaxEnergy;
						mYValueLable = const_Energy;
					case EnumCalibrationMode.EMISSION:

						mobjParameters.YaxisMin = const_YMinEmission;
						mobjParameters.YaxisMax = const_YMaxEmission;
						mYValueLable = const_Emission;
					case EnumCalibrationMode.SELFTEST:
						mobjParameters.YaxisMin = const_YMinmVolt;
						mobjParameters.YaxisMax = const_YMaxmVolt;
						mYValueLable = const_Volt;
				}

				lblYValue.Text = mYValueLable;
				lblYValue.Refresh();

				//addataSpect.intSpeed = 0
				//addataSpect.intMode = gobjInst.Mode

				mobjParameters.Cal_Mode = gobjInst.Mode;
				//addataSpect.blnPloted = True
				////-----
				AASEnergySpectrum.AldysPane.Legend.IsVisible = false;
				funcClearGraph();
				funcGraphPreRequisite(mobjParameters.Cal_Mode, mobjParameters.XaxisMin, mobjParameters.XaxisMax, mobjParameters.YaxisMin, mobjParameters.YaxisMax);

				funcSetSpectrumParameter = true;

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

	private bool funcSetDefaultParameter()
	{
		//=====================================================================
		// Procedure Name        : funcSetDefaultParameter
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : 
		// Description           : Set Spectrum Parameter
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 21.11.06
		// Revisions             : 
		//=====================================================================
		int intMaxD2Current;
		int intMinD2Current;
		try {
			funcSetDefaultParameter = false;

			////--------
			///----- Set the Form object parameter
			////----- Set the default parameter to the spectrum.

			////----- Set PMT Object
			//nudPMT.DecimalPlaces = 0
			//nudPMT.Increment = 5.0
			//nudPMT.Maximum = 700.0
			//nudPMT.Minimum = 0.0
			nudPMT.DecimalPlace = 0;
			nudPMT.ChangeFactor = 5.0;
			nudPMT.MaxValue = 700.0;
			nudPMT.MinValue = 0.0;
			nudPMT.Value = gobjInst.PmtVoltage;
			mobjParameters.PMTV = gobjInst.PmtVoltage;

			////-----commented on 21.01.08 Deepak
			//'If gintInstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.DoubleBeam Then
			//'If gobjInst.PmtVoltageReference = 0 Then

			//'    'gobjInst.PmtVoltageReference = gobjInst.PmtVoltage
			//'    Call funcSetPmtVParameter_Ref(gobjInst.PmtVoltage)
			//'End If
			//'End If

			if (!(gintInstrumentBeamType == AAS203Library.Instrument.enumInstrumentBeamType.SingleBeam)) {
				nudPMT_Ref.DecimalPlace = 0;
				nudPMT_Ref.ChangeFactor = 5.0;
				nudPMT_Ref.MaxValue = 700.0;
				nudPMT_Ref.MinValue = 0.0;
				nudPMT_Ref.Value = gobjInst.PmtVoltageReference;
				mobjParameters.PMTV_Ref = gobjInst.PmtVoltageReference;
				nudPMT_Ref.Enabled = true;
			} else {
				nudPMT_Ref.Enabled = false;
			}
			////----- Set D2 current Object
			if (gobjCommProtocol.SRLamp) {
				intMaxD2Current = 600;
				intMinD2Current = 100;
			} else {
				intMaxD2Current = 300;
				intMinD2Current = 100;
			}

			//---added by deepak on 02.08.07 to make the ref pmt equal to samp pmt in aa mode
			//If gintInstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.DoubleBeam Then
			//    If gobjInst.PmtVoltageReference = 0 Then

			//        'gobjInst.PmtVoltageReference = gobjInst.PmtVoltage
			//        Call funcSetPmtVParameter_Ref(gobjInst.PmtVoltage)
			//    End If
			//End If
			//---

			//nudD2Cur.DecimalPlaces = 0
			//nudD2Cur.Increment = 1
			//nudD2Cur.Maximum = intMaxD2Current
			//nudD2Cur.Minimum = intMinD2Current
			nudD2Cur.DecimalPlace = 0;
			nudD2Cur.ChangeFactor = 1;
			nudD2Cur.MaxValue = intMaxD2Current;
			nudD2Cur.MinValue = intMinD2Current;

			nudD2Cur.Value = gobjInst.D2Current;
			if (nudD2Cur.Value == 100.0) {
				nudD2Cur.Text = "D2 Off";
			}
			mobjParameters.D2Curr = gobjInst.D2Current;
			////-----

			////----- Set Fuel Ratio object
			//nudFuelRatio.DecimalPlaces = 2
			//nudFuelRatio.Increment = 0.1
			//nudFuelRatio.Maximum = 25.0
			//nudFuelRatio.Minimum = -115.0

			nudFuelRatio.DecimalPlace = 2;
			nudFuelRatio.ChangeFactor = 0.1;
			nudFuelRatio.MaxValue = 25.0;
			nudFuelRatio.MinValue = 0.0;

			//funcSetFuelParameter(0.0)
			//Call gobjCommProtocol.funcGet_NV_Pos()
			mdblFuelRatio = gobjClsAAS203.funcGet_Fuel_Ratio(true);
			if (mdblFuelRatio < 0.0) {
				//'setting some validation
				mdblFuelRatio = 0.0;
			} else {
				mdblFuelRatio = Format(mdblFuelRatio, "#0.00");
			}
			nudFuelRatio.Value = mdblFuelRatio;
			mobjParameters.FualRatio = mdblFuelRatio;
			////-----

			////----- Set HCL Current Object
			//nudHCLCur.DecimalPlaces = 1
			//nudHCLCur.Increment = 0.1
			//nudHCLCur.Maximum = 25.0
			//nudHCLCur.Minimum = 0.0
			nudHCLCur.DecimalPlace = 1;
			nudHCLCur.ChangeFactor = 0.1;
			nudHCLCur.MaxValue = 25.0;
			nudHCLCur.MinValue = 0.0;

			nudHCLCur.Value = gobjInst.Current;
			mobjParameters.HCLCurr = gobjInst.Current;
			////-----

			////----- Set Burner Height Object
			//nudBurnerHeight.DecimalPlaces = 2
			//nudBurnerHeight.Increment = 0.1
			//nudBurnerHeight.Maximum = 6.0
			//nudBurnerHeight.Minimum = 0.0

			nudBurnerHeight.DecimalPlace = 2;
			nudBurnerHeight.ChangeFactor = 0.1;
			nudBurnerHeight.MaxValue = 6.0;
			nudBurnerHeight.MinValue = 0.0;
			dblBhHeight = gobjClsAAS203.funcReadBurnerHeight();
			nudBurnerHeight.Value = gobjClsAAS203.funcReadBurnerHeight();
			mobjParameters.BurnerHeight = (double)nudBurnerHeight.Value;
			////-----

			////----- Set Slit width Object
			//nudSlit.DecimalPlaces = 1
			//nudSlit.Increment = 0.1
			//nudSlit.Maximum = 2.0
			//nudSlit.Minimum = 0.0

			nudSlit.DecimalPlace = 1;
			nudSlit.ChangeFactor = 0.1;
			nudSlit.MaxValue = 2.0;
			nudSlit.MinValue = 0.0;
			nudSlit.Value = gobjClsAAS203.funcGet_SlitWidth();
			mobjParameters.SlitWidth = (double)nudSlit.Value;

			nudSlit_Ref.DecimalPlace = 1;
			nudSlit_Ref.ChangeFactor = 0.1;
			nudSlit_Ref.MaxValue = 2.0;
			nudSlit_Ref.MinValue = 0.0;
			nudSlit_Ref.Value = gobjClsAAS203.funcGet_SlitWidth(1);
			mobjParameters.SlitWidthRef = (double)nudSlit_Ref.Value;

			mobjParameters.LampEle = gobjInst.Lamp.LampParametersCollection(gobjInst.Lamp_Position - 1).ElementName;
			mobjParameters.LampTurrNo = gobjInst.Lamp_Position;


			//mobjParameters.Cal_Mode = gobjInst.Mode

			////----- Commented by Sachin Dokhale against VCK
			//If gintInstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.DoubleBeam Then
			//    Dim intSelectedModeType As Integer
			//    Select Case gobjInst.Mode
			//        Case EnumCalibrationMode.AA
			//            intSelectedModeType = EnumCalibrationMode.AA
			//        Case EnumCalibrationMode.HCLE
			//            intSelectedModeType = EnumCalibrationMode.HCLE
			//        Case EnumCalibrationMode.AABGC
			//            intSelectedModeType = 2 'EnumCalibrationMode.AABGC
			//            'Case EnumCalibrationMode.SELFTEST
			//            '    intSelectedModeType = 2 'EnumCalibrationMode.SELFTEST
			//    End Select
			//    '    Call funcSetSpectrumParameter(intSelectedModeType)
			//    cmbModes.SelectedIndex = intSelectedModeType
			//Else
			//    cmbModes.SelectedIndex = gobjInst.Mode
			//End If
			////-----
			cmbModes.SelectedIndex = gobjInst.Mode;
			mobjParameters.ScanSpeed = CONST_SLOWStep;
			cmbSpeed.SelectedIndex = 2;
			//mobjParameters.ScanSpeed = CONST_FASTStep
			lblYValue.Text = mYValueLable;
			lblYValue.Refresh();
			////-----

			funcSetDefaultParameter = true;

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
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

	private bool funcSetPmtVParameter(double dblPmtV)
	{
		//=====================================================================
		// Procedure Name        : funcSetPmtVParameter
		// Parameters Passed     : dblPmtV 
		// Returns               : Boolean
		// Purpose               : 
		// Description           : Set Pmt Volt Parameter
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 22.11.06
		// Revisions             : 
		//=====================================================================
		double dblPMTVolt;
		double dblAdjPMTVolt;

		try {
			funcSetPmtVParameter = false;
			dblPMTVolt = gobjInst.PmtVoltage;


			if (!dblPmtV == dblPMTVolt) {

				if (dblPmtV > dblPMTVolt) {
					//dblPMTVolt += 5.0
					dblAdjPMTVolt = dblPmtV - dblPMTVolt;
					if (dblAdjPMTVolt > 0) {
						dblPMTVolt += dblAdjPMTVolt;
					}
				} else if (dblPmtV < dblPMTVolt) {
					//dblPMTVolt -= 5.0
					dblAdjPMTVolt = dblPMTVolt - dblPmtV;
					if (dblAdjPMTVolt > 0) {
						dblPMTVolt -= dblAdjPMTVolt;
					}

				}

				if (dblPMTVolt > 700) {
					dblPMTVolt = 0.0;
				} else if (dblPMTVolt < 0.0) {
					dblPMTVolt = 0.0;
				}
				if (gobjCommProtocol.funcSet_PMT(dblPMTVolt) == true) {
					//gobjInst.PmtVoltage = dblPMTVolt
					funcSetPmtVParameter = true;
				}

				mobjParameters.PMTV = Val(dblPMTVolt);
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

	private bool funcSetPmtVParameter_Ref(double dblPmtV)
	{
		//=====================================================================
		// Procedure Name        : funcSetPmtVParameter_Ref
		// Parameters Passed     : dblPmtV 
		// Returns               : Boolean
		// Purpose               : 
		// Description           : Set Pmt Volt Parameter
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 22.11.06
		// Revisions             : 
		//=====================================================================
		double dblPMTVolt;
		double dblAdjPMTVolt;

		try {
			funcSetPmtVParameter_Ref = false;
			dblPMTVolt = gobjInst.PmtVoltageReference;


			if (!dblPmtV == dblPMTVolt) {

				if (dblPmtV > dblPMTVolt) {
					//dblPMTVolt += 5.0
					dblAdjPMTVolt = dblPmtV - dblPMTVolt;
					if (dblAdjPMTVolt > 0) {
						dblPMTVolt += dblAdjPMTVolt;
					}
				} else if (dblPmtV < dblPMTVolt) {
					//dblPMTVolt -= 5.0
					dblAdjPMTVolt = dblPMTVolt - dblPmtV;
					if (dblAdjPMTVolt > 0) {
						dblPMTVolt -= dblAdjPMTVolt;
					}

				}

				if (dblPMTVolt > 700) {
					dblPMTVolt = 0.0;
				} else if (dblPMTVolt < 0.0) {
					dblPMTVolt = 0.0;
				}
				if (gobjCommProtocol.funcSet_PMTReferenceBeam(dblPMTVolt) == true) {
					//gobjInst.PmtVoltage = dblPMTVolt
					funcSetPmtVParameter_Ref = true;
				}

				mobjParameters.PMTV_Ref = Val(dblPMTVolt);
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

	private bool funcSetHCL_CurParameter(double dblHCL_Cur)
	{
		//=====================================================================
		// Procedure Name        : funcSetHCL_CurParameter
		// Parameters Passed     : dblHCL_Cur
		// Returns               : Boolean
		// Purpose               : 
		// Description           : Set HCL Current Parameter
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 22.11.06
		// Revisions             : 
		//=====================================================================
		double dblLampCurrent;

		try {
			funcSetHCL_CurParameter = false;
			if (gobjInst.Lamp_Position >= 1 & gobjInst.Lamp_Position <= gobjClsAAS203.funcGetMaxLamp()) {
				dblLampCurrent = gobjInst.Current;
				//dblHCL_Cur()
				dblLampCurrent = dblHCL_Cur;
				if (dblHCL_Cur > 25)
					dblLampCurrent = 25;
				if (dblHCL_Cur < 0)
					dblLampCurrent = 0;
				gobjCommProtocol.funcSet_HCL_Cur(dblLampCurrent, gobjInst.Lamp_Position);
				gobjInst.Current = dblLampCurrent;
			}
			mobjParameters.HCLCurr = Val(dblLampCurrent);
			funcSetHCL_CurParameter = true;
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
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

	private bool funcSetD2_CurParameter(int intD2_Cur)
	{
		//=====================================================================
		// Procedure Name        : funcSetPmtVParameter
		// Parameters Passed     : dblD2_Cur
		// Returns               : Boolean
		// Purpose               : 
		// Description           : Set D2 Current Parameter
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 22.11.06
		// Revisions             : 
		//=====================================================================

		object intMaxD2Current = 300;
		object intMinD2Current = 100;
		int D2CurrIncrDecr;
		double intD2Lamp_Cur = 0;

		try {
			funcSetD2_CurParameter = false;
			if (gobjCommProtocol.SRLamp) {
				intMaxD2Current = 600;
				intMinD2Current = 100;
			} else {
				intMaxD2Current = 300;
				intMinD2Current = 100;
			}

			intD2Lamp_Cur = gobjInst.D2Current;


			if (intD2Lamp_Cur < intD2_Cur) {
				//intD2Lamp_Cur += 1
				D2CurrIncrDecr = intD2_Cur - intD2Lamp_Cur;

			}

			if (intD2Lamp_Cur > intD2_Cur) {
				//intD2Lamp_Cur -= 1
				D2CurrIncrDecr = intD2_Cur - intD2Lamp_Cur;
			}

			if ((intD2_Cur < intMinD2Current))
				intD2_Cur = intMaxD2Current;
			if ((intD2_Cur > intMaxD2Current))
				intD2_Cur = intMinD2Current;

			////----- Set the D2 current to the Instrument
			gobjCommProtocol.funcSetD2Cur(intD2_Cur);

			if (gobjCommProtocol.SRLamp) {
				gobjInst.D2Current = intD2Lamp_Cur;
			} else {
				if (intD2Lamp_Cur == 100) {
				}
			}
			mobjParameters.D2Curr = Val(intD2_Cur);
			funcSetD2_CurParameter = true;
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
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

	private bool funcSetSlit_WidthParameter(double dblSlit_Width)
	{
		//=====================================================================
		// Procedure Name        : funcSetSlit_WidthParameter
		// Parameters Passed     : dblSlit_Width
		// Returns               : Boolean
		// Purpose               : 
		// Description           : Set Slit Width Parameter
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 22.11.06
		// Revisions             : 
		//=====================================================================
		double dblSlitWidth;
		double dblAdjSlitWidth;

		try {
			funcSetSlit_WidthParameter = false;

			dblSlitWidth = gobjClsAAS203.funcGet_SlitWidth();

			if (dblSlit_Width > dblSlitWidth) {
				dblAdjSlitWidth = dblSlit_Width - dblSlitWidth;
				if (dblAdjSlitWidth > 0) {
					dblSlitWidth += dblAdjSlitWidth;
				}
				//dblSlitWidth += 0.1

			}

			if (dblSlit_Width < dblSlitWidth) {
				dblAdjSlitWidth = dblSlitWidth - dblSlit_Width;
				if (dblAdjSlitWidth > 0) {
					dblSlitWidth -= dblAdjSlitWidth;
				}
				//dblSlitWidth -= 0.1
			}

			if (dblSlit_Width < 0)
				dblSlitWidth = 2.0;
			if (dblSlit_Width > 2)
				dblSlitWidth = 0.0;

			gobjCommProtocol.funcSet_SlitWidth(dblSlitWidth, 0);
			mobjParameters.SlitWidth = Val(dblSlitWidth);
			funcSetSlit_WidthParameter = true;
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

	private bool funcSetSlit_WidthParameter_Ref(double dblSlit_Width)
	{
		//=====================================================================
		// Procedure Name        : funcSetSlit_WidthParameter_Ref
		// Parameters Passed     : dblSlit_Width
		// Returns               : Boolean
		// Purpose               : 
		// Description           : Set Slit Width Parameter
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 22.11.06
		// Revisions             : 
		//=====================================================================
		double dblSlitWidth;
		double dblAdjSlitWidth;

		try {
			funcSetSlit_WidthParameter_Ref = false;

			dblSlitWidth = gobjClsAAS203.funcGet_SlitWidth(1);
			//1 is for Exit Slit in Double Beam

			if (dblSlit_Width > dblSlitWidth) {
				dblAdjSlitWidth = dblSlit_Width - dblSlitWidth;
				if (dblAdjSlitWidth > 0) {
					dblSlitWidth += dblAdjSlitWidth;
				}
				//dblSlitWidth += 0.1
			}

			if (dblSlit_Width < dblSlitWidth) {
				dblAdjSlitWidth = dblSlitWidth - dblSlit_Width;
				if (dblAdjSlitWidth > 0) {
					dblSlitWidth -= dblAdjSlitWidth;
				}
				//dblSlitWidth -= 0.1
			}

			if (dblSlit_Width < 0)
				dblSlitWidth = 2.0;
			if (dblSlit_Width > 2)
				dblSlitWidth = 0.0;

			gobjCommProtocol.funcSet_SlitWidth(dblSlitWidth, 1);
			mobjParameters.SlitWidthRef = Val(dblSlitWidth);
			funcSetSlit_WidthParameter_Ref = true;
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

	private double funcSetFuelParameter(double dblFuel)
	{
		//=====================================================================
		// Procedure Name        : funcSetFuelParameter
		// Parameters Passed     : dblFuel 
		// Returns               : Double
		// Purpose               : 
		// Description           : Set Fuel Parameter
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 22.11.06
		// Revisions             : 
		//=====================================================================
		try {
			funcSetFuelParameter = false;

			TimerEnergyDisplay.Enabled = false;

			if (!(mdblFuelRatio == dblFuel)) {
				gobjClsAAS203.funcSetFuel((double)nudFuelRatio.Value);
			}

			//Call gobjCommProtocol.funcGet_NV_Pos()
			mdblFuelRatio = gobjClsAAS203.funcGet_Fuel_Ratio(true);
			if (mdblFuelRatio < 0.0) {
				//'setting some validation
				mdblFuelRatio = 0.0;
			} else {
				mdblFuelRatio = Format(mdblFuelRatio, "#0.00");
			}
			nudFuelRatio.Value = mdblFuelRatio;
			mobjParameters.FualRatio = mdblFuelRatio;
			funcSetFuelParameter = mdblFuelRatio;
			TimerEnergyDisplay.Enabled = true;
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			return 0.0;
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

	private double funcSetBurner_HeightParameter(double dblBurner_Height)
	{
		//=====================================================================
		// Procedure Name        : funcSetBurner_HeightParameter
		// Parameters Passed     : dblBurner_Height 
		// Returns               : Double
		// Purpose               : 
		// Description           : Set Burner Height Parameter
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 22.11.06
		// Revisions             : 
		//=====================================================================
		double dblBurnerHeight;
		try {
			funcSetBurner_HeightParameter = 0.0;
			//If intBurner_Height = 1 Then
			//    Call gobjClsAAS203.funcIncr_Height()
			//ElseIf intBurner_Height = -1 Then
			//    Call gobjClsAAS203.funcDecr_Height()
			//Else
			//    gobjCommProtocol.func_Get_BH_Pos()
			//End If
			//mobjParameters.BurnerHeight = gobjClsAAS203.funcReadBurnerHeight()
			//funcSetBurner_HeightParameter = gobjClsAAS203.funcReadBurnerHeight()
			TimerEnergyDisplay.Enabled = false;
			gobjClsAAS203.funcSetBHPos(FormatNumber(dblBurner_Height, 1));
			dblBhHeight = gobjClsAAS203.funcReadBurnerHeight();
			funcSetBurner_HeightParameter = dblBhHeight;
			TimerEnergyDisplay.Enabled = true;
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
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

	public bool funcOnSpect(bool BaseLine, ref System.Object lblScanStatus, ref System.Object lblOnlineWv)
	{

		//=====================================================================
		// Procedure Name        :   funcOnSpect
		// Description           :   Get the File name and path from the user
		//                           and save the spectrum file to *.spt 
		// Purpose               :   To save the channel information to the 
		//                           Spectrum file.
		// Parameters Passed     :   None.
		// Returns               :   True, if successful.
		// Parameters Affected   :   None.
		// Assumptions           :
		// Dependencies          :
		// Author                :   Gitesh, Uday
		// Created               :   Saturday, November 15, 2003 18:49
		// Revisions             :
		//=====================================================================
		//Dim ObjParameter As New Spectrum.EnergySpectrumParameter



		mobjOnlineChannel = new Spectrum.Channel(true);
		mobjEnegyChannel = new Spectrum.EnergyChannels();
		//ObjParameter = funcCloneParameter(mobjParameters)
		//mobjOnlineChannel.EnegryParameter = ObjParameter
		mobjOnlineChannel.EnegryParameter = mobjSpectrum.funcCloneESParameter(mobjParameters);
		//ObjParameter = Nothing

		if (!funcGraphPreRequisite(mobjParameters.Cal_Mode, mobjParameters.XaxisMin, mobjParameters.XaxisMax, mobjParameters.YaxisMin, mobjParameters.YaxisMax)) {
			//Call gFuncShowMessage("Error in setting spectrum parameters", "Please Check Entered Spectrum Parameters", modConstants.EnumMessageType.Information)
			return;
		}


		mobjOnlineReadings = new Spectrum.Readings();

		mblnSpectrumStarted = true;
		mblnAvoidProcessing = true;
		//RemoveHandler mnuIgnite.Click, AddressOf btnAutoIgnition_Click

		//--- Start the Spectrum analysis
		mobjController = new clsBgThread(this);
		//mobjclsBgSpectrum = New clsBgSpectrum(lblWvPos, lblOnlineWv, _
		//              mobjParameters.XaxisMax, _
		//              mobjParameters.XaxisMin, _
		//              mobjParameters.YaxisMax, _
		//              mobjParameters.YaxisMin, _
		//              mobjParameters.Cal_Mode, _
		//              mobjParameters.ScanSpeed)

		mobjclsBgSpectrum = new clsBgSpectrum(lblWvPos, lblOnlineWv, mobjParameters.XaxisMax, mobjParameters.XaxisMin, mobjParameters.YaxisMax, mobjParameters.YaxisMin, mobjParameters.Cal_Mode, mobjParameters.ScanSpeed, 0, IsRefBeamSelected);

		//'TurretOptimizationThread = New clsBgTurretOptimization(lblPMT, lblTurretPosition, lblTurretOptimisation, mdblLampCurrent, mintLampPosition, aasGraphTurretOptimisation)
		mobjController.Start(mobjclsBgSpectrum);
		funcOnSpect = true;
	}

	#Region "Save/Load Spectrum Function For Double Beam"

	//--- Save the Current Active channel to a UVSpectrum(uvs) file
	private bool funcSaveSpectrumFile_Double()
	{
		//=====================================================================
		// Procedure Name        :   funcSaveSpectrumFile
		// Description           :   Get the File name and path from the user
		//                           and save the spectrum file to *.spt 
		// Purpose               :   To save the channel information to the 
		//                           Spectrum file.
		// Parameters Passed     :   None.
		// Returns               :   True, if successful.
		// Parameters Affected   :   None.
		// Assumptions           :
		// Dependencies          :
		// Author                :   Gitesh, Uday
		// Created               :   Saturday, November 15, 2003 18:49
		// Revisions             :
		//=====================================================================
		try {
			funcSaveSpectrumFile_Double = false;
			if (mobjChannnels.item(mintChannelIndex) == null) {
				gobjMessageAdapter.ShowMessage(constSpectrumNotPresent);
				//gFuncShowMessage("Error", "Spectrum is not present for saving.", EnumMessageType.Information)
				return;
			}

			Spectrum.EnergyChannels objEnergyChannels = new Spectrum.EnergyChannels();

			//objEnergyChannels.Add(mobjChannnels.item(mintChannelIndex - 1))
			objEnergyChannels.Add(mobjChannnels.item(mintChannelIndex));

			if (gstructSettings.Enable21CFR == true) {
				if (!gfuncGetFileAuthenticationData(objEnergyChannels.DigitalSignature)) {
					return true;
				}
			} else {
				//--- This is for saving the file with login Authnetication 
				//--- when 21 cfr is off
				//If Not gfuncGetFileAuthenticationData_21CFR_OFF(objchannel.DigitalSignature) Then
				//    Return True
				//End If
			}

			Stream objStream;
			SaveFileDialog objsfdSpectrum = new SaveFileDialog();

			//--- Show the save dialog to accept the *.spt file.
			objsfdSpectrum.Filter = "Spectrum Files(*" + CONST_EnergySpectrumFileExtDB + ")|*" + CONST_EnergySpectrumFileExtDB;
			objsfdSpectrum.FilterIndex = 1;
			objsfdSpectrum.InitialDirectory = strPath.GetCurrentDirectory.ToString + "\\Energy Spectrums";
			objsfdSpectrum.RestoreDirectory = true;

			if (objsfdSpectrum.ShowDialog() == DialogResult.OK) {
				objEnergyChannels.DigitalSignature.FileName = objsfdSpectrum.FileName;
				//--- Check if file exist   
				if ((objsfdSpectrum.CheckFileExists())) {
					if (gobjMessageAdapter.ShowMessage(constSaveAs) == true) {
						//If (MessageBox.Show("DO YOU WISH TO OVERWRITE", "SAVE AS", MessageBoxButtons.YesNo) = DialogResult.Yes) Then
						if (!gfuncSerializeObjectDB(objsfdSpectrum.FileName, objEnergyChannels)) {
							gobjMessageAdapter.ShowMessage(constErrorFileSaving);
							//gFuncShowMessage("Error", "ERROR IN SAVING FILE.", EnumMessageType.Information)
						}
					} else {
						return true;
					}
				} else {
					if (!gfuncSerializeObjectDB(objsfdSpectrum.FileName, objEnergyChannels)) {
						gobjMessageAdapter.ShowMessage(constErrorFileSaving);
						//gFuncShowMessage("Error", "ERROR IN SAVING FILE.", EnumMessageType.Information)
					}


					//--- Writing to Activity Log and File Log
					if ((gstructSettings.Enable21CFR == true)) {
						long lngActivityLogID;
						lngActivityLogID = gfuncInsertActivityLog(EnumModules.Energy_Spectrum_Mode, "Spectrum File Saved");

						if ((lngActivityLogID > 0)) {
							FileInfo objFI = new FileInfo(objsfdSpectrum.FileName);
							string strXMLFileData;
							string strFileLogPath;
							string strFileName = Replace(objFI.Name, objFI.Extension, "");

							strFileName = strFileName + "_" + Format(DateTime.Now, "MM_dd_yyyy_hh_mm_ss") + objFI.Extension;

							if (!Directory.Exists(CONST_FILELOG_PATH)) {
								Directory.CreateDirectory(CONST_FILELOG_PATH);
							}

							strFileLogPath = CONST_FILELOG_PATH + "\\" + strFileName;

							//Call objclsXmlOperation.gfuncXMLSerializeObject(strFileLogPath, objchannel)
							//strXMLFileData = objclsXmlOperation.gfuncXMLFileRead(strFileLogPath)
							if (!gfuncSerializeObjectDB(strFileLogPath, objEnergyChannels)) {
								throw new Exception();
							}
							//--- Log the file 
							gfuncInsertFileLog(lngActivityLogID, objsfdSpectrum.FileName, strFileLogPath);
						}
					}
				}
			}
			objsfdSpectrum.Dispose();
			return true;

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			//---------------------------------------------------------
			return false;
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			//---------------------------------------------------------
			blnYetFileNotSave = false;
		}

	}

	//--- Load channel from spectrum(spt) file
	private bool funcLoadSpectrumFile_Double()
	{
		//=====================================================================
		// Procedure Name        :   funcLoadSpectrumFile
		// Description           :   Get the Spectrum file from the user and load the
		//                           spectrum file data to the channel object.
		// Purpose               :   To load the spectrum file in the channel object.
		// Parameters Passed     :   None.
		// Returns               :   True, if successful.
		// Parameters Affected   :   Spectrum file data is added to the channels collection.
		// Assumptions           :   None.
		// Dependencies          :   None.
		// Author                :   Gitesh, Uday
		// Created               :   Saturday, November 15, 2003 18:49
		// Revisions             :   Nilesh Shirode  feb 11 2004
		//=====================================================================
		Stream objStream;
		OpenFileDialog objofdSpectrum = new OpenFileDialog();
		try {
			funcLoadSpectrumFile_Double = false;

			objofdSpectrum.InitialDirectory = strPath.GetCurrentDirectory.ToString + "\\Energy Spectrums";
			objofdSpectrum.Filter = "Spectrum Files(*" + CONST_EnergySpectrumFileExtDB + ")|*" + CONST_EnergySpectrumFileExtDB;
			objofdSpectrum.FilterIndex = 1;
			objofdSpectrum.RestoreDirectory = true;

			ArrlstGraphCurveItem.Add(mGraphCurveItem);
			intCurveIndex = ArrlstGraphCurveItem.Count - 1;

			if (objofdSpectrum.ShowDialog() == DialogResult.OK) {
				if ((objofdSpectrum.CheckFileExists())) {
					Spectrum.EnergyChannels objchannels;
					Int16 intChannel_no;

					if (gstructSettings.Enable21CFR == true) {
						EnergyChannels objChn;
						objChn = gfuncDeSerializeObject(objofdSpectrum.FileName, EnumDeserializeObjType.EnergySpectrumDB);
						if (gfuncCheckForFileAuthentication(objChn.DigitalSignature)) {
							objchannels = objChn;
						} else {
							gobjMessageAdapter.ShowMessage(constAccessDenied);
							return false;
						}
					}

					objchannels = gfuncDeSerializeObject(objofdSpectrum.FileName, EnumDeserializeObjType.EnergySpectrumDB);
					//--- Add the new channel to the channels collection and 
					//--- accordingly save the channel file to the disk
					int intChannelIdx;
					if (objchannels.Count > 0) {
						for (intChannelIdx = 0; intChannelIdx <= objchannels.Count - 1; intChannelIdx++) {
							intChannel_no = funcAddChannelToCollection(objchannels(intChannelIdx));
							mintChannelIndex = intChannel_no;
						}
					}
					if (mobjChannnels.Count > 0) {
						mobjChannnels.item(0) = objchannels(0);
						//mobjChannnels.item(1) = objchannels(1)
						mobjEnegyChannel.Add(objchannels(0));
						//mobjEnegyChannel.Add(objchannels(1))

						mobjParameters = null;
						mobjParameters = mobjChannnels.item(0).EnegryParameter;
						funcSetParameter();
						funcClearGraph();
						intChannelIdx = 0;
						//For intChannelIdx = 0 To 1
						//funcDisplayGraph(mobjChannnels.item(intChannelIdx), mGraphCurveItem)
						funcDisplayGraphOffline(mobjChannnels.item(intChannelIdx), mGraphCurveItem);
						ArrlstGraphCurveItem.Add(mGraphCurveItem);
						intCurveIndex = ArrlstGraphCurveItem.Count - 1;
						//Next
						funcGraphPreRequisite(mobjParameters.Cal_Mode, mobjParameters.XaxisMin, mobjParameters.XaxisMax, mobjParameters.YaxisMin, mobjParameters.YaxisMax);

					} else {
						mobjParameters = null;
						mobjChannnels.Add(objchannels(0));
						//mobjChannnels.Add(objchannels(1))
						mobjParameters = mobjChannnels.item(intChannel_no).EnegryParameter;
						funcSetParameter();
						funcClearGraph();

						funcDisplayGraph(mobjChannnels.item(intChannel_no), mGraphCurveItem);
						ArrlstGraphCurveItem.Add(mGraphCurveItem);
						intCurveIndex = ArrlstGraphCurveItem.Count - 1;

						funcGraphPreRequisite(mobjParameters.Cal_Mode, mobjParameters.XaxisMin, mobjParameters.XaxisMax, mobjParameters.YaxisMin, mobjParameters.YaxisMax);

					}
					func_Enable_Disable(EnumProcesses.LoadChannel, EnumStart_End.Start_of_Process);
					Application.DoEvents();

					//subLabelDisplay(mobjChannnels.item(0))
				}
			}
			objofdSpectrum.Dispose();
			funcLoadSpectrumFile_Double = true;

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
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

	#Region "Save/Load Spectrum Function"

	//--- Save the Current Active channel to a UVSpectrum(uvs) file
	private bool funcSaveSpectrumFile()
	{
		//=====================================================================
		// Procedure Name        :   funcSaveSpectrumFile
		// Description           :   Get the File name and path from the user
		//                           and save the spectrum file to *.spt 
		// Purpose               :   To save the channel information to the 
		//                           Spectrum file.
		// Parameters Passed     :   None.
		// Returns               :   True, if successful.
		// Parameters Affected   :   None.
		// Assumptions           :
		// Dependencies          :
		// Author                :   Gitesh, Uday
		// Created               :   Saturday, November 15, 2003 18:49
		// Revisions             :
		//=====================================================================
		try {
			if (mobjChannnels.item(mintChannelIndex) == null) {
				gobjMessageAdapter.ShowMessage(constSpectrumNotPresent);
				//gFuncShowMessage("Error", "Spectrum is not present for saving.", EnumMessageType.Information)
				return;
			}

			Spectrum.Channel objchannel;

			objchannel = mobjChannnels.item(mintChannelIndex);

			if (gstructSettings.Enable21CFR == true) {
				if (!gfuncGetFileAuthenticationData(objchannel.DigitalSignature)) {
					return true;
				}
			} else {
				//--- This is for saving the file with login Authnetication 
				//--- when 21 cfr is off
				//If Not gfuncGetFileAuthenticationData_21CFR_OFF(objchannel.DigitalSignature) Then
				//    Return True
				//End If
			}

			Stream objStream;
			SaveFileDialog objsfdSpectrum = new SaveFileDialog();

			//--- Show the save dialog to accept the *.spt file.
			objsfdSpectrum.Filter = "Spectrum Files(*" + CONST_EnergySpectrumFileExt + ")|*" + CONST_EnergySpectrumFileExt;
			objsfdSpectrum.FilterIndex = 1;
			objsfdSpectrum.InitialDirectory = strPath.GetCurrentDirectory.ToString + "\\Energy Spectrums";
			objsfdSpectrum.RestoreDirectory = true;

			if (objsfdSpectrum.ShowDialog() == DialogResult.OK) {
				objchannel.DigitalSignature.FileName = objsfdSpectrum.FileName;
				//--- Check if file exist   
				if ((objsfdSpectrum.CheckFileExists())) {
					if (gobjMessageAdapter.ShowMessage(constSaveAs) == true) {
						//If (MessageBox.Show("DO YOU WISH TO OVERWRITE", "SAVE AS", MessageBoxButtons.YesNo) = DialogResult.Yes) Then
						if (!gfuncSerializeObject(objsfdSpectrum.FileName, objchannel)) {
							gobjMessageAdapter.ShowMessage(constErrorFileSaving);
							//gFuncShowMessage("Error", "ERROR IN SAVING FILE.", EnumMessageType.Information)
						}
					} else {
						return true;
					}
				} else {
					if (!gfuncSerializeObject(objsfdSpectrum.FileName, objchannel)) {
						gobjMessageAdapter.ShowMessage(constErrorFileSaving);
						//gFuncShowMessage("Error", "ERROR IN SAVING FILE.", EnumMessageType.Information)
					}
				}

				//--- Writing to Activity Log and File Log
				if ((gstructSettings.Enable21CFR == true)) {
					long lngActivityLogID;
					lngActivityLogID = gfuncInsertActivityLog(EnumModules.Energy_Spectrum_Mode, "Spectrum File Saved");

					if ((lngActivityLogID > 0)) {
						FileInfo objFI = new FileInfo(objsfdSpectrum.FileName);
						string strXMLFileData;
						string strFileLogPath;
						string strFileName = Replace(objFI.Name, objFI.Extension, "");

						strFileName = strFileName + "_" + Format(DateTime.Now, "MM_dd_yyyy_hh_mm_ss") + objFI.Extension;

						if (!Directory.Exists(CONST_FILELOG_PATH)) {
							Directory.CreateDirectory(CONST_FILELOG_PATH);
						}

						strFileLogPath = CONST_FILELOG_PATH + "\\" + strFileName;

						//Call objclsXmlOperation.gfuncXMLSerializeObject(strFileLogPath, objchannel)
						//strXMLFileData = objclsXmlOperation.gfuncXMLFileRead(strFileLogPath)
						if (!gfuncSerializeObject(strFileLogPath, objchannel)) {
							throw new Exception();
						}

						//--- Log the file 
						gfuncInsertFileLog(lngActivityLogID, objsfdSpectrum.FileName, strFileLogPath);
					}
				}

			}
			objsfdSpectrum.Dispose();

			return true;

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			//---------------------------------------------------------
			return false;
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			//---------------------------------------------------------
			blnYetFileNotSave = false;
		}

	}

	//--- Load channel from spectrum(spt) file
	private bool funcLoadSpectrumFile()
	{
		//=====================================================================
		// Procedure Name        :   funcLoadSpectrumFile
		// Description           :   Get the Spectrum file from the user and load the
		//                           spectrum file data to the channel object.
		// Purpose               :   To load the spectrum file in the channel object.
		// Parameters Passed     :   None.
		// Returns               :   True, if successful.
		// Parameters Affected   :   Spectrum file data is added to the channels collection.
		// Assumptions           :   None.
		// Dependencies          :   None.
		// Author                :   Gitesh, Uday
		// Created               :   Saturday, November 15, 2003 18:49
		// Revisions             :   Nilesh Shirode  feb 11 2004
		//=====================================================================
		Stream objStream;
		OpenFileDialog objofdSpectrum = new OpenFileDialog();
		try {
			funcLoadSpectrumFile = false;

			objofdSpectrum.InitialDirectory = strPath.GetCurrentDirectory.ToString + "\\Energy Spectrums";
			objofdSpectrum.Filter = "Spectrum Files(*" + CONST_EnergySpectrumFileExt + ")|*" + CONST_EnergySpectrumFileExt;
			objofdSpectrum.FilterIndex = 1;
			objofdSpectrum.RestoreDirectory = true;

			if (objofdSpectrum.ShowDialog() == DialogResult.OK) {
				if ((objofdSpectrum.CheckFileExists())) {
					Spectrum.Channel objchannel;
					Int16 intChannel_no;

					if (gstructSettings.Enable21CFR == true) {
						Channel objChn;
						objChn = gfuncDeSerializeObject(objofdSpectrum.FileName, EnumDeserializeObjType.EnergySpectrum);
						if (gfuncCheckForFileAuthentication(objChn.DigitalSignature)) {
							objchannel = objChn;
						} else {
							gobjMessageAdapter.ShowMessage(constAccessDenied);
							return false;
						}
					}

					objchannel = gfuncDeSerializeObject(objofdSpectrum.FileName, EnumDeserializeObjType.EnergySpectrum);
					//--- Add the new channel to the channels collection and 
					//--- accordingly save the channel file to the disk

					intChannel_no = funcAddChannelToCollection(objchannel);
					mintChannelIndex = intChannel_no;

					if (mobjChannnels.Count > 0) {
						mobjChannnels.item(0) = objchannel;
						mobjParameters = null;
						mobjParameters = mobjChannnels.item(0).EnegryParameter;
						funcSetParameter();
						funcClearGraph();

						funcDisplayGraph(mobjChannnels.item(mintChannelIndex), mGraphCurveItem);
						ArrlstGraphCurveItem.Add(mGraphCurveItem);

						intCurveIndex = ArrlstGraphCurveItem.Count - 1;

						funcGraphPreRequisite(mobjParameters.Cal_Mode, mobjParameters.XaxisMin, mobjParameters.XaxisMax, mobjParameters.YaxisMin, mobjParameters.YaxisMax);
					} else {
						mobjParameters = null;
						mobjChannnels.Add(objchannel);
						mobjParameters = mobjChannnels.item(intChannel_no).EnegryParameter;
						funcSetParameter();
						funcClearGraph();

						funcDisplayGraph(mobjChannnels.item(intChannel_no), mGraphCurveItem);
						ArrlstGraphCurveItem.Add(mGraphCurveItem);
						intCurveIndex = ArrlstGraphCurveItem.Count - 1;

						funcGraphPreRequisite(mobjParameters.Cal_Mode, mobjParameters.XaxisMin, mobjParameters.XaxisMax, mobjParameters.YaxisMin, mobjParameters.YaxisMax);

					}
					func_Enable_Disable(EnumProcesses.LoadChannel, EnumStart_End.Start_of_Process);
					Application.DoEvents();

					//subLabelDisplay(mobjChannnels.item(0))
				}
			}
			objofdSpectrum.Dispose();
			funcLoadSpectrumFile = true;

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
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

	private bool funcSetFrmEditValue(ref double dblReturnValue, string strWinTitle, double dblMinValue, double dblMaxValue)
	{
		//=====================================================================
		// Procedure Name        : subSetFrmEditValue
		// Parameters Passed     : 
		// Returns               : 
		// Purpose               : 
		//                         
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : Apr 01, 2007 4:00 pm
		// Revisions             : 1
		//=====================================================================
		double InputValue;
		int intValue;
		try {
			mobjfrmEditValues = new frmEditValues();
			mobjfrmEditValues.LabelText = strWinTitle;
			mobjfrmEditValues.txtValue.Visible = true;
			switch (strWinTitle) {
				case "PMT":
				case "D2 Current":
					//mobjfrmEditValues.txtValue.ValidationType = NumberValidator.NumberValidator.Validations.IntegerOnly
					intValue = (int)dblReturnValue;
					dblReturnValue = intValue;
				default:
				//mobjfrmEditValues.txtValue.ValidationType = NumberValidator.NumberValidator.Validations.DoubleOnly
			}

			//mobjfrmEditValues.txtValue.RangeValidation = True
			//mobjfrmEditValues.txtValue.DigitsAfterDecimalPoint = 2
			//mobjfrmEditValues.txtValue.MaxLength = 4
			//mobjfrmEditValues.txtValue.MinimumRange = dblMinValue
			//mobjfrmEditValues.txtValue.MaximumRange = dblMaxValue
			mobjfrmEditValues.txtValue.Text = dblReturnValue;
			mobjfrmEditValues.txtValue.Focus();
			mobjfrmEditValues.txtValue.SelectAll();
			if (mobjfrmEditValues.ShowDialog == DialogResult.Cancel) {
				Application.DoEvents();
				mobjfrmEditValues.Dispose();
				return false;
			}

			if (IsNumeric(mobjfrmEditValues.txtValue.Text)) {
				InputValue = mobjfrmEditValues.txtValue.Text;
				if (InputValue < dblMinValue) {
					InputValue = dblMinValue;
				} else if (InputValue > dblMaxValue) {
					InputValue = dblMaxValue;
				} else {
					InputValue = mobjfrmEditValues.txtValue.Text;
				}
			} else {
				InputValue = dblMinValue;
			}

			//If InputValue < dblMinValue Or InputValue > dblMaxValue Then
			//    gobjMessageAdapter.ShowMessage(constInvalidRange)   'constPMTRange
			//    'MsgBox("PMT value should be between 0 and 1000")
			//    Exit Function
			//End If

			dblReturnValue = InputValue;
			Application.DoEvents();

			//mobjfrmEditValues.txtAvgFactor.Text = CInt()
			//txtAvgFactor.Refresh()
			//mobjfrmEditValues.Dispose()
			//gobjInst.Average = CInt(InputValue)
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

	private void btnIgnite_Click(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        :   btnIgnite_Click
		// Description           :   
		// Purpose               :   
		// Parameters Passed     :   
		// Returns               :   
		// Parameters Affected   :   
		// Assumptions           :   
		// Dependencies          :   None.
		// Author                :   Sachin Dokhale
		// Created               :   04.05.07
		// Revisions             :
		//=====================================================================
		if (mblnAvoidProcessing == true) {
			return;
		}
		try {
			mblnAvoidProcessing = true;
			TimerEnergyDisplay.Enabled = false;
			Application.DoEvents();
			if (!IsNothing(gobjMain)) {
				//MsgBox("frmEnergyDB")
				//gobjMain.AutoIgnition()
				gobjCommProtocol.mobjCommdll.subTime_Delay(100);
				gobjClsAAS203.funcIgnite(true);
				funcGetInstParameter();
			}
			TimerEnergyDisplay.Enabled = true;
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

	private void btnExtinguish_Click(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        :   btnExtinguish_Click
		// Description           :   
		// Purpose               :   
		// Parameters Passed     :   
		// Returns               :   
		// Parameters Affected   :   
		// Assumptions           :   
		// Dependencies          :   None.
		// Author                :   Sachin Dokhale
		// Created               :   04.05.07
		// Revisions             :
		//=====================================================================
		try {
			if (mblnAvoidProcessing == true) {
				return;
			}
			mblnAvoidProcessing = true;
			TimerEnergyDisplay.Enabled = false;
			if (!IsNothing(gobjMain)) {
				//MsgBox("frmStatus")
				//gobjMain.Extinguish()
				gobjCommProtocol.mobjCommdll.subTime_Delay(100);
				gobjClsAAS203.funcIgnite(false);
				funcGetInstParameter();
			}
			TimerEnergyDisplay.Enabled = true;
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

	private void  // ERROR: Handles clauses are not supported in C#
btnSample_CheckedChanged(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        :   btnSample_CheckedChanged
		// Description           :   
		// Purpose               :   
		// Parameters Passed     :   
		// Returns               :   
		// Parameters Affected   :   
		// Assumptions           :   
		// Dependencies          :   None.
		// Author                :   Sachin Dokhale
		// Created               :   04.05.07
		// Revisions             :
		//=====================================================================
		if (btnSample.Checked == true) {
			IsRefBeamSelected = false;
		} else {
			IsRefBeamSelected = true;
		}
	}

	private void btnN2OIgnite_Click(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        :   btnN2OIgnite_Click
		// Description           :   to handel the btnN2OIgnite_Click click event.
		// Purpose               :   
		// Parameters Passed     :   
		// Returns               :   
		// Parameters Affected   :   
		// Assumptions           :   
		// Dependencies          :   None.
		// Author                :   Sachin Dokhale
		// Created               :   04.05.07
		// Revisions             :
		//=====================================================================
		//'this is used for N2O ignition
		if (mblnAvoidProcessing == true) {
			return;
		}
		try {
			mblnAvoidProcessing = true;
			TimerEnergyDisplay.Enabled = false;
			gobjCommProtocol.mobjCommdll.subTime_Delay(100);
			//'delay
			gobjCommProtocol.funcSwitchOver();
			//'function for switching to N2O flame
			funcGetInstParameter();
			//'get a current instrument status after switching to N2O flame
			TimerEnergyDisplay.Enabled = true;
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
			TimerEnergyDisplay.Enabled = false;
			//If Not gstructSettings.AppMode = EnumAppMode.DemoMode Then
			if (!((gstructSettings.AppMode == EnumAppMode.DemoMode) | (gstructSettings.AppMode == EnumAppMode.DemoMode_201) | (gstructSettings.AppMode == EnumAppMode.DemoMode_203D))) {
				Application.DoEvents();
				gobjCommProtocol.mobjCommdll.subTime_Delay(50);
				//---switch over to N2O flame
				gobjClsAAS203.ReInitInstParameters();
				funcGetInstParameter();
			} else {
				Application.DoEvents();
			}
			TimerEnergyDisplay.Enabled = true;
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
			TimerEnergyDisplay.Enabled = false;
			//If Not gstructSettings.AppMode = EnumAppMode.DemoMode Then
			if (!((gstructSettings.AppMode == EnumAppMode.DemoMode) | (gstructSettings.AppMode == EnumAppMode.DemoMode_201) | (gstructSettings.AppMode == EnumAppMode.DemoMode_203D))) {
				Application.DoEvents();
				gobjCommProtocol.mobjCommdll.subTime_Delay(50);
				gobjClsAAS203.funcInstReset();
			} else {
				//Call gobjMessageAdapter.ShowMessage("Alt - R", "Alt - R")
				Application.DoEvents();
			}
			TimerEnergyDisplay.Enabled = true;
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
MenuBarEnergySpectrumMode_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
	{
		//=====================================================================
		// Procedure Name        : MenuBarEnergySpectrumMode_KeyUp
		// Parameters Passed     : Object, EventArgs
		// Returns               : None
		// Purpose               : Short-cuts should be work from menu bar
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
			if (e.Alt == true) {
				switch (e.KeyCode) {
					case Keys.I:
						btnIgnite_Click(sender, e);
					case Keys.C:
						btnN2OIgnite_Click(sender, e);
					case Keys.E:
						btnExtinguish_Click(sender, e);
					case Keys.D:
						//Call gobjMainService.funcAltDelete()
						btnDelete_Click(sender, e);
					case Keys.R:
						btnR_Click(sender, e);

					case Keys.Q:
				}
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
			//---------------------------------------------------------
		}
	}

	private void DisableButtonsForBurnerHeight()
	{
		//=====================================================================
		// Procedure Name        :   DisableButtonsForBurnerHeight
		// Description           :   
		// Purpose               :   
		// Parameters Passed     :   
		// Returns               :   
		// Parameters Affected   :   
		// Assumptions           :   
		// Dependencies          :   None.
		// Author                :   Sachin Dokhale
		// Created               :   04.05.07
		// Revisions             :
		//=====================================================================
		btnClearSpectrum.Enabled = false;
		mnuClearSpectrum.Enabled = false;
		tlbbtnClearSpectrum.Enabled = false;

		btnReturn.Enabled = false;
		mnuExit.Enabled = false;
		tlbbtnReturn.Enabled = false;

		btnStart.Enabled = false;
		mnuStart.Enabled = false;
		tlbbtnStart.Enabled = false;

		nudD2Cur.Enabled = false;
		nudPMT.Enabled = false;
		nudSlit.Enabled = false;
		cmbSpeed.Enabled = false;
		cmbModes.Enabled = false;
		nudBurnerHeight.Enabled = false;
		nudFuelRatio.Enabled = false;
		nudHCLCur.Enabled = false;
		nudPMT_Ref.Enabled = false;
		//For Double Beam
		nudSlit_Ref.Enabled = false;
		//For Double Beam

		btnLampParameters.Enabled = false;
		tlbbtnLampParameters.Enabled = false;
		mnuLampParameters.Enabled = false;

		cmdChangeScale.Enabled = false;
		tlbbtnChangeScale.Enabled = false;
		mnuChangeScale.Enabled = false;

		mnuSaveSpectrumFile.Enabled = false;
		tlbbtnSaveSpectrumFile.Enabled = false;

		mnuPeakPick.Enabled = false;
		tlbbtnPeakPick.Enabled = false;

		mnuPositionToMaxima.Enabled = false;
		tlbbtnPositionToMaxima.Enabled = false;

		mnuSmooth.Enabled = false;
		tlbbtnSmooth.Enabled = false;

		mnuLoadSpectrunFile.Enabled = false;
		tlbbtnLoadspectrumFile.Enabled = false;

		mnuContiniousTimeScan.Enabled = false;
		tlbbtnContiniousTimeScan.Enabled = false;

		mnuParameters.Enabled = false;
		tlbbtnParameters.Enabled = false;

		mnuPositionToMaxima.Enabled = false;
		tlbbtnPositionToMaxima.Enabled = false;
		//Added By Pankaj 21 May 07
		mnuLampParameters.Enabled = false;
		tlbbtnLampParameters.Enabled = false;
		btnLampParameters.Enabled = false;

		btnClearSpectrum.Enabled = false;
		mnuClearSpectrum.Enabled = false;
		tlbbtnClearSpectrum.Enabled = false;

		tlbbtnPrintGraph.Enabled = false;
		mnuPrintGraph.Enabled = false;
	}

	private void EnableButtonsForBurnerHeight()
	{
		//=====================================================================
		// Procedure Name        :   EnableButtonsForBurnerHeight
		// Description           :   
		// Purpose               :   
		// Parameters Passed     :   
		// Returns               :   
		// Parameters Affected   :   
		// Assumptions           :   
		// Dependencies          :   None.
		// Author                :   Sachin Dokhale
		// Created               :   04.05.07
		// Revisions             :
		//=====================================================================
		btnClearSpectrum.Enabled = true;
		mnuClearSpectrum.Enabled = true;
		tlbbtnClearSpectrum.Enabled = true;

		btnReturn.Enabled = true;
		mnuExit.Enabled = true;
		tlbbtnReturn.Enabled = true;

		btnStart.Enabled = true;
		mnuStart.Enabled = true;
		tlbbtnStart.Enabled = true;

		nudD2Cur.Enabled = true;
		nudPMT.Enabled = true;
		nudSlit.Enabled = true;
		cmbSpeed.Enabled = true;
		cmbModes.Enabled = true;
		nudBurnerHeight.Enabled = true;
		nudFuelRatio.Enabled = true;
		nudHCLCur.Enabled = true;
		nudPMT_Ref.Enabled = true;
		//For Double Beam
		//nudSlit_Ref.Enabled = True 'For Double Beam'by Pankaj on 18.1.08


		mnuLampParameters.Enabled = true;
		btnLampParameters.Enabled = true;
		tlbbtnLampParameters.Enabled = true;

		cmdChangeScale.Enabled = true;
		tlbbtnChangeScale.Enabled = true;
		mnuChangeScale.Enabled = true;

		tlbbtnPrintGraph.Enabled = true;
		mnuPrintGraph.Enabled = true;

		tlbbtnLoadspectrumFile.Enabled = true;
		mnuLoadSpectrunFile.Enabled = true;

		tlbbtnContiniousTimeScan.Enabled = true;
		mnuContiniousTimeScan.Enabled = true;
	}

	private void  // ERROR: Handles clauses are not supported in C#
frmEnergySpectrumDBMode_Activated(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        :   frmEnergySpectrumDBMode_Activated
		// Description           :   
		// Purpose               :   
		// Parameters Passed     :   
		// Returns               :   
		// Parameters Affected   :   
		// Assumptions           :   
		// Dependencies          :   None.
		// Author                :   Sachin Dokhale
		// Created               :   04.05.07
		// Revisions             :
		//=====================================================================
		try {
			if (blnActivateStartEnergySpectrum == false) {
				funcSetDefaultParameter();
				nudD2Cur.Visible = true;
				nudPMT.Visible = true;
				nudPMT_Ref.Visible = true;
				nudSlit.Visible = true;
				nudSlit_Ref.Visible = true;
				nudHCLCur.Visible = true;
				nudBurnerHeight.Visible = true;
				nudFuelRatio.Visible = true;
				blnActivateStartEnergySpectrum = true;
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

	private bool FuncIncrDecrFuel(double dblFuelRatio)
	{
		//=====================================================================
		// Procedure Name        :   FuncIncrDecrFuel
		// Description           :   To call the function according to value 
		//                           editor button clicked
		// Purpose               :   
		// Parameters Passed     :   
		// Returns               :   
		// Parameters Affected   :   
		// Assumptions           :   
		// Dependencies          :   None.
		// Author                :   Deepak Bhati
		// Created               :   03.02.08
		// Revisions             :
		//=====================================================================
		int intNVStep;
		try {
			TimerEnergyDisplay.Enabled = false;
			if (!(mdblFuelRatio == dblFuelRatio)) {

				if (gobjInst.Aaf == true | gobjInst.N2of == true) {
					switch (nudFuelRatio.ButtonClicked) {
						case ValueEditor.ValueEditor.EnumValueEditorButtons.MainButton:
							gobjClsAAS203.funcSetFuel((double)nudFuelRatio.Value);
						case ValueEditor.ValueEditor.EnumValueEditorButtons.UpButton:
							//---to increase fuel
							gobjClsAAS203.funcIncr_Fuel();
						case ValueEditor.ValueEditor.EnumValueEditorButtons.DownButton:
							//---to decrease fuel
							gobjClsAAS203.funcDecr_Fuel();
					}

				}
			}

			mdblFuelRatio = gobjClsAAS203.funcGet_Fuel_Ratio(true);
			if (mdblFuelRatio < 0.0) {
				mdblFuelRatio = 0.0;
			} else {
				mdblFuelRatio = Format(mdblFuelRatio, "#0.00");
			}
			nudFuelRatio.Value = mdblFuelRatio;
			mobjParameters.FualRatio = mdblFuelRatio;
			nudFuelRatio.Refresh();
			TimerEnergyDisplay.Enabled = true;
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
TimerEnergyDisplay_Tick(System.Object sender, System.EventArgs e)
	{
		int intMV;
		try {
			Application.DoEvents();
			//10.12.07
			if (gobjCommProtocol.mobjCommdll.IsInCommu == true) {
				//Return False
				return;
			}
			switch (gintInstrumentBeamType) {
				case AAS203Library.Instrument.enumInstrumentBeamType.SingleBeam:
					gobjCommProtocol.funcReadADCFilter(10, intMV);
				case AAS203Library.Instrument.enumInstrumentBeamType.DoubleBeam:
					if (blnIsRefBeamSelected == true) {
						gobjCommProtocol.funcReadADCFilter_ReferenceBeam(10, intMV);
					} else {
						gobjCommProtocol.funcReadADCFilter(10, intMV);
					}
			}
			lblYValue.Text = mYValueLable + FormatNumber(gFuncGetADConvertedToCurMode(intMV), 2);
			lblYValue.Refresh();
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
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

	#Region " Code for Enable and Disable"

	private object func_Enable_Disable(int intProcess, int intStart_End)
	{
		//=====================================================================
		// Procedure Name        :   func_Enable_Disable
		// Description           :   
		// Purpose               :   
		// Parameters Passed     :   
		// Returns               :   
		// Parameters Affected   :   
		// Assumptions           :   
		// Dependencies          :   None.
		// Author                :   Sachin Dokhale
		// Created               :   04.05.07
		// Revisions             :
		//=====================================================================

		try {
			switch (intProcess) {
				case EnumProcesses.FormInitialize:
				case EnumProcesses.EditSystemParamters:
					switch (intStart_End) {
						case EnumStart_End.Start_of_Process:

							subAll_Menus_Enable();

							btnStart.Enabled = true;
							mnuStart.Enabled = true;
							tlbbtnStart.Enabled = true;

							btnClearSpectrum.Enabled = true;
							mnuClearSpectrum.Enabled = true;
							tlbbtnClearSpectrum.Enabled = true;

							btnReturn.Enabled = true;
							mnuExit.Enabled = true;
							tlbbtnReturn.Enabled = true;

							nudD2Cur.Enabled = true;
							nudPMT.Enabled = true;
							if (!(gintInstrumentBeamType == AAS203Library.Instrument.enumInstrumentBeamType.SingleBeam)) {
								nudPMT_Ref.Enabled = true;
							} else {
								nudPMT_Ref.Enabled = false;
							}

							nudSlit.Enabled = true;
							//nudSlit_Ref.Enabled = True'by Pankaj on 18.1.08
							cmbSpeed.Enabled = true;
							cmbModes.Enabled = true;
							nudBurnerHeight.Enabled = true;
							nudFuelRatio.Enabled = true;
							nudHCLCur.Enabled = true;

							mnuLampParameters.Enabled = true;
							btnLampParameters.Enabled = true;
							tlbbtnLampParameters.Enabled = true;

							if (mintChannelIndex > -1) {
								mnuParameters.Enabled = true;
								tlbbtnParameters.Enabled = true;

								mnuSaveSpectrumFile.Enabled = true;
								tlbbtnSaveSpectrumFile.Enabled = true;

								mnuPeakPick.Enabled = true;
								tlbbtnPeakPick.Enabled = true;

								mnuPositionToMaxima.Enabled = true;
								tlbbtnPositionToMaxima.Enabled = true;

								mnuSmooth.Enabled = true;
								tlbbtnSmooth.Enabled = true;
							} else {
								mnuParameters.Enabled = false;
								tlbbtnParameters.Enabled = false;

								mnuSaveSpectrumFile.Enabled = false;
								tlbbtnSaveSpectrumFile.Enabled = false;

								mnuPeakPick.Enabled = false;
								tlbbtnPeakPick.Enabled = false;

								mnuPositionToMaxima.Enabled = false;
								tlbbtnPositionToMaxima.Enabled = false;

								mnuSmooth.Enabled = false;
								tlbbtnSmooth.Enabled = false;

							}
						//tlbrSpectrum.Buttons.Item(EnumToolBarButtons.ReturnToSelectModes).ImageIndex = EnumToolBarImages.ReturnToSelectModesEnabled
						//tlbrSpectrum.Buttons.Item(EnumToolBarButtons.Parameter).ImageIndex = EnumToolBarImages.ParameterEnabled
						//tlbrSpectrum.Buttons.Item(EnumToolBarButtons.StopScan).ImageIndex = EnumToolBarImages.StopScanDisabled
						//tlbrSpectrum.Buttons.Item(EnumToolBarButtons.Clear).ImageIndex = EnumToolBarImages.ClearEnabled

						//If gstructConfigurartionSetting.DemoMode = 1 Then
						//    mnuLamp.Enabled = False
						//    tlbrSpectrum.Buttons.Item(EnumToolBarButtons.Baseline).ImageIndex = EnumToolBarImages.BaselineDisabled
						//    tlbrSpectrum.Buttons.Item(EnumToolBarButtons.Autozero).ImageIndex = EnumToolBarImages.AutozeroDisabled
						//    tlbrSpectrum.Buttons.Item(EnumToolBarButtons.StartScan).ImageIndex = EnumToolBarImages.StartScanDisabled
						//Else
						//    tlbrSpectrum.Buttons.Item(EnumToolBarButtons.Baseline).ImageIndex = EnumToolBarImages.BaselineEnabled
						//    tlbrSpectrum.Buttons.Item(EnumToolBarButtons.Autozero).ImageIndex = EnumToolBarImages.AutozeroEnabled
						//    tlbrSpectrum.Buttons.Item(EnumToolBarButtons.StartScan).ImageIndex = EnumToolBarImages.StartScanEnabled
						//End If

						//If mobjChannnels.Count > 0 Then
						//    tlbrSpectrum.Buttons.Item(EnumToolBarButtons.ClearAndRedraw).ImageIndex = EnumToolBarImages.ClearAndRedrawEnabled
						//    tlbrSpectrum.Buttons.Item(EnumToolBarButtons.Print).ImageIndex = EnumToolBarImages.PrintEnabled
						//Else
						//    mnuDataProcessing.Enabled = False
						//    mnuManipulate.Enabled = False
						//    tlbrSpectrum.Buttons.Item(EnumToolBarButtons.ClearAndRedraw).ImageIndex = EnumToolBarImages.ClearAndRedrawDisabled
						//    tlbrSpectrum.Buttons.Item(EnumToolBarButtons.Print).ImageIndex = EnumToolBarImages.PrintDisabled
						//End If


						case EnumStart_End.End_of_Process:
					}
				case EnumProcesses.LoadParameters:
					//2
					switch (intStart_End) {
						case EnumStart_End.Start_of_Process:
							if (mintChannelIndex > -1) {
								mnuParameters.Enabled = true;
								tlbbtnParameters.Enabled = true;

								mnuSaveSpectrumFile.Enabled = true;
								tlbbtnSaveSpectrumFile.Enabled = true;

								mnuPeakPick.Enabled = true;
								tlbbtnPeakPick.Enabled = true;

								mnuPositionToMaxima.Enabled = true;
								tlbbtnPositionToMaxima.Enabled = true;

								tlbbtnPrintGraph.Enabled = true;
								//Added by Pankaj on 6 Sep 07
								mnuPrintGraph.Enabled = true;
								//Added by Pankaj on 6 Sep 07

								mnuSmooth.Enabled = true;
								tlbbtnSmooth.Enabled = true;
							} else {
								mnuParameters.Enabled = false;
								tlbbtnParameters.Enabled = false;

								mnuSaveSpectrumFile.Enabled = false;
								tlbbtnSaveSpectrumFile.Enabled = false;

								mnuPeakPick.Enabled = false;
								tlbbtnPeakPick.Enabled = false;

								mnuPositionToMaxima.Enabled = false;
								tlbbtnPositionToMaxima.Enabled = false;

								mnuSmooth.Enabled = false;
								tlbbtnSmooth.Enabled = false;

							}
						case EnumStart_End.End_of_Process:

					}
				case EnumProcesses.EditParameters:
					//3   
					switch (intStart_End) {

						case EnumStart_End.Start_of_Process:
						case EnumStart_End.End_of_Process:

					}
				case EnumProcesses.SaveParameters:
					//4   
					switch (intStart_End) {

						case EnumStart_End.Start_of_Process:
						case EnumStart_End.End_of_Process:

					}
				case EnumProcesses.StartScan:
					//15  EnumProcesses.StartScan
					switch (intStart_End) {
						case EnumStart_End.Start_of_Process:
							subAll_Menus_Disable();

							btnClearSpectrum.Enabled = false;
							mnuClearSpectrum.Enabled = false;
							tlbbtnClearSpectrum.Enabled = false;

							btnReturn.Enabled = false;
							mnuExit.Enabled = false;
							tlbbtnReturn.Enabled = false;

							//If m_blnBaseline = True Then
							//    btnBaseLine.Text = "&Stop"
							//    btnStart.Enabled = False
							//    btnBaseLine.Enabled = True
							//Else
							//    btnStart.Text = "&Stop"
							//    btnStart.Enabled = True
							//    btnBaseLine.Enabled = False
							//End If

							//btnStart.Enabled = False
							btnStart.Text = "&Stop";
							btnStart.Image = Image.FromFile(Application.StartupPath + "\\Images\\cancel_1.ico");
							btnStart.Refresh();
							//Added By Pankaj 22 May07
							mnuStart.Enabled = true;
							tlbbtnStart.Enabled = true;
							btnStart.Enabled = true;

							mnuStart.Text = "&Stop";
							mnuStart.Image = Image.FromFile(Application.StartupPath + "\\Images\\cancel_1.ico");

							tlbbtnStart.Text = "&Stop";
							tlbbtnStart.Image = Image.FromFile(Application.StartupPath + "\\Images\\cancel_1.ico");

							//nudD2Cur.Enabled = False
							//nudPMT.Enabled = False

							//nudPMT_Ref.Enabled = False

							//nudSlit.Enabled = False
							//nudSlit_Ref.Enabled = False
							cmbSpeed.Enabled = false;
							cmbModes.Enabled = false;
							nudBurnerHeight.Enabled = false;
							nudFuelRatio.Enabled = false;
							//nudHCLCur.Enabled = False

							btnLampParameters.Enabled = false;
							tlbbtnLampParameters.Enabled = false;
							mnuLampParameters.Enabled = false;

							cmdChangeScale.Enabled = false;
							tlbbtnChangeScale.Enabled = false;
							mnuChangeScale.Enabled = false;

							mnuSaveSpectrumFile.Enabled = false;
							tlbbtnSaveSpectrumFile.Enabled = false;

							mnuPeakPick.Enabled = false;
							tlbbtnPeakPick.Enabled = false;

							mnuPositionToMaxima.Enabled = false;
							tlbbtnPositionToMaxima.Enabled = false;

							mnuSmooth.Enabled = false;
							tlbbtnSmooth.Enabled = false;

							mnuLoadSpectrunFile.Enabled = false;
							tlbbtnLoadspectrumFile.Enabled = false;

							mnuContiniousTimeScan.Enabled = false;
							tlbbtnContiniousTimeScan.Enabled = false;

							mnuParameters.Enabled = false;
							tlbbtnParameters.Enabled = false;

							mnuPositionToMaxima.Enabled = false;
							tlbbtnPositionToMaxima.Enabled = false;
							//Added By Pankaj on 22 May 07
							//mnuStart.Enabled = False
							mnuLampParameters.Enabled = false;
							tlbbtnLampParameters.Enabled = false;
							btnLampParameters.Enabled = false;

							btnClearSpectrum.Enabled = false;
							mnuClearSpectrum.Enabled = false;
							tlbbtnClearSpectrum.Enabled = false;

							tlbbtnPrintGraph.Enabled = false;

							mnuPrintGraph.Enabled = false;
						//-----
						//NumUpDwn.Enabled = False
						//btnNumUpDwn_Dwn.Enabled = False
						//btnNumUpDwn_Up.Enabled = False

						//tlbrSpectrum.Buttons.Item(EnumToolBarButtons.ReturnToSelectModes).ImageIndex = EnumToolBarImages.ReturnToSelectModesDisabled
						//tlbrSpectrum.Buttons.Item(EnumToolBarButtons.Parameter).ImageIndex = EnumToolBarImages.ParameterDisabled
						//tlbrSpectrum.Buttons.Item(EnumToolBarButtons.StopScan).ImageIndex = EnumToolBarImages.StopScanDisabled
						//tlbrSpectrum.Buttons.Item(EnumToolBarButtons.Clear).ImageIndex = EnumToolBarImages.ClearDisabled
						//tlbrSpectrum.Buttons.Item(EnumToolBarButtons.Baseline).ImageIndex = EnumToolBarImages.BaselineDisabled
						//tlbrSpectrum.Buttons.Item(EnumToolBarButtons.Autozero).ImageIndex = EnumToolBarImages.AutozeroDisabled
						//tlbrSpectrum.Buttons.Item(EnumToolBarButtons.StartScan).ImageIndex = EnumToolBarImages.StartScanDisabled
						//tlbrSpectrum.Buttons.Item(EnumToolBarButtons.ClearAndRedraw).ImageIndex = EnumToolBarImages.ClearAndRedrawDisabled
						//tlbrSpectrum.Buttons.Item(EnumToolBarButtons.Print).ImageIndex = EnumToolBarImages.PrintDisabled

						case EnumStart_End.End_of_Process:
							if (gblnSpectrumTerminated == false) {
								subAll_Menus_Enable();

								btnClearSpectrum.Enabled = true;
								mnuClearSpectrum.Enabled = true;
								tlbbtnClearSpectrum.Enabled = true;

								btnReturn.Enabled = true;
								mnuExit.Enabled = true;
								tlbbtnReturn.Enabled = true;

								btnStart.Text = "&Start";
								btnStart.Image = Image.FromFile(Application.StartupPath + "\\Images\\Start.ico");

								btnStart.Refresh();
								nudD2Cur.Enabled = true;
								nudPMT.Enabled = true;
								if (!(gintInstrumentBeamType == AAS203Library.Instrument.enumInstrumentBeamType.SingleBeam)) {
									nudPMT_Ref.Enabled = true;
								} else {
									nudPMT_Ref.Enabled = false;
								}

								btnStart.Enabled = true;
								mnuStart.Enabled = true;
								tlbbtnStart.Enabled = true;

								nudSlit.Enabled = true;
								//nudSlit_Ref.Enabled = True'by Pankaj on 18.1.08
								cmbSpeed.Enabled = true;
								cmbModes.Enabled = true;
								nudBurnerHeight.Enabled = true;
								nudFuelRatio.Enabled = true;
								nudHCLCur.Enabled = true;

								mnuLampParameters.Enabled = true;
								btnLampParameters.Enabled = true;
								tlbbtnLampParameters.Enabled = true;

								cmdChangeScale.Enabled = true;
								tlbbtnChangeScale.Enabled = true;
								mnuChangeScale.Enabled = true;
							}
							//btnReturn.Enabled = True
							mnuSaveSpectrumFile.Enabled = true;
							tlbbtnSaveSpectrumFile.Enabled = true;

							mnuPeakPick.Enabled = true;
							tlbbtnPeakPick.Enabled = true;

							mnuPositionToMaxima.Enabled = true;
							tlbbtnPositionToMaxima.Enabled = true;

							mnuSmooth.Enabled = true;
							tlbbtnSmooth.Enabled = true;

							mnuLoadSpectrunFile.Enabled = true;
							tlbbtnLoadspectrumFile.Enabled = true;

							mnuContiniousTimeScan.Enabled = true;
							tlbbtnContiniousTimeScan.Enabled = true;

							mnuParameters.Enabled = true;
							tlbbtnParameters.Enabled = true;
							//Added By Pankaj on 22 May 07
							mnuStart.Enabled = true;
							tlbbtnStart.Enabled = true;
							btnStart.Enabled = true;

							mnuStart.Text = "&Start";
							mnuStart.Image = Image.FromFile(Application.StartupPath + "\\Images\\Start.ico");
							tlbbtnStart.Text = "&Start";
							tlbbtnStart.Image = Image.FromFile(Application.StartupPath + "\\Images\\Start.ico");

							mnuLampParameters.Enabled = true;
							tlbbtnLampParameters.Enabled = true;
							btnLampParameters.Enabled = true;

							mnuChangeScale.Enabled = true;
							tlbbtnChangeScale.Enabled = true;
							cmdChangeScale.Enabled = true;

							mnuClearSpectrum.Enabled = true;
							btnClearSpectrum.Enabled = true;
							tlbbtnClearSpectrum.Enabled = true;
							mnuPrintGraph.Enabled = true;
							//Added by pankaj on 6 sep 07
							//Added by pankaj on 6 sep 07
							tlbbtnPrintGraph.Enabled = true;
						//-----
						case EnumStart_End.Process_Running:
						//tlbrSpectrum.Buttons.Item(EnumToolBarButtons.StopScan).ImageIndex = EnumToolBarImages.StopScanEnabled
						//If gstructApplicationSessionState.intInstrument_Group = EnumInstrumentGroup.Initialize_2600_2700 Then
						//    tlbrSpectrum.Buttons.Item(EnumToolBarButtons.StopScan).ImageIndex = EnumToolBarImages.StopScanEnabled
						//ElseIf gstructApplicationSessionState.intInstrument_Group = EnumInstrumentGroup.Initialize_2100_2200_2300 Then
						//    tlbrSpectrum.Buttons.Item(EnumToolBarButtons.StopScan).ImageIndex = EnumToolBarImages.StopScanDisabled
						//End If

						case EnumStart_End.Process_Waiting:
						//--- commented to enable the stop button
						//---- While Repeat scan
						//tlbrSpectrum.Buttons.Item(EnumToolBarButtons.StopScan).ImageIndex = EnumToolBarImages.StopScanDisabled

					}
				case EnumProcesses.Clear:
					//20 
					switch (intStart_End) {

						case EnumStart_End.Start_of_Process:
						case EnumStart_End.End_of_Process:
							subAll_Menus_Enable();
							mnuDataProcessing.Enabled = false;
						//mnuManipulate.Enabled = False

						//tlbrSpectrum.Buttons.Item(EnumToolBarButtons.ReturnToSelectModes).ImageIndex = EnumToolBarImages.ReturnToSelectModesEnabled
						//tlbrSpectrum.Buttons.Item(EnumToolBarButtons.Parameter).ImageIndex = EnumToolBarImages.ParameterEnabled
						//tlbrSpectrum.Buttons.Item(EnumToolBarButtons.StopScan).ImageIndex = EnumToolBarImages.StopScanDisabled
						//tlbrSpectrum.Buttons.Item(EnumToolBarButtons.Clear).ImageIndex = EnumToolBarImages.ClearEnabled
						// Get Confirmed
						// Bt Sachin V. Dokhale
						//If gstructConfigurartionSetting.DemoMode = 1 Then   ' Or structFlag.blnNone = True
						//mnuLamp.Enabled = False
						//tlbrSpectrum.Buttons.Item(EnumToolBarButtons.Baseline).ImageIndex = EnumToolBarImages.BaselineDisabled
						//tlbrSpectrum.Buttons.Item(EnumToolBarButtons.Autozero).ImageIndex = EnumToolBarImages.AutozeroDisabled
						//tlbrSpectrum.Buttons.Item(EnumToolBarButtons.StartScan).ImageIndex = EnumToolBarImages.StartScanDisabled
						//Else
						//tlbrSpectrum.Buttons.Item(EnumToolBarButtons.Baseline).ImageIndex = EnumToolBarImages.BaselineEnabled
						//tlbrSpectrum.Buttons.Item(EnumToolBarButtons.Autozero).ImageIndex = EnumToolBarImages.AutozeroEnabled
						//tlbrSpectrum.Buttons.Item(EnumToolBarButtons.StartScan).ImageIndex = EnumToolBarImages.StartScanEnabled

						//End If
						//tlbrSpectrum.Buttons.Item(EnumToolBarButtons.Print).ImageIndex = EnumToolBarImages.PrintEnabled
						//tlbrSpectrum.Buttons.Item(EnumToolBarButtons.ClearAndRedraw).ImageIndex = EnumToolBarImages.ClearAndRedrawDisabled


					}
				case EnumProcesses.ClearAndRedraw:
					//17 
					switch (intStart_End) {
						case EnumStart_End.Start_of_Process:


							subAll_Menus_Disable();
						//tlbrSpectrum.Buttons.Item(EnumToolBarButtons.ReturnToSelectModes).ImageIndex = EnumToolBarImages.ReturnToSelectModesDisabled
						//tlbrSpectrum.Buttons.Item(EnumToolBarButtons.Parameter).ImageIndex = EnumToolBarImages.ParameterDisabled
						//tlbrSpectrum.Buttons.Item(EnumToolBarButtons.StopScan).ImageIndex = EnumToolBarImages.StopScanDisabled
						//tlbrSpectrum.Buttons.Item(EnumToolBarButtons.Clear).ImageIndex = EnumToolBarImages.ClearDisabled
						//tlbrSpectrum.Buttons.Item(EnumToolBarButtons.Baseline).ImageIndex = EnumToolBarImages.BaselineDisabled
						//tlbrSpectrum.Buttons.Item(EnumToolBarButtons.Autozero).ImageIndex = EnumToolBarImages.AutozeroDisabled
						//tlbrSpectrum.Buttons.Item(EnumToolBarButtons.StartScan).ImageIndex = EnumToolBarImages.StartScanDisabled
						//tlbrSpectrum.Buttons.Item(EnumToolBarButtons.ClearAndRedraw).ImageIndex = EnumToolBarImages.ClearAndRedrawDisabled
						//tlbrSpectrum.Buttons.Item(EnumToolBarButtons.Print).ImageIndex = EnumToolBarImages.PrintDisabled

						case EnumStart_End.End_of_Process:

							subAll_Menus_Enable();
						//tlbrSpectrum.Buttons.Item(EnumToolBarButtons.ReturnToSelectModes).ImageIndex = EnumToolBarImages.ReturnToSelectModesEnabled
						//tlbrSpectrum.Buttons.Item(EnumToolBarButtons.Parameter).ImageIndex = EnumToolBarImages.ParameterEnabled
						//tlbrSpectrum.Buttons.Item(EnumToolBarButtons.StopScan).ImageIndex = EnumToolBarImages.StopScanDisabled
						//tlbrSpectrum.Buttons.Item(EnumToolBarButtons.Clear).ImageIndex = EnumToolBarImages.ClearEnabled
						// Get Confirmed
						// Bt Sachin V. Dokhale
						//If gstructConfigurartionSetting.DemoMode = 1 Then   'Or structFlag.blnNone = True
						//    mnuLamp.Enabled = False
						//    tlbrSpectrum.Buttons.Item(EnumToolBarButtons.Baseline).ImageIndex = EnumToolBarImages.BaselineDisabled
						//    tlbrSpectrum.Buttons.Item(EnumToolBarButtons.Autozero).ImageIndex = EnumToolBarImages.AutozeroDisabled
						//    tlbrSpectrum.Buttons.Item(EnumToolBarButtons.StartScan).ImageIndex = EnumToolBarImages.StartScanDisabled
						//Else
						//    tlbrSpectrum.Buttons.Item(EnumToolBarButtons.Baseline).ImageIndex = EnumToolBarImages.BaselineEnabled
						//    tlbrSpectrum.Buttons.Item(EnumToolBarButtons.Autozero).ImageIndex = EnumToolBarImages.AutozeroEnabled
						//    tlbrSpectrum.Buttons.Item(EnumToolBarButtons.StartScan).ImageIndex = EnumToolBarImages.StartScanEnabled
						//End If

						//tlbrSpectrum.Buttons.Item(EnumToolBarButtons.ClearAndRedraw).ImageIndex = EnumToolBarImages.ClearAndRedrawEnabled
						//tlbrSpectrum.Buttons.Item(EnumToolBarButtons.Print).ImageIndex = EnumToolBarImages.PrintEnabled

					}
				case EnumProcesses.StopsScan:
					//16 
					switch (intStart_End) {
						case EnumStart_End.Start_of_Process:

							subAll_Menus_Enable();
						//tlbrSpectrum.Buttons.Item(EnumToolBarButtons.ReturnToSelectModes).ImageIndex = EnumToolBarImages.ReturnToSelectModesEnabled
						//tlbrSpectrum.Buttons.Item(EnumToolBarButtons.Parameter).ImageIndex = EnumToolBarImages.ParameterEnabled
						//tlbrSpectrum.Buttons.Item(EnumToolBarButtons.StopScan).ImageIndex = EnumToolBarImages.StopScanDisabled
						//tlbrSpectrum.Buttons.Item(EnumToolBarButtons.Clear).ImageIndex = EnumToolBarImages.ClearEnabled
						//tlbrSpectrum.Buttons.Item(EnumToolBarButtons.Baseline).ImageIndex = EnumToolBarImages.BaselineEnabled
						//tlbrSpectrum.Buttons.Item(EnumToolBarButtons.Autozero).ImageIndex = EnumToolBarImages.AutozeroEnabled
						//tlbrSpectrum.Buttons.Item(EnumToolBarButtons.StartScan).ImageIndex = EnumToolBarImages.StartScanEnabled
						//tlbrSpectrum.Buttons.Item(EnumToolBarButtons.ClearAndRedraw).ImageIndex = EnumToolBarImages.ClearAndRedrawEnabled
						//tlbrSpectrum.Buttons.Item(EnumToolBarButtons.Print).ImageIndex = EnumToolBarImages.PrintEnabled

						case EnumStart_End.End_of_Process:

					}
				case EnumProcesses.Autozero:
					//19 
					switch (intStart_End) {

						case EnumStart_End.Start_of_Process:
						case EnumStart_End.End_of_Process:

					}
				case EnumProcesses.Baseline:
					//18 
					switch (intStart_End) {

						case EnumStart_End.Start_of_Process:
						case EnumStart_End.End_of_Process:
					}
				case EnumProcesses.ChannelUp_Down:
					//21
					switch (intStart_End) {
						case EnumStart_End.Start_of_Process:
						//NumUpDwn.Enabled = False
						//btnNumUpDwn_Dwn.Enabled = False
						//btnNumUpDwn_Up.Enabled = False

						case EnumStart_End.End_of_Process:
							mnuDataProcessing.Enabled = true;
						//mnuManipulate.Enabled = True
						//NumUpDwn.Enabled = True
						//btnNumUpDwn_Dwn.Enabled = True
						//btnNumUpDwn_Up.Enabled = True
						//tlbrSpectrum.Buttons.Item(EnumToolBarButtons.Print).ImageIndex = EnumToolBarImages.PrintEnabled

					}
				case EnumProcesses.LoadChannel:
					switch (intStart_End) {
						case EnumStart_End.Start_of_Process:
							if (mintChannelIndex > -1) {
								mnuParameters.Enabled = true;
								tlbbtnParameters.Enabled = true;

								mnuSaveSpectrumFile.Enabled = true;
								tlbbtnSaveSpectrumFile.Enabled = true;

								mnuPeakPick.Enabled = true;
								tlbbtnPeakPick.Enabled = true;

								mnuPositionToMaxima.Enabled = true;
								tlbbtnPositionToMaxima.Enabled = true;

								mnuSmooth.Enabled = true;
								tlbbtnSmooth.Enabled = true;

								btnReturn.Enabled = true;
								mnuExit.Enabled = true;
								tlbbtnReturn.Enabled = true;
							} else {
								mnuParameters.Enabled = false;
								tlbbtnParameters.Enabled = false;

								mnuSaveSpectrumFile.Enabled = false;
								tlbbtnSaveSpectrumFile.Enabled = false;

								mnuPeakPick.Enabled = false;
								tlbbtnPeakPick.Enabled = false;

								mnuPositionToMaxima.Enabled = false;
								tlbbtnPositionToMaxima.Enabled = false;

								mnuSmooth.Enabled = false;
								tlbbtnSmooth.Enabled = false;

								btnReturn.Enabled = false;
								mnuExit.Enabled = false;
								tlbbtnReturn.Enabled = false;
							}
						default:

					}
				default:
					subAll_Menus_Enable();
				//tlbrSpectrum.Buttons.Item(EnumToolBarButtons.ReturnToSelectModes).ImageIndex = EnumToolBarImages.ReturnToSelectModesEnabled
				//tlbrSpectrum.Buttons.Item(EnumToolBarButtons.Parameter).ImageIndex = EnumToolBarImages.ParameterEnabled
				//tlbrSpectrum.Buttons.Item(EnumToolBarButtons.StopScan).ImageIndex = EnumToolBarImages.StopScanDisabled
				//tlbrSpectrum.Buttons.Item(EnumToolBarButtons.Clear).ImageIndex = EnumToolBarImages.ClearEnabled
				//tlbrSpectrum.Buttons.Item(EnumToolBarButtons.Baseline).ImageIndex = EnumToolBarImages.BaselineEnabled
				//tlbrSpectrum.Buttons.Item(EnumToolBarButtons.Autozero).ImageIndex = EnumToolBarImages.AutozeroEnabled
				//tlbrSpectrum.Buttons.Item(EnumToolBarButtons.StartScan).ImageIndex = EnumToolBarImages.StartScanEnabled
				//tlbrSpectrum.Buttons.Item(EnumToolBarButtons.ClearAndRedraw).ImageIndex = EnumToolBarImages.ClearAndRedrawEnabled
				//tlbrSpectrum.Buttons.Item(EnumToolBarButtons.Print).ImageIndex = EnumToolBarImages.PrintEnabled
			}

		// tlbrSpectrum.Buttons.Item(EnumToolBarButtons.StopScan).Pushed = True

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
		//gobjErrorHandler.ProcessError(ErrorHandler.EnumErrorType.Critical, ex)
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			//tlbrSpectrum.Refresh()

			//---------------------------------------------------------
		}

	}

	private bool func_Enable_DisableControl(bool blnEnabled)
	{

		//=====================================================================
		// Procedure Name        :   func_Enable_Disable
		// Description           :   
		// Purpose               :   
		// Parameters Passed     :   blnEnaDisable
		// Returns               :   True if success
		// Parameters Affected   :   
		// Assumptions           :   
		// Dependencies          :   None.
		// Author                :   Sachin Dokhale
		// Created               :   04.05.07
		// Revisions             :
		//=====================================================================
		try {
			//If blnEnabled = False Then
			//    'RemoveHandler nudFuelRatio.ValueEditorClick, AddressOf nudFuelRatio_ValueEditorClick
			//    'RemoveHandler nudFuelRatio.ValueEditorValueChanged, AddressOf nudFuelRatio_ValueChanged
			//    nudFuelRatio.Enabled = False
			//    'AddHandler nudBurnerHeight.ValueChanged, AddressOf nudBurnerHeight_ValueChanged
			//    'RemoveHandler nudBurnerHeight.ValueEditorClick, AddressOf nudBurnerHeight_ValueEditorClick
			//    'RemoveHandler nudBurnerHeight.ValueEditorValueChanged, AddressOf nudBurnerHeight_ValueChanged
			//    nudBurnerHeight.Enabled = False

			//    'AddHandler nudD2Cur.ValueChanged, AddressOf nudD2Cur_ValueChanged
			//    'RemoveHandler nudD2Cur.ValueEditorClick, AddressOf nudD2Cur_ValueEditorClick
			//    'RemoveHandler nudD2Cur.ValueEditorValueChanged, AddressOf nudD2Cur_ValueChanged
			//    nudD2Cur.Enabled = False
			//    'AddHandler nudHCLCur.ValueChanged, AddressOf nudHCLCur_ValueChanged
			//    'RemoveHandler nudHCLCur.ValueEditorClick, AddressOf nudHCLCur_ValueEditorClick
			//    'RemoveHandler nudHCLCur.ValueEditorValueChanged, AddressOf nudHCLCur_ValueChanged
			//    nudHCLCur.Enabled = False
			//    'AddHandler nudSlit.ValueChanged, AddressOf nudSlit_ValueChanged
			//    'RemoveHandler nudSlit.ValueEditorClick, AddressOf nudSlit_ValueEditorClick
			//    'RemoveHandler nudSlit.ValueEditorValueChanged, AddressOf nudSlit_ValueChanged
			//    nudSlit.Enabled = False
			//    'RemoveHandler nudSlit_Ref.ValueEditorClick, AddressOf nudSlit_Ref_ValueEditorClick
			//    'RemoveHandler nudSlit_Ref.ValueEditorValueChanged, AddressOf nudSlit_Ref_ValueChanged
			//    nudSlit_Ref.Enabled = False
			//    'AddHandler nudPMT.ValueChanged, AddressOf nudPMT_ValueChanged
			//    'RemoveHandler nudPMT.ValueEditorClick, AddressOf nudPMT_ValueEditorClick
			//    'RemoveHandler nudPMT.ValueEditorValueChanged, AddressOf nudPMT_ValueChanged
			//    nudPMT.Enabled = False
			//    'RemoveHandler nudPMT_Ref.ValueEditorClick, AddressOf nudPMT_Ref_ValueEditorClick
			//    'RemoveHandler nudPMT_Ref.ValueEditorValueChanged, AddressOf nudPMT_Ref_ValueChanged
			//    nudPMT_Ref.Enabled = False
			//Else
			//    'AddHandler nudFuelRatio.ValueEditorClick, AddressOf nudFuelRatio_ValueEditorClick
			//    'AddHandler nudFuelRatio.ValueEditorValueChanged, AddressOf nudFuelRatio_ValueChanged

			//    'AddHandler nudBurnerHeight.ValueChanged, AddressOf nudBurnerHeight_ValueChanged
			//    AddHandler nudBurnerHeight.ValueEditorClick, AddressOf nudBurnerHeight_ValueEditorClick
			//    AddHandler nudBurnerHeight.ValueEditorValueChanged, AddressOf nudBurnerHeight_ValueChanged

			//    'AddHandler nudD2Cur.ValueChanged, AddressOf nudD2Cur_ValueChanged
			//    AddHandler nudD2Cur.ValueEditorClick, AddressOf nudD2Cur_ValueEditorClick
			//    AddHandler nudD2Cur.ValueEditorValueChanged, AddressOf nudD2Cur_ValueChanged

			//    'AddHandler nudHCLCur.ValueChanged, AddressOf nudHCLCur_ValueChanged
			//    AddHandler nudHCLCur.ValueEditorClick, AddressOf nudHCLCur_ValueEditorClick
			//    AddHandler nudHCLCur.ValueEditorValueChanged, AddressOf nudHCLCur_ValueChanged

			//    'AddHandler nudSlit.ValueChanged, AddressOf nudSlit_ValueChanged
			//    AddHandler nudSlit.ValueEditorClick, AddressOf nudSlit_ValueEditorClick
			//    AddHandler nudSlit.ValueEditorValueChanged, AddressOf nudSlit_ValueChanged
			//    AddHandler nudSlit_Ref.ValueEditorClick, AddressOf nudSlit_Ref_ValueEditorClick
			//    AddHandler nudSlit_Ref.ValueEditorValueChanged, AddressOf nudSlit_Ref_ValueChanged

			//    'AddHandler nudPMT.ValueChanged, AddressOf nudPMT_ValueChanged
			//    AddHandler nudPMT.ValueEditorClick, AddressOf nudPMT_ValueEditorClick
			//    AddHandler nudPMT.ValueEditorValueChanged, AddressOf nudPMT_ValueChanged
			//    AddHandler nudPMT_Ref.ValueEditorClick, AddressOf nudPMT_Ref_ValueEditorClick
			//    AddHandler nudPMT_Ref.ValueEditorValueChanged, AddressOf nudPMT_Ref_ValueChanged
			//End If

			nudFuelRatio.Enabled = blnEnabled;

			nudBurnerHeight.Enabled = blnEnabled;

			nudD2Cur.Enabled = blnEnabled;

			nudHCLCur.Enabled = blnEnabled;

			nudSlit.Enabled = blnEnabled;

			//nudSlit_Ref.Enabled = blnEnabled'by Pankaj on 18.1.08

			nudPMT.Enabled = blnEnabled;
			if (!(gintInstrumentBeamType == AAS203Library.Instrument.enumInstrumentBeamType.SingleBeam)) {
				nudPMT_Ref.Enabled = blnEnabled;
			}
			return true;
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			return false;
		//gobjErrorHandler.ProcessError(ErrorHandler.EnumErrorType.Critical, ex)
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

	private void subAll_Menus_Enable()
	{
		//=====================================================================
		// Procedure Name        :   subAll_Menus_Enable
		// Description           :   
		// Purpose               :   
		// Parameters Passed     :   
		// Returns               :   
		// Parameters Affected   :   
		// Assumptions           :   
		// Dependencies          :   None.
		// Author                :   Sachin Dokhale
		// Created               :   04.05.07
		// Revisions             :
		//=====================================================================
		int intMenuItems_Count;
		try {
		//For intMenuItems_Count = 0 To MainMenu.MenuItems.Count - 1
		//    MainMenu.MenuItems.Item(intMenuItems_Count).Enabled = True
		//Next
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
		//gobjErrorHandler.ProcessError(ErrorHandler.EnumErrorType.Critical, ex)
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

	private void subAll_Menus_Disable()
	{
		//=====================================================================
		// Procedure Name        :   subAll_Menus_Disable
		// Description           :   
		// Purpose               :   
		// Parameters Passed     :   
		// Returns               :   
		// Parameters Affected   :   
		// Assumptions           :   
		// Dependencies          :   None.
		// Author                :   Sachin Dokhale
		// Created               :   04.05.07
		// Revisions             :
		//=====================================================================
		int intMenuItems_Count;
		try {
		//For intMenuItems_Count = 0 To MainMenu.MenuItems.Count - 1
		//    MainMenu.MenuItems.Item(intMenuItems_Count).Enabled = False
		//Next
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
		//gobjErrorHandler.ProcessError(ErrorHandler.EnumErrorType.Critical, ex)
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
			//ProgressPanel.Text = Application.ProductName & Space(1) & Application.ProductVersion   'Commented by Saurabh 29.07.07
			ProgressPanel.Text = gstrTitleInstrumentType + Space(1) + "S/W Ver. : " + Mid(Application.ProductVersion, 1, 4);
			//added by Saurabh 29.07.07

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
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

	#Region " IClient Events for receiving the wavelength and Abs value from Receiving thread "

	private void BgThread.Iclient.TaskStarted(clsBgThread BgThread)
	{
		//=====================================================================
		// Procedure Name        :   TaskStarted
		// Description           :    
		//                           
		// Purpose               :   
		// Parameters Passed     :  
		// Returns               :   True, if successful.
		// Parameters Affected   :   
		// Assumptions           :   None.
		// Dependencies          :   None.
		// Author                :   Sachin Dokhale
		// Created               :   17.12.06
		// Revisions             :
		//=====================================================================
		try {
			mblnAvoidProcessing = true;
		//func_Enable_Disable(EnumProcesses.StartScan, EnumStart_End.Process_Running)
		} catch (Exception ex) {
		//gFuncShowMessage("Communication Error...", "Error in starting spectrum scanning.", modConstants.EnumMessageType.Information)
		//---------------------------------------------------------
		//Error logging
		//gobjErrorHandler.ErrorDescription = ex.Message
		//gobjErrorHandler.ErrorMessage = ex.Message
		//gobjErrorHandler.WriteErrorLog(ex)
		//gobjErrorHandler.ProcessError(ErrorHandler.EnumErrorType.Critical, ex)
		//---------------------------------------------------------

		} finally {
			//    '---------------------------------------------------------
			//    'Writing Execution log
			//    If CONST_CREATE_EXECUTION_LOG = 1 Then
			//        gobjErrorHandler.WriteExecutionLog()
			//    End If
			//    '---------------------------------------------------------
		}

	}

	private void Iclient.TaskStatus(string Text)
	{
		//=====================================================================
		// Procedure Name        :   TaskStatus
		// Description           :    
		//                           
		// Purpose               :   
		// Parameters Passed     :  
		// Returns               :   True, if successful.
		// Parameters Affected   :   
		// Assumptions           :   None.
		// Dependencies          :   None.
		// Author                :   Sachin Dokhale
		// Created               :   17.12.06
		// Revisions             :
		//=====================================================================
		try {
			//If gstructApplicationSessionState.intInstrument_Group = EnumInstrumentGroup.Initialize_2600_2700 Then
			funcIclientTaskDisplayData(Text);
			if (!(mobjclsBgSpectrum == null)) {
				mobjclsBgSpectrum.EndProcess = true;
				Application.DoEvents();
			}

		//ElseIf gstructApplicationSessionState.intInstrument_Group = EnumInstrumentGroup.Initialize_2100_2200_2300 Then
		//Call funcIclientTaskDisplay2100(Text)
		//End If


		} catch (Exception ex) {
		//gFuncShowMessage("Error...", "Error in displaying the spectrum on the screen.", modConstants.EnumMessageType.Information)
		//---------------------------------------------------------
		//Error logging
		//gobjErrorHandler.ErrorDescription = ex.Message
		//gobjErrorHandler.ErrorMessage = ex.Message
		//gobjErrorHandler.WriteErrorLog(ex)
		//gobjErrorHandler.ProcessError(ErrorHandler.EnumErrorType.Critical, ex)
		//---------------------------------------------------------
		} finally {
			//'---------------------------------------------------------
			//'Writing Execution log
			//If CONST_CREATE_EXECUTION_LOG = 1 Then
			//    gobjErrorHandler.WriteExecutionLog()
			//End If
			//'--------------------------------------------------------
			Application.DoEvents();
		}

	}


	// commented Iclient.Display before implementation of UV2100
	//Implements Iclient.Display
	//    Try
	//'-----------------------------------------------------
	//'Data in the Text arg would be "Wavelength|Abs"
	//'-----------------------------------------------------
	//Dim objData As New Data
	//Dim arrData() As String
	//Dim O As Integer   ' same as in function funcSmoothgraphonline
	//Dim intCount As Integer

	//'--- Split the data for Wv and Abs
	//        arrData = Split(Text, "|")

	//        If arrData(0).Length > 0 And arrData(1).Length > 0 And arrData(2).Length > 0 Then

	//            objData.XaxisData = Format(Val(arrData(0)), "#000.0")  ' wv

	//            Select Case mobjTemporaryChannel.Parameter.ScanMode
	//                Case EnumScanMode.Absorbance
	//                    objData.YaxisData = Format(Val(arrData(1)), "#0.000")
	//                Case EnumScanMode.Transmittance
	//                    objData.YaxisData = Format(Val(arrData(1)), "#0.0")
	//                Case EnumScanMode.Energy
	//                    objData.YaxisData = Format(Val(arrData(1)), "#0.0")
	//            End Select

	//            O = (ORDER - 1) / 2

	//            If Val(arrData(2)) = EnumUVProtocol.Data Then

	//'--- Add the reading to the temp readings collection
	//                mobjTemporaryReadings.Add(objData)

	//                lblOnlineWv.Text = Format(mobjTemporaryReadings.item(mobjTemporaryReadings.Count - 1).XaxisData, "#000.0")

	//                Select Case mobjTemporaryChannel.Parameter.ScanMode
	//                    Case EnumScanMode.Absorbance
	//                        lblOnlineABS.Text = Format(mobjTemporaryReadings.item(mobjTemporaryReadings.Count - 1).YaxisData, "#0.000")
	//                    Case EnumScanMode.Transmittance, EnumScanMode.Energy
	//                        lblOnlineABS.Text = Format(mobjTemporaryReadings.item(mobjTemporaryReadings.Count - 1).YaxisData, "#0.0")
	//                End Select


	//                If gblnSmoothFlag Then
	//                    If mobjTemporaryReadings.Count < ORDER Then
	//                        NPSmoothningdata(mobjTemporaryReadings.Count) = objData.YaxisData
	//                    End If

	//                    If (mobjTemporaryReadings.Count - 1) < ((ORDER - 1) / 2) Then

	//                        funcDisplayGraph_RealTime(mobjTemporaryReadings.item(mobjTemporaryReadings.Count - 1).XaxisData, _
	//                                                  mobjTemporaryReadings.item(mobjTemporaryReadings.Count - 1).YaxisData)

	//                    ElseIf mobjTemporaryReadings.Count >= ORDER Then
	//                        gfuncSmoothOnlineGraph(mobjTemporaryReadings, NPSmoothningdata)
	//                        funcDisplayGraph_RealTime(mobjTemporaryReadings.item((mobjTemporaryReadings.Count - 1) - O).XaxisData, _
	//                                                  mobjTemporaryReadings.item((mobjTemporaryReadings.Count - 1) - O).YaxisData)
	//                    End If
	//                Else  ' if not gblnsmoothgraph then there is no need to smooth the graph
	//                    funcDisplayGraph_RealTime(mobjTemporaryReadings.item(mobjTemporaryReadings.Count - 1).XaxisData, _
	//                                              mobjTemporaryReadings.item(mobjTemporaryReadings.Count - 1).YaxisData)
	//                End If
	//            End If

	//            If Val(arrData(2)) = EnumUVProtocol.CMD_End _
	//            Or Val(arrData(2)) = EnumUVProtocol.Spect_End _
	//            Or Val(arrData(2)) = EnumUVProtocol.CMD_Acknowledge Then

	//                If gblnSmoothFlag Then
	//                    For intCount = (((ORDER - 1) / 2) - 1) To 0 Step -1
	//                        funcDisplayGraph_RealTime(mobjTemporaryReadings.item((mobjTemporaryReadings.Count - 1) - intCount).XaxisData, _
	//                                                  mobjTemporaryReadings.item((mobjTemporaryReadings.Count - 1) - intCount).YaxisData)
	//                    Next
	//                End If
	//            End If
	//        End If

	//    Catch ex As Exception
	//        gFuncShowMessage("Error...", "Error in displaying the Spectrum on the screen.", modConstants.EnumMessageType.Information)
	//'---------------------------------------------------------
	//'Error logging
	//'gobjErrorHandler.ErrorDescription = ex.Message
	//'gobjErrorHandler.ErrorMessage = ex.Message
	//'gobjErrorHandler.WriteErrorLog(ex)
	//'gobjErrorHandler.ProcessError(ErrorHandler.EnumErrorType.Critical, ex)
	//'---------------------------------------------------------
	//    Finally
	///---------------------------------------------------------
	///Writing Execution log
	//'If CONST_CREATE_EXECUTION_LOG = 1 Then
	//'    gobjErrorHandler.WriteExecutionLog()
	//'End If
	///--------------------------------------------------------

	//    End Try

	//End Sub

	private void Iclient.TaskFailed(Exception e)
	{
		//=====================================================================
		// Procedure Name        :   TaskFailed
		// Description           :    
		//                           
		// Purpose               :   
		// Parameters Passed     :  
		// Returns               :   True, if successful.
		// Parameters Affected   :   
		// Assumptions           :   None.
		// Dependencies          :   None.
		// Author                :   Sachin Dokhale
		// Created               :   17.12.06
		// Revisions             :
		//=====================================================================
		try {
			//--- Dispose all the objects
			//mobjTemporaryChannel = New Channel
			//mobjTemporaryReadings = New Readings
			//mobjTemporaryReadings_2100 = New Readings
			mAvoidProcessBtn = true;
			funcIclientTaskFalied();

			mblnSpectrumStarted = false;
			mblnAvoidProcessing = false;
			statStartGraph = false;
			mAvoidProcessBtn = false;
			TimerEnergyDisplay.Enabled = true;
		//gFuncShowMessage("Error...", "Spectrum scanning failed.", modConstants.EnumMessageType.Information)

		} catch (Exception ex) {
		//---------------------------------------------------------
		//Error logging
		//gobjErrorHandler.ErrorDescription = ex.Message
		//gobjErrorHandler.ErrorMessage = ex.Message
		//gobjErrorHandler.WriteErrorLog(ex)
		//gobjErrorHandler.ProcessError(ErrorHandler.EnumErrorType.Critical, ex)
		//---------------------------------------------------------
		} finally {
			//'---------------------------------------------------------
			//'Writing Execution log
			//If CONST_CREATE_EXECUTION_LOG = 1 Then
			//    gobjErrorHandler.WriteExecutionLog()
			//End If
			//'---------------------------------------------------------
			//funcTimerStartStop(mTimer, EnumTimerStartStop.Timer_Start)
			//Call SubDisplayScanModeLabel(mobjParameters, True)
			mblnAvoidProcessing = false;
			//func_Enable_Disable(EnumProcesses.StartScan, EnumStart_End.End_of_Process)
		}

	}

	private void Iclient.TaskCompleted(bool Cancelled)
	{
		//=====================================================================
		// Procedure Name        :   TaskCompleted
		// Description           :    
		//                           
		// Purpose               :   
		// Parameters Passed     :  
		// Returns               :   True, if successful.
		// Parameters Affected   :   
		// Assumptions           :   None.
		// Dependencies          :   None.
		// Author                :   Sachin Dokhale
		// Created               :   17.12.06
		// Revisions             :
		//=====================================================================
		try {
			//If gstructApplicationSessionState.intInstrument_Group = EnumInstrumentGroup.Initialize_2600_2700 Then
			//    'Call funcIclientTaskCompleted2600()
			//ElseIf gstructApplicationSessionState.intInstrument_Group = EnumInstrumentGroup.Initialize_2100_2200_2300 Then
			//    'Call funcIclientTaskCompleted2100()
			//End If
			funcIclientTaskCompleted();

			mblnSpectrumStarted = false;
			mblnAvoidProcessing = false;

			mblnAvoidProcessing = false;
			statStartGraph = false;
			TimerEnergyDisplay.Enabled = true;
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error logging
			gobjErrorHandler.ErrorDescription = ex.Message;
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

	private bool funcIclientTaskDisplayData(string strData)
	{
		//=====================================================================
		// Procedure Name        :   funcIclientTaskDisplayData
		// Description           :    
		//                           
		// Purpose               :   
		// Parameters Passed     :  
		// Returns               :   True, if successful.
		// Parameters Affected   :   
		// Assumptions           :   None.
		// Dependencies          :   None.
		// Author                :   Sachin Dokhale
		// Created               :   17.12.06
		// Revisions             :
		//=====================================================================

		try {
			//Data in the Text arg would be "Wavelength|Abs"

			Spectrum.Data objData = new Spectrum.Data();
			string[] arrData;
			int O;
			// same as in function funcSmoothgraphonline
			int intCount;

			//--- Split the data for Wv and Abs
			arrData = Split(strData, "|");


			string dsf;

			if (arrData(0).Length > 0 & arrData(1).Length > 0) {
				if (IsNumeric(arrData(0)) == false) {
					if (arrData(0) == "Reference") {
						mSelectedBeamType = modGlobalDeclarations.enumSelectBeamType.Reference;
						mstrSelectedBeamType = "Reference";
					} else if (arrData(0) == "Sample") {
						mSelectedBeamType = modGlobalDeclarations.enumSelectBeamType.Sample;
						mstrSelectedBeamType = "Sample";
					}
					funcFirstChannelTaskCompleted();
				} else {
					objData.XaxisData = Format(Val(arrData(0)), "#000.0000");
					// wv
					objData.YaxisData = Format(Val(arrData(1)), "#0.0000");

					if (!(arrData(2) == null)) {
						if (arrData(2).Length > 0) {
							objData.YaxisADCData = Val(arrData(2));
						} else {
							objData.YaxisADCData = 0.0;
							//Format(Val(arrData(1)), "#0.000")
						}
					}
					mobjOnlineReadings.Add(objData);
					funcDisplayGraph_RealTime(objData.XaxisData, objData.YaxisData);
				}
			}
			Application.DoEvents();
		} catch (Exception ex) {
			//gFuncShowMessage("Error...", "Error in displaying the spectrum on the screen.", modConstants.EnumMessageType.Information)
			//---------------------------------------------------------
			//Error logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
		//gobjErrorHandler.ProcessError(ErrorHandler.EnumErrorType.Critical, ex)
		//---------------------------------------------------------
		} finally {
			//'---------------------------------------------------------
			//'Writing Execution log
			//If CONST_CREATE_EXECUTION_LOG = 1 Then
			//    gobjErrorHandler.WriteExecutionLog()
			//End If
			//'--------------------------------------------------------

		}
	}

	#End Region

	#Region " IClient Private Function"

	private bool funcIclientTaskCompleted()
	{
		//=====================================================================
		// Procedure Name        :   funcIclientTaskCompleted2600
		// Description           :   task completed received from instrument 
		//                           
		// Purpose               :   
		// Parameters Passed     :  
		// Returns               :   True, if successful.
		// Parameters Affected   :   
		// Assumptions           :   None.
		// Dependencies          :   None.
		// Author                :   Sachin Dokhale
		// Created               :   17.12.06
		// Revisions             :
		//=====================================================================

		try {
			funcIclientTaskCompleted = false;

			// If scan is terminated by user in between then gblnSpectrumTerminated = True
			if (!ArrlstGraphCurveItem == null) {
				if (statStartGraph == true) {
					if (ArrlstGraphCurveItem.Count >= intCurveIndex + 1) {
						AASEnergySpectrum.StopOnlineGraph(ArrlstGraphCurveItem(intCurveIndex));
					}
				}
			}
			Application.DoEvents();

			AASEnergySpectrum.AldysPane.AxisChange();
			AASEnergySpectrum.Refresh();



			if (gblnSpectrumTerminated == true) {
				funcScanCompleted(false);
			//scan is completed 
			} else {

				if (!funcSpectrumReadingCompleted()) {
				}
				funcScanCompleted(true);
			}
			func_Enable_DisableControl(true);
			mblnAvoidProcessing = false;
			//AddHandler mnuIgnite.Click, AddressOf btnAutoIgnition_Click

			funcIclientTaskCompleted = true;

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			//---------------------------------------------------------
			return false;
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			//---------------------------------------------------------

		}

	}

	private bool funcFirstChannelTaskCompleted()
	{
		//=====================================================================
		// Procedure Name        :   funcIclientTaskCompleted2600
		// Description           :   task completed received from instrument 
		//                           
		// Purpose               :   
		// Parameters Passed     :  
		// Returns               :   True, if successful.
		// Parameters Affected   :   
		// Assumptions           :   None.
		// Dependencies          :   None.
		// Author                :   Sachin Dokhale
		// Created               :   17.12.06
		// Revisions             :
		//=====================================================================

		try {
			funcFirstChannelTaskCompleted = false;
			// If scan is terminated by user in between then gblnSpectrumTerminated = True
			if (!ArrlstGraphCurveItem == null) {
				if (statStartGraph == true) {
					if (ArrlstGraphCurveItem.Count >= intCurveIndex + 1) {
						AASEnergySpectrum.StopOnlineGraph(ArrlstGraphCurveItem(intCurveIndex));
					}
				}
			}

			AASEnergySpectrum.AldysPane.AxisChange();
			AASEnergySpectrum.Refresh();


			if (!funcSpectrumReadingCompleted()) {
			}

			//If gblnSpectrumTerminated = True Then
			//    funcScanCompleted(False)
			//Else 'scan is completed 
			//    funcScanCompleted(True)
			//End If

			mobjOnlineChannel = new Spectrum.Channel(true);
			//mobjEnegyChannel = New Spectrum.EnergyChannels
			//ObjParameter = funcCloneParameter(mobjParameters)
			//mobjOnlineChannel.EnegryParameter = ObjParameter
			//ObjParameter = Nothing
			statStartGraph = false;
			mobjOnlineReadings = new Spectrum.Readings();

			funcFirstChannelTaskCompleted = true;

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			//---------------------------------------------------------
			return false;
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			//---------------------------------------------------------

		}

	}

	private bool funcIclientTaskFalied()
	{
		//=====================================================================
		// Procedure Name        :   funcIclientTaskFalied
		// Description           :   task falied received from instrument 
		//                           
		// Purpose               :   
		// Parameters Passed     :  
		// Returns               :   True, if successful.
		// Parameters Affected   :   
		// Assumptions           :   None.
		// Dependencies          :   None.
		// Author                :   Sachin Dokhale
		// Created               :   18.12.06
		// Revisions             :
		//=====================================================================

		try {
			funcIclientTaskFalied = false;

			// If scan is terminated by user in between then gblnSpectrumTerminated = True
			if (!ArrlstGraphCurveItem == null) {
				if (statStartGraph == true) {
					if (ArrlstGraphCurveItem.Count >= intCurveIndex + 1) {
						AASEnergySpectrum.StopOnlineGraph(ArrlstGraphCurveItem(intCurveIndex));
						//intCurveIndex += 1
						//intCurveIndex -= 1
						AASEnergySpectrum.AldysPane.CurveList.Remove(AASEnergySpectrum.AldysPane.CurveList.Count - 1);
						ArrlstGraphCurveItem.RemoveAt(ArrlstGraphCurveItem.Count - 1);
					}
				}
			}
			mobjOnlineChannel = new Channel(true);
			mobjOnlineReadings = new Readings();
			mobjEnegyChannel = new Spectrum.EnergyChannels();
			mblnSpectrumStarted = false;
			Application.DoEvents();
			AASEnergySpectrum.AldysPane.AxisChange();
			AASEnergySpectrum.Refresh();

			funcScanCompleted(false);
			blnYetFileNotSave = false;
			gobjMessageAdapter.ShowMessage(constSpectrumScanningFailed);
			func_Enable_DisableControl(true);
			Application.DoEvents();
			mblnAvoidProcessing = false;
			//AddHandler mnuIgnite.Click, AddressOf btnAutoIgnition_Click
			//gFuncShowMessage("Error...", "Spectrum scanning failed.", EnumMessageType.Information)
			funcIclientTaskFalied = true;

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			//---------------------------------------------------------
			return false;
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			//---------------------------------------------------------

		}
	}

	private bool funcScanCompleted(bool blnCompleted)
	{
		//=====================================================================
		// Procedure Name        :   funcScanCompleted
		// Description           :   if scan completed ot terminated by user
		// Purpose               :   
		// Parameters Passed     :   blnCompleted is true if completed successfully 
		//                          & false if terminated by user
		// Returns               :   True, if successful.
		// Parameters Affected   :   
		// Assumptions           :   None.
		// Dependencies          :   None.
		// Author                :   Sachin Dokhale
		// Created               :   Tuesday, April 06, 2004 18:36
		// Revisions             :
		//=====================================================================


		try {
			if (blnCompleted) {
			//lblScanStatus.Text = "Scanning completed..."
			} else {
				//lblScanStatus.Text = "Scan terminated..."
				//lblScanStatus.Refresh()
				//lblRepeats.Text = "Terminated"
				//lblRepeats.Refresh()
			}


			//Call SubDisplayScanModeLabel(mobjParameters, True)
			btnStart.Text = "&Start";
			btnStart.Image = Image.FromFile(Application.StartupPath + "\\Images\\Start.ico");
			btnStart.Enabled = true;
			btnStart.Refresh();

			//funcTimerStartStop(mTimer, EnumTimerStartStop.Timer_Start)
			func_Enable_Disable(EnumProcesses.StartScan, EnumStart_End.End_of_Process);
			//Me.Cursor = Cursors.Default
			gblnSpectrumTerminated = false;
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			//---------------------------------------------------------
			return false;
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			this.Cursor = Cursors.Default;
			//---------------------------------------------------------

		}

	}

	private bool funcSpectrumReadingCompleted()
	{
		//=====================================================================
		// Procedure Name        :   funcSpectrumReadingCompleted
		// Description           :   Add the temp channel to the channels collection
		//                           and save the channel file to the respective 
		//                           Location.
		// Purpose               :   To add the temporary channel to the 
		//                           channels collection.
		// Parameters Passed     :   None.
		// Returns               :   True, if successful.
		// Parameters Affected   :   
		// Assumptions           :   None.
		// Dependencies          :   None.
		// Author                :   Sachin Dokhale
		// Created               :   sunday, November 15, 2003 18:49
		// Revisions             :
		//=====================================================================

		Spectrum.SpectrumData objSpectrumData = new Spectrum.SpectrumData();
		int intChannel_no;
		Spectrum.Readings objReadings = new Spectrum.Readings();

		try {
			//--- Add the analysis data in the serial manner in the 
			//--- collection and make the collection of the size as
			//--- max size=9901
			if (!mobjSpectrum.funcAddSpecDataToChannel(mobjOnlineReadings, objReadings)) {
				gobjMessageAdapter.ShowMessage(constErrorAddingSpectrumData);
				//gFuncShowMessage("Error...", "Error in adding the spectrum data to the current channel.", EnumMessageType.Information)
			}

			//--- Add the channel to the channels collection
			objSpectrumData.Readings = objReadings;
			mobjOnlineChannel.Spectrums.Add(objSpectrumData);
			if (mSelectedBeamType == modGlobalDeclarations.enumSelectBeamType.Reference) {
				mobjOnlineChannel.InstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.ReferenceBeam;
			} else if (mSelectedBeamType == modGlobalDeclarations.enumSelectBeamType.Sample) {
				mobjOnlineChannel.InstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.SingleBeam;
			} else {
				mobjOnlineChannel.InstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.DoubleBeam;
			}

			mobjEnegyChannel.Add(mobjOnlineChannel);

			//--- Add the new channel to the channels collection and 
			//--- accordingly save the channel file to the disk
			intChannel_no = funcAddChannelToCollection(mobjOnlineChannel);
			blnYetFileNotSave = true;
			mintChannelIndex = intChannel_no;
			mobjChannnels(mintChannelIndex).EnegryParameter = mobjParameters;

			//mintMinValue_Of_Channel = 0                   '--- modf by Nilesh on 3/02/04
			//mintMaxValue_Of_Channel = mobjChannnels.Count '--- modf by Nilesh on 3/02/04

			//NumUpDwn.Text = mobjTemporaryChannel.ChannelNo '--- modf by Nilesh on 3/02/04

			//--- Reset the temporary channel object
			mobjOnlineChannel = null;
			mobjOnlineReadings = null;


			return true;

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			//gobjErrorHandler.ProcessError(.EnumErrorType.Critical, ex)
			//---------------------------------------------------------
			return false;
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			//---------------------------------------------------------
		}

	}

	//Private Function funcIclientTaskDisplayData(ByVal strData As String) As Boolean
	//    Try
	//        '-----------------------------------------------------
	//        'Data in the Text arg would be "Wavelength|Abs"
	//        '-----------------------------------------------------
	//        Dim objData As New Spectrum.Data
	//        Dim arrData() As String
	//        Dim O As Integer   ' same as in function funcSmoothgraphonline
	//        Dim intCount As Integer

	//        '--- Split the data for Wv and Abs
	//        arrData = Split(strData, "|")

	//        If arrData(0).Length > 0 And arrData(1).Length > 0 Then

	//            objData.XaxisData = Format(Val(arrData(0)), "#000.0")   ' wv

	//            'Select Case mobjTemporaryChannel.Parameter.ScanMode
	//            '    Case EnumScanMode.Absorbance
	//            '        objData.YaxisData = Format(Val(arrData(1)), "#0.000")
	//            '    Case EnumScanMode.Transmittance
	//            '        objData.YaxisData = Format(Val(arrData(1)), "#0.0")
	//            '    Case EnumScanMode.Energy
	//            '        objData.YaxisData = Format(Val(arrData(1)), "#0.0")
	//            'End Select

	//            objData.YaxisData = Format(Val(arrData(1)), "#0.0")

	//            'O = (ORDER - 1) / 2

	//            'If Val(arrData(2)) = 1 Then  'EnumUVProtocol.Data Then

	//            '--- Add the reading to the temp readings collection

	//            mobjOnlineReadings.Add(objData)


	//            'lblOnlineWv.Text = Format(mobjTemporaryReadings.item(mobjTemporaryReadings.Count - 1).XaxisData, "#000.0")


	//            'Select Case mobjTemporaryChannel.Parameter.ScanMode
	//            '    Case EnumScanMode.Absorbance
	//            '        lblOnlineABS.Text = Format(mobjTemporaryReadings.item(mobjTemporaryReadings.Count - 1).YaxisData, "#0.000")
	//            '    Case EnumScanMode.Transmittance, EnumScanMode.Energy
	//            '        lblOnlineABS.Text = Format(mobjTemporaryReadings.item(mobjTemporaryReadings.Count - 1).YaxisData, "#0.0")
	//            'End Select

	//            funcDisplayGraph_RealTime(objData.XaxisData, objData.YaxisData)
	//            'If gblnSmoothFlag Then
	//            'If mobjTemporaryReadings.Count < ORDER Then
	//            '    NPSmoothningdata(mobjTemporaryReadings.Count) = objData.YaxisData
	//            'End If

	//            'If (mobjTemporaryReadings.Count - 1) < ((ORDER - 1) / 2) Then

	//            '    funcDisplayGraph_RealTime(mobjTemporaryReadings.item(mobjTemporaryReadings.Count - 1).XaxisData, _
	//            '                              mobjTemporaryReadings.item(mobjTemporaryReadings.Count - 1).YaxisData)

	//            'ElseIf mobjTemporaryReadings.Count >= ORDER Then
	//            '    gfuncSmoothOnlineGraph(mobjTemporaryReadings, NPSmoothningdata)
	//            '    funcDisplayGraph_RealTime(mobjTemporaryReadings.item((mobjTemporaryReadings.Count - 1) - O).XaxisData, _
	//            '                              mobjTemporaryReadings.item((mobjTemporaryReadings.Count - 1) - O).YaxisData)
	//            'End If
	//            'Else  ' if not gblnsmoothgraph then there is no need to smooth the graph
	//            'funcDisplayGraph_RealTime(mobjTemporaryReadings.item(mobjTemporaryReadings.Count - 1).XaxisData, _
	//            '                          mobjTemporaryReadings.item(mobjTemporaryReadings.Count - 1).YaxisData)
	//            'End If
	//            'End If

	//            'If Val(arrData(2)) = EnumUVProtocol.CMD_End _
	//            'Or Val(arrData(2)) = EnumUVProtocol.Spect_End _
	//            'Or Val(arrData(2)) = EnumUVProtocol.CMD_Acknowledge Then

	//            'If Val(arrData(2)) = 0 Then 'EnumUVProtocol.CMD_End _


	//            'End If

	//            'If gblnSmoothFlag Then
	//            '    For intCount = (((ORDER - 1) / 2) - 1) To 0 Step -1
	//            '        funcDisplayGraph_RealTime(mobjTemporaryReadings.item((mobjTemporaryReadings.Count - 1) - intCount).XaxisData, _
	//            '                                  mobjTemporaryReadings.item((mobjTemporaryReadings.Count - 1) - intCount).YaxisData)
	//            '    Next
	//            'End If
	//            'End If
	//        End If

	//    Catch ex As Exception
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = ex.Message
	//        gobjErrorHandler.WriteErrorLog(ex)
	//        '---------------------------------------------------------
	//    Finally
	//        ''---------------------------------------------------------
	//        ''Writing Execution log
	//        'If CONST_CREATE_EXECUTION_LOG = 1 Then
	//        '    gobjErrorHandler.WriteExecutionLog()
	//        'End If
	//        ''--------------------------------------------------------

	//    End Try
	//End Function

	#End Region

	#Region " Graph Method"

	private bool funcGraphPreRequisite(int intScanmode, double intXmin, double intXmax, double intYmin, double intYmax)
	{
		//=====================================================================
		// Procedure Name        :   funcGraphPreRequisite
		// Description           :   
		// Purpose               :   
		// Parameters Passed     :   
		// Returns               :   
		// Parameters Affected   :   
		// Assumptions           :   
		// Dependencies          :   None.
		// Author                :   Sachin Dokhale
		// Created               :   04.05.07
		// Revisions             :
		//=====================================================================
		double dblDiffX;
		double dblMajorStepX;
		double dblMinorStepX;
		double dblDiffY;
		double dblMajorStepY;
		double dblMinorStepY;


		try {


			dblDiffX = Fix(intXmax - intXmin);
			dblMajorStepX = dblDiffX / 10;
			dblMinorStepX = dblMajorStepX / 2;

			dblDiffY = (intYmax - intYmin);
			dblMajorStepY = dblDiffY / 10;
			dblMinorStepY = dblMajorStepY / 2;

			//Assigning Values to Xmin,xmax,ymin,ymax properties
			//AASEnergySpectrum.AldysPane.XAxis.Min = intXmin
			//AASEnergySpectrum.AldysPane.XAxis.Max = intXmax
			AASEnergySpectrum.btnPeakEdit.Enabled = true;
			AASEnergySpectrum.btnShowXYValues.Enabled = true;

			AASEnergySpectrum.XAxisMin = intXmin;
			AASEnergySpectrum.XAxisMax = intXmax;
			AASEnergySpectrum.AldysPane.XAxis.Min = intXmin;
			AASEnergySpectrum.AldysPane.XAxis.Max = intXmax;
			AASEnergySpectrum.XAxisMinorStep = dblMinorStepX;
			AASEnergySpectrum.XAxisStep = dblMajorStepX;
			//AASEnergySpectrum.AldysPane.XAxis.MaxAuto = True
			//AASEnergySpectrum.AldysPane.XAxis.MinAuto = True
			//AASEnergySpectrum.AldysPane.XAxis.MinorStepAuto = True


			//--- Display the axis lables
			AASEnergySpectrum.XAxisLabel = "WAVELENGTH (nm)";
			//AxEnergySpectrum.XAxisLabel = "  Energy"

			switch (gobjInst.Mode) {
				case EnumCalibrationMode.AA:
				case EnumCalibrationMode.AABGC:
				case EnumCalibrationMode.MABS:
					AASEnergySpectrum.YAxisMin = intYmin;
					AASEnergySpectrum.YAxisMax = intYmax;
					AASEnergySpectrum.YAxisMinorStep = 1;
					//AASEnergySpectrum.YAxisStep = 0.1
					//AASEnergySpectrum.YAxisLabel = "Abs"
					AASEnergySpectrum.YAxisLabel = "ABSORBANCE";
				case EnumCalibrationMode.HCLE:
				case EnumCalibrationMode.D2E:
					AASEnergySpectrum.YAxisMin = intYmin;
					AASEnergySpectrum.YAxisMax = intYmax;
					AASEnergySpectrum.YAxisLabel = "ENERGY";
				//AASEnergySpectrum.YAxisMinorStep = 5
				//AASEnergySpectrum.YAxisStep = 10
				case EnumCalibrationMode.EMISSION:
					AASEnergySpectrum.YAxisMin = intYmin;
					AASEnergySpectrum.YAxisMax = intYmax;
					//AASEnergySpectrum.YAxisMinorStep = 1
					//AASEnergySpectrum.YAxisStep = 10

					AASEnergySpectrum.YAxisLabel = "EMISSION";
				case EnumCalibrationMode.SELFTEST:
					AASEnergySpectrum.YAxisMin = intYmin;
					AASEnergySpectrum.YAxisMax = intYmax;
					//AASEnergySpectrum.AldysPane.YAxis.Min = intYmin
					//AASEnergySpectrum.AldysPane.YAxis.Max = intYmax
					//AASEnergySpectrum.YAxisMinorStep = 100
					//AASEnergySpectrum.YAxisStep = 500
					AASEnergySpectrum.YAxisLabel = "VOLT(mV)";
			}
			// AASEnergySpectrum.YAxisMinorStep = dblMinorStepY
			//AASEnergySpectrum.YAxisStep = dblMajorStepY

			//AASEnergySpectrum.XAxisStep = 2
			//AASEnergySpectrum.XAxisMinorStep = 5

			//AASEnergySpectrum.YAxisMinorStep = 5
			//AASEnergySpectrum.XAxisStep = 500

			//AASEnergySpectrum.XAxisStep = 2
			//AASEnergySpectrum.XAxisMinorStep = 1
			//AASEnergySpectrum.AldysPane.YAxis.MaxAuto = True
			//AASEnergySpectrum.AldysPane.YAxis.MinAuto = True
			//AASEnergySpectrum.AldysPane.YAxis.MinorStepAuto = True

			AASEnergySpectrum.AldysPane.XAxis.Step = dblMajorStepX;
			AASEnergySpectrum.AldysPane.XAxis.MinorStep = dblMinorStepX;
			AASEnergySpectrum.AldysPane.XAxis.PickScale(intXmin, intXmax);
			AASEnergySpectrum.AldysPane.XAxis.MinorStepAuto = true;
			AASEnergySpectrum.AldysPane.XAxis.StepAuto = true;
			AASEnergySpectrum.AldysPane.YAxis.Step = dblMajorStepY;
			AASEnergySpectrum.AldysPane.YAxis.MinorStep = dblMinorStepY;

			AASEnergySpectrum.AldysPane.YAxis.PickScale(intYmin, intYmax);
			AASEnergySpectrum.AldysPane.YAxis.MinorStepAuto = true;
			AASEnergySpectrum.AldysPane.YAxis.StepAuto = true;

			AASEnergySpectrum.XAxisStep = dblMajorStepX;
			AASEnergySpectrum.XAxisMinorStep = dblMinorStepX;
			AASEnergySpectrum.YAxisStep = dblMajorStepY;
			AASEnergySpectrum.YAxisMinorStep = dblMinorStepY;
			//------------Added by Pankaj on 8 May 07
			AASEnergySpectrum.XAxisMin = mobjParameters.XaxisMin;
			AASEnergySpectrum.XAxisMax = mobjParameters.XaxisMax;

			AASEnergySpectrum.YAxisMin = mobjParameters.YaxisMin;
			AASEnergySpectrum.YAxisMax = mobjParameters.YaxisMax;

			gobjClsAAS203.Calculate_Analysis_Graph_Param(AASEnergySpectrum, ClsAAS203.enumChangeAxis.xyAxis);
			//------------

			AASEnergySpectrum.AldysPane.AxisChange();
			//AASEnergySpectrum.AldysPane.Legend.IsVisible = True
			//mnuShowXYValues.Checked = True
			this.AASEnergySpectrum.IsShowGrid = true;
			mnuGrid.Checked = this.AASEnergySpectrum.IsShowGrid;
			this.AASEnergySpectrum.btnPeakEdit.Checked = false;
			mnuLegends.Checked = AASEnergySpectrum.AldysPane.Legend.IsVisible;
			AASEnergySpectrum.Invalidate();
			AASEnergySpectrum.Refresh();
			Application.DoEvents();

			//AxSpectrumGraph.RefreshGraph()

			////----------------------
			//addataSpect.dblWvMin = 230.0
			//addataSpect.dblWvMax = 250.0

			//Select Case gobjInst.Mode
			//    Case EnumCalibrationMode.AA, EnumCalibrationMode.AABGC, EnumCalibrationMode.MABS
			//        addataSpect.dblYmin = const_YMinAbs
			//        addataSpect.dblYMax = const_YMaxAbs
			//    Case EnumCalibrationMode.HCLE, EnumCalibrationMode.D2E
			//        addataSpect.dblYmin = const_YMinEnergy
			//        addataSpect.dblYMax = const_YMaxEnergy
			//    Case EnumCalibrationMode.EMISSION
			//        addataSpect.dblYmin = const_YMinEmission
			//        addataSpect.dblYMax = const_YMaxEmission
			//    Case EnumCalibrationMode.SELFTEST
			//        addataSpect.dblYmin = const_YMinmVolt
			//        addataSpect.dblYMax = const_YMaxmVolt
			//End Select
			////---------------------
			return true;
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);

			//---------------------------------------------------------
			return false;
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			//---------------------------------------------------------
		}

	}

	private bool funcDisplayGraph_RealTime(double dblXAxis, double dblYAxis)
	{
		//=====================================================================
		// Procedure Name        :   funcDisplayGraph_RealTime
		// Description           :   Plot the graph on the screen.
		// Purpose               :   To plot the graph on the screen for the given
		//                           Wavelength and absorbtion.           
		// Parameters Passed     :   None.
		// Returns               :   True, if successful.
		// Parameters Affected   :   
		// Assumptions           :   Graph pre-requisites are already been set.
		// Dependencies          :   None.
		// Author                :   Uday
		// Created               :   sunday, November 15, 2003 18:49
		// Revisions             :
		//=====================================================================
		double dblToX;
		double dblToY;

		try {
			//--- Plot the graph for the given coordinates.
			dblToX = dblXAxis;
			dblToY = dblYAxis;

			//--- Check if the X-coordinates and Y-coordinates are less than
			//--- Xmin and Ymin
			//If dblAbs < mobjParameter.YaxisMin Then
			//    dblToY = mobjParameter.YaxisMin
			//End If
			//addataSpect.dblYmin = const_YMinAbs
			//addataSpect.dblYMax = const_YMaxAbs
			//If dblYAxis < addataSpect.dblYmin Then
			//    dblYAxis = addataSpect.dblYmin
			//End If

			//If dblYAxis > addataSpect.dblYMax Then
			//    dblYAxis = addataSpect.dblYMax
			//End If
			//If ((dblToX Mod CONST_STEPS_PER_NM) = 0) Then
			dblYAxis = gfuncGetValueInSpectrum(dblToY, gobjInst.Mode);

			//End If

			//{//STEPS_PER_NM==0){
			//Disp_wv_abs_in_mode(hwnd, wv, ynew);
			//GetADConvertedToString(ynew, addata.mode, str);
			//disp_wv_abs(hwnd, wv, str);*/

			dblYAxis = dblToY;
			//dblYAxis = gfuncGetValueInSpectrum(dblToY, gobjInst.Mode)

			lblWvPos.Text = mXValueLable + FormatNumber(dblToX, 2);
			lblYValue.Text = mYValueLable + FormatNumber(dblYAxis, 2);
			//--- Check if the wavelength is equal to the max wv

			if (dblXAxis == mobjParameters.XaxisMin) {
				//mGraphCurveItem = AASEnergySpectrum.StartOnlineGraph("Energy Spectrum", AASEnergySpectrum.GetColor(500), AldysGraph.SymbolType.NoSymbol)
				//mGraphCurveItem = AASEnergySpectrum.StartOnlineGraph("Energy Spectrum", Color.Red, AldysGraph.SymbolType.Circle)
				//AASEnergySpectrum.PlotPoint(mGraphCurveItem, dblXAxis, dblYAxis)
				//AASEnergySpectrum.AldysPane.AxisChange()
				mGraphCurveItem = null;
				intCurveIndex += 1;

				//mGraphCurveItem = AASEnergySpectrum.StartOnlineGraph(mstrSelectedBeamType & " " & AASEnergySpectrum.YAxisLabel & " " & (intCurveIndex + 1).ToString, AASEnergySpectrum.GetColor(intCurveIndex), AldysGraph.SymbolType.NoSymbol)
				//---condition added by deepak on 21.07.07
				if (IsRefBeamSelected == true) {
					mGraphCurveItem = AASEnergySpectrum.StartOnlineGraph("Reference Beam Scan", AASEnergySpectrum.GetColor(intCurveIndex), AldysGraph.SymbolType.NoSymbol);
				} else {
					mGraphCurveItem = AASEnergySpectrum.StartOnlineGraph("Sample Beam Scan", AASEnergySpectrum.GetColor(intCurveIndex), AldysGraph.SymbolType.NoSymbol);
				}


				ArrlstGraphCurveItem.Add(mGraphCurveItem);
				AASEnergySpectrum.PlotPoint(ArrlstGraphCurveItem.Item(intCurveIndex), dblXAxis, dblYAxis);
				statStartGraph = true;
				//AASEnergySpectrum.OfflineCurve.Label = AASEnergySpectrum.YAxisLabel
				AASEnergySpectrum.Refresh();
			//Application.DoEvents()
			} else {
				//AxEnergySpectrum.PlotPoint(mdblXaxis, mdblYaxis, dblToX, dblToY, gSetColor(mintColor))
				//AASEnergySpectrum.PlotPoint(mGraphCurveItem, dblXAxis, (dblYAxis / 10))
				//AASEnergySpectrum.PlotPoint(mGraphCurveItem, dblXAxis, dblYAxis)
				if (statStartGraph == true) {
					AASEnergySpectrum.PlotPoint(ArrlstGraphCurveItem.Item(intCurveIndex), dblXAxis, dblYAxis);
					AASEnergySpectrum.AldysPane.AxisChange();
				}
				AASEnergySpectrum.Refresh();
			}

			//Application.DoEvents()

			//--- Check if the X-coordinates and Y-coordinates are less than
			//--- Xmin and Ymin

			//If dblToY < mobjTemporaryChannel.Parameter.YaxisMin Then
			//    dblToY = mobjTemporaryChannel.Parameter.YaxisMin
			//Else
			//    mdblYaxis = dblToY
			//End If

			mdblYaxis = dblToY;
			mdblXaxis = dblToX;
			Application.DoEvents();
			//AxSpectrumGraph.Refresh()

			return true;
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			//---------------------------------------------------------
			return false;
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			//---------------------------------------------------------
		}


	}

	internal bool funcDisplayGraph(Spectrum.Channel objChannel, ref AldysGraph.CurveItem objCurveItem = null)
	{
		//=====================================================================
		// Procedure Name        :   funcDisplayGraph
		// Description           :   Plot the graph on the screen.
		// Purpose               :   To Plot the offlien graph
		// Parameters Passed     :   objChannel, Optional ByRef objCurveItem 
		// Returns               :   True, if successful.
		// Parameters Affected   :   
		// Assumptions           :   
		// Dependencies          :   None.
		// Author                :   Sachin Dokhale
		// Created               :   08.12.06
		// Revisions             :
		//=====================================================================
		long lngDataCount;
		Spectrum.Readings objReadingCol = new Spectrum.Readings();
		double dblFromX;
		double dblFromY;
		double dblToX;
		double dblToY;
		// Dim intSpeed As Integer

		try {
			//'--- This is done when the Print overlay functionality is operated
			//'--- because graph should come as overlay
			//If mblnGraphClear_Flag = True Then
			//    AxSpectrumGraph.clear()
			//End If

			//--- Set the parameters for the graph control
			//If Not funcGraphPreRequisite(objChannel) Then
			//    gFuncShowMessage("Error", "Error in setting the parameters for graphical display.", modConstants.EnumMessageType.Information)
			//    Return False
			//End If

			//--- Set the graph name and scan speed
			//lblSpectrumName.Text = objChannel.Parameter.ChannelName

			//Select Case objChannel.Parameter.ScanSpeed
			//    Case EnumScanSpeed.Fast
			//        lblScanSpeed.Text = CONST_SCAN_SPEED_FAST
			//    Case EnumScanSpeed.Medium
			//        lblScanSpeed.Text = CONST_SCAN_SPEED_MEDIUM
			//    Case EnumScanSpeed.Slow
			//        lblScanSpeed.Text = CONST_SCAN_SPEED_SLOW
			//    Case EnumScanSpeed.VerySlow
			//        lblScanSpeed.Text = CONST_SCAN_SPEED_VERY_SLOW
			//End Select

			//use this for loop if u want to pass value using plotpointMethod
			//Substitute 2 with Number of Values to be Displayed
			//dblFromX = objChannel.Parameter.WavelengthMax
			//dblFromY = objChannel.Parameter.YaxisMin
			if (!objChannel == null) {

				if (objChannel.Spectrums.Count > 0) {
					dblFromX = objChannel.EnegryParameter.XaxisMax;
					dblFromY = objChannel.EnegryParameter.YaxisMin;

					//--- Get the speed
					//intSpeed = funcGetSpeed(objChannel.Parameter.WavelengthMin, objChannel.Parameter.WavelengthMax)

					//--------Extracting Values from Data Object

					//If objChannel.Parameter.CalculatedSpeed = 0 Then
					//    objChannel.Parameter.CalculatedSpeed = gFuncGetSpeed(objChannel.Parameter.WavelengthMin, objChannel.Parameter.WavelengthMax)
					//    If objChannel.Parameter.CalculatedSpeed = 0 Then
					//        objChannel.Parameter.CalculatedSpeed = 1
					//    End If
					//End If

					//dblYAxis = gfuncGetValueInSpectrum(dblToY, gobjInst.Mode)

					//For lngDataCount = gFuncGetIndexWv(objChannel.Parameter.WavelengthMin, True) To gFuncGetIndexWv(objChannel.Parameter.WavelengthMax, True) Step +objChannel.Parameter.CalculatedSpeed
					DataTable dtPlotValue = new DataTable();
					DataColumn dtColXaxis = new DataColumn("Xaxis", typeof(double));
					DataColumn dtColYaxis = new DataColumn("Yaxis", typeof(double));
					DataRow dtRow;

					dtPlotValue.Columns.Add(dtColXaxis);
					dtPlotValue.Columns.Add(dtColYaxis);

					//For lngDataCount = objChannel.UVParameter.XaxisMin To objChannel.UVParameter.XaxisMax Step 1     '+objChannel.Parameter.CalculatedSpeed
					//+objChannel.Parameter.CalculatedSpeed
					for (lngDataCount = 0; lngDataCount <= objChannel.Spectrums.item(0).Readings.Count - 1; lngDataCount += 1) {
						//--- Check for the graph plotted on the screen

						dblToX = objChannel.Spectrums.item(0).Readings.item(lngDataCount).XaxisData;
						dblToY = objChannel.Spectrums.item(0).Readings.item(lngDataCount).YaxisData;
						//dblToY = gfuncGetValueInSpectrum(dblToY, gobjInst.Mode)
						//--- Check if the X-coordinates and Y-coordinates are less than
						//--- Xmin and Ymin
						//If dblToY < objChannel.EnegryParameter.YaxisMin Then
						//dblToY = objChannel.EnegryParameter.YaxisMin()
						//End If

						//If dblToY > objChannel.EnegryParameter.YaxisMax Then
						//dblToY = objChannel.EnegryParameter.YaxisMax
						//End If
						dtRow = dtPlotValue.NewRow;

						dtRow(0) = dblToX;
						dtRow(1) = dblToY;
						dtPlotValue.Rows.Add(dtRow);

						//--- Check if the wavelength is equal to the min wv
					}
					dtRow = dtPlotValue.NewRow;
					dtRow(0) = dblToX;
					dtRow(1) = dblToY;
					dtPlotValue.Rows.Add(dtRow);
					AASEnergySpectrum.GraphDataSource = dtPlotValue;
					objCurveItem = AASEnergySpectrum.PlotGraph();
					objCurveItem.Label = objChannel.EnegryParameter.SpectrumName();
					AASEnergySpectrum.Refresh();
					Application.DoEvents();
				}
			}
			Application.DoEvents();
			//commented by sns on 310304
			//AxSpectrumGraph.RefreshGraph()
			return true;

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			//---------------------------------------------------------
			return false;
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			//---------------------------------------------------------
		}
		//------------use this method if u want to display graph using File
		//  AxSpectra1.FileToParentCollection("C:\IKON Projects\UV2600Production\Source\SpectroPhotometer\SpectroGraphocxusingmouselock\testfile.txt")

	}

	internal bool funcDisplayGraphOffline(Spectrum.Channel objChannel, ref AldysGraph.CurveItem objCurveItem = null)
	{
		//=====================================================================
		// Procedure Name        :   funcDisplayGraphOffline
		// Description           :   Plot the graph on the screen.
		// Purpose               :   To Plot the offlien graph
		// Parameters Passed     :   objChannel, Optional ByRef objCurveItem 
		// Returns               :   True, if successful.
		// Parameters Affected   :   
		// Assumptions           :   
		// Dependencies          :   None.
		// Author                :   Sachin Dokhale
		// Created               :   08.12.06
		// Revisions             :
		//=====================================================================
		long lngDataCount;
		Spectrum.Readings objReadingCol = new Spectrum.Readings();
		double dblFromX;
		double dblFromY;
		double dblToX;
		double dblToY;
		string strSelectedBeam;
		// Dim intSpeed As Integer


		try {
			if (!objChannel == null) {

				if (objChannel.Spectrums.Count > 0) {
					dblFromX = objChannel.EnegryParameter.XaxisMax;
					dblFromY = objChannel.EnegryParameter.YaxisMin;

					//--- Get the speed
					//intSpeed = funcGetSpeed(objChannel.Parameter.WavelengthMin, objChannel.Parameter.WavelengthMax)

					//--------Extracting Values from Data Object

					//If objChannel.Parameter.CalculatedSpeed = 0 Then
					//    objChannel.Parameter.CalculatedSpeed = gFuncGetSpeed(objChannel.Parameter.WavelengthMin, objChannel.Parameter.WavelengthMax)
					//    If objChannel.Parameter.CalculatedSpeed = 0 Then
					//        objChannel.Parameter.CalculatedSpeed = 1
					//    End If
					//End If

					//dblYAxis = gfuncGetValueInSpectrum(dblToY, gobjInst.Mode)

					//For lngDataCount = gFuncGetIndexWv(objChannel.Parameter.WavelengthMin, True) To gFuncGetIndexWv(objChannel.Parameter.WavelengthMax, True) Step +objChannel.Parameter.CalculatedSpeed
					DataTable dtPlotValue = new DataTable();
					DataColumn dtColXaxis = new DataColumn("Xaxis", typeof(double));
					DataColumn dtColYaxis = new DataColumn("Yaxis", typeof(double));
					DataRow dtRow;

					dtPlotValue.Columns.Add(dtColXaxis);
					dtPlotValue.Columns.Add(dtColYaxis);

					if (objChannel.InstrumentBeamType == AAS203Library.Instrument.enumInstrumentBeamType.SingleBeam) {
						strSelectedBeam = "Sample";
					} else if (objChannel.InstrumentBeamType == AAS203Library.Instrument.enumInstrumentBeamType.ReferenceBeam) {
						strSelectedBeam = "Reference";
					} else {
						strSelectedBeam = "Double";
					}

					////----- Start Online graph plotting
					objCurveItem = AASEnergySpectrum.StartOnlineGraph(strSelectedBeam + " " + AASEnergySpectrum.YAxisLabel + " " + (intCurveIndex + 2).ToString, AASEnergySpectrum.GetColor(intCurveIndex), AldysGraph.SymbolType.NoSymbol);
					//ArrlstGraphCurveItem.Add(mGraphCurveItem)

					////-----
					//For lngDataCount = objChannel.UVParameter.XaxisMin To objChannel.UVParameter.XaxisMax Step 1     '+objChannel.Parameter.CalculatedSpeed
					//+objChannel.Parameter.CalculatedSpeed
					for (lngDataCount = 0; lngDataCount <= objChannel.Spectrums.item(0).Readings.Count - 1; lngDataCount += 1) {
						//--- Check for the graph plotted on the screen

						dblToX = objChannel.Spectrums.item(0).Readings.item(lngDataCount).XaxisData;
						dblToY = objChannel.Spectrums.item(0).Readings.item(lngDataCount).YaxisData;
						//dblToY = gfuncGetValueInSpectrum(dblToY, gobjInst.Mode)
						//--- Check if the X-coordinates and Y-coordinates are less than
						//--- Xmin and Ymin
						//If dblToY < objChannel.EnegryParameter.YaxisMin Then
						//dblToY = objChannel.EnegryParameter.YaxisMin()
						//End If

						//If dblToY > objChannel.EnegryParameter.YaxisMax Then
						//dblToY = objChannel.EnegryParameter.YaxisMax
						//End If
						//dtRow = dtPlotValue.NewRow

						//dtRow(0) = dblToX
						//dtRow(1) = dblToY
						//dtPlotValue.Rows.Add(dtRow)
						AASEnergySpectrum.PlotPoint(objCurveItem, dblToX, dblToY, true);
						//--- Check if the wavelength is equal to the min wv
					}
					//If ArrlstGraphCurveItem.Count >= intCurveIndex + 1 Then
					AASEnergySpectrum.StopOnlineGraph(objCurveItem);
					mGraphCurveItem = objCurveItem;
					AASEnergySpectrum.AldysPane.CurveList(0).Label = AASEnergySpectrum.YAxisLabel;

					//End If
					//AASEnergySpectrum.GraphDataSource = dtPlotValue
					//objCurveItem = AASEnergySpectrum.PlotGraph()
					AASEnergySpectrum.Refresh();
					Application.DoEvents();
				}
			}
			Application.DoEvents();
			//commented by sns on 310304
			//AxSpectrumGraph.RefreshGraph()
			return true;

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			//---------------------------------------------------------
			return false;
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			//---------------------------------------------------------
		}
		//------------use this method if u want to display graph using File
		//  AxSpectra1.FileToParentCollection("C:\IKON Projects\UV2600Production\Source\SpectroPhotometer\SpectroGraphocxusingmouselock\testfile.txt")

	}

	internal bool funcClearGraph()
	{
		//=====================================================================
		// Procedure Name        :   funcClearGraph
		// Description           :   
		// Purpose               :   
		// Parameters Passed     :   
		// Returns               :   
		// Parameters Affected   :   
		// Assumptions           :   
		// Dependencies          :   None.
		// Author                :   Sachin Dokhale
		// Created               :   04.05.07
		// Revisions             :
		//=====================================================================
		long lngDataCount;
		//Dim objReadingCol As New Spectrum.Readings
		double dblFromX;
		double dblFromY;
		double dblToX;
		double dblToY;



		try {
			//--- Set the graph name and scan speed
			//lblSpectrumName.Text = objChannel.Parameter.ChannelName

			//Select Case objChannel.Parameter.ScanSpeed
			//    Case EnumScanSpeed.Fast
			//        lblScanSpeed.Text = CONST_SCAN_SPEED_FAST
			//    Case EnumScanSpeed.Medium
			//        lblScanSpeed.Text = CONST_SCAN_SPEED_MEDIUM
			//    Case EnumScanSpeed.Slow
			//        lblScanSpeed.Text = CONST_SCAN_SPEED_SLOW
			//    Case EnumScanSpeed.VerySlow
			//        lblScanSpeed.Text = CONST_SCAN_SPEED_VERY_SLOW
			//End Select

			//use this for loop if u want to pass value using plotpointMethod
			//Substitute 2 with Number of Values to be Displayed
			//dblFromX = objChannel.Parameter.WavelengthMax
			//dblFromY = objChannel.Parameter.YaxisMin

			//--- Get the speed
			//intSpeed = funcGetSpeed(objChannel.Parameter.WavelengthMin, objChannel.Parameter.WavelengthMax)

			//--------Extracting Values from Data Object

			//If objChannel.Parameter.CalculatedSpeed = 0 Then
			//    objChannel.Parameter.CalculatedSpeed = gFuncGetSpeed(objChannel.Parameter.WavelengthMin, objChannel.Parameter.WavelengthMax)
			//    If objChannel.Parameter.CalculatedSpeed = 0 Then
			//        objChannel.Parameter.CalculatedSpeed = 1
			//    End If
			//End If

			//dblYAxis = gfuncGetValueInSpectrum(dblToY, gobjInst.Mode)

			//For lngDataCount = gFuncGetIndexWv(objChannel.Parameter.WavelengthMin, True) To gFuncGetIndexWv(objChannel.Parameter.WavelengthMax, True) Step +objChannel.Parameter.CalculatedSpeed

			//dtPlotValue.Columns.Add(dtColXaxis)


			//mintChannelIndex = 0
			//mobjChannnels.Clear()
			CheckMaxPosition = false;
			//mnuPositionToMaxima_Click(mnuPositionToMaxima, System.EventArgs.Empty)
			AASEnergySpectrum.RemoveHighPeakLineLabel();
			AASEnergySpectrum.AldysPane.CurveList.Clear();
			ArrlstGraphCurveItem.Clear();
			AASEnergySpectrum.Invalidate();
			AASEnergySpectrum.Refresh();
			intCurveIndex = -1;

			Application.DoEvents();


			//Call AASEnergySpectrum.PlotGraph()
			return true;

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			//---------------------------------------------------------
			return false;
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

	#Region " Graph Options"

	private void mnuGrid_Click(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        :   mnuGrid_Click
		// Description           :   to check the graph for grid.
		// Purpose               :   
		// Parameters Passed     :   
		// Returns               :   
		// Parameters Affected   :   
		// Assumptions           :   
		// Dependencies          :   None.
		// Author                :   Sachin Dokhale
		// Created               :   04.05.07
		// Revisions             :
		//=====================================================================

		try {
			mnuGrid.Checked = !(mnuGrid.Checked);
			this.AASEnergySpectrum.IsShowGrid = mnuGrid.Checked;

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
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

	private void mnuPeakEdit_Click(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        :   mnuPeakEdit_Click
		// Description           :   to check the graph for Peak Edit.
		// Purpose               :   
		// Parameters Passed     :   
		// Returns               :   
		// Parameters Affected   :   
		// Assumptions           :   
		// Dependencies          :   None.
		// Author                :   Sachin Dokhale
		// Created               :   04.05.07
		// Revisions             :
		//=====================================================================

		try {
			mnuPeakEdit.Checked = !(mnuPeakEdit.Checked);
			//Me.AASGraphUVSpectrum.IsShowGrid = mnuPeakEdit.Checked
			this.AASEnergySpectrum.submnuPeakEdit_Click(sender, e);


		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
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

	private void mnuShowXYValues_Click(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        :   mnuShowXYValues_Click
		// Description           :   to check the graph for show XY values.
		// Purpose               :   
		// Parameters Passed     :   
		// Returns               :   
		// Parameters Affected   :   
		// Assumptions           :   
		// Dependencies          :   None.
		// Author                :   Sachin Dokhale
		// Created               :   04.05.07
		// Revisions             :
		//=====================================================================

		try {
			mnuShowXYValues.Checked = !(mnuShowXYValues.Checked);
			this.AASEnergySpectrum.ShowXYValues = mnuShowXYValues.Checked;
		//Me.AASGraphUVSpectrum.submnuPeakEdit_Click(AASGraphUVSpectrum, System.EventArgs.Empty)


		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
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

	private void mnuLegends_Click(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        :   mnuLegends_Click
		// Description           :   to check the graph for Legends.
		// Purpose               :   
		// Parameters Passed     :   
		// Returns               :   
		// Parameters Affected   :   
		// Assumptions           :   
		// Dependencies          :   None.
		// Author                :   Sachin Dokhale
		// Created               :   04.05.07
		// Revisions             :
		//=====================================================================

		try {
			mnuLegends.Checked = !(mnuLegends.Checked);
			this.AASEnergySpectrum.AldysPane.Legend.IsVisible = mnuLegends.Checked;
			AASEnergySpectrum.Invalidate();
			AASEnergySpectrum.Refresh();
		//Me.AASGraphUVSpectrum.submnuPeakEdit_Click(AASGraphUVSpectrum, System.EventArgs.Empty)


		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
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

	//Private Sub mnuPrintPreview_Click(ByVal sender As Object, ByVal e As System.EventArgs)
	//    '=====================================================================
	//    ' Procedure Name        :   mnuLegends_Click
	//    ' Description           :   to check the graph for Legends.
	//    ' Purpose               :   
	//    ' Parameters Passed     :   
	//    ' Returns               :   
	//    ' Parameters Affected   :   
	//    ' Assumptions           :   
	//    ' Dependencies          :   None.
	//    ' Author                :   Sachin Dokhale
	//    ' Created               :   04.05.07
	//    ' Revisions             :
	//    '=====================================================================

	//    Try
	//        Me.AASGraphUVSpectrum.PrintPreViewGraph()
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

	//Private Sub mnuScale_Click(ByVal sender As Object, ByVal e As System.EventArgs)
	//    '=====================================================================
	//    ' Procedure Name        :   mnuLegends_Click
	//    ' Description           :   to check the graph for Legends.
	//    ' Purpose               :   
	//    ' Parameters Passed     :   
	//    ' Returns               :   
	//    ' Parameters Affected   :   
	//    ' Assumptions           :   
	//    ' Dependencies          :   None.
	//    ' Author                :   Sachin Dokhale
	//    ' Created               :   04.05.07
	//    ' Revisions             :
	//    '=====================================================================

	//    Try
	//        'Me.AASGraphUVSpectrum.submnuScale_Click(sender, e)
	//        Call cmdChangeScale_Click(sender, e)
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

	private void  // ERROR: Handles clauses are not supported in C#
AASEnergySpectrum_GraphOptionChanged()
	{
		//=====================================================================
		// Procedure Name        :   AASGraphUVSpectrum_GraphOptionChanged
		// Description           :   to check the graph on options.
		// Purpose               :   
		// Parameters Passed     :   
		// Returns               :   
		// Parameters Affected   :   
		// Assumptions           :   
		// Dependencies          :   None.
		// Author                :   Sachin Dokhale
		// Created               :   04.05.07
		// Revisions             :
		//=====================================================================

		try {
			////----- Check Grid on graph
			mnuGrid.Click -= mnuGrid_Click;
			if (AASEnergySpectrum.IsShowGrid == true) {
				mnuGrid.Checked = true;
			} else {
				mnuGrid.Checked = false;
			}
			mnuGrid.Click += mnuGrid_Click;

			////----- Check Legends on Graph
			mnuLegends.Click -= mnuLegends_Click;
			if (AASEnergySpectrum.AldysPane.Legend.IsVisible == true) {
				mnuLegends.Checked = true;
			} else {
				mnuLegends.Checked = false;
			}
			mnuLegends.Click += mnuLegends_Click;

			////----- Check Show XY Values on Graph
			mnuShowXYValues.Click -= mnuShowXYValues_Click;
			if (AASEnergySpectrum.ShowXYValues == true) {
				mnuShowXYValues.Checked = true;
			} else {
				mnuShowXYValues.Checked = false;
			}
			mnuShowXYValues.Click += mnuShowXYValues_Click;

			mnuPeakEdit.Click -= mnuPeakEdit_Click;
			if (AASEnergySpectrum.ShowXYPeak == true) {
				mnuPeakEdit.Checked = true;
			} else {
				mnuPeakEdit.Checked = false;
			}
			mnuPeakEdit.Click += mnuPeakEdit_Click;

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
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




