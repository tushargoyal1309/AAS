Imports AAS203.Common
Imports AAS203Library.Method
Imports System.Threading

Public Class frmDataFiles
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
    Friend WithEvents CustomPanelLeft As GradientPanel.CustomPanel
    Friend WithEvents CustomPanelRight As GradientPanel.CustomPanel
    Friend WithEvents CustomPanelRightBottom As GradientPanel.CustomPanel
    Friend WithEvents CustomPanelRightTop As GradientPanel.CustomPanel
    Friend WithEvents lblMethod As System.Windows.Forms.Label
    Friend WithEvents CustomPanelMain As GradientPanel.CustomPanel
    Friend WithEvents HeaderRight As CodeIntellects.Office2003Controls.Office2003Header
    Friend WithEvents lblMethodInformation As System.Windows.Forms.Label
    Friend WithEvents lblMethodComments As System.Windows.Forms.Label
    Friend WithEvents txtMethodComments As System.Windows.Forms.TextBox
    Friend WithEvents txtRunNo As System.Windows.Forms.TextBox
    Friend WithEvents lblRunNo As System.Windows.Forms.Label
    Friend WithEvents lstMethodInformation As System.Windows.Forms.ListBox
    Friend WithEvents PreviewGraph As AAS203.AASGraph
    Friend WithEvents txtMethod As System.Windows.Forms.TextBox
    Friend WithEvents btnEditData As NETXP.Controls.XPButton
    Friend WithEvents btnExportReport As NETXP.Controls.XPButton
    Friend WithEvents btnReportOptions As NETXP.Controls.XPButton
    Friend WithEvents btnReports As NETXP.Controls.XPButton
    Friend WithEvents btnViewResults As NETXP.Controls.XPButton
    Friend WithEvents HeaderLeft As CodeIntellects.Office2003Controls.Office2003Header
    Friend WithEvents btnSampleGraph As NETXP.Controls.XPButton
    Friend WithEvents btnStandardGraph As NETXP.Controls.XPButton
    Friend WithEvents btnLoad As NETXP.Controls.XPButton
    Friend WithEvents cmdChangeScale As NETXP.Controls.XPButton
    Friend WithEvents btnPrintGraph As NETXP.Controls.XPButton
    Friend WithEvents btnExtinguish As NETXP.Controls.XPButton
    Friend WithEvents btnIgnite As NETXP.Controls.XPButton
    Friend WithEvents RealPanel1 As NETXP.Controls.RealPanel
    Friend WithEvents RealPanel2 As NETXP.Controls.RealPanel
    Friend WithEvents RealPanel3 As NETXP.Controls.RealPanel
    Friend WithEvents btnN2OIgnite As NETXP.Controls.XPButton
    Friend WithEvents btnDelete As NETXP.Controls.XPButton
    Friend WithEvents btnR As NETXP.Controls.XPButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDataFiles))
        Me.CustomPanelMain = New GradientPanel.CustomPanel()
        Me.CustomPanelRight = New GradientPanel.CustomPanel()
        Me.btnPrintGraph = New NETXP.Controls.XPButton()
        Me.cmdChangeScale = New NETXP.Controls.XPButton()
        Me.PreviewGraph = New AAS203.AASGraph()
        Me.CustomPanelRightTop = New GradientPanel.CustomPanel()
        Me.txtMethod = New System.Windows.Forms.TextBox()
        Me.txtRunNo = New System.Windows.Forms.TextBox()
        Me.lblRunNo = New System.Windows.Forms.Label()
        Me.lblMethod = New System.Windows.Forms.Label()
        Me.CustomPanelRightBottom = New GradientPanel.CustomPanel()
        Me.lstMethodInformation = New System.Windows.Forms.ListBox()
        Me.lblMethodComments = New System.Windows.Forms.Label()
        Me.txtMethodComments = New System.Windows.Forms.TextBox()
        Me.lblMethodInformation = New System.Windows.Forms.Label()
        Me.HeaderRight = New CodeIntellects.Office2003Controls.Office2003Header()
        Me.CustomPanelLeft = New GradientPanel.CustomPanel()
        Me.RealPanel3 = New NETXP.Controls.RealPanel()
        Me.btnLoad = New NETXP.Controls.XPButton()
        Me.btnR = New NETXP.Controls.XPButton()
        Me.btnDelete = New NETXP.Controls.XPButton()
        Me.btnN2OIgnite = New NETXP.Controls.XPButton()
        Me.RealPanel2 = New NETXP.Controls.RealPanel()
        Me.btnEditData = New NETXP.Controls.XPButton()
        Me.btnExportReport = New NETXP.Controls.XPButton()
        Me.btnReportOptions = New NETXP.Controls.XPButton()
        Me.RealPanel1 = New NETXP.Controls.RealPanel()
        Me.btnReports = New NETXP.Controls.XPButton()
        Me.btnViewResults = New NETXP.Controls.XPButton()
        Me.btnSampleGraph = New NETXP.Controls.XPButton()
        Me.btnStandardGraph = New NETXP.Controls.XPButton()
        Me.btnExtinguish = New NETXP.Controls.XPButton()
        Me.HeaderLeft = New CodeIntellects.Office2003Controls.Office2003Header()
        Me.btnIgnite = New NETXP.Controls.XPButton()
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
        Me.CustomPanelMain.Size = New System.Drawing.Size(804, 579)
        Me.CustomPanelMain.TabIndex = 0
        '
        'CustomPanelRight
        '
        Me.CustomPanelRight.BackColor = System.Drawing.Color.Transparent
        Me.CustomPanelRight.BackColor2 = System.Drawing.Color.Transparent
        Me.CustomPanelRight.Controls.Add(Me.btnPrintGraph)
        Me.CustomPanelRight.Controls.Add(Me.cmdChangeScale)
        Me.CustomPanelRight.Controls.Add(Me.PreviewGraph)
        Me.CustomPanelRight.Controls.Add(Me.CustomPanelRightTop)
        Me.CustomPanelRight.Controls.Add(Me.CustomPanelRightBottom)
        Me.CustomPanelRight.Controls.Add(Me.HeaderRight)
        Me.CustomPanelRight.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CustomPanelRight.Location = New System.Drawing.Point(132, 0)
        Me.CustomPanelRight.Name = "CustomPanelRight"
        Me.CustomPanelRight.Size = New System.Drawing.Size(672, 579)
        Me.CustomPanelRight.TabIndex = 3
        '
        'btnPrintGraph
        '
        Me.btnPrintGraph.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrintGraph.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrintGraph.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrintGraph.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPrintGraph.Location = New System.Drawing.Point(467, 75)
        Me.btnPrintGraph.Name = "btnPrintGraph"
        Me.btnPrintGraph.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnPrintGraph.Size = New System.Drawing.Size(110, 25)
        Me.btnPrintGraph.TabIndex = 5
        Me.btnPrintGraph.Text = "&Print Graph"
        '
        'cmdChangeScale
        '
        Me.cmdChangeScale.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdChangeScale.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdChangeScale.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdChangeScale.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdChangeScale.Location = New System.Drawing.Point(344, 75)
        Me.cmdChangeScale.Name = "cmdChangeScale"
        Me.cmdChangeScale.Size = New System.Drawing.Size(110, 25)
        Me.cmdChangeScale.TabIndex = 9
        Me.cmdChangeScale.Text = "C&hange  Scale"
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
        Me.PreviewGraph.Size = New System.Drawing.Size(623, 200)
        Me.PreviewGraph.TabIndex = 5
        Me.PreviewGraph.UseDefaultSettings = False
        Me.PreviewGraph.XAxisDateMax = New Date(2007, 3, 16, 23, 59, 59, 0)
        Me.PreviewGraph.XAxisDateMin = New Date(2007, 3, 16, 0, 0, 0, 0)
        Me.PreviewGraph.XAxisDateScaleFormat = AAS203.AASGraph.enumDateScaleFormat.HHMM
        Me.PreviewGraph.XAxisLabel = "TIME(seconds)"
        Me.PreviewGraph.XAxisMax = 100.0R
        Me.PreviewGraph.XAxisMin = 0R
        Me.PreviewGraph.XAxisMinorStep = 2.0R
        Me.PreviewGraph.XAxisScaleFormat = ""
        Me.PreviewGraph.XAxisStep = 10.0R
        Me.PreviewGraph.XAxisType = AldysGraph.AxisType.Linear
        Me.PreviewGraph.YAxisLabel = "ABSORBANCE"
        Me.PreviewGraph.YAxisMax = 1.1R
        Me.PreviewGraph.YAxisMin = -0.2R
        Me.PreviewGraph.YAxisMinorStep = 0.05R
        Me.PreviewGraph.YAxisScaleFormat = Nothing
        Me.PreviewGraph.YAxisStep = 0.1R
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
        Me.CustomPanelRightTop.Size = New System.Drawing.Size(672, 50)
        Me.CustomPanelRightTop.TabIndex = 0
        '
        'txtMethod
        '
        Me.txtMethod.BackColor = System.Drawing.Color.White
        Me.txtMethod.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMethod.Location = New System.Drawing.Point(91, 16)
        Me.txtMethod.Name = "txtMethod"
        Me.txtMethod.ReadOnly = True
        Me.txtMethod.Size = New System.Drawing.Size(154, 22)
        Me.txtMethod.TabIndex = 0
        '
        'txtRunNo
        '
        Me.txtRunNo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtRunNo.BackColor = System.Drawing.Color.White
        Me.txtRunNo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRunNo.Location = New System.Drawing.Point(376, 17)
        Me.txtRunNo.Name = "txtRunNo"
        Me.txtRunNo.ReadOnly = True
        Me.txtRunNo.Size = New System.Drawing.Size(154, 22)
        Me.txtRunNo.TabIndex = 1
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
        Me.CustomPanelRightBottom.Location = New System.Drawing.Point(0, 451)
        Me.CustomPanelRightBottom.Name = "CustomPanelRightBottom"
        Me.CustomPanelRightBottom.Size = New System.Drawing.Size(672, 128)
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
        Me.txtMethodComments.BackColor = System.Drawing.Color.White
        Me.txtMethodComments.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMethodComments.Location = New System.Drawing.Point(364, 31)
        Me.txtMethodComments.Multiline = True
        Me.txtMethodComments.Name = "txtMethodComments"
        Me.txtMethodComments.ReadOnly = True
        Me.txtMethodComments.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtMethodComments.Size = New System.Drawing.Size(254, 84)
        Me.txtMethodComments.TabIndex = 1
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
        Me.HeaderRight.Size = New System.Drawing.Size(672, 22)
        Me.HeaderRight.TabIndex = 3
        Me.HeaderRight.TitleFont = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HeaderRight.TitleText = ""
        '
        'CustomPanelLeft
        '
        Me.CustomPanelLeft.BackColor = System.Drawing.Color.CornflowerBlue
        Me.CustomPanelLeft.BackColor2 = System.Drawing.Color.Empty
        Me.CustomPanelLeft.Controls.Add(Me.RealPanel3)
        Me.CustomPanelLeft.Controls.Add(Me.RealPanel2)
        Me.CustomPanelLeft.Controls.Add(Me.RealPanel1)
        Me.CustomPanelLeft.Controls.Add(Me.btnExtinguish)
        Me.CustomPanelLeft.Controls.Add(Me.HeaderLeft)
        Me.CustomPanelLeft.Controls.Add(Me.btnIgnite)
        Me.CustomPanelLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.CustomPanelLeft.Location = New System.Drawing.Point(0, 0)
        Me.CustomPanelLeft.Name = "CustomPanelLeft"
        Me.CustomPanelLeft.Size = New System.Drawing.Size(132, 579)
        Me.CustomPanelLeft.TabIndex = 2
        '
        'RealPanel3
        '
        Me.RealPanel3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.RealPanel3.Controls.Add(Me.btnLoad)
        Me.RealPanel3.Controls.Add(Me.btnR)
        Me.RealPanel3.Controls.Add(Me.btnDelete)
        Me.RealPanel3.Controls.Add(Me.btnN2OIgnite)
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
        'btnR
        '
        Me.btnR.BackColor = System.Drawing.Color.RoyalBlue
        Me.btnR.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnR.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnR.Location = New System.Drawing.Point(78, 16)
        Me.btnR.Name = "btnR"
        Me.btnR.Size = New System.Drawing.Size(8, 8)
        Me.btnR.TabIndex = 23
        Me.btnR.TabStop = False
        Me.btnR.Text = "&R"
        Me.btnR.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btnR.UseVisualStyleBackColor = False
        '
        'btnDelete
        '
        Me.btnDelete.BackColor = System.Drawing.Color.RoyalBlue
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelete.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDelete.Location = New System.Drawing.Point(66, 16)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(8, 8)
        Me.btnDelete.TabIndex = 24
        Me.btnDelete.TabStop = False
        Me.btnDelete.Text = "&Delete"
        Me.btnDelete.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btnDelete.UseVisualStyleBackColor = False
        '
        'btnN2OIgnite
        '
        Me.btnN2OIgnite.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnN2OIgnite.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnN2OIgnite.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnN2OIgnite.Location = New System.Drawing.Point(82, 20)
        Me.btnN2OIgnite.Name = "btnN2OIgnite"
        Me.btnN2OIgnite.Size = New System.Drawing.Size(5, 5)
        Me.btnN2OIgnite.TabIndex = 19
        Me.btnN2OIgnite.TabStop = False
        Me.btnN2OIgnite.Text = "N2O&C"
        Me.btnN2OIgnite.TextAlign = System.Drawing.ContentAlignment.TopLeft
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
        Me.btnEditData.Enabled = False
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
        'frmDataFiles
        '
        Me.CausesValidation = False
        Me.ClientSize = New System.Drawing.Size(804, 579)
        Me.Controls.Add(Me.CustomPanelMain)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.Name = "frmDataFiles"
        Me.Text = "Data Files"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.CustomPanelMain.ResumeLayout(False)
        Me.CustomPanelRight.ResumeLayout(False)
        Me.CustomPanelRightTop.ResumeLayout(False)
        Me.CustomPanelRightTop.PerformLayout()
        Me.CustomPanelRightBottom.ResumeLayout(False)
        Me.CustomPanelRightBottom.PerformLayout()
        Me.CustomPanelLeft.ResumeLayout(False)
        Me.RealPanel3.ResumeLayout(False)
        Me.RealPanel2.ResumeLayout(False)
        Me.RealPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Private Variables "

    Private mintMethodMode As Integer = 0
    Private mintSelectedRunNumber As Integer
    Private mintSelectedMethodID As Integer
    Private mobjPreviewCurve As AldysGraph.CurveItem
    Private mobjClsDataFileReport As New clsDataFileReport
    Private mobjClsMethod As clsMethod
    Private mobjParameters As New Spectrum.EnergySpectrumParameter
    Private WithEvents mobjfrmLoadAnalysis As frmLoadAnalysis       'Saurabh 22.07.07 for store datatable of Load Analysis 
    Private mdtMultiReport As New DataTable
    Private mblnAvoidProcessing As Boolean = False
    WithEvents mobjfrmReportOptions As frmReportOptions
