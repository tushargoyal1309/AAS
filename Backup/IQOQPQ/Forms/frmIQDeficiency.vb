Option Explicit On 

Imports System.Data
Imports System.Data.OleDb

Public Class frmIQDeficiency
    Inherits System.Windows.Forms.Form

#Region " Module level Declarations "
    Private mblnModeLockStatus As Boolean
    Private mintMode As Integer
    Private mstrOledbConnectionString As String
    Private mobjOleDBconnection As OleDbConnection
    'Public mclsDBFunctions As New clsDatabaseFunctions

    Private mObjDataTable, mobjCADataTable As DataTable
    Dim mobjGridTableStyle, mobjCAGridTableStyle As New DataGridTableStyle
    Dim mdtpCorrectiveDate As DateTimePicker
    Private Const CONST_DateColumnNo = 4
    Private mobjDataView As New DataView
    Private mobjDataView1 As New DataView

    '30.6.2010 by dinesh wagh
    '------------------------------------
    Dim mintRowIndex, mintColumnIndex As Integer
    Private Const CONST_DetailsOfDeficiency_Size = 28
    Private Const CONST_CorrectiveAction_Size = 25
    Private Const CONST_ActionBy_Size = 25

    Private Enum EnumColumns
        DetailOfDeficiency = 1
        CorrectiveAction = 2
        ActionBy = 3
    End Enum
    '---------------------------
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

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        mintMode = intMode

        'code added by : dinesh wagh on 25.7.2010
        'AS SAME FORM IS USE FOR ALL 3 MODE.
        '------------------------------------------------
        Select Case mintMode
            Case ENUM_IQOQPQ_STATUS.IQ
                lblHeader.Text = "C.III  DEFICIENCIES FOUND AND CORRECTIVE ACTION "
            Case ENUM_IQOQPQ_STATUS.OQ
                lblHeader.Text = "D.IV  DEFICIENCIES FOUND AND CORRECTIVE ACTION "
            Case ENUM_IQOQPQ_STATUS.PQ
                lblHeader.Text = "E.III  DEFICIENCIES FOUND AND CORRECTIVE ACTION "
        End Select
        '------------------------------------------------

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
    Friend WithEvents lblHeader As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents dgDeficiency As System.Windows.Forms.DataGrid
    Friend WithEvents dgCompletedAccepted As System.Windows.Forms.DataGrid
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmIQDeficiency))
        Me.lblHeader = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.dgCompletedAccepted = New System.Windows.Forms.DataGrid
        Me.dgDeficiency = New System.Windows.Forms.DataGrid
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.dgCompletedAccepted, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgDeficiency, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblHeader
        '
        Me.lblHeader.BackColor = System.Drawing.Color.AliceBlue
        Me.lblHeader.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeader.Location = New System.Drawing.Point(35, 7)
        Me.lblHeader.Name = "lblHeader"
        Me.lblHeader.Size = New System.Drawing.Size(533, 18)
        Me.lblHeader.TabIndex = 1
        Me.lblHeader.Text = "C.III  DEFICIENCIES FOUND AND CORRECTIVE ACTION "
        Me.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.dgCompletedAccepted)
        Me.Panel1.Controls.Add(Me.dgDeficiency)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(470, 528)
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
        Me.Panel2.Size = New System.Drawing.Size(468, 32)
        Me.Panel2.TabIndex = 21
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
        'dgCompletedAccepted
        '
        Me.dgCompletedAccepted.BackgroundColor = System.Drawing.Color.AliceBlue
        Me.dgCompletedAccepted.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.dgCompletedAccepted.CaptionVisible = False
        Me.dgCompletedAccepted.DataMember = ""
        Me.dgCompletedAccepted.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgCompletedAccepted.Location = New System.Drawing.Point(69, 435)
        Me.dgCompletedAccepted.Name = "dgCompletedAccepted"
        Me.dgCompletedAccepted.ParentRowsVisible = False
        Me.dgCompletedAccepted.ReadOnly = True
        Me.dgCompletedAccepted.RowHeadersVisible = False
        Me.dgCompletedAccepted.Size = New System.Drawing.Size(454, 80)
        Me.dgCompletedAccepted.TabIndex = 20
        '
        'dgDeficiency
        '
        Me.dgDeficiency.BackgroundColor = System.Drawing.Color.AliceBlue
        Me.dgDeficiency.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.dgDeficiency.CaptionVisible = False
        Me.dgDeficiency.DataMember = ""
        Me.dgDeficiency.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgDeficiency.Location = New System.Drawing.Point(8, 48)
        Me.dgDeficiency.Name = "dgDeficiency"
        Me.dgDeficiency.ParentRowsVisible = False
        Me.dgDeficiency.ReadOnly = True
        Me.dgDeficiency.RowHeadersVisible = False
        Me.dgDeficiency.Size = New System.Drawing.Size(576, 375)
        Me.dgDeficiency.TabIndex = 18
        '
        'frmIQDeficiency
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(470, 536)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmIQDeficiency"
        Me.Tag = "2"
        Me.Text = "Deficiency And Corrective Action Plan"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.dgCompletedAccepted, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgDeficiency, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Constants"

    Private Const ConstSrNo As String = "SrNo"
    Private Const ConstCompletedBy As String = "CompletedBy"
    Private Const ConstAcceptedBy As String = "AcceptedBy"
    Private Const ConstCompletedAcceptedByID As String = "CompletedAcceptedByID"

    Private Const ConstDeficiencyDetails As String = "DeficiencyDetails"
    Private Const ConstCorrectiveActionPlan As String = "CorrectiveActionPlan"
    Private Const ConstCorrectiveActionBy As String = "CorrectiveActionBy"
    Private Const ConstCorrectiveActionDate As String = "CorrectiveActionDate"
    Private Const ConstDeficiencyID As String = "DeficiencyID"

#End Region

