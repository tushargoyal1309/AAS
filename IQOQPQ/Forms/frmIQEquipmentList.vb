Option Explicit On 

Imports System.Data
Imports System.Data.OleDb
Imports System.Windows.Forms.DataGridColumnStyle

Public Class frmIQEquipmentList
    Inherits System.Windows.Forms.Form

#Region " Module level Declarations "
    Private mblnModeLockStatus As Boolean
    'Private mstrOledbConnectionString As String
    'Private mobjOleDBconnection As OleDbConnection
    'Public mclsDBFunctions As New clsDatabaseFunctions

    Private mObjDataTable As DataTable
    Dim mobjGridTableStyle As New DataGridTableStyle
    Dim objDataView As DataView

    '30.6.2010 by dinesh wagh
    '---------------------------------------------
    Dim mintRowIndex, mintColumnIndex As Integer
    Private Const CONST_ModelColumnSize = 18
    Private Const CONST_InstSrNoColumnSize = 20
    Private Const CONST_CheckedByColumnSize = 20
    Private Const CONST_VerifiedByColumnSize = 23

    '------------------------------------------

    '30.6.2010 by dinesh wagh
    Private Enum EnumColumns
        SrNo = 0
        Model = 1
        InstSrNo = 2
        CheckedBy = 3
        VerifiedBy = 4
    End Enum


#End Region

