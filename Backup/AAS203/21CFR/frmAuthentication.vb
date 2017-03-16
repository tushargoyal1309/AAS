Option Explicit On 
Imports System.Data
Imports System.Data.OleDb
Imports AAS203.Signature

Public Class frmAuthentication
    Inherits System.Windows.Forms.Form

#Region "Module level Declarations "

    'Private mstrFileName As String
    'Private mobjDigitalSignature As DigitalSignature
    'Dim blncancelFlag As Boolean = False
    Dim blnRBFileOptionCheck As Boolean = False
#End Region

#Region " Windows Form Designer generated code "

    '--- User Defined Constructor
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
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents lblPassword As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents pnlPassword As System.Windows.Forms.Panel
    Friend WithEvents RBFile As System.Windows.Forms.RadioButton
    Friend WithEvents RBLogin As System.Windows.Forms.RadioButton
    Friend WithEvents txtUserName As System.Windows.Forms.TextBox
    Friend WithEvents lblUserName As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents pnlAuthentication As System.Windows.Forms.Panel
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents btnOk As NETXP.Controls.XPButton
    Friend WithEvents cmdCancel As NETXP.Controls.XPButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmAuthentication))
        Me.pnlPassword = New System.Windows.Forms.Panel
        Me.PictureBox4 = New System.Windows.Forms.PictureBox
        Me.txtPassword = New System.Windows.Forms.TextBox
        Me.lblPassword = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.pnlAuthentication = New System.Windows.Forms.Panel
        Me.RBFile = New System.Windows.Forms.RadioButton
        Me.RBLogin = New System.Windows.Forms.RadioButton
        Me.txtUserName = New System.Windows.Forms.TextBox
        Me.lblUserName = New System.Windows.Forms.Label
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.PictureBox5 = New System.Windows.Forms.PictureBox
        Me.btnOk = New NETXP.Controls.XPButton
        Me.cmdCancel = New NETXP.Controls.XPButton
        Me.pnlPassword.SuspendLayout()
        Me.pnlAuthentication.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlPassword
        '
        Me.pnlPassword.Controls.Add(Me.PictureBox4)
        Me.pnlPassword.Controls.Add(Me.txtPassword)
        Me.pnlPassword.Controls.Add(Me.lblPassword)
        Me.pnlPassword.Controls.Add(Me.Label2)
        Me.pnlPassword.Controls.Add(Me.PictureBox3)
        Me.pnlPassword.Location = New System.Drawing.Point(2, 127)
        Me.pnlPassword.Name = "pnlPassword"
        Me.pnlPassword.Size = New System.Drawing.Size(401, 99)
        Me.pnlPassword.TabIndex = 0
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(30, 42)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox4.TabIndex = 38
        Me.PictureBox4.TabStop = False
        '
        'txtPassword
        '
        Me.txtPassword.AutoSize = False
        Me.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPassword.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPassword.Location = New System.Drawing.Point(194, 45)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(174, 24)
        Me.txtPassword.TabIndex = 0
        Me.txtPassword.Text = ""
        '
        'lblPassword
        '
        Me.lblPassword.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPassword.Location = New System.Drawing.Point(105, 48)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(80, 18)
        Me.lblPassword.TabIndex = 1
        Me.lblPassword.Text = "Password"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(16, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 15)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Personilize"
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.Gray
        Me.PictureBox3.Location = New System.Drawing.Point(72, 26)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(400, 1)
        Me.PictureBox3.TabIndex = 34
        Me.PictureBox3.TabStop = False
        '
        'pnlAuthentication
        '
        Me.pnlAuthentication.Controls.Add(Me.RBFile)
        Me.pnlAuthentication.Controls.Add(Me.RBLogin)
        Me.pnlAuthentication.Controls.Add(Me.txtUserName)
        Me.pnlAuthentication.Controls.Add(Me.lblUserName)
        Me.pnlAuthentication.Controls.Add(Me.PictureBox2)
        Me.pnlAuthentication.Controls.Add(Me.Label1)
        Me.pnlAuthentication.Controls.Add(Me.PictureBox1)
        Me.pnlAuthentication.Location = New System.Drawing.Point(0, 0)
        Me.pnlAuthentication.Name = "pnlAuthentication"
        Me.pnlAuthentication.Size = New System.Drawing.Size(426, 120)
        Me.pnlAuthentication.TabIndex = 1
        '
        'RBFile
        '
        Me.RBFile.Location = New System.Drawing.Point(110, 91)
        Me.RBFile.Name = "RBFile"
        Me.RBFile.Size = New System.Drawing.Size(208, 24)
        Me.RBFile.TabIndex = 3
        Me.RBFile.Text = "Save as Private Authentication"
        '
        'RBLogin
        '
        Me.RBLogin.Location = New System.Drawing.Point(110, 61)
        Me.RBLogin.Name = "RBLogin"
        Me.RBLogin.Size = New System.Drawing.Size(208, 24)
        Me.RBLogin.TabIndex = 2
        Me.RBLogin.Text = "Save as Login Authentication"
        '
        'txtUserName
        '
        Me.txtUserName.AutoSize = False
        Me.txtUserName.BackColor = System.Drawing.Color.White
        Me.txtUserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUserName.Cursor = System.Windows.Forms.Cursors.Default
        Me.txtUserName.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUserName.Location = New System.Drawing.Point(195, 27)
        Me.txtUserName.Name = "txtUserName"
        Me.txtUserName.ReadOnly = True
        Me.txtUserName.Size = New System.Drawing.Size(176, 24)
        Me.txtUserName.TabIndex = 1
        Me.txtUserName.Text = ""
        '
        'lblUserName
        '
        Me.lblUserName.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUserName.Location = New System.Drawing.Point(110, 31)
        Me.lblUserName.Name = "lblUserName"
        Me.lblUserName.Size = New System.Drawing.Size(80, 17)
        Me.lblUserName.TabIndex = 0
        Me.lblUserName.Text = "User Name"
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Gray
        Me.PictureBox2.Location = New System.Drawing.Point(107, 14)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(374, 1)
        Me.PictureBox2.TabIndex = 31
        Me.PictureBox2.TabStop = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(22, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Authentication"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(34, 37)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox1.TabIndex = 29
        Me.PictureBox1.TabStop = False
        '
        'PictureBox5
        '
        Me.PictureBox5.BackColor = System.Drawing.Color.Gray
        Me.PictureBox5.Location = New System.Drawing.Point(1, 223)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(400, 1)
        Me.PictureBox5.TabIndex = 36
        Me.PictureBox5.TabStop = False
        '
        'btnOk
        '
        Me.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOk.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOk.Image = CType(resources.GetObject("btnOk.Image"), System.Drawing.Image)
        Me.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnOk.Location = New System.Drawing.Point(141, 232)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(100, 30)
        Me.btnOk.TabIndex = 37
        Me.btnOk.Text = "&OK"
        '
        'cmdCancel
        '
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdCancel.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancel.Image = CType(resources.GetObject("cmdCancel.Image"), System.Drawing.Image)
        Me.cmdCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancel.Location = New System.Drawing.Point(268, 232)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(100, 30)
        Me.cmdCancel.TabIndex = 38
        Me.cmdCancel.Text = "&Cancel"
        '
        'frmAuthentication
        '
        Me.AcceptButton = Me.btnOk
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.CancelButton = Me.cmdCancel
        Me.ClientSize = New System.Drawing.Size(402, 269)
        Me.ControlBox = False
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.PictureBox5)
        Me.Controls.Add(Me.pnlAuthentication)
        Me.Controls.Add(Me.pnlPassword)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmAuthentication"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Authentication"
        Me.pnlPassword.ResumeLayout(False)
        Me.pnlAuthentication.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Form Events"

    Private Sub RBFile_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBFile.CheckedChanged
        Try
            If (RBFile.Checked) Then
                pnlPassword.Visible = True
                txtPassword.Focus()
                blnRBFileOptionCheck = True
            Else
                pnlPassword.Visible = False
                blnRBFileOptionCheck = False
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
            'objWait.Dispose()
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub RBLogin_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBLogin.CheckedChanged
        Try
            If (RBFile.Checked) Then
                pnlPassword.Visible = True
                txtPassword.Focus()
                blnRBFileOptionCheck = True
            Else
                pnlPassword.Visible = False
                blnRBFileOptionCheck = False
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
            'objWait.Dispose()
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub frmAuthentication_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtPassword.Focus()
    End Sub
   
