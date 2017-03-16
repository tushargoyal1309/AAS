using System.Threading;
using AAS203.Common;
using BgThread;
using System.IO;
using Microsoft.VisualBasic;
using AAS203.Spectrum;

public class frmTimeScanMode : System.Windows.Forms.Form, Iclient
{

	#Region " Private Variable "

	//'this are the private variable which used in time scan mode

	//--- Declaration for the controller object of the BgThread
	private BgThread.clsBgThread mobjController = new BgThread.clsBgThread(this);
	private clsBgSpectrum mobjclsBgSpectrum = new clsBgSpectrum();
	//'this is object of clsBgSpectrum(thread class)

	//Public WithEvents Status As System.Windows.Forms.TextBox

	public System.Windows.Forms.TextBox Status;
	private double mdblFuelRatio = 0.0;

	private double mdblBhHeight = 0.0;
	private bool mblnSpectrumStarted;
	private bool mblnAvoidProcessing = false;
	private bool mblnAvoidFormProcessing = false;
	private bool mblnExitApplication = false;
	private frmEditValues mobjfrmEditValues;
	////----- Graph Items
	private double mdblYaxis;
	private double mdblXaxis;
	private AldysGraph.CurveItem mGraphCurveItem;
	private ArrayList ArrlstGraphCurveItem = new ArrayList();
	private int intCurveIndex;
	////-----
	private bool m_blnBaseline = true;
	private double InputValue;
	private struct _Data
	{
		//'this structure store some temp data about graph e.g
		//'mXaxisData  contain X point to be ploted
		bool mGraphPlot;
		int mXaxisData;
		int mYaxisData;
	}
	//Dim Data As _Data
	//--- declaration of the channels object (collection)
	//'this is a data structure 
	private Spectrum.Channels mobjChannnels = new Spectrum.Channels();
	private Spectrum.Channel mobjOnlineChannel = new Spectrum.Channel(true);
	private Spectrum.Readings mobjOnlineReadings = new Spectrum.Readings();
	private clsSpectrum mobjSpectrum = new clsSpectrum();
	//'clsSpectrum is a class for spectrum datastructure

	//--- declaration of the Parameter object used to populate the 
	//--- parameter screen on the spectrum screen
	private Spectrum.EnergySpectrumParameter mobjParameters = new Spectrum.EnergySpectrumParameter();
	//--- Current channel index
	private int mintChannelIndex;
	//----- Store the Peak and Valley

	private clsSpectrum.PeakValley[] mStuctPeaksValley = new clsSpectrum.PeakValley[99];
	private IO.Directory strPath;
	////----- TimeScan 
	private bool blnCheckMinAbsScanLmt = false;
	private double dblAbsScanthldval = 0.0;

	private double dblAbs;
	private long XaxisTime1;

	private bool blnPlotingNew = true;

	private string mYValueLable = const_Absorbance;
	//Private mXValueLable As String = "Timescan (Sc.): "

	private string mXValueLable = "Wavelength (nm): ";
	private string mstrYaxisFormat;

	private string mstrYaxisExt;
	private string mYAXIS_LABEL;
	bool blnActivateStartTimeScan;
	////-----

	#End Region

	#Region " Private Constants "

	private const  ConstFormLoad = "-Time Scan Mode";
	private const  const_WvMin = 0;
	private const  const_WvMax = 100.0;
	private const  const_YMinAbs = -0.2;
	private const  const_YMaxAbs = 1.2;
	//Private Const const_YMinAbs = -2.7
	//Private Const const_YMaxAbs = 2.7
	private const  const_YMinEnergy = 0.0;
	private const  const_YMaxEnergy = 100.0;
	//Private Const const_YMinEnergy = -110.0
	//Private Const const_YMaxEnergy = 110.0
	private const  const_YMinEmission = 0.0;
	private const  const_YMaxEmission = 100.0;
	//Private Const const_YMinEmission = -110.0
	//Private Const const_YMaxEmission = 110.0

	private const  const_YMinmVolt = -5000.0;
	//Private Const const_YMaxmVolt = 5000.0
	//Private Const const_YMinmVolt = 0.0

	private const  const_YMaxmVolt = 5000.0;
	private const  const_Absorbance = "Absorbance ";
	private const  const_Energy = "Energy ";
	private const  const_Emission = "Emission ";
	private const  const_Volt = "Volt (mv)";
	private const  const_ABSORBANCE_YLabel = "ABSORBANCE";
	private const  const_ENERGY_YLabel = "ENERGY";
	private const  const_EMISSION_YLabel = "EMISSION";

	private const  const_VOLT_YLabel = "VOLT(mV)";
	#End Region

	#Region " Windows Form Designer generated code "

