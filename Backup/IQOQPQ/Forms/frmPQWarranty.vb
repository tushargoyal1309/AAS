Imports System.Data
Imports System.Data.OleDb

Public Class frmPQWarranty
    Inherits System.Windows.Forms.Form

#Region " Module level Declarations "
    Private mblnModeLockStatus As Boolean
    Private mstrOledbConnectionString As String
    Private mobjOleDBconnection As OleDbConnection
    'Public mclsDBFunctions As New clsDatabaseFunctions
    Private mobjDataView As New DataView
    Private mobjCADataTable As DataTable
    Dim mobjCAGridTableStyle As New DataGridTableStyle
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
    Friend WithEvents dgCompletedAccepted As System.Windows.Forms.DataGrid
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmPQWarranty))
        Me.lblHeader1 = New System.Windows.Forms.Label
        Me.lblHeader2 = New System.Windows.Forms.Label
        Me.lblHeader3 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.dgCompletedAccepted = New System.Windows.Forms.DataGrid
        Me.Label1 = New System.Windows.Forms.Label
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.dgCompletedAccepted, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblHeader1
        '
        Me.lblHeader1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeader1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblHeader1.Location = New System.Drawing.Point(35, 7)
        Me.lblHeader1.Name = "lblHeader1"
        Me.lblHeader1.Size = New System.Drawing.Size(376, 18)
        Me.lblHeader1.TabIndex = 1
        Me.lblHeader1.Text = "F. WARRANTY"
        Me.lblHeader1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblHeader2
        '
        Me.lblHeader2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeader2.Location = New System.Drawing.Point(8, 40)
        Me.lblHeader2.Name = "lblHeader2"
        Me.lblHeader2.Size = New System.Drawing.Size(511, 40)
        Me.lblHeader2.TabIndex = 2
        Me.lblHeader2.Text = "     Instruments supplied carry warranty of 12 months from the date of installati" & _
        "on or 15 months from the date of supply whichever is earlier, against any manufa" & _
        "cturing defects."
        '
        'lblHeader3
        '
        Me.lblHeader3.Location = New System.Drawing.Point(8, 88)
        Me.lblHeader3.Name = "lblHeader3"
        Me.lblHeader3.Size = New System.Drawing.Size(512, 40)
        Me.lblHeader3.TabIndex = 3
        Me.lblHeader3.Text = "This warranty will not be applicable if the purchaser does not make payment, as p" & _
        "er the terms of the contract."
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.dgCompletedAccepted)
        Me.Panel1.Controls.Add(Me.lblHeader2)
        Me.Panel1.Controls.Add(Me.lblHeader3)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(456, 456)
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
        Me.Panel2.Size = New System.Drawing.Size(454, 32)
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
        'dgCompletedAccepted
        '
        Me.dgCompletedAccepted.BackgroundColor = System.Drawing.Color.AliceBlue
        Me.dgCompletedAccepted.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.dgCompletedAccepted.CaptionVisible = False
        Me.dgCompletedAccepted.DataMember = ""
        Me.dgCompletedAccepted.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgCompletedAccepted.Location = New System.Drawing.Point(16, 172)
        Me.dgCompletedAccepted.Name = "dgCompletedAccepted"
        Me.dgCompletedAccepted.ParentRowsVisible = False
        Me.dgCompletedAccepted.ReadOnly = True
        Me.dgCompletedAccepted.RowHeadersVisible = False
        Me.dgCompletedAccepted.Size = New System.Drawing.Size(455, 104)
        Me.dgCompletedAccepted.TabIndex = 18
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 129)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(512, 30)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "Warranty is not applicable for consumable parts such as D2 , Hallow Cathode Lamp " & _
        "etc."
        '
        'frmPQWarranty
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(456, 440)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPQWarranty"
        Me.Text = "Warranty"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.dgCompletedAccepted, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Constants"
    Private Const ConstSrNo As String = "SrNo"
    Private Const ConstCompletedBy As String = "CompletedBy"
    Private Const ConstAcceptedBy As String = "AcceptedBy"
    Private Const ConstCompletedAcceptedByID As String = "CompletedAcceptedByID"

