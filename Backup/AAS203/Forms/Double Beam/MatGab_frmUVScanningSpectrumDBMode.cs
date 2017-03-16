using System.Threading;
using AAS203.Common;
using BgThread;
using System.IO;
using Microsoft.VisualBasic;
using AAS203.Spectrum;

public class frmUVScanningSpectrumDBMode : System.Windows.Forms.Form, Iclient
{

	#Region " Private Variable "
	//--- Declaration for the controller object of the BgThread
	private BgThread.clsBgThread mobjController = new BgThread.clsBgThread(this);

	private clsBgSpectrum mobjclsBgSpectrum;
	//Public WithEvents Status As System.Windows.Forms.TextBox

	private bool mblnSpectrumStarted;
	private bool mblnAvoidProcessing = false;
		//by pankaj on 2 Dec 07
	private bool mblnParameterProcessing = false;
	private double mdblYaxis;
	private double mdblXaxis;
	private AldysGraph.CurveItem mGraphCurveItem;
	private ArrayList ArrlstGraphCurveItem = new ArrayList();
	private int intCurveIndex = -1;
	private bool m_blnBaseline = true;
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
	private Spectrum.Channel mobjOnlineChannel = new Spectrum.Channel(false);
	private Spectrum.Readings mobjOnlineReadings = new Spectrum.Readings();
	private Spectrum.EnergyChannels mobjUVEnegyChannel = new Spectrum.EnergyChannels();

	private clsSpectrum mobjSpectrum = new clsSpectrum();
	//--- declaration of the Parameter object used to populate the 
	//--- parameter screen on the spectrum screen
	private Spectrum.UVSpectrumParameter mobjParameters = new Spectrum.UVSpectrumParameter();
	//--- Current channel index
	private int mintChannelIndex = -1;
	//----- Store the Peak and Valley

	private clsSpectrum.PeakValley[] mStuctPeaksValley = new clsSpectrum.PeakValley[99];
	private IO.Directory strPath;

	private bool blnYetFileNotSave = false;

	private string mYValueLable = const_Absorbance;
	private string mXValueLable = "Wavelength (nm): ";
	private string strfrmStatusTurretNo;

	private string strfrmStatusEle;
	private frmEditValues mobjfrmEditValues;
	private enumSelectBeamType mSelectedBeamType;

	private string mstrSelectedBeamType;

	private bool blnActivateStartUVSpectrum = false;
		#End Region
	private int m_bytCalibMode;

	#Region " Constant "
	private const  ConstFormLoad = "-UV Scanning Spectrum Mode";
	//Private Const const_WvMin = 0
	//Private Const const_WvMax = 100.0
	private const  const_WvMin = 190.0;
	private const  const_WvMax = 280.0;
	private const  const_YMinAbs = -0.4;
	private const  const_YMaxAbs = 1.0;
	private const  const_YMaxEnergy = 100;
	private const  const_YMinEnergy = 0.0;
	private const  const_YMaxTransmision = 100;
	private const  const_YMinTransmision = 0.0;
	private const  const_YMinEmission = 0.0;
	private const  const_YMaxEmission = 100.0;
	private const  const_YMinmVolt = -5000.0;
	private const  const_YMaxmVolt = 5000.0;
	//Private Const const_YMinmVolt = 0.0
	//Private Const const_YMaxmVolt = 4000.0

	private const  const_Absorbance = "Absorbance ";
	private const  const_Transmission = "Tranmission ";
	private const  const_Energy = "Energy ";
	private const  const_Emission = "Emission ";
	private const  const_Volt = "Volt (mV)";

	private const  const_GraphLedgend = "Sample Graph";
	#End Region

	#Region " Message Constant"
	private const  constBurerCuvette = 103;
	private const  constStartRef = 104;
	private const  constStartScan = 105;
		#End Region
	private const  constCuvetteBurner = 106;

	#Region " Windows Form Designer generated code "

