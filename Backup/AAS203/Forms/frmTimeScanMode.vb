Imports System.Threading
Imports AAS203.Common
Imports BgThread
Imports System.IO
Imports Microsoft.VisualBasic
Imports AAS203.Spectrum

Public Class frmTimeScanMode
    Inherits System.Windows.Forms.Form
    Implements Iclient

#Region " Private Variable "

    ''this are the private variable which used in time scan mode

    '--- Declaration for the controller object of the BgThread
    Private mobjController As New BgThread.clsBgThread(Me)
    Private mobjclsBgSpectrum As New clsBgSpectrum
    ''this is object of clsBgSpectrum(thread class)

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
        ''this structure store some temp data about graph e.g
        ''mXaxisData  contain X point to be ploted
        Dim mGraphPlot As Boolean
        Dim mXaxisData As Integer
        Dim mYaxisData As Integer
    End Structure
    'Dim Data As _Data
    '--- declaration of the channels object (collection)
    ''this is a data structure 
    Private mobjChannnels As New Spectrum.Channels
    Private mobjOnlineChannel As New Spectrum.Channel(True)
    Private mobjOnlineReadings As New Spectrum.Readings
    Private mobjSpectrum As New clsSpectrum
    ''clsSpectrum is a class for spectrum datastructure

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


    Private mYValueLable As String = const_Absorbance
    'Private mXValueLable As String = "Timescan (Sc.): "
    Private mXValueLable As String = "Wavelength (nm): "

    Private mstrYaxisFormat As String
    Private mstrYaxisExt As String

    Private mYAXIS_LABEL As String
    Dim blnActivateStartTimeScan As Boolean
    '//-----

#End Region

