Option Explicit On 
Imports AAS203.Common
Imports System.Data
Imports System.Data.OleDb

Public Class frmAddUser
    Inherits System.Windows.Forms.Form

#Region " Module level Declarations "

    Dim mobjDataTable As New DataTable("UserInfo")
    Dim mobjGridTableStyle As New DataGridTableStyle
    Dim mobjLinkLabel As New LinkLabel

    Enum ENUM_ColumnNos
        UserID = 0
        UserName = 1
        AliasName = 2
        Password = 3
        Active = 4
        PasswordID = 5
        Edit = 6
    End Enum

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
    Friend WithEvents txtUserName As System.Windows.Forms.TextBox
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtAliasName As System.Windows.Forms.TextBox
    Friend WithEvents lblAliasName As System.Windows.Forms.Label
    Friend WithEvents chkActiveUser As System.Windows.Forms.CheckBox
    Friend WithEvents txtUserID As System.Windows.Forms.TextBox
    Friend WithEvents dgUserInfo As System.Windows.Forms.DataGrid
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtConfirmPassword As System.Windows.Forms.TextBox
    Friend WithEvents cmdSave As NETXP.Controls.XPButton
    Friend WithEvents cmdCancel As NETXP.Controls.XPButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmAddUser))
        Me.txtUserName = New System.Windows.Forms.TextBox
        Me.txtPassword = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmdCancel = New NETXP.Controls.XPButton
        Me.cmdSave = New NETXP.Controls.XPButton
        Me.txtConfirmPassword = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtUserID = New System.Windows.Forms.TextBox
        Me.chkActiveUser = New System.Windows.Forms.CheckBox
        Me.txtAliasName = New System.Windows.Forms.TextBox
        Me.lblAliasName = New System.Windows.Forms.Label
        Me.dgUserInfo = New System.Windows.Forms.DataGrid
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgUserInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtUserName
        '
        Me.txtUserName.AutoSize = False
        Me.txtUserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUserName.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUserName.Location = New System.Drawing.Point(136, 18)
        Me.txtUserName.MaxLength = 40
        Me.txtUserName.Name = "txtUserName"
        Me.txtUserName.Size = New System.Drawing.Size(232, 21)
        Me.txtUserName.TabIndex = 0
        Me.txtUserName.Text = ""
        '
        'txtPassword
        '
        Me.txtPassword.AutoSize = False
        Me.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPassword.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPassword.Location = New System.Drawing.Point(136, 90)
        Me.txtPassword.MaxLength = 40
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(232, 21)
        Me.txtPassword.TabIndex = 2
        Me.txtPassword.Text = ""
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 22)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "User Name :"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(16, 94)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 22)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Password :"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdCancel)
        Me.GroupBox1.Controls.Add(Me.cmdSave)
        Me.GroupBox1.Controls.Add(Me.txtConfirmPassword)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtUserID)
        Me.GroupBox1.Controls.Add(Me.chkActiveUser)
        Me.GroupBox1.Controls.Add(Me.txtAliasName)
        Me.GroupBox1.Controls.Add(Me.lblAliasName)
        Me.GroupBox1.Controls.Add(Me.txtUserName)
        Me.GroupBox1.Controls.Add(Me.txtPassword)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(62, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(378, 213)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'cmdCancel
        '
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdCancel.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancel.Image = CType(resources.GetObject("cmdCancel.Image"), System.Drawing.Image)
        Me.cmdCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancel.Location = New System.Drawing.Point(264, 173)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(100, 30)
        Me.cmdCancel.TabIndex = 11
        Me.cmdCancel.Text = "&Cancel"
        '
        'cmdSave
        '
        Me.cmdSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdSave.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSave.Image = CType(resources.GetObject("cmdSave.Image"), System.Drawing.Image)
        Me.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSave.Location = New System.Drawing.Point(144, 173)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(100, 30)
        Me.cmdSave.TabIndex = 10
        Me.cmdSave.Text = "&Save"
        '
        'txtConfirmPassword
        '
        Me.txtConfirmPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtConfirmPassword.Location = New System.Drawing.Point(136, 126)
        Me.txtConfirmPassword.Name = "txtConfirmPassword"
        Me.txtConfirmPassword.PasswordChar = Microsoft.VisualBasic.ChrW(42)
        Me.txtConfirmPassword.Size = New System.Drawing.Size(232, 21)
        Me.txtConfirmPassword.TabIndex = 3
        Me.txtConfirmPassword.Text = ""
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(16, 130)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(112, 22)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Confirm Password :"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtUserID
        '
        Me.txtUserID.AutoSize = False
        Me.txtUserID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUserID.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUserID.Location = New System.Drawing.Point(192, 152)
        Me.txtUserID.Name = "txtUserID"
        Me.txtUserID.Size = New System.Drawing.Size(130, 21)
        Me.txtUserID.TabIndex = 4
        Me.txtUserID.Text = "UserID + PasswordID"
        Me.txtUserID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtUserID.Visible = False
        '
        'chkActiveUser
        '
        Me.chkActiveUser.Location = New System.Drawing.Point(16, 158)
        Me.chkActiveUser.Name = "chkActiveUser"
        Me.chkActiveUser.TabIndex = 3
        Me.chkActiveUser.Text = "Active User"
        '
        'txtAliasName
        '
        Me.txtAliasName.AutoSize = False
        Me.txtAliasName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAliasName.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAliasName.Location = New System.Drawing.Point(136, 54)
        Me.txtAliasName.MaxLength = 40
        Me.txtAliasName.Name = "txtAliasName"
        Me.txtAliasName.Size = New System.Drawing.Size(232, 21)
        Me.txtAliasName.TabIndex = 1
        Me.txtAliasName.Text = ""
        '
        'lblAliasName
        '
        Me.lblAliasName.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAliasName.Location = New System.Drawing.Point(16, 58)
        Me.lblAliasName.Name = "lblAliasName"
        Me.lblAliasName.Size = New System.Drawing.Size(112, 22)
        Me.lblAliasName.TabIndex = 7
        Me.lblAliasName.Text = "Alias Name :"
        Me.lblAliasName.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'dgUserInfo
        '
        Me.dgUserInfo.BackColor = System.Drawing.Color.AliceBlue
        Me.dgUserInfo.BackgroundColor = System.Drawing.Color.White
        Me.dgUserInfo.CaptionVisible = False
        Me.dgUserInfo.DataMember = ""
        Me.dgUserInfo.GridLineColor = System.Drawing.Color.Gray
        Me.dgUserInfo.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgUserInfo.Location = New System.Drawing.Point(8, 216)
        Me.dgUserInfo.Name = "dgUserInfo"
        Me.dgUserInfo.ParentRowsVisible = False
        Me.dgUserInfo.ReadOnly = True
        Me.dgUserInfo.Size = New System.Drawing.Size(432, 144)
        Me.dgUserInfo.TabIndex = 1
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(8, 16)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(48, 48)
        Me.PictureBox1.TabIndex = 15
        Me.PictureBox1.TabStop = False
        '
        'frmAddUser
        '
        Me.AcceptButton = Me.cmdSave
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.CancelButton = Me.cmdCancel
        Me.ClientSize = New System.Drawing.Size(450, 370)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.dgUserInfo)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAddUser"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Add User"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dgUserInfo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Form Events"

    Private Sub frmAddUser_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '=====================================================================
        ' Procedure Name        : frmAddUser_Load
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To load the Add User form.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saruabh S. 
        ' Created               : Dec, 2006
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Try
            funcInitialize()

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

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : cmdSave_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To Save the User details added.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saruabh S. 
        ' Created               : Dec, 2006
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Try
            If funcSaveNewUser() Then
                funcGetExistingUsers()
                subFormatDataGrid()
                'MessageBox.Show("User Successfully")
                txtUserName.Text = ""
                txtAliasName.Text = ""
                txtPassword.Text = ""
                txtConfirmPassword.Text = ""
                txtUserID.Text = ""
            End If
            'Me.Close()

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

    Private Sub dgUserInfo_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgUserInfo.CurrentCellChanged
        '=====================================================================
        ' Procedure Name        : dgUserInfo_CurrentCellChanged
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To load the User details selected in the combo box.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saruabh S. 
        ' Created               : Dec, 2006
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Try
            ' dgUserInfo.Select(dgUserInfo.CurrentCell.RowNumber())
            dgUserInfo.Refresh()

            If (dgUserInfo.CurrentCell.ColumnNumber = ENUM_ColumnNos.Edit) Then
                mobjLinkLabel.Top = dgUserInfo.GetCurrentCellBounds().Top
                mobjLinkLabel.Left = dgUserInfo.GetCurrentCellBounds().Left
                mobjLinkLabel.Width = dgUserInfo.GetCurrentCellBounds().Width
                mobjLinkLabel.Height = dgUserInfo.GetCurrentCellBounds().Height
                mobjLinkLabel.Visible = True
                mobjLinkLabel.Text = dgUserInfo(dgUserInfo.CurrentCell.RowNumber, ENUM_ColumnNos.Edit)
            Else
                mobjLinkLabel.Width = 0
                mobjLinkLabel.Visible = False
            End If
            '----Added By Pankaj 30  MAy 07
            Call SubEditGrid(dgUserInfo)
            dgUserInfo.Refresh()
            If dgUserInfo.CurrentRowIndex >= 0 Then
                dgUserInfo.Select(dgUserInfo.CurrentRowIndex)
            End If
            '---------
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

