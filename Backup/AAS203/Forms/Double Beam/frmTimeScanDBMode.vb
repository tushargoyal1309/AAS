Imports System.Threading
Imports AAS203.Common
Imports BgThread
Imports System.IO
Imports Microsoft.VisualBasic
Imports AAS203.Spectrum

Public Class frmTimeScanDBMode
    Inherits System.Windows.Forms.Form
    Implements Iclient

#Region " Private Variable "

    '--- Declaration for the controller object of the BgThread
    Private mobjController As New BgThread.clsBgThread(Me)
    Private mobjclsBgSpectrum As New clsBgSpectrum

    'Public WithEvents Status As System.Windows.Forms.TextBox
    Public WithEvents Status As System.Windows.Forms.TextBox

    Private mdblFuelRatio As Double = 0.0
    Private mdblBhHeight As Double = 0.0

    Private mblnSpectrumStarted As Boolean
    Private mblnAvoidProcessing As Boolean = False
    Private mblnAvoidFormProcessing As Boolean = False
    Private mblnExitApplication As Boolean = False
    Private WithEvents mobjfrmEditValues As frmEditValues
    '//----- Graph Items
    Private mdblYaxis As Double
    Private mdblXaxis As Double
    Private mGraphCurveItem As AldysGraph.CurveItem
    Private ArrlstGraphCurveItem As New ArrayList
    Private intCurveIndex As Integer
    '//-----
    Private m_blnBaseline As Boolean = True
    Private InputValue As Double
    Private Structure _Data
        Dim mGraphPlot As Boolean
        Dim mXaxisData As Integer
        Dim mYaxisData As Integer
    End Structure
    'Dim Data As _Data
    '--- declaration of the channels object (collection)
    Private mobjChannnels As New Spectrum.Channels
    Private mobjOnlineChannel As New Spectrum.Channel(True)
    Private mobjOnlineReadings As New Spectrum.Readings
    Private mobjSpectrum As New clsSpectrum

    '--- declaration of the Parameter object used to populate the 
    '--- parameter screen on the spectrum screen
    Private mobjParameters As New Spectrum.EnergySpectrumParameter
    '--- Current channel index
    Private mintChannelIndex As Integer
    '----- Store the Peak and Valley
    Private mStuctPeaksValley(100) As clsSpectrum.PeakValley

    Private strPath As IO.Directory
    '//----- TimeScan 
    Private blnCheckMinAbsScanLmt As Boolean = False
    Private dblAbsScanthldval As Double = 0.0
    Private dblAbs As Double

    Private XaxisTime1 As Long
    Private blnPlotingNew As Boolean = True
    'Private blnPlotingNew_Samp As Boolean = True
    'Private blnPlotingNew_Ref As Boolean = True
    'Private blnPlotingNew_Dbl As Boolean = True
    Private blnPlotingNew_Curve1 As Boolean = True
    Private blnPlotingNew_Curve2 As Boolean = True
    Private blnPlotingNew_Curve3 As Boolean = True


    Private mYValueLable As String = "Sample " & const_Absorbance
    Private mYValueLable_Ref As String = "Ref. " & const_Absorbance
    Private mYValueLable_Double As String = "Double " & const_Absorbance
    Private mstrYaxisFormat As String

    'Private mXValueLable As String = "Timescan (Sc.): "
    Private mXValueLable As String = "Wavelength (nm): "
    Private mblnIsfrmFlameStatusWork As Boolean = False
    Private mblnIsShowDBeam As Boolean = True

    Private mYAXIS_LABEL As String
    Private blnActivateStartTimeScan As Boolean
    '//-----
#End Region

#Region " Constant"
    Private Const ConstFormLoad = "-Time Scan Mode"
    Private Const const_WvMin = 0
    Private Const const_WvMax = 100.0
    'Private Const const_YMinAbs = -0.1
    'Private Const const_YMaxAbs = 0.9
    Private Const const_YMinAbs = -0.2      'Changed by Saurabh 03.08.07
    Private Const const_YMaxAbs = 1.2       'Changed by Saurabh 03.08.07
    'Private Const const_YMinAbs = -2.7
    'Private Const const_YMaxAbs = 2.7
    Private Const const_YMinEnergy = 0.0
    Private Const const_YMaxEnergy = 100.0
    'Private Const const_YMinEnergy = -110.0
    'Private Const const_YMaxEnergy = 110.0
    Private Const const_YMinEmission = 0.0
    Private Const const_YMaxEmission = 100.0
    'Private Const const_YMinEmission = -110.0
    'Private Const const_YMaxEmission = 110.0

    Private Const const_YMinmVolt = -5000.0
    'Private Const const_YMaxmVolt = 5000.0
    'Private Const const_YMinmVolt = 0.0
    Private Const const_YMaxmVolt = 5000.0

    Private Const const_Absorbance = "Absorbance "
    Private Const const_Energy = "Energy "
    Private Const const_Emission = "Emission "
    Private Const const_Volt = "Volt (mV)"
    Private Const const_Sample = "Sample Beam"
    Private Const const_Reference = "Ref. Beam"
    Private Const const_Double = "Double Beam"
    Private Const const_ABSORBANCE_YLabel = "ABSORBANCE"
    Private Const const_ENERGY_YLabel = "ENERGY"
    Private Const const_EMISSION_YLabel = "EMISSION"


#End Region

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Call frmLoad()
    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents CustomPanelMain As GradientPanel.CustomPanel
    Friend WithEvents CustomPanelBottom As GradientPanel.CustomPanel
    Friend WithEvents btnLampParameters As NETXP.Controls.XPButton
    Friend WithEvents btnReturn As NETXP.Controls.XPButton
    Friend WithEvents StatusBar1 As NETXP.Controls.Bars.StatusBar
    Friend WithEvents StatusBarPanelInfo As System.Windows.Forms.StatusBarPanel
    Friend WithEvents ProgressPanel As NETXP.Controls.Bars.ProgressPanel
    Friend WithEvents StatusBarPanelDate As System.Windows.Forms.StatusBarPanel
    Friend WithEvents cmdChangeScale As NETXP.Controls.XPButton
    'Friend WithEvents AASGraphTimeScan As AAS203.AASGraph
    Friend WithEvents btnAutoZero As NETXP.Controls.XPButton
    Friend WithEvents cmdADJFlow As NETXP.Controls.XPButton
    Friend WithEvents cmdADJBH As NETXP.Controls.XPButton
    Friend WithEvents cmdD2GainStatus As NETXP.Controls.XPButton
    Friend WithEvents lblBurnerHeightmm As System.Windows.Forms.Label
    Friend WithEvents lblBurnerHeight As System.Windows.Forms.Label
    Friend WithEvents lblFuelRatio As System.Windows.Forms.Label
    Friend WithEvents lblHCLCurmA As System.Windows.Forms.Label
    Friend WithEvents lblHCLCur As System.Windows.Forms.Label
    Friend WithEvents lblSlitWidthnm As System.Windows.Forms.Label
    Friend WithEvents lblPMTVolts As System.Windows.Forms.Label
    Friend WithEvents lblD2CurmA As System.Windows.Forms.Label
    Friend WithEvents cmbModes As System.Windows.Forms.ComboBox
    Friend WithEvents lblModes As System.Windows.Forms.Label
    Friend WithEvents lblSlitWidth As System.Windows.Forms.Label
    Friend WithEvents lblD2Cur As System.Windows.Forms.Label
    Friend WithEvents lblPMT As System.Windows.Forms.Label
    Friend WithEvents CustomPanelTop As GradientPanel.CustomPanel
    Friend WithEvents AASGraphTimeScan As AAS203.AASGraph
    Friend WithEvents lblTime As System.Windows.Forms.Label
    Friend WithEvents lblWvPos As System.Windows.Forms.Label
    Friend WithEvents lblYValue As System.Windows.Forms.Label
    Friend WithEvents HeaderLeft As CodeIntellects.Office2003Controls.Office2003Header
    Friend WithEvents Office2003Header1 As CodeIntellects.Office2003Controls.Office2003Header
    Friend WithEvents CommandBar1 As NETXP.Controls.Bars.CommandBar
    Friend WithEvents cmdbtnReturn As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents cmdbtnAutoZero As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents cmdbtnAdjFuelFlow As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents cmdbtnAdjBurnerHt As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents cmdbtnChangeScale As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents nudPMT As ValueEditor.ValueEditor
    Friend WithEvents nudSlit As ValueEditor.ValueEditor
    Friend WithEvents nudHCLCur As ValueEditor.ValueEditor
    Friend WithEvents nudD2Cur As ValueEditor.ValueEditor
    Friend WithEvents nudFuelRatio As ValueEditor.ValueEditor
    Friend WithEvents nudBurnerHeight As ValueEditor.ValueEditor
    Friend WithEvents nudSlit_Exit As ValueEditor.ValueEditor
    Friend WithEvents lblSlitWidthnm_Exit As System.Windows.Forms.Label
    Friend WithEvents lblSlitWidth_Exit As System.Windows.Forms.Label
    Friend WithEvents nudPMT_Ref As ValueEditor.ValueEditor
    Friend WithEvents lblPMTVolts_Ref As System.Windows.Forms.Label
    Friend WithEvents lblPMT_Ref As System.Windows.Forms.Label
    Friend WithEvents lblYValue_Double As System.Windows.Forms.Label
    Friend WithEvents lblYValue_Ref As System.Windows.Forms.Label
    Friend WithEvents MenuBarEnergySpectrumMode As NETXP.Controls.Bars.CommandBar
    Friend WithEvents mnuFile As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuDataProcessing As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuGraphOptions As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuReturn As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuAutoZero As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuAdjustFuel As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuAdjustBurnerHeight As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuPeakEdit As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuGrid As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuLegends As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuShowXYValues As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuChangeScale As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents btnClearSpectrum As NETXP.Controls.XPButton
    Friend WithEvents CommandBarSeparatorItem1 As NETXP.Controls.Bars.CommandBarSeparatorItem
    Friend WithEvents mnuPrintGraph As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents CommandBarSeparatorItem2 As NETXP.Controls.Bars.CommandBarSeparatorItem
    Friend WithEvents cmdbtnPrintGraph As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents btnDelete As NETXP.Controls.XPButton
    Friend WithEvents btnR As NETXP.Controls.XPButton
    Friend WithEvents btnExtinguish As NETXP.Controls.XPButton
    Friend WithEvents btnIgnite As NETXP.Controls.XPButton
    Friend WithEvents btnN2OIgnite As NETXP.Controls.XPButton
    Friend WithEvents cmdFilter As NETXP.Controls.XPButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmTimeScanDBMode))
        Me.CustomPanelMain = New GradientPanel.CustomPanel
        Me.AASGraphTimeScan = New AAS203.AASGraph
        Me.Office2003Header1 = New CodeIntellects.Office2003Controls.Office2003Header
        Me.CustomPanelBottom = New GradientPanel.CustomPanel
        Me.cmdFilter = New NETXP.Controls.XPButton
        Me.cmdADJBH = New NETXP.Controls.XPButton
        Me.cmdADJFlow = New NETXP.Controls.XPButton
        Me.cmdChangeScale = New NETXP.Controls.XPButton
        Me.btnAutoZero = New NETXP.Controls.XPButton
        Me.btnLampParameters = New NETXP.Controls.XPButton
        Me.btnClearSpectrum = New NETXP.Controls.XPButton
        Me.btnReturn = New NETXP.Controls.XPButton
        Me.btnR = New NETXP.Controls.XPButton
        Me.CustomPanelTop = New GradientPanel.CustomPanel
        Me.lblYValue_Ref = New System.Windows.Forms.Label
        Me.lblYValue_Double = New System.Windows.Forms.Label
        Me.nudPMT_Ref = New ValueEditor.ValueEditor
        Me.lblPMTVolts_Ref = New System.Windows.Forms.Label
        Me.lblPMT_Ref = New System.Windows.Forms.Label
        Me.nudSlit_Exit = New ValueEditor.ValueEditor
        Me.lblSlitWidthnm_Exit = New System.Windows.Forms.Label
        Me.lblSlitWidth_Exit = New System.Windows.Forms.Label
        Me.lblTime = New System.Windows.Forms.Label
        Me.nudBurnerHeight = New ValueEditor.ValueEditor
        Me.nudFuelRatio = New ValueEditor.ValueEditor
        Me.nudD2Cur = New ValueEditor.ValueEditor
        Me.nudHCLCur = New ValueEditor.ValueEditor
        Me.nudSlit = New ValueEditor.ValueEditor
        Me.nudPMT = New ValueEditor.ValueEditor
        Me.HeaderLeft = New CodeIntellects.Office2003Controls.Office2003Header
        Me.lblYValue = New System.Windows.Forms.Label
        Me.lblWvPos = New System.Windows.Forms.Label
        Me.lblBurnerHeightmm = New System.Windows.Forms.Label
        Me.lblBurnerHeight = New System.Windows.Forms.Label
        Me.lblFuelRatio = New System.Windows.Forms.Label
        Me.lblHCLCurmA = New System.Windows.Forms.Label
        Me.lblHCLCur = New System.Windows.Forms.Label
        Me.lblSlitWidthnm = New System.Windows.Forms.Label
        Me.lblPMTVolts = New System.Windows.Forms.Label
        Me.lblD2CurmA = New System.Windows.Forms.Label
        Me.cmbModes = New System.Windows.Forms.ComboBox
        Me.lblModes = New System.Windows.Forms.Label
        Me.lblSlitWidth = New System.Windows.Forms.Label
        Me.lblD2Cur = New System.Windows.Forms.Label
        Me.lblPMT = New System.Windows.Forms.Label
        Me.cmdD2GainStatus = New NETXP.Controls.XPButton
        Me.btnDelete = New NETXP.Controls.XPButton
        Me.btnExtinguish = New NETXP.Controls.XPButton
        Me.btnIgnite = New NETXP.Controls.XPButton
        Me.btnN2OIgnite = New NETXP.Controls.XPButton
        Me.StatusBar1 = New NETXP.Controls.Bars.StatusBar
        Me.StatusBarPanelInfo = New System.Windows.Forms.StatusBarPanel
        Me.ProgressPanel = New NETXP.Controls.Bars.ProgressPanel
        Me.StatusBarPanelDate = New System.Windows.Forms.StatusBarPanel
        Me.CommandBar1 = New NETXP.Controls.Bars.CommandBar
        Me.cmdbtnReturn = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.cmdbtnAutoZero = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.cmdbtnAdjFuelFlow = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.cmdbtnAdjBurnerHt = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.cmdbtnChangeScale = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.CommandBarSeparatorItem2 = New NETXP.Controls.Bars.CommandBarSeparatorItem
        Me.cmdbtnPrintGraph = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.MenuBarEnergySpectrumMode = New NETXP.Controls.Bars.CommandBar
        Me.mnuFile = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuReturn = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuDataProcessing = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuAutoZero = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuAdjustFuel = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuAdjustBurnerHeight = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuGraphOptions = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuPeakEdit = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuGrid = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuLegends = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuShowXYValues = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuChangeScale = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.CommandBarSeparatorItem1 = New NETXP.Controls.Bars.CommandBarSeparatorItem
        Me.mnuPrintGraph = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.CustomPanelMain.SuspendLayout()
        Me.CustomPanelBottom.SuspendLayout()
        Me.CustomPanelTop.SuspendLayout()
        CType(Me.StatusBarPanelInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProgressPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StatusBarPanelDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CommandBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MenuBarEnergySpectrumMode, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CustomPanelMain
        '
        Me.CustomPanelMain.BackColor = System.Drawing.Color.AliceBlue
        Me.CustomPanelMain.Controls.Add(Me.AASGraphTimeScan)
        Me.CustomPanelMain.Controls.Add(Me.Office2003Header1)
        Me.CustomPanelMain.Controls.Add(Me.CustomPanelBottom)
        Me.CustomPanelMain.Controls.Add(Me.CustomPanelTop)
        Me.CustomPanelMain.Controls.Add(Me.btnExtinguish)
        Me.CustomPanelMain.Controls.Add(Me.btnIgnite)
        Me.CustomPanelMain.Controls.Add(Me.btnN2OIgnite)
        Me.CustomPanelMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CustomPanelMain.Location = New System.Drawing.Point(0, 57)
        Me.CustomPanelMain.Name = "CustomPanelMain"
        Me.CustomPanelMain.Size = New System.Drawing.Size(776, 456)
        Me.CustomPanelMain.TabIndex = 3
        '
        'AASGraphTimeScan
        '
        Me.AASGraphTimeScan.AldysGraphCursor = Nothing
        Me.AASGraphTimeScan.AldysGraphPrintColor = System.Drawing.Color.Black
        Me.AASGraphTimeScan.BackColor = System.Drawing.Color.LightGray
        Me.AASGraphTimeScan.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AASGraphTimeScan.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AASGraphTimeScan.GraphDataSource = Nothing
        Me.AASGraphTimeScan.GraphImage = Nothing
        Me.AASGraphTimeScan.IsShowGrid = True
        Me.AASGraphTimeScan.Location = New System.Drawing.Point(186, 22)
        Me.AASGraphTimeScan.Name = "AASGraphTimeScan"
        Me.AASGraphTimeScan.Size = New System.Drawing.Size(590, 367)
        Me.AASGraphTimeScan.TabIndex = 25
        Me.AASGraphTimeScan.UseDefaultSettings = True
        Me.AASGraphTimeScan.XAxisDateMax = New Date(CType(0, Long))
        Me.AASGraphTimeScan.XAxisDateMin = New Date(CType(0, Long))
        Me.AASGraphTimeScan.XAxisDateScaleFormat = AAS203.AASGraph.enumDateScaleFormat.YYYY
        Me.AASGraphTimeScan.XAxisLabel = "X Values"
        Me.AASGraphTimeScan.XAxisMax = 100
        Me.AASGraphTimeScan.XAxisMin = 0
        Me.AASGraphTimeScan.XAxisMinorStep = 5
        Me.AASGraphTimeScan.XAxisScaleFormat = Nothing
        Me.AASGraphTimeScan.XAxisStep = 10
        Me.AASGraphTimeScan.XAxisType = AldysGraph.AxisType.Linear
        Me.AASGraphTimeScan.YAxisLabel = "Y Values"
        Me.AASGraphTimeScan.YAxisMax = 100
        Me.AASGraphTimeScan.YAxisMin = -1
        Me.AASGraphTimeScan.YAxisMinorStep = 5
        Me.AASGraphTimeScan.YAxisScaleFormat = Nothing
        Me.AASGraphTimeScan.YAxisStep = 10
        Me.AASGraphTimeScan.YAxisType = AldysGraph.AxisType.Linear
        '
        'Office2003Header1
        '
        Me.Office2003Header1.BackColor = System.Drawing.SystemColors.Control
        Me.Office2003Header1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Office2003Header1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Office2003Header1.Location = New System.Drawing.Point(186, 0)
        Me.Office2003Header1.Name = "Office2003Header1"
        Me.Office2003Header1.Size = New System.Drawing.Size(590, 22)
        Me.Office2003Header1.TabIndex = 48
        Me.Office2003Header1.TitleFont = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Office2003Header1.TitleText = "Time Scan"
        '
        'CustomPanelBottom
        '
        Me.CustomPanelBottom.BackColor = System.Drawing.Color.AliceBlue
        Me.CustomPanelBottom.Controls.Add(Me.cmdFilter)
        Me.CustomPanelBottom.Controls.Add(Me.cmdADJBH)
        Me.CustomPanelBottom.Controls.Add(Me.cmdADJFlow)
        Me.CustomPanelBottom.Controls.Add(Me.cmdChangeScale)
        Me.CustomPanelBottom.Controls.Add(Me.btnAutoZero)
        Me.CustomPanelBottom.Controls.Add(Me.btnLampParameters)
        Me.CustomPanelBottom.Controls.Add(Me.btnClearSpectrum)
        Me.CustomPanelBottom.Controls.Add(Me.btnReturn)
        Me.CustomPanelBottom.Controls.Add(Me.btnR)
        Me.CustomPanelBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.CustomPanelBottom.Location = New System.Drawing.Point(186, 389)
        Me.CustomPanelBottom.Name = "CustomPanelBottom"
        Me.CustomPanelBottom.Size = New System.Drawing.Size(590, 67)
        Me.CustomPanelBottom.TabIndex = 1
        '
        'cmdFilter
        '
        Me.cmdFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdFilter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdFilter.Location = New System.Drawing.Point(550, 12)
        Me.cmdFilter.Name = "cmdFilter"
        Me.cmdFilter.Size = New System.Drawing.Size(34, 38)
        Me.cmdFilter.TabIndex = 138
        Me.cmdFilter.Text = "&Filter"
        '
        'cmdADJBH
        '
        Me.cmdADJBH.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdADJBH.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdADJBH.Image = CType(resources.GetObject("cmdADJBH.Image"), System.Drawing.Image)
        Me.cmdADJBH.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdADJBH.Location = New System.Drawing.Point(223, 12)
        Me.cmdADJBH.Name = "cmdADJBH"
        Me.cmdADJBH.Size = New System.Drawing.Size(110, 38)
        Me.cmdADJBH.TabIndex = 2
        Me.cmdADJBH.Text = "Auto &Burner Height"
        '
        'cmdADJFlow
        '
        Me.cmdADJFlow.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdADJFlow.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdADJFlow.Image = CType(resources.GetObject("cmdADJFlow.Image"), System.Drawing.Image)
        Me.cmdADJFlow.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdADJFlow.Location = New System.Drawing.Point(116, 12)
        Me.cmdADJFlow.Name = "cmdADJFlow"
        Me.cmdADJFlow.Size = New System.Drawing.Size(100, 36)
        Me.cmdADJFlow.TabIndex = 1
        Me.cmdADJFlow.Text = "Auto &Fuel Flow"
        Me.cmdADJFlow.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'cmdChangeScale
        '
        Me.cmdChangeScale.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdChangeScale.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdChangeScale.Image = CType(resources.GetObject("cmdChangeScale.Image"), System.Drawing.Image)
        Me.cmdChangeScale.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdChangeScale.Location = New System.Drawing.Point(340, 12)
        Me.cmdChangeScale.Name = "cmdChangeScale"
        Me.cmdChangeScale.Size = New System.Drawing.Size(100, 38)
        Me.cmdChangeScale.TabIndex = 3
        Me.cmdChangeScale.Text = "Chan&ge Scale"
        Me.cmdChangeScale.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'btnAutoZero
        '
        Me.btnAutoZero.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAutoZero.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAutoZero.Image = CType(resources.GetObject("btnAutoZero.Image"), System.Drawing.Image)
        Me.btnAutoZero.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAutoZero.Location = New System.Drawing.Point(9, 12)
        Me.btnAutoZero.Name = "btnAutoZero"
        Me.btnAutoZero.Size = New System.Drawing.Size(100, 35)
        Me.btnAutoZero.TabIndex = 0
        Me.btnAutoZero.Text = "Auto&Zero"
        '
        'btnLampParameters
        '
        Me.btnLampParameters.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLampParameters.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLampParameters.Location = New System.Drawing.Point(410, 72)
        Me.btnLampParameters.Name = "btnLampParameters"
        Me.btnLampParameters.Size = New System.Drawing.Size(106, 30)
        Me.btnLampParameters.TabIndex = 9
        Me.btnLampParameters.Text = "&Lamp Parameters"
        Me.btnLampParameters.Visible = False
        '
        'btnClearSpectrum
        '
        Me.btnClearSpectrum.BackColor = System.Drawing.Color.Transparent
        Me.btnClearSpectrum.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClearSpectrum.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClearSpectrum.Location = New System.Drawing.Point(352, 78)
        Me.btnClearSpectrum.Name = "btnClearSpectrum"
        Me.btnClearSpectrum.Size = New System.Drawing.Size(106, 30)
        Me.btnClearSpectrum.TabIndex = 10
        Me.btnClearSpectrum.Text = "Clear Spectrum"
        Me.btnClearSpectrum.Visible = False
        '
        'btnReturn
        '
        Me.btnReturn.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnReturn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnReturn.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReturn.Image = CType(resources.GetObject("btnReturn.Image"), System.Drawing.Image)
        Me.btnReturn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReturn.Location = New System.Drawing.Point(447, 12)
        Me.btnReturn.Name = "btnReturn"
        Me.btnReturn.Size = New System.Drawing.Size(100, 38)
        Me.btnReturn.TabIndex = 4
        Me.btnReturn.Text = "Return"
        '
        'btnR
        '
        Me.btnR.BackColor = System.Drawing.Color.Transparent
        Me.btnR.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnR.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnR.Location = New System.Drawing.Point(82, 29)
        Me.btnR.Name = "btnR"
        Me.btnR.Size = New System.Drawing.Size(8, 8)
        Me.btnR.TabIndex = 137
        Me.btnR.TabStop = False
        Me.btnR.Text = "&R"
        Me.btnR.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'CustomPanelTop
        '
        Me.CustomPanelTop.BackColor = System.Drawing.Color.AliceBlue
        Me.CustomPanelTop.Controls.Add(Me.lblYValue_Ref)
        Me.CustomPanelTop.Controls.Add(Me.lblYValue_Double)
        Me.CustomPanelTop.Controls.Add(Me.nudPMT_Ref)
        Me.CustomPanelTop.Controls.Add(Me.lblPMTVolts_Ref)
        Me.CustomPanelTop.Controls.Add(Me.lblPMT_Ref)
        Me.CustomPanelTop.Controls.Add(Me.nudSlit_Exit)
        Me.CustomPanelTop.Controls.Add(Me.lblSlitWidthnm_Exit)
        Me.CustomPanelTop.Controls.Add(Me.lblSlitWidth_Exit)
        Me.CustomPanelTop.Controls.Add(Me.lblTime)
        Me.CustomPanelTop.Controls.Add(Me.nudBurnerHeight)
        Me.CustomPanelTop.Controls.Add(Me.nudFuelRatio)
        Me.CustomPanelTop.Controls.Add(Me.nudD2Cur)
        Me.CustomPanelTop.Controls.Add(Me.nudHCLCur)
        Me.CustomPanelTop.Controls.Add(Me.nudSlit)
        Me.CustomPanelTop.Controls.Add(Me.nudPMT)
        Me.CustomPanelTop.Controls.Add(Me.HeaderLeft)
        Me.CustomPanelTop.Controls.Add(Me.lblYValue)
        Me.CustomPanelTop.Controls.Add(Me.lblWvPos)
        Me.CustomPanelTop.Controls.Add(Me.lblBurnerHeightmm)
        Me.CustomPanelTop.Controls.Add(Me.lblBurnerHeight)
        Me.CustomPanelTop.Controls.Add(Me.lblFuelRatio)
        Me.CustomPanelTop.Controls.Add(Me.lblHCLCurmA)
        Me.CustomPanelTop.Controls.Add(Me.lblHCLCur)
        Me.CustomPanelTop.Controls.Add(Me.lblSlitWidthnm)
        Me.CustomPanelTop.Controls.Add(Me.lblPMTVolts)
        Me.CustomPanelTop.Controls.Add(Me.lblD2CurmA)
        Me.CustomPanelTop.Controls.Add(Me.cmbModes)
        Me.CustomPanelTop.Controls.Add(Me.lblModes)
        Me.CustomPanelTop.Controls.Add(Me.lblSlitWidth)
        Me.CustomPanelTop.Controls.Add(Me.lblD2Cur)
        Me.CustomPanelTop.Controls.Add(Me.lblPMT)
        Me.CustomPanelTop.Controls.Add(Me.cmdD2GainStatus)
        Me.CustomPanelTop.Controls.Add(Me.btnDelete)
        Me.CustomPanelTop.Dock = System.Windows.Forms.DockStyle.Left
        Me.CustomPanelTop.Location = New System.Drawing.Point(0, 0)
        Me.CustomPanelTop.Name = "CustomPanelTop"
        Me.CustomPanelTop.Size = New System.Drawing.Size(186, 456)
        Me.CustomPanelTop.TabIndex = 0
        '
        'lblYValue_Ref
        '
        Me.lblYValue_Ref.BackColor = System.Drawing.Color.White
        Me.lblYValue_Ref.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblYValue_Ref.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblYValue_Ref.ForeColor = System.Drawing.Color.Blue
        Me.lblYValue_Ref.Location = New System.Drawing.Point(12, 400)
        Me.lblYValue_Ref.Name = "lblYValue_Ref"
        Me.lblYValue_Ref.Size = New System.Drawing.Size(166, 20)
        Me.lblYValue_Ref.TabIndex = 61
        Me.lblYValue_Ref.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblYValue_Double
        '
        Me.lblYValue_Double.BackColor = System.Drawing.Color.White
        Me.lblYValue_Double.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblYValue_Double.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblYValue_Double.ForeColor = System.Drawing.Color.Blue
        Me.lblYValue_Double.Location = New System.Drawing.Point(12, 434)
        Me.lblYValue_Double.Name = "lblYValue_Double"
        Me.lblYValue_Double.Size = New System.Drawing.Size(166, 20)
        Me.lblYValue_Double.TabIndex = 60
        Me.lblYValue_Double.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'nudPMT_Ref
        '
        Me.nudPMT_Ref.BackColor = System.Drawing.SystemColors.Window
        Me.nudPMT_Ref.BackgroundColor = System.Drawing.SystemColors.Window
        Me.nudPMT_Ref.ButtonClicked = ValueEditor.ValueEditor.EnumValueEditorButtons.MainButton
        Me.nudPMT_Ref.ChangeFactor = 0
        Me.nudPMT_Ref.DecimalPlace = 0
        Me.nudPMT_Ref.DnButtonText = "6"
        Me.nudPMT_Ref.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nudPMT_Ref.ForeColor = System.Drawing.SystemColors.ControlText
        Me.nudPMT_Ref.ForegroundColor = System.Drawing.SystemColors.ControlText
        Me.nudPMT_Ref.IsReverseOperation = False
        Me.nudPMT_Ref.IsUpDownButtonToBeDisabledOnValueChange = False
        Me.nudPMT_Ref.Location = New System.Drawing.Point(74, 67)
        Me.nudPMT_Ref.MaxValue = 0
        Me.nudPMT_Ref.MinValue = 0
        Me.nudPMT_Ref.Name = "nudPMT_Ref"
        Me.nudPMT_Ref.Size = New System.Drawing.Size(72, 22)
        Me.nudPMT_Ref.TabIndex = 5
        Me.nudPMT_Ref.UpButtonText = "5"
        Me.nudPMT_Ref.Value = 0
        Me.nudPMT_Ref.ValueEditorEnabled = True
        Me.nudPMT_Ref.ValueEditorFont = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nudPMT_Ref.Visible = False
        '
        'lblPMTVolts_Ref
        '
        Me.lblPMTVolts_Ref.BackColor = System.Drawing.Color.Transparent
        Me.lblPMTVolts_Ref.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPMTVolts_Ref.Location = New System.Drawing.Point(148, 72)
        Me.lblPMTVolts_Ref.Name = "lblPMTVolts_Ref"
        Me.lblPMTVolts_Ref.Size = New System.Drawing.Size(32, 18)
        Me.lblPMTVolts_Ref.TabIndex = 58
        Me.lblPMTVolts_Ref.Text = "volts"
        Me.lblPMTVolts_Ref.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPMT_Ref
        '
        Me.lblPMT_Ref.BackColor = System.Drawing.Color.Transparent
        Me.lblPMT_Ref.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPMT_Ref.Location = New System.Drawing.Point(13, 65)
        Me.lblPMT_Ref.Name = "lblPMT_Ref"
        Me.lblPMT_Ref.Size = New System.Drawing.Size(60, 28)
        Me.lblPMT_Ref.TabIndex = 57
        Me.lblPMT_Ref.Text = "Ref. PMT"
        Me.lblPMT_Ref.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'nudSlit_Exit
        '
        Me.nudSlit_Exit.BackColor = System.Drawing.SystemColors.Window
        Me.nudSlit_Exit.BackgroundColor = System.Drawing.SystemColors.Window
        Me.nudSlit_Exit.ButtonClicked = ValueEditor.ValueEditor.EnumValueEditorButtons.MainButton
        Me.nudSlit_Exit.ChangeFactor = 0
        Me.nudSlit_Exit.DecimalPlace = 0
        Me.nudSlit_Exit.DnButtonText = "6"
        Me.nudSlit_Exit.Enabled = False
        Me.nudSlit_Exit.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nudSlit_Exit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.nudSlit_Exit.ForegroundColor = System.Drawing.SystemColors.ControlText
        Me.nudSlit_Exit.IsReverseOperation = False
        Me.nudSlit_Exit.IsUpDownButtonToBeDisabledOnValueChange = False
        Me.nudSlit_Exit.Location = New System.Drawing.Point(74, 186)
        Me.nudSlit_Exit.MaxValue = 0
        Me.nudSlit_Exit.MinValue = 0
        Me.nudSlit_Exit.Name = "nudSlit_Exit"
        Me.nudSlit_Exit.Size = New System.Drawing.Size(72, 22)
        Me.nudSlit_Exit.TabIndex = 17
        Me.nudSlit_Exit.UpButtonText = "5"
        Me.nudSlit_Exit.Value = 0
        Me.nudSlit_Exit.ValueEditorEnabled = False
        Me.nudSlit_Exit.ValueEditorFont = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nudSlit_Exit.Visible = False
        '
        'lblSlitWidthnm_Exit
        '
        Me.lblSlitWidthnm_Exit.BackColor = System.Drawing.Color.Transparent
        Me.lblSlitWidthnm_Exit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSlitWidthnm_Exit.Location = New System.Drawing.Point(148, 190)
        Me.lblSlitWidthnm_Exit.Name = "lblSlitWidthnm_Exit"
        Me.lblSlitWidthnm_Exit.Size = New System.Drawing.Size(24, 18)
        Me.lblSlitWidthnm_Exit.TabIndex = 55
        Me.lblSlitWidthnm_Exit.Text = "nm"
        Me.lblSlitWidthnm_Exit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSlitWidth_Exit
        '
        Me.lblSlitWidth_Exit.BackColor = System.Drawing.Color.Transparent
        Me.lblSlitWidth_Exit.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSlitWidth_Exit.Location = New System.Drawing.Point(13, 183)
        Me.lblSlitWidth_Exit.Name = "lblSlitWidth_Exit"
        Me.lblSlitWidth_Exit.Size = New System.Drawing.Size(59, 28)
        Me.lblSlitWidth_Exit.TabIndex = 54
        Me.lblSlitWidth_Exit.Text = "Exit Slit Width"
        Me.lblSlitWidth_Exit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTime
        '
        Me.lblTime.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTime.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTime.Location = New System.Drawing.Point(12, 310)
        Me.lblTime.Name = "lblTime"
        Me.lblTime.Size = New System.Drawing.Size(168, 16)
        Me.lblTime.TabIndex = 39
        Me.lblTime.Text = "Time (Sec.)"
        Me.lblTime.Visible = False
        '
        'nudBurnerHeight
        '
        Me.nudBurnerHeight.BackColor = System.Drawing.SystemColors.Window
        Me.nudBurnerHeight.BackgroundColor = System.Drawing.SystemColors.Window
        Me.nudBurnerHeight.ButtonClicked = ValueEditor.ValueEditor.EnumValueEditorButtons.MainButton
        Me.nudBurnerHeight.ChangeFactor = 0
        Me.nudBurnerHeight.DecimalPlace = 0
        Me.nudBurnerHeight.DnButtonText = "6"
        Me.nudBurnerHeight.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nudBurnerHeight.ForeColor = System.Drawing.SystemColors.ControlText
        Me.nudBurnerHeight.ForegroundColor = System.Drawing.SystemColors.ControlText
        Me.nudBurnerHeight.IsReverseOperation = False
        Me.nudBurnerHeight.IsUpDownButtonToBeDisabledOnValueChange = False
        Me.nudBurnerHeight.Location = New System.Drawing.Point(74, 246)
        Me.nudBurnerHeight.MaxValue = 0
        Me.nudBurnerHeight.MinValue = 0
        Me.nudBurnerHeight.Name = "nudBurnerHeight"
        Me.nudBurnerHeight.Size = New System.Drawing.Size(72, 22)
        Me.nudBurnerHeight.TabIndex = 23
        Me.nudBurnerHeight.UpButtonText = "5"
        Me.nudBurnerHeight.Value = 0
        Me.nudBurnerHeight.ValueEditorEnabled = True
        Me.nudBurnerHeight.ValueEditorFont = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nudBurnerHeight.Visible = False
        '
        'nudFuelRatio
        '
        Me.nudFuelRatio.BackColor = System.Drawing.SystemColors.Window
        Me.nudFuelRatio.BackgroundColor = System.Drawing.SystemColors.Window
        Me.nudFuelRatio.ButtonClicked = ValueEditor.ValueEditor.EnumValueEditorButtons.MainButton
        Me.nudFuelRatio.ChangeFactor = 0
        Me.nudFuelRatio.DecimalPlace = 0
        Me.nudFuelRatio.DnButtonText = "6"
        Me.nudFuelRatio.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nudFuelRatio.ForeColor = System.Drawing.SystemColors.ControlText
        Me.nudFuelRatio.ForegroundColor = System.Drawing.SystemColors.ControlText
        Me.nudFuelRatio.IsReverseOperation = False
        Me.nudFuelRatio.IsUpDownButtonToBeDisabledOnValueChange = False
        Me.nudFuelRatio.Location = New System.Drawing.Point(74, 216)
        Me.nudFuelRatio.MaxValue = 0
        Me.nudFuelRatio.MinValue = 0
        Me.nudFuelRatio.Name = "nudFuelRatio"
        Me.nudFuelRatio.Size = New System.Drawing.Size(72, 22)
        Me.nudFuelRatio.TabIndex = 20
        Me.nudFuelRatio.UpButtonText = "5"
        Me.nudFuelRatio.Value = 0
        Me.nudFuelRatio.ValueEditorEnabled = True
        Me.nudFuelRatio.ValueEditorFont = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nudFuelRatio.Visible = False
        '
        'nudD2Cur
        '
        Me.nudD2Cur.BackColor = System.Drawing.SystemColors.Window
        Me.nudD2Cur.BackgroundColor = System.Drawing.SystemColors.Window
        Me.nudD2Cur.ButtonClicked = ValueEditor.ValueEditor.EnumValueEditorButtons.MainButton
        Me.nudD2Cur.ChangeFactor = 0
        Me.nudD2Cur.DecimalPlace = 0
        Me.nudD2Cur.DnButtonText = "6"
        Me.nudD2Cur.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nudD2Cur.ForeColor = System.Drawing.SystemColors.ControlText
        Me.nudD2Cur.ForegroundColor = System.Drawing.SystemColors.ControlText
        Me.nudD2Cur.IsReverseOperation = False
        Me.nudD2Cur.IsUpDownButtonToBeDisabledOnValueChange = False
        Me.nudD2Cur.Location = New System.Drawing.Point(74, 126)
        Me.nudD2Cur.MaxValue = 0
        Me.nudD2Cur.MinValue = 0
        Me.nudD2Cur.Name = "nudD2Cur"
        Me.nudD2Cur.Size = New System.Drawing.Size(72, 22)
        Me.nudD2Cur.TabIndex = 11
        Me.nudD2Cur.UpButtonText = "5"
        Me.nudD2Cur.Value = 0
        Me.nudD2Cur.ValueEditorEnabled = True
        Me.nudD2Cur.ValueEditorFont = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nudD2Cur.Visible = False
        '
        'nudHCLCur
        '
        Me.nudHCLCur.BackColor = System.Drawing.SystemColors.Window
        Me.nudHCLCur.BackgroundColor = System.Drawing.SystemColors.Window
        Me.nudHCLCur.ButtonClicked = ValueEditor.ValueEditor.EnumValueEditorButtons.MainButton
        Me.nudHCLCur.ChangeFactor = 0
        Me.nudHCLCur.DecimalPlace = 0
        Me.nudHCLCur.DnButtonText = "6"
        Me.nudHCLCur.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nudHCLCur.ForeColor = System.Drawing.SystemColors.ControlText
        Me.nudHCLCur.ForegroundColor = System.Drawing.SystemColors.ControlText
        Me.nudHCLCur.IsReverseOperation = False
        Me.nudHCLCur.IsUpDownButtonToBeDisabledOnValueChange = False
        Me.nudHCLCur.Location = New System.Drawing.Point(74, 97)
        Me.nudHCLCur.MaxValue = 0
        Me.nudHCLCur.MinValue = 0
        Me.nudHCLCur.Name = "nudHCLCur"
        Me.nudHCLCur.Size = New System.Drawing.Size(72, 22)
        Me.nudHCLCur.TabIndex = 8
        Me.nudHCLCur.UpButtonText = "5"
        Me.nudHCLCur.Value = 0
        Me.nudHCLCur.ValueEditorEnabled = True
        Me.nudHCLCur.ValueEditorFont = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nudHCLCur.Visible = False
        '
        'nudSlit
        '
        Me.nudSlit.BackColor = System.Drawing.SystemColors.Window
        Me.nudSlit.BackgroundColor = System.Drawing.SystemColors.Window
        Me.nudSlit.ButtonClicked = ValueEditor.ValueEditor.EnumValueEditorButtons.MainButton
        Me.nudSlit.ChangeFactor = 0
        Me.nudSlit.DecimalPlace = 0
        Me.nudSlit.DnButtonText = "6"
        Me.nudSlit.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nudSlit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.nudSlit.ForegroundColor = System.Drawing.SystemColors.ControlText
        Me.nudSlit.IsReverseOperation = False
        Me.nudSlit.IsUpDownButtonToBeDisabledOnValueChange = False
        Me.nudSlit.Location = New System.Drawing.Point(74, 156)
        Me.nudSlit.MaxValue = 0
        Me.nudSlit.MinValue = 0
        Me.nudSlit.Name = "nudSlit"
        Me.nudSlit.Size = New System.Drawing.Size(72, 22)
        Me.nudSlit.TabIndex = 14
        Me.nudSlit.UpButtonText = "5"
        Me.nudSlit.Value = 0
        Me.nudSlit.ValueEditorEnabled = True
        Me.nudSlit.ValueEditorFont = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nudSlit.Visible = False
        '
        'nudPMT
        '
        Me.nudPMT.BackColor = System.Drawing.SystemColors.Window
        Me.nudPMT.BackgroundColor = System.Drawing.SystemColors.Window
        Me.nudPMT.ButtonClicked = ValueEditor.ValueEditor.EnumValueEditorButtons.MainButton
        Me.nudPMT.ChangeFactor = 0
        Me.nudPMT.DecimalPlace = 0
        Me.nudPMT.DnButtonText = "6"
        Me.nudPMT.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nudPMT.ForeColor = System.Drawing.SystemColors.ControlText
        Me.nudPMT.ForegroundColor = System.Drawing.SystemColors.ControlText
        Me.nudPMT.IsReverseOperation = False
        Me.nudPMT.IsUpDownButtonToBeDisabledOnValueChange = False
        Me.nudPMT.Location = New System.Drawing.Point(74, 37)
        Me.nudPMT.MaxValue = 0
        Me.nudPMT.MinValue = 0
        Me.nudPMT.Name = "nudPMT"
        Me.nudPMT.Size = New System.Drawing.Size(72, 22)
        Me.nudPMT.TabIndex = 2
        Me.nudPMT.UpButtonText = "5"
        Me.nudPMT.Value = 0
        Me.nudPMT.ValueEditorEnabled = True
        Me.nudPMT.ValueEditorFont = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nudPMT.Visible = False
        '
        'HeaderLeft
        '
        Me.HeaderLeft.BackColor = System.Drawing.SystemColors.Control
        Me.HeaderLeft.Dock = System.Windows.Forms.DockStyle.Top
        Me.HeaderLeft.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HeaderLeft.Location = New System.Drawing.Point(0, 0)
        Me.HeaderLeft.Name = "HeaderLeft"
        Me.HeaderLeft.Size = New System.Drawing.Size(186, 22)
        Me.HeaderLeft.TabIndex = 47
        Me.HeaderLeft.TitleFont = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HeaderLeft.TitleText = "Parameters"
        '
        'lblYValue
        '
        Me.lblYValue.BackColor = System.Drawing.Color.White
        Me.lblYValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblYValue.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblYValue.ForeColor = System.Drawing.Color.Blue
        Me.lblYValue.Location = New System.Drawing.Point(12, 369)
        Me.lblYValue.Name = "lblYValue"
        Me.lblYValue.Size = New System.Drawing.Size(166, 20)
        Me.lblYValue.TabIndex = 43
        Me.lblYValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblWvPos
        '
        Me.lblWvPos.BackColor = System.Drawing.Color.White
        Me.lblWvPos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblWvPos.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWvPos.ForeColor = System.Drawing.Color.Blue
        Me.lblWvPos.Location = New System.Drawing.Point(12, 338)
        Me.lblWvPos.Name = "lblWvPos"
        Me.lblWvPos.Size = New System.Drawing.Size(166, 20)
        Me.lblWvPos.TabIndex = 42
        Me.lblWvPos.Text = "Wavelength (nm) :"
        Me.lblWvPos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblBurnerHeightmm
        '
        Me.lblBurnerHeightmm.BackColor = System.Drawing.Color.Transparent
        Me.lblBurnerHeightmm.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBurnerHeightmm.Location = New System.Drawing.Point(148, 255)
        Me.lblBurnerHeightmm.Name = "lblBurnerHeightmm"
        Me.lblBurnerHeightmm.Size = New System.Drawing.Size(24, 20)
        Me.lblBurnerHeightmm.TabIndex = 36
        Me.lblBurnerHeightmm.Text = "mm"
        '
        'lblBurnerHeight
        '
        Me.lblBurnerHeight.BackColor = System.Drawing.Color.Transparent
        Me.lblBurnerHeight.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBurnerHeight.Location = New System.Drawing.Point(13, 245)
        Me.lblBurnerHeight.Name = "lblBurnerHeight"
        Me.lblBurnerHeight.Size = New System.Drawing.Size(65, 28)
        Me.lblBurnerHeight.TabIndex = 34
        Me.lblBurnerHeight.Text = "Burner Ht."
        Me.lblBurnerHeight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblFuelRatio
        '
        Me.lblFuelRatio.BackColor = System.Drawing.Color.Transparent
        Me.lblFuelRatio.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFuelRatio.Location = New System.Drawing.Point(13, 218)
        Me.lblFuelRatio.Name = "lblFuelRatio"
        Me.lblFuelRatio.Size = New System.Drawing.Size(63, 28)
        Me.lblFuelRatio.TabIndex = 32
        Me.lblFuelRatio.Text = "Fuel Ratio"
        Me.lblFuelRatio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblHCLCurmA
        '
        Me.lblHCLCurmA.BackColor = System.Drawing.Color.Transparent
        Me.lblHCLCurmA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHCLCurmA.Location = New System.Drawing.Point(148, 102)
        Me.lblHCLCurmA.Name = "lblHCLCurmA"
        Me.lblHCLCurmA.Size = New System.Drawing.Size(26, 18)
        Me.lblHCLCurmA.TabIndex = 31
        Me.lblHCLCurmA.Text = "mA"
        Me.lblHCLCurmA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblHCLCur
        '
        Me.lblHCLCur.BackColor = System.Drawing.Color.Transparent
        Me.lblHCLCur.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHCLCur.Location = New System.Drawing.Point(13, 92)
        Me.lblHCLCur.Name = "lblHCLCur"
        Me.lblHCLCur.Size = New System.Drawing.Size(56, 28)
        Me.lblHCLCur.TabIndex = 30
        Me.lblHCLCur.Text = "HCL Cur"
        Me.lblHCLCur.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSlitWidthnm
        '
        Me.lblSlitWidthnm.BackColor = System.Drawing.Color.Transparent
        Me.lblSlitWidthnm.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSlitWidthnm.Location = New System.Drawing.Point(148, 160)
        Me.lblSlitWidthnm.Name = "lblSlitWidthnm"
        Me.lblSlitWidthnm.Size = New System.Drawing.Size(24, 18)
        Me.lblSlitWidthnm.TabIndex = 28
        Me.lblSlitWidthnm.Text = "nm"
        Me.lblSlitWidthnm.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPMTVolts
        '
        Me.lblPMTVolts.BackColor = System.Drawing.Color.Transparent
        Me.lblPMTVolts.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPMTVolts.Location = New System.Drawing.Point(148, 42)
        Me.lblPMTVolts.Name = "lblPMTVolts"
        Me.lblPMTVolts.Size = New System.Drawing.Size(32, 18)
        Me.lblPMTVolts.TabIndex = 27
        Me.lblPMTVolts.Text = "volts"
        Me.lblPMTVolts.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblD2CurmA
        '
        Me.lblD2CurmA.BackColor = System.Drawing.Color.Transparent
        Me.lblD2CurmA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblD2CurmA.Location = New System.Drawing.Point(148, 129)
        Me.lblD2CurmA.Name = "lblD2CurmA"
        Me.lblD2CurmA.Size = New System.Drawing.Size(22, 18)
        Me.lblD2CurmA.TabIndex = 26
        Me.lblD2CurmA.Text = "mA"
        Me.lblD2CurmA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbModes
        '
        Me.cmbModes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbModes.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbModes.ItemHeight = 15
        Me.cmbModes.Items.AddRange(New Object() {"AA", "HCLE", "D2E", "EMISSION", "AABGC", "MABS", "SELFTEST"})
        Me.cmbModes.Location = New System.Drawing.Point(65, 276)
        Me.cmbModes.Name = "cmbModes"
        Me.cmbModes.Size = New System.Drawing.Size(82, 23)
        Me.cmbModes.TabIndex = 24
        '
        'lblModes
        '
        Me.lblModes.BackColor = System.Drawing.Color.Transparent
        Me.lblModes.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblModes.Location = New System.Drawing.Point(13, 275)
        Me.lblModes.Name = "lblModes"
        Me.lblModes.Size = New System.Drawing.Size(56, 28)
        Me.lblModes.TabIndex = 8
        Me.lblModes.Text = "Modes"
        Me.lblModes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSlitWidth
        '
        Me.lblSlitWidth.BackColor = System.Drawing.Color.Transparent
        Me.lblSlitWidth.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSlitWidth.Location = New System.Drawing.Point(13, 153)
        Me.lblSlitWidth.Name = "lblSlitWidth"
        Me.lblSlitWidth.Size = New System.Drawing.Size(58, 28)
        Me.lblSlitWidth.TabIndex = 5
        Me.lblSlitWidth.Text = "Entrance Slit Width"
        Me.lblSlitWidth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblD2Cur
        '
        Me.lblD2Cur.BackColor = System.Drawing.Color.Transparent
        Me.lblD2Cur.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblD2Cur.Location = New System.Drawing.Point(13, 122)
        Me.lblD2Cur.Name = "lblD2Cur"
        Me.lblD2Cur.Size = New System.Drawing.Size(56, 28)
        Me.lblD2Cur.TabIndex = 2
        Me.lblD2Cur.Text = "D2Cur"
        Me.lblD2Cur.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPMT
        '
        Me.lblPMT.BackColor = System.Drawing.Color.Transparent
        Me.lblPMT.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPMT.Location = New System.Drawing.Point(15, 36)
        Me.lblPMT.Name = "lblPMT"
        Me.lblPMT.Size = New System.Drawing.Size(51, 28)
        Me.lblPMT.TabIndex = 1
        Me.lblPMT.Text = "Sample PMT"
        Me.lblPMT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdD2GainStatus
        '
        Me.cmdD2GainStatus.BackColor = System.Drawing.Color.Transparent
        Me.cmdD2GainStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdD2GainStatus.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdD2GainStatus.Location = New System.Drawing.Point(22, 302)
        Me.cmdD2GainStatus.Name = "cmdD2GainStatus"
        Me.cmdD2GainStatus.Size = New System.Drawing.Size(106, 30)
        Me.cmdD2GainStatus.TabIndex = 38
        Me.cmdD2GainStatus.Text = "D2 &Gain Status"
        Me.cmdD2GainStatus.Visible = False
        '
        'btnDelete
        '
        Me.btnDelete.BackColor = System.Drawing.Color.Transparent
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelete.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDelete.Location = New System.Drawing.Point(166, 346)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(8, 8)
        Me.btnDelete.TabIndex = 138
        Me.btnDelete.TabStop = False
        Me.btnDelete.Text = "&Delete"
        Me.btnDelete.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'btnExtinguish
        '
        Me.btnExtinguish.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExtinguish.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExtinguish.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExtinguish.Location = New System.Drawing.Point(377, 219)
        Me.btnExtinguish.Name = "btnExtinguish"
        Me.btnExtinguish.Size = New System.Drawing.Size(22, 18)
        Me.btnExtinguish.TabIndex = 49
        Me.btnExtinguish.TabStop = False
        Me.btnExtinguish.Text = "&Extinguish"
        Me.btnExtinguish.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'btnIgnite
        '
        Me.btnIgnite.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnIgnite.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIgnite.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnIgnite.Location = New System.Drawing.Point(378, 220)
        Me.btnIgnite.Name = "btnIgnite"
        Me.btnIgnite.Size = New System.Drawing.Size(20, 17)
        Me.btnIgnite.TabIndex = 50
        Me.btnIgnite.TabStop = False
        Me.btnIgnite.Text = "&Ignition"
        Me.btnIgnite.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'btnN2OIgnite
        '
        Me.btnN2OIgnite.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnN2OIgnite.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnN2OIgnite.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnN2OIgnite.Location = New System.Drawing.Point(386, 226)
        Me.btnN2OIgnite.Name = "btnN2OIgnite"
        Me.btnN2OIgnite.Size = New System.Drawing.Size(5, 5)
        Me.btnN2OIgnite.TabIndex = 137
        Me.btnN2OIgnite.TabStop = False
        Me.btnN2OIgnite.Text = "N2O&C"
        Me.btnN2OIgnite.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'StatusBar1
        '
        Me.StatusBar1.Location = New System.Drawing.Point(0, 513)
        Me.StatusBar1.Name = "StatusBar1"
        Me.StatusBar1.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.StatusBarPanelInfo, Me.ProgressPanel, Me.StatusBarPanelDate})
        Me.StatusBar1.ShowPanels = True
        Me.StatusBar1.Size = New System.Drawing.Size(776, 24)
        Me.StatusBar1.TabIndex = 6
        Me.StatusBar1.Text = "StatusBar1"
        '
        'StatusBarPanelInfo
        '
        Me.StatusBarPanelInfo.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
        Me.StatusBarPanelInfo.MinWidth = 40
        Me.StatusBarPanelInfo.Style = System.Windows.Forms.StatusBarPanelStyle.OwnerDraw
        Me.StatusBarPanelInfo.Width = 481
        '
        'ProgressPanel
        '
        Me.ProgressPanel.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.ProgressPanel.Maximum = 100
        Me.ProgressPanel.Minimum = 0
        Me.ProgressPanel.Style = System.Windows.Forms.StatusBarPanelStyle.OwnerDraw
        Me.ProgressPanel.Value = 0
        Me.ProgressPanel.Width = 200
        '
        'StatusBarPanelDate
        '
        Me.StatusBarPanelDate.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.StatusBarPanelDate.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents
        Me.StatusBarPanelDate.MinWidth = 40
        Me.StatusBarPanelDate.Style = System.Windows.Forms.StatusBarPanelStyle.OwnerDraw
        Me.StatusBarPanelDate.Text = "Current Date"
        Me.StatusBarPanelDate.Width = 79
        '
        'CommandBar1
        '
        Me.CommandBar1.BackColor = System.Drawing.Color.Transparent
        Me.CommandBar1.CustomizeText = "&Customize Toolbar..."
        Me.CommandBar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.CommandBar1.ID = 7308
        Me.CommandBar1.Items.AddRange(New NETXP.Controls.Bars.CommandBarItem() {Me.cmdbtnReturn, Me.cmdbtnAutoZero, Me.cmdbtnAdjFuelFlow, Me.cmdbtnAdjBurnerHt, Me.cmdbtnChangeScale, Me.CommandBarSeparatorItem2, Me.cmdbtnPrintGraph})
        Me.CommandBar1.Location = New System.Drawing.Point(0, 23)
        Me.CommandBar1.Margins.Bottom = 1
        Me.CommandBar1.Margins.Left = 1
        Me.CommandBar1.Margins.Right = 1
        Me.CommandBar1.Margins.Top = 1
        Me.CommandBar1.Name = "CommandBar1"
        Me.CommandBar1.Size = New System.Drawing.Size(776, 34)
        Me.CommandBar1.TabIndex = 0
        Me.CommandBar1.TabStop = False
        Me.CommandBar1.Text = "CommandBar1"
        '
        'cmdbtnReturn
        '
        Me.cmdbtnReturn.Image = CType(resources.GetObject("cmdbtnReturn.Image"), System.Drawing.Image)
        Me.cmdbtnReturn.Shortcut = System.Windows.Forms.Shortcut.CtrlB
        Me.cmdbtnReturn.Text = "BACK"
        '
        'cmdbtnAutoZero
        '
        Me.cmdbtnAutoZero.Image = CType(resources.GetObject("cmdbtnAutoZero.Image"), System.Drawing.Image)
        Me.cmdbtnAutoZero.Shortcut = System.Windows.Forms.Shortcut.CtrlA
        Me.cmdbtnAutoZero.Text = "AUTO ZERO[CTRL + A]"
        '
        'cmdbtnAdjFuelFlow
        '
        Me.cmdbtnAdjFuelFlow.Image = CType(resources.GetObject("cmdbtnAdjFuelFlow.Image"), System.Drawing.Image)
        Me.cmdbtnAdjFuelFlow.Shortcut = System.Windows.Forms.Shortcut.CtrlF
        Me.cmdbtnAdjFuelFlow.Text = "ADJUST FUEL FLOW[CTRL + F]"
        '
        'cmdbtnAdjBurnerHt
        '
        Me.cmdbtnAdjBurnerHt.Image = CType(resources.GetObject("cmdbtnAdjBurnerHt.Image"), System.Drawing.Image)
        Me.cmdbtnAdjBurnerHt.Shortcut = System.Windows.Forms.Shortcut.CtrlB
        Me.cmdbtnAdjBurnerHt.Text = "ADJUST BURNER HEIGHT[CTRL + B]"
        '
        'cmdbtnChangeScale
        '
        Me.cmdbtnChangeScale.Image = CType(resources.GetObject("cmdbtnChangeScale.Image"), System.Drawing.Image)
        Me.cmdbtnChangeScale.Shortcut = System.Windows.Forms.Shortcut.CtrlC
        Me.cmdbtnChangeScale.Text = "CHANGE SCALE[CTRL + C]"
        '
        'cmdbtnPrintGraph
        '
        Me.cmdbtnPrintGraph.Image = CType(resources.GetObject("cmdbtnPrintGraph.Image"), System.Drawing.Image)
        Me.cmdbtnPrintGraph.Shortcut = System.Windows.Forms.Shortcut.CtrlP
        Me.cmdbtnPrintGraph.Text = "Print Graph"
        Me.cmdbtnPrintGraph.Visible = False
        '
        'MenuBarEnergySpectrumMode
        '
        Me.MenuBarEnergySpectrumMode.BackColor = System.Drawing.Color.Transparent
        Me.MenuBarEnergySpectrumMode.CustomizeText = "&Customize Toolbar..."
        Me.MenuBarEnergySpectrumMode.Dock = System.Windows.Forms.DockStyle.Top
        Me.MenuBarEnergySpectrumMode.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuBarEnergySpectrumMode.FullRow = True
        Me.MenuBarEnergySpectrumMode.ID = 621
        Me.MenuBarEnergySpectrumMode.Items.AddRange(New NETXP.Controls.Bars.CommandBarItem() {Me.mnuFile, Me.mnuDataProcessing, Me.mnuGraphOptions})
        Me.MenuBarEnergySpectrumMode.Location = New System.Drawing.Point(0, 0)
        Me.MenuBarEnergySpectrumMode.Margins.Bottom = 1
        Me.MenuBarEnergySpectrumMode.Margins.Left = 1
        Me.MenuBarEnergySpectrumMode.Margins.Right = 1
        Me.MenuBarEnergySpectrumMode.Margins.Top = 1
        Me.MenuBarEnergySpectrumMode.Name = "MenuBarEnergySpectrumMode"
        Me.MenuBarEnergySpectrumMode.Size = New System.Drawing.Size(776, 23)
        Me.MenuBarEnergySpectrumMode.Style = NETXP.Controls.Bars.CommandBarStyle.Menu
        Me.MenuBarEnergySpectrumMode.TabIndex = 8
        Me.MenuBarEnergySpectrumMode.TabStop = False
        Me.MenuBarEnergySpectrumMode.Text = ""
        '
        'mnuFile
        '
        Me.mnuFile.Infrequent = True
        Me.mnuFile.Items.AddRange(New NETXP.Controls.Bars.CommandBarItem() {Me.mnuReturn})
        Me.mnuFile.Text = "&File"
        '
        'mnuReturn
        '
        Me.mnuReturn.Image = CType(resources.GetObject("mnuReturn.Image"), System.Drawing.Image)
        Me.mnuReturn.Shortcut = System.Windows.Forms.Shortcut.CtrlR
        Me.mnuReturn.Text = "Return"
        '
        'mnuDataProcessing
        '
        Me.mnuDataProcessing.Items.AddRange(New NETXP.Controls.Bars.CommandBarItem() {Me.mnuAutoZero, Me.mnuAdjustFuel, Me.mnuAdjustBurnerHeight})
        Me.mnuDataProcessing.Text = "Data &Processing"
        '
        'mnuAutoZero
        '
        Me.mnuAutoZero.Image = CType(resources.GetObject("mnuAutoZero.Image"), System.Drawing.Image)
        Me.mnuAutoZero.Shortcut = System.Windows.Forms.Shortcut.CtrlA
        Me.mnuAutoZero.Text = "Auto &Zero"
        '
        'mnuAdjustFuel
        '
        Me.mnuAdjustFuel.Image = CType(resources.GetObject("mnuAdjustFuel.Image"), System.Drawing.Image)
        Me.mnuAdjustFuel.Shortcut = System.Windows.Forms.Shortcut.CtrlF
        Me.mnuAdjustFuel.Text = "Adjust &Fuel"
        '
        'mnuAdjustBurnerHeight
        '
        Me.mnuAdjustBurnerHeight.Image = CType(resources.GetObject("mnuAdjustBurnerHeight.Image"), System.Drawing.Image)
        Me.mnuAdjustBurnerHeight.Shortcut = System.Windows.Forms.Shortcut.CtrlB
        Me.mnuAdjustBurnerHeight.Text = "Adjust &Burner Height"
        '
        'mnuGraphOptions
        '
        Me.mnuGraphOptions.Items.AddRange(New NETXP.Controls.Bars.CommandBarItem() {Me.mnuPeakEdit, Me.mnuGrid, Me.mnuLegends, Me.mnuShowXYValues, Me.mnuChangeScale, Me.CommandBarSeparatorItem1, Me.mnuPrintGraph})
        Me.mnuGraphOptions.Text = "&Graph Options"
        '
        'mnuPeakEdit
        '
        Me.mnuPeakEdit.Enabled = False
        Me.mnuPeakEdit.Image = CType(resources.GetObject("mnuPeakEdit.Image"), System.Drawing.Image)
        Me.mnuPeakEdit.Text = "Peak Edit"
        Me.mnuPeakEdit.Visible = False
        '
        'mnuGrid
        '
        Me.mnuGrid.Image = CType(resources.GetObject("mnuGrid.Image"), System.Drawing.Image)
        Me.mnuGrid.Text = "Grid"
        '
        'mnuLegends
        '
        Me.mnuLegends.Image = CType(resources.GetObject("mnuLegends.Image"), System.Drawing.Image)
        Me.mnuLegends.Text = "Legends"
        Me.mnuLegends.Visible = False
        '
        'mnuShowXYValues
        '
        Me.mnuShowXYValues.Enabled = False
        Me.mnuShowXYValues.Image = CType(resources.GetObject("mnuShowXYValues.Image"), System.Drawing.Image)
        Me.mnuShowXYValues.Text = "Show X,Y Values"
        Me.mnuShowXYValues.Visible = False
        '
        'mnuChangeScale
        '
        Me.mnuChangeScale.Image = CType(resources.GetObject("mnuChangeScale.Image"), System.Drawing.Image)
        Me.mnuChangeScale.Text = "Change Scale"
        '
        'CommandBarSeparatorItem1
        '
        Me.CommandBarSeparatorItem1.Visible = False
        '
        'mnuPrintGraph
        '
        Me.mnuPrintGraph.Image = CType(resources.GetObject("mnuPrintGraph.Image"), System.Drawing.Image)
        Me.mnuPrintGraph.Text = "&Print Graph"
        Me.mnuPrintGraph.Visible = False
        '
        'frmTimeScanDBMode
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(776, 537)
        Me.Controls.Add(Me.CustomPanelMain)
        Me.Controls.Add(Me.StatusBar1)
        Me.Controls.Add(Me.CommandBar1)
        Me.Controls.Add(Me.MenuBarEnergySpectrumMode)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimizeBox = False
        Me.Name = "frmTimeScanDBMode"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Time Scan Mode"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.CustomPanelMain.ResumeLayout(False)
        Me.CustomPanelBottom.ResumeLayout(False)
        Me.CustomPanelTop.ResumeLayout(False)
        CType(Me.StatusBarPanelInfo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProgressPanel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StatusBarPanelDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CommandBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MenuBarEnergySpectrumMode, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Form Events "

    Private Sub frmLoad()
        Try
            If gstructSettings.IsCustomerDisplayMode = True Then
                lblYValue_Ref.Visible = False
                lblYValue_Double.Visible = False
            Else
                If (Not gintInstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.SingleBeam) And _
                (gobjInst.Mode = EnumCalibrationMode.AA) Then
                Else
                    lblYValue_Ref.Visible = False
                    lblYValue_Double.Visible = False
                End If
            End If

            Application.DoEvents()

            Call funcInitialise()
            If blnActivateStartTimeScan = False Then
                ''Application.DoEvents()
                ''Call gobjCommProtocol.funcGetRefBaseVal()
                ''Call funcInitialise()
                ''funcOnSpect(False, lblTime, lblYValue)

                Call funcSetDefaultParameter()
                'Application.DoEvents()
                nudD2Cur.Visible = True
                nudPMT.Visible = True
                nudPMT_Ref.Visible = True
                nudSlit.Visible = True
                nudSlit_Exit.Visible = True
                nudHCLCur.Visible = True
                nudBurnerHeight.Visible = True
                nudFuelRatio.Visible = True
                blnActivateStartTimeScan = True
                'Application.DoEvents()
            End If
            'Application.DoEvents()
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If

            'If Not objWait Is Nothing Then
            '    objWait.Dispose()
            'End If
            'mblnAvoidProcessing = False

            '---------------------------------------------------------
        End Try
    End Sub


    Private Sub frmTimeScanMode_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim objWait As New CWaitCursor
        Try
            Application.DoEvents()
            btnReturn.Enabled = False
            btnAutoZero.BringToFront()
            cmdADJFlow.BringToFront()

            If mblnAvoidProcessing = True Then
                Exit Sub
            End If
            mblnAvoidProcessing = True
            ShowProgressBar(gstrTitleInstrumentType & ConstFormLoad)

            'If gstructSettings.IsCustomerDisplayMode = True Then
            '    lblYValue_Ref.Visible = False
            '    lblYValue_Double.Visible = False
            'Else
            '    If (Not gintInstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.SingleBeam) And _
            '    (gobjInst.Mode = EnumCalibrationMode.AA) Then
            '    Else
            '        lblYValue_Ref.Visible = False
            '        lblYValue_Double.Visible = False
            '    End If
            'End If

            'Application.DoEvents()

            'Call funcInitialise()
            'Application.DoEvents()


            Call gobjCommProtocol.funcGetRefBaseVal()
            funcOnSpect(False, lblTime, lblYValue)

            Call HideProgressBar()
            'Saurabh 10.07.07 To bring status form in front
            gobjfrmStatus.Show()
            'Saurabh

            Me.BringToFront()
            gobjclsTimer.subTimerStart(StatusBar1)
            btnAutoZero.Focus() '09.05.08
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            btnReturn.Enabled = True
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            'mblnAvoidProcessing = False
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub frmTimeScanMode_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Dim objWait As New CWaitCursor
        Try

            If mblnAvoidProcessing = True Then
                If Not (mobjController Is Nothing) Then
                    If mobjController.IsThreadRunning Then
                        Call subStopScan()
                        e.Cancel = True
                        Application.DoEvents()
                        Call mnuExit_Click(sender, e)
                        Exit Sub
                    End If
                End If
            Else
                If Not (mobjController Is Nothing) Then
                    If mobjController.IsThreadRunning Then
                        Call subStopScan()
                        mobjController.Cancel()
                    End If
                End If
            End If
            e.Cancel = False
            mblnExitApplication = False
            'If mblnIsfrmFlameStatusWork = True Then
            '    ''gobjMain.mobjController = New BgThread.clsBgThread(gobjMain)
            '    ''gobjclsBgFlameStatus = New clsBgFlameStatus
            '    If Not IsNothing(gobjMain) Then
            '        gobjMain.mobjController.Start(gobjclsBgFlameStatus)
            '    End If
            '    gobjfrmStatus.Visible = True
            'End If

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            objWait.Dispose()
            objWait = Nothing
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub mnuExit_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : mnuExit_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To close the Energy Spectrum Mode form
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 07.10.06
        ' Revisions             : Sachin Dokhale
        '=====================================================================
        Dim objWait As New CWaitCursor
        Try
            'If mblnAvoidProcessing = True Then
            '    Exit Sub
            'End If

            If mblnSpectrumStarted = True Then
                Call subStopScan()
                Application.DoEvents()
                'Call mnuExit_Click(sender, e)
                Exit Sub
            Else
                If Not (mobjController Is Nothing) Then
                    If mobjController.IsThreadRunning Then
                        Call subStopScan()
                        mobjController.Cancel()
                    End If
                End If
                'Exit Sub
            End If
            gobjclsTimer.subTimerStop()
            Application.DoEvents()
            Me.DialogResult = DialogResult.OK
            Me.Close()
            '''gobjMain.Visible = True '09.05.08
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            objWait.Dispose()
            mblnExitApplication = False
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub btnAutoZero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : btnStart_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale 
        ' Created               : 22.12.06
        ' Revisions             : 
        '=====================================================================

        Try
            If mblnAvoidFormProcessing = True Then
                Exit Sub
            End If
            mblnAvoidFormProcessing = True
            'If mblnSpectrumStarted = False Then
            mobjclsBgSpectrum.SpectrumWait = True
            Call subAutoZeroScan()
            mobjclsBgSpectrum.SpectrumWait = False
            'Else
            'Call subStopScan()
            'End If
            mblnAvoidFormProcessing = False

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
            mobjclsBgSpectrum.SpectrumWait = False
            mblnAvoidFormProcessing = False
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If

            btnAutoZero.Focus()
            Application.DoEvents()
            'mblnAvoidProcessing = False
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub btnLampParameters_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : btnLampParameters_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 07.10.06
        ' Revisions             : 
        '=====================================================================
        Try
            If mblnAvoidFormProcessing = True Then
                Exit Sub
            End If
            mblnAvoidFormProcessing = True

            mobjclsBgSpectrum.SpectrumWait = True
            Call subLampParameterChanged()
            mobjclsBgSpectrum.SpectrumWait = False
            mblnAvoidFormProcessing = False
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            mobjclsBgSpectrum.SpectrumWait = False
            mblnAvoidFormProcessing = False
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            btnLampParameters.Focus()
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub btnClearSpectrum_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : btnClearSpectrum_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 07.10.06
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Try
            If mblnAvoidFormProcessing = True Then
                Exit Sub
            End If
            mblnAvoidFormProcessing = True
            Call subClearScan()
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            mblnAvoidFormProcessing = False
            btnClearSpectrum.Focus()
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub cmbModes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : cmbModes_SelectedIndexChanged
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : 
        ' Description           : select index id for Calibration mode
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 21.11.06
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Try
            'If mblnAvoidProcessing = True Then
            '    Exit Sub
            'End If
            'mblnAvoidProcessing = True
            If mblnAvoidFormProcessing = True Then
                Exit Sub
            End If
            mblnAvoidFormProcessing = True
            gblnSpectrumWait = True
            mobjclsBgSpectrum.SpectrumWait = True
            Application.DoEvents()
            cmbModes.Enabled = False
            RemoveHandler cmbModes.SelectedIndexChanged, AddressOf cmbModes_SelectedIndexChanged
            If cmbModes.SelectedIndex > -1 Then
                'gobjInst.Mode = cmbModes.SelectedIndex
                'Call funcSetSpectrumParam(cmbModes.SelectedIndex)
                '//----- Use for Double Beam. It has not use other mode
                If gintInstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.DoubleBeam Then
                    Dim intSelectedModeType As Integer
                    '--commented and added following block of code by deepak on 20.07.07
                    'Select Case cmbModes.SelectedIndex
                    '    Case 0
                    '        intSelectedModeType = EnumCalibrationMode.AA
                    '    Case 1
                    '        intSelectedModeType = EnumCalibrationMode.AABGC
                    '    Case 2
                    '        intSelectedModeType = EnumCalibrationMode.SELFTEST
                    'End Select

                    Select Case cmbModes.SelectedIndex
                        Case 0
                            intSelectedModeType = EnumCalibrationMode.AA
                        Case 1
                            intSelectedModeType = EnumCalibrationMode.HCLE
                        Case 2
                            intSelectedModeType = EnumCalibrationMode.D2E
                        Case 3
                            intSelectedModeType = EnumCalibrationMode.EMISSION
                        Case 4
                            intSelectedModeType = EnumCalibrationMode.AABGC
                        Case 5
                            intSelectedModeType = EnumCalibrationMode.MABS
                        Case 6
                            intSelectedModeType = EnumCalibrationMode.SELFTEST
                        Case 7
                            intSelectedModeType = EnumCalibrationMode.AABGCSR
                    End Select

                    'Call funcSetSpectrumParameter(intSelectedModeType)
                    Call funcSetSpectrumParam(intSelectedModeType)
                Else
                    'Call funcSetSpectrumParameter(cmbModes.SelectedIndex)
                    Call funcSetSpectrumParam(cmbModes.SelectedIndex)
                End If
            End If
            AddHandler cmbModes.SelectedIndexChanged, AddressOf cmbModes_SelectedIndexChanged
            mobjclsBgSpectrum.SpectrumWait = False

            mblnAvoidFormProcessing = False
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            mobjclsBgSpectrum.SpectrumWait = False
            mblnAvoidFormProcessing = False
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            'mblnAvoidProcessing = False
            gblnSpectrumWait = False
            cmbModes.Enabled = True
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Sub

    'Private Sub cmbSpeed_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    '=====================================================================
    '    ' Procedure Name        : cmbSpeed_SelectedIndexChanged
    '    ' Parameters Passed     : Object,EventArgs
    '    ' Returns               : None
    '    ' Purpose               : 
    '    ' Description           : 
    '    ' Assumptions           : 
    '    ' Dependencies          : 
    '    ' Author                : Sachin Dokhale
    '    ' Created               : 12.12.06
    '    ' Revisions             : 
    '    '=====================================================================

    '    Dim objWait As New CWaitCursor
    '    Try
    '        If mblnAvoidProcessing = True Then
    '            Exit Sub
    '        End If

    '        mblnAvoidProcessing = True

    '        RemoveHandler cmbSpeed.SelectedIndexChanged, AddressOf cmbSpeed_SelectedIndexChanged

    '        If funcSetSpeed(cmbSpeed.SelectedIndex) = True Then
    '        End If
    '        AddHandler cmbSpeed.SelectedIndexChanged, AddressOf cmbSpeed_SelectedIndexChanged

    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        'Error Handling and logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = ex.Message
    '        gobjErrorHandler.WriteErrorLog(ex)
    '        '---------------------------------------------------------
    '    Finally
    '        '---------------------------------------------------------
    '        'Writing Execution log
    '        If CONST_CREATE_EXECUTION_LOG = 1 Then
    '            gobjErrorHandler.WriteExecutionLog()
    '        End If
    '        If Not objWait Is Nothing Then
    '            objWait.Dispose()
    '        End If
    '        mblnAvoidProcessing = False
    '        '---------------------------------------------------------
    '    End Try
    'End Sub

    Private Sub cmdChangeScale_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : cmdChangeScale_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : 
        ' Description           : select index id for Calibration mode
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 21.11.06
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Dim objfrmYChangeScale As frmYChangeScale
        Try

            'mobjclsBgSpectrum.SpectrumWait = True
            Application.DoEvents()

            objfrmYChangeScale = New frmYChangeScale(mobjParameters)
            objfrmYChangeScale.funcSetValidatingScale(gobjInst.Mode)
            If objfrmYChangeScale.ShowDialog() = DialogResult.OK Then
                mobjclsBgSpectrum.SpectrumWait = True
                If Not objfrmYChangeScale.SpectrumParameter Is Nothing Then
                    mobjParameters.YaxisMax = objfrmYChangeScale.SpectrumParameter.YaxisMax
                    mobjParameters.YaxisMin = objfrmYChangeScale.SpectrumParameter.YaxisMin
                    If Not funcGraphPreRequisite(mobjParameters.Cal_Mode, _
                                    mobjParameters.YaxisMin, _
                                    mobjParameters.YaxisMax) Then
                        'Call gFuncShowMessage("Error in setting spectrum parameters", "Please Check Entered Spectrum Parameters", modConstants.EnumMessageType.Information)
                        Exit Sub
                    End If
                End If
                AASGraphTimeScan.YAxisMin = mobjParameters.YaxisMin
                AASGraphTimeScan.YAxisMax = mobjParameters.YaxisMax
                gobjClsAAS203.Calculate_Analysis_Graph_Param(AASGraphTimeScan, ClsAAS203.enumChangeAxis.xyAxis)

                mobjclsBgSpectrum.SpectrumWait = False
            End If
            objfrmYChangeScale.Close()

            mobjclsBgSpectrum.SpectrumWait = False
            gblnSpectrumWait = False
            Application.DoEvents()
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            gblnSpectrumWait = False
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            If objfrmYChangeScale Is Nothing Then
                objfrmYChangeScale.Dispose()
                objfrmYChangeScale = Nothing
            End If
            Application.DoEvents()
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            cmdChangeScale.Focus()
            Application.DoEvents()
            'mblnAvoidProcessing = False
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub AASGraphTimeScan_GraphScaleChanged(ByVal XMin As Double, ByVal XMax As Double, ByVal YMin As Double, ByVal YMax As Double)
        '=====================================================================
        ' Procedure Name        :   AASGraphTimeScan_GraphScaleChanged
        ' Description           :   Get Graph Scale
        ' Purpose               :   
        ' Parameters Passed     :   
        ' Returns               :   
        ' Parameters Affected   :   
        ' Assumptions           :   
        ' Dependencies          :   None.
        ' Author                :   Sachin Dokhale
        ' Created               :   16.02.07
        ' Revisions             :
        '=====================================================================
        Try
            mobjParameters.YaxisMax = YMax  'objfrmYChangeScale.SpectrumParameter.YaxisMax
            mobjParameters.YaxisMin = YMin  'objfrmYChangeScale.SpectrumParameter.YaxisMin

            If Not funcGraphPreRequisite(mobjParameters.Cal_Mode, _
                                         mobjParameters.YaxisMin, _
                                         mobjParameters.YaxisMax) Then

                Exit Sub
            End If

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------
        End Try
    End Sub

#Region " Form Object "

    'Private Sub nudPMT_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    Private Sub nudPMT_ValueChanged(ByVal ChangePmt As Double)
        '=====================================================================
        ' Procedure Name        : cmbModes_SelectedIndexChanged
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : 
        ' Description           : select index id for Calibration mode
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 21.11.06
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Try
            'nudPMT.Enabled = False
            'If mblnAvoidProcessing = True Then
            '    Exit Sub
            'End If
            'mblnAvoidProcessing = True
            'RemoveHandler nudPMT.ValueEditorValueChanged, AddressOf nudPMT_ValueChanged
            If mblnAvoidFormProcessing = True Then
                Exit Sub
            End If
            mblnAvoidFormProcessing = True
            mobjclsBgSpectrum.SpectrumWait = True
            Application.DoEvents()
            Call funcSetPmtVParameter(nudPMT.Value)
            mblnAvoidFormProcessing = False
            mobjclsBgSpectrum.SpectrumWait = False
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            mblnAvoidFormProcessing = False
            mobjclsBgSpectrum.SpectrumWait = False
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If

            'nudPMT.Enabled = True
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            'AddHandler nudPMT.ValueEditorValueChanged, AddressOf nudPMT_ValueChanged
            'mblnAvoidProcessing = False
            Application.DoEvents()
        End Try
    End Sub

    Private Sub nudPMT_ValueEditorClick()
        '=====================================================================
        ' Procedure Name        : cmbModes_SelectedIndexChanged
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : 
        ' Description           : select index id for Calibration mode
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 21.11.06
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Try
            'nudPMT.Enabled = False
            'If mblnAvoidProcessing = True Then
            '    Exit Sub
            'End If
            'mblnAvoidProcessing = True

            RemoveHandler nudPMT.ValueEditorClick, AddressOf nudPMT_ValueEditorClick
            mobjclsBgSpectrum.SpectrumWait = True
            Application.DoEvents()
            Dim dblReturnValue As Double
            dblReturnValue = CInt(gobjInst.PmtVoltage)
            If funcSetFrmEditValue(dblReturnValue, "Set PMT (0 - 700)V", nudPMT.MinValue, nudPMT.MaxValue) = True Then
                nudPMT.Value = dblReturnValue
            End If
            '
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            AddHandler nudPMT.ValueEditorClick, AddressOf nudPMT_ValueEditorClick
            mobjclsBgSpectrum.SpectrumWait = False
            'nudPMT.Enabled = True
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            'mblnAvoidProcessing = False
            nudPMT.Focus()
            Application.DoEvents()
        End Try
    End Sub

    Private Sub nudPMT_Ref_ValueChanged(ByVal ChangePmt As Double)
        '=====================================================================
        ' Procedure Name        : cmbModes_SelectedIndexChanged
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : 
        ' Description           : select index id for Calibration mode
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 21.11.06
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Try
            If mblnAvoidFormProcessing = True Then
                Exit Sub
            End If
            mblnAvoidFormProcessing = True

            'nudPMT_Ref.Enabled = False
            'If mblnAvoidProcessing = True Then
            '    Exit Sub
            'End If
            'mblnAvoidProcessing = True
            'RemoveHandler nudPMT_Ref.ValueEditorValueChanged, AddressOf nudPMT_Ref_ValueChanged
            'RemoveHandler cmdbtnAutoZero.Click, AddressOf btnAutoZero_Click
            'RemoveHandler cmdbtnAdjBurnerHt.Click, AddressOf cmdADJBH_Click
            'RemoveHandler cmdbtnAdjFuelFlow.Click, AddressOf cmdADJFlow_Click
            mobjclsBgSpectrum.SpectrumWait = True
            Application.DoEvents()
            Call funcSetPmtVParameter_Ref(nudPMT_Ref.Value)
            mblnAvoidFormProcessing = False
            mobjclsBgSpectrum.SpectrumWait = False
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            mblnAvoidFormProcessing = False
            mobjclsBgSpectrum.SpectrumWait = False
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If

            'nudPMT_Ref.Enabled = True
            'AddHandler cmdbtnAutoZero.Click, AddressOf btnAutoZero_Click
            'AddHandler cmdbtnAdjBurnerHt.Click, AddressOf cmdADJBH_Click
            'AddHandler cmdbtnAdjFuelFlow.Click, AddressOf cmdADJFlow_Click
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            'mblnAvoidProcessing = False
            'AddHandler nudPMT_Ref.ValueEditorValueChanged, AddressOf nudPMT_Ref_ValueChanged
            Application.DoEvents()
        End Try
    End Sub

    Private Sub nudPMT_Ref_ValueEditorClick()
        '=====================================================================
        ' Procedure Name        : cmbModes_SelectedIndexChanged
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : 
        ' Description           : select index id for Calibration mode
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 21.11.06
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Try
            'nudPMT_Ref.Enabled = False
            'If mblnAvoidProcessing = True Then
            '    Exit Sub
            'End If
            'mblnAvoidProcessing = True

            RemoveHandler nudPMT_Ref.ValueEditorClick, AddressOf nudPMT_Ref_ValueEditorClick
            'RemoveHandler cmdbtnAutoZero.Click, AddressOf btnAutoZero_Click
            'RemoveHandler cmdbtnAdjBurnerHt.Click, AddressOf cmdADJBH_Click
            'RemoveHandler cmdbtnAdjFuelFlow.Click, AddressOf cmdADJFlow_Click

            mobjclsBgSpectrum.SpectrumWait = True
            Application.DoEvents()
            Dim dblReturnValue As Double
            dblReturnValue = CInt(gobjInst.PmtVoltageReference)
            If funcSetFrmEditValue(dblReturnValue, "Set Ref_PMT (0 - 700)V", nudPMT_Ref.MinValue, nudPMT_Ref.MaxValue) = True Then
                nudPMT_Ref.Value = dblReturnValue
            End If
            '
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            AddHandler nudPMT_Ref.ValueEditorClick, AddressOf nudPMT_Ref_ValueEditorClick
            'AddHandler cmdbtnAutoZero.Click, AddressOf btnAutoZero_Click
            'AddHandler cmdbtnAdjBurnerHt.Click, AddressOf cmdADJBH_Click
            'AddHandler cmdbtnAdjFuelFlow.Click, AddressOf cmdADJFlow_Click
            mobjclsBgSpectrum.SpectrumWait = False
            'nudPMT_Ref.Enabled = True
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            'mblnAvoidProcessing = False
            nudPMT_Ref.Focus()
            Application.DoEvents()
        End Try
    End Sub

    'Private Sub nudSlit_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    '=====================================================================
    '    ' Procedure Name        : cmbModes_SelectedIndexChanged
    '    ' Parameters Passed     : Object,EventArgs
    '    ' Returns               : None
    '    ' Purpose               : 
    '    ' Description           : select index id for Calibration mode
    '    ' Assumptions           : 
    '    ' Dependencies          : 
    '    ' Author                : Sachin Dokhale
    '    ' Created               : 21.11.06
    '    ' Revisions             : 
    '    '=====================================================================
    '    Dim objWait As New CWaitCursor
    '    Try
    '        nudSlit.Enabled = False
    '        mobjclsBgSpectrum.SpectrumWait = True
    '        Application.DoEvents()
    '        Call funcSetSlit_WidthParameter(nudSlit.Value)
    '        mobjclsBgSpectrum.SpectrumWait = False
    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        'Error Handling and logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = ex.Message
    '        gobjErrorHandler.WriteErrorLog(ex)
    '        '---------------------------------------------------------
    '    Finally
    '        '---------------------------------------------------------
    '        'Writing Execution log
    '        If CONST_CREATE_EXECUTION_LOG = 1 Then
    '            gobjErrorHandler.WriteExecutionLog()
    '        End If
    '        gblnSpectrumWait = False
    '        nudSlit.Enabled = True
    '        If Not objWait Is Nothing Then
    '            objWait.Dispose()
    '        End If
    '        Application.DoEvents()
    '    End Try
    'End Sub

    Private Sub nudSlit_ValueChanged(ByVal ChangeSlit As Double)
        '=====================================================================
        ' Procedure Name        : cmbModes_SelectedIndexChanged
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : 
        ' Description           : select index id for Calibration mode
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 21.11.06
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Try
            'RemoveHandler nudSlit.ValueEditorValueChanged, AddressOf nudSlit_ValueChanged
            'RemoveHandler cmdbtnAutoZero.Click, AddressOf btnAutoZero_Click
            'RemoveHandler cmdbtnAdjBurnerHt.Click, AddressOf cmdADJBH_Click
            'RemoveHandler cmdbtnAdjFuelFlow.Click, AddressOf cmdADJFlow_Click

            'RemoveHandler nudBurnerHeight.ValueEditorClick, AddressOf nudBurnerHeight_ValueEditorClick
            'RemoveHandler nudSlit_Exit.ValueEditorClick, AddressOf nudSlit_Exit_ValueEditorClick
            'RemoveHandler nudFuelRatio.ValueEditorClick, AddressOf nudFuelRatio_ValueEditorClick
            'RemoveHandler nudBurnerHeight.ValueEditorValueChanged, AddressOf nudBurnerHeight_ValueChanged
            'RemoveHandler nudSlit_Exit.ValueEditorValueChanged, AddressOf nudSlit_Exit_ValueChanged
            'RemoveHandler nudFuelRatio.ValueEditorValueChanged, AddressOf nudFuelRatio_ValueChanged

            'nudSlit.Enabled = False
            'If mblnAvoidProcessing = True Then
            '    Exit Sub
            'End If
            'mblnAvoidProcessing = True
            If mblnAvoidFormProcessing = True Then
                Exit Sub
            End If
            mblnAvoidFormProcessing = True
            mobjclsBgSpectrum.SpectrumWait = True
            Application.DoEvents()
            Call funcSetSlit_WidthParameter(nudSlit.Value)
            mblnAvoidFormProcessing = False
            gblnSpectrumWait = False
            mobjclsBgSpectrum.SpectrumWait = False
            'by pankaj on 18.1.08
            nudSlit_Exit.Value = CDbl(gobjClsAAS203.funcGet_SlitWidth) 'CDbl(nudSlit.Value)  'by pankaj on 18.1.08
            RemoveHandler nudSlit.ValueEditorValueChanged, AddressOf nudSlit_ValueChanged 'by pankaj on 18.1.08
            nudSlit.Value = CDbl(gobjClsAAS203.funcGet_SlitWidth)  'CDbl(nudSlit.Value)  'by pankaj on 18.1.08
            AddHandler nudSlit.ValueEditorValueChanged, AddressOf nudSlit_ValueChanged 'by pankaj on 18.1.08
            nudSlit_Exit.Enabled = False 'by pankaj on 18.1.08
            '-----

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            mblnAvoidFormProcessing = False
            gblnSpectrumWait = False
            mobjclsBgSpectrum.SpectrumWait = True
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If


            'mobjclsBgSpectrum.SpectrumWait = False
            'AddHandler nudSlit.ValueEditorValueChanged, AddressOf nudSlit_ValueChanged
            'AddHandler cmdbtnAutoZero.Click, AddressOf btnAutoZero_Click
            'AddHandler cmdbtnAdjBurnerHt.Click, AddressOf cmdADJBH_Click
            'AddHandler cmdbtnAdjFuelFlow.Click, AddressOf cmdADJFlow_Click
            'AddHandler nudBurnerHeight.ValueEditorClick, AddressOf nudBurnerHeight_ValueEditorClick
            'AddHandler nudSlit_Exit.ValueEditorClick, AddressOf nudSlit_Exit_ValueEditorClick
            'AddHandler nudFuelRatio.ValueEditorClick, AddressOf nudFuelRatio_ValueEditorClick
            'AddHandler nudBurnerHeight.ValueEditorValueChanged, AddressOf nudBurnerHeight_ValueChanged
            'AddHandler nudSlit_Exit.ValueEditorValueChanged, AddressOf nudSlit_Exit_ValueChanged
            'AddHandler nudFuelRatio.ValueEditorValueChanged, AddressOf nudFuelRatio_ValueChanged

            'nudSlit.Enabled = True
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            'mblnAvoidProcessing = False
            Application.DoEvents()
        End Try
    End Sub

    Private Sub nudSlit_ValueEditorClick()
        '=====================================================================
        ' Procedure Name        : cmbModes_SelectedIndexChanged
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : 
        ' Description           : select index id for Calibration mode
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 21.11.06
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Dim dblReturnValue As Double
        Try
            'nudSlit.Enabled = False
            RemoveHandler nudSlit.ValueEditorClick, AddressOf nudSlit_ValueEditorClick
            'RemoveHandler cmdbtnAutoZero.Click, AddressOf btnAutoZero_Click
            'RemoveHandler cmdbtnAdjBurnerHt.Click, AddressOf cmdADJBH_Click
            'RemoveHandler cmdbtnAdjFuelFlow.Click, AddressOf cmdADJFlow_Click

            'RemoveHandler nudBurnerHeight.ValueEditorClick, AddressOf nudBurnerHeight_ValueEditorClick
            'RemoveHandler nudSlit_Exit.ValueEditorClick, AddressOf nudSlit_Exit_ValueEditorClick
            'RemoveHandler nudFuelRatio.ValueEditorClick, AddressOf nudFuelRatio_ValueEditorClick
            'RemoveHandler nudBurnerHeight.ValueEditorValueChanged, AddressOf nudBurnerHeight_ValueChanged
            'RemoveHandler nudSlit_Exit.ValueEditorValueChanged, AddressOf nudSlit_Exit_ValueChanged
            'RemoveHandler nudFuelRatio.ValueEditorValueChanged, AddressOf nudFuelRatio_ValueChanged

            'If mblnAvoidProcessing = True Then
            '    Exit Sub
            'End If
            'mblnAvoidProcessing = True

            mobjclsBgSpectrum.SpectrumWait = True
            Application.DoEvents()

            dblReturnValue = gobjClsAAS203.funcGet_SlitWidth

            If funcSetFrmEditValue(dblReturnValue, "Set Entrance Slit Width (0.0 - 2.0)nm", nudSlit.MinValue, nudSlit.MaxValue) = True Then
                nudSlit.Value = dblReturnValue
            End If
            '
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            mobjclsBgSpectrum.SpectrumWait = False
            'nudSlit.Enabled = True
            AddHandler nudSlit.ValueEditorClick, AddressOf nudSlit_ValueEditorClick
            'AddHandler cmdbtnAutoZero.Click, AddressOf btnAutoZero_Click
            'AddHandler cmdbtnAdjBurnerHt.Click, AddressOf cmdADJBH_Click
            'AddHandler cmdbtnAdjFuelFlow.Click, AddressOf cmdADJFlow_Click

            'AddHandler nudBurnerHeight.ValueEditorClick, AddressOf nudBurnerHeight_ValueEditorClick
            'AddHandler nudSlit_Exit.ValueEditorClick, AddressOf nudSlit_Exit_ValueEditorClick
            'AddHandler nudFuelRatio.ValueEditorClick, AddressOf nudFuelRatio_ValueEditorClick
            'AddHandler nudBurnerHeight.ValueEditorValueChanged, AddressOf nudBurnerHeight_ValueChanged
            'AddHandler nudSlit_Exit.ValueEditorValueChanged, AddressOf nudSlit_Exit_ValueChanged
            'AddHandler nudFuelRatio.ValueEditorValueChanged, AddressOf nudFuelRatio_ValueChanged
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            'mblnAvoidProcessing = False
            nudSlit.Focus()
            Application.DoEvents()
        End Try
    End Sub

    Private Sub nudSlit_Exit_ValueChanged(ByVal ChangeSlit As Double)
        '=====================================================================
        ' Procedure Name        : cmbModes_SelectedIndexChanged
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : 
        ' Description           : select index id for Calibration mode
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 21.11.06
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Try
            If mblnAvoidFormProcessing = True Then
                Exit Sub
            End If
            mblnAvoidFormProcessing = True

            'nudSlit_Exit.Enabled = False
            mobjclsBgSpectrum.SpectrumWait = True
            Application.DoEvents()
            Call funcSetSlit_WidthParameter_Exit(nudSlit_Exit.Value)
            mblnAvoidFormProcessing = False
            gblnSpectrumWait = False
            mobjclsBgSpectrum.SpectrumWait = False
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            mblnAvoidFormProcessing = False
            gblnSpectrumWait = False
            mobjclsBgSpectrum.SpectrumWait = False
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If

            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            'mblnAvoidProcessing = False
            Application.DoEvents()
        End Try
    End Sub

    Private Sub nudSlit_Exit_ValueEditorClick()
        '=====================================================================
        ' Procedure Name        : cmbModes_SelectedIndexChanged
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : 
        ' Description           : select index id for Calibration mode
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 21.11.06
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Dim dblReturnValue As Double
        Try
            RemoveHandler nudSlit_Exit.ValueEditorClick, AddressOf nudSlit_Exit_ValueEditorClick

            mobjclsBgSpectrum.SpectrumWait = True
            Application.DoEvents()
            dblReturnValue = gobjClsAAS203.funcGet_SlitWidth(1)
            If funcSetFrmEditValue(dblReturnValue, "Set Exit Slit Width (0.0 - 2.0)nm", nudSlit_Exit.MinValue, nudSlit_Exit.MaxValue) = True Then
                nudSlit_Exit.Value = dblReturnValue
            End If
            '
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            mobjclsBgSpectrum.SpectrumWait = False
            'nudSlit_Exit.Enabled = True
            AddHandler nudSlit_Exit.ValueEditorClick, AddressOf nudSlit_Exit_ValueEditorClick
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            nudSlit_Exit.Focus()
            Application.DoEvents()
        End Try
    End Sub

    'Private Sub nudHCLCur_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    '=====================================================================
    '    ' Procedure Name        : cmbModes_SelectedIndexChanged
    '    ' Parameters Passed     : Object,EventArgs
    '    ' Returns               : None
    '    ' Purpose               : 
    '    ' Description           : select index id for Calibration mode
    '    ' Assumptions           : 
    '    ' Dependencies          : 
    '    ' Author                : Sachin Dokhale
    '    ' Created               : 21.11.06
    '    ' Revisions             : 
    '    '=====================================================================
    '    Dim objWait As New CWaitCursor
    '    Try
    '        nudHCLCur.Enabled = False
    '        mobjclsBgSpectrum.SpectrumWait = True
    '        Call funcSetHCL_CurParameter(nudHCLCur.Value)

    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        'Error Handling and logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = ex.Message
    '        gobjErrorHandler.WriteErrorLog(ex)
    '        '---------------------------------------------------------
    '    Finally
    '        '---------------------------------------------------------
    '        'Writing Execution log
    '        If CONST_CREATE_EXECUTION_LOG = 1 Then
    '            gobjErrorHandler.WriteExecutionLog()
    '        End If
    '        gblnSpectrumWait = False
    '        mobjclsBgSpectrum.SpectrumWait = False
    '        nudHCLCur.Enabled = True
    '        If Not objWait Is Nothing Then
    '            objWait.Dispose()
    '        End If
    '        Application.DoEvents()
    '    End Try
    'End Sub

    Private Sub nudHCLCur_ValueChanged(ByVal ChangeHCLCur As Double)
        '=====================================================================
        ' Procedure Name        : cmbModes_SelectedIndexChanged
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : 
        ' Description           : select index id for Calibration mode
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 21.11.06
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Try
            'RemoveHandler nudHCLCur.ValueEditorValueChanged, AddressOf nudHCLCur_ValueChanged
            'nudHCLCur.Enabled = False
            'If mblnAvoidProcessing = True Then
            '    Exit Sub
            'End If
            'mblnAvoidProcessing = True
            If mblnAvoidFormProcessing = True Then
                Exit Sub
            End If
            If ReInitLampInstParameters = True Then
                Exit Sub
            End If
            mblnAvoidFormProcessing = True

            mobjclsBgSpectrum.SpectrumWait = True
            Call funcSetHCL_CurParameter(nudHCLCur.Value)
            mblnAvoidFormProcessing = False
            mobjclsBgSpectrum.SpectrumWait = False
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            mblnAvoidFormProcessing = False
            mobjclsBgSpectrum.SpectrumWait = False
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            'gblnSpectrumWait = False
            'mobjclsBgSpectrum.SpectrumWait = False
            'nudHCLCur.Enabled = True
            'AddHandler nudHCLCur.ValueEditorValueChanged, AddressOf nudHCLCur_ValueChanged
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            'mblnAvoidProcessing = False
            Application.DoEvents()
        End Try
    End Sub

    Private Sub nudHCLCur_ValueEditorClick()
        '=====================================================================
        ' Procedure Name        : cmbModes_SelectedIndexChanged
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : 
        ' Description           : select index id for Calibration mode
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 21.11.06
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Dim dblReturnValue As Double
        Try
            'If mblnAvoidProcessing = True Then
            '    Exit Sub
            'End If
            'mblnAvoidProcessing = True
            'nudHCLCur.Enabled = False
            RemoveHandler nudHCLCur.ValueEditorClick, AddressOf nudHCLCur_ValueEditorClick
            If ReInitLampInstParameters = True Then
                Exit Sub
            End If
            mobjclsBgSpectrum.SpectrumWait = True
            Application.DoEvents()
            dblReturnValue = gobjInst.Current
            If funcSetFrmEditValue(dblReturnValue, "Set HCL Current (0 - 25)mA", nudHCLCur.MinValue, nudHCLCur.MaxValue) = True Then
                nudHCLCur.Value = dblReturnValue
            End If
            '
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            mobjclsBgSpectrum.SpectrumWait = False
            'nudHCLCur.Enabled = True
            AddHandler nudHCLCur.ValueEditorClick, AddressOf nudHCLCur_ValueEditorClick
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            nudHCLCur.Focus()
            Application.DoEvents()
        End Try
    End Sub

    'Private Sub nudD2Cur_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    '=====================================================================
    '    ' Procedure Name        : cmbModes_SelectedIndexChanged
    '    ' Parameters Passed     : Object,EventArgs
    '    ' Returns               : None
    '    ' Purpose               : 
    '    ' Description           : select index id for Calibration mode
    '    ' Assumptions           : 
    '    ' Dependencies          : 
    '    ' Author                : Sachin Dokhale
    '    ' Created               : 21.11.06
    '    ' Revisions             : 
    '    '=====================================================================
    '    Dim objWait As New CWaitCursor
    '    Try
    '        nudD2Cur.Enabled = False
    '        mobjclsBgSpectrum.SpectrumWait = True
    '        Call funcSetD2_CurParameter(nudD2Cur.Value)

    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        'Error Handling and logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = ex.Message
    '        gobjErrorHandler.WriteErrorLog(ex)
    '        '---------------------------------------------------------
    '    Finally
    '        '---------------------------------------------------------
    '        'Writing Execution log
    '        If CONST_CREATE_EXECUTION_LOG = 1 Then
    '            gobjErrorHandler.WriteExecutionLog()
    '        End If
    '        gblnSpectrumWait = False
    '        mobjclsBgSpectrum.SpectrumWait = False
    '        nudD2Cur.Enabled = True
    '        If Not objWait Is Nothing Then
    '            objWait.Dispose()
    '        End If
    '        Application.DoEvents()
    '    End Try
    'End Sub

    Private Sub nudD2Cur_ValueChanged(ByVal ChangeD2Cur As Double)
        '=====================================================================
        ' Procedure Name        : cmbModes_SelectedIndexChanged
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : 
        ' Description           : select index id for Calibration mode
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 21.11.06
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Try
            'If mblnAvoidProcessing = True Then
            '    Exit Sub
            'End If
            'mblnAvoidProcessing = True
            'RemoveHandler nudD2Cur.ValueEditorValueChanged, AddressOf nudD2Cur_ValueChanged
            'nudD2Cur.Enabled = False

            ''If mblnAvoidFormProcessing = True Then
            ''    Exit Sub
            ''End If
            If ReInitLampInstParameters = True Then
                Exit Sub
            End If
            mblnAvoidFormProcessing = True
            mobjclsBgSpectrum.SpectrumWait = True
            Call funcSetD2_CurParameter(nudD2Cur.Value)
            If nudD2Cur.Value = 100.0 Then
                nudD2Cur.Text = "D2 Off"
            End If
            gblnSpectrumWait = False
            mblnAvoidFormProcessing = False
            mobjclsBgSpectrum.SpectrumWait = False
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
            gblnSpectrumWait = False
            mblnAvoidFormProcessing = False
            mobjclsBgSpectrum.SpectrumWait = False
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If

            'nudD2Cur.Enabled = True
            'AddHandler nudD2Cur.ValueEditorValueChanged, AddressOf nudD2Cur_ValueChanged
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            'mblnAvoidProcessing = False
            Application.DoEvents()
        End Try
    End Sub

    Private Sub nudD2Cur_ValueEditorClick()
        '=====================================================================
        ' Procedure Name        : cmbModes_SelectedIndexChanged
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : 
        ' Description           : select index id for Calibration mode
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 21.11.06
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Dim dblReturnValue As Double
        Try
            'If mblnAvoidProcessing = True Then
            '    Exit Sub
            'End If
            'mblnAvoidProcessing = True
            'nudD2Cur.Enabled = False
            RemoveHandler nudD2Cur.ValueEditorClick, AddressOf nudD2Cur_ValueEditorClick
            If mblnAvoidFormProcessing = True Then
                Exit Sub
            End If
            If ReInitLampInstParameters = True Then
                Exit Sub
            End If
            mblnAvoidFormProcessing = True
            mobjclsBgSpectrum.SpectrumWait = True
            Application.DoEvents()
            dblReturnValue = gobjInst.D2Current
            If funcSetFrmEditValue(dblReturnValue, "Set D2 Current (100 - 300)mA", nudD2Cur.MinValue, nudD2Cur.MaxValue) = True Then
                nudD2Cur.Value = dblReturnValue
            End If
            '
            mblnAvoidFormProcessing = False
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            mobjclsBgSpectrum.SpectrumWait = False
            'nudD2Cur.Enabled = True
            AddHandler nudD2Cur.ValueEditorClick, AddressOf nudD2Cur_ValueEditorClick
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            'mblnAvoidProcessing = False
            nudD2Cur.Focus()
            Application.DoEvents()
        End Try
    End Sub

    'Private Sub nudFuelRatio_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    '=====================================================================
    '    ' Procedure Name        : cmbModes_SelectedIndexChanged
    '    ' Parameters Passed     : Object,EventArgs
    '    ' Returns               : None
    '    ' Purpose               : 
    '    ' Description           : select index id for Calibration mode
    '    ' Assumptions           : 
    '    ' Dependencies          : 
    '    ' Author                : Sachin Dokhale
    '    ' Created               : 21.11.06
    '    ' Revisions             : 
    '    '=====================================================================
    '    Dim objWait As New CWaitCursor

    '    Try
    '        'If Not (dblFuelRatio = CDbl(nudFuelRatio.Value)) Then
    '        '    If dblFuelRatio > nudFuelRatio.Value Then

    '        '        dblFuelRatio = funcSetFuelParameter(-1)
    '        '        dblFuelRatio = Format(dblFuelRatio, "#.00")
    '        '        nudFuelRatio.Value = Format(dblFuelRatio, "#.00")
    '        '    ElseIf dblFuelRatio < nudFuelRatio.Value Then
    '        '        dblFuelRatio = funcSetFuelParameter(1)
    '        '        dblFuelRatio = Format(dblFuelRatio, "#.00")
    '        '        nudFuelRatio.Value = Format(dblFuelRatio, "#.00")
    '        '    End If
    '        'End If 

    '        'nudFuelRatio.Text = funcSetFuelParameter(CDbl(nudFuelRatio.Value))
    '        nudFuelRatio.Enabled = False
    '        mobjclsBgSpectrum.SpectrumWait = True
    '        Application.DoEvents()
    '        RemoveHandler nudFuelRatio.ValueChanged, AddressOf nudBurnerHeight_ValueChanged
    '        If Not (CDbl(nudFuelRatio.Value) = mdblFuelRatio) Then
    '            Call gobjClsAAS203.funcSetFuel(CDbl(nudFuelRatio.Value))
    '            mdblFuelRatio = gobjClsAAS203.funcGet_Fuel_Ratio(True)
    '        Else
    '            mdblFuelRatio = gobjClsAAS203.funcGet_Fuel_Ratio(True)
    '        End If
    '        mobjParameters.FualRatio = Val(mdblFuelRatio)
    '        nudFuelRatio.Text = mdblFuelRatio
    '        nudFuelRatio.Refresh()
    '        AddHandler nudFuelRatio.ValueChanged, AddressOf nudBurnerHeight_ValueChanged


    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        'Error Handling and logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = ex.Message
    '        gobjErrorHandler.WriteErrorLog(ex)
    '        '---------------------------------------------------------
    '    Finally
    '        '---------------------------------------------------------
    '        'Writing Execution log
    '        If CONST_CREATE_EXECUTION_LOG = 1 Then
    '            gobjErrorHandler.WriteExecutionLog()
    '        End If
    '        '---------------------------------------------------------
    '        gblnSpectrumWait = False
    '        mobjclsBgSpectrum.SpectrumWait = False
    '        nudFuelRatio.Enabled = True
    '        If Not objWait Is Nothing Then
    '            objWait.Dispose()
    '        End If
    '        Application.DoEvents()
    '    End Try
    'End Sub

    Private Sub nudFuelRatio_ValueChanged(ByVal ChangeFuelRatio As Double)
        '=====================================================================
        ' Procedure Name        : cmbModes_SelectedIndexChanged
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : 
        ' Description           : select index id for Calibration mode
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 21.11.06
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor

        Try
            If mblnAvoidFormProcessing = True Then
                Exit Sub
            End If
            mblnAvoidFormProcessing = True
            mobjclsBgSpectrum.SpectrumWait = True
            Application.DoEvents()
            
            gobjCommProtocol.mobjCommdll.subTime_Delay(50)
            Application.DoEvents()
            '---above code is commented and called following 
            '---function to set fuel according to value editor 
            '---button clicked
            FuncIncrDecrFuel(CDbl(nudFuelRatio.Value))

            mobjParameters.FualRatio = mdblFuelRatio
            nudFuelRatio.Refresh()
            gblnSpectrumWait = False
            mblnAvoidFormProcessing = False
            mobjclsBgSpectrum.SpectrumWait = False
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            gblnSpectrumWait = False
            mblnAvoidFormProcessing = False
            mobjclsBgSpectrum.SpectrumWait = False
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            Application.DoEvents()
        End Try
    End Sub

    Private Sub nudFuelRatio_ValueEditorClick()
        '=====================================================================
        ' Procedure Name        : cmbModes_SelectedIndexChanged
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : 
        ' Description           : select index id for Calibration mode
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 21.11.06
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Dim dblReturnValue As Double
        Try
            RemoveHandler nudFuelRatio.ValueEditorClick, AddressOf nudFuelRatio_ValueEditorClick

            mobjclsBgSpectrum.SpectrumWait = True
            Application.DoEvents()

            dblReturnValue = nudFuelRatio.Value   'gobjClsAAS203.funcGet_Fuel_Ratio(True)

            If dblReturnValue < 0.0 Then
                ''setting some validation
                dblReturnValue = 0.0
            End If
            If funcSetFrmEditValue(dblReturnValue, "Set Fuel Ratio (0 - 7.66)", nudFuelRatio.MinValue, nudFuelRatio.MaxValue) = True Then
                nudFuelRatio.Value = dblReturnValue
            End If
            '
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            mobjclsBgSpectrum.SpectrumWait = False
            'nudFuelRatio.Enabled = True
            AddHandler nudFuelRatio.ValueEditorClick, AddressOf nudFuelRatio_ValueEditorClick
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            'AddHandler cmdbtnAutoZero.Click, AddressOf btnAutoZero_Click
            'AddHandler cmdbtnAdjBurnerHt.Click, AddressOf cmdADJBH_Click
            'AddHandler cmdbtnAdjFuelFlow.Click, AddressOf cmdADJFlow_Click
            'AddHandler nudBurnerHeight.ValueEditorClick, AddressOf nudBurnerHeight_ValueEditorClick
            'AddHandler nudSlit.ValueEditorClick, AddressOf nudSlit_ValueEditorClick
            'AddHandler nudSlit_Exit.ValueEditorClick, AddressOf nudSlit_Exit_ValueEditorClick
            'AddHandler nudBurnerHeight.ValueEditorValueChanged, AddressOf nudBurnerHeight_ValueChanged
            'AddHandler nudSlit.ValueEditorValueChanged, AddressOf nudSlit_ValueChanged
            'AddHandler nudSlit_Exit.ValueEditorValueChanged, AddressOf nudSlit_Exit_ValueChanged
            'mblnAvoidProcessing = False
            nudFuelRatio.Focus()
            Application.DoEvents()
        End Try
    End Sub

    'Private Sub nudBurnerHeight_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    '=====================================================================
    '    ' Procedure Name        : cmbModes_SelectedIndexChanged
    '    ' Parameters Passed     : Object,EventArgs
    '    ' Returns               : None
    '    ' Purpose               : 
    '    ' Description           : select index id for Calibration mode
    '    ' Assumptions           : 
    '    ' Dependencies          : 
    '    ' Author                : Sachin Dokhale
    '    ' Created               : 21.11.06
    '    ' Revisions             : 
    '    '=====================================================================
    '    Dim objWait As New CWaitCursor
    '    Try
    '        nudBurnerHeight.Enabled = False
    '        mobjclsBgSpectrum.SpectrumWait = True
    '        Application.DoEvents()
    '        If Not (mdblBhHeight = CDbl(nudBurnerHeight.Value)) Then
    '            nudBurnerHeight.Text = funcSetBurner_HeightParameter(CDbl(nudBurnerHeight.Value))
    '        End If

    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        'Error Handling and logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = ex.Message
    '        gobjErrorHandler.WriteErrorLog(ex)
    '        '---------------------------------------------------------
    '    Finally
    '        '---------------------------------------------------------
    '        'Writing Execution log
    '        If CONST_CREATE_EXECUTION_LOG = 1 Then
    '            gobjErrorHandler.WriteExecutionLog()
    '        End If
    '        '---------------------------------------------------------
    '        gblnSpectrumWait = False
    '        mobjclsBgSpectrum.SpectrumWait = False
    '        nudBurnerHeight.Enabled = True
    '        If Not objWait Is Nothing Then
    '            objWait.Dispose()
    '        End If
    '        Application.DoEvents()
    '    End Try
    'End Sub

    'Private Sub AASEnergySpectrum_OnAxisChange() Handles AASGraphTimeScan.OnAxisChange
    '    MsgBox(" Axis is Changed ")
    'End Sub

    Private Sub nudBurnerHeight_ValueChanged(ByVal ChangeFuelRatio As Double)
        '=====================================================================
        ' Procedure Name        : cmbModes_SelectedIndexChanged
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : 
        ' Description           : select index id for Calibration mode
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 21.11.06
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Try
            If mblnAvoidFormProcessing = True Then
                Exit Sub
            End If
            mblnAvoidFormProcessing = True

            'DisableButtonsForBurnerHeight()
            'RemoveHandler nudBurnerHeight.ValueEditorValueChanged, AddressOf nudBurnerHeight_ValueChanged
            'RemoveHandler cmdbtnAutoZero.Click, AddressOf btnAutoZero_Click
            'RemoveHandler cmdbtnAdjBurnerHt.Click, AddressOf cmdADJBH_Click
            'RemoveHandler cmdbtnAdjFuelFlow.Click, AddressOf cmdADJFlow_Click
            'RemoveHandler nudFuelRatio.ValueEditorClick, AddressOf nudFuelRatio_ValueEditorClick
            'RemoveHandler nudSlit.ValueEditorClick, AddressOf nudSlit_ValueEditorClick
            'RemoveHandler nudSlit_Exit.ValueEditorClick, AddressOf nudSlit_Exit_ValueEditorClick
            'RemoveHandler nudFuelRatio.ValueEditorValueChanged, AddressOf nudFuelRatio_ValueChanged
            'RemoveHandler nudSlit.ValueEditorValueChanged, AddressOf nudSlit_ValueChanged
            'RemoveHandler nudSlit_Exit.ValueEditorValueChanged, AddressOf nudSlit_Exit_ValueChanged
            'nudBurnerHeight.Enabled = False

            'If mblnAvoidProcessing = True Then
            '    Exit Sub
            'End If
            'mblnAvoidProcessing = True

            mobjclsBgSpectrum.SpectrumWait = True
            Application.DoEvents()

            If Not (mdblBhHeight = CDbl(nudBurnerHeight.Value)) Then
                nudBurnerHeight.Value = funcSetBurner_HeightParameter(CDbl(nudBurnerHeight.Value))
            End If
            mblnAvoidFormProcessing = False
            gblnSpectrumWait = False
            mobjclsBgSpectrum.SpectrumWait = False
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            mblnAvoidFormProcessing = False
            gblnSpectrumWait = False
            mobjclsBgSpectrum.SpectrumWait = False
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------
            'gblnSpectrumWait = False
            'mobjclsBgSpectrum.SpectrumWait = False
            'nudBurnerHeight.Enabled = True
            'AddHandler nudBurnerHeight.ValueEditorValueChanged, AddressOf nudBurnerHeight_ValueChanged
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            'mblnAvoidProcessing = False
            'EnableButtonsForBurnerHeight()
            'AddHandler cmdbtnAutoZero.Click, AddressOf btnAutoZero_Click
            'AddHandler cmdbtnAdjBurnerHt.Click, AddressOf cmdADJBH_Click
            'AddHandler cmdbtnAdjFuelFlow.Click, AddressOf cmdADJFlow_Click
            'AddHandler nudFuelRatio.ValueEditorClick, AddressOf nudFuelRatio_ValueEditorClick
            'AddHandler nudSlit.ValueEditorClick, AddressOf nudSlit_ValueEditorClick
            'AddHandler nudSlit_Exit.ValueEditorClick, AddressOf nudSlit_Exit_ValueEditorClick
            'AddHandler nudFuelRatio.ValueEditorValueChanged, AddressOf nudFuelRatio_ValueChanged
            'AddHandler nudSlit.ValueEditorValueChanged, AddressOf nudSlit_ValueChanged
            'AddHandler nudSlit_Exit.ValueEditorValueChanged, AddressOf nudSlit_Exit_ValueChanged
            Application.DoEvents()
        End Try
    End Sub

    Private Sub nudBurnerHeight_ValueEditorClick()
        '=====================================================================
        ' Procedure Name        : cmbModes_SelectedIndexChanged
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : 
        ' Description           : select index id for Calibration mode
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 21.11.06
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Dim dblReturnValue As Double
        Try
            'nudBurnerHeight.Enabled = False
            RemoveHandler nudBurnerHeight.ValueEditorClick, AddressOf nudBurnerHeight_ValueEditorClick
            'RemoveHandler cmdbtnAutoZero.Click, AddressOf btnAutoZero_Click
            'RemoveHandler cmdbtnAdjBurnerHt.Click, AddressOf cmdADJBH_Click
            'RemoveHandler cmdbtnAdjFuelFlow.Click, AddressOf cmdADJFlow_Click
            'RemoveHandler nudFuelRatio.ValueEditorClick, AddressOf nudFuelRatio_ValueEditorClick
            'RemoveHandler nudSlit.ValueEditorClick, AddressOf nudSlit_ValueEditorClick
            'RemoveHandler nudSlit_Exit.ValueEditorClick, AddressOf nudSlit_Exit_ValueEditorClick
            'RemoveHandler nudFuelRatio.ValueEditorValueChanged, AddressOf nudFuelRatio_ValueChanged
            'RemoveHandler nudSlit.ValueEditorValueChanged, AddressOf nudSlit_ValueChanged
            'RemoveHandler nudSlit_Exit.ValueEditorValueChanged, AddressOf nudSlit_Exit_ValueChanged
            'If mblnAvoidProcessing = True Then
            '    Exit Sub
            'End If
            'mblnAvoidProcessing = True

            mobjclsBgSpectrum.SpectrumWait = True
            Application.DoEvents()
            dblReturnValue = Format(gobjClsAAS203.funcConvertToBurnerHeight(gobjInst.BhStep), "0.00")
            If funcSetFrmEditValue(dblReturnValue, "Set Burner Height (0.0 - 6.0)nm", nudBurnerHeight.MinValue, nudBurnerHeight.MaxValue) = True Then
                nudBurnerHeight.Value = dblReturnValue
            End If

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            mobjclsBgSpectrum.SpectrumWait = False
            'nudBurnerHeight.Enabled = True
            AddHandler nudBurnerHeight.ValueEditorClick, AddressOf nudBurnerHeight_ValueEditorClick
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            'AddHandler cmdbtnAutoZero.Click, AddressOf btnAutoZero_Click
            'AddHandler cmdbtnAdjBurnerHt.Click, AddressOf cmdADJBH_Click
            'AddHandler cmdbtnAdjFuelFlow.Click, AddressOf cmdADJFlow_Click
            'AddHandler nudFuelRatio.ValueEditorClick, AddressOf nudFuelRatio_ValueEditorClick
            'AddHandler nudSlit.ValueEditorClick, AddressOf nudSlit_ValueEditorClick
            'AddHandler nudSlit_Exit.ValueEditorClick, AddressOf nudSlit_Exit_ValueEditorClick
            'AddHandler nudFuelRatio.ValueEditorValueChanged, AddressOf nudFuelRatio_ValueChanged
            'AddHandler nudSlit.ValueEditorValueChanged, AddressOf nudSlit_ValueChanged
            'AddHandler nudSlit_Exit.ValueEditorValueChanged, AddressOf nudSlit_Exit_ValueChanged
            'mblnAvoidProcessing = False
            nudBurnerHeight.Focus()
            Application.DoEvents()
        End Try
    End Sub

    Private Sub cmdD2GainStatus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdD2GainStatus.Click
        '=====================================================================
        ' Procedure Name        :   cmdD2GainStatus_Click
        ' Description           :   
        ' Purpose               :   
        '                           
        ' Parameters Passed     :   sender, e
        ' Returns               :   
        ' Parameters Affected   :   
        ' Assumptions           :   
        ' Dependencies          :   None.
        ' Author                :   Sachin Dokhale 
        ' Created               :   10.12.06
        ' Revisions             :
        '=====================================================================
        Dim objWait As New CWaitCursor
        Try
            ' if(ReadIniForD2Gain()){
            'if(IsD2GainOn()){
            '	GainX10Off();   //SetGain10_On()
            '	SetWindowText(GetDlgItem(hwnd,IDC_PBD2GAIN),"D2 Gain ON");
            '}
            'else{
            '	GainX10On(); //SetGain10_Off()
            '	SetWindowText(GetDlgItem(hwnd,IDC_PBD2GAIN),"D2 Gain OFF");
            '}
            '}
            mobjclsBgSpectrum.SpectrumWait = True
            cmdD2GainStatus.Enabled = False
            mobjclsBgSpectrum.SpectrumWait = True
            Call subD2GainSatus()

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            gblnSpectrumWait = False
            mobjclsBgSpectrum.SpectrumWait = False
            'nudBurnerHeight.Enabled = True
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub cmdFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFilter.Click
        '=====================================================================
        ' Procedure Name        :   cmdFilter_Click
        ' Description           :   
        ' Purpose               :   
        '                           
        ' Parameters Passed     :   sender, e
        ' Returns               :   
        ' Parameters Affected   :   
        ' Assumptions           :   
        ' Dependencies          :   None.
        ' Author                :   Sachin Dokhale 
        ' Created               :   22.12.06
        ' Revisions             :
        '=====================================================================

        Try
            'gblnSmoothFilter ^= True
            '           If (Smooth) Then
            'SetWindowText(GetDlgItem(hwnd,IDC_FILT),"Filt");
            '           Else
            'SetWindowText(GetDlgItem(hwnd,IDC_FILT),"No Filt");
            mobjclsBgSpectrum.SpectrumWait = True
            gblnSmoothFilter = gblnSmoothFilter Xor True
            If gblnSmoothFilter = True Then
                cmdFilter.Text = "Filter"
                cmdFilter.Refresh()
            Else
                cmdFilter.Text = "No Filter"
                cmdFilter.Refresh()
            End If

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            mobjclsBgSpectrum.SpectrumWait = False
            cmdFilter.Focus()
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub cmdADJFlow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdADJFlow.Click
        '=====================================================================
        ' Procedure Name        :   cmdADJFlow_Click
        ' Description           :   
        ' Purpose               :   
        '                           
        ' Parameters Passed     :   sender, e
        ' Returns               :   
        ' Parameters Affected   :   
        ' Assumptions           :   
        ' Dependencies          :   None.
        ' Author                :   Sachin Dokhale 
        ' Created               :   22.12.06
        ' Revisions             :
        '=====================================================================
        Try
            'gblnSmoothFilter ^= True

            'Smooth ^= TRUE;
            '           If (Smooth) Then
            'SetWindowText(GetDlgItem(hwnd,IDC_FILT),"Filt");
            '           Else
            'SetWindowText(GetDlgItem(hwnd,IDC_FILT),"No Filt");
            'Optimise_Fuel_Auto(hwnd);
            'Scroll_Fuel(hwnd,IDC_FUEL, -1);break;
            'funcOptimise_Fuel_Auto(1, 2)
            If mblnAvoidFormProcessing = True Then
                Exit Sub
            End If
            mblnAvoidFormProcessing = True
            mobjclsBgSpectrum.SpectrumWait = True
            If (gstructSettings.AppMode = EnumAppMode.FullVersion_201) Then
                Exit Sub
            End If
            '           If (!ReadAndSetFuelScanConditions(hpar)) Then
            'return FALSE;


            'If (!Flame_Present(False)) Then
            'return FALSE;
            '               If (!CheckNvPos()) Then
            'return FALSE;

            If Not (gobjClsAAS203.funcFlame_Present(False)) Then
                mblnAvoidFormProcessing = False
                mobjclsBgSpectrum.SpectrumWait = False
                Exit Sub
            End If

            If (Not gobjClsAAS203.funcCheckNvPos()) Then
                mblnAvoidFormProcessing = False
                mobjclsBgSpectrum.SpectrumWait = False
                Exit Sub
            End If

            gintOptimisation = modGlobalDeclarations.EnumBH_FP_Opimisation.FuelPresure
            Dim objfrmBurnerOptimisation As New frmBurnerOptimisation

            Application.DoEvents()
            objfrmBurnerOptimisation.ShowDialog()
            objfrmBurnerOptimisation.Dispose()
            Call gobjClsAAS203.funcCheck_Ignite()
            'mdblBhHeight = gobjClsAAS203.funcReadBurnerHeight()
            'nudBurnerHeight.Value = mdblBhHeight
            'mobjParameters.BurnerHeight = mdblBhHeight
            objfrmBurnerOptimisation.Dispose()
            objfrmBurnerOptimisation = Nothing

            mdblFuelRatio = gobjClsAAS203.funcGet_Fuel_Ratio(True)
            If mdblFuelRatio < 0.0 Then
                ''setting some validation
                mdblFuelRatio = 0.0
            Else
                mdblFuelRatio = Format(mdblFuelRatio, "#0.00")
            End If
            mobjParameters.FualRatio = mdblFuelRatio
            nudFuelRatio.Value = mdblFuelRatio
            nudFuelRatio.Text = mdblFuelRatio
            nudFuelRatio.Refresh()
            If gobjClsAAS203.funcCheck_Ignite = True Then
                'gobjfrmStatus.Visible = True
            Else
                'gobjfrmStatus.Visible = False
            End If
            'mobjclsBgSpectrum.SpectrumWait = False
            mblnAvoidFormProcessing = False
            mobjclsBgSpectrum.SpectrumWait = False
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
            mblnAvoidFormProcessing = False
            mobjclsBgSpectrum.SpectrumWait = False
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            'mobjclsBgSpectrum.SpectrumWait = False
            cmdADJFlow.Focus()
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub cmdADJBH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdADJBH.Click
        '=====================================================================
        ' Procedure Name        :   cmdADJFlow_Click
        ' Description           :   
        ' Purpose               :   
        '                           
        ' Parameters Passed     :   sender, e
        ' Returns               :   
        ' Parameters Affected   :   
        ' Assumptions           :   
        ' Dependencies          :   None.
        ' Author                :   Sachin Dokhale 
        ' Created               :   22.12.06
        ' Revisions             :
        '=====================================================================
        Try
            'case	IDC_ADJBH:	Optimise_Height_Auto(hwnd);
            '								Scroll_Bh(hwnd,IDC_BH, -1);
            '								Save_BH_Pos();
            '            AASGraphTimeScan.BringToFront()
            'Call gobjClsAAS203.Optimise_Height_Auto(AASGraphTimeScan)
            If mblnAvoidFormProcessing = True Then
                Exit Sub
            End If
            mblnAvoidFormProcessing = True
            mobjclsBgSpectrum.SpectrumWait = True
            gintOptimisation = modGlobalDeclarations.EnumBH_FP_Opimisation.BurnerHeight
            Dim objfrmBurnerOptimisation As New frmBurnerOptimisation
            Application.DoEvents()
            objfrmBurnerOptimisation.ShowDialog()
            objfrmBurnerOptimisation.Dispose()
            mdblBhHeight = gobjClsAAS203.funcReadBurnerHeight()
            nudBurnerHeight.Value = mdblBhHeight
            mobjParameters.BurnerHeight = mdblBhHeight

            mblnAvoidFormProcessing = False
            mobjclsBgSpectrum.SpectrumWait = False
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            mblnAvoidFormProcessing = False
            mobjclsBgSpectrum.SpectrumWait = False
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            'mobjclsBgSpectrum.SpectrumWait = False
            cmdADJBH.Focus()
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Sub

    'Private Sub btnAutoIgnition_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    '=====================================================================
    '    ' Procedure Name        : btnAutoIgnition_Click
    '    ' Parameters Passed     : Object, EventArgs
    '    ' Returns               : None
    '    ' Purpose               : 
    '    ' Description           : 
    '    ' Assumptions           : 
    '    ' Dependencies          : 
    '    ' Author                : Mangesh Shardul
    '    ' Created               : 18-Feb-2007 03:15 pm
    '    ' Revisions             : 1
    '    '=====================================================================
    '    Try
    '        'RemoveHandler mnuIgnite.Click, AddressOf btnAutoIgnition_Click

    '        mobjclsBgSpectrum.SpectrumWait = True
    '        'mobjController.Cancel()
    '        Application.DoEvents()

    '        Call gobjClsAAS203.funcIgnite(True)

    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        'Error Handling and logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = ex.Message
    '        gobjErrorHandler.WriteErrorLog(ex)
    '        '---------------------------------------------------------
    '    Finally
    '        '---------------------------------------------------------
    '        'Writing Execution log
    '        If CONST_CREATE_EXECUTION_LOG = 1 Then
    '            gobjErrorHandler.WriteExecutionLog()
    '        End If
    '        'mobjController.Start(gobjclsBgFlameStatus)
    '        mobjclsBgSpectrum.SpectrumWait = False
    '        Application.DoEvents()
    '        'AddHandler mnuIgnite.Click, AddressOf btnAutoIgnition_Click
    '        '---------------------------------------------------------
    '    End Try
    'End Sub

    'Private Sub btnExtinguish_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    '=====================================================================
    '    ' Procedure Name        : btnExtinguish_Click
    '    ' Parameters Passed     : Object, EventArgs
    '    ' Returns               : None
    '    ' Purpose               : 
    '    ' Description           : 
    '    ' Assumptions           : 
    '    ' Dependencies          : 
    '    ' Author                : Mangesh Shardul
    '    ' Created               : 18-Feb-2007 03:15 pm
    '    ' Revisions             : 1
    '    '=====================================================================
    '    Try
    '        RemoveHandler mnuExtinguish.Click, AddressOf btnExtinguish_Click
    '        'mobjController.Cancel()
    '        mobjclsBgSpectrum.SpectrumWait = True
    '        Application.DoEvents()

    '        Call gobjClsAAS203.funcIgnite(False)

    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        'Error Handling and logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = ex.Message
    '        gobjErrorHandler.WriteErrorLog(ex)
    '        '---------------------------------------------------------
    '    Finally
    '        '---------------------------------------------------------
    '        'Writing Execution log
    '        If CONST_CREATE_EXECUTION_LOG = 1 Then
    '            gobjErrorHandler.WriteExecutionLog()
    '        End If
    '        'mobjController.Start(gobjclsBgFlameStatus)
    '        mobjclsBgSpectrum.SpectrumWait = False
    '        Application.DoEvents()
    '        AddHandler mnuExtinguish.Click, AddressOf btnExtinguish_Click
    '        '---------------------------------------------------------
    '    End Try
    'End Sub

#End Region

#End Region

#Region " Private functions"

    Private Function funcInitialise()
        '=====================================================================
        ' Procedure Name        : funcInitialise
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : 
        ' Description           : Initialise the form Object
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 21.11.06
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Dim intSelectedModeType As Integer
        Try
            '//----- Added by Sachin Dokhale on 14.07.07
            If Not gstructSettings.ExeToRun = EnumApplicationMode.ServiceUtility Then
                If Not IsNothing(gobjMain) Then
                    If gobjMain.mobjController.IsThreadRunning = True Then
                        gobjMain.mobjController.Cancel()
                        gobjCommProtocol.mobjCommdll.subTime_Delay(100)   '10.12.07
                        Application.DoEvents()
                    End If
                End If
                gobjfrmStatus.Visible = True
                'Application.DoEvents()
            Else
                cmdADJFlow.Enabled = False
                cmdADJBH.Enabled = False
                cmdChangeScale.Enabled = False
                cmbModes.Enabled = False
                nudBurnerHeight.Enabled = False
                nudFuelRatio.Enabled = False
                nudSlit.Enabled = False
                nudD2Cur.Enabled = False
                nudHCLCur.Enabled = False
                nudPMT_Ref.Enabled = False
                nudPMT.Enabled = False
                mnuAdjustFuel.Enabled = False
                mnuAdjustBurnerHeight.Enabled = False
                mnuChangeScale.Enabled = False
                cmdbtnAdjFuelFlow.Enabled = False
                cmdbtnAdjBurnerHt.Enabled = False
                cmdbtnChangeScale.Enabled = False
            End If
            '''''''''''***********

            lblWvPos.Text = mXValueLable & Format(gobjInst.WavelengthCur, "#0.0")
            lblWvPos.Refresh()
            cmbModes.Visible = True
            'Application.DoEvents()

            nudBurnerHeight.IsReverseOperation = True
            nudBurnerHeight.IsUpDownButtonToBeDisabledOnValueChange = True
            nudFuelRatio.IsUpDownButtonToBeDisabledOnValueChange = True

            mblnIsfrmFlameStatusWork = True
            If Not IsNothing(gobjMain) Then
                If gobjMain.mobjController.IsThreadRunning = True Then
                    gobjMain.mobjController.Cancel()
                    gobjCommProtocol.mobjCommdll.subTime_Delay(100)   '10.12.07
                    Application.DoEvents()
                End If
            End If
            'Application.DoEvents()


            If gobjInst.Mode > -1 Then
                If gintInstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.DoubleBeam Then
                    cmbModes.SelectedIndex = gobjInst.Mode
                Else
                    cmbModes.SelectedIndex = gobjInst.Mode
                    intSelectedModeType = gobjInst.Mode
                End If
            End If

            gobjClsAAS203.funcReadFilterSetting()
            Call funcSetDefaultSpectrumParameter(cmbModes.SelectedIndex)
            Call AddHandlers()
            gblnSpectrumTerminated = False
            gblnSpectrumWait = False

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            objWait.Dispose()
            '---------------------------------------------------------
        End Try
    End Function

    Private Sub AddHandlers()
        '=====================================================================
        ' Procedure Name        : AddHandlers
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : To add event handlers
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh
        ' Created               : 15.11.06
        ' Revisions             : 
        '=====================================================================
        Try
            AddHandler cmbModes.SelectedIndexChanged, AddressOf cmbModes_SelectedIndexChanged
            AddHandler btnReturn.Click, AddressOf mnuExit_Click
            AddHandler cmdbtnReturn.Click, AddressOf mnuExit_Click
            AddHandler mnuReturn.Click, AddressOf mnuExit_Click
            AddHandler cmdbtnChangeScale.Click, AddressOf cmdChangeScale_Click
            AddHandler mnuChangeScale.Click, AddressOf cmdChangeScale_Click

            AddHandler cmdbtnAutoZero.Click, AddressOf btnAutoZero_Click
            AddHandler mnuAutoZero.Click, AddressOf btnAutoZero_Click
            AddHandler cmdbtnAdjBurnerHt.Click, AddressOf cmdADJBH_Click
            AddHandler cmdbtnAdjFuelFlow.Click, AddressOf cmdADJFlow_Click
            AddHandler mnuAdjustBurnerHeight.Click, AddressOf cmdADJBH_Click
            AddHandler mnuAdjustFuel.Click, AddressOf cmdADJFlow_Click
            AddHandler btnAutoZero.Click, AddressOf btnAutoZero_Click
            AddHandler btnClearSpectrum.Click, AddressOf btnClearSpectrum_Click

            'AddHandler nudFuelRatio.ValueChanged, AddressOf nudFuelRatio_ValueChanged
            AddHandler nudFuelRatio.ValueEditorValueChanged, AddressOf nudFuelRatio_ValueChanged
            AddHandler nudFuelRatio.ValueEditorClick, AddressOf nudFuelRatio_ValueEditorClick

            'AddHandler nudBurnerHeight.ValueChanged, AddressOf nudBurnerHeight_ValueChanged
            AddHandler nudBurnerHeight.ValueEditorValueChanged, AddressOf nudBurnerHeight_ValueChanged
            AddHandler nudBurnerHeight.ValueEditorClick, AddressOf nudBurnerHeight_ValueEditorClick

            'AddHandler nudD2Cur.ValueChanged, AddressOf nudD2Cur_ValueChanged
            AddHandler nudD2Cur.ValueEditorValueChanged, AddressOf nudD2Cur_ValueChanged
            AddHandler nudD2Cur.ValueEditorClick, AddressOf nudD2Cur_ValueEditorClick

            'AddHandler nudHCLCur.ValueChanged, AddressOf nudHCLCur_ValueChanged
            AddHandler nudHCLCur.ValueEditorValueChanged, AddressOf nudHCLCur_ValueChanged
            AddHandler nudHCLCur.ValueEditorClick, AddressOf nudHCLCur_ValueEditorClick

            'AddHandler nudSlit.ValueChanged, AddressOf nudSlit_ValueChanged
            AddHandler nudSlit.ValueEditorValueChanged, AddressOf nudSlit_ValueChanged
            AddHandler nudSlit.ValueEditorClick, AddressOf nudSlit_ValueEditorClick

            AddHandler nudSlit_Exit.ValueEditorValueChanged, AddressOf nudSlit_Exit_ValueChanged
            AddHandler nudSlit_Exit.ValueEditorClick, AddressOf nudSlit_Exit_ValueEditorClick

            'AddHandler nudPMT.ValueChanged, AddressOf nudPMT_ValueChanged
            'AddHandler nudPMT.ValueEditorClick, AddressOf nudPMT_ValueChanged
            AddHandler nudPMT.ValueEditorValueChanged, AddressOf nudPMT_ValueChanged
            AddHandler nudPMT.ValueEditorClick, AddressOf nudPMT_ValueEditorClick

            AddHandler nudPMT_Ref.ValueEditorValueChanged, AddressOf nudPMT_Ref_ValueChanged
            AddHandler nudPMT_Ref.ValueEditorClick, AddressOf nudPMT_Ref_ValueEditorClick

            'AddHandler cmbSpeed.SelectedIndexChanged, AddressOf cmbSpeed_SelectedIndexChanged
            AddHandler cmdChangeScale.Click, AddressOf cmdChangeScale_Click
            AddHandler btnLampParameters.Click, AddressOf btnLampParameters_Click
            AddHandler AASGraphTimeScan.GraphScaleChanged, AddressOf AASGraphTimeScan_GraphScaleChanged
            'AddHandler mnuIgnite.Click, AddressOf btnAutoIgnition_Click
            'AddHandler mnuExtinguish.Click, AddressOf btnExtinguish_Click
            AddHandler mnuGrid.Click, AddressOf mnuGrid_Click
            AddHandler mnuShowXYValues.Click, AddressOf mnuShowXYValues_Click

            AddHandler mnuPrintGraph.Click, AddressOf btnPrintGraph_Click
            AddHandler cmdbtnPrintGraph.Click, AddressOf btnPrintGraph_Click

            AddHandler btnIgnite.Click, AddressOf btnIgnite_Click
            AddHandler btnExtinguish.Click, AddressOf btnExtinguish_Click
            AddHandler btnN2OIgnite.Click, AddressOf btnN2OIgnite_Click
            AddHandler btnDelete.Click, AddressOf btnDelete_Click
            AddHandler btnR.Click, AddressOf btnR_Click

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub subAutoZeroScan()
        '=====================================================================
        ' Procedure Name        : subAutoZeroScan
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 07.10.06
        ' Revisions             : 
        '=====================================================================
        'Dim objWait As New CWaitCursor
        Try

            'If mblnAvoidProcessing = True Then
            '    Exit Sub
            'End If
            'gblnSpectrumWait = True
            RemoveHandler nudPMT.ValueEditorValueChanged, AddressOf nudPMT_ValueChanged
            If Not (gintInstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.SingleBeam) Then
                RemoveHandler nudPMT_Ref.ValueEditorValueChanged, AddressOf nudPMT_Ref_ValueChanged
            End If
            RemoveHandler nudD2Cur.ValueEditorValueChanged, AddressOf nudD2Cur_ValueChanged
            RemoveHandler nudHCLCur.ValueEditorValueChanged, AddressOf nudHCLCur_ValueChanged

            Application.DoEvents()
            'Call func_Enable_Disable(EnumProcesses.StartScan, EnumStart_End.Start_of_Process)

            gobjClsAAS203.subAutoZero(True)

            If gstructSettings.D2Gain = True Then
                cmdD2GainStatus.Visible = True
                If gobjCommProtocol.funcIsD2GainOn = &H1 Then
                    cmdD2GainStatus.Text = "D2 Gain On"
                ElseIf gobjCommProtocol.funcIsD2GainOn = &H0 Then
                    cmdD2GainStatus.Text = "D2 Gain Off"
                End If
            End If
            nudPMT.Value = gobjInst.PmtVoltage
            If Not (gintInstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.SingleBeam) Then
                nudPMT_Ref.Value = gobjInst.PmtVoltageReference
            End If
            nudHCLCur.Value = gobjInst.Current
            nudD2Cur.Value = gobjInst.D2Current
            Application.DoEvents()


        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            'If Not objWait Is Nothing Then
            '    objWait.Dispose()
            'End If
            'gblnSpectrumWait = False
            AddHandler nudPMT.ValueEditorValueChanged, AddressOf nudPMT_ValueChanged
            If Not (gintInstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.SingleBeam) Then
                AddHandler nudPMT_Ref.ValueEditorValueChanged, AddressOf nudPMT_Ref_ValueChanged
            End If
            AddHandler nudD2Cur.ValueEditorValueChanged, AddressOf nudD2Cur_ValueChanged
            AddHandler nudHCLCur.ValueEditorValueChanged, AddressOf nudHCLCur_ValueChanged
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub subStopScan()
        '=====================================================================
        ' Procedure Name        : subStartScan
        ' Parameters Passed     : 
        ' Returns               : None
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 07.10.06
        ' Revisions             : 
        '=====================================================================
        'Dim objWait As New CWaitCursor
        Try
            ' Set interupte for Termination of the thread
            'gblnSpectrumTerminated = True
            mobjclsBgSpectrum.ThTerminate = True


        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            'If Not objWait Is Nothing Then
            '    objWait.Dispose()
            'End If
            '---------------------------------------------------------
        End Try


    End Sub

    Private Sub subClearScan()
        '=====================================================================
        ' Procedure Name        : subClearScan
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 07.10.06
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Try

            'If mblnAvoidProcessing = True Then
            '    Exit Sub
            'End If
            gblnSpectrumWait = True
            Application.DoEvents()
            funcClearGraph()

            'Call func_Enable_Disable(EnumProcesses.StartScan, EnumStart_End.Start_of_Process)


        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            gblnSpectrumWait = False
            Application.DoEvents()
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub subSmoothGraph()
        '=====================================================================
        ' Procedure Name        : subSmoothGraph
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 16.10.06
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Try
            Dim objchanel0 As Channel

            If mblnAvoidFormProcessing = True Then
                Exit Sub
            End If

            objchanel0 = mobjSpectrum.funcCloneESChannel(mobjChannnels(mintChannelIndex))
            If Not (objchanel0) Is Nothing Then
                mobjSpectrum.funcSmooth1(objchanel0, 0)
                mobjChannnels(mintChannelIndex) = mobjSpectrum.funcCloneESChannel(objchanel0)
            End If
            'Call func_Enable_Disable(EnumProcesses.StartScan, EnumStart_End.Start_of_Process)


        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub subPeakValley()
        '=====================================================================
        ' Procedure Name        : subPeakValley
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 14.12.06
        ' Revisions             : 
        '=====================================================================
        'Dim objWait As New CWaitCursor
        Dim objDataTable As New DataTable
        Dim objPeakVallyChannel As Channel
        Dim intCounter As Integer = 0
        Dim lngPeakValleyCounts As Long
        Try

            If mblnAvoidFormProcessing = True Then
                Exit Sub
            End If
            mblnAvoidFormProcessing = True
            If Not (mobjChannnels.item(mintChannelIndex) Is Nothing) Then
                If mobjSpectrum.funcPeaks(mobjChannnels.item(mintChannelIndex), mStuctPeaksValley) = False Then
                    gobjMessageAdapter.ShowMessage(constErrorPeakValley)
                    'MsgBox("Error in Peak Valley Methods", MsgBoxStyle.Critical)
                End If
            Else
                Exit Sub
            End If
            '--- Check for Peak-Valley points
            If mobjSpectrum.PeakValleyCount <= 0 Then
                'Call gFuncShowMessage("Peak Pick", "No Peaks Or Valleys detected.", EnumMessageType.Information)
                Exit Sub
            End If


            '//----- Heaight the peak valley point
            'If Not funcHighlightPeakValleyPoints(structPeak, lngPeakValleyCounts, objChannel) Then
            '    gFuncShowMessage("Error...", "Error in displaying the Peak Valley points.", modConstants.EnumMessageType.Information)
            'End If
            '//----------
            'If mobjChannnels.item(mintChannelIndex).IsEnergySpectrum = True Then
            '    objPeakVallyChannel = New Channel(True)
            'Else
            '    objPeakVallyChannel = New Channel(False)
            'End If

            '/----- Ini for Energy Spectrum
            objPeakVallyChannel = New Channel(True)

            If Not mobjSpectrum.funcGetDataPeakPickResults(objDataTable, mStuctPeaksValley, lngPeakValleyCounts, objPeakVallyChannel) Then
                'gFuncShowMessage("Error...", "Error in populating the peak valley data in the data table to display on the screen.", EnumMessageType.Information)'138
            End If

            Dim frmPeakPick As New frmPeakPicks
            Call frmPeakPick.funcDisplayPicPeakResults(objDataTable)

            'Call func_Enable_Disable(EnumProcesses.StartScan, EnumStart_End.Start_of_Process)

            '//----------
            'Dim intShowdialog As Integer
            'Dim objPrintDialog As New PrintDialog
            'intShowdialog = frmPeakPick.ShowDialog
            'If intShowdialog = DialogResult.Yes Then
            '    objPrintDialog.Document = PrintDocument1
            '    objPrintDialog.PrinterSettings = PrintDocument1.PrinterSettings
            '    objPrintDialog.AllowSomePages = True
            '    Dim result As DialogResult = objPrintDialog.ShowDialog()

            '    If (result = DialogResult.OK) Then
            '        AxSpectrumGraph.PrinterName = objPrintDialog.PrinterSettings.PrinterName
            '        Call subPrintSpectrumPeakPick(objDataTable, objChannel)
            '    End If
            'ElseIf intShowdialog = DialogResult.OK Then
            '    objPrintDialog.Document = PrintDocument1
            '    objPrintDialog.PrinterSettings = PrintDocument1.PrinterSettings
            '    objPrintDialog.AllowSomePages = True
            '    Dim result As DialogResult = objPrintDialog.ShowDialog()

            '    If (result = DialogResult.OK) Then
            '        AxSpectrumGraph.PrinterName = objPrintDialog.PrinterSettings.PrinterName
            '        Call subPrintSpectrumPeakPick_WithOutGraph(objDataTable, objChannel)
            '    End If
            'End If
            '//---------

            frmPeakPick.Dispose()

            Call subClearScan()

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            mblnAvoidFormProcessing = False
            'If Not objWait Is Nothing Then
            '    objWait.Dispose()
            'End If
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub subLampParameterChanged()
        '=====================================================================
        ' Procedure Name        : subLampParameterChanged
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 07.12.06
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Dim objfrmChangeLampPara As New frmChangeLampParameters

        Try
            gblnSpectrumWait = True
            Application.DoEvents()

            If objfrmChangeLampPara.ShowDialog() = DialogResult.OK Then
                nudHCLCur.Value = gobjInst.Current
            End If

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            objfrmChangeLampPara.Dispose()
            gblnSpectrumWait = False
            Application.DoEvents()
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If

            'mblnAvoidProcessing = False
            '---------------------------------------------------------
        End Try
    End Sub

    Private Function funcSetParameter() As Boolean
        '=====================================================================
        ' Procedure Name        : funcSetParameter
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : 
        ' Description           : Set Spectrum Parameter
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 21.11.06
        ' Revisions             : 
        '=====================================================================
        Dim intMaxD2Current As Integer
        Dim intMinD2Current As Integer
        Dim intSelectedModeType As Integer
        Try
            funcSetParameter = False


            '//----- Set the default parameter to the spectrum.
            '/----- Set the Form object parameter
            '//----- Set PMT Object

            'If (gobjInst.Mode = EnumCalibrationMode.MABS) Or (gobjInst.Mode = EnumCalibrationMode.AA) Or (gobjInst.Mode = EnumCalibrationMode.AABGC) Or (gobjInst.Mode = EnumCalibrationMode.AABGCSR) Then
            '    nudD2Cur.Enabled = True
            'Else
            '    nudD2Cur.Enabled = False
            'End If

            If mobjChannnels(mintChannelIndex).ChannelNo > -1 Then


                'nudPMT.Value = gobjInst.PmtVoltage
                nudPMT.Value = mobjChannnels(mintChannelIndex).EnegryParameter.PMTV()
                '//-----

                If Not (gintInstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.SingleBeam) Then
                    nudPMT_Ref.Value = mobjChannnels(mintChannelIndex).EnegryParameter.PMTV_Ref
                End If
                '//----- Set D2 current Object
                'If gobjCommProtocol.SRLamp Then
                '    intMaxD2Current = 600
                '    intMinD2Current = 100
                'Else
                '    intMaxD2Current = 300
                '    intMinD2Current = 100
                'End If

                'nudD2Cur.Value = gobjInst.D2Current
                nudD2Cur.Value = mobjChannnels(mintChannelIndex).EnegryParameter.D2Curr
                '//-----

                '//----- Set Slit width Object
                'nudSlit.Value = gobjClsAAS203.funcGet_SlitWidth()
                nudSlit.Value = mobjChannnels(mintChannelIndex).EnegryParameter.SlitWidth
                nudSlit_Exit.Value = mobjChannnels(mintChannelIndex).EnegryParameter.SlitWidthRef

                nudBurnerHeight.Value = mobjChannnels(mintChannelIndex).EnegryParameter.BurnerHeight

                nudFuelRatio.Value = mobjChannnels(mintChannelIndex).EnegryParameter.FualRatio

                nudHCLCur.Value = mobjChannnels(mintChannelIndex).EnegryParameter.HCLCurr



                '//-----
                If gintInstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.DoubleBeam Then
                    Select Case mobjChannnels(mintChannelIndex).EnegryParameter.Cal_Mode()
                        Case EnumCalibrationMode.AA
                            intSelectedModeType = 0
                        Case EnumCalibrationMode.AABGC
                            intSelectedModeType = 1
                        Case EnumCalibrationMode.SELFTEST
                            intSelectedModeType = 2
                    End Select
                Else
                    intSelectedModeType = mobjChannnels(mintChannelIndex).EnegryParameter.Cal_Mode()
                End If
                'cmbModes.SelectedIndex = mobjChannnels(mintChannelIndex).EnegryParameter.Cal_Mode()
                cmbModes.SelectedIndex = intSelectedModeType

            End If
            Application.DoEvents()
            funcSetParameter = True

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            Return False
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------
        End Try
    End Function

    Private Function funcGetInstParameter() As Boolean
        '=====================================================================
        ' Procedure Name        : funcGetInstParameter
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : 
        ' Description           : Set Instrument Parameter
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 21.11.06
        ' Revisions             : 
        '=====================================================================
        Dim intMaxD2Current As Integer
        Dim intMinD2Current As Integer
        Try
            funcGetInstParameter = False


            '//----- Set the default parameter to the spectrum.
            '/----- Set the Form object parameter
            '//----- Set PMT Object



            '--- Set issue for Speed 
            'If gblnSetSpeedIssue = True Then
            '//----- added by Sachin dokhale to remove handlers
            '28.09.07
            RemoveHandler nudFuelRatio.ValueEditorValueChanged, AddressOf nudFuelRatio_ValueChanged
            RemoveHandler nudFuelRatio.ValueEditorClick, AddressOf nudFuelRatio_ValueEditorClick

            RemoveHandler nudBurnerHeight.ValueEditorValueChanged, AddressOf nudBurnerHeight_ValueChanged
            RemoveHandler nudBurnerHeight.ValueEditorClick, AddressOf nudBurnerHeight_ValueEditorClick

            RemoveHandler nudD2Cur.ValueEditorValueChanged, AddressOf nudD2Cur_ValueChanged
            RemoveHandler nudD2Cur.ValueEditorClick, AddressOf nudD2Cur_ValueEditorClick

            RemoveHandler nudHCLCur.ValueEditorValueChanged, AddressOf nudHCLCur_ValueChanged
            RemoveHandler nudHCLCur.ValueEditorClick, AddressOf nudHCLCur_ValueEditorClick

            RemoveHandler nudSlit.ValueEditorValueChanged, AddressOf nudSlit_ValueChanged
            RemoveHandler nudSlit.ValueEditorClick, AddressOf nudSlit_ValueEditorClick
            RemoveHandler nudSlit_Exit.ValueEditorValueChanged, AddressOf nudSlit_Exit_ValueChanged
            RemoveHandler nudSlit_Exit.ValueEditorClick, AddressOf nudSlit_Exit_ValueEditorClick


            RemoveHandler nudPMT.ValueEditorValueChanged, AddressOf nudPMT_ValueChanged
            RemoveHandler nudPMT.ValueEditorClick, AddressOf nudPMT_ValueEditorClick
            RemoveHandler nudPMT_Ref.ValueEditorValueChanged, AddressOf nudPMT_Ref_ValueChanged
            RemoveHandler nudPMT_Ref.ValueEditorClick, AddressOf nudPMT_Ref_ValueEditorClick
            '//-----
            'End If


            nudPMT.Value = gobjInst.PmtVoltage
            If Not (gintInstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.SingleBeam) Then
                nudPMT_Ref.Value = gobjInst.PmtVoltageReference
            End If
            'nudPMT.Value = mobjChannnels(mintChannelIndex).EnegryParameter.PMTV()
            '//-----

            '//----- Set D2 current Object
            'If gobjCommProtocol.SRLamp Then
            '    intMaxD2Current = 600
            '    intMinD2Current = 100
            'Else
            '    intMaxD2Current = 300
            '    intMinD2Current = 100
            'End If

            nudD2Cur.Value = gobjInst.D2Current

            'nudD2Cur.Value = mobjChannnels(mintChannelIndex).EnegryParameter.D2Curr
            '//-----

            '//----- Set Slit width Object
            'nudSlit.Value = mobjChannnels(mintChannelIndex).EnegryParameter.SlitWidth
            nudSlit.Value = gobjClsAAS203.funcGet_SlitWidth()
            nudSlit_Exit.Value = gobjClsAAS203.funcGet_SlitWidth(1)

            'nudBurnerHeight.Value = mobjChannnels(mintChannelIndex).EnegryParameter.BurnerHeight
            nudBurnerHeight.Value = gobjClsAAS203.funcReadBurnerHeight()


            'nudFuelRatio.Value = mobjChannnels(mintChannelIndex).EnegryParameter.FualRatio
            'funcSetFuelParameter(0)
            funcSetFuelParameter(mdblFuelRatio)
            mdblFuelRatio = Format(mdblFuelRatio, "#.00")
            nudFuelRatio.Value = Format(mdblFuelRatio, "#.00")


            'nudHCLCur.Value = mobjChannnels(mintChannelIndex).EnegryParameter.HCLCurr
            nudHCLCur.Value = gobjInst.Current

            If Not (mobjParameters Is Nothing) Then
                mobjParameters.PMTV = gobjInst.PmtVoltage
                mobjParameters.HCLCurr = gobjInst.Current
                mobjParameters.SlitWidth = Val(nudSlit.Value)
                mobjParameters.D2Curr = gobjInst.D2Current
                mobjParameters.BurnerHeight = CDbl(nudBurnerHeight.Value)
                mobjParameters.FualRatio = Format(mdblFuelRatio, "#.00")
            End If
            '//-----
            '--- Set issue for Speed 
            'If gblnSetSpeedIssue = True Then
            '//----- added by Sachin dokhale to add handlers
            '28.09.07
            AddHandler nudFuelRatio.ValueEditorValueChanged, AddressOf nudFuelRatio_ValueChanged
            AddHandler nudFuelRatio.ValueEditorClick, AddressOf nudFuelRatio_ValueEditorClick

            AddHandler nudBurnerHeight.ValueEditorValueChanged, AddressOf nudBurnerHeight_ValueChanged
            AddHandler nudBurnerHeight.ValueEditorClick, AddressOf nudBurnerHeight_ValueEditorClick

            AddHandler nudD2Cur.ValueEditorValueChanged, AddressOf nudD2Cur_ValueChanged
            AddHandler nudD2Cur.ValueEditorClick, AddressOf nudD2Cur_ValueEditorClick

            AddHandler nudHCLCur.ValueEditorValueChanged, AddressOf nudHCLCur_ValueChanged
            AddHandler nudHCLCur.ValueEditorClick, AddressOf nudHCLCur_ValueEditorClick

            AddHandler nudSlit.ValueEditorValueChanged, AddressOf nudSlit_ValueChanged
            AddHandler nudSlit.ValueEditorClick, AddressOf nudSlit_ValueEditorClick
            AddHandler nudSlit_Exit.ValueEditorValueChanged, AddressOf nudSlit_Exit_ValueChanged
            AddHandler nudSlit_Exit.ValueEditorClick, AddressOf nudSlit_Exit_ValueEditorClick

            AddHandler nudPMT.ValueEditorValueChanged, AddressOf nudPMT_ValueChanged
            AddHandler nudPMT.ValueEditorClick, AddressOf nudPMT_ValueEditorClick
            AddHandler nudPMT_Ref.ValueEditorValueChanged, AddressOf nudPMT_Ref_ValueChanged
            AddHandler nudPMT_Ref.ValueEditorClick, AddressOf nudPMT_Ref_ValueEditorClick
            'End If
            '//---

            Application.DoEvents()
            funcGetInstParameter = True

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            Return False
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------
        End Try
    End Function

    Private Function funcSetSpeed(ByVal intSpeed As Integer) As Boolean
        '=====================================================================
        ' Procedure Name        : funcSetSpeed
        ' Parameters Passed     : intSpeed 
        ' Returns               : Boolean
        ' Purpose               : 
        ' Description           : Set scan Speed
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 22.11.06
        ' Revisions             : 
        '=====================================================================

        Try
            funcSetSpeed = False
            Select Case intSpeed
                Case 0
                    mobjParameters.ScanSpeed = CONST_FASTStep
                Case 1
                    mobjParameters.ScanSpeed = CONST_MEDIUMStep
                Case 2
                    mobjParameters.ScanSpeed = CONST_SLOWStep
            End Select
            funcSetSpeed = True

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            Return False
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------
        End Try
    End Function

    Private Sub subLabelDisplay(ByVal objChannel As Spectrum.Channel)
        Try
            'Select Case objChannel.Parameter.ScanSpeed
            '    Case EnumScanSpeed.Fast
            '        lblScanSpeed.Text = CONST_SCAN_SPEED_FAST
            '    Case EnumScanSpeed.Medium
            '        lblScanSpeed.Text = CONST_SCAN_SPEED_MEDIUM
            '    Case EnumScanSpeed.Slow
            '        lblScanSpeed.Text = CONST_SCAN_SPEED_SLOW
            '    Case EnumScanSpeed.VerySlow
            '        lblScanSpeed.Text = CONST_SCAN_SPEED_VERY_SLOW
            'End Select

            'lblAnalystName.Text = objChannel.Parameter.AnalystName
            'lblAnalystName.Refresh()
            'lblSpectrumName.Text = objChannel.Parameter.ChannelName
            'lblSpectrumName.Refresh()
            'added and commented by kamal on 19March2004
            '----------------------------
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            'gobjErrorHandler.ProcessError(ErrorHandler.EnumErrorType.Critical, ex)
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------
        End Try

    End Sub

    Private Function funcAddChannelToCollection(ByRef objInChannel As Spectrum.Channel) As Integer
        '=====================================================================
        ' Procedure Name        :   funcAddChannelToCollection
        ' Description           :   Add the channel to the channels collection
        '                           mobjChannels to the next index of the current 
        '                           active index of the channel.
        ' Purpose               :   To add the channel object to the channels
        '                           collection (stored in the module level).
        ' Parameters Passed     :   None.
        ' Returns               :   new index of the channel added.
        ' Parameters Affected   :   None.
        ' Assumptions           :   None.
        ' Dependencies          :   None. 
        ' Author                :   Sachin Dokhale
        ' Created               :   13.12.06
        ' Revisions             :
        '=====================================================================
        Dim intChannel_no As Integer
        Try

            '--- Set the channel index location in the main
            '--- channel collection

            'If mobjChannnels.Count = CONST_CHANNEL_COUNT Then
            '    intChannel_no = CInt(gfuncGetINISystemParameters(CONST_SECTION_SpectrumChannel, CONST_Key_CurrentChannel))
            '    If intChannel_no >= CONST_CHANNEL_COUNT - 1 Then
            '        intChannel_no = 0
            '    Else
            '        intChannel_no += 1
            '    End If

            'Else
            intChannel_no = mobjChannnels.Count
            objInChannel.ChannelNo = intChannel_no

            If mobjChannnels.Count > 0 Then
                mobjChannnels.item(0) = objInChannel
            Else
                mobjChannnels.Add(objInChannel)
            End If

            'End If

            '--- Save or overwrite the channel to the file using serializability
            'If Not gfuncSaveChannelToFile(objInChannel) Then
            '    '--- log the error saving the channel file.
            '    gFuncShowMessage("Error...", "Error in save channel file.", modConstants.EnumMessageType.Information)
            'End If

            'gfuncWriteINISystemParameters(CONST_SECTION_SpectrumChannel, CONST_Key_CurrentChannel, intChannel_no)

            Return intChannel_no

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            'gobjErrorHandler.ProcessError(EnumErrorType.Critical, ex)
            '---------------------------------------------------------
            Return 0
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------
        End Try

    End Function

    'Private Function funcCloneParameter(ByVal inobjparamter As Spectrum.EnergySpectrumParameter) As Spectrum.EnergySpectrumParameter
    '    Try
    '        Dim objCloneParameter As New EnergySpectrumParameter
    '        '----------------------Cloning  parameter object ----------------------------------
    '        objCloneParameter.AnalysisDate = inobjparamter.AnalysisDate
    '        objCloneParameter.BurnerHeight = inobjparamter.BurnerHeight
    '        objCloneParameter.FualRatio = inobjparamter.FualRatio
    '        objCloneParameter.HCLCurr = inobjparamter.HCLCurr
    '        objCloneParameter.LampEle = inobjparamter.LampEle
    '        objCloneParameter.LampTurrNo = inobjparamter.LampTurrNo
    '        objCloneParameter.Cal_Mode = inobjparamter.Cal_Mode
    '        objCloneParameter.Comments = inobjparamter.Comments
    '        objCloneParameter.D2Curr = inobjparamter.D2Curr
    '        objCloneParameter.PMTV = inobjparamter.PMTV
    '        objCloneParameter.ScanSpeed = inobjparamter.ScanSpeed
    '        objCloneParameter.SlitWidth = inobjparamter.SlitWidth
    '        objCloneParameter.SpectrumName = inobjparamter.SpectrumName
    '        objCloneParameter.XaxisMax = inobjparamter.XaxisMax
    '        objCloneParameter.XaxisMin = inobjparamter.XaxisMin
    '        objCloneParameter.YaxisMax = inobjparamter.YaxisMax
    '        objCloneParameter.YaxisMin = inobjparamter.YaxisMin

    '        '----------------------Clonong  parameter object ends -----------------------------
    '        Return objCloneParameter

    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        'Error Handling and logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = ex.Message
    '        gobjErrorHandler.WriteErrorLog(ex)
    '        'gobjErrorHandler.ProcessError(EnumErrorType.Critical, ex)
    '        '---------------------------------------------------------
    '    Finally
    '        '---------------------------------------------------------
    '        'Writing Execution log
    '        If CONST_CREATE_EXECUTION_LOG = 1 Then
    '            gobjErrorHandler.WriteExecutionLog()
    '        End If
    '        '---------------------------------------------------------
    '    End Try

    'End Function

    'Private Function funcAbsConvertTransmission() As Boolean
    '    '=====================================================================
    '    ' Procedure Name        :   funcAddChannelToCollection
    '    ' Description           :   
    '    ' Purpose               :   
    '    ' Parameters Passed     :   None.
    '    ' Returns               :   Boolean
    '    ' Parameters Affected   :   None.
    '    ' Assumptions           :   None.
    '    ' Dependencies          :   None. 
    '    ' Author                :   Sachin Dokhale
    '    ' Created               :   13.12.06
    '    ' Revisions             :
    '    '=====================================================================
    '    Dim dblCurrYaxis As Double
    '    Dim dblNewYaxis As Double
    '    Dim intXaxisIdx As Double

    '    Try
    '        gblnUVABS = False
    '        If mobjChannnels.Count > 0 Then
    '            If mobjChannnels.item(mintChannelIndex).Spectrums.Count > 0 Then
    '                'For intXaxisIdx = gFuncGetIndexWv(mobjChannnels.item(mintChannelIndex).UVParameter.XaxisMin, False) To gFuncGetIndexWv(mobjChannnels.item(mintChannelIndex).UVParameter.XaxisMax, False)
    '                For intXaxisIdx = 0 To mobjChannnels.item(mintChannelIndex).Spectrums.item(0).Readings.Count - 1
    '                    dblCurrYaxis = mobjChannnels.item(mintChannelIndex).Spectrums.item(0).Readings.item(intXaxisIdx).YaxisData
    '                    'k= 2047.0 + exp((2.0- ((addata.ad[i]-2047.0)*2.0/1638.4)) *log(10))*2048.0/100.0;
    '                    dblNewYaxis = 2047.0 + Math.Exp((2.0 - ((dblCurrYaxis - 2047.0) * 2.0 / 1638.4)) * Math.Log(10)) * 2048.0 / 100.0
    '                    mobjChannnels.item(mintChannelIndex).Spectrums.item(0).Readings.item(intXaxisIdx).YaxisData = dblNewYaxis
    '                Next
    '            End If
    '        End If
    '        funcClearGraph()

    '        mobjChannnels.item(mintChannelIndex).UVParameter.YaxisMax = 100
    '        mobjChannnels.item(mintChannelIndex).UVParameter.YaxisMin = 0

    '        funcDisplayGraph(mobjChannnels.item(mintChannelIndex))
    '        Return True
    '        '           if (addata.ad!=NULL) {
    '        ' for (i=0; i<addata.counter; i++){
    '        ' k= 2047.0 + exp((2.0- ((addata.ad[i]-2047.0)*2.0/1638.4)) *log(10))*2048.0/100.0;
    '        ' addata.ad[i] =k;
    '        '}
    '        ' UVABS=FALSE;
    '        ' SpectGraph.Ymin = 0;
    '        ' SpectGraph.Ymax = 100;
    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        'Error Handling and logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = ex.Message
    '        gobjErrorHandler.WriteErrorLog(ex)
    '        'gobjErrorHandler.ProcessError(EnumErrorType.Critical, ex)
    '        '---------------------------------------------------------
    '        Return False
    '    Finally
    '        '---------------------------------------------------------
    '        'Writing Execution log
    '        If CONST_CREATE_EXECUTION_LOG = 1 Then
    '            gobjErrorHandler.WriteExecutionLog()
    '        End If
    '        '---------------------------------------------------------
    '    End Try


    'End Function

    Private Function funcSetDefaultSpectrumParameter(ByVal intCalibrationMode As Integer) As Boolean
        '=====================================================================
        ' Procedure Name        : funcSetDefaultSpectrumParameter
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : 
        ' Description           : Set Spectrum Parameter
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 21.11.06
        ' Revisions             : 
        '=====================================================================
        Static blnSetDefaultSpectrumParameter As Boolean
        Try
            funcSetDefaultSpectrumParameter = False
            '//----- Set the default parameter to the spectrum.
            If (gobjInst.Mode = intCalibrationMode) And (blnSetDefaultSpectrumParameter = True) Then
                funcSetDefaultSpectrumParameter = True
                Exit Function
            End If

            If gobjCommProtocol.funcCalibrationMode(intCalibrationMode) Then
                'If (gobjInst.Mode = EnumCalibrationMode.MABS) Or (gobjInst.Mode = EnumCalibrationMode.AA) Or (gobjInst.Mode = EnumCalibrationMode.AABGC) Or (gobjInst.Mode = EnumCalibrationMode.AABGCSR) Then
                '    nudD2Cur.Enabled = True
                'Else
                '    nudD2Cur.Enabled = False
                'End If
                'addataSpect.dblWvMin = 230.0
                'addataSpect.dblWvMax = 250.0
                mobjParameters.XaxisMin = 0
                mobjParameters.XaxisMax = 100.0

                Select Case gobjInst.Mode
                    Case EnumCalibrationMode.AA, EnumCalibrationMode.AABGC, EnumCalibrationMode.MABS

                        mobjParameters.YaxisMax = const_YMaxAbs
                        mobjParameters.YaxisMin = const_YMinAbs
                        mYValueLable = const_Absorbance
                        mYAXIS_LABEL = const_ABSORBANCE_YLabel
                        mstrYaxisFormat = "0.000"
                    Case EnumCalibrationMode.HCLE, EnumCalibrationMode.D2E
                        mobjParameters.YaxisMin = const_YMinEnergy
                        mobjParameters.YaxisMax = const_YMaxEnergy
                        mYValueLable = const_Energy
                        mYAXIS_LABEL = const_ENERGY_YLabel
                        'mstrYaxisFormat = "0.00#"
                        mstrYaxisFormat = "0.0"
                    Case EnumCalibrationMode.EMISSION
                        mobjParameters.YaxisMin = const_YMinEmission
                        mobjParameters.YaxisMax = const_YMaxEmission
                        mYValueLable = const_Emission
                        mYAXIS_LABEL = const_EMISSION_YLabel
                        mstrYaxisFormat = "0.0"
                    Case EnumCalibrationMode.SELFTEST
                        mobjParameters.YaxisMin = const_YMinmVolt
                        mobjParameters.YaxisMax = const_YMaxmVolt
                        mYValueLable = const_Volt
                        mYAXIS_LABEL = const_Volt
                        mstrYaxisFormat = "0.0"
                End Select

                'addataSpect.intSpeed = 0
                'addataSpect.intMode = gobjInst.Mode



                mobjParameters.ScanSpeed = CONST_SLOWStep
                mobjParameters.Cal_Mode = gobjInst.Mode
                'addataSpect.blnPloted = True
                '//-----
                AASGraphTimeScan.AldysPane.Legend.IsVisible = False
                funcClearGraph()
                funcGraphPreRequisite(mobjParameters.Cal_Mode, _
                                        mobjParameters.XaxisMin, _
                                        mobjParameters.XaxisMax, _
                                        mobjParameters.YaxisMin, _
                                        mobjParameters.YaxisMax)

                blnSetDefaultSpectrumParameter = True
                funcSetDefaultSpectrumParameter = True
                gobjClsAAS203.Calculate_Analysis_Graph_Param(AASGraphTimeScan, ClsAAS203.enumChangeAxis.xyAxis)     'Added by Saurabh 03.08.07
            End If

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------
        End Try
    End Function

    Private Function funcSetSpectrumParameter(ByVal intCalibrationMode As Integer) As Boolean
        '=====================================================================
        ' Procedure Name        : funcSetDefaultSpectrumParameter
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : 
        ' Description           : Set Spectrum Parameter
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 21.11.06
        ' Revisions             : 
        '=====================================================================

        Try
            funcSetSpectrumParameter = False
            '//----- Set the default parameter to the spectrum.
            If (gobjInst.Mode = intCalibrationMode) Then
                funcSetSpectrumParameter = True
                Exit Function
            End If

            If gobjCommProtocol.funcCalibrationMode(intCalibrationMode) Then

                'If (gobjInst.Mode = EnumCalibrationMode.MABS) Or (gobjInst.Mode = EnumCalibrationMode.AA) Or (gobjInst.Mode = EnumCalibrationMode.AABGC) Or (gobjInst.Mode = EnumCalibrationMode.AABGCSR) Then
                '    nudD2Cur.Enabled = True
                'Else
                '    nudD2Cur.Enabled = False
                'End If
                'addataSpect.dblWvMin = 230.0
                'addataSpect.dblWvMax = 250.0

                Select Case gobjInst.Mode
                    Case EnumCalibrationMode.AA, EnumCalibrationMode.AABGC, EnumCalibrationMode.MABS

                        mobjParameters.YaxisMax = const_YMaxAbs
                        mobjParameters.YaxisMin = const_YMinAbs
                        mYValueLable = const_Absorbance
                        mstrYaxisFormat = "0.000"
                    Case EnumCalibrationMode.HCLE, EnumCalibrationMode.D2E
                        mobjParameters.YaxisMin = const_YMinEnergy
                        mobjParameters.YaxisMax = const_YMaxEnergy
                        mYValueLable = const_Energy
                        'mstrYaxisFormat = "0.00#"
                        mstrYaxisFormat = "0.0"
                    Case EnumCalibrationMode.EMISSION

                        mobjParameters.YaxisMin = const_YMinEmission
                        mobjParameters.YaxisMax = const_YMaxEmission
                        mYValueLable = const_Emission
                        mstrYaxisFormat = "0.0"
                    Case EnumCalibrationMode.SELFTEST
                        mobjParameters.YaxisMin = const_YMinmVolt
                        mobjParameters.YaxisMax = const_YMaxmVolt
                        mYValueLable = const_Volt
                        mstrYaxisFormat = "0.0"
                End Select

                mobjParameters.XaxisMin = 0
                mobjParameters.XaxisMax = 100

                'addataSpect.intSpeed = 0
                'addataSpect.intMode = gobjInst.Mode

                mobjParameters.Cal_Mode = gobjInst.Mode
                'addataSpect.blnPloted = True
                '//-----
                AASGraphTimeScan.AldysPane.Legend.IsVisible = False
                funcClearGraph()
                funcGraphPreRequisite(mobjParameters.Cal_Mode, _
                                        mobjParameters.XaxisMin, _
                                        mobjParameters.XaxisMax, _
                                        mobjParameters.YaxisMin, _
                                        mobjParameters.YaxisMax)

                funcSetSpectrumParameter = True

            End If

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------
        End Try
    End Function

    Private Function funcSetSpectrumParam(ByVal intCalibrationMode As Integer) As Boolean
        '=====================================================================
        ' Procedure Name        : funcSetDefaultSpectrumParameter
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : 
        ' Description           : Set Spectrum Parameter
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 21.11.06
        ' Revisions             : 
        '=====================================================================

        Try

            Dim dblMajorStepY, dblMinorStepY, dblDiffY As Double

            funcSetSpectrumParam = False
            '//----- Set the default parameter to the spectrum.
            If (gobjInst.Mode = intCalibrationMode) Then
                funcSetSpectrumParam = True
                Exit Function
            End If

            If gobjCommProtocol.funcCalibrationMode(intCalibrationMode) Then

                'addataSpect.dblWvMin = 230.0
                'addataSpect.dblWvMax = 250.0

                'Select Case gobjInst.Mode
                '    Case EnumCalibrationMode.AA, EnumCalibrationMode.AABGC, EnumCalibrationMode.MABS

                '        mobjParameters.YaxisMax = const_YMaxAbs
                '        mobjParameters.YaxisMin = const_YMinAbs
                '    Case EnumCalibrationMode.HCLE, EnumCalibrationMode.D2E
                '        mobjParameters.YaxisMin = const_YMinEnergy
                '        mobjParameters.YaxisMax = const_YMaxEnergy
                '    Case EnumCalibrationMode.EMISSION

                '        mobjParameters.YaxisMin = const_YMinEmission
                '        mobjParameters.YaxisMax = const_YMaxEmission

                '    Case EnumCalibrationMode.SELFTEST
                '        mobjParameters.YaxisMin = const_YMinmVolt
                '        mobjParameters.YaxisMax = const_YMaxmVolt
                'End Select

                'addataSpect.intSpeed = 0
                'addataSpect.intMode = gobjInst.Mode

                mobjParameters.Cal_Mode = gobjInst.Mode
                'addataSpect.blnPloted = True
                '//-----
                'AASGraphTimeScan.AldysPane.Legend.IsVisible = False
                'AASGraphTimeScan.AldysPane.AddCurve()
                Select Case gobjInst.Mode
                    Case EnumCalibrationMode.AA, EnumCalibrationMode.AABGC, EnumCalibrationMode.MABS

                        mobjParameters.YaxisMax = const_YMaxAbs
                        mobjParameters.YaxisMin = const_YMinAbs
                        'mYValueLable = const_Absorbance
                        mYValueLable = const_Absorbance
                        mYAXIS_LABEL = const_ABSORBANCE_YLabel
                        mstrYaxisFormat = "0.000"
                    Case EnumCalibrationMode.HCLE, EnumCalibrationMode.D2E
                        mobjParameters.YaxisMin = const_YMinEnergy
                        mobjParameters.YaxisMax = const_YMaxEnergy
                        mYValueLable = const_Energy
                        mYAXIS_LABEL = const_ENERGY_YLabel
                        'mstrYaxisFormat = "0.00#"
                        mstrYaxisFormat = "0.0"
                    Case EnumCalibrationMode.EMISSION
                        mobjParameters.YaxisMin = const_YMinEmission
                        mobjParameters.YaxisMax = const_YMaxEmission
                        mYValueLable = const_Emission
                        mYAXIS_LABEL = const_EMISSION_YLabel
                        mstrYaxisFormat = "0.0"
                    Case EnumCalibrationMode.SELFTEST
                        mobjParameters.YaxisMin = const_YMinmVolt
                        mobjParameters.YaxisMax = const_YMaxmVolt
                        mYValueLable = const_Volt
                        mYAXIS_LABEL = const_Volt
                        mstrYaxisFormat = "0.0"
                        If mblnIsShowDBeam = True Then

                        End If

                End Select


                'AASGraphTimeScan.AldysPane.XAxis.IsMinorTic = False
                'AASGraphTimeScan.AldysPane.YAxis.IsMinorTic = False

                AASGraphTimeScan.YAxisMin = mobjParameters.YaxisMin
                AASGraphTimeScan.YAxisMax = mobjParameters.YaxisMax

                '//----- Set auto Steps of axis
                dblDiffY = (mobjParameters.YaxisMax - mobjParameters.YaxisMin)
                dblMajorStepY = dblDiffY / 10
                dblMinorStepY = dblMajorStepY / 2

                AASGraphTimeScan.YAxisStep = dblMajorStepY
                AASGraphTimeScan.YAxisMinorStep = dblMinorStepY
                AASGraphTimeScan.YAxisLabel = mYAXIS_LABEL

                '//-----
                AASGraphTimeScan.AldysPane.AxisChange()
                AASGraphTimeScan.Refresh()

                '---following condition is added by deepak on 20.07.07
                If gstructSettings.IsCustomerDisplayMode = False Then
                    'lblYValue.Text = "Sample " & mYValueLable & ": "
                    lblYValue.Text = mYValueLable & ": "
                End If

                lblYValue_Ref.Text = "Ref " & mYValueLable & ": "
                lblYValue_Double.Text = "Double " & mYValueLable & ": "
                lblYValue.Refresh()
                lblYValue_Ref.Refresh()
                lblYValue_Double.Refresh()
                Call funcOnlineGraphPrereq()
                Application.DoEvents()

                funcGraphPreRequisite(mobjParameters.Cal_Mode, _
                                        mobjParameters.XaxisMin, _
                                        mobjParameters.XaxisMax, _
                                        mobjParameters.YaxisMin, _
                                        mobjParameters.YaxisMax)

                funcSetSpectrumParam = True

            End If

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Function

    Private Function funcSetDefaultParameter() As Boolean
        '=====================================================================
        ' Procedure Name        : funcSetDefaultParameter
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : 
        ' Description           : Set Spectrum Parameter
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 19.12.06
        ' Revisions             : 
        '=====================================================================
        Dim intMaxD2Current As Integer
        Dim intMinD2Current As Integer
        Dim intSelectedModeType As Integer
        Try
            '/---------------------------------------------------------------
            'ReinitInstParameters();
            '			 Inst =  GetInstData();
            '#If !IN203DLL Then
            '			Get_Instrument_Parameters(&Inst);
            '#End If
            '			ps.hdc=NULL;
            '			hfont = Change_Button_font(hwnd, hfont, TRUE, FALSE);
            '			InitAbsScreen(hwnd);
            '			Scroll_Pmt(hwnd,IDC_PMT, -1);
            '			if (Inst->Mode==AA || Inst->Mode ==HCLE || Inst->Mode==AABGC ||Inst->Mode==AABGCSR)
            '				Scroll_Cur(hwnd,IDC_CUR, -1 );
            '            Else
            '				EnableWindow(GetDlgItem(hwnd,IDC_CUR),FALSE);
            '			if (Inst->Mode==MABS || Inst->Mode==AA || Inst->Mode==AABGC ||Inst->Mode==AABGCSR)
            '				Scroll_D2Cur(hwnd,IDC_D2CUR, -1 );
            '                Else
            '				EnableWindow(GetDlgItem(hwnd,IDC_D2CUR),FALSE);

            '			Scroll_Slit(hwnd,IDC_SLIT, -1 );
            '			Scroll_Mode(hwnd,IDC_MODE, -1 );
            '			Scroll_Fuel(hwnd,IDC_FUEL, -1 );
            '			Scroll_Bh(hwnd,IDC_BH, -1 );
            '			for(nsel =IDC_PMTVS; nsel<=IDC_BHVS; nsel++)
            '			  SetScrollRange(GetDlgItem(hwnd, nsel), SB_CTL, 0, 1,TRUE);
            '/*
            '                        If (GetSRLamp()) Then
            '			  SetWindowText(GetDlgItem(hwnd,IDC_D2CUR),"SRE:100 mA");
            '                        Else
            '			  SetWindowText(GetDlgItem(hwnd,IDC_D2CUR),"D2E:100 mA");
            '*/
            '			// mdf by sss on dt 5/12/1999 for maual D2 gain setting
            '			if(GetInstrument() != AA202 ){
            '				if(ReadIniForD2Gain()){
            '                                    If (IsD2GainOn()) Then
            '						SetWindowText(GetDlgItem(hwnd,IDC_PBD2GAIN),"D2 Gain OFF");
            '                                    Else
            '						SetWindowText(GetDlgItem(hwnd,IDC_PBD2GAIN),"D2 Gain ON");
            '				}
            '				else
            '					ShowWindow(GetDlgItem(hwnd,IDC_PBD2GAIN),SW_HIDE);
            '			}
            '			ShowWindow(hwnd,SW_SHOWMAXIMIZED);
            '//			SendMessage(hwnd,WM_SHOWWINDOW,WS_MAXIMIZE,0L);
            '			//-----
            '			ReinitInstParameters();
            '			//--mdf by sk on 3/6/2001
            '			CheckMinAbsScanLmt = ReadIniForMinAbsLimit();
            '         Absscanthldval = ReadIniForAbsThresholdLimit();
            '			//--mdf by sk on 3/6/2001
            '			return TRUE;
            '/--------------------------------------------------------------------

            funcSetDefaultParameter = False
            '//----- 
            '   Ini the Time scan Parameter
            'ReinitInstParameters();
            Call gobjClsAAS203.ReInitInstParameters()
            '//--------
            '/----- Set the Form object parameter
            '//----- Set the default parameter to the spectrum.

            'mobjParameters.Cal_Mode = gobjInst.Mode
            If gintInstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.DoubleBeam Then
                Select Case gobjInst.Mode
                    Case EnumCalibrationMode.AA
                        intSelectedModeType = 0
                    Case EnumCalibrationMode.AABGC
                        intSelectedModeType = 1
                    Case EnumCalibrationMode.SELFTEST
                        intSelectedModeType = 2
                End Select
            Else
                intSelectedModeType = gobjInst.Mode
            End If
            cmbModes.SelectedIndex = gobjInst.Mode
            'cmbModes.SelectedIndex = intSelectedModeType

            'mobjParameters.ScanSpeed = CONST_SLOWStep


            '//----- Set PMT Object
            'Scroll_Pmt(hwnd,IDC_PMT, -1);
            'nudPMT.DecimalPlaces = 0
            nudPMT.DecimalPlace = 0
            'nudPMT.Increment = 5.0
            nudPMT.ChangeFactor = 5.0
            nudPMT.MaxValue = 700.0
            nudPMT.MinValue = 0.0

            nudPMT.Value = gobjInst.PmtVoltage
            mobjParameters.PMTV = gobjInst.PmtVoltage
            If Not (gintInstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.SingleBeam) Then
                nudPMT_Ref.Enabled = True
            Else
                nudPMT_Ref.Enabled = False
            End If
            nudPMT_Ref.DecimalPlace = 0
            'nudPMT.Increment = 5.0
            nudPMT_Ref.ChangeFactor = 5.0
            nudPMT_Ref.MaxValue = 700.0
            nudPMT_Ref.MinValue = 0.0

            '---added by deepak on 02.08.07 to make the ref pmt equal to samp pmt in aa mode
            If gintInstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.DoubleBeam Then
                If gobjInst.PmtVoltageReference = 0 Then
                    Call funcSetPmtVParameter_Ref(gobjInst.PmtVoltage)
                    'gobjInst.PmtVoltageReference = gobjInst.PmtVoltage
                End If
            End If
            '---
            If (gobjInst.PmtVoltage <= 700) Then 'added by Pankaj for setting reference pmt zero if pmt is maximum on 30 Nov 07
                nudPMT_Ref.Value = gobjInst.PmtVoltageReference
            End If
            mobjParameters.PMTV_Ref = gobjInst.PmtVoltageReference

            '//-----
            '         if (Inst->Mode==AA || Inst->Mode ==HCLE || Inst->Mode==AABGC ||Inst->Mode==AABGCSR)
            '	Scroll_Cur(hwnd,IDC_CUR, -1 );
            '         Else
            '	EnableWindow(GetDlgItem(hwnd,IDC_CUR),FALSE);





            '//----- Set D2 current Object
            If gobjCommProtocol.SRLamp Then
                intMaxD2Current = 600
                intMinD2Current = 100
            Else
                intMaxD2Current = 300
                intMinD2Current = 100
            End If

            'nudD2Cur.DecimalPlaces = 0
            'nudD2Cur.Increment = 1
            'nudD2Cur.Maximum = intMaxD2Current
            'nudD2Cur.Minimum = intMinD2Current

            nudD2Cur.DecimalPlace = 0
            nudD2Cur.ChangeFactor = 1
            nudD2Cur.MaxValue = intMaxD2Current
            nudD2Cur.MinValue = intMinD2Current

            nudD2Cur.Value = gobjInst.D2Current
            If nudD2Cur.Value = 100.0 Then
                nudD2Cur.Text = "D2 Off"
            End If
            mobjParameters.D2Curr = gobjInst.D2Current

            'if (Inst->Mode==MABS || Inst->Mode==AA || Inst->Mode==AABGC ||Inst->Mode==AABGCSR)
            '	Scroll_D2Cur(hwnd,IDC_D2CUR, -1 );
            '             Else
            '	EnableWindow(GetDlgItem(hwnd,IDC_D2CUR),FALSE);
            'Select Case gobjInst.Mode
            '    Case EnumCalibrationMode.AA, EnumCalibrationMode.AABGCSR, EnumCalibrationMode.AABGC
            '        nudD2Cur.Enabled = True
            '        nudHCLCur.Enabled = True
            '    Case EnumCalibrationMode.HCLE
            '        nudD2Cur.Enabled = False
            '        nudHCLCur.Enabled = True

            '        case EnumCalibrationMode.
            '    Case EnumCalibrationMode.SELFTEST

            'End Select
            'If (gobjInst.Mode = EnumCalibrationMode.MABS) Or (gobjInst.Mode = EnumCalibrationMode.AA) Or (gobjInst.Mode = EnumCalibrationMode.AABGC) Or (gobjInst.Mode = EnumCalibrationMode.AABGCSR) Then
            '    nudD2Cur.Enabled = True
            'Else
            '    nudD2Cur.Enabled = False
            'End If



            '//-----

            '//----- Set Fuel Ratio object
            'nudFuelRatio.DecimalPlaces = 2
            'nudFuelRatio.Increment = 0.1
            'nudFuelRatio.Maximum = 25.0
            'nudFuelRatio.Minimum = 0.0

            nudFuelRatio.DecimalPlace = 2
            nudFuelRatio.ChangeFactor = 0.1
            nudFuelRatio.MaxValue = 25.0
            nudFuelRatio.MinValue = 0.0

            'Call gobjCommProtocol.funcGet_NV_Pos()
            mdblFuelRatio = gobjClsAAS203.funcGet_Fuel_Ratio(True)

            If mdblFuelRatio < 0.0 Then
                mdblFuelRatio = 0.0
            Else
                mdblFuelRatio = Format(mdblFuelRatio, "#0.00")
            End If
            nudFuelRatio.Value = mdblFuelRatio
            mobjParameters.FualRatio = mdblFuelRatio
            '//-----

            '//----- Set HCL Current Object
            'nudHCLCur.DecimalPlaces = 1
            'nudHCLCur.Increment = 0.1
            'nudHCLCur.Maximum = 25.0
            'nudHCLCur.Minimum = 0.0

            nudHCLCur.DecimalPlace = 1
            nudHCLCur.ChangeFactor = 0.1
            nudHCLCur.MaxValue = 25.0
            nudHCLCur.MinValue = 0.0
            nudHCLCur.Value = gobjInst.Current
            mobjParameters.HCLCurr = gobjInst.Current
            '//-----

            'Commented by Saurabh 05.08.07
            'If (gobjInst.Mode = EnumCalibrationMode.AA) Or (gobjInst.Mode = EnumCalibrationMode.HCLE) Or (gobjInst.Mode = EnumCalibrationMode.AABGC) Or (gobjInst.Mode = EnumCalibrationMode.AABGCSR) Then
            '    nudHCLCur.Enabled = True
            'Else
            '    nudHCLCur.Enabled = False
            'End If
            'Commented by Saurabh 05.08.07

            '//----- Set Burner Height Object
            'nudBurnerHeight.DecimalPlaces = 2
            'nudBurnerHeight.Increment = 0.1
            ''nudBurnerHeight.Maximum = 2.0
            'nudBurnerHeight.Maximum = 6.0
            'nudBurnerHeight.Minimum = 0.0

            nudBurnerHeight.DecimalPlace = 2
            nudBurnerHeight.ChangeFactor = 0.1
            nudBurnerHeight.MaxValue = 6.0
            nudBurnerHeight.MinValue = 0.0
            mdblBhHeight = gobjClsAAS203.funcReadBurnerHeight()
            nudBurnerHeight.Value = gobjClsAAS203.funcReadBurnerHeight()
            mobjParameters.BurnerHeight = CDbl(nudBurnerHeight.Value)
            '//-----

            '//----- Set Slit width Object
            'nudSlit.DecimalPlaces = 1
            'nudSlit.Increment = 0.1
            'nudSlit.Maximum = 2.0
            'nudSlit.Minimum = 0.0
            nudSlit.DecimalPlace = 1
            nudSlit.ChangeFactor = 0.1
            nudSlit.MaxValue = 2.0
            nudSlit.MinValue = 0.0
            nudSlit.Value = gobjClsAAS203.funcGet_SlitWidth()
            mobjParameters.SlitWidth = CDbl(nudSlit.Value)

            nudSlit_Exit.DecimalPlace = 1
            nudSlit_Exit.ChangeFactor = 0.1
            nudSlit_Exit.MaxValue = 2.0
            nudSlit_Exit.MinValue = 0.0
            nudSlit_Exit.Value = gobjClsAAS203.funcGet_SlitWidth(1)
            mobjParameters.SlitWidthRef = CDbl(nudSlit_Exit.Value)

            '//-----
            '        if(ReadIniForD2Gain()){
            '            If (IsD2GainOn()) Then
            '		SetWindowText(GetDlgItem(hwnd,IDC_PBD2GAIN),"D2 Gain OFF");
            '            Else
            '		SetWindowText(GetDlgItem(hwnd,IDC_PBD2GAIN),"D2 Gain ON");
            '}
            If gstructSettings.D2Gain = True Then
                cmdD2GainStatus.Visible = True
                If gobjCommProtocol.funcIsD2GainOn = &H1 Then
                    cmdD2GainStatus.Text = "D2 Gain On"
                ElseIf gobjCommProtocol.funcIsD2GainOn = &H0 Then
                    cmdD2GainStatus.Text = "D2 Gain Off"
                End If
            Else
                cmdD2GainStatus.Visible = False
            End If
            '//-----
            'mobjParameters.Cal_Mode = gobjInst.Mode
            'cmbModes.SelectedIndex = gobjInst.Mode

            'mobjParameters.ScanSpeed = CONST_SLOWStep
            '//-----

            Call gobjClsAAS203.ReInitInstParameters()

            blnCheckMinAbsScanLmt = gstructSettings.SetMinAbsLimit
            dblAbsScanthldval = gstructSettings.AbsThresholdValue

            funcSetDefaultParameter = True

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            Return False
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------
        End Try
    End Function

    Private Function funcSetPmtVParameter(ByVal dblPmtV As Double) As Boolean
        '=====================================================================
        ' Procedure Name        : funcSetPmtVParameter
        ' Parameters Passed     : dblPmtV 
        ' Returns               : Boolean
        ' Purpose               : 
        ' Description           : Set Pmt Volt Parameter
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 22.11.06
        ' Revisions             : 
        '=====================================================================
        Dim dblPMTVolt As Double
        Dim dblAdjPMTVolt As Double

        Try
            funcSetPmtVParameter = False
            gblnSpectrumWait = True
            dblPMTVolt = gobjInst.PmtVoltage
            gobjCommProtocol.mobjCommdll.subTime_Delay(50)
            If Not dblPmtV = dblPMTVolt Then

                If dblPmtV > dblPMTVolt Then

                    'dblPMTVolt += 5.0
                    dblAdjPMTVolt = dblPmtV - Math.Abs(dblPMTVolt)
                    If dblAdjPMTVolt > 0 Then
                        dblPMTVolt += dblAdjPMTVolt
                    End If
                ElseIf dblPmtV < dblPMTVolt Then
                    'dblPMTVolt -= 5.0
                    dblAdjPMTVolt = dblPMTVolt - dblPmtV
                    If dblAdjPMTVolt > 0 Then
                        dblPMTVolt -= dblAdjPMTVolt
                    End If

                End If

                If dblPMTVolt > 700 Then
                    dblPMTVolt = 0.0
                ElseIf dblPMTVolt < 0.0 Then
                    dblPMTVolt = 0.0
                End If
                If gobjCommProtocol.funcSet_PMT(dblPMTVolt) = True Then
                    'gobjInst.PmtVoltage = dblPMTVolt
                    funcSetPmtVParameter = True
                End If
                'funcSetPmtVParameter = True
            End If
            gobjCommProtocol.mobjCommdll.subTime_Delay(50)
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            gblnSpectrumWait = False
            '---------------------------------------------------------
        End Try
    End Function

    Private Function funcSetPmtVParameter_Ref(ByVal dblPmtV As Double) As Boolean
        '=====================================================================
        ' Procedure Name        : funcSetPmtVParameter
        ' Parameters Passed     : dblPmtV 
        ' Returns               : Boolean
        ' Purpose               : 
        ' Description           : Set Pmt Volt Parameter
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 22.11.06
        ' Revisions             : 
        '=====================================================================
        Dim dblPMTVolt As Double
        Dim dblAdjPMTVolt As Double

        Try
            funcSetPmtVParameter_Ref = False
            gblnSpectrumWait = True
            dblPMTVolt = gobjInst.PmtVoltageReference
            gobjCommProtocol.mobjCommdll.subTime_Delay(50)
            If Not dblPmtV = dblPMTVolt Then

                If dblPmtV > dblPMTVolt Then

                    'dblPMTVolt += 5.0
                    dblAdjPMTVolt = dblPmtV - Math.Abs(dblPMTVolt)
                    If dblAdjPMTVolt > 0 Then
                        dblPMTVolt += dblAdjPMTVolt
                    End If
                ElseIf dblPmtV < dblPMTVolt Then
                    'dblPMTVolt -= 5.0
                    dblAdjPMTVolt = dblPMTVolt - dblPmtV
                    If dblAdjPMTVolt > 0 Then
                        dblPMTVolt -= dblAdjPMTVolt
                    End If

                End If

                If dblPMTVolt > 700 Then
                    dblPMTVolt = 0.0
                ElseIf dblPMTVolt < 0.0 Then
                    dblPMTVolt = 0.0
                End If
                If gobjCommProtocol.funcSet_PMTReferenceBeam(dblPMTVolt) = True Then
                    'gobjInst.PmtVoltage = dblPMTVolt
                    funcSetPmtVParameter_Ref = True
                End If
                'funcSetPmtVParameter = True
            End If
            gobjCommProtocol.mobjCommdll.subTime_Delay(50)
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            gblnSpectrumWait = False
            '---------------------------------------------------------
        End Try
    End Function

    Private Function funcSetHCL_CurParameter(ByVal dblHCL_Cur As Double) As Boolean
        '=====================================================================
        ' Procedure Name        : funcSetHCL_CurParameter
        ' Parameters Passed     : dblHCL_Cur
        ' Returns               : Boolean
        ' Purpose               : 
        ' Description           : Set HCL Current Parameter
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 22.11.06
        ' Revisions             : 
        '=====================================================================
        Dim dblLampCurrent As Double

        Try
            funcSetHCL_CurParameter = False
            gblnSpectrumWait = True
            gobjCommProtocol.mobjCommdll.subTime_Delay(50)
            If gobjInst.Lamp_Position >= 1 And gobjInst.Lamp_Position <= gobjClsAAS203.funcGetMaxLamp() Then
                dblLampCurrent = gobjInst.Current
                'dblHCL_Cur()
                dblLampCurrent = dblHCL_Cur
                If dblHCL_Cur > 25 Then dblLampCurrent = 25
                If dblHCL_Cur < 0 Then dblLampCurrent = 0
                gobjCommProtocol.funcSet_HCL_Cur(dblLampCurrent, gobjInst.Lamp_Position)
                gobjInst.Current = dblLampCurrent
            End If
            gobjCommProtocol.mobjCommdll.subTime_Delay(50)
            funcSetHCL_CurParameter = True
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            gblnSpectrumWait = False
            '---------------------------------------------------------
        End Try
    End Function

    Private Function funcSetD2_CurParameter(ByVal intD2_Cur As Integer) As Boolean
        '=====================================================================
        ' Procedure Name        : funcSetPmtVParameter
        ' Parameters Passed     : dblD2_Cur
        ' Returns               : Boolean
        ' Purpose               : 
        ' Description           : Set D2 Current Parameter
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 22.11.06
        ' Revisions             : 
        '=====================================================================

        Dim intMaxD2Current = 300
        Dim intMinD2Current = 100
        Dim D2CurrIncrDecr As Integer
        Dim intD2Lamp_Cur As Double = 0

        Try
            funcSetD2_CurParameter = False
            gblnSpectrumWait = True
            gobjCommProtocol.mobjCommdll.subTime_Delay(50)
            If gobjCommProtocol.SRLamp Then
                intMaxD2Current = 600
                intMinD2Current = 100
            Else
                intMaxD2Current = 300
                intMinD2Current = 100
            End If

            intD2Lamp_Cur = gobjInst.D2Current

            If intD2Lamp_Cur < intD2_Cur Then

                'intD2Lamp_Cur += 1
                D2CurrIncrDecr = intD2_Cur - intD2Lamp_Cur
            End If

            If intD2Lamp_Cur > intD2_Cur Then
                'intD2Lamp_Cur -= 1
                D2CurrIncrDecr = intD2_Cur - intD2Lamp_Cur
            End If

            If (intD2_Cur < intMinD2Current) Then intD2_Cur = intMaxD2Current
            If (intD2_Cur > intMaxD2Current) Then intD2_Cur = intMinD2Current

            '//----- Set the D2 current to the Instrument
            gobjCommProtocol.funcSetD2Cur(intD2_Cur)

            If gobjCommProtocol.SRLamp Then
                gobjInst.D2Current = intD2Lamp_Cur
            Else
                If intD2Lamp_Cur = 100 Then

                End If
            End If
            gobjCommProtocol.mobjCommdll.subTime_Delay(50)
            funcSetD2_CurParameter = True
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            gblnSpectrumWait = False
            '---------------------------------------------------------
        End Try
    End Function

    Private Function funcSetSlit_WidthParameter(ByVal dblSlit_WidthIn As Double) As Boolean
        '=====================================================================
        ' Procedure Name        : funcSetSlit_WidthParameter
        ' Parameters Passed     : dblSlit_Width
        ' Returns               : Boolean
        ' Purpose               : 
        ' Description           : Set Slit Width Parameter
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 22.11.06
        ' Revisions             : 
        '=====================================================================
        Dim dblSlitWidth As Double
        Dim dblAdjSlitWidth As Double

        Try
            funcSetSlit_WidthParameter = False
            gblnSpectrumWait = True
            gobjCommProtocol.mobjCommdll.subTime_Delay(50)
            dblSlitWidth = gobjClsAAS203.funcGet_SlitWidth()

            If dblSlit_WidthIn > dblSlitWidth Then
                dblAdjSlitWidth = dblSlit_WidthIn - dblSlitWidth
                If dblAdjSlitWidth > 0 Then
                    dblSlitWidth += dblAdjSlitWidth
                End If
                'dblSlitWidth += 0.1

            End If

            If dblSlit_WidthIn < dblSlitWidth Then
                dblAdjSlitWidth = dblSlitWidth - dblSlit_WidthIn
                If dblAdjSlitWidth > 0 Then
                    dblSlitWidth -= dblAdjSlitWidth
                End If
                'dblSlitWidth -= 0.1
            End If

            If dblSlit_WidthIn < 0 Then dblSlitWidth = 2.0
            If dblSlit_WidthIn > 2 Then dblSlitWidth = 0.0

            Call gobjCommProtocol.funcSet_SlitWidth(dblSlitWidth, 0)
            gobjCommProtocol.mobjCommdll.subTime_Delay(50)
            funcSetSlit_WidthParameter = True

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            Return False
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            gblnSpectrumWait = False
            '---------------------------------------------------------
        End Try
    End Function

    Private Function funcSetSlit_WidthParameter_Exit(ByVal dblSlit_WidthIn As Double) As Boolean
        '=====================================================================
        ' Procedure Name        : funcSetSlit_WidthParameter
        ' Parameters Passed     : dblSlit_Width
        ' Returns               : Boolean
        ' Purpose               : 
        ' Description           : Set Slit Width Parameter
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 22.11.06
        ' Revisions             : 
        '=====================================================================
        Dim dblSlitWidth As Double
        Dim dblAdjSlitWidth As Double

        Try
            funcSetSlit_WidthParameter_Exit = False
            gblnSpectrumWait = True
            gobjCommProtocol.mobjCommdll.subTime_Delay(50)
            dblSlitWidth = gobjClsAAS203.funcGet_SlitWidth(1)   '1 For Exit slit

            If dblSlit_WidthIn > dblSlitWidth Then
                dblAdjSlitWidth = dblSlit_WidthIn - dblSlitWidth
                If dblAdjSlitWidth > 0 Then
                    dblSlitWidth += dblAdjSlitWidth
                End If
                'dblSlitWidth += 0.1

            End If

            If dblSlit_WidthIn < dblSlitWidth Then
                dblAdjSlitWidth = dblSlitWidth - dblSlit_WidthIn
                If dblAdjSlitWidth > 0 Then
                    dblSlitWidth -= dblAdjSlitWidth
                End If
                'dblSlitWidth -= 0.1
            End If

            If dblSlit_WidthIn < 0 Then dblSlitWidth = 2.0
            If dblSlit_WidthIn > 2 Then dblSlitWidth = 0.0

            Call gobjCommProtocol.funcSet_SlitWidth(dblSlitWidth, 1)
            gobjCommProtocol.mobjCommdll.subTime_Delay(50)
            funcSetSlit_WidthParameter_Exit = True
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            Return False
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            gblnSpectrumWait = False
            '---------------------------------------------------------
        End Try
    End Function

    Private Function funcSetFuelParameter(ByVal dblFuel As Double) As Double
        '=====================================================================
        ' Procedure Name        : funcSetFuelParameter
        ' Parameters Passed     : dblFuel 
        ' Returns               : Double
        ' Purpose               : 
        ' Description           : Set Fuel Parameter
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 22.11.06
        ' Revisions             : 
        '=====================================================================
        Try
            funcSetFuelParameter = False
            gobjCommProtocol.mobjCommdll.subTime_Delay(50)
            If Not (mdblFuelRatio = dblFuel) Then

                Call gobjClsAAS203.funcSetFuel(CDbl(nudFuelRatio.Value))
            End If

            'Call gobjCommProtocol.funcGet_NV_Pos()
            mdblFuelRatio = gobjClsAAS203.funcGet_Fuel_Ratio(True)
            If mdblFuelRatio < 0.0 Then
                mdblFuelRatio = 0.0
            Else
                mdblFuelRatio = Format(mdblFuelRatio, "#0.00")
            End If
            mobjParameters.FualRatio = mdblFuelRatio
            'mdblFuelRatio = Format(mdblFuelRatio, "#0.00")
            funcSetFuelParameter = mdblFuelRatio
            gobjCommProtocol.mobjCommdll.subTime_Delay(50)
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            Return 0.0
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------
        End Try
    End Function

    'Private Function funcSetFuelParameter(ByVal dblFuel As Double) As Double
    '    '=====================================================================
    '    ' Procedure Name        : funcSetFuelParameter
    '    ' Parameters Passed     : dblFuel 
    '    ' Returns               : Double
    '    ' Purpose               : 
    '    ' Description           : Set Fuel Parameter
    '    ' Assumptions           : 
    '    ' Dependencies          : 
    '    ' Author                : Sachin Dokhale
    '    ' Created               : 22.11.06
    '    ' Revisions             : 
    '    '=====================================================================
    '    Dim dblAdjFuelRatio As Double
    '    Dim intIncrDecr As Integer
    '    Try
    '        funcSetFuelParameter = False
    '        Application.DoEvents()
    '        If Not (mdblFuelRatio = dblFuel) Then
    '            If mdblFuelRatio > dblFuel Then
    '                dblAdjFuelRatio = mdblFuelRatio - dblFuel
    '                If dblAdjFuelRatio > 0 Then
    '                    For intIncrDecr = 0 To CInt(dblAdjFuelRatio) - 1
    '                        Call gobjClsAAS203.funcIncr_Fuel()
    '                    Next

    '                End If
    '                '        dblFuelRatio = funcSetFuelParameter(-1)
    '                mdblFuelRatio = Format(mdblFuelRatio, "#.00")
    '                'nudFuelRatio.Value = Format(mdblFuelRatio, "#.00")
    '            ElseIf mdblFuelRatio < dblFuel Then
    '                dblAdjFuelRatio = dblFuel - mdblFuelRatio
    '                If dblAdjFuelRatio > 0 Then
    '                    For intIncrDecr = 0 To CInt(dblAdjFuelRatio) - 1
    '                        Call gobjClsAAS203.funcDecr_Fuel()
    '                    Next
    '                End If
    '                'dblFuelRatio = funcSetFuelParameter(1)
    '                mdblFuelRatio = Format(mdblFuelRatio, "#.00")
    '                'nudFuelRatio.Value = Format(mdblFuelRatio, "#.00")
    '            Else
    '                Call gobjCommProtocol.funcGet_NV_Pos()
    '            End If
    '        Else
    '            Call gobjCommProtocol.funcGet_NV_Pos()
    '        End If

    '        'If intFuel = 1 Then
    '        '    Call gobjClsAAS203.funcIncr_Fuel()
    '        'ElseIf intFuel = -1 Then
    '        '    Call gobjClsAAS203.funcDecr_Fuel()
    '        'Else
    '        '    Call gobjCommProtocol.funcGet_NV_Pos()
    '        'End If

    '        funcSetFuelParameter = gobjClsAAS203.funcGet_Fuel_Ratio(False)
    '        funcSetFuelParameter = mdblFuelRatio

    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        'Error Handling and logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = ex.Message
    '        gobjErrorHandler.WriteErrorLog(ex)
    '        Return 0.0
    '        '---------------------------------------------------------
    '    Finally
    '        '---------------------------------------------------------
    '        'Writing Execution log
    '        If CONST_CREATE_EXECUTION_LOG = 1 Then
    '            gobjErrorHandler.WriteExecutionLog()
    '        End If
    '        gblnSpectrumWait = False
    '        '---------------------------------------------------------
    '    End Try
    'End Function

    Private Function funcSetBurner_HeightParameter(ByVal dblBurner_Height As Double) As Double
        '=====================================================================
        ' Procedure Name        : funcSetBurner_HeightParameter
        ' Parameters Passed     : dblBurner_Height 
        ' Returns               : Double
        ' Purpose               : 
        ' Description           : Set Burner Height Parameter
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 22.11.06
        ' Revisions             : 
        '=====================================================================
        Dim dblBurnerHeight As Double
        Try
            mobjclsBgSpectrum.SpectrumWait = True
            funcSetBurner_HeightParameter = 0.0
            'If dblBhHeight > intBurner_Height Then
            '    'dblBhHeight = funcSetBurner_HeightParameter(-1)

            '    dblBhHeight = Format(intBurner_Height, "#.00")
            '    nudBurnerHeight.Value = Format(intBurner_Height, "#.00")
            'ElseIf dblBhHeight < nudBurnerHeight.Value Then
            '    dblBhHeight = funcSetBurner_HeightParameter(1)
            '    dblBhHeight = Format(dblBhHeight, "#.00")
            '    nudBurnerHeight.Value = Format(dblBhHeight, "#.00")
            'End If

            'If intBurner_Height = 1 Then
            '    Call gobjClsAAS203.funcIncr_Height()
            'ElseIf intBurner_Height = -1 Then
            '    Call gobjClsAAS203.funcDecr_Height()
            'Else
            '    gobjCommProtocol.func_Get_BH_Pos()
            'End If
            gobjCommProtocol.mobjCommdll.subTime_Delay(50)
            gobjClsAAS203.funcSetBHPos(FormatNumber(dblBurner_Height, 1))
            mdblBhHeight = gobjClsAAS203.funcReadBurnerHeight()
            funcSetBurner_HeightParameter = mdblBhHeight
            gobjCommProtocol.mobjCommdll.subTime_Delay(50)
            mobjclsBgSpectrum.SpectrumWait = False

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            gblnSpectrumWait = False
            '---------------------------------------------------------
        End Try
    End Function

    Private Sub subD2GainSatus()
        '=====================================================================
        ' Procedure Name        :   subD2GainSatus
        ' Description           :   
        ' Purpose               :   
        '                           
        ' Parameters Passed     :   None
        ' Returns               :   None
        ' Parameters Affected   :   
        ' Assumptions           :   
        ' Dependencies          :   None.
        ' Author                :   Sachin Dokhale 
        ' Created               :   10.12.06
        ' Revisions             :
        '=====================================================================
        Try
            gblnSpectrumWait = True
            If gstructSettings.D2Gain = True Then
                If gobjCommProtocol.funcIsD2GainOn = &H1 Then
                    If gobjCommProtocol.funcGain10X_OFF = True Then
                        cmdD2GainStatus.Text = "D2 &Gain On"
                    End If

                ElseIf gobjCommProtocol.funcIsD2GainOn = &H0 Then
                    If gobjCommProtocol.funcGain10X_ON = True Then
                        cmdD2GainStatus.Text = "D2 &Gain Off"
                    End If
                End If
            End If
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            gblnSpectrumWait = False
            '---------------------------------------------------------
        End Try
    End Sub

    Private Function FuncIncrDecrFuel(ByVal dblFuelRatio As Double) As Boolean
        '=====================================================================
        ' Procedure Name        :   FuncIncrDecrFuel
        ' Description           :   To call the function according to value 
        '                           editor button clicked
        ' Purpose               :   
        ' Parameters Passed     :   
        ' Returns               :   
        ' Parameters Affected   :   
        ' Assumptions           :   
        ' Dependencies          :   None.
        ' Author                :   Deepak Bhati
        ' Created               :   03.02.08
        ' Revisions             :
        '=====================================================================
        Dim intNVStep As Integer
        Try
            If Not (mdblFuelRatio = dblFuelRatio) Then
                If gobjInst.Aaf = True Or gobjInst.N2of = True Then

                    Select Case nudFuelRatio.ButtonClicked
                        Case ValueEditor.ValueEditor.EnumValueEditorButtons.MainButton
                            Call gobjClsAAS203.funcSetFuel(CDbl(nudFuelRatio.Value))
                        Case ValueEditor.ValueEditor.EnumValueEditorButtons.UpButton
                            '---to increase fuel
                            gobjClsAAS203.funcIncr_Fuel()
                        Case ValueEditor.ValueEditor.EnumValueEditorButtons.DownButton
                            '---to decrease fuel
                            gobjClsAAS203.funcDecr_Fuel()
                    End Select

                End If
            End If

            mdblFuelRatio = gobjClsAAS203.funcGet_Fuel_Ratio(True)
            If mdblFuelRatio < 0.0 Then
                mdblFuelRatio = 0.0
            Else
                mdblFuelRatio = Format(mdblFuelRatio, "#0.00")
            End If
            nudFuelRatio.Value = mdblFuelRatio
            mobjParameters.FualRatio = mdblFuelRatio
            nudFuelRatio.Refresh()

            Return True
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            Return False
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------
        End Try
    End Function

    Public Function funcOnSpect(ByVal BaseLine As Boolean, ByRef lblScanStatus As System.Object, _
                ByRef lblOnlineWv As System.Object) As Boolean
        mblnAvoidProcessing = True

        '//----- Orig
        'addata.counter = 0;
        ' if (addata.speed==0){
        'if (GetInstrument()==AA202) addata.speed=FASTSTEP_AA202;
        'else addata.speed=FAST;
        ' }
        ' speed = addata.speed;
        '/-----
        'addataSpect.intCounter = 0
        'If (addataSpect.intSpeed = 0) Then
        '    addataSpect.intSpeed = CONST_STEPS_PER_NM
        'End If



        'Dim ObjParameter As New Spectrum.EnergySpectrumParameter
        mobjOnlineChannel = New Spectrum.Channel(True)

        'ObjParameter = funcCloneParameter(mobjParameters)
        'mobjOnlineChannel.EnegryParameter = ObjParameter
        mobjOnlineChannel.EnegryParameter = mobjSpectrum.funcCloneESParameter(mobjParameters)

        'ObjParameter = Nothing

        If Not funcGraphPreRequisite(mobjParameters.Cal_Mode, _
                                    mobjParameters.XaxisMin, _
                                    mobjParameters.XaxisMax, _
                                    mobjParameters.YaxisMin, _
                                    mobjParameters.YaxisMax) Then
            'Call gFuncShowMessage("Error in setting spectrum parameters", "Please Check Entered Spectrum Parameters", modConstants.EnumMessageType.Information)
            Exit Function
        End If

        mobjOnlineReadings = New Spectrum.Readings

        mblnSpectrumStarted = True

        '--- Start the Spectrum analysis
        'mobjController.Start(New clsBgSpectrum(lblWvPos, lblOnlineWv, _
        '              mobjParameters.XaxisMax, _
        '              mobjParameters.XaxisMin, _
        '              mobjParameters.YaxisMax, _
        '              mobjParameters.YaxisMin, _
        '              mobjParameters.Cal_Mode, _
        '              mobjParameters.ScanSpeed, _
        '              dblAbsScanthldval, blnCheckMinAbsScanLmt))

        mobjController = New clsBgThread(Me)
        mobjclsBgSpectrum = New clsBgSpectrum(lblTime, lblOnlineWv, _
                      mobjParameters.XaxisMax, _
                      mobjParameters.XaxisMin, _
                      mobjParameters.YaxisMax, _
                      mobjParameters.YaxisMin, _
                      mobjParameters.Cal_Mode, _
                      mobjParameters.ScanSpeed, _
                      dblAbsScanthldval, blnCheckMinAbsScanLmt)
        mobjController.Start(mobjclsBgSpectrum)

        funcOnSpect = True
        'mblnAvoidProcessing = False
    End Function

    '    Public Function funcOnContinuesScan()
    '        '=====================================================================
    '        ' Procedure Name        :   funcOnContinuesScan
    '        ' Description           :   
    '        ' Purpose               :   
    '        '                           
    '        ' Parameters Passed     :   None.
    '        ' Returns               :   True, if successful.
    '        ' Parameters Affected   :   None.
    '        ' Assumptions           :
    '        ' Dependencies          :
    '        ' Author                :   Sachin Dokhale
    '        ' Created               :   
    '        ' Revisions             :
    '        '=====================================================================
    '        Try
    '            '             ReadFilterSetting();   // new changes
    '            ' Afirst=TRUE;
    '            ' if (hwnd){
    '            '	UpdateWindow(hwnd);
    '            '	hdc= GetDC(hwnd);
    '            '	CEnd1=CEnd=clock();
    '            '	xtime1= ((CEnd-CEnd1)/(double) CLK_TCK);
    '            '	SetWindowText(GetDlgItem(hwnd,IDC_FILT),"Filt");
    '            '	do  {
    '            '	  if (CheckMsg(hwnd, &msg)){
    '            '		 if (WP1==IDC_FILT){ // new changes
    '            '			Smooth ^= TRUE;
    '            '                            If (Smooth) Then
    '            '			  SetWindowText(GetDlgItem(hwnd,IDC_FILT),"Filt");
    '            '                            Else
    '            '			  SetWindowText(GetDlgItem(hwnd,IDC_FILT),"No Filt");

    '            '			WP1=-1;
    '            '		  }
    '            '		 if (WP1==IDC_RET){
    '            '			pc_delay(1000);
    '            '			ReleaseDC(hwnd, hdc);
    '            '			DestroyWindow(hwnd);
    '            '			break;
    '            '		  }
    '            '		}
    '            '                                    If (IsInAltProcess()) Then
    '            '		 continue;
    '            '	  abs = GetAbsScanX();
    '            '	  if (Smooth)          	// new changes
    '            '		  abs = GetFiltData(abs);

    '            '		//---mdf by sk on 3/6/2001
    '            '                                            If (CheckMinAbsScanLmt) Then
    '            '		 {
    '            '		  if(abs<Absscanthldval) //0.008 mdf by sk on 3/6/2001
    '            '         abs=0.0;
    '            '		 }
    '            '      //---mdf by sk on 3/6/2001

    '            '	  CEnd=clock();
    '            '	  if (CEnd!=CEnd1 ){
    '            '		 xtime1 += ( ((double)(CEnd-CEnd1)/(double) CLK_TCK));
    '            '		 CEnd1 = CEnd;
    '            '		 GetWvAndDataInString(abs, str);
    '            '		 SetDlgItemText(hwnd,IDC_QAABS, str);
    '            '		 if (xtime1>=AbsGraph.Xmax){
    '            '			tval =(AbsGraph.Xmax-AbsGraph.Xmin);
    '            '			AbsGraph.Xmin = AbsGraph.Xmax;//(double)5.0;
    '            '			AbsGraph.Xmax +=tval;// (double)5.0;
    '            '			Calculate_Abs_Scan_Param(&AbsGraph);
    '            '			Afirst=TRUE;
    '            '			InvalidateRect(hwnd, NULL, TRUE); //AbsGraph.RC, TRUE);
    '            '			UpdateWindow(hwnd);
    '            '			CEnd1 = clock();
    '            '//			CStart += (CEnd1-CEnd);
    '            '		  }
    '            '		 if (Afirst){
    '            '			PlotInit(hdc, xtime1, abs, AbsGraph.RC, &AbsGraph);
    '            '			Afirst=FALSE;
    '            '		  }
    '            '                                                            Else
    '            '			Plotg(hdc, xtime1, abs, AbsGraph.RC, &AbsGraph);
    '            '		}
    '            '	  }
    '            '	 while(1);

    '            gobjClsAAS203.ReInitInstParameters()
    '            Dim CEnd1, CEnd As Long
    '            Dim ConstManipulate As Long = 1000
    '            Dim Text1 As String

    '            CEnd1 = CEnd = CLng(System.DateTime.Now.Ticks) / ConstManipulate
    '            'lngTimeInMSeconds = lngTimeDelay + lngTimeInMSeconds
    '            XaxisTime1 = ((CEnd - CEnd1) / CLng(System.DateTime.Now.Ticks))

    '            Do While (True)
    '                'If (IsInAltProcess()) Then
    '                '    GoTo ContinueEx
    '                'End If
    '                dblAbs = gobjClsAAS203.funcGetAbsScanX()
    '                If (gblnSmoothFilter = True) Then
    '                    dblAbs = gobjClsAAS203.funcGetFiltData(dblAbs)
    '                End If

    '                If blnCheckMinAbsScanLmt = True Then
    '                    If (dblAbs < dblAbsScanthldval) Then
    '                        dblAbs = 0.0
    '                    End If
    '                End If
    '                CEnd = CLng(System.DateTime.Now.Ticks) / ConstManipulate
    '                If Not (CEnd = CEnd1) Then
    '                    XaxisTime1 += ((CEnd - CEnd1) / CLng(System.DateTime.Now.Ticks))
    '                    CEnd1 = CEnd
    '                    Text1 = XaxisTime1.ToString & "|" & dblAbs.ToString
    '                    Call funcIclientTaskDisplayData(Text1)
    '                    If (XaxisTime1 >= AASGraphTimeScan.XAxisMax) Then
    '                        CEnd1 = CLng(System.DateTime.Now.Ticks) / ConstManipulate
    '                    End If
    '                    'tval =(AbsGraph.Xmax-AbsGraph.Xmin);
    '                    'AbsGraph.Xmin = AbsGraph.Xmax;//(double)5.0;
    '                    'AbsGraph.Xmax +=tval;// (double)5.0;
    '                    'Calculate_Abs_Scan_Param(&AbsGraph);
    '                    'Afirst=TRUE;
    '                    'InvalidateRect(hwnd, NULL, TRUE); //AbsGraph.RC, TRUE);
    '                    'UpdateWindow(hwnd);
    '                End If

    'ContinueEx:
    '            Loop

    '            Return True

    '        Catch ex As Exception
    '            '---------------------------------------------------------
    '            'Error Handling and logging
    '            gobjErrorHandler.ErrorDescription = ex.Message
    '            gobjErrorHandler.ErrorMessage = ex.Message
    '            gobjErrorHandler.WriteErrorLog(ex)
    '            '---------------------------------------------------------
    '            Return False
    '        Finally
    '            '---------------------------------------------------------
    '            'Writing Execution log
    '            If CONST_CREATE_EXECUTION_LOG = 1 Then
    '                gobjErrorHandler.WriteExecutionLog()
    '            End If
    '            '---------------------------------------------------------
    '        End Try

    '    End Function

#Region " Save/Load Spectrum Function "

    '--- Save the Current Active channel to a UVSpectrum(uvs) file
    'Private Function funcSaveSpectrumFile() As Boolean
    '    '=====================================================================
    '    ' Procedure Name        :   funcSaveSpectrumFile
    '    ' Description           :   Get the File name and path from the user
    '    '                           and save the spectrum file to *.spt 
    '    ' Purpose               :   To save the channel information to the 
    '    '                           Spectrum file.
    '    ' Parameters Passed     :   None.
    '    ' Returns               :   True, if successful.
    '    ' Parameters Affected   :   None.
    '    ' Assumptions           :
    '    ' Dependencies          :
    '    ' Author                :   Gitesh, Uday
    '    ' Created               :   Saturday, November 15, 2003 18:49
    '    ' Revisions             :
    '    '=====================================================================
    '    Try
    '        If mobjChannnels.item(mintChannelIndex) Is Nothing Then
    '            'gFuncShowMessage("Error", "Spectrum is not present for saving.", EnumMessageType.Information)
    '            Exit Function
    '        End If

    '        Dim objchannel As Spectrum.Channel

    '        objchannel = mobjChannnels.item(mintChannelIndex)

    '        'If gstructApplicationSettings.Enable21CFR = 1 Then
    '        '    If Not gfuncGetFileAuthenticationData(objchannel.DigitalSignature) Then
    '        '        Return True
    '        '    End If
    '        'Else
    '        '--- This is for saving the file with login Authnetication 
    '        '--- when 21 cfr is off
    '        'If Not gfuncGetFileAuthenticationData_21CFR_OFF(objchannel.DigitalSignature) Then
    '        '    Return True
    '        'End If
    '        'End If

    '        Dim objStream As Stream
    '        Dim objsfdSpectrum As New SaveFileDialog

    '        '--- Show the save dialog to accept the *.spt file.
    '        objsfdSpectrum.Filter = "Spectrum Files(*" & CONST_EnergySpectrumFileExt & ")|*" & CONST_EnergySpectrumFileExt
    '        objsfdSpectrum.FilterIndex = 1
    '        objsfdSpectrum.InitialDirectory = strPath.GetCurrentDirectory.ToString + "\UVSpectrums"
    '        objsfdSpectrum.RestoreDirectory = True

    '        If objsfdSpectrum.ShowDialog() = DialogResult.OK Then
    '            'objchannel.DigitalSignature.FileName = objsfdSpectrum.FileName
    '            '--- Check if file exist   
    '            If (objsfdSpectrum.CheckFileExists()) Then
    '                If (MessageBox.Show("DO YOU WISH TO OVERWRITE", "SAVE AS", MessageBoxButtons.YesNo) = DialogResult.Yes) Then
    '                    If Not gfuncSerializeObject(objsfdSpectrum.FileName, objchannel) Then
    '                        'gFuncShowMessage("Error", "ERROR IN SAVING FILE.", EnumMessageType.Information) '112
    '                    End If
    '                Else
    '                    Return True
    '                End If
    '            Else
    '                If Not gfuncSerializeObject(objsfdSpectrum.FileName, objchannel) Then
    '                    'gFuncShowMessage("Error", "ERROR IN SAVING FILE.", EnumMessageType.Information) '112
    '                End If
    '            End If

    '            '--- Writing to Activity Log and File Log
    '            'If (gstructApplicationSettings.Enable21CFR = 1) Then
    '            '    Dim lngActivityLogID As Long
    '            '    lngActivityLogID = gfuncInsertActivityLog(EnumModules.Spectrum, "Spectrum File Saved")

    '            'If (lngActivityLogID > 0) Then
    '            'Dim objFI As New FileInfo(objsfdSpectrum.FileName)
    '            'Dim strXMLFileData As String
    '            'Dim strFileLogPath As String
    '            'Dim strFileName As String = Replace(objFI.Name, objFI.Extension, "")

    '            'strFileName = strFileName & "_" & Format(DateTime.Now, "MM_dd_yyyy_hh_mm_ss") & objFI.Extension

    '            'If Not Directory.Exists(CONST_FILELOG_PATH) Then
    '            '    Call Directory.CreateDirectory(CONST_FILELOG_PATH)
    '            'End If

    '            'strFileLogPath = CONST_FILELOG_PATH & "\" & strFileName

    '            ''Call objclsXmlOperation.gfuncXMLSerializeObject(strFileLogPath, objchannel)
    '            ''strXMLFileData = objclsXmlOperation.gfuncXMLFileRead(strFileLogPath)
    '            'If Not gfuncSerializeObject(strFileLogPath, objchannel) Then
    '            '    Throw New Exception
    '            'End If

    '            ''--- Log the file 
    '            ''Call gfuncInsertFileLog(lngActivityLogID, objsfdSpectrum.FileName, strFileLogPath)
    '            'End If
    '            'End If

    '        End If
    '        objsfdSpectrum.Dispose()

    '        Return True

    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        'Error Handling and logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = ex.Message
    '        gobjErrorHandler.WriteErrorLog(ex)
    '        '---------------------------------------------------------
    '        Return False
    '    Finally
    '        '---------------------------------------------------------
    '        'Writing Execution log
    '        If CONST_CREATE_EXECUTION_LOG = 1 Then
    '            gobjErrorHandler.WriteExecutionLog()
    '        End If
    '        '---------------------------------------------------------
    '    End Try

    'End Function

    ''--- Load channel from spectrum(spt) file
    'Private Function funcLoadSpectrumFile() As Boolean
    '    '=====================================================================
    '    ' Procedure Name        :   funcLoadSpectrumFile
    '    ' Description           :   Get the Spectrum file from the user and load the
    '    '                           spectrum file data to the channel object.
    '    ' Purpose               :   To load the spectrum file in the channel object.
    '    ' Parameters Passed     :   None.
    '    ' Returns               :   True, if successful.
    '    ' Parameters Affected   :   Spectrum file data is added to the channels collection.
    '    ' Assumptions           :   None.
    '    ' Dependencies          :   None.
    '    ' Author                :   Gitesh, Uday
    '    ' Created               :   Saturday, November 15, 2003 18:49
    '    ' Revisions             :   Nilesh Shirode  feb 11 2004
    '    '=====================================================================
    '    Dim objStream As Stream
    '    Dim objofdSpectrum As New OpenFileDialog
    '    Try
    '        funcLoadSpectrumFile = False

    '        objofdSpectrum.InitialDirectory = strPath.GetCurrentDirectory.ToString & "\Spectrums"
    '        objofdSpectrum.Filter = "Spectrum Files(*" & CONST_EnergySpectrumFileExt & ")|*" & CONST_EnergySpectrumFileExt
    '        objofdSpectrum.FilterIndex = 1
    '        objofdSpectrum.RestoreDirectory = True

    '        If objofdSpectrum.ShowDialog() = DialogResult.OK Then
    '            If (objofdSpectrum.CheckFileExists()) Then
    '                Dim objchannel As Spectrum.Channel
    '                Dim intChannel_no As Int16

    '                'If gstructApplicationSettings.Enable21CFR = 1 Then
    '                '    Dim objChn As Channel
    '                '    objChn = gfuncDeSerializeObject(objofdSpectrum.FileName, EnumDeserializeObjType.Channel)
    '                '    If gfuncCheckForFileAuthentication(objChn.DigitalSignature) Then
    '                '        objchannel = objChn
    '                '    Else
    '                '        Call gFuncShowMessage("Authentication Fail !", "Access denied, cannot open the file.", modConstants.EnumMessageType.Information)
    '                '        Return False
    '                '    End If
    '                'End If

    '                objchannel = gfuncDeSerializeObject(objofdSpectrum.FileName, EnumDeserializeObjType.UVSpectrum)
    '                '--- Add the new channel to the channels collection and 
    '                '--- accordingly save the channel file to the disk

    '                intChannel_no = funcAddChannelToCollection(objchannel)

    '                If mobjChannnels.Count > 0 Then
    '                    mobjChannnels.item(0) = objchannel
    '                    mobjParameters = Nothing
    '                    mobjParameters = mobjChannnels.item(0).EnegryParameter
    '                    Call funcSetParameter()
    '                    funcClearGraph()
    '                    funcGraphPreRequisite(mobjParameters.Cal_Mode, _
    '                                            mobjParameters.XaxisMin, _
    '                                            mobjParameters.XaxisMax, _
    '                                            mobjParameters.YaxisMin, _
    '                                            mobjParameters.YaxisMax)
    '                    funcDisplayGraph(mobjChannnels.item(0))

    '                Else
    '                    mobjParameters = Nothing
    '                    mobjChannnels.Add(objchannel)
    '                    mobjParameters = mobjChannnels.item(intChannel_no).EnegryParameter
    '                    Call funcSetParameter()
    '                    funcClearGraph()
    '                    funcGraphPreRequisite(mobjParameters.Cal_Mode, _
    '                                            mobjParameters.XaxisMin, _
    '                                            mobjParameters.XaxisMax, _
    '                                            mobjParameters.YaxisMin, _
    '                                            mobjParameters.YaxisMax)
    '                    funcDisplayGraph(mobjChannnels.item(intChannel_no))

    '                End If
    '                Application.DoEvents()

    '                'subLabelDisplay(mobjChannnels.item(0))
    '            End If
    '        End If
    '        objofdSpectrum.Dispose()
    '        funcLoadSpectrumFile = True

    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        'Error Handling and logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = ex.Message
    '        gobjErrorHandler.WriteErrorLog(ex)
    '        '---------------------------------------------------------
    '    Finally
    '        '---------------------------------------------------------
    '        'Writing Execution log
    '        If CONST_CREATE_EXECUTION_LOG = 1 Then
    '            gobjErrorHandler.WriteExecutionLog()
    '        End If
    '        '---------------------------------------------------------
    '    End Try

    'End Function

#End Region

    Private Function funcSetFrmEditValue(ByRef ReturnValue As Double, ByVal strWinTitle As String, ByVal dblMinValue As Double, ByVal dblMaxValue As Double) As Boolean
        '=====================================================================
        ' Procedure Name        : subSetFrmEditValue
        ' Parameters Passed     : 
        ' Returns               : 
        ' Purpose               : 
        '                         
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : Apr 01, 2007 4:00 pm
        ' Revisions             : 1
        '=====================================================================
        Dim InputValue As Double
        Dim intValue As Integer
        Try
            mobjfrmEditValues = New frmEditValues
            mobjfrmEditValues.LabelText = strWinTitle
            mobjfrmEditValues.txtValue.Visible = True
            Select Case strWinTitle
                Case "PMT", "D2 Current"
                    'mobjfrmEditValues.txtValue.ValidationType = NumberValidator.NumberValidator.Validations.IntegerOnly

                    intValue = CInt(ReturnValue)
                    ReturnValue = intValue
                Case Else
                    'mobjfrmEditValues.txtValue.ValidationType = NumberValidator.NumberValidator.Validations.DoubleOnly
            End Select

            'mobjfrmEditValues.txtValue.RangeValidation = True
            'mobjfrmEditValues.txtValue.DigitsAfterDecimalPoint = 2
            'mobjfrmEditValues.txtValue.MaxLength = 3
            'mobjfrmEditValues.txtValue.MinimumRange = dblMinValue
            'mobjfrmEditValues.txtValue.MaximumRange = dblMaxValue
            mobjfrmEditValues.txtValue.Focus()
            mobjfrmEditValues.txtValue.SelectAll()

            mobjfrmEditValues.txtValue.Text = ReturnValue
            If mobjfrmEditValues.ShowDialog = DialogResult.Cancel Then
                Application.DoEvents()
                mobjfrmEditValues.Dispose()
                Return False
            End If

            If IsNumeric(mobjfrmEditValues.txtValue.Text) Then
                InputValue = mobjfrmEditValues.txtValue.Text
                If InputValue < dblMinValue Then
                    InputValue = dblMinValue
                ElseIf InputValue > dblMaxValue Then
                    InputValue = dblMaxValue
                Else
                    InputValue = mobjfrmEditValues.txtValue.Text
                End If
            Else
                InputValue = dblMinValue
            End If

            'If InputValue < dblMinValue Or InputValue > dblMaxValue Then
            '    gobjMessageAdapter.ShowMessage(constInvalidRange)   'constPMTRange
            '    'MsgBox("PMT value should be between 0 and 1000")
            '    Exit Function
            'End If

            ReturnValue = InputValue
            Application.DoEvents()

            'mobjfrmEditValues.txtAvgFactor.Text = CInt()
            'txtAvgFactor.Refresh()
            'mobjfrmEditValues.Dispose()
            'gobjInst.Average = CInt(InputValue)
            Return True
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            Return False
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------
        End Try
    End Function

#End Region

#Region " Code for Enable and Disable"

    Private Function func_Enable_Disable(ByVal intProcess As Integer, ByVal intStart_End As Integer)
        Try

            Select Case intProcess
                Case EnumProcesses.FormInitialize, EnumProcesses.EditSystemParamters
                    Select Case intStart_End
                        Case EnumStart_End.Start_of_Process

                            subAll_Menus_Enable()
                            btnAutoZero.Enabled = True
                            btnClearSpectrum.Enabled = True
                            btnReturn.Enabled = True
                            nudD2Cur.Enabled = True
                            nudPMT.Enabled = True
                            If Not (gintInstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.SingleBeam) Then
                                nudPMT_Ref.Enabled = True
                            End If
                            nudSlit.Enabled = True
                            'nudSlit_Exit.Enabled = True 'by Pankaj on 18.1.08
                            'cmbSpeed.Enabled = True
                            cmbModes.Enabled = True
                            nudBurnerHeight.Enabled = True
                            nudFuelRatio.Enabled = True
                            nudHCLCur.Enabled = True
                            btnClearSpectrum.Enabled = True
                            btnLampParameters.Enabled = True


                            'tlbrSpectrum.Buttons.Item(EnumToolBarButtons.ReturnToSelectModes).ImageIndex = EnumToolBarImages.ReturnToSelectModesEnabled
                            'tlbrSpectrum.Buttons.Item(EnumToolBarButtons.Parameter).ImageIndex = EnumToolBarImages.ParameterEnabled
                            'tlbrSpectrum.Buttons.Item(EnumToolBarButtons.StopScan).ImageIndex = EnumToolBarImages.StopScanDisabled
                            'tlbrSpectrum.Buttons.Item(EnumToolBarButtons.Clear).ImageIndex = EnumToolBarImages.ClearEnabled

                            'If gstructConfigurartionSetting.DemoMode = 1 Then
                            '    mnuLamp.Enabled = False
                            '    tlbrSpectrum.Buttons.Item(EnumToolBarButtons.Baseline).ImageIndex = EnumToolBarImages.BaselineDisabled
                            '    tlbrSpectrum.Buttons.Item(EnumToolBarButtons.Autozero).ImageIndex = EnumToolBarImages.AutozeroDisabled
                            '    tlbrSpectrum.Buttons.Item(EnumToolBarButtons.StartScan).ImageIndex = EnumToolBarImages.StartScanDisabled
                            'Else
                            '    tlbrSpectrum.Buttons.Item(EnumToolBarButtons.Baseline).ImageIndex = EnumToolBarImages.BaselineEnabled
                            '    tlbrSpectrum.Buttons.Item(EnumToolBarButtons.Autozero).ImageIndex = EnumToolBarImages.AutozeroEnabled
                            '    tlbrSpectrum.Buttons.Item(EnumToolBarButtons.StartScan).ImageIndex = EnumToolBarImages.StartScanEnabled
                            'End If

                            'If mobjChannnels.Count > 0 Then
                            '    tlbrSpectrum.Buttons.Item(EnumToolBarButtons.ClearAndRedraw).ImageIndex = EnumToolBarImages.ClearAndRedrawEnabled
                            '    tlbrSpectrum.Buttons.Item(EnumToolBarButtons.Print).ImageIndex = EnumToolBarImages.PrintEnabled
                            'Else
                            '    mnuDataProcessing.Enabled = False
                            '    mnuManipulate.Enabled = False
                            '    tlbrSpectrum.Buttons.Item(EnumToolBarButtons.ClearAndRedraw).ImageIndex = EnumToolBarImages.ClearAndRedrawDisabled
                            '    tlbrSpectrum.Buttons.Item(EnumToolBarButtons.Print).ImageIndex = EnumToolBarImages.PrintDisabled
                            'End If

                        Case EnumStart_End.End_of_Process

                    End Select
                Case EnumProcesses.LoadParameters   '2
                    Select Case intStart_End
                        Case EnumStart_End.Start_of_Process

                        Case EnumStart_End.End_of_Process
                    End Select

                Case EnumProcesses.EditParameters    '3   
                    Select Case intStart_End
                        Case EnumStart_End.Start_of_Process

                        Case EnumStart_End.End_of_Process
                    End Select

                Case EnumProcesses.SaveParameters    '4   
                    Select Case intStart_End
                        Case EnumStart_End.Start_of_Process

                        Case EnumStart_End.End_of_Process
                    End Select

                Case EnumProcesses.StartScan            '15  EnumProcesses.StartScan
                    Select Case intStart_End
                        Case EnumStart_End.Start_of_Process
                            subAll_Menus_Disable()
                            'btnClearSpectrum.Enabled = False
                            'btnReturn.Enabled = False
                            'If m_blnBaseline = True Then
                            '    btnBaseLine.Text = "&Stop"
                            '    btnStart.Enabled = False
                            '    btnBaseLine.Enabled = True
                            'Else
                            '    btnStart.Text = "&Stop"
                            '    btnStart.Enabled = True
                            '    btnBaseLine.Enabled = False
                            'End If

                            'btnStart.Enabled = False


                            'nudD2Cur.Enabled = False
                            'nudPMT.Enabled = False
                            'nudSlit.Enabled = False
                            'cmbSpeed.Enabled = False
                            'cmbModes.Enabled = False
                            'nudBurnerHeight.Enabled = False
                            'nudFuelRatio.Enabled = False
                            'nudHCLCur.Enabled = False
                            'btnLampParameters.Enabled = False

                            'NumUpDwn.Enabled = False
                            'btnNumUpDwn_Dwn.Enabled = False
                            'btnNumUpDwn_Up.Enabled = False

                            'tlbrSpectrum.Buttons.Item(EnumToolBarButtons.ReturnToSelectModes).ImageIndex = EnumToolBarImages.ReturnToSelectModesDisabled
                            'tlbrSpectrum.Buttons.Item(EnumToolBarButtons.Parameter).ImageIndex = EnumToolBarImages.ParameterDisabled
                            'tlbrSpectrum.Buttons.Item(EnumToolBarButtons.StopScan).ImageIndex = EnumToolBarImages.StopScanDisabled
                            'tlbrSpectrum.Buttons.Item(EnumToolBarButtons.Clear).ImageIndex = EnumToolBarImages.ClearDisabled
                            'tlbrSpectrum.Buttons.Item(EnumToolBarButtons.Baseline).ImageIndex = EnumToolBarImages.BaselineDisabled
                            'tlbrSpectrum.Buttons.Item(EnumToolBarButtons.Autozero).ImageIndex = EnumToolBarImages.AutozeroDisabled
                            'tlbrSpectrum.Buttons.Item(EnumToolBarButtons.StartScan).ImageIndex = EnumToolBarImages.StartScanDisabled
                            'tlbrSpectrum.Buttons.Item(EnumToolBarButtons.ClearAndRedraw).ImageIndex = EnumToolBarImages.ClearAndRedrawDisabled
                            'tlbrSpectrum.Buttons.Item(EnumToolBarButtons.Print).ImageIndex = EnumToolBarImages.PrintDisabled

                        Case EnumStart_End.End_of_Process
                            If gblnSpectrumTerminated = False Then
                                subAll_Menus_Enable()
                                btnClearSpectrum.Enabled = True
                                btnReturn.Enabled = True
                                nudD2Cur.Enabled = True
                                nudPMT.Enabled = True
                                If Not (gintInstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.SingleBeam) Then
                                    nudPMT_Ref.Enabled = True
                                End If
                                nudSlit.Enabled = True
                                'nudSlit_Exit.Enabled = True 'by Pankaj on 18.1.08
                                cmbModes.Enabled = True
                                nudBurnerHeight.Enabled = True
                                nudFuelRatio.Enabled = True
                                nudHCLCur.Enabled = True
                                btnLampParameters.Enabled = True

                            End If

                        Case EnumStart_End.Process_Running
                            'tlbrSpectrum.Buttons.Item(EnumToolBarButtons.StopScan).ImageIndex = EnumToolBarImages.StopScanEnabled
                            'If gstructApplicationSessionState.intInstrument_Group = EnumInstrumentGroup.Initialize_2600_2700 Then
                            '    tlbrSpectrum.Buttons.Item(EnumToolBarButtons.StopScan).ImageIndex = EnumToolBarImages.StopScanEnabled
                            'ElseIf gstructApplicationSessionState.intInstrument_Group = EnumInstrumentGroup.Initialize_2100_2200_2300 Then
                            '    tlbrSpectrum.Buttons.Item(EnumToolBarButtons.StopScan).ImageIndex = EnumToolBarImages.StopScanDisabled
                            'End If

                        Case EnumStart_End.Process_Waiting
                            '--- commented to enable the stop button
                            '---- While Repeat scan
                            'tlbrSpectrum.Buttons.Item(EnumToolBarButtons.StopScan).ImageIndex = EnumToolBarImages.StopScanDisabled
                    End Select

                Case EnumProcesses.Clear         '20 
                    Select Case intStart_End
                        Case EnumStart_End.Start_of_Process

                        Case EnumStart_End.End_of_Process
                            subAll_Menus_Enable()

                            'tlbrSpectrum.Buttons.Item(EnumToolBarButtons.ReturnToSelectModes).ImageIndex = EnumToolBarImages.ReturnToSelectModesEnabled
                            'tlbrSpectrum.Buttons.Item(EnumToolBarButtons.Parameter).ImageIndex = EnumToolBarImages.ParameterEnabled
                            'tlbrSpectrum.Buttons.Item(EnumToolBarButtons.StopScan).ImageIndex = EnumToolBarImages.StopScanDisabled
                            'tlbrSpectrum.Buttons.Item(EnumToolBarButtons.Clear).ImageIndex = EnumToolBarImages.ClearEnabled
                            ' Get Confirmed
                            ' Bt Sachin V. Dokhale
                            'If gstructConfigurartionSetting.DemoMode = 1 Then   ' Or structFlag.blnNone = True
                            'mnuLamp.Enabled = False
                            'tlbrSpectrum.Buttons.Item(EnumToolBarButtons.Baseline).ImageIndex = EnumToolBarImages.BaselineDisabled
                            'tlbrSpectrum.Buttons.Item(EnumToolBarButtons.Autozero).ImageIndex = EnumToolBarImages.AutozeroDisabled
                            'tlbrSpectrum.Buttons.Item(EnumToolBarButtons.StartScan).ImageIndex = EnumToolBarImages.StartScanDisabled
                            'Else
                            'tlbrSpectrum.Buttons.Item(EnumToolBarButtons.Baseline).ImageIndex = EnumToolBarImages.BaselineEnabled
                            'tlbrSpectrum.Buttons.Item(EnumToolBarButtons.Autozero).ImageIndex = EnumToolBarImages.AutozeroEnabled
                            'tlbrSpectrum.Buttons.Item(EnumToolBarButtons.StartScan).ImageIndex = EnumToolBarImages.StartScanEnabled

                            'End If
                            'tlbrSpectrum.Buttons.Item(EnumToolBarButtons.Print).ImageIndex = EnumToolBarImages.PrintEnabled
                            'tlbrSpectrum.Buttons.Item(EnumToolBarButtons.ClearAndRedraw).ImageIndex = EnumToolBarImages.ClearAndRedrawDisabled


                    End Select
                Case EnumProcesses.ClearAndRedraw             '17 
                    Select Case intStart_End
                        Case EnumStart_End.Start_of_Process

                            subAll_Menus_Disable()

                            'tlbrSpectrum.Buttons.Item(EnumToolBarButtons.ReturnToSelectModes).ImageIndex = EnumToolBarImages.ReturnToSelectModesDisabled
                            'tlbrSpectrum.Buttons.Item(EnumToolBarButtons.Parameter).ImageIndex = EnumToolBarImages.ParameterDisabled
                            'tlbrSpectrum.Buttons.Item(EnumToolBarButtons.StopScan).ImageIndex = EnumToolBarImages.StopScanDisabled
                            'tlbrSpectrum.Buttons.Item(EnumToolBarButtons.Clear).ImageIndex = EnumToolBarImages.ClearDisabled
                            'tlbrSpectrum.Buttons.Item(EnumToolBarButtons.Baseline).ImageIndex = EnumToolBarImages.BaselineDisabled
                            'tlbrSpectrum.Buttons.Item(EnumToolBarButtons.Autozero).ImageIndex = EnumToolBarImages.AutozeroDisabled
                            'tlbrSpectrum.Buttons.Item(EnumToolBarButtons.StartScan).ImageIndex = EnumToolBarImages.StartScanDisabled
                            'tlbrSpectrum.Buttons.Item(EnumToolBarButtons.ClearAndRedraw).ImageIndex = EnumToolBarImages.ClearAndRedrawDisabled
                            'tlbrSpectrum.Buttons.Item(EnumToolBarButtons.Print).ImageIndex = EnumToolBarImages.PrintDisabled

                        Case EnumStart_End.End_of_Process
                            subAll_Menus_Enable()

                            'tlbrSpectrum.Buttons.Item(EnumToolBarButtons.ReturnToSelectModes).ImageIndex = EnumToolBarImages.ReturnToSelectModesEnabled
                            'tlbrSpectrum.Buttons.Item(EnumToolBarButtons.Parameter).ImageIndex = EnumToolBarImages.ParameterEnabled
                            'tlbrSpectrum.Buttons.Item(EnumToolBarButtons.StopScan).ImageIndex = EnumToolBarImages.StopScanDisabled
                            'tlbrSpectrum.Buttons.Item(EnumToolBarButtons.Clear).ImageIndex = EnumToolBarImages.ClearEnabled
                            ' Get Confirmed
                            ' Bt Sachin V. Dokhale
                            'If gstructConfigurartionSetting.DemoMode = 1 Then   'Or structFlag.blnNone = True
                            '    mnuLamp.Enabled = False
                            '    tlbrSpectrum.Buttons.Item(EnumToolBarButtons.Baseline).ImageIndex = EnumToolBarImages.BaselineDisabled
                            '    tlbrSpectrum.Buttons.Item(EnumToolBarButtons.Autozero).ImageIndex = EnumToolBarImages.AutozeroDisabled
                            '    tlbrSpectrum.Buttons.Item(EnumToolBarButtons.StartScan).ImageIndex = EnumToolBarImages.StartScanDisabled
                            'Else
                            '    tlbrSpectrum.Buttons.Item(EnumToolBarButtons.Baseline).ImageIndex = EnumToolBarImages.BaselineEnabled
                            '    tlbrSpectrum.Buttons.Item(EnumToolBarButtons.Autozero).ImageIndex = EnumToolBarImages.AutozeroEnabled
                            '    tlbrSpectrum.Buttons.Item(EnumToolBarButtons.StartScan).ImageIndex = EnumToolBarImages.StartScanEnabled
                            'End If

                            'tlbrSpectrum.Buttons.Item(EnumToolBarButtons.ClearAndRedraw).ImageIndex = EnumToolBarImages.ClearAndRedrawEnabled
                            'tlbrSpectrum.Buttons.Item(EnumToolBarButtons.Print).ImageIndex = EnumToolBarImages.PrintEnabled

                    End Select
                Case EnumProcesses.StopsScan           '16 
                    Select Case intStart_End
                        Case EnumStart_End.Start_of_Process
                            subAll_Menus_Enable()

                            'tlbrSpectrum.Buttons.Item(EnumToolBarButtons.ReturnToSelectModes).ImageIndex = EnumToolBarImages.ReturnToSelectModesEnabled
                            'tlbrSpectrum.Buttons.Item(EnumToolBarButtons.Parameter).ImageIndex = EnumToolBarImages.ParameterEnabled
                            'tlbrSpectrum.Buttons.Item(EnumToolBarButtons.StopScan).ImageIndex = EnumToolBarImages.StopScanDisabled
                            'tlbrSpectrum.Buttons.Item(EnumToolBarButtons.Clear).ImageIndex = EnumToolBarImages.ClearEnabled
                            'tlbrSpectrum.Buttons.Item(EnumToolBarButtons.Baseline).ImageIndex = EnumToolBarImages.BaselineEnabled
                            'tlbrSpectrum.Buttons.Item(EnumToolBarButtons.Autozero).ImageIndex = EnumToolBarImages.AutozeroEnabled
                            'tlbrSpectrum.Buttons.Item(EnumToolBarButtons.StartScan).ImageIndex = EnumToolBarImages.StartScanEnabled
                            'tlbrSpectrum.Buttons.Item(EnumToolBarButtons.ClearAndRedraw).ImageIndex = EnumToolBarImages.ClearAndRedrawEnabled
                            'tlbrSpectrum.Buttons.Item(EnumToolBarButtons.Print).ImageIndex = EnumToolBarImages.PrintEnabled

                        Case EnumStart_End.End_of_Process
                    End Select

                Case EnumProcesses.Autozero '19 
                    Select Case intStart_End
                        Case EnumStart_End.Start_of_Process

                        Case EnumStart_End.End_of_Process
                    End Select

                Case EnumProcesses.Baseline         '18 
                    Select Case intStart_End
                        Case EnumStart_End.Start_of_Process

                        Case EnumStart_End.End_of_Process
                    End Select
                Case EnumProcesses.ChannelUp_Down           '21
                    Select Case intStart_End
                        Case EnumStart_End.Start_of_Process
                            'NumUpDwn.Enabled = False
                            'btnNumUpDwn_Dwn.Enabled = False
                            'btnNumUpDwn_Up.Enabled = False

                        Case EnumStart_End.End_of_Process
                            'NumUpDwn.Enabled = True
                            'btnNumUpDwn_Dwn.Enabled = True
                            'btnNumUpDwn_Up.Enabled = True
                            'tlbrSpectrum.Buttons.Item(EnumToolBarButtons.Print).ImageIndex = EnumToolBarImages.PrintEnabled

                    End Select

                Case Else
                    subAll_Menus_Enable()
                    'tlbrSpectrum.Buttons.Item(EnumToolBarButtons.ReturnToSelectModes).ImageIndex = EnumToolBarImages.ReturnToSelectModesEnabled
                    'tlbrSpectrum.Buttons.Item(EnumToolBarButtons.Parameter).ImageIndex = EnumToolBarImages.ParameterEnabled
                    'tlbrSpectrum.Buttons.Item(EnumToolBarButtons.StopScan).ImageIndex = EnumToolBarImages.StopScanDisabled
                    'tlbrSpectrum.Buttons.Item(EnumToolBarButtons.Clear).ImageIndex = EnumToolBarImages.ClearEnabled
                    'tlbrSpectrum.Buttons.Item(EnumToolBarButtons.Baseline).ImageIndex = EnumToolBarImages.BaselineEnabled
                    'tlbrSpectrum.Buttons.Item(EnumToolBarButtons.Autozero).ImageIndex = EnumToolBarImages.AutozeroEnabled
                    'tlbrSpectrum.Buttons.Item(EnumToolBarButtons.StartScan).ImageIndex = EnumToolBarImages.StartScanEnabled
                    'tlbrSpectrum.Buttons.Item(EnumToolBarButtons.ClearAndRedraw).ImageIndex = EnumToolBarImages.ClearAndRedrawEnabled
                    'tlbrSpectrum.Buttons.Item(EnumToolBarButtons.Print).ImageIndex = EnumToolBarImages.PrintEnabled
            End Select

            ' tlbrSpectrum.Buttons.Item(EnumToolBarButtons.StopScan).Pushed = True

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            'gobjErrorHandler.ProcessError(ErrorHandler.EnumErrorType.Critical, ex)
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            'tlbrSpectrum.Refresh()

            '---------------------------------------------------------
        End Try

    End Function

    Private Sub subAll_Menus_Enable()
        Dim intMenuItems_Count As Integer
        Try
            'For intMenuItems_Count = 0 To MainMenu.MenuItems.Count - 1
            '    MainMenu.MenuItems.Item(intMenuItems_Count).Enabled = True
            'Next
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            'gobjErrorHandler.ProcessError(ErrorHandler.EnumErrorType.Critical, ex)
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub subAll_Menus_Disable()
        Dim intMenuItems_Count As Integer
        Try
            'For intMenuItems_Count = 0 To MainMenu.MenuItems.Count - 1
            '    MainMenu.MenuItems.Item(intMenuItems_Count).Enabled = False
            'Next
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            'gobjErrorHandler.ProcessError(ErrorHandler.EnumErrorType.Critical, ex)
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------
        End Try
    End Sub

#End Region

#Region " ProgressBar Functions "

    Public Sub ShowProgressBar(ByVal message As String)
        '=====================================================================
        ' Procedure Name        : ShowProgressBar
        ' Parameters Passed     : message
        ' Returns               : None
        ' Purpose               : to show the progress bar
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : Saturday, January 22, 2005
        ' Revisions             : 
        '=====================================================================
        Try
            ProgressPanel.Value = 20
            StatusBarPanelInfo.Text = message
            'start a new thread to increment the progressbar
            Dim progressThread As New Thread(AddressOf BackGroundIncrementProgressBar)
            progressThread.IsBackground = True
            progressThread.Name = "Progress Bar"
            progressThread.Start()

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub BackGroundIncrementProgressBar()
        '=====================================================================
        ' Procedure Name        : BackGroundIncrementProgressBar
        ' Parameters Passed     : None
        ' Returns               : None 
        ' Purpose               : to increment the progress of progress bar
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : Saturday, January 22, 2005
        ' Revisions             : 
        '=====================================================================
        Try
            'note: this will run on a worker thread
            While ProgressPanel.Value <> 100
                If ProgressPanel.Value < 80 Then ProgressPanel.Value += 8
                Thread.Sleep(30)
            End While

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------
        End Try
    End Sub

    Public Sub HideProgressBar()
        '=====================================================================
        ' Procedure Name        : HideProgressBar
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : to finish the progress bar
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : Sunday, January 23, 2005
        ' Revisions             : 
        '=====================================================================
        Try
            'this sleep code is only eye candy but note that we must set m_ProgressBar.Value = 100
            'so that BackGroundIncrementProgressBar() can die
            Dim i As Integer
            For i = 0 To 16
                Thread.Sleep(30)
                Application.DoEvents()

                'show 100% for a glance
                If i = 15 Then ProgressPanel.Value = 100
            Next
            ProgressPanel.Value = 0
            'ProgressPanel.Text = Application.ProductName & Space(1) & Application.ProductVersion   'Commented by Saurabh 29.07.07
            ProgressPanel.Text = gstrTitleInstrumentType & Space(1) & "S/W Ver. : " & Mid(Application.ProductVersion, 1, 4)     'Added by Saurabh 29.07.07

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------
        End Try
    End Sub

    Public Sub ShowRunTimeInfo(ByVal message As String)
        '=====================================================================
        ' Procedure Name        : ShowProgressBar
        ' Parameters Passed     : message
        ' Returns               : None
        ' Purpose               : to show the progress bar
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : Saturday, January 22, 2005
        ' Revisions             : 
        '=====================================================================
        Try
            'ProgressPanel.Value = 20
            StatusBarPanelInfo.Text = message
            'start a new thread to increment the progressbar
            'Dim progressThread As New Thread(AddressOf BackGroundIncrementProgressBar)
            'progressThread.IsBackground = True
            'progressThread.Name = "Progress Bar"
            'progressThread.Start()

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------
        End Try
    End Sub

#End Region

#Region " IClient Events for receiving the wavelength and Abs value from Receiving thread "

    Private Sub TaskStarted(ByVal BgThread As clsBgThread) _
        Implements BgThread.Iclient.Start
        Try
            'mblnAvoidProcessing = True
            mblnSpectrumStarted = True
            'func_Enable_Disable(EnumProcesses.StartScan, EnumStart_End.Process_Running)
        Catch ex As Exception
            'gFuncShowMessage("Communication Error...", "Error in starting spectrum scanning.", modConstants.EnumMessageType.Information)
            '---------------------------------------------------------
            'Error logging
            'gobjErrorHandler.ErrorDescription = ex.Message
            'gobjErrorHandler.ErrorMessage = ex.Message
            'gobjErrorHandler.WriteErrorLog(ex)
            'gobjErrorHandler.ProcessError(ErrorHandler.EnumErrorType.Critical, ex)
            '---------------------------------------------------------
        Finally

            '    '---------------------------------------------------------
            '    'Writing Execution log
            '    If CONST_CREATE_EXECUTION_LOG = 1 Then
            '        gobjErrorHandler.WriteExecutionLog()
            '    End If
            '    '---------------------------------------------------------
        End Try

    End Sub

    Private Sub TaskStatus(ByVal Text As String) _
        Implements Iclient.Display
        Try
            'If gstructApplicationSessionState.intInstrument_Group = EnumInstrumentGroup.Initialize_2600_2700 Then
            Call funcIclientTaskDisplayData(Text)
            If Not (mobjclsBgSpectrum Is Nothing) Then
                mobjclsBgSpectrum.EndProcess = True
            End If
            'ElseIf gstructApplicationSessionState.intInstrument_Group = EnumInstrumentGroup.Initialize_2100_2200_2300 Then
            'Call funcIclientTaskDisplay2100(Text)
            'End If


        Catch ex As Exception
            'gFuncShowMessage("Error...", "Error in displaying the spectrum on the screen.", modConstants.EnumMessageType.Information)
            '---------------------------------------------------------
            'Error logging
            'gobjErrorHandler.ErrorDescription = ex.Message
            'gobjErrorHandler.ErrorMessage = ex.Message
            'gobjErrorHandler.WriteErrorLog(ex)
            'gobjErrorHandler.ProcessError(ErrorHandler.EnumErrorType.Critical, ex)
            '---------------------------------------------------------
        Finally
            ''---------------------------------------------------------
            ''Writing Execution log
            'If CONST_CREATE_EXECUTION_LOG = 1 Then
            '    gobjErrorHandler.WriteExecutionLog()
            'End If
            ''--------------------------------------------------------
            Application.DoEvents()
        End Try

    End Sub


    ' commented Iclient.Display before implementation of UV2100
    'Implements Iclient.Display
    '    Try
    ''-----------------------------------------------------
    ''Data in the Text arg would be "Wavelength|Abs"
    ''-----------------------------------------------------
    'Dim objData As New Data
    'Dim arrData() As String
    'Dim O As Integer   ' same as in function funcSmoothgraphonline
    'Dim intCount As Integer

    ''--- Split the data for Wv and Abs
    '        arrData = Split(Text, "|")

    '        If arrData(0).Length > 0 And arrData(1).Length > 0 And arrData(2).Length > 0 Then

    '            objData.XaxisData = Format(Val(arrData(0)), "#000.0")  ' wv

    '            Select Case mobjTemporaryChannel.Parameter.ScanMode
    '                Case EnumScanMode.Absorbance
    '                    objData.YaxisData = Format(Val(arrData(1)), "#0.000")
    '                Case EnumScanMode.Transmittance
    '                    objData.YaxisData = Format(Val(arrData(1)), "#0.0")
    '                Case EnumScanMode.Energy
    '                    objData.YaxisData = Format(Val(arrData(1)), "#0.0")
    '            End Select

    '            O = (ORDER - 1) / 2

    '            If Val(arrData(2)) = EnumUVProtocol.Data Then

    ''--- Add the reading to the temp readings collection
    '                mobjTemporaryReadings.Add(objData)

    '                lblOnlineWv.Text = Format(mobjTemporaryReadings.item(mobjTemporaryReadings.Count - 1).XaxisData, "#000.0")

    '                Select Case mobjTemporaryChannel.Parameter.ScanMode
    '                    Case EnumScanMode.Absorbance
    '                        lblOnlineABS.Text = Format(mobjTemporaryReadings.item(mobjTemporaryReadings.Count - 1).YaxisData, "#0.000")
    '                    Case EnumScanMode.Transmittance, EnumScanMode.Energy
    '                        lblOnlineABS.Text = Format(mobjTemporaryReadings.item(mobjTemporaryReadings.Count - 1).YaxisData, "#0.0")
    '                End Select


    '                If gblnSmoothFlag Then
    '                    If mobjTemporaryReadings.Count < ORDER Then
    '                        NPSmoothningdata(mobjTemporaryReadings.Count) = objData.YaxisData
    '                    End If

    '                    If (mobjTemporaryReadings.Count - 1) < ((ORDER - 1) / 2) Then

    '                        funcDisplayGraph_RealTime(mobjTemporaryReadings.item(mobjTemporaryReadings.Count - 1).XaxisData, _
    '                                                  mobjTemporaryReadings.item(mobjTemporaryReadings.Count - 1).YaxisData)

    '                    ElseIf mobjTemporaryReadings.Count >= ORDER Then
    '                        gfuncSmoothOnlineGraph(mobjTemporaryReadings, NPSmoothningdata)
    '                        funcDisplayGraph_RealTime(mobjTemporaryReadings.item((mobjTemporaryReadings.Count - 1) - O).XaxisData, _
    '                                                  mobjTemporaryReadings.item((mobjTemporaryReadings.Count - 1) - O).YaxisData)
    '                    End If
    '                Else  ' if not gblnsmoothgraph then there is no need to smooth the graph
    '                    funcDisplayGraph_RealTime(mobjTemporaryReadings.item(mobjTemporaryReadings.Count - 1).XaxisData, _
    '                                              mobjTemporaryReadings.item(mobjTemporaryReadings.Count - 1).YaxisData)
    '                End If
    '            End If

    '            If Val(arrData(2)) = EnumUVProtocol.CMD_End _
    '            Or Val(arrData(2)) = EnumUVProtocol.Spect_End _
    '            Or Val(arrData(2)) = EnumUVProtocol.CMD_Acknowledge Then

    '                If gblnSmoothFlag Then
    '                    For intCount = (((ORDER - 1) / 2) - 1) To 0 Step -1
    '                        funcDisplayGraph_RealTime(mobjTemporaryReadings.item((mobjTemporaryReadings.Count - 1) - intCount).XaxisData, _
    '                                                  mobjTemporaryReadings.item((mobjTemporaryReadings.Count - 1) - intCount).YaxisData)
    '                    Next
    '                End If
    '            End If
    '        End If

    '    Catch ex As Exception
    '        gFuncShowMessage("Error...", "Error in displaying the Spectrum on the screen.", modConstants.EnumMessageType.Information)
    ''---------------------------------------------------------
    ''Error logging
    ''gobjErrorHandler.ErrorDescription = ex.Message
    ''gobjErrorHandler.ErrorMessage = ex.Message
    ''gobjErrorHandler.WriteErrorLog(ex)
    ''gobjErrorHandler.ProcessError(ErrorHandler.EnumErrorType.Critical, ex)
    ''---------------------------------------------------------
    '    Finally
    '''---------------------------------------------------------
    '''Writing Execution log
    ''If CONST_CREATE_EXECUTION_LOG = 1 Then
    ''    gobjErrorHandler.WriteExecutionLog()
    ''End If
    '''--------------------------------------------------------

    '    End Try

    'End Sub

    Private Sub TaskFailed(ByVal e As Exception) _
        Implements Iclient.Failed
        Try
            '--- Dispose all the objects
            'mobjTemporaryChannel = New Channel
            'mobjTemporaryReadings = New Readings
            'mobjTemporaryReadings_2100 = New Readings
            funcIclientTaskFalied()

            mblnSpectrumStarted = False
            mblnAvoidProcessing = False
            Call mnuExit_Click(btnReturn, EventArgs.Empty)
            'gFuncShowMessage("Error...", "Spectrum scanning failed.", modConstants.EnumMessageType.Information)

        Catch ex As Exception
            '---------------------------------------------------------
            'Error logging
            'gobjErrorHandler.ErrorDescription = ex.Message
            'gobjErrorHandler.ErrorMessage = ex.Message
            'gobjErrorHandler.WriteErrorLog(ex)
            'gobjErrorHandler.ProcessError(ErrorHandler.EnumErrorType.Critical, ex)
            '---------------------------------------------------------
        Finally
            ''---------------------------------------------------------
            ''Writing Execution log
            'If CONST_CREATE_EXECUTION_LOG = 1 Then
            '    gobjErrorHandler.WriteExecutionLog()
            'End If
            ''---------------------------------------------------------
            'funcTimerStartStop(mTimer, EnumTimerStartStop.Timer_Start)
            'Call SubDisplayScanModeLabel(mobjParameters, True)
            mblnAvoidProcessing = False
            'func_Enable_Disable(EnumProcesses.StartScan, EnumStart_End.End_of_Process)
        End Try

    End Sub

    Private Sub TaskCompleted(ByVal Cancelled As Boolean) _
             Implements Iclient.Completed

        Try
            'If gstructApplicationSessionState.intInstrument_Group = EnumInstrumentGroup.Initialize_2600_2700 Then
            '    'Call funcIclientTaskCompleted2600()
            'ElseIf gstructApplicationSessionState.intInstrument_Group = EnumInstrumentGroup.Initialize_2100_2200_2300 Then
            '    'Call funcIclientTaskCompleted2100()
            'End If
            Call funcIclientTaskCompleted()

            mblnSpectrumStarted = False
            mblnAvoidProcessing = False
            Call mnuExit_Click(btnReturn, EventArgs.Empty)

        Catch ex As Exception
            '---------------------------------------------------------
            'Error logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)

            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            mblnAvoidProcessing = False
            '---------------------------------------------------------

        End Try

    End Sub

#End Region

#Region " IClient Private Functions "

    Private Function funcIclientTaskCompleted() As Boolean
        '=====================================================================
        ' Procedure Name        :   funcIclientTaskCompleted2600
        ' Description           :   task completed received from instrument 
        '                           
        ' Purpose               :   
        ' Parameters Passed     :  
        ' Returns               :   True, if successful.
        ' Parameters Affected   :   
        ' Assumptions           :   None.
        ' Dependencies          :   None.
        ' Author                :   Sachin Dokhale
        ' Created               :   17.12.06
        ' Revisions             :
        '=====================================================================

        Try
            funcIclientTaskCompleted = False

            ' If scan is terminated by user in between then gblnSpectrumTerminated = True
            If Not ArrlstGraphCurveItem Is Nothing Then
                If ArrlstGraphCurveItem.Count >= intCurveIndex + 1 Then
                    AASGraphTimeScan.StopOnlineGraph(ArrlstGraphCurveItem(intCurveIndex))
                    intCurveIndex += 1
                End If
            End If
            Application.DoEvents()

            AASGraphTimeScan.AldysPane.AxisChange()
            AASGraphTimeScan.Refresh()

            If Not funcSpectrumReadingCompleted() Then

            End If

            If gblnSpectrumTerminated = True Then
                funcScanCompleted(False)
            Else 'scan is completed 
                funcScanCompleted(True)
            End If
            'btnReturn.Text = "&Return"
            'btnReturn.Refresh()
            funcIclientTaskCompleted = True

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
            Return False
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------
        End Try
    End Function

    Private Function funcIclientTaskFalied() As Boolean
        '=====================================================================
        ' Procedure Name        :   funcIclientTaskFalied
        ' Description           :   task falied received from instrument 
        '                           
        ' Purpose               :   
        ' Parameters Passed     :  
        ' Returns               :   True, if successful.
        ' Parameters Affected   :   
        ' Assumptions           :   None.
        ' Dependencies          :   None.
        ' Author                :   Sachin Dokhale
        ' Created               :   18.12.06
        ' Revisions             :
        '=====================================================================

        Try
            funcIclientTaskFalied = False

            ' If scan is terminated by user in between then gblnSpectrumTerminated = True
            If ArrlstGraphCurveItem.Count >= intCurveIndex + 1 Then
                AASGraphTimeScan.StopOnlineGraph(ArrlstGraphCurveItem(intCurveIndex))
                'intCurveIndex += 1
            End If


            Application.DoEvents()
            AASGraphTimeScan.AldysPane.AxisChange()
            AASGraphTimeScan.Refresh()

            funcScanCompleted(False)

            Application.DoEvents()
            'gFuncShowMessage("Error...", "Scanning failed.", EnumMessageType.Information)'113
            mblnSpectrumStarted = False
            'btnReturn.Text = "&Return"
            'btnReturn.Refresh()
            funcIclientTaskFalied = True

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
            Return False
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------

        End Try
    End Function

    Private Function funcScanCompleted(ByVal blnCompleted As Boolean) As Boolean
        '=====================================================================
        ' Procedure Name        :   funcScanCompleted
        ' Description           :   if scan completed ot terminated by user
        ' Purpose               :   
        ' Parameters Passed     :   blnCompleted is true if completed successfully 
        '                          & false if terminated by user
        ' Returns               :   True, if successful.
        ' Parameters Affected   :   
        ' Assumptions           :   None.
        ' Dependencies          :   None.
        ' Author                :   Sachin Dokhale
        ' Created               :   Tuesday, April 06, 2004 18:36
        ' Revisions             :
        '=====================================================================

        Try

            If blnCompleted Then
                'lblScanStatus.Text = "Scanning completed..."
            Else
                'lblScanStatus.Text = "Scan terminated..."
                'lblScanStatus.Refresh()
                'lblRepeats.Text = "Terminated"
                'lblRepeats.Refresh()
            End If


            'Call SubDisplayScanModeLabel(mobjParameters, True)
            'btnStart.Text = "&Start"
            'btnStart.Enabled = True
            'btnStart.Refresh()

            'funcTimerStartStop(mTimer, EnumTimerStartStop.Timer_Start)

            'func_Enable_Disable(EnumProcesses.StartScan, EnumStart_End.End_of_Process)

            gblnSpectrumTerminated = False
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
            Return False
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            Me.Cursor = Cursors.Default
            Application.DoEvents()
            '---------------------------------------------------------

        End Try

    End Function

    Private Function funcSpectrumReadingCompleted() As Boolean
        '=====================================================================
        ' Procedure Name        :   funcSpectrumReadingCompleted
        ' Description           :   Add the temp channel to the channels collection
        '                           and save the channel file to the respective 
        '                           Location.
        ' Purpose               :   To add the temporary channel to the 
        '                           channels collection.
        ' Parameters Passed     :   None.
        ' Returns               :   True, if successful.
        ' Parameters Affected   :   
        ' Assumptions           :   None.
        ' Dependencies          :   None.
        ' Author                :   Sachin Dokhale
        ' Created               :   sunday, November 15, 2003 18:49
        ' Revisions             :
        '=====================================================================

        Dim objSpectrumData As New Spectrum.SpectrumData
        Dim intChannel_no As Integer
        Dim objReadings As New Spectrum.Readings
        Try

            '--- Add the analysis data in the serial manner in the 
            '--- collection and make the collection of the size as
            '--- max size=9901
            If Not mobjSpectrum.funcAddSpecDataToChannel(mobjOnlineReadings, objReadings) Then
                'gFuncShowMessage("Error...", "Error in adding the spectrum data to the current channel.", EnumMessageType.Information)'114
            End If

            '--- Add the channel to the channels collection
            objSpectrumData.Readings = objReadings
            mobjOnlineChannel.Spectrums.Add(objSpectrumData)

            '--- Add the new channel to the channels collection and 
            '--- accordingly save the channel file to the disk
            intChannel_no = funcAddChannelToCollection(mobjOnlineChannel)
            mintChannelIndex = intChannel_no


            'mintMinValue_Of_Channel = 0                   '--- modf by Nilesh on 3/02/04
            'mintMaxValue_Of_Channel = mobjChannnels.Count '--- modf by Nilesh on 3/02/04

            'NumUpDwn.Text = mobjTemporaryChannel.ChannelNo '--- modf by Nilesh on 3/02/04

            '--- Reset the temporary channel object
            mobjOnlineChannel = Nothing
            mobjOnlineReadings = Nothing


            Return True

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            'gobjErrorHandler.ProcessError(.EnumErrorType.Critical, ex)
            '---------------------------------------------------------
            Return False
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------
        End Try

    End Function

    'Private Function funcIclientTaskDisplayData(ByVal strData As String) As Boolean
    '    Try
    '        '-----------------------------------------------------
    '        'Data in the Text arg would be "Wavelength|Abs"
    '        '-----------------------------------------------------
    '        Dim objData As New Spectrum.Data
    '        Dim arrData() As String
    '        Dim O As Integer   ' same as in function funcSmoothgraphonline
    '        Dim intCount As Integer

    '        '--- Split the data for Wv and Abs
    '        arrData = Split(strData, "|")

    '        If arrData(0).Length > 0 And arrData(1).Length > 0 Then

    '            objData.XaxisData = Format(Val(arrData(0)), "#000.0")   ' wv

    '            'Select Case mobjTemporaryChannel.Parameter.ScanMode
    '            '    Case EnumScanMode.Absorbance
    '            '        objData.YaxisData = Format(Val(arrData(1)), "#0.000")
    '            '    Case EnumScanMode.Transmittance
    '            '        objData.YaxisData = Format(Val(arrData(1)), "#0.0")
    '            '    Case EnumScanMode.Energy
    '            '        objData.YaxisData = Format(Val(arrData(1)), "#0.0")
    '            'End Select

    '            objData.YaxisData = Format(Val(arrData(1)), "#0.0")

    '            'O = (ORDER - 1) / 2

    '            'If Val(arrData(2)) = 1 Then  'EnumUVProtocol.Data Then

    '            '--- Add the reading to the temp readings collection

    '            mobjOnlineReadings.Add(objData)


    '            'lblOnlineWv.Text = Format(mobjTemporaryReadings.item(mobjTemporaryReadings.Count - 1).XaxisData, "#000.0")


    '            'Select Case mobjTemporaryChannel.Parameter.ScanMode
    '            '    Case EnumScanMode.Absorbance
    '            '        lblOnlineABS.Text = Format(mobjTemporaryReadings.item(mobjTemporaryReadings.Count - 1).YaxisData, "#0.000")
    '            '    Case EnumScanMode.Transmittance, EnumScanMode.Energy
    '            '        lblOnlineABS.Text = Format(mobjTemporaryReadings.item(mobjTemporaryReadings.Count - 1).YaxisData, "#0.0")
    '            'End Select

    '            funcDisplayGraph_RealTime(objData.XaxisData, objData.YaxisData)
    '            'If gblnSmoothFlag Then
    '            'If mobjTemporaryReadings.Count < ORDER Then
    '            '    NPSmoothningdata(mobjTemporaryReadings.Count) = objData.YaxisData
    '            'End If

    '            'If (mobjTemporaryReadings.Count - 1) < ((ORDER - 1) / 2) Then

    '            '    funcDisplayGraph_RealTime(mobjTemporaryReadings.item(mobjTemporaryReadings.Count - 1).XaxisData, _
    '            '                              mobjTemporaryReadings.item(mobjTemporaryReadings.Count - 1).YaxisData)

    '            'ElseIf mobjTemporaryReadings.Count >= ORDER Then
    '            '    gfuncSmoothOnlineGraph(mobjTemporaryReadings, NPSmoothningdata)
    '            '    funcDisplayGraph_RealTime(mobjTemporaryReadings.item((mobjTemporaryReadings.Count - 1) - O).XaxisData, _
    '            '                              mobjTemporaryReadings.item((mobjTemporaryReadings.Count - 1) - O).YaxisData)
    '            'End If
    '            'Else  ' if not gblnsmoothgraph then there is no need to smooth the graph
    '            'funcDisplayGraph_RealTime(mobjTemporaryReadings.item(mobjTemporaryReadings.Count - 1).XaxisData, _
    '            '                          mobjTemporaryReadings.item(mobjTemporaryReadings.Count - 1).YaxisData)
    '            'End If
    '            'End If

    '            'If Val(arrData(2)) = EnumUVProtocol.CMD_End _
    '            'Or Val(arrData(2)) = EnumUVProtocol.Spect_End _
    '            'Or Val(arrData(2)) = EnumUVProtocol.CMD_Acknowledge Then

    '            'If Val(arrData(2)) = 0 Then 'EnumUVProtocol.CMD_End _


    '            'End If

    '            'If gblnSmoothFlag Then
    '            '    For intCount = (((ORDER - 1) / 2) - 1) To 0 Step -1
    '            '        funcDisplayGraph_RealTime(mobjTemporaryReadings.item((mobjTemporaryReadings.Count - 1) - intCount).XaxisData, _
    '            '                                  mobjTemporaryReadings.item((mobjTemporaryReadings.Count - 1) - intCount).YaxisData)
    '            '    Next
    '            'End If
    '            'End If
    '        End If

    '    Catch ex As Exception
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = ex.Message
    '        gobjErrorHandler.WriteErrorLog(ex)
    '        '---------------------------------------------------------
    '    Finally
    '        ''---------------------------------------------------------
    '        ''Writing Execution log
    '        'If CONST_CREATE_EXECUTION_LOG = 1 Then
    '        '    gobjErrorHandler.WriteExecutionLog()
    '        'End If
    '        ''--------------------------------------------------------

    '    End Try
    'End Function

    Private Function funcIclientTaskDisplayData(ByVal strData As String) As Boolean
        Try
            '-----------------------------------------------------
            'Data in the Text arg would be "Wavelength|Abs"
            '-----------------------------------------------------
            Dim objData As New Spectrum.Data
            Dim arrData() As String
            Dim O As Integer   ' same as in function funcSmoothgraphonline
            Dim intCount As Integer
            Dim YaxisData_Sample As Double
            Dim YaxisData_Ref As Double
            Dim YaxisData_Double As Double
            Dim XaxisData As Double

            '--- Split the data for Wv and Abs
            Application.DoEvents()
            arrData = Split(strData, "|")

            If arrData(0).Length > 0 And arrData(1).Length > 0 Then

                XaxisData = Format(Val(arrData(0)), "#000.0")   ' wv

                'YaxisData_Sample = Format(Val(arrData(1)), "#0.00000")
                'If arrData.GetUpperBound(0) > 1 Then
                '    YaxisData_Ref = Format(Val(arrData(2)), "#0.00000")
                'End If
                'If arrData.GetUpperBound(0) > 2 Then
                '    YaxisData_Double = Format(Val(arrData(3)), "#0.00000")
                'End If
                YaxisData_Sample = Val(arrData(1))
                If arrData.GetUpperBound(0) > 1 Then
                    YaxisData_Ref = Val(arrData(2))
                Else
                    YaxisData_Ref = 0.0
                End If
                If arrData.GetUpperBound(0) > 2 Then
                    YaxisData_Double = Val(arrData(3))
                Else
                    YaxisData_Double = 0.0
                End If


                If Not (mobjOnlineReadings Is Nothing) Then
                    mobjOnlineReadings.Add(objData)
                    funcDisplayGraph_RealTime(XaxisData, YaxisData_Sample, YaxisData_Ref, YaxisData_Double)
                End If
                '           
            End If

        Catch ex As Exception
            '---------------------------------------------------------
            'Error logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            'gobjErrorHandler.ProcessError(ErrorHandler.EnumErrorType.Critical, ex)
            '---------------------------------------------------------
        Finally
            ''---------------------------------------------------------
            ''Writing Execution log
            'If CONST_CREATE_EXECUTION_LOG = 1 Then
            '    gobjErrorHandler.WriteExecutionLog()
            'End If
            ''--------------------------------------------------------

        End Try
    End Function

#End Region

#Region " Graph Methods "

    Private Function funcGraphPreRequisite(ByVal intScanmode As Integer, ByVal intXmin As Double, ByVal intXmax As Double, ByVal intYmin As Double, ByVal intYmax As Double) As Boolean
        Dim dblDiffX As Double
        Dim dblMajorStepX, dblMinorStepX As Double
        Dim dblDiffY As Double
        Dim dblMajorStepY, dblMinorStepY As Double

        Try
            dblDiffX = Fix(intXmax - intXmin)
            dblMajorStepX = dblDiffX / 10
            dblMinorStepX = dblMajorStepX / 2

            dblDiffY = (intYmax - intYmin)
            dblMajorStepY = dblDiffY / 10
            dblMinorStepY = dblMajorStepY / 2

            AASGraphTimeScan.btnPeakEdit.Enabled = False
            AASGraphTimeScan.btnShowXYValues.Enabled = False
            AASGraphTimeScan.btnLegends.Enabled = False

            AASGraphTimeScan.XAxisMin = intXmin
            AASGraphTimeScan.XAxisMax = intXmax
            AASGraphTimeScan.AldysPane.XAxis.Min = intXmin
            AASGraphTimeScan.AldysPane.XAxis.Max = intXmax

            '--- Display the axis lables
            AASGraphTimeScan.XAxisLabel = "TIME(seconds)"
            'AxEnergySpectrum.XAxisLabel = "  Energy"

            Select Case gobjInst.Mode
                Case EnumCalibrationMode.AA, EnumCalibrationMode.AABGC, EnumCalibrationMode.MABS
                    AASGraphTimeScan.YAxisMin = intYmin
                    AASGraphTimeScan.YAxisMax = intYmax

                    AASGraphTimeScan.YAxisLabel = "ABSORBANCE"
                Case EnumCalibrationMode.HCLE, EnumCalibrationMode.D2E
                    AASGraphTimeScan.YAxisMin = intYmin
                    AASGraphTimeScan.YAxisMax = intYmax
                    AASGraphTimeScan.YAxisLabel = "ENERGY"

                Case EnumCalibrationMode.EMISSION
                    AASGraphTimeScan.YAxisMin = intYmin
                    AASGraphTimeScan.YAxisMax = intYmax


                    AASGraphTimeScan.YAxisLabel = "EMISSION"
                Case EnumCalibrationMode.SELFTEST
                    AASGraphTimeScan.YAxisMin = intYmin
                    AASGraphTimeScan.YAxisMax = intYmax
                    AASGraphTimeScan.YAxisLabel = "VOLT(mV)"
            End Select
            AASGraphTimeScan.YAxisLabel = mYAXIS_LABEL
            
            '//----- Set auto Steps of axis
            AASGraphTimeScan.AldysPane.XAxis.Step = dblMajorStepX
            AASGraphTimeScan.AldysPane.XAxis.MinorStep = dblMinorStepX
            AASGraphTimeScan.AldysPane.YAxis.Step = dblMajorStepY
            AASGraphTimeScan.AldysPane.YAxis.MinorStep = dblMinorStepY

            AASGraphTimeScan.XAxisStep = dblMajorStepX
            AASGraphTimeScan.YAxisStep = dblMajorStepY
            AASGraphTimeScan.XAxisMinorStep = dblMinorStepX
            AASGraphTimeScan.YAxisMinorStep = dblMinorStepY
            '------------Added by Pankaj on 8 May 07
            AASGraphTimeScan.XAxisMin = mobjParameters.XaxisMin
            AASGraphTimeScan.XAxisMax = mobjParameters.XaxisMax

            AASGraphTimeScan.YAxisMin = mobjParameters.YaxisMin
            AASGraphTimeScan.YAxisMax = mobjParameters.YaxisMax

            gobjClsAAS203.Calculate_Analysis_Graph_Param(AASGraphTimeScan, ClsAAS203.enumChangeAxis.xyAxis)
            '------------

            '//-----
            If Not gstructSettings.IsCustomerDisplayMode Then
                'AASGraphTimeScan.AldysPane.Legend.IsVisible = True     Commented by Saurabh 05.08.07
                'AASGraphTimeScan.AldysPane.Legend.IsVisible = True
            End If
            'mnuGrid.Checked = True
            Me.AASGraphTimeScan.IsShowGrid = True
            mnuGrid.Checked = Me.AASGraphTimeScan.IsShowGrid
            Me.AASGraphTimeScan.btnPeakEdit.Checked = False
            AASGraphTimeScan.AldysPane.AxisChange()
            AASGraphTimeScan.Refresh()
            Application.DoEvents()
            Call funcOnlineGraphPrereq()
            Return True
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)

            '---------------------------------------------------------
            Return False
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------
        End Try

    End Function

    Private Function funcGraphPreRequisite(ByVal intScanmode As Integer, ByVal intYmin As Double, ByVal intYmax As Double) As Boolean
        '=====================================================================
        ' Procedure Name        :   funcGraphPreRequisite
        ' Description           :   Prepare graph for plotting
        ' Purpose               :   
        ' Parameters Passed     :   intScanmode, intYmin, intYmax
        ' Returns               :   True, if successful.
        ' Parameters Affected   :   
        ' Assumptions           :   
        ' Dependencies          :   None.
        ' Author                :   Sachin Dokhale 
        ' Created               :   12.12.06
        ' Revisions             :
        '=====================================================================
        Dim dblDiffX As Double
        Dim dblMajorStepX, dblMinorStepX As Double
        Dim dblDiffY As Double
        Dim dblMajorStepY, dblMinorStepY As Double

        Try

            dblDiffY = (intYmax - intYmin)
            dblMajorStepY = dblDiffY / 10
            dblMinorStepY = dblMajorStepY / 2

            '--- Display the axis lables
            'AxEnergySpectrum.XAxisLabel = "  Energy"
            AASGraphTimeScan.btnPeakEdit.Enabled = False
            AASGraphTimeScan.btnShowXYValues.Enabled = False
            AASGraphTimeScan.btnLegends.Enabled = False
            Select Case gobjInst.Mode
                Case EnumCalibrationMode.AA, EnumCalibrationMode.AABGC, EnumCalibrationMode.MABS
                    AASGraphTimeScan.YAxisMin = intYmin
                    AASGraphTimeScan.YAxisMax = intYmax
                    AASGraphTimeScan.YAxisLabel = "ABSORBANCE"
                Case EnumCalibrationMode.HCLE, EnumCalibrationMode.D2E
                    AASGraphTimeScan.YAxisMin = intYmin
                    AASGraphTimeScan.YAxisMax = intYmax
                    AASGraphTimeScan.YAxisLabel = "ENERGY"

                Case EnumCalibrationMode.EMISSION
                    AASGraphTimeScan.YAxisMin = intYmin
                    AASGraphTimeScan.YAxisMax = intYmax
                    AASGraphTimeScan.YAxisLabel = "EMISSION"
                Case EnumCalibrationMode.SELFTEST
                    AASGraphTimeScan.YAxisMin = intYmin
                    AASGraphTimeScan.YAxisMax = intYmax
                    AASGraphTimeScan.YAxisLabel = "VOLT(mV)"
            End Select

            '//----- Set auto Steps of axis
            AASGraphTimeScan.AldysPane.YAxis.Step = dblMajorStepY
            AASGraphTimeScan.AldysPane.YAxis.MinorStep = dblMinorStepY
            AASGraphTimeScan.AldysPane.YAxis.IsMinorTic = True
            AASGraphTimeScan.AldysPane.YAxis.IsTic = True

            AASGraphTimeScan.YAxisStep = dblMajorStepY
            AASGraphTimeScan.YAxisMinorStep = dblMinorStepY
            '//-----
            '------------Added by Pankaj on 8 May 07
            'AASGraphTimeScan.XAxisMin = mobjParameters.XaxisMin
            'AASGraphTimeScan.XAxisMax = mobjParameters.XaxisMax
            'AASGraphTimeScan.YAxisMin = mobjParameters.YaxisMin
            'AASGraphTimeScan.YAxisMax = mobjParameters.YaxisMax
            '------------Added by Pankaj on 8 May 07
            AASGraphTimeScan.XAxisMin = mobjParameters.XaxisMin
            AASGraphTimeScan.XAxisMax = mobjParameters.XaxisMax

            AASGraphTimeScan.YAxisMin = mobjParameters.YaxisMin
            AASGraphTimeScan.YAxisMax = mobjParameters.YaxisMax

            gobjClsAAS203.Calculate_Analysis_Graph_Param(AASGraphTimeScan, ClsAAS203.enumChangeAxis.xyAxis)

            'gobjClsAAS203.Calculate_Analysis_Graph_Param(AASGraphTimeScan, ClsAAS203.enumChangeAxis.yAxis)
            '------------
            Me.AASGraphTimeScan.btnPeakEdit.Checked = False
            AASGraphTimeScan.AldysPane.AxisChange()
            AASGraphTimeScan.Refresh()
            Application.DoEvents()
            Call funcOnlineGraphPrereq()
            '//---------------------
            Return True
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)

            '---------------------------------------------------------
            Return False
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------
        End Try
    End Function

    'Private Function funcDisplayGraph_RealTime(ByVal dblXAxis As Double, _
    '                                            ByVal dblYAxis_Sample As Double, _
    '                                            ByVal dblYAxis_Ref As Double, _
    '                                            ByVal dblYAxis_Double As Double) As Boolean
    '    '=====================================================================
    '    ' Procedure Name        :   funcDisplayGraph_RealTime
    '    ' Description           :   Plot the graph on the screen.
    '    ' Purpose               :   To plot the graph on the screen for the given
    '    '                           Wavelength and absorbtion.           
    '    ' Parameters Passed     :   None.
    '    ' Returns               :   True, if successful.
    '    ' Parameters Affected   :   
    '    ' Assumptions           :   Graph pre-requisites are already been set.
    '    ' Dependencies          :   None.
    '    ' Author                :   Sachin Dokhale 
    '    ' Created               :   10.12.06
    '    ' Revisions             :
    '    '=====================================================================
    '    Dim lngX_Axis As Long
    '    Dim dblToYSample As Double
    '    Dim dblToYRef As Double
    '    Dim dblToYDouble As Double

    '    Dim tval As Long
    '    Dim dblDiffX As Double
    '    Dim dblMajorStepX, dblMinorStepX As Double
    '    Dim dblDiffY As Double
    '    Dim dblMajorStepY, dblMinorStepY As Double
    '    Dim lngIdx As Long
    '    Dim MaxXaxis As Long
    '    Dim MinXaxis As Long
    '    Static blnISSetShown_DBeam As Boolean = False
    '    Try
    '        Application.DoEvents()
    '        '--- Plot the graph for the given coordinates.
    '        lngX_Axis = CLng(dblXAxis)
    '        dblToYSample = dblYAxis_Sample
    '        dblToYRef = dblYAxis_Ref
    '        dblToYDouble = dblYAxis_Double

    '        '--- Check if the X-coordinates and Y-coordinates are less than
    '        '--- Xmin and Ymin

    '        'dblYAxis = dblToY

    '        '//------ to see the time lable only required to lable visiable property with "True"
    '        'lblTime.Text = "Time (Sc.) : " & Format(lngX_Axis, "#0")
    '        lblTime.Text = "Time (Sec.) : " & Format(dblXAxis, "#0.00#")
    '        lblYAxis.Text = mYValueLable

    '        '---the following condition is added by deepak on 20.07.07
    '        If gstructSettings.IsCustomerDisplayMode = True Then
    '            lblYValue.Text = Trim(lblYAxis.Text) & " : " & Format(dblYAxis_Double, "#0.000")
    '        Else
    '            If (Not gintInstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.SingleBeam) And _
    '            (gobjInst.Mode = EnumCalibrationMode.AA) Then
    '                lblYValue.Text = const_Sample & " : " & Format(dblYAxis_Sample, "#0.000")
    '                lblYValue_Ref.Text = const_Reference & " : " & Format(dblYAxis_Ref, "#0.000")
    '                lblYValue_Double.Text = const_Double & " : " & Format(dblYAxis_Double, "#0.000")
    '            Else
    '                lblYValue.Text = const_Sample & " : " & Format(dblYAxis_Sample, "#0.000")
    '            End If
    '        End If

    '        lblYAxis.Refresh()
    '        lblTime.Refresh()
    '        lblYValue.Refresh()
    '        lblYValue_Ref.Refresh()
    '        lblYValue_Double.Refresh()

    '        '--- Check if the wavelength is equal to the max wv


    '        If (lngX_Axis >= AASGraphTimeScan.XAxisMax) Then
    '            AASGraphTimeScan.AldysPane.AxisChange()
    '            AASGraphTimeScan.Refresh()

    '            dblDiffX = Fix(AASGraphTimeScan.XAxisMax - AASGraphTimeScan.XAxisMin)
    '            dblMajorStepX = dblDiffX / 10
    '            dblMinorStepX = dblMajorStepX / 2

    '            dblDiffY = Fix(AASGraphTimeScan.YAxisMax - AASGraphTimeScan.YAxisMin)
    '            dblMajorStepY = dblDiffY / 10
    '            dblMinorStepY = dblMajorStepY / 2

    '            mintChannelIndex = 0
    '            intCurveIndex = 0
    '            tval = (AASGraphTimeScan.XAxisMax - AASGraphTimeScan.XAxisMin)
    '            MaxXaxis = AASGraphTimeScan.XAxisMax
    '            MinXaxis = AASGraphTimeScan.XAxisMin

    '            If lngX_Axis > MaxXaxis Then
    '                For lngIdx = tval To lngX_Axis Step tval
    '                    'MinXaxis += tval
    '                Next
    '                MaxXaxis = lngIdx
    '                MinXaxis = MaxXaxis - tval
    '            Else
    '                MinXaxis = MaxXaxis
    '                MaxXaxis = MinXaxis + tval
    '            End If

    '            AASGraphTimeScan.XAxisMin = MinXaxis 'AASGraphTimeScan.XAxisMax
    '            AASGraphTimeScan.XAxisMax = MaxXaxis

    '            mobjParameters.XaxisMin = MinXaxis
    '            mobjParameters.XaxisMax = MaxXaxis

    '            '//----- Set auto Steps of axis
    '            AASGraphTimeScan.AldysPane.XAxis.Step = dblMajorStepX
    '            AASGraphTimeScan.AldysPane.XAxis.MinorStep = dblMinorStepX
    '            AASGraphTimeScan.XAxisStep = dblMajorStepX
    '            AASGraphTimeScan.XAxisMinorStep = dblMinorStepX
    '            '//-----
    '            'AASGraphTimeScan.Refresh()
    '            'Application.DoEvents()
    '            blnPlotingNew = False
    '        End If


    '        If blnPlotingNew = True Then
    '            mGraphCurveItem = Nothing
    '            'mGraphCurveItem = AASGraphTimeScan.StartOnlineGraph("Spectrum " & (intCurveIndex + 1).ToString, AASGraphTimeScan.GetColor(intCurveIndex), AldysGraph.SymbolType.NoSymbol)
    '            'ArrlstGraphCurveItem.Add(mGraphCurveItem)
    '            'AASGraphTimeScan.PlotPoint(ArrlstGraphCurveItem.Item(intCurveIndex), dblXAxis, dblYAxis)


    '            '//----- Sample Beam
    '            'following condition is added by deepak on 20.07.07
    '            If gstructSettings.IsCustomerDisplayMode = False Then
    '                If (Not gintInstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.SingleBeam) And _
    '                    (gobjInst.Mode = EnumCalibrationMode.AA) Then
    '                    intCurveIndex = 0
    '                    mGraphCurveItem = AASGraphTimeScan.StartOnlineGraph(const_Sample, AASGraphTimeScan.GetColor(intCurveIndex), AldysGraph.SymbolType.NoSymbol)
    '                    ArrlstGraphCurveItem.Add(mGraphCurveItem)
    '                    AASGraphTimeScan.PlotPoint(ArrlstGraphCurveItem.Item(intCurveIndex), dblXAxis, dblYAxis_Sample)
    '                End If
    '            End If

    '            '//----- Ref. Beam
    '            'following condition is added by deepak on 20.07.07
    '            If gstructSettings.IsCustomerDisplayMode = False Then
    '                If (Not gintInstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.SingleBeam) And _
    '                (gobjInst.Mode = EnumCalibrationMode.AA) Then
    '                    intCurveIndex += 1
    '                    mGraphCurveItem = AASGraphTimeScan.StartOnlineGraph(const_Reference, AASGraphTimeScan.GetColor(intCurveIndex), AldysGraph.SymbolType.NoSymbol)
    '                    ArrlstGraphCurveItem.Add(mGraphCurveItem)
    '                    AASGraphTimeScan.PlotPoint(ArrlstGraphCurveItem.Item(intCurveIndex), dblXAxis, dblYAxis_Ref)
    '                End If
    '            End If


    '            '//----- Double. Beam
    '            'If Not (gobjInst.Mode = EnumCalibrationMode.SELFTEST) Then
    '            'intCurveIndex += 1
    '            'following condition is added by deepak on 20.07.07
    '            If gstructSettings.IsCustomerDisplayMode = False Then
    '                intCurveIndex += 1
    '                mGraphCurveItem = AASGraphTimeScan.StartOnlineGraph(const_Double, AASGraphTimeScan.GetColor(intCurveIndex), AldysGraph.SymbolType.NoSymbol)
    '            Else
    '                intCurveIndex = 0
    '                mGraphCurveItem = AASGraphTimeScan.StartOnlineGraph("Double Beam Scan", AASGraphTimeScan.GetColor(intCurveIndex), AldysGraph.SymbolType.NoSymbol)
    '            End If
    '            'mGraphCurveItem = AASGraphTimeScan.StartOnlineGraph(const_Double, AASGraphTimeScan.GetColor(intCurveIndex), AldysGraph.SymbolType.NoSymbol)
    '            ArrlstGraphCurveItem.Add(mGraphCurveItem)
    '            AASGraphTimeScan.PlotPoint(ArrlstGraphCurveItem.Item(intCurveIndex), dblXAxis, dblYAxis_Double)
    '            mblnIsShowDBeam = True
    '            blnISSetShown_DBeam = False
    '            'Else
    '            'blnISSetShown_DBeam = True
    '            'End If
    '            blnPlotingNew = False
    '        Else

    '            'AASGraphTimeScan.PlotPoint(ArrlstGraphCurveItem.Item(intCurveIndex), dblXAxis, dblYAxis)
    '            'following condition is added by deepak on 20.07.07
    '            If gstructSettings.IsCustomerDisplayMode = False Then
    '                intCurveIndex = 0
    '                AASGraphTimeScan.PlotPoint(ArrlstGraphCurveItem.Item(intCurveIndex), dblXAxis, dblYAxis_Sample)
    '            End If


    '            'following condition is added by deepak on 20.07.07
    '            If gstructSettings.IsCustomerDisplayMode = False Then
    '                intCurveIndex += 1
    '                AASGraphTimeScan.PlotPoint(ArrlstGraphCurveItem.Item(intCurveIndex), dblXAxis, dblYAxis_Ref)
    '            End If

    '            '//----- Double. Beam
    '            If blnISSetShown_DBeam = True Then
    '                'If Not (gobjInst.Mode = EnumCalibrationMode.SELFTEST) Then
    '                'intCurveIndex += 1
    '                'intCurveIndex = 2
    '                'following condition is added by deepak on 20.07.07
    '                If gstructSettings.IsCustomerDisplayMode = False Then
    '                    intCurveIndex = 2
    '                Else
    '                    intCurveIndex = 0
    '                End If

    '                mGraphCurveItem = AASGraphTimeScan.StartOnlineGraph(const_Double, AASGraphTimeScan.GetColor(intCurveIndex), AldysGraph.SymbolType.NoSymbol)
    '                ArrlstGraphCurveItem.Add(mGraphCurveItem)
    '                '    AASGraphTimeScan.PlotPoint(ArrlstGraphCurveItem.Item(intCurveIndex), dblXAxis, dblYAxis_Double)
    '                blnISSetShown_DBeam = False
    '                mblnIsShowDBeam = True
    '                'End If
    '            End If
    '            'If Not (gobjInst.Mode = EnumCalibrationMode.SELFTEST) Then
    '            'intCurveIndex = 2
    '            'following condition is added by deepak on 20.07.07
    '            If gstructSettings.IsCustomerDisplayMode = False Then
    '                intCurveIndex = 2
    '            Else
    '                intCurveIndex = 0
    '            End If
    '            AASGraphTimeScan.PlotPoint(ArrlstGraphCurveItem.Item(intCurveIndex), dblXAxis, dblYAxis_Double)
    '            'End If
    '            AASGraphTimeScan.AldysPane.AxisChange()
    '        End If
    '        AASGraphTimeScan.Refresh()
    '        Application.DoEvents()
    '        Return True
    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        'Error Handling and logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = ex.Message
    '        gobjErrorHandler.WriteErrorLog(ex)
    '        '---------------------------------------------------------
    '        Return False
    '    Finally
    '        '---------------------------------------------------------
    '        'Writing Execution log
    '        If CONST_CREATE_EXECUTION_LOG = 1 Then
    '            gobjErrorHandler.WriteExecutionLog()
    '        End If
    '        '---------------------------------------------------------
    '    End Try

    'End Function

    Private Function funcDisplayGraph_RealTime(ByVal dblXAxis As Double, _
                                                ByVal dblYAxis_Sample As Double, _
                                                ByVal dblYAxis_Ref As Double, _
                                                ByVal dblYAxis_Double As Double) As Boolean
        '=====================================================================
        ' Procedure Name        :   funcDisplayGraph_RealTime
        ' Description           :   Plot the graph on the screen.
        ' Purpose               :   To plot the graph on the screen for the given
        '                           Wavelength and absorbtion.           
        ' Parameters Passed     :   None.
        ' Returns               :   True, if successful.
        ' Parameters Affected   :   
        ' Assumptions           :   Graph pre-requisites are already been set.
        ' Dependencies          :   None.
        ' Author                :   Sachin Dokhale 
        ' Created               :   10.12.06
        ' Revisions             :
        '=====================================================================
        Dim lngX_Axis As Long
        Dim dblToYSample As Double
        Dim dblToYRef As Double
        Dim dblToYDouble As Double

        Dim tval As Long
        Dim dblDiffX As Double
        Dim dblMajorStepX, dblMinorStepX As Double
        Dim dblDiffY As Double
        Dim dblMajorStepY, dblMinorStepY As Double
        Dim lngIdx As Long
        Dim MaxXaxis As Long
        Dim MinXaxis As Long
        Static blnISSetShown_DBeam As Boolean = False
        Try
            Application.DoEvents()
            '--- Plot the graph for the given coordinates.
            lngX_Axis = CLng(dblXAxis)
            dblToYSample = dblYAxis_Sample
            dblToYRef = dblYAxis_Ref
            dblToYDouble = dblYAxis_Double

            '--- Check if the X-coordinates and Y-coordinates are less than
            '--- Xmin and Ymin

            'dblYAxis = dblToY
            gDblAbsValue_IQOQPQ_Attachment1 = dblYAxis_Double

            '//------ to see the time lable only required to lable visiable property with "True"
            'lblTime.Text = "Time (Sc.) : " & Format(lngX_Axis, "#0")
            lblTime.Text = "Time (Sec.) : " & Format(dblXAxis, "#0.00#")
            'lblYAxis.Text = mYValueLable
            'lblYValue.Text = const_Sample & " : " & Format(dblYAxis_Sample, "#0.000")
            'lblYValue_Ref.Text = const_Reference & " : " & Format(dblYAxis_Ref, "#0.000")
            'lblYValue_Double.Text = const_Double & " : " & Format(dblYAxis_Double, "#0.000")
            'lblYAxis.Refresh()
            lblTime.Refresh()
            'lblYValue.Refresh()
            'lblYValue_Ref.Refresh()
            'lblYValue_Double.Refresh()

            '--- Check if the wavelength is equal to the max wv


            If (lngX_Axis >= AASGraphTimeScan.XAxisMax) Then
                AASGraphTimeScan.AldysPane.AxisChange()
                AASGraphTimeScan.Refresh()

                dblDiffX = Fix(AASGraphTimeScan.XAxisMax - AASGraphTimeScan.XAxisMin)
                dblMajorStepX = dblDiffX / 10
                dblMinorStepX = dblMajorStepX / 2

                dblDiffY = Fix(AASGraphTimeScan.YAxisMax - AASGraphTimeScan.YAxisMin)
                dblMajorStepY = dblDiffY / 10
                dblMinorStepY = dblMajorStepY / 2

                mintChannelIndex = 0
                intCurveIndex = 0
                tval = (AASGraphTimeScan.XAxisMax - AASGraphTimeScan.XAxisMin)
                MaxXaxis = AASGraphTimeScan.XAxisMax
                MinXaxis = AASGraphTimeScan.XAxisMin

                If lngX_Axis > MaxXaxis Then
                    For lngIdx = tval To lngX_Axis Step tval
                        If tval = 0 Then 'by pankaj 16.1.08
                            Exit For
                        End If
                        'MinXaxis += tval
                    Next
                    MaxXaxis = lngIdx
                    MinXaxis = MaxXaxis - tval
                Else
                    MinXaxis = MaxXaxis
                    MaxXaxis = MinXaxis + tval
                End If

                AASGraphTimeScan.XAxisMin = MinXaxis 'AASGraphTimeScan.XAxisMax
                AASGraphTimeScan.XAxisMax = MaxXaxis

                AASGraphTimeScan.AldysPane.XAxis.Min = MinXaxis   'AASGraphTimeScan.XAxisMax
                AASGraphTimeScan.AldysPane.XAxis.Max = MaxXaxis
                mobjParameters.XaxisMin = MinXaxis
                mobjParameters.XaxisMax = MaxXaxis

                '//----- Set auto Steps of axis
                AASGraphTimeScan.AldysPane.XAxis.Step = dblMajorStepX
                AASGraphTimeScan.AldysPane.XAxis.MinorStep = dblMinorStepX
                AASGraphTimeScan.XAxisStep = dblMajorStepX
                AASGraphTimeScan.XAxisMinorStep = dblMinorStepX
                gobjClsAAS203.Calculate_Analysis_Graph_Param(AASGraphTimeScan, ClsAAS203.enumChangeAxis.xyAxis)

                '//-----
                'AASGraphTimeScan.Refresh()
                'Application.DoEvents()
                'blnPlotingNew_Curve1 = False
                'blnPlotingNew_Curve2 = False
                'blnPlotingNew_Curve3 = False
                AASGraphTimeScan.AldysPane.AxisChange()
                AASGraphTimeScan.Refresh()
                Application.DoEvents()
                blnPlotingNew = False
            End If


            If blnPlotingNew = True Then
                'mGraphCurveItem = Nothing
                ''mGraphCurveItem = AASGraphTimeScan.StartOnlineGraph("Spectrum " & (intCurveIndex + 1).ToString, AASGraphTimeScan.GetColor(intCurveIndex), AldysGraph.SymbolType.NoSymbol)
                ''ArrlstGraphCurveItem.Add(mGraphCurveItem)
                ''AASGraphTimeScan.PlotPoint(ArrlstGraphCurveItem.Item(intCurveIndex), dblXAxis, dblYAxis)

                ''//----- Sample Beam
                'intCurveIndex = 0
                'mGraphCurveItem = AASGraphTimeScan.StartOnlineGraph(const_Sample, AASGraphTimeScan.GetColor(intCurveIndex), AldysGraph.SymbolType.NoSymbol)
                'ArrlstGraphCurveItem.Add(mGraphCurveItem)
                'AASGraphTimeScan.PlotPoint(ArrlstGraphCurveItem.Item(intCurveIndex), dblXAxis, dblYAxis_Sample)

                ''//----- Ref. Beam
                'intCurveIndex += 1
                'mGraphCurveItem = AASGraphTimeScan.StartOnlineGraph(const_Reference, AASGraphTimeScan.GetColor(intCurveIndex), AldysGraph.SymbolType.NoSymbol)
                'ArrlstGraphCurveItem.Add(mGraphCurveItem)
                'AASGraphTimeScan.PlotPoint(ArrlstGraphCurveItem.Item(intCurveIndex), dblXAxis, dblYAxis_Ref)


                ''//----- Double. Beam
                'If Not (gobjInst.Mode = EnumCalibrationMode.SELFTEST) Then
                '    intCurveIndex += 1
                '    mGraphCurveItem = AASGraphTimeScan.StartOnlineGraph(const_Double, AASGraphTimeScan.GetColor(intCurveIndex), AldysGraph.SymbolType.NoSymbol)
                '    ArrlstGraphCurveItem.Add(mGraphCurveItem)
                '    AASGraphTimeScan.PlotPoint(ArrlstGraphCurveItem.Item(intCurveIndex), dblXAxis, dblYAxis_Double)
                '    mblnIsShowDBeam = True
                '    blnISSetShown_DBeam = False
                'Else
                '    blnISSetShown_DBeam = True
                'End If
                funcStartOnlineGraph(dblXAxis, dblToYSample, dblToYRef, dblToYDouble)
                blnPlotingNew = False
            Else
                'intCurveIndex = 0
                ''AASGraphTimeScan.PlotPoint(ArrlstGraphCurveItem.Item(intCurveIndex), dblXAxis, dblYAxis)
                'AASGraphTimeScan.PlotPoint(ArrlstGraphCurveItem.Item(intCurveIndex), dblXAxis, dblYAxis_Sample)
                'intCurveIndex += 1
                'AASGraphTimeScan.PlotPoint(ArrlstGraphCurveItem.Item(intCurveIndex), dblXAxis, dblYAxis_Ref)

                ''//----- Double. Beam
                'If blnISSetShown_DBeam = True Then
                '    If Not (gobjInst.Mode = EnumCalibrationMode.SELFTEST) Then
                '        'intCurveIndex += 1
                '        intCurveIndex = 2
                '        mGraphCurveItem = AASGraphTimeScan.StartOnlineGraph(const_Double, AASGraphTimeScan.GetColor(intCurveIndex), AldysGraph.SymbolType.NoSymbol)
                '        ArrlstGraphCurveItem.Add(mGraphCurveItem)
                '        '    AASGraphTimeScan.PlotPoint(ArrlstGraphCurveItem.Item(intCurveIndex), dblXAxis, dblYAxis_Double)
                '        blnISSetShown_DBeam = False
                '        mblnIsShowDBeam = True
                '    End If
                'End If
                'If Not (gobjInst.Mode = EnumCalibrationMode.SELFTEST) Then
                '    intCurveIndex = 2
                '    AASGraphTimeScan.PlotPoint(ArrlstGraphCurveItem.Item(intCurveIndex), dblXAxis, dblYAxis_Double)
                'End If
                funcPlotOnlineGraph(dblXAxis, dblToYSample, dblToYRef, dblToYDouble)
                'AASGraphTimeScan.AldysPane.AxisChange()
            End If
            ' AASGraphTimeScan.Refresh()
            Application.DoEvents()
            Return True
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
            Return False
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------
        End Try

    End Function
    Private Function funcStartOnlineGraph(ByVal dblXAxis As Double, ByVal dblYAxis_Samp As Double, ByVal dblYAxis_Ref As Double, ByVal dblYAxis_Double As Double) As Boolean
        '=====================================================================
        ' Procedure Name        :   funcStartOnlineGraph
        ' Description           :   To start the online graph 
        ' Purpose               :   To start the online graph from first plotting point
        '                           Wavelength and absorbtion.           
        ' Parameters Passed     :   None.
        ' Returns               :   True, if successful.
        ' Parameters Affected   :   
        ' Assumptions           :   Graph pre-requisites are already been set.
        ' Dependencies          :   None.
        ' Author                :   Sachin Dokhale 
        ' Created               :   22.07.07
        ' Revisions             :
        '=====================================================================

        Try

            'lblYAxis.Text = mYValueLable
            'lblYValue.Text = const_Sample & " : " & Format(dblYAxis_Sample, "#0.000")
            'lblYValue_Ref.Text = const_Reference & " : " & Format(dblYAxis_Ref, "#0.000")
            'lblYValue_Double.Text = const_Double & " : " & Format(dblYAxis_Double, "#0.000")
            'lblYAxis.Refresh()
            'lblYValue.Refresh()
            'lblYValue_Ref.Refresh()
            'lblYValue_Double.Refresh()

            mGraphCurveItem = Nothing
            If gintInstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.SingleBeam Then
                '//----- Sample Beam
                If blnPlotingNew_Curve1 = True Then
                    intCurveIndex = 0
                    mGraphCurveItem = AASGraphTimeScan.StartOnlineGraph(const_Sample, AASGraphTimeScan.GetColor(intCurveIndex), AldysGraph.SymbolType.NoSymbol)
                    ArrlstGraphCurveItem.Add(mGraphCurveItem)
                    AASGraphTimeScan.PlotPoint(ArrlstGraphCurveItem.Item(intCurveIndex), dblXAxis, dblYAxis_Samp)
                    blnPlotingNew_Curve1 = False
                End If
                lblYValue.Text = mYValueLable & " : " & Format(dblYAxis_Samp, mstrYaxisFormat)
                AASGraphTimeScan.AldysPane.Legend.IsVisible = False
                'AASGraphTimeScan.AldysPane.Legend.IsVisible = True
            Else
                If Not (gobjInst.Mode = EnumCalibrationMode.AA) Then
                    '//----- Sample Beam
                    If blnPlotingNew_Curve1 = True Then
                        intCurveIndex = 0
                        mGraphCurveItem = AASGraphTimeScan.StartOnlineGraph(const_Sample, AASGraphTimeScan.GetColor(intCurveIndex), AldysGraph.SymbolType.NoSymbol)
                        ArrlstGraphCurveItem.Add(mGraphCurveItem)
                        AASGraphTimeScan.PlotPoint(ArrlstGraphCurveItem.Item(intCurveIndex), dblXAxis, dblYAxis_Samp)
                        blnPlotingNew_Curve1 = False
                    End If
                    lblYValue.Text = mYValueLable & " : " & Format(dblYAxis_Samp, mstrYaxisFormat)
                    AASGraphTimeScan.AldysPane.Legend.IsVisible = False
                    'AASGraphTimeScan.AldysPane.Legend.IsVisible = True
                Else
                    '//----- Double Beam
                    If gstructSettings.IsCustomerDisplayMode = True Then
                        If blnPlotingNew_Curve1 = True Then
                            intCurveIndex = 0
                            If (gobjInst.Mode = EnumCalibrationMode.SELFTEST) Then
                                mGraphCurveItem = AASGraphTimeScan.StartOnlineGraph(const_Double, AASGraphTimeScan.GetColor(intCurveIndex), AldysGraph.SymbolType.NoSymbol)
                                ArrlstGraphCurveItem.Add(mGraphCurveItem)
                                mGraphCurveItem.Label = ""
                                AASGraphTimeScan.PlotPoint(ArrlstGraphCurveItem.Item(intCurveIndex), dblXAxis, dblYAxis_Samp)
                                blnPlotingNew_Curve1 = False
                                lblYValue.Text = mYValueLable & " : " & Format(dblYAxis_Samp, mstrYaxisFormat)
                            Else
                                mGraphCurveItem = AASGraphTimeScan.StartOnlineGraph(const_Double, AASGraphTimeScan.GetColor(intCurveIndex), AldysGraph.SymbolType.NoSymbol)
                                ArrlstGraphCurveItem.Add(mGraphCurveItem)
                                AASGraphTimeScan.PlotPoint(ArrlstGraphCurveItem.Item(intCurveIndex), dblXAxis, dblYAxis_Double)
                                blnPlotingNew_Curve1 = False
                                lblYValue_Double.Text = mYValueLable & " : " & Format(dblYAxis_Double, mstrYaxisFormat)
                            End If
                        End If
                        AASGraphTimeScan.AldysPane.Legend.IsVisible = False
                    Else
                        If blnPlotingNew_Curve1 = True Then
                            intCurveIndex = -1
                            intCurveIndex += 1
                        End If
                        'intCurveIndex += 1
                        If blnPlotingNew_Curve1 = True Then
                            '//----- Sample Beam
                            'intCurveIndex += 1
                            mGraphCurveItem = AASGraphTimeScan.StartOnlineGraph(const_Sample, AASGraphTimeScan.GetColor(intCurveIndex), AldysGraph.SymbolType.NoSymbol)
                            ArrlstGraphCurveItem.Add(mGraphCurveItem)
                            AASGraphTimeScan.PlotPoint(ArrlstGraphCurveItem.Item(intCurveIndex), dblXAxis, dblYAxis_Samp)
                            blnPlotingNew_Curve1 = False
                        End If
                        lblYValue.Text = const_Sample & " " & mYValueLable & " : " & Format(dblYAxis_Samp, mstrYaxisFormat)
                        If blnPlotingNew_Curve2 = True Then
                            '//----- Ref. Beam
                            intCurveIndex += 1
                            mGraphCurveItem = AASGraphTimeScan.StartOnlineGraph(const_Reference, AASGraphTimeScan.GetColor(intCurveIndex), AldysGraph.SymbolType.NoSymbol)
                            ArrlstGraphCurveItem.Add(mGraphCurveItem)
                            AASGraphTimeScan.PlotPoint(ArrlstGraphCurveItem.Item(intCurveIndex), dblXAxis, dblYAxis_Ref)
                            blnPlotingNew_Curve2 = False
                        End If
                        lblYValue_Ref.Text = const_Reference & " " & mYValueLable & " : " & Format(dblYAxis_Ref, mstrYaxisFormat)
                        If blnPlotingNew_Curve3 = True Then
                            If Not (gobjInst.Mode = EnumCalibrationMode.SELFTEST) Then
                                '//----- Double Beam
                                intCurveIndex += 1
                                mGraphCurveItem = AASGraphTimeScan.StartOnlineGraph(const_Double, AASGraphTimeScan.GetColor(intCurveIndex), AldysGraph.SymbolType.NoSymbol)
                                ArrlstGraphCurveItem.Add(mGraphCurveItem)
                                AASGraphTimeScan.PlotPoint(ArrlstGraphCurveItem.Item(intCurveIndex), dblXAxis, dblYAxis_Double)
                                blnPlotingNew_Curve3 = False
                                lblYValue_Double.Text = const_Double & " " & mYValueLable & " : " & Format(dblYAxis_Double, mstrYaxisFormat)
                            End If
                        End If
                        If Not gstructSettings.IsCustomerDisplayMode Then
                            AASGraphTimeScan.AldysPane.Legend.IsVisible = True     'Commented by Saurabh 05.08.07
                        End If
                    End If
                End If
            End If

            ''//----- Ref. Beam
            'intCurveIndex += 1
            'mGraphCurveItem = AASGraphTimeScan.StartOnlineGraph(const_Reference, AASGraphTimeScan.GetColor(intCurveIndex), AldysGraph.SymbolType.NoSymbol)
            'ArrlstGraphCurveItem.Add(mGraphCurveItem)
            'AASGraphTimeScan.PlotPoint(ArrlstGraphCurveItem.Item(intCurveIndex), dblXAxis, dblYAxis_Ref)


            ''//----- Double. Beam
            'If Not (gobjInst.Mode = EnumCalibrationMode.SELFTEST) Then
            '    intCurveIndex += 1
            '    mGraphCurveItem = AASGraphTimeScan.StartOnlineGraph(const_Double, AASGraphTimeScan.GetColor(intCurveIndex), AldysGraph.SymbolType.NoSymbol)
            '    ArrlstGraphCurveItem.Add(mGraphCurveItem)
            '    AASGraphTimeScan.PlotPoint(ArrlstGraphCurveItem.Item(intCurveIndex), dblXAxis, dblYAxis_Double)
            '    mblnIsShowDBeam = True
            '    blnISSetShown_DBeam = False
            'Else
            '    blnISSetShown_DBeam = True
            'End If
            Return True
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
            Return False
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------
        End Try

    End Function

    Private Function funcStopOnlineGraph(ByVal dblYAxis_Samp As Double, ByVal dblYAxis_Ref As Double, ByVal dblYAxis_Double As Double)
        '=====================================================================
        ' Procedure Name        :   funcStartOnlineGraph
        ' Description           :   To start the online graph 
        ' Purpose               :   To start the online graph from first plotting point
        '                           Wavelength and absorbtion.           
        ' Parameters Passed     :   None.
        ' Returns               :   True, if successful.
        ' Parameters Affected   :   
        ' Assumptions           :   Graph pre-requisites are already been set.
        ' Dependencies          :   None.
        ' Author                :   Sachin Dokhale 
        ' Created               :   22.07.07
        ' Revisions             :
        '=====================================================================

        Try

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
            Return False
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------
        End Try
    End Function

    Private Function funcPlotOnlineGraph(ByVal dblXAxis As Double, ByVal dblYAxis_Samp As Double, ByVal dblYAxis_Ref As Double, ByVal dblYAxis_Double As Double) As Boolean
        '=====================================================================
        ' Procedure Name        :   funcStartOnlineGraph
        ' Description           :   To start the online graph 
        ' Purpose               :   To start the online graph from first plotting point
        '                           Wavelength and absorbtion.           
        ' Parameters Passed     :   None.
        ' Returns               :   True, if successful.
        ' Parameters Affected   :   
        ' Assumptions           :   Graph pre-requisites are already been set.
        ' Dependencies          :   None.
        ' Author                :   Sachin Dokhale 
        ' Created               :   22.07.07
        ' Revisions             :
        '=====================================================================

        Try
            If gintInstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.SingleBeam Then
                '//----- Sample Beam
                intCurveIndex = 0
                'AASGraphTimeScan.PlotPoint(ArrlstGraphCurveItem.Item(intCurveIndex), dblXAxis, dblYAxis)
                AASGraphTimeScan.PlotPoint(ArrlstGraphCurveItem.Item(intCurveIndex), dblXAxis, dblYAxis_Samp)
                lblYValue.Text = mYValueLable & " : " & Format(dblYAxis_Samp, mstrYaxisFormat)
            Else
                If Not (gobjInst.Mode = EnumCalibrationMode.AA) Then
                    '//----- Sample Beam
                    intCurveIndex = 0
                    AASGraphTimeScan.PlotPoint(ArrlstGraphCurveItem.Item(intCurveIndex), dblXAxis, dblYAxis_Samp)
                    lblYValue.Text = mYValueLable & " : " & Format(dblYAxis_Samp, mstrYaxisFormat)
                Else
                    If gstructSettings.IsCustomerDisplayMode = True Then
                        '//----- Double Beam
                        intCurveIndex = 0
                        '    mGraphCurveItem = AASGraphTimeScan.StartOnlineGraph(const_Double, AASGraphTimeScan.GetColor(intCurveIndex), AldysGraph.SymbolType.NoSymbol)
                        '    ArrlstGraphCurveItem.Add(mGraphCurveItem)
                        If (gobjInst.Mode = EnumCalibrationMode.SELFTEST) Then
                            AASGraphTimeScan.PlotPoint(ArrlstGraphCurveItem.Item(intCurveIndex), dblXAxis, dblYAxis_Samp)
                            lblYValue.Text = mYValueLable & " : " & Format(dblYAxis_Samp, mstrYaxisFormat)
                        Else
                            AASGraphTimeScan.PlotPoint(ArrlstGraphCurveItem.Item(intCurveIndex), dblXAxis, dblYAxis_Double)
                            lblYValue.Text = mYValueLable & " : " & Format(dblYAxis_Double, mstrYaxisFormat)
                        End If
                    Else
                        '//----- Sample Beam
                        intCurveIndex = 0
                        'AASGraphTimeScan.PlotPoint(ArrlstGraphCurveItem.Item(intCurveIndex), dblXAxis, dblYAxis)
                        AASGraphTimeScan.PlotPoint(ArrlstGraphCurveItem.Item(intCurveIndex), dblXAxis, dblYAxis_Samp)
                        '//----- Ref. Beam
                        intCurveIndex += 1
                        AASGraphTimeScan.PlotPoint(ArrlstGraphCurveItem.Item(intCurveIndex), dblXAxis, dblYAxis_Ref)
                        '//----- Double Beam

                        If (gobjInst.Mode = EnumCalibrationMode.SELFTEST) Then
                        Else
                            intCurveIndex += 1
                            AASGraphTimeScan.PlotPoint(ArrlstGraphCurveItem.Item(intCurveIndex), dblXAxis, dblYAxis_Double)
                            lblYValue_Double.Text = const_Double & " " & mYValueLable & " : " & Format(dblYAxis_Double, mstrYaxisFormat)
                        End If
                        lblYValue_Ref.Text = const_Reference & " " & mYValueLable & " : " & Format(dblYAxis_Ref, mstrYaxisFormat)
                        lblYValue.Text = const_Sample & " " & mYValueLable & " : " & Format(dblYAxis_Samp, mstrYaxisFormat)

                    End If
                End If
            End If

            AASGraphTimeScan.AldysPane.AxisChange()
            AASGraphTimeScan.Refresh()
            Application.DoEvents()
            Return True
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
            Return False
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------
        End Try
    End Function

    Private Function funcOnlineGraphPrereq() As Boolean
        '=====================================================================
        ' Procedure Name        :   funcStartOnlineGraph
        ' Description           :   To start the online graph 
        ' Purpose               :   To start the online graph from first plotting point
        '                           Wavelength and absorbtion.           
        ' Parameters Passed     :   None.
        ' Returns               :   True, if successful.
        ' Parameters Affected   :   
        ' Assumptions           :   Graph pre-requisites are already been set.
        ' Dependencies          :   None.
        ' Author                :   Sachin Dokhale 
        ' Created               :   22.07.07
        ' Revisions             :
        '=====================================================================
        'lblYValue_Ref.Visible = False
        'lblYValue_Double.Visible = False
        'lblYAxis.Visible = False
        ''Dim pt As New Point
        'pt = lblYValue.Location
        'pt.Y = pt.Y - 14
        'lblYValue.Location = pt
        Try
            If gintInstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.SingleBeam Then
                '//----- Sample Beam
                lblYValue.Height = 20
                lblYValue_Ref.Height = 20
                lblYValue_Double.Height = 20

                blnPlotingNew = True
                blnPlotingNew = True
                lblYValue_Ref.Visible = False
                lblYValue_Double.Visible = False
                Dim pt As New Point
                'pt = lblYValue.Location
                'pt.Y = pt.Y - 14
                'lblYValue_Double.Location = pt
                lblYValue.Visible = True
            Else
                If Not (gobjInst.Mode = EnumCalibrationMode.AA) Then
                    '//----- Sample Beam
                    lblYValue.Height = 20
                    lblYValue_Ref.Height = 20
                    lblYValue_Double.Height = 20

                    blnPlotingNew = True
                    lblYValue_Ref.Visible = False
                    lblYValue_Double.Visible = False
                    Dim pt As New Point
                    'pt = lblYValue.Location
                    'pt.Y = pt.Y - 14
                    'lblYValue_Double.Location = pt
                    lblYValue.Visible = True
                Else
                    If gstructSettings.IsCustomerDisplayMode = True Then
                        '//----- Double Beam
                        lblYValue.Height = 20
                        lblYValue_Ref.Height = 20
                        lblYValue_Double.Height = 20

                        blnPlotingNew = True
                        lblYValue_Ref.Visible = False
                        lblYValue_Double.Visible = False

                        Dim pt As New Point
                        'pt = lblYValue.Location
                        'pt.Y = pt.Y - 14
                        'lblYValue_Double.Location = pt
                        lblYValue.Visible = True
                    Else
                        blnPlotingNew = True
                        '//----- Sample Beam

                        '//----- Ref. Beam

                        '//----- Double Beam
                        Dim pt As New Point
                        'pt = lblYValue.Location
                        '' pt.Y = pt.Y - 14

                        'lblYValue.Location = pt
                        'pt.Y += 14
                        'lblYValue_Ref.Location = pt
                        'pt.Y += 14
                        'lblYValue_Double.Location = pt
                        lblYValue.Top = lblWvPos.Height + lblWvPos.Top + 8
                        lblYValue.Height = 30
                        lblYValue_Ref.Height = 30


                        lblYValue.Visible = True
                        lblYValue_Ref.Visible = True
                        If Not (gobjInst.Mode = EnumCalibrationMode.SELFTEST) Then
                            lblYValue_Double.Height = 30
                            lblYValue_Double.Visible = True
                        Else
                            lblYValue_Double.Visible = False
                        End If
                        'lblYAxis.Visible = False

                        'lblYAxis.Visible = True
                    End If
                End If
            End If
            blnPlotingNew = True
            Return True
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
            Return False
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------
        End Try
    End Function

    Friend Function funcDisplayGraph(ByVal objChannel As Spectrum.Channel) As Boolean
        '=====================================================================
        ' Procedure Name        :   funcDisplayGraph
        ' Description           :   to plot the graph as offline 
        ' Purpose               :   
        ' Parameters Passed     :   objChannel
        ' Returns               :   True, if successful.
        ' Parameters Affected   :   
        ' Assumptions           :   
        ' Dependencies          :   None.
        ' Author                :   Sachin Dokhale 
        ' Created               :   12.12.06
        ' Revisions             :
        '=====================================================================
        Dim lngDataCount As Long
        Dim objReadingCol As New Spectrum.Readings
        Dim dblFromX As Double
        Dim dblFromY As Double
        Dim dblToX As Double
        Dim dblToY As Double
        Dim dtPlotValue As New DataTable
        Dim dtColXaxis As New DataColumn("Xaxis", GetType(Double))
        Dim dtColYaxis As New DataColumn("Yaxis", GetType(Double))
        Dim dtRow As DataRow

        Try

            If Not objChannel Is Nothing Then
                If objChannel.Spectrums.Count > 0 Then

                    dblFromX = objChannel.UVParameter.XaxisMax
                    dblFromY = objChannel.UVParameter.YaxisMin

                    '--- Get the speed


                    dtPlotValue.Columns.Add(dtColXaxis)
                    dtPlotValue.Columns.Add(dtColYaxis)

                    'For lngDataCount = objChannel.UVParameter.XaxisMin To objChannel.UVParameter.XaxisMax Step 1     '+objChannel.Parameter.CalculatedSpeed
                    For lngDataCount = 0 To objChannel.Spectrums.item(0).Readings.Count - 1 Step 1      '+objChannel.Parameter.CalculatedSpeed
                        '--- Check for the graph plotted on the screen

                        dblToX = objChannel.Spectrums.item(0).Readings.item(lngDataCount).XaxisData
                        dblToY = objChannel.Spectrums.item(0).Readings.item(lngDataCount).YaxisData
                        dblToY = gfuncGetValueInSpectrum(dblToY, gobjInst.Mode)
                        '--- Check if the X-coordinates and Y-coordinates are less than
                        '--- Xmin and Ymin
                        If dblToY < objChannel.UVParameter.YaxisMin Then
                            dblToY = objChannel.UVParameter.YaxisMin()
                        End If

                        If dblToY > objChannel.UVParameter.YaxisMax Then
                            dblToY = objChannel.UVParameter.YaxisMax
                        End If
                        dtRow = dtPlotValue.NewRow

                        dtRow(0) = dblToX
                        dtRow(1) = dblToY
                        dtPlotValue.Rows.Add(dtRow)
                        '--- Check if the wavelength is equal to the min wv
                    Next

                    AASGraphTimeScan.GraphDataSource = dtPlotValue
                    Call AASGraphTimeScan.PlotGraph()
                    Application.DoEvents()
                    AASGraphTimeScan.Refresh()
                End If
            End If
            Application.DoEvents()

            Return True

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
            Return False
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------
        End Try
        '------------use this method if u want to display graph using File
        '  AxSpectra1.FileToParentCollection("C:\IKON Projects\UV2600Production\Source\SpectroPhotometer\SpectroGraphocxusingmouselock\testfile.txt")

    End Function

    Friend Function funcClearGraph() As Boolean
        Dim lngDataCount As Long
        'Dim objReadingCol As New Spectrum.Readings
        Dim dblFromX As Double
        Dim dblFromY As Double
        Dim dblToX As Double
        Dim dblToY As Double


        Try

            mintChannelIndex = 0
            'mobjChannnels.Clear()
            ArrlstGraphCurveItem.Clear()
            AASGraphTimeScan.AldysPane.CurveList.Clear()
            AASGraphTimeScan.Refresh()
            Application.DoEvents()
            intCurveIndex = 0
            Return True

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
            Return False
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------
        End Try
    End Function

#End Region

#Region " Graph Options"

    Private Sub mnuGrid_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        :   mnuGrid_Click
        ' Description           :   to check the graph for grid.
        ' Purpose               :   
        ' Parameters Passed     :   
        ' Returns               :   
        ' Parameters Affected   :   
        ' Assumptions           :   
        ' Dependencies          :   None.
        ' Author                :   Sachin Dokhale
        ' Created               :   04.05.07
        ' Revisions             :
        '=====================================================================

        Try
            mobjclsBgSpectrum.SpectrumWait = True
            mnuGrid.Checked = Not (mnuGrid.Checked)
            Me.AASGraphTimeScan.IsShowGrid = mnuGrid.Checked
            mobjclsBgSpectrum.SpectrumWait = False

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------
        End Try
    End Sub

    'Private Sub mnuPeakEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    '    '=====================================================================
    '    ' Procedure Name        :   mnuPeakEdit_Click
    '    ' Description           :   to check the graph for Peak Edit.
    '    ' Purpose               :   
    '    ' Parameters Passed     :   
    '    ' Returns               :   
    '    ' Parameters Affected   :   
    '    ' Assumptions           :   
    '    ' Dependencies          :   None.
    '    ' Author                :   Sachin Dokhale
    '    ' Created               :   04.05.07
    '    ' Revisions             :
    '    '=====================================================================

    '    Try
    '        mobjclsBgSpectrum.SpectrumWait = True
    '        mnuPeakEdit.Checked = Not (mnuPeakEdit.Checked)
    '        'Me.AASGraphUVSpectrum.IsShowGrid = mnuPeakEdit.Checked
    '        Me.AASGraphTimeScan.submnuPeakEdit_Click(sender, e)
    '        mobjclsBgSpectrum.SpectrumWait = False

    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        'Error Handling and logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = ex.Message
    '        gobjErrorHandler.WriteErrorLog(ex)
    '        '---------------------------------------------------------
    '    Finally
    '        '---------------------------------------------------------
    '        'Writing Execution log
    '        If CONST_CREATE_EXECUTION_LOG = 1 Then
    '            gobjErrorHandler.WriteExecutionLog()
    '        End If
    '        '---------------------------------------------------------
    '    End Try
    'End Sub

    Private Sub mnuShowXYValues_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        :   mnuShowXYValues_Click
        ' Description           :   to check the graph for show XY values.
        ' Purpose               :   
        ' Parameters Passed     :   
        ' Returns               :   
        ' Parameters Affected   :   
        ' Assumptions           :   
        ' Dependencies          :   None.
        ' Author                :   Sachin Dokhale
        ' Created               :   04.05.07
        ' Revisions             :
        '=====================================================================

        Try
            mobjclsBgSpectrum.SpectrumWait = True
            mnuShowXYValues.Checked = Not (mnuShowXYValues.Checked)
            Me.AASGraphTimeScan.ShowXYValues = mnuShowXYValues.Checked
            'Me.AASGraphUVSpectrum.submnuPeakEdit_Click(AASGraphUVSpectrum, System.EventArgs.Empty)
            mobjclsBgSpectrum.SpectrumWait = False


        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------
        End Try
    End Sub

    'Private Sub mnuLegends_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    '    '=====================================================================
    '    ' Procedure Name        :   mnuLegends_Click
    '    ' Description           :   to check the graph for Legends.
    '    ' Purpose               :   
    '    ' Parameters Passed     :   
    '    ' Returns               :   
    '    ' Parameters Affected   :   
    '    ' Assumptions           :   
    '    ' Dependencies          :   None.
    '    ' Author                :   Sachin Dokhale
    '    ' Created               :   04.05.07
    '    ' Revisions             :
    '    '=====================================================================

    '    Try
    '        mobjclsBgSpectrum.SpectrumWait = True
    '        mnuLegends.Checked = Not (mnuLegends.Checked)
    '        Me.AASGraphTimeScan.AldysPane.Legend.IsVisible = mnuLegends.Checked
    '        AASGraphTimeScan.Invalidate()
    '        AASGraphTimeScan.Refresh()
    '        'Me.AASGraphUVSpectrum.submnuPeakEdit_Click(AASGraphUVSpectrum, System.EventArgs.Empty)
    '        mobjclsBgSpectrum.SpectrumWait = False


    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        'Error Handling and logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = ex.Message
    '        gobjErrorHandler.WriteErrorLog(ex)
    '        '---------------------------------------------------------
    '    Finally
    '        '---------------------------------------------------------
    '        'Writing Execution log
    '        If CONST_CREATE_EXECUTION_LOG = 1 Then
    '            gobjErrorHandler.WriteExecutionLog()
    '        End If
    '        '---------------------------------------------------------
    '    End Try
    'End Sub

    Private Sub AASEnergySpectrum_GraphOptionChanged() Handles AASGraphTimeScan.GraphOptionChanged
        '=====================================================================
        ' Procedure Name        :   AASGraphUVSpectrum_GraphOptionChanged
        ' Description           :   to check the graph on options.
        ' Purpose               :   
        ' Parameters Passed     :   
        ' Returns               :   
        ' Parameters Affected   :   
        ' Assumptions           :   
        ' Dependencies          :   None.
        ' Author                :   Sachin Dokhale
        ' Created               :   04.05.07
        ' Revisions             :
        '=====================================================================

        Try
            '//----- Check Grid on graph
            RemoveHandler mnuGrid.Click, AddressOf mnuGrid_Click
            If AASGraphTimeScan.IsShowGrid = True Then
                mnuGrid.Checked = True
            Else
                mnuGrid.Checked = False
            End If
            AddHandler mnuGrid.Click, AddressOf mnuGrid_Click

            '//----- Check Legends on Graph
            'RemoveHandler mnuLegends.Click, AddressOf mnuLegends_Click
            'If AASGraphTimeScan.AldysPane.Legend.IsVisible = True Then
            '    mnuLegends.Checked = True
            'Else
            '    mnuLegends.Checked = False
            'End If
            'AddHandler mnuLegends.Click, AddressOf mnuLegends_Click

            '//----- Check Show XY Values on Graph
            RemoveHandler mnuShowXYValues.Click, AddressOf mnuShowXYValues_Click
            If AASGraphTimeScan.ShowXYValues = True Then
                mnuShowXYValues.Checked = True
            Else
                mnuShowXYValues.Checked = False
            End If
            AddHandler mnuShowXYValues.Click, AddressOf mnuShowXYValues_Click

            'RemoveHandler mnuPeakEdit.Click, AddressOf mnuPeakEdit_Click
            'If AASGraphTimeScan.ShowXYPeak = True Then
            '    mnuPeakEdit.Checked = True
            'Else
            '    mnuPeakEdit.Checked = False
            'End If
            'AddHandler mnuPeakEdit.Click, AddressOf mnuPeakEdit_Click

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------
        End Try
    End Sub

#End Region

#Region "Shortcut Handlers"

    'case	IDC_ADJFLOW: Optimise_Fuel_Auto(hwnd);
    '						 Scroll_Fuel(hwnd,IDC_FUEL, -1);break;
    'case	IDC_ADJBH:	Optimise_Height_Auto(hwnd);
    '						Scroll_Bh(hwnd,IDC_BH, -1);
    '						Save_BH_Pos();
    'break;




    '//---- ComProtocol

    '//-----

    '//---- clsAAS

    Private Sub StatusBar1_PanelClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.StatusBarPanelClickEventArgs) Handles StatusBar1.PanelClick

    End Sub

    Private Sub btnIgnite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If mblnAvoidFormProcessing = True Then
            Exit Sub
        End If
        Try
            mblnAvoidFormProcessing = True
            mobjclsBgSpectrum.SpectrumWait = True
            Call gobjCommProtocol.mobjCommdll.subTime_Delay(100)
            Call gobjClsAAS203.funcIgnite(True)
            Call funcGetInstParameter()
            mobjclsBgSpectrum.SpectrumWait = False
            mblnAvoidFormProcessing = False
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            mobjclsBgSpectrum.SpectrumWait = False
            mblnAvoidFormProcessing = False
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub btnN2OIgnite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If mblnAvoidFormProcessing = True Then
            Exit Sub
        End If
        Try
            mblnAvoidFormProcessing = True
            'If mblnSpectrumStarted = False Then
            'If Not IsNothing(gobjMain) Then
            mobjclsBgSpectrum.SpectrumWait = True
            'MsgBox("frmTimeDB")
            'gobjMain.AutoIgnition()
            Call gobjCommProtocol.mobjCommdll.subTime_Delay(100)
            Call gobjCommProtocol.funcSwitchOver()
            Call funcGetInstParameter()
            mobjclsBgSpectrum.SpectrumWait = False
            'End If
            mblnAvoidFormProcessing = False

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
            mobjclsBgSpectrum.SpectrumWait = False
            mblnAvoidFormProcessing = False
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            'objWait.Dispose()
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub btnExtinguish_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If mblnAvoidFormProcessing = True Then
            Exit Sub
        End If
        Try
            mblnAvoidFormProcessing = True
            mobjclsBgSpectrum.SpectrumWait = True
            'If Not IsNothing(gobjMain) Then
            'gobjMain.Extinguish()
            Call gobjCommProtocol.mobjCommdll.subTime_Delay(100)
            Call gobjClsAAS203.funcIgnite(False)
            'End If
            Call funcGetInstParameter()
            mobjclsBgSpectrum.SpectrumWait = False
            mblnAvoidFormProcessing = False
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            mobjclsBgSpectrum.SpectrumWait = False
            mblnAvoidFormProcessing = False
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            'mblnAvoidProcessing = False
            'objWait.Dispose()
            '---------------------------------------------------------
        End Try

    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : btnDelete_Click
        ' Parameters Passed     : Object, EventArgs
        ' Returns               : None
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 18-Dec-2007 03:15 pm
        ' Revisions             : 0
        '=====================================================================
        Try
            If mblnAvoidFormProcessing = True Then
                Exit Sub
            End If
            mblnAvoidFormProcessing = True
            mobjclsBgSpectrum.SpectrumWait = True
            'If Not gstructSettings.AppMode = EnumAppMode.DemoMode Then
            If Not ((gstructSettings.AppMode = EnumAppMode.DemoMode) Or _
                    (gstructSettings.AppMode = EnumAppMode.DemoMode_201) Or _
                    (gstructSettings.AppMode = EnumAppMode.DemoMode_203D)) Then
                Call Application.DoEvents()
                Call gobjCommProtocol.mobjCommdll.subTime_Delay(50)
                '---switch over to N2O flame
                gobjClsAAS203.ReInitInstParameters()
                Call funcGetInstParameter()
            Else
                Call Application.DoEvents()
            End If
            mobjclsBgSpectrum.SpectrumWait = False
            mblnAvoidFormProcessing = False
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub btnR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : btnR_Click
        ' Parameters Passed     : Object, EventArgs
        ' Returns               : None
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 18-Dec-2007 03:15 pm
        ' Revisions             : 0
        '=====================================================================
        Try
            If mblnAvoidFormProcessing = True Then
                Exit Sub
            End If
            mblnAvoidFormProcessing = True
            mobjclsBgSpectrum.SpectrumWait = True
            'If Not gstructSettings.AppMode = EnumAppMode.DemoMode Then
            If Not ((gstructSettings.AppMode = EnumAppMode.DemoMode) Or _
                    (gstructSettings.AppMode = EnumAppMode.DemoMode_201) Or _
                    (gstructSettings.AppMode = EnumAppMode.DemoMode_203D)) Then

                Call Application.DoEvents()
                Call gobjCommProtocol.mobjCommdll.subTime_Delay(50)
                Call gobjClsAAS203.funcInstReset()

            Else
                'Call gobjMessageAdapter.ShowMessage("Alt - R", "Alt - R")
                Call Application.DoEvents()
            End If
            mobjclsBgSpectrum.SpectrumWait = False
            mblnAvoidFormProcessing = False
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub MenuBarEnergySpectrumMode_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MenuBarEnergySpectrumMode.KeyUp
        '=====================================================================
        ' Procedure Name        : MenuBarEnergySpectrumMode_KeyUp
        ' Parameters Passed     : Object, EventArgs
        ' Returns               : None
        ' Purpose               : Short-cuts should be work from menu bar
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 18-Dec-2007 03:15 pm
        ' Revisions             : 0
        '=====================================================================
        Try
            If mblnAvoidFormProcessing = True Then
                Exit Sub
            End If
            'mblnAvoidProcessing = True
            If e.Alt = True Then
                Select Case e.KeyCode
                    Case Keys.I
                        Call btnIgnite_Click(sender, e)
                    Case Keys.C
                        btnN2OIgnite_Click(sender, e)
                    Case Keys.E
                        Call btnExtinguish_Click(sender, e)
                    Case Keys.D
                        'Call gobjMainService.funcAltDelete()
                        Call btnDelete_Click(sender, e)
                    Case Keys.R
                        Call btnR_Click(sender, e)
                    Case Keys.Q

                End Select
            End If
            mblnAvoidFormProcessing = False
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub DisableButtonsForBurnerHeight()
        btnClearSpectrum.Enabled = False
        btnExtinguish.Enabled = False
        btnIgnite.Enabled = False

        btnReturn.Enabled = False
        mnuReturn.Enabled = False
        cmdbtnReturn.Enabled = False

        cmdbtnAutoZero.Enabled = False
        mnuAutoZero.Enabled = False
        btnAutoZero.Enabled = False

        nudD2Cur.Enabled = False
        nudPMT.Enabled = False
        nudSlit.Enabled = False
        nudSlit_Exit.Enabled = False
        'cmbSpeed.Enabled = False
        cmbModes.Enabled = False
        nudBurnerHeight.Enabled = False
        nudFuelRatio.Enabled = False
        nudHCLCur.Enabled = False
        nudPMT_Ref.Enabled = False  'For Double Beam
        'nudSlit_Ref.Enabled = False 'For Double Beam

        cmdADJFlow.Enabled = False
        cmdbtnAdjFuelFlow.Enabled = False
        mnuAdjustFuel.Enabled = False

        cmdChangeScale.Enabled = False
        cmdbtnChangeScale.Enabled = False
        mnuChangeScale.Enabled = False

        mnuAdjustBurnerHeight.Enabled = False
        cmdbtnAdjBurnerHt.Enabled = False
        cmdADJBH.Enabled = False

        'mnuPeakPick.Enabled = False
        'tlbbtnPeakPick.Enabled = False

        'mnuPositionToMaxima.Enabled = False
        'tlbbtnPositionToMaxima.Enabled = False

        'mnuSmooth.Enabled = False
        'tlbbtnSmooth.Enabled = False

        'mnuLoadSpectrunFile.Enabled = False
        'tlbbtnLoadspectrumFile.Enabled = False

        'mnuContiniousTimeScan.Enabled = False
        'tlbbtnContiniousTimeScan.Enabled = False

        'mnuParameters.Enabled = False
        'tlbbtnParameters.Enabled = False

        'mnuPositionToMaxima.Enabled = False
        'tlbbtnPositionToMaxima.Enabled = False
        ''Added By Pankaj 21 May 07
        'mnuLampParameters.Enabled = False
        'tlbbtnLampParameters.Enabled = False
        btnLampParameters.Enabled = False

        'mnuClearSpectrum.Enabled = False
        'tlbbtnClearSpectrum.Enabled = False

        'tlbbtnPrintGraph.Enabled = False
        'mnuPrintGraph.Enabled = False
    End Sub

    Private Sub EnableButtonsForBurnerHeight()
        btnClearSpectrum.Enabled = True
        btnExtinguish.Enabled = True
        btnIgnite.Enabled = True

        btnReturn.Enabled = True
        mnuReturn.Enabled = True
        cmdbtnReturn.Enabled = True

        cmdbtnAutoZero.Enabled = True
        mnuAutoZero.Enabled = True
        btnAutoZero.Enabled = True

        nudD2Cur.Enabled = True
        nudPMT.Enabled = True
        nudSlit.Enabled = True
        'nudSlit_Exit.Enabled = True 'by Pankaj on 18.1.08
        'cmbSpeed.Enabled = False
        cmbModes.Enabled = True
        nudBurnerHeight.Enabled = True
        nudFuelRatio.Enabled = True
        nudHCLCur.Enabled = True
        nudPMT_Ref.Enabled = True  'For Double Bea
        'nudSlit_Ref.Enabled = False 'For Double Beam

        cmdADJFlow.Enabled = True
        cmdbtnAdjFuelFlow.Enabled = True
        mnuAdjustFuel.Enabled = True

        cmdChangeScale.Enabled = True
        cmdbtnChangeScale.Enabled = True
        mnuChangeScale.Enabled = True

        mnuAdjustBurnerHeight.Enabled = True
        cmdbtnAdjBurnerHt.Enabled = True
        cmdADJBH.Enabled = True

        'mnuPeakPick.Enabled = False
        'tlbbtnPeakPick.Enabled = False

        'mnuPositionToMaxima.Enabled = False
        'tlbbtnPositionToMaxima.Enabled = False

        'mnuSmooth.Enabled = False
        'tlbbtnSmooth.Enabled = False

        'mnuLoadSpectrunFile.Enabled = False
        'tlbbtnLoadspectrumFile.Enabled = False

        'mnuContiniousTimeScan.Enabled = False
        'tlbbtnContiniousTimeScan.Enabled = False

        'mnuParameters.Enabled = False
        'tlbbtnParameters.Enabled = False

        'mnuPositionToMaxima.Enabled = False
        'tlbbtnPositionToMaxima.Enabled = False
        ''Added By Pankaj 21 May 07
        'mnuLampParameters.Enabled = False
        'tlbbtnLampParameters.Enabled = False
        btnLampParameters.Enabled = True

        'mnuClearSpectrum.Enabled = False
        'tlbbtnClearSpectrum.Enabled = False

        'tlbbtnPrintGraph.Enabled = False
        'mnuPrintGraph.Enabled = False
    End Sub

    Private Sub frmTimeScanDBMode_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        Try
            'If blnActivateStartTimeScan = False Then
            '    ''Application.DoEvents()
            '    ''Call gobjCommProtocol.funcGetRefBaseVal()
            '    ''Call funcInitialise()
            '    ''funcOnSpect(False, lblTime, lblYValue)

            '    Call funcSetDefaultParameter()
            '    'Application.DoEvents()
            '    nudD2Cur.Visible = True
            '    nudPMT.Visible = True
            '    nudPMT_Ref.Visible = True
            '    nudSlit.Visible = True
            '    nudSlit_Exit.Visible = True
            '    nudHCLCur.Visible = True
            '    nudBurnerHeight.Visible = True
            '    nudFuelRatio.Visible = True
            '    blnActivateStartTimeScan = True
            '    'Application.DoEvents()
            'End If


        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------
        End Try


    End Sub

    Private Sub btnPrintGraph_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : tlbbtnPrintGraph_Click
        ' Parameters Passed     : Object, EventArgs
        ' Returns               : None
        ' Purpose               : 
        ' Description           :  to print the graph
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 17-May-2007 03:25 pm
        ' Revisions             : 1
        '=====================================================================


        'to print the graph
        Dim objWait As New CWaitCursor
        Dim mobjClsDataFileReport As clsDataFileReport

        Try
            '-----Added By Pankaj Fri 18 May 07
            If (gstructSettings.Enable21CFR = True) Then
                If Not funcCheckActivityAuthentication(enumActivityAuthentication.Print, gstructUserDetails.Access) Then
                    Return
                    Exit Sub
                End If
                gfuncInsertActivityLog(EnumModules.Print, "Print DataFiles Graph Accessed")
            End If
            '------
            If Not mobjclsBgSpectrum Is Nothing Then
                mobjclsBgSpectrum.SpectrumWait = True
            End If

            Call gobjCommProtocol.mobjCommdll.subTime_Delay(100)

            '--- Print the graph to print Preview
            mobjClsDataFileReport = New clsDataFileReport
            mobjClsDataFileReport.DefaultFont = Me.DefaultFont
            mobjClsDataFileReport.funcPrintTimescan(AASGraphTimeScan)
            If Not mobjclsBgSpectrum Is Nothing Then
                mobjclsBgSpectrum.SpectrumWait = False
            End If

            Call gobjCommProtocol.mobjCommdll.subTime_Delay(100)
            'AASD2EnergyPeak486.PrintPreViewGraph()
            'AASD2EnergyPeak656.PrintPreViewGraph()

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            mobjClsDataFileReport = Nothing
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            '---------------------------------------------------------
        End Try
    End Sub

#End Region

End Class

