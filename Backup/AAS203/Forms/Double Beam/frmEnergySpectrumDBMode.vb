Imports System.Threading
Imports AAS203.Common
Imports BgThread
Imports System.IO
Imports Microsoft.VisualBasic
Imports AAS203.Spectrum

Public Class frmEnergySpectrumDBMode
    Inherits System.Windows.Forms.Form
    Implements Iclient

#Region " Private Variable "
    '--- Declaration for the controller object of the BgThread
    Private mobjController As New BgThread.clsBgThread(Me)
    Private mobjclsBgSpectrum As clsBgSpectrum


    'Public WithEvents Status As System.Windows.Forms.TextBox
    Public WithEvents Status As System.Windows.Forms.TextBox

    Private mdblFuelRatio As Double = 0.0
    Private dblBhHeight As Double = 0.0

    Private mblnSpectrumStarted As Boolean
    Private mblnAvoidProcessing As Boolean = False
    Private mblnParameterProcessing As Boolean = False
    '//----- Graph Items
    Private mdblYaxis As Double
    Private mdblXaxis As Double
    Private mGraphCurveItem As AldysGraph.CurveItem
    Private ArrlstGraphCurveItem As New ArrayList
    Private intCurveIndex As Integer = -1
    '//-----
    Private m_blnBaseline As Boolean = True
    Private statStartGraph As Boolean = False
    Private mAvoidProcessBtn As Boolean = False
    Private Structure _Data
        Dim mGraphPlot As Boolean
        Dim mXaxisData As Integer
        Dim mYaxisData As Integer
    End Structure
    'Dim Data As _Data
    '--- declaration of the channels object (collection)
    Private mobjChannnels As New Spectrum.Channels
    Private mobjEnegyChannel As New Spectrum.EnergyChannels
    Private mobjOnlineChannel As New Spectrum.Channel(True)
    Private mobjOnlineReadings As New Spectrum.Readings
    Private mobjSpectrum As New clsSpectrum

    '--- declaration of the Parameter object used to populate the 
    '--- parameter screen on the spectrum screen
    Private mobjParameters As New Spectrum.EnergySpectrumParameter
    '--- Current channel index
    Private mintChannelIndex As Integer = -1
    '----- Store the Peak and Valley
    Private mStuctPeaksValley(100) As clsSpectrum.PeakValley

    Private strPath As IO.Directory

    Private blnYetFileNotSave As Boolean = False
    Private mYValueLable As String = const_Absorbance
    Private mXValueLable As String = "Wavelength (nm) : "
    Private CheckMaxPosition As Boolean = False
    Private WithEvents mobjfrmEditValues As frmEditValues
    Private mSelectedBeamType As enumSelectBeamType
    Private mstrSelectedBeamType As String
    Private blnIsRefBeamSelected As Boolean = False

    Private blnActivateStartEnergySpectrum As Boolean = False 'Saurabh11.08.07
    Private mblnReSetSpectrumParameter As Boolean = False

    Private m_bytCalibMode As Integer

#End Region

#Region " Constant"
    Private Const ConstFormLoad = " Energy Spectrum Mode"
    'Private Const const_WvMin = 217.18
    'Private Const const_WvMax = 317.18
    Private Const const_WvMin = 0.0
    Private Const const_WvMax = 100.0
    Private Const const_YMinAbs = 0.0
    Private Const const_YMaxAbs = 1.0
    Private Const const_YMaxEnergy = 100
    Private Const const_YMinEnergy = 0.0
    Private Const const_YMinEmission = 0.0
    Private Const const_YMaxEmission = 100.0
    Private Const const_YMinmVolt = -5000.0
    Private Const const_YMaxmVolt = 5000.0
    'Private Const const_YMinmVolt = 0.0
    'Private Const const_YMaxmVolt = 4000.0

    Private Const const_Absorbance = "Absorbance: "
    Private Const const_Energy = "Energy : "
    Private Const const_Emission = "Emission : "
    Private Const const_Volt = "Volt(mv) : "
#End Region

