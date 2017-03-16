Option Explicit On 
Imports System.Data
Imports System.Data.OleDb
Imports System.Windows.Forms.DataGridColumnStyle

Public Class frmPQTest2
    Inherits System.Windows.Forms.Form

#Region " Module level Declarations "
    'Private mstrOledbConnectionString As String
    'Private mobjOleDBconnection As OleDbConnection
    'Private gclsDBFunctions As New clsDatabaseFunctions
    Private objDataTable As New DataTable
    '====Saurabh====
    Private mblnModeLockStatus As Boolean
    Private mobjDataView As New DataView
    'Private mObjDataTable As DataTable
    Dim mdtpPQTest1Date As DateTimePicker
    Private Const CONST_DateColumnNo = 9
    Public Event Test_IQOQPQ_Attachment1(ByRef dtParameters As DataTable, ByVal intCounter As Integer)       'Saurabh  04.07.07
    Private intCounter As Integer = 0
    '====Saurabh====

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
    Friend WithEvents lblHeader1 As System.Windows.Forms.Label
    Friend WithEvents lblAttachment As System.Windows.Forms.Label
    Friend WithEvents lblTestName As System.Windows.Forms.Label
    Friend WithEvents lblMethod As System.Windows.Forms.Label
    Friend WithEvents lblPurpose As System.Windows.Forms.Label
    Friend WithEvents lblTestResults As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents dgMethod As System.Windows.Forms.DataGrid
    Friend WithEvents dgTest As System.Windows.Forms.DataGrid
    Friend WithEvents lblAcceptanceCriteria As System.Windows.Forms.Label
    Friend WithEvents lblSpecifiedBaselineResult As System.Windows.Forms.Label
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DataGridTextBoxColumn1 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblModelNo As System.Windows.Forms.Label
    Friend WithEvents btnTest As NETXP.Controls.XPButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmPQTest2))
        Me.lblTestResults = New System.Windows.Forms.Label
        Me.lblAttachment = New System.Windows.Forms.Label
        Me.lblMethod = New System.Windows.Forms.Label
        Me.lblPurpose = New System.Windows.Forms.Label
        Me.lblTestName = New System.Windows.Forms.Label
        Me.lblAcceptanceCriteria = New System.Windows.Forms.Label
        Me.lblHeader1 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.btnTest = New NETXP.Controls.XPButton
        Me.lblModelNo = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.lblSpecifiedBaselineResult = New System.Windows.Forms.Label
        Me.dgTest = New System.Windows.Forms.DataGrid
        Me.dgMethod = New System.Windows.Forms.DataGrid
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle
        Me.DataGridTextBoxColumn1 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.dgTest, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgMethod, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTestResults
        '
        Me.lblTestResults.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTestResults.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTestResults.Location = New System.Drawing.Point(8, 360)
        Me.lblTestResults.Name = "lblTestResults"
        Me.lblTestResults.Size = New System.Drawing.Size(120, 18)
        Me.lblTestResults.TabIndex = 18
        Me.lblTestResults.Text = "Test Results  :"
        '
        'lblAttachment
        '
        Me.lblAttachment.BackColor = System.Drawing.Color.AliceBlue
        Me.lblAttachment.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAttachment.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblAttachment.Location = New System.Drawing.Point(480, 40)
        Me.lblAttachment.Name = "lblAttachment"
        Me.lblAttachment.Size = New System.Drawing.Size(104, 20)
        Me.lblAttachment.TabIndex = 17
        Me.lblAttachment.Text = "Attachment I"
        '
        'lblMethod
        '
        Me.lblMethod.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMethod.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblMethod.Location = New System.Drawing.Point(8, 127)
        Me.lblMethod.Name = "lblMethod"
        Me.lblMethod.Size = New System.Drawing.Size(472, 18)
        Me.lblMethod.TabIndex = 12
        Me.lblMethod.Text = "Method             :     Follow the steps given below after clicking on 'Test' bu" & _
        "tton."
        '
        'lblPurpose
        '
        Me.lblPurpose.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPurpose.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblPurpose.Location = New System.Drawing.Point(8, 103)
        Me.lblPurpose.Name = "lblPurpose"
        Me.lblPurpose.Size = New System.Drawing.Size(328, 18)
        Me.lblPurpose.TabIndex = 11
        Me.lblPurpose.Text = "Purpose           :     To verify the system response."
        '
        'lblTestName
        '
        Me.lblTestName.AutoSize = True
        Me.lblTestName.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTestName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTestName.Location = New System.Drawing.Point(8, 79)
        Me.lblTestName.Name = "lblTestName"
        Me.lblTestName.Size = New System.Drawing.Size(489, 17)
        Me.lblTestName.TabIndex = 10
        Me.lblTestName.Text = "Test Name      :      Optimisation of AAS instrument with 5ppm Cu solution with A" & _
        "A flame."
        '
        'lblAcceptanceCriteria
        '
        Me.lblAcceptanceCriteria.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAcceptanceCriteria.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblAcceptanceCriteria.Location = New System.Drawing.Point(8, 328)
        Me.lblAcceptanceCriteria.Name = "lblAcceptanceCriteria"
        Me.lblAcceptanceCriteria.Size = New System.Drawing.Size(280, 16)
        Me.lblAcceptanceCriteria.TabIndex = 8
        Me.lblAcceptanceCriteria.Text = "Acceptance Criteria  : 5ppm Copper solution :"
        '
        'lblHeader1
        '
        Me.lblHeader1.BackColor = System.Drawing.Color.AliceBlue
        Me.lblHeader1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeader1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblHeader1.Location = New System.Drawing.Point(35, 7)
        Me.lblHeader1.Name = "lblHeader1"
        Me.lblHeader1.Size = New System.Drawing.Size(541, 18)
        Me.lblHeader1.TabIndex = 7
        Me.lblHeader1.Text = "E.II PERFORMANCE TESTING AND QUALIFICATION"
        Me.lblHeader1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.btnTest)
        Me.Panel1.Controls.Add(Me.lblModelNo)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.lblSpecifiedBaselineResult)
        Me.Panel1.Controls.Add(Me.dgTest)
        Me.Panel1.Controls.Add(Me.dgMethod)
        Me.Panel1.Controls.Add(Me.lblAttachment)
        Me.Panel1.Controls.Add(Me.lblTestName)
        Me.Panel1.Controls.Add(Me.lblPurpose)
        Me.Panel1.Controls.Add(Me.lblMethod)
        Me.Panel1.Controls.Add(Me.lblAcceptanceCriteria)
        Me.Panel1.Controls.Add(Me.lblTestResults)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(608, 510)
        Me.Panel1.TabIndex = 12
        '
        'btnTest
        '
        Me.btnTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTest.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnTest.Location = New System.Drawing.Point(264, 352)
        Me.btnTest.Name = "btnTest"
        Me.btnTest.Size = New System.Drawing.Size(104, 32)
        Me.btnTest.TabIndex = 32
        Me.btnTest.Text = "Test"
        '
        'lblModelNo
        '
        Me.lblModelNo.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblModelNo.Location = New System.Drawing.Point(184, 40)
        Me.lblModelNo.Name = "lblModelNo"
        Me.lblModelNo.Size = New System.Drawing.Size(112, 24)
        Me.lblModelNo.TabIndex = 31
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(192, 24)
        Me.Label1.TabIndex = 29
        Me.Label1.Text = "Equipment / Instrument :"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel2.Controls.Add(Me.PictureBox1)
        Me.Panel2.Controls.Add(Me.lblHeader1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(606, 32)
        Me.Panel2.TabIndex = 26
        Me.Panel2.TabStop = True
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
        'lblSpecifiedBaselineResult
        '
        Me.lblSpecifiedBaselineResult.AutoSize = True
        Me.lblSpecifiedBaselineResult.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSpecifiedBaselineResult.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblSpecifiedBaselineResult.Location = New System.Drawing.Point(257, 328)
        Me.lblSpecifiedBaselineResult.Name = "lblSpecifiedBaselineResult"
        Me.lblSpecifiedBaselineResult.Size = New System.Drawing.Size(297, 16)
        Me.lblSpecifiedBaselineResult.TabIndex = 25
        Me.lblSpecifiedBaselineResult.Text = "under optimized condition, it should produce Abs > 0.65"
        '
        'dgTest
        '
        Me.dgTest.BackgroundColor = System.Drawing.Color.AliceBlue
        Me.dgTest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.dgTest.CaptionVisible = False
        Me.dgTest.DataMember = ""
        Me.dgTest.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgTest.Location = New System.Drawing.Point(8, 392)
        Me.dgTest.Name = "dgTest"
        Me.dgTest.ParentRowsVisible = False
        Me.dgTest.ReadOnly = True
        Me.dgTest.RowHeadersVisible = False
        Me.dgTest.Size = New System.Drawing.Size(568, 100)
        Me.dgTest.TabIndex = 19
        '
        'dgMethod
        '
        Me.dgMethod.AllowNavigation = False
        Me.dgMethod.AllowSorting = False
        Me.dgMethod.AlternatingBackColor = System.Drawing.Color.AliceBlue
        Me.dgMethod.BackColor = System.Drawing.Color.AliceBlue
        Me.dgMethod.BackgroundColor = System.Drawing.Color.AliceBlue
        Me.dgMethod.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgMethod.CaptionVisible = False
        Me.dgMethod.ColumnHeadersVisible = False
        Me.dgMethod.DataMember = ""
        Me.dgMethod.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None
        Me.dgMethod.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgMethod.LinkColor = System.Drawing.Color.AliceBlue
        Me.dgMethod.Location = New System.Drawing.Point(8, 152)
        Me.dgMethod.Name = "dgMethod"
        Me.dgMethod.ParentRowsBackColor = System.Drawing.Color.AliceBlue
        Me.dgMethod.ParentRowsVisible = False
        Me.dgMethod.PreferredRowHeight = 14
        Me.dgMethod.ReadOnly = True
        Me.dgMethod.RowHeadersVisible = False
        Me.dgMethod.SelectionBackColor = System.Drawing.Color.AliceBlue
        Me.dgMethod.SelectionForeColor = System.Drawing.Color.AliceBlue
        Me.dgMethod.Size = New System.Drawing.Size(584, 168)
        Me.dgMethod.TabIndex = 18
        Me.dgMethod.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.AllowSorting = False
        Me.DataGridTableStyle1.AlternatingBackColor = System.Drawing.Color.AliceBlue
        Me.DataGridTableStyle1.BackColor = System.Drawing.Color.AliceBlue
        Me.DataGridTableStyle1.ColumnHeadersVisible = False
        Me.DataGridTableStyle1.DataGrid = Me.dgMethod
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DataGridTextBoxColumn1})
        Me.DataGridTableStyle1.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = ""
        Me.DataGridTableStyle1.PreferredColumnWidth = 535
        Me.DataGridTableStyle1.ReadOnly = True
        Me.DataGridTableStyle1.RowHeadersVisible = False
        Me.DataGridTableStyle1.SelectionBackColor = System.Drawing.Color.AliceBlue
        Me.DataGridTableStyle1.SelectionForeColor = System.Drawing.Color.AliceBlue
        '
        'DataGridTextBoxColumn1
        '
        Me.DataGridTextBoxColumn1.Format = ""
        Me.DataGridTextBoxColumn1.FormatInfo = Nothing
        Me.DataGridTextBoxColumn1.MappingName = ""
        Me.DataGridTextBoxColumn1.ReadOnly = True
        Me.DataGridTextBoxColumn1.Width = 535
        '
        'frmPQTest2
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(608, 424)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPQTest2"
        Me.Text = "PERFORMANCE QUALIFICATION TEST"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.dgTest, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgMethod, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Constants"
    Private Const ConstFuel As String = "Fuel"
    Private Const ConstSampleID As String = "SampleID"
    Private Const ConstTestName As String = "TestName"
    Private Const ConstWaveLength As String = "WaveLength"
    Private Const ConstAbsorbance As String = "Absorbance"
    Private Const ConstBurnerHeight As String = "BurnerHeight"
    Private Const ConstLampCurrent As String = "LampCurrent"
    Private Const ConstPMTVoltage As String = "PMTVoltage"
    Private Const ConstSlitWidth As String = "SlitWidth"
    Private Const ConstRemark As String = "Remark"
    Private Const ConstDate As String = "Date"

