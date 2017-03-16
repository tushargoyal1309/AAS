Option Explicit On 

Imports System.Data
Imports System.Data.OleDb
Imports ErrorHandler.ErrorHandler

Public Class frmOQUserTraining
    Inherits System.Windows.Forms.Form

#Region " Module level Declarations "
    Private mblnModeLockStatus As Boolean
    Private mstrOledbConnectionString As String
    Private mobjOleDBconnection As OleDbConnection
    'Public mclsDBFunctions As New clsDatabaseFunctions
    Dim mdtpUserDate As DateTimePicker
    Private mobjDataView As New DataView
    Private mObjDataTable, mobjCADataTable As DataTable
    Dim mobjGridTableStyle, mobjCAGridTableStyle As New DataGridTableStyle


    '29.6.2010 by dinesh wagh
    '-----------
    Dim mintRowIndex, mintColumnIndex As Integer
    Dim mblnAvoidProcessing As Boolean
    '----------


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
    Friend WithEvents lblHeader2 As System.Windows.Forms.Label
    Friend WithEvents lblHeader1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents dgTraining As System.Windows.Forms.DataGrid
    Friend WithEvents dgUser As System.Windows.Forms.DataGrid
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmOQUserTraining))
        Me.lblHeader2 = New System.Windows.Forms.Label
        Me.lblHeader1 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.dgUser = New System.Windows.Forms.DataGrid
        Me.dgTraining = New System.Windows.Forms.DataGrid
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.dgUser, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgTraining, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblHeader2
        '
        Me.lblHeader2.BackColor = System.Drawing.Color.AliceBlue
        Me.lblHeader2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeader2.Location = New System.Drawing.Point(8, 320)
        Me.lblHeader2.Name = "lblHeader2"
        Me.lblHeader2.Size = New System.Drawing.Size(144, 20)
        Me.lblHeader2.TabIndex = 12
        Me.lblHeader2.Text = "User Training - "
        Me.lblHeader2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblHeader1
        '
        Me.lblHeader1.BackColor = System.Drawing.Color.AliceBlue
        Me.lblHeader1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeader1.Location = New System.Drawing.Point(35, 7)
        Me.lblHeader1.Name = "lblHeader1"
        Me.lblHeader1.Size = New System.Drawing.Size(528, 18)
        Me.lblHeader1.TabIndex = 11
        Me.lblHeader1.Text = "D.III OPERATIONAL USER TRAINING"
        Me.lblHeader1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.dgUser)
        Me.Panel1.Controls.Add(Me.dgTraining)
        Me.Panel1.Controls.Add(Me.lblHeader2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(680, 512)
        Me.Panel1.TabIndex = 12
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel2.Controls.Add(Me.PictureBox1)
        Me.Panel2.Controls.Add(Me.lblHeader1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(678, 32)
        Me.Panel2.TabIndex = 20
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.AliceBlue
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'dgUser
        '
        Me.dgUser.BackgroundColor = System.Drawing.Color.AliceBlue
        Me.dgUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.dgUser.CaptionVisible = False
        Me.dgUser.DataMember = ""
        Me.dgUser.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgUser.Location = New System.Drawing.Point(8, 344)
        Me.dgUser.Name = "dgUser"
        Me.dgUser.ParentRowsVisible = False
        Me.dgUser.ReadOnly = True
        Me.dgUser.RowHeadersVisible = False
        Me.dgUser.Size = New System.Drawing.Size(640, 152)
        Me.dgUser.TabIndex = 19
        '
        'dgTraining
        '
        Me.dgTraining.BackgroundColor = System.Drawing.Color.AliceBlue
        Me.dgTraining.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.dgTraining.CaptionVisible = False
        Me.dgTraining.DataMember = ""
        Me.dgTraining.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgTraining.Location = New System.Drawing.Point(8, 48)
        Me.dgTraining.Name = "dgTraining"
        Me.dgTraining.ParentRowsVisible = False
        Me.dgTraining.ReadOnly = True
        Me.dgTraining.RowHeadersVisible = False
        Me.dgTraining.Size = New System.Drawing.Size(640, 264)
        Me.dgTraining.TabIndex = 18
        '
        'frmOQUserTraining
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(680, 520)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmOQUserTraining"
        Me.Text = "frmOQUserTraining"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.dgUser, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgTraining, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Constants"

    Private Const ConstSrNo As String = "SrNo"
    Private Const ConstTrainingType As String = "TrainingType"
    Private Const ConstTrainingGiven As String = "TrainingGiven"
    Private Const ConstTrainingComments As String = "TrainingComments"
    Private Const ConstTrainingID As String = "TrainingID"

    Private Const ConstUserName As String = "UserName"
    Private Const ConstUserDate As String = "UserDate"
    Private Const ConstUserID As String = "UserID"

#End Region

#Region " Form Events "
    Private Sub frmOQUserTraining_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

    Private Sub frmOQUserTraining_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

        Try
            If Not (mblnModeLockStatus) Then
                dgTraining.CurrentCell() = (New DataGridCell(dgTraining.CurrentRowIndex + 1, 0))
                If Not funcSaveOQUserTrainingData() Then
                    Throw New Exception("Error in Saving User Training Data.")
                End If
                dgTraining.TableStyles.Clear()

                dgUser.CurrentCell() = (New DataGridCell(dgUser.CurrentRowIndex + 1, 0))
                If Not funcSaveOQUserData() Then
                    Throw New Exception("Error in Saving User Details.")
                End If
                dgUser.TableStyles.Clear()
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
    '    General functions used for OQ User and User Training.
    '--- funcInitialize - To Initialize form and to get values for OQ User and User Training Data from database and display them.
    '--- subCreateUserTrainingDataTable - To Create Columns in the Data Table.
    '--- funcGetOQUserTrainingRecords - To Get OQ User Training Records from Database into DataTable.
    '--- subFormatUserTrainingDataGrid - To format the User Training data in Data Grid.
    '--- funcSaveOQUserTrainingData - To Save the Entered Records into Database.
    '--- funcInsertOQUserTrainingData - To Add/Insert New User Training Data in Database.
    '--- funcUpdateOQUserTrainingData - To Update User Training Data in Database.
    '--- funcDeleteOQUserTrainingData - To Delete User Training Data from Database.

    '--- subCreateUserDataTable - To Create Columns in the Data Table.
    '--- funcGetOQUserRecords - To Get OQ User Records from Database into DataTable.
    '--- subFormatUserDataGrid - To format the User data into Data Grid.
    '--- funcSaveOQUserData - To Save the Entered Records into Database.
    '--- funcInsertOQUserData - To Add/Insert New User Data in Database.
    '--- funcUpdateOQUserData - To Update User Data in Database.
    '--- funcDeleteOQUserData - To Delete User Action Data from Database.

    Private Sub dtpUserDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        dgUser(dgUser.CurrentCell.RowNumber, dgUser.CurrentCell.ColumnNumber) = mdtpUserDate.Value
    End Sub


    Private Sub funcInitialize()
        '=====================================================================
        ' Procedure Name        :   funcInitailize
        ' Description           :   To Initialize form and to get values for OQ User and User Training Data from database and display them.
        ' Purpose               :   To Initialize form and to get values for OQ User and User Training Data from database and display them.
        ' Parameters Passed     :   None.
        ' Returns               :   None.
        ' Parameters Affected   :   None.
        ' Assumptions           :
        ' Dependencies          :
        ' Author                :   Gitesh
        ' Created               :   January, 2003 
        ' Revisions             : Pankaj 03 May 07
        '=====================================================================
        Dim intCount As Integer = 0
        Dim mobjTmpDt As DataTable
        Dim objDataRow As DataRow
        Try

            'mfrmUserTraining = Me
            mObjDataTable = New DataTable("OQUserTraining")
            mobjCADataTable = New DataTable("OQUser")

            mdtpUserDate = New DateTimePicker

            '--- Initialising Connection String
            'mstrOledbConnectionString = mclsDBFunctions.ConnectionString(CONST_IQOQPQ_DATABASENAME)

            '--- Initialising Connection 
            mobjOleDBconnection = New OleDbConnection(mstrOledbConnectionString)

            AddHandler mdtpUserDate.ValueChanged, AddressOf dtpUserDate_ValueChanged
            dgUser.Controls.Add(mdtpUserDate)
            mdtpUserDate.Visible = False
            mdtpUserDate.Format = DateTimePickerFormat.Custom
            mdtpUserDate.CustomFormat = "dd-MMM-yyyy"

            mObjDataTable.Columns.Add("SrNo")
            mObjDataTable.Columns.Add("TrainingType")
            mObjDataTable.Columns.Add("TrainingGiven")
            mObjDataTable.Columns.Add("TrainingComments")
            mObjDataTable.Columns.Add("TrainingID")

            'subCreateUserTrainingDataTable()

            'If funcGetPQTest2Records() Then
            '    subFormatUserTrainingDataGrid()
            'Else
            '    Throw New Exception("Error in Getting User Training Records.")
            'End If

            subCreateUserDataTable()

            mobjTmpDt = New DataTable
            mobjTmpDt = gobjDataAccess.funcGetOQUserTrainingRecords()

            If Not mobjTmpDt Is Nothing Then
                If Not mobjTmpDt.Rows.Count = 0 Then
                    For intCount = 0 To mobjTmpDt.Rows.Count - 1
                        objDataRow = mObjDataTable.NewRow
                        objDataRow.Item(ConstSrNo) = CInt(mobjTmpDt.Rows.Item(intCount).Item("TrainingID"))

                        'objDataRow.Item(ConstTrainingType) = CStr(mobjTmpDt.Rows.Item(intCount).Item("TrainingType"))'2.4.2010 by dinesh wagh
                        objDataRow.Item(ConstTrainingType) = gfuncWordWrap(CStr(mobjTmpDt.Rows.Item(intCount).Item("TrainingType")), 45)  '2.4.2010 by dinesh wagh

                        'Condition added by pankaj on 30 May 07

                        If (IsDBNull(mobjTmpDt.Rows.Item(intCount).Item("TrainingGiven"))) Then
                            objDataRow.Item(ConstTrainingGiven) = CStr("")
                        Else
                            objDataRow.Item(ConstTrainingGiven) = gfuncWordWrap(CStr(mobjTmpDt.Rows.Item(intCount).Item("TrainingGiven")), 32) '29.6.2010 by dinesh wagh
                        End If

                        If (IsDBNull(mobjTmpDt.Rows.Item(intCount).Item("TrainingComments"))) Then
                            objDataRow.Item(ConstTrainingComments) = CStr("")
                        Else
                            'objDataRow.Item(ConstTrainingComments) = CStr(mobjTmpDt.Rows.Item(intCount).Item("TrainingComments")) '2.4.2010 by dinesh wagh
                            objDataRow.Item(ConstTrainingComments) = gfuncWordWrap(CStr(mobjTmpDt.Rows.Item(intCount).Item("TrainingComments")), 28) '2.4.2010 by dinesh wagh
                        End If


                        objDataRow.Item(ConstTrainingID) = CInt(mobjTmpDt.Rows.Item(intCount).Item("TrainingID"))
                        mObjDataTable.Rows.Add(objDataRow)

                    Next
                End If
            End If

            If IsNothing(mObjDataTable) = True Then
                Throw New Exception("Error in Getting Equipment List Records.")
            Else
                subFormatUserTrainingDataGrid()
            End If

            mobjTmpDt = New DataTable
            mobjTmpDt = gobjDataAccess.funcGetOQUserRecords()

            If Not mobjTmpDt Is Nothing Then
                If Not mobjTmpDt.Rows.Count = 0 Then
                    For intCount = 0 To mobjTmpDt.Rows.Count - 1

                        objDataRow = mobjCADataTable.NewRow
                        objDataRow.Item(ConstSrNo) = intCount + 1 ' by Pankaj on 6 Dec 07'CInt(mobjTmpDt.Rows.Item(intCount).Item("UserID"))
                        objDataRow.Item(ConstUserName) = CStr(mobjTmpDt.Rows.Item(intCount).Item("UserName"))
                        objDataRow.Item(ConstUserDate) = CStr(mobjTmpDt.Rows.Item(intCount).Item("UserDate"))
                        objDataRow.Item(ConstUserID) = CInt(mobjTmpDt.Rows.Item(intCount).Item("UserID"))
                        mobjCADataTable.Rows.Add(objDataRow)
                        
                    Next
                End If
            End If

            If IsNothing(mobjCADataTable) = True Then
                Throw New Exception("Error in Getting Equipment List Records.")
            Else
                subFormatUserDataGrid()
            End If

            'If funcGetOQUserRecords() Then
            '    subFormatUserDataGrid()
            'Else
            '    Throw New Exception("Error in Getting User Records.")
            'End If

            mblnModeLockStatus = gobjDataAccess.funcCheckModeLocked(ENUM_IQOQPQ_STATUS.OQ)
            If (mblnModeLockStatus) Then
                dgTraining.ReadOnly = True
                dgUser.ReadOnly = True
            Else
                dgTraining.ReadOnly = False
                dgUser.ReadOnly = False
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

#Region "User Training Functions"

    Private Sub subCreateUserTrainingDataTable()
        '=====================================================================
        ' Procedure Name        :   subCreateUserTrainingDataTable
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
            objDataColumn.AutoIncrement = False
            mObjDataTable.Columns.Add(objDataColumn)

            mObjDataTable.Columns.Add(New DataColumn("TrainingType", GetType(String)))
            mObjDataTable.Columns.Add(New DataColumn("TrainingGiven", GetType(String)))
            mObjDataTable.Columns.Add(New DataColumn("TrainingComments", GetType(String)))
            mObjDataTable.Columns.Add(New DataColumn("TrainingID", GetType(Integer)))

        Catch ex As Exception
            '---------------------------------------------------------
            'Error logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = "Error in Creating User Training Data-Table."
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

    'Private Function funcGetPQTest2Records() As Boolean
    '    '=====================================================================
    '    ' Procedure Name        :   funcGetPQTest2Records
    '    ' Description           :   To Get PQ Test Records from Database and display them.
    '    ' Purpose               :   To Get PQ Test Records from Database and display them.
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
    '    Dim str_sql As String
    '    Dim reader_status, record_exists As Boolean
    '    Dim testID, temp_cnt As Integer
    '    Dim strTraingType, strTrainingGiven, strComments As String

    '    Try
    '        For temp_cnt = 1 To 6
    '            testID = temp_cnt

    '            str_sql = "Select * from OQUserTraining where TrainingID = " & testID & ""
    '            'record_exists = mclsDBFunctions.RecordExists(str_sql, mobjOleDBconnection)
    '            If record_exists Then
    '                If Not (funcGetOQUserTrainingRecords(testID)) Then
    '                    Throw New Exception("Error in Getting Test Details.")
    '                End If
    '            Else
    '                strTraingType = funcGetTrainingType(testID)
    '                strTrainingGiven = ""
    '                strComments = ""
    '                If funcInsertOQUserTrainingData(testID, strTraingType, strTrainingGiven, strComments) Then
    '                    If Not (funcGetOQUserTrainingRecords(testID)) Then
    '                        Throw New Exception("Error in Getting Test Details.")
    '                    End If
    '                Else
    '                    Throw New Exception("Error in Saving Test Details.")
    '                End If
    '            End If
    '        Next
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

    'Private Function funcGetOQUserTrainingRecords(ByVal inttestId As Integer) As Boolean
    '    '=====================================================================
    '    ' Procedure Name        :   funcGetOQUserTrainingRecords
    '    ' Description           :   To Get OQ User Training Records from Database into DataTable.
    '    ' Purpose               :   To Get OQ User Training Records from Database into DataTable.
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
    '    Dim sql_string, str_date As String
    '    Dim reader_status As Boolean
    '    Dim rec_cnt As Integer
    '    Dim dt_Corrective As Date

    '    Try
    '        sql_string = " Select TrainingType ,TrainingGiven , TrainingComments " & _
    '                     " from OQUserTraining where TrainingID = " & inttestId & " "

    '        'reader_status = mclsDBFunctions.GetRecords(sql_string, mobjOleDBconnection, objReader)

    '        If Not (reader_status) Then
    '            Throw New Exception("Error in Opening Connection during Getting User Training Details.")
    '        End If

    '        rec_cnt = 1
    '        While objReader.Read
    '            objDataRow = mObjDataTable.NewRow()

    '            objDataRow("SrNo") = inttestId
    '            objDataRow("TrainingType") = CStr(objReader.Item("TrainingType"))
    '            If IsDBNull(objReader.Item("TrainingGiven")) = False Then
    '                objDataRow("TrainingGiven") = CStr(objReader.Item("TrainingGiven"))
    '            Else
    '                objDataRow("TrainingGiven") = ""
    '            End If
    '            If IsDBNull(objReader.Item("TrainingComments")) = False Then
    '                objDataRow("TrainingComments") = CStr(objReader.Item("TrainingComments"))
    '            Else
    '                objDataRow("TrainingComments") = ""
    '            End If
    '            objDataRow("TrainingID") = inttestId

    '            mObjDataTable.Rows.Add(objDataRow)
    '            rec_cnt = rec_cnt + 1
    '        End While
    '        objReader.Close()

    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        'Error logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = "Error in Getting User Training Records."
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

    Private Sub subFormatUserTrainingDataGrid()
        Dim objTextColumn As DataGridTextBoxColumn
        Dim objDataView As New DataView
        Try

            dgTraining.TableStyles.Clear()
            objDataView.Table = mObjDataTable
            objDataView.AllowNew = False
            dgTraining.DataSource = objDataView

            mobjGridTableStyle.PreferredRowHeight = 34 '2.4.2010 by dinesh wagh
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

            mobjGridTableStyle.MappingName = "OQUserTraining"

            objTextColumn = New DataGridTextBoxColumn

            objTextColumn.MappingName = "SrNo"
            objTextColumn.HeaderText = "Sr.No."
            objTextColumn.Width = 50 '40 by dinesh wagh 2.4.2010
            objTextColumn.ReadOnly = True
            objTextColumn.NullText = ""
            objTextColumn.Alignment = HorizontalAlignment.Center

            mobjGridTableStyle.GridColumnStyles.Add(objTextColumn)

            objTextColumn = New DataGridTextBoxColumn
            objTextColumn.MappingName = "TrainingType"
            objTextColumn.HeaderText = "Type of Training"
            objTextColumn.Width = 250 '210
            objTextColumn.ReadOnly = True
            objTextColumn.NullText = ""
            mobjGridTableStyle.GridColumnStyles.Add(objTextColumn)

            objTextColumn = New DataGridTextBoxColumn
            objTextColumn.MappingName = "TrainingGiven"
            objTextColumn.HeaderText = "Check"
            objTextColumn.Width = 175
            objTextColumn.ReadOnly = False
            objTextColumn.NullText = ""
            'objTextColumn.Alignment = HorizontalAlignment.Center '29.6.2010 by dinesh wagh
            
            mobjGridTableStyle.GridColumnStyles.Add(objTextColumn)

            objTextColumn = New DataGridTextBoxColumn
            objTextColumn.MappingName = "TrainingComments"
            objTextColumn.HeaderText = "Training Comments"
            objTextColumn.Width = 160 '155 '2.4.2010 by dinesh wagh
            objTextColumn.ReadOnly = False
            objTextColumn.NullText = ""
            'objTextColumn.Alignment = HorizontalAlignment.Center '29.6.2010 by dinesh wagh
           
            mobjGridTableStyle.GridColumnStyles.Add(objTextColumn)
            objTextColumn = New DataGridTextBoxColumn
            objTextColumn.MappingName = "TrainingID"
            objTextColumn.HeaderText = "TrainingID"
            objTextColumn.Width = 0
            objTextColumn.ReadOnly = True
            objTextColumn.NullText = ""

            mobjGridTableStyle.GridColumnStyles.Add(objTextColumn)

            mobjGridTableStyle.GridLineColor = Color.Black
            dgTraining.TableStyles.Add(mobjGridTableStyle)

        Catch ex As Exception
            '---------------------------------------------------------
            'Error logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = "Error in Formating User Training Data-Grid."
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

    Public Function funcSaveOQUserTrainingData() As Boolean
        '=====================================================================
        ' Procedure Name        :   funcSaveOQUserTrainingData
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

        Dim intRecordCount, intUserTrainingID, temp_cnt As Integer
        Dim strTrainingType, strTrainingGiven, strTrainingComments As String
        Dim status As Boolean = True

        Try
            intRecordCount = mObjDataTable.Rows.Count

            For temp_cnt = 0 To (intRecordCount - 1)
                '--- To Check if Training ID is Null.
                'If IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("TrainingID").Ordinal)) Then
                '    strTrainingType = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("TrainingType").Ordinal)
                '    strTrainingGiven = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("TrainingGiven").Ordinal)
                '    strTrainingComments = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("TrainingComments").Ordinal)

                '    status = funcInsertOQUserTrainingData(temp_cnt + 1, strTrainingType, strTrainingGiven, strTrainingComments)
                '    If Not (status) Then
                '        Throw New Exception("Error in Saving User Training Details.")
                '    End If
                'Else
                intUserTrainingID = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("TrainingID").Ordinal)
                strTrainingType = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("TrainingType").Ordinal)
                strTrainingType = strTrainingType.Replace(vbCrLf, " ") '29.6.2010 by dinesh wagh

                If Not (IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("TrainingGiven").Ordinal))) Then
                    strTrainingGiven = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("TrainingGiven").Ordinal)
                    strTrainingGiven = strTrainingGiven.Replace(vbCrLf, " ") '29.6.2010 by dinesh wagh
                Else
                    strTrainingGiven = ""
                End If

                If Not (IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("TrainingComments").Ordinal))) Then
                    strTrainingComments = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("TrainingComments").Ordinal)
                    strTrainingComments = strTrainingComments.Replace(vbCrLf, " ") '29.6.2010 by dinesh wagh
                Else
                    strTrainingComments = ""
                End If

                status = gobjDataAccess.funcUpdateOQUserTrainingData(strTrainingType, strTrainingGiven, strTrainingComments, intUserTrainingID)
                If Not (status) Then
                    Throw New Exception("Error in Updating User Training Details.")
                End If
                'End If
            Next

        Catch ex As Exception
            '---------------------------------------------------------
            'Error logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = "Error in Saving User Training Details."
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

    'Private Function funcInsertOQUserTrainingData(ByVal intUserTrainingID As Integer, ByVal strTrainingType As String, ByVal strTrainingGiven As String, ByVal strTrainingComments As String) As Boolean
    '    '=====================================================================
    '    ' Procedure Name        :   funcInsertOQUserTrainingData
    '    ' Description           :   To Add/Insert New User Training Data in Database.
    '    ' Purpose               :   To Add/Insert New User Training Data in Database.
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
    '            Throw New Exception("Error in Opening Connection during Saving User Training Details.")
    '        End If

    '        '--- Generating Next User Training ID. 
    '        'intUserTrainingID = mclsDBFunctions.GetNextID("OQUserTraining", "TrainingID", mobjOleDBconnection)

    '        '---  Query for adding  data to EquipmentList
    '        str_sql = " Insert into OQUserTraining " & _
    '                  " (TrainingID ,TrainingType ,TrainingGiven ,TrainingComments) " & _
    '                  " values(?,?,?,?) "

    '        '--- Providing command object. 
    '        With objCommand
    '            .Connection = mobjOleDBconnection
    '            .CommandType = CommandType.Text
    '            .CommandText = str_sql
    '            .Parameters.Add("TrainingID", OleDbType.Numeric).Value = intUserTrainingID
    '            .Parameters.Add("TrainingType", OleDbType.VarChar, 250).Value = strTrainingType
    '            .Parameters.Add("TrainingGiven", OleDbType.VarChar, 250).Value = strTrainingGiven
    '            .Parameters.Add("TrainingComments", OleDbType.VarChar, 250).Value = strTrainingComments
    '            .ExecuteNonQuery()
    '        End With

    '        objCommand.Dispose()
    '        Status = True

    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        '--- Error logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = "Error in Saving User Training Details."
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

    'Private Function funcUpdateOQUserTrainingData(ByVal strTrainingType As String, ByVal strTrainingGiven As String, ByVal strTrainingComments As String, ByVal intUserTrainingID As Integer) As Boolean
    '    '=====================================================================
    '    ' Procedure Name        :   funcUpdateOQUserTrainingData
    '    ' Description           :   To Update User Training Data in Database.
    '    ' Purpose               :   To Update User Training Data in Database.
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
    '            Throw New Exception("Error in Opening Connection during Updating User Training Details.")
    '        End If

    '        '---  Query for adding  data  
    '        str_sql = " Update OQUserTraining " & _
    '                  " Set TrainingType = ? ,TrainingGiven = ? ,TrainingComments = ? " & _
    '                  " where TrainingID = " & intUserTrainingID & " "

    '        '--- Providing command object for EquimentList
    '        With objCommand
    '            .Connection = mobjOleDBconnection
    '            .CommandType = CommandType.Text
    '            .CommandText = str_sql
    '            .Parameters.Add("TrainingType", OleDbType.VarChar, 250).Value = strTrainingType
    '            .Parameters.Add("TrainingGiven", OleDbType.VarChar, 250).Value = strTrainingGiven
    '            .Parameters.Add("TrainingComments", OleDbType.VarChar, 250).Value = strTrainingComments
    '            .ExecuteNonQuery()
    '        End With

    '        objCommand.Dispose()
    '        Status = True

    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        '--- Error logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = "Error in Updating User Training Details."
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

    'Private Function funcDeleteOQUserTrainigData(ByVal intUserTrainingID As Integer) As Boolean
    '    '=====================================================================
    '    ' Procedure Name        :   funcDeleteOQUserTrainigData
    '    ' Description           :   To Delete User Training Data from Database.
    '    ' Purpose               :   To Delete User Training Data from Database.
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
    '            Throw New Exception("Error in Opening Connection during Deleting User Training Details.")
    '        End If

    '        '--- Query to Delete from Database
    '        str_sql = " Delete * from OQUserTraining " & _
    '                  " where TrainingID = " & intUserTrainingID & " "

    '        'Status = mclsDBFunctions.AddORDeleteRecord(str_sql, mobjOleDBconnection)
    '        If (Status = False) Then
    '            MessageBox.Show("Problem in Deleting record")
    '        End If

    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        '--- Error logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = "Error in Deleting User Training Details."
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

