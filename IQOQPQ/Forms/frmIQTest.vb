Option Explicit On 

Imports System.Data
Imports System.Data.OleDb
Imports ErrorHandler.ErrorHandler

Public Class frmIQTest
    Inherits System.Windows.Forms.Form

#Region " Module level Declarations "
    Private mobjCmbBox As ComboBox
    Private Const CONST_ConfirmColumnNo = 2
    Private Const CONST_NoOfTests = 5
    Private mblnModeLockStatus As Boolean
    Private mstrOledbConnectionString As String
    Private mobjOleDBconnection As OleDbConnection
    'Public mclsDBFunctions As New clsDatabaseFunctions

    Private mObjDataTable As DataTable
    Dim mobjGridTableStyle As New DataGridTableStyle

    'code added by ; dinesh wagh on 27.6.2010
    '---------------------------------------------
    Dim mintRowIndex, mintColumnIndex As Integer
    Dim mblnAvoidProcessing As Boolean
    Private Const CONST_COMMENT_COLUMN_NO = 3
    '----------------------------------------

    Private Enum enumConfirmity As Integer
        No = 0
        Yes = 1
    End Enum

    Structure mTest
        Public mItem As String
        Public RequirementCondition As String
    End Structure
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
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents dgTest As System.Windows.Forms.DataGrid
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmIQTest))
        Me.Label3 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.dgTest = New System.Windows.Forms.DataGrid
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.dgTest, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.AliceBlue
        Me.Label3.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(35, 7)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(400, 18)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "C.II  INSTALLATION QUALIFICATION  TESTS"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.dgTest)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(720, 576)
        Me.Panel1.TabIndex = 12
        '
        'Panel2
        '
        Me.Panel2.AutoScroll = True
        Me.Panel2.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel2.Controls.Add(Me.PictureBox1)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(718, 32)
        Me.Panel2.TabIndex = 19
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
        Me.dgTest.Location = New System.Drawing.Point(8, 48)
        Me.dgTest.Name = "dgTest"
        Me.dgTest.ParentRowsVisible = False
        Me.dgTest.ReadOnly = True
        Me.dgTest.RowHeadersVisible = False
        Me.dgTest.Size = New System.Drawing.Size(704, 520)
        Me.dgTest.TabIndex = 18
        '
        'frmIQTest
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(720, 584)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmIQTest"
        Me.Text = "INSTALLATION QUALIFICATION TEST"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.dgTest, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Constants"

    Private Const ConstTestName As String = "TestName"
    Private Const ConstPurposeOrCondition As String = "PurposeOrCondition"
    Private Const ConstConfirmity As String = "Confirmity"
    Private Const ConstComments As String = "Comments"
    Private Const ConstTestID As String = "TestID"

#End Region

