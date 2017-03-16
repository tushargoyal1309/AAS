Imports System.Threading
Imports AAS203.Common
Imports IQOQPQ.IQOQPQ.IQOQPQ
Imports BgThread
Imports System.IO
Imports Microsoft.VisualBasic
Imports AAS203Library.Instrument

Public Class frmMDIMain
    Inherits System.Windows.Forms.Form
    Implements BgThread.Iclient

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

        Try
            mobjfrmMethod.IsMdiContainer = False
            mobjfrmMethod.TopLevel = False
            mobjfrmMethod.ControlBox = False
            mobjfrmMethod.Dock = DockStyle.Fill
            mobjfrmMethod.Text = ""
            CustMain.Controls.Add(mobjfrmMethod)
            mobjfrmMethod.Show()
            mobjfrmMethod.BringToFront()

            mobjfrmAnalysis = New frmAnalysis
            mobjfrmAnalysis.IsMdiContainer = False
            mobjfrmAnalysis.TopLevel = False
            mobjfrmAnalysis.ControlBox = False
            mobjfrmAnalysis.Dock = DockStyle.Fill
            mobjfrmAnalysis.Text = ""
            CustMain.Controls.Add(mobjfrmAnalysis)

            mobjfrmDataFiles = New frmDataFiles
            mobjfrmDataFiles.IsMdiContainer = False
            mobjfrmDataFiles.TopLevel = False
            mobjfrmDataFiles.ControlBox = False
            mobjfrmDataFiles.Dock = DockStyle.Fill
            mobjfrmDataFiles.Text = ""
            CustMain.Controls.Add(mobjfrmDataFiles)


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
    Friend WithEvents MenuBar As NETXP.Controls.Bars.CommandBar
    Friend WithEvents mnuAnalysis As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuHistory As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuDataFiles As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuMethod As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuAnalyse As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuSpectrumModes As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuUVSpectrum As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuEnergySpectrum As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuUtilities As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuHydrideMode As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents CommandBarSeparatorItem1 As NETXP.Controls.Bars.CommandBarSeparatorItem
    Friend WithEvents mnuManualFlame As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuOpenReportFile As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuPrinterSetup As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuPrintertype As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuCookBook As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuFilterOn As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuAutoSampler As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuEnableAutoSAmpler As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuCheckSamplerFunctions As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuSetAbsorbanceThreshold As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents ToolBar As NETXP.Controls.Bars.CommandBar
    Friend WithEvents mnuHelpMain As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuHelp As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuAboutUs As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuFile As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuExit As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents CommandBarSeparatorItem2 As NETXP.Controls.Bars.CommandBarSeparatorItem
    Friend WithEvents CommandBarSeparatorItem3 As NETXP.Controls.Bars.CommandBarSeparatorItem
    Friend WithEvents CommandBarSeparatorItem4 As NETXP.Controls.Bars.CommandBarSeparatorItem
    Friend WithEvents tlbbtnMethod As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents tlbbtnAnalyse As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents tlbbtnDataFiles As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents tlbbtnCookBook As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents tlbbtnHelp As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents tlbbtnExit As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents CustomPanelTop As GradientPanel.CustomPanel
    Friend WithEvents StatusBar1 As NETXP.Controls.Bars.StatusBar
    Friend WithEvents StatusBarPanelInfo As System.Windows.Forms.StatusBarPanel
    Friend WithEvents StatusBarPanelDate As System.Windows.Forms.StatusBarPanel
    Friend WithEvents ProgressPanel As NETXP.Controls.Bars.ProgressPanel
    Friend WithEvents mnuService As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuServiceUtility As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuAdministration As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuAddUser As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuUserPermissions As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents CommandBarSeparatorItem5 As NETXP.Controls.Bars.CommandBarSeparatorItem
    Friend WithEvents mnuActivityLog As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuDeleteLog As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuChangePassword As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnu21CFR As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents CustMain As GradientPanel.CustomPanel
    Friend WithEvents mnuChangeBeamType As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuSingleBeam As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuDoubleBeam As NETXP.Controls.Bars.CommandBarButtonItem
    'Friend WithEvents CommandBarButtonItem1 As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents CommandBarSeparatorItem6 As NETXP.Controls.Bars.CommandBarSeparatorItem
    Friend WithEvents CommandBarSeparatorItem7 As NETXP.Controls.Bars.CommandBarSeparatorItem
    Friend WithEvents tlbbtnManualFlame As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents tlbbtnUVSpectrum As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents tlbbtnEnergySpectrum As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents CommandBarSeparatorItem8 As NETXP.Controls.Bars.CommandBarSeparatorItem
    Friend WithEvents IQOQPQ As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuIQOQPQ As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents tlbbtnService As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents tlbbtnIQOQPQ As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents CommandBarSeparatorItem9 As NETXP.Controls.Bars.CommandBarSeparatorItem
    Friend WithEvents CustomPanel1 As GradientPanel.CustomPanel
    Friend WithEvents btnExtinguish As NETXP.Controls.XPButton
    Friend WithEvents btnIgnite As NETXP.Controls.XPButton
    Friend WithEvents btnN2OIgnite As NETXP.Controls.XPButton
    Friend WithEvents btnDelete As NETXP.Controls.XPButton
    Friend WithEvents btnR As NETXP.Controls.XPButton
    Friend WithEvents mnuLampElements As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuHelpAbout As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuAbout As NETXP.Controls.Bars.CommandBarButtonItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMDIMain))
        Me.ToolBar = New NETXP.Controls.Bars.CommandBar
        Me.tlbbtnMethod = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.tlbbtnAnalyse = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.tlbbtnDataFiles = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.CommandBarSeparatorItem6 = New NETXP.Controls.Bars.CommandBarSeparatorItem
        Me.tlbbtnUVSpectrum = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.tlbbtnEnergySpectrum = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.CommandBarSeparatorItem8 = New NETXP.Controls.Bars.CommandBarSeparatorItem
        Me.tlbbtnManualFlame = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.tlbbtnCookBook = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.CommandBarSeparatorItem7 = New NETXP.Controls.Bars.CommandBarSeparatorItem
        Me.tlbbtnService = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.tlbbtnIQOQPQ = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.CommandBarSeparatorItem9 = New NETXP.Controls.Bars.CommandBarSeparatorItem
        Me.tlbbtnHelp = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.CommandBarSeparatorItem4 = New NETXP.Controls.Bars.CommandBarSeparatorItem
        Me.tlbbtnExit = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.CustomPanelMain = New GradientPanel.CustomPanel
        Me.CustMain = New GradientPanel.CustomPanel
        Me.CustomPanel1 = New GradientPanel.CustomPanel
        Me.btnExtinguish = New NETXP.Controls.XPButton
        Me.btnIgnite = New NETXP.Controls.XPButton
        Me.btnN2OIgnite = New NETXP.Controls.XPButton
        Me.btnDelete = New NETXP.Controls.XPButton
        Me.btnR = New NETXP.Controls.XPButton
        Me.CustomPanelTop = New GradientPanel.CustomPanel
        Me.MenuBar = New NETXP.Controls.Bars.CommandBar
        Me.mnuFile = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuMethod = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.CommandBarSeparatorItem2 = New NETXP.Controls.Bars.CommandBarSeparatorItem
        Me.mnuExit = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuAnalysis = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuAnalyse = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuHistory = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuDataFiles = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuSpectrumModes = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuUVSpectrum = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuEnergySpectrum = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuUtilities = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuHydrideMode = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.CommandBarSeparatorItem1 = New NETXP.Controls.Bars.CommandBarSeparatorItem
        Me.mnuManualFlame = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuOpenReportFile = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuPrinterSetup = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuPrintertype = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuCookBook = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuFilterOn = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuAutoSampler = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuEnableAutoSAmpler = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuCheckSamplerFunctions = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuSetAbsorbanceThreshold = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuLampElements = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuService = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuServiceUtility = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.IQOQPQ = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuIQOQPQ = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuAdministration = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuAddUser = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuUserPermissions = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.CommandBarSeparatorItem5 = New NETXP.Controls.Bars.CommandBarSeparatorItem
        Me.mnuActivityLog = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuDeleteLog = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuChangePassword = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnu21CFR = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuHelpMain = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuHelp = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.CommandBarSeparatorItem3 = New NETXP.Controls.Bars.CommandBarSeparatorItem
        Me.mnuAboutUs = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuChangeBeamType = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuSingleBeam = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuDoubleBeam = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuHelpAbout = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuAbout = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.StatusBar1 = New NETXP.Controls.Bars.StatusBar
        Me.StatusBarPanelInfo = New System.Windows.Forms.StatusBarPanel
        Me.ProgressPanel = New NETXP.Controls.Bars.ProgressPanel
        Me.StatusBarPanelDate = New System.Windows.Forms.StatusBarPanel
        CType(Me.ToolBar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CustomPanelMain.SuspendLayout()
        Me.CustMain.SuspendLayout()
        Me.CustomPanelTop.SuspendLayout()
        CType(Me.MenuBar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StatusBarPanelInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProgressPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StatusBarPanelDate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolBar
        '
        Me.ToolBar.BackColor = System.Drawing.Color.Transparent
        Me.ToolBar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ToolBar.CustomizeText = "&Customize Toolbar..."
        Me.ToolBar.Dock = System.Windows.Forms.DockStyle.Top
        Me.ToolBar.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolBar.FullRow = True
        Me.ToolBar.ID = 1671
        Me.ToolBar.Items.AddRange(New NETXP.Controls.Bars.CommandBarItem() {Me.tlbbtnMethod, Me.tlbbtnAnalyse, Me.tlbbtnDataFiles, Me.CommandBarSeparatorItem6, Me.tlbbtnUVSpectrum, Me.tlbbtnEnergySpectrum, Me.CommandBarSeparatorItem8, Me.tlbbtnManualFlame, Me.tlbbtnCookBook, Me.CommandBarSeparatorItem7, Me.tlbbtnService, Me.tlbbtnIQOQPQ, Me.CommandBarSeparatorItem9, Me.tlbbtnHelp, Me.CommandBarSeparatorItem4, Me.tlbbtnExit})
        Me.ToolBar.Location = New System.Drawing.Point(0, 23)
        Me.ToolBar.Margins.Bottom = 1
        Me.ToolBar.Margins.Left = 1
        Me.ToolBar.Margins.Right = 1
        Me.ToolBar.Margins.Top = 1
        Me.ToolBar.MdiContainer = Me
        Me.ToolBar.Name = "ToolBar"
        Me.ToolBar.Size = New System.Drawing.Size(712, 34)
        Me.ToolBar.TabIndex = 2
        Me.ToolBar.TabStop = False
        Me.ToolBar.Text = ""
        '
        'tlbbtnMethod
        '
        Me.tlbbtnMethod.Image = CType(resources.GetObject("tlbbtnMethod.Image"), System.Drawing.Image)
        Me.tlbbtnMethod.Text = "METHOD [Ctrl+M]"
        '
        'tlbbtnAnalyse
        '
        Me.tlbbtnAnalyse.Image = CType(resources.GetObject("tlbbtnAnalyse.Image"), System.Drawing.Image)
        Me.tlbbtnAnalyse.Text = "ANALYSE [Ctrl+A]"
        '
        'tlbbtnDataFiles
        '
        Me.tlbbtnDataFiles.Image = CType(resources.GetObject("tlbbtnDataFiles.Image"), System.Drawing.Image)
        Me.tlbbtnDataFiles.Text = "DATA FILES [Ctrl+D]"
        '
        'tlbbtnUVSpectrum
        '
        Me.tlbbtnUVSpectrum.Image = CType(resources.GetObject("tlbbtnUVSpectrum.Image"), System.Drawing.Image)
        Me.tlbbtnUVSpectrum.Text = "UV SPECTRUM[Ctrl+U]"
        '
        'tlbbtnEnergySpectrum
        '
        Me.tlbbtnEnergySpectrum.Image = CType(resources.GetObject("tlbbtnEnergySpectrum.Image"), System.Drawing.Image)
        Me.tlbbtnEnergySpectrum.Text = "ENERGY SPECTRUM[Ctrl+E]"
        '
        'tlbbtnManualFlame
        '
        Me.tlbbtnManualFlame.Image = CType(resources.GetObject("tlbbtnManualFlame.Image"), System.Drawing.Image)
        Me.tlbbtnManualFlame.Text = "MANUAL FLAME[Ctrl+F]"
        '
        'tlbbtnCookBook
        '
        Me.tlbbtnCookBook.Image = CType(resources.GetObject("tlbbtnCookBook.Image"), System.Drawing.Image)
        Me.tlbbtnCookBook.Text = "COOK BOOK [Ctrl+C]"
        '
        'tlbbtnService
        '
        Me.tlbbtnService.Image = CType(resources.GetObject("tlbbtnService.Image"), System.Drawing.Image)
        Me.tlbbtnService.Text = "SERVICE UTILITY[Ctrl+Y]"
        Me.tlbbtnService.Visible = False
        '
        'tlbbtnIQOQPQ
        '
        Me.tlbbtnIQOQPQ.Image = CType(resources.GetObject("tlbbtnIQOQPQ.Image"), System.Drawing.Image)
        Me.tlbbtnIQOQPQ.Text = "IQOQPQ[Ctrl+I]"
        '
        'tlbbtnHelp
        '
        Me.tlbbtnHelp.Image = CType(resources.GetObject("tlbbtnHelp.Image"), System.Drawing.Image)
        Me.tlbbtnHelp.Text = "HELP"
        Me.tlbbtnHelp.Visible = False
        '
        'CommandBarSeparatorItem4
        '
        Me.CommandBarSeparatorItem4.Visible = False
        '
        'tlbbtnExit
        '
        Me.tlbbtnExit.Image = CType(resources.GetObject("tlbbtnExit.Image"), System.Drawing.Image)
        Me.tlbbtnExit.Shortcut = System.Windows.Forms.Shortcut.CtrlX
        Me.tlbbtnExit.Text = "EXIT [Ctrl+X]"
        '
        'CustomPanelMain
        '
        Me.CustomPanelMain.BackColor = System.Drawing.Color.AliceBlue
        Me.CustomPanelMain.BackColor2 = System.Drawing.Color.AliceBlue
        Me.CustomPanelMain.Controls.Add(Me.CustMain)
        Me.CustomPanelMain.Controls.Add(Me.CustomPanelTop)
        Me.CustomPanelMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CustomPanelMain.Location = New System.Drawing.Point(0, 0)
        Me.CustomPanelMain.Name = "CustomPanelMain"
        Me.CustomPanelMain.Size = New System.Drawing.Size(712, 399)
        Me.CustomPanelMain.TabIndex = 3
        '
        'CustMain
        '
        Me.CustMain.BackColor = System.Drawing.Color.AliceBlue
        Me.CustMain.BackgroundImage = CType(resources.GetObject("CustMain.BackgroundImage"), System.Drawing.Image)
        Me.CustMain.Controls.Add(Me.CustomPanel1)
        Me.CustMain.Controls.Add(Me.btnExtinguish)
        Me.CustMain.Controls.Add(Me.btnIgnite)
        Me.CustMain.Controls.Add(Me.btnN2OIgnite)
        Me.CustMain.Controls.Add(Me.btnDelete)
        Me.CustMain.Controls.Add(Me.btnR)
        Me.CustMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CustMain.Location = New System.Drawing.Point(0, 56)
        Me.CustMain.Name = "CustMain"
        Me.CustMain.Size = New System.Drawing.Size(712, 343)
        Me.CustMain.TabIndex = 5
        '
        'CustomPanel1
        '
        Me.CustomPanel1.BackColor = System.Drawing.Color.AliceBlue
        Me.CustomPanel1.Location = New System.Drawing.Point(640, 24)
        Me.CustomPanel1.Name = "CustomPanel1"
        Me.CustomPanel1.Size = New System.Drawing.Size(64, 72)
        Me.CustomPanel1.TabIndex = 16
        '
        'btnExtinguish
        '
        Me.btnExtinguish.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExtinguish.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExtinguish.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExtinguish.Location = New System.Drawing.Point(688, 30)
        Me.btnExtinguish.Name = "btnExtinguish"
        Me.btnExtinguish.Size = New System.Drawing.Size(5, 5)
        Me.btnExtinguish.TabIndex = 18
        Me.btnExtinguish.TabStop = False
        Me.btnExtinguish.Text = "&Extinguish"
        Me.btnExtinguish.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'btnIgnite
        '
        Me.btnIgnite.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnIgnite.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIgnite.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnIgnite.Location = New System.Drawing.Point(680, 30)
        Me.btnIgnite.Name = "btnIgnite"
        Me.btnIgnite.Size = New System.Drawing.Size(5, 5)
        Me.btnIgnite.TabIndex = 17
        Me.btnIgnite.TabStop = False
        Me.btnIgnite.Text = "&Ignition"
        Me.btnIgnite.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'btnN2OIgnite
        '
        Me.btnN2OIgnite.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnN2OIgnite.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnN2OIgnite.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnN2OIgnite.Location = New System.Drawing.Point(680, 40)
        Me.btnN2OIgnite.Name = "btnN2OIgnite"
        Me.btnN2OIgnite.Size = New System.Drawing.Size(5, 5)
        Me.btnN2OIgnite.TabIndex = 19
        Me.btnN2OIgnite.TabStop = False
        Me.btnN2OIgnite.Text = "N2O&C"
        Me.btnN2OIgnite.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'btnDelete
        '
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelete.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDelete.Location = New System.Drawing.Point(688, 40)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(8, 8)
        Me.btnDelete.TabIndex = 25
        Me.btnDelete.TabStop = False
        Me.btnDelete.Text = "&Delete"
        Me.btnDelete.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'btnR
        '
        Me.btnR.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnR.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnR.Location = New System.Drawing.Point(680, 48)
        Me.btnR.Name = "btnR"
        Me.btnR.Size = New System.Drawing.Size(8, 8)
        Me.btnR.TabIndex = 24
        Me.btnR.TabStop = False
        Me.btnR.Text = "&R"
        Me.btnR.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'CustomPanelTop
        '
        Me.CustomPanelTop.BackColor = System.Drawing.Color.Gainsboro
        Me.CustomPanelTop.Controls.Add(Me.ToolBar)
        Me.CustomPanelTop.Controls.Add(Me.MenuBar)
        Me.CustomPanelTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.CustomPanelTop.Location = New System.Drawing.Point(0, 0)
        Me.CustomPanelTop.Name = "CustomPanelTop"
        Me.CustomPanelTop.Size = New System.Drawing.Size(712, 56)
        Me.CustomPanelTop.TabIndex = 4
        '
        'MenuBar
        '
        Me.MenuBar.BackColor = System.Drawing.Color.Transparent
        Me.MenuBar.CustomBackground = True
        Me.MenuBar.CustomizeText = "&Customize Toolbar..."
        Me.MenuBar.Dock = System.Windows.Forms.DockStyle.Top
        Me.MenuBar.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuBar.FullRow = True
        Me.MenuBar.ID = 2261
        Me.MenuBar.Items.AddRange(New NETXP.Controls.Bars.CommandBarItem() {Me.mnuFile, Me.mnuAnalysis, Me.mnuHistory, Me.mnuSpectrumModes, Me.mnuUtilities, Me.mnuService, Me.IQOQPQ, Me.mnuAdministration, Me.mnuHelpMain, Me.mnuChangeBeamType, Me.mnuHelpAbout})
        Me.MenuBar.Location = New System.Drawing.Point(0, 0)
        Me.MenuBar.Margins.Bottom = 1
        Me.MenuBar.Margins.Left = 1
        Me.MenuBar.Margins.Right = 1
        Me.MenuBar.Margins.Top = 1
        Me.MenuBar.Name = "MenuBar"
        Me.MenuBar.Size = New System.Drawing.Size(712, 23)
        Me.MenuBar.Style = NETXP.Controls.Bars.CommandBarStyle.Menu
        Me.MenuBar.TabIndex = 0
        Me.MenuBar.TabStop = False
        Me.MenuBar.Text = ""
        '
        'mnuFile
        '
        Me.mnuFile.Infrequent = True
        Me.mnuFile.Items.AddRange(New NETXP.Controls.Bars.CommandBarItem() {Me.mnuMethod, Me.CommandBarSeparatorItem2, Me.mnuExit})
        Me.mnuFile.PadHorizontal = 5
        Me.mnuFile.Text = "&Method"
        '
        'mnuMethod
        '
        Me.mnuMethod.Image = CType(resources.GetObject("mnuMethod.Image"), System.Drawing.Image)
        Me.mnuMethod.Shortcut = System.Windows.Forms.Shortcut.CtrlM
        Me.mnuMethod.Text = "&Method"
        '
        'mnuExit
        '
        Me.mnuExit.Image = CType(resources.GetObject("mnuExit.Image"), System.Drawing.Image)
        Me.mnuExit.Shortcut = System.Windows.Forms.Shortcut.CtrlX
        Me.mnuExit.Text = "E&xit"
        '
        'mnuAnalysis
        '
        Me.mnuAnalysis.Items.AddRange(New NETXP.Controls.Bars.CommandBarItem() {Me.mnuAnalyse})
        Me.mnuAnalysis.PadHorizontal = 5
        Me.mnuAnalysis.ShowText = True
        Me.mnuAnalysis.Text = "&Analysis"
        '
        'mnuAnalyse
        '
        Me.mnuAnalyse.Image = CType(resources.GetObject("mnuAnalyse.Image"), System.Drawing.Image)
        Me.mnuAnalyse.Shortcut = System.Windows.Forms.Shortcut.CtrlA
        Me.mnuAnalyse.Text = "&Analysis"
        '
        'mnuHistory
        '
        Me.mnuHistory.Items.AddRange(New NETXP.Controls.Bars.CommandBarItem() {Me.mnuDataFiles})
        Me.mnuHistory.PadHorizontal = 5
        Me.mnuHistory.Text = "Da&ta Files"
        '
        'mnuDataFiles
        '
        Me.mnuDataFiles.Image = CType(resources.GetObject("mnuDataFiles.Image"), System.Drawing.Image)
        Me.mnuDataFiles.Shortcut = System.Windows.Forms.Shortcut.CtrlD
        Me.mnuDataFiles.Text = "&Data Files"
        '
        'mnuSpectrumModes
        '
        Me.mnuSpectrumModes.Items.AddRange(New NETXP.Controls.Bars.CommandBarItem() {Me.mnuUVSpectrum, Me.mnuEnergySpectrum})
        Me.mnuSpectrumModes.PadHorizontal = 5
        Me.mnuSpectrumModes.ShowText = True
        Me.mnuSpectrumModes.Text = "&Spectrum"
        '
        'mnuUVSpectrum
        '
        Me.mnuUVSpectrum.Image = CType(resources.GetObject("mnuUVSpectrum.Image"), System.Drawing.Image)
        Me.mnuUVSpectrum.Shortcut = System.Windows.Forms.Shortcut.CtrlU
        Me.mnuUVSpectrum.Text = "&UV Spectrum"
        '
        'mnuEnergySpectrum
        '
        Me.mnuEnergySpectrum.Image = CType(resources.GetObject("mnuEnergySpectrum.Image"), System.Drawing.Image)
        Me.mnuEnergySpectrum.Shortcut = System.Windows.Forms.Shortcut.CtrlE
        Me.mnuEnergySpectrum.Text = "&Energy Spectrum"
        '
        'mnuUtilities
        '
        Me.mnuUtilities.Items.AddRange(New NETXP.Controls.Bars.CommandBarItem() {Me.mnuHydrideMode, Me.CommandBarSeparatorItem1, Me.mnuManualFlame, Me.mnuOpenReportFile, Me.mnuPrinterSetup, Me.mnuPrintertype, Me.mnuCookBook, Me.mnuFilterOn, Me.mnuAutoSampler, Me.mnuSetAbsorbanceThreshold, Me.mnuLampElements})
        Me.mnuUtilities.PadHorizontal = 5
        Me.mnuUtilities.ShowText = True
        Me.mnuUtilities.Text = "&Utilities"
        '
        'mnuHydrideMode
        '
        Me.mnuHydrideMode.Text = "&Hydride Mode"
        '
        'mnuManualFlame
        '
        Me.mnuManualFlame.Image = CType(resources.GetObject("mnuManualFlame.Image"), System.Drawing.Image)
        Me.mnuManualFlame.Shortcut = System.Windows.Forms.Shortcut.CtrlF
        Me.mnuManualFlame.Text = "&Manual Flame"
        '
        'mnuOpenReportFile
        '
        Me.mnuOpenReportFile.Image = CType(resources.GetObject("mnuOpenReportFile.Image"), System.Drawing.Image)
        Me.mnuOpenReportFile.Text = "&Open Export/Multielement Report File"
        '
        'mnuPrinterSetup
        '
        Me.mnuPrinterSetup.Image = CType(resources.GetObject("mnuPrinterSetup.Image"), System.Drawing.Image)
        Me.mnuPrinterSetup.Text = "&Printer Setup"
        '
        'mnuPrintertype
        '
        Me.mnuPrintertype.Image = CType(resources.GetObject("mnuPrintertype.Image"), System.Drawing.Image)
        Me.mnuPrintertype.Text = "P&rinter Type"
        '
        'mnuCookBook
        '
        Me.mnuCookBook.Image = CType(resources.GetObject("mnuCookBook.Image"), System.Drawing.Image)
        Me.mnuCookBook.Shortcut = System.Windows.Forms.Shortcut.CtrlC
        Me.mnuCookBook.Text = "&Cook Book"
        '
        'mnuFilterOn
        '
        Me.mnuFilterOn.Text = "&Filter On(201)"
        '
        'mnuAutoSampler
        '
        Me.mnuAutoSampler.Items.AddRange(New NETXP.Controls.Bars.CommandBarItem() {Me.mnuEnableAutoSAmpler, Me.mnuCheckSamplerFunctions})
        Me.mnuAutoSampler.Text = "&Auto Sampler"
        '
        'mnuEnableAutoSAmpler
        '
        Me.mnuEnableAutoSAmpler.Image = CType(resources.GetObject("mnuEnableAutoSAmpler.Image"), System.Drawing.Image)
        Me.mnuEnableAutoSAmpler.Text = "&Enable Auto Sampler"
        '
        'mnuCheckSamplerFunctions
        '
        Me.mnuCheckSamplerFunctions.Image = CType(resources.GetObject("mnuCheckSamplerFunctions.Image"), System.Drawing.Image)
        Me.mnuCheckSamplerFunctions.Text = "&Check Sampler Functions"
        '
        'mnuSetAbsorbanceThreshold
        '
        Me.mnuSetAbsorbanceThreshold.Image = CType(resources.GetObject("mnuSetAbsorbanceThreshold.Image"), System.Drawing.Image)
        Me.mnuSetAbsorbanceThreshold.Text = "&Set Absorbance Threshold"
        '
        'mnuLampElements
        '
        Me.mnuLampElements.Shortcut = System.Windows.Forms.Shortcut.F8
        Me.mnuLampElements.Text = "View Lamp Position"
        '
        'mnuService
        '
        Me.mnuService.Items.AddRange(New NETXP.Controls.Bars.CommandBarItem() {Me.mnuServiceUtility})
        Me.mnuService.PadHorizontal = 5
        Me.mnuService.ShowText = True
        Me.mnuService.Text = "Service"
        Me.mnuService.Visible = False
        '
        'mnuServiceUtility
        '
        Me.mnuServiceUtility.Image = CType(resources.GetObject("mnuServiceUtility.Image"), System.Drawing.Image)
        Me.mnuServiceUtility.Shortcut = System.Windows.Forms.Shortcut.CtrlY
        Me.mnuServiceUtility.Text = "Ser&vice Utility"
        '
        'IQOQPQ
        '
        Me.IQOQPQ.Items.AddRange(New NETXP.Controls.Bars.CommandBarItem() {Me.mnuIQOQPQ})
        Me.IQOQPQ.PadHorizontal = 5
        Me.IQOQPQ.Text = "I&QOQPQ"
        '
        'mnuIQOQPQ
        '
        Me.mnuIQOQPQ.Image = CType(resources.GetObject("mnuIQOQPQ.Image"), System.Drawing.Image)
        Me.mnuIQOQPQ.Shortcut = System.Windows.Forms.Shortcut.CtrlI
        Me.mnuIQOQPQ.Text = "IQOQPQ"
        '
        'mnuAdministration
        '
        Me.mnuAdministration.Items.AddRange(New NETXP.Controls.Bars.CommandBarItem() {Me.mnuAddUser, Me.mnuUserPermissions, Me.CommandBarSeparatorItem5, Me.mnuActivityLog, Me.mnuDeleteLog, Me.mnuChangePassword, Me.mnu21CFR})
        Me.mnuAdministration.PadHorizontal = 5
        Me.mnuAdministration.ShowText = True
        Me.mnuAdministration.Text = "Admi&nistration"
        '
        'mnuAddUser
        '
        Me.mnuAddUser.Image = CType(resources.GetObject("mnuAddUser.Image"), System.Drawing.Image)
        Me.mnuAddUser.Tag = ""
        Me.mnuAddUser.Text = "&Add User"
        '
        'mnuUserPermissions
        '
        Me.mnuUserPermissions.Image = CType(resources.GetObject("mnuUserPermissions.Image"), System.Drawing.Image)
        Me.mnuUserPermissions.Text = "&User Permissions"
        '
        'mnuActivityLog
        '
        Me.mnuActivityLog.Image = CType(resources.GetObject("mnuActivityLog.Image"), System.Drawing.Image)
        Me.mnuActivityLog.Tag = ""
        Me.mnuActivityLog.Text = "&Activity Log"
        '
        'mnuDeleteLog
        '
        Me.mnuDeleteLog.Image = CType(resources.GetObject("mnuDeleteLog.Image"), System.Drawing.Image)
        Me.mnuDeleteLog.Tag = ""
        Me.mnuDeleteLog.Text = "&Delete Log"
        '
        'mnuChangePassword
        '
        Me.mnuChangePassword.Image = CType(resources.GetObject("mnuChangePassword.Image"), System.Drawing.Image)
        Me.mnuChangePassword.Text = "&Change Password"
        '
        'mnu21CFR
        '
        Me.mnu21CFR.Image = CType(resources.GetObject("mnu21CFR.Image"), System.Drawing.Image)
        Me.mnu21CFR.Text = "Disable 21CFR"
        '
        'mnuHelpMain
        '
        Me.mnuHelpMain.Items.AddRange(New NETXP.Controls.Bars.CommandBarItem() {Me.mnuHelp, Me.CommandBarSeparatorItem3, Me.mnuAboutUs})
        Me.mnuHelpMain.PadHorizontal = 5
        Me.mnuHelpMain.Text = "&Help"
        Me.mnuHelpMain.Visible = False
        '
        'mnuHelp
        '
        Me.mnuHelp.Text = "&Help"
        '
        'mnuAboutUs
        '
        Me.mnuAboutUs.Text = "&About Us"
        '
        'mnuChangeBeamType
        '
        Me.mnuChangeBeamType.Items.AddRange(New NETXP.Controls.Bars.CommandBarItem() {Me.mnuSingleBeam, Me.mnuDoubleBeam})
        Me.mnuChangeBeamType.PadHorizontal = 5
        Me.mnuChangeBeamType.Text = "&Beam Type"
        Me.mnuChangeBeamType.Visible = False
        '
        'mnuSingleBeam
        '
        Me.mnuSingleBeam.CheckType = NETXP.Controls.Bars.ButtonItemCheckType.Radio
        Me.mnuSingleBeam.Text = "Single Beam"
        '
        'mnuDoubleBeam
        '
        Me.mnuDoubleBeam.Checked = True
        Me.mnuDoubleBeam.CheckType = NETXP.Controls.Bars.ButtonItemCheckType.Radio
        Me.mnuDoubleBeam.DefaultItem = True
        Me.mnuDoubleBeam.Text = "Double Beam"
        '
        'mnuHelpAbout
        '
        Me.mnuHelpAbout.Items.AddRange(New NETXP.Controls.Bars.CommandBarItem() {Me.mnuAbout})
        Me.mnuHelpAbout.Text = "Help"
        '
        'mnuAbout
        '
        Me.mnuAbout.Text = "About"
        '
        'StatusBar1
        '
        Me.StatusBar1.Location = New System.Drawing.Point(0, 399)
        Me.StatusBar1.Name = "StatusBar1"
        Me.StatusBar1.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.StatusBarPanelInfo, Me.ProgressPanel, Me.StatusBarPanelDate})
        Me.StatusBar1.ShowPanels = True
        Me.StatusBar1.Size = New System.Drawing.Size(712, 24)
        Me.StatusBar1.TabIndex = 5
        Me.StatusBar1.Text = "StatusBar1"
        '
        'StatusBarPanelInfo
        '
        Me.StatusBarPanelInfo.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
        Me.StatusBarPanelInfo.MinWidth = 40
        Me.StatusBarPanelInfo.Style = System.Windows.Forms.StatusBarPanelStyle.OwnerDraw
        Me.StatusBarPanelInfo.Width = 456
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
        Me.StatusBarPanelDate.Width = 40
        '
        'frmMDIMain
        '
        Me.AutoScale = False
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.CausesValidation = False
        Me.ClientSize = New System.Drawing.Size(712, 423)
        Me.Controls.Add(Me.CustomPanelMain)
        Me.Controls.Add(Me.StatusBar1)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.Name = "frmMDIMain"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.ToolBar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CustomPanelMain.ResumeLayout(False)
        Me.CustMain.ResumeLayout(False)
        Me.CustomPanelTop.ResumeLayout(False)
        CType(Me.MenuBar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StatusBarPanelInfo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProgressPanel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StatusBarPanelDate, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Private Constants "

    Private Const ConstFormLoad = "-Method"
    Private Const ConstFormLoadDataFiles = "-DataFiles"
    Private Const ConstFormLoadAnalysis = "-Analysis"
    Private Const CONST_Export = ".TXT"

    Public Enum EnumTimerStartStop
        Timer_Start = 1
        Timer_Stop = 2
    End Enum

#End Region

#Region " Member Variables "
    ' Dim objfrmEnergySpectrumDBMode As frmEnergySpectrumDBMode 

    Private mintElementID As Integer
    Friend WithEvents mobjfrmMethod As New frmMethod
    Private mobjfrmDataFiles As frmDataFiles
    Public mobjfrmAnalysis As frmAnalysis

    Private mblnIsApplicationClosed As Boolean

    'Private mobjThread As Threading.Thread
    'Private mobjTimerToCheckFlame As New System.Timers.Timer

    Private mblnIsStartAnalysisRunNumber As Boolean
    Private mblnIsMethodInstrumentSettingsChanged As Boolean

    Private mintIgniteType As ClsAAS203.enumIgniteType

    Private strPath As IO.Directory

    Public mobjController As clsBgThread

    Private mintMethodMode As Integer = 0       'Saurabh 04.07.07
    Dim mnuStopAspiration As New NETXP.Controls.Bars.CommandBarButtonItem
    Private mblnAvoidProcessing As Boolean = False
#End Region

#Region " Properties "

    Private Property ElementID() As Integer
        Get
            Return mintElementID
        End Get
        Set(ByVal Value As Integer)
            mintElementID = Value
        End Set
    End Property

    Public Property IsStartAnalysisRunNumber() As Boolean
        Get
            Return mblnIsStartAnalysisRunNumber
        End Get
        Set(ByVal Value As Boolean)
            mblnIsStartAnalysisRunNumber = Value
        End Set
    End Property

    Public Property MethodInstrumentSettingsChanged() As Boolean
        Get
            Return mblnIsMethodInstrumentSettingsChanged
        End Get
        Set(ByVal Value As Boolean)
            mblnIsMethodInstrumentSettingsChanged = Value
        End Set
    End Property

    Public Property IgniteType() As ClsAAS203.enumIgniteType
        Get
            Return mintIgniteType
        End Get
        Set(ByVal Value As ClsAAS203.enumIgniteType)
            mintIgniteType = Value
        End Set
    End Property

    Private Property OpenMethodMode() As EnumMethodMode
        Get
            Return mintMethodMode
        End Get
        Set(ByVal Value As EnumMethodMode)
            mintMethodMode = Value
        End Set
    End Property      'Added by Saurabh for IQOQPQ Test

#End Region

#Region " Form Load, Closing and other Events "

    Private Sub frmMDIMain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '=====================================================================
        ' Procedure Name        : frmMDIMain_Load
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To initialize the form
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 07.09.06
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor

        Try

            If gstructSettings.AppMode = EnumAppMode.FullVersion_203D Or gstructSettings.AppMode = EnumAppMode.DemoMode_203D Or _
           gstructSettings.AppMode = EnumAppMode.FullVersion_203 Or gstructSettings.AppMode = EnumAppMode.DemoMode Then
            Else
                mnuLampElements.Visible = False
            End If

            '---added on 12.05.09 for ver 6.89
            If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Or gstructSettings.AppMode = EnumAppMode.DemoMode_201 Then
                If gstructSettings.NewModelName = True Then
                    mnuUVSpectrum.Visible = False
                End If
            End If
            '---added on 12.05.09 for ver 6.89


            Application.DoEvents()
            gobjclsTimer = New clsTimer(StatusBar1, 1000)
            gobjclsTimer.subTimerStop()
            mnuCheckSamplerFunctions.Enabled = False

            mnuAbout.Text = mnuAbout.Text & Space(1) & gstrTitleInstrumentType

            If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
                btnIgnite.Enabled = False
                btnExtinguish.Enabled = False
            End If

            '---Added by Saurabh to show or hide Administration menu on MDI------
            If gstructSettings.CFR21Installation = False Then
                mnuAdministration.Enabled = False
                mnuAdministration.Visible = False
            End If



            StatusBarPanelInfo.Text = ""
            Call ShowProgressBar(gstrTitleInstrumentType & ConstFormLoad)

            Me.Text = gstrTitleInstrumentType

            '--- if User is other then an Administrator he or she won't get Access to the 
            '--- Administrator Mneu on the Main Screen
            If gstructUserDetails.UserID <> 0 Then
                mnuAdministration.Visible = False
            End If

            '---initialize form and add handlers
            Call funcInitialise()
            'Call AddHandlers()
            Call HideProgressBar()

            If gstructSettings.Enable21CFR = True Then
                mnu21CFR.Text = "Disable History"
                mnu21CFR.Image = Image.FromFile(Application.StartupPath & "\" & "images\Disable History.ico")
            Else
                mnu21CFR.Text = "Enable History"
                mnu21CFR.Image = Image.FromFile(Application.StartupPath & "\" & "images\Enable History.ico")
            End If

            AddHandler mnuStopAspiration.Click, AddressOf btnStopAspiration_Click

            mobjController = New clsBgThread(Me)

            '---to start flame status thread
            Call subStartFlameStatusThread()

            Call HideProgressBar()

            'Added by Saurabh 
            If gstructSettings.AppMode = EnumAppMode.FullVersion_203D Or gstructSettings.AppMode = EnumAppMode.DemoMode_203D Then
                mnuDoubleBeam.Visible = True
            Else
                mnuDoubleBeam.Visible = False
            End If

            'Saurabh 10.07.07 To bring status form in front
            gobjfrmStatus.Show()
            'Saurabh
            'mnuAbout.Text = mnuAbout.Text & Space(1) & Me.Text
            'gobjclsTimer = New clsTimer(StatusBar1, 1000)
            gobjclsTimer.subTimerStart(StatusBar1)
            Call AddHandlers()
            mobjfrmMethod.BringToFront()
            Application.DoEvents()
            'gobjclsTimer = New clsTimer(StatusBar1, 1000)
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
            HideProgressBar()
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub frmMDIMain_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        '=====================================================================
        ' Procedure Name        : frmMDIMain_Closing
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To close the form
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 14.11.06
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor

        Try
            e.Cancel = True
            Me.DialogResult = DialogResult.None

            If Not mblnIsApplicationClosed Then
                Call subExit_Click(mnuExit, EventArgs.Empty)
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
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub frmMDIMain_Move(ByVal sender As Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : frmMDIMain_Move
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To  assign hight width to form the form
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 14.11.06
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor

        Try
            Me.Top = 0
            Me.Left = 0
            Me.Width = 800
            Me.Height = 575

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

#End Region

#Region " Private Functions "

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
        ' Created               : 05.10.06
        ' Revisions             : 
        '=====================================================================
        Try
            'add event handler to toolbar buttons and menus
            AddHandler tlbbtnMethod.Click, AddressOf mnuMethod_Click
            AddHandler mnuMethod.Click, AddressOf mnuMethod_Click

            AddHandler tlbbtnAnalyse.Click, AddressOf mnuAnalyse_Click
            AddHandler mnuAnalyse.Click, AddressOf mnuAnalyse_Click

            AddHandler tlbbtnDataFiles.Click, AddressOf mnuDataFiles_Click
            AddHandler mnuDataFiles.Click, AddressOf mnuDataFiles_Click

            AddHandler tlbbtnCookBook.Click, AddressOf mnuCookBook_Click
            AddHandler mnuCookBook.Click, AddressOf mnuCookBook_Click

            AddHandler mnuExit.Click, AddressOf subExit_Click
            AddHandler tlbbtnExit.Click, AddressOf subExit_Click

            AddHandler tlbbtnUVSpectrum.Click, AddressOf mnuUVSpectrum_Click
            AddHandler mnuUVSpectrum.Click, AddressOf mnuUVSpectrum_Click

            AddHandler tlbbtnEnergySpectrum.Click, AddressOf mnuEnergySpectrum_Click
            'AddHandler mnuEnergySpectrum.Click, AddressOf mnuEnergySpectrum_Click

            AddHandler tlbbtnService.Click, AddressOf mnuServiceUtility_Click
            AddHandler mnuServiceUtility.Click, AddressOf mnuServiceUtility_Click
            'AddHandler mnuAboutUs.Click, AddressOf mnuAboutUs_Click

            AddHandler tlbbtnIQOQPQ.Click, AddressOf mnuIQOQPQ_Click
            AddHandler mnuIQOQPQ.Click, AddressOf mnuIQOQPQ_Click

            AddHandler mnuAddUser.Click, AddressOf mnuAddUser_Click

            AddHandler mnuUserPermissions.Click, AddressOf mnuUserPermissions_Click
            AddHandler mnuActivityLog.Click, AddressOf mnuActivityLog_Click
            AddHandler mnuDeleteLog.Click, AddressOf mnuDeleteLog_Click
            AddHandler mnuChangePassword.Click, AddressOf mnuChangePassword_Click
            AddHandler mnu21CFR.Click, AddressOf mnu21CFR_Click
            AddHandler mnuPrinterSetup.Click, AddressOf mnuPrinterSetup_Click
            AddHandler mnuPrintertype.Click, AddressOf mnuPrintertype_Click

            AddHandler tlbbtnManualFlame.Click, AddressOf mnuManualFlame_Click
            AddHandler mnuManualFlame.Click, AddressOf mnuManualFlame_Click

            AddHandler MyBase.Move, AddressOf frmMDIMain_Move
            AddHandler MyBase.Closing, AddressOf frmMDIMain_Closing
            AddHandler mnuOpenReportFile.Click, AddressOf mnuOpenReportFile_Click

            AddHandler mnuSingleBeam.Click, AddressOf mnuSingleBeam_Click
            AddHandler mnuDoubleBeam.Click, AddressOf mnuDoubleBeam_Click
            'AddHandler Tmp1.Click, AddressOf btnIgnite_Click
            AddHandler mnuLampElements.Click, AddressOf mnuLampPosition_Click

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

    Private Function funcInitialise() As Boolean
        '=====================================================================
        ' Procedure Name        : funcInitialise
        ' Parameters Passed     : None
        ' Returns               : True/False
        ' Purpose               : 
        ' Description           : Initialise the form Object
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 23.01.07
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor

        Try
            mnuFilterOn.CheckType = NETXP.Controls.Bars.ButtonItemCheckType.Checkmark

            If gobjClsAAS203.IsFilter = True Then
                mnuFilterOn.Checked = True
                mnuFilterOn.Text = "Filter Off"
            Else
                mnuFilterOn.Checked = False
                mnuFilterOn.Text = "Filter On (201)"
            End If

            mnuHydrideMode.CheckType = NETXP.Controls.Bars.ButtonItemCheckType.Checkmark
            '---set hydride mode status on menu
            If gstructSettings.HydrideMode = 1 Then
                mnuHydrideMode.Checked = True
                gobjInst.Hydride = True
                HydrideMode = True

                If Not gobjfrmStatus Is Nothing Then
                    gobjfrmStatus.IsHydrideMode = True
                End If

            Else
                mnuHydrideMode.Checked = False
                gobjInst.Hydride = False
                HydrideMode = False

                If Not gobjfrmStatus Is Nothing Then
                    gobjfrmStatus.IsHydrideMode = False
                End If
            End If
            'Check for enable or disable for IQOQPQ Menu '10.12.07
            If gstructSettings.EnableIQOQPQ = False Then
                IQOQPQ.Visible = False
                'Added by Pankaj on 20 Feb 08
                tlbbtnIQOQPQ.Visible = False
            Else
                IQOQPQ.Visible = True
                'Added by Pankaj on 20 Feb 08
                tlbbtnIQOQPQ.Visible = True
            End If

            'enable special feature for 203D
            If gstructSettings.AppMode = EnumAppMode.FullVersion_203D Then
                mnuUVSpectrum.Enabled = True
            Else
                mnuUVSpectrum.Enabled = True
            End If

            If gstructSettings.AppMode = EnumAppMode.FullVersion_203D Or gstructSettings.AppMode = EnumAppMode.DemoMode_203D Then
                mnuChangeBeamType.Visible = True
                mnuChangeBeamType.Items.Item(0).Enabled = True
                mnuChangeBeamType.Items.Item(1).Enabled = True
                '---changed on 20.03.08 to make beam type selection permanent
                If gintInstrumentBeamType = enumInstrumentBeamType.SingleBeam Then
                    mnuSingleBeam.Checked = True
                    mnuDoubleBeam.Checked = False
                ElseIf gintInstrumentBeamType = enumInstrumentBeamType.DoubleBeam Then
                    mnuSingleBeam.Checked = False
                    mnuDoubleBeam.Checked = True
                End If

            Else
                mnuChangeBeamType.SuspendEvents()
                mnuChangeBeamType.Visible = False
                mnuChangeBeamType.ResumeEvents()
            End If

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
            objWait.Dispose()
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Function

    Private Sub mnuMethod_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : mnuMethod_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To load the Method form
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 25.09.06
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Try
            '---to bring method form in front
            ShowProgressBar(gstrTitleInstrumentType & ConstFormLoad)
            tlbbtnMethod.SuspendEvents()

            If (gstructSettings.Enable21CFR = True) Then
                If Not funcCheckActivityAuthentication(enumActivityAuthentication.Method, gstructUserDetails.Access) Then
                    Return
                    Exit Sub
                End If
                gfuncInsertActivityLog(EnumModules.Method, "Method Accessed")
            End If
            mobjfrmMethod.Enabled = True        'Saurabh 'uncomment By Pankaj sun 20 May 07 
            mobjfrmMethod.BringToFront()
            'mobjfrmMethod.Activate()            'Saurabh
            mobjfrmMethod.btnNewMethod.Focus()  'Saurabh
            'mobjfrmDataFiles.Enabled = False   'Saurabh
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
            'objfrmMethod.Dispose()
            tlbbtnMethod.ResumeEvents()
            HideProgressBar()
            Me.Focus()
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub mnuAnalyse_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : mnuAnalyse_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To load the Analysis form
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 25.09.06
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Dim retval As Integer
        Dim blnIsMethodOK As Boolean
        Dim ctrl As Control

        Try
            Call ShowProgressBar(gstrTitleInstrumentType & ConstFormLoadAnalysis)
            tlbbtnAnalyse.SuspendEvents()

            If (gstructSettings.Enable21CFR = True) Then
                If Not funcCheckActivityAuthentication(enumActivityAuthentication.Analysis, gstructUserDetails.Access) Then
                    Return
                    Exit Sub
                End If
                gfuncInsertActivityLog(EnumModules.Analysis, "Analysis Accessed")
            End If

            '---First Check the Method is loaded properly and
            '---is ready to start the Analysis.
            gobjclsTimer.subTimerStop()
            If Not IsNothing(gobjNewMethod) Then
                If gobjNewMethod.Status = True Then
                    '---Allow user to proceed to Analysis
                Else
                    '---Don't allow user to enter Analysis.
                    'MessageBox.Show("The method setting is not entered or loaded properly.", "No Method Loaded", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    gobjMessageAdapter.ShowMessage(constMethodNotLoaded)
                    Application.DoEvents()
                    Exit Sub
                End If
            Else
                '---Don't allow user to enter Analysis.
                'MessageBox.Show("The method setting is not entered or loaded properly.", "No Method Loaded", MessageBoxButtons.OK, MessageBoxIcon.Error)
                gobjMessageAdapter.ShowMessage(constMethodNotLoaded)
                Application.DoEvents()
                Exit Sub
            End If


            'TO DO --- Add code for checking the Hardware lock later.

            '#If HARDWARELOCK Then
            '   if(!IsChemitoLock(0))
            '       break;
            '#End If


            If Not IsNothing(mobjfrmAnalysis) Then
                mobjfrmAnalysis.IsAvoidProcessing = True
                retval = CheckMethod()
                If (retval = 2) Then
                    blnIsMethodOK = True
                    '---Hide Previous Window
                    'Vis=FALSE;
                    'DestroyWindow(Mhwnd);
                    'Mhwnd=NULL;
                    'mobjfrmAnalysis.Close()
                    'mobjfrmAnalysis.Dispose()
                    'mobjfrmAnalysis = Nothing
                    Call mobjfrmAnalysis.funcRefreshMethodParameter()
                    'If gblnSetSpeedIssue = True Then
                    If gobjMain.mobjController.IsThreadRunning = True Then '28.09.07
                        gobjMain.mobjController.Cancel()   'commented by Saurabh
                        gobjCommProtocol.mobjCommdll.subTime_Delay(500)   '10.12.07
                        Application.DoEvents()
                    End If
                    'End If

                    mobjfrmAnalysis.Show()
                    '---bring analysis from in front
                    mobjfrmAnalysis.BringToFront()
                    Application.DoEvents()
                    mobjfrmAnalysis.btnStdGraph.Focus()
                    Application.DoEvents()
                    'mobjfrmAnalysis.tmrAspirationMsg.Enabled = True
                    'If gblnSetSpeedIssue = True Then
                    If gobjMain.mobjController.IsThreadRunning = False Then  '28.09.07
                        gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay)   '10.12.07
                        Application.DoEvents()
                        gobjMain.mobjController.Start(gobjclsBgFlameStatus)      'commented by Saurabh
                        Application.DoEvents()
                    End If
                    'End If

                    '--- Added by Mangesh on 14-Mar-2007
                    '--- For Peak Latching when Instrument Settings of Method are changed 

                    If mblnIsMethodInstrumentSettingsChanged Then
                        mblnIsMethodInstrumentSettingsChanged = False
                        If gstructSettings.AppMode = EnumAppMode.DemoMode Or gstructSettings.AppMode = EnumAppMode.DemoMode_201 Or gstructSettings.AppMode = EnumAppMode.DemoMode_203D Then
                            '---Don't perform Peak Latching operation for Demo Method
                        Else
                            '---Search and Find Analytical Peak
                            Call mobjfrmAnalysis.CheckInstrumentOptimisation()
                        End If
                    End If

                Else
                    blnIsMethodOK = False
                    If (retval = 1) Then
                        'MessageBox.Show("No Standards.", "ANALYSIS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        gobjMessageAdapter.ShowMessage(constNoStandards)
                        Application.DoEvents()
                    Else
                        gobjMessageAdapter.ShowMessage(constNoMethods)
                        Application.DoEvents()
                        'MessageBox.Show("No Method defined.", "ANALYSIS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End If
                End If
                mobjfrmAnalysis.IsAvoidProcessing = False
            End If

            If IsNothing(mobjfrmAnalysis) Then
                '---if analysis form is being opened for the first time
                '---then build new object of it and initialize it
                Call OnQuantAnalyse()
            End If
            mobjfrmMethod.Enabled = False       'Saurabh'Pankaj on Sun 20 May 07
            'gobjclsTimer.subTimerStart(StatusBar1)
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
            gobjclsTimer.subTimerStart(StatusBar1)
            tlbbtnAnalyse.ResumeEvents()
            Call HideProgressBar()
            objWait.Dispose()
            Me.Focus()
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Sub

    Public Sub OnQuantAnalyse()
        '=====================================================================
        ' Procedure Name        : OnQuantAnalyse
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 13-Feb-2007 12:15 pm
        ' Revisions             : 1
        '=====================================================================

        '---- ORIGINAL CODE

        'void	OnQuantAnalyse(HWND hwnd)
        '{
        '	int	mvalid;
        '	MSG	msg;
        '	int msgcount=0;

        '	mvalid = CheckMethod();

        '	if (mvalid==0)
        '		return;

        '	if (mvalid==2)
        '	{
        '		//ANALYSIS = TRUE;
        '		SetShortHelp("", TRUE);
        '                If (skp) Then
        '			FreeProcInstance(skp);
        '		skp = (DLGPROC) MakeProcInstance((DLGPROC) QuantAnalyseProc,hInst);
        '                    If (!QanaWnd) Then
        '		{
        '			Vis = FALSE;
        '			Mhwnd = CreateDialog(hInst,"QANALYSE", hwnd, skp);
        '			QanaWnd = Mhwnd;
        '			Vis = TRUE;
        '		}
        '                    Else
        '		{
        '			Mhwnd = QanaWnd;
        '			CurStd = Check_Std( Method->QuantData->StdTopData, CurStd);
        '			CurSamp = Check_Samp(Method->QuantData->SampTopData , CurSamp);
        '		}
        '		ShowWindow (Mhwnd, SW_SHOW); //MAXIMIZED) ;
        '		UpdateWindow (Mhwnd) ;
        '		SetMethodTittle1();
        '		Vis=TRUE;
        '		WP1=-1;
        '		CheckAnaButtons(Mhwnd);
        '		CheckInstrumentOptimisation(Mhwnd);

        '       While (1)
        '		{
        '			mvalid= CheckMsg1(Mhwnd, &msg);
        '			if (mvalid==2 && msg.message==WM_COMMAND ||WP1==800)
        '			{
        '               If (cmode! = CM_ANALYSE) Then
        '				    break;
        '			}
        '           ElseIf (Started) Then
        '			{
        '				Aspirate(Mhwnd);//Aspirate(); //mdf by sk on 29/2/2000 for autosampler
        '			}
        '		}
        '		DestroyAspWnd();
        '	}
        '	else if (mvalid==1)
        '		Gerror_message("No Standard Information available");

        '	SetShortHelp("", FALSE);

        '	if (WP1==800 && LP1==1000)
        '		PostMessage(hwnd,WM_COMMAND, CM_EXIT, 0L);

        '	WP1=0;
        '	ANALYSIS = FALSE;
        '}

        Dim mvalid As Integer
        Dim msgcount As Integer
        Dim msg As Message

        Try
            '---check valid method
            mvalid = CheckMethod()

            If (mvalid = 0) Then
                Return
            End If

            If (mvalid = 2) Then
                
                'SetShortHelp("", TRUE);
                'If (skp) Then
                '    'FreeProcInstance(skp);
                'End If
                'skp = (DLGPROC) MakeProcInstance((DLGPROC) QuantAnalyseProc,hInst);
                If IsNothing(mobjfrmAnalysis) Then
                    'Vis = False;
                    'Mhwnd = CreateDialog(hInst,"QANALYSE", hwnd, skp);
                    'QanaWnd = Mhwnd;
                    'Vis = True;

                    'Vis = False
                    Application.DoEvents()
                    'mobjfrmMethod.SendToBack()
                    '---create new object of analysis form
                    mobjfrmAnalysis = New frmAnalysis
                    mobjfrmAnalysis.IsAvoidProcessing = True
                    mobjfrmAnalysis.IsMdiContainer = False
                    mobjfrmAnalysis.TopLevel = False
                    'mobjfrmAnalysis.ToolBarAnalysis.Visible = False
                    'mobjfrmAnalysis.StatusBar1.Visible = False
                    mobjfrmAnalysis.ControlBox = False
                    mobjfrmAnalysis.Dock = DockStyle.Fill
                    mobjfrmAnalysis.Text = ""
                    CustMain.Controls.Add(mobjfrmAnalysis)
                    Application.DoEvents()
                    'Vis = True
                Else
                    'Mhwnd = QanaWnd;
                    'CurStd = Check_Std( Method->QuantData->StdTopData, CurStd);
                    'CurSamp = Check_Samp(Method->QuantData->SampTopData , CurSamp);
                End If

                If mblnIsStartAnalysisRunNumber Then
                    mobjfrmAnalysis.mblnIsStartRunNumber = True
                End If
                Application.DoEvents()
                ' Set issue for Speed 
                'If gblnSetSpeedIssue = True Then
                If gobjMain.mobjController.IsThreadRunning = True Then  '28.09.07
                    gobjMain.mobjController.Cancel()     'commented by Saurabh
                    gobjCommProtocol.mobjCommdll.subTime_Delay(500)   '10.12.07
                    Application.DoEvents()
                End If
                'End If

                mobjfrmAnalysis.Show()
                mobjfrmAnalysis.IsAvoidProcessing = True
                '---bring analysis form in front
                mobjfrmAnalysis.BringToFront()

                Application.DoEvents()
                'Vis = True
                'WP1 = -1
                '---set new analysis settings
                mobjfrmAnalysis.mblnExecuteRunNo = True
                Call mobjfrmAnalysis.StartNewAnalysis()
                '---eneable/disable analysis buttons
                Call mobjfrmAnalysis.CheckAnaButtons()
                mobjfrmAnalysis.mblnExecuteRunNo = False
                ' Set issue for Speed 
                'If gblnSetSpeedIssue = True Then
                '''If gobjMain.mobjController.IsThreadRunning = False Then  '25.11.07
                '''    gobjMain.mobjController.Start(gobjclsBgFlameStatus)      'commented by Saurabh
                '''    Application.DoEvents()
                '''End If
                'End If
                If gstructSettings.AppMode = EnumAppMode.DemoMode Or gstructSettings.AppMode = EnumAppMode.DemoMode_201 Or gstructSettings.AppMode = EnumAppMode.DemoMode_203D Then
                    '---Don't perform Peak Latching operation for Demo Method
                Else
                    '---Search and Find Analytical Peak
                    Call mobjfrmAnalysis.CheckInstrumentOptimisation()
                End If

                If gobjMain.mobjController.IsThreadRunning = False Then  '25.11.07
                    gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay)   '10.12.07
                    Application.DoEvents()
                    gobjMain.mobjController.Start(gobjclsBgFlameStatus)
                    Application.DoEvents()
                End If
                mobjfrmAnalysis.IsAvoidProcessing = False
                'While (1)
                '    'mvalid= CheckMsg1(Mhwnd, &msg)
                '    If (mvalid = 2 And msg.message = WM_COMMAND Or WP1 = 800) Then
                '        If (cmode <> CM_ANALYSE) Then
                '            Exit While
                '        End If
                '    ElseIf (Started) Then
                '        Aspirate() '//Aspirate(); //mdf by sk on 29/2/2000 for autosampler
                '    End If
                'End While
                'DestroyAspWnd()

            ElseIf (mvalid = 1) Then
                'Gerror_message("No Standard Information available");
                gobjMessageAdapter.ShowMessage("No Standard Information available", "Analysis", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage)
                Application.DoEvents()
            End If

            'SetShortHelp("", FALSE);
            'If (WP1 = 800 And LP1 = 1000) Then
            '    'PostMessage(hwnd,WM_COMMAND, CM_EXIT, 0L);
            'End If
            'WP1 = 0
            'ANALYSIS = False

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

    Private Sub mnuDataFiles_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : mnuDataFiles_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To load the Data Files form
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 25.09.06
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Dim objCntrl As Control

        Try
            'Saurabh 10.07.07 While Analysis under progress
            If Not IsNothing(mobjfrmAnalysis) Then
                If mobjfrmAnalysis.InAnalysis Then
                    gobjMessageAdapter.ShowMessage(constAnalysisUnderProgress)
                    Application.DoEvents()
                    Exit Sub
                End If
            End If
            'Saurabh 10.07.07 While Analysis under progress

            tlbbtnDataFiles.SuspendEvents()
            ShowProgressBar(gstrTitleInstrumentType & ConstFormLoadDataFiles)

            If (gstructSettings.Enable21CFR = True) Then
                If Not funcCheckActivityAuthentication(enumActivityAuthentication.DataFiles, gstructUserDetails.Access) Then
                    Return
                    Exit Sub
                End If
                gfuncInsertActivityLog(EnumModules.DataFiles, "DataFiles Accessed")
            End If

            '---display data files form
            mobjfrmDataFiles.Show()
            '---bring data files form in front
            mobjfrmDataFiles.BringToFront()
            Application.DoEvents()
            mobjfrmDataFiles.btnLoad.Focus()    'Saurabh
            mobjfrmMethod.SendToBack()
            mobjfrmDataFiles.BringToFront() 'Added by pankaj on 26 Aug 07

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
            tlbbtnDataFiles.ResumeEvents()
            HideProgressBar()
            Me.Focus()
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub subExit_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : subExit_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To exit from the software 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 25.09.06
        ' Revisions             : 
        '=====================================================================
        Try
            '---shut down application
            tlbbtnExit.SuspendEvents()

            Call ShutDownApplication()

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
            tlbbtnExit.ResumeEvents()
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub mnuCookBook_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : mnuCookBook_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To load the Cook Book form
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 25.09.06
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Dim objfrmCookBook As New frmCookBook
        Dim objDtElement As New DataTable
        Dim objDtElementDetails As New DataTable
        Dim objCntrl As Control
        Try
            If (gstructSettings.Enable21CFR = True) Then
                'check user authentication
                If Not funcCheckActivityAuthentication(enumActivityAuthentication.CookBook, gstructUserDetails.Access) Then
                    Return
                    Exit Sub
                End If
                gfuncInsertActivityLog(EnumModules.CookBook, "CookBook Accessed")
            End If

            tlbbtnCookBook.SuspendEvents()
            gblnCookBookReport = True
            Application.DoEvents()

            '---to display cook book form
            objfrmCookBook = New frmCookBook
            If objfrmCookBook.ShowDialog() = DialogResult.OK Then
                'get element details from cookbook
                Application.DoEvents()
                ElementID = objfrmCookBook.ElementID
                objDtElement = gobjClsAAS203.funcGetElement(ElementID)
                objDtElementDetails = gobjClsAAS203.funcGetElementWavelengths(ElementID)
            End If
            gblnCookBookReport = False
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
            tlbbtnCookBook.ResumeEvents()
            Me.Focus()
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub mnuUVSpectrum_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : mnuUVSpectrum_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To load the UV Spectrum form
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 25.09.06
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Dim objfrmUVSpectrumMode As frmUVScanningSpectrumMode
        Dim objfrmUVSpectrumDBMode As frmUVScanningSpectrumDBMode

        Try
            If (gstructSettings.Enable21CFR = True) Then
                'check for 21 CFR
                If Not funcCheckActivityAuthentication(enumActivityAuthentication.UV_Scanning_Spectrum_Mode, gstructUserDetails.Access) Then
                    Return
                    Exit Sub
                End If
                gfuncInsertActivityLog(EnumModules.UV_Scanning_Spectrum_Mode, "UV_Scanning_Spectrum_Mode Accessed")
            End If
            '---stop aspiration thread in analysis
            If Not IsNothing(mobjfrmAnalysis) Then
                If Not IsNothing(mobjfrmAnalysis.mobjBgMsgAspirate) Then
                    If mobjfrmAnalysis.IsDisplayingMessage = True Then
                        mobjfrmAnalysis.mobjBgMsgAspirate.Cancel()
                    End If
                End If
            End If
            '--- Set issue for Speed 
            'If gblnSetSpeedIssue = True Then
            If Not gstructSettings.ExeToRun = EnumApplicationMode.ServiceUtility Then  '28.09.07
                If Not IsNothing(gobjMain) Then
                    If gobjMain.mobjController.IsThreadRunning = True Then
                        gobjMain.mobjController.Cancel()   'commented by Saurabh
                        gobjCommProtocol.mobjCommdll.subTime_Delay(500)   '10.12.07
                        Application.DoEvents()
                    End If
                End If
            End If
            'End If
            '//---
            gobjclsTimer.subTimerStop()

            '---load uv spectrum form according to the instrument type
            gintSpectrumMode = modGlobalDeclarations.EnumSpectrumMode.UVSpetrum
            If gstructSettings.AppMode = EnumAppMode.FullVersion_203D Then
                objfrmUVSpectrumDBMode = New frmUVScanningSpectrumDBMode
                objfrmUVSpectrumDBMode.ShowDialog()
                Application.DoEvents()
            ElseIf gstructSettings.AppMode = EnumAppMode.FullVersion_203D Or _
                gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
                objfrmUVSpectrumMode = New frmUVScanningSpectrumMode
                objfrmUVSpectrumMode.ShowDialog()
                Application.DoEvents()
            Else
                If gintInstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.DoubleBeam Then
                    objfrmUVSpectrumDBMode = New frmUVScanningSpectrumDBMode
                    objfrmUVSpectrumDBMode.ShowDialog()
                    Application.DoEvents()
                Else
                    objfrmUVSpectrumMode = New frmUVScanningSpectrumMode
                    objfrmUVSpectrumMode.ShowDialog()
                    Application.DoEvents()
                End If
            End If

            gobjclsTimer.subTimerStart(StatusBar1)
            '---start aspiration thread here
            If Not IsNothing(mobjfrmAnalysis) Then
                If Not IsNothing(mobjfrmAnalysis.mobjBgMsgAspirate) Then
                    If mobjfrmAnalysis.IsDisplayingMessage = True Then
                        mobjfrmAnalysis.mobjBgMsgAspirate.Start()
                    End If
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
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            Me.Focus()
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub mnuEnergySpectrum_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuEnergySpectrum.Click
        '=====================================================================
        ' Procedure Name        : mnuEnergySpectrum_Click
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
        Dim objfrmEnergySpectrumMode As frmEnergySpectrumMode
        Dim objfrmEnergySpectrumDBMode As frmEnergySpectrumDBMode
        Dim objWait As New CWaitCursor
        Try
            If (gstructSettings.Enable21CFR = True) Then
                'check for 21 CFR
                If Not funcCheckActivityAuthentication(enumActivityAuthentication.Energy_Spectrum_Mode, gstructUserDetails.Access) Then
                    Return
                    Exit Sub
                End If
                gfuncInsertActivityLog(EnumModules.Energy_Spectrum_Mode, "Energy_Spectrum_Mode Accessed")
            End If

            '--- Set issue for Speed 
            'If gblnSetSpeedIssue = True Then
            If Not gstructSettings.ExeToRun = EnumApplicationMode.ServiceUtility Then  '28.09.07
                If Not IsNothing(gobjMain) Then
                    If gobjMain.mobjController.IsThreadRunning = True Then
                        gobjMain.mobjController.Cancel()   'commented by Saurabh
                        gobjCommProtocol.mobjCommdll.subTime_Delay(500)   '10.12.07
                        Application.DoEvents()
                    End If
                End If
            End If
            'End If
            '//---

            '---stop aspiration thread
            gintSpectrumMode = modGlobalDeclarations.EnumSpectrumMode.EnergySpectrum
            If Not IsNothing(mobjfrmAnalysis) Then
                If Not IsNothing(mobjfrmAnalysis.mobjBgMsgAspirate) Then
                    If mobjfrmAnalysis.IsDisplayingMessage = True Then
                        mobjfrmAnalysis.mobjBgMsgAspirate.Cancel()
                    End If
                End If
            End If

            '---display energy spectrum form according to the instrument type
            gobjclsTimer.subTimerStop()

            If gstructSettings.AppMode = EnumAppMode.FullVersion_203D Then
                objfrmEnergySpectrumDBMode = New frmEnergySpectrumDBMode
                objfrmEnergySpectrumDBMode.ShowDialog()
                Application.DoEvents()
                '//----- added by Sachin Dokhale
            ElseIf gstructSettings.AppMode = EnumAppMode.FullVersion_201 Or _
                     gstructSettings.AppMode = EnumAppMode.FullVersion_203 Then

                objfrmEnergySpectrumMode = New frmEnergySpectrumMode
                objfrmEnergySpectrumMode.ShowDialog()
                Application.DoEvents()
            Else
                If gintInstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.DoubleBeam Then
                    objfrmEnergySpectrumDBMode = New frmEnergySpectrumDBMode
                    objfrmEnergySpectrumDBMode.ShowDialog()
                    Application.DoEvents()
                Else
                    objfrmEnergySpectrumMode = New frmEnergySpectrumMode
                    objfrmEnergySpectrumMode.ShowDialog()
                    Application.DoEvents()
                End If
            End If

            '---start aspiration thread here
            If Not IsNothing(mobjfrmAnalysis) Then
                If Not IsNothing(mobjfrmAnalysis.mobjBgMsgAspirate) Then
                    If mobjfrmAnalysis.IsDisplayingMessage = True Then
                        mobjfrmAnalysis.mobjBgMsgAspirate.Start()
                    End If
                End If
            End If
            gobjclsTimer.subTimerStart(StatusBar1)
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
            Me.Focus()
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub mnuAboutUs_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : mnuAboutUs_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To show About Us form.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 05.12.06
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Dim objfrmAboutUs As New frmAboutUs
        Try
            objfrmAboutUs.ShowDialog()
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
            Me.Focus()
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub mnuServiceUtility_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : mnuServiceUtility_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To load the Service Utility form
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 25.09.06
        ' Revisions             : 
        '=====================================================================
        'Dim objWait As New CWaitCursor
        Dim objfrmMDIMainService As New frmMDIMainService
        Try
            'check for 21 CFR
            If (gstructSettings.Enable21CFR = True) Then
                If Not funcCheckActivityAuthentication(enumActivityAuthentication.ServiceUtilities, gstructUserDetails.Access) Then
                    Return
                    Exit Sub
                End If
                gfuncInsertActivityLog(EnumModules.Service_Utilities, "ServiceUtilities Accessed")
            End If


            objfrmMDIMainService.ShowDialog()
            Application.DoEvents()
            Me.Visible = True
            objfrmMDIMainService.Dispose()
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
            Me.Focus()
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub mnuOpenReportFile_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : mnuOpenReportFile_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To Open the Expoted or Multi Report file
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 25.09.06
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Dim objfrmTextReportViewer As frmTextReportViewer
        Dim objStream As System.IO.Stream
        Dim strReportFilePath As String
        Dim objofdSpectrum As New OpenFileDialog
        Try
            'check for 21 CFR
            If (gstructSettings.Enable21CFR = True) Then
                If Not funcCheckActivityAuthentication(enumActivityAuthentication.ServiceUtilities, gstructUserDetails.Access) Then
                    Return
                    Exit Sub
                End If
                gfuncInsertActivityLog(EnumModules.Service_Utilities, "ServiceUtilities Accessed")
            End If
            '---To Show the Report 

            '



            objofdSpectrum.InitialDirectory = strPath.GetCurrentDirectory.ToString & "\TextReports"
            objofdSpectrum.Filter = "Exported or Multi Report Files(*" & CONST_Export & ")|*" & CONST_Export
            objofdSpectrum.FilterIndex = 1
            objofdSpectrum.RestoreDirectory = True

            If objofdSpectrum.ShowDialog() = DialogResult.OK Then
                If (objofdSpectrum.CheckFileExists()) Then

                    strReportFilePath = objofdSpectrum.FileName

                    objfrmTextReportViewer = New frmTextReportViewer
                    objfrmTextReportViewer.ReportFilePath = strReportFilePath

                    objfrmTextReportViewer.ShowDialog()
                    objfrmTextReportViewer.Close()
                End If
            End If

            Application.DoEvents()
            Me.Visible = True

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
            If Not objfrmTextReportViewer Is Nothing Then
                objfrmTextReportViewer.Dispose()
                objfrmTextReportViewer = Nothing
            End If
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            Application.DoEvents()
            Me.Focus()
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub mnuIQOQPQ_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : mnuIQOQPQ_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To load the IQOQPQ form
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 25.09.06
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Dim strIQPQOQDataBaseName As String
        Dim strIQPQOQDatabasePassword As String
        Dim strProvider As String
        Dim intDataSourceType As Integer
        Dim strUserName As String
        Dim strPassword As String
        Dim strSqlDataSource As String

        Dim objConfig As Configuration.ConfigurationSettings
        Dim strConfigPath As String
        Dim strDatabasePath As String

        Try
            IsInIQOQPQ = True       'Saruabh 22.07.07
            strConfigPath = Application.ExecutablePath & ".config"
            If Not System.IO.File.Exists(strConfigPath) Then
                '---display message "app.config file not found"
                'gobjMessageAdapter.ShowMessage(msgIDAppConfigFileNotFound)
            Else
                intDataSourceType = CInt(objConfig.AppSettings("DataSorceType"))
                strProvider = objConfig.AppSettings.Item("Provider")
                strUserName = objConfig.AppSettings.Item("User Name")
                strPassword = objConfig.AppSettings.Item("Password")
                strDatabasePath = objConfig.AppSettings.Item("DatabasePath")

                '---Added Database Name, Path, and Password in App.Config
                strIQPQOQDataBaseName = objConfig.AppSettings.Item("IQPQOQDatabaseName")
                strIQPQOQDatabasePassword = objConfig.AppSettings.Item("IQPQOQDatabasePassword")
                gobjIQOQPQ = New IQOQPQ.IQOQPQ.IQOQPQ
                AddHandler gobjIQOQPQ.Test_IQOQPQ_Attachment1, AddressOf IQOQPQ_Attachment1_Test_Clicked
                AddHandler gobjIQOQPQ.Test_IQOQPQ_AttachmentII, AddressOf IQOQPQ_AttachmentII_Test_Clicked
                AddHandler gobjIQOQPQ.Test_IQOQPQ_AttachmentIII, AddressOf IQOQPQ_AttachmentIII_Test_Clicked
                AddHandler gobjIQOQPQ.InstrumentType, AddressOf IQOQPQ_InstrumentType

                'addhandler gobjIQOQPQ. 
                '---For IQOQPQ Database name, Path and password
            End If

            '--- Writing to Activity Log
            If (gstructSettings.Enable21CFR = True) Then
                '--- Check for activity authentication
                If Not funcCheckActivityAuthentication(enumActivityAuthentication.IQOQPQ, gstructUserDetails.Access) Then
                    Return
                    Exit Sub
                End If
                gfuncInsertActivityLog(EnumModules.IQOQPQ, "IQOQPQ Accessed")
            End If


            Call gobjIQOQPQ.ShowIQOQPQ(strDatabasePath, strProvider, strIQPQOQDataBaseName, strUserName, strIQPQOQDatabasePassword)

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
            IsInIQOQPQ = False
            Me.Focus()
            '---------------------------------------------------------
        End Try

    End Sub
    Private Sub mnuAddUser_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : mnuAddUser_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To open the Add User form 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 25.12.06
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Dim frmAddUser As New frmAddUser
        Try
            frmAddUser.ShowDialog()

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
            tlbbtnExit.ResumeEvents()
            '---------------------------------------------------------
        End Try

    End Sub

    Private Sub mnuUserPermissions_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : mnuUserPermissions_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To open the User Permissions form 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 25.12.06
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Dim frmUserPermissions As New frmUserPermissions
        Try
            frmUserPermissions.ShowDialog()
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
            tlbbtnExit.ResumeEvents()
            '---------------------------------------------------------
        End Try

    End Sub

    Private Sub mnuActivityLog_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : mnuActivityLog_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To open the Activity Log form 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 25.12.06
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Dim frmActivityLog As New frmActivityLog
        Try
            frmActivityLog.ShowDialog()

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

    Private Sub mnuDeleteLog_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : mnuDeleteLog_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To open the Delete log form 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 25.12.06
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Dim frmDeleteLog As New frmDeleteLogs
        Try
            frmDeleteLog.ShowDialog()

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

    Private Sub mnuChangePassword_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : mnuChangePassword_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To open Change Password form
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 25.12.06
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Dim frmChangePassword As New frmChangePassword
        Try
            frmChangePassword.ShowDialog()
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

    Private Sub mnu21CFR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : mnu21CFR_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : Enable or disable 21 CFR
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 25.12.06
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Try
            If gstructSettings.Enable21CFR = True Then
                'mnu21CFR.Image.FromFile = Application.StartupPath & "\Images\Enable History.ico"
                mnu21CFR.Image = Image.FromFile(Application.StartupPath & "\" & "images\Enable History.ico")
                mnu21CFR.Text = "Enable History"
                gstructSettings.Enable21CFR = False
                '       Call gfuncSetEnable21CFRToINI(gstructApplicationSettings.Enable21CFR)
            Else
                mnu21CFR.Image = Image.FromFile(Application.StartupPath & "\" & "images\Disable History.ico")
                mnu21CFR.Text = "Disable History"
                gstructSettings.Enable21CFR = True
                '        Call gfuncSetEnable21CFRToINI(gstructApplicationSettings.Enable21CFR)
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

            '---------------------------------------------------------
        End Try

    End Sub

    Private Sub mnuPrintertype_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : mnuPrinterType_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To load the Printer type form
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 21.11.06
        ' Revisions             : 
        '=====================================================================
        Dim objfrmPrinterType As New frmPrinterType
        Dim objWait As New CWaitCursor
        Try
            '---to select printer type
            If gstructSettings.blnSelectColorPrinter = True Then
                objfrmPrinterType.rbColor.Checked = True
                objfrmPrinterType.rbNormal.Checked = False
            Else
                objfrmPrinterType.rbColor.Checked = False
                objfrmPrinterType.rbNormal.Checked = True
            End If

            If objfrmPrinterType.ShowDialog() = DialogResult.OK Then
                If objfrmPrinterType.rbColor.Checked = True Then
                    gstructSettings.blnSelectColorPrinter = True
                ElseIf objfrmPrinterType.rbNormal.Checked = True Then
                    gstructSettings.blnSelectColorPrinter = False
                End If
            End If
            gobjPageSetting.Color = gstructSettings.blnSelectColorPrinter
            objfrmPrinterType.Close()
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
            If Not objfrmPrinterType Is Nothing Then
                objfrmPrinterType.Dispose()
            End If
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub mnuPrinterSetup_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : mnuPrinterSetup_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To load the Printer setting form
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 27.01.07
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Dim objPageSetupDialog As New PageSetupDialog
        Dim objPrintDocument As New System.Drawing.Printing.PrintDocument
        Try
            objPageSetupDialog.Document = objPrintDocument
            If objPageSetupDialog.ShowDialog = DialogResult.OK Then
                gobjPageSetting = objPageSetupDialog.PageSettings
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
            If Not objPageSetupDialog Is Nothing Then
                objPageSetupDialog.Dispose()
            End If
            If Not objPrintDocument Is Nothing Then
                objPrintDocument.Dispose()
            End If
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub mnuHydrideMode_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuHydrideMode.Click
        '=====================================================================
        ' Procedure Name        : mnuHydrideMode_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To set or unset the Hydride Mode
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 22.01.07
        ' Revisions             : 2
        ' Revisions By          : Mangesh on 17-Mar-2007
        '=====================================================================
        Dim objWait As New CWaitCursor

        Try
            'Added By Pankaj on Sat 19 May 2007
            'check for 21 CFR
            If (gstructSettings.Enable21CFR = True) Then
                If Not funcCheckActivityAuthentication(enumActivityAuthentication.HydrideMode, gstructUserDetails.Access) Then  '28.3.2010 insted of accessories in enum hydride mode selected.
                    Exit Sub
                End If
                gfuncInsertActivityLog(EnumModules.Analysis, "Hydride Mode Accessed")
            End If
            '----------------
            mnuHydrideMode.CheckType = NETXP.Controls.Bars.ButtonItemCheckType.Checkmark
            'chrck for hydride mode
            If mnuHydrideMode.Checked = True Then
                mnuHydrideMode.Checked = False
                gobjInst.Hydride = False
                gstructSettings.HydrideMode = 0
                gobjfrmStatus.IsHydrideMode = False
                HydrideMode = False
            Else
                mnuHydrideMode.Checked = True
                gobjInst.Hydride = True
                HydrideMode = True
                gstructSettings.HydrideMode = 1
                gobjfrmStatus.IsHydrideMode = True
                gobjMessageAdapter.ShowMessage("HYDRIDE MODE", "CONFIGURATION", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage)
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
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub mnuFilterOn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFilterOn.Click
        '=====================================================================
        ' Procedure Name        : mnuFilterOn_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To load the Printer type form
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 22.01.07
        ' Revisions             : 
        '=====================================================================

        Dim objWait As New CWaitCursor
        Try
            '---to enable or disable filter
            mnuFilterOn.CheckType = NETXP.Controls.Bars.ButtonItemCheckType.Checkmark
            'check for filter
            If mnuFilterOn.Checked = True Then
                mnuFilterOn.Checked = False
                gobjClsAAS203.funcEnableDisableFilter(False)
                'mnuFilterOn.Text = "Filster Off"
                mnuFilterOn.Text = "Filter On (201)"
            Else
                mnuFilterOn.Checked = True
                gobjClsAAS203.funcEnableDisableFilter(True)
                'mnuFilterOn.Text = "Filter On (201)"
                mnuFilterOn.Text = "Filter Off"
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
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If

        End Try
    End Sub

    Private Sub mnuEnableAutoSAmpler_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuEnableAutoSAmpler.Click
        '=====================================================================
        ' Procedure Name        : mnuEnableAutoSAmpler_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To set AutoSampler Enable/ Disable
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 22.01.07
        ' Revisions             : 
        '=====================================================================

        Dim objWait As New CWaitCursor
        Try
            'Added By Pankaj on Sat 19 May 2007
            'check for 21CFR
            If (gstructSettings.Enable21CFR = True) Then
                If Not funcCheckActivityAuthentication(enumActivityAuthentication.Accessories, gstructUserDetails.Access) Then
                    Exit Sub
                End If
                gfuncInsertActivityLog(EnumModules.Analysis, "Enable Auto Sampler Accessed")
            End If

            '---to enable or disable autosampler
            ''by Pankaj for autosampler on 10Sep 07
            If (gstructAutoSampler.blnAutoSamplerInitialised = False) Then
                mnuEnableAutoSAmpler.Text = "Disable Autosampler"
                gstructAutoSampler.blnAutoSamplerInitialised = True
                gFuncInitSampler(gstructAutoSampler)
            Else
                mnuEnableAutoSAmpler.Text = "Enable Autosampler"
                gstructAutoSampler.blnAutoSamplerInitialised = False
                gobjCommProtocol.mobjCommdll.gFuncCloseComm2()
            End If
            mnuCheckSamplerFunctions.Enabled = gstructAutoSampler.blnAutoSamplerInitialised
            'gfuncWriteAutoSamplerFlag()

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

    Private Sub mnuSetAbsorbanceThreshold_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuSetAbsorbanceThreshold.Click
        '=====================================================================
        ' Procedure Name        : mnuSetAbsorbanceThreshold_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To open absorbance threshold form. 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 22.01.07
        ' Revisions             : 
        '=====================================================================

        Dim objfrmThreshold As New frmThreshold
        Dim objWait As New CWaitCursor
        Try
            '---display absorbance threshold value
            objfrmThreshold.txtThresholdValue.Text = gstructSettings.AbsThresholdValue

            If objfrmThreshold.ShowDialog() = DialogResult.OK Then

                gstructSettings.AbsThresholdValue = objfrmThreshold.txtThresholdValue.Text

            End If
            objfrmThreshold.Close()
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

            If Not objfrmThreshold Is Nothing Then
                objfrmThreshold.Dispose()
            End If

            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub mnuManualFlame_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : mnuManualIgnition_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To load the ManualIgnition form
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 27.11.06
        ' Revisions             : Sachin Dokhale 
        '=====================================================================
        Dim objfrmManualIgnition As New frmManualIgnition
        Dim objWait As New CWaitCursor

        Try
            '---to display manual flame form
            'RemoveHandler mnuManualFlame.Click, AddressOf mnuManualFlame_Click
            'If Not gstructSettings.AppMode = EnumAppMode.DemoMode Or _
            'Not gstructSettings.AppMode = EnumAppMode.DemoMode_201 Or _
            'Not gstructSettings.AppMode = EnumAppMode.DemoMode_203D Then
            '---stop aspiration thread
            If Not IsNothing(mobjfrmAnalysis) Then
                If Not IsNothing(mobjfrmAnalysis.mobjBgMsgAspirate) Then
                    If mobjfrmAnalysis.IsDisplayingMessage = True Then
                        mobjfrmAnalysis.mobjBgMsgAspirate.Cancel()
                    End If
                End If
            End If
            gobjclsTimer.subTimerStop()
            mobjController.Cancel()
            gobjCommProtocol.mobjCommdll.subTime_Delay(1000)   '10.12.07
            Application.DoEvents()
            'If Not objWait Is Nothing Then
            '    objWait.Dispose()
            'End If
            Application.DoEvents()

            ' code added by : dinesh wagh on 22.3.2009
            ' code start
            If gstructSettings.AppMode = EnumAppMode.DemoMode_201 Or _
                gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
                objfrmManualIgnition.Width = objfrmManualIgnition.Width - 175
                objfrmManualIgnition.StartPosition = FormStartPosition.CenterScreen
            End If
            '........code ends.

            objfrmManualIgnition.ShowDialog()
            'Else
            '    Call gobjMessageAdapter.ShowMessage("Manual Flame", "Manual Flame", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage)
            'End If

            gobjclsTimer.subTimerStart(StatusBar1)
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
            If Not gstructSettings.AppMode = EnumAppMode.DemoMode Then
                '---start aspiration thread
                If Not IsNothing(mobjfrmAnalysis) Then
                    If Not IsNothing(mobjfrmAnalysis.mobjBgMsgAspirate) Then
                        If mobjfrmAnalysis.IsDisplayingMessage = True Then
                            mobjfrmAnalysis.mobjBgMsgAspirate.Start()
                        End If
                    End If
                End If
                '---start flame status thread
                If gobjMain.mobjController.IsThreadRunning = False Then '10.12.07
                    gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay)
                    Application.DoEvents()
                    mobjController.Start(gobjclsBgFlameStatus)
                End If
                Application.DoEvents()
            End If
            'AddHandler mnuManualFlame.Click, AddressOf mnuManualFlame_Click
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If

        End Try
    End Sub

    Private Sub btnStopAspiration_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : btnStopAspiration_Click
        ' Parameters Passed     : Object, EventArgs
        ' Returns               : None
        ' Purpose               : To stop the aspiration when the Measurement
        '                         mode of Method is PeakArea or PeakHeight
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 03-Apr-2007 06:45 pm
        ' Revisions             : 1
        '=====================================================================
        Try
            If Not IsNothing(mobjfrmAnalysis) Then
                If Not IsNothing(mobjfrmAnalysis.mobjBgReadData) Then
                    mobjfrmAnalysis.mobjBgReadData.IsAlt_S_Pressed = True
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
            '---------------------------------------------------------
        End Try
    End Sub

    Private Function ShutDownApplication() As Boolean
        '=====================================================================
        ' Procedure Name        : ShutDownApplication
        ' Parameters Passed     : None
        ' Returns               : True or false
        ' Purpose               : 
        ' Description           : to shut down the application by
        '                         stopping all running threads, release resources and free memory
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 17-Jan-2007 03:25 pm
        ' Revisions             : 1
        '=====================================================================
        Try
            'If (InAnalysis) Then
            '{
            '	MessageBox(hwnd,"Analysis under progress","PROTECTION",MB_ICONSTOP|MB_OK);
            '	break;
            '}
            If Not IsNothing(mobjfrmAnalysis) Then
                If mobjfrmAnalysis.InAnalysis Then
                    Call gobjMessageAdapter.ShowMessage(constAnalysisUnderProgress)
                    Application.DoEvents()
                    Return False
                    Exit Function
                End If
            End If

            If gobjMessageAdapter.ShowMessage(constExit) = True Then
                Application.DoEvents()

                'Call mobjTimerToCheckFlame.Stop()

                '---dispose data files form
                If Not IsNothing(mobjfrmDataFiles) Then
                    mobjfrmDataFiles.Close()
                    mobjfrmDataFiles.Dispose()
                    mobjfrmDataFiles = Nothing
                End If

                '---stop aspiration thread
                If Not IsNothing(mobjfrmAnalysis) Then
                    If Not IsNothing(mobjfrmAnalysis.mobjBgMsgAspirate) Then
                        If mobjfrmAnalysis.IsDisplayingMessage = True Then
                            mobjfrmAnalysis.mobjBgMsgAspirate.Cancel()
                        End If
                    End If
                End If
                '---dispose analysis form
                If Not IsNothing(mobjfrmAnalysis) Then
                    mobjfrmAnalysis.Close()
                    mobjfrmAnalysis.Dispose()
                    mobjfrmAnalysis = Nothing
                End If
                '---dispose method form
                If Not IsNothing(mobjfrmMethod) Then
                    mobjfrmMethod.Close()
                    mobjfrmMethod.Dispose()
                    mobjfrmMethod = Nothing
                End If
                '---stop global timer for clock 
                If Not (gobjclsTimer Is Nothing) Then
                    gobjclsTimer.subTimerStop()
                End If

                '---stop flame status thread
                mobjController.Cancel()
                Call gobjCommProtocol.mobjCommdll.subTime_Delay(1000)
                Application.DoEvents()
                mobjController = Nothing
                Call gobjCommProtocol.mobjCommdll.subTime_Delay(1000)
                Application.DoEvents()
                '---Shut_Down Instrument
                '#If !GRAPHITE Then
                '   Flame_Off();
                '#Else
                '	gSerialClose();
                '#End If

                'If (ReadIniForD2Gain()) Then
                '   GainX10Off()
                'end if
                'If (ReadIniForMesh()) Then
                '   SetMicroOff()
                'end if

                '---set all lamps off
                '---set pmt as 0.0
                '---reset instrument
                '---close the comm port
                If gobjCommProtocol.mobjCommdll.gFuncIsPortOpen() Then
                    Call gobjCommProtocol.funcAll_Lamp_Off()
                    Call gobjCommProtocol.funcSet_PMT(0.0)
                    '//----- Added by Sachin Dokhale 
                    '//----- Flame Off the instrument at time of exit from application if is ignited
                    gobjCommProtocol.funcResetInstrument()
                    'gobjCommProtocol.funcResetInstrument()
                    '//----
                    Call gobjCommProtocol.mobjCommdll.gFuncCloseComm()
                    gobjCommProtocol.mobjCommdllAutoSampler.gFuncCloseComm2()
                End If
                'BH_File_save()

                mblnIsApplicationClosed = True
                Me.DialogResult = DialogResult.OK
                Me.Close()
                Me.Dispose()

                Application.DoEvents()
                Application.Exit()

                Return True
            Else
                Return False
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

    Private Sub mobjfrmMethod_LoadedMethodChanged() Handles mobjfrmMethod.LoadedMethodChanged
        '=====================================================================
        ' Procedure Name        : mobjfrmMethod_LoadedMethodChanged
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : To load the Analysis again for New Method
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 15-Mar-2007 09:15 pm
        ' Revisions             : 1
        '=====================================================================
        Try
            '---dispose existing analysis form
            If Not IsNothing(mobjfrmAnalysis) Then
                mobjfrmAnalysis.Close()
                mobjfrmAnalysis.Dispose()
                mobjfrmAnalysis = Nothing
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

    Public Sub subStartFlameStatusThread()
        '=====================================================================
        ' Procedure Name        : subStartFlameStatusThread
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : To start flame status thread 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 15-Mar-2007 09:15 pm
        ' Revisions             : 1
        '=====================================================================
        Try
            '---start flame status thread
            mobjController = New clsBgThread(Me)

            gobjclsBgFlameStatus = New clsBgFlameStatus
            gobjclsBgFlameStatus.Initialize(mobjController)
            gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay)   '10.12.07
            Application.DoEvents()
            mobjController.Start(gobjclsBgFlameStatus)

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

    Private Sub mnuSingleBeam_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : mnuSingleBeam_Click
        ' Parameters Passed     : Object, EventArgs
        ' Returns               : None
        ' Purpose               : To change the Beam type to Single or Double 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 13-Apr-2007 06:35 pm
        ' Revisions             : 1
        '=====================================================================
        Try
            '---to change beam type
            If Not gintInstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.SingleBeam Then
                Call gobjClsAAS203.funcSelectDoubleBeamType(False)
            End If
            mnuDoubleBeam.Checked = False
            mnuSingleBeam.Checked = True
            mnuDoubleBeam.DefaultItem = False
            mnuSingleBeam.DefaultItem = True
            If gstructSettings.AppMode = EnumAppMode.FullVersion_203D Then
                mnuUVSpectrum.Enabled = True
                If gintInstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.SingleBeam Then
                    gobjInst.PmtVoltageReference = 0.0
                End If
            Else
                mnuUVSpectrum.Enabled = True
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

    Private Sub mnuDoubleBeam_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : mnuDoubleBeam_Click
        ' Parameters Passed     : Object, EventArgs
        ' Returns               : None
        ' Purpose               : To change the Beam type to Single or Double 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 13-Apr-2007 06:35 pm
        ' Revisions             : 1
        '=====================================================================
        Try
            '---to change beam type
            If Not gintInstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.DoubleBeam Then
                Call gobjClsAAS203.funcSelectDoubleBeamType(True)
            End If
            mnuSingleBeam.Checked = False
            mnuDoubleBeam.Checked = True
            mnuDoubleBeam.DefaultItem = True
            mnuSingleBeam.DefaultItem = False
            If gstructSettings.AppMode = EnumAppMode.FullVersion_203D Then
                mnuUVSpectrum.Enabled = True
            Else
                mnuUVSpectrum.Enabled = True
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

    Private Sub mnuLampPosition_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim objFrmTurret As New frmTurretElements
        objFrmTurret.ShowDialog()
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

            'StatusBarPanelInfo.Text = message
            If gblnShowThreadOnfrmMDIStatusBar Then
                StatusBarPanelInfo.Text = StatusBarPanelInfo.Text & " " & message
            Else
                StatusBarPanelInfo.Text = message
            End If
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
        ' Procedure Name        : ShowRunTimeInfo
        ' Parameters Passed     : message
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
            'ProgressPanel.Value = 20
            If gblnShowThreadOnfrmMDIStatusBar Then
                StatusBarPanelInfo.Text = StatusBarPanelInfo.Text & " " & message
            Else
                StatusBarPanelInfo.Text = message
            End If
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

#Region " Background Thread IClient Implementation Functions "

    Public Sub Completed(ByVal Cancelled As Boolean) Implements BgThread.Iclient.Completed
        '''---Temporarily ...
        ''Call gobjMessageAdapter.ShowStatusMessageBox("Flame Status Thread Stopped.", "Flame Status", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage, 1000)
        ''Application.DoEvents()
        ''Call gobjMessageAdapter.CloseStatusMessageBox()
        ''Application.DoEvents()
        '''---Temporarily ...
    End Sub

    Public Sub Display(ByVal Text As String) Implements BgThread.Iclient.Display
        '=====================================================================
        ' Procedure Name        : Display
        ' Parameters Passed     : message
        ' Returns               : None
        ' Purpose               :  to display flame type
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : Saturday, January 22, 2005
        ' Revisions             : 
        '=====================================================================
        Try
            '---to display flame type
            gobjfrmStatus.FlameType = CInt(Text)
            If IsNumeric(CInt(Text)) = True Then
                IgniteType = CInt(Text)
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

    Public Sub Failed(ByVal e As System.Exception) Implements BgThread.Iclient.Failed
        '---Temporarily ...
        'MessageBox.Show("Flame Status Thread Failed.", "Flame Status")
        '---Temporarily ...
    End Sub

    Public Sub Start(ByVal clsBgThread As BgThread.clsBgThread) Implements BgThread.Iclient.Start
    End Sub

#End Region

#Region " Global Functions"

    Public Function AutoIgnition() As Boolean
        '=====================================================================
        ' Procedure Name        : AutoIgnition
        ' Parameters Passed     : Object, EventArgs
        ' Returns               : None
        ' Purpose               : 
        ' Description           : to auto ignite the flame
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 18-Feb-2007 03:15 pm
        ' Revisions             : 1
        '=====================================================================
        Try
            If Not gstructSettings.AppMode = EnumAppMode.DemoMode Then
                If Not IsNothing(mobjfrmAnalysis) Then mobjfrmAnalysis.tmrAspirationMsg.Enabled = False
                Call mobjController.Cancel()
                Call gobjCommProtocol.mobjCommdll.subTime_Delay(100)
                Call Application.DoEvents()
                '---auto ignite the flame
                Call gobjClsAAS203.funcIgnite(True)

            Else
                Call gobjMessageAdapter.ShowMessage(constFlameIgnited)
                Call Application.DoEvents()
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
            If Not gstructSettings.AppMode = EnumAppMode.DemoMode Then
                If Not IsNothing(mobjfrmAnalysis) Then mobjfrmAnalysis.tmrAspirationMsg.Enabled = True
                If gobjMain.mobjController.IsThreadRunning = False Then '10.12.07
                    gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay)
                    Application.DoEvents()
                    mobjController.Start(gobjclsBgFlameStatus)
                End If
                Application.DoEvents()
            End If
            '---------------------------------------------------------
        End Try
    End Function

    Public Function Extinguish() As Boolean
        '=====================================================================
        ' Procedure Name        : btnExtinguish_Click
        ' Parameters Passed     : Object, EventArgs
        ' Returns               : None
        ' Purpose               : 
        ' Description           : To extinguish the flame
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 18-Feb-2007 03:15 pm
        ' Revisions             : 1
        '=====================================================================
        Try
            If Not gstructSettings.AppMode = EnumAppMode.DemoMode Then
                If Not IsNothing(mobjfrmAnalysis) Then mobjfrmAnalysis.tmrAspirationMsg.Enabled = False
                mobjController.Cancel()
                Call gobjCommProtocol.mobjCommdll.subTime_Delay(100)
                Application.DoEvents()
                '---To extinguish the flame
                Call gobjClsAAS203.funcIgnite(False)
            Else
                Call gobjMessageAdapter.ShowMessage(constFlameExtinguished)
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
            If Not gstructSettings.AppMode = EnumAppMode.DemoMode Then
                If Not IsNothing(mobjfrmAnalysis) Then mobjfrmAnalysis.tmrAspirationMsg.Enabled = True
                If gobjMain.mobjController.IsThreadRunning = False Then '10.12.07
                    gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay)
                    Application.DoEvents()
                    mobjController.Start(gobjclsBgFlameStatus)
                End If
                Application.DoEvents()
            End If
            '---------------------------------------------------------
        End Try
    End Function

    Public Function N2OAutoIgnition() As Boolean
        '=====================================================================
        ' Procedure Name        : N2oAutoIgnition
        ' Parameters Passed     : Object, EventArgs
        ' Returns               : None
        ' Purpose               : 
        ' Description           : to switch over from aa flame to N2O flame
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 18-Aug-2007 03:15 pm
        ' Revisions             : 1
        '=====================================================================
        Try
            If Not gstructSettings.AppMode = EnumAppMode.DemoMode Then
                If Not IsNothing(mobjfrmAnalysis) Then mobjfrmAnalysis.tmrAspirationMsg.Enabled = False
                Call mobjController.Cancel()
                Call gobjCommProtocol.mobjCommdll.subTime_Delay(1000)
                Application.DoEvents()
                '---switch over to N2O flame
                Call gobjCommProtocol.funcSwitchOver()
            Else
                Call gobjMessageAdapter.ShowMessage(constFlameIgnited)
                Call Application.DoEvents()
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
            If Not gstructSettings.AppMode = EnumAppMode.DemoMode Then
                If Not IsNothing(mobjfrmAnalysis) Then mobjfrmAnalysis.tmrAspirationMsg.Enabled = True
                If gobjMain.mobjController.IsThreadRunning = False Then '10.12.07
                    gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay)
                    Application.DoEvents()
                    mobjController.Start(gobjclsBgFlameStatus)
                End If
                Application.DoEvents()
            End If
            '---------------------------------------------------------
        End Try
    End Function

    Public Function funcAltDelete() As Boolean
        '=====================================================================
        ' Procedure Name        : funcAltDelete
        ' Parameters Passed     : Object, EventArgs
        ' Returns               : None
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 18-Dec-2007 03:15 pm
        ' Revisions             : 1
        '=====================================================================
        Try
            If Not gstructSettings.AppMode = EnumAppMode.DemoMode Then
                If Not IsNothing(mobjfrmAnalysis) Then mobjfrmAnalysis.tmrAspirationMsg.Enabled = False
                Call mobjController.Cancel()
                Call gobjCommProtocol.mobjCommdll.subTime_Delay(1000)
                Application.DoEvents()
                '---switch over to N2O flame
                gobjClsAAS203.ReInitInstParameters()
            Else
                'Call gobjMessageAdapter.ShowMessage("Alt - Delete", "Alt - Delete")
                Call Application.DoEvents()
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
            If Not gstructSettings.AppMode = EnumAppMode.DemoMode Then
                If Not IsNothing(mobjfrmAnalysis) Then mobjfrmAnalysis.tmrAspirationMsg.Enabled = True
                If gobjMain.mobjController.IsThreadRunning = False Then '10.12.07
                    gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay)
                    Application.DoEvents()
                    mobjController.Start(gobjclsBgFlameStatus)
                End If
                Application.DoEvents()
            End If
            '---------------------------------------------------------
        End Try
    End Function

    Public Function funcAltR() As Boolean
        '=====================================================================
        ' Procedure Name        : funcAltR
        ' Parameters Passed     : Object, EventArgs
        ' Returns               : None
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 18-Dec-2007 03:15 pm
        ' Revisions             : 1
        '=====================================================================
        Try
            If Not gstructSettings.AppMode = EnumAppMode.DemoMode Then
                If Not IsNothing(mobjfrmAnalysis) Then mobjfrmAnalysis.tmrAspirationMsg.Enabled = False
                Call mobjController.Cancel()
                Call gobjCommProtocol.mobjCommdll.subTime_Delay(1000)
                Application.DoEvents()
                Call gobjClsAAS203.funcInstReset()
            Else
                'Call gobjMessageAdapter.ShowMessage("Alt - R", "Alt - R")
                Call Application.DoEvents()
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
            If Not gstructSettings.AppMode = EnumAppMode.DemoMode Then
                If Not IsNothing(mobjfrmAnalysis) Then mobjfrmAnalysis.tmrAspirationMsg.Enabled = True
                If gobjMain.mobjController.IsThreadRunning = False Then '10.12.07
                    gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay)
                    Application.DoEvents()
                    mobjController.Start(gobjclsBgFlameStatus)
                End If
                Application.DoEvents()
            End If
            '---------------------------------------------------------
        End Try
    End Function

