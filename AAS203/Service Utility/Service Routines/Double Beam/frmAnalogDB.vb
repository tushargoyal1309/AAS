Imports AAS203.Common

Public Class frmAnalogDB
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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblPMT_Ref As System.Windows.Forms.Label
    Friend WithEvents btnIgnite As NETXP.Controls.XPButton
    Friend WithEvents btnN2OIgnite As NETXP.Controls.XPButton
    Friend WithEvents btnExtinguish As NETXP.Controls.XPButton
    Friend WithEvents btnDelete As NETXP.Controls.XPButton
    Friend WithEvents btnR As NETXP.Controls.XPButton
    Friend WithEvents grpBeamType As System.Windows.Forms.GroupBox
    Friend WithEvents btnRef As System.Windows.Forms.RadioButton
    Friend WithEvents btnSample As System.Windows.Forms.RadioButton
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmAnalogDB))
        Me.CustomPanel1 = New GradientPanel.CustomPanel
        Me.grpBeamType = New System.Windows.Forms.GroupBox
        Me.btnRef = New System.Windows.Forms.RadioButton
        Me.btnSample = New System.Windows.Forms.RadioButton
        Me.btnClose = New NETXP.Controls.XPButton
        Me.txtMicroStatus = New System.Windows.Forms.TextBox
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.lblPMT_Ref = New System.Windows.Forms.Label
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.txtDEC = New System.Windows.Forms.TextBox
        Me.txtHEX = New System.Windows.Forms.TextBox
        Me.txtMv = New System.Windows.Forms.TextBox
        Me.lblDEC = New System.Windows.Forms.Label
        Me.lblHEX = New System.Windows.Forms.Label
        Me.lblMV = New System.Windows.Forms.Label
        Me.lblFiltered = New System.Windows.Forms.Label
        Me.txtGainStatus = New System.Windows.Forms.TextBox
        Me.lblGainStatus = New System.Windows.Forms.Label
        Me.lblMicroStatus = New System.Windows.Forms.Label
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.mnuAutoIgnition = New NETXP.Controls.Bars.CommandBar
        Me.mnuIgnite = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.mnuExtinguish = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.btnDelete = New NETXP.Controls.XPButton
        Me.btnR = New NETXP.Controls.XPButton
        Me.btnN2OIgnite = New NETXP.Controls.XPButton
        Me.btnExtinguish = New NETXP.Controls.XPButton
        Me.btnIgnite = New NETXP.Controls.XPButton
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.CustomPanel1.SuspendLayout()
        Me.grpBeamType.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.mnuAutoIgnition, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CustomPanel1
        '
        Me.CustomPanel1.BackColor = System.Drawing.Color.AliceBlue
        Me.CustomPanel1.Controls.Add(Me.grpBeamType)
        Me.CustomPanel1.Controls.Add(Me.btnClose)
        Me.CustomPanel1.Controls.Add(Me.txtMicroStatus)
        Me.CustomPanel1.Controls.Add(Me.Panel2)
        Me.CustomPanel1.Controls.Add(Me.Panel1)
        Me.CustomPanel1.Controls.Add(Me.txtGainStatus)
        Me.CustomPanel1.Controls.Add(Me.lblGainStatus)
        Me.CustomPanel1.Controls.Add(Me.lblMicroStatus)
        Me.CustomPanel1.Controls.Add(Me.Panel3)
        Me.CustomPanel1.Controls.Add(Me.btnDelete)
        Me.CustomPanel1.Controls.Add(Me.btnR)
        Me.CustomPanel1.Controls.Add(Me.btnN2OIgnite)
        Me.CustomPanel1.Controls.Add(Me.btnExtinguish)
        Me.CustomPanel1.Controls.Add(Me.btnIgnite)
        Me.CustomPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CustomPanel1.Location = New System.Drawing.Point(0, 0)
        Me.CustomPanel1.Name = "CustomPanel1"
        Me.CustomPanel1.Size = New System.Drawing.Size(458, 375)
        Me.CustomPanel1.TabIndex = 0
        '
        'grpBeamType
        '
        Me.grpBeamType.Controls.Add(Me.btnRef)
        Me.grpBeamType.Controls.Add(Me.btnSample)
        Me.grpBeamType.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpBeamType.Location = New System.Drawing.Point(16, 306)
        Me.grpBeamType.Name = "grpBeamType"
        Me.grpBeamType.Size = New System.Drawing.Size(128, 59)
        Me.grpBeamType.TabIndex = 63
        Me.grpBeamType.TabStop = False
        Me.grpBeamType.Text = "Beam Type"
        '
        'btnRef
        '
        Me.btnRef.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRef.Location = New System.Drawing.Point(8, 37)
        Me.btnRef.Name = "btnRef"
        Me.btnRef.Size = New System.Drawing.Size(120, 18)
        Me.btnRef.TabIndex = 1
        Me.btnRef.Text = "Reference Beam"
        '
        'btnSample
        '
        Me.btnSample.Checked = True
        Me.btnSample.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSample.Location = New System.Drawing.Point(8, 14)
        Me.btnSample.Name = "btnSample"
        Me.btnSample.TabIndex = 0
        Me.btnSample.TabStop = True
        Me.btnSample.Text = "Sample Beam"
        '
        'btnClose
        '
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.Location = New System.Drawing.Point(351, 332)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(96, 32)
        Me.btnClose.TabIndex = 11
        Me.btnClose.Text = "C&LOSE"
        '
        'txtMicroStatus
        '
        Me.txtMicroStatus.BackColor = System.Drawing.Color.White
        Me.txtMicroStatus.Enabled = False
        Me.txtMicroStatus.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMicroStatus.ForeColor = System.Drawing.Color.Blue
        Me.txtMicroStatus.Location = New System.Drawing.Point(256, 339)
        Me.txtMicroStatus.Name = "txtMicroStatus"
        Me.txtMicroStatus.Size = New System.Drawing.Size(80, 26)
        Me.txtMicroStatus.TabIndex = 19
        Me.txtMicroStatus.Text = ""
        Me.txtMicroStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Controls.Add(Me.lblPMT_Ref)
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
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Location = New System.Drawing.Point(16, 104)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(430, 192)
        Me.Panel2.TabIndex = 1
        '
        'lblPMT_Ref
        '
        Me.lblPMT_Ref.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPMT_Ref.Location = New System.Drawing.Point(96, 57)
        Me.lblPMT_Ref.Name = "lblPMT_Ref"
        Me.lblPMT_Ref.Size = New System.Drawing.Size(40, 16)
        Me.lblPMT_Ref.TabIndex = 22
        Me.lblPMT_Ref.Text = "PMT"
        Me.lblPMT_Ref.Visible = False
        '
        'txtAvgFactor
        '
        Me.txtAvgFactor.BackColor = System.Drawing.Color.White
        Me.txtAvgFactor.Enabled = False
        Me.txtAvgFactor.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAvgFactor.ForeColor = System.Drawing.Color.Blue
        Me.txtAvgFactor.Location = New System.Drawing.Point(232, 16)
        Me.txtAvgFactor.Name = "txtAvgFactor"
        Me.txtAvgFactor.Size = New System.Drawing.Size(80, 26)
        Me.txtAvgFactor.TabIndex = 20
        Me.txtAvgFactor.Text = "300"
        Me.txtAvgFactor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblAvgFactor
        '
        Me.lblAvgFactor.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAvgFactor.Location = New System.Drawing.Point(163, 19)
        Me.lblAvgFactor.Name = "lblAvgFactor"
        Me.lblAvgFactor.Size = New System.Drawing.Size(72, 18)
        Me.lblAvgFactor.TabIndex = 19
        Me.lblAvgFactor.Text = "Avg Factor"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.Label2.Location = New System.Drawing.Point(96, 76)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 16)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "(0-1000 mV)"
        '
        'txtPMT
        '
        Me.txtPMT.BackColor = System.Drawing.Color.White
        Me.txtPMT.Enabled = False
        Me.txtPMT.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPMT.ForeColor = System.Drawing.Color.Blue
        Me.txtPMT.Location = New System.Drawing.Point(176, 60)
        Me.txtPMT.Name = "txtPMT"
        Me.txtPMT.Size = New System.Drawing.Size(80, 26)
        Me.txtPMT.TabIndex = 17
        Me.txtPMT.Text = "0"
        Me.txtPMT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblPMT
        '
        Me.lblPMT.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPMT.Location = New System.Drawing.Point(96, 60)
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
        Me.txtMode.Location = New System.Drawing.Point(64, 16)
        Me.txtMode.Name = "txtMode"
        Me.txtMode.Size = New System.Drawing.Size(80, 26)
        Me.txtMode.TabIndex = 15
        Me.txtMode.Text = "6"
        Me.txtMode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblMode
        '
        Me.lblMode.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMode.Location = New System.Drawing.Point(24, 21)
        Me.lblMode.Name = "lblMode"
        Me.lblMode.Size = New System.Drawing.Size(40, 16)
        Me.lblMode.TabIndex = 14
        Me.lblMode.Text = "Mode"
        '
        'btnAvgValue
        '
        Me.btnAvgValue.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAvgValue.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAvgValue.Image = CType(resources.GetObject("btnAvgValue.Image"), System.Drawing.Image)
        Me.btnAvgValue.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAvgValue.Location = New System.Drawing.Point(176, 104)
        Me.btnAvgValue.Name = "btnAvgValue"
        Me.btnAvgValue.Size = New System.Drawing.Size(136, 32)
        Me.btnAvgValue.TabIndex = 9
        Me.btnAvgValue.Text = "&Avg Value"
        '
        'btnSetMode
        '
        Me.btnSetMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSetMode.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSetMode.Image = CType(resources.GetObject("btnSetMode.Image"), System.Drawing.Image)
        Me.btnSetMode.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSetMode.Location = New System.Drawing.Point(24, 144)
        Me.btnSetMode.Name = "btnSetMode"
        Me.btnSetMode.Size = New System.Drawing.Size(120, 32)
        Me.btnSetMode.TabIndex = 2
        Me.btnSetMode.Text = "Set &Mode"
        '
        'btnSetPMT
        '
        Me.btnSetPMT.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSetPMT.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSetPMT.Image = CType(resources.GetObject("btnSetPMT.Image"), System.Drawing.Image)
        Me.btnSetPMT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSetPMT.Location = New System.Drawing.Point(24, 104)
        Me.btnSetPMT.Name = "btnSetPMT"
        Me.btnSetPMT.Size = New System.Drawing.Size(120, 32)
        Me.btnSetPMT.TabIndex = 0
        Me.btnSetPMT.Text = "Sample &PMT"
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.SystemColors.Control
        Me.TextBox1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(320, 16)
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
        Me.btnADCFilter.Location = New System.Drawing.Point(176, 144)
        Me.btnADCFilter.Name = "btnADCFilter"
        Me.btnADCFilter.Size = New System.Drawing.Size(136, 32)
        Me.btnADCFilter.TabIndex = 12
        Me.btnADCFilter.Text = "ADC &Filter"
        Me.btnADCFilter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.Label1.Location = New System.Drawing.Point(96, 75)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 16)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "(0-1000 mV)"
        Me.Label1.Visible = False
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.txtDEC)
        Me.Panel1.Controls.Add(Me.txtHEX)
        Me.Panel1.Controls.Add(Me.txtMv)
        Me.Panel1.Controls.Add(Me.lblDEC)
        Me.Panel1.Controls.Add(Me.lblHEX)
        Me.Panel1.Controls.Add(Me.lblMV)
        Me.Panel1.Controls.Add(Me.lblFiltered)
        Me.Panel1.Location = New System.Drawing.Point(16, 8)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(430, 88)
        Me.Panel1.TabIndex = 0
        '
        'txtDEC
        '
        Me.txtDEC.BackColor = System.Drawing.Color.White
        Me.txtDEC.Enabled = False
        Me.txtDEC.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDEC.Location = New System.Drawing.Point(336, 34)
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
        Me.txtHEX.Location = New System.Drawing.Point(248, 34)
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
        Me.txtMv.Location = New System.Drawing.Point(160, 36)
        Me.txtMv.Name = "txtMv"
        Me.txtMv.ReadOnly = True
        Me.txtMv.Size = New System.Drawing.Size(80, 26)
        Me.txtMv.TabIndex = 2
        Me.txtMv.Text = ""
        Me.txtMv.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblDEC
        '
        Me.lblDEC.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDEC.Location = New System.Drawing.Point(328, 2)
        Me.lblDEC.Name = "lblDEC"
        Me.lblDEC.Size = New System.Drawing.Size(32, 22)
        Me.lblDEC.TabIndex = 7
        Me.lblDEC.Text = "dec"
        '
        'lblHEX
        '
        Me.lblHEX.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHEX.Location = New System.Drawing.Point(248, 2)
        Me.lblHEX.Name = "lblHEX"
        Me.lblHEX.Size = New System.Drawing.Size(32, 16)
        Me.lblHEX.TabIndex = 6
        Me.lblHEX.Text = "hex"
        '
        'lblMV
        '
        Me.lblMV.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMV.Location = New System.Drawing.Point(160, 2)
        Me.lblMV.Name = "lblMV"
        Me.lblMV.Size = New System.Drawing.Size(32, 18)
        Me.lblMV.TabIndex = 5
        Me.lblMV.Text = "mv"
        '
        'lblFiltered
        '
        Me.lblFiltered.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFiltered.Location = New System.Drawing.Point(7, 34)
        Me.lblFiltered.Name = "lblFiltered"
        Me.lblFiltered.Size = New System.Drawing.Size(141, 24)
        Me.lblFiltered.TabIndex = 1
        Me.lblFiltered.Text = "Non Filtered (Sample)"
        '
        'txtGainStatus
        '
        Me.txtGainStatus.BackColor = System.Drawing.Color.White
        Me.txtGainStatus.Enabled = False
        Me.txtGainStatus.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGainStatus.ForeColor = System.Drawing.Color.Blue
        Me.txtGainStatus.Location = New System.Drawing.Point(160, 339)
        Me.txtGainStatus.Name = "txtGainStatus"
        Me.txtGainStatus.Size = New System.Drawing.Size(80, 26)
        Me.txtGainStatus.TabIndex = 18
        Me.txtGainStatus.Text = ""
        Me.txtGainStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblGainStatus
        '
        Me.lblGainStatus.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGainStatus.Location = New System.Drawing.Point(160, 311)
        Me.lblGainStatus.Name = "lblGainStatus"
        Me.lblGainStatus.Size = New System.Drawing.Size(80, 24)
        Me.lblGainStatus.TabIndex = 16
        Me.lblGainStatus.Text = "Gain Status"
        '
        'lblMicroStatus
        '
        Me.lblMicroStatus.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMicroStatus.Location = New System.Drawing.Point(256, 311)
        Me.lblMicroStatus.Name = "lblMicroStatus"
        Me.lblMicroStatus.Size = New System.Drawing.Size(80, 24)
        Me.lblMicroStatus.TabIndex = 17
        Me.lblMicroStatus.Text = "Micro Status"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.mnuAutoIgnition)
        Me.Panel3.Location = New System.Drawing.Point(112, 400)
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
        'btnDelete
        '
        Me.btnDelete.BackColor = System.Drawing.Color.Transparent
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelete.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDelete.Location = New System.Drawing.Point(219, 179)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(8, 8)
        Me.btnDelete.TabIndex = 24
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
        Me.btnR.Location = New System.Drawing.Point(231, 179)
        Me.btnR.Name = "btnR"
        Me.btnR.Size = New System.Drawing.Size(8, 8)
        Me.btnR.TabIndex = 23
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
        Me.btnN2OIgnite.Location = New System.Drawing.Point(241, 179)
        Me.btnN2OIgnite.Name = "btnN2OIgnite"
        Me.btnN2OIgnite.Size = New System.Drawing.Size(8, 8)
        Me.btnN2OIgnite.TabIndex = 22
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
        Me.btnExtinguish.TabIndex = 21
        Me.btnExtinguish.TabStop = False
        Me.btnExtinguish.Text = "&Extinguish"
        Me.btnExtinguish.TextAlign = System.Drawing.ContentAlignment.TopLeft
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
        Me.btnIgnite.TabIndex = 20
        Me.btnIgnite.TabStop = False
        Me.btnIgnite.Text = "&Ignition"
        Me.btnIgnite.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'Timer1
        '
        Me.Timer1.Interval = 200
        '
        'frmAnalogDB
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(458, 375)
        Me.Controls.Add(Me.CustomPanel1)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAnalogDB"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Analog"
        Me.CustomPanel1.ResumeLayout(False)
        Me.grpBeamType.ResumeLayout(False)
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
    Private blnFlag = False
    'Private mblnInProcess As Boolean = False
    Private mblnStatus As Boolean = False

    Private mblnIsRefBeamType As Boolean = False
    Private mblnADCFilterFlag As Boolean = False
    Private mblnExit As Boolean = False
    Private mblnAvoidProcessing As Boolean
