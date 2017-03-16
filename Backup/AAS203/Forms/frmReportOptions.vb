Imports AAS203.Common
Imports AAS203Library.Method

Public Class frmReportOptions
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    Public Sub New(ByVal intMethodMode As Integer, ByVal blnIsDataFilesMode As Boolean, ByVal intSelectedMethodID As Integer, ByVal intSelectedRunNumber As Integer)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        OpenMethodMode = intMethodMode
        mblnIsDataFilesMode = blnIsDataFilesMode
        mintSelectedRunNumber = intSelectedRunNumber
        mintSelectedMethodID = intSelectedMethodID

    End Sub

    Public Sub New(ByVal intMethodMode As Integer, ByVal blnIsDataFilesMode As Boolean, ByVal intSelectedMethodID As Integer, ByVal intSelectedRunNumber As Integer, ByVal objClsMethod As clsMethod)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        OpenMethodMode = intMethodMode
        mblnIsDataFilesMode = blnIsDataFilesMode
        mintSelectedRunNumber = intSelectedRunNumber
        mintSelectedMethodID = intSelectedMethodID
        mobjClsMethod = New clsMethod
        mobjClsMethod = objClsMethod

    End Sub

    'Public Sub New(ByVal intFlag As Integer)
    '    MyBase.New()

    '    'This call is required by the Windows Form Designer.
    '    InitializeComponent()

    '    'Add any initialization after the InitializeComponent() call
    '    mintFlag = intFlag

    'End Sub

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
    Friend WithEvents Office2003Header1 As CodeIntellects.Office2003Controls.Office2003Header
    Friend WithEvents CustomPanel1 As GradientPanel.CustomPanel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnHelp As NETXP.Controls.XPButton
    Friend WithEvents btnOk As NETXP.Controls.XPButton
    Friend WithEvents btnCancel As NETXP.Controls.XPButton
    Friend WithEvents txtReportFooter As System.Windows.Forms.TextBox
    Friend WithEvents txtReportHeader As System.Windows.Forms.TextBox
    Friend WithEvents lblReportFooter1 As System.Windows.Forms.Label
    Friend WithEvents lblReportHeader1 As System.Windows.Forms.Label
    Friend WithEvents cbReportHeader As System.Windows.Forms.CheckBox
    Friend WithEvents cbInstrumentCondition As System.Windows.Forms.CheckBox
    Friend WithEvents cbAnalysisParameters As System.Windows.Forms.CheckBox
    Friend WithEvents cbMethodInfo As System.Windows.Forms.CheckBox
    Friend WithEvents cbStandards As System.Windows.Forms.CheckBox
    Friend WithEvents cbAbsorbance As System.Windows.Forms.CheckBox
    Friend WithEvents cbWeightVolumeDilution As System.Windows.Forms.CheckBox
    Friend WithEvents lblHeading As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmReportOptions))
        Me.Office2003Header1 = New CodeIntellects.Office2003Controls.Office2003Header
        Me.CustomPanel1 = New GradientPanel.CustomPanel
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txtReportFooter = New System.Windows.Forms.TextBox
        Me.txtReportHeader = New System.Windows.Forms.TextBox
        Me.lblReportFooter1 = New System.Windows.Forms.Label
        Me.lblReportHeader1 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cbReportHeader = New System.Windows.Forms.CheckBox
        Me.cbInstrumentCondition = New System.Windows.Forms.CheckBox
        Me.cbAnalysisParameters = New System.Windows.Forms.CheckBox
        Me.cbMethodInfo = New System.Windows.Forms.CheckBox
        Me.cbStandards = New System.Windows.Forms.CheckBox
        Me.cbAbsorbance = New System.Windows.Forms.CheckBox
        Me.cbWeightVolumeDilution = New System.Windows.Forms.CheckBox
        Me.lblHeading = New System.Windows.Forms.Label
        Me.btnCancel = New NETXP.Controls.XPButton
        Me.btnOk = New NETXP.Controls.XPButton
        Me.btnHelp = New NETXP.Controls.XPButton
        Me.CustomPanel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Office2003Header1
        '
        Me.Office2003Header1.BackColor = System.Drawing.SystemColors.Control
        Me.Office2003Header1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Office2003Header1.Location = New System.Drawing.Point(0, 0)
        Me.Office2003Header1.Name = "Office2003Header1"
        Me.Office2003Header1.Size = New System.Drawing.Size(404, 22)
        Me.Office2003Header1.TabIndex = 0
        Me.Office2003Header1.TitleFont = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Office2003Header1.TitleText = "Report Options"
        '
        'CustomPanel1
        '
        Me.CustomPanel1.BackColor = System.Drawing.Color.Transparent
        Me.CustomPanel1.Controls.Add(Me.GroupBox2)
        Me.CustomPanel1.Controls.Add(Me.GroupBox1)
        Me.CustomPanel1.Controls.Add(Me.btnCancel)
        Me.CustomPanel1.Controls.Add(Me.btnOk)
        Me.CustomPanel1.Controls.Add(Me.btnHelp)
        Me.CustomPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CustomPanel1.Location = New System.Drawing.Point(0, 22)
        Me.CustomPanel1.Name = "CustomPanel1"
        Me.CustomPanel1.Size = New System.Drawing.Size(404, 375)
        Me.CustomPanel1.TabIndex = 1
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtReportFooter)
        Me.GroupBox2.Controls.Add(Me.txtReportHeader)
        Me.GroupBox2.Controls.Add(Me.lblReportFooter1)
        Me.GroupBox2.Controls.Add(Me.lblReportHeader1)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 174)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(390, 146)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'txtReportFooter
        '
        Me.txtReportFooter.Enabled = False
        Me.txtReportFooter.Location = New System.Drawing.Point(8, 88)
        Me.txtReportFooter.MaxLength = 45
        Me.txtReportFooter.Multiline = True
        Me.txtReportFooter.Name = "txtReportFooter"
        Me.txtReportFooter.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtReportFooter.Size = New System.Drawing.Size(374, 48)
        Me.txtReportFooter.TabIndex = 9
        Me.txtReportFooter.Text = ""
        '
        'txtReportHeader
        '
        Me.txtReportHeader.Enabled = False
        Me.txtReportHeader.Location = New System.Drawing.Point(8, 25)
        Me.txtReportHeader.MaxLength = 40
        Me.txtReportHeader.Multiline = True
        Me.txtReportHeader.Name = "txtReportHeader"
        Me.txtReportHeader.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtReportHeader.Size = New System.Drawing.Size(374, 43)
        Me.txtReportHeader.TabIndex = 8
        Me.txtReportHeader.Text = ""
        '
        'lblReportFooter1
        '
        Me.lblReportFooter1.Location = New System.Drawing.Point(8, 74)
        Me.lblReportFooter1.Name = "lblReportFooter1"
        Me.lblReportFooter1.Size = New System.Drawing.Size(100, 16)
        Me.lblReportFooter1.TabIndex = 1
        Me.lblReportFooter1.Text = "Report Footer"
        '
        'lblReportHeader1
        '
        Me.lblReportHeader1.Location = New System.Drawing.Point(8, 10)
        Me.lblReportHeader1.Name = "lblReportHeader1"
        Me.lblReportHeader1.Size = New System.Drawing.Size(100, 14)
        Me.lblReportHeader1.TabIndex = 0
        Me.lblReportHeader1.Text = "Report Header"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.cbReportHeader)
        Me.GroupBox1.Controls.Add(Me.cbInstrumentCondition)
        Me.GroupBox1.Controls.Add(Me.cbAnalysisParameters)
        Me.GroupBox1.Controls.Add(Me.cbMethodInfo)
        Me.GroupBox1.Controls.Add(Me.cbStandards)
        Me.GroupBox1.Controls.Add(Me.cbAbsorbance)
        Me.GroupBox1.Controls.Add(Me.cbWeightVolumeDilution)
        Me.GroupBox1.Controls.Add(Me.lblHeading)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(390, 164)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'cbReportHeader
        '
        Me.cbReportHeader.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbReportHeader.Location = New System.Drawing.Point(200, 70)
        Me.cbReportHeader.Name = "cbReportHeader"
        Me.cbReportHeader.Size = New System.Drawing.Size(176, 20)
        Me.cbReportHeader.TabIndex = 6
        Me.cbReportHeader.Text = "&Report Header and Footer"
        '
        'cbInstrumentCondition
        '
        Me.cbInstrumentCondition.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbInstrumentCondition.Location = New System.Drawing.Point(200, 39)
        Me.cbInstrumentCondition.Name = "cbInstrumentCondition"
        Me.cbInstrumentCondition.Size = New System.Drawing.Size(176, 20)
        Me.cbInstrumentCondition.TabIndex = 5
        Me.cbInstrumentCondition.Text = "&Instrument Condition"
        '
        'cbAnalysisParameters
        '
        Me.cbAnalysisParameters.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbAnalysisParameters.Location = New System.Drawing.Point(200, 100)
        Me.cbAnalysisParameters.Name = "cbAnalysisParameters"
        Me.cbAnalysisParameters.Size = New System.Drawing.Size(176, 20)
        Me.cbAnalysisParameters.TabIndex = 7
        Me.cbAnalysisParameters.Text = "Analysis &Parameters"
        '
        'cbMethodInfo
        '
        Me.cbMethodInfo.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbMethodInfo.Location = New System.Drawing.Point(18, 132)
        Me.cbMethodInfo.Name = "cbMethodInfo"
        Me.cbMethodInfo.Size = New System.Drawing.Size(160, 20)
        Me.cbMethodInfo.TabIndex = 4
        Me.cbMethodInfo.Text = "&Method Info"
        '
        'cbStandards
        '
        Me.cbStandards.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbStandards.Location = New System.Drawing.Point(18, 101)
        Me.cbStandards.Name = "cbStandards"
        Me.cbStandards.Size = New System.Drawing.Size(160, 20)
        Me.cbStandards.TabIndex = 3
        Me.cbStandards.Text = "&Standards"
        '
        'cbAbsorbance
        '
        Me.cbAbsorbance.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbAbsorbance.Location = New System.Drawing.Point(18, 70)
        Me.cbAbsorbance.Name = "cbAbsorbance"
        Me.cbAbsorbance.Size = New System.Drawing.Size(160, 20)
        Me.cbAbsorbance.TabIndex = 2
        Me.cbAbsorbance.Text = "&Absorbance"
        '
        'cbWeightVolumeDilution
        '
        Me.cbWeightVolumeDilution.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbWeightVolumeDilution.Location = New System.Drawing.Point(18, 39)
        Me.cbWeightVolumeDilution.Name = "cbWeightVolumeDilution"
        Me.cbWeightVolumeDilution.Size = New System.Drawing.Size(160, 20)
        Me.cbWeightVolumeDilution.TabIndex = 1
        Me.cbWeightVolumeDilution.Text = "&Weight-Volume Dilution"
        '
        'lblHeading
        '
        Me.lblHeading.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeading.Location = New System.Drawing.Point(8, 10)
        Me.lblHeading.Name = "lblHeading"
        Me.lblHeading.Size = New System.Drawing.Size(424, 14)
        Me.lblHeading.TabIndex = 0
        Me.lblHeading.Text = "Please check the column names which are to be included on the report."
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Image = CType(resources.GetObject("btnCancel.Image"), System.Drawing.Image)
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancel.Location = New System.Drawing.Point(216, 328)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(86, 34)
        Me.btnCancel.TabIndex = 17
        Me.btnCancel.Text = "&Cancel"
        '
        'btnOk
        '
        Me.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOk.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOk.Image = CType(resources.GetObject("btnOk.Image"), System.Drawing.Image)
        Me.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnOk.Location = New System.Drawing.Point(96, 328)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(86, 34)
        Me.btnOk.TabIndex = 16
        Me.btnOk.Text = "&OK"
        '
        'btnHelp
        '
        Me.btnHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnHelp.Image = CType(resources.GetObject("btnHelp.Image"), System.Drawing.Image)
        Me.btnHelp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnHelp.Location = New System.Drawing.Point(6, 330)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(86, 34)
        Me.btnHelp.TabIndex = 18
        Me.btnHelp.Text = "&Help"
        Me.btnHelp.Visible = False
        '
        'frmReportOptions
        '
        Me.AcceptButton = Me.btnOk
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(404, 397)
        Me.ControlBox = False
        Me.Controls.Add(Me.CustomPanel1)
        Me.Controls.Add(Me.Office2003Header1)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmReportOptions"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Method"
        Me.CustomPanel1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Class Member Variables "

    Private mintOpenMethodMode As EnumMethodMode
    Private mintRunNumberIndex As Integer
    Private mblnIsDataFilesMode As Boolean = False
    Private mintSelectedMethodID As Integer
    Private mintSelectedRunNumber As Integer
    Private mobjClsMethod As clsMethod
    Public Event ReportOptionsChanged(ByVal rpt As AAS203Library.Method.clsReportParameters)