#End Region

    Private Sub btnIgnite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : btnIgnite_Click
        ' Parameters Passed     : Object, EventArgs
        ' Returns               : None
        ' Purpose               : 
        ' Description           : to auto ignite the flame
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 18-Aug-2007 03:15 pm
        ' Revisions             : 0
        '=====================================================================
        Try
            If mblnAvoidProcessing = True Then
                Exit Sub
            End If
            mblnAvoidProcessing = True
            Call AutoIgnition()
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

    Private Sub btnExtinguish_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : btnExtinguish_Click
        ' Parameters Passed     : Object, EventArgs
        ' Returns               : None
        ' Purpose               : 
        ' Description           : to extinguish the flame
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 18-Aug-2007 03:15 pm
        ' Revisions             : 0
        '=====================================================================
        Try
            If mblnAvoidProcessing = True Then
                Exit Sub
            End If
            mblnAvoidProcessing = True
            Call Extinguish()
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

    Private Sub btnN2OIgnite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : btnN2OIgnite_Click
        ' Parameters Passed     : Object, EventArgs
        ' Returns               : None
        ' Purpose               : 
        ' Description           : to N2O auto ignition
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 18-Aug-2007 03:15 pm
        ' Revisions             : 0
        '=====================================================================
        Try
            If mblnAvoidProcessing = True Then
                Exit Sub
            End If
            mblnAvoidProcessing = True
            Call N2OAutoIgnition()
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
            Call funcAltDelete()
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
            Call funcAltR()
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