#Region " Private Constants "

    Private Const ConstFormLoad = "-Time Scan Mode"
    Private Const const_WvMin = 0
    Private Const const_WvMax = 100.0
    Private Const const_YMinAbs = -0.2
    Private Const const_YMaxAbs = 1.2
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
    Private Const const_Volt = "Volt (mv)"
    Private Const const_ABSORBANCE_YLabel = "ABSORBANCE"
    Private Const const_ENERGY_YLabel = "ENERGY"
    Private Const const_EMISSION_YLabel = "EMISSION"
    Private Const const_VOLT_YLabel = "VOLT(mV)"

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
    Friend WithEvents btnClearSpectrum As NETXP.Controls.XPButton
    Friend WithEvents btnLampParameters As NETXP.Controls.XPButton
    Friend WithEvents btnReturn As NETXP.Controls.XPButton
    Friend WithEvents StatusBar1 As NETXP.Controls.Bars.StatusBar
    Friend WithEvents StatusBarPanelInfo As System.Windows.Forms.StatusBarPanel
    Friend WithEvents ProgressPanel As NETXP.Controls.Bars.ProgressPanel
    Friend WithEvents StatusBarPanelDate As System.Windows.Forms.StatusBarPanel
    Friend WithEvents cmdChangeScale As NETXP.Controls.XPButton
    Friend WithEvents cmdFilter As NETXP.Controls.XPButton
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
    Friend WithEvents MenuBarEnergySpectrumMode As NETXP.Controls.Bars.CommandBar
    Friend WithEvents mnuFile As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuDataProcessing As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuReturn As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuAutoZero As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuAdjustFuel As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuAdjustBurnerHeight As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuGraphOptions As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuPeakEdit As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuGrid As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuLegends As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuShowXYValues As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents btnExtinguish As NETXP.Controls.XPButton
    Friend WithEvents btnIgnite As NETXP.Controls.XPButton
    Friend WithEvents CommandBarSeparatorItem1 As NETXP.Controls.Bars.CommandBarSeparatorItem
    Friend WithEvents CommandBarSeparatorItem2 As NETXP.Controls.Bars.CommandBarSeparatorItem
    Friend WithEvents tlbbtnGrid As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents tlbbtnLegends As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuChangeScale As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents btnN2OIgnite As NETXP.Controls.XPButton
    Friend WithEvents btnDelete As NETXP.Controls.XPButton
    Friend WithEvents btnR As NETXP.Controls.XPButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmTimeScanMode))
        Me.CustomPanelMain = New GradientPanel.CustomPanel
        Me.AASGraphTimeScan = New AAS203.AASGraph
        Me.Office2003Header1 = New CodeIntellects.Office2003Controls.Office2003Header
        Me.CustomPanelBottom = New GradientPanel.CustomPanel
        Me.btnAutoZero = New NETXP.Controls.XPButton
        Me.cmdADJFlow = New NETXP.Controls.XPButton
        Me.cmdADJBH = New NETXP.Controls.XPButton
        Me.cmdChangeScale = New NETXP.Controls.XPButton
        Me.btnLampParameters = New NETXP.Controls.XPButton
        Me.btnClearSpectrum = New NETXP.Controls.XPButton
        Me.btnReturn = New NETXP.Controls.XPButton
        Me.btnN2OIgnite = New NETXP.Controls.XPButton
        Me.cmdFilter = New NETXP.Controls.XPButton
        Me.CustomPanelTop = New GradientPanel.CustomPanel
        Me.nudBurnerHeight = New ValueEditor.ValueEditor
        Me.nudFuelRatio = New ValueEditor.ValueEditor
        Me.nudD2Cur = New ValueEditor.ValueEditor
        Me.nudHCLCur = New ValueEditor.ValueEditor
        Me.nudSlit = New ValueEditor.ValueEditor
        Me.nudPMT = New ValueEditor.ValueEditor
        Me.HeaderLeft = New CodeIntellects.Office2003Controls.Office2003Header
        Me.lblYValue = New System.Windows.Forms.Label
        Me.lblWvPos = New System.Windows.Forms.Label
        Me.lblTime = New System.Windows.Forms.Label
        Me.cmdD2GainStatus = New NETXP.Controls.XPButton
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
        Me.btnExtinguish = New NETXP.Controls.XPButton
        Me.btnIgnite = New NETXP.Controls.XPButton
        Me.btnDelete = New NETXP.Controls.XPButton
        Me.btnR = New NETXP.Controls.XPButton
        Me.StatusBar1 = New NETXP.Controls.Bars.StatusBar
        Me.StatusBarPanelInfo = New System.Windows.Forms.StatusBarPanel
        Me.ProgressPanel = New NETXP.Controls.Bars.ProgressPanel
        Me.StatusBarPanelDate = New System.Windows.Forms.StatusBarPanel
        Me.CommandBar1 = New NETXP.Controls.Bars.CommandBar
        Me.cmdbtnReturn = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.CommandBarSeparatorItem1 = New NETXP.Controls.Bars.CommandBarSeparatorItem
        Me.cmdbtnAutoZero = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.cmdbtnAdjFuelFlow = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.cmdbtnAdjBurnerHt = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.cmdbtnChangeScale = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.CommandBarSeparatorItem2 = New NETXP.Controls.Bars.CommandBarSeparatorItem
        Me.tlbbtnGrid = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.tlbbtnLegends = New NETXP.Controls.Bars.CommandBarButtonItem
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
        Me.CustomPanelMain.Controls.Add(Me.btnDelete)
        Me.CustomPanelMain.Controls.Add(Me.btnR)
        Me.CustomPanelMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CustomPanelMain.Location = New System.Drawing.Point(0, 58)
        Me.CustomPanelMain.Name = "CustomPanelMain"
        Me.CustomPanelMain.Size = New System.Drawing.Size(804, 430)
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
        Me.AASGraphTimeScan.Location = New System.Drawing.Point(184, 22)
        Me.AASGraphTimeScan.Name = "AASGraphTimeScan"
        Me.AASGraphTimeScan.Size = New System.Drawing.Size(620, 341)
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
        Me.Office2003Header1.Location = New System.Drawing.Point(184, 0)
        Me.Office2003Header1.Name = "Office2003Header1"
        Me.Office2003Header1.Size = New System.Drawing.Size(620, 22)
        Me.Office2003Header1.TabIndex = 48
        Me.Office2003Header1.TitleFont = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Office2003Header1.TitleText = "Time Scan"
        '
        'CustomPanelBottom
        '
        Me.CustomPanelBottom.BackColor = System.Drawing.Color.AliceBlue
        Me.CustomPanelBottom.Controls.Add(Me.btnAutoZero)
        Me.CustomPanelBottom.Controls.Add(Me.cmdADJFlow)
        Me.CustomPanelBottom.Controls.Add(Me.cmdADJBH)
        Me.CustomPanelBottom.Controls.Add(Me.cmdChangeScale)
        Me.CustomPanelBottom.Controls.Add(Me.btnLampParameters)
        Me.CustomPanelBottom.Controls.Add(Me.btnClearSpectrum)
        Me.CustomPanelBottom.Controls.Add(Me.btnReturn)
        Me.CustomPanelBottom.Controls.Add(Me.btnN2OIgnite)
        Me.CustomPanelBottom.Controls.Add(Me.cmdFilter)
        Me.CustomPanelBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.CustomPanelBottom.Location = New System.Drawing.Point(184, 363)
        Me.CustomPanelBottom.Name = "CustomPanelBottom"
        Me.CustomPanelBottom.Size = New System.Drawing.Size(620, 67)
        Me.CustomPanelBottom.TabIndex = 1
        '
        'btnAutoZero
        '
        Me.btnAutoZero.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAutoZero.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAutoZero.Image = CType(resources.GetObject("btnAutoZero.Image"), System.Drawing.Image)
        Me.btnAutoZero.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAutoZero.Location = New System.Drawing.Point(8, 12)
        Me.btnAutoZero.Name = "btnAutoZero"
        Me.btnAutoZero.Size = New System.Drawing.Size(110, 35)
        Me.btnAutoZero.TabIndex = 0
        Me.btnAutoZero.Text = "Auto&Zero"
        Me.btnAutoZero.Visible = False
        '
        'cmdADJFlow
        '
        Me.cmdADJFlow.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdADJFlow.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdADJFlow.Image = CType(resources.GetObject("cmdADJFlow.Image"), System.Drawing.Image)
        Me.cmdADJFlow.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdADJFlow.Location = New System.Drawing.Point(120, 12)
        Me.cmdADJFlow.Name = "cmdADJFlow"
        Me.cmdADJFlow.Size = New System.Drawing.Size(110, 36)
        Me.cmdADJFlow.TabIndex = 1
        Me.cmdADJFlow.Text = "Adjust &Fuel Flow"
        Me.cmdADJFlow.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.cmdADJFlow.Visible = False
        '
        'cmdADJBH
        '
        Me.cmdADJBH.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdADJBH.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdADJBH.Image = CType(resources.GetObject("cmdADJBH.Image"), System.Drawing.Image)
        Me.cmdADJBH.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdADJBH.Location = New System.Drawing.Point(232, 12)
        Me.cmdADJBH.Name = "cmdADJBH"
        Me.cmdADJBH.Size = New System.Drawing.Size(110, 38)
        Me.cmdADJBH.TabIndex = 2
        Me.cmdADJBH.Text = "Adjust &Burner Ht."
        Me.cmdADJBH.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.cmdADJBH.Visible = False
        '
        'cmdChangeScale
        '
        Me.cmdChangeScale.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdChangeScale.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdChangeScale.Image = CType(resources.GetObject("cmdChangeScale.Image"), System.Drawing.Image)
        Me.cmdChangeScale.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdChangeScale.Location = New System.Drawing.Point(344, 12)
        Me.cmdChangeScale.Name = "cmdChangeScale"
        Me.cmdChangeScale.Size = New System.Drawing.Size(110, 38)
        Me.cmdChangeScale.TabIndex = 3
        Me.cmdChangeScale.Text = "Chan&ge Scale"
        Me.cmdChangeScale.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.cmdChangeScale.Visible = False
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
        Me.btnClearSpectrum.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClearSpectrum.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClearSpectrum.Location = New System.Drawing.Point(352, 78)
        Me.btnClearSpectrum.Name = "btnClearSpectrum"
        Me.btnClearSpectrum.Size = New System.Drawing.Size(106, 30)
        Me.btnClearSpectrum.TabIndex = 10
        Me.btnClearSpectrum.Text = "C&lear Spectrum"
        Me.btnClearSpectrum.Visible = False
        '
        'btnReturn
        '
        Me.btnReturn.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnReturn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnReturn.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReturn.Image = CType(resources.GetObject("btnReturn.Image"), System.Drawing.Image)
        Me.btnReturn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReturn.Location = New System.Drawing.Point(456, 12)
        Me.btnReturn.Name = "btnReturn"
        Me.btnReturn.Size = New System.Drawing.Size(110, 38)
        Me.btnReturn.TabIndex = 4
        Me.btnReturn.Text = "Return"
        Me.btnReturn.Visible = False
        '
        'btnN2OIgnite
        '
        Me.btnN2OIgnite.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnN2OIgnite.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnN2OIgnite.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnN2OIgnite.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnN2OIgnite.Location = New System.Drawing.Point(100, 40)
        Me.btnN2OIgnite.Name = "btnN2OIgnite"
        Me.btnN2OIgnite.Size = New System.Drawing.Size(5, 5)
        Me.btnN2OIgnite.TabIndex = 136
        Me.btnN2OIgnite.TabStop = False
        Me.btnN2OIgnite.Text = "N2O&C"
        Me.btnN2OIgnite.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'cmdFilter
        '
        Me.cmdFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdFilter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdFilter.Location = New System.Drawing.Point(568, 12)
        Me.cmdFilter.Name = "cmdFilter"
        Me.cmdFilter.Size = New System.Drawing.Size(38, 38)
        Me.cmdFilter.TabIndex = 15
        Me.cmdFilter.Text = "&Filter"
        '
        'CustomPanelTop
        '
        Me.CustomPanelTop.BackColor = System.Drawing.Color.AliceBlue
        Me.CustomPanelTop.Controls.Add(Me.nudBurnerHeight)
        Me.CustomPanelTop.Controls.Add(Me.nudFuelRatio)
        Me.CustomPanelTop.Controls.Add(Me.nudD2Cur)
        Me.CustomPanelTop.Controls.Add(Me.nudHCLCur)
        Me.CustomPanelTop.Controls.Add(Me.nudSlit)
        Me.CustomPanelTop.Controls.Add(Me.nudPMT)
        Me.CustomPanelTop.Controls.Add(Me.HeaderLeft)
        Me.CustomPanelTop.Controls.Add(Me.lblYValue)
        Me.CustomPanelTop.Controls.Add(Me.lblWvPos)
        Me.CustomPanelTop.Controls.Add(Me.lblTime)
        Me.CustomPanelTop.Controls.Add(Me.cmdD2GainStatus)
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
        Me.CustomPanelTop.Dock = System.Windows.Forms.DockStyle.Left
        Me.CustomPanelTop.Location = New System.Drawing.Point(0, 0)
        Me.CustomPanelTop.Name = "CustomPanelTop"
        Me.CustomPanelTop.Size = New System.Drawing.Size(184, 430)
        Me.CustomPanelTop.TabIndex = 0
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
        Me.nudBurnerHeight.Location = New System.Drawing.Point(75, 204)
        Me.nudBurnerHeight.MaxValue = 0
        Me.nudBurnerHeight.MinValue = 0
        Me.nudBurnerHeight.Name = "nudBurnerHeight"
        Me.nudBurnerHeight.Size = New System.Drawing.Size(72, 22)
        Me.nudBurnerHeight.TabIndex = 17
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
        Me.nudFuelRatio.Location = New System.Drawing.Point(75, 171)
        Me.nudFuelRatio.MaxValue = 0
        Me.nudFuelRatio.MinValue = 0
        Me.nudFuelRatio.Name = "nudFuelRatio"
        Me.nudFuelRatio.Size = New System.Drawing.Size(72, 22)
        Me.nudFuelRatio.TabIndex = 14
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
        Me.nudD2Cur.Location = New System.Drawing.Point(75, 105)
        Me.nudD2Cur.MaxValue = 0
        Me.nudD2Cur.MinValue = 0
        Me.nudD2Cur.Name = "nudD2Cur"
        Me.nudD2Cur.Size = New System.Drawing.Size(72, 22)
        Me.nudD2Cur.TabIndex = 8
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
        Me.nudHCLCur.Location = New System.Drawing.Point(75, 72)
        Me.nudHCLCur.MaxValue = 0
        Me.nudHCLCur.MinValue = 0
        Me.nudHCLCur.Name = "nudHCLCur"
        Me.nudHCLCur.Size = New System.Drawing.Size(72, 22)
        Me.nudHCLCur.TabIndex = 5
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
        Me.nudSlit.Location = New System.Drawing.Point(75, 138)
        Me.nudSlit.MaxValue = 0
        Me.nudSlit.MinValue = 0
        Me.nudSlit.Name = "nudSlit"
        Me.nudSlit.Size = New System.Drawing.Size(72, 22)
        Me.nudSlit.TabIndex = 11
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
        Me.nudPMT.Location = New System.Drawing.Point(75, 39)
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
        Me.HeaderLeft.Size = New System.Drawing.Size(184, 22)
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
        Me.lblYValue.Location = New System.Drawing.Point(12, 366)
        Me.lblYValue.Name = "lblYValue"
        Me.lblYValue.Size = New System.Drawing.Size(166, 20)
        Me.lblYValue.TabIndex = 43
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
        'lblTime
        '
        Me.lblTime.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTime.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTime.Location = New System.Drawing.Point(12, 314)
        Me.lblTime.Name = "lblTime"
        Me.lblTime.Size = New System.Drawing.Size(166, 16)
        Me.lblTime.TabIndex = 39
        Me.lblTime.Text = "Time (Sec.)"
        Me.lblTime.Visible = False
        '
        'cmdD2GainStatus
        '
        Me.cmdD2GainStatus.BackColor = System.Drawing.Color.Transparent
        Me.cmdD2GainStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdD2GainStatus.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdD2GainStatus.Location = New System.Drawing.Point(20, 267)
        Me.cmdD2GainStatus.Name = "cmdD2GainStatus"
        Me.cmdD2GainStatus.Size = New System.Drawing.Size(106, 30)
        Me.cmdD2GainStatus.TabIndex = 38
        Me.cmdD2GainStatus.Text = "D2 &Gain Status"
        Me.cmdD2GainStatus.Visible = False
        '
        'lblBurnerHeightmm
        '
        Me.lblBurnerHeightmm.BackColor = System.Drawing.Color.Transparent
        Me.lblBurnerHeightmm.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBurnerHeightmm.Location = New System.Drawing.Point(149, 208)
        Me.lblBurnerHeightmm.Name = "lblBurnerHeightmm"
        Me.lblBurnerHeightmm.Size = New System.Drawing.Size(24, 20)
        Me.lblBurnerHeightmm.TabIndex = 36
        Me.lblBurnerHeightmm.Text = "mm"
        Me.lblBurnerHeightmm.Visible = False
        '
        'lblBurnerHeight
        '
        Me.lblBurnerHeight.BackColor = System.Drawing.Color.Transparent
        Me.lblBurnerHeight.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBurnerHeight.Location = New System.Drawing.Point(7, 201)
        Me.lblBurnerHeight.Name = "lblBurnerHeight"
        Me.lblBurnerHeight.Size = New System.Drawing.Size(65, 28)
        Me.lblBurnerHeight.TabIndex = 34
        Me.lblBurnerHeight.Text = "Burner Ht."
        Me.lblBurnerHeight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblBurnerHeight.Visible = False
        '
        'lblFuelRatio
        '
        Me.lblFuelRatio.BackColor = System.Drawing.Color.Transparent
        Me.lblFuelRatio.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFuelRatio.Location = New System.Drawing.Point(7, 167)
        Me.lblFuelRatio.Name = "lblFuelRatio"
        Me.lblFuelRatio.Size = New System.Drawing.Size(63, 28)
        Me.lblFuelRatio.TabIndex = 32
        Me.lblFuelRatio.Text = "Fuel Ratio"
        Me.lblFuelRatio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblFuelRatio.Visible = False
        '
        'lblHCLCurmA
        '
        Me.lblHCLCurmA.BackColor = System.Drawing.Color.Transparent
        Me.lblHCLCurmA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHCLCurmA.Location = New System.Drawing.Point(149, 74)
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
        Me.lblHCLCur.Location = New System.Drawing.Point(7, 69)
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
        Me.lblSlitWidthnm.Location = New System.Drawing.Point(149, 140)
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
        Me.lblPMTVolts.Location = New System.Drawing.Point(149, 41)
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
        Me.lblD2CurmA.Location = New System.Drawing.Point(149, 108)
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
        Me.cmbModes.Location = New System.Drawing.Point(65, 237)
        Me.cmbModes.Name = "cmbModes"
        Me.cmbModes.Size = New System.Drawing.Size(82, 23)
        Me.cmbModes.TabIndex = 18
        Me.cmbModes.Visible = False
        '
        'lblModes
        '
        Me.lblModes.BackColor = System.Drawing.Color.Transparent
        Me.lblModes.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblModes.Location = New System.Drawing.Point(7, 234)
        Me.lblModes.Name = "lblModes"
        Me.lblModes.Size = New System.Drawing.Size(56, 28)
        Me.lblModes.TabIndex = 8
        Me.lblModes.Text = "Modes"
        Me.lblModes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblModes.Visible = False
        '
        'lblSlitWidth
        '
        Me.lblSlitWidth.BackColor = System.Drawing.Color.Transparent
        Me.lblSlitWidth.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSlitWidth.Location = New System.Drawing.Point(7, 134)
        Me.lblSlitWidth.Name = "lblSlitWidth"
        Me.lblSlitWidth.Size = New System.Drawing.Size(59, 28)
        Me.lblSlitWidth.TabIndex = 5
        Me.lblSlitWidth.Text = "Slit Width"
        Me.lblSlitWidth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblD2Cur
        '
        Me.lblD2Cur.BackColor = System.Drawing.Color.Transparent
        Me.lblD2Cur.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblD2Cur.Location = New System.Drawing.Point(7, 101)
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
        Me.lblPMT.Location = New System.Drawing.Point(8, 40)
        Me.lblPMT.Name = "lblPMT"
        Me.lblPMT.Size = New System.Drawing.Size(37, 28)
        Me.lblPMT.TabIndex = 1
        Me.lblPMT.Text = "PMT"
        Me.lblPMT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnExtinguish
        '
        Me.btnExtinguish.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExtinguish.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExtinguish.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExtinguish.Location = New System.Drawing.Point(556, 156)
        Me.btnExtinguish.Name = "btnExtinguish"
        Me.btnExtinguish.Size = New System.Drawing.Size(49, 18)
        Me.btnExtinguish.TabIndex = 15
        Me.btnExtinguish.Text = "&Extinguish"
        Me.btnExtinguish.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'btnIgnite
        '
        Me.btnIgnite.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnIgnite.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIgnite.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnIgnite.Location = New System.Drawing.Point(322, 146)
        Me.btnIgnite.Name = "btnIgnite"
        Me.btnIgnite.Size = New System.Drawing.Size(58, 20)
        Me.btnIgnite.TabIndex = 14
        Me.btnIgnite.Text = "&Ignition"
        Me.btnIgnite.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'btnDelete
        '
        Me.btnDelete.BackColor = System.Drawing.Color.Transparent
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelete.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDelete.Location = New System.Drawing.Point(366, 178)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(8, 8)
        Me.btnDelete.TabIndex = 50
        Me.btnDelete.TabStop = False
        Me.btnDelete.Text = "&Delete"
        Me.btnDelete.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'btnR
        '
        Me.btnR.BackColor = System.Drawing.Color.Transparent
        Me.btnR.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnR.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnR.Location = New System.Drawing.Point(378, 178)
        Me.btnR.Name = "btnR"
        Me.btnR.Size = New System.Drawing.Size(8, 8)
        Me.btnR.TabIndex = 49
        Me.btnR.TabStop = False
        Me.btnR.Text = "&R"
        Me.btnR.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'StatusBar1
        '
        Me.StatusBar1.Location = New System.Drawing.Point(0, 488)
        Me.StatusBar1.Name = "StatusBar1"
        Me.StatusBar1.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.StatusBarPanelInfo, Me.ProgressPanel, Me.StatusBarPanelDate})
        Me.StatusBar1.ShowPanels = True
        Me.StatusBar1.Size = New System.Drawing.Size(804, 24)
        Me.StatusBar1.TabIndex = 6
        Me.StatusBar1.Text = "StatusBar1"
        '
        'StatusBarPanelInfo
        '
        Me.StatusBarPanelInfo.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
        Me.StatusBarPanelInfo.MinWidth = 40
        Me.StatusBarPanelInfo.Style = System.Windows.Forms.StatusBarPanelStyle.OwnerDraw
        Me.StatusBarPanelInfo.Width = 509
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
        Me.CommandBar1.Items.AddRange(New NETXP.Controls.Bars.CommandBarItem() {Me.cmdbtnReturn, Me.CommandBarSeparatorItem1, Me.cmdbtnAutoZero, Me.cmdbtnAdjFuelFlow, Me.cmdbtnAdjBurnerHt, Me.cmdbtnChangeScale, Me.CommandBarSeparatorItem2, Me.tlbbtnGrid, Me.tlbbtnLegends})
        Me.CommandBar1.Location = New System.Drawing.Point(0, 24)
        Me.CommandBar1.Margins.Bottom = 1
        Me.CommandBar1.Margins.Left = 1
        Me.CommandBar1.Margins.Right = 1
        Me.CommandBar1.Margins.Top = 1
        Me.CommandBar1.Name = "CommandBar1"
        Me.CommandBar1.Size = New System.Drawing.Size(804, 34)
        Me.CommandBar1.TabIndex = 0
        Me.CommandBar1.TabStop = False
        Me.CommandBar1.Text = "CommandBar1"
        '
        'cmdbtnReturn
        '
        Me.cmdbtnReturn.Image = CType(resources.GetObject("cmdbtnReturn.Image"), System.Drawing.Image)
        Me.cmdbtnReturn.Shortcut = System.Windows.Forms.Shortcut.CtrlB
        Me.cmdbtnReturn.Text = "RETURN[CTRL+R]"
        '
        'cmdbtnAutoZero
        '
        Me.cmdbtnAutoZero.Image = CType(resources.GetObject("cmdbtnAutoZero.Image"), System.Drawing.Image)
        Me.cmdbtnAutoZero.Shortcut = System.Windows.Forms.Shortcut.CtrlZ
        Me.cmdbtnAutoZero.Text = "AUTO ZERO[CTRL+Z]"
        '
        'cmdbtnAdjFuelFlow
        '
        Me.cmdbtnAdjFuelFlow.Image = CType(resources.GetObject("cmdbtnAdjFuelFlow.Image"), System.Drawing.Image)
        Me.cmdbtnAdjFuelFlow.Shortcut = System.Windows.Forms.Shortcut.CtrlF
        Me.cmdbtnAdjFuelFlow.Text = "ADJUST FUEL FLOW[CTRL+F]"
        '
        'cmdbtnAdjBurnerHt
        '
        Me.cmdbtnAdjBurnerHt.Image = CType(resources.GetObject("cmdbtnAdjBurnerHt.Image"), System.Drawing.Image)
        Me.cmdbtnAdjBurnerHt.Shortcut = System.Windows.Forms.Shortcut.CtrlB
        Me.cmdbtnAdjBurnerHt.Text = "ADJUST BURNER HEIGHT[CTRL+B]"
        '
        'cmdbtnChangeScale
        '
        Me.cmdbtnChangeScale.Image = CType(resources.GetObject("cmdbtnChangeScale.Image"), System.Drawing.Image)
        Me.cmdbtnChangeScale.Shortcut = System.Windows.Forms.Shortcut.CtrlC
        Me.cmdbtnChangeScale.Text = "CHANGE SCALE[CTRL+C]"
        '
        'tlbbtnGrid
        '
        Me.tlbbtnGrid.Image = CType(resources.GetObject("tlbbtnGrid.Image"), System.Drawing.Image)
        Me.tlbbtnGrid.Text = "GRID[CTRL+I]"
        '
        'tlbbtnLegends
        '
        Me.tlbbtnLegends.Image = CType(resources.GetObject("tlbbtnLegends.Image"), System.Drawing.Image)
        Me.tlbbtnLegends.Text = "LEGEND[CTRL+D]"
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
        Me.MenuBarEnergySpectrumMode.Size = New System.Drawing.Size(804, 24)
        Me.MenuBarEnergySpectrumMode.Style = NETXP.Controls.Bars.CommandBarStyle.Menu
        Me.MenuBarEnergySpectrumMode.TabIndex = 7
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
        Me.mnuAutoZero.Shortcut = System.Windows.Forms.Shortcut.CtrlZ
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
        Me.mnuGraphOptions.Items.AddRange(New NETXP.Controls.Bars.CommandBarItem() {Me.mnuPeakEdit, Me.mnuGrid, Me.mnuLegends, Me.mnuShowXYValues, Me.mnuChangeScale})
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
        Me.mnuGrid.Shortcut = System.Windows.Forms.Shortcut.CtrlI
        Me.mnuGrid.Text = "&Grid"
        '
        'mnuLegends
        '
        Me.mnuLegends.Image = CType(resources.GetObject("mnuLegends.Image"), System.Drawing.Image)
        Me.mnuLegends.Shortcut = System.Windows.Forms.Shortcut.CtrlD
        Me.mnuLegends.Text = "&Legends"
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
        'frmTimeScanMode
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(804, 512)
        Me.Controls.Add(Me.CustomPanelMain)
        Me.Controls.Add(Me.StatusBar1)
        Me.Controls.Add(Me.CommandBar1)
        Me.Controls.Add(Me.MenuBarEnergySpectrumMode)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimizeBox = False
        Me.Name = "frmTimeScanMode"
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
            Call subInitialise()
            If blnActivateStartTimeScan = False Then
                Call funcSetDefaultParameter()
                nudD2Cur.Visible = True
                nudPMT.Visible = True
                nudSlit.Visible = True
                nudHCLCur.Visible = True
                blnActivateStartTimeScan = True
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

    Private Sub frmTimeScanMode_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '=====================================================================
        ' Procedure Name        :  frmTimeScanMode_Load
        ' Description           :  for handling time scan load event..
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
        Dim objWait As New CWaitCursor
        Try
            btnReturn.Enabled = False
            btnAutoZero.BringToFront()
            cmdChangeScale.BringToFront()
            Application.DoEvents()
            If mblnAvoidProcessing = True Then
                ''check a flag for avoiding a process
                Exit Sub
            End If

            mblnAvoidProcessing = True
            ShowProgressBar(gstrTitleInstrumentType & ConstFormLoad)
            ''shows current info on progress bar 
            If IsNothing(gobjclsTimer) Then
                gobjclsTimer = New clsTimer(StatusBar1, 1000)
                ''initialise a timer
            End If
            gobjclsTimer.subTimerStart(StatusBar1)
            ''start a timer
            'Call subInitialise()
            ''this is for initializatoion of time scan mode
            If funcOnSpect(False, lblTime, lblYValue) = False Then
                ''this is for starting a scanning 
                ''note in timescan scanning should automatically on 
                func_Enable_Disable(EnumProcesses.StartScan, EnumStart_End.End_of_Process)
                ''this will enable/disble the cortrol as par current process
                Exit Sub
            End If
            'Added by Saurabh 05.08.07 To set Scale at RunTime
            gobjClsAAS203.Calculate_Analysis_Graph_Param(AASGraphTimeScan, ClsAAS203.enumChangeAxis.xyAxis)
            'Added by Saurabh 05.08.07

            btnAutoZero.Focus()
            ''got a focus on auto zero button

            Call HideProgressBar()
            ''for hide progressbar

            'Saurabh 10.07.07 To bring status form in front
            gobjfrmStatus.Show()
            'Saurabh
            Me.BringToFront()
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
            objWait.Dispose()
            Application.DoEvents()
            ''allow application to perfrom its panding work.
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub frmTimeScanMode_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        '=====================================================================
        ' Procedure Name        : subInitialise
        ' Parameters Passed     : sender,e
        ' Returns               : MyBase.Closing
        ' Purpose               : 
        ' Description           : this is called when user closed a timescan mode
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 21.11.06
        ' Revisions             : 
        '=====================================================================
        ''note:
        ''this is called when user close the timescan mode
        Dim objWait As New CWaitCursor
        'Call gobjMessageAdapter.ShowMessage(constCuvetteBurner)
        'Call mnuExit_Click(sender, e)
        Try
            If mblnAvoidProcessing = True Then
                If Not (mobjController Is Nothing) Then

                    If mobjController.IsThreadRunning Then
                        ''check is there any thread is running?
                        ''if yes then stop scan
                        Call subStopScan()

                        e.Cancel = True
                        Application.DoEvents()
                        ''allow application to perfrom its panding work
                        ''and then call a mnuExit_Click event
                        Call mnuExit_Click(sender, e)
                        ''call mnuExit_Click function .this perfrom  some closing step. 
                        Exit Sub
                    End If
                End If
            Else
                If Not (mobjController Is Nothing) Then
                    If mobjController.IsThreadRunning Then
                        'Call subStopScan()
                        Application.DoEvents()
                        mobjController.Cancel()
                        ''stop the current thread
                    End If
                End If
            End If
            e.Cancel = False
            mblnExitApplication = False

            'If mblnIsfrmFlameStatusWork = True Then
            'If Not gstructSettings.ExeToRun = EnumApplicationMode.ServiceUtility Then
            '    If Not IsNothing(gobjMain) Then
            '        'gobjMain.mobjController = New BgThread.clsBgThread(gobjMain)
            '        'gobjclsBgFlameStatus = New clsBgFlameStatus
            '        gobjMain.mobjController.Start(gobjclsBgFlameStatus)
            '        gobjfrmStatus.Visible = True
            '    End If
            'End If


            'End If
            Call Application.DoEvents()
            ''here allow application to perfrom its pending work
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
            ''Dispose is a destructor 
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub mnuExit_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : mnuExit_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To close the form.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 07.10.06
        ' Revisions             : Sachin Dokhale
        '=====================================================================
        Try
            If mblnAvoidProcessing = True Then
                Call subStopScan()
                ''stop the scan befor closing 
                Call Application.DoEvents()
                Exit Sub
            Else
                If Not (mobjController Is Nothing) Then
                    If mobjController.IsThreadRunning Then
                        Application.DoEvents()
                        mobjController.Cancel()
                        ''stop the thread
                    End If
                End If
            End If
            gobjclsTimer.subTimerStop()
            ''stop a timer and allow application to perfrom its panding work.
            Application.DoEvents()
            Me.Close()

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
            mblnExitApplication = False
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub btnAutoZero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : btnAutoZero_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : this is called when user click on AutoZero button.
        ' Description           : this is used for handling autozero click event
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
            mobjclsBgSpectrum.SpectrumWait = True
            'ValueEditorUpDnEnable(False)

            Call subAutoZeroScan()

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

            'ValueEditorUpDnEnable(True)
            btnAutoZero.Focus()
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub btnLampParameters_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : btnLampParameters_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : this is called when user click on lamp parameter change
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 07.10.06
        ' Revisions             : 
        '=====================================================================
        ''note:
        ''called when user clicked on LampParameterChange

        Try
            If mblnAvoidFormProcessing = True Then
                Exit Sub
            End If
            mblnAvoidFormProcessing = True
            mobjclsBgSpectrum.SpectrumWait = True
            ''set bool SpectrumWait  true for spectrum to wait 
            subLampParameterChanged()
            ''function for lamp parameter change
            mobjclsBgSpectrum.SpectrumWait = False
            ''reset a flag for spectrumwait
            mblnAvoidFormProcessing = False
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            mobjclsBgSpectrum.SpectrumWait = False
            ''reset a flag for spectrumwait
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
        ' Purpose               : this is called when user click on Clear spectrum button
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 07.10.06
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Try
            Call subClearScan()
            ''function for clearing a spectrum
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
        ' Purpose               : this is called when user change the mode in mode combobox.
        ' Description           : select index id for Calibration mode
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 21.11.06
        ' Revisions             : 
        '=====================================================================


        ''This is used for taking action ,after the mode changed
        Dim objWait As New CWaitCursor
        Try
            'If mblnAvoidProcessing = True Then
            '    Exit Sub
            'End If
            'mblnAvoidProcessing = True
            gblnSpectrumWait = True
            ''allow spectrum to wait
            mobjclsBgSpectrum.SpectrumWait = True
            ''this is a spectrumwait flag for thread 

            Application.DoEvents()
            ''allow application to perfrom its panding work.
            cmbModes.Enabled = False
            RemoveHandler cmbModes.SelectedIndexChanged, AddressOf cmbModes_SelectedIndexChanged
            If cmbModes.SelectedIndex > -1 Then
                ''check if mode is selected or not if yes then
                'gobjInst.Mode = cmbModes.SelectedIndex
                Call funcSetSpectrumParam(cmbModes.SelectedIndex)
                ''function for setting a selected mode to spectrum parameter
            End If
            AddHandler cmbModes.SelectedIndexChanged, AddressOf cmbModes_SelectedIndexChanged

            gblnSpectrumWait = False
            ''allow spectrum to wait
            mobjclsBgSpectrum.SpectrumWait = False
            ''add a handler 
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            gblnSpectrumWait = False
            ''allow spectrum to wait
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
            'gblnSpectrumWait = False
            cmbModes.Enabled = True
            'mobjclsBgSpectrum.SpectrumWait = False
            ''restart the spectrum 
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
        ' Purpose               : this called when user click on change scale button  
        ' Description           : this is for changing a scale of spectrum as par given value.
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 21.11.06
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Dim objfrmYChangeScale As frmYChangeScale
        ''this is a object of change scale form
        Try

            'mobjclsBgSpectrum.SpectrumWait = True
            'mobjclsBgSpectrum.SpectrumWait = True
            ''allow spectrum to wait
            Application.DoEvents()
            ''allow application to perfrom its panding work.
            objfrmYChangeScale = New frmYChangeScale(mobjParameters)
            ''object of a changescale from
            objfrmYChangeScale.funcSetValidatingScale(gobjInst.Mode)
            ''setting a validation as par the selected mode
            If objfrmYChangeScale.ShowDialog() = DialogResult.OK Then
                mobjclsBgSpectrum.SpectrumWait = True
                ''set flag for spectrum wait
                If Not objfrmYChangeScale.SpectrumParameter Is Nothing Then
                    ''through this routine software accept a value from user and store it to data structure
                    mobjParameters.YaxisMax = objfrmYChangeScale.SpectrumParameter.YaxisMax
                    mobjParameters.YaxisMin = objfrmYChangeScale.SpectrumParameter.YaxisMin
                    ''get Y axis max-min value.
                    If Not funcGraphPreRequisite(mobjParameters.Cal_Mode, _
                                    mobjParameters.YaxisMin, _
                                    mobjParameters.YaxisMax) Then
                        ''this set a some prerequisite for a graph like cal. mode etc.
                        'Call gFuncShowMessage("Error in setting spectrum parameters", "Please Check Entered Spectrum Parameters", modConstants.EnumMessageType.Information)
                        Exit Sub
                    End If
                End If

                ' ------------Added By Pankaj on 8 May 07
                ''set a given scale to graph
                ''AASGraphTimeScan is a object of timescan graph
                AASGraphTimeScan.YAxisMin = mobjParameters.YaxisMin
                AASGraphTimeScan.YAxisMax = mobjParameters.YaxisMax
                gobjClsAAS203.Calculate_Analysis_Graph_Param(AASGraphTimeScan, ClsAAS203.enumChangeAxis.xyAxis)
                ''for calculating a analysis graph parameter.
                mobjclsBgSpectrum.SpectrumWait = False
            End If
            objfrmYChangeScale.Close()
            ''close the form and allow application to perfrom its panding work.
            'Application.DoEvents()
            mobjclsBgSpectrum.SpectrumWait = False
            gblnSpectrumWait = False
            Application.DoEvents()
            ''allow application to perfrom its panding work.
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            gblnSpectrumWait = False
            mobjclsBgSpectrum.SpectrumWait = False
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If

            If Not objfrmYChangeScale Is Nothing Then
                objfrmYChangeScale.Dispose()
            End If
            ''destructor
            'gblnSpectrumWait = False
            Application.DoEvents()
            ''allow application to perfrom its panding work.
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            'mobjclsBgSpectrum.SpectrumWait = False
            ''restart the thread.
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
        ' Parameters Passed     :   XMin,XMax,YMin,YMax
        ' Returns               :   
        ' Parameters Affected   :   
        ' Assumptions           :   
        ' Dependencies          :   None.
        ' Author                :   Sachin Dokhale
        ' Created               :   16.02.07
        ' Revisions             :
        '=====================================================================

        ''set the parameter 
        ''this will set the given value of scale to the graph
        Try
            mobjParameters.YaxisMax = YMax  'objfrmYChangeScale.SpectrumParameter.YaxisMax
            mobjParameters.YaxisMin = YMin  'objfrmYChangeScale.SpectrumParameter.YaxisMin
            ''get a passed value to a datastructure
            If Not funcGraphPreRequisite(mobjParameters.Cal_Mode, _
                                         mobjParameters.YaxisMin, _
                                         mobjParameters.YaxisMax) Then

                ''set the graph as par new scale
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

