Public Class frmGraphScale
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
    Friend WithEvents CustomPanelBackground As GradientPanel.CustomPanel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnOk As NETXP.Controls.XPButton
    Friend WithEvents NVYMin As NumberValidator.NumberValidator
    Friend WithEvents NVYMax As NumberValidator.NumberValidator
    Friend WithEvents NVXMin As NumberValidator.NumberValidator
    Friend WithEvents NVXMax As NumberValidator.NumberValidator
    Friend WithEvents NVZMax As NumberValidator.NumberValidator
    Friend WithEvents NVZMin As NumberValidator.NumberValidator
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents PanelZAxis As System.Windows.Forms.Panel
    Friend WithEvents dtpXMin As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpXMax As System.Windows.Forms.DateTimePicker
    Friend WithEvents PanelDateXAxis As System.Windows.Forms.Panel
    Friend WithEvents lblXminFormat As System.Windows.Forms.Label
    Friend WithEvents lblXMaxFormat As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmGraphScale))
        Me.CustomPanelBackground = New GradientPanel.CustomPanel
        Me.PanelDateXAxis = New System.Windows.Forms.Panel
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.lblXMaxFormat = New System.Windows.Forms.Label
        Me.lblXminFormat = New System.Windows.Forms.Label
        Me.dtpXMin = New System.Windows.Forms.DateTimePicker
        Me.dtpXMax = New System.Windows.Forms.DateTimePicker
        Me.PanelZAxis = New System.Windows.Forms.Panel
        Me.NVZMax = New NumberValidator.NumberValidator
        Me.NVZMin = New NumberValidator.NumberValidator
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.NVXMax = New NumberValidator.NumberValidator
        Me.NVXMin = New NumberValidator.NumberValidator
        Me.NVYMax = New NumberValidator.NumberValidator
        Me.NVYMin = New NumberValidator.NumberValidator
        Me.btnOk = New NETXP.Controls.XPButton
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.CustomPanelBackground.SuspendLayout()
        Me.PanelDateXAxis.SuspendLayout()
        Me.PanelZAxis.SuspendLayout()
        Me.SuspendLayout()
        '
        'CustomPanelBackground
        '
        Me.CustomPanelBackground.BackColor = System.Drawing.Color.Gainsboro
        Me.CustomPanelBackground.BackColor2 = System.Drawing.Color.White
        Me.CustomPanelBackground.Controls.Add(Me.PanelDateXAxis)
        Me.CustomPanelBackground.Controls.Add(Me.PanelZAxis)
        Me.CustomPanelBackground.Controls.Add(Me.NVXMax)
        Me.CustomPanelBackground.Controls.Add(Me.NVXMin)
        Me.CustomPanelBackground.Controls.Add(Me.NVYMax)
        Me.CustomPanelBackground.Controls.Add(Me.NVYMin)
        Me.CustomPanelBackground.Controls.Add(Me.btnOk)
        Me.CustomPanelBackground.Controls.Add(Me.Label4)
        Me.CustomPanelBackground.Controls.Add(Me.Label3)
        Me.CustomPanelBackground.Controls.Add(Me.Label2)
        Me.CustomPanelBackground.Controls.Add(Me.Label1)
        Me.CustomPanelBackground.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CustomPanelBackground.DockPadding.All = 1
        Me.CustomPanelBackground.GradientMode = GradientPanel.LinearGradientMode.Vertical
        Me.CustomPanelBackground.Location = New System.Drawing.Point(0, 0)
        Me.CustomPanelBackground.Name = "CustomPanelBackground"
        Me.CustomPanelBackground.Size = New System.Drawing.Size(402, 151)
        Me.CustomPanelBackground.TabIndex = 14
        '
        'PanelDateXAxis
        '
        Me.PanelDateXAxis.Controls.Add(Me.Label8)
        Me.PanelDateXAxis.Controls.Add(Me.Label7)
        Me.PanelDateXAxis.Controls.Add(Me.lblXMaxFormat)
        Me.PanelDateXAxis.Controls.Add(Me.lblXminFormat)
        Me.PanelDateXAxis.Controls.Add(Me.dtpXMin)
        Me.PanelDateXAxis.Controls.Add(Me.dtpXMax)
        Me.PanelDateXAxis.Location = New System.Drawing.Point(20, 7)
        Me.PanelDateXAxis.Name = "PanelDateXAxis"
        Me.PanelDateXAxis.Size = New System.Drawing.Size(368, 55)
        Me.PanelDateXAxis.TabIndex = 33
        Me.PanelDateXAxis.Visible = False
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(192, 10)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(64, 16)
        Me.Label8.TabIndex = 36
        Me.Label8.Text = "X-Axis Max"
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(8, 11)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(64, 15)
        Me.Label7.TabIndex = 35
        Me.Label7.Text = "X-Axis Min "
        '
        'lblXMaxFormat
        '
        Me.lblXMaxFormat.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblXMaxFormat.Location = New System.Drawing.Point(200, 32)
        Me.lblXMaxFormat.Name = "lblXMaxFormat"
        Me.lblXMaxFormat.Size = New System.Drawing.Size(160, 16)
        Me.lblXMaxFormat.TabIndex = 34
        Me.lblXMaxFormat.Text = "(dd-MMM HH:mm)"
        Me.lblXMaxFormat.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblXminFormat
        '
        Me.lblXminFormat.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblXminFormat.Location = New System.Drawing.Point(24, 32)
        Me.lblXminFormat.Name = "lblXminFormat"
        Me.lblXminFormat.Size = New System.Drawing.Size(152, 16)
        Me.lblXminFormat.TabIndex = 33
        Me.lblXminFormat.Text = "(dd-MMM HH:mm)"
        Me.lblXminFormat.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtpXMin
        '
        Me.dtpXMin.CustomFormat = "dd-MMM HH:mm"
        Me.dtpXMin.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpXMin.Location = New System.Drawing.Point(80, 8)
        Me.dtpXMin.Name = "dtpXMin"
        Me.dtpXMin.ShowUpDown = True
        Me.dtpXMin.Size = New System.Drawing.Size(96, 20)
        Me.dtpXMin.TabIndex = 31
        '
        'dtpXMax
        '
        Me.dtpXMax.CustomFormat = "dd-MMM HH:mm"
        Me.dtpXMax.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpXMax.Location = New System.Drawing.Point(264, 8)
        Me.dtpXMax.Name = "dtpXMax"
        Me.dtpXMax.ShowUpDown = True
        Me.dtpXMax.Size = New System.Drawing.Size(96, 20)
        Me.dtpXMax.TabIndex = 32
        '
        'PanelZAxis
        '
        Me.PanelZAxis.Controls.Add(Me.NVZMax)
        Me.PanelZAxis.Controls.Add(Me.NVZMin)
        Me.PanelZAxis.Controls.Add(Me.Label5)
        Me.PanelZAxis.Controls.Add(Me.Label6)
        Me.PanelZAxis.Location = New System.Drawing.Point(24, 192)
        Me.PanelZAxis.Name = "PanelZAxis"
        Me.PanelZAxis.Size = New System.Drawing.Size(368, 40)
        Me.PanelZAxis.TabIndex = 30
        Me.PanelZAxis.Visible = False
        '
        'NVZMax
        '
        Me.NVZMax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.NVZMax.DigitsAfterDecimalPoint = 4
        Me.NVZMax.ErrorColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(192, Byte))
        Me.NVZMax.ErrorMessage = ""
        Me.NVZMax.Location = New System.Drawing.Point(272, 8)
        Me.NVZMax.MaximumRange = 9999
        Me.NVZMax.MaxLength = 8
        Me.NVZMax.MinimumRange = 0
        Me.NVZMax.Name = "NVZMax"
        Me.NVZMax.RangeValidation = False
        Me.NVZMax.Size = New System.Drawing.Size(88, 20)
        Me.NVZMax.TabIndex = 29
        Me.NVZMax.Text = ""
        Me.NVZMax.ValidationType = NumberValidator.NumberValidator.Validations.DoubleOnly
        '
        'NVZMin
        '
        Me.NVZMin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.NVZMin.DigitsAfterDecimalPoint = 4
        Me.NVZMin.ErrorColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(192, Byte))
        Me.NVZMin.ErrorMessage = ""
        Me.NVZMin.Location = New System.Drawing.Point(80, 8)
        Me.NVZMin.MaximumRange = 9999
        Me.NVZMin.MaxLength = 8
        Me.NVZMin.MinimumRange = 0
        Me.NVZMin.Name = "NVZMin"
        Me.NVZMin.RangeValidation = False
        Me.NVZMin.Size = New System.Drawing.Size(88, 20)
        Me.NVZMin.TabIndex = 28
        Me.NVZMin.Text = ""
        Me.NVZMin.ValidationType = NumberValidator.NumberValidator.Validations.DoubleOnly
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(192, 8)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 16)
        Me.Label5.TabIndex = 27
        Me.Label5.Text = "Z-Axis Max"
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(8, 8)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 20)
        Me.Label6.TabIndex = 26
        Me.Label6.Text = "Z-Axis Min"
        '
        'NVXMax
        '
        Me.NVXMax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.NVXMax.DigitsAfterDecimalPoint = 4
        Me.NVXMax.ErrorColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(192, Byte))
        Me.NVXMax.ErrorMessage = ""
        Me.NVXMax.Location = New System.Drawing.Point(288, 16)
        Me.NVXMax.MaximumRange = 10
        Me.NVXMax.MaxLength = 8
        Me.NVXMax.MinimumRange = 0.86
        Me.NVXMax.Name = "NVXMax"
        Me.NVXMax.RangeValidation = False
        Me.NVXMax.Size = New System.Drawing.Size(88, 20)
        Me.NVXMax.TabIndex = 25
        Me.NVXMax.Text = ""
        Me.NVXMax.ValidationType = NumberValidator.NumberValidator.Validations.DoubleOnly
        '
        'NVXMin
        '
        Me.NVXMin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.NVXMin.DigitsAfterDecimalPoint = 4
        Me.NVXMin.ErrorColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(192, Byte))
        Me.NVXMin.ErrorMessage = ""
        Me.NVXMin.Location = New System.Drawing.Point(96, 16)
        Me.NVXMin.MaximumRange = 0
        Me.NVXMin.MaxLength = 8
        Me.NVXMin.MinimumRange = -0.15
        Me.NVXMin.Name = "NVXMin"
        Me.NVXMin.RangeValidation = False
        Me.NVXMin.Size = New System.Drawing.Size(88, 20)
        Me.NVXMin.TabIndex = 24
        Me.NVXMin.Text = ""
        Me.NVXMin.ValidationType = NumberValidator.NumberValidator.Validations.DoubleOnly
        '
        'NVYMax
        '
        Me.NVYMax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.NVYMax.DigitsAfterDecimalPoint = 4
        Me.NVYMax.ErrorColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(192, Byte))
        Me.NVYMax.ErrorMessage = ""
        Me.NVYMax.Location = New System.Drawing.Point(288, 73)
        Me.NVYMax.MaximumRange = 10
        Me.NVYMax.MaxLength = 8
        Me.NVYMax.MinimumRange = 0.5
        Me.NVYMax.Name = "NVYMax"
        Me.NVYMax.RangeValidation = False
        Me.NVYMax.Size = New System.Drawing.Size(88, 20)
        Me.NVYMax.TabIndex = 23
        Me.NVYMax.Text = ""
        Me.NVYMax.ValidationType = NumberValidator.NumberValidator.Validations.DoubleOnly
        '
        'NVYMin
        '
        Me.NVYMin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.NVYMin.DigitsAfterDecimalPoint = 4
        Me.NVYMin.ErrorColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(192, Byte))
        Me.NVYMin.ErrorMessage = ""
        Me.NVYMin.Location = New System.Drawing.Point(96, 72)
        Me.NVYMin.MaximumRange = 0
        Me.NVYMin.MaxLength = 8
        Me.NVYMin.MinimumRange = -0.05
        Me.NVYMin.Name = "NVYMin"
        Me.NVYMin.RangeValidation = False
        Me.NVYMin.Size = New System.Drawing.Size(88, 20)
        Me.NVYMin.TabIndex = 22
        Me.NVYMin.Text = ""
        Me.NVYMin.ValidationType = NumberValidator.NumberValidator.Validations.DoubleOnly
        '
        'btnOk
        '
        Me.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOk.Image = CType(resources.GetObject("btnOk.Image"), System.Drawing.Image)
        Me.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnOk.Location = New System.Drawing.Point(160, 112)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(80, 24)
        Me.btnOk.TabIndex = 21
        Me.btnOk.Text = "&Apply"
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(208, 73)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 16)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "Y-Axis Max"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(24, 72)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 20)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Y-Axis Min"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(208, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 16)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "X-Axis Max"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(24, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 15)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "X-Axis Min "
        '
        'frmGraphScale
        '
        Me.AcceptButton = Me.btnOk
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(402, 151)
        Me.Controls.Add(Me.CustomPanelBackground)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmGraphScale"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "  Change Scale"
        Me.CustomPanelBackground.ResumeLayout(False)
        Me.PanelDateXAxis.ResumeLayout(False)
        Me.PanelZAxis.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Class Member Variables "

    Private err As New ErrorProvider
    Private blnXAxisWavelength As Boolean
    Private blnIsSpaceDiagram As Boolean
    Private blnIsCIEDiagram As Boolean

    Private constXMin As Double = 0
    Private constMin As Double = -100
    Private constMax As Double = 1100

    Private mblnIsXAxisDateTime As Boolean