#End Region

#Region " Private Constants"
    Private Const ConstDefaultFooter = "Note: All Standard Concentrations are in ppm"
    Private Const ConstParentFormMethod = "-Method"
    Private Const ConstParentFormDataFiles = "-DataFiles"
    Private Const ConstFormLoadMethod = "-Method-Report Options"
    Private Const ConstFormLoadDataFiles = "-DataFiles-Report Options"

#End Region

#Region " Private Properties "

    Private Property OpenMethodMode() As EnumMethodMode
        Get
            Return mintOpenMethodMode
        End Get
        Set(ByVal Value As EnumMethodMode)
            mintOpenMethodMode = Value
        End Set
    End Property

#End Region

#Region " Form Events "

    Private Sub frmReportOptions_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '=====================================================================
        ' Procedure Name        : frmReportOptions_Load
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To initialize and load the form
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 05.10.06
        ' Revisions             : 2
        ' Revision By           : Mangesh S. on 28-Jan-2007
        ' Revision for          : Changes in AAS203Library
        '=====================================================================
        Dim objWait As New CWaitCursor
        Dim intCounter As Integer

        Try
            If mblnIsDataFilesMode = False Then
                gobjMain.ShowProgressBar(gstrTitleInstrumentType & ConstFormLoadMethod)
            Else
                gobjMain.ShowProgressBar(gstrTitleInstrumentType & ConstFormLoadDataFiles)
            End If

            Call SubAddHandlers()
            ''for adding a event to a control.


            If mblnIsDataFilesMode = False Then
                ''get a method mode.
                If Not gobjNewMethod.ReportParameters Is Nothing Then
                    OpenMethodMode = modGlobalConstants.EnumMethodMode.EditMode
                Else
                    OpenMethodMode = modGlobalConstants.EnumMethodMode.NewMode
                    gobjNewMethod.ReportParameters = New clsReportParameters
                End If
            End If

            '---to display initial report options on loading
            Call funcShowReportOptions()
            'Saurabh 10.07.07 To bring status form in front
            If Not IsInIQOQPQ Then
                gobjfrmStatus.Show()
            End If
            'Saurabh


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
            gobjMain.HideProgressBar()
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub frmReportOptions_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        '=====================================================================
        ' Procedure Name        : frmReportOptions_Closing
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : this will handle a closing event of form.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 05.10.06
        ' Revisions             : 2
        ' Revision By           : Mangesh S. on 28-Jan-2007
        ' Revision for          : Changes in AAS203Library
        '=====================================================================
        Try
            If mblnIsDataFilesMode = False Then
                'show status bar message
                gobjMain.ShowRunTimeInfo(gstrTitleInstrumentType & ConstParentFormMethod)
            Else
                gobjMain.ShowRunTimeInfo(gstrTitleInstrumentType & ConstParentFormDataFiles)
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

