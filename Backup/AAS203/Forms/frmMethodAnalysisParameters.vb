Imports AAS203.Common
Imports AAS203Library.Method
''this is a supporting files like header files
Public Class frmMethodAnalysisParameters ''class behind the form
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    Public Sub New(ByVal intMethodMode As Integer, Optional ByVal intNoOfSamples As Integer = 0)

        'constructor modified by ;dinesh on 2.2.2010
        'Purpose to set the noOf samples.

        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        OpenMethodMode = intMethodMode

        mintNoOfSamples = intNoOfSamples 'added by ; dinesh wagh on 2.2.2010
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
    Friend WithEvents CustomPanelRightBottom As GradientPanel.CustomPanel
    Friend WithEvents CustomPanelLeft As GradientPanel.CustomPanel
    Friend WithEvents CustomPanelBottom As GradientPanel.CustomPanel
    Friend WithEvents btnHelp As NETXP.Controls.XPButton
    Friend WithEvents btnOk As NETXP.Controls.XPButton
    Friend WithEvents btnCancel As NETXP.Controls.XPButton
    Friend WithEvents CustomPanelTop As GradientPanel.CustomPanel
    Friend WithEvents Office2003Header1 As CodeIntellects.Office2003Controls.Office2003Header
    Friend WithEvents lblAnalystName As System.Windows.Forms.Label
    Friend WithEvents lblLabName As System.Windows.Forms.Label
    Friend WithEvents gbMeasurementMode As System.Windows.Forms.GroupBox
    Friend WithEvents lblIntegrationTime As System.Windows.Forms.Label
    Friend WithEvents lblNumofSamples As System.Windows.Forms.Label
    Friend WithEvents lblNumofSampRepeat As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents gbUnit As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblMethodInformation As System.Windows.Forms.Label
    Friend WithEvents chkBlankAfter As System.Windows.Forms.CheckBox
    Friend WithEvents nudNumDecimalPlaces As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudNumStdRepeat As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudNumSampRepeat As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudNumofSamples As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudIntegrationTime As System.Windows.Forms.NumericUpDown
    Friend WithEvents cmbUnits As System.Windows.Forms.ComboBox
    Friend WithEvents cmbMeasurementMode As System.Windows.Forms.ComboBox
    Friend WithEvents txtAnalystName As NumberValidator.NumberValidator
    Friend WithEvents txtLabName As NumberValidator.NumberValidator
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMethodAnalysisParameters))
        Me.CustomPanelMain = New GradientPanel.CustomPanel
        Me.CustomPanelRightBottom = New GradientPanel.CustomPanel
        Me.gbUnit = New System.Windows.Forms.GroupBox
        Me.cmbUnits = New System.Windows.Forms.ComboBox
        Me.gbMeasurementMode = New System.Windows.Forms.GroupBox
        Me.cmbMeasurementMode = New System.Windows.Forms.ComboBox
        Me.chkBlankAfter = New System.Windows.Forms.CheckBox
        Me.CustomPanelLeft = New GradientPanel.CustomPanel
        Me.Label6 = New System.Windows.Forms.Label
        Me.nudNumDecimalPlaces = New System.Windows.Forms.NumericUpDown
        Me.lblMethodInformation = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.nudNumStdRepeat = New System.Windows.Forms.NumericUpDown
        Me.nudNumSampRepeat = New System.Windows.Forms.NumericUpDown
        Me.nudNumofSamples = New System.Windows.Forms.NumericUpDown
        Me.nudIntegrationTime = New System.Windows.Forms.NumericUpDown
        Me.Label4 = New System.Windows.Forms.Label
        Me.lblNumofSampRepeat = New System.Windows.Forms.Label
        Me.lblNumofSamples = New System.Windows.Forms.Label
        Me.lblIntegrationTime = New System.Windows.Forms.Label
        Me.CustomPanelBottom = New GradientPanel.CustomPanel
        Me.btnOk = New NETXP.Controls.XPButton
        Me.btnCancel = New NETXP.Controls.XPButton
        Me.btnHelp = New NETXP.Controls.XPButton
        Me.CustomPanelTop = New GradientPanel.CustomPanel
        Me.txtLabName = New NumberValidator.NumberValidator
        Me.txtAnalystName = New NumberValidator.NumberValidator
        Me.lblLabName = New System.Windows.Forms.Label
        Me.lblAnalystName = New System.Windows.Forms.Label
        Me.Office2003Header1 = New CodeIntellects.Office2003Controls.Office2003Header
        Me.CustomPanelMain.SuspendLayout()
        Me.CustomPanelRightBottom.SuspendLayout()
        Me.gbUnit.SuspendLayout()
        Me.gbMeasurementMode.SuspendLayout()
        Me.CustomPanelLeft.SuspendLayout()
        CType(Me.nudNumDecimalPlaces, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudNumStdRepeat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudNumSampRepeat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudNumofSamples, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudIntegrationTime, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CustomPanelBottom.SuspendLayout()
        Me.CustomPanelTop.SuspendLayout()
        Me.SuspendLayout()
        '
        'CustomPanelMain
        '
        Me.CustomPanelMain.BackColor = System.Drawing.Color.AliceBlue
        Me.CustomPanelMain.BackColor2 = System.Drawing.Color.AliceBlue
        Me.CustomPanelMain.Controls.Add(Me.CustomPanelRightBottom)
        Me.CustomPanelMain.Controls.Add(Me.CustomPanelLeft)
        Me.CustomPanelMain.Controls.Add(Me.CustomPanelBottom)
        Me.CustomPanelMain.Controls.Add(Me.CustomPanelTop)
        Me.CustomPanelMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CustomPanelMain.Location = New System.Drawing.Point(0, 22)
        Me.CustomPanelMain.Name = "CustomPanelMain"
        Me.CustomPanelMain.Size = New System.Drawing.Size(552, 367)
        Me.CustomPanelMain.TabIndex = 12
        '
        'CustomPanelRightBottom
        '
        Me.CustomPanelRightBottom.BackColor = System.Drawing.Color.Transparent
        Me.CustomPanelRightBottom.BackColor2 = System.Drawing.Color.Transparent
        Me.CustomPanelRightBottom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CustomPanelRightBottom.Controls.Add(Me.gbUnit)
        Me.CustomPanelRightBottom.Controls.Add(Me.gbMeasurementMode)
        Me.CustomPanelRightBottom.Controls.Add(Me.chkBlankAfter)
        Me.CustomPanelRightBottom.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CustomPanelRightBottom.Location = New System.Drawing.Point(280, 72)
        Me.CustomPanelRightBottom.Name = "CustomPanelRightBottom"
        Me.CustomPanelRightBottom.Size = New System.Drawing.Size(272, 223)
        Me.CustomPanelRightBottom.TabIndex = 2
        '
        'gbUnit
        '
        Me.gbUnit.Controls.Add(Me.cmbUnits)
        Me.gbUnit.Location = New System.Drawing.Point(8, 16)
        Me.gbUnit.Name = "gbUnit"
        Me.gbUnit.Size = New System.Drawing.Size(256, 56)
        Me.gbUnit.TabIndex = 0
        Me.gbUnit.TabStop = False
        Me.gbUnit.Text = "Unit for Results"
        '
        'cmbUnits
        '
        Me.cmbUnits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUnits.Location = New System.Drawing.Point(40, 24)
        Me.cmbUnits.Name = "cmbUnits"
        Me.cmbUnits.Size = New System.Drawing.Size(168, 23)
        Me.cmbUnits.TabIndex = 0
        '
        'gbMeasurementMode
        '
        Me.gbMeasurementMode.Controls.Add(Me.cmbMeasurementMode)
        Me.gbMeasurementMode.Location = New System.Drawing.Point(8, 82)
        Me.gbMeasurementMode.Name = "gbMeasurementMode"
        Me.gbMeasurementMode.Size = New System.Drawing.Size(256, 62)
        Me.gbMeasurementMode.TabIndex = 1
        Me.gbMeasurementMode.TabStop = False
        Me.gbMeasurementMode.Text = "Measurement Mode"
        '
        'cmbMeasurementMode
        '
        Me.cmbMeasurementMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMeasurementMode.Location = New System.Drawing.Point(40, 24)
        Me.cmbMeasurementMode.Name = "cmbMeasurementMode"
        Me.cmbMeasurementMode.Size = New System.Drawing.Size(168, 23)
        Me.cmbMeasurementMode.TabIndex = 0
        '
        'chkBlankAfter
        '
        Me.chkBlankAfter.Location = New System.Drawing.Point(24, 158)
        Me.chkBlankAfter.Name = "chkBlankAfter"
        Me.chkBlankAfter.Size = New System.Drawing.Size(192, 24)
        Me.chkBlankAfter.TabIndex = 2
        Me.chkBlankAfter.Text = "Blank After Every Sample/Std"
        '
        'CustomPanelLeft
        '
        Me.CustomPanelLeft.BackColor = System.Drawing.Color.Transparent
        Me.CustomPanelLeft.BackColor2 = System.Drawing.Color.Transparent
        Me.CustomPanelLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CustomPanelLeft.Controls.Add(Me.Label6)
        Me.CustomPanelLeft.Controls.Add(Me.nudNumDecimalPlaces)
        Me.CustomPanelLeft.Controls.Add(Me.lblMethodInformation)
        Me.CustomPanelLeft.Controls.Add(Me.Label5)
        Me.CustomPanelLeft.Controls.Add(Me.Label3)
        Me.CustomPanelLeft.Controls.Add(Me.Label1)
        Me.CustomPanelLeft.Controls.Add(Me.Label2)
        Me.CustomPanelLeft.Controls.Add(Me.nudNumStdRepeat)
        Me.CustomPanelLeft.Controls.Add(Me.nudNumSampRepeat)
        Me.CustomPanelLeft.Controls.Add(Me.nudNumofSamples)
        Me.CustomPanelLeft.Controls.Add(Me.nudIntegrationTime)
        Me.CustomPanelLeft.Controls.Add(Me.Label4)
        Me.CustomPanelLeft.Controls.Add(Me.lblNumofSampRepeat)
        Me.CustomPanelLeft.Controls.Add(Me.lblNumofSamples)
        Me.CustomPanelLeft.Controls.Add(Me.lblIntegrationTime)
        Me.CustomPanelLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.CustomPanelLeft.Location = New System.Drawing.Point(0, 72)
        Me.CustomPanelLeft.Name = "CustomPanelLeft"
        Me.CustomPanelLeft.Size = New System.Drawing.Size(280, 223)
        Me.CustomPanelLeft.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.Enabled = False
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(221, 161)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 18)
        Me.Label6.TabIndex = 32
        Me.Label6.Text = "0..8 only"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'nudNumDecimalPlaces
        '
        Me.nudNumDecimalPlaces.Location = New System.Drawing.Point(164, 160)
        Me.nudNumDecimalPlaces.Maximum = New Decimal(New Integer() {8, 0, 0, 0})
        Me.nudNumDecimalPlaces.Name = "nudNumDecimalPlaces"
        Me.nudNumDecimalPlaces.Size = New System.Drawing.Size(52, 21)
        Me.nudNumDecimalPlaces.TabIndex = 4
        '
        'lblMethodInformation
        '
        Me.lblMethodInformation.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMethodInformation.Location = New System.Drawing.Point(9, 161)
        Me.lblMethodInformation.Name = "lblMethodInformation"
        Me.lblMethodInformation.Size = New System.Drawing.Size(156, 16)
        Me.lblMethodInformation.TabIndex = 30
        Me.lblMethodInformation.Text = "No. of decimal places"
        '
        'Label5
        '
        Me.Label5.Enabled = False
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(219, 128)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 18)
        Me.Label5.TabIndex = 29
        Me.Label5.Text = "1..15 only"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Enabled = False
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(219, 93)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 18)
        Me.Label3.TabIndex = 28
        Me.Label3.Text = "1..15 only"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Enabled = False
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(219, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 18)
        Me.Label1.TabIndex = 27
        Me.Label1.Text = "1..200 "
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Enabled = False
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(217, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 18)
        Me.Label2.TabIndex = 26
        Me.Label2.Text = "1..99 sec"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'nudNumStdRepeat
        '
        Me.nudNumStdRepeat.Location = New System.Drawing.Point(165, 128)
        Me.nudNumStdRepeat.Maximum = New Decimal(New Integer() {15, 0, 0, 0})
        Me.nudNumStdRepeat.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudNumStdRepeat.Name = "nudNumStdRepeat"
        Me.nudNumStdRepeat.Size = New System.Drawing.Size(51, 21)
        Me.nudNumStdRepeat.TabIndex = 3
        Me.nudNumStdRepeat.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'nudNumSampRepeat
        '
        Me.nudNumSampRepeat.Location = New System.Drawing.Point(165, 91)
        Me.nudNumSampRepeat.Maximum = New Decimal(New Integer() {15, 0, 0, 0})
        Me.nudNumSampRepeat.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudNumSampRepeat.Name = "nudNumSampRepeat"
        Me.nudNumSampRepeat.Size = New System.Drawing.Size(51, 21)
        Me.nudNumSampRepeat.TabIndex = 2
        Me.nudNumSampRepeat.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'nudNumofSamples
        '
        Me.nudNumofSamples.Location = New System.Drawing.Point(165, 56)
        Me.nudNumofSamples.Maximum = New Decimal(New Integer() {200, 0, 0, 0})
        Me.nudNumofSamples.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudNumofSamples.Name = "nudNumofSamples"
        Me.nudNumofSamples.Size = New System.Drawing.Size(51, 21)
        Me.nudNumofSamples.TabIndex = 1
        Me.nudNumofSamples.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'nudIntegrationTime
        '
        Me.nudIntegrationTime.Location = New System.Drawing.Point(165, 16)
        Me.nudIntegrationTime.Maximum = New Decimal(New Integer() {99, 0, 0, 0})
        Me.nudIntegrationTime.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudIntegrationTime.Name = "nudIntegrationTime"
        Me.nudIntegrationTime.Size = New System.Drawing.Size(51, 21)
        Me.nudIntegrationTime.TabIndex = 0
        Me.nudIntegrationTime.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(8, 127)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(152, 16)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "No. of STD Repeats"
        '
        'lblNumofSampRepeat
        '
        Me.lblNumofSampRepeat.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumofSampRepeat.Location = New System.Drawing.Point(8, 90)
        Me.lblNumofSampRepeat.Name = "lblNumofSampRepeat"
        Me.lblNumofSampRepeat.Size = New System.Drawing.Size(152, 16)
        Me.lblNumofSampRepeat.TabIndex = 8
        Me.lblNumofSampRepeat.Text = "No. of Samp Repeats"
        '
        'lblNumofSamples
        '
        Me.lblNumofSamples.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumofSamples.Location = New System.Drawing.Point(8, 53)
        Me.lblNumofSamples.Name = "lblNumofSamples"
        Me.lblNumofSamples.Size = New System.Drawing.Size(152, 16)
        Me.lblNumofSamples.TabIndex = 7
        Me.lblNumofSamples.Text = "No. of Samples"
        '
        'lblIntegrationTime
        '
        Me.lblIntegrationTime.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIntegrationTime.Location = New System.Drawing.Point(8, 16)
        Me.lblIntegrationTime.Name = "lblIntegrationTime"
        Me.lblIntegrationTime.Size = New System.Drawing.Size(152, 16)
        Me.lblIntegrationTime.TabIndex = 6
        Me.lblIntegrationTime.Text = "Integration Time"
        '
        'CustomPanelBottom
        '
        Me.CustomPanelBottom.BackColor = System.Drawing.Color.Transparent
        Me.CustomPanelBottom.BackColor2 = System.Drawing.Color.Transparent
        Me.CustomPanelBottom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CustomPanelBottom.Controls.Add(Me.btnOk)
        Me.CustomPanelBottom.Controls.Add(Me.btnCancel)
        Me.CustomPanelBottom.Controls.Add(Me.btnHelp)
        Me.CustomPanelBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.CustomPanelBottom.Location = New System.Drawing.Point(0, 295)
        Me.CustomPanelBottom.Name = "CustomPanelBottom"
        Me.CustomPanelBottom.Size = New System.Drawing.Size(552, 72)
        Me.CustomPanelBottom.TabIndex = 3
        '
        'btnOk
        '
        Me.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOk.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOk.Image = CType(resources.GetObject("btnOk.Image"), System.Drawing.Image)
        Me.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnOk.Location = New System.Drawing.Point(360, 24)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(86, 34)
        Me.btnOk.TabIndex = 0
        Me.btnOk.Text = "&OK"
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Image = CType(resources.GetObject("btnCancel.Image"), System.Drawing.Image)
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancel.Location = New System.Drawing.Point(456, 24)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(86, 34)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "&Cancel"
        '
        'btnHelp
        '
        Me.btnHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnHelp.Image = CType(resources.GetObject("btnHelp.Image"), System.Drawing.Image)
        Me.btnHelp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnHelp.Location = New System.Drawing.Point(456, 48)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(86, 34)
        Me.btnHelp.TabIndex = 13
        Me.btnHelp.Text = "Help"
        Me.btnHelp.Visible = False
        '
        'CustomPanelTop
        '
        Me.CustomPanelTop.BackColor = System.Drawing.Color.Transparent
        Me.CustomPanelTop.BackColor2 = System.Drawing.Color.Transparent
        Me.CustomPanelTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CustomPanelTop.Controls.Add(Me.txtLabName)
        Me.CustomPanelTop.Controls.Add(Me.txtAnalystName)
        Me.CustomPanelTop.Controls.Add(Me.lblLabName)
        Me.CustomPanelTop.Controls.Add(Me.lblAnalystName)
        Me.CustomPanelTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.CustomPanelTop.Location = New System.Drawing.Point(0, 0)
        Me.CustomPanelTop.Name = "CustomPanelTop"
        Me.CustomPanelTop.Size = New System.Drawing.Size(552, 72)
        Me.CustomPanelTop.TabIndex = 0
        '
        'txtLabName
        '
        Me.txtLabName.DigitsAfterDecimalPoint = 0
        Me.txtLabName.ErrorColor = System.Drawing.Color.Empty
        Me.txtLabName.ErrorMessage = Nothing
        Me.txtLabName.Location = New System.Drawing.Point(168, 40)
        Me.txtLabName.MaximumRange = 0
        Me.txtLabName.MaxLength = 80
        Me.txtLabName.MinimumRange = 0
        Me.txtLabName.Name = "txtLabName"
        Me.txtLabName.RangeValidation = False
        Me.txtLabName.Size = New System.Drawing.Size(328, 21)
        Me.txtLabName.TabIndex = 1
        Me.txtLabName.Text = ""
        Me.txtLabName.ValidationType = NumberValidator.NumberValidator.Validations.AlphaNumeric
        '
        'txtAnalystName
        '
        Me.txtAnalystName.DigitsAfterDecimalPoint = 0
        Me.txtAnalystName.ErrorColor = System.Drawing.Color.Empty
        Me.txtAnalystName.ErrorMessage = Nothing
        Me.txtAnalystName.Location = New System.Drawing.Point(168, 8)
        Me.txtAnalystName.MaximumRange = 0
        Me.txtAnalystName.MaxLength = 40
        Me.txtAnalystName.MinimumRange = 0
        Me.txtAnalystName.Name = "txtAnalystName"
        Me.txtAnalystName.RangeValidation = False
        Me.txtAnalystName.Size = New System.Drawing.Size(248, 21)
        Me.txtAnalystName.TabIndex = 0
        Me.txtAnalystName.Text = ""
        Me.txtAnalystName.ValidationType = NumberValidator.NumberValidator.Validations.AlphaNumeric
        '
        'lblLabName
        '
        Me.lblLabName.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLabName.Location = New System.Drawing.Point(8, 41)
        Me.lblLabName.Name = "lblLabName"
        Me.lblLabName.Size = New System.Drawing.Size(152, 16)
        Me.lblLabName.TabIndex = 14
        Me.lblLabName.Text = "Laboratory Name"
        '
        'lblAnalystName
        '
        Me.lblAnalystName.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAnalystName.Location = New System.Drawing.Point(8, 8)
        Me.lblAnalystName.Name = "lblAnalystName"
        Me.lblAnalystName.Size = New System.Drawing.Size(152, 16)
        Me.lblAnalystName.TabIndex = 12
        Me.lblAnalystName.Text = "Name of the Analyst"
        '
        'Office2003Header1
        '
        Me.Office2003Header1.BackColor = System.Drawing.SystemColors.Control
        Me.Office2003Header1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Office2003Header1.Location = New System.Drawing.Point(0, 0)
        Me.Office2003Header1.Name = "Office2003Header1"
        Me.Office2003Header1.Size = New System.Drawing.Size(552, 22)
        Me.Office2003Header1.TabIndex = 13
        Me.Office2003Header1.TitleFont = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Office2003Header1.TitleText = "Analysis Parameters"
        '
        'frmMethodAnalysisParameters
        '
        Me.AcceptButton = Me.btnOk
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(552, 389)
        Me.ControlBox = False
        Me.Controls.Add(Me.CustomPanelMain)
        Me.Controls.Add(Me.Office2003Header1)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMethodAnalysisParameters"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Method "
        Me.CustomPanelMain.ResumeLayout(False)
        Me.CustomPanelRightBottom.ResumeLayout(False)
        Me.gbUnit.ResumeLayout(False)
        Me.gbMeasurementMode.ResumeLayout(False)
        Me.CustomPanelLeft.ResumeLayout(False)
        CType(Me.nudNumDecimalPlaces, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudNumStdRepeat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudNumSampRepeat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudNumofSamples, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudIntegrationTime, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CustomPanelBottom.ResumeLayout(False)
        Me.CustomPanelTop.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Class Member Variables "

    Private mintOpenMethodMode As Integer
    Private mintNoOfSamples As Integer 'by dinesh wagh on 2.2.2010

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

#Region " Private Constants"

    Private Const ConstDefaultNoOfDecimalPlaces As Integer = 2
    '+ Added by Amit 26/03/09 ################################################
    Private Const ConstDefaultNoOfDecimalPlacesPPB As Integer = 4
    '- Added by Amit 26/03/09 ################################################
    Private Const ConstDefaultNoOfSamples As Integer = 25
    Private Const ConstDefaultIntegrationTime As Integer = 3
    Private Const ConstParentFormLoad = "-Method"
    Private Const ConstFormLoad = "-Method-AnalysisParameters "

#End Region

#Region " Form Load and Events Handling functions "

    Private Sub frmMethodAnalysisParameters_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '=====================================================================
        ' Procedure Name        : frmMethodAnalysisParameters_Load
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To initialize and load the form
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 28.07.07
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        ''note:
        ''this is called when form is loaded
        ''this call two function
        ''for initialization and for adding all the event.

        Try
            gobjMain.ShowProgressBar(gstrTitleInstrumentType & ConstFormLoad)
            funcLoadInitialData()
            ''for load initial data 
            'that methos info and other
            AddHandlers()
            ''add a event to a control
            btnOk.Focus()
            If Not IsInIQOQPQ Then
                gobjfrmStatus.Show()
                ''show the status form
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
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            gobjMain.HideProgressBar()
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub frmMethodAnalysisParameters_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        '=====================================================================
        ' Procedure Name        : frmMethodAnalysisParameters_Closing
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               :  this is called when user closed the form
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 07.09.06
        ' Revisions             : 
        '=====================================================================
        ''this is called when user closed the form
        Try
            gobjMain.ShowRunTimeInfo(gstrTitleInstrumentType & ConstParentFormLoad)
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

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : btnCancel_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To send dialog result as cancel
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 07.09.06
        ' Revisions             : 
        '=====================================================================

        ''note:
        '' this is called when user click on cancel button

        Try
            If OpenMethodMode = modGlobalConstants.EnumMethodMode.NewMode Then
                ''check for new method cond

                If Not gobjNewMethod.AnalysisParameters Is Nothing Then
                    gobjNewMethod.AnalysisParameters = Nothing
                End If
            End If
            'gobjchkActiveMethod.CancelMethod = True 'Added By Pankaj 23 May 07 
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

    Public Function updateSampleParameter(ByVal intNoOfSamples As Integer, ByVal intUnitID As Integer, Optional ByVal blnIsDelete As Boolean = False)
        '=====================================================================
        ' Procedure Name        : updateSampleParameter
        ' Parameters Passed     : 
        ' Returns               : None
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Pankaj Bamb 
        ' Created               : 29.05.07
        ' Revisions             : Deepak on 28.07.07
        '=====================================================================
        ''note:
        ''this is used to update the sampler parameter
        ''like how many sampler is being used
        ''make a data structure for storing sampler no ,sampler name 
        ''whatever it is repeated or not.
        ''get a input ,no of sampler from user and save it to data structure



        Try
            Dim objClsSampleParameters As clsAnalysisSampleParameters
            Dim objSamplesCollection As clsAnalysisSampleParametersCollection
            ''this is  a object ot samplere data structure
            Dim i As Integer

            objSamplesCollection = New clsAnalysisSampleParametersCollection

            If Not gobjNewMethod.SampleDataCollection Is Nothing Then
                For i = 0 To intNoOfSamples - 1
                    ''loop for a no of sample present
                    objClsSampleParameters = New clsAnalysisSampleParameters
                    If gobjNewMethod.SampleDataCollection.Count > i Then
                        If Not gobjNewMethod.SampleDataCollection.item(i) Is Nothing Then
                            objClsSampleParameters.SampNumber = gobjNewMethod.SampleDataCollection.item(i).SampNumber
                            objClsSampleParameters.SampleName = gobjNewMethod.SampleDataCollection.item(i).SampleName
                            If blnIsDelete = True Then
                                objClsSampleParameters.Weight = 1.0
                                If (intUnitID = 1) Then
                                    objClsSampleParameters.Volume = 1
                                Else
                                    'objClsSampleParameters.Volume = 100
                                    '---changed as per document recived from app. lab on 30.01.09
                                    objClsSampleParameters.Volume = 1
                                End If
                            Else
                                objClsSampleParameters.Weight = gobjNewMethod.SampleDataCollection.item(i).Weight
                                objClsSampleParameters.Volume = gobjNewMethod.SampleDataCollection.item(i).Volume
                            End If
                        End If
                    Else
                        objClsSampleParameters.SampNumber = i + 1
                        objClsSampleParameters.SampleName = "Sample " & i + 1
                        objClsSampleParameters.Weight = 1.0
                        If (intUnitID = 1) Then
                            objClsSampleParameters.Volume = 1
                        Else
                            'objClsSampleParameters.Volume = 100
                            '---changed as per document received from app.lab on 30.01.09
                            objClsSampleParameters.Volume = 1
                        End If
                    End If
                    'update sample parameters
                    If gobjNewMethod.SampleDataCollection.Count > i Then
                        If Not gobjNewMethod.SampleDataCollection.item(i) Is Nothing Then
                            objClsSampleParameters.Abs = gobjNewMethod.SampleDataCollection.item(i).Abs
                            objClsSampleParameters.AbsRepeat = gobjNewMethod.SampleDataCollection.item(i).AbsRepeat
                            objClsSampleParameters.Conc = gobjNewMethod.SampleDataCollection.item(i).Conc
                            objClsSampleParameters.Used = gobjNewMethod.SampleDataCollection.item(i).Used
                            If blnIsDelete = True Then
                                objClsSampleParameters.DilutionFactor = 1.0
                            Else
                                objClsSampleParameters.DilutionFactor = gobjNewMethod.SampleDataCollection.item(i).DilutionFactor
                            End If
                        End If
                    Else
                        objClsSampleParameters.DilutionFactor = 1.0
                    End If
                    objSamplesCollection.Add(objClsSampleParameters)
                Next
            Else
                For i = 0 To intNoOfSamples - 1
                    objClsSampleParameters = New clsAnalysisSampleParameters
                    objClsSampleParameters.SampNumber = i + 1
                    objClsSampleParameters.SampleName = "Sample " & i + 1
                    objClsSampleParameters.Weight = 1
                    If (intUnitID = 1) Then
                        objClsSampleParameters.Volume = 1
                    Else
                        'objClsSampleParameters.Volume = 100
                        '---changed as per document recived from app. lab on 30.01.09
                        objClsSampleParameters.Volume = 1
                    End If
                    objClsSampleParameters.DilutionFactor = 1
                    objSamplesCollection.Add(objClsSampleParameters)
                Next
            End If

            If Not gobjNewMethod.SampleDataCollection Is Nothing Then
                gobjNewMethod.SampleDataCollection.Clear()
            Else
                gobjNewMethod.SampleDataCollection = New clsAnalysisSampleParametersCollection
            End If

            gobjNewMethod.SampleDataCollection = objSamplesCollection.Clone()

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

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : frmMethodAnalysisParameters_Load
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To send dialog result as ok
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 28.07.07
        ' Revisions             : 
        '=====================================================================
        ''note:
        ''This is called when user clicked on OK button
        ''algorith is that accept the parameter from user ,store it  in a temp variable
        ''and then bound it to data structure 
        ''with proper method name.



        Dim strLabName As String
        Dim strAnalystName As String
        Dim intIntegrationTime, intNoOfSamples, intNoOfSampleRepeats, intNoOfStdRepeats, intNoOfDecimalPlaces As Integer
        Dim intUnitID, intMeasurementID As Integer
        Dim blnBlankAfter As Boolean = False
        Dim intCount As Integer
        Dim blnDialogResult As Boolean
        Dim intOldNoOfSamples As Integer

        Try
            '---------------------------------------------------
            '1. validate all entered values
            '2. if ok then update all values to object
            '3. if previous value of number of samples and new value of the same differs then 
            '   display a message and update sample parameters.
            '4. if value of unit changes then update sample parameters
            '5. update method collection object
            '---------------------------------------------------

            '1. validate all entered values
            If nudIntegrationTime.Text = "" Or nudNumofSamples.Text = "" Or nudNumSampRepeat.Text = "" Or nudNumStdRepeat.Text = "" Or nudNumDecimalPlaces.Text = "" Then
                gobjMessageAdapter.ShowMessage(constFieldsRequired)
                Application.DoEvents()
            Else
                '2. if ok then update all values to object
                strLabName = Trim(txtLabName.Text)
                strAnalystName = Trim(txtAnalystName.Text)
                intIntegrationTime = nudIntegrationTime.Value
                intNoOfSamples = nudNumofSamples.Value
                intNoOfSampleRepeats = nudNumSampRepeat.Value
                intNoOfStdRepeats = nudNumStdRepeat.Value
                intNoOfDecimalPlaces = nudNumDecimalPlaces.Value
                intUnitID = cmbUnits.SelectedValue
                intMeasurementID = cmbMeasurementMode.SelectedValue
                If chkBlankAfter.Checked = True Then
                    blnBlankAfter = True
                Else
                    blnBlankAfter = False
                End If


                '3. if previous value of number of samples and new value of the same differs then 
                '   display a message and update sample parameters.
                If Not gobjNewMethod.AnalysisParameters Is Nothing Then

                    If gobjNewMethod.AnalysisParameters.Unit <> intUnitID Then
                        updateSampleParameter(intNoOfSamples, intUnitID, True)
                        gobjNewMethod.AnalysisParameters.Unit = intUnitID
                    End If

                    If gobjNewMethod.AnalysisParameters.NumOfSamples <> 0 Then
                        If gobjNewMethod.AnalysisParameters.NumOfSamples <> intNoOfSamples Then
                            blnDialogResult = gobjMessageAdapter.ShowMessage(constSamplesChanged)
                            Application.DoEvents()

                            '4. if value of unit changes then update sample parameters
                            'If Not gobjNewMethod.AnalysisParameters.Unit = 0 Then
                            'If gobjNewMethod.AnalysisParameters.Unit <> intUnitID Then
                            updateSampleParameter(intNoOfSamples, intUnitID, blnDialogResult)
                            gobjNewMethod.AnalysisParameters.NumOfSamples = intNoOfSamples
                            gobjNewMethod.AnalysisParameters.Unit = intUnitID
                            'End If
                            'End If

                            If blnDialogResult = True Then
                                Dim objfrmSampleParameters As New frmSampleParameters
                                objfrmSampleParameters.EnableBtnCancel = False
                                objfrmSampleParameters.ShowDialog()
                            Else
                                'updateSampleParameter(intNoOfSamples, intUnitID)
                                'Dim objfrmSampleParameters As New frmSampleParameters
                                'objfrmSampleParameters.EnableBtnCancel = False
                                'objfrmSampleParameters.ShowDialog()
                            End If
                        End If
                    End If
                End If

                If Not gobjNewMethod Is Nothing Then
                    gobjNewMethod.UserName = strAnalystName
                    If Not gobjNewMethod.AnalysisParameters Is Nothing Then
                        gobjNewMethod.AnalysisParameters.LabName = strLabName
                        gobjNewMethod.AnalysisParameters.AnalystName = strAnalystName
                        gobjNewMethod.AnalysisParameters.IntegrationTime = intIntegrationTime
                        gobjNewMethod.AnalysisParameters.NumOfDecimalPlaces = intNoOfDecimalPlaces
                        gobjNewMethod.AnalysisParameters.NumOfSampleRepeats = intNoOfSampleRepeats
                        'gobjNewMethod.AnalysisParameters.NumOfSamples = intNoOfSamples
                        gobjNewMethod.AnalysisParameters.NumOfStdRepeats = intNoOfStdRepeats
                        'gobjNewMethod.AnalysisParameters.Unit = intUnitID
                        gobjNewMethod.AnalysisParameters.MeasurementMode = intMeasurementID
                        gobjNewMethod.AnalysisParameters.IsBlankAfterEverySampleOrStd = blnBlankAfter
                    End If
                End If

                '5. update method collection object
                For intCount = gobjMethodCollection.Count - 1 To 0 Step -1
                    If gobjMethodCollection.item(intCount).MethodID = gobjNewMethod.MethodID Then
                        gobjMethodCollection.item(intCount).AnalysisParameters = gobjNewMethod.AnalysisParameters.Clone
                        gobjMethodCollection.item(intCount).SampleDataCollection = gobjNewMethod.SampleDataCollection.Clone 'Addded By Pankaj 29 May 07 
                        gobjMethodCollection.item(intCount).DateOfModification = DateTime.Now
                        funcSaveAllMethods(gobjMethodCollection)
                        Exit For
                    End If
                Next
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
            '---------------------------------------------------------
        End Try
    End Sub

    '+ Added by Amit 26/03/09 ################################################
    Private Sub cmbUnits_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If cmbUnits.SelectedIndex = 2 Then
            nudNumDecimalPlaces.Value = ConstDefaultNoOfDecimalPlacesPPB
        Else
            nudNumDecimalPlaces.Value = ConstDefaultNoOfDecimalPlaces
        End If
    End Sub
    '- Added by Amit 26/03/09 ################################################

#End Region

#Region " Private Functions "

    Private Sub AddHandlers()
        '=====================================================================
        ' Procedure Name        : AddHandlers
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : To add the handlers
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 04.10.06
        ' Revisions             : 
        '=====================================================================
        Try
            ''this will bind all the event to a control 
            AddHandler btnOk.Click, AddressOf btnOk_Click
            AddHandler btnCancel.Click, AddressOf btnCancel_Click
            '+ Added by Amit 26/03/09 ################################################
            AddHandler cmbUnits.SelectedIndexChanged, AddressOf cmbUnits_SelectedIndexChanged
            '- Added by Amit 26/03/09 ################################################
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
        ' Purpose               : To load the initial data
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 28.07.07
        ' Revisions             : 0
        '=====================================================================
        Dim objDtUnits As New DataTable
        Dim objDtMeasurementMode As New DataTable
        Try
            '-----------------------------------------------------------------
            '1. set mode type
            '2. if new mode then load initial data else load data from object
            '-----------------------------------------------------------------

            '1. set mode type
            If gobjNewMethod.AnalysisParameters Is Nothing Then
                OpenMethodMode = modGlobalConstants.EnumMethodMode.NewMode
                gobjNewMethod.AnalysisParameters = New clsAnalysisParameters

                'gobjNewMethod.AnalysisParameters.NumOfSamples = 25 'commented by : dinesh wagh on 2.2.2010

                'added by ; dinesh wagh on 2.2.2010
                '---------------------------------------
                If mintNoOfSamples <> 0 Then
                    gobjNewMethod.AnalysisParameters.NumOfSamples = mintNoOfSamples
                Else
                    gobjNewMethod.AnalysisParameters.NumOfSamples = 25
                End If
                '-------------------------------------


            Else
                OpenMethodMode = modGlobalConstants.EnumMethodMode.EditMode
            End If

            '2. if new mode then load initial data else load data from object
            objDtUnits = gobjClsAAS203.funcGetUnits()
            objDtMeasurementMode = gobjClsAAS203.funcGetMeasurementMode()

            If Not objDtUnits Is Nothing Then
                cmbUnits.DataSource = objDtUnits
                cmbUnits.DisplayMember = objDtUnits.Columns(ConstColumnUnit).ColumnName
                cmbUnits.ValueMember = objDtUnits.Columns(ConstColumnUnitID).ColumnName
            End If

            If Not objDtMeasurementMode Is Nothing Then
                cmbMeasurementMode.DataSource = objDtMeasurementMode
                cmbMeasurementMode.DisplayMember = objDtMeasurementMode.Columns(ConstColumnMeasurementMode).ColumnName
                cmbMeasurementMode.ValueMember = objDtMeasurementMode.Columns(ConstColumnMeasurementModeID).ColumnName
            End If

            Select Case OpenMethodMode
                Case modGlobalConstants.EnumMethodMode.NewMode
                    SubShowDefaultData()
                Case modGlobalConstants.EnumMethodMode.EditMode
                    SubShowDataFromParametersObject()
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

    Private Sub nudNumofSamples_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles nudNumofSamples.LostFocus
        '=====================================================================
        ' Procedure Name        : nudNumofSamples_LostFocus
        ' Parameters Passed     : None
        ' Returns               : Validate nudNumofSamples
        ' Purpose               :  
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 28.07.07
        ' Revisions             : 0
        '=====================================================================
        Try
            If nudNumofSamples.Value < 0 Or nudNumofSamples.Value > 200 Then
                gobjMessageAdapter.ShowMessage(constCheckValue)
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

    Private Sub nudIntegrationTime_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles nudIntegrationTime.LostFocus
        '=====================================================================
        ' Procedure Name        : nudIntegrationTime_LostFocus
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : validate nudIntegrationTime
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 28.07.07
        ' Revisions             : 0
        ' Revision By           : 
        '=====================================================================
        Try
            If nudIntegrationTime.Value < 1 Then
                nudIntegrationTime.Value = 1
            ElseIf nudIntegrationTime.Value > 99 Then
                nudIntegrationTime.Value = 99
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

    Private Sub nudNumSampRepeat_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles nudNumSampRepeat.LostFocus
        '=====================================================================
        ' Procedure Name        : nudNumSampRepeat_LostFocus
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : validate  nudNumSampRepeat
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 28.07.07
        ' Revisions             : 0
        ' Revision By           : 
        '=====================================================================
        Try
            If nudNumSampRepeat.Value < 1 Then
                nudNumSampRepeat.Value = 1
            ElseIf nudNumSampRepeat.Value > 15 Then
                nudNumSampRepeat.Value = 15
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

    Private Sub nudNumStdRepeat_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles nudNumStdRepeat.LostFocus
        '=====================================================================
        ' Procedure Name        : nudNumStdRepeat_LostFocus
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               :  Validate nudNumStdRepeat control
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 28.07.07
        ' Revisions             : 0
        ' Revision By           : 
        '=====================================================================
        Try
            If nudNumStdRepeat.Value < 1 Then
                nudNumStdRepeat.Value = 1
            ElseIf nudNumStdRepeat.Value > 15 Then
                nudNumStdRepeat.Value = 15
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

    Private Sub nudNumDecimalPlaces_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles nudNumDecimalPlaces.LostFocus
        '=====================================================================
        ' Procedure Name        : nudNumDecimalPlaces_LostFocus
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               :  validate nudNumDecimalPlaces values
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 28.07.07
        ' Revisions             : 0
        ' Revision By           : 
        '=====================================================================
        Try
            If nudNumDecimalPlaces.Value < 0 Then
                nudNumDecimalPlaces.Value = 0
            ElseIf nudNumDecimalPlaces.Value > 8 Then
                nudNumDecimalPlaces.Value = 8
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

    Private Sub SubShowDefaultData()
        '=====================================================================
        ' Procedure Name        : SubSetDefaultData
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : To load the default data
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 28.07.07
        ' Revisions             : 0
        ' Revision By           : 
        '=====================================================================

        ''note;
        ''this is called during the loading of a form 
        ''this will load some default value of all parameter on the screen



        Try
            If gblnIsDemoWithRealData = True Then  '--16.03.08
                txtLabName.Text = CONST_LabName1
            Else
                txtLabName.Text = gstrCustomer
            End If

            If Not gobjNewMethod Is Nothing Then
                txtAnalystName.Text = gobjNewMethod.UserName
            End If
            nudIntegrationTime.Value = ConstDefaultIntegrationTime
            nudNumDecimalPlaces.Value = ConstDefaultNoOfDecimalPlaces
            chkBlankAfter.Checked = True



            If gobjNewMethod.StandardAddition = True Then  '---03.08.09
                nudNumSampRepeat.Enabled = False
            End If

            'nudNumofSamples.Value = ConstDefaultNoOfSamples 'code commented by : dinesh wagh on 2.2.2010

            'code added by ; dinesh wagh on 2.2.2010
            '-------------------------------------
            If mintNoOfSamples <> 0 Then
                nudNumofSamples.Value = mintNoOfSamples
            Else
                nudNumofSamples.Value = ConstDefaultNoOfSamples
            End If
            '------------------------------------

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

    Private Sub SubShowDataFromParametersObject()
        '=====================================================================
        ' Procedure Name        : SubShowDataFromParametersObject
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : To load the parameters data
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 28.07.07
        ' Revisions             : 0
        ' Revision By           : 
        '=====================================================================

        ''note:
        ''this function will set the data from data structure object to
        ''the screen
        ''eg method name , method mode etc

        Try
            If Not gobjNewMethod Is Nothing Then
                txtAnalystName.Text = gobjNewMethod.UserName
                If Not gobjNewMethod.AnalysisParameters Is Nothing Then
                    txtLabName.Text = gobjNewMethod.AnalysisParameters.LabName
                    nudIntegrationTime.Value = gobjNewMethod.AnalysisParameters.IntegrationTime
                    nudNumDecimalPlaces.Value = gobjNewMethod.AnalysisParameters.NumOfDecimalPlaces
                    nudNumofSamples.Value = gobjNewMethod.AnalysisParameters.NumOfSamples
                    nudNumSampRepeat.Value = gobjNewMethod.AnalysisParameters.NumOfSampleRepeats
                    nudNumStdRepeat.Value = gobjNewMethod.AnalysisParameters.NumOfStdRepeats
                    chkBlankAfter.Checked = gobjNewMethod.AnalysisParameters.IsBlankAfterEverySampleOrStd
                    cmbUnits.SelectedValue = gobjNewMethod.AnalysisParameters.Unit
                    cmbMeasurementMode.SelectedValue = gobjNewMethod.AnalysisParameters.MeasurementMode
                End If
            End If
            If gobjNewMethod.StandardAddition = True Then  '---03.08.09
                nudNumSampRepeat.Enabled = False
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

#Region "Commented Code"
    'Private Sub frmMethodAnalysisParameters_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    '    '=====================================================================
    '    ' Procedure Name        : frmMethodAnalysisParameters_Load
    '    ' Parameters Passed     : Object,EventArgs
    '    ' Returns               : None
    '    ' Purpose               : To initialize and load the form
    '    ' Description           : 
    '    ' Assumptions           : 
    '    ' Dependencies          : 
    '    ' Author                : Deepak Bhati
    '    ' Created               : 03.10.06
    '    ' Revisions             : 
    '    '=====================================================================
    '    Dim objWait As New CWaitCursor

    '    Try
    '        Call gobjMain.ShowProgressBar(ConstFormLoad)

    '        If funcLoadInitialData() = False Then
    '            '---display error message
    '        End If

    '        Call AddHandlers()
    '        btnOk.Focus()
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
    'End Sub '28.07.07

    'Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    '=====================================================================
    '    ' Procedure Name        : frmMethodAnalysisParameters_Load
    '    ' Parameters Passed     : Object,EventArgs
    '    ' Returns               : None
    '    ' Purpose               : To send dialog result as ok
    '    ' Description           : 
    '    ' Assumptions           : 
    '    ' Dependencies          : 
    '    ' Author                : Deepak Bhati
    '    ' Created               : 03.10.06
    '    ' Revisions             : 
    '    '=====================================================================
    '    Dim strLabName As String
    '    Dim strAnalystName As String
    '    Dim intIntegrationTime, intNoOfSamples, intNoOfSampleRepeats, intNoOfStdRepeats, intNoOfDecimalPlaces As Integer
    '    Dim intUnitID, intMeasurementID As Integer
    '    Dim blnBlankAfter As Boolean = False
    '    Dim intCount As Integer
    '    Dim blnDlgRst As Boolean
    '    Dim intOldNoOfSamples As Integer

    '    Try
    '        If nudIntegrationTime.Text = "" Or nudNumofSamples.Text = "" Or nudNumSampRepeat.Text = "" Or nudNumStdRepeat.Text = "" Or nudNumDecimalPlaces.Text = "" Then
    '            gobjMessageAdapter.ShowMessage(constFieldsRequired)
    '            Application.DoEvents()
    '        Else
    '            strLabName = Trim(txtLabName.Text)
    '            strAnalystName = Trim(txtAnalystName.Text)
    '            intIntegrationTime = nudIntegrationTime.Value
    '            intNoOfSamples = nudNumofSamples.Value
    '            intNoOfSampleRepeats = nudNumSampRepeat.Value
    '            intNoOfStdRepeats = nudNumStdRepeat.Value
    '            intNoOfDecimalPlaces = nudNumDecimalPlaces.Value
    '            intUnitID = cmbUnits.SelectedValue
    '            intMeasurementID = cmbMeasurementMode.SelectedValue

    '            '---By Saurabh------
    '            '"Edit the Sample parameters form from Analysis parameters
    '            If OpenMethodMode = modGlobalConstants.EnumMethodMode.EditMode Then
    '                '---------Added By Pankaj 28 May 07
    '                If (gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.Unit <> intUnitID) Then
    '                    Call updateSampleParameter(mintRunNumberIndex, intNoOfSamples, intUnitID)
    '                    'Dim objfrmSampleParameters As New frmSampleParameters(modGlobalConstants.EnumMethodMode.NewMode)
    '                    'objfrmSampleParameters.ShowDialog()
    '                End If
    '                '--------
    '                If gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfSamples <> intNoOfSamples Then
    '                    blnDlgRst = gobjMessageAdapter.ShowMessage(constSamplesChanged)

    '                    'dlgRst = MsgBox("No. of Samples has been changed. Do you want to delete old Sample parameters?", MsgBoxStyle.YesNo, "Confirmation required")
    '                    'If dlgRst = DialogResult.Yes Then
    '                    '    Dim objfrmSampleParameters As New frmSampleParameters(EnumMethodMode.NewMode, intNoOfSamples)
    '                    '    objfrmSampleParameters.ShowDialog()
    '                    'Else
    '                    '    Dim objfrmSampleParameters As New frmSampleParameters(EnumMethodMode.EditMode, intNoOfSamples)
    '                    '    objfrmSampleParameters.ShowDialog()
    '                    'End If
    '                End If
    '            ElseIf (gobjchkActiveMethod.CancelMethod = True And gobjchkActiveMethod.NewMethod = True) And OpenMethodMode = modGlobalConstants.EnumMethodMode.NewMode Then
    '                '---------Added By Pankaj 28 May 07
    '                If (gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.Unit <> intUnitID) Then
    '                    Call updateSampleParameter(mintRunNumberIndex, intNoOfSamples, intUnitID)
    '                    'Dim objfrmSampleParameters As New frmSampleParameters(modGlobalConstants.EnumMethodMode.NewMode)
    '                    'objfrmSampleParameters.ShowDialog()
    '                End If
    '            End If
    '            '====================

    '            If chkBlankAfter.Checked = True Then
    '                blnBlankAfter = True
    '            Else
    '                blnBlankAfter = False
    '            End If

    '            If Not strLabName = "" Then
    '                If Not strAnalystName = "" Then
    '                    'gobjNewMethod.AnalysisParameters.AnalystName = strAnalystName
    '                    'gobjNewMethod.AnalysisParameters.LabName = strLabName
    '                    'gobjNewMethod.AnalysisParameters.IntegrationTime = intIntegrationTime
    '                    'gobjNewMethod.AnalysisParameters.NumOfDecimalPlaces = intNoOfDecimalPlaces
    '                    'gobjNewMethod.AnalysisParameters.NumOfSampleRepeats = intNoOfSampleRepeats
    '                    'gobjNewMethod.AnalysisParameters.NumOfSamples = intNoOfSamples
    '                    'gobjNewMethod.AnalysisParameters.NumOfStdRepeats = intNoOfStdRepeats
    '                    'gobjNewMethod.AnalysisParameters.Unit = intUnitID
    '                    'gobjNewMethod.AnalysisParameters.MeasurementMode = intMeasurementID
    '                    'gobjNewMethod.AnalysisParameters.IsBlankAfterEverySampleOrStd = blnBlankAfter
    '                    intOldNoOfSamples = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfSamples  '------Saurabh


    '                    'gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.AnalystName = strAnalystName
    '                    gobjNewMethod.UserName = strAnalystName
    '                    gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.LabName = strLabName
    '                    gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.IntegrationTime = intIntegrationTime
    '                    gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfDecimalPlaces = intNoOfDecimalPlaces
    '                    gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfSampleRepeats = intNoOfSampleRepeats
    '                    gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfSamples = intNoOfSamples
    '                    gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfStdRepeats = intNoOfStdRepeats
    '                    gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.Unit = intUnitID
    '                    gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.MeasurementMode = intMeasurementID
    '                    gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.IsBlankAfterEverySampleOrStd = blnBlankAfter
    '                    'gobjNewMethod.DateOfModification = DateTime.Now
    '                Else
    '                    '---display error message
    '                End If
    '                '---display error message
    '            End If
    '            For intCount = 0 To gobjMethodCollection.Count - 1
    '                If gobjMethodCollection.item(intCount).MethodID = gobjNewMethod.MethodID Then
    '                    'gobjMethodCollection.item(intCount).AnalysisParameters = gobjNewMethod.AnalysisParameters.Clone
    '                    gobjMethodCollection.item(intCount).QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.Clone
    '                    gobjMethodCollection.item(intCount).QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.Clone 'Addded By Pankaj 29 May 07 
    '                    gobjMethodCollection.item(intCount).DateOfModification = DateTime.Now
    '                End If
    '            Next

    '            'Call funcSerialize(ConstMethodsFileName, gobjMethodCollection)
    '            'Added By Pankaj on 23 May 07 for adding method of inactive mode
    '            gobjchkActiveMethod.fillParameters = True
    '            If (gobjchkActiveMethod.fillInstruments = True And gobjchkActiveMethod.fillParameters = True And gobjchkActiveMethod.fillStdConcentration = True And gobjchkActiveMethod.CancelMethod = True And gobjchkActiveMethod.NewMethod = True) Then
    '                gobjchkActiveMethod.NewMethod = False
    '                gobjchkActiveMethod.CancelMethod = False
    '                gobjchkActiveMethod.fillInstruments = False
    '                gobjchkActiveMethod.fillParameters = False
    '                gobjchkActiveMethod.fillStdConcentration = False
    '                gobjNewMethod.Status = True
    '                gobjMethodCollection.Add(gobjNewMethod)
    '            End If
    '            Call funcSaveAllMethods(gobjMethodCollection)

    '            '....Continued
    '            If OpenMethodMode = modGlobalConstants.EnumMethodMode.EditMode Then
    '                If blnDlgRst = True Then
    '                    Dim objfrmSampleParameters As New frmSampleParameters(EnumMethodMode.NewMode)
    '                    objfrmSampleParameters.EnableBtnCancel = False
    '                    objfrmSampleParameters.ShowDialog()
    '                ElseIf blnDlgRst = False Then
    '                    If intOldNoOfSamples <> intNoOfSamples Then
    '                        Dim objfrmSampleParameters As New frmSampleParameters(EnumMethodMode.EditMode)
    '                        objfrmSampleParameters.EnableBtnCancel = False
    '                        objfrmSampleParameters.ShowDialog()
    '                    End If
    '                End If
    '            End If


    '            Me.DialogResult = DialogResult.OK

    '        End If

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
    '        '---------------------------------------------------------
    '    End Try
    'End Sub

    'Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)   '28.07.07
    '    '=====================================================================
    '    ' Procedure Name        : frmMethodAnalysisParameters_Load
    '    ' Parameters Passed     : Object,EventArgs
    '    ' Returns               : None
    '    ' Purpose               : To send dialog result as ok
    '    ' Description           : 
    '    ' Assumptions           : 
    '    ' Dependencies          : 
    '    ' Author                : Deepak Bhati
    '    ' Created               : 03.10.06
    '    ' Revisions             : 
    '    '=====================================================================
    '    Dim strLabName As String
    '    Dim strAnalystName As String
    '    Dim intIntegrationTime, intNoOfSamples, intNoOfSampleRepeats, intNoOfStdRepeats, intNoOfDecimalPlaces As Integer
    '    Dim intUnitID, intMeasurementID As Integer
    '    Dim blnBlankAfter As Boolean = False
    '    Dim intCount As Integer
    '    Dim blnDlgRst As Boolean
    '    Dim intOldNoOfSamples As Integer

    '    '---18.06.07
    '    Try
    '        If nudIntegrationTime.Text = "" Or nudNumofSamples.Text = "" Or nudNumSampRepeat.Text = "" Or nudNumStdRepeat.Text = "" Or nudNumDecimalPlaces.Text = "" Then
    '            gobjMessageAdapter.ShowMessage(constFieldsRequired)
    '            Application.DoEvents()
    '        Else
    '            strLabName = Trim(txtLabName.Text)
    '            strAnalystName = Trim(txtAnalystName.Text)
    '            intIntegrationTime = nudIntegrationTime.Value
    '            intNoOfSamples = nudNumofSamples.Value
    '            intNoOfSampleRepeats = nudNumSampRepeat.Value
    '            intNoOfStdRepeats = nudNumStdRepeat.Value
    '            intNoOfDecimalPlaces = nudNumDecimalPlaces.Value
    '            intUnitID = cmbUnits.SelectedValue
    '            intMeasurementID = cmbMeasurementMode.SelectedValue

    '            '---By Saurabh------
    '            '"Edit the Sample parameters form from Analysis parameters
    '            If OpenMethodMode = modGlobalConstants.EnumMethodMode.EditMode Then
    '                '---------Added By Pankaj 28 May 07
    '                If (gobjNewMethod.AnalysisParameters.Unit <> intUnitID) Then
    '                    Call updateSampleParameter(intNoOfSamples, intUnitID)
    '                    'Dim objfrmSampleParameters As New frmSampleParameters(modGlobalConstants.EnumMethodMode.NewMode)
    '                    'objfrmSampleParameters.ShowDialog()
    '                End If
    '                '--------
    '                If gobjNewMethod.AnalysisParameters.NumOfSamples <> 0 Then
    '                    If gobjNewMethod.AnalysisParameters.NumOfSamples <> intNoOfSamples Then
    '                        blnDlgRst = gobjMessageAdapter.ShowMessage(constSamplesChanged)
    '                        Application.DoEvents()
    '                        'dlgRst = MsgBox("No. of Samples has been changed. Do you want to delete old Sample parameters?", MsgBoxStyle.YesNo, "Confirmation required")
    '                        'If dlgRst = DialogResult.Yes Then
    '                        '    Dim objfrmSampleParameters As New frmSampleParameters(EnumMethodMode.NewMode, intNoOfSamples)
    '                        '    objfrmSampleParameters.ShowDialog()
    '                        'Else
    '                        '    Dim objfrmSampleParameters As New frmSampleParameters(EnumMethodMode.EditMode, intNoOfSamples)
    '                        '    objfrmSampleParameters.ShowDialog()
    '                        'End If
    '                    End If
    '                End If
    '            ElseIf gobjchkActiveMethod.CancelMethod = True And gobjchkActiveMethod.NewMethod = True And OpenMethodMode = modGlobalConstants.EnumMethodMode.NewMode Then
    '                '---------Added By Pankaj 28 May 07
    '                If (gobjNewMethod.AnalysisParameters.Unit <> intUnitID) Then
    '                    Call updateSampleParameter(intNoOfSamples, intUnitID)
    '                    'Dim objfrmSampleParameters As New frmSampleParameters(modGlobalConstants.EnumMethodMode.NewMode)
    '                    'objfrmSampleParameters.ShowDialog()
    '                End If
    '            End If
    '            '====================

    '            If chkBlankAfter.Checked = True Then
    '                blnBlankAfter = True
    '            Else
    '                blnBlankAfter = False
    '            End If

    '            If Not strLabName = "" Then
    '                If Not strAnalystName = "" Then
    '                    intOldNoOfSamples = gobjNewMethod.AnalysisParameters.NumOfSamples  '------Saurabh

    '                    gobjNewMethod.UserName = strAnalystName
    '                    gobjNewMethod.AnalysisParameters.LabName = strLabName
    '                    gobjNewMethod.AnalysisParameters.IntegrationTime = intIntegrationTime
    '                    gobjNewMethod.AnalysisParameters.NumOfDecimalPlaces = intNoOfDecimalPlaces
    '                    gobjNewMethod.AnalysisParameters.NumOfSampleRepeats = intNoOfSampleRepeats
    '                    gobjNewMethod.AnalysisParameters.NumOfSamples = intNoOfSamples
    '                    gobjNewMethod.AnalysisParameters.NumOfStdRepeats = intNoOfStdRepeats
    '                    gobjNewMethod.AnalysisParameters.Unit = intUnitID
    '                    gobjNewMethod.AnalysisParameters.MeasurementMode = intMeasurementID
    '                    gobjNewMethod.AnalysisParameters.IsBlankAfterEverySampleOrStd = blnBlankAfter
    '                    'gobjNewMethod.DateOfModification = DateTime.Now
    '                Else
    '                    '---display error message
    '                End If
    '                '---display error message
    '            End If
    '            For intCount = 0 To gobjMethodCollection.Count - 1
    '                If gobjMethodCollection.item(intCount).MethodID = gobjNewMethod.MethodID Then
    '                    'gobjMethodCollection.item(intCount).AnalysisParameters = gobjNewMethod.AnalysisParameters.Clone
    '                    gobjMethodCollection.item(intCount).AnalysisParameters = gobjNewMethod.AnalysisParameters.Clone
    '                    gobjMethodCollection.item(intCount).SampleDataCollection = gobjNewMethod.SampleDataCollection.Clone 'Addded By Pankaj 29 May 07 
    '                    gobjMethodCollection.item(intCount).DateOfModification = DateTime.Now
    '                End If
    '            Next

    '            'Call funcSerialize(ConstMethodsFileName, gobjMethodCollection)
    '            'Added By Pankaj on 23 May 07 for adding method of inactive mode
    '            gobjchkActiveMethod.fillParameters = True '27.07.07
    '            'If (gobjchkActiveMethod.fillInstruments = True And gobjchkActiveMethod.fillParameters = True And gobjchkActiveMethod.fillStdConcentration = True And gobjchkActiveMethod.CancelMethod = True And gobjchkActiveMethod.NewMethod = True) Then
    '            If (gobjchkActiveMethod.fillParameters = True And gobjchkActiveMethod.fillStdConcentration = True And gobjchkActiveMethod.CancelMethod = True And gobjchkActiveMethod.NewMethod = True) Then
    '                gobjchkActiveMethod.NewMethod = False
    '                gobjchkActiveMethod.CancelMethod = False
    '                'gobjchkActiveMethod.fillInstruments = False  '27.07.07
    '                gobjchkActiveMethod.fillParameters = False
    '                gobjchkActiveMethod.fillStdConcentration = False
    '                gobjNewMethod.Status = True
    '                gobjMethodCollection.Add(gobjNewMethod)
    '            End If
    '            Call funcSaveAllMethods(gobjMethodCollection)

    '            '....Continued
    '            If OpenMethodMode = modGlobalConstants.EnumMethodMode.EditMode Then
    '                If gobjNewMethod.AnalysisParameters.NumOfSamples <> 0 Then
    '                    If blnDlgRst = True Then
    '                        Dim objfrmSampleParameters As New frmSampleParameters(EnumMethodMode.NewMode)
    '                        objfrmSampleParameters.EnableBtnCancel = False
    '                        objfrmSampleParameters.ShowDialog()
    '                    ElseIf blnDlgRst = False Then
    '                        If intOldNoOfSamples <> intNoOfSamples Then
    '                            Dim objfrmSampleParameters As New frmSampleParameters(EnumMethodMode.EditMode)
    '                            objfrmSampleParameters.EnableBtnCancel = False
    '                            objfrmSampleParameters.ShowDialog()
    '                        End If
    '                    End If
    '                End If
    '            End If

    '            Me.DialogResult = DialogResult.OK

    '        End If

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
    '        '---------------------------------------------------------
    '    End Try
    'End Sub

    'Public Function updateSampleParameter(ByVal mintRunNumberIndex As Integer, ByVal intNoOfSamples As Integer, ByVal intUnitID As Integer)
    '    '=====================================================================
    '    ' Procedure Name        : updateSampleParameter
    '    ' Parameters Passed     : 
    '    ' Returns               : None
    '    ' Purpose               : 
    '    ' Description           : 
    '    ' Assumptions           : 
    '    ' Dependencies          : 
    '    ' Author                : Pankaj Bamb 
    '    ' Created               : 29.05.07
    '    ' Revisions             : 
    '    '=====================================================================
    '    'If gobjNewMethod.QuantitativeDataCollection.Count > 0 Then
    '    '    mintRunNumberIndex = gobjNewMethod.QuantitativeDataCollection.Count - 1

    '    'ElseIf gobjNewMethod.QuantitativeDataCollection.Count = 0 Then
    '    '    mintRunNumberIndex = 0
    '    'End If
    '    Try
    '        Dim objClsSampleParameters As clsAnalysisSampleParameters
    '        Dim objSamplesCollection As clsAnalysisSampleParametersCollection
    '        Dim i As Integer

    '        objSamplesCollection = New clsAnalysisSampleParametersCollection
    '        If (OpenMethodMode = modGlobalConstants.EnumMethodMode.EditMode) And ((gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.Count > 0)) Then
    '            For i = 0 To intNoOfSamples - 1
    '                objClsSampleParameters = New clsAnalysisSampleParameters
    '                objClsSampleParameters.SampNumber = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(i).SampNumber
    '                objClsSampleParameters.SampleName = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(i).SampleName
    '                objClsSampleParameters.Weight = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(i).Weight
    '                If (intUnitID = 1) Then
    '                    objClsSampleParameters.Volume = 1
    '                Else
    '                    objClsSampleParameters.Volume = 100
    '                End If
    '                '//----- Added by Sachin Dokhale
    '                objClsSampleParameters.Abs = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(i).Abs
    '                objClsSampleParameters.AbsRepeat = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(i).AbsRepeat
    '                objClsSampleParameters.Conc = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(i).Conc
    '                objClsSampleParameters.Used = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(i).Used
    '                '//-----

    '                objClsSampleParameters.DilutionFactor = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(i).DilutionFactor
    '                objSamplesCollection.Add(objClsSampleParameters)
    '            Next
    '        Else
    '            For i = 0 To intNoOfSamples - 1
    '                objClsSampleParameters = New clsAnalysisSampleParameters
    '                objClsSampleParameters.SampNumber = i
    '                objClsSampleParameters.SampleName = "Sample " & i + 1
    '                objClsSampleParameters.Weight = 1
    '                If (intUnitID = 1) Then
    '                    objClsSampleParameters.Volume = 1
    '                Else
    '                    objClsSampleParameters.Volume = 100
    '                End If
    '                objClsSampleParameters.DilutionFactor = 1
    '                objSamplesCollection.Add(objClsSampleParameters)
    '            Next
    '        End If


    '        gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.Clear()
    '        gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection = objSamplesCollection.Clone()

    '        'For i As Integer = 0 To intNoOfSamples - 1
    '        '    If (intUnitID = 1) Then
    '        '        gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(i).Volume = 1
    '        '    Else
    '        '        gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(i).Volume = 100
    '        '    End If
    '        'Next
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
    '        '---------------------------------------------------------
    '    End Try
    'End Function

    'Public Function updateSampleParameter(ByVal intNoOfSamples As Integer, ByVal intUnitID As Integer)
    '    '=====================================================================
    '    ' Procedure Name        : updateSampleParameter
    '    ' Parameters Passed     : 
    '    ' Returns               : None
    '    ' Purpose               : 
    '    ' Description           : 
    '    ' Assumptions           : 
    '    ' Dependencies          : 
    '    ' Author                : Pankaj Bamb 
    '    ' Created               : 29.05.07
    '    ' Revisions             : 
    '    '=====================================================================
    '    Try
    '        Dim objClsSampleParameters As clsAnalysisSampleParameters
    '        Dim objSamplesCollection As clsAnalysisSampleParametersCollection
    '        Dim i As Integer

    '        objSamplesCollection = New clsAnalysisSampleParametersCollection
    '        If (OpenMethodMode = modGlobalConstants.EnumMethodMode.EditMode) And ((gobjNewMethod.SampleDataCollection.Count > 0)) Then
    '            For i = 0 To intNoOfSamples - 1
    '                objClsSampleParameters = New clsAnalysisSampleParameters
    '                objClsSampleParameters.SampNumber = gobjNewMethod.SampleDataCollection.item(i).SampNumber
    '                objClsSampleParameters.SampleName = gobjNewMethod.SampleDataCollection.item(i).SampleName
    '                objClsSampleParameters.Weight = gobjNewMethod.SampleDataCollection.item(i).Weight
    '                If (intUnitID = 1) Then
    '                    objClsSampleParameters.Volume = 1
    '                Else
    '                    objClsSampleParameters.Volume = 100
    '                End If
    '                '//----- Added by Sachin Dokhale
    '                objClsSampleParameters.Abs = gobjNewMethod.SampleDataCollection.item(i).Abs
    '                objClsSampleParameters.AbsRepeat = gobjNewMethod.SampleDataCollection.item(i).AbsRepeat
    '                objClsSampleParameters.Conc = gobjNewMethod.SampleDataCollection.item(i).Conc
    '                objClsSampleParameters.Used = gobjNewMethod.SampleDataCollection.item(i).Used
    '                '//-----

    '                objClsSampleParameters.DilutionFactor = gobjNewMethod.SampleDataCollection.item(i).DilutionFactor
    '                objSamplesCollection.Add(objClsSampleParameters)
    '            Next
    '        Else
    '            For i = 0 To intNoOfSamples - 1
    '                objClsSampleParameters = New clsAnalysisSampleParameters
    '                objClsSampleParameters.SampNumber = i
    '                objClsSampleParameters.SampleName = "Sample " & i + 1
    '                objClsSampleParameters.Weight = 1
    '                If (intUnitID = 1) Then
    '                    objClsSampleParameters.Volume = 1
    '                Else
    '                    objClsSampleParameters.Volume = 100
    '                End If
    '                objClsSampleParameters.DilutionFactor = 1
    '                objSamplesCollection.Add(objClsSampleParameters)
    '            Next
    '        End If


    '        gobjNewMethod.SampleDataCollection.Clear()
    '        gobjNewMethod.SampleDataCollection = objSamplesCollection.Clone()

    '        'For i As Integer = 0 To intNoOfSamples - 1
    '        '    If (intUnitID = 1) Then
    '        '        gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(i).Volume = 1
    '        '    Else
    '        '        gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(i).Volume = 100
    '        '    End If
    '        'Next
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
    '        '---------------------------------------------------------
    '    End Try
    'End Function

    'Private Function funcLoadInitialData() As Boolean
    '    '=====================================================================
    '    ' Procedure Name        : funcLoadInitialData
    '    ' Parameters Passed     : None
    '    ' Returns               : True or False
    '    ' Purpose               : To load the initial data
    '    ' Description           : 
    '    ' Assumptions           : 
    '    ' Dependencies          : 
    '    ' Author                : Deepak Bhati
    '    ' Created               : 04.10.06
    '    ' Revisions             : 2
    '    ' Revision By           : Mangesh S. on 28-Jan-2007
    '    ' Revision for          : Changes in AAS203Library
    '    ' Revision for          : Changes in AAS203Library By Deepak 18.06.07
    '    '=====================================================================
    '    Dim objDtUnits As New DataTable
    '    Dim objDtMeasurementMode As New DataTable

    '    Try
    '        txtLabName.Text = CONST_LabName
    '        txtAnalystName.Text = gobjNewMethod.UserName
    '        nudIntegrationTime.Value = ConstDefaultIntegrationTime
    '        nudNumDecimalPlaces.Value = ConstDefaultNoOfDecimalPlaces
    '        chkBlankAfter.Checked = True
    '        nudNumofSamples.Value = ConstDefaultNoOfSamples

    '        objDtUnits = gobjClsAAS203.funcGetUnits()
    '        objDtMeasurementMode = gobjClsAAS203.funcGetMeasurementMode()

    '        cmbUnits.DataSource = objDtUnits
    '        cmbUnits.DisplayMember = objDtUnits.Columns(ConstColumnUnit).ColumnName
    '        cmbUnits.ValueMember = objDtUnits.Columns(ConstColumnUnitID).ColumnName

    '        cmbMeasurementMode.DataSource = objDtMeasurementMode
    '        cmbMeasurementMode.DisplayMember = objDtMeasurementMode.Columns(ConstColumnMeasurementMode).ColumnName
    '        cmbMeasurementMode.ValueMember = objDtMeasurementMode.Columns(ConstColumnMeasurementModeID).ColumnName

    '        If OpenMethodMode = modGlobalConstants.EnumMethodMode.NewMode Then
    '            gobjNewMethod.AnalysisParameters = New AAS203Library.Method.clsAnalysisParameters
    '        End If

    '        If Not gobjNewMethod.AnalysisParameters.Unit = 0 Then
    '            cmbUnits.SelectedValue = gobjNewMethod.AnalysisParameters.Unit
    '        End If

    '        If Not gobjNewMethod.AnalysisParameters.MeasurementMode = 0 Then
    '            cmbMeasurementMode.SelectedValue = gobjNewMethod.AnalysisParameters.MeasurementMode
    '        End If

    '        If OpenMethodMode = modGlobalConstants.EnumMethodMode.EditMode Then
    '            txtAnalystName.Text = gobjNewMethod.UserName
    '            txtLabName.Text = gobjNewMethod.AnalysisParameters.LabName
    '            nudIntegrationTime.Value = gobjNewMethod.AnalysisParameters.IntegrationTime
    '            nudNumDecimalPlaces.Value = gobjNewMethod.AnalysisParameters.NumOfDecimalPlaces
    '            nudNumofSamples.Value = gobjNewMethod.AnalysisParameters.NumOfSamples
    '            nudNumSampRepeat.Value = gobjNewMethod.AnalysisParameters.NumOfSampleRepeats
    '            nudNumStdRepeat.Value = gobjNewMethod.AnalysisParameters.NumOfStdRepeats
    '            chkBlankAfter.Checked = gobjNewMethod.AnalysisParameters.IsBlankAfterEverySampleOrStd
    '        End If

    '        Return True

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
    'End Function  '28.07.07

#End Region



End Class