#End Region

#Region " Private Properties "

    'Private Property OpenMethodMode() As EnumMethodMode
    '    Get
    '        Return mintMethodMode
    '    End Get
    '    Set(ByVal Value As EnumMethodMode)
    '        mintMethodMode = Value
    '    End Set
    'End Property

#End Region

#Region " Private Constants "

    Private Const ConstCreatedBy = "Created By  "
    Private Const ConstCreatedOn = "Created On  "
    Private Const ConstStatus = "Status"
    Private Const ConstChangedOn = "Changed On  "
    Private Const ConstLastUsedOn = "Last Used On"
    Private Const ConstActive = "Active"
    Private Const ConstNotActive = "Inactive (Method parameters are incomplete)"
    Private ConstFormLoad As String = gstrTitleInstrumentType & "-Data Files"
    Private ConstParentFormLoad As String = gstrTitleInstrumentType & "-Method"
#End Region

#Region " Form Events "

    Public Sub frmDataFiles_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '=====================================================================
        ' Procedure Name        : frmDataFiles_Load
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To initialize the form
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 07.10.06
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor

        Try
            If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
                btnIgnite.Enabled = False
                btnExtinguish.Enabled = False
            End If

            btnLoad.BringToFront()
            btnLoad.Focus()
            Me.FormBorderStyle = FormBorderStyle.FixedSingle
            'Show progress bar
            Call gobjMain.ShowProgressBar(ConstFormLoad)
            'add handlers to buttons
            Call AddHandlers()

            'XpPanelStandardGraph.Enabled = False
            'XpPanelSampleGraph.Enabled = False
            'XpPanelViewResults.Enabled = False
            'XpPanelReports.Enabled = False
            'XpPanelReportOptions.Enabled = False
            'XpPanelExportReport.Enabled = False
            'XpPanelEditData.Enabled = False
            'disable all buttons for 1 st time
            btnPrintGraph.BringToFront()
            cmdChangeScale.BringToFront()
            btnStandardGraph.Enabled = False
            btnSampleGraph.Enabled = False
            btnViewResults.Enabled = False
            btnReports.Enabled = False
            btnReportOptions.Enabled = False
            btnExportReport.Enabled = False
            btnPrintGraph.Enabled = False
            btnEditData.Enabled = False

            'CustomPanelLeft.Width = 168
            'XpPanelGroup1.Width = 160
            'HeaderLeft.Width = 168
            ''lblMethod.Location = New Point(19, 20)
            ''txtMethod.Location = New Point(91, 16)
            ''lblRunNo.Location = New Point(312, 18)
            ''txtRunNo.Location = New Point(376, 17)
            ''lblMethodInformation.Location = New Point(18, 10)
            ''lstMethodInformation.Location = New Point(22, 31)
            ''lblMethodComments.Location = New Point(369, 10)
            ''txtMethodComments.Location = New Point(364, 31)
            ''lstMethodInformation.Size = New Size(274, 84)
            ''txtMethodComments.Size = New Size(254, 84)
            'PreviewGraph.XAxisMin = mobjParameters.XaxisMin
            'PreviewGraph.XAxisMax = mobjParameters.XaxisMax
            '-----Added By Pankaj on 10 May 2007
            'update graph scale and label
            If Not IsNothing(gobjNewMethod) Then
                If gobjNewMethod.OperationMode = EnumOperationMode.MODE_EMMISSION Then
                    PreviewGraph.YAxisMin = -10.0
                    PreviewGraph.YAxisMax = 100
                    PreviewGraph.YAxisLabel = "EMISSION"
                Else
                    PreviewGraph.YAxisMin = -0.2
                    PreviewGraph.YAxisMax = 1.2
                End If
            Else
                PreviewGraph.YAxisMin = -0.2
                PreviewGraph.YAxisMax = 1.2
            End If
            PreviewGraph.IsShowGrid = True
            cmdChangeScale.BringToFront()
            'adjust the graph scale for proper end points
            gobjClsAAS203.Calculate_Analysis_Graph_Param(PreviewGraph, ClsAAS203.enumChangeAxis.xyAxis)
            '-------------

            'Saurabh 10.07.07 To bring status form in front
            gobjfrmStatus.Show()
            'Saurabh
            ''Added by praveen to solve Methodfrm overlaping prob
            'gobjMain.mobjfrmMethod.SendToBack()
            'gobjMain.mobjfrmMethod.Visible = False
            ''Ended by praveen
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
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
            objWait.Dispose()
            Call gobjMain.HideProgressBar()
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub frmDataFiles_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        '=====================================================================
        ' Procedure Name        : frmDataFiles_Closing
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : 
        ' Description           :  
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                :  
        ' Created               : 1.05.07
        ' Revisions             : 
        '=====================================================================
        gobjMain.ShowRunTimeInfo(ConstParentFormLoad)
    End Sub

    Private Sub cmdChangeScale_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdChangeScale.Click
        '=====================================================================
        ' Procedure Name        : cmdChangeScale_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : 
        ' Description           : calculate change scale
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : 
        ' Created               : 1.05.07
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Dim objfrmChangeScale As frmChangeScale
        Try

            'Change the graph coordinates
            objfrmChangeScale = New frmChangeScale(mobjParameters, False)


            objfrmChangeScale.funcSetValidatingScale(gobjInst.Mode)
            objfrmChangeScale.lblXAxis.Visible = False
            'Set the graph parametes to the change scale form object
            '-------------Added By Pankaj 11 May 07 for showing default scale on change form
            objfrmChangeScale.SpectrumParameter.XaxisMin = PreviewGraph.XAxisMin
            objfrmChangeScale.SpectrumParameter.XaxisMax = PreviewGraph.XAxisMax

            objfrmChangeScale.SpectrumParameter.YaxisMin = PreviewGraph.YAxisMin
            objfrmChangeScale.SpectrumParameter.YaxisMax = PreviewGraph.YAxisMax
            '------------------------

            If objfrmChangeScale.ShowDialog() = DialogResult.OK Then
                'Set the change scale form objectparametes to the graph object
                If Not objfrmChangeScale.SpectrumParameter Is Nothing Then

                    mobjParameters.XaxisMax = objfrmChangeScale.SpectrumParameter.XaxisMax
                    mobjParameters.XaxisMin = objfrmChangeScale.SpectrumParameter.XaxisMin
                    mobjParameters.YaxisMax = objfrmChangeScale.SpectrumParameter.YaxisMax
                    mobjParameters.YaxisMin = objfrmChangeScale.SpectrumParameter.YaxisMin

                End If
                PreviewGraph.XAxisMin = mobjParameters.XaxisMin
                PreviewGraph.XAxisMax = mobjParameters.XaxisMax

                PreviewGraph.YAxisMin = mobjParameters.YaxisMin
                PreviewGraph.YAxisMax = mobjParameters.YaxisMax

                'calculate graph parameters
                gobjClsAAS203.Calculate_Analysis_Graph_Param(PreviewGraph, ClsAAS203.enumChangeAxis.xyAxis)

            End If
            objfrmChangeScale.Close()



        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
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
            objfrmChangeScale.Dispose()
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            'mblnAvoidProcessing = False
            '---------------------------------------------------------
        End Try
    End Sub