#Region " IQOQPQ Test Attachments"

    Private Sub IQOQPQ_Attachment1_Test_Clicked(ByRef dtParameters As DataTable, ByVal intCounter As Integer)
        '=====================================================================
        ' Procedure Name        : IQOQPQ_Attachment1_Test_Clicked
        ' Parameters Passed     : intCounter - To give the Serial No.
        ' Returns               : dtParameters - Data table to return parameters
        ' Purpose               : To perform the test for IQOQPQ Attachment 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 05.07.07
        ' Revisions             : Deepak B.
        '=====================================================================
        Dim objDrNewRow As DataRow
        'Dim objDataRow As DataRow
        Dim intCount As Integer = 0
        Dim mobjTmpDt As New DataTable

        'Purpose : flag is added to check whether method is created sucessfully or not if at any 
        'part of method creation use cancel the process then no row is added in datagrid.
        Dim blnIsMethodCreated As Boolean = False '22.1.2010 by dinesh wagh '

        Try

            'Test_IQOQPQ_Attachment1() 'commented by : dinesh wagh on 22.1.2010
            Test_IQOQPQ_Attachment1(blnIsMethodCreated) 'code added by : dinesh wagh on 22.1.2010

            If blnIsMethodCreated = True Then 'only if condition added by  : dinesh wagh on 22.1.2010

                '----------------------------------------------
                'added by : dinesh wagh on 2.2.2010
                '------------------------------------
                'as analysis is completed , flame should be extinguish.
                gobjMessageAdapter.ShowMessage("Extinguishing flame.", "Note", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage)
                gobjClsAAS203.funcIgnite(False)
                '-------------------------------

                'Purpose : if new method is added then only create new row otherwise datagrid should be blank.
                objDrNewRow = dtParameters.NewRow()
                objDrNewRow("SampleID") = CInt(intCounter)
                objDrNewRow("LampCurrent") = Format(CDbl(gobjInst.Current), "0.0")
                objDrNewRow("PMTVoltage") = Format(CDbl(gobjInst.PmtVoltage), "0.0")
                objDrNewRow("Wavelength") = Format(CDbl(gobjInst.WavelengthCur), "0.0")
                objDrNewRow("SlitWidth") = Format(CDbl((80.0 - CDbl(gobjInst.SlitPosition)) / 40), "0.0")
                objDrNewRow("BurnerHeight") = Format(gobjInst.BhStep / (200.0 * BHRATIO), "0.0")
                objDrNewRow("Fuel") = Format(CDbl(gobjClsAAS203.funcRead_Fuel), "0.00")
                objDrNewRow("Absorbance") = Format(CDbl(gDblAbsValue_IQOQPQ_Attachment1), "0.000")
                objDrNewRow("Remark") = "OK"
                objDrNewRow("Date") = Format(CDate(Date.Today), "d-MMMM-yy")
                'objDrNewRow("TestID") = CInt(intCounter)
                dtParameters.Rows.Add(objDrNewRow)
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
            'objWait.Dispose()
            '---------------------------------------------------------
        End Try

    End Sub

    Private Sub IQOQPQ_AttachmentII_Test_Clicked(ByRef dtParameters As DataTable, ByVal intCounter As Integer)
        '=====================================================================
        ' Procedure Name        : IQOQPQ_Attachment1_Test_Clicked
        ' Parameters Passed     : intCounter - To give the Serial No.
        ' Returns               : dtParameters - Data table to return parameters
        ' Purpose               : To perform the test for IQOQPQ Attachment 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 05.07.07
        ' Revisions             : Deepak B.
        '=====================================================================
        Dim objDrNewRow As DataRow
        'Dim objDataRow As DataRow
        Dim intCount As Integer = 0
        Dim mobjTmpDt As New DataTable
        Dim dblStdAbs As Double
        Dim dblStdAbs1 As Double
        Try
            gobjMessageAdapter.ShowMessage("Please Note: Enter the concentration value in the Standard Concentration form that you are going" _
            & " to use while performing the test.", "Test 2", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage)
            Application.DoEvents()

            'MsgBox("Please Note: Enter the concentration value in the Standard Concentration form that you are going" _
            '& " to use while performing the test.", MsgBoxStyle.Information, "Reminder")

            Test_IQOQPQ_AttachmentII(EnumIQOQPQtestId.ePQ2)

            'code added by ; dinesh wagh on 2.2.2010
            '-----------------------------------
            If gobjNewMethod Is Nothing Then
                Exit Sub
            End If
            '---------------------------------------

            If gobjNewMethod.QuantitativeDataCollection.Count > 0 Then

                'added by : dinesh wagh on 2.2.2010
                '------------------------------------
                'as analysis is completed , flame should be extinguish.
                gobjMessageAdapter.ShowMessage("Extinguishing flame.", "Note", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage)
                gobjClsAAS203.funcIgnite(False)
                '-------------------------------

                dblStdAbs = gobjNewMethod.QuantitativeDataCollection(0).StandardDataCollection(0).Abs

                For intCount = 0 To gobjNewMethod.QuantitativeDataCollection(0).SampleDataCollection.Count - 1
                    objDrNewRow = dtParameters.NewRow()

                    'objDrNewRow("SampleID") = CInt(intCount + 1) 'by dinesh wagh on 27.1.2010 'causes error log.
                    objDrNewRow("Repeat No") = CInt(intCount + 1) 'by dinesh wagh on 27.1.2010

                    If gobjNewMethod.QuantitativeDataCollection(0).SampleDataCollection.item(intCount).Abs = -1.0 Then
                        objDrNewRow("Absorbance") = ""
                        objDrNewRow("Deviation") = ""
                    Else
                        objDrNewRow("Absorbance") = Format(gobjNewMethod.QuantitativeDataCollection(0).SampleDataCollection.item(intCount).Abs, "0.000")
                        objDrNewRow("Deviation") = Format(dblStdAbs - gobjNewMethod.QuantitativeDataCollection(0).SampleDataCollection.item(intCount).Abs, "0.000")
                    End If
                    dtParameters.Rows.Add(objDrNewRow)
                Next


                'code added by ; dinesh wagh on 28.1.2010
                'purpose : to display edit data screen.
                '----------------------------------------------
                Dim objfrmDeleteStdNSam As frmDeleteStdNSam
                Dim objfrmViewRepeatResults As frmViewRepeatResults

                If ((gobjNewMethod.QuantitativeDataCollection.Item(0).AnalysisParameters.NumOfSampleRepeats > 1 _
                  Or gobjNewMethod.QuantitativeDataCollection.Item(0).AnalysisParameters.NumOfStdRepeats > 1) _
                  And clsStandardGraph.FindSamplesAnalysed(gobjNewMethod, 0) >= 1) Then
                    objfrmViewRepeatResults = New frmViewRepeatResults(gobjNewMethod, 0)
                    objfrmViewRepeatResults.ShowDialog()
                    Application.DoEvents()
                    objfrmViewRepeatResults.Close()
                    objfrmViewRepeatResults.Dispose()
                    objfrmViewRepeatResults = Nothing
                Else
                    objfrmDeleteStdNSam = New frmDeleteStdNSam(gobjNewMethod, 0)
                    If objfrmDeleteStdNSam.ShowDialog() = DialogResult.OK Then
                        gobjclsStandardGraph = New clsStandardGraph
                        Call gobjclsStandardGraph.Create_Standard_Sample_Curve(True, False, gobjNewMethod.MethodID, gobjNewMethod.QuantitativeDataCollection.Count - 1, gobjNewMethod)
                    End If
                    Application.DoEvents()
                    objfrmDeleteStdNSam.Close()
                    objfrmDeleteStdNSam.Dispose()
                    objfrmDeleteStdNSam = Nothing
                End If
                '----------------------------------------------

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
            'objWait.Dispose()
            '---------------------------------------------------------
        End Try

    End Sub

    Private Sub IQOQPQ_AttachmentIII_Test_Clicked(ByRef dtParameters As DataTable, ByVal intCounter As Integer)
        '=====================================================================
        ' Procedure Name        : IQOQPQ_Attachment1_Test_Clicked
        ' Parameters Passed     : intCounter - To give the Serial No.
        ' Returns               : dtParameters - Data table to return parameters
        ' Purpose               : To perform the test for IQOQPQ Attachment 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 05.07.07
        ' Revisions             : Deepak B.
        '=====================================================================
        Dim objDrNewRow As DataRow
        Dim intCount As Integer = 0
        Dim mobjTmpDt As New DataTable
        Dim dblStdAbs As Double
        Dim dblStdAbs1 As Double
        Try

            'code commented by : dinesh wagh on 21.1.2010
            '----------------------------------------------------
            ''gobjMessageAdapter.ShowMessage("Please Note: Enter the concentration value in the Standard Concentration form that you are going" _
            ''& " to use while performing the test.", "Test 3", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage)
            '-----------------------------------------------------

            Application.DoEvents()

            Test_IQOQPQ_AttachmentII(EnumIQOQPQtestId.ePQ3) '5.4.2010


            If gobjNewMethod.QuantitativeDataCollection.Count > 0 Then

                'added by : dinesh wagh on 2.2.2010
                '------------------------------------
                'as analysis is completed , flame should be extinguish.
                gobjMessageAdapter.ShowMessage("Extinguishing flame.", "Note", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage)
                gobjClsAAS203.funcIgnite(False)
                '-------------------------------

                For intCount = 0 To gobjNewMethod.QuantitativeDataCollection(0).StandardDataCollection.Count - 1
                    objDrNewRow = dtParameters.NewRow()
                    'objDrNewRow("SampleID") = CInt(intCount + 1) 'code commented by : dinesh wagh on 22.1.2010
                    'code added by : dinesh wagh on 22.1.2010
                    '------------------------------
                    objDrNewRow("Standard No") = CInt(intCount + 1)
                    '-----------------------------------
                    objDrNewRow("Absorbance") = Format(gobjNewMethod.QuantitativeDataCollection(0).StandardDataCollection.item(intCount).Abs, "0.000")
                    objDrNewRow("Concentration") = Format(gobjNewMethod.QuantitativeDataCollection(0).StandardDataCollection.item(intCount).Concentration, "0.00")
                    dtParameters.Rows.Add(objDrNewRow)
                Next
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
            'objWait.Dispose()
            '---------------------------------------------------------
        End Try

    End Sub
    Private Sub Test_IQOQPQ_Attachment1(ByRef blnIsMethodCreated As Boolean)
        'parameter added by ; dinesh wgah on 22.1.2010 
        'Purpose to check wheter user accept all parameter and method is sucessfully created or not.

        '=====================================================================
        ' Procedure Name        : Test_IQOQPQ_Attachment1
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : To create new method to perform test in IQOQPQ Attachment1
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh Singh
        ' Created               : 04.07.07
        ' Revisions             : 
        '=====================================================================
        Dim objfrmNewMethod As New frmNewMethod
        Dim objfrmInstrParameters As frmInstrumentParameters
        Dim objfrmAnalysisParameters As frmMethodAnalysisParameters
        Dim objfrmStdParameters As frmStandardConcentration
        Dim objfrmSampleParameters As frmSampleParameters
        Dim objfrmReportOptions As frmReportOptions
        Dim objfrmUVQuantitativeAnalysis As frmUVQuantitativeAnalysis
        Dim objfrmEmissionMode As frmEmissionMode
        Dim objWait As New CWaitCursor

        Try
            objfrmNewMethod.cmbOperationMode.Enabled = False
            If objfrmNewMethod.ShowDialog() = DialogResult.OK Then

                OpenMethodMode = modGlobalConstants.EnumMethodMode.NewMode

                If Not gobjNewMethod Is Nothing Then

                    '---Enum Values Changed and Added by Mangesh on 23-Jan-2007
                    Select Case gobjNewMethod.OperationMode
                        Case EnumOperationMode.MODE_AA, EnumOperationMode.MODE_AABGC     '1, 3
                            objfrmInstrParameters = New frmInstrumentParameters(OpenMethodMode)
                            Application.DoEvents()
                            If objfrmInstrParameters.ShowDialog() = DialogResult.OK Then
                                '---do nothing & move forward to create new method
                            Else
                                gobjNewMethod.Status = False 'Added By Pankaj Thu 24 May 07
                                Exit Sub
                            End If

                        Case EnumOperationMode.MODE_UVABS   '2
                            objfrmUVQuantitativeAnalysis = New frmUVQuantitativeAnalysis(OpenMethodMode)
                            Application.DoEvents()
                            If objfrmUVQuantitativeAnalysis.ShowDialog() = DialogResult.OK Then
                                '---do nothing & move forward to create new method
                            Else
                                gobjNewMethod.Status = False 'Added By Pankaj Thu 24 May 07
                                Exit Sub
                            End If

                        Case EnumOperationMode.MODE_EMMISSION   '4
                            objfrmEmissionMode = New frmEmissionMode(OpenMethodMode)
                            Application.DoEvents()
                            If objfrmEmissionMode.ShowDialog() = DialogResult.OK Then
                                '---do nothing & move forward to create new method
                            Else
                                'Added By Pankaj Thu 24 May 07
                                gobjNewMethod.Status = False
                                '-----
                                Exit Sub
                            End If

                    End Select

                    objfrmAnalysisParameters = New frmMethodAnalysisParameters(OpenMethodMode)
                    Application.DoEvents()
                    If objfrmAnalysisParameters.ShowDialog() = DialogResult.OK Then

                        'objfrmStdParameters = New frmStandardConcentration 'commented by ; dinesh wagh on 2.2.2010
                        objfrmStdParameters = New frmStandardConcentration(EnumIQOQPQtestId.ePQAtt1)  'added by ; dinesh wagh on 2.2.2010



                        Application.DoEvents()
                        If objfrmStdParameters.ShowDialog() = DialogResult.OK Then

                            gobjNewMethod.Status = True 'Added By Pankaj 23 May 07 
                            objfrmSampleParameters = New frmSampleParameters(EnumMethodMode.NewMode)
                            Application.DoEvents()
                            If objfrmSampleParameters.ShowDialog() = DialogResult.OK Then

                                objfrmReportOptions = New frmReportOptions(EnumMethodMode.NewMode, False, 0, 0)
                                Application.DoEvents()
                                If objfrmReportOptions.ShowDialog() = DialogResult.OK Then

                                    '----Commented by Mangesh on 04-Apr-2007

                                    ''---add new method to method collection


                                    '---For Double Beam Added by Mangesh on 06-Apr-2007

                                    If gintInstrumentBeamType = enumInstrumentBeamType.DoubleBeam Then
                                        gobjNewMethod.InstrumentBeamType = enumInstrumentBeamType.DoubleBeam
                                    ElseIf gintInstrumentBeamType = enumInstrumentBeamType.SingleBeam Then
                                        gobjNewMethod.InstrumentBeamType = enumInstrumentBeamType.SingleBeam
                                    End If

                                    '------Added By Pankaj Thu 28 May 07
                                    gobjchkActiveMethod.NewMethod = False
                                    gobjchkActiveMethod.CancelMethod = False
                                    'gobjchkActiveMethod.fillInstruments = False  '27.07.07
                                    'gobjchkActiveMethod.fillParameters = False  '27.07.07
                                    gobjchkActiveMethod.fillStdConcentration = False
                                    Call gobjMethodCollection.Add(gobjNewMethod)

                                    ''---serialize method collection 
                                    Call funcSaveAllMethods(gobjMethodCollection)



                                    '----Added by Mangesh on 04-Apr-2007

                                    OpenMethodMode = modGlobalConstants.EnumMethodMode.EditMode


                                    '---display confirmation dialog box of method creation
                                    Call gobjMessageAdapter.ShowMessage(contMethodCreatedSuccessfully)
                                    blnIsMethodCreated = True 'code added by ;dinesh wagh on 22.1.2010

                                    Call Application.DoEvents()
                                    gIntMethodID = gobjNewMethod.MethodID


                                    '---START --- Added by Mangesh on 27-Feb-2007

                                    Call OnQuantAnalyse_IQOQPQ_Test_Attachment1()

                                    '---END  ---  Added by Mangesh on 27-Feb-2007

                                Else
                                End If
                            Else
                            End If
                        Else
                            gobjNewMethod.Status = False
                        End If
                    Else
                        gobjNewMethod.Status = False
                    End If
                Else
                    gobjNewMethod.Status = False
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
            'tlbbtnNewMethod.ResumeEvents()
            gobjfrmStatus.TopMost = True
            '---------------------------------------------------------
        End Try

    End Sub

    Private Sub Test_IQOQPQ_Attachment1()

        '=====================================================================
        ' Procedure Name        : Test_IQOQPQ_Attachment1
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : To create new method to perform test in IQOQPQ Attachment1
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh Singh
        ' Created               : 04.07.07
        ' Revisions             : 
        '=====================================================================
        Dim objfrmNewMethod As New frmNewMethod
        Dim objfrmInstrParameters As frmInstrumentParameters
        Dim objfrmAnalysisParameters As frmMethodAnalysisParameters
        Dim objfrmStdParameters As frmStandardConcentration
        Dim objfrmSampleParameters As frmSampleParameters
        Dim objfrmReportOptions As frmReportOptions
        Dim objfrmUVQuantitativeAnalysis As frmUVQuantitativeAnalysis
        Dim objfrmEmissionMode As frmEmissionMode
        Dim objWait As New CWaitCursor

        Try
            objfrmNewMethod.cmbOperationMode.Enabled = False
            If objfrmNewMethod.ShowDialog() = DialogResult.OK Then

                OpenMethodMode = modGlobalConstants.EnumMethodMode.NewMode

                If Not gobjNewMethod Is Nothing Then

                    '---Enum Values Changed and Added by Mangesh on 23-Jan-2007
                    Select Case gobjNewMethod.OperationMode
                        Case EnumOperationMode.MODE_AA, EnumOperationMode.MODE_AABGC     '1, 3
                            objfrmInstrParameters = New frmInstrumentParameters(OpenMethodMode)
                            Application.DoEvents()
                            If objfrmInstrParameters.ShowDialog() = DialogResult.OK Then
                                '---do nothing & move forward to create new method
                            Else
                                gobjNewMethod.Status = False 'Added By Pankaj Thu 24 May 07

                                Exit Sub

                            End If

                        Case EnumOperationMode.MODE_UVABS   '2
                            objfrmUVQuantitativeAnalysis = New frmUVQuantitativeAnalysis(OpenMethodMode)
                            Application.DoEvents()
                            If objfrmUVQuantitativeAnalysis.ShowDialog() = DialogResult.OK Then
                                '---do nothing & move forward to create new method
                            Else
                                gobjNewMethod.Status = False 'Added By Pankaj Thu 24 May 07
                                Exit Sub
                            End If

                        Case EnumOperationMode.MODE_EMMISSION   '4
                            objfrmEmissionMode = New frmEmissionMode(OpenMethodMode)
                            Application.DoEvents()
                            If objfrmEmissionMode.ShowDialog() = DialogResult.OK Then
                                '---do nothing & move forward to create new method
                            Else
                                'Added By Pankaj Thu 24 May 07
                                gobjNewMethod.Status = False
                                '-----
                                Exit Sub
                            End If

                    End Select

                    objfrmAnalysisParameters = New frmMethodAnalysisParameters(OpenMethodMode)
                    Application.DoEvents()
                    If objfrmAnalysisParameters.ShowDialog() = DialogResult.OK Then

                        objfrmStdParameters = New frmStandardConcentration
                        Application.DoEvents()
                        If objfrmStdParameters.ShowDialog() = DialogResult.OK Then
                            gobjNewMethod.Status = True 'Added By Pankaj 23 May 07 
                            objfrmSampleParameters = New frmSampleParameters(EnumMethodMode.NewMode)
                            Application.DoEvents()
                            If objfrmSampleParameters.ShowDialog() = DialogResult.OK Then

                                objfrmReportOptions = New frmReportOptions(EnumMethodMode.NewMode, False, 0, 0)
                                Application.DoEvents()
                                If objfrmReportOptions.ShowDialog() = DialogResult.OK Then


                                    '----Commented by Mangesh on 04-Apr-2007

                                    ''---add new method to method collection


                                    '---For Double Beam Added by Mangesh on 06-Apr-2007

                                    If gintInstrumentBeamType = enumInstrumentBeamType.DoubleBeam Then
                                        gobjNewMethod.InstrumentBeamType = enumInstrumentBeamType.DoubleBeam
                                    ElseIf gintInstrumentBeamType = enumInstrumentBeamType.SingleBeam Then
                                        gobjNewMethod.InstrumentBeamType = enumInstrumentBeamType.SingleBeam
                                    End If

                                    '------Added By Pankaj Thu 28 May 07
                                    gobjchkActiveMethod.NewMethod = False
                                    gobjchkActiveMethod.CancelMethod = False
                                    'gobjchkActiveMethod.fillInstruments = False  '27.07.07
                                    'gobjchkActiveMethod.fillParameters = False  '27.07.07
                                    gobjchkActiveMethod.fillStdConcentration = False
                                    Call gobjMethodCollection.Add(gobjNewMethod)

                                    ''---serialize method collection 
                                    Call funcSaveAllMethods(gobjMethodCollection)



                                    '----Added by Mangesh on 04-Apr-2007

                                    OpenMethodMode = modGlobalConstants.EnumMethodMode.EditMode


                                    '---display confirmation dialog box of method creation
                                    Call gobjMessageAdapter.ShowMessage(contMethodCreatedSuccessfully)
                                    Call Application.DoEvents()
                                    gIntMethodID = gobjNewMethod.MethodID


                                    '---START --- Added by Mangesh on 27-Feb-2007

                                    Call OnQuantAnalyse_IQOQPQ_Test_Attachment1()

                                    '---END  ---  Added by Mangesh on 27-Feb-2007

                                Else

                                End If
                            Else

                            End If
                        Else
                            gobjNewMethod.Status = False
                        End If
                    Else
                        gobjNewMethod.Status = False

                    End If
                Else
                    gobjNewMethod.Status = False

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
            'tlbbtnNewMethod.ResumeEvents()
            gobjfrmStatus.TopMost = True
            '---------------------------------------------------------
        End Try

    End Sub

    Public Sub OnQuantAnalyse_IQOQPQ_Test_Attachment1()
        '=====================================================================
        ' Procedure Name        : OnQuantAnalyse_IQOQPQ_Test_Attachment1
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 13-Feb-2007 12:15 pm
        ' Revisions             : 1
        '=====================================================================
        Dim mvalid As Integer
        Dim msgcount As Integer
        Dim msg As Message

        Try
            mvalid = CheckMethod_IQOQPQ_Test_Attachment1()
            If (mvalid = 0) Then
                Return
            End If
            If (mvalid = 2) Then
                If IsNothing(mobjfrmAnalysis) Then
                    Application.DoEvents()
                    mobjfrmAnalysis = New frmAnalysis
                Else
                End If
                If gstructSettings.AppMode = EnumAppMode.DemoMode Then
                    '---Don't perform Peak Latching operation for Demo Method
                Else
                    '---Search and Find Analytical Peak
                    Call mobjfrmAnalysis.CheckInstrumentOptimisation()
                End If
            ElseIf (mvalid = 1) Then
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

    Public Function CheckMethod_IQOQPQ_Test_Attachment1() As Integer
        '=====================================================================
        ' Procedure Name        : CheckMethod_IQOQPQ_Test_Attachment1
        ' Parameters Passed     : None
        ' Returns               : Status Value as Integer 
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 17-Jan-2007 03:25 pm
        ' Revisions             : 1
        '=====================================================================
        Try
            If (gobjNewMethod.MethodID >= 0) Then

                If clsStandardGraph.GetTotStds(gobjNewMethod.StandardDataCollection, False) > 0 Then
                    Return 2
                End If

            End If

            If (gobjNewMethod.MethodID > 0) Then
                Return 1
            End If

            Return 3

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

    Private Sub Test_IQOQPQ_AttachmentII(ByVal intAttachmentNo As Integer)
        '=====================================================================
        ' Procedure Name        : Test_IQOQPQ_AttachmentII
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : To create new method to perform test in IQOQPQ Attachment1
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh Singh
        ' Created               : 04.07.07
        ' Revisions             : 
        '=====================================================================
        Dim objfrmNewMethod As New frmNewMethod
        Dim objfrmInstrParameters As frmInstrumentParameters
        Dim objfrmAnalysisParameters As frmMethodAnalysisParameters
        Dim objfrmStdParameters As frmStandardConcentration
        Dim objfrmSampleParameters As frmSampleParameters
        Dim objfrmReportOptions As frmReportOptions
        Dim objfrmUVQuantitativeAnalysis As frmUVQuantitativeAnalysis
        Dim objfrmEmissionMode As frmEmissionMode
        Dim objWait As New CWaitCursor

        Try
            objfrmNewMethod.cmbOperationMode.Enabled = False
            If objfrmNewMethod.ShowDialog() = DialogResult.OK Then

                OpenMethodMode = modGlobalConstants.EnumMethodMode.NewMode

                If Not gobjNewMethod Is Nothing Then

                    '---Enum Values Changed and Added by Mangesh on 23-Jan-2007
                    Select Case gobjNewMethod.OperationMode
                        Case EnumOperationMode.MODE_AA, EnumOperationMode.MODE_AABGC     '1, 3
                            objfrmInstrParameters = New frmInstrumentParameters(OpenMethodMode)
                            Application.DoEvents()
                            If objfrmInstrParameters.ShowDialog() = DialogResult.OK Then
                                '---do nothing & move forward to create new method
                            Else
                                gobjNewMethod.Status = False 'Added By Pankaj Thu 24 May 07

                                Exit Sub

                            End If

                            'Case EnumOperationMode.MODE_UVABS   '2
                            '    objfrmUVQuantitativeAnalysis = New frmUVQuantitativeAnalysis(OpenMethodMode)
                            '    Application.DoEvents()
                            '    If objfrmUVQuantitativeAnalysis.ShowDialog() = DialogResult.OK Then
                            '        '---do nothing & move forward to create new method
                            '    Else
                            '        gobjNewMethod.Status = False 'Added By Pankaj Thu 24 May 07
                            '        Exit Sub
                            '    End If

                            'Case EnumOperationMode.MODE_EMMISSION   '4
                            '    objfrmEmissionMode = New frmEmissionMode(OpenMethodMode)
                            '    Application.DoEvents()
                            '    If objfrmEmissionMode.ShowDialog() = DialogResult.OK Then
                            '        '---do nothing & move forward to create new method
                            '    Else
                            '        'Added By Pankaj Thu 24 May 07
                            '        gobjNewMethod.Status = False
                            '        '-----
                            '        Exit Sub
                            '    End If

                    End Select

                    '--------5.4.2010 by dinesh wagh
                    Dim intNumOfSamples As Integer
                    Select Case intAttachmentNo
                        Case EnumIQOQPQtestId.ePQ2
                            intNumOfSamples = 1
                        Case EnumIQOQPQtestId.ePQ3
                            intNumOfSamples = 15
                        Case Else
                            intNumOfSamples = 15
                    End Select
                    '-------------

                    'objfrmAnalysisParameters = New frmMethodAnalysisParameters(OpenMethodMode) 'commented by : dinesh wagh on 2.2.2010
                    objfrmAnalysisParameters = New frmMethodAnalysisParameters(OpenMethodMode, intNumOfSamples)  'added by ; dinesh wagh on 2.2.2010 ' as below we set no of sample as 15 samples.

                    Application.DoEvents()

                    objfrmAnalysisParameters.nudNumofSamples.Maximum = 15
                    objfrmAnalysisParameters.nudNumofSamples.Minimum = 1
                    objfrmAnalysisParameters.Label1.Text = "1..15"

                    '---------5.4.2010 by dinesh wagh
                    Select Case intAttachmentNo
                        Case EnumIQOQPQtestId.ePQ2
                            objfrmAnalysisParameters.nudNumSampRepeat.Value = 10
                        Case EnumIQOQPQtestId.ePQ3
                            objfrmAnalysisParameters.nudNumSampRepeat.Value = 1
                        Case Else
                            objfrmAnalysisParameters.nudNumSampRepeat.Value = 10
                    End Select
                    '-------------------



                    If objfrmAnalysisParameters.ShowDialog() = DialogResult.OK Then

                        objfrmStdParameters = New frmStandardConcentration
                        Application.DoEvents()
                        If objfrmStdParameters.ShowDialog() = DialogResult.OK Then
                            gobjNewMethod.Status = True 'Added By Pankaj 23 May 07 
                            objfrmSampleParameters = New frmSampleParameters(EnumMethodMode.NewMode)
                            Application.DoEvents()
                            If objfrmSampleParameters.ShowDialog() = DialogResult.OK Then

                                objfrmReportOptions = New frmReportOptions(EnumMethodMode.NewMode, False, 0, 0)
                                Application.DoEvents()
                                If objfrmReportOptions.ShowDialog() = DialogResult.OK Then


                                    '----Commented by Mangesh on 04-Apr-2007

                                    ''---add new method to method collection


                                    '---For Double Beam Added by Mangesh on 06-Apr-2007

                                    If gintInstrumentBeamType = enumInstrumentBeamType.DoubleBeam Then
                                        gobjNewMethod.InstrumentBeamType = enumInstrumentBeamType.DoubleBeam
                                    ElseIf gintInstrumentBeamType = enumInstrumentBeamType.SingleBeam Then
                                        gobjNewMethod.InstrumentBeamType = enumInstrumentBeamType.SingleBeam
                                    End If

                                    '------Added By Pankaj Thu 28 May 07
                                    gobjchkActiveMethod.NewMethod = False
                                    gobjchkActiveMethod.CancelMethod = False
                                    'gobjchkActiveMethod.fillInstruments = False  '27.07.07
                                    'gobjchkActiveMethod.fillParameters = False   '27.07.07
                                    gobjchkActiveMethod.fillStdConcentration = False
                                    Call gobjMethodCollection.Add(gobjNewMethod)

                                    ''---serialize method collection 
                                    Call funcSaveAllMethods(gobjMethodCollection)



                                    '----Added by Mangesh on 04-Apr-2007

                                    OpenMethodMode = modGlobalConstants.EnumMethodMode.EditMode


                                    '---display confirmation dialog box of method creation
                                    Call gobjMessageAdapter.ShowMessage(contMethodCreatedSuccessfully)
                                    Call Application.DoEvents()
                                    gIntMethodID = gobjNewMethod.MethodID


                                    '---START --- Added by Mangesh on 27-Feb-2007

                                    Call OnQuantAnalyse_IQOQPQ_Test_AttachmentII()

                                    '---END  ---  Added by Mangesh on 27-Feb-2007

                                Else

                                End If
                            Else

                            End If
                        Else
                            gobjNewMethod.Status = False
                        End If
                    Else
                        gobjNewMethod.Status = False

                    End If
                Else
                    gobjNewMethod.Status = False

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
            'tlbbtnNewMethod.ResumeEvents()
            gobjfrmStatus.TopMost = True
            '---------------------------------------------------------
        End Try

    End Sub

    Public Sub OnQuantAnalyse_IQOQPQ_Test_AttachmentII()
        '=====================================================================
        ' Procedure Name        : OnQuantAnalyse_IQOQPQ_Test_AttachmentII
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh Singh
        ' Created               : 12-July-2007 12:15 pm
        ' Revisions             : 1
        '=====================================================================
        Dim mvalid As Integer
        Dim msgcount As Integer
        Dim msg As Message
        Dim objfrmAnalysis As New frmTest_Analysis

        Try

            mvalid = CheckMethod()

            If (mvalid = 0) Then
                Return
            End If

            If (mvalid = 2) Then

                Call objfrmAnalysis.StartNewAnalysis()
                Call objfrmAnalysis.CheckAnaButtons()

                If gstructSettings.AppMode = EnumAppMode.DemoMode Then
                    '---Don't perform Peak Latching operation for Demo Method
                Else
                    '---Search and Find Analytical Peak
                    Call objfrmAnalysis.CheckInstrumentOptimisation()
                End If



            ElseIf (mvalid = 1) Then
                gobjMessageAdapter.ShowMessage("No Standard Information available", "Analysis", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage)
                Application.DoEvents()
            End If

            'Saurabh 10.07.07 To bring status form in front
            gobjfrmStatus.Show()
            'Saurabh
            If objfrmAnalysis.ShowDialog Then
                'To bring the Analysis form infront
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

    Private Sub IQOQPQ_InstrumentType(ByRef strInstrumentType As String)
        '=====================================================================
        ' Procedure Name        : IQOQPQ_InstrumentType
        ' Parameters Passed     :  
        ' Returns               : None
        ' Purpose               : get instrument type
        ' Description           :  
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 18-Aug-2007 03:15 pm
        ' Revisions             : 0
        '=====================================================================
        strInstrumentType = gstrTitleInstrumentType
    End Sub

