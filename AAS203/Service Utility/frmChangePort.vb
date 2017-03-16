Public Class frmChangePort
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
    Friend WithEvents btnCancel As NETXP.Controls.XPButton
    Friend WithEvents btnOk As NETXP.Controls.XPButton
    Friend WithEvents gbRS232C As System.Windows.Forms.GroupBox
    Friend WithEvents cmbSelectPort As System.Windows.Forms.ComboBox
    Friend WithEvents lblSelectPort As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmChangePort))
        Me.CustomPanel1 = New GradientPanel.CustomPanel
        Me.btnCancel = New NETXP.Controls.XPButton
        Me.btnOk = New NETXP.Controls.XPButton
        Me.gbRS232C = New System.Windows.Forms.GroupBox
        Me.cmbSelectPort = New System.Windows.Forms.ComboBox
        Me.lblSelectPort = New System.Windows.Forms.Label
        Me.CustomPanel1.SuspendLayout()
        Me.gbRS232C.SuspendLayout()
        Me.SuspendLayout()
        '
        'CustomPanel1
        '
        Me.CustomPanel1.BackColor = System.Drawing.Color.AliceBlue
        Me.CustomPanel1.Controls.Add(Me.btnCancel)
        Me.CustomPanel1.Controls.Add(Me.btnOk)
        Me.CustomPanel1.Controls.Add(Me.gbRS232C)
        Me.CustomPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CustomPanel1.Location = New System.Drawing.Point(0, 0)
        Me.CustomPanel1.Name = "CustomPanel1"
        Me.CustomPanel1.Size = New System.Drawing.Size(312, 181)
        Me.CustomPanel1.TabIndex = 0
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Image = CType(resources.GetObject("btnCancel.Image"), System.Drawing.Image)
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancel.Location = New System.Drawing.Point(160, 120)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(86, 34)
        Me.btnCancel.TabIndex = 10
        Me.btnCancel.Text = "Cancel"
        '
        'btnOk
        '
        Me.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOk.Image = CType(resources.GetObject("btnOk.Image"), System.Drawing.Image)
        Me.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnOk.Location = New System.Drawing.Point(56, 120)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(86, 34)
        Me.btnOk.TabIndex = 9
        Me.btnOk.Text = "OK"
        '
        'gbRS232C
        '
        Me.gbRS232C.Controls.Add(Me.cmbSelectPort)
        Me.gbRS232C.Controls.Add(Me.lblSelectPort)
        Me.gbRS232C.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbRS232C.Location = New System.Drawing.Point(28, 27)
        Me.gbRS232C.Name = "gbRS232C"
        Me.gbRS232C.Size = New System.Drawing.Size(256, 77)
        Me.gbRS232C.TabIndex = 1
        Me.gbRS232C.TabStop = False
        Me.gbRS232C.Text = "RS232C"
        '
        'cmbSelectPort
        '
        Me.cmbSelectPort.Location = New System.Drawing.Point(147, 29)
        Me.cmbSelectPort.Name = "cmbSelectPort"
        Me.cmbSelectPort.Size = New System.Drawing.Size(80, 23)
        Me.cmbSelectPort.TabIndex = 1
        '
        'lblSelectPort
        '
        Me.lblSelectPort.Location = New System.Drawing.Point(16, 24)
        Me.lblSelectPort.Name = "lblSelectPort"
        Me.lblSelectPort.Size = New System.Drawing.Size(224, 32)
        Me.lblSelectPort.TabIndex = 0
        Me.lblSelectPort.Text = "   Select a COM port"
        Me.lblSelectPort.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmChangePort
        '
        Me.AcceptButton = Me.btnOk
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(312, 181)
        Me.Controls.Add(Me.CustomPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmChangePort"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Communication Parameters"
        Me.CustomPanel1.ResumeLayout(False)
        Me.gbRS232C.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

End Class
