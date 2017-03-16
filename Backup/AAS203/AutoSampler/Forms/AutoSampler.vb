Public Class AutoSampler
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
    Friend WithEvents lblHome As System.Windows.Forms.Label
    Friend WithEvents lblPosition As System.Windows.Forms.Label
    Friend WithEvents lblProbe As System.Windows.Forms.Label
    Friend WithEvents lblWashTime As System.Windows.Forms.Label
    Friend WithEvents lblIntakeTime As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents lblPump As System.Windows.Forms.Label
    Friend WithEvents txtWashTime As System.Windows.Forms.TextBox
    Friend WithEvents txtIntakeTime As System.Windows.Forms.TextBox
    Friend WithEvents txtHome As System.Windows.Forms.TextBox
    Friend WithEvents txtPump As System.Windows.Forms.TextBox
    Friend WithEvents txtPosition As System.Windows.Forms.TextBox
    Friend WithEvents txtProbe As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btnHome As System.Windows.Forms.Button
    Friend WithEvents btnGoto As System.Windows.Forms.Button
    Friend WithEvents btnProbe As System.Windows.Forms.Button
    Friend WithEvents btnPumpForward As System.Windows.Forms.Button
    Friend WithEvents btnPumpReverse As System.Windows.Forms.Button
    Friend WithEvents btnTestPosns As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(AutoSampler))
        Me.lblHome = New System.Windows.Forms.Label
        Me.lblPosition = New System.Windows.Forms.Label
        Me.lblProbe = New System.Windows.Forms.Label
        Me.lblWashTime = New System.Windows.Forms.Label
        Me.lblIntakeTime = New System.Windows.Forms.Label
        Me.btnCancel = New System.Windows.Forms.Button
        Me.lblPump = New System.Windows.Forms.Label
        Me.txtPump = New System.Windows.Forms.TextBox
        Me.txtWashTime = New System.Windows.Forms.TextBox
        Me.txtIntakeTime = New System.Windows.Forms.TextBox
        Me.txtHome = New System.Windows.Forms.TextBox
        Me.txtPosition = New System.Windows.Forms.TextBox
        Me.txtProbe = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnTestPosns = New System.Windows.Forms.Button
        Me.btnPumpReverse = New System.Windows.Forms.Button
        Me.btnPumpForward = New System.Windows.Forms.Button
        Me.btnProbe = New System.Windows.Forms.Button
        Me.btnGoto = New System.Windows.Forms.Button
        Me.btnHome = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblHome
        '
        Me.lblHome.Location = New System.Drawing.Point(16, 21)
        Me.lblHome.Name = "lblHome"
        Me.lblHome.Size = New System.Drawing.Size(80, 32)
        Me.lblHome.TabIndex = 10
        Me.lblHome.Text = "Home :"
        Me.lblHome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPosition
        '
        Me.lblPosition.Location = New System.Drawing.Point(16, 69)
        Me.lblPosition.Name = "lblPosition"
        Me.lblPosition.Size = New System.Drawing.Size(80, 32)
        Me.lblPosition.TabIndex = 11
        Me.lblPosition.Text = "Position :"
        Me.lblPosition.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblProbe
        '
        Me.lblProbe.Location = New System.Drawing.Point(16, 117)
        Me.lblProbe.Name = "lblProbe"
        Me.lblProbe.Size = New System.Drawing.Size(80, 32)
        Me.lblProbe.TabIndex = 12
        Me.lblProbe.Text = "Probe :"
        Me.lblProbe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblWashTime
        '
        Me.lblWashTime.Location = New System.Drawing.Point(16, 56)
        Me.lblWashTime.Name = "lblWashTime"
        Me.lblWashTime.Size = New System.Drawing.Size(126, 24)
        Me.lblWashTime.TabIndex = 19
        Me.lblWashTime.Text = "Sample Wash Time :"
        Me.lblWashTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblIntakeTime
        '
        Me.lblIntakeTime.Location = New System.Drawing.Point(16, 21)
        Me.lblIntakeTime.Name = "lblIntakeTime"
        Me.lblIntakeTime.Size = New System.Drawing.Size(126, 24)
        Me.lblIntakeTime.TabIndex = 18
        Me.lblIntakeTime.Text = "Sample Intake Time :"
        Me.lblIntakeTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCancel.Image = CType(resources.GetObject("btnCancel.Image"), System.Drawing.Image)
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancel.Location = New System.Drawing.Point(272, 280)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(88, 32)
        Me.btnCancel.TabIndex = 13
        Me.btnCancel.Text = "&Cancel"
        '
        'lblPump
        '
        Me.lblPump.Location = New System.Drawing.Point(16, 165)
        Me.lblPump.Name = "lblPump"
        Me.lblPump.Size = New System.Drawing.Size(80, 32)
        Me.lblPump.TabIndex = 14
        Me.lblPump.Text = "Pump :"
        Me.lblPump.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPump
        '
        Me.txtPump.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPump.Location = New System.Drawing.Point(96, 176)
        Me.txtPump.MaxLength = 10
        Me.txtPump.Name = "txtPump"
        Me.txtPump.Size = New System.Drawing.Size(64, 21)
        Me.txtPump.TabIndex = 20
        Me.txtPump.Text = ""
        '
        'txtWashTime
        '
        Me.txtWashTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtWashTime.Location = New System.Drawing.Point(160, 59)
        Me.txtWashTime.Name = "txtWashTime"
        Me.txtWashTime.Size = New System.Drawing.Size(80, 21)
        Me.txtWashTime.TabIndex = 22
        Me.txtWashTime.Text = ""
        '
        'txtIntakeTime
        '
        Me.txtIntakeTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIntakeTime.Location = New System.Drawing.Point(160, 24)
        Me.txtIntakeTime.MaxLength = 10
        Me.txtIntakeTime.Name = "txtIntakeTime"
        Me.txtIntakeTime.Size = New System.Drawing.Size(80, 21)
        Me.txtIntakeTime.TabIndex = 21
        Me.txtIntakeTime.Text = ""
        '
        'txtHome
        '
        Me.txtHome.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtHome.Location = New System.Drawing.Point(96, 32)
        Me.txtHome.MaxLength = 7
        Me.txtHome.Name = "txtHome"
        Me.txtHome.Size = New System.Drawing.Size(64, 21)
        Me.txtHome.TabIndex = 15
        Me.txtHome.Text = ""
        '
        'txtPosition
        '
        Me.txtPosition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPosition.Location = New System.Drawing.Point(96, 80)
        Me.txtPosition.MaxLength = 10
        Me.txtPosition.Name = "txtPosition"
        Me.txtPosition.Size = New System.Drawing.Size(64, 21)
        Me.txtPosition.TabIndex = 16
        Me.txtPosition.Text = ""
        '
        'txtProbe
        '
        Me.txtProbe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProbe.Location = New System.Drawing.Point(96, 128)
        Me.txtProbe.MaxLength = 10
        Me.txtProbe.Name = "txtProbe"
        Me.txtProbe.Size = New System.Drawing.Size(64, 21)
        Me.txtProbe.TabIndex = 17
        Me.txtProbe.Text = ""
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.AliceBlue
        Me.GroupBox1.Controls.Add(Me.btnTestPosns)
        Me.GroupBox1.Controls.Add(Me.btnPumpReverse)
        Me.GroupBox1.Controls.Add(Me.btnPumpForward)
        Me.GroupBox1.Controls.Add(Me.btnProbe)
        Me.GroupBox1.Controls.Add(Me.btnGoto)
        Me.GroupBox1.Controls.Add(Me.btnHome)
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(176, 216)
        Me.GroupBox1.TabIndex = 23
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Auto Sampler Commands"
        '
        'btnTestPosns
        '
        Me.btnTestPosns.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnTestPosns.Location = New System.Drawing.Point(16, 184)
        Me.btnTestPosns.Name = "btnTestPosns"
        Me.btnTestPosns.Size = New System.Drawing.Size(144, 24)
        Me.btnTestPosns.TabIndex = 5
        Me.btnTestPosns.Text = "Test All Positions"
        '
        'btnPumpReverse
        '
        Me.btnPumpReverse.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnPumpReverse.Location = New System.Drawing.Point(16, 152)
        Me.btnPumpReverse.Name = "btnPumpReverse"
        Me.btnPumpReverse.Size = New System.Drawing.Size(144, 24)
        Me.btnPumpReverse.TabIndex = 4
        Me.btnPumpReverse.Text = "Pump ON (R)"
        '
        'btnPumpForward
        '
        Me.btnPumpForward.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnPumpForward.Location = New System.Drawing.Point(16, 120)
        Me.btnPumpForward.Name = "btnPumpForward"
        Me.btnPumpForward.Size = New System.Drawing.Size(144, 24)
        Me.btnPumpForward.TabIndex = 3
        Me.btnPumpForward.Text = "Pump ON (F)"
        '
        'btnProbe
        '
        Me.btnProbe.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnProbe.Location = New System.Drawing.Point(16, 88)
        Me.btnProbe.Name = "btnProbe"
        Me.btnProbe.Size = New System.Drawing.Size(144, 24)
        Me.btnProbe.TabIndex = 2
        Me.btnProbe.Text = "Probe Down"
        '
        'btnGoto
        '
        Me.btnGoto.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnGoto.Location = New System.Drawing.Point(16, 56)
        Me.btnGoto.Name = "btnGoto"
        Me.btnGoto.Size = New System.Drawing.Size(144, 24)
        Me.btnGoto.TabIndex = 1
        Me.btnGoto.Text = "Go To"
        '
        'btnHome
        '
        Me.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnHome.Location = New System.Drawing.Point(16, 24)
        Me.btnHome.Name = "btnHome"
        Me.btnHome.Size = New System.Drawing.Size(144, 24)
        Me.btnHome.TabIndex = 0
        Me.btnHome.Text = "Sampler Home"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.AliceBlue
        Me.GroupBox2.Controls.Add(Me.lblPosition)
        Me.GroupBox2.Controls.Add(Me.lblHome)
        Me.GroupBox2.Controls.Add(Me.txtHome)
        Me.GroupBox2.Controls.Add(Me.txtPosition)
        Me.GroupBox2.Controls.Add(Me.lblProbe)
        Me.GroupBox2.Controls.Add(Me.txtProbe)
        Me.GroupBox2.Controls.Add(Me.lblPump)
        Me.GroupBox2.Controls.Add(Me.txtPump)
        Me.GroupBox2.Location = New System.Drawing.Point(184, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(176, 216)
        Me.GroupBox2.TabIndex = 24
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Sampler Status"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.lblWashTime)
        Me.GroupBox3.Controls.Add(Me.lblIntakeTime)
        Me.GroupBox3.Controls.Add(Me.txtWashTime)
        Me.GroupBox3.Controls.Add(Me.txtIntakeTime)
        Me.GroupBox3.Location = New System.Drawing.Point(0, 224)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(256, 88)
        Me.GroupBox3.TabIndex = 25
        Me.GroupBox3.TabStop = False
        '
        'AutoSampler
        '
        Me.AcceptButton = Me.btnCancel
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(370, 319)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnCancel)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AutoSampler"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AutoSampler Interface"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHome.Click

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPumpForward.Click

    End Sub
End Class