#End Region

#Region "Private functions"

    '--------------------------------------------------------
    '    General functions used for Authentication/Digital Signature.
    '--- funcInitialize  - To Initialize the form and ask user for input parameters.
    '--- funcSaveNewUser - To Save Newly Created User.
    '--- funcSaveSignatureData - To Save the Records as Digital Signature in a class.

    Public Sub subInitialize(ByVal objDigitalSig As DigitalSignature)
        '=====================================================================
        ' Procedure Name        :   funcInitialize
        ' Description           :   To Initialize the form and ask user for input parameters.
        ' Purpose               :   To Initialize the form and ask user for input parameters.
        ' Parameters Passed     :   None.
        ' Returns               :   None.
        ' Parameters Affected   :   None.
        ' Assumptions           :
        ' Dependencies          :
        ' Author                :   Gitesh
        ' Created               :   February, 2003 
        ' Revisions             :
        '=====================================================================
        Try
            txtUserName.Text = objDigitalSig.UserName
            'mobjDigitalSignature = objDigitalSig
            If objDigitalSig.ActivityType = ENUM_ActivityType.FileAuthentication Then
                txtPassword.Focus()
                RBFile.Checked = True
                ' RBLogin.Checked = True
            Else
                txtPassword.Focus()
                RBLogin.Checked = True
                pnlPassword.Visible = False
            End If

            txtPassword.Text = ""


        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            'gobjErrorHandler.ProcessError(ErrorHandler.EnumErrorType.Critical, ex)
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

    'Private Function funcSaveSignatureData() As Boolean
    '    '=====================================================================
    '    ' Procedure Name        :   funcSaveSignatureData
    '    ' Description           :   To Save the Records as Digital Signature in a class.
    '    ' Purpose               :   To Save the Records as Digital Signature in a class.
    '    ' Parameters Passed     :   None.
    '    ' Returns               :   None.
    '    ' Parameters Affected   :   None.
    '    ' Assumptions           :
    '    ' Dependencies          :
    '    ' Author                :   Gitesh
    '    ' Created               :   February, 2003 
    '    ' Revisions             :
    '    '=====================================================================

    '    Dim intType As Integer

    '    Try
    '        If (RBLogin.Checked) Then
    '            intType = ENUM_ActivityType.LoginAuthentication
    '        End If
    '        If (RBFile.Checked) Then
    '            intType = ENUM_ActivityType.FileAuthentication
    '        End If

    '        mobjDigitalSignature.UserName = gstructUserDetails.UserName
    '        mobjDigitalSignature.UserID = gstructUserDetails.UserID
    '        mobjDigitalSignature.LoginPassword = gstructUserDetails.UserPassword

    '        mobjDigitalSignature.SaveDate = DateTime.Today
    '        mobjDigitalSignature.ActivityType = intType
    '        mobjDigitalSignature.FileName = mstrFileName

    '        If (intType = ENUM_ActivityType.LoginAuthentication) Then
    '            mobjDigitalSignature.FilePassword = ""
    '        Else
    '            mobjDigitalSignature.FilePassword = txtPassword.Text
    '        End If

    '        Return True
    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        'Error Handling and logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = ex.Message
    '        gobjErrorHandler.WriteErrorLog(ex)
    '        '---------------------------------------------------------
    '        Return False
    '    Finally
    '        '---------------------------------------------------------
    '        'Writing Execution log
    '        If CONST_CREATE_EXECUTION_LOG = 1 Then
    '            gobjErrorHandler.WriteExecutionLog()
    '        End If
    '        '---------------------------------------------------------
    '    End Try

    'End Function

