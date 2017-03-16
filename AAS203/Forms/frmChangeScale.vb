Imports AAS203.Common
Imports System.IO

Public Class frmChangeScale
    Inherits System.Windows.Forms.Form

    'Public SpectrumParameter As Spectrum.UVSpectrumParameter
    Public SpectrumParameter As Object
    Private mblnIsSetWv As Boolean
#Region "Private Variable"
    Dim mblnAvoidProcessing As Boolean

#End Region

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()
        mblnIsSetWv = True

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub
    Public Sub New(ByVal RefobjParameter As Object)
        MyBase.New()
        mblnIsSetWv = True

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        'SpectrumParameter = New Spectrum.UVSpectrumParameter
        SpectrumParameter = New Object
        SpectrumParameter = RefobjParameter



    End Sub

    Public Sub New(ByVal RefobjParameter As Object, ByVal blnIsSetWvIn As Boolean)
        MyBase.New()
        mblnIsSetWv = True
        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        'SpectrumParameter = New Spectrum.UVSpectrumParameter
        SpectrumParameter = New Object
        SpectrumParameter = RefobjParameter
        mblnIsSetWv = blnIsSetWvIn

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
    Friend WithEvents lblXAxisMax As System.Windows.Forms.Label
    Friend WithEvents lblYAxisMin As System.Windows.Forms.Label
    Friend WithEvents lblXAxisMin As System.Windows.Forms.Label
    Friend WithEvents txtYaxisMin As NumberValidator.NumberValidator
    Friend WithEvents txtYaxisMax As NumberValidator.NumberValidator
    Friend WithEvents txtXaxisMin As NumberValidator.NumberValidator
    Friend WithEvents txtXaxisMax As NumberValidator.NumberValidator
    Public WithEvents lblXAxis As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmChangeScale))
        Me.CustomPanel1 = New GradientPanel.CustomPanel
        Me.txtXaxisMax = New NumberValidator.NumberValidator
        Me.txtXaxisMin = New NumberValidator.NumberValidator
        Me.txtYaxisMax = New NumberValidator.NumberValidator
        Me.txtYaxisMin = New NumberValidator.NumberValidator
        Me.lblXAxis = New System.Windows.Forms.Label
        Me.lblYAxisMax = New System.Windows.Forms.Label
        Me.lblXAxisMax = New System.Windows.Forms.Label
        Me.lblYAxisMin = New System.Windows.Forms.Label
        Me.lblXAxisMin = New System.Windows.Forms.Label
        Me.btnOk = New NETXP.Controls.XPButton
        Me.btnCancel = New NETXP.Controls.XPButton
        Me.CustomPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'CustomPanel1
        '
        Me.CustomPanel1.BackColor = System.Drawing.Color.AliceBlue
        Me.CustomPanel1.Controls.Add(Me.txtXaxisMax)
        Me.CustomPanel1.Controls.Add(Me.txtXaxisMin)
        Me.CustomPanel1.Controls.Add(Me.txtYaxisMax)
        Me.CustomPanel1.Controls.Add(Me.txtYaxisMin)
        Me.CustomPanel1.Controls.Add(Me.lblXAxis)
        Me.CustomPanel1.Controls.Add(Me.lblYAxisMax)
        Me.CustomPanel1.Controls.Add(Me.lblXAxisMax)
        Me.CustomPanel1.Controls.Add(Me.lblYAxisMin)
        Me.CustomPanel1.Controls.Add(Me.lblXAxisMin)
        Me.CustomPanel1.Controls.Add(Me.btnOk)
        Me.CustomPanel1.Controls.Add(Me.btnCancel)
        Me.CustomPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CustomPanel1.Location = New System.Drawing.Point(0, 0)
        Me.CustomPanel1.Name = "CustomPanel1"
        Me.CustomPanel1.Size = New System.Drawing.Size(322, 175)
        Me.CustomPanel1.TabIndex = 0
        '
        'txtXaxisMax
        '
        Me.txtXaxisMax.DigitsAfterDecimalPoint = 2
        Me.txtXaxisMax.ErrorColor = System.Drawing.Color.Empty
        Me.txtXaxisMax.ErrorMessage = Nothing
        Me.txtXaxisMax.Location = New System.Drawing.Point(253, 44)
        Me.txtXaxisMax.MaximumRange = 1100
        Me.txtXaxisMax.MaxLength = 4
        Me.txtXaxisMax.MinimumRange = -4
        Me.txtXaxisMax.Name = "txtXaxisMax"
        Me.txtXaxisMax.RangeValidation = True
        Me.txtXaxisMax.Size = New System.Drawing.Size(56, 20)
        Me.txtXaxisMax.TabIndex = 3
        Me.txtXaxisMax.Text = ""
        Me.txtXaxisMax.ValidationType = NumberValidator.NumberValidator.Validations.DoubleOnly
        '
        'txtXaxisMin
        '
        Me.txtXaxisMin.DigitsAfterDecimalPoint = 2
        Me.txtXaxisMin.ErrorColor = System.Drawing.Color.Empty
        Me.txtXaxisMin.ErrorMessage = Nothing
        Me.txtXaxisMin.Location = New System.Drawing.Point(96, 44)
        Me.txtXaxisMin.MaximumRange = 1100
        Me.txtXaxisMin.MaxLength = 4
        Me.txtXaxisMin.MinimumRange = -50
        Me.txtXaxisMin.Name = "txtXaxisMin"
        Me.txtXaxisMin.RangeValidation = True
        Me.txtXaxisMin.Size = New System.Drawing.Size(56, 20)
        Me.txtXaxisMin.TabIndex = 2
        Me.txtXaxisMin.Text = ""
        Me.txtXaxisMin.ValidationType = NumberValidator.NumberValidator.Validations.DoubleOnly
        '
        'txtYaxisMax
        '
        Me.txtYaxisMax.DigitsAfterDecimalPoint = 3
        Me.txtYaxisMax.ErrorColor = System.Drawing.Color.Empty
        Me.txtYaxisMax.ErrorMessage = Nothing
        Me.txtYaxisMax.Location = New System.Drawing.Point(253, 13)
        Me.txtYaxisMax.MaximumRange = 5000
        Me.txtYaxisMax.MaxLength = 4
        Me.txtYaxisMax.MinimumRange = -5000
        Me.txtYaxisMax.Name = "txtYaxisMax"
        Me.txtYaxisMax.RangeValidation = True
        Me.txtYaxisMax.Size = New System.Drawing.Size(56, 20)
        Me.txtYaxisMax.TabIndex = 1
        Me.txtYaxisMax.Text = ""
        Me.txtYaxisMax.ValidationType = NumberValidator.NumberValidator.Validations.DoubleOnly
        '
        'txtYaxisMin
        '
        Me.txtYaxisMin.DigitsAfterDecimalPoint = 3
        Me.txtYaxisMin.ErrorColor = System.Drawing.Color.Empty
        Me.txtYaxisMin.ErrorMessage = Nothing
        Me.txtYaxisMin.Location = New System.Drawing.Point(96, 13)
        Me.txtYaxisMin.MaximumRange = 5000
        Me.txtYaxisMin.MaxLength = 4
        Me.txtYaxisMin.MinimumRange = -5000
        Me.txtYaxisMin.Name = "txtYaxisMin"
        Me.txtYaxisMin.RangeValidation = True
        Me.txtYaxisMin.Size = New System.Drawing.Size(56, 20)
        Me.txtYaxisMin.TabIndex = 0
        Me.txtYaxisMin.Text = ""
        Me.txtYaxisMin.ValidationType = NumberValidator.NumberValidator.Validations.DoubleOnly
        '
        'lblXAxis
        '
        Me.lblXAxis.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblXAxis.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblXAxis.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblXAxis.Location = New System.Drawing.Point(16, 80)
        Me.lblXAxis.Name = "lblXAxis"
        Me.lblXAxis.Size = New System.Drawing.Size(296, 24)
        Me.lblXAxis.TabIndex = 25
        Me.lblXAxis.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblYAxisMax
        '
        Me.lblYAxisMax.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblYAxisMax.Location = New System.Drawing.Point(163, 14)
        Me.lblYAxisMax.Name = "lblYAxisMax"
        Me.lblYAxisMax.Size = New System.Drawing.Size(85, 16)
        Me.lblYAxisMax.TabIndex = 29
        Me.lblYAxisMax.Text = "Y axis Max"
        '
        'lblXAxisMax
        '
        Me.lblXAxisMax.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblXAxisMax.Location = New System.Drawing.Point(163, 45)
        Me.lblXAxisMax.Name = "lblXAxisMax"
        Me.lblXAxisMax.Size = New System.Drawing.Size(85, 16)
        Me.lblXAxisMax.TabIndex = 28
        Me.lblXAxisMax.Text = "X axis Max"
        '
        'lblYAxisMin
        '
        Me.lblYAxisMin.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblYAxisMin.Location = New System.Drawing.Point(16, 14)
        Me.lblYAxisMin.Name = "lblYAxisMin"
        Me.lblYAxisMin.Size = New System.Drawing.Size(72, 16)
        Me.lblYAxisMin.TabIndex = 27
        Me.lblYAxisMin.Text = "Y axis Min"
        '
        'lblXAxisMin
        '
        Me.lblXAxisMin.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblXAxisMin.Location = New System.Drawing.Point(16, 45)
        Me.lblXAxisMin.Name = "lblXAxisMin"
        Me.lblXAxisMin.Size = New System.Drawing.Size(72, 16)
        Me.lblXAxisMin.TabIndex = 26
        Me.lblXAxisMin.Text = "X axis Min"
        '
        'btnOk
        '
        Me.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOk.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOk.Image = CType(resources.GetObject("btnOk.Image"), System.Drawing.Image)
        Me.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnOk.Location = New System.Drawing.Point(56, 120)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(86, 34)
        Me.btnOk.TabIndex = 4
        Me.btnOk.Text = "&OK"
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Image = CType(resources.GetObject("btnCancel.Image"), System.Drawing.Image)
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancel.Location = New System.Drawing.Point(183, 120)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(86, 34)
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.Text = "&Cancel"
        '
        'frmChangeScale
        '
        Me.AcceptButton = Me.btnOk
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(322, 175)
        Me.Controls.Add(Me.CustomPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmChangeScale"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Change Scale"
        Me.CustomPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

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
        ' Revisions             : praveen
        '=====================================================================

        ''note:
        ''this is used to initialise a change scale form
        ''do some validation here.
        Try

            'lblXAxisMin.Text = addataSpect.dblWvMin.ToString
            'lblXAxisMax.Text = addataSpect.dblWvMax.ToString
            'lblYAxisMin.Text = addataSpect.dblYmin.ToString
            'lblYAxisMax.Text = addataSpect.dblYMax.ToString
            If mblnIsSetWv = False Then
                ''check for wavwlwngth flag 
                lblXAxis.Visible = False
            Else
                lblXAxis.Visible = True
            End If

            If (lblXAxis.Visible = True) Then 'Added By Pankaj 11 May 07 11 
                If mblnIsSetWv = True Then
                    ''format the input display
                    txtXaxisMin.Text = Format(gobjInst.WavelengthCur, "0.0")    'Format(SpectrumParameter.XaxisMin, "0.0")
                    If (SpectrumParameter.XaxisMax < (gobjInst.WavelengthCur + 10)) Then
                        txtXaxisMax.Text = Format((gobjInst.WavelengthCur + 10), "0.0")
                    Else
                        txtXaxisMax.Text = Format(SpectrumParameter.XaxisMax, "0.0")
                    End If

                    txtYaxisMin.Text = Format(SpectrumParameter.YaxisMin, "0.000")
                    txtYaxisMax.Text = Format(SpectrumParameter.YaxisMax, "0.000")
                    lblXAxis.Text = Format(SpectrumParameter.XaxisMin, "#0.0")
                Else
                    txtXaxisMax.Text = Format(SpectrumParameter.XaxisMax, "0.0")
                    txtYaxisMin.Text = Format(SpectrumParameter.YaxisMin, "0.000")
                    txtYaxisMax.Text = Format(SpectrumParameter.YaxisMax, "0.000")
                    lblXAxis.Text = Format(SpectrumParameter.XaxisMin, "#0.0")
                End If
            Else 'Added by Pankaj 11 May 07 for setting default Settings for Analysis and DataFiles form
                'Added By Pankaj Mon 21 May 07
                If (lblXAxis.Visible = False) Then
                    txtXaxisMin.MinimumRange = 0
                End If
                '---27.03.09
                'txtXaxisMin.Text = Format(SpectrumParameter.XaxisMin, "0.000")
                'txtXaxisMax.Text = Format(SpectrumParameter.XaxisMax, "0.000")

                '---27.03.09
                txtXaxisMin.Text = Format(SpectrumParameter.XaxisMin, "0.000")
                txtXaxisMax.Text = Format(SpectrumParameter.XaxisMax, "0.000")

                txtYaxisMin.Text = Format(SpectrumParameter.YaxisMin, "0.000")
                txtYaxisMax.Text = Format(SpectrumParameter.YaxisMax, "0.000")
            End If
            'txtYaxisMax.DigitsAfterDecimalPoint = 2
            'txtYaxisMax.MaxLength = 6

            ''below set some validation rule.

            txtYaxisMax.RangeValidation = True
            txtYaxisMax.ValidationType = NumberValidator.NumberValidator.Validations.DoubleOnly

            txtYaxisMin.RangeValidation = True
            txtYaxisMin.ValidationType = NumberValidator.NumberValidator.Validations.DoubleOnly

            txtXaxisMax.RangeValidation = True
            txtXaxisMax.ValidationType = NumberValidator.NumberValidator.Validations.DoubleOnly

            txtXaxisMin.RangeValidation = True
            txtXaxisMin.ValidationType = NumberValidator.NumberValidator.Validations.DoubleOnly

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
        Dim objWait As New CWaitCursor

        Try
            If funcSetScale() = True Then
                ''function for setting a scale.
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
        Dim dblWvMin As Double
        Dim dblWvMax As Double
        Try
            If mblnAvoidProcessing = True Then
                Return False
            End If
            mblnAvoidProcessing = True
            Application.DoEvents()

            If lblXAxis.Visible = True Then '----- Condition added by pankaj on 10 May 07
                ''Added by praveen for null scale value
                If ((txtXaxisMin.Text) = "") Then

                    txtXaxisMin.Text = 0
                End If
                If ((txtXaxisMax.Text) = "") Then

                    txtXaxisMax.Text = 0
                End If
                ''ended by praveen

                '---27.03.09
                'dblWvMin = Format(CDbl(txtXaxisMin.Text), "0.0")
                'dblWvMax = Format(CDbl(txtXaxisMax.Text), "0.0")

                '---27.03.09
                dblWvMin = Format(CDbl(txtXaxisMin.Text), "0.000")
                dblWvMax = Format(CDbl(txtXaxisMax.Text), "0.000")

                If mblnIsSetWv = True Then
                    If dblWvMin >= dblWvMax Then
                        gobjMessageAdapter.ShowMessage(constWLMAXlessthanWLMIN)
                        'gFuncShowMessage("Maximum wavelenth is less then minimum wavelength", Me.Text, modGlobalConstants.EnumMessageType.Information)
                        Return False
                    End If
                    Application.DoEvents()
                    '---position wavelength drive to given value

                    If gblnIsDemoWithRealData = False Then    '---16.03.08
                        If gobjCommProtocol.Wavelength_Position(dblWvMin, lblXAxis) = True Then
                            Call gobjCommProtocol.mobjCommdll.subTime_Delay(100)
                            ''delay
                            Application.DoEvents()
                            ''allow application to perfrom its panding work.
                        End If
                    End If

                Else
                    If dblWvMin >= dblWvMax Then
                        'gobjMessageAdapter.ShowMessage("X axis value should be minimum " & txtXaxisMax.MinimumRange & " to maximum " & txtXaxisMax.MaximumRange & "  range.", "X axis", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage)
                        gobjMessageAdapter.ShowMessage("Maximum value is less than or equal to minimum value", "X axis", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage)
                        'gFuncShowMessage("Maximum wavelenth is less then minimum wavelength", Me.Text, modGlobalConstants.EnumMessageType.Information)
                        Return False
                    End If
                End If
            Else
                'Saurabh Commented for showing -ive values
                'Added By Pankaj Mon 21 May 07
                'If ((txtXaxisMin.Text) = "") Then
                '    txtXaxisMin.Text = 0
                'End If
                'Saurabh Commented for showing -ive values

            End If
            '------------Added By Pankaj on 29 May 07
            ''Added by praveen for null scale value

            If ((txtYaxisMin.Text) = "") Then

                txtYaxisMin.Text = 0
            End If
            If ((txtYaxisMax.Text) = "") Then

                txtYaxisMax.Text = 0
            End If

            ''ended by praveen

            '---27.03.09
            'dblWvMin = Format(CDbl(txtYaxisMin.Text), "0.0")
            'dblWvMax = Format(CDbl(txtYaxisMax.Text), "0.0")

            '---27.03.09
            dblWvMin = Format(CDbl(txtYaxisMin.Text), "0.000")
            dblWvMax = Format(CDbl(txtYaxisMax.Text), "0.000")

            If mblnIsSetWv = True Then
                If dblWvMin >= dblWvMax Then
                    gobjMessageAdapter.ShowMessage(constWLMAXlessthanWLMIN)
                    'gFuncShowMessage("Maximum wavelenth is less then minimum wavelength", Me.Text, modGlobalConstants.EnumMessageType.Information)
                    Return False
                End If
            Else
                If dblWvMin >= dblWvMax Then
                    'gobjMessageAdapter.ShowMessage("Y axis should be minimum " & txtXaxisMax.MinimumRange & " to maximum " & txtXaxisMax.MaximumRange & "  range.", "X axis", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage)
                    gobjMessageAdapter.ShowMessage("Maximum value is less than or equal to minimum value", "Y axis", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage)
                    'gFuncShowMessage("Maximum wavelenth is less then minimum wavelength", Me.Text, modGlobalConstants.EnumMessageType.Information)
                    Return False
                End If
            End If
            '--------------
            ''Added by praveen for validate X-Axis on 15.08.07
            If ((txtXaxisMin.Text) = "") Then

                txtXaxisMin.Text = 0
            End If
            If ((txtXaxisMax.Text) = "") Then

                txtXaxisMax.Text = 0
            End If

            '---27.03.09
            'dblWvMin = Format(CDbl(txtXaxisMin.Text), "0.0")
            'dblWvMax = Format(CDbl(txtXaxisMax.Text), "0.0")
            '----

            '---27.03.09
            dblWvMin = Format(CDbl(txtXaxisMin.Text), "0.000")
            dblWvMax = Format(CDbl(txtXaxisMax.Text), "0.000")
            '----

            If dblWvMin >= dblWvMax Then
                ' gobjMessageAdapter.ShowMessage("x axis should be minimum " & txtXaxisMax.MinimumRange & " to maximum " & txtXaxisMax.MaximumRange & "  range.", "X axis", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage)
                gobjMessageAdapter.ShowMessage("Maximum value is less than or equal to minimum value", "X axis", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage)
                'gFuncShowMessage("Maximum wavelenth is less then minimum wavelength", Me.Text, modGlobalConstants.EnumMessageType.Information)
                Return False
            End If

            ''ended by praveen
            SpectrumParameter.XaxisMin = CDbl(txtXaxisMin.Text)
            SpectrumParameter.XaxisMax = CDbl(txtXaxisMax.Text)
            SpectrumParameter.YaxisMin = CDbl(txtYaxisMin.Text)
            SpectrumParameter.YaxisMax = CDbl(txtYaxisMax.Text)
            Application.DoEvents()
            Me.Close()
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
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor

        Try
            If mblnAvoidProcessing = True Then
                ''check for flag to avoid a process.
                Exit Sub
            End If
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
        Dim objWait As New CWaitCursor
        ''note:
        ''this is called when change scale form is loaded.

        Try
            funcfrmInitialise()
            ''function for initialisation
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
        ''this is used for setting a validation scale as per
        ''given calibration mode.
        Dim intMaxLength As Integer = 7
        Dim intMinimumRangeX, intMaximumRangeX, intMinimumRangeY, intMaximumRangeY As Integer
        Dim intPlaceDecimalPoint As Integer = 1
        
        intMinimumRangeX = -4
        'Added By Pankaj Mon 21 May 07
        If (lblXAxis.Visible = False) Then
            intMinimumRangeX = 0
        End If
        intMaximumRangeX = 1100
        Select Case ValMode
            ''set a validation as per calibration mode.
            Case modGlobalConstants.EnumCalibrationMode.AA, modGlobalConstants.EnumCalibrationMode.AABGC, modGlobalConstants.EnumCalibrationMode.AABGCSR, modGlobalConstants.EnumCalibrationMode.MABS
                intPlaceDecimalPoint = 3
            Case modGlobalConstants.EnumCalibrationMode.D2E, modGlobalConstants.EnumCalibrationMode.EMISSION, modGlobalConstants.EnumCalibrationMode.HCLE
                intPlaceDecimalPoint = 1
            Case modGlobalConstants.EnumCalibrationMode.SELFTEST
                intPlaceDecimalPoint = 0
        End Select
        txtXaxisMax.MaxLength = 6
        txtXaxisMax.MinimumRange = intMinimumRangeX
        txtXaxisMax.MaximumRange = intMaximumRangeX
        txtXaxisMax.DigitsAfterDecimalPoint = 1

        txtXaxisMin.MaxLength = 6
        txtXaxisMin.MinimumRange = intMinimumRangeX
        txtXaxisMin.MaximumRange = intMaximumRangeX
        txtXaxisMin.DigitsAfterDecimalPoint = 1
        ''this will set a digits after a decimal.
        txtYaxisMax.MaxLength = intMaxLength
        'txtYaxisMax.MinimumRange = intMinimumRangeY
        'txtYaxisMax.MaximumRange = MaximumRangeY
        txtYaxisMax.DigitsAfterDecimalPoint = intPlaceDecimalPoint

        txtYaxisMin.MaxLength = intMaxLength
        'txtYaxisMin.MinimumRange = intMinimumRangeY
        'txtYaxisMin.MaximumRange = MaximumRangeY
        txtYaxisMin.DigitsAfterDecimalPoint = intPlaceDecimalPoint

    End Sub

End Class