#Region " Private Functions "

    Private Sub SubAddHandlers()
        '=====================================================================
        ' Procedure Name        : SubAddHandlers
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : To add handlers
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 05.10.06
        ' Revisions             : 
        '=====================================================================
        Try
            'add event handler to buttons
            AddHandler btnCancel.Click, AddressOf btnCancel_Click
            AddHandler btnOk.Click, AddressOf btnOk_Click
            AddHandler cbReportHeader.CheckedChanged, AddressOf cbReportHeader_CheckedChanged
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

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : btnCancel_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To close the form
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 05.10.06
        ' Revisions             : 
        '=====================================================================
        Try
            If OpenMethodMode = modGlobalConstants.EnumMethodMode.NewMode Then
                gobjNewMethod.ReportParameters = Nothing
            End If
            'Me.Close()
            Me.DialogResult = DialogResult.Cancel
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

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : btnOk_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To send dialog result as ok
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak, Saurabh
        ' Created               : 05.10.06
        ' Revisions             : 
        '=====================================================================
        ''note:
        ''this is called when user click on OK button
        ''this first get all the current status from screen
        ''selected by user
        ''then store it in a method collection. 
        Dim objWait As New CWaitCursor
        Dim blnWeightVolumeDilution As Boolean
        Dim blnAbsorbance As Boolean
        Dim blnStandards As Boolean
        Dim blnMethodInfo As Boolean
        Dim blnAnalysisParameters As Boolean
        Dim blnInstrumentCondition As Boolean
        Dim blnReportHeader As Boolean
        Dim blnReportFooter As Boolean
        Dim blnDisplayReportDate As Boolean
        Dim blnDisplayCompanyLogo As Boolean
        Dim dblLeftMargin As Double
        Dim dblTopMargin As Double
        Dim dblBottomMargin As Double
        Dim strReportHeader As String
        Dim strReportFooter As String
        Dim intCount As Integer
        Dim intRunNumberIndex As Integer
        Try
            'update temporary data structure
            If cbWeightVolumeDilution.Checked = True Then
                blnWeightVolumeDilution = True
                ''check for dilution
            Else
                blnWeightVolumeDilution = False
            End If

            If cbAbsorbance.Checked = True Then
                blnAbsorbance = True
                ''check for abs
            Else
                blnAbsorbance = False
            End If

            If cbStandards.Checked = True Then
                blnStandards = True
            Else
                blnStandards = False
            End If

            If cbMethodInfo.Checked = True Then
                blnMethodInfo = True
            Else
                blnMethodInfo = False
            End If

            If cbAnalysisParameters.Checked = True Then
                blnAnalysisParameters = True
            Else
                blnAnalysisParameters = False
            End If

            If cbInstrumentCondition.Checked = True Then
                blnInstrumentCondition = True
            Else
                blnInstrumentCondition = False
            End If

            If cbReportHeader.Checked = True Then
                blnReportHeader = True
                blnReportFooter = True
            Else
                blnReportHeader = False
                blnReportFooter = False
            End If
            strReportHeader = Trim(txtReportHeader.Text)
            strReportFooter = Trim(txtReportFooter.Text)

            If mblnIsDataFilesMode = False Then
                '---to save report options to object variables
                If Not gobjNewMethod.ReportParameters Is Nothing Then
                    gobjNewMethod.ReportParameters.IsAbsorbance = blnAbsorbance
                    gobjNewMethod.ReportParameters.IsAnalysisParameters = blnAnalysisParameters
                    gobjNewMethod.ReportParameters.IsInstrumentCondition = blnInstrumentCondition
                    gobjNewMethod.ReportParameters.IsMethodInfo = blnMethodInfo
                    gobjNewMethod.ReportParameters.IsReportHeaderAndFooter = blnReportHeader
                    gobjNewMethod.ReportParameters.IsStandards = blnStandards
                    gobjNewMethod.ReportParameters.IsWeightVolumeDilution = blnWeightVolumeDilution
                    gobjNewMethod.ReportParameters.ReportFooter = strReportFooter
                    gobjNewMethod.ReportParameters.ReportHeader = strReportHeader
                End If

                '---update current method to method collection and save all methods
                For intCount = gobjMethodCollection.Count - 1 To 0 Step -1
                    If gobjMethodCollection.item(intCount).MethodID = gobjNewMethod.MethodID Then
                        gobjMethodCollection.item(intCount).ReportParameters = gobjNewMethod.ReportParameters.Clone
                        gobjMethodCollection.item(intCount).DateOfModification = DateTime.Now
                        Call funcSaveAllMethods(gobjMethodCollection)
                        ''for saving a method collection.
                        Exit For
                    End If
                Next

            Else
                '---Update Current Method in Method Collection
                For intCount = 0 To gobjMethodCollection.Count - 1
                    If gobjMethodCollection.item(intCount).MethodID = mintSelectedMethodID Then

                        '--------12.04.09   4.85
                        ''gobjMethodCollection.item(intCount).ReportParameters.IsAbsorbance = blnAbsorbance
                        ''gobjMethodCollection.item(intCount).ReportParameters.IsAnalysisParameters = blnAnalysisParameters
                        ''gobjMethodCollection.item(intCount).ReportParameters.IsInstrumentCondition = blnInstrumentCondition
                        ''gobjMethodCollection.item(intCount).ReportParameters.IsMethodInfo = blnMethodInfo
                        ''gobjMethodCollection.item(intCount).ReportParameters.IsReportHeaderAndFooter = blnReportHeader
                        ''gobjMethodCollection.item(intCount).ReportParameters.IsStandards = blnStandards
                        ''gobjMethodCollection.item(intCount).ReportParameters.IsWeightVolumeDilution = blnWeightVolumeDilution
                        ''gobjMethodCollection.item(intCount).ReportParameters.ReportFooter = strReportFooter
                        ''gobjMethodCollection.item(intCount).ReportParameters.ReportHeader = strReportHeader

                        ''mobjClsMethod = gobjMethodCollection.item(intCount).Clone() 'Added By Pankaj  on 31 May 07
                        '--------12.04.09   4.85


                        '--------12.04.09   4.85
                        Dim intSelectedRunNumberIndex As Integer
                        intSelectedRunNumberIndex = gfuncGetSelectedMethodRunNumberIndex(mintSelectedMethodID, mintSelectedRunNumber)

                        gobjMethodCollection.item(intCount).QuantitativeDataCollection.Item(intSelectedRunNumberIndex).ReportParameters.IsAbsorbance = blnAbsorbance
                        gobjMethodCollection.item(intCount).QuantitativeDataCollection.Item(intSelectedRunNumberIndex).ReportParameters.IsAnalysisParameters = blnAnalysisParameters
                        gobjMethodCollection.item(intCount).QuantitativeDataCollection.Item(intSelectedRunNumberIndex).ReportParameters.IsInstrumentCondition = blnInstrumentCondition
                        gobjMethodCollection.item(intCount).QuantitativeDataCollection.Item(intSelectedRunNumberIndex).ReportParameters.IsMethodInfo = blnMethodInfo
                        gobjMethodCollection.item(intCount).QuantitativeDataCollection.Item(intSelectedRunNumberIndex).ReportParameters.IsReportHeaderAndFooter = blnReportHeader
                        gobjMethodCollection.item(intCount).QuantitativeDataCollection.Item(intSelectedRunNumberIndex).ReportParameters.IsStandards = blnStandards
                        gobjMethodCollection.item(intCount).QuantitativeDataCollection.Item(intSelectedRunNumberIndex).ReportParameters.IsWeightVolumeDilution = blnWeightVolumeDilution
                        gobjMethodCollection.item(intCount).QuantitativeDataCollection.Item(intSelectedRunNumberIndex).ReportParameters.ReportFooter = strReportFooter
                        gobjMethodCollection.item(intCount).QuantitativeDataCollection.Item(intSelectedRunNumberIndex).ReportParameters.ReportHeader = strReportHeader

                        'mobjClsMethod = gobjMethodCollection.item(intCount).Clone() 'Added By Pankaj  on 31 May 07
                        '--------12.04.09   4.85

                        '--------12.04.09   4.85
                        RaiseEvent ReportOptionsChanged(gobjMethodCollection.item(intCount).QuantitativeDataCollection.Item(intSelectedRunNumberIndex).ReportParameters)
                        '----
                    End If
                Next

                '---save all methods
                Call funcSaveAllMethods(gobjMethodCollection)
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
            objWait.Dispose()
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub cbReportHeader_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : cbReportHeader_CheckedChanged
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To enable or disable Report Header
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 05.10.06
        ' Revisions             :  
        '=====================================================================
        Try
            If cbReportHeader.Checked = True Then
                txtReportHeader.Enabled = True
                txtReportFooter.Enabled = True
            Else
                txtReportHeader.Enabled = False
                txtReportFooter.Enabled = False
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

    Private Function funcShowReportOptions() As Boolean
        '=====================================================================
        ' Procedure Name        : funcShowReportOptions
        ' Parameters Passed     : None
        ' Returns               : True or False
        ' Purpose               : To display report options
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak B.
        ' Created               : 09.10.06
        ' Revisions             : 2
        ' Revision By           : Mangesh S. on 28-Jan-2007
        ' Revision for          : Changes in AAS203Library
        '=====================================================================
        Try
            '---display selected method report options on form
            If mblnIsDataFilesMode = False Then
                If OpenMethodMode = modGlobalConstants.EnumMethodMode.EditMode Then
                    cbWeightVolumeDilution.Checked = gobjNewMethod.ReportParameters.IsWeightVolumeDilution
                    cbAnalysisParameters.Checked = gobjNewMethod.ReportParameters.IsAnalysisParameters
                    cbAbsorbance.Checked = gobjNewMethod.ReportParameters.IsAbsorbance
                    cbStandards.Checked = gobjNewMethod.ReportParameters.IsStandards
                    cbMethodInfo.Checked = gobjNewMethod.ReportParameters.IsMethodInfo
                    cbInstrumentCondition.Checked = gobjNewMethod.ReportParameters.IsInstrumentCondition
                    cbReportHeader.Checked = gobjNewMethod.ReportParameters.IsReportHeaderAndFooter
                    txtReportHeader.Text = gobjNewMethod.ReportParameters.ReportHeader
                    txtReportFooter.Text = gobjNewMethod.ReportParameters.ReportFooter
                Else
                    '---display default report options
                    cbWeightVolumeDilution.Checked = True
                    cbAnalysisParameters.Checked = True
                    cbAbsorbance.Checked = True
                    cbStandards.Checked = True
                    cbMethodInfo.Checked = False
                    cbInstrumentCondition.Checked = True
                    cbReportHeader.Checked = False
                    txtReportFooter.Text = ConstDefaultFooter
                End If
            Else
                '---display report options selected method in datafile
                '-----4.85  12.04.09
                ''cbWeightVolumeDilution.Checked = mobjClsMethod.ReportParameters.IsWeightVolumeDilution
                ''cbAnalysisParameters.Checked = mobjClsMethod.ReportParameters.IsAnalysisParameters
                ''cbAbsorbance.Checked = mobjClsMethod.ReportParameters.IsAbsorbance
                ''cbStandards.Checked = mobjClsMethod.ReportParameters.IsStandards
                ''cbMethodInfo.Checked = mobjClsMethod.ReportParameters.IsMethodInfo
                ''cbInstrumentCondition.Checked = mobjClsMethod.ReportParameters.IsInstrumentCondition
                ''cbReportHeader.Checked = mobjClsMethod.ReportParameters.IsReportHeaderAndFooter
                ''txtReportHeader.Text = mobjClsMethod.ReportParameters.ReportHeader
                ''txtReportFooter.Text = mobjClsMethod.ReportParameters.ReportFooter
                '-----4.85  12.04.09

                '-----4.85  12.04.09
                Dim intSelectedRunNumberIndex As Integer
                intSelectedRunNumberIndex = gfuncGetSelectedMethodRunNumberIndex(mintSelectedMethodID, mintSelectedRunNumber)

                cbWeightVolumeDilution.Checked = mobjClsMethod.QuantitativeDataCollection.Item(intSelectedRunNumberIndex).ReportParameters.IsWeightVolumeDilution
                cbAnalysisParameters.Checked = mobjClsMethod.QuantitativeDataCollection.Item(intSelectedRunNumberIndex).ReportParameters.IsAnalysisParameters
                cbAbsorbance.Checked = mobjClsMethod.QuantitativeDataCollection.Item(intSelectedRunNumberIndex).ReportParameters.IsAbsorbance
                cbStandards.Checked = mobjClsMethod.QuantitativeDataCollection.Item(intSelectedRunNumberIndex).ReportParameters.IsStandards
                cbMethodInfo.Checked = mobjClsMethod.QuantitativeDataCollection.Item(intSelectedRunNumberIndex).ReportParameters.IsMethodInfo
                cbInstrumentCondition.Checked = mobjClsMethod.QuantitativeDataCollection.Item(intSelectedRunNumberIndex).ReportParameters.IsInstrumentCondition
                cbReportHeader.Checked = mobjClsMethod.QuantitativeDataCollection.Item(intSelectedRunNumberIndex).ReportParameters.IsReportHeaderAndFooter
                txtReportHeader.Text = mobjClsMethod.QuantitativeDataCollection.Item(intSelectedRunNumberIndex).ReportParameters.ReportHeader
                txtReportFooter.Text = mobjClsMethod.QuantitativeDataCollection.Item(intSelectedRunNumberIndex).ReportParameters.ReportFooter
                '-----4.85  12.04.09

            End If
            If Not gobjNewMethod Is Nothing Then
                If gobjNewMethod.OperationMode = EnumOperationMode.MODE_EMMISSION Then
                    cbAbsorbance.Text = "Emission"
                End If
            End If

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

#End Region

End Class

