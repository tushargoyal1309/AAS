Option Explicit On 

Imports System.Data
Imports System.Data.OleDb
Imports System.Windows.Forms.DataGridColumnStyle
Imports ErrorHandler.ErrorHandler

Public Class frmOQEquipmentList
    Inherits System.Windows.Forms.Form

#Region " Module level Declarations "
    Private mblnModeLockStatus As Boolean
    Dim mintMode As Integer
    Private mstrOledbConnectionString As String
    Private mobjOleDBconnection As OleDbConnection
    'Public mclsDBFunctions As New clsDatabaseFunctions
    Private mobjDataView As New DataView
    Private mObjDataTable As DataTable
    Dim mobjGridTableStyle As New DataGridTableStyle
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
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents dgEquipmentList As System.Windows.Forms.DataGrid
    Friend WithEvents lblHeader As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmOQEquipmentList))
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.lblHeader = New System.Windows.Forms.Label
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.dgEquipmentList = New System.Windows.Forms.DataGrid
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.dgEquipmentList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.lblHeader)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.dgEquipmentList)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(488, 456)
        Me.Panel1.TabIndex = 12
        '
        'lblHeader
        '
        Me.lblHeader.BackColor = System.Drawing.Color.AliceBlue
        Me.lblHeader.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeader.Location = New System.Drawing.Point(35, 7)
        Me.lblHeader.Name = "lblHeader"
        Me.lblHeader.Size = New System.Drawing.Size(500, 18)
        Me.lblHeader.TabIndex = 19
        Me.lblHeader.Text = "A.  Equipment Listing"
        Me.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel2.Controls.Add(Me.PictureBox1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(486, 32)
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
        'dgEquipmentList
        '
        Me.dgEquipmentList.BackgroundColor = System.Drawing.Color.AliceBlue
        Me.dgEquipmentList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.dgEquipmentList.CaptionVisible = False
        Me.dgEquipmentList.DataMember = ""
        Me.dgEquipmentList.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgEquipmentList.Location = New System.Drawing.Point(8, 48)
        Me.dgEquipmentList.Name = "dgEquipmentList"
        Me.dgEquipmentList.ParentRowsVisible = False
        Me.dgEquipmentList.ReadOnly = True
        Me.dgEquipmentList.RowHeadersVisible = False
        Me.dgEquipmentList.Size = New System.Drawing.Size(576, 224)
        Me.dgEquipmentList.TabIndex = 18
        '
        'frmOQEquipmentList
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(488, 424)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmOQEquipmentList"
        Me.Text = "Equipment Listing"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.dgEquipmentList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Constants"
    Private Const ConstSrNo As String = "SrNo"
    Private Const ConstEquipmentName As String = "EquipmentName"
    Private Const ConstSerialNumber As String = "SerialNumber"
    Private Const ConstEquipmentID As String = "EquipmentID"
    Private Const ConstCheckedBy As String = "CheckedBy"
    Private Const ConstVerifiedBy As String = "VerifiedBy"

#End Region

#Region " Form Events "
    Private Sub frmOQEquipmentList_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            If (mintMode = ENUM_IQOQPQ_STATUS.OQ) Then
                'mfrmOQEquipmentList = Me
                subAssignTextForOQ()
            ElseIf (mintMode = ENUM_IQOQPQ_STATUS.PQ) Then
                'mfrmPQEquipmentList = Me
                subAssignTextForPQ()
            End If

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

    Private Sub frmOQEquipmentList_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

        Try
            If Not (mblnModeLockStatus) Then
                dgEquipmentList.CurrentCell() = (New DataGridCell(dgEquipmentList.CurrentRowIndex + 1, 0))
                If Not funcSaveEquipmentListData() Then
                    Throw New Exception("Error in Saving Equipment List Data.")
                End If
                dgEquipmentList.TableStyles.Clear()
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

    Private Sub dgEquipmentList_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgEquipmentList.CurrentCellChanged
        mObjDataTable.Columns(0).ReadOnly = False
        If mObjDataTable.Rows.Count = 0 Then
            mObjDataTable.Columns(0).DefaultValue = 1
        Else
            dgEquipmentList.Item(dgEquipmentList.CurrentRowIndex, 0) = dgEquipmentList.CurrentRowIndex + 1
        End If

        mObjDataTable.Columns(0).ReadOnly = True
        If dgEquipmentList.CurrentRowIndex >= 10 Then
            mobjDataView.AllowNew = False
        End If
    End Sub

#End Region

#Region "Text for OQ/PQ Headers"
    Private Sub subAssignTextForOQ()
        lblHeader.Text = "D.I  Equipment Listing"
    End Sub
    Private Sub subAssignTextForPQ()
        lblHeader.Text = "E.I  Equipment Listing"
    End Sub
#End Region

#Region " General Private functions "

    '--------------------------------------------------------
    '    General functions used for OQ / PQ Equipment Listing.
    '--- funcInitialize - To Initialize form and to get values for OQ / PQ Equipment List from database and display them.
    '--- subCreateDataTable - To Create Columns in the Data Table.
    '--- funcGetEquipmentListRecords - To Get OQ/PQ Equipment List Records from Database into DataTable.
    '--- subFormatDataGrid - To format the Data Grid.
    '--- funcSaveEquipmentListData - To Save the Entered Records into Database.
    '--- funcInsertEquipmentListData - To Add/Insert New Equipment List Data in Database.
    '--- funcUpdateEquipmentListData - To Update Equipment List Data in Database.
    '--- funcDeleteEquipmentListData - To Delete Equipment List Data from Database.

    Private Sub funcInitialize()
        '=====================================================================
        ' Procedure Name        :   funcInitailize
        ' Description           :   To Initialize form and to get values for OQ/PQ Equipment List from database and display them.
        ' Purpose               :   To Initialize form and to get values for OQ/PQ Equipment List from database and display them.
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
            mObjDataTable = New DataTable("EquipmentList")

            subCreateDataTable()

            'code added by ; dinesh wagh on 15.2.2010
            '--------------------------------------
            mintMode = 1
            '---------------------------------------


            mobjTmpDt = gobjDataAccess.funcGetOQEquipmentListRecords(mintMode)

            If Not mobjTmpDt Is Nothing Then
                If Not mobjTmpDt.Rows.Count = 0 Then
                    For intCount = 0 To mobjTmpDt.Rows.Count - 1
                        objDataRow = mObjDataTable.NewRow
                        objDataRow.Item(ConstSrNo) = intCount + 1 'by pankaj on 6 Dec 07'CInt(mobjTmpDt.Rows.Item(intCount).Item("EquipmentListID"))
                        objDataRow.Item(ConstEquipmentName) = gfuncWordWrap(CStr(mobjTmpDt.Rows.Item(intCount).Item("Name")), 20) '29.6.2010 by dinesh wagh to word wrap the text.
                        objDataRow.Item(ConstSerialNumber) = gfuncWordWrap(CStr(mobjTmpDt.Rows.Item(intCount).Item("SerialNo")), 20) '29.6.2010 by dinesh wagh to word wrap the text.
                        objDataRow.Item(ConstCheckedBy) = gfuncWordWrap(CStr(mobjTmpDt.Rows.Item(intCount).Item("CheckedBy")), 20) '29.6.2010 by dinesh wagh to word wrap the text.
                        objDataRow.Item(ConstVerifiedBy) = gfuncWordWrap(CStr(mobjTmpDt.Rows.Item(intCount).Item("VerifiedBy")), 20) '29.6.2010 by dinesh wagh to word wrap the text.
                        objDataRow.Item(ConstEquipmentID) = CInt(mobjTmpDt.Rows.Item(intCount).Item("EquipmentListID"))
                        mObjDataTable.Rows.Add(objDataRow)
                    Next
                End If
            End If

            If IsNothing(mObjDataTable) = True Then
                Throw New Exception("Error in Getting Equipment List Records.")
            Else

                subFormatDataGrid()
            End If

            'If funcGetEquipmentListRecords() Then
            '    subFormatDataGrid()
            'Else
            '    Throw New Exception("Error in Getting Equipment List Records.")
            'End If

            mblnModeLockStatus = gobjDataAccess.funcCheckModeLocked(mintMode)
            If (mblnModeLockStatus) Then
                dgEquipmentList.ReadOnly = True
            Else
                dgEquipmentList.ReadOnly = False
            End If

            dgEquipmentList.ReadOnly = True 'code added by ; dinesh wagh on 15.2.2010


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
        Dim objDataColumn As DataColumn

        Try
            objDataColumn = New DataColumn("SrNo", GetType(Integer))
            objDataColumn.ReadOnly = True
            ' objDataColumn.AutoIncrement = True
            mObjDataTable.Columns.Add(objDataColumn)

            mObjDataTable.Columns.Add(New DataColumn("EquipmentName", GetType(String)))
            mObjDataTable.Columns.Add(New DataColumn("SerialNumber", GetType(String)))
            mObjDataTable.Columns.Add(New DataColumn("CheckedBy", GetType(String)))
            mObjDataTable.Columns.Add(New DataColumn("VerifiedBy", GetType(String)))
            mObjDataTable.Columns.Add(New DataColumn("EquipmentID", GetType(Integer)))

        Catch ex As Exception
            '---------------------------------------------------------
            'Error logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = "Error in Creating Equipment List Data-Table."
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

    'Private Function funcGetEquipmentListRecords() As Boolean
    '    '=====================================================================
    '    ' Procedure Name        :   funcGetEquipmentListRecords
    '    ' Description           :   To Get OQ/PQ Equipment List Records from Database into DataTable.
    '    ' Purpose               :   To Get OQ/PQ Equipment List Records from Database into DataTable.
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
    '        sql_string = "Select EquipmentListID ,Name ,SerialNo ,CheckedBy , VerifiedBy from EquipmentList where CheckStatusIQOQPQ = " & mintMode & " "

    '        'reader_status = mclsDBFunctions.GetRecords(sql_string, mobjOleDBconnection, objReader)

    '        If Not (reader_status) Then
    '            Throw New Exception("Error in Opening Connection during Getting Equipment List Details.")
    '        End If

    '        rec_cnt = 1
    '        While objReader.Read
    '            objDataRow = mObjDataTable.NewRow()

    '            objDataRow("SrNo") = rec_cnt
    '            objDataRow("EquipmentName") = CStr(objReader.Item("Name"))
    '            objDataRow("SerialNumber") = CStr(objReader.Item("SerialNo"))
    '            objDataRow("CheckedBy") = objReader.Item("CheckedBy")
    '            objDataRow("VerifiedBy") = objReader.Item("VerifiedBy")
    '            objDataRow("EquipmentID") = Convert.ToInt32(objReader.Item("EquipmentListID"))

    '            mObjDataTable.Rows.Add(objDataRow)
    '            rec_cnt = rec_cnt + 1
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

        Try
            dgEquipmentList.TableStyles.Clear()
            mobjDataView.Table = mObjDataTable
            mobjDataView.AllowNew = True
            dgEquipmentList.DataSource = mobjDataView
            'dgEquipmentList.ReadOnly = False

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
            mobjGridTableStyle.PreferredRowHeight = 34 '29.6.2010 by dinesh wagh.
            mobjGridTableStyle.MappingName = "EquipmentList"

            objTextColumn = New DataGridTextBoxColumn
            objTextColumn.MappingName = "SrNo"
            objTextColumn.HeaderText = "Sr.No."
            objTextColumn.Width = 40
            objTextColumn.ReadOnly = True
            objTextColumn.NullText = ""
            objTextColumn.Alignment = HorizontalAlignment.Center
            mobjGridTableStyle.GridColumnStyles.Add(objTextColumn)

            objTextColumn = New DataGridTextBoxColumn
            objTextColumn.MappingName = "EquipmentName"
            objTextColumn.HeaderText = "Model"
            objTextColumn.Width = 120
            objTextColumn.ReadOnly = False
            objTextColumn.NullText = ""
            objTextColumn.Alignment = HorizontalAlignment.Left
            mobjGridTableStyle.GridColumnStyles.Add(objTextColumn)

            objTextColumn = New DataGridTextBoxColumn
            objTextColumn.MappingName = "SerialNumber"
            objTextColumn.HeaderText = "Instrument Serial No."
            objTextColumn.Width = 120
            objTextColumn.ReadOnly = False
            objTextColumn.NullText = ""
            objTextColumn.Alignment = HorizontalAlignment.Center
            mobjGridTableStyle.GridColumnStyles.Add(objTextColumn)

            objTextColumn = New DataGridTextBoxColumn
            objTextColumn.MappingName = "CheckedBy"
            objTextColumn.HeaderText = "Checked By"
            objTextColumn.Width = 140
            objTextColumn.ReadOnly = False
            objTextColumn.NullText = ""
            objTextColumn.Alignment = HorizontalAlignment.Left
            mobjGridTableStyle.GridColumnStyles.Add(objTextColumn)

            objTextColumn = New DataGridTextBoxColumn
            objTextColumn.MappingName = "VerifiedBy"
            objTextColumn.HeaderText = "Verified By"
            objTextColumn.Width = 150
            objTextColumn.ReadOnly = False
            objTextColumn.NullText = ""
            objTextColumn.Alignment = HorizontalAlignment.Left
            mobjGridTableStyle.GridColumnStyles.Add(objTextColumn)

            objTextColumn = New DataGridTextBoxColumn
            objTextColumn.MappingName = "EquipmentID"
            objTextColumn.HeaderText = "EquipmentID"
            objTextColumn.Width = 0
            objTextColumn.ReadOnly = True
            objTextColumn.NullText = ""
            mobjGridTableStyle.GridColumnStyles.Add(objTextColumn)

            mobjGridTableStyle.GridLineColor = Color.Black
            dgEquipmentList.TableStyles.Add(mobjGridTableStyle)
        Catch ex As Exception
            '---------------------------------------------------------
            'Error logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = "Error in Formating Equipment List Data-Grid."
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

    Public Function funcSaveEquipmentListData() As Boolean
        '=====================================================================
        ' Procedure Name        :   funcSaveEquipmentListData
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

        Dim intRecordCount, intEquipmentID, temp_cnt As Integer
        Dim strEquipmentName, strSerialNo, strCheckedBy, strVerifiedBy As String
        Dim status As Boolean = True

        Try
            intRecordCount = mObjDataTable.Rows.Count

            For temp_cnt = 0 To (intRecordCount - 1)
                '--- To Check if Equipment ID is Null.
                'intEquipmentID = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("EquipmentID").Ordinal)
                If IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("EquipmentID").Ordinal)) Then
                    If (IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("EquipmentName").Ordinal)) = False) Then
                        strEquipmentName = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("EquipmentName").Ordinal)
                        strEquipmentName = strEquipmentName.Replace(vbCrLf, " ") 'code added by : dinesh wagh on 29.6.2010
                        strSerialNo = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("SerialNumber").Ordinal)
                        strSerialNo = strSerialNo.Replace(vbCrLf, " ") 'code added by : dinesh wagh on 29.6.2010
                        strCheckedBy = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("CheckedBy").Ordinal)
                        strCheckedBy = strCheckedBy.Replace(vbCrLf, " ") 'code added by : dinesh wagh on 29.6.2010
                        strVerifiedBy = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("VerifiedBy").Ordinal)
                        strVerifiedBy = strVerifiedBy.Replace(vbCrLf, " ") 'code added by : dinesh wagh on 29.6.2010
                        status = gobjDataAccess.funcInsertOQEquipmentListData(strEquipmentName, strSerialNo, strCheckedBy, strVerifiedBy, mintMode)
                        If Not (status) Then
                            Throw New Exception("Error in Saving Equipment List Details.")
                        End If
                    End If
                Else
                    If IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("EquipmentName").Ordinal)) Or IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("SerialNumber").Ordinal)) Or IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("CheckedBy").Ordinal)) Or IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("VerifiedBy").Ordinal)) Then
                        intEquipmentID = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("EquipmentID").Ordinal)
                        status = gobjDataAccess.funcDeleteOQEquipmentListData(intEquipmentID, mintMode)
                        If Not (status) Then
                            Throw New Exception("Error in Deleting Equipment List Details.")
                        End If

                    Else
                        intEquipmentID = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("EquipmentID").Ordinal)
                        strEquipmentName = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("EquipmentName").Ordinal)
                        strEquipmentName = strEquipmentName.Replace(vbCrLf, " ") 'code added by : dinesh wagh on 29.6.2010
                        strSerialNo = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("SerialNumber").Ordinal)
                        strSerialNo = strSerialNo.Replace(vbCrLf, " ") 'code added by : dinesh wagh on 29.6.2010
                        strCheckedBy = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("CheckedBy").Ordinal)
                        strCheckedBy = strCheckedBy.Replace(vbCrLf, " ") 'code added by : dinesh wagh on 29.6.2010
                        strVerifiedBy = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("VerifiedBy").Ordinal)
                        strVerifiedBy = strVerifiedBy.Replace(vbCrLf, " ") 'code added by : dinesh wagh on 29.6.2010
                        status = gobjDataAccess.funcUpdateOQEquipmentListData(strEquipmentName, strSerialNo, strCheckedBy, strVerifiedBy, intEquipmentID, mintMode)
                        If Not (status) Then
                            Throw New Exception("Error in Updating Equipment List Details.")
                        End If
                    End If
                End If
            Next

        Catch ex As Exception
            '---------------------------------------------------------
            'Error logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = "Error in Saving Equipment List Details."
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

    'Private Function funcInsertEquipmentListData(ByVal strEquipmentName As String, ByVal strSerialNumber As String, ByVal strCheckedBy As String, ByVal strVerifiedBy As String) As Boolean
    '    '=====================================================================
    '    ' Procedure Name        :   funcInsertEquipmentListData
    '    ' Description           :   To Add/Insert New Equipment List Data in Database.
    '    ' Purpose               :   To Add/Insert New Equipment List Data in Database.
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
    '    Dim intEquipmentID As Integer

    '    Try
    '        'Status = mclsDBFunctions.OpenConnection(mobjOleDBconnection)
    '        If Not (Status) Then
    '            Throw New Exception("Error in Opening Connection during Saving Equipment List Details.")
    '        End If

    '        '--- Generating Next Equipment ID. 
    '        'intEquipmentID = mclsDBFunctions.GetNextID("EquipmentList", "EquipmentListID", mobjOleDBconnection)

    '        '---  Query for adding  data to EquipmentList
    '        str_sql = " Insert into EquipmentList " & _
    '                  " (EquipmentListID ,Name ,SerialNo ,CheckedBy , VerifiedBy ,CheckStatusIQOQPQ) " & _
    '                  " values(?,?,?,?,?,?) "

    '        '--- Providing command object for EquimentList
    '        With objCommand
    '            .Connection = mobjOleDBconnection
    '            .CommandType = CommandType.Text
    '            .CommandText = str_sql
    '            .Parameters.Add("EquipmentListID", OleDbType.Numeric).Value = intEquipmentID
    '            .Parameters.Add("Name", OleDbType.VarChar, 50).Value = strEquipmentName
    '            .Parameters.Add("SerialNo", OleDbType.VarChar, 50).Value = strSerialNumber
    '            .Parameters.Add("CheckedBy", OleDbType.VarChar, 50).Value = strCheckedBy
    '            .Parameters.Add("VerifiedBy", OleDbType.VarChar, 50).Value = strVerifiedBy
    '            .Parameters.Add("CheckStatusIQOQPQ", OleDbType.Single).Value = mintMode
    '            .ExecuteNonQuery()
    '        End With

    '        objCommand.Dispose()
    '        Status = True

    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        '--- Error logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = "Error in Saving Equipment List Details."
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

    'Private Function funcUpdateEquipmentListData(ByVal strEquipmentName As String, ByVal strSerialNumber As String, ByVal strCheckedBy As String, ByVal strVerifiedBy As String, ByVal intEquipmentID As Integer) As Boolean
    '    '=====================================================================
    '    ' Procedure Name        :   funcUpdateEquipmentListData
    '    ' Description           :   To Update Equipment List Data in Database.
    '    ' Purpose               :   To Update Equipment List Data in Database.
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
    '            Throw New Exception("Error in Opening Connection during Updating Equipment List Details.")
    '        End If

    '        '---  Query for adding  data to EquipmentList
    '        str_sql = " Update EquipmentList " & _
    '                  " Set Name = ? ,SerialNo = ? ,CheckedBy = ? ,VerifiedBy =? " & _
    '                  " where EquipmentListID = " & intEquipmentID & " and CheckStatusIQOQPQ = " & mintMode & "  "

    '        '--- Providing command object for EquimentList
    '        With objCommand
    '            .Connection = mobjOleDBconnection
    '            .CommandType = CommandType.Text
    '            .CommandText = str_sql
    '            .Parameters.Add("Name", OleDbType.VarChar, 250).Value = strEquipmentName
    '            .Parameters.Add("SerialNo", OleDbType.VarChar, 250).Value = strSerialNumber
    '            .Parameters.Add("CheckedBy", OleDbType.VarChar, 250).Value = strCheckedBy
    '            .Parameters.Add("VerifiedBy", OleDbType.VarChar, 250).Value = strVerifiedBy
    '            .ExecuteNonQuery()
    '        End With

    '        objCommand.Dispose()
    '        Status = True

    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        '--- Error logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = "Error in Updating Equipment List Details."
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

    'Private Function funcDeleteEquipmentListData(ByVal intEquipmentID As Integer) As Boolean
    '    '=====================================================================
    '    ' Procedure Name        :   funcDeleteEquipmentListData
    '    ' Description           :   To Delete Equipment List Data from Database.
    '    ' Purpose               :   To Delete Equipment List Data from Database.
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
    '            Throw New Exception("Error in Opening Connection during Deleting Equipment List Details.")
    '        End If

    '        '--- Query to Delete from Database
    '        str_sql = " Delete * from EquipmentList " & _
    '                  " where EquipmentListID = " & intEquipmentID & " and CheckStatusIQOQPQ = " & mintMode & "  "

    '        'Status = mclsDBFunctions.AddORDeleteRecord(str_sql, mobjOleDBconnection)
    '        If (Status = False) Then
    '            MessageBox.Show("Problem in Deleting record")
    '        End If

    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        '--- Error logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = "Error in Deleting Equipment List Details."
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

End Class