#End Region

#Region " Private Functions "

    Private Sub AddHandlers()
        '=====================================================================
        ' Procedure Name        : AddHandlers
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : To add event handlers
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh
        ' Created               : 05.10.06
        ' Revisions             : 
        '=====================================================================
        Try
            'Add event handlers to buttons
            AddHandler btnPrintGraph.Click, AddressOf tlbbtnPrintGraph_Click
            AddHandler btnStandardGraph.Click, AddressOf tlbbtnStandardGraph_Click
            AddHandler btnSampleGraph.Click, AddressOf tlbbtnSampleGraph_Click
            AddHandler btnViewResults.Click, AddressOf tlbbtnViewResults_Click
            AddHandler btnReports.Click, AddressOf tlbbtnReports_Click
            AddHandler btnReportOptions.Click, AddressOf tlbbtnReportOptions_Click
            AddHandler btnLoad.Click, AddressOf tlbbtnLoad_Click
            AddHandler btnExportReport.Click, AddressOf tlbbtnExportReport_Click
            AddHandler btnEditData.Click, AddressOf tlbbtnEditData_Click
            AddHandler btnDelete.Click, AddressOf btnDelete_Click
            AddHandler btnR.Click, AddressOf btnR_Click

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
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
            '---------------------------------------------------------
        End Try

    End Sub

    Private Sub tlbbtnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : tlbbtnBack_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To exit frmDataFiles and load frmMDIMain form
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 25.09.06
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor

        Try
            Me.Close() 'close datafile window

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
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
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            '---------------------------------------------------------
        End Try
    End Sub

    Private Function SetColorPropertiesForXpPanel(ByRef objXpPanelIn As UIComponents.XPPanel, ByVal strCaptionNameIn As String) As Boolean
        '=====================================================================
        ' Procedure Name        : SetColorPropertiesForXpPanel
        ' Parameters Passed     : objXpPanelIn,strCaptionNameIn
        ' Returns               : True or False
        ' Purpose               : To set color properties to xp panel
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 05.10.06
        ' Revisions             : 
        '=====================================================================
        Try
            'Set the color and other setting to xp panel parameters object
            objXpPanelIn.Caption = strCaptionNameIn

            objXpPanelIn.CaptionGradient.Color2 = Color.CornflowerBlue
            objXpPanelIn.CaptionGradient.Color1 = Color.FromArgb(205, 225, 250)

            objXpPanelIn.PanelGradient.Color1 = Color.White 'Color.FromArgb(205, 225, 250)
            objXpPanelIn.PanelGradient.Color2 = Color.Gainsboro 'Color.FromArgb(175, 200, 245)

            objXpPanelIn.CaptionUnderline = Color.CornflowerBlue
            objXpPanelIn.CurveRadius = 8
            objXpPanelIn.Dock = DockStyle.None
            objXpPanelIn.GradientOffset = 0.2
            objXpPanelIn.HorzAlignment = StringAlignment.Near
            objXpPanelIn.Spacing = New Point(5, 0)
            objXpPanelIn.TextColors.Color1 = Color.FromArgb(33, 93, 198)
            objXpPanelIn.TextColors.Color2 = Color.FromArgb(0, 0, 0, 0)
            objXpPanelIn.TextHighlightColors.Color1 = Color.FromArgb(66, 142, 255)
            objXpPanelIn.TextHighlightColors.Color2 = Color.FromArgb(0, 0, 0, 0)
            objXpPanelIn.VertAlignment = StringAlignment.Center
            objXpPanelIn.XPPanelStyle = UIComponents.XPPanelStyle.WindowsXP
            objXpPanelIn.OutlineColor = Color.FromArgb(175, 200, 245)
            objXpPanelIn.Visible = True
            objXpPanelIn.PanelState = UIComponents.XPPanelState.Collapsed
            objXpPanelIn.Width = Me.Width
            objXpPanelIn.Height = 100
            objXpPanelIn.AnimationRate = 1

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
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
            '---------------------------------------------------------
        End Try

    End Function

    Private Sub tlbbtnStandardGraph_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : tlbbtnStandardGraph_Click
        ' Parameters Passed     : Object, EventArgs
        ' Returns               : 
        ' Purpose               : To show the Standard Graph form.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 05.10.06
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor

        Try
            'tlbbtnStandardGraph.SuspendEvents()
            ' to show the Sample Graph 
            ' Create_Standard_Sample_Curve function of clsstandardgraph object is use 
            ' 1 param 'blnIsSampleIn' is bool to show Standard and Sample or Standard graph
            ' 2 param 'blnIsAnalysisModeIn' is bool to check in analysis mode or not 
            ' 3 param 'intSelectedMethodId' is int to set Method ID from collection object
            ' 4 param 'intSelectedRunNumber' is int to set selected Run No from Method object
            ' 5 param objNewMethod is Method object type by Ref. to return Method object

            gobjclsStandardGraph = New clsStandardGraph
            Call gobjclsStandardGraph.Create_Standard_Sample_Curve(False, False, mintSelectedMethodID, mintSelectedRunNumber, mobjClsMethod)

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
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
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            'tlbbtnStandardGraph.ResumeEvents()
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub tlbbtnSampleGraph_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : tlbbtnSampleGraph_Click
        ' Parameters Passed     : Object, EventArgs
        ' Returns               : 
        ' Purpose               : To show the Sample Graph form.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 05.10.06
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor

        Try
            'tlbbtnSampleGraph.SuspendEvents()
            ' to show the Sample Graph 
            ' Create_Standard_Sample_Curve function of clsstandardgraph object is use 
            ' 1 param 'blnIsSampleIn' is bool to show Standard and Sample or Standard graph
            ' 2 param 'blnIsAnalysisModeIn' is bool to check in analysis mode or not 
            ' 3 param 'intSelectedMethodId' is int to set Method ID from collection object
            ' 4 param 'intSelectedRunNumber' is int to set selected Run No from Method object
            ' 5 param objNewMethod is Method object type by Ref. to return Method object
            gobjclsStandardGraph = New clsStandardGraph
            Call gobjclsStandardGraph.Create_Standard_Sample_Curve(True, False, mintSelectedMethodID, mintSelectedRunNumber, mobjClsMethod)

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
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
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            'tlbbtnSampleGraph.ResumeEvents()
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub tlbbtnViewResults_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : tlbbtnViewResults_Click
        ' Parameters Passed     : Object, EventArgs
        ' Returns               : 
        ' Purpose               : To show the Results of the Analysis.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 05.10.06
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Dim objfrmViewResults As frmViewResults

        Try
            ' Show the Data Report into tabulor format on screen
            objfrmViewResults = New frmViewResults(False, mintSelectedMethodID, mintSelectedRunNumber, mobjClsMethod)
            objfrmViewResults.ShowDialog()
            Application.DoEvents()
            objfrmViewResults.Close()
            objfrmViewResults.Dispose()
            objfrmViewResults = Nothing

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
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
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub tlbbtnReports_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : tlbbtnReports_Click
        ' Parameters Passed     : Object, EventArgs
        ' Returns               : 
        ' Purpose               : To show the Reports.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 05.10.06
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Dim intSelectIDIndex As Integer
        Dim intCount As Integer

        Try
            '-----Added By Pankaj Fri 18 May 07
            'check user having authority to use the module
            If (gstructSettings.Enable21CFR = True) Then
                If Not funcCheckActivityAuthentication(enumActivityAuthentication.Print, gstructUserDetails.Access) Then
                    Exit Sub
                End If
                gfuncInsertActivityLog(EnumModules.Print, "Print DataFiles Report Accessed")
            End If
            '------
            'tlbbtnLoad.SuspendEvents()


            '----Be Careful NOT TO USE index to assign MethodID or RunNumber

            ' Selecte Method ID
            For intCount = 0 To gobjMethodCollection.Count - 1
                If mintSelectedMethodID = gobjMethodCollection(intCount).MethodID Then
                    intSelectIDIndex = intCount
                    'mobjClsDataFileReport.MethodID = intCount
                    mobjClsDataFileReport.MethodID = gobjMethodCollection(intCount).MethodID
                    Exit For
                End If
            Next
            ' Select Run No from selected Method object
            For intCount = 0 To gobjMethodCollection(intSelectIDIndex).QuantitativeDataCollection.Count - 1
                If mintSelectedRunNumber = CInt(gobjMethodCollection(intSelectIDIndex).QuantitativeDataCollection(intCount).RunNumber) Then
                    mobjClsDataFileReport.RunNumber = mintSelectedRunNumber
                    Exit For
                End If
            Next

            mobjClsDataFileReport.DefaultFont = Me.DefaultFont

            ' send the Data Report to the Report Object
            'Call mobjClsDataFileReport.funcDatafilePrint()
            Call mobjClsDataFileReport.funcDatafilePrintForMethod() 'by Pankaj on 21 feb08

            'Call mobjClsDataFileReport.funcStandardGraphPrint(Me.PreviewGraph)
            'Me.PreviewGraph.XAxisDateScaleFormat = AAS203.AASGraph.enumDateScaleFormat.HHMM
            'Call mobjClsDataFileReport.funcStandardGraphPrint(Me.PreviewGraph, "Hi Sachin")
            'Call mobjClsDataFileReport.funcSampleGraphPrint(Me.PreviewGraph, "Hi Sachin")

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
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
            'tlbbtnLoad.ResumeEvents()
            objWait.Dispose()
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub tlbbtnPrintGraph_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : tlbbtnPrintGraph_Click
        ' Parameters Passed     : Object, EventArgs
        ' Returns               : None
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 17-May-2007 03:25 pm
        ' Revisions             : 1
        '=====================================================================



        Dim objWait As New CWaitCursor
        'Dim A1() As Double = {0, 0, 0, 0, 0, 0}

        Try
            '-----Added By Pankaj Fri 18 May 07
            'check for 21 CFR
            If (gstructSettings.Enable21CFR = True) Then
                If Not funcCheckActivityAuthentication(enumActivityAuthentication.Print, gstructUserDetails.Access) Then
                    Return
                    Exit Sub
                End If
                gfuncInsertActivityLog(EnumModules.Print, "Print DataFiles Graph Accessed")
            End If
            '------

            'If (toreported) Then 'OR NOT Method->RepReady )
            'gobjClsAAS203.SaveQuantResults(gobjNewMethod, A1, False)
            'toreported = False
            'PreviewGraph.PrintPreViewGraph()
            Dim mintRunNumberIndex As Integer
            'Print the Histograph object including result
            '---For Data Files Mode
            mintRunNumberIndex = gfuncGetSelectedMethodRunNumberIndex(mobjClsMethod.MethodID, mintSelectedRunNumber)
            mobjClsDataFileReport.RunNumber = mobjClsMethod.QuantitativeDataCollection(mintRunNumberIndex).RunNumber
            'End If

            mobjClsDataFileReport.DefaultFont = Me.DefaultFont

            'Graph.XAxisDateScaleFormat = AAS203.AASGraph.enumDateScaleFormat.HHMM

            Call mobjClsDataFileReport.funcHistographPrint(PreviewGraph, mobjClsMethod)


            'End If

            'if (gobjNewMethod.RepReady )
            '   OnReportPrint(gobjNewMethod)
            'end if

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
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
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub tlbbtnReportOptions_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : tlbbtnReportOptions_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To load the frmReportOptions form
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 25.09.06
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        'Dim objfrmReportOptions As frmReportOptions
        Dim intSelectedRunNumberIndex As Integer
        Try
            ' Set the report parameter for Analysis data report
            ' To set parameters use frmReportOptions form.

            mobjfrmReportOptions = New frmReportOptions(EnumMethodMode.EditMode, True, mintSelectedMethodID, mintSelectedRunNumber, mobjClsMethod)
            mobjfrmReportOptions.ShowDialog()
            ''If objfrmReportOptions.ShowDialog() = DialogResult.OK Then   '4.85   12.04.09
            ''    'Set the clsMethod object to set report from Method collection object.
            ''    For intCounter As Integer = 0 To gobjMethodCollection.Count - 1
            ''        If gobjMethodCollection.item(intCounter).MethodID = mintSelectedMethodID Then
            ''            intSelectedRunNumberIndex = gfuncGetSelectedMethodRunNumberIndex(mintSelectedMethodID, mintSelectedRunNumber)
            ''            If intSelectedRunNumberIndex >= 0 Then
            ''                gobjMethodCollection.item(intCounter).QuantitativeDataCollection(intSelectedRunNumberIndex).ReportParameters = mobjClsMethod.ReportParameters.Clone    '4.85 12.04.09
            ''                'gobjMethodCollection.item(intCounter).QuantitativeDataCollection(intSelectedRunNumberIndex).ReportParameters = gobjMethodCollection.item(intCounter).ReportParameters.Clone  '4.85 12.04.09
            ''                'mobjClsMethod = gobjMethodCollection.item(intCounter).Clone()  '4.85 12.04.09
            ''                funcSaveAllMethods(gobjMethodCollection) '4.85  12.04.09
            ''                Exit For   '4.85  12.04.09
            ''            End If
            ''        End If
            ''    Next
            ''End If

            Application.DoEvents()
            mobjfrmReportOptions.Close()
            mobjfrmReportOptions.Dispose()
            mobjfrmReportOptions = Nothing


        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
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
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub tlbbtnLoad_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : tlbbtnLoad_Click
        ' Parameters Passed     : Object, EventArgs
        ' Returns               : 
        ' Purpose               : To load the Analysis already saved.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 05.10.06
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Dim intRunNumberIndex As Integer
        Dim intCounter As Integer
        Dim intCount As Integer
        Dim strRunNo As String
        Dim intAnalysisRawDataCount As Integer
        Dim intIntegrationTime As Integer
        Dim intX_Max As Integer
        mobjfrmLoadAnalysis = New frmLoadAnalysis(mdtMultiReport)
        Try
            'tlbbtnLoad.SuspendEvents()
            'Show the frmLoadAnalysis form object to select and load analysis Run No.
            If mobjfrmLoadAnalysis.ShowDialog() = DialogResult.Cancel Then
                Exit Sub
            End If
            Application.DoEvents()
            ' Set  the selected method ID
            mintSelectedMethodID = mobjfrmLoadAnalysis.SelectedMethodID
            ' Set  the selected Run Numbser
            mintSelectedRunNumber = mobjfrmLoadAnalysis.SelectedRunNumber
            mobjfrmLoadAnalysis.Close()
            mobjfrmLoadAnalysis.Dispose()
            ' Select the index of run No from Method objects
            intRunNumberIndex = modGlobalFunctions.gfuncGetSelectedMethodRunNumberIndex(mintSelectedMethodID, mintSelectedRunNumber)
            ' Find details info. about seleted method and analyse Run number
            For intCounter = 0 To gobjMethodCollection.Count - 1
                If gobjMethodCollection.item(intCounter).MethodID = mintSelectedMethodID Then

                    mobjClsMethod = gobjMethodCollection.item(intCounter).Clone()
                    mobjClsMethod.ReportParameters = gobjMethodCollection.item(intCounter).QuantitativeDataCollection.Item(intRunNumberIndex).ReportParameters.Clone  '4.85 12.04.09

                    strRunNo = mobjClsMethod.QuantitativeDataCollection.Item(intRunNumberIndex).RunNumber
                    gintCalcMode = 100  '29.04.08
                    '-----Saurabh--To extend graph beyond 100---21.06.07
                    intAnalysisRawDataCount = mobjClsMethod.QuantitativeDataCollection.Item(intRunNumberIndex).AnalysisRawData.Count
                    intIntegrationTime = mobjClsMethod.QuantitativeDataCollection.Item(intRunNumberIndex).AnalysisParameters.IntegrationTime
                    intX_Max = CInt((intIntegrationTime * intAnalysisRawDataCount) + 20)
                    '-----Saurabh
                    'Set the genetal information of method on display object
                    Call funcShowMethodGeneralInfo(mobjClsMethod, strRunNo)


                    ' Set form object.
                    btnStandardGraph.Enabled = True
                    btnSampleGraph.Enabled = True
                    btnViewResults.Enabled = True
                    btnReports.Enabled = True
                    btnPrintGraph.Enabled = True
                    btnReportOptions.Enabled = True
                    btnExportReport.Enabled = True
                    'btnEditData.Enabled = True

                    Exit For

                End If
            Next
            '-----Saurabh
            PreviewGraph.XAxisMax = CInt(intX_Max)
            '-----Saurabh

            '----added by deepak on 22.07.07
            Dim intStdCount, intSplCount, intStdCounter, intStdRepCount, intSplRepCount, intRepCounter, intSplCounter As Integer
            intStdCount = mobjClsMethod.QuantitativeDataCollection.Item(intRunNumberIndex).StandardDataCollection.Count
            intSplCount = mobjClsMethod.QuantitativeDataCollection.Item(intRunNumberIndex).SampleDataCollection.Count
            For intStdCounter = 0 To intStdCount - 1
                intStdRepCount = mobjClsMethod.QuantitativeDataCollection.Item(intRunNumberIndex).StandardDataCollection.item(intStdCounter).AbsRepeat.AbsRepeatData.Count
                For intRepCounter = 0 To intStdRepCount - 1
                    mobjClsMethod.QuantitativeDataCollection.Item(intRunNumberIndex).StandardDataCollection.item(intStdCounter).AbsRepeat.AbsRepeatData.item(intRepCounter).Used = True
                Next
            Next
            For intSplCounter = 0 To intSplCount - 1
                intStdRepCount = mobjClsMethod.QuantitativeDataCollection.Item(intRunNumberIndex).SampleDataCollection.item(intSplCounter).AbsRepeat.AbsRepeatData.Count
                For intRepCounter = 0 To intStdRepCount - 1
                    mobjClsMethod.QuantitativeDataCollection.Item(intRunNumberIndex).SampleDataCollection.item(intSplCounter).AbsRepeat.AbsRepeatData.item(intRepCounter).Used = True
                Next
            Next
            '----added by deepak on 22.07.07

            gobjClsAAS203.Calculate_Analysis_Graph_Param(PreviewGraph, ClsAAS203.enumChangeAxis.xyAxis)
            PreviewGraph.IsShowGrid = True
            PreviewGraph.Refresh()
            ''Added  by praveen for std graph
            ''It was not showing std graph on load .for this problem
            gobjclsStandardGraph = New clsStandardGraph
            Call gobjclsStandardGraph.Create_Standard_Sample_Curve(False, False, mintSelectedMethodID, mintSelectedRunNumber, mobjClsMethod)
            ''end praveen
            'Added By Pankaj on 17 Aug 07 for updating title
            If Not mobjClsMethod Is Nothing Then
                Dim objRow As DataRow
                objRow = gobjClsAAS203.funcGetMethodType(mobjClsMethod.OperationMode)
                HeaderRight.TitleText = CStr(objRow.Item("MethodType"))
            End If
            'End

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
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
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            'tlbbtnLoad.ResumeEvents()
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub tlbbtnExportReport_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : tlbbtnExportReport_Click
        ' Parameters Passed     : Object, EventArgs
        ' Returns               : 
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S & Sachin Dokhale
        ' Created               : 05.10.06
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Dim intSelectId As Integer
        Dim intCount As Integer
        Try
            ' Export the Data Report into Doc.(Word) format
            'Added By Pankaj Fri 18 May 07
            'check for 21 CFR
            If (gstructSettings.Enable21CFR = True) Then
                If Not funcCheckActivityAuthentication(enumActivityAuthentication.Export, gstructUserDetails.Access) Then
                    Return
                    Exit Sub
                End If
                gfuncInsertActivityLog(EnumModules.Export, "Export Accessed")
            End If

            'tlbbtnLoad.SuspendEvents()
            'mobjClsDataFileReport.MethodID = mintSelectedMethodID
            'mobjClsDataFileReport.RunNumber = mintSelectedRunNumber
            'For intCount = 0 To gobjMethodCollection.Count - 1
            '    If mintSelectedMethodID = gobjMethodCollection(intCount).MethodID Then
            '        intSelectId = intCount
            '        mobjClsDataFileReport.MethodID = intCount
            '        Exit For
            '    End If
            'Next
            ' Selecte Method ID
            For intCount = 0 To gobjMethodCollection.Count - 1
                If mintSelectedMethodID = gobjMethodCollection(intCount).MethodID Then
                    'intSelectIDIndex = intCount
                    intSelectId = intCount
                    'mobjClsDataFileReport.MethodID = intCount
                    mobjClsDataFileReport.MethodID = gobjMethodCollection(intCount).MethodID
                    Exit For
                End If
            Next
            ' Select Run No from selected Method object
            For intCount = 0 To gobjMethodCollection(intSelectId).QuantitativeDataCollection.Count - 1
                If mintSelectedRunNumber = CInt(gobjMethodCollection(intSelectId).QuantitativeDataCollection(intCount).RunNumber) Then
                    mobjClsDataFileReport.RunNumber = mintSelectedRunNumber
                    Exit For
                End If
            Next

            'For intCount = 0 To gobjMethodCollection(intSelectId).QuantitativeDataCollection.Count - 1
            '    If mintSelectedRunNumber = CInt(gobjMethodCollection(intSelectId).QuantitativeDataCollection(intCount).RunNumber) Then

            '        mobjClsDataFileReport.RunNumber = mintSelectedRunNumber
            '        Exit For
            '    End If
            'Next
            ' send the Data Report to the Report Object
            'Call mobjClsDataFileReport.funcDatafileExport(gobjMethodCollection(intSelectId).QuantitativeDataCollection(intCount).ReportParameters)
            Call mobjClsDataFileReport.funcDatafileExportForMethod(gobjMethodCollection(intSelectId).QuantitativeDataCollection(intCount).ReportParameters) ' by Pankaj on 21 feb 08

            '  Call mobjClsDataFileReport.funcPdffileExportForMethod(gobjMethodCollection(intSelectId).QuantitativeDataCollection(intCount).ReportParameters)

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
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
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub tlbbtnEditData_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : tlbbtnEditData_Click
        ' Parameters Passed     : Object, EventArgs
        ' Returns               : 
        ' Purpose               : To Edit data of the previously saved Analysis.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 05.10.06
        ' Revisions             : 2 ; By Mangesh S. on 09-Mar-2007
        '=====================================================================
        Dim objWait As New CWaitCursor

        'gobjMain.ShowRunTimeInfo(ConstFormLoad)
        'tlbbtnEditData.SuspendEvents()
        'objfrmDeleteStdNSam.ShowDialog()

        'Call OnViewRepeats()


        '---- ORIGINAL CODE

        'BOOL	OnViewRepeats(HWND	hpar)
        '{
        '   BOOL	flag = FALSE;
        '   DLGPROC  skp1;
        '   if (Method->QuantData==NULL)
        '	    return flag;
        '   if ((Method->QuantData->Param.Repeat>1 || Method->QuantData->Param.ConcRepeat>1 )&&  FindSamplesAnalysed()>=1) 
        '   {
        '	    skp1 =(DLGPROC) MakeProcInstance((DLGPROC) OnViewRepeatsProc,hInst);
        '	    flag = DialogBox(hInst,"QVIEWRPTS", hpar, skp1);
        '	    FreeProcInstance(skp1);
        '  }
        '   Else
        '	    flag = OnEditStdSamples(hpar);
        '   return flag;
        '}
        '****************************************************************
        Dim flag As Boolean = False
        Dim intSelectedRunNumberIndex As Integer
        Dim objfrmDeleteStdNSam As frmDeleteStdNSam
        Dim objfrmViewRepeatResults As frmViewRepeatResults

        Try
            ' Set the report parameter for Analysis data report
            ' To set parameters use frmReportOptions form.
            ' Shows and edit the sample and standard value of Abs and Conc. results

            If IsNothing(mobjClsMethod.QuantitativeDataCollection) Then
                'Return flag
                Exit Sub
            End If

            intSelectedRunNumberIndex = gfuncGetSelectedMethodRunNumberIndex(mintSelectedMethodID, mintSelectedRunNumber)
            ' Shows and edit the sample and standard value of Abs and Conc. for Repeat Results
            If ((mobjClsMethod.QuantitativeDataCollection.Item(intSelectedRunNumberIndex).AnalysisParameters.NumOfSampleRepeats > 1 _
              Or mobjClsMethod.QuantitativeDataCollection.Item(intSelectedRunNumberIndex).AnalysisParameters.NumOfStdRepeats > 1) _
              And clsStandardGraph.FindSamplesAnalysed(mobjClsMethod, intSelectedRunNumberIndex) >= 1) Then

                objfrmViewRepeatResults = New frmViewRepeatResults(mobjClsMethod, intSelectedRunNumberIndex)
                objfrmViewRepeatResults.ShowDialog()
                Application.DoEvents()
                objfrmViewRepeatResults.Close()
                objfrmViewRepeatResults.Dispose()
                objfrmViewRepeatResults = Nothing
            Else
                ' Shows and edit the sample and standard value of Abs and Conc. for single analysis results
                'flag = OnEditStdSamples()
                objfrmDeleteStdNSam = New frmDeleteStdNSam(mobjClsMethod, intSelectedRunNumberIndex)
                If objfrmDeleteStdNSam.ShowDialog() = DialogResult.OK Then
                    tlbbtnSampleGraph_Click(sender, e)
                End If
                Application.DoEvents()
                objfrmDeleteStdNSam.Close()
                objfrmDeleteStdNSam.Dispose()
                objfrmDeleteStdNSam = Nothing
                flag = True
            End If

            'Return flag

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
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
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            '---------------------------------------------------------
        End Try
    End Sub

    Private Function funcShowMethodGeneralInfo(ByVal objMethod As clsMethod, ByVal strRunNo As String) As Boolean
        '=====================================================================
        ' Procedure Name        : funcShowMethodGeneralInfo
        ' Parameters Passed     : None
        ' Returns               : True or False
        ' Purpose               : To show method information 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 05.10.06
        ' Revisions             : 
        '=====================================================================
        Dim objRow As DataRow
        Dim strStatus As String = ""

        Try
            'Show the Method and selected Run No. Information on screen

            txtMethod.Text = objMethod.MethodName
            txtRunNo.Text = strRunNo
            txtMethodComments.Text = objMethod.Comments

            objRow = gobjClsAAS203.funcGetMethodType(objMethod.OperationMode)

            If objMethod.Status = True Then
                strStatus = ConstActive
            Else
                strStatus = ConstNotActive
            End If

            Dim strDateOfModification, strDateOfLastUse As String
            If Not objMethod.DateOfModification = Date.FromOADate(0.0) Then
                strDateOfModification = Format(objMethod.DateOfModification, "dd-MMM-yyyy hh:mm tt")
            End If
            If Not objMethod.DateOfLastUse = Date.FromOADate(0.0) Then
                strDateOfLastUse = Format(objMethod.DateOfLastUse, "dd-MMM-yyyy hh:mm tt")
            End If
            'fill list box
            lstMethodInformation.Items.Clear()
            lstMethodInformation.Items.Add(ConstCreatedBy & vbTab & objMethod.UserName)
            lstMethodInformation.Items.Add(ConstCreatedOn & vbTab & Format(objMethod.DateOfCreation, "dd-MMM-yyyy hh:mm tt"))
            'lstMethodInformation.Items.Add(ConstStatus & Space(19) & strStatus)
            lstMethodInformation.Items.Add(ConstStatus & vbTab & vbTab & strStatus)
            lstMethodInformation.Items.Add(ConstChangedOn & vbTab & strDateOfModification)
            lstMethodInformation.Items.Add(ConstLastUsedOn & vbTab & strDateOfLastUse)
            cmdChangeScale.Visible = True
            btnPrintGraph.Visible = True
            ' Separate the info. of diff. opration Mode by UV ABS, Emission and other mode
            ' In UV Abs analysis graph is not shown or appear 
            ' Emission mode requires to change the parameters of graph
            Select Case objMethod.OperationMode
                Case EnumOperationMode.MODE_UVABS
                    PreviewGraph.Visible = False
                    cmdChangeScale.Visible = False
                    btnPrintGraph.Visible = False
                    'Saurabh 28 MAy 2007---------------------------------------
                Case EnumOperationMode.MODE_EMMISSION
                    PreviewGraph.Visible = True
                    PreviewGraph.YAxisLabel = "EMISSION"
                    PreviewGraph.YAxisMin = -10
                    PreviewGraph.YAxisMax = 100
                    PreviewGraph.YAxisMinorStep = 2
                    PreviewGraph.YAxisStep = 10
                    gobjClsAAS203.Calculate_Analysis_Graph_Param(PreviewGraph, ClsAAS203.enumChangeAxis.xyAxis)
                    Call gobjClsAAS203.subShowGraphPreview(Me.PreviewGraph, mobjPreviewCurve, strRunNo, objMethod)
                    PreviewGraph.Invalidate()
                    PreviewGraph.Refresh()
                    Me.Refresh()
                    PreviewGraph.Refresh()
                    Application.DoEvents()
                    'Saurabh 28 MAy 2007---------------------------------------

                Case Else
                    PreviewGraph.Visible = True
                    PreviewGraph.YAxisMin = -0.2
                    PreviewGraph.YAxisMax = 1.1
                    PreviewGraph.YAxisLabel = "ABSORBANCE"
                    gobjClsAAS203.Calculate_Analysis_Graph_Param(PreviewGraph, ClsAAS203.enumChangeAxis.xyAxis)
                    Call gobjClsAAS203.subShowGraphPreview(Me.PreviewGraph, mobjPreviewCurve, strRunNo, objMethod)
                    PreviewGraph.Invalidate()
                    PreviewGraph.Refresh()
                    Me.Refresh()
                    Application.DoEvents()

            End Select

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
            '---------------------------------------------------------
        End Try
    End Function

    Private Sub btnIgnite_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnIgnite.Click
        '=====================================================================
        ' Procedure Name        : btnIgnite_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : Ignite the flame
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 25.09.06
        ' Revisions             : 
        '=====================================================================
        If mblnAvoidProcessing = True Then
            Exit Sub
        End If
        Try
            'Ignite the flame automatically
            mblnAvoidProcessing = True
            gobjMain.AutoIgnition()
            mblnAvoidProcessing = False
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
            mblnAvoidProcessing = False
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            'objWait.Dispose()
            '---------------------------------------------------------
        End Try

    End Sub

    Private Sub btnExtinguish_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExtinguish.Click
        '=====================================================================
        ' Procedure Name        : btnExtinguish_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : Extinguish flame
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 25.09.06
        ' Revisions             : 
        '=====================================================================
        If mblnAvoidProcessing = True Then
            Exit Sub
        End If
        Try
            'Extinguish the flame automatically
            mblnAvoidProcessing = True
            gobjMain.Extinguish()
            mblnAvoidProcessing = False
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
            mblnAvoidProcessing = False
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            'objWait.Dispose()
            '---------------------------------------------------------
        End Try

    End Sub

    Private Sub btnN2OIgnite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnN2OIgnite.Click
        '=====================================================================
        ' Procedure Name        : btnN2OIgnite_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : N2O Auto Ignite
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 25.09.06
        ' Revisions             : 
        '=====================================================================
        If mblnAvoidProcessing = True Then
            Exit Sub
        End If
        Try
            mblnAvoidProcessing = True
            Call gobjMain.N2OAutoIgnition()
            mblnAvoidProcessing = False
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
            mblnAvoidProcessing = False
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            'objWait.Dispose()
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : btnDelete_Click
        ' Parameters Passed     : Object, EventArgs
        ' Returns               : None
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 18-Dec-2007 03:15 pm
        ' Revisions             : 0
        '=====================================================================
        Try
            If mblnAvoidProcessing = True Then
                Exit Sub
            End If
            mblnAvoidProcessing = True
            Call gobjMain.funcAltDelete()
            mblnAvoidProcessing = False
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
            mblnAvoidProcessing = False
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub btnR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : btnR_Click
        ' Parameters Passed     : Object, EventArgs
        ' Returns               : None
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 18-Dec-2007 03:15 pm
        ' Revisions             : 0
        '=====================================================================
        Try
            If mblnAvoidProcessing = True Then
                Exit Sub
            End If
            mblnAvoidProcessing = True
            Call gobjMain.funcAltR()
            mblnAvoidProcessing = False
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
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
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub frmDataFiles_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated

    End Sub

    Private Sub mobjfrmLoadAnalysis_StoreMultiReportDataTable(ByVal dtMultiReport As System.Data.DataTable) Handles mobjfrmLoadAnalysis.StoreMultiReportDataTable
        '=====================================================================
        ' Procedure Name        : mobjfrmLoadAnalysis_StoreMultiReportDataTable
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               :  
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 25.09.06
        ' Revisions             : 
        '=====================================================================
        Try
            'copy data table image
            mdtMultiReport = dtMultiReport.Copy()
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
            mblnAvoidProcessing = False
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            'objWait.Dispose()
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub mobjfrmReportOptions_ReportOptionsChanged(ByVal rpt As AAS203Library.Method.clsReportParameters) Handles mobjfrmReportOptions.ReportOptionsChanged
        '=====================================================================
        ' Procedure Name        : mobjfrmReportOptions_ReportOptionsChanged
        ' Parameters Passed     : AAS203Library.Method.clsReportParameters
        ' Returns               : None
        ' Purpose               :  
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak B.
        ' Created               : 13.04.09
        ' Revisions             : 
        '=====================================================================
        Dim intSelectedRunNumberIndex As Integer
        Try
            intSelectedRunNumberIndex = gfuncGetSelectedMethodRunNumberIndex(mintSelectedMethodID, mintSelectedRunNumber)
            If intSelectedRunNumberIndex >= 0 Then
                mobjClsMethod.QuantitativeDataCollection.Item(intSelectedRunNumberIndex).ReportParameters = rpt.Clone
            End If
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
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
            '---------------------------------------------------------
        End Try
    End Sub

#End Region

End Class