#End Region

#Region " Form Events "
    Private Sub frmPQWarranty_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

    Private Sub frmPQWarranty_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Try
            If Not (mblnModeLockStatus) Then
                dgCompletedAccepted.CurrentCell() = (New DataGridCell(dgCompletedAccepted.CurrentRowIndex + 1, 0))
                If Not funcSavePQCompleteAcceptData() Then
                    Throw New Exception("Error in Saving Completed/Accepted By Data.")
                End If
                dgCompletedAccepted.TableStyles.Clear()
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
    '    General functions used for IQ Equipment Listing.
    '--- funcInitialize - To Initialize form and to get values for PQ Completed/Accepted by Data from database and display them.
    '--- subCreateCompleteAcceptDataTable - To Create Columns in the Data Table.
    '--- funcGetPQCompleteAcceptRecords - To Get PQ Completed/Accepted By Records from Database into DataTable.
    '--- subFormatCompleteAcceptDataGrid - To format the Completed/Accepted By Data Grid.
    '--- funcSavePQCompleteAcceptData - To Save the Entered Records into Database.
    '--- funcInsertPQCompleteAcceptData - To Add/Insert New Completed/Accepted By Data in Database.
    '--- funcUpdatePQCompleteAcceptData - To Update Completed/Accepted By Data in Database.
    '--- funcDeletePQCompleteAcceptData - To Delete Completed/Accepted By Action Data from Database.

    Private Sub funcInitialize()
        '=====================================================================
        ' Procedure Name        :   funcInitailize
        ' Description           :   To Initialize form and to get values for PQ Completed/Accepted by Data from database and display them.
        ' Purpose               :   To Initialize form and to get values for PQ Completed/Accepted by Data from database and display them.
        ' Parameters Passed     :   None.
        ' Returns               :   None.
        ' Parameters Affected   :   None.
        ' Assumptions           :
        ' Dependencies          :
        ' Author                :   Gitesh
        ' Created               :   January, 2003 
        ' Revisions             :
        '=====================================================================
        Dim intRowCount As Integer
        Dim objDataRow As DataRow
        Dim intCount As Integer = 0
        Dim mobjTmpDt As New DataTable
        Try

            'mfrmWarranty = Me
            mobjCADataTable = New DataTable("CompletedAcceptedBy")

            '--- Initialising Connection String
            'mstrOledbConnectionString = mclsDBFunctions.ConnectionString(CONST_IQOQPQ_DATABASENAME)

            '--- Initialising Connection 
            'mobjOleDBconnection = New OleDbConnection(mstrOledbConnectionString)

            subCreateCompleteAcceptDataTable()

            mobjTmpDt = gobjDataAccess.funcGetPQCompleteAcceptRecords()

            If Not mobjTmpDt Is Nothing Then
                If Not mobjTmpDt.Rows.Count = 0 Then
                    For intCount = 0 To mobjTmpDt.Rows.Count - 1
                        objDataRow = mobjCADataTable.NewRow
                        objDataRow.Item(ConstSrNo) = intCount + 1 'by Pankaj on 6 Dec 07'CInt(mobjTmpDt.Rows.Item(intCount).Item("CompletedAcceptedByID"))
                        objDataRow.Item(ConstCompletedBy) = CStr(mobjTmpDt.Rows.Item(intCount).Item("CompletedBy"))
                        objDataRow.Item(ConstAcceptedBy) = CStr(mobjTmpDt.Rows.Item(intCount).Item("AcceptedBy"))
                        objDataRow.Item(ConstCompletedAcceptedByID) = CInt(mobjTmpDt.Rows.Item(intCount).Item("CompletedAcceptedByID"))
                        mobjCADataTable.Rows.Add(objDataRow)

                    Next
                End If
            End If

            If IsNothing(mobjCADataTable) = True Then
                Throw New Exception("Error in Getting Completed/Accepted By Records.")
            Else

                subFormatCompleteAcceptDataGrid()
            End If

            'If funcGetPQCompleteAcceptRecords() Then
            '    subFormatCompleteAcceptDataGrid()
            'Else
            '    Throw New Exception("Error in Getting Completed/Accepted By Records.")
            'End If

            mblnModeLockStatus = gobjDataAccess.funcCheckModeLocked(ENUM_IQOQPQ_STATUS.PQ)
            If (mblnModeLockStatus) Then
                dgCompletedAccepted.ReadOnly = True
            Else
                dgCompletedAccepted.ReadOnly = False
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
            'objDataColumn.AutoIncrement = True
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

    'Private Function funcGetPQCompleteAcceptRecords() As Boolean
    '    '=====================================================================
    '    ' Procedure Name        :   funcGetPQCompleteAcceptRecords
    '    ' Description           :   To Get PQ Completed/Accepted By Records from Database into DataTable.
    '    ' Purpose               :   To Get PQ Completed/Accepted By Records from Database into DataTable.
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
    '                     " from CompletedAcceptedBY where CheckStatusIQOQPQ = " & ENUM_IQOQPQ_STATUS.PQ & ""

    '        reader_status = mclsDBFunctions.GetRecords(sql_string, mobjOleDBconnection, objReader)

    '        If Not (reader_status) Then
    '            Return False
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
            mobjDataView.Table = mobjCADataTable
            mobjDataView.AllowNew = True
            dgCompletedAccepted.DataSource = mobjDataView
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

            objTextColumn = New DataGridTextBoxColumn
            objTextColumn.MappingName = "CompletedAcceptedByID"
            objTextColumn.HeaderText = "CompletedAcceptedByID"
            objTextColumn.Width = 0
            objTextColumn.ReadOnly = True
            objTextColumn.NullText = ""
            mobjCAGridTableStyle.GridColumnStyles.Add(objTextColumn)

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

    Public Function funcSavePQCompleteAcceptData() As Boolean
        '=====================================================================
        ' Procedure Name        :   funcSavePQCompleteAcceptData
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
                    If IsDBNull(mobjCADataTable.Rows(temp_cnt).ItemArray.GetValue(mobjCADataTable.Columns.Item("CompletedBy").Ordinal)) = False Then
                        strCompletedBy = mobjCADataTable.Rows(temp_cnt).ItemArray.GetValue(mobjCADataTable.Columns.Item("CompletedBy").Ordinal)
                    End If
                    If IsDBNull(mobjCADataTable.Rows(temp_cnt).ItemArray.GetValue(mobjCADataTable.Columns.Item("AcceptedBy").Ordinal)) = False Then
                        strAcceptedBy = mobjCADataTable.Rows(temp_cnt).ItemArray.GetValue(mobjCADataTable.Columns.Item("AcceptedBy").Ordinal)
                    End If
                    If (strCompletedBy = "" And strAcceptedBy = "") Then
                    Else
                        status = gobjDataAccess.funcInsertPQCompleteAcceptData(strCompletedBy, strAcceptedBy)
                        If Not (status) Then
                            Throw New Exception("Error in Saving Completed/Accepted By Details.")
                        End If
                    End If
                Else
                    intCompleteAcceptID = mobjCADataTable.Rows(temp_cnt).ItemArray.GetValue(mobjCADataTable.Columns.Item("CompletedAcceptedByID").Ordinal)
                    If IsDBNull(mobjCADataTable.Rows(temp_cnt).ItemArray.GetValue(mobjCADataTable.Columns.Item("CompletedBy").Ordinal)) = False Then
                        strCompletedBy = mobjCADataTable.Rows(temp_cnt).ItemArray.GetValue(mobjCADataTable.Columns.Item("CompletedBy").Ordinal)
                    End If
                    If IsDBNull(mobjCADataTable.Rows(temp_cnt).ItemArray.GetValue(mobjCADataTable.Columns.Item("AcceptedBy").Ordinal)) = False Then
                        strAcceptedBy = mobjCADataTable.Rows(temp_cnt).ItemArray.GetValue(mobjCADataTable.Columns.Item("AcceptedBy").Ordinal)
                    End If
                    status = gobjDataAccess.funcUpdatePQCompleteAcceptData(strCompletedBy, strAcceptedBy, intCompleteAcceptID)
                    If Not (status) Then
                        Throw New Exception("Error in Updating Completed/Accepted By Details.")
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

    'Private Function funcInsertPQCompleteAcceptData(ByVal strCompletedBy As String, ByVal strAcceptedBy As String) As Boolean
    '    '=====================================================================
    '    ' Procedure Name        :   funcInsertPQCompleteAcceptData
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
    '        Status = mclsDBFunctions.OpenConnection(mobjOleDBconnection)
    '        If Not (Status) Then
    '            Throw New Exception("Error in Opening Connection during Saving Test Details.")
    '        End If

    '        '--- Generating Next Equipment ID. 
    '        intCompleteAcceptID = mclsDBFunctions.GetNextID("CompletedAcceptedBY", "CompletedAcceptedByID", mobjOleDBconnection)

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
    '            .Parameters.Add("CheckStatusIQOQPQ", OleDbType.Single).Value = CSng(ENUM_IQOQPQ_STATUS.PQ)
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

    'Private Function funcUpdatePQCompleteAcceptData(ByVal strCompletedBy As String, ByVal strAcceptedBy As String, ByVal intCompleteAcceptID As Integer) As Boolean
    '    '=====================================================================
    '    ' Procedure Name        :   funcUpdatePQCompleteAcceptData
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
    '        Status = mclsDBFunctions.OpenConnection(mobjOleDBconnection)
    '        If Not (Status) Then
    '            Throw New Exception("Error in Opening Connection during Updating Test Details.")
    '        End If

    '        '---  Query for adding  data 
    '        str_sql = " Update CompletedAcceptedBY " & _
    '                  " Set CompletedBy = ? ,AcceptedBy = ? " & _
    '                  " where CompletedAcceptedByID = " & intCompleteAcceptID & " and CheckStatusIQOQPQ = " & ENUM_IQOQPQ_STATUS.PQ & "  "

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

    'Private Function funcDeletePQCompleteAcceptData(ByVal intCompleteAcceptID As Integer) As Boolean
    '    '=====================================================================
    '    ' Procedure Name        :   funcDeletePQCompleteAcceptData
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
    '        Status = mclsDBFunctions.OpenConnection(mobjOleDBconnection)
    '        If Not (Status) Then
    '            Throw New Exception("Error in Opening Connection during Deleting Completed/Accepted By Details.")
    '        End If

    '        '--- Query to Delete from Database
    '        str_sql = " Delete * from CompletedAcceptedBY " & _
    '                  " where CompletedAcceptedByID = " & intCompleteAcceptID & " and CheckStatusIQOQPQ = " & ENUM_IQOQPQ_STATUS.PQ & " "

    '        Status = mclsDBFunctions.AddORDeleteRecord(str_sql, mobjOleDBconnection)
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

    Private Sub dgCompletedAccepted_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgCompletedAccepted.CurrentCellChanged
        mobjCADataTable.Columns(0).ReadOnly = False
        If mobjCADataTable.Rows.Count = 0 Then
            mobjCADataTable.Columns(0).DefaultValue = 1
        Else
            dgCompletedAccepted.Item(dgCompletedAccepted.CurrentRowIndex, 0) = dgCompletedAccepted.CurrentRowIndex + 1
        End If

        mobjCADataTable.Columns(0).ReadOnly = True
        If dgCompletedAccepted.CurrentRowIndex >= 2 Then
            mobjDataView.AllowNew = False
        End If
    End Sub

End Class
