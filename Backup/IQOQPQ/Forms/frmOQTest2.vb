Option Explicit On 

Imports System.Data
Imports System.Data.OleDb
Imports ErrorHandler.ErrorHandler

Public Class frmOQTest2
    Inherits System.Windows.Forms.Form

#Region " Module level Declarations "
    Private mblnModeLockStatus As Boolean
    Private mstrOledbConnectionString As String
    Private mobjOleDBconnection As OleDbConnection
    'Private mclsDBFunctions As New clsDatabaseFunctions

    Private Const CONST_Test1StartID = 6
    Private Const CONST_Test1EndID = 7
    Private Const CONST_Test2StartID = 8
    Private Const CONST_Test2EndID = 8
    Private Const CONST_Test3StartID = 9
    Private Const CONST_Test3EndID = 9

    Private Const ConstTestName As String = "TestName"
    Private Const ConstDemoDate As String = "DemoDate"
    Private Const ConstVerifiedDate As String = "VerifiedDate"
    Private Const ConstObservation As String = "Observation"
    Private Const ConstTestID As String = "TestID"

    Private mobjTest1DataTable, mobjTest2DataTable, mobjTest3DataTable As DataTable
    Dim mobjTest1GridTableStyle, mobjTest2GridTableStyle, mobjTest3GridTableStyle As New DataGridTableStyle

    Private Enum ENUM_TestNos
        TestNo1 = 1
        TestNo2 = 2
        TestNo3 = 3
    End Enum

    Dim mdtpDate, mdtpDate2, mdtpDate3 As DateTimePicker
    Private Const CONST_DemoColumnNo = 2
    Private Const CONST_VerifyColumnNo = 3

    'code added by ; dinesh wagh on 29.6.2010
    '---------------------------------------------
    Dim mintRowIndex1, mintColumnIndex1 As Integer
    Dim mintRowIndex2, mintColumnIndex2 As Integer
    Dim mblnAvoidProcessing As Boolean
    Private Const CONST_COMMENT_COLUMN_NO = 1
    '----------------------------------------

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
    Friend WithEvents lblPurpose1 As System.Windows.Forms.Label
    Friend WithEvents lblTestName1 As System.Windows.Forms.Label
    Friend WithEvents lblPurpose2 As System.Windows.Forms.Label
    Friend WithEvents lblTestName2 As System.Windows.Forms.Label
    Friend WithEvents lblPurpose3 As System.Windows.Forms.Label
    Friend WithEvents lblTestName3 As System.Windows.Forms.Label
    Friend WithEvents lblHeader2 As System.Windows.Forms.Label
    Friend WithEvents lblHeader As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents dgTest1 As System.Windows.Forms.DataGrid
    Friend WithEvents dgTest2 As System.Windows.Forms.DataGrid
    Friend WithEvents dgTest3 As System.Windows.Forms.DataGrid
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmOQTest2))
        Me.lblPurpose1 = New System.Windows.Forms.Label
        Me.lblTestName1 = New System.Windows.Forms.Label
        Me.lblPurpose2 = New System.Windows.Forms.Label
        Me.lblTestName2 = New System.Windows.Forms.Label
        Me.lblPurpose3 = New System.Windows.Forms.Label
        Me.lblTestName3 = New System.Windows.Forms.Label
        Me.lblHeader2 = New System.Windows.Forms.Label
        Me.lblHeader = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label1 = New System.Windows.Forms.Label
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.dgTest3 = New System.Windows.Forms.DataGrid
        Me.dgTest2 = New System.Windows.Forms.DataGrid
        Me.dgTest1 = New System.Windows.Forms.DataGrid
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.dgTest3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgTest2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgTest1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblPurpose1
        '
        Me.lblPurpose1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPurpose1.Location = New System.Drawing.Point(8, 112)
        Me.lblPurpose1.Name = "lblPurpose1"
        Me.lblPurpose1.Size = New System.Drawing.Size(384, 18)
        Me.lblPurpose1.TabIndex = 19
        Me.lblPurpose1.Text = "Purpose : Introduction and Familiarisation with routine operation."
        '
        'lblTestName1
        '
        Me.lblTestName1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTestName1.Location = New System.Drawing.Point(8, 88)
        Me.lblTestName1.Name = "lblTestName1"
        Me.lblTestName1.Size = New System.Drawing.Size(264, 18)
        Me.lblTestName1.TabIndex = 18
        Me.lblTestName1.Text = "Test Name : Controlling System Procedure"
        '
        'lblPurpose2
        '
        Me.lblPurpose2.Location = New System.Drawing.Point(8, 312)
        Me.lblPurpose2.Name = "lblPurpose2"
        Me.lblPurpose2.Size = New System.Drawing.Size(392, 18)
        Me.lblPurpose2.TabIndex = 19
        Me.lblPurpose2.Text = "Purpose : Introduction and Familiarisation with routine operation."
        '
        'lblTestName2
        '
        Me.lblTestName2.Location = New System.Drawing.Point(8, 288)
        Me.lblTestName2.Name = "lblTestName2"
        Me.lblTestName2.Size = New System.Drawing.Size(376, 18)
        Me.lblTestName2.TabIndex = 18
        Me.lblTestName2.Text = "Test Name : Controlling of External Parameters."
        '
        'lblPurpose3
        '
        Me.lblPurpose3.Location = New System.Drawing.Point(8, 448)
        Me.lblPurpose3.Name = "lblPurpose3"
        Me.lblPurpose3.Size = New System.Drawing.Size(400, 18)
        Me.lblPurpose3.TabIndex = 19
        Me.lblPurpose3.Text = "Purpose : Introduction and Familiarisation with routine operation."
        Me.lblPurpose3.Visible = False
        '
        'lblTestName3
        '
        Me.lblTestName3.Location = New System.Drawing.Point(8, 424)
        Me.lblTestName3.Name = "lblTestName3"
        Me.lblTestName3.Size = New System.Drawing.Size(344, 18)
        Me.lblTestName3.TabIndex = 18
        Me.lblTestName3.Text = "Test Name : Basic Trouble shooting and maintenance"
        Me.lblTestName3.Visible = False
        '
        'lblHeader2
        '
        Me.lblHeader2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeader2.Location = New System.Drawing.Point(8, 48)
        Me.lblHeader2.Name = "lblHeader2"
        Me.lblHeader2.Size = New System.Drawing.Size(544, 32)
        Me.lblHeader2.TabIndex = 16
        Me.lblHeader2.Text = "If an equipment / instrument consist of more than one module, this data sheet sha" & _
        "ll be generated as per the requirement and shall be attached herewith."
        '
        'lblHeader
        '
        Me.lblHeader.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeader.Location = New System.Drawing.Point(35, 7)
        Me.lblHeader.Name = "lblHeader"
        Me.lblHeader.Size = New System.Drawing.Size(400, 18)
        Me.lblHeader.TabIndex = 15
        Me.lblHeader.Text = "D.II OPERATIONAL QUALIFICATION  TESTS"
        Me.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.dgTest3)
        Me.Panel1.Controls.Add(Me.dgTest2)
        Me.Panel1.Controls.Add(Me.dgTest1)
        Me.Panel1.Controls.Add(Me.lblHeader2)
        Me.Panel1.Controls.Add(Me.lblTestName1)
        Me.Panel1.Controls.Add(Me.lblPurpose1)
        Me.Panel1.Controls.Add(Me.lblTestName2)
        Me.Panel1.Controls.Add(Me.lblPurpose2)
        Me.Panel1.Controls.Add(Me.lblTestName3)
        Me.Panel1.Controls.Add(Me.lblPurpose3)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(592, 510)
        Me.Panel1.TabIndex = 17
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 424)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(576, 80)
        Me.Label1.TabIndex = 23
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel2.Controls.Add(Me.PictureBox1)
        Me.Panel2.Controls.Add(Me.lblHeader)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(590, 32)
        Me.Panel2.TabIndex = 22
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'dgTest3
        '
        Me.dgTest3.BackgroundColor = System.Drawing.Color.AliceBlue
        Me.dgTest3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.dgTest3.CaptionVisible = False
        Me.dgTest3.DataMember = ""
        Me.dgTest3.Enabled = False
        Me.dgTest3.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgTest3.Location = New System.Drawing.Point(8, 472)
        Me.dgTest3.Name = "dgTest3"
        Me.dgTest3.ParentRowsVisible = False
        Me.dgTest3.ReadOnly = True
        Me.dgTest3.RowHeadersVisible = False
        Me.dgTest3.Size = New System.Drawing.Size(568, 32)
        Me.dgTest3.TabIndex = 21
        Me.dgTest3.Visible = False
        '
        'dgTest2
        '
        Me.dgTest2.BackgroundColor = System.Drawing.Color.AliceBlue
        Me.dgTest2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.dgTest2.CaptionVisible = False
        Me.dgTest2.DataMember = ""
        Me.dgTest2.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgTest2.Location = New System.Drawing.Point(8, 336)
        Me.dgTest2.Name = "dgTest2"
        Me.dgTest2.ParentRowsVisible = False
        Me.dgTest2.ReadOnly = True
        Me.dgTest2.RowHeadersVisible = False
        Me.dgTest2.Size = New System.Drawing.Size(568, 73)
        Me.dgTest2.TabIndex = 20
        '
        'dgTest1
        '
        Me.dgTest1.BackgroundColor = System.Drawing.Color.AliceBlue
        Me.dgTest1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.dgTest1.CaptionVisible = False
        Me.dgTest1.DataMember = ""
        Me.dgTest1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgTest1.Location = New System.Drawing.Point(8, 144)
        Me.dgTest1.Name = "dgTest1"
        Me.dgTest1.ParentRowsVisible = False
        Me.dgTest1.ReadOnly = True
        Me.dgTest1.RowHeadersVisible = False
        Me.dgTest1.Size = New System.Drawing.Size(568, 120)
        Me.dgTest1.TabIndex = 18
        '
        'frmOQTest2
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(592, 510)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmOQTest2"
        Me.Text = "frmOQTest2"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.dgTest3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgTest2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgTest1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Form Events "
    Private Sub frmOQTest2_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

    Private Sub frmOQTest2_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Try
            If Not (mblnModeLockStatus) Then
                dgTest1.CurrentCell() = (New DataGridCell(dgTest1.CurrentRowIndex + 1, 0))
                If Not funcSaveOQTest2Data(ENUM_TestNos.TestNo1) Then
                    Throw New Exception("Error in Saving OQ Test Data.")
                End If
                dgTest1.TableStyles.Clear()

                dgTest2.CurrentCell() = (New DataGridCell(dgTest2.CurrentRowIndex + 1, 0))
                If Not funcSaveOQTest2Data(ENUM_TestNos.TestNo2) Then
                    Throw New Exception("Error in Saving OQ Test Data.")
                End If
                dgTest2.TableStyles.Clear()

                dgTest3.CurrentCell() = (New DataGridCell(dgTest3.CurrentRowIndex + 1, 0))
                If Not funcSaveOQTest2Data(ENUM_TestNos.TestNo3) Then
                    Throw New Exception("Error in Saving OQ Test Data.")
                End If
                dgTest3.TableStyles.Clear()
            End If
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.ProcessError(EnumErrorType.Critical, ex)
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
    '    General functions used for IQ Tests Listing.
    '--- funcInitialize - To Initialize form and to get values for OQ Tests List from database and display them.
    '--- funcGetOQTest2Records - To Get OQ Test Records from Database and display them.
    '--- funcGetOQTest2Details - To Get OQ Test Records from Database for the given ID.
    '--- funcAssignValuesToControls - To Assign values to controls on form. 
    '--- funcSaveOQTest2Data - To Save the Entered Records into Database.
    '--- funcGetObservationFromControls - To Get values from text box controls on form. 
    '--- funcGetDemoDateFromControls - To Get values from Date Time Picker controls on form. 
    '--- funcGetVerifiedDateFromControls - To Get values from Date Time Picker controls on form. 
    '--- funcInsertOQTest2Data - To Add/Insert New Test Data in Database.
    '--- funcUpdateOQTest2Data - To Update OTest Data in Database.
    '--- funcDeleteOQTest2Data - To Delete OQ Test Data from Database.

    Private Sub funcInitialize()
        '=====================================================================
        ' Procedure Name        :   funcInitailize
        ' Description           :   To Initialize form and to get values for OQ Tests List from database and display them.
        ' Purpose               :   To Initialize form and to get values for OQ Tests List from database and display them.
        ' Parameters Passed     :   None.
        ' Returns               :   None.
        ' Parameters Affected   :   None.
        ' Assumptions           :
        ' Dependencies          :
        ' Author                :   Gitesh
        ' Created               :   January, 2003 
        ' Revisions             :
        '=====================================================================

        Try

            'mfrmOQTest2 = Me
            mobjTest1DataTable = New DataTable("Test1")
            mobjTest2DataTable = New DataTable("Test2")
            mobjTest3DataTable = New DataTable("Test3")

            mdtpDate = New DateTimePicker
            mdtpDate2 = New DateTimePicker
            mdtpDate3 = New DateTimePicker

            '--- Initialising Connection String
            'mstrOledbConnectionString = mclsDBFunctions.ConnectionString(CONST_IQOQPQ_DATABASENAME)

            '--- Initialising Connection 
            mobjOleDBconnection = New OleDbConnection(mstrOledbConnectionString)

            '--- To Add Run-Time DateTime Picker Control
            'AddHandler mdtpDate.ValueChanged, AddressOf dtpDate_ValueChanged '30.6.2010 by dinesh wagh
            AddHandler mdtpDate.LostFocus, AddressOf dtpDate_LostFocus   '30.6.2010 by dinesh wagh


            dgTest1.Controls.Add(mdtpDate)
            mdtpDate.Visible = False
            mdtpDate.Format = DateTimePickerFormat.Custom
            mdtpDate.CustomFormat = "dd-MMM-yyyy"

            'AddHandler mdtpDate2.ValueChanged, AddressOf dtpDate2_ValueChanged '30.6.2010 by dinesh wagh
            AddHandler mdtpDate2.LostFocus, AddressOf dtpDate2_LostFocus  '30.6.2010 by dinesh wagh



            dgTest2.Controls.Add(mdtpDate2)
            mdtpDate2.Visible = False
            mdtpDate2.Format = DateTimePickerFormat.Custom
            mdtpDate2.CustomFormat = "dd-MMM-yyyy"

            'AddHandler mdtpDate3.ValueChanged, AddressOf dtpDate3_ValueChanged '30.6.2010 by dinesh wagh
            AddHandler mdtpDate3.LostFocus, AddressOf dtpDate3_LostFocus  '30.6.2010 by dinesh wagh


            dgTest3.Controls.Add(mdtpDate3)
            mdtpDate3.Visible = False
            mdtpDate3.Format = DateTimePickerFormat.Custom
            mdtpDate3.CustomFormat = "dd-MMM-yyyy"

            subCreateDataTable(mobjTest1DataTable)
            subCreateDataTable(mobjTest2DataTable)
            subCreateDataTable(mobjTest3DataTable)

            If funcGetOQTest2Records(ENUM_TestNos.TestNo1) Then
                subFormatDataGrid(mobjTest1GridTableStyle, dgTest1, mobjTest1DataTable)
            Else
                Throw New Exception("Error in Getting Test Records.")
            End If
            If funcGetOQTest2Records(ENUM_TestNos.TestNo2) Then
                subFormatDataGrid(mobjTest2GridTableStyle, dgTest2, mobjTest2DataTable)
            Else
                Throw New Exception("Error in Getting Test Records.")
            End If
            If funcGetOQTest2Records(ENUM_TestNos.TestNo3) Then
                subFormatDataGrid(mobjTest3GridTableStyle, dgTest3, mobjTest3DataTable)
            Else
                Throw New Exception("Error in Getting Test Records.")
            End If

            'mblnModeLockStatus = gobjDataAccess.funcCheckModeLocked(ENUM_IQOQPQ_STATUS.IQ) '---commented on 19.12.10 by Deepak
            mblnModeLockStatus = gobjDataAccess.funcCheckModeLocked(ENUM_IQOQPQ_STATUS.OQ)  '---written on 19.12.10 by Deepak
            If (mblnModeLockStatus) Then
                dgTest1.ReadOnly = True
                dgTest2.ReadOnly = True
                dgTest3.ReadOnly = True
            Else
                dgTest1.ReadOnly = False
                dgTest2.ReadOnly = False
                dgTest3.ReadOnly = False
            End If

            'code added by : dinesh wagh on 1.2.2010
            '-------------------------------------------------------
            lblPurpose1.Text = "Purpose     :  Introduction and Familiarisation with routine operation."
            lblPurpose2.Text = "Purpose     :  Introduction and Familiarisation with routine operation."
            '-------------------------------------------------------
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.ProcessError(EnumErrorType.Critical, ex)
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

    Private Sub dtpDate_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            '30.6.2010 by dinesh wagh sub name changesd
            dgTest1(dgTest1.CurrentCell.RowNumber, dgTest1.CurrentCell.ColumnNumber) = mdtpDate.Value
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

    Private Sub dtpDate2_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            '30.6.2010 by dinesh wagh sub name changesd
            dgTest2(dgTest2.CurrentCell.RowNumber, dgTest2.CurrentCell.ColumnNumber) = mdtpDate2.Value
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

    Private Sub dtpDate3_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            '30.6.2010 by dinesh wagh sub name changesd
            dgTest3(dgTest3.CurrentCell.RowNumber, dgTest3.CurrentCell.ColumnNumber) = mdtpDate3.Value
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

    Private Sub subCreateDataTable(ByRef objDataTable As DataTable)
        '=====================================================================
        ' Procedure Name        :   subCreateDataTable
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

        Try
            objDataTable.Columns.Add(New DataColumn("TestName", GetType(String)))
            objDataTable.Columns.Add(New DataColumn("Observation", GetType(String)))
            objDataTable.Columns.Add(New DataColumn("DemoDate", GetType(Date)))
            objDataTable.Columns.Add(New DataColumn("VerifiedDate", GetType(Date)))
            objDataTable.Columns.Add(New DataColumn("TestID", GetType(Integer)))
        Catch ex As Exception
            '---------------------------------------------------------
            'Error logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = "Error in Creating Test Data-Table."
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

    Private Function funcGetOQTest2Records(ByVal testnos As Integer) As Boolean
        '=====================================================================
        ' Procedure Name        :   funcGetOQTest2Records
        ' Description           :   To Get OQ Test Records from Database and display them.
        ' Purpose               :   To Get OQ Test Records from Database and display them.
        ' Parameters Passed     :   None.
        ' Returns               :   None.
        ' Parameters Affected   :   None.
        ' Assumptions           :
        ' Dependencies          :
        ' Author                :   
        ' Created               :   January, 2003 
        ' Revisions             :
        '=====================================================================

        'Dim objReader As OleDbDataReader
        Dim objDataRow As DataRow
        'Dim str_sql As String
        'Dim reader_status, record_exists As Boolean
        Dim testID, temp_cnt, intTestStartID, intTestEndID As Integer
        Dim intCount As Integer = 0
        Dim mobjTmpDt As DataTable

        Try
            Select Case testnos
                Case ENUM_TestNos.TestNo1
                    intTestStartID = CONST_Test1StartID
                    intTestEndID = CONST_Test1EndID

                Case ENUM_TestNos.TestNo2
                    intTestStartID = CONST_Test2StartID
                    intTestEndID = CONST_Test2EndID

                Case ENUM_TestNos.TestNo3
                    intTestStartID = CONST_Test3StartID
                    intTestEndID = CONST_Test3EndID

                Case Else
                    intTestStartID = 0
                    intTestEndID = 0
            End Select

            For temp_cnt = intTestStartID To intTestEndID
                testID = temp_cnt

                'str_sql = "Select * from OQTest where OQTestID = " & testID & ""
                'record_exists = mclsDBFunctions.RecordExists(str_sql, mobjOleDBconnection)
                'If record_exists Then
                Select Case testnos
                    Case ENUM_TestNos.TestNo1

                        mobjTmpDt = New DataTable
                        mobjTmpDt = gobjDataAccess.funcGetOQTest1Records(testID)

                        If Not mobjTmpDt Is Nothing Then
                            If Not mobjTmpDt.Rows.Count = 0 Then
                                For intCount = 0 To mobjTmpDt.Rows.Count - 1
                                    objDataRow = mobjTest1DataTable.NewRow
                                    objDataRow.Item(ConstTestName) = gfuncWordWrap(CStr(mobjTmpDt.Rows.Item(intCount).Item("OQTestName")), 30) '5.4.2010 by dinesh wagh
                                    objDataRow.Item(ConstObservation) = gfuncWordWrap(CStr(mobjTmpDt.Rows.Item(intCount).Item("OQObservation")), 30) '5.4.2010 by dinesh wagh
                                    objDataRow.Item(ConstDemoDate) = CDate(mobjTmpDt.Rows.Item(intCount).Item("OQDemoDate"))
                                    objDataRow.Item(ConstVerifiedDate) = CDate(mobjTmpDt.Rows.Item(intCount).Item("OQVerifiedDate"))
                                    objDataRow.Item(ConstTestID) = testID
                                    mobjTest1DataTable.Rows.Add(objDataRow)

                                Next
                            End If
                        Else
                            Throw New Exception("Error in Getting Test Details.")
                        End If

                        'If Not (funcGetOQTest2Details(testID, mobjTest1DataTable)) Then
                        '    Throw New Exception("Error in Getting Test Details.")
                        'End If

                    Case ENUM_TestNos.TestNo2

                        mobjTmpDt = New DataTable
                        mobjTmpDt = gobjDataAccess.funcGetOQTest1Records(testID)

                        If Not mobjTmpDt Is Nothing Then
                            If Not mobjTmpDt.Rows.Count = 0 Then
                                For intCount = 0 To mobjTmpDt.Rows.Count - 1
                                    objDataRow = mobjTest2DataTable.NewRow
                                    objDataRow.Item(ConstTestName) = gfuncWordWrap(CStr(mobjTmpDt.Rows.Item(intCount).Item("OQTestName")), 40) '5.4.2010 by dinesh wagh
                                    objDataRow.Item(ConstObservation) = gfuncWordWrap(CStr(mobjTmpDt.Rows.Item(intCount).Item("OQObservation")), 30) '5.4.2010 by dinesh wagh
                                    objDataRow.Item(ConstDemoDate) = CStr(mobjTmpDt.Rows.Item(intCount).Item("OQDemoDate"))
                                    objDataRow.Item(ConstVerifiedDate) = CStr(mobjTmpDt.Rows.Item(intCount).Item("OQVerifiedDate"))
                                    objDataRow.Item(ConstTestID) = testID
                                    mobjTest2DataTable.Rows.Add(objDataRow)

                                Next
                            End If
                        End If

                        'If Not (funcGetOQTest2Details(testID, mobjTest2DataTable)) Then
                        '    Throw New Exception("Error in Getting Test Details.")
                        'End If

                    Case ENUM_TestNos.TestNo3

                        mobjTmpDt = New DataTable
                        mobjTmpDt = gobjDataAccess.funcGetOQTest1Records(testID)

                        If Not mobjTmpDt Is Nothing Then
                            If Not mobjTmpDt.Rows.Count = 0 Then
                                For intCount = 0 To mobjTmpDt.Rows.Count - 1
                                    objDataRow = mobjTest3DataTable.NewRow
                                    objDataRow.Item(ConstTestName) = CStr(mobjTmpDt.Rows.Item(intCount).Item("OQTestName"))
                                    If IsDBNull(mobjTmpDt.Rows.Item(intCount).Item("OQObservation")) Then
                                    Else
                                        objDataRow.Item(ConstObservation) = CStr(mobjTmpDt.Rows.Item(intCount).Item("OQObservation"))
                                    End If
                                    objDataRow.Item(ConstDemoDate) = CStr(mobjTmpDt.Rows.Item(intCount).Item("OQDemoDate"))
                                    objDataRow.Item(ConstVerifiedDate) = CStr(mobjTmpDt.Rows.Item(intCount).Item("OQVerifiedDate"))
                                    objDataRow.Item(ConstTestID) = testID
                                    mobjTest3DataTable.Rows.Add(objDataRow)

                                Next
                            End If
                        End If

                        'If Not (funcGetOQTest2Details(testID, mobjTest3DataTable)) Then
                        '    Throw New Exception("Error in Getting Test Details.")
                        'End If
                End Select
                'Else
                'Dim strTestName As String
                'Dim dtToday As DateTime = DateTime.Today

                'strTestName = funcGetStdTestName(testID)
                'If funcInsertOQTest2Data(testID, strTestName) Then
                '    Select Case testnos
                '        Case ENUM_TestNos.TestNo1
                '            If Not (funcGetOQTest2Details(testID, mobjTest1DataTable)) Then
                '                Throw New Exception("Error in Getting Test Details.")
                '            End If
                '        Case ENUM_TestNos.TestNo2
                '            If Not (funcGetOQTest2Details(testID, mobjTest2DataTable)) Then
                '                Throw New Exception("Error in Getting Test Details.")
                '            End If
                '        Case ENUM_TestNos.TestNo3
                '            If Not (funcGetOQTest2Details(testID, mobjTest3DataTable)) Then
                '                Throw New Exception("Error in Getting Test Details.")
                '            End If
                '    End Select
                'Else
                '    Throw New Exception("Error in Saving Test Details.")
                'End If
                'End If
            Next
        Catch ex As Exception
            '---------------------------------------------------------
            'Error logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = "Error in Getting Test Records."
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
        Return True
    End Function

    'Private Function funcGetOQTest2Details(ByVal testID As Integer, ByRef objDataTable As DataTable) As Boolean
    '    '=====================================================================
    '    ' Procedure Name        :   funcGetOQTest2Details
    '    ' Description           :   To Get OQ Test Records from Database for the given ID.
    '    ' Purpose               :   To Get OQ Test Records from Database for the given ID.
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
    '    Dim str_sql, strTestName, strObservation As String
    '    Dim dtDemo, dtVerified As DateTime
    '    Dim reader_status As Boolean
    '    Dim objDataRow As DataRow

    '    Try
    '        str_sql = "Select OQTestName ,OQObservation ,OQDemoDate ,OQVerifiedDate from OQTest where OQTestID = " & testID & " "
    '        'reader_status = mclsDBFunctions.GetRecords(str_sql, mobjOleDBconnection, objReader)

    '        If Not (reader_status) Then
    '            Throw New Exception("Error in Opening Connection during Getting Test Details.")
    '        End If

    '        While objReader.Read
    '            objDataRow = objDataTable.NewRow()

    '            objDataRow("TestName") = CStr(objReader.Item("OQTestName"))

    '            If IsDBNull(objReader.Item("OQObservation")) = False Then
    '                objDataRow("Observation") = CStr(objReader.Item("OQObservation"))
    '            End If
    '            If IsDBNull(objReader.Item("OQDemoDate")) = False Then
    '                objDataRow("DemoDate") = CDate(objReader.Item("OQDemoDate"))
    '            Else
    '                objDataRow("DemoDate") = DateTime.Today
    '            End If
    '            If IsDBNull(objReader.Item("OQVerifiedDate")) = False Then
    '                objDataRow("VerifiedDate") = CDate(objReader.Item("OQVerifiedDate"))
    '            Else
    '                objDataRow("VerifiedDate") = DateTime.Today
    '            End If
    '            objDataRow("TestID") = testID

    '            objDataTable.Rows.Add(objDataRow)
    '        End While
    '        objReader.Close()
    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        'Error logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = "Error in Getting Test Records."
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

    Private Sub subFormatDataGrid(ByRef objGridTableStyle As DataGridTableStyle, ByRef dg As DataGrid, ByVal objDataTable As DataTable)
        Dim objTextColumn As DataGridTextBoxColumn
        Dim objDataView As New DataView
        Try
            dg.TableStyles.Clear()
            objDataView.Table = objDataTable
            objDataView.AllowNew = False
            dg.DataSource = objDataView
            'dg.ReadOnly = False

            objGridTableStyle.PreferredRowHeight = 48 '5.4.2010 by dinesh wagh

            objGridTableStyle.RowHeadersVisible = False
            objGridTableStyle.ResetAlternatingBackColor()
            objGridTableStyle.ResetBackColor()
            objGridTableStyle.ResetForeColor()
            objGridTableStyle.ResetGridLineColor()
            objGridTableStyle.BackColor = Color.AliceBlue
            objGridTableStyle.GridLineColor = Color.Black
            objGridTableStyle.HeaderBackColor = Color.FromArgb(205, 225, 250)
            objGridTableStyle.HeaderForeColor = Color.Black
            objGridTableStyle.AlternatingBackColor = Color.AliceBlue
            objGridTableStyle.AllowSorting = False

            objGridTableStyle.MappingName = objDataTable.TableName

            objTextColumn = New DataGridTextBoxColumn
            objTextColumn.TextBox.WordWrap = True '5.4.2010 by dinesh wagh
            objTextColumn.MappingName = "TestName"
            objTextColumn.HeaderText = "Test"
            objTextColumn.Width = 228
            objTextColumn.ReadOnly = True
            objTextColumn.NullText = ""
            objGridTableStyle.GridColumnStyles.Add(objTextColumn)

            objTextColumn = New DataGridTextBoxColumn
            objTextColumn.TextBox.WordWrap = True '5.4.2010 by dinesh wagh
            objTextColumn.MappingName = "Observation"
            objTextColumn.HeaderText = "Observation"
            objTextColumn.Width = 175
            objTextColumn.ReadOnly = False
            objTextColumn.NullText = ""
            objGridTableStyle.GridColumnStyles.Add(objTextColumn)

            objTextColumn = New DataGridTextBoxColumn
            objTextColumn.MappingName = "DemoDate"
            objTextColumn.HeaderText = "Demo.Date"
            objTextColumn.Width = 80
            objTextColumn.Format = "dd-MMM-yyyy"
            objTextColumn.ReadOnly = False
            objTextColumn.NullText = ""
            objGridTableStyle.GridColumnStyles.Add(objTextColumn)

            objTextColumn = New DataGridTextBoxColumn
            objTextColumn.MappingName = "VerifiedDate"
            objTextColumn.HeaderText = "Verified Date"
            objTextColumn.Width = 80
            objTextColumn.Format = "dd-MMM-yyyy"
            objTextColumn.ReadOnly = False
            objTextColumn.NullText = ""
            objGridTableStyle.GridColumnStyles.Add(objTextColumn)

            objTextColumn = New DataGridTextBoxColumn
            objTextColumn.MappingName = "TestID"
            objTextColumn.HeaderText = "TestID"
            objTextColumn.Width = 0
            objTextColumn.ReadOnly = True
            objTextColumn.NullText = ""
            objGridTableStyle.GridColumnStyles.Add(objTextColumn)

            objGridTableStyle.GridLineColor = Color.Black
            dg.TableStyles.Add(objGridTableStyle)

        Catch ex As Exception
            '---------------------------------------------------------
            'Error logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = "Error in Formating Test Data-Grid."
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

    Public Function funcSaveOQTest2Data(ByVal testnos As Integer) As Boolean
        '=====================================================================
        ' Procedure Name        :   funcSaveOQTest2Data
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

        Dim intTestID, temp_cnt, intTestStartID, intTestEndID As Integer
        Dim strObservation As String
        Dim dtDemo, dtVerified As DateTime
        Dim status As Boolean = True

        Try
            Select Case testnos
                Case ENUM_TestNos.TestNo1
                    intTestStartID = CONST_Test1StartID
                    intTestEndID = CONST_Test1EndID

                Case ENUM_TestNos.TestNo2
                    intTestStartID = CONST_Test2StartID
                    intTestEndID = CONST_Test2EndID

                Case ENUM_TestNos.TestNo3
                    intTestStartID = CONST_Test3StartID
                    intTestEndID = CONST_Test3EndID

                Case Else
                    intTestStartID = 0
                    intTestEndID = 0
            End Select

            For temp_cnt = intTestStartID To intTestEndID
                intTestID = temp_cnt
                strObservation = funcGetObservationFromControls(intTestID, testnos)
                dtDemo = funcGetDemoDateFromControls(intTestID, testnos)
                dtVerified = funcGetVerifiedDateFromControls(intTestID, testnos)
                status = gobjDataAccess.funcUpdateOQTest1Data(intTestID, strObservation, dtDemo, dtVerified)
                If Not (status) Then
                    Throw New Exception("Error in Updating Test Details.")
                End If
            Next

        Catch ex As Exception
            '---------------------------------------------------------
            'Error logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = "Error in Saving Test Details."
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

    Private Function funcGetObservationFromControls(ByVal testID As Integer, ByVal testnos As Integer) As String
        '=====================================================================
        ' Procedure Name        :   funcAssignValues
        ' Description           :   To Get values from text box controls on form. 
        ' Purpose               :   To Get values from text box controls on form. 
        ' Parameters Passed     :   None.
        ' Returns               :   None.
        ' Parameters Affected   :   None.
        ' Assumptions           :
        ' Dependencies          :
        ' Author                :   
        ' Created               :   January, 2003 
        ' Revisions             :
        '=====================================================================
        Dim strObservation As String
        Dim objDataRow As DataRow

        Try
            Select Case testnos
                Case ENUM_TestNos.TestNo1
                    For Each objDataRow In mobjTest1DataTable.Rows
                        If (objDataRow.ItemArray.GetValue(mobjTest1DataTable.Columns("TestID").Ordinal) = testID) Then
                            If IsDBNull(objDataRow.ItemArray.GetValue(mobjTest1DataTable.Columns("Observation").Ordinal)) = False Then
                                strObservation = objDataRow.ItemArray.GetValue(mobjTest1DataTable.Columns("Observation").Ordinal)
                                strObservation = strObservation.Replace(vbCrLf, " ") '29.6.2010 by dinesh wagh
                                Exit For
                            Else
                                strObservation = ""
                            End If
                        End If
                    Next
                Case ENUM_TestNos.TestNo2
                    For Each objDataRow In mobjTest2DataTable.Rows
                        If (objDataRow.ItemArray.GetValue(mobjTest2DataTable.Columns("TestID").Ordinal) = testID) Then
                            If IsDBNull(objDataRow.ItemArray.GetValue(mobjTest2DataTable.Columns("Observation").Ordinal)) = False Then
                                strObservation = objDataRow.ItemArray.GetValue(mobjTest2DataTable.Columns("Observation").Ordinal)
                                strObservation = strObservation.Replace(vbCrLf, " ") '29.6.2010 by dinesh wagh
                                Exit For
                            Else
                                strObservation = ""
                            End If
                        End If
                    Next
                Case ENUM_TestNos.TestNo3
                    For Each objDataRow In mobjTest3DataTable.Rows
                        If (objDataRow.ItemArray.GetValue(mobjTest3DataTable.Columns("TestID").Ordinal) = testID) Then
                            If IsDBNull(objDataRow.ItemArray.GetValue(mobjTest3DataTable.Columns("Observation").Ordinal)) = False Then
                                strObservation = objDataRow.ItemArray.GetValue(mobjTest3DataTable.Columns("Observation").Ordinal)
                                strObservation = strObservation.Replace(vbCrLf, " ") '29.6.2010 by dinesh wagh
                                Exit For
                            Else
                                strObservation = ""
                            End If
                        End If
                    Next
                Case Else
            End Select
        Catch ex As Exception
            '---------------------------------------------------------
            '--- Error logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = "Error in Getting Test Observation Details."
            gobjErrorHandler.WriteErrorLog(ex)
            Return ""
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            '--- Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------
        End Try

        Return strObservation
    End Function

    Private Function funcGetDemoDateFromControls(ByVal testID As Integer, ByVal testnos As Integer) As Date
        '=====================================================================
        ' Procedure Name        :   funcGetDemoDateFromControls
        ' Description           :   To Get values from Date Time Picker controls on form. 
        ' Purpose               :   To Get values from Date Time Picker controls on form. 
        ' Parameters Passed     :   None.
        ' Returns               :   None.
        ' Parameters Affected   :   None.
        ' Assumptions           :
        ' Dependencies          :
        ' Author                :   
        ' Created               :   January, 2003 
        ' Revisions             :
        '=====================================================================
        Dim dtDemo As Date
        Dim objDataRow As DataRow

        Try
            Select Case testnos
                Case ENUM_TestNos.TestNo1
                    For Each objDataRow In mobjTest1DataTable.Rows
                        If (objDataRow.ItemArray.GetValue(mobjTest1DataTable.Columns("TestID").Ordinal) = testID) Then
                            If IsDBNull(objDataRow.ItemArray.GetValue(mobjTest1DataTable.Columns("DemoDate").Ordinal)) = False Then
                                dtDemo = objDataRow.ItemArray.GetValue(mobjTest1DataTable.Columns("DemoDate").Ordinal)
                                Exit For
                            Else
                                dtDemo = DateTime.Today
                            End If
                        End If
                    Next
                Case ENUM_TestNos.TestNo2
                    For Each objDataRow In mobjTest2DataTable.Rows
                        If (objDataRow.ItemArray.GetValue(mobjTest2DataTable.Columns("TestID").Ordinal) = testID) Then
                            If IsDBNull(objDataRow.ItemArray.GetValue(mobjTest2DataTable.Columns("DemoDate").Ordinal)) = False Then
                                dtDemo = objDataRow.ItemArray.GetValue(mobjTest2DataTable.Columns("DemoDate").Ordinal)
                                Exit For
                            Else
                                dtDemo = DateTime.Today
                            End If
                        End If
                    Next
                Case ENUM_TestNos.TestNo3
                    For Each objDataRow In mobjTest3DataTable.Rows
                        If (objDataRow.ItemArray.GetValue(mobjTest3DataTable.Columns("TestID").Ordinal) = testID) Then
                            If IsDBNull(objDataRow.ItemArray.GetValue(mobjTest3DataTable.Columns("DemoDate").Ordinal)) = False Then
                                dtDemo = objDataRow.ItemArray.GetValue(mobjTest3DataTable.Columns("DemoDate").Ordinal)
                                Exit For
                            Else
                                dtDemo = DateTime.Today
                            End If
                        End If
                    Next
                Case Else
            End Select
        Catch ex As Exception
            '---------------------------------------------------------
            '--- Error logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = "Error in Getting Test Demonstrated Date Details."
            gobjErrorHandler.WriteErrorLog(ex)
            Return DateTime.Today
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            '--- Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------
        End Try
        Return dtDemo
    End Function

    Private Function funcGetVerifiedDateFromControls(ByVal testID As Integer, ByVal testnos As Integer) As Date
        '=====================================================================
        ' Procedure Name        :   funcGetVerifiedDateFromControls
        ' Description           :   To Get values from Date Time Picker controls on form. 
        ' Purpose               :   To Get values from Date Time Picker controls on form. 
        ' Parameters Passed     :   None.
        ' Returns               :   None.
        ' Parameters Affected   :   None.
        ' Assumptions           :
        ' Dependencies          :
        ' Author                :   
        ' Created               :   January, 2003 
        ' Revisions             :
        '=====================================================================
        Dim dtVerified As Date
        Dim objDataRow As DataRow

        Try
            Select Case testnos
                Case ENUM_TestNos.TestNo1
                    For Each objDataRow In mobjTest1DataTable.Rows
                        If (objDataRow.ItemArray.GetValue(mobjTest1DataTable.Columns("TestID").Ordinal) = testID) Then
                            If IsDBNull(objDataRow.ItemArray.GetValue(mobjTest1DataTable.Columns("VerifiedDate").Ordinal)) = False Then
                                dtVerified = objDataRow.ItemArray.GetValue(mobjTest1DataTable.Columns("VerifiedDate").Ordinal)
                                Exit For
                            Else
                                dtVerified = DateTime.Today
                            End If
                        End If
                    Next
                Case ENUM_TestNos.TestNo2
                    For Each objDataRow In mobjTest2DataTable.Rows
                        If (objDataRow.ItemArray.GetValue(mobjTest2DataTable.Columns("TestID").Ordinal) = testID) Then
                            If IsDBNull(objDataRow.ItemArray.GetValue(mobjTest2DataTable.Columns("VerifiedDate").Ordinal)) = False Then
                                dtVerified = objDataRow.ItemArray.GetValue(mobjTest2DataTable.Columns("VerifiedDate").Ordinal)
                                Exit For
                            Else
                                dtVerified = DateTime.Today
                            End If
                        End If
                    Next
                Case ENUM_TestNos.TestNo3
                    For Each objDataRow In mobjTest3DataTable.Rows
                        If (objDataRow.ItemArray.GetValue(mobjTest3DataTable.Columns("TestID").Ordinal) = testID) Then
                            If IsDBNull(objDataRow.ItemArray.GetValue(mobjTest3DataTable.Columns("VerifiedDate").Ordinal)) = False Then
                                dtVerified = objDataRow.ItemArray.GetValue(mobjTest3DataTable.Columns("VerifiedDate").Ordinal)
                                Exit For
                            Else
                                dtVerified = DateTime.Today
                            End If
                        End If
                    Next
                Case Else
            End Select
        Catch ex As Exception
            '---------------------------------------------------------
            '--- Error logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = "Error in Getting Test Verified Date Details."
            gobjErrorHandler.WriteErrorLog(ex)
            Return DateTime.Today
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            '--- Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------
        End Try
        Return dtVerified
    End Function

    'Private Function funcInsertOQTest2Data(ByVal intTestID As Integer, ByVal strTestName As String) As Boolean
    '    '=====================================================================
    '    ' Procedure Name        :   funcInsertOQTest2Data
    '    ' Description           :   To Add/Insert New Test Data in Database.
    '    ' Purpose               :   To Add/Insert New Test Data in Database.
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

    '        'Status = mclsDBFunctions.OpenConnection(mobjOleDBconnection)
    '        If Not (Status) Then
    '            Throw New Exception("Error in Opening Connection during Saving Test Details.")
    '        End If

    '        '---  Query for adding  data to Test
    '        str_sql = " Insert into OQTest " & _
    '                  " (OQTestID ,OQTestName) " & _
    '                  " values(?,?) "

    '        '--- Providing command object for Test
    '        With objCommand
    '            .Connection = mobjOleDBconnection
    '            .CommandType = CommandType.Text
    '            .CommandText = str_sql
    '            .Parameters.Add("OQTestID", OleDbType.Numeric).Value = intTestID
    '            .Parameters.Add("OQTestName", OleDbType.VarChar, 350).Value = strTestName
    '            .ExecuteNonQuery()
    '        End With

    '        objCommand.Dispose()
    '        Status = True

    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        '--- Error logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = "Error in Saving Test Details."
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

    'Private Function funcUpdateOQTest2Data(ByVal intTestID As Integer, ByVal strObservation As String, ByVal dtDemo As Date, ByVal dtVerified As Date) As Boolean
    '    '=====================================================================
    '    ' Procedure Name        :   funcUpdateOQTest2Data
    '    ' Description           :   To Update Test Data in Database.
    '    ' Purpose               :   To Update Test Data in Database.
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
    '        'Status = mclsDBFunctions.OpenConnection(mobjOleDBconnection)
    '        If Not (Status) Then
    '            Throw New Exception("Error in Opening Connection during Updating Test Details.")
    '        End If

    '        '---  Query to Update Data
    '        str_sql = " Update OQTest set " & _
    '                  " OQObservation = ? , OQDemoDate = ? ,OQVerifiedDate =? " & _
    '                  " where OQTestID = " & intTestID & " "

    '        '--- Providing command object 
    '        With objCommand
    '            .Connection = mobjOleDBconnection
    '            .CommandType = CommandType.Text
    '            .CommandText = str_sql
    '            .Parameters.Add("OQObservation", OleDbType.VarChar, 250).Value = strObservation
    '            .Parameters.Add("OQDemoDate", OleDbType.DBDate).Value = dtDemo
    '            .Parameters.Add("OQVerifiedDate", OleDbType.DBDate).Value = dtVerified
    '            .ExecuteNonQuery()
    '        End With

    '        objCommand.Dispose()
    '        Status = True

    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        '--- Error logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = "Error in Updating Test Details."
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

    'Private Function funcDeleteOQTest2Data(ByVal intTestID As Integer) As Boolean
    '    '=====================================================================
    '    ' Procedure Name        :   funcDeleteOQTest2Data
    '    ' Description           :   To Delete Test Data from Database.
    '    ' Purpose               :   To Delete Test Data from Database.
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
    '        'Status = mclsDBFunctions.OpenConnection(mobjOleDBconnection)
    '        If Not (Status) Then
    '            Throw New Exception("Error in Opening Connection during Deleting Test Details.")
    '        End If

    '        '--- Query to Delete from Database
    '        str_sql = " Delete * from OQTest where OQTestID = " & intTestID & " "

    '        'Status = mclsDBFunctions.AddORDeleteRecord(str_sql, mobjOleDBconnection)
    '        If (Status = False) Then
    '            MessageBox.Show("Problem in Deleting record")
    '        End If

    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        '--- Error logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = "Error in Deleting Test Details."
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