#Region " Private functions"

    '--------------------------------------------------------
    '    General functions used for Adding User.
    '--- funcInitialize  - To Initialize the form and show all the users present.
    '--- funcGetExistingUsers - To Get the Current Users from the database and display them.
    '--- subCreateDataTable -  To Create a Data Table and add Values in it.
    '--- subFormatDataGrid -  To Format Data Grid .
    '--- funcSaveNewUser - To Save Newly Created User.

    Private Sub funcInitialize()
        '=====================================================================
        ' Procedure Name        :   funcInitialize
        ' Description           :   To Initialize the form and show all the users present.
        ' Purpose               :   To Initialize the form and show all the users present.
        ' Parameters Passed     :   None.
        ' Returns               :   None.
        ' Parameters Affected   :   None.
        ' Assumptions           :
        ' Dependencies          :
        ' Author                :   Gitesh
        ' Created               :   January, 2003 
        ' Revisions             :
        '=====================================================================
        Dim objWait As New CWaitCursor
        Try
            chkActiveUser.Checked = True
            txtUserName.Text = ""
            txtAliasName.Text = ""
            txtPassword.Text = ""
            txtConfirmPassword.Text = ""
            txtUserID.Text = ""

            '--- Passing database name to clsstrConnString property
            'mstrConnectionString = gclsDBFunctions.ConnectionString(CONST_USERINFO_DATABASENAME)

            '--- Passing connection string to Connection Object
            'mOledbConnection = New OleDbConnection(mstrConnectionString)

            AddHandler mobjLinkLabel.Click, AddressOf LinkLabel_Click
            AddHandler cmdCancel.Click, AddressOf cmdCancel_Click
            AddHandler cmdSave.Click, AddressOf cmdSave_Click

            dgUserInfo.Controls.Add(mobjLinkLabel)
            mobjLinkLabel.Visible = False

            subCreateDataTable()
            funcGetExistingUsers()
            subFormatDataGrid()

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

    Private Sub LinkLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        :   LinkLabel_Click
        ' Description           :   To Initialize the form and show all the users present.
        ' Purpose               :   To Initialize the form and show all the users present.
        ' Parameters Passed     :   None.
        ' Returns               :   None.
        ' Parameters Affected   :   None.
        ' Assumptions           :
        ' Dependencies          :
        ' Author                :   Gitesh
        ' Created               :   January, 2003 
        ' Revisions             :
        '=====================================================================
        Dim row_no As Integer
        Dim user_id, password_id As String
        Dim objWait As New CWaitCursor
        Try
            row_no = dgUserInfo.CurrentCell.RowNumber()

            txtUserName.Text = dgUserInfo(row_no, ENUM_ColumnNos.UserName)
            txtAliasName.Text = dgUserInfo(row_no, ENUM_ColumnNos.AliasName)
            txtPassword.Text = dgUserInfo(row_no, ENUM_ColumnNos.Password)
            user_id = dgUserInfo(row_no, ENUM_ColumnNos.UserID)
            password_id = dgUserInfo(row_no, ENUM_ColumnNos.PasswordID)

            txtUserID.Text = user_id & " , " & password_id
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

    Private Function funcGetExistingUsers() As Boolean
        '=====================================================================
        ' Procedure Name        :   funcGetExistingUsers
        ' Description           :   To Get the Current Users from the database and display them.
        ' Purpose               :   To Get the Current Users from the database and display them.
        ' Parameters Passed     :   None.
        ' Returns               :   None.
        ' Parameters Affected   :   None.
        ' Assumptions           :
        ' Dependencies          :
        ' Author                :   Gitesh
        ' Created               :   January, 2003 
        ' Revisions             :
        '=====================================================================
        Dim result As Boolean
        Dim str_sql As String
        Dim objReader As OleDb.OleDbDataReader
        Dim objDataRow As DataRow
        Dim objWait As New CWaitCursor
        Try

            mobjDataTable.Clear()

            '--- Generating dynamic query for selection type
            str_sql = "Select Users.UserID ,Users.UserName ,Users.AliasName ,Users.Active ,Passwords.PasswordID ,Passwords.PasswordName  " & _
                      "from Users ,Passwords " & _
                      "where Users.UserID = Passwords.UserID "

            'str_sql = "Select Users.UserID ,Users.UserName ,Users.AliasName ,Users.Active " & _
            '          "from Users "

            result = gclsDBFunctions.OpenConnection(gOleDBUserInfoConnection)
            If Not (result) Then
                Return False
            End If

            '--- Calling gfuncGetRecords to Get myreader populated with provided Query( strsqlServiceComments (Global String) Records
            gclsDBFunctions.GetRecords(str_sql, gOleDBUserInfoConnection, objReader)

            Dim str_password As String

            While objReader.Read
                objDataRow = mobjDataTable.NewRow
                objDataRow("UserName") = CStr(objReader.Item("UserName"))
                objDataRow("AliasName") = CStr(objReader.Item("AliasName"))
                objDataRow("Active") = CStr(objReader.Item("Active"))
                objDataRow("UserID") = CStr(objReader.Item("UserID"))
                objDataRow("PasswordID") = CStr(objReader.Item("PasswordID"))

                '--- To get encrypted password and decrypt and save it.
                str_password = CStr(objReader.Item("PasswordName"))
                objDataRow("PasswordName") = gfuncDecryptString(str_password)

                'objDataRow("PasswordName") = CStr(objReader.Item("PasswordName"))
                'objDataRow("Edit") = "Edit"

                mobjDataTable.Rows.Add(objDataRow)
            End While

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
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            '---------------------------------------------------------
        End Try
    End Function

    Private Sub subCreateDataTable()
        '=====================================================================
        ' Procedure Name        :   subCreateDataTable
        ' Description           :   To Create a Data Table and add Values in it.
        ' Purpose               :   To Create a Data Table and add Values in it.
        ' Parameters Passed     :   None.
        ' Returns               :   None.
        ' Parameters Affected   :   None.
        ' Assumptions           :
        ' Dependencies          :
        ' Author                :   Gitesh
        ' Created               :   January , 2003 
        ' Revisions             :
        '=====================================================================
        Dim objWait As New CWaitCursor
        Try
            mobjDataTable.Columns.Add(New DataColumn("UserName", GetType(String)))
            mobjDataTable.Columns.Add(New DataColumn("AliasName", GetType(String)))
            mobjDataTable.Columns.Add(New DataColumn("Active", GetType(Integer)))
            mobjDataTable.Columns.Add(New DataColumn("UserID", GetType(Integer)))
            mobjDataTable.Columns.Add(New DataColumn("PasswordID", GetType(Integer)))
            mobjDataTable.Columns.Add(New DataColumn("PasswordName", GetType(String)))
            'mobjDataTable.Columns.Add(New DataColumn("Edit", GetType(String)))
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

    Private Sub subFormatDataGrid()
        '=====================================================================
        ' Procedure Name        :   subFormatDataGrid
        ' Description           :   To Format Data Grid .
        ' Purpose               :   To Format Data Grid .
        ' Parameters Passed     :   None.
        ' Returns               :   None.
        ' Parameters Affected   :   None.
        ' Assumptions           :
        ' Dependencies          :
        ' Author                :   Gitesh
        ' Created               :   January , 2003 
        ' Revisions             :
        '=====================================================================
        Dim objTextColumn As DataGridTextBoxColumn
        Dim objDataView As New DataView
        Dim objWait As New CWaitCursor
        Try
            dgUserInfo.TableStyles.Clear()
            objDataView.Table = mobjDataTable
            objDataView.AllowNew = False
            dgUserInfo.DataSource = objDataView
            dgUserInfo.ReadOnly = True ' False Added By Pankaj 30 May 07


            mobjGridTableStyle = New DataGridTableStyle

            mobjGridTableStyle.ResetAlternatingBackColor()
            mobjGridTableStyle.ResetBackColor()
            mobjGridTableStyle.ResetForeColor()
            mobjGridTableStyle.ResetGridLineColor()
            mobjGridTableStyle.BackColor = Color.White
            mobjGridTableStyle.HeaderBackColor = Color.FromArgb(205, 225, 250)
            mobjGridTableStyle.HeaderForeColor = Color.Black
            mobjGridTableStyle.AlternatingBackColor = Color.White
            mobjGridTableStyle.AllowSorting = False
            mobjGridTableStyle.ReadOnly = True
            mobjGridTableStyle.MappingName = "UserInfo"
            mobjGridTableStyle.RowHeadersVisible = True
            mobjGridTableStyle.RowHeaderWidth = 0.5
            mobjGridTableStyle.SelectionBackColor = Color.Gray
            mobjGridTableStyle.SelectionForeColor = Color.White
            mobjGridTableStyle.GridLineColor = Color.Gray


            objTextColumn = New DataGridTextBoxColumn
            objTextColumn.MappingName = "UserID"
            objTextColumn.HeaderText = "User ID"
            objTextColumn.Width = 88
            objTextColumn.NullText = ""
            objTextColumn.ReadOnly = True
            objTextColumn.Alignment = HorizontalAlignment.Center
            mobjGridTableStyle.GridColumnStyles.Add(objTextColumn)

            objTextColumn = New DataGridTextBoxColumn
            objTextColumn.MappingName = "UserName"
            objTextColumn.HeaderText = "User Name"
            objTextColumn.Width = 120
            objTextColumn.NullText = ""
            objTextColumn.ReadOnly = True
            mobjGridTableStyle.GridColumnStyles.Add(objTextColumn)

            objTextColumn = New DataGridTextBoxColumn
            objTextColumn.MappingName = "AliasName"
            objTextColumn.NullText = ""
            objTextColumn.HeaderText = "Alias Name"
            objTextColumn.Width = 120
            objTextColumn.ReadOnly = True
            mobjGridTableStyle.GridColumnStyles.Add(objTextColumn)

            objTextColumn = New DataGridTextBoxColumn
            objTextColumn.MappingName = "PasswordName"
            objTextColumn.HeaderText = "Password"
            objTextColumn.Width = 0
            objTextColumn.NullText = ""
            objTextColumn.ReadOnly = True
            mobjGridTableStyle.GridColumnStyles.Add(objTextColumn)

            objTextColumn = New DataGridTextBoxColumn
            objTextColumn.MappingName = "Active"
            objTextColumn.HeaderText = "Active"
            objTextColumn.Width = 85
            objTextColumn.NullText = ""
            objTextColumn.ReadOnly = True
            objTextColumn.Alignment = HorizontalAlignment.Center
            mobjGridTableStyle.GridColumnStyles.Add(objTextColumn)

            objTextColumn = New DataGridTextBoxColumn
            objTextColumn.MappingName = "PasswordID"
            objTextColumn.HeaderText = "PasswordID"
            objTextColumn.Width = 0
            objTextColumn.ReadOnly = True
            mobjGridTableStyle.GridColumnStyles.Add(objTextColumn)

            objTextColumn = New DataGridTextBoxColumn
            objTextColumn.MappingName = "Edit"
            objTextColumn.HeaderText = ""
            objTextColumn.NullText = ""
            objTextColumn.Width = 50
            objTextColumn.ReadOnly = True

            mobjGridTableStyle.GridColumnStyles.Add(objTextColumn)
            mobjGridTableStyle.GridLineColor = Color.AliceBlue
            dgUserInfo.TableStyles.Add(mobjGridTableStyle)
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

    Private Function funcSaveNewUser() As Boolean
        '=====================================================================
        ' Procedure Name        :   funcSaveNewUser
        ' Description           :   To Save the newly created user/Edited User into database.
        ' Purpose               :   To Save the newly created user/Edited User into database.
        ' Parameters Passed     :   None.
        ' Returns               :   None.
        ' Parameters Affected   :   None.
        ' Assumptions           :
        ' Dependencies          :
        ' Author                :   Gitesh
        ' Created               :   February, 2003 
        ' Revisions             :
        '=====================================================================
        Dim str_userid As String
        Dim objWait As New CWaitCursor
        Try

            If txtUserName.Text = "" Or txtPassword.Text = "" Then
                gobjMessageAdapter.ShowMessage(constEnterUserNamePassword)
                Return False
                Exit Function
            End If
            If txtConfirmPassword.Text = "" Then
                gobjMessageAdapter.ShowMessage(constConfirmPassword)
                txtConfirmPassword.Focus()
                Return False
                Exit Function
            End If
            If StrComp(txtPassword.Text, txtConfirmPassword.Text, CompareMethod.Text) <> 0 Then
                gobjMessageAdapter.ShowMessage(constInvalidPasswordConfirm)
                Return False
                Exit Function
            End If


            str_userid = txtUserID.Text
            If ((str_userid = "") Or (str_userid = Nothing)) Then
                If (funcValidateUsers() = False) Then
                    gobjMessageAdapter.ShowMessage(constUserExists)
                    txtUserName.Focus()
                    Return False
                    Exit Function
                End If

                Call funcInsertNewUser()
            Else
                Call funcUpdateUser()
            End If
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
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            '---------------------------------------------------------
        End Try

    End Function

    Private Function funcValidateUsers() As Boolean
        '=====================================================================
        ' Procedure Name        :   funcValidateUsers
        ' Description           :   
        ' Purpose               :   
        ' Parameters Passed     :   None.
        ' Returns               :   None.
        ' Parameters Affected   :   None.
        ' Assumptions           :
        ' Dependencies          :
        ' Author                :   Pankaj Bamb 
        ' Created               :   30 May 2007 
        ' Revisions             :
        '=====================================================================
        Dim result As Boolean
        Dim str_sql As String
        Dim objReader As OleDb.OleDbDataReader
        Try
            '--- Generating dynamic query for selection type
            str_sql = "SELECT Count(Users.UserName) AS CountOfUserName" _
                       & " FROM Users where Users.UserName='" & txtUserName.Text.Trim() & "' "

            result = gclsDBFunctions.OpenConnection(gOleDBUserInfoConnection)
            If Not (result) Then
                Return False
            End If

            '--- Calling gfuncGetRecords to Get myreader populated with provided Query( strsqlServiceComments (Global String) Records
            gclsDBFunctions.GetRecords(str_sql, gOleDBUserInfoConnection, objReader)

            Dim intCountOfUserName As Integer = 0

            If (objReader.Read) Then
                intCountOfUserName = CInt(objReader.Item("CountOfUserName"))
            End If
            objReader.Close()
            If intCountOfUserName <= 0 Then
                Return True
            End If
            Return False
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
            Return False
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            
            '---------------------------------------------------------
        End Try
    End Function

    Private Function funcInsertNewUser() As Boolean
        '=====================================================================
        ' Procedure Name        :   funcInsertNewUser
        ' Description           :   To Save the newly user created into database.
        ' Purpose               :   To Save the newly user created into database.
        ' Parameters Passed     :   None.
        ' Returns               :   None.
        ' Parameters Affected   :   None.
        ' Assumptions           :
        ' Dependencies          :
        ' Author                :   Gitesh
        ' Created               :   January, 2003 
        ' Revisions             :
        '=====================================================================
        Dim objWait As New CWaitCursor
        Dim str_sql As String
        Dim Status As Boolean
        Dim objCommand As New OleDbCommand
        Dim objTransaction As OleDbTransaction
        Dim user_id, password_id As Long
        Dim active_value As Integer

        Try
            Status = gclsDBFunctions.OpenConnection(gOleDBUserInfoConnection)
            If Not (Status) Then
                Return False
            End If

            '--- Generating ID for User
            user_id = gclsDBFunctions.GetNextID("Users", "UserID", gOleDBUserInfoConnection)

            Status = gclsDBFunctions.OpenConnection(gOleDBUserInfoConnection)
            If Not (Status) Then
                Return False
            End If

            password_id = gclsDBFunctions.GetNextID("Passwords", "PasswordID", gOleDBUserInfoConnection)
            If (chkActiveUser.Checked = True) Then
                active_value = 1
            Else
                active_value = 0
            End If

            objTransaction = gOleDBUserInfoConnection.BeginTransaction()

            '---  Query for Insert into Users Table
            str_sql = "Insert into Users " & _
                      "(UserID ,UserName ,AliasName ,Active) " & _
                      " values(?,?,?,?)"

            '--- Providing command object for Users
            With objCommand
                .Connection = gOleDBUserInfoConnection
                .CommandType = CommandType.Text
                .CommandText = str_sql
                .Transaction = objTransaction
                .Parameters.Add("UserID", OleDbType.BigInt).Value = user_id
                .Parameters.Add("UserName", OleDbType.VarChar).Value = Trim(txtUserName.Text)
                .Parameters.Add("AliasName", OleDbType.VarChar).Value = Trim(txtAliasName.Text)
                .Parameters.Add("Active", OleDbType.Integer).Value = active_value
                .ExecuteNonQuery()
            End With

            objCommand.Dispose()

            '-- To Encrypt the Password.
            Dim str_password As String
            str_password = gfuncEncryptString(Trim(txtPassword.Text))

            '---  Query for Insert into Password Table
            str_sql = "Insert into Passwords  " & _
                      "(PasswordID ,UserID ,PasswordName) " & _
                      " values(?,?,?)"
            '" values(" & password_id & ", " & user_id & " ,'" & txtPassword.Text & "' )"

            '--- Providing command object for Users
            With objCommand
                .Connection = gOleDBUserInfoConnection
                .CommandType = CommandType.Text
                .CommandText = str_sql
                .Transaction = objTransaction
                .Parameters.Add("PasswordID", OleDbType.BigInt).Value = password_id
                .Parameters.Add("UserId", OleDbType.BigInt).Value = user_id
                .Parameters.Add("PasswordName", OleDbType.VarChar).Value = str_password
                .ExecuteNonQuery()
            End With

            '.Parameters.Add("PasswordName", OleDbType.VarChar).Value = Trim(txtPassword.Text)
            objCommand.Dispose()
            objTransaction.Commit()
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
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            '---------------------------------------------------------
        End Try

    End Function

    Private Function funcUpdateUser() As Boolean
        '=====================================================================
        ' Procedure Name        :   funcUpdateUser
        ' Description           :   To Save the Edited user info into database.
        ' Purpose               :   To Save the Edited user info into database.
        ' Parameters Passed     :   None.
        ' Returns               :   None.
        ' Parameters Affected   :   None.
        ' Assumptions           :
        ' Dependencies          :
        ' Author                :   Gitesh
        ' Created               :   February, 2003 
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
            str_id = txtUserID.Text
            arr_id = str_id.Split(",")
            user_id = Convert.ToInt64(arr_id(0))
            password_id = Convert.ToInt64(arr_id(1))

            Status = gclsDBFunctions.OpenConnection(gOleDBUserInfoConnection)
            If Not (Status) Then
                Return False
            End If

            If (chkActiveUser.Checked = True) Then
                active_value = 1
            Else
                active_value = 0
            End If

            objTransaction = gOleDBUserInfoConnection.BeginTransaction()

            '---  Query for Update Users Table
            str_sql = "Update Users " & _
                      "Set UserName = ? ,AliasName = ? ,Active = ? " & _
                      "where UserID = " & user_id & " "

            '--- Providing command object for Users
            With objCommand
                .Connection = gOleDBUserInfoConnection
                .CommandType = CommandType.Text
                .CommandText = str_sql
                .Transaction = objTransaction
                .Parameters.Add("UserName", OleDbType.VarChar).Value = Trim(txtUserName.Text)
                .Parameters.Add("AliasName", OleDbType.VarChar).Value = Trim(txtAliasName.Text)
                .Parameters.Add("Active", OleDbType.Integer).Value = active_value
                .ExecuteNonQuery()
            End With

            objCommand.Dispose()

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

            '.Parameters.Add("PasswordName", OleDbType.VarChar).Value = Trim(txtPassword.Text)
            objCommand.Dispose()
            objTransaction.Commit()
            Return (True)

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

    Private Sub SubEditGrid(ByVal ObjDataGrid As DataGrid)
        '=====================================================================
        ' Procedure Name        :   SubEditGrid
        ' Description           :   To Save the Edited user info into database.
        ' Purpose               :   To Save the Edited user info into database.
        ' Parameters Passed     :   None.
        ' Returns               :   None.
        ' Parameters Affected   :   None.
        ' Assumptions           :
        ' Dependencies          :
        ' Author                :   Gitesh
        ' Created               :   February, 2003 
        ' Revisions             :
        '=====================================================================
        Dim objWait As New CWaitCursor
        Dim row_no As Integer
        Dim user_id, password_id As String

        Try

            row_no = dgUserInfo.CurrentCell.RowNumber()

            txtUserName.Text = dgUserInfo(row_no, ENUM_ColumnNos.UserName)
            txtAliasName.Text = dgUserInfo(row_no, ENUM_ColumnNos.AliasName)
            txtPassword.Text = dgUserInfo(row_no, ENUM_ColumnNos.Password)
            txtConfirmPassword.Text = dgUserInfo(row_no, ENUM_ColumnNos.Password)
            user_id = dgUserInfo(row_no, ENUM_ColumnNos.UserID)
            password_id = dgUserInfo(row_no, ENUM_ColumnNos.PasswordID)
            '--------Added By Pankaj 17 May 2007 4:33
            If (dgUserInfo(row_no, ENUM_ColumnNos.Active) = 1) Then
                chkActiveUser.Checked = True
            Else
                chkActiveUser.Checked = False
            End If
            '---------
            txtUserID.Text = user_id & " , " & password_id
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

    Private Sub dgUserInfo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgUserInfo.Click
        '=====================================================================
        ' Procedure Name        :   dgUserInfo_Click
        ' Description           :   To Save the Edited user info into database.
        ' Purpose               :   To Save the Edited user info into database.
        ' Parameters Passed     :   None.
        ' Returns               :   None.
        ' Parameters Affected   :   None.
        ' Assumptions           :
        ' Dependencies          :
        ' Author                :   Saurabh
        ' Created               :   05-01-2007
        ' Revisions             :
        '=====================================================================
        Dim objWait As New CWaitCursor
        Try
            Call SubEditGrid(dgUserInfo)
            '-----Added By Pankaj 30 May 07
            dgUserInfo.Refresh()
            If dgUserInfo.CurrentRowIndex >= 0 Then
                dgUserInfo.Select(dgUserInfo.CurrentRowIndex)
            End If
            '-----

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

    Private Sub dgUserInfo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgUserInfo.GotFocus
        '=====================================================================
        ' Procedure Name        :   dgUserInfo_GotFocus
        ' Description           :   To show the selected record in textboxes.
        ' Purpose               :   To show the selected record in textboxes.
        ' Parameters Passed     :   None.
        ' Returns               :   None.
        ' Parameters Affected   :   None.
        ' Assumptions           :
        ' Dependencies          :
        ' Author                :   Saurabh
        ' Revisions             :   05-01-2007
        '=====================================================================
        Dim objWait As New CWaitCursor
        Try
            If dgUserInfo.CurrentRowIndex >= 0 Then
                'dgUserInfo.Select(dgUserInfo.CurrentRowIndex)
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


End Class