#Region "Properties"
    Private Property IsRefBeamSelected() As Boolean
        Get
            Return blnIsRefBeamSelected
        End Get
        Set(ByVal Value As Boolean)
            blnIsRefBeamSelected = Value

            If IsRefBeamSelected = True Then
                btnRef.Checked = True
                btnSample.Checked = False
            Else
                btnRef.Checked = False
                btnSample.Checked = True
            End If
        End Set
    End Property

    Private Property WvStartRange() As Double
        Get
            Return M_WvStartRange       ' Module level variable
        End Get
        Set(ByVal Value As Double)
            M_WvStartRange = Value
        End Set
    End Property

    Private Property WvLastRange() As Double
        Get
            Return M_WvLastRange       ' Module level variable
        End Get
        Set(ByVal Value As Double)
            M_WvLastRange = Value
        End Set
    End Property
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
    Friend WithEvents CustomPanelMain As GradientPanel.CustomPanel
    Friend WithEvents CustomPanelTop As GradientPanel.CustomPanel
    Friend WithEvents lblSlitWidthnm As System.Windows.Forms.Label
    Friend WithEvents lblD2CurmA As System.Windows.Forms.Label
    Friend WithEvents cmbModes As System.Windows.Forms.ComboBox
    Friend WithEvents lblModes As System.Windows.Forms.Label
    Friend WithEvents lblSpeed As System.Windows.Forms.Label
    Friend WithEvents cmbSpeed As System.Windows.Forms.ComboBox
    Friend WithEvents lblSlitWidth As System.Windows.Forms.Label
    Friend WithEvents lblD2Cur As System.Windows.Forms.Label
    Friend WithEvents lblPMT As System.Windows.Forms.Label
    Friend WithEvents CustomPanelBottom As GradientPanel.CustomPanel
    Friend WithEvents btnStart As NETXP.Controls.XPButton
    Friend WithEvents btnClearSpectrum As NETXP.Controls.XPButton
    Friend WithEvents mnuDataProcessing As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuSmooth As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuPeakPick As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuLoadSpectrunFile As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuSaveSpectrumFile As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents CommandBarSeparatorItem1 As NETXP.Controls.Bars.CommandBarSeparatorItem
    Friend WithEvents mnuFile As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuParameters As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuExit As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents btnLampParameters As NETXP.Controls.XPButton
    Friend WithEvents lblHCLCur As System.Windows.Forms.Label
    Friend WithEvents lblHCLCurmA As System.Windows.Forms.Label
    Friend WithEvents btnReturn As NETXP.Controls.XPButton
    Friend WithEvents MenuBarEnergySpectrumMode As NETXP.Controls.Bars.CommandBar
    Friend WithEvents lblFuelRatio As System.Windows.Forms.Label
    Friend WithEvents lblBurnerHeight As System.Windows.Forms.Label
    Friend WithEvents lblBurnerHeightmm As System.Windows.Forms.Label
    Friend WithEvents mnuOthers As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuPositionToMaxima As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents CommandBarSeparatorItem2 As NETXP.Controls.Bars.CommandBarSeparatorItem
    Friend WithEvents mnuContiniousTimeScan As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents StatusBar1 As NETXP.Controls.Bars.StatusBar
    Friend WithEvents StatusBarPanelInfo As System.Windows.Forms.StatusBarPanel
    Friend WithEvents ProgressPanel As NETXP.Controls.Bars.ProgressPanel
    Friend WithEvents StatusBarPanelDate As System.Windows.Forms.StatusBarPanel
    Friend WithEvents cmdChangeScale As NETXP.Controls.XPButton
    Friend WithEvents AASEnergySpectrum As AAS203.AASGraph
    Friend WithEvents lblYValue As System.Windows.Forms.Label
    Friend WithEvents lblWvPos As System.Windows.Forms.Label
    Friend WithEvents HeaderLeft As CodeIntellects.Office2003Controls.Office2003Header
    Friend WithEvents Office2003Header1 As CodeIntellects.Office2003Controls.Office2003Header
    Friend WithEvents ToolBar As NETXP.Controls.Bars.CommandBar
    Friend WithEvents tlbbtnReturn As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents CommandBarSeparatorItem3 As NETXP.Controls.Bars.CommandBarSeparatorItem
    Friend WithEvents tlbbtnStart As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents tlbbtnLampParameters As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents tlbbtnClearSpectrum As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents tlbbtnChangeScale As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents tlbbtnLoadspectrumFile As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents tlbbtnSaveSpectrumFile As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents CommandBarSeparatorItem4 As NETXP.Controls.Bars.CommandBarSeparatorItem
    Friend WithEvents CommandBarSeparatorItem5 As NETXP.Controls.Bars.CommandBarSeparatorItem
    Friend WithEvents tlbbtnSmooth As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents tlbbtnPeakPick As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents tlbbtnPositionToMaxima As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents tlbbtnContiniousTimeScan As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents tlbbtnParameters As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents nudPMT As ValueEditor.ValueEditor
    Friend WithEvents nudFuelRatio As ValueEditor.ValueEditor
    Friend WithEvents nudSlit As ValueEditor.ValueEditor
    Friend WithEvents nudD2Cur As ValueEditor.ValueEditor
    Friend WithEvents nudHCLCur As ValueEditor.ValueEditor
    Friend WithEvents nudBurnerHeight As ValueEditor.ValueEditor
    Friend WithEvents nudSlit_Ref As ValueEditor.ValueEditor
    Friend WithEvents nudPMT_Ref As ValueEditor.ValueEditor
    Friend WithEvents lblPMT_Ref As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblPMTVolts As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents mnuGraphOptions As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents CommandBarButtonItem1 As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuAutoIgnition As NETXP.Controls.Bars.CommandBar
    Friend WithEvents mnuIgnite As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuExtinguish As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents CommandBarButtonItem2 As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents CommandBarButtonItem3 As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents tlbbtnPrintGraph As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents CommandBarButtonItem4 As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuPeakEdit As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuGrid As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuStart As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuClearSpectrum As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuLampParameters As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents CommandBarSeparatorItem6 As NETXP.Controls.Bars.CommandBarSeparatorItem
    Friend WithEvents tlbbtnPeakEdit As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents tlbbtnGrid As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents tlbbtnLegends As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents tlbbtnShowXYValues As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuPrintGraph As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuLegends As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuShowXYValues As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuChangeScale As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuOverlay As NETXP.Controls.Bars.CommandBarButtonItem 'by pankaj on 30 Nov 07
    Friend WithEvents grpBeamType As System.Windows.Forms.GroupBox
    Friend WithEvents btnSample As System.Windows.Forms.RadioButton
    Friend WithEvents btnRef As System.Windows.Forms.RadioButton
    Friend WithEvents btnDelete As NETXP.Controls.XPButton
    Friend WithEvents btnR As NETXP.Controls.XPButton
    Friend WithEvents btnExtinguish As NETXP.Controls.XPButton
    Friend WithEvents btnIgnite As NETXP.Controls.XPButton
    Friend WithEvents btnN2OIgnite As NETXP.Controls.XPButton
    Friend WithEvents TimerEnergyDisplay As System.Windows.Forms.Timer
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmEnergySpectrumDBMode))
        Me.CustomPanelMain = New GradientPanel.CustomPanel
        Me.CustomPanelBottom = New GradientPanel.CustomPanel
        Me.cmdChangeScale = New NETXP.Controls.XPButton
        Me.btnStart = New NETXP.Controls.XPButton
        Me.btnLampParameters = New NETXP.Controls.XPButton
        Me.btnClearSpectrum = New NETXP.Controls.XPButton
        Me.btnReturn = New NETXP.Controls.XPButton
        Me.btnDelete = New NETXP.Controls.XPButton
        Me.btnR = New NETXP.Controls.XPButton
        Me.Office2003Header1 = New CodeIntellects.Office2003Controls.Office2003Header
        Me.CustomPanelTop = New GradientPanel.CustomPanel
        Me.grpBeamType = New System.Windows.Forms.GroupBox
        Me.btnRef = New System.Windows.Forms.RadioButton
        Me.btnSample = New System.Windows.Forms.RadioButton
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblPMT_Ref = New System.Windows.Forms.Label
        Me.nudSlit_Ref = New ValueEditor.ValueEditor
        Me.nudPMT_Ref = New ValueEditor.ValueEditor
        Me.nudBurnerHeight = New ValueEditor.ValueEditor
        Me.nudHCLCur = New ValueEditor.ValueEditor
        Me.nudD2Cur = New ValueEditor.ValueEditor
        Me.nudSlit = New ValueEditor.ValueEditor
        Me.nudFuelRatio = New ValueEditor.ValueEditor
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
        Me.lblSpeed = New System.Windows.Forms.Label
        Me.cmbSpeed = New System.Windows.Forms.ComboBox
        Me.lblSlitWidth = New System.Windows.Forms.Label
        Me.lblD2Cur = New System.Windows.Forms.Label
        Me.lblPMT = New System.Windows.Forms.Label
        Me.AASEnergySpectrum = New AAS203.AASGraph
        Me.btnExtinguish = New NETXP.Controls.XPButton
        Me.btnIgnite = New NETXP.Controls.XPButton
        Me.btnN2OIgnite = New NETXP.Controls.XPButton
        Me.mnuDataProcessing = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuStart = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuLampParameters = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuSmooth = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuPeakPick = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuClearSpectrum = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuPrintGraph = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuLoadSpectrunFile = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuSaveSpectrumFile = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.CommandBarSeparatorItem1 = New NETXP.Controls.Bars.CommandBarSeparatorItem
        Me.mnuFile = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuParameters = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuExit = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.MenuBarEnergySpectrumMode = New NETXP.Controls.Bars.CommandBar
        Me.mnuAutoIgnition = New NETXP.Controls.Bars.CommandBar
        Me.mnuIgnite = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuExtinguish = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuGraphOptions = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuPeakEdit = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuGrid = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuLegends = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuShowXYValues = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuChangeScale = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuOverlay = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuOthers = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuPositionToMaxima = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.CommandBarSeparatorItem2 = New NETXP.Controls.Bars.CommandBarSeparatorItem
        Me.mnuContiniousTimeScan = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.StatusBar1 = New NETXP.Controls.Bars.StatusBar
        Me.StatusBarPanelInfo = New System.Windows.Forms.StatusBarPanel
        Me.ProgressPanel = New NETXP.Controls.Bars.ProgressPanel
        Me.StatusBarPanelDate = New System.Windows.Forms.StatusBarPanel
        Me.ToolBar = New NETXP.Controls.Bars.CommandBar
        Me.tlbbtnReturn = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.CommandBarSeparatorItem3 = New NETXP.Controls.Bars.CommandBarSeparatorItem
        Me.tlbbtnParameters = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.tlbbtnLoadspectrumFile = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.tlbbtnSaveSpectrumFile = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.CommandBarSeparatorItem4 = New NETXP.Controls.Bars.CommandBarSeparatorItem
        Me.tlbbtnStart = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.tlbbtnLampParameters = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.tlbbtnSmooth = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.tlbbtnPeakPick = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.tlbbtnClearSpectrum = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.tlbbtnChangeScale = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.tlbbtnPrintGraph = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.CommandBarSeparatorItem5 = New NETXP.Controls.Bars.CommandBarSeparatorItem
        Me.tlbbtnPeakEdit = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.tlbbtnGrid = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.tlbbtnLegends = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.tlbbtnShowXYValues = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.CommandBarSeparatorItem6 = New NETXP.Controls.Bars.CommandBarSeparatorItem
        Me.tlbbtnPositionToMaxima = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.tlbbtnContiniousTimeScan = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.CommandBarButtonItem1 = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.CommandBarButtonItem2 = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.CommandBarButtonItem3 = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.CommandBarButtonItem4 = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.TimerEnergyDisplay = New System.Windows.Forms.Timer(Me.components)
        Me.CustomPanelMain.SuspendLayout()
        Me.CustomPanelBottom.SuspendLayout()
        Me.CustomPanelTop.SuspendLayout()
        Me.grpBeamType.SuspendLayout()
        CType(Me.MenuBarEnergySpectrumMode, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuBarEnergySpectrumMode.SuspendLayout()
        CType(Me.mnuAutoIgnition, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StatusBarPanelInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProgressPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StatusBarPanelDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ToolBar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CustomPanelMain
        '
        Me.CustomPanelMain.BackColor = System.Drawing.Color.AliceBlue
        Me.CustomPanelMain.Controls.Add(Me.CustomPanelBottom)
        Me.CustomPanelMain.Controls.Add(Me.Office2003Header1)
        Me.CustomPanelMain.Controls.Add(Me.CustomPanelTop)
        Me.CustomPanelMain.Controls.Add(Me.AASEnergySpectrum)
        Me.CustomPanelMain.Controls.Add(Me.btnExtinguish)
        Me.CustomPanelMain.Controls.Add(Me.btnIgnite)
        Me.CustomPanelMain.Controls.Add(Me.btnN2OIgnite)
        Me.CustomPanelMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CustomPanelMain.Location = New System.Drawing.Point(0, 57)
        Me.CustomPanelMain.Name = "CustomPanelMain"
        Me.CustomPanelMain.Size = New System.Drawing.Size(804, 504)
        Me.CustomPanelMain.TabIndex = 3
        '
        'CustomPanelBottom
        '
        Me.CustomPanelBottom.BackColor = System.Drawing.Color.AliceBlue
        Me.CustomPanelBottom.Controls.Add(Me.cmdChangeScale)
        Me.CustomPanelBottom.Controls.Add(Me.btnStart)
        Me.CustomPanelBottom.Controls.Add(Me.btnLampParameters)
        Me.CustomPanelBottom.Controls.Add(Me.btnClearSpectrum)
        Me.CustomPanelBottom.Controls.Add(Me.btnReturn)
        Me.CustomPanelBottom.Controls.Add(Me.btnDelete)
        Me.CustomPanelBottom.Controls.Add(Me.btnR)
        Me.CustomPanelBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.CustomPanelBottom.Location = New System.Drawing.Point(184, 423)
        Me.CustomPanelBottom.Name = "CustomPanelBottom"
        Me.CustomPanelBottom.Size = New System.Drawing.Size(620, 81)
        Me.CustomPanelBottom.TabIndex = 1
        '
        'cmdChangeScale
        '
        Me.cmdChangeScale.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdChangeScale.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdChangeScale.Image = CType(resources.GetObject("cmdChangeScale.Image"), System.Drawing.Image)
        Me.cmdChangeScale.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdChangeScale.Location = New System.Drawing.Point(24, 28)
        Me.cmdChangeScale.Name = "cmdChangeScale"
        Me.cmdChangeScale.Size = New System.Drawing.Size(108, 38)
        Me.cmdChangeScale.TabIndex = 0
        Me.cmdChangeScale.Text = "Chan&ge Scale"
        Me.cmdChangeScale.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'btnStart
        '
        Me.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnStart.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStart.Image = CType(resources.GetObject("btnStart.Image"), System.Drawing.Image)
        Me.btnStart.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnStart.Location = New System.Drawing.Point(137, 28)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(108, 38)
        Me.btnStart.TabIndex = 1
        Me.btnStart.Text = "&Start"
        '
        'btnLampParameters
        '
        Me.btnLampParameters.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLampParameters.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLampParameters.Image = CType(resources.GetObject("btnLampParameters.Image"), System.Drawing.Image)
        Me.btnLampParameters.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLampParameters.Location = New System.Drawing.Point(250, 28)
        Me.btnLampParameters.Name = "btnLampParameters"
        Me.btnLampParameters.Size = New System.Drawing.Size(108, 38)
        Me.btnLampParameters.TabIndex = 2
        Me.btnLampParameters.Text = "&Lamp Parameters"
        Me.btnLampParameters.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'btnClearSpectrum
        '
        Me.btnClearSpectrum.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClearSpectrum.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClearSpectrum.Image = CType(resources.GetObject("btnClearSpectrum.Image"), System.Drawing.Image)
        Me.btnClearSpectrum.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClearSpectrum.Location = New System.Drawing.Point(366, 28)
        Me.btnClearSpectrum.Name = "btnClearSpectrum"
        Me.btnClearSpectrum.Size = New System.Drawing.Size(108, 38)
        Me.btnClearSpectrum.TabIndex = 3
        Me.btnClearSpectrum.Text = "Clear S&pectrum"
        Me.btnClearSpectrum.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'btnReturn
        '
        Me.btnReturn.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnReturn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnReturn.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReturn.Image = CType(resources.GetObject("btnReturn.Image"), System.Drawing.Image)
        Me.btnReturn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReturn.Location = New System.Drawing.Point(476, 28)
        Me.btnReturn.Name = "btnReturn"
        Me.btnReturn.Size = New System.Drawing.Size(108, 38)
        Me.btnReturn.TabIndex = 4
        Me.btnReturn.Text = "Return"
        '
        'btnDelete
        '
        Me.btnDelete.BackColor = System.Drawing.Color.Transparent
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelete.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDelete.Location = New System.Drawing.Point(216, 44)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(8, 8)
        Me.btnDelete.TabIndex = 138
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
        Me.btnR.Location = New System.Drawing.Point(228, 44)
        Me.btnR.Name = "btnR"
        Me.btnR.Size = New System.Drawing.Size(8, 8)
        Me.btnR.TabIndex = 137
        Me.btnR.TabStop = False
        Me.btnR.Text = "&R"
        Me.btnR.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'Office2003Header1
        '
        Me.Office2003Header1.BackColor = System.Drawing.SystemColors.Control
        Me.Office2003Header1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Office2003Header1.Location = New System.Drawing.Point(184, 0)
        Me.Office2003Header1.Name = "Office2003Header1"
        Me.Office2003Header1.Size = New System.Drawing.Size(620, 22)
        Me.Office2003Header1.TabIndex = 47
        Me.Office2003Header1.TitleFont = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Office2003Header1.TitleText = "Spectrum"
        '
        'CustomPanelTop
        '
        Me.CustomPanelTop.BackColor = System.Drawing.Color.AliceBlue
        Me.CustomPanelTop.Controls.Add(Me.grpBeamType)
        Me.CustomPanelTop.Controls.Add(Me.Label3)
        Me.CustomPanelTop.Controls.Add(Me.Label2)
        Me.CustomPanelTop.Controls.Add(Me.Label1)
        Me.CustomPanelTop.Controls.Add(Me.lblPMT_Ref)
        Me.CustomPanelTop.Controls.Add(Me.nudSlit_Ref)
        Me.CustomPanelTop.Controls.Add(Me.nudPMT_Ref)
        Me.CustomPanelTop.Controls.Add(Me.nudBurnerHeight)
        Me.CustomPanelTop.Controls.Add(Me.nudHCLCur)
        Me.CustomPanelTop.Controls.Add(Me.nudD2Cur)
        Me.CustomPanelTop.Controls.Add(Me.nudSlit)
        Me.CustomPanelTop.Controls.Add(Me.nudFuelRatio)
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
        Me.CustomPanelTop.Controls.Add(Me.lblSpeed)
        Me.CustomPanelTop.Controls.Add(Me.cmbSpeed)
        Me.CustomPanelTop.Controls.Add(Me.lblSlitWidth)
        Me.CustomPanelTop.Controls.Add(Me.lblD2Cur)
        Me.CustomPanelTop.Controls.Add(Me.lblPMT)
        Me.CustomPanelTop.Dock = System.Windows.Forms.DockStyle.Left
        Me.CustomPanelTop.Location = New System.Drawing.Point(0, 0)
        Me.CustomPanelTop.Name = "CustomPanelTop"
        Me.CustomPanelTop.Size = New System.Drawing.Size(184, 504)
        Me.CustomPanelTop.TabIndex = 0
        '
        'grpBeamType
        '
        Me.grpBeamType.Controls.Add(Me.btnRef)
        Me.grpBeamType.Controls.Add(Me.btnSample)
        Me.grpBeamType.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpBeamType.Location = New System.Drawing.Point(12, 338)
        Me.grpBeamType.Name = "grpBeamType"
        Me.grpBeamType.Size = New System.Drawing.Size(162, 70)
        Me.grpBeamType.TabIndex = 62
        Me.grpBeamType.TabStop = False
        Me.grpBeamType.Text = "Beam Type"
        '
        'btnRef
        '
        Me.btnRef.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRef.Location = New System.Drawing.Point(16, 44)
        Me.btnRef.Name = "btnRef"
        Me.btnRef.Size = New System.Drawing.Size(120, 18)
        Me.btnRef.TabIndex = 1
        Me.btnRef.Text = "Reference Beam"
        '
        'btnSample
        '
        Me.btnSample.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSample.Location = New System.Drawing.Point(16, 17)
        Me.btnSample.Name = "btnSample"
        Me.btnSample.Size = New System.Drawing.Size(124, 24)
        Me.btnSample.TabIndex = 0
        Me.btnSample.Text = "Sample Beam"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(147, 158)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(24, 18)
        Me.Label3.TabIndex = 61
        Me.Label3.Text = "nm"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(147, 71)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(32, 18)
        Me.Label2.TabIndex = 60
        Me.Label2.Text = "volts"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 185)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 28)
        Me.Label1.TabIndex = 59
        Me.Label1.Text = "Exit Slit Width"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPMT_Ref
        '
        Me.lblPMT_Ref.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPMT_Ref.Location = New System.Drawing.Point(8, 67)
        Me.lblPMT_Ref.Name = "lblPMT_Ref"
        Me.lblPMT_Ref.Size = New System.Drawing.Size(57, 20)
        Me.lblPMT_Ref.TabIndex = 58
        Me.lblPMT_Ref.Text = "Ref. PMT"
        Me.lblPMT_Ref.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'nudSlit_Ref
        '
        Me.nudSlit_Ref.BackColor = System.Drawing.SystemColors.Window
        Me.nudSlit_Ref.BackgroundColor = System.Drawing.SystemColors.Window
        Me.nudSlit_Ref.ButtonClicked = ValueEditor.ValueEditor.EnumValueEditorButtons.MainButton
        Me.nudSlit_Ref.ChangeFactor = 0
        Me.nudSlit_Ref.DecimalPlace = 0
        Me.nudSlit_Ref.DnButtonText = "6"
        Me.nudSlit_Ref.Enabled = False
        Me.nudSlit_Ref.ForeColor = System.Drawing.SystemColors.ControlText
        Me.nudSlit_Ref.ForegroundColor = System.Drawing.SystemColors.ControlText
        Me.nudSlit_Ref.IsReverseOperation = False
        Me.nudSlit_Ref.IsUpDownButtonToBeDisabledOnValueChange = False
        Me.nudSlit_Ref.Location = New System.Drawing.Point(72, 188)
        Me.nudSlit_Ref.MaxValue = 0
        Me.nudSlit_Ref.MinValue = 0
        Me.nudSlit_Ref.Name = "nudSlit_Ref"
        Me.nudSlit_Ref.Size = New System.Drawing.Size(72, 22)
        Me.nudSlit_Ref.TabIndex = 17
        Me.nudSlit_Ref.UpButtonText = "5"
        Me.nudSlit_Ref.Value = 0
        Me.nudSlit_Ref.ValueEditorEnabled = False
        Me.nudSlit_Ref.ValueEditorFont = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nudSlit_Ref.Visible = False
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
        Me.nudPMT_Ref.Location = New System.Drawing.Point(72, 64)
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
        'nudBurnerHeight
        '
        Me.nudBurnerHeight.BackColor = System.Drawing.SystemColors.Window
        Me.nudBurnerHeight.BackgroundColor = System.Drawing.SystemColors.Window
        Me.nudBurnerHeight.ButtonClicked = ValueEditor.ValueEditor.EnumValueEditorButtons.MainButton
        Me.nudBurnerHeight.ChangeFactor = 0
        Me.nudBurnerHeight.DecimalPlace = 0
        Me.nudBurnerHeight.DnButtonText = "6"
        Me.nudBurnerHeight.ForeColor = System.Drawing.SystemColors.ControlText
        Me.nudBurnerHeight.ForegroundColor = System.Drawing.SystemColors.ControlText
        Me.nudBurnerHeight.IsReverseOperation = False
        Me.nudBurnerHeight.IsUpDownButtonToBeDisabledOnValueChange = False
        Me.nudBurnerHeight.Location = New System.Drawing.Point(72, 250)
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
        'nudHCLCur
        '
        Me.nudHCLCur.BackColor = System.Drawing.SystemColors.Window
        Me.nudHCLCur.BackgroundColor = System.Drawing.SystemColors.Window
        Me.nudHCLCur.ButtonClicked = ValueEditor.ValueEditor.EnumValueEditorButtons.MainButton
        Me.nudHCLCur.ChangeFactor = 0
        Me.nudHCLCur.DecimalPlace = 1
        Me.nudHCLCur.DnButtonText = "6"
        Me.nudHCLCur.ForeColor = System.Drawing.SystemColors.ControlText
        Me.nudHCLCur.ForegroundColor = System.Drawing.SystemColors.ControlText
        Me.nudHCLCur.IsReverseOperation = False
        Me.nudHCLCur.IsUpDownButtonToBeDisabledOnValueChange = False
        Me.nudHCLCur.Location = New System.Drawing.Point(72, 95)
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
        Me.nudD2Cur.Location = New System.Drawing.Point(72, 126)
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
        Me.nudSlit.Location = New System.Drawing.Point(72, 157)
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
        'nudFuelRatio
        '
        Me.nudFuelRatio.BackColor = System.Drawing.SystemColors.Window
        Me.nudFuelRatio.BackgroundColor = System.Drawing.SystemColors.Window
        Me.nudFuelRatio.ButtonClicked = ValueEditor.ValueEditor.EnumValueEditorButtons.MainButton
        Me.nudFuelRatio.ChangeFactor = 0
        Me.nudFuelRatio.DecimalPlace = 0
        Me.nudFuelRatio.DnButtonText = "6"
        Me.nudFuelRatio.ForeColor = System.Drawing.SystemColors.ControlText
        Me.nudFuelRatio.ForegroundColor = System.Drawing.SystemColors.ControlText
        Me.nudFuelRatio.IsReverseOperation = False
        Me.nudFuelRatio.IsUpDownButtonToBeDisabledOnValueChange = False
        Me.nudFuelRatio.Location = New System.Drawing.Point(72, 219)
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
        Me.nudPMT.Location = New System.Drawing.Point(72, 33)
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
        Me.HeaderLeft.Location = New System.Drawing.Point(0, 0)
        Me.HeaderLeft.Name = "HeaderLeft"
        Me.HeaderLeft.Size = New System.Drawing.Size(184, 22)
        Me.HeaderLeft.TabIndex = 46
        Me.HeaderLeft.TitleFont = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HeaderLeft.TitleText = "Parameters"
        '
        'lblYValue
        '
        Me.lblYValue.BackColor = System.Drawing.Color.White
        Me.lblYValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblYValue.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblYValue.ForeColor = System.Drawing.Color.Blue
        Me.lblYValue.Location = New System.Drawing.Point(12, 447)
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
        Me.lblWvPos.Location = New System.Drawing.Point(12, 416)
        Me.lblWvPos.Name = "lblWvPos"
        Me.lblWvPos.Size = New System.Drawing.Size(166, 20)
        Me.lblWvPos.TabIndex = 44
        Me.lblWvPos.Text = "Wavelength (nm) :  "
        Me.lblWvPos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblBurnerHeightmm
        '
        Me.lblBurnerHeightmm.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBurnerHeightmm.Location = New System.Drawing.Point(147, 255)
        Me.lblBurnerHeightmm.Name = "lblBurnerHeightmm"
        Me.lblBurnerHeightmm.Size = New System.Drawing.Size(24, 18)
        Me.lblBurnerHeightmm.TabIndex = 36
        Me.lblBurnerHeightmm.Text = "mm"
        '
        'lblBurnerHeight
        '
        Me.lblBurnerHeight.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBurnerHeight.Location = New System.Drawing.Point(8, 252)
        Me.lblBurnerHeight.Name = "lblBurnerHeight"
        Me.lblBurnerHeight.Size = New System.Drawing.Size(62, 20)
        Me.lblBurnerHeight.TabIndex = 34
        Me.lblBurnerHeight.Text = "Burner Ht."
        Me.lblBurnerHeight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblFuelRatio
        '
        Me.lblFuelRatio.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFuelRatio.Location = New System.Drawing.Point(8, 221)
        Me.lblFuelRatio.Name = "lblFuelRatio"
        Me.lblFuelRatio.Size = New System.Drawing.Size(62, 20)
        Me.lblFuelRatio.TabIndex = 32
        Me.lblFuelRatio.Text = "Fuel Ratio"
        Me.lblFuelRatio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblHCLCurmA
        '
        Me.lblHCLCurmA.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHCLCurmA.Location = New System.Drawing.Point(147, 100)
        Me.lblHCLCurmA.Name = "lblHCLCurmA"
        Me.lblHCLCurmA.Size = New System.Drawing.Size(26, 18)
        Me.lblHCLCurmA.TabIndex = 31
        Me.lblHCLCurmA.Text = "mA"
        Me.lblHCLCurmA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblHCLCur
        '
        Me.lblHCLCur.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHCLCur.Location = New System.Drawing.Point(8, 97)
        Me.lblHCLCur.Name = "lblHCLCur"
        Me.lblHCLCur.Size = New System.Drawing.Size(57, 20)
        Me.lblHCLCur.TabIndex = 30
        Me.lblHCLCur.Text = "HCL Cur"
        Me.lblHCLCur.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSlitWidthnm
        '
        Me.lblSlitWidthnm.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSlitWidthnm.Location = New System.Drawing.Point(147, 187)
        Me.lblSlitWidthnm.Name = "lblSlitWidthnm"
        Me.lblSlitWidthnm.Size = New System.Drawing.Size(24, 18)
        Me.lblSlitWidthnm.TabIndex = 28
        Me.lblSlitWidthnm.Text = "nm"
        Me.lblSlitWidthnm.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPMTVolts
        '
        Me.lblPMTVolts.BackColor = System.Drawing.Color.Transparent
        Me.lblPMTVolts.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPMTVolts.Location = New System.Drawing.Point(147, 39)
        Me.lblPMTVolts.Name = "lblPMTVolts"
        Me.lblPMTVolts.Size = New System.Drawing.Size(32, 18)
        Me.lblPMTVolts.TabIndex = 27
        Me.lblPMTVolts.Text = "volts"
        Me.lblPMTVolts.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblD2CurmA
        '
        Me.lblD2CurmA.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblD2CurmA.Location = New System.Drawing.Point(147, 132)
        Me.lblD2CurmA.Name = "lblD2CurmA"
        Me.lblD2CurmA.Size = New System.Drawing.Size(22, 18)
        Me.lblD2CurmA.TabIndex = 26
        Me.lblD2CurmA.Text = "mA"
        Me.lblD2CurmA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbModes
        '
        Me.cmbModes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbModes.Items.AddRange(New Object() {"AA", "HCLE", "D2E", "EMISSION", "AABGC", "MABS", "SELFTEST"})
        Me.cmbModes.Location = New System.Drawing.Point(72, 311)
        Me.cmbModes.Name = "cmbModes"
        Me.cmbModes.Size = New System.Drawing.Size(82, 21)
        Me.cmbModes.TabIndex = 25
        Me.cmbModes.Visible = False
        '
        'lblModes
        '
        Me.lblModes.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblModes.Location = New System.Drawing.Point(8, 313)
        Me.lblModes.Name = "lblModes"
        Me.lblModes.Size = New System.Drawing.Size(57, 20)
        Me.lblModes.TabIndex = 8
        Me.lblModes.Text = "Modes"
        Me.lblModes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSpeed
        '
        Me.lblSpeed.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSpeed.Location = New System.Drawing.Point(8, 283)
        Me.lblSpeed.Name = "lblSpeed"
        Me.lblSpeed.Size = New System.Drawing.Size(57, 20)
        Me.lblSpeed.TabIndex = 7
        Me.lblSpeed.Text = "Speed"
        Me.lblSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbSpeed
        '
        Me.cmbSpeed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSpeed.Items.AddRange(New Object() {"FAST", "MEDIUM", "SLOW"})
        Me.cmbSpeed.Location = New System.Drawing.Point(72, 281)
        Me.cmbSpeed.Name = "cmbSpeed"
        Me.cmbSpeed.Size = New System.Drawing.Size(82, 21)
        Me.cmbSpeed.TabIndex = 24
        Me.cmbSpeed.Visible = False
        '
        'lblSlitWidth
        '
        Me.lblSlitWidth.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSlitWidth.Location = New System.Drawing.Point(8, 153)
        Me.lblSlitWidth.Name = "lblSlitWidth"
        Me.lblSlitWidth.Size = New System.Drawing.Size(57, 28)
        Me.lblSlitWidth.TabIndex = 5
        Me.lblSlitWidth.Text = "Entrance Slit Width"
        Me.lblSlitWidth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblD2Cur
        '
        Me.lblD2Cur.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblD2Cur.Location = New System.Drawing.Point(8, 127)
        Me.lblD2Cur.Name = "lblD2Cur"
        Me.lblD2Cur.Size = New System.Drawing.Size(57, 20)
        Me.lblD2Cur.TabIndex = 2
        Me.lblD2Cur.Text = "D2 Cur"
        Me.lblD2Cur.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPMT
        '
        Me.lblPMT.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPMT.Location = New System.Drawing.Point(10, 35)
        Me.lblPMT.Name = "lblPMT"
        Me.lblPMT.Size = New System.Drawing.Size(57, 24)
        Me.lblPMT.TabIndex = 1
        Me.lblPMT.Text = "Sample PMT"
        Me.lblPMT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'AASEnergySpectrum
        '
        Me.AASEnergySpectrum.AldysGraphCursor = Nothing
        Me.AASEnergySpectrum.AldysGraphPrintColor = System.Drawing.Color.Black
        Me.AASEnergySpectrum.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AASEnergySpectrum.BackColor = System.Drawing.Color.LightGray
        Me.AASEnergySpectrum.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AASEnergySpectrum.GraphDataSource = Nothing
        Me.AASEnergySpectrum.GraphImage = Nothing
        Me.AASEnergySpectrum.IsShowGrid = True
        Me.AASEnergySpectrum.Location = New System.Drawing.Point(184, 16)
        Me.AASEnergySpectrum.Name = "AASEnergySpectrum"
        Me.AASEnergySpectrum.Size = New System.Drawing.Size(618, 402)
        Me.AASEnergySpectrum.TabIndex = 25
        Me.AASEnergySpectrum.UseDefaultSettings = True
        Me.AASEnergySpectrum.XAxisDateMax = New Date(CType(0, Long))
        Me.AASEnergySpectrum.XAxisDateMin = New Date(CType(0, Long))
        Me.AASEnergySpectrum.XAxisDateScaleFormat = AAS203.AASGraph.enumDateScaleFormat.YYYY
        Me.AASEnergySpectrum.XAxisLabel = "X Values"
        Me.AASEnergySpectrum.XAxisMax = 100
        Me.AASEnergySpectrum.XAxisMin = 0
        Me.AASEnergySpectrum.XAxisMinorStep = 5
        Me.AASEnergySpectrum.XAxisScaleFormat = Nothing
        Me.AASEnergySpectrum.XAxisStep = 10
        Me.AASEnergySpectrum.XAxisType = AldysGraph.AxisType.Linear
        Me.AASEnergySpectrum.YAxisLabel = "Y Values"
        Me.AASEnergySpectrum.YAxisMax = 100
        Me.AASEnergySpectrum.YAxisMin = -1
        Me.AASEnergySpectrum.YAxisMinorStep = 5
        Me.AASEnergySpectrum.YAxisScaleFormat = Nothing
        Me.AASEnergySpectrum.YAxisStep = 10
        Me.AASEnergySpectrum.YAxisType = AldysGraph.AxisType.Linear
        '
        'btnExtinguish
        '
        Me.btnExtinguish.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExtinguish.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExtinguish.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExtinguish.Location = New System.Drawing.Point(382, 243)
        Me.btnExtinguish.Name = "btnExtinguish"
        Me.btnExtinguish.Size = New System.Drawing.Size(40, 18)
        Me.btnExtinguish.TabIndex = 48
        Me.btnExtinguish.TabStop = False
        Me.btnExtinguish.Text = "&Extinguish"
        Me.btnExtinguish.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'btnIgnite
        '
        Me.btnIgnite.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnIgnite.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIgnite.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnIgnite.Location = New System.Drawing.Point(380, 244)
        Me.btnIgnite.Name = "btnIgnite"
        Me.btnIgnite.Size = New System.Drawing.Size(44, 17)
        Me.btnIgnite.TabIndex = 49
        Me.btnIgnite.TabStop = False
        Me.btnIgnite.Text = "&Ignition"
        Me.btnIgnite.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'btnN2OIgnite
        '
        Me.btnN2OIgnite.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnN2OIgnite.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnN2OIgnite.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnN2OIgnite.Location = New System.Drawing.Point(400, 250)
        Me.btnN2OIgnite.Name = "btnN2OIgnite"
        Me.btnN2OIgnite.Size = New System.Drawing.Size(5, 5)
        Me.btnN2OIgnite.TabIndex = 137
        Me.btnN2OIgnite.TabStop = False
        Me.btnN2OIgnite.Text = "N2O&C"
        Me.btnN2OIgnite.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'mnuDataProcessing
        '
        Me.mnuDataProcessing.Items.AddRange(New NETXP.Controls.Bars.CommandBarItem() {Me.mnuStart, Me.mnuLampParameters, Me.mnuSmooth, Me.mnuPeakPick, Me.mnuClearSpectrum, Me.mnuPrintGraph})
        Me.mnuDataProcessing.Text = "Data &Processing"
        '
        'mnuStart
        '
        Me.mnuStart.Image = CType(resources.GetObject("mnuStart.Image"), System.Drawing.Image)
        Me.mnuStart.Shortcut = System.Windows.Forms.Shortcut.CtrlT
        Me.mnuStart.Text = "&Start"
        '
        'mnuLampParameters
        '
        Me.mnuLampParameters.Image = CType(resources.GetObject("mnuLampParameters.Image"), System.Drawing.Image)
        Me.mnuLampParameters.Shortcut = System.Windows.Forms.Shortcut.CtrlA
        Me.mnuLampParameters.Text = "Lamp Parameter"
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
        'mnuClearSpectrum
        '
        Me.mnuClearSpectrum.Image = CType(resources.GetObject("mnuClearSpectrum.Image"), System.Drawing.Image)
        Me.mnuClearSpectrum.Shortcut = System.Windows.Forms.Shortcut.CtrlC
        Me.mnuClearSpectrum.Text = "Clear Spectrum"
        '
        'mnuPrintGraph
        '
        Me.mnuPrintGraph.Image = CType(resources.GetObject("mnuPrintGraph.Image"), System.Drawing.Image)
        Me.mnuPrintGraph.Shortcut = System.Windows.Forms.Shortcut.CtrlG
        Me.mnuPrintGraph.Text = "Print Graph"
        '
        'mnuLoadSpectrunFile
        '
        Me.mnuLoadSpectrunFile.Image = CType(resources.GetObject("mnuLoadSpectrunFile.Image"), System.Drawing.Image)
        Me.mnuLoadSpectrunFile.Shortcut = System.Windows.Forms.Shortcut.CtrlL
        Me.mnuLoadSpectrunFile.Text = "&Load Spectrum File"
        '
        'mnuSaveSpectrumFile
        '
        Me.mnuSaveSpectrumFile.Image = CType(resources.GetObject("mnuSaveSpectrumFile.Image"), System.Drawing.Image)
        Me.mnuSaveSpectrumFile.Shortcut = System.Windows.Forms.Shortcut.CtrlS
        Me.mnuSaveSpectrumFile.Text = "&Save Spectrum File"
        '
        'mnuFile
        '
        Me.mnuFile.Infrequent = True
        Me.mnuFile.Items.AddRange(New NETXP.Controls.Bars.CommandBarItem() {Me.mnuParameters, Me.mnuLoadSpectrunFile, Me.mnuSaveSpectrumFile, Me.CommandBarSeparatorItem1, Me.mnuExit})
        Me.mnuFile.Text = "&File"
        '
        'mnuParameters
        '
        Me.mnuParameters.Image = CType(resources.GetObject("mnuParameters.Image"), System.Drawing.Image)
        Me.mnuParameters.Shortcut = System.Windows.Forms.Shortcut.CtrlP
        Me.mnuParameters.Text = "Parame&ters"
        '
        'mnuExit
        '
        Me.mnuExit.Image = CType(resources.GetObject("mnuExit.Image"), System.Drawing.Image)
        Me.mnuExit.Shortcut = System.Windows.Forms.Shortcut.CtrlR
        Me.mnuExit.ShowText = True
        Me.mnuExit.Text = "Return"
        '
        'MenuBarEnergySpectrumMode
        '
        Me.MenuBarEnergySpectrumMode.BackColor = System.Drawing.Color.Transparent
        Me.MenuBarEnergySpectrumMode.Controls.Add(Me.mnuAutoIgnition)
        Me.MenuBarEnergySpectrumMode.CustomizeText = "&Customize Toolbar..."
        Me.MenuBarEnergySpectrumMode.Dock = System.Windows.Forms.DockStyle.Top
        Me.MenuBarEnergySpectrumMode.FullRow = True
        Me.MenuBarEnergySpectrumMode.ID = 621
        Me.MenuBarEnergySpectrumMode.Items.AddRange(New NETXP.Controls.Bars.CommandBarItem() {Me.mnuFile, Me.mnuDataProcessing, Me.mnuGraphOptions, Me.mnuOthers})
        Me.MenuBarEnergySpectrumMode.Location = New System.Drawing.Point(0, 0)
        Me.MenuBarEnergySpectrumMode.Margins.Bottom = 1
        Me.MenuBarEnergySpectrumMode.Margins.Left = 1
        Me.MenuBarEnergySpectrumMode.Margins.Right = 1
        Me.MenuBarEnergySpectrumMode.Margins.Top = 1
        Me.MenuBarEnergySpectrumMode.Name = "MenuBarEnergySpectrumMode"
        Me.MenuBarEnergySpectrumMode.Size = New System.Drawing.Size(804, 23)
        Me.MenuBarEnergySpectrumMode.Style = NETXP.Controls.Bars.CommandBarStyle.Menu
        Me.MenuBarEnergySpectrumMode.TabIndex = 0
        Me.MenuBarEnergySpectrumMode.TabStop = False
        Me.MenuBarEnergySpectrumMode.Text = ""
        '
        'mnuAutoIgnition
        '
        Me.mnuAutoIgnition.BackColor = System.Drawing.Color.Transparent
        Me.mnuAutoIgnition.CustomizeText = "&Customize Toolbar..."
        Me.mnuAutoIgnition.FullRow = True
        Me.mnuAutoIgnition.ID = 5117
        Me.mnuAutoIgnition.Items.AddRange(New NETXP.Controls.Bars.CommandBarItem() {Me.mnuIgnite, Me.mnuExtinguish})
        Me.mnuAutoIgnition.Location = New System.Drawing.Point(540, 28)
        Me.mnuAutoIgnition.Margins.Bottom = 1
        Me.mnuAutoIgnition.Margins.Left = 1
        Me.mnuAutoIgnition.Margins.Right = 1
        Me.mnuAutoIgnition.Margins.Top = 1
        Me.mnuAutoIgnition.Name = "mnuAutoIgnition"
        Me.mnuAutoIgnition.Size = New System.Drawing.Size(112, 23)
        Me.mnuAutoIgnition.Style = NETXP.Controls.Bars.CommandBarStyle.Menu
        Me.mnuAutoIgnition.TabIndex = 2
        Me.mnuAutoIgnition.TabStop = False
        Me.mnuAutoIgnition.Text = "AutoIgnition"
        '
        'mnuIgnite
        '
        Me.mnuIgnite.Shortcut = System.Windows.Forms.Shortcut.CtrlI
        Me.mnuIgnite.Text = "Ignite"
        '
        'mnuExtinguish
        '
        Me.mnuExtinguish.PadHorizontal = 5
        Me.mnuExtinguish.Shortcut = System.Windows.Forms.Shortcut.CtrlE
        Me.mnuExtinguish.Text = "Extinguish"
        '
        'mnuGraphOptions
        '
        Me.mnuGraphOptions.Items.AddRange(New NETXP.Controls.Bars.CommandBarItem() {Me.mnuPeakEdit, Me.mnuGrid, Me.mnuLegends, Me.mnuShowXYValues, Me.mnuChangeScale, Me.mnuOverlay})
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
        '
        'mnuShowXYValues
        '
        Me.mnuShowXYValues.Image = CType(resources.GetObject("mnuShowXYValues.Image"), System.Drawing.Image)
        Me.mnuShowXYValues.Shortcut = System.Windows.Forms.Shortcut.CtrlO
        Me.mnuShowXYValues.Text = "SHOW X, Y VALUES"
        '
        'mnuChangeScale
        '
        Me.mnuChangeScale.Image = CType(resources.GetObject("mnuChangeScale.Image"), System.Drawing.Image)
        Me.mnuChangeScale.Text = "Change Scale"
        '
        'mnuOverlay
        '
        Me.mnuOverlay.Checked = True
        Me.mnuOverlay.Text = "&Overlay"
        Me.mnuOverlay.Visible = False
        '
        'mnuOthers
        '
        Me.mnuOthers.Items.AddRange(New NETXP.Controls.Bars.CommandBarItem() {Me.mnuPositionToMaxima, Me.CommandBarSeparatorItem2, Me.mnuContiniousTimeScan})
        Me.mnuOthers.Text = "&Others"
        '
        'mnuPositionToMaxima
        '
        Me.mnuPositionToMaxima.Image = CType(resources.GetObject("mnuPositionToMaxima.Image"), System.Drawing.Image)
        Me.mnuPositionToMaxima.Shortcut = System.Windows.Forms.Shortcut.CtrlX
        Me.mnuPositionToMaxima.Text = "&Position To Maxima"
        '
        'mnuContiniousTimeScan
        '
        Me.mnuContiniousTimeScan.Image = CType(resources.GetObject("mnuContiniousTimeScan.Image"), System.Drawing.Image)
        Me.mnuContiniousTimeScan.Shortcut = System.Windows.Forms.Shortcut.CtrlN
        Me.mnuContiniousTimeScan.Text = "&Continious Time Scan"
        '
        'StatusBar1
        '
        Me.StatusBar1.Location = New System.Drawing.Point(0, 561)
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
        Me.StatusBarPanelInfo.Width = 388
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
        Me.StatusBarPanelDate.MinWidth = 200
        Me.StatusBarPanelDate.Style = System.Windows.Forms.StatusBarPanelStyle.OwnerDraw
        Me.StatusBarPanelDate.Width = 200
        '
        'ToolBar
        '
        Me.ToolBar.BackColor = System.Drawing.Color.Transparent
        Me.ToolBar.CustomizeText = "&Customize Toolbar..."
        Me.ToolBar.Dock = System.Windows.Forms.DockStyle.Top
        Me.ToolBar.ID = 7406
        Me.ToolBar.Items.AddRange(New NETXP.Controls.Bars.CommandBarItem() {Me.tlbbtnReturn, Me.CommandBarSeparatorItem3, Me.tlbbtnParameters, Me.tlbbtnLoadspectrumFile, Me.tlbbtnSaveSpectrumFile, Me.CommandBarSeparatorItem4, Me.tlbbtnStart, Me.tlbbtnLampParameters, Me.tlbbtnSmooth, Me.tlbbtnPeakPick, Me.tlbbtnClearSpectrum, Me.tlbbtnChangeScale, Me.tlbbtnPrintGraph, Me.CommandBarSeparatorItem5, Me.tlbbtnPeakEdit, Me.tlbbtnGrid, Me.tlbbtnLegends, Me.tlbbtnShowXYValues, Me.CommandBarSeparatorItem6, Me.tlbbtnPositionToMaxima, Me.tlbbtnContiniousTimeScan})
        Me.ToolBar.Location = New System.Drawing.Point(0, 23)
        Me.ToolBar.Margins.Bottom = 1
        Me.ToolBar.Margins.Left = 1
        Me.ToolBar.Margins.Right = 1
        Me.ToolBar.Margins.Top = 1
        Me.ToolBar.MenuEnabled = False
        Me.ToolBar.Name = "ToolBar"
        Me.ToolBar.Size = New System.Drawing.Size(804, 34)
        Me.ToolBar.TabIndex = 1
        Me.ToolBar.TabStop = False
        Me.ToolBar.Text = ""
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
        Me.tlbbtnLoadspectrumFile.Shortcut = System.Windows.Forms.Shortcut.CtrlF
        Me.tlbbtnLoadspectrumFile.Text = "LOAD SPECTRUM FILE[CTRL+F]"
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
        'tlbbtnLampParameters
        '
        Me.tlbbtnLampParameters.Image = CType(resources.GetObject("tlbbtnLampParameters.Image"), System.Drawing.Image)
        Me.tlbbtnLampParameters.Shortcut = System.Windows.Forms.Shortcut.CtrlL
        Me.tlbbtnLampParameters.Text = "LAMP PARAMETERES[CTRL+L]"
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
        'tlbbtnPrintGraph
        '
        Me.tlbbtnPrintGraph.Image = CType(resources.GetObject("tlbbtnPrintGraph.Image"), System.Drawing.Image)
        Me.tlbbtnPrintGraph.Text = "Print Graph"
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
        Me.tlbbtnLegends.Text = "LEGENDS[CTRL+D]"
        '
        'tlbbtnShowXYValues
        '
        Me.tlbbtnShowXYValues.Image = CType(resources.GetObject("tlbbtnShowXYValues.Image"), System.Drawing.Image)
        Me.tlbbtnShowXYValues.Text = "SHOW X, Y VALUES[CTRL+O]"
        '
        'tlbbtnPositionToMaxima
        '
        Me.tlbbtnPositionToMaxima.Image = CType(resources.GetObject("tlbbtnPositionToMaxima.Image"), System.Drawing.Image)
        Me.tlbbtnPositionToMaxima.Shortcut = System.Windows.Forms.Shortcut.CtrlX
        Me.tlbbtnPositionToMaxima.Text = "POSITION TO MAXIMA[CTRL+"
        '
        'tlbbtnContiniousTimeScan
        '
        Me.tlbbtnContiniousTimeScan.Image = CType(resources.GetObject("tlbbtnContiniousTimeScan.Image"), System.Drawing.Image)
        Me.tlbbtnContiniousTimeScan.Shortcut = System.Windows.Forms.Shortcut.CtrlO
        Me.tlbbtnContiniousTimeScan.Text = "CONTINIOUS TIME SCAN[CTRL+O]"
        '
        'CommandBarButtonItem1
        '
        Me.CommandBarButtonItem1.Shortcut = System.Windows.Forms.Shortcut.CtrlG
        Me.CommandBarButtonItem1.Text = "&Graph Options"
        '
        'CommandBarButtonItem2
        '
        Me.CommandBarButtonItem2.Image = CType(resources.GetObject("CommandBarButtonItem2.Image"), System.Drawing.Image)
        Me.CommandBarButtonItem2.Shortcut = System.Windows.Forms.Shortcut.CtrlG
        Me.CommandBarButtonItem2.Text = "Print Graph"
        '
        'CommandBarButtonItem3
        '
        Me.CommandBarButtonItem3.Image = CType(resources.GetObject("CommandBarButtonItem3.Image"), System.Drawing.Image)
        Me.CommandBarButtonItem3.Shortcut = System.Windows.Forms.Shortcut.CtrlG
        Me.CommandBarButtonItem3.Text = "Print Graph"
        '
        'CommandBarButtonItem4
        '
        Me.CommandBarButtonItem4.Text = "&Graph Options"
        '
        'TimerEnergyDisplay
        '
        Me.TimerEnergyDisplay.Interval = 1000
        '
        'frmEnergySpectrumDBMode
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(804, 585)
        Me.Controls.Add(Me.CustomPanelMain)
        Me.Controls.Add(Me.StatusBar1)
        Me.Controls.Add(Me.ToolBar)
        Me.Controls.Add(Me.MenuBarEnergySpectrumMode)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimizeBox = False
        Me.Name = "frmEnergySpectrumDBMode"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Energy Spectrum Mode"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.CustomPanelMain.ResumeLayout(False)
        Me.CustomPanelBottom.ResumeLayout(False)
        Me.CustomPanelTop.ResumeLayout(False)
        Me.grpBeamType.ResumeLayout(False)
        CType(Me.MenuBarEnergySpectrumMode, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuBarEnergySpectrumMode.ResumeLayout(False)
        CType(Me.mnuAutoIgnition, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StatusBarPanelInfo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProgressPanel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StatusBarPanelDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ToolBar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Form Events"

    Private Sub frmEnergySpectrumMode_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If mblnAvoidProcessing = True Then
            Exit Sub
        End If
        Dim objWait As New CWaitCursor
        Try
            Application.DoEvents()
            cmdChangeScale.BringToFront()
            btnStart.BringToFront()

            MenuBarEnergySpectrumMode.BackColor = System.Drawing.Color.Gainsboro

            mblnAvoidProcessing = True
            ShowProgressBar(gstrTitleInstrumentType & ConstFormLoad)
            Call funcInitialise()
            TimerEnergyDisplay.Enabled = True
            Call HideProgressBar()
            'Saurabh 10.07.07 To bring status form in front
            gobjfrmStatus.Show()
            'Saurabh

            gobjclsTimer.subTimerStart(StatusBar1)
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
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub frmEnergySpectrumMode_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Try
            '        Call gobjMessageAdapter.ShowMessage(constCuvetteBurner)

            If mblnAvoidProcessing = True Then
                e.Cancel = True
                Exit Sub
            End If
            If Not gobjclsTimer Is Nothing Then
                gobjclsTimer.subTimerStop()
            End If
            
            '//---- Added by Sachin Dokhale. Stop the Timer Energy Display when closing the mode
            TimerEnergyDisplay.Enabled = False
            TimerEnergyDisplay.Stop()
            '//---- Added by Sachin Dokhale Set the previous default Calibration mode
            Call gobjCommProtocol.funcCalibrationMode(m_bytCalibMode)


            'If Not (gstructSettings.AppMode = EnumAppMode.DemoMode) Then
            If Not ((gstructSettings.AppMode = EnumAppMode.DemoMode) Or _
                    (gstructSettings.AppMode = EnumAppMode.DemoMode_201) Or _
                    (gstructSettings.AppMode = EnumAppMode.DemoMode_203D)) Then
                '//----- Added by Sachin Dokhale on 14.07.07
                If Not gstructSettings.ExeToRun = EnumApplicationMode.ServiceUtility Then
                    If Not IsNothing(gobjMain) Then
                        If gobjMain.mobjController.IsThreadRunning = False Then
                            gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay)
                            Application.DoEvents()
                            gobjMain.mobjController.Start(gobjclsBgFlameStatus)
                        End If
                    End If
                    gobjfrmStatus.Visible = True
                    Application.DoEvents()
                End If
            End If
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
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Try
            gobjclsTimer.subTimerStop()

            TimerEnergyDisplay.Enabled = False
            TimerEnergyDisplay.Stop()
            If mblnAvoidProcessing = True Then
                Exit Sub
            End If
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
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub mnuSaveSpectrumFile_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : mnuSaveSpectrumFile_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 15.11.06
        ' Revisions             : 
        '=====================================================================
        Dim SaveFileDialog1 As New SaveFileDialog
        Dim objWait As New CWaitCursor
        If mblnAvoidProcessing = True Then
            Exit Sub
        End If
        Try

            mblnAvoidProcessing = True
            'SaveFileDialog1.Filter = "Energy Spectrum File(*.spt)|*.spt"
            'SaveFileDialog1.Title = "Show an Energy Spectrum File"
            'SaveFileDialog1.ShowDialog()
            If gintInstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.DoubleBeam Then
                Call funcSaveSpectrumFile_Double()
            Else
                Call funcSaveSpectrumFile()
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

    Private Sub mnuLoadSpectrumFile_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : mnuLoadSpectrunFile_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 15.11.06
        ' Revisions             : 
        '=====================================================================

        Dim OpenFileDialog1 As New OpenFileDialog
        Dim objWait As New CWaitCursor
        If mblnAvoidProcessing = True Then
            Exit Sub
        End If
        Try

            mblnAvoidProcessing = True

            'OpenFileDialog1.Filter = "Energy Spectrum File(*.spt)|*.spt"
            'OpenFileDialog1.Title = "Show an Energy Spectrum File"
            'OpenFileDialog1.ShowDialog()
            If gintInstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.DoubleBeam Then
                Call funcLoadSpectrumFile_Double()
            Else
                Call funcLoadSpectrumFile()
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
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 15.11.06
        ' Revisions             : 
        '=====================================================================

        Dim objWait As New CWaitCursor
        If mblnAvoidProcessing = True Then
            Exit Sub
        End If
        Try



            mblnAvoidProcessing = True
            Call funcAbsConvertTransmission()

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

    Private Sub mnuSmoothGraph_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : mnuSmoothGraph_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 15.11.06
        ' Revisions             : 
        '=====================================================================

        Dim objWait As New CWaitCursor
        Try

            Call subSmoothGraph()

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

    Private Sub mnuContiniousTimeScan_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : mnuContiniousTimeScan_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To load the Energy Spectrum form
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 25.09.06
        ' Revisions             : 
        '=====================================================================
        Dim objfrmTimeScan As Object 'New frmTimeScanMode
        Dim objWait As New CWaitCursor

        Try
            If (gstructSettings.Enable21CFR = True) Then
                If Not funcCheckActivityAuthentication(enumActivityAuthentication.Energy_Spectrum_Mode, gstructUserDetails.Access) Then
                    Exit Sub
                End If
                gfuncInsertActivityLog(EnumModules.TimeScan, "TimeScan_Mode Accessed")
            End If

            TimerEnergyDisplay.Enabled = False
            TimerEnergyDisplay.Stop()
            gintSpectrumMode = modGlobalDeclarations.EnumSpectrumMode.TimeScan
            If gstructSettings.AppMode = EnumAppMode.FullVersion_203D Then
                If gintInstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.SingleBeam Or _
                            gintInstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.ReferenceBeam Then
                    'objfrmTimeScan = New frmTimeScanMode
                    objfrmTimeScan = New frmTimeScanDBMode
                Else
                    objfrmTimeScan = New frmTimeScanDBMode
                End If
                '//----- Modify by Sachin Dokhale 

            ElseIf gstructSettings.AppMode = EnumAppMode.FullVersion_203 Or _
                    gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
                objfrmTimeScan = New frmTimeScanMode
            Else
                If gintInstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.DoubleBeam Then
                    objfrmTimeScan = New frmTimeScanDBMode
                Else
                    'objfrmTimeScan = New frmTimeScanMode
                    objfrmTimeScan = New frmTimeScanDBMode
                End If
                '//-----
            End If

            'gobjclsTimer.subTimerStart(StatusBar1)
            gobjclsTimer.subTimerStop()
            If objfrmTimeScan.ShowDialog() = DialogResult.OK Then
                Application.DoEvents()
                gobjclsTimer.subTimerStart(StatusBar1)
            End If
            mblnReSetSpectrumParameter = True
            Call funcGetInstParameter()
            Call funcSetSpectrumParameter(gobjInst.Mode)
            gintSpectrumMode = modGlobalDeclarations.EnumSpectrumMode.EnergySpectrum

            gobjfrmStatus.Visible = True
            TimerEnergyDisplay.Start()
            TimerEnergyDisplay.Enabled = True
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
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            '---------------------------------------------------------
        End Try

    End Sub

    Private Sub btnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : btnStart_Click
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
            If mAvoidProcessBtn Then
                Exit Sub
            End If
            mAvoidProcessBtn = True
            'Added by pankaj on 2 Dec 07
            If mblnParameterProcessing = True Then
                Exit Sub
            End If
            '----
            TimerEnergyDisplay.Enabled = False
            If mblnSpectrumStarted = False Then
                Call subStartScan()
            Else
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
            'mblnAvoidProcessing = False
            btnStart.Focus()
            Application.DoEvents()
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
            If ReInitLampInstParameters = True Then
                Exit Sub
            End If
            'If Not (gstructSettings.AppMode = EnumAppMode.DemoMode) Then
            'If Not ((gstructSettings.AppMode = EnumAppMode.DemoMode) Or _
            '        (gstructSettings.AppMode = EnumAppMode.DemoMode_201) Or _
            '        (gstructSettings.AppMode = EnumAppMode.DemoMode_203D)) Then
            '    '//----- Added by Sachin Dokhale on 14.07.07
            '    If Not gstructSettings.ExeToRun = EnumApplicationMode.ServiceUtility Then
            '        If Not IsNothing(gobjMain) Then
            '            If gobjMain.mobjController.IsThreadRunning = True Then
            '                gobjMain.mobjController.Cancel()
            '                gobjCommProtocol.mobjCommdll.subTime_Delay(500)   '10.12.07
            '                Application.DoEvents()
            '            End If
            '        End If
            '    End If
            'End If
            TimerEnergyDisplay.Enabled = False
            subLampParameterChanged()
            TimerEnergyDisplay.Enabled = False
            'If Not (gstructSettings.AppMode = EnumAppMode.DemoMode) Then
            'If Not ((gstructSettings.AppMode = EnumAppMode.DemoMode) Or _
            '        (gstructSettings.AppMode = EnumAppMode.DemoMode_201) Or _
            '        (gstructSettings.AppMode = EnumAppMode.DemoMode_203D)) Then
            '    '//----- Added by Sachin Dokhale on 14.07.07
            '    If Not gstructSettings.ExeToRun = EnumApplicationMode.ServiceUtility Then
            '        If Not IsNothing(gobjMain) Then
            '            If gobjMain.mobjController.IsThreadRunning = False Then
            '                gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay)
            '                Application.DoEvents()
            '                gobjMain.mobjController.Start(gobjclsBgFlameStatus)
            '            End If
            '        End If
            '    End If
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
            'If Not (gstructSettings.AppMode = EnumAppMode.DemoMode) Then
            'If Not ((gstructSettings.AppMode = EnumAppMode.DemoMode) Or _
            '        (gstructSettings.AppMode = EnumAppMode.DemoMode_201) Or _
            '        (gstructSettings.AppMode = EnumAppMode.DemoMode_203D)) Then
            '    '//----- Added by Sachin Dokhale on 14.07.07
            '    If Not gstructSettings.ExeToRun = EnumApplicationMode.ServiceUtility Then
            '        If Not IsNothing(gobjMain) Then
            '            If gobjMain.mobjController.IsThreadRunning = True Then
            '                gobjMain.mobjController.Cancel()
            '                gobjCommProtocol.mobjCommdll.subTime_Delay(500)   '10.12.07
            '                Application.DoEvents()
            '            End If
            '        End If
            '    End If
            'End If

            'mblnAvoidProcessing = False
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
            Call subClearScan()
            AASEnergySpectrum.RemoveHighPeakLineLabel()
            Me.AASEnergySpectrum.disablePeakEdit() 'ADDED   by pankaj on 26 Aug 07 for pick edit bar
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

    Private Sub mnuPeakPick_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Call subPeakValley()

    End Sub

    Private Sub cmbSpeed_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : cmbSpeed_SelectedIndexChanged
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 12.12.06
        ' Revisions             : 
        '=====================================================================

        Dim objWait As New CWaitCursor
        If mblnAvoidProcessing = True Then
            Exit Sub
        End If
        Try


            mblnAvoidProcessing = True

            RemoveHandler cmbSpeed.SelectedIndexChanged, AddressOf cmbSpeed_SelectedIndexChanged

            If funcSetSpeed(cmbSpeed.SelectedIndex) = True Then
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

    Private Sub cmdOverlay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : cmdOverlay_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : 
        ' Description           : check for overlay grapph
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Pankaj Bamb
        ' Created               : 30.11.07
        ' Revisions             : 
        '=====================================================================
        mnuOverlay.Checked = Not mnuOverlay.Checked
    End Sub

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
        If mblnAvoidProcessing = True Then
            Exit Sub
        End If
        Dim objWait As New CWaitCursor
        Dim objfrmChangeScale As frmChangeScale

        Try

            mblnAvoidProcessing = True
            TimerEnergyDisplay.Enabled = False
            objfrmChangeScale = New frmChangeScale(mobjParameters, True)
            objfrmChangeScale.funcSetValidatingScale(gobjInst.Mode)
            If objfrmChangeScale.ShowDialog() = DialogResult.OK Then
                TimerEnergyDisplay.Enabled = False
                If Not objfrmChangeScale.SpectrumParameter Is Nothing Then
                    'If mobjParameters.XaxisMax < objfrmChangeScale.SpectrumParameter.XaxisMax Then

                    'End If

                    'If mobjParameters.XaxisMin > objfrmChangeScale.SpectrumParameter.XaxisMin Then

                    'End If

                    mobjParameters.XaxisMax = objfrmChangeScale.SpectrumParameter.XaxisMax
                    mobjParameters.XaxisMin = objfrmChangeScale.SpectrumParameter.XaxisMin
                    mobjParameters.YaxisMax = objfrmChangeScale.SpectrumParameter.YaxisMax
                    WvStartRange = mobjParameters.XaxisMin
                    WvLastRange = mobjParameters.XaxisMax
                    mobjParameters.YaxisMin = objfrmChangeScale.SpectrumParameter.YaxisMin
                    lblWvPos.Text = mXValueLable & gobjInst.WavelengthCur
                    If Not funcGraphPreRequisite(mobjParameters.Cal_Mode, _
                                    mobjParameters.XaxisMin, _
                                    mobjParameters.XaxisMax, _
                                    mobjParameters.YaxisMin, _
                                    mobjParameters.YaxisMax) Then
                        'Call gFuncShowMessage("Error in setting spectrum parameters", "Please Check Entered Spectrum Parameters", modConstants.EnumMessageType.Information)
                        Exit Sub
                    End If
                End If
                ' ------------Added By Pankaj on 8 May 07
                AASEnergySpectrum.XAxisMin = mobjParameters.XaxisMin
                AASEnergySpectrum.XAxisMax = mobjParameters.XaxisMax

                AASEnergySpectrum.YAxisMin = mobjParameters.YaxisMin
                AASEnergySpectrum.YAxisMax = mobjParameters.YaxisMax
                gobjClsAAS203.Calculate_Analysis_Graph_Param(AASEnergySpectrum, ClsAAS203.enumChangeAxis.xyAxis)
                '--------------
            End If
            objfrmChangeScale.Close()
            TimerEnergyDisplay.Enabled = True


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
            objfrmChangeScale.Dispose()
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            cmdChangeScale.Focus()
            mblnAvoidProcessing = False
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub mnuParameters_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : mnuParameters_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : 
        ' Description           : select index id for Calibration mode
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 13.02.06
        ' Revisions             : 
        '=====================================================================
        If mblnAvoidProcessing = True Then
            Exit Sub
        End If
        Dim objWait As New CWaitCursor
        Dim objfrmParameter As frmParameter
        Try

            mblnAvoidProcessing = True

            objfrmParameter = New frmParameter(mobjParameters)
            If objfrmParameter.ShowDialog() = DialogResult.OK Then
                If Not objfrmParameter.SpectrumParameter Is Nothing Then
                    If mobjParameters Is Nothing Then
                        mobjParameters = New Spectrum.EnergySpectrumParameter
                    End If
                    mobjParameters.SpectrumName = objfrmParameter.SpectrumParameter.SpectrumName
                    mobjParameters.Comments = objfrmParameter.SpectrumParameter.Comments
                End If
            End If
            objfrmParameter.Close()
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
            objfrmParameter.Dispose()
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            mblnAvoidProcessing = False
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub mnuPositionToMaxima_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : mnuPositionToMaxima_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : 
        ' Description           : Set Maxisise position
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 05.01.07
        ' Revisions             : 
        '=====================================================================
        If mblnAvoidProcessing = True Then
            Exit Sub
        End If
        Dim objWait As New CWaitCursor
        Dim intIsSetMaximisePosition As Integer
        Dim dblMaximisePosition As Double
        Dim i As Integer
        Dim blnIsPeakFound As Boolean = False
        Dim CourveCount As Integer
        Try

            mblnAvoidProcessing = True

            If mintChannelIndex > -1 And intCurveIndex > -1 Then
                'If (ArrlstGraphCurveItem.Count > 0) Then
                If Not ArrlstGraphCurveItem(intCurveIndex) Is Nothing Then
                    If (CheckMaxPosition = False) And (intCurveIndex > -1) Then
                        'intIsSetMaximisePosition = MsgBox(" Set Maximise Position ", MsgBoxStyle.YesNo)
                        If gobjMessageAdapter.ShowMessage(constSetMaximisePosition) Then
                            'If intIsSetMaximisePosition = MsgBoxResult.Yes Then
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
                            mnuPositionToMaxima.CheckType = NETXP.Controls.Bars.ButtonItemCheckType.Checkmark
                            mnuPositionToMaxima.Checked = True

                            AASEnergySpectrum.DrawHighestPeakLine(ArrlstGraphCurveItem(intCurveIndex))
                            AASEnergySpectrum.ShowHighPeakLineLabel("Maximise Position", False, 0)
                            For i = 0 To AASEnergySpectrum.AldysPane.CurveList.Count - 1
                                If AASEnergySpectrum.AldysPane.CurveList(i).IsHighPeakLine Then
                                    dblMaximisePosition = AASEnergySpectrum.AldysPane.CurveList(i).HighPeakXValue
                                    blnIsPeakFound = True
                                    Exit For
                                End If
                            Next
                            If blnIsPeakFound = True Then
                                If gobjCommProtocol.Wavelength_Position(dblMaximisePosition, lblWvPos) = True Then
                                    Call gobjCommProtocol.mobjCommdll.subTime_Delay(100)
                                End If
                                lblWvPos.Text = mXValueLable & gobjInst.WavelengthCur
                                lblWvPos.Refresh()
                                'lblYValue.Text = mYValueLable & FormatNumber(AASEnergySpectrum.AldysPane.CurveList(i).HighPeakYValue, 2)
                                'lblYValue.Refresh()
                                TimerEnergyDisplay.Enabled =True 
                            End If
                        End If
                    Else
                        mnuPositionToMaxima.Checked = False
                        AASEnergySpectrum.RemoveHighPeakLineLabel()

                        'If AASEnergySpectrum.AldysPane.CurveList.Count > 0 Then
                        For i = 0 To AASEnergySpectrum.AldysPane.CurveList.Count - 1
                            'If AASEnergySpectrum.AldysPane.CurveList.Count > 0 Then
                            If AASEnergySpectrum.AldysPane.CurveList(i).IsHighPeakLine() = True Then
                                AASEnergySpectrum.AldysPane.CurveList.RemoveAt(i)
                            End If
                            'End If
                        Next
                        'End If
                        'AASEnergySpectrum.AldysPane.CurveList(0).IsHighPeakLine = False
                        AASEnergySpectrum.Refresh()
                        'CheckMaxPosition = False
                    End If
                End If
                'End If
            End If
            TimerEnergyDisplay.Enabled = True
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

    Private Sub AASEnergySpectrum_GraphScaleChanged(ByVal XMin As Double, ByVal XMax As Double, ByVal YMin As Double, ByVal YMax As Double)
        '=====================================================================
        ' Procedure Name        :   AASEnergySpectrum_GraphScaleChanged
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
            mobjParameters.XaxisMax = XMax
            mobjParameters.XaxisMin = XMin
            WvStartRange = mobjParameters.XaxisMin
            WvLastRange = mobjParameters.XaxisMax
            mobjParameters.YaxisMax = YMax
            mobjParameters.YaxisMin = YMin
            If Not funcGraphPreRequisite(mobjParameters.Cal_Mode, _
                            mobjParameters.XaxisMin, _
                            mobjParameters.XaxisMax, _
                            mobjParameters.YaxisMin, _
                            mobjParameters.YaxisMax) Then

                'Call gFuncShowMessage("Error in setting spectrum parameters", "Please Check Entered Spectrum Parameters", modConstants.EnumMessageType.Information)
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

    Private Sub tlbbtnPrintGraph_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : tlbbtnPrintGraph_Click
        ' Parameters Passed     : Object, EventArgs
        ' Returns               : None
        ' Purpose               : 
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
            If (gstructSettings.Enable21CFR = True) Then
                If Not funcCheckActivityAuthentication(enumActivityAuthentication.Print, gstructUserDetails.Access) Then
                    Return
                    Exit Sub
                End If
                gfuncInsertActivityLog(EnumModules.Print, "Print Energy Spectrum Mode Graph Accessed")
            End If

            'If (toreported) Then 'OR NOT Method->RepReady )
            'gobjClsAAS203.SaveQuantResults(gobjNewMethod, A1, False)
            'toreported = False
            'AASEnergySpectrum.PrintPreViewGraph()
            objclsDataFileReport.DefaultFont = Me.DefaultFont()

            objclsDataFileReport.funcPrintEnergy(AASEnergySpectrum, mobjParameters, "")


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

