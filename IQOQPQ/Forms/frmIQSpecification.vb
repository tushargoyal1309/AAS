Option Explicit On 

Imports System.Data
Imports System.Data.OleDb
Imports ErrorHandler.ErrorHandler

Public Class frmIQSpecification
    Inherits System.Windows.Forms.Form

#Region " Module level Declarations "
    Private mblnModeLockStatus As Boolean
    Private mstrOledbConnectionString As String
    Private mobjOleDBconnection As OleDbConnection
    'Public mclsDBFunctions As New clsDatabaseFunctions
    Private mobjSpecificationDataView As New DataView
    Private mobjAccessoryDataView As New DataView
    Private mObjDataTable, mobjACDataTable As DataTable
    Dim mobjGridTableStyle, mobjACGridTableStyle As New DataGridTableStyle


    '30.6.2010 by dinesh wagh
    '----------------------------------------------
    Dim mintRowIndexInst, mintColumnIndexInst As Integer
    Dim mintRowIndexAccessory, mintColumnIndexAccessory As Integer
    Private Const CONST_InstrumentTable_EquipmentName_Size = 20
    Private Const CONST_InstrumentTable_Manufacture_Size = 16
    Private Const CONST_AccessoryTable_Accessories_Size = 27
    Private Const CONST_AccessoryTable_Manufacturer_Size = 25
    Private Enum EnumColumnsInstrument
        EquipmentName = 1
        Manufacture = 2
    End Enum
    Private Enum EnumColumnsAccessory
        Accessories = 1
        Manufacturer = 2
    End Enum
    '--------------------------



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
    Friend WithEvents lblAccessory As System.Windows.Forms.Label
    Friend WithEvents lblSpecification As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents dgSpecification As System.Windows.Forms.DataGrid
    Friend WithEvents dgAccessory As System.Windows.Forms.DataGrid
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblModelNo As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmIQSpecification))
        Me.lblAccessory = New System.Windows.Forms.Label
        Me.lblSpecification = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.lblModelNo = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.dgAccessory = New System.Windows.Forms.DataGrid
        Me.dgSpecification = New System.Windows.Forms.DataGrid
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.dgAccessory, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgSpecification, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblAccessory
        '
        Me.lblAccessory.BackColor = System.Drawing.Color.AliceBlue
        Me.lblAccessory.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAccessory.Location = New System.Drawing.Point(8, 255)
        Me.lblAccessory.Name = "lblAccessory"
        Me.lblAccessory.Size = New System.Drawing.Size(504, 18)
        Me.lblAccessory.TabIndex = 12
        Me.lblAccessory.Text = "Accessory to above Equipment/Instrument:"
        Me.lblAccessory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSpecification
        '
        Me.lblSpecification.BackColor = System.Drawing.Color.AliceBlue
        Me.lblSpecification.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSpecification.Location = New System.Drawing.Point(35, 7)
        Me.lblSpecification.Name = "lblSpecification"
        Me.lblSpecification.Size = New System.Drawing.Size(528, 18)
        Me.lblSpecification.TabIndex = 11
        Me.lblSpecification.Text = "C.I  INSTRUMENT DETAILS"
        Me.lblSpecification.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.lblModelNo)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.lblSpecification)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.dgAccessory)
        Me.Panel1.Controls.Add(Me.dgSpecification)
        Me.Panel1.Controls.Add(Me.lblAccessory)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(422, 456)
        Me.Panel1.TabIndex = 12
        '
        'lblModelNo
        '
        Me.lblModelNo.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblModelNo.Location = New System.Drawing.Point(200, 39)
        Me.lblModelNo.Name = "lblModelNo"
        Me.lblModelNo.Size = New System.Drawing.Size(104, 32)
        Me.lblModelNo.TabIndex = 22
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(200, 32)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "Identification  :  Thermo  -"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel2.Controls.Add(Me.PictureBox1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(420, 32)
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
        'dgAccessory
        '
        Me.dgAccessory.AlternatingBackColor = System.Drawing.Color.AliceBlue
        Me.dgAccessory.BackColor = System.Drawing.Color.AliceBlue
        Me.dgAccessory.BackgroundColor = System.Drawing.Color.AliceBlue
        Me.dgAccessory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.dgAccessory.CaptionVisible = False
        Me.dgAccessory.DataMember = ""
        Me.dgAccessory.HeaderBackColor = System.Drawing.Color.LightSkyBlue
        Me.dgAccessory.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgAccessory.Location = New System.Drawing.Point(8, 283)
        Me.dgAccessory.Name = "dgAccessory"
        Me.dgAccessory.ParentRowsBackColor = System.Drawing.Color.AliceBlue
        Me.dgAccessory.ParentRowsVisible = False
        Me.dgAccessory.ReadOnly = True
        Me.dgAccessory.RowHeadersVisible = False
        Me.dgAccessory.Size = New System.Drawing.Size(576, 168)
        Me.dgAccessory.TabIndex = 19
        '
        'dgSpecification
        '
        Me.dgSpecification.BackgroundColor = System.Drawing.Color.AliceBlue
        Me.dgSpecification.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.dgSpecification.CaptionVisible = False
        Me.dgSpecification.DataMember = ""
        Me.dgSpecification.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgSpecification.Location = New System.Drawing.Point(8, 75)
        Me.dgSpecification.Name = "dgSpecification"
        Me.dgSpecification.ParentRowsVisible = False
        Me.dgSpecification.ReadOnly = True
        Me.dgSpecification.RowHeadersVisible = False
        Me.dgSpecification.Size = New System.Drawing.Size(576, 168)
        Me.dgSpecification.TabIndex = 18
        '
        'frmIQSpecification
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(422, 370)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmIQSpecification"
        Me.Tag = "5"
        Me.Text = "Specification Of Instrument"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.dgAccessory, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgSpecification, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Constants"

    Private Const ConstSrNo As String = "SrNo"
    Private Const ConstIQEquipmentName As String = "IQEquipmentName"
    Private Const ConstIQManufacturer As String = "IQManufacturer"
    Private Const ConstIQSerialNo As String = "IQSerialNo"
    Private Const ConstIQSize As String = "IQSize"
    Private Const ConstIQMainpowerSupply As String = "IQMainpowerSupply"
    Private Const ConstIQSpecificationID As String = "IQSpecificationID"

    Private Const ConstName As String = "Name"
    Private Const ConstManufacturer As String = "Manufacturer"
    Private Const ConstSerialNo As String = "SerialNo"
    Private Const ConstSpecification As String = "Specification"
    Private Const ConstIQAccessoryID As String = "IQAccessoryID"

#End Region

#Region " Form Events "

    Private Sub frmIQSpecification_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

    Private Sub frmIQSpecification_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

        Try
            If Not (mblnModeLockStatus) Then
                dgSpecification.CurrentCell() = (New DataGridCell(dgSpecification.CurrentRowIndex + 1, 0))
                If Not funcSaveIQSpecificationData() Then
                    Throw New Exception("Error in Saving IQ Specification Data.")
                End If
                dgSpecification.TableStyles.Clear()

                dgAccessory.CurrentCell() = (New DataGridCell(dgAccessory.CurrentRowIndex + 1, 0))
                If Not funcSaveIQAccessoryData() Then
                    Throw New Exception("Error in Saving IQ Accessory Data.")
                End If
                dgAccessory.TableStyles.Clear()
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
    '--- funcInitialize - To Initialize form and to get values for IQ Specification and Accessory Data from database and display them.
    '--- subCreateSpecificationDataTable - To Create Columns in the Data Table.
    '--- funcGetIQSpecificationRecords - To Get IQ Specification Records from Database into DataTable.
    '--- subFormatSpecificationDataGrid - To format the Specification Data Grid.
    '--- funcSaveIQSpecificationData - To Save the Entered Records into Database.
    '--- funcInsertIQSpecificationData - To Add/Insert New Specification Data in Database.
    '--- funcUpdateIQSpecificationData - To Update Specification Data in Database.
    '--- funcDeleteIQSpecificationData - To Delete Specification Data from Database.

    '--- subCreateAccessoryDataTable - To Create Columns in the Data Table.
    '--- funcGetIQAccessoryRecords - To Get IQ Accessory Records from Database into DataTable.
    '--- subFormatAccessoryDataGrid - To format the Accessory Data Grid.
    '--- funcSaveIQAccessoryData - To Save the Entered Records into Database.
    '--- funcInsertIQAccessoryData - To Add/Insert New Accessory Data in Database.
    '--- funcUpdateIQAccessoryData - To Update Accessory Data in Database.
    '--- funcDeleteIQAccessoryData - To Delete Accessory Data from Database.

    Private Sub funcInitialize()
        '=====================================================================
        ' Procedure Name        :   funcInitailize
        ' Description           :   To Initialize form and to get values for IQ Specification and Accessory Data from database and display them.
        ' Purpose               :   To Initialize form and to get values for IQ Specification and Accessory Data from database and display them.
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
        Dim objDataRow As DataRow
        Dim intCount As Integer
        Try

            'mfrmSpecification = Me
            'Added By Pankaj on Sat 19 May 07 3:24 
            lblModelNo.Text = gobjModelNo.ToString()
            '----------
            mObjDataTable = New DataTable("IQSpecification")

            'mObjDataTable.Columns.Add("SrNo")
            'mObjDataTable.Columns.Add("IQEquipmentName")
            'mObjDataTable.Columns.Add("IQManufacturer")
            'mObjDataTable.Columns.Add("IQSerialNo")
            'mObjDataTable.Columns.Add("IQSize")
            'mObjDataTable.Columns.Add("IQMainpowerSupply")
            'mObjDataTable.Columns.Add("IQSpecificationID")

            mobjACDataTable = New DataTable("IQAccessory")

            'mobjACDataTable.Columns.Add("SrNo")
            'mobjACDataTable.Columns.Add("Name")
            'mobjACDataTable.Columns.Add("Manufacturer")
            'mobjACDataTable.Columns.Add("SerialNo")
            'mobjACDataTable.Columns.Add("Specification")
            'mobjACDataTable.Columns.Add("IQAccessoryID")

            subCreateSpecificationDataTable()

            objDtTmp = New DataTable

            objDtTmp = gobjDataAccess.funcGetIQSpecificationRecords()

            If Not objDtTmp Is Nothing Then
                If Not objDtTmp.Rows.Count = 0 Then
                    For intCount = 0 To objDtTmp.Rows.Count - 1
                        objDataRow = mObjDataTable.NewRow
                        objDataRow.Item(ConstSrNo) = intCount + 1 'by pankaj on 6 Dec 07'CInt(objDtTmp.Rows.Item(intCount).Item("IQSpecificationID"))
                        objDataRow.Item(ConstIQEquipmentName) = gfuncWordWrap(CStr(objDtTmp.Rows.Item(intCount).Item("IQEquipmentName")), CONST_InstrumentTable_EquipmentName_Size) '24.6.2010 by dinesh wagh
                        objDataRow.Item(ConstIQManufacturer) = gfuncWordWrap(CStr(objDtTmp.Rows.Item(intCount).Item("IQManufacturer")), CONST_InstrumentTable_Manufacture_Size)  '24.6.2010 by dinesh wagh
                        objDataRow.Item(ConstIQSerialNo) = CStr(objDtTmp.Rows.Item(intCount).Item("IQSerialNo"))
                        objDataRow.Item(ConstIQSize) = CStr(objDtTmp.Rows.Item(intCount).Item("IQSize"))
                        objDataRow.Item(ConstIQMainpowerSupply) = CStr(objDtTmp.Rows.Item(intCount).Item("IQMainpowerSupply"))
                        objDataRow.Item(ConstIQSpecificationID) = CInt(objDtTmp.Rows.Item(intCount).Item("IQSpecificationID"))
                        mObjDataTable.Rows.Add(objDataRow)

                    Next
                End If
            End If


            If IsNothing(mObjDataTable) = True Then
                Throw New Exception("Error in Getting IQ Specification Records.")
            Else
                subFormatSpecificationDataGrid()
            End If


            'If funcGetIQSpecificationRecords() Then
            '    subFormatSpecificationDataGrid()
            'Else
            '    Throw New Exception("Error in Getting IQ Specification Records.")
            'End If

            subCreateAccessoryDataTable()

            objDtTmp = New DataTable

            objDtTmp = gobjDataAccess.funcGetIQAccessoryRecords()

            If Not objDtTmp Is Nothing Then
                If Not objDtTmp.Rows.Count = 0 Then
                    For intCount = 0 To objDtTmp.Rows.Count - 1
                        objDataRow = mobjACDataTable.NewRow
                        objDataRow.Item(ConstSrNo) = CInt(objDtTmp.Rows.Item(intCount).Item("IQAccessoryID"))
                        objDataRow.Item(ConstName) = gfuncWordWrap(CStr(objDtTmp.Rows.Item(intCount).Item("Name")), CONST_AccessoryTable_Accessories_Size)   'by dinesh wagh on 25.6.2010
                        objDataRow.Item(ConstManufacturer) = gfuncWordWrap(CStr(objDtTmp.Rows.Item(intCount).Item("Manufacturer")), CONST_AccessoryTable_Manufacturer_Size)  'by dinesh wagh on 25.6.2010
                        objDataRow.Item(ConstSerialNo) = CStr(objDtTmp.Rows.Item(intCount).Item("SerialNo"))
                        objDataRow.Item(ConstSpecification) = CStr(objDtTmp.Rows.Item(intCount).Item("Specification"))
                        objDataRow.Item(ConstIQAccessoryID) = CInt(objDtTmp.Rows.Item(intCount).Item("IQAccessoryID"))
                        mobjACDataTable.Rows.Add(objDataRow)
                    Next
                End If
            End If


            If IsNothing(mobjACDataTable) = True Then
                Throw New Exception("Error in Getting IQ Accessory Records.")
            Else
                subFormatAccessoryDataGrid()
            End If


            'If funcGetIQAccessoryRecords() Then
            '    subFormatAccessoryDataGrid()
            'Else
            '    Throw New Exception("Error in Getting IQ Accessory Records.")
            'End If
            mblnModeLockStatus = gobjDataAccess.funcCheckModeLocked(ENUM_IQOQPQ_STATUS.IQ)
            If (mblnModeLockStatus) Then
                dgSpecification.ReadOnly = True
                dgAccessory.ReadOnly = True
            Else
                dgSpecification.ReadOnly = False
                dgAccessory.ReadOnly = False
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

#Region "IQ Specification Functions"

    Private Sub subCreateSpecificationDataTable()
        '=====================================================================
        ' Procedure Name        :   subCreateSpecificationDataTable
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
            mObjDataTable.Columns.Add(objDataColumn)

            mObjDataTable.Columns.Add(New DataColumn("IQEquipmentName", GetType(String)))
            mObjDataTable.Columns.Add(New DataColumn("IQManufacturer", GetType(String)))
            mObjDataTable.Columns.Add(New DataColumn("IQSerialNo", GetType(String)))
            mObjDataTable.Columns.Add(New DataColumn("IQSize", GetType(String)))
            mObjDataTable.Columns.Add(New DataColumn("IQMainpowerSupply", GetType(String)))
            mObjDataTable.Columns.Add(New DataColumn("IQSpecificationID", GetType(Integer)))
        Catch ex As Exception
            '---------------------------------------------------------
            'Error logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = "Error in Creating IQ Specification Data-Table."
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

    'Private Function funcGetIQSpecificationRecords() As Boolean
    '    '=====================================================================
    '    ' Procedure Name        :   funcGetIQSpecificationRecords
    '    ' Description           :   To Get IQ Specification Records from Database into DataTable.
    '    ' Purpose               :   To Get IQ Specification Records from Database into DataTable.
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
    '        '--- Initialising Connection 
    '        'mobjOleDBconnection = New OleDbConnection(mstrOledbConnectionString)

    '        sql_string = "Select IQSpecificationID ,IQEquipmentName ,IQManufacturer , IQSerialNo ,IQSize ,IQMainpowerSupply " & _
    '                     "from IQSpecification "

    '        'sql_string = " Select IQAccessoryID ,Name ,Manufacturer ,SerialNo ,Specification from IQAccessory "

    '        'mclsDBFunctions.OpenConnection(mobjOleDBconnection)

    '        'reader_status = mclsDBFunctions.GetRecords(sql_string, mobjOleDBconnection, objReader)

    '        If Not (reader_status) Then
    '            Throw New Exception("Error in Opening Connection during Getting IQ Specification Details.")
    '        End If

    '        rec_cnt = 1
    '        While objReader.Read
    '            objDataRow = mObjDataTable.NewRow()
    '            objDataRow("SrNo") = rec_cnt
    '            objDataRow("IQEquipmentName") = CStr(objReader.Item("IQEquipmentName"))
    '            objDataRow("IQManufacturer") = CStr(objReader.Item("IQManufacturer"))
    '            objDataRow("IQSerialNo") = CStr(objReader.Item("IQSerialNo"))
    '            objDataRow("IQSize") = CStr(objReader.Item("IQSize"))
    '            objDataRow("IQMainpowerSupply") = CStr(objReader.Item("IQMainpowerSupply"))
    '            objDataRow("IQSpecificationID") = Convert.ToInt32(objReader.Item("IQSpecificationID"))

    '            mObjDataTable.Rows.Add(objDataRow)
    '            rec_cnt = rec_cnt + 1
    '        End While
    '        objReader.Close()
    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        'Error logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = "Error in Getting IQ Specification Records."
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

    Private Sub subFormatSpecificationDataGrid()
        Dim objTextColumn As DataGridTextBoxColumn

        Try
            dgSpecification.TableStyles.Clear()
            mobjSpecificationDataView.Table = mObjDataTable
            mobjSpecificationDataView.AllowNew = True
            dgSpecification.DataSource = mobjSpecificationDataView


            'dgSpecification.ReadOnly = False

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
            mobjGridTableStyle.PreferredRowHeight = 34 '9.7.2010 by dinesh wagh


            mobjGridTableStyle.MappingName = "IQSpecification"
            objTextColumn = New DataGridTextBoxColumn
            objTextColumn.MappingName = "SrNo"
            objTextColumn.HeaderText = "Sr.No."
            objTextColumn.Width = 40
            objTextColumn.ReadOnly = True
            objTextColumn.NullText = ""
            objTextColumn.Alignment = HorizontalAlignment.Center
            mobjGridTableStyle.GridColumnStyles.Add(objTextColumn)

            objTextColumn = New DataGridTextBoxColumn
            objTextColumn.MappingName = "IQEquipmentName"
            objTextColumn.HeaderText = "Equipment Name"
            'objTextColumn.Width = 160 'code commented by ; dinesh wagh on 25.2.2010
            objTextColumn.Width = 118
            objTextColumn.TextBox.WordWrap = True '24.6.2010 by dinesh wagh to show text word wrap.
            objTextColumn.ReadOnly = False
            objTextColumn.NullText = ""
            mobjGridTableStyle.GridColumnStyles.Add(objTextColumn)

            objTextColumn = New DataGridTextBoxColumn
            objTextColumn.MappingName = "IQManufacturer"
            objTextColumn.HeaderText = "Manufacturer"
            'objTextColumn.Width = 150 'code commented by ; dinesh wagh on 25.2.2010
            objTextColumn.Width = 108
            objTextColumn.TextBox.WordWrap = True '24.6.2010 by dinesh wagh to show text word wrap.
            objTextColumn.ReadOnly = False
            objTextColumn.NullText = ""
            mobjGridTableStyle.GridColumnStyles.Add(objTextColumn)

            objTextColumn = New DataGridTextBoxColumn
            objTextColumn.MappingName = "IQSerialNo"
            objTextColumn.HeaderText = "Serial No"
            objTextColumn.Width = 60
            objTextColumn.ReadOnly = False
            objTextColumn.NullText = ""
            objTextColumn.Alignment = HorizontalAlignment.Center
            mobjGridTableStyle.GridColumnStyles.Add(objTextColumn)

            objTextColumn = New DataGridTextBoxColumn
            objTextColumn.MappingName = "IQSize"
            objTextColumn.HeaderText = "Size"
            'objTextColumn.Width = 50 'code commented by ; dinesh wagh on 25.2.2010
            objTextColumn.Width = 128 'code added by ; dinesh wagh on 25.2.2010
            objTextColumn.ReadOnly = False
            objTextColumn.NullText = ""
            objTextColumn.Alignment = HorizontalAlignment.Center
            mobjGridTableStyle.GridColumnStyles.Add(objTextColumn)

            objTextColumn = New DataGridTextBoxColumn
            objTextColumn.MappingName = "IQMainpowerSupply"
            objTextColumn.HeaderText = "Mains Power Supply"
            objTextColumn.Width = 118
            objTextColumn.ReadOnly = False
            objTextColumn.NullText = ""
            mobjGridTableStyle.GridColumnStyles.Add(objTextColumn)

            objTextColumn = New DataGridTextBoxColumn
            objTextColumn.MappingName = "IQSpecificationID"
            objTextColumn.HeaderText = "SpecificationID"
            objTextColumn.Width = 0
            objTextColumn.ReadOnly = True
            objTextColumn.NullText = ""
            mobjGridTableStyle.GridColumnStyles.Add(objTextColumn)

            mobjGridTableStyle.GridLineColor = Color.Black
            dgSpecification.TableStyles.Add(mobjGridTableStyle)
        Catch ex As Exception
            '---------------------------------------------------------
            'Error logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = "Error in Formating IQ Specification Data-Grid."
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

    Public Function funcSaveIQSpecificationData() As Boolean
        '=====================================================================
        ' Procedure Name        :   funcSaveIQSpecificationData
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

        Dim intRecordCount, intSpecificationID, temp_cnt As Integer
        Dim strEquipmentName, strManufacturer, strSerialNo, strSize, strMainPowerSupply As String
        Dim status As Boolean = True

        Try

            intRecordCount = mObjDataTable.Rows.Count

            For temp_cnt = 0 To intRecordCount - 1
                '--- To Check if Specification ID is Null.
                If IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("IQSpecificationID").Ordinal)) Then
                    'If IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("IQEquipmentName").Ordinal)) = False Then
                    strEquipmentName = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("IQEquipmentName").Ordinal)
                    'End If

                strEquipmentName = strEquipmentName.Replace(vbCrLf, " ") '24.6.2010 by dinesh wagh
                strManufacturer = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("IQManufacturer").Ordinal)
                    strManufacturer = strManufacturer.Replace(vbCrLf, " ") '24.6.2010 by dinesh wagh
                    'If IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("IQSerialNo").Ordinal)) = False Then
                    strSerialNo = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("IQSerialNo").Ordinal)
                    'End If

                    'If IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("IQSize").Ordinal)) = False Then
                    strSize = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("IQSize").Ordinal)
                    'End If

                    'If IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("IQMainpowerSupply").Ordinal)) = False Then
                    strMainPowerSupply = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("IQMainpowerSupply").Ordinal)
                    'End If

                status = gobjDataAccess.funcInsertIQSpecificationData(strEquipmentName, strManufacturer, strSerialNo, strSize, strMainPowerSupply)
                If Not (status) Then
                    Throw New Exception("Error in Saving IQ Specification Details.")
                End If
                Else
                If IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("IQEquipmentName").Ordinal)) Or IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("IQManufacturer").Ordinal)) Or IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("IQSerialNo").Ordinal)) Or IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("IQSize").Ordinal)) Or IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("IQMainpowerSupply").Ordinal)) Then
                    intSpecificationID = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("IQSpecificationID").Ordinal)
                    status = gobjDataAccess.funcDeleteIQSpecificationData(intSpecificationID)
                    If Not (status) Then
                        Throw New Exception("Error in Deleting Manual List Details.")
                    End If
                Else

                    intSpecificationID = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("IQSpecificationID").Ordinal)
                    strEquipmentName = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("IQEquipmentName").Ordinal)
                    strEquipmentName = strEquipmentName.Replace(vbCrLf, " ") '24.6.2010 by dinesh wagh
                    strManufacturer = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("IQManufacturer").Ordinal)
                    strManufacturer = strManufacturer.Replace(vbCrLf, " ") '24.6.2010 by dinesh wagh
                    strSerialNo = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("IQSerialNo").Ordinal)
                    strSize = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("IQSize").Ordinal)
                    strMainPowerSupply = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("IQMainpowerSupply").Ordinal)

                    status = gobjDataAccess.funcUpdateIQSpecificationData(strEquipmentName, strManufacturer, strSerialNo, strSize, strMainPowerSupply, intSpecificationID)
                    If Not (status) Then
                        Throw New Exception("Error in Updating IQ Specification Details.")
                    End If
                End If
                End If
            Next
        Catch ex As Exception
            '---------------------------------------------------------
            'Error logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = "Error in Saving IQ Specification Details."
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

    'Private Function funcInsertIQSpecificationData(ByVal strEquipmentName As String, ByVal strManufacturer As String, ByVal strSerialNo As String, ByVal strSize As String, ByVal strMainPowerSupply As String) As Boolean
    '    '=====================================================================
    '    ' Procedure Name        :   funcInsertIQSpecificationData
    '    ' Description           :   To Add/Insert New Specification Data in Database.
    '    ' Purpose               :   To Add/Insert New Specification Data in Database.
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
    '    Dim intSpecificationID As Integer

    '    Try
    '        'Status = mclsDBFunctions.OpenConnection(mobjOleDBconnection)
    '        If Not (Status) Then
    '            Throw New Exception("Error in Opening Connection during Saving IQ Specification Details.")
    '        End If

    '        '--- Generating Next Equipment ID. 
    '        'intSpecificationID = mclsDBFunctions.GetNextID("IQSpecification", "IQSpecificationID", mobjOleDBconnection)

    '        '---  Query for adding  data to EquipmentList
    '        str_sql = " Insert into IQSpecification " & _
    '                  " (IQSpecificationID, IQEquipmentName ,IQManufacturer ,IQSerialNo ,IQSize ,IQMainpowerSupply) " & _
    '                  " values(?,?,?,?,?,?) "

    '        '--- Providing command object. 
    '        With objCommand
    '            .Connection = mobjOleDBconnection
    '            .CommandType = CommandType.Text
    '            .CommandText = str_sql
    '            .Parameters.Add("IQSpecificationID", OleDbType.Numeric).Value = intSpecificationID
    '            .Parameters.Add("IQEquipmentName", OleDbType.VarChar, 50).Value = strEquipmentName
    '            .Parameters.Add("IQManufacturer", OleDbType.VarChar, 50).Value = strManufacturer
    '            .Parameters.Add("IQSerialNo", OleDbType.VarChar, 50).Value = strSerialNo
    '            .Parameters.Add("IQSize", OleDbType.VarChar, 50).Value = strSize
    '            .Parameters.Add("IQMainpowerSupply", OleDbType.VarChar, 50).Value = strMainPowerSupply
    '            .ExecuteNonQuery()
    '        End With

    '        objCommand.Dispose()
    '        Status = True

    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        '--- Error logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = "Error in Saving IQ Specification Details."
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

    'Private Function funcUpdateIQSpecificationData(ByVal strEquipmentName As String, ByVal strManufacturer As String, ByVal strSerialNo As String, ByVal strSize As String, ByVal strMainPowerSupply As String, ByVal intSpecificationID As Integer) As Boolean
    '    '=====================================================================
    '    ' Procedure Name        :   funcUpdateIQSpecificationData
    '    ' Description           :   To Update Specification Data in Database.
    '    ' Purpose               :   To Update Specification Data in Database.
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
    '            Throw New Exception("Error in Opening Connection during Updating IQ Specification Details.")
    '        End If

    '        '---  Query for adding  data to EquipmentList
    '        str_sql = " Update IQSpecification " & _
    '                  " Set IQEquipmentName = ? ,IQManufacturer = ? ,IQSerialNo = ? ,IQSize = ? ,IQMainpowerSupply = ? " & _
    '                  " where IQSpecificationID = " & intSpecificationID & "  "

    '        '--- Providing command object for EquimentList
    '        With objCommand
    '            .Connection = mobjOleDBconnection
    '            .CommandType = CommandType.Text
    '            .CommandText = str_sql
    '            .Parameters.Add("IQEquipmentName", OleDbType.VarChar, 250).Value = strEquipmentName
    '            .Parameters.Add("IQManufacturer", OleDbType.VarChar, 250).Value = strManufacturer
    '            .Parameters.Add("IQSerialNo", OleDbType.VarChar, 250).Value = strSerialNo
    '            .Parameters.Add("IQSize", OleDbType.VarChar, 250).Value = strSize
    '            .Parameters.Add("IQMainpowerSupply", OleDbType.VarChar, 250).Value = strMainPowerSupply
    '            .ExecuteNonQuery()
    '        End With

    '        objCommand.Dispose()
    '        Status = True

    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        '--- Error logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = "Error in Updating IQ Specification Details."
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

    'Private Function funcDeleteIQSpecificationData(ByVal intSpecificationID As Integer) As Boolean
    '    '=====================================================================
    '    ' Procedure Name        :   funcDeleteIQSpecificationData
    '    ' Description           :   To Delete Specification Data from Database.
    '    ' Purpose               :   To Delete Specification Data from Database.
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
    '            Throw New Exception("Error in Opening Connection during Deleting IQ Specification Details.")
    '        End If

    '        '--- Query to Delete from Database
    '        str_sql = " Delete * from IQSpecification " & _
    '                  " where IQSpecificationID = " & intSpecificationID & " "

    '        'Status = mclsDBFunctions.AddORDeleteRecord(str_sql, mobjOleDBconnection)
    '        If (Status = False) Then
    '            Throw New Exception("Error in Deleting IQ Specification Details.")
    '        End If

    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        '--- Error logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = "Error in Deleting IQ Specification Details."
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

