Public Class frmAAS_203AAFlame
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
    Friend WithEvents pbFlameRatio As System.Windows.Forms.PictureBox
    Friend WithEvents pbFlameType As System.Windows.Forms.PictureBox
    Friend WithEvents pbSafetyControlsTrap As System.Windows.Forms.PictureBox
    Friend WithEvents pbSafetyControlsDoor As System.Windows.Forms.PictureBox
    Friend WithEvents pbBurnerType As System.Windows.Forms.PictureBox
    Friend WithEvents pbStatusFuel As System.Windows.Forms.PictureBox
    Friend WithEvents pbStatusN2O As System.Windows.Forms.PictureBox
    Friend WithEvents pbPressureFuel As System.Windows.Forms.PictureBox
    Friend WithEvents pbPressureN2O As System.Windows.Forms.PictureBox
    Friend WithEvents pbPressureAir As System.Windows.Forms.PictureBox
    Friend WithEvents pbStatusAir As System.Windows.Forms.PictureBox
    Friend WithEvents pbBurnerHeight As System.Windows.Forms.PictureBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.CustomPanel1 = New GradientPanel.CustomPanel
        Me.pbFlameRatio = New System.Windows.Forms.PictureBox
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
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.pbBurnerHeight = New System.Windows.Forms.PictureBox
        Me.lblBurnerHeight = New System.Windows.Forms.Label
        Me.CustomPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'CustomPanel1
        '
        Me.CustomPanel1.BackColor = System.Drawing.Color.AliceBlue
        Me.CustomPanel1.Controls.Add(Me.pbBurnerHeight)
        Me.CustomPanel1.Controls.Add(Me.lblBurnerHeight)
        Me.CustomPanel1.Controls.Add(Me.pbFlameRatio)
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
        Me.CustomPanel1.Controls.Add(Me.Label3)
        Me.CustomPanel1.Controls.Add(Me.Label1)
        Me.CustomPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CustomPanel1.Location = New System.Drawing.Point(0, 0)
        Me.CustomPanel1.Name = "CustomPanel1"
        Me.CustomPanel1.Size = New System.Drawing.Size(634, 101)
        Me.CustomPanel1.TabIndex = 0
        '
        'pbFlameRatio
        '
        Me.pbFlameRatio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbFlameRatio.Location = New System.Drawing.Point(575, 74)
        Me.pbFlameRatio.Name = "pbFlameRatio"
        Me.pbFlameRatio.Size = New System.Drawing.Size(56, 24)
        Me.pbFlameRatio.TabIndex = 36
        Me.pbFlameRatio.TabStop = False
        '
        'pbFlameType
        '
        Me.pbFlameType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbFlameType.Location = New System.Drawing.Point(525, 74)
        Me.pbFlameType.Name = "pbFlameType"
        Me.pbFlameType.Size = New System.Drawing.Size(48, 24)
        Me.pbFlameType.TabIndex = 35
        Me.pbFlameType.TabStop = False
        '
        'pbSafetyControlsTrap
        '
        Me.pbSafetyControlsTrap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbSafetyControlsTrap.Location = New System.Drawing.Point(471, 74)
        Me.pbSafetyControlsTrap.Name = "pbSafetyControlsTrap"
        Me.pbSafetyControlsTrap.Size = New System.Drawing.Size(48, 24)
        Me.pbSafetyControlsTrap.TabIndex = 34
        Me.pbSafetyControlsTrap.TabStop = False
        '
        'pbSafetyControlsDoor
        '
        Me.pbSafetyControlsDoor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbSafetyControlsDoor.Location = New System.Drawing.Point(416, 74)
        Me.pbSafetyControlsDoor.Name = "pbSafetyControlsDoor"
        Me.pbSafetyControlsDoor.Size = New System.Drawing.Size(53, 24)
        Me.pbSafetyControlsDoor.TabIndex = 33
        Me.pbSafetyControlsDoor.TabStop = False
        '
        'pbBurnerType
        '
        Me.pbBurnerType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbBurnerType.Location = New System.Drawing.Point(266, 74)
        Me.pbBurnerType.Name = "pbBurnerType"
        Me.pbBurnerType.Size = New System.Drawing.Size(75, 24)
        Me.pbBurnerType.TabIndex = 32
        Me.pbBurnerType.TabStop = False
        '
        'pbStatusFuel
        '
        Me.pbStatusFuel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbStatusFuel.Location = New System.Drawing.Point(211, 74)
        Me.pbStatusFuel.Name = "pbStatusFuel"
        Me.pbStatusFuel.Size = New System.Drawing.Size(37, 24)
        Me.pbStatusFuel.TabIndex = 31
        Me.pbStatusFuel.TabStop = False
        '
        'pbStatusN2O
        '
        Me.pbStatusN2O.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbStatusN2O.Location = New System.Drawing.Point(173, 74)
        Me.pbStatusN2O.Name = "pbStatusN2O"
        Me.pbStatusN2O.Size = New System.Drawing.Size(37, 24)
        Me.pbStatusN2O.TabIndex = 30
        Me.pbStatusN2O.TabStop = False
        '
        'pbPressureFuel
        '
        Me.pbPressureFuel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbPressureFuel.Location = New System.Drawing.Point(79, 74)
        Me.pbPressureFuel.Name = "pbPressureFuel"
        Me.pbPressureFuel.Size = New System.Drawing.Size(37, 24)
        Me.pbPressureFuel.TabIndex = 29
        Me.pbPressureFuel.TabStop = False
        '
        'pbPressureN2O
        '
        Me.pbPressureN2O.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbPressureN2O.Location = New System.Drawing.Point(41, 74)
        Me.pbPressureN2O.Name = "pbPressureN2O"
        Me.pbPressureN2O.Size = New System.Drawing.Size(37, 24)
        Me.pbPressureN2O.TabIndex = 28
        Me.pbPressureN2O.TabStop = False
        '
        'pbPressureAir
        '
        Me.pbPressureAir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbPressureAir.Location = New System.Drawing.Point(3, 74)
        Me.pbPressureAir.Name = "pbPressureAir"
        Me.pbPressureAir.Size = New System.Drawing.Size(37, 24)
        Me.pbPressureAir.TabIndex = 27
        Me.pbPressureAir.TabStop = False
        '
        'pbStatusAir
        '
        Me.pbStatusAir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbStatusAir.Location = New System.Drawing.Point(135, 74)
        Me.pbStatusAir.Name = "pbStatusAir"
        Me.pbStatusAir.Size = New System.Drawing.Size(37, 24)
        Me.pbStatusAir.TabIndex = 26
        Me.pbStatusAir.TabStop = False
        '
        'lblFlameRatio
        '
        Me.lblFlameRatio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFlameRatio.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFlameRatio.Location = New System.Drawing.Point(575, 49)
        Me.lblFlameRatio.Name = "lblFlameRatio"
        Me.lblFlameRatio.Size = New System.Drawing.Size(56, 24)
        Me.lblFlameRatio.TabIndex = 24
        Me.lblFlameRatio.Text = "RATIO"
        Me.lblFlameRatio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblFlameType
        '
        Me.lblFlameType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFlameType.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFlameType.Location = New System.Drawing.Point(525, 49)
        Me.lblFlameType.Name = "lblFlameType"
        Me.lblFlameType.Size = New System.Drawing.Size(48, 24)
        Me.lblFlameType.TabIndex = 23
        Me.lblFlameType.Text = "TYPE"
        Me.lblFlameType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblSafetyControlsTrap
        '
        Me.lblSafetyControlsTrap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSafetyControlsTrap.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSafetyControlsTrap.Location = New System.Drawing.Point(471, 49)
        Me.lblSafetyControlsTrap.Name = "lblSafetyControlsTrap"
        Me.lblSafetyControlsTrap.Size = New System.Drawing.Size(48, 24)
        Me.lblSafetyControlsTrap.TabIndex = 22
        Me.lblSafetyControlsTrap.Text = "TRAP"
        Me.lblSafetyControlsTrap.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblSafetyControlsDoor
        '
        Me.lblSafetyControlsDoor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSafetyControlsDoor.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSafetyControlsDoor.Location = New System.Drawing.Point(416, 49)
        Me.lblSafetyControlsDoor.Name = "lblSafetyControlsDoor"
        Me.lblSafetyControlsDoor.Size = New System.Drawing.Size(53, 24)
        Me.lblSafetyControlsDoor.TabIndex = 21
        Me.lblSafetyControlsDoor.Text = "DOOR"
        Me.lblSafetyControlsDoor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblBurnerType
        '
        Me.lblBurnerType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBurnerType.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBurnerType.Location = New System.Drawing.Point(266, 49)
        Me.lblBurnerType.Name = "lblBurnerType"
        Me.lblBurnerType.Size = New System.Drawing.Size(75, 24)
        Me.lblBurnerType.TabIndex = 20
        Me.lblBurnerType.Text = "TYPE"
        Me.lblBurnerType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblStatusFuel
        '
        Me.lblStatusFuel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStatusFuel.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatusFuel.Location = New System.Drawing.Point(211, 49)
        Me.lblStatusFuel.Name = "lblStatusFuel"
        Me.lblStatusFuel.Size = New System.Drawing.Size(48, 24)
        Me.lblStatusFuel.TabIndex = 19
        Me.lblStatusFuel.Text = "FUEL"
        Me.lblStatusFuel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblStatusN2O
        '
        Me.lblStatusN2O.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStatusN2O.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatusN2O.Location = New System.Drawing.Point(173, 49)
        Me.lblStatusN2O.Name = "lblStatusN2O"
        Me.lblStatusN2O.Size = New System.Drawing.Size(37, 24)
        Me.lblStatusN2O.TabIndex = 18
        Me.lblStatusN2O.Text = "N2O"
        Me.lblStatusN2O.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblStatusAir
        '
        Me.lblStatusAir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStatusAir.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatusAir.Location = New System.Drawing.Point(135, 49)
        Me.lblStatusAir.Name = "lblStatusAir"
        Me.lblStatusAir.Size = New System.Drawing.Size(37, 24)
        Me.lblStatusAir.TabIndex = 17
        Me.lblStatusAir.Text = "AIR"
        Me.lblStatusAir.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblPressureFuel
        '
        Me.lblPressureFuel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPressureFuel.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPressureFuel.Location = New System.Drawing.Point(79, 49)
        Me.lblPressureFuel.Name = "lblPressureFuel"
        Me.lblPressureFuel.Size = New System.Drawing.Size(48, 24)
        Me.lblPressureFuel.TabIndex = 16
        Me.lblPressureFuel.Text = "FUEL"
        Me.lblPressureFuel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblPressureN2O
        '
        Me.lblPressureN2O.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPressureN2O.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPressureN2O.Location = New System.Drawing.Point(41, 49)
        Me.lblPressureN2O.Name = "lblPressureN2O"
        Me.lblPressureN2O.Size = New System.Drawing.Size(37, 24)
        Me.lblPressureN2O.TabIndex = 15
        Me.lblPressureN2O.Text = "N2O"
        Me.lblPressureN2O.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblPressureAir
        '
        Me.lblPressureAir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPressureAir.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPressureAir.Location = New System.Drawing.Point(3, 49)
        Me.lblPressureAir.Name = "lblPressureAir"
        Me.lblPressureAir.Size = New System.Drawing.Size(37, 24)
        Me.lblPressureAir.TabIndex = 14
        Me.lblPressureAir.Text = "AIR"
        Me.lblPressureAir.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblFlame
        '
        Me.lblFlame.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFlame.Location = New System.Drawing.Point(525, 8)
        Me.lblFlame.Name = "lblFlame"
        Me.lblFlame.Size = New System.Drawing.Size(104, 32)
        Me.lblFlame.TabIndex = 11
        Me.lblFlame.Text = "FLAME"
        Me.lblFlame.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'lblSafetyControls
        '
        Me.lblSafetyControls.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSafetyControls.Location = New System.Drawing.Point(426, 8)
        Me.lblSafetyControls.Name = "lblSafetyControls"
        Me.lblSafetyControls.Size = New System.Drawing.Size(84, 32)
        Me.lblSafetyControls.TabIndex = 10
        Me.lblSafetyControls.Text = "SAFETY CONTROLS"
        Me.lblSafetyControls.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'lblBurner
        '
        Me.lblBurner.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBurner.Location = New System.Drawing.Point(271, 8)
        Me.lblBurner.Name = "lblBurner"
        Me.lblBurner.Size = New System.Drawing.Size(135, 32)
        Me.lblBurner.TabIndex = 9
        Me.lblBurner.Text = "BURNER"
        Me.lblBurner.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'lblPressureValveStatus
        '
        Me.lblPressureValveStatus.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPressureValveStatus.Location = New System.Drawing.Point(145, 8)
        Me.lblPressureValveStatus.Name = "lblPressureValveStatus"
        Me.lblPressureValveStatus.Size = New System.Drawing.Size(104, 32)
        Me.lblPressureValveStatus.TabIndex = 8
        Me.lblPressureValveStatus.Text = "PRESSURE VALVE STATUS"
        Me.lblPressureValveStatus.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'lblPressures
        '
        Me.lblPressures.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPressures.Location = New System.Drawing.Point(11, 8)
        Me.lblPressures.Name = "lblPressures"
        Me.lblPressures.Size = New System.Drawing.Size(110, 32)
        Me.lblPressures.TabIndex = 7
        Me.lblPressures.Text = "PRESSURES"
        Me.lblPressures.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.Control
        Me.Label7.Location = New System.Drawing.Point(412, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(2, 120)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Label7"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.Control
        Me.Label6.Location = New System.Drawing.Point(521, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(2, 120)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Label6"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Location = New System.Drawing.Point(262, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(2, 120)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Label5"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Location = New System.Drawing.Point(130, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(2, 120)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Label3"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Location = New System.Drawing.Point(1, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(700, 2)
        Me.Label1.TabIndex = 0
        '
        'pbBurnerHeight
        '
        Me.pbBurnerHeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbBurnerHeight.Location = New System.Drawing.Point(343, 74)
        Me.pbBurnerHeight.Name = "pbBurnerHeight"
        Me.pbBurnerHeight.Size = New System.Drawing.Size(66, 24)
        Me.pbBurnerHeight.TabIndex = 39
        Me.pbBurnerHeight.TabStop = False
        '
        'lblBurnerHeight
        '
        Me.lblBurnerHeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBurnerHeight.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBurnerHeight.Location = New System.Drawing.Point(343, 49)
        Me.lblBurnerHeight.Name = "lblBurnerHeight"
        Me.lblBurnerHeight.Size = New System.Drawing.Size(66, 24)
        Me.lblBurnerHeight.TabIndex = 38
        Me.lblBurnerHeight.Text = "HEIGHT"
        Me.lblBurnerHeight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmAAS_203AAFlame
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(634, 101)
        Me.ControlBox = False
        Me.Controls.Add(Me.CustomPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmAAS_203AAFlame"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AAS-203 AA Flame"
        Me.CustomPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

End Class
