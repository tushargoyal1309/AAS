Public Class AutoSamplerInterface
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
    Friend WithEvents lblProbe As System.Windows.Forms.Label
    Friend WithEvents lblPump As System.Windows.Forms.Label
    Friend WithEvents lblIntakeTime As System.Windows.Forms.Label
    Friend WithEvents lblWashTime As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents gbCommands As System.Windows.Forms.GroupBox
    Friend WithEvents gbStatus As System.Windows.Forms.GroupBox
    Friend WithEvents gbTime As System.Windows.Forms.GroupBox
    Friend WithEvents lblPosition As System.Windows.Forms.Label
    Friend WithEvents lblHome As System.Windows.Forms.Label
    Friend WithEvents btnSamplerHome As System.Windows.Forms.Button
    Friend WithEvents btnGoto As System.Windows.Forms.Button
    Friend WithEvents btnProbe As System.Windows.Forms.Button
    Friend WithEvents btnPumpRev As System.Windows.Forms.Button
    Friend WithEvents btnTest As System.Windows.Forms.Button
    Friend WithEvents lblHomeStatus As System.Windows.Forms.Label
    Friend WithEvents lblPositionStatus As System.Windows.Forms.Label
    Friend WithEvents lblProbeStatus As System.Windows.Forms.Label
    Friend WithEvents lblPumpStatus As System.Windows.Forms.Label
    Friend WithEvents lblPumpRevStatus As System.Windows.Forms.Label
    Friend WithEvents btnPumpForward As System.Windows.Forms.Button
    Friend WithEvents txtWashTime As NumberValidator.NumberValidator
    Friend WithEvents txtIntakeTime As NumberValidator.NumberValidator
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(AutoSamplerInterface))
        Me.gbCommands = New System.Windows.Forms.GroupBox
        Me.btnTest = New System.Windows.Forms.Button
        Me.btnPumpRev = New System.Windows.Forms.Button
        Me.btnPumpForward = New System.Windows.Forms.Button
        Me.btnProbe = New System.Windows.Forms.Button
        Me.btnGoto = New System.Windows.Forms.Button
        Me.btnSamplerHome = New System.Windows.Forms.Button
        Me.gbStatus = New System.Windows.Forms.GroupBox
        Me.lblPumpRevStatus = New System.Windows.Forms.Label
        Me.lblPumpStatus = New System.Windows.Forms.Label
        Me.lblProbeStatus = New System.Windows.Forms.Label
        Me.lblPositionStatus = New System.Windows.Forms.Label
        Me.lblHomeStatus = New System.Windows.Forms.Label
        Me.lblHome = New System.Windows.Forms.Label
        Me.lblPosition = New System.Windows.Forms.Label
        Me.lblPump = New System.Windows.Forms.Label
        Me.lblProbe = New System.Windows.Forms.Label
        Me.gbTime = New System.Windows.Forms.GroupBox
        Me.txtIntakeTime = New NumberValidator.NumberValidator
        Me.txtWashTime = New NumberValidator.NumberValidator
        Me.lblWashTime = New System.Windows.Forms.Label
        Me.lblIntakeTime = New System.Windows.Forms.Label
        Me.btnCancel = New System.Windows.Forms.Button
        Me.gbCommands.SuspendLayout()
        Me.gbStatus.SuspendLayout()
        Me.gbTime.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbCommands
        '
        Me.gbCommands.Controls.Add(Me.btnTest)
        Me.gbCommands.Controls.Add(Me.btnPumpRev)
        Me.gbCommands.Controls.Add(Me.btnPumpForward)
        Me.gbCommands.Controls.Add(Me.btnProbe)
        Me.gbCommands.Controls.Add(Me.btnGoto)
        Me.gbCommands.Controls.Add(Me.btnSamplerHome)
        Me.gbCommands.Location = New System.Drawing.Point(6, 0)
        Me.gbCommands.Name = "gbCommands"
        Me.gbCommands.Size = New System.Drawing.Size(176, 304)
        Me.gbCommands.TabIndex = 0
        Me.gbCommands.TabStop = False
        Me.gbCommands.Text = "AutoSampler Commands"
        '
        'btnTest
        '
        Me.btnTest.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnTest.Location = New System.Drawing.Point(16, 264)
        Me.btnTest.Name = "btnTest"
        Me.btnTest.Size = New System.Drawing.Size(144, 32)
        Me.btnTest.TabIndex = 5
        Me.btnTest.Text = "&Test All Positions"
        '
        'btnPumpRev
        '
        Me.btnPumpRev.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnPumpRev.Location = New System.Drawing.Point(16, 216)
        Me.btnPumpRev.Name = "btnPumpRev"
        Me.btnPumpRev.Size = New System.Drawing.Size(144, 32)
        Me.btnPumpRev.TabIndex = 4
        Me.btnPumpRev.Text = "Pump ON (&R)"
        '
        'btnPumpForward
        '
        Me.btnPumpForward.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnPumpForward.Location = New System.Drawing.Point(16, 168)
        Me.btnPumpForward.Name = "btnPumpForward"
        Me.btnPumpForward.Size = New System.Drawing.Size(144, 32)
        Me.btnPumpForward.TabIndex = 3
        Me.btnPumpForward.Text = "Pump ON (&F)"
        '
        'btnProbe
        '
        Me.btnProbe.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnProbe.Location = New System.Drawing.Point(16, 120)
        Me.btnProbe.Name = "btnProbe"
        Me.btnProbe.Size = New System.Drawing.Size(144, 32)
        Me.btnProbe.TabIndex = 2
        Me.btnProbe.Text = "&Probe Down"
        '
        'btnGoto
        '
        Me.btnGoto.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnGoto.Location = New System.Drawing.Point(16, 72)
        Me.btnGoto.Name = "btnGoto"
        Me.btnGoto.Size = New System.Drawing.Size(144, 32)
        Me.btnGoto.TabIndex = 1
        Me.btnGoto.Text = "&Go To"
        '
        'btnSamplerHome
        '
        Me.btnSamplerHome.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSamplerHome.Location = New System.Drawing.Point(16, 24)
        Me.btnSamplerHome.Name = "btnSamplerHome"
        Me.btnSamplerHome.Size = New System.Drawing.Size(144, 32)
        Me.btnSamplerHome.TabIndex = 0
        Me.btnSamplerHome.Text = "Sampler &Home"
        '
        'gbStatus
        '
        Me.gbStatus.Controls.Add(Me.lblPumpRevStatus)
        Me.gbStatus.Controls.Add(Me.lblPumpStatus)
        Me.gbStatus.Controls.Add(Me.lblProbeStatus)
        Me.gbStatus.Controls.Add(Me.lblPositionStatus)
        Me.gbStatus.Controls.Add(Me.lblHomeStatus)
        Me.gbStatus.Controls.Add(Me.lblHome)
        Me.gbStatus.Controls.Add(Me.lblPosition)
        Me.gbStatus.Controls.Add(Me.lblPump)
        Me.gbStatus.Controls.Add(Me.lblProbe)
        Me.gbStatus.Location = New System.Drawing.Point(190, 0)
        Me.gbStatus.Name = "gbStatus"
        Me.gbStatus.Size = New System.Drawing.Size(232, 192)
        Me.gbStatus.TabIndex = 1
        Me.gbStatus.TabStop = False
        Me.gbStatus.Text = " AutoSampler Status"
        '
        'lblPumpRevStatus
        '
        Me.lblPumpRevStatus.Location = New System.Drawing.Point(96, 144)
        Me.lblPumpRevStatus.Name = "lblPumpRevStatus"
        Me.lblPumpRevStatus.Size = New System.Drawing.Size(128, 24)
        Me.lblPumpRevStatus.TabIndex = 14
        Me.lblPumpRevStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPumpStatus
        '
        Me.lblPumpStatus.Location = New System.Drawing.Point(96, 144)
        Me.lblPumpStatus.Name = "lblPumpStatus"
        Me.lblPumpStatus.Size = New System.Drawing.Size(128, 24)
        Me.lblPumpStatus.TabIndex = 13
        Me.lblPumpStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblPumpStatus.Visible = False
        '
        'lblProbeStatus
        '
        Me.lblProbeStatus.Location = New System.Drawing.Point(96, 104)
        Me.lblProbeStatus.Name = "lblProbeStatus"
        Me.lblProbeStatus.Size = New System.Drawing.Size(128, 24)
        Me.lblProbeStatus.TabIndex = 12
        Me.lblProbeStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPositionStatus
        '
        Me.lblPositionStatus.Location = New System.Drawing.Point(96, 64)
        Me.lblPositionStatus.Name = "lblPositionStatus"
        Me.lblPositionStatus.Size = New System.Drawing.Size(128, 24)
        Me.lblPositionStatus.TabIndex = 11
        Me.lblPositionStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblHomeStatus
        '
        Me.lblHomeStatus.Location = New System.Drawing.Point(96, 24)
        Me.lblHomeStatus.Name = "lblHomeStatus"
        Me.lblHomeStatus.Size = New System.Drawing.Size(128, 24)
        Me.lblHomeStatus.TabIndex = 10
        Me.lblHomeStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblHome
        '
        Me.lblHome.Location = New System.Drawing.Point(20, 24)
        Me.lblHome.Name = "lblHome"
        Me.lblHome.Size = New System.Drawing.Size(64, 24)
        Me.lblHome.TabIndex = 9
        Me.lblHome.Text = "Home"
        Me.lblHome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPosition
        '
        Me.lblPosition.Location = New System.Drawing.Point(20, 64)
        Me.lblPosition.Name = "lblPosition"
        Me.lblPosition.Size = New System.Drawing.Size(64, 24)
        Me.lblPosition.TabIndex = 8
        Me.lblPosition.Text = "Position"
        Me.lblPosition.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPump
        '
        Me.lblPump.Location = New System.Drawing.Point(20, 144)
        Me.lblPump.Name = "lblPump"
        Me.lblPump.Size = New System.Drawing.Size(64, 24)
        Me.lblPump.TabIndex = 3
        Me.lblPump.Text = "Pump"
        Me.lblPump.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblProbe
        '
        Me.lblProbe.Location = New System.Drawing.Point(20, 104)
        Me.lblProbe.Name = "lblProbe"
        Me.lblProbe.Size = New System.Drawing.Size(64, 24)
        Me.lblProbe.TabIndex = 2
        Me.lblProbe.Text = "Probe"
        Me.lblProbe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'gbTime
        '
        Me.gbTime.Controls.Add(Me.txtIntakeTime)
        Me.gbTime.Controls.Add(Me.txtWashTime)
        Me.gbTime.Controls.Add(Me.lblWashTime)
        Me.gbTime.Controls.Add(Me.lblIntakeTime)
        Me.gbTime.Location = New System.Drawing.Point(190, 208)
        Me.gbTime.Name = "gbTime"
        Me.gbTime.Size = New System.Drawing.Size(232, 96)
        Me.gbTime.TabIndex = 2
        Me.gbTime.TabStop = False
        Me.gbTime.Text = "Select Time"
        '
        'txtIntakeTime
        '
        Me.txtIntakeTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIntakeTime.DigitsAfterDecimalPoint = 0
        Me.txtIntakeTime.ErrorColor = System.Drawing.Color.Empty
        Me.txtIntakeTime.ErrorMessage = Nothing
        Me.txtIntakeTime.Location = New System.Drawing.Point(168, 29)
        Me.txtIntakeTime.MaximumRange = 999
        Me.txtIntakeTime.MinimumRange = 1
        Me.txtIntakeTime.Name = "txtIntakeTime"
        Me.txtIntakeTime.RangeValidation = False
        Me.txtIntakeTime.Size = New System.Drawing.Size(56, 21)
        Me.txtIntakeTime.TabIndex = 5
        Me.txtIntakeTime.Text = ""
        Me.txtIntakeTime.ValidationType = NumberValidator.NumberValidator.Validations.IntegerOnly
        '
        'txtWashTime
        '
        Me.txtWashTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtWashTime.DigitsAfterDecimalPoint = 0
        Me.txtWashTime.ErrorColor = System.Drawing.Color.Empty
        Me.txtWashTime.ErrorMessage = Nothing
        Me.txtWashTime.Location = New System.Drawing.Point(168, 69)
        Me.txtWashTime.MaximumRange = 999
        Me.txtWashTime.MinimumRange = 1
        Me.txtWashTime.Name = "txtWashTime"
        Me.txtWashTime.RangeValidation = False
        Me.txtWashTime.Size = New System.Drawing.Size(56, 21)
        Me.txtWashTime.TabIndex = 4
        Me.txtWashTime.Text = ""
        Me.txtWashTime.ValidationType = NumberValidator.NumberValidator.Validations.IntegerOnly
        '
        'lblWashTime
        '
        Me.lblWashTime.Location = New System.Drawing.Point(8, 64)
        Me.lblWashTime.Name = "lblWashTime"
        Me.lblWashTime.Size = New System.Drawing.Size(152, 24)
        Me.lblWashTime.TabIndex = 1
        Me.lblWashTime.Text = "Sample Wash Time (Secs)"
        Me.lblWashTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblIntakeTime
        '
        Me.lblIntakeTime.Location = New System.Drawing.Point(8, 24)
        Me.lblIntakeTime.Name = "lblIntakeTime"
        Me.lblIntakeTime.Size = New System.Drawing.Size(152, 24)
        Me.lblIntakeTime.TabIndex = 0
        Me.lblIntakeTime.Text = "Sample IntakeTime (secs)"
        Me.lblIntakeTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCancel.Image = CType(resources.GetObject("btnCancel.Image"), System.Drawing.Image)
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancel.Location = New System.Drawing.Point(350, 312)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(72, 24)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'AutoSamplerInterface
        '
        Me.AcceptButton = Me.btnCancel
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(427, 343)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.gbTime)
        Me.Controls.Add(Me.gbStatus)
        Me.Controls.Add(Me.gbCommands)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AutoSamplerInterface"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AutoSampler Interface"
        Me.gbCommands.ResumeLayout(False)
        Me.gbStatus.ResumeLayout(False)
        Me.gbTime.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region
    Dim mintx As Integer = 0
    Dim minty As Integer = 0
    Dim mblnAvoidProcessing As Boolean = False
   
    Private Sub txtIntakeTime_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        'mfuncAceptInteger(txtIntakeTime, e)
    End Sub

    Private Sub txtWashTime_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        'mfuncAceptInteger(txtWashTime, e)
    End Sub

    Private Sub AutoSamplerInterface_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call funcFormInitialise()
    End Sub

    Private Function funcDisplayStatus()
        Try
            If gstructAutoSampler.blnHome = True Then
                lblHomeStatus.Text = "OK"
            Else
                lblHomeStatus.Text = "ERROR"
            End If
            If gstructAutoSampler.intCoordinateX >= 0 And gstructAutoSampler.intCoordinateY >= 0 Then
                lblPositionStatus.Text = "X  = " & gstructAutoSampler.intCoordinateX & ",Y =  " & gstructAutoSampler.intCoordinateY
            Else
                lblPositionStatus.Text = " "
            End If
            If gstructAutoSampler.blnProbe = True Then
                lblProbeStatus.Text = "Probe UP"
            Else
                lblProbeStatus.Text = "Probe DOWN"
            End If

            If gstructAutoSampler.blnPump = True Then
                lblPumpStatus.Text = "Pump ON (F)"
            Else
                lblPumpStatus.Text = "Pump OFF"
            End If
            If gstructAutoSampler.blnPumpPrev = True Then
                lblPumpRevStatus.Text = "Pump ON (R)"
            Else
                lblPumpRevStatus.Text = "Pump OFF"
            End If
            Call funcShowButtons()
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

    Private Function funcShowButtons()
        Try
            If gstructAutoSampler.blnProbe = True Then
                btnProbe.Text = "Probe Down"
            Else
                btnProbe.Text = "Probe Up"
            End If
            If gstructAutoSampler.blnPump = True Then
                btnPumpForward.Text = "Pump OFF"
            Else
                btnPumpForward.Text = "Pump ON (F)"
            End If
            If gstructAutoSampler.blnPumpPrev = True Then
                btnPumpRev.Text = "Pump OFF"
            Else
                btnPumpRev.Text = "Pump ON (R)"
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

    End Function

    Private Function funcFormInitialise()
        Try
            If gobjCommProtocol.funcAutoSamplerHome() Then
                gstructAutoSampler.blnHome = True
                gstructAutoSampler.blnCommunication = True
                gstructAutoSampler.intCoordinateX = 0
                gstructAutoSampler.intCoordinateY = 0
            End If
            If gobjCommProtocol.funcAutoSamplerGoTo(0, 0, gstructAutoSampler) Then
                mintx = 0
                minty = 0
                gstructAutoSampler.intCoordinateX = 0
                gstructAutoSampler.intCoordinateY = 0
            End If

            If gobjCommProtocol.funcAutoSamplerProbeUp() Then
                gstructAutoSampler.blnProbe = True
            End If

            gstructAutoSampler.blnPump = True
            gstructAutoSampler.blnPumpPrev = True

            If gobjCommProtocol.funcAutoSamplerPumpOFF() Then
                gstructAutoSampler.blnPump = False
                gstructAutoSampler.blnPumpPrev = False
            End If

            Call funcDisplayStatus()
            txtIntakeTime.Text = gstructAutoSampler.intIntakeTime.ToString
            txtWashTime.Text = gstructAutoSampler.intWashTime.ToString

            'code added by ; dinesh wagh on 22.1.2010
            'Purpose : to remove pump buttons as there is no motor in AAS autosampler.
            '------------------------------------
            btnPumpForward.Visible = False
            btnPumpRev.Visible = False
            lblPump.Visible = False
            lblPumpRevStatus.Visible = False
            Me.Height -= 60
            btnGoto.Location = New Point(16, 80)
            btnProbe.Location = New Point(16, 140)
            btnTest.Location = New Point(16, 200)
            btnCancel.Location = New Point(350, 250)
            gbTime.Location = New Point(190, 150)
            gbCommands.Height = gbTime.Top + gbTime.Height
            gbStatus.Height -= 50
            '-------------------------------------



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

    'Private Sub txtIntakeTime_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
    '    Try
    '        If Val(txtIntakeTime.Text) >= 1 Or Val(txtIntakeTime.Text) < 1000 Then
    '            gstructAutoSampler.intIntakeTime = CInt(txtIntakeTime.Text)
    '        ElseIf Val(txtIntakeTime.Text) <> 0 Then
    '            'gFuncShowMessage("Invalid Input", "Enter intake time  between 1 and 999", EnumMessageType.Information)
    '            Call gobjMessageAdapter.ShowMessage("Enter intake time  between 1 and 999", "Invalid Input", EnumMessageType.Information)
    '            txtIntakeTime.Focus()
    '            e.Cancel = True
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

    'Private Sub txtWashTime_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
    '    Try
    '        If Val(txtWashTime.Text) >= 1 Or Val(txtWashTime.Text) < 1000 Then
    '            gstructAutoSampler.intWashTime = CInt(txtWashTime.Text)
    '        ElseIf Val(txtWashTime.Text) <> 0 Then
    '            Call gobjMessageAdapter.ShowMessage("Enter wash time between 1 and 999", "Invalid Input", EnumMessageType.Information)
    '            txtWashTime.Focus()
    '            e.Cancel = True
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

    Private Sub btnSamplerHome_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSamplerHome.Click

        If mblnAvoidProcessing = True Then
            Exit Sub
        End If

        Try
            mblnAvoidProcessing = True
            gstructAutoSampler.blnHome = False

            If gobjCommProtocol.funcAutoSamplerHome() Then
                gstructAutoSampler.blnHome = True
                gstructAutoSampler.intCoordinateX = 0
                gstructAutoSampler.intCoordinateY = 0

            End If

            funcDisplayStatus()

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
            '---------------------------------------------------------
        End Try


    End Sub

    Private Sub btnGoto_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGoto.Click
        Dim objFrmEditValues As New frmCoordinatePositions(mintx, minty)

        If mblnAvoidProcessing = True Then
            Exit Sub
        End If

        Try
            mblnAvoidProcessing = True
            If Not gobjCommProtocol.funcAutoSamplerHome() Then
                Call gobjMessageAdapter.ShowMessage(constErrorAutoSamplerHome)
                Exit Sub
            Else
                gstructAutoSampler.blnHome = True
                gstructAutoSampler.blnCommunication = True
                gstructAutoSampler.intCoordinateX = 0
                gstructAutoSampler.intCoordinateY = 0
            End If

            objFrmEditValues.ShowDialog()
            Application.DoEvents()
            mintx = objFrmEditValues.mintXCoordinate
            minty = objFrmEditValues.mintYCoordinate

            If gobjCommProtocol.funcAutoSamplerGoTo(CByte(mintx), CByte(minty), gstructAutoSampler) Then
                gstructAutoSampler.intCoordinateX = mintx
                gstructAutoSampler.intCoordinateY = minty
            End If

            funcDisplayStatus()
            objFrmEditValues.Dispose()

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
            '---------------------------------------------------------
        End Try

    End Sub

    Private Sub btnPumpForward_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPumpForward.Click
        If mblnAvoidProcessing = True Then
            Exit Sub
        End If

        Try
            mblnAvoidProcessing = True
            lblPumpStatus.Visible = True
            lblPumpRevStatus.Visible = False
            If gstructAutoSampler.blnPump = True Then
                If gobjCommProtocol.funcAutoSamplerPumpOFF() Then
                    gstructAutoSampler.blnPump = False
                End If

            Else
                If gobjCommProtocol.funcAutoSamplerPumpON() Then
                    gstructAutoSampler.blnPump = True
                End If
            End If
            funcDisplayStatus()

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
            '---------------------------------------------------------
        End Try


    End Sub

    Private Sub btnPumpRev_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPumpRev.Click
        If mblnAvoidProcessing = True Then
            Exit Sub
        End If

        Try
            mblnAvoidProcessing = True
            lblPumpStatus.Visible = False
            lblPumpRevStatus.Visible = True

            If gstructAutoSampler.blnPumpPrev Then
                If gobjCommProtocol.funcAutoSamplerPumpOFF() Then
                    gstructAutoSampler.blnPumpPrev = False
                End If
            Else
                If gobjCommProtocol.funcAutoSamplerPumpONRev() Then
                    gstructAutoSampler.blnPumpPrev = True
                End If
            End If
            funcDisplayStatus()
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
            '---------------------------------------------------------
        End Try


    End Sub

    Private Sub btnProbe_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnProbe.Click
        If mblnAvoidProcessing = True Then
            Exit Sub
        End If

        Try
            mblnAvoidProcessing = True
            If gstructAutoSampler.blnProbe = True Then
                If gobjCommProtocol.funcAutoSamplerProbeDown() Then
                    gstructAutoSampler.blnProbe = False
                End If
            Else
                If gobjCommProtocol.funcAutoSamplerProbeUp() Then
                    gstructAutoSampler.blnProbe = True
                End If
            End If
            funcDisplayStatus()
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
            '---------------------------------------------------------
        End Try


    End Sub

    Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If mblnAvoidProcessing = True Then
            Exit Sub
        End If

        Try
            mblnAvoidProcessing = True
            Call gfuncWriteSamplerParametersToINI(gstructAutoSampler)
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
            '---------------------------------------------------------
        End Try

    End Sub

    Private Sub btnTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTest.Click
        Dim objFrmAllPosition As New frmAutoSamplerStatus
        If mblnAvoidProcessing = True Then
            Exit Sub
        End If

        Try
            '//----- Added by Pankaj on 25 03 08
            If Not ((gstructSettings.AppMode = EnumAppMode.DemoMode) Or _
                                (gstructSettings.AppMode = EnumAppMode.DemoMode_201) Or _
                                (gstructSettings.AppMode = EnumAppMode.DemoMode_203D)) Then
                If Not gstructSettings.ExeToRun = EnumApplicationMode.ServiceUtility Then
                    If Not IsNothing(gobjMain) Then
                        If gobjMain.mobjController.IsThreadRunning = True Then
                            gobjMain.mobjController.Cancel()
                            gobjCommProtocol.mobjCommdll.subTime_Delay(500)   '10.12.07
                            Application.DoEvents()
                        End If
                    End If
                End If
            End If
            '//-----
            mblnAvoidProcessing = True
            Me.Enabled = False
            objFrmAllPosition.ShowDialog()
            objFrmAllPosition.Dispose()
            Me.Enabled = True
            '//----- Added by pankaj on 25.03.08
            If Not ((gstructSettings.AppMode = EnumAppMode.DemoMode) Or _
                                (gstructSettings.AppMode = EnumAppMode.DemoMode_201) Or _
                                (gstructSettings.AppMode = EnumAppMode.DemoMode_203D)) Then
                If Not gstructSettings.ExeToRun = EnumApplicationMode.ServiceUtility Then
                    If Not IsNothing(gobjMain) Then
                        If gobjMain.mobjController.IsThreadRunning = False Then
                            gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay)
                            Application.DoEvents()
                            gobjMain.mobjController.Start(gobjclsBgFlameStatus)
                        End If
                    End If
                End If
            End If
            '//--
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
            '---------------------------------------------------------
        End Try

    End Sub
End Class
