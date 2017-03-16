Imports AAS203.Common

Public Class frmAnalog ''this is a class behind the analog form
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
    Friend WithEvents CustomPanel1 As GradientPanel.CustomPanel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents btnSetMode As NETXP.Controls.XPButton
    Friend WithEvents btnSetPMT As NETXP.Controls.XPButton
    Friend WithEvents lblDEC As System.Windows.Forms.Label
    Friend WithEvents lblHEX As System.Windows.Forms.Label
    Friend WithEvents lblMV As System.Windows.Forms.Label
    Friend WithEvents txtDEC As System.Windows.Forms.TextBox
    Friend WithEvents txtHEX As System.Windows.Forms.TextBox
    Friend WithEvents txtMv As System.Windows.Forms.TextBox
    Friend WithEvents btnClose As NETXP.Controls.XPButton
    Friend WithEvents lblFiltered As System.Windows.Forms.Label
    Friend WithEvents btnADCFilter As NETXP.Controls.XPButton
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents txtMode As System.Windows.Forms.TextBox
    Friend WithEvents lblMode As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtPMT As System.Windows.Forms.TextBox
    Friend WithEvents lblPMT As System.Windows.Forms.Label
    Friend WithEvents txtMicroStatus As System.Windows.Forms.TextBox
    Friend WithEvents txtGainStatus As System.Windows.Forms.TextBox
    Friend WithEvents lblMicroStatus As System.Windows.Forms.Label
    Friend WithEvents lblGainStatus As System.Windows.Forms.Label
    Friend WithEvents txtAvgFactor As System.Windows.Forms.TextBox
    Friend WithEvents lblAvgFactor As System.Windows.Forms.Label
    Friend WithEvents btnAvgValue As NETXP.Controls.XPButton
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents mnuAutoIgnition As NETXP.Controls.Bars.CommandBar
    Friend WithEvents mnuIgnite As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuExtinguish As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuDelete As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents mnuR As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents btnDelete As NETXP.Controls.XPButton
    Friend WithEvents btnR As NETXP.Controls.XPButton
    Friend WithEvents btnIgnite As NETXP.Controls.XPButton
    Friend WithEvents btnN2OIgnite As NETXP.Controls.XPButton
    Friend WithEvents btnExtinguish As NETXP.Controls.XPButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmAnalog))
        Me.CustomPanel1 = New GradientPanel.CustomPanel
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.txtAvgFactor = New System.Windows.Forms.TextBox
        Me.lblAvgFactor = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtPMT = New System.Windows.Forms.TextBox
        Me.lblPMT = New System.Windows.Forms.Label
        Me.txtMode = New System.Windows.Forms.TextBox
        Me.lblMode = New System.Windows.Forms.Label
        Me.btnAvgValue = New NETXP.Controls.XPButton
        Me.btnSetMode = New NETXP.Controls.XPButton
        Me.btnSetPMT = New NETXP.Controls.XPButton
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.btnADCFilter = New NETXP.Controls.XPButton
        Me.btnClose = New NETXP.Controls.XPButton
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.lblDEC = New System.Windows.Forms.Label
        Me.lblHEX = New System.Windows.Forms.Label
        Me.lblMV = New System.Windows.Forms.Label
        Me.txtDEC = New System.Windows.Forms.TextBox
        Me.txtHEX = New System.Windows.Forms.TextBox
        Me.txtMv = New System.Windows.Forms.TextBox
        Me.lblFiltered = New System.Windows.Forms.Label
        Me.txtGainStatus = New System.Windows.Forms.TextBox
        Me.lblGainStatus = New System.Windows.Forms.Label
        Me.lblMicroStatus = New System.Windows.Forms.Label
        Me.txtMicroStatus = New System.Windows.Forms.TextBox
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.mnuAutoIgnition = New NETXP.Controls.Bars.CommandBar
        Me.mnuIgnite = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuExtinguish = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuDelete = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuR = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.btnIgnite = New NETXP.Controls.XPButton
        Me.btnN2OIgnite = New NETXP.Controls.XPButton
        Me.btnExtinguish = New NETXP.Controls.XPButton
        Me.btnR = New NETXP.Controls.XPButton
        Me.btnDelete = New NETXP.Controls.XPButton
        Me.CustomPanel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.mnuAutoIgnition, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CustomPanel1
        '
        Me.CustomPanel1.BackColor = System.Drawing.Color.AliceBlue
        Me.CustomPanel1.Controls.Add(Me.Panel2)
        Me.CustomPanel1.Controls.Add(Me.btnClose)
        Me.CustomPanel1.Controls.Add(Me.Panel1)
        Me.CustomPanel1.Controls.Add(Me.txtGainStatus)
        Me.CustomPanel1.Controls.Add(Me.lblGainStatus)
        Me.CustomPanel1.Controls.Add(Me.lblMicroStatus)
        Me.CustomPanel1.Controls.Add(Me.txtMicroStatus)
        Me.CustomPanel1.Controls.Add(Me.Panel3)
        Me.CustomPanel1.Controls.Add(Me.btnIgnite)
        Me.CustomPanel1.Controls.Add(Me.btnN2OIgnite)
        Me.CustomPanel1.Controls.Add(Me.btnExtinguish)
        Me.CustomPanel1.Controls.Add(Me.btnR)
        Me.CustomPanel1.Controls.Add(Me.btnDelete)
        Me.CustomPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CustomPanel1.Location = New System.Drawing.Point(0, 0)
        Me.CustomPanel1.Name = "CustomPanel1"
        Me.CustomPanel1.Size = New System.Drawing.Size(458, 359)
        Me.CustomPanel1.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Controls.Add(Me.txtAvgFactor)
        Me.Panel2.Controls.Add(Me.lblAvgFactor)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.txtPMT)
        Me.Panel2.Controls.Add(Me.lblPMT)
        Me.Panel2.Controls.Add(Me.txtMode)
        Me.Panel2.Controls.Add(Me.lblMode)
        Me.Panel2.Controls.Add(Me.btnAvgValue)
        Me.Panel2.Controls.Add(Me.btnSetMode)
        Me.Panel2.Controls.Add(Me.btnSetPMT)
        Me.Panel2.Controls.Add(Me.TextBox1)
        Me.Panel2.Controls.Add(Me.btnADCFilter)
        Me.Panel2.Location = New System.Drawing.Point(16, 104)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(430, 176)
        Me.Panel2.TabIndex = 1
        '
        'txtAvgFactor
        '
        Me.txtAvgFactor.BackColor = System.Drawing.Color.White
        Me.txtAvgFactor.Enabled = False
        Me.txtAvgFactor.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAvgFactor.ForeColor = System.Drawing.Color.Blue
        Me.txtAvgFactor.Location = New System.Drawing.Point(232, 10)
        Me.txtAvgFactor.Name = "txtAvgFactor"
        Me.txtAvgFactor.Size = New System.Drawing.Size(80, 26)
        Me.txtAvgFactor.TabIndex = 20
        Me.txtAvgFactor.Text = "300"
        Me.txtAvgFactor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblAvgFactor
        '
        Me.lblAvgFactor.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAvgFactor.Location = New System.Drawing.Point(152, 16)
        Me.lblAvgFactor.Name = "lblAvgFactor"
        Me.lblAvgFactor.Size = New System.Drawing.Size(80, 18)
        Me.lblAvgFactor.TabIndex = 19
        Me.lblAvgFactor.Text = "Avg Factor"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.Label2.Location = New System.Drawing.Point(8, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 16)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "(0-1000 Volts)"
        '
        'txtPMT
        '
        Me.txtPMT.BackColor = System.Drawing.Color.White
        Me.txtPMT.Enabled = False
        Me.txtPMT.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPMT.ForeColor = System.Drawing.Color.Blue
        Me.txtPMT.Location = New System.Drawing.Point(98, 48)
        Me.txtPMT.Name = "txtPMT"
        Me.txtPMT.Size = New System.Drawing.Size(80, 26)
        Me.txtPMT.TabIndex = 17
        Me.txtPMT.Text = "0"
        Me.txtPMT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblPMT
        '
        Me.lblPMT.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPMT.Location = New System.Drawing.Point(8, 48)
        Me.lblPMT.Name = "lblPMT"
        Me.lblPMT.Size = New System.Drawing.Size(48, 16)
        Me.lblPMT.TabIndex = 16
        Me.lblPMT.Text = "PMT"
        '
        'txtMode
        '
        Me.txtMode.BackColor = System.Drawing.Color.White
        Me.txtMode.Enabled = False
        Me.txtMode.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMode.ForeColor = System.Drawing.Color.Blue
        Me.txtMode.Location = New System.Drawing.Point(64, 10)
        Me.txtMode.Name = "txtMode"
        Me.txtMode.Size = New System.Drawing.Size(80, 26)
        Me.txtMode.TabIndex = 15
        Me.txtMode.Text = "6"
        Me.txtMode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblMode
        '
        Me.lblMode.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMode.Location = New System.Drawing.Point(8, 16)
        Me.lblMode.Name = "lblMode"
        Me.lblMode.Size = New System.Drawing.Size(54, 16)
        Me.lblMode.TabIndex = 14
        Me.lblMode.Text = "Mode"
        '
        'btnAvgValue
        '
        Me.btnAvgValue.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAvgValue.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAvgValue.Image = CType(resources.GetObject("btnAvgValue.Image"), System.Drawing.Image)
        Me.btnAvgValue.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAvgValue.Location = New System.Drawing.Point(174, 128)
        Me.btnAvgValue.Name = "btnAvgValue"
        Me.btnAvgValue.Size = New System.Drawing.Size(126, 32)
        Me.btnAvgValue.TabIndex = 3
        Me.btnAvgValue.Text = "&Avg Value"
        '
        'btnSetMode
        '
        Me.btnSetMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSetMode.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSetMode.Image = CType(resources.GetObject("btnSetMode.Image"), System.Drawing.Image)
        Me.btnSetMode.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSetMode.Location = New System.Drawing.Point(40, 88)
        Me.btnSetMode.Name = "btnSetMode"
        Me.btnSetMode.Size = New System.Drawing.Size(126, 32)
        Me.btnSetMode.TabIndex = 0
        Me.btnSetMode.Text = "Set &Mode"
        '
        'btnSetPMT
        '
        Me.btnSetPMT.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSetPMT.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSetPMT.Image = CType(resources.GetObject("btnSetPMT.Image"), System.Drawing.Image)
        Me.btnSetPMT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSetPMT.Location = New System.Drawing.Point(40, 128)
        Me.btnSetPMT.Name = "btnSetPMT"
        Me.btnSetPMT.Size = New System.Drawing.Size(126, 32)
        Me.btnSetPMT.TabIndex = 2
        Me.btnSetPMT.Text = "Set &PMT"
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.SystemColors.Control
        Me.TextBox1.Enabled = False
        Me.TextBox1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(320, 5)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(96, 160)
        Me.TextBox1.TabIndex = 13
        Me.TextBox1.Text = "Modes         0 - AA        1 - HCLE    2 - D2E       3 - Emmsn  4 - BGC       5 " & _
        "- MABS    6 - ST "
        '
        'btnADCFilter
        '
        Me.btnADCFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnADCFilter.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnADCFilter.Image = CType(resources.GetObject("btnADCFilter.Image"), System.Drawing.Image)
        Me.btnADCFilter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnADCFilter.Location = New System.Drawing.Point(174, 88)
        Me.btnADCFilter.Name = "btnADCFilter"
        Me.btnADCFilter.Size = New System.Drawing.Size(126, 32)
        Me.btnADCFilter.TabIndex = 1
        Me.btnADCFilter.Text = "ADC Non&Filter"
        Me.btnADCFilter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnClose
        '
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.Location = New System.Drawing.Point(325, 312)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(120, 32)
        Me.btnClose.TabIndex = 0
        Me.btnClose.Text = "C&LOSE"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.lblDEC)
        Me.Panel1.Controls.Add(Me.lblHEX)
        Me.Panel1.Controls.Add(Me.lblMV)
        Me.Panel1.Controls.Add(Me.txtDEC)
        Me.Panel1.Controls.Add(Me.txtHEX)
        Me.Panel1.Controls.Add(Me.txtMv)
        Me.Panel1.Controls.Add(Me.lblFiltered)
        Me.Panel1.Location = New System.Drawing.Point(16, 8)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(430, 88)
        Me.Panel1.TabIndex = 0
        '
        'lblDEC
        '
        Me.lblDEC.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDEC.Location = New System.Drawing.Point(328, 16)
        Me.lblDEC.Name = "lblDEC"
        Me.lblDEC.Size = New System.Drawing.Size(32, 22)
        Me.lblDEC.TabIndex = 7
        Me.lblDEC.Text = "dec"
        '
        'lblHEX
        '
        Me.lblHEX.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHEX.Location = New System.Drawing.Point(224, 16)
        Me.lblHEX.Name = "lblHEX"
        Me.lblHEX.Size = New System.Drawing.Size(32, 16)
        Me.lblHEX.TabIndex = 6
        Me.lblHEX.Text = "hex"
        '
        'lblMV
        '
        Me.lblMV.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMV.Location = New System.Drawing.Point(112, 16)
        Me.lblMV.Name = "lblMV"
        Me.lblMV.Size = New System.Drawing.Size(32, 24)
        Me.lblMV.TabIndex = 5
        Me.lblMV.Text = "mv"
        '
        'txtDEC
        '
        Me.txtDEC.BackColor = System.Drawing.Color.White
        Me.txtDEC.Enabled = False
        Me.txtDEC.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDEC.Location = New System.Drawing.Point(328, 40)
        Me.txtDEC.Name = "txtDEC"
        Me.txtDEC.ReadOnly = True
        Me.txtDEC.Size = New System.Drawing.Size(80, 26)
        Me.txtDEC.TabIndex = 4
        Me.txtDEC.Text = ""
        Me.txtDEC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtHEX
        '
        Me.txtHEX.BackColor = System.Drawing.Color.White
        Me.txtHEX.Enabled = False
        Me.txtHEX.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHEX.Location = New System.Drawing.Point(224, 40)
        Me.txtHEX.Name = "txtHEX"
        Me.txtHEX.ReadOnly = True
        Me.txtHEX.Size = New System.Drawing.Size(80, 26)
        Me.txtHEX.TabIndex = 3
        Me.txtHEX.Text = ""
        Me.txtHEX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtMv
        '
        Me.txtMv.BackColor = System.Drawing.Color.White
        Me.txtMv.Enabled = False
        Me.txtMv.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMv.Location = New System.Drawing.Point(112, 40)
        Me.txtMv.Name = "txtMv"
        Me.txtMv.ReadOnly = True
        Me.txtMv.Size = New System.Drawing.Size(80, 26)
        Me.txtMv.TabIndex = 2
        Me.txtMv.Text = ""
        Me.txtMv.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblFiltered
        '
        Me.lblFiltered.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFiltered.Location = New System.Drawing.Point(0, 40)
        Me.lblFiltered.Name = "lblFiltered"
        Me.lblFiltered.Size = New System.Drawing.Size(104, 24)
        Me.lblFiltered.TabIndex = 1
        Me.lblFiltered.Text = "non filtered"
        '
        'txtGainStatus
        '
        Me.txtGainStatus.BackColor = System.Drawing.Color.White
        Me.txtGainStatus.Enabled = False
        Me.txtGainStatus.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGainStatus.ForeColor = System.Drawing.Color.Blue
        Me.txtGainStatus.Location = New System.Drawing.Point(32, 328)
        Me.txtGainStatus.Name = "txtGainStatus"
        Me.txtGainStatus.Size = New System.Drawing.Size(80, 26)
        Me.txtGainStatus.TabIndex = 18
        Me.txtGainStatus.Text = ""
        Me.txtGainStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblGainStatus
        '
        Me.lblGainStatus.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGainStatus.Location = New System.Drawing.Point(32, 307)
        Me.lblGainStatus.Name = "lblGainStatus"
        Me.lblGainStatus.Size = New System.Drawing.Size(88, 24)
        Me.lblGainStatus.TabIndex = 16
        Me.lblGainStatus.Text = "Gain Status"
        '
        'lblMicroStatus
        '
        Me.lblMicroStatus.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMicroStatus.Location = New System.Drawing.Point(152, 307)
        Me.lblMicroStatus.Name = "lblMicroStatus"
        Me.lblMicroStatus.Size = New System.Drawing.Size(96, 21)
        Me.lblMicroStatus.TabIndex = 17
        Me.lblMicroStatus.Text = "Micro Status"
        '
        'txtMicroStatus
        '
        Me.txtMicroStatus.BackColor = System.Drawing.Color.White
        Me.txtMicroStatus.Enabled = False
        Me.txtMicroStatus.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMicroStatus.ForeColor = System.Drawing.Color.Blue
        Me.txtMicroStatus.Location = New System.Drawing.Point(152, 328)
        Me.txtMicroStatus.Name = "txtMicroStatus"
        Me.txtMicroStatus.Size = New System.Drawing.Size(80, 26)
        Me.txtMicroStatus.TabIndex = 19
        Me.txtMicroStatus.Text = ""
        Me.txtMicroStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.mnuAutoIgnition)
        Me.Panel3.Location = New System.Drawing.Point(96, 400)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(216, 56)
        Me.Panel3.TabIndex = 3
        '
        'mnuAutoIgnition
        '
        Me.mnuAutoIgnition.BackColor = System.Drawing.Color.Transparent
        Me.mnuAutoIgnition.CustomizeText = "&Customize Toolbar..."
        Me.mnuAutoIgnition.FullRow = True
        Me.mnuAutoIgnition.ID = 5117
        Me.mnuAutoIgnition.Items.AddRange(New NETXP.Controls.Bars.CommandBarItem() {Me.mnuIgnite, Me.mnuExtinguish, Me.mnuDelete, Me.mnuR})
        Me.mnuAutoIgnition.Location = New System.Drawing.Point(66, 16)
        Me.mnuAutoIgnition.Margins.Bottom = 1
        Me.mnuAutoIgnition.Margins.Left = 1
        Me.mnuAutoIgnition.Margins.Right = 1
        Me.mnuAutoIgnition.Margins.Top = 1
        Me.mnuAutoIgnition.Name = "mnuAutoIgnition"
        Me.mnuAutoIgnition.Size = New System.Drawing.Size(112, 43)
        Me.mnuAutoIgnition.Style = NETXP.Controls.Bars.CommandBarStyle.Menu
        Me.mnuAutoIgnition.TabIndex = 2
        Me.mnuAutoIgnition.TabStop = False
        Me.mnuAutoIgnition.Text = "AutoIgnition"
        '
        'mnuIgnite
        '
        Me.mnuIgnite.Text = "&Ignite"
        '
        'mnuExtinguish
        '
        Me.mnuExtinguish.PadHorizontal = 5
        Me.mnuExtinguish.Text = "&Extinguish"
        '
        'mnuDelete
        '
        Me.mnuDelete.Text = "&Delete"
        '
        'mnuR
        '
        Me.mnuR.Text = "&R"
        '
        'btnIgnite
        '
        Me.btnIgnite.BackColor = System.Drawing.Color.Transparent
        Me.btnIgnite.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnIgnite.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIgnite.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnIgnite.Location = New System.Drawing.Point(225, 179)
        Me.btnIgnite.Name = "btnIgnite"
        Me.btnIgnite.Size = New System.Drawing.Size(8, 8)
        Me.btnIgnite.TabIndex = 25
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
        Me.btnN2OIgnite.Location = New System.Drawing.Point(241, 179)
        Me.btnN2OIgnite.Name = "btnN2OIgnite"
        Me.btnN2OIgnite.Size = New System.Drawing.Size(8, 8)
        Me.btnN2OIgnite.TabIndex = 27
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
        Me.btnExtinguish.Location = New System.Drawing.Point(209, 179)
        Me.btnExtinguish.Name = "btnExtinguish"
        Me.btnExtinguish.Size = New System.Drawing.Size(8, 8)
        Me.btnExtinguish.TabIndex = 26
        Me.btnExtinguish.TabStop = False
        Me.btnExtinguish.Text = "&Extinguish"
        Me.btnExtinguish.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'btnR
        '
        Me.btnR.BackColor = System.Drawing.Color.Transparent
        Me.btnR.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnR.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnR.Location = New System.Drawing.Point(336, 416)
        Me.btnR.Name = "btnR"
        Me.btnR.Size = New System.Drawing.Size(8, 8)
        Me.btnR.TabIndex = 23
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
        Me.btnDelete.Location = New System.Drawing.Point(320, 416)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(8, 8)
        Me.btnDelete.TabIndex = 24
        Me.btnDelete.TabStop = False
        Me.btnDelete.Text = "&Delete"
        Me.btnDelete.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'frmAnalog
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(458, 359)
        Me.Controls.Add(Me.CustomPanel1)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAnalog"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Analog"
        Me.CustomPanel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        CType(Me.mnuAutoIgnition, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Variables"
    Private WithEvents mobjfrmEditValues As frmEditValues
    Private mintValue As Integer
    Private mblnFlag = False
    Private mblnADCFlag As Boolean
    Private mblnInProcess As Boolean = False
    Private mblnStatus As Boolean = False
#End Region

#Region "Constants"
    Private Const ConstSetPMT = "PMT volts(0 - 1000)v"
    Private Const ConstSetMODE = "Enter Mode"
    Private Const constAvgValue = "Avg Value"

    Private Enum EnumOperation
        OperationNo = 0
        OperationMode = 1
        OperationPMT = 2
        OperationAvgValue = 3
        OperationExit = 4
    End Enum
    Private m_Operation As EnumOperation = EnumOperation.OperationNo
    Private m_OperationExit As EnumOperation = EnumOperation.OperationNo 'by pankaj on 16.1.08

#End Region

#Region "Properties"
    Private Property InputValue() As Integer
        ''this is a property for temp storing a inputvalue

        Get
            Return mintValue
        End Get
        Set(ByVal Value As Integer)
            mintValue = Value
        End Set
    End Property
#End Region

#Region "Form Events"

    Private Sub frmAnalog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '=====================================================================
        ' Procedure Name        : frmAnalog_Load
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To initialize the form
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 22.11.06
        ' Revisions             : Deepak on 15.01.07
        '=====================================================================

        ''this is called when the analog form is loaded
        ''add all, the event handler here
        ''initialize the form


        Dim objWait As New CWaitCursor
        Dim dblmv As Double
        Try
            'If gobjCommProtocol.funcReadADCNonFilter(dblmv) = True Then
            'mblnStatus = True
            mblnADCFlag = True
            btnADCFilter.Text = "ADC &Filter"
            Call AddHandlers()
            ''for adding a eventhandler

            If gstructSettings.D2Gain = True Then
                txtGainStatus.Text = "ON"
            Else
                txtGainStatus.Text = "OFF"
            End If

            If gstructSettings.Mesh = True Then
                txtMicroStatus.Text = "ON"
            Else
                txtMicroStatus.Text = "OFF"
            End If
            Me.Refresh()
            btnSetMode.Focus()
            txtPMT.Text = CInt(gobjInst.PmtVoltage)
            ''get a pmt voltage from gobjInst object to text box
            txtMode.Text = gobjInst.Mode
            txtAvgFactor.Text = gobjInst.Average
            Application.DoEvents()
            'Else
            '   Me.Close()
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

            ''note:
            ''this is used for adding event handler


            'AddHandler btnOk.Click, AddressOf btnOk_Click
            AddHandler btnClose.Click, AddressOf btnClose_Click
            AddHandler btnADCFilter.Click, AddressOf btnADCFilter_Click
            'AddHandler btnADCNonFilter.Click, AddressOf btnADCNonFilter_Click
            AddHandler btnAvgValue.Click, AddressOf btnAvgValue_Click
            AddHandler btnSetMode.Click, AddressOf btnSetMode_Click
            AddHandler btnSetPMT.Click, AddressOf btnSetPMT_Click
            AddHandler MyBase.Activated, AddressOf frmAnalog_Activated
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

        ''this is called when user  click on OK button
        ''this handle the OK button event


        Dim objWait As New CWaitCursor
        Try
            'If gblnInComm = False Then
            Me.DialogResult = DialogResult.OK
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
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : btnClose_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To send dialog result as Close
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 27.11.06
        ' Revisions             : 
        '=====================================================================


        ''note:
        ''this is called when click on cancel button 

        Try
            'blnFlag = True
            m_Operation = EnumOperation.OperationExit
            m_OperationExit = EnumOperation.OperationExit
            Me.DialogResult = DialogResult.Cancel
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

    'Private Sub btnADCNonFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    '=====================================================================
    '    ' Procedure Name        : btnADCNonFilter_Click
    '    ' Parameters Passed     : Object,EventArgs
    '    ' Returns               : None
    '    ' Purpose               : To position the Turret at said position from current position 
    '    ' Description           : 
    '    ' Assumptions           : 
    '    ' Dependencies          : 
    '    ' Author                : Saurabh S
    '    ' Created               : 21.11.06
    '    ' Revisions             : 
    '    '=====================================================================
    '    Dim objWait As New CWaitCursor
    '    Dim dblmv As Double
    '    Dim intAvgFactor As Integer
    '    Try
    '        If blnADCFlag = True Then
    '            lblFiltered.Text = "filtered"
    '            blnFlag = True
    '            Application.DoEvents()

    '            If txtAvgFactor.Text = "" Then
    '                gobjMessageAdapter.ShowMessage(constInputProperData)
    '                Application.DoEvents()
    '            Else
    '                intAvgFactor = CInt(txtAvgFactor.Text)
    '                Application.DoEvents()
    '                If gobjClsAAS203.funcbtnADCFilter(intAvgFactor, dblmv) = True Then
    '                    txtDEC.Text = CDbl(dblmv)
    '                    txtMv.Text = gFuncGetmv(CInt(dblmv))
    '                    txtHEX.Text = Hex(dblmv)
    '                    Application.DoEvents()
    '                End If
    '            End If
    '            blnADCFlag = False
    '        Else
    '            lblFiltered.Text = "non filtered"
    '            Do
    '                Call funcADCNonFilter()
    '                If blnFlag = True Then
    '                    Exit Do
    '                End If
    '                Application.DoEvents()
    '            Loop
    '            blnADCFlag = True
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

    Private Sub btnAvgValue_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : btnAvgValue_Click
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
        ''this is called when user click on Avg Value button
        ''step 1: first show the edit value for input
        ''step 2: take a input in to a variable and validate it
        ''step 3: after validation ,if validation is succes then store it in gobjInst.Average object 
        ''else through error




        Dim objWait As New CWaitCursor
        Dim intAvgValue As Integer
        Try
            If mblnInProcess = True Then
                Exit Sub
            End If
            mblnInProcess = True
            mblnFlag = True
            mobjfrmEditValues = New frmEditValues
            mobjfrmEditValues.LabelText = constAvgValue
            mobjfrmEditValues.txtValue.Visible = True

            mobjfrmEditValues.txtValue.ValidationType = NumberValidator.NumberValidator.Validations.IntegerOnly
            mobjfrmEditValues.txtValue.RangeValidation = True
            mobjfrmEditValues.txtValue.MaxLength = 3
            mobjfrmEditValues.txtValue.MinimumRange = 1
            mobjfrmEditValues.txtValue.MaximumRange = 999
            mobjfrmEditValues.txtValue.Focus()
            mobjfrmEditValues.txtValue.SelectAll()

            mobjfrmEditValues.txtValue.Text = gobjInst.Average
            If mobjfrmEditValues.ShowDialog = DialogResult.Cancel Then
                Application.DoEvents()
                mobjfrmEditValues.Dispose()
                Exit Sub
            End If

            '''Added by praveen for validation
            'If IsNumeric(mobjfrmEditValues.txtValue.Text) Then
            '    InputValue = mobjfrmEditValues.txtValue.Text
            '    If InputValue < mobjfrmEditValues.txtValue.MinimumRange Then
            '        InputValue = mobjfrmEditValues.txtValue.MinimumRange
            '    ElseIf InputValue > mobjfrmEditValues.txtValue.MaximumRange Then
            '        InputValue = mobjfrmEditValues.txtValue.MaximumRange
            '    Else
            '        InputValue = mobjfrmEditValues.txtValue.Text
            '    End If
            'Else
            '    InputValue = mobjfrmEditValues.txtValue.MinimumRange
            'End If
            '''Ended by praveen
            Application.DoEvents()
            txtAvgFactor.Text = CInt(InputValue)
            txtAvgFactor.Refresh()
            mobjfrmEditValues.Dispose()
            gobjInst.Average = CInt(InputValue)
            'm_Operation = EnumOperation.OperationAvgValue

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
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
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub btnSetMode_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : btnSetMode_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To set instrument mode
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 21.11.06
        ' Revisions             : 
        '=====================================================================
        ''note:
        ''this is called when user click on Set mode button
        ''step 1: first show the edit value for input
        ''step 2: take a input in to a variable and validate it
        ''step 3: after validation ,if validation is succes then store it in gobjInst.Average object 
        ''else through error

        ''as par the list of mode send a int value



        Dim objWait As New CWaitCursor
        Dim byteSetMode As Byte
        Try
            If mblnInProcess = True Then
                Exit Sub
            End If
            mblnInProcess = True
            mblnFlag = True
            mobjfrmEditValues = New frmEditValues
            ' Application.DoEvents()

            mobjfrmEditValues.LabelText = ConstSetMODE
            mobjfrmEditValues.txtValue.Visible = True

            mobjfrmEditValues.txtValue.ValidationType = NumberValidator.NumberValidator.Validations.DoubleOnly

            mobjfrmEditValues.txtValue.RangeValidation = True
            mobjfrmEditValues.txtValue.MaxLength = 1
            mobjfrmEditValues.txtValue.MinimumRange = 0
            mobjfrmEditValues.txtValue.MaximumRange = 6
            mobjfrmEditValues.txtValue.SelectAll()
            mobjfrmEditValues.txtValue.Text = gobjInst.Mode
            If mobjfrmEditValues.ShowDialog = DialogResult.Cancel Then
                Application.DoEvents()
                mobjfrmEditValues.Dispose()
                Exit Sub
            End If
            '''Added by praveen for validation
            'If IsNumeric(mobjfrmEditValues.txtValue.Text) Then
            '    InputValue = mobjfrmEditValues.txtValue.Text
            '    If InputValue < mobjfrmEditValues.txtValue.MinimumRange Then
            '        InputValue = mobjfrmEditValues.txtValue.MinimumRange
            '    ElseIf InputValue > mobjfrmEditValues.txtValue.MaximumRange Then
            '        InputValue = mobjfrmEditValues.txtValue.MaximumRange
            '    Else
            '        InputValue = mobjfrmEditValues.txtValue.Text
            '    End If
            'Else
            '    InputValue = mobjfrmEditValues.txtValue.MinimumRange
            'End If
            '''Ended by praveen


            Application.DoEvents()
            txtMode.Text = CByte(InputValue)
            txtMode.Refresh()
            mobjfrmEditValues.Dispose()
            gobjInst.Mode = CByte(InputValue)
            m_Operation = EnumOperation.OperationMode


        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
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
            'Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub btnSetPMT_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : btnSetPMT_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 21.11.06
        ' Revisions             : Deepak B. on 15.01.07
        '=====================================================================
        ''note:
        ''this is called when user click on set PMT button
        ''step 1: first show the edit value for input
        ''step 2: take a input in to a variable and validate it
        ''step 3: after validation ,if validation is succes then store it in gobjInst.Average object 
        ''else through error



        Dim objWait As New CWaitCursor
        Dim dblPMT As Double
        Try
            If mblnInProcess = True Then
                Exit Sub
            End If
            mblnInProcess = True
            mblnFlag = True
            mobjfrmEditValues = New frmEditValues
            ' Application.DoEvents()

            mobjfrmEditValues.LabelText = ConstSetPMT
            mobjfrmEditValues.txtValue.Visible = True

            mobjfrmEditValues.txtValue.ValidationType = NumberValidator.NumberValidator.Validations.IntegerOnly
            mobjfrmEditValues.txtValue.RangeValidation = True
            mobjfrmEditValues.txtValue.MaxLength = 4
            mobjfrmEditValues.txtValue.MinimumRange = 0
            mobjfrmEditValues.txtValue.MaximumRange = 1000
            mobjfrmEditValues.txtValue.Focus()
            mobjfrmEditValues.txtValue.SelectAll()
            mobjfrmEditValues.txtValue.Text = CInt(gobjInst.PmtVoltage)
            If mobjfrmEditValues.ShowDialog = DialogResult.Cancel Then
                Application.DoEvents()
                mobjfrmEditValues.Dispose()
                Exit Sub
            End If
            '''Adeed by praveen
            'If IsNumeric(mobjfrmEditValues.txtValue.Text) Then
            '    InputValue = mobjfrmEditValues.txtValue.Text
            '    If InputValue < mobjfrmEditValues.txtValue.MinimumRange Then
            '        InputValue = mobjfrmEditValues.txtValue.MinimumRange
            '    ElseIf InputValue > mobjfrmEditValues.txtValue.MaximumRange Then
            '        InputValue = mobjfrmEditValues.txtValue.MaximumRange
            '    Else
            '        InputValue = mobjfrmEditValues.txtValue.Text
            '    End If
            'Else
            '    InputValue = mobjfrmEditValues.txtValue.MinimumRange
            'End If
            '''Ended by praveen
            Application.DoEvents()
            dblPMT = CDbl(InputValue)
            If dblPMT < 0 Or dblPMT > 1000 Then
                gobjMessageAdapter.ShowMessage(constPMTRange)
                'MsgBox("PMT value should be between 0 and 1000")
                Exit Sub
            End If
            txtPMT.Text = CDbl(InputValue)
            txtPMT.Refresh()
            mobjfrmEditValues.Dispose()
            gobjInst.PmtVoltage = CDbl(InputValue)
            m_Operation = EnumOperation.OperationPMT

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
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
            'Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub btnADCFilter_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : btnADCFilter_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To read ADC count for filtered data.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 21.11.06
        ' Revisions             : 
        '=====================================================================

        ''note:
        ''this is called when user clicked on ADC filter button
        ''mblnADCFlag is a bool flag which later used in a software
        ''and mblnADCFlag is true


        Dim objWait As New CWaitCursor
        Dim dblmv As Double
        Dim intAvgFactor As Integer
        Try
            If mblnADCFlag = True Then
                ''and mblnADCFlag is true then
                lblFiltered.Text = "Filtered"
                btnADCFilter.Text = "ADC &NonFilter"
                'blnFlag = True
                mblnADCFlag = False

            Else
                'else
                lblFiltered.Text = "Non Filtered"
                btnADCFilter.Text = "ADC &Filter"

                mblnADCFlag = True
                'Application.DoEvents()
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
        ''this is called when user click on AutoIgnition button


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
            '''function for auto ignition 
            ''here we are sending True in parameter fpr ignition ON.


        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
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
            'mblnInProcess = False
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
        ''this is used for putting ignition off
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
            ''here we sre passing False for ignition OFF.

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
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
            'mblnInProcess = False
            AddHandler mnuExtinguish.Click, AddressOf btnExtinguish_Click
            '---------------------------------------------------------
        End Try
    End Sub

    Private Function funcADCNonFilter()
        '=====================================================================
        ' Procedure Name        : funcADCNonFilter
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To show the ADC Non Filter values.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 23.01.07
        ' Revisions             : 
        '=====================================================================
        'Dim objWait As New CWaitCursor
        Dim dblmv As Double
        Try
            If mblnInProcess = True Then
                Exit Function
            End If
            If gobjClsAAS203.funcbtnADCNonFilter(dblmv) = True Then
                ''To get the value of ADC Non Filter.
                txtDEC.Text = CDbl(dblmv)
                txtHEX.Text = Hex(dblmv)
                txtMv.Text = Format(gFuncGetmv(CInt(dblmv)), "0.00")
                txtDEC.Refresh()
                txtHEX.Refresh()
                txtMv.Refresh()
                'Application.DoEvents()
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
    End Function

    Private Function funcADCFilter()
        '=====================================================================
        ' Procedure Name        : funcADCFilter
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To show the ADC Filter values.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 23.01.07
        ' Revisions             : 
        '=====================================================================
        'Dim objWait As New CWaitCursor
        Dim dblmv As Double
        Dim intAvgFactor As Integer
        Try
            If mblnInProcess = True Then
                Exit Function
            End If
            intAvgFactor = CInt(txtAvgFactor.Text)
            If intAvgFactor < 1 Then
                Exit Function
            End If
            If gobjClsAAS203.funcbtnADCFilter(intAvgFactor, dblmv) = True Then
                ''To get the value of ADC Non Filter.
                txtDEC.Text = CDbl(dblmv)
                txtMv.Text = Format(gFuncGetmv(CInt(dblmv)), "0.00")
                txtHEX.Text = Hex(dblmv)
                txtDEC.Refresh()
                txtHEX.Refresh()
                txtMv.Refresh()
                'Application.DoEvents()
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
    End Function

    Private Sub mobjfrmEditValues_ReturnValue(ByVal dblValue As Double, ByVal intvalue1 As Integer) Handles mobjfrmEditValues.ReturnValue
        '=====================================================================
        ' Procedure Name        : mobjfrmEditValues_ReturnValue
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To get the values from EditValues form.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 23.01.07
        ' Revisions             : 
        '=====================================================================
        ''this is called for accepting the value form Edit form

        Try
            InputValue = CLng(dblValue)
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
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

    Private Sub frmAnalog_Activated(ByVal sender As Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : frmAnalog_Activated
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To show the ADC values on form load.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 23.01.07
        ' Revisions             : 
        '=====================================================================
        'Dim objWait As CWaitCursor
        ''this is called during the loading of a form
        ''this will show some initial value on screen
        Dim dblmv As Double
        Try
            'If mblnStatus = True Then
            If gobjCommProtocol.funcReadADCNonFilter(dblmv) = True Then
                RemoveHandler MyBase.Activated, AddressOf frmAnalog_Activated
                Do
                    If gblnInComm = False Then
                        If m_OperationExit = EnumOperation.OperationExit Then 'by pankaj on 16.1.08
                            Exit Do
                        End If
                        Select Case m_Operation
                            Case EnumOperation.OperationMode
                                'objWait = New CWaitCursor
                                Call funcSetMode(CByte(InputValue))
                            Case EnumOperation.OperationPMT
                                'objWait = New CWaitCursor
                                Call funcSetPMT(CDbl(InputValue))
                            Case EnumOperation.OperationNo
                                If mblnADCFlag = True Then
                                    Call funcADCNonFilter()
                                Else
                                    Call funcADCFilter()
                                End If
                            Case EnumOperation.OperationExit
                                'objWait = New CWaitCursor
                                Exit Do

                        End Select
                    End If
                    mblnInProcess = False
                    m_Operation = EnumOperation.OperationNo
                    'If Not objWait Is Nothing Then
                    '    objWait.Dispose()
                    'End If
                    gobjCommProtocol.mobjCommdll.subTime_Delay(100)
                    Application.DoEvents()
                Loop
                Me.DialogResult = DialogResult.Cancel
                Me.Close()
            Else
                Me.DialogResult = DialogResult.Cancel
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
            Application.DoEvents()
            '---------------------------------------------------------
        End Try

    End Sub

    Private Function funcSetMode(ByVal byteSetMode As Byte)
        '=====================================================================
        ' Procedure Name        : funcSetMode
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To set the Mode.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 23.01.07
        ' Revisions             : 
        '=====================================================================
        ''note:
        'this is used for setting a given mode to the instrument

        Dim objWait As New CWaitCursor
        Try
            If gobjClsAAS203.funcbtnSetMode(byteSetMode) = True Then
                ''function for setting a mode to instrument 
                ''here we have to pass the mode to be selected
                txtMode.Text = CByte(byteSetMode)
                txtMode.Refresh()
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

    End Function

    Private Function funcSetPMT(ByVal dblPMT As Double)
        '=====================================================================
        ' Procedure Name        : funcSetPMT
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To set the PMT.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 23.01.07
        ' Revisions             : 
        '=====================================================================
        ''note:
        'this is used for setting the PMT to the instrument

        Dim objWait As New CWaitCursor
        Try
            If gobjClsAAS203.funcbtnSet_PMT(dblPMT) = True Then
                ''function used ofr setting the PMT value
                txtPMT.Text = CDbl(dblPMT)
                txtPMT.Refresh()
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

    End Function

    Private Sub btnN2OIgnite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If mblnInProcess = True Then
            Exit Sub
        End If

        Try
            mblnInProcess = True
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
            'Alt - R
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
