Public Class frmMessageFlame
    Inherits System.Windows.Forms.Form

#Region " Property Defination"
    Dim mptrMessageTest As String = "Ready for flame. AA or N2O," & vbLf & "else Cancel"
    Public Property MessageTest() As String
        Get
            Return mptrMessageTest
        End Get
        Set(ByVal Value As String)
            mptrMessageTest = Value
        End Set
    End Property
#End Region

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        'Me.CustomPanelBackground.BringToFront()
        InitialiseObject()
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
    Friend WithEvents lblMessage As System.Windows.Forms.Label
    Friend WithEvents cmdCancel As NETXP.Controls.XPButton
    Friend WithEvents cmdYes As NETXP.Controls.XPButton
    Friend WithEvents cmdNo As NETXP.Controls.XPButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMessageFlame))
        Me.ImgLstMessage = New System.Windows.Forms.ImageList(Me.components)
        Me.Office2003HeaderSubMessage = New CodeIntellects.Office2003Controls.Office2003HeaderSub
        Me.cmdCancel = New NETXP.Controls.XPButton
        Me.cmdYes = New NETXP.Controls.XPButton
        Me.picMessage = New System.Windows.Forms.PictureBox
        Me.cmdNo = New NETXP.Controls.XPButton
        Me.lblMessage = New System.Windows.Forms.Label
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
        Me.Office2003HeaderSubMessage.Controls.Add(Me.cmdCancel)
        Me.Office2003HeaderSubMessage.Controls.Add(Me.cmdYes)
        Me.Office2003HeaderSubMessage.Controls.Add(Me.picMessage)
        Me.Office2003HeaderSubMessage.Controls.Add(Me.cmdNo)
        Me.Office2003HeaderSubMessage.Controls.Add(Me.lblMessage)
        Me.Office2003HeaderSubMessage.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Office2003HeaderSubMessage.Location = New System.Drawing.Point(0, 0)
        Me.Office2003HeaderSubMessage.Name = "Office2003HeaderSubMessage"
        Me.Office2003HeaderSubMessage.Size = New System.Drawing.Size(434, 175)
        Me.Office2003HeaderSubMessage.TabIndex = 17
        Me.Office2003HeaderSubMessage.TitleColor = System.Drawing.Color.Black
        Me.Office2003HeaderSubMessage.TitleFont = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Office2003HeaderSubMessage.TitleText = "Message Title"
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.Color.AliceBlue
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdCancel.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.cmdCancel.Image = CType(resources.GetObject("cmdCancel.Image"), System.Drawing.Image)
        Me.cmdCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdCancel.Location = New System.Drawing.Point(278, 120)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(112, 40)
        Me.cmdCancel.TabIndex = 18
        Me.cmdCancel.Text = "&Cancel"
        '
        'cmdYes
        '
        Me.cmdYes.BackColor = System.Drawing.Color.AliceBlue
        Me.cmdYes.DialogResult = System.Windows.Forms.DialogResult.Yes
        Me.cmdYes.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdYes.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.cmdYes.Image = CType(resources.GetObject("cmdYes.Image"), System.Drawing.Image)
        Me.cmdYes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdYes.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdYes.Location = New System.Drawing.Point(38, 120)
        Me.cmdYes.Name = "cmdYes"
        Me.cmdYes.Size = New System.Drawing.Size(112, 40)
        Me.cmdYes.TabIndex = 17
        Me.cmdYes.Text = "&AA Flame"
        Me.cmdYes.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        'cmdNo
        '
        Me.cmdNo.BackColor = System.Drawing.Color.AliceBlue
        Me.cmdNo.DialogResult = System.Windows.Forms.DialogResult.No
        Me.cmdNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdNo.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.cmdNo.Image = CType(resources.GetObject("cmdNo.Image"), System.Drawing.Image)
        Me.cmdNo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdNo.Location = New System.Drawing.Point(158, 120)
        Me.cmdNo.Name = "cmdNo"
        Me.cmdNo.Size = New System.Drawing.Size(112, 40)
        Me.cmdNo.TabIndex = 19
        Me.cmdNo.Text = "&NA Flame"
        Me.cmdNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblMessage
        '
        Me.lblMessage.BackColor = System.Drawing.Color.Transparent
        Me.lblMessage.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblMessage.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblMessage.Location = New System.Drawing.Point(64, 24)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(312, 88)
        Me.lblMessage.TabIndex = 16
        Me.lblMessage.Text = "AAS"
        Me.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmMessageFlame
        '
        Me.AcceptButton = Me.cmdNo
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.CancelButton = Me.cmdCancel
        Me.ClientSize = New System.Drawing.Size(434, 175)
        Me.Controls.Add(Me.Office2003HeaderSubMessage)
        Me.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMessageFlame"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AAS"
        Me.TopMost = True
        Me.Office2003HeaderSubMessage.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub InitialiseObject()
        lblMessage.Text = MessageTest
        If Not Me.ImgLstMessage.Images.Count = 0 Then
            Me.picMessage.Image = Me.ImgLstMessage.Images(2)
        End If
    End Sub
    
    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click

    End Sub
End Class
