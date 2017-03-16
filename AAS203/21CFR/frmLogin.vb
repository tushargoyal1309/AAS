Imports AAS203.Common
Imports System.Text
Imports System.Data.OleDb
Public Class frmLogin
    Inherits System.Windows.Forms.Form

#Region "Module Level Declarations"
    Private mblnLogin As Boolean
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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbLoginName As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents btnLogin As NETXP.Controls.XPButton
    Friend WithEvents btnCancel As NETXP.Controls.XPButton
    Friend WithEvents Office2003Header1 As CodeIntellects.Office2003Controls.Office2003Header
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmLogin))
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmbLoginName = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtPassword = New System.Windows.Forms.TextBox
        Me.btnCancel = New NETXP.Controls.XPButton
        Me.btnLogin = New NETXP.Controls.XPButton
        Me.Office2003Header1 = New CodeIntellects.Office2003Controls.Office2003Header
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(74, 54)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "User Name :"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'cmbLoginName
        '
        Me.cmbLoginName.BackColor = System.Drawing.Color.White
        Me.cmbLoginName.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmbLoginName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLoginName.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbLoginName.ForeColor = System.Drawing.Color.Black
        Me.cmbLoginName.Location = New System.Drawing.Point(164, 48)
        Me.cmbLoginName.Name = "cmbLoginName"
        Me.cmbLoginName.Size = New System.Drawing.Size(196, 23)
        Me.cmbLoginName.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(74, 82)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 17)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Password :"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtPassword
        '
        Me.txtPassword.BackColor = System.Drawing.Color.White
        Me.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPassword.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPassword.ForeColor = System.Drawing.Color.Black
        Me.txtPassword.Location = New System.Drawing.Point(164, 80)
        Me.txtPassword.MaxLength = 50
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(196, 21)
        Me.txtPassword.TabIndex = 1
        Me.txtPassword.Text = ""
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Image = CType(resources.GetObject("btnCancel.Image"), System.Drawing.Image)
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancel.Location = New System.Drawing.Point(260, 128)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(100, 34)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "&Cancel"
        '
        'btnLogin
        '
        Me.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLogin.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLogin.Image = CType(resources.GetObject("btnLogin.Image"), System.Drawing.Image)
        Me.btnLogin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLogin.Location = New System.Drawing.Point(155, 128)
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.Size = New System.Drawing.Size(100, 34)
        Me.btnLogin.TabIndex = 2
        Me.btnLogin.Text = "&Login"
        '
        'Office2003Header1
        '
        Me.Office2003Header1.BackColor = System.Drawing.SystemColors.Control
        Me.Office2003Header1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Office2003Header1.Location = New System.Drawing.Point(0, 0)
        Me.Office2003Header1.Name = "Office2003Header1"
        Me.Office2003Header1.Size = New System.Drawing.Size(382, 22)
        Me.Office2003Header1.TabIndex = 4
        Me.Office2003Header1.TitleFont = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Office2003Header1.TitleText = "Login Authentication"
        '
        'frmLogin
        '
        Me.AcceptButton = Me.btnLogin
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(382, 178)
        Me.ControlBox = False
        Me.Controls.Add(Me.Office2003Header1)
        Me.Controls.Add(Me.btnLogin)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.cmbLoginName)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLogin"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TopMost = True
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Form Events"

    Private Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        '=====================================================================
        ' Procedure Name        : btnLogin_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To validate the user.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saruabh S. 
        ' Created               : Dec, 2006
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Dim lngUserID As Long
        Dim strPassword As String
        Dim intCounter As Integer
        Dim intUserList As Integer
        Dim strAccess As String
        Dim strSplittedAcess() As String
        Dim strSQL As String
        Dim objReader As OleDb.OleDbDataReader
        Dim objReaderAccess As OleDb.OleDbDataReader



        Try
            Me.TopMost = False
            If Not cmbLoginName.Text = "" Then
                lngUserID = Convert.ToInt64(cmbLoginName.SelectedValue)





                strPassword = txtPassword.Text
                If gfuncValidateUser(lngUserID, strPassword) Then
                    gstructUserDetails.Access = New ArrayList
                    strSQL = "Select * From UserAccess Where UserID=" & lngUserID
                    '--- Calling gfuncGetRecords to Get myreader populated with provided Query( strsqlServiceComments (Global String) Records
                    If gclsDBFunctions.GetRecords(strSQL, gOleDBUserInfoConnection, objReader) Then
                        While objReader.Read
                            strAccess = Convert.ToString(objReader.Item("UserAccess"))
                        End While
                        objReader.Close()

                        If Len(strAccess) > 0 Then
                            strSplittedAcess = strAccess.Split(",")
                            For intCounter = 0 To strSplittedAcess.Length - 1
                                gstructUserDetails.Access.Add(Convert.ToInt64(strSplittedAcess(intCounter)))
                            Next
                        End If
                    End If
                    gstructUserDetails.UserID = lngUserID
                    gstructUserDetails.UserName = Trim(cmbLoginName.Text)
                    gstructUserDetails.UserPassword = Trim(txtPassword.Text)

                    LoginSuccessfull = True
                    Me.DialogResult = DialogResult.OK
                Else
                    gstructUserDetails.UserID = lngUserID
                    gstructUserDetails.UserName = Trim(cmbLoginName.Text)
                    gfuncInsertActivityLog(EnumModules.Login, "Login failed", strPassword)
                    gobjMessageAdapter.ShowMessage(constIncorrectPassword)
                    LoginSuccessfull = False
                    txtPassword.Text = ""
                    Me.DialogResult = DialogResult.None
                End If
            Else
                gobjMessageAdapter.ShowMessage(constUserNotSelected)
                Me.DialogResult = DialogResult.None
            End If
            Me.TopMost = True

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

    Private Sub frmLogin_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        '=====================================================================
        ' Procedure Name        : frmLogin_Activated
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To activate the Login form.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saruabh S. 
        ' Created               : Dec, 2006
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Try
            txtPassword.Focus()

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

    Private Sub frmLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '=====================================================================
        ' Procedure Name        : frmLogin_Load
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To load the Login form.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saruabh S. 
        ' Created               : Dec, 2006
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Try
            LoginSuccessfull = False
            funcInitialize()
            txtPassword.Focus()

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