#Region "Constant Test Data"

    Private Function funcGetStdTestName(ByVal testNo As Integer) As String
        'try catch added by ; dinesh wagh on 3.2.2010
        Try
            Dim testName As String

            Select Case testNo
                Case 6
                    testName = "Preview Instrument initialisation process and baseline correction"
                Case 7
                    testName = "Preview main menu,setting and mode of operation ,Parameter setting for sub menu"
                Case 8
                    testName = "Preview setting and mode of operation of Accessories (if any)"
                Case 9
                    testName = "Preview troubleshooting and preventive maintenance procedure with service software"
                Case Else
                    testName = ""
            End Select

            Return testName

        Catch ex As Exception
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
        Finally
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
        End Try

    End Function

#End Region

    Private Sub dgTest1_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgTest1.CurrentCellChanged
        'try catch added by : dinesh wagh on 3.2.2010
        'code added by : dinesh wagh on 27.6.2010
        '-----------------------------------------------
        If mblnAvoidProcessing = True Then Exit Sub
        Dim intRowIndex, intColumnIndex As Integer
        Dim strString As String
        '-------------------------------------

        Try
            If Not (mblnModeLockStatus) Then
                If ((dgTest1.CurrentCell.ColumnNumber = CONST_DemoColumnNo) Or (dgTest1.CurrentCell.ColumnNumber = CONST_VerifyColumnNo)) Then
                    mdtpDate.Top = dgTest1.GetCurrentCellBounds().Top
                    mdtpDate.Left = dgTest1.GetCurrentCellBounds().Left
                    mdtpDate.Width = dgTest1.GetCurrentCellBounds().Width
                    mdtpDate.Height = dgTest1.GetCurrentCellBounds().Height
                    If (dgTest1.CurrentCell.RowNumber) > 0 Then
                        If IsDBNull(dgTest1(dgTest1.CurrentCell.RowNumber, dgTest1.CurrentCell.ColumnNumber)) = False Then
                            mdtpDate.Value = CDate(dgTest1(dgTest1.CurrentCell.RowNumber, dgTest1.CurrentCell.ColumnNumber))
                        Else
                            mdtpDate.Value = DateTime.Today
                        End If
                    End If
                    mdtpDate.Visible = True
                Else
                    mdtpDate.Width = 0
                    mdtpDate.Visible = False
                End If
            End If

            'code added by : dinesh wagh on 29.6.2010
            '---------------------------------------------------------------------------

            intRowIndex = dgTest1.CurrentCell.RowNumber
            intColumnIndex = dgTest1.CurrentCell.ColumnNumber


            mblnAvoidProcessing = True

            If Not IsDBNull(dgTest1.Item(mintRowIndex1, mintColumnIndex1)) Then
                If mintColumnIndex1 = CONST_COMMENT_COLUMN_NO Then
                    strString = dgTest1.Item(mintRowIndex1, mintColumnIndex1)
                    If Not (strString = "") Then
                        strString = strString.Replace(vbCrLf, " ")
                        dgTest1.Item(mintRowIndex1, mintColumnIndex1) = gfuncWordWrap(strString, 29)
                    End If
                End If
            End If

            dgTest1.CurrentCell = New DataGridCell(intRowIndex, intColumnIndex)

            mintRowIndex1 = dgTest1.CurrentCell.RowNumber
            mintColumnIndex1 = dgTest1.CurrentCell.ColumnNumber

            mblnAvoidProcessing = False
            '------------------------------------------------------------------------


        Catch ex As Exception
            mblnAvoidProcessing = False '29.6.2010 by dinesh wagh
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
        Finally
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
        End Try
    End Sub

    Private Sub dgTest2_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgTest2.CurrentCellChanged
        'try catch added by ; dinesh wagh on 3.2.2010
        'code added by : dinesh wagh on 27.6.2010
        '-----------------------------------------------
        If mblnAvoidProcessing = True Then Exit Sub
        Dim intRowIndex, intColumnIndex As Integer
        Dim strString As String
        '-------------------------------------


        Try
            If Not (mblnModeLockStatus) Then
                If ((dgTest2.CurrentCell.ColumnNumber = CONST_DemoColumnNo) Or (dgTest2.CurrentCell.ColumnNumber = CONST_VerifyColumnNo)) Then
                    mdtpDate2.Top = dgTest2.GetCurrentCellBounds().Top
                    mdtpDate2.Left = dgTest2.GetCurrentCellBounds().Left
                    mdtpDate2.Width = dgTest2.GetCurrentCellBounds().Width
                    mdtpDate2.Height = dgTest2.GetCurrentCellBounds().Height
                    If (dgTest2.CurrentCell.RowNumber) > 0 Then
                        If IsDBNull(dgTest2(dgTest2.CurrentCell.RowNumber, dgTest2.CurrentCell.ColumnNumber)) = False Then
                            mdtpDate2.Value = CDate(dgTest2(dgTest2.CurrentCell.RowNumber, dgTest2.CurrentCell.ColumnNumber))
                        Else
                            mdtpDate2.Value = DateTime.Today
                        End If
                    End If
                    mdtpDate2.Visible = True
                Else
                    mdtpDate2.Width = 0
                    mdtpDate2.Visible = False
                End If
            End If


            'code added by : dinesh wagh on 27.6.2010
            '---------------------------------------------------------------------------

            intRowIndex = dgTest2.CurrentCell.RowNumber
            intColumnIndex = dgTest2.CurrentCell.ColumnNumber


            mblnAvoidProcessing = True

            If Not IsDBNull(dgTest2.Item(mintRowIndex2, mintColumnIndex2)) Then
                If mintColumnIndex2 = CONST_COMMENT_COLUMN_NO Then
                    strString = dgTest2.Item(mintRowIndex2, mintColumnIndex2)
                    If Not (strString = "") Then
                        strString = strString.Replace(vbCrLf, " ")
                        dgTest2.Item(mintRowIndex2, mintColumnIndex2) = gfuncWordWrap(strString, 29)
                    End If
                End If
            End If

            dgTest2.CurrentCell = New DataGridCell(intRowIndex, intColumnIndex)

            mintRowIndex2 = dgTest2.CurrentCell.RowNumber
            mintColumnIndex2 = dgTest2.CurrentCell.ColumnNumber
            mblnAvoidProcessing = False
            '------------------------------------------------------------------------

        Catch ex As Exception
            mblnAvoidProcessing = False '29.6.2010 by dinesh wagh
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
        Finally
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
        End Try
    End Sub

    Private Sub dgTest3_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgTest3.CurrentCellChanged
        'try catch added by : dinesh wagh on 3.2.2010
        Try
            If Not (mblnModeLockStatus) Then
                If ((dgTest3.CurrentCell.ColumnNumber = CONST_DemoColumnNo) Or (dgTest3.CurrentCell.ColumnNumber = CONST_VerifyColumnNo)) Then
                    mdtpDate3.Top = dgTest3.GetCurrentCellBounds().Top
                    mdtpDate3.Left = dgTest3.GetCurrentCellBounds().Left
                    mdtpDate3.Width = dgTest3.GetCurrentCellBounds().Width
                    mdtpDate3.Height = dgTest3.GetCurrentCellBounds().Height
                    If (dgTest3.CurrentCell.RowNumber) > 0 Then
                        If IsDBNull(dgTest3(dgTest3.CurrentCell.RowNumber, dgTest3.CurrentCell.ColumnNumber)) = False Then
                            mdtpDate3.Value = CDate(dgTest3(dgTest3.CurrentCell.RowNumber, dgTest3.CurrentCell.ColumnNumber))
                        Else
                            mdtpDate3.Value = DateTime.Today
                        End If
                    End If
                    mdtpDate3.Visible = True
                Else
                    mdtpDate3.Width = 0
                    mdtpDate3.Visible = False
                End If
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
