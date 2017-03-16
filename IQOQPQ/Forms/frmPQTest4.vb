Option Explicit On 
Imports System.Data
Imports System.Data.OleDb
Imports System.Windows.Forms.DataGridColumnStyle

Public Class frmPQTest4
    Inherits System.Windows.Forms.Form

#Region " Module level Declarations "
    'Private mstrOledbConnectionString As String
    'Private mobjOleDBconnection As OleDbConnection
    'Private gclsDBFunctions As New clsDatabaseFunctions
    Private objDataTable As DataTable
    Private intCounter As Integer = 0       'Saurabh  09.07.07
    Public Event Test_IQOQPQ_AttachmentIII(ByRef dtParameters As DataTable, ByVal intCounter As Integer)       'Saurabh  09.07.07
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
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DataGridTextBoxColumn1 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lblAcceptance As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblModelNo As System.Windows.Forms.Label
    Friend WithEvents btnTest As NETXP.Controls.XPButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmPQTest4))
        Me.lblTestResults = New System.Windows.Forms.Label
        Me.lblAttachment = New System.Windows.Forms.Label
        Me.lblMethod = New System.Windows.Forms.Label
        Me.lblPurpose = New System.Windows.Forms.Label
        Me.lblTestName = New System.Windows.Forms.Label
        Me.lblHeader1 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label2 = New System.Windows.Forms.Label
        Me.btnTest = New NETXP.Controls.XPButton
        Me.lblModelNo = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblAcceptance = New System.Windows.Forms.Label
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
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
        Me.lblTestResults.Location = New System.Drawing.Point(8, 364)
        Me.lblTestResults.Name = "lblTestResults"
        Me.lblTestResults.Size = New System.Drawing.Size(120, 12)
        Me.lblTestResults.TabIndex = 18
        Me.lblTestResults.Text = "Observations  :"
        Me.lblTestResults.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAttachment
        '
        Me.lblAttachment.BackColor = System.Drawing.Color.AliceBlue
        Me.lblAttachment.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAttachment.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblAttachment.Location = New System.Drawing.Point(449, 40)
        Me.lblAttachment.Name = "lblAttachment"
        Me.lblAttachment.Size = New System.Drawing.Size(112, 20)
        Me.lblAttachment.TabIndex = 17
        Me.lblAttachment.Text = "Attachment III"
        '
        'lblMethod
        '
        Me.lblMethod.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMethod.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblMethod.Location = New System.Drawing.Point(8, 115)
        Me.lblMethod.Name = "lblMethod"
        Me.lblMethod.Size = New System.Drawing.Size(450, 18)
        Me.lblMethod.TabIndex = 12
        Me.lblMethod.Text = "Method             :     Follow the steps given below after clicking on 'Test' bu" & _
        "tton."
        '
        'lblPurpose
        '
        Me.lblPurpose.AutoSize = True
        Me.lblPurpose.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPurpose.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblPurpose.Location = New System.Drawing.Point(8, 91)
        Me.lblPurpose.Name = "lblPurpose"
        Me.lblPurpose.Size = New System.Drawing.Size(356, 17)
        Me.lblPurpose.TabIndex = 11
        Me.lblPurpose.Text = "Purpose          :     To verify the calibration graph for curve fitting."
        '
        'lblTestName
        '
        Me.lblTestName.AutoSize = True
        Me.lblTestName.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTestName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTestName.Location = New System.Drawing.Point(8, 67)
        Me.lblTestName.Name = "lblTestName"
        Me.lblTestName.Size = New System.Drawing.Size(516, 17)
        Me.lblTestName.TabIndex = 10
        Me.lblTestName.Text = "Test Name     :     Calibration graph plotting for Cu, in the range 1ppm - 5ppm u" & _
        "sing AA flame."
        '
        'lblHeader1
        '
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
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.btnTest)
        Me.Panel1.Controls.Add(Me.lblModelNo)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.lblAcceptance)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.dgTest)
        Me.Panel1.Controls.Add(Me.dgMethod)
        Me.Panel1.Controls.Add(Me.lblAttachment)
        Me.Panel1.Controls.Add(Me.lblTestName)
        Me.Panel1.Controls.Add(Me.lblPurpose)
        Me.Panel1.Controls.Add(Me.lblMethod)
        Me.Panel1.Controls.Add(Me.lblTestResults)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(574, 536)
        Me.Panel1.TabIndex = 12
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(146, 311)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(400, 40)
        Me.Label2.TabIndex = 35
        Me.Label2.Text = "In ratio metric method of curve fitting, the curve starts from origin and passes " & _
        "through all points on graph with minimum error."
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnTest
        '
        Me.btnTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTest.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnTest.Location = New System.Drawing.Point(168, 354)
        Me.btnTest.Name = "btnTest"
        Me.btnTest.Size = New System.Drawing.Size(104, 32)
        Me.btnTest.TabIndex = 34
        Me.btnTest.Text = "Test"
        '
        'lblModelNo
        '
        Me.lblModelNo.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblModelNo.Location = New System.Drawing.Point(184, 40)
        Me.lblModelNo.Name = "lblModelNo"
        Me.lblModelNo.Size = New System.Drawing.Size(112, 24)
        Me.lblModelNo.TabIndex = 33
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(192, 24)
        Me.Label1.TabIndex = 28
        Me.Label1.Text = "Equipment / Instrument : "
        '
        'lblAcceptance
        '
        Me.lblAcceptance.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAcceptance.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblAcceptance.Location = New System.Drawing.Point(8, 293)
        Me.lblAcceptance.Name = "lblAcceptance"
        Me.lblAcceptance.Size = New System.Drawing.Size(540, 24)
        Me.lblAcceptance.TabIndex = 27
        Me.lblAcceptance.Text = "Acceptance Criteria :     Calibration graph is non linear in most of the cases,"
        Me.lblAcceptance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel2.Controls.Add(Me.PictureBox1)
        Me.Panel2.Controls.Add(Me.lblHeader1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(572, 32)
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
        Me.dgTest.Size = New System.Drawing.Size(410, 130)
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
        Me.dgMethod.Location = New System.Drawing.Point(8, 136)
        Me.dgMethod.Name = "dgMethod"
        Me.dgMethod.ParentRowsBackColor = System.Drawing.Color.AliceBlue
        Me.dgMethod.ParentRowsVisible = False
        Me.dgMethod.PreferredRowHeight = 14
        Me.dgMethod.ReadOnly = True
        Me.dgMethod.RowHeadersVisible = False
        Me.dgMethod.SelectionBackColor = System.Drawing.Color.AliceBlue
        Me.dgMethod.SelectionForeColor = System.Drawing.Color.AliceBlue
        Me.dgMethod.Size = New System.Drawing.Size(568, 160)
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
        'frmPQTest4
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(574, 544)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPQTest4"
        Me.Text = "PERFORMANCE QUALIFICATION TEST"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.dgTest, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgMethod, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Constants"
    'Private Const ConstTestName As String = "TestName"
    'Private Const ConstSample As String = "Sample"
    Private Const ConstAbsorbance As String = "Absorbance"
    'Private Const ConstTime As String = "Time"
    'Private Const ConstResult As String = "Result"
    'Private Const ConstCriteria As String = "Criteria"
    'Private Const ConstComments As String = "Comments"
    Private Const ConstConcentration As String = "Concentration"
    Private Const ConstSampleID As String = "Standard No"


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

            objDataTable.Columns.Add(New DataColumn(ConstSampleID, GetType(Integer)))
            objDataTable.Columns.Add(New DataColumn(ConstAbsorbance, GetType(String)))
            objDataTable.Columns.Add(New DataColumn(ConstConcentration, GetType(String)))

            mobjTmpDt = gobjDataAccess.funcGetPQTest3Records()

            If Not mobjTmpDt Is Nothing Then
                If Not mobjTmpDt.Rows.Count = 0 Then
                    For intCount = 0 To mobjTmpDt.Rows.Count - 1
                        objDataRow = objDataTable.NewRow
                        objDataRow.Item(ConstSampleID) = mobjTmpDt.Rows.Item(intCount).Item(ConstSampleID)
                        objDataRow.Item(ConstAbsorbance) = mobjTmpDt.Rows.Item(intCount).Item(ConstAbsorbance)
                        objDataRow.Item(ConstConcentration) = mobjTmpDt.Rows.Item(intCount).Item(ConstConcentration)
                        objDataTable.Rows.Add(objDataRow)
                    Next
                End If
            End If

            If IsNothing(objDataTable) = True Then
                Throw New Exception("Error in Getting Equipment List Records.")
            Else
                Call subFormatTestDataGrid()
            End If

            If gobjDataAccess.funcCheckModeLocked(ENUM_IQOQPQ_STATUS.PQ) Then
                dgTest.ReadOnly = True
                btnTest.Enabled = False 'Added by Pankaj on 6.12.07
            Else
                dgTest.ReadOnly = False
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
            objTestGridTableStyle.GridLineColor = Color.Black
            objTestGridTableStyle.HeaderBackColor = Color.FromArgb(205, 225, 250)
            objTestGridTableStyle.HeaderForeColor = Color.Black
            objTestGridTableStyle.AlternatingBackColor = Color.AliceBlue
            objTestGridTableStyle.AllowSorting = False

            objTestGridTableStyle.MappingName = "PQTest1Result"

            objTextColumn = New DataGridTextBoxColumn
            objTextColumn.MappingName = ConstSampleID
            objTextColumn.HeaderText = ConstSampleID
            objTextColumn.Width = 130
            objTextColumn.ReadOnly = False
            objTextColumn.NullText = ""
            objTextColumn.Alignment = HorizontalAlignment.Center
            objTestGridTableStyle.GridColumnStyles.Add(objTextColumn)

            objTextColumn = New DataGridTextBoxColumn
            objTextColumn.MappingName = ConstAbsorbance
            objTextColumn.HeaderText = ConstAbsorbance
            objTextColumn.Width = 130
            objTextColumn.ReadOnly = False
            objTextColumn.NullText = ""
            objTextColumn.Alignment = HorizontalAlignment.Center
            objTestGridTableStyle.GridColumnStyles.Add(objTextColumn)

            objTextColumn = New DataGridTextBoxColumn
            objTextColumn.MappingName = ConstConcentration
            objTextColumn.HeaderText = ConstConcentration
            objTextColumn.Width = 130
            objTextColumn.ReadOnly = False
            objTextColumn.NullText = ""
            objTextColumn.Alignment = HorizontalAlignment.Center
            objTestGridTableStyle.GridColumnStyles.Add(objTextColumn)

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
        Dim temp_cnt, intSampleID As Integer
        'Dim strSampleID As String
        'Dim strComments As String
        Dim status As Boolean
        Dim strConcentration As String
        Dim strAbsorbance As String
        Dim objDataView As New DataView
        Dim strTemp As String
        Try
            '--- Read the remarks from the grid and save in the database.
            objDataView = dgTest.DataSource
            If objDataView.Table.Rows.Count <= 0 Then
                Return True
            End If

            For temp_cnt = 0 To objDataTable.Rows.Count - 1
                'intSampleID = objDataTable.Rows(temp_cnt).ItemArray.GetValue(objDataTable.Columns.Item("SampleID").Ordinal) '29.1.2010 by dinesh wagh
                intSampleID = objDataTable.Rows(temp_cnt).ItemArray.GetValue(objDataTable.Columns.Item("Standard No").Ordinal) '29.1.2010 by dinesh wagh

                'If IsDBNull(objDataTable.Rows(temp_cnt).ItemArray.GetValue(objDataTable.Columns.Item("SampleID").Ordinal)) Then
                '    intSample = 0
                'Else
                '    intSample = objDataTable.Rows(temp_cnt).ItemArray.GetValue(objDataTable.Columns.Item("Sample").Ordinal)
                'End If

                If IsDBNull(objDataTable.Rows(temp_cnt).ItemArray.GetValue(objDataTable.Columns.Item("Absorbance").Ordinal)) Then
                    strAbsorbance = ""
                Else
                    strAbsorbance = objDataTable.Rows(temp_cnt).ItemArray.GetValue(objDataTable.Columns.Item("Absorbance").Ordinal)
                End If

                If IsDBNull(objDataTable.Rows(temp_cnt).ItemArray.GetValue(objDataTable.Columns.Item("Concentration").Ordinal)) Then
                    strConcentration = ""
                Else
                    strConcentration = objDataTable.Rows(temp_cnt).ItemArray.GetValue(objDataTable.Columns.Item("Concentration").Ordinal)
                End If

                status = gobjDataAccess.funcUpdatePQTest3Records(intSampleID, strAbsorbance, strConcentration)
                If Not (status) Then
                    Throw New Exception("Error in Updating PQTest3 Record Details.")
                End If
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
                                        ByVal intSample As Integer, _
                                        ByVal intAbsorbance As Integer, _
                                        ByVal intConcentration As Integer) As Boolean
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
                      " PeakArea=?,RT=?,ActualAbsorbance=? " & _
                      " Where  ValidationTestID=? and PQTestID=?"

            '--- Providing command object for Test
            With objCommand
                '.Connection = gOleDBIQOQPQConnection
                .CommandType = CommandType.Text
                .CommandText = str_sql
                .Parameters.Add("PeakArea", OleDbType.Integer).Value = intSample
                .Parameters.Add("RT", OleDbType.Integer).Value = intAbsorbance
                .Parameters.Add("ActualAbsorbance", OleDbType.Integer).Value = intConcentration
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
                                        ByVal strComments As String) As Boolean
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
            str_sql = " Update PQTest1 set " & _
                      " PQComments = ? " & _
                      " where ValidationTestID =" & intValidationTestID & " and PQTestID = " & enumPQTest.PQ_Test1 & " "

            '--- Providing command object 
            With objCommand
                '.Connection = gOleDBIQOQPQConnection
                .CommandType = CommandType.Text
                .CommandText = str_sql
                .Parameters.Add("PQComments", OleDbType.VarChar, 255).Value = strComments
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
            objCADataTable = New DataTable("PQTest1")
            objCADataTable.Columns.Add(New DataColumn("Name", GetType(String)))

            '--- Format thge method grid
            Call subFormatDataGrid(objCADataTable)

            '================Modified by Saurabh========================

            'objDataRow = objCADataTable.NewRow()
            'objDataRow("Name") = "A. Chromatographic Condition - "
            'objCADataTable.Rows.Add(objDataRow)

            objDataRow = objCADataTable.NewRow()
            objDataRow("Name") = "1. Use solutions of different concentrations e.g. 1ppm, 2ppm, 3ppm, 4ppm, 5ppm standard."
            objCADataTable.Rows.Add(objDataRow)

            objDataRow = objCADataTable.NewRow()
            objDataRow("Name") = "2. Aspirate the solutions in ascending order i.e. 1ppm, 2ppm, etc."
            objCADataTable.Rows.Add(objDataRow)

            objDataRow = objCADataTable.NewRow()
            ''objDataRow("Name") = "3. The graph obtained should be linear passing through origin."
            objDataRow("Name") = "3. Calibration graph obtained is not linear curving towards x-axis from 4ppm onwards."
            objCADataTable.Rows.Add(objDataRow)

            objDataRow = objCADataTable.NewRow()
            objDataRow("Name") = "4. After conducting the test take printout of calibration graph"
            objCADataTable.Rows.Add(objDataRow)

            objDataRow = objCADataTable.NewRow()
            objDataRow("Name") = " and then return to have printout of complete IQOQPQ."
            objCADataTable.Rows.Add(objDataRow)

            'code added by ; dinesh wagh on 24.2.2010
            '----------------------------------------------------
            objDataRow = objCADataTable.NewRow
            objDataRow("Name") = "5. After completion of test please take printout of Calibration Graph from the standard"
            objCADataTable.Rows.Add(objDataRow)

            objDataRow = objCADataTable.NewRow
            objDataRow("Name") = "  graph window by clicking on print button & attach the document."
            objCADataTable.Rows.Add(objDataRow)
            '----------------------------------------------------

            'objDataRow = objCADataTable.NewRow()
            'objDataRow("Name") = "4. Detector         : FID."
            'objCADataTable.Rows.Add(objDataRow)

            'objDataRow = objCADataTable.NewRow()
            'objDataRow("Name") = "5. Injection Volume : 1.0 Micro-liter."
            'objCADataTable.Rows.Add(objDataRow)

            'objDataRow = objCADataTable.NewRow()
            'objDataRow("Name") = "6 Temperature       : Oven-80 °C., Injector-150 °C., Detector-180 °C."
            'objCADataTable.Rows.Add(objDataRow)

            'objDataRow = objCADataTable.NewRow()
            'objDataRow("Name") = "7. Range            : 1000 or 10^2."
            'objCADataTable.Rows.Add(objDataRow)

            'objDataRow = objCADataTable.NewRow()
            'objDataRow("Name") = "8. Attenuation      : 512."
            'objCADataTable.Rows.Add(objDataRow)

            'objDataRow = objCADataTable.NewRow()
            'objDataRow("Name") = ""
            'objCADataTable.Rows.Add(objDataRow)

            'objDataRow = objCADataTable.NewRow()
            'objDataRow("Name") = "B. Preparation of standard solution : Make 5% of benzene solution in toluene."
            'objCADataTable.Rows.Add(objDataRow)

            'objDataRow = objCADataTable.NewRow()
            'objDataRow("Name") = "C. Inject 0.5 Micro liter of std. solution 5 replicates and record the chromatograms."
            'objCADataTable.Rows.Add(objDataRow)

            'objDataRow = objCADataTable.NewRow()
            'objDataRow("Name") = "D. Calculate the % RSD of the retention times of benzene from the 5 replicate injection."
            'objCADataTable.Rows.Add(objDataRow)

            'objDataRow = objCADataTable.NewRow()
            'objDataRow("Name") = "E. Calculate the % RSD of the peak areas of benzene from the 5 replicate injection"
            'objCADataTable.Rows.Add(objDataRow)

            'objDataRow = objCADataTable.NewRow()
            'objDataRow("Name") = "F. Calculate the average peak area of benzene from the 5 replicate injection."
            'objCADataTable.Rows.Add(objDataRow)

            '==================Modified by Saurbah=================

            dgMethod.DataSource = objCADataTable

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

            objGridTableStyle.MappingName = "PQTest1"

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

