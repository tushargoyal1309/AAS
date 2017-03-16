Imports AAS203.Common
Imports AAS203Library.Method
''this is like headers file
Public Class frmSampleParameters ''class behind the form
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    Public Sub New(ByVal intMethodMode As Integer, Optional ByVal objPreviousSampParametersIn As clsAnalysisSampleParametersCollection = Nothing)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        OpenMethodMode = intMethodMode
        objPreviousSampParameters = objPreviousSampParametersIn
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
    Friend WithEvents dgSampleParameters As System.Windows.Forms.DataGrid
    Friend WithEvents CustomPanelBottom As GradientPanel.CustomPanel
    Friend WithEvents CustomPanelBottomTop As GradientPanel.CustomPanel
    Friend WithEvents lblNote3 As System.Windows.Forms.Label
    Friend WithEvents lblImpNotes As System.Windows.Forms.Label
    Friend WithEvents btnHelp As NETXP.Controls.XPButton
    Friend WithEvents btnOk As NETXP.Controls.XPButton
    Friend WithEvents btnCancel As NETXP.Controls.XPButton
    Friend WithEvents Office2003Header1 As CodeIntellects.Office2003Controls.Office2003Header
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnChangeTiming As NETXP.Controls.XPButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmSampleParameters))
        Me.CustomPanelMain = New GradientPanel.CustomPanel
        Me.CustomPanelTop = New GradientPanel.CustomPanel
        Me.dgSampleParameters = New System.Windows.Forms.DataGrid
        Me.CustomPanelBottom = New GradientPanel.CustomPanel
        Me.btnChangeTiming = New NETXP.Controls.XPButton
        Me.btnOk = New NETXP.Controls.XPButton
        Me.btnCancel = New NETXP.Controls.XPButton
        Me.CustomPanelBottomTop = New GradientPanel.CustomPanel
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblNote3 = New System.Windows.Forms.Label
        Me.lblImpNotes = New System.Windows.Forms.Label
        Me.btnHelp = New NETXP.Controls.XPButton
        Me.Office2003Header1 = New CodeIntellects.Office2003Controls.Office2003Header
        Me.CustomPanelMain.SuspendLayout()
        Me.CustomPanelTop.SuspendLayout()
        CType(Me.dgSampleParameters, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CustomPanelBottom.SuspendLayout()
        Me.CustomPanelBottomTop.SuspendLayout()
        Me.SuspendLayout()
        '
        'CustomPanelMain
        '
        Me.CustomPanelMain.BackColor = System.Drawing.Color.AliceBlue
        Me.CustomPanelMain.BackColor2 = System.Drawing.Color.AliceBlue
        Me.CustomPanelMain.Controls.Add(Me.CustomPanelTop)
        Me.CustomPanelMain.Controls.Add(Me.CustomPanelBottom)
        Me.CustomPanelMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CustomPanelMain.Location = New System.Drawing.Point(0, 22)
        Me.CustomPanelMain.Name = "CustomPanelMain"
        Me.CustomPanelMain.Size = New System.Drawing.Size(506, 401)
        Me.CustomPanelMain.TabIndex = 14
        '
        'CustomPanelTop
        '
        Me.CustomPanelTop.BackColor = System.Drawing.Color.Transparent
        Me.CustomPanelTop.BackColor2 = System.Drawing.Color.Transparent
        Me.CustomPanelTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CustomPanelTop.Controls.Add(Me.dgSampleParameters)
        Me.CustomPanelTop.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CustomPanelTop.Location = New System.Drawing.Point(0, 0)
        Me.CustomPanelTop.Name = "CustomPanelTop"
        Me.CustomPanelTop.Size = New System.Drawing.Size(506, 257)
        Me.CustomPanelTop.TabIndex = 10
        '
        'dgSampleParameters
        '
        Me.dgSampleParameters.CaptionVisible = False
        Me.dgSampleParameters.DataMember = ""
        Me.dgSampleParameters.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgSampleParameters.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgSampleParameters.Location = New System.Drawing.Point(9, 21)
        Me.dgSampleParameters.Name = "dgSampleParameters"
        Me.dgSampleParameters.PreferredColumnWidth = 100
        Me.dgSampleParameters.Size = New System.Drawing.Size(487, 202)
        Me.dgSampleParameters.TabIndex = 0
        '
        'CustomPanelBottom
        '
        Me.CustomPanelBottom.BackColor = System.Drawing.Color.Transparent
        Me.CustomPanelBottom.BackColor2 = System.Drawing.Color.Transparent
        Me.CustomPanelBottom.Controls.Add(Me.btnChangeTiming)
        Me.CustomPanelBottom.Controls.Add(Me.btnOk)
        Me.CustomPanelBottom.Controls.Add(Me.btnCancel)
        Me.CustomPanelBottom.Controls.Add(Me.CustomPanelBottomTop)
        Me.CustomPanelBottom.Controls.Add(Me.btnHelp)
        Me.CustomPanelBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.CustomPanelBottom.Location = New System.Drawing.Point(0, 257)
        Me.CustomPanelBottom.Name = "CustomPanelBottom"
        Me.CustomPanelBottom.Size = New System.Drawing.Size(506, 144)
        Me.CustomPanelBottom.TabIndex = 8
        '
        'btnChangeTiming
        '
        Me.btnChangeTiming.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnChangeTiming.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnChangeTiming.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnChangeTiming.Location = New System.Drawing.Point(16, 104)
        Me.btnChangeTiming.Name = "btnChangeTiming"
        Me.btnChangeTiming.Size = New System.Drawing.Size(96, 32)
        Me.btnChangeTiming.TabIndex = 12
        Me.btnChangeTiming.Text = "&Change Timing"
        '
        'btnOk
        '
        Me.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOk.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOk.Image = CType(resources.GetObject("btnOk.Image"), System.Drawing.Image)
        Me.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnOk.Location = New System.Drawing.Point(126, 102)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(86, 34)
        Me.btnOk.TabIndex = 1
        Me.btnOk.Text = "&OK"
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Image = CType(resources.GetObject("btnCancel.Image"), System.Drawing.Image)
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancel.Location = New System.Drawing.Point(230, 102)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(86, 34)
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Text = "&Cancel"
        '
        'CustomPanelBottomTop
        '
        Me.CustomPanelBottomTop.BackColor = System.Drawing.Color.Transparent
        Me.CustomPanelBottomTop.BackColor2 = System.Drawing.Color.Transparent
        Me.CustomPanelBottomTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CustomPanelBottomTop.Controls.Add(Me.Label1)
        Me.CustomPanelBottomTop.Controls.Add(Me.lblNote3)
        Me.CustomPanelBottomTop.Controls.Add(Me.lblImpNotes)
        Me.CustomPanelBottomTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.CustomPanelBottomTop.Location = New System.Drawing.Point(0, 0)
        Me.CustomPanelBottomTop.Name = "CustomPanelBottomTop"
        Me.CustomPanelBottomTop.Size = New System.Drawing.Size(506, 88)
        Me.CustomPanelBottomTop.TabIndex = 9
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 61)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(344, 16)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "2. Name of the sample should be less than 10 characters."
        '
        'lblNote3
        '
        Me.lblNote3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNote3.Location = New System.Drawing.Point(8, 33)
        Me.lblNote3.Name = "lblNote3"
        Me.lblNote3.Size = New System.Drawing.Size(344, 16)
        Me.lblNote3.TabIndex = 3
        Me.lblNote3.Text = "1. Please enter different sample names"
        '
        'lblImpNotes
        '
        Me.lblImpNotes.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImpNotes.Location = New System.Drawing.Point(8, 8)
        Me.lblImpNotes.Name = "lblImpNotes"
        Me.lblImpNotes.Size = New System.Drawing.Size(344, 16)
        Me.lblImpNotes.TabIndex = 0
        Me.lblImpNotes.Text = "Important Notes :"
        '
        'btnHelp
        '
        Me.btnHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnHelp.Image = CType(resources.GetObject("btnHelp.Image"), System.Drawing.Image)
        Me.btnHelp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnHelp.Location = New System.Drawing.Point(264, 120)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(86, 34)
        Me.btnHelp.TabIndex = 3
        Me.btnHelp.Text = "Help"
        Me.btnHelp.Visible = False
        '
        'Office2003Header1
        '
        Me.Office2003Header1.BackColor = System.Drawing.SystemColors.Control
        Me.Office2003Header1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Office2003Header1.Location = New System.Drawing.Point(0, 0)
        Me.Office2003Header1.Name = "Office2003Header1"
        Me.Office2003Header1.Size = New System.Drawing.Size(506, 22)
        Me.Office2003Header1.TabIndex = 15
        Me.Office2003Header1.TitleFont = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Office2003Header1.TitleText = " Sample Parameters"
        '
        'frmSampleParameters
        '
        Me.AcceptButton = Me.btnOk
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(506, 423)
        Me.ControlBox = False
        Me.Controls.Add(Me.CustomPanelMain)
        Me.Controls.Add(Me.Office2003Header1)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSampleParameters"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Method"
        Me.TopMost = True
        Me.CustomPanelMain.ResumeLayout(False)
        Me.CustomPanelTop.ResumeLayout(False)
        CType(Me.dgSampleParameters, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CustomPanelBottom.ResumeLayout(False)
        Me.CustomPanelBottomTop.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Private Member Variables "

    Private mobjDtSample As DataTable
    Private mintMethodMode As Integer
    Private mintRunNumberIndex As Integer
    'Private mobjDataGridClass As DataGridClass
    Private mblEnableCancel As Boolean = True
    Private mobjDtSamplesDataGrid As New DataGridClass(ConstDataGridPropertiesFileName)
    Private objPreviousSampParameters As clsAnalysisSampleParametersCollection
    Private mblnIsCancel As Boolean = False
#End Region

#Region " Private Constants "
    Private Const ConstNumberOfCharactersInWVDColumn = 11
    Private Const ConstNumberOfCharactersInSampleNameColumn = 10
    Private Const ConstColumnSrNo = "SrNo"
    Private Const ConstColumnSampleName = "SampleName"
    Private Const ConstColumnSamplerPos = "SamplerPos"
    Private Const ConstColumnWeight = "Weight"
    Private Const ConstColumnVolume = "Volume"
    Private Const ConstColumnDilutionFactor = "DilutionFactor"
    Private Const ConstTitleSrNo = "Sr.No."
    Private Const ConstTitleSampleName = "Sample Name "
    Private Const ConstTitleWeight = "Weight (gms)"
    Private Const ConstTitleVolume = "Volume (ml)"
    Private Const ConstTitleDilutionFactor = "Dilution Factor"
    Private Const ConstDefaultValue As Double = 1.0
    Private Const ConstDefaultSampleName = "Sample "
    Private Const ConstWidthSrNo = 40
    Private Const ConstNumberOfDefaultSamples = 25
    Private Const ConstWidthSampleName = 93
    Private Const ConstWidthWeight = 81
    Private Const ConstWidthVolume = 80
    Private Const ConstWidthDilutionFactor = 98
    Private Const ConstParentFormLoad = "-Method"
    Private Const ConstFormLoad = "-Method-Sample Parameters"
    Private Enum EnumUnits
        Ppm = 1
        Percentage = 2
    End Enum
#End Region

#Region " Private Properties "

    Private Property OpenMethodMode() As EnumMethodMode
        Get
            Return mintMethodMode
        End Get
        Set(ByVal Value As EnumMethodMode)

            mintMethodMode = Value
        End Set
    End Property
    Public Property EnableBtnCancel() As Boolean
        Get

        End Get
        Set(ByVal Value As Boolean)
            mblEnableCancel = Value
            If (mblEnableCancel = False) Then
                btnCancel.Enabled = False
            End If


        End Set
    End Property

#End Region

#Region " Form Events "

    Private Sub frmSampleParameters_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '=====================================================================
        ' Procedure Name        : frmSampleParameters_Load
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To initialize and load the form
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak
        ' Created               : 28.07.07
        ' Revisions             : 
        ' Revisions             : 0
        '=====================================================================
        ''note;
        ''this is called when sampler parameter form is loaded
        ''this is use to set some initialization over a form.
        Dim objWait As New CWaitCursor
        Dim intCounter As Integer
        Dim objRow As DataRow
        Dim intNoOfSamples As Integer
        Dim blnNewParameter As Boolean = True
        Try
            '1. if object is not initialized then load default condition
            '2. if object is initialized then load object data
            gobjMain.ShowProgressBar(gstrTitleInstrumentType & ConstFormLoad)
            SubAddHandlers()
            SubDataGridSettings()
            ''set the grid intial setting

            If Not gobjNewMethod.SampleDataCollection Is Nothing Then
                OpenMethodMode = modGlobalConstants.EnumMethodMode.EditMode
                ''open a method in a editable mode
            Else
                OpenMethodMode = modGlobalConstants.EnumMethodMode.NewMode
                ''open method in new creation mode
                gobjNewMethod.SampleDataCollection = New clsAnalysisSampleParametersCollection
            End If

            Select Case OpenMethodMode
                Case modGlobalConstants.EnumMethodMode.NewMode
                    'if first time this form is opened
                    'if unit is only changed in parameters 
                    For intCounter = 0 To ConstNumberOfDefaultSamples - 1
                        objRow = mobjDtSample.NewRow
                        objRow.Item(ConstColumnSrNo) = intCounter + 1
                        If gstructAutoSampler.blnAutoSamplerInitialised = True Then 'by Pankaj for autosampler on 10Sep 07
                            objRow.Item(ConstColumnSamplerPos) = intCounter + 1
                        End If
                        objRow.Item(ConstColumnSampleName) = ConstDefaultSampleName & intCounter + 1
                        objRow.Item(ConstColumnWeight) = ConstDefaultValue
                        If Not gobjNewMethod.AnalysisParameters Is Nothing Then
                            If gobjNewMethod.AnalysisParameters.Unit = EnumUnits.Percentage Then
                                'objRow.Item(ConstColumnVolume) = 100
                                '---changed by Deepak on 30.01.09 as per report from App. Lab
                                objRow.Item(ConstColumnVolume) = 1
                            Else
                                objRow.Item(ConstColumnVolume) = ConstDefaultValue
                            End If
                        Else
                            objRow.Item(ConstColumnVolume) = ConstDefaultValue
                        End If
                        objRow.Item(ConstColumnDilutionFactor) = ConstDefaultValue
                        If Not mobjDtSample Is Nothing Then
                            mobjDtSample.Rows.Add(objRow)
                        End If
                    Next intCounter

                Case modGlobalConstants.EnumMethodMode.EditMode
                    If Not gobjNewMethod.AnalysisParameters Is Nothing Then
                        intNoOfSamples = gobjNewMethod.AnalysisParameters.NumOfSamples
                    End If
                    funcLoadInitialData(intNoOfSamples)
            End Select

            Call mobjDtSamplesDataGrid.SetDataGridProperties(dgSampleParameters, mobjDtSample)
            ''''this function will set the grid property 
            dgSampleParameters.Focus()
            mobjDtSamplesDataGrid.SetDataGridTableStyle.BeginEdit(dgSampleParameters.TableStyles.Item(0).GridColumnStyles(2), 0)
            ''setting grid
            If Not IsInIQOQPQ Then
                ''show the status form
                gobjfrmStatus.Show()
            End If
            btnChangeTiming.Visible = gstructAutoSampler.blnAutoSamplerInitialised 'Added by pankaj for autosampler
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

    Private Sub frmSampleParameters_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        '=====================================================================
        ' Procedure Name        : frmSampleParameters_Closing
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak
        ' Created               : 28.07.07
        ' Revisions             : 
        ' Revisions             : 0
        '=====================================================================
        ''note:
        ''this is called when user close the form

        If mblnIsCancel = True Then
            e.Cancel = mblnIsCancel
            mblnIsCancel = False
            Exit Sub
        End If
        gobjMain.ShowRunTimeInfo(gstrTitleInstrumentType & ConstParentFormLoad)
    End Sub

    Private Sub SubDataGridSettings()
        '=====================================================================
        ' Procedure Name        : SubDataGridSettings
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : for setting data grid.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak
        ' Created               : 28.07.07
        ' Revisions             : 
        ' Revisions             : 0
        '=====================================================================
        ''note:
        ''In this function set a grid for eg no of column , row
        ''name of column ,weight ,volume ect
        ''and validat this grid
        Try
            mobjDtSample = New DataTable

            mobjDtSample.Columns.Clear()

            mobjDtSample.Columns.Add(ConstColumnSrNo, GetType(Integer))
            mobjDtSample.Columns.Add(ConstColumnSampleName, GetType(String))
            mobjDtSample.Columns.Add(ConstColumnWeight, GetType(Double))
            mobjDtSample.Columns.Add(ConstColumnVolume, GetType(Double))
            mobjDtSample.Columns.Add(ConstColumnDilutionFactor, GetType(Double))

            mobjDtSample.Columns(ConstColumnWeight).DefaultValue = DBNull.Value
            mobjDtSample.Columns(ConstColumnVolume).DefaultValue = DBNull.Value
            mobjDtSample.Columns(ConstColumnDilutionFactor).DefaultValue = DBNull.Value

            mobjDtSamplesDataGrid.AllowNew = False
            mobjDtSamplesDataGrid.AdjustColumnWidthToGrid = False

            mobjDtSamplesDataGrid.AddDataGridColumnStyle(mobjDtSample.Columns(0).ColumnName, dgSampleParameters, mobjDtSample, DataGridClass.enumColumnType.TextBoxColumn, HorizontalAlignment.Center, ConstTitleSrNo, ConstWidthSrNo, True, DataGridClass.ColumnDataType.Text, HorizontalAlignment.Center)
            mobjDtSamplesDataGrid.AddDataGridColumnStyle(mobjDtSample.Columns(1).ColumnName, dgSampleParameters, mobjDtSample, DataGridClass.enumColumnType.TextBoxColumn, HorizontalAlignment.Center, ConstTitleSampleName, ConstWidthSampleName, False, DataGridClass.ColumnDataType.Text, HorizontalAlignment.Left, ConstNumberOfCharactersInSampleNameColumn, True, False)
            mobjDtSamplesDataGrid.AddDataGridColumnStyle(mobjDtSample.Columns(2).ColumnName, dgSampleParameters, mobjDtSample, DataGridClass.enumColumnType.TextBoxColumn, HorizontalAlignment.Center, ConstTitleWeight, ConstWidthWeight, False, DataGridClass.ColumnDataType.Text, HorizontalAlignment.Center, ConstNumberOfCharactersInWVDColumn, True, True)
            mobjDtSamplesDataGrid.AddDataGridColumnStyle(mobjDtSample.Columns(3).ColumnName, dgSampleParameters, mobjDtSample, DataGridClass.enumColumnType.TextBoxColumn, HorizontalAlignment.Center, ConstTitleVolume, ConstWidthVolume, False, DataGridClass.ColumnDataType.Text, HorizontalAlignment.Center, ConstNumberOfCharactersInWVDColumn, True, True)
            mobjDtSamplesDataGrid.AddDataGridColumnStyle(mobjDtSample.Columns(4).ColumnName, dgSampleParameters, mobjDtSample, DataGridClass.enumColumnType.TextBoxColumn, HorizontalAlignment.Center, ConstTitleDilutionFactor, ConstWidthDilutionFactor, False, DataGridClass.ColumnDataType.Text, HorizontalAlignment.Center, ConstNumberOfCharactersInWVDColumn, True, True)
            If gstructAutoSampler.blnAutoSamplerInitialised = True Then
                mobjDtSample.Columns.Add(ConstColumnSamplerPos, GetType(Integer))
                mobjDtSample.Columns(ConstColumnSamplerPos).DefaultValue = 0
                mobjDtSamplesDataGrid.AddDataGridColumnStyle(mobjDtSample.Columns(5).ColumnName, dgSampleParameters, mobjDtSample, DataGridClass.enumColumnType.TextBoxColumn, HorizontalAlignment.Center, ConstColumnSamplerPos, ConstWidthDilutionFactor - 20, False, DataGridClass.ColumnDataType.Text, HorizontalAlignment.Center, 2, True, True)
            Else
                Me.dgSampleParameters.Width = Me.dgSampleParameters.Width - 70
            End If
            mobjDtSamplesDataGrid.SetDataGridProperties(dgSampleParameters, mobjDtSample)
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
        ' Author                : Deepak
        ' Created               : 05.10.06
        ' Revisions             : 
        '=====================================================================
        Try
            ''this will add a event ot a control
            AddHandler btnCancel.Click, AddressOf btnCancel_Click
            ''for eg if user click on cancel button then btnCancel_Click will called
            AddHandler btnOk.Click, AddressOf btnOk_Click

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
        ' Author                : Deepak
        ' Created               : 05.10.06
        ' Revisions             : 
        '=====================================================================
        Try
            ''this is called when user click on cancel button
            If OpenMethodMode = modGlobalConstants.EnumMethodMode.NewMode Then
                gobjNewMethod.SampleDataCollection = Nothing
            End If

            'Me.Close()
            Me.DialogResult = DialogResult.Cancel
            mblnIsCancel = False
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
            mblnIsCancel = False
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
        ' Author                : Deepak
        ' Created               : 05.10.06
        ' Revisions             : 
        '=====================================================================

        ''note:
        ''this is called when user clicked on OK button
        ''step1: check a validation for input value
        ''for eg there should be unique data
        ''step2: store it in a temp variable
        ''step3:and then bound it proper data structure



        Dim objWait As New CWaitCursor
        Dim intCounter As Integer
        Dim objClsSampleParameters As clsAnalysisSampleParameters
        Dim objSamplesCollection As clsAnalysisSampleParametersCollection

        Try
            '---18.06.07
            objSamplesCollection = New clsAnalysisSampleParametersCollection
            Dim strSampleName As String
            Dim intCounter1 As Integer
            Dim blnDuplicateFound As Boolean

            '//-----  Added by Sachin Dokhale
            blnDuplicateFound = False
            For intCounter = 0 To mobjDtSample.Rows.Count - 1
                strSampleName = mobjDtSample.Rows(intCounter).Item(1)
                For intCounter1 = intCounter + 1 To mobjDtSample.Rows.Count - 1
                    If strSampleName = mobjDtSample.Rows(intCounter1).Item(1) Then
                        blnDuplicateFound = True
                        Exit For
                    End If
                Next

                If blnDuplicateFound = True Then
                    Exit For
                End If
            Next

            If blnDuplicateFound = True Then
                'gobjMessageAdapter.ShowMessage(constInputProperData)
                mblnIsCancel = True
                ''check for duplicate name
                gobjMessageAdapter.ShowMessage("Duplicate Sample name", "Sample name", MessageHandler.clsMessageHandler.enumMessageType.WarningMessage)
                Application.DoEvents()
                Exit Sub
            End If

            'For intCounter = 0 To mobjDtSample.Rows.Count - 1
            '    If IsNumeric(mobjDtSample.Rows(intCounter).Item(ConstColumnWeight)) And _
            '    IsNumeric(mobjDtSample.Rows(intCounter).Item(ConstColumnVolume)) And _
            '    IsNumeric(mobjDtSample.Rows(intCounter).Item(ConstColumnDilutionFactor)) Then
            '    Else
            '        gobjMessageAdapter.ShowMessage("Please enter proper data", "Numeric data required", MessageHandler.clsMessageHandler.enumMessageType.WarningMessage)
            '        Application.DoEvents()
            '        Exit Sub
            '    End If
            'Next

            '//-----
            For intCounter = 0 To mobjDtSample.Rows.Count - 1
                If Trim(mobjDtSample.Rows(intCounter).Item(ConstColumnSampleName)) <> "" And Not IsDBNull(mobjDtSample.Rows(intCounter).Item(ConstColumnWeight)) And Not IsDBNull(mobjDtSample.Rows(intCounter).Item(ConstColumnVolume)) And Not IsDBNull(mobjDtSample.Rows(intCounter).Item(ConstColumnDilutionFactor)) Then
                    If IsNumeric(Trim(mobjDtSample.Rows(intCounter).Item(ConstColumnWeight))) And IsNumeric(Trim(mobjDtSample.Rows(intCounter).Item(ConstColumnVolume))) And IsNumeric(Trim(mobjDtSample.Rows(intCounter).Item(ConstColumnDilutionFactor))) Then
                        objClsSampleParameters = New clsAnalysisSampleParameters
                        objClsSampleParameters.SampNumber = mobjDtSample.Rows(intCounter).Item(ConstColumnSrNo)
                        ''here storing a data in to a data structure object.
                        objClsSampleParameters.SampleName = mobjDtSample.Rows(intCounter).Item(ConstColumnSampleName)
                        objClsSampleParameters.Weight = mobjDtSample.Rows(intCounter).Item(ConstColumnWeight)
                        objClsSampleParameters.Volume = mobjDtSample.Rows(intCounter).Item(ConstColumnVolume)
                        objClsSampleParameters.DilutionFactor = mobjDtSample.Rows(intCounter).Item(ConstColumnDilutionFactor)
                        If (gstructAutoSampler.blnAutoSamplerInitialised = True) Then 'by Pankaj for autosampler on 10Sep 07
                            objClsSampleParameters.SampPosNumber = mobjDtSample.Rows(intCounter).Item(ConstColumnSamplerPos)
                        End If
                        objSamplesCollection.Add(objClsSampleParameters)
                    Else
                        mblnIsCancel = True
                        gobjMessageAdapter.ShowMessage(constInputProperData)
                        Application.DoEvents()
                        ''allow application to perfrom its panding work
                        Exit Sub
                    End If
                Else
                    mblnIsCancel = True
                    gobjMessageAdapter.ShowMessage(constInputProperData)
                    ''show inproper data messag
                    Application.DoEvents()
                    ''allow application to perfrom its panding work
                    Exit Sub
                End If
            Next
            'For intRunNo As Integer = 0 To gobjNewMethod.QuantitativeDataCollection.Count - 1
            For intCounter = 0 To gobjNewMethod.SampleDataCollection.Count - 1
                If gobjNewMethod.SampleDataCollection.Count > intCounter Then
                    If gobjNewMethod.SampleDataCollection.item(intCounter).Used = True Then
                        objSamplesCollection.item(intCounter).Used = True
                        'If gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCounter).Abs <> -1.0 Then
                        objSamplesCollection.item(intCounter).Abs = gobjNewMethod.SampleDataCollection.item(intCounter).Abs
                        'End If
                    End If
                End If
            Next
            'Next
            gobjNewMethod.SampleDataCollection.Clear()
            gobjNewMethod.SampleDataCollection = objSamplesCollection.Clone()

            '---Update Current Method in Method Collection
            For intCounter = gobjMethodCollection.Count - 1 To 0 Step -1
                If gobjMethodCollection.item(intCounter).MethodID = gobjNewMethod.MethodID Then
                    'If (gobjMethodCollection.item(intCounter).QuantitativeDataCollection.Count >= gobjNewMethod.QuantitativeDataCollection.Count) Then
                    gobjMethodCollection.item(intCounter).SampleDataCollection = gobjNewMethod.SampleDataCollection.Clone()
                    gobjMethodCollection.item(intCounter).DateOfModification = DateTime.Now
                    'Else
                    'gobjMethodCollection.item(intCounter).QuantitativeDataCollection.Add(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex))
                    'gobjMethodCollection.item(intCounter).DateOfModification = DateTime.Now
                    'End If
                    Call funcSaveAllMethods(gobjMethodCollection)
                    ''for saving a method with current data
                    ''this saved method is later be used in analysis.
                    Exit For
                End If
            Next

            '---serialize method collection 
            'Call funcSerialize(ConstMethodsFileName, gobjMethodCollection)


            Me.DialogResult = DialogResult.OK
            mblnIsCancel = False
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            mblnIsCancel = False
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

    Private Function funcLoadInitialData(ByVal intNoOfSamples As Integer) As Boolean
        '=====================================================================
        ' Procedure Name        : funcLoadInitialData
        ' Parameters Passed     : None
        ' Returns               : True or False
        ' Purpose               : To load initial data
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 28.07.07
        ' Revisions             : 0
        '=====================================================================
        Dim intCounter As Integer
        Dim objRow As DataRow
        Dim intInitialCount As Integer
        ''note:
        ''this function is used for intial setup of form
        ''in this we show a current info like sampler name etc
        ''into a grid


        Try

            If gobjNewMethod.SampleDataCollection.Count >= intNoOfSamples Then
                For intCounter = 0 To gobjNewMethod.SampleDataCollection.Count - 1
                    objRow = mobjDtSample.NewRow
                    objRow.Item(ConstColumnSrNo) = gobjNewMethod.SampleDataCollection.item(intCounter).SampNumber
                    objRow.Item(ConstColumnSampleName) = gobjNewMethod.SampleDataCollection.item(intCounter).SampleName
                    If gstructAutoSampler.blnAutoSamplerInitialised = True Then 'by Pankaj for autosampler on 10Sep 07
                        If (gobjNewMethod.SampleDataCollection.item(intCounter).SampPosNumber = -1) Then
                            objRow.Item(ConstColumnSamplerPos) = intCounter + 1
                        Else
                            objRow.Item(ConstColumnSamplerPos) = gobjNewMethod.SampleDataCollection.item(intCounter).SampPosNumber
                        End If
                    End If

                    If gobjNewMethod.SampleDataCollection.item(intCounter).Weight = 0.0 Then
                        objRow.Item(ConstColumnWeight) = DBNull.Value
                    Else
                        objRow.Item(ConstColumnWeight) = FormatNumber(gobjNewMethod.SampleDataCollection.item(intCounter).Weight, 6)
                    End If

                    If gobjNewMethod.SampleDataCollection.item(intCounter).Volume = 0.0 Then
                        objRow.Item(ConstColumnVolume) = DBNull.Value
                    Else
                        objRow.Item(ConstColumnVolume) = FormatNumber(gobjNewMethod.SampleDataCollection.item(intCounter).Volume, 6)
                    End If

                    If gobjNewMethod.SampleDataCollection.item(intCounter).DilutionFactor = 0.0 Then
                        objRow.Item(ConstColumnDilutionFactor) = DBNull.Value
                    Else
                        objRow.Item(ConstColumnDilutionFactor) = FormatNumber(gobjNewMethod.SampleDataCollection.item(intCounter).DilutionFactor, 6)
                    End If

                    mobjDtSample.Rows.Add(objRow)
                Next
                If intNoOfSamples > gobjNewMethod.SampleDataCollection.Count Then
                    For intCounter = gobjNewMethod.SampleDataCollection.Count To intNoOfSamples - 1
                        objRow = mobjDtSample.NewRow
                        objRow.Item(ConstColumnSrNo) = intCounter + 1
                        objRow.Item(ConstColumnSampleName) = ConstDefaultSampleName & intCounter + 1
                        If (gstructAutoSampler.blnAutoSamplerInitialised = True) Then 'by Pankaj for autosampler on 10Sep 07
                            objRow.Item(ConstColumnSamplerPos) = intCounter + 1
                        End If
                        objRow.Item(ConstColumnWeight) = ConstDefaultValue
                        objRow.Item(ConstColumnVolume) = ConstDefaultValue
                        objRow.Item(ConstColumnDilutionFactor) = ConstDefaultValue
                        mobjDtSample.Rows.Add(objRow)
                    Next
                End If
            Else
                If intNoOfSamples < gobjNewMethod.SampleDataCollection.Count Then
                    For intCounter = 0 To intNoOfSamples - 1
                        objRow = mobjDtSample.NewRow
                        objRow.Item(ConstColumnSrNo) = gobjNewMethod.SampleDataCollection.item(intCounter).SampNumber
                        objRow.Item(ConstColumnSampleName) = gobjNewMethod.SampleDataCollection.item(intCounter).SampleName
                        If (gstructAutoSampler.blnAutoSamplerInitialised = True) Then
                            objRow.Item(ConstColumnSamplerPos) = gobjNewMethod.SampleDataCollection.item(intCounter).SampPosNumber
                            If (gobjNewMethod.SampleDataCollection.item(intCounter).SampPosNumber = -1) Then
                                objRow.Item(ConstColumnSamplerPos) = intCounter + 1
                            End If
                        End If

                        If gobjNewMethod.SampleDataCollection.item(intCounter).Weight = 0.0 Then
                            objRow.Item(ConstColumnWeight) = DBNull.Value
                        Else
                            objRow.Item(ConstColumnWeight) = FormatNumber(gobjNewMethod.SampleDataCollection.item(intCounter).Weight, 6)
                        End If

                        If gobjNewMethod.SampleDataCollection.item(intCounter).Volume = 0.0 Then
                            objRow.Item(ConstColumnVolume) = DBNull.Value
                        Else
                            objRow.Item(ConstColumnVolume) = FormatNumber(gobjNewMethod.SampleDataCollection.item(intCounter).Volume, 6)
                        End If

                        If gobjNewMethod.SampleDataCollection.item(intCounter).DilutionFactor = 0.0 Then
                            objRow.Item(ConstColumnDilutionFactor) = DBNull.Value
                        Else
                            objRow.Item(ConstColumnDilutionFactor) = FormatNumber(gobjNewMethod.SampleDataCollection.item(intCounter).DilutionFactor, 6)
                        End If

                        mobjDtSample.Rows.Add(objRow)
                    Next
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

#Region "Commented Code"
    'Private Sub frmSampleParameters_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
    '    '=====================================================================
    '    ' Procedure Name        : frmSampleParameters_Load
    '    ' Parameters Passed     : Object,EventArgs
    '    ' Returns               : None
    '    ' Purpose               : To initialize and load the form
    '    ' Description           : 
    '    ' Assumptions           : 
    '    ' Dependencies          : 
    '    ' Author                : Saurabh
    '    ' Created               : 05.10.06
    '    ' Revisions             : Deepak
    '    ' Revisions             : 3
    '    ' Revision By           : Mangesh S. on 28-Jan-2007
    '    ' Revision for          : Changes in AAS203Library
    '    '=====================================================================
    '    Dim objWait As New CWaitCursor
    '    Dim intCounter As Integer
    '    Dim objRow As DataRow
    '    Dim intNoOfSamples As Integer
    '    Dim blnNewParameter As Boolean = True
    '    Try
    '        'mobjDataGridClass = New DataGridClass(ConstDataGridPropertiesFileName)
    '        If gobjchkActiveMethod.NewMethod = True And gobjchkActiveMethod.CancelMethod = True Then
    '            OpenMethodMode = modGlobalConstants.EnumMethodMode.NewMode
    '        End If

    '        gobjMain.ShowProgressBar(ConstFormLoad)
    '        SubAddHandlers()
    '        mobjDtSample = New DataTable

    '        mobjDtSample.Columns.Clear()

    '        mobjDtSample.Columns.Add(ConstColumnSrNo, GetType(Integer))
    '        mobjDtSample.Columns.Add(ConstColumnSampleName, GetType(String))
    '        mobjDtSample.Columns.Add(ConstColumnWeight, GetType(Double))
    '        mobjDtSample.Columns.Add(ConstColumnVolume, GetType(Double))
    '        mobjDtSample.Columns.Add(ConstColumnDilutionFactor, GetType(Double))

    '        mobjDtSample.Columns(ConstColumnWeight).DefaultValue = DBNull.Value
    '        mobjDtSample.Columns(ConstColumnVolume).DefaultValue = DBNull.Value
    '        mobjDtSample.Columns(ConstColumnDilutionFactor).DefaultValue = DBNull.Value
    '        mobjDtSample.Columns(ConstColumnSampleName).MaxLength = 10

    '        mobjDtSamplesDataGrid.AllowNew = False
    '        mobjDtSamplesDataGrid.AdjustColumnWidthToGrid = False

    '        mobjDtSamplesDataGrid.AddDataGridColumnStyle(mobjDtSample.Columns(0).ColumnName, dgSampleParameters, mobjDtSample, DataGridClass.enumColumnType.TextBoxColumn, HorizontalAlignment.Center, ConstTitleSrNo, ConstWidthSrNo, True, DataGridClass.ColumnDataType.Text, HorizontalAlignment.Center)
    '        mobjDtSamplesDataGrid.AddDataGridColumnStyle(mobjDtSample.Columns(1).ColumnName, dgSampleParameters, mobjDtSample, DataGridClass.enumColumnType.TextBoxColumn, HorizontalAlignment.Center, ConstTitleSampleName, ConstWidthSampleName, False, DataGridClass.ColumnDataType.Text, HorizontalAlignment.Left)
    '        mobjDtSamplesDataGrid.AddDataGridColumnStyle(mobjDtSample.Columns(2).ColumnName, dgSampleParameters, mobjDtSample, DataGridClass.enumColumnType.TextBoxColumn, HorizontalAlignment.Center, ConstTitleWeight, ConstWidthWeight, False, DataGridClass.ColumnDataType.Text, HorizontalAlignment.Center)
    '        mobjDtSamplesDataGrid.AddDataGridColumnStyle(mobjDtSample.Columns(3).ColumnName, dgSampleParameters, mobjDtSample, DataGridClass.enumColumnType.TextBoxColumn, HorizontalAlignment.Center, ConstTitleVolume, ConstWidthVolume, False, DataGridClass.ColumnDataType.Text, HorizontalAlignment.Center)
    '        mobjDtSamplesDataGrid.AddDataGridColumnStyle(mobjDtSample.Columns(4).ColumnName, dgSampleParameters, mobjDtSample, DataGridClass.enumColumnType.TextBoxColumn, HorizontalAlignment.Center, ConstTitleDilutionFactor, ConstWidthDilutionFactor, False, DataGridClass.ColumnDataType.Text, HorizontalAlignment.Center)
    '        mobjDtSamplesDataGrid.SetDataGridProperties(dgSampleParameters, mobjDtSample)

    '        If OpenMethodMode = modGlobalConstants.EnumMethodMode.NewMode Then
    '            'Saurabh Commented 19.07.07
    '            '//----- Added by Sachin Dokhale 
    '            'If Not objPreviousSampParameters Is Nothing Then
    '            '    If objPreviousSampParameters.Count > 0 Then
    '            '        If gobjMessageAdapter.ShowMessage("Load Previous Sample Parameters ? ", "Previous Sample Parameter", MessageHandler.clsMessageHandler.enumMessageType.QuestionMessage) = True Then
    '            '            For intCounter = 0 To objPreviousSampParameters.Count - 1
    '            '                objRow = mobjDtSample.NewRow
    '            '                objRow.Item(ConstColumnSrNo) = intCounter + 1
    '            '                objRow.Item(ConstColumnSampleName) = objPreviousSampParameters(intCounter).SampleName
    '            '                objRow.Item(ConstColumnWeight) = objPreviousSampParameters(intCounter).Weight
    '            '                objRow.Item(ConstColumnVolume) = objPreviousSampParameters(intCounter).Volume
    '            '                objRow.Item(ConstColumnDilutionFactor) = objPreviousSampParameters(intCounter).DilutionFactor
    '            '                mobjDtSample.Rows.Add(objRow)
    '            '                blnNewParameter = False
    '            '            Next intCounter
    '            '        End If
    '            '    End If
    '            'End If
    '            'Saurabh Commented 19.07.07
    '            If blnNewParameter = True Then
    '                '//-----
    '                intNoOfSamples = gobjNewMethod.AnalysisParameters.NumOfSamples
    '                If intNoOfSamples = 0 Then '27.07.07 Deepak
    '                    intNoOfSamples = ConstNumberOfDefaultSamples
    '                End If
    '                If intNoOfSamples > 0 Then
    '                    For intCounter = 0 To intNoOfSamples - 1
    '                        objRow = mobjDtSample.NewRow
    '                        objRow.Item(ConstColumnSrNo) = intCounter + 1
    '                        objRow.Item(ConstColumnSampleName) = ConstDefaultSampleName & intCounter + 1
    '                        objRow.Item(ConstColumnWeight) = ConstDefaultValue
    '                        '------------------Added By Pankaj 11 May 07 6
    '                        If gobjNewMethod.AnalysisParameters.Unit > 1 Then
    '                            objRow.Item(ConstColumnVolume) = 100
    '                        Else
    '                            objRow.Item(ConstColumnVolume) = ConstDefaultValue
    '                        End If
    '                        '----------------
    '                        'objRow.Item(ConstColumnVolume) = ConstDefaultValue
    '                        objRow.Item(ConstColumnDilutionFactor) = ConstDefaultValue
    '                        mobjDtSample.Rows.Add(objRow)
    '                    Next intCounter
    '                End If
    '            End If
    '            'End If
    '            '----------------------------------Saurabh-------------------------------
    '        Else
    '            intNoOfSamples = gobjNewMethod.AnalysisParameters.NumOfSamples
    '            Call funcLoadInitialData(intNoOfSamples)
    '        End If

    '        Call mobjDtSamplesDataGrid.SetDataGridProperties(dgSampleParameters, mobjDtSample)

    '        dgSampleParameters.Focus()
    '        mobjDtSamplesDataGrid.SetDataGridTableStyle.BeginEdit(dgSampleParameters.TableStyles.Item(0).GridColumnStyles(2), 0)

    '        '----------------------------------Saurabh-------------------------------


    '        '''----------------------------ORIGINAL-------------------------------------------
    '        '''intNoOfSamples = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfSamples

    '        '''If intNoOfSamples > 0 Then
    '        '''    For intCounter = 0 To intNoOfSamples - 1
    '        '''        objRow = mobjDtSample.NewRow
    '        '''        objRow.Item(ConstColumnSrNo) = intCounter + 1
    '        '''        objRow.Item(ConstColumnSampleName) = ConstDefaultSampleName & intCounter + 1
    '        '''        objRow.Item(ConstColumnWeight) = ConstDefaultValue
    '        '''        objRow.Item(ConstColumnVolume) = ConstDefaultValue
    '        '''        objRow.Item(ConstColumnDilutionFactor) = ConstDefaultValue
    '        '''        mobjDtSample.Rows.Add(objRow)
    '        '''    Next intCounter
    '        '''End If

    '        ''''If OpenMethodMode = modGlobalConstants.EnumMethodMode.EditMode Then
    '        '''Call funcLoadInitialData(mobjDtSample)
    '        ''''End If

    '        '''----------------------------ORIGINAL-------------------------------------------

    '        'Saurabh 10.07.07 To bring status form in front
    '        If Not IsInIQOQPQ Then
    '            gobjfrmStatus.Show()
    '        End If
    '        'Saurabh

    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        'Error Handling and logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = ex.Message
    '        gobjErrorHandler.WriteErrorLog(ex)
    '        '---------------------------------------------------------
    '    Finally
    '        '---------------------------------------------------------
    '        'Writing Execution log
    '        If CONST_CREATE_EXECUTION_LOG = 1 Then
    '            gobjErrorHandler.WriteExecutionLog()
    '        End If
    '        objWait.Dispose()
    '        gobjMain.HideProgressBar()
    '        '---------------------------------------------------------
    '    End Try
    'End Sub

    'Private Function funcLoadInitialData(ByVal intNoOfSamples As Integer) As Boolean
    '    'Private Function funcLoadInitialData(ByRef objDtSample As DataTable) As Boolean
    '    '=====================================================================
    '    ' Procedure Name        : funcLoadInitialData
    '    ' Parameters Passed     : None
    '    ' Returns               : True or False
    '    ' Purpose               : To load initial data
    '    ' Description           : 
    '    ' Assumptions           : 
    '    ' Dependencies          : 
    '    ' Author                : Deepak Bhati
    '    ' Created               : 08.10.06
    '    ' Revisions             : 2
    '    ' Revision By           : Mangesh S. on 28-Jan-2007
    '    ' Revision for          : Changes in AAS203Library
    '    '=====================================================================
    '    '---------------------------------------Saurabh--------------------------------
    '    Dim intCounter As Integer
    '    Dim objRow As DataRow
    '    Dim intInitialCount As Integer

    '    Try
    '        '---18.06.07
    '        intInitialCount = CInt(gobjNewMethod.SampleDataCollection.Count)

    '        If intNoOfSamples > intInitialCount Then
    '            For intCounter = 0 To intInitialCount - 1
    '                objRow = mobjDtSample.NewRow
    '                objRow.Item(ConstColumnSrNo) = gobjNewMethod.SampleDataCollection.item(intCounter).SampNumber
    '                objRow.Item(ConstColumnSampleName) = gobjNewMethod.SampleDataCollection.item(intCounter).SampleName

    '                If gobjNewMethod.SampleDataCollection.item(intCounter).Weight = 0.0 Then
    '                    objRow.Item(ConstColumnWeight) = DBNull.Value
    '                Else
    '                    objRow.Item(ConstColumnWeight) = FormatNumber(gobjNewMethod.SampleDataCollection.item(intCounter).Weight, 6)
    '                End If

    '                If gobjNewMethod.SampleDataCollection.item(intCounter).Volume = 0.0 Then
    '                    objRow.Item(ConstColumnVolume) = DBNull.Value
    '                Else
    '                    'objRow.Item(ConstColumnVolume) = FormatNumber(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCounter).Volume, 6)
    '                    '------------------Added By Pankaj 11 May 07 6
    '                    'If gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.Unit = 2 And FormatNumber(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCounter).Volume, 6) < 100 Then
    '                    'objRow.Item(ConstColumnVolume) = 100 * FormatNumber(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCounter).Volume, 6)
    '                    'Else
    '                    objRow.Item(ConstColumnVolume) = FormatNumber(gobjNewMethod.SampleDataCollection.item(intCounter).Volume, 6)
    '                    'End If
    '                    '----------------

    '                End If

    '                If gobjNewMethod.SampleDataCollection.item(intCounter).DilutionFactor = 0.0 Then
    '                    objRow.Item(ConstColumnDilutionFactor) = DBNull.Value
    '                Else
    '                    objRow.Item(ConstColumnDilutionFactor) = FormatNumber(gobjNewMethod.SampleDataCollection.item(intCounter).DilutionFactor, 6)
    '                End If

    '                mobjDtSample.Rows.Add(objRow)
    '            Next

    '            For intCounter = intInitialCount To intNoOfSamples - 1
    '                objRow = mobjDtSample.NewRow
    '                objRow.Item(ConstColumnSrNo) = intCounter + 1
    '                objRow.Item(ConstColumnSampleName) = ConstDefaultSampleName & intCounter + 1
    '                objRow.Item(ConstColumnWeight) = ConstDefaultValue
    '                objRow.Item(ConstColumnVolume) = ConstDefaultValue
    '                objRow.Item(ConstColumnDilutionFactor) = ConstDefaultValue
    '                mobjDtSample.Rows.Add(objRow)
    '            Next

    '        ElseIf intNoOfSamples < intInitialCount Then

    '            For intCounter = 0 To intNoOfSamples - 1
    '                objRow = mobjDtSample.NewRow
    '                objRow.Item(ConstColumnSrNo) = gobjNewMethod.SampleDataCollection.item(intCounter).SampNumber
    '                objRow.Item(ConstColumnSampleName) = gobjNewMethod.SampleDataCollection.item(intCounter).SampleName

    '                If gobjNewMethod.SampleDataCollection.item(intCounter).Weight = 0.0 Then
    '                    objRow.Item(ConstColumnWeight) = DBNull.Value
    '                Else
    '                    objRow.Item(ConstColumnWeight) = FormatNumber(gobjNewMethod.SampleDataCollection.item(intCounter).Weight, 6)
    '                End If

    '                If gobjNewMethod.SampleDataCollection.item(intCounter).Volume = 0.0 Then
    '                    objRow.Item(ConstColumnVolume) = DBNull.Value
    '                Else
    '                    '------------------Added By Pankaj 11 May 07 6
    '                    'If gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.Unit = 2 And FormatNumber(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCounter).Volume, 6) < 100 Then
    '                    '    objRow.Item(ConstColumnVolume) = 100 * FormatNumber(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCounter).Volume, 6)
    '                    'Else
    '                    objRow.Item(ConstColumnVolume) = FormatNumber(gobjNewMethod.SampleDataCollection.item(intCounter).Volume, 6)
    '                    'End If
    '                    '----------------

    '                    'objRow.Item(ConstColumnVolume) = FormatNumber(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCounter).Volume, 6)
    '                End If

    '                If gobjNewMethod.SampleDataCollection.item(intCounter).DilutionFactor = 0.0 Then
    '                    objRow.Item(ConstColumnDilutionFactor) = DBNull.Value
    '                Else
    '                    objRow.Item(ConstColumnDilutionFactor) = FormatNumber(gobjNewMethod.SampleDataCollection.item(intCounter).DilutionFactor, 6)
    '                End If

    '                mobjDtSample.Rows.Add(objRow)
    '            Next
    '        Else
    '            For intCounter = 0 To intInitialCount - 1
    '                objRow = mobjDtSample.NewRow
    '                objRow.Item(ConstColumnSrNo) = gobjNewMethod.SampleDataCollection.item(intCounter).SampNumber
    '                objRow.Item(ConstColumnSampleName) = gobjNewMethod.SampleDataCollection.item(intCounter).SampleName

    '                If gobjNewMethod.SampleDataCollection.item(intCounter).Weight = 0.0 Then
    '                    objRow.Item(ConstColumnWeight) = DBNull.Value
    '                Else
    '                    objRow.Item(ConstColumnWeight) = FormatNumber(gobjNewMethod.SampleDataCollection.item(intCounter).Weight, 6)
    '                End If

    '                If gobjNewMethod.SampleDataCollection.item(intCounter).Volume = 0.0 Then
    '                    objRow.Item(ConstColumnVolume) = DBNull.Value
    '                Else
    '                    '------------------Added By Pankaj 11 May 07 6
    '                    'If gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.Unit = 2 And FormatNumber(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCounter).Volume, 6) < 100 Then
    '                    '    objRow.Item(ConstColumnVolume) = 100 * FormatNumber(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCounter).Volume, 6)
    '                    'Else
    '                    objRow.Item(ConstColumnVolume) = FormatNumber(gobjNewMethod.SampleDataCollection.item(intCounter).Volume, 6)
    '                    'End If
    '                    '----------------


    '                End If

    '                If gobjNewMethod.SampleDataCollection.item(intCounter).DilutionFactor = 0.0 Then
    '                    objRow.Item(ConstColumnDilutionFactor) = DBNull.Value
    '                Else
    '                    objRow.Item(ConstColumnDilutionFactor) = FormatNumber(gobjNewMethod.SampleDataCollection.item(intCounter).DilutionFactor, 6)
    '                End If

    '                mobjDtSample.Rows.Add(objRow)
    '            Next
    '        End If

    '        Return True
    '        '---------------------------------------Saurabh--------------------------------

    '        '''--------------------------------------Original----------------------------------------
    '        '''Dim intCounter As Integer
    '        '''Dim objRow As DataRow

    '        '''Try
    '        '''    For intCounter = 0 To gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.Count - 1
    '        '''        objDtSample.Rows.Item(intCounter).Item(ConstColumnSrNo) = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCounter).SampNumber
    '        '''        objDtSample.Rows.Item(intCounter).Item(ConstColumnSampleName) = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCounter).SampleName
    '        '''        objDtSample.Rows.Item(intCounter).Item(ConstColumnWeight) = FormatNumber(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCounter).Weight, 4)
    '        '''        objDtSample.Rows.Item(intCounter).Item(ConstColumnVolume) = FormatNumber(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCounter).Volume, 4)
    '        '''        objDtSample.Rows.Item(intCounter).Item(ConstColumnDilutionFactor) = FormatNumber(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCounter).DilutionFactor, 4)
    '        '''    Next

    '        '''    Return True
    '        '''--------------------------------------Original----------------------------------------

    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        'Error Handling and logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = ex.Message
    '        gobjErrorHandler.WriteErrorLog(ex)
    '        Return False
    '        '---------------------------------------------------------
    '    Finally
    '        '---------------------------------------------------------
    '        'Writing Execution log
    '        If CONST_CREATE_EXECUTION_LOG = 1 Then
    '            gobjErrorHandler.WriteExecutionLog()
    '        End If
    '        '---------------------------------------------------------
    '    End Try
    'End Function

    'Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    '=====================================================================
    '    ' Procedure Name        : btnOk_Click
    '    ' Parameters Passed     : Object,EventArgs
    '    ' Returns               : None
    '    ' Purpose               : To send dialog result as ok
    '    ' Description           : 
    '    ' Assumptions           : 
    '    ' Dependencies          : 
    '    ' Author                : Deepak
    '    ' Created               : 05.10.06
    '    ' Revisions             : 
    '    '=====================================================================
    '    Dim objWait As New CWaitCursor
    '    Dim intCounter As Integer
    '    Dim objClsSampleParameters As clsAnalysisSampleParameters
    '    Dim objSamplesCollection As clsAnalysisSampleParametersCollection

    '    Try
    '        objSamplesCollection = New clsAnalysisSampleParametersCollection

    '        For intCounter = 0 To mobjDtSample.Rows.Count - 1
    '            If Trim(mobjDtSample.Rows(intCounter).Item(ConstColumnSampleName)) <> "" And Not IsDBNull(mobjDtSample.Rows(intCounter).Item(ConstColumnWeight)) And Not IsDBNull(mobjDtSample.Rows(intCounter).Item(ConstColumnVolume)) And Not IsDBNull(mobjDtSample.Rows(intCounter).Item(ConstColumnDilutionFactor)) Then
    '                If IsNumeric(Trim(mobjDtSample.Rows(intCounter).Item(ConstColumnWeight))) And IsNumeric(Trim(mobjDtSample.Rows(intCounter).Item(ConstColumnVolume))) And IsNumeric(Trim(mobjDtSample.Rows(intCounter).Item(ConstColumnDilutionFactor))) Then
    '                    objClsSampleParameters = New clsAnalysisSampleParameters
    '                    objClsSampleParameters.SampNumber = mobjDtSample.Rows(intCounter).Item(ConstColumnSrNo)
    '                    objClsSampleParameters.SampleName = mobjDtSample.Rows(intCounter).Item(ConstColumnSampleName)
    '                    objClsSampleParameters.Weight = mobjDtSample.Rows(intCounter).Item(ConstColumnWeight)
    '                    objClsSampleParameters.Volume = mobjDtSample.Rows(intCounter).Item(ConstColumnVolume)
    '                    objClsSampleParameters.DilutionFactor = mobjDtSample.Rows(intCounter).Item(ConstColumnDilutionFactor)

    '                    objSamplesCollection.Add(objClsSampleParameters)
    '                Else
    '                    gobjMessageAdapter.ShowMessage(constInputProperData)
    '                    Application.DoEvents()
    '                    Exit Sub
    '                End If
    '            Else
    '                gobjMessageAdapter.ShowMessage(constInputProperData)
    '                Application.DoEvents()
    '                Exit Sub
    '            End If
    '        Next
    '        'For intRunNo As Integer = 0 To gobjNewMethod.QuantitativeDataCollection.Count - 1
    '        For intCounter = 0 To gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.Count - 1
    '            If gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.Count > intCounter Then
    '                If gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCounter).Used = True Then
    '                    objSamplesCollection.item(intCounter).Used = True
    '                    'If gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCounter).Abs <> -1.0 Then
    '                    objSamplesCollection.item(intCounter).Abs = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCounter).Abs
    '                    'End If
    '            End If
    '            End If
    '        Next
    '        'Next
    '        gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.Clear()
    '        gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection = objSamplesCollection.Clone()

    '        '---Update Current Method in Method Collection
    '        For intCounter = 0 To gobjMethodCollection.Count - 1
    '            If gobjMethodCollection.item(intCounter).MethodID = gobjNewMethod.MethodID Then
    '                If (gobjMethodCollection.item(intCounter).QuantitativeDataCollection.Count >= gobjNewMethod.QuantitativeDataCollection.Count) Then
    '                    gobjMethodCollection.item(intCounter).QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.Clone()
    '                    gobjMethodCollection.item(intCounter).DateOfModification = DateTime.Now
    '                Else
    '                    'gobjMethodCollection.item(intCounter).QuantitativeDataCollection.Add(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex))
    '                    'gobjMethodCollection.item(intCounter).DateOfModification = DateTime.Now
    '                End If

    '            End If
    '        Next

    '        '---serialize method collection 
    '        'Call funcSerialize(ConstMethodsFileName, gobjMethodCollection)

    '        Call funcSaveAllMethods(gobjMethodCollection)


    '        Me.DialogResult = DialogResult.OK

    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        'Error Handling and logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = ex.Message
    '        gobjErrorHandler.WriteErrorLog(ex)
    '        '---------------------------------------------------------
    '    Finally
    '        '---------------------------------------------------------
    '        'Writing Execution log
    '        If CONST_CREATE_EXECUTION_LOG = 1 Then
    '            gobjErrorHandler.WriteExecutionLog()
    '        End If
    '        If Not objWait Is Nothing Then
    '            objWait.Dispose()
    '        End If
    '        '---------------------------------------------------------
    '    End Try
    'End Sub

    'Private Function funcLoadInitialData(ByVal intNoOfSamples As Integer) As Boolean
    '    'Private Function funcLoadInitialData(ByRef objDtSample As DataTable) As Boolean
    '    '=====================================================================
    '    ' Procedure Name        : funcLoadInitialData
    '    ' Parameters Passed     : None
    '    ' Returns               : True or False
    '    ' Purpose               : To load initial data
    '    ' Description           : 
    '    ' Assumptions           : 
    '    ' Dependencies          : 
    '    ' Author                : Deepak Bhati
    '    ' Created               : 08.10.06
    '    ' Revisions             : 2
    '    ' Revision By           : Mangesh S. on 28-Jan-2007
    '    ' Revision for          : Changes in AAS203Library
    '    '=====================================================================
    '    '---------------------------------------Saurabh--------------------------------
    '    Dim intCounter As Integer
    '    Dim objRow As DataRow
    '    Dim intInitialCount As Integer

    '    Try
    '        intInitialCount = CInt(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.Count)

    '        If intNoOfSamples > intInitialCount Then
    '            For intCounter = 0 To intInitialCount - 1
    '                objRow = mobjDtSample.NewRow
    '                objRow.Item(ConstColumnSrNo) = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCounter).SampNumber
    '                objRow.Item(ConstColumnSampleName) = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCounter).SampleName

    '                If gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCounter).Weight = 0.0 Then
    '                    objRow.Item(ConstColumnWeight) = DBNull.Value
    '                Else
    '                    objRow.Item(ConstColumnWeight) = FormatNumber(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCounter).Weight, 6)
    '                End If

    '                If gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCounter).Volume = 0.0 Then
    '                    objRow.Item(ConstColumnVolume) = DBNull.Value
    '                Else
    '                    'objRow.Item(ConstColumnVolume) = FormatNumber(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCounter).Volume, 6)
    '                    '------------------Added By Pankaj 11 May 07 6
    '                    'If gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.Unit = 2 And FormatNumber(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCounter).Volume, 6) < 100 Then
    '                    'objRow.Item(ConstColumnVolume) = 100 * FormatNumber(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCounter).Volume, 6)
    '                    'Else
    '                    objRow.Item(ConstColumnVolume) = FormatNumber(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCounter).Volume, 6)
    '                    'End If
    '                    '----------------

    '                End If

    '                If gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCounter).DilutionFactor = 0.0 Then
    '                    objRow.Item(ConstColumnDilutionFactor) = DBNull.Value
    '                Else
    '                    objRow.Item(ConstColumnDilutionFactor) = FormatNumber(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCounter).DilutionFactor, 6)
    '                End If

    '                mobjDtSample.Rows.Add(objRow)
    '            Next

    '            For intCounter = intInitialCount To intNoOfSamples - 1
    '                objRow = mobjDtSample.NewRow
    '                objRow.Item(ConstColumnSrNo) = intCounter + 1
    '                objRow.Item(ConstColumnSampleName) = ConstDefaultSampleName & intCounter + 1
    '                objRow.Item(ConstColumnWeight) = ConstDefaultValue
    '                objRow.Item(ConstColumnVolume) = ConstDefaultValue
    '                objRow.Item(ConstColumnDilutionFactor) = ConstDefaultValue
    '                mobjDtSample.Rows.Add(objRow)
    '            Next

    '        ElseIf intNoOfSamples < intInitialCount Then

    '            For intCounter = 0 To intNoOfSamples - 1
    '                objRow = mobjDtSample.NewRow
    '                objRow.Item(ConstColumnSrNo) = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCounter).SampNumber
    '                objRow.Item(ConstColumnSampleName) = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCounter).SampleName

    '                If gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCounter).Weight = 0.0 Then
    '                    objRow.Item(ConstColumnWeight) = DBNull.Value
    '                Else
    '                    objRow.Item(ConstColumnWeight) = FormatNumber(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCounter).Weight, 6)
    '                End If

    '                If gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCounter).Volume = 0.0 Then
    '                    objRow.Item(ConstColumnVolume) = DBNull.Value
    '                Else
    '                    '------------------Added By Pankaj 11 May 07 6
    '                    'If gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.Unit = 2 And FormatNumber(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCounter).Volume, 6) < 100 Then
    '                    '    objRow.Item(ConstColumnVolume) = 100 * FormatNumber(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCounter).Volume, 6)
    '                    'Else
    '                        objRow.Item(ConstColumnVolume) = FormatNumber(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCounter).Volume, 6)
    '                    'End If
    '                    '----------------

    '                    'objRow.Item(ConstColumnVolume) = FormatNumber(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCounter).Volume, 6)
    '                End If

    '                If gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCounter).DilutionFactor = 0.0 Then
    '                    objRow.Item(ConstColumnDilutionFactor) = DBNull.Value
    '                Else
    '                    objRow.Item(ConstColumnDilutionFactor) = FormatNumber(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCounter).DilutionFactor, 6)
    '                End If

    '                mobjDtSample.Rows.Add(objRow)
    '            Next
    '        Else
    '            For intCounter = 0 To intInitialCount - 1
    '                objRow = mobjDtSample.NewRow
    '                objRow.Item(ConstColumnSrNo) = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCounter).SampNumber
    '                objRow.Item(ConstColumnSampleName) = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCounter).SampleName

    '                If gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCounter).Weight = 0.0 Then
    '                    objRow.Item(ConstColumnWeight) = DBNull.Value
    '                Else
    '                    objRow.Item(ConstColumnWeight) = FormatNumber(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCounter).Weight, 6)
    '                End If

    '                If gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCounter).Volume = 0.0 Then
    '                    objRow.Item(ConstColumnVolume) = DBNull.Value
    '                Else
    '                    '------------------Added By Pankaj 11 May 07 6
    '                    'If gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.Unit = 2 And FormatNumber(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCounter).Volume, 6) < 100 Then
    '                    '    objRow.Item(ConstColumnVolume) = 100 * FormatNumber(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCounter).Volume, 6)
    '                    'Else
    '                        objRow.Item(ConstColumnVolume) = FormatNumber(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCounter).Volume, 6)
    '                    'End If
    '                    '----------------


    '                End If

    '                If gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCounter).DilutionFactor = 0.0 Then
    '                    objRow.Item(ConstColumnDilutionFactor) = DBNull.Value
    '                Else
    '                    objRow.Item(ConstColumnDilutionFactor) = FormatNumber(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCounter).DilutionFactor, 6)
    '                End If

    '                mobjDtSample.Rows.Add(objRow)
    '            Next
    '        End If

    '        Return True
    '        '---------------------------------------Saurabh--------------------------------

    '        '''--------------------------------------Original----------------------------------------
    '        '''Dim intCounter As Integer
    '        '''Dim objRow As DataRow

    '        '''Try
    '        '''    For intCounter = 0 To gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.Count - 1
    '        '''        objDtSample.Rows.Item(intCounter).Item(ConstColumnSrNo) = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCounter).SampNumber
    '        '''        objDtSample.Rows.Item(intCounter).Item(ConstColumnSampleName) = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCounter).SampleName
    '        '''        objDtSample.Rows.Item(intCounter).Item(ConstColumnWeight) = FormatNumber(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCounter).Weight, 4)
    '        '''        objDtSample.Rows.Item(intCounter).Item(ConstColumnVolume) = FormatNumber(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCounter).Volume, 4)
    '        '''        objDtSample.Rows.Item(intCounter).Item(ConstColumnDilutionFactor) = FormatNumber(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCounter).DilutionFactor, 4)
    '        '''    Next

    '        '''    Return True
    '        '''--------------------------------------Original----------------------------------------

    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        'Error Handling and logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = ex.Message
    '        gobjErrorHandler.WriteErrorLog(ex)
    '        Return False
    '        '---------------------------------------------------------
    '    Finally
    '        '---------------------------------------------------------
    '        'Writing Execution log
    '        If CONST_CREATE_EXECUTION_LOG = 1 Then
    '            gobjErrorHandler.WriteExecutionLog()
    '        End If
    '        '---------------------------------------------------------
    '    End Try
    'End Function


#End Region

    Private Sub btnChangeTiming_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChangeTiming.Click
        '=====================================================================
        ' Procedure Name        : btnChangeTiming_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To change the time of autosampler
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak
        ' Created               : 05.10.06
        ' Revisions             : 
        '=====================================================================
        ''note:
        ''this is called when user clicked on change timing button
        ''this is used for autosampler
        ''this will show a change timing dialog box.


        Try
            If (gstructAutoSampler.blnCommunication = True) Then
                Dim objfrmtimings As New frmTimings
                objfrmtimings.ShowDialog()
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

End Class
