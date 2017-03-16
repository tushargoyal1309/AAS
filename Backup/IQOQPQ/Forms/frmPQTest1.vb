Imports System.Data
Imports System.Data.OleDb
Imports System.Windows.Forms.DataGridColumnStyle

Public Class frmPQTest1
    Inherits System.Windows.Forms.Form

#Region " Module level Declarations "
    'Private mblnModeLockStatus As Boolean
    'Private mstrOledbConnectionString As String
    'Private mobjOleDBconnection As OleDbConnection
    'Private mclsDBFunctions As New clsDatabaseFunctions

    'Private mobjDataTable, mobjTestDataTable As DataTable
    'Dim mobjGridTableStyle, mobjTestGridTableStyle As New DataGridTableStyle

    'Private Const CONST_TestEndID = 5
    'Private Const CONST_TestStartID = 1
    Private mobjCmbBox As ComboBox
    Private Const CONST_ConfirmColumnNo = 2

    '29.6.2010 by dinesh wagh
    '------------------------------------
    Dim mblnAvoidProcessing As Boolean
    Dim mintRowIndex, mintColumnIndex As Integer
    '-------------------------------------




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
    Friend WithEvents lblHeader2 As System.Windows.Forms.Label
    Friend WithEvents lblHeader3 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents dgTest As System.Windows.Forms.DataGrid
    Friend WithEvents lblTestingProcedure As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblppm As System.Windows.Forms.Label
    Friend WithEvents lblStdSolution As System.Windows.Forms.Label
    Friend WithEvents lblUserDefinedLamp As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmPQTest1))
        Me.lblHeader3 = New System.Windows.Forms.Label
        Me.lblHeader2 = New System.Windows.Forms.Label
        Me.lblHeader1 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.lblppm = New System.Windows.Forms.Label
        Me.lblStdSolution = New System.Windows.Forms.Label
        Me.lblUserDefinedLamp = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.lblTestingProcedure = New System.Windows.Forms.Label
        Me.dgTest = New System.Windows.Forms.DataGrid
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.dgTest, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblHeader3
        '
        Me.lblHeader3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeader3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblHeader3.Location = New System.Drawing.Point(8, 240)
        Me.lblHeader3.Name = "lblHeader3"
        Me.lblHeader3.Size = New System.Drawing.Size(520, 35)
        Me.lblHeader3.TabIndex = 9
        Me.lblHeader3.Text = "Performance testing data sheet shall be generated as per the requirement of respe" & _
        "ctive instrument / equipment are attached herewith for above tests."
        '
        'lblHeader2
        '
        Me.lblHeader2.BackColor = System.Drawing.Color.AliceBlue
        Me.lblHeader2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeader2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblHeader2.Location = New System.Drawing.Point(8, 208)
        Me.lblHeader2.Name = "lblHeader2"
        Me.lblHeader2.Size = New System.Drawing.Size(368, 26)
        Me.lblHeader2.TabIndex = 8
        Me.lblHeader2.Text = "PERFORMANCE TESTING PROCEDURE "
        Me.lblHeader2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblHeader1
        '
        Me.lblHeader1.BackColor = System.Drawing.Color.AliceBlue
        Me.lblHeader1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeader1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblHeader1.Location = New System.Drawing.Point(35, 7)
        Me.lblHeader1.Name = "lblHeader1"
        Me.lblHeader1.Size = New System.Drawing.Size(557, 18)
        Me.lblHeader1.TabIndex = 7
        Me.lblHeader1.Text = "E.II PERFORMANCE TESTING AND QUALIFICATION"
        Me.lblHeader1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.lblppm)
        Me.Panel1.Controls.Add(Me.lblStdSolution)
        Me.Panel1.Controls.Add(Me.lblUserDefinedLamp)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.lblTestingProcedure)
        Me.Panel1.Controls.Add(Me.dgTest)
        Me.Panel1.Controls.Add(Me.lblHeader2)
        Me.Panel1.Controls.Add(Me.lblHeader3)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(736, 440)
        Me.Panel1.TabIndex = 12
        '
        'lblppm
        '
        Me.lblppm.Location = New System.Drawing.Point(413, 40)
        Me.lblppm.Name = "lblppm"
        Me.lblppm.Size = New System.Drawing.Size(40, 16)
        Me.lblppm.TabIndex = 24
        Me.lblppm.Text = "ppm"
        '
        'lblStdSolution
        '
        Me.lblStdSolution.Location = New System.Drawing.Point(240, 40)
        Me.lblStdSolution.Name = "lblStdSolution"
        Me.lblStdSolution.Size = New System.Drawing.Size(120, 24)
        Me.lblStdSolution.TabIndex = 23
        Me.lblStdSolution.Text = "Standard solution :"
        '
        'lblUserDefinedLamp
        '
        Me.lblUserDefinedLamp.Location = New System.Drawing.Point(8, 40)
        Me.lblUserDefinedLamp.Name = "lblUserDefinedLamp"
        Me.lblUserDefinedLamp.Size = New System.Drawing.Size(152, 24)
        Me.lblUserDefinedLamp.TabIndex = 22
        Me.lblUserDefinedLamp.Text = "Using user defined lamp :"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 280)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(520, 18)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "The Data sheet covers following points:"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel2.Controls.Add(Me.PictureBox1)
        Me.Panel2.Controls.Add(Me.lblHeader1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(734, 32)
        Me.Panel2.TabIndex = 20
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
        'lblTestingProcedure
        '
        Me.lblTestingProcedure.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTestingProcedure.Location = New System.Drawing.Point(8, 304)
        Me.lblTestingProcedure.Name = "lblTestingProcedure"
        Me.lblTestingProcedure.Size = New System.Drawing.Size(528, 108)
        Me.lblTestingProcedure.TabIndex = 19
        Me.lblTestingProcedure.Text = "Label1"
        '
        'dgTest
        '
        Me.dgTest.BackgroundColor = System.Drawing.Color.AliceBlue
        Me.dgTest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.dgTest.CaptionVisible = False
        Me.dgTest.DataMember = ""
        Me.dgTest.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgTest.Location = New System.Drawing.Point(8, 68)
        Me.dgTest.Name = "dgTest"
        Me.dgTest.ParentRowsVisible = False
        Me.dgTest.ReadOnly = True
        Me.dgTest.RowHeadersVisible = False
        Me.dgTest.Size = New System.Drawing.Size(720, 128)
        Me.dgTest.TabIndex = 18
        '
        'frmPQTest1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(736, 440)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPQTest1"
        Me.Text = "PERFORMANCE QUALIFICATION TEST"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.dgTest, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Constants"
    Private Const ConstTestName As String = "TestName"
    Private Const ConstPurpose As String = "Purpose"
    Private Const ConstConformity As String = "Conformity"
    Private Const ConstComments As String = "Comments"
    Private Const ConstTestID As String = "TestID"

#End Region

#Region " Form Events "
    Private Sub frmPQTest1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            '--- Initialize the screen
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

    Private Sub frmPQTest1_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Try
            If Not gobjDataAccess.funcCheckModeLocked(ENUM_IQOQPQ_STATUS.PQ) Then
                dgTest.CurrentCell() = New DataGridCell(dgTest.CurrentRowIndex + 1, 0)
                If Not funcSavePQTest1Data() Then
                    Throw New Exception("Error in Saving Test Data.")
                End If
                dgTest.TableStyles.Clear()
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
    '    General functions used for IQ Tests Listing.
    '--- funcInitialize - To Initialize form and to get values for PQ Tests List from database and display them.
    '--- funcGetPQTest1Records - To Get PQ Test Records from Database and display them.
    '--- funcGetPQTest1Details - To Get PQ Test Records from Database for the given ID.
    '--- funcAssignValuesToControls - To Assign values to controls on form. 
    '--- funcSavePQTest1Data - To Save the Entered Records into Database.
    '--- funcGetObservationFromControls - To Get values from text box controls on form. 
    '--- funcGetDemoDateFromControls - To Get values from Date Time Picker controls on form. 
    '--- funcGetVerifiedDateFromControls - To Get values from Date Time Picker controls on form. 
    '--- funcInsertPQTest1Data - To Add/Insert New Test Data in Database.
    '--- funcUpdatePQTest1Data - To Update PQ Test Data in Database.
    '--- funcDeletePQTest1Data - To Delete PQ Test Data from Database.
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

            mobjCmbBox = New ComboBox
            AddHandler mobjCmbBox.SelectedIndexChanged, AddressOf CmbBox_SelectedIndexChanged
            dgTest.Controls.Add(mobjCmbBox)
            mobjCmbBox.Visible = False
            mobjCmbBox.BackColor = Color.AliceBlue
            mobjCmbBox.DropDownStyle = ComboBoxStyle.DropDownList
            'changed by sns on 21oct2004
            'mobjCmbBox.Items.Add("True")
            'mobjCmbBox.Items.Add("False")
            mobjCmbBox.Items.Add("YES")
            mobjCmbBox.Items.Add("NO")
            mobjCmbBox.Items.Add("N/A")

            '--- Display all the test information for their comformity
            Call funcDisplayPQTestConformity()
            Call subDisplayTestingProcedure()

            If gobjDataAccess.funcCheckModeLocked(ENUM_IQOQPQ_STATUS.PQ) Then
                dgTest.ReadOnly = True
                

            Else
                dgTest.ReadOnly = False
                mobjCmbBox.Enabled = True   'by Pankaj 06.12.07
            End If


            'code added by:dinesh wgah on 1.2.2010
            'Purpose : To remove the label as it is not giving any 
            'Proper information.
            '--------------------------------------
            lblppm.Visible = False
            lblStdSolution.Visible = False
            lblUserDefinedLamp.Visible = False
            '--------------------------------------


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

    Private Sub CmbBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        dgTest(dgTest.CurrentCell.RowNumber, dgTest.CurrentCell.ColumnNumber) = mobjCmbBox.Text
    End Sub


    Private Function funcDisplayPQTestConformity() As Boolean
        'Dim objReader As OleDbDataReader
        Dim objDataTable As DataTable
        Dim mobjTmpDt As DataTable
        Dim objDataRow As DataRow
        Dim intCount As Integer
        'Dim str_sql As String
        'Dim reader_status, record_exists As Boolean

        Try
            objDataTable = New DataTable("PQTest1")

            objDataTable.Columns.Add(New DataColumn("TestName", GetType(String)))
            objDataTable.Columns.Add(New DataColumn("Purpose", GetType(String)))
            objDataTable.Columns.Add(New DataColumn("Conformity", GetType(String)))
            objDataTable.Columns.Add(New DataColumn("Comments", GetType(String)))
            objDataTable.Columns.Add(New DataColumn("TestID", GetType(Integer)))

            mobjTmpDt = New DataTable
            mobjTmpDt = gobjDataAccess.funcGetPQConfirmityRecords()

            If Not mobjTmpDt Is Nothing Then
                If Not mobjTmpDt.Rows.Count = 0 Then
                    For intCount = 0 To mobjTmpDt.Rows.Count - 1
                        objDataRow = objDataTable.NewRow
                        'objDataRow.Item(ConstTestName) = CStr(mobjTmpDt.Rows.Item(intCount).Item("PQTestName")) '2.4.2010 by dinesh wagh
                        objDataRow.Item(ConstTestName) = gfuncWordWrap(CStr(mobjTmpDt.Rows.Item(intCount).Item("PQTestName")), 50) '2.4.2010 by dinesh wagh
                        'objDataRow.Item(ConstPurpose) = CStr(mobjTmpDt.Rows.Item(intCount).Item("PQPurpose")) '2.4.2010 by dinesh wagh
                        objDataRow.Item(ConstPurpose) = gfuncWordWrap(CStr(mobjTmpDt.Rows.Item(intCount).Item("PQPurpose")), 40)     '2.4.2010 by dinesh wagh
                        objDataRow.Item(ConstConformity) = (mobjTmpDt.Rows.Item(intCount).Item("PQConformity"))
                        'objDataRow.Item(ConstComments) = (mobjTmpDt.Rows.Item(intCount).Item("PQComments")) '2.4.2010 by dinesh wagh
                        objDataRow.Item(ConstComments) = gfuncWordWrap((mobjTmpDt.Rows.Item(intCount).Item("PQComments")), 30) '2.4.2010 by dinesh wagh

                        objDataRow.Item(ConstTestID) = CInt(mobjTmpDt.Rows.Item(intCount).Item("PQTestID"))
                        objDataTable.Rows.Add(objDataRow)
                    Next
                End If
            End If

            If IsNothing(objDataTable) = True Then
                Throw New Exception("Error in Getting Equipment List Records.")
            Else

                Call subFormatDataGrid(objDataTable)
            End If


            'str_sql = "Select Distinct ValidationTestID, PQTestName, PQPurpose, PQConformity, PQComments " & _
            '            "From PQTest1 " & _
            '            "Group by ValidationTestID, PQTestName, PQPurpose, PQConformity, PQComments "

            'If Not gclsDBFunctions.GetRecords(str_sql, gOleDBIQOQPQConnection, objReader) Then
            '    Return True
            'End If

            'While objReader.Read
            '    objDataRow = objDataTable.NewRow()

            '    If IsDBNull(objReader.Item("PQTestName")) = False Then
            '        objDataRow("TestName") = CStr(objReader.Item("PQTestName"))
            '    End If
            '    If IsDBNull(objReader.Item("PQPurpose")) = False Then
            '        objDataRow("Purpose") = CStr(objReader.Item("PQPurpose"))
            '    End If
            '    objDataRow("Conformity") = CStr(objReader.Item("PQConformity"))

            '    If IsDBNull(objReader.Item("PQComments")) = False Then
            '        objDataRow("Comments") = CStr(objReader.Item("PQComments"))
            '    Else
            '        objDataRow("Comments") = " "
            '    End If
            '    objDataRow("TestID") = Val(objReader.Item("ValidationTestID") & "")

            '    objDataTable.Rows.Add(objDataRow)
            'End While

            'objReader.Close()

            '--- Display the data in the grid
            'Call subFormatDataGrid(objDataTable)

            If gobjDataAccess.funcCheckModeLocked(ENUM_IQOQPQ_STATUS.PQ) Then
                mobjCmbBox.Width = 0 'by Pankaj 06.12.07
                mobjCmbBox.Enabled = False  'by Pankaj 06.12.07
                dgTest.ReadOnly = True
            Else
                mobjCmbBox.Enabled = True  'by Pankaj 06.12.07
                dgTest.ReadOnly = False
            End If

            Return True
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.ProcessError(ErrorHandler.ErrorHandler.EnumErrorType.Critical, ex)
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

    Private Sub subFormatDataGrid(ByRef objDataTable As DataTable)
        Dim objTextColumn As DataGridTextBoxColumn
        Dim objBoolColumn As DataGridBoolColumn
        Dim objDataView As New DataView
        Dim objTestGridTableStyle As New DataGridTableStyle

        Try
            dgTest.TableStyles.Clear()
            objDataView.Table = objDataTable
            objDataView.AllowNew = False
            dgTest.DataSource = objDataView

            objTestGridTableStyle.PreferredRowHeight = 34 '2.4.2010 by dinesh wagh

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

            objTestGridTableStyle.MappingName = "PQTest1"

            objTextColumn = New DataGridTextBoxColumn
            objTextColumn.TextBox.WordWrap = True '2.4.2010 by dinesh wagh
            objTextColumn.MappingName = "TestName"
            objTextColumn.HeaderText = "Performance Test"
            objTextColumn.Width = 300 '180 '2.4.2010 by dinesh wagh
            objTextColumn.ReadOnly = True
            objTextColumn.NullText = ""
            objTestGridTableStyle.GridColumnStyles.Add(objTextColumn)

            objTextColumn = New DataGridTextBoxColumn
            objTextColumn.TextBox.WordWrap = True '2.4.2010 by dinesh wagh
            objTextColumn.MappingName = "Purpose"
            objTextColumn.HeaderText = "Purpose"
            objTextColumn.Width = 185 '170 '2.4.2010 by dinesh wagh
            objTextColumn.ReadOnly = True
            objTextColumn.NullText = ""
            objTestGridTableStyle.GridColumnStyles.Add(objTextColumn)

            objTextColumn = New DataGridTextBoxColumn
            objTextColumn.TextBox.WordWrap = True '2.4.2010 by dinesh wagh
            objTextColumn.MappingName = "Conformity"
            objTextColumn.HeaderText = "Conformity"
            objTextColumn.Width = 70 '68 '2.4.2010 by dinesh wagh
            objTextColumn.ReadOnly = False
            objTextColumn.NullText = ""
            objTextColumn.Alignment = HorizontalAlignment.Center
            objTestGridTableStyle.GridColumnStyles.Add(objTextColumn)

            objTextColumn = New DataGridTextBoxColumn
            objTextColumn.TextBox.WordWrap = True '2.4.2010 by dinesh wagh
            objTextColumn.MappingName = "Comments"
            objTextColumn.HeaderText = "Comments"
            objTextColumn.Width = 160
            objTextColumn.ReadOnly = False
            objTextColumn.NullText = ""
            objTextColumn.Alignment = HorizontalAlignment.Center
            objTestGridTableStyle.GridColumnStyles.Add(objTextColumn)

            objTextColumn = New DataGridTextBoxColumn
            objTextColumn.TextBox.WordWrap = True '2.4.2010 by dinesh wagh
            objTextColumn.MappingName = "TestID"
            objTextColumn.HeaderText = "TestID"
            objTextColumn.Width = 0
            objTextColumn.ReadOnly = True
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

    Public Function funcSavePQTest1Data() As Boolean
        '=====================================================================
        ' Procedure Name        :   funcSavePQTest1Data
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
        Dim intCounter As Integer
        Dim objDataView As New DataView
        Dim strComment As String '25.6.2010 by dinesh wagh

        Try
            objDataView = dgTest.DataSource

            For intCounter = 0 To objDataView.Table.Rows.Count - 1
                If IsDBNull(objDataView.Table.Rows(intCounter).Item("Comments")) = True Then
                    objDataView.Table.Rows(intCounter).Item("Comments") = " "
                End If
                If IsDBNull(objDataView.Table.Rows(intCounter).Item("Conformity")) = True Then
                    objDataView.Table.Rows(intCounter).Item("Conformity") = " "
                End If


                'code added by ; dinesh wagh on 25.6.2010 
                '--------------
                strComment = objDataView.Table.Rows(intCounter).Item("Comments")
                strComment = strComment.Replace(vbCrLf, " ")
                '--------------------


                If Not gobjDataAccess.funcUpdatePQTestData(objDataView.Table.Rows(intCounter).Item("Conformity"), _
                            strComment, CInt(objDataView.Table.Rows(intCounter).Item("TestID"))) Then
                    Exit For
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

    Private Function funcUpdatePQTest1Data(ByVal intTestID As Integer, _
                                        ByVal strComments As String, _
                                        ByVal strConformity As String) As Boolean
        '=====================================================================
        ' Procedure Name        :   funcUpdatePQTest1Data
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
            '---  Query to Update Data
            str_sql = " Update PQTest1 set " & _
                      " PQConformity = ? , PQComments = ? " & _
                      " where ValidationTestID = " & intTestID & " "

            '--- Providing command object 
            With objCommand
                '.Connection = gOleDBIQOQPQConnection
                .CommandType = CommandType.Text
                .CommandText = str_sql
                .Parameters.Add("PQConformity", OleDbType.VarChar).Value = strConformity & ""
                .Parameters.Add("PQComments", OleDbType.VarChar, 250).Value = strComments & ""
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

    Private Sub subDisplayTestingProcedure()
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
        Dim strText As String

        Try

            strText = "1. Equipment / Instrument" & vbCrLf & _
                      "2. Test Name" & vbCrLf & _
                      "3. Purpose" & vbCrLf & _
                      "4. Method" & vbCrLf & _
                      "5. Acceptance Criteria" & vbCrLf & _
                      "6. Observation" & vbCrLf & _
                      "7. Test Results"
            'Test Result removed on 23.3.2010 by dinesh wagh

            lblTestingProcedure.Text = strText

        Catch ex As Exception
            '---------------------------------------------------------
            'Error logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = "Error in Creating Test Procedure Data-Table."
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
        'try catch added by : dinesh wagh on 3.2.2010
        'code added by : dinesh wagh on 27.6.2010
        '-----------------------------------------------
        If mblnAvoidProcessing = True Then Exit Sub
        Dim intRowIndex, intColumnIndex As Integer
        Dim strString As String
        '-------------------------------------

        Try
            If Not gobjDataAccess.funcCheckModeLocked(ENUM_IQOQPQ_STATUS.PQ) Then
                If (dgTest.CurrentCell.ColumnNumber = CONST_ConfirmColumnNo) Then
                    mobjCmbBox.Top = dgTest.GetCurrentCellBounds().Top
                    mobjCmbBox.Left = dgTest.GetCurrentCellBounds().Left
                    mobjCmbBox.Width = dgTest.GetCurrentCellBounds().Width
                    mobjCmbBox.Height = dgTest.GetCurrentCellBounds().Height
                    If (dgTest.CurrentCell.RowNumber) > 0 Then
                        If IsDBNull(dgTest(dgTest.CurrentCell.RowNumber, dgTest.CurrentCell.ColumnNumber)) = False Then
                            Dim strval = dgTest(dgTest.CurrentCell.RowNumber, dgTest.CurrentCell.ColumnNumber)
                            'If (strval = "TRUE") Then
                            If (strval = "YES") Then
                                mobjCmbBox.SelectedIndex = 0
                            Else
                                mobjCmbBox.SelectedIndex = 1
                            End If
                        Else
                            mobjCmbBox.SelectedIndex = 0
                        End If
                    End If
                    mobjCmbBox.Visible = True
                Else
                    mobjCmbBox.Width = 0
                    mobjCmbBox.Visible = False
                End If
            End If


            'code added by : dinesh wagh on 27.6.2010
            '---------------------------------------------------------------------------

            intRowIndex = dgTest.CurrentCell.RowNumber
            intColumnIndex = dgTest.CurrentCell.ColumnNumber


            mblnAvoidProcessing = True

            If Not IsDBNull(dgTest.Item(mintRowIndex, mintColumnIndex)) Then
                If mintColumnIndex = 3 Then
                    strString = dgTest.Item(mintRowIndex, mintColumnIndex)
                    If Not (strString = "") Then
                        strString = strString.Replace(vbCrLf, " ")
                        dgTest.Item(mintRowIndex, mintColumnIndex) = gfuncWordWrap(strString, 28)
                    End If
                End If
            End If

            dgTest.CurrentCell = New DataGridCell(intRowIndex, intColumnIndex)

            mintRowIndex = dgTest.CurrentCell.RowNumber
            mintColumnIndex = dgTest.CurrentCell.ColumnNumber

            mblnAvoidProcessing = False
            '------------------------------------------------------------------------
        Catch ex As Exception
            mblnAvoidProcessing = False '30.6.2010 by dinesh wagh
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