#End Region

#Region " Public Properties "

    Public Property XAxisWavelength() As Boolean
        Get
            Return blnXAxisWavelength
        End Get
        Set(ByVal Value As Boolean)
            blnXAxisWavelength = Value
        End Set
    End Property

    Public Property IsColorSpaceDiagram() As Boolean
        Get
            Return blnIsSpaceDiagram
        End Get
        Set(ByVal Value As Boolean)
            blnIsSpaceDiagram = Value
            If blnIsSpaceDiagram = True Then
                Me.PanelZAxis.Visible = True
            End If
        End Set
    End Property

    Public Property IsCIEDiagram() As Boolean
        Get
            Return blnIsCIEDiagram
        End Get
        Set(ByVal Value As Boolean)
            blnIsCIEDiagram = Value
        End Set
    End Property

    Public Property IsXAxisDateTime() As Boolean
        Get
            Return mblnIsXAxisDateTime
        End Get
        Set(ByVal Value As Boolean)
            mblnIsXAxisDateTime = Value
            If mblnIsXAxisDateTime = True Then
                Me.PanelDateXAxis.Visible = True
            End If
        End Set
    End Property

#End Region

#Region " Private Functions "

    Private Function Addhandlers() As Boolean
        Try
            AddHandler btnOk.Click, AddressOf subbtnOk_Click

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