#Region "Accessory Functions"

    Private Sub subCreateAccessoryDataTable()
        '=====================================================================
        ' Procedure Name        :   subCreateAccessoryDataTable
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
            mobjACDataTable.Columns.Add(objDataColumn)

            mobjACDataTable.Columns.Add(New DataColumn("Name", GetType(String)))
            mobjACDataTable.Columns.Add(New DataColumn("Manufacturer", GetType(String)))
            mobjACDataTable.Columns.Add(New DataColumn("SerialNo", GetType(String)))
            mobjACDataTable.Columns.Add(New DataColumn("Specification", GetType(String)))
            mobjACDataTable.Columns.Add(New DataColumn("IQAccessoryID", GetType(Integer)))
        Catch ex As Exception
            '---------------------------------------------------------
            'Error logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = "Error in Creating Accessories List Data-Table."
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

    'Private Function funcGetIQAccessoryRecords() As Boolean
    '    '=====================================================================
    '    ' Procedure Name        :   funcGetIQAccessoryRecords
    '    ' Description           :   To Get IQ Accessory Records from Database into DataTable.
    '    ' Purpose               :   To Get IQ Accessory Records from Database into DataTable.
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
    '        sql_string = " Select IQAccessoryID ,Name ,Manufacturer ,SerialNo ,Specification " & _
    '                     " from IQAccessory "

    '        'reader_status = mclsDBFunctions.GetRecords(sql_string, mobjOleDBconnection, objReader)

    '        If Not (reader_status) Then
    '            Throw New Exception("Error in Opening Connection during Getting IQ Accessory List Details.")
    '        End If

    '        rec_cnt = 1
    '        While objReader.Read
    '            objDataRow = mobjACDataTable.NewRow()

    '            objDataRow("SrNo") = rec_cnt
    '            objDataRow("Name") = CStr(objReader.Item("Name"))
    '            objDataRow("Manufacturer") = objReader.Item("Manufacturer")
    '            objDataRow("SerialNo") = objReader.Item("SerialNo")
    '            objDataRow("Specification") = objReader.Item("Specification")
    '            objDataRow("IQAccessoryID") = Convert.ToInt32(objReader.Item("IQAccessoryID"))

    '            mobjACDataTable.Rows.Add(objDataRow)
    '            rec_cnt = rec_cnt + 1
    '        End While
    '        objReader.Close()

    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        'Error logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = "Error in Getting IQ Accessory List Records."
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

    Private Sub subFormatAccessoryDataGrid()
        Dim objTextColumn As DataGridTextBoxColumn

        Try
            dgAccessory.TableStyles.Clear()
            mobjAccessoryDataView.Table = mobjACDataTable
            mobjAccessoryDataView.AllowNew = True
            dgAccessory.DataSource = mobjAccessoryDataView
            'dgAccessory.ReadOnly = False

            mobjACGridTableStyle.RowHeadersVisible = False
            mobjACGridTableStyle.ResetAlternatingBackColor()
            mobjACGridTableStyle.ResetBackColor()
            mobjACGridTableStyle.ResetForeColor()
            mobjACGridTableStyle.ResetGridLineColor()
            mobjACGridTableStyle.BackColor = Color.AliceBlue
            mobjACGridTableStyle.GridLineColor = Color.Black
            mobjACGridTableStyle.HeaderBackColor = Color.FromArgb(205, 225, 250)
            mobjACGridTableStyle.HeaderForeColor = Color.Black
            mobjACGridTableStyle.AlternatingBackColor = Color.AliceBlue
            mobjACGridTableStyle.AllowSorting = False
            mobjACGridTableStyle.PreferredRowHeight = 34 '9.7.2010 by dinesh wagh
            mobjACGridTableStyle.MappingName = "IQAccessory"

            objTextColumn = New DataGridTextBoxColumn
            objTextColumn.MappingName = "SrNo"
            objTextColumn.HeaderText = "Sr.No."
            objTextColumn.Width = 40
            objTextColumn.ReadOnly = True
            objTextColumn.NullText = ""
            objTextColumn.Alignment = HorizontalAlignment.Center
            mobjACGridTableStyle.GridColumnStyles.Add(objTextColumn)

            objTextColumn = New DataGridTextBoxColumn
            objTextColumn.MappingName = "Name"
            objTextColumn.HeaderText = "Accessories"
            objTextColumn.Width = 160
            objTextColumn.TextBox.WordWrap = True '24.6.2010 by dinesh wagh
            objTextColumn.ReadOnly = False
            objTextColumn.NullText = ""
            'objTextColumn.Alignment = HorizontalAlignment.Center
            mobjACGridTableStyle.GridColumnStyles.Add(objTextColumn)

            objTextColumn = New DataGridTextBoxColumn
            objTextColumn.MappingName = "Manufacturer"
            objTextColumn.HeaderText = "Manufacturer"
            objTextColumn.Width = 150
            objTextColumn.TextBox.WordWrap = True '24.6.2010 by dinesh wagh
            objTextColumn.ReadOnly = False
            objTextColumn.NullText = ""
            'objTextColumn.Alignment = HorizontalAlignment.Center
            mobjACGridTableStyle.GridColumnStyles.Add(objTextColumn)

            objTextColumn = New DataGridTextBoxColumn
            objTextColumn.MappingName = "SerialNo"
            objTextColumn.HeaderText = "Serial No"
            objTextColumn.Width = 80
            objTextColumn.ReadOnly = False
            objTextColumn.NullText = ""
            objTextColumn.Alignment = HorizontalAlignment.Center
            mobjACGridTableStyle.GridColumnStyles.Add(objTextColumn)

            objTextColumn = New DataGridTextBoxColumn
            objTextColumn.MappingName = "Specification"
            'objTextColumn.HeaderText = "Specification" '4.4.2010 by dinesh wagh
            objTextColumn.HeaderText = "Mains Power Supply" '4.4.2010 by dinesh wagh
            objTextColumn.Width = 142
            objTextColumn.ReadOnly = False
            objTextColumn.NullText = ""
            'objTextColumn.Alignment = HorizontalAlignment.Center
            mobjACGridTableStyle.GridColumnStyles.Add(objTextColumn)

            objTextColumn = New DataGridTextBoxColumn
            objTextColumn.MappingName = "IQAccessoryID"
            objTextColumn.HeaderText = "IQAccessoryID"
            objTextColumn.Width = 0
            objTextColumn.ReadOnly = True
            objTextColumn.NullText = ""
            mobjACGridTableStyle.GridColumnStyles.Add(objTextColumn)

            mobjACGridTableStyle.GridLineColor = Color.Black
            dgAccessory.TableStyles.Add(mobjACGridTableStyle)
        Catch ex As Exception
            '---------------------------------------------------------
            'Error logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = "Error in Formating IQ Accessory List Data-Grid."
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

    'Private Function funcSaveIQAccessoryData() As Boolean
    '    '=====================================================================
    '    ' Procedure Name        :   funcSaveIQAccessoryData
    '    ' Description           :   To Save the Entered Records into Database.
    '    ' Purpose               :   To Save the Entered Records into Database.
    '    ' Parameters Passed     :   None.
    '    ' Returns               :   None.
    '    ' Parameters Affected   :   None.
    '    ' Assumptions           :
    '    ' Dependencies          :
    '    ' Author                :   Gitesh
    '    ' Created               :   January, 2003 
    '    ' Revisions             :
    '    '=====================================================================

    '    Dim intRecordCount, intAccessoryID, temp_cnt As Integer
    '    Dim strName, strManufacturer, strSerialNo, strSpecification As String
    '    Dim status As Boolean = True

    '    Try
    '        intRecordCount = mobjACDataTable.Rows.Count

    '        For temp_cnt = 0 To (intRecordCount - 1)
    '            '--- To Check if Completed / Accepted ID is Null.
    '            If IsDBNull(mobjACDataTable.Rows(temp_cnt).ItemArray.GetValue(mobjACDataTable.Columns.Item("IQAccessoryID").Ordinal)) Then
    '                strName = mobjACDataTable.Rows(temp_cnt).ItemArray.GetValue(mobjACDataTable.Columns.Item("Name").Ordinal)
    '                If IsDBNull(mobjACDataTable.Rows(temp_cnt).ItemArray.GetValue(mobjACDataTable.Columns.Item("Manufacturer").Ordinal)) = False Then
    '                    strManufacturer = mobjACDataTable.Rows(temp_cnt).ItemArray.GetValue(mobjACDataTable.Columns.Item("Manufacturer").Ordinal)
    '                End If
    '                If IsDBNull(mobjACDataTable.Rows(temp_cnt).ItemArray.GetValue(mobjACDataTable.Columns.Item("SerialNo").Ordinal)) = False Then
    '                    strSerialNo = mobjACDataTable.Rows(temp_cnt).ItemArray.GetValue(mobjACDataTable.Columns.Item("SerialNo").Ordinal)
    '                End If
    '                If IsDBNull(mobjACDataTable.Rows(temp_cnt).ItemArray.GetValue(mobjACDataTable.Columns.Item("Specification").Ordinal)) = False Then
    '                    strSpecification = mobjACDataTable.Rows(temp_cnt).ItemArray.GetValue(mobjACDataTable.Columns.Item("Specification").Ordinal)
    '                End If
    '                status = funcInsertIQAccessoryData(strName, strManufacturer, strSerialNo, strSpecification)
    '                If Not (status) Then
    '                    Throw New Exception("Error in Saving IQ Accessory List Details.")
    '                End If
    '            Else
    '                intAccessoryID = mobjACDataTable.Rows(temp_cnt).ItemArray.GetValue(mobjACDataTable.Columns.Item("IQAccessoryID").Ordinal)
    '                strName = mobjACDataTable.Rows(temp_cnt).ItemArray.GetValue(mobjACDataTable.Columns.Item("Name").Ordinal)
    '                If IsDBNull(mobjACDataTable.Rows(temp_cnt).ItemArray.GetValue(mobjACDataTable.Columns.Item("Manufacturer").Ordinal)) = False Then
    '                    strManufacturer = mobjACDataTable.Rows(temp_cnt).ItemArray.GetValue(mobjACDataTable.Columns.Item("Manufacturer").Ordinal)
    '                End If
    '                If IsDBNull(mobjACDataTable.Rows(temp_cnt).ItemArray.GetValue(mobjACDataTable.Columns.Item("SerialNo").Ordinal)) = False Then
    '                    strSerialNo = mobjACDataTable.Rows(temp_cnt).ItemArray.GetValue(mobjACDataTable.Columns.Item("SerialNo").Ordinal)
    '                End If
    '                If IsDBNull(mobjACDataTable.Rows(temp_cnt).ItemArray.GetValue(mobjACDataTable.Columns.Item("Specification").Ordinal)) = False Then
    '                    strSpecification = mobjACDataTable.Rows(temp_cnt).ItemArray.GetValue(mobjACDataTable.Columns.Item("Specification").Ordinal)
    '                Else
    '                    strSpecification = ""
    '                End If
    '                status = funcUpdateIQAccessoryData(strName, strManufacturer, strSerialNo, strSpecification, intAccessoryID)
    '                If Not (status) Then
    '                    Throw New Exception("Error in Updating IQ Accessory List Details.")
    '                End If
    '            End If
    '        Next
    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        'Error logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = "Error in Saving IQ Accessory List Details."
    '        gobjErrorHandler.WriteErrorLog(ex)
    '        '---------------------------------------------------------
    '    Finally
    '        '---------------------------------------------------------
    '        '--- Writing Execution log
    '        If CONST_CREATE_EXECUTION_LOG = 1 Then
    '            gobjErrorHandler.WriteExecutionLog()
    '        End If
    '        '---------------------------------------------------------
    '    End Try
    '    Return status

    'End Function

    Public Function funcSaveIQAccessoryData() As Boolean
        '=====================================================================
        ' Procedure Name        :   funcSaveIQAccessoryData
        ' Description           :   To Save the Entered Records into Database.
        ' Purpose               :   To Save the Entered Records into Database.
        ' Parameters Passed     :   None.
        ' Returns               :   None.
        ' Parameters Affected   :   None.
        ' Assumptions           :
        ' Dependencies          :
        ' Author                :   M.Kamal
        ' Created               :   20-May-2004
        ' Revisions             :
        '=====================================================================

        Dim intRecordCount, intAccessoryID, temp_cnt As Integer
        Dim strName, strManufacturer, strSerialNo, strSpecification As String
        Dim status As Boolean = True

        Try
            intRecordCount = mobjACDataTable.Rows.Count

            For temp_cnt = 0 To (intRecordCount - 1)
                '--- To Check if Completed / Accepted ID is Null.
                If IsDBNull(mobjACDataTable.Rows(temp_cnt).ItemArray.GetValue(mobjACDataTable.Columns.Item("IQAccessoryID").Ordinal)) Then
                    strName = mobjACDataTable.Rows(temp_cnt).ItemArray.GetValue(mobjACDataTable.Columns.Item("Name").Ordinal)
                    strName = strName.Replace(vbCrLf, " ") '25.6.2010 by dinesh wagh
                    strManufacturer = mobjACDataTable.Rows(temp_cnt).ItemArray.GetValue(mobjACDataTable.Columns.Item("Manufacturer").Ordinal)
                    strManufacturer = strManufacturer.Replace(vbCrLf, " ") '25.6.2010 by dinesh wagh
                    strSerialNo = mobjACDataTable.Rows(temp_cnt).ItemArray.GetValue(mobjACDataTable.Columns.Item("SerialNo").Ordinal)
                    strSpecification = mobjACDataTable.Rows(temp_cnt).ItemArray.GetValue(mobjACDataTable.Columns.Item("Specification").Ordinal)
                    status = gobjDataAccess.funcInsertIQAccessoryData(strName, strManufacturer, strSerialNo, strSpecification)
                    If Not (status) Then
                        Throw New Exception("Error in Saving IQ Accessory List Details.")
                    End If
                Else
                    If IsDBNull(mobjACDataTable.Rows(temp_cnt).ItemArray.GetValue(mobjACDataTable.Columns.Item("Name").Ordinal)) Or IsDBNull(mobjACDataTable.Rows(temp_cnt).ItemArray.GetValue(mobjACDataTable.Columns.Item("Manufacturer").Ordinal)) Or IsDBNull(mobjACDataTable.Rows(temp_cnt).ItemArray.GetValue(mobjACDataTable.Columns.Item("SerialNo").Ordinal)) Or IsDBNull(mobjACDataTable.Rows(temp_cnt).ItemArray.GetValue(mobjACDataTable.Columns.Item("Specification").Ordinal)) Then
                        intAccessoryID = mobjACDataTable.Rows(temp_cnt).ItemArray.GetValue(mobjACDataTable.Columns.Item("IQAccessoryID").Ordinal)
                        status = gobjDataAccess.funcDeleteIQAccessoryData(intAccessoryID)
                        If Not (status) Then
                            Throw New Exception("Error in Deleting Manual List Details.")
                        End If
                    Else
                        intAccessoryID = mobjACDataTable.Rows(temp_cnt).ItemArray.GetValue(mobjACDataTable.Columns.Item("IQAccessoryID").Ordinal)
                        strName = mobjACDataTable.Rows(temp_cnt).ItemArray.GetValue(mobjACDataTable.Columns.Item("Name").Ordinal)
                        strName = strName.Replace(vbCrLf, " ") '25.6.2010 by dinesh wagh
                        strManufacturer = mobjACDataTable.Rows(temp_cnt).ItemArray.GetValue(mobjACDataTable.Columns.Item("Manufacturer").Ordinal)
                        strManufacturer = strManufacturer.Replace(vbCrLf, " ") '25.6.2010 by dinesh wagh
                        strSerialNo = mobjACDataTable.Rows(temp_cnt).ItemArray.GetValue(mobjACDataTable.Columns.Item("SerialNo").Ordinal)
                        strSpecification = mobjACDataTable.Rows(temp_cnt).ItemArray.GetValue(mobjACDataTable.Columns.Item("Specification").Ordinal)
                        status = gobjDataAccess.funcUpdateIQAccessoryData(strName, strManufacturer, strSerialNo, strSpecification, intAccessoryID)
                        If Not (status) Then
                            Throw New Exception("Error in Updating IQ Accessory List Details.")
                        End If
                    End If
                End If
            Next
        Catch ex As Exception
            '---------------------------------------------------------
            'Error logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = "Error in Saving IQ Accessory List Details."
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

    'Private Function funcInsertIQAccessoryData(ByVal strName As String, ByVal strManufacturer As String, ByVal strSerialNo As String, ByVal strSpecification As String) As Boolean
    '    '=====================================================================
    '    ' Procedure Name        :   funcInsertIQAccessoryData
    '    ' Description           :   To Add/Insert New Accessory Data in Database.
    '    ' Purpose               :   To Add/Insert New Accessory Data in Database.
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
    '    Dim intAccessoryID As Integer

    '    Try
    '        'Status = mclsDBFunctions.OpenConnection(mobjOleDBconnection)
    '        If Not (Status) Then
    '            Throw New Exception("Error in Opening Connection during Saving IQ Accessory List Details.")
    '        End If

    '        '--- Generating Next ID. 
    '        'intAccessoryID = mclsDBFunctions.GetNextID("IQAccessory", "IQAccessoryID", mobjOleDBconnection)

    '        '---  Query for adding  data 
    '        str_sql = " Insert into IQAccessory " & _
    '                  " (Name ,Manufacturer ,SerialNo ,Specification ,IQAccessoryID) " & _
    '                  " values('" & strName & "','" & strManufacturer & "','" & strSerialNo & "','" & strSpecification & "'," & intAccessoryID & ") "
    '        '" values(?,?,?,?,?) "

    '        '--- Providing command object. 
    '        With objCommand
    '            .Connection = mobjOleDBconnection
    '            .CommandType = CommandType.Text
    '            .CommandText = str_sql
    '            '.Parameters.Add("IQAccessoryID", OleDbType.Numeric).Value = intAccessoryID
    '            '.Parameters.Add("Name", OleDbType.VarChar, 50).Value = strName
    '            '.Parameters.Add("Manufacturer", OleDbType.VarChar, 50).Value = strManufacturer
    '            '.Parameters.Add("SerialNo", OleDbType.VarChar, 50).Value = strSerialNo
    '            '.Parameters.Add("Specification", OleDbType.VarChar, 50).Value = strSpecification
    '            .ExecuteNonQuery()
    '        End With

    '        objCommand.Dispose()
    '        Status = True

    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        '--- Error logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = "Error in Saving IQ Accessory List Details."
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

    'Private Function funcUpdateIQAccessoryData(ByVal strName As String, ByVal strManufacturer As String, ByVal strSerialNo As String, ByVal strSpecification As String, ByVal intAccessoryID As Integer) As Boolean
    '    '=====================================================================
    '    ' Procedure Name        :   funcUpdateIQAccessoryData
    '    ' Description           :   To Update Accessory Data in Database.
    '    ' Purpose               :   To Update Accessory Data in Database.
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
    '            Throw New Exception("Error in Opening Connection during Updating IQ Accessory List Details.")
    '        End If

    '        '---  Query for adding  data 
    '        str_sql = " Update IQAccessory " & _
    '                  " Set Name = ? ,Manufacturer = ? ,SerialNo = ? ,Specification = ? " & _
    '                  " where IQAccessoryID = " & intAccessoryID & " "

    '        '--- Providing command object  
    '        With objCommand
    '            .Connection = mobjOleDBconnection
    '            .CommandType = CommandType.Text
    '            .CommandText = str_sql
    '            .Parameters.Add("Name", OleDbType.VarChar, 250).Value = strName
    '            .Parameters.Add("Manufacturer", OleDbType.VarChar, 250).Value = strManufacturer
    '            .Parameters.Add("SerialNo", OleDbType.VarChar, 250).Value = strSerialNo
    '            .Parameters.Add("Specification", OleDbType.VarChar, 250).Value = strSpecification
    '            .ExecuteNonQuery()
    '        End With

    '        objCommand.Dispose()
    '        Status = True

    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        '--- Error logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = "Error in Updating IQ Accessory List Details."
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

    'Private Function funcDeleteIQAccessoryData(ByVal intAccessoryID As Integer) As Boolean
    '    '=====================================================================
    '    ' Procedure Name        :   funcDeleteIQAccessoryData
    '    ' Description           :   To Delete Accessory Data from Database.
    '    ' Purpose               :   To Delete Accessory Data from Database.
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
    '            Throw New Exception("Error in Opening Connection during Deleting IQ Accessory List Details.")
    '        End If

    '        '--- Query to Delete from Database
    '        str_sql = " Delete * from IQAccessory " & _
    '                  " where IQAccessoryID = " & intAccessoryID & " "

    '        'Status = mclsDBFunctions.AddORDeleteRecord(str_sql, mobjOleDBconnection)
    '        If (Status = False) Then
    '            Throw New Exception("Error in Deleting IQ Accessory List Details.")
    '        End If

    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        '--- Error logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = "Error in Deleting IQ Accessory List Details."
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

    Private Sub dgSpecification_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgSpecification.CurrentCellChanged
        Dim objDV As DataView
        Dim intWidth As Integer

        'try catch added by : dinesh wagh on 3.2.2010
        Try
            mObjDataTable.Columns(0).ReadOnly = False
            If mObjDataTable.Rows.Count = 0 Then
                mObjDataTable.Columns(0).DefaultValue = 1
            Else
                dgSpecification.Item(dgSpecification.CurrentRowIndex, 0) = dgSpecification.CurrentRowIndex + 1
            End If

            'Else
            'dgSpecification.Item(0, 0) = 1
            'End If
            mObjDataTable.Columns(0).ReadOnly = True
            If dgSpecification.CurrentRowIndex >= 6 Then
                mobjSpecificationDataView.AllowNew = False
            End If

            '-------16.6.2010  by dinesh wagh 
            If mObjDataTable.Rows.Count = 0 And dgSpecification.CurrentRowIndex <> -1 Then
                dgSpecification.Item(0, 0) = 1
            End If
            '-------------
            '30.6.2010 by dinesh wagh
            '------------------------------------------
            objDV = dgSpecification.DataSource

            Select Case mintColumnIndexInst
                Case EnumColumnsInstrument.EquipmentName
                    intWidth = CONST_InstrumentTable_EquipmentName_Size
                Case EnumColumnsInstrument.Manufacture
                    intWidth = CONST_InstrumentTable_Manufacture_Size
            End Select

            If objDV.Count > 0 And objDV.Count > mintRowIndexInst Then
                If mintColumnIndexInst = EnumColumnsInstrument.EquipmentName Or _
                   mintColumnIndexInst = EnumColumnsInstrument.Manufacture Then
                    If Not IsDBNull(objDV(mintRowIndexInst).Row(mintColumnIndexInst)) Then
                        objDV(mintRowIndexInst).Row(mintColumnIndexInst) = gfuncWordWrap(objDV(mintRowIndexInst).Row(mintColumnIndexInst), intWidth)
                        dgSpecification.DataSource = objDV
                    End If
                End If
            End If
            mintRowIndexInst = dgSpecification.CurrentCell.RowNumber
            mintColumnIndexInst = dgSpecification.CurrentCell.ColumnNumber
            '-----------------------------------------------------------------
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

    Private Sub dgAccessory_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgAccessory.CurrentCellChanged
        'try catch added by  : dinesh wagh on 3.2.2010
        Dim objDV As DataView
        Dim intWidth As Integer

        Try
            mobjACDataTable.Columns(0).ReadOnly = False
            'If mObjDataTable.Rows.Count = 0 Then
            If mobjACDataTable.Rows.Count = 0 Then 'by pankaj on 7.12.07
                'mObjDataTable.Columns(0).DefaultValue = 1
                mobjACDataTable.Columns(0).DefaultValue = 1 'by pankaj on 7.12.07
            Else
                dgAccessory.Item(dgAccessory.CurrentRowIndex, 0) = dgAccessory.CurrentRowIndex + 1
            End If

            mobjACDataTable.Columns(0).ReadOnly = True
            If dgAccessory.CurrentRowIndex >= 6 Then
                mobjAccessoryDataView.AllowNew = False
            End If

            '-------16.6.2010  by dinesh wagh 
            If mobjACDataTable.Rows.Count = 0 And dgAccessory.CurrentRowIndex <> -1 Then
                dgAccessory.Item(0, 0) = 1
            End If
            '------------

            '30.6.2010 by dinesh wagh
            '--------------------------------
            objDV = dgAccessory.DataSource
            Select Case mintColumnIndexAccessory
                Case EnumColumnsAccessory.Accessories
                    intWidth = CONST_AccessoryTable_Accessories_Size
                Case EnumColumnsAccessory.Manufacturer
                    intWidth = CONST_AccessoryTable_Manufacturer_Size
            End Select
            If objDV.Count > 0 And objDV.Count > mintRowIndexAccessory Then
                If mintColumnIndexAccessory = EnumColumnsAccessory.Accessories Or _
                   mintColumnIndexAccessory = EnumColumnsAccessory.Manufacturer Then
                    If Not IsDBNull(objDV(mintRowIndexAccessory).Row(mintColumnIndexAccessory)) Then
                        objDV(mintRowIndexAccessory).Row(mintColumnIndexAccessory) = gfuncWordWrap(objDV(mintRowIndexAccessory).Row(mintColumnIndexAccessory), intWidth)
                        dgAccessory.DataSource = objDV
                    End If
                End If
            End If
            mintRowIndexAccessory = dgAccessory.CurrentCell.RowNumber
            mintColumnIndexAccessory = dgAccessory.CurrentCell.ColumnNumber
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
End Class
