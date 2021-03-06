Imports System.Threading
Imports AAS203.Common
Imports BgThread
Imports System.IO
Imports Microsoft.VisualBasic
Imports AAS203.Spectrum

''these are  supporting files 
Public Class frmUVScanningSpectrumMode ''calss behind the UV spectrum form

    Inherits System.Windows.Forms.Form
    Implements Iclient

#Region " Private Variable "
    '--- Declaration for the controller object of the BgThread
    Private mobjController As New BgThread.clsBgThread(Me)
    Private mobjclsBgSpectrum As clsBgSpectrum

    'Public WithEvents Status As System.Windows.Forms.TextBox

    Private mblnSpectrumStarted As Boolean
    Private mblnAvoidProcessing As Boolean = False
    Private mdblYaxis As Double
    Private mdblXaxis As Double
    Private mGraphCurveItem As AldysGraph.CurveItem
    Private ArrlstGraphCurveItem As New ArrayList
    Private intCurveIndex As Integer = -1
    Private m_blnBaseline As Boolean = True
    Private mAvoidProcessBtn As Boolean
    Private Structure _Data
        Dim mGraphPlot As Boolean
        Dim mXaxisData As Integer
        Dim mYaxisData As Integer
    End Structure
    'Dim Data As _Data
    '--- declaration of the channels object (collection)
    Private mobjChannnels As New Spectrum.Channels
    Private mobjOnlineChannel As New Spectrum.Channel(False)
    Private mobjOnlineReadings As New Spectrum.Readings
    Private mobjSpectrum As New clsSpectrum

    '--- declaration of the Parameter object used to populate the 
    '--- parameter screen on the spectrum screen
    Private mobjParameters As New Spectrum.UVSpectrumParameter
    '--- Current channel index
    Private mintChannelIndex As Integer = -1
    '----- Store the Peak and Valley
    Private mStuctPeaksValley(100) As clsSpectrum.PeakValley

    Private strPath As IO.Directory
    Private blnYetFileNotSave As Boolean = False


    Private mYValueLable As String = const_Absorbance
    Private mXValueLable As String = "Wavelength (nm): "
    Private strfrmStatusTurretNo As String
    Private strfrmStatusEle As String

    Private WithEvents mobjfrmEditValues As frmEditValues
    Private mblnIsTransmission As Boolean
    Private statStartGraph As Boolean = False

    Private blnActivateStartUVSpectrum As Boolean = False   'Saurabh 11.08.07

    Private m_bytCalibMode As Integer
#End Region

#Region " Constant"
    Private Const ConstFormLoad = "-UV Scanning Spectrum Mode"
    'Private Const const_WvMin = 0
    'Private Const const_WvMax = 100.0
    Private Const const_WvMin = 190.0
    Private Const const_WvMax = 280.0
    Private Const const_YMinAbs = -0.4
    Private Const const_YMaxAbs = 1.0
    Private Const const_YMinTrans = -100.0
    Private Const const_YMaxTrans = 100.0
    Private Const const_YMaxEnergy = 100
    Private Const const_YMinEnergy = 0.0
    Private Const const_YMaxTransmision = 100
    Private Const const_YMinTransmision = 0.0
    Private Const const_YMinEmission = 0.0
    Private Const const_YMaxEmission = 100.0
    Private Const const_YMinmVolt = -5000.0
    Private Const const_YMaxmVolt = 5000.0
    'Private Const const_YMinmVolt = 0.0
    'Private Const const_YMaxmVolt = 4000.0

    Private Const const_Absorbance = "Absorbance: "
    Private Const const_Transmission = "Tranmission: "
    Private Const const_Energy = "Energy: "
    Private Const const_Emission = "Emission: "
    Private Const const_Volt = "Volt(mv): "
    Private Const const_GraphLedgend = "Sample Graph"

#End Region

#Region " Message Constant"
    Private Const constBurerCuvette = 103
    Private Const constStartRef = 104
    Private Const constStartScan = 105
    Private Const constCuvetteBurner = 106
