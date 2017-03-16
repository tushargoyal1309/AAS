Imports AAS203.Common
Imports AAS203Library.Method
Imports AAS203Library.Instrument
''this will include a supporting files like header file.
Public Class frmTurret '' class behind the Turrert form
    Inherits System.Windows.Forms.Form
    Public m_TurretValue As Integer


#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    Public Sub New(ByVal intValue As Integer)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
        m_TurretValue = intValue
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
    Friend WithEvents CustomPanel1 As GradientPanel.CustomPanel
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage6 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage7 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage8 As System.Windows.Forms.TabPage
    Friend WithEvents btnCancel As NETXP.Controls.XPButton
    Friend WithEvents CustomPanel2 As GradientPanel.CustomPanel
    Friend WithEvents cmbTurretPosition As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents rbOFF As System.Windows.Forms.RadioButton
    Friend WithEvents rbON As System.Windows.Forms.RadioButton
    Friend WithEvents lblD2CurrentStatus As System.Windows.Forms.Label
    Friend WithEvents txtD2CurrentValue As System.Windows.Forms.TextBox
    Friend WithEvents lblD2CurrentValue As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents btnTurretPosition As NETXP.Controls.XPButton
    Friend WithEvents btnTurretHome As NETXP.Controls.XPButton
    Friend WithEvents btnD2Current As NETXP.Controls.XPButton
    Friend WithEvents btnD2ONOFF As NETXP.Controls.XPButton
    Friend WithEvents btnAllLampOFF As NETXP.Controls.XPButton
    Friend WithEvents lblHCLCurrent As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblAt As System.Windows.Forms.Label
    Friend WithEvents btnHCLCurrent As NETXP.Controls.XPButton
    Friend WithEvents txtHCLTurretPosition As System.Windows.Forms.TextBox
    Friend WithEvents txtHCLCurrent As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents mnuAutoIgnition As NETXP.Controls.Bars.CommandBar
    Friend WithEvents mnuIgnite As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuExtinguish As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents PanelTurret As System.Windows.Forms.Panel
    Friend WithEvents txtTurretPosition As System.Windows.Forms.TextBox
    Friend WithEvents nudTurretMotor As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblTurretMotor As System.Windows.Forms.Label
    Friend WithEvents txtTurretHome As System.Windows.Forms.TextBox
    Friend WithEvents lblTurretPosition As System.Windows.Forms.Label
    Friend WithEvents lblTurretHome As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents grpStep As System.Windows.Forms.GroupBox
    Friend WithEvents rbFullStep As System.Windows.Forms.RadioButton
    Friend WithEvents rbHalfStep As System.Windows.Forms.RadioButton
    Friend WithEvents lblLampStatus As System.Windows.Forms.Label
    Friend WithEvents txtLampStatus As System.Windows.Forms.TextBox
    Friend WithEvents btnIgnite As NETXP.Controls.XPButton
    Friend WithEvents btnN2OIgnite As NETXP.Controls.XPButton
    Friend WithEvents btnExtinguish As NETXP.Controls.XPButton
    Friend WithEvents btnDelete As NETXP.Controls.XPButton
    Friend WithEvents btnR As NETXP.Controls.XPButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmTurret))
        Me.CustomPanel1 = New GradientPanel.CustomPanel
        Me.CustomPanel2 = New GradientPanel.CustomPanel
        Me.PanelTurret = New System.Windows.Forms.Panel
        Me.grpStep = New System.Windows.Forms.GroupBox
        Me.rbFullStep = New System.Windows.Forms.RadioButton
        Me.rbHalfStep = New System.Windows.Forms.RadioButton
        Me.lblLampStatus = New System.Windows.Forms.Label
        Me.txtLampStatus = New System.Windows.Forms.TextBox
        Me.txtTurretPosition = New System.Windows.Forms.TextBox
        Me.nudTurretMotor = New System.Windows.Forms.NumericUpDown
        Me.lblTurretMotor = New System.Windows.Forms.Label
        Me.txtTurretHome = New System.Windows.Forms.TextBox
        Me.lblTurretPosition = New System.Windows.Forms.Label
        Me.lblTurretHome = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.mnuAutoIgnition = New NETXP.Controls.Bars.CommandBar
        Me.mnuIgnite = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuExtinguish = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.txtHCLTurretPosition = New System.Windows.Forms.TextBox
        Me.txtHCLCurrent = New System.Windows.Forms.TextBox
        Me.btnHCLCurrent = New NETXP.Controls.XPButton
        Me.lblAt = New System.Windows.Forms.Label
        Me.lblHCLCurrent = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnAllLampOFF = New NETXP.Controls.XPButton
        Me.btnD2Current = New NETXP.Controls.XPButton
        Me.btnD2ONOFF = New NETXP.Controls.XPButton
        Me.btnTurretPosition = New NETXP.Controls.XPButton
        Me.btnTurretHome = New NETXP.Controls.XPButton
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.rbOFF = New System.Windows.Forms.RadioButton
        Me.rbON = New System.Windows.Forms.RadioButton
        Me.lblD2CurrentStatus = New System.Windows.Forms.Label
        Me.txtD2CurrentValue = New System.Windows.Forms.TextBox
        Me.lblD2CurrentValue = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmbTurretPosition = New System.Windows.Forms.ComboBox
        Me.btnCancel = New NETXP.Controls.XPButton
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage5 = New System.Windows.Forms.TabPage
        Me.TabPage6 = New System.Windows.Forms.TabPage
        Me.TabPage8 = New System.Windows.Forms.TabPage
        Me.TabPage7 = New System.Windows.Forms.TabPage
        Me.btnIgnite = New NETXP.Controls.XPButton
        Me.btnExtinguish = New NETXP.Controls.XPButton
        Me.btnDelete = New NETXP.Controls.XPButton
        Me.btnR = New NETXP.Controls.XPButton
        Me.btnN2OIgnite = New NETXP.Controls.XPButton
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.TabPage4 = New System.Windows.Forms.TabPage
        Me.CustomPanel1.SuspendLayout()
        Me.CustomPanel2.SuspendLayout()
        Me.PanelTurret.SuspendLayout()
        Me.grpStep.SuspendLayout()
        CType(Me.nudTurretMotor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.mnuAutoIgnition, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'CustomPanel1
        '
        Me.CustomPanel1.BackColor = System.Drawing.SystemColors.Control
        Me.CustomPanel1.Controls.Add(Me.CustomPanel2)
        Me.CustomPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CustomPanel1.Location = New System.Drawing.Point(0, 0)
        Me.CustomPanel1.Name = "CustomPanel1"
        Me.CustomPanel1.Size = New System.Drawing.Size(466, 383)
        Me.CustomPanel1.TabIndex = 0
        '
        'CustomPanel2
        '
        Me.CustomPanel2.BackColor = System.Drawing.Color.AliceBlue
        Me.CustomPanel2.Controls.Add(Me.PanelTurret)
        Me.CustomPanel2.Controls.Add(Me.Panel1)
        Me.CustomPanel2.Controls.Add(Me.txtHCLTurretPosition)
        Me.CustomPanel2.Controls.Add(Me.txtHCLCurrent)
        Me.CustomPanel2.Controls.Add(Me.btnHCLCurrent)
        Me.CustomPanel2.Controls.Add(Me.lblAt)
        Me.CustomPanel2.Controls.Add(Me.lblHCLCurrent)
        Me.CustomPanel2.Controls.Add(Me.Label1)
        Me.CustomPanel2.Controls.Add(Me.btnAllLampOFF)
        Me.CustomPanel2.Controls.Add(Me.btnD2Current)
        Me.CustomPanel2.Controls.Add(Me.btnD2ONOFF)
        Me.CustomPanel2.Controls.Add(Me.btnTurretPosition)
        Me.CustomPanel2.Controls.Add(Me.btnTurretHome)
        Me.CustomPanel2.Controls.Add(Me.Button1)
        Me.CustomPanel2.Controls.Add(Me.Label5)
        Me.CustomPanel2.Controls.Add(Me.Label2)
        Me.CustomPanel2.Controls.Add(Me.rbOFF)
        Me.CustomPanel2.Controls.Add(Me.rbON)
        Me.CustomPanel2.Controls.Add(Me.lblD2CurrentStatus)
        Me.CustomPanel2.Controls.Add(Me.txtD2CurrentValue)
        Me.CustomPanel2.Controls.Add(Me.lblD2CurrentValue)
        Me.CustomPanel2.Controls.Add(Me.Label4)
        Me.CustomPanel2.Controls.Add(Me.cmbTurretPosition)
        Me.CustomPanel2.Controls.Add(Me.btnCancel)
        Me.CustomPanel2.Controls.Add(Me.TabControl1)
        Me.CustomPanel2.Controls.Add(Me.btnIgnite)
        Me.CustomPanel2.Controls.Add(Me.btnExtinguish)
        Me.CustomPanel2.Controls.Add(Me.btnDelete)
        Me.CustomPanel2.Controls.Add(Me.btnR)
        Me.CustomPanel2.Controls.Add(Me.btnN2OIgnite)
        Me.CustomPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CustomPanel2.Location = New System.Drawing.Point(0, 0)
        Me.CustomPanel2.Name = "CustomPanel2"
        Me.CustomPanel2.Size = New System.Drawing.Size(466, 383)
        Me.CustomPanel2.TabIndex = 0
        '
        'PanelTurret
        '
        Me.PanelTurret.Controls.Add(Me.grpStep)
        Me.PanelTurret.Controls.Add(Me.lblLampStatus)
        Me.PanelTurret.Controls.Add(Me.txtLampStatus)
        Me.PanelTurret.Controls.Add(Me.txtTurretPosition)
        Me.PanelTurret.Controls.Add(Me.nudTurretMotor)
        Me.PanelTurret.Controls.Add(Me.lblTurretMotor)
        Me.PanelTurret.Controls.Add(Me.txtTurretHome)
        Me.PanelTurret.Controls.Add(Me.lblTurretPosition)
        Me.PanelTurret.Controls.Add(Me.lblTurretHome)
        Me.PanelTurret.Controls.Add(Me.Label3)
        Me.PanelTurret.Location = New System.Drawing.Point(8, 8)
        Me.PanelTurret.Name = "PanelTurret"
        Me.PanelTurret.Size = New System.Drawing.Size(208, 192)
        Me.PanelTurret.TabIndex = 87
        '
        'grpStep
        '
        Me.grpStep.Controls.Add(Me.rbFullStep)
        Me.grpStep.Controls.Add(Me.rbHalfStep)
        Me.grpStep.Location = New System.Drawing.Point(4, 147)
        Me.grpStep.Name = "grpStep"
        Me.grpStep.Size = New System.Drawing.Size(200, 40)
        Me.grpStep.TabIndex = 92
        Me.grpStep.TabStop = False
        '
        'rbFullStep
        '
        Me.rbFullStep.BackColor = System.Drawing.Color.Transparent
        Me.rbFullStep.Enabled = False
        Me.rbFullStep.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbFullStep.Location = New System.Drawing.Point(103, 10)
        Me.rbFullStep.Name = "rbFullStep"
        Me.rbFullStep.Size = New System.Drawing.Size(80, 24)
        Me.rbFullStep.TabIndex = 61
        Me.rbFullStep.Text = "Full Step"
        '
        'rbHalfStep
        '
        Me.rbHalfStep.Checked = True
        Me.rbHalfStep.Enabled = False
        Me.rbHalfStep.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbHalfStep.ForeColor = System.Drawing.Color.Black
        Me.rbHalfStep.Location = New System.Drawing.Point(18, 10)
        Me.rbHalfStep.Name = "rbHalfStep"
        Me.rbHalfStep.Size = New System.Drawing.Size(85, 24)
        Me.rbHalfStep.TabIndex = 60
        Me.rbHalfStep.TabStop = True
        Me.rbHalfStep.Text = "Half Step"
        '
        'lblLampStatus
        '
        Me.lblLampStatus.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLampStatus.Location = New System.Drawing.Point(20, 128)
        Me.lblLampStatus.Name = "lblLampStatus"
        Me.lblLampStatus.Size = New System.Drawing.Size(80, 20)
        Me.lblLampStatus.TabIndex = 91
        Me.lblLampStatus.Text = "Lamp Status"
        '
        'txtLampStatus
        '
        Me.txtLampStatus.BackColor = System.Drawing.Color.White
        Me.txtLampStatus.Enabled = False
        Me.txtLampStatus.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLampStatus.Location = New System.Drawing.Point(148, 123)
        Me.txtLampStatus.Name = "txtLampStatus"
        Me.txtLampStatus.ReadOnly = True
        Me.txtLampStatus.Size = New System.Drawing.Size(40, 22)
        Me.txtLampStatus.TabIndex = 90
        Me.txtLampStatus.Text = ""
        Me.txtLampStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtTurretPosition
        '
        Me.txtTurretPosition.BackColor = System.Drawing.Color.White
        Me.txtTurretPosition.Enabled = False
        Me.txtTurretPosition.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTurretPosition.ForeColor = System.Drawing.Color.Black
        Me.txtTurretPosition.Location = New System.Drawing.Point(127, 50)
        Me.txtTurretPosition.Name = "txtTurretPosition"
        Me.txtTurretPosition.ReadOnly = True
        Me.txtTurretPosition.Size = New System.Drawing.Size(64, 22)
        Me.txtTurretPosition.TabIndex = 89
        Me.txtTurretPosition.Text = ""
        Me.txtTurretPosition.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'nudTurretMotor
        '
        Me.nudTurretMotor.Enabled = False
        Me.nudTurretMotor.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nudTurretMotor.Location = New System.Drawing.Point(127, 79)
        Me.nudTurretMotor.Name = "nudTurretMotor"
        Me.nudTurretMotor.Size = New System.Drawing.Size(64, 22)
        Me.nudTurretMotor.TabIndex = 87
        Me.nudTurretMotor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTurretMotor
        '
        Me.lblTurretMotor.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTurretMotor.Location = New System.Drawing.Point(15, 82)
        Me.lblTurretMotor.Name = "lblTurretMotor"
        Me.lblTurretMotor.Size = New System.Drawing.Size(88, 18)
        Me.lblTurretMotor.TabIndex = 86
        Me.lblTurretMotor.Text = "Turret Motor"
        Me.lblTurretMotor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTurretHome
        '
        Me.txtTurretHome.BackColor = System.Drawing.Color.White
        Me.txtTurretHome.Enabled = False
        Me.txtTurretHome.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTurretHome.ForeColor = System.Drawing.Color.Black
        Me.txtTurretHome.Location = New System.Drawing.Point(127, 19)
        Me.txtTurretHome.Name = "txtTurretHome"
        Me.txtTurretHome.ReadOnly = True
        Me.txtTurretHome.Size = New System.Drawing.Size(64, 21)
        Me.txtTurretHome.TabIndex = 85
        Me.txtTurretHome.Text = ""
        Me.txtTurretHome.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblTurretPosition
        '
        Me.lblTurretPosition.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTurretPosition.Location = New System.Drawing.Point(15, 52)
        Me.lblTurretPosition.Name = "lblTurretPosition"
        Me.lblTurretPosition.Size = New System.Drawing.Size(96, 18)
        Me.lblTurretPosition.TabIndex = 84
        Me.lblTurretPosition.Text = "Turret Position"
        Me.lblTurretPosition.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTurretHome
        '
        Me.lblTurretHome.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTurretHome.Location = New System.Drawing.Point(15, 22)
        Me.lblTurretHome.Name = "lblTurretHome"
        Me.lblTurretHome.Size = New System.Drawing.Size(80, 18)
        Me.lblTurretHome.TabIndex = 83
        Me.lblTurretHome.Text = "Turret Home"
        Me.lblTurretHome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(8, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(192, 104)
        Me.Label3.TabIndex = 88
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.mnuAutoIgnition)
        Me.Panel1.Location = New System.Drawing.Point(200, 376)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(216, 56)
        Me.Panel1.TabIndex = 86
        '
        'mnuAutoIgnition
        '
        Me.mnuAutoIgnition.BackColor = System.Drawing.Color.Transparent
        Me.mnuAutoIgnition.CustomizeText = "&Customize Toolbar..."
        Me.mnuAutoIgnition.FullRow = True
        Me.mnuAutoIgnition.ID = 5117
        Me.mnuAutoIgnition.Items.AddRange(New NETXP.Controls.Bars.CommandBarItem() {Me.mnuIgnite, Me.mnuExtinguish})
        Me.mnuAutoIgnition.Location = New System.Drawing.Point(66, 16)
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
        'txtHCLTurretPosition
        '
        Me.txtHCLTurretPosition.BackColor = System.Drawing.Color.White
        Me.txtHCLTurretPosition.Enabled = False
        Me.txtHCLTurretPosition.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHCLTurretPosition.ForeColor = System.Drawing.Color.Black
        Me.txtHCLTurretPosition.Location = New System.Drawing.Point(376, 112)
        Me.txtHCLTurretPosition.Name = "txtHCLTurretPosition"
        Me.txtHCLTurretPosition.Size = New System.Drawing.Size(64, 21)
        Me.txtHCLTurretPosition.TabIndex = 84
        Me.txtHCLTurretPosition.Text = ""
        Me.txtHCLTurretPosition.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtHCLCurrent
        '
        Me.txtHCLCurrent.BackColor = System.Drawing.Color.White
        Me.txtHCLCurrent.Enabled = False
        Me.txtHCLCurrent.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHCLCurrent.ForeColor = System.Drawing.Color.Black
        Me.txtHCLCurrent.Location = New System.Drawing.Point(376, 80)
        Me.txtHCLCurrent.Name = "txtHCLCurrent"
        Me.txtHCLCurrent.Size = New System.Drawing.Size(64, 21)
        Me.txtHCLCurrent.TabIndex = 83
        Me.txtHCLCurrent.Text = ""
        Me.txtHCLCurrent.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnHCLCurrent
        '
        Me.btnHCLCurrent.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnHCLCurrent.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnHCLCurrent.Image = CType(resources.GetObject("btnHCLCurrent.Image"), System.Drawing.Image)
        Me.btnHCLCurrent.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnHCLCurrent.Location = New System.Drawing.Point(305, 224)
        Me.btnHCLCurrent.Name = "btnHCLCurrent"
        Me.btnHCLCurrent.Size = New System.Drawing.Size(120, 34)
        Me.btnHCLCurrent.TabIndex = 3
        Me.btnHCLCurrent.Text = "&HCL Current"
        Me.btnHCLCurrent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAt
        '
        Me.lblAt.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAt.Location = New System.Drawing.Point(232, 115)
        Me.lblAt.Name = "lblAt"
        Me.lblAt.Size = New System.Drawing.Size(104, 18)
        Me.lblAt.TabIndex = 79
        Me.lblAt.Text = "At turret position"
        '
        'lblHCLCurrent
        '
        Me.lblHCLCurrent.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHCLCurrent.Location = New System.Drawing.Point(232, 80)
        Me.lblHCLCurrent.Name = "lblHCLCurrent"
        Me.lblHCLCurrent.Size = New System.Drawing.Size(80, 18)
        Me.lblHCLCurrent.TabIndex = 76
        Me.lblHCLCurrent.Text = "HCL Current"
        '
        'Label1
        '
        Me.Label1.Enabled = False
        Me.Label1.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label1.Location = New System.Drawing.Point(232, 96)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 16)
        Me.Label1.TabIndex = 78
        Me.Label1.Text = "(Range 0 - 25 mA)"
        '
        'btnAllLampOFF
        '
        Me.btnAllLampOFF.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAllLampOFF.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAllLampOFF.Image = CType(resources.GetObject("btnAllLampOFF.Image"), System.Drawing.Image)
        Me.btnAllLampOFF.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAllLampOFF.Location = New System.Drawing.Point(305, 267)
        Me.btnAllLampOFF.Name = "btnAllLampOFF"
        Me.btnAllLampOFF.Size = New System.Drawing.Size(120, 34)
        Me.btnAllLampOFF.TabIndex = 6
        Me.btnAllLampOFF.Text = "&All Lamp OFF"
        Me.btnAllLampOFF.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnD2Current
        '
        Me.btnD2Current.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnD2Current.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnD2Current.Image = CType(resources.GetObject("btnD2Current.Image"), System.Drawing.Image)
        Me.btnD2Current.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnD2Current.Location = New System.Drawing.Point(177, 224)
        Me.btnD2Current.Name = "btnD2Current"
        Me.btnD2Current.Size = New System.Drawing.Size(120, 34)
        Me.btnD2Current.TabIndex = 2
        Me.btnD2Current.Text = "D2 C&urrent"
        '
        'btnD2ONOFF
        '
        Me.btnD2ONOFF.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnD2ONOFF.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnD2ONOFF.Image = CType(resources.GetObject("btnD2ONOFF.Image"), System.Drawing.Image)
        Me.btnD2ONOFF.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnD2ONOFF.Location = New System.Drawing.Point(177, 267)
        Me.btnD2ONOFF.Name = "btnD2ONOFF"
        Me.btnD2ONOFF.Size = New System.Drawing.Size(120, 34)
        Me.btnD2ONOFF.TabIndex = 5
        Me.btnD2ONOFF.Text = "D2 &ON/OFF"
        '
        'btnTurretPosition
        '
        Me.btnTurretPosition.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTurretPosition.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTurretPosition.Image = CType(resources.GetObject("btnTurretPosition.Image"), System.Drawing.Image)
        Me.btnTurretPosition.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnTurretPosition.Location = New System.Drawing.Point(40, 267)
        Me.btnTurretPosition.Name = "btnTurretPosition"
        Me.btnTurretPosition.Size = New System.Drawing.Size(128, 34)
        Me.btnTurretPosition.TabIndex = 4
        Me.btnTurretPosition.Text = "Turret &Position"
        Me.btnTurretPosition.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnTurretHome
        '
        Me.btnTurretHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTurretHome.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTurretHome.Image = CType(resources.GetObject("btnTurretHome.Image"), System.Drawing.Image)
        Me.btnTurretHome.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnTurretHome.Location = New System.Drawing.Point(40, 224)
        Me.btnTurretHome.Name = "btnTurretHome"
        Me.btnTurretHome.Size = New System.Drawing.Size(128, 34)
        Me.btnTurretHome.TabIndex = 1
        Me.btnTurretHome.Text = "Turret &Home"
        Me.btnTurretHome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Button1
        '
        Me.Button1.Enabled = False
        Me.Button1.Location = New System.Drawing.Point(40, 208)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(392, 112)
        Me.Button1.TabIndex = 70
        '
        'Label5
        '
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Location = New System.Drawing.Point(31, 200)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(408, 128)
        Me.Label5.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.Enabled = False
        Me.Label2.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label2.Location = New System.Drawing.Point(232, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(120, 16)
        Me.Label2.TabIndex = 68
        Me.Label2.Text = "(Range 100 - 300 mA)"
        '
        'rbOFF
        '
        Me.rbOFF.Enabled = False
        Me.rbOFF.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbOFF.Location = New System.Drawing.Point(400, 54)
        Me.rbOFF.Name = "rbOFF"
        Me.rbOFF.Size = New System.Drawing.Size(48, 24)
        Me.rbOFF.TabIndex = 66
        Me.rbOFF.Text = "OFF"
        '
        'rbON
        '
        Me.rbON.BackColor = System.Drawing.Color.Transparent
        Me.rbON.Checked = True
        Me.rbON.Enabled = False
        Me.rbON.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbON.ForeColor = System.Drawing.Color.Black
        Me.rbON.Location = New System.Drawing.Point(356, 54)
        Me.rbON.Name = "rbON"
        Me.rbON.Size = New System.Drawing.Size(48, 24)
        Me.rbON.TabIndex = 65
        Me.rbON.TabStop = True
        Me.rbON.Text = "ON"
        '
        'lblD2CurrentStatus
        '
        Me.lblD2CurrentStatus.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblD2CurrentStatus.Location = New System.Drawing.Point(232, 56)
        Me.lblD2CurrentStatus.Name = "lblD2CurrentStatus"
        Me.lblD2CurrentStatus.Size = New System.Drawing.Size(128, 24)
        Me.lblD2CurrentStatus.TabIndex = 64
        Me.lblD2CurrentStatus.Text = "D2 Current (Status)"
        '
        'txtD2CurrentValue
        '
        Me.txtD2CurrentValue.BackColor = System.Drawing.Color.White
        Me.txtD2CurrentValue.Enabled = False
        Me.txtD2CurrentValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtD2CurrentValue.ForeColor = System.Drawing.Color.Black
        Me.txtD2CurrentValue.Location = New System.Drawing.Point(376, 24)
        Me.txtD2CurrentValue.Name = "txtD2CurrentValue"
        Me.txtD2CurrentValue.ReadOnly = True
        Me.txtD2CurrentValue.Size = New System.Drawing.Size(64, 21)
        Me.txtD2CurrentValue.TabIndex = 67
        Me.txtD2CurrentValue.Text = ""
        Me.txtD2CurrentValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblD2CurrentValue
        '
        Me.lblD2CurrentValue.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblD2CurrentValue.Location = New System.Drawing.Point(232, 27)
        Me.lblD2CurrentValue.Name = "lblD2CurrentValue"
        Me.lblD2CurrentValue.Size = New System.Drawing.Size(120, 16)
        Me.lblD2CurrentValue.TabIndex = 63
        Me.lblD2CurrentValue.Text = "D2 Current (Value)"
        '
        'Label4
        '
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Location = New System.Drawing.Point(224, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(232, 128)
        Me.Label4.TabIndex = 62
        '
        'cmbTurretPosition
        '
        Me.cmbTurretPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTurretPosition.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTurretPosition.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6"})
        Me.cmbTurretPosition.Location = New System.Drawing.Point(64, 352)
        Me.cmbTurretPosition.Name = "cmbTurretPosition"
        Me.cmbTurretPosition.Size = New System.Drawing.Size(64, 24)
        Me.cmbTurretPosition.Sorted = True
        Me.cmbTurretPosition.TabIndex = 0
        Me.cmbTurretPosition.Visible = False
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Image = CType(resources.GetObject("btnCancel.Image"), System.Drawing.Image)
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancel.Location = New System.Drawing.Point(191, 336)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(120, 32)
        Me.btnCancel.TabIndex = 7
        Me.btnCancel.Text = "C&LOSE"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage5)
        Me.TabControl1.Controls.Add(Me.TabPage6)
        Me.TabControl1.Controls.Add(Me.TabPage8)
        Me.TabControl1.Controls.Add(Me.TabPage7)
        Me.TabControl1.Location = New System.Drawing.Point(16, 336)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(40, 40)
        Me.TabControl1.TabIndex = 26
        Me.TabControl1.Visible = False
        '
        'TabPage5
        '
        Me.TabPage5.BackColor = System.Drawing.Color.AliceBlue
        Me.TabPage5.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage5.Location = New System.Drawing.Point(4, 24)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Size = New System.Drawing.Size(32, 12)
        Me.TabPage5.TabIndex = 0
        Me.TabPage5.Text = "Turret"
        '
        'TabPage6
        '
        Me.TabPage6.BackColor = System.Drawing.Color.AliceBlue
        Me.TabPage6.Location = New System.Drawing.Point(4, 24)
        Me.TabPage6.Name = "TabPage6"
        Me.TabPage6.Size = New System.Drawing.Size(32, 12)
        Me.TabPage6.TabIndex = 1
        Me.TabPage6.Text = "D2 Current"
        '
        'TabPage8
        '
        Me.TabPage8.BackColor = System.Drawing.Color.AliceBlue
        Me.TabPage8.Location = New System.Drawing.Point(4, 24)
        Me.TabPage8.Name = "TabPage8"
        Me.TabPage8.Size = New System.Drawing.Size(32, 12)
        Me.TabPage8.TabIndex = 3
        Me.TabPage8.Text = "Lamp"
        '
        'TabPage7
        '
        Me.TabPage7.BackColor = System.Drawing.Color.AliceBlue
        Me.TabPage7.Location = New System.Drawing.Point(4, 24)
        Me.TabPage7.Name = "TabPage7"
        Me.TabPage7.Size = New System.Drawing.Size(32, 12)
        Me.TabPage7.TabIndex = 2
        Me.TabPage7.Text = "HCL Current"
        '
        'btnIgnite
        '
        Me.btnIgnite.BackColor = System.Drawing.Color.Transparent
        Me.btnIgnite.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnIgnite.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIgnite.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnIgnite.Location = New System.Drawing.Point(360, 304)
        Me.btnIgnite.Name = "btnIgnite"
        Me.btnIgnite.Size = New System.Drawing.Size(8, 8)
        Me.btnIgnite.TabIndex = 88
        Me.btnIgnite.TabStop = False
        Me.btnIgnite.Text = "&Ignition"
        Me.btnIgnite.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'btnExtinguish
        '
        Me.btnExtinguish.BackColor = System.Drawing.Color.Transparent
        Me.btnExtinguish.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExtinguish.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExtinguish.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExtinguish.Location = New System.Drawing.Point(344, 304)
        Me.btnExtinguish.Name = "btnExtinguish"
        Me.btnExtinguish.Size = New System.Drawing.Size(8, 8)
        Me.btnExtinguish.TabIndex = 89
        Me.btnExtinguish.TabStop = False
        Me.btnExtinguish.Text = "&Extinguish"
        Me.btnExtinguish.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'btnDelete
        '
        Me.btnDelete.BackColor = System.Drawing.Color.Transparent
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelete.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDelete.Location = New System.Drawing.Point(384, 304)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(8, 8)
        Me.btnDelete.TabIndex = 92
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
        Me.btnR.Location = New System.Drawing.Point(400, 304)
        Me.btnR.Name = "btnR"
        Me.btnR.Size = New System.Drawing.Size(8, 8)
        Me.btnR.TabIndex = 91
        Me.btnR.TabStop = False
        Me.btnR.Text = "&R"
        Me.btnR.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'btnN2OIgnite
        '
        Me.btnN2OIgnite.BackColor = System.Drawing.Color.Transparent
        Me.btnN2OIgnite.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnN2OIgnite.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnN2OIgnite.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnN2OIgnite.Location = New System.Drawing.Point(376, 304)
        Me.btnN2OIgnite.Name = "btnN2OIgnite"
        Me.btnN2OIgnite.Size = New System.Drawing.Size(8, 8)
        Me.btnN2OIgnite.TabIndex = 90
        Me.btnN2OIgnite.TabStop = False
        Me.btnN2OIgnite.Text = "N2O&C"
        Me.btnN2OIgnite.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.AliceBlue
        Me.TabPage1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(304, 238)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Turret"
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.AliceBlue
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(304, 238)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "D2 Current"
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.Color.AliceBlue
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(304, 230)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "HCL Current"
        '
        'TabPage4
        '
        Me.TabPage4.BackColor = System.Drawing.Color.AliceBlue
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(304, 230)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Lamp"
        '
        'frmTurret
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(466, 383)
        Me.Controls.Add(Me.CustomPanel1)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTurret"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Turret"
        Me.CustomPanel1.ResumeLayout(False)
        Me.CustomPanel2.ResumeLayout(False)
        Me.PanelTurret.ResumeLayout(False)
        Me.grpStep.ResumeLayout(False)
        CType(Me.nudTurretMotor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.mnuAutoIgnition, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Variables"
    Private WithEvents mobjfrmEditValues As New frmEditValues
    Private mintValue As Double
    Private mintValue1 As Integer
    Public Flag As Integer = 0
    Private mblnInProcess As Boolean = False
    'Private mblnCheckButton As Boolean = False
#End Region

#Region "Constants"
    Private Const ConstTurretPosition = "Enter Turret No. #"
    Private Const ConstD2Current = "Enter D2Current(100 - 300mA)"
    Private Const ConstHCLCurrent = "HCL Current(0 - 25mA)"
    Private Const ConstHCLPosition = "For Turret Position #"
#End Region

#Region "Properties"
    ''basic property which can be set by user 
    Private Property InputValue() As Double
        Get
            Return mintValue
        End Get
        Set(ByVal Value As Double)
            mintValue = Value
        End Set
    End Property

    Private Property InputValue1() As Integer
        Get
            Return mintValue1
        End Get
        Set(ByVal Value1 As Integer)
            mintValue1 = Value1
        End Set
    End Property
#End Region

#Region "Form Events"

    Private Sub frmTurret_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '=====================================================================
        ' Procedure Name        : frmTurret_Load
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To initialize the form
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 21.11.06
        ' Revisions             : 
        '=====================================================================
        ''note:
        ''this will called when form is loaded
        ''do some intialization here 
        ''intialization must be done as par application mode
        ''eg 203/201



        Dim objWait As New CWaitCursor
        Try
            Call AddHandlers()
            ''this will add all the event handler
            rbOFF.Checked = True
            rbHalfStep.Checked = True
            btnTurretHome.Focus()
            If (gstructSettings.AppMode = EnumAppMode.FullVersion_201) Then
                ''for 201
                btnTurretHome.Visible = False
                btnTurretPosition.Visible = False
                PanelTurret.Visible = False
                lblAt.Text = "At Position"

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

#Region "Private Functions"

    Private Sub AddHandlers()
        '=====================================================================
        ' Procedure Name        : SubAddHandlers
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : To add handlers
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 21.11.06
        ' Revisions             : 
        '=====================================================================
        ''note:
        ''this will called when the form is intialise
        ''ot os used for add all the event handler
        Try
            'AddHandler btnOk.Click, AddressOf btnOk_Click
            AddHandler btnCancel.Click, AddressOf btnCancel_Click
            AddHandler btnTurretHome.Click, AddressOf btnTurretHome_Click
            AddHandler btnTurretPosition.Click, AddressOf btnTurretPosition_Click
            AddHandler btnAllLampOFF.Click, AddressOf btnAllLampOFF_Click
            AddHandler btnHCLCurrent.Click, AddressOf btnHCLCurrent_Click
            AddHandler btnD2Current.Click, AddressOf btnD2Current_Click
            AddHandler btnD2ONOFF.Click, AddressOf btnD2ONOFF_Click
            'AddHandler mnuExtinguish.Click, AddressOf btnExtinguish_Click
            'AddHandler mnuIgnite.Click, AddressOf btnAutoIgnition_Click
            AddHandler btnExtinguish.Click, AddressOf btnExtinguish_Click
            AddHandler btnIgnite.Click, AddressOf btnAutoIgnition_Click
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

    Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : btnCancel_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To send dialog result as cancel
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 21.11.06
        ' Revisions             : 
        '=====================================================================

        ''note:
        ''this is called when user click on cancel button
        Dim objWait As New CWaitCursor
        Try
            Me.DialogResult = DialogResult.Cancel
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
            objWait.Dispose()
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub btnOk_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : btnOk_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To return to the main screen
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 21.11.06
        ' Revisions             : 
        '=====================================================================
        ''this is called when user click on OK button
        Dim objWait As New CWaitCursor
        Try
            Me.DialogResult = DialogResult.OK
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
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

    Private Sub btnTurretHome_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : btnTurretHome_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To make the Turret indicater home
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 21.11.06
        ' Revisions             : 
        '=====================================================================
        ''note:
        ''this is called when user click on TurrertHome button
        ''this is used for shifting a turrert at home position
        ''for this we used EnumAAS203Protocol.TURHOME protocol

        '------------------------------------------------------------------------------------
        '        BOOL	S4FUNC Find_Turret_Home(HWND hwnd)
        '{
        'BOOL	flag=FALSE;
        'unsigned  oldTout;

        ' if (GetInstrument()==AA202)
        '	return TRUE;

        ' oldTout=Tout;
        ' Tout=LONG_DEALY;
        ' hold = Load_Curs();
        ' Transmit(TARHOME, 0,0 , 0);
        '    If (Recev(True)) Then
        '	 flag=(BOOL)Param1;
        ' SetCursor(hold);
        ' Tout=oldTout;
        ' if (flag) {
        '	Inst.Lamp_old = Inst.Lamp_pos = 0;
        '	flag =Position_Turret(hwnd,1, TRUE);
        '  }
        ' else {
        '	 Gerror_message(" Turret controller error \n Check Turret connections");
        '	 Inst.Lamp_old = -1;
        '	}
        ' return flag;
        '}
        '------------------------------------------------------------------------------------

        Dim objWait As New CWaitCursor
        Try
            'If gobjMessageAdapter.ShowMessage(constTurretHome) = True Then
            'Application.DoEvents()

            'txtTurretHome.Enabled = False
            If mblnInProcess = True Then
                ''avoid process if any other process is runnig
                Exit Sub
            End If
            mblnInProcess = True

            If gobjClsAAS203.funcbtnTurretHome() = True Then
                ''function for setting turrert at home position 
                ''by sending protocol
                txtTurretHome.Text = "OK"
                txtTurretPosition.Text = "1"
                'gobjMessageAdapter.ShowMessage(constCongratsTurretHome)
                'Application.DoEvents()
            Else
                ''show the error message 
                gobjMessageAdapter.ShowMessage(constErrorPosnTurretHome)
            End If
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
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            mblnInProcess = False
            'txtTurretHome.Enabled = True
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub btnTurretPosition_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : btnTurretPosition_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To position the Turret at said position from current position 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 21.11.06
        ' Revisions             : 
        '=====================================================================

        ''note:
        ''this is called when user click on turrert position button
        ''this is used To position the Turret at said position from current position 

        ''step 1:first display a dialog box . where user can input the posotion to be changed
        ''step 2:validate the value enterd by user
        ''step 3:store the input in a temp variable
        ''step 4:send the value to instrument by using serial communication function
        ''step 5:store the current position in a glibal object to later used.




        Dim objWait As New CWaitCursor
        Dim intTurretPosition As Integer
        Dim strMessage As String
        Dim strMessage1 As String
        Try
            'btnTurretPosition.Enabled = False
            If mblnInProcess = True Then
                Exit Sub
            End If
            mblnInProcess = True
            mobjfrmEditValues.LabelText = ConstTurretPosition
            mobjfrmEditValues.txtValue.Visible = True
            mobjfrmEditValues.txtValue.ValidationType = NumberValidator.NumberValidator.Validations.IntegerOnly
            mobjfrmEditValues.txtValue.RangeValidation = True
            mobjfrmEditValues.txtValue.MaxLength = 1
            mobjfrmEditValues.txtValue.MinimumRange = 1
            mobjfrmEditValues.txtValue.MaximumRange = 6
            mobjfrmEditValues.txtValue.SelectAll()
            mobjfrmEditValues.txtValue.Text = gobjInst.Lamp_Position
            If mobjfrmEditValues.ShowDialog = DialogResult.Cancel Then
                Exit Sub
            End If
            Application.DoEvents()
            If InputValue < 1 Or InputValue > 6 Then
                gobjMessageAdapter.ShowMessage(constEnterTurretNo)
                Exit Sub
            End If
            intTurretPosition = CInt(InputValue)
            If intTurretPosition = 1 Then
                Application.DoEvents()
                If gobjClsAAS203.funcbtnTurretHome() = True Then
                    txtTurretHome.Text = "OK"
                    txtTurretPosition.Text = "1"
                    Application.DoEvents()
                End If

            Else
                Application.DoEvents()
                txtTurretHome.Text = ""
                txtTurretPosition.Text = ""
                If gobjClsAAS203.funcbtnTurretPosition(intTurretPosition) = True Then
                    Application.DoEvents()
                    txtTurretPosition.Text = CInt(intTurretPosition)
                Else
                    gobjMessageAdapter.MessageTextAlignment = ContentAlignment.MiddleLeft
                    gobjMessageAdapter.ShowMessage(constCommError)
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
            mblnInProcess = False
            'btnTurretPosition.Enabled = True
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub btnAllLampOFF_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : btnAllLampOFF_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To set all lamps to off position
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh s
        ' Created               : 21.11.06
        ' Revisions             : 
        '=====================================================================

        ''not:
        ''this is called when user clicked  on all lamp OFF button
        ''for this we are sending EnumAAS203Protocol.HCLOFF protocol


        Dim objWait As New CWaitCursor
        Try
            'If gobjMessageAdapter.ShowMessage(constOFFAllLamps) = True Then
            'Application.DoEvents()
            'btnAllLampOFF.Enabled = False
            If mblnInProcess = True Then
                Exit Sub
            End If
            mblnInProcess = True
            If gobjClsAAS203.funcbtnAllLampOFF() = True Then
                ''function for sending a protocol ofr All lamp off

                txtLampStatus.Text = "OFF"
                txtHCLCurrent.Text = "0"
                'gobjMessageAdapter.ShowMessage(constCongratsOFFAllLamps)
                'Application.DoEvents()
            Else
                gobjMessageAdapter.MessageTextAlignment = ContentAlignment.MiddleLeft
                gobjMessageAdapter.ShowMessage(constCommError)
            End If
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
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            mblnInProcess = False
            'btnAllLampOFF.Enabled = True
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub btnHCLCurrent_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name         :   btnHCLCurrent_Click
        'Description            :   To set current to the lamp
        'Parameters             :   dblLampCur = current to be set to lamp
        '                           intLampPos = lamp position to which current to be set
        'Time/Date              :   21/11/06
        'Dependencies           :   
        'Author                 :   Saurabh S.
        'Revision               :
        'Revision by Person     :
        '--------------------------------------------------------------------------------------


        ''note:
        ''this is called when user clicked on HCL current button
        ''this is used to off a HCL current at given position
        ''by sending a EnumAAS203Protocol.HCLCUR protocol
        ''step 1:show a edit dialog for accepting a value from user
        ''step 2:validate that input enter by user
        ''step 3:store it in a temp variable
        ''step 4:send it to instrument
        ''for putting lamp off at given position


        Dim objWait As New CWaitCursor
        Dim dblCurrent As Double
        Dim intTurret As Integer
        Dim strMessage As String
        Dim strMessage1 As String
        Try
            'btnHCLCurrent.Enabled = False
            If mblnInProcess = True Then
                Exit Sub
            End If
            mblnInProcess = True
            txtLampStatus.Text = ""

            mobjfrmEditValues.Size = New Size(384, 104)
            mobjfrmEditValues.LabelText = ConstHCLCurrent
            mobjfrmEditValues.txtValue.Visible = True
            mobjfrmEditValues.txtValue.ValidationType = NumberValidator.NumberValidator.Validations.DoubleOnly
            mobjfrmEditValues.txtValue.RangeValidation = True
            mobjfrmEditValues.txtValue.DigitsAfterDecimalPoint = 1
            mobjfrmEditValues.txtValue.MaxLength = 4
            mobjfrmEditValues.txtValue.MinimumRange = 0
            mobjfrmEditValues.txtValue.MaximumRange = 25
            mobjfrmEditValues.txtValue.SelectAll()
            mobjfrmEditValues.txtValue.Focus()
            mobjfrmEditValues.txtValue.Text = "3"

            mobjfrmEditValues.txtValue1.Visible = True
            mobjfrmEditValues.txtValue1.ValidationType = NumberValidator.NumberValidator.Validations.IntegerOnly
            mobjfrmEditValues.lblText1.Visible = True
            mobjfrmEditValues.lblText1.Text = "for Turret no. #"
            mobjfrmEditValues.txtValue1.Text = gobjInst.Lamp_Position
            mobjfrmEditValues.CustomPanelHide.SendToBack()
            If mobjfrmEditValues.ShowDialog = DialogResult.Cancel Then
                mobjfrmEditValues.txtValue1.Visible = False
                mobjfrmEditValues.lblText1.Visible = False
                mobjfrmEditValues.CustomPanelHide.BringToFront()
                Exit Sub
            End If
            Application.DoEvents()
            mobjfrmEditValues.txtValue1.Visible = False
            mobjfrmEditValues.lblText1.Visible = False
            mobjfrmEditValues.CustomPanelHide.BringToFront()
            If InputValue < 0 Or InputValue > 25 Then
                gobjMessageAdapter.ShowMessage(constHCLcurrentRange)
                Exit Sub
            ElseIf InputValue1 < 1 Or InputValue1 > 6 Then
                gobjMessageAdapter.ShowMessage(constEnterTurretNo)
                Exit Sub
            End If
            dblCurrent = CDbl(InputValue)
            intTurret = CInt(InputValue1)
            Application.DoEvents()
            If gobjClsAAS203.funcbtnHCLCurrent(dblCurrent, intTurret) = True Then
                ''function for lamp
                ''here dblcurrent is value of current and intTurret is turret position
                Application.DoEvents()
                txtHCLCurrent.Text = CDbl(dblCurrent)
                txtHCLTurretPosition.Text = CInt(intTurret)
            Else
                gobjMessageAdapter.MessageTextAlignment = ContentAlignment.MiddleLeft
                gobjMessageAdapter.ShowMessage(constCommError)
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
            mblnInProcess = False
            'btnHCLCurrent.Enabled = True
            '---------------------------------------------------------
        End Try

    End Sub

    Private Sub btnD2Current_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name         :   btnD2Current_Click
        'Description            :   To set the D2 current 
        'Parameters             :   dblLampCur = current to be set to lamp
        'Time/Date              :   04/12/06
        'Dependencies           :   
        'Author                 :   Saurabh S.
        'Revision               :
        'Revision by Person     :
        '--------------------------------------------------------------------------------------
        ''note:
        ''this is called when user clicked on D2 Current button
        ''step 1:show a dialog for accepting a D2 current value from user
        ''step 2:validate that input value
        ''step 3:send it to instrument and store it in a global variable as well

        Dim objWait As New CWaitCursor
        Dim dblD2Cur As Double
        Try
            'btnD2Current.Enabled = False
            If mblnInProcess = True Then
                Exit Sub
            End If
            mblnInProcess = True
            mobjfrmEditValues.LabelText = ConstD2Current
            mobjfrmEditValues.txtValue.Visible = True
            mobjfrmEditValues.txtValue.ValidationType = NumberValidator.NumberValidator.Validations.IntegerOnly
            mobjfrmEditValues.txtValue.RangeValidation = True
            mobjfrmEditValues.txtValue.MaxLength = 3
            mobjfrmEditValues.txtValue.MinimumRange = 100
            mobjfrmEditValues.txtValue.MaximumRange = 300
            mobjfrmEditValues.txtValue.SelectAll()
            mobjfrmEditValues.txtValue.Focus()
            mobjfrmEditValues.txtValue.Text = gobjInst.D2Current
            If mobjfrmEditValues.ShowDialog = DialogResult.Cancel Then
                Exit Sub
            End If
            Application.DoEvents()
            If InputValue < 100 Or InputValue > 300 Then
                gobjMessageAdapter.ShowMessage(constD2CurrentRange)
                Exit Sub
            End If
            dblD2Cur = CInt(InputValue)
            Application.DoEvents()
            If gobjClsAAS203.funcbtnD2Current(dblD2Cur) = True Then
                ''function for setting D2 current 
                Application.DoEvents()
                txtD2CurrentValue.Text = CDbl(dblD2Cur)
                rbON.Checked = True
            Else
                gobjMessageAdapter.MessageTextAlignment = ContentAlignment.MiddleLeft
                gobjMessageAdapter.ShowMessage(constCommError)
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
            mblnInProcess = False
            objWait.Dispose()
            'btnD2Current.Enabled = True
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub btnD2ONOFF_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : btnD2ONOFF_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To make the D2 current ON or OFF
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 04.12.06
        ' Revisions             : 
        '=====================================================================
        ''note:
        ''this is called when user clicked on D2 on/off button
        ''this is used to put D2 lamp on or off as par sending communication protocols



        Dim objWait As New CWaitCursor
        Dim Flag1 As Integer
        Try
            'btnD2ONOFF.Enabled = False
            If mblnInProcess = True Then
                Exit Sub
            End If
            mblnInProcess = True
            If rbOFF.Checked = True Then
                Flag = 0
            Else
                Flag = 1
            End If
            ''set a flag as par lamp current status
            If gobjClsAAS203.funcbtnD2ONOFF(Flag, Flag1) = True Then
                ''function for setting D2 lamp on or off.
                ''here we have pass the flag as par ON and OFF.
                If Flag1 = 1 Then
                    rbON.Checked = True
                Else
                    rbOFF.Checked = True
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
            mblnInProcess = False
            'btnD2ONOFF.Enabled = True
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub mobjfrmEditValues_ReturnValue(ByVal dblValue As Double, ByVal intValue1 As Integer) Handles mobjfrmEditValues.ReturnValue
        '=====================================================================
        ' Procedure Name        : mobjfrmEditValues_ReturnValue
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To get the values from form EditValues
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 04.12.06
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Try
            InputValue = dblValue
            InputValue1 = intValue1

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
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

    Private Sub btnAutoIgnition_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : btnAutoIgnition_Click
        ' Parameters Passed     : Object, EventArgs
        ' Returns               : None
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 18-Feb-2007 03:15 pm
        ' Revisions             : 1
        '=====================================================================
        ''note:
        ''this is called when user click on auto ignition ON
        ''this is used to ignite a flame


        Try
            RemoveHandler mnuIgnite.Click, AddressOf btnAutoIgnition_Click
            If mblnInProcess = True Then
                Exit Sub
            End If
            'If Not IsNothing(mobjfrmAnalysis) Then mobjfrmAnalysis.tmrAspirationMsg.Enabled = False
            ' mobjController.Cancel()
            Application.DoEvents()

            Call gobjClsAAS203.funcIgnite(True)
            ''here we are sending parameter true for ignite a flame
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            'If Not IsNothing(mobjfrmAnalysis) Then mobjfrmAnalysis.tmrAspirationMsg.Enabled = True
            'mobjController.Start(gobjclsBgFlameStatus)
            Application.DoEvents()
            AddHandler mnuIgnite.Click, AddressOf btnAutoIgnition_Click
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub btnExtinguish_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : btnExtinguish_Click
        ' Parameters Passed     : Object, EventArgs
        ' Returns               : None
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 18-Feb-2007 03:15 pm
        ' Revisions             : 1
        '=====================================================================
        ''note:
        ''this is used to put off the flame ignition
        Try
            RemoveHandler mnuExtinguish.Click, AddressOf btnExtinguish_Click
            If mblnInProcess = True Then
                Exit Sub
            End If
            'If Not IsNothing(mobjfrmAnalysis) Then mobjfrmAnalysis.tmrAspirationMsg.Enabled = False
            'mobjController.Cancel()
            Application.DoEvents()
            ''allow application to perfrom its panding work

            Call gobjClsAAS203.funcIgnite(False)
            ''here we pass false parameter for putting ignition off.

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            'If Not IsNothing(mobjfrmAnalysis) Then mobjfrmAnalysis.tmrAspirationMsg.Enabled = True
            'mobjController.Start(gobjclsBgFlameStatus)
            Application.DoEvents()
            AddHandler mnuExtinguish.Click, AddressOf btnExtinguish_Click
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

        Try
            If mblnInProcess = True Then
                Exit Sub
            End If
            mblnInProcess = True
            Application.DoEvents()
            'If Not gstructSettings.AppMode = EnumAppMode.DemoMode Then
            '    Call gobjCommProtocol.mobjCommdll.subTime_Delay(50)
            '    '---switch over to N2O flame
            '    Call gobjCommProtocol.funcSwitchOver()
            '    ''function for N2O ignition.
            'End If
            Call gobjMainService.N2OAutoIgnition()
            mblnInProcess = False

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
            mblnInProcess = False
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
            If mblnInProcess = True Then
                Exit Sub
            End If
            mblnInProcess = True
            Application.DoEvents()
            Call gobjMainService.funcAltDelete()
            mblnInProcess = False
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
            mblnInProcess = False
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
            If mblnInProcess = True Then
                Exit Sub
            End If
            mblnInProcess = True
            Application.DoEvents()
            Call gobjMainService.funcAltR()
            mblnInProcess = False
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
            mblnInProcess = False
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
