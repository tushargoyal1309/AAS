
Public Class frmPMT ''class behind the PMT form.

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
    Friend WithEvents btnCancel As NETXP.Controls.XPButton
    Friend WithEvents lblMsg As System.Windows.Forms.Label
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents PanelBack As System.Windows.Forms.Panel
    Friend WithEvents lblBlink As NETXP.Controls.XPButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmPMT))
        Me.btnCancel = New NETXP.Controls.XPButton
        Me.lblMsg = New System.Windows.Forms.Label
        Me.lblTitle = New System.Windows.Forms.Label
        Me.PanelBack = New System.Windows.Forms.Panel
        Me.lblBlink = New NETXP.Controls.XPButton
        Me.PanelBack.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.AliceBlue
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCancel.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Image = CType(resources.GetObject("btnCancel.Image"), System.Drawing.Image)
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancel.Location = New System.Drawing.Point(240, 64)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(96, 32)
        Me.btnCancel.TabIndex = 0
        Me.btnCancel.Text = "&Cancel"
        '
        'lblMsg
        '
        Me.lblMsg.BackColor = System.Drawing.Color.White
        Me.lblMsg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblMsg.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMsg.ForeColor = System.Drawing.Color.Blue
        Me.lblMsg.Location = New System.Drawing.Point(240, 24)
        Me.lblMsg.Name = "lblMsg"
        Me.lblMsg.Size = New System.Drawing.Size(320, 32)
        Me.lblMsg.TabIndex = 2
        Me.lblMsg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTitle
        '
        Me.lblTitle.BackColor = System.Drawing.Color.White
        Me.lblTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.Blue
        Me.lblTitle.Location = New System.Drawing.Point(16, 24)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(144, 32)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PanelBack
        '
        Me.PanelBack.BackColor = System.Drawing.Color.AliceBlue
        Me.PanelBack.Controls.Add(Me.lblBlink)
        Me.PanelBack.Controls.Add(Me.lblMsg)
        Me.PanelBack.Controls.Add(Me.btnCancel)
        Me.PanelBack.Controls.Add(Me.lblTitle)
        Me.PanelBack.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelBack.Location = New System.Drawing.Point(0, 0)
        Me.PanelBack.Name = "PanelBack"
        Me.PanelBack.Size = New System.Drawing.Size(576, 112)
        Me.PanelBack.TabIndex = 10
        '
        'lblBlink
        '
        Me.lblBlink.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.lblBlink.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBlink.ForeColor = System.Drawing.Color.Blue
        Me.lblBlink.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblBlink.Location = New System.Drawing.Point(184, 24)
        Me.lblBlink.Name = "lblBlink"
        Me.lblBlink.Size = New System.Drawing.Size(32, 32)
        Me.lblBlink.TabIndex = 4
        '
        'frmPMT
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(576, 112)
        Me.ControlBox = False
        Me.Controls.Add(Me.PanelBack)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(100, 40)
        Me.Name = "frmPMT"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Setting PMT"
        Me.TopMost = True
        Me.PanelBack.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Public Variable"
    Public mCancelProcess As Boolean = False
#End Region

#Region "Event Handlers"
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        '=====================================================================
        ' Procedure Name        : btnCancel_Click
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : 
        ' Description           : to handle the cancel button event. 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 21.11.06
        ' Revisions             : praveen
        '=====================================================================
        ''note:
        ''this is called when user clicked on cancel button
        mCancelProcess = True
        Application.DoEvents()
        ''cancel the process and allow application to perfrom its panding work.
    End Sub
    Private Sub lblBlink_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : lblBlink_Click
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : 
        ' Description           : to handle the blink label event. 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 21.11.06
        ' Revisions             : praveen
        '=====================================================================
        mCancelProcess = True
        Application.DoEvents()
        ''cancel the process and allow application to perfrom its panding work.
    End Sub

#End Region


End Class