#End Region

#Region " Form Events "

    Private Sub frmPQTest2_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            '--- Initialize the UI
            Call funcInitialize()
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

    Private Sub frmPQTest2_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Try
            dgTest.CurrentCell() = (New DataGridCell(dgTest.CurrentRowIndex + 1, 0))
            If Not funcSavePQTest1Remarks() Then
                Throw New Exception("Error in Saving Test Data.")
            End If
            dgTest.TableStyles.Clear()

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

    Private Sub cmdPerformTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '--- Initialize the object
        'gobjValidationTest = New ValidationTestResults.ValidationTest

        '--- Perform the test and display the results on the screen
        'Call gsubPerfomTest(enumValidationTests.BaselineFlatnessTest)

        ''--- Save the result data in the database
        'Call funcUpdatePQTest1Data(enumValidationTests.BaselineFlatnessTest, _
        '                            gobjValidationTest.BaselineTest.Result, _
        '                            gobjValidationTest.BaselineTest.SpecifiedReading, "")

        ''--- Perform the test and display the results on the screen
        'Call gsubPerfomTest(enumValidationTests.NoiseTest)

        ''--- Save the result data in the database
        'Call funcUpdatePQTest1Data(enumValidationTests.NoiseTest, _
        '                            gobjValidationTest.NoiseTest.Result, _
        '                            gobjValidationTest.NoiseTest.SpecifiedReading, "")

        '--- Update the screen and results for the test.
        Call funcDisplayPQTest1()
    End Sub

