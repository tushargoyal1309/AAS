Public Class frmMessage
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        'Me.CustomPanelBackground.BringToFront()

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
    Friend WithEvents ImgLstMessage As System.Windows.Forms.ImageList
    Friend WithEvents picMessage As System.Windows.Forms.PictureBox
    Friend WithEvents Office2003HeaderSubMessage As CodeIntellects.Office2003Controls.Office2003HeaderSub
    Friend WithEvents cmdyes As NETXP.Controls.XPButton
    Friend WithEvents cmdno As NETXP.Controls.XPButton
    Friend WithEvents cmdok As NETXP.Controls.XPButton
    Friend WithEvents lblMessage As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMessage))
        Me.ImgLstMessage = New System.Windows.Forms.ImageList(Me.components)
        Me.Office2003HeaderSubMessage = New CodeIntellects.Office2003Controls.Office2003HeaderSub
        Me.cmdno = New NETXP.Controls.XPButton
        Me.cmdyes = New NETXP.Controls.XPButton
        Me.picMessage = New System.Windows.Forms.PictureBox
        Me.lblMessage = New System.Windows.Forms.Label
        Me.cmdok = New NETXP.Controls.XPButton
        Me.Office2003HeaderSubMessage.SuspendLayout()
        Me.SuspendLayout()
        '
        'ImgLstMessage
        '
        Me.ImgLstMessage.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
        Me.ImgLstMessage.ImageSize = New System.Drawing.Size(32, 32)
        Me.ImgLstMessage.ImageStream = CType(resources.GetObject("ImgLstMessage.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImgLstMessage.TransparentColor = System.Drawing.Color.Transparent
        '
        'Office2003HeaderSubMessage
        '
        Me.Office2003HeaderSubMessage.BackColor = System.Drawing.Color.Transparent
        Me.Office2003HeaderSubMessage.Controls.Add(Me.cmdno)
        Me.Office2003HeaderSubMessage.Controls.Add(Me.cmdyes)
        Me.Office2003HeaderSubMessage.Controls.Add(Me.picMessage)
        Me.Office2003HeaderSubMessage.Controls.Add(Me.lblMessage)
        Me.Office2003HeaderSubMessage.Controls.Add(Me.cmdok)
        Me.Office2003HeaderSubMessage.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Office2003HeaderSubMessage.Location = New System.Drawing.Point(0, 0)
        Me.Office2003HeaderSubMessage.Name = "Office2003HeaderSubMessage"
        Me.Office2003HeaderSubMessage.Size = New System.Drawing.Size(434, 199)
        Me.Office2003HeaderSubMessage.TabIndex = 17
        Me.Office2003HeaderSubMessage.TitleColor = System.Drawing.Color.Black
        Me.Office2003HeaderSubMessage.TitleFont = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Office2003HeaderSubMessage.TitleText = "Message Title"
        '
        'cmdno
        '
        Me.cmdno.BackColor = System.Drawing.Color.AliceBlue
        Me.cmdno.DialogResult = System.Windows.Forms.DialogResult.No
        Me.cmdno.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdno.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.cmdno.Image = CType(resources.GetObject("cmdno.Image"), System.Drawing.Image)
        Me.cmdno.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdno.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdno.Location = New System.Drawing.Point(239, 131)
        Me.cmdno.Name = "cmdno"
        Me.cmdno.Size = New System.Drawing.Size(88, 40)
        Me.cmdno.TabIndex = 18
        Me.cmdno.Text = "&NO"
        '
        'cmdyes
        '
        Me.cmdyes.BackColor = System.Drawing.Color.AliceBlue
        Me.cmdyes.DialogResult = System.Windows.Forms.DialogResult.Yes
        Me.cmdyes.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdyes.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.cmdyes.Image = CType(resources.GetObject("cmdyes.Image"), System.Drawing.Image)
        Me.cmdyes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdyes.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdyes.Location = New System.Drawing.Point(136, 131)
        Me.cmdyes.Name = "cmdyes"
        Me.cmdyes.Size = New System.Drawing.Size(88, 40)
        Me.cmdyes.TabIndex = 17
        Me.cmdyes.Text = "&YES"
        '
        'picMessage
        '
        Me.picMessage.Image = CType(resources.GetObject("picMessage.Image"), System.Drawing.Image)
        Me.picMessage.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.picMessage.Location = New System.Drawing.Point(10, 41)
        Me.picMessage.Name = "picMessage"
        Me.picMessage.Size = New System.Drawing.Size(38, 64)
        Me.picMessage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.picMessage.TabIndex = 12
        Me.picMessage.TabStop = False
        '
        'lblMessage
        '
        Me.lblMessage.BackColor = System.Drawing.Color.Transparent
        Me.lblMessage.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblMessage.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblMessage.Location = New System.Drawing.Point(64, 27)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(360, 96)
        Me.lblMessage.TabIndex = 16
        Me.lblMessage.Text = "AAS"
        Me.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmdok
        '
        Me.cmdok.BackColor = System.Drawing.Color.AliceBlue
        Me.cmdok.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.cmdok.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdok.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.cmdok.Image = CType(resources.GetObject("cmdok.Image"), System.Drawing.Image)
        Me.cmdok.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdok.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdok.Location = New System.Drawing.Point(192, 131)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(88, 40)
        Me.cmdok.TabIndex = 19
        Me.cmdok.Text = "&OK"
        '
        'frmMessage
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(434, 199)
        Me.ControlBox = False
        Me.Controls.Add(Me.Office2003HeaderSubMessage)
        Me.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMessage"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AAS"
        Me.TopMost = True
        Me.Office2003HeaderSubMessage.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    
End Class
