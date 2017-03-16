Option Explicit On 

Imports Microsoft.Win32

Public Class frmAutoSamplerComPort
    Inherits System.Windows.Forms.Form
    Dim mblnCommSelectionOnce As Boolean = False
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
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents cboPort_Selection As System.Windows.Forms.ComboBox
    Friend WithEvents lblPort_Selection As System.Windows.Forms.Label
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmAutoSamplerComPort))
        Me.cmdOk = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.cboPort_Selection = New System.Windows.Forms.ComboBox
        Me.lblPort_Selection = New System.Windows.Forms.Label
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdOk
        '
        Me.cmdOk.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdOk.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOk.Image = CType(resources.GetObject("cmdOk.Image"), System.Drawing.Image)
        Me.cmdOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdOk.Location = New System.Drawing.Point(144, 136)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(70, 30)
        Me.cmdOk.TabIndex = 4
        Me.cmdOk.Text = "&Ok"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel1.Controls.Add(Me.cboPort_Selection)
        Me.Panel1.Controls.Add(Me.lblPort_Selection)
        Me.Panel1.Location = New System.Drawing.Point(3, 8)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(287, 116)
        Me.Panel1.TabIndex = 3
        '
        'cboPort_Selection
        '
        Me.cboPort_Selection.BackColor = System.Drawing.Color.AliceBlue
        Me.cboPort_Selection.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPort_Selection.Location = New System.Drawing.Point(136, 82)
        Me.cboPort_Selection.Name = "cboPort_Selection"
        Me.cboPort_Selection.Size = New System.Drawing.Size(106, 23)
        Me.cboPort_Selection.TabIndex = 1
        '
        'lblPort_Selection
        '
        Me.lblPort_Selection.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPort_Selection.Location = New System.Drawing.Point(10, 8)
        Me.lblPort_Selection.Name = "lblPort_Selection"
        Me.lblPort_Selection.Size = New System.Drawing.Size(274, 70)
        Me.lblPort_Selection.TabIndex = 0
        Me.lblPort_Selection.Text = "Select one of the serial communication ports attached to the Autosampler"
        Me.lblPort_Selection.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmdCancel
        '
        Me.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdCancel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancel.Image = CType(resources.GetObject("cmdCancel.Image"), System.Drawing.Image)
        Me.cmdCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancel.Location = New System.Drawing.Point(216, 136)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(70, 30)
        Me.cmdCancel.TabIndex = 5
        Me.cmdCancel.Text = "E&xit"
        '
        'frmAutoSamplerComPort
        '
        Me.AcceptButton = Me.cmdOk
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(292, 167)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.cmdCancel)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAutoSamplerComPort"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AutoSampler Comm Port Selection"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        Try

            'If gstructAutoSampler.blnAutoSamplerInitialised Then
            '    If gintCommPortSelected2 = cboPort_Selection.SelectedIndex + 1 Then
            '        If gFuncIsPortOpen2() Then
            '            gFuncShowMessage("Port Already Open", "The selected port is in use, Please try with Other Ports", modConstants.EnumMessageType.Information)
            '            Exit Sub
            '        End If
            '    End If
            'End If

            'If gFuncIsPortOpen2() Then
            '    gFuncCloseComm2()
            'End If

            'gintCommPortSelected2 = cboPort_Selection.SelectedIndex + 1

            'If Not gFuncISPortAvailable(gintCommPortSelected2) Then
            '    gFuncShowMessage("Selected Communication Port Not Available ...", "Please Try Using Another Communication Port", modConstants.EnumMessageType.Information)
            '    gintCommPortSelected2 = 0
            'Else

            '    If Not gFuncOpenCommPort2(gintCommPortSelected2, gstructAutoSampler.intBaudRate, 0, 1, 8) Then
            '        gFuncShowMessage("Communication Port Busy ...", "Selected Communication Port Used By Another Program " & vbCrLf & "Please Try Using Another Communication Port", modConstants.EnumMessageType.Information)
            '        gstructAutoSampler.blnCommunication = False
            '    Else
            '        gstructAutoSampler.blnCommunication = True
            '        '--- write the port to ini 
            '        gFuncWriteToINI(SECTION_AUTOSAMPLER, KEY_SERIALPORT, CStr(gintCommPortSelected2), INI_SETTINGS_PATH)
            '    End If
            '    Call gFuncInitSampler(gstructAutoSampler)
            '    Me.Close()
            'End If 
            '//----- Add by Sachi Dokhale on 14.12.05
            If cboPort_Selection.SelectedIndex > -1 Then
                '//----- Commited by Sachin Dokhale on 17.12.05
                'gintCommPortSelected2 = cboPort_Selection.SelectedIndex + 1
                '//-----
                '//----- Added by Sachin Dokhale on 17.12.05
                gintCommPortSelected2 = gintCommPort(cboPort_Selection.SelectedIndex)
                '//----- 
            Else
                gintCommPortSelected2 = 1 'cboPort_Selection.SelectedIndex
            End If
            gstructAutoSampler.intComPort = gintCommPortSelected2
            gfuncWriteSamplerParametersToINI(gstructAutoSampler)

            Me.Close()
            '//-----

            Call gFuncInitSampler(gstructAutoSampler)
            Me.Close()



            'added and commented by kamal on 19March2004
            '----------------------------
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gintCommPortSelected2 = 0
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

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Application.DoEvents()
        gintCommPortSelected2 = 0
        Me.Close()
    End Sub

    Private Sub frmAutoSamplerComPort_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim intPorts, i As Integer
        Try
            'lblPort_Selection.Text = "Select Proper RS232 Communication Port"
            ' Call gfuncInitialiseGlobalValues(gstructAutoSampler)
            intPorts = gFuncGetAvailbleCommPorts()

            If Not mblnCommSelectionOnce Then
                mblnCommSelectionOnce = True
                '//----- Commited by Sachin Dokhale on 17.12.05
                'For i = 0 To intPorts - 1
                '   cboPort_Selection.Items.Insert(i, "COM" + CStr(i + 1))
                'Next
                '//-----
                '//----- Added by Sachin Dokhale on 17.12.05
                For i = 0 To gintCommPort.GetUpperBound(0)

                    cboPort_Selection.Items.Insert(i, "COM" + CStr(gintCommPort(i)))
                Next
                '//-----
            End If
            Call gfuncReadSamplerParameterFromINI(gstructAutoSampler)
            gintCommPortSelected2 = gstructAutoSampler.intComPort
            If gintCommPortSelected2 > 0 Then

                '//----- Added by Sachin Dokhale on 17.12.05
                If gintCommPortSelected2 > gintCommPort(gintCommPort.GetUpperBound(0)) Then
                    gintCommPortSelected2 = gintCommPort(gintCommPort.GetUpperBound(0))
                    cboPort_Selection.SelectedIndex = gintCommPort.GetUpperBound(0) 'gintCommPortSelected2

                Else
                    For i = 0 To gintCommPort.GetUpperBound(0)
                        If gintCommPort(i) = gintCommPortSelected2 Then
                            cboPort_Selection.SelectedIndex = i
                            Exit For
                        End If

                    Next

                End If
                '//-----

            Else
                cboPort_Selection.SelectedIndex = 0
            End If

            If gobjCommProtocol.mobjCommdll.gFuncIsPortOpen2() Then
                gobjCommProtocol.mobjCommdll.gFuncCloseComm2()
            End If
            'added and commented by kamal on 19March2004
            '----------------------------
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


    Private Sub frmAutoSamplerComPort_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.VisibleChanged
        Application.DoEvents()
    End Sub

    Private Sub frmAutoSamplerComPort_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Leave
        Application.DoEvents()
    End Sub
End Class