#Region "User Functions"

    Private Sub subCreateUserDataTable()
        '=====================================================================
        ' Procedure Name        :   subCreateUserDataTable
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
            'objDataColumn.AutoIncrement = True
            '  objDataColumn.AutoIncrementSeed = 1
            '  objDataColumn.AutoIncrementStep = 1
            mobjCADataTable.Columns.Add(objDataColumn)

            mobjCADataTable.Columns.Add(New DataColumn("UserName", GetType(String)))
            mobjCADataTable.Columns.Add(New DataColumn("UserDate", GetType(Date)))
            mobjCADataTable.Columns.Add(New DataColumn("UserID", GetType(Integer)))

        Catch ex As Exception
            '---------------------------------------------------------
            'Error logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = "Error in Creating User Details Data-Table."
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

    'Private Function funcGetOQUserRecords() As Boolean
    '    '=====================================================================
    '    ' Procedure Name        :   funcGetOQUserRecords
    '    ' Description           :   To Get OQ User Records from Database into DataTable.
    '    ' Purpose               :   To Get OQ User Records from Database into DataTable.
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
    '        sql_string = " Select UserID ,UserName ,UserDate " & _
    '                     " from OQUser "

    '        'reader_status = mclsDBFunctions.GetRecords(sql_string, mobjOleDBconnection, objReader)

    '        If Not (reader_status) Then
    '            Throw New Exception("Error in Opening Connection during Getting User Details.")
    '        End If

    '        rec_cnt = 1
    '        While objReader.Read
    '            objDataRow = mobjCADataTable.NewRow()

    '            objDataRow("SrNo") = rec_cnt
    '            objDataRow("UserName") = CStr(objReader.Item("UserName"))
    '            If IsDBNull(objReader.Item("UserDate")) Then
    '            Else
    '                objDataRow("UserDate") = CDate(objReader.Item("UserDate"))
    '            End If
    '            'objDataRow("UserDate") = CDate(objReader.Item("UserDate"))
    '            objDataRow("UserID") = Convert.ToInt32(objReader.Item("UserID"))

    '            mobjCADataTable.Rows.Add(objDataRow)
    '            rec_cnt = rec_cnt + 1
    '        End While
    '        objReader.Close()

    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        'Error logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = "Error in Getting User Details Records."
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

    Private Sub subFormatUserDataGrid()
        Dim objTextColumn As DataGridTextBoxColumn

        Try
            dgUser.TableStyles.Clear()
            mobjDataView.Table = mobjCADataTable
            mobjDataView.AllowNew = True
            dgUser.DataSource = mobjDataView
            'dgUser.ReadOnly = False

            mobjCAGridTableStyle.RowHeadersVisible = False
            mobjCAGridTableStyle.ResetAlternatingBackColor()
            mobjCAGridTableStyle.ResetBackColor()
            mobjCAGridTableStyle.ResetForeColor()
            mobjCAGridTableStyle.ResetGridLineColor()
            mobjCAGridTableStyle.BackColor = Color.AliceBlue
            mobjCAGridTableStyle.GridLineColor = Color.Black
            mobjCAGridTableStyle.HeaderBackColor = Color.FromArgb(205, 225, 250)
            mobjCAGridTableStyle.HeaderForeColor = Color.Black
            mobjCAGridTableStyle.AlternatingBackColor = Color.AliceBlue
            mobjCAGridTableStyle.AllowSorting = False

            mobjCAGridTableStyle.MappingName = "OQUser"

            objTextColumn = New DataGridTextBoxColumn
            objTextColumn.MappingName = "SrNo"
            objTextColumn.HeaderText = "Sr.No."
            objTextColumn.Width = 50
            objTextColumn.ReadOnly = True
            objTextColumn.NullText = ""
            objTextColumn.Alignment = HorizontalAlignment.Center
            mobjCAGridTableStyle.GridColumnStyles.Add(objTextColumn)

            objTextColumn = New DataGridTextBoxColumn
            objTextColumn.MappingName = "UserName"
            objTextColumn.HeaderText = "User Name"
            objTextColumn.Width = 410 '380 2.4.2010 by dinesh wagh
            objTextColumn.ReadOnly = False
            objTextColumn.NullText = ""
            mobjCAGridTableStyle.GridColumnStyles.Add(objTextColumn)

            objTextColumn = New DataGridTextBoxColumn
            objTextColumn.MappingName = "UserDate"
            objTextColumn.HeaderText = "Date"
            objTextColumn.Width = 175 '150 2.4.2010 by dinesh wagh
            objTextColumn.ReadOnly = False
            objTextColumn.Format = "dd-MMM-yyyy"
            objTextColumn.NullText = ""
            objTextColumn.Alignment = HorizontalAlignment.Center
            mobjCAGridTableStyle.GridColumnStyles.Add(objTextColumn)

            objTextColumn = New DataGridTextBoxColumn
            objTextColumn.MappingName = "UserID"
            objTextColumn.HeaderText = "UserID"
            objTextColumn.Width = 0
            objTextColumn.ReadOnly = True
            objTextColumn.NullText = ""
            mobjCAGridTableStyle.GridColumnStyles.Add(objTextColumn)

            mobjCAGridTableStyle.GridLineColor = Color.Black
            dgUser.TableStyles.Add(mobjCAGridTableStyle)

        Catch ex As Exception
            '---------------------------------------------------------
            'Error logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = "Error in Formating User Details Data-Grid."
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

    Public Function funcSaveOQUserData() As Boolean
        '=====================================================================
        ' Procedure Name        :   funcSaveOQUserData
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

        Dim intRecordCount, intUserID, temp_cnt As Integer
        Dim strUserName As String
        Dim dtUserDate As Date
        Dim status As Boolean = True

        Try
            intRecordCount = mobjCADataTable.Rows.Count

            For temp_cnt = 0 To (intRecordCount - 1)
                '--- To Check if Completed / Accepted ID is Null.
                If IsDBNull(mobjCADataTable.Rows(temp_cnt).ItemArray.GetValue(mobjCADataTable.Columns.Item("UserID").Ordinal)) Then
                    strUserName = mobjCADataTable.Rows(temp_cnt).ItemArray.GetValue(mobjCADataTable.Columns.Item("UserName").Ordinal)
                    dtUserDate = CDate(mobjCADataTable.Rows(temp_cnt).ItemArray.GetValue(mobjCADataTable.Columns.Item("UserDate").Ordinal))
                    status = gobjDataAccess.funcInsertOQUserData(strUserName, dtUserDate)
                    If Not (status) Then
                        Throw New Exception("Error in Saving User Details.")
                    End If
                Else

                    If IsDBNull(mobjCADataTable.Rows(temp_cnt).ItemArray.GetValue(mobjCADataTable.Columns.Item("UserName").Ordinal)) Or IsDBNull(mobjCADataTable.Rows(temp_cnt).ItemArray.GetValue(mobjCADataTable.Columns.Item("UserDate").Ordinal)) Then
                        intUserID = mobjCADataTable.Rows(temp_cnt).ItemArray.GetValue(mobjCADataTable.Columns.Item("UserID").Ordinal)
                        status = gobjDataAccess.funcDeleteOQUserData(intUserID)
                        If Not (status) Then
                            Throw New Exception("Error in Deleting User Details.")
                        End If

                    Else

                        intUserID = mobjCADataTable.Rows(temp_cnt).ItemArray.GetValue(mobjCADataTable.Columns.Item("UserID").Ordinal)
                        strUserName = mobjCADataTable.Rows(temp_cnt).ItemArray.GetValue(mobjCADataTable.Columns.Item("UserName").Ordinal)
                        dtUserDate = mobjCADataTable.Rows(temp_cnt).ItemArray.GetValue(mobjCADataTable.Columns.Item("UserDate").Ordinal)
                        status = gobjDataAccess.funcUpdateOQUserData(strUserName, dtUserDate, intUserID)
                        If Not (status) Then
                            Throw New Exception("Error in Updating User Details.")
                        End If
                    End If
                End If
            Next

        Catch ex As Exception
            '---------------------------------------------------------
            'Error logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = "Error in Saving User Details."
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

    'Private Function funcInsertOQUserData(ByVal strUserName As String, ByVal dtUserDate As Date) As Boolean
    '    '=====================================================================
    '    ' Procedure Name        :   funcInsertOQUserData
    '    ' Description           :   To Add/Insert New User Data in Database.
    '    ' Purpose               :   To Add/Insert New User Data in Database.
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
    '    Dim intUserID As Integer

    '    Try
    '        'Status = mclsDBFunctions.OpenConnection(mobjOleDBconnection)
    '        If Not (Status) Then
    '            Throw New Exception("Error in Opening Connection during Saving User Details.")
    '        End If

    '        '--- Generating Next User ID. 
    '        'intUserID = mclsDBFunctions.GetNextID("OQUser", "UserID", mobjOleDBconnection)

    '        '---  Query for adding  data to EquipmentList
    '        str_sql = " Insert into OQUser " & _
    '                  " (UserID ,UserName ,UserDate) " & _
    '                  " values(?,?,?) "

    '        '--- Providing command object. 
    '        With objCommand
    '            .Connection = mobjOleDBconnection
    '            .CommandType = CommandType.Text
    '            .CommandText = str_sql
    '            .Parameters.Add("UserID", OleDbType.Numeric).Value = intUserID
    '            .Parameters.Add("UserName", OleDbType.VarChar, 50).Value = strUserName
    '            .Parameters.Add("UserDate", OleDbType.DBDate).Value = dtUserDate
    '            .ExecuteNonQuery()
    '        End With

    '        objCommand.Dispose()
    '        Status = True

    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        '--- Error logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = "Error in Saving User Details."
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

    'Private Function funcUpdateOQUserData(ByVal strUserName As String, ByVal dtUserDate As String, ByVal intUserID As Integer) As Boolean
    '    '=====================================================================
    '    ' Procedure Name        :   funcUpdateOQUserData
    '    ' Description           :   To Update User Data in Database.
    '    ' Purpose               :   To Update User Data in Database.
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
    '            Throw New Exception("Error in Opening Connection during Updating User Details.")
    '        End If

    '        '---  Query for adding  data 
    '        str_sql = " Update OQUser " & _
    '                  " Set UserName = ? ,UserDate = ? " & _
    '                  " where UserID = " & intUserID & " "

    '        '--- Providing command object  
    '        With objCommand
    '            .Connection = mobjOleDBconnection
    '            .CommandType = CommandType.Text
    '            .CommandText = str_sql
    '            .Parameters.Add("UserName", OleDbType.VarChar, 250).Value = strUserName
    '            .Parameters.Add("UserDate", OleDbType.DBDate).Value = dtUserDate
    '            .ExecuteNonQuery()
    '        End With

    '        objCommand.Dispose()
    '        Status = True

    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        '--- Error logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = "Error in Updating User Details."
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

    'Private Function funcDeleteOQUserData(ByVal intUserID As Integer) As Boolean
    '    '=====================================================================
    '    ' Procedure Name        :   funcDeleteOQUserData
    '    ' Description           :   To Delete User Data from Database.
    '    ' Purpose               :   To Delete User Data from Database.
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
    '            Throw New Exception("Error in Opening Connection during Deleting User Details.")
    '        End If

    '        '--- Query to Delete from Database
    '        str_sql = " Delete * from OQUser " & _
    '                  " where UserID = " & intUserID & " "

    '        'Status = mclsDBFunctions.AddORDeleteRecord(str_sql, mobjOleDBconnection)
    '        If (Status = False) Then
    '            Throw New Exception("Error in Deleting User Details.")
    '        End If

    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        '--- Error logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = "Error in Deleting User Details."
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

    Private Sub dgUser_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgUser.CurrentCellChanged
        Try
            If Not (mblnModeLockStatus) Then
                mobjCADataTable.Columns(0).ReadOnly = False
                dgUser.Item(dgUser.CurrentRowIndex, 0) = dgUser.CurrentRowIndex + 1
                mobjCADataTable.Columns(0).ReadOnly = True
                If (dgUser.CurrentCell.ColumnNumber = 2) Then
                    mdtpUserDate.Top = dgUser.GetCurrentCellBounds().Top
                    mdtpUserDate.Left = dgUser.GetCurrentCellBounds().Left
                    mdtpUserDate.Width = dgUser.GetCurrentCellBounds().Width
                    mdtpUserDate.Height = dgUser.GetCurrentCellBounds().Height

                    If (dgUser.CurrentCell.RowNumber) > 0 Then

                        If IsDBNull(dgUser(dgUser.CurrentCell.RowNumber, 2)) = False Then
                            mdtpUserDate.Value = Format(CDate(dgUser(dgUser.CurrentCell.RowNumber, 2)), "dd - MMM - yyyy")
                        Else
                            mdtpUserDate.Value = Format(DateTime.Today, "dd-MMM-yyyy")
                            dgUser(dgUser.CurrentCell.RowNumber, dgUser.CurrentCell.ColumnNumber) = mdtpUserDate.Value
                        End If
                    Else
                        dgUser(dgUser.CurrentCell.RowNumber, dgUser.CurrentCell.ColumnNumber) = mdtpUserDate.Value
                    End If
                    mdtpUserDate.Visible = True
                Else
                    mdtpUserDate.Width = 0
                    mdtpUserDate.Visible = False
                End If
            End If
            If dgUser.CurrentRowIndex >= 6 Then 'user changed to 6. by dinesh wagh Suggested by : V.C.K on 9.7.2010
                mobjDataView.AllowNew = False
            End If

        Catch ex As Exception
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = "Error in Formating User Training Data-Grid."
            gobjErrorHandler.WriteErrorLog(ex)
        Finally
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
        End Try
    End Sub
