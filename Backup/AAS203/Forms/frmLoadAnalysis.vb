Imports AAS203.Common
Imports AAS203Library
Imports AAS203Library.Method
Imports AAS203Library.Analysis

Public Class frmLoadAnalysis
    Inherits System.Windows.Forms.Form
    Dim blnFlag As Boolean

#Region " Windows Form Designer generated code "

    Public Sub New(Optional ByVal mdtMultiReport As DataTable = Nothing)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        mdtMultireport = mdtMultireport

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
    Friend WithEvents CustomPanelBottom As GradientPanel.CustomPanel
    Friend WithEvents gbMultiElementReport As System.Windows.Forms.GroupBox
    Friend WithEvents lbRun As System.Windows.Forms.ListBox
    Friend WithEvents btnCreateReport As NETXP.Controls.XPButton
    Friend WithEvents btnRemove As NETXP.Controls.XPButton
    Friend WithEvents btnAddRun As NETXP.Controls.XPButton
    Friend WithEvents btnCancel As NETXP.Controls.XPButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnDeleteRun As NETXP.Controls.XPButton
    Friend WithEvents btnSelectByRunNo As NETXP.Controls.XPButton
    Friend WithEvents btnOk As NETXP.Controls.XPButton
    Friend WithEvents CustomPanelTop As GradientPanel.CustomPanel
    Friend WithEvents CustomPanelMethod As GradientPanel.CustomPanel
    Friend WithEvents lblMethodComments As System.Windows.Forms.Label
    Friend WithEvents lblMethodInformation As System.Windows.Forms.Label
    Friend WithEvents lblRuns As System.Windows.Forms.Label
    Friend WithEvents lblMethods As System.Windows.Forms.Label
    Friend WithEvents lbMethodInformation As System.Windows.Forms.ListBox
    Friend WithEvents lbMethods As System.Windows.Forms.ListBox
    Friend WithEvents txtMethod As System.Windows.Forms.TextBox
    Friend WithEvents lbRunNos As System.Windows.Forms.ListBox
    Friend WithEvents lblMethod As System.Windows.Forms.Label
    Friend WithEvents lbMethodComments As System.Windows.Forms.Label
    Friend WithEvents PreviewGraph As AAS203.AASGraph
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmLoadAnalysis))
        Me.CustomPanelMain = New GradientPanel.CustomPanel
        Me.CustomPanelTop = New GradientPanel.CustomPanel
        Me.CustomPanelMethod = New GradientPanel.CustomPanel
        Me.lbMethodComments = New System.Windows.Forms.Label
        Me.lblMethod = New System.Windows.Forms.Label
        Me.txtMethod = New System.Windows.Forms.TextBox
        Me.lblMethodComments = New System.Windows.Forms.Label
        Me.lblMethodInformation = New System.Windows.Forms.Label
        Me.lblRuns = New System.Windows.Forms.Label
        Me.lblMethods = New System.Windows.Forms.Label
        Me.lbMethodInformation = New System.Windows.Forms.ListBox
        Me.lbRunNos = New System.Windows.Forms.ListBox
        Me.lbMethods = New System.Windows.Forms.ListBox
        Me.CustomPanelBottom = New GradientPanel.CustomPanel
        Me.PreviewGraph = New AAS203.AASGraph
        Me.gbMultiElementReport = New System.Windows.Forms.GroupBox
        Me.lbRun = New System.Windows.Forms.ListBox
        Me.btnCreateReport = New NETXP.Controls.XPButton
        Me.btnRemove = New NETXP.Controls.XPButton
        Me.btnAddRun = New NETXP.Controls.XPButton
        Me.btnCancel = New NETXP.Controls.XPButton
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.btnDeleteRun = New NETXP.Controls.XPButton
        Me.btnSelectByRunNo = New NETXP.Controls.XPButton
        Me.btnOk = New NETXP.Controls.XPButton
        Me.CustomPanelMain.SuspendLayout()
        Me.CustomPanelTop.SuspendLayout()
        Me.CustomPanelMethod.SuspendLayout()
        Me.CustomPanelBottom.SuspendLayout()
        Me.gbMultiElementReport.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
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
        Me.CustomPanelMain.Size = New System.Drawing.Size(584, 399)
        Me.CustomPanelMain.TabIndex = 0
        '
        'CustomPanelTop
        '
        Me.CustomPanelTop.BackColor = System.Drawing.Color.AliceBlue
        Me.CustomPanelTop.Controls.Add(Me.CustomPanelMethod)
        Me.CustomPanelTop.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CustomPanelTop.Location = New System.Drawing.Point(0, 0)
        Me.CustomPanelTop.Name = "CustomPanelTop"
        Me.CustomPanelTop.Size = New System.Drawing.Size(584, 247)
        Me.CustomPanelTop.TabIndex = 21
        '
        'CustomPanelMethod
        '
        Me.CustomPanelMethod.BackColor = System.Drawing.Color.AliceBlue
        Me.CustomPanelMethod.Controls.Add(Me.lbMethodComments)
        Me.CustomPanelMethod.Controls.Add(Me.lblMethod)
        Me.CustomPanelMethod.Controls.Add(Me.txtMethod)
        Me.CustomPanelMethod.Controls.Add(Me.lblMethodComments)
        Me.CustomPanelMethod.Controls.Add(Me.lblMethodInformation)
        Me.CustomPanelMethod.Controls.Add(Me.lblRuns)
        Me.CustomPanelMethod.Controls.Add(Me.lblMethods)
        Me.CustomPanelMethod.Controls.Add(Me.lbMethodInformation)
        Me.CustomPanelMethod.Controls.Add(Me.lbRunNos)
        Me.CustomPanelMethod.Controls.Add(Me.lbMethods)
        Me.CustomPanelMethod.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CustomPanelMethod.Location = New System.Drawing.Point(0, 0)
        Me.CustomPanelMethod.Name = "CustomPanelMethod"
        Me.CustomPanelMethod.Size = New System.Drawing.Size(584, 247)
        Me.CustomPanelMethod.TabIndex = 0
        '
        'lbMethodComments
        '
        Me.lbMethodComments.BackColor = System.Drawing.Color.White
        Me.lbMethodComments.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbMethodComments.Location = New System.Drawing.Point(352, 192)
        Me.lbMethodComments.Name = "lbMethodComments"
        Me.lbMethodComments.Size = New System.Drawing.Size(225, 40)
        Me.lbMethodComments.TabIndex = 4
        '
        'lblMethod
        '
        Me.lblMethod.Location = New System.Drawing.Point(360, 15)
        Me.lblMethod.Name = "lblMethod"
        Me.lblMethod.Size = New System.Drawing.Size(88, 16)
        Me.lblMethod.TabIndex = 32
        Me.lblMethod.Text = "Method"
        Me.lblMethod.Visible = False
        '
        'txtMethod
        '
        Me.txtMethod.BackColor = System.Drawing.Color.White
        Me.txtMethod.Location = New System.Drawing.Point(456, 13)
        Me.txtMethod.Name = "txtMethod"
        Me.txtMethod.ReadOnly = True
        Me.txtMethod.Size = New System.Drawing.Size(120, 20)
        Me.txtMethod.TabIndex = 2
        Me.txtMethod.Text = ""
        Me.txtMethod.Visible = False
        '
        'lblMethodComments
        '
        Me.lblMethodComments.Location = New System.Drawing.Point(351, 166)
        Me.lblMethodComments.Name = "lblMethodComments"
        Me.lblMethodComments.Size = New System.Drawing.Size(104, 16)
        Me.lblMethodComments.TabIndex = 30
        Me.lblMethodComments.Text = "Method Comments"
        '
        'lblMethodInformation
        '
        Me.lblMethodInformation.Location = New System.Drawing.Point(351, 38)
        Me.lblMethodInformation.Name = "lblMethodInformation"
        Me.lblMethodInformation.Size = New System.Drawing.Size(104, 16)
        Me.lblMethodInformation.TabIndex = 29
        Me.lblMethodInformation.Text = "Method Information"
        '
        'lblRuns
        '
        Me.lblRuns.Location = New System.Drawing.Point(191, 7)
        Me.lblRuns.Name = "lblRuns"
        Me.lblRuns.Size = New System.Drawing.Size(96, 16)
        Me.lblRuns.TabIndex = 28
        Me.lblRuns.Text = "Runs"
        '
        'lblMethods
        '
        Me.lblMethods.Location = New System.Drawing.Point(18, 7)
        Me.lblMethods.Name = "lblMethods"
        Me.lblMethods.Size = New System.Drawing.Size(72, 16)
        Me.lblMethods.TabIndex = 27
        Me.lblMethods.Text = "Methods"
        '
        'lbMethodInformation
        '
        Me.lbMethodInformation.Location = New System.Drawing.Point(351, 54)
        Me.lbMethodInformation.Name = "lbMethodInformation"
        Me.lbMethodInformation.Size = New System.Drawing.Size(225, 108)
        Me.lbMethodInformation.TabIndex = 3
        '
        'lbRunNos
        '
        Me.lbRunNos.BackColor = System.Drawing.Color.White
        Me.lbRunNos.Location = New System.Drawing.Point(191, 27)
        Me.lbRunNos.Name = "lbRunNos"
        Me.lbRunNos.Size = New System.Drawing.Size(129, 212)
        Me.lbRunNos.TabIndex = 1
        '
        'lbMethods
        '
        Me.lbMethods.BackColor = System.Drawing.Color.White
        Me.lbMethods.Location = New System.Drawing.Point(18, 27)
        Me.lbMethods.Name = "lbMethods"
        Me.lbMethods.Size = New System.Drawing.Size(160, 212)
        Me.lbMethods.TabIndex = 0
        '
        'CustomPanelBottom
        '
        Me.CustomPanelBottom.BackColor = System.Drawing.Color.AliceBlue
        Me.CustomPanelBottom.Controls.Add(Me.PreviewGraph)
        Me.CustomPanelBottom.Controls.Add(Me.gbMultiElementReport)
        Me.CustomPanelBottom.Controls.Add(Me.btnCancel)
        Me.CustomPanelBottom.Controls.Add(Me.GroupBox2)
        Me.CustomPanelBottom.Controls.Add(Me.btnOk)
        Me.CustomPanelBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.CustomPanelBottom.Location = New System.Drawing.Point(0, 247)
        Me.CustomPanelBottom.Name = "CustomPanelBottom"
        Me.CustomPanelBottom.Size = New System.Drawing.Size(584, 152)
        Me.CustomPanelBottom.TabIndex = 0
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
        Me.PreviewGraph.Size = New System.Drawing.Size(224, 136)
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
        'gbMultiElementReport
        '
        Me.gbMultiElementReport.BackColor = System.Drawing.Color.Transparent
        Me.gbMultiElementReport.Controls.Add(Me.lbRun)
        Me.gbMultiElementReport.Controls.Add(Me.btnCreateReport)
        Me.gbMultiElementReport.Controls.Add(Me.btnRemove)
        Me.gbMultiElementReport.Controls.Add(Me.btnAddRun)
        Me.gbMultiElementReport.Location = New System.Drawing.Point(374, 3)
        Me.gbMultiElementReport.Name = "gbMultiElementReport"
        Me.gbMultiElementReport.Size = New System.Drawing.Size(192, 101)
        Me.gbMultiElementReport.TabIndex = 1
        Me.gbMultiElementReport.TabStop = False
        Me.gbMultiElementReport.Text = "Multi - Element Report"
        '
        'lbRun
        '
        Me.lbRun.BackColor = System.Drawing.Color.White
        Me.lbRun.Location = New System.Drawing.Point(8, 14)
        Me.lbRun.Name = "lbRun"
        Me.lbRun.Size = New System.Drawing.Size(176, 56)
        Me.lbRun.TabIndex = 0
        '
        'btnCreateReport
        '
        Me.btnCreateReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCreateReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCreateReport.Location = New System.Drawing.Point(128, 72)
        Me.btnCreateReport.Name = "btnCreateReport"
        Me.btnCreateReport.Size = New System.Drawing.Size(54, 24)
        Me.btnCreateReport.TabIndex = 3
        Me.btnCreateReport.Text = "Create "
        '
        'btnRemove
        '
        Me.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRemove.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRemove.Location = New System.Drawing.Point(68, 72)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(54, 24)
        Me.btnRemove.TabIndex = 2
        Me.btnRemove.Text = "Remove"
        '
        'btnAddRun
        '
        Me.btnAddRun.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddRun.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAddRun.Location = New System.Drawing.Point(8, 72)
        Me.btnAddRun.Name = "btnAddRun"
        Me.btnAddRun.Size = New System.Drawing.Size(54, 24)
        Me.btnAddRun.TabIndex = 1
        Me.btnAddRun.Text = "Add Run"
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.Transparent
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Image = CType(resources.GetObject("btnCancel.Image"), System.Drawing.Image)
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancel.Location = New System.Drawing.Point(478, 108)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(86, 34)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "&Cancel"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnDeleteRun)
        Me.GroupBox2.Controls.Add(Me.btnSelectByRunNo)
        Me.GroupBox2.Location = New System.Drawing.Point(246, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(126, 141)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        '
        'btnDeleteRun
        '
        Me.btnDeleteRun.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDeleteRun.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDeleteRun.Image = CType(resources.GetObject("btnDeleteRun.Image"), System.Drawing.Image)
        Me.btnDeleteRun.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDeleteRun.Location = New System.Drawing.Point(8, 77)
        Me.btnDeleteRun.Name = "btnDeleteRun"
        Me.btnDeleteRun.Size = New System.Drawing.Size(108, 38)
        Me.btnDeleteRun.TabIndex = 1
        Me.btnDeleteRun.Text = "&Delete Run"
        Me.btnDeleteRun.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnSelectByRunNo
        '
        Me.btnSelectByRunNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSelectByRunNo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSelectByRunNo.Image = CType(resources.GetObject("btnSelectByRunNo.Image"), System.Drawing.Image)
        Me.btnSelectByRunNo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSelectByRunNo.Location = New System.Drawing.Point(8, 31)
        Me.btnSelectByRunNo.Name = "btnSelectByRunNo"
        Me.btnSelectByRunNo.Size = New System.Drawing.Size(108, 38)
        Me.btnSelectByRunNo.TabIndex = 0
        Me.btnSelectByRunNo.Text = "&Select By Run no."
        Me.btnSelectByRunNo.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'btnOk
        '
        Me.btnOk.BackColor = System.Drawing.Color.Transparent
        Me.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOk.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOk.Image = CType(resources.GetObject("btnOk.Image"), System.Drawing.Image)
        Me.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnOk.Location = New System.Drawing.Point(374, 108)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(86, 34)
        Me.btnOk.TabIndex = 2
        Me.btnOk.Text = "&OK"
        '
        'frmLoadAnalysis
        '
        Me.AcceptButton = Me.btnOk
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(584, 399)
        Me.Controls.Add(Me.CustomPanelMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLoadAnalysis"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Load Analysis"
        Me.CustomPanelMain.ResumeLayout(False)
        Me.CustomPanelTop.ResumeLayout(False)
        Me.CustomPanelMethod.ResumeLayout(False)
        Me.CustomPanelBottom.ResumeLayout(False)
        Me.gbMultiElementReport.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Private Constants"

    Private Const ConstAnalysedOn = "Analysed On "
    Private Const ConstElementName = "Element Name  "
    Private Const ConstOperationMode = "Mode         "
    Private Const ConstCreatedBy = "Created By  "
    Private Const ConstCreatedOn = "Created On  "
    Private Const ConstStatus = "Status      "
    Private Const ConstChangedOn = "Changed On  "
    Private Const ConstLastUsedOn = "Last Used On"
    Private Const ConstActive = "Active"
    Private Const ConstNotActive = "Inactive"
    Private Const ConstColumnMethodID = "MethodID"
    Private Const ConstColumnRunNumberToSort = "RunNumber"
    Private Const ConstColumnMethodName = "MethodName"
    Private Const ConstColumnRunNo = "RunNo"
    Private Const ConstFormLoad = "-DataFiles-LoadAnalysis"
    Private Const ConstParentFormLoad = "-DataFiles"

#End Region

#Region " Private Member Variables "

    'Private mblnShowByRunNo As Boolean

    Private mblnShowByRunNo As Boolean

    Private mintSelectedMethodID As Integer
    Private mintSelectedRunNo As Integer

    Private mobjPreviewCurve As AldysGraph.CurveItem
    Private intElementID As Integer
    'Private mobjDtRunNos As New DataTable
    Private mobjClsDataFileReport As New clsDataFileReport

    Public Event LoadRunNo(ByVal objClsMethod As clsMethod, ByVal strRunNo As String)
    Private arrRunNoList(100, 0) As Integer
    Private dtMultiReport As DataTable
    Dim Col01 As New DataColumn("ContaintId", GetType(Long))
    Dim Col02 As New DataColumn("SelectMethodID", GetType(String))
    Dim Col03 As New DataColumn("SelectRunID", GetType(String))
    Dim Col04 As New DataColumn("RunDesc", GetType(String))
    Dim Col05 As New DataColumn("MethodIndexID", GetType(String))
    Dim Col06 As New DataColumn("RunIndexID", GetType(String))

    Public Event StoreMultiReportDataTable(ByVal dtMultiReport As DataTable)         'Saurabh 22.07.07

#End Region

#Region " Private Properties "

    'Private Property IsShowByRunNo() As Boolean
    '    Get
    '        Return mblnShowByRunNo
    '    End Get
    '    Set(ByVal Value As Boolean)
    '        mblnShowByRunNo = Value
    '        Try
    '            If mblnShowByRunNo = True Then
    '                Dim objDtRunNos As New DataTable
    '                Dim intCounter As Integer
    '                Dim objRow As DataRow

    '                lbRunNos.Visible = True
    '                lbMethods.Visible = False
    '                lbRunNos.Width = (2 * lbMethods.Width) + 5
    '                lblMethod.Visible = True
    '                txtMethod.Visible = True

    '                objDtRunNos.Columns.Add(ConstColumnRunNo)
    '                'objDtRunNos.Columns.Add(ConstColumnMethodName)

    '                For intCounter = 0 To gobjNewMethod.QuantitativeDataCollection.Count - 1
    '                    objRow = objDtRunNos.NewRow
    '                    objRow.Item(ConstColumnRunNo) = gobjNewMethod.QuantitativeDataCollection.Item(intCounter).RunNumber
    '                    'objRow.Item(ConstColumnMethodName) = gobjMethodCollection.item(intCounter).MethodName
    '                    objDtRunNos.Rows.Add(objRow)
    '                Next
    '                lbRunNos.DataSource = objDtRunNos
    '                lbRunNos.DisplayMember = ConstColumnMethodName
    '                lbRunNos.ValueMember = ConstColumnMethodID
    '                mintSelectedMethodID = CInt(lbRunNos.SelectedValue)
    '            Else
    '                lbRunNos.Visible = True
    '                lbMethods.Visible = True
    '                lbRunNos.Width = lbMethods.Width
    '                lbMethods.Visible = False
    '                txtMethod.Visible = False
    '                mintSelectedMethodID = CInt(lbMethods.SelectedValue)
    '            End If

    '        Catch ex As Exception
    '            '---------------------------------------------------------
    '            'Error Handling and logging
    '            gobjErrorHandler.ErrorDescription = ex.Message
    '            gobjErrorHandler.ErrorMessage = ex.Message
    '            gobjErrorHandler.WriteErrorLog(ex)
    '            '---------------------------------------------------------
    '        Finally
    '            '---------------------------------------------------------
    '            'Writing Execution log
    '            If CONST_CREATE_EXECUTION_LOG = 1 Then
    '                gobjErrorHandler.WriteExecutionLog()
    '            End If
    '            '---------------------------------------------------------
    '        End Try
    '    End Set
    'End Property

    Private Property SelectedRunNo() As Integer
        Get
            Return mintSelectedRunNo
        End Get
        Set(ByVal Value As Integer)
            mintSelectedRunNo = Value

            Dim intCount As Integer
            Dim objDtRunNo As New DataTable
            Dim intRunNumberCounter As Integer
            Dim strRunNumber As String

            Try
                For intCount = 0 To gobjMethodCollection.Count - 1
                    If mintSelectedMethodID = gobjMethodCollection.item(intCount).MethodID Then
                        'If gobjMethodCollection.item(intCount).QuantitativeDataCollection.Count > 0 Then
                        For intRunNumberCounter = 0 To gobjMethodCollection.item(intCount).QuantitativeDataCollection.Count - 1
                            If CInt(gobjMethodCollection.item(intCount).QuantitativeDataCollection.Item(intRunNumberCounter).RunNumber) = mintSelectedRunNo Then
                                intElementID = gobjMethodCollection.item(intCount).InstrumentCondition.ElementID
                                strRunNumber = gobjMethodCollection.item(intCount).QuantitativeDataCollection.Item(intRunNumberCounter).RunNumber
                                Call funcShowMethodGeneralInfo(gobjMethodCollection.item(intCount), strRunNumber)
                                Exit For
                            End If
                        Next
                        'Else
                        'PreviewGraph.Visible = False
                        'End If
                    End If
                Next

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
        End Set
    End Property

    Public ReadOnly Property SelectedMethodID() As Integer
        Get
            Return mintSelectedMethodID
        End Get
    End Property

    Public ReadOnly Property SelectedRunNumber() As Integer
        Get
            Return mintSelectedRunNo
        End Get
    End Property

#End Region

#Region " Form Events"

    Private Sub frmLoadAnalysis_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '=====================================================================
        ' Procedure Name        : frmLoadAnalysis_Load
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To initialize the form
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 28.01.2007
        ' Revisions             : 
        '=====================================================================
        Try
            Call gobjMain.ShowRunTimeInfo(gstrTitleInstrumentType & ConstFormLoad)

            Application.DoEvents()
            '  Add handlers of form object
            Call Addhandlers()
            ' Init the form objects and process
            Call funcInitialise()
            btnSelectByRunNo_Click(sender, e)
            'Call lbMethods_SelectedIndexChanged(lbMethods, EventArgs.Empty)
            lbMethods.Focus()
            'lbRun_SelectedIndexChanged(Me, EventArgs.Empty)
            'SelectedRunNo = lbRunNos.SelectedValue
           
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
            gobjMain.HideProgressBar()
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub frmLoadAnalysis_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        '=====================================================================
        ' Procedure Name        : frmLoadAnalysis_Closing
        ' Parameters Passed     : Object, CancelEventArgs
        ' Returns               : None
        ' Purpose               : To set MultiReport data table as nothing.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 28.01.2007
        ' Revisions             : 
        '=====================================================================
        Try
            'show the progress bar
            gobjMain.ShowRunTimeInfo(gstrTitleInstrumentType & ConstParentFormLoad)
            ' Erase data table 
            If Not (dtMultiReport Is Nothing) Then
                dtMultiReport = Nothing
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
            'objWait.Dispose()
            '---------------------------------------------------------
        End Try
    End Sub

#End Region

#Region " Private Functions "

    Private Sub Addhandlers()
        '=====================================================================
        ' Procedure Name        : Addhandlers
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : To add event handlers
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 28.01.2007
        ' Revisions             : 
        '=====================================================================
        AddHandler btnSelectByRunNo.Click, AddressOf btnSelectByRunNo_Click
        'AddHandler lbRunNos.SelectedIndexChanged, AddressOf lbRunNos_SelectedIndexChanged
        'AddHandler lbMethods.SelectedIndexChanged, AddressOf lbMethods_SelectedIndexChanged
        AddHandler btnOk.Click, AddressOf btnOk_Click

    End Sub

    Private Sub btnSelectByRunNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : btnSelectByRunNo_Click
        ' Parameters Passed     : Object, EventArgs
        ' Returns               : None
        ' Purpose               : To Show the SelectByRunNo. option.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 28.01.2007
        ' Revisions             : 
        '=====================================================================
        Try
            ' Set the setting of selection of Run No by "Load Analysis Run Report by Method"
            If blnFlag = False Then
                Me.Text = "Load Analysis Run Report by Method"
                lbMethods.Visible = True
                lbMethods.Location = New Point(18, 27)
                lbRunNos.Width = 129
                lbRunNos.Location = New Point(191, 27)
                lblMethod.Visible = False
                txtMethod.Visible = False
                CustomPanelMethod.Dock = DockStyle.Fill
                CustomPanelMethod.Visible = True
                btnSelectByRunNo.Text = "Select By Run No."
                lblMethods.Visible = True
                lblRuns.Location = New Point(191, 7)
                blnFlag = True
                Call lbMethods_SelectedIndexChanged(sender, e)
                mblnShowByRunNo = False
            Else
                ' Set the setting of selection of Run No by "Load Analysis Run Report by Run Nos."
                Me.Text = "Load Analysis Run Report by Run Nos."
                lbRunNos.Width = (2 * lbMethods.Width)
                lbMethods.Visible = False
                lbRunNos.Location = New Point(18, 27)
                lblMethod.Visible = True
                txtMethod.Visible = True
                lblMethods.Visible = False
                lblRuns.Location = New Point(18, 7)
                btnSelectByRunNo.Text = "Select By Method"
                blnFlag = False
                lbRunNos.Refresh()
                Call SelectByRunNo()
                mblnShowByRunNo = True
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
            'objWait.Dispose()
            '---------------------------------------------------------
        End Try
    End Sub

    Private Function funcInitialise() As Boolean
        '=====================================================================
        ' Procedure Name        : funcInitialise
        ' Parameters Passed     : None
        ' Returns               : True or False
        ' Purpose               : To initialise the Load Analysis form.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 28.01.2007
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor

        Dim objDtMethods As New DataTable
        Dim intCounter As Integer
        Dim objRow As DataRow

        Try
            funcInitialise = False
            blnFlag = True

            btnRemove.Enabled = False
            btnCreateReport.Enabled = False

            Me.Text = "Load Analysis Run Report by Method"
            CustomPanelMethod.Dock = DockStyle.Fill

            RemoveHandler lbMethods.SelectedIndexChanged, AddressOf lbMethods_SelectedIndexChanged
            ' loads all methods from file system
            If funcLoadMethods() = True Then
                ' Load method data object into Data Table
                If gobjMethodCollection.Count > 0 Then
                    objDtMethods.Columns.Add(ConstColumnMethodID)
                    objDtMethods.Columns.Add(ConstColumnMethodName)
                    mintSelectedMethodID = 0

                    For intCounter = gobjMethodCollection.Count - 1 To 0 Step -1
                        objRow = objDtMethods.NewRow
                        objRow.Item(ConstColumnMethodID) = gobjMethodCollection.item(intCounter).MethodID
                        objRow.Item(ConstColumnMethodName) = gobjMethodCollection.item(intCounter).MethodName
                        objDtMethods.Rows.Add(objRow)
                    Next
                    lbMethods.DataSource = objDtMethods
                    lbMethods.DisplayMember = ConstColumnMethodName
                    lbMethods.ValueMember = ConstColumnMethodID
                    lbMethods.Refresh()
                End If
            End If
            Dim intCount As Integer
            ' Init array for Run No list.
            For intCount = 0 To arrRunNoList.GetUpperBound(0)
                arrRunNoList(intCount, 0) = -1
            Next

            AddHandler lbMethods.SelectedIndexChanged, AddressOf lbMethods_SelectedIndexChanged
            lbMethods_SelectedIndexChanged(Me, New EventArgs)
            
            funcInitialise = True
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
            'objWait.Dispose()
            '---------------------------------------------------------
        End Try
    End Function

    Private Function funcLoadRunNos() As Boolean
        '=====================================================================
        ' Procedure Name        : funcLoadRunNos
        ' Parameters Passed     : None
        ' Returns               : True or false
        ' Purpose               : To Load all the RunNos. of selected Method.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 28.01.2007
        ' Revisions             : 
        '=====================================================================
        Dim intMethodCounter As Integer
        Dim intRunCounter As Integer
        Dim objDtRunNo As New DataTable
        Dim objDrNewRow As DataRow

        Try
            ' Load Run No and Method no into Data table
            mintSelectedRunNo = -1
            objDtRunNo.Columns.Add(ConstColumnRunNo)
            objDtRunNo.Columns.Add(ConstColumnMethodID)
            ' use loop to store run No and method no
            For intMethodCounter = 0 To gobjMethodCollection.Count - 1
                For intRunCounter = 0 To gobjMethodCollection.item(intMethodCounter).QuantitativeDataCollection.Count - 1
                    If Not Val(gobjMethodCollection.item(intMethodCounter).QuantitativeDataCollection.Item(intRunCounter).RunNumber) = -1.0 Then
                        objDrNewRow = objDtRunNo.NewRow
                        objDrNewRow.Item(ConstColumnRunNo) = gobjMethodCollection.item(intMethodCounter).QuantitativeDataCollection.Item(intRunCounter).RunNumber
                        objDrNewRow.Item(ConstColumnMethodID) = gobjMethodCollection.item(intMethodCounter).MethodID
                        objDtRunNo.Rows.Add(objDrNewRow)
                    End If
                Next
            Next

            lbRunNos.DataSource = objDtRunNo
            lbRunNos.DisplayMember = ConstColumnRunNo
            lbRunNos.ValueMember = ConstColumnRunNo
            lbRunNos.Refresh()

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
            'objWait.Dispose()
            '---------------------------------------------------------
        End Try
    End Function

    Private Function funcShowMethodGeneralInfo(ByVal objMethod As clsMethod, ByVal strRunNumber As String) As Boolean
        '=====================================================================
        ' Procedure Name        : funcShowMethodGeneralInfo
        ' Parameters Passed     : clsMethod object, Run Number
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

            lbMethodComments.Text = objMethod.Comments
            ' get Method info. into data table
            objRow = gobjClsAAS203.funcGetMethodType(objMethod.OperationMode)

            ' Set form object of method info. from data table 
            If Not objRow Is Nothing Then
                If objMethod.OperationMode = 2 Or objMethod.OperationMode = 4 Then
                    txtMethod.Text = ""
                End If
            End If

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

            txtMethod.Text = CStr(objMethod.MethodName)

            '//----- Added by Sachin Dokhale
            Dim strOperationMode As String
            Dim strElementName As String
            Dim objDtElements As DataTable
            ' Get Element details from cookbook
            objDtElements = gobjDataAccess.GetCookBookData(objMethod.InstrumentCondition.ElementID)
            If Not objDtElements Is Nothing Then
                If objDtElements.Rows.Count > 0 Then
                    strElementName = objDtElements.Rows(0).Item(ConstColumnElementName)
                End If
                objDtElements = Nothing
            End If
            ' Set operation mode
            Select Case objMethod.OperationMode
                Case EnumOperationMode.MODE_AA
                    strOperationMode = "AA Quantitative Mode"
                Case EnumOperationMode.MODE_AABGC
                    strOperationMode = "AABGC Quantitative Mode"
                Case EnumOperationMode.MODE_EMMISSION
                    strOperationMode = "Emission Quantitative Mode"
                Case EnumOperationMode.MODE_UVABS
                    strOperationMode = "UV Quantitative Mode"
                Case Else
                    strOperationMode = "AA Quantitative Mode"
            End Select
            '//-----

            ' Set general Method info to the form object
            lbMethodInformation.Items.Clear()
            '//----- Added by Sachin Dokhale


            'lbMethodInformation.Items.Add(ConstAnalysedOn & vbTab & CStr(Format(objMethod.DateOfLastUse, "dd-MMM-yyyy hh:mm tt"))) 'code commented by : dinesh wagh on 10.2.2010

            '-------------------------------------------------
            'by dinesh wagh on 10.2.2010
            '--------------------------------------------------
            Dim intRunIndex As Integer
            For intRunIndex = 0 To objMethod.QuantitativeDataCollection.Count - 1
                If objMethod.QuantitativeDataCollection(intRunIndex).RunNumber = strRunNumber Then
                    Exit For
                End If
            Next
            lbMethodInformation.Items.Add(ConstAnalysedOn & vbTab & CStr(Format(objMethod.QuantitativeDataCollection(intRunIndex).AnalysisParameters.Analysis_Date, "dd-MMM-yyyy hh:mm tt")))
            '----------------------------------------------



            lbMethodInformation.Items.Add(ConstElementName & vbTab & strElementName)
            lbMethodInformation.Items.Add(ConstOperationMode & vbTab & strOperationMode)
            '//-----
            lbMethodInformation.Items.Add(ConstCreatedBy & vbTab & objMethod.UserName)
            lbMethodInformation.Items.Add(ConstCreatedOn & vbTab & Format(objMethod.DateOfCreation, "dd-MMM-yyyy hh:mm tt"))


            lbMethodInformation.Items.Add(ConstStatus & vbTab & strStatus)
            lbMethodInformation.Items.Add(ConstChangedOn & vbTab & strDateOfModification)
            lbMethodInformation.Items.Add(ConstLastUsedOn & vbTab & strDateOfLastUse)
            ' Set graph porperty depending upon opration mode
            Select Case objMethod.OperationMode
                Case EnumOperationMode.MODE_UVABS
                    PreviewGraph.Visible = False

                    'Saurabh 28 MAy 2007---------------------------------------
                Case EnumOperationMode.MODE_EMMISSION
                    PreviewGraph.Visible = True
                    PreviewGraph.YAxisLabel = "EMISSION"
                    PreviewGraph.YAxisMin = 0
                    PreviewGraph.YAxisMax = 100
                    PreviewGraph.YAxisMinorStep = 2
                    PreviewGraph.YAxisStep = 10
                    Call gobjClsAAS203.subShowGraphPreview(Me.PreviewGraph, mobjPreviewCurve, strRunNumber, objMethod)
                    PreviewGraph.IsShowGrid = True
                    PreviewGraph.Invalidate()
                    PreviewGraph.Refresh()
                    Me.Refresh()
                    PreviewGraph.Refresh()
                    Application.DoEvents()
                    'Saurabh 28 MAy 2007---------------------------------------

                    'Saurabh 30 MAy 2007---------------------------------------
                Case EnumOperationMode.MODE_AA
                    PreviewGraph.Visible = True
                    PreviewGraph.YAxisLabel = "ABSORBANCE"
                    PreviewGraph.YAxisMin = -0.2
                    PreviewGraph.YAxisMax = 1.1
                    PreviewGraph.YAxisMinorStep = 0.05
                    PreviewGraph.YAxisStep = 0.1
                    Call gobjClsAAS203.subShowGraphPreview(Me.PreviewGraph, mobjPreviewCurve, strRunNumber, objMethod)
                    PreviewGraph.IsShowGrid = True
                    PreviewGraph.Invalidate()
                    Me.Refresh()
                    Application.DoEvents()
                    'Saurabh 30 MAy 2007---------------------------------------

                Case Else
                    PreviewGraph.Visible = True
                    ' Show graph preview
                    Call gobjClsAAS203.subShowGraphPreview(Me.PreviewGraph, mobjPreviewCurve, strRunNumber, objMethod)
                    PreviewGraph.IsShowGrid = True
                    Me.PreviewGraph.Refresh()
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

    Private Function SelectByRunNo() As Boolean
        '=====================================================================
        ' Procedure Name        : SelectByRunNo
        ' Parameters Passed     : None
        ' Returns               : True or False
        ' Purpose               : To Show the SelectByRunNo. option.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 28.01.2007
        ' Revisions             : 
        '=====================================================================
        Dim objDtRunNos As DataTable
        Dim intCounter As Integer
        Dim objRow As DataRow
        Dim intMethodCounter As Integer
        Dim RunNo(99) As String

        Try
            ' Set the Run no list box by selecting Run no
            RemoveHandler lbRunNos.SelectedIndexChanged, AddressOf lbRunNos_SelectedIndexChanged
            ' Set Data table for Run no
            If IsNothing(objDtRunNos) Then
                objDtRunNos = New DataTable

                objDtRunNos.Columns.Add(ConstColumnRunNo, System.Type.GetType("System.String"))
                objDtRunNos.Columns.Add(ConstColumnMethodID, System.Type.GetType("System.Int32"))
                objDtRunNos.Columns.Add(ConstColumnRunNumberToSort, System.Type.GetType("System.Int32"))
            End If

            For intMethodCounter = 0 To gobjMethodCollection.Count - 1
                For intCounter = 0 To gobjMethodCollection.item(intMethodCounter).QuantitativeDataCollection.Count - 1
                    If Not Val(gobjMethodCollection.item(intMethodCounter).QuantitativeDataCollection.Item(intCounter).RunNumber) = -1.0 Then
                        objRow = objDtRunNos.NewRow
                        objRow.Item(ConstColumnRunNo) = gobjMethodCollection.item(intMethodCounter).QuantitativeDataCollection.Item(intCounter).RunNumber
                        objRow.Item(ConstColumnMethodID) = gobjMethodCollection.item(intMethodCounter).MethodID
                        objRow.Item(ConstColumnRunNumberToSort) = Convert.ToInt32(gobjMethodCollection.item(intMethodCounter).QuantitativeDataCollection.Item(intCounter).RunNumber)
                        objDtRunNos.Rows.Add(objRow)
                        'RunNo(intMethodCounter) = gobjMethodCollection.item(intMethodCounter).QuantitativeDataCollection.Item(intCounter).RunNumber
                    End If
                Next
            Next
            ' arrange the data table in Desc. order
            objDtRunNos.DefaultView.Sort = ConstColumnRunNumberToSort & " Desc"

            ' Set the Run no list box property for data table
            If Not IsNothing(objDtRunNos) Then
                lbRunNos.DataSource = Nothing
                lbRunNos.DataSource = objDtRunNos.DefaultView
                lbRunNos.DisplayMember = ConstColumnRunNo
                lbRunNos.ValueMember = ConstColumnRunNo
                lbRunNos.SelectedIndex = 0
                lbRunNos.Refresh()
            Else
                lbRunNos.DataSource = Nothing
                lbRunNos.SelectedIndex = -1
            End If

            AddHandler lbRunNos.SelectedIndexChanged, AddressOf lbRunNos_SelectedIndexChanged
            lbRunNos_SelectedIndexChanged(Me, New System.EventArgs)
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
            'objWait.Dispose()
            '---------------------------------------------------------
        End Try
    End Function

    Private Sub lbRunNos_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : lbRunNos_SelectedIndexChanged
        ' Parameters Passed     : Object, EventArgs
        ' Returns               : None
        ' Purpose               : To Load the Run nos. details.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 27.01.2007
        ' Revisions             : Deepak on 04.08.07
        '=====================================================================
        Dim intCount As Integer
        Dim dv As New DataView
        Try
            ' Select Method Id from Run no list box
            ' Select Run No from Run no list box
            If Not lbRunNos.Items.Count = 0 Then
                btnOk.Enabled = True
                btnDeleteRun.Enabled = True
                btnAddRun.Enabled = True
                If mblnShowByRunNo = True Then

                    If Not lbRunNos.DataSource Is Nothing Then
                        If TypeOf lbRunNos.DataSource Is DataView Then
                            dv = CType(lbRunNos.DataSource, DataView)
                            For intCount = 0 To dv.Count - 1
                                If dv.Item(intCount).Row.Item(ConstColumnRunNo) = CInt(lbRunNos.SelectedValue) Then
                                    mintSelectedMethodID = dv.Item(intCount).Row.Item(ConstColumnMethodID)
                                End If
                            Next
                        End If
                    End If
                Else
                    mintSelectedMethodID = CInt(lbMethods.SelectedValue)
                End If
                SelectedRunNo = CInt(lbRunNos.SelectedValue)
                lbRunNos.Refresh()
                PreviewGraph.Refresh()
            Else
                btnOk.Enabled = False
                btnDeleteRun.Enabled = False
                btnAddRun.Enabled = False
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
            'objWait.Dispose()
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub lbMethods_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : lbMethods_SelectedIndexChanged
        ' Parameters Passed     : Object, EventArgs
        ' Returns               : None
        ' Purpose               : To load selected method
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 27.01.2007
        ' Revisions             : 
        '=====================================================================
        Try
            lbMethodComments.Text = ""
            lbMethodInformation.Items.Clear()
            ' Select Method ID and to select Method info.
            mintSelectedMethodID = CInt(lbMethods.SelectedValue)

            Call funcLoadSelectedMethod(mintSelectedMethodID)

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
            'objWait.Dispose()
            '---------------------------------------------------------
        End Try
    End Sub

    Private Function funcLoadSelectedMethod(ByVal intMethodID As Integer) As Boolean
        '=====================================================================
        ' Procedure Name        : funcLoadSelectedMethod
        ' Parameters Passed     : Selected method ID
        ' Returns               : True if success
        ' Purpose               : To load the selected method.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 28.01.2007
        ' Revisions             : 
        '=====================================================================
        Dim objDtRunNos As DataTable
        Dim intCounter As Integer
        Dim objRow As DataRow
        Dim intMethodCounter As Integer

        Try
            RemoveHandler lbRunNos.SelectedIndexChanged, AddressOf lbRunNos_SelectedIndexChanged
            ' Select method details from Method collection into data table
            For intMethodCounter = gobjMethodCollection.Count - 1 To 0 Step -1
                If gobjMethodCollection.item(intMethodCounter).MethodID = intMethodID Then
                    If gobjMethodCollection.item(intMethodCounter).QuantitativeDataCollection.Count > 0 Then
                        For intCounter = gobjMethodCollection.item(intMethodCounter).QuantitativeDataCollection.Count - 1 To 0 Step -1
                            If Not Val(gobjMethodCollection.item(intMethodCounter).QuantitativeDataCollection.Item(intCounter).RunNumber) = -1.0 Then
                                If IsNothing(objDtRunNos) Then
                                    objDtRunNos = New DataTable
                                    objDtRunNos.Columns.Add(ConstColumnRunNo)
                                    objDtRunNos.Columns.Add(ConstColumnMethodID)
                                End If
                                ' Add method details into data table
                                objRow = objDtRunNos.NewRow
                                objRow.Item(ConstColumnRunNo) = gobjMethodCollection.item(intMethodCounter).QuantitativeDataCollection.Item(intCounter).RunNumber
                                objRow.Item(ConstColumnMethodID) = gobjMethodCollection.item(intMethodCounter).MethodID
                                objDtRunNos.Rows.Add(objRow)
                            End If
                        Next
                        Exit For
                    Else
                        PreviewGraph.Visible = False
                    End If
                End If
            Next

            If Not IsNothing(objDtRunNos) Then
                lbRunNos.DataSource = Nothing
                lbRunNos.DataSource = objDtRunNos
                lbRunNos.DisplayMember = ConstColumnRunNo
                lbRunNos.ValueMember = ConstColumnRunNo
                lbRunNos.SelectedIndex = 0
            Else
                lbRunNos.DataSource = Nothing
                lbRunNos.SelectedIndex = -1
            End If

            AddHandler lbRunNos.SelectedIndexChanged, AddressOf lbRunNos_SelectedIndexChanged

            Call lbRunNos_SelectedIndexChanged(lbRunNos, EventArgs.Empty)

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

    Private Sub btnOk_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : btnOk_Click
        ' Parameters Passed     : Object, EventArgs
        ' Returns               : None
        ' Purpose               : None
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 28.01.2007
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Dim intCounter As Integer
        Dim intCount As Integer
        Dim strRunNo As String

        Try
            ' Create multi report 
            If Not dtMultiReport Is Nothing Then
                RaiseEvent StoreMultiReportDataTable(dtMultiReport)
            End If

            Me.DialogResult = DialogResult.OK

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
            'objWait.Dispose()
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub btnAddRun_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddRun.Click
        '=====================================================================
        ' Procedure Name        : btnAddRun_Click
        ' Parameters Passed     : Object, EventArgs
        ' Returns               : None
        ' Purpose               : To add run nos. for multi report.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 28.01.2007
        ' Revisions             : 
        '=====================================================================
        Dim strElementName As String
        Dim objDtElements As New DataTable
        Static intMethod As Integer = 0
        Static intRunNo As Integer
        Dim intCount As Integer
        Dim blnFoundMethod As Boolean = False
        Dim blnFoundRunNo As Boolean = False
        Static intSndDime As Integer
        Dim blnAddRunNo As Boolean
        Dim intCount1 As Integer
        Dim intSelectId As Integer
        Dim DtRow As DataRow
        Dim blnIsRunFound As Boolean
        Dim intRowIndex As Integer
        ' Add Run No against Method No into 2 diamentional array
        ' This function logic is use to store unic Run no against Method ID in 2 dimetional array
        ' as a 1st col. holds the method ID and against it from 2 cols. it holds Run No. 
        ' each Run No is unic for that method ID. Logic is written in that way.
        Try
            ' Add Run No into list box to create multi report
            objDtElements = gobjDataAccess.GetCookBookData(intElementID)
            If Not objDtElements Is Nothing Then
                If objDtElements.Rows.Count > 0 Then
                    strElementName = objDtElements.Rows(0).Item(ConstColumnElementName)
                End If
            End If
            ' Init Multi report columns
            If (dtMultiReport Is Nothing) Then
                dtMultiReport = New DataTable

                dtMultiReport.Columns.Add(Col01)
                dtMultiReport.Columns.Add(Col02)
                dtMultiReport.Columns.Add(Col03)
                dtMultiReport.Columns.Add(Col04)
                dtMultiReport.Columns.Add(Col05)
                dtMultiReport.Columns.Add(Col06)

            End If
            
            If Not (dtMultiReport Is Nothing) Then
                'Saurabh 12.07.07 TO set Max Run Nos. for Multielement Report
                If dtMultiReport.Rows.Count > 9 Then
                    gobjMessageAdapter.ShowMessage("You can select maximum 10 Run numbers only", "Run Number", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage)
                    Exit Sub
                End If
                'Saurabh 12.07.07 TO set Max Run Nos. for Multielement Report

                If dtMultiReport.Rows.Count > 0 Then
                    For intRowIndex = 0 To dtMultiReport.Rows.Count - 1
                        If mintSelectedMethodID = CInt(dtMultiReport.Rows(intRowIndex).Item(1)) Then
                            If mintSelectedRunNo = CInt(dtMultiReport.Rows(intRowIndex).Item(2)) Then
                                blnIsRunFound = True
                                Exit For
                            End If
                        End If
                    Next
                End If
            End If

            'If lbRun.Items.Contains(lbRunNos.SelectedValue & "      " & strElementName) Then
            If blnIsRunFound = True Then
                Exit Sub
            Else
                ' Init List box object
                lbRun.DataSource = dtMultiReport
                lbRun.DisplayMember = "RunDesc"
                lbRun.ValueMember = "ContaintId"
                lbRun.Refresh()
                ' Add Method no and selected Run No into multi array 
                If Not arrRunNoList Is Nothing Then
                    If arrRunNoList.GetUpperBound(0) > 0 Then
                        Do While intCount <= arrRunNoList.GetUpperBound(0)
                            If arrRunNoList(intCount, 0) = mintSelectedMethodID Then
                                blnFoundMethod = True
                                intMethod = intCount + 1
                                Exit Do
                            End If
                            intCount += 1
                        Loop

                        If blnFoundMethod = False Then
                            intMethod += 1
                            intRunNo = 0
                        End If

                        Do While intCount <= arrRunNoList.GetUpperBound(1)
                            If arrRunNoList(intMethod, intCount) = mintSelectedRunNo Then
                                blnFoundRunNo = True
                                intRunNo = intCount + 1
                                Exit Do
                            End If
                            intCount += 1
                        Loop

                        If blnFoundRunNo = False Then
                            intRunNo += 1
                        End If
                    End If

                    If intSndDime < intRunNo Then
                        intSndDime = intRunNo
                        ReDim Preserve arrRunNoList(100, intSndDime)
                    End If

                    For intCount = 0 To gobjMethodCollection.Count - 1
                        If mintSelectedMethodID = gobjMethodCollection(intCount).MethodID Then
                            intSelectId = intCount
                            mobjClsDataFileReport.MethodID = intCount
                            arrRunNoList(intMethod - 1, 0) = intSelectId + 1 ' - 1
                            Exit For
                        End If
                    Next

                    For intCount = 0 To gobjMethodCollection(intSelectId).QuantitativeDataCollection.Count - 1
                        If mintSelectedRunNo = CInt(gobjMethodCollection(intSelectId).QuantitativeDataCollection(intCount).RunNumber) Then
                            intSelectId = intCount
                            mobjClsDataFileReport.RunNumber = intCount
                            arrRunNoList(intMethod - 1, intRunNo) = intSelectId + 1
                            If blnIsRunFound = False Then
                                DtRow = dtMultiReport.NewRow()
                                DtRow(0) = dtMultiReport.Rows.Count
                                DtRow(1) = mintSelectedMethodID
                                DtRow(2) = mintSelectedRunNo
                                DtRow(3) = lbRunNos.SelectedValue & "      " & strElementName
                                DtRow(4) = arrRunNoList(intMethod - 1, 0)
                                DtRow(5) = arrRunNoList(intMethod - 1, intRunNo)
                                dtMultiReport.Rows.Add(DtRow)
                            End If
                            blnAddRunNo = True
                            Exit For
                        End If
                    Next

                    If blnAddRunNo Then
                        For intCount = 0 To intMethod
                            For intCount1 = 0 To intSndDime
                                If arrRunNoList(intCount, intCount1) = 0 Then
                                    arrRunNoList(intCount, intCount1) = -1
                                End If
                            Next
                        Next
                    End If
                Else
                    'ReDim arrRunNoList(intMethod - 1, lbRun.Items.Count)
                End If
            End If

            lbRun.TopIndex = lbRun.SelectedIndex
            lbRun.SelectedIndex = 0

            btnRemove.Enabled = True
            btnCreateReport.Enabled = True
            lbRun.Refresh()



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
            'objWait.Dispose()
            '---------------------------------------------------------
        End Try

    End Sub

    Private Sub btnRemove_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRemove.Click
        '=====================================================================
        ' Procedure Name        : btnRemove_Click
        ' Parameters Passed     : Object, EventArgs
        ' Returns               : None
        ' Purpose               : To remove the run nos added for multi report.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 28.01.2007
        ' Revisions             : 
        '=====================================================================
        Try
            Dim blnFoundMethod As Boolean
            Dim intCount, intCount1, intCount2 As Integer
            ' remove the run nos added for multi report from list box of multireport.
            'lbRun.Items.Remove(lbRun.SelectedItem)
            If lbRun.Items.Count > 0 Then
                btnRemove.Enabled = True
                btnCreateReport.Enabled = True

                ' Search Selected Run into array and remove from it.
                Dim blnIsRemoveRow As Boolean = False
                If arrRunNoList.GetUpperBound(1) > 0 Then
                    Do While intCount <= arrRunNoList.GetUpperBound(0)
                        Do While intCount1 <= arrRunNoList.GetUpperBound(1)
                            intCount2 = lbRun.SelectedIndex
                            If dtMultiReport.Rows(intCount2).Item(4) = arrRunNoList(intCount, 0) Then
                                If dtMultiReport.Rows(intCount2).Item(5) = arrRunNoList(intCount, intCount1) Then
                                    arrRunNoList(intCount, intCount1) = 0
                                    'lbRun.Items.Remove(lbRun.SelectedItem)
                                    dtMultiReport.Rows.Remove(lbRun.SelectedItem.row)
                                    lbRun.Refresh()
                                    blnIsRemoveRow = True
                                    Exit Do
                                End If
                            End If
                            If lbRun.Items.Count > 0 Then
                                btnRemove.Enabled = True
                                btnCreateReport.Enabled = True
                            Else
                                btnRemove.Enabled = False
                                btnCreateReport.Enabled = False
                            End If

                            intCount1 += 1
                        Loop
                        intCount += 1
                        intCount1 = 0
                        If blnIsRemoveRow = True Then
                            Exit Do
                        End If
                    Loop
                End If
            Else
                btnRemove.Enabled = False
                btnCreateReport.Enabled = False
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
            'objWait.Dispose()
            '---------------------------------------------------------
        End Try

    End Sub

    Private Sub btnDeleteRun_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDeleteRun.Click
        '=====================================================================
        ' Procedure Name        : btnDeleteRun_Click
        ' Parameters Passed     : Object, EventArgs
        ' Returns               : None
        ' Purpose               : To delete the saved run nos.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 28.01.2007
        ' Revisions             : Deepak on 04.08.07
        '=====================================================================
        Dim objWait As CWaitCursor
        Dim intRunNumberCounter As Integer
        Dim intCount As Integer
        Dim objRow As DataRow
        Dim objDtMethods As New DataTable

        Try
            'delete the saved run no from Method collection object.
            If gobjMessageAdapter.ShowMessage(constSelectedRunNo) = True Then
                Application.DoEvents()
                objWait = New CWaitCursor
                For intCount = gobjMethodCollection.Count - 1 To 0 Step -1
                    If gobjMethodCollection.item(intCount).MethodID = mintSelectedMethodID Then
                        For intRunNumberCounter = 0 To gobjMethodCollection.item(intCount).QuantitativeDataCollection.Count - 1
                            If CInt(gobjMethodCollection.item(intCount).QuantitativeDataCollection.Item(intRunNumberCounter).RunNumber) = mintSelectedRunNo Then
                                gobjMethodCollection.item(intCount).QuantitativeDataCollection.RemoveAt(intRunNumberCounter)
                                Exit For
                            End If
                        Next
                    End If
                Next

                RemoveHandler lbRunNos.SelectedIndexChanged, AddressOf lbRunNos_SelectedIndexChanged
                ' Init Method collection and form object
                If funcSaveAllMethods(gobjMethodCollection) Then
                    RemoveHandler lbMethods.SelectedIndexChanged, AddressOf lbMethods_SelectedIndexChanged
                    If funcLoadMethods() = True Then
                        If gobjMethodCollection.Count > 0 Then
                            objDtMethods.Columns.Add(ConstColumnMethodID)
                            objDtMethods.Columns.Add(ConstColumnMethodName)
                            For intCount = gobjMethodCollection.Count - 1 To 0 Step -1
                                objRow = objDtMethods.NewRow
                                objRow.Item(ConstColumnMethodID) = gobjMethodCollection.item(intCount).MethodID
                                objRow.Item(ConstColumnMethodName) = gobjMethodCollection.item(intCount).MethodName
                                objDtMethods.Rows.Add(objRow)
                            Next
                            lbMethods.DataSource = objDtMethods
                            lbMethods.DisplayMember = ConstColumnMethodName
                            lbMethods.ValueMember = ConstColumnMethodID
                            lbMethods.Refresh()
                        End If
                    End If

                    AddHandler lbMethods.SelectedIndexChanged, AddressOf lbMethods_SelectedIndexChanged
                    AddHandler lbRunNos.SelectedIndexChanged, AddressOf lbRunNos_SelectedIndexChanged

                    If mblnShowByRunNo = True Then
                        SelectByRunNo()
                    Else
                        lbMethods.SelectedValue = mintSelectedMethodID
                        lbMethods_SelectedIndexChanged(sender, e)
                    End If
                    
                    gobjMessageAdapter.ShowMessage(constSelectedRunNoDeletd)
                End If
            End If

            lbRunNos.Refresh()
            Application.DoEvents()
            If lbRunNos.Items.Count = 0 Then
                btnOk.Enabled = False
                btnDeleteRun.Enabled = False
                btnAddRun.Enabled = False
            End If
            btnOk.Focus()
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

    Private Sub btnCreateReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreateReport.Click
        '=====================================================================
        ' Procedure Name        : btnCreateReport_Click
        ' Parameters Passed     : Object, EventArgs
        ' Returns               : 
        ' Purpose               : To show the multi Reports.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 05.10.06
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Dim intCount, intCount1 As Integer
        Try

           
            ' Create the multi report for selected Run Nos
            mobjClsDataFileReport.DefaultFont = Me.DefaultFont()
            Call mobjClsDataFileReport.funcMultiReport(arrRunNoList)

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

    Private Sub lbRun_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbRun.SelectedIndexChanged
        '=====================================================================
        ' Procedure Name        : lbRun_SelectedIndexChanged
        ' Parameters Passed     : Object, EventArgs
        ' Returns               : None
        ' Purpose               : Select the Run for add or remove multi report
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 28.01.2007
        ' Revisions             : 
        '=====================================================================
        Try
            'Select the Run for add or remove multi report
            If lbRun.Items.Count = 0 Then
                btnRemove.Enabled = False
                btnCreateReport.Enabled = False
            Else
                btnRemove.Enabled = True
                btnCreateReport.Enabled = True
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

    Private Sub frmLoadAnalysis_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        '=====================================================================
        ' Procedure Name        : frmLoadAnalysis_Activated
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To Activated the form
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 28.01.2007
        ' Revisions             : 
        '=====================================================================
        SelectedRunNo = lbRunNos.SelectedValue
    End Sub

End Class