#Region " Form Events "

    Private Sub frmIQDeficiency_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

    Private Sub frmIQDeficiency_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Try
            If Not (mblnModeLockStatus) Then
                dgDeficiency.CurrentCell() = (New DataGridCell(dgDeficiency.CurrentRowIndex + 1, 0))
                If Not funcSaveDeficiencyData() Then
                    Throw New Exception("Error in Saving Deficiency Corrective Action Data.")
                End If
                dgDeficiency.TableStyles.Clear()

                'if condition removed on 29.3.2010
                'by dinesh wagh
                'If (mintMode = ENUM_IQOQPQ_STATUS.PQ) Then
                'Else
                dgCompletedAccepted.CurrentCell() = (New DataGridCell(dgCompletedAccepted.CurrentRowIndex + 1, 0))
                If Not funcSaveCompleteAcceptData() Then
                    Throw New Exception("Error in Saving Customer Representative Data.")
                End If
                dgCompletedAccepted.TableStyles.Clear()
                'End If
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
    '    General functions used for Deficiency and Corrective Action.
    '--- funcInitialize - To Initialize form and to get values for Deficiency/Corrective Action and Completed/Accepted by Data from database and display them.
    '--- subCreateDeficiencyDataTable - To Create Columns in the Data Table.
    '--- funcGetDeficiencyRecords - To Get Deficiency/Corrective Action Records from Database into DataTable.
    '--- subFormatDeficiencyDataGrid - To format the Deficiency/Corrective Action Data Grid.
    '--- funcSaveDeficiencyData - To Save the Entered Records into Database.
    '--- funcInsertDeficiencyData - To Add/Insert New Deficiency/Corrective Action Data in Database.
    '--- funcUpdateDeficiencyData - To Update Deficiency/Corrective Action Data in Database.
    '--- funcDeleteDeficiencyData - To Delete Deficiency/Corrective Action Data from Database.

    '--- subCreateCompleteAcceptDataTable - To Create Columns in the Data Table.
    '--- funcGetCompleteAcceptRecords - To Get Completed/Accepted By Records from Database into DataTable.
    '--- subFormatCompleteAcceptDataGrid - To format the Completed/Accepted By Data Grid.
    '--- funcSaveCompleteAcceptData - To Save the Entered Records into Database.
    '--- funcInsertCompleteAcceptData - To Add/Insert New Completed/Accepted By Data in Database.
    '--- funcUpdateCompleteAcceptData - To Update Completed/Accepted By Data in Database.
    '--- funcDeleteCompleteAcceptData - To Delete Completed/Accepted By Action Data from Database.

    Private Sub funcInitialize()
        '=====================================================================
        ' Procedure Name        :   funcInitailize
        ' Description           :   To Initialize form and to get values for IQ Deficiency/Corrective Action and Completed/Accepted by Data from database and display them.
        ' Purpose               :   To Initialize form and to get values for IQ Deficiency/Corrective Action and Completed/Accepted by Data from database and display them.
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


            'mfrmIQDeficiency = Me
            'mfrmOQDeficiency = Me
            'mfrmPQDeficiency = Me

            mObjDataTable = New DataTable("DeficiencyAction")
            mdtpCorrectiveDate = New DateTimePicker


            '--- To Add Run-Time DateTime Picker Control
            AddHandler mdtpCorrectiveDate.ValueChanged, AddressOf dtpCorrectiveDate_ValueChanged
            dgDeficiency.Controls.Add(mdtpCorrectiveDate)
            mdtpCorrectiveDate.Visible = False
            mdtpCorrectiveDate.Format = DateTimePickerFormat.Custom
            mdtpCorrectiveDate.CustomFormat = "dd-MMM-yyyy"


            'code commented by ; dinesh wagh on 29.3.2010
            'purpose : for PQ shows the table.

            'If (mintMode = ENUM_IQOQPQ_STATUS.PQ) Then
            '    ' grpboxCompletAccept.Visible = False
            '    dgCompletedAccepted.Visible = False
            'Else

            mobjCADataTable = New DataTable("CompletedAcceptedBy")

            subCreateCompleteAcceptDataTable()

            objDtTmp = New DataTable

            objDtTmp = gobjDataAccess.funcGetCompleteAcceptRecords(mintMode)

            If Not objDtTmp Is Nothing Then
                If Not objDtTmp.Rows.Count = 0 Then
                    For intCount = 0 To objDtTmp.Rows.Count - 1
                        objDataRow = mobjCADataTable.NewRow
                        'objDataRow.Item(ConstSrNo) = CInt(objDtTmp.Rows.Item(intCount).Item("CompletedAcceptedByID"))
                        'added by pankaj on 5 Dec 07
                        objDataRow.Item(ConstSrNo) = intCount + 1 'CInt(objDtTmp.Rows.Item(intCount).Item("CompletedAcceptedByID"))
                        '...
                        objDataRow.Item(ConstCompletedBy) = CStr(objDtTmp.Rows.Item(intCount).Item("CompletedBy"))
                        objDataRow.Item(ConstAcceptedBy) = CStr(objDtTmp.Rows.Item(intCount).Item("AcceptedBy"))
                        objDataRow.Item(ConstCompletedAcceptedByID) = CStr(objDtTmp.Rows.Item(intCount).Item("CompletedAcceptedByID")) 'uncomment by pankaj on 5 Dec 07
                        mobjCADataTable.Rows.Add(objDataRow)
                    Next
                End If
            End If


            If IsNothing(mobjCADataTable) = True Then
                Throw New Exception("Error in Getting Equipment List Records.")
            Else
                subFormatCompleteAcceptDataGrid()
            End If

            'If funcGetCompleteAcceptRecords() Then
            '    subFormatCompleteAcceptDataGrid()
            'Else
            '    Throw New Exception("Error in Getting Completed/Accepted By Records.")
            'End If

            'End If


            objDtTmp = New DataTable

            subCreateDeficiencyDataTable()

            objDtTmp = gobjDataAccess.funcGetDeficiencyRecords(mintMode)

            If Not objDtTmp Is Nothing Then
                If Not objDtTmp.Rows.Count = 0 Then
                    For intCount = 0 To objDtTmp.Rows.Count - 1
                        objDataRow = mObjDataTable.NewRow
                        objDataRow.Item(ConstSrNo) = intCount + 1 'by Pankaj on 06 Dec 07'CInt(objDtTmp.Rows.Item(intCount).Item("DeficiencyCorrectiveActionPlanID"))
                        objDataRow.Item(ConstDeficiencyDetails) = gfuncWordWrap(CStr(objDtTmp.Rows.Item(intCount).Item("Details")), CONST_DetailsOfDeficiency_Size)
                        objDataRow.Item(ConstCorrectiveActionPlan) = gfuncWordWrap(CStr(objDtTmp.Rows.Item(intCount).Item("ActionPlan")), CONST_CorrectiveAction_Size)
                        objDataRow.Item(ConstCorrectiveActionBy) = gfuncWordWrap(CStr(objDtTmp.Rows.Item(intCount).Item("CorrectiveActionOrBy")), CONST_ActionBy_Size)
                        objDataRow.Item(ConstCorrectiveActionDate) = CDate(objDtTmp.Rows.Item(intCount).Item("CorrectiveActionDate"))
                        objDataRow.Item(ConstDeficiencyID) = CInt(objDtTmp.Rows.Item(intCount).Item("DeficiencyCorrectiveActionPlanID"))
                        mObjDataTable.Rows.Add(objDataRow)
                    Next
                End If
            End If


            If IsNothing(mObjDataTable) = True Then
                Throw New Exception("Error in Getting Equipment List Records.")
            Else
                subFormatDeficiencyDataGrid()
            End If

            'If funcGetDeficiencyRecords() Then
            '    subFormatDeficiencyDataGrid()
            'Else
            '    Throw New Exception("Error in Getting Deficiency Corrective Action Records.")
            'End If

            mblnModeLockStatus = gobjDataAccess.funcCheckModeLocked(mintMode)
            If (mblnModeLockStatus) Then
                dgCompletedAccepted.ReadOnly = True
                dgDeficiency.ReadOnly = True
            Else
                dgCompletedAccepted.ReadOnly = False
                dgDeficiency.ReadOnly = False
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

    Private Sub dtpCorrectiveDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        dgDeficiency(dgDeficiency.CurrentCell.RowNumber, dgDeficiency.CurrentCell.ColumnNumber) = mdtpCorrectiveDate.Value
    End Sub

