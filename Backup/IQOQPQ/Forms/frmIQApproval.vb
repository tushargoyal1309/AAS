Option Explicit On 

Imports System.Data
Imports System.Data.OleDb

Public Class frmIQApproval
    Inherits System.Windows.Forms.Form

#Region " Module level Declarations "
    Private mblnModeLockStatus As Boolean
    Private mintMode As Integer
    Private mobjDataView As New DataView
    Private mObjDataTable As DataTable
    Dim mobjGridTableStyle As New DataGridTableStyle
    Dim mdtpCustDate As DateTimePicker
    Private Const CONST_DateColumnNo = 4
#End Region

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    Public Sub New(ByVal intMode As Integer)
        MyBase.New()
        InitializeComponent()
        mintMode = intMode
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
    Friend WithEvents rchtxtIQApproval1 As System.Windows.Forms.RichTextBox
    Friend WithEvents rchtxtIQApproval2 As System.Windows.Forms.RichTextBox
    Friend WithEvents lblHeader3 As System.Windows.Forms.Label
    Friend WithEvents lblSupplierHeading As System.Windows.Forms.Label
    Friend WithEvents lblCustomerHeading As System.Windows.Forms.Label
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents lblDesignation As System.Windows.Forms.Label
    Friend WithEvents lblCompanyName As System.Windows.Forms.Label
    Friend WithEvents lblDate As System.Windows.Forms.Label
    Friend WithEvents txtDesignation As System.Windows.Forms.TextBox
    Friend WithEvents txtCompanyName As System.Windows.Forms.TextBox
    Friend WithEvents dtpDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtSupplierID As System.Windows.Forms.TextBox
    Friend WithEvents txtJointFunctionalArea As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents dgCustomer As System.Windows.Forms.DataGrid
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lblHeader2 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmIQApproval))
        Me.txtJointFunctionalArea = New System.Windows.Forms.TextBox
        Me.txtSupplierID = New System.Windows.Forms.TextBox
        Me.dtpDate = New System.Windows.Forms.DateTimePicker
        Me.txtCompanyName = New System.Windows.Forms.TextBox
        Me.txtDesignation = New System.Windows.Forms.TextBox
        Me.lblDate = New System.Windows.Forms.Label
        Me.lblCompanyName = New System.Windows.Forms.Label
        Me.lblDesignation = New System.Windows.Forms.Label
        Me.txtName = New System.Windows.Forms.TextBox
        Me.lblName = New System.Windows.Forms.Label
        Me.lblCustomerHeading = New System.Windows.Forms.Label
        Me.lblSupplierHeading = New System.Windows.Forms.Label
        Me.lblHeader3 = New System.Windows.Forms.Label
        Me.rchtxtIQApproval2 = New System.Windows.Forms.RichTextBox
        Me.rchtxtIQApproval1 = New System.Windows.Forms.RichTextBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.lblHeader2 = New System.Windows.Forms.Label
        Me.dgCustomer = New System.Windows.Forms.DataGrid
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.dgCustomer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtJointFunctionalArea
        '
        Me.txtJointFunctionalArea.BackColor = System.Drawing.Color.White
        Me.txtJointFunctionalArea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtJointFunctionalArea.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtJointFunctionalArea.Location = New System.Drawing.Point(128, 64)
        Me.txtJointFunctionalArea.MaxLength = 40
        Me.txtJointFunctionalArea.Name = "txtJointFunctionalArea"
        Me.txtJointFunctionalArea.Size = New System.Drawing.Size(432, 21)
        Me.txtJointFunctionalArea.TabIndex = 19
        Me.txtJointFunctionalArea.Text = ""
        '
        'txtSupplierID
        '
        Me.txtSupplierID.BackColor = System.Drawing.Color.AliceBlue
        Me.txtSupplierID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSupplierID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSupplierID.Location = New System.Drawing.Point(16, 216)
        Me.txtSupplierID.Name = "txtSupplierID"
        Me.txtSupplierID.Size = New System.Drawing.Size(144, 22)
        Me.txtSupplierID.TabIndex = 18
        Me.txtSupplierID.Text = ""
        Me.txtSupplierID.Visible = False
        '
        'dtpDate
        '
        Me.dtpDate.CalendarMonthBackground = System.Drawing.Color.AliceBlue
        Me.dtpDate.CalendarTitleForeColor = System.Drawing.Color.AliceBlue
        Me.dtpDate.CustomFormat = "dd-MMM-yyyy"
        Me.dtpDate.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDate.Location = New System.Drawing.Point(452, 216)
        Me.dtpDate.Name = "dtpDate"
        Me.dtpDate.Size = New System.Drawing.Size(121, 21)
        Me.dtpDate.TabIndex = 17
        '
        'txtCompanyName
        '
        Me.txtCompanyName.BackColor = System.Drawing.Color.AliceBlue
        Me.txtCompanyName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCompanyName.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCompanyName.Location = New System.Drawing.Point(304, 216)
        Me.txtCompanyName.MaxLength = 40
        Me.txtCompanyName.Name = "txtCompanyName"
        Me.txtCompanyName.Size = New System.Drawing.Size(152, 22)
        Me.txtCompanyName.TabIndex = 16
        Me.txtCompanyName.Text = ""
        '
        'txtDesignation
        '
        Me.txtDesignation.BackColor = System.Drawing.Color.AliceBlue
        Me.txtDesignation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDesignation.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDesignation.Location = New System.Drawing.Point(152, 216)
        Me.txtDesignation.MaxLength = 40
        Me.txtDesignation.Name = "txtDesignation"
        Me.txtDesignation.Size = New System.Drawing.Size(152, 22)
        Me.txtDesignation.TabIndex = 15
        Me.txtDesignation.Text = ""
        '
        'lblDate
        '
        Me.lblDate.BackColor = System.Drawing.Color.FromArgb(CType(205, Byte), CType(225, Byte), CType(250, Byte))
        Me.lblDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDate.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDate.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblDate.Location = New System.Drawing.Point(453, 192)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(120, 23)
        Me.lblDate.TabIndex = 14
        Me.lblDate.Text = "Date"
        Me.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCompanyName
        '
        Me.lblCompanyName.BackColor = System.Drawing.Color.FromArgb(CType(205, Byte), CType(225, Byte), CType(250, Byte))
        Me.lblCompanyName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCompanyName.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCompanyName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCompanyName.Location = New System.Drawing.Point(304, 192)
        Me.lblCompanyName.Name = "lblCompanyName"
        Me.lblCompanyName.Size = New System.Drawing.Size(152, 23)
        Me.lblCompanyName.TabIndex = 13
        Me.lblCompanyName.Text = "Name of Company"
        Me.lblCompanyName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblDesignation
        '
        Me.lblDesignation.BackColor = System.Drawing.Color.FromArgb(CType(205, Byte), CType(225, Byte), CType(250, Byte))
        Me.lblDesignation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDesignation.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDesignation.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblDesignation.Location = New System.Drawing.Point(152, 192)
        Me.lblDesignation.Name = "lblDesignation"
        Me.lblDesignation.Size = New System.Drawing.Size(152, 23)
        Me.lblDesignation.TabIndex = 12
        Me.lblDesignation.Text = "Designation"
        Me.lblDesignation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtName
        '
        Me.txtName.BackColor = System.Drawing.Color.AliceBlue
        Me.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtName.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtName.Location = New System.Drawing.Point(8, 216)
        Me.txtName.MaxLength = 40
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(144, 22)
        Me.txtName.TabIndex = 11
        Me.txtName.Text = ""
        '
        'lblName
        '
        Me.lblName.BackColor = System.Drawing.Color.FromArgb(CType(205, Byte), CType(225, Byte), CType(250, Byte))
        Me.lblName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblName.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblName.Location = New System.Drawing.Point(8, 192)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(144, 23)
        Me.lblName.TabIndex = 10
        Me.lblName.Text = "Name"
        Me.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCustomerHeading
        '
        Me.lblCustomerHeading.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCustomerHeading.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCustomerHeading.Location = New System.Drawing.Point(8, 248)
        Me.lblCustomerHeading.Name = "lblCustomerHeading"
        Me.lblCustomerHeading.Size = New System.Drawing.Size(368, 15)
        Me.lblCustomerHeading.TabIndex = 9
        Me.lblCustomerHeading.Text = "Customer's Representative  - "
        '
        'lblSupplierHeading
        '
        Me.lblSupplierHeading.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSupplierHeading.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblSupplierHeading.Location = New System.Drawing.Point(8, 168)
        Me.lblSupplierHeading.Name = "lblSupplierHeading"
        Me.lblSupplierHeading.Size = New System.Drawing.Size(368, 18)
        Me.lblSupplierHeading.TabIndex = 8
        Me.lblSupplierHeading.Text = "Manufacturer's / Supplier's Representative - "
        '
        'lblHeader3
        '
        Me.lblHeader3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeader3.Location = New System.Drawing.Point(8, 64)
        Me.lblHeader3.Name = "lblHeader3"
        Me.lblHeader3.Size = New System.Drawing.Size(120, 16)
        Me.lblHeader3.TabIndex = 5
        Me.lblHeader3.Text = "Functional Area"
        Me.lblHeader3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'rchtxtIQApproval2
        '
        Me.rchtxtIQApproval2.AutoSize = True
        Me.rchtxtIQApproval2.BackColor = System.Drawing.Color.AliceBlue
        Me.rchtxtIQApproval2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.rchtxtIQApproval2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rchtxtIQApproval2.Location = New System.Drawing.Point(8, 88)
        Me.rchtxtIQApproval2.Name = "rchtxtIQApproval2"
        Me.rchtxtIQApproval2.ReadOnly = True
        Me.rchtxtIQApproval2.Size = New System.Drawing.Size(547, 72)
        Me.rchtxtIQApproval2.TabIndex = 4
        Me.rchtxtIQApproval2.Text = "RichTextBox1"
        '
        'rchtxtIQApproval1
        '
        Me.rchtxtIQApproval1.AutoSize = True
        Me.rchtxtIQApproval1.BackColor = System.Drawing.Color.AliceBlue
        Me.rchtxtIQApproval1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.rchtxtIQApproval1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rchtxtIQApproval1.Location = New System.Drawing.Point(8, 40)
        Me.rchtxtIQApproval1.Name = "rchtxtIQApproval1"
        Me.rchtxtIQApproval1.Size = New System.Drawing.Size(520, 16)
        Me.rchtxtIQApproval1.TabIndex = 1
        Me.rchtxtIQApproval1.Text = "RichTextBox1"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.dgCustomer)
        Me.Panel1.Controls.Add(Me.txtJointFunctionalArea)
        Me.Panel1.Controls.Add(Me.lblHeader3)
        Me.Panel1.Controls.Add(Me.rchtxtIQApproval2)
        Me.Panel1.Controls.Add(Me.rchtxtIQApproval1)
        Me.Panel1.Controls.Add(Me.lblSupplierHeading)
        Me.Panel1.Controls.Add(Me.lblCustomerHeading)
        Me.Panel1.Controls.Add(Me.lblName)
        Me.Panel1.Controls.Add(Me.txtName)
        Me.Panel1.Controls.Add(Me.lblDesignation)
        Me.Panel1.Controls.Add(Me.lblCompanyName)
        Me.Panel1.Controls.Add(Me.lblDate)
        Me.Panel1.Controls.Add(Me.txtDesignation)
        Me.Panel1.Controls.Add(Me.txtCompanyName)
        Me.Panel1.Controls.Add(Me.dtpDate)
        Me.Panel1.Controls.Add(Me.txtSupplierID)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(474, 510)
        Me.Panel1.TabIndex = 11
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel2.Controls.Add(Me.PictureBox1)
        Me.Panel2.Controls.Add(Me.lblHeader2)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(472, 32)
        Me.Panel2.TabIndex = 20
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False
        '
        'lblHeader2
        '
        Me.lblHeader2.BackColor = System.Drawing.Color.AliceBlue
        Me.lblHeader2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblHeader2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeader2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblHeader2.Location = New System.Drawing.Point(35, 7)
        Me.lblHeader2.Name = "lblHeader2"
        Me.lblHeader2.Size = New System.Drawing.Size(376, 18)
        Me.lblHeader2.TabIndex = 1
        Me.lblHeader2.Text = "C. Approval"
        Me.lblHeader2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgCustomer
        '
        Me.dgCustomer.AllowSorting = False
        Me.dgCustomer.AlternatingBackColor = System.Drawing.Color.AliceBlue
        Me.dgCustomer.BackColor = System.Drawing.Color.LightSkyBlue
        Me.dgCustomer.BackgroundColor = System.Drawing.Color.AliceBlue
        Me.dgCustomer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.dgCustomer.CaptionBackColor = System.Drawing.Color.LightSkyBlue
        Me.dgCustomer.CaptionFont = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgCustomer.CaptionForeColor = System.Drawing.Color.AliceBlue
        Me.dgCustomer.CaptionVisible = False
        Me.dgCustomer.DataMember = ""
        Me.dgCustomer.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgCustomer.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgCustomer.Location = New System.Drawing.Point(8, 272)
        Me.dgCustomer.Name = "dgCustomer"
        Me.dgCustomer.ParentRowsVisible = False
        Me.dgCustomer.ReadOnly = True
        Me.dgCustomer.RowHeadersVisible = False
        Me.dgCustomer.Size = New System.Drawing.Size(565, 232)
        Me.dgCustomer.TabIndex = 18
        '
        'frmIQApproval
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(474, 386)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmIQApproval"
        Me.Tag = "Installation Approval"
        Me.Text = "Installation Approval"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.dgCustomer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Constants"

    Private Const ConstSrNo As String = "SrNo"
    Private Const ConstName As String = "Name"
    Private Const ConstDesignation As String = "Designation"
    Private Const ConstFunctionalArea As String = "FunctionalArea"
    Private Const ConstCustDate As String = "CustDate"
    Private Const ConstCustomerRepresentativeID As String = "CustomerRepresentativeID"
    