#End Region

#Region "Global Function"

    'Private Function funcGetDigitalSignatureDetails() As Boolean
    '    '=====================================================================
    '    ' Procedure Name        :   funcGetDigitalSignatureDetails
    '    ' Description           :   To Display form and ask user for input parameters before saving a file.
    '    ' Purpose               :   To Display form and ask user for input parameters before saving a file.
    '    ' Parameters Passed     :   None.
    '    ' Returns               :   None.
    '    ' Parameters Affected   :   None.
    '    ' Assumptions           :
    '    ' Dependencies          :
    '    ' Author                :   Gitesh
    '    ' Created               :   February, 2003 
    '    ' Revisions             :
    '    '=====================================================================
    '    Dim objDS As New DigitalSignature

    '    Try
    '        Dim frmAuthentication As New frmAuthentication
    '        frmAuthentication.ShowDialog()
    '        If (frmAuthentication.DialogResult = DialogResult.OK) Then
    '            objDS = frmAuthentication.mobjDigitalSignature
    '            Return True
    '        Else
    '            Return False
    '        End If
    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        'Error Handling and logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = ex.Message
    '        gobjErrorHandler.ProcessError(ErrorHandler.EnumErrorType.Critical, ex)
    '        '---------------------------------------------------------
    '        Return False
    '    Finally
    '        '---------------------------------------------------------
    '        'Writing Execution log
    '        If CONST_CREATE_EXECUTION_LOG = 1 Then
    '            gobjErrorHandler.WriteExecutionLog()
    '        End If
    '        '---------------------------------------------------------
    '    End Try

    'End Function

#End Region

    Private Sub txtPassword_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtPassword.Validating
        'If blncancelFlag = False And blnRBFileOptionCheck = True Then
        '    If txtPassword.Text = "" Then
        '        gobjMessageAdapter.ShowMessage("Password field cannot be Blank", "Note !", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage)
        '    End If
        'End If
    End Sub

    Private Sub RBLogin_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RBLogin.Click
        blnRBFileOptionCheck = False
    End Sub

    Private Sub RBFile_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RBFile.Click
        blnRBFileOptionCheck = True
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        Try
            If blnRBFileOptionCheck = True Then
                If txtPassword.Text = "" Then
                    btnOk.DialogResult = DialogResult.None
                    gobjMessageAdapter.ShowMessage(constPasswordCannotBlank)
                    Exit Sub
                End If
            End If
            'funcSaveSignatureData()
            'btnOk.DialogResult = DialogResult.OK

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

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Try
            'If blnRBFileOptionCheck = True Then
            'If txtPassword.Text = "" Then
            cmdCancel.DialogResult = DialogResult.Cancel
            'gobjMessageAdapter.ShowMessage("Note !", "Password field cannot be blank", modGlobalConstants.EnumMessageType.Information)



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

End Class
