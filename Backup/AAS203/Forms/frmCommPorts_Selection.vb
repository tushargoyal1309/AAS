Option Explicit On 

Imports Microsoft.Win32

Public Class frmCommPorts_Selection ''class behind the class
    Inherits System.Windows.Forms.Form

    Private mblnCommSelectionOnce As Boolean = False
    Private mintCommPortSelected As Integer
    Private mblnInProcess As Boolean = False
    Dim objfrmAASInitialisation As frmAASInitialisation

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
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents cboPort_Selection As System.Windows.Forms.ComboBox
    Friend WithEvents lblPort_Selection As System.Windows.Forms.Label
    Friend WithEvents cmdCancel As NETXP.Controls.XPButton
    Friend WithEvents cmdOK As NETXP.Controls.XPButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmCommPorts_Selection))
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.cboPort_Selection = New System.Windows.Forms.ComboBox
        Me.lblPort_Selection = New System.Windows.Forms.Label
        Me.cmdCancel = New NETXP.Controls.XPButton
        Me.cmdOK = New NETXP.Controls.XPButton
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel1.Controls.Add(Me.cboPort_Selection)
        Me.Panel1.Controls.Add(Me.lblPort_Selection)
        Me.Panel1.Location = New System.Drawing.Point(3, 42)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(287, 118)
        Me.Panel1.TabIndex = 0
        '
        'cboPort_Selection
        '
        Me.cboPort_Selection.BackColor = System.Drawing.Color.White
        Me.cboPort_Selection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPort_Selection.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPort_Selection.Location = New System.Drawing.Point(136, 82)
        Me.cboPort_Selection.Name = "cboPort_Selection"
        Me.cboPort_Selection.Size = New System.Drawing.Size(106, 23)
        Me.cboPort_Selection.TabIndex = 1
        '
        'lblPort_Selection
        '
        Me.lblPort_Selection.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPort_Selection.Location = New System.Drawing.Point(10, 9)
        Me.lblPort_Selection.Name = "lblPort_Selection"
        Me.lblPort_Selection.Size = New System.Drawing.Size(270, 70)
        Me.lblPort_Selection.TabIndex = 0
        Me.lblPort_Selection.Text = "Select one of the serial communication ports attached to the instrument"
        Me.lblPort_Selection.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmdCancel
        '
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdCancel.Image = CType(resources.GetObject("cmdCancel.Image"), System.Drawing.Image)
        Me.cmdCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancel.Location = New System.Drawing.Point(200, 184)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(86, 34)
        Me.cmdCancel.TabIndex = 12
        Me.cmdCancel.Text = "&Exit"
        '
        'cmdOK
        '
        Me.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdOK.Image = CType(resources.GetObject("cmdOK.Image"), System.Drawing.Image)
        Me.cmdOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdOK.Location = New System.Drawing.Point(88, 184)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(86, 34)
        Me.cmdOK.TabIndex = 11
        Me.cmdOK.Text = "&OK"
        '
        'frmCommPorts_Selection
        '
        Me.AcceptButton = Me.cmdOK
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.CancelButton = Me.cmdCancel
        Me.ClientSize = New System.Drawing.Size(296, 243)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOK)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCommPorts_Selection"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Comm Port Selection"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Private Functions "

    Private Sub frmCommPorts_Selection_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '---------------------------------------------------------------------------------
        'Procedure Name	    :   frmCommPorts_Selection_Load
        'Description	    :   
        'Parameters 	    :   None 
        'Time/Date  	    :   13.03.07
        'Dependencies	    :   
        'Author		        :   Sachin Dokhale
        'Revision		    :   
        'Revision by Person	:   praveen
        '---------------------------------------------------------------------------------
        Dim intPorts, i As Integer

        Try
            lblPort_Selection.Text = "Select Proper RS232 Communication Port"
            '---get available comm ports count
            intPorts = gFuncGetAvailbleCommPorts()
            ''this will get a all availble port to a inte.
            mintCommPortSelected = gintCommPortSelected

            If Not mblnCommSelectionOnce Then
                ''check for flag 
                mblnCommSelectionOnce = True
                '//----- Commited by Sachin Dokhale on 17.12.05
                'For i = 0 To intPorts '- 1
                '    cboPort_Selection.Items.Insert(i, "COM" + CStr(i + 1))
                'Next
                '//-----

                '//----- Added by Sachin Dokhale on 17.12.05
                '---add commports to the combo box list.
                For i = 0 To gintCommPort.GetUpperBound(0)
                    cboPort_Selection.Items.Insert(i, "COM" + CStr(gintCommPort(i)))
                    ''get all selected comm port
                Next
                '//-----

            End If

            '---set commport to the combo box.
            If mintCommPortSelected > 0 Then
                '//----- Added by Sachin Dokhale on 17.12.05
                If mintCommPortSelected > gintCommPort(gintCommPort.GetUpperBound(0)) Then
                    mintCommPortSelected = gintCommPort(gintCommPort.GetUpperBound(0))
                    cboPort_Selection.SelectedIndex = gintCommPort.GetUpperBound(0)
                Else
                    For i = 0 To gintCommPort.GetUpperBound(0)
                        If gintCommPort(i) = mintCommPortSelected Then
                            cboPort_Selection.SelectedIndex = i
                            Exit For
                        End If

                    Next

                End If

                'cboPort_Selection.SelectedIndex = gintCommPortSelected - 1
                '//-----

            End If

            If cboPort_Selection.SelectedIndex = -1 And cboPort_Selection.Items.Count > 0 Then

                cboPort_Selection.SelectedIndex = 0
            End If

            If gobjCommProtocol.mobjCommdll.gFuncIsPortOpen() Then
                ''check if commport is open or not.
                gobjCommProtocol.mobjCommdll.gFuncCloseComm()
                ''function for close the comm port.
            End If

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            'gobjErrorHandler.ProcessError(EnumErrorType.Critical, ex)
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
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name	    :   cmdCancel_Click
        'Description	    :   
        'Parameters 	    :   None 
        'Time/Date  	    :   13.03.07
        'Dependencies	    :   
        'Author		        :   Sachin Dokhale
        'Revision		    :   
        'Revision by Person	:   praveen
        '--------------------------------------------------------------------------------------
        ''note:
        ''this is called when user clicked on cancel button.
        gintCommPortSelected = 0
        mintCommPortSelected = 0
        Me.Close()

    End Sub

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name	    :   cmdOk_Click
        'Description	    :   
        'Parameters 	    :   None 
        'Time/Date  	    :   13.03.07
        'Dependencies	    :   
        'Author		        :   Sachin Dokhale
        'Revision		    :   
        'Revision by Person	:   praveen
        '--------------------------------------------------------------------------------------
        ''note;
        ''this is called when user clicked on OK button.
        ''this will first take a comm port to be opened from user.
        ''check whatever it is already open or not.
        ''if already open then prompt a error mess
        ''else open a commport.
        Dim blnFlag As Boolean
        Try
            If mblnInProcess = True Then
                Exit Sub
            End If
            mblnInProcess = True

            'If gblnInstrumentInitialized Then
            '//----- Added & commited by Sachin Dikhale on 17.12.05
            If mintCommPortSelected = gintCommPort(cboPort_Selection.SelectedIndex) Then
                '//-----
                If gobjCommProtocol.mobjCommdll.gFuncIsPortOpen() Then
                    'gFuncShowMessage("Port Already Open", "The selected port is in use, try with other ports", EnumMessageType.Information)
                    gobjMessageAdapter.ShowMessage(constPortAlreadyOpen)
                    Application.DoEvents()
                    Exit Sub
                End If
            End If
            'End If

            '---if comm port is open then close it
            If gobjCommProtocol.mobjCommdll.gFuncIsPortOpen() Then
                gobjCommProtocol.mobjCommdll.gFuncCloseComm()
            End If

            '//----- Added & commited by Sachin Dikhale on 17.12.05
            'gSelected_Port = Trim(cboPort_Selection.Text)
            mintCommPortSelected = gintCommPort(cboPort_Selection.SelectedIndex)
            '//-----
            '---open selected comm port
            If Not gobjCommProtocol.mobjCommdll.gFuncISPortAvailable(mintCommPortSelected) Then
                'gFuncShowMessage("Selected communication port not available. ", "Try using another communication port", modConstants.EnumMessageType.Information)
                'gintCommPortSelected = 0
                gobjMessageAdapter.ShowMessage(constComPortNotAvailable)
                Application.DoEvents()
            Else
                If Not gobjCommProtocol.mobjCommdll.gFuncOpenCommPort(mintCommPortSelected, True) Then
                    'gFuncShowMessage("Communication Port Busy ...", "Selected communication port used by another program " & vbCrLf & "Try using another communication port", modConstants.EnumMessageType.Information)
                    gobjMessageAdapter.ShowMessage(constComPortBusy)
                    Application.DoEvents()
                Else
                    '--- write the port to ini 
                    gintCommPortSelected = mintCommPortSelected
                    gFuncWriteToINI(SECTION_COMMSETTINGS, KEY_COMPORT, CStr(gintCommPortSelected), INI_SETTINGS_PATH)

                End If
            End If
            Me.DialogResult = DialogResult.OK
            'Me.Close()

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gintCommPortSelected = 0
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
            mblnInProcess = False
            '---------------------------------------------------------
        End Try

    End Sub

    Private Sub frmCommPorts_Selection_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.VisibleChanged
        Application.DoEvents()
    End Sub

    Private Sub frmCommPorts_Selection_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Leave
        Application.DoEvents()
    End Sub

#End Region

End Class
