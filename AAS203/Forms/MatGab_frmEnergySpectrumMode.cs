using System.Threading;
using AAS203.Common;
using BgThread;
using System.IO;
using Microsoft.VisualBasic;
using AAS203.Spectrum;
//'This are the dll that has to include for Energy spectrum mode, like headers file's

//'this is a class behind a EnergySpectrum form
public class frmEnergySpectrumMode : System.Windows.Forms.Form, Iclient
{

	#Region " Private Variable "

	//--- Declaration for the controller object of the BgThread

	private BgThread.clsBgThread mobjController = new BgThread.clsBgThread(this);
	private clsBgSpectrum mobjclsBgSpectrum;
	//'this is a obj to the clsBgSpectrum class, a class that is used for calling a energy spectrum function and this function are run with in a thread and 


	//Public WithEvents Status As System.Windows.Forms.TextBox

	public System.Windows.Forms.TextBox Status;
	private double mdblFuelRatio = 0.0;

	private double dblBhHeight = 0.0;
	private bool mblnSpectrumStarted;
	private bool mblnAvoidProcessing = false;
	////----- Graph Items
	private double mdblYaxis;
	private double mdblXaxis;
	private AldysGraph.CurveItem mGraphCurveItem;
	private ArrayList ArrlstGraphCurveItem = new ArrayList();
	private int intCurveIndex = -1;
	private bool CheckMaxPosition = false;
	////-----
	private bool m_blnBaseline = true;
	private bool statStartGraph = false;

	private bool mAvoidProcessBtn;
	private struct _Data
	{
		bool mGraphPlot;
		int mXaxisData;
		int mYaxisData;
	}
	//Dim Data As _Data
	//--- declaration of the channels object (collection)
	private Spectrum.Channels mobjChannnels = new Spectrum.Channels();
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

	private frmEditValues mobjfrmEditValues;
		//Saurabh 11.08.07
	private bool blnActivateStartEnergySpectrum = false;

	private bool mblnReSetSpectrumParameter = false;
		#End Region
	private int m_bytCalibMode;

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

	#Region " Constant"
	private const  ConstFormLoad = "-Energy Spectrum Mode";
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

	#Region " Windows Form Designer generated code "
	//'*****This is realted to the .NET , this are used for graphics ....
	public frmEnergySpectrumMode()
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
	internal System.Windows.Forms.Label lblPMTVolts;
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
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuGraphOptions;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuPeakEdit;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuGrid;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuLegends;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuShowXYValues;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuStart;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuClearSpectrum;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuLampParameters;
	internal AAS203.AASGraph AASEnergySpectrum;
	internal NETXP.Controls.Bars.CommandBarButtonItem tlbbtnPrintGraph;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuPrintGraph;
	internal NETXP.Controls.Bars.CommandBarSeparatorItem CommandBarSeparatorItem6;
	internal NETXP.Controls.Bars.CommandBarButtonItem tlbbtnPeakEdit;
	internal NETXP.Controls.Bars.CommandBarButtonItem tlbbtnGrid;
	internal NETXP.Controls.Bars.CommandBarButtonItem tlbbtnShowXYValues;
	internal NETXP.Controls.Bars.CommandBarButtonItem tlbbtnLegends;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuChangeScale;
	internal NETXP.Controls.XPButton btnExtinguish;
	internal NETXP.Controls.XPButton btnIgnite;
	internal NETXP.Controls.XPButton btnN2OIgnite;
	internal NETXP.Controls.XPButton btnDelete;
	internal NETXP.Controls.XPButton btnR;
	internal System.Windows.Forms.Timer TimerEnergyDisplay;
	[System.Diagnostics.DebuggerStepThrough()]
	private void InitializeComponent()
	{
		this.components = new System.ComponentModel.Container();
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmEnergySpectrumMode));
		this.CustomPanelMain = new GradientPanel.CustomPanel();
		this.CustomPanelBottom = new GradientPanel.CustomPanel();
		this.cmdChangeScale = new NETXP.Controls.XPButton();
		this.btnStart = new NETXP.Controls.XPButton();
		this.btnLampParameters = new NETXP.Controls.XPButton();
		this.btnClearSpectrum = new NETXP.Controls.XPButton();
		this.btnReturn = new NETXP.Controls.XPButton();
		this.Office2003Header1 = new CodeIntellects.Office2003Controls.Office2003Header();
		this.CustomPanelTop = new GradientPanel.CustomPanel();
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
		this.btnDelete = new NETXP.Controls.XPButton();
		this.btnR = new NETXP.Controls.XPButton();
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
		this.mnuGraphOptions = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuPeakEdit = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuGrid = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuLegends = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuShowXYValues = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuChangeScale = new NETXP.Controls.Bars.CommandBarButtonItem();
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
		this.tlbbtnPrintGraph = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.CommandBarSeparatorItem5 = new NETXP.Controls.Bars.CommandBarSeparatorItem();
		this.tlbbtnPeakEdit = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.tlbbtnGrid = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.tlbbtnLegends = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.tlbbtnShowXYValues = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.tlbbtnChangeScale = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.CommandBarSeparatorItem6 = new NETXP.Controls.Bars.CommandBarSeparatorItem();
		this.tlbbtnPositionToMaxima = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.tlbbtnContiniousTimeScan = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.TimerEnergyDisplay = new System.Windows.Forms.Timer(this.components);
		this.CustomPanelMain.SuspendLayout();
		this.CustomPanelBottom.SuspendLayout();
		this.CustomPanelTop.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.MenuBarEnergySpectrumMode).BeginInit();
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
		this.CustomPanelMain.Controls.Add(this.btnDelete);
		this.CustomPanelMain.Controls.Add(this.btnR);
		this.CustomPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
		this.CustomPanelMain.Location = new System.Drawing.Point(0, 58);
		this.CustomPanelMain.Name = "CustomPanelMain";
		this.CustomPanelMain.Size = new System.Drawing.Size(804, 435);
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
		this.CustomPanelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
		this.CustomPanelBottom.Location = new System.Drawing.Point(196, 354);
		this.CustomPanelBottom.Name = "CustomPanelBottom";
		this.CustomPanelBottom.Size = new System.Drawing.Size(608, 81);
		this.CustomPanelBottom.TabIndex = 1;
		//
		//cmdChangeScale
		//
		this.cmdChangeScale.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.cmdChangeScale.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.cmdChangeScale.Image = (System.Drawing.Image)resources.GetObject("cmdChangeScale.Image");
		this.cmdChangeScale.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.cmdChangeScale.Location = new System.Drawing.Point(8, 28);
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
		this.btnStart.Location = new System.Drawing.Point(125, 28);
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
		this.btnLampParameters.Location = new System.Drawing.Point(242, 28);
		this.btnLampParameters.Name = "btnLampParameters";
		this.btnLampParameters.Size = new System.Drawing.Size(108, 38);
		this.btnLampParameters.TabIndex = 2;
		this.btnLampParameters.Text = "&Lamp Parameters";
		this.btnLampParameters.TextAlign = System.Drawing.ContentAlignment.TopLeft;
		this.btnLampParameters.Visible = false;
		//
		//btnClearSpectrum
		//
		this.btnClearSpectrum.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnClearSpectrum.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnClearSpectrum.Image = (System.Drawing.Image)resources.GetObject("btnClearSpectrum.Image");
		this.btnClearSpectrum.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnClearSpectrum.Location = new System.Drawing.Point(359, 28);
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
		//Office2003Header1
		//
		this.Office2003Header1.BackColor = System.Drawing.SystemColors.Control;
		this.Office2003Header1.Dock = System.Windows.Forms.DockStyle.Top;
		this.Office2003Header1.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.Office2003Header1.Location = new System.Drawing.Point(196, 0);
		this.Office2003Header1.Name = "Office2003Header1";
		this.Office2003Header1.Size = new System.Drawing.Size(608, 22);
		this.Office2003Header1.TabIndex = 47;
		this.Office2003Header1.TitleFont = new System.Drawing.Font("Tahoma", 10f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.Office2003Header1.TitleText = "Energy Spectrum";
		//
		//CustomPanelTop
		//
		this.CustomPanelTop.BackColor = System.Drawing.Color.AliceBlue;
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
		this.CustomPanelTop.Size = new System.Drawing.Size(196, 435);
		this.CustomPanelTop.TabIndex = 0;
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
		this.nudBurnerHeight.Location = new System.Drawing.Point(78, 205);
		this.nudBurnerHeight.MaxValue = 0;
		this.nudBurnerHeight.MinValue = 0;
		this.nudBurnerHeight.Name = "nudBurnerHeight";
		this.nudBurnerHeight.Size = new System.Drawing.Size(72, 22);
		this.nudBurnerHeight.TabIndex = 17;
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
		this.nudHCLCur.Location = new System.Drawing.Point(78, 72);
		this.nudHCLCur.MaxValue = 0;
		this.nudHCLCur.MinValue = 0;
		this.nudHCLCur.Name = "nudHCLCur";
		this.nudHCLCur.Size = new System.Drawing.Size(72, 22);
		this.nudHCLCur.TabIndex = 5;
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
		this.nudD2Cur.Location = new System.Drawing.Point(78, 104);
		this.nudD2Cur.MaxValue = 0;
		this.nudD2Cur.MinValue = 0;
		this.nudD2Cur.Name = "nudD2Cur";
		this.nudD2Cur.Size = new System.Drawing.Size(72, 22);
		this.nudD2Cur.TabIndex = 8;
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
		this.nudSlit.Location = new System.Drawing.Point(78, 136);
		this.nudSlit.MaxValue = 0;
		this.nudSlit.MinValue = 0;
		this.nudSlit.Name = "nudSlit";
		this.nudSlit.Size = new System.Drawing.Size(72, 22);
		this.nudSlit.TabIndex = 11;
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
		this.nudFuelRatio.Location = new System.Drawing.Point(78, 168);
		this.nudFuelRatio.MaxValue = 0;
		this.nudFuelRatio.MinValue = 0;
		this.nudFuelRatio.Name = "nudFuelRatio";
		this.nudFuelRatio.Size = new System.Drawing.Size(72, 22);
		this.nudFuelRatio.TabIndex = 14;
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
		this.nudPMT.Location = new System.Drawing.Point(78, 40);
		this.nudPMT.MaxValue = 0;
		this.nudPMT.MinValue = 0;
		this.nudPMT.Name = "nudPMT";
		this.nudPMT.Size = new System.Drawing.Size(72, 22);
		this.nudPMT.TabIndex = 0;
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
		this.HeaderLeft.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.HeaderLeft.Location = new System.Drawing.Point(0, 0);
		this.HeaderLeft.Name = "HeaderLeft";
		this.HeaderLeft.Size = new System.Drawing.Size(196, 22);
		this.HeaderLeft.TabIndex = 11;
		this.HeaderLeft.TitleFont = new System.Drawing.Font("Tahoma", 10f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.HeaderLeft.TitleText = "Energy Parameters";
		//
		//lblYValue
		//
		this.lblYValue.BackColor = System.Drawing.Color.White;
		this.lblYValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblYValue.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblYValue.ForeColor = System.Drawing.Color.Blue;
		this.lblYValue.Location = new System.Drawing.Point(6, 398);
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
		this.lblWvPos.Location = new System.Drawing.Point(6, 368);
		this.lblWvPos.Name = "lblWvPos";
		this.lblWvPos.Size = new System.Drawing.Size(166, 20);
		this.lblWvPos.TabIndex = 44;
		this.lblWvPos.Text = "Wavelength (nm) : ";
		this.lblWvPos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//lblBurnerHeightmm
		//
		this.lblBurnerHeightmm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblBurnerHeightmm.Location = new System.Drawing.Point(152, 213);
		this.lblBurnerHeightmm.Name = "lblBurnerHeightmm";
		this.lblBurnerHeightmm.Size = new System.Drawing.Size(24, 20);
		this.lblBurnerHeightmm.TabIndex = 36;
		this.lblBurnerHeightmm.Text = "mm";
		//
		//lblBurnerHeight
		//
		this.lblBurnerHeight.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblBurnerHeight.Location = new System.Drawing.Point(10, 209);
		this.lblBurnerHeight.Name = "lblBurnerHeight";
		this.lblBurnerHeight.Size = new System.Drawing.Size(62, 20);
		this.lblBurnerHeight.TabIndex = 34;
		this.lblBurnerHeight.Text = "Burner Ht.";
		this.lblBurnerHeight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//lblFuelRatio
		//
		this.lblFuelRatio.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblFuelRatio.Location = new System.Drawing.Point(10, 174);
		this.lblFuelRatio.Name = "lblFuelRatio";
		this.lblFuelRatio.Size = new System.Drawing.Size(62, 20);
		this.lblFuelRatio.TabIndex = 32;
		this.lblFuelRatio.Text = "Fuel Ratio";
		this.lblFuelRatio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//lblHCLCurmA
		//
		this.lblHCLCurmA.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblHCLCurmA.Location = new System.Drawing.Point(152, 79);
		this.lblHCLCurmA.Name = "lblHCLCurmA";
		this.lblHCLCurmA.Size = new System.Drawing.Size(26, 18);
		this.lblHCLCurmA.TabIndex = 31;
		this.lblHCLCurmA.Text = "mA";
		this.lblHCLCurmA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//lblHCLCur
		//
		this.lblHCLCur.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblHCLCur.Location = new System.Drawing.Point(10, 78);
		this.lblHCLCur.Name = "lblHCLCur";
		this.lblHCLCur.Size = new System.Drawing.Size(57, 20);
		this.lblHCLCur.TabIndex = 30;
		this.lblHCLCur.Text = "HCL Cur";
		this.lblHCLCur.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//lblSlitWidthnm
		//
		this.lblSlitWidthnm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblSlitWidthnm.Location = new System.Drawing.Point(152, 143);
		this.lblSlitWidthnm.Name = "lblSlitWidthnm";
		this.lblSlitWidthnm.Size = new System.Drawing.Size(24, 18);
		this.lblSlitWidthnm.TabIndex = 28;
		this.lblSlitWidthnm.Text = "nm";
		this.lblSlitWidthnm.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//lblPMTVolts
		//
		this.lblPMTVolts.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblPMTVolts.Location = new System.Drawing.Point(152, 47);
		this.lblPMTVolts.Name = "lblPMTVolts";
		this.lblPMTVolts.Size = new System.Drawing.Size(32, 18);
		this.lblPMTVolts.TabIndex = 27;
		this.lblPMTVolts.Text = "volts";
		this.lblPMTVolts.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//lblD2CurmA
		//
		this.lblD2CurmA.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblD2CurmA.Location = new System.Drawing.Point(152, 112);
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
		this.cmbModes.Location = new System.Drawing.Point(78, 274);
		this.cmbModes.Name = "cmbModes";
		this.cmbModes.Size = new System.Drawing.Size(82, 21);
		this.cmbModes.TabIndex = 19;
		this.cmbModes.Visible = false;
		//
		//lblModes
		//
		this.lblModes.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblModes.Location = new System.Drawing.Point(10, 276);
		this.lblModes.Name = "lblModes";
		this.lblModes.Size = new System.Drawing.Size(57, 20);
		this.lblModes.TabIndex = 8;
		this.lblModes.Text = "Modes";
		this.lblModes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//lblSpeed
		//
		this.lblSpeed.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblSpeed.Location = new System.Drawing.Point(10, 243);
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
		this.cmbSpeed.Location = new System.Drawing.Point(78, 240);
		this.cmbSpeed.Name = "cmbSpeed";
		this.cmbSpeed.Size = new System.Drawing.Size(82, 21);
		this.cmbSpeed.TabIndex = 18;
		this.cmbSpeed.Visible = false;
		//
		//lblSlitWidth
		//
		this.lblSlitWidth.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblSlitWidth.Location = new System.Drawing.Point(10, 142);
		this.lblSlitWidth.Name = "lblSlitWidth";
		this.lblSlitWidth.Size = new System.Drawing.Size(57, 20);
		this.lblSlitWidth.TabIndex = 5;
		this.lblSlitWidth.Text = "Slit Width";
		this.lblSlitWidth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//lblD2Cur
		//
		this.lblD2Cur.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblD2Cur.Location = new System.Drawing.Point(10, 108);
		this.lblD2Cur.Name = "lblD2Cur";
		this.lblD2Cur.Size = new System.Drawing.Size(57, 20);
		this.lblD2Cur.TabIndex = 2;
		this.lblD2Cur.Text = "D2 Cur";
		this.lblD2Cur.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//lblPMT
		//
		this.lblPMT.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblPMT.Location = new System.Drawing.Point(10, 45);
		this.lblPMT.Name = "lblPMT";
		this.lblPMT.Size = new System.Drawing.Size(57, 20);
		this.lblPMT.TabIndex = 10;
		this.lblPMT.Text = "PMT";
		this.lblPMT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//AASEnergySpectrum
		//
		this.AASEnergySpectrum.AldysGraphCursor = null;
		this.AASEnergySpectrum.AldysGraphPrintColor = System.Drawing.Color.Black;
		this.AASEnergySpectrum.Anchor = (System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right;
		this.AASEnergySpectrum.BackColor = System.Drawing.Color.LightGray;
		this.AASEnergySpectrum.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.AASEnergySpectrum.GraphDataSource = null;
		this.AASEnergySpectrum.GraphImage = null;
		this.AASEnergySpectrum.IsShowGrid = true;
		this.AASEnergySpectrum.Location = new System.Drawing.Point(196, 20);
		this.AASEnergySpectrum.Name = "AASEnergySpectrum";
		this.AASEnergySpectrum.Size = new System.Drawing.Size(606, 333);
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
		this.btnExtinguish.Location = new System.Drawing.Point(376, 209);
		this.btnExtinguish.Name = "btnExtinguish";
		this.btnExtinguish.Size = new System.Drawing.Size(52, 18);
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
		this.btnIgnite.Location = new System.Drawing.Point(380, 210);
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
		this.btnN2OIgnite.Location = new System.Drawing.Point(400, 216);
		this.btnN2OIgnite.Name = "btnN2OIgnite";
		this.btnN2OIgnite.Size = new System.Drawing.Size(5, 5);
		this.btnN2OIgnite.TabIndex = 50;
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
		this.btnDelete.Location = new System.Drawing.Point(608, 232);
		this.btnDelete.Name = "btnDelete";
		this.btnDelete.Size = new System.Drawing.Size(8, 8);
		this.btnDelete.TabIndex = 52;
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
		this.btnR.Location = new System.Drawing.Point(620, 232);
		this.btnR.Name = "btnR";
		this.btnR.Size = new System.Drawing.Size(8, 8);
		this.btnR.TabIndex = 51;
		this.btnR.TabStop = false;
		this.btnR.Text = "&R";
		this.btnR.TextAlign = System.Drawing.ContentAlignment.TopLeft;
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
		this.mnuLampParameters.Text = "Lamp Parameters";
		//
		//mnuSmooth
		//
		this.mnuSmooth.Image = (System.Drawing.Image)resources.GetObject("mnuSmooth.Image");
		this.mnuSmooth.Shortcut = System.Windows.Forms.Shortcut.CtrlM;
		this.mnuSmooth.Text = "&Smooth";
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
		this.mnuClearSpectrum.Text = "&Clear Spectrum";
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
		this.mnuParameters.Text = "&Parameters";
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
		this.MenuBarEnergySpectrumMode.CustomizeText = "&Customize Toolbar...";
		this.MenuBarEnergySpectrumMode.Dock = System.Windows.Forms.DockStyle.Top;
		this.MenuBarEnergySpectrumMode.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
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
		this.MenuBarEnergySpectrumMode.Size = new System.Drawing.Size(804, 24);
		this.MenuBarEnergySpectrumMode.Style = NETXP.Controls.Bars.CommandBarStyle.Menu;
		this.MenuBarEnergySpectrumMode.TabIndex = 1;
		this.MenuBarEnergySpectrumMode.TabStop = false;
		this.MenuBarEnergySpectrumMode.Text = "";
		//
		//mnuGraphOptions
		//
		this.mnuGraphOptions.Items.AddRange(new NETXP.Controls.Bars.CommandBarItem[] {
			this.mnuPeakEdit,
			this.mnuGrid,
			this.mnuLegends,
			this.mnuShowXYValues,
			this.mnuChangeScale
		});
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
		this.mnuShowXYValues.Text = "Show X, Y &Values";
		//
		//mnuChangeScale
		//
		this.mnuChangeScale.Image = (System.Drawing.Image)resources.GetObject("mnuChangeScale.Image");
		this.mnuChangeScale.Text = "Change Scale";
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
		this.StatusBar1.Location = new System.Drawing.Point(0, 493);
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
		this.StatusBarPanelInfo.Width = 509;
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
		this.StatusBarPanelDate.Text = "Current Date";
		this.StatusBarPanelDate.Width = 79;
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
			this.tlbbtnPrintGraph,
			this.CommandBarSeparatorItem5,
			this.tlbbtnPeakEdit,
			this.tlbbtnGrid,
			this.tlbbtnLegends,
			this.tlbbtnShowXYValues,
			this.tlbbtnChangeScale,
			this.CommandBarSeparatorItem6,
			this.tlbbtnPositionToMaxima,
			this.tlbbtnContiniousTimeScan
		});
		this.ToolBar.Location = new System.Drawing.Point(0, 24);
		this.ToolBar.Margins.Bottom = 1;
		this.ToolBar.Margins.Left = 1;
		this.ToolBar.Margins.Right = 1;
		this.ToolBar.Margins.Top = 1;
		this.ToolBar.MenuEnabled = false;
		this.ToolBar.Name = "ToolBar";
		this.ToolBar.Size = new System.Drawing.Size(804, 34);
		this.ToolBar.TabIndex = 0;
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
		this.tlbbtnLoadspectrumFile.Shortcut = System.Windows.Forms.Shortcut.CtrlL;
		this.tlbbtnLoadspectrumFile.Text = "LOAD SPECTRUM FILE[CTRL+L]";
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
		this.tlbbtnLampParameters.Shortcut = System.Windows.Forms.Shortcut.CtrlA;
		this.tlbbtnLampParameters.Text = "LAMP PARAMETERES[CTRL+A]";
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
		//tlbbtnPrintGraph
		//
		this.tlbbtnPrintGraph.Image = (System.Drawing.Image)resources.GetObject("tlbbtnPrintGraph.Image");
		this.tlbbtnPrintGraph.Shortcut = System.Windows.Forms.Shortcut.CtrlG;
		this.tlbbtnPrintGraph.Text = "PRINT GRAPH[CTRL+G]";
		//
		//tlbbtnPeakEdit
		//
		this.tlbbtnPeakEdit.Image = (System.Drawing.Image)resources.GetObject("tlbbtnPeakEdit.Image");
		this.tlbbtnPeakEdit.Shortcut = System.Windows.Forms.Shortcut.CtrlE;
		this.tlbbtnPeakEdit.Text = "PEAK EDIT[CTRL+E]";
		//
		//tlbbtnGrid
		//
		this.tlbbtnGrid.Image = (System.Drawing.Image)resources.GetObject("tlbbtnGrid.Image");
		this.tlbbtnGrid.Shortcut = System.Windows.Forms.Shortcut.CtrlI;
		this.tlbbtnGrid.Text = "GRID[CTRL+I]";
		//
		//tlbbtnLegends
		//
		this.tlbbtnLegends.Image = (System.Drawing.Image)resources.GetObject("tlbbtnLegends.Image");
		this.tlbbtnLegends.Shortcut = System.Windows.Forms.Shortcut.CtrlD;
		this.tlbbtnLegends.Text = "LEGENDS[CTRL+D]";
		//
		//tlbbtnShowXYValues
		//
		this.tlbbtnShowXYValues.Image = (System.Drawing.Image)resources.GetObject("tlbbtnShowXYValues.Image");
		this.tlbbtnShowXYValues.Shortcut = System.Windows.Forms.Shortcut.CtrlO;
		this.tlbbtnShowXYValues.Text = "SHOW X, Y VALUES[CTRL+O]";
		//
		//tlbbtnChangeScale
		//
		this.tlbbtnChangeScale.Image = (System.Drawing.Image)resources.GetObject("tlbbtnChangeScale.Image");
		this.tlbbtnChangeScale.Shortcut = System.Windows.Forms.Shortcut.CtrlH;
		this.tlbbtnChangeScale.Text = "CHANGE SCALE";
		//
		//tlbbtnPositionToMaxima
		//
		this.tlbbtnPositionToMaxima.Image = (System.Drawing.Image)resources.GetObject("tlbbtnPositionToMaxima.Image");
		this.tlbbtnPositionToMaxima.Shortcut = System.Windows.Forms.Shortcut.CtrlX;
		this.tlbbtnPositionToMaxima.Text = "POSITION TO MAXIMA[CTRL+X]";
		//
		//tlbbtnContiniousTimeScan
		//
		this.tlbbtnContiniousTimeScan.Image = (System.Drawing.Image)resources.GetObject("tlbbtnContiniousTimeScan.Image");
		this.tlbbtnContiniousTimeScan.Shortcut = System.Windows.Forms.Shortcut.CtrlN;
		this.tlbbtnContiniousTimeScan.Text = "CONTINIOUS TIME SCAN[CTRL+N]";
		//
		//TimerEnergyDisplay
		//
		this.TimerEnergyDisplay.Interval = 1000;
		//
		//frmEnergySpectrumMode
		//
		this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
		this.ClientSize = new System.Drawing.Size(804, 517);
		this.Controls.Add(this.CustomPanelMain);
		this.Controls.Add(this.StatusBar1);
		this.Controls.Add(this.ToolBar);
		this.Controls.Add(this.MenuBarEnergySpectrumMode);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		this.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		this.MinimizeBox = false;
		this.Name = "frmEnergySpectrumMode";
		this.ShowInTaskbar = false;
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Energy Spectrum Mode";
		this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
		this.CustomPanelMain.ResumeLayout(false);
		this.CustomPanelBottom.ResumeLayout(false);
		this.CustomPanelTop.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.MenuBarEnergySpectrumMode).EndInit();
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
		//=====================================================================
		// Procedure Name        : frmEnergySpectrumMode_Load
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : this will handle a load event of a form.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 
		// Revisions             : praveen
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		//'note:
		//'This Event call whenever energyspectrum from is display first.
		//'this is called when form is loaded


		//'this is use for Exception handling
		try {
			//-----Saurabh---23.06.07
			if (gstructSettings.AppMode == EnumAppMode.FullVersion_201) {
				//'This cond is check for 201 instrument .if this cond is true then this two button should be hide.
				btnIgnite.Visible = false;
				btnExtinguish.Visible = false;
			}
			//-----Saurabh---23.06.07
			cmdChangeScale.BringToFront();
			btnStart.BringToFront();

			if (mblnAvoidProcessing == true) {
				//'this is a global flag to check whatever process should be avoided or not.

				return;
			}
			mblnAvoidProcessing = true;
			//'func_Enable_Disable() function is called for enable/disable a control on the screen,
			func_Enable_Disable(EnumProcesses.FormInitialize, EnumStart_End.Start_of_Process);
			//'for enable\disable a control.
			ShowProgressBar(gstrTitleInstrumentType + ConstFormLoad);
			//'This function shows the information on status bar like instrument type ect..
			gobjclsTimer.subTimerStart(StatusBar1);
			//'this will start a timer

			//If Not (gstructSettings.AppMode = EnumAppMode.DemoMode) Then
			//    gobjfrmStatus.Visible = False
			//End If
			MenuBarEnergySpectrumMode.BackColor = System.Drawing.Color.Gainsboro;
			//'set a menu bar color
			cmdChangeScale.Focus();
			//'set the focus on Change scale button

			funcInitialise();
			//'this will call a initialise function ,where software perfrom some initial task

			HideProgressBar();
			//'for hide progress
			//Saurabh 10.07.07 To bring status form in front
			gobjfrmStatus.Show();
		//show the status from 
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
			mblnAvoidProcessing = false;

			if (!objWait == null) {
				objWait.Dispose();
			}
			mblnAvoidProcessing = false;
			Application.DoEvents();
			//'allow application to perfrom its panding work.
			//---------------------------------------------------------
		}
	}

	private void  // ERROR: Handles clauses are not supported in C#
