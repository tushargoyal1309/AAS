Imports AAS203.Common

Public Class frmMonochromatorDB
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
    Friend WithEvents btnOk As NETXP.Controls.XPButton
    Friend WithEvents CustomPanel1 As GradientPanel.CustomPanel
    Friend WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents label2 As System.Windows.Forms.Label
    Friend WithEvents label3 As System.Windows.Forms.Label
    Friend WithEvents label4 As System.Windows.Forms.Label
    Friend WithEvents label5 As System.Windows.Forms.Label
    Friend WithEvents textbox2 As System.Windows.Forms.TextBox
    Friend WithEvents textbox3 As System.Windows.Forms.TextBox
    Friend WithEvents textbox4 As System.Windows.Forms.TextBox
    Friend WithEvents textbox5 As System.Windows.Forms.TextBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents CustomPanel2 As GradientPanel.CustomPanel
    Friend WithEvents txtWvRepeats As System.Windows.Forms.TextBox
    Friend WithEvents txtWvPosition As System.Windows.Forms.TextBox
    Friend WithEvents lblWvHome As System.Windows.Forms.Label
    Friend WithEvents txtWvHome As System.Windows.Forms.TextBox
    Friend WithEvents lblWvRepeats As System.Windows.Forms.Label
    Friend WithEvents lblWvPosition As System.Windows.Forms.Label
    Friend WithEvents nudSlitWidth As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents btnSlitHome As NETXP.Controls.XPButton
    Friend WithEvents btnSlitWidth As NETXP.Controls.XPButton
    Friend WithEvents btnSlitContinious As NETXP.Controls.XPButton
    Friend WithEvents btnWvPosition As NETXP.Controls.XPButton
    Friend WithEvents btnWvRepeats As NETXP.Controls.XPButton
    Friend WithEvents btnWvHome As NETXP.Controls.XPButton
    Friend WithEvents lblWvRec As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents mnuAutoIgnition As NETXP.Controls.Bars.CommandBar
    Friend WithEvents mnuIgnite As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuExtinguish As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents txtSlitWidth As System.Windows.Forms.TextBox
    Friend WithEvents txtSlitHome As System.Windows.Forms.TextBox
    Friend WithEvents lblSlitHome As System.Windows.Forms.Label
    Friend WithEvents txtSlitRepeats As System.Windows.Forms.TextBox
    Friend WithEvents lblSlitRepeats As System.Windows.Forms.Label
    Friend WithEvents lblSlitWidth As System.Windows.Forms.Label
    Friend WithEvents btnExitSlitHome As NETXP.Controls.XPButton
    Friend WithEvents btnExitSlitWidth As NETXP.Controls.XPButton
    Friend WithEvents btnExitSlitContinious As NETXP.Controls.XPButton
    Friend WithEvents txtExitSlitWidth As System.Windows.Forms.TextBox
    Friend WithEvents txtExitSlitHome As System.Windows.Forms.TextBox
    Friend WithEvents lblExitSlitHome As System.Windows.Forms.Label
    Friend WithEvents txtExitSlitRepeats As System.Windows.Forms.TextBox
    Friend WithEvents lblExitSlitRepeats As System.Windows.Forms.Label
    Friend WithEvents lblExitSlitWidth As System.Windows.Forms.Label
    Friend WithEvents WVGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents EntrySlitGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents ExitSlitGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents btnIgnite As NETXP.Controls.XPButton
    Friend WithEvents btnN2OIgnite As NETXP.Controls.XPButton
    Friend WithEvents btnExtinguish As NETXP.Controls.XPButton
    Friend WithEvents btnDelete As NETXP.Controls.XPButton
    Friend WithEvents btnR As NETXP.Controls.XPButton

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMonochromatorDB))
        Me.CustomPanel1 = New GradientPanel.CustomPanel
        Me.CustomPanel2 = New GradientPanel.CustomPanel
        Me.btnExitSlitHome = New NETXP.Controls.XPButton
        Me.btnExitSlitWidth = New NETXP.Controls.XPButton
        Me.btnExitSlitContinious = New NETXP.Controls.XPButton
        Me.btnOk = New NETXP.Controls.XPButton
        Me.ExitSlitGroupBox = New System.Windows.Forms.GroupBox
        Me.txtExitSlitWidth = New System.Windows.Forms.TextBox
        Me.txtExitSlitHome = New System.Windows.Forms.TextBox
        Me.lblExitSlitHome = New System.Windows.Forms.Label
        Me.txtExitSlitRepeats = New System.Windows.Forms.TextBox
        Me.lblExitSlitRepeats = New System.Windows.Forms.Label
        Me.lblExitSlitWidth = New System.Windows.Forms.Label
        Me.EntrySlitGroupBox = New System.Windows.Forms.GroupBox
        Me.txtSlitWidth = New System.Windows.Forms.TextBox
        Me.txtSlitHome = New System.Windows.Forms.TextBox
        Me.lblSlitHome = New System.Windows.Forms.Label
        Me.txtSlitRepeats = New System.Windows.Forms.TextBox
        Me.lblSlitRepeats = New System.Windows.Forms.Label
        Me.lblSlitWidth = New System.Windows.Forms.Label
        Me.WVGroupBox = New System.Windows.Forms.GroupBox
        Me.txtWvHome = New System.Windows.Forms.TextBox
        Me.lblWvHome = New System.Windows.Forms.Label
        Me.lblWvPosition = New System.Windows.Forms.Label
        Me.txtWvPosition = New System.Windows.Forms.TextBox
        Me.txtWvRepeats = New System.Windows.Forms.TextBox
        Me.lblWvRepeats = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.mnuAutoIgnition = New NETXP.Controls.Bars.CommandBar
        Me.mnuIgnite = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuExtinguish = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.lblWvRec = New System.Windows.Forms.Label
        Me.btnWvPosition = New NETXP.Controls.XPButton
        Me.btnWvRepeats = New NETXP.Controls.XPButton
        Me.btnWvHome = New NETXP.Controls.XPButton
        Me.btnSlitHome = New NETXP.Controls.XPButton
        Me.btnSlitWidth = New NETXP.Controls.XPButton
        Me.btnSlitContinious = New NETXP.Controls.XPButton
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label8 = New System.Windows.Forms.Label
        Me.nudSlitWidth = New System.Windows.Forms.NumericUpDown
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.btnIgnite = New NETXP.Controls.XPButton
        Me.btnN2OIgnite = New NETXP.Controls.XPButton
        Me.btnExtinguish = New NETXP.Controls.XPButton
        Me.btnDelete = New NETXP.Controls.XPButton
        Me.btnR = New NETXP.Controls.XPButton
        Me.CustomPanel1.SuspendLayout()
        Me.CustomPanel2.SuspendLayout()
        Me.ExitSlitGroupBox.SuspendLayout()
        Me.EntrySlitGroupBox.SuspendLayout()
        Me.WVGroupBox.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.mnuAutoIgnition, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudSlitWidth, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.CustomPanel1.Size = New System.Drawing.Size(698, 359)
        Me.CustomPanel1.TabIndex = 0
        '
        'CustomPanel2
        '
        Me.CustomPanel2.BackColor = System.Drawing.Color.AliceBlue
        Me.CustomPanel2.Controls.Add(Me.btnExitSlitHome)
        Me.CustomPanel2.Controls.Add(Me.btnExitSlitWidth)
        Me.CustomPanel2.Controls.Add(Me.btnExitSlitContinious)
        Me.CustomPanel2.Controls.Add(Me.btnOk)
        Me.CustomPanel2.Controls.Add(Me.ExitSlitGroupBox)
        Me.CustomPanel2.Controls.Add(Me.EntrySlitGroupBox)
        Me.CustomPanel2.Controls.Add(Me.WVGroupBox)
        Me.CustomPanel2.Controls.Add(Me.Panel1)
        Me.CustomPanel2.Controls.Add(Me.lblWvRec)
        Me.CustomPanel2.Controls.Add(Me.btnWvPosition)
        Me.CustomPanel2.Controls.Add(Me.btnWvRepeats)
        Me.CustomPanel2.Controls.Add(Me.btnWvHome)
        Me.CustomPanel2.Controls.Add(Me.btnSlitHome)
        Me.CustomPanel2.Controls.Add(Me.btnSlitWidth)
        Me.CustomPanel2.Controls.Add(Me.btnSlitContinious)
        Me.CustomPanel2.Controls.Add(Me.Button1)
        Me.CustomPanel2.Controls.Add(Me.Label8)
        Me.CustomPanel2.Controls.Add(Me.nudSlitWidth)
        Me.CustomPanel2.Controls.Add(Me.TabControl1)
        Me.CustomPanel2.Controls.Add(Me.btnIgnite)
        Me.CustomPanel2.Controls.Add(Me.btnN2OIgnite)
        Me.CustomPanel2.Controls.Add(Me.btnExtinguish)
        Me.CustomPanel2.Controls.Add(Me.btnDelete)
        Me.CustomPanel2.Controls.Add(Me.btnR)
        Me.CustomPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CustomPanel2.Location = New System.Drawing.Point(0, 0)
        Me.CustomPanel2.Name = "CustomPanel2"
        Me.CustomPanel2.Size = New System.Drawing.Size(698, 359)
        Me.CustomPanel2.TabIndex = 13
        '
        'btnExitSlitHome
        '
        Me.btnExitSlitHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExitSlitHome.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExitSlitHome.Image = CType(resources.GetObject("btnExitSlitHome.Image"), System.Drawing.Image)
        Me.btnExitSlitHome.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExitSlitHome.Location = New System.Drawing.Point(432, 152)
        Me.btnExitSlitHome.Name = "btnExitSlitHome"
        Me.btnExitSlitHome.Size = New System.Drawing.Size(110, 38)
        Me.btnExitSlitHome.TabIndex = 48
        Me.btnExitSlitHome.Text = "Exit Slit Home"
        Me.btnExitSlitHome.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'btnExitSlitWidth
        '
        Me.btnExitSlitWidth.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExitSlitWidth.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExitSlitWidth.Image = CType(resources.GetObject("btnExitSlitWidth.Image"), System.Drawing.Image)
        Me.btnExitSlitWidth.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExitSlitWidth.Location = New System.Drawing.Point(432, 192)
        Me.btnExitSlitWidth.Name = "btnExitSlitWidth"
        Me.btnExitSlitWidth.Size = New System.Drawing.Size(110, 38)
        Me.btnExitSlitWidth.TabIndex = 49
        Me.btnExitSlitWidth.Text = "Exit Slit Width"
        Me.btnExitSlitWidth.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'btnExitSlitContinious
        '
        Me.btnExitSlitContinious.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExitSlitContinious.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExitSlitContinious.Image = CType(resources.GetObject("btnExitSlitContinious.Image"), System.Drawing.Image)
        Me.btnExitSlitContinious.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExitSlitContinious.Location = New System.Drawing.Point(432, 232)
        Me.btnExitSlitContinious.Name = "btnExitSlitContinious"
        Me.btnExitSlitContinious.Size = New System.Drawing.Size(110, 38)
        Me.btnExitSlitContinious.TabIndex = 50
        Me.btnExitSlitContinious.Text = "Exit Slit Repeats"
        Me.btnExitSlitContinious.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'btnOk
        '
        Me.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOk.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOk.Image = CType(resources.GetObject("btnOk.Image"), System.Drawing.Image)
        Me.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnOk.Location = New System.Drawing.Point(304, 320)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(86, 34)
        Me.btnOk.TabIndex = 6
        Me.btnOk.Text = "&OK"
        '
        'ExitSlitGroupBox
        '
        Me.ExitSlitGroupBox.Controls.Add(Me.txtExitSlitWidth)
        Me.ExitSlitGroupBox.Controls.Add(Me.txtExitSlitHome)
        Me.ExitSlitGroupBox.Controls.Add(Me.lblExitSlitHome)
        Me.ExitSlitGroupBox.Controls.Add(Me.txtExitSlitRepeats)
        Me.ExitSlitGroupBox.Controls.Add(Me.lblExitSlitRepeats)
        Me.ExitSlitGroupBox.Controls.Add(Me.lblExitSlitWidth)
        Me.ExitSlitGroupBox.Location = New System.Drawing.Point(476, 8)
        Me.ExitSlitGroupBox.Name = "ExitSlitGroupBox"
        Me.ExitSlitGroupBox.Size = New System.Drawing.Size(211, 120)
        Me.ExitSlitGroupBox.TabIndex = 47
        Me.ExitSlitGroupBox.TabStop = False
        Me.ExitSlitGroupBox.Text = "Exit Slit"
        '
        'txtExitSlitWidth
        '
        Me.txtExitSlitWidth.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtExitSlitWidth.Enabled = False
        Me.txtExitSlitWidth.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtExitSlitWidth.ForeColor = System.Drawing.Color.Black
        Me.txtExitSlitWidth.Location = New System.Drawing.Point(121, 49)
        Me.txtExitSlitWidth.Name = "txtExitSlitWidth"
        Me.txtExitSlitWidth.ReadOnly = True
        Me.txtExitSlitWidth.Size = New System.Drawing.Size(80, 22)
        Me.txtExitSlitWidth.TabIndex = 49
        Me.txtExitSlitWidth.Text = "2.0"
        Me.txtExitSlitWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtExitSlitHome
        '
        Me.txtExitSlitHome.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtExitSlitHome.Enabled = False
        Me.txtExitSlitHome.ForeColor = System.Drawing.Color.Black
        Me.txtExitSlitHome.Location = New System.Drawing.Point(121, 17)
        Me.txtExitSlitHome.Name = "txtExitSlitHome"
        Me.txtExitSlitHome.ReadOnly = True
        Me.txtExitSlitHome.Size = New System.Drawing.Size(80, 21)
        Me.txtExitSlitHome.TabIndex = 48
        Me.txtExitSlitHome.Text = ""
        Me.txtExitSlitHome.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblExitSlitHome
        '
        Me.lblExitSlitHome.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblExitSlitHome.Location = New System.Drawing.Point(11, 19)
        Me.lblExitSlitHome.Name = "lblExitSlitHome"
        Me.lblExitSlitHome.Size = New System.Drawing.Size(101, 16)
        Me.lblExitSlitHome.TabIndex = 47
        Me.lblExitSlitHome.Text = "Slit Home"
        '
        'txtExitSlitRepeats
        '
        Me.txtExitSlitRepeats.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtExitSlitRepeats.Enabled = False
        Me.txtExitSlitRepeats.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtExitSlitRepeats.ForeColor = System.Drawing.Color.Black
        Me.txtExitSlitRepeats.Location = New System.Drawing.Point(121, 81)
        Me.txtExitSlitRepeats.Name = "txtExitSlitRepeats"
        Me.txtExitSlitRepeats.ReadOnly = True
        Me.txtExitSlitRepeats.Size = New System.Drawing.Size(80, 22)
        Me.txtExitSlitRepeats.TabIndex = 46
        Me.txtExitSlitRepeats.Text = ""
        Me.txtExitSlitRepeats.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblExitSlitRepeats
        '
        Me.lblExitSlitRepeats.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblExitSlitRepeats.Location = New System.Drawing.Point(11, 86)
        Me.lblExitSlitRepeats.Name = "lblExitSlitRepeats"
        Me.lblExitSlitRepeats.Size = New System.Drawing.Size(104, 16)
        Me.lblExitSlitRepeats.TabIndex = 45
        Me.lblExitSlitRepeats.Text = "Slit Repeats(1-99)"
        '
        'lblExitSlitWidth
        '
        Me.lblExitSlitWidth.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblExitSlitWidth.Location = New System.Drawing.Point(11, 52)
        Me.lblExitSlitWidth.Name = "lblExitSlitWidth"
        Me.lblExitSlitWidth.Size = New System.Drawing.Size(101, 16)
        Me.lblExitSlitWidth.TabIndex = 44
        Me.lblExitSlitWidth.Text = "Slit Width"
        '
        'EntrySlitGroupBox
        '
        Me.EntrySlitGroupBox.Controls.Add(Me.txtSlitWidth)
        Me.EntrySlitGroupBox.Controls.Add(Me.txtSlitHome)
        Me.EntrySlitGroupBox.Controls.Add(Me.lblSlitHome)
        Me.EntrySlitGroupBox.Controls.Add(Me.txtSlitRepeats)
        Me.EntrySlitGroupBox.Controls.Add(Me.lblSlitRepeats)
        Me.EntrySlitGroupBox.Controls.Add(Me.lblSlitWidth)
        Me.EntrySlitGroupBox.Location = New System.Drawing.Point(261, 8)
        Me.EntrySlitGroupBox.Name = "EntrySlitGroupBox"
        Me.EntrySlitGroupBox.Size = New System.Drawing.Size(211, 120)
        Me.EntrySlitGroupBox.TabIndex = 46
        Me.EntrySlitGroupBox.TabStop = False
        Me.EntrySlitGroupBox.Text = "Entrance Slit"
        '
        'txtSlitWidth
        '
        Me.txtSlitWidth.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtSlitWidth.Enabled = False
        Me.txtSlitWidth.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSlitWidth.ForeColor = System.Drawing.Color.Black
        Me.txtSlitWidth.Location = New System.Drawing.Point(121, 49)
        Me.txtSlitWidth.Name = "txtSlitWidth"
        Me.txtSlitWidth.ReadOnly = True
        Me.txtSlitWidth.Size = New System.Drawing.Size(80, 22)
        Me.txtSlitWidth.TabIndex = 49
        Me.txtSlitWidth.Text = "2.0"
        Me.txtSlitWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtSlitHome
        '
        Me.txtSlitHome.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtSlitHome.Enabled = False
        Me.txtSlitHome.ForeColor = System.Drawing.Color.Black
        Me.txtSlitHome.Location = New System.Drawing.Point(121, 17)
        Me.txtSlitHome.Name = "txtSlitHome"
        Me.txtSlitHome.ReadOnly = True
        Me.txtSlitHome.Size = New System.Drawing.Size(80, 21)
        Me.txtSlitHome.TabIndex = 48
        Me.txtSlitHome.Text = ""
        Me.txtSlitHome.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblSlitHome
        '
        Me.lblSlitHome.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSlitHome.Location = New System.Drawing.Point(11, 19)
        Me.lblSlitHome.Name = "lblSlitHome"
        Me.lblSlitHome.Size = New System.Drawing.Size(101, 16)
        Me.lblSlitHome.TabIndex = 47
        Me.lblSlitHome.Text = "Slit Home"
        '
        'txtSlitRepeats
        '
        Me.txtSlitRepeats.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtSlitRepeats.Enabled = False
        Me.txtSlitRepeats.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSlitRepeats.ForeColor = System.Drawing.Color.Black
        Me.txtSlitRepeats.Location = New System.Drawing.Point(121, 81)
        Me.txtSlitRepeats.Name = "txtSlitRepeats"
        Me.txtSlitRepeats.ReadOnly = True
        Me.txtSlitRepeats.Size = New System.Drawing.Size(80, 22)
        Me.txtSlitRepeats.TabIndex = 46
        Me.txtSlitRepeats.Text = ""
        Me.txtSlitRepeats.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblSlitRepeats
        '
        Me.lblSlitRepeats.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSlitRepeats.Location = New System.Drawing.Point(11, 86)
        Me.lblSlitRepeats.Name = "lblSlitRepeats"
        Me.lblSlitRepeats.Size = New System.Drawing.Size(104, 16)
        Me.lblSlitRepeats.TabIndex = 45
        Me.lblSlitRepeats.Text = "Slit Repeats(1-99)"
        '
        'lblSlitWidth
        '
        Me.lblSlitWidth.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSlitWidth.Location = New System.Drawing.Point(11, 52)
        Me.lblSlitWidth.Name = "lblSlitWidth"
        Me.lblSlitWidth.Size = New System.Drawing.Size(101, 16)
        Me.lblSlitWidth.TabIndex = 44
        Me.lblSlitWidth.Text = "Slit Width"
        '
        'WVGroupBox
        '
        Me.WVGroupBox.Controls.Add(Me.txtWvHome)
        Me.WVGroupBox.Controls.Add(Me.lblWvHome)
        Me.WVGroupBox.Controls.Add(Me.lblWvPosition)
        Me.WVGroupBox.Controls.Add(Me.txtWvPosition)
        Me.WVGroupBox.Controls.Add(Me.txtWvRepeats)
        Me.WVGroupBox.Controls.Add(Me.lblWvRepeats)
        Me.WVGroupBox.Location = New System.Drawing.Point(8, 8)
        Me.WVGroupBox.Name = "WVGroupBox"
        Me.WVGroupBox.Size = New System.Drawing.Size(248, 120)
        Me.WVGroupBox.TabIndex = 45
        Me.WVGroupBox.TabStop = False
        Me.WVGroupBox.Text = "Wavelength"
        '
        'txtWvHome
        '
        Me.txtWvHome.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtWvHome.Enabled = False
        Me.txtWvHome.ForeColor = System.Drawing.Color.Black
        Me.txtWvHome.Location = New System.Drawing.Point(167, 19)
        Me.txtWvHome.Name = "txtWvHome"
        Me.txtWvHome.ReadOnly = True
        Me.txtWvHome.Size = New System.Drawing.Size(72, 21)
        Me.txtWvHome.TabIndex = 22
        Me.txtWvHome.Text = ""
        Me.txtWvHome.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblWvHome
        '
        Me.lblWvHome.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWvHome.Location = New System.Drawing.Point(12, 21)
        Me.lblWvHome.Name = "lblWvHome"
        Me.lblWvHome.Size = New System.Drawing.Size(117, 16)
        Me.lblWvHome.TabIndex = 19
        Me.lblWvHome.Text = "Wavelength Home"
        '
        'lblWvPosition
        '
        Me.lblWvPosition.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWvPosition.Location = New System.Drawing.Point(12, 52)
        Me.lblWvPosition.Name = "lblWvPosition"
        Me.lblWvPosition.Size = New System.Drawing.Size(149, 16)
        Me.lblWvPosition.TabIndex = 20
        Me.lblWvPosition.Text = "Wavelength Position(nm)"
        '
        'txtWvPosition
        '
        Me.txtWvPosition.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtWvPosition.Enabled = False
        Me.txtWvPosition.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWvPosition.ForeColor = System.Drawing.Color.Black
        Me.txtWvPosition.Location = New System.Drawing.Point(167, 49)
        Me.txtWvPosition.Name = "txtWvPosition"
        Me.txtWvPosition.ReadOnly = True
        Me.txtWvPosition.Size = New System.Drawing.Size(72, 22)
        Me.txtWvPosition.TabIndex = 23
        Me.txtWvPosition.Text = "0.0"
        Me.txtWvPosition.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtWvRepeats
        '
        Me.txtWvRepeats.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtWvRepeats.Enabled = False
        Me.txtWvRepeats.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWvRepeats.ForeColor = System.Drawing.Color.Black
        Me.txtWvRepeats.Location = New System.Drawing.Point(168, 80)
        Me.txtWvRepeats.Name = "txtWvRepeats"
        Me.txtWvRepeats.ReadOnly = True
        Me.txtWvRepeats.Size = New System.Drawing.Size(72, 22)
        Me.txtWvRepeats.TabIndex = 24
        Me.txtWvRepeats.Text = ""
        Me.txtWvRepeats.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblWvRepeats
        '
        Me.lblWvRepeats.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWvRepeats.Location = New System.Drawing.Point(12, 83)
        Me.lblWvRepeats.Name = "lblWvRepeats"
        Me.lblWvRepeats.Size = New System.Drawing.Size(154, 16)
        Me.lblWvRepeats.TabIndex = 21
        Me.lblWvRepeats.Text = "Wavelength Repeats(1-99)"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.mnuAutoIgnition)
        Me.Panel1.Location = New System.Drawing.Point(136, 352)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(216, 56)
        Me.Panel1.TabIndex = 44
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
        Me.mnuIgnite.Text = "Ignite"
        '
        'mnuExtinguish
        '
        Me.mnuExtinguish.PadHorizontal = 5
        Me.mnuExtinguish.Text = "Extinguish"
        '
        'lblWvRec
        '
        Me.lblWvRec.Enabled = False
        Me.lblWvRec.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWvRec.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblWvRec.Location = New System.Drawing.Point(224, 280)
        Me.lblWvRec.Name = "lblWvRec"
        Me.lblWvRec.Size = New System.Drawing.Size(248, 24)
        Me.lblWvRec.TabIndex = 41
        Me.lblWvRec.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnWvPosition
        '
        Me.btnWvPosition.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnWvPosition.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnWvPosition.Image = CType(resources.GetObject("btnWvPosition.Image"), System.Drawing.Image)
        Me.btnWvPosition.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnWvPosition.Location = New System.Drawing.Point(176, 192)
        Me.btnWvPosition.Name = "btnWvPosition"
        Me.btnWvPosition.Size = New System.Drawing.Size(110, 38)
        Me.btnWvPosition.TabIndex = 1
        Me.btnWvPosition.Text = "Wv Position"
        Me.btnWvPosition.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnWvRepeats
        '
        Me.btnWvRepeats.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnWvRepeats.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnWvRepeats.Image = CType(resources.GetObject("btnWvRepeats.Image"), System.Drawing.Image)
        Me.btnWvRepeats.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnWvRepeats.Location = New System.Drawing.Point(176, 232)
        Me.btnWvRepeats.Name = "btnWvRepeats"
        Me.btnWvRepeats.Size = New System.Drawing.Size(110, 38)
        Me.btnWvRepeats.TabIndex = 2
        Me.btnWvRepeats.Text = "Wv Repeats"
        Me.btnWvRepeats.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnWvHome
        '
        Me.btnWvHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnWvHome.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnWvHome.Image = CType(resources.GetObject("btnWvHome.Image"), System.Drawing.Image)
        Me.btnWvHome.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnWvHome.Location = New System.Drawing.Point(176, 152)
        Me.btnWvHome.Name = "btnWvHome"
        Me.btnWvHome.Size = New System.Drawing.Size(110, 38)
        Me.btnWvHome.TabIndex = 0
        Me.btnWvHome.Text = "Wv Home"
        Me.btnWvHome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnSlitHome
        '
        Me.btnSlitHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSlitHome.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSlitHome.Image = CType(resources.GetObject("btnSlitHome.Image"), System.Drawing.Image)
        Me.btnSlitHome.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSlitHome.Location = New System.Drawing.Point(304, 152)
        Me.btnSlitHome.Name = "btnSlitHome"
        Me.btnSlitHome.Size = New System.Drawing.Size(110, 38)
        Me.btnSlitHome.TabIndex = 3
        Me.btnSlitHome.Text = "Entrance Slit Home"
        Me.btnSlitHome.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'btnSlitWidth
        '
        Me.btnSlitWidth.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSlitWidth.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSlitWidth.Image = CType(resources.GetObject("btnSlitWidth.Image"), System.Drawing.Image)
        Me.btnSlitWidth.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSlitWidth.Location = New System.Drawing.Point(304, 192)
        Me.btnSlitWidth.Name = "btnSlitWidth"
        Me.btnSlitWidth.Size = New System.Drawing.Size(110, 38)
        Me.btnSlitWidth.TabIndex = 4
        Me.btnSlitWidth.Text = "Entrance Slit Width"
        Me.btnSlitWidth.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'btnSlitContinious
        '
        Me.btnSlitContinious.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSlitContinious.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSlitContinious.Image = CType(resources.GetObject("btnSlitContinious.Image"), System.Drawing.Image)
        Me.btnSlitContinious.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSlitContinious.Location = New System.Drawing.Point(304, 232)
        Me.btnSlitContinious.Name = "btnSlitContinious"
        Me.btnSlitContinious.Size = New System.Drawing.Size(110, 38)
        Me.btnSlitContinious.TabIndex = 5
        Me.btnSlitContinious.Text = "Entrance Slit Repeats"
        Me.btnSlitContinious.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'Button1
        '
        Me.Button1.Enabled = False
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button1.Location = New System.Drawing.Point(109, 144)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(480, 168)
        Me.Button1.TabIndex = 34
        '
        'Label8
        '
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label8.Location = New System.Drawing.Point(101, 136)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(496, 176)
        Me.Label8.TabIndex = 33
        '
        'nudSlitWidth
        '
        Me.nudSlitWidth.DecimalPlaces = 1
        Me.nudSlitWidth.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.nudSlitWidth.Location = New System.Drawing.Point(64, 320)
        Me.nudSlitWidth.Maximum = New Decimal(New Integer() {2, 0, 0, 0})
        Me.nudSlitWidth.Name = "nudSlitWidth"
        Me.nudSlitWidth.Size = New System.Drawing.Size(80, 21)
        Me.nudSlitWidth.TabIndex = 32
        Me.nudSlitWidth.Visible = False
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(416, 304)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(96, 40)
        Me.TabControl1.TabIndex = 12
        Me.TabControl1.Visible = False
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.AliceBlue
        Me.TabPage1.Location = New System.Drawing.Point(4, 24)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(88, 12)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Wavelength"
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.AliceBlue
        Me.TabPage2.Location = New System.Drawing.Point(4, 24)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(88, 12)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Slit"
        '
        'btnIgnite
        '
        Me.btnIgnite.BackColor = System.Drawing.Color.Transparent
        Me.btnIgnite.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnIgnite.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIgnite.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnIgnite.Location = New System.Drawing.Point(334, 175)
        Me.btnIgnite.Name = "btnIgnite"
        Me.btnIgnite.Size = New System.Drawing.Size(8, 8)
        Me.btnIgnite.TabIndex = 51
        Me.btnIgnite.TabStop = False
        Me.btnIgnite.Text = "&Ignition"
        Me.btnIgnite.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'btnN2OIgnite
        '
        Me.btnN2OIgnite.BackColor = System.Drawing.Color.Transparent
        Me.btnN2OIgnite.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnN2OIgnite.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnN2OIgnite.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnN2OIgnite.Location = New System.Drawing.Point(350, 175)
        Me.btnN2OIgnite.Name = "btnN2OIgnite"
        Me.btnN2OIgnite.Size = New System.Drawing.Size(8, 8)
        Me.btnN2OIgnite.TabIndex = 53
        Me.btnN2OIgnite.TabStop = False
        Me.btnN2OIgnite.Text = "N2O&C"
        Me.btnN2OIgnite.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'btnExtinguish
        '
        Me.btnExtinguish.BackColor = System.Drawing.Color.Transparent
        Me.btnExtinguish.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExtinguish.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExtinguish.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExtinguish.Location = New System.Drawing.Point(318, 175)
        Me.btnExtinguish.Name = "btnExtinguish"
        Me.btnExtinguish.Size = New System.Drawing.Size(8, 8)
        Me.btnExtinguish.TabIndex = 52
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
        Me.btnDelete.Location = New System.Drawing.Point(360, 175)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(8, 8)
        Me.btnDelete.TabIndex = 55
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
        Me.btnR.Location = New System.Drawing.Point(372, 175)
        Me.btnR.Name = "btnR"
        Me.btnR.Size = New System.Drawing.Size(8, 8)
        Me.btnR.TabIndex = 54
        Me.btnR.TabStop = False
        Me.btnR.Text = "&R"
        Me.btnR.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'frmMonochromatorDB
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(698, 359)
        Me.Controls.Add(Me.CustomPanel1)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMonochromatorDB"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Monochromator"
        Me.CustomPanel1.ResumeLayout(False)
        Me.CustomPanel2.ResumeLayout(False)
        Me.ExitSlitGroupBox.ResumeLayout(False)
        Me.EntrySlitGroupBox.ResumeLayout(False)
        Me.WVGroupBox.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.mnuAutoIgnition, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudSlitWidth, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Variables"
    Private WithEvents mobjfrmEditValues As New frmEditValues
    Private mintValue As Double
    Private mblnInProcess As Boolean = False
