Imports System
Imports System.Threading
Imports AAS203.Common
Imports AAS203Library
Imports BgThread

Public Class frmManualIgnition
    Inherits System.Windows.Forms.Form
    Implements Iclient

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Try
            LoadInConst()
            InitFromObject()
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
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
    Friend WithEvents CustomPanel1 As GradientPanel.CustomPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblFlameRatio As System.Windows.Forms.Label
    Friend WithEvents lblFlameType As System.Windows.Forms.Label
    Friend WithEvents lblSafetyControlsTrap As System.Windows.Forms.Label
    Friend WithEvents lblSafetyControlsDoor As System.Windows.Forms.Label
    Friend WithEvents lblBurnerType As System.Windows.Forms.Label
    Friend WithEvents lblStatusFuel As System.Windows.Forms.Label
    Friend WithEvents lblStatusN2O As System.Windows.Forms.Label
    Friend WithEvents lblStatusAir As System.Windows.Forms.Label
    Friend WithEvents lblPressureFuel As System.Windows.Forms.Label
    Friend WithEvents lblPressureN2O As System.Windows.Forms.Label
    Friend WithEvents lblPressureAir As System.Windows.Forms.Label
    Friend WithEvents lblFlame As System.Windows.Forms.Label
    Friend WithEvents lblSafetyControls As System.Windows.Forms.Label
    Friend WithEvents lblBurner As System.Windows.Forms.Label
    Friend WithEvents lblPressureValveStatus As System.Windows.Forms.Label
    Friend WithEvents lblPressures As System.Windows.Forms.Label
    Friend WithEvents lblBurnerHeight As System.Windows.Forms.Label
    Friend WithEvents pbSafetyControlsTrap As System.Windows.Forms.PictureBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblBurnerAttached As System.Windows.Forms.Label
    Friend WithEvents lblFuelPressure As System.Windows.Forms.Label
    Friend WithEvents lblN2OPressure As System.Windows.Forms.Label
    Friend WithEvents lblAirPressure As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnClose As NETXP.Controls.XPButton
    Friend WithEvents btnSetMaxBurnerHeight As NETXP.Controls.XPButton
    Friend WithEvents btnSetMaxFuel As NETXP.Controls.XPButton
    Friend WithEvents btnDecreaseFuel As NETXP.Controls.XPButton
    Friend WithEvents btnIncreaseFuel As NETXP.Controls.XPButton
    Friend WithEvents btnIgnite As NETXP.Controls.XPButton
    Friend WithEvents btnFuel As NETXP.Controls.XPButton
    Friend WithEvents btnN2O As NETXP.Controls.XPButton
    Friend WithEvents btnAirOnOff As NETXP.Controls.XPButton
    Friend WithEvents lblBurnerStatus As System.Windows.Forms.Label
    Friend WithEvents lblFuel As System.Windows.Forms.Label
    Friend WithEvents lblN2O As System.Windows.Forms.Label
    Friend WithEvents lblAir As System.Windows.Forms.Label
    Friend WithEvents lblIgnite As System.Windows.Forms.Label
    Friend WithEvents lblIgniteStatus As System.Windows.Forms.Label
    Friend WithEvents btnIncreaseBurnerHeight As NETXP.Controls.XPButton
    Friend WithEvents btnDecreaseBurnerHeight As NETXP.Controls.XPButton
    Friend WithEvents tmrCheckManualIgnite As System.Timers.Timer
    Friend WithEvents lblFRatio As System.Windows.Forms.Label
    Friend WithEvents lblBHeight As System.Windows.Forms.Label
    Friend WithEvents lblNVStep As System.Windows.Forms.Label
    Friend WithEvents lblNVStep1 As System.Windows.Forms.Label
    Friend WithEvents CommandBar1 As NETXP.Controls.Bars.CommandBar
    Friend WithEvents pbPressureAir As System.Windows.Forms.Label
    Friend WithEvents pbPressureN2O As System.Windows.Forms.Label
    Friend WithEvents pbPressureFuel As System.Windows.Forms.Label
    Friend WithEvents pbStatusAir As System.Windows.Forms.Label
    Friend WithEvents pbStatusFuel As System.Windows.Forms.Label
    Friend WithEvents pbBurnerType As System.Windows.Forms.Label
    Friend WithEvents pbSafetyControlsDoor As System.Windows.Forms.Label
    Friend WithEvents pbFlameType As System.Windows.Forms.Label
    Friend WithEvents cmdBarBtnIgnite As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents cmdBarBtnExtinguish As NETXP.Controls.Bars.CommandBarButtonItem
    Friend WithEvents custpnlStatusDisplay As GradientPanel.CustomPanel
    Friend WithEvents pbStatusN2O As System.Windows.Forms.Label
    Friend WithEvents btnN2OIgnite As NETXP.Controls.XPButton
    Friend WithEvents btnDelete As NETXP.Controls.XPButton
    Friend WithEvents btnR As NETXP.Controls.XPButton
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnExtinguish As NETXP.Controls.XPButton
    Friend WithEvents btnAutoIgnite As NETXP.Controls.XPButton
    Friend WithEvents lblFlameType1 As System.Windows.Forms.Label
    Friend WithEvents lblBurnerType1 As System.Windows.Forms.Label
    Friend WithEvents lblStatusFuel1 As System.Windows.Forms.Label
    Friend WithEvents lblStatusN2O1 As System.Windows.Forms.Label
    Friend WithEvents lblStatusAir1 As System.Windows.Forms.Label
    Friend WithEvents lblPressureFuel1 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents lblPressureAir1 As System.Windows.Forms.Label
    Friend WithEvents lblFlame1 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents lblBurner1 As System.Windows.Forms.Label
    Friend WithEvents lblPressureValveStatus1 As System.Windows.Forms.Label
    Friend WithEvents pbFlameType1 As System.Windows.Forms.Label
    Friend WithEvents pbBurnerType1 As System.Windows.Forms.Label
    Friend WithEvents pbStatusFuel1 As System.Windows.Forms.Label
    Friend WithEvents pbStatusN2O1 As System.Windows.Forms.Label
    Friend WithEvents pbStatusAir1 As System.Windows.Forms.Label
    Friend WithEvents pbPressureFuel1 As System.Windows.Forms.Label
    Friend WithEvents pbPressureN2O1 As System.Windows.Forms.Label
    Friend WithEvents pbPressureAir1 As System.Windows.Forms.Label
    Friend WithEvents lblPressures1 As System.Windows.Forms.Label
    Friend WithEvents lblFRatio1 As System.Windows.Forms.Label
    Friend WithEvents lblPressureN2O1 As System.Windows.Forms.Label
    Friend WithEvents lblFlameRatio1 As System.Windows.Forms.Label
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents pnl201 As GradientPanel.CustomPanel
    Friend WithEvents pnl203 As GradientPanel.CustomPanel
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmManualIgnition))
        Me.CustomPanel1 = New GradientPanel.CustomPanel
        Me.Label8 = New System.Windows.Forms.Label
        Me.btnExtinguish = New NETXP.Controls.XPButton
        Me.btnAutoIgnite = New NETXP.Controls.XPButton
        Me.btnDelete = New NETXP.Controls.XPButton
        Me.btnR = New NETXP.Controls.XPButton
        Me.CommandBar1 = New NETXP.Controls.Bars.CommandBar
        Me.cmdBarBtnIgnite = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.cmdBarBtnExtinguish = New NETXP.Controls.Bars.CommandBarButtonItem
        Me.lblNVStep1 = New System.Windows.Forms.Label
        Me.lblIgniteStatus = New System.Windows.Forms.Label
        Me.lblIgnite = New System.Windows.Forms.Label
        Me.lblBurnerStatus = New System.Windows.Forms.Label
        Me.lblFuel = New System.Windows.Forms.Label
        Me.lblN2O = New System.Windows.Forms.Label
        Me.lblAir = New System.Windows.Forms.Label
        Me.lblNVStep = New System.Windows.Forms.Label
        Me.lblBurnerAttached = New System.Windows.Forms.Label
        Me.lblFuelPressure = New System.Windows.Forms.Label
        Me.lblN2OPressure = New System.Windows.Forms.Label
        Me.lblAirPressure = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.btnSetMaxBurnerHeight = New NETXP.Controls.XPButton
        Me.btnSetMaxFuel = New NETXP.Controls.XPButton
        Me.btnIncreaseBurnerHeight = New NETXP.Controls.XPButton
        Me.btnDecreaseBurnerHeight = New NETXP.Controls.XPButton
        Me.btnDecreaseFuel = New NETXP.Controls.XPButton
        Me.btnIncreaseFuel = New NETXP.Controls.XPButton
        Me.btnIgnite = New NETXP.Controls.XPButton
        Me.btnFuel = New NETXP.Controls.XPButton
        Me.btnN2O = New NETXP.Controls.XPButton
        Me.btnAirOnOff = New NETXP.Controls.XPButton
        Me.btnN2OIgnite = New NETXP.Controls.XPButton
        Me.btnClose = New NETXP.Controls.XPButton
        Me.pbFlameType = New System.Windows.Forms.Label
        Me.pbSafetyControlsDoor = New System.Windows.Forms.Label
        Me.pbBurnerType = New System.Windows.Forms.Label
        Me.pbStatusFuel = New System.Windows.Forms.Label
        Me.pbStatusAir = New System.Windows.Forms.Label
        Me.pbPressureFuel = New System.Windows.Forms.Label
        Me.pbPressureN2O = New System.Windows.Forms.Label
        Me.pbPressureAir = New System.Windows.Forms.Label
        Me.lblBHeight = New System.Windows.Forms.Label
        Me.lblFRatio = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblBurnerHeight = New System.Windows.Forms.Label
        Me.pbSafetyControlsTrap = New System.Windows.Forms.PictureBox
        Me.lblFlameRatio = New System.Windows.Forms.Label
        Me.lblFlameType = New System.Windows.Forms.Label
        Me.lblSafetyControlsTrap = New System.Windows.Forms.Label
        Me.lblSafetyControlsDoor = New System.Windows.Forms.Label
        Me.lblBurnerType = New System.Windows.Forms.Label
        Me.lblStatusFuel = New System.Windows.Forms.Label
        Me.lblStatusN2O = New System.Windows.Forms.Label
        Me.lblStatusAir = New System.Windows.Forms.Label
        Me.lblPressureFuel = New System.Windows.Forms.Label
        Me.lblPressureN2O = New System.Windows.Forms.Label
        Me.lblPressureAir = New System.Windows.Forms.Label
        Me.lblFlame = New System.Windows.Forms.Label
        Me.lblSafetyControls = New System.Windows.Forms.Label
        Me.lblBurner = New System.Windows.Forms.Label
        Me.lblPressureValveStatus = New System.Windows.Forms.Label
        Me.lblPressures = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.tmrCheckManualIgnite = New System.Timers.Timer
        Me.custpnlStatusDisplay = New GradientPanel.CustomPanel
        Me.pnl201 = New GradientPanel.CustomPanel
        Me.lblFlameType1 = New System.Windows.Forms.Label
        Me.lblBurnerType1 = New System.Windows.Forms.Label
        Me.lblStatusFuel1 = New System.Windows.Forms.Label
        Me.lblStatusN2O1 = New System.Windows.Forms.Label
        Me.lblStatusAir1 = New System.Windows.Forms.Label
        Me.lblPressureFuel1 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.lblPressureAir1 = New System.Windows.Forms.Label
        Me.lblFlame1 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.lblBurner1 = New System.Windows.Forms.Label
        Me.lblPressureValveStatus1 = New System.Windows.Forms.Label
        Me.pbFlameType1 = New System.Windows.Forms.Label
        Me.pbBurnerType1 = New System.Windows.Forms.Label
        Me.pbStatusFuel1 = New System.Windows.Forms.Label
        Me.pbStatusN2O1 = New System.Windows.Forms.Label
        Me.pbStatusAir1 = New System.Windows.Forms.Label
        Me.pbPressureFuel1 = New System.Windows.Forms.Label
        Me.pbPressureN2O1 = New System.Windows.Forms.Label
        Me.pbPressureAir1 = New System.Windows.Forms.Label
        Me.lblPressures1 = New System.Windows.Forms.Label
        Me.lblFRatio1 = New System.Windows.Forms.Label
        Me.lblPressureN2O1 = New System.Windows.Forms.Label
        Me.lblFlameRatio1 = New System.Windows.Forms.Label
        Me.Label42 = New System.Windows.Forms.Label
        Me.pnl203 = New GradientPanel.CustomPanel
        Me.pbStatusN2O = New System.Windows.Forms.Label
        Me.CustomPanel1.SuspendLayout()
        CType(Me.CommandBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tmrCheckManualIgnite, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.custpnlStatusDisplay.SuspendLayout()
        Me.pnl201.SuspendLayout()
        Me.pnl203.SuspendLayout()
        Me.SuspendLayout()
        '
        'CustomPanel1
        '
        Me.CustomPanel1.BackColor = System.Drawing.Color.AliceBlue
        Me.CustomPanel1.Controls.Add(Me.Label8)
        Me.CustomPanel1.Controls.Add(Me.btnExtinguish)
        Me.CustomPanel1.Controls.Add(Me.btnAutoIgnite)
        Me.CustomPanel1.Controls.Add(Me.btnDelete)
        Me.CustomPanel1.Controls.Add(Me.btnR)
        Me.CustomPanel1.Controls.Add(Me.CommandBar1)
        Me.CustomPanel1.Controls.Add(Me.lblNVStep1)
        Me.CustomPanel1.Controls.Add(Me.lblIgniteStatus)
        Me.CustomPanel1.Controls.Add(Me.lblIgnite)
        Me.CustomPanel1.Controls.Add(Me.lblBurnerStatus)
        Me.CustomPanel1.Controls.Add(Me.lblFuel)
        Me.CustomPanel1.Controls.Add(Me.lblN2O)
        Me.CustomPanel1.Controls.Add(Me.lblAir)
        Me.CustomPanel1.Controls.Add(Me.lblNVStep)
        Me.CustomPanel1.Controls.Add(Me.lblBurnerAttached)
        Me.CustomPanel1.Controls.Add(Me.lblFuelPressure)
        Me.CustomPanel1.Controls.Add(Me.lblN2OPressure)
        Me.CustomPanel1.Controls.Add(Me.lblAirPressure)
        Me.CustomPanel1.Controls.Add(Me.Label4)
        Me.CustomPanel1.Controls.Add(Me.btnSetMaxBurnerHeight)
        Me.CustomPanel1.Controls.Add(Me.btnSetMaxFuel)
        Me.CustomPanel1.Controls.Add(Me.btnIncreaseBurnerHeight)
        Me.CustomPanel1.Controls.Add(Me.btnDecreaseBurnerHeight)
        Me.CustomPanel1.Controls.Add(Me.btnDecreaseFuel)
        Me.CustomPanel1.Controls.Add(Me.btnIncreaseFuel)
        Me.CustomPanel1.Controls.Add(Me.btnIgnite)
        Me.CustomPanel1.Controls.Add(Me.btnFuel)
        Me.CustomPanel1.Controls.Add(Me.btnN2O)
        Me.CustomPanel1.Controls.Add(Me.btnAirOnOff)
        Me.CustomPanel1.Controls.Add(Me.btnN2OIgnite)
        Me.CustomPanel1.Controls.Add(Me.btnClose)
        Me.CustomPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CustomPanel1.Location = New System.Drawing.Point(0, 160)
        Me.CustomPanel1.Name = "CustomPanel1"
        Me.CustomPanel1.Size = New System.Drawing.Size(658, 184)
        Me.CustomPanel1.TabIndex = 0
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(16, 145)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(112, 24)
        Me.Label8.TabIndex = 77
        '
        'btnExtinguish
        '
        Me.btnExtinguish.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExtinguish.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExtinguish.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExtinguish.Location = New System.Drawing.Point(56, 152)
        Me.btnExtinguish.Name = "btnExtinguish"
        Me.btnExtinguish.Size = New System.Drawing.Size(8, 8)
        Me.btnExtinguish.TabIndex = 79
        Me.btnExtinguish.TabStop = False
        Me.btnExtinguish.Text = "&Extinguish"
        Me.btnExtinguish.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'btnAutoIgnite
        '
        Me.btnAutoIgnite.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAutoIgnite.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAutoIgnite.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAutoIgnite.Location = New System.Drawing.Point(40, 152)
        Me.btnAutoIgnite.Name = "btnAutoIgnite"
        Me.btnAutoIgnite.Size = New System.Drawing.Size(8, 8)
        Me.btnAutoIgnite.TabIndex = 78
        Me.btnAutoIgnite.TabStop = False
        Me.btnAutoIgnite.Text = "&Ignition"
        Me.btnAutoIgnite.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'btnDelete
        '
        Me.btnDelete.BackColor = System.Drawing.Color.Transparent
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelete.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDelete.Location = New System.Drawing.Point(80, 152)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(8, 8)
        Me.btnDelete.TabIndex = 76
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
        Me.btnR.Location = New System.Drawing.Point(96, 152)
        Me.btnR.Name = "btnR"
        Me.btnR.Size = New System.Drawing.Size(8, 8)
        Me.btnR.TabIndex = 75
        Me.btnR.TabStop = False
        Me.btnR.Text = "&R"
        Me.btnR.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'CommandBar1
        '
        Me.CommandBar1.BackColor = System.Drawing.Color.Transparent
        Me.CommandBar1.CustomizeText = "&Customize Toolbar..."
        Me.CommandBar1.FullRow = True
        Me.CommandBar1.ID = 2250
        Me.CommandBar1.Items.AddRange(New NETXP.Controls.Bars.CommandBarItem() {Me.cmdBarBtnIgnite, Me.cmdBarBtnExtinguish})
        Me.CommandBar1.Location = New System.Drawing.Point(176, 137)
        Me.CommandBar1.Margins.Bottom = 1
        Me.CommandBar1.Margins.Left = 1
        Me.CommandBar1.Margins.Right = 1
        Me.CommandBar1.Margins.Top = 1
        Me.CommandBar1.Name = "CommandBar1"
        Me.CommandBar1.Size = New System.Drawing.Size(64, 45)
        Me.CommandBar1.Style = NETXP.Controls.Bars.CommandBarStyle.Menu
        Me.CommandBar1.TabIndex = 68
        Me.CommandBar1.TabStop = False
        Me.CommandBar1.Text = "CommandBar1"
        Me.CommandBar1.Visible = False
        '
        'cmdBarBtnIgnite
        '
        Me.cmdBarBtnIgnite.Shortcut = System.Windows.Forms.Shortcut.CtrlI
        Me.cmdBarBtnIgnite.Text = "CTRL+I"
        '
        'cmdBarBtnExtinguish
        '
        Me.cmdBarBtnExtinguish.Shortcut = System.Windows.Forms.Shortcut.CtrlE
        Me.cmdBarBtnExtinguish.Text = "CTRL+E"
        '
        'lblNVStep1
        '
        Me.lblNVStep1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNVStep1.Location = New System.Drawing.Point(8, 5)
        Me.lblNVStep1.Name = "lblNVStep1"
        Me.lblNVStep1.Size = New System.Drawing.Size(72, 20)
        Me.lblNVStep1.TabIndex = 66
        Me.lblNVStep1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblIgniteStatus
        '
        Me.lblIgniteStatus.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIgniteStatus.Location = New System.Drawing.Point(120, 104)
        Me.lblIgniteStatus.Name = "lblIgniteStatus"
        Me.lblIgniteStatus.Size = New System.Drawing.Size(56, 16)
        Me.lblIgniteStatus.TabIndex = 63
        Me.lblIgniteStatus.Visible = False
        '
        'lblIgnite
        '
        Me.lblIgnite.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIgnite.Location = New System.Drawing.Point(8, 104)
        Me.lblIgnite.Name = "lblIgnite"
        Me.lblIgnite.Size = New System.Drawing.Size(104, 16)
        Me.lblIgnite.TabIndex = 62
        Me.lblIgnite.Text = "IGNITE"
        Me.lblIgnite.Visible = False
        '
        'lblBurnerStatus
        '
        Me.lblBurnerStatus.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBurnerStatus.Location = New System.Drawing.Point(120, 128)
        Me.lblBurnerStatus.Name = "lblBurnerStatus"
        Me.lblBurnerStatus.Size = New System.Drawing.Size(56, 16)
        Me.lblBurnerStatus.TabIndex = 61
        Me.lblBurnerStatus.Visible = False
        '
        'lblFuel
        '
        Me.lblFuel.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFuel.Location = New System.Drawing.Point(120, 80)
        Me.lblFuel.Name = "lblFuel"
        Me.lblFuel.Size = New System.Drawing.Size(56, 16)
        Me.lblFuel.TabIndex = 60
        Me.lblFuel.Visible = False
        '
        'lblN2O
        '
        Me.lblN2O.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblN2O.Location = New System.Drawing.Point(120, 56)
        Me.lblN2O.Name = "lblN2O"
        Me.lblN2O.Size = New System.Drawing.Size(56, 16)
        Me.lblN2O.TabIndex = 59
        Me.lblN2O.Visible = False
        '
        'lblAir
        '
        Me.lblAir.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAir.Location = New System.Drawing.Point(120, 32)
        Me.lblAir.Name = "lblAir"
        Me.lblAir.Size = New System.Drawing.Size(56, 16)
        Me.lblAir.TabIndex = 58
        Me.lblAir.Visible = False
        '
        'lblNVStep
        '
        Me.lblNVStep.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNVStep.Location = New System.Drawing.Point(96, 5)
        Me.lblNVStep.Name = "lblNVStep"
        Me.lblNVStep.Size = New System.Drawing.Size(88, 20)
        Me.lblNVStep.TabIndex = 57
        Me.lblNVStep.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblBurnerAttached
        '
        Me.lblBurnerAttached.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBurnerAttached.Location = New System.Drawing.Point(8, 128)
        Me.lblBurnerAttached.Name = "lblBurnerAttached"
        Me.lblBurnerAttached.Size = New System.Drawing.Size(104, 16)
        Me.lblBurnerAttached.TabIndex = 56
        Me.lblBurnerAttached.Text = "Burner attached"
        Me.lblBurnerAttached.Visible = False
        '
        'lblFuelPressure
        '
        Me.lblFuelPressure.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFuelPressure.Location = New System.Drawing.Point(8, 80)
        Me.lblFuelPressure.Name = "lblFuelPressure"
        Me.lblFuelPressure.Size = New System.Drawing.Size(104, 16)
        Me.lblFuelPressure.TabIndex = 55
        Me.lblFuelPressure.Text = "FUEL Pressure"
        Me.lblFuelPressure.Visible = False
        '
        'lblN2OPressure
        '
        Me.lblN2OPressure.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblN2OPressure.Location = New System.Drawing.Point(8, 56)
        Me.lblN2OPressure.Name = "lblN2OPressure"
        Me.lblN2OPressure.Size = New System.Drawing.Size(104, 16)
        Me.lblN2OPressure.TabIndex = 54
        Me.lblN2OPressure.Text = "N2O Pressure"
        Me.lblN2OPressure.Visible = False
        '
        'lblAirPressure
        '
        Me.lblAirPressure.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAirPressure.Location = New System.Drawing.Point(8, 32)
        Me.lblAirPressure.Name = "lblAirPressure"
        Me.lblAirPressure.Size = New System.Drawing.Size(104, 16)
        Me.lblAirPressure.TabIndex = 53
        Me.lblAirPressure.Text = "AIR Pressure"
        Me.lblAirPressure.Visible = False
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Location = New System.Drawing.Point(190, 24)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(2, 120)
        Me.Label4.TabIndex = 52
        Me.Label4.Text = "Label4"
        '
        'btnSetMaxBurnerHeight
        '
        Me.btnSetMaxBurnerHeight.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSetMaxBurnerHeight.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSetMaxBurnerHeight.Image = CType(resources.GetObject("btnSetMaxBurnerHeight.Image"), System.Drawing.Image)
        Me.btnSetMaxBurnerHeight.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSetMaxBurnerHeight.Location = New System.Drawing.Point(466, 89)
        Me.btnSetMaxBurnerHeight.Name = "btnSetMaxBurnerHeight"
        Me.btnSetMaxBurnerHeight.Size = New System.Drawing.Size(120, 38)
        Me.btnSetMaxBurnerHeight.TabIndex = 8
        Me.btnSetMaxBurnerHeight.Text = "Max.&Burner Height"
        Me.btnSetMaxBurnerHeight.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'btnSetMaxFuel
        '
        Me.btnSetMaxFuel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSetMaxFuel.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSetMaxFuel.Image = CType(resources.GetObject("btnSetMaxFuel.Image"), System.Drawing.Image)
        Me.btnSetMaxFuel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSetMaxFuel.Location = New System.Drawing.Point(337, 89)
        Me.btnSetMaxFuel.Name = "btnSetMaxFuel"
        Me.btnSetMaxFuel.Size = New System.Drawing.Size(120, 38)
        Me.btnSetMaxFuel.TabIndex = 7
        Me.btnSetMaxFuel.Text = "Set Max.F&uel"
        Me.btnSetMaxFuel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnIncreaseBurnerHeight
        '
        Me.btnIncreaseBurnerHeight.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnIncreaseBurnerHeight.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIncreaseBurnerHeight.Image = CType(resources.GetObject("btnIncreaseBurnerHeight.Image"), System.Drawing.Image)
        Me.btnIncreaseBurnerHeight.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnIncreaseBurnerHeight.Location = New System.Drawing.Point(466, 5)
        Me.btnIncreaseBurnerHeight.Name = "btnIncreaseBurnerHeight"
        Me.btnIncreaseBurnerHeight.Size = New System.Drawing.Size(120, 38)
        Me.btnIncreaseBurnerHeight.TabIndex = 2
        Me.btnIncreaseBurnerHeight.Text = "Decrease Burner &Height"
        Me.btnIncreaseBurnerHeight.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'btnDecreaseBurnerHeight
        '
        Me.btnDecreaseBurnerHeight.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDecreaseBurnerHeight.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDecreaseBurnerHeight.Image = CType(resources.GetObject("btnDecreaseBurnerHeight.Image"), System.Drawing.Image)
        Me.btnDecreaseBurnerHeight.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDecreaseBurnerHeight.Location = New System.Drawing.Point(466, 47)
        Me.btnDecreaseBurnerHeight.Name = "btnDecreaseBurnerHeight"
        Me.btnDecreaseBurnerHeight.Size = New System.Drawing.Size(120, 38)
        Me.btnDecreaseBurnerHeight.TabIndex = 5
        Me.btnDecreaseBurnerHeight.Text = "Increase Burner Heigh&t"
        Me.btnDecreaseBurnerHeight.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'btnDecreaseFuel
        '
        Me.btnDecreaseFuel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDecreaseFuel.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDecreaseFuel.Image = CType(resources.GetObject("btnDecreaseFuel.Image"), System.Drawing.Image)
        Me.btnDecreaseFuel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDecreaseFuel.Location = New System.Drawing.Point(337, 47)
        Me.btnDecreaseFuel.Name = "btnDecreaseFuel"
        Me.btnDecreaseFuel.Size = New System.Drawing.Size(120, 38)
        Me.btnDecreaseFuel.TabIndex = 4
        Me.btnDecreaseFuel.Text = "Decrea&se Fuel"
        Me.btnDecreaseFuel.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'btnIncreaseFuel
        '
        Me.btnIncreaseFuel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnIncreaseFuel.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIncreaseFuel.Image = CType(resources.GetObject("btnIncreaseFuel.Image"), System.Drawing.Image)
        Me.btnIncreaseFuel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnIncreaseFuel.Location = New System.Drawing.Point(337, 5)
        Me.btnIncreaseFuel.Name = "btnIncreaseFuel"
        Me.btnIncreaseFuel.Size = New System.Drawing.Size(120, 38)
        Me.btnIncreaseFuel.TabIndex = 1
        Me.btnIncreaseFuel.Text = "Increase    Fue&l"
        Me.btnIncreaseFuel.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'btnIgnite
        '
        Me.btnIgnite.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnIgnite.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIgnite.Image = CType(resources.GetObject("btnIgnite.Image"), System.Drawing.Image)
        Me.btnIgnite.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnIgnite.Location = New System.Drawing.Point(272, 131)
        Me.btnIgnite.Name = "btnIgnite"
        Me.btnIgnite.Size = New System.Drawing.Size(120, 38)
        Me.btnIgnite.TabIndex = 9
        Me.btnIgnite.Text = "I&GNITE ON"
        '
        'btnFuel
        '
        Me.btnFuel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFuel.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFuel.Image = CType(resources.GetObject("btnFuel.Image"), System.Drawing.Image)
        Me.btnFuel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnFuel.Location = New System.Drawing.Point(208, 89)
        Me.btnFuel.Name = "btnFuel"
        Me.btnFuel.Size = New System.Drawing.Size(120, 38)
        Me.btnFuel.TabIndex = 6
        Me.btnFuel.Text = "&FUEL "
        '
        'btnN2O
        '
        Me.btnN2O.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnN2O.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnN2O.Image = CType(resources.GetObject("btnN2O.Image"), System.Drawing.Image)
        Me.btnN2O.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnN2O.Location = New System.Drawing.Point(208, 47)
        Me.btnN2O.Name = "btnN2O"
        Me.btnN2O.Size = New System.Drawing.Size(120, 38)
        Me.btnN2O.TabIndex = 3
        Me.btnN2O.Text = "&N2O"
        '
        'btnAirOnOff
        '
        Me.btnAirOnOff.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAirOnOff.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAirOnOff.Image = CType(resources.GetObject("btnAirOnOff.Image"), System.Drawing.Image)
        Me.btnAirOnOff.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAirOnOff.Location = New System.Drawing.Point(208, 5)
        Me.btnAirOnOff.Name = "btnAirOnOff"
        Me.btnAirOnOff.Size = New System.Drawing.Size(120, 38)
        Me.btnAirOnOff.TabIndex = 0
        Me.btnAirOnOff.Text = "&AIR"
        '
        'btnN2OIgnite
        '
        Me.btnN2OIgnite.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnN2OIgnite.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnN2OIgnite.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnN2OIgnite.Location = New System.Drawing.Point(72, 152)
        Me.btnN2OIgnite.Name = "btnN2OIgnite"
        Me.btnN2OIgnite.Size = New System.Drawing.Size(5, 5)
        Me.btnN2OIgnite.TabIndex = 71
        Me.btnN2OIgnite.TabStop = False
        Me.btnN2OIgnite.Text = "N2O&C"
        Me.btnN2OIgnite.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'btnClose
        '
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.Location = New System.Drawing.Point(403, 131)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(120, 38)
        Me.btnClose.TabIndex = 10
        Me.btnClose.Text = "C&LOSE"
        '
        'pbFlameType
        '
        Me.pbFlameType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbFlameType.Location = New System.Drawing.Point(496, 80)
        Me.pbFlameType.Name = "pbFlameType"
        Me.pbFlameType.Size = New System.Drawing.Size(32, 32)
        Me.pbFlameType.TabIndex = 77
        Me.pbFlameType.Visible = False
        '
        'pbSafetyControlsDoor
        '
        Me.pbSafetyControlsDoor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbSafetyControlsDoor.Location = New System.Drawing.Point(408, 80)
        Me.pbSafetyControlsDoor.Name = "pbSafetyControlsDoor"
        Me.pbSafetyControlsDoor.Size = New System.Drawing.Size(32, 32)
        Me.pbSafetyControlsDoor.TabIndex = 76
        Me.pbSafetyControlsDoor.Visible = False
        '
        'pbBurnerType
        '
        Me.pbBurnerType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbBurnerType.Location = New System.Drawing.Point(288, 80)
        Me.pbBurnerType.Name = "pbBurnerType"
        Me.pbBurnerType.Size = New System.Drawing.Size(32, 32)
        Me.pbBurnerType.TabIndex = 75
        Me.pbBurnerType.Visible = False
        '
        'pbStatusFuel
        '
        Me.pbStatusFuel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbStatusFuel.Location = New System.Drawing.Point(240, 80)
        Me.pbStatusFuel.Name = "pbStatusFuel"
        Me.pbStatusFuel.Size = New System.Drawing.Size(32, 32)
        Me.pbStatusFuel.TabIndex = 74
        Me.pbStatusFuel.Visible = False
        '
        'pbStatusAir
        '
        Me.pbStatusAir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbStatusAir.Location = New System.Drawing.Point(152, 80)
        Me.pbStatusAir.Name = "pbStatusAir"
        Me.pbStatusAir.Size = New System.Drawing.Size(32, 32)
        Me.pbStatusAir.TabIndex = 72
        Me.pbStatusAir.Visible = False
        '
        'pbPressureFuel
        '
        Me.pbPressureFuel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbPressureFuel.Location = New System.Drawing.Point(104, 80)
        Me.pbPressureFuel.Name = "pbPressureFuel"
        Me.pbPressureFuel.Size = New System.Drawing.Size(32, 32)
        Me.pbPressureFuel.TabIndex = 71
        Me.pbPressureFuel.Visible = False
        '
        'pbPressureN2O
        '
        Me.pbPressureN2O.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbPressureN2O.Location = New System.Drawing.Point(56, 80)
        Me.pbPressureN2O.Name = "pbPressureN2O"
        Me.pbPressureN2O.Size = New System.Drawing.Size(32, 32)
        Me.pbPressureN2O.TabIndex = 70
        Me.pbPressureN2O.Visible = False
        '
        'pbPressureAir
        '
        Me.pbPressureAir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbPressureAir.Location = New System.Drawing.Point(16, 80)
        Me.pbPressureAir.Name = "pbPressureAir"
        Me.pbPressureAir.Size = New System.Drawing.Size(32, 32)
        Me.pbPressureAir.TabIndex = 69
        Me.pbPressureAir.Visible = False
        '
        'lblBHeight
        '
        Me.lblBHeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBHeight.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBHeight.Location = New System.Drawing.Point(328, 80)
        Me.lblBHeight.Name = "lblBHeight"
        Me.lblBHeight.Size = New System.Drawing.Size(62, 32)
        Me.lblBHeight.TabIndex = 65
        Me.lblBHeight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblFRatio
        '
        Me.lblFRatio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFRatio.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFRatio.Location = New System.Drawing.Point(536, 80)
        Me.lblFRatio.Name = "lblFRatio"
        Me.lblFRatio.Size = New System.Drawing.Size(52, 32)
        Me.lblFRatio.TabIndex = 64
        Me.lblFRatio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Location = New System.Drawing.Point(0, 112)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(759, 2)
        Me.Label2.TabIndex = 40
        '
        'lblBurnerHeight
        '
        Me.lblBurnerHeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBurnerHeight.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBurnerHeight.Location = New System.Drawing.Point(328, 56)
        Me.lblBurnerHeight.Name = "lblBurnerHeight"
        Me.lblBurnerHeight.Size = New System.Drawing.Size(62, 24)
        Me.lblBurnerHeight.TabIndex = 38
        Me.lblBurnerHeight.Text = "HEIGHT"
        Me.lblBurnerHeight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pbSafetyControlsTrap
        '
        Me.pbSafetyControlsTrap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbSafetyControlsTrap.Location = New System.Drawing.Point(448, 80)
        Me.pbSafetyControlsTrap.Name = "pbSafetyControlsTrap"
        Me.pbSafetyControlsTrap.Size = New System.Drawing.Size(32, 32)
        Me.pbSafetyControlsTrap.TabIndex = 34
        Me.pbSafetyControlsTrap.TabStop = False
        Me.pbSafetyControlsTrap.Visible = False
        '
        'lblFlameRatio
        '
        Me.lblFlameRatio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFlameRatio.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFlameRatio.Location = New System.Drawing.Point(536, 56)
        Me.lblFlameRatio.Name = "lblFlameRatio"
        Me.lblFlameRatio.Size = New System.Drawing.Size(52, 24)
        Me.lblFlameRatio.TabIndex = 24
        Me.lblFlameRatio.Text = "RATIO"
        Me.lblFlameRatio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblFlameType
        '
        Me.lblFlameType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFlameType.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFlameType.Location = New System.Drawing.Point(496, 56)
        Me.lblFlameType.Name = "lblFlameType"
        Me.lblFlameType.Size = New System.Drawing.Size(44, 24)
        Me.lblFlameType.TabIndex = 23
        Me.lblFlameType.Text = "TYPE"
        Me.lblFlameType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblSafetyControlsTrap
        '
        Me.lblSafetyControlsTrap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSafetyControlsTrap.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSafetyControlsTrap.Location = New System.Drawing.Point(448, 56)
        Me.lblSafetyControlsTrap.Name = "lblSafetyControlsTrap"
        Me.lblSafetyControlsTrap.Size = New System.Drawing.Size(44, 24)
        Me.lblSafetyControlsTrap.TabIndex = 22
        Me.lblSafetyControlsTrap.Text = "TRAP"
        Me.lblSafetyControlsTrap.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblSafetyControlsDoor
        '
        Me.lblSafetyControlsDoor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSafetyControlsDoor.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSafetyControlsDoor.Location = New System.Drawing.Point(400, 56)
        Me.lblSafetyControlsDoor.Name = "lblSafetyControlsDoor"
        Me.lblSafetyControlsDoor.Size = New System.Drawing.Size(48, 24)
        Me.lblSafetyControlsDoor.TabIndex = 21
        Me.lblSafetyControlsDoor.Text = "DOOR"
        Me.lblSafetyControlsDoor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblBurnerType
        '
        Me.lblBurnerType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBurnerType.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBurnerType.Location = New System.Drawing.Point(288, 56)
        Me.lblBurnerType.Name = "lblBurnerType"
        Me.lblBurnerType.Size = New System.Drawing.Size(44, 24)
        Me.lblBurnerType.TabIndex = 20
        Me.lblBurnerType.Text = "TYPE"
        Me.lblBurnerType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblStatusFuel
        '
        Me.lblStatusFuel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStatusFuel.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatusFuel.Location = New System.Drawing.Point(240, 56)
        Me.lblStatusFuel.Name = "lblStatusFuel"
        Me.lblStatusFuel.Size = New System.Drawing.Size(44, 24)
        Me.lblStatusFuel.TabIndex = 19
        Me.lblStatusFuel.Text = "FUEL"
        Me.lblStatusFuel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblStatusN2O
        '
        Me.lblStatusN2O.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStatusN2O.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatusN2O.Location = New System.Drawing.Point(192, 56)
        Me.lblStatusN2O.Name = "lblStatusN2O"
        Me.lblStatusN2O.Size = New System.Drawing.Size(44, 24)
        Me.lblStatusN2O.TabIndex = 18
        Me.lblStatusN2O.Text = "N2O"
        Me.lblStatusN2O.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblStatusAir
        '
        Me.lblStatusAir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStatusAir.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatusAir.Location = New System.Drawing.Point(144, 56)
        Me.lblStatusAir.Name = "lblStatusAir"
        Me.lblStatusAir.Size = New System.Drawing.Size(44, 24)
        Me.lblStatusAir.TabIndex = 17
        Me.lblStatusAir.Text = "AIR"
        Me.lblStatusAir.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblPressureFuel
        '
        Me.lblPressureFuel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPressureFuel.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPressureFuel.Location = New System.Drawing.Point(96, 56)
        Me.lblPressureFuel.Name = "lblPressureFuel"
        Me.lblPressureFuel.Size = New System.Drawing.Size(44, 24)
        Me.lblPressureFuel.TabIndex = 16
        Me.lblPressureFuel.Text = "FUEL"
        Me.lblPressureFuel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblPressureN2O
        '
        Me.lblPressureN2O.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPressureN2O.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPressureN2O.Location = New System.Drawing.Point(56, 56)
        Me.lblPressureN2O.Name = "lblPressureN2O"
        Me.lblPressureN2O.Size = New System.Drawing.Size(44, 24)
        Me.lblPressureN2O.TabIndex = 15
        Me.lblPressureN2O.Text = "N2O"
        Me.lblPressureN2O.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblPressureAir
        '
        Me.lblPressureAir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPressureAir.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPressureAir.Location = New System.Drawing.Point(8, 56)
        Me.lblPressureAir.Name = "lblPressureAir"
        Me.lblPressureAir.Size = New System.Drawing.Size(44, 24)
        Me.lblPressureAir.TabIndex = 14
        Me.lblPressureAir.Text = "AIR"
        Me.lblPressureAir.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblFlame
        '
        Me.lblFlame.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFlame.Location = New System.Drawing.Point(504, 8)
        Me.lblFlame.Name = "lblFlame"
        Me.lblFlame.Size = New System.Drawing.Size(80, 32)
        Me.lblFlame.TabIndex = 11
        Me.lblFlame.Text = "FLAME"
        Me.lblFlame.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'lblSafetyControls
        '
        Me.lblSafetyControls.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSafetyControls.Location = New System.Drawing.Point(400, 8)
        Me.lblSafetyControls.Name = "lblSafetyControls"
        Me.lblSafetyControls.Size = New System.Drawing.Size(84, 32)
        Me.lblSafetyControls.TabIndex = 10
        Me.lblSafetyControls.Text = "SAFETY CONTROLS"
        Me.lblSafetyControls.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'lblBurner
        '
        Me.lblBurner.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBurner.Location = New System.Drawing.Point(288, 8)
        Me.lblBurner.Name = "lblBurner"
        Me.lblBurner.Size = New System.Drawing.Size(96, 32)
        Me.lblBurner.TabIndex = 9
        Me.lblBurner.Text = "BURNER"
        Me.lblBurner.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'lblPressureValveStatus
        '
        Me.lblPressureValveStatus.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPressureValveStatus.Location = New System.Drawing.Point(160, 8)
        Me.lblPressureValveStatus.Name = "lblPressureValveStatus"
        Me.lblPressureValveStatus.Size = New System.Drawing.Size(108, 32)
        Me.lblPressureValveStatus.TabIndex = 8
        Me.lblPressureValveStatus.Text = "PRESSURE VALVE STATUS"
        Me.lblPressureValveStatus.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'lblPressures
        '
        Me.lblPressures.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPressures.Location = New System.Drawing.Point(16, 8)
        Me.lblPressures.Name = "lblPressures"
        Me.lblPressures.Size = New System.Drawing.Size(110, 32)
        Me.lblPressures.TabIndex = 7
        Me.lblPressures.Text = "PRESSURES"
        Me.lblPressures.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.Control
        Me.Label7.Location = New System.Drawing.Point(392, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(2, 116)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Label7"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.Control
        Me.Label6.Location = New System.Drawing.Point(488, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(2, 116)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Label6"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Location = New System.Drawing.Point(280, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(2, 116)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Label5"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Location = New System.Drawing.Point(144, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(2, 116)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Label3"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Location = New System.Drawing.Point(0, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(759, 2)
        Me.Label1.TabIndex = 0
        '
        'tmrCheckManualIgnite
        '
        Me.tmrCheckManualIgnite.Interval = 400
        Me.tmrCheckManualIgnite.SynchronizingObject = Me
        '
        'custpnlStatusDisplay
        '
        Me.custpnlStatusDisplay.BackColor = System.Drawing.Color.AliceBlue
        Me.custpnlStatusDisplay.Controls.Add(Me.pnl201)
        Me.custpnlStatusDisplay.Controls.Add(Me.pnl203)
        Me.custpnlStatusDisplay.Dock = System.Windows.Forms.DockStyle.Top
        Me.custpnlStatusDisplay.Location = New System.Drawing.Point(0, 0)
        Me.custpnlStatusDisplay.Name = "custpnlStatusDisplay"
        Me.custpnlStatusDisplay.Size = New System.Drawing.Size(658, 160)
        Me.custpnlStatusDisplay.TabIndex = 78
        '
        'pnl201
        '
        Me.pnl201.BackColor = System.Drawing.Color.AliceBlue
        Me.pnl201.Controls.Add(Me.lblFlameType1)
        Me.pnl201.Controls.Add(Me.lblBurnerType1)
        Me.pnl201.Controls.Add(Me.lblStatusFuel1)
        Me.pnl201.Controls.Add(Me.lblStatusN2O1)
        Me.pnl201.Controls.Add(Me.lblStatusAir1)
        Me.pnl201.Controls.Add(Me.lblPressureFuel1)
        Me.pnl201.Controls.Add(Me.Label17)
        Me.pnl201.Controls.Add(Me.lblPressureAir1)
        Me.pnl201.Controls.Add(Me.lblFlame1)
        Me.pnl201.Controls.Add(Me.Label21)
        Me.pnl201.Controls.Add(Me.Label22)
        Me.pnl201.Controls.Add(Me.Label23)
        Me.pnl201.Controls.Add(Me.lblBurner1)
        Me.pnl201.Controls.Add(Me.lblPressureValveStatus1)
        Me.pnl201.Controls.Add(Me.pbFlameType1)
        Me.pnl201.Controls.Add(Me.pbBurnerType1)
        Me.pnl201.Controls.Add(Me.pbStatusFuel1)
        Me.pnl201.Controls.Add(Me.pbStatusN2O1)
        Me.pnl201.Controls.Add(Me.pbStatusAir1)
        Me.pnl201.Controls.Add(Me.pbPressureFuel1)
        Me.pnl201.Controls.Add(Me.pbPressureN2O1)
        Me.pnl201.Controls.Add(Me.pbPressureAir1)
        Me.pnl201.Controls.Add(Me.lblPressures1)
        Me.pnl201.Controls.Add(Me.lblFRatio1)
        Me.pnl201.Controls.Add(Me.lblPressureN2O1)
        Me.pnl201.Controls.Add(Me.lblFlameRatio1)
        Me.pnl201.Controls.Add(Me.Label42)
        Me.pnl201.Location = New System.Drawing.Point(16, 32)
        Me.pnl201.Name = "pnl201"
        Me.pnl201.Size = New System.Drawing.Size(472, 120)
        Me.pnl201.TabIndex = 80
        '
        'lblFlameType1
        '
        Me.lblFlameType1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFlameType1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFlameType1.Location = New System.Drawing.Point(360, 56)
        Me.lblFlameType1.Name = "lblFlameType1"
        Me.lblFlameType1.Size = New System.Drawing.Size(44, 24)
        Me.lblFlameType1.TabIndex = 23
        Me.lblFlameType1.Text = "TYPE"
        Me.lblFlameType1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblBurnerType1
        '
        Me.lblBurnerType1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBurnerType1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBurnerType1.Location = New System.Drawing.Point(296, 56)
        Me.lblBurnerType1.Name = "lblBurnerType1"
        Me.lblBurnerType1.Size = New System.Drawing.Size(44, 24)
        Me.lblBurnerType1.TabIndex = 20
        Me.lblBurnerType1.Text = "TYPE"
        Me.lblBurnerType1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblStatusFuel1
        '
        Me.lblStatusFuel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStatusFuel1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatusFuel1.Location = New System.Drawing.Point(233, 54)
        Me.lblStatusFuel1.Name = "lblStatusFuel1"
        Me.lblStatusFuel1.Size = New System.Drawing.Size(44, 24)
        Me.lblStatusFuel1.TabIndex = 19
        Me.lblStatusFuel1.Text = "FUEL"
        Me.lblStatusFuel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblStatusN2O1
        '
        Me.lblStatusN2O1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStatusN2O1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatusN2O1.Location = New System.Drawing.Point(188, 54)
        Me.lblStatusN2O1.Name = "lblStatusN2O1"
        Me.lblStatusN2O1.Size = New System.Drawing.Size(44, 24)
        Me.lblStatusN2O1.TabIndex = 18
        Me.lblStatusN2O1.Text = "N2O"
        Me.lblStatusN2O1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblStatusAir1
        '
        Me.lblStatusAir1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStatusAir1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatusAir1.Location = New System.Drawing.Point(143, 54)
        Me.lblStatusAir1.Name = "lblStatusAir1"
        Me.lblStatusAir1.Size = New System.Drawing.Size(44, 24)
        Me.lblStatusAir1.TabIndex = 17
        Me.lblStatusAir1.Text = "AIR"
        Me.lblStatusAir1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblPressureFuel1
        '
        Me.lblPressureFuel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPressureFuel1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPressureFuel1.Location = New System.Drawing.Point(95, 54)
        Me.lblPressureFuel1.Name = "lblPressureFuel1"
        Me.lblPressureFuel1.Size = New System.Drawing.Size(44, 24)
        Me.lblPressureFuel1.TabIndex = 16
        Me.lblPressureFuel1.Text = "FUEL"
        Me.lblPressureFuel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.SystemColors.Control
        Me.Label17.Location = New System.Drawing.Point(352, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(2, 116)
        Me.Label17.TabIndex = 6
        Me.Label17.Text = "Label7"
        '
        'lblPressureAir1
        '
        Me.lblPressureAir1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPressureAir1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPressureAir1.Location = New System.Drawing.Point(5, 54)
        Me.lblPressureAir1.Name = "lblPressureAir1"
        Me.lblPressureAir1.Size = New System.Drawing.Size(44, 24)
        Me.lblPressureAir1.TabIndex = 14
        Me.lblPressureAir1.Text = "AIR"
        Me.lblPressureAir1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblFlame1
        '
        Me.lblFlame1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFlame1.Location = New System.Drawing.Point(360, 24)
        Me.lblFlame1.Name = "lblFlame1"
        Me.lblFlame1.Size = New System.Drawing.Size(80, 16)
        Me.lblFlame1.TabIndex = 11
        Me.lblFlame1.Text = "FLAME"
        Me.lblFlame1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.SystemColors.Control
        Me.Label21.Location = New System.Drawing.Point(278, 0)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(2, 116)
        Me.Label21.TabIndex = 4
        Me.Label21.Text = "Label5"
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.SystemColors.Control
        Me.Label22.Location = New System.Drawing.Point(140, 0)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(2, 116)
        Me.Label22.TabIndex = 2
        Me.Label22.Text = "Label3"
        '
        'Label23
        '
        Me.Label23.BackColor = System.Drawing.SystemColors.Control
        Me.Label23.Location = New System.Drawing.Point(0, 48)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(759, 2)
        Me.Label23.TabIndex = 0
        '
        'lblBurner1
        '
        Me.lblBurner1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBurner1.Location = New System.Drawing.Point(288, 24)
        Me.lblBurner1.Name = "lblBurner1"
        Me.lblBurner1.Size = New System.Drawing.Size(64, 16)
        Me.lblBurner1.TabIndex = 9
        Me.lblBurner1.Text = "BURNER"
        Me.lblBurner1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'lblPressureValveStatus1
        '
        Me.lblPressureValveStatus1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPressureValveStatus1.Location = New System.Drawing.Point(156, 8)
        Me.lblPressureValveStatus1.Name = "lblPressureValveStatus1"
        Me.lblPressureValveStatus1.Size = New System.Drawing.Size(108, 32)
        Me.lblPressureValveStatus1.TabIndex = 8
        Me.lblPressureValveStatus1.Text = "PRESSURE VALVE STATUS"
        Me.lblPressureValveStatus1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'pbFlameType1
        '
        Me.pbFlameType1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbFlameType1.Location = New System.Drawing.Point(368, 80)
        Me.pbFlameType1.Name = "pbFlameType1"
        Me.pbFlameType1.Size = New System.Drawing.Size(32, 32)
        Me.pbFlameType1.TabIndex = 77
        Me.pbFlameType1.Visible = False
        '
        'pbBurnerType1
        '
        Me.pbBurnerType1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbBurnerType1.Location = New System.Drawing.Point(304, 80)
        Me.pbBurnerType1.Name = "pbBurnerType1"
        Me.pbBurnerType1.Size = New System.Drawing.Size(32, 32)
        Me.pbBurnerType1.TabIndex = 75
        Me.pbBurnerType1.Visible = False
        '
        'pbStatusFuel1
        '
        Me.pbStatusFuel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbStatusFuel1.Location = New System.Drawing.Point(239, 80)
        Me.pbStatusFuel1.Name = "pbStatusFuel1"
        Me.pbStatusFuel1.Size = New System.Drawing.Size(32, 32)
        Me.pbStatusFuel1.TabIndex = 74
        Me.pbStatusFuel1.Visible = False
        '
        'pbStatusN2O1
        '
        Me.pbStatusN2O1.BackColor = System.Drawing.Color.Transparent
        Me.pbStatusN2O1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbStatusN2O1.Location = New System.Drawing.Point(194, 80)
        Me.pbStatusN2O1.Name = "pbStatusN2O1"
        Me.pbStatusN2O1.Size = New System.Drawing.Size(32, 32)
        Me.pbStatusN2O1.TabIndex = 73
        Me.pbStatusN2O1.Visible = False
        '
        'pbStatusAir1
        '
        Me.pbStatusAir1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbStatusAir1.Location = New System.Drawing.Point(149, 80)
        Me.pbStatusAir1.Name = "pbStatusAir1"
        Me.pbStatusAir1.Size = New System.Drawing.Size(32, 32)
        Me.pbStatusAir1.TabIndex = 72
        Me.pbStatusAir1.Visible = False
        '
        'pbPressureFuel1
        '
        Me.pbPressureFuel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbPressureFuel1.Location = New System.Drawing.Point(101, 80)
        Me.pbPressureFuel1.Name = "pbPressureFuel1"
        Me.pbPressureFuel1.Size = New System.Drawing.Size(32, 32)
        Me.pbPressureFuel1.TabIndex = 71
        Me.pbPressureFuel1.Visible = False
        '
        'pbPressureN2O1
        '
        Me.pbPressureN2O1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbPressureN2O1.Location = New System.Drawing.Point(55, 80)
        Me.pbPressureN2O1.Name = "pbPressureN2O1"
        Me.pbPressureN2O1.Size = New System.Drawing.Size(32, 32)
        Me.pbPressureN2O1.TabIndex = 70
        Me.pbPressureN2O1.Visible = False
        '
        'pbPressureAir1
        '
        Me.pbPressureAir1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbPressureAir1.Location = New System.Drawing.Point(11, 80)
        Me.pbPressureAir1.Name = "pbPressureAir1"
        Me.pbPressureAir1.Size = New System.Drawing.Size(32, 32)
        Me.pbPressureAir1.TabIndex = 69
        Me.pbPressureAir1.Visible = False
        '
        'lblPressures1
        '
        Me.lblPressures1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPressures1.Location = New System.Drawing.Point(16, 8)
        Me.lblPressures1.Name = "lblPressures1"
        Me.lblPressures1.Size = New System.Drawing.Size(110, 32)
        Me.lblPressures1.TabIndex = 7
        Me.lblPressures1.Text = "PRESSURES"
        Me.lblPressures1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'lblFRatio1
        '
        Me.lblFRatio1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFRatio1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFRatio1.Location = New System.Drawing.Point(408, 80)
        Me.lblFRatio1.Name = "lblFRatio1"
        Me.lblFRatio1.Size = New System.Drawing.Size(52, 32)
        Me.lblFRatio1.TabIndex = 64
        Me.lblFRatio1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblPressureN2O1
        '
        Me.lblPressureN2O1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPressureN2O1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPressureN2O1.Location = New System.Drawing.Point(50, 54)
        Me.lblPressureN2O1.Name = "lblPressureN2O1"
        Me.lblPressureN2O1.Size = New System.Drawing.Size(44, 24)
        Me.lblPressureN2O1.TabIndex = 15
        Me.lblPressureN2O1.Text = "N2O"
        Me.lblPressureN2O1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblFlameRatio1
        '
        Me.lblFlameRatio1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFlameRatio1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFlameRatio1.Location = New System.Drawing.Point(408, 56)
        Me.lblFlameRatio1.Name = "lblFlameRatio1"
        Me.lblFlameRatio1.Size = New System.Drawing.Size(52, 24)
        Me.lblFlameRatio1.TabIndex = 24
        Me.lblFlameRatio1.Text = "RATIO"
        Me.lblFlameRatio1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label42
        '
        Me.Label42.BackColor = System.Drawing.SystemColors.Control
        Me.Label42.Location = New System.Drawing.Point(0, 115)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(759, 2)
        Me.Label42.TabIndex = 40
        '
        'pnl203
        '
        Me.pnl203.BackColor = System.Drawing.Color.AliceBlue
        Me.pnl203.Controls.Add(Me.pbSafetyControlsTrap)
        Me.pnl203.Controls.Add(Me.lblFlameRatio)
        Me.pnl203.Controls.Add(Me.lblFlameType)
        Me.pnl203.Controls.Add(Me.lblSafetyControlsTrap)
        Me.pnl203.Controls.Add(Me.lblSafetyControlsDoor)
        Me.pnl203.Controls.Add(Me.lblBurnerType)
        Me.pnl203.Controls.Add(Me.lblStatusFuel)
        Me.pnl203.Controls.Add(Me.lblStatusN2O)
        Me.pnl203.Controls.Add(Me.lblStatusAir)
        Me.pnl203.Controls.Add(Me.lblPressureFuel)
        Me.pnl203.Controls.Add(Me.lblPressureN2O)
        Me.pnl203.Controls.Add(Me.lblPressureAir)
        Me.pnl203.Controls.Add(Me.lblFlame)
        Me.pnl203.Controls.Add(Me.lblSafetyControls)
        Me.pnl203.Controls.Add(Me.lblBurner)
        Me.pnl203.Controls.Add(Me.lblPressureValveStatus)
        Me.pnl203.Controls.Add(Me.lblPressures)
        Me.pnl203.Controls.Add(Me.Label7)
        Me.pnl203.Controls.Add(Me.Label6)
        Me.pnl203.Controls.Add(Me.Label5)
        Me.pnl203.Controls.Add(Me.Label3)
        Me.pnl203.Controls.Add(Me.Label1)
        Me.pnl203.Controls.Add(Me.pbStatusN2O)
        Me.pnl203.Controls.Add(Me.pbFlameType)
        Me.pnl203.Controls.Add(Me.pbSafetyControlsDoor)
        Me.pnl203.Controls.Add(Me.pbBurnerType)
        Me.pnl203.Controls.Add(Me.pbStatusFuel)
        Me.pnl203.Controls.Add(Me.pbStatusAir)
        Me.pnl203.Controls.Add(Me.pbPressureFuel)
        Me.pnl203.Controls.Add(Me.pbPressureN2O)
        Me.pnl203.Controls.Add(Me.pbPressureAir)
        Me.pnl203.Controls.Add(Me.lblBHeight)
        Me.pnl203.Controls.Add(Me.lblFRatio)
        Me.pnl203.Controls.Add(Me.Label2)
        Me.pnl203.Controls.Add(Me.lblBurnerHeight)
        Me.pnl203.Location = New System.Drawing.Point(8, 8)
        Me.pnl203.Name = "pnl203"
        Me.pnl203.Size = New System.Drawing.Size(600, 128)
        Me.pnl203.TabIndex = 81
        '
        'pbStatusN2O
        '
        Me.pbStatusN2O.BackColor = System.Drawing.Color.Transparent
        Me.pbStatusN2O.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbStatusN2O.Location = New System.Drawing.Point(200, 80)
        Me.pbStatusN2O.Name = "pbStatusN2O"
        Me.pbStatusN2O.Size = New System.Drawing.Size(32, 32)
        Me.pbStatusN2O.TabIndex = 73
        Me.pbStatusN2O.Visible = False
        '
        'frmManualIgnition
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(658, 344)
        Me.Controls.Add(Me.CustomPanel1)
        Me.Controls.Add(Me.custpnlStatusDisplay)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmManualIgnition"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.CustomPanel1.ResumeLayout(False)
        CType(Me.CommandBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tmrCheckManualIgnite, System.ComponentModel.ISupportInitialize).EndInit()
        Me.custpnlStatusDisplay.ResumeLayout(False)
        Me.pnl201.ResumeLayout(False)
        Me.pnl203.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Public Enums, Constants.. "

    Public Enum enumManualIgnitionProcess
        ManualIgnitionCheck
        SetAirOnOff
        SetN2OOnOff
        SetFuelOnOff
        SetIgniteOnOff
        IncreaseFuel
        DecreaseFuel
        SetMaxFuel
        IncreaseBurnerHeight
        DecreaseBurnerHeight
        SetMaxBurnerHeight
        AutoIgnition
        AutoExtinguish
    End Enum

#End Region

#Region " Private Class Variables "

    '--- Declaration for the controller object of the BgThread
    Private mobjController As New BgThread.clsBgThread(Me)
    Private WithEvents mobjclsBgManualIgnition As ClsBgManualIgnition


    Private mblnN2OPresure As Boolean = False
    Private blnPressureSensor1 As Boolean = True
    Private blnPressureSensor2 As Boolean = True
    Private blnPressureSensor3 As Boolean = True
    Private blnBurner As Boolean = False
    Private aa, ps1, ps2, ps3, air, n2, fuel, BIgnite As Boolean
    Private mobjThread As Threading.Thread
    Private Shared mintManualIgnitionProcess As enumManualIgnitionProcess
    Private Shared mblnIsStopThreadAndExit As Boolean
    Private mblnIsfrmFlameStatusWork As Boolean = False
    Private mblnInProcess As Boolean = False
    Private mblnIsManualIgnitionActivated As Boolean = False
    Private mblnIgnitionWait As Boolean = False
    Private mblnIgnitionTerminate As Boolean = False
    Private mintIgniteType As Integer
    'Private mblnAvoidProcessing As Boolean
    Private intFlameType As Integer
    Private mblnAvoidProcessing As Boolean = False

    'Private mblnFuelFlowRateMsgDisp As Boolean = False   'Commented on 30.03.09
    Private mblnFlamePresent As Boolean   '30.03.09
    'Private mblnIsN2OBurnerPresent As Boolean  '30.03.09    'commented on 26.04.09 for ver 4.87
    Private mblnFuelPressure As Boolean  '30.03.09
    Private mblnIsAir_Not_OK As Boolean = False
#End Region

#Region " Form Load and Events Handling Functions "

    Private Sub frmManualIgnition_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '=====================================================================
        ' Procedure Name        : frmManualIgnition_Load
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To initialize the form
        ' Description           : this is called when the form is loaded
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 27.11.06
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Dim intCtrlCount As Integer
        Dim status As Byte
        Try

            Me.Focus()
            btnClose.BringToFront()

            Me.Text = gstrTitleInstrumentType & " Manual Ignition"
            ''this will show Manual Ignition 
            mblnIsStopThreadAndExit = False

            Me.Focus()
            'Me.Refresh()

            'Call Manual_Init_Check()     'Commented by Saurabh

            'Application.DoEvents()
            ''allow application to perfrom its panding work
            Call AddHandlers()
            ''add all the events
            btnAirOnOff.Focus()
            ''get the focus on air button

            mintManualIgnitionProcess = enumManualIgnitionProcess.ManualIgnitionCheck

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
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

    Private Sub InitFromObject()
        Dim status As Byte
        If mblnAvoidProcessing Then
            Exit Sub
        End If
        Try
            Application.DoEvents()
            If Not IsNothing(gobjMain) Then
                If gobjMain.mobjController.IsThreadRunning = True Then
                    mblnIsfrmFlameStatusWork = True
                    gobjMain.mobjController.Cancel()
                    gobjCommProtocol.mobjCommdll.subTime_Delay(500)   '10.12.07
                    Application.DoEvents()
                End If
                Application.DoEvents()
            End If

            air = False
            n2 = False
            fuel = False
            BIgnite = False

            ''set some initial flag
            If gobjCommProtocol.func_IGNITE_OFF() Then
                ''this is a serial communication function which put off a ingition 
                'gobjInst.Aaf = False
            End If

            'If BIgnite = False Then
            btnIgnite.Text = "IGNITE ON"
            ''set text on button
            'Else
            '   btnIgnite.Text = "IGNITE ON"
            'End If
            gobjCommProtocol.mobjCommdll.subTime_Delay(20)
            ''delay
            status = gobjCommProtocol.funcGet_Pneum_Status()
            ''this is used To get the pnueumatics status
            ''and set a status flag as par return 

            '---Commented on 30.03.09
            ''If (status And EnumErrorStatus.SAIR_NON) Then
            ''    ''check for thta status should be true and display it on screen
            ''    air = True
            ''    btnAirOnOff.Text = ""
            ''Else
            ''    air = False
            ''    btnAirOnOff.Text = ""
            ''End If

            ''If (status And EnumErrorStatus.SN2O_NON) Then
            ''    ''check for thta status should be true and display it on screen
            ''    n2 = True
            ''    btnN2O.Text = ""
            ''Else
            ''    n2 = False
            ''    btnN2O.Text = ""
            ''End If

            ''If (status And EnumErrorStatus.SFUEL_ON) Then
            ''    ''check for thta status should be true and display it on screen
            ''    fuel = True
            ''    btnFuel.Text = ""
            ''Else
            ''    fuel = False
            ''    btnFuel.Text = ""
            ''End If
            '-------------------------------------

            '---Written on 30.03.09
            If (status And EnumErrorStatus.SAIR_NON) Then
                air = False
            Else
                air = True
            End If


            'If (status And EnumErrorStatus.SN2O_NON) Then  '---25.06.09 commented for version 4.91
            '    n2 = False
            'Else
            '    n2 = True
            'End If

            If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then  '---25.06.09 added for version 4.91
                If (status And EnumErrorStatus.SN2O_NON) Then
                    n2 = False
                Else
                    n2 = True
                End If
            Else
                If (status And EnumErrorStatus.SN2O_NON) Then
                    n2 = True
                Else
                    n2 = False
                End If
            End If


            If (status And EnumErrorStatus.SFUEL_ON) Then
                fuel = True
            Else
                fuel = False
            End If
            '-------------------------



            If mblnIsManualIgnitionActivated = False Then
                mblnAvoidProcessing = True

                If mobjController Is Nothing Then
                    mobjController = New clsBgThread(Me)
                End If
                If mobjclsBgManualIgnition Is Nothing Then
                    mobjclsBgManualIgnition = New ClsBgManualIgnition
                End If
                gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay)   '10.12.07
                Application.DoEvents()
                If mobjController.IsThreadRunning = False Then
                    mobjController.Start(mobjclsBgManualIgnition)
                    AddHandler mobjclsBgManualIgnition.ManualIgnition, AddressOf subWaitManualThread
                End If
                mblnIsManualIgnitionActivated = True
                mblnAvoidProcessing = False
            End If
            Me.Focus()
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
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

    Private Sub setVisibleFalse201Controls()
        '=====================================================================
        ' Procedure Name        : disable201Controls
        ' Parameters Passed     :  
        ' Returns               : None
        ' Purpose               :  
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Pankaj
        ' Created               : 30 May 07
        ' Revisions             : 
        '=====================================================================


        ''note:
        ''screen contains some control for 201 also
        ''and during the 203 it should hide

        Dim flag As Boolean = False
        If (gstructSettings.AppMode = EnumAppMode.FullVersion_201) Or _
        (gstructSettings.AppMode = EnumAppMode.DemoMode_201) Then
            btnAirOnOff.Visible = flag
            btnAutoIgnite.Visible = flag
            btnDecreaseBurnerHeight.Visible = flag
            btnDecreaseFuel.Visible = flag
            btnExtinguish.Visible = flag
            btnIgnite.Visible = flag
            btnIncreaseBurnerHeight.Visible = flag
            btnIncreaseFuel.Visible = flag
            btnSetMaxBurnerHeight.Visible = flag
            btnSetMaxFuel.Visible = flag

            lblBHeight.Visible = flag
            lblBurnerHeight.Visible = flag
            lblFlameRatio.Visible = flag
            lblFRatio.Visible = flag
            lblSafetyControlsTrap.Visible = flag
            pbSafetyControlsTrap.Visible = flag
            lblNVStep.Visible = flag
            lblNVStep1.Visible = flag
            lblSafetyControlsDoor.Visible = flag
            pbSafetyControlsDoor.Visible = flag

            '' code added by : dinesh wagh on 20.3.2009
            '... code start
            btnClose.Location = btnSetMaxFuel.Location
            pbPressureAir1.Visible = True
            pbPressureN2O1.Visible = True
            pbPressureFuel1.Visible = True
            pbStatusAir1.Visible = True
            pbStatusN2O1.Visible = True
            pbStatusFuel1.Visible = True
            pbBurnerType1.Visible = True
            pbFlameType1.Visible = True
            lblFRatio1.Visible = True
            ' code ends
            '......
        End If

    End Sub

    Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs)
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
            Application.DoEvents()
            If mblnIgnitionTerminate = False Then
                mobjclsBgManualIgnition.ThTerminate = True
                mobjclsBgManualIgnition.IgnitionWait = True
                mblnIgnitionWait = True
                gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay)   '10.12.07
                Application.DoEvents()
                Call btnClose_Click(sender, e)
                Exit Sub
            Else
                If Not (mobjController Is Nothing) Then
                    If mobjController.IsThreadRunning Then
                        mobjclsBgManualIgnition.ThTerminate = True
                        mobjclsBgManualIgnition.IgnitionWait = True
                        mblnIgnitionWait = True
                        mobjController.Cancel()
                        gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay)   '10.12.07
                        Application.DoEvents()
                    End If
                End If
                'Exit Sub
            End If
            gobjclsTimer.subTimerStop()
            Application.DoEvents()
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
            'Me.DialogResult = DialogResult.Cancel
            'Me.Close()
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub btnAirOnOff_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : btnAirOnOff_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To make the AIR Flow ON or OFF
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 27.11.06
        ' Revisions             : 
        '=====================================================================

        ''note:
        ''this is called when user clicked on Air button
        ''this is used to Put air on or off as paer cond
        ''step 1:first stop the thread 
        ''step 2:check air is on
        ''step 3:if yes then put air off else put air off
        ''step 4:do some onscreen validation as par cond






        If mblnInProcess = True Then
            ''htis is a flag which check for other running process
            Exit Sub
        End If
        Dim objWait As New CWaitCursor
        Try
            mblnInProcess = True

            'mblnIsStopThreadAndExit = True
            'mobjThread.Sleep(100)
            'mobjThread.Join()
            'If Not mobjThread.ThreadState = ThreadState.Suspended Then
            '    mobjThread.Suspend()
            'End If

            'mintManualIgnitionProcess = enumManualIgnitionProcess.SetAirOnOff
            mblnIgnitionWait = True
            mobjclsBgManualIgnition.IgnitionWait = True
            gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay)   '10.12.07
            Application.DoEvents()
            ''allow manual thread to be wait

            Application.DoEvents()
            ''allow application to perfrom its panding work

            Call subSetAirOnOff()

            ''this function is used for on or off the air

            mblnIgnitionWait = False
            mblnInProcess = False
            mobjclsBgManualIgnition.IgnitionWait = False
            gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay)   '10.12.07
            Application.DoEvents()
            'Call Manual_Init_Check()


            'mobjThread = New Threading.Thread(AddressOf subThreadStart)
            'mobjThread.IsBackground = True
            'mobjThread.Name = "Manual Ignition"

            'mobjThread.Resume()

            'Thread.Sleep(200)

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            mblnIgnitionWait = False
            mblnInProcess = False
            mobjclsBgManualIgnition.IgnitionWait = False
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            If Not (objWait Is Nothing) Then
                objWait.Dispose()
                objWait = Nothing
            End If
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub btnN2O_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : btnN2O_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To make the N2O Flow ON or OFF
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 27.11.06
        ' Revisions             : 
        '=====================================================================
        ''note:
        ''this is called when user clicked on N2O button
        ''this is used to Put N2O on or off as par cond
        ''step 1:first stop the thread 
        ''step 2:check N2O is on
        ''step 3:if yes then put N2O off else put N2O off
        ''step 4:do some onscreen validation as par cond


        If mblnInProcess = True Then
            Exit Sub
        End If
        Dim objWait As New CWaitCursor
        Try

            mblnInProcess = True
            mblnIgnitionWait = True
            mobjclsBgManualIgnition.IgnitionWait = True
            Application.DoEvents()
            gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay)   '10.12.07
            Application.DoEvents()

            Call subSetN2OOnOff()

            ''this function is used for the  on or off the N2            
            gobjCommProtocol.mobjCommdll.subTime_Delay(500)   '10.12.07
            mblnIgnitionWait = False
            mobjclsBgManualIgnition.IgnitionWait = False
            mblnInProcess = False
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            mblnIgnitionWait = False
            mobjclsBgManualIgnition.IgnitionWait = False
            mblnInProcess = False
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            
            If Not (objWait Is Nothing) Then
                objWait.Dispose()
                objWait = Nothing
            End If
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub btnFuel_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : btnFuel_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To make the FUEL Flow ON or OFF
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 29.11.06
        ' Revisions             : 
        '=====================================================================
        ''note:
        ''this is called when user clicked on FUEL button
        ''this is used to Put FUEL on or off as par cond
        ''step 1:first stop the thread 
        ''step 2:check FUEL is on
        ''step 3:if yes then put FUEL off else put FUEL off
        ''step 4:do some onscreen validation as par cond

        If mblnInProcess = True Then
            Exit Sub
        End If
        Dim objWait As New CWaitCursor
        Try

            '----------------
            If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then  '---02.08.09
                If mblnIsAir_Not_OK = True Then
                    gobjMessageAdapter.ShowMessage(98)
                    Application.DoEvents()
                    mblnInProcess = False
                    Exit Sub
                End If
            End If
            '----------------

            If mblnFuelPressure = True Then    '30.03.09
                mblnInProcess = True
                mblnIgnitionWait = True
                mobjclsBgManualIgnition.IgnitionWait = True
                Application.DoEvents()
                gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay)   '10.12.07
                Application.DoEvents()

                Call subSetFuelOnOff()

                '//--- Set the wait to  the manual flame ignit for AA201 03.10.08
                If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
                    ''If (Not (gobjInst.Aaf)) And (Not (gobjInst.N2of)) Then      '---commented on 30.03.09
                    ''    gobjCommProtocol.mobjCommdll.subTime_Delay(5000)   '03.10.07
                    ''End If

                    If mblnFlamePresent = False Then   '---added on 30.03.09
                        'gobjCommProtocol.mobjCommdll.subTime_Delay(5000)   '30.03.09
                        'gobjCommProtocol.mobjCommdll.subTime_Delay(3000)   '30.03.09  vck suggested
                        gobjCommProtocol.mobjCommdll.subTime_Delay(5000)   '19.04.09  vck suggested
                    End If

                End If
                '//---
                mblnIgnitionWait = False
                mblnInProcess = False
                mobjclsBgManualIgnition.IgnitionWait = False
            Else
                gobjMessageAdapter.ShowMessage(constLowFuelPressureRetry)   '30.03.09
            End If

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            mblnIgnitionWait = False
            mblnInProcess = False
            mobjclsBgManualIgnition.IgnitionWait = False
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            If Not (objWait Is Nothing) Then
                objWait.Dispose()
                objWait = Nothing
            End If
            Application.DoEvents()
            ''alloew application to perfrom its panding work
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub btnIgnite_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : btnIgnite_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To make the IGNITE ON or OFF
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 29.11.06
        ' Revisions             : 
        '=====================================================================

        ''note:
        ''this is called when user clicked on IGNITE button
        ''this is used to Put IGNITE on or off as par cond
        ''step 1:first stop the thread 
        ''step 2:check IGNITE is on
        ''step 3:if yes then put IGNITE off else put IGNITE off
        ''step 4:do some onscreen validation as par cond

        If mblnInProcess = True Then
            Exit Sub
        End If
        Dim objWait As New CWaitCursor
        Try

            mblnInProcess = True
            mblnIgnitionWait = True
            mblnInProcess = True
            mobjclsBgManualIgnition.IgnitionWait = True
            Application.DoEvents()
            gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay)   '10.12.07
            Application.DoEvents()
            'mblnIsStopThreadAndExit = True
            'mobjThread.Sleep(100)
            'mobjThread.Join()
            'mobjThread.Abort()
            'If Not mobjThread.ThreadState = ThreadState.Suspended Then
            '    mobjThread.Suspend()
            'End If

            'mintManualIgnitionProcess = enumManualIgnitionProcess.SetIgniteOnOff
            Call subSetIgniteOnOff()
            ''function for setting ignition

            ''this function on or off by sending proper protocols 
            'Call Manual_Init_Check()

            'mblnIsStopThreadAndExit = False
            'mobjThread = New Threading.Thread(AddressOf subThreadStart)
            'mobjThread.IsBackground = True
            'mobjThread.Name = "Manual Ignition"
            'mobjThread.Start()
            'mobjThread.Resume()
            'Thread.Sleep(200)
            gobjCommProtocol.mobjCommdll.subTime_Delay(500)   '10.12.07
            mblnIgnitionWait = False
            mblnInProcess = False
            mobjclsBgManualIgnition.IgnitionWait = False
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            mblnIgnitionWait = False
            mblnInProcess = False
            mobjclsBgManualIgnition.IgnitionWait = False
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            'mblnInProcess = False
            If Not (objWait Is Nothing) Then
                objWait.Dispose()
                objWait = Nothing
            End If
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub btnDecreaseBurnerHeight_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : btnDecreaseBurnerHeight_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To decrease the burner height.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 17.12.06
        ' Revisions             : 
        '=====================================================================

        ''note :
        ''this is called when user click on DecreaseBurnerHeight
        ''this will decrease the burner height by sending a protocol


        If mblnInProcess = True Then
            Exit Sub
        End If
        Dim objWait As New CWaitCursor
        Try

            mblnInProcess = True

            'mblnIsStopThreadAndExit = True
            'mobjThread.Sleep(100)
            'mobjThread.Join()
            'mobjThread.Abort()
            'If Not mobjThread.ThreadState = ThreadState.Suspended Then
            'mobjThread.Suspend()
            'End If
            mblnIgnitionWait = True
            mobjclsBgManualIgnition.IgnitionWait = True
            Application.DoEvents()
            gobjCommProtocol.mobjCommdll.subTime_Delay(50)   '10.12.07
            Application.DoEvents()
            'mintManualIgnitionProcess = enumManualIgnitionProcess.DecreaseBurnerHeight
            Call subDecreaseBurnerHeight()
            ''this will decerease the burner height 
            'Saurabh to set Bh step in the file "Bh.bhp" 11.07.07
            'Call gobjCommProtocol.funcSave_BH_Pos()
            'Saurabh

            'Call Manual_Init_Check()

            'mblnIsStopThreadAndExit = False
            'mobjThread = New Threading.Thread(AddressOf subThreadStart)
            'mobjThread.IsBackground = True
            'mobjThread.Name = "Manual Ignition"
            'mobjThread.Start()
            'If mobjThread.ThreadState = ThreadState.Suspended Then
            '    mobjThread.Resume()
            'End If
            'Thread.Sleep(200)
            Application.DoEvents()
            gobjCommProtocol.mobjCommdll.subTime_Delay(50)   '10.12.07
            Application.DoEvents()
            mblnInProcess = False
            mblnIgnitionWait = False
            mobjclsBgManualIgnition.IgnitionWait = False
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            mblnInProcess = False
            mblnIgnitionWait = False
            mobjclsBgManualIgnition.IgnitionWait = False
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            If Not (objWait Is Nothing) Then
                objWait.Dispose()
                objWait = Nothing
            End If
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub btnDecreaseFuel_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : btnDecreaseFuel_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To Decrease the Fuel.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 17.12.06
        ' Revisions             : 
        '=====================================================================
        ''note:
        ''this is called when user click on decreasefuel button
        ''before perfroming this ensure that thread should be stop

        If mblnInProcess = True Then
            Exit Sub
        End If
        Dim objWait As New CWaitCursor
        Try

            mblnInProcess = True
            mblnIgnitionWait = True
            mobjclsBgManualIgnition.IgnitionWait = True
            Application.DoEvents()
            gobjCommProtocol.mobjCommdll.subTime_Delay(50)   '10.12.07
            Application.DoEvents()
            ''allowing thread to stop

            'mblnIsStopThreadAndExit = True
            'mobjThread.Sleep(100)
            'mobjThread.Join()
            'mobjThread.Abort()
            'If Not mobjThread.ThreadState = ThreadState.Suspended Then
            'mobjThread.Suspend()
            'End If
            'mintManualIgnitionProcess = enumManualIgnitionProcess.DecreaseFuel
            Call subDecreaseFuel()
            ''this will decerease the fuel

            'Call Manual_Init_Check()

            'mblnIsStopThreadAndExit = False
            'mobjThread = New Threading.Thread(AddressOf subThreadStart)
            'mobjThread.IsBackground = True
            'mobjThread.Name = "Manual Ignition"
            'mobjThread.Start()
            'mobjThread.Resume()
            'Thread.Sleep(200)
            Application.DoEvents()
            gobjCommProtocol.mobjCommdll.subTime_Delay(50)   '10.12.07
            Application.DoEvents()
            mblnIgnitionWait = False
            mblnInProcess = False
            ''restart the thread
            mobjclsBgManualIgnition.IgnitionWait = False
            Application.DoEvents()
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            mblnIgnitionWait = False
            mblnInProcess = False
            mobjclsBgManualIgnition.IgnitionWait = False
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            If Not (objWait Is Nothing) Then
                objWait.Dispose()
                objWait = Nothing
            End If
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub btnIncreaseBurnerHeight_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : btnIncreaseBurnerHeight_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To increase the burner height.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 17.12.06
        ' Revisions             : 
        '=====================================================================

        ''note:
        ''this is called when user click on increaseBurnerHeight button 
        If mblnInProcess = True Then
            Exit Sub
        End If
        Dim objWait As New CWaitCursor
        Try

            mblnInProcess = True
            mblnIgnitionWait = True
            mobjclsBgManualIgnition.IgnitionWait = True
            Application.DoEvents()
            gobjCommProtocol.mobjCommdll.subTime_Delay(50)   '10.12.07
            Application.DoEvents()
            ''allow thread to stop

            'mblnIsStopThreadAndExit = True
            'mobjThread.Sleep(100)
            'mobjThread.Join()
            'mobjThread.Abort()
            'If Not mobjThread.ThreadState = ThreadState.Suspended Then
            'mobjThread.Suspend()
            'End If

            'mintManualIgnitionProcess = enumManualIgnitionProcess.IncreaseBurnerHeight
            Call subIncreaseBurnerHeight()
            'this will increase the burner height

            'Saurabh to set Bh step in the file "Bh.bhp" 11.07.07
            'Call gobjCommProtocol.funcSave_BH_Pos()
            'Saurabh

            'Call Manual_Init_Check()

            'mblnIsStopThreadAndExit = False
            'mobjThread = New Threading.Thread(AddressOf subThreadStart)
            'mobjThread.IsBackground = True
            'mobjThread.Name = "Manual Ignition"
            'mobjThread.Start()
            'If mobjThread.ThreadState = ThreadState.Suspended Then
            '    mobjThread.Resume()
            'End If
            'Thread.Sleep(200)
            Application.DoEvents()
            gobjCommProtocol.mobjCommdll.subTime_Delay(50)   '10.12.07
            Application.DoEvents()
            mblnIgnitionWait = False
            mblnInProcess = False
            mobjclsBgManualIgnition.IgnitionWait = False
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            mblnInProcess = False
            mblnIgnitionWait = False
            mobjclsBgManualIgnition.IgnitionWait = False
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            If Not (objWait Is Nothing) Then
                objWait.Dispose()
                objWait = Nothing
            End If
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub btnIncreaseFuel_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : btnIncreaseFuel_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To Increase the Fuel.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 17.12.06
        ' Revisions             : 
        '=====================================================================
        ''note:
        ''this is called when user click on increasefuel button
        If mblnInProcess = True Then
            Exit Sub
        End If
        Dim objWait As New CWaitCursor
        Try
            mblnInProcess = True
            mblnIgnitionWait = True
            mobjclsBgManualIgnition.IgnitionWait = True
            Application.DoEvents()
            gobjCommProtocol.mobjCommdll.subTime_Delay(50)   '10.12.07
            Application.DoEvents()
            ''first stop the thread

            'mblnIsStopThreadAndExit = True
            'mobjThread.Sleep(100)
            'mobjThread.Join()
            'mobjThread.Abort()
            'If Not mobjThread.ThreadState = ThreadState.Suspended Then
            '    mobjThread.Suspend()
            'End If

            'mintManualIgnitionProcess = enumManualIgnitionProcess.IncreaseFuel

            Call subIncreaseFuel()
            ''this will increase the fuel
            'Call Manual_Init_Check()

            'mblnIsStopThreadAndExit = False
            'mobjThread = New Threading.Thread(AddressOf subThreadStart)
            'mobjThread.IsBackground = True
            'mobjThread.Name = "Manual Ignition"
            'mobjThread.Start()
            'mobjThread.Resume()
            'Thread.Sleep(200)
            Application.DoEvents()
            gobjCommProtocol.mobjCommdll.subTime_Delay(50)   '10.12.07
            Application.DoEvents()
            mblnIgnitionWait = False
            mblnInProcess = False
            mobjclsBgManualIgnition.IgnitionWait = False
            ''restart the thread
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
            mblnIgnitionWait = False
            mblnInProcess = False
            mobjclsBgManualIgnition.IgnitionWait = False
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            If Not (objWait Is Nothing) Then
                objWait.Dispose()
                objWait = Nothing
            End If
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub btnSetMaxBurnerHeight_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : btnSetMaxBurnerHeight_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To set the MAX burner height.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 25.01.07
        ' Revisions             : 
        '=====================================================================
        ''note:
        ''this is called when user click on set max burner height

        If mblnInProcess = True Then
            Exit Sub
        End If
        Dim objWait As New CWaitCursor
        Try
            mblnInProcess = True
            mblnIgnitionWait = True
            mobjclsBgManualIgnition.IgnitionWait = True
            Application.DoEvents()
            gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay)   '10.12.07
            Application.DoEvents()
            ''stop the thread

            'mblnIsStopThreadAndExit = True
            'mobjThread.Sleep(100)
            'mobjThread.Join()
            'mobjThread.Abort()
            'If Not mobjThread.ThreadState = ThreadState.Suspended Then
            '    mobjThread.Suspend()
            'End If

            'mintManualIgnitionProcess = enumManualIgnitionProcess.SetMaxBurnerHeight
            Call subSetMaxBurnerHeight()
            ''this function will set the burner to its max height

            'Call Manual_Init_Check()

            'mblnIsStopThreadAndExit = False
            'mobjThread = New Threading.Thread(AddressOf subThreadStart)
            'mobjThread.IsBackground = True
            'mobjThread.Name = "Manual Ignition"
            'mobjThread.Start()
            'mobjThread.Resume()
            'Thread.Sleep(200)
            Application.DoEvents()
            gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay)   '10.12.07
            Application.DoEvents()
            mblnIgnitionWait = False
            mblnInProcess = False
            mobjclsBgManualIgnition.IgnitionWait = False
            ''restart the thread

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
            mblnIgnitionWait = False
            mblnInProcess = False
            mobjclsBgManualIgnition.IgnitionWait = False
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            'mblnInProcess = False
            If Not (objWait Is Nothing) Then
                objWait.Dispose()
                objWait = Nothing
            End If
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub btnSetMaxFuel_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : btnSetMaxFuel_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To set the MAX fuel.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 25.01.07
        ' Revisions             : 
        '=====================================================================
        ''note:
        ''this is called when user click on maxfuel button


        If mblnInProcess = True Then
            Exit Sub
        End If
        Dim objWait As New CWaitCursor
        Try
            mblnInProcess = True
            mblnIgnitionWait = True
            mobjclsBgManualIgnition.IgnitionWait = True
            Application.DoEvents()
            gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay)   '10.12.07
            Application.DoEvents()
            ''stop the thread first

            'mblnIsStopThreadAndExit = True
            'mobjThread.Sleep(100)
            'mobjThread.Join()
            'mobjThread.Abort()
            'If Not mobjThread.ThreadState = ThreadState.Suspended Then
            '    mobjThread.Suspend()
            'End If

            'mintManualIgnitionProcess = enumManualIgnitionProcess.SetMaxFuel
            Call subSetMaxFuel() ''

            ''this will set the max fuel

            'Call Manual_Init_Check()

            'mblnIsStopThreadAndExit = False
            'mobjThread = New Threading.Thread(AddressOf subThreadStart)
            'mobjThread.IsBackground = True
            'mobjThread.Name = "Manual Ignition"
            'mobjThread.Start()
            'mobjThread.Resume()
            'Thread.Sleep(200)
            Application.DoEvents()
            gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay)   '10.12.07
            Application.DoEvents()
            mblnIgnitionWait = False
            mblnInProcess = False
            mobjclsBgManualIgnition.IgnitionWait = False
            ''restart the thread

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
            mblnIgnitionWait = False
            mblnInProcess = False
            mobjclsBgManualIgnition.IgnitionWait = False
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            If Not (objWait Is Nothing) Then
                objWait.Dispose()
                objWait = Nothing
            End If
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Sub

    'Private Sub btnALT_I_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnALT_I.Click
    '    '=====================================================================
    '    ' Procedure Name        : btnALT_I_Click
    '    ' Parameters Passed     : Object, EventArgs
    '    ' Returns               : 
    '    ' Purpose               : To make the necessary adjustments and auto 
    '    '                       : ignite the flame.
    '    ' Description           : 
    '    ' Assumptions           : 
    '    ' Dependencies          : 
    '    ' Author                : Saurabh S
    '    ' Created               : 07-02-2007
    '    ' Revisions             : 
    '    '=====================================================================
    '    Try
    '        mblnIsStopThreadAndExit = True
    '        mobjThread.Sleep(100)
    '        mobjThread.Join()
    '        mobjThread.Abort()

    '        mintManualIgnitionProcess = enumManualIgnitionProcess.AutoIgnition

    '        Call subAutoIgnition()

    '        mblnIsStopThreadAndExit = False
    '        mobjThread = New Threading.Thread(AddressOf subThreadStart)
    '        mobjThread.IsBackground = True
    '        mobjThread.Name = "Manual Ignition"
    '        mobjThread.Start()
    '        Thread.Sleep(500)

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

    'Private Sub cmdBarBtnIgnite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Try
    '        cmdBarBtnIgnite.SuspendEvents()

    '        'mblnIsStopThreadAndExit = True
    '        mobjThread.Sleep(100)
    '        'mobjThread.Join()
    '        'mobjThread.Abort()
    '        mobjThread.Suspend()

    '        'mintManualIgnitionProcess = enumManualIgnitionProcess.AutoIgnition

    '        Call subAutoIgnition()

    '        'mblnIsStopThreadAndExit = False
    '        'mintManualIgnitionProcess = enumManualIgnitionProcess.ManualIgnitionCheck
    '        'mobjThread = New Threading.Thread(AddressOf subThreadStart)
    '        'mobjThread.IsBackground = True
    '        'mobjThread.Name = "Manual Ignition"
    '        'mobjThread.Start()
    '        mobjThread.Resume()
    '        Thread.Sleep(500)

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
    '        cmdBarBtnIgnite.ResumeEvents()
    '        '---------------------------------------------------------
    '    End Try
    'End Sub

    'Private Sub cmdBarBtnExtinguish_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    '=====================================================================
    '    ' Procedure Name        : btnALT_I_Click
    '    ' Parameters Passed     : Object, EventArgs
    '    ' Returns               : 
    '    ' Purpose               : To make the necessary adjustments and auto 
    '    '                       : ignite the flame.
    '    ' Description           : 
    '    ' Assumptions           : 
    '    ' Dependencies          : 
    '    ' Author                : Saurabh S
    '    ' Created               : 07-02-2007
    '    ' Revisions             : 
    '    '=====================================================================
    '    Try
    '        cmdBarBtnExtinguish.SuspendEvents()
    '        mblnIsStopThreadAndExit = True
    '        mobjThread.Sleep(100)
    '        'mobjThread.Join()
    '        'mobjThread.Abort()
    '        mobjThread.Suspend()

    '        'mintManualIgnitionProcess = enumManualIgnitionProcess.AutoExtinguish

    '        Call subAutoExtinguish()

    '        'mblnIsStopThreadAndExit = False
    '        'mintManualIgnitionProcess = enumManualIgnitionProcess.ManualIgnitionCheck
    '        'mobjThread = New Threading.Thread(AddressOf subThreadStart)
    '        'mobjThread.IsBackground = True
    '        'mobjThread.Name = "Manual Ignition"
    '        'mobjThread.Start()
    '        mobjThread.Resume()
    '        Thread.Sleep(500)

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
    '        cmdBarBtnExtinguish.ResumeEvents()
    '        '---------------------------------------------------------
    '    End Try
    'End Sub

