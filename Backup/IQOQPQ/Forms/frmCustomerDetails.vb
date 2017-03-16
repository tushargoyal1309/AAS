Option Explicit On 

Imports System.Data
Imports System.Data.OleDb


'#############################################################
'1. Database and table should be ready
'2. Function to display stored data
'3. Function to insert tha data to database.
'4. Function to update the data.
'5. lock functionality
'#############################################################
'#############################################################
'You can refer/use object like color analysis
'
'#############################################################



Public Class frmCustomerDetails
    Inherits System.Windows.Forms.Form

#Region " Module level Declarations "
    Private Const CONST_RecordID = 1

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
    Friend WithEvents lblHeader As System.Windows.Forms.Label
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents lblAddress As System.Windows.Forms.Label
    Friend WithEvents lblAttention As System.Windows.Forms.Label
    Friend WithEvents lblPhone As System.Windows.Forms.Label
    Friend WithEvents lblFax As System.Windows.Forms.Label
    Friend WithEvents lblDoneBy As System.Windows.Forms.Label
    Friend WithEvents lblCompletionDate As System.Windows.Forms.Label
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents txtAttention As System.Windows.Forms.TextBox
    Friend WithEvents txtAddress As System.Windows.Forms.TextBox
    Friend WithEvents txtPhone As System.Windows.Forms.TextBox
    Friend WithEvents txtFax As System.Windows.Forms.TextBox
    Friend WithEvents txtDoneBy As System.Windows.Forms.TextBox
    Friend WithEvents dtpCompletionDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmCustomerDetails))
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.lblHeader = New System.Windows.Forms.Label
        Me.dtpCompletionDate = New System.Windows.Forms.DateTimePicker
        Me.txtDoneBy = New System.Windows.Forms.TextBox
        Me.txtFax = New System.Windows.Forms.TextBox
        Me.txtPhone = New System.Windows.Forms.TextBox
        Me.txtAddress = New System.Windows.Forms.TextBox
        Me.txtAttention = New System.Windows.Forms.TextBox
        Me.txtName = New System.Windows.Forms.TextBox
        Me.lblCompletionDate = New System.Windows.Forms.Label
        Me.lblDoneBy = New System.Windows.Forms.Label
        Me.lblFax = New System.Windows.Forms.Label
        Me.lblPhone = New System.Windows.Forms.Label
        Me.lblAttention = New System.Windows.Forms.Label
        Me.lblAddress = New System.Windows.Forms.Label
        Me.lblName = New System.Windows.Forms.Label
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.dtpCompletionDate)
        Me.Panel1.Controls.Add(Me.txtDoneBy)
        Me.Panel1.Controls.Add(Me.txtFax)
        Me.Panel1.Controls.Add(Me.txtPhone)
        Me.Panel1.Controls.Add(Me.txtAddress)
        Me.Panel1.Controls.Add(Me.txtAttention)
        Me.Panel1.Controls.Add(Me.txtName)
        Me.Panel1.Controls.Add(Me.lblCompletionDate)
        Me.Panel1.Controls.Add(Me.lblDoneBy)
        Me.Panel1.Controls.Add(Me.lblFax)
        Me.Panel1.Controls.Add(Me.lblPhone)
        Me.Panel1.Controls.Add(Me.lblAttention)
        Me.Panel1.Controls.Add(Me.lblAddress)
        Me.Panel1.Controls.Add(Me.lblName)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(392, 456)
        Me.Panel1.TabIndex = 12
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel2.Controls.Add(Me.PictureBox1)
        Me.Panel2.Controls.Add(Me.lblHeader)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(390, 32)
        Me.Panel2.TabIndex = 0
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox1.TabIndex = 11
        Me.PictureBox1.TabStop = False
        '
        'lblHeader
        '
        Me.lblHeader.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeader.Location = New System.Drawing.Point(35, 7)
        Me.lblHeader.Name = "lblHeader"
        Me.lblHeader.Size = New System.Drawing.Size(376, 18)
        Me.lblHeader.TabIndex = 0
        Me.lblHeader.Text = "Customer Details"
        Me.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpCompletionDate
        '
        Me.dtpCompletionDate.CalendarFont = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpCompletionDate.CustomFormat = "dd-MMM-yyyy"
        Me.dtpCompletionDate.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpCompletionDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpCompletionDate.Location = New System.Drawing.Point(128, 360)
        Me.dtpCompletionDate.Name = "dtpCompletionDate"
        Me.dtpCompletionDate.Size = New System.Drawing.Size(120, 21)
        Me.dtpCompletionDate.TabIndex = 7
        Me.dtpCompletionDate.Value = New Date(2004, 5, 18, 0, 0, 0, 0)
        '
        'txtDoneBy
        '
        Me.txtDoneBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDoneBy.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDoneBy.Location = New System.Drawing.Point(128, 328)
        Me.txtDoneBy.MaxLength = 50
        Me.txtDoneBy.Name = "txtDoneBy"
        Me.txtDoneBy.Size = New System.Drawing.Size(456, 21)
        Me.txtDoneBy.TabIndex = 6
        Me.txtDoneBy.Text = ""
        '
        'txtFax
        '
        Me.txtFax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFax.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFax.Location = New System.Drawing.Point(128, 296)
        Me.txtFax.MaxLength = 20
        Me.txtFax.Name = "txtFax"
        Me.txtFax.Size = New System.Drawing.Size(456, 21)
        Me.txtFax.TabIndex = 5
        Me.txtFax.Text = ""
        '
        'txtPhone
        '
        Me.txtPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPhone.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPhone.Location = New System.Drawing.Point(128, 264)
        Me.txtPhone.MaxLength = 45
        Me.txtPhone.Name = "txtPhone"
        Me.txtPhone.Size = New System.Drawing.Size(456, 21)
        Me.txtPhone.TabIndex = 4
        Me.txtPhone.Text = ""
        '
        'txtAddress
        '
        Me.txtAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAddress.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAddress.Location = New System.Drawing.Point(128, 112)
        Me.txtAddress.MaxLength = 100
        Me.txtAddress.Multiline = True
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.Size = New System.Drawing.Size(456, 104)
        Me.txtAddress.TabIndex = 2
        Me.txtAddress.Text = ""
        '
        'txtAttention
        '
        Me.txtAttention.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAttention.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAttention.Location = New System.Drawing.Point(128, 232)
        Me.txtAttention.MaxLength = 50
        Me.txtAttention.Name = "txtAttention"
        Me.txtAttention.Size = New System.Drawing.Size(456, 21)
        Me.txtAttention.TabIndex = 3
        Me.txtAttention.Text = ""
        '
        'txtName
        '
        Me.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtName.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtName.Location = New System.Drawing.Point(128, 80)
        Me.txtName.MaxLength = 50
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(456, 21)
        Me.txtName.TabIndex = 1
        Me.txtName.Text = ""
        '
        'lblCompletionDate
        '
        Me.lblCompletionDate.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCompletionDate.Location = New System.Drawing.Point(8, 360)
        Me.lblCompletionDate.Name = "lblCompletionDate"
        Me.lblCompletionDate.Size = New System.Drawing.Size(112, 23)
        Me.lblCompletionDate.TabIndex = 14
        Me.lblCompletionDate.Text = "Completion Date:"
        Me.lblCompletionDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDoneBy
        '
        Me.lblDoneBy.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDoneBy.Location = New System.Drawing.Point(8, 320)
        Me.lblDoneBy.Name = "lblDoneBy"
        Me.lblDoneBy.Size = New System.Drawing.Size(88, 40)
        Me.lblDoneBy.TabIndex = 13
        Me.lblDoneBy.Text = "Installation Done By :"
        Me.lblDoneBy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblFax
        '
        Me.lblFax.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFax.Location = New System.Drawing.Point(8, 296)
        Me.lblFax.Name = "lblFax"
        Me.lblFax.Size = New System.Drawing.Size(112, 23)
        Me.lblFax.TabIndex = 12
        Me.lblFax.Text = "Fax:"
        Me.lblFax.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPhone
        '
        Me.lblPhone.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPhone.Location = New System.Drawing.Point(8, 264)
        Me.lblPhone.Name = "lblPhone"
        Me.lblPhone.Size = New System.Drawing.Size(112, 23)
        Me.lblPhone.TabIndex = 11
        Me.lblPhone.Text = "Phone:"
        Me.lblPhone.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAttention
        '
        Me.lblAttention.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAttention.Location = New System.Drawing.Point(8, 224)
        Me.lblAttention.Name = "lblAttention"
        Me.lblAttention.Size = New System.Drawing.Size(112, 40)
        Me.lblAttention.TabIndex = 10
        Me.lblAttention.Text = "Customer Representative:"
        Me.lblAttention.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAddress
        '
        Me.lblAddress.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAddress.Location = New System.Drawing.Point(8, 112)
        Me.lblAddress.Name = "lblAddress"
        Me.lblAddress.Size = New System.Drawing.Size(112, 23)
        Me.lblAddress.TabIndex = 9
        Me.lblAddress.Text = "Address:"
        Me.lblAddress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblName
        '
        Me.lblName.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblName.Location = New System.Drawing.Point(8, 80)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(112, 23)
        Me.lblName.TabIndex = 8
        Me.lblName.Text = "Customer Name:"
        Me.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmCustomerDetails
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(392, 440)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCustomerDetails"
        Me.Text = "Customer Details"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Form Events "

    Private Sub frmCustomerDetails_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            funcInitialize()
        Catch ex As Exception
        Finally
            '---------------------------------------------------------
            '--- Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub frmCustomerDetails_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Try
            If Not funcSaveCustomerData() Then
                Throw New Exception("Error in Saving Customer Details.")
            End If
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.ProcessError(ErrorHandler.ErrorHandler.EnumErrorType.Critical, ex)
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            '--- Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try

            Me.Close()
        Catch ex As Exception
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
        Finally
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
        End Try
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If Not funcSaveCustomerData() Then
                Throw New Exception("Error in Saving Customer Details.")
            End If
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.ProcessError(ErrorHandler.ErrorHandler.EnumErrorType.Critical, ex)
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            '--- Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------
        End Try
        Me.Close()
    End Sub
