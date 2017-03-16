Imports AAS203.Common
Imports System.IO

Public Class frmYChangeScale
    Inherits System.Windows.Forms.Form

#Region "Public Variables"
    Public SpectrumParameter As Object
#End Region

#Region "Private Variable"
    Dim mblnAvoidProcessing As Boolean
#End Region

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    Public Sub New(ByVal RefobjParameter As Object)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        'SpectrumParameter = New Spectrum.UVSpectrumParameter
        SpectrumParameter = New Object
        SpectrumParameter = RefobjParameter



    End Sub
    'Public Sub New(ByVal RefobjParameter As Spectrum.EnergySpectrumParameter)
    '    MyBase.New()

    '    'This call is required by the Windows Form Designer.
    '    InitializeComponent()

    '    'Add any initialization after the InitializeComponent() call
    '    SpectrumParameter = New Spectrum.EnergySpectrumParameter
    '    'SpectrumParameter = New Object
    '    SpectrumParameter = RefobjParameter



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
    Friend WithEvents CustomPanel1 As GradientPanel.CustomPanel
    Friend WithEvents btnOk As NETXP.Controls.XPButton
    Friend WithEvents btnCancel As NETXP.Controls.XPButton
    Friend WithEvents lblYAxisMax As System.Windows.Forms.Label
    Friend WithEvents lblYAxisMin As System.Windows.Forms.Label
    Friend WithEvents txtYaxisMax As NumberValidator.NumberValidator
    Friend WithEvents txtYaxisMin As NumberValidator.NumberValidator
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmYChangeScale))
        Me.CustomPanel1 = New GradientPanel.CustomPanel
        Me.txtYaxisMin = New NumberValidator.NumberValidator
        Me.txtYaxisMax = New NumberValidator.NumberValidator
        Me.lblYAxisMax = New System.Windows.Forms.Label
        Me.lblYAxisMin = New System.Windows.Forms.Label
        Me.btnOk = New NETXP.Controls.XPButton
        Me.btnCancel = New NETXP.Controls.XPButton
        Me.CustomPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'CustomPanel1
        '
        Me.CustomPanel1.BackColor = System.Drawing.Color.AliceBlue
        Me.CustomPanel1.Controls.Add(Me.txtYaxisMin)
        Me.CustomPanel1.Controls.Add(Me.txtYaxisMax)
        Me.CustomPanel1.Controls.Add(Me.lblYAxisMax)
        Me.CustomPanel1.Controls.Add(Me.lblYAxisMin)
        Me.CustomPanel1.Controls.Add(Me.btnOk)
        Me.CustomPanel1.Controls.Add(Me.btnCancel)
        Me.CustomPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CustomPanel1.Location = New System.Drawing.Point(0, 0)
        Me.CustomPanel1.Name = "CustomPanel1"
        Me.CustomPanel1.Size = New System.Drawing.Size(322, 111)
        Me.CustomPanel1.TabIndex = 0
        '
        'txtYaxisMin
        '
        Me.txtYaxisMin.DigitsAfterDecimalPoint = 3
        Me.txtYaxisMin.ErrorColor = System.Drawing.Color.Empty
        Me.txtYaxisMin.ErrorMessage = Nothing
        Me.txtYaxisMin.Location = New System.Drawing.Point(96, 16)
        Me.txtYaxisMin.MaximumRange = 5000
        Me.txtYaxisMin.MaxLength = 10
        Me.txtYaxisMin.MinimumRange = -5000
        Me.txtYaxisMin.Name = "txtYaxisMin"
        Me.txtYaxisMin.RangeValidation = True
        Me.txtYaxisMin.Size = New System.Drawing.Size(56, 20)
        Me.txtYaxisMin.TabIndex = 1
        Me.txtYaxisMin.Text = ""
        Me.txtYaxisMin.ValidationType = NumberValidator.NumberValidator.Validations.DoubleOnly
        '
        'txtYaxisMax
        '
        Me.txtYaxisMax.DigitsAfterDecimalPoint = 0
        Me.txtYaxisMax.ErrorColor = System.Drawing.Color.Empty
        Me.txtYaxisMax.ErrorMessage = Nothing
        Me.txtYaxisMax.Location = New System.Drawing.Point(256, 16)
        Me.txtYaxisMax.MaximumRange = 5000
        Me.txtYaxisMax.MinimumRange = -5000
        Me.txtYaxisMax.Name = "txtYaxisMax"
        Me.txtYaxisMax.RangeValidation = True
        Me.txtYaxisMax.Size = New System.Drawing.Size(56, 20)
        Me.txtYaxisMax.TabIndex = 2
        Me.txtYaxisMax.Text = ""
        Me.txtYaxisMax.ValidationType = NumberValidator.NumberValidator.Validations.DoubleOnly
        '
        'lblYAxisMax
        '
        Me.lblYAxisMax.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblYAxisMax.Location = New System.Drawing.Point(168, 16)
        Me.lblYAxisMax.Name = "lblYAxisMax"
        Me.lblYAxisMax.Size = New System.Drawing.Size(85, 16)
        Me.lblYAxisMax.TabIndex = 29
        Me.lblYAxisMax.Text = "Y axis Max"
        '
        'lblYAxisMin
        '
        Me.lblYAxisMin.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblYAxisMin.Location = New System.Drawing.Point(16, 16)
        Me.lblYAxisMin.Name = "lblYAxisMin"
        Me.lblYAxisMin.Size = New System.Drawing.Size(72, 16)
        Me.lblYAxisMin.TabIndex = 27
        Me.lblYAxisMin.Text = "Y axis Min"
        '
        'btnOk
        '
        Me.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOk.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOk.Image = CType(resources.GetObject("btnOk.Image"), System.Drawing.Image)
        Me.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnOk.Location = New System.Drawing.Point(56, 56)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(86, 34)
        Me.btnOk.TabIndex = 3
        Me.btnOk.Text = "&OK"
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Image = CType(resources.GetObject("btnCancel.Image"), System.Drawing.Image)
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancel.Location = New System.Drawing.Point(184, 56)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(86, 34)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmYChangeScale
        '
        Me.AcceptButton = Me.btnOk
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(322, 111)
        Me.Controls.Add(Me.CustomPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmYChangeScale"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Change Scale"
        Me.CustomPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Private Functions"

    Private Sub funcfrmInitialise()
        '=====================================================================
        ' Procedure Name        : funcfrmInitialise
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : 
        ' Description           : from Initialise 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 21.11.06
        ' Revisions             : 
        '=====================================================================

        ''note;
        ''this is used to take some initialization of form.
        ''for eg set a validation of textbox.
        ''set onscreen arrengment etc.

        Try
            txtYaxisMax.RangeValidation = True
            txtYaxisMax.ValidationType = NumberValidator.NumberValidator.Validations.DoubleOnly

            txtYaxisMin.RangeValidation = True
            txtYaxisMin.ValidationType = NumberValidator.NumberValidator.Validations.DoubleOnly
            ''format the text player.
            txtYaxisMin.Text = Format(SpectrumParameter.YaxisMin, "0.000")
            txtYaxisMax.Text = Format(SpectrumParameter.YaxisMax, "0.000")

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

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        '=====================================================================
        ' Procedure Name        : btnOk_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : 
        ' Description           : Set X & Y Axis
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 21.11.06
        ' Revisions             : 
        '=====================================================================
        ''note:
        ''this is called when user click on OK button.
        ''this will set sxale set by user to data structure.
        ''which will being later used.

        Dim objWait As New CWaitCursor

        Try
            If funcSetScale() = True Then
                ''function for setting scale.
                Me.DialogResult = DialogResult.OK
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

            '---------------------------------------------------------
        End Try
    End Sub

    Private Function funcSetScale() As Boolean
        '=====================================================================
        ' Procedure Name        : funcSetScale
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : 
        ' Description           : Set X & Y Axis
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 21.11.06
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Try
            If mblnAvoidProcessing = True Then
                ''check a flag for avoiding a process
                Exit Function
            End If
            mblnAvoidProcessing = True
            Application.DoEvents()
            ''allow application to perfrom its panding work.

            If (txtYaxisMax.Text.Trim() = "") Then
                txtYaxisMax.Text = "0"
                ''set scale to zero if user has't enter anything.
            End If
            If (txtYaxisMin.Text.Trim() = "") Then
                txtYaxisMin.Text = "0"
            End If
            If CDbl(txtYaxisMin.Text) >= CDbl(txtYaxisMax.Text) Then
                ''min value should be less then max value.
                gobjMessageAdapter.ShowMessage(constValueMinToMax)
                Return False
            End If

            If txtYaxisMin.MinimumRange <= CDbl(txtYaxisMin.Text) And _
                txtYaxisMin.MaximumRange >= CDbl(txtYaxisMin.Text) Then
                SpectrumParameter.YaxisMin = CDbl(txtYaxisMin.Text)
            Else
                gobjMessageAdapter.ShowMessage(constInvalidRange)
                Return False
            End If
            If txtYaxisMax.MaximumRange >= CDbl(txtYaxisMax.Text) And _
                txtYaxisMax.MinimumRange <= CDbl(txtYaxisMax.Text) Then
                SpectrumParameter.YaxisMax = CDbl(txtYaxisMax.Text)
                funcSetScale = True
            Else
                gobjMessageAdapter.ShowMessage(constInvalidRange)
                ''show the error mess.
                Return False
            End If
            Me.Close()
            ''close the form after setting a scale.
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
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            mblnAvoidProcessing = False
            '---------------------------------------------------------
        End Try
    End Function

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        '=====================================================================
        ' Procedure Name        : btnCancel_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : 
        ' Description           : Set X & Y Axis
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 21.11.06
        ' Revisions             : praveen
        '=====================================================================
        ''note:
        ''this is called when user click on cancel button.
        Dim objWait As New CWaitCursor

        Try
            If mblnAvoidProcessing = True Then
                Exit Sub
            End If
            Me.Close()
            ''close the form.
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
            mblnAvoidProcessing = False
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If

            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub frmChangeScale_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '=====================================================================
        ' Procedure Name        : frmChangeScale_Load
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : 
        ' Description           : load the form object
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 12.12.06
        ' Revisions             : praveen
        '=====================================================================
        ''note:
        ''this is called when the form is loaded 
        ''this will call initialization function.
        Dim objWait As New CWaitCursor

        Try
            funcfrmInitialise()
            ''function for initialise
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

    Friend Sub funcSetValidatingScale(ByVal ValMode As EnumCalibrationMode)
        '=====================================================================
        ' Procedure Name        : funcSetValidatingScale
        ' Parameters Passed     : ValMode
        ' Returns               : None
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 12.12.06
        ' Revisions             : praveen
        '=====================================================================
        ''note:
        ''this will used to set a validation of scale.
        ''this is set as par the mode of operation.
        Dim intMaxLength As Integer = 7
        Dim intMinimumRangeY, intMaximumRangeY As Integer
        Dim intPlaceDecimalPoint As Integer = 1
        Try
            Select Case ValMode
                'set a validation as per mode.
            Case modGlobalConstants.EnumCalibrationMode.AA, modGlobalConstants.EnumCalibrationMode.AABGC, modGlobalConstants.EnumCalibrationMode.AABGCSR, modGlobalConstants.EnumCalibrationMode.MABS
                    intPlaceDecimalPoint = 3
                Case modGlobalConstants.EnumCalibrationMode.D2E, modGlobalConstants.EnumCalibrationMode.EMISSION, modGlobalConstants.EnumCalibrationMode.HCLE
                    intPlaceDecimalPoint = 1
                Case modGlobalConstants.EnumCalibrationMode.SELFTEST
                    intPlaceDecimalPoint = 0
            End Select

            txtYaxisMax.MaxLength = intMaxLength
            txtYaxisMax.DigitsAfterDecimalPoint = intPlaceDecimalPoint

            txtYaxisMin.MaxLength = intMaxLength
            txtYaxisMin.DigitsAfterDecimalPoint = intPlaceDecimalPoint

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
