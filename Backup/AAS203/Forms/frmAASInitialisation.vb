Imports AAS203Library
Imports AAS203Library.Instrument

Public Class frmAASInitialisation
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
    Public WithEvents ImgInit As System.Windows.Forms.ImageList
    Friend WithEvents lblInstrumentType As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents pnlStepList As System.Windows.Forms.Panel
    Friend WithEvents lblStep7 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lblStep6 As System.Windows.Forms.Label
    Friend WithEvents lblStep5 As System.Windows.Forms.Label
    Friend WithEvents lblStep4 As System.Windows.Forms.Label
    Friend WithEvents lblStep3 As System.Windows.Forms.Label
    Friend WithEvents lblStep2 As System.Windows.Forms.Label
    Friend WithEvents lblStep1 As System.Windows.Forms.Label
    Friend WithEvents lblStatus1 As System.Windows.Forms.Label
    Friend WithEvents lblStatus2 As System.Windows.Forms.Label
    Friend WithEvents lblStatus3 As System.Windows.Forms.Label
    Friend WithEvents lblStatus4 As System.Windows.Forms.Label
    Friend WithEvents lblStatus5 As System.Windows.Forms.Label
    Friend WithEvents lblStatus6 As System.Windows.Forms.Label
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents lblStatus7 As System.Windows.Forms.Label
    Friend WithEvents lblStatus8 As System.Windows.Forms.Label
    Friend WithEvents lblStep8 As System.Windows.Forms.Label
    Friend WithEvents PictureBox3_DB As System.Windows.Forms.PictureBox
    Friend WithEvents lbltitle_DB As System.Windows.Forms.Label
    Friend WithEvents lbl21CFR As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmAASInitialisation))
        Me.ImgInit = New System.Windows.Forms.ImageList(Me.components)
        Me.lblInstrumentType = New System.Windows.Forms.Label
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.pnlStepList = New System.Windows.Forms.Panel
        Me.lblStatus8 = New System.Windows.Forms.Label
        Me.lblStep8 = New System.Windows.Forms.Label
        Me.lblStatus7 = New System.Windows.Forms.Label
        Me.lblTitle = New System.Windows.Forms.Label
        Me.lblStatus6 = New System.Windows.Forms.Label
        Me.lblStatus5 = New System.Windows.Forms.Label
        Me.lblStatus4 = New System.Windows.Forms.Label
        Me.lblStatus3 = New System.Windows.Forms.Label
        Me.lblStatus2 = New System.Windows.Forms.Label
        Me.lblStatus1 = New System.Windows.Forms.Label
        Me.lblStep7 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.lblStep6 = New System.Windows.Forms.Label
        Me.lblStep5 = New System.Windows.Forms.Label
        Me.lblStep4 = New System.Windows.Forms.Label
        Me.lblStep3 = New System.Windows.Forms.Label
        Me.lblStep2 = New System.Windows.Forms.Label
        Me.lblStep1 = New System.Windows.Forms.Label
        Me.PictureBox3_DB = New System.Windows.Forms.PictureBox
        Me.lbltitle_DB = New System.Windows.Forms.Label
        Me.lbl21CFR = New System.Windows.Forms.Label
        Me.pnlStepList.SuspendLayout()
        Me.SuspendLayout()
        '
        'ImgInit
        '
        Me.ImgInit.ColorDepth = System.Windows.Forms.ColorDepth.Depth16Bit
        Me.ImgInit.ImageSize = New System.Drawing.Size(16, 15)
        Me.ImgInit.ImageStream = CType(resources.GetObject("ImgInit.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImgInit.TransparentColor = System.Drawing.Color.Empty
        '
        'lblInstrumentType
        '
        Me.lblInstrumentType.BackColor = System.Drawing.Color.Transparent
        Me.lblInstrumentType.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInstrumentType.ForeColor = System.Drawing.Color.MidnightBlue
        Me.lblInstrumentType.Location = New System.Drawing.Point(183, 65)
        Me.lblInstrumentType.Name = "lblInstrumentType"
        Me.lblInstrumentType.Size = New System.Drawing.Size(456, 27)
        Me.lblInstrumentType.TabIndex = 12
        Me.lblInstrumentType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox2
        '
        Me.PictureBox2.BackgroundImage = CType(resources.GetObject("PictureBox2.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(0, -3)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(146, 408)
        Me.PictureBox2.TabIndex = 14
        Me.PictureBox2.TabStop = False
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label3.Location = New System.Drawing.Point(183, 39)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(456, 27)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Atomic Absorption Spectrometer "
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlStepList
        '
        Me.pnlStepList.BackColor = System.Drawing.Color.Transparent
        Me.pnlStepList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlStepList.Controls.Add(Me.lblStatus8)
        Me.pnlStepList.Controls.Add(Me.lblStep8)
        Me.pnlStepList.Controls.Add(Me.lblStatus7)
        Me.pnlStepList.Controls.Add(Me.lblTitle)
        Me.pnlStepList.Controls.Add(Me.lblStatus6)
        Me.pnlStepList.Controls.Add(Me.lblStatus5)
        Me.pnlStepList.Controls.Add(Me.lblStatus4)
        Me.pnlStepList.Controls.Add(Me.lblStatus3)
        Me.pnlStepList.Controls.Add(Me.lblStatus2)
        Me.pnlStepList.Controls.Add(Me.lblStatus1)
        Me.pnlStepList.Controls.Add(Me.lblStep7)
        Me.pnlStepList.Controls.Add(Me.PictureBox1)
        Me.pnlStepList.Controls.Add(Me.lblStep6)
        Me.pnlStepList.Controls.Add(Me.lblStep5)
        Me.pnlStepList.Controls.Add(Me.lblStep4)
        Me.pnlStepList.Controls.Add(Me.lblStep3)
        Me.pnlStepList.Controls.Add(Me.lblStep2)
        Me.pnlStepList.Controls.Add(Me.lblStep1)
        Me.pnlStepList.Location = New System.Drawing.Point(156, 117)
        Me.pnlStepList.Name = "pnlStepList"
        Me.pnlStepList.Size = New System.Drawing.Size(510, 266)
        Me.pnlStepList.TabIndex = 11
        '
        'lblStatus8
        '
        Me.lblStatus8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus8.Location = New System.Drawing.Point(338, 216)
        Me.lblStatus8.Name = "lblStatus8"
        Me.lblStatus8.Size = New System.Drawing.Size(150, 24)
        Me.lblStatus8.TabIndex = 24
        Me.lblStatus8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblStep8
        '
        Me.lblStep8.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStep8.ForeColor = System.Drawing.Color.MidnightBlue
        Me.lblStep8.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblStep8.ImageIndex = 0
        Me.lblStep8.ImageList = Me.ImgInit
        Me.lblStep8.Location = New System.Drawing.Point(28, 216)
        Me.lblStep8.Name = "lblStep8"
        Me.lblStep8.Size = New System.Drawing.Size(302, 24)
        Me.lblStep8.TabIndex = 23
        Me.lblStep8.Tag = "7"
        Me.lblStep8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblStep8.Visible = False
        '
        'lblStatus7
        '
        Me.lblStatus7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus7.Location = New System.Drawing.Point(338, 192)
        Me.lblStatus7.Name = "lblStatus7"
        Me.lblStatus7.Size = New System.Drawing.Size(150, 24)
        Me.lblStatus7.TabIndex = 22
        Me.lblStatus7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTitle
        '
        Me.lblTitle.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.lblTitle.Location = New System.Drawing.Point(52, 6)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(418, 18)
        Me.lblTitle.TabIndex = 21
        Me.lblTitle.Text = "Self Diagnosis"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblStatus6
        '
        Me.lblStatus6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus6.Location = New System.Drawing.Point(338, 168)
        Me.lblStatus6.Name = "lblStatus6"
        Me.lblStatus6.Size = New System.Drawing.Size(150, 24)
        Me.lblStatus6.TabIndex = 20
        Me.lblStatus6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblStatus5
        '
        Me.lblStatus5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus5.Location = New System.Drawing.Point(338, 144)
        Me.lblStatus5.Name = "lblStatus5"
        Me.lblStatus5.Size = New System.Drawing.Size(150, 24)
        Me.lblStatus5.TabIndex = 19
        Me.lblStatus5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblStatus4
        '
        Me.lblStatus4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus4.Location = New System.Drawing.Point(338, 120)
        Me.lblStatus4.Name = "lblStatus4"
        Me.lblStatus4.Size = New System.Drawing.Size(150, 24)
        Me.lblStatus4.TabIndex = 18
        Me.lblStatus4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblStatus3
        '
        Me.lblStatus3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus3.Location = New System.Drawing.Point(338, 96)
        Me.lblStatus3.Name = "lblStatus3"
        Me.lblStatus3.Size = New System.Drawing.Size(150, 24)
        Me.lblStatus3.TabIndex = 17
        Me.lblStatus3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblStatus2
        '
        Me.lblStatus2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus2.Location = New System.Drawing.Point(338, 72)
        Me.lblStatus2.Name = "lblStatus2"
        Me.lblStatus2.Size = New System.Drawing.Size(150, 24)
        Me.lblStatus2.TabIndex = 16
        Me.lblStatus2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblStatus1
        '
        Me.lblStatus1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus1.Location = New System.Drawing.Point(338, 48)
        Me.lblStatus1.Name = "lblStatus1"
        Me.lblStatus1.Size = New System.Drawing.Size(150, 24)
        Me.lblStatus1.TabIndex = 15
        Me.lblStatus1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblStep7
        '
        Me.lblStep7.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStep7.ForeColor = System.Drawing.Color.MidnightBlue
        Me.lblStep7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblStep7.ImageIndex = 0
        Me.lblStep7.ImageList = Me.ImgInit
        Me.lblStep7.Location = New System.Drawing.Point(28, 192)
        Me.lblStep7.Name = "lblStep7"
        Me.lblStep7.Size = New System.Drawing.Size(302, 24)
        Me.lblStep7.TabIndex = 14
        Me.lblStep7.Tag = "7"
        Me.lblStep7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblStep7.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Location = New System.Drawing.Point(-2, 26)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(524, 2)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'lblStep6
        '
        Me.lblStep6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStep6.ForeColor = System.Drawing.Color.MidnightBlue
        Me.lblStep6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblStep6.ImageIndex = 0
        Me.lblStep6.ImageList = Me.ImgInit
        Me.lblStep6.Location = New System.Drawing.Point(28, 168)
        Me.lblStep6.Name = "lblStep6"
        Me.lblStep6.Size = New System.Drawing.Size(302, 24)
        Me.lblStep6.TabIndex = 7
        Me.lblStep6.Tag = "6"
        Me.lblStep6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblStep6.Visible = False
        '
        'lblStep5
        '
        Me.lblStep5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStep5.ForeColor = System.Drawing.Color.MidnightBlue
        Me.lblStep5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblStep5.ImageIndex = 0
        Me.lblStep5.ImageList = Me.ImgInit
        Me.lblStep5.Location = New System.Drawing.Point(28, 144)
        Me.lblStep5.Name = "lblStep5"
        Me.lblStep5.Size = New System.Drawing.Size(302, 24)
        Me.lblStep5.TabIndex = 6
        Me.lblStep5.Tag = "5"
        Me.lblStep5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblStep5.Visible = False
        '
        'lblStep4
        '
        Me.lblStep4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStep4.ForeColor = System.Drawing.Color.MidnightBlue
        Me.lblStep4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblStep4.ImageIndex = 0
        Me.lblStep4.ImageList = Me.ImgInit
        Me.lblStep4.Location = New System.Drawing.Point(28, 120)
        Me.lblStep4.Name = "lblStep4"
        Me.lblStep4.Size = New System.Drawing.Size(302, 24)
        Me.lblStep4.TabIndex = 5
        Me.lblStep4.Tag = "4"
        Me.lblStep4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblStep4.Visible = False
        '
        'lblStep3
        '
        Me.lblStep3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStep3.ForeColor = System.Drawing.Color.MidnightBlue
        Me.lblStep3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblStep3.ImageIndex = 0
        Me.lblStep3.ImageList = Me.ImgInit
        Me.lblStep3.Location = New System.Drawing.Point(28, 96)
        Me.lblStep3.Name = "lblStep3"
        Me.lblStep3.Size = New System.Drawing.Size(302, 24)
        Me.lblStep3.TabIndex = 4
        Me.lblStep3.Tag = "3"
        Me.lblStep3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblStep3.Visible = False
        '
        'lblStep2
        '
        Me.lblStep2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStep2.ForeColor = System.Drawing.Color.MidnightBlue
        Me.lblStep2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblStep2.ImageIndex = 0
        Me.lblStep2.ImageList = Me.ImgInit
        Me.lblStep2.Location = New System.Drawing.Point(28, 72)
        Me.lblStep2.Name = "lblStep2"
        Me.lblStep2.Size = New System.Drawing.Size(302, 24)
        Me.lblStep2.TabIndex = 3
        Me.lblStep2.Tag = "2"
        Me.lblStep2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblStep2.Visible = False
        '
        'lblStep1
        '
        Me.lblStep1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStep1.ForeColor = System.Drawing.Color.MidnightBlue
        Me.lblStep1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblStep1.ImageIndex = 0
        Me.lblStep1.ImageList = Me.ImgInit
        Me.lblStep1.Location = New System.Drawing.Point(28, 48)
        Me.lblStep1.Name = "lblStep1"
        Me.lblStep1.Size = New System.Drawing.Size(302, 24)
        Me.lblStep1.TabIndex = 2
        Me.lblStep1.Tag = "1"
        Me.lblStep1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblStep1.Visible = False
        '
        'PictureBox3_DB
        '
        Me.PictureBox3_DB.BackgroundImage = CType(resources.GetObject("PictureBox3_DB.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox3_DB.Image = CType(resources.GetObject("PictureBox3_DB.Image"), System.Drawing.Image)
        Me.PictureBox3_DB.Location = New System.Drawing.Point(0, -3)
        Me.PictureBox3_DB.Name = "PictureBox3_DB"
        Me.PictureBox3_DB.Size = New System.Drawing.Size(146, 408)
        Me.PictureBox3_DB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3_DB.TabIndex = 15
        Me.PictureBox3_DB.TabStop = False
        Me.PictureBox3_DB.Visible = False
        '
        'lbltitle_DB
        '
        Me.lbltitle_DB.BackColor = System.Drawing.Color.Transparent
        Me.lbltitle_DB.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltitle_DB.ForeColor = System.Drawing.Color.MidnightBlue
        Me.lbltitle_DB.Location = New System.Drawing.Point(183, 12)
        Me.lbltitle_DB.Name = "lbltitle_DB"
        Me.lbltitle_DB.Size = New System.Drawing.Size(456, 27)
        Me.lbltitle_DB.TabIndex = 16
        Me.lbltitle_DB.Text = "Double Beam"
        Me.lbltitle_DB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lbltitle_DB.Visible = False
        '
        'lbl21CFR
        '
        Me.lbl21CFR.BackColor = System.Drawing.Color.Transparent
        Me.lbl21CFR.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl21CFR.ForeColor = System.Drawing.Color.MidnightBlue
        Me.lbl21CFR.Location = New System.Drawing.Point(218, 96)
        Me.lbl21CFR.Name = "lbl21CFR"
        Me.lbl21CFR.Size = New System.Drawing.Size(386, 16)
        Me.lbl21CFR.TabIndex = 17
        Me.lbl21CFR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmAASInitialisation
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(688, 403)
        Me.ControlBox = False
        Me.Controls.Add(Me.lbl21CFR)
        Me.Controls.Add(Me.lbltitle_DB)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.pnlStepList)
        Me.Controls.Add(Me.lblInstrumentType)
        Me.Controls.Add(Me.PictureBox3_DB)
        Me.Controls.Add(Me.PictureBox2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmAASInitialisation"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.pnlStepList.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Form Load and Event Handling functions "

    Private Sub frmAASInitialisation_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name         :   frmAASInitialisation_Load
        'Description            :   This is called when initialisation form is loaded       
        'Parameters             :   None from user.
        'Time/Date              :   25/9/06
        'Dependencies           :   
        'Author                 :   Rahul B.
        'Revision               :
        'Revision by Person     :praveen
        '--------------------------------------------------------------------------------------
        ''note:
        ''this is called when the form is loaded 
        ''this will perfrom some initialisation step here.
        Dim strAppVersion As String

        strAppVersion = Application.ProductVersion
        ''get a application product version to string variable.
        strAppVersion = Mid(strAppVersion, 1, 3)

        Select Case gstructSettings.AppMode
            ''set a instrumentaType as per applwication mode.
        Case EnumAppMode.FullVersion_201
                '--4.85  14.04.09
                If gstructSettings.NewModelName = False Then
                    gstrTitleInstrumentType = "AA 201"
                Else
                    gstrTitleInstrumentType = "AA 301"
                End If
                '--4.85  14.04.09


            Case EnumAppMode.FullVersion_203
                '--4.85  14.04.09
                If gstructSettings.NewModelName = False Then
                    gstrTitleInstrumentType = "AA 203"
                Else
                    gstrTitleInstrumentType = "AA 303"
                End If
                '--4.85  14.04.09

            Case EnumAppMode.FullVersion_203D
                '--4.85  14.04.09
                If gstructSettings.NewModelName = False Then
                    gstrTitleInstrumentType = "AA 203D"
                Else
                    gstrTitleInstrumentType = "AA 303D"
                End If
                '--4.85  14.04.09

                lbltitle_DB.Visible = True 'Added by pankaj on 29 Jan 08
                PictureBox3_DB.Visible = True 'Added by pankaj on 29 Jan 08
                PictureBox2.Visible = False 'Added by pankaj on 29 Jan 08

            Case EnumAppMode.DemoMode
                    gstrTitleInstrumentType = "AA DEMO"

        End Select

        '---commented by Deepak on 25.08.10
        '18.4.2010  by dinesh wagh
        '---------
        'If gstructSettings.Enable21CFR = True Then
        '    lbl21CFR.Text = "21CFR part 11"
        'Else
        '    lblInstrumentType.Location = New Point(lblInstrumentType.Location.X, lblInstrumentType.Location.Y + 10)
        'End If
        '----------

        '---written by Deepak on 25.08.10
        If gstructSettings.CFR21Installation = True And gstructSettings.EnableIQOQPQ = False Then
            lbl21CFR.Text = "21CFR Part 11"
        ElseIf gstructSettings.CFR21Installation = False And gstructSettings.EnableIQOQPQ = True Then
            lbl21CFR.Text = "IQOQPQ"
        ElseIf gstructSettings.CFR21Installation = True And gstructSettings.EnableIQOQPQ = True Then
            lbl21CFR.Text = "IQOQPQ / 21CFR Part 11"
        Else
            lblInstrumentType.Location = New Point(lblInstrumentType.Location.X, lblInstrumentType.Location.Y + 10)
        End If
        '---------------------------


        lblInstrumentType.Text = gstrTitleInstrumentType & " Software Version : " & strAppVersion
        Application.DoEvents()
        ''show the current status
        ''and allow application to perfrom its panding work.

    End Sub

#End Region

#Region " Private Functions "

    Private Sub subDisplayIntializationSteps_203()
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name         :   subDisplayIntializationSteps_203
        'Description            :   To display initialisation steps of AAS on screen        
        'Parameters             :   None
        'Time/Date              :   25/9/06
        'Dependencies           :   
        'Author                 :   Rahul B.
        'Revision               :
        'Revision by Person     :   Praveen
        '--------------------------------------------------------------------------------------
        Try
            ''note:
            ''this is used to display a 6 step one by one.

            lblStep1.Visible = True
            lblStep1.Text = Space(7) & "Initializing 6-Position Turret Mechanism"
            lblStep1.Refresh()

            lblStep2.Visible = True
            lblStep2.Text = Space(7) & "Initializing Wavelength Drive"
            lblStep2.Refresh()

            lblStep3.Visible = True
            lblStep3.Text = Space(7) & "Initializing Slit Assembly"
            lblStep3.Refresh()

            lblStep4.Visible = True
            lblStep4.Text = Space(7) & "Initializing Pneumatic Assembly"
            lblStep4.Refresh()

            lblStep5.Visible = True
            lblStep5.Text = Space(7) & "Analog Self Test"
            lblStep5.Refresh()

            lblStep6.Visible = True
            lblStep6.Text = Space(7) & "Setting up Optimum Parameters .... "
            lblStep6.Refresh()

        Catch ex As Exception
            '---------------------------------------------------------
            'Error logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub subDisplayIntializationSteps_203D()
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name         :   subDisplayIntializationSteps_203D
        'Description            :   To display initialisation steps of AAS on screen        
        'Parameters             :   None
        'Time/Date              :   12-Apr-2007
        'Dependencies           :   
        'Author                 :   Mangesh Shardul
        'Revision               :
        'Revision by Person     :
        '--------------------------------------------------------------------------------------
        Try
            ''note:
            ''this is used to display a initialise step for 203D instrument.
            lblStep1.Visible = True
            lblStep1.Text = Space(7) & "Initializing 6-Position Turret Mechanism"
            lblStep1.Refresh()

            lblStep2.Visible = True
            lblStep2.Text = Space(7) & "Initializing Wavelength Drive"
            lblStep2.Refresh()

            lblStep3.Visible = True
            lblStep3.Text = Space(7) & "Initializing Entrance Slit Assembly"
            lblStep3.Refresh()

            lblStep4.Visible = True
            lblStep4.Text = Space(7) & "Initializing Exit Slit Assembly"
            lblStep4.Refresh()

            lblStep5.Visible = True
            lblStep5.Text = Space(7) & "Initializing Pneumatic Assembly"
            lblStep5.Refresh()

            lblStep6.Visible = True
            lblStep6.Text = Space(7) & "Analog Self Test Sample Beam"
            lblStep6.Refresh()

            lblStep7.Visible = True
            lblStep7.Text = Space(7) & "Analog Self Test Reference Beam"
            lblStep7.Refresh()

            lblStep8.Visible = True
            lblStep8.Text = Space(7) & "Setting up Optimum Parameters .... "
            lblStep8.Refresh()

        Catch ex As Exception
            '---------------------------------------------------------
            'Error logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub subDisplayIntializationSteps_AAS201()
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name         :   subDisplayIntializationSteps_AAS201
        'Description            :   To display initialisation steps of AAS 201 on screen        
        'Parameters             :   None
        'Time/Date              :   10-Apr-2007
        'Dependencies           :   
        'Author                 :   Mangesh Shardul
        'Revision               :
        'Revision by Person     :   Praveen
        '--------------------------------------------------------------------------------------
        Try

            ''note;
            ''this is used to show initialse step for 201
            lblStep1.Visible = False
            'lblStep1.Text = Space(7) & "Initializing 6-Position Turret Mechanism"
            'lblStep1.Refresh()

            lblStep2.Visible = True
            lblStep2.Text = Space(7) & "Initializing Wavelength Drive"
            lblStep2.Refresh()

            lblStep3.Visible = True
            lblStep3.Text = Space(7) & "Initializing Slit Assembly"
            lblStep3.Refresh()

            lblStep4.Visible = True
            lblStep4.Text = Space(7) & "Initializing Pneumatic Line"
            lblStep4.Refresh()

            lblStep5.Visible = True
            lblStep5.Text = Space(7) & "Analog Self Test"
            lblStep5.Refresh()

            lblStep6.Visible = True
            lblStep6.Text = Space(7) & "Setting up Optimum Parameters .... "
            lblStep6.Refresh()

        Catch ex As Exception
            '---------------------------------------------------------
            'Error logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Sub

    Private Function funcInitialization_AAS203() As Boolean
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name	    :   funcInitialization_AAS203
        'Description	    :   To do the initialization routines  (global.c Initialise)
        'Parameters 	    :   
        'Time/Date  	    :   26/9/2006
        'Dependencies	    :   
        'Author		        :   Rahul B.
        'Revision		    :
        'Revision by Person	:   Deepak B. on 20.11.06 major modifications done   
        'Revision by Person	:   Mangesh S. on 06-Apr-2007 Double Beam Changes
        '--------------------------------------------------------------------------------------
        Dim blnFlag As Boolean = False
        Dim intCount As Integer
        Dim dblPVTvalue As Double
        Dim a As Integer

        Try
            Call gobjClsAAS203.subSetInstrumentBeamType(enumInstrumentBeamType.SingleBeam)
            ''for setting instrument beam type as single beam
            '-----Set All lamp off
            If Not gobjCommProtocol.funcAll_Lamp_Off() Then
            End If
            Application.DoEvents()
            ''allow application to perfrom its panding work
            '-----Set PMT to Zero 
            '---For Single Beam (Sample)
            Call gobjCommProtocol.funcSet_PMT(0.0)
            ''for setting PMT to given value.
            Call Application.DoEvents()
            ''allow application to perfrom its panding work

            '--- Initialize turret to Home
            If gobjCommProtocol.gFuncTurret_Home() Then
                ''make a turrert at home position 
                lblStep1.Text = lblStep1.Text
                lblStatus1.Text = " OK LAMP1"
                lblStatus1.ForeColor = Color.Green
                lblStatus1.Refresh()
                lblStep1.ImageIndex = 1
                lblStep1.Refresh()
                ''display a current status
            Else
                lblStep1.Text = lblStep1.Text
                lblStatus1.Text = " ERROR"
                lblStatus1.ForeColor = Color.Red
                lblStatus1.Refresh()
                lblStep1.ImageIndex = 2
                lblStep1.Refresh()
            End If
            Application.DoEvents()
            ''allow application to perfrom its pending work.

            '--- Initialize Wavelength to Home
            If gobjCommProtocol.gFuncWavelength_Home() Then
                lblStep2.Text = lblStep2.Text
                lblStatus2.Text = " OK 0.00 nm"
                lblStatus2.ForeColor = Color.Green
                lblStatus2.Refresh()
                lblStep2.ImageIndex = 1
                lblStep2.Refresh()
                ''display a status on screen.
            Else
                ''else display a error on screen.
                lblStep2.Text = lblStep2.Text
                lblStatus2.Text = " ERROR"
                lblStatus2.ForeColor = Color.Red
                lblStatus2.Refresh()
                lblStep2.ImageIndex = 2
                lblStep2.Refresh()
            End If
            Application.DoEvents()

            '--- Initialize Slit to Home 
            '---For Single Beam (Sample)
            If gobjCommProtocol.gFuncSlit_Home() Then
                lblStep3.Text = lblStep3.Text
                lblStatus3.Text = " OK 2.0 nm"
                lblStatus3.ForeColor = Color.Green
                lblStatus3.Refresh()
                lblStep3.ImageIndex = 1
                lblStep3.Refresh()
                ''display a current status on screen 
            Else
                ''display a error on screen
                lblStep3.Text = lblStep3.Text
                lblStatus3.Text = " ERROR"
                lblStatus3.ForeColor = Color.Red
                lblStatus3.Refresh()
                lblStep3.ImageIndex = 2
                lblStep3.Refresh()
            End If
            Application.DoEvents()

            '--- Initialize Pneumatic
            If gobjCommProtocol.gFuncPneumatics() Then
                lblStep4.Text = lblStep4.Text
                lblStatus4.Text = " OK"
                lblStatus4.ForeColor = Color.Green
                lblStatus4.Refresh()
                lblStep4.ImageIndex = 1
                lblStep4.Refresh()
                ''display current status on screen
            Else
                ''else display error on screen
                lblStep4.Text = lblStep4.Text
                lblStatus4.Text = " ERROR"
                lblStatus4.ForeColor = Color.Red
                lblStatus4.Refresh()
                lblStep4.ImageIndex = 2
                lblStep4.Refresh()
            End If
            Application.DoEvents()
            ''allow application to perfrom its pending work.

            '---Perform Analog self test
            '---For Single Beam (Sample)
            If gobjCommProtocol.gFuncAnalogSelfTest(gobjInst.Average, dblPVTvalue) Then
                lblStep5.Text = lblStep5.Text
                lblStatus5.Text = " OK " & Format((gFuncGetmv(dblPVTvalue) / 1000), "0.00") & " V"
                lblStatus5.ForeColor = Color.Green
                lblStatus5.Refresh()
                lblStep5.ImageIndex = 1
                lblStep5.Refresh()
                ''display a current status onscreen
            Else
                ''else show a error on screen.
                lblStep5.Text = lblStep5.Text
                lblStatus5.Text = " ERROR"
                lblStatus5.ForeColor = Color.Red
                lblStatus5.Refresh()
                lblStep5.ImageIndex = 2
                lblStep5.Refresh()
            End If
            Application.DoEvents()

            lblStep6.Text = lblStep6.Text
            lblStatus6.Text = " Wait"
            lblStatus6.ForeColor = Color.Green
            lblStep6.Refresh()
            lblStatus6.Refresh()
            Application.DoEvents()

            '--- this function is written by deepak b on 16.11.06 for BH
            Call gobjCommProtocol.funcBH_File_read()
            Application.DoEvents()

            'Read Lamp Position if saved in file and load turret status
            'else search for lamp if present find wavelength home and optimise turret position for that lamp
            If funcLoadInstStatus() = False Then
                For intCount = 0 To 5
                    If gobjInst.Lamp.LampParametersCollection.item(intCount).ElementName <> "" Then
                        Exit For
                    End If
                Next
                If intCount = 6 Then
                    'OnLampPlace

                    '----Added by Mangesh on 11-Apr-2007 

                    Dim objfrmLampPlacements As frmLampPlacements
                    objfrmLampPlacements = New frmLampPlacements
                    If objfrmLampPlacements.ShowDialog() = DialogResult.OK Then
                        If Not IsNothing(objfrmLampPlacements.mobjInstrumentParameters) Then
                            Dim intLastLastPositionInLampPlacement As Integer = objfrmLampPlacements.mobjInstrumentParameters.TurretNumber
                            Dim dblCurrent As Double = objfrmLampPlacements.mobjInstrumentParameters.LampCurrent
                            'set current to lamp
                            Call gobjCommProtocol.funcSet_Lamp(True, dblCurrent, intLastLastPositionInLampPlacement)
                            Call gobjCommProtocol.funcOptimise_Turret_Position(dblCurrent, intLastLastPositionInLampPlacement)
                            'optimise turret position
                            Call Application.DoEvents()
                        End If
                    Else
                        Return False
                    End If


                Else
                    gobjInst.Lamp_Position = intCount + 1
                    Call gobjCommProtocol.funcOptimise_Turret_Position(gobjInst.Lamp.LampParametersCollection.item(gobjInst.Lamp_Position - 1).Current, gobjInst.Lamp_Position)
                    'OnOptimiseTurPos
                    If gstructSettings.ExeToRun = EnumApplicationMode.AAS Then
                        funcSaveInstStatus()
                    End If
                End If
            Else
                For intCount = 0 To 5
                    If gobjInst.Lamp.LampParametersCollection.item(intCount).ElementName <> "" Then
                        Exit For
                    End If
                Next
                If gobjCommProtocol.funcFind_Wavelength_Home() Then
                    If gobjCommProtocol.gFuncTurret_Position(intCount + 1, True) Then
                    End If
                Else

                End If
                Application.DoEvents()
            End If

            'D2 file Read
            gobjInst.D2Pmt = gstructSettings.D2Pmt

            'if (Read INI for D2 gain) then
            If gstructSettings.D2Gain = True Then
                If gobjCommProtocol.funcGain10X_OFF() Then
                Else
                End If
                Application.DoEvents()
            End If

            If gstructSettings.Mesh = True Then
                If gobjCommProtocol.funcSetMICRO_OFF() Then
                Else
                End If
                Application.DoEvents()
            End If

            If Not IsNothing(gobjfrmStatus) Then
                gobjfrmStatus.TurretNumber = gobjInst.Lamp_Position
                If gobjInst.Lamp_Position >= 1 Then
                    gobjfrmStatus.ElementName = gobjInst.Lamp.LampParametersCollection.item(gobjInst.Lamp_Position - 1).ElementName
                End If
                gobjfrmStatus.Refresh()
            End If
            gobjfrmStatus.Show()
            Application.DoEvents()

            'gobjfrmStatus.lblElementName.Text = gobjInst.Lamp.LampParametersCollection(0).ElementName()

            Return True

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            Return False
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Function

    Private Function funcInitialization_AAS203D() As Boolean
        '-------------------------------------------------------------------------
        'Procedure Name	    :   funcInitialization_AAS203D
        'Description	    :   To do the initialization routines  (global.c Initialise)
        'Parameters 	    :   
        'Time/Date  	    :   26/9/2006
        'Dependencies	    :   
        'Author		        :   Rahul B.
        'Revision		    :
        'Revision by Person	:   Deepak B. on 20.11.06 major modifications done   
        'Revision by Person	:   Mangesh S. on 06-Apr-2007 Double Beam Changes
        '-------------------------------------------------------------------------
        Dim blnFlag As Boolean = False
        Dim intCount As Integer
        Dim dblPVTvalue As Double
        Dim a As Integer

        Try
            Call gobjClsAAS203.subSetInstrumentBeamType(enumInstrumentBeamType.DoubleBeam, False)

            '-----Set All lamp off
            Call gobjCommProtocol.funcAll_Lamp_Off()
            Call Application.DoEvents()

            '-----Set PMT to Zero 
            '
            Call gobjCommProtocol.funcSet_PMT(0.0)

            If gintInstrumentBeamType = enumInstrumentBeamType.DoubleBeam Then
                '---For Double Beam (Reference)
                If Not gobjCommProtocol.funcSet_PMTReferenceBeam(0.0) Then
                    Call gobjMessageAdapter.ShowMessage(constPMTRange)
                    Call Application.DoEvents()
                End If
            End If
            Call Application.DoEvents()

            '--- Initialize turret to Home
            If gobjCommProtocol.gFuncTurret_Home() Then
                lblStep1.Text = lblStep1.Text
                lblStatus1.Text = " OK LAMP1"
                lblStatus1.ForeColor = Color.Green
                lblStatus1.Refresh()
                lblStep1.ImageIndex = 1
                lblStep1.Refresh()
            Else
                lblStep1.Text = lblStep1.Text
                lblStatus1.Text = " ERROR"
                lblStatus1.ForeColor = Color.Red
                lblStatus1.Refresh()
                lblStep1.ImageIndex = 2
                lblStep1.Refresh()
            End If
            Application.DoEvents()

            '--- Initialize Wavelength to Home
            If gobjCommProtocol.gFuncWavelength_Home() Then
                lblStep2.Text = lblStep2.Text
                lblStatus2.Text = " OK 0.00 nm"
                lblStatus2.ForeColor = Color.Green
                lblStatus2.Refresh()
                lblStep2.ImageIndex = 1
                lblStep2.Refresh()
            Else
                lblStep2.Text = lblStep2.Text
                lblStatus2.Text = " ERROR"
                lblStatus2.ForeColor = Color.Red
                lblStatus2.Refresh()
                lblStep2.ImageIndex = 2
                lblStep2.Refresh()
            End If
            Application.DoEvents()

            '--- Initialize Slit to Home 
            ' 
            If gobjCommProtocol.gFuncSlit_Home() Then
                lblStep3.Text = lblStep3.Text
                lblStatus3.Text = " OK 2.0 nm"
                lblStatus3.ForeColor = Color.Green
                lblStatus3.Refresh()
                lblStep3.ImageIndex = 1
                lblStep3.Refresh()
            Else
                lblStep3.Text = lblStep3.Text
                lblStatus3.Text = " ERROR "
                lblStatus3.ForeColor = Color.Red
                lblStatus3.Refresh()
                lblStep3.ImageIndex = 2
                lblStep3.Refresh()
            End If
            Application.DoEvents()

            '---For Double Beam (Reference)
            If gintInstrumentBeamType = enumInstrumentBeamType.DoubleBeam Then
                If Not gobjCommProtocol.funcExitSlit_Home() Then
                    Call Application.DoEvents()
                    lblStep4.Text = lblStep4.Text
                    lblStatus4.Text = " ERROR "
                    lblStatus4.ForeColor = Color.Red
                    lblStatus4.Refresh()
                    lblStep4.ImageIndex = 2
                    lblStep4.Refresh()
                Else
                    lblStep4.Text = lblStep4.Text
                    lblStatus4.Text = " OK 2.0 nm"
                    lblStatus4.ForeColor = Color.Green
                    lblStatus4.Refresh()
                    lblStep4.ImageIndex = 1
                    lblStep3.Refresh()
                End If
            End If
            Call Application.DoEvents()
            '--- Initialize Pneumatic
            If gobjCommProtocol.gFuncPneumatics() Then
                lblStep5.Text = lblStep5.Text
                lblStatus5.Text = " OK"
                lblStatus5.ForeColor = Color.Green
                lblStatus5.Refresh()
                lblStep5.ImageIndex = 1
                lblStep5.Refresh()
            Else
                lblStep5.Text = lblStep5.Text
                lblStatus5.Text = " ERROR"
                lblStatus5.ForeColor = Color.Red
                lblStatus5.Refresh()
                lblStep5.ImageIndex = 2
                lblStep5.Refresh()
            End If
            Application.DoEvents()

            '---Perform Analog self test
            '---For Single Beam (Sample)
            If gobjCommProtocol.gFuncAnalogSelfTest(gobjInst.Average, dblPVTvalue) Then
                lblStep6.Text = lblStep6.Text
                lblStatus6.Text = " OK " & Format((gFuncGetmv(dblPVTvalue) / 1000), "0.00") & " V"
                lblStatus6.ForeColor = Color.Green
                lblStatus6.Refresh()
                lblStep6.ImageIndex = 1
                lblStep6.Refresh()
            Else
                lblStep6.Text = lblStep6.Text
                lblStatus6.Text = " ERROR"
                lblStatus6.ForeColor = Color.Red
                lblStatus6.Refresh()
                lblStep6.ImageIndex = 2
                lblStep6.Refresh()
            End If
            Application.DoEvents()

            '---Perform Analog self test
            '---For 203D (Reference Beam)

            If gobjCommProtocol.gFuncAnalogSelfTest_ReferenceBeam(gobjInst.Average, dblPVTvalue) Then
                lblStep7.Text = lblStep7.Text
                lblStatus7.Text = " OK " & Format((gFuncGetmv(dblPVTvalue) / 1000), "0.00") & " V"
                lblStatus7.ForeColor = Color.Green
                lblStatus7.Refresh()
                lblStep7.ImageIndex = 1
                lblStep7.Refresh()
            Else
                lblStep7.Text = lblStep7.Text
                lblStatus7.Text = " ERROR"
                lblStatus7.ForeColor = Color.Red
                lblStatus7.Refresh()
                lblStep7.ImageIndex = 2
                lblStep7.Refresh()
            End If
            Application.DoEvents()

            lblStep8.Text = lblStep8.Text
            lblStatus8.Text = " Wait"
            lblStatus8.ForeColor = Color.Green
            lblStep8.Refresh()
            lblStatus8.Refresh()
            Application.DoEvents()

            '--- this function is written by deepak b on 16.11.06 for BH
            Call gobjCommProtocol.funcBH_File_read()
            Application.DoEvents()

            'Read Lamp Position if saved in file and load turret status
            'else search for lamp if present find wavelength home and optimise turret position for that lamp
            If funcLoadInstStatus() = False Then
                For intCount = 0 To 5
                    If gobjInst.Lamp.LampParametersCollection.item(intCount).ElementName <> "" Then
                        Exit For
                    End If
                Next

                If intCount = 6 Then
                    'OnLampPlace
                    'if lamp not present in global object then ask for lamp at initialization
                    '----Added by Mangesh on 11-Apr-2007 

                    Dim objfrmLampPlacements As frmLampPlacements
                    objfrmLampPlacements = New frmLampPlacements
                    If objfrmLampPlacements.ShowDialog() = DialogResult.OK Then
                        If Not IsNothing(objfrmLampPlacements.mobjInstrumentParameters) Then
                            Dim intLastLastPositionInLampPlacement As Integer = objfrmLampPlacements.mobjInstrumentParameters.TurretNumber
                            Dim dblCurrent As Double = objfrmLampPlacements.mobjInstrumentParameters.LampCurrent
                            Call gobjCommProtocol.funcSet_Lamp(True, dblCurrent, intLastLastPositionInLampPlacement)
                            Call gobjCommProtocol.funcOptimise_Turret_Position(dblCurrent, intLastLastPositionInLampPlacement)
                            Call Application.DoEvents()
                        End If
                    Else
                        Return False
                    End If
                    '****************************************************************************************************************************
                Else
                    gobjInst.Lamp_Position = intCount + 1
                    Call gobjCommProtocol.funcOptimise_Turret_Position(gobjInst.Lamp.LampParametersCollection.item(gobjInst.Lamp_Position - 1).Current, gobjInst.Lamp_Position)
                    'OnOptimiseTurPos
                    If gstructSettings.ExeToRun = EnumApplicationMode.AAS Then
                        funcSaveInstStatus()
                    End If
                End If
            Else
                For intCount = 0 To 5
                    If gobjInst.Lamp.LampParametersCollection.item(intCount).ElementName <> "" Then
                        Exit For
                    End If
                Next
                If gobjCommProtocol.funcFind_Wavelength_Home() Then
                    If gobjCommProtocol.gFuncTurret_Position(intCount + 1, True) Then
                    End If
                Else

                End If
                Application.DoEvents()
            End If

            'D2 file Read
            gobjInst.D2Pmt = gstructSettings.D2Pmt

            'if (Read INI for D2 gain) then
            If gstructSettings.D2Gain = True Then
                If gobjCommProtocol.funcGain10X_OFF() Then
                Else
                End If
                Application.DoEvents()
            End If

            If gstructSettings.Mesh = True Then
                If gobjCommProtocol.funcSetMICRO_OFF() Then
                Else
                End If
                Application.DoEvents()
            End If

            '---Set Beam Type to Instrument
            'Call gobjCommProtocol.funcCalibrationMode(EnumCalibrationMode.SELFTEST)

            If Not IsNothing(gobjfrmStatus) Then
                gobjfrmStatus.TurretNumber = gobjInst.Lamp_Position
                If gobjInst.Lamp_Position >= 1 Then
                    gobjfrmStatus.ElementName = gobjInst.Lamp.LampParametersCollection.item(gobjInst.Lamp_Position - 1).ElementName
                End If
                gobjfrmStatus.Refresh()
            End If
            gobjfrmStatus.Show()
            Application.DoEvents()

            '---changed on 20.03.08 to make beam type selection permanent
            Dim intBeamType As Integer
            intBeamType = CInt(gFuncGetFromINI(SECTION_SYSTEMPARAMETERS, KEY_INSTRUMENT_BEAMTYPE, "0", INI_SETTINGS_PATH))
            If intBeamType = 0 Then
                gintInstrumentBeamType = enumInstrumentBeamType.SingleBeam
            ElseIf intBeamType = 2 Then
                gintInstrumentBeamType = enumInstrumentBeamType.DoubleBeam
            End If
            '-----------------------------------

            Return True

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            Return False
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Function

    Private Function funcInitialization_AAS201() As Boolean
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name	    :   funcInitialization_AAS201
        'Description	    :   To do the initialization routines  (global.c Initialise)
        'Parameters 	    :   
        'Time/Date  	    :   26/9/2006
        'Dependencies	    :   
        'Author		        :   Rahul B.
        'Revision		    :
        'Revision by Person	:   Deepak B. on 20.11.06 major modifications done   
        'Revision by Person	:   Mangesh S. on 10-Apr-2007 AA201 Changes
        '--------------------------------------------------------------------------------------
        Dim blnFlag As Boolean = False
        Dim intCount As Integer
        Dim dblPVTvalue As Double
        Dim a As Integer

        Try
            Call gobjClsAAS203.subSetInstrumentBeamType(enumInstrumentBeamType.SingleBeam)

            '-----Set All lamp off
            If Not gobjCommProtocol.funcAll_Lamp_Off() Then
            End If
            Application.DoEvents()

            '-----Set PMT to Zero 
            '---For Single Beam (Sample)
            Call gobjCommProtocol.funcSet_PMT(0.0)
            Call Application.DoEvents()

            '--- Initialize Wavelength to Home
            If gobjCommProtocol.gFuncWavelength_Home() Then
                lblStep2.Text = lblStep2.Text
                lblStatus2.Text = " OK 0.00 nm"
                lblStatus2.ForeColor = Color.Green
                lblStatus2.Refresh()
                lblStep2.ImageIndex = 1
                lblStep2.Refresh()
            Else
                lblStep2.Text = lblStep2.Text
                lblStatus2.Text = " ERROR"
                lblStatus2.ForeColor = Color.Red
                lblStatus2.Refresh()
                lblStep2.ImageIndex = 2
                lblStep2.Refresh()
            End If
            Application.DoEvents()

            '--- Initialize Slit to Home 
            If gobjCommProtocol.gFuncSlit_Home() Then
                lblStep3.Text = lblStep3.Text
                lblStatus3.Text = " OK 2.0 nm"
                lblStatus3.ForeColor = Color.Green
                lblStatus3.Refresh()
                lblStep3.ImageIndex = 1
                lblStep3.Refresh()
            Else
                lblStep3.Text = lblStep3.Text
                lblStatus3.Text = " ERROR"
                lblStatus3.ForeColor = Color.Red
                lblStatus3.Refresh()
                lblStep3.ImageIndex = 2
                lblStep3.Refresh()
            End If
            Application.DoEvents()

            '--- Initialize Pneumatic
            If gobjCommProtocol.gFuncPneumatics() Then
                lblStep4.Text = lblStep4.Text
                lblStatus4.Text = " OK"
                lblStatus4.ForeColor = Color.Green
                lblStatus4.Refresh()
                lblStep4.ImageIndex = 1
                lblStep4.Refresh()
            Else
                lblStep4.Text = lblStep4.Text
                lblStatus4.Text = " ERROR"
                lblStatus4.ForeColor = Color.Red
                lblStatus4.Refresh()
                lblStep4.ImageIndex = 2
                lblStep4.Refresh()
            End If
            Application.DoEvents()

            '---Perform Analog self test for AAS 201
            If gobjCommProtocol.gFuncAnalogSelfTest_AA201(gobjInst.Average, dblPVTvalue) Then
                lblStep5.Text = lblStep5.Text
                lblStatus5.Text = " OK " & Format((gFuncGetmv(dblPVTvalue) / 1000), "0.00") & " V"
                lblStatus5.ForeColor = Color.Green
                lblStatus5.Refresh()
                lblStep5.ImageIndex = 1
                lblStep5.Refresh()
            Else
                lblStep5.Text = lblStep5.Text
                lblStatus5.Text = " ERROR"
                lblStatus5.ForeColor = Color.Red
                lblStatus5.Refresh()
                lblStep5.ImageIndex = 2
                lblStep5.Refresh()
            End If
            Application.DoEvents()

            lblStep6.Text = lblStep6.Text
            lblStatus6.Text = " Wait ... "
            lblStatus6.ForeColor = Color.Green
            lblStep6.Refresh()
            lblStatus6.Refresh()
            Call Application.DoEvents()

            '--- this function is written by deepak b on 16.11.06 for BH
            Call gobjCommProtocol.funcBH_File_read()
            Call Application.DoEvents()

            'Read Lamp Position if saved in file and load turret status
            'else search for lamp if present find wavelength home and optimise turret position for that lamp

            If Not funcLoadInstStatus() Then
                For intCount = 0 To 1
                    If gobjInst.Lamp.LampParametersCollection.item(intCount).ElementName <> "" Then
                        Exit For
                    End If
                Next
                If intCount = 2 Then
                    'OnLampPlace
                    ' if lamp is not found ask user for lamp
                    Dim objfrmLampPlacements201 As frmLampPlacements_201
                    objfrmLampPlacements201 = New frmLampPlacements_201
                    If objfrmLampPlacements201.ShowDialog() = DialogResult.OK Then
                        If Not IsNothing(objfrmLampPlacements201.mobjInstrumentParameters) Then
                            Dim intLastLastPositionInLampPlacement As Integer = objfrmLampPlacements201.mobjInstrumentParameters.TurretNumber
                            Dim dblCurrent As Double = objfrmLampPlacements201.mobjInstrumentParameters.LampCurrent
                            'set current to the lamp
                            Call gobjCommProtocol.funcSet_Lamp(True, dblCurrent, intLastLastPositionInLampPlacement)
                            Call gobjCommProtocol.funcOptimise_Turret_Position(dblCurrent, intLastLastPositionInLampPlacement)

                            If gobjMessageAdapter.ShowMessage(constManualLampOptimisation) Then
                                Call Application.DoEvents()
                                Call gobjClsAAS203.AbsorbanceScan()
                            End If
                            Call Application.DoEvents()

                        End If
                    Else
                        Return False
                    End If
                Else
                    gobjInst.Lamp_Position = intCount + 1
                    Call gobjCommProtocol.funcOptimise_Turret_Position(gobjInst.Lamp.LampParametersCollection.item(gobjInst.Lamp_Position - 1).Current, gobjInst.Lamp_Position)
                    'OnOptimiseTurPos
                    If gstructSettings.ExeToRun = EnumApplicationMode.AAS Then
                        Call funcSaveInstStatus()
                    End If
                End If
            Else
                For intCount = 0 To 5
                    If gobjInst.Lamp.LampParametersCollection.item(intCount).ElementName <> "" Then
                        Exit For
                    End If
                Next
                If gobjCommProtocol.funcFind_Wavelength_Home() Then
                    If gobjCommProtocol.gFuncTurret_Position(intCount + 1, True) Then
                    End If
                Else

                End If
                Application.DoEvents()
            End If

            'D2 file Read
            gobjInst.D2Pmt = gstructSettings.D2Pmt

            'if (Read INI for D2 gain) then
            If gstructSettings.D2Gain = True Then
                Call gobjCommProtocol.funcGain10X_OFF()
                Call Application.DoEvents()
            End If

            If gstructSettings.Mesh = True Then
                Call gobjCommProtocol.funcSetMICRO_OFF()
                Call Application.DoEvents()
            End If

            If Not IsNothing(gobjfrmStatus) Then
                gobjfrmStatus.TurretNumber = gobjInst.Lamp_Position
                If gobjInst.Lamp_Position >= 1 Then
                    gobjfrmStatus.ElementName = gobjInst.Lamp.LampParametersCollection.item(gobjInst.Lamp_Position - 1).ElementName
                End If
                gobjfrmStatus.Refresh()
            End If
            gobjfrmStatus.Show()
            Application.DoEvents()

            'gobjfrmStatus.lblElementName.Text = gobjInst.Lamp.LampParametersCollection(0).ElementName()

            Return True

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            Return False
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Function

#End Region

#Region " Public Functions "

    Public Function funcInstrumentInitialization() As Boolean
        '-----------------------------------------------------------------
        'Procedure Name         :   funcInstrumentInitialization
        'Description            :   To display initialisation procedure of AAS on screen        
        'Parameters             :   None
        'Time/Date              :   25/9/06
        'Dependencies           :   
        'Author                 :   Rahul B.
        'Revision               :
        'Revision by Person     :   Praveen
        '-----------------------------------------------------------------
        Dim strInstrument_Type As String
        Dim blnFlag As Boolean

        Try
            Me.Refresh()

            Select Case gstructSettings.AppMode
                ''this will called a initialisation function as per application mode.
            Case EnumAppMode.FullVersion_201
                    ''for 201
                    Call subDisplayIntializationSteps_AAS201()

                Case EnumAppMode.FullVersion_203
                    ''for 203
                    Call subDisplayIntializationSteps_203()

                Case EnumAppMode.FullVersion_203D
                    ''for 203D 
                    Call subDisplayIntializationSteps_203D()

            End Select

            Me.Refresh()
            Application.DoEvents() 'allow application to perfrom its panding work.

            '--- Start the Initialization of the system
            blnFlag = gobjCommProtocol.funcInitInstrument()

            If blnFlag Then
                ''set a initialise flag as per application mode.
                Select Case gstructSettings.AppMode
                    Case EnumAppMode.FullVersion_203
                        '---Initialise to the AAS 203
                        blnFlag = funcInitialization_AAS203()

                    Case EnumAppMode.FullVersion_203D
                        '---Initialise to the AAS 203D (Double Beam) 
                        blnFlag = funcInitialization_AAS203D()

                    Case EnumAppMode.FullVersion_201
                        '---Initialise to the AAS 202 
                        blnFlag = funcInitialization_AAS201()

                End Select

            End If

            Return blnFlag

        Catch ex As Exception
            '---------------------------------------------------------
            'Error logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
            Return False
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------
        End Try
    End Function

#End Region

End Class
