Public Class frmAutoSampler
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
    Friend WithEvents txtWashTime As System.Windows.Forms.TextBox
    Friend WithEvents txtIntakeTime As System.Windows.Forms.TextBox
    Friend WithEvents lblWashTime As System.Windows.Forms.Label
    Friend WithEvents lblIntakeTime As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmAutoSampler))
        Me.txtWashTime = New System.Windows.Forms.TextBox
        Me.txtIntakeTime = New System.Windows.Forms.TextBox
        Me.lblWashTime = New System.Windows.Forms.Label
        Me.lblIntakeTime = New System.Windows.Forms.Label
        Me.btnCancel = New System.Windows.Forms.Button
        Me.lblHome = New System.Windows.Forms.Label
        Me.lblPosition = New System.Windows.Forms.Label
        Me.lblProbe = New System.Windows.Forms.Label
        Me.z = New System.Windows.Forms.Label
        Me.txtHome = New System.Windows.Forms.TextBox
        Me.TextBox4 = New System.Windows.Forms.TextBox
        Me.TextBox5 = New System.Windows.Forms.TextBox
        Me.TextBox6 = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'txtWashTime
        '
        Me.txtWashTime.Location = New System.Drawing.Point(136, 67)
        Me.txtWashTime.Name = "txtWashTime"
        Me.txtWashTime.Size = New System.Drawing.Size(80, 20)
        Me.txtWashTime.TabIndex = 9
        Me.txtWashTime.Text = ""
        '
        'txtIntakeTime
        '
        Me.txtIntakeTime.Location = New System.Drawing.Point(136, 27)
        Me.txtIntakeTime.MaxLength = 10
        Me.txtIntakeTime.Name = "txtIntakeTime"
        Me.txtIntakeTime.Size = New System.Drawing.Size(80, 20)
        Me.txtIntakeTime.TabIndex = 8
        Me.txtIntakeTime.Text = ""
        '
        'lblWashTime
        '
        Me.lblWashTime.Location = New System.Drawing.Point(32, 23)
        Me.lblWashTime.Name = "lblWashTime"
        Me.lblWashTime.Size = New System.Drawing.Size(126, 24)
        Me.lblWashTime.TabIndex = 7
        Me.lblWashTime.Text = "Sample Wash Time :"
        Me.lblWashTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblIntakeTime
        '
        Me.lblIntakeTime.Location = New System.Drawing.Point(10, 24)
        Me.lblIntakeTime.Name = "lblIntakeTime"
        Me.lblIntakeTime.Size = New System.Drawing.Size(126, 24)
        Me.lblIntakeTime.TabIndex = 6
        Me.lblIntakeTime.Text = "Sample Intake Time :"
        Me.lblIntakeTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCancel.Image = CType(resources.GetObject("btnCancel.Image"), System.Drawing.Image)
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancel.Location = New System.Drawing.Point(272, 344)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(88, 32)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "&Cancel"
        '
        'lblHome
        '
        Me.lblHome.Location = New System.Drawing.Point(34, 45)
        Me.lblHome.Name = "lblHome"
        Me.lblHome.Size = New System.Drawing.Size(80, 32)
        Me.lblHome.TabIndex = 0
        Me.lblHome.Text = "Home :"
        Me.lblHome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPosition
        '
        Me.lblPosition.Location = New System.Drawing.Point(16, 72)
        Me.lblPosition.Name = "lblPosition"
        Me.lblPosition.Size = New System.Drawing.Size(80, 32)
        Me.lblPosition.TabIndex = 1
        Me.lblPosition.Text = "Position :"
        Me.lblPosition.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblProbe
        '
        Me.lblProbe.Location = New System.Drawing.Point(16, 120)
        Me.lblProbe.Name = "lblProbe"
        Me.lblProbe.Size = New System.Drawing.Size(80, 32)
        Me.lblProbe.TabIndex = 2
        Me.lblProbe.Text = "Probe :"
        Me.lblProbe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'z
        '
        Me.z.Location = New System.Drawing.Point(16, 168)
        Me.z.Name = "z"
        Me.z.Size = New System.Drawing.Size(80, 32)
        Me.z.TabIndex = 3
        Me.z.Text = "Pump :"
        Me.z.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtHome
        '
        Me.txtHome.Location = New System.Drawing.Point(104, 32)
        Me.txtHome.MaxLength = 7
        Me.txtHome.Name = "txtHome"
        Me.txtHome.Size = New System.Drawing.Size(64, 20)
        Me.txtHome.TabIndex = 4
        Me.txtHome.Text = ""
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(104, 80)
        Me.TextBox4.MaxLength = 10
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(64, 20)
        Me.TextBox4.TabIndex = 5
        Me.TextBox4.Text = ""
        '
        'TextBox5
        '
        Me.TextBox5.Location = New System.Drawing.Point(104, 128)
        Me.TextBox5.MaxLength = 10
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(64, 20)
        Me.TextBox5.TabIndex = 6
        Me.TextBox5.Text = ""
        '
        'TextBox6
        '
        Me.TextBox6.Location = New System.Drawing.Point(104, 176)
        Me.TextBox6.MaxLength = 10
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Size = New System.Drawing.Size(64, 20)
        Me.TextBox6.TabIndex = 7
        Me.TextBox6.Text = ""
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(48, 64)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 48)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Label1"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(96, 160)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(216, 21)
        Me.TextBox1.TabIndex = 5
        Me.TextBox1.Text = "TextBox1"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(184, 64)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(80, 32)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "Button1"
        '
        'frmAutoSampler
        '
        Me.AcceptButton = Me.btnCancel
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(362, 383)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnCancel)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAutoSampler"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AutoSampler Interface"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Friend WithEvents TextBox6 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents txtHome As System.Windows.Forms.TextBox
    Friend WithEvents z As System.Windows.Forms.Label
    Friend WithEvents lblProbe As System.Windows.Forms.Label
    Friend WithEvents lblPosition As System.Windows.Forms.Label
    Friend WithEvents lblHome As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

    End Sub
End Class
