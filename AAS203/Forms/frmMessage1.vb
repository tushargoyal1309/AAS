Public Class frmMessage1
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
    Friend WithEvents cmdNo As System.Windows.Forms.Button
    Friend WithEvents cmdYes As System.Windows.Forms.Button
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents picMessage As System.Windows.Forms.PictureBox
    Friend WithEvents lblMessage As System.Windows.Forms.Label
    Friend WithEvents ImgLstMessage As System.Windows.Forms.ImageList
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMessage1))
        Me.cmdNo = New System.Windows.Forms.Button
        Me.cmdYes = New System.Windows.Forms.Button
        Me.cmdOk = New System.Windows.Forms.Button
        Me.picMessage = New System.Windows.Forms.PictureBox
        Me.lblMessage = New System.Windows.Forms.Label
        Me.ImgLstMessage = New System.Windows.Forms.ImageList(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdNo
        '
        Me.cmdNo.AccessibleDescription = resources.GetString("cmdNo.AccessibleDescription")
        Me.cmdNo.AccessibleName = resources.GetString("cmdNo.AccessibleName")
        Me.cmdNo.Anchor = CType(resources.GetObject("cmdNo.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.cmdNo.BackgroundImage = CType(resources.GetObject("cmdNo.BackgroundImage"), System.Drawing.Image)
        Me.cmdNo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdNo.DialogResult = System.Windows.Forms.DialogResult.No
        Me.cmdNo.Dock = CType(resources.GetObject("cmdNo.Dock"), System.Windows.Forms.DockStyle)
        Me.cmdNo.Enabled = CType(resources.GetObject("cmdNo.Enabled"), Boolean)
        Me.cmdNo.FlatStyle = CType(resources.GetObject("cmdNo.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.cmdNo.Font = CType(resources.GetObject("cmdNo.Font"), System.Drawing.Font)
        Me.cmdNo.Image = CType(resources.GetObject("cmdNo.Image"), System.Drawing.Image)
        Me.cmdNo.ImageAlign = CType(resources.GetObject("cmdNo.ImageAlign"), System.Drawing.ContentAlignment)
        Me.cmdNo.ImageIndex = CType(resources.GetObject("cmdNo.ImageIndex"), Integer)
        Me.cmdNo.ImeMode = CType(resources.GetObject("cmdNo.ImeMode"), System.Windows.Forms.ImeMode)
        Me.cmdNo.Location = CType(resources.GetObject("cmdNo.Location"), System.Drawing.Point)
        Me.cmdNo.Name = "cmdNo"
        Me.cmdNo.RightToLeft = CType(resources.GetObject("cmdNo.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.cmdNo.Size = CType(resources.GetObject("cmdNo.Size"), System.Drawing.Size)
        Me.cmdNo.TabIndex = CType(resources.GetObject("cmdNo.TabIndex"), Integer)
        Me.cmdNo.Text = resources.GetString("cmdNo.Text")
        Me.cmdNo.TextAlign = CType(resources.GetObject("cmdNo.TextAlign"), System.Drawing.ContentAlignment)
        Me.cmdNo.Visible = CType(resources.GetObject("cmdNo.Visible"), Boolean)
        '
        'cmdYes
        '
        Me.cmdYes.AccessibleDescription = resources.GetString("cmdYes.AccessibleDescription")
        Me.cmdYes.AccessibleName = resources.GetString("cmdYes.AccessibleName")
        Me.cmdYes.Anchor = CType(resources.GetObject("cmdYes.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.cmdYes.BackgroundImage = CType(resources.GetObject("cmdYes.BackgroundImage"), System.Drawing.Image)
        Me.cmdYes.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdYes.DialogResult = System.Windows.Forms.DialogResult.Yes
        Me.cmdYes.Dock = CType(resources.GetObject("cmdYes.Dock"), System.Windows.Forms.DockStyle)
        Me.cmdYes.Enabled = CType(resources.GetObject("cmdYes.Enabled"), Boolean)
        Me.cmdYes.FlatStyle = CType(resources.GetObject("cmdYes.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.cmdYes.Font = CType(resources.GetObject("cmdYes.Font"), System.Drawing.Font)
        Me.cmdYes.Image = CType(resources.GetObject("cmdYes.Image"), System.Drawing.Image)
        Me.cmdYes.ImageAlign = CType(resources.GetObject("cmdYes.ImageAlign"), System.Drawing.ContentAlignment)
        Me.cmdYes.ImageIndex = CType(resources.GetObject("cmdYes.ImageIndex"), Integer)
        Me.cmdYes.ImeMode = CType(resources.GetObject("cmdYes.ImeMode"), System.Windows.Forms.ImeMode)
        Me.cmdYes.Location = CType(resources.GetObject("cmdYes.Location"), System.Drawing.Point)
        Me.cmdYes.Name = "cmdYes"
        Me.cmdYes.RightToLeft = CType(resources.GetObject("cmdYes.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.cmdYes.Size = CType(resources.GetObject("cmdYes.Size"), System.Drawing.Size)
        Me.cmdYes.TabIndex = CType(resources.GetObject("cmdYes.TabIndex"), Integer)
        Me.cmdYes.Text = resources.GetString("cmdYes.Text")
        Me.cmdYes.TextAlign = CType(resources.GetObject("cmdYes.TextAlign"), System.Drawing.ContentAlignment)
        Me.cmdYes.Visible = CType(resources.GetObject("cmdYes.Visible"), Boolean)
        '
        'cmdOk
        '
        Me.cmdOk.AccessibleDescription = resources.GetString("cmdOk.AccessibleDescription")
        Me.cmdOk.AccessibleName = resources.GetString("cmdOk.AccessibleName")
        Me.cmdOk.Anchor = CType(resources.GetObject("cmdOk.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.cmdOk.BackgroundImage = CType(resources.GetObject("cmdOk.BackgroundImage"), System.Drawing.Image)
        Me.cmdOk.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdOk.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.cmdOk.Dock = CType(resources.GetObject("cmdOk.Dock"), System.Windows.Forms.DockStyle)
        Me.cmdOk.Enabled = CType(resources.GetObject("cmdOk.Enabled"), Boolean)
        Me.cmdOk.FlatStyle = CType(resources.GetObject("cmdOk.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.cmdOk.Font = CType(resources.GetObject("cmdOk.Font"), System.Drawing.Font)
        Me.cmdOk.Image = CType(resources.GetObject("cmdOk.Image"), System.Drawing.Image)
        Me.cmdOk.ImageAlign = CType(resources.GetObject("cmdOk.ImageAlign"), System.Drawing.ContentAlignment)
        Me.cmdOk.ImageIndex = CType(resources.GetObject("cmdOk.ImageIndex"), Integer)
        Me.cmdOk.ImeMode = CType(resources.GetObject("cmdOk.ImeMode"), System.Windows.Forms.ImeMode)
        Me.cmdOk.Location = CType(resources.GetObject("cmdOk.Location"), System.Drawing.Point)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.RightToLeft = CType(resources.GetObject("cmdOk.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.cmdOk.Size = CType(resources.GetObject("cmdOk.Size"), System.Drawing.Size)
        Me.cmdOk.TabIndex = CType(resources.GetObject("cmdOk.TabIndex"), Integer)
        Me.cmdOk.Text = resources.GetString("cmdOk.Text")
        Me.cmdOk.TextAlign = CType(resources.GetObject("cmdOk.TextAlign"), System.Drawing.ContentAlignment)
        Me.cmdOk.Visible = CType(resources.GetObject("cmdOk.Visible"), Boolean)
        '
        'picMessage
        '
        Me.picMessage.AccessibleDescription = resources.GetString("picMessage.AccessibleDescription")
        Me.picMessage.AccessibleName = resources.GetString("picMessage.AccessibleName")
        Me.picMessage.Anchor = CType(resources.GetObject("picMessage.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.picMessage.BackgroundImage = CType(resources.GetObject("picMessage.BackgroundImage"), System.Drawing.Image)
        Me.picMessage.Dock = CType(resources.GetObject("picMessage.Dock"), System.Windows.Forms.DockStyle)
        Me.picMessage.Enabled = CType(resources.GetObject("picMessage.Enabled"), Boolean)
        Me.picMessage.Font = CType(resources.GetObject("picMessage.Font"), System.Drawing.Font)
        Me.picMessage.Image = CType(resources.GetObject("picMessage.Image"), System.Drawing.Image)
        Me.picMessage.ImeMode = CType(resources.GetObject("picMessage.ImeMode"), System.Windows.Forms.ImeMode)
        Me.picMessage.Location = CType(resources.GetObject("picMessage.Location"), System.Drawing.Point)
        Me.picMessage.Name = "picMessage"
        Me.picMessage.RightToLeft = CType(resources.GetObject("picMessage.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.picMessage.Size = CType(resources.GetObject("picMessage.Size"), System.Drawing.Size)
        Me.picMessage.SizeMode = CType(resources.GetObject("picMessage.SizeMode"), System.Windows.Forms.PictureBoxSizeMode)
        Me.picMessage.TabIndex = CType(resources.GetObject("picMessage.TabIndex"), Integer)
        Me.picMessage.TabStop = False
        Me.picMessage.Text = resources.GetString("picMessage.Text")
        Me.picMessage.Visible = CType(resources.GetObject("picMessage.Visible"), Boolean)
        '
        'lblMessage
        '
        Me.lblMessage.AccessibleDescription = resources.GetString("lblMessage.AccessibleDescription")
        Me.lblMessage.AccessibleName = resources.GetString("lblMessage.AccessibleName")
        Me.lblMessage.Anchor = CType(resources.GetObject("lblMessage.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.lblMessage.AutoSize = CType(resources.GetObject("lblMessage.AutoSize"), Boolean)
        Me.lblMessage.Dock = CType(resources.GetObject("lblMessage.Dock"), System.Windows.Forms.DockStyle)
        Me.lblMessage.Enabled = CType(resources.GetObject("lblMessage.Enabled"), Boolean)
        Me.lblMessage.Font = CType(resources.GetObject("lblMessage.Font"), System.Drawing.Font)
        Me.lblMessage.Image = CType(resources.GetObject("lblMessage.Image"), System.Drawing.Image)
        Me.lblMessage.ImageAlign = CType(resources.GetObject("lblMessage.ImageAlign"), System.Drawing.ContentAlignment)
        Me.lblMessage.ImageIndex = CType(resources.GetObject("lblMessage.ImageIndex"), Integer)
        Me.lblMessage.ImeMode = CType(resources.GetObject("lblMessage.ImeMode"), System.Windows.Forms.ImeMode)
        Me.lblMessage.Location = CType(resources.GetObject("lblMessage.Location"), System.Drawing.Point)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.RightToLeft = CType(resources.GetObject("lblMessage.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.lblMessage.Size = CType(resources.GetObject("lblMessage.Size"), System.Drawing.Size)
        Me.lblMessage.TabIndex = CType(resources.GetObject("lblMessage.TabIndex"), Integer)
        Me.lblMessage.Text = resources.GetString("lblMessage.Text")
        Me.lblMessage.TextAlign = CType(resources.GetObject("lblMessage.TextAlign"), System.Drawing.ContentAlignment)
        Me.lblMessage.Visible = CType(resources.GetObject("lblMessage.Visible"), Boolean)
        '
        'ImgLstMessage
        '
        Me.ImgLstMessage.ImageSize = CType(resources.GetObject("ImgLstMessage.ImageSize"), System.Drawing.Size)
        Me.ImgLstMessage.ImageStream = CType(resources.GetObject("ImgLstMessage.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImgLstMessage.TransparentColor = System.Drawing.Color.Transparent
        '
        'GroupBox1
        '
        Me.GroupBox1.AccessibleDescription = resources.GetString("GroupBox1.AccessibleDescription")
        Me.GroupBox1.AccessibleName = resources.GetString("GroupBox1.AccessibleName")
        Me.GroupBox1.Anchor = CType(resources.GetObject("GroupBox1.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.BackgroundImage = CType(resources.GetObject("GroupBox1.BackgroundImage"), System.Drawing.Image)
        Me.GroupBox1.Controls.Add(Me.picMessage)
        Me.GroupBox1.Controls.Add(Me.lblMessage)
        Me.GroupBox1.Dock = CType(resources.GetObject("GroupBox1.Dock"), System.Windows.Forms.DockStyle)
        Me.GroupBox1.Enabled = CType(resources.GetObject("GroupBox1.Enabled"), Boolean)
        Me.GroupBox1.Font = CType(resources.GetObject("GroupBox1.Font"), System.Drawing.Font)
        Me.GroupBox1.ImeMode = CType(resources.GetObject("GroupBox1.ImeMode"), System.Windows.Forms.ImeMode)
        Me.GroupBox1.Location = CType(resources.GetObject("GroupBox1.Location"), System.Drawing.Point)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.RightToLeft = CType(resources.GetObject("GroupBox1.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.GroupBox1.Size = CType(resources.GetObject("GroupBox1.Size"), System.Drawing.Size)
        Me.GroupBox1.TabIndex = CType(resources.GetObject("GroupBox1.TabIndex"), Integer)
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = resources.GetString("GroupBox1.Text")
        Me.GroupBox1.Visible = CType(resources.GetObject("GroupBox1.Visible"), Boolean)
        '
        'frmMessage1
        '
        Me.AccessibleDescription = resources.GetString("$this.AccessibleDescription")
        Me.AccessibleName = resources.GetString("$this.AccessibleName")
        Me.AutoScaleBaseSize = CType(resources.GetObject("$this.AutoScaleBaseSize"), System.Drawing.Size)
        Me.AutoScroll = CType(resources.GetObject("$this.AutoScroll"), Boolean)
        Me.AutoScrollMargin = CType(resources.GetObject("$this.AutoScrollMargin"), System.Drawing.Size)
        Me.AutoScrollMinSize = CType(resources.GetObject("$this.AutoScrollMinSize"), System.Drawing.Size)
        Me.BackColor = System.Drawing.Color.Linen
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = CType(resources.GetObject("$this.ClientSize"), System.Drawing.Size)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmdNo)
        Me.Controls.Add(Me.cmdYes)
        Me.Controls.Add(Me.cmdOk)
        Me.Enabled = CType(resources.GetObject("$this.Enabled"), Boolean)
        Me.Font = CType(resources.GetObject("$this.Font"), System.Drawing.Font)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.ImeMode = CType(resources.GetObject("$this.ImeMode"), System.Windows.Forms.ImeMode)
        Me.Location = CType(resources.GetObject("$this.Location"), System.Drawing.Point)
        Me.MaximumSize = CType(resources.GetObject("$this.MaximumSize"), System.Drawing.Size)
        Me.MinimumSize = CType(resources.GetObject("$this.MinimumSize"), System.Drawing.Size)
        Me.Name = "frmMessage1"
        Me.RightToLeft = CType(resources.GetObject("$this.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.StartPosition = CType(resources.GetObject("$this.StartPosition"), System.Windows.Forms.FormStartPosition)
        Me.Text = resources.GetString("$this.Text")
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    
   
End Class
