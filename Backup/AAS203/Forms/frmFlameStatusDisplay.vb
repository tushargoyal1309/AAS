Public Class frmFlameStatusDisplay

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
    Friend WithEvents custpnlStatusDisplay As GradientPanel.CustomPanel
    Friend WithEvents lblFlameType As System.Windows.Forms.Label
    Friend WithEvents lblSafetyControlsTrap As System.Windows.Forms.Label
    Friend WithEvents lblSafetyControlsDoor As System.Windows.Forms.Label
    Friend WithEvents lblBurnerType As System.Windows.Forms.Label
    Friend WithEvents lblStatusFuel As System.Windows.Forms.Label
    Friend WithEvents lblStatusN2O As System.Windows.Forms.Label
    Friend WithEvents lblStatusAir As System.Windows.Forms.Label
    Friend WithEvents lblPressureFuel As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblPressureAir As System.Windows.Forms.Label
    Friend WithEvents lblFlame As System.Windows.Forms.Label
    Friend WithEvents lblSafetyControls As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblBurner As System.Windows.Forms.Label
    Friend WithEvents lblPressureValveStatus As System.Windows.Forms.Label
    Friend WithEvents pbFlameType As System.Windows.Forms.Label
    Friend WithEvents pbSafetyControlsDoor As System.Windows.Forms.Label
    Friend WithEvents pbBurnerType As System.Windows.Forms.Label
    Friend WithEvents pbStatusFuel As System.Windows.Forms.Label
    Friend WithEvents pbStatusN2O As System.Windows.Forms.Label
    Friend WithEvents pbStatusAir As System.Windows.Forms.Label
    Friend WithEvents pbPressureFuel As System.Windows.Forms.Label
    Friend WithEvents pbPressureN2O As System.Windows.Forms.Label
    Friend WithEvents pbPressureAir As System.Windows.Forms.Label
    Friend WithEvents lblPressures As System.Windows.Forms.Label
    Friend WithEvents lblBHeight As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblFRatio As System.Windows.Forms.Label
    Friend WithEvents lblPressureN2O As System.Windows.Forms.Label
    Friend WithEvents lblBurnerHeight As System.Windows.Forms.Label
    Friend WithEvents pbSafetyControlsTrap As System.Windows.Forms.PictureBox
    Friend WithEvents lblFlameRatio As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmFlameStatusDisplay))
        Me.custpnlStatusDisplay = New GradientPanel.CustomPanel
        Me.lblFlameType = New System.Windows.Forms.Label
        Me.lblSafetyControlsTrap = New System.Windows.Forms.Label
        Me.lblSafetyControlsDoor = New System.Windows.Forms.Label
        Me.lblBurnerType = New System.Windows.Forms.Label
        Me.lblStatusFuel = New System.Windows.Forms.Label
        Me.lblStatusN2O = New System.Windows.Forms.Label
        Me.lblStatusAir = New System.Windows.Forms.Label
        Me.lblPressureFuel = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.lblPressureAir = New System.Windows.Forms.Label
        Me.lblFlame = New System.Windows.Forms.Label
        Me.lblSafetyControls = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblBurner = New System.Windows.Forms.Label
        Me.lblPressureValveStatus = New System.Windows.Forms.Label
        Me.pbFlameType = New System.Windows.Forms.Label
        Me.pbSafetyControlsDoor = New System.Windows.Forms.Label
        Me.pbBurnerType = New System.Windows.Forms.Label
        Me.pbStatusFuel = New System.Windows.Forms.Label
        Me.pbStatusN2O = New System.Windows.Forms.Label
        Me.pbStatusAir = New System.Windows.Forms.Label
        Me.pbPressureFuel = New System.Windows.Forms.Label
        Me.pbPressureN2O = New System.Windows.Forms.Label
        Me.pbPressureAir = New System.Windows.Forms.Label
        Me.lblPressures = New System.Windows.Forms.Label
        Me.lblBHeight = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.lblFRatio = New System.Windows.Forms.Label
        Me.lblPressureN2O = New System.Windows.Forms.Label
        Me.lblBurnerHeight = New System.Windows.Forms.Label
        Me.pbSafetyControlsTrap = New System.Windows.Forms.PictureBox
        Me.lblFlameRatio = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.custpnlStatusDisplay.SuspendLayout()
        Me.SuspendLayout()
        '
        'custpnlStatusDisplay
        '
        Me.custpnlStatusDisplay.BackColor = System.Drawing.Color.AliceBlue
        Me.custpnlStatusDisplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.custpnlStatusDisplay.Controls.Add(Me.lblFlameType)
        Me.custpnlStatusDisplay.Controls.Add(Me.lblSafetyControlsTrap)
        Me.custpnlStatusDisplay.Controls.Add(Me.lblSafetyControlsDoor)
        Me.custpnlStatusDisplay.Controls.Add(Me.lblBurnerType)
        Me.custpnlStatusDisplay.Controls.Add(Me.lblStatusFuel)
        Me.custpnlStatusDisplay.Controls.Add(Me.lblStatusN2O)
        Me.custpnlStatusDisplay.Controls.Add(Me.lblStatusAir)
        Me.custpnlStatusDisplay.Controls.Add(Me.lblPressureFuel)
        Me.custpnlStatusDisplay.Controls.Add(Me.Label7)
        Me.custpnlStatusDisplay.Controls.Add(Me.lblPressureAir)
        Me.custpnlStatusDisplay.Controls.Add(Me.lblFlame)
        Me.custpnlStatusDisplay.Controls.Add(Me.lblSafetyControls)
        Me.custpnlStatusDisplay.Controls.Add(Me.Label5)
        Me.custpnlStatusDisplay.Controls.Add(Me.Label3)
        Me.custpnlStatusDisplay.Controls.Add(Me.Label1)
        Me.custpnlStatusDisplay.Controls.Add(Me.lblBurner)
        Me.custpnlStatusDisplay.Controls.Add(Me.lblPressureValveStatus)
        Me.custpnlStatusDisplay.Controls.Add(Me.pbFlameType)
        Me.custpnlStatusDisplay.Controls.Add(Me.pbSafetyControlsDoor)
        Me.custpnlStatusDisplay.Controls.Add(Me.pbBurnerType)
        Me.custpnlStatusDisplay.Controls.Add(Me.pbStatusFuel)
        Me.custpnlStatusDisplay.Controls.Add(Me.pbStatusN2O)
        Me.custpnlStatusDisplay.Controls.Add(Me.pbStatusAir)
        Me.custpnlStatusDisplay.Controls.Add(Me.pbPressureFuel)
        Me.custpnlStatusDisplay.Controls.Add(Me.pbPressureN2O)
        Me.custpnlStatusDisplay.Controls.Add(Me.pbPressureAir)
        Me.custpnlStatusDisplay.Controls.Add(Me.lblPressures)
        Me.custpnlStatusDisplay.Controls.Add(Me.lblBHeight)
        Me.custpnlStatusDisplay.Controls.Add(Me.Label6)
        Me.custpnlStatusDisplay.Controls.Add(Me.lblFRatio)
        Me.custpnlStatusDisplay.Controls.Add(Me.lblPressureN2O)
        Me.custpnlStatusDisplay.Controls.Add(Me.lblBurnerHeight)
        Me.custpnlStatusDisplay.Controls.Add(Me.pbSafetyControlsTrap)
        Me.custpnlStatusDisplay.Controls.Add(Me.lblFlameRatio)
        Me.custpnlStatusDisplay.Controls.Add(Me.Label2)
        Me.custpnlStatusDisplay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.custpnlStatusDisplay.Location = New System.Drawing.Point(0, 0)
        Me.custpnlStatusDisplay.Name = "custpnlStatusDisplay"
        Me.custpnlStatusDisplay.Size = New System.Drawing.Size(590, 119)
        Me.custpnlStatusDisplay.TabIndex = 79
        '
        'lblFlameType
        '
        Me.lblFlameType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFlameType.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFlameType.Location = New System.Drawing.Point(489, 54)
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
        Me.lblSafetyControlsTrap.Location = New System.Drawing.Point(441, 54)
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
        Me.lblSafetyControlsDoor.Location = New System.Drawing.Point(392, 54)
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
        Me.lblBurnerType.Location = New System.Drawing.Point(281, 54)
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
        Me.lblStatusFuel.Location = New System.Drawing.Point(233, 54)
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
        Me.lblStatusN2O.Location = New System.Drawing.Point(188, 54)
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
        Me.lblStatusAir.Location = New System.Drawing.Point(143, 54)
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
        Me.lblPressureFuel.Location = New System.Drawing.Point(95, 54)
        Me.lblPressureFuel.Name = "lblPressureFuel"
        Me.lblPressureFuel.Size = New System.Drawing.Size(44, 24)
        Me.lblPressureFuel.TabIndex = 16
        Me.lblPressureFuel.Text = "FUEL"
        Me.lblPressureFuel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.Control
        Me.Label7.Location = New System.Drawing.Point(389, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(2, 116)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Label7"
        '
        'lblPressureAir
        '
        Me.lblPressureAir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPressureAir.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPressureAir.Location = New System.Drawing.Point(5, 54)
        Me.lblPressureAir.Name = "lblPressureAir"
        Me.lblPressureAir.Size = New System.Drawing.Size(44, 24)
        Me.lblPressureAir.TabIndex = 14
        Me.lblPressureAir.Text = "AIR"
        Me.lblPressureAir.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblFlame
        '
        Me.lblFlame.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFlame.Location = New System.Drawing.Point(496, 8)
        Me.lblFlame.Name = "lblFlame"
        Me.lblFlame.Size = New System.Drawing.Size(92, 32)
        Me.lblFlame.TabIndex = 11
        Me.lblFlame.Text = "FLAME"
        Me.lblFlame.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'lblSafetyControls
        '
        Me.lblSafetyControls.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSafetyControls.Location = New System.Drawing.Point(399, 8)
        Me.lblSafetyControls.Name = "lblSafetyControls"
        Me.lblSafetyControls.Size = New System.Drawing.Size(84, 32)
        Me.lblSafetyControls.TabIndex = 10
        Me.lblSafetyControls.Text = "SAFETY CONTROLS"
        Me.lblSafetyControls.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Location = New System.Drawing.Point(278, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(2, 116)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Label5"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Location = New System.Drawing.Point(140, 0)
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
        Me.lblPressureValveStatus.Location = New System.Drawing.Point(156, 8)
        Me.lblPressureValveStatus.Name = "lblPressureValveStatus"
        Me.lblPressureValveStatus.Size = New System.Drawing.Size(110, 32)
        Me.lblPressureValveStatus.TabIndex = 8
        Me.lblPressureValveStatus.Text = "PRESSURE VALVE STATUS"
        Me.lblPressureValveStatus.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'pbFlameType
        '
        Me.pbFlameType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbFlameType.Image = CType(resources.GetObject("pbFlameType.Image"), System.Drawing.Image)
        Me.pbFlameType.Location = New System.Drawing.Point(495, 80)
        Me.pbFlameType.Name = "pbFlameType"
        Me.pbFlameType.Size = New System.Drawing.Size(32, 32)
        Me.pbFlameType.TabIndex = 77
        '
        'pbSafetyControlsDoor
        '
        Me.pbSafetyControlsDoor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbSafetyControlsDoor.Image = CType(resources.GetObject("pbSafetyControlsDoor.Image"), System.Drawing.Image)
        Me.pbSafetyControlsDoor.Location = New System.Drawing.Point(400, 80)
        Me.pbSafetyControlsDoor.Name = "pbSafetyControlsDoor"
        Me.pbSafetyControlsDoor.Size = New System.Drawing.Size(32, 32)
        Me.pbSafetyControlsDoor.TabIndex = 76
        '
        'pbBurnerType
        '
        Me.pbBurnerType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbBurnerType.Image = CType(resources.GetObject("pbBurnerType.Image"), System.Drawing.Image)
        Me.pbBurnerType.Location = New System.Drawing.Point(287, 80)
        Me.pbBurnerType.Name = "pbBurnerType"
        Me.pbBurnerType.Size = New System.Drawing.Size(32, 32)
        Me.pbBurnerType.TabIndex = 75
        '
        'pbStatusFuel
        '
        Me.pbStatusFuel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbStatusFuel.Image = CType(resources.GetObject("pbStatusFuel.Image"), System.Drawing.Image)
        Me.pbStatusFuel.Location = New System.Drawing.Point(239, 80)
        Me.pbStatusFuel.Name = "pbStatusFuel"
        Me.pbStatusFuel.Size = New System.Drawing.Size(32, 32)
        Me.pbStatusFuel.TabIndex = 74
        '
        'pbStatusN2O
        '
        Me.pbStatusN2O.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbStatusN2O.Image = CType(resources.GetObject("pbStatusN2O.Image"), System.Drawing.Image)
        Me.pbStatusN2O.Location = New System.Drawing.Point(194, 80)
        Me.pbStatusN2O.Name = "pbStatusN2O"
        Me.pbStatusN2O.Size = New System.Drawing.Size(32, 32)
        Me.pbStatusN2O.TabIndex = 73
        '
        'pbStatusAir
        '
        Me.pbStatusAir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbStatusAir.Image = CType(resources.GetObject("pbStatusAir.Image"), System.Drawing.Image)
        Me.pbStatusAir.Location = New System.Drawing.Point(149, 80)
        Me.pbStatusAir.Name = "pbStatusAir"
        Me.pbStatusAir.Size = New System.Drawing.Size(32, 32)
        Me.pbStatusAir.TabIndex = 72
        '
        'pbPressureFuel
        '
        Me.pbPressureFuel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbPressureFuel.Image = CType(resources.GetObject("pbPressureFuel.Image"), System.Drawing.Image)
        Me.pbPressureFuel.Location = New System.Drawing.Point(101, 80)
        Me.pbPressureFuel.Name = "pbPressureFuel"
        Me.pbPressureFuel.Size = New System.Drawing.Size(32, 32)
        Me.pbPressureFuel.TabIndex = 71
        '
        'pbPressureN2O
        '
        Me.pbPressureN2O.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbPressureN2O.Image = CType(resources.GetObject("pbPressureN2O.Image"), System.Drawing.Image)
        Me.pbPressureN2O.Location = New System.Drawing.Point(55, 80)
        Me.pbPressureN2O.Name = "pbPressureN2O"
        Me.pbPressureN2O.Size = New System.Drawing.Size(32, 32)
        Me.pbPressureN2O.TabIndex = 70
        '
        'pbPressureAir
        '
        Me.pbPressureAir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbPressureAir.Image = CType(resources.GetObject("pbPressureAir.Image"), System.Drawing.Image)
        Me.pbPressureAir.Location = New System.Drawing.Point(11, 80)
        Me.pbPressureAir.Name = "pbPressureAir"
        Me.pbPressureAir.Size = New System.Drawing.Size(32, 32)
        Me.pbPressureAir.TabIndex = 69
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
        'lblBHeight
        '
        Me.lblBHeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBHeight.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBHeight.Location = New System.Drawing.Point(326, 80)
        Me.lblBHeight.Name = "lblBHeight"
        Me.lblBHeight.Size = New System.Drawing.Size(62, 32)
        Me.lblBHeight.TabIndex = 65
        Me.lblBHeight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.Control
        Me.Label6.Location = New System.Drawing.Point(486, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(2, 116)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Label6"
        '
        'lblFRatio
        '
        Me.lblFRatio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFRatio.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFRatio.Location = New System.Drawing.Point(535, 80)
        Me.lblFRatio.Name = "lblFRatio"
        Me.lblFRatio.Size = New System.Drawing.Size(52, 32)
        Me.lblFRatio.TabIndex = 64
        Me.lblFRatio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblPressureN2O
        '
        Me.lblPressureN2O.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPressureN2O.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPressureN2O.Location = New System.Drawing.Point(50, 54)
        Me.lblPressureN2O.Name = "lblPressureN2O"
        Me.lblPressureN2O.Size = New System.Drawing.Size(44, 24)
        Me.lblPressureN2O.TabIndex = 15
        Me.lblPressureN2O.Text = "N2O"
        Me.lblPressureN2O.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblBurnerHeight
        '
        Me.lblBurnerHeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBurnerHeight.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBurnerHeight.Location = New System.Drawing.Point(326, 54)
        Me.lblBurnerHeight.Name = "lblBurnerHeight"
        Me.lblBurnerHeight.Size = New System.Drawing.Size(62, 24)
        Me.lblBurnerHeight.TabIndex = 38
        Me.lblBurnerHeight.Text = "HEIGHT"
        Me.lblBurnerHeight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pbSafetyControlsTrap
        '
        Me.pbSafetyControlsTrap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbSafetyControlsTrap.Image = CType(resources.GetObject("pbSafetyControlsTrap.Image"), System.Drawing.Image)
        Me.pbSafetyControlsTrap.Location = New System.Drawing.Point(447, 80)
        Me.pbSafetyControlsTrap.Name = "pbSafetyControlsTrap"
        Me.pbSafetyControlsTrap.Size = New System.Drawing.Size(32, 32)
        Me.pbSafetyControlsTrap.TabIndex = 34
        Me.pbSafetyControlsTrap.TabStop = False
        '
        'lblFlameRatio
        '
        Me.lblFlameRatio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFlameRatio.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFlameRatio.Location = New System.Drawing.Point(535, 54)
        Me.lblFlameRatio.Name = "lblFlameRatio"
        Me.lblFlameRatio.Size = New System.Drawing.Size(52, 24)
        Me.lblFlameRatio.TabIndex = 24
        Me.lblFlameRatio.Text = "RATIO"
        Me.lblFlameRatio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Location = New System.Drawing.Point(0, 115)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(759, 2)
        Me.Label2.TabIndex = 40
        '
        'frmFlameStatusDisplay
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(590, 119)
        Me.ControlBox = False
        Me.Controls.Add(Me.custpnlStatusDisplay)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmFlameStatusDisplay"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Flame Status Display"
        Me.custpnlStatusDisplay.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

End Class
