Imports AAS203.Common
Imports System.Threading
Imports BgThread

Public Class frmAutoIgnition
    Inherits System.Windows.Forms.Form
    Implements Iclient
#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Call funcInitialise()
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
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnSetMaxBurnerHeight As NETXP.Controls.XPButton
    Friend WithEvents btnSetMaxFuel As NETXP.Controls.XPButton
    Friend WithEvents btnIncreaseBurnerHeight As NETXP.Controls.XPButton
    Friend WithEvents btnDecreaseBurnerHeight As NETXP.Controls.XPButton
    Friend WithEvents btnDecreaseFuel As NETXP.Controls.XPButton
    Friend WithEvents btnIncreaseFuel As NETXP.Controls.XPButton
    Friend WithEvents btnAAFLAME As NETXP.Controls.XPButton
    Friend WithEvents btnNAFLAME As NETXP.Controls.XPButton
    Friend WithEvents lblBHeight As System.Windows.Forms.Label
    Friend WithEvents lblFRatio As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblBurnerHeight As System.Windows.Forms.Label
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
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents btnClose As NETXP.Controls.XPButton
    Friend WithEvents lblNVStep1 As System.Windows.Forms.Label
    Friend WithEvents pbPressureAir As System.Windows.Forms.PictureBox
    Friend WithEvents pbSafetyControlsDoor As System.Windows.Forms.PictureBox
    Friend WithEvents pbBurnerType As System.Windows.Forms.PictureBox
    Friend WithEvents pbStatusFuel As System.Windows.Forms.PictureBox
    Friend WithEvents pbStatusN2O As System.Windows.Forms.PictureBox
    Friend WithEvents pbPressureFuel As System.Windows.Forms.PictureBox
    Friend WithEvents pbFlameType As System.Windows.Forms.PictureBox
    Friend WithEvents pbSafetyControlsTrap As System.Windows.Forms.PictureBox
    Friend WithEvents pbStatusAir As System.Windows.Forms.PictureBox
    Friend WithEvents pbPressureN2O As System.Windows.Forms.PictureBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmAutoIgnition))
        Me.CustomPanel1 = New GradientPanel.CustomPanel
        Me.lblNVStep1 = New System.Windows.Forms.Label
        Me.btnClose = New NETXP.Controls.XPButton
        Me.lblStatus = New System.Windows.Forms.Label
        Me.lblBHeight = New System.Windows.Forms.Label
        Me.lblFRatio = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.lblBurnerHeight = New System.Windows.Forms.Label
        Me.pbFlameType = New System.Windows.Forms.PictureBox
        Me.pbSafetyControlsTrap = New System.Windows.Forms.PictureBox
        Me.pbSafetyControlsDoor = New System.Windows.Forms.PictureBox
        Me.pbBurnerType = New System.Windows.Forms.PictureBox
        Me.pbStatusFuel = New System.Windows.Forms.PictureBox
        Me.pbStatusN2O = New System.Windows.Forms.PictureBox
        Me.pbPressureFuel = New System.Windows.Forms.PictureBox
        Me.pbPressureN2O = New System.Windows.Forms.PictureBox
        Me.pbPressureAir = New System.Windows.Forms.PictureBox
        Me.pbStatusAir = New System.Windows.Forms.PictureBox
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
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.btnNAFLAME = New NETXP.Controls.XPButton
        Me.btnAAFLAME = New NETXP.Controls.XPButton
        Me.btnSetMaxBurnerHeight = New NETXP.Controls.XPButton
        Me.btnSetMaxFuel = New NETXP.Controls.XPButton
        Me.btnIncreaseBurnerHeight = New NETXP.Controls.XPButton
        Me.btnDecreaseBurnerHeight = New NETXP.Controls.XPButton
        Me.btnDecreaseFuel = New NETXP.Controls.XPButton
        Me.btnIncreaseFuel = New NETXP.Controls.XPButton
        Me.Label2 = New System.Windows.Forms.Label
        Me.CustomPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'CustomPanel1
        '
        Me.CustomPanel1.BackColor = System.Drawing.Color.AliceBlue
        Me.CustomPanel1.Controls.Add(Me.lblNVStep1)
        Me.CustomPanel1.Controls.Add(Me.btnClose)
        Me.CustomPanel1.Controls.Add(Me.lblStatus)
        Me.CustomPanel1.Controls.Add(Me.lblBHeight)
        Me.CustomPanel1.Controls.Add(Me.lblFRatio)
        Me.CustomPanel1.Controls.Add(Me.Label3)
        Me.CustomPanel1.Controls.Add(Me.lblBurnerHeight)
        Me.CustomPanel1.Controls.Add(Me.pbFlameType)
        Me.CustomPanel1.Controls.Add(Me.pbSafetyControlsTrap)
        Me.CustomPanel1.Controls.Add(Me.pbSafetyControlsDoor)
        Me.CustomPanel1.Controls.Add(Me.pbBurnerType)
        Me.CustomPanel1.Controls.Add(Me.pbStatusFuel)
        Me.CustomPanel1.Controls.Add(Me.pbStatusN2O)
        Me.CustomPanel1.Controls.Add(Me.pbPressureFuel)
        Me.CustomPanel1.Controls.Add(Me.pbPressureN2O)
        Me.CustomPanel1.Controls.Add(Me.pbPressureAir)
        Me.CustomPanel1.Controls.Add(Me.pbStatusAir)
        Me.CustomPanel1.Controls.Add(Me.lblFlameRatio)
        Me.CustomPanel1.Controls.Add(Me.lblFlameType)
        Me.CustomPanel1.Controls.Add(Me.lblSafetyControlsTrap)
        Me.CustomPanel1.Controls.Add(Me.lblSafetyControlsDoor)
        Me.CustomPanel1.Controls.Add(Me.lblBurnerType)
        Me.CustomPanel1.Controls.Add(Me.lblStatusFuel)
        Me.CustomPanel1.Controls.Add(Me.lblStatusN2O)
        Me.CustomPanel1.Controls.Add(Me.lblStatusAir)
        Me.CustomPanel1.Controls.Add(Me.lblPressureFuel)
        Me.CustomPanel1.Controls.Add(Me.lblPressureN2O)
        Me.CustomPanel1.Controls.Add(Me.lblPressureAir)
        Me.CustomPanel1.Controls.Add(Me.lblFlame)
        Me.CustomPanel1.Controls.Add(Me.lblSafetyControls)
        Me.CustomPanel1.Controls.Add(Me.lblBurner)
        Me.CustomPanel1.Controls.Add(Me.lblPressureValveStatus)
        Me.CustomPanel1.Controls.Add(Me.lblPressures)
        Me.CustomPanel1.Controls.Add(Me.Label7)
        Me.CustomPanel1.Controls.Add(Me.Label6)
        Me.CustomPanel1.Controls.Add(Me.Label5)
        Me.CustomPanel1.Controls.Add(Me.Label4)
        Me.CustomPanel1.Controls.Add(Me.Label8)
        Me.CustomPanel1.Controls.Add(Me.btnNAFLAME)
        Me.CustomPanel1.Controls.Add(Me.btnAAFLAME)
        Me.CustomPanel1.Controls.Add(Me.btnSetMaxBurnerHeight)
        Me.CustomPanel1.Controls.Add(Me.btnSetMaxFuel)
        Me.CustomPanel1.Controls.Add(Me.btnIncreaseBurnerHeight)
        Me.CustomPanel1.Controls.Add(Me.btnDecreaseBurnerHeight)
        Me.CustomPanel1.Controls.Add(Me.btnDecreaseFuel)
        Me.CustomPanel1.Controls.Add(Me.btnIncreaseFuel)
        Me.CustomPanel1.Controls.Add(Me.Label2)
        Me.CustomPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CustomPanel1.Location = New System.Drawing.Point(0, 0)
        Me.CustomPanel1.Name = "CustomPanel1"
        Me.CustomPanel1.Size = New System.Drawing.Size(634, 287)
        Me.CustomPanel1.TabIndex = 0
        '
        'lblNVStep1
        '
        Me.lblNVStep1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblNVStep1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNVStep1.Location = New System.Drawing.Point(72, 112)
        Me.lblNVStep1.Name = "lblNVStep1"
        Me.lblNVStep1.Size = New System.Drawing.Size(72, 20)
        Me.lblNVStep1.TabIndex = 103
        Me.lblNVStep1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnClose
        '
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.Location = New System.Drawing.Point(376, 240)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(110, 38)
        Me.btnClose.TabIndex = 6
        Me.btnClose.Text = "C&LOSE"
        '
        'lblStatus
        '
        Me.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStatus.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.ForeColor = System.Drawing.Color.Red
        Me.lblStatus.Location = New System.Drawing.Point(240, 111)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(390, 32)
        Me.lblStatus.TabIndex = 101
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblBHeight
        '
        Me.lblBHeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBHeight.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBHeight.Location = New System.Drawing.Point(347, 70)
        Me.lblBHeight.Name = "lblBHeight"
        Me.lblBHeight.Size = New System.Drawing.Size(66, 32)
        Me.lblBHeight.TabIndex = 100
        Me.lblBHeight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblFRatio
        '
        Me.lblFRatio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFRatio.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFRatio.Location = New System.Drawing.Point(576, 70)
        Me.lblFRatio.Name = "lblFRatio"
        Me.lblFRatio.Size = New System.Drawing.Size(56, 32)
        Me.lblFRatio.TabIndex = 99
        Me.lblFRatio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Location = New System.Drawing.Point(0, 104)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(700, 2)
        Me.Label3.TabIndex = 98
        '
        'lblBurnerHeight
        '
        Me.lblBurnerHeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBurnerHeight.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBurnerHeight.Location = New System.Drawing.Point(347, 44)
        Me.lblBurnerHeight.Name = "lblBurnerHeight"
        Me.lblBurnerHeight.Size = New System.Drawing.Size(66, 24)
        Me.lblBurnerHeight.TabIndex = 97
        Me.lblBurnerHeight.Text = "HEIGHT"
        Me.lblBurnerHeight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pbFlameType
        '
        Me.pbFlameType.BackColor = System.Drawing.Color.Transparent
        Me.pbFlameType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbFlameType.Location = New System.Drawing.Point(535, 70)
        Me.pbFlameType.Name = "pbFlameType"
        Me.pbFlameType.Size = New System.Drawing.Size(32, 32)
        Me.pbFlameType.TabIndex = 96
        Me.pbFlameType.TabStop = False
        '
        'pbSafetyControlsTrap
        '
        Me.pbSafetyControlsTrap.BackColor = System.Drawing.Color.Transparent
        Me.pbSafetyControlsTrap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbSafetyControlsTrap.Location = New System.Drawing.Point(481, 70)
        Me.pbSafetyControlsTrap.Name = "pbSafetyControlsTrap"
        Me.pbSafetyControlsTrap.Size = New System.Drawing.Size(32, 32)
        Me.pbSafetyControlsTrap.TabIndex = 95
        Me.pbSafetyControlsTrap.TabStop = False
        '
        'pbSafetyControlsDoor
        '
        Me.pbSafetyControlsDoor.BackColor = System.Drawing.Color.Transparent
        Me.pbSafetyControlsDoor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbSafetyControlsDoor.Location = New System.Drawing.Point(429, 70)
        Me.pbSafetyControlsDoor.Name = "pbSafetyControlsDoor"
        Me.pbSafetyControlsDoor.Size = New System.Drawing.Size(32, 32)
        Me.pbSafetyControlsDoor.TabIndex = 94
        Me.pbSafetyControlsDoor.TabStop = False
        '
        'pbBurnerType
        '
        Me.pbBurnerType.BackColor = System.Drawing.Color.Transparent
        Me.pbBurnerType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbBurnerType.Location = New System.Drawing.Point(292, 70)
        Me.pbBurnerType.Name = "pbBurnerType"
        Me.pbBurnerType.Size = New System.Drawing.Size(32, 32)
        Me.pbBurnerType.TabIndex = 93
        Me.pbBurnerType.TabStop = False
        '
        'pbStatusFuel
        '
        Me.pbStatusFuel.BackColor = System.Drawing.Color.Transparent
        Me.pbStatusFuel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbStatusFuel.Location = New System.Drawing.Point(229, 70)
        Me.pbStatusFuel.Name = "pbStatusFuel"
        Me.pbStatusFuel.Size = New System.Drawing.Size(32, 32)
        Me.pbStatusFuel.TabIndex = 92
        Me.pbStatusFuel.TabStop = False
        '
        'pbStatusN2O
        '
        Me.pbStatusN2O.BackColor = System.Drawing.Color.Transparent
        Me.pbStatusN2O.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbStatusN2O.Location = New System.Drawing.Point(186, 70)
        Me.pbStatusN2O.Name = "pbStatusN2O"
        Me.pbStatusN2O.Size = New System.Drawing.Size(32, 32)
        Me.pbStatusN2O.TabIndex = 91
        Me.pbStatusN2O.TabStop = False
        '
        'pbPressureFuel
        '
        Me.pbPressureFuel.BackColor = System.Drawing.Color.Transparent
        Me.pbPressureFuel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbPressureFuel.Location = New System.Drawing.Point(94, 70)
        Me.pbPressureFuel.Name = "pbPressureFuel"
        Me.pbPressureFuel.Size = New System.Drawing.Size(32, 32)
        Me.pbPressureFuel.TabIndex = 90
        Me.pbPressureFuel.TabStop = False
        '
        'pbPressureN2O
        '
        Me.pbPressureN2O.BackColor = System.Drawing.Color.Transparent
        Me.pbPressureN2O.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbPressureN2O.Location = New System.Drawing.Point(51, 70)
        Me.pbPressureN2O.Name = "pbPressureN2O"
        Me.pbPressureN2O.Size = New System.Drawing.Size(32, 32)
        Me.pbPressureN2O.TabIndex = 89
        Me.pbPressureN2O.TabStop = False
        '
        'pbPressureAir
        '
        Me.pbPressureAir.BackColor = System.Drawing.Color.Transparent
        Me.pbPressureAir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbPressureAir.Location = New System.Drawing.Point(8, 70)
        Me.pbPressureAir.Name = "pbPressureAir"
        Me.pbPressureAir.Size = New System.Drawing.Size(32, 32)
        Me.pbPressureAir.TabIndex = 88
        Me.pbPressureAir.TabStop = False
        '
        'pbStatusAir
        '
        Me.pbStatusAir.BackColor = System.Drawing.Color.Transparent
        Me.pbStatusAir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbStatusAir.Location = New System.Drawing.Point(143, 70)
        Me.pbStatusAir.Name = "pbStatusAir"
        Me.pbStatusAir.Size = New System.Drawing.Size(32, 32)
        Me.pbStatusAir.TabIndex = 87
        Me.pbStatusAir.TabStop = False
        '
        'lblFlameRatio
        '
        Me.lblFlameRatio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFlameRatio.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFlameRatio.Location = New System.Drawing.Point(576, 44)
        Me.lblFlameRatio.Name = "lblFlameRatio"
        Me.lblFlameRatio.Size = New System.Drawing.Size(56, 24)
        Me.lblFlameRatio.TabIndex = 86
        Me.lblFlameRatio.Text = "RATIO"
        Me.lblFlameRatio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblFlameType
        '
        Me.lblFlameType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFlameType.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFlameType.Location = New System.Drawing.Point(527, 44)
        Me.lblFlameType.Name = "lblFlameType"
        Me.lblFlameType.Size = New System.Drawing.Size(48, 24)
        Me.lblFlameType.TabIndex = 85
        Me.lblFlameType.Text = "TYPE"
        Me.lblFlameType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblSafetyControlsTrap
        '
        Me.lblSafetyControlsTrap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSafetyControlsTrap.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSafetyControlsTrap.Location = New System.Drawing.Point(473, 44)
        Me.lblSafetyControlsTrap.Name = "lblSafetyControlsTrap"
        Me.lblSafetyControlsTrap.Size = New System.Drawing.Size(48, 24)
        Me.lblSafetyControlsTrap.TabIndex = 84
        Me.lblSafetyControlsTrap.Text = "TRAP"
        Me.lblSafetyControlsTrap.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblSafetyControlsDoor
        '
        Me.lblSafetyControlsDoor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSafetyControlsDoor.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSafetyControlsDoor.Location = New System.Drawing.Point(419, 44)
        Me.lblSafetyControlsDoor.Name = "lblSafetyControlsDoor"
        Me.lblSafetyControlsDoor.Size = New System.Drawing.Size(53, 24)
        Me.lblSafetyControlsDoor.TabIndex = 83
        Me.lblSafetyControlsDoor.Text = "DOOR"
        Me.lblSafetyControlsDoor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblBurnerType
        '
        Me.lblBurnerType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBurnerType.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBurnerType.Location = New System.Drawing.Point(271, 44)
        Me.lblBurnerType.Name = "lblBurnerType"
        Me.lblBurnerType.Size = New System.Drawing.Size(75, 24)
        Me.lblBurnerType.TabIndex = 82
        Me.lblBurnerType.Text = "TYPE"
        Me.lblBurnerType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblStatusFuel
        '
        Me.lblStatusFuel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStatusFuel.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatusFuel.Location = New System.Drawing.Point(224, 44)
        Me.lblStatusFuel.Name = "lblStatusFuel"
        Me.lblStatusFuel.Size = New System.Drawing.Size(43, 24)
        Me.lblStatusFuel.TabIndex = 81
        Me.lblStatusFuel.Text = "FUEL"
        Me.lblStatusFuel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblStatusN2O
        '
        Me.lblStatusN2O.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStatusN2O.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatusN2O.Location = New System.Drawing.Point(181, 44)
        Me.lblStatusN2O.Name = "lblStatusN2O"
        Me.lblStatusN2O.Size = New System.Drawing.Size(42, 24)
        Me.lblStatusN2O.TabIndex = 80
        Me.lblStatusN2O.Text = "N2O"
        Me.lblStatusN2O.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblStatusAir
        '
        Me.lblStatusAir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStatusAir.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatusAir.Location = New System.Drawing.Point(138, 44)
        Me.lblStatusAir.Name = "lblStatusAir"
        Me.lblStatusAir.Size = New System.Drawing.Size(42, 24)
        Me.lblStatusAir.TabIndex = 79
        Me.lblStatusAir.Text = "AIR"
        Me.lblStatusAir.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblPressureFuel
        '
        Me.lblPressureFuel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPressureFuel.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPressureFuel.Location = New System.Drawing.Point(89, 44)
        Me.lblPressureFuel.Name = "lblPressureFuel"
        Me.lblPressureFuel.Size = New System.Drawing.Size(43, 24)
        Me.lblPressureFuel.TabIndex = 78
        Me.lblPressureFuel.Text = "FUEL"
        Me.lblPressureFuel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblPressureN2O
        '
        Me.lblPressureN2O.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPressureN2O.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPressureN2O.Location = New System.Drawing.Point(46, 44)
        Me.lblPressureN2O.Name = "lblPressureN2O"
        Me.lblPressureN2O.Size = New System.Drawing.Size(42, 24)
        Me.lblPressureN2O.TabIndex = 77
        Me.lblPressureN2O.Text = "N2O"
        Me.lblPressureN2O.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblPressureAir
        '
        Me.lblPressureAir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPressureAir.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPressureAir.Location = New System.Drawing.Point(3, 44)
        Me.lblPressureAir.Name = "lblPressureAir"
        Me.lblPressureAir.Size = New System.Drawing.Size(42, 24)
        Me.lblPressureAir.TabIndex = 76
        Me.lblPressureAir.Text = "AIR"
        Me.lblPressureAir.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblFlame
        '
        Me.lblFlame.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFlame.Location = New System.Drawing.Point(528, 8)
        Me.lblFlame.Name = "lblFlame"
        Me.lblFlame.Size = New System.Drawing.Size(104, 32)
        Me.lblFlame.TabIndex = 75
        Me.lblFlame.Text = "FLAME"
        Me.lblFlame.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'lblSafetyControls
        '
        Me.lblSafetyControls.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSafetyControls.Location = New System.Drawing.Point(424, 8)
        Me.lblSafetyControls.Name = "lblSafetyControls"
        Me.lblSafetyControls.Size = New System.Drawing.Size(84, 32)
        Me.lblSafetyControls.TabIndex = 74
        Me.lblSafetyControls.Text = "SAFETY CONTROLS"
        Me.lblSafetyControls.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'lblBurner
        '
        Me.lblBurner.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBurner.Location = New System.Drawing.Point(272, 8)
        Me.lblBurner.Name = "lblBurner"
        Me.lblBurner.Size = New System.Drawing.Size(135, 32)
        Me.lblBurner.TabIndex = 73
        Me.lblBurner.Text = "BURNER"
        Me.lblBurner.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'lblPressureValveStatus
        '
        Me.lblPressureValveStatus.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPressureValveStatus.Location = New System.Drawing.Point(144, 8)
        Me.lblPressureValveStatus.Name = "lblPressureValveStatus"
        Me.lblPressureValveStatus.Size = New System.Drawing.Size(110, 32)
        Me.lblPressureValveStatus.TabIndex = 72
        Me.lblPressureValveStatus.Text = "PRESSURE VALVE STATUS"
        Me.lblPressureValveStatus.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'lblPressures
        '
        Me.lblPressures.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPressures.Location = New System.Drawing.Point(8, 8)
        Me.lblPressures.Name = "lblPressures"
        Me.lblPressures.Size = New System.Drawing.Size(110, 32)
        Me.lblPressures.TabIndex = 71
        Me.lblPressures.Text = "PRESSURES"
        Me.lblPressures.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.Control
        Me.Label7.Location = New System.Drawing.Point(415, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(2, 104)
        Me.Label7.TabIndex = 70
        Me.Label7.Text = "Label7"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.Control
        Me.Label6.Location = New System.Drawing.Point(523, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(2, 104)
        Me.Label6.TabIndex = 69
        Me.Label6.Text = "Label6"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Location = New System.Drawing.Point(268, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(2, 104)
        Me.Label5.TabIndex = 68
        Me.Label5.Text = "Label5"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Location = New System.Drawing.Point(134, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(2, 104)
        Me.Label4.TabIndex = 67
        Me.Label4.Text = "Label4"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.Control
        Me.Label8.Location = New System.Drawing.Point(0, 40)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(700, 2)
        Me.Label8.TabIndex = 66
        '
        'btnNAFLAME
        '
        Me.btnNAFLAME.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNAFLAME.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNAFLAME.Image = CType(resources.GetObject("btnNAFLAME.Image"), System.Drawing.Image)
        Me.btnNAFLAME.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNAFLAME.Location = New System.Drawing.Point(61, 200)
        Me.btnNAFLAME.Name = "btnNAFLAME"
        Me.btnNAFLAME.Size = New System.Drawing.Size(123, 38)
        Me.btnNAFLAME.TabIndex = 8
        Me.btnNAFLAME.Text = "&NA FLAME"
        Me.btnNAFLAME.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnAAFLAME
        '
        Me.btnAAFLAME.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAAFLAME.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAAFLAME.Image = CType(resources.GetObject("btnAAFLAME.Image"), System.Drawing.Image)
        Me.btnAAFLAME.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAAFLAME.Location = New System.Drawing.Point(61, 144)
        Me.btnAAFLAME.Name = "btnAAFLAME"
        Me.btnAAFLAME.Size = New System.Drawing.Size(123, 38)
        Me.btnAAFLAME.TabIndex = 7
        Me.btnAAFLAME.Text = "&AA FLAME"
        Me.btnAAFLAME.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnSetMaxBurnerHeight
        '
        Me.btnSetMaxBurnerHeight.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSetMaxBurnerHeight.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSetMaxBurnerHeight.Image = CType(resources.GetObject("btnSetMaxBurnerHeight.Image"), System.Drawing.Image)
        Me.btnSetMaxBurnerHeight.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSetMaxBurnerHeight.Location = New System.Drawing.Point(504, 195)
        Me.btnSetMaxBurnerHeight.Name = "btnSetMaxBurnerHeight"
        Me.btnSetMaxBurnerHeight.Size = New System.Drawing.Size(110, 38)
        Me.btnSetMaxBurnerHeight.TabIndex = 5
        Me.btnSetMaxBurnerHeight.Text = "Set Max. &Burner Ht."
        Me.btnSetMaxBurnerHeight.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'btnSetMaxFuel
        '
        Me.btnSetMaxFuel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSetMaxFuel.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSetMaxFuel.Image = CType(resources.GetObject("btnSetMaxFuel.Image"), System.Drawing.Image)
        Me.btnSetMaxFuel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSetMaxFuel.Location = New System.Drawing.Point(504, 150)
        Me.btnSetMaxFuel.Name = "btnSetMaxFuel"
        Me.btnSetMaxFuel.Size = New System.Drawing.Size(110, 38)
        Me.btnSetMaxFuel.TabIndex = 2
        Me.btnSetMaxFuel.Text = "Set Max. &Fuel"
        Me.btnSetMaxFuel.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'btnIncreaseBurnerHeight
        '
        Me.btnIncreaseBurnerHeight.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnIncreaseBurnerHeight.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIncreaseBurnerHeight.Image = CType(resources.GetObject("btnIncreaseBurnerHeight.Image"), System.Drawing.Image)
        Me.btnIncreaseBurnerHeight.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnIncreaseBurnerHeight.Location = New System.Drawing.Point(248, 195)
        Me.btnIncreaseBurnerHeight.Name = "btnIncreaseBurnerHeight"
        Me.btnIncreaseBurnerHeight.Size = New System.Drawing.Size(110, 38)
        Me.btnIncreaseBurnerHeight.TabIndex = 3
        Me.btnIncreaseBurnerHeight.Text = "Increase Burner H&t."
        Me.btnIncreaseBurnerHeight.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'btnDecreaseBurnerHeight
        '
        Me.btnDecreaseBurnerHeight.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDecreaseBurnerHeight.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDecreaseBurnerHeight.Image = CType(resources.GetObject("btnDecreaseBurnerHeight.Image"), System.Drawing.Image)
        Me.btnDecreaseBurnerHeight.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDecreaseBurnerHeight.Location = New System.Drawing.Point(376, 195)
        Me.btnDecreaseBurnerHeight.Name = "btnDecreaseBurnerHeight"
        Me.btnDecreaseBurnerHeight.Size = New System.Drawing.Size(110, 38)
        Me.btnDecreaseBurnerHeight.TabIndex = 4
        Me.btnDecreaseBurnerHeight.Text = "Decrease Burner &Ht."
        Me.btnDecreaseBurnerHeight.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'btnDecreaseFuel
        '
        Me.btnDecreaseFuel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDecreaseFuel.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDecreaseFuel.Image = CType(resources.GetObject("btnDecreaseFuel.Image"), System.Drawing.Image)
        Me.btnDecreaseFuel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDecreaseFuel.Location = New System.Drawing.Point(376, 150)
        Me.btnDecreaseFuel.Name = "btnDecreaseFuel"
        Me.btnDecreaseFuel.Size = New System.Drawing.Size(110, 38)
        Me.btnDecreaseFuel.TabIndex = 1
        Me.btnDecreaseFuel.Text = "Decrea&se Fuel"
        Me.btnDecreaseFuel.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'btnIncreaseFuel
        '
        Me.btnIncreaseFuel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnIncreaseFuel.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIncreaseFuel.Image = CType(resources.GetObject("btnIncreaseFuel.Image"), System.Drawing.Image)
        Me.btnIncreaseFuel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnIncreaseFuel.Location = New System.Drawing.Point(248, 150)
        Me.btnIncreaseFuel.Name = "btnIncreaseFuel"
        Me.btnIncreaseFuel.Size = New System.Drawing.Size(110, 38)
        Me.btnIncreaseFuel.TabIndex = 0
        Me.btnIncreaseFuel.Text = "Increse      F&uel"
        Me.btnIncreaseFuel.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Black
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Location = New System.Drawing.Point(235, 99)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(2, 188)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Label2"
        '
        'frmAutoIgnition
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(634, 287)
        Me.Controls.Add(Me.CustomPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAutoIgnition"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AUTO IGNITION"
        Me.CustomPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Variables"
    Private mobjController As New BgThread.clsBgThread(Me)
    Private WithEvents mobjclsBgAutoIgnition As ClsBgManualIgnition


    Private mblnN2OPresure As Boolean = False
    Dim blnPressureSensor1 As Boolean = True
    Dim blnPressureSensor2 As Boolean = True
    Dim blnPressureSensor3 As Boolean = True
    Dim blnBurner As Boolean = False
    Dim aa, ps1, ps2, ps3, air, n2, fuel, BIgnite As Boolean
    Dim ato As Boolean = True
    Dim k As Integer
    Dim data As Byte
    Dim flag As Boolean
    Dim aaft As Boolean = False
    Dim n2oft As Boolean = False
    Dim posted As Boolean = False
    Dim mobjThread As Threading.Thread
    Dim count As Integer
    Private mblnExitBackGround As Boolean = False
    Private mblnAvoidPorcess As Boolean = False

    Private mblnInProcess As Boolean = False
    Private mblnIgnitionWait As Boolean = False
    Private mblnIgnitionTerminate As Boolean = False
    Private mintIgniteType As Integer
    'Private mblnAvoidProcessing As Boolean
    Private intFlameType As Integer
    Private mblnIsfrmFlameStatusWork As Boolean

#End Region

#Region "Constants"

#End Region

#Region "Properties"

#End Region

#Region " Form Events"

    Private Sub frmAutoIgnition_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '=====================================================================
        ' Procedure Name        : frmAutoIgnition_Load
        ' Parameters Passed     : Object, EventArgs
        ' Returns               : 
        ' Purpose               : To load the Auto Ignition form. 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 07-02-2007
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Try
            'Call funcInitialise()
            btnAAFLAME.Focus()

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
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

        '        void 	S4FUNC Auto_Init(HWND hpar)
        '   {
        '       int     	k; //,i;
        '       BYTE    	data;
        '       HWND 		hwnd,hwnd1;
        '       MSG		msg;
        '       BOOL    	flag=FALSE;
        '       DLGPROC 	skp ;
        '       DWORD		w1,w2;
        '       BOOL 		ato=TRUE,aaft=OFF, n2oft=OFF, posted=FALSE;
        '       HDC 		hdc;

        '       // hwnd1 = Create_Window_Pneum(NULL,"AA-203  AA FLAME");
        '       If (!Commflag) Then
        '	        return;
        '       if(GetInstrument()==AA202)
        '	        hwnd1 = Create_Window_Pneum("AA-202  AA FLAME");
        '       Else
        '	        hwnd1 = Create_Window_Pneum("AA-203  AA FLAME");
        '       StHwnd=hwnd1;
        '       skp = (DLGPROC) MakeProcInstance((FARPROC) ManualProc, hInst);
        '       hwnd = CreateDialog(hInst, "AUTO", NULL, skp);
        '       if (hwnd!=NULL)
        '       {
        '	        EnableWindow(hpar, FALSE);	 	
        '           ShowWindow(hwnd, SW_SHOW);
        '	        UpdateWindow(hwnd); 
        '           WP1=-1;		
        '           hdc = GetDC(hwnd);
        '	        SetBkColor(hdc, RGB(192,192,192));
        '	        aa =  OFF;
        '	        ps1= ps2= ps3 = ON;
        '	        data = CHECK_BUR_PAR();
        '	        if (data & AA_CONNECTED) 
        '               aa = ON;
        '	        else 
        '               aa=OFF;
        '	        data  = CHECK_PS();
        '	        if (data & AIR_NOK)  
        '               ps1 = OFF;
        '	        if (data & N2O_NOK)  
        '               ps2 = OFF;
        '	        if (data & FUEL_NOK) 
        '           {
        '               ato = OFF; 
        '               ps3 = OFF;
        '           }
        '	        if (ps1==OFF) 
        '               ato = OFF;
        '	        if (ps3==OFF) 
        '               ato = OFF;
        '	        if (aa!=ON && ps2==OFF) 
        '               ato = OFF;
        '	        w1 = GetTickCount();
        '	        Auto_Init_Check(&ato);
        '	        while(1)
        '           {
        '		        w2 = GetTickCount();
        '		        if ((w2-w1) > (DWORD) 200)
        '               {
        '		            w1=w2;
        '		            Status_Disp();
        '		        }
        '		        Auto_Init_Check(&ato);
        '               if (!ato)
        '                   if (!posted)
        '                   {
        '                       PostMessage(hwnd, WM_COMMAND, IDOK, 0L);
        '                       posted=TRUE;
        '                   }
        '		        if (flag|| Inst.Aaf!=aaft || Inst.N2of!=n2oft)
        '               {
        '		            ShowWindow(GetDlgItem(hwnd, IDC_BTN2),SW_SHOW);
        '		            ShowWindow(GetDlgItem(hwnd, IDC_BTN2),SW_SHOW);
        '		            flag = FALSE;
        '		            aaft = Inst.Aaf; 
        '                   n2oft=Inst.N2of;
        '		            if (Inst.Aaf) 
        '                   {
        '			            SetWindowText(GetDlgItem(hwnd, IDC_STATUS), "AA -FLAME");
        '			            SetWindowText(GetDlgItem(hwnd, IDC_BTN1), "EXTINGUISH AA");
        '			            ShowWindow(GetDlgItem(hwnd, IDC_BTN2),SW_HIDE);
        '			        }
        '		            else if (Inst.N2of)	
        '                   {
        '			            SetWindowText(GetDlgItem(hwnd, IDC_STATUS), "NA -FLAME");
        '			            SetWindowText(GetDlgItem(hwnd, IDC_BTN1), "EXTINGUISH NA");
        '			            ShowWindow(GetDlgItem(hwnd, IDC_BTN2),SW_HIDE);
        '			        }
        '		            else 
        '                   {
        '			            SetWindowText(GetDlgItem(hwnd, IDC_STATUS), "READY FOR IGNITION");
        '                       if (!aa) 
        '				            SetWindowText(GetDlgItem(hwnd, IDC_BTN2), "NA FLAME");
        '                       else
        '				            ShowWindow(GetDlgItem(hwnd, IDC_BTN2),SW_HIDE);
        '			            SetWindowText(GetDlgItem(hwnd, IDC_BTN1), "AA FLAME");
        '		    	    }
        '			    UpdateWindow(hwnd);
        '		    }
        '           if (CheckMsg(hwnd, &msg))
        '           {
        '		        flag = TRUE;
        '		        switch(WP1)
        '               {
        '			         case  IDC_BTN1:if (Inst.Aaf)  Inst.Aaf=AA_FLAME_OFF();
        '								 else if (Inst.N2of ) Inst.N2of=N2_FLAME_OFF();
        '								 else	Inst.Aaf = AA_FLAME_ON();
        '								 Beep(); break;
        '			 case  IDC_BTN2:	if (!Inst.N2of ) Inst.N2of=N2_FLAME_ON();
        '									else{ if(GetInstrument() == AA202)
        '												Gerror_message_new("Sorry already in NA Flame", "AA-202 PNEUM");
        '											else
        '												Gerror_message_new("Sorry already in NA Flame", "AA-203 PNEUM");}
        '									break;
        '			case IDC_INCRF:  Incr_Fuel();
        '								  Wprintf(hdc, 10, 70, "%3.2f    ", (double)Inst.Nvstep/(double)NVRED);break;
        '			case IDC_DFUEL:  Decr_Fuel();
        '								  Wprintf(hdc, 10, 70, "%3.2f     ", (double)Inst.Nvstep/(double) NVRED); break;
        '			case IDC_INCRH : Incr_Height(); break;
        '			case IDC_DECRH : Decr_Height(); break;
        '			case IDC_FUEL  : if (NV_HOME()) Inst.Nvstep=0;
        '								  else Inst.Nvstep = -1;break;
        '			case IDC_BUR:   if(BH_HOME()) Inst.Bhstep =0;
        '								 else Inst.Bhstep=-1; break;
        '			}
        '		  if (WP1==IDOK){
        '			 WP1=-1;
        '			 for(k=0; k<10;k++)
        '				 CheckMsg(hpar, &msg);
        '			 EnableWindow(hpar, TRUE);
        '			 ReleaseDC(hwnd, hdc);
        '			 DestroyWindow(hwnd);
        '			 UpdateWindow(hpar);
        '			 break;
        '		  }
        '		  WP1=-1;
        '		}
        '	 }
        '  }
        ' FreeProcInstance((FARPROC)skp);
        ' Close_Window(hwnd1, NULL);
        ' StHwnd=NULL;
        '}

    End Sub

    'Private Sub frmAutoIgnition_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    '    'objThread.Abort()
    '    mblnExitBackGround = True
    '    'objThread.Abort()
    '    'objThread.Join()
    '    Application.DoEvents()
    '    If mblnAvoidPorcess = True Then
    '        Exit Sub
    '    End If
    '    Me.DialogResult = DialogResult.Cancel
    '    Me.Close()
    'End Sub

#End Region

#Region " Private Functions"

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

            AddHandler btnAAFLAME.Click, AddressOf btnAAFLAME_Click
            AddHandler btnNAFLAME.Click, AddressOf btnNAFLAME_Click
            AddHandler btnClose.Click, AddressOf btnClose_Click
            'AddHandler btnIgnite.Click, AddressOf btnIgnite_Click
            'AddHandler btnAirOnOff.Click, AddressOf btnAirOnOff_Click
            AddHandler btnSetMaxFuel.Click, AddressOf btnSetMaxFuel_Click
            AddHandler btnDecreaseFuel.Click, AddressOf btnDecreaseFuel_Click
            AddHandler btnIncreaseFuel.Click, AddressOf btnIncreaseFuel_Click
            AddHandler btnSetMaxBurnerHeight.Click, AddressOf btnSetMaxBurnerHeight_Click
            AddHandler btnDecreaseBurnerHeight.Click, AddressOf btnDecreaseBurnerHeight_Click
            AddHandler btnIncreaseBurnerHeight.Click, AddressOf btnIncreaseBurnerHeight_Click
            'AddHandler tmrCheckManualIgnite.Elapsed, AddressOf tmrCheckManualIgnite_Elapsed

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
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
        ' Returns               : None
        ' Purpose               : To initialise the form 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 16.02.07
        ' Revisions             : 
        '=====================================================================
        Try
            If Not IsNothing(gobjMain) Then
                'If Not IsNothing(gobjMain.mobjfrmAnalysis) Then gobjMain.mobjfrmAnalysis.tmrAspirationMsg.Enabled = False
                If gobjMain.mobjController.IsThreadRunning = True Then
                    mblnIsfrmFlameStatusWork = True
                    gobjMain.mobjController.Cancel()
                    gobjCommProtocol.mobjCommdll.subTime_Delay(500)   '10.12.07
                    Application.DoEvents()
                End If
                Application.DoEvents()
            End If
            Call AddHandlers()
            If funcAuto_Init() = False Then
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
            'Application.DoEvents()
            ''mblnExitBackGround = True
            ''objThread.Join()
            ''objThread.Abort()
            'Me.DialogResult = DialogResult.Cancel
            'Me.Close()
            'Application.DoEvents()
            If mblnIgnitionTerminate = False Then
                '    Call subStopScan()
                mobjclsBgAutoIgnition.ThTerminate = True
                mobjclsBgAutoIgnition.IgnitionWait = True
                mblnIgnitionWait = True
                Application.DoEvents()
                'Call btnClose_Click(sender, e)
                Exit Sub
            Else
                If Not (mobjController Is Nothing) Then
                    If mobjController.IsThreadRunning Then
                        mobjclsBgAutoIgnition.ThTerminate = True
                        mobjclsBgAutoIgnition.IgnitionWait = True
                        mblnIgnitionWait = True
                        mobjController.Cancel()
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
            '---------------------------------------------------------
        End Try
    End Sub

    Private Function Auto_Init_Check(ByRef ato As Boolean) As Boolean
        '=====================================================================
        ' Procedure Name        : Auto_Init_Check
        ' Parameters Passed     : ato as Boolean
        ' Returns               : True or False
        ' Purpose               : To check the necessary conditions required 
        '                       : for auto ignition.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 07-02-2007
        ' Revisions             : 
        '=====================================================================
        '        void(Auto_Init_Check(BOOL * ato))
        '{
        'BYTE data;

        ' ps1 = ps2 = ps3 = aa = ON;
        ' data = CHECK_BUR_PAR();
        ' if (data & AA_CONNECTED) aa = ON;
        ' else aa = OFF;
        ' data  = CHECK_PS();
        ' if (data & AIR_NOK)  {
        '	ps1 = OFF;
        '	if (Inst.Aaf) {
        '	  Inst.Aaf=AA_FLAME_OFF();
        '	  if(GetInstrument() == AA202)
        '		  Gerror_message_new("Low Air Pressure..", "AA-202 PNEUM");
        '                    Else
        '		  Gerror_message_new("Low Air Pressure..", "AA-203 PNEUM");
        '	 }
        '  }
        ' if (data & N2O_NOK)  {
        '	ps2 = OFF;
        '	if (Inst.N2of) {
        '	  Inst.N2of=N2_FLAME_OFF();
        '	  if( GetInstrument() == AA202 )
        '		  Gerror_message_new("Low N2O Pressure..", "AA-202 PNEUM");
        '                                Else
        '		  Gerror_message_new("Low N2O Pressure..", "AA-203 PNEUM");
        '	 }
        '  }
        ' if (data & FUEL_NOK) {
        '	*ato = OFF; ps3 = OFF;
        '	if(GetInstrument() == AA202)
        '		Gerror_message_new("Low Fuel Pressure..", "AA-202 PNEUM");
        '                                        Else
        '		Gerror_message_new("Low Fuel Pressure..", "AA-203 PNEUM");
        '  }
        ' if (aa==ON && ps1==OFF) *ato = OFF;
        ' if (aa!=ON && ps2==OFF) *ato = OFF;
        '}
        '//------------------------------
        Dim BData As Byte

        Try
            'If Not IsNothing(mobjThread) Then
            '    If Not mobjThread.IsAlive Then
            '        Exit Function
            '    End If
            'End If

            Status_Disp()
            aa = True   ' To check for AA burner parameter status
            ps1 = True  ' To check for Air pressure 
            ps2 = True  ' To check for N2O pressure 
            ps3 = True  ' To check for Fuel pressure 

            gobjCommProtocol.mobjCommdll.subTime_Delay(20)
            If mblnIgnitionWait = False Then
                If gobjCommProtocol.funcCheckBurnerParameters(BData) = False Then
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
            gobjCommProtocol.mobjCommdll.subTime_Delay(20)
            If mblnIgnitionWait = False Then
                If gobjCommProtocol.funcPressSensorStatus(BData, False) = False Then
                    Exit Function
                End If
            Else
                Exit Function
            End If
            If (BData And EnumErrorStatus.AIR_NOK) Then
                ps1 = False
                If (gobjInst.Aaf) Then
                    gobjCommProtocol.mobjCommdll.subTime_Delay(20)
                    If mblnIgnitionWait = False Then
                        If gobjCommProtocol.func_AA_FLAME_OFF = True Then
                            gobjInst.Aaf = False
                        End If
                        gobjMessageAdapter.ShowMessage(constLowAirPressure)
                    Else
                        Exit Function
                    End If
                    'MsgBox("Low Air Pressure")
                End If
            End If
            If (BData And EnumErrorStatus.N2O_NOK) Then
                ps2 = False
                If (gobjInst.N2of) Then
                    gobjCommProtocol.mobjCommdll.subTime_Delay(20)
                    If mblnIgnitionWait = False Then
                        If gobjCommProtocol.func_N2_FLAME_OFF() = False Then
                            gobjInst.N2of = False
                        End If
                    End If
                    gobjMessageAdapter.ShowMessage(constLowN2OPressure)
                    Exit Function
                    'gobjMessageAdapter.ShowMessage(constLowN2OPressure)
                    'MsgBox("Low N2O Pressure")
                End If
            End If

            If (BData And EnumErrorStatus.FUEL_NOK) Then
                ato = False
                ps3 = False
                If count < 4 Then
                    gobjMessageAdapter.ShowMessage(constLowFuelPressure)
                    'MsgBox("Low fuel Pressure")
                    count += 1
                Else
                    'Me.Close()
                    btnClose_Click(btnClose, System.EventArgs.Empty)
                End If
            Else
                'count = 0
            End If

            If (aa = False And ps1 = False) Then
                ato = False
            End If

            If (Not aa = True And ps2 = False) Then
                ato = False
            End If
            Return True

            'Catch threadex As Threading.ThreadAbortException

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
            'objWait.Dispose()
            '---------------------------------------------------------
        End Try



        '   void(Auto_Init_Check(BOOL * ato))
        '   {
        '       BYTE data;

        '       ps1 = ps2 = ps3 = aa = ON;
        '       data = CHECK_BUR_PAR();
        '       if (data & AA_CONNECTED) 
        '           aa = ON;
        '       else 
        '           aa = OFF;
        '       data  = CHECK_PS();
        '       if (data & AIR_NOK)     
        '           {
        '	            ps1 = OFF;
        '	            if (Inst.Aaf) 
        '               {
        '	                Inst.Aaf=AA_FLAME_OFF();
        '	                if(GetInstrument() == AA202)
        '		                Gerror_message_new("Low Air Pressure..", "AA-202 PNEUM");
        '                   Else
        '                       Gerror_message_new("Low Air Pressure..", "AA-203 PNEUM");
        '	            }
        '           }
        '       if (data & N2O_NOK)  
        '       {
        '	        ps2 = OFF;
        '	        if (Inst.N2of) 
        '           {
        '	            Inst.N2of=N2_FLAME_OFF();
        '	            if( GetInstrument() == AA202 )
        '		            Gerror_message_new("Low N2O Pressure..", "AA-202 PNEUM");
        '               Else
        '		            Gerror_message_new("Low N2O Pressure..", "AA-203 PNEUM");
        '	        }
        '       }
        '       if (data & FUEL_NOK) 
        '       {
        '	        *ato = OFF; ps3 = OFF;
        '	        if(GetInstrument() == AA202)
        '		        Gerror_message_new("Low Fuel Pressure..", "AA-202 PNEUM");
        '           Else
        '		        Gerror_message_new("Low Fuel Pressure..", "AA-203 PNEUM");
        '       }
        '       if (aa==ON && ps1==OFF) 
        '           *ato = OFF;
        '       if (aa!=ON && ps2==OFF) 
        '           *ato = OFF;
        '   }

    End Function

    Public Function Status_Disp() As Boolean
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
        '***************************************************************
        'void(Status_Disp())
        '{
        '	char  line1[80];
        '	BYTE  status,st, st1;
        '	BOOL	flag=TRUE;

        '   If (!Commflag) Then
        '		return;
        '   If (StHwnd! = NULL) Then
        '	{
        '		status = GET_PNEUM_STATUS();
        '		//st=random(255); st1=random(255);
        '		st = CHECK_PS();
        '		st1 = CHECK_BUR_PAR();
        '		if (st & AIR_NOK)	 		{  flag=FALSE; SetVal(IDC_PAIR, "ERROR");}
        '		else 	SetVal(IDC_PAIR, "OK");
        '		if (st & N2O_NOK)	 		{  flag=FALSE; SetVal(IDC_PN2O, "ERROR");}
        '		else 	SetVal(IDC_PN2O, "OK");
        '		if (st & FUEL_NOK)	 		{  flag=FALSE; SetVal(IDC_PFUEL, "ERROR");}
        '		else 	SetVal(IDC_PFUEL, "OK");
        '                            If (status & SAIR_NON) Then
        '		{
        '			flag=FALSE; SetVal(IDC_PVAIR,"CLOSE");
        '		}
        '		else	SetVal(IDC_PVAIR,"OPEN");
        '		if (status & SN2O_ON)	 	SetVal(IDC_PVN2O, "OPEN");
        '		else	{  flag=FALSE; SetVal(IDC_PVN2O, "CLOSE");}
        '		if (status & SFUEL_ON)	SetVal(IDC_PVFUEL, "OPEN");
        '		else	{  flag=FALSE; SetVal(IDC_PVFUEL, "CLOSE");}
        '		if (st1 & AA_CONNECTED) 	SetVal(IDC_BTYPE, "BTAA");
        '		else 	SetVal(IDC_BTYPE, "BTNA");
        '		if (st1 & TRAP_NOK) {  flag=FALSE; SetVal(IDC_TRAP, "TOPEN");}
        '		else SetVal(IDC_TRAP, "OK");
        '		if (st1 &DOOR_NOK) {  flag=FALSE; SetVal(IDC_DTYPE, "DOPEN");}
        '		else SetVal(IDC_DTYPE, "DCLOSE");
        '		if ((st&YELLOW_OK) ==YELLOW_OK) 		SetVal(IDC_FLAME, "YELLOW");
        '		else if ((st&BLUE_OK)==BLUE_OK)  	SetVal(IDC_FLAME, "BLUE");
        '		else if ((st & FLAME_OK)==FLAME_OK) 	SetVal(IDC_FLAME, "BYELLOW");
        '		else if (flag)	SetVal(IDC_FLAME, "GREEN");
        '		else SetVal(IDC_FLAME, "RED");
        '		Get_NV_Pos();
        '		sprintf(line1,"%3.2f", Read_Fuel());	// Nv pos
        '		SetWindowText(GetDlgItem(StHwnd, IDC_FR),line1);
        '		Get_BH_Pos();
        '		sprintf(line1,"%2.1f", ReadBurnerHeight());
        '		SetWindowText(GetDlgItem(StHwnd, IDC_BH),line1);
        '		UpdateWindow (StHwnd) ;
        '	}
        '}
        '***************************************************************
        Dim line1 As String
        Dim status, st, st1 As Byte
        Dim flag As Boolean = True

        Try
            'If Not IsNothing(mobjThread) Then
            '    If Not mobjThread.IsAlive Then
            '        Exit Function
            '    End If
            'End If
            gobjCommProtocol.mobjCommdll.subTime_Delay(20)
            If mblnIgnitionWait = False Then
                status = gobjCommProtocol.funcGet_Pneum_Status()
            Else
                Exit Function
            End If
            gobjCommProtocol.mobjCommdll.subTime_Delay(20)
            If mblnIgnitionWait = False Then
                gobjCommProtocol.funcPressSensorStatus(st, False)
            Else
                Exit Function
            End If
            gobjCommProtocol.mobjCommdll.subTime_Delay(20)
            If mblnIgnitionWait = False Then
                gobjCommProtocol.funcCheckBurnerParameters(st1)
            Else
                Exit Function
            End If

            '----added by deepak b on 06.05.07 for flame status update
            'Dim intFlameType As Integer
            'If gstructSettings.AppMode = EnumAppMode.DemoMode Then
            '    intFlameType = ClsAAS203.enumIgniteType.Blue
            'Else
            '    intFlameType = gobjClsAAS203.funcIgnite_Test()
            'End If
            'gobjfrmStatus.FlameType = intFlameType
            '----added by deepak b on 06.05.07 for flame status update

            If (st And EnumErrorStatus.AIR_NOK) Then
                flag = False
                pbPressureAir.Image = Image.FromFile(Application.StartupPath & "\" & "images\ERROR.BMP")
            Else
                pbPressureAir.Image = Image.FromFile(Application.StartupPath & "\" & "images\OK.BMP")
            End If

            If (st And EnumErrorStatus.N2O_NOK) Then
                flag = False
                pbPressureN2O.Image = Image.FromFile(Application.StartupPath & "\" & "images\ERROR.BMP")
            Else
                pbPressureN2O.Image = Image.FromFile(Application.StartupPath & "\" & "images\OK.BMP")
            End If

            If (st And EnumErrorStatus.FUEL_NOK) Then
                flag = False
                pbPressureFuel.Image = Image.FromFile(Application.StartupPath & "\" & "images\ERROR.BMP")
            Else
                pbPressureFuel.Image = Image.FromFile(Application.StartupPath & "\" & "images\OK.BMP")
            End If

            If (status And EnumErrorStatus.SAIR_NON) Then
                flag = False
                pbStatusAir.Image = Image.FromFile(Application.StartupPath & "\" & "images\close.BMP")
            Else
                pbStatusAir.Image = Image.FromFile(Application.StartupPath & "\" & "images\open.BMP")
            End If

            If (status And EnumErrorStatus.SN2O_NON) Then
                pbStatusN2O.Image = Image.FromFile(Application.StartupPath & "\" & "images\open.BMP")
            Else
                flag = False
                pbStatusN2O.Image = Image.FromFile(Application.StartupPath & "\" & "images\close.BMP")
            End If

            If (status And EnumErrorStatus.SFUEL_ON) Then
                pbStatusFuel.Image = Image.FromFile(Application.StartupPath & "\" & "images\open.BMP")
            Else
                flag = False
                pbStatusFuel.Image = Image.FromFile(Application.StartupPath & "\" & "images\close.BMP")
            End If

            If (st1 And EnumErrorStatus.AA_CONNECTED) Then
                pbBurnerType.Image = Image.FromFile(Application.StartupPath & "\" & "images\BTAA.bmp")
            Else
                pbBurnerType.Image = Image.FromFile(Application.StartupPath & "\" & "images\BTNA.bmp")
            End If

            If (st1 And EnumErrorStatus.TRAP_NOK) Then
                flag = False
                pbSafetyControlsTrap.Image = Image.FromFile(Application.StartupPath & "\" & "images\topen.bmp")
            Else
                pbSafetyControlsTrap.Image = Image.FromFile(Application.StartupPath & "\" & "images\OK.BMP")
            End If

            If (st1 And EnumErrorStatus.DOOR_NOK) Then
                flag = False
                pbSafetyControlsDoor.Image = Image.FromFile(Application.StartupPath & "\" & "images\DOPEN.bmp")
            Else
                pbSafetyControlsDoor.Image = Image.FromFile(Application.StartupPath & "\" & "images\DCLOSE.bmp")
            End If

            If (st And EnumErrorStatus.YELLOW_OK) = EnumErrorStatus.YELLOW_OK Then
                pbFlameType.Image = Image.FromFile(Application.StartupPath & "\" & "images\YELLOW.BMP")

            ElseIf (st And EnumErrorStatus.BLUE_OK) = EnumErrorStatus.BLUE_OK Then
                pbFlameType.Image = Image.FromFile(Application.StartupPath & "\" & "images\BLUE.BMP")

            ElseIf (st And EnumErrorStatus.FLAME_OK) = EnumErrorStatus.FLAME_OK Then
                pbFlameType.Image = Image.FromFile(Application.StartupPath & "\" & "images\BYELLOW.BMP")

            ElseIf flag Then
                pbFlameType.Image = Image.FromFile(Application.StartupPath & "\" & "images\GREEN.BMP")
            Else
                pbFlameType.Image = Image.FromFile(Application.StartupPath & "\" & "images\RED.BMP")
            End If
            gobjCommProtocol.mobjCommdll.subTime_Delay(20)
            If mblnIgnitionWait = False Then
                gobjCommProtocol.funcGet_NV_Pos()
                lblFRatio.Text = Format(gobjClsAAS203.funcRead_Fuel(), "0.00")
            Else
                Exit Function
            End If
            gobjCommProtocol.mobjCommdll.subTime_Delay(20)
            If mblnIgnitionWait = False Then
                gobjCommProtocol.func_Get_BH_Pos()
                'lblBHeight.Text = Format(gobjClsAAS203.funcReadBurnerHeight(), "0.00")
                lblBHeight.Text = Format(gobjClsAAS203.funcReadBurnerHeight(), "0.0")
            Else
                Exit Function
            End If

            'lblNVStep.Text = "NV : " & gobjInst.NvStep & ""

            'Catch threadex As Threading.ThreadAbortException
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
            Application.DoEvents()
            'objWait.Dispose()
            '---------------------------------------------------------
        End Try
    End Function

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
        If mblnAvoidPorcess = True Then
            Exit Sub
        End If
        Dim objWait As New CWaitCursor
        Try
            'mobjThread.Suspend()
            mblnAvoidPorcess = True
            mblnIgnitionWait = True
            mobjclsBgAutoIgnition.IgnitionWait = True

            Call gobjClsAAS203.funcDecr_Height()

            'Saurabh to set Bh step in the file "Bh.bhp" 11.07.07
            'Call gobjCommProtocol.funcSave_BH_Pos()
            'Saurabh

            'mobjThread.Resume()
            mblnAvoidPorcess = False
            mblnIgnitionWait = False
            mobjclsBgAutoIgnition.IgnitionWait = False

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
            mblnAvoidPorcess = False
            mblnIgnitionWait = False
            mobjclsBgAutoIgnition.IgnitionWait = False
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            'mblnAvoidPorcess = False
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
        If mblnAvoidPorcess = True Then
            Exit Sub
        End If
        Dim objWait As New CWaitCursor
        Try
            mblnAvoidPorcess = True
            mblnIgnitionWait = True
            mobjclsBgAutoIgnition.IgnitionWait = True

            'mobjThread.Suspend()
            Call gobjClsAAS203.funcSetFuel(gobjClsAAS203.funcRead_Fuel() - 0.1)
            lblNVStep1.Text = Format(CDbl(gobjInst.NvStep) / CDbl(NVSTEP), "000.00")
            'mobjThread.Resume()
            mblnAvoidPorcess = False
            mblnIgnitionWait = False
            mobjclsBgAutoIgnition.IgnitionWait = False

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
            mblnAvoidPorcess = False
            mblnIgnitionWait = False
            mobjclsBgAutoIgnition.IgnitionWait = False
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
        If mblnAvoidPorcess = True Then
            Exit Sub
        End If
        Dim objWait As New CWaitCursor
        Try
            mblnAvoidPorcess = True
            mblnIgnitionWait = True
            mobjclsBgAutoIgnition.IgnitionWait = True

            'mobjThread.Suspend()
            Call gobjClsAAS203.funcIncr_Height()

            'Saurabh to set Bh step in the file "Bh.bhp" 11.07.07
            'Call gobjCommProtocol.funcSave_BH_Pos()
            'Saurabh

            'mobjThread.Resume()
            mblnAvoidPorcess = False
            mblnIgnitionWait = False
            mobjclsBgAutoIgnition.IgnitionWait = False

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
            mblnAvoidPorcess = False
            mblnIgnitionWait = False
            mobjclsBgAutoIgnition.IgnitionWait = False
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
        If mblnAvoidPorcess = True Then
            Exit Sub
        End If
        Dim objWait As New CWaitCursor
        Try
            mblnAvoidPorcess = True
            mblnIgnitionWait = True
            mobjclsBgAutoIgnition.IgnitionWait = True

            'mobjThread.Suspend()
            Call gobjClsAAS203.funcSetFuel((gobjClsAAS203.funcRead_Fuel() + 0.1))
            lblNVStep1.Text = Format(CDbl(gobjInst.NvStep) / CDbl(NVSTEP), "#0.00")
            'mobjThread.Resume()
            mblnAvoidPorcess = False
            mblnIgnitionWait = False
            mobjclsBgAutoIgnition.IgnitionWait = False
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
            mblnAvoidPorcess = False
            mblnIgnitionWait = False
            mobjclsBgAutoIgnition.IgnitionWait = False
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
        If mblnAvoidPorcess = True Then
            Exit Sub
        End If
        Dim objWait As New CWaitCursor
        Try
            'mobjThread.Suspend()
            mblnAvoidPorcess = True
            mblnIgnitionWait = True
            mobjclsBgAutoIgnition.IgnitionWait = True
            If gobjCommProtocol.funcSetBH_HOME() Then
                gobjInst.BhStep = 0
            Else
                gobjInst.BhStep = -1
            End If
            'mobjThread.Resume()
            mblnAvoidPorcess = False
            mblnIgnitionWait = False
            mobjclsBgAutoIgnition.IgnitionWait = False

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
            mblnAvoidPorcess = False
            mblnIgnitionWait = False
            mobjclsBgAutoIgnition.IgnitionWait = False
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
        If mblnAvoidPorcess = True Then
            Exit Sub
        End If
        Dim objWait As New CWaitCursor
        Try
            'mobjThread.Suspend()
            mblnAvoidPorcess = True
            mblnIgnitionWait = True
            mobjclsBgAutoIgnition.IgnitionWait = True
            If gobjCommProtocol.funcSetNV_HOME() Then
                gobjInst.NvStep = 0
            Else
                gobjInst.NvStep = -1
            End If
            'mobjThread.Resume()
            mblnAvoidPorcess = False
            mblnIgnitionWait = False
            mobjclsBgAutoIgnition.IgnitionWait = False

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
            mblnAvoidPorcess = False
            mblnIgnitionWait = False
            mobjclsBgAutoIgnition.IgnitionWait = False
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

    '//----- Commented by Sachin Dokhale
    'Private Sub subWorkInBackground()
    '    '=====================================================================
    '    ' Procedure Name        : subWorkInBackground
    '    ' Parameters Passed     : Object,EventArgs
    '    ' Returns               : None
    '    ' Purpose               : To run the Manual_Init_Check in a  continious 
    '    '                       : loop and in background.      
    '    ' Description           : 
    '    ' Assumptions           : 
    '    ' Dependencies          : 
    '    ' Author                : Saurabh S
    '    ' Created               : 02.02.07
    '    ' Revisions             : 
    '    '=====================================================================
    '    Try
    '        mblnAvoidPorcess = True
    '        While (True)
    '            If gblnInComm = False Then
    '                If mblnExitBackGround = True Then
    '                    mblnAvoidPorcess = False
    '                    mobjThread.Join()
    '                    mobjThread.Abort()
    '                    Exit While
    '                End If
    '                Threading.Thread.Sleep(400)
    '                Auto_Init_Check(ato)
    '                If Not ato Then
    '                    If Not posted Then
    '                        posted = True
    '                    End If
    '                End If
    '                If (flag Or (Not (gobjInst.Aaf = aaft)) Or (Not (gobjInst.N2of = n2oft))) Then
    '                    btnAAFLAME.Visible = True
    '                    btnNAFLAME.Visible = True

    '                    flag = False
    '                    aaft = gobjInst.Aaf
    '                    n2oft = gobjInst.N2of
    '                    If gobjInst.Aaf Then
    '                        lblStatus.Text = "AA - FLAME"
    '                        btnAAFLAME.Text = "EXTINGUISH &AA FLAME"

    '                        btnNAFLAME.Visible = False
    '                    ElseIf gobjInst.N2of Then
    '                        lblStatus.Text = "NA - FLAME"
    '                        btnNAFLAME.Text = "EXTINGUISH &NA FLAME"
    '                        btnNAFLAME.Visible = False
    '                    Else
    '                        lblStatus.Text = "READY FOR IGNITION"
    '                        If Not aa Then
    '                            btnNAFLAME.Text = "&NA - FLAME"
    '                        Else
    '                            btnNAFLAME.Visible = False
    '                        End If
    '                        btnAAFLAME.Text = "&AA - FLAME"
    '                    End If
    '                End If
    '            Else
    '                If Not ato Then
    '                    If Not posted Then
    '                        posted = True
    '                    End If
    '                End If
    '                If (flag Or (Not (gobjInst.Aaf = aaft)) Or (Not (gobjInst.N2of = n2oft))) Then
    '                    btnAAFLAME.Visible = True
    '                    btnNAFLAME.Visible = True

    '                    flag = False
    '                    aaft = gobjInst.Aaf
    '                    n2oft = gobjInst.N2of
    '                    If gobjInst.Aaf Then
    '                        lblStatus.Text = "AA - FLAME"
    '                        btnAAFLAME.Text = "EXTINGUISH &AA FLAME"
    '                        btnAAFLAME.TextAlign = ContentAlignment.TopLeft

    '                        btnNAFLAME.Visible = False
    '                    ElseIf gobjInst.N2of Then
    '                        lblStatus.Text = "NA - FLAME"
    '                        btnNAFLAME.Text = "EXTINGUISH &NA FLAME"
    '                        btnNAFLAME.TextAlign = ContentAlignment.TopLeft
    '                        btnNAFLAME.Visible = False
    '                    Else
    '                        lblStatus.Text = "READY FOR IGNITION"
    '                        If Not aa Then
    '                            btnNAFLAME.Text = "&NA - FLAME"
    '                        Else
    '                            btnNAFLAME.Visible = False
    '                        End If
    '                        btnAAFLAME.Text = "&AA - FLAME"
    '                    End If
    '                End If
    '            End If
    '            Application.DoEvents()
    '        End While

    '    Catch threadex As Threading.ThreadAbortException

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

    'End Sub

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
    '//-----

    Private Sub subWorkInBackground()
        '=====================================================================
        ' Procedure Name        : subWorkInBackground
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To run the Manual_Init_Check in a  continious 
        '                       : loop and in background.      
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 02.02.07
        ' Revisions             : 
        '=====================================================================
        Try

            'While (True)
            'If gblnInComm = False Then
            'If mblnExitBackGround = True Then
            '    Exit Sub
            'End If
            If mblnIgnitionWait = True Then
                Exit Sub
            End If
            flag = True
            If Auto_Init_Check(ato) = False Then
                Exit Sub
            End If
            If Not ato Then
                If Not posted Then
                    posted = True
                End If
            End If
            If (flag Or (Not (gobjInst.Aaf = aaft)) Or (Not (gobjInst.N2of = n2oft))) Then
                'btnAAFLAME.Visible = True
                'btnNAFLAME.Visible = True

                flag = False
                aaft = gobjInst.Aaf
                n2oft = gobjInst.N2of
                If gobjInst.Aaf Then
                    lblStatus.Text = "AA - FLAME"
                    btnAAFLAME.Text = "EXTINGUISH &AA FLAME"
                    btnNAFLAME.Visible = False
                    btnAAFLAME.Visible = True

                ElseIf gobjInst.N2of Then
                    lblStatus.Text = "NA - FLAME"
                    btnNAFLAME.Text = "EXTINGUISH &NA FLAME"
                    btnNAFLAME.Visible = True
                    btnAAFLAME.Visible = False
                Else
                    lblStatus.Text = "READY FOR IGNITION"
                    If Not aa Then
                        btnNAFLAME.Text = "&NA - FLAME"
                        btnNAFLAME.Visible = True
                        btnAAFLAME.Visible = False
                    Else
                        btnAAFLAME.Text = "&AA - FLAME"
                        btnNAFLAME.Visible = False
                        btnAAFLAME.Visible = True
                    End If
                    'btnAAFLAME.Text = "&AA - FLAME"
                End If
            End If
            'Else
            'If Not ato Then
            '    If Not posted Then
            '        posted = True
            '    End If
            'End If
            'If (flag Or (Not (gobjInst.Aaf = aaft)) Or (Not (gobjInst.N2of = n2oft))) Then
            '    btnAAFLAME.Visible = True
            '    btnNAFLAME.Visible = True

            '    flag = False
            '    aaft = gobjInst.Aaf
            '    n2oft = gobjInst.N2of
            '    If gobjInst.Aaf Then
            '        lblStatus.Text = "AA - FLAME"
            '        btnAAFLAME.Text = "EXTINGUISH &AA FLAME"
            '        btnAAFLAME.TextAlign = ContentAlignment.TopLeft

            '        btnNAFLAME.Visible = False
            '    ElseIf gobjInst.N2of Then
            '        lblStatus.Text = "NA - FLAME"
            '        btnNAFLAME.Text = "EXTINGUISH &NA FLAME"
            '        btnNAFLAME.TextAlign = ContentAlignment.TopLeft
            '        btnNAFLAME.Visible = False
            '    Else
            '        lblStatus.Text = "READY FOR IGNITION"
            '        If Not aa Then
            '            btnNAFLAME.Text = "&NA - FLAME"
            '        Else
            '            btnNAFLAME.Visible = False
            '        End If
            '        btnAAFLAME.Text = "&AA - FLAME"
            '    End If
            'End If
            'End If
            Application.DoEvents()
            'End While

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
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
            'objWait.Dispose()
            '---------------------------------------------------------
        End Try

    End Sub

    Private Sub btnAAFLAME_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : btnAAFLAME_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : 
        ' Purpose               : To get the AA Flame
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 07-02-2007
        ' Revisions             : 
        '=====================================================================
        If mblnAvoidPorcess = True Then
            Exit Sub
        End If
        Dim objWait As New CWaitCursor
        Try
            mblnAvoidPorcess = True
            mblnIgnitionWait = True
            mobjclsBgAutoIgnition.IgnitionWait = True
            If gobjInst.Aaf Then

                'gobjInst.Aaf = gobjCommProtocol.func_AA_FLAME_OFF
                If gobjCommProtocol.func_AA_FLAME_OFF() = True Then
                    gobjInst.Aaf = False
                End If
            ElseIf gobjInst.N2of Then
                gobjInst.N2of = gobjCommProtocol.func_N2_FLAME_OFF
            Else
                gobjInst.Aaf = gobjCommProtocol.func_AA_FLAME_ON
            End If
            Beep()
            mblnAvoidPorcess = False
            mblnIgnitionWait = False
            mobjclsBgAutoIgnition.IgnitionWait = False
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
            mblnAvoidPorcess = False
            mblnIgnitionWait = False
            mobjclsBgAutoIgnition.IgnitionWait = False
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

        'if (Inst.Aaf)  
        '   Inst.Aaf=AA_FLAME_OFF();
        'else if (Inst.N2of ) 
        '   Inst.N2of=N2_FLAME_OFF();
        'else	
        '   Inst.Aaf = AA_FLAME_ON();
        'Beep(); break;
    End Sub

    Private Sub btnNAFLAME_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : btnNAFLAME_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : 
        ' Purpose               : To get the NA Flame
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 07-02-2007
        ' Revisions             : 
        '=====================================================================
        If mblnAvoidPorcess = True Then
            Exit Sub
        End If
        Dim objWait As New CWaitCursor
        Try

            mblnAvoidPorcess = True
            mblnIgnitionWait = True
            mobjclsBgAutoIgnition.IgnitionWait = True
            If Not gobjInst.N2of Then
                gobjInst.N2of = gobjCommProtocol.func_N2_FLAME_ON
            Else
                gobjMessageAdapter.ShowMessage(constAlreadyNAFlame)
                'MsgBox("Sorry already in NA FLAME")
            End If
            mblnAvoidPorcess = False
            mblnIgnitionWait = False
            mobjclsBgAutoIgnition.IgnitionWait = False
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
            mblnAvoidPorcess = False
            mblnIgnitionWait = False
            mobjclsBgAutoIgnition.IgnitionWait = False
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
            'objWait.Dispose()
            '---------------------------------------------------------
        End Try

        'if (!Inst.N2of ) 
        '   Inst.N2of=N2_FLAME_ON();
        'else
        '{  if(GetInstrument() == AA202)
        '	    Gerror_message_new("Sorry already in NA Flame", "AA-202 PNEUM");
        '   else
        '	    Gerror_message_new("Sorry already in NA Flame", "AA-203 PNEUM");
        '}
        '	break;
    End Sub

    'Private Sub CommandBarButtonItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    '//----- Commented by Sachin Dokhale
    '    'Call gobjCommProtocol.func_AA_FLAME_ON()
    '    '//----- added by Sachin Dokhale
    '    If gobjInst.Aaf Then
    '        'gobjInst.Aaf = gobjCommProtocol.func_AA_FLAME_OFF
    '        If gobjCommProtocol.func_AA_FLAME_OFF() = True Then
    '            gobjInst.Aaf = False
    '        End If
    '    ElseIf gobjInst.N2of Then
    '        gobjInst.N2of = gobjCommProtocol.func_N2_FLAME_OFF
    '    Else
    '        gobjInst.Aaf = gobjCommProtocol.func_AA_FLAME_ON
    '    End If
    '    '//-----
    'End Sub

    Private Function funcAuto_Init() As Boolean
        '=====================================================================
        ' Procedure Name        : subWorkInBackground
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To init the Auto flame
        '                       : loop and in background.      
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale & Saurabh S 
        ' Created               : 16.02.07
        ' Revisions             : Sachin Dokhale 
        '=====================================================================
        '        void 	S4FUNC Auto_Init(HWND hpar)
        '   {
        '       int     	k; //,i;
        '       BYTE    	data;
        '       HWND 		hwnd,hwnd1;
        '       MSG		msg;
        '       BOOL    	flag=FALSE;
        '       DLGPROC 	skp ;
        '       DWORD		w1,w2;
        '       BOOL 		ato=TRUE,aaft=OFF, n2oft=OFF, posted=FALSE;
        '       HDC 		hdc;

        '       // hwnd1 = Create_Window_Pneum(NULL,"AA-203  AA FLAME");
        '       If (!Commflag) Then
        '	        return;
        '       if(GetInstrument()==AA202)
        '	        hwnd1 = Create_Window_Pneum("AA-202  AA FLAME");
        '       Else
        '	        hwnd1 = Create_Window_Pneum("AA-203  AA FLAME");
        '       StHwnd=hwnd1;
        '       skp = (DLGPROC) MakeProcInstance((FARPROC) ManualProc, hInst);
        '       hwnd = CreateDialog(hInst, "AUTO", NULL, skp);
        '       if (hwnd!=NULL)
        '       {
        '	        EnableWindow(hpar, FALSE);	 	
        '           ShowWindow(hwnd, SW_SHOW);
        '	        UpdateWindow(hwnd); 
        '           WP1=-1;		
        '           hdc = GetDC(hwnd);
        '	        SetBkColor(hdc, RGB(192,192,192));
        '	        aa =  OFF;
        '	        ps1= ps2= ps3 = ON;
        '	        data = CHECK_BUR_PAR();
        '	        if (data & AA_CONNECTED) 
        '               aa = ON;
        '	        else 
        '               aa=OFF;
        '	        data  = CHECK_PS();
        '	        if (data & AIR_NOK)  
        '               ps1 = OFF;
        '	        if (data & N2O_NOK)  
        '               ps2 = OFF;
        '	        if (data & FUEL_NOK) 
        '           {
        '               ato = OFF; 
        '               ps3 = OFF;
        '           }
        '	        if (ps1==OFF) 
        '               ato = OFF;
        '	        if (ps3==OFF) 
        '               ato = OFF;
        '	        if (aa!=ON && ps2==OFF) 
        '               ato = OFF;
        '	        w1 = GetTickCount();
        '	        Auto_Init_Check(&ato);
        '	        while(1)
        '           {
        '		        w2 = GetTickCount();
        '		        if ((w2-w1) > (DWORD) 200)
        '               {
        '		            w1=w2;
        '		            Status_Disp();
        '		        }
        '		        Auto_Init_Check(&ato);
        '               if (!ato)
        '                   if (!posted)
        '                   {
        '                       PostMessage(hwnd, WM_COMMAND, IDOK, 0L);
        '                       posted=TRUE;
        '                   }
        '		        if (flag|| Inst.Aaf!=aaft || Inst.N2of!=n2oft)
        '               {
        '		            ShowWindow(GetDlgItem(hwnd, IDC_BTN2),SW_SHOW);
        '		            ShowWindow(GetDlgItem(hwnd, IDC_BTN2),SW_SHOW);
        '		            flag = FALSE;
        '		            aaft = Inst.Aaf; 
        '                   n2oft=Inst.N2of;
        '		            if (Inst.Aaf) 
        '                   {
        '			            SetWindowText(GetDlgItem(hwnd, IDC_STATUS), "AA -FLAME");
        '			            SetWindowText(GetDlgItem(hwnd, IDC_BTN1), "EXTINGUISH AA");
        '			            ShowWindow(GetDlgItem(hwnd, IDC_BTN2),SW_HIDE);
        '			        }
        '		            else if (Inst.N2of)	
        '                   {
        '			            SetWindowText(GetDlgItem(hwnd, IDC_STATUS), "NA -FLAME");
        '			            SetWindowText(GetDlgItem(hwnd, IDC_BTN1), "EXTINGUISH NA");
        '			            ShowWindow(GetDlgItem(hwnd, IDC_BTN2),SW_HIDE);
        '			        }
        '		            else 
        '                   {
        '			            SetWindowText(GetDlgItem(hwnd, IDC_STATUS), "READY FOR IGNITION");
        '                       if (!aa) 
        '				            SetWindowText(GetDlgItem(hwnd, IDC_BTN2), "NA FLAME");
        '                       else
        '				            ShowWindow(GetDlgItem(hwnd, IDC_BTN2),SW_HIDE);
        '			            SetWindowText(GetDlgItem(hwnd, IDC_BTN1), "AA FLAME");
        '		    	    }
        '			    UpdateWindow(hwnd);
        '		    }
        '           if (CheckMsg(hwnd, &msg))
        '           {
        '		        flag = TRUE;
        '		        switch(WP1)
        '               {
        '			         case  IDC_BTN1:if (Inst.Aaf)  Inst.Aaf=AA_FLAME_OFF();
        '								 else if (Inst.N2of ) Inst.N2of=N2_FLAME_OFF();
        '								 else	Inst.Aaf = AA_FLAME_ON();
        '								 Beep(); break;
        '			 case  IDC_BTN2:	if (!Inst.N2of ) Inst.N2of=N2_FLAME_ON();
        '									else{ if(GetInstrument() == AA202)
        '												Gerror_message_new("Sorry already in NA Flame", "AA-202 PNEUM");
        '											else
        '												Gerror_message_new("Sorry already in NA Flame", "AA-203 PNEUM");}
        '									break;
        '			case IDC_INCRF:  Incr_Fuel();
        '								  Wprintf(hdc, 10, 70, "%3.2f    ", (double)Inst.Nvstep/(double)NVRED);break;
        '			case IDC_DFUEL:  Decr_Fuel();
        '								  Wprintf(hdc, 10, 70, "%3.2f     ", (double)Inst.Nvstep/(double) NVRED); break;
        '			case IDC_INCRH : Incr_Height(); break;
        '			case IDC_DECRH : Decr_Height(); break;
        '			case IDC_FUEL  : if (NV_HOME()) Inst.Nvstep=0;
        '								  else Inst.Nvstep = -1;break;
        '			case IDC_BUR:   if(BH_HOME()) Inst.Bhstep =0;
        '								 else Inst.Bhstep=-1; break;
        '			}
        '		  if (WP1==IDOK){
        '			 WP1=-1;
        '			 for(k=0; k<10;k++)
        '				 CheckMsg(hpar, &msg);
        '			 EnableWindow(hpar, TRUE);
        '			 ReleaseDC(hwnd, hdc);
        '			 DestroyWindow(hwnd);
        '			 UpdateWindow(hpar);
        '			 break;
        '		  }
        '		  WP1=-1;
        '		}
        '	 }
        '  }
        ' FreeProcInstance((FARPROC)skp);
        ' Close_Window(hwnd1, NULL);
        ' StHwnd=NULL;
        '}
        Try

            count = 0
            aa = False
            ps1 = True  ' To check for Air pressure 
            ps2 = True  ' To check for N2O pressure 
            ps3 = True  ' To check for Fuel pressure 

            btnAAFLAME.Visible = True
            btnNAFLAME.Visible = True
            If gobjCommProtocol.funcCheckBurnerParameters(data) = False Then
                Exit Function
            End If
            If (data And EnumErrorStatus.AA_CONNECTED) Then
                aa = True
            Else
                aa = False
            End If

            If gobjCommProtocol.funcPressSensorStatus(data, False) = False Then
                Exit Function
            End If

            If (data And EnumErrorStatus.AIR_NOK) Then
                ps1 = False
            End If
            If (data And EnumErrorStatus.N2O_NOK) Then
                ps2 = False
            End If
            If (data And EnumErrorStatus.FUEL_NOK) Then
                ato = False
                ps3 = False
            End If

            If (ps1 = False) Then
                ato = False
            End If

            If (ps3 = False) Then
                ato = False
            End If

            If (Not aa = True And ps2 = False) Then
                ato = False
            End If

            If Auto_Init_Check(ato) = False Then
                Exit Function
            End If

            'mobjThread = New Threading.Thread(AddressOf subWorkInBackground)
            'mobjThread.IsBackground = True
            'mobjThread.Start()
            mobjController = New clsBgThread(Me)
            mobjclsBgAutoIgnition = New ClsBgManualIgnition
            gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay)   '10.12.07
            Application.DoEvents()
            mobjController.Start(mobjclsBgAutoIgnition)
            AddHandler mobjclsBgAutoIgnition.ManualIgnition, AddressOf subWaitManualThread

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
            'objWait.Dispose()
            '---------------------------------------------------------
        End Try
    End Function

    Private Sub subWaitManualThread(ByRef IsContinue As Boolean)
        '=====================================================================
        ' Procedure Name        : subWaitManualThread
        ' Parameters Passed     : Boolean
        ' Returns               : 
        ' Purpose               : 
        ' Description           : To Get Thread Event
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 
        ' Revisions             : 
        '=====================================================================
        Try
            If mblnIgnitionWait = False Then
                Call subWorkInBackground()
            End If

            If mblnIgnitionWait = False Then
                'intFlameType = gobjClsAAS203.funcIgnite_Test()
                'gobjfrmStatus.FlameType = intFlameType
                '--- Modified function of funcIgnite_Test by Sachin Dokhale on 04.02.07
                'intEnumIgiteType = gobjClsAAS203.funcIgnite_Test()
                Dim intIgnite_Test As ClsAAS203.enumIgniteType
                If gobjClsAAS203.funcIgnite_Test(intIgnite_Test) Then
                    intFlameType = intIgnite_Test
                    gobjfrmStatus.FlameType = intFlameType
                End If
                '---
            End If
            'End If

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
            mblnIgnitionTerminate = True
            mblnIgnitionWait = True
            btnClose_Click(btnClose, System.EventArgs.Empty)
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
            mblnIgnitionTerminate = True
            mblnIgnitionWait = True
            btnClose_Click(btnClose, System.EventArgs.Empty)
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

    Private Sub frmAutoIgnition_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
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
        Try
            If mblnIgnitionTerminate = False Then
                If Not (mobjController Is Nothing) Then
                    If mobjController.IsThreadRunning Then
                        mobjclsBgAutoIgnition.ThTerminate = True
                        mobjclsBgAutoIgnition.IgnitionWait = True
                        mblnIgnitionWait = True
                        e.Cancel = True
                        Application.DoEvents()
                        'Call btnClose_Click(sender, e)
                        Exit Sub
                    End If
                End If
            Else
                If Not (mobjController Is Nothing) Then
                    If mobjController.IsThreadRunning Then
                        mobjclsBgAutoIgnition.ThTerminate = True
                        mobjclsBgAutoIgnition.IgnitionWait = True
                        mblnIgnitionWait = True
                        mobjController.Cancel()
                    End If
                End If
            End If
            If gobjCommProtocol.func_IGNITE_OFF() Then
            End If
            If mblnIsfrmFlameStatusWork = True Then
                If Not IsNothing(gobjMain) Then
                    'If Not IsNothing(gobjMain.mobjfrmAnalysis) Then gobjMain.mobjfrmAnalysis.tmrAspirationMsg.Enabled = False
                    If gobjMain.mobjController.IsThreadRunning = False Then
                        gobjMain.mobjController.Start(gobjclsBgFlameStatus)
                    End If
                    mblnIsfrmFlameStatusWork = False
                    Application.DoEvents()
                End If
            End If
            Application.DoEvents()
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

    Private Sub frmAutoIgnition_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated

    End Sub
End Class
