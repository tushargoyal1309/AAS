Imports System.Threading
Imports AAS203.Common
Imports AAS203Library
Imports AAS203Library.Method
Imports AAS203Library.Instrument

Public Class frmMethod
    Inherits System.Windows.Forms.Form

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
    Friend WithEvents CustomPanelMethodMain As GradientPanel.CustomPanel
    Friend WithEvents CustomPanelLeft As GradientPanel.CustomPanel
    Friend WithEvents HeaderRight As CodeIntellects.Office2003Controls.Office2003Header
    Friend WithEvents CustomPanel1 As GradientPanel.CustomPanel
    Friend WithEvents lblMethodComments As System.Windows.Forms.Label
    Friend WithEvents lblMethodInformation As System.Windows.Forms.Label
    Friend WithEvents lblModeOfOperation As System.Windows.Forms.Label
    Friend WithEvents lblMethodName As System.Windows.Forms.Label
    Friend WithEvents HeaderLeft As CodeIntellects.Office2003Controls.Office2003Header
    Friend WithEvents lstMethodInformation As System.Windows.Forms.ListBox
    Friend WithEvents TxtModeOfOperation As System.Windows.Forms.TextBox
    Friend WithEvents TxtMethodName As System.Windows.Forms.TextBox
    Friend WithEvents TxtMethodComments As System.Windows.Forms.TextBox
    'Friend WithEvents mnuNewMethod As NETXP.Controls.Bars.CommandBarButtonItem
    'Friend WithEvents mnuLoadMethod As NETXP.Controls.Bars.CommandBarButtonItem
    'Friend WithEvents mnuInstrumentSettings As NETXP.Controls.Bars.CommandBarButtonItem
    'Friend WithEvents mnuInstrumentParameters As NETXP.Controls.Bars.CommandBarButtonItem
    'Friend WithEvents mnuStandardConcentrations As NETXP.Controls.Bars.CommandBarButtonItem
    'Friend WithEvents mnuSampleParameters As NETXP.Controls.Bars.CommandBarButtonItem
    'Friend WithEvents mnuReportOptions As NETXP.Controls.Bars.CommandBarButtonItem
    'Friend WithEvents mnuHelp As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents XpPanelGroup1 As UIComponents.XPPanelGroup
    Friend WithEvents btnReportOptions As NETXP.Controls.XPButton
    Friend WithEvents btnLoadMethod As NETXP.Controls.XPButton
    Friend WithEvents btnInstrumentSettings As NETXP.Controls.XPButton
    Friend WithEvents btnInstrumentParameters As NETXP.Controls.XPButton
    Friend WithEvents btnStandardConcentrations As NETXP.Controls.XPButton
    Friend WithEvents btnSampleParameters As NETXP.Controls.XPButton
    Friend WithEvents btnNewMethod As NETXP.Controls.XPButton
    'Friend WithEvents CommandBarButtonItem3 As NETXP.Controls.Bars.CommandBarButtonItem
    'Friend WithEvents CommandBarButtonItem4 As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents btnExtinguish As NETXP.Controls.XPButton
    Friend WithEvents btnIgnite As NETXP.Controls.XPButton
    Friend WithEvents btnN2OIgnite As NETXP.Controls.XPButton
    Friend WithEvents l As System.Windows.Forms.Label
    Friend WithEvents btnR As NETXP.Controls.XPButton
    Friend WithEvents btnDelete As NETXP.Controls.XPButton

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMethod))
        Me.CustomPanelMethodMain = New GradientPanel.CustomPanel
        Me.HeaderRight = New CodeIntellects.Office2003Controls.Office2003Header
        Me.CustomPanel1 = New GradientPanel.CustomPanel
        Me.TxtMethodComments = New System.Windows.Forms.TextBox
        Me.TxtMethodName = New System.Windows.Forms.TextBox
        Me.lstMethodInformation = New System.Windows.Forms.ListBox
        Me.lblMethodComments = New System.Windows.Forms.Label
        Me.lblMethodInformation = New System.Windows.Forms.Label
        Me.lblModeOfOperation = New System.Windows.Forms.Label
        Me.TxtModeOfOperation = New System.Windows.Forms.TextBox
        Me.lblMethodName = New System.Windows.Forms.Label
        Me.CustomPanelLeft = New GradientPanel.CustomPanel
        Me.XpPanelGroup1 = New UIComponents.XPPanelGroup
        Me.l = New System.Windows.Forms.Label
        Me.btnSampleParameters = New NETXP.Controls.XPButton
        Me.btnReportOptions = New NETXP.Controls.XPButton
        Me.btnStandardConcentrations = New NETXP.Controls.XPButton
        Me.btnInstrumentParameters = New NETXP.Controls.XPButton
        Me.btnInstrumentSettings = New NETXP.Controls.XPButton
        Me.btnNewMethod = New NETXP.Controls.XPButton
        Me.btnLoadMethod = New NETXP.Controls.XPButton
        Me.btnIgnite = New NETXP.Controls.XPButton
        Me.btnN2OIgnite = New NETXP.Controls.XPButton
        Me.btnExtinguish = New NETXP.Controls.XPButton
        Me.btnDelete = New NETXP.Controls.XPButton
        Me.btnR = New NETXP.Controls.XPButton
        Me.HeaderLeft = New CodeIntellects.Office2003Controls.Office2003Header
        Me.CustomPanelMethodMain.SuspendLayout()
        Me.HeaderRight.SuspendLayout()
        Me.CustomPanel1.SuspendLayout()
        Me.CustomPanelLeft.SuspendLayout()
        CType(Me.XpPanelGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XpPanelGroup1.SuspendLayout()
        Me.SuspendLayout()
        '
        'CustomPanelMethodMain
        '
        Me.CustomPanelMethodMain.BackColor = System.Drawing.Color.AliceBlue
        Me.CustomPanelMethodMain.BackColor2 = System.Drawing.Color.AliceBlue
        Me.CustomPanelMethodMain.Controls.Add(Me.HeaderRight)
        Me.CustomPanelMethodMain.Controls.Add(Me.CustomPanelLeft)
        Me.CustomPanelMethodMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CustomPanelMethodMain.Location = New System.Drawing.Point(0, 0)
        Me.CustomPanelMethodMain.Name = "CustomPanelMethodMain"
        Me.CustomPanelMethodMain.Size = New System.Drawing.Size(772, 569)
        Me.CustomPanelMethodMain.TabIndex = 0
        '
        'HeaderRight
        '
        Me.HeaderRight.BackColor = System.Drawing.Color.Transparent
        Me.HeaderRight.Controls.Add(Me.CustomPanel1)
        Me.HeaderRight.Dock = System.Windows.Forms.DockStyle.Fill
        Me.HeaderRight.Location = New System.Drawing.Point(160, 0)
        Me.HeaderRight.Name = "HeaderRight"
        Me.HeaderRight.Size = New System.Drawing.Size(612, 569)
        Me.HeaderRight.TabIndex = 5
        Me.HeaderRight.TitleFont = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HeaderRight.TitleText = "Method"
        '
        'CustomPanel1
        '
        Me.CustomPanel1.BackColor = System.Drawing.Color.AliceBlue
        Me.CustomPanel1.BackColor2 = System.Drawing.Color.Transparent
        Me.CustomPanel1.Controls.Add(Me.TxtMethodComments)
        Me.CustomPanel1.Controls.Add(Me.TxtMethodName)
        Me.CustomPanel1.Controls.Add(Me.lstMethodInformation)
        Me.CustomPanel1.Controls.Add(Me.lblMethodComments)
        Me.CustomPanel1.Controls.Add(Me.lblMethodInformation)
        Me.CustomPanel1.Controls.Add(Me.lblModeOfOperation)
        Me.CustomPanel1.Controls.Add(Me.TxtModeOfOperation)
        Me.CustomPanel1.Controls.Add(Me.lblMethodName)
        Me.CustomPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CustomPanel1.Location = New System.Drawing.Point(0, 0)
        Me.CustomPanel1.Name = "CustomPanel1"
        Me.CustomPanel1.Size = New System.Drawing.Size(612, 569)
        Me.CustomPanel1.TabIndex = 8
        '
        'TxtMethodComments
        '
        Me.TxtMethodComments.BackColor = System.Drawing.Color.White
        Me.TxtMethodComments.Enabled = False
        Me.TxtMethodComments.Location = New System.Drawing.Point(176, 284)
        Me.TxtMethodComments.Multiline = True
        Me.TxtMethodComments.Name = "TxtMethodComments"
        Me.TxtMethodComments.ReadOnly = True
        Me.TxtMethodComments.Size = New System.Drawing.Size(368, 82)
        Me.TxtMethodComments.TabIndex = 3
        Me.TxtMethodComments.Text = ""
        '
        'TxtMethodName
        '
        Me.TxtMethodName.BackColor = System.Drawing.Color.White
        Me.TxtMethodName.Enabled = False
        Me.TxtMethodName.Location = New System.Drawing.Point(176, 72)
        Me.TxtMethodName.Name = "TxtMethodName"
        Me.TxtMethodName.ReadOnly = True
        Me.TxtMethodName.Size = New System.Drawing.Size(368, 21)
        Me.TxtMethodName.TabIndex = 0
        Me.TxtMethodName.Text = ""
        '
        'lstMethodInformation
        '
        Me.lstMethodInformation.BackColor = System.Drawing.Color.White
        Me.lstMethodInformation.Enabled = False
        Me.lstMethodInformation.ItemHeight = 15
        Me.lstMethodInformation.Location = New System.Drawing.Point(176, 184)
        Me.lstMethodInformation.Name = "lstMethodInformation"
        Me.lstMethodInformation.Size = New System.Drawing.Size(368, 79)
        Me.lstMethodInformation.TabIndex = 2
        '
        'lblMethodComments
        '
        Me.lblMethodComments.Location = New System.Drawing.Point(28, 285)
        Me.lblMethodComments.Name = "lblMethodComments"
        Me.lblMethodComments.Size = New System.Drawing.Size(132, 19)
        Me.lblMethodComments.TabIndex = 23
        Me.lblMethodComments.Text = "Method Comments"
        '
        'lblMethodInformation
        '
        Me.lblMethodInformation.Location = New System.Drawing.Point(28, 187)
        Me.lblMethodInformation.Name = "lblMethodInformation"
        Me.lblMethodInformation.Size = New System.Drawing.Size(132, 21)
        Me.lblMethodInformation.TabIndex = 22
        Me.lblMethodInformation.Text = "Method Information"
        '
        'lblModeOfOperation
        '
        Me.lblModeOfOperation.Location = New System.Drawing.Point(28, 132)
        Me.lblModeOfOperation.Name = "lblModeOfOperation"
        Me.lblModeOfOperation.Size = New System.Drawing.Size(124, 16)
        Me.lblModeOfOperation.TabIndex = 21
        Me.lblModeOfOperation.Text = "Mode of Operation"
        '
        'TxtModeOfOperation
        '
        Me.TxtModeOfOperation.BackColor = System.Drawing.Color.White
        Me.TxtModeOfOperation.Enabled = False
        Me.TxtModeOfOperation.Location = New System.Drawing.Point(176, 128)
        Me.TxtModeOfOperation.Name = "TxtModeOfOperation"
        Me.TxtModeOfOperation.ReadOnly = True
        Me.TxtModeOfOperation.Size = New System.Drawing.Size(368, 21)
        Me.TxtModeOfOperation.TabIndex = 1
        Me.TxtModeOfOperation.Text = ""
        '
        'lblMethodName
        '
        Me.lblMethodName.Location = New System.Drawing.Point(30, 73)
        Me.lblMethodName.Name = "lblMethodName"
        Me.lblMethodName.Size = New System.Drawing.Size(96, 24)
        Me.lblMethodName.TabIndex = 20
        Me.lblMethodName.Text = "Method Name"
        '
        'CustomPanelLeft
        '
        Me.CustomPanelLeft.BackColor = System.Drawing.Color.AliceBlue
        Me.CustomPanelLeft.BackColor2 = System.Drawing.Color.AliceBlue
        Me.CustomPanelLeft.Controls.Add(Me.XpPanelGroup1)
        Me.CustomPanelLeft.Controls.Add(Me.HeaderLeft)
        Me.CustomPanelLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.CustomPanelLeft.Location = New System.Drawing.Point(0, 0)
        Me.CustomPanelLeft.Name = "CustomPanelLeft"
        Me.CustomPanelLeft.Size = New System.Drawing.Size(160, 569)
        Me.CustomPanelLeft.TabIndex = 2
        '
        'XpPanelGroup1
        '
        Me.XpPanelGroup1.AutoScroll = True
        Me.XpPanelGroup1.BackColor = System.Drawing.Color.Transparent
        Me.XpPanelGroup1.Controls.Add(Me.l)
        Me.XpPanelGroup1.Controls.Add(Me.btnSampleParameters)
        Me.XpPanelGroup1.Controls.Add(Me.btnReportOptions)
        Me.XpPanelGroup1.Controls.Add(Me.btnStandardConcentrations)
        Me.XpPanelGroup1.Controls.Add(Me.btnInstrumentParameters)
        Me.XpPanelGroup1.Controls.Add(Me.btnInstrumentSettings)
        Me.XpPanelGroup1.Controls.Add(Me.btnNewMethod)
        Me.XpPanelGroup1.Controls.Add(Me.btnLoadMethod)
        Me.XpPanelGroup1.Controls.Add(Me.btnIgnite)
        Me.XpPanelGroup1.Controls.Add(Me.btnN2OIgnite)
        Me.XpPanelGroup1.Controls.Add(Me.btnExtinguish)
        Me.XpPanelGroup1.Controls.Add(Me.btnDelete)
        Me.XpPanelGroup1.Controls.Add(Me.btnR)
        Me.XpPanelGroup1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XpPanelGroup1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XpPanelGroup1.Location = New System.Drawing.Point(0, 22)
        Me.XpPanelGroup1.Name = "XpPanelGroup1"
        Me.XpPanelGroup1.PanelGradient = CType(resources.GetObject("XpPanelGroup1.PanelGradient"), UIComponents.GradientColor)
        Me.XpPanelGroup1.Size = New System.Drawing.Size(160, 547)
        Me.XpPanelGroup1.TabIndex = 0
        '
        'l
        '
        Me.l.Location = New System.Drawing.Point(26, 418)
        Me.l.Name = "l"
        Me.l.Size = New System.Drawing.Size(128, 26)
        Me.l.TabIndex = 7
        '
        'btnSampleParameters
        '
        Me.btnSampleParameters.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSampleParameters.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSampleParameters.Image = CType(resources.GetObject("btnSampleParameters.Image"), System.Drawing.Image)
        Me.btnSampleParameters.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSampleParameters.Location = New System.Drawing.Point(20, 310)
        Me.btnSampleParameters.Name = "btnSampleParameters"
        Me.btnSampleParameters.Size = New System.Drawing.Size(120, 38)
        Me.btnSampleParameters.TabIndex = 5
        Me.btnSampleParameters.Text = "Sam&ples"
        Me.btnSampleParameters.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnReportOptions
        '
        Me.btnReportOptions.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnReportOptions.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReportOptions.Image = CType(resources.GetObject("btnReportOptions.Image"), System.Drawing.Image)
        Me.btnReportOptions.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReportOptions.Location = New System.Drawing.Point(20, 368)
        Me.btnReportOptions.Name = "btnReportOptions"
        Me.btnReportOptions.Size = New System.Drawing.Size(120, 38)
        Me.btnReportOptions.TabIndex = 6
        Me.btnReportOptions.Text = "Report &Options"
        Me.btnReportOptions.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'btnStandardConcentrations
        '
        Me.btnStandardConcentrations.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnStandardConcentrations.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStandardConcentrations.Image = CType(resources.GetObject("btnStandardConcentrations.Image"), System.Drawing.Image)
        Me.btnStandardConcentrations.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnStandardConcentrations.Location = New System.Drawing.Point(20, 252)
        Me.btnStandardConcentrations.Name = "btnStandardConcentrations"
        Me.btnStandardConcentrations.Size = New System.Drawing.Size(120, 38)
        Me.btnStandardConcentrations.TabIndex = 4
        Me.btnStandardConcentrations.Text = "Standard Concentration"
        Me.btnStandardConcentrations.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'btnInstrumentParameters
        '
        Me.btnInstrumentParameters.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnInstrumentParameters.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnInstrumentParameters.Image = CType(resources.GetObject("btnInstrumentParameters.Image"), System.Drawing.Image)
        Me.btnInstrumentParameters.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnInstrumentParameters.Location = New System.Drawing.Point(20, 194)
        Me.btnInstrumentParameters.Name = "btnInstrumentParameters"
        Me.btnInstrumentParameters.Size = New System.Drawing.Size(120, 38)
        Me.btnInstrumentParameters.TabIndex = 3
        Me.btnInstrumentParameters.Text = "&Parameters"
        '
        'btnInstrumentSettings
        '
        Me.btnInstrumentSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnInstrumentSettings.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnInstrumentSettings.Image = CType(resources.GetObject("btnInstrumentSettings.Image"), System.Drawing.Image)
        Me.btnInstrumentSettings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnInstrumentSettings.Location = New System.Drawing.Point(20, 136)
        Me.btnInstrumentSettings.Name = "btnInstrumentSettings"
        Me.btnInstrumentSettings.Size = New System.Drawing.Size(120, 38)
        Me.btnInstrumentSettings.TabIndex = 2
        Me.btnInstrumentSettings.Text = "Instrument"
        Me.btnInstrumentSettings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnNewMethod
        '
        Me.btnNewMethod.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNewMethod.Image = CType(resources.GetObject("btnNewMethod.Image"), System.Drawing.Image)
        Me.btnNewMethod.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNewMethod.Location = New System.Drawing.Point(20, 20)
        Me.btnNewMethod.Name = "btnNewMethod"
        Me.btnNewMethod.Size = New System.Drawing.Size(120, 38)
        Me.btnNewMethod.TabIndex = 0
        Me.btnNewMethod.Text = "&New Method"
        '
        'btnLoadMethod
        '
        Me.btnLoadMethod.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoadMethod.Image = CType(resources.GetObject("btnLoadMethod.Image"), System.Drawing.Image)
        Me.btnLoadMethod.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLoadMethod.Location = New System.Drawing.Point(20, 78)
        Me.btnLoadMethod.Name = "btnLoadMethod"
        Me.btnLoadMethod.Size = New System.Drawing.Size(120, 38)
        Me.btnLoadMethod.TabIndex = 1
        Me.btnLoadMethod.Text = "&Load Method"
        '
        'btnIgnite
        '
        Me.btnIgnite.BackColor = System.Drawing.Color.RoyalBlue
        Me.btnIgnite.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnIgnite.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIgnite.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnIgnite.Location = New System.Drawing.Point(76, 424)
        Me.btnIgnite.Name = "btnIgnite"
        Me.btnIgnite.Size = New System.Drawing.Size(8, 8)
        Me.btnIgnite.TabIndex = 12
        Me.btnIgnite.TabStop = False
        Me.btnIgnite.Text = "&Ignition"
        Me.btnIgnite.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'btnN2OIgnite
        '
        Me.btnN2OIgnite.BackColor = System.Drawing.Color.RoyalBlue
        Me.btnN2OIgnite.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnN2OIgnite.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnN2OIgnite.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnN2OIgnite.Location = New System.Drawing.Point(92, 424)
        Me.btnN2OIgnite.Name = "btnN2OIgnite"
        Me.btnN2OIgnite.Size = New System.Drawing.Size(8, 8)
        Me.btnN2OIgnite.TabIndex = 19
        Me.btnN2OIgnite.TabStop = False
        Me.btnN2OIgnite.Text = "N2O&C"
        Me.btnN2OIgnite.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'btnExtinguish
        '
        Me.btnExtinguish.BackColor = System.Drawing.Color.RoyalBlue
        Me.btnExtinguish.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExtinguish.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExtinguish.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExtinguish.Location = New System.Drawing.Point(60, 424)
        Me.btnExtinguish.Name = "btnExtinguish"
        Me.btnExtinguish.Size = New System.Drawing.Size(8, 8)
        Me.btnExtinguish.TabIndex = 13
        Me.btnExtinguish.TabStop = False
        Me.btnExtinguish.Text = "&Extinguish"
        Me.btnExtinguish.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'btnDelete
        '
        Me.btnDelete.BackColor = System.Drawing.Color.RoyalBlue
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelete.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDelete.Location = New System.Drawing.Point(102, 424)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(8, 8)
        Me.btnDelete.TabIndex = 22
        Me.btnDelete.TabStop = False
        Me.btnDelete.Text = "&Delete"
        Me.btnDelete.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'btnR
        '
        Me.btnR.BackColor = System.Drawing.Color.RoyalBlue
        Me.btnR.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnR.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnR.Location = New System.Drawing.Point(114, 424)
        Me.btnR.Name = "btnR"
        Me.btnR.Size = New System.Drawing.Size(8, 8)
        Me.btnR.TabIndex = 21
        Me.btnR.TabStop = False
        Me.btnR.Text = "&R"
        Me.btnR.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'HeaderLeft
        '
        Me.HeaderLeft.BackColor = System.Drawing.SystemColors.Control
        Me.HeaderLeft.Dock = System.Windows.Forms.DockStyle.Top
        Me.HeaderLeft.Location = New System.Drawing.Point(0, 0)
        Me.HeaderLeft.Name = "HeaderLeft"
        Me.HeaderLeft.Size = New System.Drawing.Size(160, 22)
        Me.HeaderLeft.TabIndex = 11
        Me.HeaderLeft.TitleFont = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HeaderLeft.TitleText = "Method Parameters"
        '
        'frmMethod
        '
        Me.AutoScale = False
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.CausesValidation = False
        Me.ClientSize = New System.Drawing.Size(772, 569)
        Me.Controls.Add(Me.CustomPanelMethodMain)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmMethod"
        Me.Text = "Method"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.CustomPanelMethodMain.ResumeLayout(False)
        Me.HeaderRight.ResumeLayout(False)
        Me.CustomPanel1.ResumeLayout(False)
        Me.CustomPanelLeft.ResumeLayout(False)
        CType(Me.XpPanelGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XpPanelGroup1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Private Class Member Variables "

    Private WithEvents mobjfrmLoadMethod As New frmLoadMethod
    Private mintMethodMode As Integer = 0

    Public Event LoadedMethodChanged()
    Private mobjPreviousSampParameter As AAS203Library.Method.clsAnalysisSampleParametersCollection
    Private mblnAvoidProcessing As Boolean = False
#End Region

#Region " Private Constants "

    Private Const ConstCreatedBy = "Created By  "
    Private Const ConstCreatedOn = "Created On  "
    Private Const ConstStatus = "Status      "
    Private Const ConstChangedOn = "Changed On  "
    Private Const ConstLastUsedOn = "Last Used On"
    Private Const ConstActive = "Active"
    Private Const ConstNotActive = "Inactive (Method parameters are incomplete)"
    Private Const ConstFormLoad = "-Method"

#End Region

#Region " Private Properties "

    Private Property OpenMethodMode() As EnumMethodMode
        Get
            Return mintMethodMode
        End Get
        Set(ByVal Value As EnumMethodMode)
            mintMethodMode = Value
        End Set
    End Property

#End Region

#Region " Form Events "

    Private Sub frmMethod_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '=====================================================================
        ' Procedure Name        : frmMethod_Load
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To load the form
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh
        ' Created               : 06.10.06
        ' Revisions             : Deepak B. on 11.01.07 added code for default method
        '=====================================================================
        ''note:
        ''this is called when form is loaded
        ''do some initialization here'
        ''for eg add all the event to form.
        Dim objWait As New CWaitCursor
        Dim intCount As Integer
        Try
            'Saurabh
            If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
                ''for 201
                btnIgnite.Enabled = False
                btnExtinguish.Enabled = False
            End If

            btnNewMethod.BringToFront()
            btnLoadMethod.BringToFront()
            btnNewMethod.Focus()
            'Saurabh

            Me.FormBorderStyle = FormBorderStyle.FixedSingle
            AddHandlers()
''for adding a event
            btnInstrumentSettings.Enabled = False
            btnInstrumentParameters.Enabled = False
            btnStandardConcentrations.Enabled = False
            btnSampleParameters.Enabled = False
            btnReportOptions.Enabled = False

            If gIntMethodID <> 0 Then
                For intCount = 0 To gobjMethodCollection.Count - 1
                    If gobjMethodCollection.item(intCount).MethodID = gIntMethodID Then
                        gobjNewMethod = gobjMethodCollection.item(intCount)
                        Exit For
                    End If
                Next
                Call mobjfrmLoadMethod_LoadMethod(gobjNewMethod)
                ''To display general information of load method event of frmLoadMethod form

            End If

            'Saurabh 10.07.07 To bring status form in front
            gobjfrmStatus.Show()
            ''for statusn form.
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
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub frmMethod_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        '=====================================================================
        ' Procedure Name        : frmMethod_Closing
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : this is called for closing a form.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh
        ' Created               : 06.10.06
        ' Revisions             : Deepak B. on 11.01.07 added code for default method
        '=====================================================================
        mobjfrmLoadMethod.Close()
        mobjfrmLoadMethod.Dispose()
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
            AddHandler mobjfrmLoadMethod.LoadMethod, AddressOf mobjfrmLoadMethod_LoadMethod
            ''this will add a event to a control
            AddHandler btnReportOptions.Click, AddressOf tlbbtnReportOptions_Click
            AddHandler btnInstrumentSettings.Click, AddressOf tlbbtnInstrumentParameters_Click
            AddHandler btnInstrumentParameters.Click, AddressOf tlbbtnAnalysisParameters_Click
            AddHandler btnStandardConcentrations.Click, AddressOf tlbbtnStdConcentration_Click
            AddHandler btnSampleParameters.Click, AddressOf tlbbtnSampParameters_Click
            AddHandler btnNewMethod.Click, AddressOf tlbbtnNewMethod_Click
            AddHandler btnLoadMethod.Click, AddressOf tlbbtnLoadMethod_Click

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

    Private Sub tlbbtnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : tlbbtnBack_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To exit frmMethod and load frmMDIMain form
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 25.09.06
        ' Revisions             : 
        '=====================================================================
        ''note;
        ''this is called when user click on back button.
        ''To exit frmMethod and load frmMDIMain form
        Dim objWait As New CWaitCursor
        Try
            gobjMain.ShowProgressBar(gstrTitleInstrumentType & ConstFormLoad)
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
            gobjMain.HideProgressBar()
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub tlbbtnNewMethod_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : tlbbtnNewMethod_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To create new method
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 05.10.06
        ' Revisions             : 
        '=====================================================================
        'note:
        ''this is called when user clicked on new method button.
        ''this will start a routine for new method creation.
        Dim objfrmNewMethod As New frmNewMethod
        Dim objfrmInstrParameters As frmInstrumentParameters
        Dim objfrmAnalysisParameters As frmMethodAnalysisParameters
        Dim objfrmStdParameters As frmStandardConcentration
        Dim objfrmSampleParameters As frmSampleParameters
        Dim objfrmReportOptions As frmReportOptions
        Dim objfrmUVQuantitativeAnalysis As frmUVQuantitativeAnalysis
        Dim objfrmEmissionMode As frmEmissionMode
        Dim objWait As New CWaitCursor
        If mblnAvoidProcessing = True Then
            Exit Sub
        End If
        mblnAvoidProcessing = True
        Try
            '------Added By Pankaj Thu 24 May 07
            gobjchkActiveMethod.NewMethod = False
            gobjchkActiveMethod.CancelMethod = False
            'gobjchkActiveMethod.fillInstruments = False '27.07.07
            gobjchkActiveMethod.fillParameters = False
            gobjchkActiveMethod.fillStdConcentration = False
            'gobjchkActiveMethod.DisconnectedModeMethod = False

            '------Added By Pankaj Fri 18 May 07
            If (gstructSettings.Enable21CFR = True) Then
                If Not funcCheckActivityAuthentication(enumActivityAuthentication.Method, gstructUserDetails.Access) Then
                    ''check for user authentication.
                    mblnAvoidProcessing = False
                    Return
                    Exit Sub
                End If
                gfuncInsertActivityLog(EnumModules.Method, "Method Accessed")
            End If
            '--------
            gobjMain.ShowRunTimeInfo(gstrTitleInstrumentType & ConstFormLoad)
            'tlbbtnNewMethod.SuspendEvents()
            If Not gobjNewMethod Is Nothing Then
                mobjPreviousSampParameter = gobjNewMethod.SampleDataCollection
            End If

            Application.DoEvents()
            ''allow application to perfrom its panding work.

            If objfrmNewMethod.ShowDialog() = DialogResult.OK Then
                ''this will show a new method form.
                Application.DoEvents()
                gobjchkActiveMethod.NewMethod = True
                'Added Pankaj 23 May 07
                gobjNewMethod.Status = False
                gobjchkActiveMethod.IsMethodAddedToCollectionInDisconnectedMode = False
                OpenMethodMode = modGlobalConstants.EnumMethodMode.NewMode

                btnInstrumentSettings.Enabled = True
                btnInstrumentParameters.Enabled = True
                btnStandardConcentrations.Enabled = True
                btnSampleParameters.Enabled = True
                btnReportOptions.Enabled = True

                If Not gobjNewMethod Is Nothing Then
                    If funcShowMethodGeneralInfo(gobjNewMethod) = True Then
                        ''show a method general info 
                        If OpenMethodMode = EnumMethodMode.NewMode Then
                            ''check either it is new method or method for edit
                            ''check a flag for it
                            ''
                            '---Enum Values Changed and Added by Mangesh on 23-Jan-2007
                            Select Case gobjNewMethod.OperationMode
                                ''check ofr method s operation mode.
                                Case EnumOperationMode.MODE_AA, EnumOperationMode.MODE_AABGC     '1, 3
                                    objfrmInstrParameters = New frmInstrumentParameters(OpenMethodMode)
                                    ''creat a object for instrument parameter
                                    Application.DoEvents()
                                    If objfrmInstrParameters.ShowDialog() = DialogResult.OK Then
                                        ''show a form of instrument parameter.
                                        '---do nothing & move forward to create new method
                                    Else
                                        gobjNewMethod.Status = False 'Added By Pankaj Thu 24 May 07
                                        funcShowMethodGeneralInfo(gobjNewMethod)
                                        'gobjchkActiveMethod.DisconnectedModeMethod = True
                                        mblnAvoidProcessing = False
                                        Exit Sub
                                    End If
                                    Application.DoEvents()
                                Case EnumOperationMode.MODE_UVABS   '2
                                    objfrmUVQuantitativeAnalysis = New frmUVQuantitativeAnalysis(OpenMethodMode)
                                    Application.DoEvents()
                                    If objfrmUVQuantitativeAnalysis.ShowDialog() = DialogResult.OK Then

                                        '---do nothing & move forward to create new method
                                    Else
                                        gobjNewMethod.Status = False 'Added By Pankaj Thu 24 May 07
                                        funcShowMethodGeneralInfo(gobjNewMethod)
                                        ''for showing method info.
                                        'gobjchkActiveMethod.DisconnectedModeMethod = True
                                        mblnAvoidProcessing = False
                                        Exit Sub
                                    End If
                                    Application.DoEvents()
                                Case EnumOperationMode.MODE_EMMISSION   '4
                                    objfrmEmissionMode = New frmEmissionMode(OpenMethodMode)
                                    Application.DoEvents()
                                    If objfrmEmissionMode.ShowDialog() = DialogResult.OK Then
                                        ''show the emission mode instrument parameter screen.
                                        '---do nothing & move forward to create new method
                                    Else
                                        'Added By Pankaj Thu 24 May 07
                                        gobjNewMethod.Status = False
                                        funcShowMethodGeneralInfo(gobjNewMethod)
                                        'gobjchkActiveMethod.DisconnectedModeMethod = True
                                        mblnAvoidProcessing = False
                                        Exit Sub
                                    End If
                                    Application.DoEvents()
                                    ''allow application to perfrom its panding work.
                            End Select

                            objfrmAnalysisParameters = New frmMethodAnalysisParameters(OpenMethodMode)
                            ''creat a object of analysis form.
                            Application.DoEvents()
                            objfrmAnalysisParameters.nudNumofSamples.Value = 25   'Added by Saurabh 22.07.07

                            If objfrmAnalysisParameters.ShowDialog() = DialogResult.OK Then
                                ''show the analysis dialog.
                                Application.DoEvents()
                                objfrmStdParameters = New frmStandardConcentration
                                ''creat a object for std parameter
                                Application.DoEvents()
                                If objfrmStdParameters.ShowDialog() = DialogResult.OK Then
                                    ''show a std parameter form.
                                    Application.DoEvents()
                                    ''allow application to perfrom it panding work.
                                    gobjNewMethod.Status = True 'Added By Pankaj 23 May 07 
                                    funcShowMethodGeneralInfo(gobjNewMethod)
                                    'objfrmSampleParameters = New frmSampleParameters(EnumMethodMode.NewMode, mobjPreviousSampParameter)
                                    objfrmSampleParameters = New frmSampleParameters(EnumMethodMode.NewMode)

                                    If objfrmSampleParameters.ShowDialog() = DialogResult.OK Then
                                        Application.DoEvents()
                                        ''show the sampler parameter form.
                                        objfrmReportOptions = New frmReportOptions(EnumMethodMode.NewMode, False, 0, 0)

                                        If objfrmReportOptions.ShowDialog() = DialogResult.OK Then
                                            ''show the report option dialog.
                                            Application.DoEvents()
                                        End If 'By pankaj for showing analysis message without report option ok on 17 Aug 07


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
                                        gobjchkActiveMethod.fillParameters = False
                                        gobjchkActiveMethod.fillStdConcentration = False
                                        gobjchkActiveMethod.IsMethodAddedToCollectionInDisconnectedMode = False
                                        'gobjchkActiveMethod.DisconnectedModeMethod = False   '27.07.07
                                        Call gobjMethodCollection.Add(gobjNewMethod)

                                        ''---serialize method collection 
                                        'Call funcSerialize(ConstMethodsFileName, gobjMethodCollection)
                                        Call funcSaveAllMethods(gobjMethodCollection)

                                        ''for saveing a method to the data structure.




                                        '----Added by Mangesh on 04-Apr-2007

                                        OpenMethodMode = modGlobalConstants.EnumMethodMode.EditMode


                                        '---display confirmation dialog box of method creation
                                        Call gobjMessageAdapter.ShowMessage(contMethodCreatedSuccessfully)
                                        Call Application.DoEvents()
                                        ''allow application to perfrom its panding work.
                                        gIntMethodID = gobjNewMethod.MethodID
                                        ''get a method id.
                                        '---Added by Mangesh on 24-Apr-2007
                                        RaiseEvent LoadedMethodChanged()

                                        ''this is  a event.

                                        '---START --- Added by Mangesh on 27-Feb-2007

                                        If gobjMessageAdapter.ShowMessage(constContinueAnalysis) = True Then
                                            ''ask user for analysis or not'
                                            ''prompt a message.
                                            Application.DoEvents()
                                            '---Open Analysis Form 
                                            '------Added By Pankaj Fri 18 May 07
                                            If (gstructSettings.Enable21CFR = True) Then
                                                If Not funcCheckActivityAuthentication(enumActivityAuthentication.Analysis, gstructUserDetails.Access) Then
                                                    mblnAvoidProcessing = False
                                                    Return
                                                    Exit Sub
                                                End If
                                                gfuncInsertActivityLog(EnumModules.Analysis, "Analysis Accessed")
                                            End If
                                            '--------
                                            Call gobjMain.OnQuantAnalyse()
                                        End If
                                        Application.DoEvents()

                                        '---END  ---  Added by Mangesh on 27-Feb-2007

                                        'Comment By pankaj for showing analysis message without report option ok on 17 Aug 07
                                        'Else
                                        '    'gobjNewMethod.Status = True
                                        '    Call saveMethod("CancelReport")
                                        '    'funcShowMethodGeneralInfo(gobjNewMethod)
                                        'End If
                                        'End
                                    Else
                                        'gobjNewMethod.Status = True
                                        Call saveMethod("CancelSampleParameter")
                                        'funcShowMethodGeneralInfo(gobjNewMethod)
                                    End If
                                Else
                                    gobjNewMethod.Status = False
                                    funcShowMethodGeneralInfo(gobjNewMethod)
                                End If
                            Else
                                gobjNewMethod.Status = False
                                funcShowMethodGeneralInfo(gobjNewMethod)
                            End If
                        Else
                            gobjNewMethod.Status = False
                            funcShowMethodGeneralInfo(gobjNewMethod)
                        End If
                    End If
                End If
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
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            gobjfrmStatus.TopMost = True
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub saveMethod(ByVal strModuleName As String)
        '=====================================================================
        ' Procedure Name        : saveMethod
        ' Parameters Passed     : 
        ' Returns               : None
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Pankaj Bamb
        ' Created               : 29.05.07
        ' Revisions             : 
        '=====================================================================
        ''note:
        ''this is called for saving a method
        Try
            gobjchkActiveMethod.NewMethod = False
            gobjchkActiveMethod.CancelMethod = False
            'gobjchkActiveMethod.fillInstruments = False
            gobjchkActiveMethod.fillParameters = False
            gobjchkActiveMethod.fillStdConcentration = False
            gobjNewMethod.Status = True
            ''do some onscreen validation 

            If (strModuleName = "CancelSampleParameter") Then
                Dim objMethodAnalysis As New frmMethodAnalysisParameters(OpenMethodMode)
                Dim intUnitID, intNoOfSamples As Integer
                intUnitID = gobjNewMethod.AnalysisParameters.Unit
                intNoOfSamples = gobjNewMethod.AnalysisParameters.NumOfSamples()
                objMethodAnalysis.updateSampleParameter(intNoOfSamples, intUnitID)
            End If

            Call gobjMethodCollection.Add(gobjNewMethod)
            ''add to method data structure
            Call funcSaveAllMethods(gobjMethodCollection)
            ''save all method to collection 
            Call Application.DoEvents()
            ''allow application to nperfrom its panding work.
            gIntMethodID = gobjNewMethod.MethodID
            RaiseEvent LoadedMethodChanged()
            funcShowMethodGeneralInfo(gobjNewMethod)
            ''show a info of method which is just saved.
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If

            'tlbbtnNewMethod.ResumeEvents()
            gobjfrmStatus.TopMost = True
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub tlbbtnLoadMethod_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : tlbbtnLoadMethod_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To load the frmLoadMethod form
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 05.10.06
        ' Revisions             : Sachin Dokhale on 09.12.06
        '=====================================================================
        ''note:
        ''this is a event which called when user click on load method button
        ''this will show a load method form.
        Dim objWait As New CWaitCursor
        If mblnAvoidProcessing = True Then
            ''for avoiding a process
            Exit Sub
        End If
        mblnAvoidProcessing = True
        Try
            '------Added By Pankaj Fri 18 May 07
            If (gstructSettings.Enable21CFR = True) Then
                If Not funcCheckActivityAuthentication(enumActivityAuthentication.Method, gstructUserDetails.Access) Then
                    ''check for user authentication
                    mblnAvoidProcessing = False
                    Return
                    Exit Sub
                End If
                gfuncInsertActivityLog(EnumModules.Method, "Method Accessed")
            End If
            '--------


            gobjMain.ShowRunTimeInfo(gstrTitleInstrumentType & ConstFormLoad)
            If Not gobjNewMethod Is Nothing Then
                mobjPreviousSampParameter = gobjNewMethod.SampleDataCollection
            End If

            mobjfrmLoadMethod.ShowDialog()
            ''show a load method form.
            mblnAvoidProcessing = False
            Application.DoEvents()
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
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub tlbbtnInstrumentParameters_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : tlbbtnInstrumentParameters_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To load the Instrument Parameters form
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 25.09.06
        ' Revisions             : 
        '=====================================================================
        ''note:
        ''this is called when user clicked on instrument parameter button.
        ''this will show a instrument parameter form.
        Dim objWait As New CWaitCursor
        Dim objfrmInstrumentParameters As frmInstrumentParameters
        Dim objfrmUVQuantitativeAnalysis As frmUVQuantitativeAnalysis
        Dim objfrmEmissionMode As frmEmissionMode
        Dim objfrmD2PeakSearch As frmD2PeakSearch
        If mblnAvoidProcessing = True Then
            Exit Sub
        End If
        mblnAvoidProcessing = True
        Try
            gobjMain.ShowRunTimeInfo(gstrTitleInstrumentType & ConstFormLoad)
            'tlbbtnInstrumentParameters.SuspendEvents()

            'gobjMain.mobjController.Cancel()   'Commented by Saurabh
            'Application.DoEvents()

            'If Not IsNothing(gobjMain.mobjfrmAnalysis) Then gobjMain.mobjfrmAnalysis.tmrAspirationMsg.Enabled = False

            Application.DoEvents()

            If gobjNewMethod.OperationMode = EnumOperationMode.MODE_AA _
                Or gobjNewMethod.OperationMode = EnumOperationMode.MODE_AABGC Then
                ''check for mode
                objfrmInstrumentParameters = New frmInstrumentParameters(OpenMethodMode)
                AddHandler objfrmInstrumentParameters.MethodInstrumentSettingsChanged, AddressOf objfrmInstrumentParameters_MethodInstrumentSettingsChanged
                objfrmInstrumentParameters.ShowDialog()
                ''show instrument parameter form.
                Application.DoEvents()
                funcShowMethodGeneralInfo(gobjNewMethod)
                ''show method info.
                objfrmInstrumentParameters.Close()
                objfrmInstrumentParameters.Dispose()
                objfrmInstrumentParameters = Nothing

            ElseIf gobjNewMethod.OperationMode = EnumOperationMode.MODE_UVABS Then  'TxtModeOfOperation.Text = "UV ABS Quantitative Mode" Then
                ''do for UV mode
                objfrmUVQuantitativeAnalysis = New frmUVQuantitativeAnalysis(OpenMethodMode)
                objfrmUVQuantitativeAnalysis.ShowDialog()
                Application.DoEvents()
                objfrmUVQuantitativeAnalysis.Close()
                objfrmUVQuantitativeAnalysis.Dispose()
                objfrmUVQuantitativeAnalysis = Nothing

            ElseIf gobjNewMethod.OperationMode = EnumOperationMode.MODE_EMMISSION Then   'ElseIf TxtModeOfOperation.Text = "Emission Quantitative Mode" Then
                ''do for emission mode
                objfrmEmissionMode = New frmEmissionMode(OpenMethodMode)
                objfrmEmissionMode.ShowDialog()
                Application.DoEvents()
                objfrmEmissionMode.Close()
                objfrmEmissionMode.Dispose()
                objfrmEmissionMode = Nothing

            End If

            'gobjMain.mobjController.Start(gobjclsBgFlameStatus)    'Commented by Saurabh
            'Application.DoEvents()
            'If Not IsNothing(gobjMain.mobjfrmAnalysis) Then gobjMain.mobjfrmAnalysis.tmrAspirationMsg.Enabled = True

            Application.DoEvents()
            Call funcShowMethodGeneralInfo(gobjNewMethod) 'Added by Pankaj on 31 May 07
            mblnAvoidProcessing = False
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            mblnAvoidProcessing = False
            '--------------------------------------- ------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            objWait.Dispose()



            'tlbbtnInstrumentParameters.ResumeEvents()
            '---------------------------------------------------------
        End Try

    End Sub

    'Private Sub tlbbtnAnalysisParameters_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    '=====================================================================
    '    ' Procedure Name        : tlbbtnAnalysisParameters_Click
    '    ' Parameters Passed     : Object,EventArgs
    '    ' Returns               : None
    '    ' Purpose               : To load the frmAnalysisParameters form
    '    ' Description           : 
    '    ' Assumptions           : 
    '    ' Dependencies          : 
    '    ' Author                : Saurabh S
    '    ' Created               : 25.09.06
    '    ' Revisions             : 
    '    '=====================================================================
    '    If gobjchkActiveMethod.fillParameters = True And OpenMethodMode = modGlobalConstants.EnumMethodMode.NewMode Then                   'Added By Pankaj on 26 May 07
    '        OpenMethodMode = modGlobalConstants.EnumMethodMode.EditMode    'Added By Pankaj on 26 May 07
    '    ElseIf gobjchkActiveMethod.NewMethod = False And OpenMethodMode = modGlobalConstants.EnumMethodMode.NewMode Then                  'Added By Pankaj on 26 May 07
    '        OpenMethodMode = modGlobalConstants.EnumMethodMode.EditMode   'Added By Pankaj on 26 May 07
    '    End If   '27.07.07

    '    Dim objfrmMethodAnalysisParameters As New frmMethodAnalysisParameters(OpenMethodMode)
    '    Dim objWait As New CWaitCursor
    '    Try
    '        gobjMain.ShowRunTimeInfo(ConstFormLoad)
    '        objfrmMethodAnalysisParameters.ShowDialog()
    '        funcShowMethodGeneralInfo(gobjNewMethod)
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

    Private Sub tlbbtnAnalysisParameters_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : tlbbtnAnalysisParameters_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To load the frmAnalysisParameters form
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 25.09.06
        ' Revisions             : 
        '=====================================================================
        'If gobjchkActiveMethod.fillParameters = True And OpenMethodMode = modGlobalConstants.EnumMethodMode.NewMode Then                   'Added By Pankaj on 26 May 07
        '    OpenMethodMode = modGlobalConstants.EnumMethodMode.EditMode    'Added By Pankaj on 26 May 07
        'ElseIf gobjchkActiveMethod.NewMethod = False And OpenMethodMode = modGlobalConstants.EnumMethodMode.NewMode Then                  'Added By Pankaj on 26 May 07
        '    OpenMethodMode = modGlobalConstants.EnumMethodMode.EditMode   'Added By Pankaj on 26 May 07
        'End If   '27.07.07

        Dim objfrmMethodAnalysisParameters As New frmMethodAnalysisParameters(OpenMethodMode)
        Dim objWait As New CWaitCursor
        If mblnAvoidProcessing = True Then
            Exit Sub
        End If
        mblnAvoidProcessing = True
        Try
            gobjMain.ShowRunTimeInfo(gstrTitleInstrumentType & ConstFormLoad)
            objfrmMethodAnalysisParameters.ShowDialog()
            Application.DoEvents()
            funcShowMethodGeneralInfo(gobjNewMethod)
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
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            '---------------------------------------------------------
        End Try
    End Sub


    Private Sub tlbbtnStdConcentration_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : tlbbtnStdConcentration_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To load the frmStdConcentration form
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 25.09.06
        ' Revisions             : 
        '=====================================================================
        Dim objfrmStandardConcentration As frmStandardConcentration
        If mblnAvoidProcessing = True Then
            Exit Sub
        End If
        mblnAvoidProcessing = True
        Try
            gobjMain.ShowRunTimeInfo(gstrTitleInstrumentType & ConstFormLoad)
            'tlbbtnStandardConcentrations.SuspendEvents()

            objfrmStandardConcentration = New frmStandardConcentration
            objfrmStandardConcentration.ShowDialog()
            Application.DoEvents()
            objfrmStandardConcentration.Close()
            objfrmStandardConcentration.Dispose()
            objfrmStandardConcentration = Nothing
            Call funcShowMethodGeneralInfo(gobjNewMethod) 'Added By Pankaj23 May 07
            '            gobjMethodCollection = gobjNewMethod
            'Call gobjMethodCollection.Add(gobjNewMethod) 'comment by pankaj 25 MAy 07
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
            'tlbbtnStandardConcentrations.ResumeEvents()
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub tlbbtnSampParameters_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : tlbbtnSampParameters_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To load the frmSampParameters form
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 25.09.06
        ' Revisions             : 
        '=====================================================================
        ''note;
        ''this is called when user clicked on sample parameter button
        ''to load sampler parameter form.
        Dim objfrmSampleParameters As frmSampleParameters
        If mblnAvoidProcessing = True Then
            Exit Sub
        End If
        mblnAvoidProcessing = True
        Try
            gobjMain.ShowRunTimeInfo(gstrTitleInstrumentType & ConstFormLoad)
            'tlbbtnSampleParameters.SuspendEvents()

            objfrmSampleParameters = New frmSampleParameters(0, mobjPreviousSampParameter)
            objfrmSampleParameters.ShowDialog()
            ''show the form.
            Application.DoEvents()
            objfrmSampleParameters.Close()
            objfrmSampleParameters.Dispose()
            objfrmSampleParameters = Nothing
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
            Application.DoEvents()
            'tlbbtnSampleParameters.ResumeEvents()
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub tlbbtnReportOptions_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : tlbbtnReportOptions_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To load the frmReportOptions form
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 25.09.06
        ' Revisions             : 
        '=====================================================================
        ''note:
        ''this is called when user clicked on report option button
        ''for showing a report option dialog.
        Dim objfrmReportOptions As frmReportOptions
        If mblnAvoidProcessing = True Then
            Exit Sub
        End If
        mblnAvoidProcessing = True
        Try
            gobjMain.ShowRunTimeInfo(gstrTitleInstrumentType & ConstFormLoad)
            'tlbbtnReportOptions.SuspendEvents()

            objfrmReportOptions = New frmReportOptions(EnumMethodMode.EditMode, False, 0, 0)
            objfrmReportOptions.ShowDialog()
            Application.DoEvents()
            objfrmReportOptions.Close()
            objfrmReportOptions.Dispose()
            objfrmReportOptions = Nothing
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
            'tlbbtnReportOptions.ResumeEvents()
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
    '        If Me.XpPanelInstrumentSettings.PanelState = UIComponents.XPPanelState.Expanded Then
    '            Me.XpPanelInstrumentSettings.TogglePanelState()
    '            Me.XpPanelInstrumentSettings.Height = 0
    '        End If
    '        If XpPanelInstrumentParameters.PanelState = UIComponents.XPPanelState.Expanded Then
    '            Me.XpPanelInstrumentParameters.TogglePanelState()
    '            Me.XpPanelInstrumentParameters.Height = 0
    '        End If
    '        If Me.XpPanelStandardConcentrations.PanelState = UIComponents.XPPanelState.Expanded Then
    '            Me.XpPanelStandardConcentrations.TogglePanelState()
    '            Me.XpPanelStandardConcentrations.Height = 0
    '        End If
    '        If Me.XpPanelSampleParameters.PanelState = UIComponents.XPPanelState.Expanded Then
    '            Me.XpPanelSampleParameters.TogglePanelState()
    '            Me.XpPanelSampleParameters.Height = 0
    '        End If
    '        If Me.XpPanelReportOptions.PanelState = UIComponents.XPPanelState.Expanded Then
    '            Me.XpPanelReportOptions.TogglePanelState()
    '            Me.XpPanelReportOptions.Height = 0
    '        End If
    '        If Me.XpPanelNewMethod.PanelState = UIComponents.XPPanelState.Expanded Then
    '            Me.XpPanelNewMethod.TogglePanelState()
    '            Me.XpPanelNewMethod.Height = 0
    '        End If
    '        If Me.XpPanelLoadMethod.PanelState = UIComponents.XPPanelState.Expanded Then
    '            Me.XpPanelLoadMethod.TogglePanelState()
    '            Me.XpPanelLoadMethod.Height = 0
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
        Try
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

    'Private Sub XpPanelInstrumentSettingsClicked(ByVal sender As Object, ByVal e As System.EventArgs)
    '    '=====================================================================
    '    ' Procedure Name        : XpPanelInstrumentSettingsClicked
    '    ' Parameters Passed     : Object,EventArgs
    '    ' Returns               : None
    '    ' Purpose               : To load the Instrument Settings form
    '    ' Description           : 
    '    ' Assumptions           : 
    '    ' Dependencies          : 
    '    ' Author                : Deepak & Saurabh
    '    ' Created               : 05.10.06
    '    ' Revisions             : 
    '    '=====================================================================
    '    Dim objWait As New CWaitCursor
    '    Try
    '        If Me.XpPanelInstrumentSettings.PanelState = UIComponents.XPPanelState.Collapsed Then
    '            Call funcCollapseAllXPPanels()
    '            Me.XpPanelInstrumentSettings.TogglePanelState()
    '            Me.XpPanelInstrumentSettings.PanelHeight = 90
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

    'Private Sub XpPanelParametersClicked(ByVal sender As Object, ByVal e As System.EventArgs)
    '    '=====================================================================
    '    ' Procedure Name        : XpPanelParametersClicked
    '    ' Parameters Passed     : Object,EventArgs
    '    ' Returns               : None
    '    ' Purpose               : To load the Method Parameters form
    '    ' Description           : 
    '    ' Assumptions           : 
    '    ' Dependencies          : 
    '    ' Author                : Deepak & Saurabh
    '    ' Created               : 05.10.06
    '    ' Revisions             : 
    '    '===================================================================== 
    '    Dim objWait As New CWaitCursor
    '    Try
    '        If Me.XpPanelInstrumentParameters.PanelState = UIComponents.XPPanelState.Collapsed Then
    '            Call funcCollapseAllXPPanels()
    '            Me.XpPanelInstrumentParameters.TogglePanelState()
    '            Me.XpPanelInstrumentParameters.PanelHeight = 80
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

    'Private Sub XpPanelStandardConcentrationClicked(ByVal sender As Object, ByVal e As System.EventArgs)
    '    '=====================================================================
    '    ' Procedure Name        : XpPanelStandardConcentrationClicked
    '    ' Parameters Passed     : Object,EventArgs
    '    ' Returns               : None
    '    ' Purpose               : To load the Standard Concentration form
    '    ' Description           : 
    '    ' Assumptions           : 
    '    ' Dependencies          : 
    '    ' Author                : Deepak & Saurabh
    '    ' Created               : 05.10.06
    '    ' Revisions             : 
    '    '===================================================================== 
    '    Dim objWait As New CWaitCursor
    '    Try
    '        If Me.XpPanelStandardConcentrations.PanelState = UIComponents.XPPanelState.Collapsed Then
    '            Call funcCollapseAllXPPanels()
    '            Me.XpPanelStandardConcentrations.TogglePanelState()
    '            Me.XpPanelStandardConcentrations.PanelHeight = 90
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

    'Private Sub XpPanelSampleParametersClicked(ByVal sender As Object, ByVal e As System.EventArgs)
    '    '=====================================================================
    '    ' Procedure Name        : XpPanelSampleParametersClicked
    '    ' Parameters Passed     : Object,EventArgs
    '    ' Returns               : None
    '    ' Purpose               : To load the Sample Parameters form
    '    ' Description           : 
    '    ' Assumptions           : 
    '    ' Dependencies          : 
    '    ' Author                : Deepak & Saurabh
    '    ' Created               : 05.10.06
    '    ' Revisions             : 
    '    '===================================================================== 
    '    Dim objWait As New CWaitCursor
    '    Try
    '        If Me.XpPanelSampleParameters.PanelState = UIComponents.XPPanelState.Collapsed Then
    '            Call funcCollapseAllXPPanels()
    '            Me.XpPanelSampleParameters.TogglePanelState()
    '            Me.XpPanelSampleParameters.PanelHeight = 80
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

    'Private Sub XpPanelReportOptionsClicked(ByVal sender As Object, ByVal e As System.EventArgs)
    '    '=====================================================================
    '    ' Procedure Name        : XpPanelReportOptionsClicked
    '    ' Parameters Passed     : Object,EventArgs
    '    ' Returns               : None
    '    ' Purpose               : To load the Report Options form
    '    ' Description           : 
    '    ' Assumptions           : 
    '    ' Dependencies          : 
    '    ' Author                : Deepak & Saurabh
    '    ' Created               : 05.10.06
    '    ' Revisions             : 
    '    '=====================================================================
    '    Dim objWait As New CWaitCursor
    '    Try
    '        If Me.XpPanelReportOptions.PanelState = UIComponents.XPPanelState.Collapsed Then
    '            Call funcCollapseAllXPPanels()
    '            Me.XpPanelReportOptions.TogglePanelState()
    '            Me.XpPanelReportOptions.PanelHeight = 80

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

    'Private Sub XpPanelNewMethodClicked(ByVal sender As Object, ByVal e As System.EventArgs)
    '    '=====================================================================
    '    ' Procedure Name        : XpPanelNewMethodClicked
    '    ' Parameters Passed     : Object,EventArgs
    '    ' Returns               : None
    '    ' Purpose               : To create new method
    '    ' Description           : 
    '    ' Assumptions           : 
    '    ' Dependencies          : 
    '    ' Author                : Deepak & Saurabh
    '    ' Created               : 05.10.06
    '    ' Revisions             : 
    '    '=====================================================================
    '    'Dim objWait As New CWaitCursor
    '    Try
    '        If Me.XpPanelNewMethod.PanelState = UIComponents.XPPanelState.Collapsed Then
    '            Call funcCollapseAllXPPanels()
    '            Me.XpPanelNewMethod.TogglePanelState()
    '            Me.XpPanelNewMethod.PanelHeight = 80
    '            'Me.XpPanelNewMethod.Height = 112
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
    '        'If Not objWait Is Nothing Then
    '        '    objWait.Dispose()
    '        'End If
    '        '---------------------------------------------------------
    '    End Try
    'End Sub

    'Private Sub XpPanelLoadMethodClicked(ByVal sender As Object, ByVal e As System.EventArgs)
    '    '=====================================================================
    '    ' Procedure Name        : XpPanelLoadMethodClicked
    '    ' Parameters Passed     : Object,EventArgs
    '    ' Returns               : None
    '    ' Purpose               : To Load method
    '    ' Description           : 
    '    ' Assumptions           : 
    '    ' Dependencies          : 
    '    ' Author                : Deepak & Saurabh
    '    ' Created               : 05.10.06
    '    ' Revisions             : 
    '    '=====================================================================
    '    'Dim objWait As New CWaitCursor
    '    Try
    '        If Me.XpPanelLoadMethod.PanelState = UIComponents.XPPanelState.Collapsed Then
    '            Call funcCollapseAllXPPanels()
    '            Me.XpPanelLoadMethod.TogglePanelState()
    '            Me.XpPanelLoadMethod.PanelHeight = 80
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
    '        'If Not objWait Is Nothing Then
    '        '    objWait.Dispose()
    '        'End If
    '        '---------------------------------------------------------
    '    End Try
    'End Sub

    Private Function funcShowMethodGeneralInfo(ByVal objMethod As clsMethod) As Boolean
        '=====================================================================
        ' Procedure Name        : funcShowMethodGeneralInfo
        ' Parameters Passed     : object of clsMethod
        ' Returns               : True or False
        ' Purpose               : To show method information 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 05.10.06
        ' Revisions             : 
        '=====================================================================
        ''note:
        ''this is used to show method information 
        ''in this we take a value from objMethod object
        ''and displa it on screen,.
        Dim objRow As DataRow
        Dim strStatus As String = ""

        Try
            TxtMethodName.Text = objMethod.MethodName
            ''show method name in methodname text box 
            ''and so on.
            TxtMethodComments.Text = objMethod.Comments

            objRow = gobjClsAAS203.funcGetMethodType(objMethod.OperationMode)
            ''this is to get method type
            If Not objRow Is Nothing Then
                If gobjNewMethod.StandardAddition Then          'Saurabh 25.07.07 Check for Standard Addition"
                    ''check for std add
                    TxtModeOfOperation.Text = "STANDARD ADDITION [" & objRow.Item(ConstColumnMethodType) & "]"
                Else
                    TxtModeOfOperation.Text = objRow.Item(ConstColumnMethodType)
                End If
            End If
            If objMethod.Status = True Then
                ''check a flag for status of a flag.
                strStatus = ConstActive
            Else
                strStatus = ConstNotActive
            End If

            Dim strDateOfModification, strDateOfLastUse As String
            If Not objMethod.DateOfModification = Date.FromOADate(0.0) Then
                strDateOfModification = Format(objMethod.DateOfModification, "dd-MMM-yyyy hh:mm tt")
            End If
            If Not objMethod.DateOfLastUse = Date.FromOADate(0.0) Then
                strDateOfLastUse = Format(objMethod.DateOfLastUse, "dd-MMM-yyyy hh:mm tt")
            End If

            lstMethodInformation.Items.Clear()
            lstMethodInformation.Items.Add(ConstCreatedBy & vbTab & objMethod.UserName)
            lstMethodInformation.Items.Add(ConstCreatedOn & vbTab & Format(objMethod.DateOfCreation, "dd-MMM-yyyy hh:mm tt"))
            lstMethodInformation.Items.Add(ConstStatus & vbTab & vbTab & strStatus)
            lstMethodInformation.Items.Add(ConstChangedOn & vbTab & strDateOfModification)
            lstMethodInformation.Items.Add(ConstLastUsedOn & vbTab & strDateOfLastUse)

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

    Function createTestMethod()
        '=====================================================================
        ' Procedure Name        : createTestMethod
        ' Parameters Passed     : None
        ' Returns               : True or False
        ' Purpose               : for creat a test method.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 05.10.06
        ' Revisions             : 
        '=====================================================================
        Try
            'Call funcSerialize(ConstMethodsFileName, gobjMethodCollection)
            Call funcSaveAllMethods(gobjMethodCollection)
            ''function for saving a method.

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
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

    Private Sub mobjfrmLoadMethod_LoadMethod(ByVal objClsMethod As AAS203Library.Method.clsMethod)
        '=====================================================================
        ' Procedure Name        : mobjfrmLoadMethod_LoadMethod
        ' Parameters Passed     : object of clsMethod
        ' Returns               : None
        ' Purpose               : To display general information of load method event of frmLoadMethod form
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 05.10.06
        ' Revisions             : 
        '=====================================================================
        Try
            Call funcShowMethodGeneralInfo(objClsMethod)
            ''this will show a information from method object to Screen.
            OpenMethodMode = modGlobalConstants.EnumMethodMode.EditMode
            ''set a mode of a method to edit mode.

            '--- Added by Mangesh on 27-Feb-2007
            '--- For incrementing Run Number for recently loaded Method.

            gobjMain.IsStartAnalysisRunNumber = True
            ''flag for analysis


            'XpPanelInstrumentSettings.Enabled = True
            'XpPanelInstrumentParameters.Enabled = True
            'XpPanelStandardConcentrations.Enabled = True
            'XpPanelSampleParameters.Enabled = True
            'XpPanelReportOptions.Enabled = True
            ''
            ''onscreen validation during loading.
            btnInstrumentSettings.Enabled = True
            btnInstrumentParameters.Enabled = True
            btnStandardConcentrations.Enabled = True
            btnSampleParameters.Enabled = True
            btnReportOptions.Enabled = True

            'tlbbtnInstrumentSettings.Enabled = True
            'tlbbtnInstrumentParameters.Enabled = True
            'tlbbtnStandardConcentrations.Enabled = True
            'tlbbtnSampleParameters.Enabled = True
            'tlbbtnReportOptions.Enabled = True

            RaiseEvent LoadedMethodChanged()
            ''raise a event
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
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

    Private Sub objfrmInstrumentParameters_MethodInstrumentSettingsChanged()
        '=====================================================================
        ' Procedure Name        : objfrmInstrumentParameters_MethodInstrumentSettingsChanged
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : To notify the MDIMain form about status of Method Instrument
        '                         Settings are changed and perform Peak Latching in Analysis form
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 14-Mar-2007 04:25 pm
        ' Revisions             : 1
        '=====================================================================
        Try
            gobjMain.MethodInstrumentSettingsChanged = True

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
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

    'Private Sub XpPanelInstrumentSettings_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    '=====================================================================
    '    ' Procedure Name        : XpPanelInstrumentSettingsClicked
    '    ' Parameters Passed     : Object,EventArgs
    '    ' Returns               : None
    '    ' Purpose               : To load the Instrument Settings form
    '    ' Description           : 
    '    ' Assumptions           : 
    '    ' Dependencies          : 
    '    ' Author                : Deepak & Saurabh
    '    ' Created               : 05.10.06
    '    ' Revisions             : 
    '    '=====================================================================
    '    Dim objWait As New CWaitCursor
    '    Try
    '        If Me.XpPanelInstrumentSettings.PanelState = UIComponents.XPPanelState.Collapsed Then
    '            Call funcCollapseAllXPPanels()
    '            Me.XpPanelInstrumentSettings.TogglePanelState()
    '            Me.XpPanelInstrumentSettings.PanelHeight = 90
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

    'Private Sub XpPanelInstrumentParameters_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    '=====================================================================
    '    ' Procedure Name        : XpPanelParametersClicked
    '    ' Parameters Passed     : Object,EventArgs
    '    ' Returns               : None
    '    ' Purpose               : To load the Method Parameters form
    '    ' Description           : 
    '    ' Assumptions           : 
    '    ' Dependencies          : 
    '    ' Author                : Deepak & Saurabh
    '    ' Created               : 05.10.06
    '    ' Revisions             : 
    '    '===================================================================== 
    '    Dim objWait As New CWaitCursor
    '    Try
    '        If Me.XpPanelInstrumentParameters.PanelState = UIComponents.XPPanelState.Collapsed Then
    '            Call funcCollapseAllXPPanels()
    '            Me.XpPanelInstrumentParameters.TogglePanelState()
    '            Me.XpPanelInstrumentParameters.PanelHeight = 80
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

    'Private Sub XpPanelLoadMethod_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    '=====================================================================
    '    ' Procedure Name        : XpPanelLoadMethodClicked
    '    ' Parameters Passed     : Object,EventArgs
    '    ' Returns               : None
    '    ' Purpose               : To Load method
    '    ' Description           : 
    '    ' Assumptions           : 
    '    ' Dependencies          : 
    '    ' Author                : Deepak & Saurabh
    '    ' Created               : 05.10.06
    '    ' Revisions             : 
    '    '=====================================================================
    '    'Dim objWait As New CWaitCursor
    '    Try
    '        If Me.XpPanelLoadMethod.PanelState = UIComponents.XPPanelState.Collapsed Then
    '            Call funcCollapseAllXPPanels()
    '            Me.XpPanelLoadMethod.TogglePanelState()
    '            Me.XpPanelLoadMethod.PanelHeight = 80
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
    '        'If Not objWait Is Nothing Then
    '        '    objWait.Dispose()
    '        'End If
    '        '---------------------------------------------------------
    '    End Try
    'End Sub

    'Private Sub XpPanelNewMethod_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    '=====================================================================
    '    ' Procedure Name        : XpPanelNewMethodClicked
    '    ' Parameters Passed     : Object,EventArgs
    '    ' Returns               : None
    '    ' Purpose               : To create new method
    '    ' Description           : 
    '    ' Assumptions           : 
    '    ' Dependencies          : 
    '    ' Author                : Deepak & Saurabh
    '    ' Created               : 05.10.06
    '    ' Revisions             : 
    '    '=====================================================================
    '    'Dim objWait As New CWaitCursor
    '    Try
    '        If Me.XpPanelNewMethod.PanelState = UIComponents.XPPanelState.Collapsed Then
    '            Call funcCollapseAllXPPanels()
    '            Me.XpPanelNewMethod.TogglePanelState()
    '            Me.XpPanelNewMethod.PanelHeight = 80
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
    '        'If Not objWait Is Nothing Then
    '        '    objWait.Dispose()
    '        'End If
    '        '---------------------------------------------------------
    '    End Try
    'End Sub

    'Private Sub XpPanelReportOptions_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    '=====================================================================
    '    ' Procedure Name        : XpPanelReportOptionsClicked
    '    ' Parameters Passed     : Object,EventArgs
    '    ' Returns               : None
    '    ' Purpose               : To load the Report Options form
    '    ' Description           : 
    '    ' Assumptions           : 
    '    ' Dependencies          : 
    '    ' Author                : Deepak & Saurabh
    '    ' Created               : 05.10.06
    '    ' Revisions             : 
    '    '=====================================================================
    '    Dim objWait As New CWaitCursor
    '    Try
    '        If Me.XpPanelReportOptions.PanelState = UIComponents.XPPanelState.Collapsed Then
    '            Call funcCollapseAllXPPanels()
    '            Me.XpPanelReportOptions.TogglePanelState()
    '            Me.XpPanelReportOptions.PanelHeight = 80
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

    'Private Sub XpPanelSampleParameters_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    '=====================================================================
    '    ' Procedure Name        : XpPanelSampleParametersClicked
    '    ' Parameters Passed     : Object,EventArgs
    '    ' Returns               : None
    '    ' Purpose               : To load the Sample Parameters form
    '    ' Description           : 
    '    ' Assumptions           : 
    '    ' Dependencies          : 
    '    ' Author                : Deepak & Saurabh
    '    ' Created               : 05.10.06
    '    ' Revisions             : 
    '    '===================================================================== 
    '    Dim objWait As New CWaitCursor
    '    Try
    '        If Me.XpPanelSampleParameters.PanelState = UIComponents.XPPanelState.Collapsed Then
    '            Call funcCollapseAllXPPanels()
    '            Me.XpPanelSampleParameters.TogglePanelState()
    '            Me.XpPanelSampleParameters.PanelHeight = 80
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

    'Private Sub XpPanelStandardConcentrations_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    '=====================================================================
    '    ' Procedure Name        : XpPanelStandardConcentrationClicked
    '    ' Parameters Passed     : Object,EventArgs
    '    ' Returns               : None
    '    ' Purpose               : To load the Standard Concentration form
    '    ' Description           : 
    '    ' Assumptions           : 
    '    ' Dependencies          : 
    '    ' Author                : Deepak & Saurabh
    '    ' Created               : 05.10.06
    '    ' Revisions             : 
    '    '===================================================================== 
    '    Dim objWait As New CWaitCursor
    '    Try
    '        If Me.XpPanelStandardConcentrations.PanelState = UIComponents.XPPanelState.Collapsed Then
    '            Call funcCollapseAllXPPanels()
    '            Me.XpPanelStandardConcentrations.TogglePanelState()
    '            Me.XpPanelStandardConcentrations.PanelHeight = 90
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

    Private Sub btnIgnite_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '=====================================================================
        '    ' Procedure Name        : btnIgnite_Click
        '    ' Parameters Passed     : Object,EventArgs
        '    ' Returns               : None
        '    ' Purpose               : 
        '    ' Description           : 
        '    ' Assumptions           : 
        '    ' Dependencies          : 
        '    ' Author                : Deepak & Saurabh
        '    ' Created               : 05.10.06
        '    ' Revisions             : 
        '    '=====================================================================
        ''note:
        ''this is called when user click on ignite button
        ''this will ignite by calling a function
        If mblnAvoidProcessing = True Then
            Exit Sub
        End If
        Try
            If Not IsNothing(gobjMain) Then
                'MsgBox("frmStatus")
                mblnAvoidProcessing = True
                gobjMain.AutoIgnition()
                ''function for ignite
                mblnAvoidProcessing = False

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

    Private Sub btnExtinguish_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '=====================================================================
        '    ' Procedure Name        : btnExtinguish_Click
        '    ' Parameters Passed     : Object,EventArgs
        '    ' Returns               : None
        '    ' Purpose               : this is called when user click on Extinguish button.
        '    ' Description           : 
        '    ' Assumptions           : 
        '    ' Dependencies          : 
        '    ' Author                : Deepak & Saurabh
        '    ' Created               : 05.10.06
        '    ' Revisions             : 
        '    '=====================================================================
        If mblnAvoidProcessing = True Then
            Exit Sub
        End If
        Try
            mblnAvoidProcessing = True


            gobjMain.Extinguish()
            ''function for Extinguish
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

    Private Sub btnN2OIgnite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '=====================================================================
        '    ' Procedure Name        : btnN2OIgnite_Click
        '    ' Parameters Passed     : Object,EventArgs
        '    ' Returns               : None
        '    ' Purpose               : this is calledwhen user clicked on N2O button.
        '    ' Description           : 
        '    ' Assumptions           : 
        '    ' Dependencies          : 
        '    ' Author                : Deepak & Saurabh
        '    ' Created               : 05.10.06
        '    ' Revisions             : 
        '    '=====================================================================
        If mblnAvoidProcessing = True Then
            Exit Sub
        End If
        Try
            mblnAvoidProcessing = True
            Call gobjMain.N2OAutoIgnition()
            ''function for N2O ignition.
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

#End Region

#Region "Commented Code"
    '#Region " ProgressBar Functions "

    '    Public Sub ShowProgressBar(ByVal message As String)
    '        '=====================================================================
    '        ' Procedure Name        : ShowProgressBar
    '        ' Parameters Passed     : message
    '        ' Returns               : None
    '        ' Purpose               : to show the progress bar
    '        ' Description           : 
    '        ' Assumptions           : 
    '        ' Dependencies          : 
    '        ' Author                : Deepak Bhati
    '        ' Created               : Saturday, January 22, 2005
    '        ' Revisions             : 
    '        '=====================================================================
    '        Try
    '            ProgressPanel.Value = 20
    '            StatusBarPanelInfo.Text = message
    '            'start a new thread to increment the progressbar
    '            Dim progressThread As New Thread(AddressOf BackGroundIncrementProgressBar)
    '            progressThread.IsBackground = True
    '            progressThread.Name = "Progress Bar"
    '            progressThread.Start()

    '        Catch ex As Exception
    '            '---------------------------------------------------------
    '            'Error Handling and logging
    '            gobjErrorHandler.ErrorDescription = ex.Message
    '            gobjErrorHandler.ErrorMessage = ex.Message
    '            gobjErrorHandler.WriteErrorLog(ex)
    '            '---------------------------------------------------------
    '        Finally
    '            '---------------------------------------------------------
    '            'Writing Execution log
    '            If CONST_CREATE_EXECUTION_LOG = 1 Then
    '                gobjErrorHandler.WriteExecutionLog()
    '            End If
    '            '---------------------------------------------------------
    '        End Try
    '    End Sub

    '    Private Sub BackGroundIncrementProgressBar()
    '        '=====================================================================
    '        ' Procedure Name        : BackGroundIncrementProgressBar
    '        ' Parameters Passed     : None
    '        ' Returns               : None 
    '        ' Purpose               : to increment the progress of progress bar
    '        ' Description           : 
    '        ' Assumptions           : 
    '        ' Dependencies          : 
    '        ' Author                : Deepak Bhati
    '        ' Created               : Saturday, January 22, 2005
    '        ' Revisions             : 
    '        '=====================================================================
    '        Try
    '            'note: this will run on a worker thread
    '            While ProgressPanel.Value <> 100
    '                If ProgressPanel.Value < 80 Then ProgressPanel.Value += 8
    '                Thread.Sleep(30)
    '            End While

    '        Catch ex As Exception
    '            '---------------------------------------------------------
    '            'Error Handling and logging
    '            gobjErrorHandler.ErrorDescription = ex.Message
    '            gobjErrorHandler.ErrorMessage = ex.Message
    '            gobjErrorHandler.WriteErrorLog(ex)
    '            '---------------------------------------------------------
    '        Finally
    '            '---------------------------------------------------------
    '            'Writing Execution log
    '            If CONST_CREATE_EXECUTION_LOG = 1 Then
    '                gobjErrorHandler.WriteExecutionLog()
    '            End If
    '            '---------------------------------------------------------
    '        End Try
    '    End Sub

    '    Public Sub HideProgressBar()
    '        '=====================================================================
    '        ' Procedure Name        : HideProgressBar
    '        ' Parameters Passed     : None
    '        ' Returns               : None
    '        ' Purpose               : to finish the progress bar
    '        ' Description           : 
    '        ' Assumptions           : 
    '        ' Dependencies          : 
    '        ' Author                : Deepak Bhati
    '        ' Created               : Sunday, January 23, 2005
    '        ' Revisions             : 
    '        '=====================================================================
    '        Try
    '            'this sleep code is only eye candy but note that we must set m_ProgressBar.Value = 100
    '            'so that BackGroundIncrementProgressBar() can die
    '            Dim i As Integer
    '            For i = 0 To 16
    '                Thread.Sleep(30)
    '                Application.DoEvents()

    '                'show 100% for a glance
    '                If i = 15 Then ProgressPanel.Value = 100
    '            Next
    '            ProgressPanel.Value = 0
    '            ProgressPanel.Text = Application.ProductName & Space(1) & Application.ProductVersion

    '        Catch ex As Exception
    '            '---------------------------------------------------------
    '            'Error Handling and logging
    '            gobjErrorHandler.ErrorDescription = ex.Message
    '            gobjErrorHandler.ErrorMessage = ex.Message
    '            gobjErrorHandler.WriteErrorLog(ex)
    '            '---------------------------------------------------------
    '        Finally
    '            '---------------------------------------------------------
    '            'Writing Execution log
    '            If CONST_CREATE_EXECUTION_LOG = 1 Then
    '                gobjErrorHandler.WriteExecutionLog()
    '            End If
    '            '---------------------------------------------------------
    '        End Try
    '    End Sub

    '    Public Sub ShowRunTimeInfo(ByVal message As String)
    '        '=====================================================================
    '        ' Procedure Name        : ShowProgressBar
    '        ' Parameters Passed     : message
    '        ' Returns               : None
    '        ' Purpose               : to show the progress bar
    '        ' Description           : 
    '        ' Assumptions           : 
    '        ' Dependencies          : 
    '        ' Author                : Deepak Bhati
    '        ' Created               : Saturday, January 22, 2005
    '        ' Revisions             : 
    '        '=====================================================================
    '        Try
    '            'ProgressPanel.Value = 20
    '            StatusBarPanelInfo.Text = message
    '            'start a new thread to increment the progressbar
    '            'Dim progressThread As New Thread(AddressOf BackGroundIncrementProgressBar)
    '            'progressThread.IsBackground = True
    '            'progressThread.Name = "Progress Bar"
    '            'progressThread.Start()

    '        Catch ex As Exception
    '            '---------------------------------------------------------
    '            'Error Handling and logging
    '            gobjErrorHandler.ErrorDescription = ex.Message
    '            gobjErrorHandler.ErrorMessage = ex.Message
    '            gobjErrorHandler.WriteErrorLog(ex)
    '            '---------------------------------------------------------
    '        Finally
    '            '---------------------------------------------------------
    '            'Writing Execution log
    '            If CONST_CREATE_EXECUTION_LOG = 1 Then
    '                gobjErrorHandler.WriteExecutionLog()
    '            End If
    '            '---------------------------------------------------------
    '        End Try
    '    End Sub

    '#End Region

    'Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim objfrmabout As New frmAboutUs
    '    objfrmabout.Show()
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
    '        'RemoveHandler mnuExtinguish.Click, AddressOf btnExtinguish_Click

    '        If Not gstructSettings.AppMode = EnumAppMode.DemoMode Then
    '            If Not IsNothing(gobjMain.mobjfrmAnalysis) Then gobjMain.mobjfrmAnalysis.tmrAspirationMsg.Enabled = False
    '            gobjMain.mobjController.Cancel()
    '            Application.DoEvents()
    '            Call gobjClsAAS203.funcIgnite(False)
    '        Else
    '            Call gobjMessageAdapter.ShowMessage("Flame Extinguished", "AUTO EXTINGUISH", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage)
    '            Application.DoEvents()
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
    '        If Not gstructSettings.AppMode = EnumAppMode.DemoMode Then
    '            If Not IsNothing(gobjMain.mobjfrmAnalysis) Then gobjMain.mobjfrmAnalysis.tmrAspirationMsg.Enabled = True
    '            gobjMain.mobjController.Start(gobjclsBgFlameStatus)
    '            Application.DoEvents()
    '        End If
    '        'AddHandler mnuExtinguish.Click, AddressOf btnExtinguish_Click
    '        '---------------------------------------------------------
    '    End Try
    'End Sub

    'Private Sub btnIgnite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
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

    '        If Not gstructSettings.AppMode = EnumAppMode.DemoMode Then
    '            If Not IsNothing(gobjMain.mobjfrmAnalysis) Then gobjMain.mobjfrmAnalysis.tmrAspirationMsg.Enabled = False
    '            Call gobjMain.mobjController.Cancel()
    '            Call Application.DoEvents()
    '            Call gobjCommProtocol.mobjCommdll.subTime_Delay(100)
    '            Call gobjClsAAS203.funcIgnite(True)

    '        Else
    '            Call gobjMessageAdapter.ShowMessage("Flame Ignited", "AUTO IGNITION", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage)
    '            Call Application.DoEvents()
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
    '        If Not gstructSettings.AppMode = EnumAppMode.DemoMode Then
    '            If Not IsNothing(gobjMain.mobjfrmAnalysis) Then gobjMain.mobjfrmAnalysis.tmrAspirationMsg.Enabled = True
    '            gobjMain.mobjController.Start(gobjclsBgFlameStatus)
    '            Application.DoEvents()
    '        End If
    '        'AddHandler mnuIgnite.Click, AddressOf btnAutoIgnition_Click
    '        '---------------------------------------------------------
    '    End Try
    'End Sub
#End Region

    
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        gobjClsAAS203.funcLoadLastOptimizedConditions(True)

    End Sub
End Class