#Region " Form Objects "

    'Private Sub nudPMT_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    Private Sub nudPMT_ValueChanged(ByVal ChangePmt As Double)
        '=====================================================================
        ' Procedure Name        : nudPMT_ValueChanged
        ' Parameters Passed     : ChangePmt
        ' Returns               : None
        ' Purpose               : this is called when user change a PMT value
        ' Description           : perfroming action after changing a PMT value
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 21.11.06
        ' Revisions             : praveen
        '=====================================================================
        Dim objWait As New CWaitCursor
        Try
            If mblnAvoidFormProcessing = True Then
                Exit Sub
            End If
            mblnAvoidFormProcessing = True
            mobjclsBgSpectrum.SpectrumWait = True

            'RemoveHandler nudPMT.ValueEditorValueChanged, AddressOf nudPMT_ValueChanged
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

            'AddHandler nudPMT.ValueEditorValueChanged, AddressOf nudPMT_ValueChanged
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            Application.DoEvents()
        End Try
    End Sub

    Private Sub nudPMT_ValueEditorClick()
        '=====================================================================
        ' Procedure Name        : nudPMT_ValueEditorClick
        ' Parameters Passed     :  None
        ' Returns               : None
        ' Purpose               : 
        ' Description           :  handles nudPMT_ValueEditor's click event
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 21.11.06
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Dim dblReturnValue As Double

        Try
            If mblnAvoidFormProcessing = True Then
                Exit Sub
            End If
            'mblnAvoidFormProcessing = True
            mobjclsBgSpectrum.SpectrumWait = True

            'RemoveHandler nudPMT.ValueEditorClick, AddressOf nudPMT_ValueEditorClick
            Application.DoEvents()

            dblReturnValue = CInt(gobjInst.PmtVoltage)
            If funcSetFrmEditValue(dblReturnValue, "Set PMT (0 - 700)V", nudPMT.MinValue, nudPMT.MaxValue) = True Then
                nudPMT.Value = dblReturnValue
            End If

            'mblnAvoidFormProcessing = False
            mobjclsBgSpectrum.SpectrumWait = False

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)

            'mblnAvoidFormProcessing = False
            mobjclsBgSpectrum.SpectrumWait = False
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If

            'AddHandler nudPMT.ValueEditorClick, AddressOf nudPMT_ValueEditorClick
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
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
        ' Procedure Name        : nudSlit_ValueChanged
        ' Parameters Passed     : ChangeSlit
        ' Returns               : None
        ' Purpose               : this is called when user change a slit width 
        ' Description           :  
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

            'RemoveHandler nudSlit.ValueEditorValueChanged, AddressOf nudSlit_ValueChanged
            Application.DoEvents()
            Call funcSetSlit_WidthParameter(nudSlit.Value)

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
            mobjclsBgSpectrum.SpectrumWait = True
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            'AddHandler nudSlit.ValueEditorValueChanged, AddressOf nudSlit_ValueChanged
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            Application.DoEvents()
        End Try
    End Sub

    Private Sub nudSlit_ValueEditorClick()
        '=====================================================================
        ' Procedure Name        : nudSlit_ValueEditorClick
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : 
        ' Description           :  handles nudSlit_ValueEditors click event
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 21.11.06
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Dim dblReturnValue As Double
        Try
            If mblnAvoidFormProcessing = True Then
                Exit Sub
            End If
            'mblnAvoidFormProcessing = True
            mobjclsBgSpectrum.SpectrumWait = True

            'RemoveHandler nudSlit.ValueEditorClick, AddressOf nudSlit_ValueEditorClick
            Application.DoEvents()

            dblReturnValue = gobjClsAAS203.funcGet_SlitWidth()

            If funcSetFrmEditValue(dblReturnValue, "Set Slit Width (0.0 - 2.0)nm", nudSlit.MinValue, nudSlit.MaxValue) = True Then
                nudSlit.Value = dblReturnValue
            End If

            mobjclsBgSpectrum.SpectrumWait = False
            'mblnAvoidFormProcessing = False

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)

            mobjclsBgSpectrum.SpectrumWait = False
            'mblnAvoidFormProcessing = False
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If

            'AddHandler nudSlit.ValueEditorClick, AddressOf nudSlit_ValueEditorClick
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
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
        ' Procedure Name        : nudHCLCur_ValueChanged
        ' Parameters Passed     : ChangeHCLCur
        ' Returns               : None
        ' Purpose               : this is called when user change a HCl current value
        ' Description           :  
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

            'RemoveHandler nudHCLCur.ValueEditorValueChanged, AddressOf nudHCLCur_ValueChanged
            Application.DoEvents()
            If ReInitLampInstParameters = True Then
                Exit Sub
            End If
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
            
            'AddHandler nudHCLCur.ValueEditorValueChanged, AddressOf nudHCLCur_ValueChanged
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            Application.DoEvents()
        End Try
    End Sub

    Private Sub nudHCLCur_ValueEditorClick()
        '=====================================================================
        ' Procedure Name        : nudHCLCur_ValueEditorClick
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : for handling click event 
        ' Description           :  
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 21.11.06
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Dim dblReturnValue As Double
        Try
            If mblnAvoidFormProcessing = True Then
                Exit Sub
            End If
            'mblnAvoidFormProcessing = True
            mobjclsBgSpectrum.SpectrumWait = True

            'RemoveHandler nudHCLCur.ValueEditorClick, AddressOf nudHCLCur_ValueEditorClick
            Application.DoEvents()
            If ReInitLampInstParameters = True Then
                Exit Sub
            End If

            dblReturnValue = gobjInst.Current
            If funcSetFrmEditValue(dblReturnValue, "Set HCL Current (0 - 25)mA", nudHCLCur.MinValue, nudHCLCur.MaxValue) = True Then
                'mblnAvoidFormProcessing = False
                nudHCLCur.Value = dblReturnValue
            End If

            'mblnAvoidFormProcessing = False
            mobjclsBgSpectrum.SpectrumWait = False
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)

            'mblnAvoidFormProcessing = False
            mobjclsBgSpectrum.SpectrumWait = False
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            
            'AddHandler nudHCLCur.ValueEditorClick, AddressOf nudHCLCur_ValueEditorClick
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
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
        ' Procedure Name        : nudD2Cur_ValueChanged
        ' Parameters Passed     : ChangeD2Cur
        ' Returns               : None
        ' Purpose               : this is called when user change  D2 current 
        ' Description           :  
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

            'RemoveHandler nudD2Cur.ValueEditorValueChanged, AddressOf nudD2Cur_ValueChanged
            If ReInitLampInstParameters = True Then
                Exit Sub
            End If

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
            
            'AddHandler nudD2Cur.ValueEditorValueChanged, AddressOf nudD2Cur_ValueChanged
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            Application.DoEvents()
        End Try
    End Sub

    Private Sub nudD2Cur_ValueEditorClick()
        '=====================================================================
        ' Procedure Name        : nudD2Cur_ValueEditorClick
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : for handling click event
        ' Description           :  
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 21.11.06
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Dim dblReturnValue As Double
        Try
            If mblnAvoidFormProcessing = True Then
                Exit Sub
            End If
            If ReInitLampInstParameters = True Then
                Exit Sub
            End If
            'mblnAvoidFormProcessing = True
            mobjclsBgSpectrum.SpectrumWait = True

            'RemoveHandler nudD2Cur.ValueEditorClick, AddressOf nudD2Cur_ValueEditorClick
            Application.DoEvents()

            dblReturnValue = gobjInst.D2Current
            If funcSetFrmEditValue(dblReturnValue, "Set D2 Current (100 - 300)mA", nudD2Cur.MinValue, nudD2Cur.MaxValue) = True Then
                nudD2Cur.Value = dblReturnValue
            End If

            'mblnAvoidFormProcessing = False
            mobjclsBgSpectrum.SpectrumWait = False
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)

            'mblnAvoidFormProcessing = False
            mobjclsBgSpectrum.SpectrumWait = False
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If

            'AddHandler nudD2Cur.ValueEditorClick, AddressOf nudD2Cur_ValueEditorClick
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
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
        ' Procedure Name        : nudFuelRatio_ValueChanged
        ' Parameters Passed     : ChangeFuelRatio
        ' Returns               : None
        ' Purpose               : called when user change fuel ratio
        ' Description           : 
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

            'RemoveHandler nudFuelRatio.ValueEditorValueChanged, AddressOf nudFuelRatio_ValueChanged

            '---above code is commented and called following 
            '---function to set fuel according to value editor 
            '---button clicked
            FuncIncrDecrFuel(CDbl(nudFuelRatio.Value))

            If mdblFuelRatio < 0.0 Then
                nudFuelRatio.Value = 0.0
                mobjParameters.FualRatio = 0.0
                mdblFuelRatio = 0.0
            Else
                nudFuelRatio.Value = mdblFuelRatio
                mobjParameters.FualRatio = mdblFuelRatio
            End If

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
            
            'AddHandler nudFuelRatio.ValueEditorValueChanged, AddressOf nudFuelRatio_ValueChanged
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            Application.DoEvents()
        End Try
    End Sub

    Private Sub nudFuelRatio_ValueEditorClick()
        '=====================================================================
        ' Procedure Name        : nudFuelRatio_ValueEditorClick
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : to handle click event
        ' Description           :  
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 21.11.06
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Dim dblReturnValue As Double
        Dim lngReturnValue As Long

        Try
            'RemoveHandler nudFuelRatio.ValueEditorClick, AddressOf nudFuelRatio_ValueEditorClick
            If mblnAvoidFormProcessing = True Then
                Exit Sub
            End If
            'mblnAvoidFormProcessing = True
            mobjclsBgSpectrum.SpectrumWait = True

            Application.DoEvents()

            dblReturnValue = gobjClsAAS203.funcGet_Fuel_Ratio(True)

            If dblReturnValue < 0.0 Then
                dblReturnValue = 0.0
            Else
                dblReturnValue = Format(dblReturnValue, "#0.00")
            End If

            If funcSetFrmEditValue(dblReturnValue, "Set Fuel Ratio (0 - 7.66)", nudFuelRatio.MinValue, nudFuelRatio.MaxValue) = True Then
                nudFuelRatio.Value = dblReturnValue
            End If

            mobjclsBgSpectrum.SpectrumWait = False
            'mblnAvoidFormProcessing = False
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)

            mobjclsBgSpectrum.SpectrumWait = False
            'mblnAvoidFormProcessing = False
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If

            'AddHandler nudFuelRatio.ValueEditorClick, AddressOf nudFuelRatio_ValueEditorClick
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
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
        ' Procedure Name        : nudBurnerHeight_ValueChanged
        ' Parameters Passed     : ChangeFuelRatio
        ' Returns               : None
        ' Purpose               : for handling click event 
        ' Description           : 
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

            'RemoveHandler nudBurnerHeight.ValueEditorValueChanged, AddressOf nudBurnerHeight_ValueChanged
            Application.DoEvents()

            If Not (mdblBhHeight = CDbl(nudBurnerHeight.Value)) Then
                nudBurnerHeight.Value = funcSetBurner_HeightParameter(nudBurnerHeight.Value)
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

            'AddHandler nudBurnerHeight.ValueEditorValueChanged, AddressOf nudBurnerHeight_ValueChanged
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            Application.DoEvents()
        End Try
    End Sub

    Private Sub nudBurnerHeight_ValueEditorClick()
        '=====================================================================
        ' Procedure Name        : nudBurnerHeight_ValueEditorClick
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : for handling click event 
        ' Description           : for setting burner height
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 21.11.06
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Dim dblReturnValue As Double
        Try
            If mblnAvoidFormProcessing = True Then
                Exit Sub
            End If
            'mblnAvoidFormProcessing = True
            mobjclsBgSpectrum.SpectrumWait = True

            'RemoveHandler nudBurnerHeight.ValueEditorClick, AddressOf nudBurnerHeight_ValueEditorClick
            Application.DoEvents()

            dblReturnValue = Format(gobjClsAAS203.funcConvertToBurnerHeight(gobjInst.BhStep), "0.00")
            If funcSetFrmEditValue(dblReturnValue, "Set Burner Height (0.0 - 6.0)nm", nudBurnerHeight.MinValue, nudBurnerHeight.MaxValue) = True Then
                nudBurnerHeight.Value = dblReturnValue
            End If

            mobjclsBgSpectrum.SpectrumWait = False
            'mblnAvoidFormProcessing = False

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)

            mobjclsBgSpectrum.SpectrumWait = False
            'mblnAvoidFormProcessing = False
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If

            'AddHandler nudBurnerHeight.ValueEditorClick, AddressOf nudBurnerHeight_ValueEditorClick
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            Application.DoEvents()
        End Try
    End Sub

    Private Sub cmdD2GainStatus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdD2GainStatus.Click
        '=====================================================================
        ' Procedure Name        :   cmdD2GainStatus_Click
        ' Description           :   
        ' Purpose               :   for handling click event 
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
            ''for gain status

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
        ' Purpose               :  for handling click event 
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
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub cmdADJFlow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdADJFlow.Click
        '=====================================================================
        ' Procedure Name        :   cmdADJFlow_Click
        ' Description           :   
        ' Purpose               :   for handling click event 
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
            'check for application mode

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
            'check for flame presence
            If Not (gobjClsAAS203.funcFlame_Present(False)) Then
                Exit Sub
            End If
            'check for Nv Position
            If (Not gobjClsAAS203.funcCheckNvPos()) Then
                Exit Sub
            End If

            gintOptimisation = modGlobalDeclarations.EnumBH_FP_Opimisation.FuelPresure
            Dim objfrmBurnerOptimisation As New frmBurnerOptimisation
            objfrmBurnerOptimisation.ShowDialog()
            objfrmBurnerOptimisation.Dispose()
            objfrmBurnerOptimisation = Nothing


            mdblFuelRatio = gobjClsAAS203.funcGet_Fuel_Ratio(True)
            If mdblFuelRatio < 0.0 Then
                mdblFuelRatio = 0.0
            Else
                mdblFuelRatio = Format(mdblFuelRatio, "#0.00")
            End If

            nudFuelRatio.Value = mdblFuelRatio
            mobjParameters.FualRatio = mdblFuelRatio
            nudFuelRatio.Text = mdblFuelRatio
            nudFuelRatio.Refresh()

            If gobjClsAAS203.funcCheck_Flame = True Then
            Else
                Call gobjMessageAdapter.ShowMessage(constFlameErrorFlameOff)
                Application.DoEvents()
            End If

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
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub cmdADJBH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdADJBH.Click
        '=====================================================================
        ' Procedure Name        :   cmdADJFlow_Click
        ' Description           :   
        ' Purpose               :   this is called when user click on burner height button
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
    '        RemoveHandler mnuIgnite.Click, AddressOf btnAutoIgnition_Click

    '        mobjclsBgSpectrum.SpectrumWait = True
    '        Application.DoEvents()
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
    '        AddHandler mnuIgnite.Click, AddressOf btnAutoIgnition_Click
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

    '        mobjclsBgSpectrum.SpectrumWait = True
    '        Application.DoEvents()
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