#End Region

#Region " Private Functions "

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
        ' Created               : 27.11.06
        ' Revisions             : 
        '=====================================================================
        Try
            ''this function is used for adding a event to a control
            ''for eg btnClose_Click is called when user click on close button 
            AddHandler btnClose.Click, AddressOf btnClose_Click

            AddHandler btnN2O.Click, AddressOf btnN2O_Click
            AddHandler btnFuel.Click, AddressOf btnFuel_Click
            AddHandler btnIgnite.Click, AddressOf btnIgnite_Click
            AddHandler btnN2OIgnite.Click, AddressOf btnN2OIgnite_Click
            AddHandler btnAirOnOff.Click, AddressOf btnAirOnOff_Click
            AddHandler btnSetMaxFuel.Click, AddressOf btnSetMaxFuel_Click
            AddHandler btnDecreaseFuel.Click, AddressOf btnDecreaseFuel_Click
            AddHandler btnIncreaseFuel.Click, AddressOf btnIncreaseFuel_Click
            AddHandler btnSetMaxBurnerHeight.Click, AddressOf btnSetMaxBurnerHeight_Click
            AddHandler btnDecreaseBurnerHeight.Click, AddressOf btnDecreaseBurnerHeight_Click
            AddHandler btnIncreaseBurnerHeight.Click, AddressOf btnIncreaseBurnerHeight_Click
            AddHandler btnDelete.Click, AddressOf btnDelete_Click
            AddHandler btnR.Click, AddressOf btnR_Click
            AddHandler btnExtinguish.Click, AddressOf btnExtinguish_Click
            AddHandler btnAutoIgnite.Click, AddressOf btnAutoIgnite_Click
            AddHandler btnN2OIgnite.Click, AddressOf btnN2OIgnite_Click


            'AddHandler cmdBarBtnIgnite.Click, AddressOf cmdBarBtnIgnite_Click
            'AddHandler cmdBarBtnExtinguish.Click, AddressOf cmdBarBtnExtinguish_Click



        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
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

    Private Sub funcInitialise()
        '=====================================================================
        ' Procedure Name        : frmManualIgnition_Load
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To initialize the form
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 27.11.06
        ' Revisions             : 
        '=====================================================================
        Dim blnFlag As Boolean = True
        Dim bData As Byte

        'void	Manual_Init_Check(HDC hdc)
        '{
        'BYTE data;
        '  if (!Commflag)
        '	 return;
        '	Status_Disp();
        '	aa = ps1 = ps2 = ps3 = ON;
        '	data  = CHECK_PS();
        '	if (data & AIR_NOK) ps1 = OFF;
        '	if (data & N2O_NOK) ps2 = OFF;
        '	if (data & FUEL_NOK) ps3 = OFF;
        '	data = CHECK_BUR_PAR();
        '	if (data & AA_CONNECTED) aa = ON;
        '	if (!ps1)  {
        '	  Wprintf(hdc, 20, 0, " No AIR Pressure  ");
        '	  if (! ( air))  air = AIR_ON();
        '	 }
        '	if (!ps2) {
        '	  Wprintf(hdc, 20, 15, " No N‘O Pressure  ");
        '	  if( n2)  n2 = N2O_OFF();
        '	 }
        '	if (!ps3) {
        '	  Wprintf(hdc, 20, 30," No FUEL Pressure  ");
        '	  if ( fuel)  fuel = FUEL_OFF();
        '	 }
        '	if (aa) Wprintf(hdc, 20, 45 ," AA  Burner  attached ");
        '	else Wprintf(hdc, 20, 45 ," N2o Burner attached ");
        '}

        ''note:
        ''this function is called during the loading of a form
        ''in this we perfrom some initial setup like text name
        ''image etc.


        Try
            gobjCommProtocol.funcCheckBurnerParameters(bData)
            ''this function is for To check Burner parameters
            ''here we have to passed byte arry
            ''which will return byte holding data.

            

            '===commented on 24.04.09
            ''If (bData And EnumErrorStatus.AA_CONNECTED) Then
            ''    lblBurnerStatus.Text = "AA"
            ''    pbBurnerType.Image = Image.FromFile(Application.StartupPath & "\" & "images\BTAA.bmp")
            ''Else
            ''    lblBurnerStatus.Text = "NA"
            ''    pbBurnerType.Image = Image.FromFile(Application.StartupPath & "\" & "images\BTNA.bmp")
            ''End If
            '===commented on 24.04.09

            '===written on 24.04.09
            If gblnBurnerMsg = False Then
                If (bData And EnumErrorStatus.AA_CONNECTED) Then
                    lblBurnerStatus.Text = "AA"
                    pbBurnerType.Image = Image.FromFile(Application.StartupPath & "\" & "images\BTAA.bmp")
                Else
                    lblBurnerStatus.Text = "NA"
                    pbBurnerType.Image = Image.FromFile(Application.StartupPath & "\" & "images\BTNA.bmp")
                End If
            Else
                lblBurnerStatus.Text = "NONE"
                pbBurnerType.Image = Image.FromFile(Application.StartupPath & "\" & "images\ERROR.BMP")
            End If
            '===written on 24.04.09


            ' If gobjCommProtocol.funcPressSensorStatus(bData) Then
            If (bData And EnumErrorStatus.AIR_NOK) Then
                blnPressureSensor1 = True
            Else
                blnPressureSensor1 = False
            End If

            If (bData And EnumErrorStatus.N2O_NOK) Then
                blnPressureSensor2 = True
            Else
                blnPressureSensor2 = False
            End If

            If (bData And EnumErrorStatus.FUEL_NOK) Then
                blnPressureSensor3 = True
            Else
                blnPressureSensor3 = False
            End If

            If blnPressureSensor1 = False Then
                lblAir.Text = "NO"
                pbPressureAir.Image = Image.FromFile(Application.StartupPath & "\" & "images\ERROR.BMP")
            Else
                lblAir.Text = "YES"
                pbPressureAir.Image = Image.FromFile(Application.StartupPath & "\" & "images\OK.BMP")
            End If

            If blnBurner = False And blnPressureSensor2 = False Then
                lblN2O.Text = "NO"
                pbPressureN2O.Image = Image.FromFile(Application.StartupPath & "\" & "images\ERROR.BMP")
                mblnN2OPresure = False
            Else
                lblN2O.Text = "YES"
                pbPressureN2O.Image = Image.FromFile(Application.StartupPath & "\" & "images\OK.BMP")
                mblnN2OPresure = True
            End If

            If blnPressureSensor3 = False Then
                lblFuel.Text = "NO"
                pbPressureFuel.Image = Image.FromFile(Application.StartupPath & "\" & "images\ERROR.BMP")
            Else
                lblFuel.Text = "YES"
                pbPressureFuel.Image = Image.FromFile(Application.StartupPath & "\" & "images\OK.BMP")
            End If


            ' End If

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
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

    Private Function Manual_Init_Check() As Boolean
        '=====================================================================
        ' Procedure Name        : Manual_Init_Check
        ' Parameters Passed     : None
        ' Returns               : True if success
        ' Purpose               : To set the parameters on form load.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 02.02.07
        ' Revisions             : 
        '=====================================================================
        'void	Manual_Init_Check(HDC hdc)
        '{
        'BYTE data;
        '  if (!Commflag)
        '	 return;
        '	Status_Disp();
        '	aa = ps1 = ps2 = ps3 = ON;
        '	data  = CHECK_PS();
        '	if (data & AIR_NOK) ps1 = OFF;
        '	if (data & N2O_NOK) ps2 = OFF;
        '	if (data & FUEL_NOK) ps3 = OFF;
        '	data = CHECK_BUR_PAR();
        '	if (data & AA_CONNECTED) aa = ON;
        '	if (!ps1)  {
        '	  Wprintf(hdc, 20, 0, " No AIR Pressure  ");
        '	  if (! ( air))  air = AIR_ON();
        '	 }
        '	if (!ps2) {
        '	  Wprintf(hdc, 20, 15, " No N‘O Pressure  ");
        '	  if( n2)  n2 = N2O_OFF();
        '	 }
        '	if (!ps3) {
        '	  Wprintf(hdc, 20, 30," No FUEL Pressure  ");
        '	  if ( fuel)  fuel = FUEL_OFF();
        '	 }
        '	if (aa) Wprintf(hdc, 20, 45 ," AA  Burner  attached ");
        '	else Wprintf(hdc, 20, 45 ," N2o Burner attached ");
        '}

        Dim BData As Byte

        Try
            Me.custpnlStatusDisplay.Height = 120
            Me.Height = 320

            If Status_Disp() = False Then
                ''To set the parameters on form load.
                Exit Function
            End If

            aa = True   ' To check for AA burner parameter status
            ps1 = True  ' To check for Air pressure 
            ps2 = True  ' To check for N2O pressure 
            ps3 = True  ' To check for Fuel pressure 

            gobjCommProtocol.mobjCommdll.subTime_Delay(100)
            ''for delay
            If mblnIgnitionWait = False Then
                ''set flag for stop thread
                'Retrive Pressure sensor status from Instrument
                If gobjCommProtocol.funcPressSensorStatus(BData, False) = False Then
                    ''To check pressure sensors for AIR, N2O, Fuel etc.
                    Exit Function
                End If
            Else
                Exit Function
            End If

            If (BData And EnumErrorStatus.AIR_NOK) Then
                ps1 = False
            End If
            If (BData And EnumErrorStatus.N2O_NOK) Then
                ps2 = False
            End If
            If (BData And EnumErrorStatus.FUEL_NOK) Then
                ps3 = False
            End If
            gobjCommProtocol.mobjCommdll.subTime_Delay(20)
            ''delay
            If mblnIgnitionWait = False Then
                If gobjCommProtocol.funcCheckBurnerParameters(BData) = False Then
                    ''To check Burner parameters 
                    Exit Function
                End If
            Else
                Exit Function
            End If

            If (BData And EnumErrorStatus.AA_CONNECTED) Then
                aa = True
            Else
                aa = False
            End If
            '--- To check air pressure status
            If Not ps1 Then
                lblAirPressure.Visible = True
                lblAir.Visible = True
                lblAir.Text = "NO"
                If Not air Then
                    gobjCommProtocol.mobjCommdll.subTime_Delay(20)
                    ''delay
                    If mblnIgnitionWait = False Then

                        '---Commented on 30.03.09
                        'air = gobjCommProtocol.funcAir_ON()  
                        '--------

                        '---Written on 30.03.09
                        If gobjCommProtocol.funcAir_ON() = True Then
                            air = True
                        End If
                        '--------------

                        ''To set AIR on
                    Else
                        Exit Function
                    End If
                End If
            Else            'Else part added by Saurabh-----22.06.07
                lblAirPressure.Visible = False
                lblAir.Visible = False
                'lblAir.Text = "Yes"
            End If

            '--- To check N2O status
            If Not ps2 Then
                lblN2OPressure.Visible = True
                lblN2O.Visible = True
                lblN2O.Text = "NO"
                If n2 Then  ' hold the staus of N2O flame ignition
                    gobjCommProtocol.mobjCommdll.subTime_Delay(20)
                    ''delay
                    If mblnIgnitionWait = False Then
                        '---Commented on 30.03.09
                        'n2 = gobjCommProtocol.func_N2O_OFF()    
                        '------------

                        '---Written on 30.03.09
                        If gobjCommProtocol.func_N2O_OFF() = True Then
                            n2 = False
                        End If
                        '------------

                        ''serial communication function for setting N2O off
                    Else
                        Exit Function
                    End If
                    n2 = False
                End If
            End If
            '--- To check Fuel status
            If Not ps3 Then
                lblFuelPressure.Visible = True
                lblFuel.Visible = True
                lblFuel.Text = "NO"
                If fuel Then
                    ''delay
                    If mblnIgnitionWait = False Then
                        gobjCommProtocol.mobjCommdll.subTime_Delay(20)
                        ''serial communication for setting FUEL off
                        If gobjCommProtocol.func_FUEL_OFF() = True Then
                        End If
                    Else
                        Exit Function
                    End If
                    fuel = False
                End If
            End If

            '===commented on 24.04.09
            '--- To check Burner parameter status
            ''If aa Then
            ''    lblBurnerAttached.Visible = True
            ''    lblBurnerStatus.Text = "AA"
            ''    lblBurnerStatus.Visible = True
            ''Else
            ''    lblBurnerAttached.Visible = True
            ''    lblBurnerStatus.Text = "NA"
            ''    lblBurnerStatus.Visible = True
            ''End If
            '===commented on 24.04.09

            '===written on 24.04.09
            If gblnBurnerMsg = False Then
                If aa Then
                    lblBurnerAttached.Visible = True
                    lblBurnerStatus.Text = "AA"
                    lblBurnerStatus.Visible = True
                Else
                    lblBurnerAttached.Visible = True
                    lblBurnerStatus.Text = "NA"
                    lblBurnerStatus.Visible = True
                End If
            Else
                lblBurnerAttached.Visible = True
                lblBurnerStatus.Text = "NONE"
                lblBurnerStatus.Visible = True
            End If
            '===written on 24.04.09

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
            Application.DoEvents()
        End Try
    End Function

    Private Function Status_Disp() As Boolean
        '=====================================================================
        ' Procedure Name        : Status_Disp
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To set the parameters on form load.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 02.02.07
        ' Revisions             : 
        '=====================================================================
        Dim line1 As String
        Dim status, st, st1 As Byte
        Dim flag As Boolean = True
        Dim intFlameStatus As Integer
        Dim intflag As Integer = 0
        Try
            gobjCommProtocol.mobjCommdll.subTime_Delay(20)
            ''delay
            If mblnIgnitionWait = False Then
                status = gobjCommProtocol.funcGet_Pneum_Status()
                ''check the status of pneumentic setting
            Else
                Exit Function
            End If
            gobjCommProtocol.mobjCommdll.subTime_Delay(20)
            ''delay

            If gstructSettings.AppMode = EnumAppMode.FullVersion_203 Or _
                gstructSettings.AppMode = EnumAppMode.FullVersion_203D Then
                '---Added by deepak on 29.12.08
                gobjClsAAS203.funcCheck_Flame()
                '------------
            End If


            If mblnIgnitionWait = False Then
                gobjCommProtocol.funcPressSensorStatus(st, False)
                ''check the pressure sensor status
            Else
                Exit Function
            End If
            gobjCommProtocol.mobjCommdll.subTime_Delay(20)
            If mblnIgnitionWait = False Then
                If gobjCommProtocol.funcCheckBurnerParameters(st1) = False Then
                    ''cheack for a burner parameter status
                    Exit Function
                End If
            Else
                Exit Function
            End If

            '---Burner Head Confirmation    'added on 30.03.09
            '---------------------------------------------------------
            If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
                If gstructSettings.NewModelName = True Then   '---changed for ver 6.89
                    If (st1 And EnumErrorStatus.BurnerHead_Present) Then
                        btnFuel.Enabled = True
                        'btnN2O.Enabled = True
                        '---condition added as it is required by vck for testing 07.05.09
                        If gstructSettings.ExeToRun = EnumApplicationMode.ServiceUtility Then
                            btnN2O.Enabled = True
                        Else
                            '---added on 26.04.09 for ver 4.87
                            If mblnFlamePresent = True Then
                                btnN2O.Enabled = True
                            Else
                                btnN2O.Enabled = False
                            End If
                        End If
                        '---------------

                        gblnBurnerMsg = False
                    Else
                        btnFuel.Enabled = False
                        btnN2O.Enabled = False
                        gobjCommProtocol.func_N2O_OFF()
                        gobjCommProtocol.func_FUEL_OFF()
                        If gblnBurnerMsg = False Then
                            'Call gobjMessageAdapter.ShowMessage("Burner Head/Tether not present", "Warning", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage)
                            gobjMessageAdapter.ShowMessage(constBurnerHeadMsg)
                            gblnBurnerMsg = True
                        End If
                    End If
                End If
            End If
            '---------------------------------------------------------

            If (st And EnumErrorStatus.AIR_NOK) Then
                flag = False
                mblnIsAir_Not_OK = True
                ' code commented by: dinesh wagh on 20.3.2009
                ''......
                ''pbPressureAir.Image = Image.FromFile(Application.StartupPath & "\" & "images\ERROR.BMP")
                ''If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
                ''    'btnFuel.Visible = False         'Saruabh----22.06.07
                ''End If
                ''.........

                ' code added by : dinesh wagh on 20.3.2009
                ' code start
                If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Or _
                    gstructSettings.AppMode = EnumAppMode.DemoMode_201 Then
                    pbPressureAir1.Image = Image.FromFile(Application.StartupPath & "\" & "images\ERROR.BMP")
                Else
                    pbPressureAir.Image = Image.FromFile(Application.StartupPath & "\" & "images\ERROR.BMP")
                End If
                ' code ends

            Else
                mblnIsAir_Not_OK = False


                ' code commented by : dinesh wagh on 20.3.2009
                '''pbPressureAir.Image = Image.FromFile(Application.StartupPath & "\" & "images\OK.BMP")
                '''If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
                '''    btnFuel.Visible = True          'Saruabh----22.06.07
                '''End If
                '........

                ' code added by : dinesh wagh on 20.3.2009
                '... code start

                If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Or _
                    gstructSettings.AppMode = EnumAppMode.DemoMode_201 Then

                    pbPressureAir1.Image = Image.FromFile(Application.StartupPath & "\" & "images\OK.BMP")
                    btnFuel.Visible = True
                Else
                    pbPressureAir.Image = Image.FromFile(Application.StartupPath & "\" & "images\OK.BMP")
                End If
                '.... code ends
            End If

            If (st And EnumErrorStatus.N2O_NOK) Then
                flag = False

                ' code commented by: dinesh wagh on 20.3.2009
                ''pbPressureN2O.Image = Image.FromFile(Application.StartupPath & "\" & "images\ERROR.BMP")
                ''If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
                ''    btnN2O.Visible = False         'Saruabh----22.06.07
                ''

                ' code added by: dinesh wagh on 20.3.2009
                If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Or _
                    gstructSettings.AppMode = EnumAppMode.DemoMode_201 Then

                    If gstructSettings.ExeToRun = EnumApplicationMode.AAS Then   '---21.09.09
                        btnN2O.Visible = False
                    End If
                    pbPressureN2O1.Image = Image.FromFile(Application.StartupPath & "\" & "images\ERROR.BMP") ' code added by : dinesh wagh on 20.3.2009
                Else
                    pbPressureN2O.Image = Image.FromFile(Application.StartupPath & "\" & "images\ERROR.BMP")
                End If
            Else
                ' code commented by : dinesh wagh on 20.3.2009
                ' comment start
                ''pbPressureN2O.Image = Image.FromFile(Application.StartupPath & "\" & "images\OK.BMP")
                ''If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
                ''    'btnN2O.Visible = True         'Saruabh----22.06.07
                ''    If (st1 And EnumErrorStatus.AA_CONNECTED) Then
                ''        btnN2O.Visible = False         'Saruabh----22.06.07
                ''    Else
                ''        btnN2O.Visible = True         'Saruabh----22.06.07
                ''    End If

                ''End If
                ' comment end


                ' code added by: dinesh wagh on 20.3.2009
                'code start
                If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Or _
                    gstructSettings.AppMode = EnumAppMode.DemoMode_201 Then

                    pbPressureN2O1.Image = Image.FromFile(Application.StartupPath & "\" & "images\OK.BMP")
                    If (st1 And EnumErrorStatus.AA_CONNECTED) Then
                        If gstructSettings.ExeToRun = EnumApplicationMode.AAS Then   '---21.09.09
                            btnN2O.Visible = False
                        End If
                    Else
                        btnN2O.Visible = True

                        '---condition added as it is required by vck for testing 07.05.09
                        If gstructSettings.ExeToRun = EnumApplicationMode.ServiceUtility Then
                            btnN2O.Enabled = True
                        Else
                            '---added on 26.04.09 for ver 4.87
                            If mblnFlamePresent = True Then
                                btnN2O.Enabled = True
                            Else
                                btnN2O.Enabled = False
                            End If
                            '---------------
                        End If


                    End If
                Else
                    pbPressureN2O.Image = Image.FromFile(Application.StartupPath & "\" & "images\OK.BMP")
                End If
                'code ends

            End If

            pbPressureN2O.Refresh()
            pbPressureN2O1.Refresh() '20.3.2009 by dinesh

            If (st And EnumErrorStatus.FUEL_NOK) Then
                mblnFuelPressure = False '---added on 30.03.09
                flag = False
                'pbPressureFuel.Image = Image.FromFile(Application.StartupPath & "\" & "images\ERROR.BMP") 'by dinesh on 20.3.2009


                'added by: dinesh wagh on 20.3.2009
                If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Or _
                    gstructSettings.AppMode = EnumAppMode.DemoMode_201 Then
                    pbPressureFuel1.Image = Image.FromFile(Application.StartupPath & "\" & "images\ERROR.BMP")
                Else
                    pbPressureFuel.Image = Image.FromFile(Application.StartupPath & "\" & "images\ERROR.BMP")
                End If


            Else
                mblnFuelPressure = True '---added on 30.03.09
                'pbPressureFuel.Image = Image.FromFile(Application.StartupPath & "\" & "images\OK.BMP") 'by dinesh wagh on 20.3.2009

                'added by: dinesh wagh on 20.3.2009
                If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Or _
                    gstructSettings.AppMode = EnumAppMode.DemoMode_201 Then
                    pbPressureFuel1.Image = Image.FromFile(Application.StartupPath & "\" & "images\OK.BMP")
                Else
                    pbPressureFuel.Image = Image.FromFile(Application.StartupPath & "\" & "images\OK.BMP")
                End If



            End If
            pbPressureFuel.Refresh()
            pbPressureFuel1.Refresh() 'by dinesh wagh on 20.3.2009



            If (status And EnumErrorStatus.SAIR_NON) Then
                flag = False
                air = False
                btnAirOnOff.Text = "AIR ON"

                'pbStatusAir.Image = Image.FromFile(Application.StartupPath & "\" & "images\close.BMP")' by dinesh wagh on 20.3.2009


                ' code added by : dinesh wagh on 20.3.2009
                If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Or _
                    gstructSettings.AppMode = EnumAppMode.DemoMode_201 Then
                    pbStatusAir1.Image = Image.FromFile(Application.StartupPath & "\" & "images\close.BMP")
                Else
                    pbStatusAir.Image = Image.FromFile(Application.StartupPath & "\" & "images\close.BMP")
                End If

            Else
                air = True

                btnAirOnOff.Text = "AIR OFF"

                'pbStatusAir.Image = Image.FromFile(Application.StartupPath & "\" & "images\open.BMP") ' by dinesh wagh on 20.3.2009

                'added by: dinesh wagh on 20.3.209
                If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Or _
                    gstructSettings.AppMode = EnumAppMode.DemoMode_201 Then
                    pbStatusAir1.Image = Image.FromFile(Application.StartupPath & "\" & "images\open.BMP")
                Else
                    pbStatusAir.Image = Image.FromFile(Application.StartupPath & "\" & "images\open.BMP")
                End If

            End If

            ''If (status And EnumErrorStatus.SN2O_NON) Then    '---25.06.09 commented for version 4.91
            ''    btnN2O.Text = "N2O ON"
            ''    ' code added by: dinesh wagh on 20.3.2009
            ''    If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Or _
            ''        gstructSettings.AppMode = EnumAppMode.DemoMode_201 Then
            ''        pbStatusN2O1.Image = Image.FromFile(Application.StartupPath & "\" & "images\open.BMP")
            ''    Else
            ''        pbStatusN2O.Image = Image.FromFile(Application.StartupPath & "\" & "images\open.BMP")
            ''    End If
            ''Else
            ''    flag = False
            ''    btnN2O.Text = "N2O OFF"
            ''    ' code added by : dinesh wagh on 20.3.2009
            ''    If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Or _
            ''        gstructSettings.AppMode = EnumAppMode.DemoMode_201 Then

            ''        pbStatusN2O1.Image = Image.FromFile(Application.StartupPath & "\" & "images\close.BMP")
            ''    Else
            ''        pbStatusN2O.Image = Image.FromFile(Application.StartupPath & "\" & "images\close.BMP")
            ''    End If
            ''End If

            If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then   '---25.06.09  added for version 4.91
                If (status And EnumErrorStatus.SN2O_NON) Then
                    btnN2O.Text = "N2O ON"
                    ' code added by: dinesh wagh on 20.3.2009
                    If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Or _
                        gstructSettings.AppMode = EnumAppMode.DemoMode_201 Then
                        pbStatusN2O1.Image = Image.FromFile(Application.StartupPath & "\" & "images\open.BMP")
                    Else
                        pbStatusN2O.Image = Image.FromFile(Application.StartupPath & "\" & "images\open.BMP")
                    End If
                Else
                    flag = False
                    btnN2O.Text = "N2O OFF"
                    ' code added by : dinesh wagh on 20.3.2009
                    If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Or _
                        gstructSettings.AppMode = EnumAppMode.DemoMode_201 Then

                        pbStatusN2O1.Image = Image.FromFile(Application.StartupPath & "\" & "images\close.BMP")
                    Else
                        pbStatusN2O.Image = Image.FromFile(Application.StartupPath & "\" & "images\close.BMP")
                    End If
                End If
            Else
                If (status And EnumErrorStatus.SN2O_NON) Then
                    btnN2O.Text = "N2O OFF"
                    ' code added by: dinesh wagh on 20.3.2009
                    If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Or _
                        gstructSettings.AppMode = EnumAppMode.DemoMode_201 Then
                        pbStatusN2O1.Image = Image.FromFile(Application.StartupPath & "\" & "images\open.BMP")
                    Else
                        pbStatusN2O.Image = Image.FromFile(Application.StartupPath & "\" & "images\open.BMP")
                    End If
                Else
                    flag = False
                    btnN2O.Text = "N2O ON"
                    ' code added by : dinesh wagh on 20.3.2009
                    If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Or _
                        gstructSettings.AppMode = EnumAppMode.DemoMode_201 Then

                        pbStatusN2O1.Image = Image.FromFile(Application.StartupPath & "\" & "images\close.BMP")
                    Else
                        pbStatusN2O.Image = Image.FromFile(Application.StartupPath & "\" & "images\close.BMP")
                    End If
                End If
            End If

            btnN2O.Refresh()
            pbStatusN2O.Refresh()
            pbStatusN2O1.Refresh() 'dinesh wagh on 20.3.2009


            If (status And EnumErrorStatus.SFUEL_ON) Then
                btnFuel.Text = "FUEL OFF"

                'pbStatusFuel.Image = Image.FromFile(Application.StartupPath & "\" & "images\open.BMP") by dinesh wagh on 20.3.2009

                ' code added by: dinesh wagh on 20.3.2009
                If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Or _
                    gstructSettings.AppMode = EnumAppMode.DemoMode_201 Then
                    pbStatusFuel1.Image = Image.FromFile(Application.StartupPath & "\" & "images\open.BMP")
                Else
                    pbStatusFuel.Image = Image.FromFile(Application.StartupPath & "\" & "images\open.BMP")
                End If

            Else
                flag = False

                btnFuel.Text = "FUEL ON"

                'pbStatusFuel.Image = Image.FromFile(Application.StartupPath & "\" & "images\close.BMP") 'by dinesh wagh on 20.3.2009

                ' code added by: dinesh wagh on 20.3.2009
                If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Or _
                    gstructSettings.AppMode = EnumAppMode.DemoMode_201 Then
                    pbStatusFuel1.Image = Image.FromFile(Application.StartupPath & "\" & "images\close.BMP")
                Else
                    pbStatusFuel.Image = Image.FromFile(Application.StartupPath & "\" & "images\close.BMP")
                End If

            End If
            btnFuel.Refresh()
            pbStatusFuel.Refresh()

            pbStatusFuel1.Refresh() 'by dinesh wagh on 20.3.2009


            '====commented on 24.04.09
            '''If (st1 And EnumErrorStatus.AA_CONNECTED) Then
            '''    mblnIsN2OBurnerPresent = False   '---added on 30.03.09
            '''    'pbBurnerType.Image = Image.FromFile(Application.StartupPath & "\" & "images\BTAA.bmp") 'by dinesh wagh on 20.3.2009
            '''    ' code added by: dinesh wagh on 20.3.2009
            '''    If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Or _
            '''        gstructSettings.AppMode = EnumAppMode.DemoMode_201 Then
            '''        pbBurnerType1.Image = Image.FromFile(Application.StartupPath & "\" & "images\BTAA.bmp")
            '''    Else
            '''        pbBurnerType.Image = Image.FromFile(Application.StartupPath & "\" & "images\BTAA.bmp")
            '''    End If
            '''Else
            '''    mblnIsN2OBurnerPresent = True  '---added on 30.03.09

            '''    'pbBurnerType.Image = Image.FromFile(Application.StartupPath & "\" & "images\BTNA.bmp") ' by dinesh wagh on 20.3.2009

            '''    ''If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then '---02.02.09 as suggested by Mr. VCK   '---commented on 30.03.09
            '''    ''    If mblnFuelFlowRateMsgDisp = False Then
            '''    ''        gobjMessageAdapter.ShowMessage(constSetFuelFlow)
            '''    ''        mblnFuelFlowRateMsgDisp = True
            '''    ''    End If
            '''    ''End If

            '''    ' code added by: dinesh wagh on 20.3.2009
            '''    If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Or _
            '''        gstructSettings.AppMode = EnumAppMode.DemoMode_201 Then
            '''        pbBurnerType1.Image = Image.FromFile(Application.StartupPath & "\" & "images\BTNA.bmp")
            '''    Else
            '''        pbBurnerType.Image = Image.FromFile(Application.StartupPath & "\" & "images\BTNA.bmp")
            '''    End If
            '''End If
            '====commented on 24.04.09


            '====written on 24.04.09
            If gblnBurnerMsg = False Then
                If (st1 And EnumErrorStatus.AA_CONNECTED) Then
                    'mblnIsN2OBurnerPresent = False   '---added on 30.03.09  'commented on 26.04.09 for ver 4.87
                    ' code added by: dinesh wagh on 20.3.2009
                    If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Or _
                        gstructSettings.AppMode = EnumAppMode.DemoMode_201 Then
                        pbBurnerType1.Image = Image.FromFile(Application.StartupPath & "\" & "images\BTAA.bmp")
                    Else
                        pbBurnerType.Image = Image.FromFile(Application.StartupPath & "\" & "images\BTAA.bmp")
                    End If
                Else
                    'mblnIsN2OBurnerPresent = True  '---added on 30.03.09   'commented on 26.04.09 for ver 4.87

                    ' code added by: dinesh wagh on 20.3.2009
                    If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Or _
                        gstructSettings.AppMode = EnumAppMode.DemoMode_201 Then
                        pbBurnerType1.Image = Image.FromFile(Application.StartupPath & "\" & "images\BTNA.bmp")
                    Else
                        pbBurnerType.Image = Image.FromFile(Application.StartupPath & "\" & "images\BTNA.bmp")
                    End If
                End If
            Else
                If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Or _
                                        gstructSettings.AppMode = EnumAppMode.DemoMode_201 Then
                    pbBurnerType1.Image = Image.FromFile(Application.StartupPath & "\" & "images\ERROR.bmp")
                Else
                    pbBurnerType.Image = Image.FromFile(Application.StartupPath & "\" & "images\ERROR.bmp")
                End If
            End If
            '====written on 24.04.09


            pbBurnerType.Refresh()
            pbBurnerType1.Refresh() 'dinesh wagh on 20.3.2009
            If (st1 And EnumErrorStatus.TRAP_NOK) Then
                flag = False
                pbSafetyControlsTrap.Image = Image.FromFile(Application.StartupPath & "\" & "images\topen.bmp")
            Else
                pbSafetyControlsTrap.Image = Image.FromFile(Application.StartupPath & "\" & "images\OK.BMP")

            End If
            pbSafetyControlsTrap.Refresh()
            If (st1 And EnumErrorStatus.DOOR_NOK) Then
                flag = False
                pbSafetyControlsDoor.Image = Image.FromFile(Application.StartupPath & "\" & "images\DOPEN.bmp")
            Else
                pbSafetyControlsDoor.Image = Image.FromFile(Application.StartupPath & "\" & "images\DCLOSE.bmp")
            End If
            pbSafetyControlsDoor.Refresh()
            If (st And EnumErrorStatus.YELLOW_OK) = EnumErrorStatus.YELLOW_OK Then
                'pbFlameType.Image = Image.FromFile(Application.StartupPath & "\" & "images\YELLOW.BMP") 'by dinesh wagh on 20.3.2009
                '//--- get the flame status for AA201 03.10.08
                intFlameStatus = 1
                '//---
                ' code added by: dinesh wagh on 20.3.2009
                If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Or _
                    gstructSettings.AppMode = EnumAppMode.DemoMode_201 Then
                    pbFlameType1.Image = Image.FromFile(Application.StartupPath & "\" & "images\YELLOW.BMP")
                    '---commented on 26.04.09 (suggested by Mr. Ben) for ver 4.87
                    '---Added on 30.03.09 (suggested by Mr. Vck)
                    ''If gblnMessageDisplayed = False And mblnIsN2OBurnerPresent = True Then
                    ''    gobjMessageAdapter.ShowMessage(constSetFuelFlow)
                    ''    gblnMessageDisplayed = True
                    ''End If
                    '----------
                    '----------
                    mblnFlamePresent = True  '---added on 30.03.09
                Else
                    pbFlameType.Image = Image.FromFile(Application.StartupPath & "\" & "images\YELLOW.BMP")
                End If


            ElseIf (st And EnumErrorStatus.BLUE_OK) = EnumErrorStatus.BLUE_OK Then
                'pbFlameType.Image = Image.FromFile(Application.StartupPath & "\" & "images\BLUE.BMP") 'by dinesh wagh on 20.3.20009

                '//--- get the flame status for AA201 03.10.08
                intFlameStatus = 1
                '//---

                ' code added by: dinesh wagh on 20.3.2009
                If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Or _
                    gstructSettings.AppMode = EnumAppMode.DemoMode_201 Then
                    pbFlameType1.Image = Image.FromFile(Application.StartupPath & "\" & "images\BLUE.BMP")
                    '---Commented on 26.04.09 (suggested by Mr. Ben) for ver 4.87
                    '---Added on 30.03.09 (suggested by Mr. Vck)
                    ''If gblnMessageDisplayed = False And mblnIsN2OBurnerPresent = True Then
                    ''    gobjMessageAdapter.ShowMessage(constSetFuelFlow)
                    ''    gblnMessageDisplayed = True
                    ''End If
                    '----------
                    '----------
                    mblnFlamePresent = True  '---added on 30.03.09
                Else
                    pbFlameType.Image = Image.FromFile(Application.StartupPath & "\" & "images\BLUE.BMP")
                End If

            ElseIf (st And EnumErrorStatus.FLAME_OK) = EnumErrorStatus.FLAME_OK Then
                'pbFlameType.Image = Image.FromFile(Application.StartupPath & "\" & "images\BYELLOW.BMP") 'by dinesh wagh on 20.3.2009



                '//--- get the flame status for AA201 03.10.08
                intFlameStatus = 1
                '//---

                ' code added by: dinesh wagh on 20.3.2009
                If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Or _
                    gstructSettings.AppMode = EnumAppMode.DemoMode_201 Then
                    pbFlameType1.Image = Image.FromFile(Application.StartupPath & "\" & "images\BYELLOW.BMP")
                    '---Commented on 26.04.09 (suggested by Mr. Ben) for ver 4.87
                    '---Added on 30.03.09 (suggested by Mr. Vck)
                    ''If gblnMessageDisplayed = False And mblnIsN2OBurnerPresent = True Then
                    ''    gobjMessageAdapter.ShowMessage(constSetFuelFlow)
                    ''    gblnMessageDisplayed = True
                    ''End If
                    '----------
                    '----------
                    mblnFlamePresent = True  '---added on 30.03.09
                Else
                    pbFlameType.Image = Image.FromFile(Application.StartupPath & "\" & "images\BYELLOW.BMP")
                End If


            ElseIf flag Then
                'pbFlameType.Image = Image.FromFile(Application.StartupPath & "\" & "images\GREEN.BMP")'by dinesh wagh on 20.3.2009

                '//--- get the flame status for AA201 03.10.08
                intFlameStatus = 0
                '//---
                ' code added by: dinesh wagh on 20.3.2009
                If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Or _
                    gstructSettings.AppMode = EnumAppMode.DemoMode_201 Then
                    pbFlameType1.Image = Image.FromFile(Application.StartupPath & "\" & "images\GREEN.BMP")
                    '---added on 30.03.09
                    'gblnMessageDisplayed = False   '---commented on 26.04.09 for ver 4.87
                    '---------
                    mblnFlamePresent = False '30.03.09
                Else
                    pbFlameType.Image = Image.FromFile(Application.StartupPath & "\" & "images\GREEN.BMP")
                End If
            Else

                'pbFlameType.Image = Image.FromFile(Application.StartupPath & "\" & "images\RED.BMP") 'by dinesh wagh on 20.3.2009


                '//--- get the flame status for AA201 03.10.08
                intFlameStatus = 0
                '//---
                ' code added by: dinesh wagh on 20.3.2009
                If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Or _
                    gstructSettings.AppMode = EnumAppMode.DemoMode_201 Then
                    pbFlameType1.Image = Image.FromFile(Application.StartupPath & "\" & "images\RED.BMP")
                    '---added on 30.03.09
                    'gblnMessageDisplayed = False   '---commented on 26.04.09 for ver 4.87
                    '---------
                    mblnFlamePresent = False '---added on 30.03.09
                Else
                    pbFlameType.Image = Image.FromFile(Application.StartupPath & "\" & "images\RED.BMP")
                End If

            End If

            ' code added by : dinesh wagh on 22.3.2009
            'If gstructSettings.AppMode = EnumAppMode.DemoMode_201 Then

            '    lblFRatio1.Text = Format(gobjClsAAS203.funcRead_Fuel(), "0.00")
            'End If


            '22.02.09

            If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
                Dim fl As Integer
                fl = 0

                '---Changed on 30.03.09
                funcCheck_Flame_Test201(fl)
                '------------

                '//--- if Hydride mode is not set then check the flame status
                If gstructSettings.HydrideMode Then
                    ''check for hydride mode
                    If Not HydrideMode Then
                        If intFlameStatus = 1 Then
                            intflag = 1
                        End If
                    End If
                    If intFlameStatus = 1 Then  '---27.05.09
                        intflag = 1
                    End If
                Else
                    If Not (gobjInst.Hydride) Then
                        If intFlameStatus = 1 Then
                            intflag = 1
                        End If
                    End If
                End If

                '//--- if flame is not present and fuel volve is open then set the fuel volve close
                'If gobjInst.N2of = False Then '---commented on 30.03.09
                If (fuel) And (intflag = 1) Then
                    gobjInst.Aaf = True
                Else
                    If (fuel) Then
                        If gobjCommProtocol.func_FUEL_OFF() = True Then
                            fuel = False
                            gobjInst.Aaf = False
                        End If
                    End If
                End If
                'End If
                '//--- if flame is not present and N2O volve is open then set the N2O volve close
                'If n2 And air Then
                'If gobjInst.Aaf = False Then '---commented on 30.03.09
                If (n2) And (intflag = 1) Then
                    gobjInst.N2of = True
                Else
                    If (n2) Then
                        If gobjCommProtocol.func_N2O_OFF() = True Then
                            n2 = False
                            gobjInst.N2of = False
                        End If
                    End If
                End If
                'End If

                '---commented on 30.03.09
                'If fl = True Then
                '    Call gobjMessageAdapter.ShowMessage("Flame is off", "Flame Off", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage)
                'End If
                '--------------

                '---added on 30.03.09
                Select Case fl
                    Case 1
                        '---added on 30.03.09
                        gobjCommProtocol.func_N2O_OFF()
                        gobjCommProtocol.func_FUEL_OFF()
                        '-------------

                        Call gobjMessageAdapter.ShowMessage("Flame is off", "Flame Off", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage)
                    Case 2
                        '---added on 30.03.09
                        gobjCommProtocol.func_N2O_OFF()
                        gobjCommProtocol.func_FUEL_OFF()
                        '-------------

                        If fuel = False Then
                            Call gobjMessageAdapter.ShowMessage(constFlameErrorFuelOff)
                        End If
                    Case 3
                        '---added on 30.03.09
                        gobjCommProtocol.func_N2O_OFF()
                        gobjCommProtocol.func_FUEL_OFF()
                        '-------------

                        Call gobjMessageAdapter.ShowMessage(constFlameErrorAirOff)
                    Case 4
                        '---added on 30.03.09
                        gobjCommProtocol.func_N2O_OFF()
                        gobjCommProtocol.func_FUEL_OFF()
                        '-------------

                        If n2 = False Then
                            Call gobjMessageAdapter.ShowMessage(constFlameErrorN2OOff)
                        End If
                End Select

            End If
            '//---

            gobjCommProtocol.mobjCommdll.subTime_Delay(20)
            If mblnIgnitionWait = False Then
                If gobjCommProtocol.funcGet_NV_Pos() = False Then
                    ''serial communication function for getting NV pos
                    Exit Function
                End If
            Else
                Exit Function
            End If
            If mblnIgnitionWait = False Then

                '''lblFRatio.Text = Format(gobjClsAAS203.funcRead_Fuel(), "0.00") commneted by dinesh wagh on 20.3.2009

                ' code added by : dinesh wagh on 22.3.2009
                If gstructSettings.AppMode = EnumAppMode.DemoMode_201 Or _
                gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
                    lblFRatio1.Text = Format(gobjClsAAS203.funcRead_Fuel(), "0.00")
                Else
                    lblFRatio.Text = Format(gobjClsAAS203.funcRead_Fuel(), "0.00")
                End If
                '-------------
                ''this will give a current value of fuel
            Else
                Exit Function
            End If
            gobjCommProtocol.mobjCommdll.subTime_Delay(20)
            ''delay
            If mblnIgnitionWait = False Then
                If gobjCommProtocol.func_Get_BH_Pos() = False Then
                    ''this is for getting burner position
                    Exit Function
                End If
            Else
                Exit Function
            End If

            'lblBHeight.Text = Format(gobjClsAAS203.funcReadBurnerHeight(), "0.00") dinesh wagh on 20.3.2009

            If Not gstructSettings.AppMode = EnumAppMode.DemoMode_201 Or _
                Not gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
                lblBHeight.Text = Format(gobjClsAAS203.funcReadBurnerHeight(), "0.0")
            End If


            'Commented by Amit
            lblBHeight.Refresh()
            pbFlameType.Refresh()

            pbFlameType1.Refresh() ' dinesh wagh on 20.3.2009

            pbSafetyControlsDoor.Refresh()

            Application.DoEvents()

            lblNVStep.Text = "NV : " & gobjInst.NvStep & ""
            lblNVStep.Refresh()
            Application.DoEvents()
            Return True
            'Catch ThreadEx As Threading.ThreadAbortException

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
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Function

    Private Sub subSetAirOnOff()
        '=====================================================================
        ' Procedure Name        : subSetAirOnOff
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 24-Mar-2007 03:15 pm
        ' Revisions             : 1
        '=====================================================================

        ''note:
        ''set a flag that stand for current state of air
        ''check a cond from air flag 
        ''and perfrom ON / OFF by sending serial communication protocol

        Try
            If ps1 Then
                ''here ps1 stand for air pressure flag
                If air Then
                    ''air is a flag for air ,it stand true if air is on else 
                    If gobjCommProtocol.funcAir_OFF() = True Then
                        air = False
                    End If
                Else
                    If gobjCommProtocol.funcAir_ON() = True Then
                        air = True
                    End If
                End If
            Else
                Call gobjMessageAdapter.ShowMessage(constLowAirPressure)
                ''show the low air message
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


    Private Sub subSetN2OOnOff()
        '=====================================================================
        ' Procedure Name        : subSetN2OOnOff
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 24-Mar-2007 03:15 pm
        ' Revisions             : 1
        '=====================================================================
        ''note:
        ''check for a pressure 
        ''check for a N2 flag 
        ''and as per flag send a serial communication protocol

        Try
            If ps2 Then
                'To check N2O flame status
                If n2 Then
                    'If gobjCommProtocol.func_N2O_OFF() = True Then   '---25.06.09 '---commented for version 4.91
                    '    n2 = False
                    'End If

                    If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then  '---25.06.09  added for version 4.91
                        If gobjCommProtocol.func_N2O_OFF() = True Then
                            n2 = False
                        End If
                    Else
                        n2 = gobjCommProtocol.func_N2O_OFF()
                    End If
                    'End If
                Else
                    '---added on 26.04.09 ver 4.87
                    If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Or _
                    gstructSettings.AppMode = EnumAppMode.DemoMode_201 Then
                        gobjMessageAdapter.ShowMessage(constSetFuelFlow)
                    End If
                    '-----------------

                    ''If gobjCommProtocol.func_N2O_ON() = True Then  '---25.06.09  commented for version 4.91
                    ''    '---Commented on 30.03.09
                    ''    'n2 = gobjCommProtocol.func_N2O_OFF
                    ''    '------------

                    ''    '---Written on 30.03.09
                    ''    n2 = True
                    ''    '------------
                    ''End If

                    If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then  '---25.06.09 added for version 4.91
                        If gobjCommProtocol.func_N2O_ON() = True Then
                            '---Commented on 30.03.09
                            'n2 = gobjCommProtocol.func_N2O_OFF
                            '------------

                            '---Written on 30.03.09
                            n2 = True
                            '------------
                        End If
                    Else
                        n2 = gobjCommProtocol.func_N2O_ON()
                    End If
                End If
                'End If
            Else
            If n2 Then
                '---Commented on 30.03.09
                'n2 = gobjCommProtocol.func_N2O_OFF
                '-------------------

                '---Written on 30.03.09
                If gobjCommProtocol.func_N2O_OFF = True Then
                    n2 = False
                End If
                '-------------------
            End If
            gobjMessageAdapter.ShowMessage(constLowN2OPressure)
            Application.DoEvents()
            End If
            '//--- Added by Sachin Dokhale on 22.05.08
            If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
                'If fuel And air Then
                If fuel Then
                    gobjInst.Aaf = True
                Else
                    gobjInst.Aaf = False
                End If
                'If n2 And air Then
                If n2 Then
                    gobjInst.N2of = True
                Else
                    gobjInst.N2of = False
                End If
            End If
            '//---
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
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


    Private Sub subSetFuelOnOff()
        '=====================================================================
        ' Procedure Name        : subSetFuelOnOff
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 24-Mar-2007 03:15 pm
        ' Revisions             : 1
        '=====================================================================
        ''note:
        ''check for pressure
        ''check fuel flag
        ''and as par cond send a proper protocol
        Try
            If ps3 Then
                If fuel Then
                    If gobjCommProtocol.func_FUEL_OFF() = True Then
                        fuel = False
                    End If
                Else
                    If gobjCommProtocol.func_FUEL_ON() = True Then
                        fuel = True
                    End If
                End If
            Else
                If fuel Then
                    If gobjCommProtocol.func_FUEL_OFF() = True Then
                        fuel = False
                    End If
                End If
                Call gobjMessageAdapter.ShowMessage(constLowFuelPressure)
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


    Private Sub subSetIgniteOnOff()
        '=====================================================================
        ' Procedure Name        : subSetIgniteOnOff
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 24-Mar-2007 03:15 pm
        ' Revisions             : 1
        '=====================================================================
        ''this is used to set a ignition on/off
        Try
            If BIgnite Then
                If gobjCommProtocol.func_IGNITE_OFF() Then
                    ''check for a ignition if true(ignition off)
                    btnIgnite.Text = "IGNITE ON"
                    BIgnite = False
                End If
            ElseIf BIgnite = False Then
                If gobjCommProtocol.func_IGNITE_ON() Then
                    btnIgnite.Text = "IGNITE OFF"
                    BIgnite = True
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

    Private Sub subIncreaseFuel()
        '=====================================================================
        ' Procedure Name        : subIncreaseFuel
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 24-Mar-2007 03:15 pm
        ' Revisions             : 1
        '=====================================================================
        ''this will increase the fuel by 0.1
        ''here gobjClsAAS203.funcRead_Fuel()  will return current fuel
        '=====================================================================
        'void     S4FUNC Incr_Fuel()
        '{
        ' Get_NV_Pos();
        '        If (Inst.Nvstep >= NVSTEP) Then
        '		NV_RotateClock_Steps(NVSTEP);
        ' Get_NV_Pos();
        '}
        '=====================================================================

        Try
            gobjClsAAS203.funcIncr_Fuel()
            lblNVStep1.Text = Format(CDbl(gobjInst.NvStep) / CDbl(NVSTEP), "000.00")
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
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

    Private Sub subDecreaseFuel()
        '=====================================================================
        ' Procedure Name        : subDecreaseFuel
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 24-Mar-2007 03:15 pm
        ' Revisions             : 1
        '=====================================================================
        ''this will decrease the fuel 
        '        ''gobjClsAAS203.funcRead_Fuel() will return the current fuel.
        '=====================================================================
        'void	S4FUNC Decr_Fuel()
        '{
        'int k;
        ' Get_NV_Pos();
        '        If (Inst.Nvstep <= (NVRED * MAXNVHOME - NVSTEP)) Then
        '	  for (k=1; k<=NVSTEP; k++){
        '		if (!Flame_Present(FALSE)) {
        '			NV_RotateClock();
        '			pc_delay(200);
        '			break;
        '		  }
        '		NV_RotateAnticlock();
        '	}
        '#If DEMO Then
        '	 NVpos+=NVSTEP;
        '#End If
        ' Get_NV_Pos();
        '}
        '=====================================================================

        Try
            gobjClsAAS203.funcDecr_Fuel()
            lblNVStep1.Text = Format(CDbl(gobjInst.NvStep) / CDbl(NVSTEP), "000.00")
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
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

    Private Sub subSetMaxFuel()
        '=====================================================================
        ' Procedure Name        : subSetMaxFuel
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 24-Mar-2007 03:15 pm
        ' Revisions             : 1
        '=====================================================================
        Try
            If gobjCommProtocol.funcSetNV_HOME() Then
                ''by setting NV at home position we can set fuel to its mximum 
                gobjInst.NvStep = 0
            Else
                gobjInst.NvStep = -1
            End If
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
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub subIncreaseBurnerHeight()
        '=====================================================================
        ' Procedure Name        : subIncreaseBurnerHeight
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 24-Mar-2007 03:15 pm
        ' Revisions             : 1
        '=====================================================================
        Try
            Call gobjClsAAS203.funcIncr_Height()
            ''function for increasing a burner height 
            ''this will increase the burner height in a step
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
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

    Private Sub subDecreaseBurnerHeight()
        '=====================================================================
        ' Procedure Name        : subDecreaseBurnerHeight
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 24-Mar-2007 03:15 pm
        ' Revisions             : 1
        '=====================================================================
        Try
            Call gobjClsAAS203.funcDecr_Height()
            ''function for drecrease a burner height 
            ''this will drecrease the burner height in a step
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
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

    Private Sub subSetMaxBurnerHeight()
        '=====================================================================
        ' Procedure Name        : subSetMaxBurnerHeight
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 24-Mar-2007 03:15 pm
        ' Revisions             : 1
        '=====================================================================
        Try
            If gobjCommProtocol.funcSetBH_HOME() Then
                ''if we set burner at its home position then burner is in max position
                gobjInst.BhStep = 0
            Else
                gobjInst.BhStep = -1
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

    Private Sub subAutoIgnition()
        '=====================================================================
        ' Procedure Name        : subAutoIgnition
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 24-Mar-2007 03:15 pm
        ' Revisions             : 1
        '=====================================================================
        Try
            Me.custpnlStatusDisplay.Height = 0
            Me.Height = 200
            Me.Enabled = False  '29.12.08
            Application.DoEvents()

            Call gobjClsAAS203.funcIgnite(True)

            Application.DoEvents()
            Me.Enabled = True '29.12.08
            Me.custpnlStatusDisplay.Height = 120
            Me.Height = 320
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

    Private Sub subAutoExtinguish()
        '=====================================================================
        ' Procedure Name        : subAutoExtinguish
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : this is used to put off the ignition
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 24-Mar-2007 03:15 pm
        ' Revisions             : 1
        '=====================================================================
        Try
            Me.custpnlStatusDisplay.Height = 0
            Me.Height = 200
            Me.Enabled = False '29.12.08
            Application.DoEvents()

            Call gobjClsAAS203.funcIgnite(False)

            Me.Enabled = True '29.12.08
            Me.custpnlStatusDisplay.Height = 120
            Me.Height = 320
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

    Private Sub btnAutoIgnite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If mblnInProcess = True Then
                Exit Sub
            End If
            mblnInProcess = True
            cmdBarBtnIgnite.SuspendEvents()

            '---changed by Deepak on 28.12.08
            'mblnIgnitionWait = True
            'mobjclsBgManualIgnition.IgnitionWait = True
            If mobjController.IsThreadRunning = True Then
                mobjController.Cancel()
                gobjCommProtocol.mobjCommdll.subTime_Delay(50)
                Application.DoEvents()
            End If
            '---end changes

            Call subAutoIgnition()

            Application.DoEvents()
            gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay)   '10.12.07
            Application.DoEvents()
            mblnInProcess = False
            cmdBarBtnIgnite.ResumeEvents()

            '---changed by Deepak on 28.12.08
            'mblnIgnitionWait = False
            'mobjclsBgManualIgnition.IgnitionWait = False
            If mobjController.IsThreadRunning = False Then
                mobjController.Start(mobjclsBgManualIgnition)
                Application.DoEvents()
            End If
            '---end changes

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
            mblnIgnitionWait = False
            mblnInProcess = False
            mobjclsBgManualIgnition.IgnitionWait = False
            cmdBarBtnIgnite.ResumeEvents()
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

    Private Sub btnExtinguish_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : btnALT_I_Click
        ' Parameters Passed     : Object, EventArgs
        ' Returns               : 
        ' Purpose               : To make the necessary adjustments and auto 
        '                       : ignite the flame.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 07-02-2007
        ' Revisions             : 
        '=====================================================================
        Try
            If mblnInProcess = True Then
                Exit Sub
            End If
            mblnInProcess = True
            cmdBarBtnExtinguish.SuspendEvents()

            '---30.12.08
            'mblnIgnitionWait = True
            'mobjclsBgManualIgnition.IgnitionWait = True
            'Application.DoEvents()
            'gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay)   '10.12.07
            'Application.DoEvents()

            '---changed by Deepak on 30.12.08
            'mblnIgnitionWait = True
            'mobjclsBgManualIgnition.IgnitionWait = True
            If mobjController.IsThreadRunning = True Then
                mobjController.Cancel()
                gobjCommProtocol.mobjCommdll.subTime_Delay(50)
                Application.DoEvents()
            End If
            '---end changes

            Call subAutoExtinguish()

            Application.DoEvents()
            gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay)   '10.12.07
            Application.DoEvents()
            mblnInProcess = False
            cmdBarBtnExtinguish.ResumeEvents()

            '---30.12.08
            'mblnIgnitionWait = False
            'mobjclsBgManualIgnition.IgnitionWait = False

            '---changed by Deepak on 30.12.08
            'mblnIgnitionWait = False
            'mobjclsBgManualIgnition.IgnitionWait = False
            If mobjController.IsThreadRunning = False Then
                mobjController.Start(mobjclsBgManualIgnition)
                Application.DoEvents()
            End If
            '---end changes


        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
            mblnIgnitionWait = False
            mblnInProcess = False
            mobjclsBgManualIgnition.IgnitionWait = False
            cmdBarBtnExtinguish.ResumeEvents()
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

    Private Sub btnN2OIgnite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Try
            If mblnInProcess = True Then
                Exit Sub
            End If
            mblnInProcess = True
            cmdBarBtnExtinguish.SuspendEvents()
            mblnIgnitionWait = True
            mobjclsBgManualIgnition.IgnitionWait = True
            Application.DoEvents()
            gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay)   '10.12.07
            Application.DoEvents()
            ''delay
            Call gobjCommProtocol.funcSwitchOver()
            ''function To Switch to N20 Flame
            Application.DoEvents()
            gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay)   '10.12.07
            Application.DoEvents()
            mblnIgnitionWait = False
            mblnInProcess = False
            mobjclsBgManualIgnition.IgnitionWait = False
            cmdBarBtnExtinguish.ResumeEvents()
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
            mblnIgnitionWait = False
            mblnInProcess = False
            mobjclsBgManualIgnition.IgnitionWait = False
            cmdBarBtnExtinguish.ResumeEvents()
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
            cmdBarBtnExtinguish.SuspendEvents()
            mblnIgnitionWait = True
            mobjclsBgManualIgnition.IgnitionWait = True
            Application.DoEvents()
            gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay)   '10.12.07
            Application.DoEvents()
            'If Not gstructSettings.AppMode = EnumAppMode.DemoMode Then
            Call Application.DoEvents()
            'If Not gstructSettings.AppMode = EnumAppMode.DemoMode Then
            If Not ((gstructSettings.AppMode = EnumAppMode.DemoMode) Or _
                (gstructSettings.AppMode = EnumAppMode.DemoMode_201) Or _
                (gstructSettings.AppMode = EnumAppMode.DemoMode_203D)) Then
                Call gobjCommProtocol.mobjCommdll.subTime_Delay(50)
                gobjClsAAS203.ReInitInstParameters()
            End If
            'Else
            '    'Call gobjMessageAdapter.ShowMessage(constFlameIgnited)
            '    'Call Application.DoEvents()
            'End If
            Application.DoEvents()
            gobjCommProtocol.mobjCommdll.subTime_Delay(50)   '10.12.07
            Application.DoEvents()
            mblnIgnitionWait = False
            mblnInProcess = False
            mobjclsBgManualIgnition.IgnitionWait = False
            cmdBarBtnExtinguish.ResumeEvents()
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
            mblnIgnitionWait = False
            mblnInProcess = False
            mobjclsBgManualIgnition.IgnitionWait = False
            cmdBarBtnExtinguish.ResumeEvents()
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
            cmdBarBtnExtinguish.SuspendEvents()
            mblnIgnitionWait = True
            mobjclsBgManualIgnition.IgnitionWait = True
            Application.DoEvents()
            gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay)   '10.12.07
            Application.DoEvents()
            'Alt - R
            'If Not gstructSettings.AppMode = EnumAppMode.DemoMode Then
            If Not (gstructSettings.AppMode = EnumAppMode.DemoMode) Or _
                    (gstructSettings.AppMode = EnumAppMode.DemoMode_201) Or _
                    (gstructSettings.AppMode = EnumAppMode.DemoMode_203D) Then
                Call Application.DoEvents()
                Call gobjCommProtocol.mobjCommdll.subTime_Delay(50)
                Call gobjClsAAS203.funcInstReset()
            Else
                Call Application.DoEvents()
            End If
            Application.DoEvents()
            gobjCommProtocol.mobjCommdll.subTime_Delay(50)   '10.12.07
            Application.DoEvents()
            mblnIgnitionWait = False
            mblnInProcess = False
            mobjclsBgManualIgnition.IgnitionWait = False
            cmdBarBtnExtinguish.ResumeEvents()
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
            mblnIgnitionWait = False
            mblnInProcess = False
            mobjclsBgManualIgnition.IgnitionWait = False
            cmdBarBtnExtinguish.ResumeEvents()
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub frmManualIgnition_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated

        ''note
        ''this will start the manual ignition thread
        'If mblnAvoidProcessing Then
        '    Exit Sub
        'End If
        Try
            '    If mblnIsManualIgnitionActivated = False Then
            '        mblnAvoidProcessing = True

            '        'mobjThread = New Threading.Thread(AddressOf subThreadStart)
            '        'mobjThread.IsBackground = False
            '        'mobjThread.Name = "Manual Ignition"
            '        'mobjThread.Start()

            '        'Thread.Sleep(500)
            '        If mobjController Is Nothing Then
            '            mobjController = New clsBgThread(Me)
            '        End If
            '        If mobjclsBgManualIgnition Is Nothing Then
            '            mobjclsBgManualIgnition = New ClsBgManualIgnition
            '        End If
            '        gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay)   '10.12.07
            '        Application.DoEvents()
            '        If mobjController.IsThreadRunning = False Then
            '            mobjController.Start(mobjclsBgManualIgnition)
            '            AddHandler mobjclsBgManualIgnition.ManualIgnition, AddressOf subWaitManualThread
            '        End If
            '        mblnIsManualIgnitionActivated = True
            '        mblnAvoidProcessing = False
            '    End If
            '    Me.Focus()
            '    Me.Refresh()
            '    Application.DoEvents()
            'Me.Refresh()

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
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

    Private Sub LoadInConst()

        Try

            ' code added by :dinesh wagh on 20.3.2009
            ' code start

            If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Or gstructSettings.AppMode = EnumAppMode.DemoMode_201 Then
                pnl203.Visible = False
                pnl201.Visible = True
                pnl201.Dock = DockStyle.Top
            Else
                pnl203.Visible = True
                pnl201.Visible = False
                pnl203.Dock = DockStyle.Top
            End If

            'code ends


            pbPressureAir.Visible = True
            pbPressureN2O.Visible = True
            pbPressureFuel.Visible = True
            pbStatusAir.Visible = True
            pbStatusN2O.Visible = True
            pbStatusFuel.Visible = True
            pbBurnerType.Visible = True
            pbSafetyControlsTrap.Visible = True
            pbSafetyControlsDoor.Visible = True
            pbFlameType.Visible = True



            setVisibleFalse201Controls()

            If Not IsNothing(gobjMain) Then
                'If Not IsNothing(gobjMain.mobjfrmAnalysis) Then gobjMain.mobjfrmAnalysis.tmrAspirationMsg.Enabled = False
                If gobjMain.mobjController.IsThreadRunning = True Then
                    mblnIsfrmFlameStatusWork = True
                    gobjMain.mobjController.Cancel()
                    Application.DoEvents()
                    gobjCommProtocol.mobjCommdll.subTime_Delay(500)   '10.12.07
                    Application.DoEvents()
                End If
                Application.DoEvents()
            End If
            Manual_Init_Check()
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
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

    Private Sub subWaitManualThread(ByRef IsContinue As Boolean)
        '=====================================================================
        ' Procedure Name        : subWaitManualThread
        ' Parameters Passed     : bool for IS Continue status
        ' Returns               : 
        ' Purpose               : this is used for allow thread to wait
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 
        ' Revisions             : 
        '=====================================================================
        Try
            If mblnIgnitionWait = False Then
                Manual_Init_Check()
            End If

            If mblnIgnitionWait = False Then
            End If
            IsContinue = mblnIgnitionWait
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
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

    Private Sub frmManualIgnition_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        '=====================================================================
        ' Procedure Name        : 
        ' Parameters Passed     : 
        ' Returns               : 
        ' Purpose               : 
        '                         
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : Thursday, 10 aug, 2007
        ' Revisions             : 1
        '=====================================================================
        ''note:
        ''this is called when user close the manual ignition form 
        ''first stop the thread
        ''put the ignition off etc...

        Try

            If mblnIgnitionTerminate = False Then
                ''check the status of thread
                If Not (mobjController Is Nothing) Then
                    If mobjController.IsThreadRunning Then
                        mobjclsBgManualIgnition.ThTerminate = True
                        mobjclsBgManualIgnition.IgnitionWait = True
                        mblnIgnitionWait = True
                        gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay)   '10.12.07
                        Application.DoEvents()
                        e.Cancel = True
                        Application.DoEvents()
                        ''allow application to perfrom its panding work
                        Call btnClose_Click(sender, e)
                        Exit Sub
                    End If
                End If
            Else
                If Not (mobjController Is Nothing) Then
                    If mobjController.IsThreadRunning Then
                        mobjclsBgManualIgnition.ThTerminate = True
                        mobjclsBgManualIgnition.IgnitionWait = True
                        ''allowing thread to wait
                        mblnIgnitionWait = True
                        mobjController.Cancel()
                        gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay)   '10.12.07
                        Application.DoEvents()
                    End If
                End If
            End If
            If gobjCommProtocol.func_IGNITE_OFF() Then
                ''function for putting ignition off
            End If
            Dim intIgnite_Test As ClsAAS203.enumIgniteType
            If gobjClsAAS203.funcIgnite_Test(intIgnite_Test) Then
                intFlameType = intIgnite_Test
                gobjfrmStatus.FlameType = intFlameType
            End If

            If mblnIsfrmFlameStatusWork = True Then
                If Not IsNothing(gobjMain) Then
                    'If Not IsNothing(gobjMain.mobjfrmAnalysis) Then gobjMain.mobjfrmAnalysis.tmrAspirationMsg.Enabled = False
                    If gobjMain.mobjController.IsThreadRunning = False Then
                        gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay)   '10.12.07
                        Application.DoEvents()
                        gobjMain.mobjController.Start(gobjclsBgFlameStatus)
                    End If
                    mblnIsfrmFlameStatusWork = False
                    Application.DoEvents()
                End If
            End If
            e.Cancel = False
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
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

    Public Function funcCheck_Flame_Test201(ByRef flg As Integer) As Boolean
        '---Changed on 30.03.09
        Try
            'BYTE 		st;

            'BOOL 	ps1, ps2, ps3, flag=0;

            'if (Inst.Aaf || Inst.N2of) {
            '	ps1 = ps2 = ps3 = ON;
            '	st  = CHECK_PS();
            '	if (st & AIR_NOK) ps1 = OFF;
            '	if (st & N2O_NOK) ps2 = OFF;
            '	if (st & FUEL_NOK) ps3 = OFF;
            '#If HYRD_MODE Then
            '	if (!HydrideMode){
            '#Else
            '	if (!Inst.Hydride){
            '#End If
            '	  if ((st&FLAME_OK) !=FLAME_OK ) flag=1;
            '	  }
            '	if (!ps3) flag=2;
            '	if (Inst.Aaf) if (!ps1) flag = 3;
            '	if (Inst.N2of) if (!ps2) flag = 4;
            '#If DEMO Then
            '		flag=FALSE;
            '#End If

            '	if (flag){
            '	  Flame_Off();
            '	  switch(flag) {
            '		 case 1 : Inst.Nvstep-= (5*NVSTEP);Save_NV_Pos();
            '					 Gerror_message(" **FLAME ERROR *** \n Flame OFF "); break;
            '		 case 2 : Gerror_message(" **FLAME ERROR *** \n Fuel not enough "); break;
            '		 case 3 : Gerror_message(" **FLAME ERROR *** \n Air  not enough "); break;
            '		 case 4 : Gerror_message(" **FLAME ERROR *** \n N2o  not enough "); break;
            '	  }
            '	}
            ' }
            '}

            Dim bdata As Byte
            Dim ps1, ps2, ps3 As Boolean
            Dim intflag As Integer = 0

            'if (Inst.Aaf || Inst.N2of) {
            '	ps1 = ps2 = ps3 = ON;
            If ((gobjInst.Aaf) Or (gobjInst.N2of)) Then
                'if true
                ps1 = True  ' To check for Air pressure 
                ps2 = True  ' To check for N2O pressure 
                ps3 = True  ' To check for Fuel pressure 

                If gobjCommProtocol.funcPressSensorStatus(bdata) Then
                    ''get a presssensor status
                    If (bdata And EnumErrorStatus.AIR_NOK) Then
                        ''check for air nok
                        ps1 = False
                    End If
                    If (bdata And EnumErrorStatus.N2O_NOK) Then
                        ''check for n2o nok
                        ps2 = False
                    End If
                    If (bdata And EnumErrorStatus.FUEL_NOK) Then
                        ''check for fuel nok
                        ps3 = False
                    End If
                    'End If

                    '#If HYRD_MODE Then
                    '	if (!HydrideMode){
                    '#Else
                    '	if (!Inst.Hydride){
                    '#End If
                    '	  if ((st&FLAME_OK) !=FLAME_OK ) flag=1;
                    '	  }

                    If gstructSettings.HydrideMode Then

                        ''check for hydride mode
                        If Not HydrideMode Then
                            If (Not (bdata And EnumErrorStatus.FLAME_OK) = EnumErrorStatus.FLAME_OK) Then
                                intflag = 1
                            End If
                        End If
                    Else
                        If Not (gobjInst.Hydride) Then
                            If (Not (bdata And EnumErrorStatus.FLAME_OK) = EnumErrorStatus.FLAME_OK) Then
                                intflag = 1
                            End If
                        End If
                    End If

                    '	if (!ps3) flag=2;
                    '	if (Inst.Aaf) if (!ps1) flag = 3;
                    '	if (Inst.N2of) if (!ps2) flag = 4;

                    If Not (ps3) Then
                        intflag = 2
                    End If

                    If (gobjInst.Aaf) Then
                        If Not (ps1) Then
                            intflag = 3
                        End If
                    End If

                    'If Not (gobjInst.Aaf) Then
                    If (gobjInst.N2of) Then
                        If Not (ps2) Then
                            intflag = 4
                        End If
                    End If
                    'End If


                    '#If DEMO Then
                    '		flag=FALSE;
                    '#endif
                    'If gstructSettings.AppMode = EnumAppMode.DemoMode Then
                    If (gstructSettings.AppMode = EnumAppMode.DemoMode) Or _
                        (gstructSettings.AppMode = EnumAppMode.DemoMode_201) Or _
                        (gstructSettings.AppMode = EnumAppMode.DemoMode_203D) Then
                        intflag = False
                    End If

                    If (intflag) Then
                        Call gobjCommProtocol.funcFlame_OFF()
                        ''for flame off
                        '//--- check the flame status for AA201 03.10.08
                        If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
                            '//--- Set the Fuel volve off  when flame is not present
                            If gobjCommProtocol.func_FUEL_OFF() = True Then
                            End If
                            '//--- Set the N2O volve off when flame is not present
                            If (gobjInst.N2of) Then
                                If gobjCommProtocol.func_N2O_OFF() = True Then
                                End If
                            End If
                        End If
                        '//---
                        Select Case intflag
                            ''select case as per flag
                        Case 1
                                flg = 1
                                '//--- check the flame status for AA201 03.10.08
                                'If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
                                '    Call gobjMessageAdapter.ShowMessage("Flame is off", "Flame Off", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage)
                                'Else
                                '    gobjInst.NvStep -= (5 * NVSTEP)
                                '    '**************************************************************************
                                '    '---Added function by Mangesh on 23-Apr-2007
                                '    '**************************************************************************
                                '    Call gobjCommProtocol.funcSave_NV_Pos()
                                '    ''for saving a NV position
                                '    '**************************************************************************
                                '    Call gobjMessageAdapter.ShowMessage(constFlameErrorFlameOff)
                                '    'break;
                                'End If
                                '//---
                            Case 2
                                ' Gerror_message(" **FLAME ERROR *** \n Fuel not enough "); break;
                                'Call gobjMessageAdapter.ShowMessage(constFlameErrorFuelOff)
                                flg = 2

                            Case 3
                                ' Gerror_message(" **FLAME ERROR *** \n Air  not enough "); break;
                                'Call gobjMessageAdapter.ShowMessage(constFlameErrorAirOff)
                                flg = 3
                            Case 4
                                ' Gerror_message(" **FLAME ERROR *** \n N2o  not enough "); break;
                                'Call gobjMessageAdapter.ShowMessage(constFlameErrorN2OOff)
                                flg = 4
                            Case Else
                                flg = 0
                        End Select
                    End If
                End If
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

#End Region

#Region " IClient Events for receiving the wavelength and Abs value from Receiving thread "

    Private Sub TaskStarted(ByVal BgThread As clsBgThread) _
        Implements BgThread.Iclient.Start
        Try
            'mblnAvoidProcessing = True
            mblnIgnitionWait = False
            mblnIgnitionTerminate = False
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
        Try
            'If gstructApplicationSessionState.intInstrument_Group = EnumInstrumentGroup.Initialize_2600_2700 Then
            'Call funcIclientTaskDisplayData(Text)
            'If Not (mobjclsBgSpectrum Is Nothing) Then
            '    mobjclsBgSpectrum.EndProcess = True
            'End If
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
        Try
            '--- Dispose all the objects
            'mobjTemporaryChannel = New Channel
            'mobjTemporaryReadings = New Readings
            'mobjTemporaryReadings_2100 = New Readings
            'funcIclientTaskFalied()

            'mblnSpectrumStarted = False
            'mblnAvoidProcessing = False
            'Call mnuExit_Click(btnReturn, EventArgs.Empty)
            'gFuncShowMessage("Error...", "Spectrum scanning failed.", modConstants.EnumMessageType.Information)
            mblnIgnitionTerminate = True
            mblnIgnitionWait = True
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
            Application.DoEvents()
        End Try

    End Sub

    Private Sub TaskCompleted(ByVal Cancelled As Boolean) _
             Implements Iclient.Completed

        Try
            'If gstructApplicationSessionState.intInstrument_Group = EnumInstrumentGroup.Initialize_2600_2700 Then
            '    'Call funcIclientTaskCompleted2600()
            'ElseIf gstructApplicationSessionState.intInstrument_Group = EnumInstrumentGroup.Initialize_2100_2200_2300 Then
            '    'Call funcIclientTaskCompleted2100()
            'End If
            'Call funcIclientTaskCompleted()

            'mblnSpectrumStarted = False
            'mblnAvoidProcessing = False
            'Call mnuExit_Click(btnReturn, EventArgs.Empty)
            mblnIgnitionTerminate = True
            mblnIgnitionWait = True
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
            Application.DoEvents()
        End Try

    End Sub

#End Region

#Region " Commented Code "

    '    void	Manual_Init_Check(HDC hdc)
    '{
    'BYTE data;
    '  if (!Commflag)
    '	 return;
    '	Status_Disp();
    '	aa = ps1 = ps2 = ps3 = ON;
    '	data  = CHECK_PS();
    '	if (data & AIR_NOK) ps1 = OFF;
    '	if (data & N2O_NOK) ps2 = OFF;
    '	if (data & FUEL_NOK) ps3 = OFF;
    '	data = CHECK_BUR_PAR();
    '	if (data & AA_CONNECTED) aa = ON;
    '	if (!ps1)  {
    '	  Wprintf(hdc, 20, 0, " No AIR Pressure  ");
    '	  if (! ( air))  air = AIR_ON();
    '	 }
    '	if (!ps2) {
    '	  Wprintf(hdc, 20, 15, " No N‘O Pressure  ");
    '	  if( n2)  n2 = N2O_OFF();
    '	 }
    '	if (!ps3) {
    '	  Wprintf(hdc, 20, 30," No FUEL Pressure  ");
    '	  if ( fuel)  fuel = FUEL_OFF();
    '	 }
    '	if (aa) Wprintf(hdc, 20, 45 ," AA  Burner  attached ");
    '	else Wprintf(hdc, 20, 45 ," N2o Burner attached ");
    '}
    '====================================================================

    '    void	Status_Disp()
    '{
    'char  line1[80];
    'BYTE  status,st, st1;
    'BOOL	flag=TRUE;

    'if (!Commflag)
    '	 return;
    'if (StHwnd!=NULL){
    '  status = GET_PNEUM_STATUS();
    '//  st=random(255); st1=random(255);
    '  st = CHECK_PS();
    '  st1 = CHECK_BUR_PAR();
    '  if (st & AIR_NOK)	 		{  flag=FALSE; SetVal(IDC_PAIR, "ERROR");}
    '  else 	SetVal(IDC_PAIR, "OK");
    '  if (st & N2O_NOK)	 		{  flag=FALSE; SetVal(IDC_PN2O, "ERROR");}
    '  else 	SetVal(IDC_PN2O, "OK");
    '  if (st & FUEL_NOK)	 		{  flag=FALSE; SetVal(IDC_PFUEL, "ERROR");}
    '  else 	SetVal(IDC_PFUEL, "OK");
    '  if (status & SAIR_NON) 	{
    '		flag=FALSE; SetVal(IDC_PVAIR,"CLOSE");}
    '  else	SetVal(IDC_PVAIR,"OPEN");
    '  if (status & SN2O_ON)	 	SetVal(IDC_PVN2O, "OPEN");
    '  else	{  flag=FALSE; SetVal(IDC_PVN2O, "CLOSE");}
    '  if (status & SFUEL_ON)	SetVal(IDC_PVFUEL, "OPEN");
    '  else	{  flag=FALSE; SetVal(IDC_PVFUEL, "CLOSE");}
    '  if (st1 & AA_CONNECTED) 	SetVal(IDC_BTYPE, "BTAA");
    '  else 	SetVal(IDC_BTYPE, "BTNA");
    '  if (st1 & TRAP_NOK) {  flag=FALSE; SetVal(IDC_TRAP, "TOPEN");}
    '  else SetVal(IDC_TRAP, "OK");
    '  if (st1 &DOOR_NOK) {  flag=FALSE; SetVal(IDC_DTYPE, "DOPEN");}
    '  else SetVal(IDC_DTYPE, "DCLOSE");
    '  if ((st&YELLOW_OK) ==YELLOW_OK) 		SetVal(IDC_FLAME, "YELLOW");
    '  else if ((st&BLUE_OK)==BLUE_OK)  	SetVal(IDC_FLAME, "BLUE");
    '  else if ((st & FLAME_OK)==FLAME_OK) 	SetVal(IDC_FLAME, "BYELLOW");
    '  else if (flag)	SetVal(IDC_FLAME, "GREEN");
    '  else SetVal(IDC_FLAME, "RED");
    '  Get_NV_Pos();
    '  sprintf(line1,"%3.2f", Read_Fuel());	// Nv pos
    '  SetWindowText(GetDlgItem(StHwnd, IDC_FR),line1);
    '  Get_BH_Pos();
    '  sprintf(line1,"%2.1f", ReadBurnerHeight());
    '  SetWindowText(GetDlgItem(StHwnd, IDC_BH),line1);
    '  UpdateWindow (StHwnd) ;
    ' }
    '}
    '=++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    '    BYTE	GET_PNEUM_STATUS()
    '{
    '  Transmit(PNEMSTATUS, 0, 0 , 0);
    ' Recev(TRUE);
    '//  c = PNEMSTATUS; trans(c); recev();
    'return Param1;
    '}
#Region ""
    '=====on air on/off
    'if (ps1)	{
    '									  if (air){ air = AIR_OFF();if(GetInstrument() == AA202) SetWindowText(GetDlgItem(hwnd,IDC_BAIR),"N2O OFF");}
    '									  else{ air = AIR_ON();if(GetInstrument() == AA202) SetWindowText(GetDlgItem(hwnd,IDC_BAIR),"N2O ON");}
    '									 }
    '								  else{  if(GetInstrument() == AA202)
    '												Gerror_message_new("No AIR Pressure ..","AA-202 PNEUM");
    '											else
    '												Gerror_message_new("No AIR Pressure ..","AA-203 PNEUM");
    '												}break;
    '=====on n20 button on/off
    'if (ps2)  {
    '					  if(n2){ n2 = N2O_OFF();}
    '					  else{ n2 = N2O_ON();}
    '					 }
    '					else {
    '					  if(n2) n2 = N2O_OFF();
    '					  if(GetInstrument() == AA202)
    '						Gerror_message_new("No N2O Pressure ..", "AA-202 PNEUM");
    '					  else
    '						Gerror_message_new("No N2O Pressure ..", "AA-203 PNEUM");
    '					} break;
    '=========on fuel on/off button
    'if (ps3){
    '					  if (fuel){ if(GetInstrument() == AA202){  air = AIR_ON(); SetWindowText(GetDlgItem(hwnd,IDC_BAIR),"N2O ON");SetWindowText(GetDlgItem(hwnd,IDC_BFUEL),"FUEL ON");pc_delay(6000);pc_delay(6000);}fuel = FUEL_OFF();}
    '					  else{ if( GetInstrument() == AA202 ){SetWindowText(GetDlgItem(hwnd,IDC_BFUEL),"FUEL OFF");}fuel = FUEL_ON();}
    '					 }
    '					else  {
    '					  if (fuel) fuel = FUEL_OFF();
    '						 if(GetInstrument() == AA202)
    '							 Gerror_message_new("No FUEL Pressure ..", "AA-202 PNEUM");
    '						 else
    '							 Gerror_message_new("No FUEL Pressure ..", "AA-203 PNEUM");
    '					 } break;
    '=======on ignite on/off button
    'if (fuel && air) Inst.Aaf = ON;
    '				  if (fuel && n2) Inst.N2of = ON;
    '				  if (Bignite) Bignite=IGNITE_OFF();
    '				  else   if (!Inst.Aaf && !Inst.N2of)  Bignite = IGNITE_ON();
    '				  pc_delay(250);break;
    '=====on increment fuel button 
    'Incr_Fuel();
    '				  Wprintf(hdc, 10, 70, "%3.2f      ", (double)Inst.Nvstep/(double)NVSTEP);break;
    '======on decrement fuel button
    'Decr_Fuel();
    '				  Wprintf(hdc, 10, 70, "%3.2f      ", (double)Inst.Nvstep/(double)NVSTEP); break;
    '
    '====on form closing
    '   if (Bignite) Bignite=IGNITE_OFF();
    'if (fuel && air) Inst.Aaf = ON;
    'if (fuel && n2) Inst.N2of = ON;





#End Region

    'Private Function Read_Fuel() As Double
    '    '=====================================================================
    '    ' Procedure Name        : Read_Fuel
    '    ' Parameters Passed     : Object,EventArgs
    '    ' Returns               : Fuel
    '    ' Purpose               : To get the fuel.
    '    ' Description           : 
    '    ' Assumptions           : 
    '    ' Dependencies          : 
    '    ' Author                : Saurabh S
    '    ' Created               : 02.02.07
    '    ' Revisions             : 
    '    '=====================================================================
    '    Dim fuel As Double = 0.0
    '    Try
    '        gobjCommProtocol.funcGet_NV_Pos()
    '        fuel = ConvertToFuel(gobjInst.NvStep)
    '        Return fuel

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
    '        'objWait.Dispose()
    '        '---------------------------------------------------------
    '    End Try

    'End Function

    'Private Function ConvertToFuel(ByVal intNVSteps As Integer)
    '    '=====================================================================
    '    ' Procedure Name        : ConvertToFuel
    '    ' Parameters Passed     : Object,EventArgs
    '    ' Returns               : Fuel value
    '    ' Purpose               : To convert the steps into fuel.
    '    ' Description           : 
    '    ' Assumptions           : 
    '    ' Dependencies          : 
    '    ' Author                : Saurabh S
    '    ' Created               : 02.02.07
    '    ' Revisions             : 
    '    '=====================================================================
    '    Dim fuel As Double = 0.0
    '    Try
    '        If intNVSteps < 0 Then
    '            Return 0.0
    '        End If
    '        fuel = MAXNVHOME * 1.0 - (intNVSteps / NVRED)
    '        If Burner_Type() Then
    '            fuel = (fuel + 0.1561) / 0.6733
    '        Else
    '            fuel = (fuel + 0.1732) / 0.7232
    '        End If
    '        Return fuel

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
    '        'objWait.Dispose()
    '        '---------------------------------------------------------
    '    End Try

    'End Function

    'Private Function Burner_Type() As Boolean
    '    '=====================================================================
    '    ' Procedure Name        : Burner_Type
    '    ' Parameters Passed     : Object,EventArgs
    '    ' Returns               : True or False
    '    ' Purpose               : To get the type of Burner AA or NA.
    '    ' Description           : 
    '    ' Assumptions           : 
    '    ' Dependencies          : 
    '    ' Author                : Saurabh S
    '    ' Created               : 02.02.07
    '    ' Revisions             : 
    '    '=====================================================================
    '    Dim st1 As Byte
    '    Try
    '        gobjCommProtocol.funcCheckBurnerParameters(st1)
    '        If (st1 And EnumErrorStatus.AA_CONNECTED) Then
    '            Return True
    '        Else
    '            Return False
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
    '        'objWait.Dispose()
    '        '---------------------------------------------------------
    '    End Try

    'End Function

    'Private Function ReadBurnerHeight() As Double
    '    '=====================================================================
    '    ' Procedure Name        : ReadBurnerHeight
    '    ' Parameters Passed     : Object,EventArgs
    '    ' Returns               : Burner Height
    '    ' Purpose               : To get the Burner Height.
    '    ' Description           : 
    '    ' Assumptions           : 
    '    ' Dependencies          : 
    '    ' Author                : Saurabh S
    '    ' Created               : 02.02.07
    '    ' Revisions             : 
    '    '=====================================================================
    '    Dim dblBH As Double = 0.0
    '    Try
    '        dblBH = ConvertToBurnerHeight(gobjInst.BhStep)
    '        Return dblBH

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
    '        'objWait.Dispose()
    '        '---------------------------------------------------------
    '    End Try

    'End Function

    'Private Function ConvertToBurnerHeight(ByVal steps As Integer)
    '    '=====================================================================
    '    ' Procedure Name        : ConvertToBurnerHeight
    '    ' Parameters Passed     : Object,EventArgs
    '    ' Returns               : Height
    '    ' Purpose               : To convert the steps in height.
    '    ' Description           : 
    '    ' Assumptions           : 
    '    ' Dependencies          : 
    '    ' Author                : Saurabh S
    '    ' Created               : 02.02.07
    '    ' Revisions             : 
    '    '=====================================================================
    '    Dim dblBH As Double = 0.0
    '    Try
    '        dblBH = steps / (200.0 * BHRATIO)
    '        Return dblBH

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
    '        'objWait.Dispose()
    '        '---------------------------------------------------------
    '    End Try
    'End Function

#End Region


End Class