#End Region

#Region " General Private functions "

    '--------------------------------------------------------
    '    General functions used for IQ Tests Listing.
    '--- funcInitialize - To Initialize form and to get values for PQ Tests List from database and display them.
    '--- funcGetPQTest2Records - To Get PQ Test Records from Database and display them.
    '--- funcGetPQTest2Details - To Get PQ Test Records from Database for the given ID.
    '--- funcAssignValuesToControls - To Assign values to controls on form. 
    '--- funcSavePQTest2Data - To Save the Entered Records into Database.
    '--- funcGetObservationFromControls - To Get values from text box controls on form. 
    '--- funcGetDemoDateFromControls - To Get values from Date Time Picker controls on form. 
    '--- funcGetVerifiedDateFromControls - To Get values from Date Time Picker controls on form. 
    '--- funcInsertPQTest2Data - To Add/Insert New Test Data in Database.
    '--- funcUpdatePQTest2Data - To Update PQ Test Data in Database.
    '--- funcDeletePQTest2Data - To Delete PQ Test Data from Database.
    '--- subCreateDataTable - To Create Columns in the Data Table.
    '--- subFormatDataGrid - To format the Data Grid Display Testing Procedure.

    Private Sub funcInitialize()
        '=====================================================================
        ' Procedure Name        :   funcInitailize
        ' Description           :   To Initialize form and to get values for PQ Tests List from database and display them.
        ' Purpose               :   To Initialize form and to get values for PQ Tests List from database and display them.
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

            'mobjDataTable = New DataTable("TestProcedure")
            'mobjTestDataTable = New DataTable("Test")
            'Added by Pankaj on 19 May 2007
            lblModelNo.Text = gobjModelNo
            '--- Display the Procedure for the test 
            Call subDisplayMethodInfo()

            '--- Display the result for the test
            Call funcDisplayPQTest1()

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

    Private Sub dtpCorrectiveDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        dgTest(dgTest.CurrentCell.RowNumber, dgTest.CurrentCell.ColumnNumber) = mdtpPQTest1Date.Value
    End Sub

    Private Sub subDisplayParameters()
        Try
            '--- Get thye parameters form the file
            'Call funcGetBaselineTestParameters(gobjValidationTest)

            ''--- Get thye parameters form the file
            'Call funcGetNoiseTestParameters(gobjValidationTest)

            'lblSpecifiedBaselineResult.Text = "+/-" & gobjValidationTest.BaselineTest.SpecifiedReading & " Abs"
            'lblSpecifiedNoiseTestResult.Text = "+/-" & gobjValidationTest.NoiseTest.SpecifiedReading & " Abs"

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

    Private Function funcDisplayPQTest1() As Boolean
        '=====================================================================
        ' Procedure Name        :   funcDisplayPQTest1
        ' Description           :   To Get PQ Test Records from Database and display them.
        ' Purpose               :   To Get PQ Test Records from Database and display them.
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
        'Dim objDataTable As DataTable
        Dim objDataRow As DataRow
        Dim intCount As Integer = 0
        Dim mobjTmpDt As New DataTable
        'Dim str_sql As String
        'Dim reader_status, record_exists As Boolean

        Try
            objDataTable = New DataTable("PQTest1Result")

            mdtpPQTest1Date = New DateTimePicker


            '--- To Add Run-Time DateTime Picker Control
            AddHandler mdtpPQTest1Date.ValueChanged, AddressOf dtpCorrectiveDate_ValueChanged
            dgTest.Controls.Add(mdtpPQTest1Date)
            mdtpPQTest1Date.Visible = False
            mdtpPQTest1Date.Format = DateTimePickerFormat.Custom
            mdtpPQTest1Date.CustomFormat = "dd-MMM-yyyy"


            'objDataTable.Columns.Add(New DataColumn("TestName", GetType(String)))
            objDataTable.Columns.Add(New DataColumn(ConstSampleID, GetType(Integer)))
            objDataTable.Columns.Add(New DataColumn(ConstAbsorbance, GetType(String)))
            objDataTable.Columns.Add(New DataColumn(ConstPMTVoltage, GetType(String)))
            objDataTable.Columns.Add(New DataColumn(ConstWaveLength, GetType(String)))
            objDataTable.Columns.Add(New DataColumn(ConstSlitWidth, GetType(String)))
            objDataTable.Columns.Add(New DataColumn(ConstBurnerHeight, GetType(String)))
            objDataTable.Columns.Add(New DataColumn(ConstFuel, GetType(String)))
            objDataTable.Columns.Add(New DataColumn(ConstLampCurrent, GetType(String)))
            objDataTable.Columns.Add(New DataColumn(ConstRemark, GetType(String)))
            objDataTable.Columns.Add(New DataColumn(ConstDate, GetType(String)))

            mobjTmpDt = gobjDataAccess.funcGetPQTest1Records()

            If Not mobjTmpDt Is Nothing Then
                If Not mobjTmpDt.Rows.Count = 0 Then
                    For intCount = 0 To mobjTmpDt.Rows.Count - 1
                        objDataRow = objDataTable.NewRow
                        objDataRow.Item(ConstSampleID) = mobjTmpDt.Rows.Item(intCount).Item(ConstSampleID)

                        If IsDBNull(mobjTmpDt.Rows.Item(intCount).Item(ConstLampCurrent)) = True Then
                            objDataRow.Item(ConstLampCurrent) = ""
                            'ElseIf Trim(mobjTmpDt.Rows.Item(intCount).Item(ConstLampCurrent)) = "" Then
                            '    objDataRow.Item(ConstLampCurrent) = ""
                        Else
                            'objDataRow.Item(ConstLampCurrent) = Format(CDbl(mobjTmpDt.Rows.Item(intCount).Item(ConstLampCurrent)), "0.0")
                            objDataRow.Item(ConstLampCurrent) = mobjTmpDt.Rows.Item(intCount).Item(ConstLampCurrent)
                        End If

                        If IsDBNull(mobjTmpDt.Rows.Item(intCount).Item(ConstPMTVoltage)) = True Then
                            objDataRow.Item(ConstPMTVoltage) = ""
                        Else
                            'objDataRow.Item(ConstPMTVoltage) = Format(CDbl(mobjTmpDt.Rows.Item(intCount).Item(ConstPMTVoltage)), "0.0")
                            objDataRow.Item(ConstPMTVoltage) = mobjTmpDt.Rows.Item(intCount).Item(ConstPMTVoltage)
                        End If

                        If IsDBNull(mobjTmpDt.Rows.Item(intCount).Item(ConstWaveLength)) = True Then
                            objDataRow.Item(ConstWaveLength) = ""
                        Else
                            'objDataRow.Item(ConstWaveLength) = Format(CDbl(mobjTmpDt.Rows.Item(intCount).Item(ConstWaveLength)), "0.0")
                            objDataRow.Item(ConstWaveLength) = mobjTmpDt.Rows.Item(intCount).Item(ConstWaveLength)
                        End If

                        If IsDBNull(mobjTmpDt.Rows.Item(intCount).Item(ConstSlitWidth)) = True Then
                            objDataRow.Item(ConstSlitWidth) = ""
                        Else
                            'objDataRow.Item(ConstSlitWidth) = Format(CDbl(mobjTmpDt.Rows.Item(intCount).Item(ConstSlitWidth)), "0.0")
                            objDataRow.Item(ConstSlitWidth) = mobjTmpDt.Rows.Item(intCount).Item(ConstSlitWidth)
                        End If

                        If IsDBNull(mobjTmpDt.Rows.Item(intCount).Item(ConstFuel)) = True Then
                            objDataRow.Item(ConstFuel) = ""
                        Else
                            'objDataRow.Item(ConstFuel) = Format(CDbl(mobjTmpDt.Rows.Item(intCount).Item(ConstFuel)), "0.00")
                            objDataRow.Item(ConstFuel) = mobjTmpDt.Rows.Item(intCount).Item(ConstFuel)
                        End If

                        If IsDBNull(mobjTmpDt.Rows.Item(intCount).Item(ConstAbsorbance)) = True Then
                            objDataRow.Item(ConstAbsorbance) = ""
                        Else
                            'objDataRow.Item(ConstAbsorbance) = Format(CDbl(mobjTmpDt.Rows.Item(intCount).Item(ConstAbsorbance)), "0.000")
                            objDataRow.Item(ConstAbsorbance) = mobjTmpDt.Rows.Item(intCount).Item(ConstAbsorbance)
                        End If

                        If IsDBNull(mobjTmpDt.Rows.Item(intCount).Item(ConstBurnerHeight)) = True Then
                            objDataRow.Item(ConstBurnerHeight) = ""
                        Else
                            'objDataRow.Item(ConstBurnerHeight) = Format(CDbl(mobjTmpDt.Rows.Item(intCount).Item(ConstBurnerHeight)), "0.0")
                            objDataRow.Item(ConstBurnerHeight) = mobjTmpDt.Rows.Item(intCount).Item(ConstBurnerHeight)
                        End If

                        If IsDBNull(mobjTmpDt.Rows.Item(intCount).Item(ConstRemark)) = True Then
                            objDataRow.Item(ConstRemark) = ""
                        Else
                            objDataRow.Item(ConstRemark) = mobjTmpDt.Rows.Item(intCount).Item(ConstRemark)
                        End If

                        If IsDBNull(mobjTmpDt.Rows.Item(intCount).Item(ConstDate)) = True Then
                            objDataRow.Item(ConstDate) = ""
                        Else
                            objDataRow.Item(ConstDate) = mobjTmpDt.Rows.Item(intCount).Item(ConstDate)
                        End If

                        objDataTable.Rows.Add(objDataRow)
                    Next
                End If
            End If

            If IsNothing(objDataTable) = True Then
                Throw New Exception("Error in Getting Equipment List Records.")
            Else
                Call subFormatTestDataGrid()
            End If

            'str_sql = "Select * from PQTest where PQTestID = " & enumPQTest.PQ_Test1

            'If Not gclsDBFunctions.GetRecords(str_sql, gOleDBIQOQPQConnection, objReader) Then
            '    Return True
            'End If

            'While objReader.Read
            '    objDataRow = objDataTable.NewRow()

            '    If IsDBNull(objReader.Item("PQTestName")) = False Then
            '        objDataRow("TestName") = CStr(objReader.Item("PQTestName"))
            '    End If
            '    If IsDBNull(objReader.Item("PQAbsorbance")) = False Then
            '        objDataRow("Result") = Format(Val(objReader.Item("PQAbsorbance")), "#0.0000")
            '    End If
            '    If IsDBNull(objReader.Item("PQCriteria")) = False Then
            '        objDataRow("Criteria") = "±" & Format(Val(objReader.Item("PQCriteria")), "#0.0000")
            '    End If
            '    If IsDBNull(objReader.Item("PQComments")) = False Then
            '        objDataRow("Comments") = CStr(objReader.Item("PQComments"))
            '    End If
            '    objDataRow("TestID") = Val(objReader.Item("ValidationTestID") & "")

            '    objDataTable.Rows.Add(objDataRow)
            'End While

            'objReader.Close()

            '--- Display the data in the grid
            'Call subFormatTestDataGrid(objDataTable)

            If gobjDataAccess.funcCheckModeLocked(ENUM_IQOQPQ_STATUS.PQ) Then
                dgTest.ReadOnly = True
                btnTest.Enabled = False 'Added by Pankaj on 6.12.07
            Else
                dgTest.ReadOnly = False
                btnTest.Enabled = True
            End If

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

    Private Sub subFormatTestDataGrid()
        Dim objTextColumn As DataGridTextBoxColumn
        Dim objDataView As New DataView
        Dim objTestGridTableStyle As New DataGridTableStyle

        Try
            dgTest.TableStyles.Clear()
            objDataView.Table = objDataTable
            objDataView.AllowNew = False
            dgTest.DataSource = objDataView

            objTestGridTableStyle.RowHeadersVisible = False
            objTestGridTableStyle.ResetAlternatingBackColor()
            objTestGridTableStyle.ResetBackColor()
            objTestGridTableStyle.ResetForeColor()
            objTestGridTableStyle.ResetGridLineColor()
            objTestGridTableStyle.BackColor = Color.AliceBlue
            objTestGridTableStyle.GridLineColor = Color.SandyBrown
            objTestGridTableStyle.HeaderBackColor = Color.FromArgb(205, 225, 250)
            objTestGridTableStyle.HeaderForeColor = Color.Black
            objTestGridTableStyle.AlternatingBackColor = Color.AliceBlue
            objTestGridTableStyle.AllowSorting = False

            objTestGridTableStyle.MappingName = "PQTest1Result"
            objTextColumn = New DataGridTextBoxColumn
            objTextColumn.MappingName = ConstSampleID
            objTextColumn.HeaderText = "Sr. No."
            objTextColumn.Width = 50
            objTextColumn.ReadOnly = True
            objTextColumn.NullText = ""
            objTextColumn.Alignment = HorizontalAlignment.Center
            objTestGridTableStyle.GridColumnStyles.Add(objTextColumn)

            objTextColumn = New DataGridTextBoxColumn
            objTextColumn.MappingName = ConstLampCurrent
            objTextColumn.HeaderText = "Lamp current"  'ConstLampCurrent
            objTextColumn.Width = 85
            objTextColumn.ReadOnly = False
            objTextColumn.NullText = ""
            objTextColumn.Alignment = HorizontalAlignment.Center
            objTestGridTableStyle.GridColumnStyles.Add(objTextColumn)

            objTextColumn = New DataGridTextBoxColumn
            objTextColumn.MappingName = ConstAbsorbance
            objTextColumn.HeaderText = "Abs"
            objTextColumn.Width = 48
            objTextColumn.ReadOnly = False
            objTextColumn.NullText = ""
            objTextColumn.Alignment = HorizontalAlignment.Center
            objTestGridTableStyle.GridColumnStyles.Add(objTextColumn)

            objTextColumn = New DataGridTextBoxColumn
            objTextColumn.MappingName = ConstWaveLength
            objTextColumn.HeaderText = "Wavelength"
            objTextColumn.Width = 77
            objTextColumn.ReadOnly = False
            objTextColumn.NullText = ""
            objTextColumn.Alignment = HorizontalAlignment.Center
            objTestGridTableStyle.GridColumnStyles.Add(objTextColumn)

            objTextColumn = New DataGridTextBoxColumn
            objTextColumn.MappingName = ConstSlitWidth
            objTextColumn.HeaderText = "Slit width" 'ConstSlitWidth
            objTextColumn.Width = 60
            objTextColumn.ReadOnly = False
            objTextColumn.NullText = ""
            objTextColumn.Alignment = HorizontalAlignment.Center
            objTestGridTableStyle.GridColumnStyles.Add(objTextColumn)

            objTextColumn = New DataGridTextBoxColumn
            objTextColumn.MappingName = ConstBurnerHeight
            objTextColumn.HeaderText = "Burner height" 'ConstBurnerHeight
            objTextColumn.Width = 85
            objTextColumn.ReadOnly = False
            objTextColumn.NullText = ""
            objTextColumn.Alignment = HorizontalAlignment.Center
            objTestGridTableStyle.GridColumnStyles.Add(objTextColumn)

            objTextColumn = New DataGridTextBoxColumn
            objTextColumn.MappingName = ConstFuel
            objTextColumn.HeaderText = ConstFuel
            objTextColumn.Width = 45
            objTextColumn.ReadOnly = False
            objTextColumn.NullText = ""
            objTextColumn.Alignment = HorizontalAlignment.Center
            objTestGridTableStyle.GridColumnStyles.Add(objTextColumn)

            objTextColumn = New DataGridTextBoxColumn
            objTextColumn.MappingName = ConstPMTVoltage
            objTextColumn.HeaderText = "PMT voltage" 'ConstPMTVoltage
            objTextColumn.Width = 75
            objTextColumn.ReadOnly = False
            objTextColumn.NullText = ""
            objTextColumn.Alignment = HorizontalAlignment.Center
            objTestGridTableStyle.GridColumnStyles.Add(objTextColumn)


            objTextColumn = New DataGridTextBoxColumn
            objTextColumn.MappingName = ConstRemark
            objTextColumn.HeaderText = ConstRemark
            objTextColumn.Width = 80
            objTextColumn.ReadOnly = False
            objTextColumn.NullText = ""
            objTextColumn.Alignment = HorizontalAlignment.Center
            objTestGridTableStyle.GridColumnStyles.Add(objTextColumn)

            objTextColumn = New DataGridTextBoxColumn
            objTextColumn.MappingName = ConstDate
            objTextColumn.HeaderText = ConstDate
            objTextColumn.Width = 70
            'objTextColumn.Format = "dd-MMM-yyyy"
            objTextColumn.ReadOnly = False
            objTextColumn.NullText = ""
            objTextColumn.Alignment = HorizontalAlignment.Center
            objTestGridTableStyle.GridColumnStyles.Add(objTextColumn)


            'objTextColumn = New DataGridTextBoxColumn
            'objTextColumn.MappingName = "TestID"
            'objTextColumn.HeaderText = "TestID"
            'objTextColumn.Width = 0
            'objTextColumn.ReadOnly = True
            'objTextColumn.NullText = ""
            'objTestGridTableStyle.GridColumnStyles.Add(objTextColumn)

            objTestGridTableStyle.GridLineColor = Color.Black
            dgTest.TableStyles.Add(objTestGridTableStyle)

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

    Public Function funcSavePQTest1Remarks() As Boolean
        '=====================================================================
        ' Procedure Name        :   funcSavePQTest1Remarks
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
        Dim temp_cnt, intValidationTestID As Integer
        Dim strRemark, strSampleID As String
        Dim status As Boolean
        Dim strPMTVoltage, strWaveLength, strSlitWidth, strBurnerHeight, strAbsorbance, strLampCurrent, strFuel As String
        Dim strDate As String
        Dim objDataView As New DataView
        Try
            '--- Read the remarks from the grid and save in the database.
            'objDataView = dgTest.DataSource
            If objDataTable Is Nothing Then Return True
            If objDataTable.Rows.Count <= 0 Then Return True

            For temp_cnt = 0 To objDataTable.Rows.Count - 1

                'strSampleID = objDataTable.Rows(temp_cnt).ItemArray.GetValue(objDataTable.Columns.Item("SampleID").Ordinal) 'code commented by : dinesh wagh on 15.6.2010

                'code added by : dinesh wagh on 15.6.2010
                '------------
                If IsDBNull(objDataTable.Rows(temp_cnt).ItemArray.GetValue(objDataTable.Columns.Item("SampleID").Ordinal)) Then
                    Return True
                Else
                    strSampleID = objDataTable.Rows(temp_cnt).ItemArray.GetValue(objDataTable.Columns.Item("SampleID").Ordinal)
                End If
                '---------

                If IsDBNull(objDataTable.Rows(temp_cnt).ItemArray.GetValue(objDataTable.Columns.Item("Remark").Ordinal)) Then
                    strRemark = "OK"
                Else
                    strRemark = objDataTable.Rows(temp_cnt).ItemArray.GetValue(objDataTable.Columns.Item("Remark").Ordinal)
                End If

                If IsDBNull(objDataTable.Rows(temp_cnt).ItemArray.GetValue(objDataTable.Columns.Item("PMTVoltage").Ordinal)) Then
                    strPMTVoltage = ""
                Else
                    strPMTVoltage = objDataTable.Rows(temp_cnt).ItemArray.GetValue(objDataTable.Columns.Item("PMTVoltage").Ordinal)
                End If

                If IsDBNull(objDataTable.Rows(temp_cnt).ItemArray.GetValue(objDataTable.Columns.Item("WaveLength").Ordinal)) Then
                    strWaveLength = ""
                Else
                    strWaveLength = objDataTable.Rows(temp_cnt).ItemArray.GetValue(objDataTable.Columns.Item("WaveLength").Ordinal)
                End If

                If IsDBNull(objDataTable.Rows(temp_cnt).ItemArray.GetValue(objDataTable.Columns.Item("SlitWidth").Ordinal)) Then
                    strSlitWidth = ""
                Else
                    strSlitWidth = objDataTable.Rows(temp_cnt).ItemArray.GetValue(objDataTable.Columns.Item("SlitWidth").Ordinal)
                End If

                If IsDBNull(objDataTable.Rows(temp_cnt).ItemArray.GetValue(objDataTable.Columns.Item("BurnerHeight").Ordinal)) Then
                    strBurnerHeight = ""
                Else
                    strBurnerHeight = objDataTable.Rows(temp_cnt).ItemArray.GetValue(objDataTable.Columns.Item("BurnerHeight").Ordinal)
                End If

                If IsDBNull(objDataTable.Rows(temp_cnt).ItemArray.GetValue(objDataTable.Columns.Item("Fuel").Ordinal)) Then
                    strFuel = ""
                Else
                    strFuel = objDataTable.Rows(temp_cnt).ItemArray.GetValue(objDataTable.Columns.Item("Fuel").Ordinal)
                End If

                If IsDBNull(objDataTable.Rows(temp_cnt).ItemArray.GetValue(objDataTable.Columns.Item("LampCurrent").Ordinal)) Then
                    strLampCurrent = ""
                Else
                    strLampCurrent = objDataTable.Rows(temp_cnt).ItemArray.GetValue(objDataTable.Columns.Item("LampCurrent").Ordinal)
                End If

                If IsDBNull(objDataTable.Rows(temp_cnt).ItemArray.GetValue(objDataTable.Columns.Item("Absorbance").Ordinal)) Then
                    strAbsorbance = ""
                Else
                    strAbsorbance = objDataTable.Rows(temp_cnt).ItemArray.GetValue(objDataTable.Columns.Item("Absorbance").Ordinal)
                End If

                If IsDBNull(objDataTable.Rows(temp_cnt).ItemArray.GetValue(objDataTable.Columns.Item("Date").Ordinal)) Then
                    strDate = ""
                Else
                    strDate = objDataTable.Rows(temp_cnt).ItemArray.GetValue(objDataTable.Columns.Item("Date").Ordinal)
                End If

                status = gobjDataAccess.funcUpdatePQTest1Records(strRemark, strPMTVoltage, strWaveLength, strSlitWidth, strBurnerHeight, strAbsorbance, strFuel, strLampCurrent, strDate, strSampleID)
                If Not (status) Then
                    Throw New Exception("Error in Updating PQTest1 Record Details.")
                End If
                'Call funcUpdatePQTestRemark(Val(objDataView.Table.Rows.Item(temp_cnt).Item("TestID") & ""), CStr(objDataView.Table.Rows.Item(temp_cnt).Item("Comments") & ""))
            Next
            Return True
        Catch ex As Exception
            '---------------------------------------------------------
            'Error logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = "Error in Saving Test Details."
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
            Return False
        Finally
            '---------------------------------------------------------
            '--- Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------
        End Try

    End Function

    Private Function funcUpdatePQTest1Data(ByVal intValidationTestID As Integer, _
                                           ByVal strRemark As String, _
                                           ByVal intLampCurrent As Integer, _
                                           ByVal dblPMTVoltage As Double, _
                                           ByVal dblWaveLength As Double, _
                                           ByVal dblSlitWidth As Double, _
                                           ByVal dblBurnerHeight As Double, _
                                           ByVal intFuel As Integer, _
                                           ByVal dtDate As DateTime, _
                                           ByVal dblAbsorbance As Double) As Boolean
        '=====================================================================
        ' Procedure Name        :   funcUpdatePQTest1Data
        ' Description           :   To Add/Insert New Test Data in Database.
        ' Purpose               :   To Add/Insert New Test Data in Database.
        ' Parameters Passed     :   None.
        ' Returns               :   None.
        ' Parameters Affected   :   None.
        ' Assumptions           :
        ' Dependencies          :
        ' Author                :   Gitesh
        ' Created               :   January, 2003 
        ' Revisions             :
        '=====================================================================
        Dim str_sql As String
        Dim objCommand As New OleDbCommand
        Try

            'If Not gclsDBFunctions.OpenConnection(gOleDBIQOQPQConnection) Then
            '    Throw New Exception("Error in Opening Connection during Saving Test Details.")
            'End If

            '---  Query for adding  data to Test
            str_sql = " Update PQTest Set" & _
                      " PQAbsorbance=?,PQCriteria=?,PQComments=? " & _
                      " Time=?,DistBySoapRing=?,ActualAbsorbance=? " & _
                      " RT=?,Absorbance=?, Date=? " & _
                      " Where  ValidationTestID=? and PQTestID=?"

            '--- Providing command object for Test
            With objCommand
                '.Connection = gOleDBIQOQPQConnection
                .CommandType = CommandType.Text
                .CommandText = str_sql
                .Parameters.Add("PQAbsorbance", OleDbType.Integer).Value = intLampCurrent
                .Parameters.Add("PQCriteria", OleDbType.Double).Value = Format(dblBurnerHeight, "#0.0")
                .Parameters.Add("PQComments", OleDbType.VarChar, 250).Value = strRemark
                .Parameters.Add("Time", OleDbType.Double).Value = Format(dblWaveLength, "#0.0")
                .Parameters.Add("DistBySoapRing", OleDbType.Double).Value = Format(dblPMTVoltage, "#0.0")
                .Parameters.Add("ActualAbsorbance", OleDbType.Double).Value = Format(dblSlitWidth, "#0.00")
                .Parameters.Add("RT", OleDbType.Integer).Value = intFuel
                .Parameters.Add("Absorbance", OleDbType.Double).Value = Format(dblAbsorbance, "#0.00")
                .Parameters.Add("Date", OleDbType.Date).Value = Format(dtDate, "#dd-MMM-yyyy")
                .Parameters.Add("ValidationTestID", OleDbType.Numeric).Value = intValidationTestID
                .Parameters.Add("PQTestID", OleDbType.Numeric).Value = enumPQTest.PQ_Test1
                .ExecuteNonQuery()
            End With

            objCommand.Dispose()
            Return True

        Catch ex As Exception
            '---------------------------------------------------------
            '--- Error logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = "Error in Saving Test Details."
            gobjErrorHandler.WriteErrorLog(ex)
            Return False
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            '--- Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------
        End Try

    End Function

    Private Function funcUpdatePQTestRemark(ByVal intValidationTestID As Integer, _
                                        ByVal strRemark As String) As Boolean
        '=====================================================================
        ' Procedure Name        :   funcUpdatePQTestRemark
        ' Description           :   To Update Test Data in Database.
        ' Purpose               :   To Update Test Data in Database.
        ' Parameters Passed     :   None.
        ' Returns               :   None.
        ' Parameters Affected   :   None.
        ' Assumptions           :
        ' Dependencies          :
        ' Author                :   Gitesh
        ' Created               :   January, 2003 
        ' Revisions             :
        '=====================================================================
        Dim str_sql As String
        Dim objCommand As New OleDbCommand

        Try
            'If Not gclsDBFunctions.OpenConnection(gOleDBIQOQPQConnection) Then
            '    Throw New Exception("Error in Opening Connection during Updating Test Details.")
            'End If

            '---  Query to Update Data
            str_sql = " Update PQTest set " & _
                      " PQComments = ? " & _
                      " where ValidationTestID =" & intValidationTestID & " and PQTestID = " & enumPQTest.PQ_Test1 & " "

            '--- Providing command object 
            With objCommand
                '.Connection = gOleDBIQOQPQConnection
                .CommandType = CommandType.Text
                .CommandText = str_sql
                .Parameters.Add("PQComments", OleDbType.VarChar, 255).Value = strRemark
                .ExecuteNonQuery()
            End With

            objCommand.Dispose()
            Return True

        Catch ex As Exception
            '---------------------------------------------------------
            '--- Error logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = "Error in Updating Test Details."
            gobjErrorHandler.WriteErrorLog(ex)
            Return False
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            '--- Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------
        End Try

    End Function

    'Private Function funcDeletePQTest2Data(ByVal intTestID As Integer) As Boolean
    '    '=====================================================================
    '    ' Procedure Name        :   funcDeletePQTest2Data
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
    '        Status = mclsDBFunctions.OpenConnection(mobjOleDBconnection)
    '        If Not (Status) Then
    '            Throw New Exception("Error in Opening Connection during Deleting Test Details.")
    '        End If

    '        '--- Query to Delete from Database
    '        str_sql = " Delete * from PQTest1 where PQTestID = " & intTestID & " "

    '        Status = mclsDBFunctions.AddORDeleteRecord(str_sql, mobjOleDBconnection)
    '        If (Status = False) Then
    '            Throw New Exception("Error in Deleting Test Details.")
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

    Private Sub subDisplayMethodInfo()
        '=====================================================================
        ' Procedure Name        :   subDisplayMethodInfo
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
        Dim objDataRow As DataRow
        Dim objDataView As New DataView
        Dim objCADataTable As New DataTable

        Try
            objCADataTable = New DataTable("PQTest11")
            objCADataTable.Columns.Add(New DataColumn("Name", GetType(String)))

            '--- Format thge method grid
            Call subFormatDataGrid(objCADataTable)

            objDataRow = objCADataTable.NewRow()
            ''objDataRow("Name") = "1) Switch on instrument, load method for (lamp should be mounted on turret). "
            objDataRow("Name") = "1) Load or create method for Copper. "
            objCADataTable.Rows.Add(objDataRow)

            objDataRow = objCADataTable.NewRow()
            ''objDataRow("Name") = "2) Select 'Analysis' from menu, wavelength will be selected and latched."
            objDataRow("Name") = "2) Proceed for Analysis."
            objCADataTable.Rows.Add(objDataRow)

            objDataRow = objCADataTable.NewRow()
            ''objDataRow("Name") = "3) Switch on th Air-Acetylene flame. Aspirate blank and adjust zero."
            ''objDataRow("Name") = "3) With AA flame aspirate blank to set zero absorbance (± 0.002)." 'code commented by ; dinesh wagh on 24.2.2010
            objDataRow("Name") = "3) With AA flame aspirate blank to set zero absorbance." 'code added by ; dinesh wagh on 24.2.2010
            objCADataTable.Rows.Add(objDataRow)

            objDataRow = objCADataTable.NewRow()
            ''objDataRow("Name") = "4) Select manual optimisation. Aspirate 'ppm' of solution and observe absorbance."
            objDataRow("Name") = "4) In manual optimisation, Aspirate '5ppm' Copper solution and observe the absorbance reading."
            objCADataTable.Rows.Add(objDataRow)

            objDataRow = objCADataTable.NewRow()
            ''objDataRow("Name") = "5) Adjust burner height, horizontal position, angular position to get maximum absorbance"
            objDataRow("Name") = "5) Adjust height, horizontal position, angular position of the burner head to set maximum"
            objCADataTable.Rows.Add(objDataRow)

            objDataRow = objCADataTable.NewRow()
            objDataRow("Name") = "   absorbance value, if required adjust nebulizer also."
            objCADataTable.Rows.Add(objDataRow) 'code added by : dinesh wagh on 24.2.2010

            objDataRow = objCADataTable.NewRow()
            objDataRow("Name") = "6) After conducting the test and adjusting 5 ppm Cu to produce 0.65 abs, don't remove tube"
            objCADataTable.Rows.Add(objDataRow)

            objDataRow = objCADataTable.NewRow()
            objDataRow("Name") = "  from the solution and press return."
            objCADataTable.Rows.Add(objDataRow)

            'code commented by ; dinesh wagh on 15.2.2010
            '----------------------------------------------------
            ''objDataRow = objCADataTable.NewRow()
            ''objDataRow("Name") = "7) Conduct the test 3 times."
            ''objCADataTable.Rows.Add(objDataRow)
            '---------------------------------------------------

            Application.DoEvents()
            'objDataRow = objCADataTable.NewRow()
            'objDataRow("Name") = "6 Gently press the bulb of flow meter so that fine ring of soap should develop."
            'objCADataTable.Rows.Add(objDataRow)

            'objDataRow = objCADataTable.NewRow()
            'objDataRow("Name") = "7. Measure the distance travel by the soap ring against time using stopwatch."
            'objCADataTable.Rows.Add(objDataRow)

            dgMethod.DataSource = objCADataTable
            Application.DoEvents()

            '--- Display the specified values on the screen
            Call subDisplayParameters()

        Catch ex As Exception
            '---------------------------------------------------------
            'Error logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = "Error in Creating Test Method Data-Table."
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

    Private Sub subFormatDataGrid(ByRef objDataTable As DataTable)
        Dim objTextColumn As DataGridTextBoxColumn
        Dim objDataView As New DataView
        Dim objGridTableStyle As New DataGridTableStyle
        Try
            dgMethod.TableStyles.Clear()
            dgMethod.RowHeadersVisible = False
            dgMethod.CaptionVisible = False
            dgMethod.RowHeadersVisible = False
            dgMethod.ParentRowsVisible = False
            dgMethod.FlatMode = True
            dgMethod.BorderStyle = BorderStyle.None
            dgMethod.GridLineStyle = DataGridLineStyle.None
            objDataView.Table = objDataTable
            objDataView.AllowNew = False
            dgMethod.DataSource = objDataView
            dgMethod.ReadOnly = False

            objGridTableStyle.RowHeadersVisible = False
            objGridTableStyle.ResetAlternatingBackColor()
            objGridTableStyle.ResetBackColor()
            objGridTableStyle.ResetForeColor()
            objGridTableStyle.ResetGridLineColor()
            objGridTableStyle.BackColor = Color.AliceBlue
            objGridTableStyle.HeaderBackColor = Color.LightSkyBlue
            objGridTableStyle.HeaderForeColor = Color.Black
            objGridTableStyle.AlternatingBackColor = Color.AliceBlue
            objGridTableStyle.SelectionBackColor = Color.AliceBlue
            objGridTableStyle.SelectionForeColor = Color.AliceBlue
            objGridTableStyle.LinkColor = Color.AliceBlue
            objGridTableStyle.AllowSorting = False

            objGridTableStyle.MappingName = "PQTest11"

            objGridTableStyle.RowHeadersVisible = False
            objGridTableStyle.ColumnHeadersVisible = False
            objGridTableStyle.GridLineStyle = DataGridLineStyle.None

            objTextColumn = New DataGridTextBoxColumn
            objTextColumn.MappingName = "Name"
            objTextColumn.HeaderText = ""
            objTextColumn.Width = 535
            objTextColumn.ReadOnly = True
            objTextColumn.NullText = ""
            objGridTableStyle.GridColumnStyles.Add(objTextColumn)

            objGridTableStyle.GridLineColor = Color.LightBlue
            dgMethod.TableStyles.Add(objGridTableStyle)

        Catch ex As Exception
            '---------------------------------------------------------
            'Error logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = "Error in Formating Test Description - 1 Data-Grid."
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

