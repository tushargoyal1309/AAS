Public Class frmAutoSamplerStatus
    Inherits System.Windows.Forms.Form
#Region "Module lelvel Declaration"
    Dim mblnCancel As Boolean
    Dim mblnCallOnce As Boolean = False
    Dim mintx As Integer = 0
    Dim minty As Integer = -1
    Dim mintAutoSamplerStatus As Int16

#End Region

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
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lblPosition As System.Windows.Forms.Label
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents lblDisplayPosition As System.Windows.Forms.Label
    Friend WithEvents lblPump As System.Windows.Forms.Label
    Friend WithEvents lblProbe As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmAutoSamplerStatus))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lblStatus = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.lblProbe = New System.Windows.Forms.Label
        Me.lblPump = New System.Windows.Forms.Label
        Me.lblDisplayPosition = New System.Windows.Forms.Label
        Me.lblPosition = New System.Windows.Forms.Label
        Me.btnOk = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblStatus)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(256, 64)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Status"
        '
        'lblStatus
        '
        Me.lblStatus.Location = New System.Drawing.Point(16, 24)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(232, 32)
        Me.lblStatus.TabIndex = 0
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lblProbe)
        Me.GroupBox2.Controls.Add(Me.lblPump)
        Me.GroupBox2.Controls.Add(Me.lblDisplayPosition)
        Me.GroupBox2.Controls.Add(Me.lblPosition)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 72)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(256, 144)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'lblProbe
        '
        Me.lblProbe.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProbe.Location = New System.Drawing.Point(16, 64)
        Me.lblProbe.Name = "lblProbe"
        Me.lblProbe.Size = New System.Drawing.Size(112, 23)
        Me.lblProbe.TabIndex = 6
        Me.lblProbe.Text = "Down"
        Me.lblProbe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPump
        '
        Me.lblPump.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPump.Location = New System.Drawing.Point(16, 104)
        Me.lblPump.Name = "lblPump"
        Me.lblPump.Size = New System.Drawing.Size(112, 23)
        Me.lblPump.TabIndex = 5
        Me.lblPump.Text = "OFF"
        Me.lblPump.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDisplayPosition
        '
        Me.lblDisplayPosition.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDisplayPosition.Location = New System.Drawing.Point(16, 24)
        Me.lblDisplayPosition.Name = "lblDisplayPosition"
        Me.lblDisplayPosition.Size = New System.Drawing.Size(112, 23)
        Me.lblDisplayPosition.TabIndex = 4
        Me.lblDisplayPosition.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPosition
        '
        Me.lblPosition.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPosition.Location = New System.Drawing.Point(144, 23)
        Me.lblPosition.Name = "lblPosition"
        Me.lblPosition.Size = New System.Drawing.Size(64, 24)
        Me.lblPosition.TabIndex = 0
        Me.lblPosition.Text = "Position"
        Me.lblPosition.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnOk
        '
        Me.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnOk.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOk.Image = CType(resources.GetObject("btnOk.Image"), System.Drawing.Image)
        Me.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnOk.Location = New System.Drawing.Point(192, 224)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(72, 24)
        Me.btnOk.TabIndex = 2
        Me.btnOk.Text = "&Cancel"
        Me.btnOk.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmAutoSamplerStatus
        '
        Me.AcceptButton = Me.btnOk
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(272, 255)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAutoSamplerStatus"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AutoSampler Status"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Form Events"
    Private Sub frmAllPositions_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        mblnCancel = False
        mintAutoSamplerStatus = enumAutoSamplerOperation.Home
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        mblnCancel = True
    End Sub
#End Region