#End Region

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

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
    Friend WithEvents mnuFile As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuParameters As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuSaveSpectrumFile As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuDataProcessing As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuSmooth As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuPeakPick As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuAbsTransmission As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuExit As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents CommandBarSeparatorItem1 As NETXP.Controls.Bars.CommandBarSeparatorItem
    Friend WithEvents CustomPanelMain As GradientPanel.CustomPanel
    Friend WithEvents MenuBarUV As NETXP.Controls.Bars.CommandBar
    Friend WithEvents StatusBar1 As NETXP.Controls.Bars.StatusBar
    Friend WithEvents StatusBarPanelInfo As System.Windows.Forms.StatusBarPanel
    Friend WithEvents ProgressPanel As NETXP.Controls.Bars.ProgressPanel
    Friend WithEvents StatusBarPanelDate As System.Windows.Forms.StatusBarPanel
    Friend WithEvents mnuLoadSpectrumFile As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents AASGraphUVSpectrum As AAS203.AASGraph
    Friend WithEvents CustomPanelBottom As GradientPanel.CustomPanel
    Friend WithEvents btnStart As NETXP.Controls.XPButton
    Friend WithEvents btnBaseLine As NETXP.Controls.XPButton
    Friend WithEvents btnClearSpectrum As NETXP.Controls.XPButton
    Friend WithEvents btnReturn As NETXP.Controls.XPButton
    Friend WithEvents CustomPanelTop As GradientPanel.CustomPanel
    Friend WithEvents lblYValue As System.Windows.Forms.Label
    Friend WithEvents lblWvPos As System.Windows.Forms.Label
    Friend WithEvents cmdChangeScale As NETXP.Controls.XPButton
    Friend WithEvents lblPMTVolts As System.Windows.Forms.Label
    Friend WithEvents lblD2CurmA As System.Windows.Forms.Label
    Friend WithEvents cmbModes As System.Windows.Forms.ComboBox
    Friend WithEvents lblModes As System.Windows.Forms.Label
    Friend WithEvents lblSpeed As System.Windows.Forms.Label
    Friend WithEvents cmbSpeed As System.Windows.Forms.ComboBox
    Friend WithEvents lblSlitWidth As System.Windows.Forms.Label
    Friend WithEvents lblD2Cur As System.Windows.Forms.Label
    Friend WithEvents lblPMT As System.Windows.Forms.Label
    Friend WithEvents Office2003Header1 As CodeIntellects.Office2003Controls.Office2003Header
    Friend WithEvents Office2003Header2 As CodeIntellects.Office2003Controls.Office2003Header
    Friend WithEvents CustomPanelBack As GradientPanel.CustomPanel
    Friend WithEvents ToolBar1 As NETXP.Controls.Bars.CommandBar
    Friend WithEvents ToolBar As NETXP.Controls.Bars.CommandBar
    Friend WithEvents tlbbtnReturn As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents CommandBarSeparatorItem3 As NETXP.Controls.Bars.CommandBarSeparatorItem
    Friend WithEvents tlbbtnParameters As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents tlbbtnLoadspectrumFile As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents tlbbtnSaveSpectrumFile As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents CommandBarSeparatorItem4 As NETXP.Controls.Bars.CommandBarSeparatorItem
    Friend WithEvents tlbbtnStart As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents tlbbtnClearSpectrum As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents tlbbtnChangeScale As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents CommandBarSeparatorItem5 As NETXP.Controls.Bars.CommandBarSeparatorItem
    Friend WithEvents tlbbtnSmooth As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents tlbbtnPeakPick As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents tlbbtnBaseLine As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents tlbbtnAbsToTransmission As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents CommandBarButtonItem1 As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents nudPMT As ValueEditor.ValueEditor
    Friend WithEvents nudD2Cur As ValueEditor.ValueEditor
    Friend WithEvents nudSlit As ValueEditor.ValueEditor
    Friend WithEvents lblSlitnm As System.Windows.Forms.Label
    Friend WithEvents mnuGraphOptions As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuPeakEdit As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuGrid As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuLegends As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuShowXYValues As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuStart As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuBaseLine As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuClearSpectrum As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents tlbbtnPrintGraph As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents CommandBarSeparatorItem2 As NETXP.Controls.Bars.CommandBarSeparatorItem
    Friend WithEvents mnuPrintGraph As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents btnExtinguish As NETXP.Controls.XPButton
    Friend WithEvents btnIgnite As NETXP.Controls.XPButton
    Friend WithEvents tlbbtnPeakEdit As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents CommandBarSeparatorItem6 As NETXP.Controls.Bars.CommandBarSeparatorItem
    Friend WithEvents tlbbtnGrid As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents tlbbtnShowXYValues As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents tlbbtnLegends As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuChangeScale As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents btnR As NETXP.Controls.XPButton
    Friend WithEvents btnDelete As NETXP.Controls.XPButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmUVScanningSpectrumMode))
        Me.CustomPanelMain = New GradientPanel.CustomPanel
        Me.AASGraphUVSpectrum = New AAS203.AASGraph
        Me.Office2003Header2 = New CodeIntellects.Office2003Controls.Office2003Header
        Me.CustomPanelBottom = New GradientPanel.CustomPanel
        Me.btnStart = New NETXP.Controls.XPButton
        Me.btnBaseLine = New NETXP.Controls.XPButton
        Me.btnClearSpectrum = New NETXP.Controls.XPButton
        Me.btnReturn = New NETXP.Controls.XPButton
        Me.cmdChangeScale = New NETXP.Controls.XPButton
        Me.btnExtinguish = New NETXP.Controls.XPButton
        Me.btnIgnite = New NETXP.Controls.XPButton
        Me.btnR = New NETXP.Controls.XPButton
        Me.btnDelete = New NETXP.Controls.XPButton
        Me.MenuBarUV = New NETXP.Controls.Bars.CommandBar
        Me.mnuFile = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuParameters = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuLoadSpectrumFile = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuSaveSpectrumFile = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.CommandBarSeparatorItem1 = New NETXP.Controls.Bars.CommandBarSeparatorItem
        Me.mnuExit = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuDataProcessing = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuBaseLine = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuStart = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuSmooth = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuPeakPick = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuAbsTransmission = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuClearSpectrum = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuPrintGraph = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuGraphOptions = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuPeakEdit = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuGrid = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuLegends = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuShowXYValues = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuChangeScale = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.StatusBar1 = New NETXP.Controls.Bars.StatusBar
        Me.StatusBarPanelInfo = New System.Windows.Forms.StatusBarPanel
        Me.ProgressPanel = New NETXP.Controls.Bars.ProgressPanel
        Me.StatusBarPanelDate = New System.Windows.Forms.StatusBarPanel
        Me.CustomPanelTop = New GradientPanel.CustomPanel
        Me.lblSlitnm = New System.Windows.Forms.Label
        Me.nudSlit = New ValueEditor.ValueEditor
        Me.nudD2Cur = New ValueEditor.ValueEditor
        Me.nudPMT = New ValueEditor.ValueEditor
        Me.Office2003Header1 = New CodeIntellects.Office2003Controls.Office2003Header
        Me.lblYValue = New System.Windows.Forms.Label
        Me.lblWvPos = New System.Windows.Forms.Label
        Me.lblPMTVolts = New System.Windows.Forms.Label
        Me.lblD2CurmA = New System.Windows.Forms.Label
        Me.cmbModes = New System.Windows.Forms.ComboBox
        Me.lblModes = New System.Windows.Forms.Label
        Me.lblSpeed = New System.Windows.Forms.Label
        Me.cmbSpeed = New System.Windows.Forms.ComboBox
        Me.lblSlitWidth = New System.Windows.Forms.Label
        Me.lblD2Cur = New System.Windows.Forms.Label
        Me.lblPMT = New System.Windows.Forms.Label
        Me.CustomPanelBack = New GradientPanel.CustomPanel
        Me.ToolBar1 = New NETXP.Controls.Bars.CommandBar
        Me.ToolBar = New NETXP.Controls.Bars.CommandBar
        Me.tlbbtnReturn = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.CommandBarSeparatorItem3 = New NETXP.Controls.Bars.CommandBarSeparatorItem
        Me.tlbbtnParameters = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.tlbbtnLoadspectrumFile = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.tlbbtnSaveSpectrumFile = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.CommandBarSeparatorItem4 = New NETXP.Controls.Bars.CommandBarSeparatorItem
        Me.tlbbtnStart = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.tlbbtnBaseLine = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.tlbbtnClearSpectrum = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.tlbbtnChangeScale = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.CommandBarSeparatorItem5 = New NETXP.Controls.Bars.CommandBarSeparatorItem
        Me.tlbbtnSmooth = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.tlbbtnPeakPick = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.tlbbtnPrintGraph = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.CommandBarSeparatorItem2 = New NETXP.Controls.Bars.CommandBarSeparatorItem
        Me.tlbbtnPeakEdit = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.tlbbtnGrid = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.tlbbtnLegends = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.tlbbtnShowXYValues = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.CommandBarSeparatorItem6 = New NETXP.Controls.Bars.CommandBarSeparatorItem
        Me.tlbbtnAbsToTransmission = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.CommandBarButtonItem1 = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.CustomPanelMain.SuspendLayout()
        Me.CustomPanelBottom.SuspendLayout()
        CType(Me.MenuBarUV, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StatusBarPanelInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProgressPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StatusBarPanelDate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CustomPanelTop.SuspendLayout()
        Me.CustomPanelBack.SuspendLayout()
        CType(Me.ToolBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolBar1.SuspendLayout()
        CType(Me.ToolBar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CustomPanelMain
        '
        Me.CustomPanelMain.BackColor = System.Drawing.Color.AliceBlue
        Me.CustomPanelMain.Controls.Add(Me.AASGraphUVSpectrum)
        Me.CustomPanelMain.Controls.Add(Me.Office2003Header2)
        Me.CustomPanelMain.Controls.Add(Me.CustomPanelBottom)
        Me.CustomPanelMain.Controls.Add(Me.btnExtinguish)
        Me.CustomPanelMain.Controls.Add(Me.btnIgnite)
        Me.CustomPanelMain.Controls.Add(Me.btnR)
        Me.CustomPanelMain.Controls.Add(Me.btnDelete)
        Me.CustomPanelMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CustomPanelMain.Location = New System.Drawing.Point(198, 0)
        Me.CustomPanelMain.Name = "CustomPanelMain"
        Me.CustomPanelMain.Size = New System.Drawing.Size(608, 437)
        Me.CustomPanelMain.TabIndex = 0
        '
        'AASGraphUVSpectrum
        '
        Me.AASGraphUVSpectrum.AldysGraphCursor = Nothing
        Me.AASGraphUVSpectrum.AldysGraphPrintColor = System.Drawing.Color.Black
        Me.AASGraphUVSpectrum.BackColor = System.Drawing.Color.White
        Me.AASGraphUVSpectrum.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AASGraphUVSpectrum.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AASGraphUVSpectrum.GraphDataSource = Nothing
        Me.AASGraphUVSpectrum.GraphImage = Nothing
        Me.AASGraphUVSpectrum.IsShowGrid = True
        Me.AASGraphUVSpectrum.Location = New System.Drawing.Point(0, 22)
        Me.AASGraphUVSpectrum.Name = "AASGraphUVSpectrum"
        Me.AASGraphUVSpectrum.Size = New System.Drawing.Size(608, 334)
        Me.AASGraphUVSpectrum.TabIndex = 26
        Me.AASGraphUVSpectrum.UseDefaultSettings = True
        Me.AASGraphUVSpectrum.XAxisDateMax = New Date(CType(0, Long))
        Me.AASGraphUVSpectrum.XAxisDateMin = New Date(CType(0, Long))
        Me.AASGraphUVSpectrum.XAxisDateScaleFormat = AAS203.AASGraph.enumDateScaleFormat.YYYY
        Me.AASGraphUVSpectrum.XAxisLabel = "X Values"
        Me.AASGraphUVSpectrum.XAxisMax = 100
        Me.AASGraphUVSpectrum.XAxisMin = 0
        Me.AASGraphUVSpectrum.XAxisMinorStep = 5
        Me.AASGraphUVSpectrum.XAxisScaleFormat = Nothing
        Me.AASGraphUVSpectrum.XAxisStep = 10
        Me.AASGraphUVSpectrum.XAxisType = AldysGraph.AxisType.Linear
        Me.AASGraphUVSpectrum.YAxisLabel = "Y Values"
        Me.AASGraphUVSpectrum.YAxisMax = 100
        Me.AASGraphUVSpectrum.YAxisMin = -1
        Me.AASGraphUVSpectrum.YAxisMinorStep = 5
        Me.AASGraphUVSpectrum.YAxisScaleFormat = Nothing
        Me.AASGraphUVSpectrum.YAxisStep = 10
        Me.AASGraphUVSpectrum.YAxisType = AldysGraph.AxisType.Linear
        '
        'Office2003Header2
        '
        Me.Office2003Header2.BackColor = System.Drawing.SystemColors.Control
        Me.Office2003Header2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Office2003Header2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Office2003Header2.Location = New System.Drawing.Point(0, 0)
        Me.Office2003Header2.Name = "Office2003Header2"
        Me.Office2003Header2.Size = New System.Drawing.Size(608, 22)
        Me.Office2003Header2.TabIndex = 27
        Me.Office2003Header2.TitleFont = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Office2003Header2.TitleText = "UV Spectrum"
        '
        'CustomPanelBottom
        '
        Me.CustomPanelBottom.BackColor = System.Drawing.Color.AliceBlue
        Me.CustomPanelBottom.Controls.Add(Me.btnStart)
        Me.CustomPanelBottom.Controls.Add(Me.btnBaseLine)
        Me.CustomPanelBottom.Controls.Add(Me.btnClearSpectrum)
        Me.CustomPanelBottom.Controls.Add(Me.btnReturn)
        Me.CustomPanelBottom.Controls.Add(Me.cmdChangeScale)
        Me.CustomPanelBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.CustomPanelBottom.Location = New System.Drawing.Point(0, 356)
        Me.CustomPanelBottom.Name = "CustomPanelBottom"
        Me.CustomPanelBottom.Size = New System.Drawing.Size(608, 81)
        Me.CustomPanelBottom.TabIndex = 25
        '
        'btnStart
        '
        Me.btnStart.Enabled = False
        Me.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnStart.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStart.Image = CType(resources.GetObject("btnStart.Image"), System.Drawing.Image)
        Me.btnStart.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnStart.Location = New System.Drawing.Point(134, 25)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(106, 38)
        Me.btnStart.TabIndex = 1
        Me.btnStart.Text = "&Start"
        '
        'btnBaseLine
        '
        Me.btnBaseLine.Enabled = False
        Me.btnBaseLine.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBaseLine.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBaseLine.Image = CType(resources.GetObject("btnBaseLine.Image"), System.Drawing.Image)
        Me.btnBaseLine.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBaseLine.Location = New System.Drawing.Point(252, 25)
        Me.btnBaseLine.Name = "btnBaseLine"
        Me.btnBaseLine.Size = New System.Drawing.Size(106, 38)
        Me.btnBaseLine.TabIndex = 2
        Me.btnBaseLine.Text = "&Base Line"
        '
        'btnClearSpectrum
        '
        Me.btnClearSpectrum.Enabled = False
        Me.btnClearSpectrum.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClearSpectrum.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClearSpectrum.Image = CType(resources.GetObject("btnClearSpectrum.Image"), System.Drawing.Image)
        Me.btnClearSpectrum.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClearSpectrum.Location = New System.Drawing.Point(370, 25)
        Me.btnClearSpectrum.Name = "btnClearSpectrum"
        Me.btnClearSpectrum.Size = New System.Drawing.Size(106, 38)
        Me.btnClearSpectrum.TabIndex = 3
        Me.btnClearSpectrum.Text = "C&lear Spectrum"
        Me.btnClearSpectrum.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'btnReturn
        '
        Me.btnReturn.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnReturn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnReturn.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReturn.Image = CType(resources.GetObject("btnReturn.Image"), System.Drawing.Image)
        Me.btnReturn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReturn.Location = New System.Drawing.Point(488, 25)
        Me.btnReturn.Name = "btnReturn"
        Me.btnReturn.Size = New System.Drawing.Size(106, 38)
        Me.btnReturn.TabIndex = 4
        Me.btnReturn.Text = "Return"
        '
        'cmdChangeScale
        '
        Me.cmdChangeScale.Enabled = False
        Me.cmdChangeScale.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdChangeScale.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdChangeScale.Image = CType(resources.GetObject("cmdChangeScale.Image"), System.Drawing.Image)
        Me.cmdChangeScale.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdChangeScale.Location = New System.Drawing.Point(16, 25)
        Me.cmdChangeScale.Name = "cmdChangeScale"
        Me.cmdChangeScale.Size = New System.Drawing.Size(106, 38)
        Me.cmdChangeScale.TabIndex = 0
        Me.cmdChangeScale.Text = "&Change Scale"
        Me.cmdChangeScale.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'btnExtinguish
        '
        Me.btnExtinguish.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExtinguish.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExtinguish.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExtinguish.Location = New System.Drawing.Point(144, 218)
        Me.btnExtinguish.Name = "btnExtinguish"
        Me.btnExtinguish.Size = New System.Drawing.Size(34, 18)
        Me.btnExtinguish.TabIndex = 15
        Me.btnExtinguish.TabStop = False
        Me.btnExtinguish.Text = "&Extinguish"
        Me.btnExtinguish.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'btnIgnite
        '
        Me.btnIgnite.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnIgnite.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIgnite.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnIgnite.Location = New System.Drawing.Point(198, 192)
        Me.btnIgnite.Name = "btnIgnite"
        Me.btnIgnite.Size = New System.Drawing.Size(40, 17)
        Me.btnIgnite.TabIndex = 14
        Me.btnIgnite.TabStop = False
        Me.btnIgnite.Text = "&Ignition"
        Me.btnIgnite.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'btnR
        '
        Me.btnR.BackColor = System.Drawing.Color.Transparent
        Me.btnR.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnR.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnR.Location = New System.Drawing.Point(306, 215)
        Me.btnR.Name = "btnR"
        Me.btnR.Size = New System.Drawing.Size(8, 8)
        Me.btnR.TabIndex = 51
        Me.btnR.TabStop = False
        Me.btnR.Text = "&R"
        Me.btnR.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'btnDelete
        '
        Me.btnDelete.BackColor = System.Drawing.Color.Transparent
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelete.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDelete.Location = New System.Drawing.Point(294, 215)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(8, 8)
        Me.btnDelete.TabIndex = 52
        Me.btnDelete.TabStop = False
        Me.btnDelete.Text = "&Delete"
        Me.btnDelete.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'MenuBarUV
        '
        Me.MenuBarUV.BackColor = System.Drawing.Color.Transparent
        Me.MenuBarUV.CustomBackground = True
        Me.MenuBarUV.CustomizeText = "&Customize Toolbar..."
        Me.MenuBarUV.Dock = System.Windows.Forms.DockStyle.Top
        Me.MenuBarUV.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuBarUV.FullRow = True
        Me.MenuBarUV.ID = 621
        Me.MenuBarUV.Items.AddRange(New NETXP.Controls.Bars.CommandBarItem() {Me.mnuFile, Me.mnuDataProcessing, Me.mnuGraphOptions})
        Me.MenuBarUV.Location = New System.Drawing.Point(0, 0)
        Me.MenuBarUV.Margins.Bottom = 1
        Me.MenuBarUV.Margins.Left = 1
        Me.MenuBarUV.Margins.Right = 1
        Me.MenuBarUV.Margins.Top = 1
        Me.MenuBarUV.Name = "MenuBarUV"
        Me.MenuBarUV.Size = New System.Drawing.Size(806, 24)
        Me.MenuBarUV.Style = NETXP.Controls.Bars.CommandBarStyle.Menu
        Me.MenuBarUV.TabIndex = 0
        Me.MenuBarUV.TabStop = False
        Me.MenuBarUV.Text = ""
        '
        'mnuFile
        '
        Me.mnuFile.Items.AddRange(New NETXP.Controls.Bars.CommandBarItem() {Me.mnuParameters, Me.mnuLoadSpectrumFile, Me.mnuSaveSpectrumFile, Me.CommandBarSeparatorItem1, Me.mnuExit})
        Me.mnuFile.PadHorizontal = 5
        Me.mnuFile.Text = "&File"
        '
        'mnuParameters
        '
        Me.mnuParameters.Image = CType(resources.GetObject("mnuParameters.Image"), System.Drawing.Image)
        Me.mnuParameters.Shortcut = System.Windows.Forms.Shortcut.CtrlP
        Me.mnuParameters.Text = "&Parameters"
        '
        'mnuLoadSpectrumFile
        '
        Me.mnuLoadSpectrumFile.Image = CType(resources.GetObject("mnuLoadSpectrumFile.Image"), System.Drawing.Image)
        Me.mnuLoadSpectrumFile.Shortcut = System.Windows.Forms.Shortcut.CtrlL
        Me.mnuLoadSpectrumFile.Text = "&Load Spectrum File"
        '
        'mnuSaveSpectrumFile
        '
        Me.mnuSaveSpectrumFile.Image = CType(resources.GetObject("mnuSaveSpectrumFile.Image"), System.Drawing.Image)
        Me.mnuSaveSpectrumFile.Shortcut = System.Windows.Forms.Shortcut.CtrlS
        Me.mnuSaveSpectrumFile.Text = "&Save Spectrum File"
        '
        'mnuExit
        '
        Me.mnuExit.Image = CType(resources.GetObject("mnuExit.Image"), System.Drawing.Image)
        Me.mnuExit.Shortcut = System.Windows.Forms.Shortcut.CtrlR
        Me.mnuExit.ShowText = True
        Me.mnuExit.Text = "Return"
        '
        'mnuDataProcessing
        '
        Me.mnuDataProcessing.Items.AddRange(New NETXP.Controls.Bars.CommandBarItem() {Me.mnuBaseLine, Me.mnuStart, Me.mnuSmooth, Me.mnuPeakPick, Me.mnuAbsTransmission, Me.mnuClearSpectrum, Me.mnuPrintGraph})
        Me.mnuDataProcessing.PadHorizontal = 5
        Me.mnuDataProcessing.Text = "Data &Processing"
        '
        'mnuBaseLine
        '
        Me.mnuBaseLine.Image = CType(resources.GetObject("mnuBaseLine.Image"), System.Drawing.Image)
        Me.mnuBaseLine.Shortcut = System.Windows.Forms.Shortcut.CtrlB
        Me.mnuBaseLine.Text = "&Base Line"
        '
        'mnuStart
        '
        Me.mnuStart.Image = CType(resources.GetObject("mnuStart.Image"), System.Drawing.Image)
        Me.mnuStart.Shortcut = System.Windows.Forms.Shortcut.CtrlT
        Me.mnuStart.Text = "&Start"
        '
        'mnuSmooth
        '
        Me.mnuSmooth.Image = CType(resources.GetObject("mnuSmooth.Image"), System.Drawing.Image)
        Me.mnuSmooth.Shortcut = System.Windows.Forms.Shortcut.CtrlM
        Me.mnuSmooth.Text = "S&mooth"
        '
        'mnuPeakPick
        '
        Me.mnuPeakPick.Image = CType(resources.GetObject("mnuPeakPick.Image"), System.Drawing.Image)
        Me.mnuPeakPick.Shortcut = System.Windows.Forms.Shortcut.CtrlK
        Me.mnuPeakPick.Text = "Peak &Pick"
        '
        'mnuAbsTransmission
        '
        Me.mnuAbsTransmission.Image = CType(resources.GetObject("mnuAbsTransmission.Image"), System.Drawing.Image)
        Me.mnuAbsTransmission.Shortcut = System.Windows.Forms.Shortcut.CtrlA
        Me.mnuAbsTransmission.Text = "&Abs -> % Transmission"
        '
        'mnuClearSpectrum
        '
        Me.mnuClearSpectrum.Image = CType(resources.GetObject("mnuClearSpectrum.Image"), System.Drawing.Image)
        Me.mnuClearSpectrum.Shortcut = System.Windows.Forms.Shortcut.CtrlC
        Me.mnuClearSpectrum.Text = "&Clear Spectrum"
        '
        'mnuPrintGraph
        '
        Me.mnuPrintGraph.Image = CType(resources.GetObject("mnuPrintGraph.Image"), System.Drawing.Image)
        Me.mnuPrintGraph.Shortcut = System.Windows.Forms.Shortcut.CtrlG
        Me.mnuPrintGraph.Text = "Print Graph"
        '
        'mnuGraphOptions
        '
        Me.mnuGraphOptions.Items.AddRange(New NETXP.Controls.Bars.CommandBarItem() {Me.mnuPeakEdit, Me.mnuGrid, Me.mnuLegends, Me.mnuShowXYValues, Me.mnuChangeScale})
        Me.mnuGraphOptions.Shortcut = System.Windows.Forms.Shortcut.CtrlG
        Me.mnuGraphOptions.Text = "&Graph Options"
        '
        'mnuPeakEdit
        '
        Me.mnuPeakEdit.Image = CType(resources.GetObject("mnuPeakEdit.Image"), System.Drawing.Image)
        Me.mnuPeakEdit.Shortcut = System.Windows.Forms.Shortcut.CtrlE
        Me.mnuPeakEdit.Text = "Peak &Edit"
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
        Me.mnuLegends.Visible = False
        '
        'mnuShowXYValues
        '
        Me.mnuShowXYValues.Image = CType(resources.GetObject("mnuShowXYValues.Image"), System.Drawing.Image)
        Me.mnuShowXYValues.Shortcut = System.Windows.Forms.Shortcut.CtrlO
        Me.mnuShowXYValues.Text = "Show X, Y &Values"
        '
        'mnuChangeScale
        '
        Me.mnuChangeScale.Image = CType(resources.GetObject("mnuChangeScale.Image"), System.Drawing.Image)
        Me.mnuChangeScale.Text = "Change Scale"
        '
        'StatusBar1
        '
        Me.StatusBar1.Location = New System.Drawing.Point(0, 495)
        Me.StatusBar1.Name = "StatusBar1"
        Me.StatusBar1.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.StatusBarPanelInfo, Me.ProgressPanel, Me.StatusBarPanelDate})
        Me.StatusBar1.ShowPanels = True
        Me.StatusBar1.Size = New System.Drawing.Size(806, 24)
        Me.StatusBar1.TabIndex = 6
        Me.StatusBar1.Text = "StatusBar1"
        '
        'StatusBarPanelInfo
        '
        Me.StatusBarPanelInfo.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
        Me.StatusBarPanelInfo.MinWidth = 40
        Me.StatusBarPanelInfo.Style = System.Windows.Forms.StatusBarPanelStyle.OwnerDraw
        Me.StatusBarPanelInfo.Width = 511
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
        'CustomPanelTop
        '
        Me.CustomPanelTop.BackColor = System.Drawing.Color.AliceBlue
        Me.CustomPanelTop.Controls.Add(Me.lblSlitnm)
        Me.CustomPanelTop.Controls.Add(Me.nudSlit)
        Me.CustomPanelTop.Controls.Add(Me.nudD2Cur)
        Me.CustomPanelTop.Controls.Add(Me.nudPMT)
        Me.CustomPanelTop.Controls.Add(Me.Office2003Header1)
        Me.CustomPanelTop.Controls.Add(Me.lblYValue)
        Me.CustomPanelTop.Controls.Add(Me.lblWvPos)
        Me.CustomPanelTop.Controls.Add(Me.lblPMTVolts)
        Me.CustomPanelTop.Controls.Add(Me.lblD2CurmA)
        Me.CustomPanelTop.Controls.Add(Me.cmbModes)
        Me.CustomPanelTop.Controls.Add(Me.lblModes)
        Me.CustomPanelTop.Controls.Add(Me.lblSpeed)
        Me.CustomPanelTop.Controls.Add(Me.cmbSpeed)
        Me.CustomPanelTop.Controls.Add(Me.lblSlitWidth)
        Me.CustomPanelTop.Controls.Add(Me.lblD2Cur)
        Me.CustomPanelTop.Controls.Add(Me.lblPMT)
        Me.CustomPanelTop.Dock = System.Windows.Forms.DockStyle.Left
        Me.CustomPanelTop.Location = New System.Drawing.Point(0, 0)
        Me.CustomPanelTop.Name = "CustomPanelTop"
        Me.CustomPanelTop.Size = New System.Drawing.Size(198, 437)
        Me.CustomPanelTop.TabIndex = 7
        '
        'lblSlitnm
        '
        Me.lblSlitnm.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSlitnm.Location = New System.Drawing.Point(160, 116)
        Me.lblSlitnm.Name = "lblSlitnm"
        Me.lblSlitnm.Size = New System.Drawing.Size(22, 18)
        Me.lblSlitnm.TabIndex = 52
        Me.lblSlitnm.Text = "nm"
        Me.lblSlitnm.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'nudSlit
        '
        Me.nudSlit.BackColor = System.Drawing.SystemColors.Window
        Me.nudSlit.BackgroundColor = System.Drawing.SystemColors.Window
        Me.nudSlit.ButtonClicked = ValueEditor.ValueEditor.EnumValueEditorButtons.MainButton
        Me.nudSlit.ChangeFactor = 0
        Me.nudSlit.DecimalPlace = 0
        Me.nudSlit.DnButtonText = "6"
        Me.nudSlit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.nudSlit.ForegroundColor = System.Drawing.SystemColors.ControlText
        Me.nudSlit.IsReverseOperation = False
        Me.nudSlit.IsUpDownButtonToBeDisabledOnValueChange = False
        Me.nudSlit.Location = New System.Drawing.Point(84, 109)
        Me.nudSlit.MaxValue = 0
        Me.nudSlit.MinValue = 0
        Me.nudSlit.Name = "nudSlit"
        Me.nudSlit.Size = New System.Drawing.Size(72, 22)
        Me.nudSlit.TabIndex = 8
        Me.nudSlit.UpButtonText = "5"
        Me.nudSlit.Value = 0
        Me.nudSlit.ValueEditorEnabled = True
        Me.nudSlit.ValueEditorFont = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nudSlit.Visible = False
        '
        'nudD2Cur
        '
        Me.nudD2Cur.BackColor = System.Drawing.SystemColors.Window
        Me.nudD2Cur.BackgroundColor = System.Drawing.SystemColors.Window
        Me.nudD2Cur.ButtonClicked = ValueEditor.ValueEditor.EnumValueEditorButtons.MainButton
        Me.nudD2Cur.ChangeFactor = 0
        Me.nudD2Cur.DecimalPlace = 0
        Me.nudD2Cur.DnButtonText = "6"
        Me.nudD2Cur.ForeColor = System.Drawing.SystemColors.ControlText
        Me.nudD2Cur.ForegroundColor = System.Drawing.SystemColors.ControlText
        Me.nudD2Cur.IsReverseOperation = False
        Me.nudD2Cur.IsUpDownButtonToBeDisabledOnValueChange = False
        Me.nudD2Cur.Location = New System.Drawing.Point(84, 76)
        Me.nudD2Cur.MaxValue = 0
        Me.nudD2Cur.MinValue = 0
        Me.nudD2Cur.Name = "nudD2Cur"
        Me.nudD2Cur.Size = New System.Drawing.Size(72, 22)
        Me.nudD2Cur.TabIndex = 5
        Me.nudD2Cur.UpButtonText = "5"
        Me.nudD2Cur.Value = 0
        Me.nudD2Cur.ValueEditorEnabled = True
        Me.nudD2Cur.ValueEditorFont = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nudD2Cur.Visible = False
        '
        'nudPMT
        '
        Me.nudPMT.BackColor = System.Drawing.SystemColors.Window
        Me.nudPMT.BackgroundColor = System.Drawing.SystemColors.Window
        Me.nudPMT.ButtonClicked = ValueEditor.ValueEditor.EnumValueEditorButtons.MainButton
        Me.nudPMT.ChangeFactor = 0
        Me.nudPMT.DecimalPlace = 0
        Me.nudPMT.DnButtonText = "6"
        Me.nudPMT.ForeColor = System.Drawing.SystemColors.ControlText
        Me.nudPMT.ForegroundColor = System.Drawing.SystemColors.ControlText
        Me.nudPMT.IsReverseOperation = False
        Me.nudPMT.IsUpDownButtonToBeDisabledOnValueChange = False
        Me.nudPMT.Location = New System.Drawing.Point(84, 43)
        Me.nudPMT.MaxValue = 0
        Me.nudPMT.MinValue = 0
        Me.nudPMT.Name = "nudPMT"
        Me.nudPMT.Size = New System.Drawing.Size(72, 22)
        Me.nudPMT.TabIndex = 0
        Me.nudPMT.UpButtonText = "5"
        Me.nudPMT.Value = 0
        Me.nudPMT.ValueEditorEnabled = True
        Me.nudPMT.ValueEditorFont = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nudPMT.Visible = False
        '
        'Office2003Header1
        '
        Me.Office2003Header1.BackColor = System.Drawing.SystemColors.Control
        Me.Office2003Header1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Office2003Header1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Office2003Header1.Location = New System.Drawing.Point(0, 0)
        Me.Office2003Header1.Name = "Office2003Header1"
        Me.Office2003Header1.Size = New System.Drawing.Size(198, 22)
        Me.Office2003Header1.TabIndex = 46
        Me.Office2003Header1.TitleFont = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Office2003Header1.TitleText = "UV Parameters"
        '
        'lblYValue
        '
        Me.lblYValue.BackColor = System.Drawing.Color.White
        Me.lblYValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblYValue.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblYValue.ForeColor = System.Drawing.Color.Blue
        Me.lblYValue.Location = New System.Drawing.Point(9, 403)
        Me.lblYValue.Name = "lblYValue"
        Me.lblYValue.Size = New System.Drawing.Size(166, 20)
        Me.lblYValue.TabIndex = 45
        Me.lblYValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblWvPos
        '
        Me.lblWvPos.BackColor = System.Drawing.Color.White
        Me.lblWvPos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblWvPos.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWvPos.ForeColor = System.Drawing.Color.Blue
        Me.lblWvPos.Location = New System.Drawing.Point(9, 373)
        Me.lblWvPos.Name = "lblWvPos"
        Me.lblWvPos.Size = New System.Drawing.Size(166, 20)
        Me.lblWvPos.TabIndex = 44
        Me.lblWvPos.Text = "Wavelength (nm) :"
        Me.lblWvPos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPMTVolts
        '
        Me.lblPMTVolts.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPMTVolts.Location = New System.Drawing.Point(160, 45)
        Me.lblPMTVolts.Name = "lblPMTVolts"
        Me.lblPMTVolts.Size = New System.Drawing.Size(32, 18)
        Me.lblPMTVolts.TabIndex = 27
        Me.lblPMTVolts.Text = "volts"
        Me.lblPMTVolts.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblD2CurmA
        '
        Me.lblD2CurmA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblD2CurmA.Location = New System.Drawing.Point(160, 83)
        Me.lblD2CurmA.Name = "lblD2CurmA"
        Me.lblD2CurmA.Size = New System.Drawing.Size(22, 18)
        Me.lblD2CurmA.TabIndex = 26
        Me.lblD2CurmA.Text = "mA"
        Me.lblD2CurmA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbModes
        '
        Me.cmbModes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbModes.Enabled = False
        Me.cmbModes.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbModes.Items.AddRange(New Object() {"D2E", "HCLE", "AA", "SELFTEST", "MABS", "AABGC", "EMISSION"})
        Me.cmbModes.Location = New System.Drawing.Point(80, 176)
        Me.cmbModes.Name = "cmbModes"
        Me.cmbModes.Size = New System.Drawing.Size(82, 23)
        Me.cmbModes.TabIndex = 10
        Me.cmbModes.Visible = False
        '
        'lblModes
        '
        Me.lblModes.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblModes.Location = New System.Drawing.Point(20, 174)
        Me.lblModes.Name = "lblModes"
        Me.lblModes.Size = New System.Drawing.Size(48, 20)
        Me.lblModes.TabIndex = 8
        Me.lblModes.Text = "Modes"
        Me.lblModes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSpeed
        '
        Me.lblSpeed.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSpeed.Location = New System.Drawing.Point(20, 144)
        Me.lblSpeed.Name = "lblSpeed"
        Me.lblSpeed.Size = New System.Drawing.Size(50, 20)
        Me.lblSpeed.TabIndex = 7
        Me.lblSpeed.Text = "Speed"
        Me.lblSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbSpeed
        '
        Me.cmbSpeed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSpeed.Enabled = False
        Me.cmbSpeed.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSpeed.Items.AddRange(New Object() {"FAST", "MEDIUM", "SLOW"})
        Me.cmbSpeed.Location = New System.Drawing.Point(80, 142)
        Me.cmbSpeed.Name = "cmbSpeed"
        Me.cmbSpeed.Size = New System.Drawing.Size(82, 23)
        Me.cmbSpeed.TabIndex = 9
        Me.cmbSpeed.Visible = False
        '
        'lblSlitWidth
        '
        Me.lblSlitWidth.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSlitWidth.Location = New System.Drawing.Point(20, 110)
        Me.lblSlitWidth.Name = "lblSlitWidth"
        Me.lblSlitWidth.Size = New System.Drawing.Size(58, 20)
        Me.lblSlitWidth.TabIndex = 5
        Me.lblSlitWidth.Text = "Slit Width"
        Me.lblSlitWidth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblD2Cur
        '
        Me.lblD2Cur.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblD2Cur.Location = New System.Drawing.Point(20, 77)
        Me.lblD2Cur.Name = "lblD2Cur"
        Me.lblD2Cur.Size = New System.Drawing.Size(44, 20)
        Me.lblD2Cur.TabIndex = 2
        Me.lblD2Cur.Text = "D2 Cur"
        Me.lblD2Cur.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPMT
        '
        Me.lblPMT.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPMT.Location = New System.Drawing.Point(20, 44)
        Me.lblPMT.Name = "lblPMT"
        Me.lblPMT.Size = New System.Drawing.Size(36, 20)
        Me.lblPMT.TabIndex = 1
        Me.lblPMT.Text = "PMT"
        Me.lblPMT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CustomPanelBack
        '
        Me.CustomPanelBack.BackColor = System.Drawing.Color.AliceBlue
        Me.CustomPanelBack.Controls.Add(Me.CustomPanelMain)
        Me.CustomPanelBack.Controls.Add(Me.CustomPanelTop)
        Me.CustomPanelBack.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CustomPanelBack.Location = New System.Drawing.Point(0, 58)
        Me.CustomPanelBack.Name = "CustomPanelBack"
        Me.CustomPanelBack.Size = New System.Drawing.Size(806, 437)
        Me.CustomPanelBack.TabIndex = 8
        '
        'ToolBar1
        '
        Me.ToolBar1.BackColor = System.Drawing.Color.Transparent
        Me.ToolBar1.Controls.Add(Me.ToolBar)
        Me.ToolBar1.CustomizeText = "&Customize Toolbar..."
        Me.ToolBar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.ToolBar1.ID = 7406
        Me.ToolBar1.Items.AddRange(New NETXP.Controls.Bars.CommandBarItem() {Me.CommandBarButtonItem1})
        Me.ToolBar1.Location = New System.Drawing.Point(0, 24)
        Me.ToolBar1.Margins.Bottom = 1
        Me.ToolBar1.Margins.Left = 1
        Me.ToolBar1.Margins.Right = 1
        Me.ToolBar1.Margins.Top = 1
        Me.ToolBar1.MenuEnabled = False
        Me.ToolBar1.Name = "ToolBar1"
        Me.ToolBar1.Size = New System.Drawing.Size(806, 34)
        Me.ToolBar1.TabIndex = 9
        Me.ToolBar1.TabStop = False
        Me.ToolBar1.Text = ""
        '
        'ToolBar
        '
        Me.ToolBar.BackColor = System.Drawing.Color.Transparent
        Me.ToolBar.CustomizeText = "&Customize Toolbar..."
        Me.ToolBar.Dock = System.Windows.Forms.DockStyle.Top
        Me.ToolBar.ID = 7406
        Me.ToolBar.Items.AddRange(New NETXP.Controls.Bars.CommandBarItem() {Me.tlbbtnReturn, Me.CommandBarSeparatorItem3, Me.tlbbtnParameters, Me.tlbbtnLoadspectrumFile, Me.tlbbtnSaveSpectrumFile, Me.CommandBarSeparatorItem4, Me.tlbbtnStart, Me.tlbbtnBaseLine, Me.tlbbtnClearSpectrum, Me.tlbbtnChangeScale, Me.CommandBarSeparatorItem5, Me.tlbbtnSmooth, Me.tlbbtnPeakPick, Me.tlbbtnPrintGraph, Me.CommandBarSeparatorItem2, Me.tlbbtnPeakEdit, Me.tlbbtnGrid, Me.tlbbtnLegends, Me.tlbbtnShowXYValues, Me.CommandBarSeparatorItem6, Me.tlbbtnAbsToTransmission})
        Me.ToolBar.Location = New System.Drawing.Point(0, 0)
        Me.ToolBar.Margins.Bottom = 1
        Me.ToolBar.Margins.Left = 1
        Me.ToolBar.Margins.Right = 1
        Me.ToolBar.Margins.Top = 1
        Me.ToolBar.MenuEnabled = False
        Me.ToolBar.Name = "ToolBar"
        Me.ToolBar.Size = New System.Drawing.Size(806, 34)
        Me.ToolBar.TabIndex = 0
        Me.ToolBar.TabStop = False
        Me.ToolBar.Text = "Command Bar"
        '
        'tlbbtnReturn
        '
        Me.tlbbtnReturn.Image = CType(resources.GetObject("tlbbtnReturn.Image"), System.Drawing.Image)
        Me.tlbbtnReturn.Shortcut = System.Windows.Forms.Shortcut.CtrlR
        Me.tlbbtnReturn.Text = "RETURN[CTRL+R]"
        '
        'tlbbtnParameters
        '
        Me.tlbbtnParameters.Image = CType(resources.GetObject("tlbbtnParameters.Image"), System.Drawing.Image)
        Me.tlbbtnParameters.Shortcut = System.Windows.Forms.Shortcut.CtrlP
        Me.tlbbtnParameters.Text = "PARAMETERS[CTRL+P]"
        '
        'tlbbtnLoadspectrumFile
        '
        Me.tlbbtnLoadspectrumFile.Image = CType(resources.GetObject("tlbbtnLoadspectrumFile.Image"), System.Drawing.Image)
        Me.tlbbtnLoadspectrumFile.Shortcut = System.Windows.Forms.Shortcut.CtrlL
        Me.tlbbtnLoadspectrumFile.Text = "LOAD SPECTRUM FILE[CTRL+L]"
        '
        'tlbbtnSaveSpectrumFile
        '
        Me.tlbbtnSaveSpectrumFile.Image = CType(resources.GetObject("tlbbtnSaveSpectrumFile.Image"), System.Drawing.Image)
        Me.tlbbtnSaveSpectrumFile.Shortcut = System.Windows.Forms.Shortcut.CtrlS
        Me.tlbbtnSaveSpectrumFile.Text = "SAVE SPECTRUM FILE[CTRL+S]"
        '
        'tlbbtnStart
        '
        Me.tlbbtnStart.Image = CType(resources.GetObject("tlbbtnStart.Image"), System.Drawing.Image)
        Me.tlbbtnStart.Shortcut = System.Windows.Forms.Shortcut.CtrlT
        Me.tlbbtnStart.Text = "START[CTRL+T]"
        '
        'tlbbtnBaseLine
        '
        Me.tlbbtnBaseLine.Image = CType(resources.GetObject("tlbbtnBaseLine.Image"), System.Drawing.Image)
        Me.tlbbtnBaseLine.Shortcut = System.Windows.Forms.Shortcut.CtrlB
        Me.tlbbtnBaseLine.Text = "BASE LINE[CTRL+B]"
        '
        'tlbbtnClearSpectrum
        '
        Me.tlbbtnClearSpectrum.Image = CType(resources.GetObject("tlbbtnClearSpectrum.Image"), System.Drawing.Image)
        Me.tlbbtnClearSpectrum.Shortcut = System.Windows.Forms.Shortcut.CtrlC
        Me.tlbbtnClearSpectrum.Text = "CLEAR SPECTRUM[CTRL+C]"
        '
        'tlbbtnChangeScale
        '
        Me.tlbbtnChangeScale.Image = CType(resources.GetObject("tlbbtnChangeScale.Image"), System.Drawing.Image)
        Me.tlbbtnChangeScale.Shortcut = System.Windows.Forms.Shortcut.CtrlH
        Me.tlbbtnChangeScale.Text = "CHANGE SCALE[CTRL+H]"
        '
        'tlbbtnSmooth
        '
        Me.tlbbtnSmooth.Image = CType(resources.GetObject("tlbbtnSmooth.Image"), System.Drawing.Image)
        Me.tlbbtnSmooth.Shortcut = System.Windows.Forms.Shortcut.CtrlM
        Me.tlbbtnSmooth.Text = "SMOOTH[CTRL+M]"
        '
        'tlbbtnPeakPick
        '
        Me.tlbbtnPeakPick.Image = CType(resources.GetObject("tlbbtnPeakPick.Image"), System.Drawing.Image)
        Me.tlbbtnPeakPick.Shortcut = System.Windows.Forms.Shortcut.CtrlK
        Me.tlbbtnPeakPick.Text = "PEAK PICK[CTRL+K]"
        '
        'tlbbtnPrintGraph
        '
        Me.tlbbtnPrintGraph.Image = CType(resources.GetObject("tlbbtnPrintGraph.Image"), System.Drawing.Image)
        Me.tlbbtnPrintGraph.Shortcut = System.Windows.Forms.Shortcut.CtrlG
        Me.tlbbtnPrintGraph.Text = "PPRINT GRAPH[CTRL+G]"
        '
        'tlbbtnPeakEdit
        '
        Me.tlbbtnPeakEdit.Image = CType(resources.GetObject("tlbbtnPeakEdit.Image"), System.Drawing.Image)
        Me.tlbbtnPeakEdit.Text = "PEAK EDIT[CTRL+E]"
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
        'tlbbtnShowXYValues
        '
        Me.tlbbtnShowXYValues.Image = CType(resources.GetObject("tlbbtnShowXYValues.Image"), System.Drawing.Image)
        Me.tlbbtnShowXYValues.Text = "SHOW X, Y VALUES[CTRL+O]"
        '
        'tlbbtnAbsToTransmission
        '
        Me.tlbbtnAbsToTransmission.Image = CType(resources.GetObject("tlbbtnAbsToTransmission.Image"), System.Drawing.Image)
        Me.tlbbtnAbsToTransmission.Shortcut = System.Windows.Forms.Shortcut.CtrlA
        Me.tlbbtnAbsToTransmission.Text = "ABS->%TRANSMISSION[CTRL+A]"
        '
        'CommandBarButtonItem1
        '
        Me.CommandBarButtonItem1.Image = CType(resources.GetObject("CommandBarButtonItem1.Image"), System.Drawing.Image)
        Me.CommandBarButtonItem1.Text = Nothing
        '
        'frmUVScanningSpectrumMode
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(806, 519)
        Me.Controls.Add(Me.CustomPanelBack)
        Me.Controls.Add(Me.ToolBar1)
        Me.Controls.Add(Me.StatusBar1)
        Me.Controls.Add(Me.MenuBarUV)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimizeBox = False
        Me.Name = "frmUVScanningSpectrumMode"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "UV Scanning Spectrum Mode"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.CustomPanelMain.ResumeLayout(False)
        Me.CustomPanelBottom.ResumeLayout(False)
        CType(Me.MenuBarUV, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StatusBarPanelInfo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProgressPanel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StatusBarPanelDate, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CustomPanelTop.ResumeLayout(False)
        Me.CustomPanelBack.ResumeLayout(False)
        CType(Me.ToolBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolBar1.ResumeLayout(False)
        CType(Me.ToolBar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Form Events"

    Private Sub frmUVScanningSpectrumMode_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '=====================================================================
        ' Procedure Name        : frmUVScanningSpectrumMode_Load
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To initialize the form
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 07.10.06
        ' Revisions             : 
        '=====================================================================
        ''note:
        ''To initialize the form
        ''this is called when UV spectrum  mode is loaded

        Application.DoEvents()
        Dim objWait As New CWaitCursor
        Try

            If Not gstructSettings.ExeToRun = EnumApplicationMode.ServiceUtility Then
                ''check the mode of application
                If Not IsNothing(gobjMain) Then
                    If gobjMain.mobjController.IsThreadRunning = True Then
                        ''check if any thread is running if yes then stop thet thread
                        gobjMain.mobjController.Cancel()
                        gobjCommProtocol.mobjCommdll.subTime_Delay(500)   '10.12.07
                        Application.DoEvents()
                    End If
                End If
            End If

            If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
                ''check for 201 instrument
                btnIgnite.Enabled = False
                btnExtinguish.Enabled = False
            End If

            cmdChangeScale.BringToFront()
            btnStart.BringToFront()

            If mblnAvoidProcessing = True Then
                Exit Sub
            End If
            mblnAvoidProcessing = True

            ShowProgressBar(gstrTitleInstrumentType & ConstFormLoad)
            gobjclsTimer.subTimerStart(StatusBar1)
            ''start a timer for status display

            MenuBarUV.BackColor = System.Drawing.Color.Gainsboro

            gblnUVS = True
            strfrmStatusTurretNo = gobjfrmStatus.lblTurretNo.Text
            strfrmStatusEle = gobjfrmStatus.lblElementName.Text

            cmdChangeScale.Focus()
            ''got a focus on change scale.


            'To check if Flame is present and turn it OFF and also Air OFF
            If gobjInst.Aaf = True Then
                If gobjCommProtocol.funcFlame_OFF() = True Then
                    ''check flame should be off
                    gobjInst.Aaf = False
                End If
            End If
            gobjCommProtocol.funcAir_OFF()
            ''serial communication function for air off

            Call funcInitialise()
            ''this is a function for initialisation 

            'Saurabh 10.07.07 To bring status form in front
            gobjfrmStatus.Show()
            ''form falme status must be shown
            'Saurabh
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
            mblnAvoidProcessing = False
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            Call HideProgressBar()
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub frmUVScanningSpectrumMode_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        '=====================================================================
        ' Procedure Name        : frmUVScanningSpectrumMode_Load
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 14.02.07
        ' Revisions             : 
        '=====================================================================
        ''note:
        ''To Closing the form
        ''this is called when user closed the form
        Try
            If mblnAvoidProcessing = True Then
                ''flag for avoiding a process
                e.Cancel = True
                Exit Sub
            End If
            Call gobjMessageAdapter.ShowMessage(constCuvetteBurner)
            Application.DoEvents()
            
            '//---- Added by Sachin Dokhale Set the previous default Calibration mode
            Call gobjCommProtocol.funcCalibrationMode(m_bytCalibMode)
            ''show the cuvette burner msg
            ''allow application to perfrom its panding work

            'strfrmStatusTurretNo = gobjfrmStatus.lblTurretNo.Text
            'strfrmStatusEle = gobjfrmStatus.lblElementName.Text


            '---Changed By Mangesh on 24-Apr-2007
            'gobjfrmStatus.lblTurretNo.Text = strfrmStatusTurretNo
            'gobjfrmStatus.lblElementName.Text = strfrmStatusEle
            'gobjfrmStatus.lblElementName.Refresh()
            'gobjfrmStatus.lblElementName.Refresh()
            If Not (strfrmStatusTurretNo = "") Then
                gobjfrmStatus.TurretNumber = CInt(strfrmStatusTurretNo)
                ''shows the turrert no in a status forms
            End If
            gobjfrmStatus.ElementName = strfrmStatusEle

            If Not gstructSettings.ExeToRun = EnumApplicationMode.ServiceUtility Then
                ''check for the application mode
                'If Not (gstructSettings.AppMode = EnumAppMode.DemoMode) Then
                If Not ((gstructSettings.AppMode = EnumAppMode.DemoMode) Or _
                        (gstructSettings.AppMode = EnumAppMode.DemoMode_201) Or _
                        (gstructSettings.AppMode = EnumAppMode.DemoMode_203D)) Then
                    '//----- Added by Sachin Dokhale
                    'gobjMain.mobjController.Start(gobjclsBgFlameStatus)
                    If gobjMain.mobjController.IsThreadRunning = False Then
                        gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay)   '10.12.07
                        Application.DoEvents()
                        ''if thread is not running then restart the status flag1
                        gobjMain.mobjController.Start(gobjclsBgFlameStatus)
                    End If
                    '//-----
                    gobjfrmStatus.Visible = True
                End If
            End If
            If Not gobjclsTimer Is Nothing Then
                gobjclsTimer.subTimerStop()
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
            'mblnAvoidProcessing = False
            gobjCommProtocol.funcAir_ON()
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub mnuExit_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : mnuExit_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : 
        ' Description           : to handle exit event.
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 14.02.07
        ' Revisions             : 
        '=====================================================================
        ''note:
        ''this is called when user exit from the spectrum

        Try
            If mblnAvoidProcessing = True Then
                Exit Sub
            End If
            gobjclsTimer.subTimerStop()
            ''stop the timer.
            Me.DialogResult = DialogResult.OK
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
            'mblnAvoidProcessing = False
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub mnuPeakPick_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : mnuPeakPick_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : 
        ' Description           : to handel peakpick event.
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 14.02.07
        ' Revisions             : 
        '=====================================================================
        Call subPeakValley()
        ''this is a function for finding peak valley
    End Sub

    Private Sub btnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : btnStart_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : this function is called after clicking on start button
        ' Description           : start step2
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 07.10.06
        ' Revisions             : 
        '=====================================================================
        If mAvoidProcessBtn = True Then
            Exit Sub
        End If
        Try
            ''note:
            ''this will call main routin for UV spectrum.
            ''check the cond that spectrum is already running or not
            mAvoidProcessBtn = True
            If mblnSpectrumStarted = False Then
                ''if yes then 
                Call subStartScan()
            Else
                ''if no then
                Call subStopScan()
            End If

            mAvoidProcessBtn = False
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            mAvoidProcessBtn = False
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            btnStart.Focus()
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub btnBaseLine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : btnBaseLine_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : to handle baseline event
        ' Description           : this will called when user click on baseline button.
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 07.10.06
        ' Revisions             : 
        '=====================================================================

        Try
            ''note:
            ''this will call Baseline routin
            gblnBaseLine = False
            ''gblnBaseLine  global flag for baseline
            If mblnSpectrumStarted = False Then
                ''check for spectrum cond is yes
                Call subStartBaseline()
            Else
                ''if no
                Call subStopScan()
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
            btnBaseLine.Focus()
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
        ' Description           : this is called when user click on clear spectrum button
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 07.10.06
        ' Revisions             : 
        '=====================================================================
        ''note:
        ''this will called when user click on clear spectrum button.
        Dim objWait As New CWaitCursor
        Try
            Call subClearScan()
            ''this is a function for clearing a spectrum
            Me.AASGraphUVSpectrum.disablePeakEdit() 'ADDED   by pankaj on 26 Aug 07 for pick edit bar
            ''this will disable a peakedit after clears tha spectrum
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

    'Private Sub nudPMT_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    nudPMT.Enabled = False
    '    mblnAvoidProcessing = True
    '    RemoveHandler nudPMT.ValueChanged, AddressOf nudPMT_ValueChanged
    '    Application.DoEvents()
    '    Call funcSetPmtVParameter(nudPMT.Value)
    '    AddHandler nudPMT.ValueChanged, AddressOf nudPMT_ValueChanged
    '    mblnAvoidProcessing = False
    '    nudPMT.Enabled = True
    '    Application.DoEvents()
    'End Sub

    Private Sub nudPMT_ValueChanged(ByVal ChangePmt As Double)
        '=====================================================================
        ' Procedure Name        : nudPMT_ValueChanged
        ' Parameters Passed     : ChangePmt
        ' Returns               : None
        ' Purpose               : this is called when user change the value of pmt
        ' Description           : select index id for Calibration mode
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 21.11.06
        ' Revisions             : praveen
        '=====================================================================
        Dim objWait As New CWaitCursor
        Try

            'nudPMT.Enabled = False
            'If mblnAvoidProcessing = True Then
            '    Exit Sub
            'End If
            'mblnAvoidProcessing = True
            RemoveHandler nudPMT.ValueEditorValueChanged, AddressOf nudPMT_ValueChanged
            Application.DoEvents()

            Call funcSetPmtVParameter(nudPMT.Value)
            ''this will set the PMT as per user
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
            AddHandler nudPMT.ValueEditorValueChanged, AddressOf nudPMT_ValueChanged
            'mblnAvoidProcessing = False
            'nudPMT.Enabled = True
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            Application.DoEvents()
            ''allow application to perfrom its panding work.
        End Try
    End Sub

    Private Sub nudPMT_ValueEditorClick()
        '=====================================================================
        ' Procedure Name        : nudPMT_ValueEditorClick
        ' Parameters Passed     : 
        ' Returns               : None
        ' Purpose               : 
        ' Description           : called when PMT calue is changed
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
            Application.DoEvents()
            ''allow application to perfrom its panding work
            Dim dblReturnValue As Double
            dblReturnValue = gobjInst.PmtVoltage
            If funcSetFrmEditValue(dblReturnValue, "Set PMT (0 - 700)V", nudPMT.MinValue, nudPMT.MaxValue) = True Then
                ''this is a function which call edit dialog as per the parameter passed
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
            'mblnAvoidProcessing = False
            AddHandler nudPMT.ValueEditorClick, AddressOf nudPMT_ValueEditorClick
            'nudPMT.Enabled = True
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            nudPMT.Focus()
            Application.DoEvents()
            ''allow application to perfrom its panding work
        End Try
    End Sub

    'Private Sub nudSlit_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    nudSlit.Enabled = False
    '    mblnAvoidProcessing = True
    '    RemoveHandler nudSlit.ValueChanged, AddressOf nudSlit_ValueChanged
    '    Application.DoEvents()
    '    Call funcSetSlit_WidthParameter(nudSlit.Value)
    '    AddHandler nudSlit.ValueChanged, AddressOf nudSlit_ValueChanged
    '    mblnAvoidProcessing = False
    '    nudSlit.Enabled = True
    '    Application.DoEvents()
    'End Sub

    Private Sub nudSlit_ValueChanged(ByVal ChangeSlit As Double)
        '=====================================================================
        ' Procedure Name        : nudSlit_ValueChanged
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : 
        ' Description           : to handle Slit value event.
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 14.02.07
        ' Revisions             : 
        '=====================================================================
        ''this is called when user change a slitwidth

        Dim objWait As New CWaitCursor
        Try
            'nudSlit.Enabled = False
            'If mblnAvoidProcessing = True Then
            '    Exit Sub
            'End If
            'mblnAvoidProcessing = True
            RemoveHandler nudSlit.ValueEditorValueChanged, AddressOf nudSlit_ValueChanged
            'RemoveHandler btnStart.Click, AddressOf btnStart_Click
            'RemoveHandler btnBaseLine.Click, AddressOf btnBaseLine_Click
            Application.DoEvents()
            Call funcSetSlit_WidthParameter(nudSlit.Value)
            ''this is a function for setting slit as passed in parameter

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
            AddHandler nudSlit.ValueEditorValueChanged, AddressOf nudSlit_ValueChanged
            'AddHandler btnStart.Click, AddressOf btnStart_Click
            'AddHandler btnBaseLine.Click, AddressOf btnBaseLine_Click
            'mblnAvoidProcessing = False
            'nudSlit.Enabled = True
            objWait.Dispose()
            Application.DoEvents()
        End Try

    End Sub

    Private Sub nudSlit_ValueEditorClick()
        '=====================================================================
        ' Procedure Name        : nudSlit_ValueEditorClick
        ' Parameters Passed     :  
        ' Returns               : None
        ' Purpose               : 
        ' Description           : this is called when slit value has been changed.
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 21.11.06
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Try
            'nudSlit.Enabled = False
            'If mblnAvoidProcessing = True Then
            '    Exit Sub
            'End If
            'mblnAvoidProcessing = True
            RemoveHandler nudSlit.ValueEditorClick, AddressOf nudSlit_ValueEditorClick
            'RemoveHandler btnStart.Click, AddressOf btnStart_Click
            'RemoveHandler btnBaseLine.Click, AddressOf btnBaseLine_Click
            Application.DoEvents()
            Dim dblReturnValue As Double
            dblReturnValue = gobjClsAAS203.funcGet_SlitWidth
            If funcSetFrmEditValue(dblReturnValue, "Set Slit Width (0.0 - 2.0)nm", nudSlit.MinValue, nudSlit.MaxValue) = True Then
                ''this will show a edit dialog as per user defined parameter.
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
            AddHandler nudSlit.ValueEditorClick, AddressOf nudSlit_ValueEditorClick
            'AddHandler btnStart.Click, AddressOf btnStart_Click
            'AddHandler btnBaseLine.Click, AddressOf btnBaseLine_Click
            'nudSlit.Enabled = True
            'mblnAvoidProcessing = False
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            nudSlit.Focus()
            Application.DoEvents()
        End Try
    End Sub

    Private Sub nudD2Cur_ValueChanged(ByVal ChangeD2Cur As Double)
        '=====================================================================
        ' Procedure Name        : nudD2Cur_ValueChanged
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : 
        ' Description           : to handle  D2 current value event.
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 14.02.07
        ' Revisions             : 
        '=====================================================================
        ''this is called when user change a D2 Curr value
        Dim objWait As New CWaitCursor
        Try
            'nudD2Cur.Enabled = False
            'If mblnAvoidProcessing = True Then
            '    Exit Sub
            'End If
            'mblnAvoidProcessing = True
            RemoveHandler nudD2Cur.ValueEditorValueChanged, AddressOf nudD2Cur_ValueChanged
            Application.DoEvents()
            If ReInitLampInstParameters = True Then
                Exit Sub
            End If
            Call funcSetD2_CurParameter(nudD2Cur.Value)
            ''this is a function for seetting given D2 Current value
            If nudD2Cur.Value = 100.0 Then
                ''set a maximum value for curr
                nudD2Cur.Text = "D2 Off"
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
            AddHandler nudD2Cur.ValueEditorValueChanged, AddressOf nudD2Cur_ValueChanged
            'mblnAvoidProcessing = False
            'nudD2Cur.Enabled = True
            objWait.Dispose()
            Application.DoEvents()
        End Try

    End Sub

    Private Sub nudD2Cur_ValueEditorClick()
        '=====================================================================
        ' Procedure Name        : nudD2Cur_ValueEditorClick
        ' Parameters Passed     :  
        ' Returns               : None
        ' Purpose               : 
        ' Description           : called when D2 current has been changed
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 21.11.06
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Dim dblReturnValue As Double
        Try
            'nudD2Cur.Enabled = False
            'If mblnAvoidProcessing = True Then
            '    Exit Sub
            'End If
            'mblnAvoidProcessing = True
            RemoveHandler nudD2Cur.ValueEditorClick, AddressOf nudD2Cur_ValueEditorClick
            Application.DoEvents()
            If ReInitLampInstParameters = True Then
                Exit Sub
            End If

            dblReturnValue = gobjInst.D2Current
            If funcSetFrmEditValue(dblReturnValue, "Set D2 Current (100 - 300)mA", nudD2Cur.MinValue, nudD2Cur.MaxValue) = True Then
                ''display a edit form as par given value.

                nudD2Cur.Value = dblReturnValue
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
            'mblnAvoidProcessing = False
            AddHandler nudD2Cur.ValueEditorClick, AddressOf nudD2Cur_ValueEditorClick
            'nudD2Cur.Enabled = True
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            nudD2Cur.Focus()
            Application.DoEvents()
        End Try
    End Sub

    Private Sub mnuSaveSpectrumFile_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : mnuSaveSpectrumFile_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : 
        ' Description           : for saving spectrum file.
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 15.11.06
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Dim SaveFileDialog1 As New SaveFileDialog
        Try
            If (gstructSettings.Enable21CFR = True) Then
                If Not funcCheckActivityAuthentication(enumActivityAuthentication.SaveFile, gstructUserDetails.Access) Then
                    ''check for authentication
                    Exit Sub
                End If
                'save log a in file
                gfuncInsertActivityLog(EnumModules.SaveFile, "Save Spectrum File Accessed")
            End If
            If mblnAvoidProcessing = True Then
                Exit Sub
            End If
            mblnAvoidProcessing = True
            'SaveFileDialog1.Filter = "Energy Spectrum File(*.spt)|*.spt"
            'SaveFileDialog1.Title = "Show an Energy Spectrum File"
            'SaveFileDialog1.ShowDialog()
            Call funcSaveSpectrumFile()
            ''function for saving a spectrum file on disk
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
            mblnAvoidProcessing = False
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub mnuLoadSpectrumFile_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : mnuLoadSpectrunFile_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : it load a saved spectrum file in UV mode
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 15.11.06
        ' Revisions             : 
        '=====================================================================

        Dim OpenFileDialog1 As New OpenFileDialog
        Dim objWait As New CWaitCursor
        Try
            If (gstructSettings.Enable21CFR = True) Then
                If Not funcCheckActivityAuthentication(enumActivityAuthentication.LoadFile, gstructUserDetails.Access) Then
                    ''check for user authentication
                    Exit Sub
                End If
                'save avtivity log
                gfuncInsertActivityLog(EnumModules.LoadFile, "Load Spectrum File Accessed")
            End If
            If mblnAvoidProcessing = True Then
                Exit Sub
            End If
            mblnAvoidProcessing = True

            'OpenFileDialog1.Filter = "Energy Spectrum File(*.spt)|*.spt"
            'OpenFileDialog1.Title = "Show an Energy Spectrum File"
            'OpenFileDialog1.ShowDialog()
            Call funcLoadSpectrumFile()
            ''function for loading spectrum file
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
            mblnAvoidProcessing = False
            '---------------------------------------------------------
        End Try
        'If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
        '    Dim sr As New System.IO.StreamReader(OpenFileDialog1.FileName)
        '    MessageBox.Show(sr.ReadToEnd, Name, MessageBoxButtons.AbortRetryIgnore, _
        '    MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1, _
        '    MessageBoxOptions.ServiceNotification)
        '    sr.Close()
        'End If

    End Sub

    Private Sub mnuAbsTransmission_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : mnuAbsTransmission_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : this is called when user click on Abs to T
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 15.11.06
        ' Revisions             : 
        '=====================================================================

        Dim objWait As New CWaitCursor
        Try


            If mblnAvoidProcessing = True Then
                Exit Sub
            End If
            mblnAvoidProcessing = True
            Call funcAbsConvertTransmission()

            ''for convertion of Abs to transmission


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
            mblnAvoidProcessing = False
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub cmbSpeed_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : cmbSpeed_SelectedIndexChanged
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : this is called when user change a speed 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 12.12.06
        ' Revisions             : 
        '=====================================================================

        ''note:
        ''this will called when user change the speed.
        Dim objWait As New CWaitCursor
        Try
            If mblnAvoidProcessing = True Then
                Exit Sub
            End If

            mblnAvoidProcessing = True

            RemoveHandler cmbSpeed.SelectedIndexChanged, AddressOf cmbSpeed_SelectedIndexChanged

            If funcSetSpeed(cmbSpeed.SelectedIndex) = True Then
                ''this is a bool function for setting a speed
                gblnBaseLine = False
            End If
            AddHandler cmbSpeed.SelectedIndexChanged, AddressOf cmbSpeed_SelectedIndexChanged

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
            mblnAvoidProcessing = False
            '---------------------------------------------------------
        End Try

    End Sub

    Private Sub cmbModes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        '=====================================================================
        ' Procedure Name        : cmbModes_SelectedIndexChanged
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : this is called when user change the mode 
        ' Description           : select index id for Calibration mode
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 21.11.06
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Try
            If mblnAvoidProcessing = True Then
                ''flag for avoiding a flag
                Exit Sub
            End If
            mblnAvoidProcessing = True
            cmbModes.Enabled = False
            ''check is there any mode selected
            If cmbModes.SelectedIndex > -1 Then
                'gobjInst.Mode = cmbModes.SelectedIndex
                Call funcSetSpectrumParameter(cmbModes.SelectedIndex)
                ''this called for setting spectrum paremeter
            End If
            AddHandler cmbModes.SelectedIndexChanged, AddressOf cmbModes_SelectedIndexChanged
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
            cmbModes.Enabled = True
            mblnAvoidProcessing = False
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub cmdChangeScale_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : cmdChangeScale_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : This is called when user click on change scale button
        ' Description           : select Coordinate of graph
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 21.11.06
        ' Revisions             : 
        '=====================================================================
        ''note:
        ''handles the change scale button click event.


        Dim objWait As New CWaitCursor
        Dim objfrmChangeScale As frmChangeScale
        Try
            If mblnAvoidProcessing = True Then
                Exit Sub
            End If
            mblnAvoidProcessing = True
            objfrmChangeScale = New frmChangeScale(mobjParameters, True)
            ''creat a new object to change scale form
            objfrmChangeScale.funcSetValidatingScale(gobjInst.Mode)
            ''set a scale validation as par selected mode
            If objfrmChangeScale.ShowDialog() = DialogResult.OK Then
                ''this will show change scale dialog
                If Not objfrmChangeScale.SpectrumParameter Is Nothing Then
                    If mobjParameters.XaxisMax < objfrmChangeScale.SpectrumParameter.XaxisMax Then
                        gblnBaseLine = False
                    End If

                    If mobjParameters.XaxisMin > objfrmChangeScale.SpectrumParameter.XaxisMin Then
                        gblnBaseLine = False
                    End If

                    mobjParameters.XaxisMax = objfrmChangeScale.SpectrumParameter.XaxisMax
                    mobjParameters.XaxisMin = objfrmChangeScale.SpectrumParameter.XaxisMin
                    mobjParameters.YaxisMax = objfrmChangeScale.SpectrumParameter.YaxisMax
                    mobjParameters.YaxisMin = objfrmChangeScale.SpectrumParameter.YaxisMin
                    If Not funcGraphPreRequisite(mobjParameters.Cal_Mode, _
                                   mobjParameters.XaxisMin, _
                                   mobjParameters.XaxisMax, _
                                   mobjParameters.YaxisMin, _
                                   mobjParameters.YaxisMax) Then
                        ''set the UV graph as par given parameter by user

                        'Call gFuncShowMessage("Error in setting spectrum parameters", "Please Check Entered Spectrum Parameters", modConstants.EnumMessageType.Information)
                        Exit Sub
                    End If
                    lblWvPos.Text = mXValueLable & gobjInst.WavelengthCur
                End If
                '------------Added by Pankaj on 8 May 07
                'update graph parameters
                AASGraphUVSpectrum.XAxisMin = mobjParameters.XaxisMin
                AASGraphUVSpectrum.XAxisMax = mobjParameters.XaxisMax

                AASGraphUVSpectrum.YAxisMin = mobjParameters.YaxisMin
                AASGraphUVSpectrum.YAxisMax = mobjParameters.YaxisMax

                ''validate user scale
                gobjClsAAS203.Calculate_Analysis_Graph_Param(AASGraphUVSpectrum, ClsAAS203.enumChangeAxis.xyAxis)

            End If

            objfrmChangeScale.Close()


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
            cmdChangeScale.Focus()
            If Not objfrmChangeScale Is Nothing Then
                objfrmChangeScale.Dispose()
            End If
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            mblnAvoidProcessing = False
            Application.DoEvents()
            ''allow application to perfrom its panding task
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub mnuSmoothGraph_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : mnuSmoothGraph_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : this will called when user click on smooth graph menu
        ' Description           : for smooth display of graph
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 15.11.06
        ' Revisions             : 
        '=====================================================================

        Dim objWait As New CWaitCursor
        Try



            Call subSmoothGraph()
            ''function called for smooth graph

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
            mblnAvoidProcessing = False
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub mnuPositionToMaxima_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : mnuPositionToMaxima_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : praveencheck
        ' Description           : Set Maximise position
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 05.01.07
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Dim intIsSetMaximisePosition As Integer
        Dim dblMaximisePosition As Double
        Static CheckMaxPosition As Boolean = False

        Try
            If mblnAvoidProcessing = True Then
                Exit Sub
            End If
            mblnAvoidProcessing = True

            If mintChannelIndex > -1 Then
                If Not (AASGraphUVSpectrum.OfflineCurve Is Nothing) Then
                    If (CheckMaxPosition = False) And (intCurveIndex > -1) Then
                        intIsSetMaximisePosition = gobjMessageAdapter.ShowMessage(constSetMaximisePosition)
                        Application.DoEvents()
                        If intIsSetMaximisePosition = MsgBoxResult.Yes Then
                            CheckMaxPosition = CheckMaxPosition Xor True
                        End If
                    Else
                        CheckMaxPosition = CheckMaxPosition Xor True
                    End If

                    If CheckMaxPosition = True Then
                        'AASEnergySpectrum.StopOnlineGraph(ArrlstGraphCurveItem(intCurveIndex))
                        'AASEnergySpectrum.DrawHighestPeakLine(ArrlstGraphCurveItem(intCurveIndex)
                        If intCurveIndex > -1 Then
                            'intIsSetMaximisePosition = MsgBox(" Set Maximise Position ", MsgBoxStyle.YesNo)
                            'If intIsSetMaximisePosition = MsgBoxResult.Yes Then
                            'CheckMaxPosition = CheckMaxPosition Xor True
                            'mnuPositionToMaxima.CheckType = NETXP.Controls.Bars.ButtonItemCheckType.Checkmark
                            'mnuPositionToMaxima.Checked = True
                            'draw heighest peak line
                            AASGraphUVSpectrum.DrawHighestPeakLine(ArrlstGraphCurveItem(intCurveIndex))
                            'AASEnergySpectrum.AldysPane.CurveList(0 ).Label 
                            dblMaximisePosition = ArrlstGraphCurveItem(intCurveIndex).HighPeakXValue()
                            'dblMaximisePosition = AASEnergySpectrum.AldysPane.CurveList(0).HighPeakXValue
                            If gobjCommProtocol.Wavelength_Position(dblMaximisePosition, lblWvPos) = True Then
                                Call gobjCommProtocol.mobjCommdll.subTime_Delay(100)
                                ''delay function
                            End If
                            lblWvPos.Text = mXValueLable & gobjInst.WavelengthCur
                            lblWvPos.Refresh()
                            'End If
                            'AASEnergySpectrum.DrawHighestPeakLine(ArrlstGraphCurveItem(intCurveIndex))
                            AASGraphUVSpectrum.ShowHighPeakLineLabel("Maximise Position", False, 0)
                            'show high peak label


                        End If
                    Else

                        'mnuPositionToMaxima.Checked = False
                        'rmove high peak label
                        AASGraphUVSpectrum.RemoveHighPeakLineLabel()
                        Dim i, CourveCount As Integer
                        'If AASEnergySpectrum.AldysPane.CurveList.Count > 0 Then
                        For i = 0 To AASGraphUVSpectrum.AldysPane.CurveList.Count - 1
                            'If AASEnergySpectrum.AldysPane.CurveList.Count > 0 Then
                            If AASGraphUVSpectrum.AldysPane.CurveList(i).IsHighPeakLine() = True Then
                                AASGraphUVSpectrum.AldysPane.CurveList.RemoveAt(i)
                            End If
                            'End If
                        Next
                        'End If
                        'AASEnergySpectrum.AldysPane.CurveList(0).IsHighPeakLine = False
                        AASGraphUVSpectrum.Refresh()
                        'CheckMaxPosition = False
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
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            mblnAvoidProcessing = False
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub mnuParameters_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : mnuParameters_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : 
        ' Description           : this is called when user click on mnu parameter
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 13.02.06
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Dim objfrmParameter As frmParameter
        ''obj to parameter form
        Try
            If mblnAvoidProcessing = True Then
                ''flag for avoid a process
                Exit Sub
            End If
            mblnAvoidProcessing = True

            objfrmParameter = New frmParameter(mobjParameters)
            ''mobjParameters is a object containg instrument current status
            If objfrmParameter.ShowDialog() = DialogResult.OK Then
                ''this will show the parameter dilog 
                If Not objfrmParameter.SpectrumParameter Is Nothing Then
                    If mobjParameters Is Nothing Then
                        ''if object is Null then intialise the object with UV spectrum parameter
                        mobjParameters = New Spectrum.UVSpectrumParameter
                    End If
                    mobjParameters.SpectrumName = objfrmParameter.SpectrumParameter.SpectrumName
                    mobjParameters.Comments = objfrmParameter.SpectrumParameter.Comments
                End If
            End If
            objfrmParameter.Close()
            Application.DoEvents()
            ''allow application to perfrom its panding work
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
            objfrmParameter.Dispose()
            ''destructor
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            mblnAvoidProcessing = False
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Sub

    'Private Sub mnuD2Peak_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    '    '=====================================================================
    '    ' Procedure Name        : mnuD2Peak_Click
    '    ' Parameters Passed     : Object,EventArgs
    '    ' Returns               : None
    '    ' Purpose               : 
    '    ' Description           : Set Maxisise position
    '    ' Assumptions           : 
    '    ' Dependencies          : 
    '    ' Author                : Sachin Dokhale
    '    ' Created               : 05.01.07
    '    ' Revisions             : 
    '    '=====================================================================
    '    Dim objWait As New CWaitCursor
    '    Dim objfrmD2PeakSearch As frmD2PeakSearch
    '    Try
    '        If mblnAvoidProcessing = True Then
    '            Exit Sub
    '        End If
    '        mblnAvoidProcessing = True
    '        objfrmD2PeakSearch = New frmD2PeakSearch
    '        If objfrmD2PeakSearch.ShowDialog = DialogResult.OK Then

    '        End If
    '        objfrmD2PeakSearch.Close()
    '        Call funcGetInstParameter()

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
    '        objfrmD2PeakSearch.Dispose()
    '        If Not objWait Is Nothing Then
    '            objWait.Dispose()
    '        End If
    '        mblnAvoidProcessing = False
    '        Application.DoEvents()
    '        '---------------------------------------------------------

    '    End Try
    'End Sub

    Private Sub AASGraphUVSpectrum_GraphScaleChanged(ByVal XMin As Double, ByVal XMax As Double, ByVal YMin As Double, ByVal YMax As Double)
        '=====================================================================
        ' Procedure Name        :   AASGraphUVSpectrum_GraphScaleChanged
        ' Description           :   Get Graph Scale
        ' Purpose               :   this will called when UV spectrum graph has been changed 
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
            mobjParameters.XaxisMax = XMax
            mobjParameters.XaxisMin = XMin
            mobjParameters.YaxisMax = YMax
            mobjParameters.YaxisMin = YMin

            ''above we are binding passed value to datastructure object

            If Not funcGraphPreRequisite(mobjParameters.Cal_Mode, _
                             mobjParameters.XaxisMin, _
                            mobjParameters.XaxisMax, _
                            mobjParameters.YaxisMin, _
                            mobjParameters.YaxisMax) Then

                ''reset the graph as par new parameter

                'Call gFuncShowMessage("Error in setting spectrum parameters", "Please Check Entered Spectrum Parameters", modConstants.EnumMessageType.Information)
                Exit Sub
                ''this is a statement for Exiting from function
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
    '    Dim objWait As New CWaitCursor
    '    Try
    '        RemoveHandler mnuIgnite.Click, AddressOf btnAutoIgnition_Click
    '        If mblnAvoidProcessing = True Then
    '            Exit Sub
    '        End If
    '        mblnAvoidProcessing = True
    '        Call gobjClsAAS203.funcIgnite(True)
    '        mblnAvoidProcessing = False
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
    '        AddHandler mnuIgnite.Click, AddressOf btnAutoIgnition_Click
    '        objWait.Dispose()
    '        Application.DoEvents()
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
    '    Dim objWait As New CWaitCursor
    '    Try
    '        RemoveHandler mnuExtinguish.Click, AddressOf btnExtinguish_Click
    '        If mblnAvoidProcessing = True Then
    '            Exit Sub
    '        End If
    '        mblnAvoidProcessing = True
    '        Call gobjClsAAS203.funcIgnite(False)
    '        mblnAvoidProcessing = False
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
    '        AddHandler mnuExtinguish.Click, AddressOf btnExtinguish_Click
    '        objWait.Dispose()
    '        Application.DoEvents()
    '        '---------------------------------------------------------
    '    End Try
    'End Sub

    Private Sub tlbbtnPrintGraph_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : tlbbtnPrintGraph_Click
        ' Parameters Passed     : Object, EventArgs
        ' Returns               : None
        ' Purpose               : this is printing a graph
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 17-May-2007 03:25 pm
        ' Revisions             : 1
        '=====================================================================



        Dim objWait As New CWaitCursor
        Dim objclsDataFileReport As New clsDataFileReport
        'Dim A1() As Double = {0, 0, 0, 0, 0, 0}

        Try
            '-----Added By Pankaj Fri 18 May 07
            'check for authentication
            If (gstructSettings.Enable21CFR = True) Then
                If Not funcCheckActivityAuthentication(enumActivityAuthentication.Print, gstructUserDetails.Access) Then
                    Return
                    Exit Sub
                End If
                gfuncInsertActivityLog(EnumModules.Print, "Print UVScanning Spectrum Mode Graph Accessed")
            End If

            objclsDataFileReport.DefaultFont = Me.DefaultFont()
            objclsDataFileReport.funcPrintUV(AASGraphUVSpectrum, mobjParameters, "")

            '------show print preview
            'If (toreported) Then 'OR NOT Method->RepReady )
            'gobjClsAAS203.SaveQuantResults(gobjNewMethod, A1, False)
            'toreported = False
            'AASGraphUVSpectrum.PrintPreViewGraph()

            'End If

            'if (gobjNewMethod.RepReady )
            '   OnReportPrint(gobjNewMethod)
            'end if

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
#End Region

#Region " Code for Enable and Disable"

    Private Function func_Enable_Disable(ByVal intProcess As Integer, ByVal intStart_End As Integer)
        '=====================================================================
        ' Procedure Name        : func_Enable_Disable
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : 
        ' Description           : for enable /disable the control as per current process..
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 14.02.07
        ' Revisions             : 
        '=====================================================================
        Try
            ''This functionenable/disable the control on the  UV screen as par current state of form
            ''for eg EnumProcesses.FormInitialize is a state of loading a form
            Select Case intProcess
                Case EnumProcesses.FormInitialize, EnumProcesses.EditSystemParamters
                    Select Case intStart_End
                        Case EnumStart_End.Start_of_Process

                            subAll_Menus_Enable()
                            ''function for enable all the menu

                            btnStart.Enabled = True
                            mnuStart.Enabled = True
                            tlbbtnStart.Enabled = True

                            btnBaseLine.Enabled = True
                            mnuBaseLine.Enabled = True
                            tlbbtnBaseLine.Enabled = True

                            btnClearSpectrum.Enabled = True
                            mnuClearSpectrum.Enabled = True
                            tlbbtnClearSpectrum.Enabled = True

                            btnReturn.Enabled = True
                            mnuExit.Enabled = True
                            tlbbtnReturn.Enabled = True

                            nudD2Cur.Enabled = True
                            nudPMT.Enabled = True
                            nudSlit.Enabled = True
                            cmbSpeed.Enabled = True

                            cmdChangeScale.Enabled = True
                            tlbbtnChangeScale.Enabled = True
                            mnuChangeScale.Enabled = True

                            If mintChannelIndex > -1 Then
                                mnuSaveSpectrumFile.Enabled = True
                                tlbbtnSaveSpectrumFile.Enabled = True

                                mnuPeakPick.Enabled = True
                                tlbbtnPeakPick.Enabled = True

                                mnuSmooth.Enabled = True
                                tlbbtnSmooth.Enabled = True

                                mnuAbsTransmission.Enabled = True
                                tlbbtnAbsToTransmission.Enabled = True
                            Else
                                mnuParameters.Enabled = False       'Saurabh      
                                tlbbtnParameters.Enabled = False

                                mnuSaveSpectrumFile.Enabled = False
                                tlbbtnSaveSpectrumFile.Enabled = False

                                mnuPeakPick.Enabled = False
                                tlbbtnPeakPick.Enabled = False

                                mnuSmooth.Enabled = False
                                tlbbtnSmooth.Enabled = False

                                mnuAbsTransmission.Enabled = False
                                tlbbtnAbsToTransmission.Enabled = False
                            End If

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

                            btnBaseLine.Enabled = False
                            mnuBaseLine.Enabled = False
                            tlbbtnBaseLine.Enabled = False

                            btnClearSpectrum.Enabled = False
                            mnuClearSpectrum.Enabled = False
                            tlbbtnClearSpectrum.Enabled = False

                            btnReturn.Enabled = False
                            mnuExit.Enabled = False
                            tlbbtnReturn.Enabled = False

                            'If m_blnBaseline = True Then
                            '    btnBaseLine.Text = "&Stop"
                            '    btnStart.Enabled = False
                            '    btnBaseLine.Enabled = True
                            'Else
                            '    btnStart.Text = "&Stop"
                            '    btnStart.Enabled = True
                            '    btnBaseLine.Enabled = False
                            'End If

                            btnStart.Enabled = False
                            mnuStart.Enabled = False
                            tlbbtnStart.Enabled = False

                            'btnBaseLine.Enabled = False 

                            'nudD2Cur.Enabled = False
                            'nudPMT.Enabled = False
                            'nudSlit.Enabled = False

                            cmbSpeed.Enabled = False
                            cmdChangeScale.Enabled = False
                            mnuChangeScale.Enabled = False
                            tlbbtnChangeScale.Enabled = False

                            mnuAbsTransmission.Enabled = False
                            tlbbtnAbsToTransmission.Enabled = False

                            mnuLoadSpectrumFile.Enabled = False
                            tlbbtnLoadspectrumFile.Enabled = False

                            mnuParameters.Enabled = False
                            tlbbtnParameters.Enabled = False

                            mnuPeakPick.Enabled = False
                            tlbbtnPeakPick.Enabled = False

                            mnuSaveSpectrumFile.Enabled = False
                            tlbbtnSaveSpectrumFile.Enabled = False

                            mnuSmooth.Enabled = False
                            tlbbtnSmooth.Enabled = False

                            'Added By Pankaj Bamb 21 MAy 07
                            mnuClearSpectrum.Enabled = False
                            tlbbtnClearSpectrum.Enabled = False

                            mnuChangeScale.Enabled = False
                            tlbbtnChangeScale.Enabled = False

                            'mnuBaseLine.Enabled = False
                            'mnuExit.Enabled = False
                            mnuPrintGraph.Enabled = False
                            tlbbtnPrintGraph.Enabled = False



                            'tlbbtnStart.Enabled = False
                            'tlbbtnBaseLine.Enabled = False
                            'tlbbtnParameters.Enabled = False
                            'tlbbtnLoadspectrumFile.Enabled = False
                            'tlbbtnAbsToTransmission.Enabled = False
                            'tlbbtnReturn.Enabled = False
                            'tlbbtnPrintGraph.Enabled = False
                            '----
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

                                btnBaseLine.Enabled = True
                                tlbbtnBaseLine.Enabled = True
                                mnuBaseLine.Enabled = True

                                btnClearSpectrum.Enabled = True
                                mnuClearSpectrum.Enabled = True
                                tlbbtnClearSpectrum.Enabled = True

                                btnReturn.Enabled = True
                                mnuExit.Enabled = True
                                tlbbtnReturn.Enabled = True

                                'Added By Pankaj Bamb 21 MAy 07
                                cmdChangeScale.Enabled = True
                                tlbbtnChangeScale.Enabled = True
                                mnuChangeScale.Enabled = True

                                mnuStart.Enabled = True
                                tlbbtnStart.Enabled = True
                                btnStart.Enabled = True

                                mnuPrintGraph.Enabled = True
                                tlbbtnPrintGraph.Enabled = True

                                'tlbbtnParameters.Enabled = True            'Saurabh
                                tlbbtnLoadspectrumFile.Enabled = True
                                mnuLoadSpectrumFile.Enabled = True
                                'tlbbtnAbsToTransmission.Enabled = True     'Saurabh
                                '----
                                'btnStart.Text = "&Stop"
                                'mnuStart.Enabled = True
                                'tlbbtnStart.Enabled = True

                                nudD2Cur.Enabled = True
                                nudPMT.Enabled = True
                                nudSlit.Enabled = True
                                cmbSpeed.Enabled = True
                                'cmdChangeScale.Enabled = True

                                If mintChannelIndex > -1 Then
                                    mnuParameters.Enabled = True
                                    tlbbtnParameters.Enabled = True

                                    mnuSaveSpectrumFile.Enabled = True
                                    tlbbtnSaveSpectrumFile.Enabled = True

                                    mnuPeakPick.Enabled = True
                                    tlbbtnPeakPick.Enabled = True

                                    mnuAbsTransmission.Enabled = True
                                    tlbbtnAbsToTransmission.Enabled = True

                                    mnuSmooth.Enabled = True
                                    tlbbtnSmooth.Enabled = True
                                Else
                                    mnuParameters.Enabled = False
                                    tlbbtnParameters.Enabled = False

                                    mnuSaveSpectrumFile.Enabled = False
                                    tlbbtnSaveSpectrumFile.Enabled = False

                                    mnuPeakPick.Enabled = False
                                    tlbbtnPeakPick.Enabled = False

                                    mnuAbsTransmission.Enabled = False
                                    tlbbtnAbsToTransmission.Enabled = False

                                    mnuSmooth.Enabled = False
                                    tlbbtnSmooth.Enabled = False
                                End If
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
                            mnuDataProcessing.Enabled = False
                            'mnuManipulate.Enabled = False

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
                            mnuDataProcessing.Enabled = True
                            'mnuManipulate.Enabled = True
                            'NumUpDwn.Enabled = True
                            'btnNumUpDwn_Dwn.Enabled = True
                            'btnNumUpDwn_Up.Enabled = True
                            'tlbrSpectrum.Buttons.Item(EnumToolBarButtons.Print).ImageIndex = EnumToolBarImages.PrintEnabled

                    End Select
                Case EnumProcesses.LoadChannel
                    Select Case intStart_End
                        Case EnumStart_End.Start_of_Process
                            If mintChannelIndex > -1 Then
                                mnuParameters.Enabled = True
                                tlbbtnParameters.Enabled = True

                                mnuSaveSpectrumFile.Enabled = True
                                tlbbtnSaveSpectrumFile.Enabled = True

                                mnuPeakPick.Enabled = True
                                tlbbtnPeakPick.Enabled = True

                                mnuAbsTransmission.Enabled = True
                                tlbbtnAbsToTransmission.Enabled = True

                                mnuSmooth.Enabled = True
                                tlbbtnSmooth.Enabled = True
                            Else
                                mnuParameters.Enabled = False
                                tlbbtnParameters.Enabled = False

                                mnuSaveSpectrumFile.Enabled = False
                                tlbbtnSaveSpectrumFile.Enabled = False

                                mnuPeakPick.Enabled = False
                                tlbbtnPeakPick.Enabled = False

                                mnuAbsTransmission.Enabled = False
                                tlbbtnAbsToTransmission.Enabled = False

                                mnuSmooth.Enabled = False
                                tlbbtnSmooth.Enabled = False
                            End If
                        Case Else
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

    Private Function func_Enable_DisableControl(ByVal blnEnabled As Boolean) As Boolean

        '=====================================================================
        ' Procedure Name        :   func_Enable_Disable
        ' Description           :   
        ' Purpose               :   
        ' Parameters Passed     :   blnEnaDisable
        ' Returns               :   True if success
        ' Parameters Affected   :   
        ' Assumptions           :   
        ' Dependencies          :   None.
        ' Author                :   Sachin Dokhale
        ' Created               :   04.05.07
        ' Revisions             :
        '=====================================================================
        Try
            'If blnEnabled = False Then
            '    'RemoveHandler nudFuelRatio.ValueEditorClick, AddressOf nudFuelRatio_ValueEditorClick
            '    'RemoveHandler nudFuelRatio.ValueEditorValueChanged, AddressOf nudFuelRatio_ValueChanged
            '    nudFuelRatio.Enabled = False
            '    'AddHandler nudBurnerHeight.ValueChanged, AddressOf nudBurnerHeight_ValueChanged
            '    'RemoveHandler nudBurnerHeight.ValueEditorClick, AddressOf nudBurnerHeight_ValueEditorClick
            '    'RemoveHandler nudBurnerHeight.ValueEditorValueChanged, AddressOf nudBurnerHeight_ValueChanged
            '    nudBurnerHeight.Enabled = False

            '    'AddHandler nudD2Cur.ValueChanged, AddressOf nudD2Cur_ValueChanged
            '    'RemoveHandler nudD2Cur.ValueEditorClick, AddressOf nudD2Cur_ValueEditorClick
            '    'RemoveHandler nudD2Cur.ValueEditorValueChanged, AddressOf nudD2Cur_ValueChanged
            '    nudD2Cur.Enabled = False
            '    'AddHandler nudHCLCur.ValueChanged, AddressOf nudHCLCur_ValueChanged
            '    'RemoveHandler nudHCLCur.ValueEditorClick, AddressOf nudHCLCur_ValueEditorClick
            '    'RemoveHandler nudHCLCur.ValueEditorValueChanged, AddressOf nudHCLCur_ValueChanged
            '    nudHCLCur.Enabled = False
            '    'AddHandler nudSlit.ValueChanged, AddressOf nudSlit_ValueChanged
            '    'RemoveHandler nudSlit.ValueEditorClick, AddressOf nudSlit_ValueEditorClick
            '    'RemoveHandler nudSlit.ValueEditorValueChanged, AddressOf nudSlit_ValueChanged
            '    nudSlit.Enabled = False
            '    'RemoveHandler nudSlit_Ref.ValueEditorClick, AddressOf nudSlit_Ref_ValueEditorClick
            '    'RemoveHandler nudSlit_Ref.ValueEditorValueChanged, AddressOf nudSlit_Ref_ValueChanged
            '    nudSlit_Ref.Enabled = False
            '    'AddHandler nudPMT.ValueChanged, AddressOf nudPMT_ValueChanged
            '    'RemoveHandler nudPMT.ValueEditorClick, AddressOf nudPMT_ValueEditorClick
            '    'RemoveHandler nudPMT.ValueEditorValueChanged, AddressOf nudPMT_ValueChanged
            '    nudPMT.Enabled = False
            '    'RemoveHandler nudPMT_Ref.ValueEditorClick, AddressOf nudPMT_Ref_ValueEditorClick
            '    'RemoveHandler nudPMT_Ref.ValueEditorValueChanged, AddressOf nudPMT_Ref_ValueChanged
            '    nudPMT_Ref.Enabled = False
            'Else
            '    'AddHandler nudFuelRatio.ValueEditorClick, AddressOf nudFuelRatio_ValueEditorClick
            '    'AddHandler nudFuelRatio.ValueEditorValueChanged, AddressOf nudFuelRatio_ValueChanged

            '    'AddHandler nudBurnerHeight.ValueChanged, AddressOf nudBurnerHeight_ValueChanged
            '    AddHandler nudBurnerHeight.ValueEditorClick, AddressOf nudBurnerHeight_ValueEditorClick
            '    AddHandler nudBurnerHeight.ValueEditorValueChanged, AddressOf nudBurnerHeight_ValueChanged

            '    'AddHandler nudD2Cur.ValueChanged, AddressOf nudD2Cur_ValueChanged
            '    AddHandler nudD2Cur.ValueEditorClick, AddressOf nudD2Cur_ValueEditorClick
            '    AddHandler nudD2Cur.ValueEditorValueChanged, AddressOf nudD2Cur_ValueChanged

            '    'AddHandler nudHCLCur.ValueChanged, AddressOf nudHCLCur_ValueChanged
            '    AddHandler nudHCLCur.ValueEditorClick, AddressOf nudHCLCur_ValueEditorClick
            '    AddHandler nudHCLCur.ValueEditorValueChanged, AddressOf nudHCLCur_ValueChanged

            '    'AddHandler nudSlit.ValueChanged, AddressOf nudSlit_ValueChanged
            '    AddHandler nudSlit.ValueEditorClick, AddressOf nudSlit_ValueEditorClick
            '    AddHandler nudSlit.ValueEditorValueChanged, AddressOf nudSlit_ValueChanged
            '    AddHandler nudSlit_Ref.ValueEditorClick, AddressOf nudSlit_Ref_ValueEditorClick
            '    AddHandler nudSlit_Ref.ValueEditorValueChanged, AddressOf nudSlit_Ref_ValueChanged

            '    'AddHandler nudPMT.ValueChanged, AddressOf nudPMT_ValueChanged
            '    AddHandler nudPMT.ValueEditorClick, AddressOf nudPMT_ValueEditorClick
            '    AddHandler nudPMT.ValueEditorValueChanged, AddressOf nudPMT_ValueChanged
            '    AddHandler nudPMT_Ref.ValueEditorClick, AddressOf nudPMT_Ref_ValueEditorClick
            '    AddHandler nudPMT_Ref.ValueEditorValueChanged, AddressOf nudPMT_Ref_ValueChanged
            'End If


            nudD2Cur.Enabled = blnEnabled

            nudSlit.Enabled = blnEnabled

            nudPMT.Enabled = blnEnabled
            Return True
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            Return False
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
    End Function

    Private Sub subAll_Menus_Enable()
        '=====================================================================
        ' Procedure Name        :   subAll_Menus_Enable
        ' Description           :   for enable all the menu.
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
        ' Procedure Name        :   subAll_Menus_Disable
        ' Description           :   for disable all the menu.
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

#Region " Private Functions"

    Private Function funcInitialise()
        '=====================================================================
        ' Procedure Name        : funcInitialise
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : this is called when UV spectrum form is load
        ' Description           : Initialise the form Object
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 21.11.06
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Try
            func_Enable_Disable(EnumProcesses.StartScan, EnumStart_End.Start_of_Process) 'Added By Pankaj 01 June 07
            ''function for enable/disable a control 
            nudD2Cur.Visible = True
            nudPMT.Visible = True
            nudSlit.Visible = True
            cmbSpeed.Visible = True
            cmbModes.Visible = True
            'Saruabh 08.08.07
            If Not gstructSettings.ExeToRun = EnumApplicationMode.ServiceUtility Then
                ''check the mode of application
                If Not IsNothing(gobjMain) Then
                    If gobjMain.mobjController.IsThreadRunning = True Then
                        ''check if any thread is running if yes then stop thet thread
                        gobjMain.mobjController.Cancel()
                        gobjCommProtocol.mobjCommdll.subTime_Delay(500)   '10.12.07
                        Application.DoEvents()
                    End If
                End If
            End If
            'Saruabh 08.08.07
            'gobjfrmStatus.Visible = False
            Me.BringToFront()
            Application.DoEvents()

            If gobjInst.Mode > -1 Then
                '//----- Added by Sachin Dokhale. Get the init. calibration mode.
                m_bytCalibMode = gobjInst.Mode
                cmbModes.SelectedIndex = gobjInst.Mode
            End If

            '//---- for Uv Spectrum Reading
            gblnUVS = True
            '//--- Start for UV abs 
            gblnUVABS = True
            '//-----
            '//----- Set the D2 Energy as default mode for UV Spectrum
            Call funcSetDefaultSpectrumParameter(EnumCalibrationMode.D2E)
            ''function for setting some default spectrum parameter as par passed mode

            'Call funcSetDefaultSpectrumParameter(cmbModes.SelectedIndex)
            gobjClsAAS203.Calculate_Analysis_Graph_Param(AASGraphUVSpectrum, ClsAAS203.enumChangeAxis.xyAxis)
            Application.DoEvents()

            Call funcSetDefaultParameter()
            ''for setting default parameter

            Call gobjMessageAdapter.ShowMessage(constBurerCuvette)
            ''shows the burner cuvette message
            Application.DoEvents()
            '//----- Set wavelength default
            '//----- Display Current Wavelength
            'Application.DoEvents()
            Dim dblCurrWv As Double
            If gobjCommProtocol.funcGet_Current_Wv(dblCurrWv) = True Then
                'Description            :   To get the current wavelength
                'Parameters             :   [OUT]dblCurWv : returns current wavelength in this variable

                lblWvPos.Text = mXValueLable & dblCurrWv.ToString
                lblWvPos.Refresh()
                lblYValue.Text = mYValueLable & "0.0"
                lblYValue.Refresh()
            Else
                'mobjThreadController.Display("Error" & "|" & "0.0")
                lblWvPos.Text = mXValueLable
                lblWvPos.Refresh()
                lblYValue.Text = mYValueLable
                lblYValue.Refresh()
            End If
            '//----------------

            gobjCommProtocol.Wavelength_Position(mobjParameters.XaxisMin, lblWvPos)
            ''To position the wavelength as par mobjParameters.XaxisMin


            gobjCommProtocol.mobjCommdll.subTime_Delay(100)
            ''for delay of 100

            Call AddHandlers()
            ''add all the event 


            '//-----
            'gblnSpectrumTerminated = False
            'gblnSpectrumWait = False
            func_Enable_Disable(EnumProcesses.StartScan, EnumStart_End.End_of_Process)  'Added By Pankaj 01 June 07
            func_Enable_Disable(EnumProcesses.FormInitialize, EnumStart_End.Start_of_Process)
            ''function for enable/disble the control as par current process

            Me.Refresh()

            ''for refresh the form


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
            Application.DoEvents()
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
            AddHandler mnuLoadSpectrumFile.Click, AddressOf mnuLoadSpectrumFile_Click
            ''for eg when we click on loadspectrumfile ,mnuLoadSpectrumFile_Click function is called



            AddHandler mnuSaveSpectrumFile.Click, AddressOf mnuSaveSpectrumFile_Click
            'AddHandler cmbModes.SelectedIndexChanged, AddressOf cmbModes_SelectedIndexChanged
            AddHandler mnuExit.Click, AddressOf mnuExit_Click
            AddHandler btnReturn.Click, AddressOf mnuExit_Click
            ''add a handler to button click event

            AddHandler mnuStart.Click, AddressOf btnStart_Click '--Added By Pankaj 22 May 07
            AddHandler btnStart.Click, AddressOf btnStart_Click
            AddHandler btnBaseLine.Click, AddressOf btnBaseLine_Click
            '' baseline step1 this will add a handler for baseline event
            AddHandler mnuBaseLine.Click, AddressOf btnBaseLine_Click '--Added By Pankaj 22 May 07
            AddHandler btnClearSpectrum.Click, AddressOf btnClearSpectrum_Click
            ''This will add a handler to clearspectrum function

            AddHandler mnuClearSpectrum.Click, AddressOf btnClearSpectrum_Click '--Added By Pankaj 22 May 07




            AddHandler mnuPeakPick.Click, AddressOf mnuPeakPick_Click
            'AddHandler nudD2Cur.ValueChanged, AddressOf nudD2Cur_ValueChanged
            AddHandler nudD2Cur.ValueEditorClick, AddressOf nudD2Cur_ValueEditorClick
            AddHandler nudD2Cur.ValueEditorValueChanged, AddressOf nudD2Cur_ValueChanged


            'AddHandler nudSlit.ValueChanged, AddressOf nudSlit_ValueChanged
            AddHandler nudSlit.ValueEditorClick, AddressOf nudSlit_ValueEditorClick
            AddHandler nudSlit.ValueEditorValueChanged, AddressOf nudSlit_ValueChanged

            'AddHandler nudPMT.ValueChanged, AddressOf nudPMT_ValueChanged
            AddHandler nudPMT.ValueEditorClick, AddressOf nudPMT_ValueEditorClick
            AddHandler nudPMT.ValueEditorValueChanged, AddressOf nudPMT_ValueChanged


            AddHandler cmbSpeed.SelectedIndexChanged, AddressOf cmbSpeed_SelectedIndexChanged
            AddHandler cmdChangeScale.Click, AddressOf cmdChangeScale_Click
            AddHandler mnuChangeScale.Click, AddressOf cmdChangeScale_Click
            AddHandler mnuAbsTransmission.Click, AddressOf mnuAbsTransmission_Click
            AddHandler mnuSmooth.Click, AddressOf mnuSmoothGraph_Click
            AddHandler cmbModes.SelectedIndexChanged, AddressOf cmbModes_SelectedIndexChanged

            AddHandler mnuParameters.Click, AddressOf mnuParameters_Click
            AddHandler AASGraphUVSpectrum.GraphScaleChanged, AddressOf AASGraphUVSpectrum_GraphScaleChanged
            'AddHandler mnuD2Peak.Click, AddressOf mnuD2Peak_Click

            AddHandler tlbbtnReturn.Click, AddressOf mnuExit_Click
            AddHandler tlbbtnStart.Click, AddressOf btnStart_Click
            ''start step 1:- this will add a handler to a function, which handles a start button event

            AddHandler tlbbtnBaseLine.Click, AddressOf btnBaseLine_Click
            AddHandler tlbbtnClearSpectrum.Click, AddressOf btnClearSpectrum_Click
            AddHandler tlbbtnChangeScale.Click, AddressOf cmdChangeScale_Click
            AddHandler tlbbtnLoadspectrumFile.Click, AddressOf mnuLoadSpectrumFile_Click
            AddHandler tlbbtnSaveSpectrumFile.Click, AddressOf mnuSaveSpectrumFile_Click
            AddHandler tlbbtnSmooth.Click, AddressOf mnuSmoothGraph_Click
            AddHandler tlbbtnPeakPick.Click, AddressOf mnuPeakPick_Click 'Added by Pankaj on 06 Sup 07 
            AddHandler tlbbtnAbsToTransmission.Click, AddressOf mnuAbsTransmission_Click
            AddHandler tlbbtnParameters.Click, AddressOf mnuParameters_Click
            'AddHandler mnuIgnite.Click, AddressOf btnAutoIgnition_Click
            'AddHandler mnuIgnite.Click, AddressOf btnIgnite_Click

            'AddHandler mnuExtinguish.Click, AddressOf btnExtinguish_Click

            AddHandler mnuPeakEdit.Click, AddressOf mnuPeakEdit_Click
            AddHandler mnuGrid.Click, AddressOf mnuGrid_Click
            AddHandler mnuShowXYValues.Click, AddressOf mnuShowXYValues_Click
            AddHandler mnuLegends.Click, AddressOf mnuLegends_Click
            'AddHandler mnuPrintPreview.Click, AddressOf mnuPrintPreview_Click
            'AddHandler mnuScale.Click, AddressOf cmdChangeScale_Click

            'Tlbbtn for Graph Options
            AddHandler tlbbtnPeakEdit.Click, AddressOf mnuPeakEdit_Click
            AddHandler tlbbtnGrid.Click, AddressOf mnuGrid_Click
            AddHandler tlbbtnShowXYValues.Click, AddressOf mnuShowXYValues_Click
            AddHandler tlbbtnLegends.Click, AddressOf mnuLegends_Click


            AddHandler mnuPrintGraph.Click, AddressOf tlbbtnPrintGraph_Click
            AddHandler tlbbtnPrintGraph.Click, AddressOf tlbbtnPrintGraph_Click
            AddHandler btnDelete.Click, AddressOf btnDelete_Click
            AddHandler btnR.Click, AddressOf btnR_Click

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
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub subStartScan()
        '=====================================================================
        ' Procedure Name        : subStartScan
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : this is called for starting a scanning
        ' Description           : start step3
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 07.10.06
        ' Revisions             : 
        '=====================================================================
        'Dim objWait As New CWaitCursor
        Try
            ''mblnAvoidProcessing is a bool flag 
            If mblnAvoidProcessing = True Then
                Exit Sub
            End If
            ''gblnBaseLine is a bool flag , which is check for baseline.

            If gblnBaseLine = False Then
                ''if gblnBaseLine  flase then
                gobjMessageAdapter.ShowMessage(constPerformBaseLine)
                ''prompt a msg for perfroming baseline ..
                Application.DoEvents()
                Exit Sub
            End If
            ''if gblnBaseLine  true then go ahead

            If gobjMessageAdapter.ShowMessage(constStartScan, True) = False Then
                ''this show a baseline message
                Application.DoEvents()
                Exit Sub
            End If
            m_blnBaseline = False



            Call func_Enable_Disable(EnumProcesses.StartScan, EnumStart_End.Start_of_Process)
            Call func_Enable_DisableControl(False)
            ''this will enable/disable the control
            'Display graph
            ''check for spectrum cond
            If mobjChannnels.Count > 0 Then

                funcDisplayGraph(mobjChannnels(mintChannelIndex))
                ''this is a function for displaying a point on spectrum
            End If
            ''below are the some  cond for spectrum
            Me.AASGraphUVSpectrum.btnPeakEdit.Checked = True
            Me.AASGraphUVSpectrum.btnShowXYValues.Checked = False
            Me.mnuShowXYValues.Enabled = False
            Me.tlbbtnShowXYValues.Enabled = False
            Me.mnuPeakEdit.Enabled = False
            Me.tlbbtnPeakEdit.Enabled = False
            If Me.AASGraphUVSpectrum.getCurveListCount > 0 Then 'Added by Pankaj on 27 Aug 07
                Me.AASGraphUVSpectrum.submnuPeakEdit_Click(btnStart, System.EventArgs.Empty)
            End If
            If funcOnSpect(False, lblWvPos, lblYValue) = False Then

                ''this will enable/disable a control
                func_Enable_Disable(EnumProcesses.StartScan, EnumStart_End.End_of_Process)
                Call func_Enable_DisableControl(True)
                Exit Sub
            End If
            btnStart.Text = "&Stop"
            tlbbtnStart.Text = "&Stop"
            mnuStart.Text = "&Stop"
            btnStart.Image = Image.FromFile(Application.StartupPath & "\Images\cancel_1.ico")
            mnuStart.Image = Image.FromFile(Application.StartupPath & "\Images\cancel_1.ico")
            tlbbtnStart.Image = Image.FromFile(Application.StartupPath & "\Images\cancel_1.ico")
            Me.AASGraphUVSpectrum.btnShowXYValues.Enabled = False
            Me.AASGraphUVSpectrum.btnPeakEdit.Enabled = False

            btnStart.Enabled = True
            mnuStart.Enabled = True
            tlbbtnStart.Enabled = True

            btnBaseLine.Enabled = False
            mnuBaseLine.Enabled = False
            tlbbtnBaseLine.Enabled = False
            btnStart.Refresh()
            btnBaseLine.Refresh()

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

    Private Sub subStartBaseline()
        '=====================================================================
        ' Procedure Name        : subStartBaseline
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : to perfrom baseline
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 07.10.06
        ' Revisions             : 
        '=====================================================================
        'Dim objWait As New CWaitCursor
        ''note:
        ''this will start a baseline routine.

        Try

            If mblnAvoidProcessing = True Then
                ''for avoiding a process
                Exit Sub
            End If

            If gobjMessageAdapter.ShowMessage(constStartRef, True) = False Then
                Application.DoEvents()
                Exit Sub
            End If

            If gblnBaseLine = True Then
                ''check a baseline flag
                Exit Sub
            End If


            m_blnBaseline = True

            Call func_Enable_Disable(EnumProcesses.StartScan, EnumStart_End.Start_of_Process)
            Call func_Enable_DisableControl(False)

            'MenuBarUV.Enabled = False '---27.12.10 added by Deepak 


            tlbbtnBaseLine.Enabled = False '---24.01.11
            btnBaseLine.Enabled = False '---24.01.11

            ''enable/disable the control as per cond
            If (gobjInst.D2Pmt = 0) Then
                ''check for D2pmt
                Call gobjClsAAS203.funcAdj_D2Gain(True)
                ''this will called for adjusting a D2pmt
                gobjCommProtocol.Wavelength_Position(mobjParameters.XaxisMin)
                ''this is a communication function for position the wavelength  
                ''as par a min Xaxis value on spectrum parameter .
            End If
            Me.AASGraphUVSpectrum.btnPeakEdit.Checked = True
            Me.AASGraphUVSpectrum.btnShowXYValues.Checked = False
            Me.mnuShowXYValues.Enabled = False
            Me.tlbbtnShowXYValues.Enabled = False
            Me.mnuPeakEdit.Enabled = False
            Me.tlbbtnPeakEdit.Enabled = False
            If Me.AASGraphUVSpectrum.getCurveListCount > 0 Then 'Added by Pankaj on 27 Aug 07
                Me.AASGraphUVSpectrum.submnuPeakEdit_Click(btnStart, System.EventArgs.Empty)
            End If

            tlbbtnBaseLine.Enabled = True  '---24.01.11
            btnBaseLine.Enabled = True  '---24.01.11

            If funcOnSpect(True, lblWvPos, lblYValue) = False Then
                ''here pass true for baseline completed 
                ''this is a bool function for starting a UV spectrum
                func_Enable_Disable(EnumProcesses.StartScan, EnumStart_End.End_of_Process)
                Call func_Enable_DisableControl(True)
                Exit Sub
            End If
            btnBaseLine.Text = "&Stop"
            btnBaseLine.Image = Image.FromFile(Application.StartupPath & "\Images\cancel_1.ico")
            tlbbtnBaseLine.Text = "&Stop"
            tlbbtnBaseLine.Image = Image.FromFile(Application.StartupPath & "\Images\cancel_1.ico")
            mnuBaseLine.Text = "&Stop"
            mnuBaseLine.Image = Image.FromFile(Application.StartupPath & "\Images\cancel_1.ico")
            btnStart.Enabled = False
            mnuStart.Enabled = False
            tlbbtnStart.Enabled = False
            btnBaseLine.Enabled = True
            tlbbtnBaseLine.Enabled = True
            mnuBaseLine.Enabled = True
            Me.AASGraphUVSpectrum.btnShowXYValues.Enabled = False
            Me.AASGraphUVSpectrum.btnPeakEdit.Enabled = False

            btnStart.Refresh()
            btnBaseLine.Refresh()
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
            'MenuBarUV.Enabled = True  '---27.12.10 added by Deepak 
            'If Not objWait Is Nothing Then
            '    objWait.Dispose()
            'End If
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub subStopScan()
        '=====================================================================
        ' Procedure Name        : subStopScan
        ' Parameters Passed     : 
        ' Returns               : None
        ' Purpose               : this is called for stoping a spectrum
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
            ''note:
            ''set a flag for stoping a spectrum
            ''this flag directed to Spectrumthread
            ''and stop the thread



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
        ' Description           :this is called for clearing a spectrum 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 07.10.06
        ' Revisions             : 
        '=====================================================================
        'Dim objWait As New CWaitCursor
        Try

            If mblnAvoidProcessing = True Then
                ''for avoiding the process
                Exit Sub
            End If

            If mintChannelIndex > -1 Then
                If mobjChannnels.Count > 0 Then
                    If blnYetFileNotSave = True Then
                        ''this is flag that show whatever file is saved or not
                        ''if not then ask for save option

                        If gobjMessageAdapter.ShowMessage(constFileNotSaved) = True Then
                            Application.DoEvents()
                            ''prompt a message for saving a spectrum
                            ''and call a function for saving a spectrum on a disk
                            Call funcSaveSpectrumFile()
                        End If
                    End If
                    mintChannelIndex = -1

                    mobjChannnels.Clear()
                    ''clear the channel data structure
                    If ArrlstGraphCurveItem.Count >= intCurveIndex + 1 Then
                        'ArrlstGraphCurveItem.RemoveAt(intCurveIndex)
                        ArrlstGraphCurveItem.Clear()
                        'clear the array
                        intCurveIndex = -1
                    End If
                End If
            End If

            blnYetFileNotSave = False
            funcClearGraph()
            ''for clearing a graph
            Call func_Enable_Disable(EnumProcesses.EditSystemParamters, EnumStart_End.Start_of_Process)
            ''function for enable/disable the control

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

    Private Sub subSmoothGraph()
        '=====================================================================
        ' Procedure Name        : subSmoothGraph
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : this is a function for smooth graph
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 16.10.06
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        ''
        Try
            Dim chanel0 As Channel
            ''make a object of datastructure for storing a temp value

            If mblnAvoidProcessing = True Then
                ''set flag for avoiding a process
                Exit Sub
            End If
            If mintChannelIndex > -1 Then
                chanel0 = mobjSpectrum.funcCloneUVSChannel(mobjChannnels(mintChannelIndex))
                ''get a clone copy of UV parameter in to a temp obj chanel0

                If Not (chanel0) Is Nothing Then
                    ''check for not null
                    mobjSpectrum.funcSmooth1(chanel0, 0)
                    ''called for smooth graph hera pass tmpe object holding data and
                    ''perfrom smooth function on that
                    mobjChannnels(mintChannelIndex) = mobjSpectrum.funcCloneUVSChannel(chanel0)
                    ''now bind current smooth object to real object
                    funcClearGraph()
                    ''for clearing a graph
                    funcDisplayGraph(mobjChannnels.item(mintChannelIndex))
                    ''for displaying a graph with smooth value
                    funcGraphPreRequisite(mobjParameters.Cal_Mode, _
                                            mobjParameters.XaxisMin, _
                                            mobjParameters.XaxisMax, _
                                            mobjParameters.YaxisMin, _
                                            mobjParameters.YaxisMax)
                    ''set the UV spectrum graph as par current parameter
                End If
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
        ' Purpose               : for finding a peakvally on a spectrum
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 14.12.06
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Dim objDataTable As New DataTable
        Dim objPeakVallyChannel As Channel
        ''temp object for data structure
        Dim intCounter As Integer = 0
        Dim lngPeakValleyCounts As Long
        Dim intShowdialog As Integer
        Dim objclsDataFileReport As New clsDataFileReport
        ''object for reportoption
        Try

            If mblnAvoidProcessing = True Then
                ''flag for avoiding current process
                Exit Sub
            End If
            mblnAvoidProcessing = True

            If mintChannelIndex > -1 Then
                ''check for data structure index
                If Not (mobjChannnels.item(mintChannelIndex) Is Nothing) Then
                    If mobjSpectrum.funcPeaks(mobjChannnels.item(mintChannelIndex), mStuctPeaksValley) = False Then
                        ''this is a function for finding peakvally
                        ''parameter are temp object to data structoe hold spectrum data
                        ''and structure of peakvally for holding a result

                        ''if this function get not succeed then show error msg
                        gobjMessageAdapter.ShowMessage(constErrorPopulatingPeakValleyData)
                        Application.DoEvents()
                        ''now allow application to perfrom its panding work
                        'MsgBox("Error in Peak Valley Methods", MsgBoxStyle.Critical)
                    End If
                Else
                    Exit Sub
                End If
                '--- Check for Peak-Valley points

                lngPeakValleyCounts = mobjSpectrum.PeakValleyCount
                ''get total number of peak count from peak vally structure
                If lngPeakValleyCounts <= 0 Then
                    ''if there is no peak count then show peak not found message
                    gobjMessageAdapter.ShowMessage(constNOPeakORValley)
                    Application.DoEvents()
                    'gFuncShowMessage("Peak Pick", "No Peaks Or Valleys detected.", EnumMessageType.Information)
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

                '//----- Ini channel object for UV Spectrum 
                objPeakVallyChannel = mobjChannnels.item(mintChannelIndex)

                ''now get a data in temp data structure object

                If Not mobjSpectrum.funcGetDataPeakPickResults(objDataTable, mStuctPeaksValley, lngPeakValleyCounts, objPeakVallyChannel) Then
                    ''get a data from peak vally data structure to a datatable
                    gobjMessageAdapter.ShowMessage(constErrorPopulatingPeakValleyData)
                    Application.DoEvents()
                    'gFuncShowMessage("Error...", "Error in populating the peak valley data in the data table to display on the screen.", EnumMessageType.Information)
                End If

                Dim frmPeakPick As New frmPeakPicks
                ''now we have to show that result on screen 
                ''make a object of form peak
                Call frmPeakPick.funcDisplayPicPeakResults(objDataTable)
                ''now display a peakresult from peak datatable to on screen
                intShowdialog = frmPeakPick.ShowDialog()
                ''shows that peak dialog

                If intShowdialog = DialogResult.Yes Then
                    ''for data report
                    objclsDataFileReport.DefaultFont = Me.DefaultFont()
                    objclsDataFileReport.funcPeakValleyPrintUV(AASGraphUVSpectrum, objDataTable, mobjParameters, "")
                End If
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
                frmPeakPick.Close()
                ''close the form
                frmPeakPick.Dispose()
                ''destructor
            End If
            objPeakVallyChannel = Nothing
            objDataTable = Nothing
            'Call subClearScan()

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
            mblnAvoidProcessing = False
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub subSetScanParameter()
        '=====================================================================
        ' Procedure Name        : subSetScanParameter
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : for setting a scan parameter
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 14.12.06
        ' Revisions             : praveen
        '=====================================================================
        Dim objWait As New CWaitCursor
        Dim objfrmSampleParameter As New frmParameter
        ''object to parameter form
        Try
            If mblnAvoidProcessing = True Then
                ''flag for avoiding process
                Exit Sub
            End If
            mblnAvoidProcessing = True

            If objfrmSampleParameter.ShowDialog = DialogResult.OK Then
                ''accept the new parameter from user through parameter form
                ''bind them, with mobjParameters object
                mobjParameters.SpectrumName = objfrmSampleParameter.SpectrumParameter.SpectrumName
                mobjParameters.Comments = objfrmSampleParameter.SpectrumParameter.Comments
            End If

            objfrmSampleParameter.Close()
            ''close the form
            Application.DoEvents()
            ''allow application to perfrom its panding work

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
            mblnAvoidProcessing = False

            If Not objfrmSampleParameter Is Nothing Then
                objfrmSampleParameter.Dispose()
            End If

            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            '---------------------------------------------------------
        End Try
    End Sub

    Private Function funcSetDefaultSpectrumParameter(ByVal intCalibrationMode As Integer) As Boolean
        '=====================================================================
        ' Procedure Name        : funcSetDefaultSpectrumParameter
        ' Parameters Passed     : current mode of operation
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

            If gobjCommProtocol.funcCalibrationMode(EnumCalibrationMode.D2E) Then
                ''if calibration mode is D2E then 

                'addataSpect.dblWvMin = 230.0
                'addataSpect.dblWvMax = 250.0
                'mobjParameters.XaxisMin = 190
                'mobjParameters.XaxisMax = 400

                mobjParameters.XaxisMin = 190
                mobjParameters.XaxisMax = 220


                Select Case gobjInst.Mode
                    ''now check for another mode
                Case EnumCalibrationMode.AA, EnumCalibrationMode.AABGC, EnumCalibrationMode.MABS, EnumCalibrationMode.D2E
                        'addataSpect.dblYmin = const_YMinAbs
                        'addataSpect.dblYMax = const_YMaxAbs
                        mobjParameters.YaxisMax = const_YMaxAbs
                        mobjParameters.YaxisMin = const_YMinAbs
                        mYValueLable = const_Absorbance
                    Case EnumCalibrationMode.D2E
                        mobjParameters.YaxisMax = const_YMaxAbs
                        mobjParameters.YaxisMin = const_YMinAbs
                        If gblnUVABS = True Then
                            mYValueLable = const_Absorbance
                        Else
                            mYValueLable = const_Transmission
                        End If

                    Case EnumCalibrationMode.HCLE

                        'mobjParameters.YaxisMin = const_YMinEnergy
                        'mobjParameters.YaxisMax = const_YMaxEnergy
                        mobjParameters.YaxisMin = const_YMinAbs
                        mobjParameters.YaxisMax = const_YMaxAbs
                        mYValueLable = const_Energy
                    Case EnumCalibrationMode.EMISSION
                        mobjParameters.YaxisMin = const_YMinEmission
                        mobjParameters.YaxisMax = const_YMaxEmission
                        mYValueLable = const_Emission
                    Case EnumCalibrationMode.SELFTEST
                        mobjParameters.YaxisMin = const_YMinmVolt
                        mobjParameters.YaxisMax = const_YMaxmVolt
                        mYValueLable = const_Volt
                End Select

                'addataSpect.intSpeed = 50
                'addataSpect.intMode = gobjInst.Mode
                'addataSpect.blnPloted = True
                '//-----
                mobjParameters.ScanSpeed = CONST_SLOWStep
                mobjParameters.Cal_Mode = gobjInst.Mode
                mobjParameters.UVABS = gblnUVABS
                AASGraphUVSpectrum.AldysPane.Legend.IsVisible = False

                funcClearGraph()
                ''clear the previous graph if any
                funcGraphPreRequisite(mobjParameters.Cal_Mode, _
                                        mobjParameters.XaxisMin, _
                                        mobjParameters.XaxisMax, _
                                        mobjParameters.YaxisMin, _
                                        mobjParameters.YaxisMax)
                ''now set a graph as par new parameter
                blnSetDefaultSpectrumParameter = True
                funcSetDefaultSpectrumParameter = True
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
        ' Procedure Name        : funcSetSpectrumParameter
        ' Parameters Passed     : intCalibrationMode
        ' Returns               : Boolean
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
            funcSetSpectrumParameter = False

            '//----- Set the default parameter to the spectrum.
            If (gobjInst.Mode = intCalibrationMode) Then
                ''check is given mode is present or not
                funcSetSpectrumParameter = True
                Exit Function
            End If

            If gobjCommProtocol.funcCalibrationMode(EnumCalibrationMode.D2E) Then
                'addataSpect.dblWvMin = 230.0
                'addataSpect.dblWvMax = 250.0
                'mobjParameters.XaxisMin = 190
                'mobjParameters.XaxisMax = 400
                mobjParameters.XaxisMin = 190
                mobjParameters.XaxisMax = 220
                ''Depanding on the mode selected we have to change some spectrum parameter
                ''and passed it to data structure
                Select Case gobjInst.Mode
                    Case EnumCalibrationMode.AA, EnumCalibrationMode.AABGC, EnumCalibrationMode.MABS
                        'addataSpect.dblYmin = const_YMinAbs
                        'addataSpect.dblYMax = const_YMaxAbs
                        mobjParameters.YaxisMax = const_YMaxAbs
                        mobjParameters.YaxisMin = const_YMinAbs
                        mYValueLable = const_Absorbance
                    Case EnumCalibrationMode.D2E
                        mobjParameters.YaxisMax = const_YMaxAbs
                        mobjParameters.YaxisMin = const_YMinAbs
                        If gblnUVABS = True Then
                            mYValueLable = const_Absorbance
                        Else
                            mYValueLable = const_Transmission
                        End If

                    Case EnumCalibrationMode.HCLE

                        'mobjParameters.YaxisMin = const_YMinEnergy
                        'mobjParameters.YaxisMax = const_YMaxEnergy
                        mobjParameters.YaxisMin = const_YMinAbs
                        mobjParameters.YaxisMax = const_YMaxAbs
                        mYValueLable = const_Energy
                    Case EnumCalibrationMode.EMISSION
                        mobjParameters.YaxisMin = const_YMinEmission
                        mobjParameters.YaxisMax = const_YMaxEmission
                        mYValueLable = const_Emission
                    Case EnumCalibrationMode.SELFTEST
                        mobjParameters.YaxisMin = const_YMinmVolt
                        mobjParameters.YaxisMax = const_YMaxmVolt
                        mYValueLable = const_Volt
                End Select

                'addataSpect.intSpeed = 50
                'addataSpect.intMode = gobjInst.Mode
                'addataSpect.blnPloted = True
                '//-----
                mobjParameters.UVABS = gblnUVABS
                mobjParameters.ScanSpeed = CONST_SLOWStep
                mobjParameters.Cal_Mode = gobjInst.Mode
                blnSetDefaultSpectrumParameter = True
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

    Private Function funcSetDefaultParameter() As Boolean
        '=====================================================================
        ' Procedure Name        : funcSetDefaultParameter
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : 
        ' Description           : Set default Spectrum Parameter
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 21.11.06
        ' Revisions             : 
        '=====================================================================
        Dim intMaxD2Current As Integer
        Dim intMinD2Current As Integer
        Dim dblD2_PMT As Double
        ''for holding a temp PMT value
        Try
            funcSetDefaultParameter = False


            '//----- Set the default parameter to the spectrum.
            '/----- Set the Form object parameter
            '//----- Set PMT Object
            'nudPMT.DecimalPlaces = 0
            'nudPMT.Increment = 5.0
            'nudPMT.Maximum = 700.0
            'nudPMT.Minimum = 0.0
            'nudPMT.DecimalPlaces = 0



            nudPMT.DecimalPlace = 0
            nudPMT.ChangeFactor = 5.0
            nudPMT.MaxValue = 700.0
            ''for eg this will set a range for PMT
            nudPMT.MinValue = 0.0

            '---Get D2 PMT for AAS Instrument
            dblD2_PMT = CInt(gFuncGetFromINI(SECTION_D2Setting, KEY_D2PMT, "300.0", INI_SETTINGS_PATH))
            'Description:   To retrieve the key vale of a specified Section From INI
            ''get a setting of D2_PMT form INI file
            'Parameters :   Section, Key , DefaultKeyValue, strFullPath of the INI
            Call funcSetPmtVParameter(dblD2_PMT)
            ''now set this D2_PMT from which we got from INI file
            '//-----

            nudPMT.Value = gobjInst.PmtVoltage
            mobjParameters.PMTV = gobjInst.PmtVoltage
            mobjParameters.UVABS = gblnUVABS
            '//-----


            '//----- Set D2 current Object
            If gobjCommProtocol.SRLamp Then
                ''check for SR lamp if yes 
                intMaxD2Current = 600
                intMinD2Current = 100
            Else
                ''if no
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


            Call funcSetD2_CurParameter(300)
            ''for setting D2_Cur as par passed value
            nudD2Cur.Value = gobjInst.D2Current
            ''display current value of D2_Curr on the screen 
            If nudD2Cur.Value = 100.0 Then
                ''if it is 100.0 then put it OFF
                nudD2Cur.Text = "D2 Off"
            End If
            mobjParameters.D2Curr = gobjInst.D2Current
            '//-----

            '//----- Set Slit width Object
            nudSlit.DecimalPlace = 1
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

            If gobjInst.Mode = 2 Then

            End If
            mobjParameters.Cal_Mode = gobjInst.Mode
            '//----- Set the d2E default mode
            cmbModes.SelectedIndex = 0
            cmbModes.Enabled = False

            '//----- Set slow Speed 
            'cmbSpeed.SelectedIndex = 2
            'mobjParameters.ScanSpeed = CONST_SLOWStep

            '//----- Set fast Speed 

            cmbSpeed.SelectedIndex = 2
            'mobjParameters.ScanSpeed = CONST_FASTStep
            If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
                mobjParameters.ScanSpeed = CONST_SLOWStep_AA201
            Else
                mobjParameters.ScanSpeed = CONST_SLOWStep
            End If
            ''set the scan speed as par app mode

            lblYValue.Text = mYValueLable
            lblYValue.Refresh()

            funcSetDefaultParameter = True
            ''return true if succed
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
        Try
            funcSetParameter = False


            '//----- Set the default parameter to the spectrum.
            '/----- Set the Form object parameter
            '//----- Set PMT Object



            If mobjChannnels(mintChannelIndex).ChannelNo > -1 Then
                ''check for data structure index


                'nudPMT.Value = gobjInst.PmtVoltage
                nudPMT.Value = mobjChannnels(mintChannelIndex).UVParameter.PMTV()
                ''Note:-
                ''get a value from UV data structure as par index ,to the screen control
                ''for eg above line got a value of PMT to screen from UV data structure


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
                nudD2Cur.Value = mobjChannnels(mintChannelIndex).UVParameter.D2Curr
                '//-----

                '//----- Set Slit width Object
                'nudSlit.Value = gobjClsAAS203.funcGet_SlitWidth()
                nudSlit.Value = mobjChannnels(mintChannelIndex).UVParameter.SlitWidth

                '//-----
                If gobjInst.Mode = 2 Then

                End If

                '//----- Set the d2E default mode
                '//----- Set slow Speed s
                If gstructSettings.AppMode = EnumAppMode.DemoMode_201 Or _
                    gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
                    Select Case mobjChannnels(mintChannelIndex).UVParameter.ScanSpeed
                        Case CONST_FASTStep_AA201
                            cmbSpeed.SelectedIndex = 0
                        Case CONST_MEDIUMStep_AA201
                            cmbSpeed.SelectedIndex = 1
                        Case CONST_SLOWStep_AA201
                            cmbSpeed.SelectedIndex = 2
                    End Select
                Else
                    Select Case mobjChannnels(mintChannelIndex).UVParameter.ScanSpeed
                        Case CONST_FASTStep
                            cmbSpeed.SelectedIndex = 0
                        Case CONST_MEDIUMStep
                            cmbSpeed.SelectedIndex = 1
                        Case CONST_SLOWStep
                            cmbSpeed.SelectedIndex = 2
                    End Select
                End If

                lblYValue.Text = mYValueLable
                lblYValue.Refresh()

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
        ' Description           : Get Instrument Parameter
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
            '//----- added by Sachin dokhale to remove handlers on 08.10.07
            '28.09.07
            RemoveHandler nudD2Cur.ValueEditorClick, AddressOf nudD2Cur_ValueEditorClick
            RemoveHandler nudD2Cur.ValueEditorValueChanged, AddressOf nudD2Cur_ValueChanged

            'AddHandler nudSlit.ValueChanged, AddressOf nudSlit_ValueChanged
            RemoveHandler nudSlit.ValueEditorClick, AddressOf nudSlit_ValueEditorClick
            RemoveHandler nudSlit.ValueEditorValueChanged, AddressOf nudSlit_ValueChanged

            'AddHandler nudPMT.ValueChanged, AddressOf nudPMT_ValueChanged
            RemoveHandler nudPMT.ValueEditorClick, AddressOf nudPMT_ValueEditorClick
            RemoveHandler nudPMT.ValueEditorValueChanged, AddressOf nudPMT_ValueChanged
            '//-----
            'End If




            nudPMT.Value = gobjInst.PmtVoltage

            ''Note:-
            ''this function is for getting instrument parameter from gobjInst object to screen
            ''for eg above line will get a PMT voltage from gobjInst to screen
            ''and so on


            'mobjParameters.PMTV = gobjInst.PmtVoltage
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
            'mobjParameters.D2Curr = gobjInst.D2Current
            'nudD2Cur.Value = mobjChannnels(mintChannelIndex).EnegryParameter.D2Curr
            '//-----

            '//----- Set Slit width Object
            'nudSlit.Value = mobjChannnels(mintChannelIndex).EnegryParameter.SlitWidth
            nudSlit.Value = gobjClsAAS203.funcGet_SlitWidth()

            If Not (mobjParameters Is Nothing) Then
                mobjParameters.PMTV = gobjInst.PmtVoltage
                'mobjParameters.HCLCurr = gobjInst.Current
                mobjParameters.D2Curr = gobjInst.D2Current
                mobjParameters.SlitWidth = Val(nudSlit.Value)
                'mobjParameters.PMTV = CDbl(nudSlit.Value)
            End If

            '//-----


            '--- Set issue for Speed 
            'If gblnSetSpeedIssue = True Then
            '//----- added by Sachin dokhale to add handlers on 08.10.07
            '28.09.07
            AddHandler nudD2Cur.ValueEditorClick, AddressOf nudD2Cur_ValueEditorClick
            AddHandler nudD2Cur.ValueEditorValueChanged, AddressOf nudD2Cur_ValueChanged

            AddHandler nudSlit.ValueEditorClick, AddressOf nudSlit_ValueEditorClick
            AddHandler nudSlit.ValueEditorValueChanged, AddressOf nudSlit_ValueChanged

            AddHandler nudPMT.ValueEditorClick, AddressOf nudPMT_ValueEditorClick
            AddHandler nudPMT.ValueEditorValueChanged, AddressOf nudPMT_ValueChanged
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

    Private Function funcSetPmtVParameter(ByVal dblPmtV As Double) As Boolean
        '=====================================================================
        ' Procedure Name        : funcSetPmtVParameter
        ' Parameters Passed     : dblPmtV 
        ' Returns               : Boolean
        ' Purpose               : 
        ' Description           : Set Pmt Volt Parameter to the instrument
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 22.11.06
        ' Revisions             : 
        '=====================================================================
        Dim dblPMTVolt As Double
        Dim dblAdjPMTVolt As Double
        ''note:-
        ''this function set a passed PMT value to instrument 
        ''before sending it to instru
        ''we perfrom some validation
        ''eg it should be in range 0-700
        ''and then store that current PMT to data structure also


        Try
            funcSetPmtVParameter = False
            dblPMTVolt = gobjInst.PmtVoltage

            If Not dblPmtV = dblPMTVolt Then

                If dblPmtV > dblPMTVolt Then

                    'dblPMTVolt += 5.0
                    dblAdjPMTVolt = dblPmtV - dblPMTVolt
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
                    ''this is a serial communication function for setting given PMT to the instrument

                    'gobjInst.PmtVoltage = dblPMTVolt
                    funcSetPmtVParameter = True
                End If
                mobjParameters.PMTV = Val(dblPmtV)
                ''save a current PMT value to data structure also
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
            ''note:
            ''depanding on given value it set the speed
            ''value of constants also shown here.
            funcSetSpeed = False
            If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
                Select Case intSpeed
                    Case 0
                        mobjParameters.ScanSpeed = CONST_FASTStep_AA201 ''25.0
                    Case 1
                        mobjParameters.ScanSpeed = CONST_MEDIUMStep_AA201 ''12.5
                    Case 2
                        mobjParameters.ScanSpeed = CONST_SLOWStep_AA201 ''2.5
                End Select
            Else
                Select Case intSpeed
                    Case 0
                        mobjParameters.ScanSpeed = CONST_FASTStep
                    Case 1
                        mobjParameters.ScanSpeed = CONST_MEDIUMStep
                    Case 2
                        mobjParameters.ScanSpeed = CONST_SLOWStep
                End Select
            End If

            'mobjParameters.ScanSpeed = intSpeed
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

    'Private Function funcSetModes(ByVal intModes As Integer) As Boolean
    '    '=====================================================================
    '    ' Procedure Name        : funcSetModes
    '    ' Parameters Passed     : intSpeed 
    '    ' Returns               : Boolean
    '    ' Purpose               : 
    '    ' Description           : Set scan Speed
    '    ' Assumptions           : 
    '    ' Dependencies          : 
    '    ' Author                : Sachin Dokhale
    '    ' Created               : 22.11.06
    '    ' Revisions             : 
    '    '=====================================================================

    '    Try
    '        funcSetModes = False

    '        Select Case intModes
    '            Case 0
    '                mobjParameters.ScanSpeed = CONST_FASTStep
    '            Case 1
    '                mobjParameters.ScanSpeed = CONST_MEDIUMStep
    '            Case 2
    '                mobjParameters.ScanSpeed = CONST_SLOWStep
    '        End Select
    '        mobjParameters.Cal_Mode = intModes
    '        funcSetModes = True




    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        'Error Handling and logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = ex.Message
    '        gobjErrorHandler.WriteErrorLog(ex)
    '        Return False
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

    Private Function funcSetD2_CurParameter(ByVal intD2_Cur As Integer) As Boolean
        '=====================================================================
        ' Procedure Name        : funcSetD2_CurParameter
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

        ''note:-
        ''this function set a passed D2 current value to instrument 
        ''before sending it to instru
        ''we perfrom some validation
        ''eg it should be in range 
        ''and then store that current value to data structure also

        Try
            funcSetD2_CurParameter = False
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
            ''this is a serial communication function for setting D2 curr to the instrument


            If gobjCommProtocol.SRLamp Then
                ''check fo SR lamp
                gobjInst.D2Current = intD2Lamp_Cur
            Else
                If intD2Lamp_Cur = 100 Then

                End If
            End If
            mobjParameters.D2Curr = Val(intD2_Cur)
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
            '---------------------------------------------------------
        End Try
    End Function

    Private Function funcSetSlit_WidthParameter(ByVal dblSlit_Width As Double) As Boolean
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

        ''note:-
        ''this function set a passed slit width value to instrument 
        ''before sending it to instru
        ''we perfrom some validation
        ''eg it should be in range 
        ''and then store that current value to data structure also


        Try
            funcSetSlit_WidthParameter = False
            ''below are some validation for slit width
            dblSlitWidth = gobjClsAAS203.funcGet_SlitWidth()

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
            ''serial communication function for setting a slitwidth


            mobjParameters.SlitWidth = Val(dblSlitWidth)
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
            '---------------------------------------------------------
        End Try
    End Function

    Public Function funcOnSpect(ByVal BaseLine As Boolean, ByRef lblScanStatus As System.Object, _
                ByRef lblOnlineWv As System.Object) As Boolean
        '=====================================================================
        ' Procedure Name        :   funcOnSpect
        ' Description           :   For starting a UV spectrum by starting a UV thread.
        ' Purpose               :   
        ' Parameters Passed     :   
        ' Returns               :   
        ' Parameters Affected   :   
        ' Assumptions           :   
        ' Dependencies          :   None.
        ' Author                :   Sachin Dokhale
        ' Created               :   04.05.07
        ' Revisions             :   praveen
        '=====================================================================


        ''BaseLine  is bool flag which check a baseline
        ''it should be perfrom only when baseline is completed
        ''this will start a spectrum routin.

        '//----- Orig
        'addata.counter = 0;
        ' if (addata.speed==0){
        'if (GetInstrument()==AA202) addata.speed=FASTSTEP_AA202;
        'else addata.speed=FAST;
        ' }
        ' speed = addata.speed;
        '/-----
        mobjParameters.UVABS = True
        ''this is cond which ckeck for uv spectrum mode
        mobjParameters.IsBaseline = BaseLine
        ''check for base line 

        If mobjParameters.ScanSpeed = 0 Then
            ''this will set a scan speed , given by user
            If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
                ''check for 201 instrument
                mobjParameters.ScanSpeed = CONST_STEPS_PER_NM_AA201
            Else
                mobjParameters.ScanSpeed = CONST_STEPS_PER_NM
            End If
        End If
        'If (addataSpect.intSpeed = 0) Then
        '    addataSpect.intSpeed = CONST_STEPS_PER_NM
        'End If

        'If (mobjParameters.ScanSpeed = 0) Then
        '   mobjParameters.ScanSpeed = CONST_STEPS_PER_NM
        'End If


        'If Not (gblnUVABS = True) Then

        'addataSpect.dblYmin = 0.0
        'addataSpect.dblYMax = 1.0


        '--- Add the parameters to the online channel object
        'Dim ObjParameter As New Spectrum.UVSpectrumParameter
        ''new object for spectrum
        mobjOnlineChannel = New Spectrum.Channel(False)
        ''make a obj of data structure for storing value

        'ObjParameter = funcCloneParameter(mobjParameters)
        ''make a copy of all parameter to ObjParameter 
        'mobjOnlineChannel.UVParameter = ObjParameter
        mobjOnlineChannel.UVParameter = mobjSpectrum.funcCloneUVParameter(mobjParameters)
        ''now passed all parameter to data structure object
        'ObjParameter = Nothing


        If Not funcGraphPreRequisite(mobjParameters.Cal_Mode, _
                                    mobjParameters.XaxisMin, _
                                    mobjParameters.XaxisMax, _
                                    mobjParameters.YaxisMin, _
                                    mobjParameters.YaxisMax) Then
            ''this will set a some pre requisite for a uv spectrum
            ''if this false then it will exit from function
            'Call gFuncShowMessage("Error in setting spectrum parameters", "Please Check Entered Spectrum Parameters", modConstants.EnumMessageType.Information)
            Exit Function
        End If

        mblnAvoidProcessing = True
        gblnUVABS = True
        mobjOnlineReadings = New Spectrum.Readings

        mblnSpectrumStarted = True
        ''this is flag for starting a spectrum
        gblnUVABS = True
        ''this is flag for UV mode
        'RemoveHandler mnuIgnite.Click, AddressOf btnIgnite_Click
        '--- Start the Spectrum analysis
        'mobjController.Start(New clsBgSpectrum(lblWvPos, lblOnlineWv, _
        '                     mobjParameters.XaxisMax, _
        '                     mobjParameters.XaxisMin, _
        '                     mobjParameters.YaxisMax, _
        '                     mobjParameters.YaxisMin, _
        '                     mobjParameters.Cal_Mode, _
        '                     mobjParameters.ScanSpeed, BaseLine))

        mobjController = New clsBgThread(Me)
        ''make a obj for thread
        mobjclsBgSpectrum = New clsBgSpectrum(lblWvPos, lblOnlineWv, _
                             mobjParameters.XaxisMax, _
                             mobjParameters.XaxisMin, _
                             mobjParameters.YaxisMax, _
                             mobjParameters.YaxisMin, _
                             mobjParameters.Cal_Mode, _
                             mobjParameters.ScanSpeed, 0, False, BaseLine)

        MenuBarUV.Enabled = False '---21.01.11 added by Deepak 

        mobjController.Start(mobjclsBgSpectrum)
        ''this will start a uv spectrumthread 
        ''which will get a value from instrument and display it on spectrum


        'WP1=-1;
        ' addata.Saved=FALSE;;
        ' disp_Cur_wv_abs(hwnd);
        ' hdc= GetDC(hwnd);
        '/* IncrColor();
        ' Hpen =  (HPEN) CreatePen(PS_SOLID, 1, RGB(Color[Colptr][0],Color[Colptr][1],Color[Colptr][2]));
        ' hpenold= (HPEN) SelectObject(hdc, Hpen);
        '*/
        'funcWavelength_Position(hdc,SpectGraph.Xmin, 20, 372 );

        '//----- This is for UV Spectrum

        'If (UVS) = True Then
        '    If (!UVABS) Then
        '        UVABS = True
        '        SpectGraph.Ymin = 0
        '        SpectGraph.Ymax = 1.0
        '        Scroll_Mode1(hwnd, IDC_MODE, -1)
        '    End If
        '    If (Inst.d2Pmt = 0) Then
        '        Adj_D2Gain(hwnd, True, 15, 372)
        '        Wavelength_Position(hdc, SpectGraph.Xmin, 20, 372)
        '    End If
        '    UvSpectReading(hwnd, hdc, gblnBaseLine)
        '//-----



        'funcSpectReading(hwnd, hdc)

        'End If
        '//----- Set the Wavelength Position
        'Wavelength_Position(hdc, SpectGraph.Xmin, 20, 372)

        '/* SelectObject(hdc, hpenold);
        'DeleteObject(Hpen);
        '*/
        'ReleaseDC(hwnd,hdc);

        'disp_Cur_wv_abs(hwnd);
        funcOnSpect = True
    End Function

    Private Sub subLabelDisplay(ByVal objChannel As Spectrum.Channel)

        ''not in used.
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
            mobjChannnels.Add(objInChannel)
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

    'Private Function funcCloneParameter(ByVal inobjparamter As Spectrum.UVSpectrumParameter) As Spectrum.UVSpectrumParameter
    '    '=====================================================================
    '    ' Procedure Name        :   funcCloneParameter
    '    ' Description           :  this will make a copy of all parameter from one object to another
    '    '                          and return a new object
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
    '    ''note:
    '    ''this will make a copy of all parameter from one object to another
    '    ''and return a new object

    '    Try
    '        Dim objCloneParameter As New UVSpectrumParameter
    '        '----------------------Cloning  parameter object ----------------------------------
    '        objCloneParameter.AnalysisDate = inobjparamter.AnalysisDate
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

    Private Function funcAbsConvertTransmission() As Boolean
        '=====================================================================
        ' Procedure Name        :   funcAbsConvertTransmission
        ' Description           :   
        ' Purpose               :   
        ' Parameters Passed     :   None.
        ' Returns               :   Boolean
        ' Parameters Affected   :   None.
        ' Assumptions           :   None.
        ' Dependencies          :   None. 
        ' Author                :   Sachin Dokhale
        ' Created               :   13.12.06
        ' Revisions             :
        '=====================================================================
        Dim dblCurrYaxis As Double
        Dim dblNewYaxis As Double
        Dim intXaxisIdx As Double
        ''note:
        ''this is used for convertion
        Try
            'gblnUVABS = False
            gblnUVABS = Not gblnUVABS
            If mobjChannnels.Count > mintChannelIndex Then
                ''check for data structure 
                If mobjChannnels.item(mintChannelIndex).Spectrums.Count > 0 Then
                    ''if ther is some spectrum count then
                    'For intXaxisIdx = gFuncGetIndexWv(mobjChannnels.item(mintChannelIndex).UVParameter.XaxisMin, False) To gFuncGetIndexWv(mobjChannnels.item(mintChannelIndex).UVParameter.XaxisMax, False)
                    For intXaxisIdx = 0 To mobjChannnels.item(mintChannelIndex).Spectrums.item(0).Readings.Count - 1
                        ''Note:
                        ''below are a line which convert abs to T
                        ''get a current value from data structure 
                        ''perfrom below formilla
                        dblCurrYaxis = mobjChannnels.item(mintChannelIndex).Spectrums.item(0).Readings.item(intXaxisIdx).YaxisData
                        'k= 2047.0 + exp((2.0- ((addata.ad[i]-2047.0)*2.0/1638.4)) *log(10))*2048.0/100.0;
                        dblNewYaxis = 2047.0 + Math.Exp((2.0 - ((dblCurrYaxis - 2047.0) * 2.0 / 1638.4)) * Math.Log(10)) * 2048.0 / 100.0
                        mobjChannnels.item(mintChannelIndex).Spectrums.item(0).Readings.item(intXaxisIdx).YaxisData = dblNewYaxis
                    Next
                End If
                funcClearGraph()


                If gblnUVABS = True Then
                    ''check for UV mode
                    ''if true set axis as par UV mode.
                    mobjChannnels.item(mintChannelIndex).UVParameter.YaxisMax = const_YMaxAbs
                    mobjChannnels.item(mintChannelIndex).UVParameter.YaxisMin = const_YMinAbs
                Else
                    mobjChannnels.item(mintChannelIndex).UVParameter.YaxisMax = const_YMaxTransmision
                    mobjChannnels.item(mintChannelIndex).UVParameter.YaxisMin = const_YMinTransmision
                End If
                mobjChannnels.item(mintChannelIndex).UVParameter.UVABS = gblnUVABS
                funcDisplayGraph(mobjChannnels.item(mintChannelIndex))
                AASGraphUVSpectrum.Refresh()
                Application.DoEvents()
                ''display a graph as par data structure
                funcGraphPreRequisite(mobjParameters.Cal_Mode, _
                        mobjChannnels.item(mintChannelIndex).UVParameter.XaxisMin, _
                        mobjChannnels.item(mintChannelIndex).UVParameter.XaxisMax, _
                        mobjChannnels.item(mintChannelIndex).UVParameter.YaxisMin, _
                        mobjChannnels.item(mintChannelIndex).UVParameter.YaxisMax)
                AASGraphUVSpectrum.OfflineCurve.Label = AASGraphUVSpectrum.YAxisLabel
                'AASGraphUVSpectrum.Invalidate()
                AASGraphUVSpectrum.Refresh()
                Application.DoEvents()
                ''allow application to perfrom its panding work.

            End If

            Return True
            '           if (addata.ad!=NULL) {
            ' for (i=0; i<addata.counter; i++){
            ' k= 2047.0 + exp((2.0- ((addata.ad[i]-2047.0)*2.0/1638.4)) *log(10))*2048.0/100.0;
            ' addata.ad[i] =k;
            '}
            ' UVABS=FALSE;
            ' SpectGraph.Ymin = 0;
            ' SpectGraph.Ymax = 100;
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            'gobjErrorHandler.ProcessError(EnumErrorType.Critical, ex)
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

    Private Function funcTransmissionConvertAbs() As Boolean

        '=====================================================================
        ' Procedure Name        :   funcTransmissionConvertAbs
        ' Description           :   
        ' Purpose               :   
        ' Parameters Passed     :   None.
        ' Returns               :   Boolean
        ' Parameters Affected   :   None.
        ' Assumptions           :   None.
        ' Dependencies          :   None. 
        ' Author                :   Sachin Dokhale
        ' Created               :   13.12.06
        ' Revisions             :
        '=====================================================================
        Dim dblCurrYaxis As Double
        Dim dblNewYaxis As Double
        Dim intXaxisIdx As Double

        Try
            gblnUVABS = True
            If mobjChannnels.Count > mintChannelIndex Then
                If mobjChannnels.item(mintChannelIndex).Spectrums.Count > 0 Then
                    'For intXaxisIdx = gFuncGetIndexWv(mobjChannnels.item(mintChannelIndex).UVParameter.XaxisMin, False) To gFuncGetIndexWv(mobjChannnels.item(mintChannelIndex).UVParameter.XaxisMax, False)
                    For intXaxisIdx = 0 To mobjChannnels.item(mintChannelIndex).Spectrums.item(0).Readings.Count - 1

                        ''note:
                        ''get a current value
                        ''perfrom below formulla 
                        dblCurrYaxis = mobjChannnels.item(mintChannelIndex).Spectrums.item(0).Readings.item(intXaxisIdx).YaxisData
                        'k= 2047.0 + exp((2.0- ((addata.ad[i]-2047.0)*2.0/1638.4)) *log(10))*2048.0/100.0;
                        dblNewYaxis = 2047.0 + Math.Exp((2.0 - ((dblCurrYaxis - 2047.0) * 2.0 / 1638.4)) * Math.Log(10)) * 2048.0 / 100.0
                        mobjChannnels.item(mintChannelIndex).Spectrums.item(0).Readings.item(intXaxisIdx).YaxisData = dblNewYaxis
                    Next
                End If
                funcClearGraph()

                funcDisplayGraph(mobjChannnels.item(mintChannelIndex))
                mobjChannnels.item(mintChannelIndex).UVParameter.YaxisMax = const_YMaxAbs
                mobjChannnels.item(mintChannelIndex).UVParameter.YaxisMin = const_YMinAbs
                mobjChannnels.item(mintChannelIndex).UVParameter.UVABS = gblnUVABS
                funcGraphPreRequisite(mobjParameters.Cal_Mode, _
                        mobjParameters.XaxisMin, _
                        mobjParameters.XaxisMax, _
                        mobjParameters.YaxisMin, _
                        mobjParameters.YaxisMax)

            End If

            Return True
            '           if (addata.ad!=NULL) {
            ' for (i=0; i<addata.counter; i++){
            ' k= 2047.0 + exp((2.0- ((addata.ad[i]-2047.0)*2.0/1638.4)) *log(10))*2048.0/100.0;
            ' addata.ad[i] =k;
            '}
            ' UVABS=FALSE;
            ' SpectGraph.Ymin = 0;
            ' SpectGraph.Ymax = 100;
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            'gobjErrorHandler.ProcessError(EnumErrorType.Critical, ex)
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

    

#Region "Save/Load Spectrum Function"
    '--- Save the Current Active channel to a UVSpectrum(uvs) file
    Private Function funcSaveSpectrumFile() As Boolean
        '=====================================================================
        ' Procedure Name        :   funcSaveSpectrumFile
        ' Description           :   Get the File name and path from the user
        '                           and save the spectrum file to *.spt 
        ' Purpose               :   To save the channel information to the 
        '                           Spectrum file.
        ' Parameters Passed     :   None.
        ' Returns               :   True, if successful.
        ' Parameters Affected   :   None.
        ' Assumptions           :
        ' Dependencies          :
        ' Author                :   Gitesh, Uday
        ' Created               :   Saturday, November 15, 2003 18:49
        ' Revisions             :
        '=====================================================================
        Try
            'If mobjChannnels.item(mintChannelIndex) Is Nothing Then
            If mobjChannnels.item(mobjChannnels.Count - 1) Is Nothing Then
                gobjMessageAdapter.ShowMessage(constSpectrumNotPresent)
                Application.DoEvents()
                'gFuncShowMessage("Error", "Spectrum is not present for saving.", EnumMessageType.Information)
                Exit Function
            End If

            Dim objchannel As Spectrum.Channel

            'objchannel = mobjChannnels.item(mintChannelIndex)
            objchannel = mobjChannnels.item(mobjChannnels.Count - 1)
            'objchannel.UVParameter.UVABS()

            '31.3.2010 by dinesh wagh
            '-----------------------------------------------------
            If (gstructSettings.Enable21CFR = True) Then
                If Not funcCheckActivityAuthentication(enumActivityAuthentication.SaveFile, gstructUserDetails.Access) Then
                    ''check for authentication
                    Exit Function
                End If
                'save log a in file
                gfuncInsertActivityLog(EnumModules.SaveFile, "Save Spectrum File Accessed")
            End If
            '--------------------------------


            If gstructSettings.Enable21CFR = True Then
                If Not gfuncGetFileAuthenticationData(objchannel.DigitalSignature) Then
                    Return True
                End If
            End If
            'Else
            '--- This is for saving the file with login Authnetication 
            '--- when 21 cfr is off
            'If Not gfuncGetFileAuthenticationData_21CFR_OFF(objchannel.DigitalSignature) Then
            '    Return True
            'End If
            'End If

            Dim objStream As Stream
            Dim objsfdSpectrum As New SaveFileDialog

            '--- Show the save dialog to accept the *.spt file.
            objsfdSpectrum.Filter = "Spectrum Files(*" & CONST_UVSpectrumFileExt & ")|*" & CONST_UVSpectrumFileExt
            objsfdSpectrum.FilterIndex = 1
            objsfdSpectrum.InitialDirectory = strPath.GetCurrentDirectory.ToString + "\UVSpectrums"
            objsfdSpectrum.RestoreDirectory = True

            If objsfdSpectrum.ShowDialog() = DialogResult.OK Then
                'objchannel.DigitalSignature.FileName = objsfdSpectrum.FileName
                '--- Check if file exist   
                If (objsfdSpectrum.CheckFileExists()) Then
                    'If (MessageBox.Show("DO YOU WISH TO OVERWRITE", "SAVE AS", MessageBoxButtons.YesNo) = DialogResult.Yes) Then
                    If gobjMessageAdapter.ShowMessage(constSaveAs) = True Then
                        Application.DoEvents()
                        If Not gfuncSerializeObject(objsfdSpectrum.FileName, objchannel) Then
                            gobjMessageAdapter.ShowMessage(constErrorFileSaving)
                            Application.DoEvents()
                            'gFuncShowMessage("Error", "ERROR IN SAVING FILE.", EnumMessageType.Information)
                        End If
                    Else
                        Return True
                    End If
                Else
                    If Not gfuncSerializeObject(objsfdSpectrum.FileName, objchannel) Then
                        gobjMessageAdapter.ShowMessage(constErrorFileSaving)
                        Application.DoEvents()
                        'gFuncShowMessage("Error", "ERROR IN SAVING FILE.", EnumMessageType.Information)
                    End If
                End If

                '--- Writing to Activity Log and File Log
                If (gstructSettings.Enable21CFR = True) Then
                    Dim lngActivityLogID As Long
                    lngActivityLogID = gfuncInsertActivityLog(EnumModules.Energy_Spectrum_Mode, "Spectrum File Saved")

                    If (lngActivityLogID > 0) Then
                        Dim objFI As New FileInfo(objsfdSpectrum.FileName)
                        Dim strXMLFileData As String
                        Dim strFileLogPath As String
                        Dim strFileName As String = Replace(objFI.Name, objFI.Extension, "")

                        strFileName = strFileName & "_" & Format(DateTime.Now, "MM_dd_yyyy_hh_mm_ss") & objFI.Extension

                        If Not Directory.Exists(CONST_FILELOG_PATH) Then
                            Call Directory.CreateDirectory(CONST_FILELOG_PATH)
                        End If

                        strFileLogPath = CONST_FILELOG_PATH & "\" & strFileName

                        'Call objclsXmlOperation.gfuncXMLSerializeObject(strFileLogPath, objchannel)
                        'strXMLFileData = objclsXmlOperation.gfuncXMLFileRead(strFileLogPath)
                        If Not gfuncSerializeObject(strFileLogPath, objchannel) Then
                            Throw New Exception
                        End If
                        '--- Log the file 
                        Call gfuncInsertFileLog(lngActivityLogID, objsfdSpectrum.FileName, strFileLogPath)
                    End If
                End If
            End If
            objsfdSpectrum.Dispose()
            blnYetFileNotSave = False
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
            blnYetFileNotSave = False
            '---------------------------------------------------------
        End Try

    End Function

    '--- Load channel from spectrum(spt) file
    Private Function funcLoadSpectrumFile() As Boolean
        '=====================================================================
        ' Procedure Name        :   funcLoadSpectrumFile
        ' Description           :   Get the Spectrum file from the user and load the
        '                           spectrum file data to the channel object.
        ' Purpose               :   To load the spectrum file in the channel object.
        ' Parameters Passed     :   None.
        ' Returns               :   True, if successful.
        ' Parameters Affected   :   Spectrum file data is added to the channels collection.
        ' Assumptions           :   None.
        ' Dependencies          :   None.
        ' Author                :   Gitesh, Uday
        ' Created               :   Saturday, November 15, 2003 18:49
        ' Revisions             :   Nilesh Shirode  feb 11 2004
        '=====================================================================
        Dim objStream As Stream
        Dim objofdSpectrum As New OpenFileDialog
        Try
            funcLoadSpectrumFile = False

            objofdSpectrum.InitialDirectory = strPath.GetCurrentDirectory.ToString & "\Spectrums"
            objofdSpectrum.Filter = "Spectrum Files(*" & CONST_UVSpectrumFileExt & ")|*" & CONST_UVSpectrumFileExt
            objofdSpectrum.FilterIndex = 1
            objofdSpectrum.RestoreDirectory = True

            If objofdSpectrum.ShowDialog() = DialogResult.OK Then
                If (objofdSpectrum.CheckFileExists()) Then
                    Dim objchannel As Spectrum.Channel
                    Dim intChannel_no As Int16

                    If gstructSettings.Enable21CFR = True Then
                        Dim objChn As Spectrum.Channel
                        objChn = gfuncDeSerializeObject(objofdSpectrum.FileName, EnumDeserializeObjType.UVSpectrum)
                        If gfuncCheckForFileAuthentication(objChn.DigitalSignature) Then
                            objchannel = objChn
                        Else
                            Call gobjMessageAdapter.ShowMessage(constAccessDenied)
                            Application.DoEvents()
                            Return False
                        End If
                    End If

                    objchannel = gfuncDeSerializeObject(objofdSpectrum.FileName, EnumDeserializeObjType.UVSpectrum)
                    '--- Add the new channel to the channels collection and 
                    '--- accordingly save the channel file to the disk
                    intChannel_no = funcAddChannelToCollection(objchannel)
                    If mobjChannnels.Count > 0 Then
                        mobjChannnels.item(0) = objchannel
                        mobjParameters = Nothing
                        mobjParameters = mobjChannnels.item(0).UVParameter
                        gblnUVABS = mobjParameters.UVABS
                        'intChannel_no = funcAddChannelToCollection(mobjOnlineChannel)
                        blnYetFileNotSave = True
                        mintChannelIndex = intChannel_no

                        Call funcSetParameter()
                        funcClearGraph()
                        funcDisplayGraph(mobjChannnels.item(mintChannelIndex), mGraphCurveItem)
                        ArrlstGraphCurveItem.Add(mGraphCurveItem)
                        intCurveIndex = ArrlstGraphCurveItem.Count - 1

                        'funcDisplayGraph(mobjChannnels.item(intChannel_no))
                        funcGraphPreRequisite(mobjParameters.Cal_Mode, _
                                                                        mobjParameters.XaxisMin, _
                                                                        mobjParameters.XaxisMax, _
                                                                        mobjParameters.YaxisMin, _
                                                                        mobjParameters.YaxisMax)
                    Else
                        mobjParameters = Nothing
                        mobjChannnels.Add(objchannel)
                        mobjParameters = mobjChannnels.item(intChannel_no).UVParameter
                        gblnUVABS = mobjParameters.UVABS
                        Call funcSetParameter()
                        funcClearGraph()

                        'funcDisplayGraph(mobjChannnels.item(intChannel_no))

                        funcDisplayGraph(mobjChannnels.item(mintChannelIndex), mGraphCurveItem)
                        ArrlstGraphCurveItem.Add(mGraphCurveItem)
                        intCurveIndex = ArrlstGraphCurveItem.Count - 1

                        funcGraphPreRequisite(mobjParameters.Cal_Mode, _
                                                                        mobjParameters.XaxisMin, _
                                                                        mobjParameters.XaxisMax, _
                                                                        mobjParameters.YaxisMin, _
                                                                        mobjParameters.YaxisMax)
                    End If
                    func_Enable_Disable(EnumProcesses.LoadChannel, EnumStart_End.Start_of_Process)
                    Application.DoEvents()

                    'subLabelDisplay(mobjChannnels.item(0))



                End If
            End If
            objofdSpectrum.Dispose()
            funcLoadSpectrumFile = True

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

#End Region

    Private Function funcSetFrmEditValue(ByRef dblReturnValue As Double, ByVal strWinTitle As String, ByVal dblMinValue As Double, ByVal dblMaxValue As Double) As Boolean
        '=====================================================================
        ' Procedure Name        : subSetFrmEditValue
        ' Parameters Passed     : 
        ' Returns               : 
        ' Purpose               : 
        '                         
        ' Description           : for displaying a edit box as par passed value.
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : Apr 01, 2007 4:00 pm
        ' Revisions             : 1
        '=====================================================================

        ''note:
        ''this is used for display a Edit Dialog as par parameter passed
        ''for eg strWinTitle shoh a title to be shown.

        Dim InputValue As Double
        Dim intValue As Integer
        Try
            mobjfrmEditValues = New frmEditValues
            mobjfrmEditValues.LabelText = strWinTitle
            mobjfrmEditValues.txtValue.Visible = True
            Select Case strWinTitle
                Case "PMT", "D2 Current"
                    mobjfrmEditValues.txtValue.ValidationType = NumberValidator.NumberValidator.Validations.IntegerOnly

                    intValue = CInt(dblReturnValue)
                    dblReturnValue = intValue
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

            mobjfrmEditValues.txtValue.Text = dblReturnValue
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
            '    Application.DoEvents()
            '    'MsgBox("PMT value should be between 0 and 1000")
            '    Exit Function
            'End If

            dblReturnValue = InputValue
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
            'ProgressPanel.Text = Application.ProductName & Space(1) & Application.ProductVersion
            ProgressPanel.Text = gstrTitleInstrumentType & Space(1) & "S/W Ver. : " & Mid(Application.ProductVersion, 1, 4)

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
        '=====================================================================
        ' Procedure Name        : TaskStarted
        ' Parameters Passed     : BgThread
        ' Returns               : None
        ' Purpose               : this is used for starting a thread task.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : Saturday, January 22, 2005
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
        ' Returns               : None
        ' Purpose               : this is used for display result of  thread task.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : Saturday, January 22, 2005
        ' Revisions             : 
        '=====================================================================
        Try
            'If gstructApplicationSessionState.intInstrument_Group = EnumInstrumentGroup.Initialize_2600_2700 Then
            Call funcIclientTaskDisplayData(Text)
            ''function for displaying a result.
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
        '=====================================================================
        ' Procedure Name        : TaskFailed
        ' Parameters Passed     : e
        ' Returns               : None
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : Saturday, January 22, 2005
        ' Revisions             : 
        '=====================================================================
        Try
            '--- Dispose all the objects
            'mobjTemporaryChannel = New Channel
            'mobjTemporaryReadings = New Readings
            'mobjTemporaryReadings_2100 = New Readings
            mAvoidProcessBtn = True
            funcIclientTaskFalied()
            ''function for displaying a task failed

            mblnSpectrumStarted = False
            mblnAvoidProcessing = False
            statStartGraph = False
            mAvoidProcessBtn = False
            '///


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
        ' Returns               : None
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : Saturday, January 22, 2005
        ' Revisions             : 
        '=====================================================================
        Try
            'If gstructApplicationSessionState.intInstrument_Group = EnumInstrumentGroup.Initialize_2600_2700 Then
            '    'Call funcIclientTaskCompleted2600()
            'ElseIf gstructApplicationSessionState.intInstrument_Group = EnumInstrumentGroup.Initialize_2100_2200_2300 Then
            '    'Call funcIclientTaskCompleted2100()
            'End If
            mAvoidProcessBtn = True
            Call funcIclientTaskCompleted()
            ''function for showing task completed

            mblnSpectrumStarted = False
            mblnAvoidProcessing = False
            statStartGraph = False
            mAvoidProcessBtn = False
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

    Private Function funcIclientTaskDisplayData(ByVal strData As String) As Boolean
        '=====================================================================
        ' Procedure Name        : funcIclientTaskDisplayData
        ' Parameters Passed     : strData
        ' Returns               : None
        ' Purpose               : for displaying a thread result.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : Saturday, January 22, 2005
        ' Revisions             : 
        '=====================================================================
        Try
            '-----------------------------------------------------
            'Data in the Text arg would be "Wavelength|Abs"
            '-----------------------------------------------------
            Dim objData As New Spectrum.Data
            Dim arrData() As String
            Dim O As Integer   ' same as in function funcSmoothgraphonline
            Dim intCount As Integer

            Application.DoEvents()
            '--- Split the data for Wv and Abs
            arrData = Split(strData, "|")

            If arrData(0).Length > 0 And arrData(1).Length > 0 Then

                objData.XaxisData = Format(Val(arrData(0)), "#000.0000")   ' wv

                'Select Case mobjTemporaryChannel.Parameter.ScanMode
                '    Case EnumScanMode.Absorbance
                '        objData.YaxisData = Format(Val(arrData(1)), "#0.000")
                '    Case EnumScanMode.Transmittance
                '        objData.YaxisData = Format(Val(arrData(1)), "#0.0")
                '    Case EnumScanMode.Energy
                '        objData.YaxisData = Format(Val(arrData(1)), "#0.0")
                'End Select

                objData.YaxisData = Format(Val(arrData(1)), "#0.0000")
                If Not (arrData(2) Is Nothing) Then
                    If arrData(2).Length > 0 Then
                        objData.YaxisADCData = Val(arrData(2))
                    Else
                        objData.YaxisADCData = 0.0  'Format(Val(arrData(1)), "#0.000")
                    End If
                End If
                'O = (ORDER - 1) / 2

                'If Val(arrData(2)) = 1 Then  'EnumUVProtocol.Data Then

                '--- Add the reading to the temp readings collection

                mobjOnlineReadings.Add(objData)


                'lblOnlineWv.Text = Format(mobjTemporaryReadings.item(mobjTemporaryReadings.Count - 1).XaxisData, "#000.0")


                'Select Case mobjTemporaryChannel.Parameter.ScanMode
                '    Case EnumScanMode.Absorbance
                '        lblOnlineABS.Text = Format(mobjTemporaryReadings.item(mobjTemporaryReadings.Count - 1).YaxisData, "#0.000")
                '    Case EnumScanMode.Transmittance, EnumScanMode.Energy
                '        lblOnlineABS.Text = Format(mobjTemporaryReadings.item(mobjTemporaryReadings.Count - 1).YaxisData, "#0.0")
                'End Select

                funcDisplayGraph_RealTime(objData.XaxisData, objData.YaxisData)
                'If gblnSmoothFlag Then
                'If mobjTemporaryReadings.Count < ORDER Then
                '    NPSmoothningdata(mobjTemporaryReadings.Count) = objData.YaxisData
                'End If

                'If (mobjTemporaryReadings.Count - 1) < ((ORDER - 1) / 2) Then

                '    funcDisplayGraph_RealTime(mobjTemporaryReadings.item(mobjTemporaryReadings.Count - 1).XaxisData, _
                '                              mobjTemporaryReadings.item(mobjTemporaryReadings.Count - 1).YaxisData)

                'ElseIf mobjTemporaryReadings.Count >= ORDER Then
                '    gfuncSmoothOnlineGraph(mobjTemporaryReadings, NPSmoothningdata)
                '    funcDisplayGraph_RealTime(mobjTemporaryReadings.item((mobjTemporaryReadings.Count - 1) - O).XaxisData, _
                '                              mobjTemporaryReadings.item((mobjTemporaryReadings.Count - 1) - O).YaxisData)
                'End If
                'Else  ' if not gblnsmoothgraph then there is no need to smooth the graph
                'funcDisplayGraph_RealTime(mobjTemporaryReadings.item(mobjTemporaryReadings.Count - 1).XaxisData, _
                '                          mobjTemporaryReadings.item(mobjTemporaryReadings.Count - 1).YaxisData)
                'End If
                'End If

                'If Val(arrData(2)) = EnumUVProtocol.CMD_End _
                'Or Val(arrData(2)) = EnumUVProtocol.Spect_End _
                'Or Val(arrData(2)) = EnumUVProtocol.CMD_Acknowledge Then

                'If Val(arrData(2)) = 0 Then 'EnumUVProtocol.CMD_End _


                'End If

                'If gblnSmoothFlag Then
                '    For intCount = (((ORDER - 1) / 2) - 1) To 0 Step -1
                '        funcDisplayGraph_RealTime(mobjTemporaryReadings.item((mobjTemporaryReadings.Count - 1) - intCount).XaxisData, _
                '                                  mobjTemporaryReadings.item((mobjTemporaryReadings.Count - 1) - intCount).YaxisData)
                '    Next
                'End If
                'End If
            End If

        Catch ex As Exception
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
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

#Region " IClient Private Function"

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
        ' Author                :   Santosh
        ' Created               :   Monday, April 12, 2004 15:12
        ' Revisions             :
        '=====================================================================

        Try
            funcIclientTaskCompleted = False

            ' If scan is terminated by user in between then gblnSpectrumTerminated = True
            If Not ArrlstGraphCurveItem Is Nothing Then
                If statStartGraph = True Then
                    If ArrlstGraphCurveItem.Count >= intCurveIndex + 1 Then
                        AASGraphUVSpectrum.StopOnlineGraph(ArrlstGraphCurveItem(intCurveIndex))
                        'intCurveIndex += 1
                    End If
                End If
            End If
            Application.DoEvents()
            AASGraphUVSpectrum.AldysPane.AxisChange()
            AASGraphUVSpectrum.Refresh()

            'If gblnSpectrumTerminated = True Then
            '    funcScanCompleted(False)
            'Else 'scan is completed 
            '    funcScanCompleted(True)
            'End If
            If mobjclsBgSpectrum.ThTerminate = True Then
                funcScanCompleted(False)
            Else
                funcScanCompleted(True)
            End If
            MenuBarUV.Enabled = True '----21.01.11
            'AddHandler mnuIgnite.Click, AddressOf btnIgnite_Click
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
            If Not ArrlstGraphCurveItem Is Nothing Then
                If statStartGraph = True Then
                    If ArrlstGraphCurveItem.Count >= intCurveIndex + 1 Then
                        AASGraphUVSpectrum.StopOnlineGraph(ArrlstGraphCurveItem(intCurveIndex))
                        'intCurveIndex += 1
                        AASGraphUVSpectrum.AldysPane.CurveList.Remove(AASGraphUVSpectrum.AldysPane.CurveList.Count - 1)
                        ArrlstGraphCurveItem.RemoveAt(ArrlstGraphCurveItem.Count - 1)
                    End If
                End If
            End If
            mobjOnlineChannel = New Channel(False)
            mobjOnlineReadings = New Readings
            mblnSpectrumStarted = False

            blnYetFileNotSave = False

            Application.DoEvents()
            AASGraphUVSpectrum.AldysPane.AxisChange()
            AASGraphUVSpectrum.Refresh()

            funcScanCompleted(False)
            Application.DoEvents()
            gobjMessageAdapter.ShowMessage(constSpectrumScanningFailed)
            Application.DoEvents()
            'gFuncShowMessage("Error...", "Spectrum scanning failed.", EnumMessageType.Information)
            'AddHandler mnuIgnite.Click, AddressOf btnIgnite_Click
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



            If m_blnBaseline = True Then
                If Not gintSample_adc Is Nothing Then
                    If gintSample_adc.Length > 0 Then
                        If blnCompleted Then
                            If Not (mobjclsBgSpectrum Is Nothing) Then
                                If mobjclsBgSpectrum.ThTerminate = False Then
                                    gblnBaseLine = True
                                End If
                            End If
                        End If
                    Else
                        gblnBaseLine = False
                    End If
                Else
                    gblnBaseLine = False
                End If
                btnBaseLine.Text = "&Baseline"
                btnBaseLine.Image = Image.FromFile(Application.StartupPath & "\Images\Base Line.ico")
                tlbbtnBaseLine.Text = "&Baseline"
                tlbbtnBaseLine.Image = Image.FromFile(Application.StartupPath & "\Images\Base Line.ico")
                mnuBaseLine.Text = "&Baseline"
                mnuBaseLine.Image = Image.FromFile(Application.StartupPath & "\Images\Base Line.ico")

                btnBaseLine.Enabled = True

                btnStart.Enabled = True
                mnuStart.Enabled = True
                tlbbtnStart.Enabled = True
                Me.mnuPeakEdit.Enabled = True
                Me.tlbbtnPeakEdit.Enabled = True
                Me.mnuShowXYValues.Enabled = True
                Me.tlbbtnShowXYValues.Enabled = True
                Me.AASGraphUVSpectrum.btnShowXYValues.Enabled = True
                Me.AASGraphUVSpectrum.btnPeakEdit.Enabled = True

                btnBaseLine.Refresh()
                btnStart.Refresh()
            Else
                btnStart.Text = "&Start"
                tlbbtnStart.Text = "&Start"
                mnuStart.Text = "&Start"
                btnStart.Image = Image.FromFile(Application.StartupPath & "\Images\start.ico")
                tlbbtnStart.Image = Image.FromFile(Application.StartupPath & "\Images\start.ico")
                mnuStart.Image = Image.FromFile(Application.StartupPath & "\Images\start.ico")
                Me.AASGraphUVSpectrum.btnShowXYValues.Enabled = True
                Me.AASGraphUVSpectrum.btnPeakEdit.Enabled = True
                Me.mnuPeakEdit.Enabled = True
                Me.tlbbtnPeakEdit.Enabled = True
                Me.mnuShowXYValues.Enabled = True
                Me.tlbbtnShowXYValues.Enabled = True
                btnStart.Enabled = True
                mnuStart.Enabled = True
                tlbbtnStart.Enabled = True
                btnBaseLine.Enabled = True
                btnStart.Refresh()
                btnBaseLine.Refresh()
                If Not funcSpectrumReadingCompleted() Then

                End If
                If Not AASGraphUVSpectrum.OfflineCurve Is Nothing Then
                    AASGraphUVSpectrum.OfflineCurve.Label = AASGraphUVSpectrum.YAxisLabel
                End If
            End If

            'funcTimerStartStop(mTimer, EnumTimerStartStop.Timer_Start)
            func_Enable_Disable(EnumProcesses.StartScan, EnumStart_End.End_of_Process)
            Call func_Enable_DisableControl(True)
            'gblnSpectrumTerminated = False
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
            blnYetFileNotSave = True
            mintChannelIndex = intChannel_no
            mobjChannnels(mintChannelIndex).UVParameter = mobjParameters

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

#End Region

#Region " Graph Method"

    Private Function funcGraphPreRequisite(ByVal intScanmode As Integer, ByVal intXmin As Double, ByVal intXmax As Double, ByVal intYmin As Double, ByVal intYmax As Double) As Boolean
        '=====================================================================
        ' Procedure Name        :   funcGraphPreRequisite
        ' Description           :   to set graph prerequisite.
        ' Purpose               :   
        '                           
        ' Parameters Passed     :   intScanmode, intXmin, intXmax, intYmin, intYmax
        ' Returns               :   True, if successful.
        ' Parameters Affected   :   
        ' Assumptions           :   Graph pre-requisites are already been set.
        ' Dependencies          :   None.
        ' Author                :   Sachin Dokhale
        ' Created               :   08.12.06
        ' Revisions             :
        '=====================================================================
        Dim dblDiffX As Double
        Dim dblMajorStepX, dblMinorStepX As Double
        Dim dblDiffY As Double
        Dim dblMajorStepY, dblMinorStepY As Double
        Dim intXDivisableFactor As Integer = 10
        Dim intYDivisableFactor As Integer = 10
        Try

            dblDiffX = Fix(intXmax - intXmin)
            dblMajorStepX = dblDiffX / intXDivisableFactor
            dblMinorStepX = dblMajorStepX / 2

            'dblMajorStepX = dblDiffX / dblMajorStepX
            'dblMinorStepX = dblMajorStepX / 5



            dblDiffY = (intYmax - intYmin)
            dblMajorStepY = dblDiffY / 10
            dblMinorStepY = dblMajorStepY / 2

            'Assigning Values to Xmin,xmax,ymin,ymax properties
            'AASEnergySpectrum.AldysPane.XAxis.Min = intXmin
            'AASEnergySpectrum.AldysPane.XAxis.Max = intXmax
            AASGraphUVSpectrum.btnPeakEdit.Enabled = True
            AASGraphUVSpectrum.btnShowXYValues.Enabled = True

            AASGraphUVSpectrum.AldysPane.XAxis.Min = intXmin
            AASGraphUVSpectrum.AldysPane.XAxis.Max = intXmax
            AASGraphUVSpectrum.XAxisMin = intXmin
            AASGraphUVSpectrum.XAxisMax = intXmax
            If (intXmin >= 1000 And intXDivisableFactor >= 10) Then
                AASGraphUVSpectrum.AldysPane.XAxis.ScaleFontSpec.Size = 11
            End If
            '--- Display the axis lables
            AASGraphUVSpectrum.XAxisLabel = "WAVELENGTH (nm)"
            'AxEnergySpectrum.XAxisLabel = "  Energy"

            Select Case gobjInst.Mode
                Case EnumCalibrationMode.AA, EnumCalibrationMode.AABGC, EnumCalibrationMode.MABS
                    AASGraphUVSpectrum.YAxisMin = intYmin
                    AASGraphUVSpectrum.YAxisMax = intYmax
                    AASGraphUVSpectrum.YAxisLabel = "ABSORBANCE"
                    AASGraphUVSpectrum.YAxisStep = 0.1
                Case EnumCalibrationMode.D2E
                    AASGraphUVSpectrum.YAxisMin = intYmin
                    AASGraphUVSpectrum.YAxisMax = intYmax
                    If (gblnUVABS) = True Then
                        AASGraphUVSpectrum.YAxisLabel = "ABSORBANCE"
                        AASGraphUVSpectrum.YAxisStep = 0.1
                    Else
                        AASGraphUVSpectrum.YAxisLabel = "TRANSMISSION"
                        AASGraphUVSpectrum.YAxisStep = 10
                        'AASGraphUVSpectrum.AldysPane.Legend.IsVisible = True
                    End If

                Case EnumCalibrationMode.HCLE
                    AASGraphUVSpectrum.YAxisMin = intYmin
                    AASGraphUVSpectrum.YAxisMax = intYmax
                    AASGraphUVSpectrum.YAxisLabel = "ABSORBANCE"
                    AASGraphUVSpectrum.YAxisStep = 0.1
                Case EnumCalibrationMode.EMISSION
                    AASGraphUVSpectrum.YAxisMin = intYmin
                    AASGraphUVSpectrum.YAxisMax = intYmax
                    AASGraphUVSpectrum.YAxisLabel = "EMISSION"
                    AASGraphUVSpectrum.YAxisStep = 1
                Case EnumCalibrationMode.SELFTEST
                    AASGraphUVSpectrum.YAxisMin = intYmin
                    AASGraphUVSpectrum.YAxisMax = intYmax
                    'AASEnergySpectrum.AldysPane.YAxis.Min = intYmin
                    'AASEnergySpectrum.AldysPane.YAxis.Max = intYmax
                    AASGraphUVSpectrum.YAxisLabel = "VOLT(mV)"
                    AASGraphUVSpectrum.YAxisStep = 1
            End Select

            AASGraphUVSpectrum.XAxisStep = dblMajorStepX
            AASGraphUVSpectrum.XAxisMinorStep = dblMinorStepX
            AASGraphUVSpectrum.YAxisStep = dblMajorStepY
            AASGraphUVSpectrum.YAxisMinorStep = dblMinorStepY
            AASGraphUVSpectrum.AldysPane.AxisChange()
            mnuGrid.Checked = True
            Me.AASGraphUVSpectrum.IsShowGrid = True
            mnuGrid.Checked = Me.AASGraphUVSpectrum.IsShowGrid
            Me.AASGraphUVSpectrum.btnPeakEdit.Checked = False
            mnuLegends.Checked = AASGraphUVSpectrum.AldysPane.Legend.IsVisible
            AASGraphUVSpectrum.Invalidate()
            AASGraphUVSpectrum.Refresh()
            Application.DoEvents()
            'AxSpectrumGraph.ysubdiv = 1
            'AxSpectrumGraph.XdivFormat = "#0.0"

            'If mnuRemoveGrid.Checked = True Then
            '    mnuRemoveGrid.Checked = True
            '    AxSpectrumGraph.Gridcolor = System.Drawing.Color.White
            'Else
            '    '------substitute color of grid if u want to display grid
            '    mnuRemoveGrid.Checked = False
            '    AxSpectrumGraph.Gridcolor = System.Drawing.Color.Gray
            '    'changed by sns on 30sep2004 for printing effect
            '    'AxSpectrumGraph.Gridcolor = System.Drawing.Color.Black
            'End If

            'AxSpectrumGraph.RefreshGraph()

            '//----------------------
            'addataSpect.dblWvMin = 230.0
            'addataSpect.dblWvMax = 250.0

            'Select Case gobjInst.Mode
            '    Case EnumCalibrationMode.AA, EnumCalibrationMode.AABGC, EnumCalibrationMode.MABS
            '        addataSpect.dblYmin = const_YMinAbs
            '        addataSpect.dblYMax = const_YMaxAbs
            '    Case EnumCalibrationMode.HCLE, EnumCalibrationMode.D2E
            '        addataSpect.dblYmin = const_YMinEnergy
            '        addataSpect.dblYMax = const_YMaxEnergy
            '    Case EnumCalibrationMode.EMISSION
            '        addataSpect.dblYmin = const_YMinEmission
            '        addataSpect.dblYMax = const_YMaxEmission
            '    Case EnumCalibrationMode.SELFTEST
            '        addataSpect.dblYmin = const_YMinmVolt
            '        addataSpect.dblYMax = const_YMaxmVolt
            'End Select
            '//---------------------
            'Added by pankaj bamb on 16 May 2007 3.44 for formating graph scale
            gobjClsAAS203.Calculate_Analysis_Graph_Param(AASGraphUVSpectrum, ClsAAS203.enumChangeAxis.xyAxis)
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

    'Private Function funcDisplayGraph(ByVal objChannel As Channel, ByVal Xmin As Double, ByVal Xmax As Double, ByVal Ymin As Double, ByVal Ymax As Double) As Boolean
    '    '--- this function has been overloaded to be used only to
    '    '-- suscces the functionality of the Zoom by Coordinates
    '    '-- modf by Nilesh Shirode on 11 Feb 2004
    '    Dim lngDataCount As Long
    '    Dim objReadingCol As New Readings
    '    Dim dblFromX As Double
    '    Dim dblFromY As Double
    '    Dim dblToX As Double
    '    Dim dblToY As Double
    '    'Dim intSpeed As Integer

    '    Try
    '        AxSpectrumGraph.clear()

    '        '--- Set the parameters for the graph control
    '        If Not funcGraphPreRequisite(objChannel, Xmin, Xmax, Ymin, Ymax) Then
    '            gFuncShowMessage("Error", "Error in setting the graph parameters.", modConstants.EnumMessageType.Information)
    '            Return False
    '            Exit Function
    '        End If

    '        '--- Set the graph name and scan speed
    '        lblSpectrumName.Text = objChannel.Parameter.ChannelName


    '        'use this for loop if u want to pass value using plotpointMethod
    '        'Substitute 2 with Number of Values to be Displayed
    '        dblFromX = Xmax
    '        dblFromY = Ymax

    '        '--- Get the speed
    '        'intSpeed = funcGetSpeed(objChannel.Parameter.WavelengthMin, objChannel.Parameter.WavelengthMax)

    '        '--------Extracting Values from Data Object
    '        For lngDataCount = gFuncGetIndexWv(Xmin, True) To gFuncGetIndexWv(Xmax, True) Step +objChannel.Parameter.CalculatedSpeed
    '            'For lngDataCount = 0 To objChannel.Spectrums.item(0).Readings.Count - 2 Step +intSpeed
    '            '--- Check for the graph plotted on the screen

    '            dblToX = objChannel.Spectrums.item(0).Readings.item(lngDataCount).XaxisData
    '            dblToY = objChannel.Spectrums.item(0).Readings.item(lngDataCount).YaxisData

    '            '--- Check if the X-coordinates and Y-coordinates are less than
    '            '--- Xmin and Ymin
    '            If objChannel.Spectrums.item(0).Readings.item(lngDataCount).YaxisData < Ymin Then
    '                dblToY = Ymin
    '            End If

    '            If objChannel.Spectrums.item(0).Readings.item(lngDataCount).YaxisData > Ymax Then
    '                dblToY = Ymax
    '            End If

    '            '--- Check if the wavelength is equal to the min wv as loop starts from min
    '            If objChannel.Spectrums.item(0).Readings.item(lngDataCount).XaxisData = Xmin Then
    '                AxSpectrumGraph.PlotPoint(dblToX, dblToY, dblToX, dblToY, gSetColor(mintChannelIndex))
    '            Else
    '                AxSpectrumGraph.PlotPoint(dblFromX, dblFromY, dblToX, dblToY, gSetColor(mintChannelIndex))
    '            End If

    '            '--- Check if the X-coordinates and Y-coordinates are less than
    '            '--- Xmin and Ymin
    '            If dblToY < Ymin Then
    '                dblToY = Ymin
    '            End If

    '            If objChannel.Spectrums.item(0).Readings.item(lngDataCount).YaxisData > Ymax Then
    '                dblToY = Ymax
    '            End If

    '            dblFromX = dblToX
    '            dblFromY = dblToY

    '        Next

    '        AxSpectrumGraph.Refresh()
    '        Return True

    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        'Error Handling and logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = ex.Message
    '        gobjErrorHandler.WriteErrorLog(ex)
    '        gobjErrorHandler.ProcessError(ErrorHandler.EnumErrorType.Critical, ex)
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
                                         ByVal dblYAxis As Double) As Boolean
        '=====================================================================
        ' Procedure Name        :   funcDisplayGraph_RealTime
        ' Description           :   Plot the graph on the screen.
        ' Purpose               :   To plot the graph on the screen for the given
        '                           Wavelength and absorbtion.           
        ' Parameters Passed     :   dblXAxis , dblYAxis 
        ' Returns               :   True, if successful.
        ' Parameters Affected   :   
        ' Assumptions           :   Graph pre-requisites are already been set.
        ' Dependencies          :   None.
        ' Author                :   Sachin Dokhale
        ' Created               :   08.12.06
        ' Revisions             :
        '=====================================================================
        Dim dblToX As Double
        Dim dblToY As Double

        Try
            '--- Plot the graph for the given coordinates.
            dblToX = dblXAxis
            dblToY = dblYAxis

            '--- Check if the X-coordinates and Y-coordinates are less than
            '--- Xmin and Ymin
            'If dblAbs < mobjParameter.YaxisMin Then
            '    dblToY = mobjParameter.YaxisMin
            'End If
            'addataSpect.dblYmin = const_YMinAbs
            'addataSpect.dblYMax = const_YMaxAbs
            dblYAxis = gfuncGetValueInSpectrum(dblToY, gobjInst.Mode)
            'get absorbance

            'lblWvPos.Text = Format(dblToX, "#0.0")
            'lblYValue.Text = Format(dblYAxis, "#0.000")   'Format(mobjTemporaryReadings.item(mobjTemporaryReadings.Count - 1).YaxisData, "#0.0")


            lblWvPos.Text = mXValueLable & Format(dblToX, "#0.0")
            lblYValue.Text = mYValueLable & Format(dblYAxis, "#0.000")


            'If dblYAxis < mobjParameters.YaxisMin Then
            '    dblYAxis = mobjParameters.YaxisMin
            'End If

            'If dblYAxis > mobjParameters.YaxisMax Then
            '    dblYAxis = mobjParameters.YaxisMax
            'End If

            ' mobjChannnels(mintChannelIndex).Spectrums(0).Readings(0).XaxisData = dblToX
            ' mobjChannnels(mintChannelIndex).Spectrums(0).Readings(0).YaxisData = dblToY

            '--- Check if the wavelength is equal to the max wv

            If dblXAxis = mobjParameters.XaxisMin Then
                'mGraphCurveItem = AASEnergySpectrum.StartOnlineGraph("Energy Spectrum", AASEnergySpectrum.GetColor(500), AldysGraph.SymbolType.NoSymbol)

                'ArrlstGraphCurveItem.Add(mGraphCurveItem)
                'intCurveIndex += 1
                'ArrlstGraphCurveItem.Item(intCurveIndex) = AASGraphUVSpectrum.StartOnlineGraph("Energy Spectrum", Color.Red, AldysGraph.SymbolType.NoSymbol)
                mGraphCurveItem = Nothing
                intCurveIndex += 1
                'const_GraphLedgend
                If m_blnBaseline = True Then
                    'mGraphCurveItem = AASGraphUVSpectrum.StartOnlineGraph("Baseline", AASGraphUVSpectrum.GetColor(intCurveIndex), AldysGraph.SymbolType.NoSymbol)
                    mGraphCurveItem = AASGraphUVSpectrum.StartOnlineGraph("", AASGraphUVSpectrum.GetColor(intCurveIndex), AldysGraph.SymbolType.NoSymbol)
                Else
                    'mGraphCurveItem = AASGraphUVSpectrum.StartOnlineGraph(AASGraphUVSpectrum.YAxisLabel & " " & (intCurveIndex + 1).ToString, AASGraphUVSpectrum.GetColor(intCurveIndex), AldysGraph.SymbolType.NoSymbol)
                    mGraphCurveItem = AASGraphUVSpectrum.StartOnlineGraph(const_GraphLedgend, AASGraphUVSpectrum.GetColor(intCurveIndex), AldysGraph.SymbolType.NoSymbol)
                End If
                statStartGraph = True
                ArrlstGraphCurveItem.Add(mGraphCurveItem)
                'AASGraphUVSpectrum.PlotPoint(ArrlstGraphCurveItem.Item(intCurveIndex), dblXAxis, dblYAxis)
                AASGraphUVSpectrum.PlotPoint(ArrlstGraphCurveItem.Item(intCurveIndex), dblXAxis, dblYAxis)

                'AASEnergySpectrum.AldysPane.AxisChange()
                'AASGraphUVSpectrum.Refresh()
                'Application.DoEvents()
            Else
                'AxEnergySpectrum.PlotPoint(mdblXaxis, mdblYaxis, dblToX, dblToY, gSetColor(mintColor))
                'AASEnergySpectrum.PlotPoint(mGraphCurveItem, dblXAxis, (dblYAxis / 10))
                If statStartGraph = True Then
                    AASGraphUVSpectrum.PlotPoint(ArrlstGraphCurveItem.Item(intCurveIndex), dblXAxis, dblYAxis)
                End If
                'AASGraphUVSpectrum.AldysPane.AxisChange()
                'AASGraphUVSpectrum.Refresh()
                'Application.DoEvents()
            End If



            lblWvPos.Refresh()
            lblYValue.Refresh()
            Application.DoEvents()

            '--- Check if the X-coordinates and Y-coordinates are less than
            '--- Xmin and Ymin

            'If dblToY < mobjTemporaryChannel.Parameter.YaxisMin Then
            '    dblToY = mobjTemporaryChannel.Parameter.YaxisMin
            'Else
            '    mdblYaxis = dblToY
            'End If

            mdblYaxis = dblToY
            mdblXaxis = dblToX
            'AxSpectrumGraph.Refresh()

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

    Friend Function funcDisplayGraph(ByVal objChannel As Spectrum.Channel, Optional ByRef objCurveItem As Object = Nothing) As Boolean
        '=====================================================================
        ' Procedure Name        :   funcDisplayGraph
        ' Description           :   Plot the graph on the screen.
        ' Purpose               :   To Plot the offlien graph
        ' Parameters Passed     :   objChannel, Optional ByRef objCurveItem 
        ' Returns               :   True, if successful.
        ' Parameters Affected   :   
        ' Assumptions           :   
        ' Dependencies          :   None.
        ' Author                :   Sachin Dokhale
        ' Created               :   08.12.06
        ' Revisions             :
        '=====================================================================
        Dim lngDataCount As Long
        Dim objReadingCol As New Spectrum.Readings
        Dim dblFromX As Double
        Dim dblFromY As Double
        Dim dblToX As Double
        Dim dblToY As Double
        ' Dim intSpeed As Integer

        Try
            ''--- This is done when the Print overlay functionality is operated
            ''--- because graph should come as overlay
            'If mblnGraphClear_Flag = True Then
            '    AxSpectrumGraph.clear()
            'End If

            '--- Set the parameters for the graph control
            'If Not funcGraphPreRequisite(objChannel) Then
            '    gFuncShowMessage("Error", "Error in setting the parameters for graphical display.", modConstants.EnumMessageType.Information)
            '    Return False
            'End If

            '--- Set the graph name and scan speed
            'lblSpectrumName.Text = objChannel.Parameter.ChannelName

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

            'use this for loop if u want to pass value using plotpointMethod
            'Substitute 2 with Number of Values to be Displayed
            'dblFromX = objChannel.Parameter.WavelengthMax
            'dblFromY = objChannel.Parameter.YaxisMin
            If Not objChannel Is Nothing Then


                If objChannel.Spectrums.Count > 0 Then
                    dblFromX = objChannel.UVParameter.XaxisMax
                    dblFromY = objChannel.UVParameter.YaxisMin

                    '--- Get the speed
                    'intSpeed = funcGetSpeed(objChannel.Parameter.WavelengthMin, objChannel.Parameter.WavelengthMax)

                    '--------Extracting Values from Data Object

                    'If objChannel.Parameter.CalculatedSpeed = 0 Then
                    '    objChannel.Parameter.CalculatedSpeed = gFuncGetSpeed(objChannel.Parameter.WavelengthMin, objChannel.Parameter.WavelengthMax)
                    '    If objChannel.Parameter.CalculatedSpeed = 0 Then
                    '        objChannel.Parameter.CalculatedSpeed = 1
                    '    End If
                    'End If

                    'dblYAxis = gfuncGetValueInSpectrum(dblToY, gobjInst.Mode)

                    'For lngDataCount = gFuncGetIndexWv(objChannel.Parameter.WavelengthMin, True) To gFuncGetIndexWv(objChannel.Parameter.WavelengthMax, True) Step +objChannel.Parameter.CalculatedSpeed
                    Dim dtPlotValue As New DataTable
                    Dim dtColXaxis As New DataColumn("Xaxis", GetType(Double))
                    Dim dtColYaxis As New DataColumn("Yaxis", GetType(Double))
                    Dim dtRow As DataRow

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
                        'If dblToY < objChannel.UVParameter.YaxisMin Then
                        '    dblToY = objChannel.UVParameter.YaxisMin()
                        'End If

                        'If dblToY > objChannel.UVParameter.YaxisMax Then
                        '    dblToY = objChannel.UVParameter.YaxisMax
                        'End If
                        dtRow = dtPlotValue.NewRow

                        dtRow(0) = dblToX
                        dtRow(1) = dblToY
                        dtPlotValue.Rows.Add(dtRow)

                        '--- Check if the wavelength is equal to the min wv
                        'If objChannel.Spectrums.item(0).Readings.item(lngDataCount).XaxisData = objChannel.Parameter.WavelengthMax _
                        'Or objChannel.Spectrums.item(0).Readings.item(lngDataCount).XaxisData = objChannel.Parameter.WavelengthMin Then
                        'If objChannel.Spectrums.item(0).Readings.item(lngDataCount).XaxisData = objChannel.Parameter.WavelengthMin Then
                        '    AxSpectrumGraph.PlotPoint(dblToX, dblToY, dblToX, dblToY, gSetColor(mintChannelIndex))
                        'Else
                        '    AxSpectrumGraph.PlotPoint(dblFromX, dblFromY, dblToX, dblToY, gSetColor(mintChannelIndex))
                        'End If

                        '--- Check if the X-coordinates and Y-coordinates are less than
                        '--- Xmin and Ymin
                        'If dblToY < objChannel.Parameter.YaxisMin Then
                        '    dblToY = objChannel.Parameter.YaxisMin
                        'End If

                        'If objChannel.Spectrums.item(0).Readings.item(lngDataCount).YaxisData > objChannel.Parameter.YaxisMax Then
                        '    dblToY = objChannel.Parameter.YaxisMax
                        'End If

                    Next

                    dtRow = dtPlotValue.NewRow

                    dtRow(0) = dblToX
                    dtRow(1) = dblToY
                    dtPlotValue.Rows.Add(dtRow)

                    AASGraphUVSpectrum.GraphDataSource = dtPlotValue
                    objCurveItem = AASGraphUVSpectrum.PlotGraph()
                    If Not AASGraphUVSpectrum.OfflineCurve Is Nothing Then
                        If mobjParameters.IsBaseline = False Then
                            AASGraphUVSpectrum.OfflineCurve.Label = const_GraphLedgend  'AASGraphUVSpectrum.YAxisLabel
                        Else
                            AASGraphUVSpectrum.OfflineCurve.Label = ""  '"Baseline"
                        End If
                    End If

                    'mGraphCurveItem = AASEnergySpectrum.PlotGraph()
                    AASGraphUVSpectrum.Refresh()
                    Application.DoEvents()
                End If
            End If
            Application.DoEvents()
            AASGraphUVSpectrum.Refresh()
            Application.DoEvents()
            'commented by sns on 310304
            'AxSpectrumGraph.RefreshGraph()
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
        ' Procedure Name        :   funcClearGraph
        ' Description           :   to clear graph.
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
        ''this is called for clearing a spectrum
        Dim lngDataCount As Long
        'Dim objReadingCol As New Spectrum.Readings
        Dim dblFromX As Double
        Dim dblFromY As Double
        Dim dblToX As Double
        Dim dblToY As Double


        Try

            '--- Set the graph name and scan speed
            'lblSpectrumName.Text = objChannel.Parameter.ChannelName

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

            'use this for loop if u want to pass value using plotpointMethod
            'Substitute 2 with Number of Values to be Displayed
            'dblFromX = objChannel.Parameter.WavelengthMax
            'dblFromY = objChannel.Parameter.YaxisMin

            '--- Get the speed
            'intSpeed = funcGetSpeed(objChannel.Parameter.WavelengthMin, objChannel.Parameter.WavelengthMax)

            '--------Extracting Values from Data Object

            'If objChannel.Parameter.CalculatedSpeed = 0 Then
            '    objChannel.Parameter.CalculatedSpeed = gFuncGetSpeed(objChannel.Parameter.WavelengthMin, objChannel.Parameter.WavelengthMax)
            '    If objChannel.Parameter.CalculatedSpeed = 0 Then
            '        objChannel.Parameter.CalculatedSpeed = 1
            '    End If
            'End If

            'dblYAxis = gfuncGetValueInSpectrum(dblToY, gobjInst.Mode)

            'For lngDataCount = gFuncGetIndexWv(objChannel.Parameter.WavelengthMin, True) To gFuncGetIndexWv(objChannel.Parameter.WavelengthMax, True) Step +objChannel.Parameter.CalculatedSpeed

            'dtPlotValue.Columns.Add(dtColXaxis)


            'mintChannelIndex = 0
            'mobjChannnels.Clear()
            'clear curve item
            ArrlstGraphCurveItem.Clear()
            'clear curve list
            AASGraphUVSpectrum.AldysPane.CurveList.Clear()
            'refresh graph
            AASGraphUVSpectrum.Refresh()
            'set curve index to -1
            intCurveIndex = -1

            Application.DoEvents()


            'Call AASGraphUVSpectrum.PlotGraph()

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
            ''this will enable/disble a grid
            mnuGrid.Checked = Not (mnuGrid.Checked)
            Me.AASGraphUVSpectrum.IsShowGrid = mnuGrid.Checked

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

            ''this is called when user click on menu peak
            mnuPeakEdit.Checked = Not (mnuPeakEdit.Checked)
            'Me.AASGraphUVSpectrum.IsShowGrid = mnuPeakEdit.Checked
            Me.AASGraphUVSpectrum.submnuPeakEdit_Click(sender, e)


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
            ''to show the XY position value on spectrum
            mnuShowXYValues.Checked = Not (mnuShowXYValues.Checked)
            Me.AASGraphUVSpectrum.ShowXYValues = mnuShowXYValues.Checked
            'Me.AASGraphUVSpectrum.submnuPeakEdit_Click(AASGraphUVSpectrum, System.EventArgs.Empty)


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
            ''for showing a legends on spectrum

            mnuLegends.Checked = Not (mnuLegends.Checked)
            Me.AASGraphUVSpectrum.AldysPane.Legend.IsVisible = mnuLegends.Checked
            AASGraphUVSpectrum.Invalidate()
            AASGraphUVSpectrum.Refresh()
            'Me.AASGraphUVSpectrum.submnuPeakEdit_Click(AASGraphUVSpectrum, System.EventArgs.Empty)


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

    Private Sub AASGraphUVSpectrum_GraphOptionChanged() Handles AASGraphUVSpectrum.GraphOptionChanged
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
            If AASGraphUVSpectrum.IsShowGrid = True Then
                mnuGrid.Checked = True
            Else
                mnuGrid.Checked = False
            End If
            AddHandler mnuGrid.Click, AddressOf mnuGrid_Click

            '//----- Check Legends on Graph
            RemoveHandler mnuLegends.Click, AddressOf mnuLegends_Click
            If AASGraphUVSpectrum.AldysPane.Legend.IsVisible = True Then
                mnuLegends.Checked = True
            Else
                mnuLegends.Checked = False
            End If
            AddHandler mnuLegends.Click, AddressOf mnuLegends_Click

            '//----- Check Show XY Values on Graph
            RemoveHandler mnuShowXYValues.Click, AddressOf mnuShowXYValues_Click
            If AASGraphUVSpectrum.ShowXYValues = True Then
                mnuShowXYValues.Checked = True
            Else
                mnuShowXYValues.Checked = False
            End If
            AddHandler mnuShowXYValues.Click, AddressOf mnuShowXYValues_Click

            RemoveHandler mnuPeakEdit.Click, AddressOf mnuPeakEdit_Click
            If AASGraphUVSpectrum.ShowXYPeak = True Then
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

    'Private Sub btnIgnite_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnIgnite.Click
    '    '=====================================================================
    '    ' Procedure Name        :   btnIgnite_Click
    '    ' Description           : handle click event
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
    '    ''note:
    '    ''this is called when user click on ignite button
    '    ''do some delay
    '    ''ignite flame by send protocol
    '    ''now get a current instrument parameter


    '    RemoveHandler btnIgnite.Click, AddressOf btnIgnite_Click
    '    If mblnAvoidProcessing = True Then
    '        Exit Sub
    '    End If
    '    Try

    '        mblnAvoidProcessing = True
    '        If Not IsNothing(gobjMain) Then
    '            'MsgBox("frmUV")
    '            'gobjMain.AutoIgnition()
    '            'communication delay
    '            Call gobjCommProtocol.mobjCommdll.subTime_Delay(100)
    '            Call gobjClsAAS203.funcIgnite(True)
    '            ''for ignite a flame
    '            Call funcGetInstParameter()
    '            ''for getting instrument parameter
    '        End If
    '        mblnAvoidProcessing = False
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
    '        AddHandler btnIgnite.Click, AddressOf btnIgnite_Click
    '        'objWait.Dispose()
    '        '---------------------------------------------------------
    '    End Try

    'End Sub

    'Private Sub btnN2OIgnite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    '=====================================================================
    '    ' Procedure Name        :   btnN2OIgnite_Click
    '    ' Description           :  handle a N2O Ignite event.
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
    '    ''note:
    '    ''this is called when user click on ignite button
    '    ''do some delay
    '    ''ignite flame by send protocol
    '    ''now get a current instrument parameter


    '    If mblnAvoidProcessing = True Then
    '        Exit Sub
    '    End If
    '    Try
    '        mblnAvoidProcessing = True
    '        Call gobjCommProtocol.mobjCommdll.subTime_Delay(100)
    '        ''delay
    '        Call gobjCommProtocol.funcSwitchOver()
    '        ''To Switch to N20 Flame
    '        Call funcGetInstParameter()
    '        ''get instrument current parameter.
    '        mblnAvoidProcessing = False
    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        'Error Handling and logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = ex.Message
    '        gobjErrorHandler.WriteErrorLog(ex)
    '        '---------------------------------------------------------
    '        mblnAvoidProcessing = False
    '    Finally
    '        '---------------------------------------------------------
    '        'Writing Execution log
    '        If CONST_CREATE_EXECUTION_LOG = 1 Then
    '            gobjErrorHandler.WriteExecutionLog()
    '        End If
    '        'objWait.Dispose()
    '        '---------------------------------------------------------
    '    End Try
    'End Sub

    'Private Sub btnExtinguish_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExtinguish.Click

    '    '=====================================================================
    '    ' Procedure Name        :   btnExtinguish_Click
    '    ' Description           :  handle a Extinguish Ignite event.
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
    '    ''note:
    '    ''this is called when user click on Extinuish button
    '    ''do some delay
    '    ''off flame by send protocol
    '    ''now get a current instrument parameter

    '    RemoveHandler btnExtinguish.Click, AddressOf btnExtinguish_Click
    '    If mblnAvoidProcessing = True Then
    '        Exit Sub
    '    End If
    '    Try
    '        mblnAvoidProcessing = True
    '        'gobjMain.Extinguish()
    '        Call gobjCommProtocol.mobjCommdll.subTime_Delay(100)
    '        ''delay
    '        Call gobjClsAAS203.funcIgnite(False)
    '        ''for ignition off.
    '        Call funcGetInstParameter()
    '        ''for getting instrument parameter.
    '        mblnAvoidProcessing = False
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
    '        AddHandler btnExtinguish.Click, AddressOf btnExtinguish_Click
    '        'objWait.Dispose()
    '        '---------------------------------------------------------
    '    End Try

    'End Sub

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
                Call gobjClsAAS203.funcInstReset()

            Else
                'Call gobjMessageAdapter.ShowMessage("Alt - R", "Alt - R")
                Call Application.DoEvents()
            End If
            mblnAvoidProcessing = False
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

    Private Sub MenuBarEnergySpectrumMode_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MenuBarUV.KeyUp
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
            If mblnAvoidProcessing = True Then
                Exit Sub
            End If
            mblnAvoidProcessing = True
            If e.Alt = True Then
                Select Case e.KeyCode
                    Case Keys.I
                        'Call btnIgnite_Click(sender, e)
                    Case Keys.C
                        'btnN2OIgnite_Click(sender, e)
                    Case Keys.E
                        'Call btnExtinguish_Click(sender, e)
                    Case Keys.D
                        'Call gobjMainService.funcAltDelete()
                        Call btnDelete_Click(sender, e)
                    Case Keys.R
                        Call btnR_Click(sender, e)
                    Case Keys.Q

                End Select
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

    Private Sub frmUVScanningSpectrumMode_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated

        '=====================================================================
        ' Procedure Name        :  frmUVScanningSpectrumMode_Activated
        ' Description           :  for activated UV spectrum.
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
            If blnActivateStartUVSpectrum = False Then
                Call funcSetDefaultParameter()
                ''for setting default instrument parameters like .
                nudD2Cur.Visible = True
                nudPMT.Visible = True
                'nudPMT_Ref.Visible = True
                nudSlit.Visible = True
                'nudSlit_Ref.Visible = True
                'nudHCLCur.Visible = True
                'nudBurnerHeight.Visible = True
                'nudFuelRatio.Visible = True
                blnActivateStartUVSpectrum = True
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

End Class