#Region " Form Events "

    Private Sub frmIQMannualList_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

    Private Sub frmIQMannualList_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Try
            If Not (mblnModeLockStatus) Then
                dgTest.CurrentCell() = (New DataGridCell(dgTest.CurrentRowIndex + 1, 0))
                If Not funcSaveIQTestData() Then
                    Throw New Exception("Error in Saving IQ Tests Data.")
                End If
                dgTest.TableStyles.Clear()
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
    '--- funcInitialize - To Initialize form and to get values for IQ Tests List from database and display them.
    '--- subCreateDataTable - To Create Columns in the Data Table.
    '--- funcGetIQTestRecords - To Get IQ Equipment List Records from Database into DataTable.
    '--- subFormatDataGrid - To format the Data Grid.
    '--- funcSaveIQTestData - To Save the Entered Records into Database.
    '--- funcInsertIQTestData - To Add/Insert New Test Data in Database.
    '--- funcUpdateIQTestData - To Update IQ Test Data in Database.
    '--- funcDeleteIQTestData - To Delete IQ Test Data from Database.

    Private Sub funcInitialize()
        '=====================================================================
        ' Procedure Name        :   funcInitailize
        ' Description           :   To Initialize form and to get values for IQ Test Data from database and display them.
        ' Purpose               :   To Initialize form and to get values for IQ Equipment List from database and display them.
        ' Parameters Passed     :   None.
        ' Returns               :   None.
        ' Parameters Affected   :   None.
        ' Assumptions           :
        ' Dependencies          :
        ' Author                :   Gitesh
        ' Created               :   January, 2003 
        ' Revisions             :
        '=====================================================================
        Dim mobjTmpDt As DataTable
        Dim intCount As Integer
        Dim objDataRow As DataRow

        Try
            'mfrmTest = Me
            mObjDataTable = New DataTable("Test")
            mobjCmbBox = New ComboBox

            '--- To Add Run-Time DateTime Picker Control
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

            subCreateDataTable()

            mobjTmpDt = New DataTable

            mobjTmpDt = gobjDataAccess.funcGetIQTestRecords()

            If Not mobjTmpDt Is Nothing Then
                If Not mobjTmpDt.Rows.Count = 0 Then
                    For intCount = 0 To mobjTmpDt.Rows.Count - 1
                        objDataRow = mObjDataTable.NewRow
                        'objDataRow.Item(ConstTestName) = CStr(mobjTmpDt.Rows.Item(intCount).Item("TestName")) '2.4.2010
                        objDataRow.Item(ConstTestName) = gfuncWordWrap(CStr(mobjTmpDt.Rows.Item(intCount).Item("TestName")), 25) '2.4.2010
                        'objDataRow.Item(ConstPurposeOrCondition) = CStr(mobjTmpDt.Rows.Item(intCount).Item("PurposeOrCondition")) '2.4.2010
                        objDataRow.Item(ConstPurposeOrCondition) = gfuncWordWrap(CStr(mobjTmpDt.Rows.Item(intCount).Item("PurposeOrCondition")), 60)          '2.4.2010

                        objDataRow.Item(ConstConfirmity) = CStr(mobjTmpDt.Rows.Item(intCount).Item("Confirmity"))
                        If (IsDBNull(mobjTmpDt.Rows.Item(intCount).Item("Comments"))) Then
                            objDataRow.Item(ConstComments) = ""
                        Else
                            'objDataRow.Item(ConstComments) = CStr(mobjTmpDt.Rows.Item(intCount).Item("Comments")) '2.4.2010
                            objDataRow.Item(ConstComments) = gfuncWordWrap(CStr(mobjTmpDt.Rows.Item(intCount).Item("Comments")), 18) '2.4.2010
                        End If
                        objDataRow.Item(ConstTestID) = CInt(mobjTmpDt.Rows.Item(intCount).Item("TestID"))
                        mObjDataTable.Rows.Add(objDataRow)

                    Next
                End If
            End If

            If IsNothing(mObjDataTable) = True Then
                Throw New Exception("Error in Getting Equipment List Records.")
            Else

                subFormatDataGrid()
            End If

            'If funcGetIQTestRecords() Then
            '    subFormatDataGrid()
            'Else
            '    Throw New Exception("Error in Getting IQ Test Records.")
            'End If

            mblnModeLockStatus = gobjDataAccess.funcCheckModeLocked(ENUM_IQOQPQ_STATUS.IQ)
            If (mblnModeLockStatus) Then
                dgTest.ReadOnly = True
            Else
                dgTest.ReadOnly = False
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

    Private Sub CmbBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'try catch added by ; dinesh wagh on 3.2.2010
        Try
            dgTest(dgTest.CurrentCell.RowNumber, dgTest.CurrentCell.ColumnNumber) = mobjCmbBox.Text
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

    Private Sub subCreateDataTable()
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
            mObjDataTable.Columns.Add(New DataColumn("TestName", GetType(String)))
            mObjDataTable.Columns.Add(New DataColumn("PurposeOrCondition", GetType(String)))
            mObjDataTable.Columns.Add(New DataColumn("Confirmity", GetType(String)))
            mObjDataTable.Columns.Add(New DataColumn("Comments", GetType(String)))
            mObjDataTable.Columns.Add(New DataColumn("TestID", GetType(Integer)))
        Catch ex As Exception
            '---------------------------------------------------------
            'Error logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = "Error in Creating IQ Test List Data-Table."
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

    'Private Function funcGetIQTestRecords() As Boolean
    '    '=====================================================================
    '    ' Procedure Name        :   funcGetIQTestRecords
    '    ' Description           :   To Get IQ Test Records from Database into DataTable.
    '    ' Purpose               :   To Get IQ Test Records from Database into DataTable.
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
    '    Dim intTableRecordCount, temp_cnt As Integer
    '    Dim ObjStructmTest As New mTest

    '    Try
    '        'reader_status = mclsDBFunctions.GetRecords("Select * from Test where CheckStatusIQOQPQ = 1 ", mobjOleDBconnection, objReader)

    '        If Not (reader_status) Then
    '            Throw New Exception("Error in Opening Connection during Getting IQ Test Details.")
    '        End If

    '        'intTableRecordCount = mclsDBFunctions.GetNoOfRec(objReader)
    '        objReader.Close()

    '        If intTableRecordCount <= 0 Then
    '            For temp_cnt = 0 To (CONST_NoOfTests)
    '                'Assigning Struct Object
    '                Call funcFillStruct(ObjStructmTest, temp_cnt)

    '                'Insert Item and Requirement and Condition                
    '                If Not (funcInsertIQTestData(ObjStructmTest.mItem, ObjStructmTest.RequirementCondition)) Then
    '                    Throw New Exception("Error in Opening Connection during Getting IQ Test Details.")
    '                End If
    '            Next
    '        End If

    '        sql_string = "Select TestID ,TestName ,PurposeOrCondition ,Confirmity ,Comments from Test where CheckStatusIQOQPQ = 1 "

    '        'reader_status = mclsDBFunctions.GetRecords(sql_string, mobjOleDBconnection, objReader)

    '        If Not (reader_status) Then
    '            Throw New Exception("Error in Opening Connection during Getting IQ Test Details.")
    '        End If

    '        While objReader.Read
    '            objDataRow = mObjDataTable.NewRow()

    '            objDataRow("TestName") = CStr(objReader.Item("TestName"))
    '            objDataRow("PurposeOrCondition") = CStr(objReader.Item("PurposeOrCondition"))
    '            objDataRow("Confirmity") = CStr(objReader.Item("Confirmity")) & " "
    '            objDataRow("Comments") = CStr(objReader.Item("Comments")) & ""
    '            objDataRow("TestID") = Convert.ToInt32(objReader.Item("TestID"))

    '            mObjDataTable.Rows.Add(objDataRow)
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

    Private Sub subFormatDataGrid()
        Dim objTextColumn As DataGridTextBoxColumn
        Dim objDataView As New DataView
        Try
            dgTest.TableStyles.Clear()
            objDataView.Table = mObjDataTable
            objDataView.AllowNew = False
            dgTest.DataSource = objDataView
            'dgTest.ReadOnly = False
            mobjGridTableStyle.PreferredRowHeight = 100 '2.4.2010 by dinesh wagh
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

            mobjGridTableStyle.MappingName = "Test"

            objTextColumn = New DataGridTextBoxColumn
            objTextColumn.TextBox.WordWrap = True '2.4.2010 by dinesh wagh
            objTextColumn.MappingName = "TestName"
            objTextColumn.HeaderText = "Item"
            objTextColumn.Width = 150 '200 '2.4.2010 by dinesh wagh
            objTextColumn.ReadOnly = True
            objTextColumn.NullText = ""
            mobjGridTableStyle.GridColumnStyles.Add(objTextColumn)

            objTextColumn = New DataGridTextBoxColumn
            objTextColumn.TextBox.WordWrap = True '2.4.2010 by dinesh wagh
            objTextColumn.MappingName = "PurposeOrCondition"
            objTextColumn.HeaderText = "Requirement Condition"
            objTextColumn.Width = 350 '210  on 2.4.2010 by dinesh wagh
            objTextColumn.ReadOnly = True
            objTextColumn.NullText = ""
            mobjGridTableStyle.GridColumnStyles.Add(objTextColumn)

            objTextColumn = New DataGridTextBoxColumn
            objTextColumn.TextBox.WordWrap = True '2.4.2010 by dinesh wagh
            objTextColumn.MappingName = "Confirmity"
            objTextColumn.HeaderText = "Conformity"
            objTextColumn.Width = 70
            objTextColumn.ReadOnly = False
            objTextColumn.NullText = ""
            mobjGridTableStyle.GridColumnStyles.Add(objTextColumn)

            objTextColumn = New DataGridTextBoxColumn
            objTextColumn.TextBox.WordWrap = True '2.4.2010 by dinesh wagh
            objTextColumn.MappingName = "Comments"
            objTextColumn.HeaderText = "Comments"
            objTextColumn.Width = 110 '90 by dinesh wagh 2.4.2010
            objTextColumn.ReadOnly = False
            objTextColumn.NullText = ""
            mobjGridTableStyle.GridColumnStyles.Add(objTextColumn)

            objTextColumn = New DataGridTextBoxColumn
            objTextColumn.TextBox.WordWrap = True '2.4.2010 by dinesh wagh
            objTextColumn.MappingName = "TestID"
            objTextColumn.HeaderText = "TestID"
            objTextColumn.Width = 0
            objTextColumn.ReadOnly = True
            objTextColumn.NullText = ""
            mobjGridTableStyle.GridColumnStyles.Add(objTextColumn)

            mobjGridTableStyle.GridLineColor = Color.Black
            dgTest.TableStyles.Add(mobjGridTableStyle)
        Catch ex As Exception
            '---------------------------------------------------------
            'Error logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = "Error in Formating IQ Test List Data-Grid."
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

    Public Function funcSaveIQTestData() As Boolean
        '=====================================================================
        ' Procedure Name        :   funcSaveIQTestData
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

        Dim intRecordCount, intTestID, temp_cnt As Integer
        Dim strComment, strConfirmity As String
        Dim status As Boolean = True

        Try
            intRecordCount = mObjDataTable.Rows.Count

            For temp_cnt = 0 To (intRecordCount - 1)

                '--- To Check if Test ID is Null.
                If IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("TestID").Ordinal)) Then

                Else
                    intTestID = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("TestID").Ordinal)

                    If IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("Comments").Ordinal)) Then
                        strComment = ""
                    Else
                        strComment = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("Comments").Ordinal)
                        strComment = strComment.Replace(vbCrLf, " ")   '24.6.2010 by dinesh wagh to make the string which has no vbcrlf.
                    End If
                    If IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("Confirmity").Ordinal)) Then
                        strConfirmity = ""
                    Else
                        strConfirmity = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("Confirmity").Ordinal)
                    End If

                    ' strConfirmity = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("Confirmity").Ordinal)
                    status = gobjDataAccess.funcUpdateIQTestData(strComment, strConfirmity, intTestID)
                    If Not (status) Then
                        Throw New Exception("Error in Updating IQ Test Details.")
                    End If
                End If
            Next
        Catch ex As Exception
            '---------------------------------------------------------
            'Error logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = "Error in Saving IQ Test Details."
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

    'Private Function funcInsertIQTestData(ByVal strTestName As String, ByVal strPurpose As String) As Boolean
    '    '=====================================================================
    '    ' Procedure Name        :   funcInsertIQTestData
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
    '    Dim str_sql, strConfirm As String
    '    Dim objCommand As New OleDbCommand
    '    Dim intTestID As Integer

    '    Try
    '        strConfirm = "False"
    '        'Status = mclsDBFunctions.OpenConnection(mobjOleDBconnection)
    '        If Not (Status) Then
    '            Throw New Exception("Error in Opening Connection during Saving IQ Test Details.")
    '        End If

    '        '--- Generating Next Equipment ID. 
    '        'intTestID = mclsDBFunctions.GetNextID("Test", "TestID", mobjOleDBconnection)

    '        '---  Query for adding  data to Test
    '        str_sql = " Insert into Test " & _
    '                  " (TestID ,TestName ,PurposeOrCondition ,CheckStatusIQOQPQ ,Confirmity ,Comments) " & _
    '                  " values(?,?,?,?,?,?) "

    '        '--- Providing command object for Test
    '        With objCommand
    '            .Connection = mobjOleDBconnection
    '            .CommandType = CommandType.Text
    '            .CommandText = str_sql
    '            .Parameters.Add("TestID", OleDbType.Numeric).Value = intTestID
    '            .Parameters.Add("TestName", OleDbType.WChar).Value = strTestName
    '            .Parameters.Add("PurposeOrCondition", OleDbType.VarChar, 350).Value = strPurpose
    '            .Parameters.Add("CheckStatusIQOQPQ", OleDbType.Single).Value = CSng(ENUM_IQOQPQ_STATUS.IQ)
    '            .Parameters.Add("Confirmity", OleDbType.VarChar, 350).Value = strConfirm & " "
    '            .Parameters.Add("Comments", OleDbType.VarChar, 350).Value = strConfirm & " "
    '            .ExecuteNonQuery()
    '        End With

    '        objCommand.Dispose()
    '        Status = True

    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        '--- Error logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = "Error in Saving IQ Test Details."
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

    'Private Function funcUpdateIQTestData(ByVal strComment As String, ByVal strConfirmity As String, ByVal intTestID As Integer) As Boolean
    '    '=====================================================================
    '    ' Procedure Name        :   funcUpdateIQTestData
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
    '            Throw New Exception("Error in Opening Connection during Updating IQ Test Details.")
    '        End If

    '        '---  Query for adding  data to Test            
    '        str_sql = " Update Test set " & _
    '                  "Confirmity = ? , Comments = ? " & _
    '                  " where TestID = " & intTestID & " " & _
    '                  " and CheckStatusIQOQPQ=1 "

    '        '--- Providing command object for EquimentList
    '        With objCommand
    '            .Connection = mobjOleDBconnection
    '            .CommandType = CommandType.Text
    '            .CommandText = str_sql
    '            .Parameters.Add("Confirmity", OleDbType.VarChar, 250).Value = strConfirmity
    '            .Parameters.Add("Comments", OleDbType.VarChar, 250).Value = strComment
    '            .ExecuteNonQuery()
    '        End With

    '        objCommand.Dispose()
    '        Status = True

    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        '--- Error logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = "Error in Updating IQ Test Details."
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

    'Private Function funcDeleteIQTestData(ByVal intTestID As Integer) As Boolean
    '    '=====================================================================
    '    ' Procedure Name        :   funcDeleteIQTestData
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
    '            Throw New Exception("Error in Opening Connection during Deleting IQ Test Details.")
    '        End If

    '        '--- Query to Delete from Database
    '        str_sql = " Delete * from Test where TestID = " & intTestID & " and and CheckStatusIQOQPQ = 1  "

    '        'Status = mclsDBFunctions.AddORDeleteRecord(str_sql, mobjOleDBconnection)
    '        If (Status = False) Then
    '            Throw New Exception("Error in Deleting IQ Test Details.")
    '        End If

    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        '--- Error logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = "Error in Deleting IQ Test Details."
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

    Private Function funcFillStruct(ByRef objstructTest As mTest, ByVal testNo As Integer)
        'try catch added by ; dinesh wagh on 3.2.2010
        Try

            Select Case testNo
                Case 0
                    objstructTest.mItem = "Equipment Appearance Check"
                    objstructTest.RequirementCondition = "No contamination ,Dirt,Deformation,Marks etc.Physical condition good "
                Case 1
                    objstructTest.mItem = "Parts Check"
                    objstructTest.RequirementCondition = "Check with delivery Challan and confirm that parts are supplied as displayed"
                Case 2
                    objstructTest.mItem = "Voltage Check"
                    objstructTest.RequirementCondition = "Online UPS(1 KVA)Or "" Offline UPS with servo-stabliser is recommended " & _
                    "Check stablised voltage supply with digital volt meter and voltage should satisfy the specified value (230 VAC" & _
                    "+/- 5%).A very good Ground/Earth Connection with earth -neutral leakage less than 3 volts"
                Case 3
                    objstructTest.mItem = "Installation Site Check"
                    objstructTest.RequirementCondition = "Check and confirm the Following:" & _
                    "      1.Room Temperature of 25° C +/- 3° C. " & _
                    "2.Away from Direct Sunlight and Direct Air-Blow." & _
                    Space(79) & "3.No corrosive gases." & _
                    Space(30) & "4.Free from excessive dust and moisture "
                Case 4
                    objstructTest.mItem = "Equipment Connection Check"
                    objstructTest.RequirementCondition = "Check the interconnection wiring and " & _
                    "connections between each instrument and accessories of the system .Ensure that there is no loose wiring" & _
                    " & connections .For Accessories :Ensure that proper types of tubings and fittings used. " & _
                    "Check Tubing connectuions for leak(using leak check solution)"

                Case 5
                    objstructTest.mItem = "Certificate Functional Performance Check"
                    objstructTest.RequirementCondition = "Check serial numbers indicated on test certificate and" & _
                     " ensure that it tallies with the equipments serial numbers "

            End Select

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

    Private Sub dgTest_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgTest.CurrentCellChanged
        'try catch added by : dinesh wagh on 3.2.2010

        'code added by : dinesh wagh on 27.6.2010
        '-----------------------------------------------
        If mblnAvoidProcessing = True Then Exit Sub
        Dim intRowIndex, intColumnIndex As Integer
        Dim strString As String
        '-------------------------------------

        Try
            If Not (mblnModeLockStatus) Then
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
                If mintColumnIndex = CONST_COMMENT_COLUMN_NO Then
                    strString = dgTest.Item(mintRowIndex, mintColumnIndex)
                    If Not (strString = "") Then
                        strString = strString.Replace(vbCrLf, " ")
                        dgTest.Item(mintRowIndex, mintColumnIndex) = gfuncWordWrap(strString, 18)
                    End If
                End If
            End If

            dgTest.CurrentCell = New DataGridCell(intRowIndex, intColumnIndex)

            mintRowIndex = dgTest.CurrentCell.RowNumber
            mintColumnIndex = dgTest.CurrentCell.ColumnNumber

            mblnAvoidProcessing = False
            '------------------------------------------------------------------------
        Catch ex As Exception
            mblnAvoidProcessing = False '27.6.2010 by dinesh wagh on 27.6.2010
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