	public frmTimeScanMode()
	{
		base.New();

		//This call is required by the Windows Form Designer.
		InitializeComponent();

		//Add any initialization after the InitializeComponent() call
		frmLoad();
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
	internal GradientPanel.CustomPanel CustomPanelBottom;
	internal NETXP.Controls.XPButton btnClearSpectrum;
	internal NETXP.Controls.XPButton btnLampParameters;
	internal NETXP.Controls.XPButton btnReturn;
	internal NETXP.Controls.Bars.StatusBar StatusBar1;
	internal System.Windows.Forms.StatusBarPanel StatusBarPanelInfo;
	internal NETXP.Controls.Bars.ProgressPanel ProgressPanel;
	internal System.Windows.Forms.StatusBarPanel StatusBarPanelDate;
	internal NETXP.Controls.XPButton cmdChangeScale;
	internal NETXP.Controls.XPButton cmdFilter;
	//Friend WithEvents AASGraphTimeScan As AAS203.AASGraph
	internal NETXP.Controls.XPButton btnAutoZero;
	internal NETXP.Controls.XPButton cmdADJFlow;
	internal NETXP.Controls.XPButton cmdADJBH;
	internal NETXP.Controls.XPButton cmdD2GainStatus;
	internal System.Windows.Forms.Label lblBurnerHeightmm;
	internal System.Windows.Forms.Label lblBurnerHeight;
	internal System.Windows.Forms.Label lblFuelRatio;
	internal System.Windows.Forms.Label lblHCLCurmA;
	internal System.Windows.Forms.Label lblHCLCur;
	internal System.Windows.Forms.Label lblSlitWidthnm;
	internal System.Windows.Forms.Label lblPMTVolts;
	internal System.Windows.Forms.Label lblD2CurmA;
	internal System.Windows.Forms.ComboBox cmbModes;
	internal System.Windows.Forms.Label lblModes;
	internal System.Windows.Forms.Label lblSlitWidth;
	internal System.Windows.Forms.Label lblD2Cur;
	internal System.Windows.Forms.Label lblPMT;
	internal GradientPanel.CustomPanel CustomPanelTop;
	internal AAS203.AASGraph AASGraphTimeScan;
	internal System.Windows.Forms.Label lblTime;
	internal System.Windows.Forms.Label lblWvPos;
	internal System.Windows.Forms.Label lblYValue;
	internal CodeIntellects.Office2003Controls.Office2003Header HeaderLeft;
	internal CodeIntellects.Office2003Controls.Office2003Header Office2003Header1;
	internal NETXP.Controls.Bars.CommandBar CommandBar1;
	internal NETXP.Controls.Bars.CommandBarButtonItem cmdbtnReturn;
	internal NETXP.Controls.Bars.CommandBarButtonItem cmdbtnAutoZero;
	internal NETXP.Controls.Bars.CommandBarButtonItem cmdbtnAdjFuelFlow;
	internal NETXP.Controls.Bars.CommandBarButtonItem cmdbtnAdjBurnerHt;
	internal NETXP.Controls.Bars.CommandBarButtonItem cmdbtnChangeScale;
	internal ValueEditor.ValueEditor nudPMT;
	internal ValueEditor.ValueEditor nudSlit;
	internal ValueEditor.ValueEditor nudHCLCur;
	internal ValueEditor.ValueEditor nudD2Cur;
	internal ValueEditor.ValueEditor nudFuelRatio;
	internal ValueEditor.ValueEditor nudBurnerHeight;
	internal NETXP.Controls.Bars.CommandBar MenuBarEnergySpectrumMode;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuFile;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuDataProcessing;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuReturn;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuAutoZero;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuAdjustFuel;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuAdjustBurnerHeight;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuGraphOptions;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuPeakEdit;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuGrid;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuLegends;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuShowXYValues;
	internal NETXP.Controls.XPButton btnExtinguish;
	internal NETXP.Controls.XPButton btnIgnite;
	internal NETXP.Controls.Bars.CommandBarSeparatorItem CommandBarSeparatorItem1;
	internal NETXP.Controls.Bars.CommandBarSeparatorItem CommandBarSeparatorItem2;
	internal NETXP.Controls.Bars.CommandBarButtonItem tlbbtnGrid;
	internal NETXP.Controls.Bars.CommandBarButtonItem tlbbtnLegends;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuChangeScale;
	internal NETXP.Controls.XPButton btnN2OIgnite;
	internal NETXP.Controls.XPButton btnDelete;
	internal NETXP.Controls.XPButton btnR;
	[System.Diagnostics.DebuggerStepThrough()]
	private void InitializeComponent()
	{
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmTimeScanMode));
		this.CustomPanelMain = new GradientPanel.CustomPanel();
		this.AASGraphTimeScan = new AAS203.AASGraph();
		this.Office2003Header1 = new CodeIntellects.Office2003Controls.Office2003Header();
		this.CustomPanelBottom = new GradientPanel.CustomPanel();
		this.btnAutoZero = new NETXP.Controls.XPButton();
		this.cmdADJFlow = new NETXP.Controls.XPButton();
		this.cmdADJBH = new NETXP.Controls.XPButton();
		this.cmdChangeScale = new NETXP.Controls.XPButton();
		this.btnLampParameters = new NETXP.Controls.XPButton();
		this.btnClearSpectrum = new NETXP.Controls.XPButton();
		this.btnReturn = new NETXP.Controls.XPButton();
		this.btnN2OIgnite = new NETXP.Controls.XPButton();
		this.cmdFilter = new NETXP.Controls.XPButton();
		this.CustomPanelTop = new GradientPanel.CustomPanel();
		this.nudBurnerHeight = new ValueEditor.ValueEditor();
		this.nudFuelRatio = new ValueEditor.ValueEditor();
		this.nudD2Cur = new ValueEditor.ValueEditor();
		this.nudHCLCur = new ValueEditor.ValueEditor();
		this.nudSlit = new ValueEditor.ValueEditor();
		this.nudPMT = new ValueEditor.ValueEditor();
		this.HeaderLeft = new CodeIntellects.Office2003Controls.Office2003Header();
		this.lblYValue = new System.Windows.Forms.Label();
		this.lblWvPos = new System.Windows.Forms.Label();
		this.lblTime = new System.Windows.Forms.Label();
		this.cmdD2GainStatus = new NETXP.Controls.XPButton();
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
		this.lblSlitWidth = new System.Windows.Forms.Label();
		this.lblD2Cur = new System.Windows.Forms.Label();
		this.lblPMT = new System.Windows.Forms.Label();
		this.btnExtinguish = new NETXP.Controls.XPButton();
		this.btnIgnite = new NETXP.Controls.XPButton();
		this.btnDelete = new NETXP.Controls.XPButton();
		this.btnR = new NETXP.Controls.XPButton();
		this.StatusBar1 = new NETXP.Controls.Bars.StatusBar();
		this.StatusBarPanelInfo = new System.Windows.Forms.StatusBarPanel();
		this.ProgressPanel = new NETXP.Controls.Bars.ProgressPanel();
		this.StatusBarPanelDate = new System.Windows.Forms.StatusBarPanel();
		this.CommandBar1 = new NETXP.Controls.Bars.CommandBar();
		this.cmdbtnReturn = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.CommandBarSeparatorItem1 = new NETXP.Controls.Bars.CommandBarSeparatorItem();
		this.cmdbtnAutoZero = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.cmdbtnAdjFuelFlow = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.cmdbtnAdjBurnerHt = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.cmdbtnChangeScale = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.CommandBarSeparatorItem2 = new NETXP.Controls.Bars.CommandBarSeparatorItem();
		this.tlbbtnGrid = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.tlbbtnLegends = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.MenuBarEnergySpectrumMode = new NETXP.Controls.Bars.CommandBar();
		this.mnuFile = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuReturn = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuDataProcessing = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuAutoZero = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuAdjustFuel = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuAdjustBurnerHeight = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuGraphOptions = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuPeakEdit = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuGrid = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuLegends = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuShowXYValues = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuChangeScale = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.CustomPanelMain.SuspendLayout();
		this.CustomPanelBottom.SuspendLayout();
		this.CustomPanelTop.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.StatusBarPanelInfo).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.ProgressPanel).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.StatusBarPanelDate).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.CommandBar1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.MenuBarEnergySpectrumMode).BeginInit();
		this.SuspendLayout();
		//
		//CustomPanelMain
		//
		this.CustomPanelMain.BackColor = System.Drawing.Color.AliceBlue;
		this.CustomPanelMain.Controls.Add(this.AASGraphTimeScan);
		this.CustomPanelMain.Controls.Add(this.Office2003Header1);
		this.CustomPanelMain.Controls.Add(this.CustomPanelBottom);
		this.CustomPanelMain.Controls.Add(this.CustomPanelTop);
		this.CustomPanelMain.Controls.Add(this.btnExtinguish);
		this.CustomPanelMain.Controls.Add(this.btnIgnite);
		this.CustomPanelMain.Controls.Add(this.btnDelete);
		this.CustomPanelMain.Controls.Add(this.btnR);
		this.CustomPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
		this.CustomPanelMain.Location = new System.Drawing.Point(0, 58);
		this.CustomPanelMain.Name = "CustomPanelMain";
		this.CustomPanelMain.Size = new System.Drawing.Size(804, 430);
		this.CustomPanelMain.TabIndex = 3;
		//
		//AASGraphTimeScan
		//
		this.AASGraphTimeScan.AldysGraphCursor = null;
		this.AASGraphTimeScan.AldysGraphPrintColor = System.Drawing.Color.Black;
		this.AASGraphTimeScan.BackColor = System.Drawing.Color.LightGray;
		this.AASGraphTimeScan.Dock = System.Windows.Forms.DockStyle.Fill;
		this.AASGraphTimeScan.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.AASGraphTimeScan.GraphDataSource = null;
		this.AASGraphTimeScan.GraphImage = null;
		this.AASGraphTimeScan.IsShowGrid = true;
		this.AASGraphTimeScan.Location = new System.Drawing.Point(184, 22);
		this.AASGraphTimeScan.Name = "AASGraphTimeScan";
		this.AASGraphTimeScan.Size = new System.Drawing.Size(620, 341);
		this.AASGraphTimeScan.TabIndex = 25;
		this.AASGraphTimeScan.UseDefaultSettings = true;
		this.AASGraphTimeScan.XAxisDateMax = new System.DateTime((long)0);
		this.AASGraphTimeScan.XAxisDateMin = new System.DateTime((long)0);
		this.AASGraphTimeScan.XAxisDateScaleFormat = AAS203.AASGraph.enumDateScaleFormat.YYYY;
		this.AASGraphTimeScan.XAxisLabel = "X Values";
		this.AASGraphTimeScan.XAxisMax = 100;
		this.AASGraphTimeScan.XAxisMin = 0;
		this.AASGraphTimeScan.XAxisMinorStep = 5;
		this.AASGraphTimeScan.XAxisScaleFormat = null;
		this.AASGraphTimeScan.XAxisStep = 10;
		this.AASGraphTimeScan.XAxisType = AldysGraph.AxisType.Linear;
		this.AASGraphTimeScan.YAxisLabel = "Y Values";
		this.AASGraphTimeScan.YAxisMax = 100;
		this.AASGraphTimeScan.YAxisMin = -1;
		this.AASGraphTimeScan.YAxisMinorStep = 5;
		this.AASGraphTimeScan.YAxisScaleFormat = null;
		this.AASGraphTimeScan.YAxisStep = 10;
		this.AASGraphTimeScan.YAxisType = AldysGraph.AxisType.Linear;
		//
		//Office2003Header1
		//
		this.Office2003Header1.BackColor = System.Drawing.SystemColors.Control;
		this.Office2003Header1.Dock = System.Windows.Forms.DockStyle.Top;
		this.Office2003Header1.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.Office2003Header1.Location = new System.Drawing.Point(184, 0);
		this.Office2003Header1.Name = "Office2003Header1";
		this.Office2003Header1.Size = new System.Drawing.Size(620, 22);
		this.Office2003Header1.TabIndex = 48;
		this.Office2003Header1.TitleFont = new System.Drawing.Font("Tahoma", 10f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.Office2003Header1.TitleText = "Time Scan";
		//
		//CustomPanelBottom
		//
		this.CustomPanelBottom.BackColor = System.Drawing.Color.AliceBlue;
		this.CustomPanelBottom.Controls.Add(this.btnAutoZero);
		this.CustomPanelBottom.Controls.Add(this.cmdADJFlow);
		this.CustomPanelBottom.Controls.Add(this.cmdADJBH);
		this.CustomPanelBottom.Controls.Add(this.cmdChangeScale);
		this.CustomPanelBottom.Controls.Add(this.btnLampParameters);
		this.CustomPanelBottom.Controls.Add(this.btnClearSpectrum);
		this.CustomPanelBottom.Controls.Add(this.btnReturn);
		this.CustomPanelBottom.Controls.Add(this.btnN2OIgnite);
		this.CustomPanelBottom.Controls.Add(this.cmdFilter);
		this.CustomPanelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
		this.CustomPanelBottom.Location = new System.Drawing.Point(184, 363);
		this.CustomPanelBottom.Name = "CustomPanelBottom";
		this.CustomPanelBottom.Size = new System.Drawing.Size(620, 67);
		this.CustomPanelBottom.TabIndex = 1;
		//
		//btnAutoZero
		//
		this.btnAutoZero.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnAutoZero.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnAutoZero.Image = (System.Drawing.Image)resources.GetObject("btnAutoZero.Image");
		this.btnAutoZero.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnAutoZero.Location = new System.Drawing.Point(8, 12);
		this.btnAutoZero.Name = "btnAutoZero";
		this.btnAutoZero.Size = new System.Drawing.Size(110, 35);
		this.btnAutoZero.TabIndex = 0;
		this.btnAutoZero.Text = "Auto&Zero";
		this.btnAutoZero.Visible = false;
		//
		//cmdADJFlow
		//
		this.cmdADJFlow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.cmdADJFlow.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.cmdADJFlow.Image = (System.Drawing.Image)resources.GetObject("cmdADJFlow.Image");
		this.cmdADJFlow.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.cmdADJFlow.Location = new System.Drawing.Point(120, 12);
		this.cmdADJFlow.Name = "cmdADJFlow";
		this.cmdADJFlow.Size = new System.Drawing.Size(110, 36);
		this.cmdADJFlow.TabIndex = 1;
		this.cmdADJFlow.Text = "Adjust &Fuel Flow";
		this.cmdADJFlow.TextAlign = System.Drawing.ContentAlignment.TopLeft;
		this.cmdADJFlow.Visible = false;
		//
		//cmdADJBH
		//
		this.cmdADJBH.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.cmdADJBH.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.cmdADJBH.Image = (System.Drawing.Image)resources.GetObject("cmdADJBH.Image");
		this.cmdADJBH.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.cmdADJBH.Location = new System.Drawing.Point(232, 12);
		this.cmdADJBH.Name = "cmdADJBH";
		this.cmdADJBH.Size = new System.Drawing.Size(110, 38);
		this.cmdADJBH.TabIndex = 2;
		this.cmdADJBH.Text = "Adjust &Burner Ht.";
		this.cmdADJBH.TextAlign = System.Drawing.ContentAlignment.TopLeft;
		this.cmdADJBH.Visible = false;
		//
		//cmdChangeScale
		//
		this.cmdChangeScale.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.cmdChangeScale.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.cmdChangeScale.Image = (System.Drawing.Image)resources.GetObject("cmdChangeScale.Image");
		this.cmdChangeScale.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.cmdChangeScale.Location = new System.Drawing.Point(344, 12);
		this.cmdChangeScale.Name = "cmdChangeScale";
		this.cmdChangeScale.Size = new System.Drawing.Size(110, 38);
		this.cmdChangeScale.TabIndex = 3;
		this.cmdChangeScale.Text = "Chan&ge Scale";
		this.cmdChangeScale.TextAlign = System.Drawing.ContentAlignment.TopLeft;
		this.cmdChangeScale.Visible = false;
		//
		//btnLampParameters
		//
		this.btnLampParameters.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnLampParameters.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnLampParameters.Location = new System.Drawing.Point(410, 72);
		this.btnLampParameters.Name = "btnLampParameters";
		this.btnLampParameters.Size = new System.Drawing.Size(106, 30);
		this.btnLampParameters.TabIndex = 9;
		this.btnLampParameters.Text = "&Lamp Parameters";
		this.btnLampParameters.Visible = false;
		//
		//btnClearSpectrum
		//
		this.btnClearSpectrum.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnClearSpectrum.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnClearSpectrum.Location = new System.Drawing.Point(352, 78);
		this.btnClearSpectrum.Name = "btnClearSpectrum";
		this.btnClearSpectrum.Size = new System.Drawing.Size(106, 30);
		this.btnClearSpectrum.TabIndex = 10;
		this.btnClearSpectrum.Text = "C&lear Spectrum";
		this.btnClearSpectrum.Visible = false;
		//
		//btnReturn
		//
		this.btnReturn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.btnReturn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnReturn.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnReturn.Image = (System.Drawing.Image)resources.GetObject("btnReturn.Image");
		this.btnReturn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnReturn.Location = new System.Drawing.Point(456, 12);
		this.btnReturn.Name = "btnReturn";
		this.btnReturn.Size = new System.Drawing.Size(110, 38);
		this.btnReturn.TabIndex = 4;
		this.btnReturn.Text = "Return";
		this.btnReturn.Visible = false;
		//
		//btnN2OIgnite
		//
		this.btnN2OIgnite.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left;
		this.btnN2OIgnite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnN2OIgnite.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnN2OIgnite.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnN2OIgnite.Location = new System.Drawing.Point(100, 40);
		this.btnN2OIgnite.Name = "btnN2OIgnite";
		this.btnN2OIgnite.Size = new System.Drawing.Size(5, 5);
		this.btnN2OIgnite.TabIndex = 136;
		this.btnN2OIgnite.TabStop = false;
		this.btnN2OIgnite.Text = "N2O&C";
		this.btnN2OIgnite.TextAlign = System.Drawing.ContentAlignment.TopLeft;
		//
		//cmdFilter
		//
		this.cmdFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.cmdFilter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.cmdFilter.Location = new System.Drawing.Point(568, 12);
		this.cmdFilter.Name = "cmdFilter";
		this.cmdFilter.Size = new System.Drawing.Size(38, 38);
		this.cmdFilter.TabIndex = 15;
		this.cmdFilter.Text = "&Filter";
		//
		//CustomPanelTop
		//
		this.CustomPanelTop.BackColor = System.Drawing.Color.AliceBlue;
		this.CustomPanelTop.Controls.Add(this.nudBurnerHeight);
		this.CustomPanelTop.Controls.Add(this.nudFuelRatio);
		this.CustomPanelTop.Controls.Add(this.nudD2Cur);
		this.CustomPanelTop.Controls.Add(this.nudHCLCur);
		this.CustomPanelTop.Controls.Add(this.nudSlit);
		this.CustomPanelTop.Controls.Add(this.nudPMT);
		this.CustomPanelTop.Controls.Add(this.HeaderLeft);
		this.CustomPanelTop.Controls.Add(this.lblYValue);
		this.CustomPanelTop.Controls.Add(this.lblWvPos);
		this.CustomPanelTop.Controls.Add(this.lblTime);
		this.CustomPanelTop.Controls.Add(this.cmdD2GainStatus);
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
		this.CustomPanelTop.Controls.Add(this.lblSlitWidth);
		this.CustomPanelTop.Controls.Add(this.lblD2Cur);
		this.CustomPanelTop.Controls.Add(this.lblPMT);
		this.CustomPanelTop.Dock = System.Windows.Forms.DockStyle.Left;
		this.CustomPanelTop.Location = new System.Drawing.Point(0, 0);
		this.CustomPanelTop.Name = "CustomPanelTop";
		this.CustomPanelTop.Size = new System.Drawing.Size(184, 430);
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
		this.nudBurnerHeight.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.nudBurnerHeight.ForeColor = System.Drawing.SystemColors.ControlText;
		this.nudBurnerHeight.ForegroundColor = System.Drawing.SystemColors.ControlText;
		this.nudBurnerHeight.IsReverseOperation = false;
		this.nudBurnerHeight.IsUpDownButtonToBeDisabledOnValueChange = false;
		this.nudBurnerHeight.Location = new System.Drawing.Point(75, 204);
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
		//nudFuelRatio
		//
		this.nudFuelRatio.BackColor = System.Drawing.SystemColors.Window;
		this.nudFuelRatio.BackgroundColor = System.Drawing.SystemColors.Window;
		this.nudFuelRatio.ButtonClicked = ValueEditor.ValueEditor.EnumValueEditorButtons.MainButton;
		this.nudFuelRatio.ChangeFactor = 0;
		this.nudFuelRatio.DecimalPlace = 0;
		this.nudFuelRatio.DnButtonText = "6";
		this.nudFuelRatio.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.nudFuelRatio.ForeColor = System.Drawing.SystemColors.ControlText;
		this.nudFuelRatio.ForegroundColor = System.Drawing.SystemColors.ControlText;
		this.nudFuelRatio.IsReverseOperation = false;
		this.nudFuelRatio.IsUpDownButtonToBeDisabledOnValueChange = false;
		this.nudFuelRatio.Location = new System.Drawing.Point(75, 171);
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
		//nudD2Cur
		//
		this.nudD2Cur.BackColor = System.Drawing.SystemColors.Window;
		this.nudD2Cur.BackgroundColor = System.Drawing.SystemColors.Window;
		this.nudD2Cur.ButtonClicked = ValueEditor.ValueEditor.EnumValueEditorButtons.MainButton;
		this.nudD2Cur.ChangeFactor = 0;
		this.nudD2Cur.DecimalPlace = 0;
		this.nudD2Cur.DnButtonText = "6";
		this.nudD2Cur.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.nudD2Cur.ForeColor = System.Drawing.SystemColors.ControlText;
		this.nudD2Cur.ForegroundColor = System.Drawing.SystemColors.ControlText;
		this.nudD2Cur.IsReverseOperation = false;
		this.nudD2Cur.IsUpDownButtonToBeDisabledOnValueChange = false;
		this.nudD2Cur.Location = new System.Drawing.Point(75, 105);
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
		//nudHCLCur
		//
		this.nudHCLCur.BackColor = System.Drawing.SystemColors.Window;
		this.nudHCLCur.BackgroundColor = System.Drawing.SystemColors.Window;
		this.nudHCLCur.ButtonClicked = ValueEditor.ValueEditor.EnumValueEditorButtons.MainButton;
		this.nudHCLCur.ChangeFactor = 0;
		this.nudHCLCur.DecimalPlace = 0;
		this.nudHCLCur.DnButtonText = "6";
		this.nudHCLCur.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.nudHCLCur.ForeColor = System.Drawing.SystemColors.ControlText;
		this.nudHCLCur.ForegroundColor = System.Drawing.SystemColors.ControlText;
		this.nudHCLCur.IsReverseOperation = false;
		this.nudHCLCur.IsUpDownButtonToBeDisabledOnValueChange = false;
		this.nudHCLCur.Location = new System.Drawing.Point(75, 72);
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
		//nudSlit
		//
		this.nudSlit.BackColor = System.Drawing.SystemColors.Window;
		this.nudSlit.BackgroundColor = System.Drawing.SystemColors.Window;
		this.nudSlit.ButtonClicked = ValueEditor.ValueEditor.EnumValueEditorButtons.MainButton;
		this.nudSlit.ChangeFactor = 0;
		this.nudSlit.DecimalPlace = 0;
		this.nudSlit.DnButtonText = "6";
		this.nudSlit.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.nudSlit.ForeColor = System.Drawing.SystemColors.ControlText;
		this.nudSlit.ForegroundColor = System.Drawing.SystemColors.ControlText;
		this.nudSlit.IsReverseOperation = false;
		this.nudSlit.IsUpDownButtonToBeDisabledOnValueChange = false;
		this.nudSlit.Location = new System.Drawing.Point(75, 138);
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
		this.nudPMT.Location = new System.Drawing.Point(75, 39);
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
		this.HeaderLeft.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.HeaderLeft.Location = new System.Drawing.Point(0, 0);
		this.HeaderLeft.Name = "HeaderLeft";
		this.HeaderLeft.Size = new System.Drawing.Size(184, 22);
		this.HeaderLeft.TabIndex = 47;
		this.HeaderLeft.TitleFont = new System.Drawing.Font("Tahoma", 10f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.HeaderLeft.TitleText = "Parameters";
		//
		//lblYValue
		//
		this.lblYValue.BackColor = System.Drawing.Color.White;
		this.lblYValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblYValue.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblYValue.ForeColor = System.Drawing.Color.Blue;
		this.lblYValue.Location = new System.Drawing.Point(12, 366);
		this.lblYValue.Name = "lblYValue";
		this.lblYValue.Size = new System.Drawing.Size(166, 20);
		this.lblYValue.TabIndex = 43;
		//
		//lblWvPos
		//
		this.lblWvPos.BackColor = System.Drawing.Color.White;
		this.lblWvPos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblWvPos.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblWvPos.ForeColor = System.Drawing.Color.Blue;
		this.lblWvPos.Location = new System.Drawing.Point(12, 338);
		this.lblWvPos.Name = "lblWvPos";
		this.lblWvPos.Size = new System.Drawing.Size(166, 20);
		this.lblWvPos.TabIndex = 42;
		this.lblWvPos.Text = "Wavelength (nm) :";
		this.lblWvPos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//lblTime
		//
		this.lblTime.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right;
		this.lblTime.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblTime.Location = new System.Drawing.Point(12, 314);
		this.lblTime.Name = "lblTime";
		this.lblTime.Size = new System.Drawing.Size(166, 16);
		this.lblTime.TabIndex = 39;
		this.lblTime.Text = "Time (Sec.)";
		this.lblTime.Visible = false;
		//
		//cmdD2GainStatus
		//
		this.cmdD2GainStatus.BackColor = System.Drawing.Color.Transparent;
		this.cmdD2GainStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.cmdD2GainStatus.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.cmdD2GainStatus.Location = new System.Drawing.Point(20, 267);
		this.cmdD2GainStatus.Name = "cmdD2GainStatus";
		this.cmdD2GainStatus.Size = new System.Drawing.Size(106, 30);
		this.cmdD2GainStatus.TabIndex = 38;
		this.cmdD2GainStatus.Text = "D2 &Gain Status";
		this.cmdD2GainStatus.Visible = false;
		//
		//lblBurnerHeightmm
		//
		this.lblBurnerHeightmm.BackColor = System.Drawing.Color.Transparent;
		this.lblBurnerHeightmm.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblBurnerHeightmm.Location = new System.Drawing.Point(149, 208);
		this.lblBurnerHeightmm.Name = "lblBurnerHeightmm";
		this.lblBurnerHeightmm.Size = new System.Drawing.Size(24, 20);
		this.lblBurnerHeightmm.TabIndex = 36;
		this.lblBurnerHeightmm.Text = "mm";
		this.lblBurnerHeightmm.Visible = false;
		//
		//lblBurnerHeight
		//
		this.lblBurnerHeight.BackColor = System.Drawing.Color.Transparent;
		this.lblBurnerHeight.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblBurnerHeight.Location = new System.Drawing.Point(7, 201);
		this.lblBurnerHeight.Name = "lblBurnerHeight";
		this.lblBurnerHeight.Size = new System.Drawing.Size(65, 28);
		this.lblBurnerHeight.TabIndex = 34;
		this.lblBurnerHeight.Text = "Burner Ht.";
		this.lblBurnerHeight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.lblBurnerHeight.Visible = false;
		//
		//lblFuelRatio
		//
		this.lblFuelRatio.BackColor = System.Drawing.Color.Transparent;
		this.lblFuelRatio.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblFuelRatio.Location = new System.Drawing.Point(7, 167);
		this.lblFuelRatio.Name = "lblFuelRatio";
		this.lblFuelRatio.Size = new System.Drawing.Size(63, 28);
		this.lblFuelRatio.TabIndex = 32;
		this.lblFuelRatio.Text = "Fuel Ratio";
		this.lblFuelRatio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.lblFuelRatio.Visible = false;
		//
		//lblHCLCurmA
		//
		this.lblHCLCurmA.BackColor = System.Drawing.Color.Transparent;
		this.lblHCLCurmA.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblHCLCurmA.Location = new System.Drawing.Point(149, 74);
		this.lblHCLCurmA.Name = "lblHCLCurmA";
		this.lblHCLCurmA.Size = new System.Drawing.Size(26, 18);
		this.lblHCLCurmA.TabIndex = 31;
		this.lblHCLCurmA.Text = "mA";
		this.lblHCLCurmA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//lblHCLCur
		//
		this.lblHCLCur.BackColor = System.Drawing.Color.Transparent;
		this.lblHCLCur.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblHCLCur.Location = new System.Drawing.Point(7, 69);
		this.lblHCLCur.Name = "lblHCLCur";
		this.lblHCLCur.Size = new System.Drawing.Size(56, 28);
		this.lblHCLCur.TabIndex = 30;
		this.lblHCLCur.Text = "HCL Cur";
		this.lblHCLCur.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//lblSlitWidthnm
		//
		this.lblSlitWidthnm.BackColor = System.Drawing.Color.Transparent;
		this.lblSlitWidthnm.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblSlitWidthnm.Location = new System.Drawing.Point(149, 140);
		this.lblSlitWidthnm.Name = "lblSlitWidthnm";
		this.lblSlitWidthnm.Size = new System.Drawing.Size(24, 18);
		this.lblSlitWidthnm.TabIndex = 28;
		this.lblSlitWidthnm.Text = "nm";
		this.lblSlitWidthnm.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//lblPMTVolts
		//
		this.lblPMTVolts.BackColor = System.Drawing.Color.Transparent;
		this.lblPMTVolts.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblPMTVolts.Location = new System.Drawing.Point(149, 41);
		this.lblPMTVolts.Name = "lblPMTVolts";
		this.lblPMTVolts.Size = new System.Drawing.Size(32, 18);
		this.lblPMTVolts.TabIndex = 27;
		this.lblPMTVolts.Text = "volts";
		this.lblPMTVolts.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//lblD2CurmA
		//
		this.lblD2CurmA.BackColor = System.Drawing.Color.Transparent;
		this.lblD2CurmA.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblD2CurmA.Location = new System.Drawing.Point(149, 108);
		this.lblD2CurmA.Name = "lblD2CurmA";
		this.lblD2CurmA.Size = new System.Drawing.Size(22, 18);
		this.lblD2CurmA.TabIndex = 26;
		this.lblD2CurmA.Text = "mA";
		this.lblD2CurmA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//cmbModes
		//
		this.cmbModes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cmbModes.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.cmbModes.ItemHeight = 15;
		this.cmbModes.Items.AddRange(new object[] {
			"AA",
			"HCLE",
			"D2E",
			"EMISSION",
			"AABGC",
			"MABS",
			"SELFTEST"
		});
		this.cmbModes.Location = new System.Drawing.Point(65, 237);
		this.cmbModes.Name = "cmbModes";
		this.cmbModes.Size = new System.Drawing.Size(82, 23);
		this.cmbModes.TabIndex = 18;
		this.cmbModes.Visible = false;
		//
		//lblModes
		//
		this.lblModes.BackColor = System.Drawing.Color.Transparent;
		this.lblModes.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblModes.Location = new System.Drawing.Point(7, 234);
		this.lblModes.Name = "lblModes";
		this.lblModes.Size = new System.Drawing.Size(56, 28);
		this.lblModes.TabIndex = 8;
		this.lblModes.Text = "Modes";
		this.lblModes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.lblModes.Visible = false;
		//
		//lblSlitWidth
		//
		this.lblSlitWidth.BackColor = System.Drawing.Color.Transparent;
		this.lblSlitWidth.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblSlitWidth.Location = new System.Drawing.Point(7, 134);
		this.lblSlitWidth.Name = "lblSlitWidth";
		this.lblSlitWidth.Size = new System.Drawing.Size(59, 28);
		this.lblSlitWidth.TabIndex = 5;
		this.lblSlitWidth.Text = "Slit Width";
		this.lblSlitWidth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//lblD2Cur
		//
		this.lblD2Cur.BackColor = System.Drawing.Color.Transparent;
		this.lblD2Cur.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblD2Cur.Location = new System.Drawing.Point(7, 101);
		this.lblD2Cur.Name = "lblD2Cur";
		this.lblD2Cur.Size = new System.Drawing.Size(56, 28);
		this.lblD2Cur.TabIndex = 2;
		this.lblD2Cur.Text = "D2Cur";
		this.lblD2Cur.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//lblPMT
		//
		this.lblPMT.BackColor = System.Drawing.Color.Transparent;
		this.lblPMT.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblPMT.Location = new System.Drawing.Point(8, 40);
		this.lblPMT.Name = "lblPMT";
		this.lblPMT.Size = new System.Drawing.Size(37, 28);
		this.lblPMT.TabIndex = 1;
		this.lblPMT.Text = "PMT";
		this.lblPMT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//btnExtinguish
		//
		this.btnExtinguish.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnExtinguish.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnExtinguish.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnExtinguish.Location = new System.Drawing.Point(556, 156);
		this.btnExtinguish.Name = "btnExtinguish";
		this.btnExtinguish.Size = new System.Drawing.Size(49, 18);
		this.btnExtinguish.TabIndex = 15;
		this.btnExtinguish.Text = "&Extinguish";
		this.btnExtinguish.TextAlign = System.Drawing.ContentAlignment.TopLeft;
		//
		//btnIgnite
		//
		this.btnIgnite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnIgnite.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnIgnite.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnIgnite.Location = new System.Drawing.Point(322, 146);
		this.btnIgnite.Name = "btnIgnite";
		this.btnIgnite.Size = new System.Drawing.Size(58, 20);
		this.btnIgnite.TabIndex = 14;
		this.btnIgnite.Text = "&Ignition";
		this.btnIgnite.TextAlign = System.Drawing.ContentAlignment.TopLeft;
		//
		//btnDelete
		//
		this.btnDelete.BackColor = System.Drawing.Color.Transparent;
		this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnDelete.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnDelete.Location = new System.Drawing.Point(366, 178);
		this.btnDelete.Name = "btnDelete";
		this.btnDelete.Size = new System.Drawing.Size(8, 8);
		this.btnDelete.TabIndex = 50;
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
		this.btnR.Location = new System.Drawing.Point(378, 178);
		this.btnR.Name = "btnR";
		this.btnR.Size = new System.Drawing.Size(8, 8);
		this.btnR.TabIndex = 49;
		this.btnR.TabStop = false;
		this.btnR.Text = "&R";
		this.btnR.TextAlign = System.Drawing.ContentAlignment.TopLeft;
		//
		//StatusBar1
		//
		this.StatusBar1.Location = new System.Drawing.Point(0, 488);
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
		//CommandBar1
		//
		this.CommandBar1.BackColor = System.Drawing.Color.Transparent;
		this.CommandBar1.CustomizeText = "&Customize Toolbar...";
		this.CommandBar1.Dock = System.Windows.Forms.DockStyle.Top;
		this.CommandBar1.ID = 7308;
		this.CommandBar1.Items.AddRange(new NETXP.Controls.Bars.CommandBarItem[] {
			this.cmdbtnReturn,
			this.CommandBarSeparatorItem1,
			this.cmdbtnAutoZero,
			this.cmdbtnAdjFuelFlow,
			this.cmdbtnAdjBurnerHt,
			this.cmdbtnChangeScale,
			this.CommandBarSeparatorItem2,
			this.tlbbtnGrid,
			this.tlbbtnLegends
		});
		this.CommandBar1.Location = new System.Drawing.Point(0, 24);
		this.CommandBar1.Margins.Bottom = 1;
		this.CommandBar1.Margins.Left = 1;
		this.CommandBar1.Margins.Right = 1;
		this.CommandBar1.Margins.Top = 1;
		this.CommandBar1.Name = "CommandBar1";
		this.CommandBar1.Size = new System.Drawing.Size(804, 34);
		this.CommandBar1.TabIndex = 0;
		this.CommandBar1.TabStop = false;
		this.CommandBar1.Text = "CommandBar1";
		//
		//cmdbtnReturn
		//
		this.cmdbtnReturn.Image = (System.Drawing.Image)resources.GetObject("cmdbtnReturn.Image");
		this.cmdbtnReturn.Shortcut = System.Windows.Forms.Shortcut.CtrlB;
		this.cmdbtnReturn.Text = "RETURN[CTRL+R]";
		//
		//cmdbtnAutoZero
		//
		this.cmdbtnAutoZero.Image = (System.Drawing.Image)resources.GetObject("cmdbtnAutoZero.Image");
		this.cmdbtnAutoZero.Shortcut = System.Windows.Forms.Shortcut.CtrlZ;
		this.cmdbtnAutoZero.Text = "AUTO ZERO[CTRL+Z]";
		//
		//cmdbtnAdjFuelFlow
		//
		this.cmdbtnAdjFuelFlow.Image = (System.Drawing.Image)resources.GetObject("cmdbtnAdjFuelFlow.Image");
		this.cmdbtnAdjFuelFlow.Shortcut = System.Windows.Forms.Shortcut.CtrlF;
		this.cmdbtnAdjFuelFlow.Text = "ADJUST FUEL FLOW[CTRL+F]";
		//
		//cmdbtnAdjBurnerHt
		//
		this.cmdbtnAdjBurnerHt.Image = (System.Drawing.Image)resources.GetObject("cmdbtnAdjBurnerHt.Image");
		this.cmdbtnAdjBurnerHt.Shortcut = System.Windows.Forms.Shortcut.CtrlB;
		this.cmdbtnAdjBurnerHt.Text = "ADJUST BURNER HEIGHT[CTRL+B]";
		//
		//cmdbtnChangeScale
		//
		this.cmdbtnChangeScale.Image = (System.Drawing.Image)resources.GetObject("cmdbtnChangeScale.Image");
		this.cmdbtnChangeScale.Shortcut = System.Windows.Forms.Shortcut.CtrlC;
		this.cmdbtnChangeScale.Text = "CHANGE SCALE[CTRL+C]";
		//
		//tlbbtnGrid
		//
		this.tlbbtnGrid.Image = (System.Drawing.Image)resources.GetObject("tlbbtnGrid.Image");
		this.tlbbtnGrid.Text = "GRID[CTRL+I]";
		//
		//tlbbtnLegends
		//
		this.tlbbtnLegends.Image = (System.Drawing.Image)resources.GetObject("tlbbtnLegends.Image");
		this.tlbbtnLegends.Text = "LEGEND[CTRL+D]";
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
			this.mnuGraphOptions
		});
		this.MenuBarEnergySpectrumMode.Location = new System.Drawing.Point(0, 0);
		this.MenuBarEnergySpectrumMode.Margins.Bottom = 1;
		this.MenuBarEnergySpectrumMode.Margins.Left = 1;
		this.MenuBarEnergySpectrumMode.Margins.Right = 1;
		this.MenuBarEnergySpectrumMode.Margins.Top = 1;
		this.MenuBarEnergySpectrumMode.Name = "MenuBarEnergySpectrumMode";
		this.MenuBarEnergySpectrumMode.Size = new System.Drawing.Size(804, 24);
		this.MenuBarEnergySpectrumMode.Style = NETXP.Controls.Bars.CommandBarStyle.Menu;
		this.MenuBarEnergySpectrumMode.TabIndex = 7;
		this.MenuBarEnergySpectrumMode.TabStop = false;
		this.MenuBarEnergySpectrumMode.Text = "";
		//
		//mnuFile
		//
		this.mnuFile.Infrequent = true;
		this.mnuFile.Items.AddRange(new NETXP.Controls.Bars.CommandBarItem[] { this.mnuReturn });
		this.mnuFile.Text = "&File";
		//
		//mnuReturn
		//
		this.mnuReturn.Image = (System.Drawing.Image)resources.GetObject("mnuReturn.Image");
		this.mnuReturn.Shortcut = System.Windows.Forms.Shortcut.CtrlR;
		this.mnuReturn.Text = "Return";
		//
		//mnuDataProcessing
		//
		this.mnuDataProcessing.Items.AddRange(new NETXP.Controls.Bars.CommandBarItem[] {
			this.mnuAutoZero,
			this.mnuAdjustFuel,
			this.mnuAdjustBurnerHeight
		});
		this.mnuDataProcessing.Text = "Data &Processing";
		//
		//mnuAutoZero
		//
		this.mnuAutoZero.Image = (System.Drawing.Image)resources.GetObject("mnuAutoZero.Image");
		this.mnuAutoZero.Shortcut = System.Windows.Forms.Shortcut.CtrlZ;
		this.mnuAutoZero.Text = "Auto &Zero";
		//
		//mnuAdjustFuel
		//
		this.mnuAdjustFuel.Image = (System.Drawing.Image)resources.GetObject("mnuAdjustFuel.Image");
		this.mnuAdjustFuel.Shortcut = System.Windows.Forms.Shortcut.CtrlF;
		this.mnuAdjustFuel.Text = "Adjust &Fuel";
		//
		//mnuAdjustBurnerHeight
		//
		this.mnuAdjustBurnerHeight.Image = (System.Drawing.Image)resources.GetObject("mnuAdjustBurnerHeight.Image");
		this.mnuAdjustBurnerHeight.Shortcut = System.Windows.Forms.Shortcut.CtrlB;
		this.mnuAdjustBurnerHeight.Text = "Adjust &Burner Height";
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
		this.mnuPeakEdit.Enabled = false;
		this.mnuPeakEdit.Image = (System.Drawing.Image)resources.GetObject("mnuPeakEdit.Image");
		this.mnuPeakEdit.Text = "Peak Edit";
		this.mnuPeakEdit.Visible = false;
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
		this.mnuShowXYValues.Enabled = false;
		this.mnuShowXYValues.Image = (System.Drawing.Image)resources.GetObject("mnuShowXYValues.Image");
		this.mnuShowXYValues.Text = "Show X,Y Values";
		this.mnuShowXYValues.Visible = false;
		//
		//mnuChangeScale
		//
		this.mnuChangeScale.Image = (System.Drawing.Image)resources.GetObject("mnuChangeScale.Image");
		this.mnuChangeScale.Text = "Change Scale";
		//
		//frmTimeScanMode
		//
		this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
		this.ClientSize = new System.Drawing.Size(804, 512);
		this.Controls.Add(this.CustomPanelMain);
		this.Controls.Add(this.StatusBar1);
		this.Controls.Add(this.CommandBar1);
		this.Controls.Add(this.MenuBarEnergySpectrumMode);
		this.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		this.MinimizeBox = false;
		this.Name = "frmTimeScanMode";
		this.ShowInTaskbar = false;
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Time Scan Mode";
		this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
		this.CustomPanelMain.ResumeLayout(false);
		this.CustomPanelBottom.ResumeLayout(false);
		this.CustomPanelTop.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.StatusBarPanelInfo).EndInit();
		((System.ComponentModel.ISupportInitialize)this.ProgressPanel).EndInit();
		((System.ComponentModel.ISupportInitialize)this.StatusBarPanelDate).EndInit();
		((System.ComponentModel.ISupportInitialize)this.CommandBar1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.MenuBarEnergySpectrumMode).EndInit();
		this.ResumeLayout(false);

	}

	#End Region

	#Region " Form Events "

	private void frmLoad()
	{
		try {
			subInitialise();
			if (blnActivateStartTimeScan == false) {
				funcSetDefaultParameter();
				nudD2Cur.Visible = true;
				nudPMT.Visible = true;
				nudSlit.Visible = true;
				nudHCLCur.Visible = true;
				blnActivateStartTimeScan = true;
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
frmTimeScanMode_Load(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        :  frmTimeScanMode_Load
		// Description           :  for handling time scan load event..
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
		CWaitCursor objWait = new CWaitCursor();
		try {
			btnReturn.Enabled = false;
			btnAutoZero.BringToFront();
			cmdChangeScale.BringToFront();
			Application.DoEvents();
			if (mblnAvoidProcessing == true) {
				//'check a flag for avoiding a process
				return;
			}

			mblnAvoidProcessing = true;
			ShowProgressBar(gstrTitleInstrumentType + ConstFormLoad);
			//'shows current info on progress bar 
			if (IsNothing(gobjclsTimer)) {
				gobjclsTimer = new clsTimer(StatusBar1, 1000);
				//'initialise a timer
			}
			gobjclsTimer.subTimerStart(StatusBar1);
			//'start a timer
			//Call subInitialise()
			//'this is for initializatoion of time scan mode
			if (funcOnSpect(false, lblTime, lblYValue) == false) {
				//'this is for starting a scanning 
				//'note in timescan scanning should automatically on 
				func_Enable_Disable(EnumProcesses.StartScan, EnumStart_End.End_of_Process);
				//'this will enable/disble the cortrol as par current process
				return;
			}
			//Added by Saurabh 05.08.07 To set Scale at RunTime
			gobjClsAAS203.Calculate_Analysis_Graph_Param(AASGraphTimeScan, ClsAAS203.enumChangeAxis.xyAxis);
			//Added by Saurabh 05.08.07

			btnAutoZero.Focus();
			//'got a focus on auto zero button

			HideProgressBar();
			//'for hide progressbar

			//Saurabh 10.07.07 To bring status form in front
			gobjfrmStatus.Show();
			//Saurabh
			this.BringToFront();
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
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
			objWait.Dispose();
			Application.DoEvents();
			//'allow application to perfrom its panding work.
			//---------------------------------------------------------
		}
	}

	private void  // ERROR: Handles clauses are not supported in C#
frmTimeScanMode_Closing(object sender, System.ComponentModel.CancelEventArgs e)
	{
		//=====================================================================
		// Procedure Name        : subInitialise
		// Parameters Passed     : sender,e
		// Returns               : MyBase.Closing
		// Purpose               : 
		// Description           : this is called when user closed a timescan mode
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 21.11.06
		// Revisions             : 
		//=====================================================================
		//'note:
		//'this is called when user close the timescan mode
		CWaitCursor objWait = new CWaitCursor();
		//Call gobjMessageAdapter.ShowMessage(constCuvetteBurner)
		//Call mnuExit_Click(sender, e)
		try {
			if (mblnAvoidProcessing == true) {

				if (!(mobjController == null)) {
					if (mobjController.IsThreadRunning) {
						//'check is there any thread is running?
						//'if yes then stop scan
						subStopScan();

						e.Cancel = true;
						Application.DoEvents();
						//'allow application to perfrom its panding work
						//'and then call a mnuExit_Click event
						mnuExit_Click(sender, e);
						//'call mnuExit_Click function .this perfrom  some closing step. 
						return;
					}
				}
			} else {
				if (!(mobjController == null)) {
					if (mobjController.IsThreadRunning) {
						//Call subStopScan()
						Application.DoEvents();
						mobjController.Cancel();
						//'stop the current thread
					}
				}
			}
			e.Cancel = false;
			mblnExitApplication = false;

			//If mblnIsfrmFlameStatusWork = True Then
			//If Not gstructSettings.ExeToRun = EnumApplicationMode.ServiceUtility Then
			//    If Not IsNothing(gobjMain) Then
			//        'gobjMain.mobjController = New BgThread.clsBgThread(gobjMain)
			//        'gobjclsBgFlameStatus = New clsBgFlameStatus
			//        gobjMain.mobjController.Start(gobjclsBgFlameStatus)
			//        gobjfrmStatus.Visible = True
			//    End If
			//End If


			//End If
			Application.DoEvents();
		//'here allow application to perfrom its pending work
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
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
			//'Dispose is a destructor 
			//---------------------------------------------------------
		}
	}

	private void mnuExit_Click(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : mnuExit_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To close the form.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 07.10.06
		// Revisions             : Sachin Dokhale
		//=====================================================================
		try {
			if (mblnAvoidProcessing == true) {
				subStopScan();
				//'stop the scan befor closing 
				Application.DoEvents();
				return;
			} else {
				if (!(mobjController == null)) {
					if (mobjController.IsThreadRunning) {
						Application.DoEvents();
						mobjController.Cancel();
						//'stop the thread
					}
				}
			}
			gobjclsTimer.subTimerStop();
			//'stop a timer and allow application to perfrom its panding work.
			Application.DoEvents();
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
			mblnExitApplication = false;
			//---------------------------------------------------------
		}
	}

	private void btnAutoZero_Click(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : btnAutoZero_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : this is called when user click on AutoZero button.
		// Description           : this is used for handling autozero click event
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale 
		// Created               : 22.12.06
		// Revisions             : 
		//=====================================================================
		try {
			if (mblnAvoidFormProcessing == true) {
				return;
			}
			mblnAvoidFormProcessing = true;
			mobjclsBgSpectrum.SpectrumWait = true;
			//ValueEditorUpDnEnable(False)

			subAutoZeroScan();

			mobjclsBgSpectrum.SpectrumWait = false;
			mblnAvoidFormProcessing = false;

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);

			mobjclsBgSpectrum.SpectrumWait = false;
			mblnAvoidFormProcessing = false;
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}

			//ValueEditorUpDnEnable(True)
			btnAutoZero.Focus();
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
		// Purpose               : this is called when user click on lamp parameter change
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 07.10.06
		// Revisions             : 
		//=====================================================================
		//'note:
		//'called when user clicked on LampParameterChange

		try {
			if (mblnAvoidFormProcessing == true) {
				return;
			}
			mblnAvoidFormProcessing = true;
			mobjclsBgSpectrum.SpectrumWait = true;
			//'set bool SpectrumWait  true for spectrum to wait 
			subLampParameterChanged();
			//'function for lamp parameter change
			mobjclsBgSpectrum.SpectrumWait = false;
			//'reset a flag for spectrumwait
			mblnAvoidFormProcessing = false;
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			mobjclsBgSpectrum.SpectrumWait = false;
			//'reset a flag for spectrumwait
			mblnAvoidFormProcessing = false;
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			btnLampParameters.Focus();
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
		// Purpose               : this is called when user click on Clear spectrum button
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
		//'function for clearing a spectrum
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
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


	private void cmbModes_SelectedIndexChanged(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : cmbModes_SelectedIndexChanged
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : this is called when user change the mode in mode combobox.
		// Description           : select index id for Calibration mode
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 21.11.06
		// Revisions             : 
		//=====================================================================


		//'This is used for taking action ,after the mode changed
		CWaitCursor objWait = new CWaitCursor();
		try {
			//If mblnAvoidProcessing = True Then
			//    Exit Sub
			//End If
			//mblnAvoidProcessing = True
			gblnSpectrumWait = true;
			//'allow spectrum to wait
			mobjclsBgSpectrum.SpectrumWait = true;
			//'this is a spectrumwait flag for thread 

			Application.DoEvents();
			//'allow application to perfrom its panding work.
			cmbModes.Enabled = false;
			cmbModes.SelectedIndexChanged -= cmbModes_SelectedIndexChanged;
			if (cmbModes.SelectedIndex > -1) {
				//'check if mode is selected or not if yes then
				//gobjInst.Mode = cmbModes.SelectedIndex
				funcSetSpectrumParam(cmbModes.SelectedIndex);
				//'function for setting a selected mode to spectrum parameter
			}
			cmbModes.SelectedIndexChanged += cmbModes_SelectedIndexChanged;

			gblnSpectrumWait = false;
			//'allow spectrum to wait
			mobjclsBgSpectrum.SpectrumWait = false;
		//'add a handler 
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			gblnSpectrumWait = false;
			//'allow spectrum to wait
			mobjclsBgSpectrum.SpectrumWait = false;
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
			//mblnAvoidProcessing = False
			//gblnSpectrumWait = False
			cmbModes.Enabled = true;
			//mobjclsBgSpectrum.SpectrumWait = False
			//'restart the spectrum 
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	//Private Sub cmbSpeed_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
	//    '=====================================================================
	//    ' Procedure Name        : cmbSpeed_SelectedIndexChanged
	//    ' Parameters Passed     : Object,EventArgs
	//    ' Returns               : None
	//    ' Purpose               : 
	//    ' Description           : 
	//    ' Assumptions           : 
	//    ' Dependencies          : 
	//    ' Author                : Sachin Dokhale
	//    ' Created               : 12.12.06
	//    ' Revisions             : 
	//    '=====================================================================

	//    Dim objWait As New CWaitCursor
	//    Try
	//        If mblnAvoidProcessing = True Then
	//            Exit Sub
	//        End If

	//        mblnAvoidProcessing = True

	//        RemoveHandler cmbSpeed.SelectedIndexChanged, AddressOf cmbSpeed_SelectedIndexChanged

	//        If funcSetSpeed(cmbSpeed.SelectedIndex) = True Then
	//        End If
	//        AddHandler cmbSpeed.SelectedIndexChanged, AddressOf cmbSpeed_SelectedIndexChanged

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
	//        mblnAvoidProcessing = False
	//        '---------------------------------------------------------
	//    End Try
	//End Sub

	private void cmdChangeScale_Click(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : cmdChangeScale_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : this called when user click on change scale button  
		// Description           : this is for changing a scale of spectrum as par given value.
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 21.11.06
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		frmYChangeScale objfrmYChangeScale;
		//'this is a object of change scale form

		try {
			//mobjclsBgSpectrum.SpectrumWait = True
			//mobjclsBgSpectrum.SpectrumWait = True
			//'allow spectrum to wait
			Application.DoEvents();
			//'allow application to perfrom its panding work.
			objfrmYChangeScale = new frmYChangeScale(mobjParameters);
			//'object of a changescale from
			objfrmYChangeScale.funcSetValidatingScale(gobjInst.Mode);
			//'setting a validation as par the selected mode
			if (objfrmYChangeScale.ShowDialog() == DialogResult.OK) {
				mobjclsBgSpectrum.SpectrumWait = true;
				//'set flag for spectrum wait
				if (!objfrmYChangeScale.SpectrumParameter == null) {
					//'through this routine software accept a value from user and store it to data structure
					mobjParameters.YaxisMax = objfrmYChangeScale.SpectrumParameter.YaxisMax;
					mobjParameters.YaxisMin = objfrmYChangeScale.SpectrumParameter.YaxisMin;
					//'get Y axis max-min value.
					if (!funcGraphPreRequisite(mobjParameters.Cal_Mode, mobjParameters.YaxisMin, mobjParameters.YaxisMax)) {
						//'this set a some prerequisite for a graph like cal. mode etc.
						//Call gFuncShowMessage("Error in setting spectrum parameters", "Please Check Entered Spectrum Parameters", modConstants.EnumMessageType.Information)
						return;
					}
				}

				// ------------Added By Pankaj on 8 May 07
				//'set a given scale to graph
				//'AASGraphTimeScan is a object of timescan graph
				AASGraphTimeScan.YAxisMin = mobjParameters.YaxisMin;
				AASGraphTimeScan.YAxisMax = mobjParameters.YaxisMax;
				gobjClsAAS203.Calculate_Analysis_Graph_Param(AASGraphTimeScan, ClsAAS203.enumChangeAxis.xyAxis);
				//'for calculating a analysis graph parameter.
				mobjclsBgSpectrum.SpectrumWait = false;
			}
			objfrmYChangeScale.Close();
			//'close the form and allow application to perfrom its panding work.
			//Application.DoEvents()
			mobjclsBgSpectrum.SpectrumWait = false;
			gblnSpectrumWait = false;
			Application.DoEvents();
		//'allow application to perfrom its panding work.
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			gblnSpectrumWait = false;
			mobjclsBgSpectrum.SpectrumWait = false;
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}

			if (!objfrmYChangeScale == null) {
				objfrmYChangeScale.Dispose();
			}
			//'destructor
			//gblnSpectrumWait = False
			Application.DoEvents();
			//'allow application to perfrom its panding work.
			if (!objWait == null) {
				objWait.Dispose();
			}
			//mobjclsBgSpectrum.SpectrumWait = False
			//'restart the thread.
			cmdChangeScale.Focus();
			Application.DoEvents();
			//mblnAvoidProcessing = False
			//---------------------------------------------------------
		}
	}

	private void AASGraphTimeScan_GraphScaleChanged(double XMin, double XMax, double YMin, double YMax)
	{
		//=====================================================================
		// Procedure Name        :   AASGraphTimeScan_GraphScaleChanged
		// Description           :   Get Graph Scale
		// Purpose               :   
		// Parameters Passed     :   XMin,XMax,YMin,YMax
		// Returns               :   
		// Parameters Affected   :   
		// Assumptions           :   
		// Dependencies          :   None.
		// Author                :   Sachin Dokhale
		// Created               :   16.02.07
		// Revisions             :
		//=====================================================================

		//'set the parameter 
		//'this will set the given value of scale to the graph
		try {
			mobjParameters.YaxisMax = YMax;
			//objfrmYChangeScale.SpectrumParameter.YaxisMax
			mobjParameters.YaxisMin = YMin;
			//objfrmYChangeScale.SpectrumParameter.YaxisMin
			//'get a passed value to a datastructure

			if (!funcGraphPreRequisite(mobjParameters.Cal_Mode, mobjParameters.YaxisMin, mobjParameters.YaxisMax)) {
				//'set the graph as par new scale
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

	#Region " Form Objects "

	//Private Sub nudPMT_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs)

	private void nudPMT_ValueChanged(double ChangePmt)
	{
		//=====================================================================
		// Procedure Name        : nudPMT_ValueChanged
		// Parameters Passed     : ChangePmt
		// Returns               : None
		// Purpose               : this is called when user change a PMT value
		// Description           : perfroming action after changing a PMT value
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 21.11.06
		// Revisions             : praveen
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		try {
			if (mblnAvoidFormProcessing == true) {
				return;
			}
			mblnAvoidFormProcessing = true;
			mobjclsBgSpectrum.SpectrumWait = true;

			//RemoveHandler nudPMT.ValueEditorValueChanged, AddressOf nudPMT_ValueChanged
			Application.DoEvents();

			funcSetPmtVParameter(nudPMT.Value);

			mblnAvoidFormProcessing = false;
			mobjclsBgSpectrum.SpectrumWait = false;

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);

			mblnAvoidFormProcessing = false;
			mobjclsBgSpectrum.SpectrumWait = false;
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}

			//AddHandler nudPMT.ValueEditorValueChanged, AddressOf nudPMT_ValueChanged
			if (!objWait == null) {
				objWait.Dispose();
			}
			Application.DoEvents();
		}
	}

	private void nudPMT_ValueEditorClick()
	{
		//=====================================================================
		// Procedure Name        : nudPMT_ValueEditorClick
		// Parameters Passed     :  None
		// Returns               : None
		// Purpose               : 
		// Description           :  handles nudPMT_ValueEditor's click event
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 21.11.06
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		double dblReturnValue;

		try {
			if (mblnAvoidFormProcessing == true) {
				return;
			}
			//mblnAvoidFormProcessing = True
			mobjclsBgSpectrum.SpectrumWait = true;

			//RemoveHandler nudPMT.ValueEditorClick, AddressOf nudPMT_ValueEditorClick
			Application.DoEvents();

			dblReturnValue = (int)gobjInst.PmtVoltage;
			if (funcSetFrmEditValue(dblReturnValue, "Set PMT (0 - 700)V", nudPMT.MinValue, nudPMT.MaxValue) == true) {
				nudPMT.Value = dblReturnValue;
			}

			//mblnAvoidFormProcessing = False
			mobjclsBgSpectrum.SpectrumWait = false;

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);

			//mblnAvoidFormProcessing = False
			mobjclsBgSpectrum.SpectrumWait = false;
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}

			//AddHandler nudPMT.ValueEditorClick, AddressOf nudPMT_ValueEditorClick
			if (!objWait == null) {
				objWait.Dispose();
			}
			Application.DoEvents();
		}
	}

	//Private Sub nudSlit_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
	//    '=====================================================================
	//    ' Procedure Name        : cmbModes_SelectedIndexChanged
	//    ' Parameters Passed     : Object,EventArgs
	//    ' Returns               : None
	//    ' Purpose               : 
	//    ' Description           : select index id for Calibration mode
	//    ' Assumptions           : 
	//    ' Dependencies          : 
	//    ' Author                : Sachin Dokhale
	//    ' Created               : 21.11.06
	//    ' Revisions             : 
	//    '=====================================================================
	//    Dim objWait As New CWaitCursor
	//    Try
	//        nudSlit.Enabled = False
	//        mobjclsBgSpectrum.SpectrumWait = True
	//        Application.DoEvents()
	//        Call funcSetSlit_WidthParameter(nudSlit.Value)
	//        mobjclsBgSpectrum.SpectrumWait = False
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
	//        gblnSpectrumWait = False
	//        nudSlit.Enabled = True
	//        If Not objWait Is Nothing Then
	//            objWait.Dispose()
	//        End If
	//        Application.DoEvents()
	//    End Try
	//End Sub

	private void nudSlit_ValueChanged(double ChangeSlit)
	{
		//=====================================================================
		// Procedure Name        : nudSlit_ValueChanged
		// Parameters Passed     : ChangeSlit
		// Returns               : None
		// Purpose               : this is called when user change a slit width 
		// Description           :  
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 21.11.06
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		try {
			if (mblnAvoidFormProcessing == true) {
				return;
			}
			mblnAvoidFormProcessing = true;
			mobjclsBgSpectrum.SpectrumWait = true;

			//RemoveHandler nudSlit.ValueEditorValueChanged, AddressOf nudSlit_ValueChanged
			Application.DoEvents();
			funcSetSlit_WidthParameter(nudSlit.Value);

			mblnAvoidFormProcessing = false;
			gblnSpectrumWait = false;
			mobjclsBgSpectrum.SpectrumWait = false;
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);

			mblnAvoidFormProcessing = false;
			gblnSpectrumWait = false;
			mobjclsBgSpectrum.SpectrumWait = true;
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			//AddHandler nudSlit.ValueEditorValueChanged, AddressOf nudSlit_ValueChanged
			if (!objWait == null) {
				objWait.Dispose();
			}
			Application.DoEvents();
		}
	}

	private void nudSlit_ValueEditorClick()
	{
		//=====================================================================
		// Procedure Name        : nudSlit_ValueEditorClick
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : 
		// Description           :  handles nudSlit_ValueEditors click event
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 21.11.06
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		double dblReturnValue;
		try {
			if (mblnAvoidFormProcessing == true) {
				return;
			}
			//mblnAvoidFormProcessing = True
			mobjclsBgSpectrum.SpectrumWait = true;

			//RemoveHandler nudSlit.ValueEditorClick, AddressOf nudSlit_ValueEditorClick
			Application.DoEvents();

			dblReturnValue = gobjClsAAS203.funcGet_SlitWidth();

			if (funcSetFrmEditValue(dblReturnValue, "Set Slit Width (0.0 - 2.0)nm", nudSlit.MinValue, nudSlit.MaxValue) == true) {
				nudSlit.Value = dblReturnValue;
			}

			mobjclsBgSpectrum.SpectrumWait = false;
		//mblnAvoidFormProcessing = False

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);

			mobjclsBgSpectrum.SpectrumWait = false;
		//mblnAvoidFormProcessing = False
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}

			//AddHandler nudSlit.ValueEditorClick, AddressOf nudSlit_ValueEditorClick
			if (!objWait == null) {
				objWait.Dispose();
			}
			Application.DoEvents();
		}
	}

	//Private Sub nudHCLCur_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
	//    '=====================================================================
	//    ' Procedure Name        : cmbModes_SelectedIndexChanged
	//    ' Parameters Passed     : Object,EventArgs
	//    ' Returns               : None
	//    ' Purpose               : 
	//    ' Description           : select index id for Calibration mode
	//    ' Assumptions           : 
	//    ' Dependencies          : 
	//    ' Author                : Sachin Dokhale
	//    ' Created               : 21.11.06
	//    ' Revisions             : 
	//    '=====================================================================
	//    Dim objWait As New CWaitCursor
	//    Try
	//        nudHCLCur.Enabled = False
	//        mobjclsBgSpectrum.SpectrumWait = True
	//        Call funcSetHCL_CurParameter(nudHCLCur.Value)

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
	//        gblnSpectrumWait = False
	//        mobjclsBgSpectrum.SpectrumWait = False
	//        nudHCLCur.Enabled = True
	//        If Not objWait Is Nothing Then
	//            objWait.Dispose()
	//        End If
	//        Application.DoEvents()
	//    End Try
	//End Sub

	private void nudHCLCur_ValueChanged(double ChangeHCLCur)
	{
		//=====================================================================
		// Procedure Name        : nudHCLCur_ValueChanged
		// Parameters Passed     : ChangeHCLCur
		// Returns               : None
		// Purpose               : this is called when user change a HCl current value
		// Description           :  
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 21.11.06
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		try {
			if (mblnAvoidFormProcessing == true) {
				return;
			}
			mblnAvoidFormProcessing = true;
			mobjclsBgSpectrum.SpectrumWait = true;

			//RemoveHandler nudHCLCur.ValueEditorValueChanged, AddressOf nudHCLCur_ValueChanged
			Application.DoEvents();
			if (ReInitLampInstParameters == true) {
				return;
			}
			funcSetHCL_CurParameter(nudHCLCur.Value);

			mblnAvoidFormProcessing = false;
			mobjclsBgSpectrum.SpectrumWait = false;
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);

			mblnAvoidFormProcessing = false;
			mobjclsBgSpectrum.SpectrumWait = false;
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}

			//AddHandler nudHCLCur.ValueEditorValueChanged, AddressOf nudHCLCur_ValueChanged
			if (!objWait == null) {
				objWait.Dispose();
			}
			Application.DoEvents();
		}
	}

	private void nudHCLCur_ValueEditorClick()
	{
		//=====================================================================
		// Procedure Name        : nudHCLCur_ValueEditorClick
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : for handling click event 
		// Description           :  
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 21.11.06
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		double dblReturnValue;
		try {
			if (mblnAvoidFormProcessing == true) {
				return;
			}
			//mblnAvoidFormProcessing = True
			mobjclsBgSpectrum.SpectrumWait = true;

			//RemoveHandler nudHCLCur.ValueEditorClick, AddressOf nudHCLCur_ValueEditorClick
			Application.DoEvents();
			if (ReInitLampInstParameters == true) {
				return;
			}

			dblReturnValue = gobjInst.Current;
			if (funcSetFrmEditValue(dblReturnValue, "Set HCL Current (0 - 25)mA", nudHCLCur.MinValue, nudHCLCur.MaxValue) == true) {
				//mblnAvoidFormProcessing = False
				nudHCLCur.Value = dblReturnValue;
			}

			//mblnAvoidFormProcessing = False
			mobjclsBgSpectrum.SpectrumWait = false;
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);

			//mblnAvoidFormProcessing = False
			mobjclsBgSpectrum.SpectrumWait = false;
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}

			//AddHandler nudHCLCur.ValueEditorClick, AddressOf nudHCLCur_ValueEditorClick
			if (!objWait == null) {
				objWait.Dispose();
			}
			Application.DoEvents();
		}
	}

	//Private Sub nudD2Cur_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
	//    '=====================================================================
	//    ' Procedure Name        : cmbModes_SelectedIndexChanged
	//    ' Parameters Passed     : Object,EventArgs
	//    ' Returns               : None
	//    ' Purpose               : 
	//    ' Description           : select index id for Calibration mode
	//    ' Assumptions           : 
	//    ' Dependencies          : 
	//    ' Author                : Sachin Dokhale
	//    ' Created               : 21.11.06
	//    ' Revisions             : 
	//    '=====================================================================
	//    Dim objWait As New CWaitCursor
	//    Try
	//        nudD2Cur.Enabled = False
	//        mobjclsBgSpectrum.SpectrumWait = True
	//        Call funcSetD2_CurParameter(nudD2Cur.Value)

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
	//        gblnSpectrumWait = False
	//        mobjclsBgSpectrum.SpectrumWait = False
	//        nudD2Cur.Enabled = True
	//        If Not objWait Is Nothing Then
	//            objWait.Dispose()
	//        End If
	//        Application.DoEvents()
	//    End Try
	//End Sub

	private void nudD2Cur_ValueChanged(double ChangeD2Cur)
	{
		//=====================================================================
		// Procedure Name        : nudD2Cur_ValueChanged
		// Parameters Passed     : ChangeD2Cur
		// Returns               : None
		// Purpose               : this is called when user change  D2 current 
		// Description           :  
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 21.11.06
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		try {
			if (mblnAvoidFormProcessing == true) {
				return;
			}
			mblnAvoidFormProcessing = true;
			mobjclsBgSpectrum.SpectrumWait = true;

			//RemoveHandler nudD2Cur.ValueEditorValueChanged, AddressOf nudD2Cur_ValueChanged
			if (ReInitLampInstParameters == true) {
				return;
			}

			funcSetD2_CurParameter(nudD2Cur.Value);
			if (nudD2Cur.Value == 100.0) {
				nudD2Cur.Text = "D2 Off";
			}

			gblnSpectrumWait = false;
			mblnAvoidFormProcessing = false;
			mobjclsBgSpectrum.SpectrumWait = false;

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);

			gblnSpectrumWait = false;
			mblnAvoidFormProcessing = false;
			mobjclsBgSpectrum.SpectrumWait = false;
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}

			//AddHandler nudD2Cur.ValueEditorValueChanged, AddressOf nudD2Cur_ValueChanged
			if (!objWait == null) {
				objWait.Dispose();
			}
			Application.DoEvents();
		}
	}

	private void nudD2Cur_ValueEditorClick()
	{
		//=====================================================================
		// Procedure Name        : nudD2Cur_ValueEditorClick
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : for handling click event
		// Description           :  
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 21.11.06
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		double dblReturnValue;
		try {
			if (mblnAvoidFormProcessing == true) {
				return;
			}
			if (ReInitLampInstParameters == true) {
				return;
			}
			//mblnAvoidFormProcessing = True
			mobjclsBgSpectrum.SpectrumWait = true;

			//RemoveHandler nudD2Cur.ValueEditorClick, AddressOf nudD2Cur_ValueEditorClick
			Application.DoEvents();

			dblReturnValue = gobjInst.D2Current;
			if (funcSetFrmEditValue(dblReturnValue, "Set D2 Current (100 - 300)mA", nudD2Cur.MinValue, nudD2Cur.MaxValue) == true) {
				nudD2Cur.Value = dblReturnValue;
			}

			//mblnAvoidFormProcessing = False
			mobjclsBgSpectrum.SpectrumWait = false;
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);

			//mblnAvoidFormProcessing = False
			mobjclsBgSpectrum.SpectrumWait = false;
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}

			//AddHandler nudD2Cur.ValueEditorClick, AddressOf nudD2Cur_ValueEditorClick
			if (!objWait == null) {
				objWait.Dispose();
			}
			Application.DoEvents();
		}
	}

	//Private Sub nudFuelRatio_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
	//    '=====================================================================
	//    ' Procedure Name        : cmbModes_SelectedIndexChanged
	//    ' Parameters Passed     : Object,EventArgs
	//    ' Returns               : None
	//    ' Purpose               : 
	//    ' Description           : select index id for Calibration mode
	//    ' Assumptions           : 
	//    ' Dependencies          : 
	//    ' Author                : Sachin Dokhale
	//    ' Created               : 21.11.06
	//    ' Revisions             : 
	//    '=====================================================================
	//    Dim objWait As New CWaitCursor

	//    Try
	//        'If Not (dblFuelRatio = CDbl(nudFuelRatio.Value)) Then
	//        '    If dblFuelRatio > nudFuelRatio.Value Then

	//        '        dblFuelRatio = funcSetFuelParameter(-1)
	//        '        dblFuelRatio = Format(dblFuelRatio, "#.00")
	//        '        nudFuelRatio.Value = Format(dblFuelRatio, "#.00")
	//        '    ElseIf dblFuelRatio < nudFuelRatio.Value Then
	//        '        dblFuelRatio = funcSetFuelParameter(1)
	//        '        dblFuelRatio = Format(dblFuelRatio, "#.00")
	//        '        nudFuelRatio.Value = Format(dblFuelRatio, "#.00")
	//        '    End If
	//        'End If 

	//        'nudFuelRatio.Text = funcSetFuelParameter(CDbl(nudFuelRatio.Value))
	//        nudFuelRatio.Enabled = False
	//        mobjclsBgSpectrum.SpectrumWait = True
	//        Application.DoEvents()
	//        RemoveHandler nudFuelRatio.ValueChanged, AddressOf nudBurnerHeight_ValueChanged
	//        If Not (CDbl(nudFuelRatio.Value) = mdblFuelRatio) Then
	//            Call gobjClsAAS203.funcSetFuel(CDbl(nudFuelRatio.Value))
	//            mdblFuelRatio = gobjClsAAS203.funcGet_Fuel_Ratio(True)
	//        Else
	//            mdblFuelRatio = gobjClsAAS203.funcGet_Fuel_Ratio(True)
	//        End If
	//        mobjParameters.FualRatio = Val(mdblFuelRatio)
	//        nudFuelRatio.Text = mdblFuelRatio
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
	//        '---------------------------------------------------------
	//        gblnSpectrumWait = False
	//        mobjclsBgSpectrum.SpectrumWait = False
	//        nudFuelRatio.Enabled = True
	//        If Not objWait Is Nothing Then
	//            objWait.Dispose()
	//        End If
	//        Application.DoEvents()
	//    End Try
	//End Sub

	private void nudFuelRatio_ValueChanged(double ChangeFuelRatio)
	{
		//=====================================================================
		// Procedure Name        : nudFuelRatio_ValueChanged
		// Parameters Passed     : ChangeFuelRatio
		// Returns               : None
		// Purpose               : called when user change fuel ratio
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 21.11.06
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();

		try {
			if (mblnAvoidFormProcessing == true) {
				return;
			}
			mblnAvoidFormProcessing = true;
			mobjclsBgSpectrum.SpectrumWait = true;

			Application.DoEvents();

			//RemoveHandler nudFuelRatio.ValueEditorValueChanged, AddressOf nudFuelRatio_ValueChanged

			//---above code is commented and called following 
			//---function to set fuel according to value editor 
			//---button clicked
			FuncIncrDecrFuel((double)nudFuelRatio.Value);

			if (mdblFuelRatio < 0.0) {
				nudFuelRatio.Value = 0.0;
				mobjParameters.FualRatio = 0.0;
				mdblFuelRatio = 0.0;
			} else {
				nudFuelRatio.Value = mdblFuelRatio;
				mobjParameters.FualRatio = mdblFuelRatio;
			}

			nudFuelRatio.Refresh();

			gblnSpectrumWait = false;
			mblnAvoidFormProcessing = false;
			mobjclsBgSpectrum.SpectrumWait = false;

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);

			gblnSpectrumWait = false;
			mblnAvoidFormProcessing = false;
			mobjclsBgSpectrum.SpectrumWait = false;
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			//---------------------------------------------------------

			//AddHandler nudFuelRatio.ValueEditorValueChanged, AddressOf nudFuelRatio_ValueChanged
			if (!objWait == null) {
				objWait.Dispose();
			}
			Application.DoEvents();
		}
	}

	private void nudFuelRatio_ValueEditorClick()
	{
		//=====================================================================
		// Procedure Name        : nudFuelRatio_ValueEditorClick
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : to handle click event
		// Description           :  
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 21.11.06
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		double dblReturnValue;
		long lngReturnValue;

		try {
			//RemoveHandler nudFuelRatio.ValueEditorClick, AddressOf nudFuelRatio_ValueEditorClick
			if (mblnAvoidFormProcessing == true) {
				return;
			}
			//mblnAvoidFormProcessing = True
			mobjclsBgSpectrum.SpectrumWait = true;

			Application.DoEvents();

			dblReturnValue = gobjClsAAS203.funcGet_Fuel_Ratio(true);

			if (dblReturnValue < 0.0) {
				dblReturnValue = 0.0;
			} else {
				dblReturnValue = Format(dblReturnValue, "#0.00");
			}

			if (funcSetFrmEditValue(dblReturnValue, "Set Fuel Ratio (0 - 7.66)", nudFuelRatio.MinValue, nudFuelRatio.MaxValue) == true) {
				nudFuelRatio.Value = dblReturnValue;
			}

			mobjclsBgSpectrum.SpectrumWait = false;
		//mblnAvoidFormProcessing = False
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);

			mobjclsBgSpectrum.SpectrumWait = false;
		//mblnAvoidFormProcessing = False
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}

			//AddHandler nudFuelRatio.ValueEditorClick, AddressOf nudFuelRatio_ValueEditorClick
			if (!objWait == null) {
				objWait.Dispose();
			}
			Application.DoEvents();
		}
	}

	//Private Sub nudBurnerHeight_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
	//    '=====================================================================
	//    ' Procedure Name        : cmbModes_SelectedIndexChanged
	//    ' Parameters Passed     : Object,EventArgs
	//    ' Returns               : None
	//    ' Purpose               : 
	//    ' Description           : select index id for Calibration mode
	//    ' Assumptions           : 
	//    ' Dependencies          : 
	//    ' Author                : Sachin Dokhale
	//    ' Created               : 21.11.06
	//    ' Revisions             : 
	//    '=====================================================================
	//    Dim objWait As New CWaitCursor
	//    Try
	//        nudBurnerHeight.Enabled = False
	//        mobjclsBgSpectrum.SpectrumWait = True
	//        Application.DoEvents()
	//        If Not (mdblBhHeight = CDbl(nudBurnerHeight.Value)) Then
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
	//        '---------------------------------------------------------
	//        gblnSpectrumWait = False
	//        mobjclsBgSpectrum.SpectrumWait = False
	//        nudBurnerHeight.Enabled = True
	//        If Not objWait Is Nothing Then
	//            objWait.Dispose()
	//        End If
	//        Application.DoEvents()
	//    End Try
	//End Sub

	//Private Sub AASEnergySpectrum_OnAxisChange() Handles AASGraphTimeScan.OnAxisChange
	//    MsgBox(" Axis is Changed ")
	//End Sub

	private void nudBurnerHeight_ValueChanged(double ChangeFuelRatio)
	{
		//=====================================================================
		// Procedure Name        : nudBurnerHeight_ValueChanged
		// Parameters Passed     : ChangeFuelRatio
		// Returns               : None
		// Purpose               : for handling click event 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 21.11.06
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		try {
			if (mblnAvoidFormProcessing == true) {
				return;
			}
			mblnAvoidFormProcessing = true;
			mobjclsBgSpectrum.SpectrumWait = true;

			//RemoveHandler nudBurnerHeight.ValueEditorValueChanged, AddressOf nudBurnerHeight_ValueChanged
			Application.DoEvents();

			if (!(mdblBhHeight == (double)nudBurnerHeight.Value)) {
				nudBurnerHeight.Value = funcSetBurner_HeightParameter(nudBurnerHeight.Value);
			}

			mblnAvoidFormProcessing = false;
			gblnSpectrumWait = false;
			mobjclsBgSpectrum.SpectrumWait = false;

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);

			mblnAvoidFormProcessing = false;
			gblnSpectrumWait = false;
			mobjclsBgSpectrum.SpectrumWait = false;

		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			//---------------------------------------------------------

			//AddHandler nudBurnerHeight.ValueEditorValueChanged, AddressOf nudBurnerHeight_ValueChanged
			if (!objWait == null) {
				objWait.Dispose();
			}
			Application.DoEvents();
		}
	}

	private void nudBurnerHeight_ValueEditorClick()
	{
		//=====================================================================
		// Procedure Name        : nudBurnerHeight_ValueEditorClick
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : for handling click event 
		// Description           : for setting burner height
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 21.11.06
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		double dblReturnValue;
		try {
			if (mblnAvoidFormProcessing == true) {
				return;
			}
			//mblnAvoidFormProcessing = True
			mobjclsBgSpectrum.SpectrumWait = true;

			//RemoveHandler nudBurnerHeight.ValueEditorClick, AddressOf nudBurnerHeight_ValueEditorClick
			Application.DoEvents();

			dblReturnValue = Format(gobjClsAAS203.funcConvertToBurnerHeight(gobjInst.BhStep), "0.00");
			if (funcSetFrmEditValue(dblReturnValue, "Set Burner Height (0.0 - 6.0)nm", nudBurnerHeight.MinValue, nudBurnerHeight.MaxValue) == true) {
				nudBurnerHeight.Value = dblReturnValue;
			}

			mobjclsBgSpectrum.SpectrumWait = false;
		//mblnAvoidFormProcessing = False

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);

			mobjclsBgSpectrum.SpectrumWait = false;
		//mblnAvoidFormProcessing = False
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}

			//AddHandler nudBurnerHeight.ValueEditorClick, AddressOf nudBurnerHeight_ValueEditorClick
			if (!objWait == null) {
				objWait.Dispose();
			}
			Application.DoEvents();
		}
	}

	private void  // ERROR: Handles clauses are not supported in C#