#Region " Private functions "

    Private Sub subInitialise()
        '=====================================================================
        ' Procedure Name        : subInitialise
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


        ''note:
        ''this is called during the loading of a TimeScanMode.

        Dim objWait As New CWaitCursor

        Try
            ''this is for initialisation of timescan mode
            Call subRearrangeFrmOBJ()
            ''this will rearrange the control on the screen
            '//----- Added by Sachin Dokhale on 14.07.07
            If Not gstructSettings.ExeToRun = EnumApplicationMode.ServiceUtility Then
                If Not IsNothing(gobjMain) Then
                    If gobjMain.mobjController.IsThreadRunning = True Then
                        ''stop the thread if any running
                        gobjMain.mobjController.Cancel()
                        gobjCommProtocol.mobjCommdll.subTime_Delay(500)   '10.12.07
                        Application.DoEvents()
                    End If
                End If
                gobjfrmStatus.Visible = True
                Application.DoEvents()
                ''show a status form and allow application to perfrom its panding work.
            End If

            nudD2Cur.Visible = True
            nudPMT.Visible = True
            nudSlit.Visible = True
            nudHCLCur.Visible = True

            lblWvPos.Text = mXValueLable & Format(gobjInst.WavelengthCur, "#0.00") '---02.02.09
            ''format wavelength position
            lblWvPos.Refresh()
            cmbModes.Visible = True
            nudBurnerHeight.IsReverseOperation = True
            nudBurnerHeight.IsUpDownButtonToBeDisabledOnValueChange = True
            nudFuelRatio.IsUpDownButtonToBeDisabledOnValueChange = True

            'If gobjClsAAS203.funcCheck_Ignite() = True Then
            '    gobjfrmStatus.Visible = True
            'Else
            '    gobjfrmStatus.Visible = False
            'End If

            Call Application.DoEvents()
            ''allow   application to perfrom its panding work.

            If gobjInst.Mode > -1 Then
                ''set a default mode 
                cmbModes.SelectedIndex = gobjInst.Mode
            End If
            Application.DoEvents()
            Call funcSetDefaultSpectrumParameter(cmbModes.SelectedIndex)
            ''set a default spectrum parameter as par selected mode
            Call funcSetDefaultParameter()
            ''Set Spectrum Parameter
            Call gobjClsAAS203.funcReadFilterSetting()
            ''Read Filter Setting
            Call AddHandlers()
            ''this will add all the handler or event 

            gblnSpectrumTerminated = False
            gblnSpectrumWait = False
            Me.AASGraphTimeScan.AldysPane.Legend.IsVisible = mnuLegends.Checked
            Me.Refresh()
            Application.DoEvents()
            ''allow application to perfrom its panding work.
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
    End Sub

    Private Sub subRearrangeFrmOBJ()
        '=====================================================================
        ' Procedure Name        : subRearrangeFrmOBJ
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : 
        ' Description           : Rearrange of the form control Object
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 21.11.06
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        ''note:
        ''this is for arranging a control on time scan screen
        ''as par alignment
        Try
            Dim intPanelWidth, intSplitWidth As Integer
            Dim intButtonWidth As Integer
            Dim intStatingPoint1, intStatingPoint2, intStatingPoint3 As Integer
            If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
                ''for 201
                intPanelWidth = CustomPanelBottom.Width()
                intButtonWidth = btnAutoZero.Width
                intSplitWidth = intPanelWidth / 3

                If intPanelWidth > intButtonWidth Then
                    intStatingPoint1 = (intSplitWidth - intButtonWidth) / 2
                    btnAutoZero.Left = intStatingPoint1
                    intStatingPoint2 = intSplitWidth + intStatingPoint1
                    cmdChangeScale.Left = intStatingPoint2

                    intStatingPoint3 = (intSplitWidth * 2) + intStatingPoint1
                    btnReturn.Left = intStatingPoint3
                End If

                btnAutoZero.Visible = True
                cmdADJFlow.Visible = False
                cmdADJBH.Visible = False
                cmdChangeScale.Visible = True
                btnReturn.Visible = True
                nudBurnerHeight.Visible = False
                nudFuelRatio.Visible = False
                lblBurnerHeight.Visible = False
                lblBurnerHeightmm.Visible = False
                lblFuelRatio.Visible = False
                cmbModes.Top = lblFuelRatio.Location.Y  'nudFuelRatio.Location.Y
                lblModes.Top = lblFuelRatio.Location.Y

            Else
                btnAutoZero.Visible = True
                cmdADJFlow.Visible = True
                cmdADJBH.Visible = True
                cmdChangeScale.Visible = True
                btnReturn.Visible = True
                nudBurnerHeight.Visible = True
                nudFuelRatio.Visible = True
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
            objWait.Dispose()
            ''destructor
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub AddHandlers()
        '=====================================================================
        ' Procedure Name        : AddHandlers
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : To add event handlers to controls
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh
        ' Created               : 15.11.06
        ' Revisions             : 
        '=====================================================================
        Try
            ''note:
            ''this would called durinf the loading.
            ''this will add a event handler for e.g

            AddHandler cmbModes.SelectedIndexChanged, AddressOf cmbModes_SelectedIndexChanged

            AddHandler btnReturn.Click, AddressOf mnuExit_Click
            ''mnuExit_Click is called after clicking on return button.
            AddHandler cmdbtnReturn.Click, AddressOf mnuExit_Click
            AddHandler cmdbtnChangeScale.Click, AddressOf cmdChangeScale_Click
            AddHandler cmdbtnAutoZero.Click, AddressOf btnAutoZero_Click
            AddHandler cmdbtnAdjBurnerHt.Click, AddressOf cmdADJBH_Click

            AddHandler cmdbtnAdjFuelFlow.Click, AddressOf cmdADJFlow_Click
            AddHandler btnAutoZero.Click, AddressOf btnAutoZero_Click
            AddHandler btnClearSpectrum.Click, AddressOf btnClearSpectrum_Click

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

            AddHandler nudPMT.ValueEditorValueChanged, AddressOf nudPMT_ValueChanged
            AddHandler nudPMT.ValueEditorClick, AddressOf nudPMT_ValueEditorClick

            AddHandler cmdChangeScale.Click, AddressOf cmdChangeScale_Click
            AddHandler btnLampParameters.Click, AddressOf btnLampParameters_Click
            AddHandler AASGraphTimeScan.GraphScaleChanged, AddressOf AASGraphTimeScan_GraphScaleChanged
            'AddHandler mnuIgnite.Click, AddressOf btnAutoIgnition_Click
            'AddHandler mnuExtinguish.Click, AddressOf btnExtinguish_Click

            AddHandler mnuChangeScale.Click, AddressOf cmdChangeScale_Click
            AddHandler mnuReturn.Click, AddressOf mnuExit_Click
            AddHandler mnuAutoZero.Click, AddressOf btnAutoZero_Click
            AddHandler mnuAdjustBurnerHeight.Click, AddressOf cmdADJBH_Click
            AddHandler mnuAdjustFuel.Click, AddressOf cmdADJFlow_Click


            'Menu for Graph Options
            AddHandler mnuPeakEdit.Click, AddressOf mnuPeakEdit_Click
            AddHandler mnuGrid.Click, AddressOf mnuGrid_Click
            AddHandler mnuShowXYValues.Click, AddressOf mnuShowXYValues_Click
            AddHandler mnuLegends.Click, AddressOf mnuLegends_Click

            'Tlbbtn for Graph Options
            AddHandler tlbbtnGrid.Click, AddressOf mnuGrid_Click
            AddHandler tlbbtnLegends.Click, AddressOf mnuLegends_Click
            AddHandler btnDelete.Click, AddressOf btnDelete_Click
            AddHandler btnR.Click, AddressOf btnR_Click

            AddHandler btnIgnite.Click, AddressOf btnIgnite_Click
            AddHandler btnExtinguish.Click, AddressOf btnExtinguish_Click
            AddHandler btnN2OIgnite.Click, AddressOf btnN2OIgnite_Click


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
        ' Purpose               : to start the auto zero
        ' Description           : this will called after clicking on auto zero button.
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
            gblnSpectrumWait = True
            ''put spectrum on wait
            Application.DoEvents()
            ''allow application to perfrom its panding work.
            ''RemoveHandler  is a keyword for removing a event from control 
            RemoveHandler nudPMT.ValueEditorValueChanged, AddressOf nudPMT_ValueChanged
            RemoveHandler nudD2Cur.ValueEditorValueChanged, AddressOf nudD2Cur_ValueChanged
            RemoveHandler nudHCLCur.ValueEditorValueChanged, AddressOf nudHCLCur_ValueChanged

            'Call func_Enable_Disable(EnumProcesses.StartScan, EnumStart_End.Start_of_Process)

            gobjClsAAS203.subAutoZero(True)
            ''To set Auto Zero for AA,BGC and Emission Mode
            Select Case gobjInst.Mode
                Case EnumCalibrationMode.AA
                    'funcSetPmtVParameter(gobjInst.PmtVoltage - 5)
                    nudPMT.Value = gobjInst.PmtVoltage
                Case EnumCalibrationMode.AABGC
                    'funcSetHCL_CurParameter(gobjInst.Current - 0.1)
                    'funcSetD2_CurParameter(gobjInst.D2Current - 0.1)
                    'funcSetPmtVParameter(gobjInst.PmtVoltage - 5)
            End Select
            nudPMT.Value = gobjInst.PmtVoltage
            ''show PMT voltage at screen
            nudHCLCur.Value = gobjInst.Current
            ''show Current on screen
            If gstructSettings.D2Gain = True Then
                ''for D2 gain
                cmdD2GainStatus.Visible = True
                If gobjCommProtocol.funcIsD2GainOn = &H1 Then
                    'this is a function for checking D2 gain
                    cmdD2GainStatus.Text = "D2 Gain On"
                ElseIf gobjCommProtocol.funcIsD2GainOn = &H0 Then
                    cmdD2GainStatus.Text = "D2 Gain Off"
                End If
            End If
            nudD2Cur.Value = gobjInst.D2Current
            ''show a D2 current on screen
            Application.DoEvents()
            ''allow application to perfrom its panding work.

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
            AddHandler nudPMT.ValueEditorValueChanged, AddressOf nudPMT_ValueChanged
            AddHandler nudD2Cur.ValueEditorValueChanged, AddressOf nudD2Cur_ValueChanged
            AddHandler nudHCLCur.ValueEditorValueChanged, AddressOf nudHCLCur_ValueChanged

            gblnSpectrumWait = False
            ''reset the spectrum
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub subStopScan()
        '=====================================================================
        ' Procedure Name        : subStartScan
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : to stop a scan by stoping a thread
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 07.10.06
        ' Revisions             : 
        '=====================================================================
        'Dim objWait As New CWaitCursor
        Try

            'gblnSpectrumTerminated = True
            mobjclsBgSpectrum.ThTerminate = True
            ''this will allow spectrum to stop
            If Not gobjclsTimer Is Nothing Then
                gobjclsTimer.subTimerStop()
                ''stop a timer.
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
        ' Purpose               : to clear a scan
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 07.10.06
        ' Revisions             : 
        '=====================================================================
        ''note:
        ''this is used to clear the spectrum.
        Dim objWait As New CWaitCursor
        Try

            'If mblnAvoidProcessing = True Then
            '    Exit Sub
            'End If
            gblnSpectrumWait = True
            ''put spectrum on wait
            Application.DoEvents()
            ''allow application to perfrom its panding work.
            funcClearGraph()
            ''for clear the graph

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
            ''allow application to perfrom its panding work.
            If Not objWait Is Nothing Then
                objWait.Dispose()
                ''destructor.
            End If
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub subSmoothGraph()
        '=====================================================================
        ' Procedure Name        : subSmoothGraph
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : for smooth graph 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 16.10.06
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        ''note;
        ''this is called when user click smooth graph 

        Try
            Dim objchanel0 As Channel
            ''class Channel is like a data structure to hold a current spectrum data
            ''and later we modified it for smooth represention

            If mblnAvoidFormProcessing = True Then
                Exit Sub
            End If

            objchanel0 = mobjSpectrum.funcCloneESChannel(mobjChannnels(mintChannelIndex))
            'Add the channel data to the Channels object
            ' with the readings collection as MAX_RANGE
            ''now objchanel0  we had a spectrum data 
            If Not (objchanel0) Is Nothing Then
                mobjSpectrum.funcSmooth1(objchanel0, 0)
                ''function for smoothing a graph 
                ''we have to pass Source channel,Destination channel for smoothing.
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
        ' Purpose               : to find a peak valley
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 14.12.06
        ' Revisions             : 
        '=====================================================================
        'Dim objWait As New CWaitCursor
        Dim objDataTable As New DataTable
        ''obj for datatable for holding temp data
        Dim objPeakVallyChannel As Channel
        ''this is a object of channel(data structure for holding a spectrum data)
        Dim intCounter As Integer = 0
        Dim lngPeakValleyCounts As Long
        ''variable for valley count
        Try

            If mblnAvoidFormProcessing = True Then
                ''flag for avoid process
                Exit Sub
            End If
            mblnAvoidFormProcessing = True
            If Not (mobjChannnels.item(mintChannelIndex) Is Nothing) Then
                ''if data is present in a data structure
                If mobjSpectrum.funcPeaks(mobjChannnels.item(mintChannelIndex), mStuctPeaksValley) = False Then
                    ''function for find a peak we have to pass a data structure holding a data and a structure
                    gobjMessageAdapter.ShowMessage(constErrorPeakValley)
                    ''shows the peak not found message.
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
            ''made a new obj to datastructure channel

            If Not mobjSpectrum.funcGetDataPeakPickResults(objDataTable, mStuctPeaksValley, lngPeakValleyCounts, objPeakVallyChannel) Then
                ''this will get a result of peakpick in a objDataTable .

                'gFuncShowMessage("Error...", "Error in populating the peak valley data in the data table to display on the screen.", EnumMessageType.Information)'138
            End If

            Dim frmPeakPick As New frmPeakPicks
            ''new obj to form peak
            Call frmPeakPick.funcDisplayPicPeakResults(objDataTable)
            ''for display a peak result from objDataTable


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
            ''destructor

            Call subClearScan()
            ''clears the scan
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
        ' Purpose               : for changing a lamp parameter  
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 07.12.06
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Dim objfrmChangeLampPara As New frmChangeLampParameters
        ''obj to form lamp parameter
        Try
            'If mblnAvoidProcessing = True Then
            '    Exit Sub
            'End If
            'mblnAvoidProcessing = True
            gblnSpectrumWait = True
            ''allow spectrum to wait
            Application.DoEvents()
            ''allow application to perfrom panding task

            If objfrmChangeLampPara.ShowDialog() = DialogResult.OK Then
                ''show the dilog and accept a new value of HCL current
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
            ''destructor
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
        ' Returns               : True, if success
        ' Purpose               : 
        ' Description           : Set Spectrum Parameter
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 21.11.06
        ' Revisions             : praveen deshmukh 
        '=====================================================================
        Dim intMaxD2Current As Integer
        Dim intMinD2Current As Integer
        ''note:
        ''this function set all the parameter to collection
        ''this is a bool function so if it get succeed it return true
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
                ''set the value of PMT from data structure to screen

                'nudPMT.Value = gobjInst.PmtVoltage
                nudPMT.Value = mobjChannnels(mintChannelIndex).EnegryParameter.PMTV()
                ''for eg this take a PMT value from data structure and set to PMT value
                ''and so on 

                '//-----

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
                ''set a slitwidth at screen
                nudBurnerHeight.Value = mobjChannnels(mintChannelIndex).EnegryParameter.BurnerHeight
                ''set a burner height at screen
                nudFuelRatio.Value = mobjChannnels(mintChannelIndex).EnegryParameter.FualRatio
                ''set a fuelratio at screen
                nudHCLCur.Value = mobjChannnels(mintChannelIndex).EnegryParameter.HCLCurr
                ''set a HCL current at screen


                '//-----

                cmbModes.SelectedIndex = mobjChannnels(mintChannelIndex).EnegryParameter.Cal_Mode()

            End If
            Application.DoEvents()
            ''allow application to perfrom its panding work
            funcSetParameter = True
            ''returning true if successful

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
        ' Returns               : True, if success
        ' Purpose               : 
        ' Description           :this is for getting  Instrument Parameter and display it on screen.
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 21.11.06
        ' Revisions             : 
        '=====================================================================
        Dim intMaxD2Current As Integer
        Dim intMinD2Current As Integer
        ''note:
        ''this is for getting  Instrument Parameter form ginst object and display it on screen

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

            RemoveHandler nudPMT.ValueEditorValueChanged, AddressOf nudPMT_ValueChanged
            RemoveHandler nudPMT.ValueEditorClick, AddressOf nudPMT_ValueEditorClick
            '//-----
            'End If

            'If mobjChannnels(mintChannelIndex).ChannelNo > -1 Then


            nudPMT.Value = gobjInst.PmtVoltage
            ''for eg hare PMT voltage from gobjinst is displayed at screen
            ''and so on 
            ''gobjInst is a global instrument object containing instrument para

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
            ''for getting a slitwidth

            'nudBurnerHeight.Value = mobjChannnels(mintChannelIndex).EnegryParameter.BurnerHeight
            nudBurnerHeight.Value = gobjClsAAS203.funcReadBurnerHeight()
            ''for getting a burnerheight

            'nudFuelRatio.Value = mobjChannnels(mintChannelIndex).EnegryParameter.FualRatio
            'funcSetFuelParameter(0) '---16.05.10
            funcSetFuelParameter(mdblFuelRatio) '---16.05.10
            mdblFuelRatio = Format(mdblFuelRatio, "#.00")
            nudFuelRatio.Value = Format(mdblFuelRatio, "#.00")
            ''''for getting a fuelratio

            'nudHCLCur.Value = mobjChannnels(mintChannelIndex).EnegryParameter.HCLCurr
            nudHCLCur.Value = gobjInst.Current
            ''for getting a HCL current
            If Not (mobjParameters Is Nothing) Then
                ''copy a parameter from gobjInst to mobjParameters
                mobjParameters.PMTV = gobjInst.PmtVoltage
                ''copy a PMT voltage
                mobjParameters.HCLCurr = gobjInst.Current
                ''copy a HCL current
                mobjParameters.SlitWidth = Val(nudSlit.Value)
                ''copy a slit width
                mobjParameters.D2Curr = gobjInst.D2Current
                ''copy a D2 curr
                mobjParameters.BurnerHeight = CDbl(nudBurnerHeight.Value)
                ''copy a burner height
                mobjParameters.FualRatio = Format(mdblFuelRatio, "#.00")
                ''copy a fuel ratio.
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

            AddHandler nudPMT.ValueEditorValueChanged, AddressOf nudPMT_ValueChanged
            AddHandler nudPMT.ValueEditorClick, AddressOf nudPMT_ValueEditorClick
            'End If
            '//---
            Application.DoEvents()
            ''allow instrument to perfrom its panding work
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
        ' Parameters Passed     : intSpeed  , this is a speed which has to be set.
        ' Returns               : Boolean, if succed then true else false
        ' Purpose               : to set a given speed to instrument
        ' Description           : Set scan Speed
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 22.11.06
        ' Revisions             : 
        '=====================================================================

        Try
            funcSetSpeed = False
            ''note:
            ''set the speed as par user passed
            Select Case intSpeed
                Case 0
                    mobjParameters.ScanSpeed = CONST_FASTStep '50.0
                Case 1
                    mobjParameters.ScanSpeed = CONST_MEDIUMStep '25.0
                Case 2
                    mobjParameters.ScanSpeed = CONST_SLOWStep '5.0
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

    'Private Sub subLabelDisplay(ByVal objChannel As Spectrum.Channel)
    '    ''not in used.
    '    Try
    '        'Select Case objChannel.Parameter.ScanSpeed
    '        '    Case EnumScanSpeed.Fast
    '        '        lblScanSpeed.Text = CONST_SCAN_SPEED_FAST
    '        '    Case EnumScanSpeed.Medium
    '        '        lblScanSpeed.Text = CONST_SCAN_SPEED_MEDIUM
    '        '    Case EnumScanSpeed.Slow
    '        '        lblScanSpeed.Text = CONST_SCAN_SPEED_SLOW
    '        '    Case EnumScanSpeed.VerySlow
    '        '        lblScanSpeed.Text = CONST_SCAN_SPEED_VERY_SLOW
    '        'End Select

    '        'lblAnalystName.Text = objChannel.Parameter.AnalystName
    '        'lblAnalystName.Refresh()
    '        'lblSpectrumName.Text = objChannel.Parameter.ChannelName
    '        'lblSpectrumName.Refresh()
    '        'added and commented by kamal on 19March2004
    '        '----------------------------
    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        'Error Handling and logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = ex.Message
    '        gobjErrorHandler.WriteErrorLog(ex)
    '        'gobjErrorHandler.ProcessError(ErrorHandler.EnumErrorType.Critical, ex)
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

    Private Function funcAddChannelToCollection(ByRef objInChannel As Spectrum.Channel) As Integer
        '=====================================================================
        ' Procedure Name        :   funcAddChannelToCollection
        ' Description           :   Add the channel to the channels collection
        '                           mobjChannels to the next index of the current 
        '                           active index of the channel.
        ' Purpose               :   To add the channel object to the channels
        '                           collection (stored in the module level).
        ' Parameters Passed     :   pass a object of channel to be passed.
        ' Returns               :   new index of the channel added.
        ' Parameters Affected   :   objInChannel
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
            ''get a totalnumber of channel from data structure
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
    '    '=====================================================================
    '    ' Procedure Name        : funcCloneParameter
    '    ' Parameters Passed     : inobjparamter is Energy Spectrum Parameter
    '    ' Returns               : Spectrum.EnergySpectrumParameter
    '    ' Purpose               : 
    '    ' Description           : to make a clone for object.
    '    ' Assumptions           : 
    '    ' Dependencies          : 
    '    ' Author                : Sachin Dokhale
    '    ' Created               : 21.11.06
    '    ' Revisions             : 
    '    '=====================================================================
    '    ''this will make a clone of instrument parameter
    '    ''we have to pass object to be clone
    '    ''and this will return a object having all parameter clone copy
    '    Try
    '        Dim objCloneParameter As New EnergySpectrumParameter
    '        '----------------------Cloning  parameter object ----------------------------------
    '        objCloneParameter.AnalysisDate = inobjparamter.AnalysisDate
    '        ''make a clone of AnalysisDate 
    '        objCloneParameter.BurnerHeight = inobjparamter.BurnerHeight
    '        ''make a clone of burner height
    '        objCloneParameter.FualRatio = inobjparamter.FualRatio
    '        ''make a clone of fuel ratio
    '        objCloneParameter.HCLCurr = inobjparamter.HCLCurr
    '        ''make a clone of HCL current
    '        objCloneParameter.LampEle = inobjparamter.LampEle
    '        ''make a clone of lamp element
    '        objCloneParameter.LampTurrNo = inobjparamter.LampTurrNo
    '        ''make a clone of lamp turrert no
    '        objCloneParameter.Cal_Mode = inobjparamter.Cal_Mode
    '        ''make a clone of calibration mode.
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
        ' Parameters Passed     : intCalibrationMode,this is a mode of calibration
        ' Returns               : true if succed
        ' Purpose               : for setting default parameter
        ' Description           :this is called for Setting default Spectrum Parameter
        ' Assumptions           : calibration mode is present
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 21.11.06
        ' Revisions             : 
        '=====================================================================
        Static blnSetDefaultSpectrumParameter As Boolean
        ''bool datatype blnSetDefaultSpectrumParameter 

        Try
            funcSetDefaultSpectrumParameter = False
            '//----- Set the default parameter to the spectrum.
            If (gobjInst.Mode = intCalibrationMode) And (blnSetDefaultSpectrumParameter = True) Then
                ''check whatever given mode is correct or not
                funcSetDefaultSpectrumParameter = True
                Exit Function
            End If

            If gobjCommProtocol.funcCalibrationMode(intCalibrationMode) Then
                ''this is a serial communication function for setting given calibration mode to instrument.
                'If (gobjInst.Mode = EnumCalibrationMode.MABS) Or (gobjInst.Mode = EnumCalibrationMode.AA) Or (gobjInst.Mode = EnumCalibrationMode.AABGC) Or (gobjInst.Mode = EnumCalibrationMode.AABGCSR) Then
                '    nudD2Cur.Enabled = True
                'Else
                '    nudD2Cur.Enabled = False
                'End If
                'addataSpect.dblWvMin = 230.0
                'addataSpect.dblWvMax = 250.0
                mobjParameters.XaxisMin = 0
                mobjParameters.XaxisMax = 100.0
                ''set a graph X-axis default scale
                Select Case gobjInst.Mode
                    ''set a default parameter as par calibration mode
                Case EnumCalibrationMode.AA, EnumCalibrationMode.AABGC, EnumCalibrationMode.MABS
                        ''set a default parameter as par calibration mode
                        mobjParameters.YaxisMax = const_YMaxAbs
                        mobjParameters.YaxisMin = const_YMinAbs
                        mYValueLable = const_Absorbance
                    Case EnumCalibrationMode.HCLE, EnumCalibrationMode.D2E
                        ''set a default parameter as par calibration mode
                        mobjParameters.YaxisMin = const_YMinEnergy
                        mobjParameters.YaxisMax = const_YMaxEnergy
                        mYValueLable = const_Energy
                    Case EnumCalibrationMode.EMISSION
                        ''set a default parameter as par calibration mode
                        mobjParameters.YaxisMin = const_YMinEmission
                        mobjParameters.YaxisMax = const_YMaxEmission
                        mYValueLable = const_Emission
                    Case EnumCalibrationMode.SELFTEST
                        ''set a default parameter as par calibration mode
                        mobjParameters.YaxisMin = const_YMinmVolt
                        mobjParameters.YaxisMax = const_YMaxmVolt
                        mYValueLable = const_Volt
                End Select

                'addataSpect.intSpeed = 0
                'addataSpect.intMode = gobjInst.Mode



                mobjParameters.ScanSpeed = CONST_SLOWStep
                ''set a speed
                mobjParameters.Cal_Mode = gobjInst.Mode
                ''set a calibration mode.
                'addataSpect.blnPloted = True
                '//-----
                AASGraphTimeScan.AldysPane.Legend.IsVisible = False
                funcClearGraph()
                ''for clear a graph

                funcGraphPreRequisite(mobjParameters.Cal_Mode, _
                                        mobjParameters.XaxisMin, _
                                        mobjParameters.XaxisMax, _
                                        mobjParameters.YaxisMin, _
                                        mobjParameters.YaxisMax)
                ''for setting a time scan graph as par user defined calibration mode 
                blnSetDefaultSpectrumParameter = True
                funcSetDefaultSpectrumParameter = True
                gobjClsAAS203.Calculate_Analysis_Graph_Param(AASGraphTimeScan, ClsAAS203.enumChangeAxis.xyAxis)     'Added by Saurabh 03.08.07
                ''for calculating a graph parameter.
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
        ' Parameters Passed     : intCalibrationMode  
        ' Returns               : True if success
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
                ''check for given calibration mode
                funcSetSpectrumParameter = True
                Exit Function
            End If

            If gobjCommProtocol.funcCalibrationMode(intCalibrationMode) Then
                ''serial communication function for setting given calibration mode to instrument

                'If (gobjInst.Mode = EnumCalibrationMode.MABS) Or (gobjInst.Mode = EnumCalibrationMode.AA) Or (gobjInst.Mode = EnumCalibrationMode.AABGC) Or (gobjInst.Mode = EnumCalibrationMode.AABGCSR) Then
                '    nudD2Cur.Enabled = True
                'Else
                '    nudD2Cur.Enabled = False
                'End If
                'addataSpect.dblWvMin = 230.0
                'addataSpect.dblWvMax = 250.0

                Select Case gobjInst.Mode
                    ''setting parameter as par calibration mode
                Case EnumCalibrationMode.AA, EnumCalibrationMode.AABGC, EnumCalibrationMode.MABS
                        ''setting parameter as par calibration mode

                        mobjParameters.YaxisMax = const_YMaxAbs
                        mobjParameters.YaxisMin = const_YMinAbs
                        mYValueLable = const_Absorbance
                    Case EnumCalibrationMode.HCLE, EnumCalibrationMode.D2E
                        ''setting parameter as par calibration mode

                        mobjParameters.YaxisMin = const_YMinEnergy
                        mobjParameters.YaxisMax = const_YMaxEnergy
                        mYValueLable = const_Energy
                    Case EnumCalibrationMode.EMISSION
                        ''setting parameter as par calibration mode

                        mobjParameters.YaxisMin = const_YMinEmission
                        mobjParameters.YaxisMax = const_YMaxEmission
                        mYValueLable = const_Emission
                    Case EnumCalibrationMode.SELFTEST
                        ''setting parameter as par calibration mode

                        mobjParameters.YaxisMin = const_YMinmVolt
                        mobjParameters.YaxisMax = const_YMaxmVolt
                        mYValueLable = const_Volt
                End Select

                mobjParameters.XaxisMin = 0
                mobjParameters.XaxisMax = 100

                'addataSpect.intSpeed = 0
                'addataSpect.intMode = gobjInst.Mode

                mobjParameters.Cal_Mode = gobjInst.Mode
                ''set a calibration mode

                'addataSpect.blnPloted = True
                '//-----
                AASGraphTimeScan.AldysPane.Legend.IsVisible = False
                funcClearGraph()
                ''clear a graph
                funcGraphPreRequisite(mobjParameters.Cal_Mode, _
                                        mobjParameters.XaxisMin, _
                                        mobjParameters.XaxisMax, _
                                        mobjParameters.YaxisMin, _
                                        mobjParameters.YaxisMax)
                ''set a timescan graph as par a given value

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
        ' Parameters Passed     : calibration mode
        ' Returns               : bool
        ' Purpose               : setting parameter as par calibration mode
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
                ''check for calibration mode exit or not.
                funcSetSpectrumParam = True
                Exit Function
            End If

            If gobjCommProtocol.funcCalibrationMode(intCalibrationMode) Then
                ''serial communication function for setting calibration mode.

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
                AASGraphTimeScan.AldysPane.Legend.IsVisible = False
                Select Case gobjInst.Mode
                    ''set a parameter as per calibration mode
                Case EnumCalibrationMode.AA, EnumCalibrationMode.AABGC, EnumCalibrationMode.MABS
                        ''set a parameter as per calibration mode
                        mobjParameters.YaxisMax = const_YMaxAbs
                        mobjParameters.YaxisMin = const_YMinAbs
                        mYAXIS_LABEL = const_ABSORBANCE_YLabel
                        mYValueLable = const_Absorbance
                        mstrYaxisFormat = "0.000"
                        mstrYaxisExt = ""
                    Case EnumCalibrationMode.HCLE, EnumCalibrationMode.D2E
                        ''set a parameter as per calibration mode
                        mobjParameters.YaxisMin = const_YMinEnergy
                        mobjParameters.YaxisMax = const_YMaxEnergy
                        mYAXIS_LABEL = const_ENERGY_YLabel
                        mYValueLable = const_Energy
                        mstrYaxisFormat = "0.00#"
                        mstrYaxisExt = ""
                    Case EnumCalibrationMode.EMISSION
                        ''set a parameter as per calibration mode
                        mobjParameters.YaxisMin = const_YMinEmission
                        mobjParameters.YaxisMax = const_YMaxEmission
                        mYAXIS_LABEL = const_EMISSION_YLabel
                        mYValueLable = const_Emission
                        mstrYaxisFormat = "0.0"
                        mstrYaxisExt = "%"
                    Case EnumCalibrationMode.SELFTEST
                        ''set a parameter as per calibration mode
                        mobjParameters.YaxisMin = const_YMinmVolt
                        mobjParameters.YaxisMax = const_YMaxmVolt
                        mYAXIS_LABEL = const_VOLT_YLabel
                        mYValueLable = const_Volt
                        mstrYaxisFormat = "0.0"
                        mstrYaxisExt = ""
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
                lblYValue.Text = mYValueLable & ": "
                lblYValue.Refresh()
                Application.DoEvents()

                'uncommented by Saurabh 05.08.07
                funcGraphPreRequisite(mobjParameters.Cal_Mode, _
                                        mobjParameters.XaxisMin, _
                                        mobjParameters.XaxisMax, _
                                        mobjParameters.YaxisMin, _
                                        mobjParameters.YaxisMax)
                ''setting graph as par new given value

                'uncommented by Saurabh 05.08.07

                'Added by Saurabh 05.08.07 To set Scale at RunTime
                gobjClsAAS203.Calculate_Analysis_Graph_Param(AASGraphTimeScan, ClsAAS203.enumChangeAxis.xyAxis)
                'Added by Saurabh 05.08.07

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
        ' Returns               : true if success
        ' Purpose               : 
        ' Description           : Set default Spectrum Parameter
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 19.12.06
        ' Revisions             : 
        '=====================================================================
        Dim intMaxD2Current As Integer
        Dim intMinD2Current As Integer
        Try

            ''below is a "c" code 
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
            ''for reinitli a instrument parameter for eg D2 off
            '//--------
            '/----- Set the Form object parameter
            '//----- Set the default parameter to the spectrum.

            'mobjParameters.Cal_Mode = gobjInst.Mode
            cmbModes.SelectedIndex = gobjInst.Mode
            ''show selected mode on combo  box

            'mobjParameters.ScanSpeed = CONST_SLOWStep


            '//----- Set PMT Object
            'Scroll_Pmt(hwnd,IDC_PMT, -1);
            'nudPMT.DecimalPlaces = 0
            nudPMT.DecimalPlace = 0
            'nudPMT.Increment = 5.0
            nudPMT.ChangeFactor = 5.0
            nudPMT.MaxValue = 700.0
            ''for setting default Max pmt as 700.
            nudPMT.MinValue = 0.0
            ''above we are setting default parameter
            nudPMT.Value = gobjInst.PmtVoltage
            mobjParameters.PMTV = gobjInst.PmtVoltage
            '//-----
            '         if (Inst->Mode==AA || Inst->Mode ==HCLE || Inst->Mode==AABGC ||Inst->Mode==AABGCSR)
            '	Scroll_Cur(hwnd,IDC_CUR, -1 );
            '         Else
            '	EnableWindow(GetDlgItem(hwnd,IDC_CUR),FALSE);





            '//----- Set D2 current Object
            If gobjCommProtocol.SRLamp Then
                ''check for SR lamp.
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
            ''get a D2 current value.
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
            If (gobjInst.Mode = EnumCalibrationMode.AA) Or (gobjInst.Mode = EnumCalibrationMode.HCLE) Or (gobjInst.Mode = EnumCalibrationMode.AABGC) Or (gobjInst.Mode = EnumCalibrationMode.AABGCSR) Then
                nudHCLCur.Enabled = True
            Else
                '    nudHCLCur.Enabled = False
            End If



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
            '//-----

            '//----- Set Fuel Ratio object
            'nudFuelRatio.DecimalPlaces = 2
            'nudFuelRatio.Increment = 0.1
            'nudFuelRatio.Maximum = 25.0
            'nudFuelRatio.Minimum = 0.0

            If Not gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then

                nudFuelRatio.DecimalPlace = 2
                nudFuelRatio.ChangeFactor = 0.1
                nudFuelRatio.MaxValue = 25.0
                nudFuelRatio.MinValue = 0.0

                Call gobjCommProtocol.funcGet_NV_Pos()
                ''serial communication function for setting NV position
                mdblFuelRatio = gobjClsAAS203.funcGet_Fuel_Ratio(True)
                ''for getting fuel ratio
                mdblFuelRatio = Format(mdblFuelRatio, "#.00")
                ''for formatting a display of fuelratio
                If mdblFuelRatio < 0.0 Then
                    ''setting some validation
                    nudFuelRatio.Value = 0.0
                Else
                    nudFuelRatio.Value = mdblFuelRatio
                End If
                mobjParameters.FualRatio = mdblFuelRatio
                '//-----

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

                nudFuelRatio.Visible = True
                nudBurnerHeight.Visible = True
                lblFuelRatio.Visible = True
                lblBurnerHeight.Visible = True
                lblBurnerHeightmm.Visible = True
                cmbModes.Visible = True
                lblModes.Visible = True

                '//-----
            Else
                nudFuelRatio.Visible = False
                nudBurnerHeight.Visible = False
                lblFuelRatio.Visible = False
                lblBurnerHeight.Visible = False
                lblBurnerHeightmm.Visible = False
                lblModes.Top = lblFuelRatio.Top
                cmbModes.Top = nudFuelRatio.Top
                cmbModes.Visible = True
                lblModes.Visible = True

            End If

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
                ''here we are checking D2 gain is on or off

            Else
                cmdD2GainStatus.Visible = False
            End If
            '//-----
            'mobjParameters.Cal_Mode = gobjInst.Mode
            'cmbModes.SelectedIndex = gobjInst.Mode

            'mobjParameters.ScanSpeed = CONST_SLOWStep
            '//-----

            Call gobjClsAAS203.ReInitInstParameters()
            ''for reinitialisation of instrument
            blnCheckMinAbsScanLmt = gstructSettings.SetMinAbsLimit
            dblAbsScanthldval = gstructSettings.AbsThresholdValue

            funcSetDefaultParameter = True
            ''set a functionreturning true value

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
        ' Parameters Passed     : dblPmtV , value of PMT is to set
        ' Returns               : Boolean
        ' Purpose               : 
        ' Description           : Set Pmt Volt Parameter
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 22.11.06
        ' Revisions             : 
        '=====================================================================

        ''note:
        ''validate a pmt value before sending it to instrument.
        Dim dblPMTVolt As Double
        Dim dblAdjPMTVolt As Double

        Try
            funcSetPmtVParameter = False
            gblnSpectrumWait = True
            ''put spectrum on wait
            dblPMTVolt = gobjInst.PmtVoltage
            ''get a pmt from gobjInst to a local variable


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
                    ''serial communication function for setting PMT
                    'gobjInst.PmtVoltage = dblPMTVolt
                    funcSetPmtVParameter = True
                End If
                'funcSetPmtVParameter = True
            End If
            ''this function is for setting some validation range of pmt.
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
        ' Returns               : Boolean. hcl curr which is to be set
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
            ''allow spectrum to be wait
            If gobjInst.Lamp_Position >= 1 And gobjInst.Lamp_Position <= gobjClsAAS203.funcGetMaxLamp() Then
                ''check for lamp position 
                dblLampCurrent = gobjInst.Current
                'dblHCL_Cur()
                dblLampCurrent = dblHCL_Cur
                If dblHCL_Cur > 25 Then dblLampCurrent = 25
                If dblHCL_Cur < 0 Then dblLampCurrent = 0
                gobjCommProtocol.funcSet_HCL_Cur(dblLampCurrent, gobjInst.Lamp_Position)
                ''serial communication function for setting HCL current
                gobjInst.Current = dblLampCurrent
            End If

            funcSetHCL_CurParameter = True
            ''this is for setting a HCL current with proper range
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
        ' Parameters Passed     : dblD2_Cur, which is to be set
        ' Returns               : Boolean
        ' Purpose               : 
        ' Description           : Set D2 Current Parameter with proper range
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 22.11.06
        ' Revisions             : 
        '=====================================================================

        ''note:
        ''this is used to set D2 current to instrument

        Dim intMaxD2Current = 300
        Dim intMinD2Current = 100
        Dim D2CurrIncrDecr As Integer
        Dim intD2Lamp_Cur As Double = 0

        Try
            funcSetD2_CurParameter = False
            gblnSpectrumWait = True
            ''put spectrum on wait
            If gobjCommProtocol.SRLamp Then
                ''set a min, max curr for SRLamp if true
                intMaxD2Current = 600
                intMinD2Current = 100
            Else
                'if not
                intMaxD2Current = 300
                intMinD2Current = 100
            End If

            intD2Lamp_Cur = gobjInst.D2Current
            ''get a D2 Current
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
            ''serial communication function for setting D2 Current

            If gobjCommProtocol.SRLamp Then
                ''for SR lamp
                gobjInst.D2Current = intD2Lamp_Cur
            Else
                If intD2Lamp_Cur = 100 Then

                End If
            End If

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

    Private Function funcSetSlit_WidthParameter(ByVal dblSlit_Width As Double) As Boolean
        '=====================================================================
        ' Procedure Name        : funcSetSlit_WidthParameter
        ' Parameters Passed     : dblSlit_Width ,slitwidth is to be set
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
            ''allow spectrum to wait
            dblSlitWidth = gobjClsAAS203.funcGet_SlitWidth()
            ''get a slit width

            If dblSlit_Width > dblSlitWidth Then
                dblAdjSlitWidth = dblSlit_Width - dblSlitWidth
                If dblAdjSlitWidth > 0 Then
                    dblSlitWidth += dblAdjSlitWidth
                End If
                'dblSlitWidth += 0.1

            End If

            If dblSlit_Width < dblSlitWidth Then
                dblAdjSlitWidth = dblSlitWidth - dblSlit_Width
                If dblAdjSlitWidth > 0 Then
                    dblSlitWidth -= dblAdjSlitWidth
                End If
                'dblSlitWidth -= 0.1
            End If

            If dblSlit_Width < 0 Then dblSlitWidth = 2.0
            If dblSlit_Width > 2 Then dblSlitWidth = 0.0

            Call gobjCommProtocol.funcSet_SlitWidth(dblSlitWidth, 0)
            ''serial communication function for setting SlitWidth
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

    Private Function funcSetFuelParameter(ByVal dblFuel As Double) As Double
        '=====================================================================
        ' Procedure Name        : funcSetFuelParameter
        ' Parameters Passed     : dblFuel 
        ' Returns               : Double
        ' Purpose               : 
        ' Description           : for Set Fuel Parameter
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 22.11.06
        ' Revisions             : 
        '=====================================================================
        Try
            funcSetFuelParameter = False

            If Not (mdblFuelRatio = dblFuel) Then

                Call gobjClsAAS203.funcSetFuel(CDbl(nudFuelRatio.Value))
                ''function for setting fuel.
            End If

            'Call gobjCommProtocol.funcGet_NV_Pos()
            ''serial communication for setting fuel parameter
            mdblFuelRatio = gobjClsAAS203.funcGet_Fuel_Ratio(True)
            If mdblFuelRatio < 0.0 Then
                ''setting some validation
                mdblFuelRatio = 0.0
            Else
                mdblFuelRatio = Format(mdblFuelRatio, "#0.00")
            End If
            ''for getting fuel ratio
            mobjParameters.FualRatio = mdblFuelRatio

            mdblFuelRatio = Format(mdblFuelRatio, "#.00")
            ''for format 
            funcSetFuelParameter = mdblFuelRatio

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
        ' Parameters Passed     : dblBurner_Height is to be set 
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
            ''allow spectrum to wait during the process
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

            gobjClsAAS203.funcSetBHPos(FormatNumber(dblBurner_Height, 1))
            'for setting burner height as par given value
            mdblBhHeight = gobjClsAAS203.funcReadBurnerHeight()
            ''for getting burner height
            funcSetBurner_HeightParameter = mdblBhHeight
            mobjclsBgSpectrum.SpectrumWait = False
            gblnSpectrumWait = False
            ''reset a spectrum.
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            gblnSpectrumWait = False
            mobjclsBgSpectrum.SpectrumWait = False
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            'gblnSpectrumWait = False
            '---------------------------------------------------------
        End Try
    End Function

    Private Sub subD2GainSatus()
        '=====================================================================
        ' Procedure Name        :   subD2GainSatus
        ' Description           :   
        ' Purpose               :   for checking a status of D2 gain
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
            ''put spectrum on wait
            If gstructSettings.D2Gain = True Then
                ''for D2 gain
                If gobjCommProtocol.funcIsD2GainOn = &H1 Then
                    If gobjCommProtocol.funcGain10X_OFF = True Then
                        ''put off 
                        cmdD2GainStatus.Text = "D2 &Gain On"
                    End If

                ElseIf gobjCommProtocol.funcIsD2GainOn = &H0 Then

                    If gobjCommProtocol.funcGain10X_ON = True Then
                        ''put on.
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

        '=====================================================================
        ' Procedure Name        : funcOnSpect
        ' Parameters Passed     : baseline status, lblScanStatus as label object, lblOnlineWv label object, 
        ' Returns               : bool
        ' Purpose               : for starting a time scan spectrum by starting a thread.
        ' Description           : Set Spectrum Parameter
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 21.11.06
        ' Revisions             : 
        '=====================================================================
        ''note:
        '''here BaseLine is a flag which is true if baseline is completed and false if not
        ''this is a main function which start the TimeScan Spectrum routin.

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


        ''for starting a spectrum
        'Dim ObjParameter As New Spectrum.EnergySpectrumParameter

        mobjOnlineChannel = New Spectrum.Channel(True)
        ''object for data structure
        'ObjParameter = funcCloneParameter(mobjParameters)
        ''this will make a copy of all parameter from mobjParameters to objParameter
        'mobjOnlineChannel.EnegryParameter = ObjParameter
        mobjOnlineChannel.EnegryParameter = mobjSpectrum.funcCloneESParameter(mobjParameters)
        ''now pass this object parameter to data structure
        'ObjParameter = Nothing

        If Not funcGraphPreRequisite(mobjParameters.Cal_Mode, _
                                    mobjParameters.XaxisMin, _
                                    mobjParameters.XaxisMax, _
                                    mobjParameters.YaxisMin, _
                                    mobjParameters.YaxisMax) Then
            ''this is set a graph as per given value
            'Call gFuncShowMessage("Error in setting spectrum parameters", "Please Check Entered Spectrum Parameters", modConstants.EnumMessageType.Information)
            Exit Function
        End If

        mobjOnlineReadings = New Spectrum.Readings

        'Readings is a class use as a datastructure


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
        mobjController = Nothing
        mobjController = New clsBgThread(Me)
        ''make a object for thread class
        mobjclsBgSpectrum = New clsBgSpectrum(lblTime, lblOnlineWv, _
                      mobjParameters.XaxisMax, _
                      mobjParameters.XaxisMin, _
                      mobjParameters.YaxisMax, _
                      mobjParameters.YaxisMin, _
                      mobjParameters.Cal_Mode, _
                      mobjParameters.ScanSpeed, _
                      dblAbsScanthldval, blnCheckMinAbsScanLmt)
        mobjController.Start(mobjclsBgSpectrum)
        ''for starting a spectrum thread

        funcOnSpect = True
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
        ' Parameters Passed     : ReturnValue, strWinTitle, dblMinValue, dblMaxValue
        ' Parameter affected    : ReturnValue,
        ' Returns               : True if success
        ' Purpose               : this is used to call a edit dilog as par user defined value.
        '                         
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : Apr 01, 2007 4:00 pm
        ' Revisions             : Deepak on 20.05.10
        '=====================================================================
        Dim InputValue As Double
        Dim intValue As Integer
        Try
            mobjfrmEditValues = New frmEditValues
            mobjfrmEditValues.LabelText = strWinTitle

            mobjfrmEditValues.txtValue.Visible = True
            Select Case strWinTitle
                Case "PMT", "D2 Current"
                    intValue = CInt(ReturnValue)
                    ReturnValue = intValue
                Case Else
            End Select

            mobjfrmEditValues.txtValue.Focus()
            mobjfrmEditValues.txtValue.SelectAll()
            mobjfrmEditValues.txtValue.Text = ReturnValue

            If mobjfrmEditValues.ShowDialog = DialogResult.Cancel Then
                Application.DoEvents()
                If Not mobjfrmEditValues Is Nothing Then
                    mobjfrmEditValues.Dispose()
                End If
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

            ReturnValue = InputValue
            Application.DoEvents()

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

    Private Sub ValueEditorUpDnEnable(ByVal blnEnable As Boolean)
        'nudBurnerHeight.IsUpDownEnable = blnEnable
        'nudD2Cur.IsUpDownEnable = blnEnable
        'nudHCLCur.IsUpDownEnable = blnEnable
        'nudFuelRatio.IsUpDownEnable = blnEnable
        'nudPMT.IsUpDownEnable = blnEnable
        'nudSlit.IsUpDownEnable = blnEnable

        nudBurnerHeight.Enabled = blnEnable
        nudD2Cur.Enabled = blnEnable
        nudHCLCur.Enabled = blnEnable
        nudFuelRatio.Enabled = blnEnable
        nudPMT.Enabled = blnEnable
        nudSlit.Enabled = blnEnable

    End Sub