#Region "Deficiency/Corrective Action Functions"

    Private Sub subCreateDeficiencyDataTable()
        '=====================================================================
        ' Procedure Name        :   subCreateDeficiencyDataTable
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

            mObjDataTable.Columns.Add(New DataColumn("DeficiencyDetails", GetType(String)))
            mObjDataTable.Columns.Add(New DataColumn("CorrectiveActionPlan", GetType(String)))
            mObjDataTable.Columns.Add(New DataColumn("CorrectiveActionBy", GetType(String)))
            mObjDataTable.Columns.Add(New DataColumn("CorrectiveActionDate", GetType(Date)))
            mObjDataTable.Columns.Add(New DataColumn("DeficiencyID", GetType(Integer)))
        Catch ex As Exception
            '---------------------------------------------------------
            'Error logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = "Error in Creating Deficiency Corrective Action Data-Table."
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

    'Private Function funcGetDeficiencyRecords() As Boolean
    '    '=====================================================================
    '    ' Procedure Name        :   funcGetDeficiencyRecords
    '    ' Description           :   To Get Deficiency/Corrective Action Records from Database into DataTable.
    '    ' Purpose               :   To Get Deficiency/Corrective Action Records from Database into DataTable.
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
    '        sql_string = " Select DeficiencyCorrectiveActionPlanID ,Details ,ActionPlan , CorrectiveActionDate ,CorrectiveActionOrBy " & _
    '                     " from DeficiencyCorrectiveActionPlan where CheckStatusIQOQPQ = " & mintMode & " "

    '        'reader_status = mclsDBFunctions.GetRecords(sql_string, mobjOleDBconnection, objReader)

    '        If Not (reader_status) Then
    '            Throw New Exception("Error in Opening Connection during Getting Deficiency Corrective Action Records.")
    '        End If

    '        rec_cnt = 1
    '        While objReader.Read
    '            objDataRow = mObjDataTable.NewRow()

    '            objDataRow("SrNo") = rec_cnt
    '            objDataRow("DeficiencyDetails") = CStr(objReader.Item("Details"))
    '            objDataRow("CorrectiveActionPlan") = CStr(objReader.Item("ActionPlan"))
    '            objDataRow("CorrectiveActionBy") = CStr(objReader.Item("CorrectiveActionOrBy"))
    '            If IsDBNull(objReader.Item("CorrectiveActionDate")) Then
    '            Else
    '                objDataRow("CorrectiveActionDate") = CDate(objReader.Item("CorrectiveActionDate"))
    '            End If
    '            'objDataRow("CorrectiveActionDate") = CDate(objReader.Item("CorrectiveActionDate"))
    '            objDataRow("DeficiencyID") = Convert.ToInt32(objReader.Item("DeficiencyCorrectiveActionPlanID"))

    '            mObjDataTable.Rows.Add(objDataRow)
    '            rec_cnt = rec_cnt + 1
    '        End While
    '        objReader.Close()

    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        'Error logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = "Error in Getting Deficiency Corrective Action Records."
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

    Private Sub subFormatDeficiencyDataGrid()
        Dim objTextColumn As DataGridTextBoxColumn

        Try
            dgDeficiency.TableStyles.Clear()
            mobjDataView.Table = mObjDataTable
            mobjDataView.AllowNew = True
            dgDeficiency.DataSource = mobjDataView
            'dgDeficiency.ReadOnly = False

            mobjGridTableStyle.PreferredRowHeight = 34 '9.7.2010 by dinesh wagh
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

            mobjGridTableStyle.MappingName = "DeficiencyAction"

            objTextColumn = New DataGridTextBoxColumn
            objTextColumn.MappingName = "SrNo"
            objTextColumn.HeaderText = "Sr.No."
            objTextColumn.Width = 40
            objTextColumn.ReadOnly = True
            objTextColumn.NullText = ""
            objTextColumn.Alignment = HorizontalAlignment.Center
            mobjGridTableStyle.GridColumnStyles.Add(objTextColumn)

            objTextColumn = New DataGridTextBoxColumn
            objTextColumn.TextBox.WordWrap = True '16.4.2010
            objTextColumn.MappingName = "DeficiencyDetails"
            objTextColumn.HeaderText = "Deficiency Details"
            objTextColumn.Width = 150
            objTextColumn.ReadOnly = False
            objTextColumn.NullText = ""
            objTextColumn.Alignment = HorizontalAlignment.Left
            mobjGridTableStyle.GridColumnStyles.Add(objTextColumn)

            objTextColumn = New DataGridTextBoxColumn
            objTextColumn.TextBox.WordWrap = True '16.4.2010
            objTextColumn.MappingName = "CorrectiveActionPlan"
            objTextColumn.HeaderText = "Corrective Action Plan with responsible person"
            objTextColumn.Width = 130
            objTextColumn.ReadOnly = False
            objTextColumn.NullText = ""
            objTextColumn.Alignment = HorizontalAlignment.Left
            mobjGridTableStyle.GridColumnStyles.Add(objTextColumn)

            objTextColumn = New DataGridTextBoxColumn
            objTextColumn.TextBox.WordWrap = True '16.4.2010
            objTextColumn.MappingName = "CorrectiveActionBy"
            objTextColumn.HeaderText = "Corrective Action By"
            objTextColumn.Width = 120
            objTextColumn.ReadOnly = False
            objTextColumn.NullText = ""
            objTextColumn.Alignment = HorizontalAlignment.Left
            mobjGridTableStyle.GridColumnStyles.Add(objTextColumn)

            objTextColumn = New DataGridTextBoxColumn
            objTextColumn.MappingName = "CorrectiveActionDate"
            objTextColumn.HeaderText = "Corrective Action Date"
            objTextColumn.Width = 132
            objTextColumn.Format = "dd-MMM-yyyy"
            objTextColumn.ReadOnly = False
            objTextColumn.NullText = ""
            objTextColumn.Alignment = HorizontalAlignment.Center
            mobjGridTableStyle.GridColumnStyles.Add(objTextColumn)

            objTextColumn = New DataGridTextBoxColumn
            objTextColumn.MappingName = "DeficiencyID"
            objTextColumn.HeaderText = "DeficiencyID"
            objTextColumn.Width = 0
            objTextColumn.ReadOnly = True
            objTextColumn.NullText = ""
            mobjGridTableStyle.GridColumnStyles.Add(objTextColumn)

            mobjGridTableStyle.GridLineColor = Color.Black
            dgDeficiency.TableStyles.Add(mobjGridTableStyle)
        Catch ex As Exception
            '---------------------------------------------------------
            'Error logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = "Error in Formating Deficiecny Corrective Action Data-Grid."
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

    Public Function funcSaveDeficiencyData() As Boolean
        '=====================================================================
        ' Procedure Name        :   funcSaveDeficiencyData
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

        Dim intRecordCount, intDeficiencyID, temp_cnt As Integer
        Dim strDetails, strActionPlan, strActionBy As String
        Dim dtActionDate As DateTime
        Dim status As Boolean = True

        Try
            dtActionDate = Now '---24.01.11


            intRecordCount = mObjDataTable.Rows.Count

            For temp_cnt = 0 To (intRecordCount - 1)
                '--- To Check if Deficiency ID is Null.
                If IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("DeficiencyID").Ordinal)) Then
                    If IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("DeficiencyDetails").Ordinal)) = False Then

                        strDetails = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("DeficiencyDetails").Ordinal)
                        strDetails = strDetails.Replace(vbCrLf, " ")

                        strActionPlan = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("CorrectiveActionPlan").Ordinal)
                        strActionPlan = strActionPlan.Replace(vbCrLf, " ")

                        strActionBy = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("CorrectiveActionBy").Ordinal)
                        strActionBy = strActionBy.Replace(vbCrLf, " ")

                        If IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("CorrectiveActionDate").Ordinal)) = False Then
                            dtActionDate = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("CorrectiveActionDate").Ordinal)
                        End If

                        status = gobjDataAccess.funcInsertDeficiencyData(strDetails, strActionPlan, strActionBy, dtActionDate, mintMode)
                        If Not (status) Then
                            Throw New Exception("Error in Saving Deficiency Corrective Action Details.")
                        End If
                    End If
                Else
                    If IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("DeficiencyDetails").Ordinal)) Or IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("CorrectiveActionPlan").Ordinal)) Or IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("CorrectiveActionBy").Ordinal)) Or IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("CorrectiveActionDate").Ordinal)) Then
                        intDeficiencyID = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("DeficiencyID").Ordinal)
                        status = gobjDataAccess.funcDeleteDeficiencyData(intDeficiencyID, mintMode)
                        If Not (status) Then
                            Throw New Exception("Error in Deleting Manual List Details.")
                        End If
                    Else
                        If IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("DeficiencyID").Ordinal)) = False Then
                            intDeficiencyID = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("DeficiencyID").Ordinal)
                        End If

                        strDetails = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("DeficiencyDetails").Ordinal)
                        strActionPlan = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("CorrectiveActionPlan").Ordinal)
                        strActionBy = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("CorrectiveActionBy").Ordinal)
                        If IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("CorrectiveActionDate").Ordinal)) Then
                        Else
                            dtActionDate = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("CorrectiveActionDate").Ordinal)
                        End If
                        status = gobjDataAccess.funcUpdateDeficiencyData(strDetails, strActionPlan, strActionBy, dtActionDate, intDeficiencyID, mintMode)
                        If Not (status) Then
                            Throw New Exception("Error in Updating Deficiency Corrective Action Details.")
                        End If
                    End If
                End If
            Next

        Catch ex As Exception
            '---------------------------------------------------------
            'Error logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = "Error in Saving Deficiency Correction Action Details."
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

    'Private Function funcInsertDeficiencyData(ByVal strDetails As String, ByVal strActionPlan As String, ByVal strActionBy As String, ByVal dtActionDate As DateTime) As Boolean
    '    '=====================================================================
    '    ' Procedure Name        :   funcInsertDeficiencyData
    '    ' Description           :   To Add/Insert New Deficiency/Corrective Action Data in Database.
    '    ' Purpose               :   To Add/Insert New Deficiency/Corrective Action Data in Database.
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
    '    Dim intDeficiencyID As Integer

    '    Try
    '        'Status = mclsDBFunctions.OpenConnection(mobjOleDBconnection)
    '        If Not (Status) Then
    '            Throw New Exception("Error in Opening Connection during Saving Deficiency Corrective Action Details.")
    '        End If

    '        '--- Generating Next Equipment ID. 
    '        'intDeficiencyID = mclsDBFunctions.GetNextID("DeficiencyCorrectiveActionPlan", "DeficiencyCorrectiveActionPlanID", mobjOleDBconnection)

    '        '---  Query for adding  data to EquipmentList
    '        str_sql = " Insert into DeficiencyCorrectiveActionPlan " & _
    '                  " (DeficiencyCorrectiveActionPlanID ,Details ,ActionPlan ,CorrectiveActionDate ,CorrectiveActionOrBy ,CheckStatusIQOQPQ) " & _
    '                  " values(?,?,?,?,?,?) "

    '        '--- Providing command object. 
    '        With objCommand
    '            .Connection = mobjOleDBconnection
    '            .CommandType = CommandType.Text
    '            .CommandText = str_sql
    '            .Parameters.Add("DeficiencyCorrectiveActionPlanID", OleDbType.Numeric).Value = intDeficiencyID
    '            .Parameters.Add("Details", OleDbType.VarChar, 50).Value = strDetails
    '            .Parameters.Add("ActionPlan", OleDbType.VarChar, 50).Value = strActionPlan
    '            .Parameters.Add("CorrectiveActionDate", OleDbType.DBDate).Value = dtActionDate
    '            .Parameters.Add("CorrectiveActionOrBy", OleDbType.VarChar, 50).Value = strActionBy
    '            .Parameters.Add("CheckStatusIQOQPQ", OleDbType.Single).Value = mintMode
    '            '.Parameters.Add("CheckStatusIQOQPQ", OleDbType.Single).Value = CSng(ENUM_IQOQPQ_STATUS.IQ)
    '            .ExecuteNonQuery()
    '        End With

    '        objCommand.Dispose()
    '        Status = True

    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        '--- Error logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = "Error in Saving Deficiency Correction Action Details."
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

    'Private Function funcUpdateDeficiencyData(ByVal strDetails As String, ByVal strActionPlan As String, ByVal strActionBy As String, ByVal dtActionDate As DateTime, ByVal intDeficiencyID As Integer) As Boolean
    '    '=====================================================================
    '    ' Procedure Name        :   funcUpdateDeficiencyData
    '    ' Description           :   To Update Deficiency/Corrective Action Data in Database.
    '    ' Purpose               :   To Update Deficiency/Corrective Action Data in Database.
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
    '            Throw New Exception("Error in Opening Connection during Updating Deficiency Correction Action Details.")
    '        End If

    '        '---  Query for adding  data to EquipmentList
    '        str_sql = " Update DeficiencyCorrectiveActionPlan " & _
    '                  " Set Details = ? ,ActionPlan = ? ,CorrectiveActionDate = ? ,CorrectiveActionOrBy = ? " & _
    '                  " where DeficiencyCorrectiveActionPlanID = " & intDeficiencyID & " and CheckStatusIQOQPQ = " & mintMode & "  "

    '        '--- Providing command object for EquimentList
    '        With objCommand
    '            .Connection = mobjOleDBconnection
    '            .CommandType = CommandType.Text
    '            .CommandText = str_sql
    '            .Parameters.Add("Details", OleDbType.VarChar, 250).Value = strDetails
    '            .Parameters.Add("ActionPlan", OleDbType.VarChar, 250).Value = strActionPlan
    '            .Parameters.Add("CorrectiveActionDate", OleDbType.DBDate).Value = dtActionDate
    '            .Parameters.Add("CorrectiveActionOrBy", OleDbType.VarChar, 250).Value = strActionBy
    '            .ExecuteNonQuery()
    '        End With

    '        objCommand.Dispose()
    '        Status = True

    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        '--- Error logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = "Error in Updating Deficiency Correction Action Details."
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

    'Private Function funcDeleteDeficiencyData(ByVal intDeficiencyID As Integer) As Boolean
    '    '=====================================================================
    '    ' Procedure Name        :   funcDeleteDeficiencyData
    '    ' Description           :   To Delete Deficiency/Corrective Action Data from Database.
    '    ' Purpose               :   To Delete Deficiency/Corrective Action Data from Database.
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
    '            Throw New Exception("Error in Opening Connection for Deleting Completed/Accepted By Details.")
    '        End If

    '        '--- Query to Delete from Database
    '        str_sql = " Delete * from DeficiencyCorrectiveActionPlan " & _
    '                  " where DeficiencyCorrectiveActionPlanID = " & intDeficiencyID & " and CheckStatusIQOQPQ = " & mintMode & " "

    '        'Status = mclsDBFunctions.AddORDeleteRecord(str_sql, mobjOleDBconnection)
    '        If (Status = False) Then
    '            Throw New Exception("Error in Deleting Completed/Accepted By Details.")
    '        End If

    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        '--- Error logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = "Error in Deleting Deficiency Corrective Action Details."
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