#End Region

#Region " General Private functions "

    '--------------------------------------------------------
    '    General functions used for IQ Equipment Listing.
    '--- funcInitialize - To Initialize form and to get values for Customer Details from database and display them.
    '--- funcGetCustomerData - To Get Customer Detail Records from Database into DataTable.
    '--- funcGetCustomerDetails - To Get Customer Detail Records from Database into DataTable.
    '--- funcSaveCustomerData - To Save the Entered Records into Database.
    '--- funcInsertCustomerData - To Add/Insert New Customer Data in Database.
    '--- funcUpdateCustomerData - To Update Customer Data in Database.

    Private Sub funcInitialize()
        '=====================================================================
        ' Procedure Name        :   funcInitailize
        ' Description           :   To Initialize form and to get values for Customer Details from database and display them.
        ' Purpose               :   To Initialize form and to get values for Customer Details from database and display them.
        ' Parameters Passed     :   None.
        ' Returns               :   None.
        ' Parameters Affected   :   None.
        ' Assumptions           :
        ' Dependencies          :
        ' Author                :   Gitesh
        ' Created               :   February, 2003 
        ' Revisions             :
        '=====================================================================
        'mfrmCustDetails = Me
        Dim dtCustomerDetails As New DataTable

        Try
            dtCustomerDetails = gobjDataAccess.GetCustomerDetails()
            If dtCustomerDetails.Rows.Count > 0 Then
                txtName.Text = CStr(dtCustomerDetails.Rows.Item(0).Item("Name"))
                txtAddress.Text = CStr(dtCustomerDetails.Rows.Item(0).Item("Address") & "")
                txtAttention.Text = CStr(dtCustomerDetails.Rows.Item(0).Item("Attention") & "")
                txtPhone.Text = CStr(dtCustomerDetails.Rows.Item(0).Item("Phone") & "")
                txtFax.Text = CStr(dtCustomerDetails.Rows.Item(0).Item("Fax") & "")
                txtDoneBy.Text = CStr(dtCustomerDetails.Rows.Item(0).Item("DoneBy") & "")
                If IsDBNull(dtCustomerDetails.Rows.Item(0).Item("CompleteDate")) = False Then
                    dtpCompletionDate.Value = CDate(dtCustomerDetails.Rows.Item(0).Item("CompleteDate"))
                Else
                    dtpCompletionDate.Value = DateTime.Today
                End If
            Else
                'Throw New Exception("Error in Saving Customer Details.")
            End If
            If gobjDataAccess.funcCheckModeLocked(ENUM_IQOQPQ_STATUS.IQ) Then

                txtName.ReadOnly = True
                txtAddress.ReadOnly = True
                txtAttention.ReadOnly = True
                txtPhone.ReadOnly = True
                txtFax.ReadOnly = True
                txtDoneBy.ReadOnly = True
                dtpCompletionDate.Enabled = False 'Added by pankaj on 6.12.07
            Else
                txtName.ReadOnly = False
                txtAddress.ReadOnly = False
                txtAttention.ReadOnly = False
                txtPhone.ReadOnly = False
                txtFax.ReadOnly = False
                txtDoneBy.ReadOnly = False
                dtpCompletionDate.Enabled = True 'Added by pankaj on 6.12.07
            End If
            'If Not (funcGetCustomerData()) Then
            '    Throw New Exception("Error in Getting Customer Details Records.")
            'End If
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.ProcessError(ErrorHandler.ErrorHandler.EnumErrorType.Critical, ex)
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            '--- Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------
        End Try
    End Sub

    'Private Function funcGetCustomerData() As Boolean
    '    '=====================================================================
    '    ' Procedure Name        :   funcGetCustomerData
    '    ' Description           :   To Get Customer Records from Database into DataTable.
    '    ' Purpose               :   To Get Customer Records from Database into DataTable.
    '    ' Parameters Passed     :   None.
    '    ' Returns               :   None.
    '    ' Parameters Affected   :   None.
    '    ' Assumptions           :
    '    ' Dependencies          :
    '    ' Author                :   
    '    ' Created               :   January, 2003 
    '    ' Revisions             :
    '    '=====================================================================

    '    Dim dtCustomerDetails As New DataTable

    '    Try
    '        dtCustomerDetails = gobjDataAccess.GetCustomerDetails()
    '        If dtCustomerDetails.Rows.Count > 0 Then
    '            txtName.Text = CStr(dtCustomerDetails.Rows.Item(0).Item("Name"))
    '            txtAddress.Text = CStr(dtCustomerDetails.Rows.Item(0).Item("Address") & "")
    '            txtAttention.Text = CStr(dtCustomerDetails.Rows.Item(0).Item("Attention") & "")
    '            txtPhone.Text = CStr(dtCustomerDetails.Rows.Item(0).Item("Phone") & "")
    '            txtFax.Text = CStr(dtCustomerDetails.Rows.Item(0).Item("Fax") & "")
    '            txtDoneBy.Text = CStr(dtCustomerDetails.Rows.Item(0).Item("DoneBy") & "")
    '            If IsDBNull(dtCustomerDetails.Rows.Item(0).Item("CompleteDate")) = False Then
    '                dtpCompletionDate.Value = CDate(dtCustomerDetails.Rows.Item(0).Item("CompleteDate"))
    '            Else
    '                dtpCompletionDate.Value = DateTime.Today
    '            End If
    '        Else
    '            Throw New Exception("Error in Saving Customer Details.")
    '        End If


    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        'Error logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = "Error in Getting Customer Details Data."
    '        gobjErrorHandler.WriteErrorLog(ex)
    '        Return (False)
    '        '---------------------------------------------------------
    '    Finally
    '        '---------------------------------------------------------
    '        '--- Writing Execution log
    '        If CONST_CREATE_EXECUTION_LOG = 1 Then
    '            gobjErrorHandler.WriteExecutionLog()
    '        End If
    '        '---------------------------------------------------------
    '    End Try
    '    Return True
    'End Function

    'Private Function funcGetCustomerDetails() As Boolean
    '    '=====================================================================
    '    ' Procedure Name        :   funcGetCustomerDetails
    '    ' Description           :   To Get Customer Records from Database into DataTable.
    '    ' Purpose               :   To Get Customer Records from Database into DataTable.
    '    ' Parameters Passed     :   None.
    '    ' Returns               :   None.
    '    ' Parameters Affected   :   None.
    '    ' Assumptions           :
    '    ' Dependencies          :
    '    ' Author                :   
    '    ' Created               :   February, 2003 
    '    ' Revisions             :
    '    '=====================================================================

    '    Dim objReader As OleDbDataReader
    '    Dim sql_string As String
    '    Dim reader_status As Boolean

    '    Try
    '        'sql_string = "Select CustomerID ,Name ,Address ,Attention ,Phone ,Fax ,DoneBy ,CompleteDate from CustomerDetails where CustomerID = " & CONST_RecordID & " "

    '        'reader_status = gclsDBFunctions.GetRecords(sql_string, gOleDBIQOQPQConnection, objReader)

    '        If Not (reader_status) Then
    '            Throw New Exception("Error in Opening Connection during Getting Customer Details.")
    '        End If

    '        While objReader.Read
    '            txtName.Text = CStr(objReader.Item("Name") & "")
    '            txtAddress.Text = CStr(objReader.Item("Address") & "")
    '            txtAttention.Text = CStr(objReader.Item("Attention") & "")
    '            txtPhone.Text = CStr(objReader.Item("Phone") & "")
    '            txtFax.Text = CStr(objReader.Item("Fax") & "")
    '            txtDoneBy.Text = CStr(objReader.Item("DoneBy") & "")
    '            If IsDBNull(objReader.Item("CompleteDate")) = False Then
    '                dtpCompletionDate.Value = CDate(objReader.Item("CompleteDate"))
    '            Else
    '                dtpCompletionDate.Value = DateTime.Today
    '            End If
    '        End While

    '        objReader.Close()

    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        'Error logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = "Error in Getting Equipment List Records."
    '        gobjErrorHandler.WriteErrorLog(ex)
    '        Return (False)
    '        '---------------------------------------------------------
    '    Finally
    '        '---------------------------------------------------------
    '        '--- Writing Execution log
    '        If CONST_CREATE_EXECUTION_LOG = 1 Then
    '            gobjErrorHandler.WriteExecutionLog()
    '        End If
    '        '---------------------------------------------------------
    '    End Try
    '    Return True
    'End Function

    Public Function funcSaveCustomerData() As Boolean
        '=====================================================================
        ' Procedure Name        :   funcSaveCustomerData
        ' Description           :   To Save the Entered Records into Database.
        ' Purpose               :   To Save the Entered Records into Database.
        ' Parameters Passed     :   None.
        ' Returns               :   None.
        ' Parameters Affected   :   None.
        ' Assumptions           :
        ' Dependencies          :
        ' Author                :   Gitesh
        ' Created               :   January, 2003 
        ' Revisions             :
        '=====================================================================

        Dim intID As Integer
        Dim strName, strAddress, strAttention, strPhone, strFax, strDoneBy As String
        Dim dtCompleteDate As DateTime
        Dim status As Boolean = False
        Dim objdtCustomer As New DataTable
        Dim objRow As DataRow
        Try
            objdtCustomer.Columns.Add("Name")
            objdtCustomer.Columns.Add("Address")
            objdtCustomer.Columns.Add("Attention")
            objdtCustomer.Columns.Add("Phone")
            objdtCustomer.Columns.Add("Fax")
            objdtCustomer.Columns.Add("DoneBy")
            objdtCustomer.Columns.Add("CompleteDate")

            objRow = objdtCustomer.NewRow
            'intID = CONST_RecordID
            If txtName.Text = "" Then
                txtName.Text = " "
            End If
            If txtAddress.Text = "" Then
                txtAddress.Text = " "
            End If
            If txtAttention.Text = "" Then
                txtAttention.Text = " "
            End If
            If txtPhone.Text = "" Then
                txtPhone.Text = " "
            End If
            If txtFax.Text = "" Then
                txtFax.Text = " "
            End If
            If txtDoneBy.Text = "" Then
                txtDoneBy.Text = " "
            End If

            objRow.Item("Name") = txtName.Text
            objRow.Item("Address") = txtAddress.Text
            objRow.Item("Attention") = txtAttention.Text
            objRow.Item("Phone") = txtPhone.Text
            objRow.Item("Fax") = txtFax.Text
            objRow.Item("DoneBy") = txtDoneBy.Text
            objRow.Item("CompleteDate") = dtpCompletionDate.Value
            objdtCustomer.Rows.Add(objRow)
            status = gobjDataAccess.funcUpdateCustomerData(objdtCustomer)
            If Not (status) Then
                Throw New Exception("Error in Updating Customer Details.")
            End If

        Catch ex As Exception
            '---------------------------------------------------------
            'Error logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = "Error in Updating Customer Details."
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            '--- Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------
        End Try
        Return status

    End Function

    'Private Function funcInsertCustomerData(ByVal intID As Integer) As Boolean
    '    '=====================================================================
    '    ' Procedure Name        :   funcInsertCustomerData
    '    ' Description           :   To Add/Insert New Customer Record in Database.
    '    ' Purpose               :   To Add/Insert New Customer Record in Database.
    '    ' Parameters Passed     :   None.
    '    ' Returns               :   None.
    '    ' Parameters Affected   :   None.
    '    ' Assumptions           :
    '    ' Dependencies          :
    '    ' Author                :   Gitesh
    '    ' Created               :   February, 2003 
    '    ' Revisions             :
    '    '=====================================================================

    '    Dim Status As Boolean
    '    Dim str_sql As String
    '    Dim objCommand As New OleDbCommand

    '    Try
    '        'Status = gobjGeneralDatabaseFunctions.OpenConnection(gOledbConnectionObj)
    '        'If Not (Status) Then
    '        '    Throw New Exception("Error in Opening Connection during Saving Customer Details.")
    '        'End If

    '        '---  Query for adding  data to EquipmentList
    '        str_sql = " Insert into CustomerDetails " & _
    '                  " (CustomerID ,Name ) " & _
    '                  " values(?,?) "

    '        '--- Providing command object for EquimentList
    '        With objCommand
    '            .Connection = gOleDBIQOQPQConnection
    '            .CommandType = CommandType.Text
    '            .CommandText = str_sql
    '            .Parameters.Add("CustomerID", OleDbType.Numeric).Value = intID
    '            .Parameters.Add("Name", OleDbType.VarChar, 250).Value = ""
    '            .ExecuteNonQuery()
    '        End With

    '        objCommand.Dispose()
    '        Status = True

    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        '--- Error logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = "Error in Saving Customer Details."
    '        gobjErrorHandler.WriteErrorLog(ex)
    '        Return (False)
    '        '---------------------------------------------------------
    '    Finally
    '        '---------------------------------------------------------
    '        '--- Writing Execution log
    '        If CONST_CREATE_EXECUTION_LOG = 1 Then
    '            gobjErrorHandler.WriteExecutionLog()
    '        End If
    '        '---------------------------------------------------------
    '    End Try

    '    Return Status

    'End Function

    'Private Function funcUpdateCustomerData(ByVal intID As Integer, ByVal strName As String, ByVal strAddress As String, ByVal strAttention As String, ByVal strPhone As String, ByVal strFax As String, ByVal strDoneBy As String, ByVal dtCompleteDate As DateTime) As Boolean
    '    '=====================================================================
    '    ' Procedure Name        :   funcUpdateCustomerData
    '    ' Description           :   To Update Customer Data in Database.
    '    ' Purpose               :   To Update Customer Data in Database.
    '    ' Parameters Passed     :   None.
    '    ' Returns               :   None.
    '    ' Parameters Affected   :   None.
    '    ' Assumptions           :
    '    ' Dependencies          :
    '    ' Author                :   Gitesh
    '    ' Created               :   February, 2003 
    '    ' Revisions             :
    '    '=====================================================================

    '    Dim Status As Boolean
    '    Dim str_sql As String
    '    Dim objCommand As New OleDbCommand

    '    Try
    '        'Status = gobjGeneralDatabaseFunctions.OpenConnection(gOledbConnectionObj)
    '        'If Not (Status) Then
    '        '    Throw New Exception("Error in Opening Connection during Updating Customer Details.")
    '        'End If

    '        '---  Query for adding  data to EquipmentList
    '        str_sql = " Update CustomerDetails " & _
    '                  " Set Name = ? ,Address= ? ,Attention = ? ,Phone = ? ,Fax = ? ,DoneBy = ? ,CompleteDate = ? " & _
    '                  " where CustomerID = " & intID & " "

    '        '--- Providing command object for EquimentList
    '        With objCommand
    '            .Connection = gOleDBIQOQPQConnection
    '            .CommandType = CommandType.Text
    '            .CommandText = str_sql
    '            .Parameters.Add("Name", OleDbType.VarChar, 250).Value = strName
    '            .Parameters.Add("Address", OleDbType.VarChar, 250).Value = strAddress
    '            .Parameters.Add("Attention", OleDbType.VarChar, 250).Value = strAttention
    '            .Parameters.Add("Phone", OleDbType.VarChar, 250).Value = strPhone
    '            .Parameters.Add("Fax", OleDbType.VarChar, 250).Value = strFax
    '            .Parameters.Add("DoneBy", OleDbType.VarChar, 250).Value = strDoneBy
    '            .Parameters.Add("CompleteDate", OleDbType.DBDate).Value = dtCompleteDate
    '            .ExecuteNonQuery()
    '        End With

    '        objCommand.Dispose()
    '        Status = True

    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        '--- Error logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = "Error in Updating Customer Details."
    '        gobjErrorHandler.WriteErrorLog(ex)
    '        Return (False)
    '        '---------------------------------------------------------
    '    Finally
    '        '---------------------------------------------------------
    '        '--- Writing Execution log
    '        If CONST_CREATE_EXECUTION_LOG = 1 Then
    '            gobjErrorHandler.WriteExecutionLog()
    '        End If
    '        '---------------------------------------------------------
    '    End Try

    '    Return Status

    'End Function

#End Region

End Class