#End Region

#Region " Form Events "

    Private Sub frmIQApproval_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
            '--- Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub frmIQApproval_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

        Try
            If Not (mblnModeLockStatus) Then
                If Not funcSaveSupplierData() Then
                    Throw New Exception("Error in Saving Manufacturer/Supplier Representative Data.")
                End If
                dgCustomer.CurrentCell() = (New DataGridCell(dgCustomer.CurrentRowIndex + 1, 0))
                If Not funcSaveCustomerData() Then
                    Throw New Exception("Error in Saving Customer Representative Data.")
                End If
                dgCustomer.TableStyles.Clear()
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

#End Region

#Region " General Private functions "

    '--------------------------------------------------------
    '    General functions used for Approval.
    '--- funcInitialize - To Initialize form and to get values for Approval from database and display them.
    '--- funcGetSupplierRecords - To Get Manufacturer / Supplier Records from Database.
    '--- subCreateDataTable - To Create Columns in the Data Table.
    '--- funcGetCustomerRecords - To Get Customer Records from Database into DataTable.
    '--- subFormatDataGrid - To format the Data Grid.
    '--- funcSaveSupplierData - To Save the Entered Records into Database.
    '--- funcSaveCustomerData - To Save the Entered Records into Database.
    '--- funcInsertSupplierData - To Add/Insert New Supplier Data in Database.
    '--- funcUpdateSupplierData - To Update Supplier Data in Database.
    '--- funcDeleteSupplierData - To Delete Supplier Data from Database.
    '--- funcInsertCustomerData - To Add/Insert New Customer Data in Database.
    '--- funcUpdateCustomerData - To Update Customer Data in Database.
    '--- funcDeleteCustomerData - To Delete Customer Data from Database.

    Private Sub funcInitialize()
        '=====================================================================
        ' Procedure Name        :   funcInitailize
        ' Description           :   To Initialize form and to get values for Approval from database and display them.
        ' Purpose               :   To Initialize form and to get values for Approval from database and display them.
        ' Parameters Passed     :   None.
        ' Returns               :   None.
        ' Parameters Affected   :   None.
        ' Assumptions           :
        ' Dependencies          :
        ' Author                :   Gitesh
        ' Created               :   January, 2003 
        ' Revisions             :
        '=====================================================================
        Dim objDtTmp As DataTable
        Dim intCount As Integer
        Dim objDataRow As DataRow
        Try
            Select Case mintMode
                Case ENUM_IQOQPQ_STATUS.IQ
                    'mfrmIQApproval = Me
                    funcAprovalTextFormatForIQ()

                Case ENUM_IQOQPQ_STATUS.OQ
                    'mfrmOQApproval = Me
                    funcAprovalTextFormatForOQ()

                Case ENUM_IQOQPQ_STATUS.PQ
                    'mfrmPQApproval = Me
                    funcAprovalTextFormatForPQ()
            End Select

            '--- To clear Text Fields
            txtName.Text = ""
            txtSupplierID.Text = ""
            txtCompanyName.Text = ""
            txtDesignation.Text = ""
            txtJointFunctionalArea.Text = ""

            mdtpCustDate = New DateTimePicker

            AddHandler mdtpCustDate.ValueChanged, AddressOf dtpCustDate_ValueChanged
            dgCustomer.Controls.Add(mdtpCustDate)
            mdtpCustDate.Visible = False
            mdtpCustDate.Format = DateTimePickerFormat.Custom
            mdtpCustDate.CustomFormat = "dd-MMM-yyyy"

            objDtTmp = New DataTable

            objDtTmp = gobjDataAccess.funcGetSupplierRecords(mintMode)

            If Not objDtTmp Is Nothing Then
                If Not objDtTmp.Rows.Count = 0 Then
                    txtName.Text = CStr(objDtTmp.Rows.Item(0).Item("Name"))
                    txtSupplierID.Text = CStr(objDtTmp.Rows.Item(0).Item("ManufacturerRepresentativeID"))
                    txtCompanyName.Text = CStr(objDtTmp.Rows.Item(0).Item("Company"))
                    txtDesignation.Text = CStr(objDtTmp.Rows.Item(0).Item("Designation"))
                    txtJointFunctionalArea.Text = CStr(objDtTmp.Rows.Item(0).Item("JointFunctionalArea"))
                    'dtpDate.Value = CDate(objDtTmp.Rows.Item(0).Item("ManDate"))
                End If
            Else
                Throw New Exception("Error in Getting Manufacturer/Supplier Representative Records.")
            End If
            'If Not funcGetSupplierRecords() Then
            '    Throw New Exception("Error in Getting Manufacturer/Supplier Representative Records.")
            'End If

            mObjDataTable = New DataTable("CustomerRepresentative")
            subCreateCustomerDataTable()
            objDtTmp = New DataTable

            objDtTmp = gobjDataAccess.funcGetCustomerRecords(mintMode)

            If Not objDtTmp Is Nothing Then
                If Not objDtTmp.Rows.Count = 0 Then
                    For intCount = 0 To objDtTmp.Rows.Count - 1
                        objDataRow = mObjDataTable.NewRow
                        'objDataRow.Item(ConstSrNo) = CInt(objDtTmp.Rows.Item(intCount).Item("CustomerRepresentativeID"))
                        'Added by pankaj on 6 Dec 07
                        objDataRow.Item(ConstSrNo) = intCount + 1 'CInt(objDtTmp.Rows.Item(intCount).Item("CustomerRepresentativeID"))
                        '--------
                        objDataRow.Item(ConstName) = CStr(objDtTmp.Rows.Item(intCount).Item("Name"))
                        objDataRow.Item(ConstDesignation) = CStr(objDtTmp.Rows.Item(intCount).Item("Designation"))
                        objDataRow.Item(ConstFunctionalArea) = CStr(objDtTmp.Rows.Item(intCount).Item("FunctionalArea"))
                        objDataRow.Item(ConstCustDate) = CDate(objDtTmp.Rows.Item(intCount).Item("CustDate"))
                        objDataRow.Item(ConstCustomerRepresentativeID) = CInt(objDtTmp.Rows.Item(intCount).Item("CustomerRepresentativeID"))
                        mObjDataTable.Rows.Add(objDataRow)
                    Next
                End If
            End If


            If IsNothing(mObjDataTable) = True Then
                Throw New Exception("Error in Getting Equipment List Records.")
            Else
                subFormatCustomerDataGrid()
            End If
            'If funcGetCustomerRecords() Then
            '    subFormatCustomerDataGrid()
            'Else
            '    Throw New Exception("Error in Getting Customer Representative Data.")
            'End If

            mblnModeLockStatus = gobjDataAccess.funcCheckModeLocked(mintMode)
            If (mblnModeLockStatus) Then
                dgCustomer.ReadOnly = True
                txtJointFunctionalArea.ReadOnly = True
                txtCompanyName.ReadOnly = True
                txtDesignation.ReadOnly = True
                txtName.ReadOnly = True
                dtpDate.Enabled = False
                mdtpCustDate.Enabled = False 'added by pankaj on 6 Dec 07
                mdtpCustDate.Width = 0
            Else
                dgCustomer.ReadOnly = False
                txtJointFunctionalArea.ReadOnly = False
                txtCompanyName.ReadOnly = False
                txtDesignation.ReadOnly = False
                txtName.ReadOnly = False
                dtpDate.Enabled = True
                mdtpCustDate.Enabled = True 'added by pankaj on 6 Dec 07
            End If
        Catch ex As Exception
            '---------------------------------------------------------
            '--- Error logging
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

    Private Sub dtpCustDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'try catch added by ; dinesh wagh on 3.2.2010
        Try
            dgCustomer(dgCustomer.CurrentCell.RowNumber, dgCustomer.CurrentCell.ColumnNumber) = mdtpCustDate.Value
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

