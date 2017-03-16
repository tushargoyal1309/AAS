Imports AAS203.Common
Imports System.Data.OleDb
Imports System.Data

Public Class frmChangePassword
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
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblUserName As System.Windows.Forms.Label
    Friend WithEvents txtPasswordconfirm As System.Windows.Forms.TextBox
    Friend WithEvents lblPasswordConfirm As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents cmdCancel As NETXP.Controls.XPButton
    Friend WithEvents cmdSave As NETXP.Controls.XPButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmChangePassword))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmdCancel = New NETXP.Controls.XPButton
        Me.cmdSave = New NETXP.Controls.XPButton
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.lblUserName = New System.Windows.Forms.Label
        Me.txtPasswordconfirm = New System.Windows.Forms.TextBox
        Me.lblPasswordConfirm = New System.Windows.Forms.Label
        Me.txtPassword = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdCancel)
        Me.GroupBox1.Controls.Add(Me.cmdSave)
        Me.GroupBox1.Controls.Add(Me.PictureBox2)
        Me.GroupBox1.Controls.Add(Me.PictureBox1)
        Me.GroupBox1.Controls.Add(Me.lblUserName)
        Me.GroupBox1.Controls.Add(Me.txtPasswordconfirm)
        Me.GroupBox1.Controls.Add(Me.lblPasswordConfirm)
        Me.GroupBox1.Controls.Add(Me.txtPassword)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(360, 197)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        '
        'cmdCancel
        '
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdCancel.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancel.Image = CType(resources.GetObject("cmdCancel.Image"), System.Drawing.Image)
        Me.cmdCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancel.Location = New System.Drawing.Point(244, 144)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(100, 34)
        Me.cmdCancel.TabIndex = 39
        Me.cmdCancel.Text = "&Cancel"
        '
        'cmdSave
        '
        Me.cmdSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdSave.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSave.Image = CType(resources.GetObject("cmdSave.Image"), System.Drawing.Image)
        Me.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSave.Location = New System.Drawing.Point(133, 144)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(100, 34)
        Me.cmdSave.TabIndex = 38
        Me.cmdSave.Text = "&Save"
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Gray
        Me.PictureBox2.Location = New System.Drawing.Point(56, 24)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(300, 2)
        Me.PictureBox2.TabIndex = 22
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(6, 24)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(48, 48)
        Me.PictureBox1.TabIndex = 21
        Me.PictureBox1.TabStop = False
        '
        'lblUserName
        '
        Me.lblUserName.BackColor = System.Drawing.Color.White
        Me.lblUserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblUserName.Location = New System.Drawing.Point(162, 48)
        Me.lblUserName.Name = "lblUserName"
        Me.lblUserName.Size = New System.Drawing.Size(182, 21)
        Me.lblUserName.TabIndex = 20
        Me.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPasswordconfirm
        '
        Me.txtPasswordconfirm.AutoSize = False
        Me.txtPasswordconfirm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPasswordconfirm.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPasswordconfirm.Location = New System.Drawing.Point(162, 112)
        Me.txtPasswordconfirm.Name = "txtPasswordconfirm"
        Me.txtPasswordconfirm.PasswordChar = Microsoft.VisualBasic.ChrW(42)
        Me.txtPasswordconfirm.Size = New System.Drawing.Size(182, 21)
        Me.txtPasswordconfirm.TabIndex = 7
        Me.txtPasswordconfirm.Text = ""
        '
        'lblPasswordConfirm
        '
        Me.lblPasswordConfirm.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPasswordConfirm.Location = New System.Drawing.Point(46, 112)
        Me.lblPasswordConfirm.Name = "lblPasswordConfirm"
        Me.lblPasswordConfirm.Size = New System.Drawing.Size(112, 22)
        Me.lblPasswordConfirm.TabIndex = 6
        Me.lblPasswordConfirm.Text = "Password Confirm :"
        Me.lblPasswordConfirm.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtPassword
        '
        Me.txtPassword.AutoSize = False
        Me.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPassword.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPassword.Location = New System.Drawing.Point(162, 80)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(182, 21)
        Me.txtPassword.TabIndex = 5
        Me.txtPassword.Text = ""
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(78, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 22)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "User Name :"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(78, 80)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 22)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Password :"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmChangePassword
        '
        Me.AcceptButton = Me.cmdSave
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.CancelButton = Me.cmdCancel
        Me.ClientSize = New System.Drawing.Size(360, 197)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmChangePassword"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Change Password"
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Form Events"

    Private Sub frmChangePassword_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '=====================================================================
        ' Procedure Name        : frmChangePassword_Load
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To load the Change Password form
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saruabh S. 
        ' Created               : Dec, 2006
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Try
            SubAddHandlers()
            If funcGetExistingUserName() = False Then
                ''gFuncShowMessage("Note...", "Problem in retreiving the Active AdminUser", EnumMessageType.Information)
                Exit Sub
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

