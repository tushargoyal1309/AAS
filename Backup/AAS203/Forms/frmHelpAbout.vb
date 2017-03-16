Public Class frmHelpAbout
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
    Friend WithEvents AAS_picture As System.Windows.Forms.PictureBox
    Friend WithEvents aasDB_picture As System.Windows.Forms.PictureBox
    Friend WithEvents lblVersion As System.Windows.Forms.Label
    Friend WithEvents lblCompany As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmHelpAbout))
        Me.AAS_picture = New System.Windows.Forms.PictureBox
        Me.aasDB_picture = New System.Windows.Forms.PictureBox
        Me.lblVersion = New System.Windows.Forms.Label
        Me.lblCompany = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'AAS_picture
        '
        Me.AAS_picture.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AAS_picture.Image = CType(resources.GetObject("AAS_picture.Image"), System.Drawing.Image)
        Me.AAS_picture.Location = New System.Drawing.Point(0, 0)
        Me.AAS_picture.Name = "AAS_picture"
        Me.AAS_picture.Size = New System.Drawing.Size(486, 340)
        Me.AAS_picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.AAS_picture.TabIndex = 0
        Me.AAS_picture.TabStop = False
        '
        'aasDB_picture
        '
        Me.aasDB_picture.Dock = System.Windows.Forms.DockStyle.Fill
        Me.aasDB_picture.Image = CType(resources.GetObject("aasDB_picture.Image"), System.Drawing.Image)
        Me.aasDB_picture.Location = New System.Drawing.Point(0, 0)
        Me.aasDB_picture.Name = "aasDB_picture"
        Me.aasDB_picture.Size = New System.Drawing.Size(486, 340)
        Me.aasDB_picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.aasDB_picture.TabIndex = 1
        Me.aasDB_picture.TabStop = False
        '
        'lblVersion
        '
        Me.lblVersion.BackColor = System.Drawing.Color.White
        Me.lblVersion.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVersion.Location = New System.Drawing.Point(24, 135)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(472, 24)
        Me.lblVersion.TabIndex = 2
        '
        'lblCompany
        '
        Me.lblCompany.BackColor = System.Drawing.Color.White
        Me.lblCompany.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCompany.Location = New System.Drawing.Point(24, 161)
        Me.lblCompany.Name = "lblCompany"
        Me.lblCompany.Size = New System.Drawing.Size(472, 24)
        Me.lblCompany.TabIndex = 3
        '
        'frmHelpAbout
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(486, 340)
        Me.Controls.Add(Me.aasDB_picture)
        Me.Controls.Add(Me.lblCompany)
        Me.Controls.Add(Me.lblVersion)
        Me.Controls.Add(Me.AAS_picture)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmHelpAbout"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "About"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub frmHelpAbout_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblVersion.BringToFront()
        lblCompany.BringToFront()
        lblVersion.Text = gstrTitleInstrumentType & Space(1) & "Software Version :" & Space(1) & Mid(Application.ProductVersion, 1, 4)
        lblCompany.Text = gConst_AboutCompany
    End Sub

End Class