	public frmUVScanningSpectrumDBMode()
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
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuFile;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuParameters;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuSaveSpectrumFile;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuDataProcessing;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuSmooth;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuPeakPick;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuAbsTransmission;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuExit;
	internal NETXP.Controls.Bars.CommandBarSeparatorItem CommandBarSeparatorItem1;
	internal GradientPanel.CustomPanel CustomPanelMain;
	internal NETXP.Controls.Bars.CommandBar MenuBarUV;
	internal NETXP.Controls.Bars.StatusBar StatusBar1;
	internal System.Windows.Forms.StatusBarPanel StatusBarPanelInfo;
	internal NETXP.Controls.Bars.ProgressPanel ProgressPanel;
	internal System.Windows.Forms.StatusBarPanel StatusBarPanelDate;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuLoadSpectrumFile;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuD2Peak;
	internal AAS203.AASGraph AASGraphUVSpectrum;
	internal GradientPanel.CustomPanel CustomPanelBottom;
	internal NETXP.Controls.XPButton btnStart;
	internal NETXP.Controls.XPButton btnBaseLine;
	internal NETXP.Controls.XPButton btnClearSpectrum;
	internal NETXP.Controls.XPButton btnReturn;
	internal GradientPanel.CustomPanel CustomPanelTop;
	internal System.Windows.Forms.Label lblYValue;
	internal System.Windows.Forms.Label lblWvPos;
	internal NETXP.Controls.XPButton cmdChangeScale;
	internal System.Windows.Forms.Label lblPMTVolts;
	internal System.Windows.Forms.Label lblD2CurmA;
	internal System.Windows.Forms.ComboBox cmbModes;
	internal System.Windows.Forms.Label lblModes;
	internal System.Windows.Forms.Label lblSpeed;
	internal System.Windows.Forms.ComboBox cmbSpeed;
	internal System.Windows.Forms.Label lblSlitWidth;
	internal System.Windows.Forms.Label lblD2Cur;
	internal System.Windows.Forms.Label lblPMT;
	internal CodeIntellects.Office2003Controls.Office2003Header Office2003Header1;
	internal CodeIntellects.Office2003Controls.Office2003Header Office2003Header2;
	internal GradientPanel.CustomPanel CustomPanelBack;
	internal NETXP.Controls.Bars.CommandBar ToolBar1;
	internal NETXP.Controls.Bars.CommandBar ToolBar;
	internal NETXP.Controls.Bars.CommandBarButtonItem tlbbtnReturn;
	internal NETXP.Controls.Bars.CommandBarSeparatorItem CommandBarSeparatorItem3;
	internal NETXP.Controls.Bars.CommandBarButtonItem tlbbtnParameters;
	internal NETXP.Controls.Bars.CommandBarButtonItem tlbbtnLoadspectrumFile;
	internal NETXP.Controls.Bars.CommandBarButtonItem tlbbtnSaveSpectrumFile;
	internal NETXP.Controls.Bars.CommandBarSeparatorItem CommandBarSeparatorItem4;
	internal NETXP.Controls.Bars.CommandBarButtonItem tlbbtnStart;
	internal NETXP.Controls.Bars.CommandBarButtonItem tlbbtnClearSpectrum;
	internal NETXP.Controls.Bars.CommandBarButtonItem tlbbtnChangeScale;
	internal NETXP.Controls.Bars.CommandBarSeparatorItem CommandBarSeparatorItem5;
	internal NETXP.Controls.Bars.CommandBarButtonItem tlbbtnSmooth;
	internal NETXP.Controls.Bars.CommandBarButtonItem tlbbtnPeakPick;
	internal NETXP.Controls.Bars.CommandBarButtonItem tlbbtnBaseLine;
	internal NETXP.Controls.Bars.CommandBarButtonItem tlbbtnAbsToTransmission;
	internal NETXP.Controls.Bars.CommandBarButtonItem CommandBarButtonItem1;
	internal ValueEditor.ValueEditor nudPMT;
	internal ValueEditor.ValueEditor nudD2Cur;
	internal ValueEditor.ValueEditor nudSlit;
	internal System.Windows.Forms.Label lblSlitnm;
	internal ValueEditor.ValueEditor nudPMT_Ref;
	internal System.Windows.Forms.Label lblPMTVolts_Ref;
	internal System.Windows.Forms.Label lblPMT_Ref;
	internal System.Windows.Forms.Label lblSlitnm_Ref;
	internal ValueEditor.ValueEditor nudSlit_Ref;
	internal System.Windows.Forms.Label lblSlitWidth_Ref;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuBaseLine;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuStart;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuClearSpectrum;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuGraphOptions;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuPeakEdit;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuGrid;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuLegends;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuShowXYValues;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuPrintGraph;
	internal NETXP.Controls.XPButton btnExtinguish;
	internal NETXP.Controls.XPButton btnIgnite;
	internal NETXP.Controls.Bars.CommandBarButtonItem tlbbtnPrintGraph;
	internal NETXP.Controls.Bars.CommandBarButtonItem CommandBarButtonItem2;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuChangeScale;
	internal NETXP.Controls.XPButton btnR;
	internal NETXP.Controls.XPButton btnDelete;
	[System.Diagnostics.DebuggerStepThrough()]
	private void InitializeComponent()
	{
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmUVScanningSpectrumDBMode));
		this.CustomPanelMain = new GradientPanel.CustomPanel();
		this.AASGraphUVSpectrum = new AAS203.AASGraph();
		this.Office2003Header2 = new CodeIntellects.Office2003Controls.Office2003Header();
		this.CustomPanelBottom = new GradientPanel.CustomPanel();
		this.btnStart = new NETXP.Controls.XPButton();
		this.btnBaseLine = new NETXP.Controls.XPButton();
		this.btnClearSpectrum = new NETXP.Controls.XPButton();
		this.btnReturn = new NETXP.Controls.XPButton();
		this.cmdChangeScale = new NETXP.Controls.XPButton();
		this.btnIgnite = new NETXP.Controls.XPButton();
		this.btnExtinguish = new NETXP.Controls.XPButton();
		this.btnR = new NETXP.Controls.XPButton();
		this.btnDelete = new NETXP.Controls.XPButton();
		this.MenuBarUV = new NETXP.Controls.Bars.CommandBar();
		this.mnuFile = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuParameters = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuLoadSpectrumFile = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuSaveSpectrumFile = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.CommandBarSeparatorItem1 = new NETXP.Controls.Bars.CommandBarSeparatorItem();
		this.mnuExit = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuDataProcessing = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuBaseLine = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuStart = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuSmooth = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuPeakPick = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuAbsTransmission = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuD2Peak = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuClearSpectrum = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuGraphOptions = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuPeakEdit = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuGrid = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuLegends = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuShowXYValues = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuPrintGraph = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuChangeScale = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.StatusBar1 = new NETXP.Controls.Bars.StatusBar();
		this.StatusBarPanelInfo = new System.Windows.Forms.StatusBarPanel();
		this.ProgressPanel = new NETXP.Controls.Bars.ProgressPanel();
		this.StatusBarPanelDate = new System.Windows.Forms.StatusBarPanel();
		this.CustomPanelTop = new GradientPanel.CustomPanel();
		this.lblSlitnm_Ref = new System.Windows.Forms.Label();
		this.nudSlit_Ref = new ValueEditor.ValueEditor();
		this.lblSlitWidth_Ref = new System.Windows.Forms.Label();
		this.nudPMT_Ref = new ValueEditor.ValueEditor();
		this.lblPMTVolts_Ref = new System.Windows.Forms.Label();
		this.lblPMT_Ref = new System.Windows.Forms.Label();
		this.lblSlitnm = new System.Windows.Forms.Label();
		this.nudSlit = new ValueEditor.ValueEditor();
		this.nudD2Cur = new ValueEditor.ValueEditor();
		this.nudPMT = new ValueEditor.ValueEditor();
		this.Office2003Header1 = new CodeIntellects.Office2003Controls.Office2003Header();
		this.lblYValue = new System.Windows.Forms.Label();
		this.lblWvPos = new System.Windows.Forms.Label();
		this.lblPMTVolts = new System.Windows.Forms.Label();
		this.lblD2CurmA = new System.Windows.Forms.Label();
		this.cmbModes = new System.Windows.Forms.ComboBox();
		this.lblModes = new System.Windows.Forms.Label();
		this.lblSpeed = new System.Windows.Forms.Label();
		this.cmbSpeed = new System.Windows.Forms.ComboBox();
		this.lblSlitWidth = new System.Windows.Forms.Label();
		this.lblD2Cur = new System.Windows.Forms.Label();
		this.lblPMT = new System.Windows.Forms.Label();
		this.CustomPanelBack = new GradientPanel.CustomPanel();
		this.ToolBar1 = new NETXP.Controls.Bars.CommandBar();
		this.ToolBar = new NETXP.Controls.Bars.CommandBar();
		this.tlbbtnReturn = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.CommandBarSeparatorItem3 = new NETXP.Controls.Bars.CommandBarSeparatorItem();
		this.tlbbtnParameters = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.tlbbtnLoadspectrumFile = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.tlbbtnSaveSpectrumFile = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.CommandBarSeparatorItem4 = new NETXP.Controls.Bars.CommandBarSeparatorItem();
		this.tlbbtnStart = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.tlbbtnBaseLine = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.tlbbtnClearSpectrum = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.tlbbtnChangeScale = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.CommandBarSeparatorItem5 = new NETXP.Controls.Bars.CommandBarSeparatorItem();
		this.tlbbtnSmooth = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.tlbbtnPeakPick = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.tlbbtnAbsToTransmission = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.CommandBarButtonItem1 = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.tlbbtnPrintGraph = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.CommandBarButtonItem2 = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.CustomPanelMain.SuspendLayout();
		this.CustomPanelBottom.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.MenuBarUV).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.StatusBarPanelInfo).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.ProgressPanel).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.StatusBarPanelDate).BeginInit();
		this.CustomPanelTop.SuspendLayout();
		this.CustomPanelBack.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.ToolBar1).BeginInit();
		this.ToolBar1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.ToolBar).BeginInit();
		this.SuspendLayout();
		//
		//CustomPanelMain
		//
		this.CustomPanelMain.BackColor = System.Drawing.Color.AliceBlue;
		this.CustomPanelMain.Controls.Add(this.AASGraphUVSpectrum);
		this.CustomPanelMain.Controls.Add(this.Office2003Header2);
		this.CustomPanelMain.Controls.Add(this.CustomPanelBottom);
		this.CustomPanelMain.Controls.Add(this.btnIgnite);
		this.CustomPanelMain.Controls.Add(this.btnExtinguish);
		this.CustomPanelMain.Controls.Add(this.btnR);
		this.CustomPanelMain.Controls.Add(this.btnDelete);
		this.CustomPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
		this.CustomPanelMain.Location = new System.Drawing.Point(198, 0);
		this.CustomPanelMain.Name = "CustomPanelMain";
		this.CustomPanelMain.Size = new System.Drawing.Size(608, 438);
		this.CustomPanelMain.TabIndex = 0;
		//
		//AASGraphUVSpectrum
		//
		this.AASGraphUVSpectrum.AldysGraphCursor = null;
		this.AASGraphUVSpectrum.AldysGraphPrintColor = System.Drawing.Color.Black;
		this.AASGraphUVSpectrum.BackColor = System.Drawing.Color.White;
		this.AASGraphUVSpectrum.Dock = System.Windows.Forms.DockStyle.Fill;
		this.AASGraphUVSpectrum.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.AASGraphUVSpectrum.GraphDataSource = null;
		this.AASGraphUVSpectrum.GraphImage = null;
		this.AASGraphUVSpectrum.IsShowGrid = true;
		this.AASGraphUVSpectrum.Location = new System.Drawing.Point(0, 22);
		this.AASGraphUVSpectrum.Name = "AASGraphUVSpectrum";
		this.AASGraphUVSpectrum.Size = new System.Drawing.Size(608, 335);
		this.AASGraphUVSpectrum.TabIndex = 26;
		this.AASGraphUVSpectrum.UseDefaultSettings = true;
		this.AASGraphUVSpectrum.XAxisDateMax = new System.DateTime((long)0);
		this.AASGraphUVSpectrum.XAxisDateMin = new System.DateTime((long)0);
		this.AASGraphUVSpectrum.XAxisDateScaleFormat = AAS203.AASGraph.enumDateScaleFormat.YYYY;
		this.AASGraphUVSpectrum.XAxisLabel = "X Values";
		this.AASGraphUVSpectrum.XAxisMax = 100;
		this.AASGraphUVSpectrum.XAxisMin = 0;
		this.AASGraphUVSpectrum.XAxisMinorStep = 5;
		this.AASGraphUVSpectrum.XAxisScaleFormat = null;
		this.AASGraphUVSpectrum.XAxisStep = 10;
		this.AASGraphUVSpectrum.XAxisType = AldysGraph.AxisType.Linear;
		this.AASGraphUVSpectrum.YAxisLabel = "Y Values";
		this.AASGraphUVSpectrum.YAxisMax = 100;
		this.AASGraphUVSpectrum.YAxisMin = -1;
		this.AASGraphUVSpectrum.YAxisMinorStep = 5;
		this.AASGraphUVSpectrum.YAxisScaleFormat = null;
		this.AASGraphUVSpectrum.YAxisStep = 10;
		this.AASGraphUVSpectrum.YAxisType = AldysGraph.AxisType.Linear;
		//
		//Office2003Header2
		//
		this.Office2003Header2.BackColor = System.Drawing.SystemColors.Control;
		this.Office2003Header2.Dock = System.Windows.Forms.DockStyle.Top;
		this.Office2003Header2.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.Office2003Header2.Location = new System.Drawing.Point(0, 0);
		this.Office2003Header2.Name = "Office2003Header2";
		this.Office2003Header2.Size = new System.Drawing.Size(608, 22);
		this.Office2003Header2.TabIndex = 27;
		this.Office2003Header2.TitleFont = new System.Drawing.Font("Tahoma", 10f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.Office2003Header2.TitleText = "Spectrum";
		//
		//CustomPanelBottom
		//
		this.CustomPanelBottom.BackColor = System.Drawing.Color.AliceBlue;
		this.CustomPanelBottom.Controls.Add(this.btnStart);
		this.CustomPanelBottom.Controls.Add(this.btnBaseLine);
		this.CustomPanelBottom.Controls.Add(this.btnClearSpectrum);
		this.CustomPanelBottom.Controls.Add(this.btnReturn);
		this.CustomPanelBottom.Controls.Add(this.cmdChangeScale);
		this.CustomPanelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
		this.CustomPanelBottom.Location = new System.Drawing.Point(0, 357);
		this.CustomPanelBottom.Name = "CustomPanelBottom";
		this.CustomPanelBottom.Size = new System.Drawing.Size(608, 81);
		this.CustomPanelBottom.TabIndex = 25;
		//
		//btnStart
		//
		this.btnStart.Enabled = false;
		this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnStart.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnStart.Image = (System.Drawing.Image)resources.GetObject("btnStart.Image");
		this.btnStart.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnStart.Location = new System.Drawing.Point(134, 25);
		this.btnStart.Name = "btnStart";
		this.btnStart.Size = new System.Drawing.Size(106, 38);
		this.btnStart.TabIndex = 1;
		this.btnStart.Text = "&Start";
		//
		//btnBaseLine
		//
		this.btnBaseLine.Enabled = false;
		this.btnBaseLine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnBaseLine.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnBaseLine.Image = (System.Drawing.Image)resources.GetObject("btnBaseLine.Image");
		this.btnBaseLine.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnBaseLine.Location = new System.Drawing.Point(252, 25);
		this.btnBaseLine.Name = "btnBaseLine";
		this.btnBaseLine.Size = new System.Drawing.Size(106, 38);
		this.btnBaseLine.TabIndex = 2;
		this.btnBaseLine.Text = "&Base Line";
		//
		//btnClearSpectrum
		//
		this.btnClearSpectrum.Enabled = false;
		this.btnClearSpectrum.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnClearSpectrum.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnClearSpectrum.Image = (System.Drawing.Image)resources.GetObject("btnClearSpectrum.Image");
		this.btnClearSpectrum.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnClearSpectrum.Location = new System.Drawing.Point(370, 25);
		this.btnClearSpectrum.Name = "btnClearSpectrum";
		this.btnClearSpectrum.Size = new System.Drawing.Size(106, 38);
		this.btnClearSpectrum.TabIndex = 3;
		this.btnClearSpectrum.Text = "C&lear Spectrum";
		this.btnClearSpectrum.TextAlign = System.Drawing.ContentAlignment.TopLeft;
		//
		//btnReturn
		//
		this.btnReturn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.btnReturn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnReturn.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnReturn.Image = (System.Drawing.Image)resources.GetObject("btnReturn.Image");
		this.btnReturn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnReturn.Location = new System.Drawing.Point(488, 25);
		this.btnReturn.Name = "btnReturn";
		this.btnReturn.Size = new System.Drawing.Size(106, 38);
		this.btnReturn.TabIndex = 4;
		this.btnReturn.Text = "Return";
		//
		//cmdChangeScale
		//
		this.cmdChangeScale.Enabled = false;
		this.cmdChangeScale.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.cmdChangeScale.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.cmdChangeScale.Image = (System.Drawing.Image)resources.GetObject("cmdChangeScale.Image");
		this.cmdChangeScale.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.cmdChangeScale.Location = new System.Drawing.Point(16, 25);
		this.cmdChangeScale.Name = "cmdChangeScale";
		this.cmdChangeScale.Size = new System.Drawing.Size(106, 38);
		this.cmdChangeScale.TabIndex = 0;
		this.cmdChangeScale.Text = "Change &Scale";
		this.cmdChangeScale.TextAlign = System.Drawing.ContentAlignment.TopLeft;
		//
		//btnIgnite
		//
		this.btnIgnite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnIgnite.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnIgnite.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnIgnite.Location = new System.Drawing.Point(144, 260);
		this.btnIgnite.Name = "btnIgnite";
		this.btnIgnite.Size = new System.Drawing.Size(25, 25);
		this.btnIgnite.TabIndex = 14;
		this.btnIgnite.TabStop = false;
		this.btnIgnite.Text = "&Ignition";
		this.btnIgnite.TextAlign = System.Drawing.ContentAlignment.TopLeft;
		this.btnIgnite.Visible = false;
		//
		//btnExtinguish
		//
		this.btnExtinguish.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnExtinguish.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnExtinguish.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnExtinguish.Location = new System.Drawing.Point(196, 236);
		this.btnExtinguish.Name = "btnExtinguish";
		this.btnExtinguish.Size = new System.Drawing.Size(25, 25);
		this.btnExtinguish.TabIndex = 15;
		this.btnExtinguish.TabStop = false;
		this.btnExtinguish.Text = "&Extinguish";
		this.btnExtinguish.TextAlign = System.Drawing.ContentAlignment.TopLeft;
		this.btnExtinguish.Visible = false;
		//
		//btnR
		//
		this.btnR.BackColor = System.Drawing.Color.Transparent;
		this.btnR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnR.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnR.Location = new System.Drawing.Point(306, 215);
		this.btnR.Name = "btnR";
		this.btnR.Size = new System.Drawing.Size(8, 8);
		this.btnR.TabIndex = 51;
		this.btnR.TabStop = false;
		this.btnR.Text = "&R";
		this.btnR.TextAlign = System.Drawing.ContentAlignment.TopLeft;
		//
		//btnDelete
		//
		this.btnDelete.BackColor = System.Drawing.Color.Transparent;
		this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnDelete.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnDelete.Location = new System.Drawing.Point(294, 215);
		this.btnDelete.Name = "btnDelete";
		this.btnDelete.Size = new System.Drawing.Size(8, 8);
		this.btnDelete.TabIndex = 52;
		this.btnDelete.TabStop = false;
		this.btnDelete.Text = "&Delete";
		this.btnDelete.TextAlign = System.Drawing.ContentAlignment.TopLeft;
		//
		//MenuBarUV
		//
		this.MenuBarUV.BackColor = System.Drawing.Color.Transparent;
		this.MenuBarUV.CustomBackground = true;
		this.MenuBarUV.CustomizeText = "&Customize Toolbar...";
		this.MenuBarUV.Dock = System.Windows.Forms.DockStyle.Top;
		this.MenuBarUV.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.MenuBarUV.FullRow = true;
		this.MenuBarUV.ID = 621;
		this.MenuBarUV.Items.AddRange(new NETXP.Controls.Bars.CommandBarItem[] {
			this.mnuFile,
			this.mnuDataProcessing,
			this.mnuGraphOptions
		});
		this.MenuBarUV.Location = new System.Drawing.Point(0, 0);
		this.MenuBarUV.Margins.Bottom = 1;
		this.MenuBarUV.Margins.Left = 1;
		this.MenuBarUV.Margins.Right = 1;
		this.MenuBarUV.Margins.Top = 1;
		this.MenuBarUV.Name = "MenuBarUV";
		this.MenuBarUV.Size = new System.Drawing.Size(806, 23);
		this.MenuBarUV.Style = NETXP.Controls.Bars.CommandBarStyle.Menu;
		this.MenuBarUV.TabIndex = 0;
		this.MenuBarUV.TabStop = false;
		this.MenuBarUV.Text = "";
		//
		//mnuFile
		//
		this.mnuFile.Items.AddRange(new NETXP.Controls.Bars.CommandBarItem[] {
			this.mnuParameters,
			this.mnuLoadSpectrumFile,
			this.mnuSaveSpectrumFile,
			this.CommandBarSeparatorItem1,
			this.mnuExit
		});
		this.mnuFile.PadHorizontal = 5;
		this.mnuFile.Text = "&File";
		//
		//mnuParameters
		//
		this.mnuParameters.Image = (System.Drawing.Image)resources.GetObject("mnuParameters.Image");
		this.mnuParameters.Text = "Parame&ters";
		//
		//mnuLoadSpectrumFile
		//
		this.mnuLoadSpectrumFile.Image = (System.Drawing.Image)resources.GetObject("mnuLoadSpectrumFile.Image");
		this.mnuLoadSpectrumFile.Text = "&Load Spectrum File";
		//
		//mnuSaveSpectrumFile
		//
		this.mnuSaveSpectrumFile.Image = (System.Drawing.Image)resources.GetObject("mnuSaveSpectrumFile.Image");
		this.mnuSaveSpectrumFile.Text = "&Save Spectrum File";
		//
		//mnuExit
		//
		this.mnuExit.Image = (System.Drawing.Image)resources.GetObject("mnuExit.Image");
		this.mnuExit.Shortcut = System.Windows.Forms.Shortcut.CtrlR;
		this.mnuExit.ShowText = true;
		this.mnuExit.Text = "Return";
		//
		//mnuDataProcessing
		//
		this.mnuDataProcessing.Items.AddRange(new NETXP.Controls.Bars.CommandBarItem[] {
			this.mnuBaseLine,
			this.mnuStart,
			this.mnuSmooth,
			this.mnuPeakPick,
			this.mnuAbsTransmission,
			this.mnuD2Peak,
			this.mnuClearSpectrum
		});
		this.mnuDataProcessing.PadHorizontal = 5;
		this.mnuDataProcessing.Text = "Data &Processing";
		//
		//mnuBaseLine
		//
		this.mnuBaseLine.Image = (System.Drawing.Image)resources.GetObject("mnuBaseLine.Image");
		this.mnuBaseLine.Shortcut = System.Windows.Forms.Shortcut.CtrlB;
		this.mnuBaseLine.Text = "Base Line";
		//
		//mnuStart
		//
		this.mnuStart.Image = (System.Drawing.Image)resources.GetObject("mnuStart.Image");
		this.mnuStart.Shortcut = System.Windows.Forms.Shortcut.CtrlT;
		this.mnuStart.Text = "Start";
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
		//mnuAbsTransmission
		//
		this.mnuAbsTransmission.Image = (System.Drawing.Image)resources.GetObject("mnuAbsTransmission.Image");
		this.mnuAbsTransmission.Shortcut = System.Windows.Forms.Shortcut.CtrlA;
		this.mnuAbsTransmission.Text = "&Abs -> % Transmission";
		//
		//mnuD2Peak
		//
		this.mnuD2Peak.Text = "D2 Peak";
		this.mnuD2Peak.Visible = false;
		//
		//mnuClearSpectrum
		//
		this.mnuClearSpectrum.Image = (System.Drawing.Image)resources.GetObject("mnuClearSpectrum.Image");
		this.mnuClearSpectrum.Shortcut = System.Windows.Forms.Shortcut.CtrlC;
		this.mnuClearSpectrum.Text = "Clear Spectrum";
		//
		//mnuGraphOptions
		//
		this.mnuGraphOptions.Items.AddRange(new NETXP.Controls.Bars.CommandBarItem[] {
			this.mnuPeakEdit,
			this.mnuGrid,
			this.mnuLegends,
			this.mnuShowXYValues,
			this.mnuPrintGraph,
			this.mnuChangeScale
		});
		this.mnuGraphOptions.Text = "Graph Options";
		//
		//mnuPeakEdit
		//
		this.mnuPeakEdit.Image = (System.Drawing.Image)resources.GetObject("mnuPeakEdit.Image");
		this.mnuPeakEdit.Text = "Peak Edit";
		//
		//mnuGrid
		//
		this.mnuGrid.Image = (System.Drawing.Image)resources.GetObject("mnuGrid.Image");
		this.mnuGrid.Text = "Grid";
		//
		//mnuLegends
		//
		this.mnuLegends.Image = (System.Drawing.Image)resources.GetObject("mnuLegends.Image");
		this.mnuLegends.Text = "Legends";
		//
		//mnuShowXYValues
		//
		this.mnuShowXYValues.Image = (System.Drawing.Image)resources.GetObject("mnuShowXYValues.Image");
		this.mnuShowXYValues.Text = "Show X, Y &Values";
		//
		//mnuPrintGraph
		//
		this.mnuPrintGraph.Image = (System.Drawing.Image)resources.GetObject("mnuPrintGraph.Image");
		this.mnuPrintGraph.Text = "Print Graph";
		//
		//mnuChangeScale
		//
		this.mnuChangeScale.Image = (System.Drawing.Image)resources.GetObject("mnuChangeScale.Image");
		this.mnuChangeScale.Text = "Change Scale";
		//
		//StatusBar1
		//
		this.StatusBar1.Location = new System.Drawing.Point(0, 495);
		this.StatusBar1.Name = "StatusBar1";
		this.StatusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
			this.StatusBarPanelInfo,
			this.ProgressPanel,
			this.StatusBarPanelDate
		});
		this.StatusBar1.ShowPanels = true;
		this.StatusBar1.Size = new System.Drawing.Size(806, 24);
		this.StatusBar1.TabIndex = 6;
		this.StatusBar1.Text = "StatusBar1";
		//
		//StatusBarPanelInfo
		//
		this.StatusBarPanelInfo.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
		this.StatusBarPanelInfo.MinWidth = 40;
		this.StatusBarPanelInfo.Style = System.Windows.Forms.StatusBarPanelStyle.OwnerDraw;
		this.StatusBarPanelInfo.Width = 511;
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
		//CustomPanelTop
		//
		this.CustomPanelTop.BackColor = System.Drawing.Color.AliceBlue;
		this.CustomPanelTop.Controls.Add(this.lblSlitnm_Ref);
		this.CustomPanelTop.Controls.Add(this.nudSlit_Ref);
		this.CustomPanelTop.Controls.Add(this.lblSlitWidth_Ref);
		this.CustomPanelTop.Controls.Add(this.nudPMT_Ref);
		this.CustomPanelTop.Controls.Add(this.lblPMTVolts_Ref);
		this.CustomPanelTop.Controls.Add(this.lblPMT_Ref);
		this.CustomPanelTop.Controls.Add(this.lblSlitnm);
		this.CustomPanelTop.Controls.Add(this.nudSlit);
		this.CustomPanelTop.Controls.Add(this.nudD2Cur);
		this.CustomPanelTop.Controls.Add(this.nudPMT);
		this.CustomPanelTop.Controls.Add(this.Office2003Header1);
		this.CustomPanelTop.Controls.Add(this.lblYValue);
		this.CustomPanelTop.Controls.Add(this.lblWvPos);
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
		this.CustomPanelTop.Size = new System.Drawing.Size(198, 438);
		this.CustomPanelTop.TabIndex = 7;
		//
		//lblSlitnm_Ref
		//
		this.lblSlitnm_Ref.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblSlitnm_Ref.Location = new System.Drawing.Point(160, 176);
		this.lblSlitnm_Ref.Name = "lblSlitnm_Ref";
		this.lblSlitnm_Ref.Size = new System.Drawing.Size(22, 18);
		this.lblSlitnm_Ref.TabIndex = 58;
		this.lblSlitnm_Ref.Text = "nm";
		this.lblSlitnm_Ref.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
		this.nudSlit_Ref.Location = new System.Drawing.Point(84, 171);
		this.nudSlit_Ref.MaxValue = 0;
		this.nudSlit_Ref.MinValue = 0;
		this.nudSlit_Ref.Name = "nudSlit_Ref";
		this.nudSlit_Ref.Size = new System.Drawing.Size(72, 22);
		this.nudSlit_Ref.TabIndex = 14;
		this.nudSlit_Ref.UpButtonText = "5";
		this.nudSlit_Ref.Value = 0;
		this.nudSlit_Ref.ValueEditorEnabled = false;
		this.nudSlit_Ref.ValueEditorFont = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.nudSlit_Ref.Visible = false;
		//
		//lblSlitWidth_Ref
		//
		this.lblSlitWidth_Ref.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblSlitWidth_Ref.Location = new System.Drawing.Point(16, 170);
		this.lblSlitWidth_Ref.Name = "lblSlitWidth_Ref";
		this.lblSlitWidth_Ref.Size = new System.Drawing.Size(58, 28);
		this.lblSlitWidth_Ref.TabIndex = 56;
		this.lblSlitWidth_Ref.Text = "Exit Slit Width";
		this.lblSlitWidth_Ref.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//nudPMT_Ref
		//
		this.nudPMT_Ref.BackColor = System.Drawing.SystemColors.Window;
		this.nudPMT_Ref.BackgroundColor = System.Drawing.SystemColors.Window;
		this.nudPMT_Ref.ButtonClicked = ValueEditor.ValueEditor.EnumValueEditorButtons.MainButton;
		this.nudPMT_Ref.ChangeFactor = 0;
		this.nudPMT_Ref.DecimalPlace = 0;
		this.nudPMT_Ref.DnButtonText = "6";
		this.nudPMT_Ref.ForeColor = System.Drawing.SystemColors.ControlText;
		this.nudPMT_Ref.ForegroundColor = System.Drawing.SystemColors.ControlText;
		this.nudPMT_Ref.IsReverseOperation = false;
		this.nudPMT_Ref.IsUpDownButtonToBeDisabledOnValueChange = false;
		this.nudPMT_Ref.Location = new System.Drawing.Point(84, 75);
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
		//lblPMTVolts_Ref
		//
		this.lblPMTVolts_Ref.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblPMTVolts_Ref.Location = new System.Drawing.Point(160, 80);
		this.lblPMTVolts_Ref.Name = "lblPMTVolts_Ref";
		this.lblPMTVolts_Ref.Size = new System.Drawing.Size(32, 18);
		this.lblPMTVolts_Ref.TabIndex = 54;
		this.lblPMTVolts_Ref.Text = "volts";
		this.lblPMTVolts_Ref.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//lblPMT_Ref
		//
		this.lblPMT_Ref.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblPMT_Ref.Location = new System.Drawing.Point(16, 74);
		this.lblPMT_Ref.Name = "lblPMT_Ref";
		this.lblPMT_Ref.Size = new System.Drawing.Size(64, 28);
		this.lblPMT_Ref.TabIndex = 53;
		this.lblPMT_Ref.Text = "Ref. PMT";
		this.lblPMT_Ref.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//lblSlitnm
		//
		this.lblSlitnm.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblSlitnm.Location = new System.Drawing.Point(160, 142);
		this.lblSlitnm.Name = "lblSlitnm";
		this.lblSlitnm.Size = new System.Drawing.Size(22, 18);
		this.lblSlitnm.TabIndex = 52;
		this.lblSlitnm.Text = "nm";
		this.lblSlitnm.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
		this.nudSlit.Location = new System.Drawing.Point(84, 139);
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
		this.nudD2Cur.Location = new System.Drawing.Point(84, 107);
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
		//nudPMT
		//
		this.nudPMT.BackColor = System.Drawing.SystemColors.Window;
		this.nudPMT.BackgroundColor = System.Drawing.SystemColors.Window;
		this.nudPMT.ButtonClicked = ValueEditor.ValueEditor.EnumValueEditorButtons.MainButton;
		this.nudPMT.ChangeFactor = 0;
		this.nudPMT.DecimalPlace = 0;
		this.nudPMT.DnButtonText = "6";
		this.nudPMT.ForeColor = System.Drawing.SystemColors.ControlText;
		this.nudPMT.ForegroundColor = System.Drawing.SystemColors.ControlText;
		this.nudPMT.IsReverseOperation = false;
		this.nudPMT.IsUpDownButtonToBeDisabledOnValueChange = false;
		this.nudPMT.Location = new System.Drawing.Point(84, 43);
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
		//Office2003Header1
		//
		this.Office2003Header1.BackColor = System.Drawing.SystemColors.Control;
		this.Office2003Header1.Dock = System.Windows.Forms.DockStyle.Top;
		this.Office2003Header1.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.Office2003Header1.Location = new System.Drawing.Point(0, 0);
		this.Office2003Header1.Name = "Office2003Header1";
		this.Office2003Header1.Size = new System.Drawing.Size(198, 22);
		this.Office2003Header1.TabIndex = 46;
		this.Office2003Header1.TitleFont = new System.Drawing.Font("Tahoma", 10f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.Office2003Header1.TitleText = "UV settings";
		//
		//lblYValue
		//
		this.lblYValue.BackColor = System.Drawing.Color.White;
		this.lblYValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblYValue.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblYValue.ForeColor = System.Drawing.Color.Blue;
		this.lblYValue.Location = new System.Drawing.Point(9, 402);
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
		this.lblWvPos.Location = new System.Drawing.Point(9, 372);
		this.lblWvPos.Name = "lblWvPos";
		this.lblWvPos.Size = new System.Drawing.Size(166, 20);
		this.lblWvPos.TabIndex = 44;
		this.lblWvPos.Text = "Wavelength (nm) :";
		this.lblWvPos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//lblPMTVolts
		//
		this.lblPMTVolts.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblPMTVolts.Location = new System.Drawing.Point(160, 47);
		this.lblPMTVolts.Name = "lblPMTVolts";
		this.lblPMTVolts.Size = new System.Drawing.Size(32, 18);
		this.lblPMTVolts.TabIndex = 27;
		this.lblPMTVolts.Text = "volts";
		this.lblPMTVolts.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//lblD2CurmA
		//
		this.lblD2CurmA.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblD2CurmA.Location = new System.Drawing.Point(160, 110);
		this.lblD2CurmA.Name = "lblD2CurmA";
		this.lblD2CurmA.Size = new System.Drawing.Size(22, 18);
		this.lblD2CurmA.TabIndex = 26;
		this.lblD2CurmA.Text = "mA";
		this.lblD2CurmA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//cmbModes
		//
		this.cmbModes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cmbModes.Enabled = false;
		this.cmbModes.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.cmbModes.Items.AddRange(new object[] {
			"D2E",
			"HCLE",
			"AA",
			"SELFTEST",
			"MABS",
			"AABGC",
			"EMISSION"
		});
		this.cmbModes.Location = new System.Drawing.Point(84, 236);
		this.cmbModes.Name = "cmbModes";
		this.cmbModes.Size = new System.Drawing.Size(82, 23);
		this.cmbModes.TabIndex = 16;
		this.cmbModes.Visible = false;
		//
		//lblModes
		//
		this.lblModes.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblModes.Location = new System.Drawing.Point(16, 240);
		this.lblModes.Name = "lblModes";
		this.lblModes.Size = new System.Drawing.Size(48, 20);
		this.lblModes.TabIndex = 8;
		this.lblModes.Text = "Modes";
		this.lblModes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//lblSpeed
		//
		this.lblSpeed.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblSpeed.Location = new System.Drawing.Point(16, 208);
		this.lblSpeed.Name = "lblSpeed";
		this.lblSpeed.Size = new System.Drawing.Size(50, 24);
		this.lblSpeed.TabIndex = 7;
		this.lblSpeed.Text = "Speed";
		this.lblSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//cmbSpeed
		//
		this.cmbSpeed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cmbSpeed.Enabled = false;
		this.cmbSpeed.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.cmbSpeed.Items.AddRange(new object[] {
			"FAST",
			"MEDIUM",
			"SLOW"
		});
		this.cmbSpeed.Location = new System.Drawing.Point(84, 203);
		this.cmbSpeed.Name = "cmbSpeed";
		this.cmbSpeed.Size = new System.Drawing.Size(82, 23);
		this.cmbSpeed.TabIndex = 15;
		this.cmbSpeed.Visible = false;
		//
		//lblSlitWidth
		//
		this.lblSlitWidth.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblSlitWidth.Location = new System.Drawing.Point(16, 138);
		this.lblSlitWidth.Name = "lblSlitWidth";
		this.lblSlitWidth.Size = new System.Drawing.Size(58, 28);
		this.lblSlitWidth.TabIndex = 5;
		this.lblSlitWidth.Text = "Entrance Slit Width";
		this.lblSlitWidth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//lblD2Cur
		//
		this.lblD2Cur.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblD2Cur.Location = new System.Drawing.Point(16, 106);
		this.lblD2Cur.Name = "lblD2Cur";
		this.lblD2Cur.Size = new System.Drawing.Size(44, 28);
		this.lblD2Cur.TabIndex = 2;
		this.lblD2Cur.Text = "D2 Cur";
		this.lblD2Cur.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//lblPMT
		//
		this.lblPMT.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblPMT.Location = new System.Drawing.Point(16, 41);
		this.lblPMT.Name = "lblPMT";
		this.lblPMT.Size = new System.Drawing.Size(56, 28);
		this.lblPMT.TabIndex = 1;
		this.lblPMT.Text = "Sample PMT";
		this.lblPMT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//CustomPanelBack
		//
		this.CustomPanelBack.BackColor = System.Drawing.Color.AliceBlue;
		this.CustomPanelBack.Controls.Add(this.CustomPanelMain);
		this.CustomPanelBack.Controls.Add(this.CustomPanelTop);
		this.CustomPanelBack.Dock = System.Windows.Forms.DockStyle.Fill;
		this.CustomPanelBack.Location = new System.Drawing.Point(0, 57);
		this.CustomPanelBack.Name = "CustomPanelBack";
		this.CustomPanelBack.Size = new System.Drawing.Size(806, 438);
		this.CustomPanelBack.TabIndex = 8;
		//
		//ToolBar1
		//
		this.ToolBar1.BackColor = System.Drawing.Color.Transparent;
		this.ToolBar1.Controls.Add(this.ToolBar);
		this.ToolBar1.CustomizeText = "&Customize Toolbar...";
		this.ToolBar1.Dock = System.Windows.Forms.DockStyle.Top;
		this.ToolBar1.ID = 7406;
		this.ToolBar1.Items.AddRange(new NETXP.Controls.Bars.CommandBarItem[] { this.CommandBarButtonItem1 });
		this.ToolBar1.Location = new System.Drawing.Point(0, 23);
		this.ToolBar1.Margins.Bottom = 1;
		this.ToolBar1.Margins.Left = 1;
		this.ToolBar1.Margins.Right = 1;
		this.ToolBar1.Margins.Top = 1;
		this.ToolBar1.MenuEnabled = false;
		this.ToolBar1.Name = "ToolBar1";
		this.ToolBar1.Size = new System.Drawing.Size(806, 34);
		this.ToolBar1.TabIndex = 9;
		this.ToolBar1.TabStop = false;
		this.ToolBar1.Text = "";
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
			this.tlbbtnBaseLine,
			this.tlbbtnClearSpectrum,
			this.tlbbtnChangeScale,
			this.CommandBarSeparatorItem5,
			this.tlbbtnSmooth,
			this.tlbbtnPeakPick,
			this.tlbbtnAbsToTransmission
		});
		this.ToolBar.Location = new System.Drawing.Point(0, 0);
		this.ToolBar.Margins.Bottom = 1;
		this.ToolBar.Margins.Left = 1;
		this.ToolBar.Margins.Right = 1;
		this.ToolBar.Margins.Top = 1;
		this.ToolBar.MenuEnabled = false;
		this.ToolBar.Name = "ToolBar";
		this.ToolBar.Size = new System.Drawing.Size(806, 34);
		this.ToolBar.TabIndex = 0;
		this.ToolBar.TabStop = false;
		this.ToolBar.Text = "Command Bar";
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
		//tlbbtnBaseLine
		//
		this.tlbbtnBaseLine.Image = (System.Drawing.Image)resources.GetObject("tlbbtnBaseLine.Image");
		this.tlbbtnBaseLine.Shortcut = System.Windows.Forms.Shortcut.CtrlB;
		this.tlbbtnBaseLine.Text = "BASE LINE[CTRL+B]";
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
		//tlbbtnAbsToTransmission
		//
		this.tlbbtnAbsToTransmission.Image = (System.Drawing.Image)resources.GetObject("tlbbtnAbsToTransmission.Image");
		this.tlbbtnAbsToTransmission.Shortcut = System.Windows.Forms.Shortcut.CtrlA;
		this.tlbbtnAbsToTransmission.Text = "ABS->%TRANSMISSION[CTRL+A]";
		//
		//CommandBarButtonItem1
		//
		this.CommandBarButtonItem1.Image = (System.Drawing.Image)resources.GetObject("CommandBarButtonItem1.Image");
		this.CommandBarButtonItem1.Text = null;
		//
		//tlbbtnPrintGraph
		//
		this.tlbbtnPrintGraph.Image = (System.Drawing.Image)resources.GetObject("tlbbtnPrintGraph.Image");
		this.tlbbtnPrintGraph.Shortcut = System.Windows.Forms.Shortcut.CtrlG;
		this.tlbbtnPrintGraph.Text = "PPRINT GRAPH[CTRL+G]";
		//
		//CommandBarButtonItem2
		//
		this.CommandBarButtonItem2.Image = (System.Drawing.Image)resources.GetObject("CommandBarButtonItem2.Image");
		this.CommandBarButtonItem2.Shortcut = System.Windows.Forms.Shortcut.CtrlG;
		this.CommandBarButtonItem2.Text = "PPRINT GRAPH[CTRL+G]";
		//
		//frmUVScanningSpectrumDBMode
		//
		this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
		this.ClientSize = new System.Drawing.Size(806, 519);
		this.Controls.Add(this.CustomPanelBack);
		this.Controls.Add(this.ToolBar1);
		this.Controls.Add(this.StatusBar1);
		this.Controls.Add(this.MenuBarUV);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		this.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		this.MinimizeBox = false;
		this.Name = "frmUVScanningSpectrumDBMode";
		this.ShowInTaskbar = false;
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "UV Scanning Spectrum Mode ";
		this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
		this.CustomPanelMain.ResumeLayout(false);
		this.CustomPanelBottom.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.MenuBarUV).EndInit();
		((System.ComponentModel.ISupportInitialize)this.StatusBarPanelInfo).EndInit();
		((System.ComponentModel.ISupportInitialize)this.ProgressPanel).EndInit();
		((System.ComponentModel.ISupportInitialize)this.StatusBarPanelDate).EndInit();
		this.CustomPanelTop.ResumeLayout(false);
		this.CustomPanelBack.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.ToolBar1).EndInit();
		this.ToolBar1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.ToolBar).EndInit();
		this.ResumeLayout(false);

	}

	#End Region

	#Region " Form Events "

	private void  // ERROR: Handles clauses are not supported in C#