#End Region
    
#Region " Private Functions"

    Private Sub SubAddHandlers()
        '=====================================================================
        ' Procedure Name        : SubAddHandlers
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : To add handlers
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S.
        ' Created               : 01.01.07
        ' Revisions             : 
        '=====================================================================
        AddHandler cmdCancel.Click, AddressOf cmdCancel_Click
        AddHandler cmdSave.Click, AddressOf cmdSave_Click

    End Sub

    Private Function funcGetExistingUserName() As Boolean
        '=====================================================================
        ' Procedure Name        :   funcGetExistingUserName
        ' Description           :   To Get the Current Users from the database and display them.
        ' Purpose               :   To Get the Current Users from the database and display them.
        ' Parameters Passed     :   None.
        ' Returns               :   None.
        ' Parameters Affected   :   None.
        ' Assumptions           :
        ' Dependencies          :
        ' Author                :   Saruabh S. 
        ' Created               :   Dec, 2006
        ' Revisions             :
        '=====================================================================
        Dim result As Boolean
        Dim str_sql As String
        Dim objReader As OleDb.OleDbDataReader
        Dim objDataRow As DataRow
        Dim objwait As New CWaitCursor
        Try

            '--- Generating dynamic query for selection type
            str_sql = "Select Users.UserName " & _
                      "from Users " & _
                      "where Users.UserID = " & gstructUserDetails.UserID & " "

            result = gclsDBFunctions.OpenConnection(gOleDBUserInfoConnection)
            If Not (result) Then
                Return False
            End If

            '--- Calling gfuncGetRecords to Get myreader populated with provided Query( strsqlServiceComments (Global String) Records
            gclsDBFunctions.GetRecords(str_sql, gOleDBUserInfoConnection, objReader)

            objReader.Read()

            Dim str_password As String

            lblUserName.Text = CStr(objReader.Item("UserName"))

            objReader.Close()

            Return True
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
            If Not objwait Is Nothing Then
                objwait.Dispose()
            End If
            '---------------------------------------------------------
        End Try

    End Function

    Private Function funcUpdateUserPassword() As Boolean
        '=====================================================================
        ' Procedure Name        :   funcUpdateUserPassword
        ' Description           :   To Save the Edited user Password into database.
        ' Purpose               :   To Save the Edited user Password into database.
        ' Parameters Passed     :   None.
        ' Returns               :   None.
        ' Parameters Affected   :   None.
        ' Assumptions           :
        ' Dependencies          :
        ' Author                :   Saruabh S. 
        ' Created               :   Dec, 2006
        ' Revisions             :
        '=====================================================================
        Dim objWait As New CWaitCursor
        Dim str_sql As String
        Dim Status As Boolean
        Dim objCommand As New OleDbCommand
        Dim objTransaction As OleDbTransaction
        Dim user_id, password_id As Long
        Dim active_value As Integer
        Dim str_id, arr_id() As String

        Try
            If gobjMessageAdapter.ShowMessage(constPasswordChange) = True Then

                If StrComp(txtPassword.Text, txtPasswordconfirm.Text, CompareMethod.Text) <> 0 Then
                    gobjMessageAdapter.ShowMessage(constInvalidPasswordConfirm)
                    Exit Try
                End If

                user_id = Convert.ToInt64(gstructUserDetails.UserID)

                'Status = gclsDBFunctions.OpenConnection(gOleDBUserInfoConnection)
                'If Not (Status) Then
                '    Return False
                'End If

                objTransaction = gOleDBUserInfoConnection.BeginTransaction()

                '--- To Encrypt the Password
                Dim str_password As String
                str_password = gfuncEncryptString(Trim(txtPassword.Text))

                '--- Query for Update Passwords Table
                str_sql = "Update Passwords  " & _
                          "Set PasswordName = ? " & _
                          "where PasswordID = " & password_id & " and UserID = " & user_id & " "

                '--- Providing command object for Users
                With objCommand
                    .Connection = gOleDBUserInfoConnection
                    .CommandType = CommandType.Text
                    .CommandText = str_sql
                    .Transaction = objTransaction
                    .Parameters.Add("PasswordName", OleDbType.VarChar).Value = str_password
                    .ExecuteNonQuery()
                End With

                objCommand.Dispose()
                objTransaction.Commit()
                Return (True)
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

    End Function

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : cmdSave_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To Save the change password
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saruabh S. 
        ' Created               : Dec, 2006
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Try
            If Not funcUpdateUserPassword() Then
                ''gFuncShowMessage("Note...", "Problem in retreiving the active AdminUser", EnumMessageType.Information)
                Exit Sub
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

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : cmdCancel_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To cancel the form
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                :   Saruabh S. 
        ' Created               :   Dec, 2006
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Try
            Me.DialogResult = DialogResult.Cancel
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
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            '---------------------------------------------------------
        End Try
    End Sub

#End Region

End Class