#End Region

#Region " Form Load And Event Handling Functions "

    Private Sub subbtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            'If Len(NVXMin.Text) <= 0 Then
            '    gobjMessageAdapter.ShowMessage(msgIDPlzEnterProperScaleLimits)
            '    Application.DoEvents()
            '    NVXMin.Focus()
            '    Exit Try
            'End If

            'If Len(NVXMax.Text) <= 0 Then
            '    gobjMessageAdapter.ShowMessage(msgIDPlzEnterProperScaleLimits)
            '    Application.DoEvents()
            '    NVXMax.Focus()
            '    Exit Try
            'End If

            'If Len(NVYMin.Text) <= 0 Then
            '    gobjMessageAdapter.ShowMessage(msgIDPlzEnterProperScaleLimits)
            '    Application.DoEvents()
            '    NVYMin.Focus()
            '    Exit Try
            'End If

            'If Len(NVYMax.Text) <= 0 Then
            '    gobjMessageAdapter.ShowMessage(msgIDPlzEnterProperScaleLimits)
            '    Application.DoEvents()
            '    NVYMax.Focus()
            '    Exit Try
            'End If

            If blnIsCIEDiagram = True Then
                'If CDbl(NVXMin.Text) < -100 Then
                '    gobjMessageAdapter.ShowMessage(msgIDMinOfXAxisWavelengthCannotLessThanMinus100)
                '    Application.DoEvents()
                '    NVXMin.Focus()
                '    Exit Try
                'End If

                'If CDbl(NVXMax.Text) > 100 Then
                '    gobjMessageAdapter.ShowMessage(msgIDMaxOfXAxisCannotGreaterThan100)
                '    Application.DoEvents()
                '    NVXMax.Focus()
                '    Exit Try
                'End If

                'If CDbl(NVYMin.Text) < -100 Then
                '    gobjMessageAdapter.ShowMessage(msgIDMinOfYAxisCannotLessThanMinus100)
                '    Application.DoEvents()
                '    NVYMin.Focus()
                '    Exit Try
                'End If

                'If CDbl(NVYMax.Text) > 100 Then
                '    gobjMessageAdapter.ShowMessage(msgIDMaxOfYAxisCannotGreaterThan100)
                '    Application.DoEvents()
                '    NVYMax.Focus()
                '    Exit Try
                'End If

                Me.DialogResult = DialogResult.OK
                Me.Close()
                Exit Try
            End If

            If blnIsSpaceDiagram = False Then
                'If blnXAxisWavelength = True Then
                '    If CDbl(NVXMin.Text) < 300 Then
                '        gobjMessageAdapter.ShowMessage(msgIDMinOfXAxisWavelengthCannotLessThan300)
                '        Application.DoEvents()
                '        NVXMin.Focus()
                '        Exit Try
                '    End If
                'Else
                '    If CDbl(NVXMin.Text) < constXMin Then
                '        gobjMessageAdapter.ShowMessage(msgIDMinOfXAxisCannotLessThanZero)
                '        Application.DoEvents()
                '        NVXMin.Focus()
                '        Exit Try
                '    End If
                'End If

                'If CDbl(NVYMin.Text) < constMin Then
                '    gobjMessageAdapter.ShowMessage(msgIDMinCannotLessThanMinus100)
                '    Application.DoEvents()
                '    NVYMin.Focus()
                '    Exit Try
                'End If

                'If CDbl(NVXMin.Text) >= CDbl(NVXMax.Text) Or _
                '        CDbl(NVYMin.Text) >= CDbl(NVYMax.Text) Then
                '    gobjMessageAdapter.ShowMessage(msgIDMinCannotGreaterThanMax)
                '    Application.DoEvents()
                '    Exit Try
                'End If

                'If CDbl(NVXMax.Text) > constMax Or CDbl(NVYMax.Text) > constMax Then
                '    gobjMessageAdapter.ShowMessage(msgIDMaxCannotGreaterThan1100)
                '    Application.DoEvents()
                '    Exit Try
                'End If
            Else
                'If Len(NVZMin.Text) <= 0 Then
                '    gobjMessageAdapter.ShowMessage(msgIDPlzEnterProperScaleLimits)
                '    Application.DoEvents()
                '    NVZMin.Focus()
                '    Exit Try
                'End If

                'If Len(NVZMax.Text) <= 0 Then
                '    gobjMessageAdapter.ShowMessage(msgIDPlzEnterProperScaleLimits)
                '    Application.DoEvents()
                '    NVZMax.Focus()
                '    Exit Try
                'End If

                'If CDbl(NVXMin.Text) < -100 Then
                '    gobjMessageAdapter.ShowMessage(msgIDMinOfXAxisWavelengthCannotLessThanMinus100)
                '    Application.DoEvents()
                '    NVXMin.Focus()
                '    Exit Try
                'End If

                'If CDbl(NVXMax.Text) > 100 Then
                '    gobjMessageAdapter.ShowMessage(msgIDMaxOfXAxisCannotGreaterThan100)
                '    Application.DoEvents()
                '    NVXMax.Focus()
                '    Exit Try
                'End If

                'If CDbl(NVYMin.Text) < -100 Then
                '    gobjMessageAdapter.ShowMessage(msgIDMinOfYAxisCannotLessThanMinus100)
                '    Application.DoEvents()
                '    NVYMin.Focus()
                '    Exit Try
                'End If

                'If CDbl(NVYMax.Text) > 100 Then
                '    gobjMessageAdapter.ShowMessage(msgIDMaxOfYAxisCannotGreaterThan100)
                '    Application.DoEvents()
                '    NVYMax.Focus()
                '    Exit Try
                'End If

                'If CDbl(NVZMin.Text) < -100 Then
                '    gobjMessageAdapter.ShowMessage(msgIDMinOfZAxisCannotLessThanMinus100)
                '    Application.DoEvents()
                '    NVZMin.Focus()
                '    Exit Try
                'End If

                'If CDbl(NVZMax.Text) > 100 Then
                '    gobjMessageAdapter.ShowMessage(msgIDMaxOfZAxisCannotGreaterThan100)
                '    Application.DoEvents()
                '    NVZMax.Focus()
                '    Exit Try
                'End If

                'If CDbl(NVXMin.Text) >= 0 Or CDbl(NVXMax.Text) <= 0 Or _
                '        CDbl(NVYMin.Text) >= 0 Or CDbl(NVYMax.Text) <= 0 Or _
                '        CDbl(NVZMin.Text) >= 0 Or CDbl(NVZMax.Text) <= 0 Then
                '    gobjMessageAdapter.ShowMessage(msgIDMinMaxCannotGreaterLessThan1)
                '    Application.DoEvents()
                '    Exit Try
                'End If
            End If

            Me.DialogResult = DialogResult.OK
            Me.Close()

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

    Private Sub frmGraphScale_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Addhandlers()
    End Sub