#Region "Customer Records Functions"

    Private Sub subCreateCustomerDataTable()
        '=====================================================================
        ' Procedure Name        :   subCreateCustomerDataTable
        ' Description           :   To Create Columns in the Data Table.
        ' Purpose               :   To Create Columns in the Data Table.
        ' Parameters Passed     :   None.
        ' Returns               :   None.
        ' Parameters Affected   :   None.
        ' Assumptions           :
        ' Dependencies          :
        ' Author                :   Gitesh
        ' Created               :   January, 2003 
        ' Revisions             :
        '=====================================================================
        Dim objDataColumn As DataColumn

        Try
            objDataColumn = New DataColumn("SrNo", GetType(Integer))
            objDataColumn.ReadOnly = True
            ' objDataColumn.AutoIncrement = True
            mObjDataTable.Columns.Add(objDataColumn)

            mObjDataTable.Columns.Add(New DataColumn("Name", GetType(String)))
            mObjDataTable.Columns.Add(New DataColumn("Designation", GetType(String)))
            mObjDataTable.Columns.Add(New DataColumn("FunctionalArea", GetType(String)))
            mObjDataTable.Columns.Add(New DataColumn("CustDate", GetType(Date)))
            mObjDataTable.Columns.Add(New DataColumn("CustomerRepresentativeID", GetType(Integer)))
        Catch ex As Exception
            '---------------------------------------------------------
            '--- Error logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = "Unable to Create Customer Representative Data Table."
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

    End Sub

    'Private Function funcGetCustomerRecords() As Boolean
    '    '=====================================================================
    '    ' Procedure Name        :   funcGetCustomerRecords
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

    '    Dim objReader As OleDbDataReader
    '    Dim objDataRow As DataRow
    '    Dim sql_string As String
    '    Dim reader_status As Boolean
    '    Dim rec_cnt As Integer

    '    Try
    '        sql_string = "Select CustomerRepresentativeID ,Name ,Designation ,FunctionalArea ,CustDate from CustomerRepresentative where CheckStatusIQOQPQ = " & mintMode & " "

    '        'reader_status = gclsDBFunctions.GetRecords(sql_string, gOleDBIQOQPQConnection, objReader)

    '        If Not (reader_status) Then
    '            Return False
    '        End If

    '        rec_cnt = 1
    '        While objReader.Read
    '            objDataRow = mObjDataTable.NewRow()

    '            objDataRow("SrNo") = rec_cnt
    '            objDataRow("Name") = CStr(objReader.Item("Name"))
    '            objDataRow("Designation") = CStr(objReader.Item("Designation"))
    '            objDataRow("FunctionalArea") = CStr(objReader.Item("FunctionalArea"))
    '            If IsDBNull(objReader.Item("CustDate")) Then
    '            Else
    '                objDataRow("CustDate") = CDate(objReader.Item("CustDate"))
    '            End If
    '            objDataRow("CustomerRepresentativeID") = Convert.ToInt32(objReader.Item("CustomerRepresentativeID"))

    '            mObjDataTable.Rows.Add(objDataRow)
    '            rec_cnt = rec_cnt + 1
    '        End While
    '        objReader.Close()

    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        '--- Error logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = "Error in Getting Customer Representative Records."
    '        gobjErrorHandler.WriteErrorLog(ex)
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

    Private Sub subFormatCustomerDataGrid()
        Dim objTextColumn As DataGridTextBoxColumn

        Try
            dgCustomer.TableStyles.Clear()
            mobjDataView.Table = mObjDataTable
            mobjDataView.AllowNew = True
            dgCustomer.DataSource = mobjDataView
            'dgCustomer.ReadOnly = False

            mobjGridTableStyle.RowHeadersVisible = False
            mobjGridTableStyle.ResetAlternatingBackColor()
            mobjGridTableStyle.ResetBackColor()
            mobjGridTableStyle.ResetForeColor()
            mobjGridTableStyle.ResetGridLineColor()
            mobjGridTableStyle.BackColor = Color.AliceBlue
            mobjGridTableStyle.GridLineColor = Color.Black
            mobjGridTableStyle.HeaderBackColor = Color.FromArgb(205, 225, 250)
            mobjGridTableStyle.HeaderForeColor = Color.Black
            mobjGridTableStyle.AlternatingBackColor = Color.AliceBlue
            mobjGridTableStyle.AllowSorting = False

            mobjGridTableStyle.MappingName = "CustomerRepresentative"

            objTextColumn = New DataGridTextBoxColumn
            objTextColumn.MappingName = "SrNo"
            objTextColumn.HeaderText = "Sr.No."
            objTextColumn.Width = 40
            objTextColumn.ReadOnly = True
            objTextColumn.NullText = ""
            objTextColumn.Alignment = HorizontalAlignment.Center
            mobjGridTableStyle.GridColumnStyles.Add(objTextColumn)

            objTextColumn = New DataGridTextBoxColumn
            objTextColumn.MappingName = "Name"
            objTextColumn.HeaderText = "Name"
            objTextColumn.Width = 150
            objTextColumn.ReadOnly = False
            objTextColumn.NullText = ""
            objTextColumn.Alignment = HorizontalAlignment.Center
            mobjGridTableStyle.GridColumnStyles.Add(objTextColumn)

            objTextColumn = New DataGridTextBoxColumn
            objTextColumn.MappingName = "Designation"
            objTextColumn.HeaderText = "Designation"
            objTextColumn.Width = 150
            objTextColumn.ReadOnly = False
            objTextColumn.NullText = ""
            objTextColumn.Alignment = HorizontalAlignment.Center
            mobjGridTableStyle.GridColumnStyles.Add(objTextColumn)

            objTextColumn = New DataGridTextBoxColumn
            objTextColumn.MappingName = "FunctionalArea"
            objTextColumn.HeaderText = "Functional Area"
            objTextColumn.Width = 140
            objTextColumn.ReadOnly = False
            objTextColumn.NullText = ""
            objTextColumn.Alignment = HorizontalAlignment.Center
            mobjGridTableStyle.GridColumnStyles.Add(objTextColumn)

            objTextColumn = New DataGridTextBoxColumn
            objTextColumn.MappingName = "CustDate"
            objTextColumn.HeaderText = "Date"
            objTextColumn.Width = 80
            objTextColumn.Format = "dd-MMM-yyyy"
            objTextColumn.ReadOnly = False
            objTextColumn.NullText = ""
            objTextColumn.Alignment = HorizontalAlignment.Center
            mobjGridTableStyle.GridColumnStyles.Add(objTextColumn)

            objTextColumn = New DataGridTextBoxColumn
            objTextColumn.MappingName = "CustomerRepresentativeID"
            objTextColumn.HeaderText = "CustomerRepresentativeID"
            objTextColumn.Width = 0
            objTextColumn.ReadOnly = True
            objTextColumn.NullText = ""
            mobjGridTableStyle.GridColumnStyles.Add(objTextColumn)

            mobjGridTableStyle.GridLineColor = Color.Black
            dgCustomer.TableStyles.Add(mobjGridTableStyle)

        Catch ex As Exception
            '---------------------------------------------------------
            '--- Error logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = "Unable To Format Data - Grid For Customer Representative Data."
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
    End Sub

    'Private Function funcSaveCustomerData() As Boolean
    '    '=====================================================================
    '    ' Procedure Name        :   funcSaveCustomerData
    '    ' Description           :   To Save the Entered Records into Database.
    '    ' Purpose               :   To Save the Entered Records into Database.
    '    ' Parameters Passed     :   None.
    '    ' Returns               :   None.
    '    ' Parameters Affected   :   None.
    '    ' Assumptions           :
    '    ' Dependencies          :
    '    ' Author                :   Gitesh
    '    ' Created               :   January, 2003 
    '    ' Revisions             :
    '    '=====================================================================

    '    Dim intRecordCount, intCustomerID, temp_cnt As Integer
    '    Dim strName, strDesignation, strFunctionalArea As String
    '    Dim dtCustDate As DateTime
    '    Dim status As Boolean = True

    '    Try
    '        intRecordCount = mObjDataTable.Rows.Count

    '        For temp_cnt = 0 To (intRecordCount - 1)
    '            '--- To Check if Customer ID is Null.
    '            If IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("CustomerRepresentativeID").Ordinal)) Then
    '                If (IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("Name").Ordinal)) = False) Then
    '                    strName = CStr(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("Name").Ordinal))
    '                    If IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("Designation").Ordinal)) Then

    '                    Else
    '                        strDesignation = CStr(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("Designation").Ordinal))
    '                    End If
    '                    If IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("FunctionalArea").Ordinal)) Then
    '                    Else
    '                        strFunctionalArea = CStr(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("FunctionalArea").Ordinal))
    '                    End If
    '                    If IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("CustDate").Ordinal)) Then
    '                    Else
    '                        dtCustDate = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("CustDate").Ordinal)
    '                    End If
    '                    status = funcInsertCustomerData(strName, strDesignation, strFunctionalArea, dtCustDate)
    '                    If Not (status) Then
    '                        Throw New Exception("Error in Saving Customer Representative Data.")
    '                    End If
    '                End If
    '            Else
    '                If IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("Name").Ordinal)) Then
    '                    'Delete function if reqd.
    '                Else
    '                    intCustomerID = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("CustomerRepresentativeID").Ordinal)
    '                    strName = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("Name").Ordinal)
    '                    strDesignation = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("Designation").Ordinal)
    '                    strFunctionalArea = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("FunctionalArea").Ordinal)
    '                    If IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("CustDate").Ordinal)) Then
    '                    Else
    '                        dtCustDate = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("CustDate").Ordinal)
    '                    End If
    '                    status = funcUpdateCustomerData(strName, strDesignation, strFunctionalArea, dtCustDate, intCustomerID)
    '                    If Not (status) Then
    '                        Throw New Exception("Error in Updating Customer Representative Data.")
    '                    End If
    '                End If
    '            End If
    '        Next

    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        '--- Error logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = "Error in Saving Customer Representative Records."
    '        gobjErrorHandler.WriteErrorLog(ex)
    '        '---------------------------------------------------------
    '    Finally
    '        '---------------------------------------------------------
    '        '--- Writing Execution log
    '        If CONST_CREATE_EXECUTION_LOG = 1 Then
    '            gobjErrorHandler.WriteExecutionLog()
    '        End If
    '        '---------------------------------------------------------
    '    End Try

    '    Return status

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
        ' Author                :   M.Kamal
        ' Created               :   May, 20,2004 
        ' Revisions             :
        '=====================================================================

        Dim intRecordCount, intCustomerID, temp_cnt As Integer
        Dim strName, strDesignation, strFunctionalArea As String
        Dim dtCustDate As DateTime
        Dim status As Boolean = True

        Try
            dtCustDate = Now
            intRecordCount = mObjDataTable.Rows.Count

            For temp_cnt = 0 To (intRecordCount - 1)
                '--- To Check if Customer ID is Null.
                If IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("CustomerRepresentativeID").Ordinal)) Then
                    If (IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("Name").Ordinal)) = False) Then
                        strName = CStr(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("Name").Ordinal))
                        strDesignation = CStr(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("Designation").Ordinal))
                        strFunctionalArea = CStr(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("FunctionalArea").Ordinal))
                        If IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("CustDate").Ordinal)) = False Then
                            dtCustDate = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("CustDate").Ordinal)
                        End If
                        status = gobjDataAccess.funcInsertCustomerData(strName, strDesignation, strFunctionalArea, dtCustDate, mintMode)
                        If Not (status) Then
                            Throw New Exception("Error in Saving Customer Representative Data.")
                        End If
                    End If
                Else
                    If IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("Name").Ordinal)) Or IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("Designation").Ordinal)) Or IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("FunctionalArea").Ordinal)) Or IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("CustDate").Ordinal)) Then
                        'Delete function if reqd.
                        intCustomerID = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("CustomerRepresentativeID").Ordinal)
                        status = gobjDataAccess.funcDeleteCustomerData(intCustomerID, mintMode)
                        If Not (status) Then
                            Throw New Exception("Error in Deleting Customer Details.")
                        End If

                    Else
                        intCustomerID = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("CustomerRepresentativeID").Ordinal)
                        strName = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("Name").Ordinal)
                        strDesignation = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("Designation").Ordinal)
                        strFunctionalArea = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("FunctionalArea").Ordinal)
                        If IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("CustDate").Ordinal)) Then
                            dtCustDate = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("CustDate").Ordinal)
                        End If
                        status = gobjDataAccess.funcUpdateCustomerDataApproval(strName, strDesignation, strFunctionalArea, dtCustDate, intCustomerID, mintMode)
                        If Not (status) Then
                            Throw New Exception("Error in Updating Customer Representative Data.")
                        End If
                    End If
                End If
            Next

        Catch ex As Exception
            '---------------------------------------------------------
            '--- Error logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = "Error in Saving Customer Representative Records."
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

    'Private Function funcInsertCustomerData(ByVal strName As String, ByVal strDesignation As String, ByVal strFunctionalArea As String, ByVal dtCustDate As DateTime) As Boolean
    '    '=====================================================================
    '    ' Procedure Name        :   funcInsertCustomerData
    '    ' Description           :   To Add/Insert New Customer Data in Database.
    '    ' Purpose               :   To Add/Insert New Customer Data in Database.
    '    ' Parameters Passed     :   None.
    '    ' Returns               :   None.
    '    ' Parameters Affected   :   None.
    '    ' Assumptions           :
    '    ' Dependencies          :
    '    ' Author                :   Gitesh
    '    ' Created               :   January, 2003 
    '    ' Revisions             :
    '    '=====================================================================

    '    Dim Status As Boolean
    '    Dim str_sql As String
    '    Dim objCommand As New OleDbCommand
    '    Dim intCustomerID As Integer

    '    Try

    '        '--- Generating Next Customer ID. 
    '        'intCustomerID = gclsDBFunctions.GetNextID("CustomerRepresentative", "CustomerRepresentativeID", gOleDBIQOQPQConnection)

    '        '---  Query for adding  data 
    '        str_sql = " Insert into CustomerRepresentative " & _
    '                  " (CustomerRepresentativeID ,Name ,Designation ,CustDate ,CheckStatusIQOQPQ ,FunctionalArea) " & _
    '                  " values(" & intCustomerID & ", '" & strName & "','" & strDesignation & "','" & dtCustDate & "'," & mintMode & ",'" & strFunctionalArea & "') "
    '        '" values(?,?,?,?,?,?) "

    '        '--- Providing command object for EquimentList
    '        With objCommand
    '            '.Connection = gOleDBIQOQPQConnection
    '            .CommandType = CommandType.Text
    '            .CommandText = str_sql
    '            '.Parameters.Add("CustomerRepresentativeID", OleDbType.Numeric).Value = intCustomerID
    '            '.Parameters.Add("Name", OleDbType.VarChar, 50).Value = strName
    '            '.Parameters.Add("Designation", OleDbType.VarChar, 50).Value = strDesignation
    '            '.Parameters.Add("CustDate", OleDbType.DBDate).Value = dtCustDate
    '            '.Parameters.Add("FunctionalArea", OleDbType.VarChar, 50).Value = strFunctionalArea
    '            '.Parameters.Add("CheckStatusIQOQPQ", OleDbType.Single).Value = mintMode
    '            .ExecuteNonQuery()
    '        End With

    '        objCommand.Dispose()
    '        Status = True

    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        'Error logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = "Error in Saving Customer Representative Data."
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

    'Private Function funcUpdateCustomerData(ByVal strName As String, ByVal strDesignation As String, ByVal strFunctionalArea As String, ByVal dtCustDate As DateTime, ByVal intCustomerID As Integer) As Boolean
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
    '    ' Created               :   January, 2003 
    '    ' Revisions             :
    '    '=====================================================================

    '    Dim Status As Boolean
    '    Dim str_sql As String
    '    Dim objCommand As New OleDbCommand

    '    Try

    '        '---  Query for Updating data 
    '        str_sql = " Update CustomerRepresentative " & _
    '                  " Set Name = ? ,Designation = ? ,FunctionalArea =? ,CustDate = ? " & _
    '                  " where CustomerRepresentativeID = " & intCustomerID & " and CheckStatusIQOQPQ = " & mintMode & "  "

    '        '--- Providing command object for EquimentList
    '        With objCommand
    '            '.Connection = gOleDBIQOQPQConnection
    '            .CommandType = CommandType.Text
    '            .CommandText = str_sql
    '            .Parameters.Add("Name", OleDbType.VarChar, 50).Value = strName
    '            .Parameters.Add("Designation", OleDbType.VarChar, 50).Value = strDesignation
    '            .Parameters.Add("FunctionalArea", OleDbType.VarChar, 50).Value = strFunctionalArea
    '            .Parameters.Add("CustDate", OleDbType.DBDate).Value = dtCustDate
    '            .ExecuteNonQuery()
    '        End With

    '        objCommand.Dispose()
    '        Status = True

    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        'Error logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = "Error in Updating Customer Representative Records."
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

    'Private Function funcDeleteCustomerData(ByVal intCustomerID As Integer) As Boolean
    '    '=====================================================================
    '    ' Procedure Name        :   funcDeleteCustomerData
    '    ' Description           :   To Delete Customer Data from Database.
    '    ' Purpose               :   To Delete Customer Data from Database.
    '    ' Parameters Passed     :   None.
    '    ' Returns               :   None.
    '    ' Parameters Affected   :   None.
    '    ' Assumptions           :
    '    ' Dependencies          :
    '    ' Author                :   Gitesh
    '    ' Created               :   January, 2003 
    '    ' Revisions             :
    '    '=====================================================================

    '    Dim Status As Boolean
    '    Dim str_sql As String

    '    Try

    '        '--- Query to Delete from Database
    '        str_sql = " Delete * from CustomerRepresentative " & _
    '                  " where CustomerRepresentativeID = " & intCustomerID & " and CheckStatusIQOQPQ = " & mintMode & "  "

    '        'Status = gclsDBFunctions.AddORDeleteRecord(str_sql, gOleDBIQOQPQConnection)
    '        If (Status = False) Then
    '            Throw New Exception("Error in Deleting Customer Representative Data.")
    '        End If

    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        'Error logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = "Error in Deleting Customer Representative Data."
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