#End Region

#Region " Code for Enable and Disable"

    Private Function func_Enable_Disable(ByVal intProcess As Integer, ByVal intStart_End As Integer)
        '=====================================================================
        ' Procedure Name        : func_Enable_Disable
        ' Parameters Passed     : current process , intStart_End 
        ' Returns               : None
        ' Purpose               : for enable/disable a onscreen control as par current process..
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 21.11.06
        ' Revisions             : 
        '=====================================================================

        ''parameter
        '' intprocess is a current stata of a form




        Try
            ''this function is called for the enable/disable the control on the screen as par the case 
            Select Case intProcess
                Case EnumProcesses.FormInitialize, EnumProcesses.EditSystemParamters
                    Select Case intStart_End

                        Case EnumStart_End.Start_of_Process
                            ''select a case as per current process
                            subAll_Menus_Enable()
                            ''for enable all the menu
                            btnAutoZero.Enabled = True
                            btnClearSpectrum.Enabled = True
                            btnReturn.Enabled = True
                            nudD2Cur.Enabled = True
                            nudPMT.Enabled = True
                            nudSlit.Enabled = True
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
                            ''select a case as per current process
                    End Select
                Case EnumProcesses.LoadParameters   '2
                    ''select a case as per current process
                    Select Case intStart_End
                        Case EnumStart_End.Start_of_Process

                        Case EnumStart_End.End_of_Process
                    End Select

                Case EnumProcesses.EditParameters    '3   
                    ''select a case as per current process
                    Select Case intStart_End
                        Case EnumStart_End.Start_of_Process

                        Case EnumStart_End.End_of_Process
                    End Select

                Case EnumProcesses.SaveParameters    '4   
                    ''select a case as per current process
                    Select Case intStart_End
                        Case EnumStart_End.Start_of_Process

                        Case EnumStart_End.End_of_Process
                    End Select

                Case EnumProcesses.StartScan            '15  EnumProcesses.StartScan
                    ''select a case as per current process
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
                            ''select a case as per current process
                            If gblnSpectrumTerminated = False Then
                                subAll_Menus_Enable()
                                btnClearSpectrum.Enabled = True
                                btnReturn.Enabled = True
                                nudD2Cur.Enabled = True
                                nudPMT.Enabled = True
                                nudSlit.Enabled = True
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
                    ''select a case as per current process
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
                    ''select a case as per current process
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

        '=====================================================================
        ' Procedure Name        : subAll_Menus_Enable
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : for enable all the menu..
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 21.11.06
        ' Revisions             : 
        '=====================================================================

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
        '=====================================================================
        ' Procedure Name        : subAll_Menus_Enable
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : for disable all the menu..
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 21.11.06
        ' Revisions             : 
        '=====================================================================
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
            'start a progress thread.

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

            'ProgressPanel.Text = Application.ProductName & Space(1) & Application.ProductVersion '22.3.2009 by dinesh wagh
            ProgressPanel.Text = gstrTitleInstrumentType & Space(1) & "S/W Ver. " & Mid(Application.ProductVersion, 1, 4) ' added by : dinesh wggh on 22.3.2009


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
        ' Procedure Name        : ShowRunTimeInfo
        ' Parameters Passed     : message
        ' Returns               : None
        ' Purpose               : to show message on status bar
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
        '=====================================================================
        ' Procedure Name        : TaskStarted
        ' Parameters Passed     : BgThread
        ' Returns               :  
        ' Purpose               :  this is called by thread
        ' Description           : for stating a thread.
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 12.10.06
        ' Revisions             : 
        '=====================================================================
        Try
            mblnAvoidProcessing = True
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
        '=====================================================================
        ' Procedure Name        : TaskStatus
        ' Parameters Passed     : Text
        ' Returns               :  
        ' Purpose               :  this is called by thread
        ' Description           :  for display a status.
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 12.10.06
        ' Revisions             : 
        '=====================================================================
        Try
            'If gstructApplicationSessionState.intInstrument_Group = EnumInstrumentGroup.Initialize_2600_2700 Then
            Call funcIclientTaskDisplayData(Text)
            ''for display a thread result.
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
            Application.DoEvents()
            ''--------------------------------------------------------
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
        '=====================================================================
        ' Procedure Name        : TaskFailed
        ' Parameters Passed     : e
        ' Returns               :  
        ' Purpose               :  this is called by thread
        ' Description           :  when thread is failed.
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 12.10.06
        ' Revisions             : 
        '=====================================================================
        Try
            '--- Dispose all the objects
            'mobjTemporaryChannel = New Channel
            'mobjTemporaryReadings = New Readings
            'mobjTemporaryReadings_2100 = New Readings
            funcIclientTaskFalied() ' task falied received from instrument

            mblnSpectrumStarted = False
            ''stop a spectrum
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
        '=====================================================================
        ' Procedure Name        : TaskCompleted
        ' Parameters Passed     : Cancelled
        ' Returns               :  
        ' Purpose               :  this is called by thread
        ' Description           :  when thread is completed.
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 12.10.06
        ' Revisions             : 
        '=====================================================================
        Try
            'If gstructApplicationSessionState.intInstrument_Group = EnumInstrumentGroup.Initialize_2600_2700 Then
            '    'Call funcIclientTaskCompleted2600()
            'ElseIf gstructApplicationSessionState.intInstrument_Group = EnumInstrumentGroup.Initialize_2100_2200_2300 Then
            '    'Call funcIclientTaskCompleted2100()
            'End If
            Call funcIclientTaskCompleted()
            'ask completed received from instrument
            mblnSpectrumStarted = False
            mblnAvoidProcessing = False
            Call mnuExit_Click(btnReturn, EventArgs.Empty)
            ''call mnuExit event.

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
            '---------------------------------------------------------

        End Try

    End Sub