#End Region

#Region " Validation Status Functions "

    Private Sub NVXMin_ValidationStatus(ByVal Status As NumberValidator.NumberValidator.Status, ByVal Msg As String) Handles NVXMin.ValidationStatus
        '17.03.06 deepak 
        If Status = NumberValidator.NumberValidator.Status.NotValidated Then
            NVXMin.Focus()
            btnOk.Enabled = False
        Else
            btnOk.Enabled = True
        End If
        err.SetError(NVXMin, Msg)
    End Sub

    Private Sub NVXMax_ValidationStatus(ByVal Status As NumberValidator.NumberValidator.Status, ByVal Msg As String) Handles NVXMax.ValidationStatus
        '17.03.06 deepak 
        If Status = NumberValidator.NumberValidator.Status.NotValidated Then
            NVXMax.Focus()
            btnOk.Enabled = False
        Else
            btnOk.Enabled = True
        End If
        err.SetError(NVXMax, Msg)
    End Sub

    Private Sub NVYMin_ValidationStatus(ByVal Status As NumberValidator.NumberValidator.Status, ByVal Msg As String) Handles NVYMin.ValidationStatus
        '17.03.06 deepak 
        If Status = NumberValidator.NumberValidator.Status.NotValidated Then
            NVYMin.Focus()
            btnOk.Enabled = False
        Else
            btnOk.Enabled = True
        End If
        err.SetError(NVYMin, Msg)
    End Sub

    Private Sub NVYMax_ValidationStatus(ByVal Status As NumberValidator.NumberValidator.Status, ByVal Msg As String) Handles NVYMax.ValidationStatus
        '17.03.06 deepak 
        If Status = NumberValidator.NumberValidator.Status.NotValidated Then
            NVYMax.Focus()
            btnOk.Enabled = False
        Else
            btnOk.Enabled = True
        End If
        err.SetError(NVYMax, Msg)
    End Sub

#End Region

End Class