#End Region

    Private Sub dgTest_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgTest.CurrentCellChanged
        'try catch added by ;dinesh wagh on 3.2.2010
        Try
            If Not (mblnModeLockStatus) Then
                objDataTable.Columns(0).ReadOnly = False

                If objDataTable.Rows.Count = 0 Then
                    objDataTable.Columns(0).DefaultValue = 1
                Else
                    dgTest.Item(dgTest.CurrentRowIndex, 0) = dgTest.CurrentRowIndex + 1
                End If

                objDataTable.Columns(0).ReadOnly = True
                If (dgTest.CurrentCell.ColumnNumber = CONST_DateColumnNo) Then
                    mdtpPQTest1Date.Top = dgTest.GetCurrentCellBounds().Top
                    mdtpPQTest1Date.Left = dgTest.GetCurrentCellBounds().Left
                    mdtpPQTest1Date.Width = dgTest.GetCurrentCellBounds().Width
                    mdtpPQTest1Date.Height = dgTest.GetCurrentCellBounds().Height
                    If (dgTest.CurrentCell.RowNumber) > 0 Then
                        If IsDBNull(dgTest(dgTest.CurrentCell.RowNumber, CONST_DateColumnNo)) = False Then
                            mdtpPQTest1Date.Value = CDate(dgTest(dgTest.CurrentCell.RowNumber, CONST_DateColumnNo))
                        Else
                            mdtpPQTest1Date.Value = DateTime.Today
                            dgTest(dgTest.CurrentCell.RowNumber, dgTest.CurrentCell.ColumnNumber) = mdtpPQTest1Date.Value
                        End If
                    Else
                        dgTest(dgTest.CurrentCell.RowNumber, dgTest.CurrentCell.ColumnNumber) = mdtpPQTest1Date.Value
                        '   mdtpCorrectiveDate.Value = DateTime.Today
                    End If
                    mdtpPQTest1Date.Visible = True
                Else
                    mdtpPQTest1Date.Width = 0
                    mdtpPQTest1Date.Visible = False
                End If
            End If

            If dgTest.CurrentRowIndex >= 10 Then
                mobjDataView.AllowNew = False
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

    Private Sub btnTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTest.Click
        '=====================================================================
        ' Procedure Name        : btnTest_Click
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : To communicate with the instrument and perform tests
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 04.07.07
        ' Revisions             : 
        '=====================================================================
        'Dim lblTestStatus As Label
        'Dim dtParameters As DataTable
        Try
            btnTest.Enabled = False
            If objDataTable.Rows.Count = 3 Then
                objDataTable.Rows.Clear()
                intCounter = 0
            End If
            If intCounter < 3 Then
                intCounter += 1
                RaiseEvent Test_IQOQPQ_Attachment1(objDataTable, intCounter)  ', dtParameters)
            Else
                intCounter = 1
                objDataTable.Rows.Clear()
                RaiseEvent Test_IQOQPQ_Attachment1(objDataTable, intCounter)  ', dtParameters)
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
            btnTest.Enabled = True
            '---------------------------------------------------------
        End Try
    End Sub

End Class
