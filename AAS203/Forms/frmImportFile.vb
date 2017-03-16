Public Class frmImportFile
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
    Friend WithEvents CustomPanelMain As GradientPanel.CustomPanel
    Friend WithEvents CustomPanelTop As GradientPanel.CustomPanel
    Friend WithEvents CustomPanelMethod As GradientPanel.CustomPanel
    Friend WithEvents lbMethodComments As System.Windows.Forms.Label
    Friend WithEvents lblMethodComments As System.Windows.Forms.Label
    Friend WithEvents lblMethodInformation As System.Windows.Forms.Label
    Friend WithEvents lblRuns As System.Windows.Forms.Label
    Friend WithEvents lbMethodInformation As System.Windows.Forms.ListBox
    Friend WithEvents lbRunNos As System.Windows.Forms.ListBox
    Friend WithEvents CustomPanelBottom As GradientPanel.CustomPanel
    Friend WithEvents PreviewGraph As AAS203.AASGraph
    Friend WithEvents btnCancel As NETXP.Controls.XPButton
    Friend WithEvents btnOk As NETXP.Controls.XPButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmImportFile))
        Me.CustomPanelMain = New GradientPanel.CustomPanel
        Me.CustomPanelTop = New GradientPanel.CustomPanel
        Me.CustomPanelMethod = New GradientPanel.CustomPanel
        Me.lbMethodComments = New System.Windows.Forms.Label
        Me.lblMethodComments = New System.Windows.Forms.Label
        Me.lblMethodInformation = New System.Windows.Forms.Label
        Me.lblRuns = New System.Windows.Forms.Label
        Me.lbMethodInformation = New System.Windows.Forms.ListBox
        Me.lbRunNos = New System.Windows.Forms.ListBox
        Me.CustomPanelBottom = New GradientPanel.CustomPanel
        Me.PreviewGraph = New AAS203.AASGraph
        Me.btnCancel = New NETXP.Controls.XPButton
        Me.btnOk = New NETXP.Controls.XPButton
        Me.CustomPanelMain.SuspendLayout()
        Me.CustomPanelTop.SuspendLayout()
        Me.CustomPanelMethod.SuspendLayout()
        Me.CustomPanelBottom.SuspendLayout()
        Me.SuspendLayout()
        '
        'CustomPanelMain
        '
        Me.CustomPanelMain.BackColor = System.Drawing.Color.AliceBlue
        Me.CustomPanelMain.Controls.Add(Me.CustomPanelTop)
        Me.CustomPanelMain.Controls.Add(Me.CustomPanelBottom)
        Me.CustomPanelMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CustomPanelMain.Location = New System.Drawing.Point(0, 0)
        Me.CustomPanelMain.Name = "CustomPanelMain"
        Me.CustomPanelMain.Size = New System.Drawing.Size(400, 395)
        Me.CustomPanelMain.TabIndex = 1
        '
        'CustomPanelTop
        '
        Me.CustomPanelTop.BackColor = System.Drawing.Color.AliceBlue
        Me.CustomPanelTop.Controls.Add(Me.CustomPanelMethod)
        Me.CustomPanelTop.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CustomPanelTop.Location = New System.Drawing.Point(0, 0)
        Me.CustomPanelTop.Name = "CustomPanelTop"
        Me.CustomPanelTop.Size = New System.Drawing.Size(400, 251)
        Me.CustomPanelTop.TabIndex = 21
        '
        'CustomPanelMethod
        '
        Me.CustomPanelMethod.BackColor = System.Drawing.Color.AliceBlue
        Me.CustomPanelMethod.Controls.Add(Me.lbMethodComments)
        Me.CustomPanelMethod.Controls.Add(Me.lblMethodComments)
        Me.CustomPanelMethod.Controls.Add(Me.lblMethodInformation)
        Me.CustomPanelMethod.Controls.Add(Me.lblRuns)
        Me.CustomPanelMethod.Controls.Add(Me.lbMethodInformation)
        Me.CustomPanelMethod.Controls.Add(Me.lbRunNos)
        Me.CustomPanelMethod.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CustomPanelMethod.Location = New System.Drawing.Point(0, 0)
        Me.CustomPanelMethod.Name = "CustomPanelMethod"
        Me.CustomPanelMethod.Size = New System.Drawing.Size(400, 251)
        Me.CustomPanelMethod.TabIndex = 20
        '
        'lbMethodComments
        '
        Me.lbMethodComments.BackColor = System.Drawing.Color.White
        Me.lbMethodComments.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbMethodComments.Location = New System.Drawing.Point(160, 173)
        Me.lbMethodComments.Name = "lbMethodComments"
        Me.lbMethodComments.Size = New System.Drawing.Size(225, 40)
        Me.lbMethodComments.TabIndex = 33
        '
        'lblMethodComments
        '
        Me.lblMethodComments.Location = New System.Drawing.Point(160, 152)
        Me.lblMethodComments.Name = "lblMethodComments"
        Me.lblMethodComments.Size = New System.Drawing.Size(104, 16)
        Me.lblMethodComments.TabIndex = 30
        Me.lblMethodComments.Text = "Method Comments"
        '
        'lblMethodInformation
        '
        Me.lblMethodInformation.Location = New System.Drawing.Point(160, 7)
        Me.lblMethodInformation.Name = "lblMethodInformation"
        Me.lblMethodInformation.Size = New System.Drawing.Size(104, 16)
        Me.lblMethodInformation.TabIndex = 29
        Me.lblMethodInformation.Text = "Method Information"
        '
        'lblRuns
        '
        Me.lblRuns.Location = New System.Drawing.Point(16, 7)
        Me.lblRuns.Name = "lblRuns"
        Me.lblRuns.Size = New System.Drawing.Size(96, 16)
        Me.lblRuns.TabIndex = 28
        Me.lblRuns.Text = "Runs"
        '
        'lbMethodInformation
        '
        Me.lbMethodInformation.Location = New System.Drawing.Point(160, 27)
        Me.lbMethodInformation.Name = "lbMethodInformation"
        Me.lbMethodInformation.Size = New System.Drawing.Size(225, 108)
        Me.lbMethodInformation.TabIndex = 25
        '
        'lbRunNos
        '
        Me.lbRunNos.BackColor = System.Drawing.Color.White
        Me.lbRunNos.Location = New System.Drawing.Point(16, 27)
        Me.lbRunNos.Name = "lbRunNos"
        Me.lbRunNos.Size = New System.Drawing.Size(129, 186)
        Me.lbRunNos.TabIndex = 24
        '
        'CustomPanelBottom
        '
        Me.CustomPanelBottom.BackColor = System.Drawing.Color.AliceBlue
        Me.CustomPanelBottom.Controls.Add(Me.PreviewGraph)
        Me.CustomPanelBottom.Controls.Add(Me.btnCancel)
        Me.CustomPanelBottom.Controls.Add(Me.btnOk)
        Me.CustomPanelBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.CustomPanelBottom.Location = New System.Drawing.Point(0, 251)
        Me.CustomPanelBottom.Name = "CustomPanelBottom"
        Me.CustomPanelBottom.Size = New System.Drawing.Size(400, 144)
        Me.CustomPanelBottom.TabIndex = 20
        '
        'PreviewGraph
        '
        Me.PreviewGraph.AldysGraphCursor = System.Windows.Forms.Cursors.Hand
        Me.PreviewGraph.AldysGraphPrintColor = System.Drawing.Color.Black
        Me.PreviewGraph.BackColor = System.Drawing.Color.LightGray
        Me.PreviewGraph.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PreviewGraph.GraphDataSource = Nothing
        Me.PreviewGraph.GraphImage = Nothing
        Me.PreviewGraph.IsShowGrid = True
        Me.PreviewGraph.Location = New System.Drawing.Point(16, 8)
        Me.PreviewGraph.Name = "PreviewGraph"
        Me.PreviewGraph.Size = New System.Drawing.Size(224, 128)
        Me.PreviewGraph.TabIndex = 24
        Me.PreviewGraph.UseDefaultSettings = False
        Me.PreviewGraph.XAxisDateMax = New Date(2007, 3, 16, 23, 59, 59, 0)
        Me.PreviewGraph.XAxisDateMin = New Date(2007, 3, 16, 0, 0, 0, 0)
        Me.PreviewGraph.XAxisDateScaleFormat = AAS203.AASGraph.enumDateScaleFormat.HHMM
        Me.PreviewGraph.XAxisLabel = "TIME(seconds)"
        Me.PreviewGraph.XAxisMax = 100
        Me.PreviewGraph.XAxisMin = 0
        Me.PreviewGraph.XAxisMinorStep = 2
        Me.PreviewGraph.XAxisScaleFormat = ""
        Me.PreviewGraph.XAxisStep = 10
        Me.PreviewGraph.XAxisType = AldysGraph.AxisType.Linear
        Me.PreviewGraph.YAxisLabel = "ABSORBANCE"
        Me.PreviewGraph.YAxisMax = 1.1
        Me.PreviewGraph.YAxisMin = -0.2
        Me.PreviewGraph.YAxisMinorStep = 0.05
        Me.PreviewGraph.YAxisScaleFormat = Nothing
        Me.PreviewGraph.YAxisStep = 0.1
        Me.PreviewGraph.YAxisType = AldysGraph.AxisType.Linear
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.Transparent
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Image = CType(resources.GetObject("btnCancel.Image"), System.Drawing.Image)
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancel.Location = New System.Drawing.Point(248, 101)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(86, 34)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "&Cancel"
        '
        'btnOk
        '
        Me.btnOk.BackColor = System.Drawing.Color.Transparent
        Me.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOk.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOk.Image = CType(resources.GetObject("btnOk.Image"), System.Drawing.Image)
        Me.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnOk.Location = New System.Drawing.Point(248, 56)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(86, 34)
        Me.btnOk.TabIndex = 0
        Me.btnOk.Text = "&OK"
        '
        'frmImportFile
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(400, 395)
        Me.Controls.Add(Me.CustomPanelMain)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmImportFile"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Import File"
        Me.CustomPanelMain.ResumeLayout(False)
        Me.CustomPanelTop.ResumeLayout(False)
        Me.CustomPanelMethod.ResumeLayout(False)
        Me.CustomPanelBottom.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

End Class
