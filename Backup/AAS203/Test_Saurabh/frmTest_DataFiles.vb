Public Class frmTest_DataFiles
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
    Friend WithEvents CustomPanelRight As GradientPanel.CustomPanel
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents btnPrintGraph As NETXP.Controls.XPButton
    Friend WithEvents cmdChangeScale As NETXP.Controls.XPButton
    Friend WithEvents PreviewGraph As AAS203.AASGraph
    Friend WithEvents CustomPanelRightTop As GradientPanel.CustomPanel
    Friend WithEvents txtMethod As System.Windows.Forms.TextBox
    Friend WithEvents txtRunNo As System.Windows.Forms.TextBox
    Friend WithEvents lblRunNo As System.Windows.Forms.Label
    Friend WithEvents lblMethod As System.Windows.Forms.Label
    Friend WithEvents CustomPanelRightBottom As GradientPanel.CustomPanel
    Friend WithEvents lstMethodInformation As System.Windows.Forms.ListBox
    Friend WithEvents lblMethodComments As System.Windows.Forms.Label
    Friend WithEvents txtMethodComments As System.Windows.Forms.TextBox
    Friend WithEvents lblMethodInformation As System.Windows.Forms.Label
    Friend WithEvents HeaderRight As CodeIntellects.Office2003Controls.Office2003Header
    Friend WithEvents CustomPanelLeft As GradientPanel.CustomPanel
    Friend WithEvents RealPanel3 As NETXP.Controls.RealPanel
    Friend WithEvents btnLoad As NETXP.Controls.XPButton
    Friend WithEvents RealPanel2 As NETXP.Controls.RealPanel
    Friend WithEvents btnEditData As NETXP.Controls.XPButton
    Friend WithEvents btnExportReport As NETXP.Controls.XPButton
    Friend WithEvents btnReportOptions As NETXP.Controls.XPButton
    Friend WithEvents RealPanel1 As NETXP.Controls.RealPanel
    Friend WithEvents btnReports As NETXP.Controls.XPButton
    Friend WithEvents btnViewResults As NETXP.Controls.XPButton
    Friend WithEvents btnSampleGraph As NETXP.Controls.XPButton
    Friend WithEvents btnStandardGraph As NETXP.Controls.XPButton
    Friend WithEvents btnExtinguish As NETXP.Controls.XPButton
    Friend WithEvents HeaderLeft As CodeIntellects.Office2003Controls.Office2003Header
    Friend WithEvents btnIgnite As NETXP.Controls.XPButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmTest_DataFiles))
        Me.CustomPanelMain = New GradientPanel.CustomPanel
        Me.CustomPanelRight = New GradientPanel.CustomPanel
        Me.Button1 = New System.Windows.Forms.Button
        Me.btnPrintGraph = New NETXP.Controls.XPButton
        Me.cmdChangeScale = New NETXP.Controls.XPButton
        Me.PreviewGraph = New AAS203.AASGraph
        Me.CustomPanelRightTop = New GradientPanel.CustomPanel
        Me.txtMethod = New System.Windows.Forms.TextBox
        Me.txtRunNo = New System.Windows.Forms.TextBox
        Me.lblRunNo = New System.Windows.Forms.Label
        Me.lblMethod = New System.Windows.Forms.Label
        Me.CustomPanelRightBottom = New GradientPanel.CustomPanel
        Me.lstMethodInformation = New System.Windows.Forms.ListBox
        Me.lblMethodComments = New System.Windows.Forms.Label
        Me.txtMethodComments = New System.Windows.Forms.TextBox
        Me.lblMethodInformation = New System.Windows.Forms.Label
        Me.HeaderRight = New CodeIntellects.Office2003Controls.Office2003Header
        Me.CustomPanelLeft = New GradientPanel.CustomPanel
        Me.RealPanel3 = New NETXP.Controls.RealPanel
        Me.btnLoad = New NETXP.Controls.XPButton
        Me.RealPanel2 = New NETXP.Controls.RealPanel
        Me.btnEditData = New NETXP.Controls.XPButton
        Me.btnExportReport = New NETXP.Controls.XPButton
        Me.btnReportOptions = New NETXP.Controls.XPButton
        Me.RealPanel1 = New NETXP.Controls.RealPanel
        Me.btnReports = New NETXP.Controls.XPButton
        Me.btnViewResults = New NETXP.Controls.XPButton
        Me.btnSampleGraph = New NETXP.Controls.XPButton
        Me.btnStandardGraph = New NETXP.Controls.XPButton
        Me.btnExtinguish = New NETXP.Controls.XPButton
        Me.HeaderLeft = New CodeIntellects.Office2003Controls.Office2003Header
        Me.btnIgnite = New NETXP.Controls.XPButton
        Me.CustomPanelMain.SuspendLayout()
        Me.CustomPanelRight.SuspendLayout()
        Me.CustomPanelRightTop.SuspendLayout()
        Me.CustomPanelRightBottom.SuspendLayout()
        Me.CustomPanelLeft.SuspendLayout()
        Me.RealPanel3.SuspendLayout()
        Me.RealPanel2.SuspendLayout()
        Me.RealPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'CustomPanelMain
        '
        Me.CustomPanelMain.BackColor = System.Drawing.Color.AliceBlue
        Me.CustomPanelMain.BackColor2 = System.Drawing.Color.AliceBlue
        Me.CustomPanelMain.Controls.Add(Me.CustomPanelRight)
        Me.CustomPanelMain.Controls.Add(Me.CustomPanelLeft)
        Me.CustomPanelMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CustomPanelMain.Location = New System.Drawing.Point(0, 0)
        Me.CustomPanelMain.Name = "CustomPanelMain"
        Me.CustomPanelMain.Size = New System.Drawing.Size(800, 561)
        Me.CustomPanelMain.TabIndex = 1
        '
        'CustomPanelRight
        '
        Me.CustomPanelRight.BackColor = System.Drawing.Color.Transparent
        Me.CustomPanelRight.BackColor2 = System.Drawing.Color.Transparent
        Me.CustomPanelRight.Controls.Add(Me.Button1)
        Me.CustomPanelRight.Controls.Add(Me.btnPrintGraph)
        Me.CustomPanelRight.Controls.Add(Me.cmdChangeScale)
        Me.CustomPanelRight.Controls.Add(Me.PreviewGraph)
        Me.CustomPanelRight.Controls.Add(Me.CustomPanelRightTop)
        Me.CustomPanelRight.Controls.Add(Me.CustomPanelRightBottom)
        Me.CustomPanelRight.Controls.Add(Me.HeaderRight)
        Me.CustomPanelRight.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CustomPanelRight.Location = New System.Drawing.Point(132, 0)
        Me.CustomPanelRight.Name = "CustomPanelRight"
        Me.CustomPanelRight.Size = New System.Drawing.Size(668, 561)
        Me.CustomPanelRight.TabIndex = 3
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(76, 78)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(90, 22)
        Me.Button1.TabIndex = 10
        Me.Button1.Text = "Button1"
        '
        'btnPrintGraph
        '
        Me.btnPrintGraph.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrintGraph.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrintGraph.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrintGraph.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPrintGraph.Location = New System.Drawing.Point(476, 75)
        Me.btnPrintGraph.Name = "btnPrintGraph"
        Me.btnPrintGraph.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnPrintGraph.Size = New System.Drawing.Size(110, 25)
        Me.btnPrintGraph.TabIndex = 5
        Me.btnPrintGraph.Text = "&Print Graph"
        Me.btnPrintGraph.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdChangeScale
        '
        Me.cmdChangeScale.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdChangeScale.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdChangeScale.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdChangeScale.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdChangeScale.Location = New System.Drawing.Point(353, 75)
        Me.cmdChangeScale.Name = "cmdChangeScale"
        Me.cmdChangeScale.Size = New System.Drawing.Size(110, 25)
        Me.cmdChangeScale.TabIndex = 9
        Me.cmdChangeScale.Text = "&Change  Scale"
        Me.cmdChangeScale.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'PreviewGraph
        '
        Me.PreviewGraph.AldysGraphCursor = Nothing
        Me.PreviewGraph.AldysGraphPrintColor = System.Drawing.Color.Black
        Me.PreviewGraph.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PreviewGraph.BackColor = System.Drawing.Color.LightGray
        Me.PreviewGraph.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PreviewGraph.GraphDataSource = Nothing
        Me.PreviewGraph.GraphImage = Nothing
        Me.PreviewGraph.IsShowGrid = True
        Me.PreviewGraph.Location = New System.Drawing.Point(23, 72)
        Me.PreviewGraph.Name = "PreviewGraph"
        Me.PreviewGraph.Size = New System.Drawing.Size(619, 361)
        Me.PreviewGraph.TabIndex = 5
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
        'CustomPanelRightTop
        '
        Me.CustomPanelRightTop.BackColor = System.Drawing.Color.Transparent
        Me.CustomPanelRightTop.BackColor2 = System.Drawing.Color.Transparent
        Me.CustomPanelRightTop.Controls.Add(Me.txtMethod)
        Me.CustomPanelRightTop.Controls.Add(Me.txtRunNo)
        Me.CustomPanelRightTop.Controls.Add(Me.lblRunNo)
        Me.CustomPanelRightTop.Controls.Add(Me.lblMethod)
        Me.CustomPanelRightTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.CustomPanelRightTop.Location = New System.Drawing.Point(0, 22)
        Me.CustomPanelRightTop.Name = "CustomPanelRightTop"
        Me.CustomPanelRightTop.Size = New System.Drawing.Size(668, 50)
        Me.CustomPanelRightTop.TabIndex = 0
        '
        'txtMethod
        '
        Me.txtMethod.AutoSize = False
        Me.txtMethod.BackColor = System.Drawing.Color.White
        Me.txtMethod.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMethod.Location = New System.Drawing.Point(91, 16)
        Me.txtMethod.Name = "txtMethod"
        Me.txtMethod.ReadOnly = True
        Me.txtMethod.Size = New System.Drawing.Size(154, 20)
        Me.txtMethod.TabIndex = 0
        Me.txtMethod.Text = ""
        '
        'txtRunNo
        '
        Me.txtRunNo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtRunNo.AutoSize = False
        Me.txtRunNo.BackColor = System.Drawing.Color.White
        Me.txtRunNo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRunNo.Location = New System.Drawing.Point(376, 17)
        Me.txtRunNo.Name = "txtRunNo"
        Me.txtRunNo.ReadOnly = True
        Me.txtRunNo.Size = New System.Drawing.Size(154, 20)
        Me.txtRunNo.TabIndex = 1
        Me.txtRunNo.Text = ""
        '
        'lblRunNo
        '
        Me.lblRunNo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRunNo.Location = New System.Drawing.Point(312, 18)
        Me.lblRunNo.Name = "lblRunNo"
        Me.lblRunNo.Size = New System.Drawing.Size(70, 24)
        Me.lblRunNo.TabIndex = 2
        Me.lblRunNo.Text = "Run No."
        '
        'lblMethod
        '
        Me.lblMethod.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMethod.Location = New System.Drawing.Point(22, 20)
        Me.lblMethod.Name = "lblMethod"
        Me.lblMethod.Size = New System.Drawing.Size(70, 24)
        Me.lblMethod.TabIndex = 0
        Me.lblMethod.Text = "Method"
        '
        'CustomPanelRightBottom
        '
        Me.CustomPanelRightBottom.BackColor = System.Drawing.Color.Transparent
        Me.CustomPanelRightBottom.BackColor2 = System.Drawing.Color.Transparent
        Me.CustomPanelRightBottom.Controls.Add(Me.lstMethodInformation)
        Me.CustomPanelRightBottom.Controls.Add(Me.lblMethodComments)
        Me.CustomPanelRightBottom.Controls.Add(Me.txtMethodComments)
        Me.CustomPanelRightBottom.Controls.Add(Me.lblMethodInformation)
        Me.CustomPanelRightBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.CustomPanelRightBottom.Location = New System.Drawing.Point(0, 433)
        Me.CustomPanelRightBottom.Name = "CustomPanelRightBottom"
        Me.CustomPanelRightBottom.Size = New System.Drawing.Size(668, 128)
        Me.CustomPanelRightBottom.TabIndex = 1
        '
        'lstMethodInformation
        '
        Me.lstMethodInformation.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstMethodInformation.ItemHeight = 16
        Me.lstMethodInformation.Location = New System.Drawing.Point(22, 31)
        Me.lstMethodInformation.Name = "lstMethodInformation"
        Me.lstMethodInformation.Size = New System.Drawing.Size(274, 84)
        Me.lstMethodInformation.TabIndex = 0
        '
        'lblMethodComments
        '
        Me.lblMethodComments.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMethodComments.Location = New System.Drawing.Point(363, 10)
        Me.lblMethodComments.Name = "lblMethodComments"
        Me.lblMethodComments.Size = New System.Drawing.Size(150, 17)
        Me.lblMethodComments.TabIndex = 7
        Me.lblMethodComments.Text = "Method Comments"
        '
        'txtMethodComments
        '
        Me.txtMethodComments.AutoSize = False
        Me.txtMethodComments.BackColor = System.Drawing.Color.White
        Me.txtMethodComments.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMethodComments.Location = New System.Drawing.Point(364, 31)
        Me.txtMethodComments.Multiline = True
        Me.txtMethodComments.Name = "txtMethodComments"
        Me.txtMethodComments.ReadOnly = True
        Me.txtMethodComments.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtMethodComments.Size = New System.Drawing.Size(254, 84)
        Me.txtMethodComments.TabIndex = 1
        Me.txtMethodComments.Text = ""
        '
        'lblMethodInformation
        '
        Me.lblMethodInformation.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMethodInformation.Location = New System.Drawing.Point(20, 10)
        Me.lblMethodInformation.Name = "lblMethodInformation"
        Me.lblMethodInformation.Size = New System.Drawing.Size(208, 20)
        Me.lblMethodInformation.TabIndex = 2
        Me.lblMethodInformation.Text = "Method Information"
        '
        'HeaderRight
        '
        Me.HeaderRight.BackColor = System.Drawing.SystemColors.Control
        Me.HeaderRight.Dock = System.Windows.Forms.DockStyle.Top
        Me.HeaderRight.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HeaderRight.Location = New System.Drawing.Point(0, 0)
        Me.HeaderRight.Name = "HeaderRight"
        Me.HeaderRight.Size = New System.Drawing.Size(668, 22)
        Me.HeaderRight.TabIndex = 3
        Me.HeaderRight.TitleFont = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HeaderRight.TitleText = "Spectrum"
        '
        'CustomPanelLeft
        '
        Me.CustomPanelLeft.BackColor = System.Drawing.Color.DodgerBlue
        Me.CustomPanelLeft.BackColor2 = System.Drawing.Color.Transparent
        Me.CustomPanelLeft.Controls.Add(Me.RealPanel3)
        Me.CustomPanelLeft.Controls.Add(Me.RealPanel2)
        Me.CustomPanelLeft.Controls.Add(Me.RealPanel1)
        Me.CustomPanelLeft.Controls.Add(Me.btnExtinguish)
        Me.CustomPanelLeft.Controls.Add(Me.HeaderLeft)
        Me.CustomPanelLeft.Controls.Add(Me.btnIgnite)
        Me.CustomPanelLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.CustomPanelLeft.Location = New System.Drawing.Point(0, 0)
        Me.CustomPanelLeft.Name = "CustomPanelLeft"
        Me.CustomPanelLeft.Size = New System.Drawing.Size(132, 561)
        Me.CustomPanelLeft.TabIndex = 2
        '
        'RealPanel3
        '
        Me.RealPanel3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.RealPanel3.Controls.Add(Me.btnLoad)
        Me.RealPanel3.Location = New System.Drawing.Point(7, 30)
        Me.RealPanel3.Name = "RealPanel3"
        Me.RealPanel3.Size = New System.Drawing.Size(118, 44)
        Me.RealPanel3.TabIndex = 14
        Me.RealPanel3.Text = "RealPanel3"
        '
        'btnLoad
        '
        Me.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoad.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLoad.Image = CType(resources.GetObject("btnLoad.Image"), System.Drawing.Image)
        Me.btnLoad.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLoad.Location = New System.Drawing.Point(4, 4)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(110, 36)
        Me.btnLoad.TabIndex = 0
        Me.btnLoad.Text = "&Load"
        Me.btnLoad.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'RealPanel2
        '
        Me.RealPanel2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.RealPanel2.Controls.Add(Me.btnEditData)
        Me.RealPanel2.Controls.Add(Me.btnExportReport)
        Me.RealPanel2.Controls.Add(Me.btnReportOptions)
        Me.RealPanel2.Location = New System.Drawing.Point(7, 274)
        Me.RealPanel2.Name = "RealPanel2"
        Me.RealPanel2.Size = New System.Drawing.Size(118, 131)
        Me.RealPanel2.TabIndex = 13
        Me.RealPanel2.Text = "RealPanel2"
        '
        'btnEditData
        '
        Me.btnEditData.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEditData.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEditData.Image = CType(resources.GetObject("btnEditData.Image"), System.Drawing.Image)
        Me.btnEditData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEditData.Location = New System.Drawing.Point(4, 90)
        Me.btnEditData.Name = "btnEditData"
        Me.btnEditData.Size = New System.Drawing.Size(110, 36)
        Me.btnEditData.TabIndex = 8
        Me.btnEditData.Text = "Edi&t Data"
        Me.btnEditData.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnExportReport
        '
        Me.btnExportReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExportReport.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExportReport.Image = CType(resources.GetObject("btnExportReport.Image"), System.Drawing.Image)
        Me.btnExportReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExportReport.Location = New System.Drawing.Point(4, 47)
        Me.btnExportReport.Name = "btnExportReport"
        Me.btnExportReport.Size = New System.Drawing.Size(110, 36)
        Me.btnExportReport.TabIndex = 7
        Me.btnExportReport.Text = "E&xport Report"
        Me.btnExportReport.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'btnReportOptions
        '
        Me.btnReportOptions.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnReportOptions.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReportOptions.Image = CType(resources.GetObject("btnReportOptions.Image"), System.Drawing.Image)
        Me.btnReportOptions.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReportOptions.Location = New System.Drawing.Point(4, 4)
        Me.btnReportOptions.Name = "btnReportOptions"
        Me.btnReportOptions.Size = New System.Drawing.Size(110, 36)
        Me.btnReportOptions.TabIndex = 6
        Me.btnReportOptions.Text = "Report &Options"
        Me.btnReportOptions.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'RealPanel1
        '
        Me.RealPanel1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.RealPanel1.Controls.Add(Me.btnReports)
        Me.RealPanel1.Controls.Add(Me.btnViewResults)
        Me.RealPanel1.Controls.Add(Me.btnSampleGraph)
        Me.RealPanel1.Controls.Add(Me.btnStandardGraph)
        Me.RealPanel1.Location = New System.Drawing.Point(7, 86)
        Me.RealPanel1.Name = "RealPanel1"
        Me.RealPanel1.Size = New System.Drawing.Size(118, 176)
        Me.RealPanel1.TabIndex = 12
        Me.RealPanel1.Text = "RealPanel1"
        '
        'btnReports
        '
        Me.btnReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnReports.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReports.Image = CType(resources.GetObject("btnReports.Image"), System.Drawing.Image)
        Me.btnReports.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReports.Location = New System.Drawing.Point(4, 136)
        Me.btnReports.Name = "btnReports"
        Me.btnReports.Size = New System.Drawing.Size(110, 36)
        Me.btnReports.TabIndex = 4
        Me.btnReports.Text = "&Reports"
        Me.btnReports.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnViewResults
        '
        Me.btnViewResults.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnViewResults.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnViewResults.Image = CType(resources.GetObject("btnViewResults.Image"), System.Drawing.Image)
        Me.btnViewResults.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnViewResults.Location = New System.Drawing.Point(4, 92)
        Me.btnViewResults.Name = "btnViewResults"
        Me.btnViewResults.Size = New System.Drawing.Size(110, 36)
        Me.btnViewResults.TabIndex = 3
        Me.btnViewResults.Text = "&View Results"
        Me.btnViewResults.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'btnSampleGraph
        '
        Me.btnSampleGraph.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSampleGraph.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSampleGraph.Image = CType(resources.GetObject("btnSampleGraph.Image"), System.Drawing.Image)
        Me.btnSampleGraph.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSampleGraph.Location = New System.Drawing.Point(4, 48)
        Me.btnSampleGraph.Name = "btnSampleGraph"
        Me.btnSampleGraph.Size = New System.Drawing.Size(110, 36)
        Me.btnSampleGraph.TabIndex = 2
        Me.btnSampleGraph.Text = "Sample   &Graph"
        Me.btnSampleGraph.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'btnStandardGraph
        '
        Me.btnStandardGraph.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnStandardGraph.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStandardGraph.Image = CType(resources.GetObject("btnStandardGraph.Image"), System.Drawing.Image)
        Me.btnStandardGraph.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnStandardGraph.Location = New System.Drawing.Point(4, 4)
        Me.btnStandardGraph.Name = "btnStandardGraph"
        Me.btnStandardGraph.Size = New System.Drawing.Size(110, 36)
        Me.btnStandardGraph.TabIndex = 1
        Me.btnStandardGraph.Text = "Sta&ndard Graph"
        Me.btnStandardGraph.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'btnExtinguish
        '
        Me.btnExtinguish.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExtinguish.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExtinguish.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExtinguish.Location = New System.Drawing.Point(38, 36)
        Me.btnExtinguish.Name = "btnExtinguish"
        Me.btnExtinguish.Size = New System.Drawing.Size(16, 14)
        Me.btnExtinguish.TabIndex = 11
        Me.btnExtinguish.TabStop = False
        Me.btnExtinguish.Text = "&Extinguish"
        Me.btnExtinguish.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'HeaderLeft
        '
        Me.HeaderLeft.BackColor = System.Drawing.SystemColors.Control
        Me.HeaderLeft.Dock = System.Windows.Forms.DockStyle.Top
        Me.HeaderLeft.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HeaderLeft.Location = New System.Drawing.Point(0, 0)
        Me.HeaderLeft.Name = "HeaderLeft"
        Me.HeaderLeft.Size = New System.Drawing.Size(132, 22)
        Me.HeaderLeft.TabIndex = 8
        Me.HeaderLeft.TitleFont = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HeaderLeft.TitleText = "Parameters"
        '
        'btnIgnite
        '
        Me.btnIgnite.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnIgnite.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIgnite.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnIgnite.Location = New System.Drawing.Point(66, 36)
        Me.btnIgnite.Name = "btnIgnite"
        Me.btnIgnite.Size = New System.Drawing.Size(16, 14)
        Me.btnIgnite.TabIndex = 10
        Me.btnIgnite.TabStop = False
        Me.btnIgnite.Text = "&Ignition"
        Me.btnIgnite.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'frmTest_DataFiles
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(800, 561)
        Me.Controls.Add(Me.CustomPanelMain)
        Me.Name = "frmTest_DataFiles"
        Me.Text = "frmTest_DataFiles"
        Me.CustomPanelMain.ResumeLayout(False)
        Me.CustomPanelRight.ResumeLayout(False)
        Me.CustomPanelRightTop.ResumeLayout(False)
        Me.CustomPanelRightBottom.ResumeLayout(False)
        Me.CustomPanelLeft.ResumeLayout(False)
        Me.RealPanel3.ResumeLayout(False)
        Me.RealPanel2.ResumeLayout(False)
        Me.RealPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Commented old analysis form code"
    '    Imports AAS203.Common
    'Imports System.Threading
    'Imports AAS203Library
    'Imports AAS203Library.Analysis
    'Imports AAS203Library.Method
    'Imports AAS203Library.Method.clsQuantitativeData

    'Imports BgThread
    '    Public Class frmTest_Analysis
    '        Inherits System.Windows.Forms.Form
    '        Implements BgThread.Iclient

    '#Region " Windows Form Designer generated code "

    '        Public Sub New()
    '            MyBase.New()

    '            'This call is required by the Windows Form Designer.
    '            InitializeComponent()

    '            'Add any initialization after the InitializeComponent() call

    '        End Sub

    '        'Form overrides dispose to clean up the component list.
    '        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
    '            If disposing Then
    '                If Not (components Is Nothing) Then
    '                    components.Dispose()
    '                End If
    '            End If
    '            MyBase.Dispose(disposing)
    '        End Sub

    '        'Required by the Windows Form Designer
    '        Private components As System.ComponentModel.IContainer

    '        'NOTE: The following procedure is required by the Windows Form Designer
    '        'It can be modified using the Windows Form Designer.  
    '        'Do not modify it using the code editor.
    '        Friend WithEvents mnuBack As NETXP.Controls.Bars.CommandBarButtonItem
    '        Friend WithEvents mnuStandardGraph As NETXP.Controls.Bars.CommandBarButtonItem
    '        Friend WithEvents mnuSampleGraph As NETXP.Controls.Bars.CommandBarButtonItem
    '        Friend WithEvents mnuViewResults As NETXP.Controls.Bars.CommandBarButtonItem
    '        Friend WithEvents mnuBack1 As NETXP.Controls.Bars.CommandBarButtonItem
    '        Friend WithEvents mnuReports As NETXP.Controls.Bars.CommandBarButtonItem
    '        Friend WithEvents tmrAspirationMsg As System.Timers.Timer
    '        Friend WithEvents btnStartStopAnalysis As NETXP.Controls.XPButton
    '        Friend WithEvents btnReadData As NETXP.Controls.XPButton
    '        Friend WithEvents CustomPanelMain As GradientPanel.CustomPanel
    '        Friend WithEvents CustomPanel1 As GradientPanel.CustomPanel
    '        Friend WithEvents custPnlASPMessages As GradientPanel.CustomPanel
    '        Friend WithEvents lblAspirationMessage As System.Windows.Forms.Label
    '        Friend WithEvents btnNewAnalysis As NETXP.Controls.XPButton
    '        Friend WithEvents lblOptimizedWavelength As System.Windows.Forms.Label
    '        Friend WithEvents btnNextAnalysis As NETXP.Controls.XPButton
    '        Friend WithEvents btnExtinguish As NETXP.Controls.XPButton
    '        Friend WithEvents btnIgnite As NETXP.Controls.XPButton
    '        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    '            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmTest_Analysis))
    '            Me.mnuBack = New NETXP.Controls.Bars.CommandBarButtonItem
    '            Me.mnuStandardGraph = New NETXP.Controls.Bars.CommandBarButtonItem
    '            Me.mnuSampleGraph = New NETXP.Controls.Bars.CommandBarButtonItem
    '            Me.mnuViewResults = New NETXP.Controls.Bars.CommandBarButtonItem
    '            Me.mnuBack1 = New NETXP.Controls.Bars.CommandBarButtonItem
    '            Me.mnuReports = New NETXP.Controls.Bars.CommandBarButtonItem
    '            Me.tmrAspirationMsg = New System.Timers.Timer
    '            Me.CustomPanel1 = New GradientPanel.CustomPanel
    '            Me.btnReadData = New NETXP.Controls.XPButton
    '            Me.btnStartStopAnalysis = New NETXP.Controls.XPButton
    '            Me.btnIgnite = New NETXP.Controls.XPButton
    '            Me.btnExtinguish = New NETXP.Controls.XPButton
    '            Me.btnNextAnalysis = New NETXP.Controls.XPButton
    '            Me.lblOptimizedWavelength = New System.Windows.Forms.Label
    '            Me.btnNewAnalysis = New NETXP.Controls.XPButton
    '            Me.custPnlASPMessages = New GradientPanel.CustomPanel
    '            Me.lblAspirationMessage = New System.Windows.Forms.Label
    '            Me.CustomPanelMain = New GradientPanel.CustomPanel
    '            CType(Me.tmrAspirationMsg, System.ComponentModel.ISupportInitialize).BeginInit()
    '            Me.CustomPanel1.SuspendLayout()
    '            Me.custPnlASPMessages.SuspendLayout()
    '            Me.CustomPanelMain.SuspendLayout()
    '            Me.SuspendLayout()
    '            '
    '            'mnuBack
    '            '
    '            Me.mnuBack.Shortcut = System.Windows.Forms.Shortcut.CtrlB
    '            Me.mnuBack.Text = "Back"
    '            '
    '            'mnuStandardGraph
    '            '
    '            Me.mnuStandardGraph.Shortcut = System.Windows.Forms.Shortcut.CtrlT
    '            Me.mnuStandardGraph.Text = "Standard Graph"
    '            '
    '            'mnuSampleGraph
    '            '
    '            Me.mnuSampleGraph.Shortcut = System.Windows.Forms.Shortcut.CtrlA
    '            Me.mnuSampleGraph.Text = "Sample Graph"
    '            '
    '            'mnuViewResults
    '            '
    '            Me.mnuViewResults.Shortcut = System.Windows.Forms.Shortcut.CtrlU
    '            Me.mnuViewResults.Text = "View Results"
    '            '
    '            'mnuBack1
    '            '
    '            Me.mnuBack1.Shortcut = System.Windows.Forms.Shortcut.CtrlZ
    '            Me.mnuBack1.Text = "Back"
    '            '
    '            'mnuReports
    '            '
    '            Me.mnuReports.Shortcut = System.Windows.Forms.Shortcut.CtrlR
    '            Me.mnuReports.Text = "Reports"
    '            '
    '            'tmrAspirationMsg
    '            '
    '            Me.tmrAspirationMsg.Enabled = True
    '            Me.tmrAspirationMsg.Interval = 500
    '            Me.tmrAspirationMsg.SynchronizingObject = Me
    '            '
    '            'CustomPanel1
    '            '
    '            Me.CustomPanel1.BackColor = System.Drawing.Color.AliceBlue
    '            Me.CustomPanel1.BackColor2 = System.Drawing.Color.Transparent
    '            Me.CustomPanel1.Controls.Add(Me.btnReadData)
    '            Me.CustomPanel1.Controls.Add(Me.btnStartStopAnalysis)
    '            Me.CustomPanel1.Controls.Add(Me.btnIgnite)
    '            Me.CustomPanel1.Controls.Add(Me.btnExtinguish)
    '            Me.CustomPanel1.Controls.Add(Me.btnNextAnalysis)
    '            Me.CustomPanel1.Controls.Add(Me.lblOptimizedWavelength)
    '            Me.CustomPanel1.Controls.Add(Me.btnNewAnalysis)
    '            Me.CustomPanel1.Controls.Add(Me.custPnlASPMessages)
    '            Me.CustomPanel1.Location = New System.Drawing.Point(0, 0)
    '            Me.CustomPanel1.Name = "CustomPanel1"
    '            Me.CustomPanel1.Size = New System.Drawing.Size(464, 208)
    '            Me.CustomPanel1.TabIndex = 8
    '            '
    '            'btnReadData
    '            '
    '            Me.btnReadData.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    '            Me.btnReadData.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    '            Me.btnReadData.Image = CType(resources.GetObject("btnReadData.Image"), System.Drawing.Image)
    '            Me.btnReadData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
    '            Me.btnReadData.Location = New System.Drawing.Point(264, 56)
    '            Me.btnReadData.Name = "btnReadData"
    '            Me.btnReadData.Size = New System.Drawing.Size(110, 36)
    '            Me.btnReadData.TabIndex = 7
    '            Me.btnReadData.Text = "&Read Data"
    '            Me.btnReadData.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '            '
    '            'btnStartStopAnalysis
    '            '
    '            Me.btnStartStopAnalysis.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    '            Me.btnStartStopAnalysis.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    '            Me.btnStartStopAnalysis.Image = CType(resources.GetObject("btnStartStopAnalysis.Image"), System.Drawing.Image)
    '            Me.btnStartStopAnalysis.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
    '            Me.btnStartStopAnalysis.Location = New System.Drawing.Point(56, 56)
    '            Me.btnStartStopAnalysis.Name = "btnStartStopAnalysis"
    '            Me.btnStartStopAnalysis.RightToLeft = System.Windows.Forms.RightToLeft.No
    '            Me.btnStartStopAnalysis.Size = New System.Drawing.Size(104, 36)
    '            Me.btnStartStopAnalysis.TabIndex = 6
    '            Me.btnStartStopAnalysis.Text = "Start Anal&ysis"
    '            Me.btnStartStopAnalysis.TextAlign = System.Drawing.ContentAlignment.TopLeft
    '            '
    '            'btnIgnite
    '            '
    '            Me.btnIgnite.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    '            Me.btnIgnite.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
    '            Me.btnIgnite.Location = New System.Drawing.Point(296, 200)
    '            Me.btnIgnite.Name = "btnIgnite"
    '            Me.btnIgnite.Size = New System.Drawing.Size(48, 20)
    '            Me.btnIgnite.TabIndex = 29
    '            Me.btnIgnite.TabStop = False
    '            Me.btnIgnite.Text = "&Ignite"
    '            '
    '            'btnExtinguish
    '            '
    '            Me.btnExtinguish.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    '            Me.btnExtinguish.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
    '            Me.btnExtinguish.Location = New System.Drawing.Point(88, 172)
    '            Me.btnExtinguish.Name = "btnExtinguish"
    '            Me.btnExtinguish.Size = New System.Drawing.Size(56, 20)
    '            Me.btnExtinguish.TabIndex = 28
    '            Me.btnExtinguish.TabStop = False
    '            Me.btnExtinguish.Text = "&Extinguish"
    '            '
    '            'btnNextAnalysis
    '            '
    '            Me.btnNextAnalysis.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    '            Me.btnNextAnalysis.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    '            Me.btnNextAnalysis.Image = CType(resources.GetObject("btnNextAnalysis.Image"), System.Drawing.Image)
    '            Me.btnNextAnalysis.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
    '            Me.btnNextAnalysis.Location = New System.Drawing.Point(208, 160)
    '            Me.btnNextAnalysis.Name = "btnNextAnalysis"
    '            Me.btnNextAnalysis.Size = New System.Drawing.Size(100, 36)
    '            Me.btnNextAnalysis.TabIndex = 27
    '            Me.btnNextAnalysis.Text = "Ne&xt"
    '            Me.btnNextAnalysis.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '            '
    '            'lblOptimizedWavelength
    '            '
    '            Me.lblOptimizedWavelength.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    '            Me.lblOptimizedWavelength.Location = New System.Drawing.Point(8, 184)
    '            Me.lblOptimizedWavelength.Name = "lblOptimizedWavelength"
    '            Me.lblOptimizedWavelength.Size = New System.Drawing.Size(160, 19)
    '            Me.lblOptimizedWavelength.TabIndex = 26
    '            Me.lblOptimizedWavelength.Text = "Optimized Wavelength : "
    '            '
    '            'btnNewAnalysis
    '            '
    '            Me.btnNewAnalysis.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    '            Me.btnNewAnalysis.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    '            Me.btnNewAnalysis.Image = CType(resources.GetObject("btnNewAnalysis.Image"), System.Drawing.Image)
    '            Me.btnNewAnalysis.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
    '            Me.btnNewAnalysis.Location = New System.Drawing.Point(360, 122)
    '            Me.btnNewAnalysis.Name = "btnNewAnalysis"
    '            Me.btnNewAnalysis.Size = New System.Drawing.Size(100, 36)
    '            Me.btnNewAnalysis.TabIndex = 11
    '            Me.btnNewAnalysis.Text = "Ne&w Analysis"
    '            Me.btnNewAnalysis.TextAlign = System.Drawing.ContentAlignment.TopLeft
    '            '
    '            'custPnlASPMessages
    '            '
    '            Me.custPnlASPMessages.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
    '                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    '            Me.custPnlASPMessages.BackColor = System.Drawing.Color.White
    '            Me.custPnlASPMessages.BackColor2 = System.Drawing.Color.Gainsboro
    '            Me.custPnlASPMessages.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    '            Me.custPnlASPMessages.Controls.Add(Me.lblAspirationMessage)
    '            Me.custPnlASPMessages.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    '            Me.custPnlASPMessages.GradientMode = GradientPanel.LinearGradientMode.Horizontal
    '            Me.custPnlASPMessages.Location = New System.Drawing.Point(14, 16)
    '            Me.custPnlASPMessages.Name = "custPnlASPMessages"
    '            Me.custPnlASPMessages.Size = New System.Drawing.Size(430, 28)
    '            Me.custPnlASPMessages.TabIndex = 10
    '            '
    '            'lblAspirationMessage
    '            '
    '            Me.lblAspirationMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    '            Me.lblAspirationMessage.Dock = System.Windows.Forms.DockStyle.Fill
    '            Me.lblAspirationMessage.ForeColor = System.Drawing.Color.Maroon
    '            Me.lblAspirationMessage.Location = New System.Drawing.Point(0, 0)
    '            Me.lblAspirationMessage.Name = "lblAspirationMessage"
    '            Me.lblAspirationMessage.Size = New System.Drawing.Size(430, 28)
    '            Me.lblAspirationMessage.TabIndex = 0
    '            Me.lblAspirationMessage.Text = "Aspiration Messages"
    '            Me.lblAspirationMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '            '
    '            'CustomPanelMain
    '            '
    '            Me.CustomPanelMain.BackColor = System.Drawing.Color.AliceBlue
    '            Me.CustomPanelMain.BackColor2 = System.Drawing.Color.AliceBlue
    '            Me.CustomPanelMain.Controls.Add(Me.CustomPanel1)
    '            Me.CustomPanelMain.Location = New System.Drawing.Point(0, 0)
    '            Me.CustomPanelMain.Name = "CustomPanelMain"
    '            Me.CustomPanelMain.Size = New System.Drawing.Size(804, 579)
    '            Me.CustomPanelMain.TabIndex = 17
    '            '
    '            'frmTest_Analysis
    '            '
    '            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    '            Me.ClientSize = New System.Drawing.Size(456, 109)
    '            Me.Controls.Add(Me.CustomPanelMain)
    '            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
    '            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
    '            Me.MaximizeBox = False
    '            Me.MinimizeBox = False
    '            Me.Name = "frmTest_Analysis"
    '            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    '            Me.Text = "Analysis"
    '            CType(Me.tmrAspirationMsg, System.ComponentModel.ISupportInitialize).EndInit()
    '            Me.CustomPanel1.ResumeLayout(False)
    '            Me.custPnlASPMessages.ResumeLayout(False)
    '            Me.CustomPanelMain.ResumeLayout(False)
    '            Me.ResumeLayout(False)

    '        End Sub

    '#End Region

    '#Region " Private Constants "

    '        Private ConstFormLoad As String = gstrTitleInstrumentType & "-Analysis"
    '        Private ConstParentFormLoad As String = gstrTitleInstrumentType & "-Method"

    '#End Region

    '#Region " Private Member Variables "
    '        Dim intDispCount As Integer

    '        Private mdblWvOpt As Double = -1.0
    '        'Private mblnIsAnalysisStarted As Boolean   'Saurabh  10.07.07
    '        Friend mblnIsAnalysisStarted As Boolean    'Saurabh  10.07.07

    '        Private mblnIsAutosampler As Boolean
    '        Private EndAnalysis As Boolean = False
    '        Private mdblAbsorbance As Double

    '        Private mstrAspirationMessage As String
    '        Private mintAspirationTimerCounter As Integer
    '        Private mblnIsBlinkMessage As Boolean

    '        Private SampleType As ClsAAS203.enumSampleType = ClsAAS203.enumSampleType.BLANK
    '        Private LSampType As ClsAAS203.enumSampleType = ClsAAS203.enumSampleType.BLANK
    '        Private mobjParameters As New Spectrum.EnergySpectrumParameter

    '        Private mobjCurrentStandard As AAS203Library.Method.clsAnalysisStdParameters
    '        Private mobjCurrentSample As AAS203Library.Method.clsAnalysisSampleParameters


    '        Private mobjStandardEnumerator As IEnumerator
    '        Private mobjSampleEnumerator As IEnumerator

    '        Private mobjAnalysisRawData As New Analysis.clsRawDataCollection
    '        Private mobjBlankRawData As Analysis.clsRawData
    '        Private mobjStandardRawData As Analysis.clsRawData
    '        Private mobjSampleRawData As Analysis.clsRawData

    '        Private CurRepeat As Integer = 1

    '        Private StdAnalysed As Boolean = False
    '        Private AnaOver As Boolean = False
    '        Private methchange As Boolean = False
    '        Private InQAnaRead As Boolean = False
    '        Private toreported As Boolean = False

    '        '---for checking the method is in analysis mode or not
    '        Public InAnalysis As Boolean = False
    '        Public exitbutton As Boolean = False
    '        Public ANALYSIS As Boolean

    '        Private mintSelectedInstrumentConditionIndex As Integer

    '        Private mobjGraphCurve As AldysGraph.CurveItem
    '        Private Afirst As Boolean

    '        Private mStartTime As Integer
    '        Private mEndTime As Integer

    '        Private XOld, YOld As Double

    '        Private Filter_flag As Boolean = True

    '        Private mdblBlankAbsorbance As Double = 0.0

    '        Public mblnIsStartRunNumber As Boolean = True

    '        '---For Background Worker Thread functions
    '        Private mController As clsBgThread

    '        Public mobjBgReadData As New clsBgReadData

    '        Private mintRunNumberIndex As Integer

    '        Private mintSelectedMethodID As Integer     'Saurabh 
    '        Private mlngSelectedRunNumber As Long    'Saurabh
    '        Private mobjClsMethod As clsMethod          'Sauarbh

    '        Private mblnRepeatLastBlank As Boolean
    '        Private mblnRepeatLastStd As Boolean
    '        Private mblnRepeatLastSample As Boolean

    '        Private mobjClsDataFileReport As New clsDataFileReport 'Saurabh 07-06-2007
    '        Private intIEnumCollLocationStd As Integer
    '        Private intIEnumCollLocationSamp As Integer
    '        Private mblnAvoidProcessing As Boolean = False
    '        Private blnIsAspirateTimer As Boolean = False
    '#End Region

    '#Region " Private Properties "

    '        Private Property AspirationMessage() As String
    '            Get
    '                Return mstrAspirationMessage
    '            End Get
    '            Set(ByVal Value As String)
    '                mstrAspirationMessage = Value
    '            End Set
    '        End Property

    '#End Region

    '#Region " Form Load and Event Handling Functions "

    '        Private Sub frmAnalysis_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
    '            '=====================================================================
    '            ' Procedure Name        : frmAnalysis_Load
    '            ' Parameters Passed     : Object,EventArgs
    '            ' Returns               : None
    '            ' Purpose               : To initialize the form
    '            ' Description           : 
    '            ' Assumptions           : 
    '            ' Dependencies          : 
    '            ' Author                : Deepak Bhati and Mangesh Shardul
    '            ' Created               : 07.10.06
    '            ' Revisions             : 
    '            '=====================================================================
    '            Dim objWait As New CWaitCursor

    '            Try
    '                'If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
    '                '    btnIgnite.Enabled = False
    '                '    btnExtinguish.Enabled = False
    '                'End If

    '                'btnStdGraph.BringToFront()
    '                'btnSplGraph.BringToFront()
    '                'btnStdGraph.Focus()
    '                'btnSave.Enabled = False
    '                ''cmdChangeScale.Location = New Point(14, 378)
    '                ''btnExportReport.Location = New Point(14, 419)
    '                ''Me.FormBorderStyle = FormBorderStyle.FixedSingle
    '                ''gobjMain.ShowProgressBar(ConstFormLoad)

    '                Call AddHandlers()
    '                '//----- Sachin Dokhale
    '                btnStartStopAnalysis.BringToFront()
    '                btnReadData.BringToFront()

    '                If Not (gobjNewMethod.OperationMode = EnumOperationMode.MODE_UVABS Or _
    '                    gobjNewMethod.OperationMode = EnumOperationMode.MODE_UVSPECT Or _
    '                    gobjNewMethod.OperationMode = EnumOperationMode.MODE_EMMISSION) Then
    '                    ''-----Added By Pankaj on 10 May 2007
    '                    '    AASGraphAnalysis.YAxisMin = -0.2
    '                    '    AASGraphAnalysis.YAxisMax = 1.2
    '                    '    gobjClsAAS203.Calculate_Analysis_Graph_Param(AASGraphAnalysis, ClsAAS203.enumChangeAxis.xyAxis)

    '                    '    'Elseif Added by Saurabh
    '                    'ElseIf gobjNewMethod.OperationMode = EnumOperationMode.MODE_EMMISSION Then
    '                    '    AASGraphAnalysis.YAxisMin = 0
    '                    '    AASGraphAnalysis.YAxisMax = 100
    '                    '    'AASGraphAnalysis.YAxisStep = 10
    '                    '    'AASGraphAnalysis.YAxisMinorStep = 10
    '                    '    AASGraphAnalysis.YAxisLabel = "EMISSION"
    '                    '    gobjClsAAS203.Calculate_Analysis_Graph_Param(AASGraphAnalysis, ClsAAS203.enumChangeAxis.xyAxis)
    '                    'Else
    '                    '    cmdChangeScale.Enabled = False
    '                    '    cmdChangeScale.Visible = False
    '                    '    btnPrintGraph.Enabled = False
    '                    '    btnPrintGraph.Visible = False
    '                End If
    '                ''//--- --
    '                ''-------------


    '            Catch ex As Exception
    '                '---------------------------------------------------------
    '                'Error Handling and logging
    '                gobjErrorHandler.ErrorDescription = ex.Message
    '                gobjErrorHandler.ErrorMessage = ex.Message
    '                gobjErrorHandler.WriteErrorLog(ex)
    '                '---------------------------------------------------------
    '            Finally
    '                '---------------------------------------------------------
    '                'Writing Execution log
    '                If CONST_CREATE_EXECUTION_LOG = 1 Then
    '                    gobjErrorHandler.WriteExecutionLog()
    '                End If
    '                objWait.Dispose()
    '                'gobjMain.HideProgressBar()
    '                '---------------------------------------------------------
    '            End Try
    '        End Sub

    '        Private Sub AddHandlers()
    '            '=====================================================================
    '            ' Procedure Name        : AddHandlers
    '            ' Parameters Passed     : None
    '            ' Returns               : None
    '            ' Purpose               : To add event handlers
    '            ' Description           : 
    '            ' Assumptions           : 
    '            ' Dependencies          : 
    '            ' Author                : Saurabh
    '            ' Created               : 05.10.06
    '            ' Revisions             : 
    '            '=====================================================================
    '            Try
    '                AddHandler btnIgnite.Click, AddressOf btnIgnite_Click
    '                AddHandler btnExtinguish.Click, AddressOf btnExtinguish_Click

    '                AddHandler btnStartStopAnalysis.Click, AddressOf StartStopAnalysis_Click
    '                AddHandler btnReadData.Click, AddressOf ReadData_Click

    '                If blnIsAspirateTimer = False Then
    '                    AddHandler tmrAspirationMsg.Elapsed, AddressOf tmrAspirationMsg_Elapsed
    '                    blnIsAspirateTimer = True
    '                End If
    '            Catch ex As Exception
    '                '---------------------------------------------------------
    '                'Error Handling and logging
    '                gobjErrorHandler.ErrorDescription = ex.Message
    '                gobjErrorHandler.ErrorMessage = ex.Message
    '                gobjErrorHandler.WriteErrorLog(ex)
    '                '---------------------------------------------------------
    '            Finally
    '                '---------------------------------------------------------
    '                'Writing Execution log
    '                If CONST_CREATE_EXECUTION_LOG = 1 Then
    '                    gobjErrorHandler.WriteExecutionLog()
    '                End If
    '                '---------------------------------------------------------
    '            End Try
    '        End Sub

    '        Private Sub tmrAspirationMsg_Elapsed(ByVal sender As System.Object, ByVal e As System.Timers.ElapsedEventArgs)
    '            'case	WM_TIMER:
    '            '   tAsp++;
    '            '   If (tAsp > 1000) Then
    '            '       tAsp=1;
    '            '   if (tAsp%3==0)							
    '            '       ShowAspMessage(FALSE);
    '            '   Else
    '            '       ShowAspMessage(TRUE);
    '            'break;
    '            Try
    '                ' Application.DoEvents()
    '                mintAspirationTimerCounter += 1
    '                If (mintAspirationTimerCounter > 1000) Then
    '                    mintAspirationTimerCounter = 1
    '                End If

    '                '---Saurabh---20.06.07
    '                'If btnReadData.Enabled = True Then
    '                '    btnReadData.Focus()
    '                '    btnReadData.Refresh()
    '                'End If
    '                'Application.DoEvents()
    '                'Saruabh

    '                If (mintAspirationTimerCounter Mod 3 = 0) Then
    '                    If mblnIsBlinkMessage Then
    '                        Call ShowAspirationMessages(False)
    '                    Else
    '                        Call ShowAspirationMessages(True)
    '                    End If
    '                    'Application.DoEvents()
    '                Else
    '                    Call ShowAspirationMessages(True)
    '                    'Application.DoEvents()
    '                End If
    '                'Application.DoEvents()
    '            Catch ex As Exception
    '                '---------------------------------------------------------
    '                'Error Handling and logging
    '                gobjErrorHandler.ErrorDescription = ex.Message
    '                gobjErrorHandler.ErrorMessage = ex.Message
    '                gobjErrorHandler.WriteErrorLog(ex)
    '                '---------------------------------------------------------
    '            Finally
    '                '---------------------------------------------------------
    '                'Writing Execution log
    '                If CONST_CREATE_EXECUTION_LOG = 1 Then
    '                    gobjErrorHandler.WriteExecutionLog()
    '                End If
    '                '---------------------------------------------------------
    '            End Try
    '        End Sub

    '        Private Sub NewAnalysis_Clicked(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '            'case	IDC_QANEW:
    '            '#If STD_ADDN Then
    '            '   endanalysis= FALSE;
    '            '#End If
    '            'DeleteAllRawData(FALSE);
    '            'mobjCurrentStandard  =Method->QuantData->StdTopData;
    '            'mobjCurrentSample =Method->QuantData->SampTopData;
    '            'CurRepeat=1;

    '            'if(mobjCurrentStandard!=NULL  && StdAnalysed)
    '            '{
    '            '   if(Method->QuantData->Param.Std_Addn)
    '            '	    i = IDNO;
    '            '	else{
    '            '       If (!methchange) Then        
    '            '		    i=MessageBox(hwnd,"Do you want to use the previous standards","INFORMATION", MB_ICONQUESTION | MB_YESNO);
    '            '		else
    '            '		    i=IDNO;
    '            '   }
    '            'if(i==IDNO)
    '            '   Clear_All_Abs_Std(Method->QuantData->StdTopData);
    '            'Else
    '            '   mobjCurrentStandard=NULL;
    '            '}
    '            'methchange = FALSE;	
    '            'if(!StdAnalysed) 
    '            '   Clear_All_Abs_Std(Method->QuantData->StdTopData);
    '            'Clear_All_Abs_Conc_Samp(Method->QuantData->SampTopData);
    '            'SampType=BLANK;
    '            'Xtime=0;Afirst=TRUE;
    '            '	
    '            'if(i==6)
    '            '   StdAnalysed =TRUE;
    '            'Else
    '            '	StdAnalysed =FALSE;
    '            'Method->RepReady=FALSE;
    '            'if (lParam!=100L){
    '            '   AppendMethod(Method, QALL);
    '            '	Method->QuantData->Fname =-1.0;
    '            '}
    '            'if (Method->QuantData->Fname<=0)
    '            '   GetRunNo(Method);
    '            'AnaGraph.Xmin=0; AnaGraph.Xmax=10*10.0;
    '            'Calculate_Analysis_Graph_Param(&AnaGraph);
    '            'AnaOver=FALSE;
    '            'if (hwnd){
    '            '   DisplayRunNo(hwnd);
    '            '	InvalidateRect(hwnd, NULL, TRUE);
    '            '}
    '            'Method->QuantData->cMode=-2;

    '            'EnableWindow(GetDlgItem(hwnd,IDC_QARPT),FALSE); // add by sss
    '            'if(Method->QuantData)
    '            '   aafname = Method->QuantData->Fname;
    '            'break;

    '            '*****************************************
    '            '---CODE BY MANGESH 
    '            '*****************************************
    '            'On NEW Analysis
    '            Dim dblFuelRatio As Double
    '            Dim objDlgResult As DialogResult

    '            '---18.06.07
    '            Try
    '                '----added by deepak for new analysis on 28.04.07
    '                'lblAbsorbance.Text = ""
    '                'lblAverageAbsorbance.Text = ""
    '                'lblCorrectedAbsorbance.Text = ""
    '                'lblSampleID.Text = ""
    '                'lblRepeatNo.Text = ""
    '                'lblConcentration.Text = ""
    '                '------------------

    '                gobjclsStandardGraph = New clsStandardGraph

    '                '---Get the last RunNumber 

    '                'If gobjNewMethod.QuantitativeDataCollection.Count > 0 Then
    '                '    mintRunNumberIndex = gobjNewMethod.QuantitativeDataCollection.Count - 1
    '                'ElseIf gobjNewMethod.QuantitativeDataCollection.Count <= 0 Then
    '                '    mintRunNumberIndex = -1
    '                'End If

    '                If gobjNewMethod.StandardAddition Then
    '                    EndAnalysis = False
    '                End If

    '                'DeleteAllRawData(False)
    '                '//----- Modifed by Sachin Dokhale
    '                ''mobjAnalysisRawData.Clear()
    '                'mobjAnalysisRawData.Dispose()
    '                mobjAnalysisRawData = Nothing
    '                mobjAnalysisRawData = New Analysis.clsRawDataCollection
    '                '//-----
    '                mobjBlankRawData = Nothing
    '                mobjStandardRawData = Nothing
    '                mobjSampleRawData = Nothing
    '                ''//-----


    '                '*************************************************************************
    '                '---- Commented by Mangesh on 10-May-2007
    '                '*************************************************************************
    '                '---Gets the First Standard from Standard Collection
    '                If Not IsNothing(gobjNewMethod.StandardDataCollection) Then
    '                    mobjStandardEnumerator = gobjNewMethod.StandardDataCollection.GetEnumerator()
    '                    mobjStandardEnumerator.Reset()
    '                    intIEnumCollLocationStd = 0
    '                    If mobjStandardEnumerator.MoveNext() Then
    '                        intIEnumCollLocationStd = 1
    '                        mobjCurrentStandard = CType(mobjStandardEnumerator.Current(), Method.clsAnalysisStdParameters)
    '                    End If
    '                End If

    '                '---Gets the First Sample from Sample Collection
    '                If Not IsNothing(gobjNewMethod.SampleDataCollection) Then
    '                    mobjSampleEnumerator = gobjNewMethod.SampleDataCollection.GetEnumerator()
    '                    mobjSampleEnumerator.Reset()
    '                    intIEnumCollLocationSamp = 0
    '                    If mobjSampleEnumerator.MoveNext() Then
    '                        intIEnumCollLocationSamp = 1
    '                        mobjCurrentSample = CType(mobjSampleEnumerator.Current(), Method.clsAnalysisSampleParameters)
    '                    End If
    '                End If
    '                '*************************************************************************

    '                CurRepeat = 1

    '                If ((Not IsNothing(mobjCurrentStandard)) And StdAnalysed) Then
    '                    If (gobjNewMethod.StandardAddition) Then
    '                        objDlgResult = DialogResult.No
    '                    Else
    '                        If Not (methchange) Then
    '                            If gobjMessageAdapter.ShowMessage(constPreviousStandards) Then
    '                                objDlgResult = DialogResult.Yes
    '                            Else
    '                                objDlgResult = DialogResult.No
    '                            End If
    '                        Else
    '                            objDlgResult = DialogResult.No
    '                        End If
    '                    End If
    '                    'Comment & move by Pankaj on 08 Jun 07 
    '                    'If (objDlgResult = DialogResult.No) Then
    '                    '    Clear_All_Abs_Std(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection)
    '                    'Else
    '                    '    mobjCurrentStandard = Nothing
    '                    'End If
    '                    '------
    '                End If
    '                methchange = False

    '                If Not (StdAnalysed) Then  '---for removing uncompleted std analysis
    '                    Call Clear_All_Abs_Std(gobjNewMethod.StandardDataCollection)
    '                End If
    '                'Moved By Pankaj  on 09 Jun 07
    '                'Call Clear_All_Abs_Conc_Samp(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection)


    '                SampleType = ClsAAS203.enumSampleType.BLANK

    '                Afirst = True
    '                mStartTime = 0.0
    '                mEndTime = mStartTime + 100

    '                'if(i==6)
    '                '   StdAnalysed =TRUE;
    '                'Else
    '                '	StdAnalysed =FALSE;

    '                'Comment & move by Pankaj 08 Jun 06 
    '                'If (objDlgResult = DialogResult.Yes) Then
    '                '    StdAnalysed = True
    '                'Else
    '                '    StdAnalysed = False
    '                'End If
    '                '---------

    '                'gobjNewMethod.AnalysisParameters.RepReady = False

    '                If (mblnIsStartRunNumber) Then
    '                    'AppendMethod(Method, QALL)
    '                    'If (CInt(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).RunNumber) >= 0) Then
    '                    Dim objclsQuantitativeData As AAS203Library.Method.clsQuantitativeData
    '                    objclsQuantitativeData = New AAS203Library.Method.clsQuantitativeData
    '                    objclsQuantitativeData.AnalysisParameters = gobjNewMethod.AnalysisParameters.Clone()
    '                    objclsQuantitativeData.ReportParameters = gobjNewMethod.ReportParameters.Clone()
    '                    objclsQuantitativeData.StandardDataCollection = gobjNewMethod.StandardDataCollection.Clone()
    '                    objclsQuantitativeData.SampleDataCollection = gobjNewMethod.SampleDataCollection.Clone()
    '                    'objclsQuantitativeData.CalculationMode = gobjNewMethod.CalculationMode
    '                    gobjNewMethod.QuantitativeDataCollection.Add(objclsQuantitativeData)
    '                    'mintRunNumberIndex += 1
    '                    mintRunNumberIndex = gobjNewMethod.QuantitativeDataCollection.Count - 1
    '                    gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).RunNumber = -1.0
    '                    'End If
    '                    mblnIsStartRunNumber = False
    '                End If
    '                'Added By Pankaj on 08 Jun 07
    '                If ((Not IsNothing(mobjCurrentStandard)) And StdAnalysed) Then
    '                    If (objDlgResult = DialogResult.No) Then
    '                        Clear_All_Abs_Std(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection)
    '                    Else
    '                        mobjCurrentStandard = Nothing
    '                    End If
    '                End If
    '                Call Clear_All_Abs_Conc_Samp(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection)
    '                '------------------
    '                'Comment & move by Pankaj 08 Jun 06 
    '                If (objDlgResult = DialogResult.Yes) Then
    '                    StdAnalysed = True
    '                Else
    '                    StdAnalysed = False
    '                End If
    '                '---------
    '                If (CInt(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).RunNumber) <= 0) Then
    '                    ' Call GetRunNo(gobjNewMethod)
    '                End If

    '                '*************************************************************************
    '                '---- Added by Mangesh on 10-May-2007
    '                '*************************************************************************
    '                '---Gets the First Standard from Standard Collection
    '                If Not IsNothing(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection) Then
    '                    mobjStandardEnumerator = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.GetEnumerator()
    '                    mobjStandardEnumerator.Reset()
    '                    intIEnumCollLocationStd = 0
    '                    If mobjStandardEnumerator.MoveNext() Then
    '                        intIEnumCollLocationStd = 1
    '                        mobjCurrentStandard = CType(mobjStandardEnumerator.Current(), Method.clsAnalysisStdParameters)
    '                    End If
    '                End If

    '                '---Gets the First Sample from Sample Collection
    '                If Not IsNothing(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection) Then
    '                    mobjSampleEnumerator = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.GetEnumerator()
    '                    mobjSampleEnumerator.Reset()
    '                    intIEnumCollLocationSamp = 0
    '                    If mobjSampleEnumerator.MoveNext() Then
    '                        intIEnumCollLocationSamp = 1
    '                        mobjCurrentSample = CType(mobjSampleEnumerator.Current(), Method.clsAnalysisSampleParameters)
    '                    End If
    '                End If

    '                If (objDlgResult = DialogResult.Yes) Then
    '                    mobjCurrentStandard = Nothing
    '                End If
    '                '*************************************************************************

    '                'If AASGraphAnalysis.AldysPane.CurveList.Count > 0 Then
    '                '    AASGraphAnalysis.AldysPane.CurveList.Clear()

    '                '    AASGraphAnalysis.AldysPane.AxisChange()
    '                '    AASGraphAnalysis.Invalidate()
    '                '    Application.DoEvents()
    '                'End If

    '                'AASGraphAnalysis.XAxisStep = 20     'Saurabh 06-06-2007
    '                'Call Calculate_Analysis_Graph_Param(AASGraphAnalysis)

    '                'AASGraphAnalysis.XAxisType = AldysGraph.AxisType.Linear
    '                'AASGraphAnalysis.XAxisMin = mStartTime
    '                'AASGraphAnalysis.XAxisMax = mEndTime

    '                'Call Calculate_Analysis_Graph_Param(AASGraphAnalysis)

    '                ''AASGraphAnalysis.AldysPane.XAxis.StepAuto = True
    '                ''AASGraphAnalysis.AldysPane.XAxis.MinorStepAuto = True
    '                ''AASGraphAnalysis.AldysPane.XAxis.PickScale(AASGraphAnalysis.XAxisMin, AASGraphAnalysis.XAxisMax)

    '                'AASGraphAnalysis.Refresh()
    '                'Application.DoEvents()

    '                AnaOver = False

    '                Call DisplayRunNo()

    '                'gobjNewMethod.AnalysisParameters.cMode = -2

    '                'tlbbtnRepeatLastAnalysis.Enabled = False
    '                ' btnRepeatLast.Enabled = False
    '                '//----- Save Instrument parameter
    '                'gobjNewMethod.InstrumentCondition.D2Current = gobjInst.D2Current
    '                'gobjNewMethod.InstrumentCondition.LampCurrent = gobjInst.Current
    '                'gobjNewMethod.InstrumentCondition.PmtVoltage = gobjInst.PmtVoltage
    '                'gobjNewMethod.InstrumentCondition.SlitWidth = gobjClsAAS203.funcGet_SlitWidth
    '                If gstructSettings.AppMode = EnumAppMode.FullVersion_203D Then
    '                    'TODO   Add property to gobjNewMethod.InstrumentCondition object for PMT Volt & Exit Slit Wd for Ref. 
    '                    'gobjNewMethod.InstrumentCondition.PmtVoltage = gobjInst.PmtVoltageReference
    '                    'gobjNewMethod.InstrumentCondition.SlitWidth = gobjInst.SlitPositionExit
    '                End If

    '                gobjNewMethod.InstrumentCondition.BurnerHeight = gobjClsAAS203.funcReadBurnerHeight()

    '                If Not (gstructSettings.AppMode = EnumAppMode.DemoMode) Then
    '                    Call gobjCommProtocol.funcGet_NV_Pos()
    '                End If

    '                dblFuelRatio = gobjClsAAS203.funcGet_Fuel_Ratio(True)
    '                gobjNewMethod.InstrumentCondition.FuelRatio = dblFuelRatio
    '                '//-----

    '                'If (gobjNewMethod.AnalysisParameters) Then
    '                '   aafname = gobjNewMethod.AnalysisParameter.Fname
    '                'End If
    '                Call Display_Analysis_Info()
    '                Call CheckValidStdAbs()
    '                If (mblnIsAnalysisStarted) Then
    '                    ANALYSIS = True
    '                    '---Show Blinking Message
    '                    Call Aspirate()
    '                Else
    '                    ANALYSIS = False
    '                End If
    '                mblnRepeatLastStd = False
    '                mblnRepeatLastSample = False

    '            Catch ex As Exception
    '                '---------------------------------------------------------
    '                'Error Handling and logging
    '                gobjErrorHandler.ErrorDescription = ex.Message
    '                gobjErrorHandler.ErrorMessage = ex.Message
    '                gobjErrorHandler.WriteErrorLog(ex)
    '                '---------------------------------------------------------
    '            Finally
    '                '---------------------------------------------------------
    '                'Writing Execution log
    '                If CONST_CREATE_EXECUTION_LOG = 1 Then
    '                    gobjErrorHandler.WriteExecutionLog()
    '                End If
    '                '---------------------------------------------------------
    '            End Try
    '        End Sub

    '        Private Sub NextAnalysis_Clicked(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '            '=====================================================================
    '            ' Procedure Name        : NextAnalysis_Clicked
    '            ' Parameters Passed     : Object, EventArgs
    '            ' Returns               : None
    '            ' Purpose               : 
    '            ' Description           : 
    '            ' Assumptions           : 
    '            ' Dependencies          : 
    '            ' Author                : Mangesh Shardul
    '            ' Created               : 17-Jan-2007 03:25 pm
    '            ' Revisions             : 1
    '            '=====================================================================
    '            'case IDC_QANEXT:
    '            'LSampType=SampType;
    '            'if( SampType==BLANK )
    '            '{
    '            '   SampType=STD;
    '            '	if (CurStd==NULL)
    '            '	    SampType=SAMP;
    '            '	if (SampType==SAMP && CurSamp==NULL)
    '            '   {
    '            '	    InQAnaRead=FALSE;
    '            '       AnaOver=TRUE;
    '            '		SendMessage(hwnd, WM_COMMAND, IDC_QASTART, 0L);
    '            '   }
    '            '}
    '            'else
    '            '{
    '            '   CurRepeat++;
    '            '   if ((CurRepeat>Method->QuantData->Param.Repeat && SampType==SAMP) || (CurRepeat>Method->QuantData->Param.ConcRepeat && SampType==STD))
    '            '   {
    '            '	    CurRepeat=1;
    '            '		if (SampType==STD )
    '            '       {
    '            '           If (CurStd! = NULL) Then
    '            '			    CurStd=CurStd->next;
    '            '			if (CurStd==NULL)
    '            '           {
    '            '			    StdAnalysed=TRUE;
    '            '			    if (!GetBlankCalType())
    '            '               {
    '            '				    Create_Standard_Sample_Curve(hwnd,FALSE);
    '            '
    '            '                   #If STD_ADDN Then
    '            '					    if(Method->QuantData->Param.Std_Addn)
    '            '					        endanalysis= TRUE;
    '            '                   #End If        
    '            '
    '            '				}
    '            '				SampType=SAMP;
    '            '			}
    '            '		}
    '            '		else if (SampType==SAMP)
    '            '       {
    '            '           If (CurSamp! = NULL) Then
    '            '			    CurSamp=CurSamp->next;
    '            '		}
    '            '	}
    '            '	if (Method->QuantData->Param.Blank)
    '            '	    SampType=BLANK;
    '            '}
    '            'InQAnaRead=FALSE;
    '            'EnableWindow(GetDlgItem(hwnd,IDC_SAVEREPORT), StdAnalysed);
    '            'EnableWindow(GetDlgItem(hwnd,IDC_QARPT),TRUE); 

    '            '#If STD_ADDN Then
    '            '   if(endanalysis)
    '            '       SendMessage(hwnd, WM_COMMAND, 951, 0L);
    '            '#End If
    '            'break;

    '            '******************************************************************
    '            '--- CODE BY MANGESH 
    '            '******************************************************************
    '            Try
    '                LSampType = SampleType

    '                If (SampleType = ClsAAS203.enumSampleType.BLANK) Then
    '                    SampleType = ClsAAS203.enumSampleType.STANDARD

    '                    If IsNothing(mobjCurrentStandard) Then
    '                        SampleType = ClsAAS203.enumSampleType.SAMPLE
    '                    End If

    '                    If (SampleType = ClsAAS203.enumSampleType.SAMPLE _
    '                        And IsNothing(mobjCurrentSample)) Then

    '                        InQAnaRead = False
    '                        AnaOver = True
    '                        'SendMessage(hwnd, WM_COMMAND, IDC_QASTART, 0L)
    '                        Call StartStopAnalysis_Click(btnStartStopAnalysis, EventArgs.Empty)
    '                    End If

    '                Else
    '                    CurRepeat += 1

    '                    'if ((CurRepeat>Method->QuantData->Param.Repeat && SampType==SAMP) || (CurRepeat>Method->QuantData->Param.ConcRepeat && SampType==STD)){
    '                    If ((CurRepeat > gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfSampleRepeats _
    '                         And SampleType = ClsAAS203.enumSampleType.SAMPLE) _
    '                        Or (CurRepeat > gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfStdRepeats _
    '                         And SampleType = ClsAAS203.enumSampleType.STANDARD)) Then

    '                        CurRepeat = 1

    '                        If (SampleType = ClsAAS203.enumSampleType.STANDARD) Then
    '                            'If (CurStd! = NULL) Then
    '                            '   CurStd=CurStd->next
    '                            '}

    '                            Call funcGetCurrentStandard(mobjCurrentStandard)



    '                            If IsNothing(mobjCurrentStandard) Then
    '                                StdAnalysed = True
    '                                If Not (gstructSettings.BlankCalculation) Then

    '                                    Call gobjclsStandardGraph.Create_Standard_Sample_Curve(False, True, 0, 0, gobjNewMethod)

    '                                    '#If STD_ADDN Then
    '                                    If gobjNewMethod.StandardAddition Then
    '                                        'if(Method->QuantData->Param.Std_Addn)
    '                                        EndAnalysis = True
    '                                        'End If
    '                                        '#End If
    '                                    End If
    '                                End If
    '                                SampleType = ClsAAS203.enumSampleType.SAMPLE
    '                            End If

    '                        ElseIf (SampleType = ClsAAS203.enumSampleType.SAMPLE) Then
    '                            'If (CurSamp! = NULL) Then
    '                            '   CurSamp=CurSamp->next;
    '                            '}
    '                            'If Not IsNothing(mobjSampleEnumerator) Then
    '                            '    If mblnRepeatLastSample Then
    '                            '        If Not mobjSampleEnumerator.Current Is Nothing Then
    '                            '            mobjCurrentSample = CType(mobjSampleEnumerator.Current, Method.clsAnalysisSampleParameters)
    '                            '        Else
    '                            '            mobjCurrentSample = Nothing
    '                            '        End If
    '                            '    Else
    '                            '        If Not mobjSampleEnumerator.Current Is Nothing Then
    '                            '            If mobjSampleEnumerator.MoveNext() Then
    '                            '                mobjCurrentSample = CType(mobjSampleEnumerator.Current, Method.clsAnalysisSampleParameters)
    '                            '            Else
    '                            '                mobjCurrentSample = Nothing
    '                            '            End If
    '                            '        End If
    '                            '    End If
    '                            '    mblnRepeatLastSample = False
    '                            'End If
    '                            Call funcGetCurrentSample(mobjCurrentSample)
    '                        End If
    '                    End If
    '                    'EnableWindow(GetDlgItem(hwnd, IDC_SAVEREPORT), StdAnalysed)
    '                    'btnSave.Enabled = StdAnalysed

    '                    If (gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.IsBlankAfterEverySampleOrStd) Then
    '                        SampleType = ClsAAS203.enumSampleType.BLANK
    '                    End If

    '                End If

    '                InQAnaRead = False
    '                'tlbbtnSaveReport.Enabled = StdAnalysed
    '                'tlbbtnRepeatLastAnalysis.Enabled = True
    '                'btnEditData.Enabled = StdAnalysed
    '                'btnRepeatLast.Enabled = True

    '                Call Aspirate()

    '                '#If STD_ADDN Then
    '                If gobjNewMethod.StandardAddition Then
    '                    If (EndAnalysis) Then
    '                        'SendMessage(hwnd, WM_COMMAND, 951, 0L)
    '                        '951=>IDC_QASTART
    '                        Call StartStopAnalysis_Click(btnStartStopAnalysis, EventArgs.Empty)
    '                    End If
    '                End If
    '                'End IF

    '            Catch ex As Exception
    '                '---------------------------------------------------------
    '                'Error Handling and logging
    '                gobjErrorHandler.ErrorDescription = ex.Message
    '                gobjErrorHandler.ErrorMessage = ex.Message
    '                gobjErrorHandler.WriteErrorLog(ex)
    '                '---------------------------------------------------------
    '            Finally
    '                '---------------------------------------------------------
    '                'Writing Execution log
    '                If CONST_CREATE_EXECUTION_LOG = 1 Then
    '                    gobjErrorHandler.WriteExecutionLog()
    '                End If
    '                '---------------------------------------------------------
    '            End Try
    '        End Sub

    '        Private Function funcGetCurrentStandard(ByRef objCurrentStandard As Method.clsAnalysisStdParameters) As Boolean
    '            'Static intIEnumCollLocation As Integer
    '            Try
    '                If Not IsNothing(objCurrentStandard) Then
    '                    If mblnRepeatLastStd = True Then
    '                        'If Not mobjStandardEnumerator.Current Is Nothing Then
    '                        '    mobjCurrentStandard = CType(mobjStandardEnumerator.Current, Method.clsAnalysisStdParameters)
    '                        'Else
    '                        '    mobjCurrentStandard = Nothing
    '                        'End If

    '                        If funcMoveEnumerator(mobjStandardEnumerator, intIEnumCollLocationStd) = True Then
    '                            objCurrentStandard = CType(mobjStandardEnumerator.Current, Method.clsAnalysisStdParameters)
    '                        Else
    '                            objCurrentStandard = Nothing
    '                        End If
    '                    Else
    '                        'If Not mobjStandardEnumerator.Current Is Nothing Then
    '                        '    If mobjStandardEnumerator.MoveNext() Then
    '                        '        mobjCurrentStandard = CType(mobjStandardEnumerator.Current, Method.clsAnalysisStdParameters)
    '                        '    Else
    '                        '        mobjCurrentStandard = Nothing
    '                        '    End If
    '                        'End If

    '                        intIEnumCollLocationStd += 1
    '                        If funcMoveEnumerator(mobjStandardEnumerator, intIEnumCollLocationStd) = True Then
    '                            objCurrentStandard = CType(mobjStandardEnumerator.Current, Method.clsAnalysisStdParameters)
    '                        Else
    '                            objCurrentStandard = Nothing
    '                        End If
    '                    End If
    '                    'mblnRepeatLastStd = False
    '                End If
    '                mblnRepeatLastStd = False
    '            Catch ex As Exception
    '                '---------------------------------------------------------
    '                'Error Handling and logging
    '                gobjErrorHandler.ErrorDescription = ex.Message
    '                gobjErrorHandler.ErrorMessage = ex.Message
    '                gobjErrorHandler.WriteErrorLog(ex)
    '                Return False
    '                '---------------------------------------------------------
    '            Finally
    '                '---------------------------------------------------------
    '                'Writing Execution log
    '                If CONST_CREATE_EXECUTION_LOG = 1 Then
    '                    gobjErrorHandler.WriteExecutionLog()
    '                End If
    '                '---------------------------------------------------------
    '            End Try
    '        End Function

    '        Private Function funcGetCurrentSample(ByRef objCurrentSample As Method.clsAnalysisSampleParameters) As Boolean
    '            'Static intIEnumCollLocation As Integer
    '            Try
    '                If Not IsNothing(objCurrentSample) Then
    '                    If mblnRepeatLastSample = True Then
    '                        'If Not mobjStandardEnumerator.Current Is Nothing Then
    '                        '    mobjCurrentStandard = CType(mobjStandardEnumerator.Current, Method.clsAnalysisStdParameters)
    '                        'Else
    '                        '    mobjCurrentStandard = Nothing
    '                        'End If

    '                        If funcMoveSampleEnumerator(mobjSampleEnumerator, intIEnumCollLocationSamp) = True Then
    '                            objCurrentSample = CType(mobjSampleEnumerator.Current, Method.clsAnalysisSampleParameters)
    '                        Else
    '                            objCurrentSample = Nothing
    '                        End If
    '                    Else
    '                        'If Not mobjStandardEnumerator.Current Is Nothing Then
    '                        '    If mobjStandardEnumerator.MoveNext() Then
    '                        '        mobjCurrentStandard = CType(mobjStandardEnumerator.Current, Method.clsAnalysisStdParameters)
    '                        '    Else
    '                        '        mobjCurrentStandard = Nothing
    '                        '    End If
    '                        'End If

    '                        intIEnumCollLocationSamp += 1
    '                        If funcMoveSampleEnumerator(mobjSampleEnumerator, intIEnumCollLocationSamp) = True Then
    '                            objCurrentSample = CType(mobjSampleEnumerator.Current, Method.clsAnalysisSampleParameters)
    '                        Else
    '                            objCurrentSample = Nothing
    '                        End If
    '                    End If
    '                    'mblnRepeatLastSample = False
    '                End If
    '                mblnRepeatLastSample = False
    '            Catch ex As Exception
    '                '---------------------------------------------------------
    '                'Error Handling and logging
    '                gobjErrorHandler.ErrorDescription = ex.Message
    '                gobjErrorHandler.ErrorMessage = ex.Message
    '                gobjErrorHandler.WriteErrorLog(ex)
    '                Return False
    '                '---------------------------------------------------------
    '            Finally
    '                '---------------------------------------------------------
    '                'Writing Execution log
    '                If CONST_CREATE_EXECUTION_LOG = 1 Then
    '                    gobjErrorHandler.WriteExecutionLog()
    '                End If
    '                '---------------------------------------------------------
    '            End Try
    '        End Function

    '        Private Function funcMoveEnumerator(ByRef piEnumarator As IEnumerator, ByVal iLocation As Integer) As Boolean
    '            Dim tmpEnum As IEnumerator
    '            Dim IsLastRecoed As Boolean = False
    '            Try
    '                Dim i As Integer
    '                tmpEnum = piEnumarator
    '                If Not tmpEnum Is Nothing Then

    '                    tmpEnum.Reset()
    '                    For i = 1 To iLocation
    '                        If tmpEnum.MoveNext() = False Then
    '                            IsLastRecoed = True
    '                            Exit For
    '                        End If
    '                    Next
    '                    piEnumarator = tmpEnum
    '                End If
    '                If IsLastRecoed = True Then
    '                    Return False
    '                End If
    '                Return True
    '            Catch ex As Exception
    '                '---------------------------------------------------------
    '                'Error Handling and logging
    '                gobjErrorHandler.ErrorDescription = ex.Message
    '                gobjErrorHandler.ErrorMessage = ex.Message
    '                gobjErrorHandler.WriteErrorLog(ex)
    '                Return False
    '                '---------------------------------------------------------
    '            Finally
    '                '---------------------------------------------------------
    '                'Writing Execution log
    '                If CONST_CREATE_EXECUTION_LOG = 1 Then
    '                    gobjErrorHandler.WriteExecutionLog()
    '                End If
    '                '---------------------------------------------------------
    '            End Try

    '        End Function

    '        Private Function funcMoveSampleEnumerator(ByRef piEnumarator As IEnumerator, ByVal iLocation As Integer) As Boolean
    '            Dim tmpEnum As IEnumerator
    '            Dim IsLastRecoed As Boolean = False
    '            Try
    '                Dim i As Integer
    '                If Not IsNothing(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection) Then
    '                    mobjSampleEnumerator = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.GetEnumerator()
    '                    tmpEnum = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.GetEnumerator()
    '                Else
    '                    tmpEnum = piEnumarator
    '                End If

    '                If Not tmpEnum Is Nothing Then

    '                    tmpEnum.Reset()
    '                    For i = 1 To iLocation
    '                        If tmpEnum.MoveNext() = False Then
    '                            IsLastRecoed = True
    '                            Exit For
    '                        End If
    '                    Next
    '                    piEnumarator = tmpEnum
    '                End If
    '                If IsLastRecoed = True Then
    '                    Return False
    '                End If
    '                Return True
    '            Catch ex As Exception
    '                '---------------------------------------------------------
    '                'Error Handling and logging
    '                gobjErrorHandler.ErrorDescription = ex.Message
    '                gobjErrorHandler.ErrorMessage = ex.Message
    '                gobjErrorHandler.WriteErrorLog(ex)
    '                Return False
    '                '---------------------------------------------------------
    '            Finally
    '                '---------------------------------------------------------
    '                'Writing Execution log
    '                If CONST_CREATE_EXECUTION_LOG = 1 Then
    '                    gobjErrorHandler.WriteExecutionLog()
    '                End If
    '                '---------------------------------------------------------
    '            End Try

    '        End Function

    '        Private Sub BlankAnalysis_Clicked(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '            'case	IDC_BLANK:
    '            '   SampType=BLANK;
    '            '   break;
    '            Try
    '                If Not (SampleType = ClsAAS203.enumSampleType.BLANK) Then
    '                    SampleType = ClsAAS203.enumSampleType.BLANK
    '                    Call Aspirate()
    '                End If

    '            Catch ex As Exception
    '                '---------------------------------------------------------
    '                'Error Handling and logging
    '                gobjErrorHandler.ErrorDescription = ex.Message
    '                gobjErrorHandler.ErrorMessage = ex.Message
    '                gobjErrorHandler.WriteErrorLog(ex)
    '                '---------------------------------------------------------
    '            Finally
    '                '---------------------------------------------------------
    '                'Writing Execution log
    '                If CONST_CREATE_EXECUTION_LOG = 1 Then
    '                    gobjErrorHandler.WriteExecutionLog()
    '                End If
    '                '---------------------------------------------------------
    '            End Try
    '        End Sub

    '        Private Sub StartStopAnalysis_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '            '=====================================================================
    '            ' Procedure Name        : StartStopAnalysis_Click
    '            ' Parameters Passed     : Object, EventArgs
    '            ' Returns               : None
    '            ' Purpose               : 
    '            ' Description           : 
    '            ' Assumptions           : 
    '            ' Dependencies          : 
    '            ' Author                : Mangesh Shardul
    '            ' Created               : 17-Jan-2007 03:25 pm
    '            ' Revisions             : 1
    '            '=====================================================================
    '            'Started ^= 1;
    '            'InAnalysis ^= 1;

    '            'if(Started & !exitbutton){
    '            '   if (MessageBox(hwnd," New Analysis?", "STD/SAMPLE ANALYSIS", MB_ICONQUESTION | MB_YESNO)==IDYES){
    '            '   SendMessage(hwnd, WM_COMMAND,IDC_QANEW, 0L);
    '            '   }
    '            '}
    '            'WP1= wParam;
    '            'if (!AnaOver && (CurStd==NULL && CurSamp==NULL)){
    '            '   If (!StdAnalysed) Then
    '            '       CurStd  =Method->QuantData->StdTopData;
    '            '   #If STD_ADDN Then
    '            '       if(!Method->QuantData->Param.Std_Addn)
    '            '   #End If
    '            '       CurSamp =Method->QuantData->SampTopData;
    '            '}
    '            'CheckAnaButtons(hwnd);
    '            'if (Started){
    '            '   if (AnaOver){
    '            '       if (MessageBox(hwnd," Data Exists in Memory . \n Erase them ?", "STD/SAMPLE ANALYSIS", MB_YESNO)==IDYES)
    '            '           SendMessage(hwnd, WM_COMMAND,IDC_QANEW, 0L);
    '            '   }
    '            '   SetWindowText(GetDlgItem(hwnd, IDC_QASTART), "E&nd Ana");
    '            '   if (Method->QuantData->Fname<=0)
    '            '   GetRunNo(Method);
    '            '   DisplayRunNo(hwnd);
    '            '}
    '            'else{
    '            '   SetWindowText(GetDlgItem(hwnd, IDC_QASTART), "&Start");
    '            '   RawDataSave("rawdata.txt");
    '            '   if (toreported||!Method->RepReady ){
    '            '   SaveQuantResults(hwnd, Method, A1,0);
    '            '   toreported=FALSE;
    '            '   }
    '            '   DestroyAspWnd();
    '            '}
    '            'InQAnaRead=FALSE;
    '            '#If QDEMO Then
    '            '   if (AnaOver)
    '            '       EndFiledataRead();
    '            '#End If
    '            'break;
    '            '------------------------------------------
    '            Try
    '                mblnIsAnalysisStarted = Not mblnIsAnalysisStarted
    '                InAnalysis = Not InAnalysis

    '                If mblnIsAnalysisStarted Then
    '                    'Saurabh Add to check if 'No' is selected
    '                    If (mblnIsAnalysisStarted And (Not exitbutton)) Then
    '                        'If (gobjMessageAdapter.ShowMessage(constNewAnalysis) = True) Then
    '                        'SendMessage(hwnd, WM_COMMAND,IDC_QANEW, 0L)
    '                        Call NewAnalysis_Clicked(btnNewAnalysis, EventArgs.Empty)
    '                        'Else
    '                        'mblnIsAnalysisStarted = Not mblnIsAnalysisStarted
    '                        'InAnalysis = Not InAnalysis
    '                        'Exit Sub
    '                        'End If
    '                    End If
    '                    'Saurabh Add to check if 'No' is selected
    '                    btnStartStopAnalysis.Text = "End Anal&ysis"
    '                    mstrAspirationMessage = "Click End Analysis button to Stop Analysis."
    '                    btnReadData.Enabled = True
    '                    'Saurabh 10.07.07
    '                    If Not IsNothing(gobjMain.mobjfrmMethod) Then
    '                        gobjMain.mobjfrmMethod.btnNewMethod.Enabled = False
    '                        gobjMain.mobjfrmMethod.btnLoadMethod.Enabled = False
    '                    End If
    '                    'Saurabh 10.07.07
    '                Else
    '                    btnStartStopAnalysis.Text = "Start Anal&ysis"
    '                    mstrAspirationMessage = "Click Start button to Start Analysis."
    '                    btnReadData.Enabled = False
    '                    'Saurabh 10.07.07
    '                    If Not IsNothing(gobjMain.mobjfrmMethod) Then
    '                        gobjMain.mobjfrmMethod.btnNewMethod.Enabled = True
    '                        gobjMain.mobjfrmMethod.btnLoadMethod.Enabled = True
    '                    End If
    '                    'Saurabh 10.07.07
    '                End If

    '                'Saurabh Shifted on top of this procedure
    '                'If (mblnIsAnalysisStarted And (Not exitbutton)) Then
    '                '    If (gobjMessageAdapter.ShowMessage(constNewAnalysis) = True) Then
    '                '        'SendMessage(hwnd, WM_COMMAND,IDC_QANEW, 0L)
    '                '        Call NewAnalysis_Clicked(btnNewAnalysis, EventArgs.Empty)
    '                '    End If
    '                'End If
    '                'Saurabh Shifted on top of this procedure

    '                'WP1= wParam;
    '                If (Not AnaOver And (IsNothing(mobjCurrentStandard) And IsNothing(mobjCurrentSample))) Then
    '                    If Not (StdAnalysed) Then
    '                        'CurStd  =Method->QuantData->StdTopData;
    '                        mobjCurrentStandard = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(0)
    '                    End If
    '                    '#If STD_ADDN Then
    '                    If Not (gobjNewMethod.StandardAddition) Then
    '                        'CurSamp =Method->QuantData->SampTopData;
    '                        mobjCurrentSample = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(0)

    '                    End If
    '                    '#End If
    '                End If

    '                Call CheckAnaButtons()

    '                If (mblnIsAnalysisStarted) Then
    '                    If (AnaOver) Then
    '                        If gobjMessageAdapter.ShowMessage(constDataExists) = True Then
    '                            'If (MessageBox.Show(" Data Exists in Memory." & vbCrLf & "Erase them?", "STANDARD/SAMPLE ANALYSIS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
    '                            'SendMessage(hwnd, WM_COMMAND,IDC_QANEW, 0L)
    '                            mblnIsStartRunNumber = False
    '                            'Call GetRunNo(gobjNewMethod)
    '                            Call NewAnalysis_Clicked(btnNewAnalysis, EventArgs.Empty)
    '                        End If
    '                    End If
    '                    Call GetRunNo(gobjNewMethod)
    '                    Call DisplayRunNo()


    '                    'SetWindowText(GetDlgItem(hwnd, IDC_QASTART), "E&nd Ana")
    '                    btnStartStopAnalysis.Text = "E&nd Analysis"

    '                    gobjclsStandardGraph = New clsStandardGraph
    '                    InQAnaRead = False
    '                Else
    '                    btnStartStopAnalysis.Text = "&Start Analysis"

    '                    'btnEditData.Enabled = True

    '                    'If (AnaOver) Then
    '                    Call RawDataSave("rawdata.txt")
    '                    Call SaveRawDataFile()
    '                    Dim A1() As Double = {0, 0, 0, 0, 0, 0}
    '                    'if (toreported or  not (Method->RepReady) )
    '                    If (toreported) Then
    '                        'SaveQuantResults(hwnd, Method, A1, 0)
    '                        gobjNewMethod.DateOfLastUse = Now

    '                        '---added by deepak on 20.07.07 for not dsplaying messages in uv mode
    '                        Call gobjClsAAS203.SaveQuantResults(gobjNewMethod, A1, 0, False)

    '                        'Call gobjClsAAS203.SaveQuantResults(gobjNewMethod, A1, 0)


    '                        'Dim intMethodCounter As Integer
    '                        'For intMethodCounter = 0 To gobjMethodCollection.Count - 1
    '                        '    If gobjMethodCollection.item(intMethodCounter).MethodID = gobjNewMethod.MethodID Then
    '                        '        gobjNewMethod = gobjMethodCollection.item(intMethodCounter).Clone()
    '                        '        Exit For
    '                        '    End If
    '                        'Next

    '                        mblnIsStartRunNumber = True
    '                        toreported = False
    '                    End If
    '                    'End If
    '                    InQAnaRead = False
    '                    Me.Close()
    '                    Me.Dispose()
    '                End If


    '                '#If QDEMO Then
    '                '   If (AnaOver) Then
    '                '       EndFiledataRead()
    '                '   End If
    '                '#End If

    '            Catch ex As Exception
    '                '---------------------------------------------------------
    '                'Error Handling and logging
    '                gobjErrorHandler.ErrorDescription = ex.Message
    '                gobjErrorHandler.ErrorMessage = ex.Message
    '                gobjErrorHandler.WriteErrorLog(ex)
    '                '---------------------------------------------------------
    '            Finally
    '                '---------------------------------------------------------
    '                'Writing Execution log
    '                If CONST_CREATE_EXECUTION_LOG = 1 Then
    '                    gobjErrorHandler.WriteExecutionLog()
    '                End If
    '                '---------------------------------------------------------
    '            End Try
    '        End Sub

    '        Private Sub ReadData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '            'case	IDC_QAREAD:

    '            'if(Method->Mode != MODE_UVABS)
    '            '{
    '            '   t = Ignite_Test();
    '            '	if(!GetHydrideModeStatus() && (t == GREEN || t == RED))
    '            '	    {
    '            '		    MessageBox(hwnd,"Flame is OFF.\nAnalysis not possible.","Aspiration Error",MB_ICONSTOP | MB_OK);
    '            '			break;
    '            '		}
    '            '}
    '            '#If STD_ADDN Then
    '            '	if(Method->QuantData->Param.Std_Addn)
    '            '	{
    '            '	    if(endanalysis)
    '            '		SendMessage(hwnd, WM_COMMAND,IDC_QANEW, 0L);
    '            '	}
    '            '#End If
    '            '	InQAnaRead=TRUE;
    '            '	toreported=TRUE;
    '            '	strcpy(Aspiratemsg,"Reading Wait ... ");
    '            '	Disp_Analysis_Info(hwnd);
    '            '	abs1=Read_Quant_Data(hwnd, &AnaGraph);
    '            '	if (!Method->RepReady )
    '            '	{
    '            '	    SaveQuantResults(hwnd, Method, A1,0);
    '            '	}
    '            '   Else
    '            '	    SaveRawDataFile();

    '            '	if(SampType==STD)
    '            '	{
    '            '	    if(!CheckValidStdAbsEntry(Method->QuantData->StdTopData))
    '            '		{
    '            '		    MessageBox(hwnd,"Abs of the std is less than or equal to the previous std.\nPress 'Rpt Last' button for Aspirating the same std again","Std Aspiration Error",MB_ICONSTOP | MB_OK);
    '            '		}
    '            '	}
    '            '	if(SampType==SAMP)
    '            '	{
    '            '	    if(!CheckValidSampAbsEntry(Method->QuantData->StdTopData,abs1))
    '            '		{
    '            '		    MessageBox(hwnd,"Abs of the sample is more than the maximum standard value.\nCalculated Concentration may not be correct.\nPlease dilute the sample and repeat again.\nPress RptLast button when ready.","Sample Aspiration Error",MB_ICONSTOP | MB_OK);
    '            '		}
    '            '	}
    '            '	SendMessage(hwnd, WM_COMMAND, 900, 0L);//IDC_QANEXT, 0L);
    '            '	break;


    '            '******************************************************************************
    '            '----CODE BY MANEGSH 
    '            '******************************************************************************
    '            Dim intEnumIgiteType As ClsAAS203.enumIgniteType

    '            Try
    '                If mblnAvoidProcessing = True Then
    '                    Exit Sub
    '                End If
    '                mblnAvoidProcessing = True

    '                '*********Saurabh 10.07.07 for change in Integration Time*********
    '                gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.IntegrationTime = gobjNewMethod.AnalysisParameters.IntegrationTime
    '                '*********Saurabh 10.07.07 for change in Integration Time*********

    '                'Added By Pankaj on 11 Jun 07 
    '                If funcMoveSampleEnumerator(mobjSampleEnumerator, intIEnumCollLocationSamp) = True Then
    '                    mobjCurrentSample = CType(mobjSampleEnumerator.Current, Method.clsAnalysisSampleParameters)
    '                End If
    '                If funcMoveEnumerator(mobjStandardEnumerator, intIEnumCollLocationStd) = True Then
    '                    mobjCurrentStandard = CType(mobjStandardEnumerator.Current, Method.clsAnalysisStdParameters)
    '                End If

    '                '-----
    '                gobjMain.mobjController.Cancel()
    '                Call Application.DoEvents()

    '                If Not (gobjNewMethod.OperationMode = EnumOperationMode.MODE_UVABS) Then

    '                    If gstructSettings.AppMode = EnumAppMode.DemoMode Then
    '                        intEnumIgiteType = ClsAAS203.enumIgniteType.Blue
    '                    Else
    '                        intEnumIgiteType = gobjClsAAS203.funcIgnite_Test()
    '                    End If

    '                    gobjfrmStatus.FlameType = intEnumIgiteType

    '                    If (Not HydrideMode And (intEnumIgiteType = ClsAAS203.enumIgniteType.Green Or gobjMain.IgniteType = ClsAAS203.enumIgniteType.Red)) Then
    '                        'gobjMessageAdapter.ShowMessage("Flame is OFF." & vbCrLf & "Analysis not possible.", "Aspiration Error", MessageHandler.clsMessageHandler.enumMessageType.ErrorMessage)
    '                        gobjMessageAdapter.ShowMessage(constFlameOFF)
    '                        mblnAvoidProcessing = False
    '                        Exit Sub
    '                    End If
    '                End If

    '                '#If STD_ADDN Then
    '                If (gobjNewMethod.StandardAddition) Then
    '                    If (EndAnalysis) Then
    '                        'SendMessage(hwnd, WM_COMMAND, IDC_QANEW, 0L)
    '                        Call NewAnalysis_Clicked(btnNewAnalysis, EventArgs.Empty)
    '                    End If
    '                End If
    '                '#End If

    '                InQAnaRead = True
    '                toreported = True

    '                'mstrAspirationMessage = "Reading Wait ... "
    '                Call mobjBgReadData_AspirationMessageChanged("Reading Wait ... ", False)
    '                'Saurabh Delay increased from 100 to 2000
    '                Call gobjCommProtocol.mobjCommdll.subTime_Delay(2000)
    '                'Call gobjCommProtocol.mobjCommdll.subTime_Delay(100)
    '                Call Application.DoEvents()

    '                Call Display_Analysis_Info()
    '                '//----- Added by Sachin Dokhale
    '                'btnReadData.Enabled = False
    '                RemoveHandler btnReadData.Click, AddressOf ReadData_Click

    '                If Not (Afirst) Then
    '                    mEndTime = mobjBgReadData.CEndTime
    '                Else
    '                    'mEndTime = mStartTime

    '                    'CEndTime = (int) ((double) Method->QuantData->Param.Int_Time * (double) CLK_TCK);
    '                    'mEndTime = mStartTime + gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.IntegrationTime
    '                    mEndTime = mStartTime '+ gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.IntegrationTime
    '                End If

    '                ''//----- Added by Sachin Dokhale
    '                ''btnReadData.Enabled = False
    '                'RemoveHandler btnReadData.Click, AddressOf ReadData_Click
    '                '//-----
    '                'mdblAbsorbance = Read_Quant_Data(mdtStartTime, mdtEndTime)
    '                mdblAbsorbance = Read_Quant_Data(mStartTime, mEndTime)



    '                '---Shifted to Completed Event Function of BgThread Client 
    '                'double	A1[6]={0, 0, 0, 0, 0, 0};
    '                'Dim A1() As Double = {0, 0, 0, 0, 0, 0}
    '                'If Not (gobjNewMethod.Status) Then '->RepReady )
    '                '    'SaveQuantResults(gobjNewMethod, A1, 0)
    '                'Else
    '                'SaveRawDataFile()
    '                ''End If

    '                'If (SampType = ClsAAS203.enumSampleType.STANDARD) Then
    '                '    If Not (CheckValidStdAbsEntry(gobjNewMethod.StdParametersCollection)) Then

    '                '        gobjMessageAdapter.ShowMessage("Absorbance of the standard is less than or equal to the previous standard." & vbCrLf & _
    '                '                                       "Press 'Repeat Last' button for aspirating the same standard again.", _
    '                '                                       "Standard Aspiration Error", MessageHandler.clsMessageHandler.enumMessageType.ErrorMessage)
    '                '        'gobjMessageAdapter.ShowMessage(constStandardAbsorbance)
    '                '    End If
    '                'End If

    '                'If (SampType = ClsAAS203.enumSampleType.SAMPLE) Then
    '                '    If Not (CheckValidSampAbsEntry(gobjNewMethod.SampleParametersCollection, mdblAbsorbance)) Then

    '                '        gobjMessageAdapter.ShowMessage("Absorbance of the sample is more than the maximum standard value." & vbCrLf & _
    '                '                                       "Calculated Concentration may not be correct." & vbCrLf & _
    '                '                                       "Please dilute the sample and repeat again." & vbCrLf & _
    '                '                                       "Press RepeatLast button when ready.", "Sample Aspiration Error", _
    '                '                                            MessageHandler.clsMessageHandler.enumMessageType.ErrorMessage)
    '                '        'gobjMessageAdapter.ShowMessage(constSampleAbsorbance)
    '                '    End If

    '                'End If

    '                ''SendMessage(hwnd, WM_COMMAND, 900, 0L) '//IDC_QANEXT, 0L);
    '                'Call NextAnalysis_Clicked(tlbbtnNextAnalysis, EventArgs.Empty)

    '            Catch ex As Exception
    '                '---------------------------------------------------------
    '                'Error Handling and logging
    '                gobjErrorHandler.ErrorDescription = ex.Message
    '                gobjErrorHandler.ErrorMessage = ex.Message
    '                gobjErrorHandler.WriteErrorLog(ex)
    '                '---------------------------------------------------------
    '            Finally
    '                '---------------------------------------------------------
    '                'Writing Execution log
    '                If CONST_CREATE_EXECUTION_LOG = 1 Then
    '                    gobjErrorHandler.WriteExecutionLog()
    '                End If
    '                '---------------------------------------------------------
    '            End Try
    '        End Sub

    '        Private Sub frmAnalysis_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
    '            gobjMain.ShowRunTimeInfo(ConstParentFormLoad)
    '        End Sub

    '        Private Sub btnIgnite_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    '            Try
    '                gobjMain.AutoIgnition()

    '            Catch ex As Exception
    '                '---------------------------------------------------------
    '                'Error Handling and logging
    '                gobjErrorHandler.ErrorDescription = ex.Message
    '                gobjErrorHandler.ErrorMessage = ex.Message
    '                gobjErrorHandler.WriteErrorLog(ex)
    '                '---------------------------------------------------------
    '            Finally
    '                '---------------------------------------------------------
    '                'Writing Execution log
    '                If CONST_CREATE_EXECUTION_LOG = 1 Then
    '                    gobjErrorHandler.WriteExecutionLog()
    '                End If
    '                'objWait.Dispose()
    '                '---------------------------------------------------------
    '            End Try

    '        End Sub

    '        Private Sub btnExtinguish_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    '            Try
    '                gobjMain.Extinguish()

    '            Catch ex As Exception
    '                '---------------------------------------------------------
    '                'Error Handling and logging
    '                gobjErrorHandler.ErrorDescription = ex.Message
    '                gobjErrorHandler.ErrorMessage = ex.Message
    '                gobjErrorHandler.WriteErrorLog(ex)
    '                '---------------------------------------------------------
    '            Finally
    '                '---------------------------------------------------------
    '                'Writing Execution log
    '                If CONST_CREATE_EXECUTION_LOG = 1 Then
    '                    gobjErrorHandler.WriteExecutionLog()
    '                End If
    '                'objWait.Dispose()
    '                '---------------------------------------------------------
    '            End Try

    '        End Sub

    '#End Region

    '#Region " Private Functions "

    '        Private Sub ShowAspirationMessages(ByVal blnIsShow As Boolean)
    '            '=====================================================================
    '            ' Procedure Name        : ShowAspirationMessages
    '            ' Parameters Passed     : Flag to Set or Clear the Message.
    '            ' Returns               : None
    '            ' Purpose               : 
    '            ' Description           : 
    '            ' Assumptions           : 
    '            ' Dependencies          : 
    '            ' Author                : Mangesh Shardul
    '            ' Created               : 17-Jan-2007 03:25 pm
    '            ' Revisions             : 1
    '            '=====================================================================
    '            'void	ShowAspMessage(BOOL	flag)
    '            '{
    '            '   char str[128]="";
    '            '   int t=0;
    '            '   if (flag)
    '            '   {
    '            '       GetDlgItemText(Mhwnd, IDC_TASP, str, 120);
    '            '	    ltrim(trim(str));
    '            '	    t = Ignite_Test();
    '            '	    if( (Method->Mode != MODE_UVABS && !GetHydrideModeStatus()) && (t == GREEN || t == RED) )  // mdf by sss for showing the flame error message
    '            '       {
    '            '		    SetDlgItemText(Mhwnd, IDC_TASP, "  Flame is OFF  ");
    '            '	    }
    '            '   	else
    '            '       {
    '            '   		if (strcmpi(str,Aspiratemsg)!=0)
    '            '		     SetDlgItemText(Mhwnd, IDC_TASP, Aspiratemsg);
    '            '	    }
    '            '   }
    '            '   Else
    '            '       SetDlgItemText(Mhwnd, IDC_TASP, "");
    '            '}

    '            '****************************************************************
    '            '---CODE BY MANGESH
    '            '****************************************************************
    '            Dim intIgniteType As ClsAAS203.enumIgniteType
    '            Dim strAspMessage As String

    '            Try
    '                'Application.DoEvents()
    '                If (blnIsShow) Then
    '                    strAspMessage = Trim(lblAspirationMessage.Text)

    '                    If gstructSettings.AppMode = EnumAppMode.DemoMode Then
    '                        'intIgniteType = ClsAAS203.enumIgniteType.Blue
    '                    Else
    '                        'intIgniteType = gobjClsAAS203.funcIgnite_Test()
    '                    End If

    '                    'If ((gobjNewMethod.OperationMode <> EnumOperationMode.MODE_UVABS And Not gobjInst.Hydride) _
    '                    '    And (intIgniteType = ClsAAS203.enumIgniteType.Green Or intIgniteType = ClsAAS203.enumIgniteType.Red)) Then
    '                    'intIgniteType = gobjMain.IgniteType
    '                    If ((gobjNewMethod.OperationMode <> EnumOperationMode.MODE_UVABS And Not gobjInst.Hydride) _
    '                        And (gobjMain.IgniteType = ClsAAS203.enumIgniteType.Green Or gobjMain.IgniteType = ClsAAS203.enumIgniteType.Red)) Then

    '                        'for showing the flame error message
    '                        lblAspirationMessage.Text = "  Flame is OFF  "
    '                    Else
    '                        If String.Compare(strAspMessage, mstrAspirationMessage) <> 0 Then
    '                            lblAspirationMessage.Text = mstrAspirationMessage
    '                            lblAspirationMessage.Refresh()
    '                        End If
    '                    End If

    '                Else
    '                    lblAspirationMessage.Text = ""
    '                    lblAspirationMessage.Refresh()
    '                End If
    '                'Application.DoEvents()
    '                If btnReadData.Enabled Then
    '                    btnReadData.Focus()
    '                    btnReadData.Refresh()
    '                End If
    '            Catch ex As Exception
    '                '---------------------------------------------------------
    '                'Error Handling and logging
    '                gobjErrorHandler.ErrorDescription = ex.Message
    '                gobjErrorHandler.ErrorMessage = ex.Message
    '                gobjErrorHandler.WriteErrorLog(ex)
    '                '---------------------------------------------------------
    '            Finally
    '                '---------------------------------------------------------
    '                'Writing Execution log
    '                If CONST_CREATE_EXECUTION_LOG = 1 Then
    '                    gobjErrorHandler.WriteExecutionLog()
    '                End If
    '                'Application.DoEvents()     'Commented by Saurabh 20.07.07
    '                '---------------------------------------------------------
    '            End Try
    '        End Sub

    '        'Private Function funcCollapseAllXPPanels() As Boolean
    '        '    '=====================================================================
    '        '    ' Procedure Name        : funcCollapseAllXPPanels
    '        '    ' Parameters Passed     : None
    '        '    ' Returns               : True or False
    '        '    ' Purpose               : To collapse all XP Panels
    '        '    ' Description           : 
    '        '    ' Assumptions           : 
    '        '    ' Dependencies          : 
    '        '    ' Author                : Deepak Bhati
    '        '    ' Created               : 05.10.06
    '        '    ' Revisions             : 
    '        '    '=====================================================================
    '        '    Try
    '        '        If Me.XpPanelStandardGraph.PanelState = UIComponents.XPPanelState.Expanded Then
    '        '            Me.XpPanelStandardGraph.TogglePanelState()
    '        '            Me.XpPanelStandardGraph.Height = 0
    '        '        End If
    '        '        If Me.XpPanelSampleGraph.PanelState = UIComponents.XPPanelState.Expanded Then
    '        '            Me.XpPanelSampleGraph.TogglePanelState()
    '        '            Me.XpPanelSampleGraph.Height = 0
    '        '        End If
    '        '        If Me.XpPanelViewResults.PanelState = UIComponents.XPPanelState.Expanded Then
    '        '            Me.XpPanelViewResults.TogglePanelState()
    '        '            Me.XpPanelViewResults.Height = 0
    '        '        End If
    '        '        If Me.XpPanelReports.PanelState = UIComponents.XPPanelState.Expanded Then
    '        '            Me.XpPanelReports.TogglePanelState()
    '        '            Me.XpPanelReports.Height = 0
    '        '        End If

    '        '        Return True

    '        '    Catch ex As Exception
    '        '        '---------------------------------------------------------
    '        '        'Error Handling and logging
    '        '        gobjErrorHandler.ErrorDescription = ex.Message
    '        '        gobjErrorHandler.ErrorMessage = ex.Message
    '        '        gobjErrorHandler.WriteErrorLog(ex)
    '        '        Return False
    '        '        '---------------------------------------------------------
    '        '    Finally
    '        '        '---------------------------------------------------------
    '        '        'Writing Execution log
    '        '        If CONST_CREATE_EXECUTION_LOG = 1 Then
    '        '            gobjErrorHandler.WriteExecutionLog()
    '        '        End If
    '        '        '---------------------------------------------------------
    '        '    End Try
    '        'End Function

    '        Private Function SetColorPropertiesForXpPanel(ByRef objXpPanelIn As UIComponents.XPPanel, ByVal strCaptionNameIn As String) As Boolean
    '            '=====================================================================
    '            ' Procedure Name        : SetColorPropertiesForXpPanel
    '            ' Parameters Passed     : objXpPanelIn,strCaptionNameIn
    '            ' Returns               : True or False
    '            ' Purpose               : To set color properties to xp panel
    '            ' Description           : 
    '            ' Assumptions           : 
    '            ' Dependencies          : 
    '            ' Author                : Deepak Bhati
    '            ' Created               : 05.10.06
    '            ' Revisions             : 
    '            '=====================================================================
    '            Dim objWait As New CWaitCursor
    '            Try
    '                objXpPanelIn.Caption = strCaptionNameIn

    '                objXpPanelIn.CaptionGradient.Color2 = Color.CornflowerBlue
    '                objXpPanelIn.CaptionGradient.Color1 = Color.FromArgb(205, 225, 250)

    '                objXpPanelIn.PanelGradient.Color1 = Color.White 'Color.FromArgb(205, 225, 250)
    '                objXpPanelIn.PanelGradient.Color2 = Color.Gainsboro 'Color.FromArgb(175, 200, 245)

    '                objXpPanelIn.CaptionUnderline = Color.CornflowerBlue
    '                objXpPanelIn.CurveRadius = 8
    '                objXpPanelIn.Dock = DockStyle.None
    '                objXpPanelIn.GradientOffset = 0.2
    '                objXpPanelIn.HorzAlignment = StringAlignment.Near
    '                objXpPanelIn.Spacing = New Point(5, 0)
    '                objXpPanelIn.TextColors.Color1 = Color.FromArgb(33, 93, 198)
    '                objXpPanelIn.TextColors.Color2 = Color.FromArgb(0, 0, 0, 0)
    '                objXpPanelIn.TextHighlightColors.Color1 = Color.FromArgb(66, 142, 255)
    '                objXpPanelIn.TextHighlightColors.Color2 = Color.FromArgb(0, 0, 0, 0)
    '                objXpPanelIn.VertAlignment = StringAlignment.Center
    '                objXpPanelIn.XPPanelStyle = UIComponents.XPPanelStyle.WindowsXP
    '                objXpPanelIn.OutlineColor = Color.FromArgb(175, 200, 245)
    '                objXpPanelIn.Visible = True
    '                objXpPanelIn.PanelState = UIComponents.XPPanelState.Collapsed
    '                objXpPanelIn.Width = Me.Width
    '                objXpPanelIn.Height = 100
    '                objXpPanelIn.AnimationRate = 1

    '            Catch ex As Exception
    '                '---------------------------------------------------------
    '                'Error Handling and logging
    '                gobjErrorHandler.ErrorDescription = ex.Message
    '                gobjErrorHandler.ErrorMessage = ex.Message
    '                gobjErrorHandler.WriteErrorLog(ex)
    '                '---------------------------------------------------------
    '            Finally
    '                '---------------------------------------------------------
    '                'Writing Execution log
    '                If CONST_CREATE_EXECUTION_LOG = 1 Then
    '                    gobjErrorHandler.WriteExecutionLog()
    '                End If
    '                '---------------------------------------------------------
    '            End Try
    '        End Function

    '        'Private Sub subInitAnalysisGraph()
    '        '    '---To set the X-axis as Time axis and its default Min, Max & Step values.
    '        '    Dim dtXMin, dtXMax As Date

    '        '    Try
    '        '        Call Calculate_Analysis_Graph_Param(AASGraphAnalysis)

    '        '        AASGraphAnalysis.XAxisLabel = "TIME(seconds)"
    '        '        AASGraphAnalysis.XAxisType = AldysGraph.AxisType.Linear
    '        '        AASGraphAnalysis.IsShowGrid = True
    '        '        AASGraphAnalysis.Refresh()
    '        '        Application.DoEvents()

    '        '    Catch ex As Exception
    '        '        '---------------------------------------------------------
    '        '        'Error Handling and logging
    '        '        gobjErrorHandler.ErrorDescription = ex.Message
    '        '        gobjErrorHandler.ErrorMessage = ex.Message
    '        '        gobjErrorHandler.WriteErrorLog(ex)
    '        '        '---------------------------------------------------------
    '        '    Finally
    '        '        '---------------------------------------------------------
    '        '        'Writing Execution log
    '        '        If CONST_CREATE_EXECUTION_LOG = 1 Then
    '        '            gobjErrorHandler.WriteExecutionLog()
    '        '        End If
    '        '        '---------------------------------------------------------
    '        '    End Try
    '        'End Sub

    '        Private Sub InitAnalysis()
    '            'void	InitAnalyse(HWND hwnd,CURVEDATA 	*AnaGraph)
    '            '{
    '            'HWND hwnd1;
    '            ' if (Method->Mode==MODE_UVABS){
    '            '	ShowWindow(GetDlgItem(hwnd,IDC_UVABS), SW_SHOW);
    '            '	ShowWindow(GetDlgItem(hwnd,IDC_GRAPH), SW_HIDE);
    '            '	ShowWindow(GetDlgItem(hwnd,IDC_SCALE), SW_HIDE);
    '            '	ShowWindow(GetDlgItem(hwnd,IDC_PGRAPH), SW_HIDE);
    '            '	ShowWindow(GetDlgItem(hwnd,IDC_HSXMIN), SW_HIDE);
    '            '	ShowWindow(GetDlgItem(hwnd,IDC_HSXMAX), SW_HIDE);
    '            '  }
    '            ' else{
    '            '	ShowWindow(GetDlgItem(hwnd,IDC_UVABS), SW_HIDE);
    '            '	ShowWindow(GetDlgItem(hwnd,IDC_GRAPH), SW_SHOW);
    '            '	ShowWindow(GetDlgItem(hwnd,IDC_SCALE), SW_SHOW);
    '            '	ShowWindow(GetDlgItem(hwnd,IDC_PGRAPH), SW_SHOW);
    '            '	ShowWindow(GetDlgItem(hwnd,IDC_HSXMIN), SW_SHOW);
    '            '	ShowWindow(GetDlgItem(hwnd,IDC_HSXMAX), SW_SHOW);

    '            '	hwnd1=GetDlgItem(hwnd,IDC_GRAPH);
    '            '	if (hwnd1){
    '            '	 EnableWindow(hwnd1,TRUE);
    '            '	 GetWindowRect(hwnd1, &(AnaGraph->RC));
    '            '	 ShowWindow(hwnd1,SW_HIDE);
    '            '	 AnaGraph->RC.top -= 35; 	AnaGraph->RC.right-=30;
    '            '	 AnaGraph->RC.bottom-=40;
    '            '	}
    '            '            Else
    '            '	 SetRectEmpty(&AnaGraph->RC);
    '            '  if (Method->Mode==MODE_EMISSION){
    '            '		AnaGraph->Ymin=-1.0; AnaGraph->Ymax=100.0;
    '            '	 }
    '            '  else{
    '            '	AnaGraph->Ymin=-0.1; AnaGraph->Ymax=1.0;
    '            '	}
    '            '  AnaGraph->Xmin=0; AnaGraph->Xmax=10*10.0;
    '            '  Calculate_Analysis_Graph_Param(AnaGraph);
    '            ' }
    '            '}
    '            Try
    '                'Select Case gobjNewMethod.OperationMode
    '                '    Case EnumOperationMode.MODE_UVABS
    '                '        '---Do not show graph
    '                '        lblUVAbsorbance.Visible = True
    '                '        lblUVAbsorbance.Size = New Size(370, 87)
    '                '        lblUVAbsorbance.Location = New Point(136, 73)
    '                '        lblUVWavelength.Visible = True
    '                '        lblUVWavelength.Size = New Size(370, 87)
    '                '        lblUVWavelength.Location = New Point(136, 188)
    '                '        AASGraphAnalysis.Visible = False
    '                '        Call Application.DoEvents()

    '                '    Case Else
    '                '        AASGraphAnalysis.Visible = True
    '                '        lblUVAbsorbance.Visible = False
    '                '        lblUVWavelength.Visible = False
    '                '        Call Application.DoEvents()

    '                '        If (gobjNewMethod.OperationMode = EnumOperationMode.MODE_EMMISSION) Then
    '                '            AASGraphAnalysis.YAxisMin = 0.0
    '                '            AASGraphAnalysis.YAxisMax = 100.0
    '                '            AASGraphAnalysis.YAxisStep = 20.0
    '                '            AASGraphAnalysis.YAxisMinorStep = 5.0

    '                '            AASGraphAnalysis.YAxisLabel = "EMISSION"
    '                '            'Changed by Saurabh "Energy" to "Emission"
    '                '            lblAbsorbanceMain.Text = "Emission : "
    '                '            lblAverageAbsorbanceMain.Text = "Average Emission : "
    '                '        Else
    '                '            '---changed by deepak on 29.04.07
    '                '            AASGraphAnalysis.YAxisMin = -0.2
    '                '            AASGraphAnalysis.YAxisMax = 0.8
    '                '            'AASGraphAnalysis.YAxisStep = 0.1
    '                '            'AASGraphAnalysis.YAxisMinorStep = 0.05
    '                '            AASGraphAnalysis.YAxisStep = 0.2
    '                '            AASGraphAnalysis.YAxisMinorStep = 0.1

    '                '            AASGraphAnalysis.YAxisLabel = "ABSORBANCE"
    '                '        End If
    '                '        Call subInitAnalysisGraph()
    '                'End Select

    '                ''---Set Method Title
    '                'txtMethod.Text = gobjNewMethod.MethodName

    '                btnReadData.Enabled = False

    '            Catch ex As Exception
    '                '---------------------------------------------------------
    '                'Error Handling and logging
    '                gobjErrorHandler.ErrorDescription = ex.Message
    '                gobjErrorHandler.ErrorMessage = ex.Message
    '                gobjErrorHandler.WriteErrorLog(ex)
    '                '---------------------------------------------------------
    '            Finally
    '                '---------------------------------------------------------
    '                'Writing Execution log
    '                If CONST_CREATE_EXECUTION_LOG = 1 Then
    '                    gobjErrorHandler.WriteExecutionLog()
    '                End If
    '                '---------------------------------------------------------
    '            End Try
    '        End Sub

    '        Private Sub Test(ByRef dblX As Double, ByRef dblY As Double)
    '            If (dblX < 40) Then
    '                dblX = dblX + 5
    '                dblY = 0.05 * dblX * dblX
    '            ElseIf (dblX < 50) Then
    '                dblX = dblX + 5
    '                dblY = Math.Sqrt((dblY * dblY) - 1)
    '            Else
    '                dblX = dblX + 5
    '                dblY = dblY - 0.05 * dblY
    '            End If
    '        End Sub

    '        'Private Sub Test_Time(ByRef dtXTime As Date, ByRef dblY As Double)
    '        '    If (dtXTime < AldysGraph.XDate.XLDateToDateTime(AASGraphAnalysis.XAxisMax)) Then
    '        '        dtXTime = dtXTime.AddMinutes(1.0)
    '        '        Dim objRnd As New Random
    '        '        dblY = objRnd.NextDouble() * 100
    '        '    End If
    '        'End Sub

    '        Private Sub ResetAnaMode(ByVal intLampNumber As Integer)
    '            '------------------------------------------------------------------------
    '            'void ResetAnaMode(int lampno )
    '            '{
    '            'INST_PAR	*Inst=NULL;
    '            'Inst =  GetInstData();
    '            'switch(Method->Mode){
    '            '	case MODE_AA:Inst->Lamp_par.lamp[lampno].mode=AA;break;
    '            '	case MODE_AABGC:Inst->Lamp_par.lamp[lampno].mode=AABGC;break;
    '            '	case MODE_EMISSION:Inst->Lamp_par.lamp[lampno].mode=EMISSION;break;
    '            '	case MODE_UVABS:Inst->Lamp_par.lamp[lampno].mode=MABS;break;
    '            '	case MODE_SPECT:if(GetInstrument() == AA202)
    '            '							Inst->Lamp_par.lamp[lampno].mode=AABGCSR;
    '            '	break;
    '            '}
    '            '}
    '            '------------------------------------------------------------------------

    '            'INST_PAR	*Inst=NULL;
    '            'Inst = GetInstData()

    '            'gobjInst = Nothing
    '            'Call funcInitInstrumentSettings()

    '            '---Get Lamp Index from Lamp Number
    '            Try
    '                intLampNumber -= 1

    '                Select Case gobjNewMethod.OperationMode
    '                    Case EnumOperationMode.MODE_AA
    '                        gobjInst.Lamp.LampParametersCollection(intLampNumber).Mode = EnumOperationMode.MODE_AA

    '                    Case EnumOperationMode.MODE_AABGC
    '                        gobjInst.Lamp.LampParametersCollection(intLampNumber).Mode = EnumOperationMode.MODE_AABGC

    '                    Case EnumOperationMode.MODE_EMMISSION
    '                        gobjInst.Lamp.LampParametersCollection(intLampNumber).Mode = EnumOperationMode.MODE_EMMISSION

    '                    Case EnumOperationMode.MODE_UVABS
    '                        gobjInst.Lamp.LampParametersCollection(intLampNumber).Mode = EnumOperationMode.MODE_UVABS

    '                    Case EnumOperationMode.MODE_SPECT
    '                        gobjInst.Lamp.LampParametersCollection(intLampNumber).Mode = EnumOperationMode.MODE_SPECT

    '                End Select

    '            Catch ex As Exception
    '                '---------------------------------------------------------
    '                'Error Handling and logging
    '                gobjErrorHandler.ErrorDescription = ex.Message
    '                gobjErrorHandler.ErrorMessage = ex.Message
    '                gobjErrorHandler.WriteErrorLog(ex)
    '                '---------------------------------------------------------
    '            Finally
    '                '---------------------------------------------------------
    '                'Writing Execution log
    '                If CONST_CREATE_EXECUTION_LOG = 1 Then
    '                    gobjErrorHandler.WriteExecutionLog()
    '                End If
    '                '---------------------------------------------------------
    '            End Try
    '        End Sub

    '        Private Sub Display_Analysis_Info()
    '            '=====================================================================
    '            ' Procedure Name        : Display_Analysis_Info
    '            ' Parameters Passed     : None
    '            ' Returns               : None
    '            ' Purpose               : To display analysis information. 
    '            '                           
    '            ' Description           : 
    '            ' Assumptions           : 
    '            ' Dependencies          : 
    '            ' Author                : Mangesh Shardul
    '            ' Created               : 15-Dec-2006
    '            ' Revisions             : 1
    '            '=====================================================================

    '            '****************************************************************************************
    '            'AAS 16-Bit Software Code
    '            '****************************************************************************************
    '            'void	Disp_Analysis_Info(HWND hwnd)
    '            '{
    '            'char		str[60]="";
    '            'int		i;

    '            ' for(i=IDC_QSAMPID;i<=IDC_QCONC; i++)
    '            '	SetDlgItemText(hwnd,i, "");
    '            ' if (SampType==BLANK){
    '            '	SetDlgItemText(hwnd,IDC_QSAMPID, "BLANK");
    '            '	SetDlgItemText(hwnd,IDC_QRPTNO, "1");
    '            '	SetDlgItemText(hwnd,IDC_QCORABS, "");
    '            '	SetDlgItemText(hwnd,IDC_QCONC, "");
    '            '  }
    '            ' else if (SampType==STD){
    '            '	if (mobjCurrentStandard!=NULL){
    '            '	  sprintf(str, "%s",mobjCurrentStandard->Data.Std_Name);
    '            '	  SetDlgItemText(hwnd,IDC_QSAMPID, str);
    '            '	  sprintf(str, "%d",CurRepeat);
    '            '	  SetDlgItemText(hwnd,IDC_QRPTNO, str);
    '            '	  StoreResultAccurate(mobjCurrentStandard->Data.Conc, str,
    '            '			  Method->QuantData->Param.No_Decimals);
    '            '	  SetDlgItemText(hwnd,IDC_QCONC, str);
    '            '	 }
    '            '	}
    '            '  else if (SampType==SAMP){
    '            '	 if (mobjCurrentSample!=NULL){
    '            '	  sprintf(str, "%s",mobjCurrentSample->Data.Samp_Name);
    '            '	  SetDlgItemText(hwnd,IDC_QSAMPID, str);
    '            '	  sprintf(str, "%d",CurRepeat);
    '            '	  SetDlgItemText(hwnd,IDC_QRPTNO, str);
    '            '	  SetDlgItemText(hwnd,IDC_QCONC, "Unknown");
    '            '	 }
    '            '	}
    '            '}
    '            '****************************************************************************************
    '            Try
    '                'lblSampleID.Text = ""
    '                'lblRepeatNo.Text = ""
    '                'lblCorrectedAbsorbance.Text = ""
    '                'lblConcentration.Text = ""

    '                Select Case SampleType
    '                    Case ClsAAS203.enumSampleType.BLANK
    '                        'lblSampleID.Text = "BLANK"
    '                        'lblRepeatNo.Text = "1"
    '                        'lblCorrectedAbsorbance.Text = ""
    '                        'lblConcentration.Text = ""

    '                    Case ClsAAS203.enumSampleType.STANDARD
    '                        If Not IsNothing(mobjCurrentStandard) Then
    '                            'lblSampleID.Text = mobjCurrentStandard.StdName
    '                            'lblRepeatNo.Text = CurRepeat

    '                            ''---Store Result Accurate upto AnalysisParameters.NumOfDecimalPlaces
    '                            'lblConcentration.Text = FormatNumber(mobjCurrentStandard.Concentration, gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfDecimalPlaces)
    '                        End If

    '                    Case ClsAAS203.enumSampleType.SAMPLE
    '                        If Not IsNothing(mobjCurrentSample) Then
    '                            'lblSampleID.Text = mobjCurrentSample.SampleName
    '                            'lblRepeatNo.Text = CurRepeat
    '                            'lblConcentration.Text = "Unknown"
    '                        End If
    '                End Select

    '            Catch ex As Exception
    '                '---------------------------------------------------------
    '                'Error Handling and logging
    '                gobjErrorHandler.ErrorDescription = ex.Message
    '                gobjErrorHandler.ErrorMessage = ex.Message
    '                gobjErrorHandler.WriteErrorLog(ex)
    '                '---------------------------------------------------------
    '            Finally
    '                '---------------------------------------------------------
    '                'Writing Execution log
    '                If CONST_CREATE_EXECUTION_LOG = 1 Then
    '                    gobjErrorHandler.WriteExecutionLog()
    '                End If
    '                '---------------------------------------------------------
    '            End Try
    '        End Sub

    '        Private Sub DisplayRunNo()
    '            'void	DisplayRunNo(HWND hwnd)
    '            '{
    '            'char 	str[80]="";
    '            '  if (!Method->QuantData)
    '            '	 return;
    '            ' if (Method->QuantData->Fname>0){
    '            '	sprintf(str,"%08.0f",Method->QuantData->Fname);
    '            '	SetWindowText(GetDlgItem(hwnd,IDC_TRUN), str);
    '            '  }
    '            '}

    '            Dim strRunNumber As String = ""

    '            Try
    '                If Not IsNothing(gobjNewMethod.QuantitativeDataCollection) Then
    '                    If (CInt(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).RunNumber) > 0) Then
    '                        strRunNumber = Format(CInt(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).RunNumber), "00000000")
    '                        'lblRunNumber.Text = strRunNumber
    '                    End If
    '                End If

    '            Catch ex As Exception
    '                '---------------------------------------------------------
    '                'Error Handling and logging
    '                gobjErrorHandler.ErrorDescription = ex.Message
    '                gobjErrorHandler.ErrorMessage = ex.Message
    '                gobjErrorHandler.WriteErrorLog(ex)
    '                '---------------------------------------------------------
    '            Finally
    '                '---------------------------------------------------------
    '                'Writing Execution log
    '                If CONST_CREATE_EXECUTION_LOG = 1 Then
    '                    gobjErrorHandler.WriteExecutionLog()
    '                End If
    '                '---------------------------------------------------------
    '            End Try
    '        End Sub

    '        Private Sub Clear_All_Abs_Std(ByRef StdTop As Method.clsAnalysisStdParametersCollection)
    '            '-------------------------
    '            'void	  S4FUNC	Clear_All_Abs_Std(STDDATA *StdTop)
    '            '{
    '            'STDDATA   *tempk=NULL;
    '            'ABSREPEATDATA	*rpt=NULL;

    '            ' tempk =StdTop;
    '            ' while(tempk!=NULL){
    '            '	 tempk->Data.Abs=(double) -1.0;
    '            '	 tempk=tempk->next;
    '            '  }
    '            '//---------clr repeat    add by sss on dt 21/12/1999
    '            'tempk =StdTop;
    '            'while(tempk){
    '            '	if(tempk->Data.AbsRepeat){
    '            '		rpt = tempk->Data.AbsRepeat->RptDataTop;
    '            '		DeleteAllAbsRepeatNodes(&rpt);
    '            '		free(tempk->Data.AbsRepeat);
    '            '		tempk->Data.AbsRepeat = NULL;
    '            '	}
    '            '	tempk =  tempk->next;
    '            '};
    '            '//------------------

    '            Dim rpt As Method.clsAbsRepeat

    '            'While (tempk! = NULL){
    '            '	 tempk->Data.Abs= -1.0
    '            '	 tempk=tempk->next
    '            '}
    '            'tempk =StdTop;
    '            'while(tempk){
    '            '	if(tempk->Data.AbsRepeat){
    '            '		rpt = tempk->Data.AbsRepeat->RptDataTop;
    '            '		DeleteAllAbsRepeatNodes(&rpt);
    '            '		free(tempk->Data.AbsRepeat);
    '            '		tempk->Data.AbsRepeat = NULL;
    '            '	}
    '            '	tempk =  tempk->next;
    '            '};

    '            'Dim objIterator As IEnumerator
    '            Dim intCounter As Integer

    '            Try
    '                'objIterator = StdTop.GetEnumerator()
    '                'objIterator.Reset()
    '                'While (objIterator.MoveNext)
    '                '    CType(objIterator.Current, Method.clsAnalysisStdParameters).Abs = -1.0
    '                '    'CType(objIterator.Current, Method.clsAnalysisStdParameters).AbsRepeat.AbsRepeatData.Clear()
    '                'End While

    '                For intCounter = 0 To StdTop.Count - 1
    '                    StdTop.item(intCounter).Abs = -1.0
    '                    StdTop.item(intCounter).AbsRepeat.AbsRepeatData.Clear()
    '                Next intCounter

    '            Catch ex As Exception
    '                '---------------------------------------------------------
    '                'Error Handling and logging
    '                gobjErrorHandler.ErrorDescription = ex.Message
    '                gobjErrorHandler.ErrorMessage = ex.Message
    '                gobjErrorHandler.WriteErrorLog(ex)
    '                '---------------------------------------------------------
    '            Finally
    '                '---------------------------------------------------------
    '                'Writing Execution log
    '                If CONST_CREATE_EXECUTION_LOG = 1 Then
    '                    gobjErrorHandler.WriteExecutionLog()
    '                End If
    '                '---------------------------------------------------------
    '            End Try
    '        End Sub

    '        Private Sub Clear_All_Abs_Conc_Samp(ByRef SampTop As Method.clsAnalysisSampleParametersCollection)
    '            '//-------------------
    '            'void     S4FUNC	Clear_All_Abs_Conc_Samp(SAMPDATA *SampTop)
    '            '{
    '            'SAMPDATA *tempk=NULL;
    '            'ABSREPEATDATA	*rpt=NULL;
    '            ' tempk =SampTop;
    '            ' while(tempk!=NULL){
    '            '	 tempk->Data.Abs=(double) -1.0;
    '            '	 tempk->Data.Conc=(double) 0.0;
    '            '	 tempk=tempk->next;
    '            '  }

    '            'tempk =SampTop;
    '            'while(tempk){
    '            '	if (tempk->Data.AbsRepeat){
    '            '		rpt = tempk->Data.AbsRepeat->RptDataTop;
    '            '		DeleteAllAbsRepeatNodes(&rpt);
    '            '		free(tempk->Data.AbsRepeat);
    '            '		tempk->Data.AbsRepeat = NULL;
    '            '	}
    '            '	tempk =  tempk->next;
    '            '};
    '            '//------------

    '            'Dim objIterator As IEnumerator
    '            Dim intCounter As Integer

    '            Try
    '                ''objIterator = SampTop.GetEnumerator()
    '                ''objIterator.Reset()
    '                ''While (objIterator.MoveNext)
    '                ''    CType(objIterator.Current, Method.clsAnalysisSampleParameters).Abs = -1.0
    '                ''    CType(objIterator.Current, Method.clsAnalysisSampleParameters).AbsRepeat.AbsRepeatData.Clear()
    '                ''End While

    '                For intCounter = 0 To SampTop.Count - 1
    '                    SampTop.item(intCounter).Abs = -1.0
    '                    SampTop.item(intCounter).AbsRepeat.AbsRepeatData.Clear()
    '                Next intCounter

    '            Catch ex As Exception
    '                '---------------------------------------------------------
    '                'Error Handling and logging
    '                gobjErrorHandler.ErrorDescription = ex.Message
    '                gobjErrorHandler.ErrorMessage = ex.Message
    '                gobjErrorHandler.WriteErrorLog(ex)
    '                '---------------------------------------------------------
    '            Finally
    '                '---------------------------------------------------------
    '                'Writing Execution log
    '                If CONST_CREATE_EXECUTION_LOG = 1 Then
    '                    gobjErrorHandler.WriteExecutionLog()
    '                End If
    '                '---------------------------------------------------------
    '            End Try
    '        End Sub

    '        Private Sub CheckValidStdAbs()
    '            '//----------------------
    '            'void		S4FUNC	CheckValidStdAbs()
    '            '{
    '            'STDDATA   *tempk=NULL;
    '            ' if (!Method->QuantData)
    '            '	return;
    '            ' tempk =Method->QuantData->StdTopData;
    '            ' while(tempk!=NULL){
    '            '	tempk->Data.Used=FALSE;
    '            '	if (tempk->Data.Abs>0.0) ////-1.0)
    '            '	  tempk->Data.Used=TRUE;
    '            '	 tempk=tempk->next;
    '            '  }
    '            '}
    '            '//-------------
    '            Dim intCount As Integer

    '            Try
    '                If Not IsNothing(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection) Then
    '                    For intCount = 0 To gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.Count - 1
    '                        gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount).Used = False
    '                        If gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount).Abs > 0.0 Then
    '                            gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(intCount).Used = True
    '                        End If
    '                    Next
    '                End If

    '                'If Not IsNothing(objCurStandard) Then
    '                '    objCurStandard.Used = False
    '                '    If objCurStandard.Abs > 0.0 Then
    '                '        objCurStandard.Used = True
    '                '    End If
    '                'End If

    '            Catch ex As Exception
    '                '---------------------------------------------------------
    '                'Error Handling and logging
    '                gobjErrorHandler.ErrorDescription = ex.Message
    '                gobjErrorHandler.ErrorMessage = ex.Message
    '                gobjErrorHandler.WriteErrorLog(ex)
    '                '---------------------------------------------------------
    '            Finally
    '                '---------------------------------------------------------
    '                'Writing Execution log
    '                If CONST_CREATE_EXECUTION_LOG = 1 Then
    '                    gobjErrorHandler.WriteExecutionLog()
    '                End If
    '                '---------------------------------------------------------
    '            End Try
    '        End Sub

    '        Private Function GetRunNo(ByVal objMethod As Method.clsMethod) As Double
    '            '//-------------------
    '            'double		S4FUNC	GetRunNo(METHOD *temp)
    '            '{
    '            'DATA4  	*aaresultdata=NULL;
    '            'INDEX4  	*aaresultidx=NULL;
    '            'double	fname=-1.0;
    '            'If (!temp) Then
    '            '   return fname;
    '            'If (!temp->QuantData)
    '            '   return fname;

    '            'If (!QDIopen("AARESULT",&aaresultdata, &aaresultidx))
    '            '{
    '            '   d4close_all(cb);
    '            '   return  FALSE;
    '            '}
    '            'If (d4reccount(aaresultdata) > 0) Then
    '            '   fname = Obtain_Next_Key(aaresultdata,"FNAME", FALSE);
    '            'Else
    '            '   fname=(double) 1.0;

    '            'temp->QuantData->Fname =fname;
    '            'd4close_all(cb);
    '            'return fname;
    '            '}
    '            '//---------------------------
    '            'DATA4  	*aaresultdata=NULL;
    '            'INDEX4  	*aaresultidx=NULL;

    '            Dim dblNewRunNumber As Double = -1.0

    '            Try
    '                If IsNothing(objMethod) Then
    '                    Return dblNewRunNumber
    '                End If

    '                If IsNothing(objMethod.QuantitativeDataCollection) Then
    '                    Return dblNewRunNumber
    '                End If

    '                ''If Not (QDIopen("AARESULT", aaresultdata, aaresultidx)) Then
    '                ''    d4close_all(cb)
    '                ''    Return -1.0
    '                ''End If
    '                ''If (d4reccount(aaresultdata) > 0) Then
    '                ''    fname = Obtain_Next_Key(aaresultdata, "FNAME", False)
    '                ''Else
    '                ''    fname = 1.0
    '                ''End If
    '                'd4close_all(cb)
    '                '//----- Added by Sachin Dokhale on 25.05.07
    '                'dblNewRunNumber = gobjNewMethod.QuantitativeDataCollection.Count
    '                'gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).RunNumber = Format(dblNewRunNumber, "00000000")
    '                Dim intMethodCount As Integer
    '                Dim lngRunCount As Long
    '                Dim lngTotalRunNumber As Long = 0

    '                If Not gobjMethodCollection Is Nothing Then
    '                    If gobjMethodCollection.Count > 0 Then
    '                        For intMethodCount = 0 To gobjMethodCollection.Count - 1
    '                            If Not gobjMethodCollection(intMethodCount).QuantitativeDataCollection Is Nothing Then
    '                                If gobjMethodCollection(intMethodCount).QuantitativeDataCollection.Count > 0 Then
    '                                    For lngRunCount = 0 To gobjMethodCollection(intMethodCount).QuantitativeDataCollection.Count - 1
    '                                        If CLng(gobjMethodCollection(intMethodCount).QuantitativeDataCollection(lngRunCount).RunNumber) > lngTotalRunNumber Then
    '                                            lngTotalRunNumber = CLng(gobjMethodCollection(intMethodCount).QuantitativeDataCollection(lngRunCount).RunNumber)
    '                                        End If
    '                                    Next
    '                                    'intTotalRunNumber = gobjMethodCollection(intMethodCount).QuantitativeDataCollection.Count
    '                                End If
    '                            End If
    '                        Next
    '                    End If
    '                End If
    '                ''''
    '                lngTotalRunNumber += 1
    '                dblNewRunNumber = Format(lngTotalRunNumber, "00000000")
    '                gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).RunNumber = Format(lngTotalRunNumber, "00000000")
    '                mlngSelectedRunNumber = lngTotalRunNumber
    '                Return dblNewRunNumber

    '            Catch ex As Exception
    '                '---------------------------------------------------------
    '                'Error Handling and logging
    '                gobjErrorHandler.ErrorDescription = ex.Message
    '                gobjErrorHandler.ErrorMessage = ex.Message
    '                gobjErrorHandler.WriteErrorLog(ex)
    '                '---------------------------------------------------------
    '            Finally
    '                '---------------------------------------------------------
    '                'Writing Execution log
    '                If CONST_CREATE_EXECUTION_LOG = 1 Then
    '                    gobjErrorHandler.WriteExecutionLog()
    '                End If
    '                '---------------------------------------------------------
    '            End Try
    '        End Function

    '        Private Sub Aspirate()
    '            '=====================================================================
    '            ' Procedure Name        : Aspirate
    '            ' Parameters Passed     : None
    '            ' Returns               : None
    '            ' Purpose               : 
    '            ' Description           : 
    '            ' Assumptions           : 
    '            ' Dependencies          : 
    '            ' Author                : Mangesh Shardul
    '            ' Created               : 17-Jan-2007 03:25 pm
    '            ' Revisions             : 1
    '            '=====================================================================
    '            'void   Aspirate(HWND hwnd)        
    '            '{
    '            'char	*aspMsg=NULL;
    '            'char	strAspMsg1[]= "Aspirate";
    '            'char	strAspMsg2[]="Insert Cuvete";
    '            'char	str[180]="";

    '            'if ( Method->Mode==MODE_UVABS)
    '            '	aspMsg =strAspMsg2;
    '            'Else
    '            '   aspMsg =strAspMsg1;

    '            'if (SampType==BLANK)
    '            '{
    '            '	if(Autosampler && Started )
    '            '	{
    '            '       If (!PositionAutosampler(hwnd, Str)) Then
    '            '		Gerror_message_system("Autosampler connection Lost");
    '            '	}
    '            '	else 
    '            '		sprintf(str, "%s Blank and Click &READ or press <SPACEBAR>", aspMsg);
    '            '}        
    '            'else
    '            '{
    '            '	if (SampType==STD)
    '            '	{
    '            '       If (mobjCurrentStandard! = NULL) Then
    '            '		{        
    '            '			if ( Method->QuantData->Param.ConcRepeat>1)
    '            '			{
    '            '				if(Autosampler && Started)
    '            '				{
    '            '					sprintf(str,"%s %s (Rpt #%d)from Position %d ",aspMsg,mobjCurrentStandard->Data.Std_Name, CurRepeat,mobjCurrentStandard->Data.PosNo);
    '            '					strcpy(Aspiratemsg, str);
    '            '					SetAutoSampler(hwnd,mobjCurrentStandard->Data.PosNo,TRUE);
    '            '				}
    '            '               Else
    '            '				    sprintf(str, " %s %s (Rpt #%d) and Click &READ or press <SPACEBAR>", aspMsg,mobjCurrentStandard->Data.Std_Name, CurRepeat); 
    '            '			}
    '            '			else
    '            '			{
    '            '				if(Autosampler && Started)
    '            '				{
    '            '					sprintf(str,"%s %s from Position %d ",aspMsg,mobjCurrentStandard->Data.Std_Name,mobjCurrentStandard->Data.PosNo);
    '            '					strcpy(Aspiratemsg, str);
    '            '					SetAutoSampler(hwnd,mobjCurrentStandard->Data.PosNo,TRUE);
    '            '				}
    '            '               Else
    '            '				    sprintf(str, " %s %s  and Click &READ or press <SPACEBAR>", aspMsg, mobjCurrentStandard->Data.Std_Name ); 
    '            '			}
    '            '		}
    '            '	}
    '            '	else
    '            '	{
    '            '       If (mobjCurrentSample! = NULL) Then
    '            '		{
    '            '			if ( Method->QuantData->Param.Repeat>1 )
    '            '			{
    '            '				if(Autosampler && Started)
    '            '				{
    '            '					sprintf(str,"%s %s (Repeat #%d) from Position %d ",aspMsg,mobjCurrentSample->Data.Samp_Name, CurRepeat,mobjCurrentSample->Data.SampPosNo);
    '            '					strcpy(Aspiratemsg, str);
    '            '					SetAutoSampler(hwnd,mobjCurrentSample->Data.SampPosNo,TRUE);
    '            '				}
    '            '               Else
    '            '					sprintf(str, " %s %s (Repeat #%d) and Click &READ or press <SPACEBAR> ", aspMsg, mobjCurrentSample->Data.Samp_Name, CurRepeat); 
    '            '			}
    '            '			else
    '            '			{
    '            '				if(Autosampler && Started)
    '            '				{
    '            '					sprintf(str, " %s %s from Position %d", aspMsg,mobjCurrentSample->Data.Samp_Name,mobjCurrentSample->Data.SampPosNo);
    '            '					strcpy(Aspiratemsg, str);
    '            '					SetAutoSampler(hwnd,mobjCurrentSample->Data.SampPosNo,TRUE);
    '            '				}
    '            '               Else
    '            '				    sprintf(str, " %s %s and Click &READ or press <SPACE BAR>", aspMsg, mobjCurrentSample->Data.Samp_Name);
    '            '			}
    '            '		}
    '            '	}
    '            '}

    '            'If (!Autosampler) Then
    '            '   strcpy(Aspiratemsg, str);
    '            'Else
    '            '{
    '            '   If (Started) Then
    '            '	    strcpy(Aspiratemsg, str);
    '            '}

    '            'if(Autosampler && Started)
    '            '	SendMessage(hwnd, WM_COMMAND, IDC_QAREAD, 0L);
    '            '}


    '            '*******************************************************************************
    '            '---CODE BY MANGESH 
    '            '*******************************************************************************
    '            Dim aspMsg As String

    '            Try
    '                If (gobjNewMethod.OperationMode = EnumOperationMode.MODE_UVABS) Then
    '                    aspMsg = "Insert Cuvete "
    '                Else
    '                    aspMsg = "Aspirate "
    '                End If

    '                If (SampleType = ClsAAS203.enumSampleType.BLANK) Then
    '                    If (mblnIsAutosampler And mblnIsAnalysisStarted) Then
    '                        If Not (PositionAutosampler()) Then
    '                            'gobjMessageAdapter.ShowMessage("Autosampler connection Lost", "Autosampler", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage)
    '                            gobjMessageAdapter.ShowMessage(constAutoSamplerConnLost)
    '                        End If
    '                    Else
    '                        mstrAspirationMessage = aspMsg & "Blank and Click READ DATA or press <SPACEBAR>"
    '                        '---Saurabh---20.06.07
    '                        If btnReadData.Enabled = True Then
    '                            btnReadData.Focus()
    '                            btnReadData.Refresh()
    '                        End If
    '                        '---Saurabh
    '                    End If
    '                Else
    '                    If (SampleType = ClsAAS203.enumSampleType.STANDARD) Then
    '                        If Not IsNothing(mobjCurrentStandard) Then
    '                            If (gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfStdRepeats) > 1 Then '( Method->QuantData->Param.ConcRepeat>1)
    '                                If (mblnIsAutosampler And mblnIsAnalysisStarted) Then
    '                                    mstrAspirationMessage = aspMsg & mobjCurrentStandard.StdName & " (Repeat #" & CurRepeat & ") from Position " & mobjCurrentStandard.PositionNumber
    '                                    SetAutoSampler(mobjCurrentStandard.PositionNumber, True)
    '                                Else
    '                                    mstrAspirationMessage = aspMsg & mobjCurrentStandard.StdName & "(Repeat #" & CurRepeat & ") and Click READ DATA or press <SPACEBAR>"
    '                                End If
    '                            Else
    '                                If (mblnIsAutosampler And mblnIsAnalysisStarted) Then
    '                                    mstrAspirationMessage = aspMsg & mobjCurrentStandard.StdName & " from Position " & mobjCurrentStandard.PositionNumber
    '                                    SetAutoSampler(mobjCurrentStandard.PositionNumber, True)
    '                                Else
    '                                    mstrAspirationMessage = aspMsg & mobjCurrentStandard.StdName & " and Click READ DATA or press <SPACEBAR>"
    '                                End If
    '                            End If
    '                        End If
    '                    Else
    '                        If Not IsNothing(mobjCurrentSample) Then
    '                            If (gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfSampleRepeats > 1) Then
    '                                If (mblnIsAutosampler And mblnIsAnalysisStarted) Then
    '                                    mstrAspirationMessage = aspMsg & mobjCurrentSample.SampleName & " (Repeat #" & CurRepeat & ") from Position " & mobjCurrentSample.SampPosNumber
    '                                    SetAutoSampler(mobjCurrentSample.SampPosNumber, True)
    '                                Else
    '                                    mstrAspirationMessage = aspMsg & mobjCurrentSample.SampleName & " (Repeat #" & CurRepeat & ") and Click READ DATA or press <SPACEBAR> "
    '                                End If
    '                            Else
    '                                If (mblnIsAutosampler And mblnIsAnalysisStarted) Then
    '                                    mstrAspirationMessage = aspMsg & mobjCurrentSample.SampleName & " from Position " & mobjCurrentSample.SampPosNumber
    '                                    SetAutoSampler(mobjCurrentSample.SampPosNumber, True)
    '                                Else
    '                                    mstrAspirationMessage = aspMsg & mobjCurrentSample.SampleName & " and Click READ DATA or press <SPACE BAR>"
    '                                End If
    '                            End If
    '                        End If
    '                    End If
    '                End If

    '                If btnReadData.Enabled Then
    '                    btnReadData.Focus()
    '                    btnReadData.Refresh()
    '                End If

    '                If (mblnIsAutosampler And mblnIsAnalysisStarted) Then
    '                    'SendMessage(hwnd, WM_COMMAND, IDC_QAREAD, 0L)
    '                    Call ReadData_Click(btnReadData, EventArgs.Empty)
    '                End If

    '            Catch ex As Exception
    '                '---------------------------------------------------------
    '                'Error Handling and logging
    '                gobjErrorHandler.ErrorDescription = ex.Message
    '                gobjErrorHandler.ErrorMessage = ex.Message
    '                gobjErrorHandler.WriteErrorLog(ex)
    '                '---------------------------------------------------------
    '            Finally
    '                '---------------------------------------------------------
    '                'Writing Execution log
    '                If CONST_CREATE_EXECUTION_LOG = 1 Then
    '                    gobjErrorHandler.WriteExecutionLog()
    '                End If
    '                '---------------------------------------------------------
    '            End Try
    '        End Sub

    '        Private Function SetAutoSampler(ByVal pos As Integer, ByVal flag As Boolean) As Boolean
    '            '---FUNCTION TEMPORARILY COMMENTED AS NO AUTOSAMPLER
    '            Return False
    '            '---FUNCTION TEMPORARILY COMMENTED AS NO AUTOSAMPLER


    '            'BOOL		SetAutoSampler(HWND hpar, int pos, BOOL flag)
    '            '{
    '            'char	str[40];
    '            '        If (!IsSamplerConnected()) Then
    '            '  return FALSE;

    '            ' if (hpar) EnableWindow(hpar, FALSE);
    '            'if (flag){
    '            '	 sprintf(str,"Sampler => %d        ", pos);
    '            '	 //PrintmsgOnWvAbsTag(str);
    '            '	 ASamplerStart(pos,hpar);
    '            '	}
    '            'else{
    '            '  sprintf(str, "Resetting Sampler    ");
    '            '  //PrintmsgOnWvAbsTag(str);
    '            '  ASamplerEnd(hpar);
    '            ' }
    '            '// }
    '            '// SendMessage(hpar, WM_COMMAND, IDC_QAREAD, 0L);
    '            ' if (hpar) EnableWindow(hpar, TRUE);
    '            'return TRUE;
    '            '}

    '            '-------CODE BY MANGESH 
    '            Dim str As String

    '            Try
    '                'If Not (IsSamplerConnected()) Then
    '                '    Return False
    '                'End If

    '                If (flag) Then
    '                    str = "Sampler => " & pos & "    "
    '                    'ASamplerStart(pos)
    '                Else
    '                    str = "Resetting Sampler    "
    '                    'ASamplerEnd()
    '                End If

    '                Return True

    '            Catch ex As Exception
    '                '---------------------------------------------------------
    '                'Error Handling and logging
    '                gobjErrorHandler.ErrorDescription = ex.Message
    '                gobjErrorHandler.ErrorMessage = ex.Message
    '                gobjErrorHandler.WriteErrorLog(ex)
    '                '---------------------------------------------------------
    '            Finally
    '                '---------------------------------------------------------
    '                'Writing Execution log
    '                If CONST_CREATE_EXECUTION_LOG = 1 Then
    '                    gobjErrorHandler.WriteExecutionLog()
    '                End If
    '                '---------------------------------------------------------
    '            End Try
    '        End Function

    '        Private Function PositionAutosampler() As Boolean
    '            '---FUNCTION TEMPORARILY COMMENTED AS NO AUTOSAMPLER
    '            Return False
    '            '---FUNCTION TEMPORARILY COMMENTED AS NO AUTOSAMPLER


    '            'BOOL PositionAutosampler(HWND hwnd,char *str)
    '            '{
    '            '   int  WASH_TIME=20;
    '            '	GetProfileStringFromIniFile("AutoSampler", "Wash Time (sec)", "10",str, "asampler.ini");
    '            '	trim(ltrim(str)); 
    '            '   WASH_TIME=atoi(str);
    '            '   If (!IsSamplerConnected()) Then
    '            '	    return FALSE;
    '            '	strcpy(str,"Positioning Autosampler for Aspirating Blank");
    '            '   If (Started) Then
    '            '	    strcpy(Aspiratemsg, str);
    '            '	if(ASampler_GoToYhome(0))    
    '            '	{
    '            '	    if(ASampler_ProbeDown()){
    '            '		    sprintf(str,"Aspirating Blank wait for wash time %d sec",WASH_TIME);
    '            '           If (Started) Then
    '            '		        strcpy(Aspiratemsg, str);
    '            '		    ASampler_PumpON();
    '            '		    WaitForSec(WASH_TIME); 
    '            '		    ASampler_PumpOFF();
    '            '		 }
    '            '        Else
    '            '		    Gerror_message_system("Error in placing probe down");
    '            '	}
    '            '	else
    '            '	    Gerror_message_system("Error in positioning Autosampler");
    '            '	strcpy(str,"");
    '            '	return TRUE ;
    '            '}


    '            Dim WASH_TIME As Integer = 20
    '            Dim strTemp As String = ""

    '            Try
    '                strTemp = gFuncGetFromINI(CONST_Section_AutoSampler, CONST_Key_WashTime, "10", CONST_AutoSampler_INI_FileName)
    '                WASH_TIME = Val(Trim(strTemp))

    '                '---TEMPORARILY COMMENTED
    '                'If Not (IsSamplerConnected()) Then
    '                '    Return False
    '                'End If
    '                '---TEMPORARILY COMMENTED

    '                If (mblnIsAnalysisStarted) Then
    '                    mstrAspirationMessage = "Positioning Autosampler for Aspirating Blank"
    '                End If

    '                '---TEMPORARILY COMMENTED
    '                'If (ASampler_GoToYhome(0)) Then
    '                '    If (ASampler_ProbeDown()) Then
    '                '        If (mblnIsAnalysisStarted) Then
    '                '            mstrAspirationMessage = "Aspirating Blank wait for wash time " & WASH_TIME & " sec"
    '                '        End If
    '                '        ASampler_PumpON()
    '                '        WaitForSec(WASH_TIME)
    '                '        ASampler_PumpOFF()
    '                '    Else
    '                '        MessageBox.Show("Error in placing probe down")
    '                '    End If
    '                'Else
    '                '    MessageBox.Show("Error in positioning Autosampler")
    '                'End If
    '                '---TEMPORARILY COMMENTED

    '                Return True

    '            Catch ex As Exception
    '                '---------------------------------------------------------
    '                'Error Handling and logging
    '                gobjErrorHandler.ErrorDescription = ex.Message
    '                gobjErrorHandler.ErrorMessage = ex.Message
    '                gobjErrorHandler.WriteErrorLog(ex)
    '                '---------------------------------------------------------
    '            Finally
    '                '---------------------------------------------------------
    '                'Writing Execution log
    '                If CONST_CREATE_EXECUTION_LOG = 1 Then
    '                    gobjErrorHandler.WriteExecutionLog()
    '                End If
    '                '---------------------------------------------------------
    '            End Try
    '        End Function

    '        Private Sub SaveRawDataFile()
    '            '=====================================================================
    '            ' Procedure Name        : SaveRawDataFile
    '            ' Parameters Passed     : None
    '            ' Returns               : None
    '            ' Purpose               : To save raw data for current run number.
    '            ' Description           : 
    '            ' Assumptions           : 
    '            ' Dependencies          : 
    '            ' Author                : Mangesh Shardul
    '            ' Created               : 17-Jan-2007 03:25 pm
    '            ' Revisions             : 1
    '            '=====================================================================
    '            'void	SaveRawDataFile(void)
    '            '{
    '            'char	fname[128]="";
    '            'char	rsultfname[80]="";
    '            ' if (Method->QuantData && Method->QuantData->Fname>0){
    '            '	 GetRawDataDirectory(fname);
    '            '	 sprintf(rsultfname,"Saving %08.0f.dat",Method->QuantData->Fname );
    '            '	 SetShortHelp(rsultfname, TRUE);
    '            '	 sprintf(rsultfname,"%08.0f.dat",Method->QuantData->Fname );
    '            '	 strcat(fname, rsultfname);
    '            '	 RawDataSave(fname);
    '            '	 SetShortHelp("", TRUE);
    '            '	}
    '            '}

    '            '*************************************
    '            'CODE BY MANGESH 
    '            '*************************************
    '            Dim fname As String = ""
    '            Dim rsultfname As String = ""

    '            Try
    '                If (Not IsNothing(gobjNewMethod) And CInt(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).RunNumber) > 0) Then
    '                    ''rsultfname = "Saving " & gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).RunNumber & ".dat"
    '                    ''rsultfname = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).RunNumber & ".dat"
    '                    ''fname = rsultfname
    '                    ''Call RawDataSave(fname)
    '                    gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisRawData = mobjAnalysisRawData
    '                End If

    '            Catch ex As Exception
    '                '---------------------------------------------------------
    '                'Error Handling and logging
    '                gobjErrorHandler.ErrorDescription = ex.Message
    '                gobjErrorHandler.ErrorMessage = ex.Message
    '                gobjErrorHandler.WriteErrorLog(ex)
    '                '---------------------------------------------------------
    '            Finally
    '                '---------------------------------------------------------
    '                'Writing Execution log
    '                If CONST_CREATE_EXECUTION_LOG = 1 Then
    '                    gobjErrorHandler.WriteExecutionLog()
    '                End If
    '                '---------------------------------------------------------
    '            End Try
    '        End Sub

    '        'Private Function CheckValidStdAbsEntry(ByVal objStandardData As Method.clsAnalysisStdParametersCollection) As Boolean
    '        '    'BOOL CheckValidStdAbsEntry( STDDATA *std) // this fn added by sss for checking the valid std used or not dt 30/11/2K
    '        '    '{
    '        '    'double abs=0.0;
    '        '    'BOOL   flag = TRUE;
    '        '    'if(std){
    '        '    '	if(std->Data.Used==1){
    '        '    '		abs = std->Data.Abs;
    '        '    '		std = std=std->next;
    '        '    '	}
    '        '    '}
    '        '    'while(std){
    '        '    '	  if(std->Data.Used==1){
    '        '    '		  if( std->Data.Abs <= abs ){
    '        '    '				flag = FALSE;
    '        '    '				Gerror_message_new("Abs of the standard is less than or equal to the previous standard", "Standards");
    '        '    '				return flag;
    '        '    '		  }
    '        '    '		  abs = std->Data.Abs;
    '        '    '	  }
    '        '    '	  std=std->next;
    '        '    '}
    '        '    'return flag;
    '        '    '}

    '        '    '*****************************
    '        '    '---CODE BY MANGESH
    '        '    '*****************************
    '        '    Dim abs As Double = 0.0
    '        '    Dim flag As Boolean = True
    '        '    Dim intCounter As Integer

    '        '    Try
    '        '        For intCounter = 0 To objStandardData.Count - 1
    '        '            If (objStandardData(intCounter).Used = True) Then
    '        '                If (objStandardData(intCounter).Abs <= abs) Then
    '        '                    flag = False
    '        '                    Call gobjMessageAdapter.ShowMessage("Abs of the standard is less than or equal to the previous standard", "Standards", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage)
    '        '                    Call Application.DoEvents()
    '        '                    Return False
    '        '                End If
    '        '                abs = objStandardData(intCounter).Abs
    '        '            End If
    '        '        Next

    '        '        Return flag

    '        '    Catch ex As Exception
    '        '        '---------------------------------------------------------
    '        '        'Error Handling and logging
    '        '        gobjErrorHandler.ErrorDescription = ex.Message
    '        '        gobjErrorHandler.ErrorMessage = ex.Message
    '        '        gobjErrorHandler.WriteErrorLog(ex)
    '        '        '---------------------------------------------------------
    '        '    Finally
    '        '        '---------------------------------------------------------
    '        '        'Writing Execution log
    '        '        If CONST_CREATE_EXECUTION_LOG = 1 Then
    '        '            gobjErrorHandler.WriteExecutionLog()
    '        '        End If
    '        '        '---------------------------------------------------------
    '        '    End Try
    '        'End Function

    '        'Private Function CheckValidSampAbsEntry(ByVal objSampleData As Method.clsAnalysisSampleParametersCollection, ByVal dblSampConc As Double) As Boolean
    '        '    'BOOL CheckValidSampAbsEntry( STDDATA *std,double sampconc) // this fn added by sss for checking the valid samp used or not dt 26/12/2K
    '        '    '{
    '        '    'double abs=0.0;
    '        '    'BOOL   flag = TRUE;
    '        '    'abs=GetMaxStdAbs(std);
    '        '    '//if((abs+abs*0.05) < sampconc)
    '        '    '        If ((abs) < sampconc) Then
    '        '    '	flag = FALSE;
    '        '    'return flag;
    '        '    '}

    '        '    '******************
    '        '    '---CODE BY MANGESH 
    '        '    '******************
    '        '    Dim abs As Double = 0.0
    '        '    Dim flag As Boolean = True

    '        '    Try
    '        '        abs = GetMaxStdAbs(objSampleData)

    '        '        If ((abs) < dblSampConc) Then
    '        '            flag = False
    '        '        End If

    '        '        Return flag

    '        '    Catch ex As Exception
    '        '        '---------------------------------------------------------
    '        '        'Error Handling and logging
    '        '        gobjErrorHandler.ErrorDescription = ex.Message
    '        '        gobjErrorHandler.ErrorMessage = ex.Message
    '        '        gobjErrorHandler.WriteErrorLog(ex)
    '        '        '---------------------------------------------------------
    '        '    Finally
    '        '        '---------------------------------------------------------
    '        '        'Writing Execution log
    '        '        If CONST_CREATE_EXECUTION_LOG = 1 Then
    '        '            gobjErrorHandler.WriteExecutionLog()
    '        '        End If
    '        '        '---------------------------------------------------------
    '        '    End Try
    '        'End Function

    '        'Private Function GetMaxStdAbs(ByVal objSampleData As Method.clsAnalysisSampleParametersCollection) As Double
    '        '    'double GetMaxStdAbs(STDDATA *std)
    '        '    '{
    '        '    'double Abs=0.0;
    '        '    'while(std){
    '        '    '	  if(std->Data.Used==1){
    '        '    '		  if( std->Data.Abs >= Abs )
    '        '    '				Abs = std->Data.Abs;
    '        '    '	  }
    '        '    '	  std=std->next;
    '        '    '}
    '        '    'return Abs;
    '        '    '}

    '        '    '********************
    '        '    '---CODE BY MANGESH 
    '        '    '********************
    '        '    Dim dblMaxAbs As Double
    '        '    Dim intCounter As Integer

    '        '    Try
    '        '        dblMaxAbs = 0.0

    '        '        For intCounter = 0 To objSampleData.Count - 1
    '        '            If (objSampleData.item(intCounter).Used = True) Then
    '        '                If (objSampleData.item(intCounter).Abs >= dblMaxAbs) Then
    '        '                    dblMaxAbs = objSampleData.item(intCounter).Abs
    '        '                End If
    '        '            End If
    '        '        Next

    '        '        Return dblMaxAbs

    '        '    Catch ex As Exception
    '        '        '---------------------------------------------------------
    '        '        'Error Handling and logging
    '        '        gobjErrorHandler.ErrorDescription = ex.Message
    '        '        gobjErrorHandler.ErrorMessage = ex.Message
    '        '        gobjErrorHandler.WriteErrorLog(ex)
    '        '        '---------------------------------------------------------
    '        '    Finally
    '        '        '---------------------------------------------------------
    '        '        'Writing Execution log
    '        '        If CONST_CREATE_EXECUTION_LOG = 1 Then
    '        '            gobjErrorHandler.WriteExecutionLog()
    '        '        End If
    '        '        '---------------------------------------------------------
    '        '    End Try
    '        'End Function

    '        Private Function StoreCalculateDisplayQuantValue() As Double
    '            '=====================================================================
    '            ' Procedure Name        : StoreCalculateDisplayQuantValue
    '            ' Parameters Passed     : None
    '            ' Returns               : None
    '            ' Purpose               : 
    '            ' Description           : 
    '            ' Assumptions           : 
    '            ' Dependencies          : 
    '            ' Author                : Mangesh Shardul
    '            ' Created               : 17-Jan-2007 03:25 pm
    '            ' Revisions             : 1
    '            '=====================================================================

    '            'double StoreCalculateDisplayQuantValue(HWND hwnd)
    '            '{
    '            'char	str[40]="";
    '            'double	abs=0.0;
    '            'double	abs1=0.0;
    '            'static	STDDATA	*nCurStd=NULL;
    '            'static	SAMPDATA	*nCurSamp=NULL;
    '            'static	double	lblank = (double) 0.0;
    '            'static	int	nSampType = -1 ;;

    '            'if(mobjCurrentStandard==Method->QuantData->StdTopData && CurRepeat==1)
    '            '{
    '            '   nCurStd=NULL;
    '            '	nCurSamp=NULL;
    '            '	lblank=(double) 0.0;
    '            '	nSampType=-1;;
    '            '}

    '            'if (Method->QuantData->Param.Meas_Mode==INTEGRATE)
    '            '{
    '            '   abs = GetAvgValOfCurAnalysis();
    '            '	abs = GetValConvertedTo(abs, Method->Mode);
    '            '}
    '            'else if (Method->QuantData->Param.Meas_Mode==PKAREA)
    '            '{
    '            '   abs = GetPeakAreaOfCurAnalysis();
    '            '	abs = GetValConvertedTo(abs, Method->Mode);
    '            '}
    '            'else if (Method->QuantData->Param.Meas_Mode==PKHEIGHT)
    '            '{
    '            '   abs = GetPeakHeightOfCurAnalysis();
    '            '	abs = GetValConvertedTo(abs, Method->Mode);
    '            '}

    '            'if (SampType == BLANK)
    '            '{
    '            '   BlankAbs = abs;
    '            '	GetValInString(abs, str, Method->Mode);
    '            '	SetDlgItemText(hwnd,IDC_QAVABS, str);
    '            '	SetDlgItemText(hwnd,IDC_QCORABS, "");
    '            '	SetDlgItemText(hwnd,IDC_QCONC, "");

    '            '   if (GetBlankCalType())
    '            '   {
    '            '	    BlankAbs = (lblank + BlankAbs)/2.0;
    '            '		if (nSampType==STD && nCurStd!=NULL)
    '            '       {
    '            '		    abs =nCurStd->Data.Abs;
    '            '			sprintf(str, "%s",nCurStd->Data.Std_Name);
    '            '	    }
    '            '		if (nSampType==SAMP&& nCurSamp!=NULL)
    '            '       {
    '            '		    abs =nCurSamp->Data.Abs;
    '            '			sprintf(str, "%s",nCurSamp->Data.Samp_Name);
    '            '		}
    '            '		SetDlgItemText(hwnd,IDC_QSAMPID, str);
    '            '		abs1 = StoreCalculateStdSampDisplayQuantValue(hwnd, nSampType, &nCurStd, &nCurSamp, abs);

    '            '		if (mobjCurrentStandard==NULL && mobjCurrentSample ==Method->QuantData->SampTopData)
    '            '			 Create_Standard_Sample_Curve(hwnd,FALSE);
    '            '   }
    '            '}
    '            'else
    '            '{
    '            '   If (!GetBlankCalType()) Then
    '            '	    abs1=StoreCalculateStdSampDisplayQuantValue(hwnd, SampType, &mobjCurrentStandard, &mobjCurrentSample, abs);
    '            '   else
    '            '   {
    '            '       if (SampType==STD && mobjCurrentStandard!=NULL)
    '            '		    mobjCurrentStandard->Data.Abs=abs;

    '            '	    if (SampType==SAMP&& mobjCurrentSample!=NULL)
    '            '		    mobjCurrentSample->Data.Abs=abs;

    '            '		 GetValInString(abs, str, Method->Mode);
    '            '		 SetDlgItemText(hwnd,IDC_QAVABS, str);
    '            '		 SetDlgItemText(hwnd,IDC_QCORABS, "");
    '            '		 nCurStd=mobjCurrentStandard;
    '            '		 nCurSamp=mobjCurrentSample;
    '            '		 nSampType = SampType;
    '            '		 lblank = BlankAbs;
    '            '	}
    '            '}
    '            'return abs1;
    '            '}

    '            '***************************************************
    '            '---CODE BY MANGESH 
    '            '***************************************************
    '            Dim strSampleName As String = ""
    '            Dim abs As Double = 0.0
    '            Dim abs1 As Double = 0.0

    '            Static Dim nCurStd As Method.clsAnalysisStdParameters
    '            Static Dim nCurSamp As Method.clsAnalysisSampleParameters
    '            Static Dim lblank As Double = 0.0
    '            Static Dim nSampType As ClsAAS203.enumSampleType = -1

    '            Try
    '                If (mobjCurrentStandard Is gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(0) And CurRepeat = 1) Then
    '                    nCurStd = Nothing
    '                    nCurSamp = Nothing
    '                    lblank = 0.0
    '                    nSampType = -1
    '                End If

    '                If (gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.MeasurementMode = enumMeasurementMode.Integrate) Then
    '                    '---Get Average of all readings of clsRawData 
    '                    abs = GetAvgValOfCurAnalysis()

    '                    '---Later call this method instead of above function.
    '                    'abs = GetAvgValOfAnalysis( .item(0) )
    '                    '---Later on remove this comment

    '                ElseIf (gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.MeasurementMode = enumMeasurementMode.PeakArea) Then
    '                    '---Returns ZERO 
    '                    abs = GetPeakAreaOfCurAnalysis()

    '                ElseIf (gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.MeasurementMode = enumMeasurementMode.PeakHeight) Then
    '                    '---Returns ZERO 
    '                    abs = GetPeakHeightOfCurAnalysis()

    '                End If

    '                If (SampleType = ClsAAS203.enumSampleType.BLANK) Then
    '                    mdblBlankAbsorbance = abs

    '                    'Saurabh 05 June 2007
    '                    'lblAverageAbsorbance.Text = FormatNumber(abs, gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfDecimalPlaces)
    '                    'lblAverageAbsorbance.Text = FormatNumber(abs, 3)
    '                    'Saurabh 05 June 2007

    '                    'lblCorrectedAbsorbance.Text = ""
    '                    'lblConcentration.Text = ""

    '                    If (gstructSettings.BlankCalculation) Then
    '                        mdblBlankAbsorbance = (lblank + mdblBlankAbsorbance) / 2.0

    '                        If nSampType = ClsAAS203.enumSampleType.STANDARD And (Not IsNothing(nCurStd)) Then
    '                            abs = nCurStd.Abs
    '                            strSampleName = nCurStd.StdName
    '                        End If

    '                        If nSampType = ClsAAS203.enumSampleType.SAMPLE And (Not IsNothing(nCurSamp)) Then
    '                            abs = nCurSamp.Abs
    '                            strSampleName = nCurSamp.SampleName
    '                        End If
    '                        'lblSampleID.Text = strSampleName 

    '                        abs1 = StoreCalculateStdSampDisplayQuantValue(nSampType, nCurStd, nCurSamp, abs)

    '                        'if (mobjCurrentStandard==NULL && mobjCurrentSample == Method->QuantData->SampTopData)
    '                        '   Create_Standard_Sample_Curve(hwnd,FALSE);
    '                        If (IsNothing(mobjCurrentStandard) And mobjCurrentSample Is gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(0)) Then
    '                            Call gobjclsStandardGraph.Create_Standard_Sample_Curve(False, True, 0, 0, gobjNewMethod)
    '                        End If
    '                    End If
    '                Else
    '                    If Not (gstructSettings.BlankCalculation) Then
    '                        abs1 = StoreCalculateStdSampDisplayQuantValue(SampleType, mobjCurrentStandard, mobjCurrentSample, abs)
    '                    Else
    '                        If (SampleType = ClsAAS203.enumSampleType.STANDARD) And Not IsNothing(mobjCurrentStandard) Then
    '                            mobjCurrentStandard.Abs = abs
    '                        End If

    '                        If (SampleType = ClsAAS203.enumSampleType.SAMPLE And Not IsNothing(mobjCurrentSample)) Then
    '                            mobjCurrentSample.Abs = abs
    '                        End If

    '                        'Saurabh 05 June 2007
    '                        'lblAverageAbsorbance.Text = FormatNumber(abs, gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfDecimalPlaces)
    '                        'lblAverageAbsorbance.Text = FormatNumber(abs, 3)
    '                        'Saurabh 05 June 2007

    '                        'lblCorrectedAbsorbance.Text = ""
    '                        nCurStd = mobjCurrentStandard
    '                        nCurSamp = mobjCurrentSample
    '                        nSampType = SampleType
    '                        lblank = mdblBlankAbsorbance
    '                    End If
    '                End If

    '                Return abs1

    '            Catch ex As Exception
    '                '---------------------------------------------------------
    '                'Error Handling and logging
    '                gobjErrorHandler.ErrorDescription = ex.Message
    '                gobjErrorHandler.ErrorMessage = ex.Message
    '                gobjErrorHandler.WriteErrorLog(ex)
    '                '---------------------------------------------------------
    '            Finally
    '                '---------------------------------------------------------
    '                'Writing Execution log
    '                If CONST_CREATE_EXECUTION_LOG = 1 Then
    '                    gobjErrorHandler.WriteExecutionLog()
    '                End If
    '                '---------------------------------------------------------
    '            End Try
    '        End Function

    '        Private Function RawDataSave(ByVal strFullFileName As String) As Boolean
    '            'RAW_DATA 		*tempk=NULL;
    '            'RAW_DATA_LINKS *tempk1=NULL;
    '            'FILE *fp;

    '            Dim objRawDataReadings As Analysis.clsRawDataReadings
    '            Dim intCount As Integer
    '            Dim intReadingCounter As Integer
    '            Dim fs As IO.FileStream
    '            Dim sw As IO.StreamWriter

    '            Dim blnIsBlank, blnIsStandard, blnIsSample As Boolean
    '            Dim intPrevSampleID, intSampleID As Integer

    '            Try
    '                If IsNothing(mobjAnalysisRawData) Then
    '                    Return False
    '                End If

    '                If IO.File.Exists(strFullFileName) Then IO.File.Delete(strFullFileName)

    '                fs = New IO.FileStream(strFullFileName, IO.FileMode.OpenOrCreate)
    '                sw = New IO.StreamWriter(fs)

    '                If Not IsNothing(sw) Then
    '                    For intCount = 0 To mobjAnalysisRawData.Count - 1
    '                        objRawDataReadings = mobjAnalysisRawData.item(intCount).Readings
    '                        If (mobjAnalysisRawData.item(intCount).TotalReadings > 0) Then
    '                            intSampleID = mobjAnalysisRawData.item(intCount).SampleID
    '                            Select Case mobjAnalysisRawData.item(intCount).SampleType
    '                                Case clsRawData.enumSampleType.BLANK
    '                                    If Not blnIsBlank Then
    '                                        blnIsBlank = True
    '                                        blnIsStandard = False
    '                                        blnIsSample = False
    '                                        sw.WriteLine("BLANK; ; ; " & objRawDataReadings.Count)
    '                                    Else
    '                                        If intSampleID <> intPrevSampleID Then
    '                                            sw.WriteLine()
    '                                            sw.WriteLine("BLANK; ; ; " & objRawDataReadings.Count)
    '                                        End If
    '                                    End If

    '                                Case clsRawData.enumSampleType.STANDARD
    '                                    If Not blnIsStandard Then
    '                                        blnIsBlank = False
    '                                        blnIsStandard = True
    '                                        blnIsSample = False
    '                                        sw.WriteLine()
    '                                        sw.WriteLine("STANDARD ;" & mobjAnalysisRawData(intCount).SampleID & ";" & mobjAnalysisRawData(intCount).SampleName & "; " & objRawDataReadings.Count & "")
    '                                    Else
    '                                        If intSampleID <> intPrevSampleID Then
    '                                            sw.WriteLine()
    '                                            sw.WriteLine("STANDARD ;" & mobjAnalysisRawData(intCount).SampleID & ";" & mobjAnalysisRawData(intCount).SampleName & "; " & objRawDataReadings.Count & "")
    '                                        End If
    '                                    End If

    '                                Case clsRawData.enumSampleType.SAMPLE
    '                                    If Not blnIsSample Then
    '                                        blnIsBlank = False
    '                                        blnIsStandard = False
    '                                        blnIsSample = True
    '                                        sw.WriteLine()
    '                                        sw.WriteLine("SAMPLE ;" & mobjAnalysisRawData(intCount).SampleID & ";" & mobjAnalysisRawData(intCount).SampleName & "; " & objRawDataReadings.Count & "")
    '                                    Else
    '                                        If intSampleID <> intPrevSampleID Then
    '                                            sw.WriteLine()
    '                                            sw.WriteLine("SAMPLE ;" & mobjAnalysisRawData(intCount).SampleID & ";" & mobjAnalysisRawData(intCount).SampleName & "; " & objRawDataReadings.Count & "")
    '                                        End If
    '                                    End If
    '                            End Select
    '                        End If
    '                        For intReadingCounter = 0 To objRawDataReadings.Count - 1
    '                            sw.WriteLine(objRawDataReadings(intReadingCounter).XTime & " ,  " & objRawDataReadings(intReadingCounter).Absorbance)
    '                        Next
    '                        '---Draw empty line
    '                        'sw.WriteLine()
    '                        intPrevSampleID = intSampleID
    '                    Next intCount

    '                End If

    '                sw.Flush()
    '                fs.Flush()

    '                Return True

    '            Catch ex As Exception
    '                '---------------------------------------------------------
    '                'Error Handling and logging
    '                gobjErrorHandler.ErrorDescription = ex.Message
    '                gobjErrorHandler.ErrorMessage = ex.Message
    '                gobjErrorHandler.WriteErrorLog(ex)
    '                '---------------------------------------------------------
    '            Finally
    '                '---------------------------------------------------------
    '                'Writing Execution log
    '                If CONST_CREATE_EXECUTION_LOG = 1 Then
    '                    gobjErrorHandler.WriteExecutionLog()
    '                End If
    '                sw.Close()
    '                fs.Close()
    '                '---------------------------------------------------------
    '            End Try
    '        End Function

    '        Public Function Calculate_Analysis_Graph_Param(ByRef Curve As AASGraph, Optional ByVal XValue As Double = 0.0, Optional ByVal YValue As Double = 0.0) As Double
    '            '=====================================================================
    '            ' Procedure Name        : Calculate_Analysis_Graph_Param
    '            ' Parameters Passed     : AASGraph Reference
    '            ' Returns               : Double value
    '            ' Purpose               : 
    '            ' Description           : 
    '            ' Assumptions           : 
    '            ' Dependencies          : 
    '            ' Author                : Mangesh Shardul
    '            ' Created               : 17-Jan-2007 03:25 pm
    '            ' Revisions             : 1
    '            '=====================================================================
    '            Dim FrqIntv As Double = 0.0
    '            Dim xmax1 As Double = 0
    '            Dim xmin1 As Double = 0
    '            Dim Fmin As Double = 0
    '            Dim Fmax As Double = 0
    '            Dim Fx As Double = 0
    '            Dim fn, tot1 As Integer

    '            Try
    '                If IsNothing(Curve) Then
    '                    Return 0.0
    '                End If

    '                xmax1 = Curve.YAxisMax
    '                xmin1 = Curve.YAxisMin
    '                tot1 = (xmax1 - xmin1) * 60

    '                FrqIntv = gobjclsStandardGraph.GetInterval(xmax1, xmin1, tot1, True)
    '                'FrqIntv = 100

    '                fn = (xmax1 / FrqIntv)
    '                Fmax = CDbl(fn * FrqIntv)
    '                If xmax1 > Fmax Then
    '                    Fmax = Fmax + FrqIntv
    '                End If
    '                fn = CInt(xmin1 / FrqIntv)
    '                Fmin = CDbl(fn * FrqIntv)

    '                If (xmin1 < Fmin) Then
    '                    Fmin = Fmin - FrqIntv
    '                End If

    '                If (Fmin > xmin1) And (FrqIntv <> -1.0) Then
    '                    While (Fmin > xmin1)
    '                        Fmax -= FrqIntv
    '                    End While
    '                End If

    '                If (Fmax < xmax1 And FrqIntv <> -1.0) Then
    '                    While (Fmax < xmax1)
    '                        Fmax += FrqIntv
    '                    End While
    '                End If
    '                'Curve.YAxisMin = -0.2 'Fmin
    '                'Curve.YAxisMax = 1.1  'Fmax
    '                'Curve.YAxisStep = 0.1 'FrqIntv
    '                'Curve.YAxisMinorStep = 0.05

    '                '---changed by deepak on 29.04.07
    '                Curve.YAxisMin = -0.2 'Fmin
    '                Curve.YAxisMax = 0.8  '0.8 'Fmax ' changed by pankaj
    '                Curve.YAxisStep = 0.2 'FrqIntv
    '                Curve.YAxisMinorStep = 0.2
    '                '---changed by deepak on 29.04.07

    '                '//----- Added by Sachin Dokhale
    '                'xmax1 = Curve.XAxisMax
    '                'xmin1 = Curve.XAxisMin
    '                If Not (XValue = 0.0) Then
    '                    'Saurabh 10.07.07 for Scrolling Graph
    '                    'If (XValue > Curve.XAxisMax) Then
    '                    '    xmax1 = Curve.XAxisMax + (gobjNewMethod.AnalysisParameters.IntegrationTime * 3)
    '                    'End If
    '                    'xmin1 = Curve.XAxisMin
    '                    If (XValue > Curve.XAxisMax) Then
    '                        xmax1 = Curve.XAxisMax + (gobjNewMethod.AnalysisParameters.IntegrationTime + 20)
    '                        xmin1 = Curve.XAxisMin + (gobjNewMethod.AnalysisParameters.IntegrationTime + 20)
    '                    Else
    '                        xmin1 = Curve.XAxisMin
    '                    End If

    '                Else
    '                    xmax1 = Curve.XAxisMax
    '                    xmin1 = Curve.XAxisMin
    '                End If

    '                tot1 = 60
    '                Fx = gobjclsStandardGraph.GetInterval(xmax1, xmin1, tot1, True)

    '                If (Fx > 0) Then
    '                    fn = xmax1 / Fx
    '                Else
    '                    fn = 0
    '                End If

    '                Fmax = fn * Fx
    '                If (xmax1 > Fmax) Then
    '                    Fmax += Fx
    '                End If

    '                Curve.XAxisMin = xmin1
    '                Curve.XAxisMax = Fmax
    '                Curve.XAxisStep = gobjclsStandardGraph.GetInterval(Curve.XAxisMax, Curve.XAxisMin, tot1, True)

    '                'If is Added by Saurabh for Emission---------------
    '                If gobjNewMethod.OperationMode = EnumOperationMode.MODE_EMMISSION Then
    '                    'AASGraphAnalysis.YAxisMin = 0
    '                    'AASGraphAnalysis.YAxisMax = 100
    '                    'AASGraphAnalysis.YAxisMinorStep = 2
    '                Else
    '                    '-----Added By Pankaj on 10 May 2007
    '                    'AASGraphAnalysis.YAxisMin = -0.2
    '                    'AASGraphAnalysis.YAxisMax = 1.2
    '                End If

    '                'gobjClsAAS203.Calculate_Analysis_Graph_Param(AASGraphAnalysis, ClsAAS203.enumChangeAxis.xyAxis)
    '                '-------------

    '                Return FrqIntv

    '            Catch ex As Exception
    '                '---------------------------------------------------------
    '                'Error Handling and logging
    '                gobjErrorHandler.ErrorDescription = ex.Message
    '                gobjErrorHandler.ErrorMessage = ex.Message
    '                gobjErrorHandler.WriteErrorLog(ex)
    '                '---------------------------------------------------------
    '            Finally
    '                '---------------------------------------------------------
    '                'Writing Execution log
    '                If CONST_CREATE_EXECUTION_LOG = 1 Then
    '                    gobjErrorHandler.WriteExecutionLog()
    '                End If
    '                '---------------------------------------------------------
    '            End Try
    '        End Function

    '        Public Function Read_Quant_Data(ByVal intStartTime As Integer, ByVal intEndTime As Integer) As Double
    '            'double	 (HWND hwnd, CURVEDATA *AnaGraph)
    '            '{
    '            'HDC				 hdc;
    '            'HPEN				 hpen, hpenold;
    '            'double          abs1=0.0;

    '            '#If QDEMO Then
    '            'int	adval=0;
    '            '  if (!Dfptr){
    '            '	 Dfptr= fopen("raw0.dat","rt");
    '            '	 if (Dfptr)
    '            '		 fscanf(Dfptr, "%d", &adval);
    '            '	}
    '            '#End If
    '            ' hdc = GetDC(hwnd);
    '            ' ReadFilterSetting();   // new changes
    '            ' if (Method->Mode==MODE_UVABS){
    '            '	Read_Quant_Data_UV_Mode(hwnd);
    '            '  }
    '            ' else{
    '            '	hpen= SetColor(SampType, TRUE);
    '            '   If (hpen! = NULL) Then
    '            '	    hpenold = SelectObject(hdc, hpen);
    '            '	if (Xoldt!=-1 && Yoldt!=-1)
    '            '	    SetXoldYold(Xoldt, Yoldt);
    '            '	if (Method->QuantData->Param.Meas_Mode==INTEGRATE){
    '            '       If (!Filter_flag) Then
    '            '		    Wait_For_Analysis(hwnd, 2);
    '            '       Else
    '            '		    Wait_For_Analysis(hwnd, 2);
    '            '		Read_Quant_Data_Integration_Mode(hwnd,hdc, AnaGraph);
    '            '	}
    '            '	else if (Method->QuantData->Param.Meas_Mode==PKAREA ||
    '            '	         Method->QuantData->Param.Meas_Mode==PKHEIGHT)
    '            '	    Read_Quant_Data_PkHt_Area_Mode(hwnd, hdc, AnaGraph);
    '            '   abs1=StoreCalculateDisplayQuantValue(hwnd);
    '            '	GetXoldYold(&Xoldt, &Yoldt);
    '            '	if (hpen!=NULL){
    '            '	    SelectObject(hdc, hpenold);
    '            '	DeleteObject(hpen);
    '            '  }
    '            ' }
    '            ' ReleaseDC(hwnd, hdc);
    '            ' return abs1;
    '            '}

    '            '*****************************************
    '            '---CODE BY MANGESH
    '            '*****************************************
    '            'HDC				 hdc;
    '            'HPEN				 hpen, hpenold;
    '            Dim dblAbsorbance As Double = 0.0

    '            Try
    '                '#If QDEMO Then
    '                ' dim adval as integer=0
    '                ' if not (Dfptr)
    '                '	 Dfptr= fopen("raw0.dat","rt")
    '                '	 if (Dfptr)
    '                '		 fscanf(Dfptr, "%d", &adval )
    '                '   end if
    '                '  end if
    '                '#End If

    '                Call gobjClsAAS203.funcReadFilterSetting()

    '                Call StartAspirationThread(intStartTime, intEndTime)

    '                ''If (gobjNewMethod.OperationMode = EnumOperationMode.MODE_UVABS) Then
    '                ''    'Call Read_Quant_Data_UV_Mode()
    '                ''Else
    '                ''    'hpen = SetColor(SampType, True)
    '                ''    'If Not (hpen Is Nothing) Then
    '                ''    '    hpenold = SelectObject(hdc, hpen)
    '                ''    'End If
    '                ''    'If (XOld <> -1 And YOld <> -1) Then
    '                ''    '    SetXoldYold(XOld, YOld)
    '                ''    'End If

    '                ''    'If (XOld <> -1 And YOld <> -1) Then
    '                ''    '    XOld = 0
    '                ''    '    YOld = 0
    '                ''    'End If

    '                ''    Call StartAspirationThread(dtStartTime)

    '                ''    If (gobjNewMethod.AnalysisParameters.MeasurementMode = enumMeasurementMode.Integrate) Then
    '                ''        If Not (Filter_flag) Then
    '                ''            Wait_For_Analysis(2)
    '                ''        Else
    '                ''            Wait_For_Analysis(2)
    '                ''        End If

    '                ''        'Call Read_Quant_Data_Integration_Mode()
    '                ''        Call StartAspirationThread(dtStartTime)

    '                ''    ElseIf (gobjNewMethod.AnalysisParameters.MeasurementMode = enumMeasurementMode.PeakArea Or _
    '                ''            gobjNewMethod.AnalysisParameters.MeasurementMode = enumMeasurementMode.PeakHeight) Then

    '                ''        '#########TO DO Later
    '                ''        Call gobjClsAAS203.Read_Quant_Data_PkHt_Area_Mode()
    '                ''    End If

    '                '----Shited to Completed event function of BgThread
    '                'dblAbsorbance = StoreCalculateDisplayQuantValue()
    '                'Call GetXoldYold(XOld, YOld)
    '                'If Not (hpen Is Nothing) Then
    '                '    'SelectObject(hdc, hpenold)
    '                '    'DeleteObject(hpen)
    '                'End If
    '                '##########################################

    '                ''End If

    '                Return dblAbsorbance

    '            Catch ex As Exception
    '                '---------------------------------------------------------
    '                'Error Handling and logging
    '                gobjErrorHandler.ErrorDescription = ex.Message
    '                gobjErrorHandler.ErrorMessage = ex.Message
    '                gobjErrorHandler.WriteErrorLog(ex)
    '                '---------------------------------------------------------
    '            Finally
    '                '---------------------------------------------------------
    '                'Writing Execution log
    '                If CONST_CREATE_EXECUTION_LOG = 1 Then
    '                    gobjErrorHandler.WriteExecutionLog()
    '                End If
    '                '---------------------------------------------------------
    '            End Try
    '        End Function

    '        Private Sub SetXoldYold(ByVal dblXold As Double, ByVal dblYold As Double)
    '            'void SetXoldYold(int Xoldt, int Yoldt)
    '            '{
    '            '   Xold=Xoldt;
    '            '   Yold= Yoldt;
    '            '}
    '            Try
    '                XOld = dblXold
    '                YOld = dblYold

    '            Catch ex As Exception
    '                '---------------------------------------------------------
    '                'Error Handling and logging
    '                gobjErrorHandler.ErrorDescription = ex.Message
    '                gobjErrorHandler.ErrorMessage = ex.Message
    '                gobjErrorHandler.WriteErrorLog(ex)
    '                '---------------------------------------------------------
    '            Finally
    '                '---------------------------------------------------------
    '                'Writing Execution log
    '                If CONST_CREATE_EXECUTION_LOG = 1 Then
    '                    gobjErrorHandler.WriteExecutionLog()
    '                End If
    '                '---------------------------------------------------------
    '            End Try
    '        End Sub

    '        Private Sub GetXoldYold(ByRef dblXold As Double, ByRef dblYold As Double)
    '            'void GetXoldYold(int *Xoldt, int *Yoldt)
    '            '{
    '            '   *Xoldt=Xold;
    '            '   *Yoldt= Yold;
    '            '}
    '            Try
    '                dblXold = XOld
    '                dblYold = YOld

    '            Catch ex As Exception
    '                '---------------------------------------------------------
    '                'Error Handling and logging
    '                gobjErrorHandler.ErrorDescription = ex.Message
    '                gobjErrorHandler.ErrorMessage = ex.Message
    '                gobjErrorHandler.WriteErrorLog(ex)
    '                '---------------------------------------------------------
    '            Finally
    '                '---------------------------------------------------------
    '                'Writing Execution log
    '                If CONST_CREATE_EXECUTION_LOG = 1 Then
    '                    gobjErrorHandler.WriteExecutionLog()
    '                End If
    '                '---------------------------------------------------------
    '            End Try
    '        End Sub

    '        Private Function GetAvgValOfCurAnalysis() As Double
    '            'double	GetAvgValOfCurAnalysis()
    '            '{
    '            ' return GetAvgValOfAnalysis(Raw->RawDataCur);        
    '            '}

    '            '*********************************************************
    '            '---CODE BY MANGESH
    '            '*********************************************************
    '            Try
    '                'return GetAvgValOfAnalysis(Raw->RawDataCur) 
    '                If Not IsNothing(mobjAnalysisRawData) Then
    '                    If mobjAnalysisRawData.Count > 0 Then
    '                        Return GetAvgValOfAnalysis(mobjAnalysisRawData.item(mobjAnalysisRawData.Count - 1))
    '                    End If
    '                End If

    '            Catch ex As Exception
    '                '---------------------------------------------------------
    '                'Error Handling and logging
    '                gobjErrorHandler.ErrorDescription = ex.Message
    '                gobjErrorHandler.ErrorMessage = ex.Message
    '                gobjErrorHandler.WriteErrorLog(ex)
    '                '---------------------------------------------------------
    '            Finally
    '                '---------------------------------------------------------
    '                'Writing Execution log
    '                If CONST_CREATE_EXECUTION_LOG = 1 Then
    '                    gobjErrorHandler.WriteExecutionLog()
    '                End If
    '                '---------------------------------------------------------
    '            End Try
    '        End Function

    '        Private Function GetAvgValOfAnalysis(ByVal objAnalysisRawData As clsRawData) As Double
    '            '{
    '            'double	val=0.0;
    '            'int	tot=0;
    '            'RAW_DATA_LINKS *tempk=NULL;

    '            'if (node==NULL)
    '            '   return val;
    '            'tempk = node->Data.TopRawData;
    '            'while(tempk!=NULL)
    '            '{
    '            '   val+= tempk->Data.Abs;
    '            '   tot++;
    '            '   tempk=tempk->next;
    '            '}
    '            'If (tot > 0) Then
    '            '   val/=tot;
    '            'return val;
    '            '}

    '            '*****************************************************
    '            '--- CODE BY MANGESH
    '            '*****************************************************
    '            Dim dblAbsorbance As Double
    '            Dim intTotal As Integer
    '            Dim objRawDataReading As Analysis.clsRawDataReadings.RAW_DATA
    '            Dim intCounter As Integer

    '            Try
    '                intTotal = 0

    '                If Not IsNothing(objAnalysisRawData) Then

    '                    For intCounter = 0 To objAnalysisRawData.Readings.Count - 1
    '                        objRawDataReading = objAnalysisRawData.Readings.item(intCounter)
    '                        dblAbsorbance += objRawDataReading.Absorbance
    '                        intTotal += 1
    '                    Next intCounter

    '                    If (intTotal > 0) Then
    '                        dblAbsorbance = dblAbsorbance / intTotal
    '                    End If
    '                End If
    '                Return dblAbsorbance

    '            Catch ex As Exception
    '                '---------------------------------------------------------
    '                'Error Handling and logging
    '                gobjErrorHandler.ErrorDescription = ex.Message
    '                gobjErrorHandler.ErrorMessage = ex.Message
    '                gobjErrorHandler.WriteErrorLog(ex)
    '                '---------------------------------------------------------
    '            Finally
    '                '---------------------------------------------------------
    '                'Writing Execution log
    '                If CONST_CREATE_EXECUTION_LOG = 1 Then
    '                    gobjErrorHandler.WriteExecutionLog()
    '                End If
    '                '---------------------------------------------------------
    '            End Try
    '        End Function

    '        Private Function GetPeakAreaOfCurAnalysis() As Double
    '            'double	GetPeakAreaOfCurAnalysis()
    '            '{
    '            '/* float	absorb=0.0;
    '            ' float	y1;
    '            ' float	val=0;
    '            ' int	 i;
    '            ' absorb = 0.0 ;
    '            ' // formaulae = dx* ((y1+y2)/2 -(y1+y')/2)
    '            ' read_count = findPeak_end();
    '            ' for (i =0; i<read_count-1; i++){
    '            '	y1=GetBaseExtra((float) (i+1));
    '            '	val = (abs_read[i+1]-y1)/2.0;
    '            '            If (Val() < 0) Then
    '            '	 val=0;
    '            '   absorb+=val;
    '            '  }
    '            ' clearwindow1(20, 294, 190, 306);
    '            ' gxy1(5, 22);
    '            ' absorb = get_float(absorb, TRUE);
    '            ' if (mode==AA||mode==AABGC) gprintf("Peak Area   : %4.3f ", absorb);
    '            ' else if (mode==EMISSION)   gprintf("Peak Area   : %-4.3f ", absorb);
    '            ' return(absorb);
    '            ' }
    '            ' */

    '            'return 0.0;
    '            '}

    '            '************************************************************
    '            '--- CODE BY MANGESH 
    '            '************************************************************
    '            Try
    '                Return 0.0

    '            Catch ex As Exception
    '                '---------------------------------------------------------
    '                'Error Handling and logging
    '                gobjErrorHandler.ErrorDescription = ex.Message
    '                gobjErrorHandler.ErrorMessage = ex.Message
    '                gobjErrorHandler.WriteErrorLog(ex)
    '                '---------------------------------------------------------
    '            Finally
    '                '---------------------------------------------------------
    '                'Writing Execution log
    '                If CONST_CREATE_EXECUTION_LOG = 1 Then
    '                    gobjErrorHandler.WriteExecutionLog()
    '                End If
    '                '---------------------------------------------------------
    '            End Try
    '        End Function

    '        Private Function GetPeakHeightOfCurAnalysis() As Double
    '            'double	GetPeakHeightOfCurAnalysis()
    '            '{
    '            '   //---mdf by sk on 3/8/2001
    '            '   // return GetPkHtOfAnalysis(Raw->RawDataCur);
    '            '   //---mdf by sk on 3/8/2001
    '            '   /*float	peakheight()
    '            '   {
    '            '       float	absorb=0.0, sav=0.0, base=0.0;
    '            '       int	i;
    '            '       for (i =4; i<read_count-4; i++)  {
    '            '	        sav=abs_read[i];
    '            '	        if (sav > absorb){
    '            '	            absorb = sav;
    '            '	            base =  abs_read[0]+sav* (abs_read[read_count-1]-abs_read[0])/(read_count-1);
    '            '	            base= get_float(base, TRUE);
    '            '	        }
    '            '       }
    '            '       clearwindow1(20, 294, 190, 306);
    '            '       gxy1(5, 22);
    '            '       absorb -= base;
    '            '       absorb= get_float(absorb, TRUE);
    '            '       if (mode==AA||mode==AABGC) gprintf("Peak Height : %4.3f", absorb);
    '            '       else if (mode==EMISSION)   gprintf("Peak Height : %-4.3f", absorb);
    '            '       return(absorb);
    '            '   }
    '            '   */

    '            '   return 0.0;
    '            '}

    '            '*****************************************************
    '            '--- CODE BY MANGESH
    '            '*****************************************************
    '            Try
    '                Return 0.0

    '            Catch ex As Exception
    '                '---------------------------------------------------------
    '                'Error Handling and logging
    '                gobjErrorHandler.ErrorDescription = ex.Message
    '                gobjErrorHandler.ErrorMessage = ex.Message
    '                gobjErrorHandler.WriteErrorLog(ex)
    '                '---------------------------------------------------------
    '            Finally
    '                '---------------------------------------------------------
    '                'Writing Execution log
    '                If CONST_CREATE_EXECUTION_LOG = 1 Then
    '                    gobjErrorHandler.WriteExecutionLog()
    '                End If
    '                '---------------------------------------------------------
    '            End Try
    '        End Function

    '        Private Function StoreCalculateStdSampDisplayQuantValue(ByVal intSampleType As ClsAAS203.enumSampleType, _
    '                                                                ByRef nCurStd As Method.clsAnalysisStdParameters, _
    '                                                                ByRef nCurSamp As Method.clsAnalysisSampleParameters, _
    '                                                                ByVal dblAbsorbance As Double) As Double
    '            '=====================================================================
    '            ' Procedure Name        : StoreCalculateStdSampDisplayQuantValue
    '            ' Parameters Passed     : None
    '            ' Returns               : None
    '            ' Purpose               : 
    '            ' Description           : 
    '            ' Assumptions           : 
    '            ' Dependencies          : 
    '            ' Author                : Mangesh Shardul
    '            ' Created               : 17-Jan-2007 03:25 pm
    '            ' Revisions             : 1
    '            '=====================================================================
    '            'char	str[40]="";
    '            'double abs1=0.0;
    '            '  if (nSampType==STD){
    '            '	 if ((*nCurStd)!=NULL){
    '            '		 GetValInString(abs, str, Method->Mode);
    '            '		 SetDlgItemText(hwnd,IDC_QAVABS, str);
    '            '		 if (Method->QuantData->Param.Meas_Mode==INTEGRATE)
    '            '			abs-=BlankAbs;
    '            '		 (*nCurStd)->Data.Abs=abs;
    '            '//		 *nCurStd->Data.Abs = GetResultAccurate(abs, 3);
    '            '		 CheckValidStdAbs();
    '            '		 GetValInString(abs, str, Method->Mode);
    '            '		 SetDlgItemText(hwnd,IDC_QCORABS, str);
    '            '		 StoreResultAccurate((*nCurStd)->Data.Conc, str,
    '            '			  Method->QuantData->Param.No_Decimals);
    '            '		 SetDlgItemText(hwnd,IDC_QCONC, str);
    '            '		 if (Method->QuantData->Param.Repeat>1 || Method->QuantData->Param.ConcRepeat>1){
    '            '			AddAbsRepeatStd((*nCurStd)->Data.Abs, (*nCurStd)->Data.Conc,(*nCurStd));
    '            '			CalculateAvgOfStd((*nCurStd));
    '            '		  }
    '            '		 if (Method->Mode==MODE_EMISSION)
    '            '			(*nCurStd)->Data.Abs = GetResultAccurate((*nCurStd)->Data.Abs, 1);
    '            '                        Else
    '            '			 (*nCurStd)->Data.Abs = GetResultAccurate((*nCurStd)->Data.Abs, 3);
    '            '	  }
    '            '	}
    '            '  else if (nSampType==SAMP){
    '            '	 if (*nCurSamp!=NULL){
    '            '		 GetValInString(abs, str, Method->Mode);
    '            '		 SetDlgItemText(hwnd,IDC_QAVABS, str);
    '            '		 if (Method->QuantData->Param.Meas_Mode==INTEGRATE)
    '            '			abs-=BlankAbs;
    '            '		 (*nCurSamp)->Data.Abs=abs; // GetResultAccurate(abs, 3);
    '            '		 abs1 = abs; // added by sss for saving the abs of sample for checking for outoff scale on dt 27/12/2000
    '            '		 GetValInString(abs, str, Method->Mode);
    '            '		 SetDlgItemText(hwnd,IDC_QCORABS, str);
    '            '		 (*nCurSamp)->Data.Conc = Get_Conc((*nCurSamp)->Data.Abs, 0.0);
    '            '		 if ((*nCurSamp)->Data.Conc>=0 && (*nCurSamp)->Data.Abs>-0.1)
    '            '			(*nCurSamp)->Data.Used=TRUE;

    '            '		 if (Method->QuantData->Param.Repeat>1 || Method->QuantData->Param.ConcRepeat>1){
    '            '			AddAbsRepeatSamp((*nCurSamp)->Data.Abs, (*nCurSamp)->Data.Conc, (*nCurSamp));
    '            '			CalculateAvgOfSamp((*nCurSamp));
    '            '		  }
    '            '		 if (Method->Mode==MODE_EMISSION)
    '            '			(*nCurSamp)->Data.Abs = GetResultAccurate((*nCurSamp)->Data.Abs, 1);
    '            '                                            Else
    '            '			(*nCurSamp)->Data.Abs = GetResultAccurate((*nCurSamp)->Data.Abs, 3);
    '            '		 StoreResultAccurate((*nCurSamp)->Data.Conc, str,
    '            '			  Method->QuantData->Param.No_Decimals);
    '            '		 strcat(str, "   ppm");
    '            '		 SetDlgItemText(hwnd,IDC_QCONC, str);
    '            '	 }
    '            '	}
    '            '	return abs1;

    '            '*****************************************************************
    '            '--- CODE BY MANGESH
    '            '*****************************************************************
    '            Dim dblCorrectedAbsorbance As Double

    '            Try
    '                Select Case intSampleType
    '                    Case ClsAAS203.enumSampleType.STANDARD

    '                        If Not IsNothing(nCurStd) Then
    '                            'Saurabh 05 June 2007
    '                            'lblAverageAbsorbance.Text = FormatNumber(abs, gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfDecimalPlaces)
    '                            'lblAverageAbsorbance.Text = FormatNumber(dblAbsorbance, 3)
    '                            'Saurabh 05 June 2007

    '                            If (gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.MeasurementMode = enumMeasurementMode.Integrate) Then
    '                                dblAbsorbance -= mdblBlankAbsorbance
    '                            End If

    '                            nCurStd.Abs = dblAbsorbance
    '                            Call CheckValidStdAbs()
    '                            'Saurabh 05 June 2007
    '                            'lblCorrectedAbsorbance.Text = FormatNumber(dblAbsorbance, gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfDecimalPlaces)
    '                            'lblCorrectedAbsorbance.Text = FormatNumber(dblAbsorbance, 3)
    '                            'Saurabh 05 June 2007

    '                            '---Store Result Accurate upto AnalysisParameters.NumOfDecimalPlaces
    '                            'lblConcentration.Text = FormatNumber(nCurStd.Concentration, gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfDecimalPlaces)

    '                            If (gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfStdRepeats > 1 Or _
    '                                gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfSampleRepeats > 1) Then

    '                                Call AddAbsRepeatStd(nCurStd.Abs, nCurStd.Concentration, nCurStd.AbsRepeat)
    '                                Call CalculateAvgOfStd(nCurStd)
    '                            End If

    '                            If (gobjNewMethod.OperationMode = EnumOperationMode.MODE_EMMISSION) Then
    '                                nCurStd.Abs = FormatNumber(nCurStd.Abs, 1)
    '                            Else
    '                                nCurStd.Abs = FormatNumber(nCurStd.Abs, 3)
    '                            End If
    '                        End If

    '                    Case ClsAAS203.enumSampleType.SAMPLE

    '                        If Not IsNothing(nCurSamp) Then

    '                            'Saurabh 05 June 2007
    '                            'lblAverageAbsorbance.Text = FormatNumber(abs, gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfDecimalPlaces)
    '                            'lblAverageAbsorbance.Text = FormatNumber(dblAbsorbance, 3)
    '                            'Saurabh 05 June 2007

    '                            If (gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.MeasurementMode = enumMeasurementMode.Integrate) Then
    '                                dblAbsorbance -= mdblBlankAbsorbance
    '                            End If

    '                            nCurSamp.Abs = dblAbsorbance
    '                            dblCorrectedAbsorbance = FormatNumber(dblAbsorbance, gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfDecimalPlaces)

    '                            'Saurabh 05 June 2007
    '                            'lblCorrectedAbsorbance.Text = FormatNumber(dblAbsorbance, gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfDecimalPlaces)
    '                            'lblCorrectedAbsorbance.Text = FormatNumber(dblAbsorbance, 3)
    '                            'Saurabh 05 June 2007

    '                            nCurSamp.Conc = gobjclsStandardGraph.Get_Conc(nCurSamp.Abs, 0.0)

    '                            If (nCurSamp.Conc >= 0 And nCurSamp.Abs > -0.1) Then
    '                                nCurSamp.Used = True
    '                            End If

    '                            'if (Method->QuantData->Param.Repeat>1 || Method->QuantData->Param.ConcRepeat>1){
    '                            If (gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfStdRepeats > 1 Or gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfSampleRepeats > 1) Then
    '                                Call AddAbsRepeatSamp(nCurSamp.Abs, nCurSamp.Conc, nCurSamp.AbsRepeat)
    '                                Call CalculateAvgOfSamp(nCurSamp)
    '                            End If

    '                            If (gobjNewMethod.OperationMode = EnumOperationMode.MODE_EMMISSION) Then
    '                                nCurSamp.Abs = FormatNumber(nCurSamp.Abs, 1)
    '                            Else
    '                                nCurSamp.Abs = FormatNumber(nCurSamp.Abs, 3)
    '                            End If

    '                            'lblConcentration.Text = FormatNumber(nCurSamp.Conc, gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfDecimalPlaces) & "  ppm"

    '                        End If

    '                End Select

    '                Return dblCorrectedAbsorbance

    '            Catch ex As Exception
    '                '---------------------------------------------------------
    '                'Error Handling and logging
    '                gobjErrorHandler.ErrorDescription = ex.Message
    '                gobjErrorHandler.ErrorMessage = ex.Message
    '                gobjErrorHandler.WriteErrorLog(ex)
    '                '---------------------------------------------------------
    '            Finally
    '                '---------------------------------------------------------
    '                'Writing Execution log
    '                If CONST_CREATE_EXECUTION_LOG = 1 Then
    '                    gobjErrorHandler.WriteExecutionLog()
    '                End If
    '                '---------------------------------------------------------
    '            End Try
    '        End Function

    '        Private Sub AddAbsRepeatStd(ByVal dblAbsorbance As Double, ByVal dblConcentration As Double, _
    '                                    ByRef objAbsRepeat As Method.clsAbsRepeat)
    '            '=====================================================================
    '            ' Procedure Name        : AddAbsRepeatStd
    '            ' Parameters Passed     : None
    '            ' Returns               : None
    '            ' Purpose               : 
    '            ' Description           : 
    '            ' Assumptions           : 
    '            ' Dependencies          : 
    '            ' Author                : Mangesh Shardul
    '            ' Created               : 17-Jan-2007 03:25 pm
    '            ' Revisions             : 1
    '            '=====================================================================
    '            'void	  S4FUNC	AddAbsRepeatStd(double data, double conc, STDDATA *cur)
    '            '{
    '            ' if (cur==NULL)
    '            '	return;
    '            ' data = GetResultAccurate(data,3);
    '            ' conc =  GetResultAccurate(conc,Method->QuantData->Param.No_Decimals);

    '            ' if (cur->Data.AbsRepeat==NULL){
    '            '	cur->Data.AbsRepeat = (ABSREPEAT *) malloc(sizeof(ABSREPEAT));
    '            '	InitAbsRepeat(cur->Data.AbsRepeat);
    '            '  }
    '            ' AddAbsRepeatData(data, conc, &(cur->Data.AbsRepeat->RptDataTop));
    '            '}
    '            '****************************************************
    '            '--- CODE BY MANGESH 
    '            '****************************************************
    '            Try
    '                ''dblAbsorbance = Math.Round(dblAbsorbance, 3)
    '                ''dblConcentration = Math.Round(dblConcentration, gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfDecimalPlaces)

    '                Call InitAbsRepeat(objAbsRepeat)

    '                Call AddAbsRepeatData(dblAbsorbance, dblConcentration, objAbsRepeat.AbsRepeatData)

    '            Catch ex As Exception
    '                '---------------------------------------------------------
    '                'Error Handling and logging
    '                gobjErrorHandler.ErrorDescription = ex.Message
    '                gobjErrorHandler.ErrorMessage = ex.Message
    '                gobjErrorHandler.WriteErrorLog(ex)
    '                '---------------------------------------------------------
    '            Finally
    '                '---------------------------------------------------------
    '                'Writing Execution log
    '                If CONST_CREATE_EXECUTION_LOG = 1 Then
    '                    gobjErrorHandler.WriteExecutionLog()
    '                End If
    '                '---------------------------------------------------------
    '            End Try
    '        End Sub

    '        Private Sub AddAbsRepeatSamp(ByVal dblAbsorbance As Double, ByVal dblConcentration As Double, _
    '                                     ByRef objAbsRepeat As Method.clsAbsRepeat)
    '            '=====================================================================
    '            ' Procedure Name        : AddAbsRepeatSamp
    '            ' Parameters Passed     : None
    '            ' Returns               : None
    '            ' Purpose               : 
    '            ' Description           : 
    '            ' Assumptions           : 
    '            ' Dependencies          : 
    '            ' Author                : Mangesh Shardul
    '            ' Created               : 17-Jan-2007 03:25 pm
    '            ' Revisions             : 1
    '            '=====================================================================
    '            '{
    '            ' if (cur==NULL)
    '            '	return;
    '            ' data = GetResultAccurate(data,3);
    '            ' conc =  GetResultAccurate(conc,Method->QuantData->Param.No_Decimals);
    '            ' if (cur->Data.AbsRepeat==NULL){
    '            '	cur->Data.AbsRepeat = (ABSREPEAT *) malloc(sizeof(ABSREPEAT));
    '            '	InitAbsRepeat(cur->Data.AbsRepeat);
    '            '  }
    '            ' AddAbsRepeatData(data, conc, &(cur->Data.AbsRepeat->RptDataTop));
    '            '}
    '            '****************************************************
    '            '--- CODE BY MANGESH 
    '            '****************************************************
    '            Try
    '                'dblAbsorbance = Math.Round(dblAbsorbance, 3)
    '                'dblConcentration = Math.Round(dblConcentration, gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfDecimalPlaces)

    '                Call InitAbsRepeat(objAbsRepeat)

    '                Call AddAbsRepeatData(dblAbsorbance, dblConcentration, objAbsRepeat.AbsRepeatData)

    '            Catch ex As Exception
    '                '---------------------------------------------------------
    '                'Error Handling and logging
    '                gobjErrorHandler.ErrorDescription = ex.Message
    '                gobjErrorHandler.ErrorMessage = ex.Message
    '                gobjErrorHandler.WriteErrorLog(ex)
    '                '---------------------------------------------------------
    '            Finally
    '                '---------------------------------------------------------
    '                'Writing Execution log
    '                If CONST_CREATE_EXECUTION_LOG = 1 Then
    '                    gobjErrorHandler.WriteExecutionLog()
    '                End If
    '                '---------------------------------------------------------
    '            End Try
    '        End Sub

    '        Private Sub InitAbsRepeat(ByRef AbsRpt As Method.clsAbsRepeat)
    '            '=====================================================================
    '            ' Procedure Name        : InitAbsRepeat
    '            ' Parameters Passed     : None
    '            ' Returns               : None
    '            ' Purpose               : 
    '            ' Description           : 
    '            ' Assumptions           : 
    '            ' Dependencies          : 
    '            ' Author                : Mangesh Shardul
    '            ' Created               : 17-Jan-2007 03:25 pm
    '            ' Revisions             : 1
    '            '=====================================================================
    '            'void(InitAbsRepeat(ABSREPEAT * AbsRpt))
    '            '{
    '            '   if (AbsRpt==NULL)
    '            '	    return;
    '            '   AbsRpt->RptDataTop=NULL;
    '            '   AbsRpt->Data.TotData[0]=AbsRpt->Data.TotData[1]=(double)0.0;
    '            '   AbsRpt->Data.Zavg[0]=AbsRpt->Data.Zavg[1] =(double)0.0;
    '            '   AbsRpt->Data.CV[0]=AbsRpt->Data.CV[1] =(double)0.0;
    '            '   AbsRpt->Data.Zsigma[0]=AbsRpt->Data.Zsigma[1] =(double)0.0;
    '            '   AbsRpt->Data.Var[0]=AbsRpt->Data.Var[1] =(double)0.0;
    '            '   AbsRpt->Data.Min[0]=AbsRpt->Data.Min[1] =(double)0.0;
    '            '   AbsRpt->Data.Max[0]=AbsRpt->Data.Max[1] =(double)0.0;
    '            '}
    '            '****************************************************
    '            '--- CODE BY MANGESH 
    '            '****************************************************
    '            Try
    '                If IsNothing(AbsRpt) Then
    '                    AbsRpt = New Method.clsAbsRepeat

    '                    AbsRpt.AbsRepeatData = Nothing

    '                    AbsRpt.BasicStat.TotData(0) = 0.0
    '                    AbsRpt.BasicStat.TotData(1) = 0.0

    '                    AbsRpt.BasicStat.ZAvg(0) = 0.0
    '                    AbsRpt.BasicStat.ZAvg(1) = 0.0

    '                    AbsRpt.BasicStat.CV(0) = 0.0
    '                    AbsRpt.BasicStat.CV(1) = 0.0

    '                    AbsRpt.BasicStat.ZSigma(0) = 0.0
    '                    AbsRpt.BasicStat.ZSigma(1) = 0.0

    '                    AbsRpt.BasicStat.Var(0) = 0.0
    '                    AbsRpt.BasicStat.Var(1) = 0.0

    '                    AbsRpt.BasicStat.Min(0) = 0.0
    '                    AbsRpt.BasicStat.Min(1) = 0.0

    '                    AbsRpt.BasicStat.Max(0) = 0.0
    '                    AbsRpt.BasicStat.Max(1) = 0.0

    '                End If

    '            Catch ex As Exception
    '                '---------------------------------------------------------
    '                'Error Handling and logging
    '                gobjErrorHandler.ErrorDescription = ex.Message
    '                gobjErrorHandler.ErrorMessage = ex.Message
    '                gobjErrorHandler.WriteErrorLog(ex)
    '                '---------------------------------------------------------
    '            Finally
    '                '---------------------------------------------------------
    '                'Writing Execution log
    '                If CONST_CREATE_EXECUTION_LOG = 1 Then
    '                    gobjErrorHandler.WriteExecutionLog()
    '                End If
    '                '---------------------------------------------------------
    '            End Try
    '        End Sub

    '        Private Sub AddAbsRepeatData(ByVal dblAbsorbance As Double, ByVal dblConcentration As Double, _
    '                                     ByRef objAbsRepeatDataCollection As Method.clsAbsRepeatDataCollection)
    '            '=====================================================================
    '            ' Procedure Name        : AddAbsRepeatData
    '            ' Parameters Passed     : None
    '            ' Returns               : None
    '            ' Purpose               : 
    '            ' Description           : 
    '            ' Assumptions           : 
    '            ' Dependencies          : 
    '            ' Author                : Mangesh Shardul
    '            ' Created               : 17-Jan-2007 03:25 pm
    '            ' Revisions             : 1
    '            '=====================================================================
    '            '{
    '            'ABSREPEATDATA  *tempk=NULL;
    '            'ABSREPEATDATA  *cur=NULL;

    '            ' tempk = (ABSREPEATDATA*) malloc(sizeof(ABSREPEATDATA));
    '            ' if (tempk !=NULL){
    '            '  cur = GoAbsRepeatBottom(*Top);
    '            '  tempk->Abs=abs;
    '            '  tempk->Conc=conc;
    '            '  tempk->next=NULL;
    '            '  If (cur! = NULL) Then
    '            '    tempk->next=cur->next;
    '            '  if (*Top==NULL)
    '            '	 *Top= tempk;
    '            '  Else
    '            '    cur->next=tempk;
    '            '  cur = tempk;
    '            ' }
    '            '}
    '            '******************************************************************
    '            '---CODE BY MANGESH
    '            '******************************************************************
    '            Dim objAbsRepeatData As Method.clsAbsRepeatData

    '            Try
    '                objAbsRepeatData = New Method.clsAbsRepeatData
    '                objAbsRepeatData.Abs = dblAbsorbance
    '                objAbsRepeatData.Concentration = dblConcentration
    '                objAbsRepeatData.Used = True

    '                If Not IsNothing(objAbsRepeatDataCollection) Then
    '                    objAbsRepeatDataCollection.Add(objAbsRepeatData)
    '                Else
    '                    objAbsRepeatDataCollection = New Method.clsAbsRepeatDataCollection
    '                    objAbsRepeatDataCollection.Add(objAbsRepeatData)
    '                End If

    '            Catch ex As Exception
    '                '---------------------------------------------------------
    '                'Error Handling and logging
    '                gobjErrorHandler.ErrorDescription = ex.Message
    '                gobjErrorHandler.ErrorMessage = ex.Message
    '                gobjErrorHandler.WriteErrorLog(ex)
    '                '---------------------------------------------------------
    '            Finally
    '                '---------------------------------------------------------
    '                'Writing Execution log
    '                If CONST_CREATE_EXECUTION_LOG = 1 Then
    '                    gobjErrorHandler.WriteExecutionLog()
    '                End If
    '                '---------------------------------------------------------
    '            End Try
    '        End Sub

    '        Private Sub CalculateAvgOfStd(ByRef objStandard As Method.clsAnalysisStdParameters)
    '            '=====================================================================
    '            ' Procedure Name        : CalculateAvgOfStd 
    '            ' Parameters Passed     : Reference to the clsAnalysisStdParameters
    '            ' Returns               : None
    '            ' Purpose               : 
    '            ' Description           : 
    '            ' Assumptions           : 
    '            ' Dependencies          : 
    '            ' Author                : Mangesh Shardul
    '            ' Created               : 17-Jan-2007 03:25 pm
    '            ' Revisions             : 1
    '            '=====================================================================
    '            '{
    '            ' if (mobjCurrentStandard==NULL || mobjCurrentStandard->Data.AbsRepeat==NULL)
    '            '	return;
    '            ' CalculateBasicStats(mobjCurrentStandard->Data.AbsRepeat);
    '            ' mobjCurrentStandard->Data.Abs = mobjCurrentStandard->Data.AbsRepeat->Data.Zavg[0];
    '            '}
    '            '***********************************************************************
    '            '---CODE BY MANGESH
    '            '***********************************************************************
    '            Try
    '                If IsNothing(objStandard) Or IsNothing(objStandard.AbsRepeat) Then
    '                    Return
    '                End If

    '                If clsBasicStatistics.CalculateBasicStats(objStandard.AbsRepeat) Then
    '                    objStandard.Abs = objStandard.AbsRepeat.BasicStat.ZAvg(0)
    '                End If

    '            Catch ex As Exception
    '                '---------------------------------------------------------
    '                'Error Handling and logging
    '                gobjErrorHandler.ErrorDescription = ex.Message
    '                gobjErrorHandler.ErrorMessage = ex.Message
    '                gobjErrorHandler.WriteErrorLog(ex)
    '                '---------------------------------------------------------
    '            Finally
    '                '---------------------------------------------------------
    '                'Writing Execution log
    '                If CONST_CREATE_EXECUTION_LOG = 1 Then
    '                    gobjErrorHandler.WriteExecutionLog()
    '                End If
    '                '---------------------------------------------------------
    '            End Try
    '        End Sub

    '        Private Sub CalculateAvgOfSamp(ByRef objSample As Method.clsAnalysisSampleParameters)
    '            '=====================================================================
    '            ' Procedure Name        : CalculateAvgOfSamp
    '            ' Parameters Passed     : Reference of clsAnalysisSampleParameters object
    '            ' Returns               : None
    '            ' Purpose               : 
    '            ' Description           : 
    '            ' Assumptions           : 
    '            ' Dependencies          : 
    '            ' Author                : Mangesh Shardul
    '            ' Created               : 17-Jan-2007 03:25 pm
    '            ' Revisions             : 1
    '            '=====================================================================
    '            'void S4FUNC CalculateAvgOfSamp(SAMPDATA *mobjCurrentSample)
    '            '{
    '            '   if (mobjCurrentSample==NULL || mobjCurrentSample->Data.AbsRepeat==NULL)
    '            '	    return;
    '            '   CalculateBasicStats(mobjCurrentSample->Data.AbsRepeat);
    '            '   mobjCurrentSample->Data.Abs = mobjCurrentSample->Data.AbsRepeat->Data.Zavg[0];
    '            '}
    '            '********************************************************************
    '            '---CODE BY MANGESH
    '            '********************************************************************
    '            Try
    '                If IsNothing(objSample) Or IsNothing(objSample.AbsRepeat) Then
    '                    Return
    '                End If

    '                If clsBasicStatistics.CalculateBasicStats(objSample.AbsRepeat) Then
    '                    objSample.Abs = objSample.AbsRepeat.BasicStat.ZAvg(0)
    '                End If

    '            Catch ex As Exception
    '                '---------------------------------------------------------
    '                'Error Handling and logging
    '                gobjErrorHandler.ErrorDescription = ex.Message
    '                gobjErrorHandler.ErrorMessage = ex.Message
    '                gobjErrorHandler.WriteErrorLog(ex)
    '                '---------------------------------------------------------
    '            Finally
    '                '---------------------------------------------------------
    '                'Writing Execution log
    '                If CONST_CREATE_EXECUTION_LOG = 1 Then
    '                    gobjErrorHandler.WriteExecutionLog()
    '                End If
    '                '---------------------------------------------------------
    '            End Try
    '        End Sub

    '        Private Function GetPrevStd(ByVal objStandardsCollection As Method.clsAnalysisStdParametersCollection, _
    '                                    ByVal objCurrentStandard As Method.clsAnalysisStdParameters) As Method.clsAnalysisStdParameters
    '            '=====================================================================
    '            ' Procedure Name        : GetPrevStd
    '            ' Parameters Passed     : StandardDataCollection and Current Standard
    '            ' Returns               : Previous Standard
    '            ' Purpose               : 
    '            ' Description           : 
    '            ' Assumptions           : 
    '            ' Dependencies          : 
    '            ' Author                : Mangesh Shardul
    '            ' Created               : 17-Jan-2007 03:25 pm
    '            ' Revisions             : 1
    '            '=====================================================================
    '            '***************************************************************
    '            '--- ORIGINAL 16-bit CODE
    '            '***************************************************************
    '            'STDDATA *S4FUNC GetPrevStd(STDDATA *StdTop, STDDATA *CurStd)
    '            '{
    '            '   STDDATA	*tempk=NULL;
    '            '   tempk = StdTop;
    '            '   if (CurStd == StdTop)
    '            '	    return tempk;
    '            '   while(tempk!=NULL)
    '            '   {
    '            '	    if (tempk->next==CurStd)
    '            '	        break;
    '            '       tempk=tempk->next;
    '            '   }
    '            '   return tempk;
    '            '}
    '            '***************************************************************
    '            Dim intCounter As Integer

    '            Try
    '                For intCounter = 0 To objStandardsCollection.Count - 1
    '                    If objStandardsCollection.item(intCounter) Is objCurrentStandard Then
    '                        Exit For
    '                    End If
    '                Next intCounter

    '                '---Returns the Previous Standard from Standard Collection.
    '                If intCounter = 0 Then
    '                    Return objStandardsCollection.item(0).Clone()
    '                Else
    '                    Return objStandardsCollection.item(intCounter - 1).Clone()
    '                End If

    '            Catch ex As Exception
    '                '---------------------------------------------------------
    '                'Error Handling and logging
    '                gobjErrorHandler.ErrorDescription = ex.Message
    '                gobjErrorHandler.ErrorMessage = ex.Message
    '                gobjErrorHandler.WriteErrorLog(ex)
    '                '---------------------------------------------------------
    '            Finally
    '                '---------------------------------------------------------
    '                'Writing Execution log
    '                If CONST_CREATE_EXECUTION_LOG = 1 Then
    '                    gobjErrorHandler.WriteExecutionLog()
    '                End If
    '                '---------------------------------------------------------
    '            End Try
    '        End Function

    '        Private Function GetPrevSamp(ByVal objSamplesCollection As Method.clsAnalysisSampleParametersCollection, _
    '                                     ByVal objCurrentSample As Method.clsAnalysisSampleParameters) As Method.clsAnalysisSampleParameters
    '            '=====================================================================
    '            ' Procedure Name        : GetPrevSamp
    '            ' Parameters Passed     : SampleDataCollection and Current Sample
    '            ' Returns               : Previous Sample
    '            ' Purpose               : 
    '            ' Description           : 
    '            ' Assumptions           : 
    '            ' Dependencies          : 
    '            ' Author                : Mangesh Shardul
    '            ' Created               : 17-Jan-2007 03:25 pm
    '            ' Revisions             : 1
    '            '=====================================================================
    '            '***************************************************************
    '            '--- ORIGINAL 16-bit CODE
    '            '***************************************************************
    '            'SAMPDATA	*S4FUNC GetPrevSamp(SAMPDATA *SampTop, SAMPDATA *CurSamp)
    '            '{
    '            '   SAMPDATA	*tempk=NULL;
    '            '   tempk =  SampTop;
    '            '   if (CurSamp==SampTop)
    '            '	    return tempk;
    '            '   while(tempk!=NULL)
    '            '   {
    '            '	    if (tempk->next==CurSamp)
    '            '		    break;
    '            '	    tempk=tempk->next;
    '            '   }
    '            '   return tempk;
    '            '}
    '            '***************************************************************
    '            Dim intCounter As Integer

    '            Try
    '                For intCounter = 0 To objSamplesCollection.Count - 1
    '                    If objSamplesCollection.item(intCounter) Is objCurrentSample Then
    '                        Exit For
    '                    End If
    '                Next intCounter

    '                '---Returns the Previous Sample from Sample Collection.
    '                If intCounter = 0 Then
    '                    Return objSamplesCollection.item(0).Clone()
    '                Else
    '                    Return objSamplesCollection.item(intCounter - 1).Clone()
    '                End If

    '            Catch ex As Exception
    '                '---------------------------------------------------------
    '                'Error Handling and logging
    '                gobjErrorHandler.ErrorDescription = ex.Message
    '                gobjErrorHandler.ErrorMessage = ex.Message
    '                gobjErrorHandler.WriteErrorLog(ex)
    '                '---------------------------------------------------------
    '            Finally
    '                '---------------------------------------------------------
    '                'Writing Execution log
    '                If CONST_CREATE_EXECUTION_LOG = 1 Then
    '                    gobjErrorHandler.WriteExecutionLog()
    '                End If
    '                '---------------------------------------------------------
    '            End Try
    '        End Function

    '        Private Function OnViewResults() As Boolean
    '            '=====================================================================
    '            ' Procedure Name        : OnViewResults
    '            ' Parameters Passed     : None
    '            ' Returns               : True or false
    '            ' Purpose               : 
    '            ' Description           : 
    '            ' Assumptions           : 
    '            ' Dependencies          : 
    '            ' Author                : Mangesh Shardul
    '            ' Created               : 01-Feb-2007 07:50 pm
    '            ' Revisions             : 1
    '            '=====================================================================

    '            '*********************************************************
    '            '---- ORIGINAL CODE
    '            '*********************************************************
    '            'void	OnViewResults(HWND hpar)
    '            '{
    '            '   DLGPROC  skp1;
    '            '	if (Method->QuantData==NULL)
    '            '	    return;
    '            '	if (GetTotStds(Method->QuantData->StdTopData, TRUE)>0)
    '            '	{
    '            '		skp1 =(DLGPROC) MakeProcInstance((DLGPROC) ViewResultsProc,hInst);
    '            '		DialogBox(hInst,"SHOWRESULTS", hpar, skp1);
    '            '		FreeProcInstance(skp1);
    '            '	}
    '            '   Else
    '            '	    Gerror_message_new("No Standards", "STANDARD CURVE");
    '            '}
    '            '*********************************************************
    '            Dim objfrmViewResults As frmViewResults

    '            Try
    '                'DLGPROC  skp1;
    '                'if (Method->QuantData==NULL)
    '                '   return;
    '                'end if
    '                If IsNothing(gobjNewMethod.QuantitativeDataCollection) Then
    '                    Return False
    '                End If

    '                If (clsStandardGraph.GetTotStds(gobjNewMethod.QuantitativeDataCollection(mintRunNumberIndex).StandardDataCollection, True) > 0) Then
    '                    'skp1 =(DLGPROC) MakeProcInstance((DLGPROC) ViewResultsProc,hInst);
    '                    'DialogBox(hInst,"SHOWRESULTS", hpar, skp1);
    '                    'FreeProcInstance(skp1);
    '                    objfrmViewResults = New frmViewResults(True, 0, 0, gobjNewMethod)
    '                    objfrmViewResults.ShowDialog()
    '                    objfrmViewResults.Close()
    '                    objfrmViewResults.Dispose()
    '                    objfrmViewResults = Nothing
    '                Else
    '                    Call gobjMessageAdapter.ShowMessage(constNoStandards)
    '                    Call Application.DoEvents()
    '                End If

    '                Return True

    '            Catch ex As Exception
    '                '---------------------------------------------------------
    '                'Error Handling and logging
    '                gobjErrorHandler.ErrorDescription = ex.Message
    '                gobjErrorHandler.ErrorMessage = ex.Message
    '                gobjErrorHandler.WriteErrorLog(ex)
    '                '---------------------------------------------------------
    '            Finally
    '                '---------------------------------------------------------
    '                'Writing Execution log
    '                If CONST_CREATE_EXECUTION_LOG = 1 Then
    '                    gobjErrorHandler.WriteExecutionLog()
    '                End If
    '                '---------------------------------------------------------
    '            End Try
    '        End Function

    '        Private Sub StoreCalculateDisplayQuantValueUvMode(ByVal dblAbsorbance As Double)
    '            '=====================================================================
    '            ' Procedure Name        : StoreCalculateDisplayQuantValueUvMode
    '            ' Parameters Passed     : Absorbance value in UV mode
    '            ' Returns               : None
    '            ' Purpose               : To store, calculate and Display Quantitative
    '            '                         value in UV Mode
    '            ' Description           : 
    '            ' Assumptions           : 
    '            ' Dependencies          : 
    '            ' Author                : Mangesh Shardul
    '            ' Created               : 23-Apr-2007 11:45 pm
    '            ' Revisions             : 1
    '            '=====================================================================
    '            '******************************************************************
    '            '---- ORIGINAL CODE
    '            '******************************************************************
    '            'void	StoreCalculateDisplayQuantValueUvMode(HWND hwnd, double abs)
    '            '{
    '            '	char	str[40]="";
    '            '	abs = GetValConvertedTo(abs, Method->Mode);
    '            '	if (SampType==BLANK)
    '            '	{
    '            '	  BlankAbs=abs;
    '            '	}
    '            '	else if (SampType==STD)
    '            '	{
    '            '		if (CurStd!=NULL){
    '            '			CurStd->Data.Abs=abs;
    '            '			GetValInString(abs, str, Method->Mode);
    '            '			SetDlgItemText(hwnd,IDC_QAVABS, str);
    '            '			CheckValidStdAbs();
    '            '			GetValInString(abs, str, Method->Mode);
    '            '			SetDlgItemText(hwnd,IDC_QCORABS, str);
    '            '			StoreResultAccurate(CurStd->Data.Conc, str, Method->QuantData->Param.No_Decimals);
    '            '			SetDlgItemText(hwnd,IDC_QCONC, str);
    '            '			CurStd->Data.Abs = GetResultAccurate(CurStd->Data.Abs, 3);
    '            '		}
    '            '	}
    '            '	else if (SampType==SAMP)
    '            '	{
    '            '       If (CurSamp! = NULL) Then
    '            '		{
    '            '			GetValInString(abs, str, Method->Mode);
    '            '			SetDlgItemText(hwnd,IDC_QAVABS, str);
    '            '			CurSamp->Data.Abs=abs;
    '            '			GetValInString(abs, str, Method->Mode);
    '            '			SetDlgItemText(hwnd,IDC_QCORABS, str);
    '            '			CurSamp->Data.Conc = Get_Conc(CurSamp->Data.Abs, 0.0);
    '            '			if (CurSamp->Data.Conc>0 && CurSamp->Data.Abs>-0.1)
    '            '				CurSamp->Data.Used=TRUE;
    '            '			CurSamp->Data.Abs = GetResultAccurate(CurSamp->Data.Abs, 3);
    '            '			StoreResultAccurate(CurSamp->Data.Conc, str, Method->QuantData->Param.No_Decimals);
    '            '			strcat(str, "   ppm");
    '            '			SetDlgItemText(hwnd,IDC_QCONC, str);
    '            '		}
    '            '	}
    '            '}
    '            '******************************************************************
    '            'char	str[40]="";
    '            Try
    '                'dblAbsorbance = gfuncGetValConvertedTo(dblAbsorbance, Method.Mode)

    '                If (SampleType = ClsAAS203.enumSampleType.BLANK) Then
    '                    mdblBlankAbsorbance = dblAbsorbance

    '                ElseIf (SampleType = ClsAAS203.enumSampleType.STANDARD) Then
    '                    If Not IsNothing(mobjCurrentStandard) Then
    '                        'CurStd->Data.Abs=abs;
    '                        mobjCurrentStandard.Abs = dblAbsorbance

    '                        'GetValInString(abs, str, Method->Mode);
    '                        'SetDlgItemText(hwnd,IDC_QAVABS, str);

    '                        'Saurabh 05 June 2007
    '                        'lblAverageAbsorbance.Text = FormatNumber(abs, gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfDecimalPlaces)
    '                        'lblAverageAbsorbance.Text = FormatNumber(dblAbsorbance, 3)
    '                        'Saurabh 05 June 2007


    '                        Call CheckValidStdAbs()

    '                        'GetValInString(abs, str, Method->Mode);
    '                        'SetDlgItemText(hwnd,IDC_QCORABS, str);

    '                        'Saurabh 05 June 2007
    '                        'lblCorrectedAbsorbance.Text = FormatNumber(dblAbsorbance, gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfDecimalPlaces)
    '                        'lblCorrectedAbsorbance.Text = FormatNumber(dblAbsorbance, 3)
    '                        'Saurabh 05 June 2007

    '                        'StoreResultAccurate(CurStd->Data.Conc, str, Method->QuantData->Param.No_Decimals);
    '                        'SetDlgItemText(hwnd,IDC_QCONC, str);
    '                        'Saurabh To format the concentration value upto 2 decimal places 20.07.07
    '                        'lblConcentration.Text = FormatNumber(mobjCurrentStandard.Concentration, 2)
    '                        'Saurabh To format the concentration value upto 2 decimal places 20.07.07
    '                        'CurStd->Data.Abs = GetResultAccurate(CurStd->Data.Abs, 3);

    '                    End If

    '                ElseIf (SampleType = ClsAAS203.enumSampleType.SAMPLE) Then
    '                    If Not IsNothing(mobjCurrentSample) Then
    '                        'GetValInString(abs, str, Method->Mode);
    '                        'SetDlgItemText(hwnd,IDC_QAVABS, str);

    '                        'Saurabh 05 June 2007
    '                        'lblAverageAbsorbance.Text = FormatNumber(abs, gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfDecimalPlaces)
    '                        'lblAverageAbsorbance.Text = FormatNumber(dblAbsorbance, 3)
    '                        'Saurabh 05 June 2007

    '                        'CurSamp->Data.Abs=abs;
    '                        mobjCurrentSample.Abs = dblAbsorbance

    '                        'GetValInString(abs, str, Method->Mode);
    '                        'SetDlgItemText(hwnd,IDC_QCORABS, str);

    '                        'Saurabh 05 June 2007
    '                        'lblCorrectedAbsorbance.Text = FormatNumber(dblAbsorbance, gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfDecimalPlaces)
    '                        'lblCorrectedAbsorbance.Text = FormatNumber(dblAbsorbance, 3)
    '                        'Saurabh 05 June 2007

    '                        'CurSamp->Data.Conc = Get_Conc(CurSamp->Data.Abs, 0.0);
    '                        mobjCurrentSample.Conc = gobjclsStandardGraph.Get_Conc(mobjCurrentSample.Abs, 0.0)

    '                        'if (CurSamp->Data.Conc>0 && CurSamp->Data.Abs>-0.1)
    '                        '	CurSamp->Data.Used=TRUE;
    '                        'end if
    '                        If mobjCurrentSample.Conc > 0 And mobjCurrentSample.Abs > -0.1 Then
    '                            mobjCurrentSample.Used = True
    '                        End If

    '                        'CurSamp->Data.Abs = GetResultAccurate(CurSamp->Data.Abs, 3);

    '                        'StoreResultAccurate(CurSamp->Data.Conc, str, Method->QuantData->Param.No_Decimals);
    '                        'strcat(str, "   ppm");
    '                        'SetDlgItemText(hwnd,IDC_QCONC, str);
    '                        'Saurabh To format the concentration value upto 2 decimal places 20.07.07
    '                        'lblConcentration.Text = FormatNumber(mobjCurrentSample.Conc, 2) & "  ppm"
    '                        'Saurabh To format the concentration value upto 2 decimal places 20.07.07

    '                    End If

    '                End If

    '            Catch ex As Exception
    '                '---------------------------------------------------------
    '                'Error Handling and logging
    '                gobjErrorHandler.ErrorDescription = ex.Message
    '                gobjErrorHandler.ErrorMessage = ex.Message
    '                gobjErrorHandler.WriteErrorLog(ex)
    '                '---------------------------------------------------------
    '            Finally
    '                '---------------------------------------------------------
    '                'Writing Execution log
    '                If CONST_CREATE_EXECUTION_LOG = 1 Then
    '                    gobjErrorHandler.WriteExecutionLog()
    '                End If
    '                '---------------------------------------------------------
    '            End Try
    '        End Sub

    '#End Region

    '#Region " Public Functions "

    '        Public Sub StartNewAnalysis()
    '            '=====================================================================
    '            ' Procedure Name        : StartNewAnalysis
    '            ' Parameters Passed     : None
    '            ' Returns               : None
    '            ' Purpose               : 
    '            ' Description           : 
    '            ' Assumptions           : 
    '            ' Dependencies          : 
    '            ' Author                : Mangesh Shardul
    '            ' Created               : 20-Feb-2007 03:00 pm
    '            ' Revisions             : 1
    '            '=====================================================================
    '            Dim intValid As Integer

    '            Try
    '                mController = New clsBgThread(Me)
    '                Call mobjBgReadData.Initialize(mController)

    '                mstrAspirationMessage = "Click Start button to Start Analysis."
    '                gobjclsStandardGraph = New clsStandardGraph
    '                intValid = CheckMethod()
    '                If (intValid = 2) Then
    '                    Call InitAnalysis()
    '                End If
    '                mblnIsAnalysisStarted = False

    '                Call NewAnalysis_Clicked(btnNewAnalysis, EventArgs.Empty)

    '                'Enable_Disable_Filter(False)
    '                'tlbbtnSaveReport.Enabled = False
    '                'btnEditData.Enabled = False

    '                mintAspirationTimerCounter = 0

    '                tmrAspirationMsg.Enabled = True

    '            Catch ex As Exception
    '                '---------------------------------------------------------
    '                'Error Handling and logging
    '                gobjErrorHandler.ErrorDescription = ex.Message
    '                gobjErrorHandler.ErrorMessage = ex.Message
    '                gobjErrorHandler.WriteErrorLog(ex)
    '                '---------------------------------------------------------
    '            Finally
    '                '---------------------------------------------------------
    '                'Writing Execution log
    '                If CONST_CREATE_EXECUTION_LOG = 1 Then
    '                    gobjErrorHandler.WriteExecutionLog()
    '                End If
    '                '---------------------------------------------------------
    '            End Try
    '        End Sub

    '        Public Sub CheckAnaButtons()
    '            '=====================================================================
    '            ' Procedure Name        : CheckAnaButtons
    '            ' Parameters Passed     : None
    '            ' Returns               : None
    '            ' Purpose               : To set buttons enable/disable, and show the 
    '            '                           messages accordingly.
    '            ' Description           : 
    '            ' Assumptions           : 
    '            ' Dependencies          : 
    '            ' Author                : Mangesh Shardul
    '            ' Created               : 15-Dec-2006
    '            ' Revisions             : 1
    '            '=====================================================================

    '            '****************************************************************************************
    '            'AAS 16-Bit Software Code
    '            '****************************************************************************************
    '            ''void	CheckAnaButtons(HWND hwnd)
    '            ''{
    '            '' if (Started){
    '            ''	ANALYSIS = TRUE;
    '            ''	SetShortHelp("", FALSE);
    '            ''	SetShortHelp(" Click End Analysis button to Stop the Analysis", TRUE);
    '            ''//	EnableWindow(GetDlgItem(hwnd, IDC_QAREPORT),FALSE);
    '            ''	}
    '            '' else{
    '            ''	SetShortHelp(" Click START button to start Analysis", TRUE);
    '            ''//	EnableWindow(GetDlgItem(hwnd, IDC_QAREPORT),TRUE);
    '            ''	ANALYSIS = FALSE;
    '            ''	}
    '            ''  //---mdf by sk on 29/2/2000 for autosampler
    '            ''  If (Autosampler & Started) Then
    '            ''	 EnableWindow(GetDlgItem(hwnd, IDC_QAREAD), FALSE);
    '            ''  else   //--mdf by sk on 29/2/2000 for autosampler
    '            ''// EnableWindow(GetDlgItem(hwnd, IDC_QAREAD), Started);
    '            '' EnableWindow(GetDlgItem(hwnd, IDC_QAREAD), Started);
    '            '' EnableWindow(GetDlgItem(hwnd, IDC_QANEXT),Started);
    '            '' EnableWindow(GetDlgItem(hwnd, IDC_BLANK),Started);
    '            '' EnableWindow(GetDlgItem(hwnd, IDC_QARPT),Started);
    '            '' EnableWindow(GetDlgItem(hwnd, IDC_QANEW),Started);
    '            '' EnableWindow(GetDlgItem(hwnd, IDC_QASAMP),Started);
    '            ''}
    '            '****************************************************************************************
    '            Try
    '                If (mblnIsAnalysisStarted) Then
    '                    ANALYSIS = True
    '                    '---Show Blinking Message
    '                    Call Aspirate()
    '                Else
    '                    ANALYSIS = False
    '                End If

    '                If (mblnIsAutosampler And mblnIsAnalysisStarted) Then
    '                    btnReadData.Enabled = False
    '                Else
    '                    btnReadData.Enabled = mblnIsAnalysisStarted
    '                End If

    '                'tlbbtnNextAnalysis.Enabled = mblnIsAnalysisStarted
    '                'tlbbtnBlankAnalysis.Enabled = mblnIsAnalysisStarted
    '                'tlbbtnRepeatLastAnalysis.Enabled = mblnIsAnalysisStarted
    '                'tlbbtnNewAnalysis.Enabled = mblnIsAnalysisStarted

    '                'btnNextAnalysis.Enabled = mblnIsAnalysisStarted
    '                'btnBlankAnalysis.Enabled = mblnIsAnalysisStarted
    '                'btnRepeatLast.Enabled = mblnIsAnalysisStarted
    '                btnNewAnalysis.Enabled = mblnIsAnalysisStarted

    '            Catch ex As Exception
    '                '---------------------------------------------------------
    '                'Error Handling and logging
    '                gobjErrorHandler.ErrorDescription = ex.Message
    '                gobjErrorHandler.ErrorMessage = ex.Message
    '                gobjErrorHandler.WriteErrorLog(ex)
    '                '---------------------------------------------------------
    '            Finally
    '                '---------------------------------------------------------
    '                'Writing Execution log
    '                If CONST_CREATE_EXECUTION_LOG = 1 Then
    '                    gobjErrorHandler.WriteExecutionLog()
    '                End If
    '                '---------------------------------------------------------
    '            End Try
    '        End Sub

    '        Public Sub CheckInstrumentOptimisation()
    '            '=====================================================================
    '            ' Procedure Name        : CheckInstrumentOptimisation
    '            ' Parameters Passed     : None
    '            ' Returns               : None
    '            ' Purpose               : To check and perform Instrument Optimization
    '            ' Description           : Finds analytical OR Emmision Peak
    '            ' Assumptions           : 
    '            ' Dependencies          : 
    '            ' Author                : Mangesh Shardul
    '            ' Created               : 01.12.06
    '            ' Revisions             : 
    '            '=====================================================================
    '            '***************************************************************
    '            '--- ORIGINAL CODE 
    '            '***************************************************************
    '            ''void	CheckInstrumentOptimisation(HWND hwnd)
    '            ''{
    '            ''char line1[20]="";
    '            ''if (Method){
    '            ''  if (Method->Mode==MODE_UVABS &&  Method->Aas.Wv !=Get_Cur_Wv())
    '            ''	    Method->Aas.OptimseFlag=FALSE;
    '            ''  if (!Method->Aas.OptimseFlag){
    '            ''	    if ((Method->Mode==MODE_AA || Method->Mode==MODE_AABGC ||
    '            ''			 Method->Mode==MODE_SPECT)
    '            ''		    &&  (Method->Aas.LampNo>=0 && Method->Aas.LampNo<=5) )
    '            ''	    {
    '            ''	        ResetAnaMode(Method->Aas.LampNo);
    '            ''		    Method->Aas.OptimseFlag=Find_Analytical_Peak(hwnd, Method->Aas.LampNo);
    '            ''	    }
    '            ''	    else if (Method->Mode==MODE_EMISSION)
    '            ''	        Method->Aas.OptimseFlag=Find_Emmission_Peak(hwnd);
    '            ''	    else if (Method->Mode==MODE_UVABS)
    '            ''	        SetRest_uvs_Condn(hwnd, Method->Aas.Wv, TRUE, 87, 284);
    '            ''  }
    '            ''}
    '            ''sprintf(line1,"%0.2f nm",Get_Cur_Wv());
    '            ''SetWindowText(GetDlgItem(hwnd,IDC_UVWV),line1);
    '            ''}
    '            '***************************************************************
    '            Dim dblSelectedWavelength As Double
    '            Dim intRowCounter As Integer
    '            Dim intInstrumentIndex As Integer

    '            Try
    '                tmrAspirationMsg.Enabled = False
    '                gobjMain.mobjController.Cancel()
    '                Application.DoEvents()
    '                'dblSelectedWavelength = gfuncGetSelectedUVElementWavelength(gobjNewMethod.InstrumentCondition)
    '                If Not IsNothing(gobjNewMethod) Then

    '                    '---Gets Current Wavelength from Instrument.
    '                    If (gobjNewMethod.OperationMode = EnumOperationMode.MODE_AA Or _
    '                                  gobjNewMethod.OperationMode = EnumOperationMode.MODE_AABGC Or _
    '                                  gobjNewMethod.OperationMode = EnumOperationMode.MODE_SPECT Or _
    '                                  gobjNewMethod.OperationMode = EnumOperationMode.MODE_EMMISSION) Then
    '                        Call gobjCommProtocol.funcGet_Current_Wv(gobjInst.WavelengthCur)
    '                    End If

    '                    '---Assign the Lamp Number as Turret Number as Both are same
    '                    gobjNewMethod.InstrumentCondition.LampNumber = gobjNewMethod.InstrumentCondition.TurretNumber

    '                    If Not IsNothing(gobjNewMethod.InstrumentCondition) Then
    '                        If (gobjNewMethod.OperationMode = EnumOperationMode.MODE_UVABS) Then
    '                            dblSelectedWavelength = gfuncGetSelectedUVElementWavelength(gobjNewMethod.InstrumentCondition)
    '                        Else
    '                            dblSelectedWavelength = gfuncGetSelectedElementWavelength(gobjNewMethod.InstrumentCondition)
    '                        End If

    '                        If (gobjNewMethod.OperationMode = EnumOperationMode.MODE_UVABS And _
    '                                dblSelectedWavelength <> gobjInst.WavelengthCur) Then
    '                            gobjNewMethod.InstrumentCondition.IsOptimize = False
    '                        End If

    '                        If Not (gobjNewMethod.InstrumentCondition.IsOptimize) Then
    '                            If ((gobjNewMethod.OperationMode = EnumOperationMode.MODE_AA Or _
    '                                  gobjNewMethod.OperationMode = EnumOperationMode.MODE_AABGC Or _
    '                                  gobjNewMethod.OperationMode = EnumOperationMode.MODE_SPECT) _
    '                                  And _
    '                                  (gobjNewMethod.InstrumentCondition.LampNumber >= 1 And _
    '                                   gobjNewMethod.InstrumentCondition.LampNumber <= 6)) Then

    '                                Call ResetAnaMode(gobjNewMethod.InstrumentCondition.LampNumber)

    '                                '----Finds the Analytical Peak ...
    '                                gobjNewMethod.InstrumentCondition.IsOptimize = gobjClsAAS203.Find_Analytical_Peak(gobjNewMethod.InstrumentCondition.LampNumber, mdblWvOpt, lblOptimizedWavelength)

    '                            ElseIf (gobjNewMethod.OperationMode = EnumOperationMode.MODE_EMMISSION) Then

    '                                '----Finds the Emission Peak ...
    '                                gobjNewMethod.InstrumentCondition.IsOptimize = gobjClsAAS203.Find_Emmission_Peak()

    '                            ElseIf (gobjNewMethod.OperationMode = EnumOperationMode.MODE_UVABS) Then
    '                                Dim blnUVFlag As Boolean
    '                                'Call gobjClsAAS203.funcSetRest_uvs_Condn(dblSelectedWavelength, True, lblUVWavelength, blnUVFlag)
    '                            End If
    '                        End If
    '                    End If
    '                End If

    '                ''sprintf(line1,"%0.2f nm",Get_Cur_Wv());
    '                ''SetWindowText(GetDlgItem(hwnd,IDC_UVWV),line1);
    '                gobjCommProtocol.funcGet_Current_Wv(gobjInst.WavelengthCur)
    '                lblOptimizedWavelength.Text = "Optimized Wavelength : " & gobjInst.WavelengthCur.ToString & " nm"

    '            Catch ex As Exception
    '                '---------------------------------------------------------
    '                'Error Handling and logging
    '                gobjErrorHandler.ErrorDescription = ex.Message
    '                gobjErrorHandler.ErrorMessage = ex.Message
    '                gobjErrorHandler.WriteErrorLog(ex)
    '                '---------------------------------------------------------
    '            Finally
    '                '---------------------------------------------------------
    '                'Writing Execution log
    '                If CONST_CREATE_EXECUTION_LOG = 1 Then
    '                    gobjErrorHandler.WriteExecutionLog()
    '                End If
    '                tmrAspirationMsg.Enabled = True
    '                gobjMain.mobjController.Start(gobjclsBgFlameStatus)
    '                Application.DoEvents()
    '                '---------------------------------------------------------
    '            End Try
    '        End Sub

    '#End Region

    '#Region " Aspiration Related Functions "

    '        Private Sub StartAspirationThread(ByVal intStartTime As Integer, ByVal intEndTime As Integer)
    '            Dim dtMinTime As Date
    '            Dim dtMaxTime As Date
    '            Dim intOLDStartTime As Integer
    '            Dim intOLDEndTime As Integer

    '            Try
    '                mobjBgReadData = New clsBgReadData(intStartTime, intEndTime, SampleType, mobjCurrentStandard, mobjCurrentSample)
    '                mobjBgReadData.Filter_flag = Filter_flag

    '                AddHandler mobjBgReadData.AbsorbanceValueChanged, AddressOf mobjBgReadData_AbsorbanceValueChanged
    '                AddHandler mobjBgReadData.AspirationMessageChanged, AddressOf mobjBgReadData_AspirationMessageChanged

    '                If Not (gobjNewMethod.OperationMode = EnumOperationMode.MODE_UVABS) Then
    '                    If Afirst Then
    '                        ''AASGraphAnalysis.AldysPane.XAxis.StepAuto = True
    '                        ''AASGraphAnalysis.AldysPane.XAxis.MinorStepAuto = True
    '                        ''AASGraphAnalysis.AldysPane.XAxis.PickScale(AASGraphAnalysis.XAxisMin, AASGraphAnalysis.XAxisMax)
    '                        ''AASGraphAnalysis.AldysPane.YAxis.StepAuto = True
    '                        ''AASGraphAnalysis.AldysPane.YAxis.MinorStepAuto = True
    '                        ''AASGraphAnalysis.AldysPane.YAxis.PickScale(AASGraphAnalysis.YAxisMin, AASGraphAnalysis.YAxisMax)
    '                    End If
    '                End If

    '                Call mobjBgReadData.Initialize(mController)
    '                Call mController.Start(mobjBgReadData)

    '            Catch ex As Exception
    '                '---------------------------------------------------------
    '                'Error Handling and logging
    '                gobjErrorHandler.ErrorDescription = ex.Message
    '                gobjErrorHandler.ErrorMessage = ex.Message
    '                gobjErrorHandler.WriteErrorLog(ex)
    '                '---------------------------------------------------------
    '            Finally
    '                '---------------------------------------------------------
    '                'Writing Execution log
    '                If CONST_CREATE_EXECUTION_LOG = 1 Then
    '                    gobjErrorHandler.WriteExecutionLog()
    '                End If
    '                '---------------------------------------------------------
    '            End Try
    '        End Sub

    '        Private Sub mobjBgReadData_AbsorbanceValueChanged(ByVal dblAbs As Double)
    '            Try
    '                'lblAbsorbance.Text = Format(dblAbs, "0.000")

    '            Catch ex As Exception
    '                '---------------------------------------------------------
    '                'Error Handling and logging
    '                gobjErrorHandler.ErrorDescription = ex.Message
    '                gobjErrorHandler.ErrorMessage = ex.Message
    '                gobjErrorHandler.WriteErrorLog(ex)
    '                '---------------------------------------------------------
    '            Finally
    '                '---------------------------------------------------------
    '                'Writing Execution log
    '                If CONST_CREATE_EXECUTION_LOG = 1 Then
    '                    gobjErrorHandler.WriteExecutionLog()
    '                End If
    '                '---------------------------------------------------------
    '            End Try
    '        End Sub

    '        Private Sub mobjBgReadData_AspirationMessageChanged(ByVal strNewMessage As String, ByVal blnIsBlink As Boolean)
    '            Try
    '                mstrAspirationMessage = strNewMessage
    '                mblnIsBlinkMessage = blnIsBlink

    '            Catch ex As Exception
    '                '---------------------------------------------------------
    '                'Error Handling and logging
    '                gobjErrorHandler.ErrorDescription = ex.Message
    '                gobjErrorHandler.ErrorMessage = ex.Message
    '                gobjErrorHandler.WriteErrorLog(ex)
    '                '---------------------------------------------------------
    '            Finally
    '                '---------------------------------------------------------
    '                'Writing Execution log
    '                If CONST_CREATE_EXECUTION_LOG = 1 Then
    '                    gobjErrorHandler.WriteExecutionLog()
    '                End If
    '                '---------------------------------------------------------
    '            End Try
    '        End Sub

    '        Private Sub AddInAnalysisRawData(ByVal xValue As Double, ByVal yValue As Double)
    '            '=====================================================================
    '            ' Procedure Name        : AddInAnalysisRawData
    '            ' Parameters Passed     : None
    '            ' Returns               : None
    '            ' Purpose               : 
    '            ' Description           : 
    '            ' Assumptions           : 
    '            ' Dependencies          : 
    '            ' Author                : Mangesh Shardul
    '            ' Created               : 25-Jan-2007 12:45 pm
    '            ' Revisions             : 1
    '            '=====================================================================
    '            Dim strSampleName As String
    '            Dim curveColor As Color
    '            Static Dim intStCurRepeat As Integer
    '            Try
    '                '---Add Each Raw Data in the Analysis Raw Data Collection
    '                Select Case Me.SampleType  'mobjBgReadData.SampleType
    '                    Case clsRawData.enumSampleType.BLANK
    '                        '---For Blank
    '                        If mobjBlankRawData Is Nothing Then
    '                            mobjBlankRawData = New Analysis.clsRawData
    '                        End If
    '                        mobjBlankRawData.SampleID = 0
    '                        mobjBlankRawData.SampleType = clsRawData.enumSampleType.BLANK
    '                        mobjBlankRawData.SampleName = "BLANK"
    '                        strSampleName = "BLANK"
    '                        curveColor = ClsAAS203.BLANKCOLOR
    '                        mobjBlankRawData.AddReadings(xValue, yValue)
    '                        'mobjAnalysisRawData.Add(mobjBlankRawData)

    '                    Case clsRawData.enumSampleType.STANDARD
    '                        If Not IsNothing(mobjCurrentStandard) Then
    '                            '---For Standard
    '                            If IsNothing(mobjStandardRawData) Then
    '                                mobjStandardRawData = New Analysis.clsRawData
    '                            End If

    '                            If CurRepeat > 1 Then
    '                                If Not (intStCurRepeat = CurRepeat) Then
    '                                    mobjStandardRawData = New Analysis.clsRawData
    '                                    intStCurRepeat = CurRepeat
    '                                End If
    '                            Else
    '                                intStCurRepeat = 0
    '                            End If

    '                            If (mobjStandardRawData.SampleID = mobjCurrentStandard.StdNumber) Then
    '                                mobjStandardRawData.SampleID = mobjCurrentStandard.StdNumber
    '                                mobjStandardRawData.SampleName = mobjCurrentStandard.StdName
    '                                mobjStandardRawData.SampleType = clsRawData.enumSampleType.STANDARD
    '                                strSampleName = mobjCurrentStandard.StdName
    '                                curveColor = ClsAAS203.STDCOLOR
    '                                mobjStandardRawData.AddReadings(xValue, yValue)
    '                            Else
    '                                mobjStandardRawData = New Analysis.clsRawData
    '                                mobjStandardRawData.SampleID = mobjCurrentStandard.StdNumber
    '                                mobjStandardRawData.SampleName = mobjCurrentStandard.StdName
    '                                mobjStandardRawData.SampleType = clsRawData.enumSampleType.STANDARD
    '                                strSampleName = mobjCurrentStandard.StdName
    '                                curveColor = ClsAAS203.STDCOLOR
    '                                mobjStandardRawData.AddReadings(xValue, yValue)
    '                                'mobjAnalysisRawData.Add(mobjStandardRawData)
    '                            End If

    '                        End If

    '                    Case clsRawData.enumSampleType.SAMPLE
    '                        If Not IsNothing(mobjCurrentSample) Then
    '                            '---For Sample
    '                            If IsNothing(mobjSampleRawData) Then
    '                                mobjSampleRawData = New Analysis.clsRawData
    '                            End If

    '                            If CurRepeat > 1 Then
    '                                If Not (intStCurRepeat = CurRepeat) Then
    '                                    mobjSampleRawData = New Analysis.clsRawData
    '                                    intStCurRepeat = CurRepeat
    '                                End If
    '                            Else
    '                                intStCurRepeat = 0
    '                            End If

    '                            If mobjSampleRawData.SampleID = mobjCurrentSample.SampNumber Then
    '                                mobjSampleRawData.SampleID = mobjCurrentSample.SampNumber
    '                                mobjSampleRawData.SampleName = mobjCurrentSample.SampleName
    '                                mobjSampleRawData.SampleType = clsRawData.enumSampleType.SAMPLE
    '                                strSampleName = mobjCurrentSample.SampleName
    '                                curveColor = ClsAAS203.SAMPCOLOR
    '                                mobjSampleRawData.AddReadings(xValue, yValue)
    '                            Else
    '                                mobjSampleRawData = New Analysis.clsRawData
    '                                mobjSampleRawData.SampleID = mobjCurrentSample.SampNumber
    '                                mobjSampleRawData.SampleName = mobjCurrentSample.SampleName
    '                                mobjSampleRawData.SampleType = clsRawData.enumSampleType.SAMPLE
    '                                strSampleName = mobjCurrentSample.SampleName
    '                                curveColor = ClsAAS203.SAMPCOLOR
    '                                mobjSampleRawData.AddReadings(xValue, yValue)
    '                                'mobjAnalysisRawData.Add(mobjSampleRawData)
    '                            End If
    '                        End If
    '                End Select

    '            Catch ex As Exception
    '                '---------------------------------------------------------
    '                'Error Handling and logging
    '                gobjErrorHandler.ErrorDescription = ex.Message
    '                gobjErrorHandler.ErrorMessage = ex.Message
    '                gobjErrorHandler.WriteErrorLog(ex)
    '                '---------------------------------------------------------
    '            Finally
    '                '---------------------------------------------------------
    '                'Writing Execution log
    '                If CONST_CREATE_EXECUTION_LOG = 1 Then
    '                    gobjErrorHandler.WriteExecutionLog()
    '                End If
    '                '---------------------------------------------------------
    '            End Try
    '        End Sub

    '#End Region

    '#Region " Background Thread IClient Implementation Functions "

    '        Public Sub Start(ByVal clsBgThread As BgThread.clsBgThread) Implements BgThread.Iclient.Start
    '            '=====================================================================
    '            ' Procedure Name        : Start
    '            ' Parameters Passed     : None
    '            ' Returns               : None
    '            ' Purpose               : 
    '            ' Description           : 
    '            ' Assumptions           : 
    '            ' Dependencies          : 
    '            ' Author                : Mangesh Shardul
    '            ' Created               : 17-Jan-2007 03:25 pm
    '            ' Revisions             : 1
    '            '=====================================================================
    '            Try

    '            Catch ex As Exception
    '                '---------------------------------------------------------
    '                'Error Handling and logging
    '                gobjErrorHandler.ErrorDescription = ex.Message
    '                gobjErrorHandler.ErrorMessage = ex.Message
    '                gobjErrorHandler.WriteErrorLog(ex)
    '                '---------------------------------------------------------
    '            Finally
    '                '---------------------------------------------------------
    '                'Writing Execution log
    '                If CONST_CREATE_EXECUTION_LOG = 1 Then
    '                    gobjErrorHandler.WriteExecutionLog()
    '                End If
    '                '---------------------------------------------------------
    '            End Try
    '        End Sub

    '        Public Sub Completed(ByVal Cancelled As Boolean) Implements BgThread.Iclient.Completed
    '            '=====================================================================
    '            ' Procedure Name        : Completed
    '            ' Parameters Passed     : None
    '            ' Returns               : None
    '            ' Purpose               : 
    '            ' Description           : 
    '            ' Assumptions           : 
    '            ' Dependencies          : 
    '            ' Author                : Mangesh Shardul
    '            ' Created               : 17-Jan-2007 03:25 pm
    '            ' Revisions             : 1
    '            '=====================================================================
    '            Dim dblAbsorbance As Double
    '            Dim A1() As Double = {0, 0, 0, 0, 0, 0}

    '            Try
    '                '//----- Added by Sachin Dokhale 
    '                '//----- to Save Raw Data
    '                Select Case Me.SampleType
    '                    Case ClsAAS203.enumSampleType.BLANK
    '                        If Not (mobjBlankRawData Is Nothing) Then
    '                            mobjAnalysisRawData.Add(mobjBlankRawData)
    '                            mobjBlankRawData = Nothing
    '                        End If
    '                    Case ClsAAS203.enumSampleType.SAMPLE
    '                        If Not (mobjSampleRawData Is Nothing) Then
    '                            mobjAnalysisRawData.Add(mobjSampleRawData)
    '                            mobjSampleRawData = Nothing
    '                        End If
    '                    Case ClsAAS203.enumSampleType.STANDARD
    '                        If Not (mobjStandardRawData Is Nothing) Then
    '                            mobjAnalysisRawData.Add(mobjStandardRawData)
    '                            mobjStandardRawData = Nothing
    '                        End If
    '                End Select
    '                '//-----
    '                Call SaveRawDataFile()

    '                If (gobjNewMethod.OperationMode = EnumOperationMode.MODE_UVABS) Then
    '                    If Not Cancelled Then
    '                        Call StoreCalculateDisplayQuantValueUvMode(mobjBgReadData.UVAbsorbance)
    '                    End If

    '                Else
    '                    dblAbsorbance = StoreCalculateDisplayQuantValue()
    '                End If

    '                If (SampleType = ClsAAS203.enumSampleType.STANDARD) Then
    '                    If Not clsStandardGraph.CheckValidStdAbsEntry(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection) Then
    '                        'If Not clsStandardGraph.CheckValidStdAbsEntry(mobjCurrentStandard) Then
    '                        'gobjMessageAdapter.ShowMessage("Absorbance of the standard is less than or equal to the previous standard." & vbCrLf & _
    '                        '"Press 'Repeat Last' button for aspirating the same standard again.", _
    '                        '"Standard Aspiration Error", MessageHandler.clsMessageHandler.enumMessageType.ErrorMessage)

    '                        gobjMessageAdapter.ShowMessage(constStandardAbsorbance)
    '                        Application.DoEvents()
    '                    End If
    '                End If

    '                If (SampleType = ClsAAS203.enumSampleType.SAMPLE) Then
    '                    If Not clsStandardGraph.CheckValidSampAbsEntry(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection, mdblAbsorbance) Then
    '                        'If Not clsStandardGraph.CheckValidSampAbsEntry(mobjCurrentSample, mdblAbsorbance) Then

    '                        'gobjMessageAdapter.ShowMessage("Absorbance of the sample is more than the maximum standard value." & vbCrLf & _
    '                        '"Calculated Concentration may not be correct." & vbCrLf & _
    '                        '"Please dilute the sample and repeat again." & vbCrLf & _
    '                        ' "Press RepeatLast button when ready.", "Sample Aspiration Error", _
    '                        '  MessageHandler.clsMessageHandler.enumMessageType.ErrorMessage)

    '                        gobjMessageAdapter.ShowMessage(constSampleAbsorbance)
    '                        Application.DoEvents()
    '                    End If

    '                End If

    '                'btnReadData.Enabled = True

    '                'SendMessage(hwnd, WM_COMMAND, 900, 0L) '//IDC_QANEXT, 0L);
    '                Call NextAnalysis_Clicked(btnNextAnalysis, EventArgs.Empty)

    '                If AnaOver Then
    '                    'btnRepeatLast.Enabled = False
    '                End If
    '                AddHandler btnReadData.Click, AddressOf ReadData_Click
    '                mblnAvoidProcessing = False
    '                Application.DoEvents()
    '                Call gobjMain.mobjController.Start(gobjclsBgFlameStatus)

    '                'Application.DoEvents()
    '                'Call Aspirate()
    '                'Application.DoEvents()


    '                'Application.DoEvents()

    '            Catch ex As Exception
    '                '---------------------------------------------------------
    '                'Error Handling and logging
    '                gobjErrorHandler.ErrorDescription = ex.Message
    '                gobjErrorHandler.ErrorMessage = ex.Message
    '                gobjErrorHandler.WriteErrorLog(ex)
    '                '---------------------------------------------------------
    '            Finally
    '                '---------------------------------------------------------
    '                'Writing Execution log
    '                If CONST_CREATE_EXECUTION_LOG = 1 Then
    '                    gobjErrorHandler.WriteExecutionLog()
    '                End If
    '                '---------------------------------------------------------
    '            End Try
    '        End Sub

    '        'Public Sub Display(ByVal Text As String) Implements BgThread.Iclient.Display
    '        '    '=====================================================================
    '        '    ' Procedure Name        : Display
    '        '    ' Parameters Passed     : Text
    '        '    ' Returns               : None
    '        '    ' Purpose               : 
    '        '    ' Description           : 
    '        '    ' Assumptions           : 
    '        '    ' Dependencies          : 
    '        '    ' Author                : Mangesh Shardul
    '        '    ' Created               : 17-Jan-2007 03:25 pm
    '        '    ' Revisions             : 1
    '        '    '=====================================================================
    '        '    Dim strData As String
    '        '    Dim arrData() As String
    '        '    Dim xValue, yValue As Double
    '        '    Dim strSampleName As String
    '        '    Dim curveColor As Color
    '        '    Try
    '        '        If gobjNewMethod.OperationMode = EnumOperationMode.MODE_UVABS Then
    '        '            lblUVAbsorbance.Text = "Absorbance : " & FormatNumber(Text, 2)
    '        '            Call AddInAnalysisRawData(xValue, yValue)
    '        '            Exit Sub
    '        '        Else
    '        '            arrData = Text.Split(",")
    '        '            xValue = Val(arrData(0))
    '        '            yValue = Val(arrData(1))
    '        '        End If

    '        '        '---Display Real Point of Reading
    '        '        'If intIsReal = 1 Then
    '        '        '---Display Abs Value on screen
    '        '        lblAbsorbance.Text = Format(yValue, "0.000")
    '        '        '---Add only Real Point in the Analysis Raw Data Structure
    '        '        Call AddInAnalysisRawData(xValue, yValue)
    '        '        'End If

    '        '        '---Draw Line
    '        '        '---Add single Curve Item for all lines
    '        '        strSampleName = "Aspiration Curve"
    '        '        Select Case Me.SampleType
    '        '            Case ClsAAS203.enumSampleType.BLANK
    '        '                curveColor = ClsAAS203.BLANKCOLOR
    '        '            Case ClsAAS203.enumSampleType.STANDARD
    '        '                curveColor = ClsAAS203.STDCOLOR
    '        '            Case ClsAAS203.enumSampleType.SAMPLE
    '        '                curveColor = ClsAAS203.SAMPCOLOR
    '        '        End Select

    '        '        If (Afirst) Then
    '        '            Afirst = False
    '        '            mobjGraphCurve = AASGraphAnalysis.StartOnlineGraph(strSampleName, Color.Black, AldysGraph.SymbolType.NoSymbol, True)
    '        '            AASGraphAnalysis.PlotPoint(mobjGraphCurve, xValue, yValue, True)
    '        '        Else
    '        '            mobjGraphCurve.CL.Add(curveColor)
    '        '            AASGraphAnalysis.PlotPoint(mobjGraphCurve, xValue, yValue, True)
    '        '        End If

    '        '        'Application.DoEvents()
    '        '        'AASGraphAnalysis.AldysPane.XAxis.PickScale(AASGraphAnalysis.XAxisMin, AASGraphAnalysis.XAxisMax)
    '        '        'AASGraphAnalysis.AldysPane.XAxis.StepAuto = True
    '        '        'AASGraphAnalysis.AldysPane.XAxis.MinorStepAuto = True
    '        '        'AASGraphAnalysis.AldysPane.YAxis.PickScale(AASGraphAnalysis.YAxisMin, AASGraphAnalysis.YAxisMax)
    '        '        'AASGraphAnalysis.AldysPane.YAxis.StepAuto = True
    '        '        'AASGraphAnalysis.AldysPane.YAxis.MinorStepAuto = True

    '        '        AASGraphAnalysis.Refresh()
    '        '        Application.DoEvents()

    '        '    Catch ex As Exception
    '        '        '---------------------------------------------------------
    '        '        'Error Handling and logging
    '        '        gobjErrorHandler.ErrorDescription = ex.Message
    '        '        gobjErrorHandler.ErrorMessage = ex.Message
    '        '        gobjErrorHandler.WriteErrorLog(ex)
    '        '        '---------------------------------------------------------
    '        '    Finally
    '        '        '---------------------------------------------------------
    '        '        'Writing Execution log
    '        '        If CONST_CREATE_EXECUTION_LOG = 1 Then
    '        '            gobjErrorHandler.WriteExecutionLog()
    '        '        End If
    '        '        '---------------------------------------------------------
    '        '    End Try
    '        'End Sub

    '        Public Sub Display(ByVal Text As String) Implements BgThread.Iclient.Display
    '            '=====================================================================
    '            ' Procedure Name        : Display
    '            ' Parameters Passed     : Text
    '            ' Returns               : None
    '            ' Purpose               : 
    '            ' Description           : 
    '            ' Assumptions           : 
    '            ' Dependencies          : 
    '            ' Author                : Deepak
    '            ' Created               : 29.04.07
    '            ' Revisions             : 
    '            '=====================================================================
    '            Dim strData As String
    '            Dim arrData() As String
    '            Dim xValue, yValue As Double
    '            Dim strSampleName As String
    '            Dim curveColor As Color
    '            Dim dblAvgAbs As Double = 0
    '            Dim IsAvgAbs As Boolean = False
    '            Try
    '                intDispCount += 1

    '                If gobjNewMethod.OperationMode = EnumOperationMode.MODE_UVABS Then
    '                    'lblUVAbsorbance.Text = "Absorbance : " & FormatNumber(Text, 2)
    '                    Call AddInAnalysisRawData(xValue, yValue)
    '                    Exit Sub
    '                Else
    '                    arrData = Text.Split(",")
    '                    xValue = Val(arrData(0))
    '                    yValue = Val(arrData(1))


    '                    IsAvgAbs = False
    '                    If arrData.Length > 2 Then
    '                        IsAvgAbs = True
    '                        dblAvgAbs = Val(arrData(2))
    '                    End If
    '                End If

    '                '---Display Real Point of Reading
    '                'If intIsReal = 1 Then
    '                '---Display Abs Value on screen
    '                'lblAbsorbance.Text = Format(yValue, "0.000")
    '                '---Add only Real Point in the Analysis Raw Data Structure
    '                'Call AddInAnalysisRawData(xValue, yValue)
    '                Call AddInAnalysisRawData(xValue, dblAvgAbs)

    '                'End If

    '                '---Draw Line
    '                '---Add single Curve Item for all lines
    '                strSampleName = "Aspiration Curve"
    '                Select Case Me.SampleType
    '                    Case ClsAAS203.enumSampleType.BLANK
    '                        curveColor = ClsAAS203.BLANKCOLOR
    '                    Case ClsAAS203.enumSampleType.STANDARD
    '                        curveColor = ClsAAS203.STDCOLOR
    '                    Case ClsAAS203.enumSampleType.SAMPLE
    '                        curveColor = ClsAAS203.SAMPCOLOR
    '                End Select
    '                'If xValue > AASGraphAnalysis.XAxisMax Or yValue > AASGraphAnalysis.YAxisMax Then
    '                'Call' Calculate_Analysis_Graph_Param(AASGraphAnalysis, xValue, yValue)
    '                'End If

    '                If IsAvgAbs Then
    '                    If (Afirst) Then
    '                        Afirst = False
    '                        'mobjGraphCurve = AASGraphAnalysis.StartOnlineGraph(strSampleName, Color.Black, AldysGraph.SymbolType.NoSymbol, True)
    '                        'AASGraphAnalysis.PlotPoint(mobjGraphCurve, xValue, dblAvgAbs, True)
    '                        'AASGraphAnalysis.PlotPoint(mobjGraphCurve, xValue, yValue, True)
    '                    Else
    '                        'mobjGraphCurve.CL.Add(curveColor)
    '                        'AASGraphAnalysis.PlotPoint(mobjGraphCurve, xValue, dblAvgAbs, True)
    '                        'AASGraphAnalysis.PlotPoint(mobjGraphCurve, xValue, yValue, True)
    '                    End If
    '                End If

    '                'AASGraphAnalysis.Refresh()
    '                'Application.DoEvents()

    '            Catch ex As Exception
    '                '---------------------------------------------------------
    '                'Error Handling and logging
    '                gobjErrorHandler.ErrorDescription = ex.Message
    '                gobjErrorHandler.ErrorMessage = ex.Message
    '                gobjErrorHandler.WriteErrorLog(ex)
    '                '---------------------------------------------------------
    '            Finally
    '                '---------------------------------------------------------
    '                'Writing Execution log
    '                If CONST_CREATE_EXECUTION_LOG = 1 Then
    '                    gobjErrorHandler.WriteExecutionLog()
    '                End If
    '                '---------------------------------------------------------
    '            End Try
    '        End Sub

    '        Public Sub Failed(ByVal e As System.Exception) Implements BgThread.Iclient.Failed
    '            '=====================================================================
    '            ' Procedure Name        : Failed
    '            ' Parameters Passed     : None
    '            ' Returns               : None
    '            ' Purpose               : 
    '            ' Description           : 
    '            ' Assumptions           : 
    '            ' Dependencies          : 
    '            ' Author                : Mangesh Shardul
    '            ' Created               : 17-Jan-2007 03:25 pm
    '            ' Revisions             : 1
    '            '=====================================================================
    '            Try
    '                MsgBox("Data Read Thread is failed", MsgBoxStyle.OKOnly)
    '                Application.DoEvents()
    '                AddHandler btnReadData.Click, AddressOf ReadData_Click
    '                mblnAvoidProcessing = False
    '            Catch ex As Exception
    '                '---------------------------------------------------------
    '                'Error Handling and logging
    '                gobjErrorHandler.ErrorDescription = ex.Message
    '                gobjErrorHandler.ErrorMessage = ex.Message
    '                gobjErrorHandler.WriteErrorLog(ex)
    '                '---------------------------------------------------------
    '            Finally
    '                '---------------------------------------------------------
    '                'Writing Execution log
    '                If CONST_CREATE_EXECUTION_LOG = 1 Then
    '                    gobjErrorHandler.WriteExecutionLog()
    '                End If
    '                Application.DoEvents()
    '                '---------------------------------------------------------
    '            End Try
    '        End Sub

    '#End Region

    '#Region "Commented Code"

    '        'Private Sub btnImport_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    '        '    '=====================================================================
    '        '    ' Procedure Name        : tlbbtnLoad_Click
    '        '    ' Parameters Passed     : Object, EventArgs
    '        '    ' Returns               : 
    '        '    ' Purpose               : To load the Analysis already saved.
    '        '    ' Description           : 
    '        '    ' Assumptions           : 
    '        '    ' Dependencies          : 
    '        '    ' Author                : Saurabh S
    '        '    ' Created               : 05.10.06
    '        '    ' Revisions             : 
    '        '    '=====================================================================
    '        '    Dim objWait As New CWaitCursor
    '        '    Dim intRunNumberIndex As Long
    '        '    Dim intCounter As Integer
    '        '    Dim intCount As Integer
    '        '    Dim strRunNo As String
    '        '    Dim objfrmLoadAnalysis As New frmLoadAnalysis
    '        '    Dim objClsMethod As clsMethod
    '        '    Dim intSelectedMethodID As Integer
    '        '    Dim lngSelectedRunNumber As Long
    '        '    Try
    '        '        'tlbbtnLoad.SuspendEvents()

    '        '        objfrmLoadAnalysis.GroupBox2.Visible = False
    '        '        objfrmLoadAnalysis.gbMultiElementReport.Visible = False
    '        '        If objfrmLoadAnalysis.ShowDialog() = DialogResult.Cancel Then
    '        '            Exit Sub
    '        '        End If

    '        '        intSelectedMethodID = objfrmLoadAnalysis.SelectedMethodID
    '        '        lngSelectedRunNumber = objfrmLoadAnalysis.SelectedRunNumber
    '        '        objfrmLoadAnalysis.Close()
    '        '        objfrmLoadAnalysis.Dispose()
    '        '        '//-----
    '        '        mobjAnalysisRawData = Nothing
    '        '        mobjAnalysisRawData = New Analysis.clsRawDataCollection

    '        '        mobjBlankRawData = Nothing
    '        '        mobjStandardRawData = Nothing
    '        '        mobjSampleRawData = Nothing

    '        '        intRunNumberIndex = modGlobalFunctions.gfuncGetSelectedMethodRunNumberIndex(mintSelectedMethodID, mlngSelectedRunNumber)

    '        '        For intCounter = 0 To gobjMethodCollection.Count - 1
    '        '            If gobjMethodCollection.item(intCounter).MethodID = intSelectedMethodID Then

    '        '                'mobjClsMethod = gobjMethodCollection.item(intCounter).Clone()

    '        '                'mobjClsMethod.QuantitativeDataCollection.Item(intRunNumberIndex).AnalysisRawData(0).SampleType = clsRawData.enumSampleType.BLANK
    '        '                'Dim int As Integer
    '        '                For intRunNumberIndex = 0 To gobjMethodCollection.item(intCounter).QuantitativeDataCollection.Count - 1
    '        '                    If lngSelectedRunNumber = gobjMethodCollection.item(intCounter).QuantitativeDataCollection.Item(intRunNumberIndex).RunNumber Then

    '        '                        Afirst = False

    '        '                        'mobjAnalysisRawData.Add(mobjStandardRawData)


    '        '                        'Select Case mobjAnalysisRawData(i).SampleType
    '        '                        'Case (ClsAAS203.enumSampleType.STANDARD)
    '        '                        'If Not IsNothing(mobjCurrentStandard) Then
    '        '                        '    If (gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfStdRepeats) > 1 Then '( Method->QuantData->Param.ConcRepeat>1)
    '        '                        '        If (mblnIsAutosampler And mblnIsAnalysisStarted) Then
    '        '                        '            mstrAspirationMessage = aspMsg & mobjCurrentStandard.StdName & " (Repeat #" & CurRepeat & ") from Position " & mobjCurrentStandard.PositionNumber
    '        '                        '            SetAutoSampler(mobjCurrentStandard.PositionNumber, True)
    '        '                        '        Else
    '        '                        '            mstrAspirationMessage = aspMsg & .StdName & "(Repeat #" & CurRepeat & ") and Click &READ or press <SPACEBAR>"
    '        '                        '        End If
    '        '                        '    Else
    '        '                        '        If (mblnIsAutosampler And mblnIsAnalysisStarted) Then
    '        '                        '            mstrAspirationMessage = aspMsg & mobjCurrentStandard.StdName & " from Position " & mobjCurrentStandard.PositionNumber
    '        '                        '            SetAutoSampler(mobjCurrentStandard.PositionNumber, True)
    '        '                        '        Else
    '        '                        '            mstrAspirationMessage = aspMsg & mobjCurrentStandard.StdName & " and Click &READ or press <SPACEBAR>"
    '        '                        '        End If
    '        '                        '    End If
    '        '                        'End If

    '        '                        '    Case (ClsAAS203.enumSampleType.STANDARD)
    '        '                        '        If Not IsNothing(mobjCurrentSample) Then
    '        '                        '            If (gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfSampleRepeats > 1) Then
    '        '                        '                If (mblnIsAutosampler And mblnIsAnalysisStarted) Then
    '        '                        '                    mstrAspirationMessage = aspMsg & mobjCurrentSample.SampleName & " (Repeat #" & CurRepeat & ") from Position " & mobjCurrentSample.SampPosNumber
    '        '                        '                    SetAutoSampler(mobjCurrentSample.SampPosNumber, True)
    '        '                        '                Else
    '        '                        '                    mstrAspirationMessage = aspMsg & mobjCurrentSample.SampleName & " (Repeat #" & CurRepeat & ") and Click &READ or press <SPACEBAR> "
    '        '                        '                End If
    '        '                        '            Else
    '        '                        '                If (mblnIsAutosampler And mblnIsAnalysisStarted) Then
    '        '                        '                    mstrAspirationMessage = aspMsg & mobjCurrentSample.SampleName & " from Position " & mobjCurrentSample.SampPosNumber
    '        '                        '                    SetAutoSampler(mobjCurrentSample.SampPosNumber, True)
    '        '                        '                Else
    '        '                        '                    mstrAspirationMessage = aspMsg & mobjCurrentSample.SampleName & " and Click &READ or press <SPACE BAR>"
    '        '                        '                End If
    '        '                        '            End If
    '        '                        '        End If
    '        '                        '    Case Else

    '        '                        'End Select
    '        '                        '//----
    '        '                        Exit For

    '        '                    End If

    '        '                Next
    '        '                Dim i As Integer
    '        '                intIEnumCollLocationStd = 0
    '        '                intIEnumCollLocationSamp = 0
    '        '                For i = 0 To gobjMethodCollection.item(intCounter).QuantitativeDataCollection.Item(intRunNumberIndex).AnalysisRawData.Count - 1
    '        '                    mobjAnalysisRawData.Add(gobjMethodCollection.item(intCounter).QuantitativeDataCollection.Item(intRunNumberIndex).AnalysisRawData(i))
    '        '                    'mobjClsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisRawData = mobjAnalysisRawData
    '        '                    If gobjMethodCollection.item(intCounter).QuantitativeDataCollection.Item(intRunNumberIndex).AnalysisRawData(i).SampleType = clsRawData.enumSampleType.SAMPLE Then
    '        '                        intIEnumCollLocationSamp += 1
    '        '                    ElseIf gobjMethodCollection.item(intCounter).QuantitativeDataCollection.Item(intRunNumberIndex).AnalysisRawData(i).SampleType = clsRawData.enumSampleType.STANDARD Then
    '        '                        intIEnumCollLocationStd += 1
    '        '                    End If
    '        '                Next

    '        '                '//----
    '        '                'mobjClsMethod.QuantitativeDataCollection.Item(intRunNumberIndex).StandardDataCollection(0)
    '        '                'intIEnumCollLocationStd = gobjMethodCollection.item(intCounter).QuantitativeDataCollection(intRunNumberIndex).StandardDataCollection.Count
    '        '                'intIEnumCollLocationSamp = gobjMethodCollection.item(intCounter).QuantitativeDataCollection(intRunNumberIndex).SampleDataCollection.Count

    '        '                mobjCurrentStandard = Nothing
    '        '                mobjCurrentSample = Nothing
    '        '                If intIEnumCollLocationSamp <= 0 Then
    '        '                    'mobjCurrentStandard = gobjMethodCollection.item(intCounter).QuantitativeDataCollection(intRunNumberIndex).StandardDataCollection(intIEnumCollLocationStd - 1)
    '        '                    Call funcGetCurrentStandard(mobjCurrentStandard)
    '        '                Else
    '        '                    'mobjCurrentSample = gobjMethodCollection.item(intCounter).QuantitativeDataCollection(intRunNumberIndex).SampleDataCollection(intIEnumCollLocationSamp - 1)
    '        '                    Call funcGetCurrentSample(mobjCurrentSample)
    '        '                End If



    '        '                Dim i1 As Integer = gobjMethodCollection.item(intCounter).QuantitativeDataCollection.Item(intRunNumberIndex).AnalysisRawData(i - 1).Readings.Count - 1

    '        '                mobjBgReadData.CEndTime = gobjMethodCollection.item(intCounter).QuantitativeDataCollection(intRunNumberIndex).AnalysisRawData(i - 1).Readings(i1).XTime
    '        '                mEndTime = mobjBgReadData.CEndTime
    '        '                SampleType = gobjMethodCollection.item(intCounter).QuantitativeDataCollection.Item(intRunNumberIndex).AnalysisRawData(i - 1).SampleType
    '        '                'Call NextAnalysis_Clicked(btnNextAnalysis, EventArgs.Empty)
    '        '                Application.DoEvents()
    '        '                Call Aspirate()
    '        '                Application.DoEvents()
    '        '                '//----- Sachin Dokhale
    '        '                'StdAnalysed=TRUE;
    '        '                'toreported=TRUE;
    '        '                'InvalidateRect(hwnd, NULL, TRUE);
    '        '                'EnableWindow(GetDlgItem(hwnd,IDC_SAVEREPORT), StdAnalysed);
    '        '                StdAnalysed = True
    '        '                toreported = True
    '        '                'btnSave.Enabled = StdAnalysed
    '        '                '//-----

    '        '                'If gobjNewMethod Is Nothing Then
    '        '                '    gobjNewMethod = objClsMethod
    '        '                'End If
    '        '                'If gobjNewMethod.MethodID <> objClsMethod.MethodID Then
    '        '                '    '---Currently Selected Method is Changed.. Notify user for Reprocess Analysis
    '        '                '    '---If Current Method is in Analysis then Prevent user for Changing method
    '        '                '    gobjNewMethod = objClsMethod
    '        '                '    'RaiseEvent CurrentMethodChannged(objClsMethod.MethodID)
    '        '                'End If


    '        '                'Call funcShowMethodGeneralInfo(mobjClsMethod, strRunNo)
    '        '                Select Case gobjMethodCollection.item(intCounter).OperationMode
    '        '                    Case EnumOperationMode.MODE_UVABS
    '        '                        'AASGraphAnalysis.Visible = False
    '        '                    Case Else
    '        '                        strRunNo = gobjMethodCollection.item(intCounter).QuantitativeDataCollection.Item(intRunNumberIndex).RunNumber
    '        '                        'AASGraphAnalysis.Visible = True
    '        '                        'Call gobjClsAAS203.subShowGraphPreview(Me.AASGraphAnalysis, mobjGraphCurve, strRunNo, gobjMethodCollection.item(intCounter))
    '        '                        'AASGraphAnalysis.Invalidate()
    '        '                        'AASGraphAnalysis.IsShowGrid = True      'Saurabh To show Grid 19.07.07
    '        '                        'AASGraphAnalysis.Refresh()
    '        '                        Me.Refresh()
    '        '                        Application.DoEvents()
    '        '                End Select
    '        '                'btnStandardGraph.Enabled = True
    '        '                'btnSampleGraph.Enabled = True
    '        '                'btnViewResults.Enabled = True
    '        '                'btnReports.Enabled = True
    '        '                'btnPrintGraph.Enabled = True
    '        '                'btnReportOptions.Enabled = True
    '        '                'btnExportReport.Enabled = True
    '        '                'btnEditData.Enabled = True

    '        '                Exit For

    '        '            End If
    '        '        Next

    '        '    Catch ex As Exception
    '        '        '---------------------------------------------------------
    '        '        'Error Handling and logging
    '        '        gobjErrorHandler.ErrorDescription = ex.Message
    '        '        gobjErrorHandler.ErrorMessage = ex.Message
    '        '        gobjErrorHandler.WriteErrorLog(ex)
    '        '        '---------------------------------------------------------
    '        '    Finally
    '        '        '---------------------------------------------------------
    '        '        'Writing Execution log
    '        '        If CONST_CREATE_EXECUTION_LOG = 1 Then
    '        '            gobjErrorHandler.WriteExecutionLog()
    '        '        End If
    '        '        If Not objWait Is Nothing Then
    '        '            objWait.Dispose()
    '        '        End If
    '        '        'tlbbtnLoad.ResumeEvents()
    '        '        '---------------------------------------------------------
    '        '    End Try
    '        'End Sub

    '        'Private Sub subGetRowDatafileInfoIntoObject(ByVal objClsMethodIn As clsMethod)
    '        '    Try
    '        '        ' objClsMethodIn.InstrumentCondition()

    '        '    Catch ex As Exception
    '        '        '---------------------------------------------------------
    '        '        'Error Handling and logging
    '        '        gobjErrorHandler.ErrorDescription = ex.Message
    '        '        gobjErrorHandler.ErrorMessage = ex.Message
    '        '        gobjErrorHandler.WriteErrorLog(ex)
    '        '        '---------------------------------------------------------
    '        '    Finally
    '        '        '---------------------------------------------------------
    '        '        'Writing Execution log
    '        '        If CONST_CREATE_EXECUTION_LOG = 1 Then
    '        '            gobjErrorHandler.WriteExecutionLog()
    '        '        End If
    '        '        '---------------------------------------------------------
    '        '    End Try
    '        'End Sub

    '        'Private Sub btnExportReport_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    '        '    '=====================================================================
    '        '    ' Procedure Name        : tlbbtnExportReport_Click
    '        '    ' Parameters Passed     : Object, EventArgs
    '        '    ' Returns               : 
    '        '    ' Purpose               : 
    '        '    ' Description           : 
    '        '    ' Assumptions           : 
    '        '    ' Dependencies          : 
    '        '    ' Author                : Saurabh S & Sachin Dokhale
    '        '    ' Created               : 05.10.06
    '        '    ' Revisions             : 
    '        '    '=====================================================================
    '        '    Dim objWait As New CWaitCursor
    '        '    Dim intSelectId As Integer
    '        '    Dim intCount, intCount1 As Integer
    '        '    Dim A1() As Double = {0, 0, 0, 0, 0, 0}
    '        '    Try
    '        '        'Added By Pankaj Fri 18 May 07
    '        '        If (gstructSettings.Enable21CFR = True) Then
    '        '            If Not funcCheckActivityAuthentication(enumActivityAuthentication.Export, gstructUserDetails.Access) Then
    '        '                Return
    '        '                Exit Sub
    '        '            End If
    '        '            gfuncInsertActivityLog(EnumModules.Export, "Export Accessed")
    '        '        End If

    '        '        'tlbbtnLoad.SuspendEvents()
    '        '        'mobjClsDataFileReport.MethodID = mintSelectedMethodID
    '        '        'mobjClsDataFileReport.RunNumber = mintSelectedRunNumber
    '        '        'For intCount = 0 To gobjMethodCollection.Count - 1
    '        '        '    If mintSelectedMethodID = gobjMethodCollection(intCount).MethodID Then
    '        '        '        intSelectId = intCount
    '        '        '        mobjClsDataFileReport.MethodID = intCount
    '        '        '        Exit For
    '        '        '    End If
    '        '        'Next
    '        '        If (toreported) Then 'OR NOT Method->RepReady )
    '        '            gobjClsAAS203.SaveQuantResults(gobjNewMethod, A1, 1, False)
    '        '            toreported = False
    '        '        End If
    '        '        If StdAnalysed Or AnaOver Or mblnIsAnalysisStarted Then 'Or ManualEntry Then
    '        '            For intCount = 0 To gobjMethodCollection.Count - 1
    '        '                'If mintSelectedMethodID = gobjMethodCollection(intCount).MethodID Then
    '        '                If gobjNewMethod.MethodID = gobjMethodCollection(intCount).MethodID Then
    '        '                    'intSelectIDIndex = intCount
    '        '                    intSelectId = intCount
    '        '                    'mobjClsDataFileReport.MethodID = intCount
    '        '                    mobjClsDataFileReport.MethodID = gobjMethodCollection(intCount).MethodID
    '        '                    For intCount1 = 0 To gobjMethodCollection(intSelectId).QuantitativeDataCollection.Count - 1
    '        '                        If mlngSelectedRunNumber = CInt(gobjMethodCollection(intSelectId).QuantitativeDataCollection(intCount1).RunNumber) Then
    '        '                            mobjClsDataFileReport.RunNumber = mlngSelectedRunNumber
    '        '                            Call mobjClsDataFileReport.funcDatafileExport(gobjMethodCollection(intSelectId).QuantitativeDataCollection(intCount1).ReportParameters)
    '        '                            Exit For
    '        '                        End If
    '        '                    Next
    '        '                    Exit For
    '        '                End If
    '        '            Next

    '        '            'For intCount = 0 To gobjMethodCollection(intSelectId).QuantitativeDataCollection.Count - 1
    '        '            '    If mlngSelectedRunNumber = CInt(gobjMethodCollection(intSelectId).QuantitativeDataCollection(intCount).RunNumber) Then
    '        '            '        mobjClsDataFileReport.RunNumber = mlngSelectedRunNumber
    '        '            '        Call mobjClsDataFileReport.funcDatafileExport()
    '        '            '        Exit For
    '        '            '    End If
    '        '            'Next
    '        '            'For intCount = 0 To gobjMethodCollection(intSelectId).QuantitativeDataCollection.Count - 1
    '        '            '    If mintSelectedRunNumber = CInt(gobjMethodCollection(intSelectId).QuantitativeDataCollection(intCount).RunNumber) Then

    '        '            '        mobjClsDataFileReport.RunNumber = mintSelectedRunNumber
    '        '            '        Exit For
    '        '            '    End If
    '        '            'Next
    '        '            'Call mobjClsDataFileReport.funcDatafileExport()
    '        '        End If
    '        '    Catch ex As Exception
    '        '        '---------------------------------------------------------
    '        '        'Error Handling and logging
    '        '        gobjErrorHandler.ErrorDescription = ex.Message
    '        '        gobjErrorHandler.ErrorMessage = ex.Message
    '        '        gobjErrorHandler.WriteErrorLog(ex)
    '        '        '---------------------------------------------------------
    '        '    Finally
    '        '        '---------------------------------------------------------
    '        '        'Writing Execution log
    '        '        If CONST_CREATE_EXECUTION_LOG = 1 Then
    '        '            gobjErrorHandler.WriteExecutionLog()
    '        '        End If
    '        '        If Not objWait Is Nothing Then
    '        '            objWait.Dispose()
    '        '        End If
    '        '        '---------------------------------------------------------
    '        '    End Try
    '        'End Sub

    '        'Private Sub btnEditData_Clicked(ByVal sender As Object, ByVal e As EventArgs)
    '        '    '=====================================================================
    '        '    ' Procedure Name        : btnEditData_Clicked
    '        '    ' Parameters Passed     : object, EventArgs
    '        '    ' Returns               : None
    '        '    ' Purpose               : 
    '        '    ' Description           : 
    '        '    ' Assumptions           : 
    '        '    ' Dependencies          : 
    '        '    ' Author                : Mangesh Shardul
    '        '    ' Created               : 16-Mar-2007 12:45 pm
    '        '    ' Revisions             : 1
    '        '    '=====================================================================
    '        '    '****************************************************************
    '        '    '---- ORIGINAL CODE
    '        '    '****************************************************************
    '        '    'BOOL	OnViewRepeats(HWND	hpar)
    '        '    '{
    '        '    '   BOOL	flag = FALSE;
    '        '    '   DLGPROC  skp1;
    '        '    '   if (Method->QuantData==NULL)
    '        '    '	    return flag;
    '        '    '   if ((Method->QuantData->Param.Repeat>1 || Method->QuantData->Param.ConcRepeat>1 )&&  FindSamplesAnalysed()>=1) 
    '        '    '   {
    '        '    '	    skp1 =(DLGPROC) MakeProcInstance((DLGPROC) OnViewRepeatsProc,hInst);
    '        '    '	    flag = DialogBox(hInst,"QVIEWRPTS", hpar, skp1);
    '        '    '	    FreeProcInstance(skp1);
    '        '    '  }
    '        '    '   Else
    '        '    '	    flag = OnEditStdSamples(hpar);
    '        '    '   return flag;
    '        '    '}
    '        '    '****************************************************************
    '        '    Dim flag As Boolean = False
    '        '    Dim objfrmDeleteStdNSam As frmDeleteStdNSam
    '        '    Dim objfrmViewRepeatResults As frmViewRepeatResults

    '        '    Try
    '        '        If IsNothing(gobjNewMethod.QuantitativeDataCollection) Then
    '        '            Return
    '        '        End If

    '        '        If ((gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfSampleRepeats > 1 _
    '        '          Or gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfStdRepeats > 1) _
    '        '          And clsStandardGraph.FindSamplesAnalysed(gobjNewMethod, mintRunNumberIndex) >= 1) Then

    '        '            objfrmViewRepeatResults = New frmViewRepeatResults(gobjNewMethod, mintRunNumberIndex)
    '        '            objfrmViewRepeatResults.ShowDialog()
    '        '            objfrmViewRepeatResults.Close()
    '        '            objfrmViewRepeatResults.Dispose()
    '        '            objfrmViewRepeatResults = Nothing
    '        '        Else
    '        '            'flag = OnEditStdSamples()
    '        '            objfrmDeleteStdNSam = New frmDeleteStdNSam(gobjNewMethod, mintRunNumberIndex)
    '        '            objfrmDeleteStdNSam.ShowDialog()
    '        '            objfrmDeleteStdNSam.Close()
    '        '            objfrmDeleteStdNSam.Dispose()
    '        '            objfrmDeleteStdNSam = Nothing
    '        '            flag = True
    '        '        End If

    '        '    Catch ex As Exception
    '        '        '---------------------------------------------------------
    '        '        'Error Handling and logging
    '        '        gobjErrorHandler.ErrorDescription = ex.Message
    '        '        gobjErrorHandler.ErrorMessage = ex.Message
    '        '        gobjErrorHandler.WriteErrorLog(ex)
    '        '        '---------------------------------------------------------
    '        '    Finally
    '        '        '---------------------------------------------------------
    '        '        'Writing Execution log
    '        '        If CONST_CREATE_EXECUTION_LOG = 1 Then
    '        '            gobjErrorHandler.WriteExecutionLog()
    '        '        End If
    '        '        '---------------------------------------------------------
    '        '    End Try
    '        'End Sub


    '        'Private Sub XpPanelReports_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        '    '=====================================================================
    '        '    ' Procedure Name        : XpPanelReportsClicked
    '        '    ' Parameters Passed     : Object,EventArgs
    '        '    ' Returns               : None
    '        '    ' Purpose               : To view the Reports
    '        '    ' Description           : 
    '        '    ' Assumptions           : 
    '        '    ' Dependencies          : 
    '        '    ' Author                : Deepak & Saurabh
    '        '    ' Created               : 05.10.06
    '        '    ' Revisions             : 
    '        '    '===================================================================== 
    '        '    Dim objWait As New CWaitCursor

    '        '    Try
    '        '        If Me.XpPanelReports.PanelState = UIComponents.XPPanelState.Collapsed Then
    '        '            Call funcCollapseAllXPPanels()
    '        '            Me.XpPanelReports.TogglePanelState()
    '        '            Me.XpPanelReports.PanelHeight = 80
    '        '        End If

    '        '    Catch ex As Exception
    '        '        '---------------------------------------------------------
    '        '        'Error Handling and logging
    '        '        gobjErrorHandler.ErrorDescription = ex.Message
    '        '        gobjErrorHandler.ErrorMessage = ex.Message
    '        '        gobjErrorHandler.WriteErrorLog(ex)
    '        '        '---------------------------------------------------------
    '        '    Finally
    '        '        '---------------------------------------------------------
    '        '        'Writing Execution log
    '        '        If CONST_CREATE_EXECUTION_LOG = 1 Then
    '        '            gobjErrorHandler.WriteExecutionLog()
    '        '        End If
    '        '        If Not objWait Is Nothing Then
    '        '            objWait.Dispose()
    '        '        End If
    '        '        '---------------------------------------------------------
    '        '    End Try
    '        'End Sub

    '        'Private Sub XpPanelSampleGraph_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        '    '=====================================================================
    '        '    ' Procedure Name        : XpPanelSampleGraphClicked
    '        '    ' Parameters Passed     : Object,EventArgs
    '        '    ' Returns               : None
    '        '    ' Purpose               : To view the Sample Graphs
    '        '    ' Description           : 
    '        '    ' Assumptions           : 
    '        '    ' Dependencies          : 
    '        '    ' Author                : Deepak & Saurabh
    '        '    ' Created               : 05.10.06
    '        '    ' Revisions             : 
    '        '    '===================================================================== 
    '        '    Dim objWait As New CWaitCursor

    '        '    Try
    '        '        If Me.XpPanelSampleGraph.PanelState = UIComponents.XPPanelState.Collapsed Then
    '        '            Call funcCollapseAllXPPanels()
    '        '            Me.XpPanelSampleGraph.TogglePanelState()
    '        '            Me.XpPanelSampleGraph.PanelHeight = 90
    '        '        End If

    '        '    Catch ex As Exception
    '        '        '---------------------------------------------------------
    '        '        'Error Handling and logging
    '        '        gobjErrorHandler.ErrorDescription = ex.Message
    '        '        gobjErrorHandler.ErrorMessage = ex.Message
    '        '        gobjErrorHandler.WriteErrorLog(ex)
    '        '        '---------------------------------------------------------
    '        '    Finally
    '        '        '---------------------------------------------------------
    '        '        'Writing Execution log
    '        '        If CONST_CREATE_EXECUTION_LOG = 1 Then
    '        '            gobjErrorHandler.WriteExecutionLog()
    '        '        End If
    '        '        If Not objWait Is Nothing Then
    '        '            objWait.Dispose()
    '        '        End If
    '        '        '---------------------------------------------------------
    '        '    End Try
    '        'End Sub

    '        'Private Sub XpPanelStandardGraph_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        '    '=====================================================================
    '        '    ' Procedure Name        : XpPanelStandardGraphClicked
    '        '    ' Parameters Passed     : Object,EventArgs
    '        '    ' Returns               : None
    '        '    ' Purpose               : To load the Standard Graph form
    '        '    ' Description           : 
    '        '    ' Assumptions           : 
    '        '    ' Dependencies          : 
    '        '    ' Author                : Deepak & Saurabh
    '        '    ' Created               : 05.10.06
    '        '    ' Revisions             : 
    '        '    '===================================================================== 
    '        '    Dim objWait As New CWaitCursor

    '        '    Try
    '        '        If Me.XpPanelStandardGraph.PanelState = UIComponents.XPPanelState.Collapsed Then
    '        '            Call funcCollapseAllXPPanels()
    '        '            Me.XpPanelStandardGraph.TogglePanelState()
    '        '            Me.XpPanelStandardGraph.PanelHeight = 80
    '        '        End If

    '        '    Catch ex As Exception
    '        '        '---------------------------------------------------------
    '        '        'Error Handling and logging
    '        '        gobjErrorHandler.ErrorDescription = ex.Message
    '        '        gobjErrorHandler.ErrorMessage = ex.Message
    '        '        gobjErrorHandler.WriteErrorLog(ex)
    '        '        '---------------------------------------------------------
    '        '    Finally
    '        '        '---------------------------------------------------------
    '        '        'Writing Execution log
    '        '        If CONST_CREATE_EXECUTION_LOG = 1 Then
    '        '            gobjErrorHandler.WriteExecutionLog()
    '        '        End If
    '        '        If Not objWait Is Nothing Then
    '        '            objWait.Dispose()
    '        '        End If
    '        '        '---------------------------------------------------------
    '        '    End Try
    '        'End Sub

    '        'Private Sub XpPanelViewResults_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        '    '=====================================================================
    '        '    ' Procedure Name        : XpPanelViewResultsClicked
    '        '    ' Parameters Passed     : Object,EventArgs
    '        '    ' Returns               : None
    '        '    ' Purpose               : To view the Results
    '        '    ' Description           : 
    '        '    ' Assumptions           : 
    '        '    ' Dependencies          : 
    '        '    ' Author                : Deepak & Saurabh
    '        '    ' Created               : 05.10.06
    '        '    ' Revisions             : 
    '        '    '===================================================================== 
    '        '    Dim objWait As New CWaitCursor

    '        '    Try
    '        '        If Me.XpPanelViewResults.PanelState = UIComponents.XPPanelState.Collapsed Then
    '        '            Call funcCollapseAllXPPanels()
    '        '            Me.XpPanelViewResults.TogglePanelState()
    '        '            Me.XpPanelViewResults.PanelHeight = 80
    '        '        End If

    '        '    Catch ex As Exception
    '        '        '---------------------------------------------------------
    '        '        'Error Handling and logging
    '        '        gobjErrorHandler.ErrorDescription = ex.Message
    '        '        gobjErrorHandler.ErrorMessage = ex.Message
    '        '        gobjErrorHandler.WriteErrorLog(ex)
    '        '        '---------------------------------------------------------
    '        '    Finally
    '        '        '---------------------------------------------------------
    '        '        'Writing Execution log
    '        '        If CONST_CREATE_EXECUTION_LOG = 1 Then
    '        '            gobjErrorHandler.WriteExecutionLog()
    '        '        End If
    '        '        If Not objWait Is Nothing Then
    '        '            objWait.Dispose()
    '        '        End If
    '        '        '---------------------------------------------------------
    '        '    End Try
    '        'End Sub

    '        'Private Sub AASGraphAnalysis_GraphScaleChanged(ByVal XMin As Double, ByVal XMax As Double, ByVal YMin As Double, ByVal YMax As Double) Handles AASGraphAnalysis.GraphScaleChanged
    '        '    AASGraphAnalysis.AldysPane.XAxis.MinorStepAuto = False
    '        '    AASGraphAnalysis.AldysPane.XAxis.StepAuto = False
    '        '    AASGraphAnalysis.AldysPane.YAxis.MinorStepAuto = False
    '        '    AASGraphAnalysis.AldysPane.YAxis.StepAuto = False

    '        '    '---changed by deepak on 29.04.07
    '        '    'AASGraphAnalysis.YAxisStep = 0.1
    '        '    AASGraphAnalysis.YAxisStep = 0.2
    '        '    'AASGraphAnalysis.YAxisMinorStep = 0.05
    '        '    AASGraphAnalysis.YAxisMinorStep = 0.1
    '        '    '---changed by deepak on 29.04.07

    '        '    AASGraphAnalysis.Refresh()
    '        'End Sub

    '        'Private Sub cmdChangeScale_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdChangeScale.Click
    '        '    '=====================================================================
    '        '    ' Procedure Name        : cmdChangeScale_Click
    '        '    ' Parameters Passed     : Object,EventArgs
    '        '    ' Returns               : None
    '        '    ' Purpose               : 
    '        '    ' Description           : calculte change scale
    '        '    ' Assumptions           : 
    '        '    ' Dependencies          : 
    '        '    ' Author                : Pankaj Bamb
    '        '    ' Created               : 1.05.07
    '        '    ' Revisions             : 
    '        '    '=====================================================================
    '        '    Dim objWait As New CWaitCursor
    '        '    Dim objfrmChangeScale As frmChangeScale

    '        '    Try
    '        '        objfrmChangeScale = New frmChangeScale(mobjParameters)
    '        '        objfrmChangeScale.funcSetValidatingScale(gobjInst.Mode)
    '        '        objfrmChangeScale.lblXAxis.Visible = False
    '        '        '-------------Added By Pankaj 11 May 07 for showing default scale on change form
    '        '        objfrmChangeScale.SpectrumParameter.XaxisMin = AASGraphAnalysis.XAxisMin
    '        '        objfrmChangeScale.SpectrumParameter.XaxisMax = AASGraphAnalysis.XAxisMax

    '        '        objfrmChangeScale.SpectrumParameter.YaxisMin = AASGraphAnalysis.YAxisMin
    '        '        objfrmChangeScale.SpectrumParameter.YaxisMax = AASGraphAnalysis.YAxisMax
    '        '        '------------------------
    '        '        If objfrmChangeScale.ShowDialog() = DialogResult.OK Then
    '        '            If Not objfrmChangeScale.SpectrumParameter Is Nothing Then
    '        '                mobjParameters.XaxisMax = objfrmChangeScale.SpectrumParameter.XaxisMax
    '        '                mobjParameters.XaxisMin = objfrmChangeScale.SpectrumParameter.XaxisMin
    '        '                mobjParameters.YaxisMax = objfrmChangeScale.SpectrumParameter.YaxisMax
    '        '                mobjParameters.YaxisMin = objfrmChangeScale.SpectrumParameter.YaxisMin
    '        '            End If
    '        '            AASGraphAnalysis.XAxisMin = mobjParameters.XaxisMin
    '        '            AASGraphAnalysis.XAxisMax = mobjParameters.XaxisMax
    '        '            AASGraphAnalysis.YAxisMin = mobjParameters.YaxisMin
    '        '            AASGraphAnalysis.YAxisMax = mobjParameters.YaxisMax

    '        '            Call gobjClsAAS203.Calculate_Analysis_Graph_Param(AASGraphAnalysis, ClsAAS203.enumChangeAxis.xyAxis)

    '        '        End If
    '        '        objfrmChangeScale.Close()


    '        '    Catch ex As Exception
    '        '        '---------------------------------------------------------
    '        '        'Error Handling and logging
    '        '        gobjErrorHandler.ErrorDescription = ex.Message
    '        '        gobjErrorHandler.ErrorMessage = ex.Message
    '        '        gobjErrorHandler.WriteErrorLog(ex)
    '        '        '---------------------------------------------------------
    '        '    Finally
    '        '        '---------------------------------------------------------
    '        '        'Writing Execution log
    '        '        If CONST_CREATE_EXECUTION_LOG = 1 Then
    '        '            gobjErrorHandler.WriteExecutionLog()
    '        '        End If
    '        '        objfrmChangeScale.Dispose()
    '        '        If Not objWait Is Nothing Then
    '        '            objWait.Dispose()
    '        '        End If
    '        '        'mblnAvoidProcessing = False
    '        '        '---------------------------------------------------------
    '        '    End Try
    '        'End Sub

    '        'Private Sub tlbbtnExportReport_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    '        '    '=====================================================================
    '        '    ' Procedure Name        : tlbbtnExportReport_Click
    '        '    ' Parameters Passed     : Object, EventArgs
    '        '    ' Returns               : 
    '        '    ' Purpose               : 
    '        '    ' Description           : 
    '        '    ' Assumptions           : 
    '        '    ' Dependencies          : 
    '        '    ' Author                : Saurabh S & Sachin Dokhale
    '        '    ' Created               : 05.10.06
    '        '    ' Revisions             : 
    '        '    '=====================================================================
    '        '    Dim objWait As New CWaitCursor
    '        '    Dim intSelectId As Integer
    '        '    Dim intCount As Integer
    '        '    Try
    '        '        'Added By Pankaj Fri 18 May 07
    '        '        If (gstructSettings.Enable21CFR = True) Then
    '        '            If Not funcCheckActivityAuthentication(enumActivityAuthentication.Export, gstructUserDetails.Access) Then
    '        '                Return
    '        '                Exit Sub
    '        '            End If
    '        '            gfuncInsertActivityLog(EnumModules.Export, "Export Accessed")
    '        '        End If

    '        '        '    tlbbtnLoad.SuspendEvents()
    '        '        'mobjClsDataFileReport.MethodID = mintSelectedMethodID
    '        '        'mobjClsDataFileReport.RunNumber = mintSelectedRunNumber
    '        '        'For intCount = 0 To gobjMethodCollection.Count - 1
    '        '        '    If mintSelectedMethodID = gobjMethodCollection(intCount).MethodID Then
    '        '        '        intSelectId = intCount
    '        '        '        mobjClsDataFileReport.MethodID = intCount
    '        '        '        Exit For
    '        '        '    End If
    '        '        'Next
    '        '        Dim strRunNo As String
    '        '        'strRunNo = mobjClsMethod.QuantitativeDataCollection.Item(intCount).RunNumber


    '        '        For intCount = 0 To gobjMethodCollection.Count - 1
    '        '            If mintSelectedMethodID = gobjMethodCollection(intCount).MethodID Then
    '        '                'intSelectIDIndex = intCount
    '        '                intSelectId = intCount
    '        '                'mobjClsDataFileReport.MethodID = intCount
    '        '                mobjClsDataFileReport.MethodID = gobjMethodCollection(intCount).MethodID
    '        '                Exit For
    '        '            End If
    '        '        Next
    '        '        strRunNo = gobjNewMethod.QuantitativeDataCollection.Item(0).RunNumber
    '        '        For intCount = 0 To gobjMethodCollection(intSelectId).QuantitativeDataCollection.Count - 1
    '        '            If strRunNo = CInt(gobjMethodCollection(intSelectId).QuantitativeDataCollection(intCount).RunNumber) Then
    '        '                mobjClsDataFileReport.RunNumber = CLng(strRunNo)
    '        '                Exit For
    '        '            End If
    '        '        Next

    '        '        'For intCount = 0 To gobjMethodCollection(intSelectId).QuantitativeDataCollection.Count - 1
    '        '        '    If mintSelectedRunNumber = CInt(gobjMethodCollection(intSelectId).QuantitativeDataCollection(intCount).RunNumber) Then

    '        '        '        mobjClsDataFileReport.RunNumber = mintSelectedRunNumber
    '        '        '        Exit For
    '        '        '    End If
    '        '        'Next
    '        '        'Call mobjClsDataFileReport.funcDatafileExport()

    '        '    Catch ex As Exception
    '        '        '---------------------------------------------------------
    '        '        'Error Handling and logging
    '        '        gobjErrorHandler.ErrorDescription = ex.Message
    '        '        gobjErrorHandler.ErrorMessage = ex.Message
    '        '        gobjErrorHandler.WriteErrorLog(ex)
    '        '        '---------------------------------------------------------
    '        '    Finally
    '        '        '---------------------------------------------------------
    '        '        'Writing Execution log
    '        '        If CONST_CREATE_EXECUTION_LOG = 1 Then
    '        '            gobjErrorHandler.WriteExecutionLog()
    '        '        End If
    '        '        If Not objWait Is Nothing Then
    '        '            objWait.Dispose()
    '        '        End If
    '        '        '---------------------------------------------------------
    '        '    End Try
    '        'End Sub


    '        'Private Sub btnExtinguish_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExtinguish.Click
    '        '    '=====================================================================
    '        '    ' Procedure Name        : btnExtinguish_Click
    '        '    ' Parameters Passed     : Object, EventArgs
    '        '    ' Returns               : None
    '        '    ' Purpose               : 
    '        '    ' Description           : 
    '        '    ' Assumptions           : 
    '        '    ' Dependencies          : 
    '        '    ' Author                : Mangesh Shardul
    '        '    ' Created               : 18-Feb-2007 03:15 pm
    '        '    ' Revisions             : 1
    '        '    '=====================================================================
    '        '    Try
    '        '        'RemoveHandler mnuExtinguish.Click, AddressOf btnExtinguish_Click

    '        '        If Not gstructSettings.AppMode = EnumAppMode.DemoMode Then
    '        '            If Not IsNothing(gobjMain.mobjfrmAnalysis) Then gobjMain.mobjfrmAnalysis.tmrAspirationMsg.Enabled = False
    '        '            gobjMain.mobjController.Cancel()
    '        '            Application.DoEvents()
    '        '            Call gobjClsAAS203.funcIgnite(False)
    '        '        Else
    '        '            Call gobjMessageAdapter.ShowMessage("Flame Extinguished", "AUTO EXTINGUISH", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage)
    '        '            Application.DoEvents()
    '        '        End If

    '        '    Catch ex As Exception
    '        '        '---------------------------------------------------------
    '        '        'Error Handling and logging
    '        '        gobjErrorHandler.ErrorDescription = ex.Message
    '        '        gobjErrorHandler.ErrorMessage = ex.Message
    '        '        gobjErrorHandler.WriteErrorLog(ex)
    '        '        '---------------------------------------------------------
    '        '    Finally
    '        '        '---------------------------------------------------------
    '        '        'Writing Execution log
    '        '        If CONST_CREATE_EXECUTION_LOG = 1 Then
    '        '            gobjErrorHandler.WriteExecutionLog()
    '        '        End If
    '        '        If Not gstructSettings.AppMode = EnumAppMode.DemoMode Then
    '        '            If Not IsNothing(gobjMain.mobjfrmAnalysis) Then gobjMain.mobjfrmAnalysis.tmrAspirationMsg.Enabled = True
    '        '            gobjMain.mobjController.Start(gobjclsBgFlameStatus)
    '        '            Application.DoEvents()
    '        '        End If
    '        '        'AddHandler mnuExtinguish.Click, AddressOf btnExtinguish_Click
    '        '        '---------------------------------------------------------
    '        '    End Try
    '        'End Sub

    '        'Private Sub btnIgnite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIgnite.Click
    '        '    '=====================================================================
    '        '    ' Procedure Name        : btnAutoIgnition_Click
    '        '    ' Parameters Passed     : Object, EventArgs
    '        '    ' Returns               : None
    '        '    ' Purpose               : 
    '        '    ' Description           : 
    '        '    ' Assumptions           : 
    '        '    ' Dependencies          : 
    '        '    ' Author                : Mangesh Shardul
    '        '    ' Created               : 18-Feb-2007 03:15 pm
    '        '    ' Revisions             : 1
    '        '    '=====================================================================
    '        '    Try
    '        '        'RemoveHandler mnuIgnite.Click, AddressOf btnAutoIgnition_Click

    '        '        If Not gstructSettings.AppMode = EnumAppMode.DemoMode Then
    '        '            If Not IsNothing(gobjMain.mobjfrmAnalysis) Then gobjMain.mobjfrmAnalysis.tmrAspirationMsg.Enabled = False
    '        '            Call gobjMain.mobjController.Cancel()
    '        '            Call Application.DoEvents()
    '        '            Call gobjCommProtocol.mobjCommdll.subTime_Delay(100)
    '        '            Call gobjClsAAS203.funcIgnite(True)

    '        '        Else
    '        '            Call gobjMessageAdapter.ShowMessage("Flame Ignited", "AUTO IGNITION", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage)
    '        '            Call Application.DoEvents()
    '        '        End If

    '        '    Catch ex As Exception
    '        '        '---------------------------------------------------------
    '        '        'Error Handling and logging
    '        '        gobjErrorHandler.ErrorDescription = ex.Message
    '        '        gobjErrorHandler.ErrorMessage = ex.Message
    '        '        gobjErrorHandler.WriteErrorLog(ex)
    '        '        '---------------------------------------------------------
    '        '    Finally
    '        '        '---------------------------------------------------------
    '        '        'Writing Execution log
    '        '        If CONST_CREATE_EXECUTION_LOG = 1 Then
    '        '            gobjErrorHandler.WriteExecutionLog()
    '        '        End If
    '        '        If Not gstructSettings.AppMode = EnumAppMode.DemoMode Then
    '        '            If Not IsNothing(gobjMain.mobjfrmAnalysis) Then gobjMain.mobjfrmAnalysis.tmrAspirationMsg.Enabled = True
    '        '            gobjMain.mobjController.Start(gobjclsBgFlameStatus)
    '        '            Application.DoEvents()
    '        '        End If
    '        '        'AddHandler mnuIgnite.Click, AddressOf btnAutoIgnition_Click
    '        '        '---------------------------------------------------------
    '        '    End Try
    '        'End Sub

    '        'Private Sub tlbbtnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        '    '=====================================================================
    '        '    ' Procedure Name        : tlbbtnBack_Click
    '        '    ' Parameters Passed     : Object,EventArgs
    '        '    ' Returns               : None
    '        '    ' Purpose               : To exit frmAnalysis and load frmMDIMain form
    '        '    ' Description           : 
    '        '    ' Assumptions           : 
    '        '    ' Dependencies          : 
    '        '    ' Author                : Saurabh S
    '        '    ' Created               : 25.09.06
    '        '    ' Revisions             : 
    '        '    '=====================================================================
    '        '    Dim objWait As New CWaitCursor
    '        '    Try
    '        '        'tlbbtnBack.SuspendEvents()
    '        '        Me.Close()

    '        '    Catch ex As Exception
    '        '        '---------------------------------------------------------
    '        '        'Error Handling and logging
    '        '        gobjErrorHandler.ErrorDescription = ex.Message
    '        '        gobjErrorHandler.ErrorMessage = ex.Message
    '        '        gobjErrorHandler.WriteErrorLog(ex)
    '        '        '---------------------------------------------------------
    '        '    Finally
    '        '        '---------------------------------------------------------
    '        '        'Writing Execution log
    '        '        If CONST_CREATE_EXECUTION_LOG = 1 Then
    '        '            gobjErrorHandler.WriteExecutionLog()
    '        '        End If
    '        '        If Not objWait Is Nothing Then
    '        '            objWait.Dispose()
    '        '        End If
    '        '        'tlbbtnBack.ResumeEvents()
    '        '        '---------------------------------------------------------
    '        '    End Try
    '        'End Sub

    '        'Private Sub tlbbtnStandardGraph_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        '    '=====================================================================
    '        '    ' Procedure Name        : tlbbtnStandardGraph_Click
    '        '    ' Parameters Passed     : Object, EventArgs
    '        '    ' Returns               : None
    '        '    ' Purpose               : 
    '        '    ' Description           : 
    '        '    ' Assumptions           : 
    '        '    ' Dependencies          : 
    '        '    ' Author                : Mangesh Shardul
    '        '    ' Created               : 17-Jan-2007 03:25 pm
    '        '    ' Revisions             : 1
    '        '    '=====================================================================
    '        '    'case IDC_QASTDGRAPH:
    '        '    '   if (StdAnalysed || ManualEntry){
    '        '    '       If (Create_Standard_Sample_Curve(hwnd, False)) Then
    '        '    '           toreported=TRUE;
    '        '    '   }
    '        '    'break;

    '        '    Dim objWait As New CWaitCursor

    '        '    Try
    '        '        'tlbbtnStandardGraph.SuspendEvents()

    '        '        If StdAnalysed Then 'Or ManualEntry Then
    '        '            If gobjclsStandardGraph.Create_Standard_Sample_Curve(False, True, 0, 0, gobjNewMethod) Then
    '        '                toreported = True
    '        '            End If
    '        '        End If

    '        '    Catch ex As Exception
    '        '        '---------------------------------------------------------
    '        '        'Error Handling and logging
    '        '        gobjErrorHandler.ErrorDescription = ex.Message
    '        '        gobjErrorHandler.ErrorMessage = ex.Message
    '        '        gobjErrorHandler.WriteErrorLog(ex)
    '        '        '---------------------------------------------------------
    '        '    Finally
    '        '        '---------------------------------------------------------
    '        '        'Writing Execution log
    '        '        If CONST_CREATE_EXECUTION_LOG = 1 Then
    '        '            gobjErrorHandler.WriteExecutionLog()
    '        '        End If
    '        '        objWait.Dispose()
    '        '        'tlbbtnStandardGraph.ResumeEvents()
    '        '        '---------------------------------------------------------
    '        '    End Try
    '        'End Sub

    '        'Private Sub tlbbtnSampleGraph_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        '    '=====================================================================
    '        '    ' Procedure Name        : tlbbtnSampleGraph_Click
    '        '    ' Parameters Passed     : Object, EventArgs
    '        '    ' Returns               : None
    '        '    ' Purpose               : 
    '        '    ' Description           : 
    '        '    ' Assumptions           : 
    '        '    ' Dependencies          : 
    '        '    ' Author                : Mangesh Shardul
    '        '    ' Created               : 17-Jan-2007 03:25 pm
    '        '    ' Revisions             : 1
    '        '    '=====================================================================
    '        '    'case IDC_QASAMPGRAPH:
    '        '    '   if (StdAnalysed || ManualEntry){
    '        '    '       If (Create_Standard_Sample_Curve(hwnd, TRUE)) Then
    '        '    '	        toreported=TRUE;
    '        '    '   }
    '        '    '   break;

    '        '    Dim objWait As New CWaitCursor

    '        '    Try
    '        '        'tlbbtnSampleGraph.SuspendEvents()

    '        '        If StdAnalysed Then 'Or ManualEntry Then
    '        '            If gobjclsStandardGraph.Create_Standard_Sample_Curve(True, True, 0, 0, gobjNewMethod) Then
    '        '                toreported = True
    '        '            End If
    '        '        End If

    '        '    Catch ex As Exception
    '        '        '---------------------------------------------------------
    '        '        'Error Handling and logging
    '        '        gobjErrorHandler.ErrorDescription = ex.Message
    '        '        gobjErrorHandler.ErrorMessage = ex.Message
    '        '        gobjErrorHandler.WriteErrorLog(ex)
    '        '        '---------------------------------------------------------
    '        '    Finally
    '        '        '---------------------------------------------------------
    '        '        'Writing Execution log
    '        '        If CONST_CREATE_EXECUTION_LOG = 1 Then
    '        '            gobjErrorHandler.WriteExecutionLog()
    '        '        End If
    '        '        If Not objWait Is Nothing Then
    '        '            objWait.Dispose()
    '        '        End If
    '        '        'tlbbtnSampleGraph.ResumeEvents()
    '        '        '---------------------------------------------------------
    '        '    End Try
    '        'End Sub

    '        'Private Sub tlbbtnViewResults_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        '    '=====================================================================
    '        '    ' Procedure Name        : tlbbtnViewResults_Click
    '        '    ' Parameters Passed     : Object, EventArgs
    '        '    ' Returns               : None
    '        '    ' Purpose               : 
    '        '    ' Description           : 
    '        '    ' Assumptions           : 
    '        '    ' Dependencies          : 
    '        '    ' Author                : Mangesh Shardul
    '        '    ' Created               : 17-Jan-2007 03:25 pm
    '        '    ' Revisions             : 1
    '        '    '=====================================================================
    '        '    'case IDC_QARESULTS:
    '        '    'if (StdAnalysed||AnaOver ||Started ||ManualEntry)
    '        '    ' OnViewResults(hwnd);
    '        '    'break;

    '        '    Dim objWait As New CWaitCursor

    '        '    Try
    '        '        'tlbbtnViewResults.SuspendEvents()

    '        '        If StdAnalysed Or AnaOver Or mblnIsAnalysisStarted Then 'Or ManualEntry Then
    '        '            OnViewResults()
    '        '        End If

    '        '    Catch ex As Exception
    '        '        '---------------------------------------------------------
    '        '        'Error Handling and logging
    '        '        gobjErrorHandler.ErrorDescription = ex.Message
    '        '        gobjErrorHandler.ErrorMessage = ex.Message
    '        '        gobjErrorHandler.WriteErrorLog(ex)
    '        '        '---------------------------------------------------------
    '        '    Finally
    '        '        '---------------------------------------------------------
    '        '        'Writing Execution log
    '        '        If CONST_CREATE_EXECUTION_LOG = 1 Then
    '        '            gobjErrorHandler.WriteExecutionLog()
    '        '        End If
    '        '        If Not objWait Is Nothing Then
    '        '            objWait.Dispose()
    '        '        End If
    '        '        'tlbbtnViewResults.ResumeEvents()
    '        '        '---------------------------------------------------------
    '        '    End Try
    '        'End Sub

    '        'Private Sub tlbbtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        '    '=====================================================================
    '        '    ' Procedure Name        : tlbbtnReports_Click
    '        '    ' Parameters Passed     : Object, EventArgs
    '        '    ' Returns               : None
    '        '    ' Purpose               : 
    '        '    ' Description           : 
    '        '    ' Assumptions           : 
    '        '    ' Dependencies          : 
    '        '    ' Author                : Mangesh Shardul
    '        '    ' Created               : 17-Jan-2007 03:25 pm
    '        '    ' Revisions             : 1
    '        '    '=====================================================================

    '        '    'case IDC_QAREPORT:
    '        '    '   if (toreported||!Method->RepReady )
    '        '    '	{
    '        '    '	    SaveQuantResults(hwnd, Method, A1,0);
    '        '    '	    toreported=FALSE;
    '        '    '	}
    '        '    '	if (Method->RepReady )
    '        '    '	    OnReportPrint(hwnd, Method);
    '        '    '   break;

    '        '    Dim objWait As New CWaitCursor
    '        '    Dim A1() As Double = {0, 0, 0, 0, 0, 0}

    '        '    Try
    '        '        'tlbbtnReports.SuspendEvents()

    '        '        If (toreported) Then 'OR NOT Method->RepReady )
    '        '            gobjClsAAS203.SaveQuantResults(gobjNewMethod, A1, False)
    '        '            toreported = False
    '        '        End If

    '        '        'if (gobjNewMethod.RepReady )
    '        '        '   OnReportPrint(gobjNewMethod)
    '        '        'end if

    '        '    Catch ex As Exception
    '        '        '---------------------------------------------------------
    '        '        'Error Handling and logging
    '        '        gobjErrorHandler.ErrorDescription = ex.Message
    '        '        gobjErrorHandler.ErrorMessage = ex.Message
    '        '        gobjErrorHandler.WriteErrorLog(ex)
    '        '        '---------------------------------------------------------
    '        '    Finally
    '        '        '---------------------------------------------------------
    '        '        'Writing Execution log
    '        '        If CONST_CREATE_EXECUTION_LOG = 1 Then
    '        '            gobjErrorHandler.WriteExecutionLog()
    '        '        End If
    '        '        If Not objWait Is Nothing Then
    '        '            objWait.Dispose()
    '        '        End If
    '        '        'tlbbtnReports.ResumeEvents()
    '        '        '---------------------------------------------------------
    '        '    End Try
    '        'End Sub

    '        'Private Sub tlbbtnReports_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        '    '=====================================================================
    '        '    ' Procedure Name        : tlbbtnReports_Click
    '        '    ' Parameters Passed     : Object, EventArgs
    '        '    ' Returns               : None
    '        '    ' Purpose               : 
    '        '    ' Description           : 
    '        '    ' Assumptions           : 
    '        '    ' Dependencies          : 
    '        '    ' Author                : Mangesh Shardul
    '        '    ' Created               : 17-Jan-2007 03:25 pm
    '        '    ' Revisions             : 1
    '        '    '=====================================================================

    '        '    'case IDC_QAREPORT:
    '        '    '   if (toreported||!Method->RepReady )
    '        '    '	{
    '        '    '	    SaveQuantResults(hwnd, Method, A1,0);
    '        '    '	    toreported=FALSE;
    '        '    '	}
    '        '    '	if (Method->RepReady )
    '        '    '	    OnReportPrint(hwnd, Method);
    '        '    '   break;

    '        '    Dim objWait As New CWaitCursor
    '        '    Dim objClsDataFileReport As New clsDataFileReport
    '        '    Dim intSelectIDIndex As Integer
    '        '    Dim intCount As Integer
    '        '    Dim intSelectedRunNumber As Integer
    '        '    Dim intSelectedMethodID As Integer
    '        '    Dim A1() As Double = {0, 0, 0, 0, 0, 0}

    '        '    Try

    '        '        'If toreported Then
    '        '        '-----Added By Pankaj Fri 18 May 07
    '        '        If (gstructSettings.Enable21CFR = True) Then
    '        '            If Not funcCheckActivityAuthentication(enumActivityAuthentication.Print, gstructUserDetails.Access) Then
    '        '                Return
    '        '                Exit Sub
    '        '            End If
    '        '            gfuncInsertActivityLog(EnumModules.Print, "Print Analysis Report Accessed")
    '        '        End If
    '        '        '------
    '        '        'tlbbtnLoad.SuspendEvents()
    '        '        'tlbbtnReports.SuspendEvents()
    '        '        If (toreported) Then 'OR NOT Method->RepReady )
    '        '            gobjClsAAS203.SaveQuantResults(gobjNewMethod, A1, False)
    '        '            toreported = False
    '        '        End If

    '        '        '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    '        '        '----Be Careful NOT TO USE index to assign MethodID or RunNumber
    '        '        '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    '        '        If StdAnalysed Or AnaOver Or mblnIsAnalysisStarted Then
    '        '            If Not (gobjNewMethod Is Nothing) Then
    '        '                For intCount = 0 To gobjMethodCollection.Count - 1
    '        '                    If gobjNewMethod.MethodID = gobjMethodCollection(intCount).MethodID Then
    '        '                        intSelectIDIndex = intCount
    '        '                        'mobjClsDataFileReport.MethodID = intCount
    '        '                        objClsDataFileReport.MethodID = gobjMethodCollection(intCount).MethodID
    '        '                        Exit For
    '        '                    End If
    '        '                Next
    '        '                'intSelectedRunNumber = GetRunNo(gobjNewMethod)

    '        '                objClsDataFileReport.RunNumber = gobjMethodCollection(intCount).QuantitativeDataCollection(mintRunNumberIndex).RunNumber   'intSelectedRunNumber - 1
    '        '                'For intCount = 0 To gobjMethodCollection(intSelectIDIndex).QuantitativeDataCollection.Count - 1
    '        '                '    If intSelectedRunNumber = CInt(gobjMethodCollection(intSelectIDIndex).QuantitativeDataCollection(intCount).RunNumber) Then
    '        '                '        objClsDataFileReport.RunNumber = intCount
    '        '                '        Exit For
    '        '                '    End If
    '        '                'Next

    '        '                objClsDataFileReport.DefaultFont = Me.DefaultFont
    '        '                Call objClsDataFileReport.funcDatafilePrint()
    '        '            End If
    '        '        End If
    '        '    Catch ex As Exception
    '        '        '---------------------------------------------------------
    '        '        'Error Handling and logging
    '        '        gobjErrorHandler.ErrorDescription = ex.Message
    '        '        gobjErrorHandler.ErrorMessage = ex.Message
    '        '        gobjErrorHandler.WriteErrorLog(ex)
    '        '        '---------------------------------------------------------
    '        '    Finally
    '        '        '---------------------------------------------------------
    '        '        'Writing Execution log
    '        '        If CONST_CREATE_EXECUTION_LOG = 1 Then
    '        '            gobjErrorHandler.WriteExecutionLog()
    '        '        End If
    '        '        If Not objWait Is Nothing Then
    '        '            objWait.Dispose()
    '        '        End If
    '        '        'tlbbtnReports.ResumeEvents()
    '        '        '---------------------------------------------------------
    '        '    End Try
    '        'End Sub

    '        'Private Sub tlbbtnPrintGraph_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        '    '=====================================================================
    '        '    ' Procedure Name        : tlbbtnPrintGraph_Click
    '        '    ' Parameters Passed     : Object, EventArgs
    '        '    ' Returns               : None
    '        '    ' Purpose               : 
    '        '    ' Description           : 
    '        '    ' Assumptions           : 
    '        '    ' Dependencies          : 
    '        '    ' Author                : Sachin Dokhale
    '        '    ' Created               : 17-May-2007 03:25 pm
    '        '    ' Revisions             : 1
    '        '    '=====================================================================



    '        '    Dim objWait As New CWaitCursor
    '        '    Dim A1() As Double = {0, 0, 0, 0, 0, 0}

    '        '    Try
    '        '        '-----Added By Pankaj Fri 18 May 07
    '        '        If (gstructSettings.Enable21CFR = True) Then
    '        '            If Not funcCheckActivityAuthentication(enumActivityAuthentication.Print, gstructUserDetails.Access) Then
    '        '                Return
    '        '                Exit Sub
    '        '            End If
    '        '            gfuncInsertActivityLog(EnumModules.Print, "Print Analysis Graph Accessed")
    '        '        End If
    '        '        '------

    '        '        'If (toreported) Then 'OR NOT Method->RepReady )
    '        '        '    gobjClsAAS203.SaveQuantResults(gobjNewMethod, A1, False)
    '        '        '    toreported = False

    '        '        'End If
    '        '        If StdAnalysed Or AnaOver Or mblnIsAnalysisStarted Then
    '        '            'AASGraphAnalysis.PrintPreViewGraph()
    '        '        End If
    '        '        'if (gobjNewMethod.RepReady )
    '        '        '   OnReportPrint(gobjNewMethod)
    '        '        'end if

    '        '    Catch ex As Exception
    '        '        '---------------------------------------------------------
    '        '        'Error Handling and logging
    '        '        gobjErrorHandler.ErrorDescription = ex.Message
    '        '        gobjErrorHandler.ErrorMessage = ex.Message
    '        '        gobjErrorHandler.WriteErrorLog(ex)
    '        '        '---------------------------------------------------------
    '        '    Finally
    '        '        '---------------------------------------------------------
    '        '        'Writing Execution log
    '        '        If CONST_CREATE_EXECUTION_LOG = 1 Then
    '        '            gobjErrorHandler.WriteExecutionLog()
    '        '        End If
    '        '        If Not objWait Is Nothing Then
    '        '            objWait.Dispose()
    '        '        End If
    '        '        'tlbbtnSampleGraph.ResumeEvents()
    '        '        '---------------------------------------------------------
    '        '    End Try
    '        'End Sub

    '        'Private Sub XpPanelStandardGraphClicked(ByVal sender As Object, ByVal e As System.EventArgs)
    '        '    '=====================================================================
    '        '    ' Procedure Name        : XpPanelStandardGraphClicked
    '        '    ' Parameters Passed     : Object,EventArgs
    '        '    ' Returns               : None
    '        '    ' Purpose               : To load the Standard Graph form
    '        '    ' Description           : 
    '        '    ' Assumptions           : 
    '        '    ' Dependencies          : 
    '        '    ' Author                : Deepak & Saurabh
    '        '    ' Created               : 05.10.06
    '        '    ' Revisions             : 
    '        '    '===================================================================== 
    '        '    Dim objWait As New CWaitCursor

    '        '    Try
    '        '        If Me.XpPanelStandardGraph.PanelState = UIComponents.XPPanelState.Collapsed Then
    '        '            Call funcCollapseAllXPPanels()
    '        '            Me.XpPanelStandardGraph.TogglePanelState()
    '        '            Me.XpPanelStandardGraph.PanelHeight = 80
    '        '        End If

    '        '    Catch ex As Exception
    '        '        '---------------------------------------------------------
    '        '        'Error Handling and logging
    '        '        gobjErrorHandler.ErrorDescription = ex.Message
    '        '        gobjErrorHandler.ErrorMessage = ex.Message
    '        '        gobjErrorHandler.WriteErrorLog(ex)
    '        '        '---------------------------------------------------------
    '        '    Finally
    '        '        '---------------------------------------------------------
    '        '        'Writing Execution log
    '        '        If CONST_CREATE_EXECUTION_LOG = 1 Then
    '        '            gobjErrorHandler.WriteExecutionLog()
    '        '        End If
    '        '        If Not objWait Is Nothing Then
    '        '            objWait.Dispose()
    '        '        End If
    '        '        '---------------------------------------------------------
    '        '    End Try
    '        'End Sub

    '        'Private Sub XpPanelSampleGraphClicked(ByVal sender As Object, ByVal e As System.EventArgs)
    '        '    '=====================================================================
    '        '    ' Procedure Name        : XpPanelSampleGraphClicked
    '        '    ' Parameters Passed     : Object,EventArgs
    '        '    ' Returns               : None
    '        '    ' Purpose               : To view the Sample Graphs
    '        '    ' Description           : 
    '        '    ' Assumptions           : 
    '        '    ' Dependencies          : 
    '        '    ' Author                : Deepak & Saurabh
    '        '    ' Created               : 05.10.06
    '        '    ' Revisions             : 
    '        '    '===================================================================== 
    '        '    Dim objWait As New CWaitCursor

    '        '    Try
    '        '        If Me.XpPanelSampleGraph.PanelState = UIComponents.XPPanelState.Collapsed Then
    '        '            Call funcCollapseAllXPPanels()
    '        '            Me.XpPanelSampleGraph.TogglePanelState()
    '        '            Me.XpPanelSampleGraph.PanelHeight = 90
    '        '        End If

    '        '    Catch ex As Exception
    '        '        '---------------------------------------------------------
    '        '        'Error Handling and logging
    '        '        gobjErrorHandler.ErrorDescription = ex.Message
    '        '        gobjErrorHandler.ErrorMessage = ex.Message
    '        '        gobjErrorHandler.WriteErrorLog(ex)
    '        '        '---------------------------------------------------------
    '        '    Finally
    '        '        '---------------------------------------------------------
    '        '        'Writing Execution log
    '        '        If CONST_CREATE_EXECUTION_LOG = 1 Then
    '        '            gobjErrorHandler.WriteExecutionLog()
    '        '        End If
    '        '        If Not objWait Is Nothing Then
    '        '            objWait.Dispose()
    '        '        End If
    '        '        '---------------------------------------------------------
    '        '    End Try
    '        'End Sub

    '        'Private Sub XpPanelViewResultsClicked(ByVal sender As Object, ByVal e As System.EventArgs)
    '        '    '=====================================================================
    '        '    ' Procedure Name        : XpPanelViewResultsClicked
    '        '    ' Parameters Passed     : Object,EventArgs
    '        '    ' Returns               : None
    '        '    ' Purpose               : To view the Results
    '        '    ' Description           : 
    '        '    ' Assumptions           : 
    '        '    ' Dependencies          : 
    '        '    ' Author                : Deepak & Saurabh
    '        '    ' Created               : 05.10.06
    '        '    ' Revisions             : 
    '        '    '===================================================================== 
    '        '    Dim objWait As New CWaitCursor

    '        '    Try
    '        '        If Me.XpPanelViewResults.PanelState = UIComponents.XPPanelState.Collapsed Then
    '        '            Call funcCollapseAllXPPanels()
    '        '            Me.XpPanelViewResults.TogglePanelState()
    '        '            Me.XpPanelViewResults.PanelHeight = 80
    '        '        End If

    '        '    Catch ex As Exception
    '        '        '---------------------------------------------------------
    '        '        'Error Handling and logging
    '        '        gobjErrorHandler.ErrorDescription = ex.Message
    '        '        gobjErrorHandler.ErrorMessage = ex.Message
    '        '        gobjErrorHandler.WriteErrorLog(ex)
    '        '        '---------------------------------------------------------
    '        '    Finally
    '        '        '---------------------------------------------------------
    '        '        'Writing Execution log
    '        '        If CONST_CREATE_EXECUTION_LOG = 1 Then
    '        '            gobjErrorHandler.WriteExecutionLog()
    '        '        End If
    '        '        If Not objWait Is Nothing Then
    '        '            objWait.Dispose()
    '        '        End If
    '        '        '---------------------------------------------------------
    '        '    End Try
    '        'End Sub

    '        'Private Sub XpPanelReportsClicked(ByVal sender As Object, ByVal e As System.EventArgs)
    '        '    '=====================================================================
    '        '    ' Procedure Name        : XpPanelReportsClicked
    '        '    ' Parameters Passed     : Object,EventArgs
    '        '    ' Returns               : None
    '        '    ' Purpose               : To view the Reports
    '        '    ' Description           : 
    '        '    ' Assumptions           : 
    '        '    ' Dependencies          : 
    '        '    ' Author                : Deepak & Saurabh
    '        '    ' Created               : 05.10.06
    '        '    ' Revisions             : 
    '        '    '===================================================================== 
    '        '    Dim objWait As New CWaitCursor
    '        '    Try
    '        '        If Me.XpPanelReports.PanelState = UIComponents.XPPanelState.Collapsed Then
    '        '            Call funcCollapseAllXPPanels()
    '        '            Me.XpPanelReports.TogglePanelState()
    '        '            Me.XpPanelReports.PanelHeight = 80
    '        '        End If

    '        '    Catch ex As Exception
    '        '        '---------------------------------------------------------
    '        '        'Error Handling and logging
    '        '        gobjErrorHandler.ErrorDescription = ex.Message
    '        '        gobjErrorHandler.ErrorMessage = ex.Message
    '        '        gobjErrorHandler.WriteErrorLog(ex)
    '        '        '---------------------------------------------------------
    '        '    Finally
    '        '        '---------------------------------------------------------
    '        '        'Writing Execution log
    '        '        If CONST_CREATE_EXECUTION_LOG = 1 Then
    '        '            gobjErrorHandler.WriteExecutionLog()
    '        '        End If
    '        '        If Not objWait Is Nothing Then
    '        '            objWait.Dispose()
    '        '        End If
    '        '        '---------------------------------------------------------
    '        '    End Try
    '        'End Sub

    '        'Private Sub AutoZero_Clicked(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        '    '=====================================================================
    '        '    ' Procedure Name        : AutoZero_Clicked
    '        '    ' Parameters Passed     : Object, EventArgs
    '        '    ' Returns               : None
    '        '    ' Purpose               : 
    '        '    ' Description           : 
    '        '    ' Assumptions           : 
    '        '    ' Dependencies          : 
    '        '    ' Author                : Mangesh Shardul
    '        '    ' Created               : 17-Jan-2007 03:25 pm
    '        '    ' Revisions             : 1
    '        '    '=====================================================================

    '        '    'case IDC_AUTOZERO:
    '        '    '   Auto_Zero(hwnd, FALSE);
    '        '    '   break;

    '        '    Try
    '        '        tmrAspirationMsg.Enabled = False
    '        '        gobjMain.mobjController.Cancel()
    '        '        Application.DoEvents()

    '        '        Call gobjClsAAS203.subAutoZero(False)

    '        '    Catch ex As Exception
    '        '        '---------------------------------------------------------
    '        '        'Error Handling and logging
    '        '        gobjErrorHandler.ErrorDescription = ex.Message
    '        '        gobjErrorHandler.ErrorMessage = ex.Message
    '        '        gobjErrorHandler.WriteErrorLog(ex)
    '        '        '---------------------------------------------------------
    '        '    Finally
    '        '        '---------------------------------------------------------
    '        '        'Writing Execution log
    '        '        If CONST_CREATE_EXECUTION_LOG = 1 Then
    '        '            gobjErrorHandler.WriteExecutionLog()
    '        '        End If
    '        '        tmrAspirationMsg.Enabled = True
    '        '        gobjMain.mobjController.Start(gobjclsBgFlameStatus)
    '        '        Application.DoEvents()
    '        '        '---------------------------------------------------------
    '        '    End Try
    '        'End Sub

    '        'Private Sub ManualSetup_Clicked(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        '    '=====================================================================
    '        '    ' Procedure Name        : ManualSetup_Clicked
    '        '    ' Parameters Passed     : Object, EventArgs
    '        '    ' Returns               : None
    '        '    ' Purpose               : 
    '        '    ' Description           : 
    '        '    ' Assumptions           : 
    '        '    ' Dependencies          : 
    '        '    ' Author                : Mangesh Shardul
    '        '    ' Created               : 17-Jan-2007 03:25 pm
    '        '    ' Revisions             : 1
    '        '    '=====================================================================
    '        '    Try
    '        '        tmrAspirationMsg.Enabled = False
    '        '        gobjMain.mobjController.Cancel()
    '        '        Application.DoEvents()

    '        '        '---Manual Optimization or Instrument Setup
    '        '        Call gobjClsAAS203.AbsorbanceScan()

    '        '        'gobjclsTimer.subTimerStart(StatusBar1)


    '        '    Catch ex As Exception
    '        '        '---------------------------------------------------------
    '        '        'Error Handling and logging
    '        '        gobjErrorHandler.ErrorDescription = ex.Message
    '        '        gobjErrorHandler.ErrorMessage = ex.Message
    '        '        gobjErrorHandler.WriteErrorLog(ex)
    '        '        '---------------------------------------------------------
    '        '    Finally
    '        '        '---------------------------------------------------------
    '        '        'Writing Execution log
    '        '        If CONST_CREATE_EXECUTION_LOG = 1 Then
    '        '            gobjErrorHandler.WriteExecutionLog()
    '        '        End If
    '        '        tmrAspirationMsg.Enabled = True
    '        '        gobjMain.mobjController.Start(gobjclsBgFlameStatus)
    '        '        Application.DoEvents()
    '        '        '---------------------------------------------------------
    '        '    End Try
    '        'End Sub

    '        'Private Sub ReOptimizeInstrument_Clicked(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        '    '=====================================================================
    '        '    ' Procedure Name        : ReOptimizeInstrument_Clicked
    '        '    ' Parameters Passed     : Object, EventArgs
    '        '    ' Returns               : None
    '        '    ' Purpose               : ReOptimize Wavelength i.e. Find Analytical Peak Again
    '        '    ' Description           : 
    '        '    ' Assumptions           : 
    '        '    ' Dependencies          : 
    '        '    ' Author                : Mangesh Shardul
    '        '    ' Created               : 17-Jan-2007 03:25 pm
    '        '    ' Revisions             : 1
    '        '    '=====================================================================
    '        '    '---ReOptimize Wavelength i.e. Find Analytical Peak Again
    '        '    'case IDC_OPTIMIZE:
    '        '    '   Method->Aas.OptimseFlag=FALSE;
    '        '    '   CheckInstrumentOptimisation(hwnd);
    '        '    '   break;

    '        '    Try
    '        '        tmrAspirationMsg.Enabled = False
    '        '        gobjMain.mobjController.Cancel()
    '        '        gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay)   '10.12.07
    '        '        Application.DoEvents()


    '        '        'gobjNewMethod.InstrumentConditions.item(mintSelectedInstrumentConditionIndex).IsOptimize = False
    '        '        gobjNewMethod.InstrumentCondition.IsOptimize = False

    '        '        Call CheckInstrumentOptimisation()

    '        '    Catch ex As Exception
    '        '        '---------------------------------------------------------
    '        '        'Error Handling and logging
    '        '        gobjErrorHandler.ErrorDescription = ex.Message
    '        '        gobjErrorHandler.ErrorMessage = ex.Message
    '        '        gobjErrorHandler.WriteErrorLog(ex)
    '        '        '---------------------------------------------------------
    '        '    Finally
    '        '        '---------------------------------------------------------
    '        '        'Writing Execution log
    '        '        If CONST_CREATE_EXECUTION_LOG = 1 Then
    '        '            gobjErrorHandler.WriteExecutionLog()
    '        '        End If
    '        '        tmrAspirationMsg.Enabled = True
    '        '        gobjMain.mobjController.Start(gobjclsBgFlameStatus)
    '        '        Application.DoEvents()
    '        '        '---------------------------------------------------------
    '        '    End Try
    '        'End Sub

    '        'Private Sub RepeatLastAnalysis_Clicked(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        '    '=====================================================================
    '        '    ' Procedure Name        : RepeatLastAnalysis_Clicked
    '        '    ' Parameters Passed     : Object, EventArgs
    '        '    ' Returns               : None
    '        '    ' Purpose               : 
    '        '    ' Description           : 
    '        '    ' Assumptions           : 
    '        '    ' Dependencies          : 
    '        '    ' Author                : Mangesh Shardul
    '        '    ' Created               : 17-Jan-2007 03:25 pm
    '        '    ' Revisions             : 1
    '        '    '=====================================================================
    '        '    '**************************************************************
    '        '    'case IDC_QARPT:
    '        '    '   if(LSampType != BLANK )
    '        '    '	    CurRepeat--;
    '        '    '	if(CurRepeat <= 0 ){
    '        '    '	    if(LSampType == SAMP)
    '        '    '		    CurRepeat = Method->QuantData->Param.Repeat; //mdf by sss
    '        '    '		if(LSampType == STD)
    '        '    '		    CurRepeat = Method->QuantData->Param.ConcRepeat; //mdf by sss
    '        '    '	}
    '        '    '	if (SampType==BLANK && LSampType==BLANK){
    '        '    '	    if (CurStd==NULL){
    '        '    '		    SampType=SAMP;
    '        '    '       }
    '        '    '		else{
    '        '    '		    SampType=STD;
    '        '    '       }
    '        '    '   }
    '        '    '	else{
    '        '    '	    SampType=LSampType;
    '        '    '	}
    '        '    '	if (SampType==SAMP){
    '        '    '       CurSamp = GetPrevSamp(Method->QuantData->SampTopData, CurSamp);
    '        '    '	}
    '        '    '	if (SampType==STD)
    '        '    '	    CurStd = GetPrevStd(Method->QuantData->StdTopData, CurStd);
    '        '    '	if (SampType==BLANK){
    '        '    '	    if (CurStd==NULL)
    '        '    '		    LSampType=SAMP;
    '        '    '       Else
    '        '    '		    LSampType=BLANK;
    '        '    '	}
    '        '    '	else
    '        '    '	    LSampType=BLANK;
    '        '    'EnableWindow(GetDlgItem(hwnd,IDC_QARPT),FALSE);
    '        '    '**************************************************************
    '        '    Try
    '        '        'Added By Pankaj on 11 Jun 07 
    '        '        If funcMoveSampleEnumerator(mobjSampleEnumerator, intIEnumCollLocationSamp) = True Then
    '        '            mobjCurrentSample = CType(mobjSampleEnumerator.Current, Method.clsAnalysisSampleParameters)
    '        '        End If
    '        '        If funcMoveEnumerator(mobjStandardEnumerator, intIEnumCollLocationStd) = True Then
    '        '            mobjCurrentStandard = CType(mobjStandardEnumerator.Current, Method.clsAnalysisStdParameters)
    '        '        End If

    '        '        '-----
    '        '        If (LSampType <> ClsAAS203.enumSampleType.BLANK) Then
    '        '            CurRepeat -= 1
    '        '        End If

    '        '        If (CurRepeat <= 0) Then
    '        '            If (LSampType = ClsAAS203.enumSampleType.SAMPLE) Then
    '        '                'CurRepeat = Method->QuantData->Param.Repeat
    '        '                CurRepeat = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfSampleRepeats
    '        '            End If
    '        '            If (LSampType = ClsAAS203.enumSampleType.STANDARD) Then
    '        '                'CurRepeat = Method->QuantData->Param.ConcRepeat
    '        '                CurRepeat = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfStdRepeats
    '        '            End If
    '        '        End If

    '        '        If (SampleType = ClsAAS203.enumSampleType.BLANK _
    '        '         And LSampType = ClsAAS203.enumSampleType.BLANK) Then

    '        '            If IsNothing(mobjCurrentStandard) Then
    '        '                SampleType = ClsAAS203.enumSampleType.SAMPLE
    '        '            Else
    '        '                SampleType = ClsAAS203.enumSampleType.STANDARD
    '        '            End If

    '        '        Else
    '        '            SampleType = LSampType
    '        '        End If
    '        '        '//--------

    '        '        '//------------
    '        '        If (SampleType = ClsAAS203.enumSampleType.SAMPLE) Then
    '        '            'mobjCurrentSample = GetPrevSamp(Method->QuantData->SampTopData, mobjCurrentSample  )
    '        '            mobjCurrentSample = GetPrevSamp(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection, mobjCurrentSample)
    '        '            mblnRepeatLastSample = True
    '        '        End If

    '        '        If (SampleType = ClsAAS203.enumSampleType.STANDARD) Then
    '        '            'mobjCurrentStandard = GetPrevStd(Method->QuantData->StdTopData,  mobjCurrentStandard )
    '        '            mobjCurrentStandard = GetPrevStd(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection, mobjCurrentStandard)
    '        '            mblnRepeatLastStd = True
    '        '        End If

    '        '        If (SampleType = ClsAAS203.enumSampleType.BLANK) Then
    '        '            If IsNothing(mobjCurrentStandard) Then
    '        '                LSampType = ClsAAS203.enumSampleType.SAMPLE
    '        '            Else
    '        '                LSampType = ClsAAS203.enumSampleType.BLANK
    '        '            End If
    '        '        Else
    '        '            LSampType = ClsAAS203.enumSampleType.BLANK
    '        '        End If

    '        '        'EnableWindow(GetDlgItem(hwnd,IDC_QARPT),FALSE);

    '        '        'tlbbtnRepeatLastAnalysis.Enabled = False
    '        '        'btnRepeatLast.Enabled = False

    '        '        Call Aspirate()

    '        '    Catch ex As Exception
    '        '        '---------------------------------------------------------
    '        '        'Error Handling and logging
    '        '        gobjErrorHandler.ErrorDescription = ex.Message
    '        '        gobjErrorHandler.ErrorMessage = ex.Message
    '        '        gobjErrorHandler.WriteErrorLog(ex)
    '        '        '---------------------------------------------------------
    '        '    Finally
    '        '        '---------------------------------------------------------
    '        '        'Writing Execution log
    '        '        If CONST_CREATE_EXECUTION_LOG = 1 Then
    '        '            gobjErrorHandler.WriteExecutionLog()
    '        '        End If
    '        '        '---------------------------------------------------------
    '        '    End Try
    '        'End Sub

    '        'Private Sub NewAnalysis_Clicked(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        '    'case	IDC_QANEW:
    '        '    '#If STD_ADDN Then
    '        '    '   endanalysis= FALSE;
    '        '    '#End If
    '        '    'DeleteAllRawData(FALSE);
    '        '    'mobjCurrentStandard  =Method->QuantData->StdTopData;
    '        '    'mobjCurrentSample =Method->QuantData->SampTopData;
    '        '    'CurRepeat=1;

    '        '    'if(mobjCurrentStandard!=NULL  && StdAnalysed)
    '        '    '{
    '        '    '   if(Method->QuantData->Param.Std_Addn)
    '        '    '	    i = IDNO;
    '        '    '	else{
    '        '    '       If (!methchange) Then        
    '        '    '		    i=MessageBox(hwnd,"Do you want to use the previous standards","INFORMATION", MB_ICONQUESTION | MB_YESNO);
    '        '    '		else
    '        '    '		    i=IDNO;
    '        '    '   }
    '        '    'if(i==IDNO)
    '        '    '   Clear_All_Abs_Std(Method->QuantData->StdTopData);
    '        '    'Else
    '        '    '   mobjCurrentStandard=NULL;
    '        '    '}
    '        '    'methchange = FALSE;	
    '        '    'if(!StdAnalysed) 
    '        '    '   Clear_All_Abs_Std(Method->QuantData->StdTopData);
    '        '    'Clear_All_Abs_Conc_Samp(Method->QuantData->SampTopData);
    '        '    'SampType=BLANK;
    '        '    'Xtime=0;Afirst=TRUE;
    '        '    '	
    '        '    'if(i==6)
    '        '    '   StdAnalysed =TRUE;
    '        '    'Else
    '        '    '	StdAnalysed =FALSE;
    '        '    'Method->RepReady=FALSE;
    '        '    'if (lParam!=100L){
    '        '    '   AppendMethod(Method, QALL);
    '        '    '	Method->QuantData->Fname =-1.0;
    '        '    '}
    '        '    'if (Method->QuantData->Fname<=0)
    '        '    '   GetRunNo(Method);
    '        '    'AnaGraph.Xmin=0; AnaGraph.Xmax=10*10.0;
    '        '    'Calculate_Analysis_Graph_Param(&AnaGraph);
    '        '    'AnaOver=FALSE;
    '        '    'if (hwnd){
    '        '    '   DisplayRunNo(hwnd);
    '        '    '	InvalidateRect(hwnd, NULL, TRUE);
    '        '    '}
    '        '    'Method->QuantData->cMode=-2;

    '        '    'EnableWindow(GetDlgItem(hwnd,IDC_QARPT),FALSE); // add by sss
    '        '    'if(Method->QuantData)
    '        '    '   aafname = Method->QuantData->Fname;
    '        '    'break;

    '        '    '*****************************************
    '        '    '---CODE BY MANGESH 
    '        '    '*****************************************
    '        '    'On NEW Analysis
    '        '    Dim dblFuelRatio As Double
    '        '    Dim objDlgResult As DialogResult

    '        '    Try
    '        '        '----added by deepak for new analysis on 28.04.07
    '        '        lblAbsorbance.Text = ""
    '        '        lblAverageAbsorbance.Text = ""
    '        '        lblCorrectedAbsorbance.Text = ""
    '        '        lblSampleID.Text = ""
    '        '        lblRepeatNo.Text = ""
    '        '        lblConcentration.Text = ""
    '        '        '------------------

    '        '        gobjclsStandardGraph = New clsStandardGraph

    '        '        '---Get the last RunNumber 

    '        '        If gobjNewMethod.QuantitativeDataCollection.Count > 0 Then
    '        '            mintRunNumberIndex = gobjNewMethod.QuantitativeDataCollection.Count - 1
    '        '        ElseIf gobjNewMethod.QuantitativeDataCollection.Count <= 0 Then
    '        '            mintRunNumberIndex = -1
    '        '        End If

    '        '        If gobjNewMethod.StandardAddition Then
    '        '            EndAnalysis = False
    '        '        End If

    '        '        'DeleteAllRawData(False)
    '        '        mobjAnalysisRawData.Clear()
    '        '        mobjBlankRawData = Nothing
    '        '        mobjStandardRawData = Nothing
    '        '        mobjSampleRawData = Nothing

    '        '        '*************************************************************************
    '        '        '---- Commented by Mangesh on 10-May-2007
    '        '        '*************************************************************************
    '        '        '---Gets the First Standard from Standard Collection
    '        '        If Not IsNothing(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection) Then
    '        '            mobjStandardEnumerator = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.GetEnumerator()
    '        '            mobjStandardEnumerator.Reset()
    '        '            intIEnumCollLocationStd = 0
    '        '            If mobjStandardEnumerator.MoveNext() Then
    '        '                intIEnumCollLocationStd = 1
    '        '                mobjCurrentStandard = CType(mobjStandardEnumerator.Current(), Method.clsAnalysisStdParameters)
    '        '            End If
    '        '        End If

    '        '        '---Gets the First Sample from Sample Collection
    '        '        If Not IsNothing(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection) Then
    '        '            mobjSampleEnumerator = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.GetEnumerator()
    '        '            mobjSampleEnumerator.Reset()
    '        '            intIEnumCollLocationSamp = 0
    '        '            If mobjSampleEnumerator.MoveNext() Then
    '        '                intIEnumCollLocationSamp = 1
    '        '                mobjCurrentSample = CType(mobjSampleEnumerator.Current(), Method.clsAnalysisSampleParameters)
    '        '            End If
    '        '        End If
    '        '        '*************************************************************************

    '        '        CurRepeat = 1

    '        '        If ((Not IsNothing(mobjCurrentStandard)) And StdAnalysed) Then
    '        '            If (gobjNewMethod.StandardAddition) Then
    '        '                objDlgResult = DialogResult.No
    '        '            Else
    '        '                If Not (methchange) Then
    '        '                    If gobjMessageAdapter.ShowMessage(constPreviousStandards) Then
    '        '                        objDlgResult = DialogResult.Yes
    '        '                    Else
    '        '                        objDlgResult = DialogResult.No
    '        '                    End If
    '        '                Else
    '        '                    objDlgResult = DialogResult.No
    '        '                End If
    '        '            End If
    '        '            'Comment & move by Pankaj on 08 Jun 07 
    '        '            'If (objDlgResult = DialogResult.No) Then
    '        '            '    Clear_All_Abs_Std(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection)
    '        '            'Else
    '        '            '    mobjCurrentStandard = Nothing
    '        '            'End If
    '        '            '------
    '        '        End If
    '        '        methchange = False

    '        '        If Not (StdAnalysed) Then  '---for removing uncompleted std analysis
    '        '            Call Clear_All_Abs_Std(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection)
    '        '        End If
    '        '        'Moved By Pankaj  on 09 Jun 07
    '        '        'Call Clear_All_Abs_Conc_Samp(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection)


    '        '        SampleType = ClsAAS203.enumSampleType.BLANK

    '        '        Afirst = True
    '        '        mStartTime = 0.0
    '        '        mEndTime = mStartTime + 100

    '        '        'if(i==6)
    '        '        '   StdAnalysed =TRUE;
    '        '        'Else
    '        '        '	StdAnalysed =FALSE;

    '        '        'Comment & move by Pankaj 08 Jun 06 
    '        '        'If (objDlgResult = DialogResult.Yes) Then
    '        '        '    StdAnalysed = True
    '        '        'Else
    '        '        '    StdAnalysed = False
    '        '        'End If
    '        '        '---------

    '        '        'gobjNewMethod.AnalysisParameters.RepReady = False

    '        '        If (mblnIsStartRunNumber) Then
    '        '            'AppendMethod(Method, QALL)

    '        '            If (CInt(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).RunNumber) >= 0) Then
    '        '                Dim objclsQuantitativeData As AAS203Library.Method.clsQuantitativeData
    '        '                objclsQuantitativeData = New AAS203Library.Method.clsQuantitativeData
    '        '                objclsQuantitativeData.AnalysisParameters = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.Clone()
    '        '                objclsQuantitativeData.ReportParameters = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).ReportParameters.Clone()
    '        '                objclsQuantitativeData.StandardDataCollection = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.Clone()
    '        '                objclsQuantitativeData.SampleDataCollection = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.Clone()
    '        '                objclsQuantitativeData.CalculationMode = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).CalculationMode
    '        '                gobjNewMethod.QuantitativeDataCollection.Add(objclsQuantitativeData)
    '        '                mintRunNumberIndex += 1
    '        '                gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).RunNumber = -1.0
    '        '            End If
    '        '            mblnIsStartRunNumber = False
    '        '        End If
    '        '        'Added By Pankaj on 08 Jun 07
    '        '        If ((Not IsNothing(mobjCurrentStandard)) And StdAnalysed) Then
    '        '            If (objDlgResult = DialogResult.No) Then
    '        '                Clear_All_Abs_Std(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection)
    '        '            Else
    '        '                mobjCurrentStandard = Nothing
    '        '            End If
    '        '        End If
    '        '        Call Clear_All_Abs_Conc_Samp(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection)
    '        '        '------------------
    '        '        'Comment & move by Pankaj 08 Jun 06 
    '        '        If (objDlgResult = DialogResult.Yes) Then
    '        '            StdAnalysed = True
    '        '        Else
    '        '            StdAnalysed = False
    '        '        End If
    '        '        '---------
    '        '        If (CInt(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).RunNumber) <= 0) Then
    '        '            Call GetRunNo(gobjNewMethod)
    '        '        End If

    '        '        '*************************************************************************
    '        '        '---- Added by Mangesh on 10-May-2007
    '        '        '*************************************************************************
    '        '        '---Gets the First Standard from Standard Collection
    '        '        If Not IsNothing(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection) Then
    '        '            mobjStandardEnumerator = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.GetEnumerator()
    '        '            mobjStandardEnumerator.Reset()
    '        '            intIEnumCollLocationStd = 0
    '        '            If mobjStandardEnumerator.MoveNext() Then
    '        '                intIEnumCollLocationStd = 1
    '        '                mobjCurrentStandard = CType(mobjStandardEnumerator.Current(), Method.clsAnalysisStdParameters)
    '        '            End If
    '        '        End If

    '        '        '---Gets the First Sample from Sample Collection
    '        '        If Not IsNothing(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection) Then
    '        '            mobjSampleEnumerator = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.GetEnumerator()
    '        '            mobjSampleEnumerator.Reset()
    '        '            intIEnumCollLocationSamp = 0
    '        '            If mobjSampleEnumerator.MoveNext() Then
    '        '                intIEnumCollLocationSamp = 1
    '        '                mobjCurrentSample = CType(mobjSampleEnumerator.Current(), Method.clsAnalysisSampleParameters)
    '        '            End If
    '        '        End If

    '        '        If (objDlgResult = DialogResult.Yes) Then
    '        '            mobjCurrentStandard = Nothing
    '        '        End If
    '        '        '*************************************************************************

    '        '        If AASGraphAnalysis.AldysPane.CurveList.Count > 0 Then
    '        '            AASGraphAnalysis.AldysPane.CurveList.Clear()

    '        '            AASGraphAnalysis.AldysPane.AxisChange()
    '        '            AASGraphAnalysis.Invalidate()
    '        '            Application.DoEvents()
    '        '        End If

    '        '        'AASGraphAnalysis.XAxisStep = 20     'Saurabh 06-06-2007
    '        '        'Call Calculate_Analysis_Graph_Param(AASGraphAnalysis)

    '        '        AASGraphAnalysis.XAxisType = AldysGraph.AxisType.Linear
    '        '        AASGraphAnalysis.XAxisMin = mStartTime
    '        '        AASGraphAnalysis.XAxisMax = mEndTime

    '        '        Call Calculate_Analysis_Graph_Param(AASGraphAnalysis)

    '        '        'AASGraphAnalysis.AldysPane.XAxis.StepAuto = True
    '        '        'AASGraphAnalysis.AldysPane.XAxis.MinorStepAuto = True
    '        '        'AASGraphAnalysis.AldysPane.XAxis.PickScale(AASGraphAnalysis.XAxisMin, AASGraphAnalysis.XAxisMax)

    '        '        AASGraphAnalysis.Refresh()
    '        '        Application.DoEvents()

    '        '        AnaOver = False

    '        '        Call DisplayRunNo()

    '        '        'gobjNewMethod.AnalysisParameters.cMode = -2

    '        '        'tlbbtnRepeatLastAnalysis.Enabled = False
    '        '        btnRepeatLast.Enabled = False
    '        '        '//----- Save Instrument parameter
    '        '        'gobjNewMethod.InstrumentCondition.D2Current = gobjInst.D2Current
    '        '        'gobjNewMethod.InstrumentCondition.LampCurrent = gobjInst.Current
    '        '        'gobjNewMethod.InstrumentCondition.PmtVoltage = gobjInst.PmtVoltage
    '        '        'gobjNewMethod.InstrumentCondition.SlitWidth = gobjClsAAS203.funcGet_SlitWidth
    '        '        If gstructSettings.AppMode = EnumAppMode.FullVersion_203D Then
    '        '            'TODO   Add property to gobjNewMethod.InstrumentCondition object for PMT Volt & Exit Slit Wd for Ref. 
    '        '            'gobjNewMethod.InstrumentCondition.PmtVoltage = gobjInst.PmtVoltageReference
    '        '            'gobjNewMethod.InstrumentCondition.SlitWidth = gobjInst.SlitPositionExit
    '        '        End If

    '        '        gobjNewMethod.InstrumentCondition.BurnerHeight = gobjClsAAS203.funcReadBurnerHeight()

    '        '        If Not (gstructSettings.AppMode = EnumAppMode.DemoMode) Then
    '        '            Call gobjCommProtocol.funcGet_NV_Pos()
    '        '        End If

    '        '        dblFuelRatio = gobjClsAAS203.funcGet_Fuel_Ratio(True)
    '        '        gobjNewMethod.InstrumentCondition.FuelRatio = dblFuelRatio
    '        '        '//-----

    '        '        'If (gobjNewMethod.AnalysisParameters) Then
    '        '        '   aafname = gobjNewMethod.AnalysisParameter.Fname
    '        '        'End If

    '        '        Call Display_Analysis_Info()
    '        '        Call CheckValidStdAbs()
    '        '        If (mblnIsAnalysisStarted) Then
    '        '            ANALYSIS = True
    '        '            '---Show Blinking Message
    '        '            Call Aspirate()
    '        '        Else
    '        '            ANALYSIS = False
    '        '        End If
    '        '        mblnRepeatLastStd = False
    '        '        mblnRepeatLastSample = False

    '        '    Catch ex As Exception
    '        '        '---------------------------------------------------------
    '        '        'Error Handling and logging
    '        '        gobjErrorHandler.ErrorDescription = ex.Message
    '        '        gobjErrorHandler.ErrorMessage = ex.Message
    '        '        gobjErrorHandler.WriteErrorLog(ex)
    '        '        '---------------------------------------------------------
    '        '    Finally
    '        '        '---------------------------------------------------------
    '        '        'Writing Execution log
    '        '        If CONST_CREATE_EXECUTION_LOG = 1 Then
    '        '            gobjErrorHandler.WriteExecutionLog()
    '        '        End If
    '        '        '---------------------------------------------------------
    '        '    End Try
    '        'End Sub

    '#End Region

    '    End Class
#End Region


End Class