#End Region

#Region " IClient Private Functions "

    Private Function funcIclientTaskCompleted() As Boolean
        '=====================================================================
        ' Procedure Name        :   funcIclientTaskCompleted
        ' Description           :   task completed received from instrument 
        '                           
        ' Purpose               :   
        ' Parameters Passed     :  None
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
                    ''for stoping a online graph
                    intCurveIndex += 1
                End If
            End If
            Application.DoEvents()
            ''allow application to perfrom its panding work.

            AASGraphTimeScan.AldysPane.AxisChange()
            AASGraphTimeScan.Refresh()

            If Not funcSpectrumReadingCompleted() Then
                ''check for spectrum reading 
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
        ' Parameters Passed     :  None
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
            'make the gblnSpectrumTerminated flag false
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
        '=====================================================================
        ' Procedure Name        : funcIclientTaskDisplayData
        ' Parameters Passed     : strData
        ' Returns               : bool
        ' Purpose               : for displying a data. this is called by thread.

        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 21.11.06
        ' Revisions             : 
        '=====================================================================
        Try

            'Data in the Text arg would be "Wavelength|Abs"

            Dim objData As New Spectrum.Data
            Dim arrData() As String
            Dim O As Integer   ' same as in function funcSmoothgraphonline
            Dim intCount As Integer

            '--- Split the data for Wv and Abs
            Application.DoEvents()
            arrData = Split(strData, "|")

            If arrData(0).Length > 0 And arrData(1).Length > 0 Then

                objData.XaxisData = Format(Val(arrData(0)), "#000.0")   ' wv

                objData.YaxisData = Format(Val(arrData(1)), "#0.000")

                If Not (mobjOnlineReadings Is Nothing) Then
                    mobjOnlineReadings.Add(objData)
                    funcDisplayGraph_RealTime(objData.XaxisData, objData.YaxisData)
                    ''for display a graph as per given value.
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
        '=====================================================================
        ' Procedure Name        : funcGraphPreRequisite
        ' Parameters Passed     :intScanmode,intXmax.intXmin,intYmax.intYmin,
        ' Returns               : bool
        ' Purpose               : for setting a graph as per passed parameter

        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 21.11.06
        ' Revisions             : 
        '=====================================================================
        ''note.
        ''here intScanmode means a calibration mode
        Dim dblDiffX As Double
        Dim dblMajorStepX, dblMinorStepX As Double
        Dim dblDiffY As Double
        Dim dblMajorStepY, dblMinorStepY As Double

        Try
            dblDiffX = Fix(intXmax - intXmin)
            ''get a X range
            dblMajorStepX = dblDiffX / 10
            ''get a major step
            dblMinorStepX = dblMajorStepX / 2
            ''get a minor step.
            dblDiffY = (intYmax - intYmin)
            ''get a Y range
            dblMajorStepY = dblDiffY / 10
            ''get a Y major
            dblMinorStepY = dblMajorStepY / 2
            ''get a Y minor
            AASGraphTimeScan.btnPeakEdit.Enabled = False
            AASGraphTimeScan.btnShowXYValues.Enabled = False

            AASGraphTimeScan.XAxisMin = intXmin
            AASGraphTimeScan.XAxisMax = intXmax
            AASGraphTimeScan.AldysPane.XAxis.Min = intXmin
            AASGraphTimeScan.AldysPane.XAxis.Max = intXmax

            '--- Display the axis lables
            AASGraphTimeScan.XAxisLabel = "TIME(seconds)"
            ''set a X-axis label.

            ''default X-axis label
            'AxEnergySpectrum.XAxisLabel = "  Energy"
            '''below we are setting a graph parameter on screen as par mode 
            Select Case gobjInst.Mode
                ''set a default parameter as per calibration mode 
            Case EnumCalibrationMode.AA, EnumCalibrationMode.AABGC, EnumCalibrationMode.MABS
                    ''set a default parameter as per calibration mode
                    AASGraphTimeScan.YAxisMin = intYmin
                    AASGraphTimeScan.YAxisMax = intYmax

                    AASGraphTimeScan.YAxisLabel = "ABSORBANCE"
                    mstrYaxisFormat = "0.000"
                    mstrYaxisExt = ""
                Case EnumCalibrationMode.HCLE, EnumCalibrationMode.D2E
                    ''set a default parameter as per calibration mode
                    AASGraphTimeScan.YAxisMin = intYmin
                    AASGraphTimeScan.YAxisMax = intYmax
                    AASGraphTimeScan.YAxisLabel = "ENERGY"
                    mstrYaxisFormat = "0.00#"
                    mstrYaxisExt = ""
                Case EnumCalibrationMode.EMISSION
                    ''set a default parameter as per calibration mode
                    AASGraphTimeScan.YAxisMin = intYmin
                    AASGraphTimeScan.YAxisMax = intYmax
                    AASGraphTimeScan.YAxisLabel = "EMISSION"
                    mstrYaxisFormat = "0.0"
                    mstrYaxisExt = "%"
                Case EnumCalibrationMode.SELFTEST
                    ''set a default parameter as per calibration mode
                    AASGraphTimeScan.YAxisMin = intYmin
                    AASGraphTimeScan.YAxisMax = intYmax
                    AASGraphTimeScan.YAxisLabel = "VOLT(mv)"
                    mstrYaxisExt = ""
                    mstrYaxisFormat = "0.0"
            End Select
            'AASGraphTimeScan.YAxisLabel = mYValueLable Commented by Saurabh 05.08.07 


            '//----- Set auto Steps of axis

            AASGraphTimeScan.AldysPane.XAxis.Step = dblMajorStepX
            AASGraphTimeScan.AldysPane.XAxis.MinorStep = dblMinorStepX
            AASGraphTimeScan.AldysPane.YAxis.Step = dblMajorStepY
            AASGraphTimeScan.AldysPane.YAxis.MinorStep = dblMinorStepY

            AASGraphTimeScan.XAxisStep = dblMajorStepX
            AASGraphTimeScan.YAxisStep = dblMajorStepY
            AASGraphTimeScan.XAxisMinorStep = dblMinorStepX
            AASGraphTimeScan.YAxisMinorStep = dblMinorStepY
            AASGraphTimeScan.AldysPane.Legend.IsVisible = True
            mnuGrid.Checked = True
            Me.AASGraphTimeScan.IsShowGrid = True
            Me.AASGraphTimeScan.btnPeakEdit.Checked = False
            '//-----
            AASGraphTimeScan.AldysPane.AxisChange()
            ''call axis change event
            AASGraphTimeScan.Refresh()
            Application.DoEvents()
            ''allow application to perfrom its panding work.
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


        ''here intScanmode means a calibration mode 
        Dim dblDiffX As Double
        Dim dblMajorStepX, dblMinorStepX As Double
        Dim dblDiffY As Double
        Dim dblMajorStepY, dblMinorStepY As Double

        Try

            dblDiffY = (intYmax - intYmin)
            ''get a Y range
            dblMajorStepY = dblDiffY / 10
            ''get major step
            dblMinorStepY = dblMajorStepY / 2
            ''get minor step
            '--- Display the axis lables
            'AxEnergySpectrum.XAxisLabel = "  Energy"
            AASGraphTimeScan.btnPeakEdit.Enabled = False
            AASGraphTimeScan.btnShowXYValues.Enabled = False

            Select Case gobjInst.Mode
                ''here we are setting graph parameter as par mode
            Case EnumCalibrationMode.AA, EnumCalibrationMode.AABGC, EnumCalibrationMode.MABS
                    AASGraphTimeScan.YAxisMin = intYmin
                    AASGraphTimeScan.YAxisMax = intYmax
                    AASGraphTimeScan.YAxisLabel = "ABSORBANCE"
                    mstrYaxisFormat = "0.00#"
                    mstrYaxisExt = ""
                Case EnumCalibrationMode.HCLE, EnumCalibrationMode.D2E
                    ''here we are setting graph parameter as par mode
                    AASGraphTimeScan.YAxisMin = intYmin
                    AASGraphTimeScan.YAxisMax = intYmax
                    AASGraphTimeScan.YAxisLabel = "ENERGY"
                    mstrYaxisFormat = "0.00#"
                    mstrYaxisExt = ""
                Case EnumCalibrationMode.EMISSION
                    ''here we are setting graph parameter as par mode
                    AASGraphTimeScan.YAxisMin = intYmin
                    AASGraphTimeScan.YAxisMax = intYmax
                    AASGraphTimeScan.YAxisLabel = "EMISSION"
                    mstrYaxisFormat = "0.#"
                    mstrYaxisExt = "%"
                Case EnumCalibrationMode.SELFTEST
                    ''here we are setting graph parameter as par mode
                    AASGraphTimeScan.YAxisMin = intYmin
                    AASGraphTimeScan.YAxisMax = intYmax
                    AASGraphTimeScan.YAxisLabel = "Volt(m)"
                    mstrYaxisFormat = "0.#"
                    mstrYaxisExt = ""
            End Select

            '//----- Set auto Steps of axis
            AASGraphTimeScan.AldysPane.YAxis.Step = dblMajorStepY
            AASGraphTimeScan.AldysPane.YAxis.MinorStep = dblMinorStepY
            AASGraphTimeScan.AldysPane.YAxis.IsMinorTic = True
            AASGraphTimeScan.AldysPane.YAxis.IsTic = True

            AASGraphTimeScan.YAxisStep = dblMajorStepY
            AASGraphTimeScan.YAxisMinorStep = dblMinorStepY
            '//-----
            Me.AASGraphTimeScan.btnPeakEdit.Checked = False
            AASGraphTimeScan.AldysPane.AxisChange()
            AASGraphTimeScan.Refresh()
            Application.DoEvents()
            ''allow application to perfrom its panding work
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

    Private Function funcDisplayGraph_RealTime(ByVal dblXAxis As Double, _
                                                ByVal dblYAxis As Double) As Boolean
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
        Dim dblToY As Double
        Dim tval As Long
        Dim dblDiffX As Double
        Dim dblMajorStepX, dblMinorStepX As Double
        Dim dblDiffY As Double
        Dim dblMajorStepY, dblMinorStepY As Double
        Dim lngIdx As Long
        Dim MaxXaxis As Long
        Dim MinXaxis As Long

        Try
            Application.DoEvents()
            '--- Plot the graph for the given coordinates.
            'lngX_Axis = CLng(dblXAxis)
            lngX_Axis = Fix(dblXAxis)
            dblToY = dblYAxis

            '--- Check if the X-coordinates and Y-coordinates are less than
            '--- Xmin and Ymin

            dblYAxis = dblToY

            '//------ to see the time lable only required to lable visiable property with "True"
            lblTime.Text = "Time (Sec.) : " & Format(dblXAxis, "#0.00#")

            'lblYValue.Text = mYValueLable & ": " & Format(dblYAxis, "#0.000")
            lblYValue.Text = mYValueLable & ": " & Format(dblYAxis, mstrYaxisFormat) & mstrYaxisExt
            gDblAbsValue_IQOQPQ_Attachment1 = dblYAxis
            lblTime.Refresh()
            lblYValue.Refresh()

            '            if (xtime1>=AbsGraph.Xmax){
            '			tval =(AbsGraph.Xmax-AbsGraph.Xmin);
            '			AbsGraph.Xmin = AbsGraph.Xmax;//(double)5.0;
            '			AbsGraph.Xmax +=tval;// (double)5.0;
            '			Calculate_Abs_Scan_Param(&AbsGraph);
            '			Afirst=TRUE;
            '			InvalidateRect(hwnd, NULL, TRUE); //AbsGraph.RC, TRUE);
            '			UpdateWindow(hwnd);
            '			CEnd1 = clock();
            '//			CStart += (CEnd1-CEnd);
            '		  }
            '		 if (Afirst){
            '			PlotInit(hdc, xtime1, abs, AbsGraph.RC, &AbsGraph);
            '			Afirst=FALSE;
            '		  }
            '                Else
            '			Plotg(hdc, xtime1, abs, AbsGraph.RC, &AbsGraph);
            '		}

            '--- Check if the wavelength is equal to the max wv


            If (lngX_Axis >= Fix(AASGraphTimeScan.XAxisMax)) Then

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
                        If tval = 0 Then 'by Pankaj on 16.1.08
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
                'mGraphCurveItem = AASGraphTimeScan.StartOnlineGraph("Spectrum " & (intCurveIndex + 1).ToString, AASGraphTimeScan.GetColor(intCurveIndex), AldysGraph.SymbolType.NoSymbol)
                'ArrlstGraphCurveItem.Add(mGraphCurveItem)
                'AASGraphTimeScan.PlotPoint(ArrlstGraphCurveItem.Item(intCurveIndex), dblXAxis, dblYAxis)
                AASGraphTimeScan.AldysPane.AxisChange()
                AASGraphTimeScan.Refresh()
                Application.DoEvents()
                blnPlotingNew = False
            End If
            Application.DoEvents()

            If blnPlotingNew = True Then
                mGraphCurveItem = Nothing
                'start online graph
                mGraphCurveItem = AASGraphTimeScan.StartOnlineGraph("Time scan", AASGraphTimeScan.GetColor(intCurveIndex), AldysGraph.SymbolType.NoSymbol) '---20.03.09
                ArrlstGraphCurveItem.Add(mGraphCurveItem)
                If Not (ArrlstGraphCurveItem.Item(intCurveIndex) Is Nothing) Then
                    AASGraphTimeScan.PlotPoint(ArrlstGraphCurveItem.Item(intCurveIndex), dblXAxis, dblYAxis)
                    AASGraphTimeScan.Refresh()
                End If
                blnPlotingNew = False
            Else
                If Not (ArrlstGraphCurveItem.Item(intCurveIndex) Is Nothing) Then
                    AASGraphTimeScan.PlotPoint(ArrlstGraphCurveItem.Item(intCurveIndex), dblXAxis, dblYAxis)
                    AASGraphTimeScan.AldysPane.AxisChange()
                    AASGraphTimeScan.Refresh()
                End If
                Application.DoEvents()
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

    End Function

    Friend Function funcDisplayGraph(ByVal objChannel As Spectrum.Channel) As Boolean
        '=====================================================================
        ' Procedure Name        :   funcDisplayGraph
        ' Description           :   to plot the graph as offline 
        ' Purpose               :   
        ' Parameters Passed     :   objChannel, is a obj of data structure
        ' Returns               :   True, if successful.
        ' Parameters Affected   :   
        ' Assumptions           :   
        ' Dependencies          :   None.
        ' Author                :   Sachin Dokhale 
        ' Created               :   12.12.06
        ' Revisions             :
        '=====================================================================
        ''note:
        ''this function draw a offline graph 
        ''it gets a value from data structure and display a graph 
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
                    ''for plotting a graph
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
        '=====================================================================
        ' Procedure Name        : funcClearGraph
        ' Parameters Passed     :  
        ' Returns               : True or False
        ' Purpose               : for clearing a graph
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 12.10.06
        ' Revisions             : 
        '=====================================================================
        Dim lngDataCount As Long
        'Dim objReadingCol As New Spectrum.Readings
        Dim dblFromX As Double
        Dim dblFromY As Double
        Dim dblToX As Double
        Dim dblToY As Double
        ''as the name 
        '' this clear all the point on the graph

        Try

            mintChannelIndex = 0
            'mobjChannnels.Clear()
            ArrlstGraphCurveItem.Clear()
            ''clear the array
            AASGraphTimeScan.AldysPane.CurveList.Clear()
            AASGraphTimeScan.Refresh()
            Application.DoEvents()
            ''allow application to perfrom panding work
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
        ' Purpose               :   for grid showing
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
            mobjclsBgSpectrum.SpectrumWait = False
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

    Private Sub mnuPeakEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        :   mnuPeakEdit_Click
        ' Description           :   to check the graph for Peak Edit.
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
            mnuPeakEdit.Checked = Not (mnuPeakEdit.Checked)
            'Me.AASGraphUVSpectrum.IsShowGrid = mnuPeakEdit.Checked
            Me.AASGraphTimeScan.submnuPeakEdit_Click(sender, e)
            'call peakEdit_Click procedure for showing peak edit control
            mobjclsBgSpectrum.SpectrumWait = False

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            mobjclsBgSpectrum.SpectrumWait = False
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

    Private Sub mnuLegends_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        :   mnuLegends_Click
        ' Description           :   to check the graph for Legends.
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
            mnuLegends.Checked = Not (mnuLegends.Checked)
            Me.AASGraphTimeScan.AldysPane.Legend.IsVisible = mnuLegends.Checked
            AASGraphTimeScan.Invalidate()
            'invalidates specified region of the control
            AASGraphTimeScan.Refresh()
            'Me.AASGraphUVSpectrum.submnuPeakEdit_Click(AASGraphUVSpectrum, System.EventArgs.Empty)
            mobjclsBgSpectrum.SpectrumWait = False


        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            mobjclsBgSpectrum.SpectrumWait = False
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

    'Private Sub mnuPrintPreview_Click(ByVal sender As Object, ByVal e As System.EventArgs)
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
    '        Me.AASGraphUVSpectrum.PrintPreViewGraph()
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

    'Private Sub mnuScale_Click(ByVal sender As Object, ByVal e As System.EventArgs)
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
    '        'Me.AASGraphUVSpectrum.submnuScale_Click(sender, e)
    '        Call cmdChangeScale_Click(sender, e)
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
            RemoveHandler mnuLegends.Click, AddressOf mnuLegends_Click
            If AASGraphTimeScan.AldysPane.Legend.IsVisible = True Then
                mnuLegends.Checked = True
            Else
                mnuLegends.Checked = False
            End If
            AddHandler mnuLegends.Click, AddressOf mnuLegends_Click

            '//----- Check Show XY Values on Graph
            RemoveHandler mnuShowXYValues.Click, AddressOf mnuShowXYValues_Click
            If AASGraphTimeScan.ShowXYValues = True Then
                mnuShowXYValues.Checked = True
            Else
                mnuShowXYValues.Checked = False
            End If
            AddHandler mnuShowXYValues.Click, AddressOf mnuShowXYValues_Click

            RemoveHandler mnuPeakEdit.Click, AddressOf mnuPeakEdit_Click
            If AASGraphTimeScan.ShowXYPeak = True Then
                mnuPeakEdit.Checked = True
            Else
                mnuPeakEdit.Checked = False
            End If
            AddHandler mnuPeakEdit.Click, AddressOf mnuPeakEdit_Click

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

    Private Sub btnIgnite_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : btnIgnite_Click
        ' Parameters Passed     :
        ' Returns               : bool
        ' Purpose               : to handle ignite click event.

        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 21.11.06
        ' Revisions             : 
        '=====================================================================

        Try
            If mblnAvoidFormProcessing = True Then
                Exit Sub
            End If
            mblnAvoidFormProcessing = True
            mobjclsBgSpectrum.SpectrumWait = True

            Call gobjCommProtocol.mobjCommdll.subTime_Delay(300)  '---17.11.09
            Call gobjClsAAS203.funcIgnite(True)
            Call funcGetInstParameter()

            Call gobjCommProtocol.mobjCommdll.subTime_Delay(200)  '---17.11.09

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
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub btnN2OIgnite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : btnN2OIgnite_Click
        ' Parameters Passed     :
        ' Returns               : bool
        ' Purpose               : to handle btnN2OIgnite_Click event.

        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 21.11.06
        ' Revisions             : 
        '=====================================================================
        Try
            If mblnAvoidFormProcessing = True Then
                Exit Sub
            End If
            mblnAvoidFormProcessing = True
            mobjclsBgSpectrum.SpectrumWait = True

            Call gobjCommProtocol.mobjCommdll.subTime_Delay(100)
            Call gobjCommProtocol.funcSwitchOver()
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
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub btnExtinguish_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : btnExtinguish_Click
        ' Parameters Passed     :
        ' Returns               : bool
        ' Purpose               : to handle btnExtinguish_Click event.

        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 21.11.06
        ' Revisions             : 
        '=====================================================================
        Try
            If mblnAvoidFormProcessing = True Then
                Exit Sub
            End If
            mblnAvoidFormProcessing = True
            mobjclsBgSpectrum.SpectrumWait = True

            Call gobjCommProtocol.mobjCommdll.subTime_Delay(100)
            Call gobjClsAAS203.funcIgnite(False)
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
            If mblnAvoidProcessing = True Then
                Exit Sub
            End If
            mblnAvoidProcessing = True
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
            mblnAvoidProcessing = False
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            mblnAvoidProcessing = False
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

#End Region

#Region "Other functions"
    'case	IDC_ADJFLOW: Optimise_Fuel_Auto(hwnd);
    '						 Scroll_Fuel(hwnd,IDC_FUEL, -1);break;
    'case	IDC_ADJBH:	Optimise_Height_Auto(hwnd);
    '						Scroll_Bh(hwnd,IDC_BH, -1);
    '						Save_BH_Pos();
    'break;




    '//---- ComProtocol

    '//-----

    '//---- clsAAS

    Private Sub DisableButtonsForBurnerHeight()
        '=====================================================================
        ' Procedure Name        : DisableButtonsForBurnerHeight
        ' Parameters Passed     :
        ' Returns               : bool
        ' Purpose               : on screen validation for burner height.

        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 21.11.06
        ' Revisions             : 
        '=====================================================================
        ''note:
        ''this is called when user going to adjust burner height
        ''this is realted to disble a control

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
        'nudSlit_Exit.Enabled = False
        'cmbSpeed.Enabled = False
        cmbModes.Enabled = False
        nudBurnerHeight.Enabled = False
        nudFuelRatio.Enabled = False
        nudHCLCur.Enabled = False
        'nudPMT_Ref.Enabled = False  'For Double Beam
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
        '=====================================================================
        ' Procedure Name        : EnableButtonsForBurnerHeight
        ' Parameters Passed     :
        ' Returns               : bool
        ' Purpose               : on screen validation for burner height.

        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 21.11.06
        ' Revisions             : 
        '=====================================================================
        ''note.
        ''this is called when user going to adjust burner height
        ''this is realted to enable a control

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
        'nudSlit_Exit.Enabled = True
        'cmbSpeed.Enabled = False
        cmbModes.Enabled = True
        nudBurnerHeight.Enabled = True
        nudFuelRatio.Enabled = True
        nudHCLCur.Enabled = True
        'nudPMT_Ref.Enabled = True  'For Double Bea
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

    'Private Sub frmTimeScanMode_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    '    '=====================================================================
    '    ' Procedure Name        : frmTimeScanMode_Activated
    '    ' Parameters Passed     :
    '    ' Returns               : bool
    '    ' Purpose               : this will activated a time scan mode.

    '    ' Description           : 
    '    ' Assumptions           : 
    '    ' Dependencies          : 
    '    ' Author                : Sachin Dokhale
    '    ' Created               : 21.11.06
    '    ' Revisions             : 
    '    '=====================================================================
    '    Try
    '        'If blnActivateStartTimeScan = False Then
    '        '    Call funcSetDefaultParameter()
    '        '    ''for setting default parameter
    '        '    nudD2Cur.Visible = True
    '        '    nudPMT.Visible = True
    '        '    nudSlit.Visible = True
    '        '    nudHCLCur.Visible = True
    '        '    nudBurnerHeight.Visible = True
    '        '    nudFuelRatio.Visible = True
    '        '    blnActivateStartTimeScan = True
    '        'End If


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

#End Region

End Class