#Region "Private functions"

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
        ' Created               :   March, 2003 
        ' Revisions             :
        '=====================================================================
        Dim objWait As New CWaitCursor
        Try
            cmbLoginName.Items.Clear()
            funcGetExistingUsers()

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
        ' Created               :   March, 2003 
        ' Revisions             :
        '=====================================================================
        Dim result As Boolean
        Dim str_sql As String
        Dim objDataAdapter As OleDbDataAdapter
        Dim objCommand As OleDbCommand
        Dim objReader As OleDbDataReader
        Dim ds As New DataSet
        Dim strUserName As String
        Dim intUserId As Integer
        Dim objWait As New CWaitCursor
        Try

            '--- Generating dynamic query for selection type
            str_sql = "Select UserID ,UserName " & _
                      "from Users where Active = 1 "
            objCommand = New OleDbCommand(str_sql, gOleDBUserInfoConnection)
            objDataAdapter = New OleDbDataAdapter(objCommand)
            objDataAdapter.Fill(ds, "Users")

            Dim objDV As DataView
            objDV = New DataView(ds.Tables("Users"))

            cmbLoginName.Items.Clear()
            cmbLoginName.DataSource = objDV
            cmbLoginName.DisplayMember = "UserName"
            cmbLoginName.ValueMember = "UserID"

            If cmbLoginName.Items.Count <> 0 Then
                '---commented mdf by kamal & sns  on 13 oct 2004
                intUserId = CInt(gstructUserDetails.UserID)
                cmbLoginName.SelectedValue = intUserId
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
        Return True

    End Function

#End Region

#Region "Property"
    Property LoginSuccessfull() As Boolean
        Get
            Return mblnLogin
        End Get
        Set(ByVal Value As Boolean)
            mblnLogin = Value
        End Set
    End Property
#End Region

  
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub

End Class