#Region "Supplier Records Functions"

    'Private Function funcGetSupplierRecords() As Boolean
    '    '=====================================================================
    '    ' Procedure Name        :   funcGetSupplierRecords
    '    ' Description           :   To Get Supplier Records from Database into DataTable.
    '    ' Purpose               :   To Get Supplier Records from Database into DataTable.
    '    ' Parameters Passed     :   None.
    '    ' Returns               :   None.
    '    ' Parameters Affected   :   None.
    '    ' Assumptions           :
    '    ' Dependencies          :
    '    ' Author                :   
    '    ' Created               :   January, 2003 
    '    ' Revisions             :
    '    '=====================================================================

    '    Dim objReader As OleDbDataReader
    '    Dim sql_string As String
    '    Dim reader_status As Boolean

    '    Try
    '        sql_string = "Select ManufacturerRepresentativeID ,Name ,Designation ,Company ,ManDate ,JointFunctionalArea from ManufacturerRepresentative where CheckStatusIQOQPQ = " & mintMode & " "

    '        'reader_status = gclsDBFunctions.GetRecords(sql_string, gOleDBIQOQPQConnection, objReader)

    '        If Not (reader_status) Then
    '            Throw New Exception("Error in Getting Manufacturer/Supplier Representative Data.")
    '        End If

    '        While objReader.Read()
    '            txtSupplierID.Text = CStr(objReader.Item("ManufacturerRepresentativeID"))
    '            txtName.Text = CStr(objReader.Item("Name"))
    '            txtDesignation.Text = CStr(objReader.Item("Designation"))
    '            txtCompanyName.Text = CStr(objReader.Item("Company"))
    '            dtpDate.Value = CDate(objReader.Item("ManDate"))
    '            txtJointFunctionalArea.Text = CStr(objReader.Item("JointFunctionalArea"))
    '        End While
    '        objReader.Close()

    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        'Error logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = ex.Message
    '        gobjErrorHandler.WriteErrorLog(ex)
    '        '---------------------------------------------------------           
    '        Return False
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

    Public Function funcSaveSupplierData() As Boolean
        '=====================================================================
        ' Procedure Name        :   funcSaveSupplierData
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

        Dim intRecordCount, intSupplierID, temp_cnt As Integer
        Dim strName, strDesignation, strCompany, strFunctionalArea As String
        Dim dtManDate As DateTime
        Dim status As Boolean = True

        Try
            '--- To Check if Supplier ID is Null.
            If (IsDBNull(txtSupplierID.Text) Or txtSupplierID.Text = "") Then
                If (txtName.Text = "") Then
                Else
                    strName = txtName.Text
                    strDesignation = txtDesignation.Text
                    strCompany = txtCompanyName.Text
                    dtManDate = dtpDate.Value
                    strFunctionalArea = txtJointFunctionalArea.Text
                    status = gobjDataAccess.funcInsertSupplierData(strName, strDesignation, strCompany, dtManDate, strFunctionalArea, mintMode)
                    If Not (status) Then
                        Throw New Exception("Error in Saving Supplier Data.")
                    End If
                End If
            Else
                If txtName.Text = "" Then
                    'Delete function if reqd.
                Else
                    intSupplierID = Convert.ToInt32(txtSupplierID.Text)
                    strName = txtName.Text
                    strDesignation = txtDesignation.Text
                    strCompany = txtCompanyName.Text
                    dtManDate = dtpDate.Value
                    strFunctionalArea = txtJointFunctionalArea.Text
                    status = gobjDataAccess.funcUpdateSupplierData(strName, strDesignation, strCompany, dtManDate, strFunctionalArea, intSupplierID, mintMode)
                    If Not (status) Then
                        Throw New Exception("Error in Updating Supplier Data.")
                    End If
                End If
            End If

        Catch ex As Exception
            '---------------------------------------------------------
            '--- Error logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = "Unable To Save Records in ManufacturerRepresentative table."
            gobjErrorHandler.WriteErrorLog(ex)
            Return (False)
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

    'Private Function funcInsertSupplierData(ByVal strName As String, ByVal strDesignation As String, ByVal strCompany As String, ByVal dtManDate As DateTime, ByVal strFunctionalArea As String) As Boolean
    '    '=====================================================================
    '    ' Procedure Name        :   funcInsertSupplierData
    '    ' Description           :   To Add/Insert New Supplier Data in Database.
    '    ' Purpose               :   To Add/Insert New Supplier Data in Database.
    '    ' Parameters Passed     :   None.
    '    ' Returns               :   None.
    '    ' Parameters Affected   :   None.
    '    ' Assumptions           :
    '    ' Dependencies          :
    '    ' Author                :   Gitesh
    '    ' Created               :   January, 2003 
    '    ' Revisions             :
    '    '=====================================================================

    '    Dim Status As Boolean
    '    Dim str_sql As String
    '    Dim objCommand As New OleDbCommand
    '    Dim intSupplierID As Integer

    '    Try

    '        '--- Generating Next Customer ID. 
    '        'intSupplierID = gclsDBFunctions.GetNextID("ManufacturerRepresentative", "ManufacturerRepresentativeID", gOleDBIQOQPQConnection)

    '        '---  Query for adding  data 
    '        str_sql = " Insert into ManufacturerRepresentative " & _
    '                  " (ManufacturerRepresentativeID ,Name ,Designation ,Company ,ManDate ,JointFunctionalArea ,CheckStatusIQOQPQ) " & _
    '                  " values(" & intSupplierID & " ,'" & strName & "','" & strDesignation & "','" & strCompany & "','" & dtManDate & "' ,'" & strFunctionalArea & "' ," & mintMode & ") "

    '        '" values(?,?,?,?,?,?,?) "

    '        '--- Providing command object for EquimentList
    '        With objCommand
    '            '.Connection = gOleDBIQOQPQConnection
    '            .CommandType = CommandType.Text
    '            .CommandText = str_sql
    '            '.Parameters.Add("ManufacturerRepresentativeID", OleDbType.Numeric).Value = intSupplierID
    '            '.Parameters.Add("Name", OleDbType.VarChar, 50).Value = strName
    '            '.Parameters.Add("Designation", OleDbType.VarChar, 50).Value = strDesignation
    '            '.Parameters.Add("Company", OleDbType.VarChar, 50).Value = strCompany
    '            '.Parameters.Add("ManDate", OleDbType.DBDate).Value = dtManDate
    '            '.Parameters.Add("JointFunctionalArea", OleDbType.VarChar, 50).Value = strFunctionalArea
    '            '.Parameters.Add("CheckStatusIQOQPQ", OleDbType.Single).Value = mintMode
    '            .ExecuteNonQuery()
    '        End With

    '        objCommand.Dispose()
    '        Status = True

    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        'Error logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = "Records Could Not be Inserted."
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

    'Private Function funcUpdateSupplierData(ByVal strName As String, ByVal strDesignation As String, ByVal strCompany As String, ByVal dtManDate As DateTime, ByVal strFunctionalArea As String, ByVal intSupplierID As Integer) As Boolean
    '    '=====================================================================
    '    ' Procedure Name        :   funcUpdateSupplierData
    '    ' Description           :   To Update Supplier Data in Database.
    '    ' Purpose               :   To Update Supplier Data in Database.
    '    ' Parameters Passed     :   None.
    '    ' Returns               :   None.
    '    ' Parameters Affected   :   None.
    '    ' Assumptions           :
    '    ' Dependencies          :
    '    ' Author                :   Gitesh
    '    ' Created               :   January, 2003 
    '    ' Revisions             :
    '    '=====================================================================
    '    Dim str_sql As String
    '    Dim objCommand As New OleDbCommand
    '    Try
    '        '---  Query for Updating data 
    '        str_sql = " Update ManufacturerRepresentative " & _
    '                  " Set Name = ? ,Designation = ? ,Company = ? ,JointFunctionalArea =? ,ManDate = ? " & _
    '                  " where ManufacturerRepresentativeID = " & intSupplierID & " and CheckStatusIQOQPQ = " & mintMode & "  "

    '        '--- Providing command object for EquimentList
    '        With objCommand
    '            '.Connection = gOleDBIQOQPQConnection
    '            .CommandType = CommandType.Text
    '            .CommandText = str_sql
    '            .Parameters.Add("Name", OleDbType.VarChar, 250).Value = strName
    '            .Parameters.Add("Designation", OleDbType.VarChar, 250).Value = strDesignation
    '            .Parameters.Add("Company", OleDbType.VarChar, 250).Value = strCompany
    '            .Parameters.Add("JointFunctionalArea", OleDbType.VarChar, 250).Value = strFunctionalArea
    '            .Parameters.Add("ManDate", OleDbType.DBDate).Value = dtManDate
    '            .ExecuteNonQuery()
    '        End With

    '        objCommand.Dispose()

    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        'Error logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = "Records Could Not be Updated."
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

    'End Function

    'Private Function funcDeleteSupplierData(ByVal intSupplierID As Integer) As Boolean
    '    '=====================================================================
    '    ' Procedure Name        :   funcDeleteSupplierData
    '    ' Description           :   To Delete Supplier Data from Database.
    '    ' Purpose               :   To Delete Supplier Data from Database.
    '    ' Parameters Passed     :   None.
    '    ' Returns               :   None.
    '    ' Parameters Affected   :   None.
    '    ' Assumptions           :
    '    ' Dependencies          :
    '    ' Author                :   Gitesh
    '    ' Created               :   January, 2003 
    '    ' Revisions             :
    '    '=====================================================================

    '    Dim Status As Boolean
    '    Dim str_sql As String

    '    Try
    '        '--- Query to Delete from Database
    '        str_sql = " Delete * from ManufacturerRepresentative " & _
    '                  " where ManufacturerRepresentativeID = " & intSupplierID & " and CheckStatusIQOQPQ = " & mintMode & "  "

    '        'Status = gclsDBFunctions.AddORDeleteRecord(str_sql, gOleDBIQOQPQConnection)
    '        If (Status = False) Then
    '            Throw New Exception("Error in Deleting Manufacturer/Supplier Representative Data.")
    '        End If

    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        'Error Handling and logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = "Records Could Not be Deleted."
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