#Region "General Functions"

    Private Function funcTesting()
        Dim blnFlag As Boolean = False
        Dim intCurrentx As Integer
        Dim intCurrenty As Integer
        Try
            While mblnCancel = False
                Application.DoEvents()
                funcDisplayCurrentStatus(mintAutoSamplerStatus, blnFlag)
                Select Case mintAutoSamplerStatus
                    Case enumAutoSamplerOperation.Home
                        If gobjCommProtocol.funcAutoSamplerHome() Then
                            gstructAutoSampler.blnHome = True
                            gstructAutoSampler.blnCommunication = True
                            gstructAutoSampler.intCoordinateX = 0
                            gstructAutoSampler.intCoordinateY = 0
                            mintAutoSamplerStatus = enumAutoSamplerOperation.Positioning
                        End If

                    Case enumAutoSamplerOperation.Positioning
                        intCurrentx = mintx
                        intCurrenty = minty
                        minty += 1
                        If minty > 5 Then
                            mintx += 1
                            If mintx > 12 Then
                                mintx = 0
                            End If
                            minty = 0
                        End If
                        If gobjCommProtocol.funcAutoSamplerGoTo(mintx, minty, gstructAutoSampler) Then
                            gstructAutoSampler.intCoordinateX = mintx
                            gstructAutoSampler.intCoordinateY = minty
                            mintAutoSamplerStatus = enumAutoSamplerOperation.PumpON
                        Else
                            mintx = intCurrentx
                            minty = intCurrenty
                        End If
                    Case enumAutoSamplerOperation.PumpON
                        If gobjCommProtocol.funcAutoSamplerPumpON() Then
                            gstructAutoSampler.blnPump = True
                            mintAutoSamplerStatus = enumAutoSamplerOperation.ProbeDown
                        End If
                    Case enumAutoSamplerOperation.ProbeDown
                        If gobjCommProtocol.funcAutoSamplerProbeDown() Then
                            gstructAutoSampler.blnProbe = False
                            mintAutoSamplerStatus = enumAutoSamplerOperation.Waiting
                        End If
                    Case enumAutoSamplerOperation.ProbeUp
                        If gobjCommProtocol.funcAutoSamplerProbeUp() Then
                            gstructAutoSampler.blnProbe = True
                            mintAutoSamplerStatus = enumAutoSamplerOperation.PumpOff
                        End If
                    Case enumAutoSamplerOperation.PumpOff
                        If gobjCommProtocol.funcAutoSamplerPumpOFF() Then
                            gstructAutoSampler.blnPump = False
                            mintAutoSamplerStatus = enumAutoSamplerOperation.Positioning
                        End If
                    Case enumAutoSamplerOperation.Waiting
                        'subTime_Delay(gstructAutoSampler.intIntakeTime * 1000)
                        'Call gobjCommProtocol.mobjCommdll.subTime_Delay(gstructAutoSampler.intIntakeTime * 1000)'Commented by pankaj on 25 Mar 08
                        Call gobjCommProtocol.mobjCommdllAutoSampler.subTime_Delay(gstructAutoSampler.intIntakeTime * 1000) 'added by pankaj on 25 Mar 08
                        mintAutoSamplerStatus = enumAutoSamplerOperation.ProbeUp
                End Select
                Application.DoEvents()
            End While

            If gobjCommProtocol.funcAutoSamplerPumpOFF() Then
                gstructAutoSampler.blnPump = False
            End If
            If gobjCommProtocol.funcAutoSamplerProbeUp() Then
                gstructAutoSampler.blnProbe = True
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
            '---------------------------------------------------------
        End Try


    End Function

    Public Function funcDisplayCurrentStatus(ByVal intStatus As Int16, ByVal blnFlag As Boolean)
        Try
            Select Case intStatus
                Case 0
                    lblStatus.Text = "Setting Home"
                Case 1
                    lblStatus.Text = "Positioning "
                Case 2
                    lblStatus.Text = "Setting Pump ON"
                Case 3
                    lblStatus.Text = "Setting Probe Down"
                Case 4
                    lblStatus.Text = "Setting Probe UP"
                Case 5
                    lblStatus.Text = "Setting Pump OFF"
                Case 6
                    lblStatus.Text = "Waiting "
            End Select
            Call funcDisplayStatus()

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

    Public Function funcDisplayStatus()
        Try
            If gstructAutoSampler.intCoordinateX >= 0 And gstructAutoSampler.intCoordinateY >= 0 Then
                lblDisplayPosition.Text = "X  = " & gstructAutoSampler.intCoordinateX & ",Y =  " & gstructAutoSampler.intCoordinateY
            Else
                lblDisplayPosition.Text = " "
            End If
            If gstructAutoSampler.blnProbe = True Then
                lblProbe.Text = "Probe UP"
            Else
                lblProbe.Text = "Probe DOWN"
            End If

            If gstructAutoSampler.blnPump = True Then
                lblPump.Text = "Pump ON "
            Else
                lblPump.Text = "Pump OFF"
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

    Private Sub frmAllPositions_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        Try
            If mblnCallOnce = False Then
                mblnCallOnce = True
                Call funcTesting()
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