#Region " Form Object "

    'Private Sub nudPMT_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '    nudPMT.Enabled = False
    '    mblnAvoidProcessing = True
    '    Call funcSetPmtVParameter(nudPMT.Value)
    '    mblnAvoidProcessing = False
    '    nudPMT.Enabled = True
    'End Sub

    Private Sub nudPMT_ValueChanged(ByVal ChangePmt As Double)
        Try

            'nudPMT.Enabled = False
            'If mblnAvoidProcessing = True Then
            '    Exit Sub
            'End If
            'mblnAvoidProcessing = True
            If Not (mobjclsBgSpectrum Is Nothing) Then
                mobjclsBgSpectrum.SpectrumWait = True
                Application.DoEvents()
            End If
            mblnParameterProcessing = True   'Added by pankaj on 2 Dec 07
            gobjCommProtocol.mobjCommdll.subTime_Delay(30)
            Application.DoEvents()
            Call funcSetPmtVParameter(nudPMT.Value)

            If Not (mobjclsBgSpectrum Is Nothing) Then
                mobjclsBgSpectrum.SpectrumWait = False
                Application.DoEvents()
                gobjCommProtocol.mobjCommdll.subTime_Delay(30)
                Application.DoEvents()
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
            'mblnAvoidProcessing = False
            'nudPMT.Enabled = True
            mblnParameterProcessing = False 'Added by pankaj on 2 Dec 07
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
        Dim dblReturnValue As Double
        Try
            'nudPMT.Enabled = False
            'If mblnAvoidProcessing = True Then
            '    Exit Sub
            'End If
            'mblnAvoidProcessing = True

            RemoveHandler nudPMT.ValueEditorClick, AddressOf nudPMT_ValueEditorClick
            Application.DoEvents()
            mblnParameterProcessing = True  'Added by pankaj on 2 Dec 07
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
            'nudPMT.Enabled = True
            'mblnAvoidProcessing = False
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            nudPMT.Focus()
            Application.DoEvents()
            mblnParameterProcessing = False 'Added by pankaj on 2 Dec 07
        End Try
    End Sub

    Private Sub nudPMT_Ref_ValueChanged(ByVal ChangePmt As Double)
        Try

            'nudPMT_Ref.Enabled = False
            'If mblnAvoidProcessing = True Then
            '    Exit Sub
            'End If
            'mblnAvoidProcessing = True
            mblnParameterProcessing = True  'Added by pankaj on 2 Dec 07
            Call funcSetPmtVParameter_Ref(nudPMT_Ref.Value)


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
            'mblnAvoidProcessing = False
            'nudPMT_Ref.Enabled = True
            mblnParameterProcessing = False 'Added by pankaj on 2 Dec 07
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
        Dim dblReturnValue As Double
        Try
            'nudPMT_Ref.Enabled = False
            'If mblnAvoidProcessing = True Then
            '    Exit Sub
            'End If
            'mblnAvoidProcessing = True

            RemoveHandler nudPMT_Ref.ValueEditorClick, AddressOf nudPMT_Ref_ValueEditorClick
            Application.DoEvents()
            mblnParameterProcessing = True  'Added by pankaj on 2 Dec 07
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
            'mblnAvoidProcessing = False
            AddHandler nudPMT_Ref.ValueEditorClick, AddressOf nudPMT_Ref_ValueEditorClick
            'nudPMT_Ref.Enabled = True
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            nudPMT_Ref.Focus()
            Application.DoEvents()
            mblnParameterProcessing = False 'Added by pankaj on 2 Dec 07
        End Try
    End Sub

    'Private Sub nudSlit_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    nudSlit.Enabled = False
    '    mblnAvoidProcessing = True
    '    Call funcSetSlit_WidthParameter(nudSlit.Value)
    '    mblnAvoidProcessing = False
    '    nudSlit.Enabled = True
    'End Sub

    Private Sub nudSlit_ValueChanged(ByVal ChangeSlit As Double)
        Try
            'nudSlit.Enabled = False
            'If mblnAvoidProcessing = True Then
            '    Exit Sub
            'End If
            'mblnAvoidProcessing = True

            'RemoveHandler btnStart.Click, AddressOf btnStart_Click
            'RemoveHandler btnLampParameters.Click, AddressOf btnLampParameters_Click

            'RemoveHandler nudBurnerHeight.ValueEditorClick, AddressOf nudBurnerHeight_ValueEditorClick
            'RemoveHandler nudSlit_Ref.ValueEditorClick, AddressOf nudSlit_Ref_ValueEditorClick
            'RemoveHandler nudFuelRatio.ValueEditorClick, AddressOf nudFuelRatio_ValueEditorClick
            'RemoveHandler nudBurnerHeight.ValueEditorValueChanged, AddressOf nudBurnerHeight_ValueChanged
            'RemoveHandler nudSlit_Ref.ValueEditorValueChanged, AddressOf nudSlit_Ref_ValueChanged
            'RemoveHandler nudFuelRatio.ValueEditorValueChanged, AddressOf nudFuelRatio_ValueChanged
            mblnParameterProcessing = True  'Added by pankaj on 2 Dec 07
            Call funcSetSlit_WidthParameter(nudSlit.Value)
            'by pankaj on 18.1.08
            nudSlit_Ref.Value = CDbl(gobjClsAAS203.funcGet_SlitWidth) 'CDbl(nudSlit.Value)  'by pankaj on 18.1.08
            RemoveHandler nudSlit.ValueEditorValueChanged, AddressOf nudSlit_ValueChanged 'by pankaj on 18.1.08
            nudSlit.Value = CDbl(gobjClsAAS203.funcGet_SlitWidth)  'CDbl(nudSlit.Value)  'by pankaj on 18.1.08
            AddHandler nudSlit.ValueEditorValueChanged, AddressOf nudSlit_ValueChanged 'by pankaj on 18.1.08
            nudSlit_Ref.Enabled = False 'by pankaj on 18.1.08
            '-----
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
            'nudSlit.Enabled = True
            'AddHandler btnStart.Click, AddressOf btnStart_Click
            'AddHandler btnLampParameters.Click, AddressOf btnLampParameters_Click

            'AddHandler nudBurnerHeight.ValueEditorClick, AddressOf nudBurnerHeight_ValueEditorClick
            'AddHandler nudSlit_Ref.ValueEditorClick, AddressOf nudSlit_Ref_ValueEditorClick
            'AddHandler nudFuelRatio.ValueEditorClick, AddressOf nudFuelRatio_ValueEditorClick
            'AddHandler nudBurnerHeight.ValueEditorValueChanged, AddressOf nudBurnerHeight_ValueChanged
            'AddHandler nudSlit_Ref.ValueEditorValueChanged, AddressOf nudSlit_Ref_ValueChanged
            'AddHandler nudFuelRatio.ValueEditorValueChanged, AddressOf nudFuelRatio_ValueChanged
            'mblnAvoidProcessing = False
            Application.DoEvents()
            mblnParameterProcessing = False 'Added by pankaj on 2 Dec 07
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
            'If mblnAvoidProcessing = True Then
            '    Exit Sub
            'End If
            'mblnAvoidProcessing = True

            RemoveHandler nudSlit.ValueEditorClick, AddressOf nudSlit_ValueEditorClick
            'RemoveHandler btnStart.Click, AddressOf btnStart_Click
            'RemoveHandler btnLampParameters.Click, AddressOf btnLampParameters_Click

            'RemoveHandler nudBurnerHeight.ValueEditorClick, AddressOf nudBurnerHeight_ValueEditorClick
            'RemoveHandler nudSlit_Ref.ValueEditorClick, AddressOf nudSlit_Ref_ValueEditorClick
            'RemoveHandler nudFuelRatio.ValueEditorClick, AddressOf nudFuelRatio_ValueEditorClick
            'RemoveHandler nudBurnerHeight.ValueEditorValueChanged, AddressOf nudBurnerHeight_ValueChanged
            'RemoveHandler nudSlit_Ref.ValueEditorValueChanged, AddressOf nudSlit_Ref_ValueChanged
            'RemoveHandler nudFuelRatio.ValueEditorValueChanged, AddressOf nudFuelRatio_ValueChanged
            mblnParameterProcessing = True  'Added by pankaj on 2 Dec 07
            Application.DoEvents()

            dblReturnValue = gobjClsAAS203.funcGet_SlitWidth(0)
            If funcSetFrmEditValue(dblReturnValue, "Set Entrance Slit Width (0.0 - 2.0)nm", nudSlit.MinValue, nudSlit.MaxValue) = True Then
                nudSlit.Value = dblReturnValue
            Else
                nudSlit.Value = gobjClsAAS203.funcGet_SlitWidth(0)
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
            AddHandler nudSlit.ValueEditorClick, AddressOf nudSlit_ValueEditorClick
            'AddHandler btnStart.Click, AddressOf btnStart_Click
            'AddHandler btnLampParameters.Click, AddressOf btnLampParameters_Click

            'AddHandler nudBurnerHeight.ValueEditorClick, AddressOf nudBurnerHeight_ValueEditorClick
            'AddHandler nudSlit_Ref.ValueEditorClick, AddressOf nudSlit_Ref_ValueEditorClick
            'AddHandler nudFuelRatio.ValueEditorClick, AddressOf nudFuelRatio_ValueEditorClick
            'AddHandler nudBurnerHeight.ValueEditorValueChanged, AddressOf nudBurnerHeight_ValueChanged
            'AddHandler nudSlit_Ref.ValueEditorValueChanged, AddressOf nudSlit_Ref_ValueChanged
            'AddHandler nudFuelRatio.ValueEditorValueChanged, AddressOf nudFuelRatio_ValueChanged
            'nudSlit.Enabled = True
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            nudSlit.Focus()
            mblnParameterProcessing = False 'Added by pankaj on 2 Dec 07
            Application.DoEvents()
        End Try
    End Sub

    Private Sub nudSlit_Ref_ValueChanged(ByVal ChangeSlit As Double)
        Try
            'nudSlit_Ref.Enabled = False
            'If mblnAvoidProcessing = True Then
            '    Exit Sub
            'End If
            'mblnAvoidProcessing = True

            'RemoveHandler btnStart.Click, AddressOf btnStart_Click
            'RemoveHandler btnLampParameters.Click, AddressOf btnLampParameters_Click

            'RemoveHandler nudBurnerHeight.ValueEditorClick, AddressOf nudBurnerHeight_ValueEditorClick
            'RemoveHandler nudSlit.ValueEditorClick, AddressOf nudSlit_ValueEditorClick
            'RemoveHandler nudFuelRatio.ValueEditorClick, AddressOf nudFuelRatio_ValueEditorClick
            'RemoveHandler nudBurnerHeight.ValueEditorValueChanged, AddressOf nudBurnerHeight_ValueChanged
            'RemoveHandler nudSlit.ValueEditorValueChanged, AddressOf nudSlit_ValueChanged
            'RemoveHandler nudFuelRatio.ValueEditorValueChanged, AddressOf nudFuelRatio_ValueChanged
            mblnParameterProcessing = True  'Added by pankaj on 2 Dec 07
            Call funcSetSlit_WidthParameter_Ref(nudSlit_Ref.Value)


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
            'nudSlit_Ref.Enabled = True
            'AddHandler btnStart.Click, AddressOf btnStart_Click
            'AddHandler btnLampParameters.Click, AddressOf btnLampParameters_Click

            'AddHandler nudBurnerHeight.ValueEditorClick, AddressOf nudBurnerHeight_ValueEditorClick
            'AddHandler nudSlit.ValueEditorClick, AddressOf nudSlit_ValueEditorClick
            'AddHandler nudFuelRatio.ValueEditorClick, AddressOf nudFuelRatio_ValueEditorClick
            'AddHandler nudBurnerHeight.ValueEditorValueChanged, AddressOf nudBurnerHeight_ValueChanged
            'AddHandler nudSlit.ValueEditorValueChanged, AddressOf nudSlit_ValueChanged
            'AddHandler nudFuelRatio.ValueEditorValueChanged, AddressOf nudFuelRatio_ValueChanged
            'mblnAvoidProcessing = False
            Application.DoEvents()
            mblnParameterProcessing = False 'Added by pankaj on 2 Dec 07
        End Try

    End Sub

    Private Sub nudSlit_Ref_ValueEditorClick()
        '=====================================================================
        ' Procedure Name        : nudSlit_Ref_ValueEditorClick
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
            'nudSlit_Ref.Enabled = False
            'If mblnAvoidProcessing = True Then
            '    Exit Sub
            'End If
            'mblnAvoidProcessing = True

            RemoveHandler nudSlit_Ref.ValueEditorClick, AddressOf nudSlit_Ref_ValueEditorClick
            'RemoveHandler btnStart.Click, AddressOf btnStart_Click
            'RemoveHandler btnLampParameters.Click, AddressOf btnLampParameters_Click

            'RemoveHandler nudBurnerHeight.ValueEditorClick, AddressOf nudBurnerHeight_ValueEditorClick
            'RemoveHandler nudSlit.ValueEditorClick, AddressOf nudSlit_ValueEditorClick
            'RemoveHandler nudFuelRatio.ValueEditorClick, AddressOf nudFuelRatio_ValueEditorClick
            'RemoveHandler nudBurnerHeight.ValueEditorValueChanged, AddressOf nudBurnerHeight_ValueChanged
            'RemoveHandler nudSlit.ValueEditorValueChanged, AddressOf nudSlit_ValueChanged
            'RemoveHandler nudFuelRatio.ValueEditorValueChanged, AddressOf nudFuelRatio_ValueChanged
            Application.DoEvents()
            mblnParameterProcessing = True  'Added by pankaj on 2 Dec 07
            dblReturnValue = gobjClsAAS203.funcGet_SlitWidth(1)
            If funcSetFrmEditValue(dblReturnValue, "Set Exit Slit Width (0.0 - 2.0)nm", nudSlit_Ref.MinValue, nudSlit_Ref.MaxValue) = True Then
                nudSlit_Ref.Value = dblReturnValue
            Else
                nudSlit_Ref.Value = gobjClsAAS203.funcGet_SlitWidth(1)
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
            AddHandler nudSlit_Ref.ValueEditorClick, AddressOf nudSlit_Ref_ValueEditorClick
            'AddHandler btnStart.Click, AddressOf btnStart_Click
            'AddHandler btnLampParameters.Click, AddressOf btnLampParameters_Click

            'AddHandler nudBurnerHeight.ValueEditorClick, AddressOf nudBurnerHeight_ValueEditorClick
            'AddHandler nudSlit.ValueEditorClick, AddressOf nudFuelRatio_ValueEditorClick
            'AddHandler nudFuelRatio.ValueEditorClick, AddressOf nudFuelRatio_ValueEditorClick
            'AddHandler nudBurnerHeight.ValueEditorValueChanged, AddressOf nudBurnerHeight_ValueChanged
            'AddHandler nudSlit.ValueEditorValueChanged, AddressOf nudSlit_ValueChanged
            'AddHandler nudFuelRatio.ValueEditorValueChanged, AddressOf nudFuelRatio_ValueChanged
            'nudSlit_Ref.Enabled = True
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            nudSlit_Ref.Focus()
            Application.DoEvents()
            mblnParameterProcessing = False 'Added by pankaj on 2 Dec 07
        End Try
    End Sub

    'Private Sub nudHCLCur_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    nudHCLCur.Enabled = False
    '    mblnAvoidProcessing = True
    '    Call funcSetHCL_CurParameter(nudHCLCur.Value)
    '    mblnAvoidProcessing = False
    '    nudHCLCur.Enabled = True
    'End Sub

    Private Sub nudHCLCur_ValueChanged(ByVal ChangeHCLCur As Double)
        '=====================================================================
        ' Procedure Name        : nudHCLCur_ValueChanged
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : 
        ' Description           :  
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 21.11.06
        ' Revisions             : 
        '=====================================================================
        Try
            'nudHCLCur.Enabled = False
            'If mblnAvoidProcessing = True Then
            '    Exit Sub
            'End If
            'mblnAvoidProcessing = True
            
            RemoveHandler nudHCLCur.ValueEditorValueChanged, AddressOf nudHCLCur_ValueChanged
            Application.DoEvents()
            If ReInitLampInstParameters = True Then
                Exit Sub
            End If
            mblnParameterProcessing = True  'Added by pankaj on 2 Dec 07
            Call funcSetHCL_CurParameter(nudHCLCur.Value)

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
            'mblnAvoidProcessing = False
            AddHandler nudHCLCur.ValueEditorValueChanged, AddressOf nudHCLCur_ValueChanged
            'nudHCLCur.Enabled = True
            mblnParameterProcessing = False 'Added by pankaj on 2 Dec 07
            Application.DoEvents()
        End Try

    End Sub

    Private Sub nudHCLCur_ValueEditorClick()
        '=====================================================================
        ' Procedure Name        : nudHCLCur_ValueEditorClick
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
            'nudHCLCur.Enabled = False
            'If mblnAvoidProcessing = True Then
            '    Exit Sub
            'End If
            'mblnAvoidProcessing = True

            RemoveHandler nudHCLCur.ValueEditorClick, AddressOf nudHCLCur_ValueEditorClick
            Application.DoEvents()
            If ReInitLampInstParameters = True Then
                Exit Sub
            End If
            mblnParameterProcessing = True  'Added by pankaj on 2 Dec 07
            dblReturnValue = gobjInst.Current
            If funcSetFrmEditValue(dblReturnValue, "Set HCL Current (0 - 25)mA", nudHCLCur.MinValue, nudHCLCur.MaxValue) = True Then
                nudHCLCur.Value = dblReturnValue
            Else
                nudHCLCur.Value = gobjInst.Current
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
            AddHandler nudHCLCur.ValueEditorClick, AddressOf nudHCLCur_ValueEditorClick
            'nudHCLCur.Enabled = True
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            nudHCLCur.Focus()
            Application.DoEvents()
            mblnParameterProcessing = False 'Added by pankaj on 2 Dec 07
        End Try
    End Sub

    'Private Sub nudD2Cur_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    nudHCLCur.Enabled = False
    '    mblnAvoidProcessing = True
    '    Call funcSetD2_CurParameter(nudD2Cur.Value)
    '    mblnAvoidProcessing = False
    '    nudHCLCur.Enabled = True
    'End Sub

    Private Sub nudD2Cur_ValueChanged(ByVal ChangeD2Cur As Double)
        '=====================================================================
        ' Procedure Name        : nudD2Cur_ValueChanged
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : 
        ' Description           :  
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 21.11.06
        ' Revisions             : 
        '=====================================================================
        Try
            'nudD2Cur.Enabled = False
            'If mblnAvoidProcessing = True Then
            '    Exit Sub
            'End If
            'mblnAvoidProcessing = True
            If ReInitLampInstParameters = True Then
                Exit Sub
            End If
            mblnParameterProcessing = True  'Added by pankaj on 2 Dec 07
            Call funcSetD2_CurParameter(nudD2Cur.Value)
            If nudD2Cur.Value = 100.0 Then
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
            'mblnAvoidProcessing = False
            'nudD2Cur.Enabled = True
            mblnParameterProcessing = False 'Added by pankaj on 2 Dec 07
            '---------------------------------------------------------
        End Try

    End Sub

    Private Sub nudD2Cur_ValueEditorClick()
        '=====================================================================
        ' Procedure Name        : nudD2Cur_ValueEditorClick
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
            'nudD2Cur.Enabled = False
            'If mblnAvoidProcessing = True Then
            '    Exit Sub
            'End If
            'mblnAvoidProcessing = True
            mblnParameterProcessing = True  'Added by pankaj on 2 Dec 07
            RemoveHandler nudD2Cur.ValueEditorClick, AddressOf nudD2Cur_ValueEditorClick
            Application.DoEvents()
            If ReInitLampInstParameters = True Then
                Exit Sub
            End If
            dblReturnValue = gobjInst.D2Current
            If funcSetFrmEditValue(dblReturnValue, "Set D2 Current (100 - 300)mA", nudD2Cur.MinValue, nudD2Cur.MaxValue) = True Then
                nudD2Cur.Value = dblReturnValue
            Else
                nudD2Cur.Value = gobjInst.D2Current
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
            mblnParameterProcessing = False 'Added by pankaj on 2 Dec 07
        End Try
    End Sub

    'Private Sub nudFuelRatio_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Try
    '        nudHCLCur.Enabled = False
    '        mblnAvoidProcessing = True
    '        RemoveHandler nudFuelRatio.ValueChanged, AddressOf nudBurnerHeight_ValueChanged
    '        'If Not (CDbl(nudFuelRatio.Value) = mdblFuelRatio) Then
    '        '    Call gobjClsAAS203.funcSetFuel(CDbl(nudFuelRatio.Value))
    '        '    mdblFuelRatio = gobjClsAAS203.funcGet_Fuel_Ratio(True)
    '        'Else
    '        '    mdblFuelRatio = gobjClsAAS203.funcGet_Fuel_Ratio(True)
    '        'End If

    '        Call funcSetFuelParameter(CDbl(nudFuelRatio.Value))
    '        mobjParameters.FualRatio = Val(mdblFuelRatio)
    '        nudFuelRatio.Value = mdblFuelRatio
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
    '        mblnAvoidProcessing = False
    '        nudFuelRatio.Enabled = True
    '        '---------------------------------------------------------
    '    End Try
    'End Sub

    Private Sub nudFuelRatio_ValueChanged(ByVal ChangeFuelRatio As Double)
        '=====================================================================
        ' Procedure Name        : nudFuelRatio_ValueChanged
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : 
        ' Description           :  
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 21.11.06
        ' Revisions             : 
        '=====================================================================
        Try
            RemoveHandler nudFuelRatio.ValueEditorValueChanged, AddressOf nudFuelRatio_ValueChanged

            gobjCommProtocol.mobjCommdll.subTime_Delay(50)
            Application.DoEvents()
            mblnParameterProcessing = True  'Added by pankaj on 2 Dec 07

            ''Call funcSetFuelParameter(CDbl(nudFuelRatio.Value))

            ''If mdblFuelRatio < 0.0 Then
            ''    nudFuelRatio.Value = 0.0
            ''    mobjParameters.FualRatio = 0.0
            ''    mdblFuelRatio = 0.0
            ''Else
            ''    nudFuelRatio.Value = mdblFuelRatio
            ''    mobjParameters.FualRatio = mdblFuelRatio
            ''End If

            ''nudFuelRatio.Refresh()

            '---above code is commented and called following 
            '---function to set fuel according to value editor 
            '---button clicked
            FuncIncrDecrFuel(CDbl(nudFuelRatio.Value))

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
            AddHandler nudFuelRatio.ValueEditorValueChanged, AddressOf nudFuelRatio_ValueChanged
            mblnParameterProcessing = False  'Added by pankaj on 2 Dec 07
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub nudFuelRatio_ValueEditorClick()
        '=====================================================================
        ' Procedure Name        : nudFuelRatio_ValueEditorClick
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
            'nudFuelRatio.Enabled = False
            'If mblnAvoidProcessing = True Then
            '    Exit Sub
            'End If
            'mblnAvoidProcessing = True

            RemoveHandler nudFuelRatio.ValueEditorClick, AddressOf nudFuelRatio_ValueEditorClick
            'RemoveHandler btnStart.Click, AddressOf btnStart_Click
            'RemoveHandler btnLampParameters.Click, AddressOf btnLampParameters_Click
            'RemoveHandler nudBurnerHeight.ValueEditorClick, AddressOf nudBurnerHeight_ValueEditorClick
            'RemoveHandler nudSlit.ValueEditorClick, AddressOf nudSlit_ValueEditorClick
            'RemoveHandler nudSlit_Ref.ValueEditorClick, AddressOf nudSlit_Ref_ValueEditorClick
            'RemoveHandler nudBurnerHeight.ValueEditorValueChanged, AddressOf nudBurnerHeight_ValueChanged
            'RemoveHandler nudSlit.ValueEditorValueChanged, AddressOf nudSlit_ValueChanged
            'RemoveHandler nudSlit_Ref.ValueEditorValueChanged, AddressOf nudSlit_Ref_ValueChanged

            Application.DoEvents()
            mblnParameterProcessing = True  'Added by pankaj on 2 Dec 07
            'dblReturnValue = gobjClsAAS203.funcGet_Fuel_Ratio(True)
            dblReturnValue = nudFuelRatio.Value
            If dblReturnValue < 0.0 Then
                ''setting some validation
                'mobjParameters.FualRatio = 0.0
                dblReturnValue = 0.0
            End If
            'dblReturnValue = mdblFuelRatio
            'dblReturnValue = gobjClsAAS203.funcGet_Fuel_Ratio(True)
            If funcSetFrmEditValue(dblReturnValue, "Set Fuel Ratio (0 - 7.66)", nudFuelRatio.MinValue, nudFuelRatio.MaxValue) = True Then
                nudFuelRatio.Value = dblReturnValue
            Else
                'nudFuelRatio.Value = gobjClsAAS203.funcGet_Fuel_Ratio(True)
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
            AddHandler nudFuelRatio.ValueEditorClick, AddressOf nudFuelRatio_ValueEditorClick
            'AddHandler btnStart.Click, AddressOf btnStart_Click
            'AddHandler btnLampParameters.Click, AddressOf btnLampParameters_Click

            'AddHandler nudBurnerHeight.ValueEditorClick, AddressOf nudBurnerHeight_ValueEditorClick
            'AddHandler nudSlit.ValueEditorClick, AddressOf nudSlit_ValueEditorClick
            'AddHandler nudSlit_Ref.ValueEditorClick, AddressOf nudSlit_Ref_ValueEditorClick
            'AddHandler nudBurnerHeight.ValueEditorValueChanged, AddressOf nudBurnerHeight_ValueChanged
            'AddHandler nudSlit.ValueEditorValueChanged, AddressOf nudSlit_ValueChanged
            'AddHandler nudSlit_Ref.ValueEditorValueChanged, AddressOf nudSlit_Ref_ValueChanged
            'nudFuelRatio.Enabled = True
            'mblnAvoidProcessing = False
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            nudFuelRatio.Focus()
            Application.DoEvents()
            mblnParameterProcessing = False 'Added by pankaj on 2 Dec 07
        End Try
    End Sub

    'Private Sub nudBurnerHeight_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Try
    '        nudHCLCur.Enabled = False
    '        mblnAvoidProcessing = True
    '        If Not (dblBhHeight = CDbl(nudBurnerHeight.Value)) Then
    '            'If dblBhHeight > nudBurnerHeight.Value Then
    '            '    dblBhHeight = funcSetBurner_HeightParameter(-1)
    '            '    dblBhHeight = Format(dblBhHeight, "#.00")
    '            '    nudBurnerHeight.Value = Format(dblBhHeight, "#.00")
    '            'ElseIf dblBhHeight < nudBurnerHeight.Value Then
    '            '    dblBhHeight = funcSetBurner_HeightParameter(1)
    '            '    dblBhHeight = Format(dblBhHeight, "#.00")
    '            '    nudBurnerHeight.Value = Format(dblBhHeight, "#.00")
    '            'End If
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
    '        mblnAvoidProcessing = False
    '        nudHCLCur.Enabled = True
    '        '---------------------------------------------------------
    '    End Try
    'End Sub

    Private Sub nudBurnerHeight_ValueChanged(ByVal ChangeBurnerHeight As Double)
        '=====================================================================
        ' Procedure Name        :   nudBurnerHeight_ValueChanged
        ' Description           :    
        ' Purpose               :    
        '                           
        ' Parameters Passed     :   None.
        ' Returns               :    
        ' Parameters Affected   :   None.
        ' Assumptions           :
        ' Dependencies          :
        ' Author                :   Gitesh, Uday
        ' Created               :   Saturday, November 15, 2003 18:49
        ' Revisions             :
        '=====================================================================
        Try
            If mblnAvoidProcessing = True Then
                Exit Sub
            End If


            'nudBurnerHeight.Enabled = False
            'RemoveHandler nudBurnerHeight.ValueEditorValueChanged, AddressOf nudBurnerHeight_ValueChanged
            'RemoveHandler btnStart.Click, AddressOf btnStart_Click
            'RemoveHandler btnLampParameters.Click, AddressOf btnLampParameters_Click
            'RemoveHandler nudFuelRatio.ValueEditorClick, AddressOf nudFuelRatio_ValueEditorClick
            'RemoveHandler nudSlit.ValueEditorClick, AddressOf nudSlit_ValueEditorClick
            'RemoveHandler nudSlit_Ref.ValueEditorClick, AddressOf nudSlit_Ref_ValueEditorClick
            'RemoveHandler nudFuelRatio.ValueEditorValueChanged, AddressOf nudFuelRatio_ValueChanged
            'RemoveHandler nudSlit.ValueEditorValueChanged, AddressOf nudSlit_ValueChanged
            'RemoveHandler nudSlit_Ref.ValueEditorValueChanged, AddressOf nudSlit_Ref_ValueChanged

            mblnAvoidProcessing = True
            mblnParameterProcessing = True  'Added by pankaj on 2 Dec 07
            If Not (dblBhHeight = CDbl(nudBurnerHeight.Value)) Then
                'If dblBhHeight > nudBurnerHeight.Value Then
                '    dblBhHeight = funcSetBurner_HeightParameter(-1)
                '    dblBhHeight = Format(dblBhHeight, "#.00")
                '    nudBurnerHeight.Value = Format(dblBhHeight, "#.00")
                'ElseIf dblBhHeight < nudBurnerHeight.Value Then
                '    dblBhHeight = funcSetBurner_HeightParameter(1)
                '    dblBhHeight = Format(dblBhHeight, "#.00")
                '    nudBurnerHeight.Value = Format(dblBhHeight, "#.00")
                'End If
                nudBurnerHeight.Value = funcSetBurner_HeightParameter(CDbl(nudBurnerHeight.Value))
            End If

            'AddHandler nudBurnerHeight.ValueEditorValueChanged, AddressOf nudBurnerHeight_ValueChanged
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
            mblnParameterProcessing = False 'Added by pankaj on 2 Dec 07
            'AddHandler btnStart.Click, AddressOf btnStart_Click
            'AddHandler btnLampParameters.Click, AddressOf btnLampParameters_Click
            'AddHandler nudFuelRatio.ValueEditorClick, AddressOf nudFuelRatio_ValueEditorClick
            'AddHandler nudSlit.ValueEditorClick, AddressOf nudSlit_ValueEditorClick
            'AddHandler nudSlit_Ref.ValueEditorClick, AddressOf nudSlit_Ref_ValueEditorClick
            'AddHandler nudFuelRatio.ValueEditorValueChanged, AddressOf nudFuelRatio_ValueChanged
            'AddHandler nudSlit.ValueEditorValueChanged, AddressOf nudSlit_ValueChanged
            'AddHandler nudSlit_Ref.ValueEditorValueChanged, AddressOf nudSlit_Ref_ValueChanged
            'nudBurnerHeight.Enabled = True
            '---------------------------------------------------------
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
        'Dim objWait As New CWaitCursor
        Dim dblReturnValue As Double
        Try
            If mblnAvoidProcessing = True Then
                Exit Sub
            End If
            'nudBurnerHeight.Enabled = False
            mblnAvoidProcessing = True
            mblnParameterProcessing = True  'Added by pankaj on 2 Dec 07
            'DisableButtonsForBurnerHeight() 'Saurabh 21.07.07

            'RemoveHandler nudBurnerHeight.ValueEditorClick, AddressOf nudBurnerHeight_ValueEditorClick
            'RemoveHandler btnStart.Click, AddressOf btnStart_Click
            'RemoveHandler btnLampParameters.Click, AddressOf btnLampParameters_Click

            'RemoveHandler nudFuelRatio.ValueEditorClick, AddressOf nudFuelRatio_ValueEditorClick
            'RemoveHandler nudSlit.ValueEditorClick, AddressOf nudSlit_ValueEditorClick
            'RemoveHandler nudSlit_Ref.ValueEditorClick, AddressOf nudSlit_Ref_ValueEditorClick
            'RemoveHandler nudFuelRatio.ValueEditorValueChanged, AddressOf nudFuelRatio_ValueChanged
            'RemoveHandler nudSlit.ValueEditorValueChanged, AddressOf nudSlit_ValueChanged
            'RemoveHandler nudSlit_Ref.ValueEditorValueChanged, AddressOf nudSlit_Ref_ValueChanged

            'RemoveHandler nudBurnerHeight.VisibleChanged, AddressOf nudBurnerHeight_ValueChanged
            Application.DoEvents()

            dblReturnValue = Format(gobjClsAAS203.funcReadBurnerHeight(), "0.00")
            If funcSetFrmEditValue(dblReturnValue, "Set Burner Height (0.0 - 6.0)nm", nudBurnerHeight.MinValue, nudBurnerHeight.MaxValue) = True Then
                'nudBurnerHeight.Value = dblReturnValue     Commented By Saurabh
                nudBurnerHeight.Value = funcSetBurner_HeightParameter(CDbl(dblReturnValue))  'Added by Saurabh
            End If

            'AddHandler nudBurnerHeight.ValueEditorClick, AddressOf nudBurnerHeight_ValueEditorClick
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

            'nudBurnerHeight.Enabled = True
            'If Not objWait Is Nothing Then
            '    objWait.Dispose()
            'End If
            'EnableButtonsForBurnerHeight() 'Saurabh 21.07.07
            'AddHandler btnStart.Click, AddressOf btnStart_Click
            'AddHandler btnLampParameters.Click, AddressOf btnLampParameters_Click
            'AddHandler nudFuelRatio.ValueEditorClick, AddressOf nudFuelRatio_ValueEditorClick
            'AddHandler nudSlit.ValueEditorClick, AddressOf nudSlit_ValueEditorClick
            'AddHandler nudSlit_Ref.ValueEditorClick, AddressOf nudSlit_Ref_ValueEditorClick
            'AddHandler nudFuelRatio.ValueEditorValueChanged, AddressOf nudFuelRatio_ValueChanged
            'AddHandler nudSlit.ValueEditorValueChanged, AddressOf nudSlit_ValueChanged
            'AddHandler nudSlit_Ref.ValueEditorValueChanged, AddressOf nudSlit_Ref_ValueChanged
            mblnAvoidProcessing = False
            mblnParameterProcessing = False 'Added by pankaj on 2 Dec 07
            nudBurnerHeight.Focus()
            Application.DoEvents()
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
        Dim intSelectedModeType As Integer
        Try
            If mblnAvoidProcessing = True Then
                Exit Sub
            End If
            mblnAvoidProcessing = True
            'nudHCLCur.Enabled = False
            RemoveHandler cmbModes.SelectedIndexChanged, AddressOf cmbModes_SelectedIndexChanged
            If cmbModes.SelectedIndex > -1 Then
                'gobjInst.Mode = cmbModes.SelectedIndex
                '//----- Use for Double Beam. It has not use other mode
                If gintInstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.DoubleBeam Then
                    '//----- Commented by Sachin Dokhale on change of 2nd time requirement for DB for 
                    'Select Case cmbModes.SelectedIndex
                    '    Case 0
                    '        intSelectedModeType = EnumCalibrationMode.AA
                    '    Case 1
                    '        intSelectedModeType = EnumCalibrationMode.HCLE
                    '    Case 2
                    '        intSelectedModeType = EnumCalibrationMode.AABGC
                    'End Select
                    'Call funcSetSpectrumParameter(intSelectedModeType)
                    '//------
                    Call funcSetSpectrumParameter(cmbModes.SelectedIndex)
                Else
                    Call funcSetSpectrumParameter(cmbModes.SelectedIndex)
                End If

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
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            mblnAvoidProcessing = False

            'nudHCLCur.Enabled = True
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
    '    Dim blnIsFlameStatusCheck As Boolean = False

    '    Try
    '        RemoveHandler mnuIgnite.Click, AddressOf btnAutoIgnition_Click
    '        If mblnAvoidProcessing = True Then
    '            Exit Sub
    '        End If
    '        mblnAvoidProcessing = True

    '        'If Not IsNothing(mobjfrmAnalysis) Then mobjfrmAnalysis.tmrAspirationMsg.Enabled = False
    '        gobjMain.mobjController.Cancel()
    '        Application.DoEvents()
    '        blnIsFlameStatusCheck = True
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
    '        mblnAvoidProcessing = False
    '        If blnIsFlameStatusCheck = True Then
    '            gobjMain.mobjController.Start(gobjclsBgFlameStatus)
    '        End If
    '        AddHandler mnuIgnite.Click, AddressOf btnAutoIgnition_Click
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
    '    Dim blnIsFlameStatusCheck As Boolean = False
    '    Try
    '        RemoveHandler mnuExtinguish.Click, AddressOf btnExtinguish_Click
    '        If mblnAvoidProcessing = True Then
    '            Exit Sub
    '        End If
    '        mblnAvoidProcessing = True

    '        gobjMain.mobjController.Cancel()
    '        blnIsFlameStatusCheck = True
    '        Application.DoEvents()

    '        Call gobjClsAAS203.funcIgnite(False)
    '        mblnAvoidProcessing = False
    '        Application.DoEvents()
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
    '        If blnIsFlameStatusCheck = True Then
    '            gobjMain.mobjController.Start(gobjclsBgFlameStatus)
    '        End If
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

            'gobjMain.mobjController.Cancel()       Commented By Saurabh
            'Application.DoEvents()

            nudBurnerHeight.IsReverseOperation = True
            nudBurnerHeight.IsUpDownButtonToBeDisabledOnValueChange = True
            nudFuelRatio.IsUpDownButtonToBeDisabledOnValueChange = True
            TimerEnergyDisplay.Enabled = False
            gblnUVS = False
            IsRefBeamSelected = False
            If gintInstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.DoubleBeam Then
                grpBeamType.Visible = True
            Else
                grpBeamType.Visible = False
            End If
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
                Application.DoEvents()
            End If

            If gobjInst.Mode > -1 Then
                '//----- Added by Sachin Dokhale. Get the init. calibration mode.
                m_bytCalibMode = gobjInst.Mode
                '//-----
                cmbModes.SelectedIndex = gobjInst.Mode
            End If
            nudPMT.Visible = True
            If Not (gintInstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.SingleBeam) Then
                nudPMT_Ref.Visible = True
                nudPMT_Ref.Enabled = True
            Else
                nudPMT_Ref.Visible = True
                nudPMT_Ref.Enabled = False
            End If

            nudBurnerHeight.Visible = True
            nudD2Cur.Visible = True
            nudFuelRatio.Visible = True
            nudHCLCur.Visible = True
            nudSlit.Visible = True
            nudSlit_Ref.Visible = True
            cmbSpeed.Visible = True
            cmbModes.Visible = True
            Application.DoEvents()
            '//----- Set the HCLE as default mode for Energy Spectrum
            Call funcSetDefaultSpectrumParameter(EnumCalibrationMode.HCLE)
            Call funcSetDefaultParameter()
            Call AddHandlers()
            gblnSpectrumTerminated = False
            gblnSpectrumWait = False
            'TimerEnergyDisplay.Enabled = True
            func_Enable_Disable(EnumProcesses.FormInitialize, EnumStart_End.Start_of_Process)
            Me.Refresh()
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
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
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
            AddHandler mnuLoadSpectrunFile.Click, AddressOf mnuLoadSpectrumFile_Click
            AddHandler mnuSaveSpectrumFile.Click, AddressOf mnuSaveSpectrumFile_Click
            AddHandler cmbModes.SelectedIndexChanged, AddressOf cmbModes_SelectedIndexChanged
            AddHandler mnuExit.Click, AddressOf mnuExit_Click
            AddHandler btnReturn.Click, AddressOf mnuExit_Click
            AddHandler mnuPeakPick.Click, AddressOf mnuPeakPick_Click
            AddHandler btnStart.Click, AddressOf btnStart_Click
            AddHandler btnLampParameters.Click, AddressOf btnLampParameters_Click
            AddHandler btnClearSpectrum.Click, AddressOf btnClearSpectrum_Click
            'Added By Pankaj on 22 May 07
            AddHandler mnuStart.Click, AddressOf btnStart_Click
            AddHandler mnuClearSpectrum.Click, AddressOf btnClearSpectrum_Click
            AddHandler mnuLampParameters.Click, AddressOf btnLampParameters_Click
            AddHandler mnuChangeScale.Click, AddressOf cmdChangeScale_Click
            AddHandler mnuOverlay.Click, AddressOf cmdOverlay_Click 'By Pankaj on 30 Nov 07
            '----

            'AddHandler nudFuelRatio.ValueChanged, AddressOf nudFuelRatio_ValueChanged
            AddHandler nudFuelRatio.ValueEditorClick, AddressOf nudFuelRatio_ValueEditorClick
            AddHandler nudFuelRatio.ValueEditorValueChanged, AddressOf nudFuelRatio_ValueChanged

            'AddHandler nudBurnerHeight.ValueChanged, AddressOf nudBurnerHeight_ValueChanged
            AddHandler nudBurnerHeight.ValueEditorClick, AddressOf nudBurnerHeight_ValueEditorClick
            AddHandler nudBurnerHeight.ValueEditorValueChanged, AddressOf nudBurnerHeight_ValueChanged

            'AddHandler nudD2Cur.ValueChanged, AddressOf nudD2Cur_ValueChanged
            AddHandler nudD2Cur.ValueEditorClick, AddressOf nudD2Cur_ValueEditorClick
            AddHandler nudD2Cur.ValueEditorValueChanged, AddressOf nudD2Cur_ValueChanged

            'AddHandler nudHCLCur.ValueChanged, AddressOf nudHCLCur_ValueChanged
            AddHandler nudHCLCur.ValueEditorClick, AddressOf nudHCLCur_ValueEditorClick
            AddHandler nudHCLCur.ValueEditorValueChanged, AddressOf nudHCLCur_ValueChanged

            'AddHandler nudSlit.ValueChanged, AddressOf nudSlit_ValueChanged
            AddHandler nudSlit.ValueEditorClick, AddressOf nudSlit_ValueEditorClick
            AddHandler nudSlit.ValueEditorValueChanged, AddressOf nudSlit_ValueChanged

            AddHandler nudSlit_Ref.ValueEditorClick, AddressOf nudSlit_Ref_ValueEditorClick
            AddHandler nudSlit_Ref.ValueEditorValueChanged, AddressOf nudSlit_Ref_ValueChanged

            'AddHandler nudPMT.ValueChanged, AddressOf nudPMT_ValueChanged
            AddHandler nudPMT.ValueEditorClick, AddressOf nudPMT_ValueEditorClick
            AddHandler nudPMT.ValueEditorValueChanged, AddressOf nudPMT_ValueChanged

            AddHandler nudPMT_Ref.ValueEditorClick, AddressOf nudPMT_Ref_ValueEditorClick
            AddHandler nudPMT_Ref.ValueEditorValueChanged, AddressOf nudPMT_Ref_ValueChanged

            AddHandler cmbSpeed.SelectedIndexChanged, AddressOf cmbSpeed_SelectedIndexChanged
            AddHandler cmdChangeScale.Click, AddressOf cmdChangeScale_Click
            'AddHandler btnLampParameters.Click, AddressOf btnLampParameters_Click
            AddHandler mnuContiniousTimeScan.Click, AddressOf mnuContiniousTimeScan_Click
            AddHandler mnuSmooth.Click, AddressOf mnuSmoothGraph_Click
            AddHandler mnuPositionToMaxima.Click, AddressOf mnuPositionToMaxima_Click
            AddHandler mnuParameters.Click, AddressOf mnuParameters_Click
            AddHandler AASEnergySpectrum.GraphScaleChanged, AddressOf AASEnergySpectrum_GraphScaleChanged

            AddHandler tlbbtnReturn.Click, AddressOf mnuExit_Click
            AddHandler tlbbtnStart.Click, AddressOf btnStart_Click
            AddHandler tlbbtnLampParameters.Click, AddressOf btnLampParameters_Click
            AddHandler tlbbtnClearSpectrum.Click, AddressOf btnClearSpectrum_Click
            AddHandler tlbbtnChangeScale.Click, AddressOf cmdChangeScale_Click
            AddHandler tlbbtnLoadspectrumFile.Click, AddressOf mnuLoadSpectrumFile_Click
            AddHandler tlbbtnSaveSpectrumFile.Click, AddressOf mnuSaveSpectrumFile_Click
            AddHandler tlbbtnSmooth.Click, AddressOf mnuSmoothGraph_Click
            AddHandler tlbbtnPositionToMaxima.Click, AddressOf mnuPositionToMaxima_Click
            AddHandler tlbbtnContiniousTimeScan.Click, AddressOf mnuContiniousTimeScan_Click
            AddHandler tlbbtnParameters.Click, AddressOf mnuParameters_Click
            AddHandler tlbbtnPrintGraph.Click, AddressOf tlbbtnPrintGraph_Click
            AddHandler tlbbtnPeakPick.Click, AddressOf mnuPeakPick_Click
            AddHandler mnuPrintGraph.Click, AddressOf tlbbtnPrintGraph_Click

            'Menu for Graph Options
            AddHandler mnuPeakEdit.Click, AddressOf mnuPeakEdit_Click
            AddHandler mnuGrid.Click, AddressOf mnuGrid_Click
            AddHandler mnuShowXYValues.Click, AddressOf mnuShowXYValues_Click
            AddHandler mnuLegends.Click, AddressOf mnuLegends_Click

            'Tlbbtn for Graph Options
            AddHandler tlbbtnPeakEdit.Click, AddressOf mnuPeakEdit_Click
            AddHandler tlbbtnGrid.Click, AddressOf mnuGrid_Click
            AddHandler tlbbtnShowXYValues.Click, AddressOf mnuShowXYValues_Click
            AddHandler tlbbtnLegends.Click, AddressOf mnuLegends_Click

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

    Private Sub subStartScan()
        '=====================================================================
        ' Procedure Name        : subStartScan
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

            If mblnAvoidProcessing = True Then
                Exit Sub
            End If
            Call func_Enable_Disable(EnumProcesses.StartScan, EnumStart_End.Start_of_Process)
            Call funcGetInstParameter()
            Call func_Enable_DisableControl(False)
            If mnuOverlay.Checked = False Then 'by Pankaj on 30 Nov 07
                subClearGraph()
            End If
            'Display graph
            If mobjChannnels.Count > 0 Then
                If Not (mobjChannnels(mintChannelIndex) Is Nothing) Then
                    funcDisplayGraph(mobjChannnels(mintChannelIndex))
                End If
            End If
            'Added by pankaj on 21 Jan 08
            If gstructSettings.AppMode = EnumAppMode.FullVersion_203D Then
                If IsRefBeamSelected = False Then
                    nudPMT_Ref.Value = 0
                    Me.Refresh()
                    Application.DoEvents()
                End If
                
            End If
            '---for setting ref. pmt to zero

            If gblnIsDemoWithRealData = True Then   '---16.03.08
                mobjParameters.YaxisMin = 0
                mobjParameters.YaxisMax = 100
                Select Case gobjInst.Lamp_Position
                    Case 1
                        mobjParameters.XaxisMin = 210
                        mobjParameters.XaxisMax = 220
                    Case 2
                        mobjParameters.XaxisMin = 320
                        mobjParameters.XaxisMax = 330
                    Case 3
                        mobjParameters.XaxisMin = 210
                        mobjParameters.XaxisMax = 220
                    Case 4
                        mobjParameters.XaxisMin = 190
                        mobjParameters.XaxisMax = 200
                    Case 5
                        mobjParameters.XaxisMin = 246
                        mobjParameters.XaxisMax = 254
                    Case 6
                        mobjParameters.XaxisMin = 276
                        mobjParameters.XaxisMax = 284
                End Select
                WvStartRange = mobjParameters.XaxisMin
                WvLastRange = mobjParameters.XaxisMax
            End If

            If funcOnSpect(False, lblWvPos, lblYValue) = False Then
                func_Enable_Disable(EnumProcesses.StartScan, EnumStart_End.End_of_Process)
                Call func_Enable_DisableControl(True)
                Exit Sub
            End If

            btnStart.Text = "&Stop"
            btnStart.Image = Image.FromFile(Application.StartupPath & "\Images\cancel_1.ico")
            btnStart.Enabled = True
            btnStart.Refresh()
            'AASEnergySpectrum

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

            'gblnSpectrumTerminated = True
            ' Set interupte for Termination of the thread
            If Not mobjclsBgSpectrum Is Nothing Then
                mobjclsBgSpectrum.ThTerminate = True
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

            If mblnAvoidProcessing = True Then
                Exit Sub
            End If
            mblnAvoidProcessing = True
            'intChannel_no = funcAddChannelToCollection(mobjOnlineChannel)

            If mintChannelIndex > -1 Then
                If mobjChannnels.Count > 0 Then
                    If blnYetFileNotSave = True Then
                        If gobjMessageAdapter.ShowMessage(constFileNotSaved) = True Then
                            If gintInstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.DoubleBeam Then
                                Call funcSaveSpectrumFile_Double()
                            Else
                                Call funcSaveSpectrumFile()
                            End If
                        End If
                    End If
                    'mobjChannnels.RemoveAt(mintChannelIndex)
                    mintChannelIndex = -1

                    mobjChannnels.Clear()
                    If ArrlstGraphCurveItem.Count >= intCurveIndex + 1 Then
                        'ArrlstGraphCurveItem.RemoveAt(intCurveIndex)
                        ArrlstGraphCurveItem.Clear()
                        intCurveIndex = -1
                    End If
                End If
            End If
            blnYetFileNotSave = False
            funcClearGraph()
            Call func_Enable_Disable(EnumProcesses.EditSystemParamters, EnumStart_End.Start_of_Process)


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
            mblnAvoidProcessing = False
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub subClearGraph()
        '=====================================================================
        ' Procedure Name        : subClearScan
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Pankaj
        ' Created               : 30.11.07
        ' Revisions             : 
        '=====================================================================
        'Dim objWait As New CWaitCursor
        Try

            If mblnAvoidProcessing = True Then
                'Exit Sub
            End If
            'mblnAvoidProcessing = True
            'intChannel_no = funcAddChannelToCollection(mobjOnlineChannel)


            If mintChannelIndex > -1 Then
                If mobjChannnels.Count > 0 Then
                    If blnYetFileNotSave = True Then
                        If gobjMessageAdapter.ShowMessage(constFileNotSaved) = True Then
                            If gintInstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.DoubleBeam Then
                                Call funcSaveSpectrumFile_Double()
                            Else
                                Call funcSaveSpectrumFile()
                            End If
                        End If
                    End If
                    mobjChannnels.RemoveAt(mintChannelIndex)
                    mintChannelIndex = -1

                    mobjChannnels.Clear()
                    If ArrlstGraphCurveItem.Count >= intCurveIndex + 1 Then
                        'ArrlstGraphCurveItem.RemoveAt(intCurveIndex)
                        ArrlstGraphCurveItem.Clear()
                        intCurveIndex = -1
                    End If
                End If
            End If
            'blnYetFileNotSave = False
            funcClearGraph()
            'Call func_Enable_Disable(EnumProcesses.EditSystemParamters, EnumStart_End.Start_of_Process)


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
            mblnAvoidProcessing = False
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
        If mblnAvoidProcessing = True Then
            Exit Sub
        End If
        Try
            Dim objchanel0 As Channel
            'Dim objchanel_Ref As Channel
            Dim objchanel_Sample As Channel

            mblnAvoidProcessing = True
            If mintChannelIndex > -1 Then
                'If Not gintInstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.DoubleBeam Then
                '    objchanel0 = mobjSpectrum.funcCloneESChannel(mobjChannnels(mintChannelIndex))
                '    If Not (objchanel0) Is Nothing Then
                '        mobjSpectrum.funcSmooth1(objchanel0, 0)
                '        mobjChannnels(mintChannelIndex) = mobjSpectrum.funcCloneESChannel(objchanel0)
                '        funcClearGraph()

                '        If funcDisplayGraph(mobjChannnels.item(mintChannelIndex)) = True Then
                '            ArrlstGraphCurveItem.Add(mGraphCurveItem)
                '            intCurveIndex += 1
                '        End If
                '        funcGraphPreRequisite(mobjParameters.Cal_Mode, _
                '                                                    mobjParameters.XaxisMin, _
                '                                                    mobjParameters.XaxisMax, _
                '                                                    mobjParameters.YaxisMin, _
                '                                                    mobjParameters.YaxisMax)
                '    End If
                'Else
                '//----- Smoothing for Double beam, two channel.

                'objchanel_Ref = mobjSpectrum.funcCloneESChannel(mobjEnegyChannel(mintChannelIndex - 1))

                'objchanel_Sample = mobjSpectrum.funcCloneESChannel(mobjEnegyChannel(mintChannelIndex - 1))
                objchanel_Sample = mobjSpectrum.funcCloneESChannel(mobjChannnels(mintChannelIndex))

                funcClearGraph()
                'If Not (objchanel_Ref) Is Nothing Then
                '    mobjSpectrum.funcSmooth1(objchanel_Ref, 0)
                '    'mobjChannnels(mintChannelIndex - 1) = mobjSpectrum.funcCloneESChannel(objchanel_Ref)
                '    mobjChannnels(mintChannelIndex) = (objchanel_Ref)

                '    'ArrlstGraphCurveItem(intCurveIndex) = mGraphCurveItem

                '    If funcDisplayGraphOffline(mobjChannnels.item(mintChannelIndex), mGraphCurveItem) = True Then
                '        ArrlstGraphCurveItem.Add(mGraphCurveItem)
                '        intCurveIndex += 1
                '    End If
                '    'ArrlstGraphCurveItem(intCurveIndex - 1) = mGraphCurveItem
                '    funcGraphPreRequisite(mobjParameters.Cal_Mode, _
                '                                                mobjParameters.XaxisMin, _
                '                                                mobjParameters.XaxisMax, _
                '                                                mobjParameters.YaxisMin, _
                '                                                mobjParameters.YaxisMax)
                'End If
                If Not (objchanel_Sample) Is Nothing Then
                    mobjSpectrum.funcSmooth1(objchanel_Sample, 0)
                    'mobjChannnels(mintChannelIndex) = mobjSpectrum.funcCloneESChannel(objchanel_Sample)
                    mobjChannnels(mintChannelIndex) = objchanel_Sample
                    'funcClearGraph()
                    'funcDisplayGraph(mobjChannnels.item(mintChannelIndex))
                    'funcDisplayGraph(mobjChannnels.item(mintChannelIndex))
                    If funcDisplayGraphOffline(mobjChannnels.item(mintChannelIndex), mGraphCurveItem) = True Then
                        ArrlstGraphCurveItem.Add(mGraphCurveItem)
                        intCurveIndex += 1
                    End If
                    'ArrlstGraphCurveItem(intCurveIndex) = mGraphCurveItem

                    funcGraphPreRequisite(mobjParameters.Cal_Mode, _
                                            mobjParameters.XaxisMin, _
                                            mobjParameters.XaxisMax, _
                                            mobjParameters.YaxisMin, _
                                            mobjParameters.YaxisMax)

                End If
                AASEnergySpectrum.Refresh()
                Application.DoEvents()
                'End If
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
            mblnAvoidProcessing = False
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
        Dim objDataTable_Ref As New DataTable
        Dim objPeakVallyChannel As Channel
        Dim intCounter As Integer = 0
        Dim lngPeakValleyCounts As Long
        Dim lngPeakValleyCounts_Ref As Long
        Dim intShowdialog As Integer
        Dim objclsDataFileReport As New clsDataFileReport
        If mblnAvoidProcessing = True Then
            Exit Sub
        End If

        Try


            mblnAvoidProcessing = True
            If mintChannelIndex > -1 Then

                '//----- Searching for Ref Peak.

                'If gintInstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.DoubleBeam Then
                '    If Not (mobjEnegyChannel(0) Is Nothing) Then
                '        If mobjSpectrum.funcPeaks(mobjEnegyChannel(0), mStuctPeaksValley) = False Then
                '            gobjMessageAdapter.ShowMessage(constErrorPopulatingPeakValleyData)
                '            'MsgBox("Error in Peak Valley Methods", MsgBoxStyle.Critical)
                '        End If
                '    Else
                '        Exit Sub
                '    End If
                '    '--- Check for Peak-Valley points
                '    lngPeakValleyCounts_Ref = mobjSpectrum.PeakValleyCount
                '    If lngPeakValleyCounts_Ref > 0 Then

                '        'Exit Sub
                '        '/----- Ini for Energy Spectrum

                '        objPeakVallyChannel = mobjEnegyChannel(0) 'mobjChannnels.item(mintChannelIndex)

                '        If Not mobjSpectrum.funcGetDataPeakPickResults(objDataTable_Ref, mStuctPeaksValley, lngPeakValleyCounts_Ref, objPeakVallyChannel) Then
                '            gobjMessageAdapter.ShowMessage(constErrorPopulatingPeakValleyData)
                '            'gFuncShowMessage("Error...", "Error in populating the peak valley data in the data table to display on the screen.", EnumMessageType.Information)
                '        End If
                '    Else
                '        gobjMessageAdapter.ShowMessage(constNOPeakORValley)
                '    End If
                '    objPeakVallyChannel = Nothing
                '    intCounter = 0
                '    lngPeakValleyCounts = 0
                'End If
                '//----- End of searching peak

                If Not (mobjChannnels.item(mintChannelIndex) Is Nothing) Then
                    If mobjSpectrum.funcPeaks(mobjChannnels.item(mintChannelIndex), mStuctPeaksValley) = False Then
                        gobjMessageAdapter.ShowMessage(constErrorPopulatingPeakValleyData)
                        'MsgBox("Error in Peak Valley Methods", MsgBoxStyle.Critical)
                    End If
                Else
                    Exit Sub
                End If
                '--- Check for Peak-Valley points
                lngPeakValleyCounts = mobjSpectrum.PeakValleyCount
                If lngPeakValleyCounts > 0 Then

                    'gFuncShowMessage("Peak Pick", "No Peaks Or Valleys detected.", EnumMessageType.Information)
                    'Exit Sub

                    '/----- Ini for Energy Spectrum
                    objPeakVallyChannel = mobjChannnels.item(mintChannelIndex)

                    If Not mobjSpectrum.funcGetDataPeakPickResults(objDataTable, mStuctPeaksValley, lngPeakValleyCounts, objPeakVallyChannel) Then
                        gobjMessageAdapter.ShowMessage(constErrorPopulatingPeakValleyData)
                        'gFuncShowMessage("Error...", "Error in populating the peak valley data in the data table to display on the screen.", EnumMessageType.Information)
                    End If
                Else
                    gobjMessageAdapter.ShowMessage(constNOPeakORValley)
                End If
                'If lngPeakValleyCounts > 0 And lngPeakValleyCounts_Ref > 0 Then
                If lngPeakValleyCounts > 0 Then
                    Dim frmPeakPick As New frmPeakPicks
                    If Not objDataTable Is Nothing Then
                        Call frmPeakPick.funcDisplayPicPeakResults(objDataTable)
                    End If

                    'If Not objDataTable_Ref Is Nothing Then
                    '    Call frmPeakPick.funcDisplayPicPeakResults_Ref(objDataTable_Ref)
                    'End If

                    intShowdialog = frmPeakPick.ShowDialog()
                    If intShowdialog = DialogResult.Yes Then
                        objclsDataFileReport.DefaultFont = Me.DefaultFont()
                        objclsDataFileReport.funcPeakValleyPrintEnergy(AASEnergySpectrum, objDataTable, mobjParameters, "")
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
                    frmPeakPick.Dispose()
                End If
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
            If mblnAvoidProcessing = True Then
                Exit Sub
            End If
            mblnAvoidProcessing = True

            If objfrmChangeLampPara.ShowDialog() = DialogResult.OK Then
                TimerEnergyDisplay.Enabled = False
                nudHCLCur.Value = gobjInst.Current
            End If
            mobjParameters.LampEle = gobjInst.Lamp.LampParametersCollection(gobjInst.Lamp_Position - 1).ElementName
            mobjParameters.LampTurrNo = gobjInst.Lamp_Position
            TimerEnergyDisplay.Enabled = True
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
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            mblnAvoidProcessing = False
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



            If mobjChannnels(mintChannelIndex).ChannelNo > -1 Then


                'nudPMT.Value = gobjInst.PmtVoltage

                nudPMT.Value = mobjChannnels(mintChannelIndex).EnegryParameter.PMTV()
                If Not (gintInstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.SingleBeam) Then
                    nudPMT_Ref.Value = mobjChannnels(mintChannelIndex).EnegryParameter.PMTV_Ref
                End If
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

                nudSlit.Value = Val(mobjChannnels(mintChannelIndex).EnegryParameter.SlitWidth)
                nudSlit_Ref.Value = Val(mobjChannnels(mintChannelIndex).EnegryParameter.SlitWidthRef)

                dblBhHeight = Val(mobjChannnels(mintChannelIndex).EnegryParameter.BurnerHeight)

                nudBurnerHeight.Value = dblBhHeight 'Val(mobjChannnels(mintChannelIndex).EnegryParameter.BurnerHeight)


                nudFuelRatio.Value = Val(mobjChannnels(mintChannelIndex).EnegryParameter.FualRatio)

                nudHCLCur.Value = Val(mobjChannnels(mintChannelIndex).EnegryParameter.HCLCurr)



                '//-----
                '//----- Commented by Sachin Dokhale against VCK
                'Dim intSelectedModeType As Integer
                'If gintInstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.DoubleBeam Then
                '    Select Case mobjChannnels(mintChannelIndex).EnegryParameter.Cal_Mode()
                '        Case EnumCalibrationMode.AA
                '            intSelectedModeType = 0
                '        Case EnumCalibrationMode.HCLE
                '            intSelectedModeType = 1
                '        Case EnumCalibrationMode.AABGC
                '            intSelectedModeType = 2
                '            'Case EnumCalibrationMode.SELFTEST
                '            '    intSelectedModeType = 2
                '    End Select
                'Else
                '    intSelectedModeType = mobjChannnels(mintChannelIndex).EnegryParameter.Cal_Mode()
                'End If
                cmbModes.SelectedIndex = mobjChannnels(mintChannelIndex).EnegryParameter.Cal_Mode()

                'cmbModes.SelectedIndex = intSelectedModeType


                '//----- Set the d2E default mode
                '//----- Set slow Speed s
                Select Case mobjChannnels(mintChannelIndex).EnegryParameter.ScanSpeed
                    Case CONST_FASTStep
                        cmbSpeed.SelectedIndex = 0
                    Case CONST_MEDIUMStep
                        cmbSpeed.SelectedIndex = 1
                    Case CONST_SLOWStep
                        cmbSpeed.SelectedIndex = 2
                End Select


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
            '//----- added by Sachin dokhale to remove handlers on 08.10.07
            '28.09.07
            'If gblnSetSpeedIssue = True Then
            RemoveHandler nudFuelRatio.ValueEditorClick, AddressOf nudFuelRatio_ValueEditorClick
            RemoveHandler nudFuelRatio.ValueEditorValueChanged, AddressOf nudFuelRatio_ValueChanged

            'AddHandler nudBurnerHeight.ValueChanged, AddressOf nudBurnerHeight_ValueChanged
            RemoveHandler nudBurnerHeight.ValueEditorClick, AddressOf nudBurnerHeight_ValueEditorClick
            RemoveHandler nudBurnerHeight.ValueEditorValueChanged, AddressOf nudBurnerHeight_ValueChanged

            'AddHandler nudD2Cur.ValueChanged, AddressOf nudD2Cur_ValueChanged
            RemoveHandler nudD2Cur.ValueEditorClick, AddressOf nudD2Cur_ValueEditorClick
            RemoveHandler nudD2Cur.ValueEditorValueChanged, AddressOf nudD2Cur_ValueChanged

            'AddHandler nudHCLCur.ValueChanged, AddressOf nudHCLCur_ValueChanged
            RemoveHandler nudHCLCur.ValueEditorClick, AddressOf nudHCLCur_ValueEditorClick
            RemoveHandler nudHCLCur.ValueEditorValueChanged, AddressOf nudHCLCur_ValueChanged

            'AddHandler nudSlit.ValueChanged, AddressOf nudSlit_ValueChanged
            RemoveHandler nudSlit.ValueEditorClick, AddressOf nudSlit_ValueEditorClick
            RemoveHandler nudSlit.ValueEditorValueChanged, AddressOf nudSlit_ValueChanged
            RemoveHandler nudSlit_Ref.ValueEditorClick, AddressOf nudSlit_Ref_ValueEditorClick
            RemoveHandler nudSlit_Ref.ValueEditorValueChanged, AddressOf nudSlit_Ref_ValueChanged

            'AddHandler nudPMT.ValueChanged, AddressOf nudPMT_ValueChanged
            RemoveHandler nudPMT.ValueEditorClick, AddressOf nudPMT_ValueEditorClick
            RemoveHandler nudPMT.ValueEditorValueChanged, AddressOf nudPMT_ValueChanged
            RemoveHandler nudPMT_Ref.ValueEditorClick, AddressOf nudPMT_Ref_ValueEditorClick
            RemoveHandler nudPMT_Ref.ValueEditorValueChanged, AddressOf nudPMT_Ref_ValueChanged

            'End If
            '//-----

            '//----- Set PMT Object
            nudPMT.Value = gobjInst.PmtVoltage
            If Not (gintInstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.SingleBeam) Then
                nudPMT_Ref.Value = gobjInst.PmtVoltageReference
            End If
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
            nudSlit_Ref.Value = gobjClsAAS203.funcGet_SlitWidth(1)


            'nudBurnerHeight.Value = mobjChannnels(mintChannelIndex).EnegryParameter.BurnerHeight
            nudBurnerHeight.Value = gobjClsAAS203.funcReadBurnerHeight()
            'mobjParameters.BurnerHeight = CDbl(nudBurnerHeight.Value)

            'nudFuelRatio.Value = mobjChannnels(mintChannelIndex).EnegryParameter.FualRatio
            funcSetFuelParameter(mdblFuelRatio)
            mdblFuelRatio = Format(mdblFuelRatio, "#.00")
            nudFuelRatio.Value = Format(mdblFuelRatio, "#.00")
            'mobjParameters.FualRatio = Format(mdblFuelRatio, "#.00")

            'nudHCLCur.Value = mobjChannnels(mintChannelIndex).EnegryParameter.HCLCurr
            nudHCLCur.Value = gobjInst.Current
            'mobjParameters.HCLCurr = gobjInst.Current

            If Not (mobjParameters Is Nothing) Then
                mobjParameters.PMTV = gobjInst.PmtVoltage
                mobjParameters.PMTV_Ref = gobjInst.PmtVoltageReference
                mobjParameters.HCLCurr = gobjInst.Current
                mobjParameters.D2Curr = gobjInst.D2Current
                mobjParameters.SlitWidth = Val(nudSlit.Value)
                mobjParameters.SlitWidthRef = Val(nudSlit_Ref.Value)
                mobjParameters.BurnerHeight = CDbl(nudBurnerHeight.Value)
                mobjParameters.FualRatio = Format(mdblFuelRatio, "#.00")
                mobjParameters.LampEle = gobjInst.Lamp.LampParametersCollection(gobjInst.Lamp_Position - 1).ElementName
                mobjParameters.LampTurrNo = gobjInst.Lamp_Position

                lblWvPos.Text = mXValueLable & gobjInst.WavelengthCur
                lblWvPos.Refresh()
                lblYValue.Text = mYValueLable
                lblYValue.Refresh()
            End If
            '//-----

            'cmbModes.SelectedIndex = mobjChannnels(mintChannelIndex).EnegryParameter.Cal_Mode()
            'cmbModes.SelectedIndex = 

            'End If
            cmbModes.SelectedIndex = gobjInst.Mode

            'If gblnSetSpeedIssue = True Then
            '//----- added by Sachin dokhale to add handlers on 08.10.07
            '28.09.07
            AddHandler nudFuelRatio.ValueEditorClick, AddressOf nudFuelRatio_ValueEditorClick
            AddHandler nudFuelRatio.ValueEditorValueChanged, AddressOf nudFuelRatio_ValueChanged

            'AddHandler nudBurnerHeight.ValueChanged, AddressOf nudBurnerHeight_ValueChanged
            AddHandler nudBurnerHeight.ValueEditorClick, AddressOf nudBurnerHeight_ValueEditorClick
            AddHandler nudBurnerHeight.ValueEditorValueChanged, AddressOf nudBurnerHeight_ValueChanged

            'AddHandler nudD2Cur.ValueChanged, AddressOf nudD2Cur_ValueChanged
            AddHandler nudD2Cur.ValueEditorClick, AddressOf nudD2Cur_ValueEditorClick
            AddHandler nudD2Cur.ValueEditorValueChanged, AddressOf nudD2Cur_ValueChanged

            'AddHandler nudHCLCur.ValueChanged, AddressOf nudHCLCur_ValueChanged
            AddHandler nudHCLCur.ValueEditorClick, AddressOf nudHCLCur_ValueEditorClick
            AddHandler nudHCLCur.ValueEditorValueChanged, AddressOf nudHCLCur_ValueChanged

            'AddHandler nudSlit.ValueChanged, AddressOf nudSlit_ValueChanged
            AddHandler nudSlit.ValueEditorClick, AddressOf nudSlit_ValueEditorClick
            AddHandler nudSlit.ValueEditorValueChanged, AddressOf nudSlit_ValueChanged
            AddHandler nudSlit_Ref.ValueEditorClick, AddressOf nudSlit_Ref_ValueEditorClick
            AddHandler nudSlit_Ref.ValueEditorValueChanged, AddressOf nudSlit_Ref_ValueChanged

            'AddHandler nudPMT.ValueChanged, AddressOf nudPMT_ValueChanged
            AddHandler nudPMT.ValueEditorClick, AddressOf nudPMT_ValueEditorClick
            AddHandler nudPMT.ValueEditorValueChanged, AddressOf nudPMT_ValueChanged
            AddHandler nudPMT_Ref.ValueEditorClick, AddressOf nudPMT_Ref_ValueEditorClick
            AddHandler nudPMT_Ref.ValueEditorValueChanged, AddressOf nudPMT_Ref_ValueChanged
            'End If
            '//-----
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

    Private Sub subLabelDisplay(ByVal objChannel As Spectrum.Channel)
        '=====================================================================
        ' Procedure Name        :   subLabelDisplay
        ' Description           :    
        ' Purpose               :    
        '                           
        ' Parameters Passed     :   None.
        ' Returns               :    
        ' Parameters Affected   :   None.
        ' Assumptions           :
        ' Dependencies          :
        ' Author                :   Gitesh, Uday
        ' Created               :   Saturday, November 15, 2003 18:49
        ' Revisions             :
        '=====================================================================
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

    Private Function funcAddChannelToCollection(ByRef objInChannel As Spectrum.Channel) As Integer    'ByRef objInChannel As Spectrum.EnergyChannels
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
        Dim intChannel_no As Integer = -1
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
            mobjChannnels.Add(objInChannel)
            objInChannel.ChannelNo = intChannel_no
            'mobjChannnels.Add(objInChannel)

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
            Return -1
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
    '    ' Procedure Name        :   funcCloneParameter
    '    ' Description           :    
    '    ' Purpose               :    
    '    '                           
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
    '        objCloneParameter.PMTV_Ref = inobjparamter.PMTV_Ref
    '        objCloneParameter.ScanSpeed = inobjparamter.ScanSpeed
    '        objCloneParameter.SlitWidth = inobjparamter.SlitWidth
    '        objCloneParameter.SlitWidthRef = inobjparamter.SlitWidthRef
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

        Try
            'void  abs_trans(HWND hwnd)
            '{
            'int i, k;

            'if (addata.ad!=NULL) {
            '  for (i=0; i<addata.counter; i++){
            '	 k= 2047.0 + exp((2.0- ((addata.ad[i]-2047.0)*2.0/1638.4)) *log(10))*2048.0/100.0;
            '	 addata.ad[i] =k;
            '	}
            '  UVABS=FALSE;
            '  SpectGraph.Ymin = 0;
            '  SpectGraph.Ymax = 100;
            '  Scroll_Mode1(hwnd,IDC_MODE, -1 );
            '  }
            '}

            gblnUVABS = False
            If mobjChannnels.Count > 0 Then
                If mobjChannnels.item(mintChannelIndex).Spectrums.Count > 0 Then
                    'For intXaxisIdx = gFuncGetIndexWv(mobjChannnels.item(mintChannelIndex).UVParameter.XaxisMin, False) To gFuncGetIndexWv(mobjChannnels.item(mintChannelIndex).UVParameter.XaxisMax, False)
                    For intXaxisIdx = 0 To mobjChannnels.item(mintChannelIndex).Spectrums.item(0).Readings.Count - 1
                        dblCurrYaxis = mobjChannnels.item(mintChannelIndex).Spectrums.item(0).Readings.item(intXaxisIdx).YaxisData
                        'k= 2047.0 + exp((2.0- ((addata.ad[i]-2047.0)*2.0/1638.4)) *log(10))*2048.0/100.0;
                        dblNewYaxis = 2047.0 + Math.Exp((2.0 - ((dblCurrYaxis - 2047.0) * 2.0 / 1638.4)) * Math.Log(10)) * 2048.0 / 100.0
                        mobjChannnels.item(mintChannelIndex).Spectrums.item(0).Readings.item(intXaxisIdx).YaxisData = dblNewYaxis
                    Next
                End If
            End If
            funcClearGraph()

            mobjChannnels.item(mintChannelIndex).EnegryParameter.YaxisMax = 100
            mobjChannnels.item(mintChannelIndex).EnegryParameter.YaxisMin = 0

            funcClearGraph()

            funcDisplayGraph(mobjChannnels.item(mintChannelIndex))
            funcGraphPreRequisite(mobjParameters.Cal_Mode, _
                                    mobjParameters.XaxisMin, _
                                    mobjParameters.XaxisMax, _
                                    mobjParameters.YaxisMin, _
                                    mobjParameters.YaxisMax)
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

                'addataSpect.dblWvMin = 230.0
                'addataSpect.dblWvMax = 250.0

                'mobjParameters.XaxisMin = const_WvMin
                'mobjParameters.XaxisMax = const_WvMax

                '''commented and added following code on '08.05.08
                '-----------------
                '''If WvStartRange = 0.0 Then
                '''    WvLastRange = const_WvMax
                '''ElseIf Not (gobjInst.WavelengthCur = 0.0) Then
                '''    If (gobjInst.WavelengthCur < WvStartRange Or _
                '''        gobjInst.WavelengthCur > WvLastRange) Then
                '''        Dim dblRangeDiff As Double = WvLastRange - WvStartRange
                '''        WvLastRange = WvStartRange + dblRangeDiff
                '''        WvStartRange = gobjInst.WavelengthCur
                '''    End If
                '''End If
                '-----------------

                '08.05.08
                '-----------------

                WvStartRange = Fix(gobjInst.WavelengthCur)
                WvLastRange = WvStartRange + 10
                lblWvPos.Text = mXValueLable & FormatNumber(gobjInst.WavelengthCur, 2)
                '-----------------

                mobjParameters.XaxisMin = WvStartRange
                mobjParameters.XaxisMax = WvLastRange

                Select Case gobjInst.Mode
                    Case EnumCalibrationMode.AA, EnumCalibrationMode.AABGC, EnumCalibrationMode.MABS

                        mobjParameters.YaxisMax = const_YMaxAbs
                        mobjParameters.YaxisMin = const_YMinAbs
                        mYValueLable = const_Absorbance
                    Case EnumCalibrationMode.HCLE, EnumCalibrationMode.D2E
                        mobjParameters.YaxisMin = const_YMinEnergy
                        mobjParameters.YaxisMax = const_YMaxEnergy
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

                'addataSpect.intSpeed = 0
                'addataSpect.intMode = gobjInst.Mode
                'mobjParameters.ScanSpeed = CONST_SLOWStep 

                mobjParameters.Cal_Mode = gobjInst.Mode
                'addataSpect.blnPloted = True
                '//-----
                AASEnergySpectrum.AldysPane.Legend.IsVisible = False
                funcClearGraph()
                funcGraphPreRequisite(mobjParameters.Cal_Mode, _
                                        mobjParameters.XaxisMin, _
                                        mobjParameters.XaxisMax, _
                                        mobjParameters.YaxisMin, _
                                        mobjParameters.YaxisMax)

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
            If mblnReSetSpectrumParameter = False Then
                If (gobjInst.Mode = intCalibrationMode) Then
                    funcSetSpectrumParameter = True
                    mblnReSetSpectrumParameter = True
                    Exit Function
                End If
            End If

            If gobjCommProtocol.funcCalibrationMode(intCalibrationMode) Then

                'addataSpect.dblWvMin = 230.0
                'addataSpect.dblWvMax = 250.0

                Select Case gobjInst.Mode
                    Case EnumCalibrationMode.AA, EnumCalibrationMode.AABGC, EnumCalibrationMode.MABS

                        mobjParameters.YaxisMax = const_YMaxAbs
                        mobjParameters.YaxisMin = const_YMinAbs
                        mYValueLable = const_Absorbance
                    Case EnumCalibrationMode.HCLE, EnumCalibrationMode.D2E
                        mobjParameters.YaxisMin = const_YMinEnergy
                        mobjParameters.YaxisMax = const_YMaxEnergy
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

                lblYValue.Text = mYValueLable
                lblYValue.Refresh()

                'addataSpect.intSpeed = 0
                'addataSpect.intMode = gobjInst.Mode

                mobjParameters.Cal_Mode = gobjInst.Mode
                'addataSpect.blnPloted = True
                '//-----
                AASEnergySpectrum.AldysPane.Legend.IsVisible = False
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
        ' Created               : 21.11.06
        ' Revisions             : 
        '=====================================================================
        Dim intMaxD2Current As Integer
        Dim intMinD2Current As Integer
        Try
            funcSetDefaultParameter = False

            '//--------
            '/----- Set the Form object parameter
            '//----- Set the default parameter to the spectrum.

            '//----- Set PMT Object
            'nudPMT.DecimalPlaces = 0
            'nudPMT.Increment = 5.0
            'nudPMT.Maximum = 700.0
            'nudPMT.Minimum = 0.0
            nudPMT.DecimalPlace = 0
            nudPMT.ChangeFactor = 5.0
            nudPMT.MaxValue = 700.0
            nudPMT.MinValue = 0.0
            nudPMT.Value = gobjInst.PmtVoltage
            mobjParameters.PMTV = gobjInst.PmtVoltage

            '//-----commented on 21.01.08 Deepak
            ''If gintInstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.DoubleBeam Then
            ''If gobjInst.PmtVoltageReference = 0 Then

            ''    'gobjInst.PmtVoltageReference = gobjInst.PmtVoltage
            ''    Call funcSetPmtVParameter_Ref(gobjInst.PmtVoltage)
            ''End If
            ''End If

            If Not (gintInstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.SingleBeam) Then
                nudPMT_Ref.DecimalPlace = 0
                nudPMT_Ref.ChangeFactor = 5.0
                nudPMT_Ref.MaxValue = 700.0
                nudPMT_Ref.MinValue = 0.0
                nudPMT_Ref.Value = gobjInst.PmtVoltageReference
                mobjParameters.PMTV_Ref = gobjInst.PmtVoltageReference
                nudPMT_Ref.Enabled = True
            Else
                nudPMT_Ref.Enabled = False
            End If
            '//----- Set D2 current Object
            If gobjCommProtocol.SRLamp Then
                intMaxD2Current = 600
                intMinD2Current = 100
            Else
                intMaxD2Current = 300
                intMinD2Current = 100
            End If

            '---added by deepak on 02.08.07 to make the ref pmt equal to samp pmt in aa mode
            'If gintInstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.DoubleBeam Then
            '    If gobjInst.PmtVoltageReference = 0 Then

            '        'gobjInst.PmtVoltageReference = gobjInst.PmtVoltage
            '        Call funcSetPmtVParameter_Ref(gobjInst.PmtVoltage)
            '    End If
            'End If
            '---

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
            '//-----

            '//----- Set Fuel Ratio object
            'nudFuelRatio.DecimalPlaces = 2
            'nudFuelRatio.Increment = 0.1
            'nudFuelRatio.Maximum = 25.0
            'nudFuelRatio.Minimum = -115.0

            nudFuelRatio.DecimalPlace = 2
            nudFuelRatio.ChangeFactor = 0.1
            nudFuelRatio.MaxValue = 25.0
            nudFuelRatio.MinValue = 0.0

            'funcSetFuelParameter(0.0)
            'Call gobjCommProtocol.funcGet_NV_Pos()
            mdblFuelRatio = gobjClsAAS203.funcGet_Fuel_Ratio(True)
            If mdblFuelRatio < 0.0 Then
                ''setting some validation
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

            '//----- Set Burner Height Object
            'nudBurnerHeight.DecimalPlaces = 2
            'nudBurnerHeight.Increment = 0.1
            'nudBurnerHeight.Maximum = 6.0
            'nudBurnerHeight.Minimum = 0.0

            nudBurnerHeight.DecimalPlace = 2
            nudBurnerHeight.ChangeFactor = 0.1
            nudBurnerHeight.MaxValue = 6.0
            nudBurnerHeight.MinValue = 0.0
            dblBhHeight = gobjClsAAS203.funcReadBurnerHeight()
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

            nudSlit_Ref.DecimalPlace = 1
            nudSlit_Ref.ChangeFactor = 0.1
            nudSlit_Ref.MaxValue = 2.0
            nudSlit_Ref.MinValue = 0.0
            nudSlit_Ref.Value = gobjClsAAS203.funcGet_SlitWidth(1)
            mobjParameters.SlitWidthRef = CDbl(nudSlit_Ref.Value)

            mobjParameters.LampEle = gobjInst.Lamp.LampParametersCollection(gobjInst.Lamp_Position - 1).ElementName
            mobjParameters.LampTurrNo = gobjInst.Lamp_Position


            'mobjParameters.Cal_Mode = gobjInst.Mode

            '//----- Commented by Sachin Dokhale against VCK
            'If gintInstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.DoubleBeam Then
            '    Dim intSelectedModeType As Integer
            '    Select Case gobjInst.Mode
            '        Case EnumCalibrationMode.AA
            '            intSelectedModeType = EnumCalibrationMode.AA
            '        Case EnumCalibrationMode.HCLE
            '            intSelectedModeType = EnumCalibrationMode.HCLE
            '        Case EnumCalibrationMode.AABGC
            '            intSelectedModeType = 2 'EnumCalibrationMode.AABGC
            '            'Case EnumCalibrationMode.SELFTEST
            '            '    intSelectedModeType = 2 'EnumCalibrationMode.SELFTEST
            '    End Select
            '    '    Call funcSetSpectrumParameter(intSelectedModeType)
            '    cmbModes.SelectedIndex = intSelectedModeType
            'Else
            '    cmbModes.SelectedIndex = gobjInst.Mode
            'End If
            '//-----
            cmbModes.SelectedIndex = gobjInst.Mode
            mobjParameters.ScanSpeed = CONST_SLOWStep
            cmbSpeed.SelectedIndex = 2
            'mobjParameters.ScanSpeed = CONST_FASTStep
            lblYValue.Text = mYValueLable
            lblYValue.Refresh()
            '//-----

            funcSetDefaultParameter = True

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
                    'gobjInst.PmtVoltage = dblPMTVolt
                    funcSetPmtVParameter = True
                End If

                mobjParameters.PMTV = Val(dblPMTVolt)
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

    Private Function funcSetPmtVParameter_Ref(ByVal dblPmtV As Double) As Boolean
        '=====================================================================
        ' Procedure Name        : funcSetPmtVParameter_Ref
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
            dblPMTVolt = gobjInst.PmtVoltageReference

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
                If gobjCommProtocol.funcSet_PMTReferenceBeam(dblPMTVolt) = True Then
                    'gobjInst.PmtVoltage = dblPMTVolt
                    funcSetPmtVParameter_Ref = True
                End If

                mobjParameters.PMTV_Ref = Val(dblPMTVolt)
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
            If gobjInst.Lamp_Position >= 1 And gobjInst.Lamp_Position <= gobjClsAAS203.funcGetMaxLamp() Then
                dblLampCurrent = gobjInst.Current
                'dblHCL_Cur()
                dblLampCurrent = dblHCL_Cur
                If dblHCL_Cur > 25 Then dblLampCurrent = 25
                If dblHCL_Cur < 0 Then dblLampCurrent = 0
                gobjCommProtocol.funcSet_HCL_Cur(dblLampCurrent, gobjInst.Lamp_Position)
                gobjInst.Current = dblLampCurrent
            End If
            mobjParameters.HCLCurr = Val(dblLampCurrent)
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

        Try
            funcSetSlit_WidthParameter = False

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

    Private Function funcSetSlit_WidthParameter_Ref(ByVal dblSlit_Width As Double) As Boolean
        '=====================================================================
        ' Procedure Name        : funcSetSlit_WidthParameter_Ref
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
            funcSetSlit_WidthParameter_Ref = False

            dblSlitWidth = gobjClsAAS203.funcGet_SlitWidth(1)   '1 is for Exit Slit in Double Beam

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

            Call gobjCommProtocol.funcSet_SlitWidth(dblSlitWidth, 1)
            mobjParameters.SlitWidthRef = Val(dblSlitWidth)
            funcSetSlit_WidthParameter_Ref = True
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

            TimerEnergyDisplay.Enabled = False
            If Not (mdblFuelRatio = dblFuel) Then

                Call gobjClsAAS203.funcSetFuel(CDbl(nudFuelRatio.Value))
            End If

            'Call gobjCommProtocol.funcGet_NV_Pos()
            mdblFuelRatio = gobjClsAAS203.funcGet_Fuel_Ratio(True)
            If mdblFuelRatio < 0.0 Then
                ''setting some validation
                mdblFuelRatio = 0.0
            Else
                mdblFuelRatio = Format(mdblFuelRatio, "#0.00")
            End If
            nudFuelRatio.Value = mdblFuelRatio
            mobjParameters.FualRatio = mdblFuelRatio
            funcSetFuelParameter = mdblFuelRatio
            TimerEnergyDisplay.Enabled = True
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
            funcSetBurner_HeightParameter = 0.0
            'If intBurner_Height = 1 Then
            '    Call gobjClsAAS203.funcIncr_Height()
            'ElseIf intBurner_Height = -1 Then
            '    Call gobjClsAAS203.funcDecr_Height()
            'Else
            '    gobjCommProtocol.func_Get_BH_Pos()
            'End If
            'mobjParameters.BurnerHeight = gobjClsAAS203.funcReadBurnerHeight()
            'funcSetBurner_HeightParameter = gobjClsAAS203.funcReadBurnerHeight()
            TimerEnergyDisplay.Enabled = False
            gobjClsAAS203.funcSetBHPos(FormatNumber(dblBurner_Height, 1))
            dblBhHeight = gobjClsAAS203.funcReadBurnerHeight()
            funcSetBurner_HeightParameter = dblBhHeight
            TimerEnergyDisplay.Enabled = True
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

    Public Function funcOnSpect(ByVal BaseLine As Boolean, ByRef lblScanStatus As System.Object, _
                ByRef lblOnlineWv As System.Object) As Boolean

        '=====================================================================
        ' Procedure Name        :   funcOnSpect
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
        'Dim ObjParameter As New Spectrum.EnergySpectrumParameter



        mobjOnlineChannel = New Spectrum.Channel(True)
        mobjEnegyChannel = New Spectrum.EnergyChannels
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
        mblnAvoidProcessing = True
        'RemoveHandler mnuIgnite.Click, AddressOf btnAutoIgnition_Click

        '--- Start the Spectrum analysis
        mobjController = New clsBgThread(Me)
        'mobjclsBgSpectrum = New clsBgSpectrum(lblWvPos, lblOnlineWv, _
        '              mobjParameters.XaxisMax, _
        '              mobjParameters.XaxisMin, _
        '              mobjParameters.YaxisMax, _
        '              mobjParameters.YaxisMin, _
        '              mobjParameters.Cal_Mode, _
        '              mobjParameters.ScanSpeed)

        mobjclsBgSpectrum = New clsBgSpectrum(lblWvPos, lblOnlineWv, _
                      mobjParameters.XaxisMax, _
                      mobjParameters.XaxisMin, _
                      mobjParameters.YaxisMax, _
                      mobjParameters.YaxisMin, _
                      mobjParameters.Cal_Mode, _
                      mobjParameters.ScanSpeed, 0, IsRefBeamSelected)

        ''TurretOptimizationThread = New clsBgTurretOptimization(lblPMT, lblTurretPosition, lblTurretOptimisation, mdblLampCurrent, mintLampPosition, aasGraphTurretOptimisation)
        mobjController.Start(mobjclsBgSpectrum)
        funcOnSpect = True
    End Function

#Region "Save/Load Spectrum Function For Double Beam"

    '--- Save the Current Active channel to a UVSpectrum(uvs) file
    Private Function funcSaveSpectrumFile_Double() As Boolean
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
            funcSaveSpectrumFile_Double = False
            If mobjChannnels.item(mintChannelIndex) Is Nothing Then
                gobjMessageAdapter.ShowMessage(constSpectrumNotPresent)
                'gFuncShowMessage("Error", "Spectrum is not present for saving.", EnumMessageType.Information)
                Exit Function
            End If

            Dim objEnergyChannels As New Spectrum.EnergyChannels

            'objEnergyChannels.Add(mobjChannnels.item(mintChannelIndex - 1))
            objEnergyChannels.Add(mobjChannnels.item(mintChannelIndex))

            If gstructSettings.Enable21CFR = True Then
                If Not gfuncGetFileAuthenticationData(objEnergyChannels.DigitalSignature) Then
                    Return True
                End If
            Else
                '--- This is for saving the file with login Authnetication 
                '--- when 21 cfr is off
                'If Not gfuncGetFileAuthenticationData_21CFR_OFF(objchannel.DigitalSignature) Then
                '    Return True
                'End If
            End If

            Dim objStream As Stream
            Dim objsfdSpectrum As New SaveFileDialog

            '--- Show the save dialog to accept the *.spt file.
            objsfdSpectrum.Filter = "Spectrum Files(*" & CONST_EnergySpectrumFileExtDB & ")|*" & CONST_EnergySpectrumFileExtDB
            objsfdSpectrum.FilterIndex = 1
            objsfdSpectrum.InitialDirectory = strPath.GetCurrentDirectory.ToString + "\Energy Spectrums"
            objsfdSpectrum.RestoreDirectory = True

            If objsfdSpectrum.ShowDialog() = DialogResult.OK Then
                objEnergyChannels.DigitalSignature.FileName = objsfdSpectrum.FileName
                '--- Check if file exist   
                If (objsfdSpectrum.CheckFileExists()) Then
                    If gobjMessageAdapter.ShowMessage(constSaveAs) = True Then
                        'If (MessageBox.Show("DO YOU WISH TO OVERWRITE", "SAVE AS", MessageBoxButtons.YesNo) = DialogResult.Yes) Then
                        If Not gfuncSerializeObjectDB(objsfdSpectrum.FileName, objEnergyChannels) Then
                            gobjMessageAdapter.ShowMessage(constErrorFileSaving)
                            'gFuncShowMessage("Error", "ERROR IN SAVING FILE.", EnumMessageType.Information)
                        End If
                    Else
                        Return True
                    End If
                Else
                    If Not gfuncSerializeObjectDB(objsfdSpectrum.FileName, objEnergyChannels) Then
                        gobjMessageAdapter.ShowMessage(constErrorFileSaving)
                        'gFuncShowMessage("Error", "ERROR IN SAVING FILE.", EnumMessageType.Information)
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
                            If Not gfuncSerializeObjectDB(strFileLogPath, objEnergyChannels) Then
                                Throw New Exception
                            End If
                            '--- Log the file 
                            Call gfuncInsertFileLog(lngActivityLogID, objsfdSpectrum.FileName, strFileLogPath)
                        End If
                    End If
                End If
            End If
            objsfdSpectrum.Dispose()
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
            blnYetFileNotSave = False
        End Try

    End Function

    '--- Load channel from spectrum(spt) file
    Private Function funcLoadSpectrumFile_Double() As Boolean
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
            funcLoadSpectrumFile_Double = False

            objofdSpectrum.InitialDirectory = strPath.GetCurrentDirectory.ToString & "\Energy Spectrums"
            objofdSpectrum.Filter = "Spectrum Files(*" & CONST_EnergySpectrumFileExtDB & ")|*" & CONST_EnergySpectrumFileExtDB
            objofdSpectrum.FilterIndex = 1
            objofdSpectrum.RestoreDirectory = True

            ArrlstGraphCurveItem.Add(mGraphCurveItem)
            intCurveIndex = ArrlstGraphCurveItem.Count - 1

            If objofdSpectrum.ShowDialog() = DialogResult.OK Then
                If (objofdSpectrum.CheckFileExists()) Then
                    Dim objchannels As Spectrum.EnergyChannels
                    Dim intChannel_no As Int16

                    If gstructSettings.Enable21CFR = True Then
                        Dim objChn As EnergyChannels
                        objChn = gfuncDeSerializeObject(objofdSpectrum.FileName, EnumDeserializeObjType.EnergySpectrumDB)
                        If gfuncCheckForFileAuthentication(objChn.DigitalSignature) Then
                            objchannels = objChn
                        Else
                            Call gobjMessageAdapter.ShowMessage(constAccessDenied)
                            Return False
                        End If
                    End If

                    objchannels = gfuncDeSerializeObject(objofdSpectrum.FileName, EnumDeserializeObjType.EnergySpectrumDB)
                    '--- Add the new channel to the channels collection and 
                    '--- accordingly save the channel file to the disk
                    Dim intChannelIdx As Integer
                    If objchannels.Count > 0 Then
                        For intChannelIdx = 0 To objchannels.Count - 1
                            intChannel_no = funcAddChannelToCollection(objchannels(intChannelIdx))
                            mintChannelIndex = intChannel_no
                        Next
                    End If
                    If mobjChannnels.Count > 0 Then
                        mobjChannnels.item(0) = objchannels(0)
                        'mobjChannnels.item(1) = objchannels(1)
                        mobjEnegyChannel.Add(objchannels(0))
                        'mobjEnegyChannel.Add(objchannels(1))

                        mobjParameters = Nothing
                        mobjParameters = mobjChannnels.item(0).EnegryParameter
                        Call funcSetParameter()
                        funcClearGraph()
                        intChannelIdx = 0
                        'For intChannelIdx = 0 To 1
                        'funcDisplayGraph(mobjChannnels.item(intChannelIdx), mGraphCurveItem)
                        funcDisplayGraphOffline(mobjChannnels.item(intChannelIdx), mGraphCurveItem)
                        ArrlstGraphCurveItem.Add(mGraphCurveItem)
                        intCurveIndex = ArrlstGraphCurveItem.Count - 1
                        'Next
                        funcGraphPreRequisite(mobjParameters.Cal_Mode, _
                                            mobjParameters.XaxisMin, _
                                            mobjParameters.XaxisMax, _
                                            mobjParameters.YaxisMin, _
                                           mobjParameters.YaxisMax)

                    Else
                        mobjParameters = Nothing
                        mobjChannnels.Add(objchannels(0))
                        'mobjChannnels.Add(objchannels(1))
                        mobjParameters = mobjChannnels.item(intChannel_no).EnegryParameter
                        Call funcSetParameter()
                        funcClearGraph()

                        funcDisplayGraph(mobjChannnels.item(intChannel_no), mGraphCurveItem)
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
            funcLoadSpectrumFile_Double = True

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
            If mobjChannnels.item(mintChannelIndex) Is Nothing Then
                gobjMessageAdapter.ShowMessage(constSpectrumNotPresent)
                'gFuncShowMessage("Error", "Spectrum is not present for saving.", EnumMessageType.Information)
                Exit Function
            End If

            Dim objchannel As Spectrum.Channel

            objchannel = mobjChannnels.item(mintChannelIndex)

            If gstructSettings.Enable21CFR = True Then
                If Not gfuncGetFileAuthenticationData(objchannel.DigitalSignature) Then
                    Return True
                End If
            Else
                '--- This is for saving the file with login Authnetication 
                '--- when 21 cfr is off
                'If Not gfuncGetFileAuthenticationData_21CFR_OFF(objchannel.DigitalSignature) Then
                '    Return True
                'End If
            End If

            Dim objStream As Stream
            Dim objsfdSpectrum As New SaveFileDialog

            '--- Show the save dialog to accept the *.spt file.
            objsfdSpectrum.Filter = "Spectrum Files(*" & CONST_EnergySpectrumFileExt & ")|*" & CONST_EnergySpectrumFileExt
            objsfdSpectrum.FilterIndex = 1
            objsfdSpectrum.InitialDirectory = strPath.GetCurrentDirectory.ToString + "\Energy Spectrums"
            objsfdSpectrum.RestoreDirectory = True

            If objsfdSpectrum.ShowDialog() = DialogResult.OK Then
                objchannel.DigitalSignature.FileName = objsfdSpectrum.FileName
                '--- Check if file exist   
                If (objsfdSpectrum.CheckFileExists()) Then
                    If gobjMessageAdapter.ShowMessage(constSaveAs) = True Then
                        'If (MessageBox.Show("DO YOU WISH TO OVERWRITE", "SAVE AS", MessageBoxButtons.YesNo) = DialogResult.Yes) Then
                        If Not gfuncSerializeObject(objsfdSpectrum.FileName, objchannel) Then
                            gobjMessageAdapter.ShowMessage(constErrorFileSaving)
                            'gFuncShowMessage("Error", "ERROR IN SAVING FILE.", EnumMessageType.Information)
                        End If
                    Else
                        Return True
                    End If
                Else
                    If Not gfuncSerializeObject(objsfdSpectrum.FileName, objchannel) Then
                        gobjMessageAdapter.ShowMessage(constErrorFileSaving)
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
            blnYetFileNotSave = False
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

            objofdSpectrum.InitialDirectory = strPath.GetCurrentDirectory.ToString & "\Energy Spectrums"
            objofdSpectrum.Filter = "Spectrum Files(*" & CONST_EnergySpectrumFileExt & ")|*" & CONST_EnergySpectrumFileExt
            objofdSpectrum.FilterIndex = 1
            objofdSpectrum.RestoreDirectory = True

            If objofdSpectrum.ShowDialog() = DialogResult.OK Then
                If (objofdSpectrum.CheckFileExists()) Then
                    Dim objchannel As Spectrum.Channel
                    Dim intChannel_no As Int16

                    If gstructSettings.Enable21CFR = True Then
                        Dim objChn As Channel
                        objChn = gfuncDeSerializeObject(objofdSpectrum.FileName, EnumDeserializeObjType.EnergySpectrum)
                        If gfuncCheckForFileAuthentication(objChn.DigitalSignature) Then
                            objchannel = objChn
                        Else
                            Call gobjMessageAdapter.ShowMessage(constAccessDenied)
                            Return False
                        End If
                    End If

                    objchannel = gfuncDeSerializeObject(objofdSpectrum.FileName, EnumDeserializeObjType.EnergySpectrum)
                    '--- Add the new channel to the channels collection and 
                    '--- accordingly save the channel file to the disk

                    intChannel_no = funcAddChannelToCollection(objchannel)
                    mintChannelIndex = intChannel_no

                    If mobjChannnels.Count > 0 Then
                        mobjChannnels.item(0) = objchannel
                        mobjParameters = Nothing
                        mobjParameters = mobjChannnels.item(0).EnegryParameter
                        Call funcSetParameter()
                        funcClearGraph()

                        funcDisplayGraph(mobjChannnels.item(mintChannelIndex), mGraphCurveItem)
                        ArrlstGraphCurveItem.Add(mGraphCurveItem)

                        intCurveIndex = ArrlstGraphCurveItem.Count - 1

                        funcGraphPreRequisite(mobjParameters.Cal_Mode, _
                                                                        mobjParameters.XaxisMin, _
                                                                        mobjParameters.XaxisMax, _
                                                                        mobjParameters.YaxisMin, _
                                                                        mobjParameters.YaxisMax)
                    Else
                        mobjParameters = Nothing
                        mobjChannnels.Add(objchannel)
                        mobjParameters = mobjChannnels.item(intChannel_no).EnegryParameter
                        Call funcSetParameter()
                        funcClearGraph()

                        funcDisplayGraph(mobjChannnels.item(intChannel_no), mGraphCurveItem)
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
                    intValue = CInt(dblReturnValue)
                    dblReturnValue = intValue
                Case Else
                    'mobjfrmEditValues.txtValue.ValidationType = NumberValidator.NumberValidator.Validations.DoubleOnly
            End Select

            'mobjfrmEditValues.txtValue.RangeValidation = True
            'mobjfrmEditValues.txtValue.DigitsAfterDecimalPoint = 2
            'mobjfrmEditValues.txtValue.MaxLength = 4
            'mobjfrmEditValues.txtValue.MinimumRange = dblMinValue
            'mobjfrmEditValues.txtValue.MaximumRange = dblMaxValue
            mobjfrmEditValues.txtValue.Text = dblReturnValue
            mobjfrmEditValues.txtValue.Focus()
            mobjfrmEditValues.txtValue.SelectAll()
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

    Private Sub btnIgnite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        :   btnIgnite_Click
        ' Description           :   
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
        If mblnAvoidProcessing = True Then
            Exit Sub
        End If
        Try
            mblnAvoidProcessing = True
            TimerEnergyDisplay.Enabled = False
            Application.DoEvents()
            If Not IsNothing(gobjMain) Then
                'MsgBox("frmEnergyDB")
                'gobjMain.AutoIgnition()
                Call gobjCommProtocol.mobjCommdll.subTime_Delay(100)
                Call gobjClsAAS203.funcIgnite(True)
                Call funcGetInstParameter()
            End If
            TimerEnergyDisplay.Enabled = True
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
            'objWait.Dispose()
            '---------------------------------------------------------
        End Try

    End Sub

    Private Sub btnExtinguish_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        :   btnExtinguish_Click
        ' Description           :   
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
            If mblnAvoidProcessing = True Then
                Exit Sub
            End If
            mblnAvoidProcessing = True
            TimerEnergyDisplay.Enabled = False
            If Not IsNothing(gobjMain) Then
                'MsgBox("frmStatus")
                'gobjMain.Extinguish()
                Call gobjCommProtocol.mobjCommdll.subTime_Delay(100)
                Call gobjClsAAS203.funcIgnite(False)
                Call funcGetInstParameter()
            End If
            TimerEnergyDisplay.Enabled = True
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
            'objWait.Dispose()
            '---------------------------------------------------------
        End Try

    End Sub

    Private Sub btnSample_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSample.CheckedChanged
        '=====================================================================
        ' Procedure Name        :   btnSample_CheckedChanged
        ' Description           :   
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
        If btnSample.Checked = True Then
            IsRefBeamSelected = False
        Else
            IsRefBeamSelected = True
        End If
    End Sub

    Private Sub btnN2OIgnite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        :   btnN2OIgnite_Click
        ' Description           :   to handel the btnN2OIgnite_Click click event.
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
        ''this is used for N2O ignition
        If mblnAvoidProcessing = True Then
            Exit Sub
        End If
        Try
            mblnAvoidProcessing = True
            TimerEnergyDisplay.Enabled = False
            Call gobjCommProtocol.mobjCommdll.subTime_Delay(100)
            ''delay
            Call gobjCommProtocol.funcSwitchOver()
            ''function for switching to N2O flame
            Call funcGetInstParameter()
            ''get a current instrument status after switching to N2O flame
            TimerEnergyDisplay.Enabled = True
            mblnAvoidProcessing = False
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
            mblnAvoidProcessing = False
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
            TimerEnergyDisplay.Enabled = False
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
            TimerEnergyDisplay.Enabled = True
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
            TimerEnergyDisplay.Enabled = False
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
            TimerEnergyDisplay.Enabled = True
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
            If mblnAvoidProcessing = True Then
                Exit Sub
            End If
            mblnAvoidProcessing = True
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

    Private Sub DisableButtonsForBurnerHeight()
        '=====================================================================
        ' Procedure Name        :   DisableButtonsForBurnerHeight
        ' Description           :   
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
        btnClearSpectrum.Enabled = False
        mnuClearSpectrum.Enabled = False
        tlbbtnClearSpectrum.Enabled = False

        btnReturn.Enabled = False
        mnuExit.Enabled = False
        tlbbtnReturn.Enabled = False

        btnStart.Enabled = False
        mnuStart.Enabled = False
        tlbbtnStart.Enabled = False

        nudD2Cur.Enabled = False
        nudPMT.Enabled = False
        nudSlit.Enabled = False
        cmbSpeed.Enabled = False
        cmbModes.Enabled = False
        nudBurnerHeight.Enabled = False
        nudFuelRatio.Enabled = False
        nudHCLCur.Enabled = False
        nudPMT_Ref.Enabled = False  'For Double Beam
        nudSlit_Ref.Enabled = False 'For Double Beam

        btnLampParameters.Enabled = False
        tlbbtnLampParameters.Enabled = False
        mnuLampParameters.Enabled = False

        cmdChangeScale.Enabled = False
        tlbbtnChangeScale.Enabled = False
        mnuChangeScale.Enabled = False

        mnuSaveSpectrumFile.Enabled = False
        tlbbtnSaveSpectrumFile.Enabled = False

        mnuPeakPick.Enabled = False
        tlbbtnPeakPick.Enabled = False

        mnuPositionToMaxima.Enabled = False
        tlbbtnPositionToMaxima.Enabled = False

        mnuSmooth.Enabled = False
        tlbbtnSmooth.Enabled = False

        mnuLoadSpectrunFile.Enabled = False
        tlbbtnLoadspectrumFile.Enabled = False

        mnuContiniousTimeScan.Enabled = False
        tlbbtnContiniousTimeScan.Enabled = False

        mnuParameters.Enabled = False
        tlbbtnParameters.Enabled = False

        mnuPositionToMaxima.Enabled = False
        tlbbtnPositionToMaxima.Enabled = False
        'Added By Pankaj 21 May 07
        mnuLampParameters.Enabled = False
        tlbbtnLampParameters.Enabled = False
        btnLampParameters.Enabled = False

        btnClearSpectrum.Enabled = False
        mnuClearSpectrum.Enabled = False
        tlbbtnClearSpectrum.Enabled = False

        tlbbtnPrintGraph.Enabled = False
        mnuPrintGraph.Enabled = False
    End Sub

    Private Sub EnableButtonsForBurnerHeight()
        '=====================================================================
        ' Procedure Name        :   EnableButtonsForBurnerHeight
        ' Description           :   
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
        btnClearSpectrum.Enabled = True
        mnuClearSpectrum.Enabled = True
        tlbbtnClearSpectrum.Enabled = True

        btnReturn.Enabled = True
        mnuExit.Enabled = True
        tlbbtnReturn.Enabled = True

        btnStart.Enabled = True
        mnuStart.Enabled = True
        tlbbtnStart.Enabled = True

        nudD2Cur.Enabled = True
        nudPMT.Enabled = True
        nudSlit.Enabled = True
        cmbSpeed.Enabled = True
        cmbModes.Enabled = True
        nudBurnerHeight.Enabled = True
        nudFuelRatio.Enabled = True
        nudHCLCur.Enabled = True
        nudPMT_Ref.Enabled = True 'For Double Beam
        'nudSlit_Ref.Enabled = True 'For Double Beam'by Pankaj on 18.1.08


        mnuLampParameters.Enabled = True
        btnLampParameters.Enabled = True
        tlbbtnLampParameters.Enabled = True

        cmdChangeScale.Enabled = True
        tlbbtnChangeScale.Enabled = True
        mnuChangeScale.Enabled = True

        tlbbtnPrintGraph.Enabled = True
        mnuPrintGraph.Enabled = True

        tlbbtnLoadspectrumFile.Enabled = True
        mnuLoadSpectrunFile.Enabled = True

        tlbbtnContiniousTimeScan.Enabled = True
        mnuContiniousTimeScan.Enabled = True
    End Sub

    Private Sub frmEnergySpectrumDBMode_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        '=====================================================================
        ' Procedure Name        :   frmEnergySpectrumDBMode_Activated
        ' Description           :   
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
            If blnActivateStartEnergySpectrum = False Then
                Call funcSetDefaultParameter()
                nudD2Cur.Visible = True
                nudPMT.Visible = True
                nudPMT_Ref.Visible = True
                nudSlit.Visible = True
                nudSlit_Ref.Visible = True
                nudHCLCur.Visible = True
                nudBurnerHeight.Visible = True
                nudFuelRatio.Visible = True
                blnActivateStartEnergySpectrum = True
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
            TimerEnergyDisplay.Enabled = False
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
            TimerEnergyDisplay.Enabled = True
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

    Private Sub TimerEnergyDisplay_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerEnergyDisplay.Tick

        Dim intMV As Integer
        Try
            Application.DoEvents()
            If gobjCommProtocol.mobjCommdll.IsInCommu = True Then     '10.12.07
                'Return False
                Exit Sub
            End If
            Select Case gintInstrumentBeamType
                Case AAS203Library.Instrument.enumInstrumentBeamType.SingleBeam
                    gobjCommProtocol.funcReadADCFilter(10, intMV)
                Case AAS203Library.Instrument.enumInstrumentBeamType.DoubleBeam
                    If blnIsRefBeamSelected = True Then
                        gobjCommProtocol.funcReadADCFilter_ReferenceBeam(10, intMV)
                    Else
                        gobjCommProtocol.funcReadADCFilter(10, intMV)
                    End If
            End Select
            lblYValue.Text = mYValueLable & FormatNumber(gFuncGetADConvertedToCurMode(intMV), 2)
            lblYValue.Refresh()
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

#Region " Code for Enable and Disable"

    Private Function func_Enable_Disable(ByVal intProcess As Integer, ByVal intStart_End As Integer)
        '=====================================================================
        ' Procedure Name        :   func_Enable_Disable
        ' Description           :   
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

            Select Case intProcess
                Case EnumProcesses.FormInitialize, EnumProcesses.EditSystemParamters
                    Select Case intStart_End
                        Case EnumStart_End.Start_of_Process

                            subAll_Menus_Enable()

                            btnStart.Enabled = True
                            mnuStart.Enabled = True
                            tlbbtnStart.Enabled = True

                            btnClearSpectrum.Enabled = True
                            mnuClearSpectrum.Enabled = True
                            tlbbtnClearSpectrum.Enabled = True

                            btnReturn.Enabled = True
                            mnuExit.Enabled = True
                            tlbbtnReturn.Enabled = True

                            nudD2Cur.Enabled = True
                            nudPMT.Enabled = True
                            If Not (gintInstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.SingleBeam) Then
                                nudPMT_Ref.Enabled = True
                            Else
                                nudPMT_Ref.Enabled = False
                            End If

                            nudSlit.Enabled = True
                            'nudSlit_Ref.Enabled = True'by Pankaj on 18.1.08
                            cmbSpeed.Enabled = True
                            cmbModes.Enabled = True
                            nudBurnerHeight.Enabled = True
                            nudFuelRatio.Enabled = True
                            nudHCLCur.Enabled = True

                            mnuLampParameters.Enabled = True
                            btnLampParameters.Enabled = True
                            tlbbtnLampParameters.Enabled = True

                            If mintChannelIndex > -1 Then
                                mnuParameters.Enabled = True
                                tlbbtnParameters.Enabled = True

                                mnuSaveSpectrumFile.Enabled = True
                                tlbbtnSaveSpectrumFile.Enabled = True

                                mnuPeakPick.Enabled = True
                                tlbbtnPeakPick.Enabled = True

                                mnuPositionToMaxima.Enabled = True
                                tlbbtnPositionToMaxima.Enabled = True

                                mnuSmooth.Enabled = True
                                tlbbtnSmooth.Enabled = True
                            Else
                                mnuParameters.Enabled = False
                                tlbbtnParameters.Enabled = False

                                mnuSaveSpectrumFile.Enabled = False
                                tlbbtnSaveSpectrumFile.Enabled = False

                                mnuPeakPick.Enabled = False
                                tlbbtnPeakPick.Enabled = False

                                mnuPositionToMaxima.Enabled = False
                                tlbbtnPositionToMaxima.Enabled = False

                                mnuSmooth.Enabled = False
                                tlbbtnSmooth.Enabled = False
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
                            If mintChannelIndex > -1 Then
                                mnuParameters.Enabled = True
                                tlbbtnParameters.Enabled = True

                                mnuSaveSpectrumFile.Enabled = True
                                tlbbtnSaveSpectrumFile.Enabled = True

                                mnuPeakPick.Enabled = True
                                tlbbtnPeakPick.Enabled = True

                                mnuPositionToMaxima.Enabled = True
                                tlbbtnPositionToMaxima.Enabled = True

                                tlbbtnPrintGraph.Enabled = True 'Added by Pankaj on 6 Sep 07
                                mnuPrintGraph.Enabled = True 'Added by Pankaj on 6 Sep 07

                                mnuSmooth.Enabled = True
                                tlbbtnSmooth.Enabled = True
                            Else
                                mnuParameters.Enabled = False
                                tlbbtnParameters.Enabled = False

                                mnuSaveSpectrumFile.Enabled = False
                                tlbbtnSaveSpectrumFile.Enabled = False

                                mnuPeakPick.Enabled = False
                                tlbbtnPeakPick.Enabled = False

                                mnuPositionToMaxima.Enabled = False
                                tlbbtnPositionToMaxima.Enabled = False

                                mnuSmooth.Enabled = False
                                tlbbtnSmooth.Enabled = False
                            End If

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

                            'btnStart.Enabled = False
                            btnStart.Text = "&Stop"
                            btnStart.Image = Image.FromFile(Application.StartupPath & "\Images\cancel_1.ico")
                            btnStart.Refresh()
                            'Added By Pankaj 22 May07
                            mnuStart.Enabled = True
                            tlbbtnStart.Enabled = True
                            btnStart.Enabled = True

                            mnuStart.Text = "&Stop"
                            mnuStart.Image = Image.FromFile(Application.StartupPath & "\Images\cancel_1.ico")

                            tlbbtnStart.Text = "&Stop"
                            tlbbtnStart.Image = Image.FromFile(Application.StartupPath & "\Images\cancel_1.ico")

                            'nudD2Cur.Enabled = False
                            'nudPMT.Enabled = False

                            'nudPMT_Ref.Enabled = False

                            'nudSlit.Enabled = False
                            'nudSlit_Ref.Enabled = False
                            cmbSpeed.Enabled = False
                            cmbModes.Enabled = False
                            nudBurnerHeight.Enabled = False
                            nudFuelRatio.Enabled = False
                            'nudHCLCur.Enabled = False

                            btnLampParameters.Enabled = False
                            tlbbtnLampParameters.Enabled = False
                            mnuLampParameters.Enabled = False

                            cmdChangeScale.Enabled = False
                            tlbbtnChangeScale.Enabled = False
                            mnuChangeScale.Enabled = False

                            mnuSaveSpectrumFile.Enabled = False
                            tlbbtnSaveSpectrumFile.Enabled = False

                            mnuPeakPick.Enabled = False
                            tlbbtnPeakPick.Enabled = False

                            mnuPositionToMaxima.Enabled = False
                            tlbbtnPositionToMaxima.Enabled = False

                            mnuSmooth.Enabled = False
                            tlbbtnSmooth.Enabled = False

                            mnuLoadSpectrunFile.Enabled = False
                            tlbbtnLoadspectrumFile.Enabled = False

                            mnuContiniousTimeScan.Enabled = False
                            tlbbtnContiniousTimeScan.Enabled = False

                            mnuParameters.Enabled = False
                            tlbbtnParameters.Enabled = False

                            mnuPositionToMaxima.Enabled = False
                            tlbbtnPositionToMaxima.Enabled = False
                            'Added By Pankaj on 22 May 07
                            'mnuStart.Enabled = False
                            mnuLampParameters.Enabled = False
                            tlbbtnLampParameters.Enabled = False
                            btnLampParameters.Enabled = False

                            btnClearSpectrum.Enabled = False
                            mnuClearSpectrum.Enabled = False
                            tlbbtnClearSpectrum.Enabled = False

                            tlbbtnPrintGraph.Enabled = False
                            mnuPrintGraph.Enabled = False

                            '-----
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
                                mnuClearSpectrum.Enabled = True
                                tlbbtnClearSpectrum.Enabled = True

                                btnReturn.Enabled = True
                                mnuExit.Enabled = True
                                tlbbtnReturn.Enabled = True

                                btnStart.Text = "&Start"
                                btnStart.Image = Image.FromFile(Application.StartupPath & "\Images\Start.ico")

                                btnStart.Refresh()
                                nudD2Cur.Enabled = True
                                nudPMT.Enabled = True
                                If Not (gintInstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.SingleBeam) Then
                                    nudPMT_Ref.Enabled = True
                                Else
                                    nudPMT_Ref.Enabled = False
                                End If

                                btnStart.Enabled = True
                                mnuStart.Enabled = True
                                tlbbtnStart.Enabled = True

                                nudSlit.Enabled = True
                                'nudSlit_Ref.Enabled = True'by Pankaj on 18.1.08
                                cmbSpeed.Enabled = True
                                cmbModes.Enabled = True
                                nudBurnerHeight.Enabled = True
                                nudFuelRatio.Enabled = True
                                nudHCLCur.Enabled = True

                                mnuLampParameters.Enabled = True
                                btnLampParameters.Enabled = True
                                tlbbtnLampParameters.Enabled = True

                                cmdChangeScale.Enabled = True
                                tlbbtnChangeScale.Enabled = True
                                mnuChangeScale.Enabled = True
                            End If
                            'btnReturn.Enabled = True
                            mnuSaveSpectrumFile.Enabled = True
                            tlbbtnSaveSpectrumFile.Enabled = True

                            mnuPeakPick.Enabled = True
                            tlbbtnPeakPick.Enabled = True

                            mnuPositionToMaxima.Enabled = True
                            tlbbtnPositionToMaxima.Enabled = True

                            mnuSmooth.Enabled = True
                            tlbbtnSmooth.Enabled = True

                            mnuLoadSpectrunFile.Enabled = True
                            tlbbtnLoadspectrumFile.Enabled = True

                            mnuContiniousTimeScan.Enabled = True
                            tlbbtnContiniousTimeScan.Enabled = True

                            mnuParameters.Enabled = True
                            tlbbtnParameters.Enabled = True
                            'Added By Pankaj on 22 May 07
                            mnuStart.Enabled = True
                            tlbbtnStart.Enabled = True
                            btnStart.Enabled = True

                            mnuStart.Text = "&Start"
                            mnuStart.Image = Image.FromFile(Application.StartupPath & "\Images\Start.ico")
                            tlbbtnStart.Text = "&Start"
                            tlbbtnStart.Image = Image.FromFile(Application.StartupPath & "\Images\Start.ico")

                            mnuLampParameters.Enabled = True
                            tlbbtnLampParameters.Enabled = True
                            btnLampParameters.Enabled = True

                            mnuChangeScale.Enabled = True
                            tlbbtnChangeScale.Enabled = True
                            cmdChangeScale.Enabled = True

                            mnuClearSpectrum.Enabled = True
                            btnClearSpectrum.Enabled = True
                            tlbbtnClearSpectrum.Enabled = True
                            mnuPrintGraph.Enabled = True    'Added by pankaj on 6 sep 07
                            tlbbtnPrintGraph.Enabled = True  'Added by pankaj on 6 sep 07
                            '-----
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

                                mnuPositionToMaxima.Enabled = True
                                tlbbtnPositionToMaxima.Enabled = True

                                mnuSmooth.Enabled = True
                                tlbbtnSmooth.Enabled = True

                                btnReturn.Enabled = True
                                mnuExit.Enabled = True
                                tlbbtnReturn.Enabled = True
                            Else
                                mnuParameters.Enabled = False
                                tlbbtnParameters.Enabled = False

                                mnuSaveSpectrumFile.Enabled = False
                                tlbbtnSaveSpectrumFile.Enabled = False

                                mnuPeakPick.Enabled = False
                                tlbbtnPeakPick.Enabled = False

                                mnuPositionToMaxima.Enabled = False
                                tlbbtnPositionToMaxima.Enabled = False

                                mnuSmooth.Enabled = False
                                tlbbtnSmooth.Enabled = False

                                btnReturn.Enabled = False
                                mnuExit.Enabled = False
                                tlbbtnReturn.Enabled = False
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

            nudFuelRatio.Enabled = blnEnabled

            nudBurnerHeight.Enabled = blnEnabled

            nudD2Cur.Enabled = blnEnabled
            
            nudHCLCur.Enabled = blnEnabled
            
            nudSlit.Enabled = blnEnabled
            
            'nudSlit_Ref.Enabled = blnEnabled'by Pankaj on 18.1.08
            
            nudPMT.Enabled = blnEnabled
            If Not (gintInstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.SingleBeam) Then
                nudPMT_Ref.Enabled = blnEnabled
            End If
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
        ' Description           :   
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
        ' Description           :   
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
            ProgressPanel.Text = gstrTitleInstrumentType & Space(1) & "S/W Ver. : " & Mid(Application.ProductVersion, 1, 4)     'added by Saurabh 29.07.07

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
        ' Procedure Name        :   TaskStarted
        ' Description           :    
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
        ' Procedure Name        :   TaskStatus
        ' Description           :    
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
            'If gstructApplicationSessionState.intInstrument_Group = EnumInstrumentGroup.Initialize_2600_2700 Then
            Call funcIclientTaskDisplayData(Text)
            If Not (mobjclsBgSpectrum Is Nothing) Then
                mobjclsBgSpectrum.EndProcess = True
                Application.DoEvents()
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
        ' Procedure Name        :   TaskFailed
        ' Description           :    
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
            '--- Dispose all the objects
            'mobjTemporaryChannel = New Channel
            'mobjTemporaryReadings = New Readings
            'mobjTemporaryReadings_2100 = New Readings
            mAvoidProcessBtn = True
            funcIclientTaskFalied()

            mblnSpectrumStarted = False
            mblnAvoidProcessing = False
            statStartGraph = False
            mAvoidProcessBtn = False
            TimerEnergyDisplay.Enabled = True
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
        ' Procedure Name        :   TaskCompleted
        ' Description           :    
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
            'If gstructApplicationSessionState.intInstrument_Group = EnumInstrumentGroup.Initialize_2600_2700 Then
            '    'Call funcIclientTaskCompleted2600()
            'ElseIf gstructApplicationSessionState.intInstrument_Group = EnumInstrumentGroup.Initialize_2100_2200_2300 Then
            '    'Call funcIclientTaskCompleted2100()
            'End If
            Call funcIclientTaskCompleted()

            mblnSpectrumStarted = False
            mblnAvoidProcessing = False

            mblnAvoidProcessing = False
            statStartGraph = False
            TimerEnergyDisplay.Enabled = True
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
        ' Procedure Name        :   funcIclientTaskDisplayData
        ' Description           :    
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

            'Data in the Text arg would be "Wavelength|Abs"

            Dim objData As New Spectrum.Data
            Dim arrData() As String
            Dim O As Integer   ' same as in function funcSmoothgraphonline
            Dim intCount As Integer

            '--- Split the data for Wv and Abs
            arrData = Split(strData, "|")


            Dim dsf As String

            If arrData(0).Length > 0 And arrData(1).Length > 0 Then
                If IsNumeric(arrData(0)) = False Then
                    If arrData(0) = "Reference" Then
                        mSelectedBeamType = modGlobalDeclarations.enumSelectBeamType.Reference
                        mstrSelectedBeamType = "Reference"
                    ElseIf arrData(0) = "Sample" Then
                        mSelectedBeamType = modGlobalDeclarations.enumSelectBeamType.Sample
                        mstrSelectedBeamType = "Sample"
                    End If
                    funcFirstChannelTaskCompleted()
                Else
                    objData.XaxisData = Format(Val(arrData(0)), "#000.0000")   ' wv
                    objData.YaxisData = Format(Val(arrData(1)), "#0.0000")
                    
                    If Not (arrData(2) Is Nothing) Then
                        If arrData(2).Length > 0 Then
                            objData.YaxisADCData = Val(arrData(2))
                        Else
                            objData.YaxisADCData = 0.0  'Format(Val(arrData(1)), "#0.000")
                        End If
                    End If
                    mobjOnlineReadings.Add(objData)
                    funcDisplayGraph_RealTime(objData.XaxisData, objData.YaxisData)
                End If
            End If
            Application.DoEvents()
        Catch ex As Exception
            'gFuncShowMessage("Error...", "Error in displaying the spectrum on the screen.", modConstants.EnumMessageType.Information)
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
        ' Author                :   Sachin Dokhale
        ' Created               :   17.12.06
        ' Revisions             :
        '=====================================================================

        Try
            funcIclientTaskCompleted = False

            ' If scan is terminated by user in between then gblnSpectrumTerminated = True
            If Not ArrlstGraphCurveItem Is Nothing Then
                If statStartGraph = True Then
                    If ArrlstGraphCurveItem.Count >= intCurveIndex + 1 Then
                        AASEnergySpectrum.StopOnlineGraph(ArrlstGraphCurveItem(intCurveIndex))
                    End If
                End If
            End If
            Application.DoEvents()

            AASEnergySpectrum.AldysPane.AxisChange()
            AASEnergySpectrum.Refresh()



            If gblnSpectrumTerminated = True Then
                funcScanCompleted(False)
            Else 'scan is completed 
                If Not funcSpectrumReadingCompleted() Then

                End If
                funcScanCompleted(True)
            End If
            Call func_Enable_DisableControl(True)
            mblnAvoidProcessing = False
            'AddHandler mnuIgnite.Click, AddressOf btnAutoIgnition_Click

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

    Private Function funcFirstChannelTaskCompleted() As Boolean
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
            funcFirstChannelTaskCompleted = False
            ' If scan is terminated by user in between then gblnSpectrumTerminated = True
            If Not ArrlstGraphCurveItem Is Nothing Then
                If statStartGraph = True Then
                    If ArrlstGraphCurveItem.Count >= intCurveIndex + 1 Then
                        AASEnergySpectrum.StopOnlineGraph(ArrlstGraphCurveItem(intCurveIndex))
                    End If
                End If
            End If

            AASEnergySpectrum.AldysPane.AxisChange()
            AASEnergySpectrum.Refresh()

            If Not funcSpectrumReadingCompleted() Then

            End If

            'If gblnSpectrumTerminated = True Then
            '    funcScanCompleted(False)
            'Else 'scan is completed 
            '    funcScanCompleted(True)
            'End If

            mobjOnlineChannel = New Spectrum.Channel(True)
            'mobjEnegyChannel = New Spectrum.EnergyChannels
            'ObjParameter = funcCloneParameter(mobjParameters)
            'mobjOnlineChannel.EnegryParameter = ObjParameter
            'ObjParameter = Nothing
            statStartGraph = False
            mobjOnlineReadings = New Spectrum.Readings

            funcFirstChannelTaskCompleted = True

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
                        AASEnergySpectrum.StopOnlineGraph(ArrlstGraphCurveItem(intCurveIndex))
                        'intCurveIndex += 1
                        'intCurveIndex -= 1
                        AASEnergySpectrum.AldysPane.CurveList.Remove(AASEnergySpectrum.AldysPane.CurveList.Count - 1)
                        ArrlstGraphCurveItem.RemoveAt(ArrlstGraphCurveItem.Count - 1)
                    End If
                End If
            End If
            mobjOnlineChannel = New Channel(True)
            mobjOnlineReadings = New Readings
            mobjEnegyChannel = New Spectrum.EnergyChannels
            mblnSpectrumStarted = False
            Application.DoEvents()
            AASEnergySpectrum.AldysPane.AxisChange()
            AASEnergySpectrum.Refresh()

            funcScanCompleted(False)
            blnYetFileNotSave = False
            gobjMessageAdapter.ShowMessage(constSpectrumScanningFailed)
            Call func_Enable_DisableControl(True)
            Application.DoEvents()
            mblnAvoidProcessing = False
            'AddHandler mnuIgnite.Click, AddressOf btnAutoIgnition_Click
            'gFuncShowMessage("Error...", "Spectrum scanning failed.", EnumMessageType.Information)
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
            btnStart.Text = "&Start"
            btnStart.Image = Image.FromFile(Application.StartupPath & "\Images\Start.ico")
            btnStart.Enabled = True
            btnStart.Refresh()

            'funcTimerStartStop(mTimer, EnumTimerStartStop.Timer_Start)
            func_Enable_Disable(EnumProcesses.StartScan, EnumStart_End.End_of_Process)
            'Me.Cursor = Cursors.Default
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
                gobjMessageAdapter.ShowMessage(constErrorAddingSpectrumData)
                'gFuncShowMessage("Error...", "Error in adding the spectrum data to the current channel.", EnumMessageType.Information)
            End If

            '--- Add the channel to the channels collection
            objSpectrumData.Readings = objReadings
            mobjOnlineChannel.Spectrums.Add(objSpectrumData)
            If mSelectedBeamType = modGlobalDeclarations.enumSelectBeamType.Reference Then
                mobjOnlineChannel.InstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.ReferenceBeam
            ElseIf mSelectedBeamType = modGlobalDeclarations.enumSelectBeamType.Sample Then
                mobjOnlineChannel.InstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.SingleBeam
            Else
                mobjOnlineChannel.InstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.DoubleBeam
            End If

            mobjEnegyChannel.Add(mobjOnlineChannel)

            '--- Add the new channel to the channels collection and 
            '--- accordingly save the channel file to the disk
            intChannel_no = funcAddChannelToCollection(mobjOnlineChannel)
            blnYetFileNotSave = True
            mintChannelIndex = intChannel_no
            mobjChannnels(mintChannelIndex).EnegryParameter = mobjParameters

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

#End Region

#Region " Graph Method"

    Private Function funcGraphPreRequisite(ByVal intScanmode As Integer, ByVal intXmin As Double, ByVal intXmax As Double, ByVal intYmin As Double, ByVal intYmax As Double) As Boolean
        '=====================================================================
        ' Procedure Name        :   funcGraphPreRequisite
        ' Description           :   
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

            'Assigning Values to Xmin,xmax,ymin,ymax properties
            'AASEnergySpectrum.AldysPane.XAxis.Min = intXmin
            'AASEnergySpectrum.AldysPane.XAxis.Max = intXmax
            AASEnergySpectrum.btnPeakEdit.Enabled = True
            AASEnergySpectrum.btnShowXYValues.Enabled = True

            AASEnergySpectrum.XAxisMin = intXmin
            AASEnergySpectrum.XAxisMax = intXmax
            AASEnergySpectrum.AldysPane.XAxis.Min = intXmin
            AASEnergySpectrum.AldysPane.XAxis.Max = intXmax
            AASEnergySpectrum.XAxisMinorStep = dblMinorStepX
            AASEnergySpectrum.XAxisStep = dblMajorStepX
            'AASEnergySpectrum.AldysPane.XAxis.MaxAuto = True
            'AASEnergySpectrum.AldysPane.XAxis.MinAuto = True
            'AASEnergySpectrum.AldysPane.XAxis.MinorStepAuto = True


            '--- Display the axis lables
            AASEnergySpectrum.XAxisLabel = "WAVELENGTH (nm)"
            'AxEnergySpectrum.XAxisLabel = "  Energy"

            Select Case gobjInst.Mode
                Case EnumCalibrationMode.AA, EnumCalibrationMode.AABGC, EnumCalibrationMode.MABS
                    AASEnergySpectrum.YAxisMin = intYmin
                    AASEnergySpectrum.YAxisMax = intYmax
                    AASEnergySpectrum.YAxisMinorStep = 1
                    'AASEnergySpectrum.YAxisStep = 0.1
                    'AASEnergySpectrum.YAxisLabel = "Abs"
                    AASEnergySpectrum.YAxisLabel = "ABSORBANCE"
                Case EnumCalibrationMode.HCLE, EnumCalibrationMode.D2E
                    AASEnergySpectrum.YAxisMin = intYmin
                    AASEnergySpectrum.YAxisMax = intYmax
                    AASEnergySpectrum.YAxisLabel = "ENERGY"
                    'AASEnergySpectrum.YAxisMinorStep = 5
                    'AASEnergySpectrum.YAxisStep = 10
                Case EnumCalibrationMode.EMISSION
                    AASEnergySpectrum.YAxisMin = intYmin
                    AASEnergySpectrum.YAxisMax = intYmax
                    'AASEnergySpectrum.YAxisMinorStep = 1
                    'AASEnergySpectrum.YAxisStep = 10

                    AASEnergySpectrum.YAxisLabel = "EMISSION"
                Case EnumCalibrationMode.SELFTEST
                    AASEnergySpectrum.YAxisMin = intYmin
                    AASEnergySpectrum.YAxisMax = intYmax
                    'AASEnergySpectrum.AldysPane.YAxis.Min = intYmin
                    'AASEnergySpectrum.AldysPane.YAxis.Max = intYmax
                    'AASEnergySpectrum.YAxisMinorStep = 100
                    'AASEnergySpectrum.YAxisStep = 500
                    AASEnergySpectrum.YAxisLabel = "VOLT(mV)"
            End Select
            ' AASEnergySpectrum.YAxisMinorStep = dblMinorStepY
            'AASEnergySpectrum.YAxisStep = dblMajorStepY

            'AASEnergySpectrum.XAxisStep = 2
            'AASEnergySpectrum.XAxisMinorStep = 5

            'AASEnergySpectrum.YAxisMinorStep = 5
            'AASEnergySpectrum.XAxisStep = 500

            'AASEnergySpectrum.XAxisStep = 2
            'AASEnergySpectrum.XAxisMinorStep = 1
            'AASEnergySpectrum.AldysPane.YAxis.MaxAuto = True
            'AASEnergySpectrum.AldysPane.YAxis.MinAuto = True
            'AASEnergySpectrum.AldysPane.YAxis.MinorStepAuto = True

            AASEnergySpectrum.AldysPane.XAxis.Step = dblMajorStepX
            AASEnergySpectrum.AldysPane.XAxis.MinorStep = dblMinorStepX
            AASEnergySpectrum.AldysPane.XAxis.PickScale(intXmin, intXmax)
            AASEnergySpectrum.AldysPane.XAxis.MinorStepAuto = True
            AASEnergySpectrum.AldysPane.XAxis.StepAuto = True
            AASEnergySpectrum.AldysPane.YAxis.Step = dblMajorStepY
            AASEnergySpectrum.AldysPane.YAxis.MinorStep = dblMinorStepY

            AASEnergySpectrum.AldysPane.YAxis.PickScale(intYmin, intYmax)
            AASEnergySpectrum.AldysPane.YAxis.MinorStepAuto = True
            AASEnergySpectrum.AldysPane.YAxis.StepAuto = True

            AASEnergySpectrum.XAxisStep = dblMajorStepX
            AASEnergySpectrum.XAxisMinorStep = dblMinorStepX
            AASEnergySpectrum.YAxisStep = dblMajorStepY
            AASEnergySpectrum.YAxisMinorStep = dblMinorStepY
            '------------Added by Pankaj on 8 May 07
            AASEnergySpectrum.XAxisMin = mobjParameters.XaxisMin
            AASEnergySpectrum.XAxisMax = mobjParameters.XaxisMax

            AASEnergySpectrum.YAxisMin = mobjParameters.YaxisMin
            AASEnergySpectrum.YAxisMax = mobjParameters.YaxisMax

            gobjClsAAS203.Calculate_Analysis_Graph_Param(AASEnergySpectrum, ClsAAS203.enumChangeAxis.xyAxis)
            '------------

            AASEnergySpectrum.AldysPane.AxisChange()
            'AASEnergySpectrum.AldysPane.Legend.IsVisible = True
            'mnuShowXYValues.Checked = True
            Me.AASEnergySpectrum.IsShowGrid = True
            mnuGrid.Checked = Me.AASEnergySpectrum.IsShowGrid
            Me.AASEnergySpectrum.btnPeakEdit.Checked = False
            mnuLegends.Checked = AASEnergySpectrum.AldysPane.Legend.IsVisible
            AASEnergySpectrum.Invalidate()
            AASEnergySpectrum.Refresh()
            Application.DoEvents()

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
        ' Author                :   Uday
        ' Created               :   sunday, November 15, 2003 18:49
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
            'If dblYAxis < addataSpect.dblYmin Then
            '    dblYAxis = addataSpect.dblYmin
            'End If

            'If dblYAxis > addataSpect.dblYMax Then
            '    dblYAxis = addataSpect.dblYMax
            'End If
            'If ((dblToX Mod CONST_STEPS_PER_NM) = 0) Then
            dblYAxis = gfuncGetValueInSpectrum(dblToY, gobjInst.Mode)

            'End If

            '{//STEPS_PER_NM==0){
            'Disp_wv_abs_in_mode(hwnd, wv, ynew);
            'GetADConvertedToString(ynew, addata.mode, str);
            'disp_wv_abs(hwnd, wv, str);*/

            dblYAxis = dblToY
            'dblYAxis = gfuncGetValueInSpectrum(dblToY, gobjInst.Mode)

            lblWvPos.Text = mXValueLable & FormatNumber(dblToX, 2)
            lblYValue.Text = mYValueLable & FormatNumber(dblYAxis, 2)
            '--- Check if the wavelength is equal to the max wv

            If dblXAxis = mobjParameters.XaxisMin Then
                'mGraphCurveItem = AASEnergySpectrum.StartOnlineGraph("Energy Spectrum", AASEnergySpectrum.GetColor(500), AldysGraph.SymbolType.NoSymbol)
                'mGraphCurveItem = AASEnergySpectrum.StartOnlineGraph("Energy Spectrum", Color.Red, AldysGraph.SymbolType.Circle)
                'AASEnergySpectrum.PlotPoint(mGraphCurveItem, dblXAxis, dblYAxis)
                'AASEnergySpectrum.AldysPane.AxisChange()
                mGraphCurveItem = Nothing
                intCurveIndex += 1

                'mGraphCurveItem = AASEnergySpectrum.StartOnlineGraph(mstrSelectedBeamType & " " & AASEnergySpectrum.YAxisLabel & " " & (intCurveIndex + 1).ToString, AASEnergySpectrum.GetColor(intCurveIndex), AldysGraph.SymbolType.NoSymbol)
                '---condition added by deepak on 21.07.07
                If IsRefBeamSelected = True Then
                    mGraphCurveItem = AASEnergySpectrum.StartOnlineGraph("Reference Beam Scan", AASEnergySpectrum.GetColor(intCurveIndex), AldysGraph.SymbolType.NoSymbol)
                Else
                    mGraphCurveItem = AASEnergySpectrum.StartOnlineGraph("Sample Beam Scan", AASEnergySpectrum.GetColor(intCurveIndex), AldysGraph.SymbolType.NoSymbol)
                End If


                ArrlstGraphCurveItem.Add(mGraphCurveItem)
                AASEnergySpectrum.PlotPoint(ArrlstGraphCurveItem.Item(intCurveIndex), dblXAxis, dblYAxis)
                statStartGraph = True
                'AASEnergySpectrum.OfflineCurve.Label = AASEnergySpectrum.YAxisLabel
                AASEnergySpectrum.Refresh()
                'Application.DoEvents()
            Else
                'AxEnergySpectrum.PlotPoint(mdblXaxis, mdblYaxis, dblToX, dblToY, gSetColor(mintColor))
                'AASEnergySpectrum.PlotPoint(mGraphCurveItem, dblXAxis, (dblYAxis / 10))
                'AASEnergySpectrum.PlotPoint(mGraphCurveItem, dblXAxis, dblYAxis)
                If statStartGraph = True Then
                    AASEnergySpectrum.PlotPoint(ArrlstGraphCurveItem.Item(intCurveIndex), dblXAxis, dblYAxis)
                    AASEnergySpectrum.AldysPane.AxisChange()
                End If
                AASEnergySpectrum.Refresh()
            End If

            'Application.DoEvents()

            '--- Check if the X-coordinates and Y-coordinates are less than
            '--- Xmin and Ymin

            'If dblToY < mobjTemporaryChannel.Parameter.YaxisMin Then
            '    dblToY = mobjTemporaryChannel.Parameter.YaxisMin
            'Else
            '    mdblYaxis = dblToY
            'End If

            mdblYaxis = dblToY
            mdblXaxis = dblToX
            Application.DoEvents()
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

    Friend Function funcDisplayGraph(ByVal objChannel As Spectrum.Channel, Optional ByRef objCurveItem As AldysGraph.CurveItem = Nothing) As Boolean
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

                    dblFromX = objChannel.EnegryParameter.XaxisMax
                    dblFromY = objChannel.EnegryParameter.YaxisMin

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
                        'dblToY = gfuncGetValueInSpectrum(dblToY, gobjInst.Mode)
                        '--- Check if the X-coordinates and Y-coordinates are less than
                        '--- Xmin and Ymin
                        'If dblToY < objChannel.EnegryParameter.YaxisMin Then
                        'dblToY = objChannel.EnegryParameter.YaxisMin()
                        'End If

                        'If dblToY > objChannel.EnegryParameter.YaxisMax Then
                        'dblToY = objChannel.EnegryParameter.YaxisMax
                        'End If
                        dtRow = dtPlotValue.NewRow

                        dtRow(0) = dblToX
                        dtRow(1) = dblToY
                        dtPlotValue.Rows.Add(dtRow)

                        '--- Check if the wavelength is equal to the min wv
                    Next
                    dtRow = dtPlotValue.NewRow
                    dtRow(0) = dblToX
                    dtRow(1) = dblToY
                    dtPlotValue.Rows.Add(dtRow)
                    AASEnergySpectrum.GraphDataSource = dtPlotValue
                    objCurveItem = AASEnergySpectrum.PlotGraph()
                    objCurveItem.Label = objChannel.EnegryParameter.SpectrumName()
                    AASEnergySpectrum.Refresh()
                    Application.DoEvents()
                End If
            End If
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

    Friend Function funcDisplayGraphOffline(ByVal objChannel As Spectrum.Channel, Optional ByRef objCurveItem As AldysGraph.CurveItem = Nothing) As Boolean
        '=====================================================================
        ' Procedure Name        :   funcDisplayGraphOffline
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
        Dim strSelectedBeam As String
        ' Dim intSpeed As Integer

        Try

            If Not objChannel Is Nothing Then
                If objChannel.Spectrums.Count > 0 Then

                    dblFromX = objChannel.EnegryParameter.XaxisMax
                    dblFromY = objChannel.EnegryParameter.YaxisMin

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

                    If objChannel.InstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.SingleBeam Then
                        strSelectedBeam = "Sample"
                    ElseIf objChannel.InstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.ReferenceBeam Then
                        strSelectedBeam = "Reference"
                    Else
                        strSelectedBeam = "Double"
                    End If

                    '//----- Start Online graph plotting
                    objCurveItem = AASEnergySpectrum.StartOnlineGraph(strSelectedBeam & " " & AASEnergySpectrum.YAxisLabel & " " & (intCurveIndex + 2).ToString, AASEnergySpectrum.GetColor(intCurveIndex), AldysGraph.SymbolType.NoSymbol)
                    'ArrlstGraphCurveItem.Add(mGraphCurveItem)

                    '//-----
                    'For lngDataCount = objChannel.UVParameter.XaxisMin To objChannel.UVParameter.XaxisMax Step 1     '+objChannel.Parameter.CalculatedSpeed
                    For lngDataCount = 0 To objChannel.Spectrums.item(0).Readings.Count - 1 Step 1      '+objChannel.Parameter.CalculatedSpeed
                        '--- Check for the graph plotted on the screen

                        dblToX = objChannel.Spectrums.item(0).Readings.item(lngDataCount).XaxisData
                        dblToY = objChannel.Spectrums.item(0).Readings.item(lngDataCount).YaxisData
                        'dblToY = gfuncGetValueInSpectrum(dblToY, gobjInst.Mode)
                        '--- Check if the X-coordinates and Y-coordinates are less than
                        '--- Xmin and Ymin
                        'If dblToY < objChannel.EnegryParameter.YaxisMin Then
                        'dblToY = objChannel.EnegryParameter.YaxisMin()
                        'End If

                        'If dblToY > objChannel.EnegryParameter.YaxisMax Then
                        'dblToY = objChannel.EnegryParameter.YaxisMax
                        'End If
                        'dtRow = dtPlotValue.NewRow

                        'dtRow(0) = dblToX
                        'dtRow(1) = dblToY
                        'dtPlotValue.Rows.Add(dtRow)
                        Call AASEnergySpectrum.PlotPoint(objCurveItem, dblToX, dblToY, True)
                        '--- Check if the wavelength is equal to the min wv
                    Next
                    'If ArrlstGraphCurveItem.Count >= intCurveIndex + 1 Then
                    AASEnergySpectrum.StopOnlineGraph(objCurveItem)
                    mGraphCurveItem = objCurveItem
                    AASEnergySpectrum.AldysPane.CurveList(0).Label = AASEnergySpectrum.YAxisLabel

                    'End If
                    'AASEnergySpectrum.GraphDataSource = dtPlotValue
                    'objCurveItem = AASEnergySpectrum.PlotGraph()
                    AASEnergySpectrum.Refresh()
                    Application.DoEvents()
                End If
            End If
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
        ' Description           :   
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
            CheckMaxPosition = False
            'mnuPositionToMaxima_Click(mnuPositionToMaxima, System.EventArgs.Empty)
            AASEnergySpectrum.RemoveHighPeakLineLabel()
            AASEnergySpectrum.AldysPane.CurveList.Clear()
            ArrlstGraphCurveItem.Clear()
            AASEnergySpectrum.Invalidate()
            AASEnergySpectrum.Refresh()
            intCurveIndex = -1

            Application.DoEvents()


            'Call AASEnergySpectrum.PlotGraph()
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
            mnuGrid.Checked = Not (mnuGrid.Checked)
            Me.AASEnergySpectrum.IsShowGrid = mnuGrid.Checked

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
            mnuPeakEdit.Checked = Not (mnuPeakEdit.Checked)
            'Me.AASGraphUVSpectrum.IsShowGrid = mnuPeakEdit.Checked
            Me.AASEnergySpectrum.submnuPeakEdit_Click(sender, e)


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
            mnuShowXYValues.Checked = Not (mnuShowXYValues.Checked)
            Me.AASEnergySpectrum.ShowXYValues = mnuShowXYValues.Checked
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
            mnuLegends.Checked = Not (mnuLegends.Checked)
            Me.AASEnergySpectrum.AldysPane.Legend.IsVisible = mnuLegends.Checked
            AASEnergySpectrum.Invalidate()
            AASEnergySpectrum.Refresh()
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

    Private Sub AASEnergySpectrum_GraphOptionChanged() Handles AASEnergySpectrum.GraphOptionChanged
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
            If AASEnergySpectrum.IsShowGrid = True Then
                mnuGrid.Checked = True
            Else
                mnuGrid.Checked = False
            End If
            AddHandler mnuGrid.Click, AddressOf mnuGrid_Click

            '//----- Check Legends on Graph
            RemoveHandler mnuLegends.Click, AddressOf mnuLegends_Click
            If AASEnergySpectrum.AldysPane.Legend.IsVisible = True Then
                mnuLegends.Checked = True
            Else
                mnuLegends.Checked = False
            End If
            AddHandler mnuLegends.Click, AddressOf mnuLegends_Click

            '//----- Check Show XY Values on Graph
            RemoveHandler mnuShowXYValues.Click, AddressOf mnuShowXYValues_Click
            If AASEnergySpectrum.ShowXYValues = True Then
                mnuShowXYValues.Checked = True
            Else
                mnuShowXYValues.Checked = False
            End If
            AddHandler mnuShowXYValues.Click, AddressOf mnuShowXYValues_Click

            RemoveHandler mnuPeakEdit.Click, AddressOf mnuPeakEdit_Click
            If AASEnergySpectrum.ShowXYPeak = True Then
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

    

End Class