#Region "Constants"
    Private Const ConstSrNo As String = "SrNo"
    Private Const ConstEquipmentName As String = "EquipmentName"
    Private Const ConstSerialNumber As String = "SerialNumber"
    Private Const ConstEquipmentID As String = "EquipmentID"
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
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblHeader As System.Windows.Forms.Label
    Friend WithEvents dgEquipmentList As System.Windows.Forms.DataGrid
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lblSystem As System.Windows.Forms.Label
    Friend WithEvents lblAAS As System.Windows.Forms.Label
    Friend WithEvents lblModelNo As System.Windows.Forms.Label
    Friend WithEvents cmbModelList As System.Windows.Forms.ComboBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmIQEquipmentList))
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.cmbModelList = New System.Windows.Forms.ComboBox
        Me.lblModelNo = New System.Windows.Forms.Label
        Me.lblAAS = New System.Windows.Forms.Label
        Me.lblSystem = New System.Windows.Forms.Label
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
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.cmbModelList)
        Me.Panel1.Controls.Add(Me.lblModelNo)
        Me.Panel1.Controls.Add(Me.lblAAS)
        Me.Panel1.Controls.Add(Me.lblSystem)
        Me.Panel1.Controls.Add(Me.lblHeader)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.dgEquipmentList)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(471, 456)
        Me.Panel1.TabIndex = 10
        '
        'cmbModelList
        '
        Me.cmbModelList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbModelList.Items.AddRange(New Object() {"AA301", "AA303", "AA303D"})
        Me.cmbModelList.Location = New System.Drawing.Point(408, 45)
        Me.cmbModelList.Name = "cmbModelList"
        Me.cmbModelList.Size = New System.Drawing.Size(80, 23)
        Me.cmbModelList.TabIndex = 24
        '
        'lblModelNo
        '
        Me.lblModelNo.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblModelNo.Location = New System.Drawing.Point(344, 48)
        Me.lblModelNo.Name = "lblModelNo"
        Me.lblModelNo.Size = New System.Drawing.Size(64, 16)
        Me.lblModelNo.TabIndex = 22
        Me.lblModelNo.Text = "Model No. "
        '
        'lblAAS
        '
        Me.lblAAS.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAAS.Location = New System.Drawing.Point(80, 48)
        Me.lblAAS.Name = "lblAAS"
        Me.lblAAS.Size = New System.Drawing.Size(232, 16)
        Me.lblAAS.TabIndex = 21
        Me.lblAAS.Text = "Atomic Absorption Spectrometer"
        '
        'lblSystem
        '
        Me.lblSystem.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSystem.Location = New System.Drawing.Point(8, 48)
        Me.lblSystem.Name = "lblSystem"
        Me.lblSystem.Size = New System.Drawing.Size(64, 16)
        Me.lblSystem.TabIndex = 20
        Me.lblSystem.Text = "System   :"
        '
        'lblHeader
        '
        Me.lblHeader.BackColor = System.Drawing.Color.AliceBlue
        Me.lblHeader.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeader.Location = New System.Drawing.Point(35, 7)
        Me.lblHeader.Name = "lblHeader"
        Me.lblHeader.Size = New System.Drawing.Size(376, 18)
        Me.lblHeader.TabIndex = 10
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
        Me.Panel2.Size = New System.Drawing.Size(469, 32)
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
        'dgEquipmentList
        '
        Me.dgEquipmentList.BackgroundColor = System.Drawing.Color.AliceBlue
        Me.dgEquipmentList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.dgEquipmentList.CaptionVisible = False
        Me.dgEquipmentList.DataMember = ""
        Me.dgEquipmentList.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgEquipmentList.Location = New System.Drawing.Point(8, 93)
        Me.dgEquipmentList.Name = "dgEquipmentList"
        Me.dgEquipmentList.ParentRowsVisible = False
        Me.dgEquipmentList.ReadOnly = True
        Me.dgEquipmentList.RowHeadersVisible = False
        Me.dgEquipmentList.Size = New System.Drawing.Size(576, 170)
        Me.dgEquipmentList.TabIndex = 18
        '
        'frmIQEquipmentList
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(471, 386)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmIQEquipmentList"
        Me.Tag = "3"
        Me.Text = "Equipment Listing"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.dgEquipmentList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Form Events "
    Private Sub frmIQEquipmentList_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

    Private Sub frmIQEquipmentList_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Try
            If Not (mblnModeLockStatus) Then
                dgEquipmentList.CurrentCell() = (New DataGridCell(dgEquipmentList.CurrentRowIndex + 1, 0))
                If Not funcSaveIQEquipmentListData() Then
                    Throw New Exception("Error in Saving Equipment List Data.")
                End If
                dgEquipmentList.TableStyles.Clear()
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
    '--- funcInitialize - To Initialize form and to get values for IQ Equipment List from database and display them.
    '--- subCreateDataTable - To Create Columns in the Data Table.
    '--- funcGetIQEquipmentListRecords - To Get IQ Equipment List Records from Database into DataTable.
    '--- subFormatDataGrid - To format the Data Grid.
    '--- funcSaveIQEquipmentListData - To Save the Entered Records into Database.
    '--- funcInsertIQEquipmentListData - To Add/Insert New Equipment List Data in Database.
    '--- funcUpdateIQEquipmentListData - To Update Equipment List Data in Database.
    '--- funcDeleteIQEquipmentListData - To Delete Equipment List Data from Database.

    Private Sub funcInitialize()
        '=====================================================================
        ' Procedure Name        :   funcInitailize
        ' Description           :   To Initialize form and to get values for IQ Equipment List from database and display them.
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
        'mfrmEqLst = Me
        'Dim objDataColumn As DataColumn
        Dim intRowCount As Integer
        Dim objDataRow As DataRow
        Dim intCount As Integer = 0
        Dim mobjTmpDt As New DataTable
        Try

            'code commented by ; dinesh wagh on 15.2.2010
            '-----------------------------------------------------------
            'mObjDataTable = New DataTable("EquipmentList")
            'mObjDataTable.Columns.Add(ConstSrNo)
            'mObjDataTable.Columns.Add(ConstEquipmentName)
            'mObjDataTable.Columns.Add(ConstSerialNumber)
            'mObjDataTable.Columns.Add(ConstEquipmentID)
            '-------------------------------------------------------------

            'code added by  dinesh wagh on 15.2.2010
            '------------------------------------------------------
            Dim objDataColumn As DataColumn
            objDataColumn = New DataColumn("SrNo", GetType(Integer))
            objDataColumn.ReadOnly = True
            mObjDataTable = New DataTable("EquipmentList")
            mObjDataTable.Columns.Add(objDataColumn)
            mObjDataTable.Columns.Add(New DataColumn("EquipmentName", GetType(String)))
            mObjDataTable.Columns.Add(New DataColumn("SerialNumber", GetType(String)))
            mObjDataTable.Columns.Add(New DataColumn("CheckedBy", GetType(String)))
            mObjDataTable.Columns.Add(New DataColumn("VerifiedBy", GetType(String)))
            mObjDataTable.Columns.Add(New DataColumn("EquipmentID", GetType(Integer)))
            '------------------------------------------------------------------


            mobjTmpDt = gobjDataAccess.funcGetIQEquipmentListRecords()

            If Not mobjTmpDt Is Nothing Then
                If Not mobjTmpDt.Rows.Count = 0 Then
                    For intCount = 0 To mobjTmpDt.Rows.Count - 1


                        '----------------
                        '15.2.2010   by dinesh wagh
                        objDataRow = mObjDataTable.NewRow
                        objDataRow.Item(ConstSrNo) = intCount + 1 'by pankaj on 6 Dec 07'CInt(mobjTmpDt.Rows.Item(intCount).Item("EquipmentListID"))
                        objDataRow.Item(ConstEquipmentName) = gfuncWordWrap(CStr(mobjTmpDt.Rows.Item(intCount).Item("Name")), CONST_ModelColumnSize) '29.6.2010 by dinesh wagh to word wrap the text.
                        objDataRow.Item(ConstSerialNumber) = gfuncWordWrap(CStr(mobjTmpDt.Rows.Item(intCount).Item("SerialNo")), CONST_InstSrNoColumnSize) '29.6.2010 by dinesh wagh to word wrap the text.
                        objDataRow.Item("CheckedBy") = gfuncWordWrap(CStr(mobjTmpDt.Rows.Item(intCount).Item("CheckedBy")), CONST_CheckedByColumnSize) '29.6.2010 by dinesh wagh to word wrap the text.
                        objDataRow.Item("VerifiedBy") = gfuncWordWrap(CStr(mobjTmpDt.Rows.Item(intCount).Item("VerifiedBy")), CONST_VerifiedByColumnSize)  '29.6.2010 by dinesh wagh to word wrap the text.
                        objDataRow.Item(ConstEquipmentID) = CInt(mobjTmpDt.Rows.Item(intCount).Item("EquipmentListID"))
                        mObjDataTable.Rows.Add(objDataRow)
                        If (Convert.ToString(mobjTmpDt.Rows.Item(intCount).Item("ModelNO")) <> "") Then
                            If (cmbModelList.Items.Contains(mobjTmpDt.Rows.Item(intCount).Item("ModelNO"))) Then
                                cmbModelList.Text = CStr(mobjTmpDt.Rows.Item(intCount).Item("ModelNO"))
                            End If
                        End If
                        '----------------


                        'code commented by  ; dinesh wagh on 15.2.2010
                        '----------------------------------------------------------------------------
                        ''objDataRow = mObjDataTable.NewRow
                        '''objDataRow.Item(ConstSrNo) = CInt(mobjTmpDt.Rows.Item(intCount).Item("EquipmentListID"))
                        '''Added by pankaj on 6 Dec 07
                        ''objDataRow.Item(ConstSrNo) = intCount + 1
                        ''objDataRow.Item(ConstEquipmentName) = CStr(mobjTmpDt.Rows.Item(intCount).Item("Name"))
                        ''objDataRow.Item(ConstSerialNumber) = CStr(mobjTmpDt.Rows.Item(intCount).Item("SerialNo"))
                        ''objDataRow.Item(ConstEquipmentID) = CInt(mobjTmpDt.Rows.Item(intCount).Item("EquipmentListID"))
                        ''mObjDataTable.Rows.Add(objDataRow)
                        ''If (Convert.ToString(mobjTmpDt.Rows.Item(intCount).Item("ModelNO")) <> "") Then
                        ''    If (cmbModelList.Items.Contains(mobjTmpDt.Rows.Item(intCount).Item("ModelNO"))) Then
                        ''        cmbModelList.Text = CStr(mobjTmpDt.Rows.Item(intCount).Item("ModelNO"))
                        ''    End If
                        ''End If
                        '---------------------------------------------------

                    Next
                End If
            End If

            If IsNothing(mObjDataTable) = True Then
                Throw New Exception("Error in Getting Equipment List Records.")
            Else

                subFormatDataGrid()
            End If

            'mobjTmpDt = New DataTable
            mblnModeLockStatus = gobjDataAccess.funcCheckModeLocked(ENUM_IQOQPQ_STATUS.IQ)
            If (mblnModeLockStatus) Then
                dgEquipmentList.ReadOnly = True
                cmbModelList.Enabled = False 'Added by pankaj on 6.12.07
            Else
                cmbModelList.Enabled = True  'Added by pankaj on 6.12.07
                dgEquipmentList.ReadOnly = False
            End If
            'Added By Pankaj Sat 19 MAy 07
            'If (cmbModelList.Text.Trim() = "") Then
            '    cmbModelList.SelectedIndex = 0
            'End If
            gobjModelNo = cmbModelList.Text
            '------

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
        Dim intRowCount As Integer
        Dim objDataRow As DataRow
        Try
            'If mObjDataTable.Columns.Count <= 0 Then
            'objDataColumn = New DataColumn("SrNo", GetType(Integer))
            'objDataColumn.ReadOnly = True
            'mObjDataTable.Columns.Add(objDataColumn)

            'mObjDataTable.Columns.Add(New DataColumn("EquipmentName", GetType(String)))
            'mObjDataTable.Columns.Add(New DataColumn("SerialNumber", GetType(String)))
            'mObjDataTable.Columns.Add(New DataColumn("EquipmentID", GetType(Integer)))
            'End If
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

    'Private Function funcGetIQEquipmentListRecords() As Boolean
    '    '=====================================================================
    '    ' Procedure Name        :   funcGetIQEquipmentListRecords
    '    ' Description           :   To Get IQ Equipment List Records from Database into DataTable.
    '    ' Purpose               :   To Get IQ Equipment List Records from Database into DataTable.
    '    ' Parameters Passed     :   None.
    '    ' Returns               :   None.
    '    ' Parameters Affected   :   None.
    '    ' Assumptions           :
    '    ' Dependencies          :
    '    ' Author                :   
    '    ' Created               :   January, 2003 
    '    ' Revisions             :
    '    '=====================================================================

    '    'Dim objReader As OleDbDataReader
    '    Dim objDataRow As DataRow
    '    Dim sql_string As String
    '    'Dim reader_status As Boolean
    '    Dim rec_cnt As Integer
    '    Dim intRowCount As Integer

    '    Try
    '        sql_string = "Select EquipmentListID ,Name ,SerialNo from EquipmentList where CheckStatusIQOQPQ = 1 "

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
    '            objDataRow("EquipmentID") = Convert.ToInt32(objReader.Item("EquipmentListID"))
    '            mObjDataTable.Rows.Add(objDataRow)

    '            rec_cnt = rec_cnt + 1
    '        End While
    '        objReader.Close()

    '        'For intRowCount = rec_cnt To 10
    '        '    objDataRow = mObjDataTable.NewRow()
    '        '    objDataRow("SrNo") = rec_cnt
    '        '    objDataRow("EquipmentName") = ""
    '        '    objDataRow("SerialNumber") = ""
    '        '    objDataRow("EquipmentID") = intRowCount
    '        '    mObjDataTable.Rows.Add(objDataRow)
    '        'Next

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
        'Dim objTextColumn As DataGridTextBoxColumn '15.2.2010 by dinesh wagh

        'Dim objDataView As New DataView
        'Dim objDataView As New DataView(mObjDataTable)
        Try

            'code commented by ; dinesh wagh on 15.2.2010
            '-------------------------------------------------------------
            ''objDataView = New DataView
            ''dgEquipmentList.TableStyles.Clear()
            ''objDataView.Table = mObjDataTable
            '''objDataView = mObjDataTable.DefaultView
            ''objDataView.AllowNew = True
            ''dgEquipmentList.DataSource = objDataView
            '''dgEquipmentList.ReadOnly = False

            ''mobjGridTableStyle.RowHeadersVisible = False
            ''mobjGridTableStyle.ResetAlternatingBackColor()
            ''mobjGridTableStyle.ResetBackColor()
            ''mobjGridTableStyle.ResetForeColor()
            ''mobjGridTableStyle.ResetGridLineColor()
            ''mobjGridTableStyle.BackColor = Color.AliceBlue
            ''mobjGridTableStyle.GridLineColor = Color.Black
            ''mobjGridTableStyle.HeaderBackColor = Color.FromArgb(205, 225, 250)
            ''mobjGridTableStyle.HeaderForeColor = Color.Black
            ''mobjGridTableStyle.AlternatingBackColor = Color.AliceBlue
            ''mobjGridTableStyle.AllowSorting = False

            ''mobjGridTableStyle.MappingName = "EquipmentList"

            ''objTextColumn = New DataGridTextBoxColumn
            ''objTextColumn.MappingName = "SrNo"
            ''objTextColumn.HeaderText = "Sr.No."
            ''objTextColumn.Width = 50
            ''objTextColumn.ReadOnly = True
            ''objTextColumn.NullText = ""
            ''objTextColumn.Alignment = HorizontalAlignment.Center
            ''mobjGridTableStyle.GridColumnStyles.Add(objTextColumn)

            ''objTextColumn = New DataGridTextBoxColumn
            ''objTextColumn.MappingName = "EquipmentName"
            ''objTextColumn.HeaderText = "Equipment Name"
            ''objTextColumn.Width = 300
            ''ob    jTextColumn.ReadOnly = False
            ''objTextColumn.NullText = ""
            ''mobjGridTableStyle.GridColumnStyles.Add(objTextColumn)

            ''objTextColumn = New DataGridTextBoxColumn
            ''objTextColumn.MappingName = "SerialNumber"
            ''objTextColumn.HeaderText = "Instrument Serial No."
            ''objTextColumn.Width = 220
            ''objTextColumn.ReadOnly = False
            ''objTextColumn.NullText = ""
            ''objTextColumn.Alignment = HorizontalAlignment.Center
            ''mobjGridTableStyle.GridColumnStyles.Add(objTextColumn)

            ''objTextColumn = New DataGridTextBoxColumn
            ''objTextColumn.MappingName = "EquipmentID"
            ''objTextColumn.HeaderText = "EquipmentID"
            ''objTextColumn.Width = 0
            ''objTextColumn.ReadOnly = True
            ''objTextColumn.NullText = ""
            ''mobjGridTableStyle.GridColumnStyles.Add(objTextColumn)

            ''mobjGridTableStyle.GridLineColor = Color.Black
            ''dgEquipmentList.TableStyles.Add(mobjGridTableStyle)
            '-------------------------------------------------------------



        'code added by ; dinesh wagh on 15.2.2010
        '--------------------------------------------------------
            Dim objTextColumn As DataGridTextBoxColumn
            Dim mobjDataView As New DataView
            mobjDataView = New DataView
            dgEquipmentList.TableStyles.Clear()
            mobjDataView.Table = mObjDataTable
            mobjDataView.AllowNew = True
            dgEquipmentList.DataSource = mobjDataView
            'dgEquipmentList.ReadOnly = False
            mobjGridTableStyle.PreferredRowHeight = 34 '9.7.2010 by Dinesh Wagh

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
            '------------------------------------------------------


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

    Public Function funcSaveIQEquipmentListData() As Boolean
        '=====================================================================
        ' Procedure Name        :   funcSaveIQEquipmentListData
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

        'code commented by ; dinesh wagh on 15.2.2010
        '-------------------------------------------------------------------
        ''Dim intRecordCount, intEquipmentID, temp_cnt As Integer
        ''Dim strEquipmentName, strSerialNo As String
        '------------------------------------------------------------
        Dim status As Boolean = True
        'mObjDataTable = New DataTable("EquipmentList")
        Dim intRecordCount, intEquipmentID, temp_cnt As Integer
        Dim strEquipmentName, strSerialNo, strCheckedBy, strVerifiedBy As String
        Try
            'subCreateDataTable()
            'code commented by : dinesh wagh on 15.2.2010
            '-------------------------------------------------------------
            ''''intRecordCount = mObjDataTable.Rows.Count
            ''''For temp_cnt = 0 To (intRecordCount - 1)

            ''''    '--- To Check if Equipment ID is Null.
            ''''    'intEquipmentID = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("EquipmentID").Ordinal)
            ''''    If IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("EquipmentID").Ordinal)) Then
            ''''        If (IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("EquipmentName").Ordinal)) = False) Then
            ''''            strEquipmentName = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("EquipmentName").Ordinal)
            ''''            strSerialNo = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("SerialNumber").Ordinal)
            ''''            status = gobjDataAccess.funcInsertIQEquipmentList(strEquipmentName, strSerialNo)
            ''''            If Not (status) Then
            ''''                Throw New Exception("Error in Saving Equipment List Details.")
            ''''            End If
            ''''        End If
            ''''    Else
            ''''        If IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("EquipmentName").Ordinal)) Or IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("SerialNumber").Ordinal)) Then
            ''''            intEquipmentID = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("EquipmentID").Ordinal)
            ''''            status = gobjDataAccess.funcDeleteIQEquipmentList(intEquipmentID)
            ''''            If Not (status) Then
            ''''                Throw New Exception("Error in Deleting Equipment List Details.")
            ''''            End If
            ''''        Else
            ''''            intEquipmentID = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("EquipmentID").Ordinal)
            ''''            strEquipmentName = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("EquipmentName").Ordinal)
            ''''            strSerialNo = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("SerialNumber").Ordinal)
            ''''            status = gobjDataAccess.funcUpdateIQEquipmentList(strEquipmentName, strSerialNo, intEquipmentID)
            ''''            If Not (status) Then
            ''''                Throw New Exception("Error in Updating Equipment List Details.")
            ''''            End If
            ''''        End If
            ''''    End If
            ''''Next
            '--------------------------------------------------
            'code added by ; dinesh wagh on 15.2.2010
            '------------------------------------------------------------
            intRecordCount = mObjDataTable.Rows.Count

            For temp_cnt = 0 To (intRecordCount - 1)
                strEquipmentName = "" : strSerialNo = "" : strCheckedBy = "" : strVerifiedBy = "" '16.06.2010 by dinesh wagh to initialize the string
                '--- To Check if Equipment ID is Null.
                'intEquipmentID = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("EquipmentID").Ordinal)
                If IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("EquipmentID").Ordinal)) Then
                    If Not (IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("EquipmentName").Ordinal))) Then strEquipmentName = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("EquipmentName").Ordinal) '16.6.2010 by dinesh wagh only Null is check before assinging value.
                    If Not (IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("SerialNumber").Ordinal))) Then strSerialNo = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("SerialNumber").Ordinal) '16.6.2010 by dinesh wagh only Null is check before assinging value.
                    If Not (IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("CheckedBy").Ordinal))) Then strCheckedBy = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("CheckedBy").Ordinal) '16.6.2010 by dinesh wagh only Null is check before assinging value.
                    If Not (IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("VerifiedBy").Ordinal))) Then strVerifiedBy = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("VerifiedBy").Ordinal) '16.6.2010 by dinesh wagh only Null is check before assinging value.
                    status = gobjDataAccess.funcInsertOQEquipmentListData(strEquipmentName, strSerialNo, strCheckedBy, strVerifiedBy, 1)
                    If Not (status) Then
                        Throw New Exception("Error in Saving Equipment List Details.")
                    End If
                Else
                    If IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("EquipmentName").Ordinal)) Or IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("SerialNumber").Ordinal)) Or IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("CheckedBy").Ordinal)) Or IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("VerifiedBy").Ordinal)) Then
                        intEquipmentID = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("EquipmentID").Ordinal)
                        status = gobjDataAccess.funcDeleteOQEquipmentListData(intEquipmentID, 1)
                        If Not (status) Then
                            Throw New Exception("Error in Deleting Equipment List Details.")
                        End If
                    Else
                        intEquipmentID = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("EquipmentID").Ordinal)
                        strEquipmentName = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("EquipmentName").Ordinal)
                        strEquipmentName = strEquipmentName.Replace(vbCrLf, " ") '29.6.2010 by dinesh wagh
                        strSerialNo = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("SerialNumber").Ordinal)
                        strSerialNo = strSerialNo.Replace(vbCrLf, " ") '29.6.2010 by dinesh wagh
                        strCheckedBy = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("CheckedBy").Ordinal)
                        strCheckedBy = strCheckedBy.Replace(vbCrLf, " ") '29.6.2010 by dinesh wagh
                        strVerifiedBy = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("VerifiedBy").Ordinal)
                        strVerifiedBy = strVerifiedBy.Replace(vbCrLf, " ") '29.6.2010 by dinesh wagh
                        status = gobjDataAccess.funcUpdateOQEquipmentListData(strEquipmentName, strSerialNo, strCheckedBy, strVerifiedBy, intEquipmentID, 1)
                        If Not (status) Then
                            Throw New Exception("Error in Updating Equipment List Details.")
                        End If
                    End If
                End If
            Next
            '---------------------------------------------
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
    'Private Function funcInsertIQEquipmentListData(ByVal strEquipmentName As String, ByVal strSerialNumber As String) As Boolean
    '    '=====================================================================
    '    ' Procedure Name        :   funcInsertIQEquipmentListData
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
    '        Status = mclsDBFunctions.OpenConnection(mobjOleDBconnection)
    '        If Not (Status) Then
    '            Throw New Exception("Error in Opening Connection during Saving Equipment List Details.")
    '        End If

    '        '--- Generating Next Equipment ID. 
    '        intEquipmentID = mclsDBFunctions.GetNextID("EquipmentList", "EquipmentListID", mobjOleDBconnection)

    '        '---  Query for adding  data to EquipmentList
    '        str_sql = " Insert into EquipmentList " & _
    '                  " (EquipmentListID ,Name ,SerialNo ,CheckStatusIQOQPQ) " & _
    '                  " values(?,?,?,?) "

    '        '--- Providing command object for EquimentList
    '        With objCommand
    '            .Connection = mobjOleDBconnection
    '            .CommandType = CommandType.Text
    '            .CommandText = str_sql
    '            .Parameters.Add("EquipmentListID", OleDbType.Numeric).Value = intEquipmentID
    '            .Parameters.Add("Name", OleDbType.VarChar, 50).Value = strEquipmentName
    '            .Parameters.Add("SerialNo", OleDbType.VarChar, 50).Value = strSerialNumber
    '.Parameters.Add("CheckStatusIQOQPQ", OleDbType.Single).Value = CSng(ENUM_IQOQPQ_STATUS.IQ)
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

    'Private Function funcUpdateIQEquipmentListData(ByVal strEquipmentName As String, ByVal strSerialNumber As String, ByVal intEquipmentID As Integer) As Boolean
    '    '=====================================================================
    '    ' Procedure Name        :   funcUpdateIQEquipmentListData
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
    '        Status = mclsDBFunctions.OpenConnection(mobjOleDBconnection)
    '        If Not (Status) Then
    '            Throw New Exception("Error in Opening Connection during Updating Equipment List Details.")
    '        End If

    '        '---  Query for adding  data to EquipmentList
    '        str_sql = " Update EquipmentList " & _
    '                  " Set Name = ? ,SerialNo = ? " & _
    '                  " where EquipmentListID = " & intEquipmentID & " and CheckStatusIQOQPQ = 1  "

    '        '--- Providing command object for EquimentList
    '        With objCommand
    '            .Connection = mobjOleDBconnection
    '            .CommandType = CommandType.Text
    '            .CommandText = str_sql
    '            .Parameters.Add("Name", OleDbType.VarChar, 250).Value = strEquipmentName
    '            .Parameters.Add("SerialNo", OleDbType.VarChar, 250).Value = strSerialNumber
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

    'Private Function funcDeleteIQEquipmentListData(ByVal intEquipmentID As Integer) As Boolean
    '    '=====================================================================
    '    ' Procedure Name        :   funcDeleteIQEquipmentListData
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
    '        Status = mclsDBFunctions.OpenConnection(mobjOleDBconnection)
    '        If Not (Status) Then
    '            Throw New Exception("Error in Opening Connection during Deleting Equipment List Details.")
    '        End If

    '        '--- Query to Delete from Database
    '        str_sql = " Delete * from EquipmentList " & _
    '                  " where EquipmentListID = " & intEquipmentID & " and CheckStatusIQOQPQ = 1  "

    '        Status = mclsDBFunctions.AddORDeleteRecord(str_sql, mobjOleDBconnection)
    '        If (Status = False) Then
    '            Throw New Exception("Error in Deleting Equipment List Details.")
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

    Private Sub dgEquipmentList_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgEquipmentList.CurrentCellChanged
        'try catch added by ; dinesh wagh on 3.2.2010

        Dim intWidth As Integer
        Dim objDV As DataView

        Try

            mObjDataTable.Columns(0).ReadOnly = False
            If mObjDataTable.Rows.Count = 0 Then
                mObjDataTable.Columns(0).DefaultValue = 1
            Else
                dgEquipmentList.Item(dgEquipmentList.CurrentRowIndex, 0) = dgEquipmentList.CurrentRowIndex + 1
            End If

            mObjDataTable.Columns(0).ReadOnly = True

            If dgEquipmentList.CurrentRowIndex >= 10 Then
                objDataView.AllowNew = False
            End If

            '-------3.2.2010    by dinesh wagh
            If mObjDataTable.Rows.Count = 0 And dgEquipmentList.CurrentRowIndex <> -1 Then
                dgEquipmentList.Item(0, 0) = 1
            End If
            '-------------

            '--- 30.6.2010 by dinesh wagh
            objDV = dgEquipmentList.DataSource

            Select Case mintColumnIndex
                Case EnumColumns.Model
                    intWidth = CONST_ModelColumnSize
                Case EnumColumns.InstSrNo
                    intWidth = CONST_InstSrNoColumnSize
                Case EnumColumns.CheckedBy
                    intWidth = CONST_CheckedByColumnSize
                Case EnumColumns.VerifiedBy
                    intWidth = CONST_VerifiedByColumnSize
            End Select

            If objDV.Count > 0 And objDV.Count > mintRowIndex Then
                If mintColumnIndex <> 0 Then
                    If Not IsDBNull(objDV(mintRowIndex).Row(mintColumnIndex)) Then
                        objDV(mintRowIndex).Row(mintColumnIndex) = gfuncWordWrap(objDV(mintRowIndex).Row(mintColumnIndex), intWidth)
                        dgEquipmentList.DataSource = objDV
                    End If
                End If
            End If
            mintRowIndex = dgEquipmentList.CurrentCell.RowNumber
            mintColumnIndex = dgEquipmentList.CurrentCell.ColumnNumber
            '-------




            'If IsDBNull(mObjDataTable.Rows(dgEquipmentList.CurrentRowIndex + 1).Item(1)) And _
            ' IsDBNull(mObjDataTable.Rows(dgEquipmentList.CurrentRowIndex + 1).Item(2)) Then
            '    mObjDataTable.Rows(dgEquipmentList.CurrentRowIndex + 1).Item(0) = Nothing
            'End If

        Catch ex As Exception
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.ProcessError(ErrorHandler.ErrorHandler.EnumErrorType.Critical, ex)
        Finally
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
        End Try

    End Sub

    Private Sub cmbModelList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbModelList.SelectedIndexChanged
        'try catch added by ; dinesh wagh on 3.2.2010
        Try
            gobjModelNo = cmbModelList.Text.ToString()
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
End Class