#End Region

    Private Sub MenuBar_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MenuBar.KeyUp
        '=====================================================================
        ' Procedure Name        : MenuBar_KeyUp
        ' Parameters Passed     : Object, EventArgs
        ' Returns               : None
        ' Purpose               : 
        ' Description           : to activate shortcut keys
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 18-Aug-2007 03:15 pm
        ' Revisions             : 0
        '=====================================================================
        If mblnAvoidProcessing = True Then
            Exit Sub
        End If
        Try
            If e.Alt = True Then
                mblnAvoidProcessing = True
                Select Case e.KeyCode
                    Case Keys.I
                        AutoIgnition()
                    Case Keys.C
                        N2OAutoIgnition()
                    Case Keys.E
                        Call Extinguish()
                    Case Keys.D
                        Call funcAltDelete()
                    Case Keys.R
                        Call funcAltR()

                    Case Keys.Q

                End Select
                mblnAvoidProcessing = True
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

    Private Sub mnuCheckSamplerFunctions_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuCheckSamplerFunctions.Click
        '=====================================================================
        ' Procedure Name        : mnuCheckSamplerFunctions_Click
        ' Parameters Passed     : message
        ' Returns               : None
        ' Purpose               : to open autosampler interface
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 05.09.07
        ' Revisions             : 
        '=====================================================================
        Try
            'If gblnTestAutoSampler = True Then'Comment by pankaj for autosampler on 10 Sep 07
            If gstructAutoSampler.blnAutoSamplerInitialised = True Then
                Dim objFrmAutoSamplerInterface As New AutoSamplerInterface
                Application.DoEvents()
                objFrmAutoSamplerInterface.ShowDialog()
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
        End Try

    End Sub

    Private Sub mnuAbout_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuAbout.Click
        '=====================================================================
        ' Procedure Name        : mnuAbout_Click
        ' Parameters Passed     : message
        ' Returns               : None
        ' Purpose               : to open help about window
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 27.09.08
        ' Revisions             : 
        '=====================================================================
        Try
            Dim objFrmAbout As New frmHelpAbout
            If gstructSettings.AppMode = EnumAppMode.FullVersion_203D Or _
            gstructSettings.AppMode = EnumAppMode.DemoMode_203D Then
                objFrmAbout.aasDB_picture.BringToFront()
            Else
                objFrmAbout.AAS_picture.BringToFront()
            End If
            objFrmAbout.Text = objFrmAbout.Text & Space(1) & Me.Text
            objFrmAbout.ShowDialog()
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
