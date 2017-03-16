Option Explicit On 

Imports System.Data
Imports System.Data.OleDb
Imports System.Windows.Forms.DataGridColumnStyle

Public Class frmIQMannualList
    Inherits System.Windows.Forms.Form

#Region " Module level Declarations "
    Private mblnModeLockStatus As Boolean
    Private mstrOledbConnectionString As String
    Private mobjOleDBconnection As OleDbConnection
    'Public mclsDBFunctions As New clsDatabaseFunctions
    Private mobjDataView As New DataView
    Private mObjDataTable As DataTable
    Dim mobjGridTableStyle As New DataGridTableStyle
    Dim mCurrentGridRowNo As Integer = 0
    Dim mCurrentGridQuantity As Integer = 0

    Private Enum enumMannualListing As Integer
        SNo = 0
        EquipmentName = 1
        PartNo = 2
        Quantity = 3
        MannualID = 4
    End Enum
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
    Friend WithEvents dgManualList As System.Windows.Forms.DataGrid
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmIQMannualList))
        Me.Label3 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.dgManualList = New System.Windows.Forms.DataGrid
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.dgManualList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.AliceBlue
        Me.Label3.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(35, 7)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(408, 18)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "B.  Manual Listing"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.dgManualList)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(502, 456)
        Me.Panel1.TabIndex = 11
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel2.Controls.Add(Me.PictureBox1)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(500, 32)
        Me.Panel2.TabIndex = 19
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 11
        Me.PictureBox1.TabStop = False
        '
        'dgManualList
        '
        Me.dgManualList.BackgroundColor = System.Drawing.Color.AliceBlue
        Me.dgManualList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.dgManualList.CaptionVisible = False
        Me.dgManualList.DataMember = ""
        Me.dgManualList.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgManualList.Location = New System.Drawing.Point(8, 48)
        Me.dgManualList.Name = "dgManualList"
        Me.dgManualList.ParentRowsVisible = False
        Me.dgManualList.ReadOnly = True
        Me.dgManualList.RowHeadersVisible = False
        Me.dgManualList.Size = New System.Drawing.Size(576, 224)
        Me.dgManualList.TabIndex = 18
        '
        'frmIQMannualList
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(502, 386)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmIQMannualList"
        Me.Tag = "4"
        Me.Text = "Mannual Listing"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.dgManualList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Constants"
    Private Const ConstSrNo As String = "SrNo"
    Private Const ConstName As String = "Name"
    Private Const ConstPartNo As String = "PartNo"
    Private Const ConstQuantity As String = "Quantity"
    Private Const ConstManualListID As String = "ManualListID"
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
                'dgManualList.CurrentCell() = New DataGridCell(0, 0)
                dgManualList.CurrentCell() = New DataGridCell(dgManualList.CurrentRowIndex + 1, 0)
                If Not funcSaveIQManualListData() Then
                    Throw New Exception("Error in Saving Manual List Data.")
                End If
                dgManualList.TableStyles.Clear()
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
    '--- funcInitialize - To Initialize form and to get values for IQ Manual List from database and display them.
    '--- subCreateDataTable - To Create Columns in the Data Table.
    '--- funcGetIQManualListRecords - To Get IQ Manual List Records from Database into DataTable.
    '--- subFormatDataGrid - To format the Data Grid.
    '--- funcSaveIQManualListData - To Save the Entered Records into Database.
    '--- funcInsertIQManualListData - To Add/Insert New Manual List Data in Database.
    '--- funcUpdateIQManualListData - To Update Manual List Data in Database.
    '--- funcDeleteIQManualListData - To Delete Manual List Data from Database.

    Private Sub funcInitialize()
        '=====================================================================
        ' Procedure Name        :   funcInitailize
        ' Description           :   To Initialize form and to get values for IQ Manual List from database and display them.
        ' Purpose               :   To Initialize form and to get values for IQ Manual List from database and display them.
        ' Parameters Passed     :   None.
        ' Returns               :   None.
        ' Parameters Affected   :   None.
        ' Assumptions           :
        ' Dependencies          :
        ' Author                :   Gitesh
        ' Created               :   January, 2003 
        ' Revisions             :
        '=====================================================================
        Dim mobjTmpDt As New DataTable
        Dim intCount As Integer
        Dim objDataRow As DataRow
        Try

            'mfrmManualLst = Me
            mObjDataTable = New DataTable("ManualList")

            'subCreateDataTable()

            mObjDataTable.Columns.Add(ConstSrNo)
            mObjDataTable.Columns.Add(ConstName)
            mObjDataTable.Columns.Add(ConstPartNo)
            mObjDataTable.Columns.Add(ConstQuantity, GetType(Integer))
            mObjDataTable.Columns.Add(ConstManualListID)

            mobjTmpDt = gobjDataAccess.funcGetIQManualListRecords()

            If Not mobjTmpDt Is Nothing Then
                If Not mobjTmpDt.Rows.Count = 0 Then
                    For intCount = 0 To mobjTmpDt.Rows.Count - 1
                        objDataRow = mObjDataTable.NewRow
                        objDataRow.Item(ConstSrNo) = intCount + 1 ' by pankaj on 6 Dec 07'CInt(mobjTmpDt.Rows.Item(intCount).Item("ManualListID"))
                        objDataRow.Item(ConstName) = CStr(mobjTmpDt.Rows.Item(intCount).Item("Name"))
                        objDataRow.Item(ConstPartNo) = CStr(mobjTmpDt.Rows.Item(intCount).Item("PartNo"))
                        objDataRow.Item(ConstQuantity) = CStr(mobjTmpDt.Rows.Item(intCount).Item("Quantity"))
                        objDataRow.Item(ConstManualListID) = CInt(mobjTmpDt.Rows.Item(intCount).Item("ManualListID"))
                        mObjDataTable.Rows.Add(objDataRow)
                    Next
                End If
            End If

            If IsNothing(mObjDataTable) = True Then
                Throw New Exception("Error in Getting Equipment List Records.")
            Else
                subFormatDataGrid()
            End If
            'If funcGetIQManualListRecords() Then
            '    subFormatDataGrid()
            'Else
            '    Throw New Exception("Error in Getting Manual List Records.")
            'End If

            mblnModeLockStatus = gobjDataAccess.funcCheckModeLocked(ENUM_IQOQPQ_STATUS.IQ)
            If (mblnModeLockStatus) Then
                dgManualList.ReadOnly = True
            Else
                dgManualList.ReadOnly = False
            End If
            If (mObjDataTable.Rows.Count > 0) Then
                mCurrentGridQuantity = dgManualList.Item(0, 3)
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

            mObjDataTable.Columns.Add(New DataColumn("Name", GetType(String)))
            mObjDataTable.Columns.Add(New DataColumn("PartNo", GetType(String)))
            mObjDataTable.Columns.Add(New DataColumn("Quantity", GetType(String)))
            mObjDataTable.Columns.Add(New DataColumn("ManualListID", GetType(Integer)))

        Catch ex As Exception
            '---------------------------------------------------------
            'Error logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = "Error in Creating Manual List Data-Table."
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

    'Private Function funcGetIQManualListRecords() As Boolean
    '    '=====================================================================
    '    ' Procedure Name        :   funcGetIQManualListRecords
    '    ' Description           :   To Get IQ Manual List Records from Database into DataTable.
    '    ' Purpose               :   To Get IQ Manual List Records from Database into DataTable.
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
    '        'sql_string = "Select ManualListID ,Name ,PartNo , Quantity from IQManualList "

    '        ''reader_status = mclsDBFunctions.GetRecords(sql_string, mobjOleDBconnection, objReader)

    '        'If Not (reader_status) Then
    '        '    Throw New Exception("Error in Opening Connection during Getting Manual List Details.")
    '        'End If

    '        'rec_cnt = 1
    '        'While objReader.Read
    '        '    objDataRow = mObjDataTable.NewRow()

    '        '    objDataRow("SrNo") = rec_cnt
    '        '    objDataRow("Name") = CStr(objReader.Item("Name"))
    '        '    objDataRow("PartNo") = CStr(objReader.Item("PartNo"))
    '        '    objDataRow("Quantity") = CStr(objReader.Item("Quantity"))
    '        '    objDataRow("ManualListID") = Convert.ToInt32(objReader.Item("ManualListID"))

    '        '    mObjDataTable.Rows.Add(objDataRow)
    '        '    rec_cnt = rec_cnt + 1
    '        'End While
    '        'objReader.Close()

    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        'Error logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = "Error in Getting Manual List Records."
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
            dgManualList.TableStyles.Clear()

            mobjDataView.Table = mObjDataTable
            mobjDataView.AllowNew = True
            dgManualList.DataSource = mobjDataView
            'dgManualList.ReadOnly = False

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

            mobjGridTableStyle.MappingName = "ManualList"

            objTextColumn = New DataGridTextBoxColumn
            objTextColumn.MappingName = "SrNo"
            objTextColumn.HeaderText = "Sr.No."
            objTextColumn.Width = 50
            objTextColumn.ReadOnly = True
            objTextColumn.NullText = ""
            objTextColumn.Alignment = HorizontalAlignment.Center
            mobjGridTableStyle.GridColumnStyles.Add(objTextColumn)

            objTextColumn = New DataGridTextBoxColumn
            objTextColumn.MappingName = "Name"
            objTextColumn.HeaderText = "Manual"
            objTextColumn.Width = 220
            objTextColumn.ReadOnly = False
            objTextColumn.NullText = ""
            mobjGridTableStyle.GridColumnStyles.Add(objTextColumn)

            objTextColumn = New DataGridTextBoxColumn
            objTextColumn.MappingName = "PartNo"
            objTextColumn.HeaderText = "Part Number"
            objTextColumn.Width = 170
            objTextColumn.ReadOnly = False
            objTextColumn.NullText = ""
            objTextColumn.Alignment = HorizontalAlignment.Center
            mobjGridTableStyle.GridColumnStyles.Add(objTextColumn)

            objTextColumn = New DataGridTextBoxColumn
            objTextColumn.MappingName = "Quantity"
            objTextColumn.HeaderText = "Quantity"
            objTextColumn.Width = 130
            objTextColumn.ReadOnly = False
            objTextColumn.NullText = ""
            objTextColumn.Alignment = HorizontalAlignment.Center
            mobjGridTableStyle.GridColumnStyles.Add(objTextColumn)

            objTextColumn = New DataGridTextBoxColumn
            objTextColumn.MappingName = "ManualListID"
            objTextColumn.HeaderText = "ManualListID"
            objTextColumn.Width = 0
            objTextColumn.ReadOnly = True
            objTextColumn.NullText = ""
            mobjGridTableStyle.GridColumnStyles.Add(objTextColumn)

            mobjGridTableStyle.GridLineColor = Color.Black
            dgManualList.TableStyles.Add(mobjGridTableStyle)

        Catch ex As Exception
            '---------------------------------------------------------
            'Error logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = "Error in Formating Manual List Data-Grid."
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

    Public Function funcSaveIQManualListData() As Boolean
        '=====================================================================
        ' Procedure Name        :   funcSaveIQManualListData
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

        Dim intRecordCount, intManualListID, temp_cnt As Integer
        Dim strName, strPartNo, strQuantity As String
        Dim status As Boolean = True
        Dim objDataRow As DataRow
        Try

            'If mObjDataTable.Rows.Count = 0 Then
            '    objDataRow = mObjDataTable.NewRow()
            '    objDataRow("SrNo") = dgManualList.Item(0, 0)
            '    objDataRow("Name") = dgManualList.Item(0, 1)
            '    objDataRow("PartNo") = dgManualList.Item(0, 2)
            '    objDataRow("Quantity") = dgManualList.Item(0, 3)
            '    objDataRow("ManualListID") = dgManualList.Item(0, 4)
            '    mObjDataTable.Rows.Add(objDataRow)
            'End If

            intRecordCount = mObjDataTable.Rows.Count

            For temp_cnt = 0 To (intRecordCount - 1)
                '--- To Check if Manual List ID is Null.
                If IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("ManualListID").Ordinal)) Then
                    If (IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("Name").Ordinal)) = False) Then
                        'If IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("Name").Ordinal)) = False Then
                        strName = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("Name").Ordinal)
                        'End If

                        'If IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("PartNo").Ordinal)) = False Then
                        strPartNo = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("PartNo").Ordinal)
                        'End If

                        strQuantity = " "
                        If IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("Quantity").Ordinal)) = False Then
                            strQuantity = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("Quantity").Ordinal)
                        End If


                        status = gobjDataAccess.funcInsertIQManualListData(strName, strPartNo, strQuantity)
                        If Not (status) Then
                            Throw New Exception("Error in Saving Manual List Details.")
                        End If
                    End If
                Else
                    If IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("Name").Ordinal)) Or IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("PartNo").Ordinal)) Or IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("Quantity").Ordinal)) Then
                        intManualListID = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("ManualListID").Ordinal)
                        status = gobjDataAccess.funcDeleteIQManualListData(intManualListID)
                        If Not (status) Then
                            Throw New Exception("Error in Deleting Manual List Details.")
                        End If
                    Else
                        intManualListID = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("ManualListID").Ordinal)
                        strName = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("Name").Ordinal)
                        strPartNo = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("PartNo").Ordinal)
                        strQuantity = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("Quantity").Ordinal)
                        status = gobjDataAccess.funcUpdateIQManualListData(strName, strPartNo, strQuantity, intManualListID)
                        If Not (status) Then
                            Throw New Exception("Error in Updating Manual List Details.")
                        End If
                    End If
                End If
            Next
        Catch ex As Exception
            '---------------------------------------------------------
            'Error logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = "Error in Saving Manual List Details."
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

    'Private Function funcInsertIQManualListData(ByVal strName As String, ByVal strPartNo As String, ByVal strQuantity As String) As Boolean
    '    '=====================================================================
    '    ' Procedure Name        :   funcInsertIQEquipmentListData
    '    ' Description           :   To Add/Insert New Manual List Data in Database.
    '    ' Purpose               :   To Add/Insert New Manual List Data in Database.
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
    '    Dim intManualListID As Integer

    '    Try
    '        'Status = mclsDBFunctions.OpenConnection(mobjOleDBconnection)
    '        If Not (Status) Then
    '            Throw New Exception("Error in Opening Connection during Saving Manual List Details.")
    '        End If

    '        '--- Generating Next Equipment ID. 
    '        'intManualListID = mclsDBFunctions.GetNextID("IQManualList", "ManualListID", mobjOleDBconnection)

    '        '---  Query for adding  data to EquipmentList
    '        str_sql = " Insert into IQManualList " & _
    '                  " (ManualListID ,Name ,PartNo ,Quantity) " & _
    '                  " values(?,?,?,?) "

    '        '--- Providing command object for EquimentList
    '        With objCommand
    '            .Connection = mobjOleDBconnection
    '            .CommandType = CommandType.Text
    '            .CommandText = str_sql
    '            .Parameters.Add("ManualListID", OleDbType.Numeric).Value = intManualListID
    '            .Parameters.Add("Name", OleDbType.VarChar, 50).Value = strName
    '            .Parameters.Add("PartNo", OleDbType.VarChar, 50).Value = strPartNo
    '            .Parameters.Add("Quantity", OleDbType.VarChar, 50).Value = strQuantity
    '            .ExecuteNonQuery()
    '        End With

    '        objCommand.Dispose()
    '        Status = True

    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        '--- Error logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = "Error in Saving Manual List Details."
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

    'Private Function funcUpdateIQManualListData(ByVal strName As String, ByVal strPartNo As String, ByVal strQuantity As String, ByVal intManualListID As Integer) As Boolean
    '    '=====================================================================
    '    ' Procedure Name        :   funcUpdateIQManualListData
    '    ' Description           :   To Update Manual List Data in Database.
    '    ' Purpose               :   To Update Manual List Data in Database.
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
    '            Throw New Exception("Error in Opening Connection during Updating Manual List Details.")
    '        End If

    '        '---  Query for adding  data to EquipmentList
    '        str_sql = " Update IQManualList " & _
    '                  " Set Name = ? ,PartNo = ? , Quantity = ? " & _
    '                  " where ManualListID = " & intManualListID & " "

    '        '--- Providing command object for EquimentList
    '        With objCommand
    '            .Connection = mobjOleDBconnection
    '            .CommandType = CommandType.Text
    '            .CommandText = str_sql
    '            .Parameters.Add("Name", OleDbType.VarChar, 250).Value = strName
    '            .Parameters.Add("PartNo", OleDbType.VarChar, 250).Value = strPartNo
    '            .Parameters.Add("Quantity", OleDbType.VarChar, 250).Value = strQuantity
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

    'Private Function funcDeleteIQManualListData(ByVal intManuaListID As Integer) As Boolean
    '    '=====================================================================
    '    ' Procedure Name        :   funcDeleteIQManualListData
    '    ' Description           :   To Delete Manual List Data from Database.
    '    ' Purpose               :   To Delete Manual List Data from Database.
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
    '            Throw New Exception("Error in Opening Connection during Deleting Manual List Details.")
    '        End If

    '        '--- Query to Delete from Database
    '        str_sql = " Delete * from IQManualList " & _
    '                  " where ManualListID = " & intManuaListID & " "

    '        'Status = mclsDBFunctions.AddORDeleteRecord(str_sql, mobjOleDBconnection)
    '        If (Status = False) Then
    '            MessageBox.Show("Problem in Deleting record")
    '        End If

    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        '--- Error logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = "Error in Deleting Manual List Details."
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

    Private Sub dgManualList_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgManualList.CurrentCellChanged
        Try


        mObjDataTable.Columns(0).ReadOnly = False

            If mObjDataTable.Rows.Count = 0 Then
                mObjDataTable.Columns(0).DefaultValue = 1
            Else
                If (dgManualList.CurrentRowIndex <> -1) Then
                    dgManualList.Item(dgManualList.CurrentRowIndex, 0) = dgManualList.CurrentRowIndex + 1
                End If
            End If

            mObjDataTable.Columns(0).ReadOnly = True

            If dgManualList.CurrentRowIndex >= 10 Then
                mobjDataView.AllowNew = False
            End If
            ''Added By Pankaj on Sat 19 May 07 5:37
            'If (mCurrentGridRowNo <> -1) Then
            '    If (Convert.ToString(dgManualList.Item(mCurrentGridRowNo, 3)).Trim() <> "") And Not IsDBNull(dgManualList.Item(mCurrentGridRowNo, 3)) Then
            '        If Not (IsNumeric(dgManualList.Item(mCurrentGridRowNo, 3))) Then
            '            dgManualList.Item(mCurrentGridRowNo, 3) = mCurrentGridQuantity
            '        End If
            '    End If
            'End If

            'mCurrentGridRowNo = dgManualList.CurrentRowIndex
            'If (dgManualList.CurrentRowIndex <> -1) Then  'Condition added by PAnkaj 30 May 07
            '    If Not (IsDBNull(dgManualList.Item(dgManualList.CurrentRowIndex, 3))) Then
            '        mCurrentGridQuantity = dgManualList.Item(dgManualList.CurrentRowIndex, 3)
            '    Else
            '        mCurrentGridQuantity = 0
            '    End If
            'End If


            '-------15.2.2010    by dinesh wagh
            If mObjDataTable.Rows.Count = 0 And dgManualList.CurrentRowIndex <> -1 Then
                dgManualList.Item(0, 0) = 1
            End If
            '-------------


        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.ProcessError(ErrorHandler.ErrorHandler.EnumErrorType.Critical, ex)
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub frmIQMannualList_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed

    End Sub
End Class