#Region "Completed/Accepted By Functions"

    Private Sub subCreateCompleteAcceptDataTable()
        '=====================================================================
        ' Procedure Name        :   subCreateCompleteAcceptDataTable
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
            mobjCADataTable.Columns.Add(objDataColumn)

            mobjCADataTable.Columns.Add(New DataColumn("CompletedBy", GetType(String)))
            mobjCADataTable.Columns.Add(New DataColumn("AcceptedBy", GetType(String)))
            mobjCADataTable.Columns.Add(New DataColumn("CompletedAcceptedByID", GetType(Integer)))

        Catch ex As Exception
            '---------------------------------------------------------
            'Error logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = "Error in Creating Completed/Accepted By Data-Table."
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

    'Private Function funcGetCompleteAcceptRecords() As Boolean
    '    '=====================================================================
    '    ' Procedure Name        :   funcGetCompleteAcceptRecords
    '    ' Description           :   To Get Completed/Accepted By Records from Database into DataTable.
    '    ' Purpose               :   To Get Completed/Accepted By Records from Database into DataTable.
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

    '        sql_string = " Select CompletedAcceptedByID ,CompletedBy ,AcceptedBy " & _
    '                     " from CompletedAcceptedBY where CheckStatusIQOQPQ = " & mintMode & " "

    '        'reader_status = mclsDBFunctions.GetRecords(sql_string, mobjOleDBconnection, objReader)

    '        If Not (reader_status) Then
    '            Throw New Exception("Error in Opening Connection during Getting Completed/Accepted By Details.")
    '        End If

    '        rec_cnt = 1
    '        While objReader.Read
    '            objDataRow = mobjCADataTable.NewRow()

    '            objDataRow("SrNo") = rec_cnt
    '            objDataRow("CompletedBy") = CStr(objReader.Item("CompletedBy"))
    '            objDataRow("AcceptedBy") = CStr(objReader.Item("AcceptedBy"))
    '            objDataRow("CompletedAcceptedByID") = Convert.ToInt32(objReader.Item("CompletedAcceptedByID"))

    '            mobjCADataTable.Rows.Add(objDataRow)
    '            rec_cnt = rec_cnt + 1
    '        End While
    '        objReader.Close()

    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        'Error logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = "Error in Getting Completed/Accepted By Records."
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

    Private Sub subFormatCompleteAcceptDataGrid()
        Dim objTextColumn As DataGridTextBoxColumn

        Try
            dgCompletedAccepted.TableStyles.Clear()
            mobjDataView1.Table = mobjCADataTable
            mobjDataView1.AllowNew = True
            dgCompletedAccepted.DataSource = mobjDataView1

            'dgCompletedAccepted.DataSource = mobjCADataTable
            'dgCompletedAccepted.ReadOnly = False

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

            mobjCAGridTableStyle.MappingName = "CompletedAcceptedBy"

            objTextColumn = New DataGridTextBoxColumn
            objTextColumn.MappingName = "SrNo"
            objTextColumn.HeaderText = "Sr.No."
            objTextColumn.Width = 50
            objTextColumn.ReadOnly = True
            objTextColumn.NullText = ""
            objTextColumn.Alignment = HorizontalAlignment.Center
            mobjCAGridTableStyle.GridColumnStyles.Add(objTextColumn)

            objTextColumn = New DataGridTextBoxColumn
            objTextColumn.MappingName = "CompletedBy"
            objTextColumn.HeaderText = "Completed By"
            objTextColumn.Width = 200
            objTextColumn.ReadOnly = False
            objTextColumn.NullText = ""
            objTextColumn.Alignment = HorizontalAlignment.Center
            mobjCAGridTableStyle.GridColumnStyles.Add(objTextColumn)

            objTextColumn = New DataGridTextBoxColumn
            objTextColumn.MappingName = "AcceptedBy"
            objTextColumn.HeaderText = "Accepted By"
            objTextColumn.Width = 200
            objTextColumn.ReadOnly = False
            objTextColumn.NullText = ""
            objTextColumn.Alignment = HorizontalAlignment.Center
            mobjCAGridTableStyle.GridColumnStyles.Add(objTextColumn)

            'objTextColumn = New DataGridTextBoxColumn
            'objTextColumn.MappingName = "CompletedAcceptedByID"
            'objTextColumn.HeaderText = "CompletedAcceptedByID"
            'objTextColumn.Width = 0
            'objTextColumn.ReadOnly = True
            'objTextColumn.NullText = ""
            'objTextColumn.Alignment = HorizontalAlignment.Center
            'mobjCAGridTableStyle.GridColumnStyles.Add(objTextColumn)

            mobjCAGridTableStyle.GridLineColor = Color.Black
            dgCompletedAccepted.TableStyles.Add(mobjCAGridTableStyle)

        Catch ex As Exception
            '---------------------------------------------------------
            'Error logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = "Error in Formating Completed/Accepted By Data-Grid."
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

    Public Function funcSaveCompleteAcceptData() As Boolean
        '=====================================================================
        ' Procedure Name        :   funcSaveCompleteAcceptData
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

        Dim intRecordCount, intCompleteAcceptID, temp_cnt As Integer
        Dim strCompletedBy, strAcceptedBy As String
        Dim status As Boolean = True

        Try
            intRecordCount = mobjCADataTable.Rows.Count

            For temp_cnt = 0 To (intRecordCount - 1)
                '--- To Check if Completed / Accepted ID is Null.
                If IsDBNull(mobjCADataTable.Rows(temp_cnt).ItemArray.GetValue(mobjCADataTable.Columns.Item("CompletedAcceptedByID").Ordinal)) Then
                    strCompletedBy = mobjCADataTable.Rows(temp_cnt).ItemArray.GetValue(mobjCADataTable.Columns.Item("CompletedBy").Ordinal)
                    strAcceptedBy = mobjCADataTable.Rows(temp_cnt).ItemArray.GetValue(mobjCADataTable.Columns.Item("AcceptedBy").Ordinal)
                    status = gobjDataAccess.funcInsertCompleteAcceptData(strCompletedBy, strAcceptedBy, mintMode)
                    If Not (status) Then
                        Throw New Exception("Error in Saving Completed/Accepted By Details.")
                    End If
                Else
                    intCompleteAcceptID = mobjCADataTable.Rows(temp_cnt).ItemArray.GetValue(mobjCADataTable.Columns.Item("CompletedAcceptedByID").Ordinal)
                    If Not (IsDBNull(mobjCADataTable.Rows(temp_cnt).ItemArray.GetValue(mobjCADataTable.Columns.Item("CompletedBy").Ordinal))) Then strCompletedBy = mobjCADataTable.Rows(temp_cnt).ItemArray.GetValue(mobjCADataTable.Columns.Item("CompletedBy").Ordinal)
                    If Not (IsDBNull(mobjCADataTable.Rows(temp_cnt).ItemArray.GetValue(mobjCADataTable.Columns.Item("AcceptedBy").Ordinal))) Then strAcceptedBy = mobjCADataTable.Rows(temp_cnt).ItemArray.GetValue(mobjCADataTable.Columns.Item("AcceptedBy").Ordinal)
                    status = gobjDataAccess.funcUpdateCompleteAcceptData(strCompletedBy, strAcceptedBy, intCompleteAcceptID, mintMode)
                    If Not (status) Then
                        Throw New Exception("Error in Saving Completed/Accepted By Details.")
                    End If
                End If
            Next
        Catch ex As Exception
            '---------------------------------------------------------
            'Error logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = "Error in Saving Completed/Accepted By Details."
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

    'Private Function funcInsertCompleteAcceptData(ByVal strCompletedBy As String, ByVal strAcceptedBy As String) As Boolean
    '    '=====================================================================
    '    ' Procedure Name        :   funcInsertCompleteAcceptData
    '    ' Description           :   To Add/Insert New Completed/Accepted By Data in Database.
    '    ' Purpose               :   To Add/Insert New Completed/Accepted By Data in Database.
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
    '    Dim intCompleteAcceptID As Integer

    '    Try
    '        'Status = mclsDBFunctions.OpenConnection(mobjOleDBconnection)
    '        If Not (Status) Then
    '            Throw New Exception("Error in Opening Connection during Saving Completed/Accepted By Details.")
    '        End If

    '        '--- Generating Next Equipment ID. 
    '        'intCompleteAcceptID = mclsDBFunctions.GetNextID("CompletedAcceptedBY", "CompletedAcceptedByID", mobjOleDBconnection)

    '        '---  Query for adding  data to EquipmentList
    '        str_sql = " Insert into CompletedAcceptedBY " & _
    '                  " (CompletedAcceptedByID ,CompletedBy ,AcceptedBy ,CheckStatusIQOQPQ) " & _
    '                  " values(?,?,?,?) "

    '        '--- Providing command object. 
    '        With objCommand
    '            .Connection = mobjOleDBconnection
    '            .CommandType = CommandType.Text
    '            .CommandText = str_sql
    '            .Parameters.Add("CompletedAcceptedByID", OleDbType.Numeric).Value = intCompleteAcceptID
    '            .Parameters.Add("CompletedBy", OleDbType.VarChar, 50).Value = strCompletedBy
    '            .Parameters.Add("AcceptedBy", OleDbType.VarChar, 50).Value = strAcceptedBy
    '            .Parameters.Add("CheckStatusIQOQPQ", OleDbType.Single).Value = mintMode
    '            '.Parameters.Add("CheckStatusIQOQPQ", OleDbType.Single).Value = CSng(ENUM_IQOQPQ_STATUS.IQ)
    '            .ExecuteNonQuery()
    '        End With

    '        objCommand.Dispose()
    '        Status = True

    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        '--- Error logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = "Error in Saving Completed/Accepted By Details."
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

    'Private Function funcUpdateCompleteAcceptData(ByVal strCompletedBy As String, ByVal strAcceptedBy As String, ByVal intCompleteAcceptID As Integer) As Boolean
    '    '=====================================================================
    '    ' Procedure Name        :   funcUpdateCompleteAcceptData
    '    ' Description           :   To Update Completed/Accepted By Data in Database.
    '    ' Purpose               :   To Update Completed/Accepted By Data in Database.
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
    '            Throw New Exception("Error in Opening Connection during Updating Completed/Accepted By Details.")
    '        End If

    '        '---  Query for adding  data 
    '        str_sql = " Update CompletedAcceptedBY " & _
    '                  " Set CompletedBy = ? ,AcceptedBy = ? " & _
    '                  " where CompletedAcceptedByID = " & intCompleteAcceptID & " and CheckStatusIQOQPQ = " & mintMode & " "

    '        '--- Providing command object  
    '        With objCommand
    '            .Connection = mobjOleDBconnection
    '            .CommandType = CommandType.Text
    '            .CommandText = str_sql
    '            .Parameters.Add("CompletedBy", OleDbType.VarChar, 250).Value = strCompletedBy
    '            .Parameters.Add("AcceptedBy", OleDbType.VarChar, 250).Value = strAcceptedBy
    '            .ExecuteNonQuery()
    '        End With

    '        objCommand.Dispose()
    '        Status = True

    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        '--- Error logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = "Error in Updating Completed/Accepted By Details."
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

    'Private Function funcDeleteCompleteAcceptData(ByVal intCompleteAcceptID As Integer) As Boolean
    '    '=====================================================================
    '    ' Procedure Name        :   funcDeleteCompleteAcceptData
    '    ' Description           :   To Delete Completed/Accepted By Data from Database.
    '    ' Purpose               :   To Delete Completed/Accepted By Data from Database.
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
    '            Throw New Exception("Error in Opening Connection during Deleting Completed/Accepted By Details.")
    '        End If

    '        '--- Query to Delete from Database
    '        str_sql = " Delete * from CompletedAcceptedBY " & _
    '                  " where CompletedAcceptedByID = " & intCompleteAcceptID & " and CheckStatusIQOQPQ = " & mintMode & " "

    '        'Status = mclsDBFunctions.AddORDeleteRecord(str_sql, mobjOleDBconnection)
    '        If (Status = False) Then
    '            Throw New Exception("Error in Deleting Completed/Accepted By Details.")
    '        End If

    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        '--- Error logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = "Error in Deleting Completed/Accepted By Details."
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

    Private Sub dgDeficiency_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgDeficiency.CurrentCellChanged

        Dim intWidth As Integer
        Dim objDV As DataView

        Try
            If Not (mblnModeLockStatus) Then
                mObjDataTable.Columns(0).ReadOnly = False

                If mObjDataTable.Rows.Count = 0 Then
                    mObjDataTable.Columns(0).DefaultValue = 1
                Else
                    dgDeficiency.Item(dgDeficiency.CurrentRowIndex, 0) = dgDeficiency.CurrentRowIndex + 1
                End If

                mObjDataTable.Columns(0).ReadOnly = True
                If (dgDeficiency.CurrentCell.ColumnNumber = CONST_DateColumnNo) Then
                    mdtpCorrectiveDate.Top = dgDeficiency.GetCurrentCellBounds().Top
                    mdtpCorrectiveDate.Left = dgDeficiency.GetCurrentCellBounds().Left
                    mdtpCorrectiveDate.Width = dgDeficiency.GetCurrentCellBounds().Width
                    mdtpCorrectiveDate.Height = dgDeficiency.GetCurrentCellBounds().Height
                    If (dgDeficiency.CurrentCell.RowNumber) > 0 Then
                        If IsDBNull(dgDeficiency(dgDeficiency.CurrentCell.RowNumber, CONST_DateColumnNo)) = False Then
                            mdtpCorrectiveDate.Value = CDate(dgDeficiency(dgDeficiency.CurrentCell.RowNumber, CONST_DateColumnNo))
                        Else
                            mdtpCorrectiveDate.Value = DateTime.Today
                            dgDeficiency(dgDeficiency.CurrentCell.RowNumber, dgDeficiency.CurrentCell.ColumnNumber) = mdtpCorrectiveDate.Value
                        End If
                    Else
                        dgDeficiency(dgDeficiency.CurrentCell.RowNumber, dgDeficiency.CurrentCell.ColumnNumber) = mdtpCorrectiveDate.Value
                        '   mdtpCorrectiveDate.Value = DateTime.Today
                    End If
                    mdtpCorrectiveDate.Visible = True
                Else
                    mdtpCorrectiveDate.Width = 0
                    mdtpCorrectiveDate.Visible = False
                End If
            End If

            If dgDeficiency.CurrentRowIndex >= 10 Then
                mobjDataView.AllowNew = False
            End If

            '-------3.2.2010  by dinesh wagh
            If mObjDataTable.Rows.Count = 0 And dgDeficiency.CurrentRowIndex <> -1 Then
                dgDeficiency.Item(0, 0) = 1
            End If
            '-------------


            'code added by ; dinesh wagh on 30.6.2010
            '---------------------------------------------------
            objDV = dgDeficiency.DataSource

            Select Case mintColumnIndex
                Case EnumColumns.DetailOfDeficiency
                    intWidth = CONST_DetailsOfDeficiency_Size
                Case EnumColumns.CorrectiveAction
                    intWidth = CONST_CorrectiveAction_Size
                Case EnumColumns.ActionBy
                    intWidth = CONST_ActionBy_Size
            End Select

            If objDV.Count > 0 And objDV.Count > mintRowIndex Then
                If mintColumnIndex = EnumColumns.DetailOfDeficiency Or _
                   mintColumnIndex = EnumColumns.CorrectiveAction Or _
                   mintColumnIndex = EnumColumns.ActionBy Then

                    If Not IsDBNull(objDV(mintRowIndex).Row(mintColumnIndex)) Then
                        objDV(mintRowIndex).Row(mintColumnIndex) = gfuncWordWrap(objDV(mintRowIndex).Row(mintColumnIndex), intWidth)
                        dgDeficiency.DataSource = objDV
                    End If

                End If
            End If
            mintRowIndex = dgDeficiency.CurrentCell.RowNumber
            mintColumnIndex = dgDeficiency.CurrentCell.ColumnNumber
            '---------------------------------
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

    Private Sub dgCompletedAccepted_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgCompletedAccepted.CurrentCellChanged
        Try
            mobjCADataTable.Columns(0).ReadOnly = False

            If mobjCADataTable.Rows.Count = 0 Then
                mobjCADataTable.Columns(0).DefaultValue = 1
            Else
                dgCompletedAccepted.Item(dgCompletedAccepted.CurrentRowIndex, 0) = dgCompletedAccepted.CurrentRowIndex + 1
            End If

            mobjCADataTable.Columns(0).ReadOnly = True
            If dgCompletedAccepted.CurrentRowIndex >= 2 Then
                mobjDataView1.AllowNew = False
            End If

            '-------16.6.2010  by dinesh wagh 
            If mobjCADataTable.Rows.Count = 0 And dgCompletedAccepted.CurrentRowIndex <> -1 Then
                dgCompletedAccepted.Item(0, 0) = 1
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

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class