#Region "Constant Test Data"

    Private Function funcGetTrainingType(ByVal testNo As Integer) As String
        Dim strtestName As String

        Select Case testNo
            Case 1
                strtestName = "Instrument Setup"
            Case 2
                strtestName = "Basic operation of Main Menu"
            Case 3
                strtestName = "System operation & condition of operation (parameter setting and operation)"
            Case 4
                strtestName = "Basic trouble shooting and maintenance"
            Case 5
                strtestName = "Controlling system for external accessories(if any)"
            Case 6
                strtestName = "Operational training and demonstration"
            Case Else
                strtestName = ""
        End Select

        Return strtestName

    End Function
#End Region

    Private Sub dgTraining_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgTraining.CurrentCellChanged
        'new sub added by : dinesh wagh on 29.6.2010
        'to wrap the text as soon as user entered the text.
        If mblnAvoidProcessing = True Then Exit Sub
        Dim intRowIndex, intColumnIndex As Integer
        Dim strString As String
        Try
            intRowIndex = dgTraining.CurrentCell.RowNumber
            intColumnIndex = dgTraining.CurrentCell.ColumnNumber
            mblnAvoidProcessing = True
            If Not IsDBNull(dgTraining.Item(mintRowIndex, mintColumnIndex)) Then
                If mintColumnIndex = 2 Or mintColumnIndex = 3 Then
                    strString = dgTraining.Item(mintRowIndex, mintColumnIndex)
                    If Not (strString = "") Then
                        strString = strString.Replace(vbCrLf, " ")
                        dgTraining.Item(mintRowIndex, mintColumnIndex) = gfuncWordWrap(strString, 32)
                    End If
                End If
            End If
            dgTraining.CurrentCell = New DataGridCell(intRowIndex, intColumnIndex)
            mintRowIndex = dgTraining.CurrentCell.RowNumber
            mintColumnIndex = dgTraining.CurrentCell.ColumnNumber
            mblnAvoidProcessing = False
        Catch ex As Exception
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = "Error in Formating User Training Data-Grid."
            gobjErrorHandler.WriteErrorLog(ex)
        Finally
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
        End Try
    End Sub
End Class