#End Region

#Region "Text for Screen"

#Region "TextFormat for IQ"
    Private Sub funcAprovalTextFormatForIQ()

        'try catch added by ; dinesh wagh on 3.2.2010
        Try
            'lblHeader1.Text = "C. INSTALLATION QUALIFICATION"
            lblHeader2.Text = "C. Approval"

            rchtxtIQApproval1.Multiline = True

            'Assigning Text To rchtxtIQApproval1
            rchtxtIQApproval1.Text = "This Approval of Installation Qualification protocol will be responsibility of" & _
           " following -: "
            'Assigning Text To rchtxtIQApproval2
            rchtxtIQApproval2.Text = "Study data has determined that the system described in this document either meets all criteria " & _
            "outlined in this Installation Qualification protocol, or exceptional conditions have been identified " & _
            "and documentation included. Exceptional conditions, if any, have been addressed. The system is " & _
            "ready for specified usage."

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
#End Region

#Region "TextFormat for OQ"
    Private Sub funcAprovalTextFormatForOQ()
        'try catch added by ; dinesh wagh on 3.2.2010

        Try
            'lblHeader1.Text = "D. OPERATIONAL QUALIFICATION"
            lblHeader2.Text = "D. Approval"

            rchtxtIQApproval1.Multiline = True

            'Assigning Text To rchtxtIQApproval1
            rchtxtIQApproval1.Text = "This Approval of Operational Qualification protocol will be responsibility of " & _
           " following -: "
            'Assigning Text To rchtxtIQApproval2
            rchtxtIQApproval2.Text = "Study data has determined that the system described in this document either meets all criteria " & _
            "outlined in this Operational Qualification protocol, or exceptional conditions have been identified " & _
            "and documentation included. Exceptional conditions, if any, have been addressed. The system is " & _
            " ready for specified usage."

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
#End Region