#End Region

#Region "Constants"
    Private Const ConstSetPMT = "PMT volts(0 - 1000)v"
    Private Const ConstSetMODE = "Enter Mode"
    Private Const constAvgValue = "Avg Value"
#End Region

#Region "Properties"
    Private Property InputValue() As Integer
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
        Dim objWait As New CWaitCursor
        Try
            btnADCFilter.Text = "ADC Filter"
            Call AddHandlers()

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

            txtPMT.Text = CInt(gobjInst.PmtVoltage)
            txtMode.Text = gobjInst.Mode
            txtAvgFactor.Text = gobjInst.Average

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

    Private Sub frmAnalogDB_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        Try
            Timer1.Enabled = True
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

            AddHandler btnClose.Click, AddressOf btnClose_Click
            AddHandler btnADCFilter.Click, AddressOf btnADCFilter_Click
            AddHandler btnAvgValue.Click, AddressOf btnAvgValue_Click
            AddHandler btnSetMode.Click, AddressOf btnSetMode_Click
            AddHandler btnSetPMT.Click, AddressOf btnSetPMT_Click
            AddHandler btnDelete.Click, AddressOf btnDelete_Click
            AddHandler btnR.Click, AddressOf btnR_Click
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
        Try
            gintInstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.DoubleBeam
            mblnExit = True
            Timer1.Enabled = False
            Me.DialogResult = DialogResult.Cancel
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
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
        Dim objWait As New CWaitCursor
        Dim intAvgValue As Integer
        Try
            Timer1.Enabled = False
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
            Application.DoEvents()
            txtAvgFactor.Text = CInt(InputValue)
            txtAvgFactor.Refresh()
            mobjfrmEditValues.Dispose()
            gobjInst.Average = CInt(InputValue)

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
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
            Timer1.Enabled = True
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
        Dim objWait As New CWaitCursor
        Dim byteSetMode As Byte
        Try
            Timer1.Enabled = False
            mobjfrmEditValues = New frmEditValues

            mobjfrmEditValues.LabelText = ConstSetMODE
            mobjfrmEditValues.txtValue.Visible = True
            mobjfrmEditValues.txtValue.ValidationType = NumberValidator.NumberValidator.Validations.IntegerOnly
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
            Application.DoEvents()
            txtMode.Text = CByte(InputValue)
            txtMode.Refresh()
            mobjfrmEditValues.Dispose()
            gobjInst.Mode = CByte(InputValue)
            funcSetMode(gobjInst.Mode)

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            'mblnInProcess = False
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            Timer1.Enabled = True
            'Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub btnSetPMT_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : btnSetPMT_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To position the Turret at said position from current position 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 21.11.06
        ' Revisions             : Deepak B. on 15.01.07
        '=====================================================================
        Dim objWait As New CWaitCursor
        Dim dblPMT As Double
        Try
            Timer1.Enabled = False
            btnSetPMT.Enabled = False
            mobjfrmEditValues = New frmEditValues

            mobjfrmEditValues.LabelText = ConstSetPMT
            mobjfrmEditValues.txtValue.Visible = True
            mobjfrmEditValues.txtValue.ValidationType = NumberValidator.NumberValidator.Validations.IntegerOnly
            mobjfrmEditValues.txtValue.RangeValidation = True
            mobjfrmEditValues.txtValue.MaxLength = 4
            mobjfrmEditValues.txtValue.MinimumRange = 0
            mobjfrmEditValues.txtValue.MaximumRange = 1000
            mobjfrmEditValues.txtValue.Focus()
            mobjfrmEditValues.txtValue.SelectAll()
            If mblnIsRefBeamType = True Then
                mobjfrmEditValues.txtValue.Text = CInt(gobjInst.PmtVoltageReference)
            Else
                mobjfrmEditValues.txtValue.Text = CInt(gobjInst.PmtVoltage)
            End If
            If mobjfrmEditValues.ShowDialog = DialogResult.Cancel Then
                Application.DoEvents()
                mobjfrmEditValues.Dispose()
                Exit Sub
            End If
            Application.DoEvents()
            dblPMT = CDbl(InputValue)
            If dblPMT < 0 Or dblPMT > 1000 Then
                gobjMessageAdapter.ShowMessage(constPMTRange)
                Exit Sub
            End If
            txtPMT.Text = CDbl(InputValue)
            txtPMT.Refresh()
            mobjfrmEditValues.Dispose()
            If mblnIsRefBeamType = True Then
                gobjInst.PmtVoltageReference = CDbl(InputValue)
                funcSetPMT_Ref(gobjInst.PmtVoltageReference)
            Else
                gobjInst.PmtVoltage = CDbl(InputValue)
                funcSetPMT(gobjInst.PmtVoltage)
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
            btnSetPMT.Enabled = True
            Timer1.Enabled = True
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
        Dim objWait As New CWaitCursor
        Dim dblmv As Double
        Dim intAvgFactor As Integer
        Try
            If mblnADCFilterFlag = True Then
                mblnADCFilterFlag = False
                btnADCFilter.Text = "ADC Filter"
            Else
                mblnADCFilterFlag = True
                btnADCFilter.Text = "ADC Non_Filter"
            End If
            funcChangeLabel()

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
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
        If mblnAvoidProcessing = True Then
            Exit Sub
        End If
        Try
            mblnAvoidProcessing = True


            RemoveHandler mnuIgnite.Click, AddressOf btnAutoIgnition_Click
            Timer1.Enabled = False
            Application.DoEvents()
            Call gobjClsAAS203.funcIgnite(True)
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
            'If Not IsNothing(mobjfrmAnalysis) Then mobjfrmAnalysis.tmrAspirationMsg.Enabled = True
            'mobjController.Start(gobjclsBgFlameStatus)
            Application.DoEvents()
            AddHandler mnuIgnite.Click, AddressOf btnAutoIgnition_Click
            Timer1.Enabled = True
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
        If mblnAvoidProcessing = True Then
            Exit Sub
        End If
        Try
            mblnAvoidProcessing = True

            RemoveHandler mnuExtinguish.Click, AddressOf btnExtinguish_Click
            Timer1.Enabled = False
            Call gobjClsAAS203.funcIgnite(False)
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
            'If Not IsNothing(mobjfrmAnalysis) Then mobjfrmAnalysis.tmrAspirationMsg.Enabled = True
            'mobjController.Start(gobjclsBgFlameStatus)
            Application.DoEvents()
            AddHandler mnuExtinguish.Click, AddressOf btnExtinguish_Click
            Timer1.Enabled = True
            '---------------------------------------------------------
        End Try
    End Sub

    Private Function funcADCNonFilter(ByVal blnIsSample As Boolean)
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
        Dim dblmv As Double
        Try
            Timer1.Enabled = False

            If blnIsSample = True Then
                If gobjClsAAS203.funcbtnADCNonFilter(dblmv) = True Then
                    txtDEC.Text = CDbl(dblmv)
                    txtHEX.Text = Hex(dblmv)
                    txtMv.Text = Format(gFuncGetmv(CInt(dblmv)), "0.00")
                End If
            Else
                If gobjCommProtocol.funcReadADCFilter_ReferenceBeam(10, dblmv) = True Then
                    txtDEC.Text = CDbl(dblmv)
                    txtDEC.Text = Hex(dblmv)
                    txtDEC.Text = Format(gFuncGetmv(CInt(dblmv)), "0.00")
                End If
            End If
            txtDEC.Refresh()
            txtHEX.Refresh()
            txtMv.Refresh()

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
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
            Timer1.Enabled = True
            '---------------------------------------------------------
        End Try
    End Function

    Private Function funcADCFilter(ByVal blnIsSample As Boolean, ByVal intAverage As Integer)
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
        Dim dblmv As Double
        Try
            Timer1.Enabled = False

            If intAverage < 1 Then
                Exit Function
            End If

            If blnIsSample = True Then
                If gobjClsAAS203.funcbtnADCFilter(intAverage, dblmv) = True Then
                    txtDEC.Text = CDbl(dblmv)
                    txtMv.Text = Format(gFuncGetmv(CInt(dblmv)), "0.00")
                    txtHEX.Text = Hex(dblmv)
                End If
            Else
                If gobjCommProtocol.funcReadADCFilter_ReferenceBeam(intAverage, dblmv) = True Then
                    txtDEC.Text = CDbl(dblmv)
                    txtMv.Text = Format(gFuncGetmv(CInt(dblmv)), "0.00")
                    txtHEX.Text = Hex(dblmv)
                End If
            End If
            txtDEC.Refresh()
            txtHEX.Refresh()
            txtMv.Refresh()

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
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
            Timer1.Enabled = True
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
        Dim objWait As New CWaitCursor
        Try

            If mblnIsRefBeamType = True Then
                gintInstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.ReferenceBeam
                If gobjCommProtocol.funcCalibrationMode(byteSetMode) = True Then
                    txtMode.Text = CByte(byteSetMode)
                    txtMode.Refresh()
                End If
            Else
                gintInstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.SingleBeam
                If gobjCommProtocol.funcCalibrationMode(byteSetMode) = True Then
                    txtMode.Text = CByte(byteSetMode)
                    txtMode.Refresh()
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
        Dim objWait As New CWaitCursor
        Try
            If gobjClsAAS203.funcbtnSet_PMT(dblPMT) = True Then
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

    Private Function funcSetPMT_Ref(ByVal dblPMT As Double)
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
        Dim objWait As New CWaitCursor
        Try
            If gobjCommProtocol.funcSet_PMTReferenceBeam(dblPMT) = True Then
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


            Timer1.Enabled = False
            Application.DoEvents()
            Call gobjMainService.N2OAutoIgnition()
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
            Timer1.Enabled = True
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
        If mblnAvoidProcessing = True Then
            Exit Sub
        End If
        Try
            mblnAvoidProcessing = True


            Timer1.Enabled = False
            Call gobjMainService.funcAltDelete()
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
            Timer1.Enabled = True
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
        If mblnAvoidProcessing = True Then
            Exit Sub
        End If
        Try
            mblnAvoidProcessing = True
            Timer1.Enabled = False

            Call gobjMainService.funcAltR()
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
            Timer1.Enabled = True
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub btnSample_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSample.CheckedChanged
        Try
            If btnSample.Checked = True Then
                '---if sample beam is selected then first 
                '---set reference board to AA mode
                gintInstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.ReferenceBeam
                gobjInst.Mode = EnumCalibrationMode.AA
                funcSetMode(gobjInst.Mode)
                gintInstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.SingleBeam

                mblnIsRefBeamType = False
                btnSetPMT.Text = "Sample PMT"
            Else
                '---if ref. beam is selected then first 
                '---set sample board to AA mode
                gintInstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.SingleBeam
                gobjInst.Mode = EnumCalibrationMode.AA
                funcSetMode(gobjInst.Mode)
                gintInstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.ReferenceBeam

                mblnIsRefBeamType = True
                btnSetPMT.Text = "Ref. PMT"
            End If
            funcChangeLabel()
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
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

    Private Function funcChangeLabel()
        Try
            If mblnADCFilterFlag = True Then
                If mblnIsRefBeamType = True Then
                    lblFiltered.Text = "Filtered (Ref.)"
                Else
                    lblFiltered.Text = "Filtered (Sample)"
                End If
            Else
                If mblnIsRefBeamType = True Then
                    lblFiltered.Text = "Non Filtered (Ref.)"
                Else
                    lblFiltered.Text = "Non Filtered (Sample)"
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

    Private Function funcGetADCData()
        Try
            If mblnADCFilterFlag = True Then
                If mblnIsRefBeamType = True Then
                    funcADCFilter(False, gobjInst.Average)
                Else
                    funcADCFilter(True, gobjInst.Average)
                End If
            Else
                If mblnIsRefBeamType = True Then
                    funcADCNonFilter(False)
                Else
                    funcADCNonFilter(True)
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

    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Try
            funcGetADCData()
            Me.txtDEC.Refresh()
            Me.txtHEX.Refresh()
            Me.txtMv.Refresh()
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

#End Region


End Class