#Region " Constant Test Data"


#End Region

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
        ' Created               : 07.07.07
        ' Revisions             : 
        '=====================================================================
        Try
            btnTest.Enabled = False

            'code commented by : dinesh wagh on 24.6.2010
            'To remove the previous result and to load fresh result we have to clear all rows.: suggested by V.C.K
            '---------------------------------------------
            'If objDataTable.Rows.Count = 5 Then
            '    objDataTable.Rows.Clear()
            '    intCounter = 0
            'End If
            'If intCounter < 5 Then
            '    intCounter += 1
            '    RaiseEvent Test_IQOQPQ_AttachmentIII(objDataTable, intCounter)  ', dtParameters)
            'Else
            '    intCounter = 1
            '    objDataTable.Rows.Clear()
            '    RaiseEvent Test_IQOQPQ_AttachmentIII(objDataTable, intCounter)  ', dtParameters)
            'End If
            '------------------------------------------------


            'code added by ; dinesh wagh on 24.6.2010
            'To remove the previous result as new fresh results to be loaded at new analysis.
            '-------------------------------------
            intCounter = 1
            objDataTable.Rows.Clear()
            RaiseEvent Test_IQOQPQ_AttachmentIII(objDataTable, intCounter)  ', dtParameters)
            '-------------------------------------




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
