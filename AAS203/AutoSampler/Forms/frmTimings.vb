Public Class frmTimings
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
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblIntakeTime As System.Windows.Forms.Label
    Friend WithEvents lblWaitTime As System.Windows.Forms.Label
    Friend WithEvents lblWashTime As System.Windows.Forms.Label
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents NumUpDnWaitTime As System.Windows.Forms.NumericUpDown
    Friend WithEvents NumUpDnWashTime As System.Windows.Forms.NumericUpDown
    Friend WithEvents NumUpDnIntakeTime As System.Windows.Forms.NumericUpDown
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmTimings))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.NumUpDnIntakeTime = New System.Windows.Forms.NumericUpDown
        Me.NumUpDnWashTime = New System.Windows.Forms.NumericUpDown
        Me.NumUpDnWaitTime = New System.Windows.Forms.NumericUpDown
        Me.lblWashTime = New System.Windows.Forms.Label
        Me.lblWaitTime = New System.Windows.Forms.Label
        Me.lblIntakeTime = New System.Windows.Forms.Label
        Me.btnOk = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        CType(Me.NumUpDnIntakeTime, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumUpDnWashTime, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumUpDnWaitTime, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.NumUpDnIntakeTime)
        Me.GroupBox1.Controls.Add(Me.NumUpDnWashTime)
        Me.GroupBox1.Controls.Add(Me.NumUpDnWaitTime)
        Me.GroupBox1.Controls.Add(Me.lblWashTime)
        Me.GroupBox1.Controls.Add(Me.lblWaitTime)
        Me.GroupBox1.Controls.Add(Me.lblIntakeTime)
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(288, 144)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Timings"
        '
        'NumUpDnIntakeTime
        '
        Me.NumUpDnIntakeTime.BackColor = System.Drawing.Color.FloralWhite
        Me.NumUpDnIntakeTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.NumUpDnIntakeTime.Location = New System.Drawing.Point(232, 24)
        Me.NumUpDnIntakeTime.Maximum = New Decimal(New Integer() {999, 0, 0, 0})
        Me.NumUpDnIntakeTime.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumUpDnIntakeTime.Name = "NumUpDnIntakeTime"
        Me.NumUpDnIntakeTime.ReadOnly = True
        Me.NumUpDnIntakeTime.Size = New System.Drawing.Size(48, 21)
        Me.NumUpDnIntakeTime.TabIndex = 6
        Me.NumUpDnIntakeTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.NumUpDnIntakeTime.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'NumUpDnWashTime
        '
        Me.NumUpDnWashTime.BackColor = System.Drawing.Color.FloralWhite
        Me.NumUpDnWashTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.NumUpDnWashTime.Location = New System.Drawing.Point(232, 107)
        Me.NumUpDnWashTime.Maximum = New Decimal(New Integer() {999, 0, 0, 0})
        Me.NumUpDnWashTime.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumUpDnWashTime.Name = "NumUpDnWashTime"
        Me.NumUpDnWashTime.ReadOnly = True
        Me.NumUpDnWashTime.Size = New System.Drawing.Size(48, 21)
        Me.NumUpDnWashTime.TabIndex = 5
        Me.NumUpDnWashTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.NumUpDnWashTime.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'NumUpDnWaitTime
        '
        Me.NumUpDnWaitTime.BackColor = System.Drawing.Color.FloralWhite
        Me.NumUpDnWaitTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.NumUpDnWaitTime.Location = New System.Drawing.Point(232, 67)
        Me.NumUpDnWaitTime.Maximum = New Decimal(New Integer() {999, 0, 0, 0})
        Me.NumUpDnWaitTime.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumUpDnWaitTime.Name = "NumUpDnWaitTime"
        Me.NumUpDnWaitTime.ReadOnly = True
        Me.NumUpDnWaitTime.Size = New System.Drawing.Size(48, 21)
        Me.NumUpDnWaitTime.TabIndex = 4
        Me.NumUpDnWaitTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.NumUpDnWaitTime.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'lblWashTime
        '
        Me.lblWashTime.Location = New System.Drawing.Point(16, 104)
        Me.lblWashTime.Name = "lblWashTime"
        Me.lblWashTime.Size = New System.Drawing.Size(208, 24)
        Me.lblWashTime.TabIndex = 2
        Me.lblWashTime.Text = "Wash Time (secs) :"
        Me.lblWashTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblWaitTime
        '
        Me.lblWaitTime.Location = New System.Drawing.Point(16, 64)
        Me.lblWaitTime.Name = "lblWaitTime"
        Me.lblWaitTime.Size = New System.Drawing.Size(208, 24)
        Me.lblWaitTime.TabIndex = 1
        Me.lblWaitTime.Text = "Pre Measurement Wait Time(secs) :"
        Me.lblWaitTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblIntakeTime
        '
        Me.lblIntakeTime.Location = New System.Drawing.Point(16, 21)
        Me.lblIntakeTime.Name = "lblIntakeTime"
        Me.lblIntakeTime.Size = New System.Drawing.Size(208, 24)
        Me.lblIntakeTime.TabIndex = 0
        Me.lblIntakeTime.Text = "Sample Intake Time(secs) :"
        Me.lblIntakeTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnOk
        '
        Me.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnOk.Image = CType(resources.GetObject("btnOk.Image"), System.Drawing.Image)
        Me.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnOk.Location = New System.Drawing.Point(128, 152)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(72, 24)
        Me.btnOk.TabIndex = 1
        Me.btnOk.Text = "&Ok"
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCancel.Image = CType(resources.GetObject("btnCancel.Image"), System.Drawing.Image)
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancel.Location = New System.Drawing.Point(216, 152)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(72, 24)
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmTimings
        '
        Me.AcceptButton = Me.btnOk
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(292, 183)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTimings"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Timings"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.NumUpDnIntakeTime, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumUpDnWashTime, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumUpDnWaitTime, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub frmTimings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        NumUpDnIntakeTime.Value = gstructAutoSampler.intIntakeTime.ToString
        NumUpDnWaitTime.Value = gstructAutoSampler.intWaitingTime.ToString
        NumUpDnWashTime.Value = gstructAutoSampler.intWashTime.ToString
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        gstructAutoSampler.intIntakeTime = NumUpDnIntakeTime.Value
        gstructAutoSampler.intWaitingTime = NumUpDnWaitTime.Value
        gstructAutoSampler.intWashTime = NumUpDnWashTime.Value
        Call gfuncWriteSamplerParametersToINI(gstructAutoSampler)
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
End Class
