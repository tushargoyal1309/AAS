Public Class Test111
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
    Friend WithEvents CustomPanelTop As GradientPanel.CustomPanel
    Friend WithEvents lblYValue As System.Windows.Forms.Label
    Friend WithEvents lblWvPos As System.Windows.Forms.Label
    Friend WithEvents cmdChangeScale As NETXP.Controls.XPButton
    Friend WithEvents lblSlitWidthnm As System.Windows.Forms.Label
    Friend WithEvents lblPMTVolts As System.Windows.Forms.Label
    Friend WithEvents lblD2CurmA As System.Windows.Forms.Label
    Friend WithEvents cmbModes As System.Windows.Forms.ComboBox
    Friend WithEvents lblModes As System.Windows.Forms.Label
    Friend WithEvents lblSpeed As System.Windows.Forms.Label
    Friend WithEvents cmbSpeed As System.Windows.Forms.ComboBox
    Friend WithEvents lblSlitWidth As System.Windows.Forms.Label
    Friend WithEvents nudSlit As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudD2Cur As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblD2Cur As System.Windows.Forms.Label
    Friend WithEvents lblPMT As System.Windows.Forms.Label
    Friend WithEvents nudPMT As System.Windows.Forms.NumericUpDown
    Friend WithEvents Button1 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.CustomPanelTop = New GradientPanel.CustomPanel
        Me.lblYValue = New System.Windows.Forms.Label
        Me.lblWvPos = New System.Windows.Forms.Label
        Me.cmdChangeScale = New NETXP.Controls.XPButton
        Me.lblSlitWidthnm = New System.Windows.Forms.Label
        Me.lblPMTVolts = New System.Windows.Forms.Label
        Me.lblD2CurmA = New System.Windows.Forms.Label
        Me.cmbModes = New System.Windows.Forms.ComboBox
        Me.lblModes = New System.Windows.Forms.Label
        Me.lblSpeed = New System.Windows.Forms.Label
        Me.cmbSpeed = New System.Windows.Forms.ComboBox
        Me.lblSlitWidth = New System.Windows.Forms.Label
        Me.nudSlit = New System.Windows.Forms.NumericUpDown
        Me.nudD2Cur = New System.Windows.Forms.NumericUpDown
        Me.lblD2Cur = New System.Windows.Forms.Label
        Me.lblPMT = New System.Windows.Forms.Label
        Me.nudPMT = New System.Windows.Forms.NumericUpDown
        Me.Button1 = New System.Windows.Forms.Button
        Me.CustomPanelTop.SuspendLayout()
        CType(Me.nudSlit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudD2Cur, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudPMT, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CustomPanelTop
        '
        Me.CustomPanelTop.BackColor = System.Drawing.Color.AliceBlue
        Me.CustomPanelTop.Controls.Add(Me.lblYValue)
        Me.CustomPanelTop.Controls.Add(Me.lblWvPos)
        Me.CustomPanelTop.Controls.Add(Me.cmdChangeScale)
        Me.CustomPanelTop.Controls.Add(Me.lblSlitWidthnm)
        Me.CustomPanelTop.Controls.Add(Me.lblPMTVolts)
        Me.CustomPanelTop.Controls.Add(Me.lblD2CurmA)
        Me.CustomPanelTop.Controls.Add(Me.cmbModes)
        Me.CustomPanelTop.Controls.Add(Me.lblModes)
        Me.CustomPanelTop.Controls.Add(Me.lblSpeed)
        Me.CustomPanelTop.Controls.Add(Me.cmbSpeed)
        Me.CustomPanelTop.Controls.Add(Me.lblSlitWidth)
        Me.CustomPanelTop.Controls.Add(Me.nudSlit)
        Me.CustomPanelTop.Controls.Add(Me.nudD2Cur)
        Me.CustomPanelTop.Controls.Add(Me.lblD2Cur)
        Me.CustomPanelTop.Controls.Add(Me.lblPMT)
        Me.CustomPanelTop.Controls.Add(Me.nudPMT)
        Me.CustomPanelTop.Dock = System.Windows.Forms.DockStyle.Left
        Me.CustomPanelTop.Location = New System.Drawing.Point(0, 0)
        Me.CustomPanelTop.Name = "CustomPanelTop"
        Me.CustomPanelTop.Size = New System.Drawing.Size(208, 493)
        Me.CustomPanelTop.TabIndex = 2
        '
        'lblYValue
        '
        Me.lblYValue.BackColor = System.Drawing.Color.White
        Me.lblYValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblYValue.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblYValue.ForeColor = System.Drawing.Color.Blue
        Me.lblYValue.Location = New System.Drawing.Point(9, 322)
        Me.lblYValue.Name = "lblYValue"
        Me.lblYValue.Size = New System.Drawing.Size(187, 20)
        Me.lblYValue.TabIndex = 45
        Me.lblYValue.Text = ""
        '
        'lblWvPos
        '
        Me.lblWvPos.AutoSize = True
        Me.lblWvPos.BackColor = System.Drawing.Color.White
        Me.lblWvPos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblWvPos.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWvPos.ForeColor = System.Drawing.Color.Blue
        Me.lblWvPos.Location = New System.Drawing.Point(9, 280)
        Me.lblWvPos.Name = "lblWvPos"
        Me.lblWvPos.Size = New System.Drawing.Size(114, 20)
        Me.lblWvPos.TabIndex = 44
        Me.lblWvPos.Text = "Wavelength (nm) :"
        '
        'cmdChangeScale
        '
        Me.cmdChangeScale.Enabled = False
        Me.cmdChangeScale.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdChangeScale.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdChangeScale.Location = New System.Drawing.Point(84, 220)
        Me.cmdChangeScale.Name = "cmdChangeScale"
        Me.cmdChangeScale.Size = New System.Drawing.Size(106, 30)
        Me.cmdChangeScale.TabIndex = 31
        Me.cmdChangeScale.Text = "Change &Scale"
        '
        'lblSlitWidthnm
        '
        Me.lblSlitWidthnm.Enabled = False
        Me.lblSlitWidthnm.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSlitWidthnm.Location = New System.Drawing.Point(142, 108)
        Me.lblSlitWidthnm.Name = "lblSlitWidthnm"
        Me.lblSlitWidthnm.Size = New System.Drawing.Size(24, 18)
        Me.lblSlitWidthnm.TabIndex = 28
        Me.lblSlitWidthnm.Text = "nm"
        Me.lblSlitWidthnm.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPMTVolts
        '
        Me.lblPMTVolts.Enabled = False
        Me.lblPMTVolts.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPMTVolts.Location = New System.Drawing.Point(142, 40)
        Me.lblPMTVolts.Name = "lblPMTVolts"
        Me.lblPMTVolts.Size = New System.Drawing.Size(32, 18)
        Me.lblPMTVolts.TabIndex = 27
        Me.lblPMTVolts.Text = "volts"
        Me.lblPMTVolts.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblD2CurmA
        '
        Me.lblD2CurmA.Enabled = False
        Me.lblD2CurmA.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblD2CurmA.Location = New System.Drawing.Point(142, 74)
        Me.lblD2CurmA.Name = "lblD2CurmA"
        Me.lblD2CurmA.Size = New System.Drawing.Size(22, 18)
        Me.lblD2CurmA.TabIndex = 26
        Me.lblD2CurmA.Text = "mA"
        Me.lblD2CurmA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbModes
        '
        Me.cmbModes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbModes.Enabled = False
        Me.cmbModes.Items.AddRange(New Object() {"D2E", "HCLE", "AA", "SELFTEST", "MABS", "AABGC", "EMISSION"})
        Me.cmbModes.Location = New System.Drawing.Point(84, 182)
        Me.cmbModes.Name = "cmbModes"
        Me.cmbModes.Size = New System.Drawing.Size(82, 21)
        Me.cmbModes.TabIndex = 4
        Me.cmbModes.Visible = False
        '
        'lblModes
        '
        Me.lblModes.Location = New System.Drawing.Point(32, 182)
        Me.lblModes.Name = "lblModes"
        Me.lblModes.Size = New System.Drawing.Size(48, 20)
        Me.lblModes.TabIndex = 8
        Me.lblModes.Text = "Modes"
        Me.lblModes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblSpeed
        '
        Me.lblSpeed.Location = New System.Drawing.Point(24, 146)
        Me.lblSpeed.Name = "lblSpeed"
        Me.lblSpeed.Size = New System.Drawing.Size(50, 24)
        Me.lblSpeed.TabIndex = 7
        Me.lblSpeed.Text = "Speed"
        Me.lblSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbSpeed
        '
        Me.cmbSpeed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSpeed.Enabled = False
        Me.cmbSpeed.Items.AddRange(New Object() {"FAST", "MEDIUM", "SLOW"})
        Me.cmbSpeed.Location = New System.Drawing.Point(84, 148)
        Me.cmbSpeed.Name = "cmbSpeed"
        Me.cmbSpeed.Size = New System.Drawing.Size(82, 21)
        Me.cmbSpeed.TabIndex = 3
        Me.cmbSpeed.Visible = False
        '
        'lblSlitWidth
        '
        Me.lblSlitWidth.Location = New System.Drawing.Point(18, 106)
        Me.lblSlitWidth.Name = "lblSlitWidth"
        Me.lblSlitWidth.Size = New System.Drawing.Size(66, 28)
        Me.lblSlitWidth.TabIndex = 5
        Me.lblSlitWidth.Text = "Slit Width"
        Me.lblSlitWidth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'nudSlit
        '
        Me.nudSlit.DecimalPlaces = 1
        Me.nudSlit.Enabled = False
        Me.nudSlit.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.nudSlit.Location = New System.Drawing.Point(86, 110)
        Me.nudSlit.Maximum = New Decimal(New Integer() {20, 0, 0, 65536})
        Me.nudSlit.Name = "nudSlit"
        Me.nudSlit.Size = New System.Drawing.Size(56, 20)
        Me.nudSlit.TabIndex = 2
        Me.nudSlit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.nudSlit.Visible = False
        '
        'nudD2Cur
        '
        Me.nudD2Cur.Enabled = False
        Me.nudD2Cur.Location = New System.Drawing.Point(86, 74)
        Me.nudD2Cur.Maximum = New Decimal(New Integer() {300, 0, 0, 0})
        Me.nudD2Cur.Minimum = New Decimal(New Integer() {100, 0, 0, 0})
        Me.nudD2Cur.Name = "nudD2Cur"
        Me.nudD2Cur.Size = New System.Drawing.Size(56, 20)
        Me.nudD2Cur.TabIndex = 1
        Me.nudD2Cur.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.nudD2Cur.Value = New Decimal(New Integer() {100, 0, 0, 0})
        Me.nudD2Cur.Visible = False
        '
        'lblD2Cur
        '
        Me.lblD2Cur.Location = New System.Drawing.Point(40, 70)
        Me.lblD2Cur.Name = "lblD2Cur"
        Me.lblD2Cur.Size = New System.Drawing.Size(44, 28)
        Me.lblD2Cur.TabIndex = 2
        Me.lblD2Cur.Text = "D2 Cur"
        Me.lblD2Cur.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblPMT
        '
        Me.lblPMT.Location = New System.Drawing.Point(46, 36)
        Me.lblPMT.Name = "lblPMT"
        Me.lblPMT.Size = New System.Drawing.Size(36, 28)
        Me.lblPMT.TabIndex = 1
        Me.lblPMT.Text = "PMT"
        Me.lblPMT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'nudPMT
        '
        Me.nudPMT.Enabled = False
        Me.nudPMT.Increment = New Decimal(New Integer() {5, 0, 0, 0})
        Me.nudPMT.Location = New System.Drawing.Point(86, 40)
        Me.nudPMT.Maximum = New Decimal(New Integer() {700, 0, 0, 0})
        Me.nudPMT.Name = "nudPMT"
        Me.nudPMT.Size = New System.Drawing.Size(56, 20)
        Me.nudPMT.TabIndex = 0
        Me.nudPMT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.nudPMT.Visible = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(240, 160)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(72, 72)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "Button1"
        '
        'Test111
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(352, 493)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.CustomPanelTop)
        Me.Name = "Test111"
        Me.Text = "Test111"
        Me.CustomPanelTop.ResumeLayout(False)
        CType(Me.nudSlit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudD2Cur, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudPMT, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ' Create and display a modless about dialog box.
        Dim about As New TestForm
        about.Show()

        ' Draw a blue square on the form.
        ' NOTE: This is not a persistent object, it will no longer be
        ' visible after the next call to OnPaint. To make it persistent, 
        ' override the OnPaint method and draw the square there 
        Dim g As Graphics = about.CreateGraphics()
        g.FillRectangle(Brushes.Blue, 10, 10, 200, 200)
    End Sub
End Class
