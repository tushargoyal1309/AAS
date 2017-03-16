Option Strict On
Imports AAS203.Common
''note this is used for checking a AAS protocol by send it theough serial communication

Public Class frmCommand
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
    Friend WithEvents CustomPanel1 As GradientPanel.CustomPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblCommand As System.Windows.Forms.Label
    Friend WithEvents lblParam1 As System.Windows.Forms.Label
    Friend WithEvents lblParam2 As System.Windows.Forms.Label
    Friend WithEvents lblParam3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnCancel As NETXP.Controls.XPButton
    Friend WithEvents btnOk As NETXP.Controls.XPButton
    Friend WithEvents txtParam1 As NumberValidator.NumberValidator
    Friend WithEvents txtParam2 As NumberValidator.NumberValidator
    Friend WithEvents txtParam3 As NumberValidator.NumberValidator
    Friend WithEvents txtCommand As NumberValidator.NumberValidator
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmCommand))
        Me.CustomPanel1 = New GradientPanel.CustomPanel
        Me.txtCommand = New NumberValidator.NumberValidator
        Me.txtParam3 = New NumberValidator.NumberValidator
        Me.txtParam2 = New NumberValidator.NumberValidator
        Me.txtParam1 = New NumberValidator.NumberValidator
        Me.btnCancel = New NETXP.Controls.XPButton
        Me.btnOk = New NETXP.Controls.XPButton
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblParam3 = New System.Windows.Forms.Label
        Me.lblParam2 = New System.Windows.Forms.Label
        Me.lblParam1 = New System.Windows.Forms.Label
        Me.lblCommand = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.CustomPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'CustomPanel1
        '
        Me.CustomPanel1.BackColor = System.Drawing.Color.AliceBlue
        Me.CustomPanel1.Controls.Add(Me.txtCommand)
        Me.CustomPanel1.Controls.Add(Me.txtParam3)
        Me.CustomPanel1.Controls.Add(Me.txtParam2)
        Me.CustomPanel1.Controls.Add(Me.txtParam1)
        Me.CustomPanel1.Controls.Add(Me.btnCancel)
        Me.CustomPanel1.Controls.Add(Me.btnOk)
        Me.CustomPanel1.Controls.Add(Me.Label2)
        Me.CustomPanel1.Controls.Add(Me.lblParam3)
        Me.CustomPanel1.Controls.Add(Me.lblParam2)
        Me.CustomPanel1.Controls.Add(Me.lblParam1)
        Me.CustomPanel1.Controls.Add(Me.lblCommand)
        Me.CustomPanel1.Controls.Add(Me.Label1)
        Me.CustomPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CustomPanel1.Location = New System.Drawing.Point(0, 0)
        Me.CustomPanel1.Name = "CustomPanel1"
        Me.CustomPanel1.Size = New System.Drawing.Size(362, 191)
        Me.CustomPanel1.TabIndex = 0
        '
        'txtCommand
        '
        Me.txtCommand.DigitsAfterDecimalPoint = 0
        Me.txtCommand.ErrorColor = System.Drawing.Color.Empty
        Me.txtCommand.ErrorMessage = Nothing
        Me.txtCommand.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCommand.Location = New System.Drawing.Point(160, 32)
        Me.txtCommand.MaximumRange = 55
        Me.txtCommand.MaxLength = 2
        Me.txtCommand.MinimumRange = 0
        Me.txtCommand.Name = "txtCommand"
        Me.txtCommand.RangeValidation = True
        Me.txtCommand.Size = New System.Drawing.Size(40, 22)
        Me.txtCommand.TabIndex = 13
        Me.txtCommand.Text = "0"
        Me.txtCommand.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtCommand.ValidationType = NumberValidator.NumberValidator.Validations.IntegerOnly
        '
        'txtParam3
        '
        Me.txtParam3.DigitsAfterDecimalPoint = 0
        Me.txtParam3.ErrorColor = System.Drawing.Color.Empty
        Me.txtParam3.ErrorMessage = Nothing
        Me.txtParam3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtParam3.Location = New System.Drawing.Point(160, 137)
        Me.txtParam3.MaximumRange = 300
        Me.txtParam3.MaxLength = 3
        Me.txtParam3.MinimumRange = 1
        Me.txtParam3.Name = "txtParam3"
        Me.txtParam3.RangeValidation = True
        Me.txtParam3.Size = New System.Drawing.Size(40, 22)
        Me.txtParam3.TabIndex = 12
        Me.txtParam3.Text = "0"
        Me.txtParam3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtParam3.ValidationType = NumberValidator.NumberValidator.Validations.IntegerOnly
        '
        'txtParam2
        '
        Me.txtParam2.DigitsAfterDecimalPoint = 0
        Me.txtParam2.ErrorColor = System.Drawing.Color.Empty
        Me.txtParam2.ErrorMessage = Nothing
        Me.txtParam2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtParam2.Location = New System.Drawing.Point(160, 102)
        Me.txtParam2.MaximumRange = 300
        Me.txtParam2.MaxLength = 3
        Me.txtParam2.MinimumRange = 1
        Me.txtParam2.Name = "txtParam2"
        Me.txtParam2.RangeValidation = True
        Me.txtParam2.Size = New System.Drawing.Size(40, 22)
        Me.txtParam2.TabIndex = 11
        Me.txtParam2.Text = "0"
        Me.txtParam2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtParam2.ValidationType = NumberValidator.NumberValidator.Validations.IntegerOnly
        '
        'txtParam1
        '
        Me.txtParam1.DigitsAfterDecimalPoint = 0
        Me.txtParam1.ErrorColor = System.Drawing.Color.Empty
        Me.txtParam1.ErrorMessage = Nothing
        Me.txtParam1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtParam1.Location = New System.Drawing.Point(160, 67)
        Me.txtParam1.MaximumRange = 300
        Me.txtParam1.MaxLength = 3
        Me.txtParam1.MinimumRange = 1
        Me.txtParam1.Name = "txtParam1"
        Me.txtParam1.RangeValidation = True
        Me.txtParam1.Size = New System.Drawing.Size(40, 22)
        Me.txtParam1.TabIndex = 10
        Me.txtParam1.Text = "0"
        Me.txtParam1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtParam1.ValidationType = NumberValidator.NumberValidator.Validations.IntegerOnly
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Image = CType(resources.GetObject("btnCancel.Image"), System.Drawing.Image)
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancel.Location = New System.Drawing.Point(264, 104)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(86, 34)
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.Text = "Cancel"
        '
        'btnOk
        '
        Me.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOk.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOk.Image = CType(resources.GetObject("btnOk.Image"), System.Drawing.Image)
        Me.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnOk.Location = New System.Drawing.Point(264, 48)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(86, 34)
        Me.btnOk.TabIndex = 4
        Me.btnOk.Text = "OK"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(248, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(2, 176)
        Me.Label2.TabIndex = 9
        '
        'lblParam3
        '
        Me.lblParam3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblParam3.Location = New System.Drawing.Point(24, 143)
        Me.lblParam3.Name = "lblParam3"
        Me.lblParam3.Size = New System.Drawing.Size(72, 16)
        Me.lblParam3.TabIndex = 4
        Me.lblParam3.Text = "Param3"
        '
        'lblParam2
        '
        Me.lblParam2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblParam2.Location = New System.Drawing.Point(24, 106)
        Me.lblParam2.Name = "lblParam2"
        Me.lblParam2.Size = New System.Drawing.Size(72, 16)
        Me.lblParam2.TabIndex = 3
        Me.lblParam2.Text = "Param2"
        '
        'lblParam1
        '
        Me.lblParam1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblParam1.Location = New System.Drawing.Point(24, 69)
        Me.lblParam1.Name = "lblParam1"
        Me.lblParam1.Size = New System.Drawing.Size(72, 16)
        Me.lblParam1.TabIndex = 2
        Me.lblParam1.Text = "Param1"
        '
        'lblCommand
        '
        Me.lblCommand.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCommand.Location = New System.Drawing.Point(24, 32)
        Me.lblCommand.Name = "lblCommand"
        Me.lblCommand.Size = New System.Drawing.Size(72, 16)
        Me.lblCommand.TabIndex = 1
        Me.lblCommand.Text = "Command"
        Me.lblCommand.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Location = New System.Drawing.Point(16, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(208, 160)
        Me.Label1.TabIndex = 0
        '
        'frmCommand
        '
        Me.AcceptButton = Me.btnOk
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(362, 191)
        Me.Controls.Add(Me.CustomPanel1)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCommand"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Command"
        Me.CustomPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Variables "

    Public Event CheckResponse(ByVal strResponse As String)
    Private blnCheck As Boolean = False

#End Region

#Region " Private Constants "

    Private Const intConst1 As Integer = &H32
    Private Const intConst2 As Integer = &H20
    Private Const intConst3 As Integer = &H34

#End Region

#Region " Form Events "

    Private Sub frmCommand_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '=====================================================================
        ' Procedure Name        : frmCommand_Load
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To load the Command form.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S.
        ' Created               : 07.12.06
        ' Revisions             : 
        '=====================================================================
        ''this is called when form is loaded 
        ''this done some initialisation

        Dim objWait As New CWaitCursor
        Try
            txtCommand.Focus()
            blnCheck = False
            Call AddHandlers()
            ''this is called for adding event handler

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
            '---------------------------------------------------------
        End Try
    End Sub

#End Region

#Region " Private Functions "

    Private Sub AddHandlers()
        '=====================================================================
        ' Procedure Name        : AddHandlers
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : To add event handlers
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh
        ' Created               : 05.10.06
        ' Revisions             : 
        '=====================================================================

        ''note:
        ''this is used for adding a event handler
        Try
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

    Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : btnCancel_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : This will close the Command Test window.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 07.12.06
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor

        Try
            ''this is called when user close the form
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
            objWait.Dispose()
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub btnOk_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : btnOk_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : This will send the Command .
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 07.12.06
        ' Revisions             : 
        '=====================================================================

        ''note:
        ''this is used to send a command to the instrument
        ''step 1: take a value from user to a variable
        ''step 2: check for validation as par protocol notification
        ''and if command is varify then send it via serial communication


        Dim objWait As New CWaitCursor
        Dim intCommand As Integer
        Dim intParam1 As Integer
        Dim intParam2 As Integer
        Dim intParam3 As Integer
        Dim bytArray(7) As Byte
        Dim strTrans As String = ""
        Dim strRec As String = ""
        Dim strConstTrans As String
        Dim strConstRec As String

        Try
            intCommand = CInt(txtCommand.Text)
            intParam1 = CInt(txtParam1.Text)
            intParam2 = CInt(txtParam2.Text)
            intParam3 = CInt(txtParam3.Text)

            ''here we taking value from user to the variables

            '***********************************************************
            '---Changed By Mangesh on 17-Apr-2007
            '***********************************************************
            '---Max Limit of Command is previously 55 and is changed to 100
            '***********************************************************
            If intCommand < 0 Or intCommand > 100 Then
                gobjMessageAdapter.ShowMessage(constCommandValue)
                Application.DoEvents()
                Exit Sub
            ElseIf intParam1 > 255 Or intParam2 > 255 Or intParam3 > 255 Then
                gobjMessageAdapter.ShowMessage("Parameter value should not be more than 255", "Check value", MessageHandler.clsMessageHandler.enumMessageType.ErrorMessage)
                Application.DoEvents()
                Exit Sub
            ElseIf blnCheck = False Then
                ''by Pankaj on 18.1.08
                If gobjCommProtocol.mobjCommdll.gFuncIsPortOpen() = False Then 'by Pankaj on 18.1.08
                    Dim frmCommPorts_Selection As New frmCommPorts_Selection
                    frmCommPorts_Selection.ShowDialog()
                    Application.DoEvents()
                End If
                ''---
                If gobjCommProtocol.mobjCommdll.gFuncTransmitCommand(intCommand, intParam1, intParam2, intParam3) Then

                    strConstTrans = Microsoft.VisualBasic.Right(Hex(0 - (intCommand + CInt(intParam1 + intParam2 + intParam3) + intConst1 + intConst2 + intConst3)), 2)
                    strTrans = "Transmitted -> " & Hex(intConst1) & ", " & Hex(intCommand) & ", " & Hex(intParam1) & ", " & Hex(intParam2) & ", " & Hex(intParam3) & ", " & strConstTrans & ", " & Hex(intConst2) & ", " & Hex(intConst3) & " in HEX"
                    RaiseEvent CheckResponse(strTrans)

                    If gobjCommProtocol.mobjCommdll.gFuncReceiveData(bytArray, CONST_LONG_DELAY) Then
                        If bytArray(1) <> 1 Then

                            strConstRec = Microsoft.VisualBasic.Right(Hex(0 - (CInt(bytArray(1) + bytArray(2) + bytArray(3)) + CInt(intConst1 + intConst2 + intConst3))), 2)
                            strRec = "Received -> " & Hex(intConst1) & ", " & Hex(bytArray(1)) & ", " & bytArray(2) & ", " & bytArray(3) & ", " & bytArray(4) & ", " & strConstRec & ", " & Hex(intConst2) & ", " & Hex(intConst3) & " in HEX"
                            RaiseEvent CheckResponse(strRec)

                            blnCheck = True
                            Me.Close()
                            Application.DoEvents()

                        Else
                            strConstRec = Microsoft.VisualBasic.Right(Hex(0 - (CInt(bytArray(1) + bytArray(2) + bytArray(3)) + CInt(intConst1 + intConst2 + intConst3))), 2)
                            strRec = "Received -> " & Hex(intConst1) & ", " & bytArray(1) & ", " & bytArray(2) & ", " & bytArray(3) & ", " & bytArray(4) & ", " & strConstRec & ", " & Hex(intConst2) & ", " & Hex(intConst3) & " in HEX"
                            RaiseEvent CheckResponse(strRec)

                            blnCheck = True
                            Me.Close()
                            Application.DoEvents()

                        End If
                    Else
                        gobjMessageAdapter.ShowMessage(constErrorRecivedBlockBurner)
                        Application.DoEvents()
                        End
                    End If
                Else
                    'Application.DoEvents()
                End If

            ElseIf blnCheck = True Then
                Exit Sub
            End If

            '---added on 29.01.08
            If gobjCommProtocol.mobjCommdll.gFuncIsPortOpen() Then
                gobjCommProtocol.funcGet_Current_Wv(gobjInst.WavelengthCur)
            End If
            '---added on 29.01.08

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
            '---------------------------------------------------------
        End Try
    End Sub

#End Region

End Class
