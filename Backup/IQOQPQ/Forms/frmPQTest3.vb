Option Explicit On 
Imports System.Data
Imports System.Data.OleDb
Imports System.Windows.Forms.DataGridColumnStyle

Public Class frmPQTest3
    Inherits System.Windows.Forms.Form

#Region " Module level Declarations "
    'Private mstrOledbConnectionString As String
    'Private mobjOleDBconnection As OleDbConnection
    'Private gclsDBFunctions As New clsDatabaseFunctions
    Dim objDataTable As DataTable
    'Saurabh 07.07.07
    Public Event Test_IQOQPQ_AttachmentII(ByRef dtParameters As DataTable, ByVal intCounter As Integer)       'Saurabh  04.07.07
    Private intCounter As Integer = 0
    'Saurabh 07.07.07
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
    Friend WithEvents cmdPerformTest As System.Windows.Forms.Button
    Friend WithEvents lblAcceptanceCriteria As System.Windows.Forms.Label
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DataGridTextBoxColumn1 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblModelNo As System.Windows.Forms.Label
    Friend WithEvents btnTest As NETXP.Controls.XPButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmPQTest3))
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
        Me.cmdPerformTest = New System.Windows.Forms.Button
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
        Me.lblTestResults.Location = New System.Drawing.Point(8, 321)
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
        Me.lblAttachment.Location = New System.Drawing.Point(455, 40)
        Me.lblAttachment.Name = "lblAttachment"
        Me.lblAttachment.Size = New System.Drawing.Size(112, 20)
        Me.lblAttachment.TabIndex = 17
        Me.lblAttachment.Text = "Attachment II"
        '
        'lblMethod
        '
        Me.lblMethod.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMethod.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblMethod.Location = New System.Drawing.Point(8, 121)
        Me.lblMethod.Name = "lblMethod"
        Me.lblMethod.Size = New System.Drawing.Size(450, 18)
        Me.lblMethod.TabIndex = 12
        Me.lblMethod.Text = "Method         :  Follow the steps given below after clicking on 'Test' button."
        '
        'lblPurpose
        '
        Me.lblPurpose.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPurpose.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblPurpose.Location = New System.Drawing.Point(8, 97)
        Me.lblPurpose.Name = "lblPurpose"
        Me.lblPurpose.Size = New System.Drawing.Size(500, 18)
        Me.lblPurpose.TabIndex = 11
        Me.lblPurpose.Text = "Purpose       :  To find Cv (Coefficient of variance) & repeatability of Abs. val" & _
        "ue."
        '
        'lblTestName
        '
        Me.lblTestName.AutoSize = True
        Me.lblTestName.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTestName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTestName.Location = New System.Drawing.Point(8, 73)
        Me.lblTestName.Name = "lblTestName"
        Me.lblTestName.Size = New System.Drawing.Size(428, 17)
        Me.lblTestName.TabIndex = 10
        Me.lblTestName.Text = "Test Name  :  Cv (Coefficient of variance) and repeatability for Cu 5ppm Abs.."
        '
        'lblAcceptanceCriteria
        '
        Me.lblAcceptanceCriteria.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAcceptanceCriteria.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblAcceptanceCriteria.Location = New System.Drawing.Point(8, 291)
        Me.lblAcceptanceCriteria.Name = "lblAcceptanceCriteria"
        Me.lblAcceptanceCriteria.Size = New System.Drawing.Size(576, 18)
        Me.lblAcceptanceCriteria.TabIndex = 8
        Me.lblAcceptanceCriteria.Text = "Acceptance test: Repeatability of absorbance equal to ± 10 count and CV < 1 %"
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
        Me.Panel1.Controls.Add(Me.btnTest)
        Me.Panel1.Controls.Add(Me.lblModelNo)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.cmdPerformTest)
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
        Me.Panel1.Size = New System.Drawing.Size(591, 510)
        Me.Panel1.TabIndex = 12
        '
        'btnTest
        '
        Me.btnTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTest.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnTest.Location = New System.Drawing.Point(176, 315)
        Me.btnTest.Name = "btnTest"
        Me.btnTest.Size = New System.Drawing.Size(104, 32)
        Me.btnTest.TabIndex = 33
        Me.btnTest.Text = "Test"
        '
        'lblModelNo
        '
        Me.lblModelNo.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblModelNo.Location = New System.Drawing.Point(184, 40)
        Me.lblModelNo.Name = "lblModelNo"
        Me.lblModelNo.Size = New System.Drawing.Size(112, 24)
        Me.lblModelNo.TabIndex = 32
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(310, 24)
        Me.Label1.TabIndex = 29
        Me.Label1.Text = "Equipment / Instrument : "
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel2.Controls.Add(Me.PictureBox1)
        Me.Panel2.Controls.Add(Me.lblHeader1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(589, 32)
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
        'cmdPerformTest
        '
        Me.cmdPerformTest.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdPerformTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdPerformTest.Image = CType(resources.GetObject("cmdPerformTest.Image"), System.Drawing.Image)
        Me.cmdPerformTest.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdPerformTest.Location = New System.Drawing.Point(300, 311)
        Me.cmdPerformTest.Name = "cmdPerformTest"
        Me.cmdPerformTest.Size = New System.Drawing.Size(110, 37)
        Me.cmdPerformTest.TabIndex = 22
        Me.cmdPerformTest.Text = "&Start Test"
        Me.cmdPerformTest.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdPerformTest.Visible = False
        '
        'dgTest
        '
        Me.dgTest.BackgroundColor = System.Drawing.Color.AliceBlue
        Me.dgTest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.dgTest.CaptionVisible = False
        Me.dgTest.DataMember = ""
        Me.dgTest.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgTest.Location = New System.Drawing.Point(8, 351)
        Me.dgTest.Name = "dgTest"
        Me.dgTest.ParentRowsVisible = False
        Me.dgTest.ReadOnly = True
        Me.dgTest.RowHeadersVisible = False
        Me.dgTest.Size = New System.Drawing.Size(410, 100)
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
        Me.dgMethod.Size = New System.Drawing.Size(568, 136)
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
        'frmPQTest3
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(591, 456)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPQTest3"
        Me.Text = "PERFORMANCE QUALIFICATION TEST"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.dgTest, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgMethod, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Constants "
    'Private Const ConstSample As String = "Sample"
    Private Const ConstAbsorbance As String = "Absorbance"
    Private Const ConstDeviation As String = "Deviation"
    'Private Const ConstTestName As String = "TestName"
    'Private Const ConstSetTemp As String = "SetTemp"
    'Private Const ConstDistBySoapRing As String = "DistBySoapRing"
    'Private Const ConstTime As String = "Time"
    'Private Const ConstResult As String = "Result"
    'Private Const ConstParameters As String = "Parameters"
    'Private Const ConstComments As String = "Comments"
    Private Const ConstSampleID As String = "Repeat No"

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

    Private Sub cmdPerformTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPerformTest.Click
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
        Call funcDisplayPQTest2()
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
            Call funcDisplayPQTest2()

            dgTest.Visible = False 'code added by ; dinesh wagh on 29.1.2010


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

    Private Function funcDisplayPQTest2() As Boolean
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

            'objDataTable.Columns.Add(New DataColumn("TestName", GetType(String)))
            objDataTable.Columns.Add(New DataColumn(ConstSampleID, GetType(Integer)))
            objDataTable.Columns.Add(New DataColumn(ConstAbsorbance, GetType(String)))
            objDataTable.Columns.Add(New DataColumn(ConstDeviation, GetType(String)))
            'objDataTable.Columns.Add(New DataColumn("TestID", GetType(Integer)))

            mobjTmpDt = gobjDataAccess.funcGetPQTest2Records()

            If Not mobjTmpDt Is Nothing Then
                If Not mobjTmpDt.Rows.Count = 0 Then
                    For intCount = 0 To mobjTmpDt.Rows.Count - 1
                        objDataRow = objDataTable.NewRow
                        objDataRow.Item(ConstSampleID) = mobjTmpDt.Rows.Item(intCount).Item(ConstSampleID)
                        objDataRow.Item(ConstAbsorbance) = mobjTmpDt.Rows.Item(intCount).Item(ConstAbsorbance)
                        objDataRow.Item(ConstDeviation) = mobjTmpDt.Rows.Item(intCount).Item(ConstDeviation)
                        objDataTable.Rows.Add(objDataRow)
                    Next
                End If
            End If

            If IsNothing(objDataTable) = True Then
                Throw New Exception("Error in Getting Equipment List Records.")
            Else

                Call subFormatTestDataGrid()
            End If

            'str_sql = "Select * from PQTest1 where PQTestID = " & enumPQTest.PQ_Test1

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

            'objTextColumn = New DataGridTextBoxColumn
            'objTextColumn.MappingName = "TestName"
            'objTextColumn.HeaderText = "Performance Test"
            'objTextColumn.Width = 150
            'objTextColumn.ReadOnly = True
            'objTextColumn.NullText = ""
            'objTestGridTableStyle.GridColumnStyles.Add(objTextColumn)

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

            'objTextColumn = New DataGridTextBoxColumn
            'objTextColumn.MappingName = "DistBySoapRing"
            'objTextColumn.HeaderText = "Dist traveled By Soap Ring"
            'objTextColumn.Width = 130
            'objTextColumn.ReadOnly = False
            'objTextColumn.NullText = ""
            'objTestGridTableStyle.GridColumnStyles.Add(objTextColumn)

            'objTextColumn = New DataGridTextBoxColumn
            'objTextColumn.MappingName = "Time"
            'objTextColumn.HeaderText = "Time Required in minutes"
            'objTextColumn.Width = 130
            'objTextColumn.ReadOnly = False
            'objTextColumn.NullText = ""
            'objTestGridTableStyle.GridColumnStyles.Add(objTextColumn)

            objTextColumn = New DataGridTextBoxColumn
            objTextColumn.MappingName = ConstDeviation
            objTextColumn.HeaderText = "Deviation from std"
            objTextColumn.Width = 130
            objTextColumn.NullText = ""
            objTextColumn.Alignment = HorizontalAlignment.Center
            objTextColumn.ReadOnly = False
            objTestGridTableStyle.GridColumnStyles.Add(objTextColumn)

            '=================== By Saurabh=========================
            'objTextColumn = New DataGridTextBoxColumn
            'objTextColumn.MappingName = "Comments"
            'objTextColumn.HeaderText = "Remarks"
            'objTextColumn.Width = 150
            'objTextColumn.ReadOnly = False
            'objTextColumn.NullText = ""
            'objTestGridTableStyle.GridColumnStyles.Add(objTextColumn)


            'objTextColumn = New DataGridTextBoxColumn
            'objTextColumn.MappingName = "TestID"
            'objTextColumn.HeaderText = "TestID"
            'objTextColumn.Width = 0
            'objTextColumn.ReadOnly = True
            'objTextColumn.NullText = ""
            'objTestGridTableStyle.GridColumnStyles.Add(objTextColumn)
            '=================== By Saurabh=========================
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
        Dim temp_cnt, intValidationTestID, intSampleID As Integer
        Dim strValidationTestID As String
        Dim strDeviation, strAbsorbance As String
        Dim status As Boolean
        Dim objDataView As New DataView
        Try
            '--- Read the remarks from the grid and save in the database.
            objDataView = dgTest.DataSource
            If objDataView.Table.Rows.Count <= 0 Then
                Return True
            End If

            For temp_cnt = 0 To objDataTable.Rows.Count - 1
                'intSampleID = objDataTable.Rows(temp_cnt).ItemArray.GetValue(objDataTable.Columns.Item("SampleID").Ordinal) 'code commented by : dinesh wagh on 28.1.2010 purpose : gives error log.
                intSampleID = objDataTable.Rows(temp_cnt).ItemArray.GetValue(objDataTable.Columns.Item("Repeat No").Ordinal) 'code added by ; dinesh wagh on 28.1.2010

                'If IsDBNull(objDataTable.Rows(temp_cnt).ItemArray.GetValue(objDataTable.Columns.Item("Sample").Ordinal)) Then
                '    intSample = ""
                'Else
                '    intSample = objDataTable.Rows(temp_cnt).ItemArray.GetValue(objDataTable.Columns.Item("Sample").Ordinal)
                'End If

                If IsDBNull(objDataTable.Rows(temp_cnt).ItemArray.GetValue(objDataTable.Columns.Item("Absorbance").Ordinal)) Then
                    strAbsorbance = ""
                Else
                    strAbsorbance = objDataTable.Rows(temp_cnt).ItemArray.GetValue(objDataTable.Columns.Item("Absorbance").Ordinal)
                End If

                If IsDBNull(objDataTable.Rows(temp_cnt).ItemArray.GetValue(objDataTable.Columns.Item("Deviation").Ordinal)) Then
                    strDeviation = ""
                Else
                    strDeviation = objDataTable.Rows(temp_cnt).ItemArray.GetValue(objDataTable.Columns.Item("Deviation").Ordinal)
                End If

                status = gobjDataAccess.funcUpdatePQTest2Records(intSampleID, strAbsorbance, strDeviation)
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
                                        ByVal intSample As Integer, _
                                        ByVal intAbsorbance As Integer, _
                                        ByVal dblDeviation As Double) As Boolean
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
                      " RT=?,PQAbsorbance=?,ActualAbsorbance=? " & _
                      " Where  ValidationTestID=? and PQTestID=?"

            '--- Providing command object for Test
            With objCommand
                '.Connection = gOleDBIQOQPQConnection
                .CommandType = CommandType.Text
                .CommandText = str_sql
                .Parameters.Add("RT", OleDbType.Numeric).Value = intSample
                .Parameters.Add("PQAbsorbance", OleDbType.Numeric).Value = intAbsorbance
                .Parameters.Add("ActualAbsorbance", OleDbType.Double).Value = Format(dblDeviation, "#0.00000")
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

            objDataRow = objCADataTable.NewRow()
            objDataRow("Name") = "1) Set the instrument with copper lamp. Optimise the response as per Attachment I."
            objCADataTable.Rows.Add(objDataRow)

            objDataRow = objCADataTable.NewRow()
            objDataRow("Name") = "2) Wait for 15 minutes to stablise_warm up the lamp."
            objCADataTable.Rows.Add(objDataRow)

            objDataRow = objCADataTable.NewRow()
            ''objDataRow("Name") = "3) Aspirate the solution. Using single point calibration curve obtains 10 reading for 'ppm' solution."
            objDataRow("Name") = "3) Aspirate 5ppm copper solution. Using sample repeats 10-15 numbers."
            objCADataTable.Rows.Add(objDataRow)

            objDataRow = objCADataTable.NewRow()
            ''objDataRow("Name") = "4) The absorption reading should be reproducible within +/- 10 counts."
            objDataRow("Name") = "4) Absorbance readings for repeats should be reproducible within ±10 counts."
            objCADataTable.Rows.Add(objDataRow)

            'code added by ; dinesh wagh on 24.2.2010
            '-------------------------------------------
            objDataRow = objCADataTable.NewRow
            objDataRow("Name") = "5) After completion of test please take printout of cv result from the resulted window."
            objCADataTable.Rows.Add(objDataRow)
            objDataRow = objCADataTable.NewRow
            objDataRow("Name") = "  by clicking on print button."
            objCADataTable.Rows.Add(objDataRow)
            '-----------------------------------------


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

#Region "Constant Test Data"


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

            If objDataTable.Rows.Count = 15 Then
                objDataTable.Rows.Clear()
                intCounter = 0
            End If
            If intCounter < 15 Then
                intCounter += 1
                RaiseEvent Test_IQOQPQ_AttachmentII(objDataTable, intCounter)  ', dtParameters)
            Else
                intCounter = 1
                objDataTable.Rows.Clear()
                RaiseEvent Test_IQOQPQ_AttachmentII(objDataTable, intCounter)  ', dtParameters)
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
