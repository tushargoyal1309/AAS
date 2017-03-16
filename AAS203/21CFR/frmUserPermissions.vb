Option Explicit On 
Imports AAS203.Common
Imports System.Data
Imports System.Data.OleDb

Public Class frmUserPermissions
    Inherits System.Windows.Forms.Form

#Region "Module level Declarations "
    'Private mstrConnectionString As String
    'Private mclsDBFunctions As New clsDatabaseFunctions()
    'Private mOledbConnection As OleDb.OleDbConnection

    Dim mobjDataTable As New DataTable("UserAccess")
    Dim mobjGridTableStyle As New DataGridTableStyle

    Dim mblnCmbSelectEvent As Boolean = False
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
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents chkAllAccesRights As System.Windows.Forms.CheckBox
    Friend WithEvents dgUserAccess As System.Windows.Forms.DataGrid
    Friend WithEvents cmbUserName As System.Windows.Forms.ComboBox
    Friend WithEvents lblUserName As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents cmdSave As NETXP.Controls.XPButton
    Friend WithEvents cmdCancel As NETXP.Controls.XPButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmUserPermissions))
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.cmdCancel = New NETXP.Controls.XPButton
        Me.cmdSave = New NETXP.Controls.XPButton
        Me.chkAllAccesRights = New System.Windows.Forms.CheckBox
        Me.dgUserAccess = New System.Windows.Forms.DataGrid
        Me.cmbUserName = New System.Windows.Forms.ComboBox
        Me.lblUserName = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.Panel1.SuspendLayout()
        CType(Me.dgUserAccess, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.cmdCancel)
        Me.Panel1.Controls.Add(Me.cmdSave)
        Me.Panel1.Controls.Add(Me.chkAllAccesRights)
        Me.Panel1.Controls.Add(Me.dgUserAccess)
        Me.Panel1.Controls.Add(Me.cmbUserName)
        Me.Panel1.Controls.Add(Me.lblUserName)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.PictureBox2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(378, 359)
        Me.Panel1.TabIndex = 0
        '
        'cmdCancel
        '
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdCancel.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancel.Image = CType(resources.GetObject("cmdCancel.Image"), System.Drawing.Image)
        Me.cmdCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancel.Location = New System.Drawing.Point(270, 319)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(100, 34)
        Me.cmdCancel.TabIndex = 5
        Me.cmdCancel.Text = "&Cancel"
        '
        'cmdSave
        '
        Me.cmdSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdSave.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSave.Image = CType(resources.GetObject("cmdSave.Image"), System.Drawing.Image)
        Me.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSave.Location = New System.Drawing.Point(159, 319)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(100, 34)
        Me.cmdSave.TabIndex = 4
        Me.cmdSave.Text = "&Save"
        '
        'chkAllAccesRights
        '
        Me.chkAllAccesRights.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkAllAccesRights.Location = New System.Drawing.Point(144, 88)
        Me.chkAllAccesRights.Name = "chkAllAccesRights"
        Me.chkAllAccesRights.Size = New System.Drawing.Size(136, 24)
        Me.chkAllAccesRights.TabIndex = 2
        Me.chkAllAccesRights.Text = "Admin Permissions"
        '
        'dgUserAccess
        '
        Me.dgUserAccess.BackgroundColor = System.Drawing.Color.AliceBlue
        Me.dgUserAccess.CaptionVisible = False
        Me.dgUserAccess.DataMember = ""
        Me.dgUserAccess.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgUserAccess.Location = New System.Drawing.Point(6, 120)
        Me.dgUserAccess.Name = "dgUserAccess"
        Me.dgUserAccess.ParentRowsVisible = False
        Me.dgUserAccess.ReadOnly = True
        Me.dgUserAccess.RowHeadersVisible = False
        Me.dgUserAccess.Size = New System.Drawing.Size(364, 194)
        Me.dgUserAccess.TabIndex = 3
        '
        'cmbUserName
        '
        Me.cmbUserName.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmbUserName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUserName.Location = New System.Drawing.Point(160, 32)
        Me.cmbUserName.Name = "cmbUserName"
        Me.cmbUserName.Size = New System.Drawing.Size(208, 23)
        Me.cmbUserName.TabIndex = 1
        '
        'lblUserName
        '
        Me.lblUserName.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUserName.Location = New System.Drawing.Point(75, 35)
        Me.lblUserName.Name = "lblUserName"
        Me.lblUserName.Size = New System.Drawing.Size(80, 17)
        Me.lblUserName.TabIndex = 28
        Me.lblUserName.Text = "User Name"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.AliceBlue
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(5, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(48, 48)
        Me.PictureBox1.TabIndex = 34
        Me.PictureBox1.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Gray
        Me.PictureBox2.Location = New System.Drawing.Point(72, 16)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(290, 2)
        Me.PictureBox2.TabIndex = 35
        Me.PictureBox2.TabStop = False
        '
        'frmUserPermissions
        '
        Me.AcceptButton = Me.cmdSave
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.CancelButton = Me.cmdCancel
        Me.ClientSize = New System.Drawing.Size(378, 359)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmUserPermissions"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "User Access Permissions"
        Me.Panel1.ResumeLayout(False)
        CType(Me.dgUserAccess, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Form Events"

    Private Sub frmUserPermissions_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

    Private Sub chkAllAccesRights_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAllAccesRights.CheckedChanged
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
            If chkAllAccesRights.Checked = True Then
                If funcSelectAllAccess() Then
                    dgUserAccess.ReadOnly = True
                End If
            Else
                'If funcClearAllAccess() Then
                If dgUserAccess.ReadOnly = True Then
                    dgUserAccess.ReadOnly = False
                End If
                'End If
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

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
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
            If funcSaveUserPermisssions() Then
                gobjMessageAdapter.ShowMessage(constUserPermissionsSaved)
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

    Private Sub cmbUserName_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbUserName.SelectedIndexChanged
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
            If mblnCmbSelectEvent Then
                Dim user_id As Long = Convert.ToInt64(cmbUserName.SelectedValue)
                funcClearAllAccess()
                funcGetAccessForUser()
                '//---- Added by Sachin Dokhale.
                Call subFormatDataGrid()
                '//-----
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

#Region "Private functions"

    '--------------------------------------------------------
    '    General functions used for Adding User.
    '--- funcInitialize  - To Initialize the form and show all the users present in Combo Box.
    '--- funcGetExistingUsers - To Get the Current Users from the database and display them in ComboBox.
    '--- funcGetAccessForUser - To Get the Access Permissions for the Currently Selected User.
    '--- subCreateDataTable - To Create a Data Table and add Values in it.
    '--- subFormatDataGrid - To Format the DataGrid.
    '--- funcSaveUserPermisssions - To Save the User Permissions into the Database.
    '--- funcInsertData - To Add/Insert New User Access Record.
    '--- funcUpdateData - To Update User Access Record.
    '--- funcClearAllAccess - To Clear All Access Rights for the User.

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
            cmbUserName.Items.Clear()

            '--- Passing database name to clsstrConnString property
            'mstrConnectionString = gclsDBFunctions.ConnectionString(CONST_USERINFO_DATABASENAME)

            '--- Passing connection string to Connection Object
            'mOledbConnection = New OleDbConnection(mstrConnectionString)

            funcGetExistingUsers()
            subCreateDataTable()
            funcGetAllAccessValues()
            subFormatDataGrid()
            mblnCmbSelectEvent = True
            AddHandler cmdSave.Click, AddressOf cmdSave_Click
            AddHandler cmdCancel.Click, AddressOf cmdCancel_Click
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
        Dim objDataAdapter As OleDbDataAdapter
        Dim objCommand As OleDbCommand
        Dim objReader As OleDbDataReader
        Dim ds As New DataSet
        Dim objWait As New CWaitCursor
        Try

            '--- Generating dynamic query for selection type
            str_sql = "Select UserID ,UserName " & _
                      "from Users where Active = 1 and UserID > 0 Order by UserName "

            'result = gclsDBFunctions.OpenConnection(gOleDBUserInfoConnection)
            'If Not (result) Then
            '    Return False
            'End If

            objCommand = New OleDbCommand(str_sql, gOleDBUserInfoConnection)
            objDataAdapter = New OleDbDataAdapter(objCommand)
            objDataAdapter.Fill(ds, "Users")

            Dim objDV As DataView
            objDV = New DataView(ds.Tables("Users"))

            cmbUserName.Items.Clear()
            cmbUserName.DataSource = objDV
            cmbUserName.DisplayMember = "UserName"
            cmbUserName.ValueMember = "UserID"

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
        Try
            mobjDataTable.Columns.Add(New DataColumn("AccessID", GetType(Integer)))
            mobjDataTable.Columns.Add(New DataColumn("AccessName", GetType(String)))
        mobjDataTable.Columns.Add(New DataColumn("Rights", GetType(Boolean)))

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

    Private Function funcGetAllAccessValues() As Boolean
        '=====================================================================
        ' Procedure Name        :   funcGetAllAccessValues
        ' Description           :   To Get All the Access Permissions from the Access Master.
        ' Purpose               :   To Get All the Access Permissions from the Access Master.
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
        Dim user_id, access_id As Long
        Dim objWait As New CWaitCursor
        Try
            str_sql = "Select AccessID ,Access " & _
                      "from AccessMaster where Suspend = 0 ORDER by AccessID "

            'result = gclsDBFunctions.OpenConnection(gOleDBUserInfoConnection)
            'If Not (result) Then
            '    Return False
            'End If

            '--- Calling gfuncGetRecords to Get myreader populated with provided Query( strsqlServiceComments (Global String) Records
            gclsDBFunctions.GetRecords(str_sql, gOleDBUserInfoConnection, objReader)

            While objReader.Read
                objDataRow = mobjDataTable.NewRow
                objDataRow("AccessID") = Convert.ToInt32(objReader.Item("AccessID"))
                objDataRow("AccessName") = CStr(objReader.Item("Access"))
                mobjDataTable.Rows.Add(objDataRow)
            End While

            objReader.Close()

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


        funcClearAllAccess()
        funcGetAccessForUser()

        'user_id = Convert.ToInt64(cmbUserName.SelectedValue)
        'For Each objDataRow In mobjDataTable.Rows
        '    access_id = objDataRow("AccessID")
        '    If funcValidateUserAccess(user_id, access_id) Then
        '        objDataRow("Rights") = True
        '    Else
        '        objDataRow("Rights") = False
        '    End If
        'Next

        Return True

    End Function

    Private Function funcGetAccessForUser() As Boolean
        '=====================================================================
        ' Procedure Name        :   funcGetAccessForUser
        ' Description           :   To Get the Access Permissions for the Currently Selected User.
        ' Purpose               :   To Get the Access Permissions for the Currently Selected User.
        ' Parameters Passed     :   None.
        ' Returns               :   None.
        ' Parameters Affected   :   None.
        ' Assumptions           :
        ' Dependencies          :
        ' Author                :   Gitesh
        ' Created               :   January, 2003 
        ' Revisions             :
        '=====================================================================
        Dim user_id, access_id As Long
        Dim objDataRow As DataRow
        Dim objWait As New CWaitCursor

        '--- This flag is only used to check whther the user has all 
        '--- access wrigths and if he has it then the checdk box has to made
        '--- checked (used by nilesh)
        Dim blnAllAcceswrigths As Boolean

        Try

            user_id = Convert.ToInt64(cmbUserName.SelectedValue)
            For Each objDataRow In mobjDataTable.Rows
                access_id = objDataRow("AccessID")
                If funcValidateUserAccess(user_id, access_id) Then
                    objDataRow("Rights") = True
                    'modified by kamal
                    'if only last access is true it shows true fir all
                    '    blnAllAcceswrigths = True
                Else
                    objDataRow("Rights") = False
                    '     blnAllAcceswrigths = False
                End If
            Next

            For Each objDataRow In mobjDataTable.Rows
                If objDataRow("Rights") = False Then
                    blnAllAcceswrigths = False
                    Exit For
                End If
                blnAllAcceswrigths = True
            Next

            '--- Logic to check them
            If blnAllAcceswrigths = True Then
                chkAllAccesRights.Checked = True
                If dgUserAccess.ReadOnly = False Then
                    dgUserAccess.ReadOnly = True
                End If
            Else
                chkAllAccesRights.Checked = False
                If dgUserAccess.ReadOnly = True Then
                    dgUserAccess.ReadOnly = False
                End If
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

    Private Function funcClearAllAccess() As Boolean
        '=====================================================================
        ' Procedure Name        :   funcClearAllAccess 
        ' Description           :   To Clear All Access Rights for the User.
        ' Purpose               :   To Clear All Access Rights for the User.
        ' Parameters Passed     :   None.
        ' Returns               :   None.
        ' Parameters Affected   :   None.
        ' Assumptions           :
        ' Dependencies          :
        ' Author                :   Gitesh
        ' Created               :   January, 2003 
        ' Revisions             :
        '=====================================================================
        Dim objDataRow As DataRow
        Dim objWait As New CWaitCursor
        Try

            For Each objDataRow In mobjDataTable.Rows
                objDataRow("Rights") = False
            Next
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

    Private Function funcSelectAllAccess() As Boolean
        '=====================================================================
        ' Procedure Name        :   funcClearAllAccess 
        ' Description           :   To Select all Access wrigths Present in the List
        ' Purpose               :   To Select all Access wrigths Present in the List
        ' Parameters Passed     :   None.
        ' Returns               :   None.
        ' Parameters Affected   :   None.
        ' Assumptions           :
        ' Dependencies          :
        ' Author                :   Nilesh Shirode
        ' Created               :   27 June 2004 
        ' Revisions             :
        '=====================================================================
        Dim objDataRow As DataRow
        Dim objWait As New CWaitCursor
        Try

            For Each objDataRow In mobjDataTable.Rows
                objDataRow("Rights") = True
            Next
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
        Dim objBoolColumn As DataGridBoolColumn
        Dim objDataView As New DataView
        Dim objWait As New CWaitCursor
        Try
            dgUserAccess.TableStyles.Clear()
            objDataView.Table = mobjDataTable
            objDataView.AllowNew = False
            dgUserAccess.DataSource = objDataView
            dgUserAccess.ReadOnly = False
            dgUserAccess.AllowSorting = False


            mobjGridTableStyle = New DataGridTableStyle
            mobjGridTableStyle.RowHeadersVisible = False
            mobjGridTableStyle.ResetAlternatingBackColor()
            mobjGridTableStyle.ResetBackColor()
            mobjGridTableStyle.ResetForeColor()
            mobjGridTableStyle.ResetGridLineColor()
            mobjGridTableStyle.BackColor = Color.White
            mobjGridTableStyle.GridLineColor = Color.Gray
            mobjGridTableStyle.HeaderBackColor = Color.AliceBlue
            mobjGridTableStyle.HeaderForeColor = Color.Black
            mobjGridTableStyle.AlternatingBackColor = Color.White
            mobjGridTableStyle.AllowSorting = False
            mobjGridTableStyle.ReadOnly = False

            mobjGridTableStyle.MappingName = "UserAccess"

            objTextColumn = New DataGridTextBoxColumn
            objTextColumn.MappingName = "AccessID"
            objTextColumn.HeaderText = "Access ID"
            objTextColumn.Width = 0
            objTextColumn.ReadOnly = True
            mobjGridTableStyle.GridColumnStyles.Add(objTextColumn)

            objTextColumn = New DataGridTextBoxColumn
            objTextColumn.MappingName = "AccessName"
            objTextColumn.HeaderText = "Access Name"
            'objTextColumn.Width = 150
            objTextColumn.Width = 260 '((dgUserAccess.Width / 2) + (dgUserAccess.Width / 4)) - 6
            objTextColumn.ReadOnly = True
            mobjGridTableStyle.GridColumnStyles.Add(objTextColumn)

            objBoolColumn = New DataGridBoolColumn
            objBoolColumn.MappingName = "Rights"
            objBoolColumn.HeaderText = "Permissions"
            objBoolColumn.Width = (dgUserAccess.Width / 4) - 8
            objBoolColumn.ReadOnly = False
            objBoolColumn.AllowNull = False
            mobjGridTableStyle.GridColumnStyles.Add(objBoolColumn)

            'mobjGridTableStyle.GridLineColor = Color.LightBlue
            dgUserAccess.TableStyles.Add(mobjGridTableStyle)

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

    Private Function funcSaveUserPermisssions() As Boolean
        '=====================================================================
        ' Procedure Name        :   funcSaveUserPermisssions
        ' Description           :   To Save the User Permissions into the Database.
        ' Purpose               :   To Save the User Permissions into the Database.
        ' Parameters Passed     :   None.
        ' Returns               :   None.
        ' Parameters Affected   :   None.
        ' Assumptions           :
        ' Dependencies          :
        ' Author                :   Gitesh
        ' Created               :   January, 2003 
        ' Revisions             :
        '=====================================================================
        Dim user_id, access_id As Long
        Dim objDataRow As DataRow
        Dim user_rights, str_sql As String
        Dim rec_cnt As Integer
        Dim objReader As OleDbDataReader
        Dim record_exists As Boolean
        Dim objWait As New CWaitCursor
        Try

            user_id = Convert.ToInt64(cmbUserName.SelectedValue)
            rec_cnt = 0
            For Each objDataRow In mobjDataTable.Rows
                access_id = objDataRow("AccessID")
                If (objDataRow("Rights") = True) Then
                    If rec_cnt = 0 Then
                        user_rights = access_id.ToString()
                    Else
                        user_rights = user_rights & "," & access_id.ToString()
                    End If
                    rec_cnt = rec_cnt + 1
                End If
            Next

            'MessageBox.Show(user_rights)

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


        Try

            If Not (gclsDBFunctions.OpenConnection(gOleDBUserInfoConnection)) Then
                Return False
            End If

            str_sql = "Select * from UserAccess where UserID = " & user_id & ""

            record_exists = gclsDBFunctions.RecordExists(str_sql, gOleDBUserInfoConnection)
            If user_rights = Nothing Then
                user_rights = "0"
            End If
            If record_exists Then
                Call funcUpdateData(user_id, user_rights)
            Else
                Call funcInsertData(user_id, user_rights)
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

    Private Function funcInsertData(ByVal user_id As Long, ByVal user_rights As String) As Boolean
        '=====================================================================
        ' Procedure Name        :   funcInsertData
        ' Description           :   To Add/Insert New User Access Record.
        ' Purpose               :   To Add/Insert New User Access Record.
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
        Dim Status As Boolean
        Dim str_sql As String
        Dim objCommand As New OleDbCommand
        Dim useraccess_id As Long

        Try
            'Status = gclsDBFunctions.OpenConnection(gOleDBUserInfoConnection)
            'If Not (Status) Then
            '    Return False
            'End If

            '--- Generating ID for UserAccess
            useraccess_id = gclsDBFunctions.GetNextID("UserAccess", "UserAccessID", gOleDBUserInfoConnection)

            str_sql = "Insert into UserAccess " & _
                      " values(?,?,?)"

            '--- Providing command object for Infomaster
            With objCommand
                .Connection = gOleDBUserInfoConnection
                .CommandType = CommandType.Text
                .CommandText = str_sql
                .Parameters.Add("UserAccessID", OleDbType.BigInt).Value = useraccess_id
                .Parameters.Add("UserID", OleDbType.BigInt).Value = user_id
                .Parameters.Add("UserAccess", OleDbType.VarChar, 50).Value = user_rights
                .ExecuteNonQuery()
            End With

            objCommand.Dispose()
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

    Private Function funcUpdateData(ByVal user_id As Long, ByVal user_rights As String)
        '=====================================================================
        ' Procedure Name        :   funcUpdateData
        ' Description           :   To Update User Access Record.
        ' Purpose               :   To Update User Access Record.
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
        Dim Status As Boolean
        Dim strsqlMaster As String
        Dim objCommand As New OleDbCommand

        Try
            Status = gclsDBFunctions.OpenConnection(gOleDBUserInfoConnection)
            If Not (Status) Then
                Return False
            End If

            strsqlMaster = "Update UserAccess set " & _
                           "UserAccess = ? " & _
                           "where UserID = " & user_id & ""

            '--- Providing command object for Infomaster
            With objCommand
                .Connection = gOleDBUserInfoConnection
                .CommandType = CommandType.Text
                .CommandText = strsqlMaster
                .Parameters.Add("UserAccess", OleDbType.VarChar, 50).Value = user_rights
                .ExecuteNonQuery()
            End With

            objCommand.Dispose()
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

#End Region

#Region "User / Access Validation Functions"

    '--------------------------------------------------------
    '    General functions used for Adding User.
    '--- funcValidateUser - To Validate the User against the Password entered by him.
    '--- funcValidateUserAccess - To Validate the Access Rights to the User.

    Private Function funcValidateUser(ByVal user_id As Long, ByVal password As String) As Boolean
        '=====================================================================
        ' Procedure Name        :   funcValidateUser 
        ' Description           :   To Validate the User against the Password entered by him.
        ' Purpose               :   To Validate the User against the Password entered by him.
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
        Dim result As Boolean = False
        Dim str_sql As String
        Dim objReader As OleDb.OleDbDataReader
        Dim password_id As Long

        Try

            '--- Generating dynamic query for selection type

            str_sql = "Select PasswordID " & _
                      "from Passwords ,Users where Passwords.UserID = " & user_id & " and Passwords.Password = '" & password & "' " & _
                      "and Passwords.UserID = Users.UserID and Users.Active = 1 "

            'result = gclsDBFunctions.OpenConnection(gOleDBUserInfoConnection)
            'If Not (result) Then
            '    result = False
            '    Return result
            'End If

            '--- Calling gfuncGetRecords to Get myreader populated with provided Query( strsqlServiceComments (Global String) Records
            If Not gclsDBFunctions.GetRecords(str_sql, gOleDBUserInfoConnection, objReader) Then
                result = False
                Return result
            End If

            While objReader.Read
                password_id = Convert.ToInt64(objReader.Item("PasswordID"))
                result = True
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

    Private Function funcValidateUserAccess(ByVal user_id As Long, ByVal access_id As Long) As Boolean
        '=====================================================================
        ' Procedure Name        :   funcValidateUserAccess 
        ' Description           :   To Validate the Access Rights to the User.
        ' Purpose               :   To Validate the Access Rights to the User.
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
        Dim result As Boolean = False
        Dim str_sql As String
        Dim objReader As OleDb.OleDbDataReader
        Dim str_access As String
        Dim arr_access As String()
        Dim rec_cnt, temp_cnt As Integer

        Try

            '--- Zero Code stands for Admin which has all rights.
            If (user_id = 0) Then
                result = True
                Return result
            End If

            '--- Generating dynamic query for selection type
            str_sql = "Select UserAccess " & _
                      "from UserAccess , Users where UserAccess.UserID = " & user_id & "  and UserAccess.UserID = Users.UserID and Users.Active = 1 "

            'result = gclsDBFunctions.OpenConnection(gOleDBUserInfoConnection)
            'If Not (result) Then
            '    result = False
            '    Return result
            'End If

            '--- Calling gfuncGetRecords to Get myreader populated with provided Query( strsqlServiceComments (Global String) Records
            If Not gclsDBFunctions.GetRecords(str_sql, gOleDBUserInfoConnection, objReader) Then
                result = False
                Return result
            End If

            While objReader.Read
                str_access = objReader.Item("UserAccess")
            End While
            objReader.Close()

            If (str_access = "" Or str_access = Nothing) Then
                Return False
            End If

            arr_access = str_access.Split(",")

            rec_cnt = arr_access.Length
            result = False
            For temp_cnt = 0 To (rec_cnt - 1)
                Dim id As Long = Convert.ToInt64(arr_access.GetValue(temp_cnt))
                If (id = access_id) Then
                    result = True
                    Return result
                End If
            Next

            Return result

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

#End Region

    'Private Sub dgUserAccess_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgUserAccess.Click
    '    Dim objDataRow As DataRow
    '    Dim a As Integer = 0

    '    For Each objDataRow In dgUserAccess.DataSource.table.rows  'mobjDataTable.Rows
    '        'dgUserAccess.HitTestInfo.   
    '        If dgUserAccess.Item(a, 2) = False Then
    '            'If objDataRow("Rights") = False Then
    '            chkAllAccesRights.Checked = False
    '            Exit For
    '        End If
    '        a += 1
    '    Next
    'End Sub


End Class