cmdD2GainStatus_Click(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        :   cmdD2GainStatus_Click
		// Description           :   
		// Purpose               :   for handling click event 
		//                           
		// Parameters Passed     :   sender, e
		// Returns               :   
		// Parameters Affected   :   
		// Assumptions           :   
		// Dependencies          :   None.
		// Author                :   Sachin Dokhale 
		// Created               :   10.12.06
		// Revisions             :
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		try {
			// if(ReadIniForD2Gain()){
			//if(IsD2GainOn()){
			//	GainX10Off();   //SetGain10_On()
			//	SetWindowText(GetDlgItem(hwnd,IDC_PBD2GAIN),"D2 Gain ON");
			//}
			//else{
			//	GainX10On(); //SetGain10_Off()
			//	SetWindowText(GetDlgItem(hwnd,IDC_PBD2GAIN),"D2 Gain OFF");
			//}
			//}
			mobjclsBgSpectrum.SpectrumWait = true;
			cmdD2GainStatus.Enabled = false;
			mobjclsBgSpectrum.SpectrumWait = true;
			subD2GainSatus();
		//'for gain status

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			gblnSpectrumWait = false;
			mobjclsBgSpectrum.SpectrumWait = false;
			//nudBurnerHeight.Enabled = True
			if (!objWait == null) {
				objWait.Dispose();
			}
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	private void  // ERROR: Handles clauses are not supported in C#
cmdFilter_Click(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        :   cmdFilter_Click
		// Description           :   
		// Purpose               :  for handling click event 
		//                           
		// Parameters Passed     :   sender, e
		// Returns               :   
		// Parameters Affected   :   
		// Assumptions           :   
		// Dependencies          :   None.
		// Author                :   Sachin Dokhale 
		// Created               :   22.12.06
		// Revisions             :
		//=====================================================================

		try {
			//gblnSmoothFilter ^= True
			//           If (Smooth) Then
			//SetWindowText(GetDlgItem(hwnd,IDC_FILT),"Filt");
			//           Else
			//SetWindowText(GetDlgItem(hwnd,IDC_FILT),"No Filt");
			mobjclsBgSpectrum.SpectrumWait = true;
			gblnSmoothFilter = gblnSmoothFilter ^ true;
			if (gblnSmoothFilter == true) {
				cmdFilter.Text = "Filter";
				cmdFilter.Refresh();
			} else {
				cmdFilter.Text = "No Filter";
				cmdFilter.Refresh();
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
			mobjclsBgSpectrum.SpectrumWait = false;
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	private void  // ERROR: Handles clauses are not supported in C#
cmdADJFlow_Click(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        :   cmdADJFlow_Click
		// Description           :   
		// Purpose               :   for handling click event 
		//                           
		// Parameters Passed     :   sender, e
		// Returns               :   
		// Parameters Affected   :   
		// Assumptions           :   
		// Dependencies          :   None.
		// Author                :   Sachin Dokhale 
		// Created               :   22.12.06
		// Revisions             :
		//=====================================================================
		try {
			//gblnSmoothFilter ^= True

			//Smooth ^= TRUE;
			//           If (Smooth) Then
			//SetWindowText(GetDlgItem(hwnd,IDC_FILT),"Filt");
			//           Else
			//SetWindowText(GetDlgItem(hwnd,IDC_FILT),"No Filt");
			//Optimise_Fuel_Auto(hwnd);
			//Scroll_Fuel(hwnd,IDC_FUEL, -1);break;
			//funcOptimise_Fuel_Auto(1, 2)
			//check for application mode

			if (mblnAvoidFormProcessing == true) {
				return;
			}
			mblnAvoidFormProcessing = true;
			mobjclsBgSpectrum.SpectrumWait = true;

			if ((gstructSettings.AppMode == EnumAppMode.FullVersion_201)) {
				return;
			}
			//           If (!ReadAndSetFuelScanConditions(hpar)) Then
			//return FALSE;


			//If (!Flame_Present(False)) Then
			//return FALSE;
			//               If (!CheckNvPos()) Then
			//return FALSE;
			//check for flame presence
			if (!(gobjClsAAS203.funcFlame_Present(false))) {
				return;
			}
			//check for Nv Position
			if ((!gobjClsAAS203.funcCheckNvPos())) {
				return;
			}

			gintOptimisation = modGlobalDeclarations.EnumBH_FP_Opimisation.FuelPresure;
			frmBurnerOptimisation objfrmBurnerOptimisation = new frmBurnerOptimisation();
			objfrmBurnerOptimisation.ShowDialog();
			objfrmBurnerOptimisation.Dispose();
			objfrmBurnerOptimisation = null;


			mdblFuelRatio = gobjClsAAS203.funcGet_Fuel_Ratio(true);
			if (mdblFuelRatio < 0.0) {
				mdblFuelRatio = 0.0;
			} else {
				mdblFuelRatio = Format(mdblFuelRatio, "#0.00");
			}

			nudFuelRatio.Value = mdblFuelRatio;
			mobjParameters.FualRatio = mdblFuelRatio;
			nudFuelRatio.Text = mdblFuelRatio;
			nudFuelRatio.Refresh();

			if (gobjClsAAS203.funcCheck_Flame == true) {
			} else {
				gobjMessageAdapter.ShowMessage(constFlameErrorFlameOff);
				Application.DoEvents();
			}

			mblnAvoidFormProcessing = false;
			mobjclsBgSpectrum.SpectrumWait = false;
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);

			mblnAvoidFormProcessing = false;
			mobjclsBgSpectrum.SpectrumWait = false;
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

	private void  // ERROR: Handles clauses are not supported in C#
cmdADJBH_Click(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        :   cmdADJFlow_Click
		// Description           :   
		// Purpose               :   this is called when user click on burner height button
		//                           
		// Parameters Passed     :   sender, e
		// Returns               :   
		// Parameters Affected   :   
		// Assumptions           :   
		// Dependencies          :   None.
		// Author                :   Sachin Dokhale 
		// Created               :   22.12.06
		// Revisions             :
		//=====================================================================
		try {
			//case	IDC_ADJBH:	Optimise_Height_Auto(hwnd);
			//								Scroll_Bh(hwnd,IDC_BH, -1);
			//								Save_BH_Pos();
			//            AASGraphTimeScan.BringToFront()
			//Call gobjClsAAS203.Optimise_Height_Auto(AASGraphTimeScan)

			if (mblnAvoidFormProcessing == true) {
				return;
			}
			mblnAvoidFormProcessing = true;
			mobjclsBgSpectrum.SpectrumWait = true;

			gintOptimisation = modGlobalDeclarations.EnumBH_FP_Opimisation.BurnerHeight;

			frmBurnerOptimisation objfrmBurnerOptimisation = new frmBurnerOptimisation();
			Application.DoEvents();
			objfrmBurnerOptimisation.ShowDialog();

			objfrmBurnerOptimisation.Dispose();
			mdblBhHeight = gobjClsAAS203.funcReadBurnerHeight();

			nudBurnerHeight.Value = mdblBhHeight;
			mobjParameters.BurnerHeight = mdblBhHeight;

			mblnAvoidFormProcessing = false;
			mobjclsBgSpectrum.SpectrumWait = false;

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);

			mblnAvoidFormProcessing = false;
			mobjclsBgSpectrum.SpectrumWait = false;
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}

			cmdADJBH.Focus();
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

	//        mobjclsBgSpectrum.SpectrumWait = True
	//        Application.DoEvents()
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

	//        'mobjController.Start(gobjclsBgFlameStatus)
	//        mobjclsBgSpectrum.SpectrumWait = False
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

	//        mobjclsBgSpectrum.SpectrumWait = True
	//        Application.DoEvents()
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
	//        'mobjController.Start(gobjclsBgFlameStatus)
	//        mobjclsBgSpectrum.SpectrumWait = False
	//        Application.DoEvents()
	//        AddHandler mnuExtinguish.Click, AddressOf btnExtinguish_Click
	//        '---------------------------------------------------------
	//    End Try
	//End Sub

	#End Region

	#End Region

	#Region " Private functions "

	private void subInitialise()
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


		//'note:
		//'this is called during the loading of a TimeScanMode.

		CWaitCursor objWait = new CWaitCursor();

		try {
			//'this is for initialisation of timescan mode
			subRearrangeFrmOBJ();
			//'this will rearrange the control on the screen
			////----- Added by Sachin Dokhale on 14.07.07
			if (!gstructSettings.ExeToRun == EnumApplicationMode.ServiceUtility) {
				if (!IsNothing(gobjMain)) {
					if (gobjMain.mobjController.IsThreadRunning == true) {
						//'stop the thread if any running
						gobjMain.mobjController.Cancel();
						gobjCommProtocol.mobjCommdll.subTime_Delay(500);
						//10.12.07
						Application.DoEvents();
					}
				}
				gobjfrmStatus.Visible = true;
				Application.DoEvents();
				//'show a status form and allow application to perfrom its panding work.
			}

			nudD2Cur.Visible = true;
			nudPMT.Visible = true;
			nudSlit.Visible = true;
			nudHCLCur.Visible = true;

			lblWvPos.Text = mXValueLable + Format(gobjInst.WavelengthCur, "#0.00");
			//---02.02.09
			//'format wavelength position
			lblWvPos.Refresh();
			cmbModes.Visible = true;
			nudBurnerHeight.IsReverseOperation = true;
			nudBurnerHeight.IsUpDownButtonToBeDisabledOnValueChange = true;
			nudFuelRatio.IsUpDownButtonToBeDisabledOnValueChange = true;

			//If gobjClsAAS203.funcCheck_Ignite() = True Then
			//    gobjfrmStatus.Visible = True
			//Else
			//    gobjfrmStatus.Visible = False
			//End If

			Application.DoEvents();
			//'allow   application to perfrom its panding work.

			if (gobjInst.Mode > -1) {
				//'set a default mode 
				cmbModes.SelectedIndex = gobjInst.Mode;
			}
			Application.DoEvents();
			funcSetDefaultSpectrumParameter(cmbModes.SelectedIndex);
			//'set a default spectrum parameter as par selected mode
			funcSetDefaultParameter();
			//'Set Spectrum Parameter
			gobjClsAAS203.funcReadFilterSetting();
			//'Read Filter Setting
			AddHandlers();
			//'this will add all the handler or event 

			gblnSpectrumTerminated = false;
			gblnSpectrumWait = false;
			this.AASGraphTimeScan.AldysPane.Legend.IsVisible = mnuLegends.Checked;
			this.Refresh();
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
			objWait.Dispose();
			//---------------------------------------------------------
		}
	}

	private void subRearrangeFrmOBJ()
	{
		//=====================================================================
		// Procedure Name        : subRearrangeFrmOBJ
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : 
		// Description           : Rearrange of the form control Object
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 21.11.06
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		//'note:
		//'this is for arranging a control on time scan screen
		//'as par alignment
		try {
			int intPanelWidth;
			int intSplitWidth;
			int intButtonWidth;
			int intStatingPoint1;
			int intStatingPoint2;
			int intStatingPoint3;
			if (gstructSettings.AppMode == EnumAppMode.FullVersion_201) {
				//'for 201
				intPanelWidth = CustomPanelBottom.Width();
				intButtonWidth = btnAutoZero.Width;
				intSplitWidth = intPanelWidth / 3;

				if (intPanelWidth > intButtonWidth) {
					intStatingPoint1 = (intSplitWidth - intButtonWidth) / 2;
					btnAutoZero.Left = intStatingPoint1;
					intStatingPoint2 = intSplitWidth + intStatingPoint1;
					cmdChangeScale.Left = intStatingPoint2;

					intStatingPoint3 = (intSplitWidth * 2) + intStatingPoint1;
					btnReturn.Left = intStatingPoint3;
				}

				btnAutoZero.Visible = true;
				cmdADJFlow.Visible = false;
				cmdADJBH.Visible = false;
				cmdChangeScale.Visible = true;
				btnReturn.Visible = true;
				nudBurnerHeight.Visible = false;
				nudFuelRatio.Visible = false;
				lblBurnerHeight.Visible = false;
				lblBurnerHeightmm.Visible = false;
				lblFuelRatio.Visible = false;
				cmbModes.Top = lblFuelRatio.Location.Y;
				//nudFuelRatio.Location.Y
				lblModes.Top = lblFuelRatio.Location.Y;

			} else {
				btnAutoZero.Visible = true;
				cmdADJFlow.Visible = true;
				cmdADJBH.Visible = true;
				cmdChangeScale.Visible = true;
				btnReturn.Visible = true;
				nudBurnerHeight.Visible = true;
				nudFuelRatio.Visible = true;
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
			//'destructor
			//---------------------------------------------------------
		}
	}

	private void AddHandlers()
	{
		//=====================================================================
		// Procedure Name        : AddHandlers
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : To add event handlers to controls
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh
		// Created               : 15.11.06
		// Revisions             : 
		//=====================================================================
		try {
			//'note:
			//'this would called durinf the loading.
			//'this will add a event handler for e.g

			cmbModes.SelectedIndexChanged += cmbModes_SelectedIndexChanged;

			btnReturn.Click += mnuExit_Click;
			//'mnuExit_Click is called after clicking on return button.
			cmdbtnReturn.Click += mnuExit_Click;
			cmdbtnChangeScale.Click += cmdChangeScale_Click;
			cmdbtnAutoZero.Click += btnAutoZero_Click;
			cmdbtnAdjBurnerHt.Click += cmdADJBH_Click;

			cmdbtnAdjFuelFlow.Click += cmdADJFlow_Click;
			btnAutoZero.Click += btnAutoZero_Click;
			btnClearSpectrum.Click += btnClearSpectrum_Click;

			nudFuelRatio.ValueEditorValueChanged += nudFuelRatio_ValueChanged;
			nudFuelRatio.ValueEditorClick += nudFuelRatio_ValueEditorClick;

			nudBurnerHeight.ValueEditorValueChanged += nudBurnerHeight_ValueChanged;
			nudBurnerHeight.ValueEditorClick += nudBurnerHeight_ValueEditorClick;

			nudD2Cur.ValueEditorValueChanged += nudD2Cur_ValueChanged;
			nudD2Cur.ValueEditorClick += nudD2Cur_ValueEditorClick;

			nudHCLCur.ValueEditorValueChanged += nudHCLCur_ValueChanged;
			nudHCLCur.ValueEditorClick += nudHCLCur_ValueEditorClick;

			nudSlit.ValueEditorValueChanged += nudSlit_ValueChanged;
			nudSlit.ValueEditorClick += nudSlit_ValueEditorClick;

			nudPMT.ValueEditorValueChanged += nudPMT_ValueChanged;
			nudPMT.ValueEditorClick += nudPMT_ValueEditorClick;

			cmdChangeScale.Click += cmdChangeScale_Click;
			btnLampParameters.Click += btnLampParameters_Click;
			AASGraphTimeScan.GraphScaleChanged += AASGraphTimeScan_GraphScaleChanged;
			//AddHandler mnuIgnite.Click, AddressOf btnAutoIgnition_Click
			//AddHandler mnuExtinguish.Click, AddressOf btnExtinguish_Click

			mnuChangeScale.Click += cmdChangeScale_Click;
			mnuReturn.Click += mnuExit_Click;
			mnuAutoZero.Click += btnAutoZero_Click;
			mnuAdjustBurnerHeight.Click += cmdADJBH_Click;
			mnuAdjustFuel.Click += cmdADJFlow_Click;


			//Menu for Graph Options
			mnuPeakEdit.Click += mnuPeakEdit_Click;
			mnuGrid.Click += mnuGrid_Click;
			mnuShowXYValues.Click += mnuShowXYValues_Click;
			mnuLegends.Click += mnuLegends_Click;

			//Tlbbtn for Graph Options
			tlbbtnGrid.Click += mnuGrid_Click;
			tlbbtnLegends.Click += mnuLegends_Click;
			btnDelete.Click += btnDelete_Click;
			btnR.Click += btnR_Click;

			btnIgnite.Click += btnIgnite_Click;
			btnExtinguish.Click += btnExtinguish_Click;
			btnN2OIgnite.Click += btnN2OIgnite_Click;


		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
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

	private void subAutoZeroScan()
	{
		//=====================================================================
		// Procedure Name        : subAutoZeroScan
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : to start the auto zero
		// Description           : this will called after clicking on auto zero button.
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 07.10.06
		// Revisions             : 
		//=====================================================================
		//Dim objWait As New CWaitCursor

		try {
			//If mblnAvoidProcessing = True Then
			//    Exit Sub
			//End If
			gblnSpectrumWait = true;
			//'put spectrum on wait
			Application.DoEvents();
			//'allow application to perfrom its panding work.
			//'RemoveHandler  is a keyword for removing a event from control 
			nudPMT.ValueEditorValueChanged -= nudPMT_ValueChanged;
			nudD2Cur.ValueEditorValueChanged -= nudD2Cur_ValueChanged;
			nudHCLCur.ValueEditorValueChanged -= nudHCLCur_ValueChanged;

			//Call func_Enable_Disable(EnumProcesses.StartScan, EnumStart_End.Start_of_Process)

			gobjClsAAS203.subAutoZero(true);
			//'To set Auto Zero for AA,BGC and Emission Mode
			switch (gobjInst.Mode) {
				case EnumCalibrationMode.AA:
					//funcSetPmtVParameter(gobjInst.PmtVoltage - 5)
					nudPMT.Value = gobjInst.PmtVoltage;
				case EnumCalibrationMode.AABGC:
				//funcSetHCL_CurParameter(gobjInst.Current - 0.1)
				//funcSetD2_CurParameter(gobjInst.D2Current - 0.1)
				//funcSetPmtVParameter(gobjInst.PmtVoltage - 5)
			}
			nudPMT.Value = gobjInst.PmtVoltage;
			//'show PMT voltage at screen
			nudHCLCur.Value = gobjInst.Current;
			//'show Current on screen
			if (gstructSettings.D2Gain == true) {
				//'for D2 gain
				cmdD2GainStatus.Visible = true;
				if (gobjCommProtocol.funcIsD2GainOn == 0x1) {
					//this is a function for checking D2 gain
					cmdD2GainStatus.Text = "D2 Gain On";
				} else if (gobjCommProtocol.funcIsD2GainOn == 0x0) {
					cmdD2GainStatus.Text = "D2 Gain Off";
				}
			}
			nudD2Cur.Value = gobjInst.D2Current;
			//'show a D2 current on screen
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
			//If Not objWait Is Nothing Then
			//    objWait.Dispose()
			//End If
			nudPMT.ValueEditorValueChanged += nudPMT_ValueChanged;
			nudD2Cur.ValueEditorValueChanged += nudD2Cur_ValueChanged;
			nudHCLCur.ValueEditorValueChanged += nudHCLCur_ValueChanged;

			gblnSpectrumWait = false;
			//'reset the spectrum
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	private void subStopScan()
	{
		//=====================================================================
		// Procedure Name        : subStartScan
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : to stop a scan by stoping a thread
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
			mobjclsBgSpectrum.ThTerminate = true;
			//'this will allow spectrum to stop
			if (!gobjclsTimer == null) {
				gobjclsTimer.subTimerStop();
				//'stop a timer.
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
		// Purpose               : to clear a scan
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 07.10.06
		// Revisions             : 
		//=====================================================================
		//'note:
		//'this is used to clear the spectrum.
		CWaitCursor objWait = new CWaitCursor();

		try {
			//If mblnAvoidProcessing = True Then
			//    Exit Sub
			//End If
			gblnSpectrumWait = true;
			//'put spectrum on wait
			Application.DoEvents();
			//'allow application to perfrom its panding work.
			funcClearGraph();
		//'for clear the graph

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
			gblnSpectrumWait = false;
			Application.DoEvents();
			//'allow application to perfrom its panding work.
			if (!objWait == null) {
				objWait.Dispose();
				//'destructor.
			}
			//---------------------------------------------------------
		}
	}

	private void subSmoothGraph()
	{
		//=====================================================================
		// Procedure Name        : subSmoothGraph
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : for smooth graph 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 16.10.06
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		//'note;
		//'this is called when user click smooth graph 

		try {
			Channel objchanel0;
			//'class Channel is like a data structure to hold a current spectrum data
			//'and later we modified it for smooth represention

			if (mblnAvoidFormProcessing == true) {
				return;
			}

			objchanel0 = mobjSpectrum.funcCloneESChannel(mobjChannnels(mintChannelIndex));
			//Add the channel data to the Channels object
			// with the readings collection as MAX_RANGE
			//'now objchanel0  we had a spectrum data 
			if (!(objchanel0) == null) {
				mobjSpectrum.funcSmooth1(objchanel0, 0);
				//'function for smoothing a graph 
				//'we have to pass Source channel,Destination channel for smoothing.
				mobjChannnels(mintChannelIndex) = mobjSpectrum.funcCloneESChannel(objchanel0);
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
		// Purpose               : to find a peak valley
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 14.12.06
		// Revisions             : 
		//=====================================================================
		//Dim objWait As New CWaitCursor
		DataTable objDataTable = new DataTable();
		//'obj for datatable for holding temp data
		Channel objPeakVallyChannel;
		//'this is a object of channel(data structure for holding a spectrum data)
		int intCounter = 0;
		long lngPeakValleyCounts;
		//'variable for valley count

		try {
			if (mblnAvoidFormProcessing == true) {
				//'flag for avoid process
				return;
			}
			mblnAvoidFormProcessing = true;
			if (!(mobjChannnels.item(mintChannelIndex) == null)) {
				//'if data is present in a data structure
				if (mobjSpectrum.funcPeaks(mobjChannnels.item(mintChannelIndex), mStuctPeaksValley) == false) {
					//'function for find a peak we have to pass a data structure holding a data and a structure
					gobjMessageAdapter.ShowMessage(constErrorPeakValley);
					//'shows the peak not found message.
					//MsgBox("Error in Peak Valley Methods", MsgBoxStyle.Critical)
				}
			} else {
				return;
			}
			//--- Check for Peak-Valley points
			if (mobjSpectrum.PeakValleyCount <= 0) {
				//Call gFuncShowMessage("Peak Pick", "No Peaks Or Valleys detected.", EnumMessageType.Information)
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
			objPeakVallyChannel = new Channel(true);
			//'made a new obj to datastructure channel

			if (!mobjSpectrum.funcGetDataPeakPickResults(objDataTable, mStuctPeaksValley, lngPeakValleyCounts, objPeakVallyChannel)) {
				//'this will get a result of peakpick in a objDataTable .

				//gFuncShowMessage("Error...", "Error in populating the peak valley data in the data table to display on the screen.", EnumMessageType.Information)'138
			}

			frmPeakPicks frmPeakPick = new frmPeakPicks();
			//'new obj to form peak
			frmPeakPick.funcDisplayPicPeakResults(objDataTable);
			//'for display a peak result from objDataTable


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

			frmPeakPick.Dispose();
			//'destructor

			subClearScan();
		//'clears the scan
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			mblnAvoidFormProcessing = false;
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
		// Purpose               : for changing a lamp parameter  
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 07.12.06
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		frmChangeLampParameters objfrmChangeLampPara = new frmChangeLampParameters();
		//'obj to form lamp parameter
		try {
			//If mblnAvoidProcessing = True Then
			//    Exit Sub
			//End If
			//mblnAvoidProcessing = True
			gblnSpectrumWait = true;
			//'allow spectrum to wait
			Application.DoEvents();
			//'allow application to perfrom panding task

			if (objfrmChangeLampPara.ShowDialog() == DialogResult.OK) {
				//'show the dilog and accept a new value of HCL current
				nudHCLCur.Value = gobjInst.Current;
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
			objfrmChangeLampPara.Dispose();
			//'destructor
			gblnSpectrumWait = false;
			Application.DoEvents();
			if (!objWait == null) {
				objWait.Dispose();
			}

			//mblnAvoidProcessing = False
			//---------------------------------------------------------
		}
	}

	private bool funcSetParameter()
	{
		//=====================================================================
		// Procedure Name        : funcSetParameter
		// Parameters Passed     : None
		// Returns               : True, if success
		// Purpose               : 
		// Description           : Set Spectrum Parameter
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 21.11.06
		// Revisions             : praveen deshmukh 
		//=====================================================================
		int intMaxD2Current;
		int intMinD2Current;
		//'note:
		//'this function set all the parameter to collection
		//'this is a bool function so if it get succeed it return true
		try {
			funcSetParameter = false;


			////----- Set the default parameter to the spectrum.
			///----- Set the Form object parameter
			////----- Set PMT Object

			//If (gobjInst.Mode = EnumCalibrationMode.MABS) Or (gobjInst.Mode = EnumCalibrationMode.AA) Or (gobjInst.Mode = EnumCalibrationMode.AABGC) Or (gobjInst.Mode = EnumCalibrationMode.AABGCSR) Then
			//    nudD2Cur.Enabled = True
			//Else
			//    nudD2Cur.Enabled = False
			//End If

			if (mobjChannnels(mintChannelIndex).ChannelNo > -1) {
				//'set the value of PMT from data structure to screen

				//nudPMT.Value = gobjInst.PmtVoltage
				nudPMT.Value = mobjChannnels(mintChannelIndex).EnegryParameter.PMTV();
				//'for eg this take a PMT value from data structure and set to PMT value
				//'and so on 

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
				nudSlit.Value = mobjChannnels(mintChannelIndex).EnegryParameter.SlitWidth;
				//'set a slitwidth at screen
				nudBurnerHeight.Value = mobjChannnels(mintChannelIndex).EnegryParameter.BurnerHeight;
				//'set a burner height at screen
				nudFuelRatio.Value = mobjChannnels(mintChannelIndex).EnegryParameter.FualRatio;
				//'set a fuelratio at screen
				nudHCLCur.Value = mobjChannnels(mintChannelIndex).EnegryParameter.HCLCurr;
				//'set a HCL current at screen


				////-----

				cmbModes.SelectedIndex = mobjChannnels(mintChannelIndex).EnegryParameter.Cal_Mode();

			}
			Application.DoEvents();
			//'allow application to perfrom its panding work
			funcSetParameter = true;
		//'returning true if successful

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
		// Returns               : True, if success
		// Purpose               : 
		// Description           :this is for getting  Instrument Parameter and display it on screen.
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 21.11.06
		// Revisions             : 
		//=====================================================================
		int intMaxD2Current;
		int intMinD2Current;
		//'note:
		//'this is for getting  Instrument Parameter form ginst object and display it on screen

		try {
			funcGetInstParameter = false;


			////----- Set the default parameter to the spectrum.
			///----- Set the Form object parameter
			////----- Set PMT Object

			//--- Set issue for Speed 
			//If gblnSetSpeedIssue = True Then
			////----- added by Sachin dokhale to remove handlers
			//28.09.07
			nudFuelRatio.ValueEditorValueChanged -= nudFuelRatio_ValueChanged;
			nudFuelRatio.ValueEditorClick -= nudFuelRatio_ValueEditorClick;

			nudBurnerHeight.ValueEditorValueChanged -= nudBurnerHeight_ValueChanged;
			nudBurnerHeight.ValueEditorClick -= nudBurnerHeight_ValueEditorClick;

			nudD2Cur.ValueEditorValueChanged -= nudD2Cur_ValueChanged;
			nudD2Cur.ValueEditorClick -= nudD2Cur_ValueEditorClick;

			nudHCLCur.ValueEditorValueChanged -= nudHCLCur_ValueChanged;
			nudHCLCur.ValueEditorClick -= nudHCLCur_ValueEditorClick;

			nudSlit.ValueEditorValueChanged -= nudSlit_ValueChanged;
			nudSlit.ValueEditorClick -= nudSlit_ValueEditorClick;

			nudPMT.ValueEditorValueChanged -= nudPMT_ValueChanged;
			nudPMT.ValueEditorClick -= nudPMT_ValueEditorClick;
			////-----
			//End If

			//If mobjChannnels(mintChannelIndex).ChannelNo > -1 Then


			nudPMT.Value = gobjInst.PmtVoltage;
			//'for eg hare PMT voltage from gobjinst is displayed at screen
			//'and so on 
			//'gobjInst is a global instrument object containing instrument para

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

			//nudD2Cur.Value = mobjChannnels(mintChannelIndex).EnegryParameter.D2Curr
			////-----

			////----- Set Slit width Object
			//nudSlit.Value = mobjChannnels(mintChannelIndex).EnegryParameter.SlitWidth
			nudSlit.Value = gobjClsAAS203.funcGet_SlitWidth();
			//'for getting a slitwidth

			//nudBurnerHeight.Value = mobjChannnels(mintChannelIndex).EnegryParameter.BurnerHeight
			nudBurnerHeight.Value = gobjClsAAS203.funcReadBurnerHeight();
			//'for getting a burnerheight

			//nudFuelRatio.Value = mobjChannnels(mintChannelIndex).EnegryParameter.FualRatio
			//funcSetFuelParameter(0) '---16.05.10
			funcSetFuelParameter(mdblFuelRatio);
			//---16.05.10
			mdblFuelRatio = Format(mdblFuelRatio, "#.00");
			nudFuelRatio.Value = Format(mdblFuelRatio, "#.00");
			///'for getting a fuelratio

			//nudHCLCur.Value = mobjChannnels(mintChannelIndex).EnegryParameter.HCLCurr
			nudHCLCur.Value = gobjInst.Current;
			//'for getting a HCL current
			if (!(mobjParameters == null)) {
				//'copy a parameter from gobjInst to mobjParameters
				mobjParameters.PMTV = gobjInst.PmtVoltage;
				//'copy a PMT voltage
				mobjParameters.HCLCurr = gobjInst.Current;
				//'copy a HCL current
				mobjParameters.SlitWidth = Val(nudSlit.Value);
				//'copy a slit width
				mobjParameters.D2Curr = gobjInst.D2Current;
				//'copy a D2 curr
				mobjParameters.BurnerHeight = (double)nudBurnerHeight.Value;
				//'copy a burner height
				mobjParameters.FualRatio = Format(mdblFuelRatio, "#.00");
				//'copy a fuel ratio.
			}
			////-----

			//--- Set issue for Speed 
			//If gblnSetSpeedIssue = True Then
			////----- added by Sachin dokhale to add handlers
			//28.09.07
			nudFuelRatio.ValueEditorValueChanged += nudFuelRatio_ValueChanged;
			nudFuelRatio.ValueEditorClick += nudFuelRatio_ValueEditorClick;

			nudBurnerHeight.ValueEditorValueChanged += nudBurnerHeight_ValueChanged;
			nudBurnerHeight.ValueEditorClick += nudBurnerHeight_ValueEditorClick;

			nudD2Cur.ValueEditorValueChanged += nudD2Cur_ValueChanged;
			nudD2Cur.ValueEditorClick += nudD2Cur_ValueEditorClick;

			nudHCLCur.ValueEditorValueChanged += nudHCLCur_ValueChanged;
			nudHCLCur.ValueEditorClick += nudHCLCur_ValueEditorClick;

			nudSlit.ValueEditorValueChanged += nudSlit_ValueChanged;
			nudSlit.ValueEditorClick += nudSlit_ValueEditorClick;

			nudPMT.ValueEditorValueChanged += nudPMT_ValueChanged;
			nudPMT.ValueEditorClick += nudPMT_ValueEditorClick;
			//End If
			////---
			Application.DoEvents();
			//'allow instrument to perfrom its panding work
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
		// Parameters Passed     : intSpeed  , this is a speed which has to be set.
		// Returns               : Boolean, if succed then true else false
		// Purpose               : to set a given speed to instrument
		// Description           : Set scan Speed
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 22.11.06
		// Revisions             : 
		//=====================================================================

		try {
			funcSetSpeed = false;
			//'note:
			//'set the speed as par user passed
			switch (intSpeed) {
				case 0:
					//50.0
					mobjParameters.ScanSpeed = CONST_FASTStep;
				case 1:
					//25.0
					mobjParameters.ScanSpeed = CONST_MEDIUMStep;
				case 2:
					//5.0
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

	//Private Sub subLabelDisplay(ByVal objChannel As Spectrum.Channel)
	//    ''not in used.
	//    Try
	//        'Select Case objChannel.Parameter.ScanSpeed
	//        '    Case EnumScanSpeed.Fast
	//        '        lblScanSpeed.Text = CONST_SCAN_SPEED_FAST
	//        '    Case EnumScanSpeed.Medium
	//        '        lblScanSpeed.Text = CONST_SCAN_SPEED_MEDIUM
	//        '    Case EnumScanSpeed.Slow
	//        '        lblScanSpeed.Text = CONST_SCAN_SPEED_SLOW
	//        '    Case EnumScanSpeed.VerySlow
	//        '        lblScanSpeed.Text = CONST_SCAN_SPEED_VERY_SLOW
	//        'End Select

	//        'lblAnalystName.Text = objChannel.Parameter.AnalystName
	//        'lblAnalystName.Refresh()
	//        'lblSpectrumName.Text = objChannel.Parameter.ChannelName
	//        'lblSpectrumName.Refresh()
	//        'added and commented by kamal on 19March2004
	//        '----------------------------
	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        'Error Handling and logging
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = ex.Message
	//        gobjErrorHandler.WriteErrorLog(ex)
	//        'gobjErrorHandler.ProcessError(ErrorHandler.EnumErrorType.Critical, ex)
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

	private int funcAddChannelToCollection(ref Spectrum.Channel objInChannel)
	{
		//=====================================================================
		// Procedure Name        :   funcAddChannelToCollection
		// Description           :   Add the channel to the channels collection
		//                           mobjChannels to the next index of the current 
		//                           active index of the channel.
		// Purpose               :   To add the channel object to the channels
		//                           collection (stored in the module level).
		// Parameters Passed     :   pass a object of channel to be passed.
		// Returns               :   new index of the channel added.
		// Parameters Affected   :   objInChannel
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
			//'get a totalnumber of channel from data structure
			objInChannel.ChannelNo = intChannel_no;

			if (mobjChannnels.Count > 0) {
				mobjChannnels.item(0) = objInChannel;
			} else {
				mobjChannnels.Add(objInChannel);
			}

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

	//Private Function funcCloneParameter(ByVal inobjparamter As Spectrum.EnergySpectrumParameter) As Spectrum.EnergySpectrumParameter
	//    '=====================================================================
	//    ' Procedure Name        : funcCloneParameter
	//    ' Parameters Passed     : inobjparamter is Energy Spectrum Parameter
	//    ' Returns               : Spectrum.EnergySpectrumParameter
	//    ' Purpose               : 
	//    ' Description           : to make a clone for object.
	//    ' Assumptions           : 
	//    ' Dependencies          : 
	//    ' Author                : Sachin Dokhale
	//    ' Created               : 21.11.06
	//    ' Revisions             : 
	//    '=====================================================================
	//    ''this will make a clone of instrument parameter
	//    ''we have to pass object to be clone
	//    ''and this will return a object having all parameter clone copy
	//    Try
	//        Dim objCloneParameter As New EnergySpectrumParameter
	//        '----------------------Cloning  parameter object ----------------------------------
	//        objCloneParameter.AnalysisDate = inobjparamter.AnalysisDate
	//        ''make a clone of AnalysisDate 
	//        objCloneParameter.BurnerHeight = inobjparamter.BurnerHeight
	//        ''make a clone of burner height
	//        objCloneParameter.FualRatio = inobjparamter.FualRatio
	//        ''make a clone of fuel ratio
	//        objCloneParameter.HCLCurr = inobjparamter.HCLCurr
	//        ''make a clone of HCL current
	//        objCloneParameter.LampEle = inobjparamter.LampEle
	//        ''make a clone of lamp element
	//        objCloneParameter.LampTurrNo = inobjparamter.LampTurrNo
	//        ''make a clone of lamp turrert no
	//        objCloneParameter.Cal_Mode = inobjparamter.Cal_Mode
	//        ''make a clone of calibration mode.
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

	//Private Function funcAbsConvertTransmission() As Boolean
	//    '=====================================================================
	//    ' Procedure Name        :   funcAddChannelToCollection
	//    ' Description           :   
	//    ' Purpose               :   
	//    ' Parameters Passed     :   None.
	//    ' Returns               :   Boolean
	//    ' Parameters Affected   :   None.
	//    ' Assumptions           :   None.
	//    ' Dependencies          :   None. 
	//    ' Author                :   Sachin Dokhale
	//    ' Created               :   13.12.06
	//    ' Revisions             :
	//    '=====================================================================
	//    Dim dblCurrYaxis As Double
	//    Dim dblNewYaxis As Double
	//    Dim intXaxisIdx As Double

	//    Try
	//        gblnUVABS = False
	//        If mobjChannnels.Count > 0 Then
	//            If mobjChannnels.item(mintChannelIndex).Spectrums.Count > 0 Then
	//                'For intXaxisIdx = gFuncGetIndexWv(mobjChannnels.item(mintChannelIndex).UVParameter.XaxisMin, False) To gFuncGetIndexWv(mobjChannnels.item(mintChannelIndex).UVParameter.XaxisMax, False)
	//                For intXaxisIdx = 0 To mobjChannnels.item(mintChannelIndex).Spectrums.item(0).Readings.Count - 1
	//                    dblCurrYaxis = mobjChannnels.item(mintChannelIndex).Spectrums.item(0).Readings.item(intXaxisIdx).YaxisData
	//                    'k= 2047.0 + exp((2.0- ((addata.ad[i]-2047.0)*2.0/1638.4)) *log(10))*2048.0/100.0;
	//                    dblNewYaxis = 2047.0 + Math.Exp((2.0 - ((dblCurrYaxis - 2047.0) * 2.0 / 1638.4)) * Math.Log(10)) * 2048.0 / 100.0
	//                    mobjChannnels.item(mintChannelIndex).Spectrums.item(0).Readings.item(intXaxisIdx).YaxisData = dblNewYaxis
	//                Next
	//            End If
	//        End If
	//        funcClearGraph()

	//        mobjChannnels.item(mintChannelIndex).UVParameter.YaxisMax = 100
	//        mobjChannnels.item(mintChannelIndex).UVParameter.YaxisMin = 0

	//        funcDisplayGraph(mobjChannnels.item(mintChannelIndex))
	//        Return True
	//        '           if (addata.ad!=NULL) {
	//        ' for (i=0; i<addata.counter; i++){
	//        ' k= 2047.0 + exp((2.0- ((addata.ad[i]-2047.0)*2.0/1638.4)) *log(10))*2048.0/100.0;
	//        ' addata.ad[i] =k;
	//        '}
	//        ' UVABS=FALSE;
	//        ' SpectGraph.Ymin = 0;
	//        ' SpectGraph.Ymax = 100;
	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        'Error Handling and logging
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = ex.Message
	//        gobjErrorHandler.WriteErrorLog(ex)
	//        'gobjErrorHandler.ProcessError(EnumErrorType.Critical, ex)
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

	private bool funcSetDefaultSpectrumParameter(int intCalibrationMode)
	{
		//=====================================================================
		// Procedure Name        : funcSetDefaultSpectrumParameter
		// Parameters Passed     : intCalibrationMode,this is a mode of calibration
		// Returns               : true if succed
		// Purpose               : for setting default parameter
		// Description           :this is called for Setting default Spectrum Parameter
		// Assumptions           : calibration mode is present
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 21.11.06
		// Revisions             : 
		//=====================================================================
		static bool blnSetDefaultSpectrumParameter;
		//'bool datatype blnSetDefaultSpectrumParameter 

		try {
			funcSetDefaultSpectrumParameter = false;
			////----- Set the default parameter to the spectrum.
			if ((gobjInst.Mode == intCalibrationMode) & (blnSetDefaultSpectrumParameter == true)) {
				//'check whatever given mode is correct or not
				funcSetDefaultSpectrumParameter = true;
				return;
			}

			if (gobjCommProtocol.funcCalibrationMode(intCalibrationMode)) {
				//'this is a serial communication function for setting given calibration mode to instrument.
				//If (gobjInst.Mode = EnumCalibrationMode.MABS) Or (gobjInst.Mode = EnumCalibrationMode.AA) Or (gobjInst.Mode = EnumCalibrationMode.AABGC) Or (gobjInst.Mode = EnumCalibrationMode.AABGCSR) Then
				//    nudD2Cur.Enabled = True
				//Else
				//    nudD2Cur.Enabled = False
				//End If
				//addataSpect.dblWvMin = 230.0
				//addataSpect.dblWvMax = 250.0
				mobjParameters.XaxisMin = 0;
				mobjParameters.XaxisMax = 100.0;
				//'set a graph X-axis default scale
				switch (gobjInst.Mode) {
					//'set a default parameter as par calibration mode
					case EnumCalibrationMode.AA:
					case EnumCalibrationMode.AABGC:
					case EnumCalibrationMode.MABS:
						//'set a default parameter as par calibration mode
						mobjParameters.YaxisMax = const_YMaxAbs;
						mobjParameters.YaxisMin = const_YMinAbs;
						mYValueLable = const_Absorbance;
					case EnumCalibrationMode.HCLE:
					case EnumCalibrationMode.D2E:
						//'set a default parameter as par calibration mode
						mobjParameters.YaxisMin = const_YMinEnergy;
						mobjParameters.YaxisMax = const_YMaxEnergy;
						mYValueLable = const_Energy;
					case EnumCalibrationMode.EMISSION:
						//'set a default parameter as par calibration mode
						mobjParameters.YaxisMin = const_YMinEmission;
						mobjParameters.YaxisMax = const_YMaxEmission;
						mYValueLable = const_Emission;
					case EnumCalibrationMode.SELFTEST:
						//'set a default parameter as par calibration mode
						mobjParameters.YaxisMin = const_YMinmVolt;
						mobjParameters.YaxisMax = const_YMaxmVolt;
						mYValueLable = const_Volt;
				}

				//addataSpect.intSpeed = 0
				//addataSpect.intMode = gobjInst.Mode



				mobjParameters.ScanSpeed = CONST_SLOWStep;
				//'set a speed
				mobjParameters.Cal_Mode = gobjInst.Mode;
				//'set a calibration mode.
				//addataSpect.blnPloted = True
				////-----
				AASGraphTimeScan.AldysPane.Legend.IsVisible = false;
				funcClearGraph();
				//'for clear a graph

				funcGraphPreRequisite(mobjParameters.Cal_Mode, mobjParameters.XaxisMin, mobjParameters.XaxisMax, mobjParameters.YaxisMin, mobjParameters.YaxisMax);
				//'for setting a time scan graph as par user defined calibration mode 
				blnSetDefaultSpectrumParameter = true;
				funcSetDefaultSpectrumParameter = true;
				gobjClsAAS203.Calculate_Analysis_Graph_Param(AASGraphTimeScan, ClsAAS203.enumChangeAxis.xyAxis);
				//Added by Saurabh 03.08.07
				//'for calculating a graph parameter.
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
		// Procedure Name        : funcSetDefaultSpectrumParameter
		// Parameters Passed     : intCalibrationMode  
		// Returns               : True if success
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
			if ((gobjInst.Mode == intCalibrationMode)) {
				//'check for given calibration mode
				funcSetSpectrumParameter = true;
				return;
			}

			if (gobjCommProtocol.funcCalibrationMode(intCalibrationMode)) {
				//'serial communication function for setting given calibration mode to instrument

				//If (gobjInst.Mode = EnumCalibrationMode.MABS) Or (gobjInst.Mode = EnumCalibrationMode.AA) Or (gobjInst.Mode = EnumCalibrationMode.AABGC) Or (gobjInst.Mode = EnumCalibrationMode.AABGCSR) Then
				//    nudD2Cur.Enabled = True
				//Else
				//    nudD2Cur.Enabled = False
				//End If
				//addataSpect.dblWvMin = 230.0
				//addataSpect.dblWvMax = 250.0

				switch (gobjInst.Mode) {
					//'setting parameter as par calibration mode
					case EnumCalibrationMode.AA:
					case EnumCalibrationMode.AABGC:
					case EnumCalibrationMode.MABS:
						//'setting parameter as par calibration mode

						mobjParameters.YaxisMax = const_YMaxAbs;
						mobjParameters.YaxisMin = const_YMinAbs;
						mYValueLable = const_Absorbance;
					case EnumCalibrationMode.HCLE:
					case EnumCalibrationMode.D2E:
						//'setting parameter as par calibration mode

						mobjParameters.YaxisMin = const_YMinEnergy;
						mobjParameters.YaxisMax = const_YMaxEnergy;
						mYValueLable = const_Energy;
					case EnumCalibrationMode.EMISSION:
						//'setting parameter as par calibration mode

						mobjParameters.YaxisMin = const_YMinEmission;
						mobjParameters.YaxisMax = const_YMaxEmission;
						mYValueLable = const_Emission;
					case EnumCalibrationMode.SELFTEST:
						//'setting parameter as par calibration mode

						mobjParameters.YaxisMin = const_YMinmVolt;
						mobjParameters.YaxisMax = const_YMaxmVolt;
						mYValueLable = const_Volt;
				}

				mobjParameters.XaxisMin = 0;
				mobjParameters.XaxisMax = 100;

				//addataSpect.intSpeed = 0
				//addataSpect.intMode = gobjInst.Mode

				mobjParameters.Cal_Mode = gobjInst.Mode;
				//'set a calibration mode

				//addataSpect.blnPloted = True
				////-----
				AASGraphTimeScan.AldysPane.Legend.IsVisible = false;
				funcClearGraph();
				//'clear a graph
				funcGraphPreRequisite(mobjParameters.Cal_Mode, mobjParameters.XaxisMin, mobjParameters.XaxisMax, mobjParameters.YaxisMin, mobjParameters.YaxisMax);
				//'set a timescan graph as par a given value

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

	private bool funcSetSpectrumParam(int intCalibrationMode)
	{
		//=====================================================================
		// Procedure Name        : funcSetDefaultSpectrumParameter
		// Parameters Passed     : calibration mode
		// Returns               : bool
		// Purpose               : setting parameter as par calibration mode
		// Description           : Set Spectrum Parameter
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 21.11.06
		// Revisions             : 
		//=====================================================================


		try {
			double dblMajorStepY;
			double dblMinorStepY;
			double dblDiffY;

			funcSetSpectrumParam = false;
			////----- Set the default parameter to the spectrum.
			if ((gobjInst.Mode == intCalibrationMode)) {
				//'check for calibration mode exit or not.
				funcSetSpectrumParam = true;
				return;
			}

			if (gobjCommProtocol.funcCalibrationMode(intCalibrationMode)) {
				//'serial communication function for setting calibration mode.

				//addataSpect.dblWvMin = 230.0
				//addataSpect.dblWvMax = 250.0

				//Select Case gobjInst.Mode
				//    Case EnumCalibrationMode.AA, EnumCalibrationMode.AABGC, EnumCalibrationMode.MABS

				//        mobjParameters.YaxisMax = const_YMaxAbs
				//        mobjParameters.YaxisMin = const_YMinAbs
				//    Case EnumCalibrationMode.HCLE, EnumCalibrationMode.D2E
				//        mobjParameters.YaxisMin = const_YMinEnergy
				//        mobjParameters.YaxisMax = const_YMaxEnergy
				//    Case EnumCalibrationMode.EMISSION

				//        mobjParameters.YaxisMin = const_YMinEmission
				//        mobjParameters.YaxisMax = const_YMaxEmission

				//    Case EnumCalibrationMode.SELFTEST
				//        mobjParameters.YaxisMin = const_YMinmVolt
				//        mobjParameters.YaxisMax = const_YMaxmVolt
				//End Select

				//addataSpect.intSpeed = 0
				//addataSpect.intMode = gobjInst.Mode

				mobjParameters.Cal_Mode = gobjInst.Mode;
				//addataSpect.blnPloted = True
				////-----
				AASGraphTimeScan.AldysPane.Legend.IsVisible = false;
				switch (gobjInst.Mode) {
					//'set a parameter as per calibration mode
					case EnumCalibrationMode.AA:
					case EnumCalibrationMode.AABGC:
					case EnumCalibrationMode.MABS:
						//'set a parameter as per calibration mode
						mobjParameters.YaxisMax = const_YMaxAbs;
						mobjParameters.YaxisMin = const_YMinAbs;
						mYAXIS_LABEL = const_ABSORBANCE_YLabel;
						mYValueLable = const_Absorbance;
						mstrYaxisFormat = "0.000";
						mstrYaxisExt = "";
					case EnumCalibrationMode.HCLE:
					case EnumCalibrationMode.D2E:
						//'set a parameter as per calibration mode
						mobjParameters.YaxisMin = const_YMinEnergy;
						mobjParameters.YaxisMax = const_YMaxEnergy;
						mYAXIS_LABEL = const_ENERGY_YLabel;
						mYValueLable = const_Energy;
						mstrYaxisFormat = "0.00#";
						mstrYaxisExt = "";
					case EnumCalibrationMode.EMISSION:
						//'set a parameter as per calibration mode
						mobjParameters.YaxisMin = const_YMinEmission;
						mobjParameters.YaxisMax = const_YMaxEmission;
						mYAXIS_LABEL = const_EMISSION_YLabel;
						mYValueLable = const_Emission;
						mstrYaxisFormat = "0.0";
						mstrYaxisExt = "%";
					case EnumCalibrationMode.SELFTEST:
						//'set a parameter as per calibration mode
						mobjParameters.YaxisMin = const_YMinmVolt;
						mobjParameters.YaxisMax = const_YMaxmVolt;
						mYAXIS_LABEL = const_VOLT_YLabel;
						mYValueLable = const_Volt;
						mstrYaxisFormat = "0.0";
						mstrYaxisExt = "";
				}


				//AASGraphTimeScan.AldysPane.XAxis.IsMinorTic = False
				//AASGraphTimeScan.AldysPane.YAxis.IsMinorTic = False

				AASGraphTimeScan.YAxisMin = mobjParameters.YaxisMin;
				AASGraphTimeScan.YAxisMax = mobjParameters.YaxisMax;

				////----- Set auto Steps of axis
				dblDiffY = (mobjParameters.YaxisMax - mobjParameters.YaxisMin);
				dblMajorStepY = dblDiffY / 10;
				dblMinorStepY = dblMajorStepY / 2;

				AASGraphTimeScan.YAxisStep = dblMajorStepY;
				AASGraphTimeScan.YAxisMinorStep = dblMinorStepY;
				AASGraphTimeScan.YAxisLabel = mYAXIS_LABEL;

				////-----
				AASGraphTimeScan.AldysPane.AxisChange();
				AASGraphTimeScan.Refresh();
				lblYValue.Text = mYValueLable + ": ";
				lblYValue.Refresh();
				Application.DoEvents();

				//uncommented by Saurabh 05.08.07
				funcGraphPreRequisite(mobjParameters.Cal_Mode, mobjParameters.XaxisMin, mobjParameters.XaxisMax, mobjParameters.YaxisMin, mobjParameters.YaxisMax);
				//'setting graph as par new given value

				//uncommented by Saurabh 05.08.07

				//Added by Saurabh 05.08.07 To set Scale at RunTime
				gobjClsAAS203.Calculate_Analysis_Graph_Param(AASGraphTimeScan, ClsAAS203.enumChangeAxis.xyAxis);
				//Added by Saurabh 05.08.07

				funcSetSpectrumParam = true;

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
			//---------------------------------------------------------
		}
	}

	private bool funcSetDefaultParameter()
	{
		//=====================================================================
		// Procedure Name        : funcSetDefaultParameter
		// Parameters Passed     : None
		// Returns               : true if success
		// Purpose               : 
		// Description           : Set default Spectrum Parameter
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 19.12.06
		// Revisions             : 
		//=====================================================================
		int intMaxD2Current;
		int intMinD2Current;

		try {
			//'below is a "c" code 
			///---------------------------------------------------------------
			//ReinitInstParameters();
			//			 Inst =  GetInstData();
			//#If !IN203DLL Then
			//			Get_Instrument_Parameters(&Inst);
			//#End If
			//			ps.hdc=NULL;
			//			hfont = Change_Button_font(hwnd, hfont, TRUE, FALSE);
			//			InitAbsScreen(hwnd);
			//			Scroll_Pmt(hwnd,IDC_PMT, -1);
			//			if (Inst->Mode==AA || Inst->Mode ==HCLE || Inst->Mode==AABGC ||Inst->Mode==AABGCSR)
			//				Scroll_Cur(hwnd,IDC_CUR, -1 );
			//            Else
			//				EnableWindow(GetDlgItem(hwnd,IDC_CUR),FALSE);
			//			if (Inst->Mode==MABS || Inst->Mode==AA || Inst->Mode==AABGC ||Inst->Mode==AABGCSR)
			//				Scroll_D2Cur(hwnd,IDC_D2CUR, -1 );
			//                Else
			//				EnableWindow(GetDlgItem(hwnd,IDC_D2CUR),FALSE);

			//			Scroll_Slit(hwnd,IDC_SLIT, -1 );
			//			Scroll_Mode(hwnd,IDC_MODE, -1 );
			//			Scroll_Fuel(hwnd,IDC_FUEL, -1 );
			//			Scroll_Bh(hwnd,IDC_BH, -1 );
			//			for(nsel =IDC_PMTVS; nsel<=IDC_BHVS; nsel++)
			//			  SetScrollRange(GetDlgItem(hwnd, nsel), SB_CTL, 0, 1,TRUE);
			///*
			//                        If (GetSRLamp()) Then
			//			  SetWindowText(GetDlgItem(hwnd,IDC_D2CUR),"SRE:100 mA");
			//                        Else
			//			  SetWindowText(GetDlgItem(hwnd,IDC_D2CUR),"D2E:100 mA");
			//*/
			//			// mdf by sss on dt 5/12/1999 for maual D2 gain setting
			//			if(GetInstrument() != AA202 ){
			//				if(ReadIniForD2Gain()){
			//                                    If (IsD2GainOn()) Then
			//						SetWindowText(GetDlgItem(hwnd,IDC_PBD2GAIN),"D2 Gain OFF");
			//                                    Else
			//						SetWindowText(GetDlgItem(hwnd,IDC_PBD2GAIN),"D2 Gain ON");
			//				}
			//				else
			//					ShowWindow(GetDlgItem(hwnd,IDC_PBD2GAIN),SW_HIDE);
			//			}
			//			ShowWindow(hwnd,SW_SHOWMAXIMIZED);
			////			SendMessage(hwnd,WM_SHOWWINDOW,WS_MAXIMIZE,0L);
			//			//-----
			//			ReinitInstParameters();
			//			//--mdf by sk on 3/6/2001
			//			CheckMinAbsScanLmt = ReadIniForMinAbsLimit();
			//         Absscanthldval = ReadIniForAbsThresholdLimit();
			//			//--mdf by sk on 3/6/2001
			//			return TRUE;
			///--------------------------------------------------------------------
			funcSetDefaultParameter = false;
			////----- 
			//   Ini the Time scan Parameter
			//ReinitInstParameters();
			gobjClsAAS203.ReInitInstParameters();
			//'for reinitli a instrument parameter for eg D2 off
			////--------
			///----- Set the Form object parameter
			////----- Set the default parameter to the spectrum.

			//mobjParameters.Cal_Mode = gobjInst.Mode
			cmbModes.SelectedIndex = gobjInst.Mode;
			//'show selected mode on combo  box

			//mobjParameters.ScanSpeed = CONST_SLOWStep


			////----- Set PMT Object
			//Scroll_Pmt(hwnd,IDC_PMT, -1);
			//nudPMT.DecimalPlaces = 0
			nudPMT.DecimalPlace = 0;
			//nudPMT.Increment = 5.0
			nudPMT.ChangeFactor = 5.0;
			nudPMT.MaxValue = 700.0;
			//'for setting default Max pmt as 700.
			nudPMT.MinValue = 0.0;
			//'above we are setting default parameter
			nudPMT.Value = gobjInst.PmtVoltage;
			mobjParameters.PMTV = gobjInst.PmtVoltage;
			////-----
			//         if (Inst->Mode==AA || Inst->Mode ==HCLE || Inst->Mode==AABGC ||Inst->Mode==AABGCSR)
			//	Scroll_Cur(hwnd,IDC_CUR, -1 );
			//         Else
			//	EnableWindow(GetDlgItem(hwnd,IDC_CUR),FALSE);





			////----- Set D2 current Object
			if (gobjCommProtocol.SRLamp) {
				//'check for SR lamp.
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
			//'get a D2 current value.
			if (nudD2Cur.Value == 100.0) {
				nudD2Cur.Text = "D2 Off";
			}
			mobjParameters.D2Curr = gobjInst.D2Current;

			//if (Inst->Mode==MABS || Inst->Mode==AA || Inst->Mode==AABGC ||Inst->Mode==AABGCSR)
			//	Scroll_D2Cur(hwnd,IDC_D2CUR, -1 );
			//             Else
			//	EnableWindow(GetDlgItem(hwnd,IDC_D2CUR),FALSE);
			//Select Case gobjInst.Mode
			//    Case EnumCalibrationMode.AA, EnumCalibrationMode.AABGCSR, EnumCalibrationMode.AABGC
			//        nudD2Cur.Enabled = True
			//        nudHCLCur.Enabled = True
			//    Case EnumCalibrationMode.HCLE
			//        nudD2Cur.Enabled = False
			//        nudHCLCur.Enabled = True

			//        case EnumCalibrationMode.
			//    Case EnumCalibrationMode.SELFTEST

			//End Select
			//If (gobjInst.Mode = EnumCalibrationMode.MABS) Or (gobjInst.Mode = EnumCalibrationMode.AA) Or (gobjInst.Mode = EnumCalibrationMode.AABGC) Or (gobjInst.Mode = EnumCalibrationMode.AABGCSR) Then
			//    nudD2Cur.Enabled = True
			//Else
			//    nudD2Cur.Enabled = False
			//End If



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
			if ((gobjInst.Mode == EnumCalibrationMode.AA) | (gobjInst.Mode == EnumCalibrationMode.HCLE) | (gobjInst.Mode == EnumCalibrationMode.AABGC) | (gobjInst.Mode == EnumCalibrationMode.AABGCSR)) {
				nudHCLCur.Enabled = true;
			} else {
				//    nudHCLCur.Enabled = False
			}



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
			////-----

			////----- Set Fuel Ratio object
			//nudFuelRatio.DecimalPlaces = 2
			//nudFuelRatio.Increment = 0.1
			//nudFuelRatio.Maximum = 25.0
			//nudFuelRatio.Minimum = 0.0


			if (!gstructSettings.AppMode == EnumAppMode.FullVersion_201) {
				nudFuelRatio.DecimalPlace = 2;
				nudFuelRatio.ChangeFactor = 0.1;
				nudFuelRatio.MaxValue = 25.0;
				nudFuelRatio.MinValue = 0.0;

				gobjCommProtocol.funcGet_NV_Pos();
				//'serial communication function for setting NV position
				mdblFuelRatio = gobjClsAAS203.funcGet_Fuel_Ratio(true);
				//'for getting fuel ratio
				mdblFuelRatio = Format(mdblFuelRatio, "#.00");
				//'for formatting a display of fuelratio
				if (mdblFuelRatio < 0.0) {
					//'setting some validation
					nudFuelRatio.Value = 0.0;
				} else {
					nudFuelRatio.Value = mdblFuelRatio;
				}
				mobjParameters.FualRatio = mdblFuelRatio;
				////-----

				////----- Set Burner Height Object
				//nudBurnerHeight.DecimalPlaces = 2
				//nudBurnerHeight.Increment = 0.1
				//'nudBurnerHeight.Maximum = 2.0
				//nudBurnerHeight.Maximum = 6.0
				//nudBurnerHeight.Minimum = 0.0

				nudBurnerHeight.DecimalPlace = 2;
				nudBurnerHeight.ChangeFactor = 0.1;
				nudBurnerHeight.MaxValue = 6.0;
				nudBurnerHeight.MinValue = 0.0;
				mdblBhHeight = gobjClsAAS203.funcReadBurnerHeight();
				nudBurnerHeight.Value = gobjClsAAS203.funcReadBurnerHeight();
				mobjParameters.BurnerHeight = (double)nudBurnerHeight.Value;

				nudFuelRatio.Visible = true;
				nudBurnerHeight.Visible = true;
				lblFuelRatio.Visible = true;
				lblBurnerHeight.Visible = true;
				lblBurnerHeightmm.Visible = true;
				cmbModes.Visible = true;
				lblModes.Visible = true;

			////-----
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

			}

			//        if(ReadIniForD2Gain()){
			//            If (IsD2GainOn()) Then
			//		SetWindowText(GetDlgItem(hwnd,IDC_PBD2GAIN),"D2 Gain OFF");
			//            Else
			//		SetWindowText(GetDlgItem(hwnd,IDC_PBD2GAIN),"D2 Gain ON");
			//}
			if (gstructSettings.D2Gain == true) {
				cmdD2GainStatus.Visible = true;

				if (gobjCommProtocol.funcIsD2GainOn == 0x1) {
					cmdD2GainStatus.Text = "D2 Gain On";
				} else if (gobjCommProtocol.funcIsD2GainOn == 0x0) {
					cmdD2GainStatus.Text = "D2 Gain Off";
				}
			//'here we are checking D2 gain is on or off

			} else {
				cmdD2GainStatus.Visible = false;
			}
			////-----
			//mobjParameters.Cal_Mode = gobjInst.Mode
			//cmbModes.SelectedIndex = gobjInst.Mode

			//mobjParameters.ScanSpeed = CONST_SLOWStep
			////-----

			gobjClsAAS203.ReInitInstParameters();
			//'for reinitialisation of instrument
			blnCheckMinAbsScanLmt = gstructSettings.SetMinAbsLimit;
			dblAbsScanthldval = gstructSettings.AbsThresholdValue;

			funcSetDefaultParameter = true;
		//'set a functionreturning true value

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
		// Parameters Passed     : dblPmtV , value of PMT is to set
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
		//'validate a pmt value before sending it to instrument.
		double dblPMTVolt;
		double dblAdjPMTVolt;

		try {
			funcSetPmtVParameter = false;
			gblnSpectrumWait = true;
			//'put spectrum on wait
			dblPMTVolt = gobjInst.PmtVoltage;
			//'get a pmt from gobjInst to a local variable



			if (!dblPmtV == dblPMTVolt) {

				if (dblPmtV > dblPMTVolt) {
					//dblPMTVolt += 5.0
					dblAdjPMTVolt = dblPmtV - Math.Abs(dblPMTVolt);
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
					//'serial communication function for setting PMT
					//gobjInst.PmtVoltage = dblPMTVolt
					funcSetPmtVParameter = true;
				}
				//funcSetPmtVParameter = True
			}
		//'this function is for setting some validation range of pmt.
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			gblnSpectrumWait = false;
			//---------------------------------------------------------
		}
	}

	private bool funcSetHCL_CurParameter(double dblHCL_Cur)
	{
		//=====================================================================
		// Procedure Name        : funcSetHCL_CurParameter
		// Parameters Passed     : dblHCL_Cur
		// Returns               : Boolean. hcl curr which is to be set
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
			gblnSpectrumWait = true;
			//'allow spectrum to be wait
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
				//'serial communication function for setting HCL current
				gobjInst.Current = dblLampCurrent;
			}

			funcSetHCL_CurParameter = true;
		//'this is for setting a HCL current with proper range
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			gblnSpectrumWait = false;
			//---------------------------------------------------------
		}
	}

	private bool funcSetD2_CurParameter(int intD2_Cur)
	{
		//=====================================================================
		// Procedure Name        : funcSetPmtVParameter
		// Parameters Passed     : dblD2_Cur, which is to be set
		// Returns               : Boolean
		// Purpose               : 
		// Description           : Set D2 Current Parameter with proper range
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 22.11.06
		// Revisions             : 
		//=====================================================================

		//'note:
		//'this is used to set D2 current to instrument

		object intMaxD2Current = 300;
		object intMinD2Current = 100;
		int D2CurrIncrDecr;
		double intD2Lamp_Cur = 0;

		try {
			funcSetD2_CurParameter = false;
			gblnSpectrumWait = true;
			//'put spectrum on wait
			if (gobjCommProtocol.SRLamp) {
				//'set a min, max curr for SRLamp if true
				intMaxD2Current = 600;
				intMinD2Current = 100;
			} else {
				//if not
				intMaxD2Current = 300;
				intMinD2Current = 100;
			}

			intD2Lamp_Cur = gobjInst.D2Current;
			//'get a D2 Current

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
			//'serial communication function for setting D2 Current

			if (gobjCommProtocol.SRLamp) {
				//'for SR lamp
				gobjInst.D2Current = intD2Lamp_Cur;
			} else {

				if (intD2Lamp_Cur == 100) {
				}
			}

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
			gblnSpectrumWait = false;
			//---------------------------------------------------------
		}
	}

	private bool funcSetSlit_WidthParameter(double dblSlit_Width)
	{
		//=====================================================================
		// Procedure Name        : funcSetSlit_WidthParameter
		// Parameters Passed     : dblSlit_Width ,slitwidth is to be set
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
			gblnSpectrumWait = true;
			//'allow spectrum to wait
			dblSlitWidth = gobjClsAAS203.funcGet_SlitWidth();
			//'get a slit width

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
			//'serial communication function for setting SlitWidth
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
			gblnSpectrumWait = false;
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
		// Description           : for Set Fuel Parameter
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 22.11.06
		// Revisions             : 
		//=====================================================================
		try {
			funcSetFuelParameter = false;


			if (!(mdblFuelRatio == dblFuel)) {
				gobjClsAAS203.funcSetFuel((double)nudFuelRatio.Value);
				//'function for setting fuel.
			}

			//Call gobjCommProtocol.funcGet_NV_Pos()
			//'serial communication for setting fuel parameter
			mdblFuelRatio = gobjClsAAS203.funcGet_Fuel_Ratio(true);
			if (mdblFuelRatio < 0.0) {
				//'setting some validation
				mdblFuelRatio = 0.0;
			} else {
				mdblFuelRatio = Format(mdblFuelRatio, "#0.00");
			}
			//'for getting fuel ratio
			mobjParameters.FualRatio = mdblFuelRatio;

			mdblFuelRatio = Format(mdblFuelRatio, "#.00");
			//'for format 
			funcSetFuelParameter = mdblFuelRatio;

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

	//Private Function funcSetFuelParameter(ByVal dblFuel As Double) As Double
	//    '=====================================================================
	//    ' Procedure Name        : funcSetFuelParameter
	//    ' Parameters Passed     : dblFuel 
	//    ' Returns               : Double
	//    ' Purpose               : 
	//    ' Description           : Set Fuel Parameter
	//    ' Assumptions           : 
	//    ' Dependencies          : 
	//    ' Author                : Sachin Dokhale
	//    ' Created               : 22.11.06
	//    ' Revisions             : 
	//    '=====================================================================
	//    Dim dblAdjFuelRatio As Double
	//    Dim intIncrDecr As Integer
	//    Try
	//        funcSetFuelParameter = False
	//        Application.DoEvents()
	//        If Not (mdblFuelRatio = dblFuel) Then
	//            If mdblFuelRatio > dblFuel Then
	//                dblAdjFuelRatio = mdblFuelRatio - dblFuel
	//                If dblAdjFuelRatio > 0 Then
	//                    For intIncrDecr = 0 To CInt(dblAdjFuelRatio) - 1
	//                        Call gobjClsAAS203.funcIncr_Fuel()
	//                    Next

	//                End If
	//                '        dblFuelRatio = funcSetFuelParameter(-1)
	//                mdblFuelRatio = Format(mdblFuelRatio, "#.00")
	//                'nudFuelRatio.Value = Format(mdblFuelRatio, "#.00")
	//            ElseIf mdblFuelRatio < dblFuel Then
	//                dblAdjFuelRatio = dblFuel - mdblFuelRatio
	//                If dblAdjFuelRatio > 0 Then
	//                    For intIncrDecr = 0 To CInt(dblAdjFuelRatio) - 1
	//                        Call gobjClsAAS203.funcDecr_Fuel()
	//                    Next
	//                End If
	//                'dblFuelRatio = funcSetFuelParameter(1)
	//                mdblFuelRatio = Format(mdblFuelRatio, "#.00")
	//                'nudFuelRatio.Value = Format(mdblFuelRatio, "#.00")
	//            Else
	//                Call gobjCommProtocol.funcGet_NV_Pos()
	//            End If
	//        Else
	//            Call gobjCommProtocol.funcGet_NV_Pos()
	//        End If

	//        'If intFuel = 1 Then
	//        '    Call gobjClsAAS203.funcIncr_Fuel()
	//        'ElseIf intFuel = -1 Then
	//        '    Call gobjClsAAS203.funcDecr_Fuel()
	//        'Else
	//        '    Call gobjCommProtocol.funcGet_NV_Pos()
	//        'End If

	//        funcSetFuelParameter = gobjClsAAS203.funcGet_Fuel_Ratio(False)
	//        funcSetFuelParameter = mdblFuelRatio

	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        'Error Handling and logging
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = ex.Message
	//        gobjErrorHandler.WriteErrorLog(ex)
	//        Return 0.0
	//        '---------------------------------------------------------
	//    Finally
	//        '---------------------------------------------------------
	//        'Writing Execution log
	//        If CONST_CREATE_EXECUTION_LOG = 1 Then
	//            gobjErrorHandler.WriteExecutionLog()
	//        End If
	//        gblnSpectrumWait = False
	//        '---------------------------------------------------------
	//    End Try
	//End Function

	private double funcSetBurner_HeightParameter(double dblBurner_Height)
	{
		//=====================================================================
		// Procedure Name        : funcSetBurner_HeightParameter
		// Parameters Passed     : dblBurner_Height is to be set 
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
			mobjclsBgSpectrum.SpectrumWait = true;
			//'allow spectrum to wait during the process
			funcSetBurner_HeightParameter = 0.0;
			//If dblBhHeight > intBurner_Height Then
			//    'dblBhHeight = funcSetBurner_HeightParameter(-1)

			//    dblBhHeight = Format(intBurner_Height, "#.00")
			//    nudBurnerHeight.Value = Format(intBurner_Height, "#.00")
			//ElseIf dblBhHeight < nudBurnerHeight.Value Then
			//    dblBhHeight = funcSetBurner_HeightParameter(1)
			//    dblBhHeight = Format(dblBhHeight, "#.00")
			//    nudBurnerHeight.Value = Format(dblBhHeight, "#.00")
			//End If

			//If intBurner_Height = 1 Then
			//    Call gobjClsAAS203.funcIncr_Height()
			//ElseIf intBurner_Height = -1 Then
			//    Call gobjClsAAS203.funcDecr_Height()
			//Else
			//    gobjCommProtocol.func_Get_BH_Pos()
			//End If

			gobjClsAAS203.funcSetBHPos(FormatNumber(dblBurner_Height, 1));
			//for setting burner height as par given value
			mdblBhHeight = gobjClsAAS203.funcReadBurnerHeight();
			//'for getting burner height
			funcSetBurner_HeightParameter = mdblBhHeight;
			mobjclsBgSpectrum.SpectrumWait = false;
			gblnSpectrumWait = false;
		//'reset a spectrum.
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			gblnSpectrumWait = false;
			mobjclsBgSpectrum.SpectrumWait = false;
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			//gblnSpectrumWait = False
			//---------------------------------------------------------
		}
	}

	private void subD2GainSatus()
	{
		//=====================================================================
		// Procedure Name        :   subD2GainSatus
		// Description           :   
		// Purpose               :   for checking a status of D2 gain
		//                           
		// Parameters Passed     :   None
		// Returns               :   None
		// Parameters Affected   :   
		// Assumptions           :   
		// Dependencies          :   None.
		// Author                :   Sachin Dokhale 
		// Created               :   10.12.06
		// Revisions             :
		//=====================================================================
		try {
			gblnSpectrumWait = true;
			//'put spectrum on wait
			if (gstructSettings.D2Gain == true) {
				//'for D2 gain
				if (gobjCommProtocol.funcIsD2GainOn == 0x1) {
					if (gobjCommProtocol.funcGain10X_OFF == true) {
						//'put off 
						cmdD2GainStatus.Text = "D2 &Gain On";
					}


				} else if (gobjCommProtocol.funcIsD2GainOn == 0x0) {
					if (gobjCommProtocol.funcGain10X_ON == true) {
						//'put on.
						cmdD2GainStatus.Text = "D2 &Gain Off";
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
			gblnSpectrumWait = false;
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
		mblnAvoidProcessing = true;

		//=====================================================================
		// Procedure Name        : funcOnSpect
		// Parameters Passed     : baseline status, lblScanStatus as label object, lblOnlineWv label object, 
		// Returns               : bool
		// Purpose               : for starting a time scan spectrum by starting a thread.
		// Description           : Set Spectrum Parameter
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 21.11.06
		// Revisions             : 
		//=====================================================================
		//'note:
		///here BaseLine is a flag which is true if baseline is completed and false if not
		//'this is a main function which start the TimeScan Spectrum routin.

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


		//'for starting a spectrum
		//Dim ObjParameter As New Spectrum.EnergySpectrumParameter

		mobjOnlineChannel = new Spectrum.Channel(true);
		//'object for data structure
		//ObjParameter = funcCloneParameter(mobjParameters)
		//'this will make a copy of all parameter from mobjParameters to objParameter
		//mobjOnlineChannel.EnegryParameter = ObjParameter
		mobjOnlineChannel.EnegryParameter = mobjSpectrum.funcCloneESParameter(mobjParameters);
		//'now pass this object parameter to data structure
		//ObjParameter = Nothing

		if (!funcGraphPreRequisite(mobjParameters.Cal_Mode, mobjParameters.XaxisMin, mobjParameters.XaxisMax, mobjParameters.YaxisMin, mobjParameters.YaxisMax)) {
			//'this is set a graph as per given value
			//Call gFuncShowMessage("Error in setting spectrum parameters", "Please Check Entered Spectrum Parameters", modConstants.EnumMessageType.Information)
			return;
		}

		mobjOnlineReadings = new Spectrum.Readings();

		//Readings is a class use as a datastructure


		mblnSpectrumStarted = true;

		//--- Start the Spectrum analysis
		//mobjController.Start(New clsBgSpectrum(lblWvPos, lblOnlineWv, _
		//              mobjParameters.XaxisMax, _
		//              mobjParameters.XaxisMin, _
		//              mobjParameters.YaxisMax, _
		//              mobjParameters.YaxisMin, _
		//              mobjParameters.Cal_Mode, _
		//              mobjParameters.ScanSpeed, _
		//              dblAbsScanthldval, blnCheckMinAbsScanLmt))
		mobjController = null;
		mobjController = new clsBgThread(this);
		//'make a object for thread class
		mobjclsBgSpectrum = new clsBgSpectrum(lblTime, lblOnlineWv, mobjParameters.XaxisMax, mobjParameters.XaxisMin, mobjParameters.YaxisMax, mobjParameters.YaxisMin, mobjParameters.Cal_Mode, mobjParameters.ScanSpeed, dblAbsScanthldval, blnCheckMinAbsScanLmt);
		mobjController.Start(mobjclsBgSpectrum);
		//'for starting a spectrum thread

		funcOnSpect = true;
	}

	//    Public Function funcOnContinuesScan()
	//        '=====================================================================
	//        ' Procedure Name        :   funcOnContinuesScan
	//        ' Description           :   
	//        ' Purpose               :   
	//        '                           
	//        ' Parameters Passed     :   None.
	//        ' Returns               :   True, if successful.
	//        ' Parameters Affected   :   None.
	//        ' Assumptions           :
	//        ' Dependencies          :
	//        ' Author                :   Sachin Dokhale
	//        ' Created               :   
	//        ' Revisions             :
	//        '=====================================================================
	//        Try
	//            '             ReadFilterSetting();   // new changes
	//            ' Afirst=TRUE;
	//            ' if (hwnd){
	//            '	UpdateWindow(hwnd);
	//            '	hdc= GetDC(hwnd);
	//            '	CEnd1=CEnd=clock();
	//            '	xtime1= ((CEnd-CEnd1)/(double) CLK_TCK);
	//            '	SetWindowText(GetDlgItem(hwnd,IDC_FILT),"Filt");
	//            '	do  {
	//            '	  if (CheckMsg(hwnd, &msg)){
	//            '		 if (WP1==IDC_FILT){ // new changes
	//            '			Smooth ^= TRUE;
	//            '                            If (Smooth) Then
	//            '			  SetWindowText(GetDlgItem(hwnd,IDC_FILT),"Filt");
	//            '                            Else
	//            '			  SetWindowText(GetDlgItem(hwnd,IDC_FILT),"No Filt");

	//            '			WP1=-1;
	//            '		  }
	//            '		 if (WP1==IDC_RET){
	//            '			pc_delay(1000);
	//            '			ReleaseDC(hwnd, hdc);
	//            '			DestroyWindow(hwnd);
	//            '			break;
	//            '		  }
	//            '		}
	//            '                                    If (IsInAltProcess()) Then
	//            '		 continue;
	//            '	  abs = GetAbsScanX();
	//            '	  if (Smooth)          	// new changes
	//            '		  abs = GetFiltData(abs);

	//            '		//---mdf by sk on 3/6/2001
	//            '                                            If (CheckMinAbsScanLmt) Then
	//            '		 {
	//            '		  if(abs<Absscanthldval) //0.008 mdf by sk on 3/6/2001
	//            '         abs=0.0;
	//            '		 }
	//            '      //---mdf by sk on 3/6/2001

	//            '	  CEnd=clock();
	//            '	  if (CEnd!=CEnd1 ){
	//            '		 xtime1 += ( ((double)(CEnd-CEnd1)/(double) CLK_TCK));
	//            '		 CEnd1 = CEnd;
	//            '		 GetWvAndDataInString(abs, str);
	//            '		 SetDlgItemText(hwnd,IDC_QAABS, str);
	//            '		 if (xtime1>=AbsGraph.Xmax){
	//            '			tval =(AbsGraph.Xmax-AbsGraph.Xmin);
	//            '			AbsGraph.Xmin = AbsGraph.Xmax;//(double)5.0;
	//            '			AbsGraph.Xmax +=tval;// (double)5.0;
	//            '			Calculate_Abs_Scan_Param(&AbsGraph);
	//            '			Afirst=TRUE;
	//            '			InvalidateRect(hwnd, NULL, TRUE); //AbsGraph.RC, TRUE);
	//            '			UpdateWindow(hwnd);
	//            '			CEnd1 = clock();
	//            '//			CStart += (CEnd1-CEnd);
	//            '		  }
	//            '		 if (Afirst){
	//            '			PlotInit(hdc, xtime1, abs, AbsGraph.RC, &AbsGraph);
	//            '			Afirst=FALSE;
	//            '		  }
	//            '                                                            Else
	//            '			Plotg(hdc, xtime1, abs, AbsGraph.RC, &AbsGraph);
	//            '		}
	//            '	  }
	//            '	 while(1);

	//            gobjClsAAS203.ReInitInstParameters()
	//            Dim CEnd1, CEnd As Long
	//            Dim ConstManipulate As Long = 1000
	//            Dim Text1 As String

	//            CEnd1 = CEnd = CLng(System.DateTime.Now.Ticks) / ConstManipulate
	//            'lngTimeInMSeconds = lngTimeDelay + lngTimeInMSeconds
	//            XaxisTime1 = ((CEnd - CEnd1) / CLng(System.DateTime.Now.Ticks))

	//            Do While (True)
	//                'If (IsInAltProcess()) Then
	//                '    GoTo ContinueEx
	//                'End If
	//                dblAbs = gobjClsAAS203.funcGetAbsScanX()
	//                If (gblnSmoothFilter = True) Then
	//                    dblAbs = gobjClsAAS203.funcGetFiltData(dblAbs)
	//                End If

	//                If blnCheckMinAbsScanLmt = True Then
	//                    If (dblAbs < dblAbsScanthldval) Then
	//                        dblAbs = 0.0
	//                    End If
	//                End If
	//                CEnd = CLng(System.DateTime.Now.Ticks) / ConstManipulate
	//                If Not (CEnd = CEnd1) Then
	//                    XaxisTime1 += ((CEnd - CEnd1) / CLng(System.DateTime.Now.Ticks))
	//                    CEnd1 = CEnd
	//                    Text1 = XaxisTime1.ToString & "|" & dblAbs.ToString
	//                    Call funcIclientTaskDisplayData(Text1)
	//                    If (XaxisTime1 >= AASGraphTimeScan.XAxisMax) Then
	//                        CEnd1 = CLng(System.DateTime.Now.Ticks) / ConstManipulate
	//                    End If
	//                    'tval =(AbsGraph.Xmax-AbsGraph.Xmin);
	//                    'AbsGraph.Xmin = AbsGraph.Xmax;//(double)5.0;
	//                    'AbsGraph.Xmax +=tval;// (double)5.0;
	//                    'Calculate_Abs_Scan_Param(&AbsGraph);
	//                    'Afirst=TRUE;
	//                    'InvalidateRect(hwnd, NULL, TRUE); //AbsGraph.RC, TRUE);
	//                    'UpdateWindow(hwnd);
	//                End If

	//ContinueEx:
	//            Loop

	//            Return True

	//        Catch ex As Exception
	//            '---------------------------------------------------------
	//            'Error Handling and logging
	//            gobjErrorHandler.ErrorDescription = ex.Message
	//            gobjErrorHandler.ErrorMessage = ex.Message
	//            gobjErrorHandler.WriteErrorLog(ex)
	//            '---------------------------------------------------------
	//            Return False
	//        Finally
	//            '---------------------------------------------------------
	//            'Writing Execution log
	//            If CONST_CREATE_EXECUTION_LOG = 1 Then
	//                gobjErrorHandler.WriteExecutionLog()
	//            End If
	//            '---------------------------------------------------------
	//        End Try

	//    End Function

	#Region " Save/Load Spectrum Function "

	//--- Save the Current Active channel to a UVSpectrum(uvs) file
	//Private Function funcSaveSpectrumFile() As Boolean
	//    '=====================================================================
	//    ' Procedure Name        :   funcSaveSpectrumFile
	//    ' Description           :   Get the File name and path from the user
	//    '                           and save the spectrum file to *.spt 
	//    ' Purpose               :   To save the channel information to the 
	//    '                           Spectrum file.
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
	//        If mobjChannnels.item(mintChannelIndex) Is Nothing Then
	//            'gFuncShowMessage("Error", "Spectrum is not present for saving.", EnumMessageType.Information)
	//            Exit Function
	//        End If

	//        Dim objchannel As Spectrum.Channel

	//        objchannel = mobjChannnels.item(mintChannelIndex)

	//        'If gstructApplicationSettings.Enable21CFR = 1 Then
	//        '    If Not gfuncGetFileAuthenticationData(objchannel.DigitalSignature) Then
	//        '        Return True
	//        '    End If
	//        'Else
	//        '--- This is for saving the file with login Authnetication 
	//        '--- when 21 cfr is off
	//        'If Not gfuncGetFileAuthenticationData_21CFR_OFF(objchannel.DigitalSignature) Then
	//        '    Return True
	//        'End If
	//        'End If

	//        Dim objStream As Stream
	//        Dim objsfdSpectrum As New SaveFileDialog

	//        '--- Show the save dialog to accept the *.spt file.
	//        objsfdSpectrum.Filter = "Spectrum Files(*" & CONST_EnergySpectrumFileExt & ")|*" & CONST_EnergySpectrumFileExt
	//        objsfdSpectrum.FilterIndex = 1
	//        objsfdSpectrum.InitialDirectory = strPath.GetCurrentDirectory.ToString + "\UVSpectrums"
	//        objsfdSpectrum.RestoreDirectory = True

	//        If objsfdSpectrum.ShowDialog() = DialogResult.OK Then
	//            'objchannel.DigitalSignature.FileName = objsfdSpectrum.FileName
	//            '--- Check if file exist   
	//            If (objsfdSpectrum.CheckFileExists()) Then
	//                If (MessageBox.Show("DO YOU WISH TO OVERWRITE", "SAVE AS", MessageBoxButtons.YesNo) = DialogResult.Yes) Then
	//                    If Not gfuncSerializeObject(objsfdSpectrum.FileName, objchannel) Then
	//                        'gFuncShowMessage("Error", "ERROR IN SAVING FILE.", EnumMessageType.Information) '112
	//                    End If
	//                Else
	//                    Return True
	//                End If
	//            Else
	//                If Not gfuncSerializeObject(objsfdSpectrum.FileName, objchannel) Then
	//                    'gFuncShowMessage("Error", "ERROR IN SAVING FILE.", EnumMessageType.Information) '112
	//                End If
	//            End If

	//            '--- Writing to Activity Log and File Log
	//            'If (gstructApplicationSettings.Enable21CFR = 1) Then
	//            '    Dim lngActivityLogID As Long
	//            '    lngActivityLogID = gfuncInsertActivityLog(EnumModules.Spectrum, "Spectrum File Saved")

	//            'If (lngActivityLogID > 0) Then
	//            'Dim objFI As New FileInfo(objsfdSpectrum.FileName)
	//            'Dim strXMLFileData As String
	//            'Dim strFileLogPath As String
	//            'Dim strFileName As String = Replace(objFI.Name, objFI.Extension, "")

	//            'strFileName = strFileName & "_" & Format(DateTime.Now, "MM_dd_yyyy_hh_mm_ss") & objFI.Extension

	//            'If Not Directory.Exists(CONST_FILELOG_PATH) Then
	//            '    Call Directory.CreateDirectory(CONST_FILELOG_PATH)
	//            'End If

	//            'strFileLogPath = CONST_FILELOG_PATH & "\" & strFileName

	//            ''Call objclsXmlOperation.gfuncXMLSerializeObject(strFileLogPath, objchannel)
	//            ''strXMLFileData = objclsXmlOperation.gfuncXMLFileRead(strFileLogPath)
	//            'If Not gfuncSerializeObject(strFileLogPath, objchannel) Then
	//            '    Throw New Exception
	//            'End If

	//            ''--- Log the file 
	//            ''Call gfuncInsertFileLog(lngActivityLogID, objsfdSpectrum.FileName, strFileLogPath)
	//            'End If
	//            'End If

	//        End If
	//        objsfdSpectrum.Dispose()

	//        Return True

	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        'Error Handling and logging
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = ex.Message
	//        gobjErrorHandler.WriteErrorLog(ex)
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

	//'--- Load channel from spectrum(spt) file
	//Private Function funcLoadSpectrumFile() As Boolean
	//    '=====================================================================
	//    ' Procedure Name        :   funcLoadSpectrumFile
	//    ' Description           :   Get the Spectrum file from the user and load the
	//    '                           spectrum file data to the channel object.
	//    ' Purpose               :   To load the spectrum file in the channel object.
	//    ' Parameters Passed     :   None.
	//    ' Returns               :   True, if successful.
	//    ' Parameters Affected   :   Spectrum file data is added to the channels collection.
	//    ' Assumptions           :   None.
	//    ' Dependencies          :   None.
	//    ' Author                :   Gitesh, Uday
	//    ' Created               :   Saturday, November 15, 2003 18:49
	//    ' Revisions             :   Nilesh Shirode  feb 11 2004
	//    '=====================================================================
	//    Dim objStream As Stream
	//    Dim objofdSpectrum As New OpenFileDialog
	//    Try
	//        funcLoadSpectrumFile = False

	//        objofdSpectrum.InitialDirectory = strPath.GetCurrentDirectory.ToString & "\Spectrums"
	//        objofdSpectrum.Filter = "Spectrum Files(*" & CONST_EnergySpectrumFileExt & ")|*" & CONST_EnergySpectrumFileExt
	//        objofdSpectrum.FilterIndex = 1
	//        objofdSpectrum.RestoreDirectory = True

	//        If objofdSpectrum.ShowDialog() = DialogResult.OK Then
	//            If (objofdSpectrum.CheckFileExists()) Then
	//                Dim objchannel As Spectrum.Channel
	//                Dim intChannel_no As Int16

	//                'If gstructApplicationSettings.Enable21CFR = 1 Then
	//                '    Dim objChn As Channel
	//                '    objChn = gfuncDeSerializeObject(objofdSpectrum.FileName, EnumDeserializeObjType.Channel)
	//                '    If gfuncCheckForFileAuthentication(objChn.DigitalSignature) Then
	//                '        objchannel = objChn
	//                '    Else
	//                '        Call gFuncShowMessage("Authentication Fail !", "Access denied, cannot open the file.", modConstants.EnumMessageType.Information)
	//                '        Return False
	//                '    End If
	//                'End If

	//                objchannel = gfuncDeSerializeObject(objofdSpectrum.FileName, EnumDeserializeObjType.UVSpectrum)
	//                '--- Add the new channel to the channels collection and 
	//                '--- accordingly save the channel file to the disk

	//                intChannel_no = funcAddChannelToCollection(objchannel)

	//                If mobjChannnels.Count > 0 Then
	//                    mobjChannnels.item(0) = objchannel
	//                    mobjParameters = Nothing
	//                    mobjParameters = mobjChannnels.item(0).EnegryParameter
	//                    Call funcSetParameter()
	//                    funcClearGraph()
	//                    funcGraphPreRequisite(mobjParameters.Cal_Mode, _
	//                                            mobjParameters.XaxisMin, _
	//                                            mobjParameters.XaxisMax, _
	//                                            mobjParameters.YaxisMin, _
	//                                            mobjParameters.YaxisMax)
	//                    funcDisplayGraph(mobjChannnels.item(0))

	//                Else
	//                    mobjParameters = Nothing
	//                    mobjChannnels.Add(objchannel)
	//                    mobjParameters = mobjChannnels.item(intChannel_no).EnegryParameter
	//                    Call funcSetParameter()
	//                    funcClearGraph()
	//                    funcGraphPreRequisite(mobjParameters.Cal_Mode, _
	//                                            mobjParameters.XaxisMin, _
	//                                            mobjParameters.XaxisMax, _
	//                                            mobjParameters.YaxisMin, _
	//                                            mobjParameters.YaxisMax)
	//                    funcDisplayGraph(mobjChannnels.item(intChannel_no))

	//                End If
	//                Application.DoEvents()

	//                'subLabelDisplay(mobjChannnels.item(0))
	//            End If
	//        End If
	//        objofdSpectrum.Dispose()
	//        funcLoadSpectrumFile = True

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

	#End Region

	private bool funcSetFrmEditValue(ref double ReturnValue, string strWinTitle, double dblMinValue, double dblMaxValue)
	{
		//=====================================================================
		// Procedure Name        : subSetFrmEditValue
		// Parameters Passed     : ReturnValue, strWinTitle, dblMinValue, dblMaxValue
		// Parameter affected    : ReturnValue,
		// Returns               : True if success
		// Purpose               : this is used to call a edit dilog as par user defined value.
		//                         
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : Apr 01, 2007 4:00 pm
		// Revisions             : Deepak on 20.05.10
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
					intValue = (int)ReturnValue;
					ReturnValue = intValue;
				default:
			}

			mobjfrmEditValues.txtValue.Focus();
			mobjfrmEditValues.txtValue.SelectAll();
			mobjfrmEditValues.txtValue.Text = ReturnValue;

			if (mobjfrmEditValues.ShowDialog == DialogResult.Cancel) {
				Application.DoEvents();
				if (!mobjfrmEditValues == null) {
					mobjfrmEditValues.Dispose();
				}
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

			ReturnValue = InputValue;
			Application.DoEvents();

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

	private void ValueEditorUpDnEnable(bool blnEnable)
	{
		//nudBurnerHeight.IsUpDownEnable = blnEnable
		//nudD2Cur.IsUpDownEnable = blnEnable
		//nudHCLCur.IsUpDownEnable = blnEnable
		//nudFuelRatio.IsUpDownEnable = blnEnable
		//nudPMT.IsUpDownEnable = blnEnable
		//nudSlit.IsUpDownEnable = blnEnable

		nudBurnerHeight.Enabled = blnEnable;
		nudD2Cur.Enabled = blnEnable;
		nudHCLCur.Enabled = blnEnable;
		nudFuelRatio.Enabled = blnEnable;
		nudPMT.Enabled = blnEnable;
		nudSlit.Enabled = blnEnable;

	}

	#End Region

	#Region " Code for Enable and Disable"

	private object func_Enable_Disable(int intProcess, int intStart_End)
	{
		//=====================================================================
		// Procedure Name        : func_Enable_Disable
		// Parameters Passed     : current process , intStart_End 
		// Returns               : None
		// Purpose               : for enable/disable a onscreen control as par current process..
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 21.11.06
		// Revisions             : 
		//=====================================================================

		//'parameter
		//' intprocess is a current stata of a form




		try {
			//'this function is called for the enable/disable the control on the screen as par the case 
			switch (intProcess) {
				case EnumProcesses.FormInitialize:
				case EnumProcesses.EditSystemParamters:
					switch (intStart_End) {

						case EnumStart_End.Start_of_Process:
							//'select a case as per current process
							subAll_Menus_Enable();
							//'for enable all the menu
							btnAutoZero.Enabled = true;
							btnClearSpectrum.Enabled = true;
							btnReturn.Enabled = true;
							nudD2Cur.Enabled = true;
							nudPMT.Enabled = true;
							nudSlit.Enabled = true;
							//cmbSpeed.Enabled = True
							cmbModes.Enabled = true;
							nudBurnerHeight.Enabled = true;
							nudFuelRatio.Enabled = true;
							nudHCLCur.Enabled = true;
							btnClearSpectrum.Enabled = true;

							btnLampParameters.Enabled = true;

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
						//'select a case as per current process
					}
				case EnumProcesses.LoadParameters:
					//2
					//'select a case as per current process
					switch (intStart_End) {

						case EnumStart_End.Start_of_Process:
						case EnumStart_End.End_of_Process:

					}
				case EnumProcesses.EditParameters:
					//3   
					//'select a case as per current process
					switch (intStart_End) {

						case EnumStart_End.Start_of_Process:
						case EnumStart_End.End_of_Process:

					}
				case EnumProcesses.SaveParameters:
					//4   
					//'select a case as per current process
					switch (intStart_End) {

						case EnumStart_End.Start_of_Process:
						case EnumStart_End.End_of_Process:

					}
				case EnumProcesses.StartScan:
					//15  EnumProcesses.StartScan
					//'select a case as per current process
					switch (intStart_End) {
						case EnumStart_End.Start_of_Process:
							subAll_Menus_Disable();
						//btnClearSpectrum.Enabled = False
						//btnReturn.Enabled = False
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


						//nudD2Cur.Enabled = False
						//nudPMT.Enabled = False
						//nudSlit.Enabled = False
						//cmbSpeed.Enabled = False
						//cmbModes.Enabled = False
						//nudBurnerHeight.Enabled = False
						//nudFuelRatio.Enabled = False
						//nudHCLCur.Enabled = False
						//btnLampParameters.Enabled = False

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
							//'select a case as per current process
							if (gblnSpectrumTerminated == false) {
								subAll_Menus_Enable();
								btnClearSpectrum.Enabled = true;
								btnReturn.Enabled = true;
								nudD2Cur.Enabled = true;
								nudPMT.Enabled = true;
								nudSlit.Enabled = true;
								cmbModes.Enabled = true;
								nudBurnerHeight.Enabled = true;
								nudFuelRatio.Enabled = true;
								nudHCLCur.Enabled = true;
								btnLampParameters.Enabled = true;


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
					//'select a case as per current process
					switch (intStart_End) {

						case EnumStart_End.Start_of_Process:
						case EnumStart_End.End_of_Process:

							subAll_Menus_Enable();
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
					//'select a case as per current process
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
						//NumUpDwn.Enabled = True
						//btnNumUpDwn_Dwn.Enabled = True
						//btnNumUpDwn_Up.Enabled = True
						//tlbrSpectrum.Buttons.Item(EnumToolBarButtons.Print).ImageIndex = EnumToolBarImages.PrintEnabled


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


	private void subAll_Menus_Enable()
	{
		//=====================================================================
		// Procedure Name        : subAll_Menus_Enable
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : for enable all the menu..
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 21.11.06
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
		// Procedure Name        : subAll_Menus_Enable
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : for disable all the menu..
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 21.11.06
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
		//start a progress thread.

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
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

			//ProgressPanel.Text = Application.ProductName & Space(1) & Application.ProductVersion '22.3.2009 by dinesh wagh
			ProgressPanel.Text = gstrTitleInstrumentType + Space(1) + "S/W Ver. " + Mid(Application.ProductVersion, 1, 4);
			// added by : dinesh wggh on 22.3.2009


		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
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
		// Purpose               : to show message on status bar
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
		// Parameters Passed     : BgThread
		// Returns               :  
		// Purpose               :  this is called by thread
		// Description           : for stating a thread.
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : 12.10.06
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
		// Procedure Name        : TaskStatus
		// Parameters Passed     : Text
		// Returns               :  
		// Purpose               :  this is called by thread
		// Description           :  for display a status.
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : 12.10.06
		// Revisions             : 
		//=====================================================================
		try {
			//If gstructApplicationSessionState.intInstrument_Group = EnumInstrumentGroup.Initialize_2600_2700 Then
			funcIclientTaskDisplayData(Text);
			//'for display a thread result.
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
			Application.DoEvents();
			//'--------------------------------------------------------
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
		// Parameters Passed     : e
		// Returns               :  
		// Purpose               :  this is called by thread
		// Description           :  when thread is failed.
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : 12.10.06
		// Revisions             : 
		//=====================================================================
		try {
			//--- Dispose all the objects
			//mobjTemporaryChannel = New Channel
			//mobjTemporaryReadings = New Readings
			//mobjTemporaryReadings_2100 = New Readings
			funcIclientTaskFalied();
			// task falied received from instrument

			mblnSpectrumStarted = false;
			//'stop a spectrum
			mblnAvoidProcessing = false;
			mnuExit_Click(btnReturn, EventArgs.Empty);
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
		// Parameters Passed     : Cancelled
		// Returns               :  
		// Purpose               :  this is called by thread
		// Description           :  when thread is completed.
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : 12.10.06
		// Revisions             : 
		//=====================================================================
		try {
			//If gstructApplicationSessionState.intInstrument_Group = EnumInstrumentGroup.Initialize_2600_2700 Then
			//    'Call funcIclientTaskCompleted2600()
			//ElseIf gstructApplicationSessionState.intInstrument_Group = EnumInstrumentGroup.Initialize_2100_2200_2300 Then
			//    'Call funcIclientTaskCompleted2100()
			//End If
			funcIclientTaskCompleted();
			//ask completed received from instrument
			mblnSpectrumStarted = false;
			mblnAvoidProcessing = false;
			mnuExit_Click(btnReturn, EventArgs.Empty);
		//'call mnuExit event.

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

	#End Region

	#Region " IClient Private Functions "

	private bool funcIclientTaskCompleted()
	{
		//=====================================================================
		// Procedure Name        :   funcIclientTaskCompleted
		// Description           :   task completed received from instrument 
		//                           
		// Purpose               :   
		// Parameters Passed     :  None
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
				if (ArrlstGraphCurveItem.Count >= intCurveIndex + 1) {
					AASGraphTimeScan.StopOnlineGraph(ArrlstGraphCurveItem(intCurveIndex));
					//'for stoping a online graph
					intCurveIndex += 1;
				}
			}
			Application.DoEvents();
			//'allow application to perfrom its panding work.

			AASGraphTimeScan.AldysPane.AxisChange();
			AASGraphTimeScan.Refresh();

			if (!funcSpectrumReadingCompleted()) {
				//'check for spectrum reading 
			}

			if (gblnSpectrumTerminated == true) {
				funcScanCompleted(false);
			//scan is completed 
			} else {
				funcScanCompleted(true);
			}
			//btnReturn.Text = "&Return"
			//btnReturn.Refresh()
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
		// Parameters Passed     :  None
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
				AASGraphTimeScan.StopOnlineGraph(ArrlstGraphCurveItem(intCurveIndex));
				//intCurveIndex += 1
			}


			Application.DoEvents();
			AASGraphTimeScan.AldysPane.AxisChange();
			AASGraphTimeScan.Refresh();

			funcScanCompleted(false);

			Application.DoEvents();
			//gFuncShowMessage("Error...", "Scanning failed.", EnumMessageType.Information)'113
			mblnSpectrumStarted = false;
			//btnReturn.Text = "&Return"
			//btnReturn.Refresh()
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
			//btnStart.Text = "&Start"
			//btnStart.Enabled = True
			//btnStart.Refresh()

			//funcTimerStartStop(mTimer, EnumTimerStartStop.Timer_Start)

			//func_Enable_Disable(EnumProcesses.StartScan, EnumStart_End.End_of_Process)
			//make the gblnSpectrumTerminated flag false
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
			Application.DoEvents();
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

			//--- Add the new channel to the channels collection and 
			//--- accordingly save the channel file to the disk
			intChannel_no = funcAddChannelToCollection(mobjOnlineChannel);
			mintChannelIndex = intChannel_no;


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

	private bool funcIclientTaskDisplayData(string strData)
	{
		//=====================================================================
		// Procedure Name        : funcIclientTaskDisplayData
		// Parameters Passed     : strData
		// Returns               : bool
		// Purpose               : for displying a data. this is called by thread.

		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 21.11.06
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
			Application.DoEvents();
			arrData = Split(strData, "|");


			if (arrData(0).Length > 0 & arrData(1).Length > 0) {
				objData.XaxisData = Format(Val(arrData(0)), "#000.0");
				// wv

				objData.YaxisData = Format(Val(arrData(1)), "#0.000");

				if (!(mobjOnlineReadings == null)) {
					mobjOnlineReadings.Add(objData);
					funcDisplayGraph_RealTime(objData.XaxisData, objData.YaxisData);
					//'for display a graph as per given value.
				}
				//           
			}

		} catch (Exception ex) {
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

	#Region " Graph Methods "

	private bool funcGraphPreRequisite(int intScanmode, double intXmin, double intXmax, double intYmin, double intYmax)
	{
		//=====================================================================
		// Procedure Name        : funcGraphPreRequisite
		// Parameters Passed     :intScanmode,intXmax.intXmin,intYmax.intYmin,
		// Returns               : bool
		// Purpose               : for setting a graph as per passed parameter

		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 21.11.06
		// Revisions             : 
		//=====================================================================
		//'note.
		//'here intScanmode means a calibration mode
		double dblDiffX;
		double dblMajorStepX;
		double dblMinorStepX;
		double dblDiffY;
		double dblMajorStepY;
		double dblMinorStepY;

		try {
			dblDiffX = Fix(intXmax - intXmin);
			//'get a X range
			dblMajorStepX = dblDiffX / 10;
			//'get a major step
			dblMinorStepX = dblMajorStepX / 2;
			//'get a minor step.
			dblDiffY = (intYmax - intYmin);
			//'get a Y range
			dblMajorStepY = dblDiffY / 10;
			//'get a Y major
			dblMinorStepY = dblMajorStepY / 2;
			//'get a Y minor
			AASGraphTimeScan.btnPeakEdit.Enabled = false;
			AASGraphTimeScan.btnShowXYValues.Enabled = false;

			AASGraphTimeScan.XAxisMin = intXmin;
			AASGraphTimeScan.XAxisMax = intXmax;
			AASGraphTimeScan.AldysPane.XAxis.Min = intXmin;
			AASGraphTimeScan.AldysPane.XAxis.Max = intXmax;

			//--- Display the axis lables
			AASGraphTimeScan.XAxisLabel = "TIME(seconds)";
			//'set a X-axis label.

			//'default X-axis label
			//AxEnergySpectrum.XAxisLabel = "  Energy"
			///below we are setting a graph parameter on screen as par mode 
			switch (gobjInst.Mode) {
				//'set a default parameter as per calibration mode 
				case EnumCalibrationMode.AA:
				case EnumCalibrationMode.AABGC:
				case EnumCalibrationMode.MABS:
					//'set a default parameter as per calibration mode
					AASGraphTimeScan.YAxisMin = intYmin;
					AASGraphTimeScan.YAxisMax = intYmax;

					AASGraphTimeScan.YAxisLabel = "ABSORBANCE";
					mstrYaxisFormat = "0.000";
					mstrYaxisExt = "";
				case EnumCalibrationMode.HCLE:
				case EnumCalibrationMode.D2E:
					//'set a default parameter as per calibration mode
					AASGraphTimeScan.YAxisMin = intYmin;
					AASGraphTimeScan.YAxisMax = intYmax;
					AASGraphTimeScan.YAxisLabel = "ENERGY";
					mstrYaxisFormat = "0.00#";
					mstrYaxisExt = "";
				case EnumCalibrationMode.EMISSION:
					//'set a default parameter as per calibration mode
					AASGraphTimeScan.YAxisMin = intYmin;
					AASGraphTimeScan.YAxisMax = intYmax;
					AASGraphTimeScan.YAxisLabel = "EMISSION";
					mstrYaxisFormat = "0.0";
					mstrYaxisExt = "%";
				case EnumCalibrationMode.SELFTEST:
					//'set a default parameter as per calibration mode
					AASGraphTimeScan.YAxisMin = intYmin;
					AASGraphTimeScan.YAxisMax = intYmax;
					AASGraphTimeScan.YAxisLabel = "VOLT(mv)";
					mstrYaxisExt = "";
					mstrYaxisFormat = "0.0";
			}
			//AASGraphTimeScan.YAxisLabel = mYValueLable Commented by Saurabh 05.08.07 


			////----- Set auto Steps of axis

			AASGraphTimeScan.AldysPane.XAxis.Step = dblMajorStepX;
			AASGraphTimeScan.AldysPane.XAxis.MinorStep = dblMinorStepX;
			AASGraphTimeScan.AldysPane.YAxis.Step = dblMajorStepY;
			AASGraphTimeScan.AldysPane.YAxis.MinorStep = dblMinorStepY;

			AASGraphTimeScan.XAxisStep = dblMajorStepX;
			AASGraphTimeScan.YAxisStep = dblMajorStepY;
			AASGraphTimeScan.XAxisMinorStep = dblMinorStepX;
			AASGraphTimeScan.YAxisMinorStep = dblMinorStepY;
			AASGraphTimeScan.AldysPane.Legend.IsVisible = true;
			mnuGrid.Checked = true;
			this.AASGraphTimeScan.IsShowGrid = true;
			this.AASGraphTimeScan.btnPeakEdit.Checked = false;
			////-----
			AASGraphTimeScan.AldysPane.AxisChange();
			//'call axis change event
			AASGraphTimeScan.Refresh();
			Application.DoEvents();
			//'allow application to perfrom its panding work.
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

	private bool funcGraphPreRequisite(int intScanmode, double intYmin, double intYmax)
	{
		//=====================================================================
		// Procedure Name        :   funcGraphPreRequisite
		// Description           :   Prepare graph for plotting
		// Purpose               :   
		// Parameters Passed     :   intScanmode, intYmin, intYmax
		// Returns               :   True, if successful.
		// Parameters Affected   :   
		// Assumptions           :   
		// Dependencies          :   None.
		// Author                :   Sachin Dokhale 
		// Created               :   12.12.06
		// Revisions             :
		//=====================================================================


		//'here intScanmode means a calibration mode 
		double dblDiffX;
		double dblMajorStepX;
		double dblMinorStepX;
		double dblDiffY;
		double dblMajorStepY;
		double dblMinorStepY;


		try {
			dblDiffY = (intYmax - intYmin);
			//'get a Y range
			dblMajorStepY = dblDiffY / 10;
			//'get major step
			dblMinorStepY = dblMajorStepY / 2;
			//'get minor step
			//--- Display the axis lables
			//AxEnergySpectrum.XAxisLabel = "  Energy"
			AASGraphTimeScan.btnPeakEdit.Enabled = false;
			AASGraphTimeScan.btnShowXYValues.Enabled = false;

			switch (gobjInst.Mode) {
				//'here we are setting graph parameter as par mode
				case EnumCalibrationMode.AA:
				case EnumCalibrationMode.AABGC:
				case EnumCalibrationMode.MABS:
					AASGraphTimeScan.YAxisMin = intYmin;
					AASGraphTimeScan.YAxisMax = intYmax;
					AASGraphTimeScan.YAxisLabel = "ABSORBANCE";
					mstrYaxisFormat = "0.00#";
					mstrYaxisExt = "";
				case EnumCalibrationMode.HCLE:
				case EnumCalibrationMode.D2E:
					//'here we are setting graph parameter as par mode
					AASGraphTimeScan.YAxisMin = intYmin;
					AASGraphTimeScan.YAxisMax = intYmax;
					AASGraphTimeScan.YAxisLabel = "ENERGY";
					mstrYaxisFormat = "0.00#";
					mstrYaxisExt = "";
				case EnumCalibrationMode.EMISSION:
					//'here we are setting graph parameter as par mode
					AASGraphTimeScan.YAxisMin = intYmin;
					AASGraphTimeScan.YAxisMax = intYmax;
					AASGraphTimeScan.YAxisLabel = "EMISSION";
					mstrYaxisFormat = "0.#";
					mstrYaxisExt = "%";
				case EnumCalibrationMode.SELFTEST:
					//'here we are setting graph parameter as par mode
					AASGraphTimeScan.YAxisMin = intYmin;
					AASGraphTimeScan.YAxisMax = intYmax;
					AASGraphTimeScan.YAxisLabel = "Volt(m)";
					mstrYaxisFormat = "0.#";
					mstrYaxisExt = "";
			}

			////----- Set auto Steps of axis
			AASGraphTimeScan.AldysPane.YAxis.Step = dblMajorStepY;
			AASGraphTimeScan.AldysPane.YAxis.MinorStep = dblMinorStepY;
			AASGraphTimeScan.AldysPane.YAxis.IsMinorTic = true;
			AASGraphTimeScan.AldysPane.YAxis.IsTic = true;

			AASGraphTimeScan.YAxisStep = dblMajorStepY;
			AASGraphTimeScan.YAxisMinorStep = dblMinorStepY;
			////-----
			this.AASGraphTimeScan.btnPeakEdit.Checked = false;
			AASGraphTimeScan.AldysPane.AxisChange();
			AASGraphTimeScan.Refresh();
			Application.DoEvents();
			//'allow application to perfrom its panding work
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
		// Author                :   Sachin Dokhale 
		// Created               :   10.12.06
		// Revisions             :
		//=====================================================================
		long lngX_Axis;
		double dblToY;
		long tval;
		double dblDiffX;
		double dblMajorStepX;
		double dblMinorStepX;
		double dblDiffY;
		double dblMajorStepY;
		double dblMinorStepY;
		long lngIdx;
		long MaxXaxis;
		long MinXaxis;

		try {
			Application.DoEvents();
			//--- Plot the graph for the given coordinates.
			//lngX_Axis = CLng(dblXAxis)
			lngX_Axis = Fix(dblXAxis);
			dblToY = dblYAxis;

			//--- Check if the X-coordinates and Y-coordinates are less than
			//--- Xmin and Ymin

			dblYAxis = dblToY;

			////------ to see the time lable only required to lable visiable property with "True"
			lblTime.Text = "Time (Sec.) : " + Format(dblXAxis, "#0.00#");

			//lblYValue.Text = mYValueLable & ": " & Format(dblYAxis, "#0.000")
			lblYValue.Text = mYValueLable + ": " + Format(dblYAxis, mstrYaxisFormat) + mstrYaxisExt;
			gDblAbsValue_IQOQPQ_Attachment1 = dblYAxis;
			lblTime.Refresh();
			lblYValue.Refresh();

			//            if (xtime1>=AbsGraph.Xmax){
			//			tval =(AbsGraph.Xmax-AbsGraph.Xmin);
			//			AbsGraph.Xmin = AbsGraph.Xmax;//(double)5.0;
			//			AbsGraph.Xmax +=tval;// (double)5.0;
			//			Calculate_Abs_Scan_Param(&AbsGraph);
			//			Afirst=TRUE;
			//			InvalidateRect(hwnd, NULL, TRUE); //AbsGraph.RC, TRUE);
			//			UpdateWindow(hwnd);
			//			CEnd1 = clock();
			////			CStart += (CEnd1-CEnd);
			//		  }
			//		 if (Afirst){
			//			PlotInit(hdc, xtime1, abs, AbsGraph.RC, &AbsGraph);
			//			Afirst=FALSE;
			//		  }
			//                Else
			//			Plotg(hdc, xtime1, abs, AbsGraph.RC, &AbsGraph);
			//		}

			//--- Check if the wavelength is equal to the max wv



			if ((lngX_Axis >= Fix(AASGraphTimeScan.XAxisMax))) {
				dblDiffX = Fix(AASGraphTimeScan.XAxisMax - AASGraphTimeScan.XAxisMin);
				dblMajorStepX = dblDiffX / 10;
				dblMinorStepX = dblMajorStepX / 2;

				dblDiffY = Fix(AASGraphTimeScan.YAxisMax - AASGraphTimeScan.YAxisMin);
				dblMajorStepY = dblDiffY / 10;
				dblMinorStepY = dblMajorStepY / 2;
				mintChannelIndex = 0;
				intCurveIndex = 0;
				tval = (AASGraphTimeScan.XAxisMax - AASGraphTimeScan.XAxisMin);
				MaxXaxis = AASGraphTimeScan.XAxisMax;
				MinXaxis = AASGraphTimeScan.XAxisMin;

				if (lngX_Axis > MaxXaxis) {
					for (lngIdx = tval; lngIdx <= lngX_Axis; lngIdx += tval) {
						//by Pankaj on 16.1.08
						if (tval == 0) {
							break; // TODO: might not be correct. Was : Exit For
						}
						//MinXaxis += tval
					}
					MaxXaxis = lngIdx;
					MinXaxis = MaxXaxis - tval;
				} else {
					MinXaxis = MaxXaxis;
					MaxXaxis = MinXaxis + tval;
				}

				AASGraphTimeScan.XAxisMin = MinXaxis;
				//AASGraphTimeScan.XAxisMax
				AASGraphTimeScan.XAxisMax = MaxXaxis;

				AASGraphTimeScan.AldysPane.XAxis.Min = MinXaxis;
				//AASGraphTimeScan.XAxisMax
				AASGraphTimeScan.AldysPane.XAxis.Max = MaxXaxis;
				mobjParameters.XaxisMin = MinXaxis;
				mobjParameters.XaxisMax = MaxXaxis;

				////----- Set auto Steps of axis
				AASGraphTimeScan.AldysPane.XAxis.Step = dblMajorStepX;
				AASGraphTimeScan.AldysPane.XAxis.MinorStep = dblMinorStepX;
				AASGraphTimeScan.XAxisStep = dblMajorStepX;
				AASGraphTimeScan.XAxisMinorStep = dblMinorStepX;
				gobjClsAAS203.Calculate_Analysis_Graph_Param(AASGraphTimeScan, ClsAAS203.enumChangeAxis.xyAxis);
				////-----
				//mGraphCurveItem = AASGraphTimeScan.StartOnlineGraph("Spectrum " & (intCurveIndex + 1).ToString, AASGraphTimeScan.GetColor(intCurveIndex), AldysGraph.SymbolType.NoSymbol)
				//ArrlstGraphCurveItem.Add(mGraphCurveItem)
				//AASGraphTimeScan.PlotPoint(ArrlstGraphCurveItem.Item(intCurveIndex), dblXAxis, dblYAxis)
				AASGraphTimeScan.AldysPane.AxisChange();
				AASGraphTimeScan.Refresh();
				Application.DoEvents();
				blnPlotingNew = false;
			}
			Application.DoEvents();

			if (blnPlotingNew == true) {
				mGraphCurveItem = null;
				//start online graph
				mGraphCurveItem = AASGraphTimeScan.StartOnlineGraph("Time scan", AASGraphTimeScan.GetColor(intCurveIndex), AldysGraph.SymbolType.NoSymbol);
				//---20.03.09
				ArrlstGraphCurveItem.Add(mGraphCurveItem);
				if (!(ArrlstGraphCurveItem.Item(intCurveIndex) == null)) {
					AASGraphTimeScan.PlotPoint(ArrlstGraphCurveItem.Item(intCurveIndex), dblXAxis, dblYAxis);
					AASGraphTimeScan.Refresh();
				}
				blnPlotingNew = false;
			} else {
				if (!(ArrlstGraphCurveItem.Item(intCurveIndex) == null)) {
					AASGraphTimeScan.PlotPoint(ArrlstGraphCurveItem.Item(intCurveIndex), dblXAxis, dblYAxis);
					AASGraphTimeScan.AldysPane.AxisChange();
					AASGraphTimeScan.Refresh();
				}
				Application.DoEvents();
			}

			Application.DoEvents();
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

	internal bool funcDisplayGraph(Spectrum.Channel objChannel)
	{
		//=====================================================================
		// Procedure Name        :   funcDisplayGraph
		// Description           :   to plot the graph as offline 
		// Purpose               :   
		// Parameters Passed     :   objChannel, is a obj of data structure
		// Returns               :   True, if successful.
		// Parameters Affected   :   
		// Assumptions           :   
		// Dependencies          :   None.
		// Author                :   Sachin Dokhale 
		// Created               :   12.12.06
		// Revisions             :
		//=====================================================================
		//'note:
		//'this function draw a offline graph 
		//'it gets a value from data structure and display a graph 
		long lngDataCount;
		Spectrum.Readings objReadingCol = new Spectrum.Readings();
		double dblFromX;
		double dblFromY;
		double dblToX;
		double dblToY;
		DataTable dtPlotValue = new DataTable();
		DataColumn dtColXaxis = new DataColumn("Xaxis", typeof(double));
		DataColumn dtColYaxis = new DataColumn("Yaxis", typeof(double));
		DataRow dtRow;


		try {
			if (!objChannel == null) {

				if (objChannel.Spectrums.Count > 0) {
					dblFromX = objChannel.UVParameter.XaxisMax;
					dblFromY = objChannel.UVParameter.YaxisMin;

					//--- Get the speed


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
						if (dblToY < objChannel.UVParameter.YaxisMin) {
							dblToY = objChannel.UVParameter.YaxisMin();
						}

						if (dblToY > objChannel.UVParameter.YaxisMax) {
							dblToY = objChannel.UVParameter.YaxisMax;
						}
						dtRow = dtPlotValue.NewRow;

						dtRow(0) = dblToX;
						dtRow(1) = dblToY;
						dtPlotValue.Rows.Add(dtRow);
						//--- Check if the wavelength is equal to the min wv
					}

					AASGraphTimeScan.GraphDataSource = dtPlotValue;
					AASGraphTimeScan.PlotGraph();
					//'for plotting a graph
					Application.DoEvents();
					AASGraphTimeScan.Refresh();
				}
			}
			Application.DoEvents();

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
		// Procedure Name        : funcClearGraph
		// Parameters Passed     :  
		// Returns               : True or False
		// Purpose               : for clearing a graph
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : 12.10.06
		// Revisions             : 
		//=====================================================================
		long lngDataCount;
		//Dim objReadingCol As New Spectrum.Readings
		double dblFromX;
		double dblFromY;
		double dblToX;
		double dblToY;
		//'as the name 
		//' this clear all the point on the graph


		try {
			mintChannelIndex = 0;
			//mobjChannnels.Clear()
			ArrlstGraphCurveItem.Clear();
			//'clear the array
			AASGraphTimeScan.AldysPane.CurveList.Clear();
			AASGraphTimeScan.Refresh();
			Application.DoEvents();
			//'allow application to perfrom panding work
			intCurveIndex = 0;
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
		// Purpose               :   for grid showing
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
			mobjclsBgSpectrum.SpectrumWait = true;
			mnuGrid.Checked = !(mnuGrid.Checked);
			this.AASGraphTimeScan.IsShowGrid = mnuGrid.Checked;
			mobjclsBgSpectrum.SpectrumWait = false;

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			mobjclsBgSpectrum.SpectrumWait = false;
		//---------------------------------------------------------
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
			mobjclsBgSpectrum.SpectrumWait = true;
			mnuPeakEdit.Checked = !(mnuPeakEdit.Checked);
			//Me.AASGraphUVSpectrum.IsShowGrid = mnuPeakEdit.Checked
			this.AASGraphTimeScan.submnuPeakEdit_Click(sender, e);
			//call peakEdit_Click procedure for showing peak edit control
			mobjclsBgSpectrum.SpectrumWait = false;

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			mobjclsBgSpectrum.SpectrumWait = false;
		//---------------------------------------------------------
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
			mobjclsBgSpectrum.SpectrumWait = true;
			mnuShowXYValues.Checked = !(mnuShowXYValues.Checked);
			this.AASGraphTimeScan.ShowXYValues = mnuShowXYValues.Checked;
			//Me.AASGraphUVSpectrum.submnuPeakEdit_Click(AASGraphUVSpectrum, System.EventArgs.Empty)
			mobjclsBgSpectrum.SpectrumWait = false;


		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
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
			mobjclsBgSpectrum.SpectrumWait = true;
			mnuLegends.Checked = !(mnuLegends.Checked);
			this.AASGraphTimeScan.AldysPane.Legend.IsVisible = mnuLegends.Checked;
			AASGraphTimeScan.Invalidate();
			//invalidates specified region of the control
			AASGraphTimeScan.Refresh();
			//Me.AASGraphUVSpectrum.submnuPeakEdit_Click(AASGraphUVSpectrum, System.EventArgs.Empty)
			mobjclsBgSpectrum.SpectrumWait = false;


		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			mobjclsBgSpectrum.SpectrumWait = false;
		//---------------------------------------------------------
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
			if (AASGraphTimeScan.IsShowGrid == true) {
				mnuGrid.Checked = true;
			} else {
				mnuGrid.Checked = false;
			}
			mnuGrid.Click += mnuGrid_Click;

			////----- Check Legends on Graph
			mnuLegends.Click -= mnuLegends_Click;
			if (AASGraphTimeScan.AldysPane.Legend.IsVisible == true) {
				mnuLegends.Checked = true;
			} else {
				mnuLegends.Checked = false;
			}
			mnuLegends.Click += mnuLegends_Click;

			////----- Check Show XY Values on Graph
			mnuShowXYValues.Click -= mnuShowXYValues_Click;
			if (AASGraphTimeScan.ShowXYValues == true) {
				mnuShowXYValues.Checked = true;
			} else {
				mnuShowXYValues.Checked = false;
			}
			mnuShowXYValues.Click += mnuShowXYValues_Click;

			mnuPeakEdit.Click -= mnuPeakEdit_Click;
			if (AASGraphTimeScan.ShowXYPeak == true) {
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

	#Region "Shortcut Handlers"

	private void btnIgnite_Click(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : btnIgnite_Click
		// Parameters Passed     :
		// Returns               : bool
		// Purpose               : to handle ignite click event.

		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 21.11.06
		// Revisions             : 
		//=====================================================================

		try {
			if (mblnAvoidFormProcessing == true) {
				return;
			}
			mblnAvoidFormProcessing = true;
			mobjclsBgSpectrum.SpectrumWait = true;

			gobjCommProtocol.mobjCommdll.subTime_Delay(300);
			//---17.11.09
			gobjClsAAS203.funcIgnite(true);
			funcGetInstParameter();

			gobjCommProtocol.mobjCommdll.subTime_Delay(200);
			//---17.11.09

			mblnAvoidFormProcessing = false;
			mobjclsBgSpectrum.SpectrumWait = false;

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);

			mblnAvoidFormProcessing = false;
			mobjclsBgSpectrum.SpectrumWait = false;
		//---------------------------------------------------------
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
		// Parameters Passed     :
		// Returns               : bool
		// Purpose               : to handle btnN2OIgnite_Click event.

		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 21.11.06
		// Revisions             : 
		//=====================================================================
		try {
			if (mblnAvoidFormProcessing == true) {
				return;
			}
			mblnAvoidFormProcessing = true;
			mobjclsBgSpectrum.SpectrumWait = true;

			gobjCommProtocol.mobjCommdll.subTime_Delay(100);
			gobjCommProtocol.funcSwitchOver();
			funcGetInstParameter();

			mobjclsBgSpectrum.SpectrumWait = false;
			mblnAvoidFormProcessing = false;

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);

			mobjclsBgSpectrum.SpectrumWait = false;
			mblnAvoidFormProcessing = false;
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			//---------------------------------------------------------
		}
	}

	private void btnExtinguish_Click(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : btnExtinguish_Click
		// Parameters Passed     :
		// Returns               : bool
		// Purpose               : to handle btnExtinguish_Click event.

		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 21.11.06
		// Revisions             : 
		//=====================================================================
		try {
			if (mblnAvoidFormProcessing == true) {
				return;
			}
			mblnAvoidFormProcessing = true;
			mobjclsBgSpectrum.SpectrumWait = true;

			gobjCommProtocol.mobjCommdll.subTime_Delay(100);
			gobjClsAAS203.funcIgnite(false);
			funcGetInstParameter();

			mobjclsBgSpectrum.SpectrumWait = false;
			mblnAvoidFormProcessing = false;

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);

			mobjclsBgSpectrum.SpectrumWait = false;
			mblnAvoidFormProcessing = false;
		//---------------------------------------------------------
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
			mblnAvoidProcessing = false;
		//---------------------------------------------------------
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
			if (mblnAvoidFormProcessing == true) {
				return;
			}
			mblnAvoidFormProcessing = true;
			mobjclsBgSpectrum.SpectrumWait = true;
			//If Not gstructSettings.AppMode = EnumAppMode.DemoMode Then

			if (!((gstructSettings.AppMode == EnumAppMode.DemoMode) | (gstructSettings.AppMode == EnumAppMode.DemoMode_201) | (gstructSettings.AppMode == EnumAppMode.DemoMode_203D))) {
				Application.DoEvents();
				gobjCommProtocol.mobjCommdll.subTime_Delay(50);
				gobjClsAAS203.funcInstReset();

			} else {
				//Call gobjMessageAdapter.ShowMessage("Alt - R", "Alt - R")
				Application.DoEvents();
			}
			mobjclsBgSpectrum.SpectrumWait = false;
			mblnAvoidFormProcessing = false;
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);

			mobjclsBgSpectrum.SpectrumWait = false;
			mblnAvoidFormProcessing = false;
		//---------------------------------------------------------
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

	#Region "Other functions"
	//case	IDC_ADJFLOW: Optimise_Fuel_Auto(hwnd);
	//						 Scroll_Fuel(hwnd,IDC_FUEL, -1);break;
	//case	IDC_ADJBH:	Optimise_Height_Auto(hwnd);
	//						Scroll_Bh(hwnd,IDC_BH, -1);
	//						Save_BH_Pos();
	//break;




	////---- ComProtocol

	////-----

	////---- clsAAS

	private void DisableButtonsForBurnerHeight()
	{
		//=====================================================================
		// Procedure Name        : DisableButtonsForBurnerHeight
		// Parameters Passed     :
		// Returns               : bool
		// Purpose               : on screen validation for burner height.

		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 21.11.06
		// Revisions             : 
		//=====================================================================
		//'note:
		//'this is called when user going to adjust burner height
		//'this is realted to disble a control

		btnClearSpectrum.Enabled = false;
		btnExtinguish.Enabled = false;
		btnIgnite.Enabled = false;

		btnReturn.Enabled = false;
		mnuReturn.Enabled = false;
		cmdbtnReturn.Enabled = false;

		cmdbtnAutoZero.Enabled = false;
		mnuAutoZero.Enabled = false;
		btnAutoZero.Enabled = false;

		nudD2Cur.Enabled = false;
		nudPMT.Enabled = false;
		nudSlit.Enabled = false;
		//nudSlit_Exit.Enabled = False
		//cmbSpeed.Enabled = False
		cmbModes.Enabled = false;
		nudBurnerHeight.Enabled = false;
		nudFuelRatio.Enabled = false;
		nudHCLCur.Enabled = false;
		//nudPMT_Ref.Enabled = False  'For Double Beam
		//nudSlit_Ref.Enabled = False 'For Double Beam

		cmdADJFlow.Enabled = false;
		cmdbtnAdjFuelFlow.Enabled = false;
		mnuAdjustFuel.Enabled = false;

		cmdChangeScale.Enabled = false;
		cmdbtnChangeScale.Enabled = false;
		mnuChangeScale.Enabled = false;

		mnuAdjustBurnerHeight.Enabled = false;
		cmdbtnAdjBurnerHt.Enabled = false;
		cmdADJBH.Enabled = false;

		//mnuPeakPick.Enabled = False
		//tlbbtnPeakPick.Enabled = False

		//mnuPositionToMaxima.Enabled = False
		//tlbbtnPositionToMaxima.Enabled = False

		//mnuSmooth.Enabled = False
		//tlbbtnSmooth.Enabled = False

		//mnuLoadSpectrunFile.Enabled = False
		//tlbbtnLoadspectrumFile.Enabled = False

		//mnuContiniousTimeScan.Enabled = False
		//tlbbtnContiniousTimeScan.Enabled = False

		//mnuParameters.Enabled = False
		//tlbbtnParameters.Enabled = False

		//mnuPositionToMaxima.Enabled = False
		//tlbbtnPositionToMaxima.Enabled = False
		//'Added By Pankaj 21 May 07
		//mnuLampParameters.Enabled = False
		//tlbbtnLampParameters.Enabled = False
		btnLampParameters.Enabled = false;

		//mnuClearSpectrum.Enabled = False
		//tlbbtnClearSpectrum.Enabled = False

		//tlbbtnPrintGraph.Enabled = False
		//mnuPrintGraph.Enabled = False
	}

	private void EnableButtonsForBurnerHeight()
	{
		//=====================================================================
		// Procedure Name        : EnableButtonsForBurnerHeight
		// Parameters Passed     :
		// Returns               : bool
		// Purpose               : on screen validation for burner height.

		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 21.11.06
		// Revisions             : 
		//=====================================================================
		//'note.
		//'this is called when user going to adjust burner height
		//'this is realted to enable a control

		btnClearSpectrum.Enabled = true;
		btnExtinguish.Enabled = true;
		btnIgnite.Enabled = true;

		btnReturn.Enabled = true;
		mnuReturn.Enabled = true;
		cmdbtnReturn.Enabled = true;

		cmdbtnAutoZero.Enabled = true;
		mnuAutoZero.Enabled = true;
		btnAutoZero.Enabled = true;

		nudD2Cur.Enabled = true;
		nudPMT.Enabled = true;
		nudSlit.Enabled = true;
		//nudSlit_Exit.Enabled = True
		//cmbSpeed.Enabled = False
		cmbModes.Enabled = true;
		nudBurnerHeight.Enabled = true;
		nudFuelRatio.Enabled = true;
		nudHCLCur.Enabled = true;
		//nudPMT_Ref.Enabled = True  'For Double Bea
		//nudSlit_Ref.Enabled = False 'For Double Beam

		cmdADJFlow.Enabled = true;
		cmdbtnAdjFuelFlow.Enabled = true;
		mnuAdjustFuel.Enabled = true;

		cmdChangeScale.Enabled = true;
		cmdbtnChangeScale.Enabled = true;
		mnuChangeScale.Enabled = true;

		mnuAdjustBurnerHeight.Enabled = true;
		cmdbtnAdjBurnerHt.Enabled = true;
		cmdADJBH.Enabled = true;

		//mnuPeakPick.Enabled = False
		//tlbbtnPeakPick.Enabled = False

		//mnuPositionToMaxima.Enabled = False
		//tlbbtnPositionToMaxima.Enabled = False

		//mnuSmooth.Enabled = False
		//tlbbtnSmooth.Enabled = False

		//mnuLoadSpectrunFile.Enabled = False
		//tlbbtnLoadspectrumFile.Enabled = False

		//mnuContiniousTimeScan.Enabled = False
		//tlbbtnContiniousTimeScan.Enabled = False

		//mnuParameters.Enabled = False
		//tlbbtnParameters.Enabled = False

		//mnuPositionToMaxima.Enabled = False
		//tlbbtnPositionToMaxima.Enabled = False
		//'Added By Pankaj 21 May 07
		//mnuLampParameters.Enabled = False
		//tlbbtnLampParameters.Enabled = False
		btnLampParameters.Enabled = true;

		//mnuClearSpectrum.Enabled = False
		//tlbbtnClearSpectrum.Enabled = False

		//tlbbtnPrintGraph.Enabled = False
		//mnuPrintGraph.Enabled = False
	}

	//Private Sub frmTimeScanMode_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
	//    '=====================================================================
	//    ' Procedure Name        : frmTimeScanMode_Activated
	//    ' Parameters Passed     :
	//    ' Returns               : bool
	//    ' Purpose               : this will activated a time scan mode.

	//    ' Description           : 
	//    ' Assumptions           : 
	//    ' Dependencies          : 
	//    ' Author                : Sachin Dokhale
	//    ' Created               : 21.11.06
	//    ' Revisions             : 
	//    '=====================================================================
	//    Try
	//        'If blnActivateStartTimeScan = False Then
	//        '    Call funcSetDefaultParameter()
	//        '    ''for setting default parameter
	//        '    nudD2Cur.Visible = True
	//        '    nudPMT.Visible = True
	//        '    nudSlit.Visible = True
	//        '    nudHCLCur.Visible = True
	//        '    nudBurnerHeight.Visible = True
	//        '    nudFuelRatio.Visible = True
	//        '    blnActivateStartTimeScan = True
	//        'End If


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

}
