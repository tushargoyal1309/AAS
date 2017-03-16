Option Explicit On 
Imports System.Data
Imports System.Data.OleDb
Imports System.Windows.Forms.DataGridColumnStyle

Public Class frmPQTest8
    Inherits System.Windows.Forms.Form

#Region " Module level Declarations "
    'Private mstrOledbConnectionString As String
    'Private mobjOleDBconnection As OleDbConnection
    'Private gclsDBFunctions As New clsDatabaseFunctions
    Private objDataTable As DataTable
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
    Friend WithEvents lblAcceptance As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmPQTest8))
        Me.lblTestResults = New System.Windows.Forms.Label
        Me.lblAttachment = New System.Windows.Forms.Label
        Me.lblMethod = New System.Windows.Forms.Label
        Me.lblPurpose = New System.Windows.Forms.Label
        Me.lblTestName = New System.Windows.Forms.Label
        Me.lblAcceptanceCriteria = New System.Windows.Forms.Label
        Me.lblHeader1 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.lblAcceptance = New System.Windows.Forms.Label
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
        Me.lblTestResults.Size = New System.Drawing.Size(120, 12)
        Me.lblTestResults.TabIndex = 18
        Me.lblTestResults.Text = "Observations  :"
        Me.lblTestResults.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAttachment
        '
        Me.lblAttachment.BackColor = System.Drawing.Color.AliceBlue
        Me.lblAttachment.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAttachment.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblAttachment.Location = New System.Drawing.Point(472, 32)
        Me.lblAttachment.Name = "lblAttachment"
        Me.lblAttachment.Size = New System.Drawing.Size(104, 20)
        Me.lblAttachment.TabIndex = 17
        Me.lblAttachment.Text = "Attachment VII"
        '
        'lblMethod
        '
        Me.lblMethod.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMethod.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblMethod.Location = New System.Drawing.Point(8, 88)
        Me.lblMethod.Name = "lblMethod"
        Me.lblMethod.Size = New System.Drawing.Size(450, 18)
        Me.lblMethod.TabIndex = 12
        Me.lblMethod.Text = "Method            :  Electron Capture Detector :"
        '
        'lblPurpose
        '
        Me.lblPurpose.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPurpose.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblPurpose.Location = New System.Drawing.Point(8, 64)
        Me.lblPurpose.Name = "lblPurpose"
        Me.lblPurpose.Size = New System.Drawing.Size(340, 18)
        Me.lblPurpose.TabIndex = 11
        Me.lblPurpose.Text = "Purpose          :   To verify the reproducibility test for system."
        '
        'lblTestName
        '
        Me.lblTestName.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTestName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTestName.Location = New System.Drawing.Point(8, 40)
        Me.lblTestName.Name = "lblTestName"
        Me.lblTestName.Size = New System.Drawing.Size(350, 18)
        Me.lblTestName.TabIndex = 10
        Me.lblTestName.Text = "Test Name    :   Retention time and Area reproducibility test."
        '
        'lblAcceptanceCriteria
        '
        Me.lblAcceptanceCriteria.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAcceptanceCriteria.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblAcceptanceCriteria.Location = New System.Drawing.Point(8, 300)
        Me.lblAcceptanceCriteria.Name = "lblAcceptanceCriteria"
        Me.lblAcceptanceCriteria.Size = New System.Drawing.Size(132, 12)
        Me.lblAcceptanceCriteria.TabIndex = 8
        Me.lblAcceptanceCriteria.Text = "Acceptance Criteria  :"
        Me.lblAcceptanceCriteria.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        Me.lblHeader1.Text = "E.II PERFORMANCE TESTING AND QUALIFICATION INSTALLATION "
        Me.lblHeader1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.lblAcceptance)
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
        Me.Panel1.Size = New System.Drawing.Size(344, 510)
        Me.Panel1.TabIndex = 12
        '
        'lblAcceptance
        '
        Me.lblAcceptance.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAcceptance.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblAcceptance.Location = New System.Drawing.Point(8, 320)
        Me.lblAcceptance.Name = "lblAcceptance"
        Me.lblAcceptance.Size = New System.Drawing.Size(500, 12)
        Me.lblAcceptance.TabIndex = 27
        Me.lblAcceptance.Text = "The % RSD of retention time of benzene from 5 replicate injection should be less " & _
        "than 2 %"
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
        Me.Panel2.Size = New System.Drawing.Size(342, 32)
        Me.Panel2.TabIndex = 26
        Me.Panel2.TabStop = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(30, 30)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'lblSpecifiedBaselineResult
        '
        Me.lblSpecifiedBaselineResult.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSpecifiedBaselineResult.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblSpecifiedBaselineResult.Location = New System.Drawing.Point(8, 340)
        Me.lblSpecifiedBaselineResult.Name = "lblSpecifiedBaselineResult"
        Me.lblSpecifiedBaselineResult.Size = New System.Drawing.Size(500, 12)
        Me.lblSpecifiedBaselineResult.TabIndex = 25
        Me.lblSpecifiedBaselineResult.Text = "The % RSD of peak areas of benzene from 5 replicate injection should be less than" & _
        " 2 %"
        Me.lblSpecifiedBaselineResult.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgTest
        '
        Me.dgTest.BackgroundColor = System.Drawing.Color.AliceBlue
        Me.dgTest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.dgTest.CaptionVisible = False
        Me.dgTest.DataMember = ""
        Me.dgTest.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgTest.Location = New System.Drawing.Point(8, 380)
        Me.dgTest.Name = "dgTest"
        Me.dgTest.ParentRowsVisible = False
        Me.dgTest.ReadOnly = True
        Me.dgTest.RowHeadersVisible = False
        Me.dgTest.Size = New System.Drawing.Size(568, 130)
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
        Me.dgMethod.Location = New System.Drawing.Point(8, 112)
        Me.dgMethod.Name = "dgMethod"
        Me.dgMethod.ParentRowsBackColor = System.Drawing.Color.AliceBlue
        Me.dgMethod.ParentRowsVisible = False
        Me.dgMethod.PreferredRowHeight = 14
        Me.dgMethod.ReadOnly = True
        Me.dgMethod.RowHeadersVisible = False
        Me.dgMethod.SelectionBackColor = System.Drawing.Color.AliceBlue
        Me.dgMethod.SelectionForeColor = System.Drawing.Color.AliceBlue
        Me.dgMethod.Size = New System.Drawing.Size(568, 180)
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
        'frmPQTest8
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(344, 424)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPQTest8"
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
    'Private Const ConstTestName As String = "TestName"
    Private Const ConstRT As String = "RT"
    Private Const ConstPeakArea As String = "PeakArea"
    'Private Const ConstTime As String = "Time"
    'Private Const ConstResult As String = "Result"
    'Private Const ConstCriteria As String = "Criteria"
    'Private Const ConstComments As String = "Comments"
    Private Const ConstTestID As String = "TestID"

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

            objDataTable.Columns.Add("RT")
            objDataTable.Columns.Add("PeakArea")
            objDataTable.Columns.Add("TestID")


            mobjTmpDt = gobjDataAccess.funcGetPQTest7Records()

            If Not mobjTmpDt Is Nothing Then
                If Not mobjTmpDt.Rows.Count = 0 Then
                    For intCount = 0 To mobjTmpDt.Rows.Count - 1
                        objDataRow = objDataTable.NewRow
                        'If CInt(mobjTmpDt.Rows.Item(intCount).Item("ValidationTestID")) = 6 Then
                        '    objDataRow.Item(ConstTestID) = "Average"
                        'ElseIf CInt(mobjTmpDt.Rows.Item(intCount).Item("ValidationTestID")) = 7 Then
                        '    objDataRow.Item(ConstTestID) = "% RSD"
                        'ElseIf CInt(mobjTmpDt.Rows.Item(intCount).Item("ValidationTestID")) = 8 Then
                        '    objDataRow.Item(ConstTestID) = "Results"
                        'Else
                        objDataRow.Item(ConstTestID) = mobjTmpDt.Rows.Item(intCount).Item("ValidationTestID")
                        'End If

                        objDataRow.Item(ConstRT) = Format(Val(mobjTmpDt.Rows.Item(intCount).Item("RT")), "#0.0")
                        objDataRow.Item(ConstPeakArea) = Format(Val(mobjTmpDt.Rows.Item(intCount).Item("PeakArea")), "#0.0")
                        objDataTable.Rows.Add(objDataRow)

                    Next
                End If
            End If

            If IsNothing(objDataTable) = True Then
                Throw New Exception("Error in Getting Equipment List Records.")
            Else
                'objDataRow = objDataTable.NewRow
                'objDataRow.Item(ConstTestID) = "Average"
                'objDataRow.Item(ConstRT) = (mobjTmpDt.Rows.Item(0).Item("RT") + mobjTmpDt.Rows.Item(1).Item("RT") + mobjTmpDt.Rows.Item(2).Item("RT") & _
                '+mobjTmpDt.Rows.Item(3).Item("RT") + mobjTmpDt.Rows.Item(4).Item("RT")) / 5
                'objDataRow.Item(ConstPeakArea) = (mobjTmpDt.Rows.Item(0).Item("PeakArea") + mobjTmpDt.Rows.Item(1).Item("PeakArea") + mobjTmpDt.Rows.Item(2).Item("PeakArea") & _
                '+mobjTmpDt.Rows.Item(3).Item("PeakArea") + mobjTmpDt.Rows.Item(4).Item("PeakArea")) / 5
                'objDataTable.Rows.Add(objDataRow)

                'objDataRow = objDataTable.NewRow
                'objDataRow.Item(ConstTestID) = "% RSD"
                'objDataRow.Item(ConstRT) = 0
                'objDataRow.Item(ConstPeakArea) = 0
                'objDataTable.Rows.Add(objDataRow)

                'objDataRow = objDataTable.NewRow
                'objDataRow.Item(ConstTestID) = "Results"
                'objDataRow.Item(ConstRT) = 0
                'objDataRow.Item(ConstPeakArea) = 0
                'objDataTable.Rows.Add(objDataRow)

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
            objTestGridTableStyle.HeaderBackColor = Color.LightSkyBlue
            objTestGridTableStyle.HeaderForeColor = Color.Black
            objTestGridTableStyle.AlternatingBackColor = Color.AliceBlue
            objTestGridTableStyle.AllowSorting = False

            objTestGridTableStyle.MappingName = "PQTest1Result"

            objTextColumn = New DataGridTextBoxColumn
            objTextColumn.MappingName = "TestID"
            objTextColumn.HeaderText = "Injection no."
            objTextColumn.Width = 130
            objTextColumn.ReadOnly = True
            objTextColumn.NullText = ""
            objTestGridTableStyle.GridColumnStyles.Add(objTextColumn)

            objTextColumn = New DataGridTextBoxColumn
            objTextColumn.MappingName = "RT"
            objTextColumn.HeaderText = "Retention Time"
            objTextColumn.Width = 130
            objTextColumn.ReadOnly = False
            objTextColumn.NullText = ""
            objTestGridTableStyle.GridColumnStyles.Add(objTextColumn)

            objTextColumn = New DataGridTextBoxColumn
            objTextColumn.MappingName = "PeakArea"
            objTextColumn.HeaderText = "Peak Area"
            objTextColumn.Width = 130
            objTextColumn.ReadOnly = False
            objTextColumn.NullText = ""
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
        Dim temp_cnt, intValidationTestID As Integer
        Dim strValidationTestID As String
        Dim status As Boolean
        Dim dblRT, dblPeakArea As Double
        Dim objDataView As New DataView
        Dim strTemp As String
        Try
            '--- Read the remarks from the grid and save in the database.
            objDataView = dgTest.DataSource
            If objDataView.Table.Rows.Count <= 0 Then
                Return True
            End If

            For temp_cnt = 0 To objDataTable.Rows.Count - 1
                'If temp_cnt > 4 Then
                '    strTemp = objDataTable.Rows(temp_cnt).ItemArray.GetValue(objDataTable.Columns.Item("TestID").Ordinal)
                '    If strTemp = "Average" Then
                '        intValidationTestID = 6
                '    ElseIf strTemp = "% RSD" Then
                '        intValidationTestID = 7
                '    ElseIf strTemp = "Results" Then
                '        intValidationTestID = 8
                '    End If
                'Else
                strValidationTestID = objDataTable.Rows(temp_cnt).ItemArray.GetValue(objDataTable.Columns.Item("TestID").Ordinal)
                'End If

                If IsDBNull(objDataTable.Rows(temp_cnt).ItemArray.GetValue(objDataTable.Columns.Item("RT").Ordinal)) Then
                    dblRT = 0
                Else
                    dblRT = objDataTable.Rows(temp_cnt).ItemArray.GetValue(objDataTable.Columns.Item("RT").Ordinal)
                End If

                If IsDBNull(objDataTable.Rows(temp_cnt).ItemArray.GetValue(objDataTable.Columns.Item("PeakArea").Ordinal)) Then
                    dblPeakArea = 0
                Else
                    dblPeakArea = objDataTable.Rows(temp_cnt).ItemArray.GetValue(objDataTable.Columns.Item("PeakArea").Ordinal)
                End If

                status = gobjDataAccess.funcUpdatePQTest7Records(dblRT, dblPeakArea, strValidationTestID)
                If Not (status) Then
                    Throw New Exception("Error in Updating PQTest3 Record Details.")
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
                                        ByVal dblResult As Double, _
                                        ByVal dblSpecifiedCriteria As Double, _
                                        ByVal strRemarks As String) As Boolean
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
            str_sql = " Update PQTest1 Set" & _
                      " PQAbsorbance=?,PQCriteria=?,PQComments=? " & _
                      " Where  ValidationTestID=? and PQTestID=?"

            '--- Providing command object for Test
            With objCommand
                '.Connection = gOleDBIQOQPQConnection
                .CommandType = CommandType.Text
                .CommandText = str_sql
                .Parameters.Add("PQAbsorbance", OleDbType.Double).Value = Format(dblResult, "#0.00000")
                .Parameters.Add("PQCriteria", OleDbType.Double).Value = Format(dblSpecifiedCriteria, "#0.00000")
                .Parameters.Add("PQComments", OleDbType.VarChar, 250).Value = strRemarks
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
            objDataRow("Name") = "A. Chromatographic Condition - "
            'objCADataTable.Columns.Item(0) 
            objCADataTable.Rows.Add(objDataRow)

            objDataRow = objCADataTable.NewRow()
            objDataRow("Name") = "1. Column           : 5 % SE-30 S.S.Column size 4'x1/8'' OD,80/100 Mesh or Suitable Equivalent Capillary column."
            objCADataTable.Rows.Add(objDataRow)

            objDataRow = objCADataTable.NewRow()
            objDataRow("Name") = "2. Carrier Gas      : Nitrogen."
            objCADataTable.Rows.Add(objDataRow)

            objDataRow = objCADataTable.NewRow()
            objDataRow("Name") = "3. Flow Rate        : N2 - 30 ml/min, Make Up Gas2 - 30 ml/min for capillary column flow, refer to the column manufacturer's instruction."
            objCADataTable.Rows.Add(objDataRow)

            objDataRow = objCADataTable.NewRow()
            objDataRow("Name") = "4. Detector         : ECD."
            objCADataTable.Rows.Add(objDataRow)

            objDataRow = objCADataTable.NewRow()
            objDataRow("Name") = "5. Injection Volume : 1.0 Micro-liter. Use suitable split ratio for capillary system"
            objCADataTable.Rows.Add(objDataRow)

            objDataRow = objCADataTable.NewRow()
            objDataRow("Name") = "6 Temperature       : Oven-190 °C., Injector-230 °C., Detector-250 °C."
            objCADataTable.Rows.Add(objDataRow)

            objDataRow = objCADataTable.NewRow()
            objDataRow("Name") = "7. Range            : Current 1.0 nA."
            objCADataTable.Rows.Add(objDataRow)

            objDataRow = objCADataTable.NewRow()
            objDataRow("Name") = "8. Attenuation      : 32."
            objCADataTable.Rows.Add(objDataRow)

            objDataRow = objCADataTable.NewRow()
            objDataRow("Name") = ""
            objCADataTable.Rows.Add(objDataRow)

            objDataRow = objCADataTable.NewRow()
            objDataRow("Name") = "B. Preparation of standard solution : Make 100 ppb Lindane solution in HPLC grade Hexane."
            objCADataTable.Rows.Add(objDataRow)

            objDataRow = objCADataTable.NewRow()
            objDataRow("Name") = "C. Inject 0.5 Micro liter of std. solution 5 replicates and record the chromatograms."
            objCADataTable.Rows.Add(objDataRow)

            objDataRow = objCADataTable.NewRow()
            objDataRow("Name") = "D. Calculate the % RSD of the retention times of benzene from the 5 replicate injection."
            objCADataTable.Rows.Add(objDataRow)

            objDataRow = objCADataTable.NewRow()
            objDataRow("Name") = "E. Calculate the % RSD of the peak areas of Lindane from the 5 replicate injection."
            objCADataTable.Rows.Add(objDataRow)

            objDataRow = objCADataTable.NewRow()
            objDataRow("Name") = "F. Calculate the average peak area of Lindane from the 5 replicate injection"
            objCADataTable.Rows.Add(objDataRow)

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

End Class