frmEnergySpectrumMode_Closing(object sender, System.ComponentModel.CancelEventArgs e)
	{
		//=====================================================================
		// Procedure Name        : frmEnergySpectrumMode_Closing
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : this will handle a closing event of a form.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 
		// Revisions             : praveen
		//=====================================================================
		//        Call gobjMessageAdapter.ShowMessage(constCuvetteBurner)
		//'note:
		//'this will called when energy spectrum mode is closed


		try {

			if (mblnAvoidProcessing == true) {
				//'check flag for Avoiding a process.
				e.Cancel = true;
				return;
			}
			////---- Added by Sachin Dokhale. Stop the Timer Energy Display when closing the mode
			TimerEnergyDisplay.Enabled = false;
			////---- Added by Sachin Dokhale Set the previous default Calibration mode
			gobjCommProtocol.funcCalibrationMode(m_bytCalibMode);

			//If Not (gstructSettings.AppMode = EnumAppMode.DemoMode) Then
			if (!((gstructSettings.AppMode == EnumAppMode.DemoMode) | (gstructSettings.AppMode == EnumAppMode.DemoMode_201) | (gstructSettings.AppMode == EnumAppMode.DemoMode_203D))) {
				//'for demo mode.
				gobjfrmStatus.Visible = true;
			}
			if (!gobjclsTimer == null) {
				gobjclsTimer.subTimerStop();
				//'for stoping a timer
			}
			//Saurabh 08.08.07
			if (!gstructSettings.ExeToRun == EnumApplicationMode.ServiceUtility) {
				if (!IsNothing(gobjMain)) {
					//gobjmain is a global object of main screen (MainMDI from)
					if (gobjMain.mobjController.IsThreadRunning == false) {
						//'stop previous thread and start flame status thread.
						gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay);
						Application.DoEvents();
						gobjMain.mobjController.Start(gobjclsBgFlameStatus);
					}
					gobjfrmStatus.Visible = true;
					//'make status from visible

				}
			}
			//Saurabh 08.08.07
			Application.DoEvents();
		//'allow application to perfrom its panding work.
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
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
		//'note:
		//'this is called when user click on menu exit 
		//'here we need to do some finishing task for eg stoping a timer
		CWaitCursor objWait = new CWaitCursor();
		try {
			if (mblnAvoidProcessing == true) {
				//'check flag for avoiding a process
				return;
			}
			////---- Added by Sachin Dokhale. Stop the Timer Energy Display when closing the mode
			TimerEnergyDisplay.Enabled = false;
			gobjclsTimer.subTimerStop();
			//'stop a timer.
			this.DialogResult = DialogResult.OK;
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
		// Purpose               : to save a spectrum file on disk
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 15.11.06
		// Revisions             : 
		//=====================================================================

		//'note:
		//'whatevr the spectrum if user want to save that 
		//'then this can be done
		SaveFileDialog SaveFileDialog1 = new SaveFileDialog();
		CWaitCursor objWait = new CWaitCursor();

		try {
			if ((gstructSettings.Enable21CFR == true)) {
				if (!funcCheckActivityAuthentication(enumActivityAuthentication.SaveFile, gstructUserDetails.Access)) {
					//'check for user authentication
					return;
				}
				gfuncInsertActivityLog(EnumModules.SaveFile, "Save Spectrum File Accessed");
				//'insert a log.
			}
			if (mblnAvoidProcessing == true) {
				//'check a flag for avoiding a process.
				return;
			}
			mblnAvoidProcessing = true;
			//SaveFileDialog1.Filter = "Energy Spectrum File(*.spt)|*.spt"
			//SaveFileDialog1.Title = "Show an Energy Spectrum File"
			//SaveFileDialog1.ShowDialog()
			funcSaveSpectrumFile();
		//'this is  a main function for saving a spectrum on disk
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
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
		// Purpose               : to load a spectrum file from disk.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 15.11.06
		// Revisions             : 
		//=====================================================================
		//'note:
		//'this is used to load a spectrum file from disk to current energy mode 
		//'with all its data  for futher processing.

		OpenFileDialog OpenFileDialog1 = new OpenFileDialog();
		//'object for filedialog
		CWaitCursor objWait = new CWaitCursor();
		try {
			if ((gstructSettings.Enable21CFR == true)) {
				//'check for 21 CFR
				if (!funcCheckActivityAuthentication(enumActivityAuthentication.LoadFile, gstructUserDetails.Access)) {
					//'check for user authentication
					return;
				}
				gfuncInsertActivityLog(EnumModules.LoadFile, "Load Spectrum File Accessed");
				//'insert a log
			}
			if (mblnAvoidProcessing == true) {
				//'check for flag to avoid a process.
				return;
			}
			mblnAvoidProcessing = true;

			//OpenFileDialog1.Filter = "Energy Spectrum File(*.spt)|*.spt"
			//OpenFileDialog1.Title = "Show an Energy Spectrum File"
			//OpenFileDialog1.ShowDialog()
			funcLoadSpectrumFile();
		//'this is a function for load spectrum file.


		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
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
		// Purpose               : this is called when user click on Abs ot T.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 15.11.06
		// Revisions             : 
		//=====================================================================
		//'note:
		//'this is called when user clicked on abs to T menu.
		CWaitCursor objWait = new CWaitCursor();

		try {

			if (mblnAvoidProcessing == true) {
				//'check flag for avoiding a flag.
				return;
			}
			mblnAvoidProcessing = true;
			funcAbsConvertTransmission();
		//'call this function for convertion

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
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
		// Purpose               : this function is called for displaying a smooth graph
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 15.11.06
		// Revisions             : 
		//=====================================================================

		//'note;
		//'this is called when user clicked on smooth menu.
		CWaitCursor objWait = new CWaitCursor();
		///this is a obj of CWaitCursor class to which we have to use later


		try {
			subSmoothGraph();
		//'this is a main function for smoothing

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
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
		// Purpose               : to load a TimeScan from
		// Description           : this is a event that call a time scan mode screen
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 25.09.06
		// Revisions             : 
		//=====================================================================

		object objfrmTimeScan;
		//frmTimeScanMode
		CWaitCursor objWait = new CWaitCursor();

		try {
			if ((gstructSettings.Enable21CFR == true)) {
				if (!funcCheckActivityAuthentication(enumActivityAuthentication.Time_Scan, gstructUserDetails.Access)) {
					//'this function is check for user authentication 
					//'its check whatever user has a rule or not.
					return;
				}
				gfuncInsertActivityLog(EnumModules.TimeScan, "Energy Spectrum Mode->TimeScan_Mode Accessed");
				//'insert activity log.
			}
			////---- Added by Sachin Dokhale. Stop the Timer Energy Display 
			TimerEnergyDisplay.Enabled = false;
			gintSpectrumMode = modGlobalDeclarations.EnumSpectrumMode.TimeScan;
			//'get a spectrum mode.
			if (gstructSettings.AppMode == EnumAppMode.FullVersion_203D) {
				//'for 203D
				if (gintInstrumentBeamType == AAS203Library.Instrument.enumInstrumentBeamType.SingleBeam | gintInstrumentBeamType == AAS203Library.Instrument.enumInstrumentBeamType.ReferenceBeam) {
					//'check for a beam type

					//objfrmTimeScan = New frmTimeScanMode
					objfrmTimeScan = new frmTimeScanDBMode();
				} else {
					objfrmTimeScan = new frmTimeScanDBMode();
				}
			////---- modify by Sachin Dokhale
			} else if (gstructSettings.AppMode == EnumAppMode.FullVersion_203 | gstructSettings.AppMode == EnumAppMode.FullVersion_201) {
				//'for 203 and 201 instrument
				objfrmTimeScan = new frmTimeScanMode();
			} else {
				//'else get a beam type.

				if (gintInstrumentBeamType == AAS203Library.Instrument.enumInstrumentBeamType.DoubleBeam) {
					objfrmTimeScan = new frmTimeScanDBMode();
				} else {
					//objfrmTimeScan = New frmTimeScanMode
					objfrmTimeScan = new frmTimeScanDBMode();
				}
				////-----
			}
			gobjclsTimer.subTimerStop();
			//'for stoping a timer 
			objfrmTimeScan.ShowDialog();
			//'for shoeing a dialog
			mblnReSetSpectrumParameter = true;
			//'set a flag for easeting a spectrum parameter.
			funcGetInstParameter();
			//'function for getting instrument current parameter
			funcSetSpectrumParameter(gobjInst.Mode);
			//'function for setting spectrum parameter as par given mode
			gintSpectrumMode = modGlobalDeclarations.EnumSpectrumMode.EnergySpectrum;
			//'--- get a spectrum mode as energy
			gobjclsTimer.subTimerStart(StatusBar1);
			//'start a timer
			gobjfrmStatus.Visible = true;
			////---- Added by Sachin Dokhale. Start the Timer Energy Display 
			TimerEnergyDisplay.Enabled = true;
			//'set status form to visible
			Application.DoEvents();
		//'allow application to perfrom its panding work.
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
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
		// Purpose               : to start a scanning
		// Description           : this function is called when user clicked on Start Button.
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 07.10.06
		// Revisions             : Praveen S Deshmukh on 16.05.07
		//=====================================================================
		//'note:
		//'this is called when user clicked on start button
		//'this is used to start the scan for energy spectrum.


		try {
			//mblnSpectrumStarted is a bool flag which show whatever spectrum is started or not.
			if (mAvoidProcessBtn == true) {
				return;
			}
			mAvoidProcessBtn = true;
			////---- Added by Sachin Dokhale. Stop the Timer Energy Display 
			TimerEnergyDisplay.Enabled = false;
			if (mblnSpectrumStarted == false) {
				subStartScan();
			//this is a function for start a scan 
			} else {
				subStopScan();
				//this is a function for stop a scan
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
		// Purpose               : this is called when user click on Lampparameter button
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 07.10.06
		// Revisions             : 
		//=====================================================================

		try {
			//*************************************************
			//----Commented By Mangesh on 20-Apr-2007
			//*************************************************
			//mblnAvoidProcessing = True
			//*************************************************
			//If gobjMain.mobjController.IsThreadRunning = True Then
			//    gobjMain.mobjController.Cancel()
			//    ''stop the thread if any running
			//    gobjCommProtocol.mobjCommdll.subTime_Delay(500)   '10.12.07
			//    Application.DoEvents()
			//End If
			if (ReInitLampInstParameters == true) {
				return;
			}
			////---- Added by Sachin Dokhale. Stop the Timer Energy Display 
			TimerEnergyDisplay.Enabled = false;
			subLampParameterChanged();
			//'this is call for changing a lamp parameter
			//If gobjMain.mobjController.IsThreadRunning = False Then
			//    gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay)
			//    Application.DoEvents()
			//    gobjMain.mobjController.Start(gobjclsBgFlameStatus)
			//    ''stop a previous thread and start a flamestatus thread
			//End If
			////---- Added by Sachin Dokhale. Start the Timer Energy Display 
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
			//mblnAvoidProcessing = False
			btnLampParameters.Focus();
			//If gobjMain.mobjController.IsThreadRunning = True Then
			//    gobjMain.mobjController.Cancel()
			//    gobjCommProtocol.mobjCommdll.subTime_Delay(500)   '10.12.07
			//    Application.DoEvents()
			//End If
			//Application.DoEvents()
			//---------------------------------------------------------
		}
	}

	private void btnClearSpectrum_Click(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : btnClearSpectrum_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : to clear a spectrum
		// Description           : this is called when user cliak on Clear spectrum button
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 07.10.06
		// Revisions             : 
		//=====================================================================
		//'note:
		//'this is used to clear the spectrum .
		CWaitCursor objWait = new CWaitCursor();
		try {
			subClearScan();
			//'this is a function for clearing a spectrum
			AASEnergySpectrum.RemoveHighPeakLineLabel();
			//'for removing a label from spectrum
			this.AASEnergySpectrum.disablePeakEdit();
		//'for disable a peakedit option
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
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

			//'allow application to perfrom its panding work
			//---------------------------------------------------------
		}
	}

	private void mnuPeakPick_Click(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : mnuPeakPick_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To locate a peakpick on spectrum
		// Description           : this is called when user click on peakpick menu.
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 07.10.06
		// Revisions             : 
		//=====================================================================
		subPeakValley();
		//'show a peak valley

	}

	private void cmbSpeed_SelectedIndexChanged(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : cmbSpeed_SelectedIndexChanged
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : this is called when user changed a speed in a combo box
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 12.12.06
		// Revisions             : 
		//=====================================================================

		//'note:
		//'this is called whenever user  change the speed in combobox.
		CWaitCursor objWait = new CWaitCursor();
		try {
			if (mblnAvoidProcessing == true) {
				//'for avoiding a process
				return;
			}

			mblnAvoidProcessing = true;

			cmbSpeed.SelectedIndexChanged -= cmbSpeed_SelectedIndexChanged;

			if (funcSetSpeed(cmbSpeed.SelectedIndex) == true) {
				//'this is a function that set new speed to the instrument
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

	private void cmdChangeScale_Click(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : cmdChangeScale_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : 
		// Description           : this is called when user click on change scale buton.
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 21.11.06
		// Revisions             : 
		//=====================================================================
		//'note;
		//'this is called when user click on change scale button

		CWaitCursor objWait = new CWaitCursor();
		frmChangeScale objfrmChangeScale;
		//'this is a obj to a change scale form
		try {
			if (mblnAvoidProcessing == true) {
				//'check a flag for avoiding a process.
				return;
			}
			mblnAvoidProcessing = true;
			////---- Added by Sachin Dokhale. Stop the Timer Energy Display 
			TimerEnergyDisplay.Enabled = false;
			objfrmChangeScale = new frmChangeScale(mobjParameters, true);
			//'call a constructor of frmchangescale
			objfrmChangeScale.funcSetValidatingScale(gobjInst.Mode);
			//'check a validation of given scale as par given mode
			//'here gobjInst.Mode is a obj to structure that contains a different modes 
			if (objfrmChangeScale.ShowDialog() == DialogResult.OK) {
				////---- Added by Sachin Dokhale. Stop the Timer Energy Display 
				TimerEnergyDisplay.Enabled = false;
				//'this will show a change scale form
				//'SpectrumParameter  is a public obj of change scale class which contain some parameter for graph
				if (!objfrmChangeScale.SpectrumParameter == null) {
					//If mobjParameters.XaxisMax < objfrmChangeScale.SpectrumParameter.XaxisMax Then

					//End If

					//If mobjParameters.XaxisMin > objfrmChangeScale.SpectrumParameter.XaxisMin Then

					//End If
					//mobjParameters is a object to a energy spectrum
					//'which hold a parameter for energy spectrum

					//'get a user defined value from form to mobjParameters 
					mobjParameters.XaxisMax = objfrmChangeScale.SpectrumParameter.XaxisMax;
					//'get Xmax 
					mobjParameters.XaxisMin = objfrmChangeScale.SpectrumParameter.XaxisMin;
					//'get Xmin
					mobjParameters.YaxisMax = objfrmChangeScale.SpectrumParameter.YaxisMax;
					//'get Ymax 
					mobjParameters.YaxisMin = objfrmChangeScale.SpectrumParameter.YaxisMin;
					///'get Ymin 
					//---08.05.08
					WvStartRange = mobjParameters.XaxisMin;
					WvLastRange = mobjParameters.XaxisMax;
					//lblWvPos.Text = Format(mobjParameters.XaxisMin, "0.0")
					lblWvPos.Text = mXValueLable + gobjInst.WavelengthCur;
					//'get a wavelength 
					if (!funcGraphPreRequisite(mobjParameters.Cal_Mode, mobjParameters.XaxisMin, mobjParameters.XaxisMax, mobjParameters.YaxisMin, mobjParameters.YaxisMax)) {
						//'this function set a prerequisite for a energy spectrum graph

						//Call gFuncShowMessage("Error in setting spectrum parameters", "Please Check Entered Spectrum Parameters", modConstants.EnumMessageType.Information)
						return;
					}
				}
				// ------------Added By Pankaj on 8 May 07
				//AASEnergySpectrum is a object of energy spectrum graph control

				//'set parameter to energy spectrum.

				AASEnergySpectrum.XAxisMin = mobjParameters.XaxisMin;
				AASEnergySpectrum.XAxisMax = mobjParameters.XaxisMax;

				AASEnergySpectrum.YAxisMin = mobjParameters.YaxisMin;
				AASEnergySpectrum.YAxisMax = mobjParameters.YaxisMax;

				gobjClsAAS203.Calculate_Analysis_Graph_Param(AASEnergySpectrum, ClsAAS203.enumChangeAxis.xyAxis);
				//'for calculating a analysis graph parameter.

				//--------------
			}
			objfrmChangeScale.Close();
			////---- Added by Sachin Dokhale. Start the Timer Energy Display 
			TimerEnergyDisplay.Enabled = true;
		//'this will close the change scale form



		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			if (!(objfrmChangeScale == null)) {
				objfrmChangeScale.Dispose();
				objfrmChangeScale = null;
			}
			if (!objWait == null) {
				objWait.Dispose();
			}
			mblnAvoidProcessing = false;
			cmdChangeScale.Focus();
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
		// Description           : this is called when user called on parameter menu
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 13.02.06
		// Revisions             : 
		//=====================================================================
		//'note:
		//'this is called when user clicked on parameter menu.
		//'this will show the dialog of parameter.

		CWaitCursor objWait = new CWaitCursor();
		frmParameter objfrmParameter;
		try {
			if (mblnAvoidProcessing == true) {
				//'check a flag for avoiding a process.
				return;
			}
			mblnAvoidProcessing = true;

			objfrmParameter = new frmParameter(mobjParameters);
			//'initialise a object of parameter form.
			if (objfrmParameter.ShowDialog() == DialogResult.OK) {
				//'showing a parameter dialog
				if (!objfrmParameter.SpectrumParameter == null) {
					//'if object having a some parameter then
					if (mobjParameters == null) {
						mobjParameters = new Spectrum.EnergySpectrumParameter();
						//'initialise a object.
					}
					mobjParameters.SpectrumName = objfrmParameter.SpectrumParameter.SpectrumName;
					//'get a spectrum name to data structure
					mobjParameters.Comments = objfrmParameter.SpectrumParameter.Comments;
					//'get a spectrum comment to data structure
				}
			}
			//Aadded By pankaj on 25 Aug
			if (!objfrmParameter == null) {
				objfrmParameter.Close();
				//'close the parameter form.
			}

			Application.DoEvents();
		//'allow application to perfrom its panding work.

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			//Aadded By pankaj on 25 Aug
			if (!objfrmParameter == null) {
				objfrmParameter.Dispose();
			}
			if (!objWait == null) {
				objWait.Dispose();
			}
			mblnAvoidProcessing = false;
			Application.DoEvents();
			//'allow application to perfrom its panding work.
			//---------------------------------------------------------
		}
	}

	private void mnuPositionToMaxima_Click(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : mnuPositionToMaxima_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : this is called when user click on position to maxima
		// Description           : Set Maxisise position
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 05.01.07
		// Revisions             : praveencheck
		//=====================================================================
		//'note:
		//'this is called when user click on position to maxima
		//'Set Maxisise position


		CWaitCursor objWait = new CWaitCursor();
		int intIsSetMaximisePosition;

		double dblMaximisePosition;
		int i;
		bool blnIsPeakFound = false;
		//'flag for chacking peak
		int CourveCount;
		try {
			if (mblnAvoidProcessing == true) {
				//'flag for avoiding a process
				return;
			}
			mblnAvoidProcessing = true;

			if (mintChannelIndex > -1 & (ArrlstGraphCurveItem.Count > 0)) {
				//If Not (AASEnergySpectrum.OfflineCurve Is Nothing) Then
				if (!ArrlstGraphCurveItem(intCurveIndex) == null) {
					if ((CheckMaxPosition == false) & (intCurveIndex > -1)) {
						//intIsSetMaximisePosition = MsgBox(" Set Maximise Position ", MsgBoxStyle.YesNo)
						if (gobjMessageAdapter.ShowMessage(constSetMaximisePosition)) {
							Application.DoEvents();
							//If intIsSetMaximisePosition = MsgBoxResult.Yes Then
							CheckMaxPosition = CheckMaxPosition ^ true;
						}
					} else {
						CheckMaxPosition = CheckMaxPosition ^ true;
					}
					////---- Added by Sachin Dokhale. Stop the Timer Energy Display 


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
							//'for drawing highest peak line
							AASEnergySpectrum.ShowHighPeakLineLabel("Maximise Position", false, 0);
							//'show a highest peak label.
							for (i = 0; i <= AASEnergySpectrum.AldysPane.CurveList.Count - 1; i++) {
								if (AASEnergySpectrum.AldysPane.CurveList(i).IsHighPeakLine) {
									dblMaximisePosition = AASEnergySpectrum.AldysPane.CurveList(i).HighPeakXValue;
									//'get a maxima position of peak.
									blnIsPeakFound = true;
									//'set a flag for peak found.
									break; // TODO: might not be correct. Was : Exit For
								}
							}

							if (blnIsPeakFound == true) {
								TimerEnergyDisplay.Enabled = false;
								if (gobjCommProtocol.Wavelength_Position(dblMaximisePosition, lblWvPos) == true) {
									//'serial communication function for position a wavelength
									gobjCommProtocol.mobjCommdll.subTime_Delay(100);
									//'this is a function for delay
								}
								lblWvPos.Text = mXValueLable + gobjInst.WavelengthCur;
								//'display on label.
								lblWvPos.Refresh();
								////---- Added by Sachin Dokhale. Start the Timer Energy Display 
								TimerEnergyDisplay.Enabled = true;
								//lblYValue.Text = mYValueLable & FormatNumber(AASEnergySpectrum.AldysPane.CurveList(i).HighPeakYValue, 2)
								//lblYValue.Refresh()
							}
						}
					} else {
						mnuPositionToMaxima.Checked = false;
						AASEnergySpectrum.RemoveHighPeakLineLabel();
						//'for remove a highpeakline.

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
			mblnAvoidProcessing = false;
			//---------------------------------------------------------
		}
	}

	private void AASEnergySpectrum_GraphScaleChanged(double XMin, double XMax, double YMin, double YMax)
	{
		//=====================================================================
		// Procedure Name        :   AASEnergySpectrum_GraphScaleChanged
		// Description           :   Get Graph Scale
		// Purpose               :  this will change a scale of graph 
		// Parameters Passed     :   
		// Returns               :   
		// Parameters Affected   :   
		// Assumptions           :   
		// Dependencies          :   None.
		// Author                :   Sachin Dokhale
		// Created               :   16.02.07
		// Revisions             :
		//=====================================================================

		//'note;
		//'this is called during the change scale 
		//'it is used to change the energy spectrum scale.
		//'we have to pass the Scale ,we wanted for spectrum.

		try {
			//'get a passed parameter in to a  mobjParameters
			mobjParameters.XaxisMax = XMax;
			mobjParameters.XaxisMin = XMin;
			mobjParameters.YaxisMax = YMax;
			mobjParameters.YaxisMin = YMin;
			//---08.05.08
			WvStartRange = mobjParameters.XaxisMin;
			WvLastRange = mobjParameters.XaxisMax;

			if (!funcGraphPreRequisite(mobjParameters.Cal_Mode, mobjParameters.XaxisMin, mobjParameters.XaxisMax, mobjParameters.YaxisMin, mobjParameters.YaxisMax)) {
				//'reset the graph prerequisite as par given value

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
		// Purpose               : this is used for printing a graph
		// Description           : this is called when user click on print graph.
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 17-May-2007 03:25 pm
		// Revisions             : 1
		//=====================================================================


		//'this is used for printing
		CWaitCursor objWait = new CWaitCursor();
		clsDataFileReport objclsDataFileReport = new clsDataFileReport();
		//'clsDataFileReport() contain a function for printing a graph
		//Dim A1() As Double = {0, 0, 0, 0, 0, 0}

		try {
			//-----Added By Pankaj Fri 18 May 07
			if ((gstructSettings.Enable21CFR == true)) {
				if (!funcCheckActivityAuthentication(enumActivityAuthentication.Print, gstructUserDetails.Access)) {
					//'check for user authentication
					return;
					return;
				}
				gfuncInsertActivityLog(EnumModules.Print, "Print Energy Spectrum Mode Graph Accessed");
				//'insert a log.
			}
			//If intShowdialog = DialogResult.Yes Then
			objclsDataFileReport.DefaultFont = this.DefaultFont();
			//'set a font for report as default
			objclsDataFileReport.funcPrintEnergy(AASEnergySpectrum, mobjParameters, "");
		//'funcPrintEnergy is use for printing a graph

		//End If
		//------
		//If (toreported) Then 'OR NOT Method->RepReady )
		//gobjClsAAS203.SaveQuantResults(gobjNewMethod, A1, False)
		//toreported = False
		//AASEnergySpectrum.PrintPreViewGraph()


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
		//=====================================================================
		// Procedure Name        : nudPMT_ValueChanged
		// Parameters Passed     :ChangePmt
		// Returns               : bool
		// Purpose               : ''this is a function for setting PMT value to instrument 

		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 21.11.06
		// Revisions             : 
		//=====================================================================
		try {
			//nudPMT.Enabled = False
			//If mblnAvoidProcessing = True Then
			//    Exit Sub
			//End If
			//mblnAvoidProcessing = True
			funcSetPmtVParameter(nudPMT.Value);
		//'this is a function for setting PMT value to instrument


		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
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
			//---------------------------------------------------------
			//nudPMT.Enabled = True
		}

	}

	private void nudPMT_ValueEditorClick()
	{
		//=====================================================================
		// Procedure Name        : nudPMT_ValueEditorClick
		// Parameters Passed     :  
		// Returns               : None
		// Purpose               : 
		// Description           :  handle a value editor click event
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 21.11.06
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		try {
			//nudPMT.Enabled = False
			//If mblnAvoidProcessing = True Then
			//    Exit Sub
			//End If
			//mblnAvoidProcessing = True
			nudPMT.ValueEditorClick -= nudPMT_ValueEditorClick;
			Application.DoEvents();
			//'allow application to perfrom its panding work
			double dblReturnValue;

			dblReturnValue = FormatNumber(gobjInst.PmtVoltage, 0);
			//'get a PMT in temp variable
			if (funcSetFrmEditValue(dblReturnValue, "Set PMT (0 - 700)V ", nudPMT.MinValue, nudPMT.MaxValue) == true) {
				//'draw a EDIT form as per given parameter
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
			//mblnAvoidProcessing = False
			nudPMT.ValueEditorClick += nudPMT_ValueEditorClick;
			//nudPMT.Enabled = True
			if (!objWait == null) {
				objWait.Dispose();
			}
			nudPMT.Focus();
			Application.DoEvents();
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
		//=====================================================================
		// Procedure Name        : nudSlit_ValueChanged
		// Parameters Passed     : ChangeSlit 
		// Returns               : None
		// Purpose               : 
		// Description           :  for setting slit width
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 21.11.06
		// Revisions             : 
		//=====================================================================
		try {
			//nudSlit.Enabled = False
			//If mblnAvoidProcessing = True Then
			//    Exit Sub
			//End If
			//mblnAvoidProcessing = True
			funcSetSlit_WidthParameter(nudSlit.Value);
		//'for setting slit width

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
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
			//---------------------------------------------------------
			//nudSlit.Enabled = True
		}

	}

	private void nudSlit_ValueEditorClick()
	{
		//=====================================================================
		// Procedure Name        : nudSlit_ValueEditorClick
		// Parameters Passed     :  
		// Returns               : None
		// Purpose               : 
		// Description           : for setting slit width
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
			Application.DoEvents();
			//'allow application to perfrom its panding work.

			dblReturnValue = gobjClsAAS203.funcGet_SlitWidth;
			//'get a current slitwidth
			if (funcSetFrmEditValue(dblReturnValue, "Set Slit Width (0.0 - 2.0)nm", nudSlit.MinValue, nudSlit.MaxValue) == true) {
				//'draw a EDIT form as per given parameter.
				nudSlit.Value = dblReturnValue;
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
			//nudSlit.Enabled = True
			if (!objWait == null) {
				objWait.Dispose();
			}
			nudSlit.Focus();
			Application.DoEvents();
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
		// Parameters Passed     :  ChangeHCLCur
		// Returns               : None
		// Purpose               : 
		// Description           : for setting HCL current
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
			if (ReInitLampInstParameters == true) {
				return;
			}
			funcSetHCL_CurParameter(nudHCLCur.Value);
		//'for setting HCL current

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
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
			//nudHCLCur.Enabled = True
		}

	}

	private void nudHCLCur_ValueEditorClick()
	{
		//=====================================================================
		// Procedure Name        : nudHCLCur_ValueEditorClick
		// Parameters Passed     :  
		// Returns               : None
		// Purpose               : 
		// Description           : for setting HCL current
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
			//'allow application to perfrom its panding work
			dblReturnValue = gobjInst.Current;
			//'get current to be set
			if (funcSetFrmEditValue(dblReturnValue, "Set HCL Current (0 - 25)mA", nudHCLCur.MinValue, nudHCLCur.MaxValue) == true) {
				//'draw a EDIT form as per passed parameter
				nudHCLCur.Value = dblReturnValue;
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
		// Parameters Passed     : ChangeD2Cur 
		// Returns               : None
		// Purpose               : 
		// Description           : for setting D2 Current
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
			funcSetD2_CurParameter(nudD2Cur.Value);
			//for setting D2 Current
			if (nudD2Cur.Value == 100.0) {
				//check a cond if true then
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
			//---------------------------------------------------------
		}

	}

	private void nudD2Cur_ValueEditorClick()
	{
		//=====================================================================
		// Procedure Name        : nudD2Cur_ValueEditorClick
		// Parameters Passed     :  
		// Returns               : None
		// Purpose               : 
		// Description           : for setting D2 current
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
			nudD2Cur.ValueEditorClick -= nudD2Cur_ValueEditorClick;
			Application.DoEvents();
			if (ReInitLampInstParameters == true) {
				return;
			}
			//'allow application to perfrom its panding work.

			dblReturnValue = gobjInst.D2Current;
			//'get a D2 current.
			if (funcSetFrmEditValue(dblReturnValue, "Set D2 Current (100 - 300)mA", nudD2Cur.MinValue, nudD2Cur.MaxValue) == true) {
				//'draw a EDIT form as per given parameter.
				nudD2Cur.Value = dblReturnValue;
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
			//'alow application to perfrom its panding work
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
		// Parameters Passed     : ChangeFuelRatio 
		// Returns               : None
		// Purpose               : 
		// Description           : for setting Fuel ratio
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 21.11.06
		// Revisions             : 
		//=====================================================================
		try {
			//nudFuelRatio.Enabled = False
			//If mblnAvoidProcessing = True Then
			//    Exit Sub
			//End If
			//mblnAvoidProcessing = True
			nudFuelRatio.ValueEditorValueChanged -= nudFuelRatio_ValueChanged;
			//If Not (CDbl(nudFuelRatio.Value) = mdblFuelRatio) Then
			//    Call gobjClsAAS203.funcSetFuel(CDbl(nudFuelRatio.Value))
			//    mdblFuelRatio = gobjClsAAS203.funcGet_Fuel_Ratio(True)
			//Else
			//    mdblFuelRatio = gobjClsAAS203.funcGet_Fuel_Ratio(True)
			//End If

			funcSetFuelParameter((double)nudFuelRatio.Value);
			//'for setting fuel 
			if (mdblFuelRatio < 0.0) {
				//'setting some validation
				nudFuelRatio.Value = 0.0;
				mobjParameters.FualRatio = 0.0;
				mdblFuelRatio = 0.0;
			} else {
				nudFuelRatio.Value = mdblFuelRatio;
				mobjParameters.FualRatio = mdblFuelRatio;
			}

			//mobjParameters.FualRatio = Val(mdblFuelRatio)
			///get fuelratio in object
			//nudFuelRatio.Value = mdblFuelRatio
			//nudFuelRatio.Value = mdblFuelRatio
			nudFuelRatio.Refresh();


		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
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
			//mblnAvoidProcessing = False
			//nudFuelRatio.Enabled = True
			//---------------------------------------------------------
		}
	}

	private void nudFuelRatio_ValueEditorClick()
	{
		//=====================================================================
		// Procedure Name        : nudFuelRatio_ValueEditorClick
		// Parameters Passed     :  
		// Returns               : None
		// Purpose               : 
		// Description           : for setting fuel ratio.
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
			Application.DoEvents();
			//'allow application to perfrom its panding work.

			dblReturnValue = gobjClsAAS203.funcGet_Fuel_Ratio(true);
			if (dblReturnValue < 0.0) {
				//'setting some validation
				dblReturnValue = 0.0;
			} else {
				dblReturnValue = Format(dblReturnValue, "#.00");
			}
			//'get a fuel ratio which is to be set
			if (funcSetFrmEditValue(dblReturnValue, "Set Fuel Ratio (0 - 7.66)", nudFuelRatio.MinValue, nudFuelRatio.MaxValue) == true) {
				//'draw a form as per given parameter.
				nudFuelRatio.Value = dblReturnValue;
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
			//nudFuelRatio.Enabled = True
			//mblnAvoidProcessing = False
			if (!objWait == null) {
				objWait.Dispose();
			}
			nudFuelRatio.Focus();
			Application.DoEvents();
			//'allow application to perfrom its panding work.
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
		// Procedure Name        : nudBurnerHeight_ValueChanged
		// Parameters Passed     : ChangeBurnerHeight 
		// Returns               : None
		// Purpose               : 
		// Description           : for setting burner height.
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 21.11.06
		// Revisions             : 
		//=====================================================================
		try {
			//If mblnAvoidProcessing = True Then
			//    Exit Sub
			//End If
			//mblnAvoidProcessing = True
			//nudBurnerHeight.Enabled = False
			nudBurnerHeight.ValueEditorValueChanged -= nudBurnerHeight_ValueChanged;

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
				if (!mobjclsBgSpectrum == null) {
					mobjclsBgSpectrum.SpectrumWait = true;
					//'first pause a spectrum
				}
				nudBurnerHeight.Value = funcSetBurner_HeightParameter((double)nudBurnerHeight.Value);
				//'set a burner height.
				if (!mobjclsBgSpectrum == null) {
					//'reset a spectrum.
					mobjclsBgSpectrum.SpectrumWait = false;
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
			//mblnAvoidProcessing = False
			nudBurnerHeight.ValueEditorValueChanged += nudBurnerHeight_ValueChanged;
			//nudBurnerHeight.Enabled = True

			//---------------------------------------------------------
		}
	}

	private void nudBurnerHeight_ValueEditorClick()
	{
		//=====================================================================
		// Procedure Name        : nudBurnerHeight_ValueEditorClick
		// Parameters Passed     :  
		// Returns               : None
		// Purpose               : 
		// Description           : for setting a burner height
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 21.11.06
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		double dblReturnValue;
		try {
			//DisableButtonsForBurnerHeight()
			//nudBurnerHeight.Enabled = False
			//If mblnAvoidProcessing = True Then
			//    Exit Sub
			//End If
			//mblnAvoidProcessing = True



			nudBurnerHeight.ValueEditorClick -= nudBurnerHeight_ValueEditorClick;
			Application.DoEvents();
			//'allow applicationj to perfrom its panding work
			dblReturnValue = FormatNumber(gobjClsAAS203.funcReadBurnerHeight(), 2);
			//'get height to be set
			if (funcSetFrmEditValue(dblReturnValue, "Set Burner Height (0.0 - 6.0)nm", nudBurnerHeight.MinValue, nudBurnerHeight.MaxValue) == true) {
				//'draw a EDIT form as per given parameter.
				nudBurnerHeight.Value = dblReturnValue;
			}

		//If Not mobjclsBgSpectrum Is Nothing Then
		//    mobjclsBgSpectrum.SpectrumWait = False
		//End If
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
			nudBurnerHeight.ValueEditorClick += nudBurnerHeight_ValueEditorClick;
			//nudBurnerHeight.Enabled = True
			if (!objWait == null) {
				objWait.Dispose();
			}
			//EnableButtonsForBurnerHeight()
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
		try {
			//If mblnAvoidProcessing = True Then
			//    Exit Sub
			//End If
			//mblnAvoidProcessing = True
			//nudHCLCur.Enabled = False

			//If Not mobjclsBgSpectrum Is Nothing Then
			//    mobjclsBgSpectrum.SpectrumWait = True
			//End If

			cmbModes.SelectedIndexChanged -= cmbModes_SelectedIndexChanged;
			if (cmbModes.SelectedIndex > -1) {
				//gobjInst.Mode = cmbModes.SelectedIndex
				funcSetSpectrumParameter(cmbModes.SelectedIndex);
				//'for setting spectrum parameter as per calibration mode.

			}
			cmbModes.SelectedIndexChanged += cmbModes_SelectedIndexChanged;

		//If Not mobjclsBgSpectrum Is Nothing Then
		//    mobjclsBgSpectrum.SpectrumWait = False
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
			if (!objWait == null) {
				objWait.Dispose();
			}
			mblnAvoidProcessing = false;
			//nudHCLCur.Enabled = True
			Application.DoEvents();
			//'allow application to perfrom its panding work.
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
	//        If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
	//            Exit Sub
	//        End If
	//        mblnAvoidProcessing = True

	//        'If Not IsNothing(mobjfrmAnalysis) Then mobjfrmAnalysis.tmrAspirationMsg.Enabled = False
	//        If Not gstructSettings.ExeToRun = EnumApplicationMode.ServiceUtility Then
	//            If gobjMain.mobjController.IsThreadRunning Then
	//                gobjMain.mobjController.Cancel()
	//                blnIsFlameStatusCheck = True
	//            End If
	//        End If
	//        Call gobjClsAAS203.funcIgnite(True)
	//        '//----- Set Fuel Ratio
	//        RemoveHandler nudFuelRatio.ValueEditorValueChanged, AddressOf nudFuelRatio_ValueChanged
	//        Call gobjCommProtocol.funcGet_NV_Pos()
	//        mdblFuelRatio = gobjClsAAS203.funcGet_Fuel_Ratio(True)
	//        mobjParameters.FualRatio = Val(mdblFuelRatio)
	//        nudFuelRatio.Value = mdblFuelRatio
	//        AddHandler nudFuelRatio.ValueEditorValueChanged, AddressOf nudFuelRatio_ValueChanged
	//        '//-----
	//        mblnAvoidProcessing = False
	//        'gobjMain.mobjController.Start(gobjclsBgFlameStatus)
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
	//        If Not gstructSettings.ExeToRun = EnumApplicationMode.ServiceUtility Then
	//            If blnIsFlameStatusCheck = True Then
	//                gobjMain.mobjController.Start(gobjclsBgFlameStatus)
	//            End If
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
	//        If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
	//            Exit Sub
	//        End If

	//        mblnAvoidProcessing = True
	//        If Not gstructSettings.ExeToRun = EnumApplicationMode.ServiceUtility Then
	//            If gobjMain.mobjController.IsThreadRunning = True Then
	//                gobjMain.mobjController.Cancel()
	//                blnIsFlameStatusCheck = True
	//            End If
	//        End If
	//        Application.DoEvents()

	//        Call gobjClsAAS203.funcIgnite(False)
	//        '//----- Set Fuel Ratio
	//        RemoveHandler nudFuelRatio.ValueEditorValueChanged, AddressOf nudFuelRatio_ValueChanged
	//        Call gobjCommProtocol.funcGet_NV_Pos()
	//        mdblFuelRatio = gobjClsAAS203.funcGet_Fuel_Ratio(True)
	//        nudFuelRatio.Value = mdblFuelRatio
	//        mobjParameters.FualRatio = Val(mdblFuelRatio)
	//        nudFuelRatio.Value = mdblFuelRatio
	//        AddHandler nudFuelRatio.ValueEditorValueChanged, AddressOf nudFuelRatio_ValueChanged
	//        '//-----

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
	//        If Not gstructSettings.ExeToRun = EnumApplicationMode.ServiceUtility Then
	//            If blnIsFlameStatusCheck = True Then
	//                gobjMain.mobjController.Start(gobjclsBgFlameStatus)
	//            End If
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
		//'note:
		//'this is called during the loading of a form.
		//'this is used to take some initial action 
		//'for eg like setting a on screen validation.
		CWaitCursor objWait = new CWaitCursor();

		try {
			Application.DoEvents();
			////---- Added by Sachin Dokhale. Stop the Timer Energy Display 
			TimerEnergyDisplay.Enabled = false;
			if (!gstructSettings.ExeToRun == EnumApplicationMode.ServiceUtility) {
				//'check for exe
				if (!IsNothing(gobjMain)) {
					if (gobjMain.mobjController.IsThreadRunning == true) {
						gobjMain.mobjController.Cancel();
						//commented by Saurabh
						//'stop the thread if any running
						gobjCommProtocol.mobjCommdll.subTime_Delay(500);
						//10.12.07
						Application.DoEvents();
						//'by this application perfrom its pending operation
					}
				}
			}
			gblnUVS = false;
			subRearrangeFrmOBJ();
			//'this will rearrange the form object
			if (gobjInst.Mode > -1) {
				////----- Added by Sachin Dokhale. Get the init. calibration mode.
				m_bytCalibMode = gobjInst.Mode;
				//'set all the mode present in data steuctor to combobox
				cmbModes.SelectedIndex = gobjInst.Mode;
			}
			//'below we are setting some visible to control which has to be shown on screen

			nudPMT.Visible = true;
			nudBurnerHeight.Visible = true;
			nudBurnerHeight.IsReverseOperation = true;
			nudBurnerHeight.IsUpDownButtonToBeDisabledOnValueChange = true;
			nudFuelRatio.IsUpDownButtonToBeDisabledOnValueChange = true;
			nudD2Cur.Visible = true;
			nudFuelRatio.Visible = true;
			nudHCLCur.Visible = true;
			nudSlit.Visible = true;
			cmbSpeed.Visible = true;
			cmbModes.Visible = true;
			Application.DoEvents();
			////----- Set the HCLE as default mode for Energy Spectrum
			funcSetDefaultSpectrumParameter(EnumCalibrationMode.HCLE);
			//'set a default spectrum parameter when calibration mode is HCLE
			funcSetDefaultParameter();
			//lblWvPos()

			AddHandlers();
			//'this is called for adding all the event to control
			gblnSpectrumTerminated = false;
			gblnSpectrumWait = false;
			////---- Added by Sachin Dokhale. Start the Timer Energy Display 
			TimerEnergyDisplay.Enabled = true;
			func_Enable_Disable(EnumProcesses.FormInitialize, EnumStart_End.End_of_Process);
			//'for enable/disable the control when form is in initial state
			this.Refresh();
			Application.DoEvents();
		//'allow application to perform it's panding work

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
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
		//'note:
		//'this is used to add a event to the control.

		try {
			mnuLoadSpectrunFile.Click += mnuLoadSpectrumFile_Click;
			mnuSaveSpectrumFile.Click += mnuSaveSpectrumFile_Click;
			cmbModes.SelectedIndexChanged += cmbModes_SelectedIndexChanged;
			mnuExit.Click += mnuExit_Click;
			btnReturn.Click += mnuExit_Click;
			mnuPeakPick.Click += mnuPeakPick_Click;
			btnStart.Click += btnStart_Click;
			mnuStart.Click += btnStart_Click;
			//--Added By Pankaj 22 May 07
			btnClearSpectrum.Click += btnClearSpectrum_Click;
			//'this will bind a event to a control

			mnuChangeScale.Click += cmdChangeScale_Click;
			//'this will add a event to the change scale button.
			mnuClearSpectrum.Click += btnClearSpectrum_Click;
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

			//AddHandler nudPMT.ValueChanged, AddressOf nudPMT_ValueChanged
			nudPMT.ValueEditorClick += nudPMT_ValueEditorClick;
			nudPMT.ValueEditorValueChanged += nudPMT_ValueChanged;

			cmbSpeed.SelectedIndexChanged += cmbSpeed_SelectedIndexChanged;
			cmdChangeScale.Click += cmdChangeScale_Click;
			btnLampParameters.Click += btnLampParameters_Click;
			mnuContiniousTimeScan.Click += mnuContiniousTimeScan_Click;
			mnuSmooth.Click += mnuSmoothGraph_Click;
			//'this will add a event to a menu smooth , which called when user click on smooth menu

			mnuPositionToMaxima.Click += mnuPositionToMaxima_Click;
			mnuParameters.Click += mnuParameters_Click;
			AASEnergySpectrum.GraphScaleChanged += AASEnergySpectrum_GraphScaleChanged;

			tlbbtnReturn.Click += mnuExit_Click;
			tlbbtnStart.Click += btnStart_Click;
			//'this will add a start button click event to btnStart_Click procedure

			tlbbtnLampParameters.Click += btnLampParameters_Click;
			tlbbtnClearSpectrum.Click += btnClearSpectrum_Click;
			tlbbtnChangeScale.Click += cmdChangeScale_Click;
			tlbbtnLoadspectrumFile.Click += mnuLoadSpectrumFile_Click;
			tlbbtnSaveSpectrumFile.Click += mnuSaveSpectrumFile_Click;
			tlbbtnSmooth.Click += mnuSmoothGraph_Click;
			tlbbtnPositionToMaxima.Click += mnuPositionToMaxima_Click;
			tlbbtnContiniousTimeScan.Click += mnuContiniousTimeScan_Click;
			tlbbtnParameters.Click += mnuParameters_Click;
			mnuLampParameters.Click += btnLampParameters_Click;
			//'this will bind a event 

			btnIgnite.Click += btnIgnite_Click;
			btnExtinguish.Click += btnExtinguish_Click;
			btnN2OIgnite.Click += btnN2OIgnite_Click;
			btnDelete.Click += btnDelete_Click;
			btnR.Click += btnR_Click;

			tlbbtnPeakPick.Click += mnuPeakPick_Click;


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

			mnuPrintGraph.Click += tlbbtnPrintGraph_Click;
			tlbbtnPrintGraph.Click += tlbbtnPrintGraph_Click;


		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
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
		// Purpose               : for starting a spectrum 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 07.10.06
		// Revisions             : 
		//=====================================================================
		//Dim objWait As New CWaitCursor
		//'note:
		//'this will satrt a energy spectrum by starting thread.
		try {
			//'Added By Praveen
			tlbbtnClearSpectrum.Enabled = false;
			tlbbtnChangeScale.Enabled = false;
			tlbbtnLampParameters.Enabled = false;
			//Ended by praveen
			if (mblnAvoidProcessing == true) {
				//'check a flag for avoiding a process
				return;
			}
			func_Enable_Disable(EnumProcesses.StartScan, EnumStart_End.Start_of_Process);
			func_Enable_DisableControl(false);
			//'for enable/disable a control when scanniong is started

			//Display graph
			//if data structure in open then
			if (mobjChannnels.Count > 0) {
				//'here mobjchannnels is a object of spectrum data structure
				if (!(mobjChannnels(mintChannelIndex) == null)) {
					funcDisplayGraph(mobjChannnels(mintChannelIndex));
					//this is for displaying a graph withcurrent data steucture value.
				}
			}

			this.AASEnergySpectrum.btnPeakEdit.Checked = true;
			this.AASEnergySpectrum.btnShowXYValues.Checked = false;
			this.mnuShowXYValues.Enabled = false;
			this.tlbbtnShowXYValues.Enabled = false;
			this.mnuPeakEdit.Enabled = false;
			this.tlbbtnPeakEdit.Enabled = false;
			funcGetInstParameter();
			//'get the current instrument parameter
			//Added by Pankaj on 27 Aug 07
			if (this.AASEnergySpectrum.getCurveListCount > 0) {
				this.AASEnergySpectrum.submnuPeakEdit_Click(btnStart, System.EventArgs.Empty);
			}
			if (funcOnSpect(false, lblWvPos, lblYValue) == false) {
				//'here we pass false for baseline
				//for starting a spectrum
				func_Enable_Disable(EnumProcesses.StartScan, EnumStart_End.End_of_Process);
				//'and enable/disable the control
				func_Enable_DisableControl(true);
				return;
			}

			this.AASEnergySpectrum.btnPeakEdit.Enabled = false;
			this.AASEnergySpectrum.btnShowXYValues.Enabled = false;
			btnStart.Text = "&Stop";
			mnuStart.Text = "&Stop";
			//mnuPeakEdit.Enabled = True

			//AASEnergySpectrum.ShowXYValues = False

			//'here we are setting what image has to be displayed ion button
			btnStart.Image = Image.FromFile(Application.StartupPath + "\\Images\\cancel_1.ico");
			mnuStart.Image = Image.FromFile(Application.StartupPath + "\\Images\\cancel_1.ico");
			btnStart.Enabled = true;
			btnStart.Refresh();

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
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
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	private void subStopScan()
	{
		//=====================================================================
		// Procedure Name        : subStartScan
		// Parameters Passed     : 
		// Returns               : None
		// Purpose               : for stop the scan
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 07.10.06
		// Revisions             : 
		//=====================================================================
		//Dim objWait As New CWaitCursor
		//'note:
		//'this is used to stop the thread by settin
		//'spectrum thread to true.



		try {
			//'Added By Praveen
			tlbbtnClearSpectrum.Enabled = true;
			tlbbtnChangeScale.Enabled = true;
			tlbbtnLampParameters.Enabled = true;
			//Ended by praveen
			//gblnSpectrumTerminated = True
			mobjclsBgSpectrum.ThTerminate = true;

		//'for stoping a thread so that scan will stoped


		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
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
		// Purpose               : this is called when user click on clear spectrum
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 07.10.06
		// Revisions             : 
		//=====================================================================
		//Dim objWait As New CWaitCursor
		//'note:
		//'for this first prompt user that whatever he want to save a spectrum or not
		//'is yes then save the spectrum then clear it
		//'else clear it without save 

		try {
			if (mblnAvoidProcessing == true) {
				//'check for flag to avoid process
				return;
			}
			mblnAvoidProcessing = true;
			//intChannel_no = funcAddChannelToCollection(mobjOnlineChannel)

			if (mintChannelIndex > -1) {
				if (mobjChannnels.Count > 0) {
					if (blnYetFileNotSave == true) {
						if (gobjMessageAdapter.ShowMessage(constFileNotSaved) == true) {
							Application.DoEvents();
							//'prompt a save message before clear the spectrum 
							funcSaveSpectrumFile();
							//'save a current soectrum if user want, befora clearing a spectrum.

						}
					}
					//mobjChannnels.RemoveAt(mintChannelIndex)
					mintChannelIndex = -1;

					mobjChannnels.Clear();
					//'clearing a data structure
					if (ArrlstGraphCurveItem.Count >= intCurveIndex + 1) {
						//ArrlstGraphCurveItem.RemoveAt(intCurveIndex)
						ArrlstGraphCurveItem.Clear();
						intCurveIndex = -1;
					}
				}
			}
			blnYetFileNotSave = false;
			funcClearGraph();
			//'for clearing a graph
			func_Enable_Disable(EnumProcesses.EditSystemParamters, EnumStart_End.End_of_Process);
		//'for enable/disble the control

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
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
		// Description           : for smooth graph
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 16.10.06
		// Revisions             : 
		//=====================================================================
		//'note:
		//'basic algorithm behind it ,first store current spectrum in a data structure
		//'and then perfrom smooth operation , and after thet display it on graph


		CWaitCursor objWait = new CWaitCursor();
		try {
			Channel objchanel0;

			if (mblnAvoidProcessing == true) {
				//'check for flag to avoid a process
				return;

			}

			if (mintChannelIndex > -1) {
				//'check is there any channel present in the collection
				objchanel0 = mobjSpectrum.funcCloneESChannel(mobjChannnels(mintChannelIndex));
				//'this will make a clone copy of one object to other object
				if (!(objchanel0) == null) {
					mobjSpectrum.funcSmooth1(objchanel0, 0);
					//'function for smoothing a graph
					mobjChannnels(mintChannelIndex) = mobjSpectrum.funcCloneESChannel(objchanel0);
					funcClearGraph();
					//'function for clear the graph
					if (funcDisplayGraph(mobjChannnels.item(mintChannelIndex))) {
						//'display a graph as par a given item index no
						//mintChannelIndex += 1
						ArrlstGraphCurveItem.Add(mGraphCurveItem);
						intCurveIndex += 1;
					}

					funcGraphPreRequisite(mobjParameters.Cal_Mode, mobjParameters.XaxisMin, mobjParameters.XaxisMax, mobjParameters.YaxisMin, mobjParameters.YaxisMax);
					//'set a graph as par prerequisite
					//'for setting a graph as par a current value
				}
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
		// Purpose               : to find a peakvally
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 14.12.06
		// Revisions             : 
		//=====================================================================
		//Dim objWait As New CWaitCursor
		//'note:
		//'this is used to find a peak vally in a spectrum.
		DataTable objDataTable = new DataTable();
		Channel objPeakVallyChannel;
		//'object of spectrum data structure
		int intCounter = 0;
		long lngPeakValleyCounts;
		int intShowdialog;
		clsDataFileReport objclsDataFileReport = new clsDataFileReport();
		//'realted to report

		try {
			if (mblnAvoidProcessing == true) {
				//'check flag for avoiding a process,
				return;
			}

			mblnAvoidProcessing = true;
			if (mintChannelIndex > -1) {
				//;check is there any channel present in the collection
				if (!(mobjChannnels.item(mintChannelIndex) == null)) {
					if (mobjSpectrum.funcPeaks(mobjChannnels.item(mintChannelIndex), mStuctPeaksValley) == false) {
						//'function called for finding peacs
						gobjMessageAdapter.ShowMessage(constErrorPopulatingPeakValleyData);
						//'shows the msg peak not found
						Application.DoEvents();
						//MsgBox("Error in Peak Valley Methods", MsgBoxStyle.Critical)
					}
				} else {
					return;
				}
				//--- Check for Peak-Valley points
				lngPeakValleyCounts = mobjSpectrum.PeakValleyCount;
				//'store a total number of peakcount in a variable

				if (lngPeakValleyCounts <= 0) {
					//'if not any peak found then shows error message
					gobjMessageAdapter.ShowMessage(constNOPeakORValley);
					Application.DoEvents();
					//'allow application to perform its panding work
					//gFuncShowMessage("Peak Pick", "No Peaks Or Valleys detected.", EnumMessageType.Information)
					return;
				}


				////----- Heaight the peak valley point
				//If Not funcHighlightPeakValleyPoints(structPeak, lngPeakValleyCounts, objChannel) Then
				//    gFuncShowMessage("Error...", "Error in displaying the Peak Valley points.", modConstants.EnumMessageType.Information)
				//End If
				////----------
				//If mobjChannnels.item(mintChannelIndex).IsEnergySpectrum = True Then
				//    objPeakVallyChannel = New Channel(True)
				//Else
				//    objPeakVallyChannel = New Channel(False)
				//End If

				///----- Ini for Energy Spectrum
				objPeakVallyChannel = mobjChannnels.item(mintChannelIndex);
				//'store all peakvally info in objPeakVallyChannel as par data structure index.


				if (!mobjSpectrum.funcGetDataPeakPickResults(objDataTable, mStuctPeaksValley, lngPeakValleyCounts, objPeakVallyChannel)) {
					//'now get a peakresult in a datatable or any other datasteuctor
					gobjMessageAdapter.ShowMessage(constErrorPopulatingPeakValleyData);
					Application.DoEvents();
					//'allow application to perfrom its panding work.
					//gFuncShowMessage("Error...", "Error in populating the peak valley data in the data table to display on the screen.", EnumMessageType.Information)
				}

				frmPeakPicks frmPeakPick = new frmPeakPicks();
				//'make object of formpeakpicks

				frmPeakPick.funcDisplayPicPeakResults(objDataTable);
				//'now passed a data table containing all peak result to above function
				//'this will display a peak result
				intShowdialog = frmPeakPick.ShowDialog();

				if (intShowdialog == DialogResult.Yes) {
					//-----------------------------      28.3.2010 by dinesh wagh
					if ((gstructSettings.Enable21CFR == true)) {
						if (!funcCheckActivityAuthentication(enumActivityAuthentication.Print, gstructUserDetails.Access)) {
							return;
						} else {
							objclsDataFileReport.DefaultFont = this.DefaultFont();
							//'set a font
							objclsDataFileReport.funcPeakValleyPrintEnergy(AASEnergySpectrum, objDataTable, mobjParameters, "");
						}
					}
					//---------------------

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
		// Purpose               : to changed the lamp parameter. 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : it should have given value.
		// Author                : Sachin Dokhale
		// Created               : 07.12.06
		// Revisions             : 
		//=====================================================================
		//'note:
		//'this is used to change the lamp parameter .
		//'it will show a lamp parameter dialog first '
		//'then accept the value for new parameter.
		CWaitCursor objWait = new CWaitCursor();
		frmChangeLampParameters objfrmChangeLampPara = new frmChangeLampParameters();
		//'object of lamp parameter changed form
		try {
			if (mblnAvoidProcessing == true) {
				//flag for avoid process
				return;
			}
			mblnAvoidProcessing = true;
			////---- Added by Sachin Dokhale. Stop the Timer Energy Display 
			TimerEnergyDisplay.Enabled = false;

			if (objfrmChangeLampPara.ShowDialog() == DialogResult.OK) {
				//'this will show the lampparameter dialog box
				nudHCLCur.Value = gobjInst.Current;
				//'nudHCLCur is a object of number validator
			}
			//'accept element name and turret no in mobjParameters  
			mobjParameters.LampEle = gobjInst.Lamp.LampParametersCollection(gobjInst.Lamp_Position - 1).ElementName;
			mobjParameters.LampTurrNo = gobjInst.Lamp_Position;
			////---- Added by Sachin Dokhale. Start the Timer Energy Display 
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
			//destructor
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
		// Purpose               : this function set data from current data structure to screen
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
			funcSetParameter = false;


			////----- Set the default parameter to the spectrum.
			///----- Set the Form object parameter
			////----- Set PMT Object



			if (mobjChannnels(mintChannelIndex).ChannelNo > -1) {
				//'if data structure have a data then

				//nudPMT.Value = gobjInst.PmtVoltage

				nudPMT.Value = mobjChannnels(mintChannelIndex).EnegryParameter.PMTV();
				//'display a curren value of spectrum from data spectrum to screen
				//'this will set a PMT value to PMT control
				//gobjInst.PmtVoltage = mobjChannnels(mintChannelIndex).EnegryParameter.PMTV()    'Saurabh
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
				//gobjInst.D2Current = mobjChannnels(mintChannelIndex).EnegryParameter.D2Curr     'Saurabh
				////-----

				////----- Set Slit width Object
				//nudSlit.Value = gobjClsAAS203.funcGet_SlitWidth()

				nudSlit.Value = Val(mobjChannnels(mintChannelIndex).EnegryParameter.SlitWidth);
				//gobjInst.SlitPosition = Val(mobjChannnels(mintChannelIndex).EnegryParameter.SlitWidth)      'Saurabh

				//Commented by Saurabh
				//dblBhHeight = Val(mobjChannnels(mintChannelIndex).EnegryParameter.BurnerHeight)
				//nudBurnerHeight.Value = dblBhHeight 'Val(mobjChannnels(mintChannelIndex).EnegryParameter.BurnerHeight)
				//Saurabh


				//nudFuelRatio.Value = Val(mobjChannnels(mintChannelIndex).EnegryParameter.FualRatio)

				nudHCLCur.Value = Val(mobjChannnels(mintChannelIndex).EnegryParameter.HCLCurr);
				//gobjInst.Current = Val(mobjChannnels(mintChannelIndex).EnegryParameter.HCLCurr)     'Saurabh



				////-----

				cmbModes.SelectedIndex = mobjChannnels(mintChannelIndex).EnegryParameter.Cal_Mode();


				////----- Set the d2E default mode
				////----- Set slow Speed s
				switch (mobjChannnels(mintChannelIndex).EnegryParameter.ScanSpeed) {
					//'displayed a selected speed
					case CONST_FASTStep:
						cmbSpeed.SelectedIndex = 0;
					case CONST_MEDIUMStep:
						cmbSpeed.SelectedIndex = 1;
					case CONST_SLOWStep:
						cmbSpeed.SelectedIndex = 2;
				}
			}
			Application.DoEvents();
			//'allow application to perfrom its panding work.
			funcSetParameter = true;
		//'
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
		// Description           : for getting a instrument parameter from the gobjinst data structure.
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

			//AddHandler nudPMT.ValueChanged, AddressOf nudPMT_ValueChanged
			nudPMT.ValueEditorClick -= nudPMT_ValueEditorClick;
			nudPMT.ValueEditorValueChanged -= nudPMT_ValueChanged;
			//End If
			////-----

			////----- Set PMT Object

			nudPMT.Value = gobjInst.PmtVoltage;
			//'this will get a pmt voltage from gobjinst object to screen
			nudD2Cur.Value = gobjInst.D2Current;
			//'this will get a D2 current from gobjinst object to screen
			////-----

			////----- Set Slit width Object
			nudSlit.Value = gobjClsAAS203.funcGet_SlitWidth();
			//'get slitwidth


			nudBurnerHeight.Value = gobjClsAAS203.funcReadBurnerHeight();
			//'get burner height
			mdblFuelRatio = Format(mdblFuelRatio, "#0.00");
			//'get fuel ratio
			nudFuelRatio.Value = Format(mdblFuelRatio, "#0.00");

			nudHCLCur.Value = gobjInst.Current;
			//'get HCL current
			if (!(mobjParameters == null)) {
				//'if mobjParameters  prasence
				//'below we are taking parameter from gobjInst ot mobjParameters object

				mobjParameters.PMTV = gobjInst.PmtVoltage;
				mobjParameters.HCLCurr = gobjInst.Current;
				mobjParameters.D2Curr = gobjInst.D2Current;
				mobjParameters.SlitWidth = Val(nudSlit.Value);
				mobjParameters.SlitWidth = (double)nudSlit.Value;
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
			cmbModes.SelectedIndex = gobjInst.Mode;
			//'get selected mode.
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

			//AddHandler nudPMT.ValueChanged, AddressOf nudPMT_ValueChanged
			nudPMT.ValueEditorClick += nudPMT_ValueEditorClick;
			nudPMT.ValueEditorValueChanged += nudPMT_ValueChanged;
			//End If
			////-----

			Application.DoEvents();
			//'allow application to perfrom its panding work
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
		// Parameters Passed     : intSpeed , which is to be set
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
				//'set the speed as par given value
				//'here we are using constant value for speed
				//'like #define
				//'and as par application mode we set the speed
				case 0:
					if (gstructSettings.AppMode == EnumAppMode.FullVersion_201 | gstructSettings.AppMode == EnumAppMode.DemoMode_201) {
						mobjParameters.ScanSpeed = CONST_FASTStep_AA201;
						//25.0
					} else {
						mobjParameters.ScanSpeed = CONST_FASTStep;
						//50.0
					}
				//mobjParameters object contain parameter for energyspectrum

				case 1:
					if (gstructSettings.AppMode == EnumAppMode.FullVersion_201 | gstructSettings.AppMode == EnumAppMode.DemoMode_201) {
						mobjParameters.ScanSpeed = CONST_MEDIUMStep_AA201;
						//12.5
					} else {
						mobjParameters.ScanSpeed = CONST_MEDIUMStep;
						//25.0
					}
				case 2:
					if (gstructSettings.AppMode == EnumAppMode.FullVersion_201 | gstructSettings.AppMode == EnumAppMode.DemoMode_201) {
						mobjParameters.ScanSpeed = CONST_SLOWStep_AA201;
						//2.5
					} else {
						mobjParameters.ScanSpeed = CONST_SLOWStep;
						//5.0
					}
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
		//'not in used
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

		//'this is for data structure

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
			objInChannel.ChannelNo = intChannel_no;
			mobjChannnels.Add(objInChannel);
			//'for adding a channel to data structure

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
	//    ' Procedure Name        : funcCloneParameter
	//    ' Parameters Passed     : inobjparamter
	//    ' Returns               : object 
	//    ' Purpose               : for cloning a object.
	//    ' Description           : 
	//    ' Assumptions           : 
	//    ' Dependencies          : 
	//    ' Author                : Sachin Dokhale
	//    ' Created               : 
	//    ' Revisions             : praveen
	//    '=====================================================================
	//    Try
	//        ''note:
	//        ''for cloning parameter from one obj to another
	//        ''we have to pass a object with parameter 
	//        ''and this function return a object with clone parameter

	//        Dim objCloneParameter As New EnergySpectrumParameter
	//        '----------------------Cloning  parameter object ----------------------------------
	//        objCloneParameter.AnalysisDate = inobjparamter.AnalysisDate
	//        ''clone AnalysisDate
	//        objCloneParameter.BurnerHeight = inobjparamter.BurnerHeight
	//        ''clone burner height
	//        objCloneParameter.FualRatio = inobjparamter.FualRatio
	//        ''clone fuel ratio
	//        objCloneParameter.HCLCurr = inobjparamter.HCLCurr
	//        objCloneParameter.LampEle = inobjparamter.LampEle
	//        objCloneParameter.LampTurrNo = inobjparamter.LampTurrNo
	//        objCloneParameter.Cal_Mode = inobjparamter.Cal_Mode
	//        objCloneParameter.Comments = inobjparamter.Comments
	//        objCloneParameter.D2Curr = inobjparamter.D2Curr
	//        objCloneParameter.PMTV = inobjparamter.PMTV
	//        objCloneParameter.ScanSpeed = inobjparamter.ScanSpeed
	//        objCloneParameter.SlitWidth = inobjparamter.SlitWidth
	//        objCloneParameter.SpectrumName = inobjparamter.SpectrumName
	//        objCloneParameter.XaxisMax = inobjparamter.XaxisMax
	//        objCloneParameter.XaxisMin = inobjparamter.XaxisMin
	//        objCloneParameter.YaxisMax = inobjparamter.YaxisMax
	//        objCloneParameter.YaxisMin = inobjparamter.YaxisMin

	//        '----------------------Clonong  parameter object ends -----------------------------
	//        Return objCloneParameter
	//        ''it is a clone obj which return through function

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
		// Procedure Name        :   funcAddChannelToCollection
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
		//'note;
		//'this is used to convert abs to T.
		//'this is used some function ,which shown in follwing code.
		//'here we are providing 16 bit as well as 32 bit code...



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
			//' mobjChannnels is a data structure
			gblnUVABS = false;
			//'flag for checkimg UV mode
			if (mobjChannnels.Count > 0) {
				//'if data structure count is not empty
				if (mobjChannnels.item(mintChannelIndex).Spectrums.Count > 0) {
					//For intXaxisIdx = gFuncGetIndexWv(mobjChannnels.item(mintChannelIndex).UVParameter.XaxisMin, False) To gFuncGetIndexWv(mobjChannnels.item(mintChannelIndex).UVParameter.XaxisMax, False)
					for (intXaxisIdx = 0; intXaxisIdx <= mobjChannnels.item(mintChannelIndex).Spectrums.item(0).Readings.Count - 1; intXaxisIdx++) {
						dblCurrYaxis = mobjChannnels.item(mintChannelIndex).Spectrums.item(0).Readings.item(intXaxisIdx).YaxisData;
						//k= 2047.0 + exp((2.0- ((addata.ad[i]-2047.0)*2.0/1638.4)) *log(10))*2048.0/100.0;
						dblNewYaxis = 2047.0 + Math.Exp((2.0 - ((dblCurrYaxis - 2047.0) * 2.0 / 1638.4)) * Math.Log(10)) * 2048.0 / 100.0;
						//'formulla for coveration
						mobjChannnels.item(mintChannelIndex).Spectrums.item(0).Readings.item(intXaxisIdx).YaxisData = dblNewYaxis;
					}
				}
			}
			funcClearGraph();
			//'for clearing a graph

			mobjChannnels.item(mintChannelIndex).EnegryParameter.YaxisMax = 100;
			mobjChannnels.item(mintChannelIndex).EnegryParameter.YaxisMin = 0;

			funcClearGraph();

			funcDisplayGraph(mobjChannnels.item(mintChannelIndex));
			//'display a graph as par a current value of data structure
			funcGraphPreRequisite(mobjParameters.Cal_Mode, mobjParameters.XaxisMin, mobjParameters.XaxisMax, mobjParameters.YaxisMin, mobjParameters.YaxisMax);
			//'set a graph with current graph parameter
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
		// Parameters Passed     : pass a calibration mode
		// Returns               : None
		// Purpose               : 
		// Description           : Set Spectrum Parameter
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 21.11.06
		// Revisions             : 
		//=====================================================================

		//'note:
		//'this is used to set default parameter ot global obj objparameter
		static bool blnSetDefaultSpectrumParameter;
		try {
			funcSetDefaultSpectrumParameter = false;
			////----- Set the default parameter to the spectrum.
			if ((gobjInst.Mode == intCalibrationMode) & (blnSetDefaultSpectrumParameter == true)) {
				funcSetDefaultSpectrumParameter = true;
				return;
			}
			if (gobjCommProtocol.funcCalibrationMode(intCalibrationMode)) {
				//'serial communication function for setting calibration mode to the instrument

				//addataSpect.dblWvMin = 230.0
				//addataSpect.dblWvMax = 250.0

				//08.05.08
				//-----------------
				WvStartRange = Fix(gobjInst.WavelengthCur);
				WvLastRange = WvStartRange + 10;
				lblWvPos.Text = mXValueLable + FormatNumber(gobjInst.WavelengthCur, 2);
				//-----------------

				//08.05.08
				//mobjParameters.XaxisMin = const_WvMin
				//mobjParameters.XaxisMax = const_WvMax

				//08.05.08
				mobjParameters.XaxisMin = WvStartRange;
				mobjParameters.XaxisMax = WvLastRange;

				switch (gobjInst.Mode) {
					//'made a cond as par calibration mode
					//'select case as par calibration mode
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
				//01.09.09
				if (!gobjInst.Lamp_Position == 0) {
					mobjParameters.LampEle = gobjInst.Lamp.LampParametersCollection(gobjInst.Lamp_Position - 1).ElementName;
				}
				mobjParameters.LampTurrNo = gobjInst.Lamp_Position;
				//addataSpect.blnPloted = True
				////-----
				AASEnergySpectrum.AldysPane.Legend.IsVisible = false;
				//'hide a legend
				funcClearGraph();
				//'for clear a graph

				funcGraphPreRequisite(mobjParameters.Cal_Mode, mobjParameters.XaxisMin, mobjParameters.XaxisMax, mobjParameters.YaxisMin, mobjParameters.YaxisMax);
				//'for setting a graph as par current value
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
		// Parameters Passed     : calibration mode 
		// Returns               : None
		// Purpose               : 
		// Description           : Set Spectrum Parameter
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 21.11.06
		// Revisions             : 
		//=====================================================================
		//'note:
		//'this will set spectrum parameter as par mode.
		try {
			funcSetSpectrumParameter = false;
			////----- Set the default parameter to the spectrum.
			if (mblnReSetSpectrumParameter == false) {
				if ((gobjInst.Mode == intCalibrationMode)) {
					//'if given calibration mode is present or not
					funcSetSpectrumParameter = true;
					mblnReSetSpectrumParameter = true;
					return;
				}
			}

			if (gobjCommProtocol.funcCalibrationMode(intCalibrationMode)) {
				//'serial communication function for setting calibration mode to instrument 
				//addataSpect.dblWvMin = 230.0
				//addataSpect.dblWvMax = 250.0

				switch (gobjInst.Mode) {
					//'select case as par calibration mode
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
				//'clear the graph
				funcGraphPreRequisite(mobjParameters.Cal_Mode, mobjParameters.XaxisMin, mobjParameters.XaxisMax, mobjParameters.YaxisMin, mobjParameters.YaxisMax);
				//'set a graph as par given value
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

		//'note:
		//'this is used to set some default parameter on screen. 
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
			//'for eg above we are setting default parameter for PMT.

			mobjParameters.PMTV = gobjInst.PmtVoltage;
			////-----

			////----- Set D2 current Object
			if (gobjCommProtocol.SRLamp) {
				//cond for SR lamp
				intMaxD2Current = 600;
				intMinD2Current = 100;
			} else {
				intMaxD2Current = 300;
				intMinD2Current = 100;
			}

			//nudD2Cur.DecimalPlaces = 0
			//nudD2Cur.Increment = 1
			//nudD2Cur.Maximum = intMaxD2Current
			//nudD2Cur.Minimum = intMinD2Current
			nudD2Cur.DecimalPlace = 0;
			nudD2Cur.ChangeFactor = 1;
			nudD2Cur.MaxValue = intMaxD2Current;
			nudD2Cur.MinValue = intMinD2Current;


			nudD2Cur.Value = gobjInst.D2Current;
			mobjParameters.D2Curr = gobjInst.D2Current;
			if (mobjParameters.D2Curr == 100.0) {
				//'for D2 curr
				nudD2Cur.Text = "D2 Off";
			}

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
			//'function for getting slit width
			mobjParameters.SlitWidth = (double)nudSlit.Value;
			//'getting slitwidth from screen to obj

			////----- added by Sachin Dokhale
			//If gobjInst.TurretPosition = 0 Then
			//mobjParameters.LampEle = gobjInst.ElementName
			//mobjParameters.LampTurrNo = gobjInst.TurretPosition
			//Else
			//01.09.09
			if (!gobjInst.Lamp_Position == 0) {
				mobjParameters.LampEle = gobjInst.Lamp.LampParametersCollection(gobjInst.Lamp_Position - 1).ElementName;
			}

			mobjParameters.LampTurrNo = gobjInst.Lamp_Position;
			//End If

			//mobjParameters.Cal_Mode = gobjInst.Mode
			//mobjParameters.ScanSpeed = CONST_SLOWStep

			////------------
			if (!(gstructSettings.AppMode == EnumAppMode.FullVersion_201)) {
				////----- Set Burner Height Object
				//nudBurnerHeight.DecimalPlaces = 2
				//nudBurnerHeight.Increment = 0.1
				//nudBurnerHeight.Maximum = 6.0
				//nudBurnerHeight.Minimum = 0.0

				//'for 201

				nudBurnerHeight.DecimalPlace = 2;
				nudBurnerHeight.ChangeFactor = 0.1;
				nudBurnerHeight.MaxValue = 6.0;
				nudBurnerHeight.MinValue = 0.0;
				dblBhHeight = gobjClsAAS203.funcReadBurnerHeight();
				nudBurnerHeight.Value = gobjClsAAS203.funcReadBurnerHeight();
				mobjParameters.BurnerHeight = (double)nudBurnerHeight.Value;
				//'get a burner height in to object.

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
				//'serial communication function for setting NV position
				mdblFuelRatio = gobjClsAAS203.funcGet_Fuel_Ratio(true);
				if (mdblFuelRatio < 0.0) {
					//'setting some validation
					mdblFuelRatio = 0.0;
				} else {
					mdblFuelRatio = Format(mdblFuelRatio, "#0.00");
				}
				nudFuelRatio.Value = mdblFuelRatio;
				mobjParameters.FualRatio = mdblFuelRatio;
				//'serial communication function for getting fuel ratio
				//mdblFuelRatio = Format(mdblFuelRatio, "#.00")
				//'for formatting a fuel ratio
				//nudFuelRatio.Value = mdblFuelRatio
				//mobjParameters.FualRatio = mdblFuelRatio
				////-----
				nudFuelRatio.Visible = true;
				nudBurnerHeight.Visible = true;
				lblFuelRatio.Visible = true;
				lblBurnerHeight.Visible = true;
				lblBurnerHeightmm.Visible = true;
				cmbModes.Visible = true;
				lblModes.Visible = true;
			} else {
				nudFuelRatio.Visible = false;
				nudBurnerHeight.Visible = false;
				lblFuelRatio.Visible = false;
				lblBurnerHeight.Visible = false;
				lblBurnerHeightmm.Visible = false;
				lblModes.Top = lblFuelRatio.Top;
				cmbModes.Top = nudFuelRatio.Top;
				cmbModes.Visible = true;
				lblModes.Visible = true;
				////-----------
			}

			cmbModes.SelectedIndex = gobjInst.Mode;

			if (gstructSettings.AppMode == EnumAppMode.FullVersion_201) {
				//'cond for 201

				mobjParameters.ScanSpeed = CONST_SLOWStep_AA201;
			} else {
				mobjParameters.ScanSpeed = CONST_SLOWStep;
			}
			cmbSpeed.SelectedIndex = 2;

			lblWvPos.Text = "Wavelength (nm) : " + gobjInst.WavelengthCur;
			//mobjParameters.ScanSpeed = CONST_FASTStep
			lblYValue.Text = mYValueLable;
			lblYValue.Refresh();
			////-----

			funcSetDefaultParameter = true;
		//'return true if succed
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
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
		// Parameters Passed     : dblPmtV, value of pmt , which is to be set 
		// Returns               : Boolean
		// Purpose               : 
		// Description           : Set Pmt Volt Parameter
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 22.11.06
		// Revisions             : 
		//=====================================================================
		//'note:
		//'this is used to set the pmt value to the instrument
		//'before sending pmt value ,check it for validation.
		//'it should be in range 0-700.
		double dblPMTVolt;
		double dblAdjPMTVolt;

		try {
			funcSetPmtVParameter = false;
			dblPMTVolt = gobjInst.PmtVoltage;
			//'below we are performing some range validator

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
					//'serial communication function for setting PMT value to instrument
					//gobjInst.PmtVoltage = dblPMTVolt
					funcSetPmtVParameter = true;
				}

				mobjParameters.PMTV = Val(dblPMTVolt);
				//'save this new PMT value to data structure also
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
		// Parameters Passed     : dblHCL_Cur, which is to be set.
		// Returns               : Boolean
		// Purpose               : 
		// Description           : Set HCL Current Parameter
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 22.11.06
		// Revisions             : 
		//=====================================================================
		//'note:
		//'this is used to set HCL current to the instrument
		//'before sending it to instrument chack for validation
		//'it should be in range 0-25. 

		double dblLampCurrent;

		try {
			funcSetHCL_CurParameter = false;

			if (gobjInst.Lamp_Position >= 1 & gobjInst.Lamp_Position <= gobjClsAAS203.funcGetMaxLamp()) {
				//'check for lamp position
				dblLampCurrent = gobjInst.Current;
				//dblHCL_Cur()
				dblLampCurrent = dblHCL_Cur;
				if (dblHCL_Cur > 25)
					dblLampCurrent = 25;
				if (dblHCL_Cur < 0)
					dblLampCurrent = 0;
				gobjCommProtocol.funcSet_HCL_Cur(dblLampCurrent, gobjInst.Lamp_Position);
				//'serial communication function for setting HCL curr to instrument
				//'save new value of HCL current to data structure also
				gobjInst.Current = dblLampCurrent;
			}
			mobjParameters.HCLCurr = Val(dblLampCurrent);
			//'store a HCL current into object also.
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
		// Parameters Passed     : dblD2_Cur,which is to be set.
		// Returns               : Boolean
		// Purpose               : 
		// Description           : Set D2 Current Parameter
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 22.11.06
		// Revisions             : 
		//=====================================================================


		//'note;
		//'this is used to set the D2 current 
		//'before sending it ,cheak it for validation.
		//'


		object intMaxD2Current = 300;
		object intMinD2Current = 100;
		int D2CurrIncrDecr;
		double intD2Lamp_Cur = 0;

		try {
			funcSetD2_CurParameter = false;
			if (gobjCommProtocol.SRLamp) {
				//'cond for SR lamp
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
			//'serial communication.
			if (gobjCommProtocol.SRLamp) {
				//'serial communication function 
				gobjInst.D2Current = intD2Lamp_Cur;
			} else {
				if (intD2Lamp_Cur == 100) {
				}
			}
			mobjParameters.D2Curr = Val(intD2_Cur);
			//'save new value to data structure also
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
		// Parameters Passed     : dblSlit_Width,slitwidth which is to be set.
		// Returns               : Boolean
		// Purpose               : 
		// Description           : Set Slit Width Parameter
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 22.11.06
		// Revisions             : 
		//=====================================================================

		//'note:
		//'used to set a slit width parameter
		//'it should be in range 0 - 2.0 nm.



		double dblSlitWidth;
		double dblAdjSlitWidth;

		try {
			funcSetSlit_WidthParameter = false;

			dblSlitWidth = gobjClsAAS203.funcGet_SlitWidth();
			//'get the slitwidth as par instrument type
			//'here we are going to validate slitwidth 
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
			//'serial communication function for setting slitwidth
			//'after validate send adjust slitwidth to instrument

			mobjParameters.SlitWidth = Val(dblSlitWidth);
			//'get a slitwidth in database object too.
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

	private double funcSetFuelParameter(double dblFuel)
	{
		//=====================================================================
		// Procedure Name        : funcSetFuelParameter
		// Parameters Passed     : dblFuel , fuel which is to be set
		// Returns               : Double
		// Purpose               : 
		// Description           : Set Fuel Parameter
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 22.11.06
		// Revisions             : 
		//=====================================================================

		//'note:
		//'this is used to set fuel to instrument 
		//'check for validation.



		try {
			funcSetFuelParameter = false;
			//---
			//If Not (mdblFuelRatio = dblFuel) Then
			//    'Call gobjClsAAS203.funcSetFuel(CDbl(nudFuelRatio.Value))
			//    Call gobjClsAAS203.funcSetFuel(dblFuel)
			//    ''function for setting fuel
			//End If

			//'Call gobjCommProtocol.funcGet_NV_Pos()
			///serial communication function for setting fuel
			//mdblFuelRatio = gobjClsAAS203.funcGet_Fuel_Ratio(True)
			//If mdblFuelRatio < 0.0 Then
			//    ''setting some validation
			//    mdblFuelRatio = 0.0
			//Else
			//    mdblFuelRatio = Format(mdblFuelRatio, "#0.00")
			//End If
			//nudFuelRatio.Value = mdblFuelRatio
			//---
			//---above code is commented and called following 
			//---function to set fuel according to value editor 
			//---button clicked
			////---- Added by Sachin Dokhale. Stop the Timer Energy Display 
			TimerEnergyDisplay.Enabled = false;
			FuncIncrDecrFuel((double)nudFuelRatio.Value);

			//mobjParameters.FualRatio = mdblFuelRatio
			//'get a fuel ratio in a temp variable
			//mobjParameters.FualRatio = mdblFuelRatio
			//mdblFuelRatio = Format(mdblFuelRatio, "#0.00")
			//'format a decimal order
			funcSetFuelParameter = mdblFuelRatio;
			////---- Added by Sachin Dokhale. Start the Timer Energy Display 
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
		// Parameters Passed     : dblBurner_Height, burner height which is to be set 
		// Returns               : Double
		// Purpose               : 
		// Description           : Set Burner Height Parameter
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 22.11.06
		// Revisions             : 
		//=====================================================================

		//'note:
		//'this is used for setting burner height
		//'this is set burner height by setting burner step.
		//'check for validation before sending to instrument.
		double dblBurnerHeight;
		try {
			////---- Added by Sachin Dokhale. Stop the Timer Energy Display 
			TimerEnergyDisplay.Enabled = false;
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
			gobjClsAAS203.funcSetBHPos(FormatNumber(dblBurner_Height, 1));
			//'this function set the burner step(height) as par given value
			dblBhHeight = gobjClsAAS203.funcReadBurnerHeight();
			//'now this read a burner spep , convert it in height and return it
			funcSetBurner_HeightParameter = dblBhHeight;
			////---- Added by Sachin Dokhale. Start the Timer Energy Display 
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
			////---- Added by Sachin Dokhale. Stop the Timer Energy Display 
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
			////---- Added by Sachin Dokhale. Start the Timer Energy Display 
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

	public bool funcOnSpect(bool BaseLine, ref System.Object lblScanStatus, ref System.Object lblOnlineWv)
	{
		//=====================================================================
		// Procedure Name        : funcOnSpect
		// Parameters Passed     :  
		// Returns               : Double
		// Purpose               : 
		// Description           : to start a spectrum by starting a thread.
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 22.11.06
		// Revisions             : 
		//=====================================================================

		//'note:
		//'this is main function from where spectrum, is started
		//'here baseline is a flag which , indicate whatever baseline is completed or not 

		////----- Orig
		//addata.counter = 0;
		// if (addata.speed==0){
		//if (GetInstrument()==AA202) addata.speed=FASTSTEP_AA202;
		//else addata.speed=FAST;
		// }
		// speed = addata.speed;
		///-----
		//addataSpect.intCounter = 0
		//If (addataSpect.intSpeed = 0) Then
		//    addataSpect.intSpeed = CONST_STEPS_PER_NM
		//End If



		//Dim ObjParameter As New Spectrum.EnergySpectrumParameter
		mobjOnlineChannel = new Spectrum.Channel(true);
		//'make a object of data structure
		//ObjParameter = funcCloneParameter(mobjParameters)
		//'make a copy of all parameter from one obj to another
		//mobjOnlineChannel.EnegryParameter = ObjParameter

		mobjOnlineChannel.EnegryParameter = mobjSpectrum.funcCloneESParameter(mobjParameters);
		//'assgin them to current data structure
		//ObjParameter = Nothing

		if (!funcGraphPreRequisite(mobjParameters.Cal_Mode, mobjParameters.XaxisMin, mobjParameters.XaxisMax, mobjParameters.YaxisMin, mobjParameters.YaxisMax)) {
			//'set the graph as par prerequisite
			//Call gFuncShowMessage("Error in setting spectrum parameters", "Please Check Entered Spectrum Parameters", modConstants.EnumMessageType.Information)
			return;
		}

		mblnAvoidProcessing = true;
		mobjOnlineReadings = new Spectrum.Readings();

		mblnSpectrumStarted = true;
		mblnAvoidProcessing = true;
		//RemoveHandler mnuIgnite.Click, AddressOf btnAutoIgnition_Click

		//--- Start the Spectrum analysis
		//mobjController.Start(New clsBgSpectrum(lblWvPos, lblOnlineWv, _
		//              mobjParameters.XaxisMax, _
		//              mobjParameters.XaxisMin, _
		//              mobjParameters.YaxisMax, _
		//              mobjParameters.YaxisMin, _
		//              mobjParameters.Cal_Mode, _
		//              mobjParameters.ScanSpeed))

		mobjController = new clsBgThread(this);
		mobjclsBgSpectrum = new clsBgSpectrum(lblWvPos, lblOnlineWv, mobjParameters.XaxisMax, mobjParameters.XaxisMin, mobjParameters.YaxisMax, mobjParameters.YaxisMin, mobjParameters.Cal_Mode, mobjParameters.ScanSpeed, 0, false);

		//'TurretOptimizationThread = New clsBgTurretOptimization(lblPMT, lblTurretPosition, lblTurretOptimisation, mdblLampCurrent, mintLampPosition, aasGraphTurretOptimisation)
		mobjController.Start(mobjclsBgSpectrum);
		//'note:
		//'for starting a spectrum thread 
		//'which get a current value from instrument 
		//'and display it on graph

		//WP1=-1;
		// addata.Saved=FALSE;;
		// disp_Cur_wv_abs(hwnd);
		// hdc= GetDC(hwnd);
		///* IncrColor();
		// Hpen =  (HPEN) CreatePen(PS_SOLID, 1, RGB(Color[Colptr][0],Color[Colptr][1],Color[Colptr][2]));
		// hpenold= (HPEN) SelectObject(hdc, Hpen);
		//*/
		//funcWavelength_Position(hdc,SpectGraph.Xmin, 20, 372 );

		////----- This is for UV Spectrum

		//If (UVS) = True Then
		//    If (!UVABS) Then
		//        UVABS = True
		//        SpectGraph.Ymin = 0
		//        SpectGraph.Ymax = 1.0
		//        Scroll_Mode1(hwnd, IDC_MODE, -1)
		//    End If
		//    If (Inst.d2Pmt = 0) Then
		//        Adj_D2Gain(hwnd, True, 15, 372)
		//        Wavelength_Position(hdc, SpectGraph.Xmin, 20, 372)
		//    End If
		//    UvSpectReading(hwnd, hdc, gblnBaseLine)
		////-----



		//funcSpectReading(hwnd, hdc)

		//End If
		////----- Set the Wavelength Position
		//Wavelength_Position(hdc, SpectGraph.Xmin, 20, 372)

		///* SelectObject(hdc, hpenold);
		//DeleteObject(Hpen);
		//*/
		//ReleaseDC(hwnd,hdc);

		//disp_Cur_wv_abs(hwnd);
		funcOnSpect = true;
	}

	//    Private Sub subRearrangeFrmOBJ()
	//        =====================================================================
	//        Procedure(Name) : subInitialise()
	//        Parameters(Passed) : None()
	//Returns: None()
	//Purpose:
	//         Description           : Initialise the form Object
	//Assumptions:
	//Dependencies:
	//Author: Sachin(Dokhale)
	//         Created               : 21.11.06
	//Revisions:
	//        =====================================================================
	//        Dim objWait As New CWaitCursor
	//        Try
	//            Dim intPanelWidth, intSplitWidth As Integer
	//            Dim intButtonWidth As Integer
	//            Dim intStatingPoint1, intStatingPoint2, intStatingPoint3 As Integer
	//            If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
	//                intPanelWidth = CustomPanelBottom.Width()
	//                intButtonWidth = btnAutoZero.Width
	//                intSplitWidth = intPanelWidth / 3

	//                If intPanelWidth > intButtonWidth Then
	//                    intStatingPoint1 = (intSplitWidth - intButtonWidth) / 2
	//                    btnAutoZero.Left = intStatingPoint1
	//                    intStatingPoint2 = intSplitWidth + intStatingPoint1
	//                    cmdChangeScale.Left = intStatingPoint2

	//                    intStatingPoint3 = (intSplitWidth * 2) + intStatingPoint1
	//                    btnReturn.Left = intStatingPoint3
	//                End If

	//                btnAutoZero.Visible = True
	//                cmdADJFlow.Visible = False
	//                cmdADJBH.Visible = False
	//                cmdChangeScale.Visible = True
	//                btnReturn.Visible = True
	//                nudBurnerHeight.Visible = False
	//                nudFuelRatio.Visible = False
	//                lblBurnerHeight.Visible = False
	//                lblBurnerHeightmm.Visible = False
	//                lblFuelRatio.Visible = False
	//                cmbSpeed.Top = lblFuelRatio.Top
	//                lblSpeed.Top = lblFuelRatio.Top
	//                cmbModes.Top = lblBurnerHeight.Top
	//                lblModes.Top = lblBurnerHeight.Top


	//            Else
	//                btnAutoZero.Visible = True
	//                cmdADJFlow.Visible = True
	//                cmdADJBH.Visible = True
	//                cmdChangeScale.Visible = True
	//                btnReturn.Visible = True
	//                nudBurnerHeight.Visible = True
	//                nudFuelRatio.Visible = True
	//            End If

	//        Catch ex As Exception
	//            ---------------------------------------------------------
	//            Error Handling And logging
	//            gobjErrorHandler.ErrorDescription = ex.Message
	//            gobjErrorHandler.ErrorMessage = ex.Message
	//            gobjErrorHandler.WriteErrorLog(ex)
	//            ---------------------------------------------------------
	//        Finally
	//            ---------------------------------------------------------
	//            Writing Execution log
	//            If CONST_CREATE_EXECUTION_LOG = 1 Then
	//                gobjErrorHandler.WriteExecutionLog()
	//            End If
	//            objWait.Dispose()
	//            ---------------------------------------------------------
	//        End Try
	//    End Sub

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
				Application.DoEvents();
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
						Application.DoEvents();
						//If (MessageBox.Show("DO YOU WISH TO OVERWRITE", "SAVE AS", MessageBoxButtons.YesNo) = DialogResult.Yes) Then
						if (!gfuncSerializeObject(objsfdSpectrum.FileName, objchannel)) {
							gobjMessageAdapter.ShowMessage(constErrorFileSaving);
							Application.DoEvents();
							//gFuncShowMessage("Error", "ERROR IN SAVING FILE.", EnumMessageType.Information)
						}
					} else {
						return true;
					}
				} else {
					if (!gfuncSerializeObject(objsfdSpectrum.FileName, objchannel)) {
						gobjMessageAdapter.ShowMessage(constErrorFileSaving);
						Application.DoEvents();
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
							Application.DoEvents();
							return false;
						}
					}

					objchannel = gfuncDeSerializeObject(objofdSpectrum.FileName, EnumDeserializeObjType.EnergySpectrum);
					//--- Add the new channel to the channels collection and 
					//--- accordingly save the channel file to the disk

					intChannel_no = funcAddChannelToCollection(objchannel);
					mintChannelIndex = intChannel_no;
					//blnYetFileNotSave = True  '---03.09.09
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
		//'this function is called for displayed a Edit form as par given value
		//'for eg strWinTitle will represent a forms title

		double InputValue;
		int intValue;
		try {
			mobjfrmEditValues = new frmEditValues();
			///'obj to form
			mobjfrmEditValues.LabelText = strWinTitle;

			mobjfrmEditValues.txtValue.Visible = true;
			switch (strWinTitle) {
				//'case for form title
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
			//'display a value at EDIT box
			mobjfrmEditValues.txtValue.Focus();
			mobjfrmEditValues.txtValue.SelectAll();
			if (mobjfrmEditValues.ShowDialog == DialogResult.Cancel) {
				Application.DoEvents();
				//'allow application to perfrom its panding work.
				mobjfrmEditValues.Dispose();
				return false;
			}
			//'below this we are perform some validation to input value
			//'input value must be in range
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
			//'accept the input value
			Application.DoEvents();
			//'allow application to perfrom its panding work

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

	#End Region

	#Region " Code for Enable and Disable"

	private object func_Enable_Disable(int intProcess, int intStart_End)
	{

		//=====================================================================
		// Procedure Name        : func_Enable_Disable
		// Parameters Passed     : 
		// Returns               : 
		// Purpose               : 
		//                         
		// Description           : to enable /disable the control as par current process
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : Apr 01, 2007 4:00 pm
		// Revisions             : 1
		//=====================================================================
		try {
			//'note:
			//'this is for enable/disable a control as par process
			//'here process means a state of a form
			switch (intProcess) {
				case EnumProcesses.FormInitialize:
				case EnumProcesses.EditSystemParamters:
					switch (intStart_End) {
						case EnumStart_End.Start_of_Process:
							subAll_Menus_Disable();
							btnClearSpectrum.Enabled = false;
							tlbbtnClearSpectrum.Enabled = false;
							btnReturn.Enabled = true;
							mnuExit.Enabled = true;
							tlbbtnReturn.Enabled = false;
							cmbSpeed.Enabled = false;
							cmbModes.Enabled = false;
							nudBurnerHeight.Enabled = false;
							nudFuelRatio.Enabled = false;
							//nudHCLCur.Enabled = False

							btnLampParameters.Enabled = false;
							tlbbtnLampParameters.Enabled = false;
							cmdChangeScale.Enabled = false;
							tlbbtnChangeScale.Enabled = false;
							tlbbtnSaveSpectrumFile.Enabled = false;
							tlbbtnPeakPick.Enabled = false;
							tlbbtnPositionToMaxima.Enabled = false;
							tlbbtnSmooth.Enabled = false;

							tlbbtnLoadspectrumFile.Enabled = false;

							//tlbbtnContiniousTimeScan.Enabled = False ''comment by PAnkaj on 06 Sup 07

							tlbbtnParameters.Enabled = false;

							tlbbtnPositionToMaxima.Enabled = false;
							//Added By Pankaj 21 May 07
							tlbbtnLampParameters.Enabled = false;
							btnLampParameters.Enabled = false;

							btnClearSpectrum.Enabled = false;
							tlbbtnClearSpectrum.Enabled = false;
						// tlbbtnPrintGraph.Enabled = False 'comment by PAnkaj on 06 Sup 07

						case EnumStart_End.End_of_Process:

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
							nudSlit.Enabled = true;
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
							//'Added by PAnkaj on 06 Sup 07
							mnuChangeScale.Enabled = true;
							//Added by PAnkaj on 06 Sup 07
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

							btnStart.Text = "&Stop";
							mnuStart.Text = "&Stop";
							tlbbtnStart.Text = "&Stop";
							btnStart.Image = Image.FromFile(Application.StartupPath + "\\Images\\cancel_1.ico");
							mnuStart.Image = Image.FromFile(Application.StartupPath + "\\Images\\cancel_1.ico");
							tlbbtnStart.Image = Image.FromFile(Application.StartupPath + "\\Images\\cancel_1.ico");
							AASEnergySpectrum.ShowXYPeak = false;
							AASEnergySpectrum.ShowXYValues = false;
							btnStart.Refresh();

							//nudD2Cur.Enabled = False
							//nudPMT.Enabled = False
							//nudSlit.Enabled = False
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
							//Added By Pankaj 21 May 07
							mnuLampParameters.Enabled = false;
							tlbbtnLampParameters.Enabled = false;
							btnLampParameters.Enabled = false;

							btnClearSpectrum.Enabled = false;
							mnuClearSpectrum.Enabled = false;
							tlbbtnClearSpectrum.Enabled = false;

							tlbbtnPrintGraph.Enabled = false;
							mnuPrintGraph.Enabled = false;
						//----

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
								tlbbtnStart.Text = "&Start";
								mnuStart.Text = "&Start";
								btnStart.Image = Image.FromFile(Application.StartupPath + "\\Images\\start.ico");
								tlbbtnStart.Image = Image.FromFile(Application.StartupPath + "\\Images\\start.ico");
								//Added By Pankaj 22 MAy 07
								mnuStart.Image = Image.FromFile(Application.StartupPath + "\\Images\\start.ico");
								//Added By Pankaj 22 May07

								btnStart.Enabled = true;
								mnuStart.Enabled = true;
								tlbbtnStart.Enabled = true;

								this.AASEnergySpectrum.btnPeakEdit.Enabled = true;
								this.AASEnergySpectrum.btnShowXYValues.Enabled = true;

								btnStart.Refresh();

								nudD2Cur.Enabled = true;
								nudPMT.Enabled = true;
								nudSlit.Enabled = true;
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

								tlbbtnPrintGraph.Enabled = true;
								mnuPrintGraph.Enabled = true;

								tlbbtnLoadspectrumFile.Enabled = true;
								mnuLoadSpectrunFile.Enabled = true;

								tlbbtnContiniousTimeScan.Enabled = true;
								mnuContiniousTimeScan.Enabled = true;
								//----
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

							mnuPositionToMaxima.Enabled = true;

							tlbbtnPositionToMaxima.Enabled = true;

						case EnumStart_End.Process_Running:

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
					}
				case EnumProcesses.ClearAndRedraw:
					//17 
					switch (intStart_End) {
						case EnumStart_End.Start_of_Process:


							subAll_Menus_Disable();
						case EnumStart_End.End_of_Process:

							subAll_Menus_Enable();
					}
				case EnumProcesses.StopsScan:
					//16 
					switch (intStart_End) {
						case EnumStart_End.Start_of_Process:

							subAll_Menus_Enable();
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
						case EnumStart_End.End_of_Process:

							mnuDataProcessing.Enabled = true;
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
			}
			Application.DoEvents();

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

			nudPMT.Enabled = blnEnabled;

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
		// Procedure Name        : subAll_Menus_Enable
		// Parameters Passed     : 
		// Returns               : 
		// Purpose               : 
		//                         
		// Description           : to enable /disable the control as par current process
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : Apr 01, 2007 4:00 pm
		// Revisions             : 1
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
		// Procedure Name        : subAll_Menus_Disable
		// Parameters Passed     : 
		// Returns               : 
		// Purpose               : 
		//                         
		// Description           : to enable /disable the control as par current process
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : Apr 01, 2007 4:00 pm
		// Revisions             : 1
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
			//'this will run in background.
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

	#Region " IClient Events for receiving the wavelength and Abs value from Receiving thread "

	private void BgThread.Iclient.TaskStarted(clsBgThread BgThread)
	{
		//=====================================================================
		// Procedure Name        : TaskStarted
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : for starting a task.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 
		// Revisions             : praveen
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
		// Procedure Name        : TaskStatus
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : for display a task.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 
		// Revisions             : praveen
		//=====================================================================
		try {
			//If gstructApplicationSessionState.intInstrument_Group = EnumInstrumentGroup.Initialize_2600_2700 Then
			funcIclientTaskDisplayData(Text);
			if (!(mobjclsBgSpectrum == null)) {
				mobjclsBgSpectrum.EndProcess = true;
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
		// Procedure Name        : TaskFailed
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : for handleing a task failed
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 
		// Revisions             : praveen
		//=====================================================================
		try {
			//--- Dispose all the objects
			//mobjTemporaryChannel = New Channel
			//mobjTemporaryReadings = New Readings
			//mobjTemporaryReadings_2100 = New Readings
			mAvoidProcessBtn = true;
			funcIclientTaskFalied();

			mblnSpectrumStarted = false;
			//'pause a spectrum
			mblnAvoidProcessing = false;
			statStartGraph = false;
			mAvoidProcessBtn = false;
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
		// Procedure Name        : TaskCompleted
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : for handleing a task completion.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 
		// Revisions             : praveen
		//=====================================================================
		try {
			//If gstructApplicationSessionState.intInstrument_Group = EnumInstrumentGroup.Initialize_2600_2700 Then
			//    'Call funcIclientTaskCompleted2600()
			//ElseIf gstructApplicationSessionState.intInstrument_Group = EnumInstrumentGroup.Initialize_2100_2200_2300 Then
			//    'Call funcIclientTaskCompleted2100()
			//End If
			mAvoidProcessBtn = true;
			funcIclientTaskCompleted();

			mblnSpectrumStarted = false;
			mblnAvoidProcessing = false;
			statStartGraph = false;
			mAvoidProcessBtn = false;
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
		// Procedure Name        : funcIclientTaskDisplayData
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : thios will display a data on screen.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 
		// Revisions             : praveen
		//=====================================================================

		try {
			//Data in the Text arg would be "Wavelength|Abs"

			Spectrum.Data objData = new Spectrum.Data();
			string[] arrData;
			int O;
			// same as in function funcSmoothgraphonline
			int intCount;
			Application.DoEvents();
			//--- Split the data for Wv and Abs
			arrData = Split(strData, "|");


			if (arrData(0).Length > 0 & arrData(1).Length > 0) {
				objData.XaxisData = Format(Val(arrData(0)), "#000.0000");
				// wv
				//objData.XaxisData = Val(arrData(0))     ' wv

				//Select Case mobjTemporaryChannel.Parameter.ScanMode
				//    Case EnumScanMode.Absorbance
				//        objData.YaxisData = Format(Val(arrData(1)), "#0.000")
				//    Case EnumScanMode.Transmittance
				//        objData.YaxisData = Format(Val(arrData(1)), "#0.0")
				//    Case EnumScanMode.Energy
				//        objData.YaxisData = Format(Val(arrData(1)), "#0.0")
				//End Select

				//objData.YaxisData = Format(Val(arrData(1)), "#0.000")
				objData.YaxisData = Val(arrData(1));
				if (!(arrData(2) == null)) {
					if (arrData(2).Length > 0) {
						objData.YaxisADCData = Val(arrData(2));
					} else {
						objData.YaxisADCData = 0.0;
						//Format(Val(arrData(1)), "#0.000")
					}
				}
				//O = (ORDER - 1) / 2

				//If Val(arrData(2)) = 1 Then  'EnumUVProtocol.Data Then

				//--- Add the reading to the temp readings collection
				//mobjTemporaryReadings.Add(objData)

				//lblOnlineWv.Text = Format(mobjTemporaryReadings.item(mobjTemporaryReadings.Count - 1).XaxisData, "#000.0")
				mobjOnlineReadings.Add(objData);

				//lblWvPos.Text = Format(objData.mXaxisData, "#000.0")

				//Select Case mobjTemporaryChannel.Parameter.ScanMode
				//    Case EnumScanMode.Absorbance
				//        lblOnlineABS.Text = Format(mobjTemporaryReadings.item(mobjTemporaryReadings.Count - 1).YaxisData, "#0.000")
				//    Case EnumScanMode.Transmittance, EnumScanMode.Energy
				//        lblOnlineABS.Text = Format(mobjTemporaryReadings.item(mobjTemporaryReadings.Count - 1).YaxisData, "#0.0")
				//End Select

				//lblYValue.Text = Format(objData.mYaxisData, "#000.0")   'Format(mobjTemporaryReadings.item(mobjTemporaryReadings.Count - 1).YaxisData, "#0.0")
				funcDisplayGraph_RealTime(objData.XaxisData, objData.YaxisData);
				//If gblnSmoothFlag Then
				//If mobjTemporaryReadings.Count < ORDER Then
				//    NPSmoothningdata(mobjTemporaryReadings.Count) = objData.YaxisData
				//End If

				//If (mobjTemporaryReadings.Count - 1) < ((ORDER - 1) / 2) Then

				//    funcDisplayGraph_RealTime(mobjTemporaryReadings.item(mobjTemporaryReadings.Count - 1).XaxisData, _
				//                              mobjTemporaryReadings.item(mobjTemporaryReadings.Count - 1).YaxisData)

				//ElseIf mobjTemporaryReadings.Count >= ORDER Then
				//    gfuncSmoothOnlineGraph(mobjTemporaryReadings, NPSmoothningdata)
				//    funcDisplayGraph_RealTime(mobjTemporaryReadings.item((mobjTemporaryReadings.Count - 1) - O).XaxisData, _
				//                              mobjTemporaryReadings.item((mobjTemporaryReadings.Count - 1) - O).YaxisData)
				//End If
				//Else  ' if not gblnsmoothgraph then there is no need to smooth the graph
				//funcDisplayGraph_RealTime(mobjTemporaryReadings.item(mobjTemporaryReadings.Count - 1).XaxisData, _
				//                          mobjTemporaryReadings.item(mobjTemporaryReadings.Count - 1).YaxisData)
				//End If
				//End If

				//If Val(arrData(2)) = EnumUVProtocol.CMD_End _
				//Or Val(arrData(2)) = EnumUVProtocol.Spect_End _
				//Or Val(arrData(2)) = EnumUVProtocol.CMD_Acknowledge Then

				//If Val(arrData(2)) = 0 Then 'EnumUVProtocol.CMD_End _


				//End If

				//If gblnSmoothFlag Then
				//    For intCount = (((ORDER - 1) / 2) - 1) To 0 Step -1
				//        funcDisplayGraph_RealTime(mobjTemporaryReadings.item((mobjTemporaryReadings.Count - 1) - intCount).XaxisData, _
				//                                  mobjTemporaryReadings.item((mobjTemporaryReadings.Count - 1) - intCount).YaxisData)
				//    Next
				//End If
				//End If
			}

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
						//'stoppnline graph
					}
				}
			}
			Application.DoEvents();
			//'allow application to perfrom its panding work.

			AASEnergySpectrum.AldysPane.AxisChange();
			AASEnergySpectrum.Refresh();


			if (!funcSpectrumReadingCompleted()) {
			}

			if (gblnSpectrumTerminated == true) {
				funcScanCompleted(false);

			//scan is completed 
			} else {
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
			func_Enable_DisableControl(true);
			//---11.09.09
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
			mnuStart.Text = "&Start";
			btnStart.Image = Image.FromFile(Application.StartupPath + "\\Images\\start.ico");
			mnuStart.Image = Image.FromFile(Application.StartupPath + "\\Images\\start.ico");
			btnStart.Enabled = true;
			this.AASEnergySpectrum.btnShowXYValues.Enabled = true;
			this.AASEnergySpectrum.btnPeakEdit.Enabled = true;
			this.mnuPeakEdit.Enabled = true;
			this.tlbbtnPeakEdit.Enabled = true;
			this.mnuShowXYValues.Enabled = true;
			this.tlbbtnShowXYValues.Enabled = true;
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
		// Procedure Name        : funcGraphPreRequisite
		// Parameters Passed     : 
		// Returns               : 
		// Purpose               : 
		//                         
		// Description           : to set a graph pre _requisite of graph
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : Apr 01, 2007 4:00 pm
		// Revisions             : 1
		//=====================================================================
		double dblDiffX;
		double dblMajorStepX;
		double dblMinorStepX;
		double dblDiffY;
		double dblMajorStepY;
		double dblMinorStepY;


		try {


			dblDiffX = Fix(intXmax - intXmin);
			//'get a X axis range
			dblMajorStepX = dblDiffX / 10;
			//'get X major step
			dblMinorStepX = dblMajorStepX / 2;
			//'get X minor step.
			dblDiffY = (intYmax - intYmin);
			//'get Y axis range
			dblMajorStepY = dblDiffY / 10;
			//'get Y major step
			dblMinorStepY = dblMajorStepY / 2;
			///get Y minor step.
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
				//'slect case as per calibration
				case EnumCalibrationMode.AA:
				case EnumCalibrationMode.AABGC:
				case EnumCalibrationMode.MABS:
					//'slect case as per calibration
					AASEnergySpectrum.YAxisMin = intYmin;
					AASEnergySpectrum.YAxisMax = intYmax;
					AASEnergySpectrum.YAxisMinorStep = 1;
					//AASEnergySpectrum.YAxisStep = 0.1
					//AASEnergySpectrum.YAxisLabel = "Abs"
					AASEnergySpectrum.YAxisLabel = "ABSORBANCE";
				case EnumCalibrationMode.HCLE:
				case EnumCalibrationMode.D2E:
					//'slect case as per calibration
					AASEnergySpectrum.YAxisMin = intYmin;
					AASEnergySpectrum.YAxisMax = intYmax;
					AASEnergySpectrum.YAxisLabel = "ENERGY";
				//AASEnergySpectrum.YAxisMinorStep = 5
				//AASEnergySpectrum.YAxisStep = 10
				case EnumCalibrationMode.EMISSION:
					//'slect case as per calibration
					AASEnergySpectrum.YAxisMin = intYmin;
					AASEnergySpectrum.YAxisMax = intYmax;
					//AASEnergySpectrum.YAxisMinorStep = 1
					//AASEnergySpectrum.YAxisStep = 10

					AASEnergySpectrum.YAxisLabel = "EMISSION";
				case EnumCalibrationMode.SELFTEST:
					//'slect case as per calibration
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
			AASEnergySpectrum.AldysPane.AxisChange();
			mnuGrid.Checked = true;
			mnuGrid.Checked = this.AASEnergySpectrum.IsShowGrid;
			mnuLegends.Checked = AASEnergySpectrum.AldysPane.Legend.IsVisible;
			this.AASEnergySpectrum.IsShowGrid = true;
			this.AASEnergySpectrum.btnPeakEdit.Checked = false;
			AASEnergySpectrum.Invalidate();
			AASEnergySpectrum.Refresh();
			Application.DoEvents();
			//'allow application to perfrom its panding work.

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
			//'get Y axis as per calibration
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
				mGraphCurveItem = AASEnergySpectrum.StartOnlineGraph(AASEnergySpectrum.YAxisLabel + " " + (intCurveIndex + 1).ToString, AASEnergySpectrum.GetColor(intCurveIndex), AldysGraph.SymbolType.NoSymbol);
				statStartGraph = true;
				ArrlstGraphCurveItem.Add(mGraphCurveItem);
				AASEnergySpectrum.PlotPoint(ArrlstGraphCurveItem.Item(intCurveIndex), dblXAxis, dblYAxis);
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

			Application.DoEvents();

			//--- Check if the X-coordinates and Y-coordinates are less than
			//--- Xmin and Ymin

			//If dblToY < mobjTemporaryChannel.Parameter.YaxisMin Then
			//    dblToY = mobjTemporaryChannel.Parameter.YaxisMin
			//Else
			//    mdblYaxis = dblToY
			//End If

			mdblYaxis = dblToY;
			mdblXaxis = dblToX;
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
					//'get a value from datastructure.

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
					mGraphCurveItem = objCurveItem;
					AASEnergySpectrum.AldysPane.CurveList(0).Label = AASEnergySpectrum.YAxisLabel;
					AASEnergySpectrum.Refresh();
					Application.DoEvents();
				}
			}
			Application.DoEvents();
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

	private void subRearrangeFrmOBJ()
	{
		//=====================================================================
		// Procedure Name        : subInitialise
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
		try {
			int intPanelWidth;
			int intSplitWidth;
			int intButtonWidth;
			int intStatingPoint1;
			int intStatingPoint2;
			int intStatingPoint3;
			int intStatingPoint4;
			if (gstructSettings.AppMode == EnumAppMode.FullVersion_201) {
				intPanelWidth = CustomPanelBottom.Width();
				intButtonWidth = cmdChangeScale.Width;
				intSplitWidth = intPanelWidth / 4;

				if (intPanelWidth > intButtonWidth) {
					intStatingPoint1 = (intSplitWidth - intButtonWidth) / 2;
					cmdChangeScale.Left = intStatingPoint1;

					intStatingPoint2 = intSplitWidth + intStatingPoint1;
					btnStart.Left = intStatingPoint2;

					intStatingPoint3 = (intSplitWidth * 2) + intStatingPoint1;
					btnClearSpectrum.Left = intStatingPoint3;

					intStatingPoint4 = (intSplitWidth * 3) + intStatingPoint1;
					btnReturn.Left = intStatingPoint4;
				}

				cmdChangeScale.Visible = true;
				btnReturn.Visible = true;
				btnLampParameters.Visible = false;
			//nudBurnerHeight.Visible = False
			//nudFuelRatio.Visible = False
			//lblBurnerHeight.Visible = False
			//lblBurnerHeightmm.Visible = False
			//lblFuelRatio.Visible = False
			//cmbModes.Top = lblFuelRatio.Location.Y  'nudFuelRatio.Location.Y
			//lblModes.Top = lblFuelRatio.Location.Y

			} else {
				cmdChangeScale.Visible = true;
				btnReturn.Visible = true;
				btnLampParameters.Visible = true;
				//nudBurnerHeight.Visible = True
				//nudFuelRatio.Visible = True
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

	internal bool funcClearGraph()
	{
		//=====================================================================
		// Procedure Name        : funcClearGraph
		// Parameters Passed     : 
		// Returns               : 
		// Purpose               : 
		//                         
		// Description           : for clearing the graph.
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : Apr 01, 2007 4:00 pm
		// Revisions             : 1
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
			//'remove High peak label
			AASEnergySpectrum.AldysPane.CurveList.Clear();
			ArrlstGraphCurveItem.Clear();
			AASEnergySpectrum.Invalidate();
			AASEnergySpectrum.Refresh();
			intCurveIndex = -1;

			Application.DoEvents();
			//'this will allow application to perfrom its panding work.


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

	private void btnIgnite_Click(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        :   btnIgnite_Click
		// Description           :   to handel the ignite click event.
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


		//'this is called when user click on ignite butto
		if (mblnAvoidProcessing == true) {
			return;
		}
		try {
			mblnAvoidProcessing = true;
			////---- Added by Sachin Dokhale. Stop the Timer Energy Display 
			TimerEnergyDisplay.Enabled = false;
			if (!IsNothing(gobjMain)) {
				//MsgBox("frmEnergy")
				//gobjMain.AutoIgnition()
				gobjCommProtocol.mobjCommdll.subTime_Delay(100);
				//'serial communication function for delay
				gobjClsAAS203.funcIgnite(true);
				//'function for ignite a flame
				funcGetInstParameter();
				//'function for getting current instrument cond after ignition
			}
			////---- Added by Sachin Dokhale. Start the Timer Energy Display 
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
		// Description           :   to handel the Extinguish click event.
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
			////---- Added by Sachin Dokhale. Stop the Timer Energy Display 
			TimerEnergyDisplay.Enabled = false;
			if (!IsNothing(gobjMain)) {
				//gobjMain.Extinguish()
				gobjCommProtocol.mobjCommdll.subTime_Delay(100);
				//'communication function for delay
				gobjClsAAS203.funcIgnite(false);
				//'function for put off the ignition
				funcGetInstParameter();
				//'get a current instrument cond after a ingition is off
			}
			////---- Added by Sachin Dokhale. Start the Timer Energy Display 
			TimerEnergyDisplay.Enabled = true;
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
			//objWait.Dispose()
			//---------------------------------------------------------
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
			////---- Added by Sachin Dokhale. Stop the Timer Energy Display 
			TimerEnergyDisplay.Enabled = false;
			gobjCommProtocol.mobjCommdll.subTime_Delay(100);
			//'delay
			gobjCommProtocol.funcSwitchOver();
			//'function for switching to N2O flame
			funcGetInstParameter();
			////---- Added by Sachin Dokhale. Start the Timer Energy Display 
			TimerEnergyDisplay.Enabled = true;
			//'get a current instrument status after switching to N2O flame
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
			////---- Added by Sachin Dokhale. Stop the Timer Energy Display 
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
			////---- Added by Sachin Dokhale. Start the Timer Energy Display 
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
			////---- Added by Sachin Dokhale. Stop the Timer Energy Display 
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
			////---- Added by Sachin Dokhale. Start the Timer Energy Display 
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
		// Description           :   On screen validation for  burner height.
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
		//'for disable all control during burner height
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
		// Description           :   On screen validation for  burner height.
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
frmEnergySpectrumMode_Activated(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        :   frmEnergySpectrumMode_Activated
		// Description           :   for activating a energy spectrum..
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
				//'for setting some default parameter

				nudD2Cur.Visible = true;
				nudPMT.Visible = true;
				//nudPMT_Ref.Visible = True
				nudSlit.Visible = true;
				//nudSlit_Ref.Visible = True
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
			gobjCommProtocol.funcReadADCFilter(10, intMV);
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
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

}