#Region "TextFormat for PQ"
    Private Sub funcAprovalTextFormatForPQ()
        'try catch added by ; dinesh wagh on 3.2.2010
        Try
            'lblHeader1.Text = "E. PERFORMANCE QUALIFICATION"
            lblHeader2.Text = "E. Approval"

            rchtxtIQApproval1.Multiline = True

            'Assigning Text To rchtxtIQApproval1
            rchtxtIQApproval1.Text = "This Approval of Performance Qualification protocol will be responsibility of " & _
           " following -: "
            'Assigning Text To rchtxtIQApproval2
            rchtxtIQApproval2.Text = "Study data has determined that the system described in this document either meets all criteria " & _
            "outlined in this Performance Qualification protocol, or exceptional conditions have been identified " & _
            "and documentation included. Exceptional conditions, if any, have been addressed. The system is " & _
            " ready for specified usage."

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
#End Region

#End Region

    Private Sub dgCustomer_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgCustomer.CurrentCellChanged
        'try catch added b y : dinesh wagh on 3.2.2010
        Try
            If Not (mblnModeLockStatus) Then
                mObjDataTable.Columns(0).ReadOnly = False

                If mObjDataTable.Rows.Count = 0 Then
                    mObjDataTable.Columns(0).DefaultValue = 1
                Else
                    dgCustomer.Item(dgCustomer.CurrentRowIndex, 0) = dgCustomer.CurrentRowIndex + 1
                End If

                mObjDataTable.Columns(0).ReadOnly = True

                If (dgCustomer.CurrentCell.ColumnNumber = CONST_DateColumnNo) Then
                    mdtpCustDate.Top = dgCustomer.GetCurrentCellBounds().Top
                    mdtpCustDate.Left = dgCustomer.GetCurrentCellBounds().Left
                    mdtpCustDate.Width = dgCustomer.GetCurrentCellBounds().Width
                    mdtpCustDate.Height = dgCustomer.GetCurrentCellBounds().Height

                    If (dgCustomer.CurrentCell.RowNumber) > 0 Then

                        If IsDBNull(dgCustomer(dgCustomer.CurrentCell.RowNumber, CONST_DateColumnNo)) = False Then
                            mdtpCustDate.Value = Format(CDate(dgCustomer(dgCustomer.CurrentCell.RowNumber, CONST_DateColumnNo)), "dd-MMM-yyyy")
                        Else
                            mdtpCustDate.Value = Format(DateTime.Today, "dd-MMM-yyyy")
                            dgCustomer(dgCustomer.CurrentCell.RowNumber, dgCustomer.CurrentCell.ColumnNumber) = mdtpCustDate.Value
                        End If
                    Else
                        dgCustomer(dgCustomer.CurrentCell.RowNumber, dgCustomer.CurrentCell.ColumnNumber) = mdtpCustDate.Value
                    End If
                    mdtpCustDate.Visible = True
                Else
                    mdtpCustDate.Width = 0
                    mdtpCustDate.Visible = False
                End If
            End If

            If dgCustomer.CurrentRowIndex >= 10 Then
                mobjDataView.AllowNew = False
            End If


            '-------3.2.2010
            If mObjDataTable.Rows.Count = 0 And dgCustomer.CurrentRowIndex <> -1 Then
                dgCustomer.Item(0, 0) = 1
            End If
            '-------------


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

    Private Sub dgCustomer_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgCustomer.GotFocus
        'try catch added by ; dinesh wagh on 3.2.2010
        Try
            mdtpCustDate.Visible = False
            ' dgCustomer.CurrentCell = New DataGridCell(dgCustomer.CurrentCell.RowNumber, 0)
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

    Private Sub dgCustomer_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgCustomer.MouseUp
        'try catch added by ; dinesh wagh on 3.2.2010
        Try
            If (dgCustomer.CurrentCell.ColumnNumber = CONST_DateColumnNo) Then
                mdtpCustDate.Visible = True
            End If
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

End Class