frmUVScanningSpectrumMode_Load(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : frmUVScanningSpectrumMode_Load
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To initialize the form
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 07.10.06
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		try {
			btnReturn.Enabled = false;
			cmdChangeScale.BringToFront();
			btnStart.BringToFront();

			MenuBarUV.BackColor = System.Drawing.Color.Gainsboro;
			if (mblnAvoidProcessing == true) {
				return;
			}
			mblnAvoidProcessing = true;
			ShowProgressBar(gstrTitleInstrumentType + ConstFormLoad);
			Application.DoEvents();
			gblnUVS = true;
			strfrmStatusTurretNo = gobjfrmStatus.lblTurretNo.Text;
			strfrmStatusEle = gobjfrmStatus.lblElementName.Text;
			gobjfrmStatus.lblTurretNo.Text = "";
			gobjfrmStatus.lblElementName.Text = "";
			gobjfrmStatus.lblElementName.Refresh();
			gobjfrmStatus.lblElementName.Refresh();


			funcInitialise();

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
			btnReturn.Enabled = true;
			mblnAvoidProcessing = false;
			if (!objWait == null) {
				objWait.Dispose();
			}
			HideProgressBar();
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	private void  // ERROR: Handles clauses are not supported in C#
frmUVScanningSpectrumMode_Closing(object sender, System.ComponentModel.CancelEventArgs e)
	{
		//=====================================================================
		// Procedure Name        : frmUVScanningSpectrumMode_Load
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To Closing the form
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 14.02.07
		// Revisions             : 
		//=====================================================================
		try {
			if (mblnAvoidProcessing == true) {
				e.Cancel = true;
				return;
			}
			gobjCommProtocol.funcAir_ON();
			gobjMessageAdapter.ShowMessage(constCuvetteBurner);
			Application.DoEvents();
			////---- Added by Sachin Dokhale Set the previous default Calibration mode
			gobjCommProtocol.funcCalibrationMode(m_bytCalibMode);
			//strfrmStatusTurretNo = gobjfrmStatus.lblTurretNo.Text
			//strfrmStatusEle = gobjfrmStatus.lblElementName.Text

			//*************************************
			//---Changed By Mangesh on 24-Apr-2007
			//gobjfrmStatus.lblTurretNo.Text = strfrmStatusTurretNo
			//gobjfrmStatus.lblElementName.Text = strfrmStatusEle
			//gobjfrmStatus.lblElementName.Refresh()
			//gobjfrmStatus.lblElementName.Refresh()
			if (!(strfrmStatusTurretNo == "")) {
				gobjfrmStatus.TurretNumber = (int)strfrmStatusTurretNo;
			}
			gobjfrmStatus.ElementName = strfrmStatusEle;
			//*************************************
			gobjfrmStatus.ElementName = strfrmStatusEle;
			//*************************************
			//If Not (gstructSettings.AppMode = EnumAppMode.DemoMode) Then
			//    If Not IsNothing(gobjMain) Then
			//        gobjMain.mobjController.Start(gobjclsBgFlameStatus)
			//    End If
			//    gobjfrmStatus.Visible = True
			//End If
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

			if (!gobjclsTimer == null) {
				gobjclsTimer.subTimerStop();
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
			mblnAvoidProcessing = false;
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	private void mnuExit_Click(object sender, System.EventArgs e)
	{
		try {
			if (mblnAvoidProcessing == true) {
				return;
			}
			gobjclsTimer.subTimerStop();
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
			mblnAvoidProcessing = false;
			//---------------------------------------------------------
		}
	}

	private void mnuPeakPick_Click(object sender, System.EventArgs e)
	{
		subPeakValley();

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
			//by pankaj on 2 Dec 07
			if (mblnParameterProcessing == true) {
				return;
			}

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
			btnStart.Focus();
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	private void btnBaseLine_Click(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : btnBaseLine_Click
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
			//by pankaj on 2 Dec 07
			if (mblnParameterProcessing == true) {
				return;
			}
			gblnBaseLine = false;
			if (mblnSpectrumStarted == false) {
				subStartBaseline();
			} else {
				subStopScan();
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
			btnBaseLine.Focus();
			Application.DoEvents();
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
			this.AASGraphUVSpectrum.disablePeakEdit();
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

	//Private Sub nudPMT_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
	//    nudPMT.Enabled = False
	//    mblnAvoidProcessing = True
	//    RemoveHandler nudPMT.ValueChanged, AddressOf nudPMT_ValueChanged
	//    Application.DoEvents()
	//    Call funcSetPmtVParameter(nudPMT.Value)
	//    AddHandler nudPMT.ValueChanged, AddressOf nudPMT_ValueChanged
	//    mblnAvoidProcessing = False
	//    nudPMT.Enabled = True
	//    Application.DoEvents()
	//End Sub

	private void nudPMT_ValueChanged(double ChangePmt)
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
			//nudPMT.Enabled = False
			//If mblnAvoidProcessing = True Then
			//    Exit Sub
			//End If
			//mblnAvoidProcessing = True
			mblnParameterProcessing = true;
			//by pankaj on 2 Dec 07
			nudPMT.ValueEditorValueChanged -= nudPMT_ValueChanged;
			Application.DoEvents();
			funcSetPmtVParameter(nudPMT.Value);

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			nudPMT.ValueEditorValueChanged += nudPMT_ValueChanged;
			//mblnAvoidProcessing = False
			//nudPMT.Enabled = True
			if (!objWait == null) {
				objWait.Dispose();
			}
			Application.DoEvents();
			mblnParameterProcessing = false;
			//by pankaj on 2 Dec 07
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
		try {
			//nudPMT.Enabled = False
			//If mblnAvoidProcessing = True Then
			//    Exit Sub
			//End If
			//mblnAvoidProcessing = True

			nudPMT.ValueEditorClick -= nudPMT_ValueEditorClick;
			Application.DoEvents();
			mblnParameterProcessing = true;
			//by pankaj on 2 Dec 07
			double dblReturnValue;
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
			//mblnAvoidProcessing = False
			nudPMT.ValueEditorClick += nudPMT_ValueEditorClick;
			//nudPMT.Enabled = True
			if (!objWait == null) {
				objWait.Dispose();
			}
			nudPMT.Focus();
			Application.DoEvents();
			mblnParameterProcessing = false;
			//by pankaj on 2 Dec 07
		}
	}

	private void nudPMT_Ref_ValueChanged(double ChangePmt)
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
			//nudPMT_Ref.Enabled = False
			//If mblnAvoidProcessing = True Then
			//    Exit Sub
			//End If
			//mblnAvoidProcessing = True

			nudPMT_Ref.ValueEditorValueChanged -= nudPMT_Ref_ValueChanged;
			Application.DoEvents();
			mblnParameterProcessing = true;
			//by pankaj on 2 Dec 07
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
			nudPMT_Ref.ValueEditorValueChanged += nudPMT_Ref_ValueChanged;
			//mblnAvoidProcessing = False
			//nudPMT.Enabled = True
			if (!objWait == null) {
				objWait.Dispose();
			}
			Application.DoEvents();
			mblnParameterProcessing = false;
			//by pankaj on 2 Dec 07
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
			//'nudPMT_Ref.Enabled = False
			//If mblnAvoidProcessing = True Then
			//    Exit Sub
			//End If
			//mblnAvoidProcessing = True
			nudPMT_Ref.ValueEditorClick -= nudPMT_Ref_ValueEditorClick;
			Application.DoEvents();
			mblnParameterProcessing = true;
			//by pankaj on 2 Dec 07
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
			//nudPMT.Enabled = True
			if (!objWait == null) {
				objWait.Dispose();
			}
			nudPMT_Ref.Focus();
			Application.DoEvents();
			mblnParameterProcessing = false;
			//by pankaj on 2 Dec 07
		}
	}

	//Private Sub nudSlit_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
	//    nudSlit.Enabled = False
	//    mblnAvoidProcessing = True
	//    RemoveHandler nudSlit.ValueChanged, AddressOf nudSlit_ValueChanged
	//    Application.DoEvents()
	//    Call funcSetSlit_WidthParameter(nudSlit.Value)
	//    AddHandler nudSlit.ValueChanged, AddressOf nudSlit_ValueChanged
	//    mblnAvoidProcessing = False
	//    nudSlit.Enabled = True
	//    Application.DoEvents()
	//End Sub

	private void nudSlit_ValueChanged(double ChangeSlit)
	{
		CWaitCursor objWait = new CWaitCursor();
		try {
			//nudSlit.Enabled = False
			//If mblnAvoidProcessing = True Then
			//    Exit Sub
			//End If
			//mblnAvoidProcessing = True
			mblnParameterProcessing = true;
			//by pankaj on 2 Dec 07
			nudSlit.ValueEditorValueChanged -= nudSlit_ValueChanged;
			//RemoveHandler btnStart.Click, AddressOf btnStart_Click
			//RemoveHandler btnBaseLine.Click, AddressOf btnBaseLine_Click
			Application.DoEvents();
			funcSetSlit_WidthParameter(nudSlit.Value);
			//'by pankaj on 18.1.08
			nudSlit.Value = (double)gobjClsAAS203.funcGet_SlitWidth;
			//CDbl(nudSlit.Value)  'by pankaj on 18.1.08
		//'-----
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
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
			nudSlit.ValueEditorValueChanged += nudSlit_ValueChanged;
			//AddHandler btnStart.Click, AddressOf btnStart_Click
			//AddHandler btnBaseLine.Click, AddressOf btnBaseLine_Click
			//mblnAvoidProcessing = False
			//nudSlit.Enabled = True
			objWait.Dispose();
			Application.DoEvents();
			mblnParameterProcessing = false;
			//by pankaj on 2 Dec 07
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
			mblnParameterProcessing = true;
			//by pankaj on 2 Dec 07
			nudSlit.ValueEditorClick -= nudSlit_ValueEditorClick;
			//RemoveHandler btnStart.Click, AddressOf btnStart_Click
			//RemoveHandler btnBaseLine.Click, AddressOf btnBaseLine_Click
			Application.DoEvents();

			dblReturnValue = gobjClsAAS203.funcGet_SlitWidth;
			if (funcSetFrmEditValue(dblReturnValue, "Set Entrance Slit Width (0.0 - 2.0)nm", nudSlit.MinValue, nudSlit.MaxValue) == true) {
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
			nudSlit.ValueEditorClick += nudSlit_ValueEditorClick;
			//AddHandler btnStart.Click, AddressOf btnStart_Click
			//AddHandler btnBaseLine.Click, AddressOf btnBaseLine_Click
			//nudSlit.Enabled = True
			//mblnAvoidProcessing = False
			if (!objWait == null) {
				objWait.Dispose();
			}
			nudSlit.Focus();
			Application.DoEvents();
			mblnParameterProcessing = false;
			//by pankaj on 2 Dec 07
		}
	}

	private void nudSlit_Ref_ValueChanged(double ChangeSlit)
	{
		CWaitCursor objWait = new CWaitCursor();
		try {
			//nudSlit_Ref.Enabled = False
			//If mblnAvoidProcessing = True Then
			//    Exit Sub
			//End If
			//mblnAvoidProcessing = True
			nudSlit_Ref.ValueEditorValueChanged -= nudSlit_Ref_ValueChanged;
			//RemoveHandler btnStart.Click, AddressOf btnStart_Click
			//RemoveHandler btnBaseLine.Click, AddressOf btnBaseLine_Click
			Application.DoEvents();
			mblnParameterProcessing = true;
			//by pankaj on 2 Dec 07
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
			nudSlit_Ref.ValueEditorValueChanged += nudSlit_Ref_ValueChanged;
			//AddHandler btnStart.Click, AddressOf btnStart_Click
			//AddHandler btnBaseLine.Click, AddressOf btnBaseLine_Click
			//mblnAvoidProcessing = False
			//nudSlit.Enabled = True
			objWait.Dispose();
			Application.DoEvents();
			mblnParameterProcessing = false;
			//by pankaj on 2 Dec 07
		}

	}

	private void nudSlit_Ref_ValueEditorClick()
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
			mblnParameterProcessing = true;
			//by pankaj on 2 Dec 07
			nudSlit_Ref.ValueEditorClick -= nudSlit_Ref_ValueEditorClick;
			//RemoveHandler btnStart.Click, AddressOf btnStart_Click
			//RemoveHandler btnBaseLine.Click, AddressOf btnBaseLine_Click
			Application.DoEvents();

			dblReturnValue = gobjClsAAS203.funcGet_SlitWidth(1);
			if (funcSetFrmEditValue(dblReturnValue, "Set Exit Slit Width (0.0 - 2.0)nm", nudSlit.MinValue, nudSlit.MaxValue) == true) {
				nudSlit_Ref.Value = dblReturnValue;
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
			nudSlit_Ref.ValueEditorClick += nudSlit_Ref_ValueEditorClick;
			//AddHandler btnStart.Click, AddressOf btnStart_Click
			//AddHandler btnBaseLine.Click, AddressOf btnBaseLine_Click
			//nudSlit.Enabled = True
			//mblnAvoidProcessing = False
			if (!objWait == null) {
				objWait.Dispose();
			}
			nudSlit_Ref.Focus();
			Application.DoEvents();
			mblnParameterProcessing = false;
			//by pankaj on 2 Dec 07
		}
	}

	private void nudD2Cur_ValueChanged(double ChangeD2Cur)
	{
		CWaitCursor objWait = new CWaitCursor();
		try {
			//nudD2Cur.Enabled = False
			//If mblnAvoidProcessing = True Then
			//    Exit Sub
			//End If
			//mblnAvoidProcessing = True
			mblnParameterProcessing = true;
			//by pankaj on 2 Dec 07
			nudD2Cur.ValueEditorValueChanged -= nudD2Cur_ValueChanged;
			Application.DoEvents();
			if (ReInitLampInstParameters == true) {
				return;
			}
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
			//---------------------------------------------------------
			nudD2Cur.ValueEditorValueChanged += nudD2Cur_ValueChanged;
			//mblnAvoidProcessing = False
			//nudD2Cur.Enabled = True
			objWait.Dispose();
			Application.DoEvents();
			mblnParameterProcessing = false;
			//by pankaj on 2 Dec 07
		}

	}

	private void nudD2Cur_ValueEditorClick()
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
			mblnParameterProcessing = true;
			//by pankaj on 2 Dec 07
			dblReturnValue = gobjInst.D2Current;
			//If funcSetFrmEditValue(dblReturnValue, "Set D2 Current (100 - 300)mA", nudD2Cur.MinValue, nudD2Cur.MaxValue) = True Then
			//    nudD2Cur.Value = dblReturnValue
			//End If
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
			//by pankaj on 2 Dec 07
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
		CWaitCursor objWait = new CWaitCursor();
		SaveFileDialog SaveFileDialog1 = new SaveFileDialog();
		try {
			if (mblnAvoidProcessing == true) {
				return;
			}
			mblnAvoidProcessing = true;
			//SaveFileDialog1.Filter = "Energy Spectrum File(*.spt)|*.spt"
			//SaveFileDialog1.Title = "Show an Energy Spectrum File"
			//SaveFileDialog1.ShowDialog()
			funcSaveSpectrumFile();
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
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
		try {
			if (mblnAvoidProcessing == true) {
				return;
			}
			mblnAvoidProcessing = true;

			//OpenFileDialog1.Filter = "Energy Spectrum File(*.spt)|*.spt"
			//OpenFileDialog1.Title = "Show an Energy Spectrum File"
			//OpenFileDialog1.ShowDialog()
			funcLoadSpectrumFile();
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
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

		try {

			if (mblnAvoidProcessing == true) {
				return;
			}
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
		try {
			if (mblnAvoidProcessing == true) {
				return;
			}

			mblnAvoidProcessing = true;

			cmbSpeed.SelectedIndexChanged -= cmbSpeed_SelectedIndexChanged;

			if (funcSetSpeed(cmbSpeed.SelectedIndex) == true) {
				gblnBaseLine = false;
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
			if (mblnAvoidProcessing == true) {
				return;
			}
			mblnAvoidProcessing = true;
			cmbModes.Enabled = false;
			if (cmbModes.SelectedIndex > -1) {
				//gobjInst.Mode = cmbModes.SelectedIndex
				funcSetSpectrumParameter(cmbModes.SelectedIndex);
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
			cmbModes.Enabled = true;
			mblnAvoidProcessing = false;
			if (!objWait == null) {
				objWait.Dispose();
			}
			Application.DoEvents();
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
		// Description           : select Coordinate of graph
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 21.11.06
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		frmChangeScale objfrmChangeScale;
		try {
			if (mblnAvoidProcessing == true) {
				return;
			}
			mblnAvoidProcessing = true;
			objfrmChangeScale = new frmChangeScale(mobjParameters, true);
			objfrmChangeScale.funcSetValidatingScale(gobjInst.Mode);
			if (objfrmChangeScale.ShowDialog() == DialogResult.OK) {
				if (!objfrmChangeScale.SpectrumParameter == null) {
					if (mobjParameters.XaxisMax < objfrmChangeScale.SpectrumParameter.XaxisMax) {
						gblnBaseLine = false;
					}

					if (mobjParameters.XaxisMin > objfrmChangeScale.SpectrumParameter.XaxisMin) {
						gblnBaseLine = false;
					}

					mobjParameters.XaxisMax = objfrmChangeScale.SpectrumParameter.XaxisMax;
					mobjParameters.XaxisMin = objfrmChangeScale.SpectrumParameter.XaxisMin;
					mobjParameters.YaxisMax = objfrmChangeScale.SpectrumParameter.YaxisMax;
					mobjParameters.YaxisMin = objfrmChangeScale.SpectrumParameter.YaxisMin;

					if (!funcGraphPreRequisite(mobjParameters.Cal_Mode, mobjParameters.XaxisMin, mobjParameters.XaxisMax, mobjParameters.YaxisMin, mobjParameters.YaxisMax)) {
						//Call gFuncShowMessage("Error in setting spectrum parameters", "Please Check Entered Spectrum Parameters", modConstants.EnumMessageType.Information)
						return;
					}
					lblWvPos.Text = mXValueLable + gobjInst.WavelengthCur;
				}
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
			if (!objfrmChangeScale == null) {
				objfrmChangeScale.Dispose();
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
		CWaitCursor objWait = new CWaitCursor();
		int intIsSetMaximisePosition;
		double dblMaximisePosition;
		static bool CheckMaxPosition = false;

		try {
			if (mblnAvoidProcessing == true) {
				return;
			}
			mblnAvoidProcessing = true;

			if (mintChannelIndex > -1) {
				if (!(AASGraphUVSpectrum.OfflineCurve == null)) {
					if ((CheckMaxPosition == false) & (intCurveIndex > -1)) {
						intIsSetMaximisePosition = gobjMessageAdapter.ShowMessage(constSetMaximisePosition);
						Application.DoEvents();
						if (intIsSetMaximisePosition == MsgBoxResult.Yes) {
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
							//mnuPositionToMaxima.CheckType = NETXP.Controls.Bars.ButtonItemCheckType.Checkmark
							//mnuPositionToMaxima.Checked = True

							AASGraphUVSpectrum.DrawHighestPeakLine(ArrlstGraphCurveItem(intCurveIndex));
							//AASEnergySpectrum.AldysPane.CurveList(0 ).Label 
							dblMaximisePosition = ArrlstGraphCurveItem(intCurveIndex).HighPeakXValue();
							//dblMaximisePosition = AASEnergySpectrum.AldysPane.CurveList(0).HighPeakXValue
							if (gobjCommProtocol.Wavelength_Position(dblMaximisePosition, lblWvPos) == true) {
								gobjCommProtocol.mobjCommdll.subTime_Delay(100);
							}
							lblWvPos.Text = mXValueLable + gobjInst.WavelengthCur;
							lblWvPos.Refresh();
							//End If
							//AASEnergySpectrum.DrawHighestPeakLine(ArrlstGraphCurveItem(intCurveIndex))
							AASGraphUVSpectrum.ShowHighPeakLineLabel("Maximise Position", false, 0);

						}

					} else {
						//mnuPositionToMaxima.Checked = False
						AASGraphUVSpectrum.RemoveHighPeakLineLabel();
						int i;
						int CourveCount;
						//If AASEnergySpectrum.AldysPane.CurveList.Count > 0 Then
						for (i = 0; i <= AASGraphUVSpectrum.AldysPane.CurveList.Count - 1; i++) {
							//If AASEnergySpectrum.AldysPane.CurveList.Count > 0 Then
							if (AASGraphUVSpectrum.AldysPane.CurveList(i).IsHighPeakLine() == true) {
								AASGraphUVSpectrum.AldysPane.CurveList.RemoveAt(i);
							}
							//End If
						}
						//End If
						//AASEnergySpectrum.AldysPane.CurveList(0).IsHighPeakLine = False
						AASGraphUVSpectrum.Refresh();
						//CheckMaxPosition = False
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
			mblnAvoidProcessing = false;
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
		CWaitCursor objWait = new CWaitCursor();
		frmParameter objfrmParameter;
		try {
			if (mblnAvoidProcessing == true) {
				return;
			}
			mblnAvoidProcessing = true;

			objfrmParameter = new frmParameter(mobjParameters);
			if (objfrmParameter.ShowDialog() == DialogResult.OK) {
				if (!objfrmParameter.SpectrumParameter == null) {
					if (mobjParameters == null) {
						mobjParameters = new Spectrum.UVSpectrumParameter();
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

	//Private Sub mnuD2Peak_Click(ByVal sender As Object, ByVal e As System.EventArgs)
	//    '=====================================================================
	//    ' Procedure Name        : mnuD2Peak_Click
	//    ' Parameters Passed     : Object,EventArgs
	//    ' Returns               : None
	//    ' Purpose               : 
	//    ' Description           : Set Maxisise position
	//    ' Assumptions           : 
	//    ' Dependencies          : 
	//    ' Author                : Sachin Dokhale
	//    ' Created               : 05.01.07
	//    ' Revisions             : 
	//    '=====================================================================
	//    Dim objWait As New CWaitCursor
	//    Dim objfrmD2PeakSearch As frmD2PeakSearch
	//    Try
	//        If mblnAvoidProcessing = True Then
	//            Exit Sub
	//        End If
	//        mblnAvoidProcessing = True
	//        objfrmD2PeakSearch = New frmD2PeakSearch
	//        If objfrmD2PeakSearch.ShowDialog = DialogResult.OK Then

	//        End If
	//        objfrmD2PeakSearch.Close()
	//        Call funcGetInstParameter()

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
	//        objfrmD2PeakSearch.Dispose()
	//        If Not objWait Is Nothing Then
	//            objWait.Dispose()
	//        End If
	//        mblnAvoidProcessing = False
	//        Application.DoEvents()
	//        '---------------------------------------------------------

	//    End Try
	//End Sub

	private void AASGraphUVSpectrum_GraphScaleChanged(double XMin, double XMax, double YMin, double YMax)
	{
		//=====================================================================
		// Procedure Name        :   AASGraphUVSpectrum_GraphScaleChanged
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
	//    Dim objWait As New CWaitCursor
	//    Try
	//        RemoveHandler mnuIgnite.Click, AddressOf btnAutoIgnition_Click
	//        If mblnAvoidProcessing = True Then
	//            Exit Sub
	//        End If
	//        mblnAvoidProcessing = True
	//        Call gobjClsAAS203.funcIgnite(True)
	//        mblnAvoidProcessing = False
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
	//        AddHandler mnuIgnite.Click, AddressOf btnAutoIgnition_Click
	//        objWait.Dispose()
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
	//    Dim objWait As New CWaitCursor
	//    Try
	//        RemoveHandler mnuExtinguish.Click, AddressOf btnExtinguish_Click
	//        If mblnAvoidProcessing = True Then
	//            Exit Sub
	//        End If
	//        mblnAvoidProcessing = True
	//        Call gobjClsAAS203.funcIgnite(False)
	//        mblnAvoidProcessing = False
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
	//        AddHandler mnuExtinguish.Click, AddressOf btnExtinguish_Click
	//        objWait.Dispose()
	//        Application.DoEvents()
	//        '---------------------------------------------------------
	//    End Try
	//End Sub

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
				gfuncInsertActivityLog(EnumModules.Print, "Print UVScanning Spectrum Mode Graph Accessed");
			}
			//If (toreported) Then 'OR NOT Method->RepReady )
			//gobjClsAAS203.SaveQuantResults(gobjNewMethod, A1, False)
			//toreported = False
			//AASGraphUVSpectrum.PrintPreViewGraph()
			objclsDataFileReport.DefaultFont = this.DefaultFont();
			objclsDataFileReport.funcPrintUV(AASGraphUVSpectrum, mobjParameters, "");
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
	#End Region

	#Region " Code for Enable and Disable"

	private object func_Enable_Disable(int intProcess, int intStart_End)
	{

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

							btnIgnite.Visible = true;
							btnExtinguish.Visible = true;

							btnBaseLine.Enabled = true;
							mnuBaseLine.Enabled = true;
							tlbbtnBaseLine.Enabled = true;

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
							nudSlit_Ref.Enabled = true;
							cmbSpeed.Enabled = true;

							cmdChangeScale.Enabled = true;
							tlbbtnChangeScale.Enabled = true;
							mnuChangeScale.Enabled = true;

							if (mintChannelIndex > -1) {
								mnuSaveSpectrumFile.Enabled = true;
								tlbbtnSaveSpectrumFile.Enabled = true;

								mnuPeakPick.Enabled = true;
								tlbbtnPeakPick.Enabled = true;

								mnuSmooth.Enabled = true;
								tlbbtnSmooth.Enabled = true;

								mnuAbsTransmission.Enabled = true;
								tlbbtnAbsToTransmission.Enabled = true;
							} else {
								//mnuParameters.Enabled = False       'Saurabh      
								//tlbbtnParameters.Enabled = False

								mnuSaveSpectrumFile.Enabled = false;
								tlbbtnSaveSpectrumFile.Enabled = false;

								mnuPeakPick.Enabled = false;
								tlbbtnPeakPick.Enabled = false;

								mnuSmooth.Enabled = false;
								tlbbtnSmooth.Enabled = false;

								mnuAbsTransmission.Enabled = false;
								tlbbtnAbsToTransmission.Enabled = false;

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
							btnBaseLine.Enabled = false;
							mnuBaseLine.Enabled = false;
							tlbbtnBaseLine.Enabled = false;

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

							btnStart.Enabled = false;
							mnuStart.Enabled = false;
							tlbbtnStart.Enabled = false;

							//nudD2Cur.Enabled = False
							//nudPMT.Enabled = False
							//nudPMT_Ref.Enabled = False
							//nudSlit.Enabled = False
							//nudSlit_Ref.Enabled = False
							cmbSpeed.Enabled = false;

							cmdChangeScale.Enabled = false;
							mnuChangeScale.Enabled = false;
							tlbbtnChangeScale.Enabled = false;

							mnuAbsTransmission.Enabled = false;
							tlbbtnAbsToTransmission.Enabled = false;

							mnuLoadSpectrumFile.Enabled = false;
							tlbbtnLoadspectrumFile.Enabled = false;

							mnuParameters.Enabled = false;
							tlbbtnParameters.Enabled = false;

							mnuPeakPick.Enabled = false;
							tlbbtnPeakPick.Enabled = false;

							mnuSaveSpectrumFile.Enabled = false;
							tlbbtnSaveSpectrumFile.Enabled = false;

							mnuSmooth.Enabled = false;

							tlbbtnSmooth.Enabled = false;
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
								btnBaseLine.Enabled = true;
								tlbbtnBaseLine.Enabled = true;
								mnuBaseLine.Enabled = true;

								btnClearSpectrum.Enabled = true;
								mnuClearSpectrum.Enabled = true;
								tlbbtnClearSpectrum.Enabled = true;

								btnReturn.Enabled = true;
								mnuExit.Enabled = true;
								tlbbtnReturn.Enabled = true;

								//btnStart.Text = "&Stop"
								mnuStart.Enabled = true;
								tlbbtnStart.Enabled = true;
								btnStart.Enabled = true;

								nudD2Cur.Enabled = true;
								nudPMT.Enabled = true;
								//nudPMT_Ref.Enabled = True
								if (!(gintInstrumentBeamType == AAS203Library.Instrument.enumInstrumentBeamType.SingleBeam)) {
									nudPMT_Ref.Enabled = true;
								} else {
									nudPMT_Ref.Enabled = false;
								}
								nudSlit.Enabled = true;
								nudSlit_Ref.Enabled = true;
								cmbSpeed.Enabled = true;

								cmdChangeScale.Enabled = true;
								tlbbtnChangeScale.Enabled = true;
								mnuChangeScale.Enabled = true;

								mnuLoadSpectrumFile.Enabled = true;
								tlbbtnLoadspectrumFile.Enabled = true;

								if (mintChannelIndex > -1) {
									mnuParameters.Enabled = true;
									tlbbtnParameters.Enabled = true;

									mnuSaveSpectrumFile.Enabled = true;
									tlbbtnSaveSpectrumFile.Enabled = true;

									mnuPeakPick.Enabled = true;
									tlbbtnPeakPick.Enabled = true;

									mnuAbsTransmission.Enabled = true;
									tlbbtnAbsToTransmission.Enabled = true;

									mnuSmooth.Enabled = true;

									tlbbtnSmooth.Enabled = true;
								} else {
									mnuParameters.Enabled = false;
									tlbbtnParameters.Enabled = false;

									mnuSaveSpectrumFile.Enabled = false;
									tlbbtnSaveSpectrumFile.Enabled = false;

									mnuPeakPick.Enabled = false;
									tlbbtnPeakPick.Enabled = false;

									mnuAbsTransmission.Enabled = false;
									tlbbtnAbsToTransmission.Enabled = false;

									mnuSmooth.Enabled = false;
									tlbbtnSmooth.Enabled = false;
								}

							}
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

								mnuAbsTransmission.Enabled = true;
								tlbbtnAbsToTransmission.Enabled = true;

								mnuSmooth.Enabled = true;
								tlbbtnSmooth.Enabled = true;
							} else {
								mnuParameters.Enabled = false;
								tlbbtnParameters.Enabled = false;

								mnuSaveSpectrumFile.Enabled = false;
								tlbbtnSaveSpectrumFile.Enabled = false;

								mnuPeakPick.Enabled = false;
								tlbbtnPeakPick.Enabled = false;

								mnuAbsTransmission.Enabled = false;
								tlbbtnAbsToTransmission.Enabled = false;

								mnuSmooth.Enabled = false;
								tlbbtnSmooth.Enabled = false;
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

			//    'AddHandler nudD2Cur.ValueChanged, AddressOf nudD2Cur_ValueChanged
			//    RemoveHandler nudD2Cur.ValueEditorClick, AddressOf nudD2Cur_ValueEditorClick
			//    RemoveHandler nudD2Cur.ValueEditorValueChanged, AddressOf nudD2Cur_ValueChanged

			//    'AddHandler nudSlit.ValueChanged, AddressOf nudSlit_ValueChanged
			//    RemoveHandler nudSlit.ValueEditorClick, AddressOf nudSlit_ValueEditorClick
			//    RemoveHandler nudSlit.ValueEditorValueChanged, AddressOf nudSlit_ValueChanged
			//    RemoveHandler nudSlit_Ref.ValueEditorClick, AddressOf nudSlit_Ref_ValueEditorClick
			//    RemoveHandler nudSlit_Ref.ValueEditorValueChanged, AddressOf nudSlit_Ref_ValueChanged

			//    'AddHandler nudPMT.ValueChanged, AddressOf nudPMT_ValueChanged
			//    RemoveHandler nudPMT.ValueEditorClick, AddressOf nudPMT_ValueEditorClick
			//    RemoveHandler nudPMT.ValueEditorValueChanged, AddressOf nudPMT_ValueChanged
			//    RemoveHandler nudPMT_Ref.ValueEditorClick, AddressOf nudPMT_Ref_ValueEditorClick
			//    RemoveHandler nudPMT_Ref.ValueEditorValueChanged, AddressOf nudPMT_Ref_ValueChanged
			//Else


			//    'AddHandler nudD2Cur.ValueChanged, AddressOf nudD2Cur_ValueChanged
			//    AddHandler nudD2Cur.ValueEditorClick, AddressOf nudD2Cur_ValueEditorClick
			//    AddHandler nudD2Cur.ValueEditorValueChanged, AddressOf nudD2Cur_ValueChanged

			//    'AddHandler nudHCLCur.ValueChanged, AddressOf nudHCLCur_ValueChanged

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

			nudD2Cur.Enabled = blnEnabled;

			nudSlit.Enabled = blnEnabled;

			nudSlit_Ref.Enabled = blnEnabled;

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

	#Region " Private Functions "

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
		try {
			//---------------------------------------------------------
			//To check if Flame is present and turn it OFF and also Air OFF
			if (gobjInst.Aaf == true) {
				if (gobjCommProtocol.funcFlame_OFF() == true) {
					gobjInst.Aaf = false;
				}
			}
			gobjCommProtocol.funcAir_OFF();
			//---------------------------------------------------------

			nudD2Cur.Visible = true;
			nudPMT.Visible = true;
			nudPMT_Ref.Visible = true;
			nudSlit.Visible = true;
			nudSlit_Ref.Visible = true;
			cmbSpeed.Visible = true;
			cmbModes.Visible = true;
			func_Enable_DisableControl(false);
			nudPMT_Ref.Enabled = false;
			////----- Added by Sachin Dokhale on 14.07.07
			if (!gstructSettings.ExeToRun == EnumApplicationMode.ServiceUtility) {
				if (!IsNothing(gobjMain)) {
					if (gobjMain.mobjController.IsThreadRunning == true) {
						gobjMain.mobjController.Cancel();
						gobjCommProtocol.mobjCommdll.subTime_Delay(500);
						//10.12.07
						Application.DoEvents();
					}
				}
				gobjfrmStatus.Visible = true;
				Application.DoEvents();
			}
			////----
			//'gobjfrmStatus.Visible = False
			this.BringToFront();
			Application.DoEvents();

			if (gobjInst.Mode > -1) {
				////----- Added by Sachin Dokhale. Get the init. calibration mode.
				m_bytCalibMode = gobjInst.Mode;
				cmbModes.SelectedIndex = gobjInst.Mode;
			}

			////---- for Uv Spectrum Reading
			gblnUVS = true;
			////--- Start for UV abs 
			gblnUVABS = true;
			////-----
			////----- Set the D2 Energy as default mode for UV Spectrum
			funcSetDefaultSpectrumParameter(EnumCalibrationMode.D2E);
			//Call funcSetDefaultSpectrumParameter(cmbModes.SelectedIndex)

			funcSetDefaultParameter();

			gobjMessageAdapter.ShowMessage(constBurerCuvette);
			Application.DoEvents();
			////----- Set wavelength default
			////----- Display Current Wavelength
			//Application.DoEvents()
			double dblCurrWv;
			if (gobjCommProtocol.funcGet_Current_Wv(dblCurrWv) == true) {
				lblWvPos.Text = mXValueLable + dblCurrWv.ToString;
				lblWvPos.Refresh();
				lblYValue.Text = mYValueLable + ": 0.0";
				lblYValue.Refresh();
			} else {
				//mobjThreadController.Display("Error" & "|" & "0.0")
				lblWvPos.Text = mXValueLable;
				lblWvPos.Refresh();
				lblYValue.Text = mYValueLable;
				lblYValue.Refresh();
			}
			////----------------

			gobjCommProtocol.Wavelength_Position(mobjParameters.XaxisMin, lblWvPos);
			gobjCommProtocol.mobjCommdll.subTime_Delay(100);

			AddHandlers();
			////-----
			//gblnSpectrumTerminated = False
			//gblnSpectrumWait = False
			func_Enable_Disable(EnumProcesses.FormInitialize, EnumStart_End.Start_of_Process);
			func_Enable_DisableControl(true);
			if (!(gintInstrumentBeamType == AAS203Library.Instrument.enumInstrumentBeamType.SingleBeam)) {
				nudPMT_Ref.Enabled = true;
			}
			this.Refresh();


		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
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
			mnuLoadSpectrumFile.Click += mnuLoadSpectrumFile_Click;
			mnuSaveSpectrumFile.Click += mnuSaveSpectrumFile_Click;
			//AddHandler cmbModes.SelectedIndexChanged, AddressOf cmbModes_SelectedIndexChanged
			mnuExit.Click += mnuExit_Click;
			btnReturn.Click += mnuExit_Click;
			btnStart.Click += btnStart_Click;
			btnBaseLine.Click += btnBaseLine_Click;
			btnClearSpectrum.Click += btnClearSpectrum_Click;
			//--Added By Pankaj 22 May 07
			mnuStart.Click += btnStart_Click;
			mnuBaseLine.Click += btnBaseLine_Click;
			mnuClearSpectrum.Click += btnClearSpectrum_Click;
			//----------
			mnuPeakPick.Click += mnuPeakPick_Click;
			//AddHandler nudD2Cur.ValueChanged, AddressOf nudD2Cur_ValueChanged
			nudD2Cur.ValueEditorClick += nudD2Cur_ValueEditorClick;
			nudD2Cur.ValueEditorValueChanged += nudD2Cur_ValueChanged;

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
			mnuAbsTransmission.Click += mnuAbsTransmission_Click;
			mnuSmooth.Click += mnuSmoothGraph_Click;
			cmbModes.SelectedIndexChanged += cmbModes_SelectedIndexChanged;
			mnuParameters.Click += mnuParameters_Click;
			AASGraphUVSpectrum.GraphScaleChanged += AASGraphUVSpectrum_GraphScaleChanged;

			mnuPeakEdit.Click += mnuPeakEdit_Click;
			mnuGrid.Click += mnuGrid_Click;
			mnuShowXYValues.Click += mnuShowXYValues_Click;
			mnuLegends.Click += mnuLegends_Click;
			AASGraphUVSpectrum.GraphOptionChanged += AASGraphUVSpectrum_GraphOptionChanged;
			//AddHandler mnuD2Peak.Click, AddressOf mnuD2Peak_Click

			//Tlbbtn for Graph Options
			//AddHandler tlbbtnp PeakEdit.Click, AddressOf mnuPeakEdit_Click
			//AddHandler tlbbtnGrid.Click, AddressOf mnuGrid_Click
			//AddHandler tlbbtnShowXYValues.Click, AddressOf mnuShowXYValues_Click
			//AddHandler tlbbtnLegends.Click, AddressOf mnuLegends_Click

			tlbbtnReturn.Click += mnuExit_Click;
			tlbbtnStart.Click += btnStart_Click;
			tlbbtnBaseLine.Click += btnBaseLine_Click;
			tlbbtnClearSpectrum.Click += btnClearSpectrum_Click;
			tlbbtnChangeScale.Click += cmdChangeScale_Click;
			tlbbtnLoadspectrumFile.Click += mnuLoadSpectrumFile_Click;
			tlbbtnSaveSpectrumFile.Click += mnuSaveSpectrumFile_Click;
			tlbbtnSmooth.Click += mnuSmoothGraph_Click;
			tlbbtnAbsToTransmission.Click += mnuAbsTransmission_Click;
			tlbbtnParameters.Click += mnuParameters_Click;
			tlbbtnPrintGraph.Click += tlbbtnPrintGraph_Click;
			mnuPrintGraph.Click += tlbbtnPrintGraph_Click;

			btnDelete.Click += btnDelete_Click;
			btnR.Click += btnR_Click;


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
			if (gblnBaseLine == false) {
				gobjMessageAdapter.ShowMessage(constPerformBaseLine);
				Application.DoEvents();
				return;
			}


			if (gobjMessageAdapter.ShowMessage(constStartScan, true) == false) {
				Application.DoEvents();
				return;
			}
			Application.DoEvents();
			m_blnBaseline = false;



			func_Enable_Disable(EnumProcesses.StartScan, EnumStart_End.Start_of_Process);
			func_Enable_DisableControl(false);
			//Display graph
			if (mobjChannnels.Count > 0) {
				funcDisplayGraph(mobjChannnels(mintChannelIndex));
			}

			if (funcOnSpect(false, lblWvPos, lblYValue) == false) {
				func_Enable_Disable(EnumProcesses.StartScan, EnumStart_End.End_of_Process);
				return;
			}

			btnStart.Text = "&Stop";
			btnStart.Image = Image.FromFile(Application.StartupPath + "\\" + "images\\stop.ico");
			tlbbtnStart.Text = "&Stop";
			tlbbtnStart.Image = Image.FromFile(Application.StartupPath + "\\Images\\cancel_1.ico");
			mnuStart.Text = "&Stop";
			mnuStart.Image = Image.FromFile(Application.StartupPath + "\\Images\\cancel_1.ico");
			btnStart.Enabled = true;
			mnuStart.Enabled = true;
			tlbbtnStart.Enabled = true;

			btnBaseLine.Enabled = false;
			mnuBaseLine.Enabled = false;
			tlbbtnBaseLine.Enabled = false;
			btnStart.Refresh();
			btnBaseLine.Refresh();

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
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

	private void subStartBaseline()
	{
		//=====================================================================
		// Procedure Name        : subStartBaseline
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

			if (gobjMessageAdapter.ShowMessage(constStartRef, true) == false) {
				Application.DoEvents();
				return;
			}
			Application.DoEvents();

			if (gblnBaseLine == true) {
				return;
			}


			m_blnBaseline = true;
			func_Enable_Disable(EnumProcesses.StartScan, EnumStart_End.Start_of_Process);
			func_Enable_DisableControl(false);
			if ((gobjInst.D2Pmt == 0)) {
				gobjClsAAS203.funcAdj_D2Gain(true);
				gobjCommProtocol.Wavelength_Position(mobjParameters.XaxisMin);
			}


			if (funcOnSpect(true, lblWvPos, lblYValue) == false) {
				func_Enable_Disable(EnumProcesses.StartScan, EnumStart_End.End_of_Process);
				func_Enable_DisableControl(true);
				return;
			}
			btnBaseLine.Text = "&Stop";
			btnBaseLine.Image = Image.FromFile(Application.StartupPath + "\\" + "images\\stop.ico");
			tlbbtnBaseLine.Text = "&Stop";
			tlbbtnBaseLine.Image = Image.FromFile(Application.StartupPath + "\\Images\\cancel_1.ico");
			mnuBaseLine.Text = "&Stop";
			mnuBaseLine.Image = Image.FromFile(Application.StartupPath + "\\Images\\cancel_1.ico");

			btnStart.Enabled = false;
			mnuStart.Enabled = false;
			tlbbtnStart.Enabled = false;

			btnBaseLine.Enabled = true;
			tlbbtnBaseLine.Enabled = true;
			mnuBaseLine.Enabled = true;

			btnStart.Refresh();
			btnBaseLine.Refresh();

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
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
			// Set interupte for Termination of the thread
			//gblnSpectrumTerminated = True
			mobjclsBgSpectrum.ThTerminate = true;


		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
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

			if (mintChannelIndex > -1) {
				if (mobjChannnels.Count > 0) {
					if (blnYetFileNotSave == true) {
						if (gobjMessageAdapter.ShowMessage(constFileNotSaved) == true) {
							Application.DoEvents();
							funcSaveSpectrumFile();
						}
						Application.DoEvents();
					}
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
		try {
			Channel chanel0;

			if (mblnAvoidProcessing == true) {
				return;
			}
			if (mintChannelIndex > -1) {
				chanel0 = mobjSpectrum.funcCloneUVSChannel(mobjChannnels(mintChannelIndex));
				if (!(chanel0) == null) {
					mobjSpectrum.funcSmooth1(chanel0, 0);
					mobjChannnels(mintChannelIndex) = mobjSpectrum.funcCloneUVSChannel(chanel0);
					funcClearGraph();
					funcDisplayGraph(mobjChannnels.item(mintChannelIndex));
					funcGraphPreRequisite(mobjParameters.Cal_Mode, mobjParameters.XaxisMin, mobjParameters.XaxisMax, mobjParameters.YaxisMin, mobjParameters.YaxisMax);
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
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 14.12.06
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		DataTable objDataTable = new DataTable();
		Channel objPeakVallyChannel;
		int intCounter = 0;
		long lngPeakValleyCounts;
		int intShowdialog;
		clsDataFileReport objclsDataFileReport = new clsDataFileReport();

		try {
			if (mblnAvoidProcessing == true) {
				return;
			}
			mblnAvoidProcessing = true;

			if (mintChannelIndex > -1) {
				if (!(mobjChannnels.item(mintChannelIndex) == null)) {
					if (mobjSpectrum.funcPeaks(mobjChannnels.item(mintChannelIndex), mStuctPeaksValley) == false) {
						gobjMessageAdapter.ShowMessage(constErrorPopulatingPeakValleyData);
						Application.DoEvents();
						//MsgBox("Error in Peak Valley Methods", MsgBoxStyle.Critical)
					}
				} else {
					return;
				}
				//--- Check for Peak-Valley points

				lngPeakValleyCounts = mobjSpectrum.PeakValleyCount;
				if (lngPeakValleyCounts <= 0) {
					gobjMessageAdapter.ShowMessage(constNOPeakORValley);
					Application.DoEvents();
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

				////----- Ini channel object for UV Spectrum 
				objPeakVallyChannel = mobjChannnels.item(mintChannelIndex);

				if (!mobjSpectrum.funcGetDataPeakPickResults(objDataTable, mStuctPeaksValley, lngPeakValleyCounts, objPeakVallyChannel)) {
					gobjMessageAdapter.ShowMessage(constErrorPopulatingPeakValleyData);
					Application.DoEvents();
					//gFuncShowMessage("Error...", "Error in populating the peak valley data in the data table to display on the screen.", EnumMessageType.Information)
				}

				frmPeakPicks frmPeakPick = new frmPeakPicks();
				frmPeakPick.funcDisplayPicPeakResults(objDataTable);

				intShowdialog = frmPeakPick.ShowDialog();
				if (intShowdialog == DialogResult.Yes) {
					objclsDataFileReport.DefaultFont = this.DefaultFont();
					objclsDataFileReport.funcPeakValleyPrintUV(AASGraphUVSpectrum, objDataTable, mobjParameters, "");
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
			if (!objWait == null) {
				objWait.Dispose();
			}
			//---------------------------------------------------------
		}
	}

	private void subSetScanParameter()
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
		CWaitCursor objWait = new CWaitCursor();
		frmParameter objfrmSampleParameter = new frmParameter();
		try {
			if (mblnAvoidProcessing == true) {
				return;
			}
			mblnAvoidProcessing = true;

			if (objfrmSampleParameter.ShowDialog == DialogResult.OK) {
				mobjParameters.SpectrumName = objfrmSampleParameter.SpectrumParameter.SpectrumName;
				mobjParameters.Comments = objfrmSampleParameter.SpectrumParameter.Comments;
			}

			objfrmSampleParameter.Close();
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
			mblnAvoidProcessing = false;

			if (!objfrmSampleParameter == null) {
				objfrmSampleParameter.Dispose();
			}

			if (!objWait == null) {
				objWait.Dispose();
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

			if (gobjCommProtocol.funcCalibrationMode(EnumCalibrationMode.D2E)) {
				//addataSpect.dblWvMin = 230.0
				//addataSpect.dblWvMax = 250.0
				//mobjParameters.XaxisMin = 190
				//mobjParameters.XaxisMax = 400
				mobjParameters.XaxisMin = 190;
				mobjParameters.XaxisMax = 220;

				switch (gobjInst.Mode) {
					case EnumCalibrationMode.AA:
					case EnumCalibrationMode.AABGC:
					case EnumCalibrationMode.MABS:
						//addataSpect.dblYmin = const_YMinAbs
						//addataSpect.dblYMax = const_YMaxAbs
						mobjParameters.YaxisMax = const_YMaxAbs;
						mobjParameters.YaxisMin = const_YMinAbs;
						mYValueLable = const_Absorbance;
					case EnumCalibrationMode.D2E:
						mobjParameters.YaxisMax = const_YMaxAbs;
						mobjParameters.YaxisMin = const_YMinAbs;
						if (gblnUVABS == true) {
							mYValueLable = const_Absorbance;
						} else {
							mYValueLable = const_Transmission;
						}
					case EnumCalibrationMode.HCLE:

						//mobjParameters.YaxisMin = const_YMinEnergy
						//mobjParameters.YaxisMax = const_YMaxEnergy
						mobjParameters.YaxisMin = const_YMinAbs;
						mobjParameters.YaxisMax = const_YMaxAbs;
						mYValueLable = const_Absorbance;
					case EnumCalibrationMode.EMISSION:
						mobjParameters.YaxisMin = const_YMinEmission;
						mobjParameters.YaxisMax = const_YMaxEmission;
						mYValueLable = const_Emission;
					case EnumCalibrationMode.SELFTEST:
						mobjParameters.YaxisMin = const_YMinmVolt;
						mobjParameters.YaxisMax = const_YMaxmVolt;
						mYValueLable = const_Volt;
				}

				//addataSpect.intSpeed = 50
				//addataSpect.intMode = gobjInst.Mode
				//addataSpect.blnPloted = True
				////-----
				mobjParameters.ScanSpeed = CONST_SLOWStep;
				mobjParameters.Cal_Mode = gobjInst.Mode;
				//AASGraphUVSpectrum.AldysPane.Legend.IsVisible = False
				AASGraphUVSpectrum.AldysPane.Legend.IsVisible = true;

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
		// Parameters Passed     : intCalibrationMode
		// Returns               : Boolean
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
			funcSetSpectrumParameter = false;

			////----- Set the default parameter to the spectrum.
			if ((gobjInst.Mode == intCalibrationMode)) {
				funcSetSpectrumParameter = true;
				return;
			}

			if (gobjCommProtocol.funcCalibrationMode(EnumCalibrationMode.D2E)) {
				//addataSpect.dblWvMin = 230.0
				//addataSpect.dblWvMax = 250.0
				//mobjParameters.XaxisMin = 190
				//mobjParameters.XaxisMax = 400
				mobjParameters.XaxisMin = 190;
				mobjParameters.XaxisMax = 220;

				switch (gobjInst.Mode) {
					case EnumCalibrationMode.AA:
					case EnumCalibrationMode.AABGC:
					case EnumCalibrationMode.MABS:
						//addataSpect.dblYmin = const_YMinAbs
						//addataSpect.dblYMax = const_YMaxAbs
						mobjParameters.YaxisMax = const_YMaxAbs;
						mobjParameters.YaxisMin = const_YMinAbs;
						mYValueLable = const_Absorbance;
					case EnumCalibrationMode.D2E:
						mobjParameters.YaxisMax = const_YMaxAbs;
						mobjParameters.YaxisMin = const_YMinAbs;
						if (gblnUVABS == true) {
							mYValueLable = const_Absorbance;
						} else {
							mYValueLable = const_Transmission;
						}
					case EnumCalibrationMode.HCLE:

						//mobjParameters.YaxisMin = const_YMinEnergy
						//mobjParameters.YaxisMax = const_YMaxEnergy
						mobjParameters.YaxisMin = const_YMinAbs;
						mobjParameters.YaxisMax = const_YMaxAbs;
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

				//addataSpect.intSpeed = 50
				//addataSpect.intMode = gobjInst.Mode
				//addataSpect.blnPloted = True
				////-----
				mobjParameters.ScanSpeed = CONST_SLOWStep;
				mobjParameters.Cal_Mode = gobjInst.Mode;
				blnSetDefaultSpectrumParameter = true;
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


			////----- Set the default parameter to the spectrum.
			///----- Set the Form object parameter
			////----- Set PMT Object
			//nudPMT.DecimalPlaces = 0
			//nudPMT.Increment = 5.0
			//nudPMT.Maximum = 700.0
			//nudPMT.Minimum = 0.0
			//nudPMT.DecimalPlaces = 0
			nudPMT.DecimalPlace = 0;
			nudPMT.ChangeFactor = 5.0;
			nudPMT.MaxValue = 700.0;
			nudPMT.MinValue = 0.0;

			nudPMT.Value = gobjInst.PmtVoltage;
			mobjParameters.PMTV = gobjInst.PmtVoltage;

			nudPMT_Ref.DecimalPlace = 0;
			nudPMT_Ref.ChangeFactor = 5.0;
			nudPMT_Ref.MaxValue = 700.0;
			nudPMT_Ref.MinValue = 0.0;
			nudPMT_Ref.Value = gobjInst.PmtVoltageReference;
			mobjParameters.PMTV_Ref = gobjInst.PmtVoltageReference;

			////-----

			////----- Set D2 current Object
			if (gobjCommProtocol.SRLamp) {
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
			funcSetD2_CurParameter(300);
			nudD2Cur.Value = gobjInst.D2Current;
			if (nudD2Cur.Value == 100.0) {
				nudD2Cur.Text = "D2 Off";
			}
			mobjParameters.D2Curr = gobjInst.D2Current;
			////-----

			////----- Set Slit width Object
			nudSlit.DecimalPlace = 1;
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
			mobjParameters.SlitWidth_Ref = (double)nudSlit_Ref.Value;
			////-----

			if (gobjInst.Mode == 2) {
			}
			mobjParameters.Cal_Mode = gobjInst.Mode;
			////----- Set the d2E default mode
			cmbModes.SelectedIndex = 0;
			cmbModes.Enabled = false;

			////----- Set slow Speed 
			//cmbSpeed.SelectedIndex = 2
			//mobjParameters.ScanSpeed = CONST_SLOWStep

			////----- Set Slow Speed 
			cmbSpeed.SelectedIndex = 2;
			mobjParameters.ScanSpeed = CONST_SLOWStep;

			lblYValue.Text = mYValueLable + ": ";
			lblYValue.Refresh();

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
		try {
			funcSetParameter = false;


			////----- Set the default parameter to the spectrum.
			///----- Set the Form object parameter
			////----- Set PMT Object




			if (mobjChannnels(mintChannelIndex).ChannelNo > -1) {

				//nudPMT.Value = gobjInst.PmtVoltage
				nudPMT.Value = mobjChannnels(mintChannelIndex).UVParameter.PMTV();
				nudPMT_Ref.Value = mobjChannnels(mintChannelIndex).UVParameter.PMTV_Ref;
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
				nudD2Cur.Value = mobjChannnels(mintChannelIndex).UVParameter.D2Curr;
				////-----

				////----- Set Slit width Object
				//nudSlit.Value = gobjClsAAS203.funcGet_SlitWidth()
				nudSlit.Value = mobjChannnels(mintChannelIndex).UVParameter.SlitWidth;
				nudSlit_Ref.Value = mobjChannnels(mintChannelIndex).UVParameter.SlitWidth_Ref;

				////-----

				if (gobjInst.Mode == 2) {
				}

				////----- Set the d2E default mode
				////----- Set slow Speed s
				if (gstructSettings.AppMode == EnumAppMode.FullVersion_201 | gstructSettings.AppMode == EnumAppMode.DemoMode_201) {
					switch (mobjChannnels(mintChannelIndex).UVParameter.ScanSpeed) {
						case CONST_FASTStep_AA201:
							cmbSpeed.SelectedIndex = 0;
						case CONST_MEDIUMStep_AA201:
							cmbSpeed.SelectedIndex = 1;
						case CONST_SLOWStep_AA201:
							cmbSpeed.SelectedIndex = 2;
					}
				} else {
					switch (mobjChannnels(mintChannelIndex).UVParameter.ScanSpeed) {
						case CONST_FASTStep:
							cmbSpeed.SelectedIndex = 0;
						case CONST_MEDIUMStep:
							cmbSpeed.SelectedIndex = 1;
						case CONST_SLOWStep:
							cmbSpeed.SelectedIndex = 2;
					}
				}
				lblYValue.Text = mYValueLable + ": ";
				lblYValue.Refresh();

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
			////----- Set PMT Object



			//--- Set issue for Speed 
			//If gblnSetSpeedIssue = True Then
			////----- added by Sachin dokhale to remove handlers on 08.10.07
			//28.09.07
			nudD2Cur.ValueEditorClick -= nudD2Cur_ValueEditorClick;
			nudD2Cur.ValueEditorValueChanged -= nudD2Cur_ValueChanged;

			nudSlit.ValueEditorClick -= nudSlit_ValueEditorClick;
			nudSlit.ValueEditorValueChanged -= nudSlit_ValueChanged;
			nudSlit_Ref.ValueEditorClick -= nudSlit_Ref_ValueEditorClick;
			nudSlit_Ref.ValueEditorValueChanged -= nudSlit_Ref_ValueChanged;


			nudPMT.ValueEditorClick -= nudPMT_ValueEditorClick;
			nudPMT.ValueEditorValueChanged -= nudPMT_ValueChanged;
			nudPMT_Ref.ValueEditorClick -= nudPMT_Ref_ValueEditorClick;
			nudPMT_Ref.ValueEditorValueChanged -= nudPMT_Ref_ValueChanged;
			////-----
			//End If


			nudPMT.Value = gobjInst.PmtVoltage;
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

			if (!(mobjParameters == null)) {
				mobjParameters.PMTV = gobjInst.PmtVoltage;
				mobjParameters.PMTV_Ref = gobjInst.PmtVoltageReference;
				//mobjParameters.HCLCurr = gobjInst.Current
				mobjParameters.D2Curr = gobjInst.D2Current;
				mobjParameters.SlitWidth = Val(nudSlit.Value);
				mobjParameters.SlitWidth_Ref = Val(nudSlit_Ref.Value);

			}

			////-----

			//--- Set issue for Speed 
			//If gblnSetSpeedIssue = True Then
			////----- added by Sachin dokhale to add handlers on 08.10.07
			//28.09.07
			nudD2Cur.ValueEditorClick += nudD2Cur_ValueEditorClick;
			nudD2Cur.ValueEditorValueChanged += nudD2Cur_ValueChanged;

			nudSlit.ValueEditorClick += nudSlit_ValueEditorClick;
			nudSlit.ValueEditorValueChanged += nudSlit_ValueChanged;
			nudSlit_Ref.ValueEditorClick += nudSlit_Ref_ValueEditorClick;
			nudSlit_Ref.ValueEditorValueChanged += nudSlit_Ref_ValueChanged;


			nudPMT.ValueEditorClick += nudPMT_ValueEditorClick;
			nudPMT.ValueEditorValueChanged += nudPMT_ValueChanged;
			nudPMT_Ref.ValueEditorClick += nudPMT_Ref_ValueEditorClick;
			nudPMT_Ref.ValueEditorValueChanged += nudPMT_Ref_ValueChanged;
			//End If
			////---

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
					gobjInst.PmtVoltage = dblPMTVolt;
					funcSetPmtVParameter = true;
				}
				mobjParameters.PMTV = Val(dblPmtV);
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
					gobjInst.PmtVoltageReference = dblPMTVolt;
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
			if (gstructSettings.AppMode == EnumAppMode.FullVersion_201) {
				switch (intSpeed) {
					case 0:
						mobjParameters.ScanSpeed = CONST_FASTStep_AA201;
					case 1:
						mobjParameters.ScanSpeed = CONST_MEDIUMStep_AA201;
					case 2:
						mobjParameters.ScanSpeed = CONST_SLOWStep_AA201;
				}
			} else {
				switch (intSpeed) {
					case 0:
						mobjParameters.ScanSpeed = CONST_FASTStep;
					case 1:
						mobjParameters.ScanSpeed = CONST_MEDIUMStep;
					case 2:
						mobjParameters.ScanSpeed = CONST_SLOWStep;
				}
				//mobjParameters.ScanSpeed = intSpeed
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
			mobjParameters.SlitWidth_Ref = Val(dblSlitWidth);
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

	public bool funcOnSpect(bool BaseLine, ref System.Object lblScanStatus, ref System.Object lblOnlineWv)
	{

		////----- Orig
		//addata.counter = 0;
		// if (addata.speed==0){
		//if (GetInstrument()==AA202) addata.speed=FASTSTEP_AA202;
		//else addata.speed=FAST;
		// }
		// speed = addata.speed;
		///-----
		mobjParameters.UVABS = true;
		mobjParameters.IsBaseline = BaseLine;

		if (mobjParameters.ScanSpeed == 0) {
			if (gstructSettings.AppMode == EnumAppMode.FullVersion_201) {
				mobjParameters.ScanSpeed = CONST_STEPS_PER_NM_AA201;
			} else {
				mobjParameters.ScanSpeed = CONST_STEPS_PER_NM;
			}
		}
		//If (addataSpect.intSpeed = 0) Then
		//    addataSpect.intSpeed = CONST_STEPS_PER_NM
		//End If

		//If (mobjParameters.ScanSpeed = 0) Then
		//   mobjParameters.ScanSpeed = CONST_STEPS_PER_NM
		//End If


		//If Not (gblnUVABS = True) Then

		//addataSpect.dblYmin = 0.0
		//addataSpect.dblYMax = 1.0


		//--- Add the parameters to the online channel object
		//Dim ObjParameter As New Spectrum.UVSpectrumParameter
		mobjOnlineChannel = new Spectrum.Channel(false);
		mobjUVEnegyChannel = new Spectrum.EnergyChannels();
		//ObjParameter = mobjSpectrum.funcCloneUVParameter(mobjParameters)
		//mobjOnlineChannel.UVParameter = ObjParameter
		mobjOnlineChannel.UVParameter = mobjSpectrum.funcCloneUVParameter(mobjParameters);
		//ObjParameter = Nothing

		if (!funcGraphPreRequisite(mobjParameters.Cal_Mode, mobjParameters.XaxisMin, mobjParameters.XaxisMax, mobjParameters.YaxisMin, mobjParameters.YaxisMax)) {
			//Call gFuncShowMessage("Error in setting spectrum parameters", "Please Check Entered Spectrum Parameters", modConstants.EnumMessageType.Information)
			return;
		}

		gblnUVABS = true;
		mblnAvoidProcessing = true;

		mobjOnlineReadings = new Spectrum.Readings();

		mblnSpectrumStarted = true;

		gblnUVABS = true;
		//RemoveHandler mnuIgnite.Click, AddressOf btnIgnite_Click
		//--- Start the Spectrum analysis
		//mobjController.Start(New clsBgSpectrum(lblWvPos, lblOnlineWv, _
		//                     mobjParameters.XaxisMax, _
		//                     mobjParameters.XaxisMin, _
		//                     mobjParameters.YaxisMax, _
		//                     mobjParameters.YaxisMin, _
		//                     mobjParameters.Cal_Mode, _
		//                     mobjParameters.ScanSpeed, BaseLine))

		mobjController = new clsBgThread(this);
		mobjclsBgSpectrum = new clsBgSpectrum(lblWvPos, lblOnlineWv, mobjParameters.XaxisMax, mobjParameters.XaxisMin, mobjParameters.YaxisMax, mobjParameters.YaxisMin, mobjParameters.Cal_Mode, mobjParameters.ScanSpeed, 0, false,
		BaseLine);

		mobjController.Start(mobjclsBgSpectrum);


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

	private void subLabelDisplay(Spectrum.Channel objChannel)
	{
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
		int intChannel_no;

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
			return 0;
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			//---------------------------------------------------------
		}

	}

	//Private Function funcCloneParameter(ByVal inobjparamter As Spectrum.UVSpectrumParameter) As Spectrum.UVSpectrumParameter
	//    Try
	//        Dim objCloneParameter As New UVSpectrumParameter
	//        '----------------------Cloning  parameter object ----------------------------------
	//        objCloneParameter.AnalysisDate = inobjparamter.AnalysisDate
	//        objCloneParameter.Cal_Mode = inobjparamter.Cal_Mode
	//        objCloneParameter.Comments = inobjparamter.Comments
	//        objCloneParameter.D2Curr = inobjparamter.D2Curr
	//        objCloneParameter.PMTV = inobjparamter.PMTV
	//        objCloneParameter.PMTV_Ref = inobjparamter.PMTV_Ref
	//        objCloneParameter.ScanSpeed = inobjparamter.ScanSpeed
	//        objCloneParameter.SlitWidth = inobjparamter.SlitWidth
	//        objCloneParameter.SlitWidth_Ref = inobjparamter.SlitWidth_Ref
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
		double dblCurrYaxis;
		double dblNewYaxis;
		double intXaxisIdx;

		try {
			gblnUVABS = !gblnUVABS;


			if (mobjChannnels.Count > mintChannelIndex) {
				if (mobjChannnels.item(mintChannelIndex).Spectrums.Count > 0) {
					//For intXaxisIdx = gFuncGetIndexWv(mobjChannnels.item(mintChannelIndex).UVParameter.XaxisMin, False) To gFuncGetIndexWv(mobjChannnels.item(mintChannelIndex).UVParameter.XaxisMax, False)
					for (intXaxisIdx = 0; intXaxisIdx <= mobjChannnels.item(mintChannelIndex).Spectrums.item(0).Readings.Count - 1; intXaxisIdx++) {
						//dblCurrYaxis = mobjChannnels.item(mintChannelIndex).Spectrums.item(0).Readings.item(intXaxisIdx).YaxisData 
						dblCurrYaxis = mobjChannnels.item(mintChannelIndex).Spectrums.item(0).Readings.item(intXaxisIdx).YaxisADCData;
						//dblCurrYaxis = gfuncGetValueInSpectrum(CInt(dblCurrYaxis), EnumCalibrationMode.AA)
						//k= 2047.0 + exp((2.0- ((addata.ad[i]-2047.0)*2.0/1638.4)) *log(10))*2048.0/100.0;
						if (gblnUVABS == false) {
							dblNewYaxis = 2047.0 + Math.Exp((2.0 - ((dblCurrYaxis - 2047.0) * 2.0 / 1638.4)) * Math.Log(10)) * 2048.0 / 100.0;
						} else {
							dblNewYaxis = dblCurrYaxis;
						}
						mobjChannnels.item(mintChannelIndex).Spectrums.item(0).Readings.item(intXaxisIdx).YaxisData = dblNewYaxis;
					}
				}

				//If gblnUVABS = True Then
				//    mobjChannnels.item(mintChannelIndex).UVParameter.YaxisMax = const_YMaxAbs
				//    mobjChannnels.item(mintChannelIndex).UVParameter.YaxisMin = const_YMinAbs
				//Else
				//    mobjChannnels.item(mintChannelIndex).UVParameter.YaxisMax = const_YMaxTransmision
				//    mobjChannnels.item(mintChannelIndex).UVParameter.YaxisMin = const_YMinTransmision
				//End If
				mobjChannnels.item(mintChannelIndex).UVParameter.UVABS = gblnUVABS;
				funcClearGraph();

				funcDisplayGraph(mobjChannnels.item(mintChannelIndex));
				AASGraphUVSpectrum.Refresh();
				Application.DoEvents();
				//mobjChannnels.item(mintChannelIndex).UVParameter.YaxisMax = const_YMaxTransmision
				//mobjChannnels.item(mintChannelIndex).UVParameter.YaxisMin = const_YMinTransmision
				if (gblnUVABS == true) {
					mobjChannnels.item(mintChannelIndex).UVParameter.YaxisMax = const_YMaxAbs;
					mobjChannnels.item(mintChannelIndex).UVParameter.YaxisMin = const_YMinAbs;
				} else {
					mobjChannnels.item(mintChannelIndex).UVParameter.YaxisMax = const_YMaxTransmision;
					mobjChannnels.item(mintChannelIndex).UVParameter.YaxisMin = const_YMinTransmision;
				}
				funcGraphPreRequisite(mobjParameters.Cal_Mode, mobjParameters.XaxisMin, mobjParameters.XaxisMax, mobjParameters.YaxisMin, mobjParameters.YaxisMax);
				//If gblnUVABS = True Then
				//    mobjChannnels.item(mintChannelIndex).UVParameter.YaxisMax = const_YMaxTransmision
				//    mobjChannnels.item(mintChannelIndex).UVParameter.YaxisMin = const_YMinTransmision
				//Else
				//    mobjChannnels.item(mintChannelIndex).UVParameter.YaxisMax = const_YMaxAbs
				//    mobjChannnels.item(mintChannelIndex).UVParameter.YaxisMin = const_YMinAbs
				//End If

				mobjChannnels.item(mintChannelIndex).UVParameter.UVABS = gblnUVABS;
				AASGraphUVSpectrum.OfflineCurve.Label = AASGraphUVSpectrum.YAxisLabel;
				AASGraphUVSpectrum.Refresh();
				Application.DoEvents();

			}

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

	private bool funcTransmissionConvertAbs()
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
		double dblCurrYaxis;
		double dblNewYaxis;
		double intXaxisIdx;

		try {
			gblnUVABS = false;
			if (mobjChannnels.Count > mintChannelIndex) {
				if (mobjChannnels.item(mintChannelIndex).Spectrums.Count > 0) {
					//For intXaxisIdx = gFuncGetIndexWv(mobjChannnels.item(mintChannelIndex).UVParameter.XaxisMin, False) To gFuncGetIndexWv(mobjChannnels.item(mintChannelIndex).UVParameter.XaxisMax, False)
					for (intXaxisIdx = 0; intXaxisIdx <= mobjChannnels.item(mintChannelIndex).Spectrums.item(0).Readings.Count - 1; intXaxisIdx++) {
						dblCurrYaxis = mobjChannnels.item(mintChannelIndex).Spectrums.item(0).Readings.item(intXaxisIdx).YaxisData;
						//dblCurrYaxis = mobjChannnels.item(mintChannelIndex).Spectrums.item(0).Readings.item(intXaxisIdx).YaxisADCData
						//k= 2047.0 + exp((2.0- ((addata.ad[i]-2047.0)*2.0/1638.4)) *log(10))*2048.0/100.0;
						dblNewYaxis = 2047.0 + Math.Exp((2.0 - ((dblCurrYaxis - 2047.0) * 2.0 / 1638.4)) * Math.Log(10)) * 2048.0 / 100.0;
						//dblCurrYaxis = gfuncGetValueInSpectrum(CInt(dblCurrYaxis), EnumCalibrationMode.AA)
						mobjChannnels.item(mintChannelIndex).Spectrums.item(0).Readings.item(intXaxisIdx).YaxisData = dblNewYaxis;
					}
				}
				//mobjChannnels.item(mintChannelIndex).UVParameter.UVABS = (gblnUVABS)
				funcClearGraph();

				funcDisplayGraph(mobjChannnels.item(mintChannelIndex));
				mobjChannnels.item(mintChannelIndex).UVParameter.YaxisMax = const_YMaxTransmision;
				mobjChannnels.item(mintChannelIndex).UVParameter.YaxisMin = const_YMinTransmision;
				funcGraphPreRequisite(mobjParameters.Cal_Mode, mobjParameters.XaxisMin, mobjParameters.XaxisMax, mobjParameters.YaxisMin, mobjParameters.YaxisMax);

			}

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
			//If mobjChannnels.item(mintChannelIndex) Is Nothing Then
			if (mobjChannnels.item(mobjChannnels.Count - 1) == null) {
				gobjMessageAdapter.ShowMessage(constSpectrumNotPresent);
				Application.DoEvents();
				//gFuncShowMessage("Error", "Spectrum is not present for saving.", EnumMessageType.Information)
				return;
			}

			//Dim objchannel As Spectrum.Channel
			Spectrum.EnergyChannels objUVEnergyChannels = new Spectrum.EnergyChannels();

			//objchannel = mobjChannnels.item(mintChannelIndex)


			//objUVEnergyChannels.Add(mobjChannnels.item(mobjChannnels.Count - 1))
			objUVEnergyChannels.Add(mobjChannnels.item(mintChannelIndex));
			if (gstructSettings.Enable21CFR == true) {
				if (!gfuncGetFileAuthenticationData(objUVEnergyChannels.DigitalSignature)) {
					return true;
				}
			}
			//If gstructApplicationSettings.Enable21CFR = 1 Then
			//    If Not gfuncGetFileAuthenticationData(objchannel.DigitalSignature) Then
			//        Return True
			//    End If
			//Else
			//--- This is for saving the file with login Authnetication 
			//--- when 21 cfr is off
			//If Not gfuncGetFileAuthenticationData_21CFR_OFF(objchannel.DigitalSignature) Then
			//    Return True
			//End If
			//End If

			Stream objStream;
			SaveFileDialog objsfdSpectrum = new SaveFileDialog();

			//--- Show the save dialog to accept the *.spt file.
			objsfdSpectrum.Filter = "UV Spectrum Files(*" + CONST_UVSpectrumFileExt + ")|*" + CONST_UVSpectrumFileExt;
			objsfdSpectrum.FilterIndex = 1;
			objsfdSpectrum.InitialDirectory = strPath.GetCurrentDirectory.ToString + "\\UVSpectrums";
			objsfdSpectrum.RestoreDirectory = true;

			if (objsfdSpectrum.ShowDialog() == DialogResult.OK) {
				objUVEnergyChannels.DigitalSignature.FileName = objsfdSpectrum.FileName;
				//--- Check if file exist   
				if ((objsfdSpectrum.CheckFileExists())) {
					//If (MessageBox.Show("DO YOU WISH TO OVERWRITE", "SAVE AS", MessageBoxButtons.YesNo) = DialogResult.Yes) Then
					if (gobjMessageAdapter.ShowMessage(constSaveAs) == true) {
						Application.DoEvents();
						if (!gfuncSerializeObjectDB(objsfdSpectrum.FileName, objUVEnergyChannels)) {
							gobjMessageAdapter.ShowMessage(constErrorFileSaving);
							Application.DoEvents();
							//gFuncShowMessage("Error", "ERROR IN SAVING FILE.", EnumMessageType.Information)
						}
					} else {
						Application.DoEvents();
						return true;
					}
				} else {
					if (!gfuncSerializeObjectDB(objsfdSpectrum.FileName, objUVEnergyChannels)) {
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
						if (!gfuncSerializeObjectDB(strFileLogPath, objUVEnergyChannels)) {
							throw new Exception();
						}
						//--- Log the file 
						gfuncInsertFileLog(lngActivityLogID, objsfdSpectrum.FileName, strFileLogPath);
					}
				}
			}
			//'--- Log the file 
			//'Call gfuncInsertFileLog(lngActivityLogID, objsfdSpectrum.FileName, strFileLogPath)
			//End If
			//End If


			objsfdSpectrum.Dispose();
			blnYetFileNotSave = false;
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
			blnYetFileNotSave = false;
			//---------------------------------------------------------
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
		int intChannelIdx;
		try {
			funcLoadSpectrumFile = false;

			objofdSpectrum.InitialDirectory = strPath.GetCurrentDirectory.ToString + "\\Spectrums";
			objofdSpectrum.Filter = "Spectrum Files(*" + CONST_UVSpectrumFileExt + ")|*" + CONST_UVSpectrumFileExt;
			objofdSpectrum.FilterIndex = 1;
			objofdSpectrum.RestoreDirectory = true;

			if (objofdSpectrum.ShowDialog() == DialogResult.OK) {
				if ((objofdSpectrum.CheckFileExists())) {
					Spectrum.EnergyChannels objchannels;
					Int16 intChannel_no;

					if (gstructSettings.Enable21CFR == true) {
						Spectrum.EnergyChannels objChn;
						objChn = gfuncDeSerializeObject(objofdSpectrum.FileName, EnumDeserializeObjType.UVSpectrumDB);
						if (gfuncCheckForFileAuthentication(objChn.DigitalSignature)) {
							objchannels = objChn;
						} else {
							gobjMessageAdapter.ShowMessage(constAccessDenied);
							Application.DoEvents();
							return false;
						}
					}
					objchannels = gfuncDeSerializeObject(objofdSpectrum.FileName, EnumDeserializeObjType.UVSpectrumDB);
					//--- Add the new channel to the channels collection and 
					//--- accordingly save the channel file to the disk
					//intChannel_no = funcAddChannelToCollection(objchannel)

					//For intChannelIdx = 0 To objchannels.Count - 1
					intChannelIdx = 0;
					intChannel_no = funcAddChannelToCollection(objchannels(intChannelIdx));
					mintChannelIndex = intChannel_no;
					//Next

					if (mobjChannnels.Count > 0) {
						//mobjChannnels.item(0) = objchannels
						mobjChannnels.item(intChannelIdx) = objchannels(intChannelIdx);
						//mobjChannnels.item(1) = objchannels(1)

						mobjParameters = null;
						mobjParameters = mobjChannnels.item(0).UVParameter;
						gblnUVABS = mobjParameters.UVABS;
						//intChannel_no = funcAddChannelToCollection(mobjOnlineChannel)
						blnYetFileNotSave = true;
						mintChannelIndex = intChannel_no;

						funcSetParameter();
						funcClearGraph();
						//funcDisplayGraph(mobjChannnels.item(mintChannelIndex), mGraphCurveItem)
						//ArrlstGraphCurveItem.Add(mGraphCurveItem)
						//intCurveIndex = ArrlstGraphCurveItem.Count - 1
						//For intChannelIdx = 0 To 1
						intChannelIdx = 0;
						funcDisplayGraph(mobjChannnels.item(intChannelIdx), mGraphCurveItem);
						//funcDisplayGraphOffline(mobjChannnels.item(intChannelIdx), mGraphCurveItem)
						ArrlstGraphCurveItem.Add(mGraphCurveItem);
						intCurveIndex = ArrlstGraphCurveItem.Count - 1;
						//Next
						//funcDisplayGraph(mobjChannnels.item(intChannel_no))
						funcGraphPreRequisite(mobjParameters.Cal_Mode, mobjParameters.XaxisMin, mobjParameters.XaxisMax, mobjParameters.YaxisMin, mobjParameters.YaxisMax);
					} else {
						mobjParameters = null;
						//mobjChannnels.Add(objchannels)
						mobjChannnels.Add(objchannels(0));
						//mobjChannnels.Add(objchannels(1))

						mobjParameters = mobjChannnels.item(intChannel_no).UVParameter;
						gblnUVABS = mobjParameters.UVABS;
						funcSetParameter();
						funcClearGraph();

						//funcDisplayGraph(mobjChannnels.item(intChannel_no))

						funcDisplayGraph(mobjChannnels.item(mintChannelIndex), mGraphCurveItem);
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

	private bool funcSetFrmEditValue(ref double ReturnValue, string strWinTitle, double dblMinValue, double dblMaxValue)
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

					intValue = (int)ReturnValue;
					ReturnValue = intValue;
				default:
				//mobjfrmEditValues.txtValue.ValidationType = NumberValidator.NumberValidator.Validations.DoubleOnly
			}

			//mobjfrmEditValues.txtValue.RangeValidation = True
			//mobjfrmEditValues.txtValue.DigitsAfterDecimalPoint = 2
			//mobjfrmEditValues.txtValue.MaxLength = 3
			//mobjfrmEditValues.txtValue.MinimumRange = dblMinValue
			//mobjfrmEditValues.txtValue.MaximumRange = dblMaxValue
			mobjfrmEditValues.txtValue.Focus();
			mobjfrmEditValues.txtValue.SelectAll();

			mobjfrmEditValues.txtValue.Text = ReturnValue;
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
			//    gobjMessageAdapter.ShowMessage(constInvalidRange)    'constPMTRange
			//    'MsgBox("PMT value should be between 0 and 1000")
			//    Exit Function
			//End If

			ReturnValue = InputValue;
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

	#Region " IClient Events for receiving the wavelength and Abs value from Receiving thread "

	private void BgThread.Iclient.TaskStarted(clsBgThread BgThread)
	{
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
		try {
			//--- Dispose all the objects
			//mobjTemporaryChannel = New Channel
			//mobjTemporaryReadings = New Readings
			//mobjTemporaryReadings_2100 = New Readings
			mAvoidProcessBtn = true;
			funcIclientTaskFalied();

			mblnSpectrumStarted = false;
			mblnAvoidProcessing = false;
			mAvoidProcessBtn = false;
		/////


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
			// by pankaj for applying 1 smooth by default on 29 Nov 07
			if (mnuSmooth.Enabled == true) {
				subSmoothGraph();
			}
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
		try {
			//-----------------------------------------------------
			//Data in the Text arg would be "Wavelength|Abs"
			//-----------------------------------------------------
			Spectrum.Data objData = new Spectrum.Data();
			string[] arrData;
			int O;
			// same as in function funcSmoothgraphonline
			int intCount;

			//Application.DoEvents()
			//--- Split the data for Wv and Abs
			arrData = Split(strData, "|");

			if (arrData(0).Length > 0 & arrData(1).Length > 0) {
				if (IsNumeric(arrData(0)) == false) {
					if (arrData(0) == "Reference") {
						mSelectedBeamType = modGlobalDeclarations.enumSelectBeamType.Reference;
						mstrSelectedBeamType = "Reference";
					} else if (arrData(0) == "Sample") {
						mSelectedBeamType = modGlobalDeclarations.enumSelectBeamType.Sample;
						mstrSelectedBeamType = "Sample";
					} else {
						mSelectedBeamType = modGlobalDeclarations.enumSelectBeamType.Sample;
						mstrSelectedBeamType = "Sample";
					}
					funcFirstChannelTaskCompleted();

				} else {
					objData.XaxisData = Format(Val(arrData(0)), "#000.0000");
					// wv

					//Select Case mobjTemporaryChannel.Parameter.ScanMode
					//    Case EnumScanMode.Absorbance
					//        objData.YaxisData = Format(Val(arrData(1)), "#0.000")
					//    Case EnumScanMode.Transmittance
					//        objData.YaxisData = Format(Val(arrData(1)), "#0.0")
					//    Case EnumScanMode.Energy
					//        objData.YaxisData = Format(Val(arrData(1)), "#0.0")
					//End Select

					objData.YaxisData = Format(Val(arrData(1)), "#0.0000");
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

					mobjOnlineReadings.Add(objData);


					//lblOnlineWv.Text = Format(mobjTemporaryReadings.item(mobjTemporaryReadings.Count - 1).XaxisData, "#000.0")


					//Select Case mobjTemporaryChannel.Parameter.ScanMode
					//    Case EnumScanMode.Absorbance
					//        lblOnlineABS.Text = Format(mobjTemporaryReadings.item(mobjTemporaryReadings.Count - 1).YaxisData, "#0.000")
					//    Case EnumScanMode.Transmittance, EnumScanMode.Energy
					//        lblOnlineABS.Text = Format(mobjTemporaryReadings.item(mobjTemporaryReadings.Count - 1).YaxisData, "#0.0")
					//End Select

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
			}

		} catch (Exception ex) {
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
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

	#End Region

	#Region " IClient Private Function "

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
		// Author                :   Santosh
		// Created               :   Monday, April 12, 2004 15:12
		// Revisions             :
		//=====================================================================

		try {
			funcIclientTaskCompleted = false;

			// If scan is terminated by user in between then gblnSpectrumTerminated = True
			if (!ArrlstGraphCurveItem == null) {
				if (ArrlstGraphCurveItem.Count >= intCurveIndex + 1) {
					AASGraphUVSpectrum.StopOnlineGraph(ArrlstGraphCurveItem(intCurveIndex));
					//intCurveIndex += 1
				}
			}

			Application.DoEvents();
			AASGraphUVSpectrum.AldysPane.AxisChange();
			AASGraphUVSpectrum.Refresh();



			//If gblnSpectrumTerminated = True Then
			//    funcScanCompleted(False)
			//Else 'scan is completed 
			//    funcScanCompleted(True)
			//End If
			if (mobjclsBgSpectrum.ThTerminate == true) {
				funcScanCompleted(false);
			} else {
				funcScanCompleted(true);
			}

			//AddHandler mnuIgnite.Click, AddressOf btnIgnite_Click
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
			if (ArrlstGraphCurveItem.Count >= intCurveIndex + 1) {
				AASGraphUVSpectrum.StopOnlineGraph(ArrlstGraphCurveItem(intCurveIndex));
				//intCurveIndex += 1
				AASGraphUVSpectrum.AldysPane.CurveList.Remove(AASGraphUVSpectrum.AldysPane.CurveList.Count - 1);
				ArrlstGraphCurveItem.RemoveAt(ArrlstGraphCurveItem.Count - 1);
			}

			mobjOnlineChannel = new Channel(false);
			mobjOnlineReadings = new Readings();
			mobjUVEnegyChannel = new Spectrum.EnergyChannels();
			mblnSpectrumStarted = false;

			blnYetFileNotSave = false;

			Application.DoEvents();
			AASGraphUVSpectrum.AldysPane.AxisChange();
			AASGraphUVSpectrum.Refresh();

			funcScanCompleted(false);

			Application.DoEvents();
			gobjMessageAdapter.ShowMessage(constSpectrumScanningFailed);
			Application.DoEvents();
			//gFuncShowMessage("Error...", "Spectrum scanning failed.", EnumMessageType.Information)
			//AddHandler mnuIgnite.Click, AddressOf btnIgnite_Click
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



			if (m_blnBaseline == true) {
				if (gintSample_adc.Length > 0) {
					gblnBaseLine = true;
				}
				btnBaseLine.Text = "&Baseline";
				btnBaseLine.Enabled = true;
				btnBaseLine.Image = Image.FromFile(Application.StartupPath + "\\Images\\Base Line.ico");
				tlbbtnBaseLine.Text = "&Baseline";
				tlbbtnBaseLine.Image = Image.FromFile(Application.StartupPath + "\\Images\\Base Line.ico");
				mnuBaseLine.Text = "&Baseline";
				mnuBaseLine.Image = Image.FromFile(Application.StartupPath + "\\Images\\Base Line.ico");
				btnStart.Enabled = true;
				btnBaseLine.Refresh();
				btnStart.Refresh();
			} else {
				btnStart.Text = "&Start";
				tlbbtnStart.Text = "&Start";
				mnuStart.Text = "&Start";
				btnStart.Image = Image.FromFile(Application.StartupPath + "\\Images\\start.ico");
				tlbbtnStart.Image = Image.FromFile(Application.StartupPath + "\\Images\\start.ico");
				mnuStart.Image = Image.FromFile(Application.StartupPath + "\\Images\\start.ico");
				btnStart.Enabled = true;
				btnBaseLine.Enabled = true;
				btnStart.Refresh();
				btnBaseLine.Refresh();
				if (mobjclsBgSpectrum.ThTerminate == false) {
					if (!funcSpectrumReadingCompleted()) {
					}
				}
				if (!AASGraphUVSpectrum.OfflineCurve == null) {
					AASGraphUVSpectrum.OfflineCurve.Label = AASGraphUVSpectrum.YAxisLabel;
				}
			}

			//funcTimerStartStop(mTimer, EnumTimerStartStop.Timer_Start)
			func_Enable_Disable(EnumProcesses.StartScan, EnumStart_End.End_of_Process);
			func_Enable_DisableControl(true);

		//gblnSpectrumTerminated = False
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
				//gFuncShowMessage("Error...", "Error in adding the spectrum data to the current channel.", EnumMessageType.Information)'114
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

			mobjUVEnegyChannel.Add(mobjOnlineChannel);
			//--- Add the new channel to the channels collection and 
			//--- accordingly save the channel file to the disk
			intChannel_no = funcAddChannelToCollection(mobjOnlineChannel);
			blnYetFileNotSave = true;
			mintChannelIndex = intChannel_no;
			mobjChannnels(mintChannelIndex).UVParameter = mobjParameters;

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
			if (ArrlstGraphCurveItem.Count >= intCurveIndex + 1) {
				AASGraphUVSpectrum.StopOnlineGraph(ArrlstGraphCurveItem(intCurveIndex));
			}


			AASGraphUVSpectrum.AldysPane.AxisChange();
			AASGraphUVSpectrum.Refresh();


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

	#End Region

	#Region " Graph Method "

	private bool funcGraphPreRequisite(int intScanmode, double intXmin, double intXmax, double intYmin, double intYmax)
	{
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
			AASGraphUVSpectrum.btnPeakEdit.Enabled = true;
			AASGraphUVSpectrum.btnShowXYValues.Enabled = true;
			AASGraphUVSpectrum.AldysPane.XAxis.Min = intXmin;
			AASGraphUVSpectrum.AldysPane.XAxis.Max = intXmax;
			AASGraphUVSpectrum.XAxisMin = intXmin;
			AASGraphUVSpectrum.XAxisMax = intXmax;

			//--- Display the axis lables
			AASGraphUVSpectrum.XAxisLabel = "WAVELENGTH (nm)";
			//AxEnergySpectrum.XAxisLabel = "  Energy"

			switch (gobjInst.Mode) {
				case EnumCalibrationMode.AA:
				case EnumCalibrationMode.AABGC:
				case EnumCalibrationMode.MABS:
					AASGraphUVSpectrum.YAxisMin = intYmin;
					AASGraphUVSpectrum.YAxisMax = intYmax;
					AASGraphUVSpectrum.YAxisLabel = "ABSORBANCE";
					AASGraphUVSpectrum.YAxisStep = 0.1;
				case EnumCalibrationMode.D2E:
					AASGraphUVSpectrum.YAxisMin = intYmin;
					AASGraphUVSpectrum.YAxisMax = intYmax;
					if ((gblnUVABS) == true) {
						AASGraphUVSpectrum.YAxisLabel = "ABSORBANCE";
						AASGraphUVSpectrum.YAxisStep = 0.1;
					} else {
						AASGraphUVSpectrum.YAxisLabel = "TRANSMISSION";
						AASGraphUVSpectrum.YAxisStep = 10;
						//AASGraphUVSpectrum.AldysPane.Legend.IsVisible = True

					}
				case EnumCalibrationMode.HCLE:
					AASGraphUVSpectrum.YAxisMin = intYmin;
					AASGraphUVSpectrum.YAxisMax = intYmax;
					AASGraphUVSpectrum.YAxisLabel = "ABSORBANCE";
					AASGraphUVSpectrum.YAxisStep = 0.1;
				case EnumCalibrationMode.EMISSION:
					AASGraphUVSpectrum.YAxisMin = intYmin;
					AASGraphUVSpectrum.YAxisMax = intYmax;
					AASGraphUVSpectrum.YAxisLabel = "EMISSION";
					AASGraphUVSpectrum.YAxisStep = 1;
				case EnumCalibrationMode.SELFTEST:
					AASGraphUVSpectrum.YAxisMin = intYmin;
					AASGraphUVSpectrum.YAxisMax = intYmax;
					//AASEnergySpectrum.AldysPane.YAxis.Min = intYmin
					//AASEnergySpectrum.AldysPane.YAxis.Max = intYmax
					AASGraphUVSpectrum.YAxisLabel = "VOLT(mv)";
					AASGraphUVSpectrum.YAxisStep = 1;
			}

			AASGraphUVSpectrum.XAxisStep = dblMajorStepX;
			AASGraphUVSpectrum.XAxisMinorStep = dblMinorStepX;
			AASGraphUVSpectrum.YAxisStep = dblMajorStepY;
			AASGraphUVSpectrum.YAxisMinorStep = dblMinorStepY;

			//------------Added by Pankaj on 8 May 07
			AASGraphUVSpectrum.XAxisMin = mobjParameters.XaxisMin;
			AASGraphUVSpectrum.XAxisMax = mobjParameters.XaxisMax;

			AASGraphUVSpectrum.YAxisMin = mobjParameters.YaxisMin;
			AASGraphUVSpectrum.YAxisMax = mobjParameters.YaxisMax;

			gobjClsAAS203.Calculate_Analysis_Graph_Param(AASGraphUVSpectrum, ClsAAS203.enumChangeAxis.xyAxis);
			//------------

			AASGraphUVSpectrum.AldysPane.AxisChange();
			//mnuShowXYValues.Checked = True
			this.AASGraphUVSpectrum.IsShowGrid = true;
			this.AASGraphUVSpectrum.btnPeakEdit.Checked = false;
			AASGraphUVSpectrum.Invalidate();
			AASGraphUVSpectrum.Refresh();
			Application.DoEvents();
			//AxSpectrumGraph.ysubdiv = 1
			//AxSpectrumGraph.XdivFormat = "#0.0"

			//If mnuRemoveGrid.Checked = True Then
			//    mnuRemoveGrid.Checked = True
			//    AxSpectrumGraph.Gridcolor = System.Drawing.Color.White
			//Else
			//    '------substitute color of grid if u want to display grid
			//    mnuRemoveGrid.Checked = False
			//    AxSpectrumGraph.Gridcolor = System.Drawing.Color.Gray
			//    'changed by sns on 30sep2004 for printing effect
			//    'AxSpectrumGraph.Gridcolor = System.Drawing.Color.Black
			//End If

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

	//Private Function funcDisplayGraph(ByVal objChannel As Channel, ByVal Xmin As Double, ByVal Xmax As Double, ByVal Ymin As Double, ByVal Ymax As Double) As Boolean
	//    '--- this function has been overloaded to be used only to
	//    '-- suscces the functionality of the Zoom by Coordinates
	//    '-- modf by Nilesh Shirode on 11 Feb 2004
	//    Dim lngDataCount As Long
	//    Dim objReadingCol As New Readings
	//    Dim dblFromX As Double
	//    Dim dblFromY As Double
	//    Dim dblToX As Double
	//    Dim dblToY As Double
	//    'Dim intSpeed As Integer

	//    Try
	//        AxSpectrumGraph.clear()

	//        '--- Set the parameters for the graph control
	//        If Not funcGraphPreRequisite(objChannel, Xmin, Xmax, Ymin, Ymax) Then
	//            gFuncShowMessage("Error", "Error in setting the graph parameters.", modConstants.EnumMessageType.Information)
	//            Return False
	//            Exit Function
	//        End If

	//        '--- Set the graph name and scan speed
	//        lblSpectrumName.Text = objChannel.Parameter.ChannelName


	//        'use this for loop if u want to pass value using plotpointMethod
	//        'Substitute 2 with Number of Values to be Displayed
	//        dblFromX = Xmax
	//        dblFromY = Ymax

	//        '--- Get the speed
	//        'intSpeed = funcGetSpeed(objChannel.Parameter.WavelengthMin, objChannel.Parameter.WavelengthMax)

	//        '--------Extracting Values from Data Object
	//        For lngDataCount = gFuncGetIndexWv(Xmin, True) To gFuncGetIndexWv(Xmax, True) Step +objChannel.Parameter.CalculatedSpeed
	//            'For lngDataCount = 0 To objChannel.Spectrums.item(0).Readings.Count - 2 Step +intSpeed
	//            '--- Check for the graph plotted on the screen

	//            dblToX = objChannel.Spectrums.item(0).Readings.item(lngDataCount).XaxisData
	//            dblToY = objChannel.Spectrums.item(0).Readings.item(lngDataCount).YaxisData

	//            '--- Check if the X-coordinates and Y-coordinates are less than
	//            '--- Xmin and Ymin
	//            If objChannel.Spectrums.item(0).Readings.item(lngDataCount).YaxisData < Ymin Then
	//                dblToY = Ymin
	//            End If

	//            If objChannel.Spectrums.item(0).Readings.item(lngDataCount).YaxisData > Ymax Then
	//                dblToY = Ymax
	//            End If

	//            '--- Check if the wavelength is equal to the min wv as loop starts from min
	//            If objChannel.Spectrums.item(0).Readings.item(lngDataCount).XaxisData = Xmin Then
	//                AxSpectrumGraph.PlotPoint(dblToX, dblToY, dblToX, dblToY, gSetColor(mintChannelIndex))
	//            Else
	//                AxSpectrumGraph.PlotPoint(dblFromX, dblFromY, dblToX, dblToY, gSetColor(mintChannelIndex))
	//            End If

	//            '--- Check if the X-coordinates and Y-coordinates are less than
	//            '--- Xmin and Ymin
	//            If dblToY < Ymin Then
	//                dblToY = Ymin
	//            End If

	//            If objChannel.Spectrums.item(0).Readings.item(lngDataCount).YaxisData > Ymax Then
	//                dblToY = Ymax
	//            End If

	//            dblFromX = dblToX
	//            dblFromY = dblToY

	//        Next

	//        AxSpectrumGraph.Refresh()
	//        Return True

	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        'Error Handling and logging
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = ex.Message
	//        gobjErrorHandler.WriteErrorLog(ex)
	//        gobjErrorHandler.ProcessError(ErrorHandler.EnumErrorType.Critical, ex)
	//        '---------------------------------------------------------
	//        Return False
	//    Finally
	//        '---------------------------------------------------------
	//        'Writing Execution log
	//        If CONST_CREATE_EXECUTION_LOG = 1 Then
	//            gobjErrorHandler.WriteExecutionLog()
	//        End If
	//        '---------------------------------------------------------
	//    End Try



	//End Function

	private bool funcDisplayGraph_RealTime(double dblXAxis, double dblYAxis)
	{
		//=====================================================================
		// Procedure Name        :   funcDisplayGraph_RealTime
		// Description           :   Plot the graph on the screen.
		// Purpose               :   To plot the graph on the screen for the given
		//                           Wavelength and absorbtion.           
		// Parameters Passed     :   dblXAxis , dblYAxis 
		// Returns               :   True, if successful.
		// Parameters Affected   :   
		// Assumptions           :   Graph pre-requisites are already been set.
		// Dependencies          :   None.
		// Author                :   Sachin Dokhale
		// Created               :   08.12.06
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
			dblYAxis = gfuncGetValueInSpectrum(dblToY, gobjInst.Mode);

			//lblWvPos.Text = Format(dblToX, "#0.0")
			//lblYValue.Text = Format(dblYAxis, "#0.000")   'Format(mobjTemporaryReadings.item(mobjTemporaryReadings.Count - 1).YaxisData, "#0.0")

			lblWvPos.Text = mXValueLable + Format(dblToX, "#0.0");
			lblYValue.Text = mYValueLable + ": " + Format(dblYAxis, "#0.000");
			lblWvPos.Refresh();
			lblYValue.Refresh();

			//If dblYAxis < mobjParameters.YaxisMin Then
			//    dblYAxis = mobjParameters.YaxisMin
			//End If

			//If dblYAxis > mobjParameters.YaxisMax Then
			//    dblYAxis = mobjParameters.YaxisMax
			//End If

			// mobjChannnels(mintChannelIndex).Spectrums(0).Readings(0).XaxisData = dblToX
			// mobjChannnels(mintChannelIndex).Spectrums(0).Readings(0).YaxisData = dblToY

			//--- Check if the wavelength is equal to the max wv

			if (dblXAxis == mobjParameters.XaxisMin) {
				//mGraphCurveItem = AASEnergySpectrum.StartOnlineGraph("Energy Spectrum", AASEnergySpectrum.GetColor(500), AldysGraph.SymbolType.NoSymbol)

				//ArrlstGraphCurveItem.Add(mGraphCurveItem)
				//intCurveIndex += 1
				//ArrlstGraphCurveItem.Item(intCurveIndex) = AASGraphUVSpectrum.StartOnlineGraph("Energy Spectrum", Color.Red, AldysGraph.SymbolType.NoSymbol)
				mGraphCurveItem = null;
				intCurveIndex += 1;

				if (gblnBaseLine == true) {
					mGraphCurveItem = AASGraphUVSpectrum.StartOnlineGraph("", AASGraphUVSpectrum.GetColor(intCurveIndex), AldysGraph.SymbolType.NoSymbol);
				} else {
					//mGraphCurveItem = AASGraphUVSpectrum.StartOnlineGraph(AASGraphUVSpectrum.YAxisLabel & " " & (intCurveIndex + 1).ToString, AASGraphUVSpectrum.GetColor(intCurveIndex), AldysGraph.SymbolType.NoSymbol)
					mGraphCurveItem = AASGraphUVSpectrum.StartOnlineGraph(const_GraphLedgend, AASGraphUVSpectrum.GetColor(intCurveIndex), AldysGraph.SymbolType.NoSymbol);
				}

				ArrlstGraphCurveItem.Add(mGraphCurveItem);
				AASGraphUVSpectrum.PlotPoint(ArrlstGraphCurveItem.Item(intCurveIndex), dblXAxis, dblYAxis);

				//AASEnergySpectrum.AldysPane.AxisChange()
				AASGraphUVSpectrum.Refresh();
			//Application.DoEvents()
			} else {
				//AxEnergySpectrum.PlotPoint(mdblXaxis, mdblYaxis, dblToX, dblToY, gSetColor(mintColor))
				//AASEnergySpectrum.PlotPoint(mGraphCurveItem, dblXAxis, (dblYAxis / 10))
				AASGraphUVSpectrum.PlotPoint(ArrlstGraphCurveItem.Item(intCurveIndex), dblXAxis, dblYAxis);
				AASGraphUVSpectrum.AldysPane.AxisChange();
				AASGraphUVSpectrum.Refresh();
				//Application.DoEvents()
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

	internal bool funcDisplayGraph(Spectrum.Channel objChannel, ref object objCurveItem = null)
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
					dblFromX = objChannel.UVParameter.XaxisMax;
					dblFromY = objChannel.UVParameter.YaxisMin;

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
						dblToY = gfuncGetValueInSpectrum(dblToY, gobjInst.Mode);
						//--- Check if the X-coordinates and Y-coordinates are less than
						//--- Xmin and Ymin
						//If dblToY < objChannel.UVParameter.YaxisMin Then
						//    dblToY = objChannel.UVParameter.YaxisMin()
						//End If

						//If dblToY > objChannel.UVParameter.YaxisMax Then
						//    dblToY = objChannel.UVParameter.YaxisMax
						//End If
						dtRow = dtPlotValue.NewRow;

						dtRow(0) = dblToX;
						dtRow(1) = dblToY;
						dtPlotValue.Rows.Add(dtRow);

						//--- Check if the wavelength is equal to the min wv
						//If objChannel.Spectrums.item(0).Readings.item(lngDataCount).XaxisData = objChannel.Parameter.WavelengthMax _
						//Or objChannel.Spectrums.item(0).Readings.item(lngDataCount).XaxisData = objChannel.Parameter.WavelengthMin Then
						//If objChannel.Spectrums.item(0).Readings.item(lngDataCount).XaxisData = objChannel.Parameter.WavelengthMin Then
						//    AxSpectrumGraph.PlotPoint(dblToX, dblToY, dblToX, dblToY, gSetColor(mintChannelIndex))
						//Else
						//    AxSpectrumGraph.PlotPoint(dblFromX, dblFromY, dblToX, dblToY, gSetColor(mintChannelIndex))
						//End If

						//--- Check if the X-coordinates and Y-coordinates are less than
						//--- Xmin and Ymin
						//If dblToY < objChannel.Parameter.YaxisMin Then
						//    dblToY = objChannel.Parameter.YaxisMin
						//End If

						//If objChannel.Spectrums.item(0).Readings.item(lngDataCount).YaxisData > objChannel.Parameter.YaxisMax Then
						//    dblToY = objChannel.Parameter.YaxisMax
						//End If

					}

					dtRow = dtPlotValue.NewRow;

					dtRow(0) = dblToX;
					dtRow(1) = dblToY;
					dtPlotValue.Rows.Add(dtRow);

					AASGraphUVSpectrum.GraphDataSource = dtPlotValue;
					objCurveItem = AASGraphUVSpectrum.PlotGraph();
					if (!AASGraphUVSpectrum.OfflineCurve == null) {
						AASGraphUVSpectrum.OfflineCurve.Label = const_GraphLedgend;
					}

					//mGraphCurveItem = AASEnergySpectrum.PlotGraph()
					AASGraphUVSpectrum.Refresh();
					Application.DoEvents();
				}
			}
			Application.DoEvents();
			AASGraphUVSpectrum.Refresh();
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
		string strSelectedBeam;
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
					dblFromX = objChannel.UVParameter.XaxisMin;
					dblFromY = objChannel.UVParameter.YaxisMin;

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
						strSelectedBeam = const_GraphLedgend;
						//"Sample"
					} else if (objChannel.InstrumentBeamType == AAS203Library.Instrument.enumInstrumentBeamType.ReferenceBeam) {
						strSelectedBeam = const_GraphLedgend;
						//"Reference"
					} else {
						strSelectedBeam = const_GraphLedgend;
						//"Double"
					}
					////----- Start Online graph plotting
					objCurveItem = AASGraphUVSpectrum.StartOnlineGraph(mstrSelectedBeamType + " " + AASGraphUVSpectrum.YAxisLabel + " " + (intCurveIndex + 1).ToString, AASGraphUVSpectrum.GetColor(intCurveIndex), AldysGraph.SymbolType.NoSymbol);
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
						AASGraphUVSpectrum.PlotPoint(objCurveItem, dblToX, dblToY, true);
						//--- Check if the wavelength is equal to the min wv
					}
					//If ArrlstGraphCurveItem.Count >= intCurveIndex + 1 Then
					AASGraphUVSpectrum.StopOnlineGraph(objCurveItem);
					//End If
					//AASEnergySpectrum.GraphDataSource = dtPlotValue
					//objCurveItem = AASEnergySpectrum.PlotGraph()
					AASGraphUVSpectrum.Refresh();
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
			ArrlstGraphCurveItem.Clear();
			AASGraphUVSpectrum.AldysPane.CurveList.Clear();
			AASGraphUVSpectrum.Refresh();
			intCurveIndex = -1;
			Application.DoEvents();


			//Call AASGraphUVSpectrum.PlotGraph()

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

	#Region " Graph Options "

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
			this.AASGraphUVSpectrum.IsShowGrid = mnuGrid.Checked;

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
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
			this.AASGraphUVSpectrum.submnuPeakEdit_Click(sender, e);


		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
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
			this.AASGraphUVSpectrum.ShowXYValues = mnuShowXYValues.Checked;
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
			this.AASGraphUVSpectrum.AldysPane.Legend.IsVisible = mnuLegends.Checked;
			AASGraphUVSpectrum.Invalidate();
			AASGraphUVSpectrum.Refresh();
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
AASGraphUVSpectrum_GraphOptionChanged()
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
			if (AASGraphUVSpectrum.IsShowGrid == true) {
				mnuGrid.Checked = true;
			} else {
				mnuGrid.Checked = false;
			}
			mnuGrid.Click += mnuGrid_Click;

			////----- Check Legends on Graph
			mnuLegends.Click -= mnuLegends_Click;
			if (AASGraphUVSpectrum.AldysPane.Legend.IsVisible == true) {
				mnuLegends.Checked = true;
			} else {
				mnuLegends.Checked = false;
			}
			mnuLegends.Click += mnuLegends_Click;

			////----- Check Show XY Values on Graph
			mnuShowXYValues.Click -= mnuShowXYValues_Click;
			if (AASGraphUVSpectrum.ShowXYValues == true) {
				mnuShowXYValues.Checked = true;
			} else {
				mnuShowXYValues.Checked = false;
			}
			mnuShowXYValues.Click += mnuShowXYValues_Click;

			mnuPeakEdit.Click -= mnuPeakEdit_Click;
			if (AASGraphUVSpectrum.ShowXYPeak == true) {
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

	//Private Sub btnIgnite_Click(ByVal sender As Object, ByVal e As System.EventArgs)
	//    Try
	//        RemoveHandler btnIgnite.Click, AddressOf btnIgnite_Click
	//        If mblnAvoidProcessing = True Then
	//            Exit Sub
	//        End If
	//        mblnAvoidProcessing = True
	//        gobjClsAAS203.funcIgnite(True)

	//        Call funcGetInstParameter()

	//        mblnAvoidProcessing = False
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
	//        AddHandler btnIgnite.Click, AddressOf btnIgnite_Click
	//        'objWait.Dispose()
	//        '---------------------------------------------------------
	//    End Try

	//End Sub

	//Private Sub btnExtinguish_Click(ByVal sender As Object, ByVal e As System.EventArgs)
	//    Try
	//        RemoveHandler btnExtinguish.Click, AddressOf btnExtinguish_Click
	//        If mblnAvoidProcessing = True Then
	//            Exit Sub
	//        End If
	//        mblnAvoidProcessing = True

	//        gobjClsAAS203.funcIgnite(False)
	//        Call funcGetInstParameter()


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
	//        AddHandler btnExtinguish.Click, AddressOf btnExtinguish_Click
	//        'objWait.Dispose()
	//        '---------------------------------------------------------
	//    End Try

	//End Sub

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
			//If Not gstructSettings.AppMode = EnumAppMode.DemoMode Then

			if (!((gstructSettings.AppMode == EnumAppMode.DemoMode) | (gstructSettings.AppMode == EnumAppMode.DemoMode_201) | (gstructSettings.AppMode == EnumAppMode.DemoMode_203D))) {
				Application.DoEvents();
				gobjCommProtocol.mobjCommdll.subTime_Delay(50);
				gobjClsAAS203.funcInstReset();

			} else {
				//Call gobjMessageAdapter.ShowMessage("Alt - R", "Alt - R")
				Application.DoEvents();
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
					//Call btnIgnite_Click(sender, e)
					case Keys.C:
					//btnN2OIgnite_Click(sender, e)
					case Keys.E:
					//Call btnExtinguish_Click(sender, e)
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

	private void  // ERROR: Handles clauses are not supported in C#
frmUVScanningSpectrumDBMode_Activated(object sender, System.EventArgs e)
	{
		try {
			if (blnActivateStartUVSpectrum == false) {
				funcSetDefaultParameter();
				nudD2Cur.Visible = true;
				nudPMT.Visible = true;
				nudPMT_Ref.Visible = true;
				nudSlit.Visible = true;
				nudSlit_Ref.Visible = true;
				//nudHCLCur.Visible = True
				//nudBurnerHeight.Visible = True
				//nudFuelRatio.Visible = True
				blnActivateStartUVSpectrum = true;
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

}
