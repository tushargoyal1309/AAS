Imports AAS203.Common
Imports AAS203Library.Method


Public Class frmStandardConcentration
    Inherits System.Windows.Forms.Form


#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    Public Sub New(ByVal intIQOQtest As Integer)

        'constructor overloaded by ; dinesh wagh on 2.2.2010

        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

        mintIQOQPQtest = intIQOQtest


    End Sub

    'Public Sub New(ByVal intMethodMode As Integer)
    '    MyBase.New()

    '    'This call is required by the Windows Form Designer.
    '    InitializeComponent()

    '    'Add any initialization after the InitializeComponent() call
    '    OpenMethodMode = intMethodMode

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
    Friend WithEvents CustomPanelMain As GradientPanel.CustomPanel
    Friend WithEvents CustomPanelBottom As GradientPanel.CustomPanel
    Friend WithEvents CustomPanelBottomTop As GradientPanel.CustomPanel
    Friend WithEvents btnHelp As NETXP.Controls.XPButton
    Friend WithEvents btnOk As NETXP.Controls.XPButton
    Friend WithEvents btnCancel As NETXP.Controls.XPButton
    Friend WithEvents Office2003Header1 As CodeIntellects.Office2003Controls.Office2003Header
    Friend WithEvents dgStdConcentration As System.Windows.Forms.DataGrid
    Friend WithEvents CustomPanelTop As GradientPanel.CustomPanel
    Friend WithEvents lblImpNotes As System.Windows.Forms.Label
    Friend WithEvents lblNote1 As System.Windows.Forms.Label
    Friend WithEvents lblNote2 As System.Windows.Forms.Label
    Friend WithEvents lblNote3 As System.Windows.Forms.Label
    Friend WithEvents btnAddNew As NETXP.Controls.XPButton
    Friend WithEvents btnChangeTiming As NETXP.Controls.XPButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmStandardConcentration))
        Me.CustomPanelMain = New GradientPanel.CustomPanel
        Me.CustomPanelTop = New GradientPanel.CustomPanel
        Me.dgStdConcentration = New System.Windows.Forms.DataGrid
        Me.CustomPanelBottom = New GradientPanel.CustomPanel
        Me.btnChangeTiming = New NETXP.Controls.XPButton
        Me.CustomPanelBottomTop = New GradientPanel.CustomPanel
        Me.lblNote3 = New System.Windows.Forms.Label
        Me.lblNote2 = New System.Windows.Forms.Label
        Me.lblNote1 = New System.Windows.Forms.Label
        Me.lblImpNotes = New System.Windows.Forms.Label
        Me.btnOk = New NETXP.Controls.XPButton
        Me.btnCancel = New NETXP.Controls.XPButton
        Me.btnAddNew = New NETXP.Controls.XPButton
        Me.btnHelp = New NETXP.Controls.XPButton
        Me.Office2003Header1 = New CodeIntellects.Office2003Controls.Office2003Header
        Me.CustomPanelMain.SuspendLayout()
        Me.CustomPanelTop.SuspendLayout()
        CType(Me.dgStdConcentration, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.CustomPanelMain.Size = New System.Drawing.Size(404, 329)
        Me.CustomPanelMain.TabIndex = 12
        '
        'CustomPanelTop
        '
        Me.CustomPanelTop.BackColor = System.Drawing.Color.Transparent
        Me.CustomPanelTop.BackColor2 = System.Drawing.Color.Transparent
        Me.CustomPanelTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CustomPanelTop.Controls.Add(Me.dgStdConcentration)
        Me.CustomPanelTop.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CustomPanelTop.Location = New System.Drawing.Point(0, 0)
        Me.CustomPanelTop.Name = "CustomPanelTop"
        Me.CustomPanelTop.Size = New System.Drawing.Size(404, 153)
        Me.CustomPanelTop.TabIndex = 0
        '
        'dgStdConcentration
        '
        Me.dgStdConcentration.CaptionVisible = False
        Me.dgStdConcentration.DataMember = ""
        Me.dgStdConcentration.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgStdConcentration.Location = New System.Drawing.Point(16, 16)
        Me.dgStdConcentration.Name = "dgStdConcentration"
        Me.dgStdConcentration.Size = New System.Drawing.Size(376, 110)
        Me.dgStdConcentration.TabIndex = 0
        '
        'CustomPanelBottom
        '
        Me.CustomPanelBottom.BackColor = System.Drawing.Color.Transparent
        Me.CustomPanelBottom.BackColor2 = System.Drawing.Color.Transparent
        Me.CustomPanelBottom.Controls.Add(Me.btnChangeTiming)
        Me.CustomPanelBottom.Controls.Add(Me.CustomPanelBottomTop)
        Me.CustomPanelBottom.Controls.Add(Me.btnOk)
        Me.CustomPanelBottom.Controls.Add(Me.btnCancel)
        Me.CustomPanelBottom.Controls.Add(Me.btnAddNew)
        Me.CustomPanelBottom.Controls.Add(Me.btnHelp)
        Me.CustomPanelBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.CustomPanelBottom.Location = New System.Drawing.Point(0, 153)
        Me.CustomPanelBottom.Name = "CustomPanelBottom"
        Me.CustomPanelBottom.Size = New System.Drawing.Size(404, 176)
        Me.CustomPanelBottom.TabIndex = 8
        '
        'btnChangeTiming
        '
        Me.btnChangeTiming.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnChangeTiming.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnChangeTiming.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnChangeTiming.Location = New System.Drawing.Point(72, 128)
        Me.btnChangeTiming.Name = "btnChangeTiming"
        Me.btnChangeTiming.Size = New System.Drawing.Size(96, 32)
        Me.btnChangeTiming.TabIndex = 11
        Me.btnChangeTiming.Text = "&Change Timing"
        '
        'CustomPanelBottomTop
        '
        Me.CustomPanelBottomTop.BackColor = System.Drawing.Color.Transparent
        Me.CustomPanelBottomTop.BackColor2 = System.Drawing.Color.Transparent
        Me.CustomPanelBottomTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CustomPanelBottomTop.Controls.Add(Me.lblNote3)
        Me.CustomPanelBottomTop.Controls.Add(Me.lblNote2)
        Me.CustomPanelBottomTop.Controls.Add(Me.lblNote1)
        Me.CustomPanelBottomTop.Controls.Add(Me.lblImpNotes)
        Me.CustomPanelBottomTop.Location = New System.Drawing.Point(0, 8)
        Me.CustomPanelBottomTop.Name = "CustomPanelBottomTop"
        Me.CustomPanelBottomTop.Size = New System.Drawing.Size(374, 112)
        Me.CustomPanelBottomTop.TabIndex = 9
        '
        'lblNote3
        '
        Me.lblNote3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNote3.Location = New System.Drawing.Point(6, 82)
        Me.lblNote3.Name = "lblNote3"
        Me.lblNote3.Size = New System.Drawing.Size(344, 16)
        Me.lblNote3.TabIndex = 3
        Me.lblNote3.Text = "3. Please enter different standard names"
        '
        'lblNote2
        '
        Me.lblNote2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNote2.Location = New System.Drawing.Point(6, 57)
        Me.lblNote2.Name = "lblNote2"
        Me.lblNote2.Size = New System.Drawing.Size(344, 16)
        Me.lblNote2.TabIndex = 2
        Me.lblNote2.Text = "2. Please enter the standards in increasing order only "
        '
        'lblNote1
        '
        Me.lblNote1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNote1.Location = New System.Drawing.Point(7, 32)
        Me.lblNote1.Name = "lblNote1"
        Me.lblNote1.Size = New System.Drawing.Size(360, 16)
        Me.lblNote1.TabIndex = 1
        Me.lblNote1.Text = "1. In Standard Addition Method, first standard must be 0.0 conc."
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
        'btnOk
        '
        Me.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOk.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOk.Image = CType(resources.GetObject("btnOk.Image"), System.Drawing.Image)
        Me.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnOk.Location = New System.Drawing.Point(176, 128)
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
        Me.btnCancel.Location = New System.Drawing.Point(272, 128)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(86, 34)
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Text = "&Cancel"
        '
        'btnAddNew
        '
        Me.btnAddNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAddNew.Location = New System.Drawing.Point(221, 4)
        Me.btnAddNew.Name = "btnAddNew"
        Me.btnAddNew.Size = New System.Drawing.Size(136, 24)
        Me.btnAddNew.TabIndex = 0
        Me.btnAddNew.Text = "Click to add Standard"
        Me.btnAddNew.Visible = False
        '
        'btnHelp
        '
        Me.btnHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnHelp.Image = CType(resources.GetObject("btnHelp.Image"), System.Drawing.Image)
        Me.btnHelp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnHelp.Location = New System.Drawing.Point(272, 144)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(86, 34)
        Me.btnHelp.TabIndex = 4
        Me.btnHelp.Text = "Help"
        Me.btnHelp.Visible = False
        '
        'Office2003Header1
        '
        Me.Office2003Header1.BackColor = System.Drawing.SystemColors.Control
        Me.Office2003Header1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Office2003Header1.Location = New System.Drawing.Point(0, 0)
        Me.Office2003Header1.Name = "Office2003Header1"
        Me.Office2003Header1.Size = New System.Drawing.Size(404, 22)
        Me.Office2003Header1.TabIndex = 13
        Me.Office2003Header1.TitleFont = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Office2003Header1.TitleText = "Standard Concentration"
        '
        'frmStandardConcentration
        '
        Me.AcceptButton = Me.btnOk
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(404, 351)
        Me.ControlBox = False
        Me.Controls.Add(Me.CustomPanelMain)
        Me.Controls.Add(Me.Office2003Header1)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmStandardConcentration"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Method "
        Me.TopMost = True
        Me.CustomPanelMain.ResumeLayout(False)
        Me.CustomPanelTop.ResumeLayout(False)
        CType(Me.dgStdConcentration, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CustomPanelBottom.ResumeLayout(False)
        Me.CustomPanelBottomTop.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Private Member Variables "

    Private mobjDtStandards As DataTable
    Private mobjDtStandardsDataGrid As New DataGridClass(ConstDataGridPropertiesFileName)

    Private mintMethodMode As Integer
    Private mintRunNumberIndex As Integer
    Dim intGridRowNo As Integer = 0
    Private mblnIsCancel As Boolean = False

    Private mintIQOQPQtest As Integer 'added by ;dinesh wagh on 2.2.2010


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
    Private Const ConstNumberOfCharactersInSampleNameColum = 10
    Private Const ConstColumnSrNo = "SrNo"
    Private Const ConstColumnStandardName = "StandardName"
    Private Const ConstColumnSamplerPos = "Sampler Pos"
    Private Const ConstColumnConcentration = "Concentration"
    Private Const ConstColumnRemove = "Remove"
    Private Const ConstTitleSrNo = "Sr.No."
    Private Const ConstTitleStandardName = "Standard Name"
    Private Const ConstTitleConcentration = "Concentrations"
    Private Const ConstTitleRemove = "Remove"
    Private Const ConstWidthSrNo = 55
    Private Const ConstWidthStandardName = 135
    Private Const ConstWidthConcentration = 135
    Private Const ConstParentFormLoad = "-Method"
    Private Const ConstFormLoad = "-Method-Standard Concentration"
    'Private Const ConstWidthRemove = 58

#End Region

#Region " Form Events "

    Private Sub frmStandardConcentration_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '=====================================================================
        ' Procedure Name        : frmStandardConcentration_Load
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

        ''note:
        ''this is is called when std concentration form is loaded 
        ''this is used to initialization of from

        Dim objWait As New CWaitCursor
        Dim intCounter As Integer
        Dim objRow As DataRow
        Dim intCount As Integer

        Try
            Call gobjMain.ShowProgressBar(gstrTitleInstrumentType & ConstFormLoad)
            ''show the current ststus of instrument on progressbar
            Call SubAddHandlers()
            ''add all the event 
            mobjDtStandards = New DataTable

            ''this is code for grid control
            ''grid control is used for displaying a std name , contration etc on screen 
            ''in well fromated manner 
            mobjDtStandards.Columns.Add(ConstColumnSrNo, GetType(Integer))
            mobjDtStandards.Columns.Add(ConstColumnStandardName, GetType(String))
            mobjDtStandards.Columns.Add(ConstColumnConcentration, GetType(String))

            mobjDtStandards.Columns(ConstColumnConcentration).DefaultValue = DBNull.Value

            mobjDtStandardsDataGrid.AllowNew = False
            mobjDtStandardsDataGrid.AdjustColumnWidthToGrid = False
            
            If (gstructAutoSampler.blnAutoSamplerInitialised = True) Then 'by pankaj for autosampler
                ''this is for auto sampler
                ''do  initialisation if auto sampler is present

                mobjDtStandardsDataGrid.AddDataGridColumnStyle(mobjDtStandards.Columns(ConstColumnSrNo).ColumnName, dgStdConcentration, mobjDtStandards, DataGridClass.enumColumnType.TextBoxColumn, HorizontalAlignment.Center, ConstTitleSrNo, ConstWidthSrNo, True, DataGridClass.ColumnDataType.Text, HorizontalAlignment.Center)
                mobjDtStandardsDataGrid.AddDataGridColumnStyle(mobjDtStandards.Columns(ConstColumnStandardName).ColumnName, dgStdConcentration, mobjDtStandards, DataGridClass.enumColumnType.TextBoxColumn, HorizontalAlignment.Center, ConstTitleStandardName, ConstWidthSrNo + ConstWidthSrNo, False, DataGridClass.ColumnDataType.Text, HorizontalAlignment.Left, ConstNumberOfCharactersInSampleNameColum, True, False)
                mobjDtStandardsDataGrid.AddDataGridColumnStyle(mobjDtStandards.Columns(ConstColumnConcentration).ColumnName, dgStdConcentration, mobjDtStandards, DataGridClass.enumColumnType.TextBoxColumn, HorizontalAlignment.Center, ConstTitleConcentration, ConstWidthSrNo + ConstWidthSrNo, False, DataGridClass.ColumnDataType.Text, HorizontalAlignment.Left, 11, True, True)

                mobjDtStandards.Columns.Add(ConstColumnSamplerPos, GetType(String))
                mobjDtStandards.Columns(ConstColumnSamplerPos).DefaultValue = DBNull.Value
                mobjDtStandardsDataGrid.AddDataGridColumnStyle(mobjDtStandards.Columns(ConstColumnSamplerPos).ColumnName, dgStdConcentration, mobjDtStandards, DataGridClass.enumColumnType.TextBoxColumn, HorizontalAlignment.Center, ConstColumnSamplerPos, ConstWidthSrNo + ConstWidthSrNo - 30, False, DataGridClass.ColumnDataType.Text, HorizontalAlignment.Left, 2, True, True)

            Else
                mobjDtStandardsDataGrid.AddDataGridColumnStyle(mobjDtStandards.Columns(ConstColumnSrNo).ColumnName, dgStdConcentration, mobjDtStandards, DataGridClass.enumColumnType.TextBoxColumn, HorizontalAlignment.Center, ConstTitleSrNo, ConstWidthSrNo, True, DataGridClass.ColumnDataType.Text, HorizontalAlignment.Center)
                mobjDtStandardsDataGrid.AddDataGridColumnStyle(mobjDtStandards.Columns(ConstColumnStandardName).ColumnName, dgStdConcentration, mobjDtStandards, DataGridClass.enumColumnType.TextBoxColumn, HorizontalAlignment.Center, ConstTitleStandardName, ConstWidthStandardName, False, DataGridClass.ColumnDataType.Text, HorizontalAlignment.Left, ConstNumberOfCharactersInSampleNameColum, True, False)
                mobjDtStandardsDataGrid.AddDataGridColumnStyle(mobjDtStandards.Columns(ConstColumnConcentration).ColumnName, dgStdConcentration, mobjDtStandards, DataGridClass.enumColumnType.TextBoxColumn, HorizontalAlignment.Center, ConstTitleConcentration, ConstWidthConcentration, False, DataGridClass.ColumnDataType.Text, HorizontalAlignment.Left, 11, True, True)
                Me.dgStdConcentration.Width = Me.dgStdConcentration.Width - 30
            End If

            Call funcLoadInitialData()
            ''this is called to load some initial data.

            Call mobjDtStandardsDataGrid.SetDataGridProperties(dgStdConcentration, mobjDtStandards)
            ''set a data grid property




            'code commented by ; dinesh wagh on 2.2.2010
            '----------------------------------------------
            ''For intCount = gobjNewMethod.StandardDataCollection.Count + 1 To 15
            ''    Call subAddNewClicked(intCount)
            ''    ''add a data of maximum 15 std
            ''Next
            '------------------------------------------------

            'code added by ;dinesh wagh on 2.2.2010
            'Purpose : There is only one std required.Suggested by ; vck sir.
            '---------------------------------------------------------
            Dim intTotalStd As Integer
            If IsInIQOQPQ Then
                Select Case mintIQOQPQtest
                    Case EnumIQOQPQtestId.ePQAtt1
                        intTotalStd = 1
                    Case Else
                        intTotalStd = 15
                End Select

                '15.2.2010 by dinesh wagh
                '---------------------
                lblNote2.Text = "1. Please enter the standards in increasing order only"
                lblNote3.Text = "2. Please enter different standard names"
                lblNote3.Location = lblNote2.Location
                lblNote2.Location = lblNote1.Location
                lblNote1.Visible = False
                '--------------------------



            Else
                intTotalStd = 15
            End If

            For intCount = gobjNewMethod.StandardDataCollection.Count + 1 To intTotalStd
                Call subAddNewClicked(intCount)
            Next

            If IsInIQOQPQ Then
                Select Case mintIQOQPQtest
                    Case EnumIQOQPQtestId.ePQAtt1
                        If mobjDtStandards.Rows.Count > 0 Then
                            mobjDtStandards.Rows(0).Item(ConstColumnConcentration) = "5"
                        End If
                End Select

            End If

            '------------------------------------------------------------



            dgStdConcentration.Focus()
            mobjDtStandardsDataGrid.SetDataGridTableStyle.BeginEdit(dgStdConcentration.TableStyles.Item(0).GridColumnStyles(2), 0)
            ''setting grid property
            'Saurabh 10.07.07 To bring status form in front
            If Not IsInIQOQPQ Then
                gobjfrmStatus.Show()
                ''shows the status form
            End If
            'Saurabh
            btnChangeTiming.Visible = gstructAutoSampler.blnAutoSamplerInitialised 'Added by pankaj for autosampler
            ''validated change timing button as par autosampler
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

    Private Sub frmStandardConcentration_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        '=====================================================================
        ' Procedure Name        : frmStandardConcentration_Closing
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : to handle a closing event.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 05.10.06
        ' Revisions             : 2
        ' Revision By           : Mangesh S. on 28-Jan-2007
        ' Revision for          : Changes in AAS203Library
        '=====================================================================

        'when user close the form 

        If mblnIsCancel = True Then
            e.Cancel = mblnIsCancel
            mblnIsCancel = False
            Exit Sub
        End If
        gobjMain.ShowRunTimeInfo(gstrTitleInstrumentType & ConstParentFormLoad)
    End Sub

    Private Sub frmStandardConcentration_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        '=====================================================================
        ' Procedure Name        : frmStandardConcentration_Activated
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : to activated a form.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 05.10.06
        ' Revisions             : 2
        ' Revision By           : Mangesh S. on 28-Jan-2007
        ' Revision for          : Changes in AAS203Library
        '=====================================================================

        dgStdConcentration.Focus()
    End Sub

#End Region

#Region " Private Functions"

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
        ' Created               : 07.10.06
        ' Revisions             : 
        '=====================================================================
        Try
            ''this function is used for adding a event 
            AddHandler btnCancel.Click, AddressOf btnCancel_Click
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
        ' Author                : Deepak Bhati
        ' Created               : 05.10.06
        ' Revisions             : 
        '=====================================================================
        Try
            ''this is called when user click on cancel button
            gobjchkActiveMethod.CancelMethod = True 'Added By Pankaj 23 May 07
            mblnIsCancel = False
            Me.DialogResult = DialogResult.Cancel
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
        ' Author                : Deepak Bhati
        ' Created               : 05.10.06
        ' Revisions             : 
        '=====================================================================
        ''note:
        ''this is called when user click on OK button
        ''in this step1 is to check for validation
        ''step 2 get data enterd by user to temp varible
        ''step3 now check for validation and bound that data to data structure

        ''validation
        ''std name should be unique
        ''check contration range


        Dim objWait As New CWaitCursor
        Dim intCounter As Integer
        Dim dblConcentration As Double
        Dim objStandard As clsAnalysisStdParameters
        Dim objStandardCollection As clsAnalysisStdParametersCollection
        Dim blnDuplicateFound As Boolean = False
        Dim intCounter1 As Integer
        Dim strStdName As String
        Dim zeroFlag As Boolean = False
        Try
            '//-----  Added by Sachin Dokhale
            'Check for dublicate Standard name
            blnDuplicateFound = False
            For intCounter = 0 To mobjDtStandards.Rows.Count - 1
                strStdName = mobjDtStandards.Rows(intCounter).Item(1)
                For intCounter1 = intCounter + 1 To mobjDtStandards.Rows.Count - 1
                    If strStdName = mobjDtStandards.Rows(intCounter1).Item(1) Then
                        blnDuplicateFound = True
                        Exit For
                    End If
                Next

                If blnDuplicateFound = True Then
                    Exit For
                End If
            Next

            If blnDuplicateFound = True Then
                mblnIsCancel = True
                gobjMessageAdapter.ShowMessage("Duplicate standard name", "Standard name", MessageHandler.clsMessageHandler.enumMessageType.WarningMessage)
                Application.DoEvents()
                Exit Sub
            End If

            'validate entered concentration is numeric or not
            For intCounter = 0 To mobjDtStandards.Rows.Count - 1
                If Not gfuncIsDBNull_Ext(mobjDtStandards.Rows(intCounter).Item(ConstColumnConcentration)) = True Then
                    If Not IsNumeric(mobjDtStandards.Rows(intCounter).Item(ConstColumnConcentration)) = True Then
                        gobjMessageAdapter.ShowMessage("Please enter proper data", "Numeric data required", MessageHandler.clsMessageHandler.enumMessageType.WarningMessage)
                        Application.DoEvents()
                        Exit Sub
                    End If
                Else
                    'Added by pankaj on 17 Aug 07 for handling null exceptions
                    If (intCounter = 0) Then
                        gobjMessageAdapter.ShowMessage("Please enter data for first standard", "Numeric data required", MessageHandler.clsMessageHandler.enumMessageType.WarningMessage)
                        Application.DoEvents()
                        Exit Sub
                    End If
                    'end
                End If
            Next

            '//-----

            '----18.06.07
            '---Validate for First Blank (ZERO) Concentration
            If intCounter = 0 Then
                If gfuncIsDBNull_Ext(mobjDtStandards.Rows(0).Item(ConstColumnConcentration)) Then
                    mblnIsCancel = True
                    Call gobjMessageAdapter.ShowMessage(constEnterStdConc)
                    Call Application.DoEvents()
                    Exit Sub
                End If
            End If

            If Not gobjNewMethod.StandardAddition Then
                If Val(mobjDtStandards.Rows(0).Item(ConstColumnConcentration)) = 0.0 Then
                    mblnIsCancel = True
                    Call gobjMessageAdapter.ShowMessage(constFirstZeroStdConc)
                    Call Application.DoEvents()
                    Exit Sub
                End If
            End If

            objStandardCollection = New clsAnalysisStdParametersCollection
            'update objstandard object with standard concentrations values
            For intCounter = 0 To mobjDtStandards.Rows.Count - 1
                If Trim(mobjDtStandards.Rows(intCounter).Item(ConstColumnStandardName)) <> "" Then
                    If (Not gfuncIsDBNull_Ext(mobjDtStandards.Rows(intCounter).Item(ConstColumnConcentration))) And (Convert.ToString(mobjDtStandards.Rows(intCounter).Item(ConstColumnConcentration)) <> "") Then
                        If intCounter = 0 Then
                            objStandard = New clsAnalysisStdParameters
                            objStandard.StdNumber = CInt(mobjDtStandards.Rows(intCounter).Item(ConstColumnSrNo))
                            objStandard.StdName = CStr(mobjDtStandards.Rows(intCounter).Item(ConstColumnStandardName))
                            dblConcentration = CDbl(mobjDtStandards.Rows(intCounter).Item(ConstColumnConcentration))
                            If (gstructAutoSampler.blnAutoSamplerInitialised = True) Then ''by Pankaj for autosampler on 10Sep 07
                                If Not gfuncIsDBNull_Ext(mobjDtStandards.Rows(intCounter).Item(ConstColumnSamplerPos)) Then
                                    objStandard.PositionNumber = CInt(mobjDtStandards.Rows(intCounter).Item(ConstColumnSamplerPos))
                                Else
                                    objStandard.PositionNumber = 0
                                End If
                            End If
                        Else
                            objStandard = New clsAnalysisStdParameters
                            objStandard.StdNumber = CInt(mobjDtStandards.Rows(intCounter).Item(ConstColumnSrNo))
                            objStandard.StdName = CStr(mobjDtStandards.Rows(intCounter).Item(ConstColumnStandardName))
                            If (gstructAutoSampler.blnAutoSamplerInitialised = True) Then 'by Pankaj for autosampler on 10Sep 07
                                If Not gfuncIsDBNull_Ext(mobjDtStandards.Rows(intCounter).Item(ConstColumnSamplerPos)) Then
                                    objStandard.PositionNumber = CInt(mobjDtStandards.Rows(intCounter).Item(ConstColumnSamplerPos))
                                Else
                                    objStandard.PositionNumber = 0
                                End If
                            End If
                            'Added by pankaj on 21 Jan 08
                            If zeroFlag = True And CDbl(mobjDtStandards.Rows(intCounter).Item(ConstColumnConcentration)) <> 0 Then
                                gobjMessageAdapter.ShowMessage(constStdsInIncreasingOrder)
                                Exit Sub
                            End If
                            If CDbl(mobjDtStandards.Rows(intCounter).Item(ConstColumnConcentration)) = 0 Then
                                zeroFlag = True
                            End If
                            '---for ignore zero values
                            '--------------To check the increasing order of standards-----------
                            If zeroFlag = False Then
                                If dblConcentration >= CDbl(mobjDtStandards.Rows(intCounter).Item(ConstColumnConcentration)) Then
                                    mblnIsCancel = True
                                    gobjMessageAdapter.ShowMessage(constStdsInIncreasingOrder)
                                    Exit Sub
                                End If
                                dblConcentration = Val(mobjDtStandards.Rows(intCounter).Item(ConstColumnConcentration))
                            End If
                        End If

                        If zeroFlag = False Then 'by pankaj on 21 Jan 08
                            objStandard.Concentration = mobjDtStandards.Rows(intCounter).Item(ConstColumnConcentration)
                            objStandardCollection.Add(objStandard)
                        End If

                    End If
                End If
            Next
            '------------Added By Pankaj on 11 Jun 07
            For intCounter = 0 To gobjNewMethod.StandardDataCollection.Count - 1
                If gobjNewMethod.StandardDataCollection.Count > intCounter Then
                    If gobjNewMethod.StandardDataCollection.item(intCounter).Used = True Then
                        objStandardCollection.item(intCounter).Used = True
                        objStandardCollection.item(intCounter).Abs = gobjNewMethod.StandardDataCollection.item(intCounter).Abs
                    End If
                End If
            Next
            '-----------
            gobjNewMethod.StandardDataCollection.Clear()
            gobjNewMethod.StandardDataCollection = objStandardCollection.Clone()

            '---Update Current Method in Method Collection
            For intCounter = 0 To gobjMethodCollection.Count - 1
                If gobjMethodCollection.item(intCounter).MethodID = gobjNewMethod.MethodID Then
                    gobjMethodCollection.item(intCounter).StandardDataCollection = gobjNewMethod.StandardDataCollection.Clone()
                    gobjMethodCollection.item(intCounter).DateOfModification = DateTime.Now
                End If
            Next

            '---serialize method collection 
            'Added By Pankaj on 23 May 07 for adding method of inactive mode
            gobjchkActiveMethod.fillStdConcentration = True
            '27.07.07
            If (gobjchkActiveMethod.fillStdConcentration = True And gobjchkActiveMethod.CancelMethod = True And gobjchkActiveMethod.NewMethod = True) Then
                gobjchkActiveMethod.NewMethod = False
                gobjchkActiveMethod.CancelMethod = False
                gobjchkActiveMethod.fillStdConcentration = False
                gobjNewMethod.Status = True
                gobjchkActiveMethod.IsMethodAddedToCollectionInDisconnectedMode = True
                gobjMethodCollection.Add(gobjNewMethod)
            End If
            Call funcSaveAllMethods(gobjMethodCollection)

            ''save method with current value and data 

            Me.DialogResult = DialogResult.OK
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
            objWait.Dispose()
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub subAddNewClicked(ByVal intCount As Integer)
        '=====================================================================
        ' Procedure Name        : subAddNewClicked
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To add new Standard
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : Monday, December 13, 2004
        ' Revisions             : 08.10.06
        '=====================================================================
        Dim objDrNewRow As DataRow

        ''note:
        ''this is used for adding new std 
        ''step 1: check for validation 
        ''step 2: modify data structure for adding new std


        Try
            btnOk.Enabled = True
            objDrNewRow = mobjDtStandards.NewRow
            mobjDtStandards.Constraints.Clear()
            objDrNewRow = mobjDtStandards.NewRow
            objDrNewRow.Item(ConstColumnSrNo) = intCount
            objDrNewRow.Item(ConstColumnStandardName) = "Std " & intCount
            objDrNewRow.Item(ConstColumnConcentration) = DBNull.Value
            If (gstructAutoSampler.blnAutoSamplerInitialised = True) Then 'by Pankaj for autosampler on 10Sep 07
                objDrNewRow.Item(ConstColumnSamplerPos) = intCount
            End If
            mobjDtStandards.Rows.Add(objDrNewRow)

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

    Private Function funcLoadInitialData() As Boolean
        '=====================================================================
        ' Procedure Name        : funcLoadInitialData
        ' Parameters Passed     : None
        ' Returns               : True or False
        ' Purpose               : To load initial data
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 08.10.06
        ' Revisions             : 2
        ' Revision By           : Mangesh S. on 28-Jan-2007
        ' Revision for          : Changes in AAS203Library
        '=====================================================================
        Dim intCounter As Integer
        Dim objRow As DataRow
        ''note:
        ''this called during loading of the form.
        ''this used to load some initial data on screen.
        ''this will load to data from data structure.


        Try
            '18.06.07
            If Not gobjNewMethod.StandardDataCollection Is Nothing Then
                For intCounter = 0 To gobjNewMethod.StandardDataCollection.Count - 1
                    If Not gobjNewMethod.StandardDataCollection.item(intCounter) Is Nothing Then
                        objRow = mobjDtStandards.NewRow
                        objRow.Item(ConstColumnSrNo) = gobjNewMethod.StandardDataCollection.item(intCounter).StdNumber
                        objRow.Item(ConstColumnStandardName) = gobjNewMethod.StandardDataCollection.item(intCounter).StdName
                        If gobjNewMethod.StandardDataCollection.item(intCounter).Concentration = 0.0 Then
                            objRow.Item(ConstColumnConcentration) = FormatNumber(0, 6)
                        Else
                            objRow.Item(ConstColumnConcentration) = FormatNumber(gobjNewMethod.StandardDataCollection.item(intCounter).Concentration, 6)
                        End If
                        If (gstructAutoSampler.blnAutoSamplerInitialised = True) Then
                            If (gobjNewMethod.StandardDataCollection.item(intCounter).PositionNumber = -1) Then
                                objRow.Item(ConstColumnSamplerPos) = gobjNewMethod.StandardDataCollection.item(intCounter).StdNumber
                            Else
                                objRow.Item(ConstColumnSamplerPos) = gobjNewMethod.StandardDataCollection.item(intCounter).PositionNumber
                            End If
                        End If
                        mobjDtStandards.Rows.Add(objRow)
                    End If
                Next
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

    Private Sub dgStdConcentration_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgStdConcentration.CurrentCellChanged
        '=====================================================================
        ' Procedure Name        : dgStdConcentration_CurrentCellChanged
        ' Parameters Passed     : Object, EventArgs
        ' Returns               : True or False
        ' Purpose               : check validation for new enterd value
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 08.10.06
        ' Revisions             : 2
        ' Revision By           : Mangesh S. on 28-Jan-2007
        ' Revision for          : Changes in AAS203Library
        '=====================================================================
        ''note:
        ''this called when user change or edit a current cell
        ''check validation for new enterd value
        ''if validated then accept it and modify the data structure

        Try
            If (dgStdConcentration.CurrentCell.ColumnNumber = 2) Then
                'If Not IsDBNull(dgStdConcentration.Item(intGridRowNo, 2)) Then
                If Not gfuncIsDBNull_Ext(dgStdConcentration.Item(intGridRowNo, 2)) Then
                    If Convert.ToString(dgStdConcentration.Item(intGridRowNo, 2)) = "" Then
                        dgStdConcentration.Item(intGridRowNo, 2) = DBNull.Value
                    ElseIf Not IsNumeric(dgStdConcentration.Item(intGridRowNo, 2)) Then
                        dgStdConcentration.Item(intGridRowNo, 2) = DBNull.Value
                    End If
                End If
            End If
            intGridRowNo = dgStdConcentration.CurrentRowIndex

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

    Private Sub dgStdConcentration_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgStdConcentration.LostFocus
        '=====================================================================
        ' Procedure Name        : dgStdConcentration_LostFocus
        ' Parameters Passed     : Object, EventArgs
        ' Returns               : True or False
        ' Purpose               : for handle a LostFocus Event.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 08.10.06
        ' Revisions             : 2
        ' Revision By           : Mangesh S. on 28-Jan-2007
        ' Revision for          : Changes in AAS203Library
        '=====================================================================
        'validate entered value of current cell
        dgStdConcentration_CurrentCellChanged(sender, e)
    End Sub

    Private Sub btnChangeTiming_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChangeTiming.Click
        '=====================================================================
        ' Procedure Name        : btnChangeTiming_Click
        ' Parameters Passed     : Object, EventArgs
        ' Returns               : True or False
        ' Purpose               : show change timing form
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 08.10.06
        ' Revisions             : 2
        ' Revision By           : Mangesh S. on 28-Jan-2007
        ' Revision for          : Changes in AAS203Library
        '=====================================================================
        ''note:
        ''this is called when user clicked on change timing button
        ''this will set a autosampler flag 
        ''and show change timing form.

        Try
            If (gstructAutoSampler.blnCommunication = True) Then
                Dim objfrmtimings As New frmTimings
                objfrmtimings.ShowDialog()
                ''show a dialog.
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
