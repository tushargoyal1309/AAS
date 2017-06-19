Imports AAS203.Common
Imports System.Threading
Imports AAS203Library
Imports AAS203Library.Analysis
Imports AAS203Library.Method
Imports AAS203Library.Method.clsQuantitativeData
Imports System.IO
Imports System.Diagnostics
Imports System.Runtime.InteropServices
'Imports IQOQPQ

Imports BgThread

Public Class frmAnalysis
    Inherits System.Windows.Forms.Form
    Implements BgThread.Iclient


#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        Application.DoEvents()
        InitializeComponent()
        Application.DoEvents()
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
    Friend WithEvents HeaderRight As CodeIntellects.Office2003Controls.Office2003Header
    Friend WithEvents XpPanelGroup1 As UIComponents.XPPanelGroup
    Friend WithEvents CustomPanelMain As GradientPanel.CustomPanel
    Friend WithEvents CustomPanelRight As GradientPanel.CustomPanel
    Friend WithEvents CustomPanelLeft As GradientPanel.CustomPanel
    Friend WithEvents HeaderLeft As CodeIntellects.Office2003Controls.Office2003Header
    Friend WithEvents CustomPanel1 As GradientPanel.CustomPanel
    Friend WithEvents CustomPanelRightTop As GradientPanel.CustomPanel
    Friend WithEvents lblMethod As System.Windows.Forms.Label
    Friend WithEvents CustomPanelRightBottom As GradientPanel.CustomPanel
    Friend WithEvents lblConcentration As System.Windows.Forms.Label
    Friend WithEvents lblRepeatNo As System.Windows.Forms.Label
    Friend WithEvents lblSampleID As System.Windows.Forms.Label
    Friend WithEvents lblCorrectedAbsorbance As System.Windows.Forms.Label
    Friend WithEvents lblAverageAbsorbance As System.Windows.Forms.Label
    Friend WithEvents lblAbsorbance As System.Windows.Forms.Label
    Friend WithEvents lblRepeatNoMain As System.Windows.Forms.Label
    Friend WithEvents lblConcentrationMain As System.Windows.Forms.Label
    Friend WithEvents lblSampleIDMain As System.Windows.Forms.Label
    Friend WithEvents lblCorrectedAbsorbanceMain As System.Windows.Forms.Label
    Friend WithEvents lblAverageAbsorbanceMain As System.Windows.Forms.Label
    Friend WithEvents lblAbsorbanceMain As System.Windows.Forms.Label
    Friend WithEvents mnuBack1 As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents AASGraphAnalysis As AAS203.AASGraph
    Friend WithEvents btnStartStopAnalysis As NETXP.Controls.XPButton
    Friend WithEvents btnReadData As NETXP.Controls.XPButton
    Friend WithEvents lblRunNumberMain As System.Windows.Forms.Label
    Friend WithEvents lblRunNumber As System.Windows.Forms.Label
    Friend WithEvents custPnlASPMessages As GradientPanel.CustomPanel
    Friend WithEvents lblAspirationMessage As System.Windows.Forms.Label
    Friend WithEvents tmrAspirationMsg As System.Timers.Timer
    Friend WithEvents lblOptimizedWavelength As System.Windows.Forms.Label
    Friend WithEvents lblUVAbsorbance As System.Windows.Forms.Label
    Friend WithEvents lblUVWavelength As System.Windows.Forms.Label
    Friend WithEvents mnuBack As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuStandardGraph As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuSampleGraph As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuViewResults As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuReports As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents txtMethod As System.Windows.Forms.Label
    Friend WithEvents grpAbsorbanceValues As System.Windows.Forms.GroupBox
    Friend WithEvents grpAnalysis As System.Windows.Forms.GroupBox
    Friend WithEvents btnNewAnalysis As NETXP.Controls.XPButton
    Friend WithEvents btnBlankAnalysis As NETXP.Controls.XPButton
    Friend WithEvents btnRepeatLast As NETXP.Controls.XPButton
    Friend WithEvents btnNextAnalysis As NETXP.Controls.XPButton
    Friend WithEvents grpInstrument As System.Windows.Forms.GroupBox
    Friend WithEvents btnImport As NETXP.Controls.XPButton
    Friend WithEvents btnAutoZero As NETXP.Controls.XPButton
    Friend WithEvents btnSetup As NETXP.Controls.XPButton
    Friend WithEvents btnReoptimize As NETXP.Controls.XPButton
    Friend WithEvents btnEditData As NETXP.Controls.XPButton
    Friend WithEvents btnViewResults As NETXP.Controls.XPButton
    Friend WithEvents btnSplGraph As NETXP.Controls.XPButton
    Friend WithEvents btnStdGraph As NETXP.Controls.XPButton
    Friend WithEvents cmdChangeScale As NETXP.Controls.XPButton
    Friend WithEvents btnReports As NETXP.Controls.XPButton
    Friend WithEvents btnSave As NETXP.Controls.XPButton
    Friend WithEvents btnPrintGraph As NETXP.Controls.XPButton
    Friend WithEvents btnExtinguish As NETXP.Controls.XPButton
    Friend WithEvents btnIgnite As NETXP.Controls.XPButton
    Friend WithEvents btnExportReport As NETXP.Controls.XPButton
    Friend WithEvents RealPanel1 As NETXP.Controls.RealPanel
    Friend WithEvents RealPanel2 As NETXP.Controls.RealPanel
    Friend WithEvents RealPanel3 As NETXP.Controls.RealPanel
    Friend WithEvents btnN2OIgnite As NETXP.Controls.XPButton
    Friend WithEvents btnDelete As NETXP.Controls.XPButton
    Friend WithEvents btnR As NETXP.Controls.XPButton

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAnalysis))
        Me.CustomPanelMain = New GradientPanel.CustomPanel()
        Me.CustomPanelRight = New GradientPanel.CustomPanel()
        Me.HeaderRight = New CodeIntellects.Office2003Controls.Office2003Header()
        Me.CustomPanel1 = New GradientPanel.CustomPanel()
        Me.btnPrintGraph = New NETXP.Controls.XPButton()
        Me.cmdChangeScale = New NETXP.Controls.XPButton()
        Me.lblUVWavelength = New System.Windows.Forms.Label()
        Me.lblUVAbsorbance = New System.Windows.Forms.Label()
        Me.CustomPanelRightBottom = New GradientPanel.CustomPanel()
        Me.grpInstrument = New System.Windows.Forms.GroupBox()
        Me.btnImport = New NETXP.Controls.XPButton()
        Me.btnAutoZero = New NETXP.Controls.XPButton()
        Me.btnSetup = New NETXP.Controls.XPButton()
        Me.btnReoptimize = New NETXP.Controls.XPButton()
        Me.grpAnalysis = New System.Windows.Forms.GroupBox()
        Me.btnRepeatLast = New NETXP.Controls.XPButton()
        Me.btnNextAnalysis = New NETXP.Controls.XPButton()
        Me.btnBlankAnalysis = New NETXP.Controls.XPButton()
        Me.btnNewAnalysis = New NETXP.Controls.XPButton()
        Me.custPnlASPMessages = New GradientPanel.CustomPanel()
        Me.lblAspirationMessage = New System.Windows.Forms.Label()
        Me.btnIgnite = New NETXP.Controls.XPButton()
        Me.btnN2OIgnite = New NETXP.Controls.XPButton()
        Me.btnDelete = New NETXP.Controls.XPButton()
        Me.btnR = New NETXP.Controls.XPButton()
        Me.btnExtinguish = New NETXP.Controls.XPButton()
        Me.grpAbsorbanceValues = New System.Windows.Forms.GroupBox()
        Me.lblConcentration = New System.Windows.Forms.Label()
        Me.lblRepeatNo = New System.Windows.Forms.Label()
        Me.lblSampleID = New System.Windows.Forms.Label()
        Me.lblCorrectedAbsorbance = New System.Windows.Forms.Label()
        Me.lblAverageAbsorbance = New System.Windows.Forms.Label()
        Me.lblAbsorbance = New System.Windows.Forms.Label()
        Me.lblRepeatNoMain = New System.Windows.Forms.Label()
        Me.lblConcentrationMain = New System.Windows.Forms.Label()
        Me.lblSampleIDMain = New System.Windows.Forms.Label()
        Me.lblCorrectedAbsorbanceMain = New System.Windows.Forms.Label()
        Me.lblAverageAbsorbanceMain = New System.Windows.Forms.Label()
        Me.lblAbsorbanceMain = New System.Windows.Forms.Label()
        Me.CustomPanelRightTop = New GradientPanel.CustomPanel()
        Me.lblRunNumber = New System.Windows.Forms.Label()
        Me.lblRunNumberMain = New System.Windows.Forms.Label()
        Me.lblMethod = New System.Windows.Forms.Label()
        Me.txtMethod = New System.Windows.Forms.Label()
        Me.lblOptimizedWavelength = New System.Windows.Forms.Label()
        Me.CustomPanelLeft = New GradientPanel.CustomPanel()
        Me.XpPanelGroup1 = New UIComponents.XPPanelGroup()
        Me.RealPanel3 = New NETXP.Controls.RealPanel()
        Me.btnStartStopAnalysis = New NETXP.Controls.XPButton()
        Me.btnReadData = New NETXP.Controls.XPButton()
        Me.RealPanel2 = New NETXP.Controls.RealPanel()
        Me.btnSave = New NETXP.Controls.XPButton()
        Me.btnExportReport = New NETXP.Controls.XPButton()
        Me.btnEditData = New NETXP.Controls.XPButton()
        Me.RealPanel1 = New NETXP.Controls.RealPanel()
        Me.btnStdGraph = New NETXP.Controls.XPButton()
        Me.btnReports = New NETXP.Controls.XPButton()
        Me.btnViewResults = New NETXP.Controls.XPButton()
        Me.btnSplGraph = New NETXP.Controls.XPButton()
        Me.HeaderLeft = New CodeIntellects.Office2003Controls.Office2003Header()
        Me.mnuBack1 = New NETXP.Controls.Bars.CommandBarButtonItem()
        Me.tmrAspirationMsg = New System.Timers.Timer()
        Me.mnuBack = New NETXP.Controls.Bars.CommandBarButtonItem()
        Me.mnuStandardGraph = New NETXP.Controls.Bars.CommandBarButtonItem()
        Me.mnuSampleGraph = New NETXP.Controls.Bars.CommandBarButtonItem()
        Me.mnuViewResults = New NETXP.Controls.Bars.CommandBarButtonItem()
        Me.mnuReports = New NETXP.Controls.Bars.CommandBarButtonItem()
        Me.AASGraphAnalysis = New AAS203.AASGraph()
        Me.CustomPanelMain.SuspendLayout()
        Me.CustomPanelRight.SuspendLayout()
        Me.HeaderRight.SuspendLayout()
        Me.CustomPanel1.SuspendLayout()
        Me.CustomPanelRightBottom.SuspendLayout()
        Me.grpInstrument.SuspendLayout()
        Me.grpAnalysis.SuspendLayout()
        Me.custPnlASPMessages.SuspendLayout()
        Me.grpAbsorbanceValues.SuspendLayout()
        Me.CustomPanelRightTop.SuspendLayout()
        Me.CustomPanelLeft.SuspendLayout()
        CType(Me.XpPanelGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XpPanelGroup1.SuspendLayout()
        Me.RealPanel3.SuspendLayout()
        Me.RealPanel2.SuspendLayout()
        Me.RealPanel1.SuspendLayout()
        CType(Me.tmrAspirationMsg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CustomPanelMain
        '
        Me.CustomPanelMain.BackColor = System.Drawing.Color.AliceBlue
        Me.CustomPanelMain.BackColor2 = System.Drawing.Color.AliceBlue
        Me.CustomPanelMain.Controls.Add(Me.CustomPanelRight)
        Me.CustomPanelMain.Controls.Add(Me.CustomPanelLeft)
        Me.CustomPanelMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CustomPanelMain.Location = New System.Drawing.Point(0, 0)
        Me.CustomPanelMain.Name = "CustomPanelMain"
        Me.CustomPanelMain.Size = New System.Drawing.Size(804, 579)
        Me.CustomPanelMain.TabIndex = 0
        '
        'CustomPanelRight
        '
        Me.CustomPanelRight.BackColor = System.Drawing.Color.Transparent
        Me.CustomPanelRight.BackColor2 = System.Drawing.Color.Transparent
        Me.CustomPanelRight.Controls.Add(Me.HeaderRight)
        Me.CustomPanelRight.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CustomPanelRight.Location = New System.Drawing.Point(132, 0)
        Me.CustomPanelRight.Name = "CustomPanelRight"
        Me.CustomPanelRight.Size = New System.Drawing.Size(672, 579)
        Me.CustomPanelRight.TabIndex = 11
        '
        'HeaderRight
        '
        Me.HeaderRight.BackColor = System.Drawing.Color.Transparent
        Me.HeaderRight.Controls.Add(Me.CustomPanel1)
        Me.HeaderRight.Dock = System.Windows.Forms.DockStyle.Fill
        Me.HeaderRight.Location = New System.Drawing.Point(0, 0)
        Me.HeaderRight.Name = "HeaderRight"
        Me.HeaderRight.Size = New System.Drawing.Size(672, 579)
        Me.HeaderRight.TabIndex = 10
        Me.HeaderRight.TitleFont = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HeaderRight.TitleText = "Analysis Details"
        '
        'CustomPanel1
        '
        Me.CustomPanel1.BackColor = System.Drawing.Color.AliceBlue
        Me.CustomPanel1.BackColor2 = System.Drawing.Color.Transparent
        Me.CustomPanel1.Controls.Add(Me.btnPrintGraph)
        Me.CustomPanel1.Controls.Add(Me.cmdChangeScale)
        Me.CustomPanel1.Controls.Add(Me.AASGraphAnalysis)
        Me.CustomPanel1.Controls.Add(Me.lblUVWavelength)
        Me.CustomPanel1.Controls.Add(Me.lblUVAbsorbance)
        Me.CustomPanel1.Controls.Add(Me.CustomPanelRightBottom)
        Me.CustomPanel1.Controls.Add(Me.CustomPanelRightTop)
        Me.CustomPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CustomPanel1.Location = New System.Drawing.Point(0, 0)
        Me.CustomPanel1.Name = "CustomPanel1"
        Me.CustomPanel1.Size = New System.Drawing.Size(672, 579)
        Me.CustomPanel1.TabIndex = 8
        '
        'btnPrintGraph
        '
        Me.btnPrintGraph.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrintGraph.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrintGraph.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrintGraph.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPrintGraph.Location = New System.Drawing.Point(486, 57)
        Me.btnPrintGraph.Name = "btnPrintGraph"
        Me.btnPrintGraph.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnPrintGraph.Size = New System.Drawing.Size(110, 25)
        Me.btnPrintGraph.TabIndex = 5
        Me.btnPrintGraph.Text = "Print &Graph"
        '
        'cmdChangeScale
        '
        Me.cmdChangeScale.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdChangeScale.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdChangeScale.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdChangeScale.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdChangeScale.Location = New System.Drawing.Point(360, 57)
        Me.cmdChangeScale.Name = "cmdChangeScale"
        Me.cmdChangeScale.Size = New System.Drawing.Size(110, 25)
        Me.cmdChangeScale.TabIndex = 9
        Me.cmdChangeScale.Text = "C&hange Scale"
        Me.cmdChangeScale.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblUVWavelength
        '
        Me.lblUVWavelength.BackColor = System.Drawing.Color.White
        Me.lblUVWavelength.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblUVWavelength.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUVWavelength.Location = New System.Drawing.Point(116, 188)
        Me.lblUVWavelength.Name = "lblUVWavelength"
        Me.lblUVWavelength.Size = New System.Drawing.Size(442, 87)
        Me.lblUVWavelength.TabIndex = 27
        Me.lblUVWavelength.Text = "Wavelength : "
        Me.lblUVWavelength.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblUVAbsorbance
        '
        Me.lblUVAbsorbance.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblUVAbsorbance.BackColor = System.Drawing.Color.White
        Me.lblUVAbsorbance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblUVAbsorbance.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUVAbsorbance.Location = New System.Drawing.Point(116, 73)
        Me.lblUVAbsorbance.Name = "lblUVAbsorbance"
        Me.lblUVAbsorbance.Size = New System.Drawing.Size(442, 152)
        Me.lblUVAbsorbance.TabIndex = 26
        Me.lblUVAbsorbance.Text = "Absorbance : 0.000"
        Me.lblUVAbsorbance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblUVAbsorbance.Visible = False
        '
        'CustomPanelRightBottom
        '
        Me.CustomPanelRightBottom.BackColor = System.Drawing.Color.Transparent
        Me.CustomPanelRightBottom.BackColor2 = System.Drawing.Color.Transparent
        Me.CustomPanelRightBottom.BorderWidth = 15
        Me.CustomPanelRightBottom.Controls.Add(Me.grpInstrument)
        Me.CustomPanelRightBottom.Controls.Add(Me.grpAnalysis)
        Me.CustomPanelRightBottom.Controls.Add(Me.custPnlASPMessages)
        Me.CustomPanelRightBottom.Controls.Add(Me.grpAbsorbanceValues)
        Me.CustomPanelRightBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.CustomPanelRightBottom.Location = New System.Drawing.Point(0, 397)
        Me.CustomPanelRightBottom.Name = "CustomPanelRightBottom"
        Me.CustomPanelRightBottom.Size = New System.Drawing.Size(672, 182)
        Me.CustomPanelRightBottom.TabIndex = 20
        '
        'grpInstrument
        '
        Me.grpInstrument.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpInstrument.Controls.Add(Me.btnImport)
        Me.grpInstrument.Controls.Add(Me.btnAutoZero)
        Me.grpInstrument.Controls.Add(Me.btnSetup)
        Me.grpInstrument.Controls.Add(Me.btnReoptimize)
        Me.grpInstrument.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpInstrument.Location = New System.Drawing.Point(544, 4)
        Me.grpInstrument.Name = "grpInstrument"
        Me.grpInstrument.Size = New System.Drawing.Size(114, 175)
        Me.grpInstrument.TabIndex = 1
        Me.grpInstrument.TabStop = False
        Me.grpInstrument.Text = "Instrument "
        '
        'btnImport
        '
        Me.btnImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnImport.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImport.Image = CType(resources.GetObject("btnImport.Image"), System.Drawing.Image)
        Me.btnImport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnImport.Location = New System.Drawing.Point(6, 134)
        Me.btnImport.Name = "btnImport"
        Me.btnImport.Size = New System.Drawing.Size(100, 36)
        Me.btnImport.TabIndex = 3
        Me.btnImport.Text = "Import &File"
        Me.btnImport.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnAutoZero
        '
        Me.btnAutoZero.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAutoZero.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAutoZero.Image = CType(resources.GetObject("btnAutoZero.Image"), System.Drawing.Image)
        Me.btnAutoZero.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAutoZero.Location = New System.Drawing.Point(6, 96)
        Me.btnAutoZero.Name = "btnAutoZero"
        Me.btnAutoZero.Size = New System.Drawing.Size(100, 36)
        Me.btnAutoZero.TabIndex = 2
        Me.btnAutoZero.Text = "Auto &Zero"
        Me.btnAutoZero.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnSetup
        '
        Me.btnSetup.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSetup.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSetup.Image = CType(resources.GetObject("btnSetup.Image"), System.Drawing.Image)
        Me.btnSetup.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSetup.Location = New System.Drawing.Point(6, 58)
        Me.btnSetup.Name = "btnSetup"
        Me.btnSetup.Size = New System.Drawing.Size(100, 36)
        Me.btnSetup.TabIndex = 1
        Me.btnSetup.Text = "Se&tUp"
        Me.btnSetup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnReoptimize
        '
        'Me.btnReoptimize.Enabled = False 'code commented by Mrutunjaya/Surajfor enabling reoptimize button in analysis screen
        'Me.btnReoptimize.EnableFade = False
        Me.btnReoptimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnReoptimize.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReoptimize.Image = CType(resources.GetObject("btnReoptimize.Image"), System.Drawing.Image)
        Me.btnReoptimize.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReoptimize.Location = New System.Drawing.Point(6, 20)
        Me.btnReoptimize.Name = "btnReoptimize"
        Me.btnReoptimize.Size = New System.Drawing.Size(100, 36)
        Me.btnReoptimize.TabIndex = 0
        Me.btnReoptimize.Text = "Re &Optimize"
        Me.btnReoptimize.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'grpAnalysis
        '
        Me.grpAnalysis.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpAnalysis.Controls.Add(Me.btnRepeatLast)
        Me.grpAnalysis.Controls.Add(Me.btnNextAnalysis)
        Me.grpAnalysis.Controls.Add(Me.btnBlankAnalysis)
        Me.grpAnalysis.Controls.Add(Me.btnNewAnalysis)
        Me.grpAnalysis.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpAnalysis.Location = New System.Drawing.Point(425, 4)
        Me.grpAnalysis.Name = "grpAnalysis"
        Me.grpAnalysis.Size = New System.Drawing.Size(114, 175)
        Me.grpAnalysis.TabIndex = 0
        Me.grpAnalysis.TabStop = False
        Me.grpAnalysis.Text = "Analysis"
        '
        'btnRepeatLast
        '
        Me.btnRepeatLast.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRepeatLast.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRepeatLast.Image = CType(resources.GetObject("btnRepeatLast.Image"), System.Drawing.Image)
        Me.btnRepeatLast.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRepeatLast.Location = New System.Drawing.Point(6, 134)
        Me.btnRepeatLast.Name = "btnRepeatLast"
        Me.btnRepeatLast.Size = New System.Drawing.Size(100, 36)
        Me.btnRepeatLast.TabIndex = 3
        Me.btnRepeatLast.Text = "Repeat &Last"
        Me.btnRepeatLast.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'btnNextAnalysis
        '
        Me.btnNextAnalysis.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNextAnalysis.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNextAnalysis.Image = CType(resources.GetObject("btnNextAnalysis.Image"), System.Drawing.Image)
        Me.btnNextAnalysis.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNextAnalysis.Location = New System.Drawing.Point(6, 96)
        Me.btnNextAnalysis.Name = "btnNextAnalysis"
        Me.btnNextAnalysis.Size = New System.Drawing.Size(100, 36)
        Me.btnNextAnalysis.TabIndex = 2
        Me.btnNextAnalysis.Text = "Next"
        Me.btnNextAnalysis.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnBlankAnalysis
        '
        Me.btnBlankAnalysis.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBlankAnalysis.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBlankAnalysis.Image = CType(resources.GetObject("btnBlankAnalysis.Image"), System.Drawing.Image)
        Me.btnBlankAnalysis.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBlankAnalysis.Location = New System.Drawing.Point(6, 58)
        Me.btnBlankAnalysis.Name = "btnBlankAnalysis"
        Me.btnBlankAnalysis.Size = New System.Drawing.Size(100, 36)
        Me.btnBlankAnalysis.TabIndex = 1
        Me.btnBlankAnalysis.Text = "Blan&k"
        Me.btnBlankAnalysis.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnNewAnalysis
        '
        Me.btnNewAnalysis.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNewAnalysis.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNewAnalysis.Image = CType(resources.GetObject("btnNewAnalysis.Image"), System.Drawing.Image)
        Me.btnNewAnalysis.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNewAnalysis.Location = New System.Drawing.Point(6, 20)
        Me.btnNewAnalysis.Name = "btnNewAnalysis"
        Me.btnNewAnalysis.Size = New System.Drawing.Size(100, 36)
        Me.btnNewAnalysis.TabIndex = 0
        Me.btnNewAnalysis.Text = "Ne&w Analysis"
        Me.btnNewAnalysis.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'custPnlASPMessages
        '
        Me.custPnlASPMessages.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.custPnlASPMessages.BackColor = System.Drawing.Color.White
        Me.custPnlASPMessages.BackColor2 = System.Drawing.Color.Gainsboro
        Me.custPnlASPMessages.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.custPnlASPMessages.Controls.Add(Me.lblAspirationMessage)
        Me.custPnlASPMessages.Controls.Add(Me.btnIgnite)
        Me.custPnlASPMessages.Controls.Add(Me.btnN2OIgnite)
        Me.custPnlASPMessages.Controls.Add(Me.btnDelete)
        Me.custPnlASPMessages.Controls.Add(Me.btnR)
        Me.custPnlASPMessages.Controls.Add(Me.btnExtinguish)
        Me.custPnlASPMessages.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.custPnlASPMessages.GradientMode = GradientPanel.LinearGradientMode.Horizontal
        Me.custPnlASPMessages.Location = New System.Drawing.Point(10, 4)
        Me.custPnlASPMessages.Name = "custPnlASPMessages"
        Me.custPnlASPMessages.Size = New System.Drawing.Size(410, 38)
        Me.custPnlASPMessages.TabIndex = 10
        '
        'lblAspirationMessage
        '
        Me.lblAspirationMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblAspirationMessage.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblAspirationMessage.ForeColor = System.Drawing.Color.Maroon
        Me.lblAspirationMessage.Location = New System.Drawing.Point(0, 0)
        Me.lblAspirationMessage.Name = "lblAspirationMessage"
        Me.lblAspirationMessage.Size = New System.Drawing.Size(410, 38)
        Me.lblAspirationMessage.TabIndex = 0
        Me.lblAspirationMessage.Text = "Wait ... "
        Me.lblAspirationMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnIgnite
        '
        Me.btnIgnite.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnIgnite.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnIgnite.Location = New System.Drawing.Point(86, 12)
        Me.btnIgnite.Name = "btnIgnite"
        Me.btnIgnite.Size = New System.Drawing.Size(27, 3)
        Me.btnIgnite.TabIndex = 11
        Me.btnIgnite.TabStop = False
        Me.btnIgnite.Text = "&Ignite"
        '
        'btnN2OIgnite
        '
        Me.btnN2OIgnite.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnN2OIgnite.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnN2OIgnite.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnN2OIgnite.Location = New System.Drawing.Point(108, 8)
        Me.btnN2OIgnite.Name = "btnN2OIgnite"
        Me.btnN2OIgnite.Size = New System.Drawing.Size(5, 10)
        Me.btnN2OIgnite.TabIndex = 19
        Me.btnN2OIgnite.TabStop = False
        Me.btnN2OIgnite.Text = "N2O&C"
        Me.btnN2OIgnite.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'btnDelete
        '
        Me.btnDelete.BackColor = System.Drawing.Color.Transparent
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelete.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDelete.Location = New System.Drawing.Point(96, 15)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(8, 8)
        Me.btnDelete.TabIndex = 24
        Me.btnDelete.TabStop = False
        Me.btnDelete.Text = "&Delete"
        Me.btnDelete.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btnDelete.UseVisualStyleBackColor = False
        '
        'btnR
        '
        Me.btnR.BackColor = System.Drawing.Color.Transparent
        Me.btnR.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnR.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnR.Location = New System.Drawing.Point(108, 15)
        Me.btnR.Name = "btnR"
        Me.btnR.Size = New System.Drawing.Size(8, 8)
        Me.btnR.TabIndex = 23
        Me.btnR.TabStop = False
        Me.btnR.Text = "&R"
        Me.btnR.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btnR.UseVisualStyleBackColor = False
        '
        'btnExtinguish
        '
        Me.btnExtinguish.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExtinguish.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExtinguish.Location = New System.Drawing.Point(58, 16)
        Me.btnExtinguish.Name = "btnExtinguish"
        Me.btnExtinguish.Size = New System.Drawing.Size(20, 3)
        Me.btnExtinguish.TabIndex = 10
        Me.btnExtinguish.TabStop = False
        Me.btnExtinguish.Text = "&Extinguish"
        '
        'grpAbsorbanceValues
        '
        Me.grpAbsorbanceValues.Controls.Add(Me.lblConcentration)
        Me.grpAbsorbanceValues.Controls.Add(Me.lblRepeatNo)
        Me.grpAbsorbanceValues.Controls.Add(Me.lblSampleID)
        Me.grpAbsorbanceValues.Controls.Add(Me.lblCorrectedAbsorbance)
        Me.grpAbsorbanceValues.Controls.Add(Me.lblAverageAbsorbance)
        Me.grpAbsorbanceValues.Controls.Add(Me.lblAbsorbance)
        Me.grpAbsorbanceValues.Controls.Add(Me.lblRepeatNoMain)
        Me.grpAbsorbanceValues.Controls.Add(Me.lblConcentrationMain)
        Me.grpAbsorbanceValues.Controls.Add(Me.lblSampleIDMain)
        Me.grpAbsorbanceValues.Controls.Add(Me.lblCorrectedAbsorbanceMain)
        Me.grpAbsorbanceValues.Controls.Add(Me.lblAverageAbsorbanceMain)
        Me.grpAbsorbanceValues.Controls.Add(Me.lblAbsorbanceMain)
        Me.grpAbsorbanceValues.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpAbsorbanceValues.Location = New System.Drawing.Point(10, 42)
        Me.grpAbsorbanceValues.Name = "grpAbsorbanceValues"
        Me.grpAbsorbanceValues.Size = New System.Drawing.Size(410, 137)
        Me.grpAbsorbanceValues.TabIndex = 9
        Me.grpAbsorbanceValues.TabStop = False
        Me.grpAbsorbanceValues.Text = "Current Std/Sample Information"
        '
        'lblConcentration
        '
        Me.lblConcentration.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblConcentration.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblConcentration.Location = New System.Drawing.Point(296, 96)
        Me.lblConcentration.Name = "lblConcentration"
        Me.lblConcentration.Size = New System.Drawing.Size(108, 18)
        Me.lblConcentration.TabIndex = 11
        '
        'lblRepeatNo
        '
        Me.lblRepeatNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRepeatNo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRepeatNo.Location = New System.Drawing.Point(296, 60)
        Me.lblRepeatNo.Name = "lblRepeatNo"
        Me.lblRepeatNo.Size = New System.Drawing.Size(108, 18)
        Me.lblRepeatNo.TabIndex = 10
        '
        'lblSampleID
        '
        Me.lblSampleID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSampleID.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSampleID.Location = New System.Drawing.Point(296, 24)
        Me.lblSampleID.Name = "lblSampleID"
        Me.lblSampleID.Size = New System.Drawing.Size(108, 18)
        Me.lblSampleID.TabIndex = 9
        '
        'lblCorrectedAbsorbance
        '
        Me.lblCorrectedAbsorbance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCorrectedAbsorbance.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCorrectedAbsorbance.Location = New System.Drawing.Point(94, 96)
        Me.lblCorrectedAbsorbance.Name = "lblCorrectedAbsorbance"
        Me.lblCorrectedAbsorbance.Size = New System.Drawing.Size(102, 18)
        Me.lblCorrectedAbsorbance.TabIndex = 8
        '
        'lblAverageAbsorbance
        '
        Me.lblAverageAbsorbance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblAverageAbsorbance.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAverageAbsorbance.Location = New System.Drawing.Point(94, 60)
        Me.lblAverageAbsorbance.Name = "lblAverageAbsorbance"
        Me.lblAverageAbsorbance.Size = New System.Drawing.Size(102, 18)
        Me.lblAverageAbsorbance.TabIndex = 7
        '
        'lblAbsorbance
        '
        Me.lblAbsorbance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblAbsorbance.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAbsorbance.Location = New System.Drawing.Point(94, 24)
        Me.lblAbsorbance.Name = "lblAbsorbance"
        Me.lblAbsorbance.Size = New System.Drawing.Size(102, 18)
        Me.lblAbsorbance.TabIndex = 6
        '
        'lblRepeatNoMain
        '
        Me.lblRepeatNoMain.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRepeatNoMain.Location = New System.Drawing.Point(208, 65)
        Me.lblRepeatNoMain.Name = "lblRepeatNoMain"
        Me.lblRepeatNoMain.Size = New System.Drawing.Size(84, 18)
        Me.lblRepeatNoMain.TabIndex = 5
        Me.lblRepeatNoMain.Text = "Repeat No. :"
        '
        'lblConcentrationMain
        '
        Me.lblConcentrationMain.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblConcentrationMain.Location = New System.Drawing.Point(208, 100)
        Me.lblConcentrationMain.Name = "lblConcentrationMain"
        Me.lblConcentrationMain.Size = New System.Drawing.Size(86, 18)
        Me.lblConcentrationMain.TabIndex = 4
        Me.lblConcentrationMain.Text = "Concentration:"
        '
        'lblSampleIDMain
        '
        Me.lblSampleIDMain.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSampleIDMain.Location = New System.Drawing.Point(208, 28)
        Me.lblSampleIDMain.Name = "lblSampleIDMain"
        Me.lblSampleIDMain.Size = New System.Drawing.Size(86, 18)
        Me.lblSampleIDMain.TabIndex = 3
        Me.lblSampleIDMain.Text = "Sample ID :"
        '
        'lblCorrectedAbsorbanceMain
        '
        Me.lblCorrectedAbsorbanceMain.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCorrectedAbsorbanceMain.Location = New System.Drawing.Point(8, 87)
        Me.lblCorrectedAbsorbanceMain.Name = "lblCorrectedAbsorbanceMain"
        Me.lblCorrectedAbsorbanceMain.Size = New System.Drawing.Size(90, 34)
        Me.lblCorrectedAbsorbanceMain.TabIndex = 2
        Me.lblCorrectedAbsorbanceMain.Text = "Corrected Absorbance :"
        '
        'lblAverageAbsorbanceMain
        '
        Me.lblAverageAbsorbanceMain.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAverageAbsorbanceMain.Location = New System.Drawing.Point(8, 50)
        Me.lblAverageAbsorbanceMain.Name = "lblAverageAbsorbanceMain"
        Me.lblAverageAbsorbanceMain.Size = New System.Drawing.Size(90, 36)
        Me.lblAverageAbsorbanceMain.TabIndex = 1
        Me.lblAverageAbsorbanceMain.Text = "Average Absorbance :"
        '
        'lblAbsorbanceMain
        '
        Me.lblAbsorbanceMain.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAbsorbanceMain.Location = New System.Drawing.Point(8, 28)
        Me.lblAbsorbanceMain.Name = "lblAbsorbanceMain"
        Me.lblAbsorbanceMain.Size = New System.Drawing.Size(90, 18)
        Me.lblAbsorbanceMain.TabIndex = 0
        Me.lblAbsorbanceMain.Text = "Absorbance :"
        '
        'CustomPanelRightTop
        '
        Me.CustomPanelRightTop.BackColor = System.Drawing.Color.Transparent
        Me.CustomPanelRightTop.BackColor2 = System.Drawing.Color.Transparent
        Me.CustomPanelRightTop.Controls.Add(Me.lblRunNumber)
        Me.CustomPanelRightTop.Controls.Add(Me.lblRunNumberMain)
        Me.CustomPanelRightTop.Controls.Add(Me.lblMethod)
        Me.CustomPanelRightTop.Controls.Add(Me.txtMethod)
        Me.CustomPanelRightTop.Controls.Add(Me.lblOptimizedWavelength)
        Me.CustomPanelRightTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.CustomPanelRightTop.Location = New System.Drawing.Point(0, 0)
        Me.CustomPanelRightTop.Name = "CustomPanelRightTop"
        Me.CustomPanelRightTop.Size = New System.Drawing.Size(672, 54)
        Me.CustomPanelRightTop.TabIndex = 22
        '
        'lblRunNumber
        '
        Me.lblRunNumber.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRunNumber.Location = New System.Drawing.Point(285, 24)
        Me.lblRunNumber.Name = "lblRunNumber"
        Me.lblRunNumber.Size = New System.Drawing.Size(80, 16)
        Me.lblRunNumber.TabIndex = 24
        '
        'lblRunNumberMain
        '
        Me.lblRunNumberMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRunNumberMain.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRunNumberMain.Location = New System.Drawing.Point(172, 23)
        Me.lblRunNumberMain.Name = "lblRunNumberMain"
        Me.lblRunNumberMain.Size = New System.Drawing.Size(196, 19)
        Me.lblRunNumberMain.TabIndex = 23
        Me.lblRunNumberMain.Text = "Run Number : "
        '
        'lblMethod
        '
        Me.lblMethod.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMethod.Location = New System.Drawing.Point(12, 23)
        Me.lblMethod.Name = "lblMethod"
        Me.lblMethod.Size = New System.Drawing.Size(61, 18)
        Me.lblMethod.TabIndex = 19
        Me.lblMethod.Text = "Method :"
        Me.lblMethod.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtMethod
        '
        Me.txtMethod.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMethod.Location = New System.Drawing.Point(75, 23)
        Me.txtMethod.Name = "txtMethod"
        Me.txtMethod.Size = New System.Drawing.Size(92, 18)
        Me.txtMethod.TabIndex = 25
        Me.txtMethod.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblOptimizedWavelength
        '
        Me.lblOptimizedWavelength.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOptimizedWavelength.Location = New System.Drawing.Point(409, 22)
        Me.lblOptimizedWavelength.Name = "lblOptimizedWavelength"
        Me.lblOptimizedWavelength.Size = New System.Drawing.Size(217, 19)
        Me.lblOptimizedWavelength.TabIndex = 25
        Me.lblOptimizedWavelength.Text = "Optimized Wavelength : "
        '
        'CustomPanelLeft
        '
        Me.CustomPanelLeft.BackColor = System.Drawing.Color.Transparent
        Me.CustomPanelLeft.BackColor2 = System.Drawing.Color.Transparent
        Me.CustomPanelLeft.Controls.Add(Me.XpPanelGroup1)
        Me.CustomPanelLeft.Controls.Add(Me.HeaderLeft)
        Me.CustomPanelLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.CustomPanelLeft.Location = New System.Drawing.Point(0, 0)
        Me.CustomPanelLeft.Name = "CustomPanelLeft"
        Me.CustomPanelLeft.Size = New System.Drawing.Size(132, 579)
        Me.CustomPanelLeft.TabIndex = 10
        '
        'XpPanelGroup1
        '
        Me.XpPanelGroup1.AutoScroll = True
        Me.XpPanelGroup1.BackColor = System.Drawing.Color.Transparent
        Me.XpPanelGroup1.Controls.Add(Me.RealPanel3)
        Me.XpPanelGroup1.Controls.Add(Me.RealPanel2)
        Me.XpPanelGroup1.Controls.Add(Me.RealPanel1)
        Me.XpPanelGroup1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XpPanelGroup1.Location = New System.Drawing.Point(0, 22)
        Me.XpPanelGroup1.Name = "XpPanelGroup1"
        Me.XpPanelGroup1.PanelGradient = CType(resources.GetObject("XpPanelGroup1.PanelGradient"), UIComponents.GradientColor)
        Me.XpPanelGroup1.PanelSpacing = 4
        Me.XpPanelGroup1.Size = New System.Drawing.Size(132, 557)
        Me.XpPanelGroup1.TabIndex = 0
        '
        'RealPanel3
        '
        Me.RealPanel3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.RealPanel3.Controls.Add(Me.btnStartStopAnalysis)
        Me.RealPanel3.Controls.Add(Me.btnReadData)
        Me.RealPanel3.Location = New System.Drawing.Point(6, 345)
        Me.RealPanel3.Name = "RealPanel3"
        Me.RealPanel3.Size = New System.Drawing.Size(117, 95)
        Me.RealPanel3.TabIndex = 30
        Me.RealPanel3.Text = "RealPanel3"
        '
        'btnStartStopAnalysis
        '
        Me.btnStartStopAnalysis.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnStartStopAnalysis.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStartStopAnalysis.Image = CType(resources.GetObject("btnStartStopAnalysis.Image"), System.Drawing.Image)
        Me.btnStartStopAnalysis.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnStartStopAnalysis.Location = New System.Drawing.Point(4, 5)
        Me.btnStartStopAnalysis.Name = "btnStartStopAnalysis"
        Me.btnStartStopAnalysis.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnStartStopAnalysis.Size = New System.Drawing.Size(110, 36)
        Me.btnStartStopAnalysis.TabIndex = 6
        Me.btnStartStopAnalysis.Text = "Start Anal&ysis"
        Me.btnStartStopAnalysis.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'btnReadData
        '
        Me.btnReadData.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnReadData.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReadData.Image = CType(resources.GetObject("btnReadData.Image"), System.Drawing.Image)
        Me.btnReadData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReadData.Location = New System.Drawing.Point(4, 49)
        Me.btnReadData.Name = "btnReadData"
        Me.btnReadData.Size = New System.Drawing.Size(110, 36)
        Me.btnReadData.TabIndex = 7
        Me.btnReadData.Text = "Read Data"
        Me.btnReadData.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'RealPanel2
        '
        Me.RealPanel2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.RealPanel2.Controls.Add(Me.btnSave)
        Me.RealPanel2.Controls.Add(Me.btnExportReport)
        Me.RealPanel2.Controls.Add(Me.btnEditData)
        Me.RealPanel2.Location = New System.Drawing.Point(6, 196)
        Me.RealPanel2.Name = "RealPanel2"
        Me.RealPanel2.Size = New System.Drawing.Size(117, 138)
        Me.RealPanel2.TabIndex = 29
        Me.RealPanel2.Text = "RealPanel2"
        '
        'btnSave
        '
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSave.Location = New System.Drawing.Point(4, 6)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnSave.Size = New System.Drawing.Size(110, 36)
        Me.btnSave.TabIndex = 3
        Me.btnSave.Text = "&Save Reports"
        Me.btnSave.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'btnExportReport
        '
        Me.btnExportReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExportReport.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExportReport.Image = CType(resources.GetObject("btnExportReport.Image"), System.Drawing.Image)
        Me.btnExportReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExportReport.Location = New System.Drawing.Point(4, 50)
        Me.btnExportReport.Name = "btnExportReport"
        Me.btnExportReport.Size = New System.Drawing.Size(110, 36)
        Me.btnExportReport.TabIndex = 10
        Me.btnExportReport.Text = "E&xport Report"
        Me.btnExportReport.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'btnEditData
        '
        Me.btnEditData.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEditData.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEditData.Image = CType(resources.GetObject("btnEditData.Image"), System.Drawing.Image)
        Me.btnEditData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEditData.Location = New System.Drawing.Point(4, 95)
        Me.btnEditData.Name = "btnEditData"
        Me.btnEditData.Size = New System.Drawing.Size(110, 36)
        Me.btnEditData.TabIndex = 8
        Me.btnEditData.Text = "Edit Data"
        Me.btnEditData.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'RealPanel1
        '
        Me.RealPanel1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.RealPanel1.Controls.Add(Me.btnStdGraph)
        Me.RealPanel1.Controls.Add(Me.btnReports)
        Me.RealPanel1.Controls.Add(Me.btnViewResults)
        Me.RealPanel1.Controls.Add(Me.btnSplGraph)
        Me.RealPanel1.Location = New System.Drawing.Point(6, 10)
        Me.RealPanel1.Name = "RealPanel1"
        Me.RealPanel1.Size = New System.Drawing.Size(117, 176)
        Me.RealPanel1.TabIndex = 28
        Me.RealPanel1.Text = "RealPanel1"
        '
        'btnStdGraph
        '
        Me.btnStdGraph.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnStdGraph.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStdGraph.Image = CType(resources.GetObject("btnStdGraph.Image"), System.Drawing.Image)
        Me.btnStdGraph.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnStdGraph.Location = New System.Drawing.Point(4, 6)
        Me.btnStdGraph.Name = "btnStdGraph"
        Me.btnStdGraph.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnStdGraph.Size = New System.Drawing.Size(110, 36)
        Me.btnStdGraph.TabIndex = 0
        Me.btnStdGraph.Text = "Sta&ndard Graph"
        Me.btnStdGraph.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'btnReports
        '
        Me.btnReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnReports.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReports.Image = CType(resources.GetObject("btnReports.Image"), System.Drawing.Image)
        Me.btnReports.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReports.Location = New System.Drawing.Point(4, 134)
        Me.btnReports.Name = "btnReports"
        Me.btnReports.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnReports.Size = New System.Drawing.Size(110, 36)
        Me.btnReports.TabIndex = 4
        Me.btnReports.Text = "Re&ports"
        Me.btnReports.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnViewResults
        '
        Me.btnViewResults.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnViewResults.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnViewResults.Image = CType(resources.GetObject("btnViewResults.Image"), System.Drawing.Image)
        Me.btnViewResults.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnViewResults.Location = New System.Drawing.Point(4, 90)
        Me.btnViewResults.Name = "btnViewResults"
        Me.btnViewResults.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnViewResults.Size = New System.Drawing.Size(110, 36)
        Me.btnViewResults.TabIndex = 2
        Me.btnViewResults.Text = "&View Results"
        Me.btnViewResults.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'btnSplGraph
        '
        Me.btnSplGraph.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSplGraph.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSplGraph.Image = CType(resources.GetObject("btnSplGraph.Image"), System.Drawing.Image)
        Me.btnSplGraph.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSplGraph.Location = New System.Drawing.Point(4, 48)
        Me.btnSplGraph.Name = "btnSplGraph"
        Me.btnSplGraph.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnSplGraph.Size = New System.Drawing.Size(110, 36)
        Me.btnSplGraph.TabIndex = 1
        Me.btnSplGraph.Text = "Sa&mple Graph"
        Me.btnSplGraph.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'HeaderLeft
        '
        Me.HeaderLeft.BackColor = System.Drawing.SystemColors.Control
        Me.HeaderLeft.Dock = System.Windows.Forms.DockStyle.Top
        Me.HeaderLeft.Location = New System.Drawing.Point(0, 0)
        Me.HeaderLeft.Name = "HeaderLeft"
        Me.HeaderLeft.Size = New System.Drawing.Size(132, 22)
        Me.HeaderLeft.TabIndex = 7
        Me.HeaderLeft.TitleFont = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HeaderLeft.TitleText = "Options"
        '
        'mnuBack1
        '
        Me.mnuBack1.Shortcut = System.Windows.Forms.Shortcut.CtrlZ
        Me.mnuBack1.Text = "Back"
        '
        'tmrAspirationMsg
        '
        Me.tmrAspirationMsg.Interval = 500.0R
        Me.tmrAspirationMsg.SynchronizingObject = Me
        '
        'mnuBack
        '
        Me.mnuBack.Shortcut = System.Windows.Forms.Shortcut.CtrlB
        Me.mnuBack.Text = "Back"
        '
        'mnuStandardGraph
        '
        Me.mnuStandardGraph.Shortcut = System.Windows.Forms.Shortcut.CtrlT
        Me.mnuStandardGraph.Text = "Standard Graph"
        '
        'mnuSampleGraph
        '
        Me.mnuSampleGraph.Shortcut = System.Windows.Forms.Shortcut.CtrlA
        Me.mnuSampleGraph.Text = "Sample Graph"
        '
        'mnuViewResults
        '
        Me.mnuViewResults.Shortcut = System.Windows.Forms.Shortcut.CtrlU
        Me.mnuViewResults.Text = "View Results"
        '
        'mnuReports
        '
        Me.mnuReports.Shortcut = System.Windows.Forms.Shortcut.CtrlR
        Me.mnuReports.Text = "Reports"
        '
        'AASGraphAnalysis
        '
        Me.AASGraphAnalysis.AldysGraphCursor = Nothing
        Me.AASGraphAnalysis.AldysGraphPrintColor = System.Drawing.Color.Black
        Me.AASGraphAnalysis.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AASGraphAnalysis.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.AASGraphAnalysis.BackColor = System.Drawing.Color.LightGray
        Me.AASGraphAnalysis.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AASGraphAnalysis.GraphDataSource = Nothing
        Me.AASGraphAnalysis.GraphImage = Nothing
        Me.AASGraphAnalysis.IsShowGrid = True
        Me.AASGraphAnalysis.Location = New System.Drawing.Point(14, 48)
        Me.AASGraphAnalysis.Name = "AASGraphAnalysis"
        Me.AASGraphAnalysis.Size = New System.Drawing.Size(645, 341)
        Me.AASGraphAnalysis.TabIndex = 23
        Me.AASGraphAnalysis.UseDefaultSettings = True
        Me.AASGraphAnalysis.XAxisDateMax = New Date(2007, 3, 15, 23, 59, 59, 0)
        Me.AASGraphAnalysis.XAxisDateMin = New Date(2007, 3, 15, 0, 0, 0, 0)
        Me.AASGraphAnalysis.XAxisDateScaleFormat = AAS203.AASGraph.enumDateScaleFormat.HHMM
        Me.AASGraphAnalysis.XAxisLabel = "TIME(seconds)"
        Me.AASGraphAnalysis.XAxisMax = 100.0R
        Me.AASGraphAnalysis.XAxisMin = 0R
        Me.AASGraphAnalysis.XAxisMinorStep = 5.0R
        Me.AASGraphAnalysis.XAxisScaleFormat = ""
        Me.AASGraphAnalysis.XAxisStep = 20.0R
        Me.AASGraphAnalysis.XAxisType = AldysGraph.AxisType.Linear
        Me.AASGraphAnalysis.YAxisLabel = "ABSORBANCE"
        Me.AASGraphAnalysis.YAxisMax = 0.8R
        Me.AASGraphAnalysis.YAxisMin = -0.2R
        Me.AASGraphAnalysis.YAxisMinorStep = 0.1R
        Me.AASGraphAnalysis.YAxisScaleFormat = Nothing
        Me.AASGraphAnalysis.YAxisStep = 0.2R
        Me.AASGraphAnalysis.YAxisType = AldysGraph.AxisType.Linear
        '
        'frmAnalysis
        '
        Me.CausesValidation = False
        Me.ClientSize = New System.Drawing.Size(804, 579)
        Me.Controls.Add(Me.CustomPanelMain)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.Name = "frmAnalysis"
        Me.Text = "Analysis"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.CustomPanelMain.ResumeLayout(False)
        Me.CustomPanelRight.ResumeLayout(False)
        Me.HeaderRight.ResumeLayout(False)
        Me.CustomPanel1.ResumeLayout(False)
        Me.CustomPanelRightBottom.ResumeLayout(False)
        Me.grpInstrument.ResumeLayout(False)
        Me.grpAnalysis.ResumeLayout(False)
        Me.custPnlASPMessages.ResumeLayout(False)
        Me.grpAbsorbanceValues.ResumeLayout(False)
        Me.CustomPanelRightTop.ResumeLayout(False)
        Me.CustomPanelLeft.ResumeLayout(False)
        CType(Me.XpPanelGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XpPanelGroup1.ResumeLayout(False)
        Me.RealPanel3.ResumeLayout(False)
        Me.RealPanel2.ResumeLayout(False)
        Me.RealPanel1.ResumeLayout(False)
        CType(Me.tmrAspirationMsg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Private Constants "

    Private ConstFormLoad As String = gstrTitleInstrumentType & "-Analysis"
    Private ConstParentFormLoad As String = gstrTitleInstrumentType & "-Method"


#End Region

#Region " Private Member Variables "
    Dim mxValue, mdblAvgAbs As Double

    Dim intDispCount As Integer
    Private mdblWvOpt As Double = -1.0
    'Private mblnIsAnalysisStarted As Boolean   'Saurabh  10.07.07
    Friend mblnIsAnalysisStarted As Boolean    'Saurabh  10.07.07  Commented to Check S/W hang
    Friend mblnIsCreateNewRunNo As Boolean = False
    Friend mblnExecuteRunNo As Boolean = False
    Private mblnIsAutosampler As Boolean
    Private EndAnalysis As Boolean = False
    Private mdblAbsorbance As Double

    Private mstrAspirationMessage As String
    Private mintAspirationTimerCounter As Integer
    Private mblnIsBlinkMessage As Boolean

    Private SampleType As ClsAAS203.enumSampleType = ClsAAS203.enumSampleType.BLANK
    Private LSampType As ClsAAS203.enumSampleType = ClsAAS203.enumSampleType.BLANK
    Private mobjParameters As New Spectrum.EnergySpectrumParameter

    Private mobjCurrentStandard As AAS203Library.Method.clsAnalysisStdParameters
    Private mobjCurrentSample As AAS203Library.Method.clsAnalysisSampleParameters


    Private mobjStandardEnumerator As IEnumerator
    Private mobjSampleEnumerator As IEnumerator

    Private mobjAnalysisRawData As New ANALYSIS.clsRawDataCollection
    Private mobjBlankRawData As ANALYSIS.clsRawData
    Private mobjStandardRawData As ANALYSIS.clsRawData
    Private mobjSampleRawData As ANALYSIS.clsRawData

    Private CurRepeat As Integer = 1

    Private StdAnalysed As Boolean = False
    Private mblnGetStandards As Boolean = False
    Private AnaOver As Boolean = False
    Private methchange As Boolean = False
    Private InQAnaRead As Boolean = False
    Private toreported As Boolean = False

    '---for checking the method is in analysis mode or not
    Public InAnalysis As Boolean = False
    Public exitbutton As Boolean = False
    Public ANALYSIS As Boolean

    Private mintSelectedInstrumentConditionIndex As Integer

    Private mobjGraphCurve As AldysGraph.CurveItem
    Private Afirst As Boolean

    Private mStartTime As Integer
    Private mEndTime As Integer

    Private XOld, YOld As Double

    Private Filter_flag As Boolean = True

    Private mdblBlankAbsorbance As Double = 0.0

    Public mblnIsStartRunNumber As Boolean = True      'Commented to Check S/W hang
    'Public mblnIsStartRunNumber As Boolean = False          

    '---For Background Worker Thread functions
    Private mController As clsBgThread

    'Public mobjBgReadData As New clsBgReadData
    Public mobjBgReadData As clsBgReadData

    '//----- Added by Sachin Dokhale
    'Private mMsgController As clsBgThread
    Public mobjBgMsgAspirate As AspirateMessage.clsMassageController
    '//-----

    Private mintRunNumberIndex As Integer

    Private mintSelectedMethodID As Integer     'Saurabh 
    Private mlngSelectedRunNumber As Long    'Saurabh
    Private mobjClsMethod As clsMethod          'Sauarbh

    Private mblnRepeatLastBlank As Boolean
    Private mblnRepeatLastStd As Boolean
    Private mblnRepeatLastSample As Boolean
    Private mblnRepeatResultStd As Boolean
    Private mblnRepeatResultSample As Boolean

    Private mobjClsDataFileReport As New clsDataFileReport 'Saurabh 07-06-2007
    Private intIEnumCollLocationStd As Integer
    Private intIEnumCollLocationSamp As Integer
    Private mblnAvoidProcessing As Boolean = False
    Private blnIsAspirateTimer As Boolean = False
    Dim blnIsLoadPreviousStandards As Boolean = False
    Public IsDisplayingMessage As Boolean = False
    Private mintTimeDelay As Integer = 1000
    Private mobjLastStandardData As clsAnalysisStdParameters
    Private mobjLastSampleData As clsAnalysisSampleParameters

    Private mintSelectedDemoFile As Integer = 0   '16.03.08

#End Region

#Region " Private Properties "

    Private Property AspirationMessage() As String
        Get
            Return mstrAspirationMessage
        End Get
        Set(ByVal Value As String)
            mstrAspirationMessage = Value
        End Set
    End Property

    Public Property IsAvoidProcessing() As Boolean
        Get
            Return mblnAvoidProcessing
        End Get
        Set(ByVal Value As Boolean)
            mblnAvoidProcessing = Value
        End Set
    End Property

#End Region

#Region " Form Load and Event Handling Functions "

    Private Sub frmAnalysis_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '=====================================================================
        ' Procedure Name        : frmAnalysis_Load
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To initialize the form
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati and Mangesh Shardul
        ' Created               : 07.10.06
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Application.DoEvents()
        Try
            'Dim BData As Byte
            'If (EnumErrorStatus.AA_CONNECTED) Then 'code commented by Mrutunjaya/Surajfor enabling reoptimize button in analysis screen
            '    btnReoptimize.Enabled = False
            'Else
            '    btnReoptimize.Enabled = True
            'End If
            ' Disable auto ignition/ extinguish button  for 201 
            If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
                btnIgnite.Enabled = False
                btnExtinguish.Enabled = False
            End If

            btnStdGraph.BringToFront()
            btnSplGraph.BringToFront()
            btnStdGraph.Focus()
            btnSave.Enabled = False
            'cmdChangeScale.Location = New Point(14, 378)
            'btnExportReport.Location = New Point(14, 419)
            'Me.FormBorderStyle = FormBorderStyle.FixedSingle
            'gobjMain.ShowProgressBar(ConstFormLoad)

            ' Init Reading thread
            mobjBgReadData = New clsBgReadData

            ' Add handlers of form object
            Call AddHandlers()
            '//----- Sachin Dokhale
            If Not (gobjNewMethod.OperationMode = EnumOperationMode.MODE_UVABS Or
                gobjNewMethod.OperationMode = EnumOperationMode.MODE_UVSPECT Or
                gobjNewMethod.OperationMode = EnumOperationMode.MODE_EMMISSION) Then
                ' Init graph coordinates for if opration mode is not UVABS/Spect and Emission mode
                ''-----Added By Pankaj on 10 May 2007
                AASGraphAnalysis.YAxisMin = -0.2
                AASGraphAnalysis.YAxisMax = 1.2
                gobjClsAAS203.Calculate_Analysis_Graph_Param(AASGraphAnalysis, ClsAAS203.enumChangeAxis.xyAxis)

                'Elseif Added by Saurabh
            ElseIf gobjNewMethod.OperationMode = EnumOperationMode.MODE_EMMISSION Then
                ' Init graph coordinates for if opration mode is Emission mode
                AASGraphAnalysis.YAxisMin = -10     'Changed from 0 to -10 by Saurabh 01.08.07
                AASGraphAnalysis.YAxisMax = 100
                'AASGraphAnalysis.YAxisStep = 10
                'AASGraphAnalysis.YAxisMinorStep = 10
                AASGraphAnalysis.YAxisLabel = "EMISSION"
                gobjClsAAS203.Calculate_Analysis_Graph_Param(AASGraphAnalysis, ClsAAS203.enumChangeAxis.xyAxis)
            Else
                ' Init graph coordinates for if opration mode is UVABS/Spect 
                cmdChangeScale.Enabled = False
                cmdChangeScale.Visible = False
                btnPrintGraph.Enabled = False
                btnPrintGraph.Visible = False
            End If

            ' Init. Aspiration messages
            'mMsgController = New clsBgThread(Me)
            mobjBgMsgAspirate = New AspirateMessage.clsMassageController(lblAspirationMessage)
            'mobjBgMsgAspirate.Initialize(mMsgController)
            If Not gobjNewMethod Is Nothing Then
                Dim objRow As DataRow
                objRow = gobjClsAAS203.funcGetMethodType(gobjNewMethod.OperationMode)
                HeaderRight.TitleText = CStr(objRow.Item("MethodType"))
            End If
            If (gstructAutoSampler.blnAutoSamplerInitialised = True) Then ''by Pankaj for autosampler on 10Sep 07
                mblnIsAutosampler = gstructAutoSampler.blnCommunication
            End If

            If gblnIsDemoWithRealData = True Then    '16.03.08
                Dim objele As New DataTable
                Dim strEleName As String
                objele = gobjClsAAS203.funcGetElement(gobjNewMethod.InstrumentCondition.ElementID)
                If Not objele Is Nothing Then
                    If objele.Rows.Count > 0 Then
                        strEleName = LCase(objele.Rows(0).Item("Name"))
                    End If
                End If
                Select Case strEleName
                    Case "cu"
                        mintSelectedDemoFile = 1
                    Case "pb"
                        mintSelectedDemoFile = 2
                    Case "zn"
                        mintSelectedDemoFile = 3
                End Select
            End If   '16.03.08

            '//-----
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
            'gobjMain.HideProgressBar()
            '---------------------------------------------------------
        End Try
    End Sub

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
            AddHandler btnStdGraph.Click, AddressOf tlbbtnStandardGraph_Click
            AddHandler btnSplGraph.Click, AddressOf tlbbtnSampleGraph_Click
            AddHandler btnViewResults.Click, AddressOf tlbbtnViewResults_Click
            AddHandler btnReports.Click, AddressOf tlbbtnReports_Click
            AddHandler btnSave.Click, AddressOf tlbbtnSave_Click
            AddHandler btnPrintGraph.Click, AddressOf tlbbtnPrintGraph_Click
            AddHandler btnImport.Click, AddressOf btnImport_Click
            AddHandler btnIgnite.Click, AddressOf btnIgnite_Click
            AddHandler btnExtinguish.Click, AddressOf btnExtinguish_Click
            AddHandler btnN2OIgnite.Click, AddressOf btnN2OIgnite_Click
            AddHandler btnDelete.Click, AddressOf btnDelete_Click
            AddHandler btnR.Click, AddressOf btnR_Click

            'Invisible Menu Items
            AddHandler mnuBack.Click, AddressOf tlbbtnBack_Click
            AddHandler mnuStandardGraph.Click, AddressOf tlbbtnStandardGraph_Click
            AddHandler mnuSampleGraph.Click, AddressOf tlbbtnSampleGraph_Click
            AddHandler mnuViewResults.Click, AddressOf tlbbtnViewResults_Click
            AddHandler mnuReports.Click, AddressOf tlbbtnReports_Click

            AddHandler btnNewAnalysis.Click, AddressOf NewAnalysis_Clicked
            AddHandler btnBlankAnalysis.Click, AddressOf BlankAnalysis_Clicked
            AddHandler btnNextAnalysis.Click, AddressOf NextAnalysis_Clicked
            AddHandler btnRepeatLast.Click, AddressOf RepeatLastAnalysis_Clicked
            AddHandler btnReoptimize.Click, AddressOf ReOptimizeInstrument_Clicked
            AddHandler btnSetup.Click, AddressOf ManualSetup_Clicked
            AddHandler btnAutoZero.Click, AddressOf AutoZero_Clicked

            AddHandler btnEditData.Click, AddressOf btnEditData_Clicked

            '---Start/Stop Analysis and Read Data during Aspiration Event functions 
            AddHandler btnStartStopAnalysis.Click, AddressOf StartStopAnalysis_Click
            AddHandler btnReadData.Click, AddressOf ReadData_Click
            AddHandler btnExportReport.Click, AddressOf btnExportReport_Click

            If blnIsAspirateTimer = False Then
                blnIsAspirateTimer = True
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

    'Private Sub tmrAspirationMsg_Elapsed(ByVal sender As System.Object, ByVal e As System.Timers.ElapsedEventArgs)
    '    '=====================================================================
    '    ' Procedure Name        : tmrAspirationMsg_Elapsed
    '    ' Parameters Passed     : sender As System.Object, System.Timers.ElapsedEventArgs
    '    ' Returns               : None
    '    ' Purpose               : Timer Aspiration Message events
    '    ' Description           : 
    '    ' Assumptions           : 
    '    ' Dependencies          : 
    '    ' Author                : Saurabh
    '    ' Created               : 05.10.06
    '    ' Revisions             : 
    '    '=====================================================================
    '    'case	WM_TIMER:
    '    '   tAsp++;
    '    '   If (tAsp > 1000) Then
    '    '       tAsp=1;
    '    '   if (tAsp%3==0)							
    '    '       ShowAspMessage(FALSE);
    '    '   Else
    '    '       ShowAspMessage(TRUE);
    '    'break;
    '    Try
    '        ' Application.DoEvents()
    '        mintAspirationTimerCounter += 1
    '        If (mintAspirationTimerCounter > 1000) Then
    '            mintAspirationTimerCounter = 1
    '        End If

    '        '---Saurabh---20.06.07
    '        'If btnReadData.Enabled = True Then
    '        '    btnReadData.Focus()
    '        '    btnReadData.Refresh()
    '        'End If
    '        'Application.DoEvents()
    '        'Saruabh

    '        If (mintAspirationTimerCounter Mod 3 = 0) Then
    '            If mblnIsBlinkMessage Then
    '                Call ShowAspirationMessages(False)
    '            Else
    '                Call ShowAspirationMessages(True)
    '            End If
    '            'Application.DoEvents()
    '        Else
    '            Call ShowAspirationMessages(True)
    '            'Application.DoEvents()
    '        End If
    '        'Application.DoEvents()
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

    Private Sub tlbbtnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : tlbbtnBack_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To exit frmAnalysis and load frmMDIMain form
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 25.09.06
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Try
            'tlbbtnBack.SuspendEvents()
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
            'tlbbtnBack.ResumeEvents()
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub tlbbtnStandardGraph_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : tlbbtnStandardGraph_Click
        ' Parameters Passed     : Object, EventArgs
        ' Returns               : None
        ' Purpose               : show the Standard graph
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 17-Jan-2007 03:25 pm
        ' Revisions             : 1
        '=====================================================================
        'case IDC_QASTDGRAPH:
        '   if (StdAnalysed || ManualEntry){
        '       If (Create_Standard_Sample_Curve(hwnd, False)) Then
        '           toreported=TRUE;
        '   }
        'break;

        Dim objWait As New CWaitCursor
        Dim intMethodID As Integer
        Try
            'tlbbtnStandardGraph.SuspendEvents()

            If StdAnalysed Then 'Or ManualEntry Then
                'If gobjclsStandardGraph.Create_Standard_Sample_Curve(False, True, 0, 0, gobjNewMethod) Then  '---commented for ver 4.90
                '    toreported = True
                'End If

                intMethodID = gobjNewMethod.MethodID  '---added for version 4.90

                '---added for ver 4.90
                If gobjclsStandardGraph.Create_Standard_Sample_Curve(False, True, intMethodID, mlngSelectedRunNumber, gobjNewMethod) Then
                    toreported = True
                End If
                '------

            End If
            If btnReadData.Enabled Then
                btnReadData.Focus()
                btnReadData.Refresh()
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
            'tlbbtnStandardGraph.ResumeEvents()
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub tlbbtnSampleGraph_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : tlbbtnSampleGraph_Click
        ' Parameters Passed     : Object, EventArgs
        ' Returns               : None
        ' Purpose               : Show the Sample graph
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 17-Jan-2007 03:25 pm
        ' Revisions             : 1
        '=====================================================================
        'case IDC_QASAMPGRAPH:
        '   if (StdAnalysed || ManualEntry){
        '       If (Create_Standard_Sample_Curve(hwnd, TRUE)) Then
        '	        toreported=TRUE;
        '   }
        '   break;

        Dim objWait As New CWaitCursor
        Dim intMethodID As Integer
        Try
            'tlbbtnSampleGraph.SuspendEvents()

            intMethodID = gobjNewMethod.MethodID  '---added for version 4.90

            If StdAnalysed Then 'Or ManualEntry Then
                'If gobjclsStandardGraph.Create_Standard_Sample_Curve(True, True, 0, 0, gobjNewMethod) Then  '---commented for version 4.90
                '    toreported = True
                'End If

                '---added for version 4.90
                If gobjclsStandardGraph.Create_Standard_Sample_Curve(True, True, intMethodID, mlngSelectedRunNumber, gobjNewMethod) Then
                    toreported = True
                End If
                '--------

            End If
            If btnReadData.Enabled Then
                btnReadData.Focus()
                btnReadData.Refresh()
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
            'tlbbtnSampleGraph.ResumeEvents()
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub tlbbtnViewResults_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : tlbbtnViewResults_Click
        ' Parameters Passed     : Object, EventArgs
        ' Returns               : None
        ' Purpose               : View analysis report in Listview
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 17-Jan-2007 03:25 pm
        ' Revisions             : 1
        '=====================================================================
        'case IDC_QARESULTS:
        'if (StdAnalysed||AnaOver ||Started ||ManualEntry)
        ' OnViewResults(hwnd);
        'break;

        Dim objWait As New CWaitCursor

        Try
            'tlbbtnViewResults.SuspendEvents()
            ' View analysis report in Listview if analysis is complite
            If StdAnalysed Or AnaOver Or mblnIsAnalysisStarted Then 'Or ManualEntry Then
                OnViewResults()
            End If
            If btnReadData.Enabled Then
                btnReadData.Focus()
                btnReadData.Refresh()
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
            'tlbbtnViewResults.ResumeEvents()
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub tlbbtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : tlbbtnReports_Click
        ' Parameters Passed     : Object, EventArgs
        ' Returns               : None
        ' Purpose               : Save the Quant. analysis result 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 17-Jan-2007 03:25 pm
        ' Revisions             : 1
        '=====================================================================

        'case IDC_QAREPORT:
        '   if (toreported||!Method->RepReady )
        '	{
        '	    SaveQuantResults(hwnd, Method, A1,0);
        '	    toreported=FALSE;
        '	}
        '	if (Method->RepReady )
        '	    OnReportPrint(hwnd, Method);
        '   break;

        Dim objWait As New CWaitCursor
        Dim A1() As Double = {0, 0, 0, 0, 0, 0}

        Try
            ' check "toreported" to store the report of quantity result
            If (toreported) Then 'OR NOT Method->RepReady )
                'Save the Quant. data result into Method Data object
                If gobjClsAAS203.SaveQuantResults(gobjNewMethod, A1, 0, False) = True Then

                    'Onecs data result is store  then
                    ' toreported var. is set to false to avoide resundancy of data storing
                    'toreported = False
                    mblnIsStartRunNumber = True
                End If
                toreported = False
            End If

            gobjClsAAS203.funcSave_Fuel_Conditions() '---30.04.10

            If btnReadData.Enabled Then
                btnReadData.Focus()
                btnReadData.Refresh()
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
            'tlbbtnReports.ResumeEvents()
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub tlbbtnReports_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : tlbbtnReports_Click
        ' Parameters Passed     : Object, EventArgs
        ' Returns               : None
        ' Purpose               : Show the Analysis Report
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 17-Jan-2007 03:25 pm
        ' Revisions             : 1
        '=====================================================================

        'case IDC_QAREPORT:
        '   if (toreported||!Method->RepReady )
        '	{
        '	    SaveQuantResults(hwnd, Method, A1,0);
        '	    toreported=FALSE;
        '	}
        '	if (Method->RepReady )
        '	    OnReportPrint(hwnd, Method);
        '   break;

        Dim objWait As New CWaitCursor
        Dim objClsDataFileReport As New clsDataFileReport
        Dim intSelectIDIndex As Integer
        Dim intCount As Integer
        Dim intSelectedRunNumber As Integer
        Dim intSelectedMethodID As Integer
        Dim A1() As Double = {0, 0, 0, 0, 0, 0}

        Try

            'If toreported Then
            ' Check 21 CFR 
            '-----Added By Pankaj Fri 18 May 07
            If (gstructSettings.Enable21CFR = True) Then
                If Not funcCheckActivityAuthentication(enumActivityAuthentication.Print, gstructUserDetails.Access) Then
                    Return
                    Exit Sub
                End If
                gfuncInsertActivityLog(EnumModules.Print, "Print Analysis Report Accessed")
            End If
            '------
            'tlbbtnLoad.SuspendEvents()
            ' Save Quant analysis data
            If (toreported) Then 'OR NOT Method->RepReady )
                If gobjClsAAS203.SaveQuantResults(gobjNewMethod, A1, 1, False) = True Then
                    mblnIsStartRunNumber = True
                End If
                toreported = False
                'mblnIsStartRunNumber = True
            End If


            '----Be Careful NOT TO USE index to assign MethodID or RunNumber

            If StdAnalysed Or AnaOver Or mblnIsAnalysisStarted Then
                If Not (gobjNewMethod Is Nothing) Then
                    For intCount = 0 To gobjMethodCollection.Count - 1
                        If gobjNewMethod.MethodID = gobjMethodCollection(intCount).MethodID Then
                            intSelectIDIndex = intCount
                            'mobjClsDataFileReport.MethodID = intCount
                            objClsDataFileReport.MethodID = gobjMethodCollection(intCount).MethodID
                            Exit For
                        End If
                    Next

                    objClsDataFileReport.RunNumber = gobjMethodCollection(intCount).QuantitativeDataCollection(mintRunNumberIndex).RunNumber   'intSelectedRunNumber - 1

                    objClsDataFileReport.DefaultFont = Me.DefaultFont
                    ' print data report from Data file report object
                    Call objClsDataFileReport.funcDatafilePrint()
                End If
            End If
            If btnReadData.Enabled Then
                btnReadData.Focus()
                btnReadData.Refresh()
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
            'tlbbtnReports.ResumeEvents()
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub tlbbtnPrintGraph_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : tlbbtnPrintGraph_Click
        ' Parameters Passed     : Object, EventArgs
        ' Returns               : None
        ' Purpose               : Print the Histograph
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 17-May-2007 03:25 pm
        ' Revisions             : 1
        '=====================================================================



        Dim objWait As New CWaitCursor
        Dim A1() As Double = {0, 0, 0, 0, 0, 0}

        Try
            ' Check for 21 CFR 
            '-----Added By Pankaj Fri 18 May 07
            If (gstructSettings.Enable21CFR = True) Then
                If Not funcCheckActivityAuthentication(enumActivityAuthentication.Print, gstructUserDetails.Access) Then
                    Return
                    Exit Sub
                End If
                gfuncInsertActivityLog(EnumModules.Print, "Print Analysis Graph Accessed")
            End If
            '------

            'If (toreported) Then 'OR NOT Method->RepReady )
            '    gobjClsAAS203.SaveQuantResults(gobjNewMethod, A1, False)
            '    toreported = False

            'End If
            'If StdAnalysed Or AnaOver Or mblnIsAnalysisStarted Then By Sachin
            'AASGraphAnalysis.PrintPreViewGraph()
            '-----Added By Pankaj Fri 14 Aug 07
            Dim mintRunNumberIndex As Integer
            'Print the Histograph
            '---For Data Files Mode
            mintRunNumberIndex = gobjNewMethod.QuantitativeDataCollection.Count - 1
            mobjClsDataFileReport.RunNumber = gobjNewMethod.QuantitativeDataCollection(mintRunNumberIndex).RunNumber
            mobjClsDataFileReport.DefaultFont = Me.DefaultFont
            Call mobjClsDataFileReport.funcHistographPrint(AASGraphAnalysis, gobjNewMethod)
            '------------

            If btnReadData.Enabled Then
                btnReadData.Focus()
                btnReadData.Refresh()
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
            'tlbbtnSampleGraph.ResumeEvents()
            '---------------------------------------------------------
        End Try
    End Sub

    'Private Sub XpPanelStandardGraphClicked(ByVal sender As Object, ByVal e As System.EventArgs)
    '    '=====================================================================
    '    ' Procedure Name        : XpPanelStandardGraphClicked
    '    ' Parameters Passed     : Object,EventArgs
    '    ' Returns               : None
    '    ' Purpose               : To load the Standard Graph form
    '    ' Description           : 
    '    ' Assumptions           : 
    '    ' Dependencies          : 
    '    ' Author                : Deepak & Saurabh
    '    ' Created               : 05.10.06
    '    ' Revisions             : 
    '    '===================================================================== 
    '    Dim objWait As New CWaitCursor

    '    Try
    '        If Me.XpPanelStandardGraph.PanelState = UIComponents.XPPanelState.Collapsed Then
    '            Call funcCollapseAllXPPanels()
    '            Me.XpPanelStandardGraph.TogglePanelState()
    '            Me.XpPanelStandardGraph.PanelHeight = 80
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
    '        If Not objWait Is Nothing Then
    '            objWait.Dispose()
    '        End If
    '        '---------------------------------------------------------
    '    End Try
    'End Sub

    'Private Sub XpPanelSampleGraphClicked(ByVal sender As Object, ByVal e As System.EventArgs)
    '    '=====================================================================
    '    ' Procedure Name        : XpPanelSampleGraphClicked
    '    ' Parameters Passed     : Object,EventArgs
    '    ' Returns               : None
    '    ' Purpose               : To view the Sample Graphs
    '    ' Description           : 
    '    ' Assumptions           : 
    '    ' Dependencies          : 
    '    ' Author                : Deepak & Saurabh
    '    ' Created               : 05.10.06
    '    ' Revisions             : 
    '    '===================================================================== 
    '    Dim objWait As New CWaitCursor

    '    Try
    '        If Me.XpPanelSampleGraph.PanelState = UIComponents.XPPanelState.Collapsed Then
    '            Call funcCollapseAllXPPanels()
    '            Me.XpPanelSampleGraph.TogglePanelState()
    '            Me.XpPanelSampleGraph.PanelHeight = 90
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
    '        If Not objWait Is Nothing Then
    '            objWait.Dispose()
    '        End If
    '        '---------------------------------------------------------
    '    End Try
    'End Sub

    'Private Sub XpPanelViewResultsClicked(ByVal sender As Object, ByVal e As System.EventArgs)
    '    '=====================================================================
    '    ' Procedure Name        : XpPanelViewResultsClicked
    '    ' Parameters Passed     : Object,EventArgs
    '    ' Returns               : None
    '    ' Purpose               : To view the Results
    '    ' Description           : 
    '    ' Assumptions           : 
    '    ' Dependencies          : 
    '    ' Author                : Deepak & Saurabh
    '    ' Created               : 05.10.06
    '    ' Revisions             : 
    '    '===================================================================== 
    '    Dim objWait As New CWaitCursor

    '    Try
    '        If Me.XpPanelViewResults.PanelState = UIComponents.XPPanelState.Collapsed Then
    '            Call funcCollapseAllXPPanels()
    '            Me.XpPanelViewResults.TogglePanelState()
    '            Me.XpPanelViewResults.PanelHeight = 80
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
    '        If Not objWait Is Nothing Then
    '            objWait.Dispose()
    '        End If
    '        '---------------------------------------------------------
    '    End Try
    'End Sub

    'Private Sub XpPanelReportsClicked(ByVal sender As Object, ByVal e As System.EventArgs)
    '    '=====================================================================
    '    ' Procedure Name        : XpPanelReportsClicked
    '    ' Parameters Passed     : Object,EventArgs
    '    ' Returns               : None
    '    ' Purpose               : To view the Reports
    '    ' Description           : 
    '    ' Assumptions           : 
    '    ' Dependencies          : 
    '    ' Author                : Deepak & Saurabh
    '    ' Created               : 05.10.06
    '    ' Revisions             : 
    '    '===================================================================== 
    '    Dim objWait As New CWaitCursor
    '    Try
    '        If Me.XpPanelReports.PanelState = UIComponents.XPPanelState.Collapsed Then
    '            Call funcCollapseAllXPPanels()
    '            Me.XpPanelReports.TogglePanelState()
    '            Me.XpPanelReports.PanelHeight = 80
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
    '        If Not objWait Is Nothing Then
    '            objWait.Dispose()
    '        End If
    '        '---------------------------------------------------------
    '    End Try
    'End Sub

    Private Sub AutoZero_Clicked(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : AutoZero_Clicked
        ' Parameters Passed     : Object, EventArgs
        ' Returns               : None
        ' Purpose               : Start to Autozero
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 17-Jan-2007 03:25 pm
        ' Revisions             : 1
        '=====================================================================

        'case IDC_AUTOZERO:
        '   Auto_Zero(hwnd, FALSE);
        '   break;
        If mblnAvoidProcessing = True Then
            Exit Sub
        End If
        Try
            mblnAvoidProcessing = True
            '//----- Commented by Sachin Dokhale
            '//----- use Thread except timer for apirate message
            'tmrAspirationMsg.Enabled = False
            mobjBgMsgAspirate.Cancel()
            IsDisplayingMessage = mobjBgMsgAspirate.IsMessageRunning
            'If gobjMain.mobjController.IsThreadRunning = True Then  '10.12.07
            gobjMain.mobjController.Cancel()
            Application.DoEvents()
            gobjCommProtocol.mobjCommdll.subTime_Delay(500)   '10.12.07
            Application.DoEvents()
            'End If

            'Start to Autozero Set bool flag to False
            Call gobjClsAAS203.subAutoZero(False)

            mobjBgMsgAspirate.Start()
            IsDisplayingMessage = mobjBgMsgAspirate.IsMessageRunning
            If gobjMain.mobjController.IsThreadRunning = False Then
                gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay)
                Application.DoEvents()
                gobjMain.mobjController.Start(gobjclsBgFlameStatus)
            End If
            If btnReadData.Enabled Then
                btnReadData.Focus()
                btnReadData.Refresh()
            End If
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
            '//----- Commented by Sachin Dokhale
            '//----- use Thread except timer for apirate message
            'tmrAspirationMsg.Enabled = True

            'mblnAvoidProcessing = False
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub ManualSetup_Clicked(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : ManualSetup_Clicked
        ' Parameters Passed     : Object, EventArgs
        ' Returns               : None
        ' Purpose               : Manual Setup of instrument
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 17-Jan-2007 03:25 pm
        ' Revisions             : 1
        '=====================================================================
        If mblnAvoidProcessing = True Then
            Exit Sub
        End If
        Try
            '//----- Commented by Sachin Dokhale
            '//----- use Thread except timer for apirate message
            'tmrAspirationMsg.Enabled = False
            mblnAvoidProcessing = True
            mobjBgMsgAspirate.Cancel()
            gobjclsTimer.subTimerStop()
            IsDisplayingMessage = mobjBgMsgAspirate.IsMessageRunning
            'If gobjMain.mobjController.IsThreadRunning = True Then
            gobjMain.mobjController.Cancel()
            gobjCommProtocol.mobjCommdll.subTime_Delay(500)   '10.12.07
            Application.DoEvents()
            'End If


            '---Manual Optimization or Instrument Setup
            Call gobjClsAAS203.AbsorbanceScan()

            'gobjclsTimer.subTimerStart(StatusBar1)
            'mblnAvoidProcessing = False

            mobjBgMsgAspirate.Start()
            IsDisplayingMessage = mobjBgMsgAspirate.IsMessageRunning
            'gobjclsTimer.subTimerStart()
            'mblnAvoidProcessing = False
            '//-----
            If gobjMain.mobjController.IsThreadRunning = False Then
                gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay)
                Application.DoEvents()
                gobjMain.mobjController.Start(gobjclsBgFlameStatus)
            End If
            If btnReadData.Enabled Then
                btnReadData.Focus()
                btnReadData.Refresh()
            End If
            If gobjclsTimer.TimerStatus = False Then
                gobjclsTimer.subTimerStart(gobjMain.StatusBar1)
            End If
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
            '//----- Commented by Sachin Dokhale
            '//----- use Thread except timer for apirate message
            'tmrAspirationMsg.Enabled = True

            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub ReOptimizeInstrument_Clicked(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : ReOptimizeInstrument_Clicked
        ' Parameters Passed     : Object, EventArgs
        ' Returns               : None
        ' Purpose               : ReOptimize Wavelength i.e. Find Analytical Peak Again
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 17-Jan-2007 03:25 pm
        ' Revisions             : 1
        '=====================================================================
        '---ReOptimize Wavelength i.e. Find Analytical Peak Again
        'case IDC_OPTIMIZE:
        '   Method->Aas.OptimseFlag=FALSE;
        '   CheckInstrumentOptimisation(hwnd);
        '   break;
        If mblnAvoidProcessing = True Then
            Exit Sub
        End If
        Try
            mblnAvoidProcessing = True
            '//----- Commented by Sachin Dokhale
            '//----- use Thread except timer for apirate message
            'tmrAspirationMsg.Enabled = False
            mobjBgMsgAspirate.Cancel()
            IsDisplayingMessage = mobjBgMsgAspirate.IsMessageRunning
            '//-----
            'If gobjMain.mobjController.IsThreadRunning = True Then
            gobjMain.mobjController.Cancel()
            gobjCommProtocol.mobjCommdll.subTime_Delay(500)   '10.12.07
            Application.DoEvents()
            'End If

            'gobjNewMethod.InstrumentConditions.item(mintSelectedInstrumentConditionIndex).IsOptimize = False
            gobjNewMethod.InstrumentCondition.IsOptimize = False
            ' Start to find Analytical Peak 

            Call CheckInstrumentOptimisation()
            mobjBgMsgAspirate.Start()
            IsDisplayingMessage = mobjBgMsgAspirate.IsMessageRunning

            '//-----
            'start flame status thread
            If gobjMain.mobjController.IsThreadRunning = False Then
                gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay)
                Application.DoEvents()
                gobjMain.mobjController.Start(gobjclsBgFlameStatus)
            End If
            If btnReadData.Enabled Then
                btnReadData.Focus()
                btnReadData.Refresh()
            End If
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
            '//----- Commented by Sachin Dokhale
            '//----- use Thread except timer for apirate message
            'tmrAspirationMsg.Enabled = True

            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub RepeatLastAnalysis_Clicked(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : RepeatLastAnalysis_Clicked
        ' Parameters Passed     : Object, EventArgs
        ' Returns               : None
        ' Purpose               : Repat the last analysis
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 17-Jan-2007 03:25 pm
        ' Revisions             : 1
        '=====================================================================
        '**************************************************************
        'case IDC_QARPT:
        '   if(LSampType != BLANK )
        '	    CurRepeat--;
        '	if(CurRepeat <= 0 ){
        '	    if(LSampType == SAMP)
        '		    CurRepeat = Method->QuantData->Param.Repeat; //mdf by sss
        '		if(LSampType == STD)
        '		    CurRepeat = Method->QuantData->Param.ConcRepeat; //mdf by sss
        '	}
        '	if (SampType==BLANK && LSampType==BLANK){
        '	    if (CurStd==NULL){
        '		    SampType=SAMP;
        '       }
        '		else{
        '		    SampType=STD;
        '       }
        '   }
        '	else{
        '	    SampType=LSampType;
        '	}
        '	if (SampType==SAMP){
        '       CurSamp = GetPrevSamp(Method->QuantData->SampTopData, CurSamp);
        '	}
        '	if (SampType==STD)
        '	    CurStd = GetPrevStd(Method->QuantData->StdTopData, CurStd);
        '	if (SampType==BLANK){
        '	    if (CurStd==NULL)
        '		    LSampType=SAMP;
        '       Else
        '		    LSampType=BLANK;
        '	}
        '	else
        '	    LSampType=BLANK;
        'EnableWindow(GetDlgItem(hwnd,IDC_QARPT),FALSE);
        '**************************************************************
        If mblnAvoidProcessing = True Then
            Exit Sub
        End If
        Try
            mblnAvoidProcessing = True
            'Added By Pankaj on 11 Jun 07 
            'If intIEnumCollLocationSamp > 0 Then
            '    If funcMoveSampleEnumerator(mobjSampleEnumerator, intIEnumCollLocationSamp) = True Then
            '        mobjCurrentSample = CType(mobjSampleEnumerator.Current, Method.clsAnalysisSampleParameters)
            '    End If
            'End If
            'If intIEnumCollLocationStd > 0 Then
            '    If funcMoveEnumerator(mobjStandardEnumerator, intIEnumCollLocationStd) = True Then
            '        mobjCurrentStandard = CType(mobjStandardEnumerator.Current, Method.clsAnalysisStdParameters)
            '    End If
            'End If
            'Call funcRefreshEnumerators(mobjStandardEnumerator, mobjSampleEnumerator)

            '-----
            ' last sample type is not Blank then Set the previous no for current repeat
            If (LSampType <> ClsAAS203.enumSampleType.BLANK) Then
                CurRepeat -= 1
            End If

            If (CurRepeat <= 0) Then
                If (LSampType = ClsAAS203.enumSampleType.SAMPLE) Then
                    'CurRepeat = Method->QuantData->Param.Repeat
                    CurRepeat = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfSampleRepeats
                End If
                If (LSampType = ClsAAS203.enumSampleType.STANDARD) Then
                    'CurRepeat = Method->QuantData->Param.ConcRepeat
                    CurRepeat = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfStdRepeats
                End If
            End If

            If (SampleType = ClsAAS203.enumSampleType.BLANK _
             And LSampType = ClsAAS203.enumSampleType.BLANK) Then

                If IsNothing(mobjCurrentStandard) Then
                    SampleType = ClsAAS203.enumSampleType.SAMPLE
                Else
                    SampleType = ClsAAS203.enumSampleType.STANDARD
                End If

            Else
                SampleType = LSampType
            End If
            '//--------
            ' Get previous Sample from method object
            '//------------
            If (SampleType = ClsAAS203.enumSampleType.SAMPLE) Then
                'mobjCurrentSample = GetPrevSamp(Method->QuantData->SampTopData, mobjCurrentSample  )
                'If Not (mobjCurrentSample Is Nothing) Then
                '    mobjCurrentSample = GetPrevSamp(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection, mobjCurrentSample)
                'Else
                '    Dim intSampColl As Integer
                '    intSampColl = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.Count
                '    If intSampColl > 0 Then
                '        mobjCurrentSample = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection(intSampColl - 1)
                '    End If
                'End If
                mobjCurrentSample = GetPrevSamp(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection, mobjLastSampleData)
                'mobjCurrentSample = GetPrevSamp(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection, mobjCurrentSample)
                'mblnRepeatLastSample = True
                If gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfSampleRepeats > 1 Then
                    mblnRepeatResultSample = True
                Else
                    mblnRepeatLastSample = True
                End If
            End If
            ' Get previous stadard from method object
            If (SampleType = ClsAAS203.enumSampleType.STANDARD) Then
                'mobjCurrentStandard = GetPrevStd(Method->QuantData->StdTopData,  mobjCurrentStandard )
                'If Not (mobjCurrentStandard Is Nothing) Then
                '    mobjCurrentStandard = GetPrevStd(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection, mobjLastStandardData)
                'Else
                '    Dim intStdColl As Integer
                '    intStdColl = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.Count
                '    If intStdColl > 0 Then
                '        mobjCurrentStandard = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection(intStdColl - 1)
                '    End If
                'End If
                mobjCurrentStandard = GetPrevStd(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection, mobjLastStandardData)
                'mblnRepeatLastStd = True
                If gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfStdRepeats > 1 Then
                    mblnRepeatResultStd = True
                Else
                    mblnRepeatLastStd = True
                End If

                '---added by Deepak on 26.07.09 with ref vck/ramesh
                If gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfStdRepeats = 1 Then
                    mblnRepeatResultStd = True
                End If
                '--------

            End If

            If (SampleType = ClsAAS203.enumSampleType.BLANK) Then
                If IsNothing(mobjCurrentStandard) Then
                    LSampType = ClsAAS203.enumSampleType.SAMPLE
                Else
                    LSampType = ClsAAS203.enumSampleType.BLANK
                End If
            Else
                LSampType = ClsAAS203.enumSampleType.BLANK
            End If

            'EnableWindow(GetDlgItem(hwnd,IDC_QARPT),FALSE);

            'tlbbtnRepeatLastAnalysis.Enabled = False
            btnRepeatLast.Enabled = False

            Call Aspirate()
            If btnReadData.Enabled Then
                btnReadData.Focus()
                btnReadData.Refresh()
            End If
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
            '---------------------------------------------------------
        End Try
    End Sub

    'Private Sub NewAnalysis_Clicked(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    'case	IDC_QANEW:
    '    '#If STD_ADDN Then
    '    '   endanalysis= FALSE;
    '    '#End If
    '    'DeleteAllRawData(FALSE);
    '    'mobjCurrentStandard  =Method->QuantData->StdTopData;
    '    'mobjCurrentSample =Method->QuantData->SampTopData;
    '    'CurRepeat=1;

    '    'if(mobjCurrentStandard!=NULL  && StdAnalysed)
    '    '{
    '    '   if(Method->QuantData->Param.Std_Addn)
    '    '	    i = IDNO;
    '    '	else{
    '    '       If (!methchange) Then        
    '    '		    i=MessageBox(hwnd,"Do you want to use the previous standards","INFORMATION", MB_ICONQUESTION | MB_YESNO);
    '    '		else
    '    '		    i=IDNO;
    '    '   }
    '    'if(i==IDNO)
    '    '   Clear_All_Abs_Std(Method->QuantData->StdTopData);
    '    'Else
    '    '   mobjCurrentStandard=NULL;
    '    '}
    '    'methchange = FALSE;	
    '    'if(!StdAnalysed) 
    '    '   Clear_All_Abs_Std(Method->QuantData->StdTopData);
    '    'Clear_All_Abs_Conc_Samp(Method->QuantData->SampTopData);
    '    'SampType=BLANK;
    '    'Xtime=0;Afirst=TRUE;
    '    '	
    '    'if(i==6)
    '    '   StdAnalysed =TRUE;
    '    'Else
    '    '	StdAnalysed =FALSE;
    '    'Method->RepReady=FALSE;
    '    'if (lParam!=100L){
    '    '   AppendMethod(Method, QALL);
    '    '	Method->QuantData->Fname =-1.0;
    '    '}
    '    'if (Method->QuantData->Fname<=0)
    '    '   GetRunNo(Method);
    '    'AnaGraph.Xmin=0; AnaGraph.Xmax=10*10.0;
    '    'Calculate_Analysis_Graph_Param(&AnaGraph);
    '    'AnaOver=FALSE;
    '    'if (hwnd){
    '    '   DisplayRunNo(hwnd);
    '    '	InvalidateRect(hwnd, NULL, TRUE);
    '    '}
    '    'Method->QuantData->cMode=-2;

    '    'EnableWindow(GetDlgItem(hwnd,IDC_QARPT),FALSE); // add by sss
    '    'if(Method->QuantData)
    '    '   aafname = Method->QuantData->Fname;
    '    'break;

    '    '*****************************************
    '    '---CODE BY MANGESH 
    '    '*****************************************
    '    'On NEW Analysis
    '    Dim dblFuelRatio As Double
    '    Dim objDlgResult As DialogResult

    '    Try
    '        '----added by deepak for new analysis on 28.04.07
    '        lblAbsorbance.Text = ""
    '        lblAverageAbsorbance.Text = ""
    '        lblCorrectedAbsorbance.Text = ""
    '        lblSampleID.Text = ""
    '        lblRepeatNo.Text = ""
    '        lblConcentration.Text = ""
    '        '------------------

    '        gobjclsStandardGraph = New clsStandardGraph

    '        '---Get the last RunNumber 

    '        If gobjNewMethod.QuantitativeDataCollection.Count > 0 Then
    '            mintRunNumberIndex = gobjNewMethod.QuantitativeDataCollection.Count - 1
    '        ElseIf gobjNewMethod.QuantitativeDataCollection.Count <= 0 Then
    '            mintRunNumberIndex = -1
    '        End If

    '        If gobjNewMethod.StandardAddition Then
    '            EndAnalysis = False
    '        End If

    '        'DeleteAllRawData(False)
    '        mobjAnalysisRawData.Clear()
    '        mobjBlankRawData = Nothing
    '        mobjStandardRawData = Nothing
    '        mobjSampleRawData = Nothing

    '        '*************************************************************************
    '        '---- Commented by Mangesh on 10-May-2007
    '        '*************************************************************************
    '        '---Gets the First Standard from Standard Collection
    '        If Not IsNothing(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection) Then
    '            mobjStandardEnumerator = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.GetEnumerator()
    '            mobjStandardEnumerator.Reset()
    '            intIEnumCollLocationStd = 0
    '            If mobjStandardEnumerator.MoveNext() Then
    '                intIEnumCollLocationStd = 1
    '                mobjCurrentStandard = CType(mobjStandardEnumerator.Current(), Method.clsAnalysisStdParameters)
    '            End If
    '        End If

    '        '---Gets the First Sample from Sample Collection
    '        If Not IsNothing(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection) Then
    '            mobjSampleEnumerator = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.GetEnumerator()
    '            mobjSampleEnumerator.Reset()
    '            intIEnumCollLocationSamp = 0
    '            If mobjSampleEnumerator.MoveNext() Then
    '                intIEnumCollLocationSamp = 1
    '                mobjCurrentSample = CType(mobjSampleEnumerator.Current(), Method.clsAnalysisSampleParameters)
    '            End If
    '        End If
    '        '*************************************************************************

    '        CurRepeat = 1

    '        If ((Not IsNothing(mobjCurrentStandard)) And StdAnalysed) Then
    '            If (gobjNewMethod.StandardAddition) Then
    '                objDlgResult = DialogResult.No
    '            Else
    '                If Not (methchange) Then
    '                    If gobjMessageAdapter.ShowMessage(constPreviousStandards) Then
    '                        objDlgResult = DialogResult.Yes
    '                    Else
    '                        objDlgResult = DialogResult.No
    '                    End If
    '                Else
    '                    objDlgResult = DialogResult.No
    '                End If
    '            End If
    '            'Comment & move by Pankaj on 08 Jun 07 
    '            'If (objDlgResult = DialogResult.No) Then
    '            '    Clear_All_Abs_Std(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection)
    '            'Else
    '            '    mobjCurrentStandard = Nothing
    '            'End If
    '            '------
    '        End If
    '        methchange = False

    '        If Not (StdAnalysed) Then  '---for removing uncompleted std analysis
    '            Call Clear_All_Abs_Std(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection)
    '        End If
    '        'Moved By Pankaj  on 09 Jun 07
    '        'Call Clear_All_Abs_Conc_Samp(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection)


    '        SampleType = ClsAAS203.enumSampleType.BLANK

    '        Afirst = True
    '        mStartTime = 0.0
    '        mEndTime = mStartTime + 100

    '        'if(i==6)
    '        '   StdAnalysed =TRUE;
    '        'Else
    '        '	StdAnalysed =FALSE;

    '        'Comment & move by Pankaj 08 Jun 06 
    '        'If (objDlgResult = DialogResult.Yes) Then
    '        '    StdAnalysed = True
    '        'Else
    '        '    StdAnalysed = False
    '        'End If
    '        '---------

    '        'gobjNewMethod.AnalysisParameters.RepReady = False

    '        If (mblnIsStartRunNumber) Then
    '            'AppendMethod(Method, QALL)

    '            If (CInt(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).RunNumber) >= 0) Then
    '                Dim objclsQuantitativeData As AAS203Library.Method.clsQuantitativeData
    '                objclsQuantitativeData = New AAS203Library.Method.clsQuantitativeData
    '                objclsQuantitativeData.AnalysisParameters = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.Clone()
    '                objclsQuantitativeData.ReportParameters = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).ReportParameters.Clone()
    '                objclsQuantitativeData.StandardDataCollection = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.Clone()
    '                objclsQuantitativeData.SampleDataCollection = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.Clone()
    '                objclsQuantitativeData.CalculationMode = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).CalculationMode
    '                gobjNewMethod.QuantitativeDataCollection.Add(objclsQuantitativeData)
    '                mintRunNumberIndex += 1
    '                gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).RunNumber = -1.0
    '            End If
    '            mblnIsStartRunNumber = False
    '        End If
    '        'Added By Pankaj on 08 Jun 07
    '        If ((Not IsNothing(mobjCurrentStandard)) And StdAnalysed) Then
    '            If (objDlgResult = DialogResult.No) Then
    '                Clear_All_Abs_Std(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection)
    '            Else
    '                mobjCurrentStandard = Nothing
    '            End If
    '        End If
    '        Call Clear_All_Abs_Conc_Samp(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection)
    '        '------------------
    '        'Comment & move by Pankaj 08 Jun 06 
    '        If (objDlgResult = DialogResult.Yes) Then
    '            StdAnalysed = True
    '        Else
    '            StdAnalysed = False
    '        End If
    '        '---------
    '        If (CInt(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).RunNumber) <= 0) Then
    '            Call GetRunNo(gobjNewMethod)
    '        End If

    '        '*************************************************************************
    '        '---- Added by Mangesh on 10-May-2007
    '        '*************************************************************************
    '        '---Gets the First Standard from Standard Collection
    '        If Not IsNothing(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection) Then
    '            mobjStandardEnumerator = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.GetEnumerator()
    '            mobjStandardEnumerator.Reset()
    '            intIEnumCollLocationStd = 0
    '            If mobjStandardEnumerator.MoveNext() Then
    '                intIEnumCollLocationStd = 1
    '                mobjCurrentStandard = CType(mobjStandardEnumerator.Current(), Method.clsAnalysisStdParameters)
    '            End If
    '        End If

    '        '---Gets the First Sample from Sample Collection
    '        If Not IsNothing(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection) Then
    '            mobjSampleEnumerator = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.GetEnumerator()
    '            mobjSampleEnumerator.Reset()
    '            intIEnumCollLocationSamp = 0
    '            If mobjSampleEnumerator.MoveNext() Then
    '                intIEnumCollLocationSamp = 1
    '                mobjCurrentSample = CType(mobjSampleEnumerator.Current(), Method.clsAnalysisSampleParameters)
    '            End If
    '        End If

    '        If (objDlgResult = DialogResult.Yes) Then
    '            mobjCurrentStandard = Nothing
    '        End If
    '        '*************************************************************************

    '        If AASGraphAnalysis.AldysPane.CurveList.Count > 0 Then
    '            AASGraphAnalysis.AldysPane.CurveList.Clear()

    '            AASGraphAnalysis.AldysPane.AxisChange()
    '            AASGraphAnalysis.Invalidate()
    '            Application.DoEvents()
    '        End If

    '        'AASGraphAnalysis.XAxisStep = 20     'Saurabh 06-06-2007
    '        'Call Calculate_Analysis_Graph_Param(AASGraphAnalysis)

    '        AASGraphAnalysis.XAxisType = AldysGraph.AxisType.Linear
    '        AASGraphAnalysis.XAxisMin = mStartTime
    '        AASGraphAnalysis.XAxisMax = mEndTime

    '        Call Calculate_Analysis_Graph_Param(AASGraphAnalysis)

    '        'AASGraphAnalysis.AldysPane.XAxis.StepAuto = True
    '        'AASGraphAnalysis.AldysPane.XAxis.MinorStepAuto = True
    '        'AASGraphAnalysis.AldysPane.XAxis.PickScale(AASGraphAnalysis.XAxisMin, AASGraphAnalysis.XAxisMax)

    '        AASGraphAnalysis.Refresh()
    '        Application.DoEvents()

    '        AnaOver = False

    '        Call DisplayRunNo()

    '        'gobjNewMethod.AnalysisParameters.cMode = -2

    '        'tlbbtnRepeatLastAnalysis.Enabled = False
    '        btnRepeatLast.Enabled = False
    '        '//----- Save Instrument parameter
    '        'gobjNewMethod.InstrumentCondition.D2Current = gobjInst.D2Current
    '        'gobjNewMethod.InstrumentCondition.LampCurrent = gobjInst.Current
    '        'gobjNewMethod.InstrumentCondition.PmtVoltage = gobjInst.PmtVoltage
    '        'gobjNewMethod.InstrumentCondition.SlitWidth = gobjClsAAS203.funcGet_SlitWidth
    '        If gstructSettings.AppMode = EnumAppMode.FullVersion_203D Then
    '            'TODO   Add property to gobjNewMethod.InstrumentCondition object for PMT Volt & Exit Slit Wd for Ref. 
    '            'gobjNewMethod.InstrumentCondition.PmtVoltage = gobjInst.PmtVoltageReference
    '            'gobjNewMethod.InstrumentCondition.SlitWidth = gobjInst.SlitPositionExit
    '        End If

    '        gobjNewMethod.InstrumentCondition.BurnerHeight = gobjClsAAS203.funcReadBurnerHeight()

    '        If Not (gstructSettings.AppMode = EnumAppMode.DemoMode) Then
    '            Call gobjCommProtocol.funcGet_NV_Pos()
    '        End If

    '        dblFuelRatio = gobjClsAAS203.funcGet_Fuel_Ratio(True)
    '        gobjNewMethod.InstrumentCondition.FuelRatio = dblFuelRatio
    '        '//-----

    '        'If (gobjNewMethod.AnalysisParameters) Then
    '        '   aafname = gobjNewMethod.AnalysisParameter.Fname
    '        'End If

    '        Call Display_Analysis_Info()
    '        Call CheckValidStdAbs()
    '        If (mblnIsAnalysisStarted) Then
    '            ANALYSIS = True
    '            '---Show Blinking Message
    '            Call Aspirate()
    '        Else
    '            ANALYSIS = False
    '        End If
    '        mblnRepeatLastStd = False
    '        mblnRepeatLastSample = False

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

    Private Sub NewAnalysis_Clicked(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : NewAnalysis_Clicked
        ' Parameters Passed     : Object, EventArgs
        ' Returns               : None
        ' Purpose               : Start to new analysis
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 17-Jan-2007 03:25 pm
        ' Revisions             : 1
        '=====================================================================
        'case	IDC_QANEW:
        '#If STD_ADDN Then
        '   endanalysis= FALSE;
        '#End If
        'DeleteAllRawData(FALSE);
        'mobjCurrentStandard  =Method->QuantData->StdTopData;
        'mobjCurrentSample =Method->QuantData->SampTopData;
        'CurRepeat=1;

        'if(mobjCurrentStandard!=NULL  && StdAnalysed)
        '{
        '   if(Method->QuantData->Param.Std_Addn)
        '	    i = IDNO;
        '	else{
        '       If (!methchange) Then        
        '		    i=MessageBox(hwnd,"Do you want to use the previous standards","INFORMATION", MB_ICONQUESTION | MB_YESNO);
        '		else
        '		    i=IDNO;
        '   }
        'if(i==IDNO)
        '   Clear_All_Abs_Std(Method->QuantData->StdTopData);
        'Else
        '   mobjCurrentStandard=NULL;
        '}
        'methchange = FALSE;	
        'if(!StdAnalysed) 
        '   Clear_All_Abs_Std(Method->QuantData->StdTopData);
        'Clear_All_Abs_Conc_Samp(Method->QuantData->SampTopData);
        'SampType=BLANK;
        'Xtime=0;Afirst=TRUE;
        '	
        'if(i==6)
        '   StdAnalysed =TRUE;
        'Else
        '	StdAnalysed =FALSE;
        'Method->RepReady=FALSE;
        'if (lParam!=100L){
        '   AppendMethod(Method, QALL);
        '	Method->QuantData->Fname =-1.0;
        '}
        'if (Method->QuantData->Fname<=0)
        '   GetRunNo(Method);
        'AnaGraph.Xmin=0; AnaGraph.Xmax=10*10.0;
        'Calculate_Analysis_Graph_Param(&AnaGraph);
        'AnaOver=FALSE;
        'if (hwnd){
        '   DisplayRunNo(hwnd);
        '	InvalidateRect(hwnd, NULL, TRUE);
        '}
        'Method->QuantData->cMode=-2;

        'EnableWindow(GetDlgItem(hwnd,IDC_QARPT),FALSE); // add by sss
        'if(Method->QuantData)
        '   aafname = Method->QuantData->Fname;
        'break;


        '---CODE BY MANGESH 

        'On NEW Analysis
        Dim dblFuelRatio As Double
        Dim objDlgResult As DialogResult

        '---18.06.07
        Try

            '----added by deepak for new analysis on 28.04.07
            lblAbsorbance.Text = ""
            lblAverageAbsorbance.Text = ""
            lblCorrectedAbsorbance.Text = ""
            lblSampleID.Text = ""
            lblRepeatNo.Text = ""
            lblConcentration.Text = ""
            '------------------
            '//----- Commented by Sachin Dokhale
            '//----- Previous Standard
            '//-----

            '---Get the last RunNumber 


            If gobjNewMethod.StandardAddition Then
                EndAnalysis = False
            End If


            '//----- Modifed by Sachin Dokhale
            ' ReInit object
            mobjAnalysisRawData = Nothing
            mobjAnalysisRawData = New Analysis.clsRawDataCollection
            '//-----
            mobjBlankRawData = Nothing
            mobjStandardRawData = Nothing
            mobjSampleRawData = Nothing
            ''//-----



            '---- Commented by Mangesh on 10-May-2007

            '---Gets the First Standard from Standard Collection
            If Not IsNothing(gobjNewMethod.StandardDataCollection) Then
                mobjStandardEnumerator = gobjNewMethod.StandardDataCollection.GetEnumerator()
                mobjStandardEnumerator.Reset()
                intIEnumCollLocationStd = 0
                If mobjStandardEnumerator.MoveNext() Then
                    intIEnumCollLocationStd = 1
                    mobjCurrentStandard = CType(mobjStandardEnumerator.Current(), Method.clsAnalysisStdParameters)
                End If
            End If

            '---Gets the First Sample from Sample Collection
            If Not IsNothing(gobjNewMethod.SampleDataCollection) Then
                mobjSampleEnumerator = gobjNewMethod.SampleDataCollection.GetEnumerator()
                mobjSampleEnumerator.Reset()
                intIEnumCollLocationSamp = 0
                If mobjSampleEnumerator.MoveNext() Then
                    intIEnumCollLocationSamp = 1
                    mobjCurrentSample = CType(mobjSampleEnumerator.Current(), Method.clsAnalysisSampleParameters)
                End If
            End If

            CurRepeat = 1
            '//----- if use Previous Standard
            'Dim blnIsLoadPreviousStandards As Boolean
            If ((Not IsNothing(mobjCurrentStandard)) And StdAnalysed) Then
                If (gobjNewMethod.StandardAddition) Then
                    objDlgResult = DialogResult.No
                    blnIsLoadPreviousStandards = False
                Else
                    If Not (methchange) And (mblnGetStandards = True) Then
                        If gobjMessageAdapter.ShowMessage(constPreviousStandards) Then
                            objDlgResult = DialogResult.Yes
                            blnIsLoadPreviousStandards = True
                        Else
                            objDlgResult = DialogResult.No
                            blnIsLoadPreviousStandards = False
                        End If
                    Else
                        objDlgResult = DialogResult.No
                        blnIsLoadPreviousStandards = False
                    End If
                End If
                'Comment & move by Pankaj on 08 Jun 07 
                'If (objDlgResult = DialogResult.No) Then
                '    Clear_All_Abs_Std(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection)
                'Else
                '    mobjCurrentStandard = Nothing
                'End If
                '------
            Else
                blnIsLoadPreviousStandards = False
            End If
            methchange = False
            '//----- Added by Sachin Dokhale 
            '//----- Previous Standard
            If blnIsLoadPreviousStandards = False Then
                gobjclsStandardGraph = New clsStandardGraph
            Else
                If gobjclsStandardGraph Is Nothing Then
                    gobjclsStandardGraph = New clsStandardGraph
                End If
            End If
            '//-----
            'for removing uncompleted std analysis
            If Not (StdAnalysed) Then  '---
                Call Clear_All_Abs_Std(gobjNewMethod.StandardDataCollection)
            End If
            'Moved By Pankaj  on 09 Jun 07
            'Call Clear_All_Abs_Conc_Samp(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection)

            ' Set 1st at the time of starting new analysis Sample Type is Balnk
            'Start Time and End time of analysis is reset
            ' then change when analysis perform Sts/Sample or blank

            SampleType = ClsAAS203.enumSampleType.BLANK
            Afirst = True
            mStartTime = 0.0
            mEndTime = mStartTime + 100

            'if(i==6)
            '   StdAnalysed =TRUE;
            'Else
            '	StdAnalysed =FALSE;

            'Comment & move by Pankaj 08 Jun 06 
            'If (objDlgResult = DialogResult.Yes) Then
            '    StdAnalysed = True
            'Else
            '    StdAnalysed = False
            'End If
            '---------

            'gobjNewMethod.AnalysisParameters.RepReady = False
            ' Follow the process for New Run nuumber
            If (mblnIsStartRunNumber) Then
                'AppendMethod(Method, QALL)
                'If (CInt(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).RunNumber) >= 0) Then
                Dim objclsQuantitativeData As AAS203Library.Method.clsQuantitativeData
                objclsQuantitativeData = New AAS203Library.Method.clsQuantitativeData
                'Set Analysis Parameter object
                If Not gobjNewMethod.AnalysisParameters Is Nothing Then
                    objclsQuantitativeData.AnalysisParameters = gobjNewMethod.AnalysisParameters.Clone()
                End If
                'Set Report Parameter object
                If Not gobjNewMethod.ReportParameters Is Nothing Then
                    objclsQuantitativeData.ReportParameters = gobjNewMethod.ReportParameters.Clone()
                End If

                'objclsQuantitativeData.StandardDataCollection = gobjNewMethod.StandardDataCollection.Clone()
                '//----- Added by Sachin Dokhale for Previous Standard
                ' Restore the previous object when analysis use Load previous Standard 
                If blnIsLoadPreviousStandards = True And StdAnalysed = True And mintRunNumberIndex >= 0 Then
                    mblnGetStandards = False
                    objclsQuantitativeData.StandardDataCollection = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.Clone

                    intIEnumCollLocationStd = objclsQuantitativeData.StandardDataCollection.Count + 1
                    If funcMoveEnumerator(mobjStandardEnumerator, intIEnumCollLocationStd) = True Then
                        mobjCurrentStandard = CType(mobjStandardEnumerator.Current, Method.clsAnalysisStdParameters)
                    Else
                        mobjCurrentStandard = Nothing
                    End If
                Else
                    objclsQuantitativeData.StandardDataCollection = gobjNewMethod.StandardDataCollection.Clone()
                End If

                '//-----
                If Not gobjNewMethod.SampleDataCollection Is Nothing Then
                    objclsQuantitativeData.SampleDataCollection = gobjNewMethod.SampleDataCollection.Clone()
                End If

                'objclsQuantitativeData.CalculationMode = gobjNewMethod.CalculationMode
                gobjNewMethod.QuantitativeDataCollection.Add(objclsQuantitativeData)
                'mintRunNumberIndex += 1
                mintRunNumberIndex = gobjNewMethod.QuantitativeDataCollection.Count - 1


                gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).RunNumber = -1.0
                'End If
                mblnIsStartRunNumber = False
                '//--- Create Run No to start new analysis during the analysis 
                If mblnExecuteRunNo = False Then
                    ' Get the Run No from Data collection object
                    Call GetRunNo(gobjNewMethod)
                    mblnIsCreateNewRunNo = False
                    ' Display Run No in screen
                    Call DisplayRunNo()
                End If
            End If
            'Added By Pankaj on 08 Jun 07
            ' Cleat all stadard object when New Standard use analysis
            If ((Not IsNothing(mobjCurrentStandard)) And StdAnalysed) Then
                If (objDlgResult = DialogResult.No) Then
                    Clear_All_Abs_Std(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection)
                Else
                    mobjCurrentStandard = Nothing
                End If
            End If
            ' Cleat all Sample object 
            Call Clear_All_Abs_Conc_Samp(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection)
            '------------------
            'Comment & move by Pankaj 08 Jun 06 
            If (objDlgResult = DialogResult.Yes) Then
                StdAnalysed = True
            Else
                StdAnalysed = False
            End If
            '---------
            If (CInt(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).RunNumber) <= 0) Then
                ' Call GetRunNo(gobjNewMethod)
            End If


            '---- Added by Mangesh on 10-May-2007

            '---Gets the First Standard from Standard Collection
            If blnIsLoadPreviousStandards = True And StdAnalysed = True And mintRunNumberIndex > 0 Then
            Else
                If Not IsNothing(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection) Then
                    mobjStandardEnumerator = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.GetEnumerator()
                    mobjStandardEnumerator.Reset()
                    intIEnumCollLocationStd = 0
                    If mobjStandardEnumerator.MoveNext() Then
                        intIEnumCollLocationStd = 1
                        mobjCurrentStandard = CType(mobjStandardEnumerator.Current(), Method.clsAnalysisStdParameters)
                    End If
                End If

            End If

            '---Gets the First Sample from Sample Collection
            If Not IsNothing(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection) Then
                mobjSampleEnumerator = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.GetEnumerator()
                mobjSampleEnumerator.Reset()
                intIEnumCollLocationSamp = 0
                If mobjSampleEnumerator.MoveNext() Then
                    intIEnumCollLocationSamp = 1
                    mobjCurrentSample = CType(mobjSampleEnumerator.Current(), Method.clsAnalysisSampleParameters)
                End If
            End If

            If (objDlgResult = DialogResult.Yes) Then
                mobjCurrentStandard = Nothing
            End If

            '10.2.2010
            '-------------------------------------------
            gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.Analysis_Date = Date.Now
            '---------------------------------------------


            If AASGraphAnalysis.AldysPane.CurveList.Count > 0 Then
                AASGraphAnalysis.AldysPane.CurveList.Clear()

                AASGraphAnalysis.AldysPane.AxisChange()
                AASGraphAnalysis.Invalidate()
                Application.DoEvents()
            End If

            'AASGraphAnalysis.XAxisStep = 20     'Saurabh 06-06-2007
            'Call Calculate_Analysis_Graph_Param(AASGraphAnalysis)
            '--- Set Graph parameters
            AASGraphAnalysis.XAxisType = AldysGraph.AxisType.Linear
            AASGraphAnalysis.XAxisMin = mStartTime
            AASGraphAnalysis.XAxisMax = mEndTime
            '--- Cal. graph coordinates 
            Call Calculate_Analysis_Graph_Param(AASGraphAnalysis)
            AASGraphAnalysis.Refresh()
            Application.DoEvents()

            AnaOver = False
            mblnIsCreateNewRunNo = True
            Call DisplayRunNo()

            'gobjNewMethod.AnalysisParameters.cMode = -2

            'tlbbtnRepeatLastAnalysis.Enabled = False
            btnRepeatLast.Enabled = False
            '//----- Save Instrument parameter

            If gstructSettings.AppMode = EnumAppMode.FullVersion_203D Then
                'TODO   Add property to gobjNewMethod.InstrumentCondition object for PMT Volt & Exit Slit Wd for Ref. 
                'gobjNewMethod.InstrumentCondition.PmtVoltage = gobjInst.PmtVoltageReference
                'gobjNewMethod.InstrumentCondition.SlitWidth = gobjInst.SlitPositionExit
            End If
            If gobjMain.mobjController.IsThreadRunning = True Then  '10.12.07
                gobjMain.mobjController.Cancel()
                Application.DoEvents()
                gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay)   '10.12.07
                Application.DoEvents()
            End If

            ' set the instrument parameter into Data collection object
            gobjNewMethod.InstrumentCondition.BurnerHeight = gobjClsAAS203.funcReadBurnerHeight()

            'If Not (gstructSettings.AppMode = EnumAppMode.DemoMode) Then
            If Not ((gstructSettings.AppMode = EnumAppMode.DemoMode) Or _
                    (gstructSettings.AppMode = EnumAppMode.DemoMode_201) Or _
                    (gstructSettings.AppMode = EnumAppMode.DemoMode_203D)) Then
                Call gobjCommProtocol.funcGet_NV_Pos()
            End If

            'dblFuelRatio = gobjClsAAS203.funcGet_Fuel_Ratio(True)  '10.12.07
            dblFuelRatio = gobjClsAAS203.funcRead_Fuel_Ratio        '10.12.07
            gobjNewMethod.InstrumentCondition.FuelRatio = dblFuelRatio
            '//-----

            'If (gobjNewMethod.AnalysisParameters) Then
            '   aafname = gobjNewMethod.AnalysisParameter.Fname
            'End If
            'display analysis information 
            Call Display_Analysis_Info()
            ' Check Valid Std for result from analysis
            Call CheckValidStdAbs()

            If (mblnIsAnalysisStarted) Then
                ANALYSIS = True
                '---Show Blinking Message
                Call Aspirate()
            Else
                ANALYSIS = False
            End If
            mblnRepeatLastStd = False
            mblnRepeatLastSample = False
            '//----- Initialise the Data Bg Thread for UV Analysis
            If (gobjNewMethod.OperationMode = EnumOperationMode.MODE_UVABS) Then
                mobjBgReadData = New clsBgReadData(0, 0, SampleType, mobjCurrentStandard, mobjCurrentSample)
            End If
            '//-----
            If btnReadData.Enabled Then
                btnReadData.Focus()
                btnReadData.Refresh()
            End If
            If gobjMain.mobjController.IsThreadRunning = False Then     '10.12.07
                gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay)
                Application.DoEvents()
                gobjMain.mobjController.Start(gobjclsBgFlameStatus)
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

    Private Sub NextAnalysis_Clicked(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : NextAnalysis_Clicked
        ' Parameters Passed     : Object, EventArgs
        ' Returns               : None
        ' Purpose               : Set to Next sample
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 17-Jan-2007 03:25 pm
        ' Revisions             : 1
        '=====================================================================
        'case IDC_QANEXT:
        'LSampType=SampType;
        'if( SampType==BLANK )
        '{
        '   SampType=STD;
        '	if (CurStd==NULL)
        '	    SampType=SAMP;
        '	if (SampType==SAMP && CurSamp==NULL)
        '   {
        '	    InQAnaRead=FALSE;
        '       AnaOver=TRUE;
        '		SendMessage(hwnd, WM_COMMAND, IDC_QASTART, 0L);
        '   }
        '}
        'else
        '{
        '   CurRepeat++;
        '   if ((CurRepeat>Method->QuantData->Param.Repeat && SampType==SAMP) || (CurRepeat>Method->QuantData->Param.ConcRepeat && SampType==STD))
        '   {
        '	    CurRepeat=1;
        '		if (SampType==STD )
        '       {
        '           If (CurStd! = NULL) Then
        '			    CurStd=CurStd->next;
        '			if (CurStd==NULL)
        '           {
        '			    StdAnalysed=TRUE;
        '			    if (!GetBlankCalType())
        '               {
        '				    Create_Standard_Sample_Curve(hwnd,FALSE);
        '
        '                   #If STD_ADDN Then
        '					    if(Method->QuantData->Param.Std_Addn)
        '					        endanalysis= TRUE;
        '                   #End If        
        '
        '				}
        '				SampType=SAMP;
        '			}
        '		}
        '		else if (SampType==SAMP)
        '       {
        '           If (CurSamp! = NULL) Then
        '			    CurSamp=CurSamp->next;
        '		}
        '	}
        '	if (Method->QuantData->Param.Blank)
        '	    SampType=BLANK;
        '}
        'InQAnaRead=FALSE;
        'EnableWindow(GetDlgItem(hwnd,IDC_SAVEREPORT), StdAnalysed);
        'EnableWindow(GetDlgItem(hwnd,IDC_QARPT),TRUE); 

        '#If STD_ADDN Then
        '   if(endanalysis)
        '       SendMessage(hwnd, WM_COMMAND, 951, 0L);
        '#End If
        'break;


        '--- CODE BY MANGESH 
        
        Try
            '--- Set previous Sample type to tmep and assign next sample type
            LSampType = SampleType

            If (SampleType = ClsAAS203.enumSampleType.BLANK) Then
                SampleType = ClsAAS203.enumSampleType.STANDARD

                If IsNothing(mobjCurrentStandard) Then
                    SampleType = ClsAAS203.enumSampleType.SAMPLE
                End If

                If (SampleType = ClsAAS203.enumSampleType.SAMPLE _
                    And IsNothing(mobjCurrentSample)) Then

                    InQAnaRead = False
                    AnaOver = True
                    'SendMessage(hwnd, WM_COMMAND, IDC_QASTART, 0L)
                    ' Set the StartStop Analysis porcedure
                    mblnAvoidProcessing = False
                    Call StartStopAnalysis_Click(btnStartStopAnalysis, EventArgs.Empty)
                End If

            Else

                CurRepeat += 1

                'if ////////////////////////////////((CurRepeat>Method->QuantData->Param.Repeat && SampType==SAMP) || (CurRepeat>Method->QuantData->Param.ConcRepeat && SampType==STD)){
                If ((CurRepeat > gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfSampleRepeats _
                     And SampleType = ClsAAS203.enumSampleType.SAMPLE) _
                    Or (CurRepeat > gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfStdRepeats _
                     And SampleType = ClsAAS203.enumSampleType.STANDARD)) Then

                    CurRepeat = 1

                    If (SampleType = ClsAAS203.enumSampleType.STANDARD) Then
                        'If (CurStd! = NULL) Then
                        '   CurStd=CurStd->next
                        '}
                        ' Set the current standard
                        Call funcGetCurrentStandard(mobjCurrentStandard)



                        If IsNothing(mobjCurrentStandard) Then
                            StdAnalysed = True
                            If Not (gstructSettings.BlankCalculation) Then

                                Call gobjclsStandardGraph.Create_Standard_Sample_Curve(False, True, 0, 0, gobjNewMethod)

                                '#If STD_ADDN Then
                                If gobjNewMethod.StandardAddition Then
                                    'if(Method->QuantData->Param.Std_Addn)                   

                                    EndAnalysis = True
                                    'End If
                                    '#End If
                                End If
                            End If
                            SampleType = ClsAAS203.enumSampleType.SAMPLE
                        End If
                    ElseIf (SampleType = ClsAAS203.enumSampleType.SAMPLE) Then
                        'If (CurSamp! = NULL) Then
                        '   CurSamp=CurSamp->next;
                        Call funcGetCurrentSample(mobjCurrentSample)
                    End If
                End If
                'EnableWindow(GetDlgItem(hwnd, IDC_SAVEREPORT), StdAnalysed)
                btnSave.Enabled = StdAnalysed

                '--- Check Blank After Every Sample or Std and set sample type is blank
                If (gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.IsBlankAfterEverySampleOrStd) Then
                    SampleType = ClsAAS203.enumSampleType.BLANK
                Else
                    If (SampleType = ClsAAS203.enumSampleType.SAMPLE _
                    And IsNothing(mobjCurrentSample)) Then

                        InQAnaRead = False
                        AnaOver = True
                        'SendMessage(hwnd, WM_COMMAND, IDC_QASTART, 0L)
                        ' Set the StartStop Analysis porcedure
                        mblnAvoidProcessing = False
                        Call StartStopAnalysis_Click(btnStartStopAnalysis, EventArgs.Empty)
                    End If
                End If

            End If

            InQAnaRead = False
            'tlbbtnSaveReport.Enabled = StdAnalysed
            'tlbbtnRepeatLastAnalysis.Enabled = True
            btnEditData.Enabled = StdAnalysed
            btnRepeatLast.Enabled = True
            '--- Asipiration message for next analysis
            Call Aspirate()
            ' check for Standsrd Addition mode and if analysis is end then use start stop analysis porcesure
            '#If STD_ADDN Then
            If gobjNewMethod.StandardAddition Then
                If (EndAnalysis) Then
                    'SendMessage(hwnd, WM_COMMAND, 951, 0L)
                    mblnAvoidProcessing = False   '---02.08.09
                    Call StartStopAnalysis_Click(btnStartStopAnalysis, EventArgs.Empty)
                End If
            End If
            'End IF

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

    Private Function funcGetCurrentStandard(ByRef objCurrentStandard As Method.clsAnalysisStdParameters) As Boolean
        '=====================================================================
        ' Procedure Name        : funcGetCurrentStandard
        ' Parameters Passed     : objCurrentStandard As Method.clsAnalysisStdParameters
        ' Returns               : Bool
        ' Purpose               : Set to curent standard
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 17-Jan-2007 03:25 pm
        ' Revisions             : 1
        '=====================================================================
        'Static intIEnumCollLocation As Integer
        Try
            'Set by Ref. object of the current standard 
            If Not IsNothing(objCurrentStandard) Then
                '--- Check for last repeat Standard
                'If mblnRepeatLastStd = True Then
                'If funcMoveEnumerator(mobjStandardEnumerator, intIEnumCollLocationStd) = True Then
                '    objCurrentStandard = CType(mobjStandardEnumerator.Current, Method.clsAnalysisStdParameters)
                'Else
                '    objCurrentStandard = Nothing
                'End If
                'Else
                intIEnumCollLocationStd += 1
                If funcMoveEnumerator(mobjStandardEnumerator, intIEnumCollLocationStd) = True Then
                    objCurrentStandard = CType(mobjStandardEnumerator.Current, Method.clsAnalysisStdParameters)
                Else
                    objCurrentStandard = Nothing
                End If
                'End If
                'mblnRepeatLastStd = False
            End If
            mblnRepeatLastStd = False
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

    Private Function funcGetCurrentSample(ByRef objCurrentSample As Method.clsAnalysisSampleParameters) As Boolean
        '=====================================================================
        ' Procedure Name        : funcGetCurrentSample
        ' Parameters Passed     : objCurrentStandard As Method.clsAnalysisStdParameters
        ' Returns               : Bool
        ' Purpose               : Set to curent Sample
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 17-Jan-2007 03:25 pm
        ' Revisions             : 1
        '=====================================================================
        'Static intIEnumCollLocation As Integer
        Try
            'Set by Ref. object of the current sample
            If Not IsNothing(objCurrentSample) Then
                '--- Check for last repeat sample
                'If mblnRepeatLastSample = True Then

                '    If funcMoveSampleEnumerator(mobjSampleEnumerator, intIEnumCollLocationSamp) = True Then
                '        objCurrentSample = CType(mobjSampleEnumerator.Current, Method.clsAnalysisSampleParameters)
                '    Else
                '        objCurrentSample = Nothing
                '    End If
                'Else

                    intIEnumCollLocationSamp += 1
                    If funcMoveSampleEnumerator(mobjSampleEnumerator, intIEnumCollLocationSamp) = True Then
                        objCurrentSample = CType(mobjSampleEnumerator.Current, Method.clsAnalysisSampleParameters)
                    Else
                        objCurrentSample = Nothing
                    End If
                'End If
                'mblnRepeatLastSample = False
            End If
            mblnRepeatLastSample = False
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

    Private Function funcMoveEnumerator(ByRef piEnumarator As IEnumerator, ByVal iLocation As Integer) As Boolean
        '=====================================================================
        ' Procedure Name        : funcMoveEnumerator
        ' Parameters Passed     : piStandardEnumarator As IEnumerator, piSampleEnumarator As IEnumerator
        ' Returns               : Bool
        ' Purpose               : Move Enumerator object
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 17-Jan-2007 03:25 pm
        ' Revisions             : 1
        '=====================================================================

        Dim tmpEnum As IEnumerator
        Dim IsLastRecoed As Boolean = False
        Try
            If mobjCurrentStandard Is Nothing Then
                Return False
            End If
            Dim i As Integer
            'assign enumarator to temporary enumrator
            tmpEnum = piEnumarator
            If Not tmpEnum Is Nothing Then
                'move the pointer to starting position
                tmpEnum.Reset()
                'validate location
                If iLocation <= 0 Then
                    IsLastRecoed = True
                End If
                'move enumrator pointer to said location
                For i = 1 To iLocation
                    If tmpEnum.MoveNext() = False Then
                        IsLastRecoed = True
                        Exit For
                    End If
                Next
                'assign temp enumrator to original enumrator
                piEnumarator = tmpEnum
            End If
            If IsLastRecoed = True Then
                Return False
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
            '---------------------------------------------------------
        End Try

    End Function

    Private Function funcMoveSampleEnumerator(ByRef piEnumarator As IEnumerator, ByVal iLocation As Integer) As Boolean
        '=====================================================================
        ' Procedure Name        : funcMoveSampleEnumerator
        ' Parameters Passed     : piStandardEnumarator As IEnumerator, piSampleEnumarator As IEnumerator
        ' Returns               : Bool
        ' Purpose               : Move sample Enumerator object
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 17-Jan-2007 03:25 pm
        ' Revisions             : 1
        '=====================================================================
        Dim tmpEnum As IEnumerator
        Dim IsLastRecoed As Boolean = False
        Try

            Dim i As Integer
            If mobjCurrentSample Is Nothing Then
                Return False
            End If
            If Not IsNothing(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection) Then
                mobjSampleEnumerator = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.GetEnumerator()
                tmpEnum = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.GetEnumerator()
            Else
                tmpEnum = piEnumarator
            End If

            If Not tmpEnum Is Nothing Then

                tmpEnum.Reset()
                'validate location
                If iLocation <= 0 Then
                    IsLastRecoed = True
                End If
                'move enumrator pointer to said location
                For i = 1 To iLocation
                    If tmpEnum.MoveNext() = False Then
                        IsLastRecoed = True
                        Exit For
                    End If
                Next
                piEnumarator = tmpEnum
            End If
            If IsLastRecoed = True Then
                Return False
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
            '---------------------------------------------------------
        End Try

    End Function

    Private Function funcRefreshEnumerators(ByRef piStandardEnumarator As IEnumerator, ByRef piSampleEnumarator As IEnumerator) As Boolean
        '=====================================================================
        ' Procedure Name        : funcRefreshEnumerators
        ' Parameters Passed     : piStandardEnumarator As IEnumerator, piSampleEnumarator As IEnumerator
        ' Returns               : Bool
        ' Purpose               : Move refresh Enumerator object
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 17-Jan-2007 03:25 pm
        ' Revisions             : 1
        '=====================================================================
        Dim tmpEnum As IEnumerator
        Dim IsLastRecoed As Boolean = False
        Try
            'Dim i As Integer
            If Not (mobjCurrentStandard Is Nothing) Then
                If Not IsNothing(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection) Then
                    piStandardEnumarator = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.GetEnumerator()
                    piStandardEnumarator.Reset()
                    'Try 'by Pankaj on 30 Jan 08
                    '    If Not (piStandardEnumarator.Current Is Nothing) Then
                    '        mobjCurrentStandard = CType(piStandardEnumarator.Current, Method.clsAnalysisStdParameters)
                    '    End If
                    'Catch ex As InvalidOperationException
                    '    If piStandardEnumarator.MoveNext = True Then
                    '        If Not (piStandardEnumarator.Current Is Nothing) Then
                    '            mobjCurrentStandard = CType(piStandardEnumarator.Current, Method.clsAnalysisStdParameters)
                    '        End If
                    '    End If
                    'End Try

                    'tmpEnum = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.GetEnumerator()
                Else
                    'tmpEnum = piEnumarator
                End If
            End If
            If Not IsNothing(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection) Then
                piSampleEnumarator = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.GetEnumerator()
                piSampleEnumarator.Reset()
                'Try 'by Pankaj on 30 Jan 08
                '    If Not (piSampleEnumarator.Current Is Nothing) Then
                '        mobjCurrentSample = CType(piSampleEnumarator.Current, Method.clsAnalysisSampleParameters)
                '    End If
                'Catch ex As InvalidOperationException
                '    If piSampleEnumarator.MoveNext = True Then
                '        If Not (piSampleEnumarator.Current Is Nothing) Then
                '            mobjCurrentSample = CType(piSampleEnumarator.Current, Method.clsAnalysisSampleParameters)
                '        End If
                '    End If
                'End Try

                'tmpEnum = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.GetEnumerator()
            Else
                'tmpEnum = piEnumarator
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
            '---------------------------------------------------------
        End Try

    End Function

    Private Sub BlankAnalysis_Clicked(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : BlankAnalysis_Clicked
        ' Parameters Passed     : Object, EventArgs
        ' Returns               : Bool
        ' Purpose               : perform blank analysis
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 17-Jan-2007 03:25 pm
        ' Revisions             : 1
        '=====================================================================
        'case	IDC_BLANK:
        '   SampType=BLANK;
        '   break;
        Try
            ' Set Blank sample type
            If Not (SampleType = ClsAAS203.enumSampleType.BLANK) Then
                SampleType = ClsAAS203.enumSampleType.BLANK
                'Aspiration message for diff. type of sample
                Call Aspirate()
            End If
            If btnReadData.Enabled Then
                btnReadData.Focus()
                btnReadData.Refresh()
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

    Private Sub StartStopAnalysis_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : StartStopAnalysis_Click
        ' Parameters Passed     : Object, EventArgs
        ' Returns               : None
        ' Purpose               : Start/Stop anslysis
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 17-Jan-2007 03:25 pm
        ' Revisions             : 1
        '=====================================================================
        'Started ^= 1;
        'InAnalysis ^= 1;

        'if(Started & !exitbutton){
        '   if (MessageBox(hwnd," New Analysis?", "STD/SAMPLE ANALYSIS", MB_ICONQUESTION | MB_YESNO)==IDYES){
        '   SendMessage(hwnd, WM_COMMAND,IDC_QANEW, 0L);
        '   }
        '}
        'WP1= wParam;
        'if (!AnaOver && (CurStd==NULL && CurSamp==NULL)){
        '   If (!StdAnalysed) Then
        '       CurStd  =Method->QuantData->StdTopData;
        '   #If STD_ADDN Then
        '       if(!Method->QuantData->Param.Std_Addn)
        '   #End If
        '       CurSamp =Method->QuantData->SampTopData;
        '}
        'CheckAnaButtons(hwnd);
        'if (Started){
        '   if (AnaOver){
        '       if (MessageBox(hwnd," Data Exists in Memory . \n Erase them ?", "STD/SAMPLE ANALYSIS", MB_YESNO)==IDYES)
        '           SendMessage(hwnd, WM_COMMAND,IDC_QANEW, 0L);
        '   }
        '   SetWindowText(GetDlgItem(hwnd, IDC_QASTART), "E&nd Ana");
        '   if (Method->QuantData->Fname<=0)
        '   GetRunNo(Method);
        '   DisplayRunNo(hwnd);
        '}
        'else{
        '   SetWindowText(GetDlgItem(hwnd, IDC_QASTART), "&Start");
        '   RawDataSave("rawdata.txt");
        '   if (toreported||!Method->RepReady ){
        '   SaveQuantResults(hwnd, Method, A1,0);
        '   toreported=FALSE;
        '   }
        '   DestroyAspWnd();
        '}
        'InQAnaRead=FALSE;
        '#If QDEMO Then
        '   if (AnaOver)
        '       EndFiledataRead();
        '#End If
        'break;
        '------------------------------------------
        Try
            'If mblnAvoidProcessing = True Then  '10.12.07 'commented by pankaj on 23 Mar 08  
            '    Exit Sub
            'End If
            '-----by Pankaj on 23 Mar 08 for autosampler
            If mblnAvoidProcessing = True And mblnIsAutosampler = False Then
                Exit Sub
            End If
            '----end
            mblnExecuteRunNo = True
            mblnAvoidProcessing = True
            ' Start or stop the analysis depending upon setting
            If (gstructAutoSampler.blnAutoSamplerInitialised = True) Then ''by Pankaj for autosampler on 10Sep 07
                mblnIsAutosampler = gstructAutoSampler.blnCommunication
            Else
                mblnIsAutosampler = False
            End If
            mblnIsAnalysisStarted = Not mblnIsAnalysisStarted
            InAnalysis = Not InAnalysis
            'Check for start Analysis 
            If mblnIsAnalysisStarted Then
                'If mblnAvoidProcessing = True Then  '10.12.07
                '    Exit Sub
                'End If
                'mblnAvoidProcessing = True
                '---
                'Saurabh Add to check if 'No' is selected
                If (mblnIsAnalysisStarted And (Not exitbutton)) Then
                    'Check for to start New Analysis
                    If (gobjMessageAdapter.ShowMessage(constNewAnalysis) = True) Then
                        'SendMessage(hwnd, WM_COMMAND,IDC_QANEW, 0L)
                        If (mblnIsAutosampler And mblnIsAnalysisStarted) Then 'by pankaj on 3 OCt 07
                            btnReadData.Enabled = False
                        End If
                        Call NewAnalysis_Clicked(btnNewAnalysis, EventArgs.Empty)
                    Else
                        '//-----------
                        If Not mobjAnalysisRawData Is Nothing Then
                            If mobjAnalysisRawData.Count = 0 Then
                                Call NewAnalysis_Clicked(btnNewAnalysis, EventArgs.Empty)
                            End If
                        Else
                            Call NewAnalysis_Clicked(btnNewAnalysis, EventArgs.Empty)
                        End If
                        'Else
                        '    'mobjAnalysisRawData(0).
                        '    Dim intSampleCount As Integer = gobjNewMethod.QuantitativeDataCollection(0).SampleDataCollection.Count
                        '    'If gobjNewMethod.QuantitativeDataCollection(0).SampleDataCollection >= intSampleCount Then
                        '    'gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection()
                        '    Dim CountSampData, IdxRawData As Integer
                        '    CountSampData = 0
                        '    For IdxRawData = 0 To mobjAnalysisRawData.Count - 1
                        '        If mobjAnalysisRawData(IdxRawData).SampleType = clsRawData.enumSampleType.SAMPLE Then
                        '            CountSampData += 1
                        '        End If
                        '    Next

                        '    If CountSampData >= gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.Count Then
                        '        If gobjMessageAdapter.ShowMessage("Data exist in memory, Erase it?", "Erase Memory", MessageHandler.clsMessageHandler.enumMessageType.QuestionMessage) = True Then
                        '            Call NewAnalysis_Clicked(btnNewAnalysis, EventArgs.Empty)
                        '        End If
                        '    End If
                        'End If
                        '//---------------------
                        'mblnIsAnalysisStarted = Not mblnIsAnalysisStarted
                        'InAnalysis = Not InAnalysis
                        'mblnAvoidProcessing = False     '10.12.07
                        'Exit Sub
                    End If
                End If
                ' if New Analysis is then ....
                'Saurabh Add to check if 'No' is selected
                Call gobjCommProtocol.FunChopperON()
                btnStartStopAnalysis.Text = "End Anal&ysis"
                mstrAspirationMessage = "Click End Analysis button to Stop Analysis."
                mobjBgMsgAspirate.AspirationMessage = mstrAspirationMessage
                btnReadData.Enabled = True
                'Saurabh 10.07.07
                If Not IsNothing(gobjMain.mobjfrmMethod) Then
                    gobjMain.mobjfrmMethod.btnNewMethod.Enabled = False
                    gobjMain.mobjfrmMethod.btnLoadMethod.Enabled = False
                End If
                'mblnAvoidProcessing = False     '10.12.07
                'Saurabh 10.07.07

            Else
                ' Stop the Analysis before complite the analysis
                ' Set Aspiration Message and buttons caption
                btnStartStopAnalysis.Text = "Start Anal&ysis"
                mstrAspirationMessage = "Click Start button to Start Analysis."
                mobjBgMsgAspirate.AspirationMessage = mstrAspirationMessage
                btnReadData.Enabled = False
                'Saurabh 10.07.07
                If Not IsNothing(gobjMain.mobjfrmMethod) Then
                    gobjMain.mobjfrmMethod.btnNewMethod.Enabled = True
                    gobjMain.mobjfrmMethod.btnLoadMethod.Enabled = True
                End If
                Call gobjCommProtocol.FunChopperOFF()
                'Saurabh 10.07.07
            End If

            'Saurabh Shifted on top of this procedure
            'If (mblnIsAnalysisStarted And (Not exitbutton)) Then
            '    If (gobjMessageAdapter.ShowMessage(constNewAnalysis) = True) Then
            '        'SendMessage(hwnd, WM_COMMAND,IDC_QANEW, 0L)
            '        Call NewAnalysis_Clicked(btnNewAnalysis, EventArgs.Empty)
            '    End If
            'End If
            'Saurabh Shifted on top of this procedure

            'WP1= wParam;
            If (Not AnaOver And (IsNothing(mobjCurrentStandard) And IsNothing(mobjCurrentSample))) Then
                If Not (StdAnalysed) Then
                    'CurStd  =Method->QuantData->StdTopData;
                    mobjCurrentStandard = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(0)
                End If
                '#If STD_ADDN Then
                If Not (gobjNewMethod.StandardAddition) Then
                    'CurSamp =Me++thod->QuantData->SampTopData;
                    mobjCurrentSample = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(0)
                End If
                '#End If
            End If
            ' Set the enable/disable property for buttons reguarding of actual analysis 
            Call CheckAnaButtons()
            ' Check under any circumtancy if analysis is started mode 
            ' but Analysis is over (Standard and Sample Analysis)
            If (mblnIsAnalysisStarted) Then
                If (AnaOver) Then
                    If gobjMessageAdapter.ShowMessage(constDataExists) = True Then
                        'If (MessageBox.Show(" Data Exists in Memory." & vbCrLf & "Erase them?", "STANDARD/SAMPLE ANALYSIS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
                        'SendMessage(hwnd, WM_COMMAND,IDC_QANEW, 0L)
                        mblnIsStartRunNumber = False
                        'Call GetRunNo(gobjNewMethod)
                        Call NewAnalysis_Clicked(btnNewAnalysis, EventArgs.Empty)
                    End If
                End If
                If mblnIsCreateNewRunNo = True Then
                    ' Get the Run No from Data collection object
                    Call GetRunNo(gobjNewMethod)
                    mblnIsCreateNewRunNo = False
                End If

                ' Display Run No in screen
                Call DisplayRunNo()

                gobjNewMethod.DateOfLastUse = Now

                'SetWindowText(GetDlgItem(hwnd, IDC_QASTART), "E&nd Ana")
                btnStartStopAnalysis.Text = "E&nd Analysis"

                '//----- Previous Standard
                'gobjclsStandardGraph = New clsStandardGraph
                '//----- Added by Sachin Dokhale 
                '//----- Previous Standard
                'If blnIsLoadPreviousStandards = False Then
                If gobjclsStandardGraph Is Nothing Then
                    gobjclsStandardGraph = New clsStandardGraph
                End If
                'Else
                'If gobjclsStandardGraph Is Nothing Then
                '    gobjclsStandardGraph = New clsStandardGraph
                'End If
                'End If

                gobjClsAAS203.funcSave_Fuel_Conditions() '---30.04.10


                '//-----
            Else

            btnStartStopAnalysis.Text = "&Start Analysis"

                gobjClsAAS203.funcSave_Fuel_Conditions() '---30.04.10


            btnEditData.Enabled = True
            'when Stop the analysisSave the Row Data into file system and also into method collection object
            Call RawDataSave("rawdata.txt")
            Call SaveRawDataFile()
            Dim A1() As Double = {0, 0, 0, 0, 0, 0}
            'if (toreported or  not (Method->RepReady) )
            ' Check data is ready to store into system (File System/Collection object)
            If (toreported) Then
                'SaveQuantResults(hwnd, Method, A1, 0)
                gobjNewMethod.DateOfLastUse = Now

                '---added by deepak on 20.07.07 for not dsplaying messages in uv mode
                If Not gobjNewMethod.OperationMode = EnumOperationMode.MODE_UVABS Then

                    If gobjClsAAS203.SaveQuantResults(gobjNewMethod, A1, 1) = True Then
                        mblnIsStartRunNumber = True
                    End If
                Else
                    ' This function last parameter is "ShowMessage" is use to show messages after saving result.
                    ' It is optional and use only for UV Mode analysis
                    If gobjClsAAS203.SaveQuantResults(gobjNewMethod, A1, 0, False) = True Then
                        mblnIsStartRunNumber = True
                    End If
                End If
                'Call gobjClsAAS203.SaveQuantResults(gobjNewMethod, A1, 0)


                'Dim intMethodCounter As Integer
                'For intMethodCounter = 0 To gobjMethodCollection.Count - 1
                '    If gobjMethodCollection.item(intMethodCounter).MethodID = gobjNewMethod.MethodID Then
                '        gobjNewMethod = gobjMethodCollection.item(intMethodCounter).Clone()
                '        Exit For
                '    End If
                'Next

                'mblnIsStartRunNumber = True
                toreported = False
            End If
            'End If
            End If
            InQAnaRead = False
            mblnExecuteRunNo = False
            '#If QDEMO Then
            '   If (AnaOver) Then
            '       EndFiledataRead()
            '   End If
            '#End If
            mblnAvoidProcessing = False
            'call "ReadData_Click" this event when Autosampler is use and process under started analysis
            If (mblnIsAutosampler And mblnIsAnalysisStarted) Then
                'SendMessage(hwnd, WM_COMMAND, IDC_QAREAD, 0L)
                Call ReadData_Click(btnReadData, EventArgs.Empty) 'by pankaj on 01 Oct07 
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

    Private Sub ReadData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : ReadData_Click
        ' Parameters Passed     : Object, EventArgs
        ' Returns               : None
        ' Purpose               : Read data from instrument for analysis
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 17-Jan-2007 03:25 pm
        ' Revisions             : 1
        '=====================================================================
        'case	IDC_QAREAD:

        'if(Method->Mode != MODE_UVABS)
        '{
        '   t = Ignite_Test();
        '	if(!GetHydrideModeStatus() && (t == GREEN || t == RED))
        '	    {
        '		    MessageBox(hwnd,"Flame is OFF.\nAnalysis not possible.","Aspiration Error",MB_ICONSTOP | MB_OK);
        '			break;
        '		}
        '}
        '#If STD_ADDN Then
        '	if(Method->QuantData->Param.Std_Addn)
        '	{
        '	    if(endanalysis)
        '		SendMessage(hwnd, WM_COMMAND,IDC_QANEW, 0L);
        '	}
        '#End If
        '	InQAnaRead=TRUE;
        '	toreported=TRUE;
        '	strcpy(Aspiratemsg,"Reading Wait ... ");
        '	Disp_Analysis_Info(hwnd);
        '	abs1=Read_Quant_Data(hwnd, &AnaGraph);
        '	if (!Method->RepReady )
        '	{
        '	    SaveQuantResults(hwnd, Method, A1,0);
        '	}
        '   Else
        '	    SaveRawDataFile();

        '	if(SampType==STD)
        '	{
        '	    if(!CheckValidStdAbsEntry(Method->QuantData->StdTopData))
        '		{
        '		    MessageBox(hwnd,"Abs of the std is less than or equal to the previous std.\nPress 'Rpt Last' button for Aspirating the same std again","Std Aspiration Error",MB_ICONSTOP | MB_OK);
        '		}
        '	}
        '	if(SampType==SAMP)
        '	{
        '	    if(!CheckValidSampAbsEntry(Method->QuantData->StdTopData,abs1))
        '		{
        '		    MessageBox(hwnd,"Abs of the sample is more than the maximum standard value.\nCalculated Concentration may not be correct.\nPlease dilute the sample and repeat again.\nPress RptLast button when ready.","Sample Aspiration Error",MB_ICONSTOP | MB_OK);
        '		}
        '	}
        '	SendMessage(hwnd, WM_COMMAND, 900, 0L);//IDC_QANEXT, 0L);
        '	break;



        '----CODE BY MANEGSH 

        'startRead:
        Dim intEnumIgiteType As ClsAAS203.enumIgniteType

        Try
            If mblnAvoidProcessing = True And mblnIsAutosampler = False Then
                Exit Sub
            End If
            mblnAvoidProcessing = True

            gobjMain.mobjController.Cancel()
            gobjCommProtocol.mobjCommdll.subTime_Delay(500)   '10.12.07
            Application.DoEvents()

            If Not (gobjNewMethod.OperationMode = EnumOperationMode.MODE_UVABS) Then

                If (gstructSettings.AppMode = EnumAppMode.DemoMode) Or _
                    (gstructSettings.AppMode = EnumAppMode.DemoMode_201) Or _
                    (gstructSettings.AppMode = EnumAppMode.DemoMode_203D) Then
                    intEnumIgiteType = ClsAAS203.enumIgniteType.Blue
                Else
                    If gobjMain.mobjController.IsThreadRunning = False Then

                        '--- Modified function of funcIgnite_Test by Sachin Dokhale on 04.02.07
                        'intEnumIgiteType = gobjClsAAS203.funcIgnite_Test()
                        Dim intIgnite_Test As ClsAAS203.enumIgniteType
                        If gobjClsAAS203.funcIgnite_Test(intIgnite_Test) Then
                            intEnumIgiteType = intIgnite_Test
                        End If
                        '---
                    Else
                        intEnumIgiteType = gobjfrmStatus.FlameType
                    End If
                End If
                gobjfrmStatus.FlameType = intEnumIgiteType
                If ((Not HydrideMode) And (intEnumIgiteType = ClsAAS203.enumIgniteType.Green Or gobjMain.IgniteType = ClsAAS203.enumIgniteType.Red)) Then
                    'gobjMessageAdapter.ShowMessage("Flame is OFF." & vbCrLf & "Analysis not possible.", "Aspiration Error", MessageHandler.clsMessageHandler.enumMessageType.ErrorMessage)
                    gobjMessageAdapter.ShowMessage(constFlameOFF)
                    If gobjMain.mobjController.IsThreadRunning = False Then
                        gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay)
                        Application.DoEvents()
                        gobjMain.mobjController.Start(gobjclsBgFlameStatus)
                    End If
                    mblnAvoidProcessing = False
                    Exit Sub
                End If
            End If

            '  Check when standaed addtion Flag is On and Analysis is complite 
            '  then continue to start New Analysis from begin.
            '#If STD_ADDN Then
            If (gobjNewMethod.StandardAddition) Then
                If (EndAnalysis) Then
                    'SendMessage(hwnd, WM_COMMAND, IDC_QANEW, 0L)
                    Call NewAnalysis_Clicked(btnNewAnalysis, EventArgs.Empty)
                    gobjMain.mobjController.Cancel()
                    gobjCommProtocol.mobjCommdll.subTime_Delay(500)   '10.12.07
                    Application.DoEvents()
                End If
            End If
            '#End If

            ' Set this flag to show report 
            InQAnaRead = True
            toreported = True

            mstrAspirationMessage = "Reading Wait ... "
            mobjBgMsgAspirate.AspirationMessage = mstrAspirationMessage

            'Call gobjCommProtocol.mobjCommdll.subTime_Delay(1200)
            Call Application.DoEvents()

            ' To Display Analysis information.
            Call Display_Analysis_Info()
            '//----- Added by Sachin Dokhale
            'btnReadData.Enabled = False
            RemoveHandler btnReadData.Click, AddressOf ReadData_Click

            If Not (Afirst) Then
                mEndTime = mobjBgReadData.CEndTime
            Else
                mEndTime = mStartTime
            End If

            mdblAbsorbance = Read_Quant_Data(mStartTime, mEndTime)


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

    Private Sub frmAnalysis_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        '=====================================================================
        ' Procedure Name        : frmAnalysis_Closing
        ' Parameters Passed     : object, EventArgs
        ' Returns               : None
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 16-Mar-2007 12:45 pm
        ' Revisions             : 1
        '=====================================================================
        Try
            gobjMain.ShowRunTimeInfo(ConstParentFormLoad)
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

    Private Sub btnEditData_Clicked(ByVal sender As Object, ByVal e As EventArgs)
        '=====================================================================
        ' Procedure Name        : btnEditData_Clicked
        ' Parameters Passed     : object, EventArgs
        ' Returns               : None
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 16-Mar-2007 12:45 pm
        ' Revisions             : 1
        '=====================================================================

        '---- ORIGINAL CODE

        'BOOL	OnViewRepeats(HWND	hpar)
        '{
        '   BOOL	flag = FALSE;
        '   DLGPROC  skp1;
        '   if (Method->QuantData==NULL)
        '	    return flag;
        '   if ((Method->QuantData->Param.Repeat>1 || Method->QuantData->Param.ConcRepeat>1 )&&  FindSamplesAnalysed()>=1) 
        '   {
        '	    skp1 =(DLGPROC) MakeProcInstance((DLGPROC) OnViewRepeatsProc,hInst);
        '	    flag = DialogBox(hInst,"QVIEWRPTS", hpar, skp1);
        '	    FreeProcInstance(skp1);
        '  }
        '   Else
        '	    flag = OnEditStdSamples(hpar);
        '   return flag;
        '}
        '****************************************************************
        Dim flag As Boolean = False
        Dim objfrmDeleteStdNSam As frmDeleteStdNSam

        Dim objfrmViewRepeatResults As frmViewRepeatResults

        Try
            'validate objects Quantitative data collection
            If IsNothing(gobjNewMethod.QuantitativeDataCollection) Then
                Return
            End If

            If ((gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfSampleRepeats > 1 _
              Or gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfStdRepeats > 1) _
              And clsStandardGraph.FindSamplesAnalysed(gobjNewMethod, mintRunNumberIndex) >= 1) Then
                'show result
                objfrmViewRepeatResults = New frmViewRepeatResults(gobjNewMethod, mintRunNumberIndex)
                objfrmViewRepeatResults.ShowDialog()
                Application.DoEvents()
                objfrmViewRepeatResults.Close()
                objfrmViewRepeatResults.Dispose()
                objfrmViewRepeatResults = Nothing
            Else
                'flag = OnEditStdSamples()
                objfrmDeleteStdNSam = New frmDeleteStdNSam(gobjNewMethod, mintRunNumberIndex)
                If objfrmDeleteStdNSam.ShowDialog() = DialogResult.OK Then
                    tlbbtnSampleGraph_Click(sender, e)
                End If
                objfrmDeleteStdNSam.Close()
                Application.DoEvents()
                If Not objfrmDeleteStdNSam Is Nothing Then
                    objfrmDeleteStdNSam.Dispose()
                End If
                objfrmDeleteStdNSam = Nothing
                flag = True
            End If
            If btnReadData.Enabled Then
                btnReadData.Focus()
                btnReadData.Refresh()
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

    'Private Sub XpPanelReports_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    '=====================================================================
    '    ' Procedure Name        : XpPanelReportsClicked
    '    ' Parameters Passed     : Object,EventArgs
    '    ' Returns               : None
    '    ' Purpose               : To view the Reports
    '    ' Description           : 
    '    ' Assumptions           : 
    '    ' Dependencies          : 
    '    ' Author                : Deepak & Saurabh
    '    ' Created               : 05.10.06
    '    ' Revisions             : 
    '    '===================================================================== 
    '    Dim objWait As New CWaitCursor

    '    Try
    '        If Me.XpPanelReports.PanelState = UIComponents.XPPanelState.Collapsed Then
    '            Call funcCollapseAllXPPanels()
    '            Me.XpPanelReports.TogglePanelState()
    '            Me.XpPanelReports.PanelHeight = 80
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
    '        If Not objWait Is Nothing Then
    '            objWait.Dispose()
    '        End If
    '        '---------------------------------------------------------
    '    End Try
    'End Sub

    'Private Sub XpPanelSampleGraph_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    '=====================================================================
    '    ' Procedure Name        : XpPanelSampleGraphClicked
    '    ' Parameters Passed     : Object,EventArgs
    '    ' Returns               : None
    '    ' Purpose               : To view the Sample Graphs
    '    ' Description           : 
    '    ' Assumptions           : 
    '    ' Dependencies          : 
    '    ' Author                : Deepak & Saurabh
    '    ' Created               : 05.10.06
    '    ' Revisions             : 
    '    '===================================================================== 
    '    Dim objWait As New CWaitCursor

    '    Try
    '        If Me.XpPanelSampleGraph.PanelState = UIComponents.XPPanelState.Collapsed Then
    '            Call funcCollapseAllXPPanels()
    '            Me.XpPanelSampleGraph.TogglePanelState()
    '            Me.XpPanelSampleGraph.PanelHeight = 90
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
    '        If Not objWait Is Nothing Then
    '            objWait.Dispose()
    '        End If
    '        '---------------------------------------------------------
    '    End Try
    'End Sub

    'Private Sub XpPanelStandardGraph_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    '=====================================================================
    '    ' Procedure Name        : XpPanelStandardGraphClicked
    '    ' Parameters Passed     : Object,EventArgs
    '    ' Returns               : None
    '    ' Purpose               : To load the Standard Graph form
    '    ' Description           : 
    '    ' Assumptions           : 
    '    ' Dependencies          : 
    '    ' Author                : Deepak & Saurabh
    '    ' Created               : 05.10.06
    '    ' Revisions             : 
    '    '===================================================================== 
    '    Dim objWait As New CWaitCursor

    '    Try
    '        If Me.XpPanelStandardGraph.PanelState = UIComponents.XPPanelState.Collapsed Then
    '            Call funcCollapseAllXPPanels()
    '            Me.XpPanelStandardGraph.TogglePanelState()
    '            Me.XpPanelStandardGraph.PanelHeight = 80
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
    '        If Not objWait Is Nothing Then
    '            objWait.Dispose()
    '        End If
    '        '---------------------------------------------------------
    '    End Try
    'End Sub

    'Private Sub XpPanelViewResults_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    '=====================================================================
    '    ' Procedure Name        : XpPanelViewResultsClicked
    '    ' Parameters Passed     : Object,EventArgs
    '    ' Returns               : None
    '    ' Purpose               : To view the Results
    '    ' Description           : 
    '    ' Assumptions           : 
    '    ' Dependencies          : 
    '    ' Author                : Deepak & Saurabh
    '    ' Created               : 05.10.06
    '    ' Revisions             : 
    '    '===================================================================== 
    '    Dim objWait As New CWaitCursor

    '    Try
    '        If Me.XpPanelViewResults.PanelState = UIComponents.XPPanelState.Collapsed Then
    '            Call funcCollapseAllXPPanels()
    '            Me.XpPanelViewResults.TogglePanelState()
    '            Me.XpPanelViewResults.PanelHeight = 80
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
    '        If Not objWait Is Nothing Then
    '            objWait.Dispose()
    '        End If
    '        '---------------------------------------------------------
    '    End Try
    'End Sub

    Private Sub AASGraphAnalysis_GraphScaleChanged(ByVal XMin As Double, ByVal XMax As Double, ByVal YMin As Double, ByVal YMax As Double) Handles AASGraphAnalysis.GraphScaleChanged
        '=====================================================================
        ' Procedure Name        : AASGraphAnalysis_GraphScaleChanged
        ' Parameters Passed     : XMin, XMax, YMin, YMax  
        ' Returns               : None
        ' Purpose               : Set the property of graph 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 17-Jan-2007 03:25 pm
        ' Revisions             : 1
        '=====================================================================
        Try
            'Set the property of graph object
            AASGraphAnalysis.AldysPane.XAxis.MinorStepAuto = False
            AASGraphAnalysis.AldysPane.XAxis.StepAuto = False
            AASGraphAnalysis.AldysPane.YAxis.MinorStepAuto = False
            AASGraphAnalysis.AldysPane.YAxis.StepAuto = False
            '---changed by deepak on 29.04.07
            AASGraphAnalysis.YAxisStep = 0.2
            AASGraphAnalysis.YAxisMinorStep = 0.1
            '---changed by deepak on 29.04.07
            'set focus to read data button
            AASGraphAnalysis.Refresh()
            If btnReadData.Enabled Then
                btnReadData.Focus()
                btnReadData.Refresh()
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

    Private Sub cmdChangeScale_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdChangeScale.Click
        '=====================================================================
        ' Procedure Name        : cmdChangeScale_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : 
        ' Description           : calculte change scale
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Pankaj Bamb
        ' Created               : 1.05.07
        ' Revisions             : 
        '=====================================================================
        If mblnAvoidProcessing = True Then
            Exit Sub
        End If
        Dim objWait As New CWaitCursor
        Dim objfrmChangeScale As frmChangeScale

        Try
            mblnAvoidProcessing = True
            objfrmChangeScale = New frmChangeScale(mobjParameters, False)
            objfrmChangeScale.funcSetValidatingScale(gobjInst.Mode)
            objfrmChangeScale.lblXAxis.Visible = False
            '-------------Added By Pankaj 11 May 07 for showing default scale on change form
            objfrmChangeScale.SpectrumParameter.XaxisMin = AASGraphAnalysis.XAxisMin
            objfrmChangeScale.SpectrumParameter.XaxisMax = AASGraphAnalysis.XAxisMax

            objfrmChangeScale.SpectrumParameter.YaxisMin = AASGraphAnalysis.YAxisMin
            objfrmChangeScale.SpectrumParameter.YaxisMax = AASGraphAnalysis.YAxisMax
            '------------------------
            If objfrmChangeScale.ShowDialog() = DialogResult.OK Then
                'update scale data structur by user supplied values
                If Not objfrmChangeScale.SpectrumParameter Is Nothing Then
                    mobjParameters.XaxisMax = objfrmChangeScale.SpectrumParameter.XaxisMax
                    mobjParameters.XaxisMin = objfrmChangeScale.SpectrumParameter.XaxisMin
                    mobjParameters.YaxisMax = objfrmChangeScale.SpectrumParameter.YaxisMax
                    mobjParameters.YaxisMin = objfrmChangeScale.SpectrumParameter.YaxisMin
                End If
                AASGraphAnalysis.XAxisMin = mobjParameters.XaxisMin
                AASGraphAnalysis.XAxisMax = mobjParameters.XaxisMax
                AASGraphAnalysis.YAxisMin = mobjParameters.YaxisMin
                AASGraphAnalysis.YAxisMax = mobjParameters.YaxisMax
                'adjust scale in proper range
                Call gobjClsAAS203.Calculate_Analysis_Graph_Param(AASGraphAnalysis, ClsAAS203.enumChangeAxis.xyAxis)

            End If
            objfrmChangeScale.Close()
            'set the focus on read data button
            If btnReadData.Enabled Then
                btnReadData.Focus()
                btnReadData.Refresh()
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
            objfrmChangeScale.Dispose()
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            'mblnAvoidProcessing = False
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub tlbbtnExportReport_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : tlbbtnExportReport_Click
        ' Parameters Passed     : Object, EventArgs
        ' Returns               : 
        ' Purpose               : Export data to the text file format
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S & Sachin Dokhale
        ' Created               : 05.10.06
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Dim intSelectId As Integer
        Dim intCount As Integer
        Try
            'Added By Pankaj Fri 18 May 07
            ' Check for 21CFR option
            If (gstructSettings.Enable21CFR = True) Then
                If Not funcCheckActivityAuthentication(enumActivityAuthentication.Export, gstructUserDetails.Access) Then
                    Return
                    Exit Sub
                End If
                gfuncInsertActivityLog(EnumModules.Export, "Export Accessed")
            End If

            '    tlbbtnLoad.SuspendEvents()
            'mobjClsDataFileReport.MethodID = mintSelectedMethodID
            'mobjClsDataFileReport.RunNumber = mintSelectedRunNumber
            'For intCount = 0 To gobjMethodCollection.Count - 1
            '    If mintSelectedMethodID = gobjMethodCollection(intCount).MethodID Then
            '        intSelectId = intCount
            '        mobjClsDataFileReport.MethodID = intCount
            '        Exit For
            '    End If
            'Next
            Dim strRunNo As String
            'strRunNo = mobjClsMethod.QuantitativeDataCollection.Item(intCount).RunNumber

            ' Search Method id
            For intCount = 0 To gobjMethodCollection.Count - 1
                If mintSelectedMethodID = gobjMethodCollection(intCount).MethodID Then
                    'intSelectIDIndex = intCount
                    intSelectId = intCount
                    'mobjClsDataFileReport.MethodID = intCount
                    mobjClsDataFileReport.MethodID = gobjMethodCollection(intCount).MethodID
                    Exit For
                End If
            Next
            ' Search run No
            strRunNo = gobjNewMethod.QuantitativeDataCollection.Item(0).RunNumber
            For intCount = 0 To gobjMethodCollection(intSelectId).QuantitativeDataCollection.Count - 1
                If strRunNo = CInt(gobjMethodCollection(intSelectId).QuantitativeDataCollection(intCount).RunNumber) Then
                    mobjClsDataFileReport.RunNumber = CLng(strRunNo)
                    Exit For
                End If
            Next

            'For intCount = 0 To gobjMethodCollection(intSelectId).QuantitativeDataCollection.Count - 1
            '    If mintSelectedRunNumber = CInt(gobjMethodCollection(intSelectId).QuantitativeDataCollection(intCount).RunNumber) Then

            '        mobjClsDataFileReport.RunNumber = mintSelectedRunNumber
            '        Exit For
            '    End If
            'Next
            ' Send data to export facility.
            Call mobjClsDataFileReport.funcDatafileExport(gobjMethodCollection(intSelectId).QuantitativeDataCollection(intCount).ReportParameters)
            If btnReadData.Enabled Then
                btnReadData.Focus()
                btnReadData.Refresh()
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

#End Region

#Region " Private Functions "

    Private Sub ShowAspirationMessages(ByVal blnIsShow As Boolean)
        '=====================================================================
        ' Procedure Name        : ShowAspirationMessages
        ' Parameters Passed     : Flag to Set or Clear the Message.
        ' Returns               : None
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 17-Jan-2007 03:25 pm
        ' Revisions             : 1
        '=====================================================================
        'void	ShowAspMessage(BOOL	flag)
        '{
        '   char str[128]="";
        '   int t=0;
        '   if (flag)
        '   {
        '       GetDlgItemText(Mhwnd, IDC_TASP, str, 120);
        '	    ltrim(trim(str));
        '	    t = Ignite_Test();
        '	    if( (Method->Mode != MODE_UVABS && !GetHydrideModeStatus()) && (t == GREEN || t == RED) )  // mdf by sss for showing the flame error message
        '       {
        '		    SetDlgItemText(Mhwnd, IDC_TASP, "  Flame is OFF  ");
        '	    }
        '   	else
        '       {
        '   		if (strcmpi(str,Aspiratemsg)!=0)
        '		     SetDlgItemText(Mhwnd, IDC_TASP, Aspiratemsg);
        '	    }
        '   }
        '   Else
        '       SetDlgItemText(Mhwnd, IDC_TASP, "");
        '}




        Dim intIgniteType As ClsAAS203.enumIgniteType
        Dim strAspMessage As String

        Try
            'Application.DoEvents()
            If (blnIsShow) Then
                strAspMessage = Trim(lblAspirationMessage.Text)

                If gstructSettings.AppMode = EnumAppMode.DemoMode Then
                    'intIgniteType = ClsAAS203.enumIgniteType.Blue
                Else
                    'intIgniteType = gobjClsAAS203.funcIgnite_Test()
                End If

                'If ((gobjNewMethod.OperationMode <> EnumOperationMode.MODE_UVABS And Not gobjInst.Hydride) _
                '    And (intIgniteType = ClsAAS203.enumIgniteType.Green Or intIgniteType = ClsAAS203.enumIgniteType.Red)) Then
                'intIgniteType = gobjMain.IgniteType
                If ((gobjNewMethod.OperationMode <> EnumOperationMode.MODE_UVABS And Not gobjInst.Hydride) _
                    And (gobjMain.IgniteType = ClsAAS203.enumIgniteType.Green Or gobjMain.IgniteType = ClsAAS203.enumIgniteType.Red)) Then

                    'for showing the flame error message
                    lblAspirationMessage.Text = "  Flame is OFF  "
                Else
                    If String.Compare(strAspMessage, mstrAspirationMessage) <> 0 Then
                        lblAspirationMessage.Text = mstrAspirationMessage
                        lblAspirationMessage.Refresh()
                    End If
                End If

            Else
                lblAspirationMessage.Text = ""
                lblAspirationMessage.Refresh()
            End If
            'Application.DoEvents()
            'set focus to read data button
            If btnReadData.Enabled Then
                btnReadData.Focus()
                btnReadData.Refresh()
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
            'Application.DoEvents()     'Commented by Saurabh 20.07.07
            '---------------------------------------------------------
        End Try
    End Sub

    'Private Function funcCollapseAllXPPanels() As Boolean
    '    '=====================================================================
    '    ' Procedure Name        : funcCollapseAllXPPanels
    '    ' Parameters Passed     : None
    '    ' Returns               : True or False
    '    ' Purpose               : To collapse all XP Panels
    '    ' Description           : 
    '    ' Assumptions           : 
    '    ' Dependencies          : 
    '    ' Author                : Deepak Bhati
    '    ' Created               : 05.10.06
    '    ' Revisions             : 
    '    '=====================================================================
    '    Try
    '        If Me.XpPanelStandardGraph.PanelState = UIComponents.XPPanelState.Expanded Then
    '            Me.XpPanelStandardGraph.TogglePanelState()
    '            Me.XpPanelStandardGraph.Height = 0
    '        End If
    '        If Me.XpPanelSampleGraph.PanelState = UIComponents.XPPanelState.Expanded Then
    '            Me.XpPanelSampleGraph.TogglePanelState()
    '            Me.XpPanelSampleGraph.Height = 0
    '        End If
    '        If Me.XpPanelViewResults.PanelState = UIComponents.XPPanelState.Expanded Then
    '            Me.XpPanelViewResults.TogglePanelState()
    '            Me.XpPanelViewResults.Height = 0
    '        End If
    '        If Me.XpPanelReports.PanelState = UIComponents.XPPanelState.Expanded Then
    '            Me.XpPanelReports.TogglePanelState()
    '            Me.XpPanelReports.Height = 0
    '        End If

    '        Return True

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

    Private Function SetColorPropertiesForXpPanel(ByRef objXpPanelIn As UIComponents.XPPanel, ByVal strCaptionNameIn As String) As Boolean
        '=====================================================================
        ' Procedure Name        : SetColorPropertiesForXpPanel
        ' Parameters Passed     : objXpPanelIn,strCaptionNameIn
        ' Returns               : True or False
        ' Purpose               : To set color properties to xp panel
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 05.10.06
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Try
            'update data structures value for objxppanelln
            objXpPanelIn.Caption = strCaptionNameIn

            objXpPanelIn.CaptionGradient.Color2 = Color.CornflowerBlue
            objXpPanelIn.CaptionGradient.Color1 = Color.FromArgb(205, 225, 250)

            objXpPanelIn.PanelGradient.Color1 = Color.White 'Color.FromArgb(205, 225, 250)
            objXpPanelIn.PanelGradient.Color2 = Color.Gainsboro 'Color.FromArgb(175, 200, 245)

            objXpPanelIn.CaptionUnderline = Color.CornflowerBlue
            objXpPanelIn.CurveRadius = 8
            objXpPanelIn.Dock = DockStyle.None
            objXpPanelIn.GradientOffset = 0.2
            objXpPanelIn.HorzAlignment = StringAlignment.Near
            objXpPanelIn.Spacing = New Point(5, 0)
            objXpPanelIn.TextColors.Color1 = Color.FromArgb(33, 93, 198)
            objXpPanelIn.TextColors.Color2 = Color.FromArgb(0, 0, 0, 0)
            objXpPanelIn.TextHighlightColors.Color1 = Color.FromArgb(66, 142, 255)
            objXpPanelIn.TextHighlightColors.Color2 = Color.FromArgb(0, 0, 0, 0)
            objXpPanelIn.VertAlignment = StringAlignment.Center
            objXpPanelIn.XPPanelStyle = UIComponents.XPPanelStyle.WindowsXP
            objXpPanelIn.OutlineColor = Color.FromArgb(175, 200, 245)
            objXpPanelIn.Visible = True
            objXpPanelIn.PanelState = UIComponents.XPPanelState.Collapsed
            objXpPanelIn.Width = Me.Width
            objXpPanelIn.Height = 100
            objXpPanelIn.AnimationRate = 1

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

    Private Sub subInitAnalysisGraph()
        '=====================================================================
        ' Procedure Name        : subInitAnalysisGraph
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : Init. analysis graph
        '                           
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 15-Dec-2006
        ' Revisions             : 1
        '=====================================================================
        '---To set the X-axis as Time axis and its default Min, Max & Step values.
        Dim dtXMin, dtXMax As Date

        Try
            ' cal. Analysis apram. of graph.
            Call Calculate_Analysis_Graph_Param(AASGraphAnalysis)

            AASGraphAnalysis.XAxisLabel = "TIME(seconds)"
            AASGraphAnalysis.XAxisType = AldysGraph.AxisType.Linear
            AASGraphAnalysis.IsShowGrid = True
            AASGraphAnalysis.Refresh()
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
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub InitAnalysis()
        '=====================================================================
        ' Procedure Name        : InitAnalysis
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : Init. analysis parameters
        '                           
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 15-Dec-2006
        ' Revisions             : 1
        '=====================================================================
        'void	InitAnalyse(HWND hwnd,CURVEDATA 	*AnaGraph)
        '{
        'HWND hwnd1;
        ' if (Method->Mode==MODE_UVABS){
        '	ShowWindow(GetDlgItem(hwnd,IDC_UVABS), SW_SHOW);
        '	ShowWindow(GetDlgItem(hwnd,IDC_GRAPH), SW_HIDE);
        '	ShowWindow(GetDlgItem(hwnd,IDC_SCALE), SW_HIDE);
        '	ShowWindow(GetDlgItem(hwnd,IDC_PGRAPH), SW_HIDE);
        '	ShowWindow(GetDlgItem(hwnd,IDC_HSXMIN), SW_HIDE);
        '	ShowWindow(GetDlgItem(hwnd,IDC_HSXMAX), SW_HIDE);
        '  }
        ' else{
        '	ShowWindow(GetDlgItem(hwnd,IDC_UVABS), SW_HIDE);
        '	ShowWindow(GetDlgItem(hwnd,IDC_GRAPH), SW_SHOW);
        '	ShowWindow(GetDlgItem(hwnd,IDC_SCALE), SW_SHOW);
        '	ShowWindow(GetDlgItem(hwnd,IDC_PGRAPH), SW_SHOW);
        '	ShowWindow(GetDlgItem(hwnd,IDC_HSXMIN), SW_SHOW);
        '	ShowWindow(GetDlgItem(hwnd,IDC_HSXMAX), SW_SHOW);

        '	hwnd1=GetDlgItem(hwnd,IDC_GRAPH);
        '	if (hwnd1){
        '	 EnableWindow(hwnd1,TRUE);
        '	 GetWindowRect(hwnd1, &(AnaGraph->RC));
        '	 ShowWindow(hwnd1,SW_HIDE);
        '	 AnaGraph->RC.top -= 35; 	AnaGraph->RC.right-=30;
        '	 AnaGraph->RC.bottom-=40;
        '	}
        '            Else
        '	 SetRectEmpty(&AnaGraph->RC);
        '  if (Method->Mode==MODE_EMISSION){
        '		AnaGraph->Ymin=-1.0; AnaGraph->Ymax=100.0;
        '	 }
        '  else{
        '	AnaGraph->Ymin=-0.1; AnaGraph->Ymax=1.0;
        '	}
        '  AnaGraph->Xmin=0; AnaGraph->Xmax=10*10.0;
        '  Calculate_Analysis_Graph_Param(AnaGraph);
        ' }
        '}
        Try
            Select Case gobjNewMethod.OperationMode
                Case EnumOperationMode.MODE_UVABS
                    '---Do not show graph
                    lblUVAbsorbance.Visible = True
                    lblUVAbsorbance.Size = New Size(370, 87)
                    lblUVAbsorbance.Location = New Point(136, 73)
                    lblUVWavelength.Visible = True
                    lblUVWavelength.Size = New Size(370, 87)
                    lblUVWavelength.Location = New Point(136, 188)
                    AASGraphAnalysis.Visible = False
                    Call Application.DoEvents()

                Case Else
                    AASGraphAnalysis.Visible = True
                    AASGraphAnalysis.Size = New Size(1100, 380) 'Manoj
                    lblUVAbsorbance.Visible = False
                    lblUVWavelength.Visible = False
                    Call Application.DoEvents()

                    If (gobjNewMethod.OperationMode = EnumOperationMode.MODE_EMMISSION) Then
                        'update AASGraph analysis scale values
                        AASGraphAnalysis.YAxisMin = -10.0
                        AASGraphAnalysis.YAxisMax = 100.0
                        AASGraphAnalysis.YAxisStep = 20.0
                        AASGraphAnalysis.YAxisMinorStep = 5.0

                        AASGraphAnalysis.YAxisLabel = "EMISSION"
                        'Changed by Saurabh "Energy" to "Emission"
                        lblAbsorbanceMain.Text = "Emission : "
                        lblAverageAbsorbanceMain.Text = "Average Emission : "
                        lblCorrectedAbsorbanceMain.Text = "Corrected Emission : "
                    Else
                        '---changed by deepak on 29.04.07
                        AASGraphAnalysis.YAxisMin = -0.2
                        AASGraphAnalysis.YAxisMax = 0.8
                        'AASGraphAnalysis.YAxisStep = 0.1
                        'AASGraphAnalysis.YAxisMinorStep = 0.05
                        AASGraphAnalysis.YAxisStep = 0.2
                        AASGraphAnalysis.YAxisMinorStep = 0.1

                        AASGraphAnalysis.YAxisLabel = "ABSORBANCE"
                    End If
                    Call subInitAnalysisGraph()
            End Select

            '---Set Method Title
            txtMethod.Text = gobjNewMethod.MethodName

            btnReadData.Enabled = False

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

    Private Sub Test(ByRef dblX As Double, ByRef dblY As Double)
        '=====================================================================
        ' Procedure Name        : Test
        ' Parameters Passed     : dtX , dblY as Coordinate
        ' Returns               : None
        ' Purpose               : Test Analysis
        '                           
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 15-Dec-2006
        ' Revisions             : 1
        '=====================================================================
        Try
            If (dblX < 40) Then
                dblX = dblX + 5
                dblY = 0.05 * dblX * dblX
            ElseIf (dblX < 50) Then
                dblX = dblX + 5
                dblY = Math.Sqrt((dblY * dblY) - 1)
            Else
                dblX = dblX + 5
                dblY = dblY - 0.05 * dblY
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

    Private Sub Test_Time(ByRef dtXTime As Date, ByRef dblY As Double)
        '=====================================================================
        ' Procedure Name        : Test_Time
        ' Parameters Passed     : dtXTime as Time, dblY as y Coordinate
        ' Returns               : None
        ' Purpose               : Test Analysis 
        '                           
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 15-Dec-2006
        ' Revisions             : 1
        '=====================================================================
        Try
            If (dtXTime < AldysGraph.XDate.XLDateToDateTime(AASGraphAnalysis.XAxisMax)) Then
                dtXTime = dtXTime.AddMinutes(1.0)
                Dim objRnd As New Random
                dblY = objRnd.NextDouble() * 100
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

    Private Sub ResetAnaMode(ByVal intLampNumber As Integer)
        '=====================================================================
        ' Procedure Name        : ResetAnaMode
        ' Parameters Passed     : intLampNumber
        ' Returns               : None
        ' Purpose               : Reset Analysis Mode
        '                           
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 15-Dec-2006
        ' Revisions             : 1
        '=====================================================================
        '------------------------------------------------------------------------
        'void ResetAnaMode(int lampno )
        '{
        'INST_PAR	*Inst=NULL;
        'Inst =  GetInstData();
        'switch(Method->Mode){
        '	case MODE_AA:Inst->Lamp_par.lamp[lampno].mode=AA;break;
        '	case MODE_AABGC:Inst->Lamp_par.lamp[lampno].mode=AABGC;break;
        '	case MODE_EMISSION:Inst->Lamp_par.lamp[lampno].mode=EMISSION;break;
        '	case MODE_UVABS:Inst->Lamp_par.lamp[lampno].mode=MABS;break;
        '	case MODE_SPECT:if(GetInstrument() == AA202)
        '							Inst->Lamp_par.lamp[lampno].mode=AABGCSR;
        '	break;
        '}
        '}
        '------------------------------------------------------------------------

        'INST_PAR	*Inst=NULL;
        'Inst = GetInstData()

        'gobjInst = Nothing
        'Call funcInitInstrumentSettings()

        '---Get Lamp Index from Lamp Number
        Try
            intLampNumber -= 1

            Select Case gobjNewMethod.OperationMode
                Case EnumOperationMode.MODE_AA
                    gobjInst.Lamp.LampParametersCollection(intLampNumber).Mode = EnumOperationMode.MODE_AA

                Case EnumOperationMode.MODE_AABGC
                    gobjInst.Lamp.LampParametersCollection(intLampNumber).Mode = EnumOperationMode.MODE_AABGC

                Case EnumOperationMode.MODE_EMMISSION
                    gobjInst.Lamp.LampParametersCollection(intLampNumber).Mode = EnumOperationMode.MODE_EMMISSION

                Case EnumOperationMode.MODE_UVABS
                    gobjInst.Lamp.LampParametersCollection(intLampNumber).Mode = EnumOperationMode.MODE_UVABS

                Case EnumOperationMode.MODE_SPECT
                    gobjInst.Lamp.LampParametersCollection(intLampNumber).Mode = EnumOperationMode.MODE_SPECT

            End Select

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

    Private Sub Display_Analysis_Info()
        '=====================================================================
        ' Procedure Name        : Display_Analysis_Info
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : To display analysis information. 
        '                           
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 15-Dec-2006
        ' Revisions             : 1
        '=====================================================================

        '****************************************************************************************
        'AAS 16-Bit Software Code
        '****************************************************************************************
        'void	Disp_Analysis_Info(HWND hwnd)
        '{
        'char		str[60]="";
        'int		i;

        ' for(i=IDC_QSAMPID;i<=IDC_QCONC; i++)
        '	SetDlgItemText(hwnd,i, "");
        ' if (SampType==BLANK){
        '	SetDlgItemText(hwnd,IDC_QSAMPID, "BLANK");
        '	SetDlgItemText(hwnd,IDC_QRPTNO, "1");
        '	SetDlgItemText(hwnd,IDC_QCORABS, "");
        '	SetDlgItemText(hwnd,IDC_QCONC, "");
        '  }
        ' else if (SampType==STD){
        '	if (mobjCurrentStandard!=NULL){
        '	  sprintf(str, "%s",mobjCurrentStandard->Data.Std_Name);
        '	  SetDlgItemText(hwnd,IDC_QSAMPID, str);
        '	  sprintf(str, "%d",CurRepeat);
        '	  SetDlgItemText(hwnd,IDC_QRPTNO, str);
        '	  StoreResultAccurate(mobjCurrentStandard->Data.Conc, str,
        '			  Method->QuantData->Param.No_Decimals);
        '	  SetDlgItemText(hwnd,IDC_QCONC, str);
        '	 }
        '	}
        '  else if (SampType==SAMP){
        '	 if (mobjCurrentSample!=NULL){
        '	  sprintf(str, "%s",mobjCurrentSample->Data.Samp_Name);
        '	  SetDlgItemText(hwnd,IDC_QSAMPID, str);
        '	  sprintf(str, "%d",CurRepeat);
        '	  SetDlgItemText(hwnd,IDC_QRPTNO, str);
        '	  SetDlgItemText(hwnd,IDC_QCONC, "Unknown");
        '	 }
        '	}
        '}
        '****************************************************************************************
        Try
            ' display analysis information dependingupon analysis type i.s. Bank/Std/Samp. 
            lblSampleID.Text = ""
            lblRepeatNo.Text = ""
            lblCorrectedAbsorbance.Text = ""
            lblConcentration.Text = ""
            'display analysis Info Sample type wise
            Select Case SampleType
                Case ClsAAS203.enumSampleType.BLANK
                    lblSampleID.Text = "BLANK"
                    lblRepeatNo.Text = "1"
                    lblCorrectedAbsorbance.Text = ""
                    lblConcentration.Text = ""

                Case ClsAAS203.enumSampleType.STANDARD
                    If Not IsNothing(mobjCurrentStandard) Then
                        lblSampleID.Text = mobjCurrentStandard.StdName
                        lblRepeatNo.Text = CurRepeat

                        lblConcentration.Text = FormatNumber(mobjCurrentStandard.Concentration, gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfDecimalPlaces)
                    End If

                Case ClsAAS203.enumSampleType.SAMPLE
                        If Not IsNothing(mobjCurrentSample) Then
                            lblSampleID.Text = mobjCurrentSample.SampleName
                            lblRepeatNo.Text = CurRepeat
                            lblConcentration.Text = "Unknown"
                        End If
            End Select

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

    Private Sub DisplayRunNo()
        '=====================================================================
        ' Procedure Name        : DisplayRunNo
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : To display Run No on test object
        '                           
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 15-Dec-2006
        ' Revisions             : 1
        '=====================================================================

        'void	DisplayRunNo(HWND hwnd)
        '{
        'char 	str[80]="";
        '  if (!Method->QuantData)
        '	 return;
        ' if (Method->QuantData->Fname>0){
        '	sprintf(str,"%08.0f",Method->QuantData->Fname);
        '	SetWindowText(GetDlgItem(hwnd,IDC_TRUN), str);
        '  }
        '}

        Dim strRunNumber As String = ""

        Try
            ' Set the Run number to the label
            If Not IsNothing(gobjNewMethod.QuantitativeDataCollection) Then
                If (CInt(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).RunNumber) > 0) Then
                    strRunNumber = Format(CInt(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).RunNumber), "00000000")
                    lblRunNumber.Text = strRunNumber
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

    Private Sub Clear_All_Abs_Std(ByRef StdTop As Method.clsAnalysisStdParametersCollection)
        '=====================================================================
        ' Procedure Name        : Clear_All_Abs_Std
        ' Parameters Passed     : None
        ' Returns               : None
        ' Parameters Affected   : Method.clsAnalysisStdParametersCollection
        ' Purpose               : Clear Std all Abs parameter
        '                           
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 15-Dec-2006
        ' Revisions             : 1
        '=====================================================================

        '-------------------------
        'void	  S4FUNC	Clear_All_Abs_Std(STDDATA *StdTop)
        '{
        'STDDATA   *tempk=NULL;
        'ABSREPEATDATA	*rpt=NULL;

        ' tempk =StdTop;
        ' while(tempk!=NULL){
        '	 tempk->Data.Abs=(double) -1.0;
        '	 tempk=tempk->next;
        '  }
        '//---------clr repeat    add by sss on dt 21/12/1999
        'tempk =StdTop;
        'while(tempk){
        '	if(tempk->Data.AbsRepeat){
        '		rpt = tempk->Data.AbsRepeat->RptDataTop;
        '		DeleteAllAbsRepeatNodes(&rpt);
        '		free(tempk->Data.AbsRepeat);
        '		tempk->Data.AbsRepeat = NULL;
        '	}
        '	tempk =  tempk->next;
        '};
        '//------------------

        Dim rpt As Method.clsAbsRepeat

        'While (tempk! = NULL){
        '	 tempk->Data.Abs= -1.0
        '	 tempk=tempk->next
        '}
        'tempk =StdTop;
        'while(tempk){
        '	if(tempk->Data.AbsRepeat){
        '		rpt = tempk->Data.AbsRepeat->RptDataTop;
        '		DeleteAllAbsRepeatNodes(&rpt);
        '		free(tempk->Data.AbsRepeat);
        '		tempk->Data.AbsRepeat = NULL;
        '	}
        '	tempk =  tempk->next;
        '};

        'Dim objIterator As IEnumerator
        Dim intCounter As Integer

        Try
            'objIterator = StdTop.GetEnumerator()
            'objIterator.Reset()
            'While (objIterator.MoveNext)
            '    CType(objIterator.Current, Method.clsAnalysisStdParameters).Abs = -1.0
            '    'CType(objIterator.Current, Method.clsAnalysisStdParameters).AbsRepeat.AbsRepeatData.Clear()
            'End While

            ' Clear all Std parameters (Abs) object
            For intCounter = 0 To StdTop.Count - 1
                StdTop.item(intCounter).Abs = -1.0
                StdTop.item(intCounter).AbsRepeat.AbsRepeatData.Clear()
            Next intCounter

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

    Private Sub Clear_All_Abs_Conc_Samp(ByRef SampTop As Method.clsAnalysisSampleParametersCollection)
        '=====================================================================
        ' Procedure Name        : Clear_All_Abs_Conc_Samp
        ' Parameters Passed     : SampTop of Method.clsAnalysisSampleParametersCollection data type object
        ' Returns               : None
        ' Purpose               : Clear Std all Abs and Conc. parameter 
        '                           
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 15-Dec-2006
        ' Revisions             : 1
        '=====================================================================

        '//-------------------
        'void     S4FUNC	Clear_All_Abs_Conc_Samp(SAMPDATA *SampTop)
        '{
        'SAMPDATA *tempk=NULL;
        'ABSREPEATDATA	*rpt=NULL;
        ' tempk =SampTop;
        ' while(tempk!=NULL){
        '	 tempk->Data.Abs=(double) -1.0;
        '	 tempk->Data.Conc=(double) 0.0;
        '	 tempk=tempk->next;
        '  }

        'tempk =SampTop;
        'while(tempk){
        '	if (tempk->Data.AbsRepeat){
        '		rpt = tempk->Data.AbsRepeat->RptDataTop;
        '		DeleteAllAbsRepeatNodes(&rpt);
        '		free(tempk->Data.AbsRepeat);
        '		tempk->Data.AbsRepeat = NULL;
        '	}
        '	tempk =  tempk->next;
        '};
        '//------------

        'Dim objIterator As IEnumerator
        Dim intCounter As Integer

        Try
            ''objIterator = SampTop.GetEnumerator()
            ''objIterator.Reset()
            ''While (objIterator.MoveNext)
            ''    CType(objIterator.Current, Method.clsAnalysisSampleParameters).Abs = -1.0
            ''    CType(objIterator.Current, Method.clsAnalysisSampleParameters).AbsRepeat.AbsRepeatData.Clear()
            ''End While
            ' Clear all Std parameters (Cons) object
            For intCounter = 0 To SampTop.Count - 1
                SampTop.item(intCounter).Abs = -1.0
                SampTop.item(intCounter).AbsRepeat.AbsRepeatData.Clear()
            Next intCounter

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

    Private Sub CheckValidStdAbs()
        '=====================================================================
        ' Procedure Name        : CheckValidStdAbs
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : Set Validated value to the Std object parameter
        '                           
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 15-Dec-2006
        ' Revisions             : 1
        '=====================================================================

        '//----------------------
        'void		S4FUNC	CheckValidStdAbs()
        '{
        'STDDATA   *tempk=NULL;
        ' if (!Method->QuantData)
        '	return;
        ' tempk =Method->QuantData->StdTopData;
        ' while(tempk!=NULL){
        '	tempk->Data.Used=FALSE;
        '	if (tempk->Data.Abs>0.0) ////-1.0)
        '	  tempk->Data.Used=TRUE;
        '	 tempk=tempk->next;
        '  }
        '}
        '//-------------
        Dim intCount As Integer

        Try
            'Set Validated value to the Std object of used parameter
            If Not IsNothing(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection) Then
                For intCount = 0 To gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.Count - 1
                    gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount).Used = False
                    If gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount).Abs > 0.0 Then
                        gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount).Used = True
                    End If
                Next
            End If

            'If Not IsNothing(objCurStandard) Then
            '    objCurStandard.Used = False
            '    If objCurStandard.Abs > 0.0 Then
            '        objCurStandard.Used = True
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
            '---------------------------------------------------------
        End Try
    End Sub

    Private Function GetRunNo(ByVal objMethod As Method.clsMethod) As Double
        '=====================================================================
        ' Procedure Name        : GetRunNo
        ' Parameters Passed     : objMethod of Method.clsMethod data type object
        ' Returns               : Double - Return the Run Number
        ' Purpose               : Get Run No.
        '                           
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 15-Dec-2006
        ' Revisions             : 1
        '=====================================================================
        '//-------------------
        'double		S4FUNC	GetRunNo(METHOD *temp)
        '{
        'DATA4  	*aaresultdata=NULL;
        'INDEX4  	*aaresultidx=NULL;
        'double	fname=-1.0;
        'If (!temp) Then
        '   return fname;
        'If (!temp->QuantData)
        '   return fname;

        'If (!QDIopen("AARESULT",&aaresultdata, &aaresultidx))
        '{
        '   d4close_all(cb);
        '   return  FALSE;
        '}
        'If (d4reccount(aaresultdata) > 0) Then
        '   fname = Obtain_Next_Key(aaresultdata,"FNAME", FALSE);
        'Else
        '   fname=(double) 1.0;

        'temp->QuantData->Fname =fname;
        'd4close_all(cb);
        'return fname;
        '}
        '//---------------------------
        'DATA4  	*aaresultdata=NULL;
        'INDEX4  	*aaresultidx=NULL;

        Dim dblNewRunNumber As Double = -1.0

        Try
            'validate method object
            If IsNothing(objMethod) Then
                Return dblNewRunNumber
            End If

            If IsNothing(objMethod.QuantitativeDataCollection) Then
                Return dblNewRunNumber
            End If

            ''If Not (QDIopen("AARESULT", aaresultdata, aaresultidx)) Then
            ''    d4close_all(cb)
            ''    Return -1.0
            ''End If
            ''If (d4reccount(aaresultdata) > 0) Then
            ''    fname = Obtain_Next_Key(aaresultdata, "FNAME", False)
            ''Else
            ''    fname = 1.0
            ''End If
            'd4close_all(cb)
            '//----- Added by Sachin Dokhale on 25.05.07
            'dblNewRunNumber = gobjNewMethod.QuantitativeDataCollection.Count
            'gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).RunNumber = Format(dblNewRunNumber, "00000000")
            Dim intMethodCount As Integer
            Dim lngRunCount As Long
            Dim lngTotalRunNumber As Long = 0
            'get max Run number
            If Not gobjMethodCollection Is Nothing Then
                If gobjMethodCollection.Count > 0 Then
                    For intMethodCount = 0 To gobjMethodCollection.Count - 1
                        If Not gobjMethodCollection(intMethodCount).QuantitativeDataCollection Is Nothing Then
                            If gobjMethodCollection(intMethodCount).QuantitativeDataCollection.Count > 0 Then
                                For lngRunCount = 0 To gobjMethodCollection(intMethodCount).QuantitativeDataCollection.Count - 1
                                    If CLng(gobjMethodCollection(intMethodCount).QuantitativeDataCollection(lngRunCount).RunNumber) > lngTotalRunNumber Then
                                        lngTotalRunNumber = CLng(gobjMethodCollection(intMethodCount).QuantitativeDataCollection(lngRunCount).RunNumber)
                                    End If
                                Next
                                'intTotalRunNumber = gobjMethodCollection(intMethodCount).QuantitativeDataCollection.Count
                            End If
                        End If
                    Next
                End If
            End If
            ''''
            'add one to max run number 
            lngTotalRunNumber += 1
            dblNewRunNumber = Format(lngTotalRunNumber, "00000000")
            gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).RunNumber = Format(lngTotalRunNumber, "00000000")
            mlngSelectedRunNumber = lngTotalRunNumber
            Return dblNewRunNumber

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

    Private Sub Aspirate()
        '=====================================================================
        ' Procedure Name        : Aspirate
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : Aspiration message for diff. type of sample
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 17-Jan-2007 03:25 pm
        ' Revisions             : 2 by deepak on 09.09.08 for adding conc. in
        ' braces in front of standard name
        '=====================================================================
        'void   Aspirate(HWND hwnd)        
        '{
        'char	*aspMsg=NULL;
        'char	strAspMsg1[]= "Aspirate";
        'char	strAspMsg2[]="Insert Cuvete";
        'char	str[180]="";

        'if ( Method->Mode==MODE_UVABS)
        '	aspMsg =strAspMsg2;
        'Else
        '   aspMsg =strAspMsg1;

        'if (SampType==BLANK)
        '{
        '	if(Autosampler && Started )
        '	{
        '       If (!PositionAutosampler(hwnd, Str)) Then
        '		Gerror_message_system("Autosampler connection Lost");
        '	}
        '	else 
        '		sprintf(str, "%s Blank and Click &READ or press <SPACEBAR>", aspMsg);
        '}        
        'else
        '{
        '	if (SampType==STD)
        '	{
        '       If (mobjCurrentStandard! = NULL) Then
        '		{        
        '			if ( Method->QuantData->Param.ConcRepeat>1)
        '			{
        '				if(Autosampler && Started)
        '				{
        '					sprintf(str,"%s %s (Rpt #%d)from Position %d ",aspMsg,mobjCurrentStandard->Data.Std_Name, CurRepeat,mobjCurrentStandard->Data.PosNo);
        '					strcpy(Aspiratemsg, str);
        '					SetAutoSampler(hwnd,mobjCurrentStandard->Data.PosNo,TRUE);
        '				}
        '               Else
        '				    sprintf(str, " %s %s (Rpt #%d) and Click &READ or press <SPACEBAR>", aspMsg,mobjCurrentStandard->Data.Std_Name, CurRepeat); 
        '			}
        '			else
        '			{
        '				if(Autosampler && Started)
        '				{
        '					sprintf(str,"%s %s from Position %d ",aspMsg,mobjCurrentStandard->Data.Std_Name,mobjCurrentStandard->Data.PosNo);
        '					strcpy(Aspiratemsg, str);
        '					SetAutoSampler(hwnd,mobjCurrentStandard->Data.PosNo,TRUE);
        '				}
        '               Else
        '				    sprintf(str, " %s %s  and Click &READ or press <SPACEBAR>", aspMsg, mobjCurrentStandard->Data.Std_Name ); 
        '			}
        '		}
        '	}
        '	else
        '	{
        '       If (mobjCurrentSample! = NULL) Then
        '		{
        '			if ( Method->QuantData->Param.Repeat>1 )
        '			{
        '				if(Autosampler && Started)
        '				{
        '					sprintf(str,"%s %s (Repeat #%d) from Position %d ",aspMsg,mobjCurrentSample->Data.Samp_Name, CurRepeat,mobjCurrentSample->Data.SampPosNo);
        '					strcpy(Aspiratemsg, str);
        '					SetAutoSampler(hwnd,mobjCurrentSample->Data.SampPosNo,TRUE);
        '				}
        '               Else
        '					sprintf(str, " %s %s (Repeat #%d) and Click &READ or press <SPACEBAR> ", aspMsg, mobjCurrentSample->Data.Samp_Name, CurRepeat); 
        '			}
        '			else
        '			{
        '				if(Autosampler && Started)
        '				{
        '					sprintf(str, " %s %s from Position %d", aspMsg,mobjCurrentSample->Data.Samp_Name,mobjCurrentSample->Data.SampPosNo);
        '					strcpy(Aspiratemsg, str);
        '					SetAutoSampler(hwnd,mobjCurrentSample->Data.SampPosNo,TRUE);
        '				}
        '               Else
        '				    sprintf(str, " %s %s and Click &READ or press <SPACE BAR>", aspMsg, mobjCurrentSample->Data.Samp_Name);
        '			}
        '		}
        '	}
        '}

        'If (!Autosampler) Then
        '   strcpy(Aspiratemsg, str);
        'Else
        '{
        '   If (Started) Then
        '	    strcpy(Aspiratemsg, str);
        '}

        'if(Autosampler && Started)
        '	SendMessage(hwnd, WM_COMMAND, IDC_QAREAD, 0L);
        '}



        '---CODE BY MANGESH 

        Dim aspMsg As String
        Dim dblConc As Double
        Try
            ' Aspirattion message when UV ABS Mdoe is selected
            If (gobjNewMethod.OperationMode = EnumOperationMode.MODE_UVABS) Then
                aspMsg = "Insert Cuvete "
            Else
                aspMsg = "Aspirate "
            End If
            ' Aspirattion message when Blank is inserted
            If (SampleType = ClsAAS203.enumSampleType.BLANK) Then
                If (mblnIsAutosampler And mblnIsAnalysisStarted) Then
                    If Not (PositionAutosampler()) Then
                        'gobjMessageAdapter.ShowMessage("Autosampler connection Lost", "Autosampler", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage)
                        gobjMessageAdapter.ShowMessage(constAutoSamplerConnLost)
                    End If
                Else
                    mstrAspirationMessage = aspMsg & "Blank and Click READ DATA or press <SPACEBAR>"
                    '//---- Added by Sachin Dokhale
                    mobjBgMsgAspirate.AspirationMessage = mstrAspirationMessage
                    '//-----
                    '---Saurabh---20.06.07
                    If btnReadData.Enabled = True Then
                        btnReadData.Focus()
                        btnReadData.Refresh()
                    End If
                    '---Saurabh
                End If
                'BlankAlert()  '10.09.08
                gintAspirationType = 1
            Else
                ' Aspirattion message when Standard is used
                If (SampleType = ClsAAS203.enumSampleType.STANDARD) Then
                    If Not IsNothing(mobjCurrentStandard) Then
                        If (gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfStdRepeats) > 1 Then '( Method->QuantData->Param.ConcRepeat>1)
                            If (mblnIsAutosampler And mblnIsAnalysisStarted) Then
                                '+ Commented by Amit 26/03/09 ################################################
                                'mstrAspirationMessage = aspMsg & mobjCurrentStandard.StdName & " [" & FormatNumber(mobjCurrentStandard.Concentration, 2) & " ppm" & "] " & " (Repeat #" & CurRepeat & ") from Position " & mobjCurrentStandard.PositionNumber
                                '- Commented by Amit 26/03/09 ################################################

                                '+ Added by Amit 26/03/09 ################################################
                                If gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.Unit = enumUnit.PPB Then
                                    mstrAspirationMessage = aspMsg & mobjCurrentStandard.StdName & " [" & FormatNumber(mobjCurrentStandard.Concentration, CONST_Format_Value_Concentration_PPB) & Space(1) & Const_PPB & "] " & " (Repeat #" & CurRepeat & ") from Position " & mobjCurrentStandard.PositionNumber
                                Else
                                    mstrAspirationMessage = aspMsg & mobjCurrentStandard.StdName & " [" & FormatNumber(mobjCurrentStandard.Concentration, CONST_Format_Value_Concentration) & Space(1) & Const_PPM & "] " & " (Repeat #" & CurRepeat & ") from Position " & mobjCurrentStandard.PositionNumber
                                End If
                                '- Added by Amit 26/03/09 ################################################

                                mobjBgMsgAspirate.AspirationMessage = mstrAspirationMessage
                                SetAutoSampler(mobjCurrentStandard.PositionNumber, True)
                            Else
                                '+ Commented by Amit 26/03/09 ################################################
                                'mstrAspirationMessage = aspMsg & mobjCurrentStandard.StdName & " [" & FormatNumber(mobjCurrentStandard.Concentration, 2) & " ppm" & "] " & "(Repeat #" & CurRepeat & ") and Click READ DATA or press <SPACEBAR>"
                                '- Commented by Amit 26/03/09 ################################################

                                '+ Added by Amit 26/03/09 ################################################
                                If gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.Unit = enumUnit.PPB Then
                                    mstrAspirationMessage = aspMsg & mobjCurrentStandard.StdName & " [" & FormatNumber(mobjCurrentStandard.Concentration, CONST_Format_Value_Concentration_PPB) & Space(1) & Const_PPB & "] " & "(Repeat #" & CurRepeat & ") and Click READ DATA or press <SPACEBAR>"
                                Else
                                    mstrAspirationMessage = aspMsg & mobjCurrentStandard.StdName & " [" & FormatNumber(mobjCurrentStandard.Concentration, CONST_Format_Value_Concentration) & Space(1) & Const_PPM & "] " & "(Repeat #" & CurRepeat & ") and Click READ DATA or press <SPACEBAR>"
                                End If
                                '- Added by Amit 26/03/09 ################################################
                                mobjBgMsgAspirate.AspirationMessage = mstrAspirationMessage
                            End If
                        Else
                                If (mblnIsAutosampler And mblnIsAnalysisStarted) Then
                                    '+ Commented by Amit 26/03/09 ################################################
                                    'mstrAspirationMessage = aspMsg & mobjCurrentStandard.StdName & " [" & FormatNumber(mobjCurrentStandard.Concentration, 2) & " ppm" & "] " & " from Position " & mobjCurrentStandard.PositionNumber
                                    '- Commented by Amit 26/03/09 ################################################

                                '+ Added by Amit 26/03/09 ################################################
                                If gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.Unit = enumUnit.PPB Then
                                    mstrAspirationMessage = aspMsg & mobjCurrentStandard.StdName & " [" & FormatNumber(mobjCurrentStandard.Concentration, CONST_Format_Value_Concentration_PPB) & Space(1) & Const_PPB & "] " & " from Position " & mobjCurrentStandard.PositionNumber
                                Else
                                    mstrAspirationMessage = aspMsg & mobjCurrentStandard.StdName & " [" & FormatNumber(mobjCurrentStandard.Concentration, CONST_Format_Value_Concentration) & Space(1) & Const_PPM & "] " & " from Position " & mobjCurrentStandard.PositionNumber
                                End If
                                '- Added by Amit 26/03/09 ################################################
                                mobjBgMsgAspirate.AspirationMessage = mstrAspirationMessage
                                SetAutoSampler(mobjCurrentStandard.PositionNumber, True)
                            Else
                                    '+ Commented by Amit 26/03/09 ################################################
                                    'mstrAspirationMessage = aspMsg & mobjCurrentStandard.StdName & " [" & FormatNumber(mobjCurrentStandard.Concentration, 2) & " ppm" & "] " & " and Click READ DATA or press <SPACEBAR>"
                                    '- Commented by Amit 26/03/09 ################################################

                                '+ Added by Amit 26/03/09 ################################################
                                If gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.Unit = enumUnit.PPB Then
                                    mstrAspirationMessage = aspMsg & mobjCurrentStandard.StdName & " [" & FormatNumber(mobjCurrentStandard.Concentration, CONST_Format_Value_Concentration_PPB) & Space(1) & Const_PPB & "] " & " and Click READ DATA or press <SPACEBAR>"
                                Else
                                    mstrAspirationMessage = aspMsg & mobjCurrentStandard.StdName & " [" & FormatNumber(mobjCurrentStandard.Concentration, CONST_Format_Value_Concentration) & Space(1) & Const_PPM & "] " & " and Click READ DATA or press <SPACEBAR>"
                                End If
                                '- Added by Amit 26/03/09 ################################################
                                mobjBgMsgAspirate.AspirationMessage = mstrAspirationMessage
                            End If
                        End If
                        'StandardAlert()  '10.09.08
                        gintAspirationType = 2
                    End If
                Else
                    ' Aspirattion message when sample is used
                    If Not IsNothing(mobjCurrentSample) Then
                        If (gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfSampleRepeats > 1) Then
                            If (mblnIsAutosampler And mblnIsAnalysisStarted) Then
                                mstrAspirationMessage = aspMsg & mobjCurrentSample.SampleName & " (Repeat #" & CurRepeat & ") from Position " & mobjCurrentSample.SampPosNumber
                                mobjBgMsgAspirate.AspirationMessage = mstrAspirationMessage
                                SetAutoSampler(mobjCurrentSample.SampPosNumber, True)
                            Else
                                mstrAspirationMessage = aspMsg & mobjCurrentSample.SampleName & " (Repeat #" & CurRepeat & ") and Click READ DATA or press <SPACEBAR> "
                                mobjBgMsgAspirate.AspirationMessage = mstrAspirationMessage
                            End If
                        Else
                            If (mblnIsAutosampler And mblnIsAnalysisStarted) Then
                                mstrAspirationMessage = aspMsg & mobjCurrentSample.SampleName & " from Position " & mobjCurrentSample.SampPosNumber
                                mobjBgMsgAspirate.AspirationMessage = mstrAspirationMessage
                                SetAutoSampler(mobjCurrentSample.SampPosNumber, True)
                            Else
                                mstrAspirationMessage = aspMsg & mobjCurrentSample.SampleName & " and Click READ DATA or press <SPACEBAR>"
                                mobjBgMsgAspirate.AspirationMessage = mstrAspirationMessage
                            End If
                        End If
                        'SampleAlert()  '10.09.08
                        gintAspirationType = 3
                    End If
                End If
            End If

            If btnReadData.Enabled Then
                btnReadData.Focus()
                btnReadData.Refresh()
            End If
            '//----- Commented by Sachin Dokhale
            'If (mblnIsAutosampler And mblnIsAnalysisStarted) Then
            '    'SendMessage(hwnd, WM_COMMAND, IDC_QAREAD, 0L)
            '    Call ReadData_Click(btnReadData, EventArgs.Empty)
            'End If
            '//-----
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

    Private Function SetAutoSampler(ByVal pos As Integer, ByVal flag As Boolean) As Boolean
        '=====================================================================
        ' Procedure Name        : SetAutoSampler
        ' Parameters Passed     : pos as position is integer, flag is use to Set or Reset the position
        ' Returns               : None
        ' Purpose               : Set Auto Sampler
        '                           
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 15-Dec-2006
        ' Revisions             : 1
        '=====================================================================
        '---FUNCTION TEMPORARILY COMMENTED AS NO AUTOSAMPLER
        'Return False'by Pankaj for autosampler on 10Sep 07
        '---FUNCTION TEMPORARILY COMMENTED AS NO AUTOSAMPLER


        'BOOL		SetAutoSampler(HWND hpar, int pos, BOOL flag)
        '{
        'char	str[40];
        '        If (!IsSamplerConnected()) Then
        '  return FALSE;

        ' if (hpar) EnableWindow(hpar, FALSE);
        'if (flag){
        '	 sprintf(str,"Sampler => %d        ", pos);
        '	 //PrintmsgOnWvAbsTag(str);
        '	 ASamplerStart(pos,hpar);
        '	}
        'else{
        '  sprintf(str, "Resetting Sampler    ");
        '  //PrintmsgOnWvAbsTag(str);
        '  ASamplerEnd(hpar);
        ' }
        '// }
        '// SendMessage(hpar, WM_COMMAND, IDC_QAREAD, 0L);
        ' if (hpar) EnableWindow(hpar, TRUE);
        'return TRUE;
        '}

        '-------CODE BY MANGESH 
        Dim str As String

        Try
            ' Set Autosampler messages
            Application.DoEvents() 'by Pankaj
            'If Not (gstructAutoSampler.blnCommunication = False) Then
            'check communication for autosampler
            If (gstructAutoSampler.blnCommunication = False) Then 'Modified by pankaj for autosampler
                SetAutoSampler = False
                Return False
            End If

            If (flag) Then
                str = "Sampler => " & pos & "    "
                lblAspirationMessage.Text = str
                'get message text
                gfuncAutoSamplerStartStatus(pos, lblAspirationMessage, gstructAutoSampler)
                Application.DoEvents() 'by Pankaj
            Else
                str = "Resetting Sampler    "
                lblAspirationMessage.Text = str
                gfuncAutoSamplerEndStatus(lblAspirationMessage, gstructAutoSampler)
                Application.DoEvents() 'by Pankaj
            End If
            SetAutoSampler = True
            Application.DoEvents() 'by Pankaj
            Return True

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

    Private Function PositionAutosampler() As Boolean
        '=====================================================================
        ' Procedure Name        : PositionAutosampler
        ' Parameters Passed     : None
        ' Returns               : True if success
        ' Purpose               : Position to Auto Sampler
        '                           
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 15-Dec-2006
        ' Revisions             : 1
        '=====================================================================
        '---FUNCTION TEMPORARILY COMMENTED AS NO AUTOSAMPLER
        'Return False 'by Pankaj for autosampler on 10Sep 07
        '---FUNCTION TEMPORARILY COMMENTED AS NO AUTOSAMPLER


        'BOOL PositionAutosampler(HWND hwnd,char *str)
        '{
        '   int  WASH_TIME=20;
        '	GetProfileStringFromIniFile("AutoSampler", "Wash Time (sec)", "10",str, "asampler.ini");
        '	trim(ltrim(str)); 
        '   WASH_TIME=atoi(str);
        '   If (!IsSamplerConnected()) Then
        '	    return FALSE;
        '	strcpy(str,"Positioning Autosampler for Aspirating Blank");
        '   If (Started) Then
        '	    strcpy(Aspiratemsg, str);
        '	if(ASampler_GoToYhome(0))    
        '	{
        '	    if(ASampler_ProbeDown()){
        '		    sprintf(str,"Aspirating Blank wait for wash time %d sec",WASH_TIME);
        '           If (Started) Then
        '		        strcpy(Aspiratemsg, str);
        '		    ASampler_PumpON();
        '		    WaitForSec(WASH_TIME); 
        '		    ASampler_PumpOFF();
        '		 }
        '        Else
        '		    Gerror_message_system("Error in placing probe down");
        '	}
        '	else
        '	    Gerror_message_system("Error in positioning Autosampler");
        '	strcpy(str,"");
        '	return TRUE ;
        '}


        Dim WASH_TIME As Integer = 20
        Dim strTemp As String = ""

        Try
            ' Set wash time from ini setting
            strTemp = gFuncGetFromINI(CONST_Section_AutoSampler, CONST_Key_WashTime, "10", CONST_AutoSampler_INI_FileName)
            WASH_TIME = Val(Trim(strTemp))

            '---TEMPORARILY COMMENTED
            'If Not (IsSamplerConnected()) Then
            '    Return False
            'End If
            '---TEMPORARILY COMMENTED

            If (mblnIsAnalysisStarted) Then
                mstrAspirationMessage = "Positioning Autosampler for Aspirating Blank"
                lblAspirationMessage.Text = mstrAspirationMessage 'by PAnkaj on 3 Oct 07
                mobjBgMsgAspirate.AspirationMessage = mstrAspirationMessage
                Application.DoEvents() 'by Pankaj on 3 Oct 07 
            End If

            '---TEMPORARILY COMMENTED
            'If (ASampler_GoToYhome(0)) Then
            '    If (ASampler_ProbeDown()) Then
            '        If (mblnIsAnalysisStarted) Then
            '            mstrAspirationMessage = "Aspirating Blank wait for wash time " & WASH_TIME & " sec"
            '        End If
            '        ASampler_PumpON()
            '        WaitForSec(WASH_TIME)
            '        ASampler_PumpOFF()
            '    Else
            '        MessageBox.Show("Error in placing probe down")
            '    End If
            'Else
            '    MessageBox.Show("Error in positioning Autosampler")
            'End If
            '---TEMPORARILY COMMENTED
            ' position to autosampler
            ' Set Home position
            If (gobjCommProtocol.funcAutoSamplerHome()) Then
                ' Set probe down for Wash
                If gobjCommProtocol.funcAutoSamplerProbeDown() Then
                    If (mblnIsAnalysisStarted) Then
                        mstrAspirationMessage = "Aspirating Blank wait for wash time " & WASH_TIME & " sec"
                        Application.DoEvents() 'by Pankaj on 3 Oct 07
                    End If
                    ' Set pump On  for wash
                    Call gobjCommProtocol.funcAutoSamplerPumpON()
                    'ASampler_PumpON()
                    'WaitForSec(WASH_TIME)
                    ' Delay for wash time
                    'Call gobjCommProtocol.mobjCommdll.subTime_Delay(gstructAutoSampler.intWashTime * 1000)
                    Call gobjCommProtocol.mobjCommdllAutoSampler.subTime_Delay(gstructAutoSampler.intWashTime * 1000)  'added by pankaj on 25 Mar 08
                    ' Set pump off
                    Call gobjCommProtocol.funcAutoSamplerPumpOFF()
                    'ASampler_PumpOFF()
                Else
                    gobjMessageAdapter.ShowMessage("Error in placing probe down", "AutoSampler", MessageHandler.clsMessageHandler.enumMessageType.ErrorMessage) ' by Pankaj on 29 Nov 07
                    'MessageBox.Show("Error in placing probe down")
                End If
            Else
                gobjMessageAdapter.ShowMessage("Error in positioning Autosampler", "AutoSampler", MessageHandler.clsMessageHandler.enumMessageType.ErrorMessage) 'by pankaj on 29 Nov 07
                'MessageBox.Show("Error in positioning Autosampler")
            End If
            Application.DoEvents() 'by Pankaj on 3 Oct 07
            Return True
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
            '---------------------------------------------------------
        End Try
    End Function

    Private Sub SaveRawDataFile()
        '=====================================================================
        ' Procedure Name        : SaveRawDataFile
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : To save raw data for current run number.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 17-Jan-2007 03:25 pm
        ' Revisions             : 1
        '=====================================================================
        'void	SaveRawDataFile(void)
        '{
        'char	fname[128]="";
        'char	rsultfname[80]="";
        ' if (Method->QuantData && Method->QuantData->Fname>0){
        '	 GetRawDataDirectory(fname);
        '	 sprintf(rsultfname,"Saving %08.0f.dat",Method->QuantData->Fname );
        '	 SetShortHelp(rsultfname, TRUE);
        '	 sprintf(rsultfname,"%08.0f.dat",Method->QuantData->Fname );
        '	 strcat(fname, rsultfname);
        '	 RawDataSave(fname);
        '	 SetShortHelp("", TRUE);
        '	}
        '}


        'CODE BY MANGESH 

        Dim fname As String = ""
        Dim rsultfname As String = ""

        Try
            ' check Methods object for data present
            If (Not IsNothing(gobjNewMethod) And CInt(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).RunNumber) > 0) Then
                ''rsultfname = "Saving " & gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).RunNumber & ".dat"
                ''rsultfname = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).RunNumber & ".dat"
                ''fname = rsultfname
                ''Call RawDataSave(fname)
                ' store raw data into analysis data object
                gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisRawData = mobjAnalysisRawData
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

    'Private Function CheckValidStdAbsEntry(ByVal objStandardData As Method.clsAnalysisStdParametersCollection) As Boolean
    '    'BOOL CheckValidStdAbsEntry( STDDATA *std) // this fn added by sss for checking the valid std used or not dt 30/11/2K
    '    '{
    '    'double abs=0.0;
    '    'BOOL   flag = TRUE;
    '    'if(std){
    '    '	if(std->Data.Used==1){
    '    '		abs = std->Data.Abs;
    '    '		std = std=std->next;
    '    '	}
    '    '}
    '    'while(std){
    '    '	  if(std->Data.Used==1){
    '    '		  if( std->Data.Abs <= abs ){
    '    '				flag = FALSE;
    '    '				Gerror_message_new("Abs of the standard is less than or equal to the previous standard", "Standards");
    '    '				return flag;
    '    '		  }
    '    '		  abs = std->Data.Abs;
    '    '	  }
    '    '	  std=std->next;
    '    '}
    '    'return flag;
    '    '}

    '    '*****************************
    '    '---CODE BY MANGESH
    '    '*****************************
    '    Dim abs As Double = 0.0
    '    Dim flag As Boolean = True
    '    Dim intCounter As Integer

    '    Try
    '        For intCounter = 0 To objStandardData.Count - 1
    '            If (objStandardData(intCounter).Used = True) Then
    '                If (objStandardData(intCounter).Abs <= abs) Then
    '                    flag = False
    '                    Call gobjMessageAdapter.ShowMessage("Abs of the standard is less than or equal to the previous standard", "Standards", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage)
    '                    Call Application.DoEvents()
    '                    Return False
    '                End If
    '                abs = objStandardData(intCounter).Abs
    '            End If
    '        Next

    '        Return flag

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

    'Private Function CheckValidSampAbsEntry(ByVal objSampleData As Method.clsAnalysisSampleParametersCollection, ByVal dblSampConc As Double) As Boolean
    '    'BOOL CheckValidSampAbsEntry( STDDATA *std,double sampconc) // this fn added by sss for checking the valid samp used or not dt 26/12/2K
    '    '{
    '    'double abs=0.0;
    '    'BOOL   flag = TRUE;
    '    'abs=GetMaxStdAbs(std);
    '    '//if((abs+abs*0.05) < sampconc)
    '    '        If ((abs) < sampconc) Then
    '    '	flag = FALSE;
    '    'return flag;
    '    '}

    '    '******************
    '    '---CODE BY MANGESH 
    '    '******************
    '    Dim abs As Double = 0.0
    '    Dim flag As Boolean = True

    '    Try
    '        abs = GetMaxStdAbs(objSampleData)

    '        If ((abs) < dblSampConc) Then
    '            flag = False
    '        End If

    '        Return flag

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

    'Private Function GetMaxStdAbs(ByVal objSampleData As Method.clsAnalysisSampleParametersCollection) As Double
    '    'double GetMaxStdAbs(STDDATA *std)
    '    '{
    '    'double Abs=0.0;
    '    'while(std){
    '    '	  if(std->Data.Used==1){
    '    '		  if( std->Data.Abs >= Abs )
    '    '				Abs = std->Data.Abs;
    '    '	  }
    '    '	  std=std->next;
    '    '}
    '    'return Abs;
    '    '}

    '    '********************
    '    '---CODE BY MANGESH 
    '    '********************
    '    Dim dblMaxAbs As Double
    '    Dim intCounter As Integer

    '    Try
    '        dblMaxAbs = 0.0

    '        For intCounter = 0 To objSampleData.Count - 1
    '            If (objSampleData.item(intCounter).Used = True) Then
    '                If (objSampleData.item(intCounter).Abs >= dblMaxAbs) Then
    '                    dblMaxAbs = objSampleData.item(intCounter).Abs
    '                End If
    '            End If
    '        Next

    '        Return dblMaxAbs

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

    Private Function StoreCalculateDisplayQuantValue() As Double
        '=====================================================================
        ' Procedure Name        : StoreCalculateDisplayQuantValue
        ' Parameters Passed     : None
        ' Returns               : bool 
        ' Purpose               : Calculate and display of quant. analysis data.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 17-Jan-2007 03:25 pm
        ' Revisions             : 1
        '=====================================================================

        'double StoreCalculateDisplayQuantValue(HWND hwnd)
        '{
        'char	str[40]="";
        'double	abs=0.0;
        'double	abs1=0.0;
        'static	STDDATA	*nCurStd=NULL;
        'static	SAMPDATA	*nCurSamp=NULL;
        'static	double	lblank = (double) 0.0;
        'static	int	nSampType = -1 ;;

        'if(mobjCurrentStandard==Method->QuantData->StdTopData && CurRepeat==1)
        '{
        '   nCurStd=NULL;
        '	nCurSamp=NULL;
        '	lblank=(double) 0.0;
        '	nSampType=-1;;
        '}

        'if (Method->QuantData->Param.Meas_Mode==INTEGRATE)
        '{
        '   abs = GetAvgValOfCurAnalysis();
        '	abs = GetValConvertedTo(abs, Method->Mode);
        '}
        'else if (Method->QuantData->Param.Meas_Mode==PKAREA)
        '{
        '   abs = GetPeakAreaOfCurAnalysis();
        '	abs = GetValConvertedTo(abs, Method->Mode);
        '}
        'else if (Method->QuantData->Param.Meas_Mode==PKHEIGHT)
        '{
        '   abs = GetPeakHeightOfCurAnalysis();
        '	abs = GetValConvertedTo(abs, Method->Mode);
        '}

        'if (SampType == BLANK)
        '{
        '   BlankAbs = abs;
        '	GetValInString(abs, str, Method->Mode);
        '	SetDlgItemText(hwnd,IDC_QAVABS, str);
        '	SetDlgItemText(hwnd,IDC_QCORABS, "");
        '	SetDlgItemText(hwnd,IDC_QCONC, "");

        '   if (GetBlankCalType())
        '   {
        '	    BlankAbs = (lblank + BlankAbs)/2.0;
        '		if (nSampType==STD && nCurStd!=NULL)
        '       {
        '		    abs =nCurStd->Data.Abs;
        '			sprintf(str, "%s",nCurStd->Data.Std_Name);
        '	    }
        '		if (nSampType==SAMP&& nCurSamp!=NULL)
        '       {
        '		    abs =nCurSamp->Data.Abs;
        '			sprintf(str, "%s",nCurSamp->Data.Samp_Name);
        '		}
        '		SetDlgItemText(hwnd,IDC_QSAMPID, str);
        '		abs1 = StoreCalculateStdSampDisplayQuantValue(hwnd, nSampType, &nCurStd, &nCurSamp, abs);

        '		if (mobjCurrentStandard==NULL && mobjCurrentSample ==Method->QuantData->SampTopData)
        '			 Create_Standard_Sample_Curve(hwnd,FALSE);
        '   }
        '}
        'else
        '{
        '   If (!GetBlankCalType()) Then
        '	    abs1=StoreCalculateStdSampDisplayQuantValue(hwnd, SampType, &mobjCurrentStandard, &mobjCurrentSample, abs);
        '   else
        '   {
        '       if (SampType==STD && mobjCurrentStandard!=NULL)
        '		    mobjCurrentStandard->Data.Abs=abs;

        '	    if (SampType==SAMP&& mobjCurrentSample!=NULL)
        '		    mobjCurrentSample->Data.Abs=abs;

        '		 GetValInString(abs, str, Method->Mode);
        '		 SetDlgItemText(hwnd,IDC_QAVABS, str);
        '		 SetDlgItemText(hwnd,IDC_QCORABS, "");
        '		 nCurStd=mobjCurrentStandard;
        '		 nCurSamp=mobjCurrentSample;
        '		 nSampType = SampType;
        '		 lblank = BlankAbs;
        '	}
        '}
        'return abs1;
        '}


        '---CODE BY MANGESH 

        Dim strSampleName As String = ""
        Dim abs As Double = 0.0
        Dim abs1 As Double = 0.0

        Static Dim nCurStd As Method.clsAnalysisStdParameters
        Static Dim nCurSamp As Method.clsAnalysisSampleParameters
        Static Dim lblank As Double = 0.0
        Static Dim nSampType As ClsAAS203.enumSampleType = -1

        Try
            If (mobjCurrentStandard Is gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(0) And CurRepeat = 1) Then
                nCurStd = Nothing
                nCurSamp = Nothing
                lblank = 0.0
                nSampType = -1
            End If

            If (gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.MeasurementMode = enumMeasurementMode.Integrate) Then
                '---Get Average of all readings of clsRawData 
                abs = GetAvgValOfCurAnalysis()

                '---Later call this method instead of above function.
                'abs = GetAvgValOfAnalysis( .item(0) )
                '---Later on remove this comment

            ElseIf (gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.MeasurementMode = enumMeasurementMode.PeakArea) Then
                '---Returns ZERO 
                abs = GetPeakAreaOfCurAnalysis()

            ElseIf (gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.MeasurementMode = enumMeasurementMode.PeakHeight) Then
                '---Returns ZERO 
                abs = GetPeakHeightOfCurAnalysis()

            End If

            If (SampleType = ClsAAS203.enumSampleType.BLANK) Then
                mdblBlankAbsorbance = abs

                'Saurabh 05 June 2007
                'lblAverageAbsorbance.Text = FormatNumber(abs, gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfDecimalPlaces)
                'lblAverageAbsorbance.Text = FormatNumber(abs, 3)   'Commented & Added by Saurabh 01.08.07
                If gobjNewMethod.OperationMode = EnumOperationMode.MODE_EMMISSION Then
                    lblAverageAbsorbance.Text = FormatNumber(abs, 1)
                Else
                    lblAverageAbsorbance.Text = FormatNumber(abs, 3)
                End If
                'Saurabh 05 June 2007

                lblCorrectedAbsorbance.Text = ""
                lblConcentration.Text = ""

                If (gstructSettings.BlankCalculation) Then
                    mdblBlankAbsorbance = (lblank + mdblBlankAbsorbance) / 2.0

                    If nSampType = ClsAAS203.enumSampleType.STANDARD And (Not IsNothing(nCurStd)) Then
                        abs = nCurStd.Abs
                        strSampleName = nCurStd.StdName
                    End If

                    If nSampType = ClsAAS203.enumSampleType.SAMPLE And (Not IsNothing(nCurSamp)) Then
                        abs = nCurSamp.Abs
                        strSampleName = nCurSamp.SampleName
                    End If
                    lblSampleID.Text = strSampleName

                    abs1 = StoreCalculateStdSampDisplayQuantValue(nSampType, nCurStd, nCurSamp, abs)

                    'if (mobjCurrentStandard==NULL && mobjCurrentSample == Method->QuantData->SampTopData)
                    '   Create_Standard_Sample_Curve(hwnd,FALSE);
                    If (IsNothing(mobjCurrentStandard) And mobjCurrentSample Is gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(0)) Then
                        Call gobjclsStandardGraph.Create_Standard_Sample_Curve(False, True, 0, 0, gobjNewMethod)
                    End If
                End If
            Else
                If Not (gstructSettings.BlankCalculation) Then
                    abs1 = StoreCalculateStdSampDisplayQuantValue(SampleType, mobjCurrentStandard, mobjCurrentSample, abs)
                    If Not mobjCurrentStandard Is Nothing Then
                        'mobjLastStandardData = mobjCurrentStandard.Clone
                        mobjLastStandardData = mobjCurrentStandard
                    Else
                        mobjLastStandardData = Nothing
                    End If
                    If Not mobjCurrentSample Is Nothing Then
                        'mobjLastSampleData = mobjCurrentSample.Clone
                        mobjLastSampleData = mobjCurrentSample
                    Else
                        mobjLastSampleData = Nothing
                    End If
                Else
                    If (SampleType = ClsAAS203.enumSampleType.STANDARD) And Not IsNothing(mobjCurrentStandard) Then
                        mobjCurrentStandard.Abs = abs
                    End If

                    If (SampleType = ClsAAS203.enumSampleType.SAMPLE And Not IsNothing(mobjCurrentSample)) Then
                        mobjCurrentSample.Abs = abs
                    End If

                    'Saurabh 05 June 2007
                    'lblAverageAbsorbance.Text = FormatNumber(abs, gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfDecimalPlaces)
                    'lblAverageAbsorbance.Text = FormatNumber(abs, 3)   'Commented & Added by Saurabh 01.08.07
                    If gobjNewMethod.OperationMode = EnumOperationMode.MODE_EMMISSION Then
                        lblAverageAbsorbance.Text = FormatNumber(abs, 1)
                    Else
                        lblAverageAbsorbance.Text = FormatNumber(abs, 3)
                    End If
                    'Saurabh 05 June 2007

                    lblCorrectedAbsorbance.Text = ""
                    nCurStd = mobjCurrentStandard
                    nCurSamp = mobjCurrentSample
                    nSampType = SampleType
                    lblank = mdblBlankAbsorbance
                    If Not mobjCurrentStandard Is Nothing Then
                        mobjLastStandardData = mobjCurrentStandard
                    Else
                        mobjLastStandardData = Nothing
                    End If
                    If Not mobjCurrentSample Is Nothing Then
                        mobjLastSampleData = mobjCurrentSample
                    Else
                        mobjLastSampleData = Nothing
                    End If
                End If

            End If

            Return abs1

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

    Private Function RawDataSave(ByVal strFullFileName As String) As Boolean
        '=====================================================================
        ' Procedure Name        : RawDataSave
        ' Parameters Passed     : strFullFileName as String 
        ' Returns               : bool True if success
        ' Purpose               : To Save Quant Data into file system
        '                           
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 15-Dec-2006
        ' Revisions             : 1
        '=====================================================================
        'RAW_DATA 		*tempk=NULL;
        'RAW_DATA_LINKS *tempk1=NULL;
        'FILE *fp;

        Dim objRawDataReadings As Analysis.clsRawDataReadings
        Dim intCount As Integer
        Dim intReadingCounter As Integer
        Dim fs As IO.FileStream
        Dim sw As IO.StreamWriter

        Dim blnIsBlank, blnIsStandard, blnIsSample As Boolean
        Dim intPrevSampleID, intSampleID As Integer
        Dim strPath As String = ""
        Try
            '---05.12.07
            strPath = Application.StartupPath & "\" & strFullFileName
            strFullFileName = strPath

            If IsNothing(mobjAnalysisRawData) Then
                Return False
            End If
            'To Save Quant Data into text file format

            If IO.File.Exists(strFullFileName) Then IO.File.Delete(strFullFileName)

            fs = New IO.FileStream(strFullFileName, IO.FileMode.OpenOrCreate)
            sw = New IO.StreamWriter(fs)

            If Not IsNothing(sw) Then
                For intCount = 0 To mobjAnalysisRawData.Count - 1
                    objRawDataReadings = mobjAnalysisRawData.item(intCount).Readings
                    If (mobjAnalysisRawData.item(intCount).TotalReadings > 0) Then
                        intSampleID = mobjAnalysisRawData.item(intCount).SampleID
                        Select Case mobjAnalysisRawData.item(intCount).SampleType
                            '--- Write the blank data details
                        Case clsRawData.enumSampleType.BLANK
                                If Not blnIsBlank Then
                                    blnIsBlank = True
                                    blnIsStandard = False
                                    blnIsSample = False
                                    sw.WriteLine("BLANK; ; ; " & objRawDataReadings.Count)
                                Else
                                    If intSampleID <> intPrevSampleID Then
                                        sw.WriteLine()
                                        sw.WriteLine("BLANK; ; ; " & objRawDataReadings.Count)
                                    End If
                                End If
                                '--- Write the Stadard data details
                            Case clsRawData.enumSampleType.STANDARD
                                If Not blnIsStandard Then
                                    blnIsBlank = False
                                    blnIsStandard = True
                                    blnIsSample = False
                                    sw.WriteLine()
                                    sw.WriteLine("STANDARD ;" & mobjAnalysisRawData(intCount).SampleID & ";" & mobjAnalysisRawData(intCount).SampleName & "; " & objRawDataReadings.Count & "")
                                Else
                                    If intSampleID <> intPrevSampleID Then
                                        sw.WriteLine()
                                        sw.WriteLine("STANDARD ;" & mobjAnalysisRawData(intCount).SampleID & ";" & mobjAnalysisRawData(intCount).SampleName & "; " & objRawDataReadings.Count & "")
                                    End If
                                End If
                                '--- Write the Sample data details
                            Case clsRawData.enumSampleType.SAMPLE
                                If Not blnIsSample Then
                                    blnIsBlank = False
                                    blnIsStandard = False
                                    blnIsSample = True
                                    sw.WriteLine()
                                    sw.WriteLine("SAMPLE ;" & mobjAnalysisRawData(intCount).SampleID & ";" & mobjAnalysisRawData(intCount).SampleName & "; " & objRawDataReadings.Count & "")
                                Else
                                    If intSampleID <> intPrevSampleID Then
                                        sw.WriteLine()
                                        sw.WriteLine("SAMPLE ;" & mobjAnalysisRawData(intCount).SampleID & ";" & mobjAnalysisRawData(intCount).SampleName & "; " & objRawDataReadings.Count & "")
                                    End If
                                End If
                        End Select
                    End If
                    For intReadingCounter = 0 To objRawDataReadings.Count - 1
                        sw.WriteLine(objRawDataReadings(intReadingCounter).XTime & " ,  " & objRawDataReadings(intReadingCounter).Absorbance)
                    Next
                    '---Draw empty line
                    'sw.WriteLine()
                    intPrevSampleID = intSampleID
                Next intCount

            End If

            sw.Flush()
            fs.Flush()

            Return True

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
            sw.Close()
            fs.Close()
            '---------------------------------------------------------
        End Try
    End Function

    Public Function Calculate_Analysis_Graph_Param(ByRef Curve As AASGraph, Optional ByVal XValue As Double = 0.0, Optional ByVal YValue As Double = 0.0) As Double
        '=====================================================================
        ' Procedure Name        : Calculate_Analysis_Graph_Param
        ' Parameters Passed     : AASGraph Reference, XValue,YValue 
        ' Returns               : Double value
        ' Purpose               : Calculate graph parameter of analysis
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 17-Jan-2007 03:25 pm
        ' Revisions             : 1
        '=====================================================================
        Dim FrqIntv As Double = 0.0
        Dim xmax1 As Double = 0
        Dim xmin1 As Double = 0
        Dim Fmin As Double = 0
        Dim Fmax As Double = 0
        Dim Fx As Double = 0
        Dim fn, tot1 As Integer

        Try
            ' Calculate the Graph X axis coordinates 
            If IsNothing(Curve) Then
                Return 0.0
            End If

            xmax1 = Curve.YAxisMax
            xmin1 = Curve.YAxisMin
            tot1 = (xmax1 - xmin1) * 60

            FrqIntv = gobjclsStandardGraph.GetInterval(xmax1, xmin1, tot1, True)
            'FrqIntv = 100

            fn = (xmax1 / FrqIntv)
            Fmax = CDbl(fn * FrqIntv)
            If xmax1 > Fmax Then
                Fmax = Fmax + FrqIntv
            End If
            fn = CInt(xmin1 / FrqIntv)
            Fmin = CDbl(fn * FrqIntv)

            If (xmin1 < Fmin) Then
                Fmin = Fmin - FrqIntv
            End If

            If (Fmin > xmin1) And (FrqIntv <> -1.0) Then
                While (Fmin > xmin1)
                    Fmax -= FrqIntv
                End While
            End If

            If (Fmax < xmax1 And FrqIntv <> -1.0) Then
                While (Fmax < xmax1)
                    Fmax += FrqIntv
                End While
            End If
            'Curve.YAxisMin = -0.2 'Fmin
            'Curve.YAxisMax = 1.1  'Fmax
            'Curve.YAxisStep = 0.1 'FrqIntv
            'Curve.YAxisMinorStep = 0.05

            '---changed by deepak on 29.04.07
            Curve.YAxisMin = -0.2 'Fmin
            Curve.YAxisMax = 0.8  '0.8 'Fmax ' changed by pankaj
            Curve.YAxisStep = 0.2 'FrqIntv
            Curve.YAxisMinorStep = 0.2
            '---changed by deepak on 29.04.07

            '//----- Added by Sachin Dokhale
            'xmax1 = Curve.XAxisMax
            'xmin1 = Curve.XAxisMin
            If Not (XValue = 0.0) Then
                'Saurabh 10.07.07 for Scrolling Graph
                'If (XValue > Curve.XAxisMax) Then
                '    xmax1 = Curve.XAxisMax + (gobjNewMethod.AnalysisParameters.IntegrationTime * 3)
                'End If
                'xmin1 = Curve.XAxisMin
                If (XValue > Curve.XAxisMax) Then
                    xmax1 = Curve.XAxisMax + (gobjNewMethod.AnalysisParameters.IntegrationTime + 20)
                    xmin1 = Curve.XAxisMin + (gobjNewMethod.AnalysisParameters.IntegrationTime + 20)
                Else
                    xmin1 = Curve.XAxisMin
                End If

            Else
                xmax1 = Curve.XAxisMax
                xmin1 = Curve.XAxisMin
            End If

            tot1 = 60
            Fx = gobjclsStandardGraph.GetInterval(xmax1, xmin1, tot1, True)

            If (Fx > 0) Then
                fn = xmax1 / Fx
            Else
                fn = 0
            End If

            Fmax = fn * Fx
            If (xmax1 > Fmax) Then
                Fmax += Fx
            End If

            Curve.XAxisMin = xmin1
            Curve.XAxisMax = Fmax
            Curve.XAxisStep = gobjclsStandardGraph.GetInterval(Curve.XAxisMax, Curve.XAxisMin, tot1, True)

            'If is Added by Saurabh for Emission---------------
            ' Chanege parameters for Emission mode 
            If gobjNewMethod.OperationMode = EnumOperationMode.MODE_EMMISSION Then
                AASGraphAnalysis.YAxisMin = -10.0
                AASGraphAnalysis.YAxisMax = 100
                AASGraphAnalysis.YAxisMinorStep = 2
            Else
                '-----Added By Pankaj on 10 May 2007
                ' Chanege parameters for else mode
                AASGraphAnalysis.YAxisMin = -0.2
                AASGraphAnalysis.YAxisMax = 1.2
            End If

            gobjClsAAS203.Calculate_Analysis_Graph_Param(AASGraphAnalysis, ClsAAS203.enumChangeAxis.xyAxis)
            '-------------

            Return FrqIntv

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

    Public Function Read_Quant_Data(ByVal intStartTime As Integer, ByVal intEndTime As Integer) As Double
        '=====================================================================
        ' Procedure Name        : Read_Quant_Data
        ' Parameters Passed     : intStartTime as int
        '                         intEndTime  as int
        ' Returns               : Double
        ' Purpose               : Read Quant Data event 
        '                           
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 15-Dec-2006
        ' Revisions             : 1
        '=====================================================================
        'double	 (HWND hwnd, CURVEDATA *AnaGraph)
        '{
        'HDC				 hdc;
        'HPEN				 hpen, hpenold;
        'double          abs1=0.0;

        '#If QDEMO Then
        'int	adval=0;
        '  if (!Dfptr){
        '	 Dfptr= fopen("raw0.dat","rt");
        '	 if (Dfptr)
        '		 fscanf(Dfptr, "%d", &adval);
        '	}
        '#End If
        ' hdc = GetDC(hwnd);
        ' ReadFilterSetting();   // new changes
        ' if (Method->Mode==MODE_UVABS){
        '	Read_Quant_Data_UV_Mode(hwnd);
        '  }
        ' else{
        '	hpen= SetColor(SampType, TRUE);
        '   If (hpen! = NULL) Then
        '	    hpenold = SelectObject(hdc, hpen);
        '	if (Xoldt!=-1 && Yoldt!=-1)
        '	    SetXoldYold(Xoldt, Yoldt);
        '	if (Method->QuantData->Param.Meas_Mode==INTEGRATE){
        '       If (!Filter_flag) Then
        '		    Wait_For_Analysis(hwnd, 2);
        '       Else
        '		    Wait_For_Analysis(hwnd, 2);
        '		Read_Quant_Data_Integration_Mode(hwnd,hdc, AnaGraph);
        '	}
        '	else if (Method->QuantData->Param.Meas_Mode==PKAREA ||
        '	         Method->QuantData->Param.Meas_Mode==PKHEIGHT)
        '	    Read_Quant_Data_PkHt_Area_Mode(hwnd, hdc, AnaGraph);
        '   abs1=StoreCalculateDisplayQuantValue(hwnd);
        '	GetXoldYold(&Xoldt, &Yoldt);
        '	if (hpen!=NULL){
        '	    SelectObject(hdc, hpenold);
        '	DeleteObject(hpen);
        '  }
        ' }
        ' ReleaseDC(hwnd, hdc);
        ' return abs1;
        '}


        '---CODE BY MANGESH

        'HDC				 hdc;
        'HPEN				 hpen, hpenold;
        Dim dblAbsorbance As Double = 0.0

        Try
            '#If QDEMO Then
            ' dim adval as integer=0
            ' if not (Dfptr)
            '	 Dfptr= fopen("raw0.dat","rt")
            '	 if (Dfptr)
            '		 fscanf(Dfptr, "%d", &adval )
            '   end if
            '  end if
            '#End If

            ' Read the filter setting
            Call gobjClsAAS203.funcReadFilterSetting()
            '--- Start to Aspiration thread
            Call StartAspirationThread(intStartTime, intEndTime)

            ''If (gobjNewMethod.OperationMode = EnumOperationMode.MODE_UVABS) Then
            ''    'Call Read_Quant_Data_UV_Mode()
            ''Else
            ''    'hpen = SetColor(SampType, True)
            ''    'If Not (hpen Is Nothing) Then
            ''    '    hpenold = SelectObject(hdc, hpen)
            ''    'End If
            ''    'If (XOld <> -1 And YOld <> -1) Then
            ''    '    SetXoldYold(XOld, YOld)
            ''    'End If

            ''    'If (XOld <> -1 And YOld <> -1) Then
            ''    '    XOld = 0
            ''    '    YOld = 0
            ''    'End If

            ''    Call StartAspirationThread(dtStartTime)

            ''    If (gobjNewMethod.AnalysisParameters.MeasurementMode = enumMeasurementMode.Integrate) Then
            ''        If Not (Filter_flag) Then
            ''            Wait_For_Analysis(2)
            ''        Else
            ''            Wait_For_Analysis(2)
            ''        End If

            ''        'Call Read_Quant_Data_Integration_Mode()
            ''        Call StartAspirationThread(dtStartTime)

            ''    ElseIf (gobjNewMethod.AnalysisParameters.MeasurementMode = enumMeasurementMode.PeakArea Or _
            ''            gobjNewMethod.AnalysisParameters.MeasurementMode = enumMeasurementMode.PeakHeight) Then

            ''        '#########TO DO Later
            ''        Call gobjClsAAS203.Read_Quant_Data_PkHt_Area_Mode()
            ''    End If

            '----Shited to Completed event function of BgThread
            'dblAbsorbance = StoreCalculateDisplayQuantValue()
            'Call GetXoldYold(XOld, YOld)
            'If Not (hpen Is Nothing) Then
            '    'SelectObject(hdc, hpenold)
            '    'DeleteObject(hpen)
            'End If
            '##########################################

            ''End If

            Return dblAbsorbance

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

    Private Sub SetXoldYold(ByVal dblXold As Double, ByVal dblYold As Double)
        '=====================================================================
        ' Procedure Name        : SetXoldYold
        ' Parameters Passed     : dblXold, dblYold as double
        ' Returns               : None
        ' Purpose               : Set X and Y Coordinate value to module level variable
        '                           
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 15-Dec-2006
        ' Revisions             : 1
        '=====================================================================

        'void SetXoldYold(int Xoldt, int Yoldt)
        '{
        '   Xold=Xoldt;
        '   Yold= Yoldt;
        '}
        Try
            'remember x y 
            XOld = dblXold
            YOld = dblYold

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

    Private Sub GetXoldYold(ByRef dblXold As Double, ByRef dblYold As Double)
        '=====================================================================
        ' Procedure Name        : GetXoldYold
        ' Parameters Passed     : dblXold, dblYold as double
        ' Returns               : None
        ' Purpose               : get X and Y Coordinate value to module level variable
        '                           
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 15-Dec-2006
        ' Revisions             : 1
        '=====================================================================
        'void GetXoldYold(int *Xoldt, int *Yoldt)
        '{
        '   *Xoldt=Xold;
        '   *Yoldt= Yold;
        '}
        Try
            dblXold = XOld
            dblYold = YOld

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

    Private Function GetAvgValOfCurAnalysis() As Double
        '=====================================================================
        ' Procedure Name        : GetAvgValOfCurAnalysis
        ' Parameters Passed     : None
        ' Returns               : Double
        ' Purpose               : return then Avg Value of Current Analysis 
        '                           
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 15-Dec-2006
        ' Revisions             : 1
        '=====================================================================
        'double	GetAvgValOfCurAnalysis()
        '{
        ' return GetAvgValOfAnalysis(Raw->RawDataCur);        
        '}


        '---CODE BY MANGESH

        Try
            'return GetAvgValOfAnalysis(Raw->RawDataCur) 
            ' Return Avg. value of analysis Raw data
            If Not IsNothing(mobjAnalysisRawData) Then
                If mobjAnalysisRawData.Count > 0 Then
                    Return GetAvgValOfAnalysis(mobjAnalysisRawData.item(mobjAnalysisRawData.Count - 1))
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
    End Function

    Private Function GetAvgValOfAnalysis(ByVal objAnalysisRawData As clsRawData) As Double
        '=====================================================================
        ' Procedure Name        : GetAvgValOfAnalysis
        ' Parameters Passed     : objAnalysisRawData of clsRawData data type
        ' Returns               : Double
        ' Purpose               : return then Avg Value of Current Analysis of given clsRowData data type
        '                           
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 15-Dec-2006
        ' Revisions             : 1
        '=====================================================================
        '{
        'double	val=0.0;
        'int	tot=0;
        'RAW_DATA_LINKS *tempk=NULL;

        'if (node==NULL)
        '   return val;
        'tempk = node->Data.TopRawData;
        'while(tempk!=NULL)
        '{
        '   val+= tempk->Data.Abs;
        '   tot++;
        '   tempk=tempk->next;
        '}
        'If (tot > 0) Then
        '   val/=tot;
        'return val;
        '}


        '--- CODE BY MANGESH

        Dim dblAbsorbance As Double
        Dim intTotal As Integer
        Dim objRawDataReading As Analysis.clsRawDataReadings.RAW_DATA
        Dim intCounter As Integer

        Try
            'calculate Avg Value of Current Analysis of given clsRowData data type.
            intTotal = 0

            If Not IsNothing(objAnalysisRawData) Then

                For intCounter = 0 To objAnalysisRawData.Readings.Count - 1
                    objRawDataReading = objAnalysisRawData.Readings.item(intCounter)
                    dblAbsorbance += objRawDataReading.Absorbance
                    intTotal += 1
                Next intCounter

                If (intTotal > 0) Then
                    dblAbsorbance = dblAbsorbance / intTotal
                End If
            End If
            Return dblAbsorbance

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

    Private Function GetPeakAreaOfCurAnalysis() As Double
        '=====================================================================
        ' Procedure Name        : GetPeakAreaOfCurAnalysis
        ' Parameters Passed     : objAnalysisRawData of clsRawData data type
        ' Returns               : Double
        ' Purpose               : get peak area of curve of analysis
        '                           
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 15-Dec-2006
        ' Revisions             : 1
        '=====================================================================

        'double	GetPeakAreaOfCurAnalysis()
        '{
        '/* float	absorb=0.0;
        ' float	y1;
        ' float	val=0;
        ' int	 i;
        ' absorb = 0.0 ;
        ' // formaulae = dx* ((y1+y2)/2 -(y1+y')/2)
        ' read_count = findPeak_end();
        ' for (i =0; i<read_count-1; i++){
        '	y1=GetBaseExtra((float) (i+1));
        '	val = (abs_read[i+1]-y1)/2.0;
        '            If (Val() < 0) Then
        '	 val=0;
        '   absorb+=val;
        '  }
        ' clearwindow1(20, 294, 190, 306);
        ' gxy1(5, 22);
        ' absorb = get_float(absorb, TRUE);
        ' if (mode==AA||mode==AABGC) gprintf("Peak Area   : %4.3f ", absorb);
        ' else if (mode==EMISSION)   gprintf("Peak Area   : %-4.3f ", absorb);
        ' return(absorb);
        ' }
        ' */

        'return 0.0;
        '}


        '--- CODE BY MANGESH 

        Try
            Return 0.0

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

    Private Function GetPeakHeightOfCurAnalysis() As Double
        '=====================================================================
        ' Procedure Name        : GetPeakHeightOfCurAnalysis
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : get peak height of curve of analysis. 
        '                           
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 15-Dec-2006
        ' Revisions             : 1
        '=====================================================================
        'double	GetPeakHeightOfCurAnalysis()
        '{
        '   //---mdf by sk on 3/8/2001
        '   // return GetPkHtOfAnalysis(Raw->RawDataCur);
        '   //---mdf by sk on 3/8/2001
        '   /*float	peakheight()
        '   {
        '       float	absorb=0.0, sav=0.0, base=0.0;
        '       int	i;
        '       for (i =4; i<read_count-4; i++)  {
        '	        sav=abs_read[i];
        '	        if (sav > absorb){
        '	            absorb = sav;
        '	            base =  abs_read[0]+sav* (abs_read[read_count-1]-abs_read[0])/(read_count-1);
        '	            base= get_float(base, TRUE);
        '	        }
        '       }
        '       clearwindow1(20, 294, 190, 306);
        '       gxy1(5, 22);
        '       absorb -= base;
        '       absorb= get_float(absorb, TRUE);
        '       if (mode==AA||mode==AABGC) gprintf("Peak Height : %4.3f", absorb);
        '       else if (mode==EMISSION)   gprintf("Peak Height : %-4.3f", absorb);
        '       return(absorb);
        '   }
        '   */

        '   return 0.0;
        '}


        '--- CODE BY MANGESH

        Try
            Return 0.0

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

    Private Function StoreCalculateStdSampDisplayQuantValue(ByVal intSampleType As ClsAAS203.enumSampleType, _
                                                            ByRef nCurStd As Method.clsAnalysisStdParameters, _
                                                            ByRef nCurSamp As Method.clsAnalysisSampleParameters, _
                                                            ByVal dblAbsorbance As Double) As Double
        '=====================================================================
        ' Procedure Name        : StoreCalculateStdSampDisplayQuantValue
        ' Parameters Passed     : enumSampleType, dblAbsorbance 
        ' Parameters Affected   : clsAnalysisStdParameters,clsAnalysisSampleParameterss
        ' Returns               : double - Corrected Absorbance
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 17-Jan-2007 03:25 pm
        ' Revisions             : 1
        '=====================================================================
        'char	str[40]="";
        'double abs1=0.0;
        '  if (nSampType==STD){
        '	 if ((*nCurStd)!=NULL){
        '		 GetValInString(abs, str, Method->Mode);
        '		 SetDlgItemText(hwnd,IDC_QAVABS, str);
        '		 if (Method->QuantData->Param.Meas_Mode==INTEGRATE)
        '			abs-=BlankAbs;
        '		 (*nCurStd)->Data.Abs=abs;
        '//		 *nCurStd->Data.Abs = GetResultAccurate(abs, 3);
        '		 CheckValidStdAbs();
        '		 GetValInString(abs, str, Method->Mode);
        '		 SetDlgItemText(hwnd,IDC_QCORABS, str);
        '		 StoreResultAccurate((*nCurStd)->Data.Conc, str,
        '			  Method->QuantData->Param.No_Decimals);
        '		 SetDlgItemText(hwnd,IDC_QCONC, str);
        '		 if (Method->QuantData->Param.Repeat>1 || Method->QuantData->Param.ConcRepeat>1){
        '			AddAbsRepeatStd((*nCurStd)->Data.Abs, (*nCurStd)->Data.Conc,(*nCurStd));
        '			CalculateAvgOfStd((*nCurStd));
        '		  }
        '		 if (Method->Mode==MODE_EMISSION)
        '			(*nCurStd)->Data.Abs = GetResultAccurate((*nCurStd)->Data.Abs, 1);
        '                        Else
        '			 (*nCurStd)->Data.Abs = GetResultAccurate((*nCurStd)->Data.Abs, 3);
        '	  }
        '	}
        '  else if (nSampType==SAMP){
        '	 if (*nCurSamp!=NULL){
        '		 GetValInString(abs, str, Method->Mode);
        '		 SetDlgItemText(hwnd,IDC_QAVABS, str);
        '		 if (Method->QuantData->Param.Meas_Mode==INTEGRATE)
        '			abs-=BlankAbs;
        '		 (*nCurSamp)->Data.Abs=abs; // GetResultAccurate(abs, 3);
        '		 abs1 = abs; // added by sss for saving the abs of sample for checking for outoff scale on dt 27/12/2000
        '		 GetValInString(abs, str, Method->Mode);
        '		 SetDlgItemText(hwnd,IDC_QCORABS, str);
        '		 (*nCurSamp)->Data.Conc = Get_Conc((*nCurSamp)->Data.Abs, 0.0);
        '		 if ((*nCurSamp)->Data.Conc>=0 && (*nCurSamp)->Data.Abs>-0.1)
        '			(*nCurSamp)->Data.Used=TRUE;

        '		 if (Method->QuantData->Param.Repeat>1 || Method->QuantData->Param.ConcRepeat>1){
        '			AddAbsRepeatSamp((*nCurSamp)->Data.Abs, (*nCurSamp)->Data.Conc, (*nCurSamp));
        '			CalculateAvgOfSamp((*nCurSamp));
        '		  }
        '		 if (Method->Mode==MODE_EMISSION)
        '			(*nCurSamp)->Data.Abs = GetResultAccurate((*nCurSamp)->Data.Abs, 1);
        '                                            Else
        '			(*nCurSamp)->Data.Abs = GetResultAccurate((*nCurSamp)->Data.Abs, 3);
        '		 StoreResultAccurate((*nCurSamp)->Data.Conc, str,
        '			  Method->QuantData->Param.No_Decimals);
        '		 strcat(str, "   ppm");
        '		 SetDlgItemText(hwnd,IDC_QCONC, str);
        '	 }
        '	}
        '	return abs1;


        '--- CODE BY MANGESH

        Dim dblCorrectedAbsorbance As Double

        Try
            Select Case intSampleType
                Case ClsAAS203.enumSampleType.STANDARD

                    If Not IsNothing(nCurStd) Then
                        'Saurabh 05 June 2007
                        'lblAverageAbsorbance.Text = FormatNumber(abs, gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfDecimalPlaces)
                        'lblAverageAbsorbance.Text = FormatNumber(dblAbsorbance, 3) 'Commented & Added by Saurabh
                        If gobjNewMethod.OperationMode = EnumOperationMode.MODE_EMMISSION Then
                            lblAverageAbsorbance.Text = FormatNumber(dblAbsorbance, 1)
                        Else
                            lblAverageAbsorbance.Text = FormatNumber(dblAbsorbance, 3)
                        End If
                        'Saurabh 05 June 2007

                        If (gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.MeasurementMode = enumMeasurementMode.Integrate) Then
                            dblAbsorbance -= mdblBlankAbsorbance
                        End If

                        nCurStd.Abs = dblAbsorbance
                        Call CheckValidStdAbs()
                        'Saurabh 05 June 2007
                        'lblCorrectedAbsorbance.Text = FormatNumber(dblAbsorbance, gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfDecimalPlaces)
                        'lblCorrectedAbsorbance.Text = FormatNumber(dblAbsorbance, 3)      'Commented & Added by Saurabh
                        If gobjNewMethod.OperationMode = EnumOperationMode.MODE_EMMISSION Then
                            lblCorrectedAbsorbance.Text = FormatNumber(dblAbsorbance, 1)
                        Else
                            lblCorrectedAbsorbance.Text = FormatNumber(dblAbsorbance, 3)
                        End If
                        'Saurabh 05 June 2007

                        '---Store Result Accurate upto AnalysisParameters.NumOfDecimalPlaces


                        ' + Commented by Amit 26/03/2009 ##################################################
                        'lblConcentration.Text = FormatNumber(nCurStd.Concentration, gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfDecimalPlaces)
                        ' - Added by Amit 26/03/2009 ##################################################


                        '+ Added by Amit 26/03/2009 ##################################################
                        'If gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.Unit = enumUnit.PPB Then
                        lblConcentration.Text = FormatNumber(nCurStd.Concentration, gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfDecimalPlaces)
                        'Else
                        'lblConcentration.Text = FormatNumber(nCurStd.Concentration, CONST_Format_Value_Concentration)
                        'End If
                    '+ Added by Amit 26/03/2009 ##################################################

                    If (gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfStdRepeats > 1 Or _
                        gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfSampleRepeats > 1) Then

                        Call AddAbsRepeatStd(nCurStd.Abs, nCurStd.Concentration, nCurStd.AbsRepeat)
                        Call CalculateAvgOfStd(nCurStd)
                    End If

                    If (gobjNewMethod.OperationMode = EnumOperationMode.MODE_EMMISSION) Then
                        ' nCurStd.Abs = FormatNumber(nCurStd.Abs, 1)
                    Else
                        'nCurStd.Abs = FormatNumber(nCurStd.Abs, 3)
                    End If
                    End If

                Case ClsAAS203.enumSampleType.SAMPLE

                        If Not IsNothing(nCurSamp) Then

                            'Saurabh 05 June 2007
                            'lblAverageAbsorbance.Text = FormatNumber(abs, gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfDecimalPlaces)
                            'lblAverageAbsorbance.Text = FormatNumber(dblAbsorbance, 3)     'Commented & Added by Saurabh
                            If gobjNewMethod.OperationMode = EnumOperationMode.MODE_EMMISSION Then
                                lblAverageAbsorbance.Text = FormatNumber(dblAbsorbance, 1)
                            Else
                                lblAverageAbsorbance.Text = FormatNumber(dblAbsorbance, 3)
                            End If
                            'Saurabh 05 June 2007

                            If (gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.MeasurementMode = enumMeasurementMode.Integrate) Then
                                dblAbsorbance -= mdblBlankAbsorbance
                            End If

                        nCurSamp.Abs = dblAbsorbance

                        '---dblCorrectedAbsorbance = FormatNumber(dblAbsorbance, gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfDecimalPlaces) '---03.07.09
                        If gobjNewMethod.OperationMode = EnumOperationMode.MODE_EMMISSION Then  '---03.07.09
                            dblCorrectedAbsorbance = FormatNumber(dblAbsorbance, 1)
                        Else
                            dblCorrectedAbsorbance = FormatNumber(dblAbsorbance, 3)
                        End If
                        '-----------------------------

                        'Saurabh 05 June 2007
                        'lblCorrectedAbsorbance.Text = FormatNumber(dblAbsorbance, gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfDecimalPlaces)
                        'lblCorrectedAbsorbance.Text = FormatNumber(dblAbsorbance, 3)    'Commented & Added by Saurabh 01.08.07
                        If gobjNewMethod.OperationMode = EnumOperationMode.MODE_EMMISSION Then
                            lblCorrectedAbsorbance.Text = FormatNumber(dblAbsorbance, 1)
                        Else
                            lblCorrectedAbsorbance.Text = FormatNumber(dblAbsorbance, 3)
                        End If
                        'Saurabh 05 June 2007

                        nCurSamp.Conc = gobjclsStandardGraph.Get_Conc(nCurSamp.Abs, 0.0)

                        If (nCurSamp.Conc >= 0 And nCurSamp.Abs > -0.1) Then
                            nCurSamp.Used = True
                        End If

                        'if (Method->QuantData->Param.Repeat>1 || Method->QuantData->Param.ConcRepeat>1){
                        If (gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfStdRepeats > 1 Or gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfSampleRepeats > 1) Then
                            Call AddAbsRepeatSamp(nCurSamp.Abs, nCurSamp.Conc, nCurSamp.AbsRepeat)
                            Call CalculateAvgOfSamp(nCurSamp)
                        End If

                        If (gobjNewMethod.OperationMode = EnumOperationMode.MODE_EMMISSION) Then
                            'nCurSamp.Abs = FormatNumber(nCurSamp.Abs, 1)
                        Else
                            'nCurSamp.Abs = FormatNumber(nCurSamp.Abs, 3)
                        End If

                        '+ Commented by Amit 26/03/09 ################################################
                        'lblConcentration.Text = FormatNumber(nCurSamp.Conc, gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfDecimalPlaces) & " ppm"
                        '- Commented by Amit 26/03/09 ################################################

                        '+ Added by Amit 26/03/09 ################################################
                        If gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.Unit = enumUnit.PPB Then
                            lblConcentration.Text = FormatNumber(nCurSamp.Conc, gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfDecimalPlaces) & Space(1) & Const_PPB
                        Else
                            lblConcentration.Text = FormatNumber(nCurSamp.Conc, gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfDecimalPlaces) & Space(1) & Const_PPM
                        End If
                        '- Added by Amit 26/03/09 ################################################

                    End If

            End Select

            Return dblCorrectedAbsorbance

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

    Private Sub AddAbsRepeatStd(ByVal dblAbsorbance As Double, ByVal dblConcentration As Double, _
                                ByRef objAbsRepeat As Method.clsAbsRepeat)
        '=====================================================================
        ' Procedure Name        : AddAbsRepeatStd
        ' Parameters Passed     : dblAbsorbance,dblConcentration
        ' Parameters affected   : Method.clsAbsRepeat
        ' Returns               : None
        ' Purpose               : Add Repeat Abs data into Standard parameter object
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 17-Jan-2007 03:25 pm
        ' Revisions             : 1
        '=====================================================================
        'void	  S4FUNC	AddAbsRepeatStd(double data, double conc, STDDATA *cur)
        '{
        ' if (cur==NULL)
        '	return;
        ' data = GetResultAccurate(data,3);
        ' conc =  GetResultAccurate(conc,Method->QuantData->Param.No_Decimals);

        ' if (cur->Data.AbsRepeat==NULL){
        '	cur->Data.AbsRepeat = (ABSREPEAT *) malloc(sizeof(ABSREPEAT));
        '	InitAbsRepeat(cur->Data.AbsRepeat);
        '  }
        ' AddAbsRepeatData(data, conc, &(cur->Data.AbsRepeat->RptDataTop));
        '}

        '--- CODE BY MANGESH 

        Try
            ''dblAbsorbance = Math.Round(dblAbsorbance, 3)
            ''dblConcentration = Math.Round(dblConcentration, gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfDecimalPlaces)

            Call InitAbsRepeat(objAbsRepeat)

            Call AddAbsRepeatData(dblAbsorbance, dblConcentration, objAbsRepeat.AbsRepeatData)

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

    Private Sub AddAbsRepeatSamp(ByVal dblAbsorbance As Double, ByVal dblConcentration As Double, _
                                 ByRef objAbsRepeat As Method.clsAbsRepeat)
        '=====================================================================
        ' Procedure Name        : AddAbsRepeatSamp
        ' Parameters Passed     : dblAbsorbance, dblConcentration  as double
        ' Parameters Affected   : Method.clsAbsRepeat 
        ' Returns               : None
        ' Purpose               : Add Repeat Abs data into Sample parameter object
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 17-Jan-2007 03:25 pm
        ' Revisions             : 1
        '=====================================================================
        '{
        ' if (cur==NULL)
        '	return;
        ' data = GetResultAccurate(data,3);
        ' conc =  GetResultAccurate(conc,Method->QuantData->Param.No_Decimals);
        ' if (cur->Data.AbsRepeat==NULL){
        '	cur->Data.AbsRepeat = (ABSREPEAT *) malloc(sizeof(ABSREPEAT));
        '	InitAbsRepeat(cur->Data.AbsRepeat);
        '  }
        ' AddAbsRepeatData(data, conc, &(cur->Data.AbsRepeat->RptDataTop));
        '}

        '--- CODE BY MANGESH 

        Try
            'dblAbsorbance = Math.Round(dblAbsorbance, 3)
            'dblConcentration = Math.Round(dblConcentration, gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfDecimalPlaces)
            ' Add Sample Repeat data 
            Call InitAbsRepeat(objAbsRepeat)
            Call AddAbsRepeatData(dblAbsorbance, dblConcentration, objAbsRepeat.AbsRepeatData)

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

    Private Sub InitAbsRepeat(ByRef AbsRpt As Method.clsAbsRepeat)
        '=====================================================================
        ' Procedure Name        : InitAbsRepeat
        ' Parameters Passed     : Method.clsAbsRepeat
        ' Returns               : None
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 17-Jan-2007 03:25 pm
        ' Revisions             : 1
        '=====================================================================
        'void(InitAbsRepeat(ABSREPEAT * AbsRpt))
        '{
        '   if (AbsRpt==NULL)
        '	    return;
        '   AbsRpt->RptDataTop=NULL;
        '   AbsRpt->Data.TotData[0]=AbsRpt->Data.TotData[1]=(double)0.0;
        '   AbsRpt->Data.Zavg[0]=AbsRpt->Data.Zavg[1] =(double)0.0;
        '   AbsRpt->Data.CV[0]=AbsRpt->Data.CV[1] =(double)0.0;
        '   AbsRpt->Data.Zsigma[0]=AbsRpt->Data.Zsigma[1] =(double)0.0;
        '   AbsRpt->Data.Var[0]=AbsRpt->Data.Var[1] =(double)0.0;
        '   AbsRpt->Data.Min[0]=AbsRpt->Data.Min[1] =(double)0.0;
        '   AbsRpt->Data.Max[0]=AbsRpt->Data.Max[1] =(double)0.0;
        '}

        '--- CODE BY MANGESH 

        Try
            '--- Init Repeat data object
            If IsNothing(AbsRpt) Then
                AbsRpt = New Method.clsAbsRepeat

                AbsRpt.AbsRepeatData = Nothing

                AbsRpt.BasicStat.TotData(0) = 0.0
                AbsRpt.BasicStat.TotData(1) = 0.0

                AbsRpt.BasicStat.ZAvg(0) = 0.0
                AbsRpt.BasicStat.ZAvg(1) = 0.0

                AbsRpt.BasicStat.CV(0) = 0.0
                AbsRpt.BasicStat.CV(1) = 0.0

                AbsRpt.BasicStat.ZSigma(0) = 0.0
                AbsRpt.BasicStat.ZSigma(1) = 0.0

                AbsRpt.BasicStat.Var(0) = 0.0
                AbsRpt.BasicStat.Var(1) = 0.0

                AbsRpt.BasicStat.Min(0) = 0.0
                AbsRpt.BasicStat.Min(1) = 0.0

                AbsRpt.BasicStat.Max(0) = 0.0
                AbsRpt.BasicStat.Max(1) = 0.0

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

    Private Sub AddAbsRepeatData(ByVal dblAbsorbance As Double, ByVal dblConcentration As Double, _
                                 ByRef objAbsRepeatDataCollection As Method.clsAbsRepeatDataCollection)
        '=====================================================================
        ' Procedure Name        : AddAbsRepeatData
        ' Parameters Passed     : dblAbsorbance,dblConcentration 
        ' Parameter Affected    : Method.clsAbsRepeatDataCollection
        ' Returns               : None
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 17-Jan-2007 03:25 pm
        ' Revisions             : 1
        '=====================================================================
        '{
        'ABSREPEATDATA  *tempk=NULL;
        'ABSREPEATDATA  *cur=NULL;

        ' tempk = (ABSREPEATDATA*) malloc(sizeof(ABSREPEATDATA));
        ' if (tempk !=NULL){
        '  cur = GoAbsRepeatBottom(*Top);
        '  tempk->Abs=abs;
        '  tempk->Conc=conc;
        '  tempk->next=NULL;
        '  If (cur! = NULL) Then
        '    tempk->next=cur->next;
        '  if (*Top==NULL)
        '	 *Top= tempk;
        '  Else
        '    cur->next=tempk;
        '  cur = tempk;
        ' }
        '}

        '---CODE BY MANGESH

        Dim objAbsRepeatData As Method.clsAbsRepeatData

        Try
            ' Add Repeat Analysis data into object
            objAbsRepeatData = New Method.clsAbsRepeatData
            objAbsRepeatData.Abs = dblAbsorbance
            objAbsRepeatData.Concentration = dblConcentration
            objAbsRepeatData.Used = True
            '--- Add Repeat data object into collection
            If Not IsNothing(objAbsRepeatDataCollection) Then
                'objAbsRepeatDataCollection.Add(objAbsRepeatData)
                If (mblnRepeatResultSample Or mblnRepeatResultStd) And _
                    (objAbsRepeatDataCollection.Count > 0) Then
                    objAbsRepeatDataCollection.item(objAbsRepeatDataCollection.Count - 1) = objAbsRepeatData
                Else
                    objAbsRepeatDataCollection.Add(objAbsRepeatData)
                End If

            Else
                objAbsRepeatDataCollection = New Method.clsAbsRepeatDataCollection
                objAbsRepeatDataCollection.Add(objAbsRepeatData)
            End If
            mblnRepeatResultSample = False
            mblnRepeatResultStd = False
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

    Private Sub CalculateAvgOfStd(ByRef objStandard As Method.clsAnalysisStdParameters)
        '=====================================================================
        ' Procedure Name        : CalculateAvgOfStd 
        ' Parameters Passed     : Reference to the clsAnalysisStdParameters
        ' Returns               : None
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 17-Jan-2007 03:25 pm
        ' Revisions             : 1
        '=====================================================================
        '{
        ' if (mobjCurrentStandard==NULL || mobjCurrentStandard->Data.AbsRepeat==NULL)
        '	return;
        ' CalculateBasicStats(mobjCurrentStandard->Data.AbsRepeat);
        ' mobjCurrentStandard->Data.Abs = mobjCurrentStandard->Data.AbsRepeat->Data.Zavg[0];
        '}

        '---CODE BY MANGESH

        Try
            If IsNothing(objStandard) Or IsNothing(objStandard.AbsRepeat) Then
                Return
            End If
            '--- Set Avg. of Abs of Standard
            If clsBasicStatistics.CalculateBasicStats(objStandard.AbsRepeat) Then
                objStandard.Abs = objStandard.AbsRepeat.BasicStat.ZAvg(0)
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

    Private Sub CalculateAvgOfSamp(ByRef objSample As Method.clsAnalysisSampleParameters)
        '=====================================================================
        ' Procedure Name        : CalculateAvgOfSamp
        ' Parameters Passed     : Reference of clsAnalysisSampleParameters object
        ' Returns               : None
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 17-Jan-2007 03:25 pm
        ' Revisions             : 1
        '=====================================================================
        'void S4FUNC CalculateAvgOfSamp(SAMPDATA *mobjCurrentSample)
        '{
        '   if (mobjCurrentSample==NULL || mobjCurrentSample->Data.AbsRepeat==NULL)
        '	    return;
        '   CalculateBasicStats(mobjCurrentSample->Data.AbsRepeat);
        '   mobjCurrentSample->Data.Abs = mobjCurrentSample->Data.AbsRepeat->Data.Zavg[0];
        '}

        '---CODE BY MANGESH

        Try
            If IsNothing(objSample) Or IsNothing(objSample.AbsRepeat) Then
                Return
            End If
            '--- Set Avg value of abs
            If clsBasicStatistics.CalculateBasicStats(objSample.AbsRepeat) Then
                objSample.Abs = objSample.AbsRepeat.BasicStat.ZAvg(0)
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

    Private Function GetPrevStd(ByVal objStandardsCollection As Method.clsAnalysisStdParametersCollection, _
                                ByVal objCurrentStandard As Method.clsAnalysisStdParameters) As Method.clsAnalysisStdParameters
        '=====================================================================
        ' Procedure Name        : GetPrevStd
        ' Parameters Passed     : StandardDataCollection and Current Standard
        ' Returns               : Previous Standard
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 17-Jan-2007 03:25 pm
        ' Revisions             : 1
        '=====================================================================

        '--- ORIGINAL 16-bit CODE

        'STDDATA *S4FUNC GetPrevStd(STDDATA *StdTop, STDDATA *CurStd)
        '{
        '   STDDATA	*tempk=NULL;
        '   tempk = StdTop;
        '   if (CurStd == StdTop)
        '	    return tempk;
        '   while(tempk!=NULL)
        '   {
        '	    if (tempk->next==CurStd)
        '	        break;
        '       tempk=tempk->next;
        '   }
        '   return tempk;
        '}
        '***************************************************************
        Dim intCounter As Integer

        Try
            If mobjLastStandardData Is mobjCurrentStandard Then
                Return objCurrentStandard
            End If

            '--- Returns the Previous Standard from Standard Collection.
            For intCounter = 0 To objStandardsCollection.Count - 1
                If objStandardsCollection.item(intCounter) Is objCurrentStandard Then
                    Exit For
                End If
            Next intCounter

            '//----- Commented by Sachin Dokhale on 31.07.07
            'If intCounter = 0 Then
            '    Return objStandardsCollection.item(0).Clone()
            'Else
            '    Return objStandardsCollection.item(intCounter - 1).Clone()
            'End If
            '//----- Added by Sachin Dokhale on 31.07.07
            If intCounter = 0 Then
                intIEnumCollLocationStd = 1
                Return objStandardsCollection.item(0)
            Else
                intIEnumCollLocationStd -= 1
                '//---- Modified by Sachin Dokahle on 19.05.08
                'Return objStandardsCollection.item(intCounter - 1)
                'If mblnRepeatLastStd = True Then
                Return objStandardsCollection.item(intCounter)
                'End If
                '//---
            End If
            '//-----
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

    Private Function GetPrevSamp(ByVal objSamplesCollection As Method.clsAnalysisSampleParametersCollection, _
                                 ByVal objCurrentSample As Method.clsAnalysisSampleParameters) As Method.clsAnalysisSampleParameters
        '=====================================================================
        ' Procedure Name        : GetPrevSamp
        ' Parameters Passed     : SampleDataCollection and Current Sample
        ' Returns               : Previous Sample parameter
        ' Purpose               : return previous sample from sample collection object
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 17-Jan-2007 03:25 pm
        ' Revisions             : 1
        '=====================================================================

        '--- ORIGINAL 16-bit CODE

        'SAMPDATA	*S4FUNC GetPrevSamp(SAMPDATA *SampTop, SAMPDATA *CurSamp)
        '{
        '   SAMPDATA	*tempk=NULL;
        '   tempk =  SampTop;
        '   if (CurSamp==SampTop)
        '	    return tempk;
        '   while(tempk!=NULL)
        '   {
        '	    if (tempk->next==CurSamp)
        '		    break;
        '	    tempk=tempk->next;
        '   }
        '   return tempk;
        '}
        '***************************************************************
        Dim intCounter As Integer

        Try

            If mobjLastSampleData Is mobjCurrentSample Then
                Return objCurrentSample
            End If
            ' Set previous sample from sample collection object
            For intCounter = 0 To objSamplesCollection.Count - 1
                If objSamplesCollection.item(intCounter) Is objCurrentSample Then
                    Exit For
                End If
            Next intCounter
            '//----- Commented by Sachin Dokhale on 31.07.07
            '---Returns the Previous Sample from Sample Collection.
            'If intCounter = 0 Then
            '    Return objSamplesCollection.item(0).Clone()
            'Else
            '    Return objSamplesCollection.item(intCounter - 1).Clone()
            'End If
            '//----- Added by Sachin Dokhale on 31.07.07
            'If mblnRepeatLastSample = False Then
            If intCounter = 0 Then
                intIEnumCollLocationSamp = 1
                Return objSamplesCollection.item(0)
            Else
                intIEnumCollLocationSamp -= 1
                '//---- Modified by Sachin Dokahle on 19.05.08
                'Return objSamplesCollection.item(intCounter - 1)
                Return objSamplesCollection.item(intCounter)
                '//---- Modified by Sachin Dokahle on 19.05.08
            End If
            'Else

            'End If
            '//-----


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

    Private Function OnViewResults() As Boolean
        '=====================================================================
        ' Procedure Name        : OnViewResults
        ' Parameters Passed     : None
        ' Returns               : True if success or False Quantitative Data Collection is Nothing
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 01-Feb-2007 07:50 pm
        ' Revisions             : 1
        '=====================================================================


        '---- ORIGINAL CODE

        'void	OnViewResults(HWND hpar)
        '{
        '   DLGPROC  skp1;
        '	if (Method->QuantData==NULL)
        '	    return;
        '	if (GetTotStds(Method->QuantData->StdTopData, TRUE)>0)
        '	{
        '		skp1 =(DLGPROC) MakeProcInstance((DLGPROC) ViewResultsProc,hInst);
        '		DialogBox(hInst,"SHOWRESULTS", hpar, skp1);
        '		FreeProcInstance(skp1);
        '	}
        '   Else
        '	    Gerror_message_new("No Standards", "STANDARD CURVE");
        '}
        '*********************************************************
        Dim objfrmViewResults As frmViewResults

        Try
            'DLGPROC  skp1;
            'if (Method->QuantData==NULL)
            '   return;
            'end if
            If IsNothing(gobjNewMethod.QuantitativeDataCollection) Then
                Return False
            End If
            'Display Result of quant. analysis in viewlist
            If (clsStandardGraph.GetTotStds(gobjNewMethod.QuantitativeDataCollection(mintRunNumberIndex).StandardDataCollection, True) > 0) Then
                'skp1 =(DLGPROC) MakeProcInstance((DLGPROC) ViewResultsProc,hInst);
                'DialogBox(hInst,"SHOWRESULTS", hpar, skp1);
                'FreeProcInstance(skp1);
                objfrmViewResults = New frmViewResults(True, 0, 0, gobjNewMethod)
                objfrmViewResults.ShowDialog()
                Application.DoEvents()
                objfrmViewResults.Close()
                objfrmViewResults.Dispose()
                objfrmViewResults = Nothing
            Else
                Call gobjMessageAdapter.ShowMessage(constNoStandards)
                Call Application.DoEvents()
            End If

            Return True

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

    Private Sub StoreCalculateDisplayQuantValueUvMode(ByVal dblAbsorbance As Double)
        '=====================================================================
        ' Procedure Name        : StoreCalculateDisplayQuantValueUvMode
        ' Parameters Passed     : Absorbance value in UV mode
        ' Returns               : None
        ' Purpose               : To store, calculate and Display Quantitative
        '                         value in UV Mode
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 23-Apr-2007 11:45 pm
        ' Revisions             : 1
        '=====================================================================

        '---- ORIGINAL CODE

        'void	StoreCalculateDisplayQuantValueUvMode(HWND hwnd, double abs)
        '{
        '	char	str[40]="";
        '	abs = GetValConvertedTo(abs, Method->Mode);
        '	if (SampType==BLANK)
        '	{
        '	  BlankAbs=abs;
        '	}
        '	else if (SampType==STD)
        '	{
        '		if (CurStd!=NULL){
        '			CurStd->Data.Abs=abs;
        '			GetValInString(abs, str, Method->Mode);
        '			SetDlgItemText(hwnd,IDC_QAVABS, str);
        '			CheckValidStdAbs();
        '			GetValInString(abs, str, Method->Mode);
        '			SetDlgItemText(hwnd,IDC_QCORABS, str);
        '			StoreResultAccurate(CurStd->Data.Conc, str, Method->QuantData->Param.No_Decimals);
        '			SetDlgItemText(hwnd,IDC_QCONC, str);
        '			CurStd->Data.Abs = GetResultAccurate(CurStd->Data.Abs, 3);
        '		}
        '	}
        '	else if (SampType==SAMP)
        '	{
        '       If (CurSamp! = NULL) Then
        '		{
        '			GetValInString(abs, str, Method->Mode);
        '			SetDlgItemText(hwnd,IDC_QAVABS, str);
        '			CurSamp->Data.Abs=abs;
        '			GetValInString(abs, str, Method->Mode);
        '			SetDlgItemText(hwnd,IDC_QCORABS, str);
        '			CurSamp->Data.Conc = Get_Conc(CurSamp->Data.Abs, 0.0);
        '			if (CurSamp->Data.Conc>0 && CurSamp->Data.Abs>-0.1)
        '				CurSamp->Data.Used=TRUE;
        '			CurSamp->Data.Abs = GetResultAccurate(CurSamp->Data.Abs, 3);
        '			StoreResultAccurate(CurSamp->Data.Conc, str, Method->QuantData->Param.No_Decimals);
        '			strcat(str, "   ppm");
        '			SetDlgItemText(hwnd,IDC_QCONC, str);
        '		}
        '	}
        '}
        '******************************************************************
        'char	str[40]="";
        Try
            'Calculate and display of Quant. data for UV mode
            'dblAbsorbance = gfuncGetValConvertedTo(dblAbsorbance, Method.Mode)

            'Display data of Blank/Std./Sample type
            If (SampleType = ClsAAS203.enumSampleType.BLANK) Then
                mdblBlankAbsorbance = dblAbsorbance
            ElseIf (SampleType = ClsAAS203.enumSampleType.STANDARD) Then
                If Not IsNothing(mobjCurrentStandard) Then
                    'CurStd->Data.Abs=abs;
                    mobjCurrentStandard.Abs = dblAbsorbance

                    'GetValInString(abs, str, Method->Mode);
                    'SetDlgItemText(hwnd,IDC_QAVABS, str);

                    'Saurabh 05 June 2007
                    If gobjNewMethod.OperationMode = EnumOperationMode.MODE_EMMISSION Then
                        lblAverageAbsorbance.Text = FormatNumber(dblAbsorbance, 1)
                    Else
                        lblAverageAbsorbance.Text = FormatNumber(dblAbsorbance, 3)
                    End If
                    'Saurabh 05 June 2007

                    ' validate the data of std. (ABS)
                    Call CheckValidStdAbs()

                    'GetValInString(abs, str, Method->Mode);
                    'SetDlgItemText(hwnd,IDC_QCORABS, str);

                    'Saurabh 05 June 2007
                    If gobjNewMethod.OperationMode = EnumOperationMode.MODE_EMMISSION Then
                        lblCorrectedAbsorbance.Text = FormatNumber(dblAbsorbance, 1)
                    Else
                        lblCorrectedAbsorbance.Text = FormatNumber(dblAbsorbance, 3)
                    End If
                    'Saurabh 05 June 2007

                    If (gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfStdRepeats > 1 Or _
                                                gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfSampleRepeats > 1) Then

                        Call AddAbsRepeatStd(mobjCurrentStandard.Abs, mobjCurrentStandard.Concentration, mobjCurrentStandard.AbsRepeat)
                        Call CalculateAvgOfStd(mobjCurrentStandard)
                    End If

                    'StoreResultAccurate(CurStd->Data.Conc, str, Method->QuantData->Param.No_Decimals);
                    'SetDlgItemText(hwnd,IDC_QCONC, str);
                    'Saurabh To format the concentration value upto 2 decimal places 20.07.07


                    '+ Commented by Amit 26/03/09 ################################################
                    'lblConcentration.Text = FormatNumber(mobjCurrentStandard.Concentration, 2)
                    '- Commented by Amit 26/03/09 ################################################

                    '+ Added by Amit 26/03/09 ################################################
                    If gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.Unit = enumUnit.PPB Then
                        lblConcentration.Text = FormatNumber(mobjCurrentStandard.Concentration, CONST_Format_Value_Concentration_PPB)
                    Else
                        lblConcentration.Text = FormatNumber(mobjCurrentStandard.Concentration, CONST_Format_Value_Concentration)
                    End If '- Added by Amit 26/03/09 ################################################


                    'CurStd->Data.Abs = GetResultAccurate(CurStd->Data.Abs, 3);
                    mobjLastStandardData = mobjCurrentStandard
                Else
                    mobjLastStandardData = Nothing
                End If

            ElseIf (SampleType = ClsAAS203.enumSampleType.SAMPLE) Then
                If Not IsNothing(mobjCurrentSample) Then
                    'GetValInString(abs, str, Method->Mode);
                    'SetDlgItemText(hwnd,IDC_QAVABS, str);

                    'Saurabh 05 June 2007
                    If gobjNewMethod.OperationMode = EnumOperationMode.MODE_EMMISSION Then
                        lblAverageAbsorbance.Text = FormatNumber(dblAbsorbance, 1)
                    Else
                        lblAverageAbsorbance.Text = FormatNumber(dblAbsorbance, 3)
                    End If
                    'Saurabh 05 June 2007

                    'CurSamp->Data.Abs=abs;
                    mobjCurrentSample.Abs = dblAbsorbance

                    'GetValInString(abs, str, Method->Mode);
                    'SetDlgItemText(hwnd,IDC_QCORABS, str);

                    'Saurabh 05 June 2007
                    If gobjNewMethod.OperationMode = EnumOperationMode.MODE_EMMISSION Then
                        lblCorrectedAbsorbance.Text = FormatNumber(dblAbsorbance, 1)
                    Else
                        lblCorrectedAbsorbance.Text = FormatNumber(dblAbsorbance, 3)
                    End If
                    'Saurabh 05 June 2007

                    'CurSamp->Data.Conc = Get_Conc(CurSamp->Data.Abs, 0.0);
                    mobjCurrentSample.Conc = gobjclsStandardGraph.Get_Conc(mobjCurrentSample.Abs, 0.0)

                    'if (CurSamp->Data.Conc>0 && CurSamp->Data.Abs>-0.1)
                    '	CurSamp->Data.Used=TRUE;
                    'end if
                    If mobjCurrentSample.Conc > 0 And mobjCurrentSample.Abs > -0.1 Then
                        mobjCurrentSample.Used = True
                    End If

                    'CurSamp->Data.Abs = GetResultAccurate(CurSamp->Data.Abs, 3);

                    If (gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfStdRepeats > 1 Or gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfSampleRepeats > 1) Then
                        Call AddAbsRepeatSamp(mobjCurrentSample.Abs, mobjCurrentSample.Conc, mobjCurrentSample.AbsRepeat)
                        Call CalculateAvgOfSamp(mobjCurrentSample)
                    End If
                    'StoreResultAccurate(CurSamp->Data.Conc, str, Method->QuantData->Param.No_Decimals);
                    'strcat(str, "   ppm");
                    'SetDlgItemText(hwnd,IDC_QCONC, str);
                    'Saurabh To format the concentration value upto 2 decimal places 20.07.07


                    '+ Added by Amit 26/03/09 ################################################
                    'lblConcentration.Text = FormatNumber(mobjCurrentSample.Conc, 2) & "  ppm"
                    '- Added by Amit 26/03/09 ################################################


                    '+ Added by Amit 26/03/09 ################################################
                    If gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.Unit = enumUnit.PPB Then
                        lblConcentration.Text = FormatNumber(mobjCurrentSample.Conc, CONST_Format_Value_Concentration_PPB) & Space(1) & Const_PPB
                    Else
                        lblConcentration.Text = FormatNumber(mobjCurrentSample.Conc, CONST_Format_Value_Concentration) & Space(1) & Const_PPM
                    End If
                    '- Added by Amit 26/03/09 ################################################
                    mobjLastSampleData = mobjCurrentSample
                Else
                    mobjLastSampleData = Nothing
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

    Friend Function funcRefreshMethodParameter() As Boolean
        '=====================================================================
        ' Procedure Name        : funcRefreshMethodParameter
        ' Parameters Passed     : Nono
        ' Returns               : True if success.
        ' Purpose               : Reinit. property of Method object
        '                         
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : Jul 31, 2007 4:00 pm
        ' Revisions             : 1
        '=====================================================================
        Dim intStdsToRemove, intCount, intStdsRemoved, intStdsToAdd As Integer
        Dim StandardData As Method.clsAnalysisStdParameters
        Dim intRepeatCounter As Integer
        Try
            ' Reinit. property of Method object.
            If mblnIsAnalysisStarted = True Then

                If Not (gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex) Is Nothing) Then
                    If Not gobjNewMethod.AnalysisParameters Is Nothing Then
                        gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.IntegrationTime = gobjNewMethod.AnalysisParameters.IntegrationTime
                        gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.Unit = gobjNewMethod.AnalysisParameters.Unit
                        gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.IsBlankAfterEverySampleOrStd = gobjNewMethod.AnalysisParameters.IsBlankAfterEverySampleOrStd
                    End If

                    '-----23.08.07
                    '##### for standard parameters
                    If (Not gobjNewMethod.StandardDataCollection Is Nothing) And mblnIsAnalysisStarted = True Then
                        'gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection = gobjNewMethod.StandardDataCollection.Clone
                        If gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.Count > gobjNewMethod.StandardDataCollection.Count Then
                            '---if method std count is less than quantitative std count then
                            '---quantitative std which are used should be kept intact
                            '---those quantitative std which are not used should be removed.

                            intStdsToRemove = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.Count - gobjNewMethod.StandardDataCollection.Count

                            For intCount = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.Count - 1 To 0 Step -1
                                StandardData = New Method.clsAnalysisStdParameters
                                StandardData = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount).Clone
                                'gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount) = gobjNewMethod.StandardDataCollection.item(intCount).Clone
                                If intStdsRemoved < intStdsToRemove Then
                                    If gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection(intCount).Used = False Then
                                        gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.RemoveAt(intCount)
                                        intStdsRemoved += 1
                                    End If
                                Else
                                    '//----- Commented by Sachin Dokhale
                                    If gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection(intCount).Used = False Then
                                        gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount) = gobjNewMethod.StandardDataCollection.item(intCount).Clone
                                    End If
                                    '//----- Added by Sachin Dokhale

                                    If Not gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount).AbsRepeat Is Nothing Then
                                        For intRepeatCounter = 0 To StandardData.AbsRepeat.AbsRepeatData.Count - 1
                                            'gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount).AbsRepeat.AbsRepeatData(intRepeatCounter).Abs = StandardData.AbsRepeat.AbsRepeatData(intRepeatCounter).Abs
                                            gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount).AbsRepeat.AbsRepeatData.Add(StandardData.AbsRepeat.AbsRepeatData(intRepeatCounter))
                                        Next
                                        gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount).Used = StandardData.Used
                                        gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount).Abs = StandardData.Abs
                                        If intRepeatCounter > 0 Then
                                            Call CalculateAvgOfStd(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount))
                                        End If
                                    Else
                                        gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount).Used = StandardData.Used
                                        gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount).Abs = StandardData.Abs
                                    End If
                                    '//-----
                                End If
                            Next
                            intStdsRemoved = 0

                        ElseIf gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.Count = gobjNewMethod.StandardDataCollection.Count Then
                            '---if quantitative std count is equal to that of method std count then
                            '---update only those std which are not used.
                            For intCount = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.Count - 1 To 0 Step -1
                                '//----- Commented by Sachin Dokhale
                                'If gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection(intCount).Used = False Then
                                'gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount) = gobjNewMethod.StandardDataCollection.item(intCount).Clone
                                'End If
                                '//----- Added by Sachin Dokhale
                                'Dim StandardData As Method.clsAnalysisStdParameters
                                StandardData = New Method.clsAnalysisStdParameters
                                StandardData = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount).Clone
                                gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount) = gobjNewMethod.StandardDataCollection.item(intCount).Clone
                                If Not gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount).AbsRepeat Is Nothing Then

                                    For intRepeatCounter = 0 To StandardData.AbsRepeat.AbsRepeatData.Count - 1
                                        'gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount).AbsRepeat.AbsRepeatData(intRepeatCounter).Abs = StandardData.AbsRepeat.AbsRepeatData(intRepeatCounter).Abs
                                        gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount).AbsRepeat.AbsRepeatData.Add(StandardData.AbsRepeat.AbsRepeatData(intRepeatCounter))
                                    Next
                                    gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount).Used = StandardData.Used
                                    gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount).Abs = StandardData.Abs
                                    If intRepeatCounter > 0 Then
                                        Call CalculateAvgOfStd(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount))
                                    End If
                                Else
                                    gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount).Used = StandardData.Used
                                    gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount).Abs = StandardData.Abs
                                End If
                                '//-----
                            Next

                        ElseIf gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.Count < gobjNewMethod.StandardDataCollection.Count Then
                            '---if method std count is more than quantitative std count then
                            '---quantitative std which are used should be kept intact.
                            '---update quantitative std from method which are not used.
                            '---add extra stds from method to quantitative list.
                            '----Added by pankaj on 24 Jan 08
                            intStdsToAdd = gobjNewMethod.StandardDataCollection.Count - gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.Count
                            For intCount = 0 To gobjNewMethod.StandardDataCollection.Count - 1 Step 1
                                If intCount <= gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.Count - 1 Then
                                    '//----- Commented by Sachin Dokhale
                                    'If gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection(intCount).Used = False Then
                                    '    gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount) = gobjNewMethod.StandardDataCollection.item(intCount).Clone
                                    'End If
                                    '//----- Added by Sachin Dokhale
                                    StandardData = New Method.clsAnalysisStdParameters
                                    StandardData = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount).Clone
                                    gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount) = gobjNewMethod.StandardDataCollection.item(intCount).Clone
                                    If Not gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount).AbsRepeat Is Nothing Then

                                        For intRepeatCounter = 0 To StandardData.AbsRepeat.AbsRepeatData.Count - 1
                                            'gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount).AbsRepeat.AbsRepeatData(intRepeatCounter).Abs = StandardData.AbsRepeat.AbsRepeatData(intRepeatCounter).Abs
                                            gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount).AbsRepeat.AbsRepeatData.Add(StandardData.AbsRepeat.AbsRepeatData(intRepeatCounter))
                                        Next
                                        gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount).Used = StandardData.Used
                                        gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount).Abs = StandardData.Abs
                                        If intRepeatCounter > 0 Then
                                            Call CalculateAvgOfStd(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount))
                                        End If
                                    Else
                                        gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount).Used = StandardData.Used
                                        gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount).Abs = StandardData.Abs
                                    End If
                                    '//-----
                                Else
                                    gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.Add(gobjNewMethod.StandardDataCollection.item(intCount).Clone)
                                End If
                            Next
                            '--
                        End If
                    End If
                    StandardData = Nothing

                    ''###########for Sample parameters ##########################################
                    ''Added by pankaj on 22 Feb 80
                    If (Not gobjNewMethod.SampleDataCollection Is Nothing) And mblnIsAnalysisStarted = True Then
                        'gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection = gobjNewMethod.StandardDataCollection.Clone
                        If gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.Count > gobjNewMethod.SampleDataCollection.Count Then
                            '---if method std count is less than quantitative std count then
                            '---quantitative std which are used should be kept intact
                            '---those quantitative std which are not used should be removed.

                            intStdsToRemove = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.Count - gobjNewMethod.SampleDataCollection.Count

                            For intCount = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.Count - 1 To 0 Step -1
                                If intStdsRemoved < intStdsToRemove Then
                                    If gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection(intCount).Used = False Then
                                        gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.RemoveAt(intCount)
                                        intStdsRemoved += 1
                                    End If
                                Else
                                    If gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection(intCount).Used = False Then
                                        gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCount) = gobjNewMethod.SampleDataCollection.item(intCount).Clone
                                    Else
                                        gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCount).SampleName = gobjNewMethod.SampleDataCollection.item(intCount).SampleName
                                        gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCount).Weight = gobjNewMethod.SampleDataCollection.item(intCount).Weight
                                        gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCount).Volume = gobjNewMethod.SampleDataCollection.item(intCount).Volume
                                        gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCount).DilutionFactor = gobjNewMethod.SampleDataCollection.item(intCount).DilutionFactor
                                        'If Not gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCount).AbsRepeat Is Nothing Then
                                        '    For intRepeatCounter = 0 To gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCount).AbsRepeat.AbsRepeatData.Count - 1
                                        '        gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCount).AbsRepeat.AbsRepeatData(intRepeatCounter).Abs = StandardData.AbsRepeat.AbsRepeatData(intRepeatCounter).Abs
                                        '        'gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount).AbsRepeat.AbsRepeatData.Add(StandardData.AbsRepeat.AbsRepeatData(intRepeatCounter))
                                        '    Next
                                        '    'gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCount).AbsRepeat()
                                        'End If
                                    End If
                                End If
                            Next
                            intStdsRemoved = 0

                        ElseIf gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.Count = gobjNewMethod.SampleDataCollection.Count Then
                            '---if quantitative std count is equal to that of method std count then
                            '---update only those std which are not used.
                            For intCount = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.Count - 1 To 0 Step -1
                                If gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection(intCount).Used = False Then
                                    gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCount) = gobjNewMethod.SampleDataCollection.item(intCount).Clone
                                Else
                                    gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCount).SampleName = gobjNewMethod.SampleDataCollection.item(intCount).SampleName
                                    gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCount).Weight = gobjNewMethod.SampleDataCollection.item(intCount).Weight
                                    gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCount).Volume = gobjNewMethod.SampleDataCollection.item(intCount).Volume
                                    gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCount).DilutionFactor = gobjNewMethod.SampleDataCollection.item(intCount).DilutionFactor
                                End If
                            Next

                        ElseIf gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.Count < gobjNewMethod.SampleDataCollection.Count Then
                            '---if method std count is more than quantitative std count then
                            '---quantitative std which are used should be kept intact.
                            '---update quantitative std from method which are not used.
                            '---add extra stds from method to quantitative list.
                            '----Added by pankaj on 24 Jan 08
                            intStdsToAdd = gobjNewMethod.SampleDataCollection.Count - gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.Count
                            For intCount = 0 To gobjNewMethod.SampleDataCollection.Count - 1 Step 1
                                If intCount <= gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.Count - 1 Then
                                    If gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection(intCount).Used = False Then
                                        gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCount) = gobjNewMethod.SampleDataCollection.item(intCount).Clone
                                    Else
                                        gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCount).SampleName = gobjNewMethod.SampleDataCollection.item(intCount).SampleName
                                        gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCount).Weight = gobjNewMethod.SampleDataCollection.item(intCount).Weight
                                        gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCount).Volume = gobjNewMethod.SampleDataCollection.item(intCount).Volume
                                        gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCount).DilutionFactor = gobjNewMethod.SampleDataCollection.item(intCount).DilutionFactor
                                    End If
                                Else
                                    gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.Add(gobjNewMethod.SampleDataCollection.item(intCount).Clone)
                                End If
                            Next
                            '--
                        End If
                    End If

                    If Not gobjNewMethod.AnalysisParameters Is Nothing Then
                        'gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters = gobjNewMethod.AnalysisParameters.Clone
                        '---24.01.08
                        gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfSampleRepeats = gobjNewMethod.AnalysisParameters.NumOfSampleRepeats
                        gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfStdRepeats = gobjNewMethod.AnalysisParameters.NumOfStdRepeats
                        '---24.01.08
                    End If
                    '-----23.08.07

                    Call funcRefreshEnumerators(mobjStandardEnumerator, mobjSampleEnumerator)

                    '--- Set Enumerator Analysis sample Parameters
                    If mblnRepeatLastSample = False Then
                        If intIEnumCollLocationSamp > gobjNewMethod.SampleDataCollection.Count Then
                            intIEnumCollLocationSamp = gobjNewMethod.SampleDataCollection.Count + 1
                        End If
                        If funcMoveSampleEnumerator(mobjSampleEnumerator, intIEnumCollLocationSamp) = True Then
                            mobjCurrentSample = CType(mobjSampleEnumerator.Current, Method.clsAnalysisSampleParameters)
                        End If
                    End If
                    '--- Set Enumerator Analysis Standard Parameters
                    If mblnRepeatLastStd = False Then
                        If intIEnumCollLocationStd > gobjNewMethod.StandardDataCollection.Count Then
                            intIEnumCollLocationStd = gobjNewMethod.StandardDataCollection.Count + 1
                        End If
                        If funcMoveEnumerator(mobjStandardEnumerator, intIEnumCollLocationStd) = True Then
                            mobjCurrentStandard = CType(mobjStandardEnumerator.Current, Method.clsAnalysisStdParameters)
                        Else
                        End If
                    End If
                End If
            Else
                '---else block is added on 28.04.08=========
                If Not (gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex) Is Nothing) Then
                    If Not gobjNewMethod.AnalysisParameters Is Nothing Then
                        gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.IntegrationTime = gobjNewMethod.AnalysisParameters.IntegrationTime
                        gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.Unit = gobjNewMethod.AnalysisParameters.Unit
                    End If

                    '-----23.08.07
                    '##### for standard parameters
                    If (Not gobjNewMethod.StandardDataCollection Is Nothing) Then
                        'gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection = gobjNewMethod.StandardDataCollection.Clone
                        If gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.Count > gobjNewMethod.StandardDataCollection.Count Then
                            '---if method std count is less than quantitative std count then
                            '---quantitative std which are used should be kept intact
                            '---those quantitative std which are not used should be removed.

                            intStdsToRemove = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.Count - gobjNewMethod.StandardDataCollection.Count

                            For intCount = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.Count - 1 To 0 Step -1
                                StandardData = New Method.clsAnalysisStdParameters
                                StandardData = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount).Clone
                                'gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount) = gobjNewMethod.StandardDataCollection.item(intCount).Clone
                                If intStdsRemoved < intStdsToRemove Then
                                    If gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection(intCount).Used = False Then
                                        gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.RemoveAt(intCount)
                                        intStdsRemoved += 1
                                    End If
                                Else
                                    '//----- Commented by Sachin Dokhale
                                    If gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection(intCount).Used = False Then
                                        gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount) = gobjNewMethod.StandardDataCollection.item(intCount).Clone
                                    End If
                                    '//----- Added by Sachin Dokhale

                                    If Not gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount).AbsRepeat Is Nothing Then
                                        Dim absdata As clsAbsRepeatData
                                        For intRepeatCounter = 0 To StandardData.AbsRepeat.AbsRepeatData.Count - 1
                                            'gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount).AbsRepeat.AbsRepeatData(intRepeatCounter).Abs = StandardData.AbsRepeat.AbsRepeatData(intRepeatCounter).Abs   '---commented on 19.03.09
                                            '--------------'---added on 19.03.09
                                            absdata = New clsAbsRepeatData
                                            absdata = StandardData.AbsRepeat.AbsRepeatData(intRepeatCounter).Clone
                                            gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount).AbsRepeat.AbsRepeatData.Add(absdata)
                                            '-------------------
                                        Next
                                        gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount).Used = StandardData.Used
                                        gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount).Abs = StandardData.Abs
                                        If intRepeatCounter > 0 Then
                                            Call CalculateAvgOfStd(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount))
                                        End If
                                    Else
                                        gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount).Used = StandardData.Used
                                        gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount).Abs = StandardData.Abs
                                    End If
                                    '//-----
                                End If
                            Next
                            intStdsRemoved = 0

                        ElseIf gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.Count = gobjNewMethod.StandardDataCollection.Count Then
                            '---if quantitative std count is equal to that of method std count then
                            '---update only those std which are not used.
                            For intCount = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.Count - 1 To 0 Step -1
                                '//----- Commented by Sachin Dokhale
                                'If gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection(intCount).Used = False Then
                                'gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount) = gobjNewMethod.StandardDataCollection.item(intCount).Clone
                                'End If
                                '//----- Added by Sachin Dokhale
                                'Dim StandardData As Method.clsAnalysisStdParameters
                                StandardData = New Method.clsAnalysisStdParameters
                                StandardData = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount).Clone
                                gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount) = gobjNewMethod.StandardDataCollection.item(intCount).Clone
                                If Not gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount).AbsRepeat Is Nothing Then
                                    Dim absdata As clsAbsRepeatData
                                    For intRepeatCounter = 0 To StandardData.AbsRepeat.AbsRepeatData.Count - 1
                                        'gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount).AbsRepeat.AbsRepeatData(intRepeatCounter).Abs = StandardData.AbsRepeat.AbsRepeatData(intRepeatCounter).Abs '---commented on 19.03.09
                                        '--------------'---added on 19.03.09
                                        absdata = New clsAbsRepeatData
                                        absdata = StandardData.AbsRepeat.AbsRepeatData(intRepeatCounter).Clone
                                        gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount).AbsRepeat.AbsRepeatData.Add(absdata)
                                        '-------------------
                                    Next
                                    gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount).Used = StandardData.Used
                                    gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount).Abs = StandardData.Abs
                                    If intRepeatCounter > 0 Then
                                        Call CalculateAvgOfStd(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount))
                                    End If
                                Else
                                    gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount).Used = StandardData.Used
                                    gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount).Abs = StandardData.Abs
                                End If
                                '//-----
                            Next

                        ElseIf gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.Count < gobjNewMethod.StandardDataCollection.Count Then
                            '---if method std count is more than quantitative std count then
                            '---quantitative std which are used should be kept intact.
                            '---update quantitative std from method which are not used.
                            '---add extra stds from method to quantitative list.
                            '----Added by pankaj on 24 Jan 08
                            intStdsToAdd = gobjNewMethod.StandardDataCollection.Count - gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.Count
                            For intCount = 0 To gobjNewMethod.StandardDataCollection.Count - 1 Step 1
                                If intCount <= gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.Count - 1 Then
                                    '//----- Commented by Sachin Dokhale
                                    'If gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection(intCount).Used = False Then
                                    '    gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount) = gobjNewMethod.StandardDataCollection.item(intCount).Clone
                                    'End If
                                    '//----- Added by Sachin Dokhale
                                    StandardData = New Method.clsAnalysisStdParameters
                                    StandardData = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount).Clone
                                    gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount) = gobjNewMethod.StandardDataCollection.item(intCount).Clone
                                    If Not gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount).AbsRepeat Is Nothing Then
                                        Dim absdata As clsAbsRepeatData
                                        For intRepeatCounter = 0 To StandardData.AbsRepeat.AbsRepeatData.Count - 1
                                            'gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount).AbsRepeat.AbsRepeatData(intRepeatCounter).Abs = StandardData.AbsRepeat.AbsRepeatData(intRepeatCounter).Abs   '---commented on 19.03.09
                                            '--------------'---added on 19.03.09
                                            absdata = New clsAbsRepeatData
                                            absdata = StandardData.AbsRepeat.AbsRepeatData(intRepeatCounter).Clone
                                            gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount).AbsRepeat.AbsRepeatData.Add(absdata)
                                            '-------------------
                                        Next
                                        gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount).Used = StandardData.Used
                                        gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount).Abs = StandardData.Abs
                                        If intRepeatCounter > 0 Then
                                            Call CalculateAvgOfStd(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount))
                                        End If
                                    Else
                                        gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount).Used = StandardData.Used
                                        gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount).Abs = StandardData.Abs
                                    End If
                                    '//-----
                                Else
                                    gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.Add(gobjNewMethod.StandardDataCollection.item(intCount).Clone)
                                End If
                            Next
                            '--
                        End If
                    End If
                    StandardData = Nothing
                End If
                '============================================28.04.08
            End If

            If gblnIsDemoWithRealData = True Then    '16.03.08
                Dim objele As New DataTable
                Dim strEleName As String
                objele = gobjClsAAS203.funcGetElement(gobjNewMethod.InstrumentCondition.ElementID)
                If Not objele Is Nothing Then
                    If objele.Rows.Count > 0 Then
                        strEleName = LCase(objele.Rows(0).Item("Name"))
                    End If
                End If
                Select Case strEleName
                    Case "cu"
                        mintSelectedDemoFile = 1
                    Case "pb"
                        mintSelectedDemoFile = 2
                    Case "zn"
                        mintSelectedDemoFile = 3
                End Select
            End If   '16.03.08

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

    Private Sub btnImport_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : tlbbtnLoad_Click
        ' Parameters Passed     : Object, EventArgs
        ' Returns               : 
        ' Purpose               : To load the Analysis already saved.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 05.10.06
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Dim intRunNumberIndex As Long
        Dim intCounter As Integer
        Dim intCount As Integer
        Dim strRunNo As String
        Dim objfrmLoadAnalysis As New frmLoadAnalysis
        Dim objClsMethod As clsMethod
        Dim intSelectedMethodID As Integer
        Dim lngSelectedRunNumber As Long
        Try
            'tlbbtnLoad.SuspendEvents()

            ' Restore the Row Data of Run no from Data result collection object

            objfrmLoadAnalysis.GroupBox2.Visible = True
            'objfrmLoadAnalysis.btnDeleteRun.Visible = False
            objfrmLoadAnalysis.gbMultiElementReport.Visible = False
            If objfrmLoadAnalysis.ShowDialog() = DialogResult.Cancel Then
                Exit Sub
            End If

            intSelectedMethodID = objfrmLoadAnalysis.SelectedMethodID
            lngSelectedRunNumber = objfrmLoadAnalysis.SelectedRunNumber
            objfrmLoadAnalysis.Close()
            objfrmLoadAnalysis.Dispose()
            '//-----
            mobjAnalysisRawData = Nothing
            mobjAnalysisRawData = New Analysis.clsRawDataCollection

            mobjBlankRawData = Nothing
            mobjStandardRawData = Nothing
            mobjSampleRawData = Nothing

            intRunNumberIndex = modGlobalFunctions.gfuncGetSelectedMethodRunNumberIndex(mintSelectedMethodID, mlngSelectedRunNumber)

            For intCounter = 0 To gobjMethodCollection.Count - 1
                If gobjMethodCollection.item(intCounter).MethodID = intSelectedMethodID Then

                    'mobjClsMethod = gobjMethodCollection.item(intCounter).Clone()

                    'mobjClsMethod.QuantitativeDataCollection.Item(intRunNumberIndex).AnalysisRawData(0).SampleType = clsRawData.enumSampleType.BLANK
                    'Dim int As Integer
                    For intRunNumberIndex = 0 To gobjMethodCollection.item(intCounter).QuantitativeDataCollection.Count - 1
                        If lngSelectedRunNumber = gobjMethodCollection.item(intCounter).QuantitativeDataCollection.Item(intRunNumberIndex).RunNumber Then

                            Afirst = False


                            Exit For

                        End If

                    Next
                    Dim i As Integer
                    intIEnumCollLocationStd = 0
                    intIEnumCollLocationSamp = 0
                    For i = 0 To gobjMethodCollection.item(intCounter).QuantitativeDataCollection.Item(intRunNumberIndex).AnalysisRawData.Count - 1
                        mobjAnalysisRawData.Add(gobjMethodCollection.item(intCounter).QuantitativeDataCollection.Item(intRunNumberIndex).AnalysisRawData(i))
                        'mobjClsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisRawData = mobjAnalysisRawData
                        If gobjMethodCollection.item(intCounter).QuantitativeDataCollection.Item(intRunNumberIndex).AnalysisRawData(i).SampleType = clsRawData.enumSampleType.SAMPLE Then
                            intIEnumCollLocationSamp += 1
                        ElseIf gobjMethodCollection.item(intCounter).QuantitativeDataCollection.Item(intRunNumberIndex).AnalysisRawData(i).SampleType = clsRawData.enumSampleType.STANDARD Then
                            intIEnumCollLocationStd += 1
                        End If
                    Next

                    '//----

                    mobjCurrentStandard = Nothing
                    mobjCurrentSample = Nothing
                    If intIEnumCollLocationSamp <= 0 Then
                        'mobjCurrentStandard = gobjMethodCollection.item(intCounter).QuantitativeDataCollection(intRunNumberIndex).StandardDataCollection(intIEnumCollLocationStd - 1)
                        Call funcGetCurrentStandard(mobjCurrentStandard)
                    Else
                        'mobjCurrentSample = gobjMethodCollection.item(intCounter).QuantitativeDataCollection(intRunNumberIndex).SampleDataCollection(intIEnumCollLocationSamp - 1)
                        Call funcGetCurrentSample(mobjCurrentSample)
                    End If



                    Dim i1 As Integer = gobjMethodCollection.item(intCounter).QuantitativeDataCollection.Item(intRunNumberIndex).AnalysisRawData(i - 1).Readings.Count - 1

                    mobjBgReadData.CEndTime = gobjMethodCollection.item(intCounter).QuantitativeDataCollection(intRunNumberIndex).AnalysisRawData(i - 1).Readings(i1).XTime
                    mEndTime = mobjBgReadData.CEndTime
                    SampleType = gobjMethodCollection.item(intCounter).QuantitativeDataCollection.Item(intRunNumberIndex).AnalysisRawData(i - 1).SampleType
                    Call NextAnalysis_Clicked(btnNextAnalysis, EventArgs.Empty)
                    Application.DoEvents()
                    Call Aspirate()
                    Application.DoEvents()
                    '//----- Sachin Dokhale
                    'StdAnalysed=TRUE;
                    'toreported=TRUE;
                    'InvalidateRect(hwnd, NULL, TRUE);
                    'EnableWindow(GetDlgItem(hwnd,IDC_SAVEREPORT), StdAnalysed);
                    StdAnalysed = True
                    toreported = True
                    btnSave.Enabled = StdAnalysed
                    '//-----



                    'Call funcShowMethodGeneralInfo(mobjClsMethod, strRunNo)
                    Select Case gobjMethodCollection.item(intCounter).OperationMode
                        Case EnumOperationMode.MODE_UVABS
                            AASGraphAnalysis.Visible = False
                        Case Else
                            strRunNo = gobjMethodCollection.item(intCounter).QuantitativeDataCollection.Item(intRunNumberIndex).RunNumber
                            AASGraphAnalysis.Visible = True
                            Call gobjClsAAS203.subShowGraphPreview(Me.AASGraphAnalysis, mobjGraphCurve, strRunNo, gobjMethodCollection.item(intCounter))
                            AASGraphAnalysis.Invalidate()
                            AASGraphAnalysis.IsShowGrid = True      'Saurabh To show Grid 19.07.07
                            AASGraphAnalysis.Refresh()
                            Me.Refresh()
                            Application.DoEvents()
                    End Select


                    Exit For

                End If
            Next

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
            'tlbbtnLoad.ResumeEvents()
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub btnIgnite_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : btnIgnite_Click
        ' Parameters Passed     : Object, EventArgs
        ' Returns               : 
        ' Purpose               : Ignite the flame
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S & Sachin Dokhale
        ' Created               : 05.10.06
        ' Revisions             : 
        '=====================================================================
        If mblnAvoidProcessing = True Then
            Exit Sub
        End If
        Try

            mblnAvoidProcessing = True
            ' this event Terminate required Thread and start the auto ignition process for AA Flame
            gobjMain.AutoIgnition()
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

    Private Sub btnExtinguish_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : btnExtinguish_Click
        ' Parameters Passed     : Object, EventArgs
        ' Returns               : 
        ' Purpose               : Extinguish the flame
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S & Sachin Dokhale
        ' Created               : 05.10.06
        ' Revisions             : 
        '=====================================================================
        If mblnAvoidProcessing = True Then
            Exit Sub
        End If
        Try
            mblnAvoidProcessing = True

            ' this event Extinguish the flame 
            gobjMain.Extinguish()
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

    Private Sub btnN2OIgnite_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : btnN2OIgnite_Click
        ' Parameters Passed     : Object, EventArgs
        ' Returns               : 
        ' Purpose               : Ignite the N2O flame
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S & Sachin Dokhale
        ' Created               : 05.10.06
        ' Revisions             : 
        '=====================================================================
        If mblnAvoidProcessing = True Then
            Exit Sub
        End If
        Try
            mblnAvoidProcessing = True

            ' this event Terminate required Thread and start the auto ignition process for N2O Flame
            ' Switch to N2O to Air 
            gobjMain.N2OAutoIgnition()
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
            Call gobjMain.funcAltDelete()
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
            Call gobjMain.funcAltR()
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

    Private Sub btnExportReport_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : tlbbtnExportReport_Click
        ' Parameters Passed     : Object, EventArgs
        ' Returns               : 
        ' Purpose               : 
        ' Description           : Send the data result to the RTF format
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S & Sachin Dokhale
        ' Created               : 05.10.06
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Dim intSelectId As Integer
        Dim intCount, intCount1 As Integer
        Dim A1() As Double = {0, 0, 0, 0, 0, 0}

        Try
            'Added By Pankaj Fri 18 May 07
            ' this block use to check the if Enabel 21 CFR
            If (gstructSettings.Enable21CFR = True) Then
                If Not funcCheckActivityAuthentication(enumActivityAuthentication.Export, gstructUserDetails.Access) Then
                    Return
                    Exit Sub
                End If
                gfuncInsertActivityLog(EnumModules.Export, "Export Accessed")
            End If

            ' Check whether Data Result is ready to report 
            If (toreported) Then 'OR NOT Method->RepReady )
                If gobjClsAAS203.SaveQuantResults(gobjNewMethod, A1, 1, False) = True Then
                    mblnIsStartRunNumber = True
                End If
                toreported = False
                'mblnIsStartRunNumber = True
            End If
            If StdAnalysed Or AnaOver Or mblnIsAnalysisStarted Then 'Or ManualEntry Then
                'Select required Run No to export data result from data collection object
                For intCount = 0 To gobjMethodCollection.Count - 1
                    'If mintSelectedMethodID = gobjMethodCollection(intCount).MethodID Then
                    If gobjNewMethod.MethodID = gobjMethodCollection(intCount).MethodID Then
                        'intSelectIDIndex = intCount
                        intSelectId = intCount
                        'mobjClsDataFileReport.MethodID = intCount
                        mobjClsDataFileReport.MethodID = gobjMethodCollection(intCount).MethodID
                        For intCount1 = 0 To gobjMethodCollection(intSelectId).QuantitativeDataCollection.Count - 1
                            If mlngSelectedRunNumber = CInt(gobjMethodCollection(intSelectId).QuantitativeDataCollection(intCount1).RunNumber) Then
                                ' Set requierd Run No and perticulat Run No object to the Report object
                                mobjClsDataFileReport.RunNumber = mlngSelectedRunNumber
                                Call mobjClsDataFileReport.funcDatafileExport(gobjMethodCollection(intSelectId).QuantitativeDataCollection(intCount1).ReportParameters)
                                Exit For
                            End If
                        Next
                        Exit For
                    End If
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
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            '---------------------------------------------------------
        End Try
    End Sub


#End Region

#Region " Public Functions "

    Public Sub StartNewAnalysis()
        '=====================================================================
        ' Procedure Name        : StartNewAnalysis
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : To Start new analysis
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 20-Feb-2007 03:00 pm
        ' Revisions             : 1
        '=====================================================================
        Dim intValid As Integer

        Try
            mController = New clsBgThread(Me)
            Call mobjBgReadData.Initialize(mController)
            '--- Set Aspiration Message
            mstrAspirationMessage = "Click Start button to Start Analysis."
            mobjBgMsgAspirate.AspirationMessage = mstrAspirationMessage

            'gobjclsStandardGraph = New clsStandardGraph
            '//----- Added by Sachin Dokhale 
            '//--- Previous Standard
            If blnIsLoadPreviousStandards = False Then
                gobjclsStandardGraph = New clsStandardGraph
            Else
                If gobjclsStandardGraph Is Nothing Then
                    gobjclsStandardGraph = New clsStandardGraph
                End If
            End If
            '//-----
            '--- Return Method Status in integer
            intValid = CheckMethod()
            If (intValid = 2) Then
                'Init. analysis parameters
                Call InitAnalysis()
            End If
            mblnIsAnalysisStarted = False
            '--- Set parameter for NEw analysis
            Call NewAnalysis_Clicked(btnNewAnalysis, EventArgs.Empty)

            btnEditData.Enabled = False

            mintAspirationTimerCounter = 0

            '//----- Commented by Sachin Dokhale
            '//----- use Thread except timer for aspirate message
            mobjBgMsgAspirate.Start()
            IsDisplayingMessage = mobjBgMsgAspirate.IsMessageRunning

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

    Public Sub CheckAnaButtons()
        '=====================================================================
        ' Procedure Name        : CheckAnaButtons
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : To set buttons enable/disable, and show the 
        '                           messages accordingly.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 15-Dec-2006
        ' Revisions             : 1
        '=====================================================================


        'AAS 16-Bit Software Code

        ''void	CheckAnaButtons(HWND hwnd)
        ''{
        '' if (Started){
        ''	ANALYSIS = TRUE;
        ''	SetShortHelp("", FALSE);
        ''	SetShortHelp(" Click End Analysis button to Stop the Analysis", TRUE);
        ''//	EnableWindow(GetDlgItem(hwnd, IDC_QAREPORT),FALSE);
        ''	}
        '' else{
        ''	SetShortHelp(" Click START button to start Analysis", TRUE);
        ''//	EnableWindow(GetDlgItem(hwnd, IDC_QAREPORT),TRUE);
        ''	ANALYSIS = FALSE;
        ''	}
        ''  //---mdf by sk on 29/2/2000 for autosampler
        ''  If (Autosampler & Started) Then
        ''	 EnableWindow(GetDlgItem(hwnd, IDC_QAREAD), FALSE);
        ''  else   //--mdf by sk on 29/2/2000 for autosampler
        ''// EnableWindow(GetDlgItem(hwnd, IDC_QAREAD), Started);
        '' EnableWindow(GetDlgItem(hwnd, IDC_QAREAD), Started);
        '' EnableWindow(GetDlgItem(hwnd, IDC_QANEXT),Started);
        '' EnableWindow(GetDlgItem(hwnd, IDC_BLANK),Started);
        '' EnableWindow(GetDlgItem(hwnd, IDC_QARPT),Started);
        '' EnableWindow(GetDlgItem(hwnd, IDC_QANEW),Started);
        '' EnableWindow(GetDlgItem(hwnd, IDC_QASAMP),Started);
        ''}
        '****************************************************************************************
        Try
            'To set buttons enable/disable, and show the 
            'messages accordingly.
            If (mblnIsAnalysisStarted) Then
                ANALYSIS = True
                '---Show Blinking Message
                Call Aspirate()
            Else
                ANALYSIS = False
            End If

            If (mblnIsAutosampler And mblnIsAnalysisStarted) Then
                btnReadData.Enabled = False
            Else
                btnReadData.Enabled = mblnIsAnalysisStarted
            End If

            'tlbbtnNextAnalysis.Enabled = mblnIsAnalysisStarted
            'tlbbtnBlankAnalysis.Enabled = mblnIsAnalysisStarted
            'tlbbtnRepeatLastAnalysis.Enabled = mblnIsAnalysisStarted
            'tlbbtnNewAnalysis.Enabled = mblnIsAnalysisStarted

            btnNextAnalysis.Enabled = mblnIsAnalysisStarted
            btnBlankAnalysis.Enabled = mblnIsAnalysisStarted
            btnRepeatLast.Enabled = mblnIsAnalysisStarted
            btnNewAnalysis.Enabled = mblnIsAnalysisStarted

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

    Public Sub CheckInstrumentOptimisation()
        '=====================================================================
        ' Procedure Name        : CheckInstrumentOptimisation
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : To check and perform Instrument Optimization
        ' Description           : Finds analytical OR Emmision Peak
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 01.12.06
        ' Revisions             : 
        '=====================================================================

        '--- ORIGINAL CODE 

        ''void	CheckInstrumentOptimisation(HWND hwnd)
        ''{
        ''char line1[20]="";
        ''if (Method){
        ''  if (Method->Mode==MODE_UVABS &&  Method->Aas.Wv !=Get_Cur_Wv())
        ''	    Method->Aas.OptimseFlag=FALSE;
        ''  if (!Method->Aas.OptimseFlag){
        ''	    if ((Method->Mode==MODE_AA || Method->Mode==MODE_AABGC ||
        ''			 Method->Mode==MODE_SPECT)
        ''		    &&  (Method->Aas.LampNo>=0 && Method->Aas.LampNo<=5) )
        ''	    {
        ''	        ResetAnaMode(Method->Aas.LampNo);
        ''		    Method->Aas.OptimseFlag=Find_Analytical_Peak(hwnd, Method->Aas.LampNo);
        ''	    }
        ''	    else if (Method->Mode==MODE_EMISSION)
        ''	        Method->Aas.OptimseFlag=Find_Emmission_Peak(hwnd);
        ''	    else if (Method->Mode==MODE_UVABS)
        ''	        SetRest_uvs_Condn(hwnd, Method->Aas.Wv, TRUE, 87, 284);
        ''  }
        ''}
        ''sprintf(line1,"%0.2f nm",Get_Cur_Wv());
        ''SetWindowText(GetDlgItem(hwnd,IDC_UVWV),line1);
        ''}
        '***************************************************************
        Dim dblSelectedWavelength As Double
        Dim intRowCounter As Integer
        Dim intInstrumentIndex As Integer

        Try

            '//----- Commented by Sachin Dokhale
            '//----- use Thread except timer for aspirate message
            'tmrAspirationMsg.Enabled = False
            If Not IsNothing(mobjBgMsgAspirate) Then
                mobjBgMsgAspirate.Cancel()
                IsDisplayingMessage = mobjBgMsgAspirate.IsMessageRunning
            End If

            gobjMain.mobjController.Cancel()
            gobjCommProtocol.mobjCommdll.subTime_Delay(500)   '10.12.07
            Application.DoEvents()

            'dblSelectedWavelength = gfuncGetSelectedUVElementWavelength(gobjNewMethod.InstrumentCondition)
            If Not IsNothing(gobjNewMethod) Then

                '---Gets Current Wavelength from Instrument.
                If (gobjNewMethod.OperationMode = EnumOperationMode.MODE_AA Or _
                              gobjNewMethod.OperationMode = EnumOperationMode.MODE_AABGC Or _
                              gobjNewMethod.OperationMode = EnumOperationMode.MODE_SPECT Or _
                              gobjNewMethod.OperationMode = EnumOperationMode.MODE_EMMISSION) Then
                    Call gobjCommProtocol.funcGet_Current_Wv(gobjInst.WavelengthCur)
                End If

                '---Assign the Lamp Number as Turret Number as Both are same
                gobjNewMethod.InstrumentCondition.LampNumber = gobjNewMethod.InstrumentCondition.TurretNumber

                If Not IsNothing(gobjNewMethod.InstrumentCondition) Then
                    If (gobjNewMethod.OperationMode = EnumOperationMode.MODE_UVABS) Then
                        dblSelectedWavelength = gfuncGetSelectedUVElementWavelength(gobjNewMethod.InstrumentCondition)
                    Else
                        dblSelectedWavelength = gfuncGetSelectedElementWavelength(gobjNewMethod.InstrumentCondition)
                    End If

                    If (gobjNewMethod.OperationMode = EnumOperationMode.MODE_EMMISSION) Then
                        dblSelectedWavelength = gobjNewMethod.InstrumentCondition.EmmWavelength
                    End If

                    If (gobjNewMethod.OperationMode = EnumOperationMode.MODE_UVABS And _
                            dblSelectedWavelength <> gobjInst.WavelengthCur) Then
                        gobjNewMethod.InstrumentCondition.IsOptimize = False
                    End If

                    If Not (gobjNewMethod.InstrumentCondition.IsOptimize) Then
                        If ((gobjNewMethod.OperationMode = EnumOperationMode.MODE_AA Or
                              gobjNewMethod.OperationMode = EnumOperationMode.MODE_AABGC Or
                              gobjNewMethod.OperationMode = EnumOperationMode.MODE_SPECT) _
                              And
                              (gobjNewMethod.InstrumentCondition.LampNumber >= 1 And
                               gobjNewMethod.InstrumentCondition.LampNumber <= 10)) Then

                            Call ResetAnaMode(gobjNewMethod.InstrumentCondition.LampNumber)

                            '----Finds the Analytical Peak ...
                            gobjNewMethod.InstrumentCondition.IsOptimize = gobjClsAAS203.Find_Analytical_Peak(gobjNewMethod.InstrumentCondition.LampNumber, mdblWvOpt, lblOptimizedWavelength)

                        ElseIf (gobjNewMethod.OperationMode = EnumOperationMode.MODE_EMMISSION) Then

                            '----Finds the Emission Peak ...
                            gobjNewMethod.InstrumentCondition.IsOptimize = gobjClsAAS203.Find_Emmission_Peak()

                        ElseIf (gobjNewMethod.OperationMode = EnumOperationMode.MODE_UVABS) Then
                            Dim blnUVFlag As Boolean
                            'blnUVFlag = True
                            'if gobjMain.

                            Call gobjClsAAS203.funcSetRest_uvs_Condn(dblSelectedWavelength, True, lblUVWavelength, blnUVFlag)
                        End If
                    End If
                End If
            End If

            ''sprintf(line1,"%0.2f nm",Get_Cur_Wv());
            ''SetWindowText(GetDlgItem(hwnd,IDC_UVWV),line1);
            gobjCommProtocol.funcGet_Current_Wv(gobjInst.WavelengthCur)
            lblOptimizedWavelength.Text = "Optimized Wavelength : " & FormatNumber(gobjInst.WavelengthCur.ToString, 2) & " nm"  '---02.02.09

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
            '//----- Commented by Sachin Dokhale
            '//----- use Thread except timer for aspirate message
            'tmrAspirationMsg.Enabled = True
            If Not IsNothing(mobjBgMsgAspirate) Then
                mobjBgMsgAspirate.Start()
                IsDisplayingMessage = mobjBgMsgAspirate.IsMessageRunning
            End If
            If gobjMain.mobjController.IsThreadRunning = False Then
                gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay)
                Application.DoEvents()
                gobjMain.mobjController.Start(gobjclsBgFlameStatus)
            End If
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Sub

#End Region

#Region " Aspiration Related Functions "

    Private Sub StartAspirationThread(ByVal intStartTime As Integer, ByVal intEndTime As Integer)
        '=====================================================================
        ' Procedure Name        : StartAspirationThread
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : Start Aspiration thread
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 17-Jan-2007 03:25 pm
        ' Revisions             : 1
        '=====================================================================
        Dim dtMinTime As Date
        Dim dtMaxTime As Date
        Dim intOLDStartTime As Integer
        Dim intOLDEndTime As Integer
        ' Start the Analysis Thread
        Try
            'check the Analysis Thread for not UV Mode 
            '//---- Modified by Sachin Dokhale on 30.07.07
            If Not (gobjNewMethod.OperationMode = EnumOperationMode.MODE_UVABS) Then
                mobjBgReadData = New clsBgReadData(intStartTime, intEndTime, SampleType, mobjCurrentStandard, mobjCurrentSample)
            End If
            '//-----
            ' use Filter setting to Thread
            mobjBgReadData.Filter_flag = Filter_flag
            'add eventsetting handler
            AddHandler mobjBgReadData.AbsorbanceValueChanged, AddressOf mobjBgReadData_AbsorbanceValueChanged
            AddHandler mobjBgReadData.AspirationMessageChanged, AddressOf mobjBgReadData_AspirationMessageChanged
            ' Check for UV ABS Mode

            If Not (gobjNewMethod.OperationMode = EnumOperationMode.MODE_UVABS) Then
                If Afirst Then
                    ''AASGraphAnalysis.AldysPane.XAxis.StepAuto = True
                    ''AASGraphAnalysis.AldysPane.XAxis.MinorStepAuto = True
                    ''AASGraphAnalysis.AldysPane.XAxis.PickScale(AASGraphAnalysis.XAxisMin, AASGraphAnalysis.XAxisMax)
                    ''AASGraphAnalysis.AldysPane.YAxis.StepAuto = True
                    ''AASGraphAnalysis.AldysPane.YAxis.MinorStepAuto = True
                    ''AASGraphAnalysis.AldysPane.YAxis.PickScale(AASGraphAnalysis.YAxisMin, AASGraphAnalysis.YAxisMax)
                End If
            End If
            '//---- Modified by Sachin Dokhale on 30.07.07
            If Not (mobjBgReadData Is Nothing) Then
                ' Init. Read Data thread
                Call mobjBgReadData.Initialize(mController)
                mobjBgReadData.SampleType = SampleType
                'mobjBgReadData.SampleType = Me.SampleType
                ' Start to read data from instrument through thread 
                gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay)   '10.12.07
                Application.DoEvents()
                Call mController.Start(mobjBgReadData)
            End If
            '//-----
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

    Private Sub mobjBgReadData_AbsorbanceValueChanged(ByVal dblAbs As Double)
        '=====================================================================
        ' Procedure Name        : mobjBgReadData_AbsorbanceValueChanged
        ' Parameters Passed     : dblAbs as absorbance.
        ' Returns               : None
        ' Purpose               : thread events throw the abs
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 17-Jan-2007 03:25 pm
        ' Revisions             : 1
        '=====================================================================
        Try
            'lblAbsorbance.Text = Format(dblAbs, "0.000")   'Commented by Saurabh 01.08.07
            '--- Show the Absorbance label
            If gobjNewMethod.OperationMode = EnumOperationMode.MODE_EMMISSION Then
                lblAbsorbance.Text = FormatNumber(dblAbs, 1)
            Else
                lblAbsorbance.Text = FormatNumber(dblAbs, 3)
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

    Private Sub mobjBgReadData_AspirationMessageChanged(ByVal strNewMessage As String, ByVal blnIsBlink As Boolean)
        '=====================================================================
        ' Procedure Name        : mobjBgReadData_AspirationMessageChanged
        ' Parameters Passed     : strNewMessage As String, blnIsBlink as bool
        ' Returns               : None
        ' Purpose               : thread events throw Aspiration Message 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 17-Jan-2007 03:25 pm
        ' Revisions             : 1
        '=====================================================================
        Try
            mstrAspirationMessage = strNewMessage
            mblnIsBlinkMessage = blnIsBlink
            mobjBgMsgAspirate.AspirationMessage = mstrAspirationMessage
            mobjBgMsgAspirate.IsBlinkMessage = blnIsBlink

            If btnReadData.Enabled = True Then
                btnReadData.Focus()
            End If


            If mstrAspirationMessage = "Reading Wait ..." Then
                Call gobjCommProtocol.mobjCommdll.subTime_Delay(2000)
            End If
            If btnReadData.Enabled = True Then
                btnReadData.Focus()
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

    Private Sub AddInAnalysisRawData(ByVal xValue As Double, ByVal yValue As Double)
        '=====================================================================
        ' Procedure Name        : AddInAnalysisRawData
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : Add the Row Data Result into the Analysis Raw Data collection object
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 25-Jan-2007 12:45 pm
        ' Revisions             : 1
        '=====================================================================
        Dim strSampleName As String
        Dim curveColor As Color
        Static Dim intStCurRepeat As Integer
        Try
            '---Add Each Raw Data in the Analysis Raw Data Collection
            ' Check for each Data result if type Blank/Std/Samp
            Select Case Me.SampleType  'mobjBgReadData.SampleType
                Case clsRawData.enumSampleType.BLANK
                    '---For Blank
                    If mobjBlankRawData Is Nothing Then
                        mobjBlankRawData = New Analysis.clsRawData
                    End If
                    mobjBlankRawData.SampleID = 0
                    mobjBlankRawData.SampleType = clsRawData.enumSampleType.BLANK
                    mobjBlankRawData.SampleName = "BLANK"
                    strSampleName = "BLANK"
                    curveColor = ClsAAS203.BLANKCOLOR
                    mobjBlankRawData.AddReadings(xValue, yValue)
                    'mobjAnalysisRawData.Add(mobjBlankRawData)

                Case clsRawData.enumSampleType.STANDARD
                    If Not IsNothing(mobjCurrentStandard) Then
                        '--- For Standard
                        If IsNothing(mobjStandardRawData) Then
                            mobjStandardRawData = New Analysis.clsRawData
                        End If

                        If CurRepeat > 1 Then
                            If Not (intStCurRepeat = CurRepeat) Then
                                mobjStandardRawData = New Analysis.clsRawData
                                intStCurRepeat = CurRepeat
                            End If
                        Else
                            intStCurRepeat = 0
                        End If

                        If (mobjStandardRawData.SampleID = mobjCurrentStandard.StdNumber) Then
                            mobjStandardRawData.SampleID = mobjCurrentStandard.StdNumber
                            mobjStandardRawData.SampleName = mobjCurrentStandard.StdName
                            mobjStandardRawData.SampleType = clsRawData.enumSampleType.STANDARD
                            strSampleName = mobjCurrentStandard.StdName
                            curveColor = ClsAAS203.STDCOLOR
                            mobjStandardRawData.AddReadings(xValue, yValue)
                        Else
                            mobjStandardRawData = New Analysis.clsRawData
                            mobjStandardRawData.SampleID = mobjCurrentStandard.StdNumber
                            mobjStandardRawData.SampleName = mobjCurrentStandard.StdName
                            mobjStandardRawData.SampleType = clsRawData.enumSampleType.STANDARD
                            strSampleName = mobjCurrentStandard.StdName
                            curveColor = ClsAAS203.STDCOLOR
                            mobjStandardRawData.AddReadings(xValue, yValue)
                            'mobjAnalysisRawData.Add(mobjStandardRawData)
                        End If

                    End If

                Case clsRawData.enumSampleType.SAMPLE
                    If Not IsNothing(mobjCurrentSample) Then
                        '---For Sample
                        If IsNothing(mobjSampleRawData) Then
                            mobjSampleRawData = New Analysis.clsRawData
                        End If

                        If CurRepeat > 1 Then
                            If Not (intStCurRepeat = CurRepeat) Then
                                mobjSampleRawData = New Analysis.clsRawData
                                intStCurRepeat = CurRepeat
                            End If
                        Else
                            intStCurRepeat = 0
                        End If

                        If mobjSampleRawData.SampleID = mobjCurrentSample.SampNumber Then
                            mobjSampleRawData.SampleID = mobjCurrentSample.SampNumber
                            mobjSampleRawData.SampleName = mobjCurrentSample.SampleName
                            mobjSampleRawData.SampleType = clsRawData.enumSampleType.SAMPLE
                            strSampleName = mobjCurrentSample.SampleName
                            curveColor = ClsAAS203.SAMPCOLOR
                            mobjSampleRawData.AddReadings(xValue, yValue)
                        Else
                            mobjSampleRawData = New Analysis.clsRawData
                            mobjSampleRawData.SampleID = mobjCurrentSample.SampNumber
                            mobjSampleRawData.SampleName = mobjCurrentSample.SampleName
                            mobjSampleRawData.SampleType = clsRawData.enumSampleType.SAMPLE
                            strSampleName = mobjCurrentSample.SampleName
                            curveColor = ClsAAS203.SAMPCOLOR
                            mobjSampleRawData.AddReadings(xValue, yValue)
                            'mobjAnalysisRawData.Add(mobjSampleRawData)
                        End If
                    End If
            End Select

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

    Public Sub Start(ByVal clsBgThread As BgThread.clsBgThread) Implements BgThread.Iclient.Start
        '=====================================================================
        ' Procedure Name        : Start
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 17-Jan-2007 03:25 pm
        ' Revisions             : 1
        '=====================================================================
        Try

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

    Public Sub Completed(ByVal Cancelled As Boolean) Implements BgThread.Iclient.Completed
        '=====================================================================
        ' Procedure Name        : Completed
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 17-Jan-2007 03:25 pm
        ' Revisions             : 1
        '=====================================================================
        Dim dblAbsorbance As Double
        Dim A1() As Double = {0, 0, 0, 0, 0, 0}

        Try
            '//----- Added by Sachin Dokhale 
            '//----- to Save Raw Data collection
            mblnAvoidProcessing = True
            Select Case Me.SampleType
                Case ClsAAS203.enumSampleType.BLANK
                    If Not (mobjBlankRawData Is Nothing) Then
                        mobjAnalysisRawData.Add(mobjBlankRawData)
                        mobjBlankRawData = Nothing
                    End If
                Case ClsAAS203.enumSampleType.SAMPLE
                    If Not (mobjSampleRawData Is Nothing) Then
                        mobjAnalysisRawData.Add(mobjSampleRawData)
                        mobjSampleRawData = Nothing
                    End If
                Case ClsAAS203.enumSampleType.STANDARD
                    If Not (mobjStandardRawData Is Nothing) Then
                        mobjAnalysisRawData.Add(mobjStandardRawData)
                        mobjStandardRawData = Nothing
                    End If
            End Select
            '//-----
            'Save Row data into file system
            Call SaveRawDataFile()

            If (gobjNewMethod.OperationMode = EnumOperationMode.MODE_UVABS) Then
                If Not Cancelled Then
                    '--- Store, calculate and Display Quantitative
                    Call StoreCalculateDisplayQuantValueUvMode(mobjBgReadData.UVAbsorbance)
                End If
            Else
                '--- Store, calculate and Display Quantitative
                dblAbsorbance = StoreCalculateDisplayQuantValue()
            End If
            '--- Check and validate analysis data
            If (SampleType = ClsAAS203.enumSampleType.STANDARD) Then
                If Not clsStandardGraph.CheckValidStdAbsEntry(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection) Then
                    'If Not clsStandardGraph.CheckValidStdAbsEntry(mobjCurrentStandard) Then
                    'gobjMessageAdapter.ShowMessage("Absorbance of the standard is less than or equal to the previous standard." & vbCrLf & _
                    '"Press 'Repeat Last' button for aspirating the same standard again.", _
                    '"Standard Aspiration Error", MessageHandler.clsMessageHandler.enumMessageType.ErrorMessage)
                    mblnGetStandards = False
                    gobjMessageAdapter.ShowMessage(constStandardAbsorbance)
                    Application.DoEvents()
                Else
                    mblnGetStandards = True
                End If
            End If

            If (SampleType = ClsAAS203.enumSampleType.SAMPLE) Then
                'If Not clsStandardGraph.CheckValidSampAbsEntry(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection, mdblAbsorbance) Then
                If Not clsStandardGraph.CheckValidSampAbsEntry(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection, dblAbsorbance) Then '04.02.09

                    'If Not clsStandardGraph.CheckValidSampAbsEntry(mobjCurrentSample, mdblAbsorbance) Then

                    'gobjMessageAdapter.ShowMessage("Absorbance of the sample is more than the maximum standard value." & vbCrLf & _
                    '"Calculated Concentration may not be correct." & vbCrLf & _
                    '"Please dilute the sample and repeat again." & vbCrLf & _
                    ' "Press RepeatLast button when ready.", "Sample Aspiration Error", _
                    '  MessageHandler.clsMessageHandler.enumMessageType.ErrorMessage)

                    gobjMessageAdapter.ShowMessage(constSampleAbsorbance)
                    Application.DoEvents()
                End If
            End If

            'btnReadData.Enabled = True
            ' Remove Read Data haldlser 
            RemoveHandler mobjBgReadData.AbsorbanceValueChanged, AddressOf mobjBgReadData_AbsorbanceValueChanged
            RemoveHandler mobjBgReadData.AspirationMessageChanged, AddressOf mobjBgReadData_AspirationMessageChanged

            'SendMessage(hwnd, WM_COMMAND, 900, 0L) '//IDC_QANEXT, 0L);
            '--- Prepare Next analysis 
            Call NextAnalysis_Clicked(btnNextAnalysis, EventArgs.Empty)

            If AnaOver Then
                btnRepeatLast.Enabled = False
            End If
            ' Add handler for Read Data
            'AddHandler btnReadData.Click, AddressOf ReadData_Click

            'mblnAvoidProcessing = False
            Application.DoEvents()
            '--- Start Flame Status window
            If gobjMain.mobjController.IsThreadRunning = False Then
                gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay)
                Application.DoEvents()
                Call gobjMain.mobjController.Start(gobjclsBgFlameStatus)
            End If
            mblnAvoidProcessing = False
            Application.DoEvents()
            ' Continue the Read Data process for next analysis 
            If (mblnIsAutosampler And mblnIsAnalysisStarted) Then 'by Pankaj for autosampler on 03 Oct 07
                'SendMessage(hwnd, WM_COMMAND, IDC_QAREAD, 0L)
                mblnAvoidProcessing = False
                Call ReadData_Click(btnReadData, EventArgs.Empty)
            Else
                ' Add handler for Read Data
                AddHandler btnReadData.Click, AddressOf ReadData_Click
                Application.DoEvents()
            End If
            'Call Aspirate()
            gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay)   '10.12.07
            '' Add handler for Read Data
            'AddHandler btnReadData.Click, AddressOf ReadData_Click
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
            '---------------------------------------------------------
        End Try
    End Sub

    'Public Sub Display(ByVal Text As String) Implements BgThread.Iclient.Display
    '    '=====================================================================
    '    ' Procedure Name        : Display
    '    ' Parameters Passed     : Text
    '    ' Returns               : None
    '    ' Purpose               : 
    '    ' Description           : 
    '    ' Assumptions           : 
    '    ' Dependencies          : 
    '    ' Author                : Mangesh Shardul
    '    ' Created               : 17-Jan-2007 03:25 pm
    '    ' Revisions             : 1
    '    '=====================================================================
    '    Dim strData As String
    '    Dim arrData() As String
    '    Dim xValue, yValue As Double
    '    Dim strSampleName As String
    '    Dim curveColor As Color
    '    Try
    '        If gobjNewMethod.OperationMode = EnumOperationMode.MODE_UVABS Then
    '            lblUVAbsorbance.Text = "Absorbance : " & FormatNumber(Text, 2)
    '            Call AddInAnalysisRawData(xValue, yValue)
    '            Exit Sub
    '        Else
    '            arrData = Text.Split(",")
    '            xValue = Val(arrData(0))
    '            yValue = Val(arrData(1))
    '        End If

    '        '---Display Real Point of Reading
    '        'If intIsReal = 1 Then
    '        '---Display Abs Value on screen
    '        lblAbsorbance.Text = Format(yValue, "0.000")
    '        '---Add only Real Point in the Analysis Raw Data Structure
    '        Call AddInAnalysisRawData(xValue, yValue)
    '        'End If

    '        '---Draw Line
    '        '---Add single Curve Item for all lines
    '        strSampleName = "Aspiration Curve"
    '        Select Case Me.SampleType
    '            Case ClsAAS203.enumSampleType.BLANK
    '                curveColor = ClsAAS203.BLANKCOLOR
    '            Case ClsAAS203.enumSampleType.STANDARD
    '                curveColor = ClsAAS203.STDCOLOR
    '            Case ClsAAS203.enumSampleType.SAMPLE
    '                curveColor = ClsAAS203.SAMPCOLOR
    '        End Select

    '        If (Afirst) Then
    '            Afirst = False
    '            mobjGraphCurve = AASGraphAnalysis.StartOnlineGraph(strSampleName, Color.Black, AldysGraph.SymbolType.NoSymbol, True)
    '            AASGraphAnalysis.PlotPoint(mobjGraphCurve, xValue, yValue, True)
    '        Else
    '            mobjGraphCurve.CL.Add(curveColor)
    '            AASGraphAnalysis.PlotPoint(mobjGraphCurve, xValue, yValue, True)
    '        End If

    '        'Application.DoEvents()
    '        'AASGraphAnalysis.AldysPane.XAxis.PickScale(AASGraphAnalysis.XAxisMin, AASGraphAnalysis.XAxisMax)
    '        'AASGraphAnalysis.AldysPane.XAxis.StepAuto = True
    '        'AASGraphAnalysis.AldysPane.XAxis.MinorStepAuto = True
    '        'AASGraphAnalysis.AldysPane.YAxis.PickScale(AASGraphAnalysis.YAxisMin, AASGraphAnalysis.YAxisMax)
    '        'AASGraphAnalysis.AldysPane.YAxis.StepAuto = True
    '        'AASGraphAnalysis.AldysPane.YAxis.MinorStepAuto = True

    '        AASGraphAnalysis.Refresh()
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
    '        '---------------------------------------------------------
    '    End Try
    'End Sub

    Public Sub Display(ByVal Text As String) Implements BgThread.Iclient.Display
        '=====================================================================
        ' Procedure Name        : Display
        ' Parameters Passed     : Text
        ' Returns               : None
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak
        ' Created               : 29.04.07
        ' Revisions             : 
        '=====================================================================
        Dim strData As String
        Dim arrData() As String
        Dim xValue, yValue As Double
        Dim strSampleName As String
        Dim curveColor As Color
        Dim dblAvgAbs As Double = 0
        Dim IsAvgAbs As Boolean = False
        Try

            intDispCount += 1
            ' Use Implementd String object 
            ' Use X and Y Value
            If gobjNewMethod.OperationMode = EnumOperationMode.MODE_UVABS Then
                lblUVAbsorbance.Text = "Absorbance : " & FormatNumber(Text, 3)
                Call AddInAnalysisRawData(xValue, yValue)
                Exit Sub
            Else
                arrData = Text.Split(",")
                xValue = Val(arrData(0))
                yValue = Val(arrData(1))

                '---16.03.08
                If gblnIsDemoWithRealData = True Then
                    If gstructSettings.AppMode = EnumAppMode.DemoMode Or gstructSettings.AppMode = EnumAppMode.DemoMode_201 Or gstructSettings.AppMode = EnumAppMode.DemoMode_203D Then
                        Dim sr As StreamReader
                        Select Case mintSelectedDemoFile
                            Case 1
                                sr = New StreamReader("cu.txt")
                            Case 2
                                sr = New StreamReader("pb.txt")
                            Case 3
                                sr = New StreamReader("zn.txt")
                            Case Else
                                sr = New StreamReader("cu.txt")
                        End Select

                        'Dim sr As StreamReader = New StreamReader("cu.txt")
                        Dim line, line1, line2 As String
                        Dim arr() As String
                        line = sr.ReadToEnd
                        arr = line.Split(";")
                        If arr.Length = 2 Then
                            line1 = arr(0)
                            line2 = arr(1)
                        End If

                        If Me.SampleType = ClsAAS203.enumSampleType.STANDARD Then
                            Dim std() As String
                            Dim i, CurrStdNo As Integer

                            For i = 0 To gobjNewMethod.QuantitativeDataCollection.Item(gobjNewMethod.QuantitativeDataCollection.Count - 1).StandardDataCollection.Count - 1
                                If gobjNewMethod.QuantitativeDataCollection.Item(gobjNewMethod.QuantitativeDataCollection.Count - 1).StandardDataCollection.item(i).Abs = -1.0 Then
                                    CurrStdNo = i + 1
                                    Exit For
                                End If
                            Next

                            std = line1.Split(",")
                            yValue = CDbl(std(CurrStdNo - 1))
                        End If

                        If Me.SampleType = ClsAAS203.enumSampleType.SAMPLE Then
                            Dim spl() As String
                            Dim j, CurrSplNo As Integer

                            For j = 0 To gobjNewMethod.QuantitativeDataCollection.Item(gobjNewMethod.QuantitativeDataCollection.Count - 1).SampleDataCollection.Count - 1
                                If gobjNewMethod.QuantitativeDataCollection.Item(gobjNewMethod.QuantitativeDataCollection.Count - 1).SampleDataCollection.item(j).Abs = -1.0 Then
                                    CurrSplNo = j + 1
                                    Exit For
                                End If
                            Next

                            spl = line2.Split(",")
                            yValue = CDbl(spl(CurrSplNo - 1))
                        End If
                        sr.Close()
                    End If
                End If
                '---16.03.08


                IsAvgAbs = False
                If arrData.Length > 2 Then
                    IsAvgAbs = True
                    dblAvgAbs = Val(arrData(2))
                    If gblnIsDemoWithRealData = True Then  '---16.03.08
                        If gstructSettings.AppMode = EnumAppMode.DemoMode Or gstructSettings.AppMode = EnumAppMode.DemoMode_201 Or gstructSettings.AppMode = EnumAppMode.DemoMode_203D Then
                            dblAvgAbs = yValue
                        End If
                    End If  '---16.03.08
                End If
            End If

            '---Display Real Point of Reading
            '---Display Abs Value on screen
            If gobjNewMethod.OperationMode = EnumOperationMode.MODE_EMMISSION Then
                lblAbsorbance.Text = FormatNumber(yValue, 1)
            Else
                lblAbsorbance.Text = FormatNumber(yValue, 3)
            End If

            '---Add only Real Point in the Analysis Raw Data Structure
            'Call AddInAnalysisRawData(xValue, yValue)
            Call AddInAnalysisRawData(xValue, dblAvgAbs)

            'End If

            '---Draw Line
            '---Add single Curve Item for all lines
            strSampleName = "Aspiration Curve"
            Select Case Me.SampleType
                Case ClsAAS203.enumSampleType.BLANK
                    curveColor = ClsAAS203.BLANKCOLOR
                Case ClsAAS203.enumSampleType.STANDARD
                    curveColor = ClsAAS203.STDCOLOR
                Case ClsAAS203.enumSampleType.SAMPLE
                    curveColor = ClsAAS203.SAMPCOLOR
            End Select
            '--- Set the Graph points
            If xValue > AASGraphAnalysis.XAxisMax Or yValue > AASGraphAnalysis.YAxisMax Then
                Call Calculate_Analysis_Graph_Param(AASGraphAnalysis, xValue, yValue)
            End If

            If IsAvgAbs Then
                If (Afirst) Then
                    Afirst = False
                    mobjGraphCurve = AASGraphAnalysis.StartOnlineGraph(strSampleName, Color.Black, AldysGraph.SymbolType.NoSymbol, True)
                    AASGraphAnalysis.PlotPoint(mobjGraphCurve, xValue, dblAvgAbs, True)
                    'AASGraphAnalysis.PlotPoint(mobjGraphCurve, xValue, yValue, True)
                Else
                    mobjGraphCurve.CL.Add(curveColor)
                    AASGraphAnalysis.PlotPoint(mobjGraphCurve, xValue, dblAvgAbs, True)
                    'AASGraphAnalysis.PlotPoint(mobjGraphCurve, xValue, yValue, True)
                End If
                mxValue = xValue
                mdblAvgAbs = dblAvgAbs
            End If

            AASGraphAnalysis.Refresh()
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
            '---------------------------------------------------------
        End Try
    End Sub

    Public Sub Failed(ByVal e As System.Exception) Implements BgThread.Iclient.Failed
        '=====================================================================
        ' Procedure Name        : Failed
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 17-Jan-2007 03:25 pm
        ' Revisions             : 1
        '=====================================================================
        Try
            ' Set the process when thread is failed
            mblnAvoidProcessing = True
            MsgBox("Data Read Thread is failed", MsgBoxStyle.OKOnly)
            Application.DoEvents()
            AddHandler btnReadData.Click, AddressOf ReadData_Click
            gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay)   '10.12.07
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
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Sub

#End Region


    Private Sub btnStartStopAnalysis_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStartStopAnalysis.Click

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

    End Sub
End Class