#End Region

#Region "Constants"
    Private Const ConstWvPosition = "Enter new Wavelength"
    Private Const ConstSlitPosition = "Slit Position(0 - 2.0)"
    Private Const ConstWvRepeats = "No. of Repeats"
    Private Const ConstSlitcontinious = "No. of Repeats"
#End Region

#Region "Properties"
    Private Property InputValue() As Double
        Get
            Return mintValue
        End Get
        Set(ByVal Value As Double)
            mintValue = Value
        End Set
    End Property
#End Region

#Region "Form Events"

    Private Sub frmMonochromator_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '=====================================================================
        ' Procedure Name        : frmMonochromator_Load
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To initialize the form
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 22.11.06
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Try
            Call AddHandlers()
            If gobjInst.WavelengthCur = 0 Then
                txtWvHome.Text = "HOME"
                txtWvPosition.Text = CDbl(gobjInst.WavelengthCur)
            Else
                txtWvPosition.Text = CDbl(gobjInst.WavelengthCur)
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
        Try
            AddHandler btnOk.Click, AddressOf btnOk_Click

            AddHandler btnWvHome.Click, AddressOf btnWvHome_Click
            AddHandler btnWvPosition.Click, AddressOf btnWvPosition_Click
            AddHandler btnWvRepeats.Click, AddressOf btnWvRepeats_Click

            AddHandler btnSlitHome.Click, AddressOf btnSlitHome_Click
            AddHandler btnSlitContinious.Click, AddressOf btnSlitContinious_Click
            AddHandler btnSlitWidth.Click, AddressOf btnSlitWidth_Click

            'AddHandler mnuExtinguish.Click, AddressOf btnExtinguish_Click
            'AddHandler mnuIgnite.Click, AddressOf btnAutoIgnition_Click
            AddHandler btnDelete.Click, AddressOf btnDelete_Click
            AddHandler btnR.Click, AddressOf btnR_Click

            AddHandler btnExitSlitHome.Click, AddressOf btnExitSlitHome_Click
            AddHandler btnExitSlitContinious.Click, AddressOf btnExitSlitContinious_Click
            AddHandler btnExitSlitWidth.Click, AddressOf btnExitSlitWidth_Click

            AddHandler btnExtinguish.Click, AddressOf btnExtinguish_Click
            AddHandler btnIgnite.Click, AddressOf btnAutoIgnition_Click
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

    Private Sub btnSlitContinious_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '               case IDC_BSCONT:
        '							rpt=10;
        '							strcpy(Cap[0], "No. of repeats");
        '							sprintf(Str[0],"%-2d ",rpt);
        '							Len[0]=2;
        '							Len[1]=-1;
        '							GetValues(hwnd, Cap, Str, Len);
        '							rpt=atoi(Str[0]);
        '							i=0; sw = Inst_par->Slitpos; op = 40;
        '							do{
        '							  if (Inst_par->Slitpos>=0 && Inst_par->Slitpos<=80)
        '								 sprintf(Str[0],"%-2.1f nm",(80-Inst_par->Slitpos)/40.0);
        '            Else
        '								 strcpy(Str[0],"ERROR");
        '							  SetDlgItemText(hwnd,IDC_SLIT, Str[0]);
        '							  sw+=op;
        '							  if (sw>80){
        '								  sw =80; op = -40;
        '								  SetDlgItemInt(hwnd,IDC_SRPT, i+1, FALSE);
        '								  i++; }
        '                    If (i >= rpt) Then
        '								 break;
        '							  if (sw<0) {
        '								 sw = 0; op=40;
        '								 SetDlgItemInt(hwnd,IDC_SRPT, i+1, FALSE);
        '								 i++; }
        '							  Position_Slit(sw);
        '							  UpdateWindow(hwnd);
        '							  for(j=0; j<15; j++)
        '							    pc_delay(20000); 
        '							 } while(i<rpt);
        '							break;
        '=====================================================================
        ' Procedure Name        : btnSlitContinious_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To position the Slit
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 21.11.06
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Dim intSlitRepeats As Integer
        Dim dblSlitWidth As Double
        Dim intcount As Integer
        Try
            'by pankaj on 17.1.08
            If Check_Password() = False Then
                mobjfrmEditValues.txtValue.PasswordChar = ""
                ''promt for a correct password
                Exit Sub
            End If
            '---------------

            If mblnInProcess = True Then
                Exit Sub
            End If
            If txtSlitWidth.Text = "" Then
                gobjMessageAdapter.ShowMessage(constInputProperData)
                Exit Sub
            End If

            mblnInProcess = True
            mobjfrmEditValues.LabelText = ConstSlitcontinious
            mobjfrmEditValues.txtValue.Visible = True
            mobjfrmEditValues.txtValue.ValidationType = NumberValidator.NumberValidator.Validations.IntegerOnly
            mobjfrmEditValues.txtValue.RangeValidation = True
            mobjfrmEditValues.txtValue.DigitsAfterDecimalPoint = 0
            mobjfrmEditValues.txtValue.MaxLength = 3
            mobjfrmEditValues.txtValue.MinimumRange = 1
            mobjfrmEditValues.txtValue.MaximumRange = 100
            mobjfrmEditValues.txtValue.SelectAll()
            mobjfrmEditValues.txtValue.Focus()
            mobjfrmEditValues.txtValue.Text = "10"
            If mobjfrmEditValues.ShowDialog = DialogResult.Cancel Then
                Exit Sub
            End If
            Application.DoEvents()
            'If InputValue >= 100 Then
            '    gobjMessageAdapter.ShowMessage(constRepeatValue)
            '    Exit Sub
            'End If
            intSlitRepeats = CInt(InputValue)
            If intSlitRepeats < 1 Or intSlitRepeats > 100 Then
                gobjMessageAdapter.ShowMessage(constRepeatValue)
                Exit Sub
            End If
            dblSlitWidth = Format(CDbl(txtSlitWidth.Text), "0.0")
            If dblSlitWidth < 0 Then
                dblSlitWidth = 0.0
            End If

            For intcount = 1 To intSlitRepeats

                If intcount = 1 Then
                    If dblSlitWidth < 1 Then
                        gobjClsAAS203.funcbtnSlitWidth(dblSlitWidth)
                        txtSlitWidth.Text = CDbl(dblSlitWidth)
                    ElseIf dblSlitWidth = 1 Or dblSlitWidth = 2 Then
                        gobjClsAAS203.funcbtnSlitWidth(0.0)
                        txtSlitWidth.Text = "0.0"
                        txtSlitWidth.Refresh()
                    ElseIf dblSlitWidth > 1 And dblSlitWidth < 2 Then
                        gobjClsAAS203.funcbtnSlitWidth(dblSlitWidth - 1)
                        txtSlitWidth.Text = CDbl(dblSlitWidth - 1)
                        txtSlitWidth.Refresh()
                    End If
                    gobjCommProtocol.mobjCommdll.subTime_Delay(500)
                ElseIf intcount > 1 And intcount Mod 2 = 1 Then
                    txtSlitWidth.Text = "0.0"
                    txtSlitWidth.Refresh()
                    txtSlitRepeats.Text = CInt(intcount)
                    txtSlitRepeats.Refresh()
                    gobjClsAAS203.funcbtnSlitWidth(0.0)
                    gobjCommProtocol.mobjCommdll.subTime_Delay(500)
                Else
                    gobjClsAAS203.funcbtnSlitWidth(0.0)
                    txtSlitWidth.Text = "0.0"
                    txtSlitWidth.Refresh()
                    gobjCommProtocol.mobjCommdll.subTime_Delay(500)

                    txtSlitRepeats.Text = CInt(intcount)
                    txtSlitRepeats.Refresh()

                    txtSlitWidth.Text = "2.0"
                    txtSlitWidth.Refresh()
                    gobjClsAAS203.funcbtnSlitHome()
                    gobjCommProtocol.mobjCommdll.subTime_Delay(500)
                End If
                txtSlitRepeats.Text = CInt(intcount)
                txtSlitRepeats.Refresh()
            Next intcount


        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
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
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            '---------------------------------------------------------
        End Try

    End Sub

    Private Sub btnSlitHome_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : btnSlitHome_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To make the Slit to its home position.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 21.11.06
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Try
            If mblnInProcess = True Then
                Exit Sub
            End If
            mblnInProcess = True
            If gobjClsAAS203.funcbtnSlitHome() = True Then
                txtSlitHome.Text = "HOME"
                txtSlitWidth.Text = "2.0"
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
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            '---------------------------------------------------------
        End Try
    End Sub
    Private Function Check_Password() As Boolean
        ''note:'
        ''this is used for checking a password enterd by a user
        ''if password is correct then proceed else prompt the user that
        ''Enter the correct password




        Dim blnPass As Boolean = True
        mobjfrmEditValues.Text = "Password Required!!!"
        mobjfrmEditValues.LabelText = "Enter The Password"
        mobjfrmEditValues.txtValue.Text = ""
        mobjfrmEditValues.txtValue.Visible = True
        mobjfrmEditValues.txtValue.ValidationType = NumberValidator.NumberValidator.Validations.AlphaNumeric
        'mobjfrmEditValues.txtValue.ValidationType = NumberValidator.NumberValidator.Validations.IntegerOnly
        mobjfrmEditValues.txtValue.RangeValidation = False
        mobjfrmEditValues.txtValue.DigitsAfterDecimalPoint = 0
        mobjfrmEditValues.txtValue.MaxLength = 10
        mobjfrmEditValues.txtValue.MinimumRange = 1
        mobjfrmEditValues.txtValue.MaximumRange = 99999
        'mobjfrmEditValues.txtValue.SelectAll()
        Do
            mobjfrmEditValues.txtValue.Focus()
            mobjfrmEditValues.txtValue.PasswordChar = "*"
            If mobjfrmEditValues.ShowDialog = DialogResult.Cancel Then
                blnPass = False
                mobjfrmEditValues.Text = "Edit Values"
                mobjfrmEditValues.txtValue.PasswordChar = ""
                mobjfrmEditValues.txtValue.Text = ""
                Return False
            ElseIf mobjfrmEditValues.txtValue.Text = "shree" Then
                blnPass = False
                mobjfrmEditValues.Text = "Edit Values"
                mobjfrmEditValues.txtValue.Text = ""
                mobjfrmEditValues.txtValue.PasswordChar = ""
                Return True
            Else
                gobjMessageAdapter.ShowMessage("Please enter the correct password", "Confirm password", MessageHandler.clsMessageHandler.enumMessageType.ErrorMessage)

            End If
            Application.DoEvents()

        Loop While (blnPass = True)



    End Function

    Private Sub btnExitSlitContinious_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '               case IDC_BSCONT:
        '							rpt=10;
        '							strcpy(Cap[0], "No. of repeats");
        '							sprintf(Str[0],"%-2d ",rpt);
        '							Len[0]=2;
        '							Len[1]=-1;
        '							GetValues(hwnd, Cap, Str, Len);
        '							rpt=atoi(Str[0]);
        '							i=0; sw = Inst_par->Slitpos; op = 40;
        '							do{
        '							  if (Inst_par->Slitpos>=0 && Inst_par->Slitpos<=80)
        '								 sprintf(Str[0],"%-2.1f nm",(80-Inst_par->Slitpos)/40.0);
        '            Else
        '								 strcpy(Str[0],"ERROR");
        '							  SetDlgItemText(hwnd,IDC_SLIT, Str[0]);
        '							  sw+=op;
        '							  if (sw>80){
        '								  sw =80; op = -40;
        '								  SetDlgItemInt(hwnd,IDC_SRPT, i+1, FALSE);
        '								  i++; }
        '                    If (i >= rpt) Then
        '								 break;
        '							  if (sw<0) {
        '								 sw = 0; op=40;
        '								 SetDlgItemInt(hwnd,IDC_SRPT, i+1, FALSE);
        '								 i++; }
        '							  Position_Slit(sw);
        '							  UpdateWindow(hwnd);
        '							  for(j=0; j<15; j++)
        '							    pc_delay(20000); 
        '							 } while(i<rpt);
        '							break;
        '=====================================================================
        ' Procedure Name        : btnSlitContinious_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To position the Slit
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 21.11.06
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Dim intSlitRepeats As Integer
        Dim dblSlitWidth As Double
        Dim intcount As Integer
        Try
            'by pankaj on 17.1.08
            If Check_Password() = False Then
                mobjfrmEditValues.txtValue.PasswordChar = ""
                ''promt for a correct password
                Exit Sub
            End If
            '---------------
            If mblnInProcess = True Then
                Exit Sub
            End If

            If txtExitSlitWidth.Text = "" Then
                gobjMessageAdapter.ShowMessage(constInputProperData)
                Exit Sub
            End If
            mblnInProcess = True
            mobjfrmEditValues.LabelText = ConstSlitcontinious
            mobjfrmEditValues.txtValue.Visible = True
            mobjfrmEditValues.txtValue.ValidationType = NumberValidator.NumberValidator.Validations.IntegerOnly
            mobjfrmEditValues.txtValue.RangeValidation = True
            mobjfrmEditValues.txtValue.DigitsAfterDecimalPoint = 0
            mobjfrmEditValues.txtValue.MaxLength = 3
            mobjfrmEditValues.txtValue.MinimumRange = 1
            mobjfrmEditValues.txtValue.MaximumRange = 100
            mobjfrmEditValues.txtValue.SelectAll()
            mobjfrmEditValues.txtValue.Focus()
            mobjfrmEditValues.txtValue.Text = "10"
            If mobjfrmEditValues.ShowDialog = DialogResult.Cancel Then
                Exit Sub
            End If
            Application.DoEvents()
            'If InputValue >= 100 Then
            '    gobjMessageAdapter.ShowMessage(constRepeatValue)
            '    Exit Sub
            'End If
            intSlitRepeats = CInt(InputValue)
            If intSlitRepeats < 1 Or intSlitRepeats > 100 Then
                gobjMessageAdapter.ShowMessage(constRepeatValue)
                Exit Sub
            End If
            dblSlitWidth = Format(CDbl(txtExitSlitWidth.Text), "0.0")
            If dblSlitWidth < 0 Then
                dblSlitWidth = 0.0
            End If

            For intcount = 1 To intSlitRepeats

                If intcount = 1 Then
                    If dblSlitWidth < 1 Then
                        'gobjClsAAS203.funcbtnSlitWidth(dblSlitWidth)
                        gobjCommProtocol.funcSet_SlitWidth(dblSlitWidth, 1)
                        txtExitSlitWidth.Text = CDbl(dblSlitWidth)
                    ElseIf dblSlitWidth = 1 Or dblSlitWidth = 2 Then
                        'gobjClsAAS203.funcbtnSlitWidth(0.0)
                        gobjCommProtocol.funcSet_SlitWidth(0.0, 1)
                        txtExitSlitWidth.Text = "0.0"

                    ElseIf dblSlitWidth > 1 And dblSlitWidth < 2 Then
                        'gobjClsAAS203.funcbtnSlitWidth(dblSlitWidth - 1)
                        gobjCommProtocol.funcSet_SlitWidth(dblSlitWidth - 1, 1)
                        txtExitSlitWidth.Text = CDbl(dblSlitWidth - 1)
                        txtExitSlitWidth.Refresh()
                    End If
                    gobjCommProtocol.mobjCommdll.subTime_Delay(500)
                ElseIf intcount > 1 And intcount Mod 2 = 1 Then
                    txtExitSlitWidth.Text = "0.0"
                    txtExitSlitWidth.Refresh()
                    txtSlitRepeats.Text = CInt(intcount)
                    txtSlitRepeats.Refresh()
                    'gobjClsAAS203.funcbtnSlitWidth(0.0)
                    gobjCommProtocol.funcSet_SlitWidth(0.0, 1)
                    gobjCommProtocol.mobjCommdll.subTime_Delay(500)
                Else
                    'gobjClsAAS203.funcbtnSlitWidth(0.0)
                    gobjCommProtocol.funcSet_SlitWidth(0.0, 1)
                    txtExitSlitWidth.Text = "0.0"
                    txtExitSlitWidth.Refresh()
                    gobjCommProtocol.mobjCommdll.subTime_Delay(500)

                    txtSlitRepeats.Text = CInt(intcount)
                    txtSlitRepeats.Refresh()

                    txtExitSlitWidth.Text = "2.0"
                    txtExitSlitWidth.Refresh()
                    'gobjClsAAS203.funcbtnSlitHome()
                    If gobjCommProtocol.funcExitSlit_Home() Then
                    End If
                    gobjCommProtocol.mobjCommdll.subTime_Delay(500)
                End If
                txtExitSlitWidth.Refresh()
                txtExitSlitRepeats.Text = CInt(intcount)
                txtExitSlitRepeats.Refresh()
            Next intcount


        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
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
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            '---------------------------------------------------------
        End Try

    End Sub

    Private Sub btnExitSlitHome_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : btnSlitHome_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To make the Slit to its home position.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 21.11.06
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Try
            If mblnInProcess = True Then
                Exit Sub
            End If
            mblnInProcess = True
            'If gobjClsAAS203.funcbtnSlitHome() = True Then
            If gobjCommProtocol.funcExitSlit_Home() Then
                txtExitSlitHome.Text = "HOME"
                txtExitSlitWidth.Text = "2.0"
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
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub btnWvHome_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : btnWvHome_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To make the Wavelength indicator home
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 21.11.06
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Try
            If mblnInProcess = True Then
                Exit Sub
            End If
            mblnInProcess = True
            If gobjClsAAS203.funcbtnWvHome(lblWvRec) = True Then
                txtWvHome.Text = "HOME"
                txtWvPosition.Text = "0.0"
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
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub btnWvPosition_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : btnWvPosition_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To position the Wavelength
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 21.11.06
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Dim dblWvPosition As Double
        Dim dblWv As Double
        Try
            If mblnInProcess = True Then
                Exit Sub
            End If
            mobjfrmEditValues.LabelText = ConstWvPosition
            mobjfrmEditValues.txtValue.Visible = True
            mblnInProcess = True
            mobjfrmEditValues.txtValue.ValidationType = NumberValidator.NumberValidator.Validations.DoubleOnly
            mobjfrmEditValues.txtValue.RangeValidation = True
            mobjfrmEditValues.txtValue.DigitsAfterDecimalPoint = 2
            mobjfrmEditValues.txtValue.MaxLength = 6
            mobjfrmEditValues.txtValue.MinimumRange = 0
            mobjfrmEditValues.txtValue.MaximumRange = 1000.0
            mobjfrmEditValues.txtValue.TabIndex = 0
            mobjfrmEditValues.txtValue.SelectAll()
            mobjfrmEditValues.txtValue.Focus()
            mobjfrmEditValues.txtValue.Text = "0.00"
            If mobjfrmEditValues.ShowDialog = DialogResult.Cancel Then
                Exit Sub
            End If
            Application.DoEvents()
            'lblWvPos.Visible = True

            dblWvPosition = Format(CDbl(InputValue), "0.00")
            If dblWvPosition < 0 Or dblWvPosition > 1000 Then
                gobjMessageAdapter.ShowMessage("Invalid Wavelength position" & vbCrLf & "Please enter wavelength range between 0-1000 nm", "Wavelength", MessageHandler.clsMessageHandler.enumMessageType.ErrorMessage)
                'MsgBox("Error")
                Exit Sub
            End If
            Application.DoEvents()
            txtWvHome.Text = ""
            If gobjClsAAS203.funcbtnWvPosition(dblWvPosition, lblWvRec) = True Then
                dblWv = CDbl(gobjInst.WavelengthCur)
            End If
            txtWvPosition.Text = CDbl(dblWv)

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
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
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub btnWvRepeats_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : btnWvRepeats_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To get the Wavelength repeats.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 21.11.06
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Dim intWvRepeats As Integer
        Dim dblWvPosition As Double
        Dim intcount As Integer
        Dim dblWv As Double
        Try
            'by pankaj on 17.1.08
            If Check_Password() = False Then
                mobjfrmEditValues.txtValue.PasswordChar = ""
                ''promt for a correct password
                Exit Sub
            End If
            '---------------
            If mblnInProcess = True Then
                Exit Sub
            End If
            mblnInProcess = True
            mobjfrmEditValues.LabelText = ConstWvRepeats
            mobjfrmEditValues.txtValue.Visible = True
            mobjfrmEditValues.txtValue.ValidationType = NumberValidator.NumberValidator.Validations.IntegerOnly
            mobjfrmEditValues.txtValue.RangeValidation = True
            mobjfrmEditValues.txtValue.DigitsAfterDecimalPoint = 0
            mobjfrmEditValues.txtValue.MaxLength = 3
            mobjfrmEditValues.txtValue.MinimumRange = 1
            mobjfrmEditValues.txtValue.MaximumRange = 100
            mobjfrmEditValues.txtValue.SelectAll()
            mobjfrmEditValues.txtValue.Focus()
            mobjfrmEditValues.txtValue.Text = "10"
            If mobjfrmEditValues.ShowDialog = DialogResult.Cancel Then
                Exit Sub
            End If
            Application.DoEvents()
            'lblWvPos.Visible = True
            'If InputValue >= 100 Then
            '    gobjMessageAdapter.ShowMessage(constRepeatValue)
            '    Exit Sub
            'End If
            intWvRepeats = CInt(InputValue)
            If intWvRepeats < 1 Or intWvRepeats > 100 Then
                gobjMessageAdapter.ShowMessage(constRepeatValue)
                Exit Sub
            End If
            'txtWvRepeats.Text = CInt(InputValue)
            'dblWvPosition = Format(CDbl(txtWvPosition.Text), "0.00")
            If txtWvPosition.Text = "" Then
                gobjMessageAdapter.ShowMessage(constInputProperData)
            Else
                For intcount = 1 To intWvRepeats
                    txtWvRepeats.Text = CInt(intcount)
                    txtWvRepeats.Refresh()
                    If intcount Mod 2 = 1 Then
                        gobjClsAAS203.funcbtnWvPosition(0.0, lblWvRec)
                        gobjCommProtocol.mobjCommdll.subTime_Delay(500)
                        'txtWvPosition.Text = CDbl(gobjInst.WavelengthCur)
                        'txtWvHome.Text = "HOME"
                    Else
                        dblWvPosition = CDbl(txtWvPosition.Text)
                        txtWvHome.Text = ""
                        gobjClsAAS203.funcbtnWvPosition(dblWvPosition, lblWvRec)
                        Application.DoEvents()
                        gobjCommProtocol.mobjCommdll.subTime_Delay(500)
                    End If
                Next intcount
            End If
            If gobjInst.WavelengthCur = 0 Then
                txtWvHome.Text = "HOME"
                txtWvPosition.Text = CDbl(gobjInst.WavelengthCur)
            Else
                txtWvPosition.Text = CDbl(gobjInst.WavelengthCur)
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
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub btnSlitWidth_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : btnSlitWidth_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To set the slit width
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 21.11.06
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Dim dblSlitWidth As Double

        Try
            If mblnInProcess = True Then
                Exit Sub
            End If
            mblnInProcess = True
            txtSlitRepeats.Text = ""
            txtSlitRepeats.Refresh()
            mobjfrmEditValues.LabelText = ConstSlitPosition
            mobjfrmEditValues.txtValue.Visible = True
            mobjfrmEditValues.txtValue.ValidationType = NumberValidator.NumberValidator.Validations.DoubleOnly
            mobjfrmEditValues.txtValue.RangeValidation = True
            mobjfrmEditValues.txtValue.DigitsAfterDecimalPoint = 1
            mobjfrmEditValues.txtValue.MaxLength = 3
            mobjfrmEditValues.txtValue.MinimumRange = 0
            mobjfrmEditValues.txtValue.MaximumRange = 2.0
            mobjfrmEditValues.txtValue.SelectAll()
            mobjfrmEditValues.txtValue.Focus()
            mobjfrmEditValues.txtValue.Text = "2.0"
            If mobjfrmEditValues.ShowDialog = DialogResult.Cancel Then
                Exit Sub
            End If
            'mobjfrmEditValues.Dispose()
            Application.DoEvents()
            dblSlitWidth = CDbl(InputValue)
            If dblSlitWidth < 0 Or dblSlitWidth > 2.0 Then
                gobjMessageAdapter.ShowMessage("Invalid Slit width", "Slit", MessageHandler.clsMessageHandler.enumMessageType.ErrorMessage)
                Exit Sub
            End If
            If gobjClsAAS203.funcbtnSlitWidth(dblSlitWidth) = True Then
                txtSlitWidth.Text = CDbl(InputValue)
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
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub btnExitSlitWidth_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : btnSlitWidth_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To set the slit width
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 21.11.06
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Dim dblExitSlitWidth As Double

        Try
            If mblnInProcess = True Then
                Exit Sub
            End If
            mblnInProcess = True
            txtExitSlitRepeats.Text = ""
            txtExitSlitRepeats.Refresh()
            mobjfrmEditValues.LabelText = ConstSlitPosition
            mobjfrmEditValues.txtValue.Visible = True
            mobjfrmEditValues.txtValue.ValidationType = NumberValidator.NumberValidator.Validations.DoubleOnly
            mobjfrmEditValues.txtValue.RangeValidation = True
            mobjfrmEditValues.txtValue.DigitsAfterDecimalPoint = 1
            mobjfrmEditValues.txtValue.MaxLength = 3
            mobjfrmEditValues.txtValue.MinimumRange = 0
            mobjfrmEditValues.txtValue.MaximumRange = 2.0
            mobjfrmEditValues.txtValue.SelectAll()
            mobjfrmEditValues.txtValue.Focus()
            mobjfrmEditValues.txtValue.Text = "2.0"
            If mobjfrmEditValues.ShowDialog = DialogResult.Cancel Then
                Exit Sub
            End If
            'mobjfrmEditValues.Dispose()
            Application.DoEvents()
            dblExitSlitWidth = CDbl(InputValue)
            If dblExitSlitWidth < 0 Or dblExitSlitWidth > 2.0 Then
                gobjMessageAdapter.ShowMessage("Invalid Slit width", "Exit Slit", MessageHandler.clsMessageHandler.enumMessageType.ErrorMessage)
                Exit Sub
            End If
            'If gobjClsAAS203.funcbtnSlitWidth(dblExitSlitWidth) = True Then
            If gobjCommProtocol.funcSet_SlitWidth(dblExitSlitWidth, 1) = True Then
                txtExitSlitWidth.Text = CDbl(InputValue)
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
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub mobjfrmEditValues_ReturnValue(ByVal dblValue As Double, ByVal intvalue1 As Integer) Handles mobjfrmEditValues.ReturnValue
        '=====================================================================
        ' Procedure Name        : mobjfrmEditValues_ReturnValue
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : Part of an event which is used to get value
        '                       : from frmEditValues
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 21.11.06
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Try
            InputValue = dblValue

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
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
        Try
            RemoveHandler mnuIgnite.Click, AddressOf btnAutoIgnition_Click
            If mblnInProcess = True Then
                Exit Sub
            End If
            mblnInProcess = True
            'If Not IsNothing(mobjfrmAnalysis) Then mobjfrmAnalysis.tmrAspirationMsg.Enabled = False
            ' mobjController.Cancel()
            Application.DoEvents()

            Call gobjClsAAS203.funcIgnite(True)
            mblnInProcess = False
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
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
        Try
            RemoveHandler mnuExtinguish.Click, AddressOf btnExtinguish_Click
            If mblnInProcess = True Then
                Exit Sub
            End If
            mblnInProcess = True
            'If Not IsNothing(mobjfrmAnalysis) Then mobjfrmAnalysis.tmrAspirationMsg.Enabled = False
            'mobjController.Cancel()
            Application.DoEvents()

            Call gobjClsAAS203.funcIgnite(False)
            mblnInProcess = False
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
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
