Option Explicit On 
Imports System
Imports System.IO
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Text
'Imports ColorAnalysis.Common

Public Class DataGridClass
    Implements IDisposable
    '****************************************************************************
    ' File Name 		:   DataGridClass
    ' Author			:   M.Kamal      
    ' Date/Time			:   03-Sept-2004
    ' Description		:   Class is used for setting the column and Grid Style
    '****************************************************************************

#Region " Public Enums, Structures, ... "

    Public Enum ColumnDataType
        Text = 1
        Color = 2
    End Enum

    Public Enum enumColumnType
        TextBoxColumn = 1
        BoolColumn = 2
    End Enum

    Public Enum enumControl
        None = 0
        TextBox = 1
        CheckBox = 2
        ComboBox = 3
        RadioButton = 4
        DatePicker = 5
        DataGrid = 6
        ProgressBar = 7
        Label = 8
    End Enum

#End Region

#Region " Class Variables "

    Private Handle As IntPtr
    ' Other managed resource this class uses.
    Private component As New component
    ' Track whether Dispose has been called.
    Private disposed As Boolean = False
    Private mblnAllowNew As Boolean
    Private mobjDataView As New DataView
    Private mblnAdjustRowWidth As Boolean
    Private mobjTextColumn As DataGridTextBoxColumn
    Private mobjClsDataGridTextBoxColumn As clsDataGridTextBoxColumn
    Private mobjBoolColumn As DataGridBoolColumn

    'Private Shared mintColumnIndicesToBeValidated() As Integer
    Private Shared mobjValidationData() As structValidationData

    Private Structure structValidationData
        Public intColumnIndex As Integer
        Public intColumnDataType As enumValidationType
    End Structure

    Public Enum enumValidationType
        Number
        Text
    End Enum

    Public SetDataGridTableStyle As DataGridTableStyle

#End Region

#Region " Constructors "

    Public Sub New(ByVal FileName As String)
        '=====================================================================
        ' Procedure Name        : new Constructor
        ' Parameters Passed     : FileName 
        ' Returns               : 
        ' Purpose               : To read the default properties from the File
        ' Description           : To read the default properties from the File
        '                          To Assign Default properties to the the Grid
        ' Assumptions           : 1. If file is not present it will Set default 
        '                           properties set at design time
        ' Dependencies          : 
        ' Author                : M.Kamal
        ' Created               : 18-Sept-2004 08:23 PM
        ' Revisions             : 
        '=====================================================================
        '-----1. Assign AllowNew to true as default Value
        '-----2. Assign AdjustColumnWidth to False as default Value
        '-----3. Read The Properties from the file and assign it to SetDataGridTableStyle

        Try
            '-----1. Assign AllowNew to False as default Value
            mblnAllowNew = False

            '-----2. Assign AdjustColumnWidth to False as default Value
            mblnAdjustRowWidth = False

            '-----3. Read The Properties from the file and assign it to SetDataGridTableStyle
            Call Me.ReadDataGridProperties(FileName)

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------           
        End Try
    End Sub

#End Region

#Region " Dispose and Garbage Collector Code "

    Public Overloads Sub Dispose() Implements IDisposable.Dispose
        Dispose(True)
        ' This object will be cleaned up by the Dispose method.
        ' Therefore, you should call GC.SupressFinalize to
        ' take this object off the finalization queue 
        ' and prevent finalization code for this object
        ' from executing a second time.

        ' GC.SuppressFinalize(Me)

    End Sub

    ' Dispose(bool disposing) executes in two distinct scenarios.
    ' If disposing equals true, the method has been called directly
    ' or indirectly by a user's code. Managed and unmanaged resources
    ' can be disposed.
    ' If disposing equals false, the method has been called by the 
    ' runtime from inside the finalizer and you should not reference 
    ' other objects. Only unmanaged resources can be disposed.
    Private Overloads Sub Dispose(ByVal disposing As Boolean)
        ' Check to see if Dispose has already been called.
        If Not Me.disposed Then
            ' If disposing equals true, dispose all managed 
            ' and unmanaged resources.
            If disposing Then
                ' Dispose managed resources.
                component.Dispose()

            End If

            ' Call the appropriate methods to clean up 
            ' unmanaged resources here.
            ' If disposing is false, 
            ' only the following code is executed.
            CloseHandle(Handle)
            Handle = IntPtr.Zero
        End If
        disposed = True
    End Sub
    <System.Runtime.InteropServices.DllImport("Kernel32")> _
         Private Shared Function CloseHandle(ByVal handle As IntPtr) As [Boolean]
    End Function

    ' This finalizer will run only if the Dispose method 
    ' does not get called.
    ' It gives your base class the opportunity to finalize.
    ' Do not provide finalize methods in types derived from this class.
    Protected Overrides Sub Finalize()
        ' Do not re-create Dispose clean-up code here.
        ' Calling Dispose(false) is optimal in terms of
        ' readability and maintainability.
        Dispose(False)
        MyBase.Finalize()
    End Sub

#End Region

#Region " Private Functions "

    Private Sub ReadDataGridProperties(ByVal FileName As String)
        '=====================================================================
        ' Procedure Name        : ReadDataGridProperties
        ' Parameters Passed     : FileName
        ' Returns               : 
        ' Purpose               : Reads the Default properties from the File
        ' Description           :
        '---- 1. Check for the existance of the file and then open it
        '---- 2. Read the file line by line and assign it to TableStyle
        ' Assumptions           :
        ' Dependencies          : 
        ' Author                : M.Kamal
        ' Created               : 18-Sept-2004 08:23 PM
        ' Revisions             : 
        '=====================================================================
        '---- 1. Check for the existance of the file and then open it
        '---- 2. Read the file line by line and assign it to TableStyle
        Try
            Dim strFileString As String
            Dim strProperty As String()
            Dim strRGBValues As String()

            SetDataGridTableStyle = New DataGridTableStyle

            '---- 1. Check for the existance of the file and then open it
            If File.Exists(Application.StartupPath & "\" & FileName) = True Then
                FileOpen(1, Application.StartupPath & "\" & FileName, OpenMode.Input)
                While Not EOF(1)

                    '---- 2. Read the file line by line and assign it to TableStyle
                    strFileString = LineInput(1)
                    strProperty = strFileString.Split("=")
                    Select Case strProperty(0).Trim
                        Case "AllowSorting"
                            SetDataGridTableStyle.AllowSorting = CBool(strProperty(1).Trim)
                        Case "AlternatingBackColor"
                            Try
                                SetDataGridTableStyle.AlternatingBackColor = Color.FromName(strProperty(1).Trim)
                            Catch ex As ArgumentException
                                strRGBValues = strProperty(1).Split(",")
                                SetDataGridTableStyle.AlternatingBackColor = Color.FromArgb(CInt(strRGBValues(0).Trim), CInt(strRGBValues(1).Trim), CInt(strRGBValues(2).Trim))
                            End Try
                        Case "BackColor"
                            'SetDataGridTableStyle.BackColor = Color.FromName(strProperty(1).Trim)
                            Try
                                SetDataGridTableStyle.BackColor = Color.FromName(strProperty(1).Trim)
                            Catch ex As ArgumentException
                                strRGBValues = strProperty(1).Split(",")
                                SetDataGridTableStyle.BackColor = Color.FromArgb(CInt(strRGBValues(0).Trim), CInt(strRGBValues(1).Trim), CInt(strRGBValues(2).Trim))
                            End Try
                        Case "HeaderBackColor"
                            'SetDataGridTableStyle.HeaderBackColor = Color.FromName(strProperty(1).Trim)
                            Try
                                SetDataGridTableStyle.HeaderBackColor = Color.FromName(strProperty(1).Trim)
                            Catch ex As ArgumentException
                                strRGBValues = strProperty(1).Split(",")
                                SetDataGridTableStyle.HeaderBackColor = Color.FromArgb(CInt(strRGBValues(0).Trim), CInt(strRGBValues(1).Trim), CInt(strRGBValues(2).Trim))
                            End Try
                        Case "HeaderForeColor"
                            'SetDataGridTableStyle.HeaderForeColor = Color.FromName(strProperty(1).Trim)
                            Try
                                SetDataGridTableStyle.HeaderForeColor = Color.FromName(strProperty(1).Trim)
                            Catch ex As ArgumentException
                                strRGBValues = strProperty(1).Split(",")
                                SetDataGridTableStyle.HeaderForeColor = Color.FromArgb(CInt(strRGBValues(0).Trim), CInt(strRGBValues(1).Trim), CInt(strRGBValues(2).Trim))
                            End Try
                        Case "ReadOnly"
                            SetDataGridTableStyle.ReadOnly = CBool(strProperty(1).Trim)
                        Case "RowHeadersVisible"
                            SetDataGridTableStyle.RowHeadersVisible = CBool(strProperty(1).Trim)
                        Case "SelectionBackColor"
                            'SetDataGridTableStyle.SelectionBackColor = Color.FromName(strProperty(1).Trim)
                            Try
                                SetDataGridTableStyle.SelectionBackColor = Color.FromName(strProperty(1).Trim)
                            Catch ex As ArgumentException
                                strRGBValues = strProperty(1).Split(",")
                                SetDataGridTableStyle.SelectionBackColor = Color.FromArgb(CInt(strRGBValues(0).Trim), CInt(strRGBValues(1).Trim), CInt(strRGBValues(2).Trim))
                            End Try
                        Case "SelectionForeColor"
                            'SetDataGridTableStyle.SelectionForeColor = Color.FromName(strProperty(1).Trim)
                            Try
                                SetDataGridTableStyle.SelectionForeColor = Color.FromName(strProperty(1).Trim)
                            Catch ex As ArgumentException
                                strRGBValues = strProperty(1).Split(",")
                                SetDataGridTableStyle.SelectionForeColor = Color.FromArgb(CInt(strRGBValues(0).Trim), CInt(strRGBValues(1).Trim), CInt(strRGBValues(2).Trim))
                            End Try
                        Case "GridLineColor"
                            'SetDataGridTableStyle.GridLineColor = Color.FromName(strProperty(1).Trim)
                            Try
                                SetDataGridTableStyle.GridLineColor = Color.FromName(strProperty(1).Trim)
                            Catch ex As ArgumentException
                                strRGBValues = strProperty(1).Split(",")
                                SetDataGridTableStyle.GridLineColor = Color.FromArgb(CInt(strRGBValues(0).Trim), CInt(strRGBValues(1).Trim), CInt(strRGBValues(2).Trim))
                            End Try
                        Case "ForeColor"
                            'SetDataGridTableStyle.ForeColor = Color.FromName(strProperty(1).Trim)
                            Try
                                SetDataGridTableStyle.ForeColor = Color.FromName(strProperty(1).Trim)
                            Catch ex As ArgumentException
                                strRGBValues = strProperty(1).Split(",")
                                SetDataGridTableStyle.ForeColor = Color.FromArgb(CInt(strRGBValues(0).Trim), CInt(strRGBValues(1).Trim), CInt(strRGBValues(2).Trim))
                            End Try
                        Case "ColumnHeadersVisible"
                            SetDataGridTableStyle.ColumnHeadersVisible = CBool(strProperty(1).Trim)
                    End Select
                End While
                FileClose(1)
            End If

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
            FileClose(1)
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------           
        End Try
    End Sub

#End Region

#Region " Public Properties "

    Public Property AdjustColumnWidthToGrid() As Boolean
        '=====================================================================
        ' Procedure Name        : AdjustColumnWidthToGrid
        ' Parameters Passed     : 
        ' Returns               : 
        ' Purpose               : To set the Width 
        ' Description           : To set the width of each column 
        '                         According to the Width of the Grid
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : M.Kamal
        ' Created               : 18-Sept-2004 08:23 PM
        ' Revisions             : 
        '=====================================================================
        Get
            Return mblnAdjustRowWidth
        End Get
        Set(ByVal Value As Boolean)
            mblnAdjustRowWidth = Value
        End Set
    End Property

    Public Property AllowNew() As Boolean
        '=====================================================================
        ' Procedure Name        : AllowNew
        ' Parameters Passed     : 
        ' Returns               : 
        ' Purpose               : To allow the creation of new Row  
        ' Description           : To allow the creation of new Row
        '                         
        ' Assumptions           : By default it is False
        ' Dependencies          : 
        ' Author                : M.Kamal
        ' Created               : 18-Sept-2004 08:23 PM
        ' Revisions             : 
        '=====================================================================
        Get
            Return mblnAllowNew
        End Get
        Set(ByVal Value As Boolean)
            mblnAllowNew = Value
        End Set
    End Property

#End Region

#Region " Public  Functions "

    Public Sub SetDataGridProperties(ByRef DataGrid As DataGrid, ByRef DataSource As DataView)
        '=====================================================================
        ' Procedure Name        : SetDataGridProperties
        ' Parameters Passed     : DataGrid , DataSource 
        ' Returns               : 
        ' Purpose               : Sets the properties to the DataGrid
        ' Description           :
        '1. Assign DataSource and allownew property to the dataGrid
        '2. Assign AdjustColumnWidth property to the Grid
        '3. Assign Table Style to the DataGrid

        ' Assumptions           :This function should be called after allthe properties are set 
        ' Dependencies          : 
        ' Author                : M.Kamal
        ' Created               : 18-Sept-2004 08:23 PM
        ' Revisions             : 
        '=====================================================================


        '---1. Assign DataSource and allownew property to the dataGrid
        '---2. Assign AdjustColumnWidth property to the Grid
        '---3. Assign Table Style to the DataGrid

        Try
            '---1. Assign DataSource and allownew property to the dataGrid
            If DataSource.Table.TableName = "" Then
                DataSource.Table.TableName = "Table"
            End If

            DataGrid.TableStyles.Clear()
            ' DataSource.AllowNew = mblnAllowNew

            DataGrid.DataSource = DataSource 'mobjDataView
            SetDataGridTableStyle.MappingName = DataSource.Table.TableName
            '---2. Assign AdjustColumnWidth property to the Grid
            If mblnAdjustRowWidth = True Then
                If SetDataGridTableStyle.RowHeadersVisible = True Then
                    If DataGrid.VisibleRowCount >= DataSource.Table.Rows.Count Then
                        SetDataGridTableStyle.PreferredColumnWidth = ((DataGrid.Width - DataGrid.RowHeaderWidth) / DataSource.Table.Columns.Count) - 2
                    Else
                        SetDataGridTableStyle.PreferredColumnWidth = ((DataGrid.Width - DataGrid.RowHeaderWidth) / DataSource.Table.Columns.Count) - 11
                    End If
                Else
                    If DataSource.Table.Rows.Count > 0 Then
                        If DataGrid.VisibleRowCount >= DataSource.Table.Rows.Count Then
                            SetDataGridTableStyle.PreferredColumnWidth = (DataGrid.Width / DataSource.Table.Columns.Count) - 1
                        Else
                            SetDataGridTableStyle.PreferredColumnWidth = (DataGrid.Width / DataSource.Table.Columns.Count) - 10
                        End If
                    End If
                    End If
            End If

            '---3. Assign Table Style to the DataGrid
            DataGrid.TableStyles.Add(SetDataGridTableStyle)

            '=====================================================================
            ' Added BY Mangesh Shardul on 02-May-2005
            '=====================================================================
            '---4. Numerically Validate DataGrid
            Dim intColumnCounter As Integer = 0
            Dim objValidationData() As structValidationData
            Dim intIndexCounter As Integer

            ReDim objValidationData(SetDataGridTableStyle.GridColumnStyles.Count)
            intIndexCounter = 0

            For intColumnCounter = 0 To SetDataGridTableStyle.GridColumnStyles.Count - 1
                If Not SetDataGridTableStyle.GridColumnStyles(intColumnCounter).ReadOnly = True Then

                    Dim strColumnName As String = SetDataGridTableStyle.GridColumnStyles(intColumnCounter).MappingName

                    Select Case Type.GetTypeCode(DataSource.Table.Columns(strColumnName).DataType)
                        Case TypeCode.Decimal, TypeCode.Double, _
                             TypeCode.Int32, TypeCode.Int64, TypeCode.Single

                            objValidationData(intIndexCounter).intColumnIndex = intColumnCounter
                            objValidationData(intIndexCounter).intColumnDataType = enumValidationType.Number
                            intIndexCounter += 1

                        Case TypeCode.String, TypeCode.Char
                            objValidationData(intIndexCounter).intColumnIndex = intColumnCounter
                            objValidationData(intIndexCounter).intColumnDataType = enumValidationType.Text
                            intIndexCounter += 1

                    End Select

                End If
            Next intColumnCounter

            If objValidationData.Length > 0 Then
                ReDim Preserve objValidationData(intIndexCounter - 1)
                Call Me.NumericValidateGrid(DataGrid, objValidationData)
            End If
            '=====================================================================

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------           
        End Try
    End Sub

    Public Sub SetDataGridProperties(ByRef DataGrid As DataGrid, ByRef DataSource As DataTable) ', ByRef DataGridStyle As DataGridTableStyle)
        '=====================================================================
        ' Procedure Name        : SetDataGridProperties
        ' Parameters Passed     : DataGrid , DataSource 
        ' Returns               : 
        ' Purpose               : Sets the properties to the DataGrid
        ' Description           : 1. Assign DataSource and allownew property to the dataGrid
        '                         2. Assign AdjustColumnWidth property to the Grid
        '                         3. Assign Table Style to the DataGrid
        '                         4. Numerically Validate DataGrid
        ' Assumptions           : This function should be called after 
        '                           all the properties are set 
        ' Dependencies          : 
        ' Author                : M.Kamal
        ' Created               : 18-Sept-2004 08:23 PM
        ' Revisions             : 2
        ' Revision By           : Mangesh S. on 02-May-2005
        ' Revisison For         : Added 4th Step of description
        '=====================================================================
        '---1. Assign DataSource and allownew property to the dataGrid
        '---2. Assign AdjustColumnWidth property to the Grid
        '---3. Assign Table Style to the DataGrid
        '---4. Numerically Validate DataGrid

        Try
            '---1. Assign DataSource and allownew property to the dataGrid
            If DataSource.TableName = "" Then
                DataSource.TableName = "Table"
            End If

            DataGrid.TableStyles.Clear()
            mobjDataView.Table = DataSource
            mobjDataView.AllowNew = mblnAllowNew
            DataGrid.DataSource = mobjDataView
            SetDataGridTableStyle.MappingName = DataSource.TableName

            '---2. Assign AdjustColumnWidth property to the Grid
            If mblnAdjustRowWidth = True Then
                If SetDataGridTableStyle.RowHeadersVisible = True Then
                    If DataGrid.VisibleRowCount >= DataSource.Rows.Count Then
                        SetDataGridTableStyle.PreferredColumnWidth = ((DataGrid.Width - DataGrid.RowHeaderWidth) / DataSource.Columns.Count) - 2
                    Else
                        SetDataGridTableStyle.PreferredColumnWidth = ((DataGrid.Width - DataGrid.RowHeaderWidth) / DataSource.Columns.Count) - 11
                    End If
                Else
                    If DataGrid.VisibleRowCount >= DataSource.Rows.Count Then
                        SetDataGridTableStyle.PreferredColumnWidth = (DataGrid.Width / DataSource.Columns.Count) - 1
                    Else
                        SetDataGridTableStyle.PreferredColumnWidth = (DataGrid.Width / DataSource.Columns.Count) - 10
                    End If
                End If
            End If

            '---3. Assign Table Style to the DataGrid
            DataGrid.TableStyles.Add(SetDataGridTableStyle)

            '=====================================================================
            ' Added BY Mangesh Shardul on 02-May-2005
            '=====================================================================
            '---4. Numerically Validate DataGrid
            Dim intColumnCounter As Integer = 0
            'Dim arrColumnIndices As New ArrayList
            'Dim intColumnIndices() As Integer

            Dim objValidationData() As structValidationData
            Dim intIndexCounter As Integer

            ReDim objValidationData(SetDataGridTableStyle.GridColumnStyles.Count)
            intIndexCounter = 0

            For intColumnCounter = 0 To SetDataGridTableStyle.GridColumnStyles.Count - 1
                If Not SetDataGridTableStyle.GridColumnStyles(intColumnCounter).ReadOnly = True Then

                    Dim strColumnName As String = SetDataGridTableStyle.GridColumnStyles(intColumnCounter).MappingName

                    Select Case Type.GetTypeCode(DataSource.Columns(strColumnName).DataType)
                        Case TypeCode.Decimal, TypeCode.Double, _
                             TypeCode.Int32, TypeCode.Int64, TypeCode.Single

                            'arrColumnIndices.Add(intColumnCounter)
                            objValidationData(intIndexCounter).intColumnIndex = intColumnCounter
                            objValidationData(intIndexCounter).intColumnDataType = enumValidationType.Number
                            intIndexCounter += 1

                        Case TypeCode.String, TypeCode.Char
                            objValidationData(intIndexCounter).intColumnIndex = intColumnCounter
                            objValidationData(intIndexCounter).intColumnDataType = enumValidationType.Text
                            intIndexCounter += 1

                    End Select

                End If
            Next intColumnCounter

            'If Not arrColumnIndices.Count = 0 Then
            '    ReDim intColumnIndices(arrColumnIndices.Count - 1)
            '    intColumnIndices = arrColumnIndices.ToArray(GetType(Integer))
            '    Call Me.NumericValidateGrid(DataGrid, intColumnIndices)
            'End If
            If objValidationData.Length > 0 Then
                ReDim Preserve objValidationData(intIndexCounter - 1)
                Call Me.NumericValidateGrid(DataGrid, objValidationData)
            End If
            '=====================================================================

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------           
        End Try
    End Sub

    Public Sub AddDataGridColumnStyle(ByVal ColumnName As String, ByRef DataGrid As DataGrid, ByRef DataSource As DataView, ByVal ColumnType As enumColumnType, ByVal Alignment As System.Windows.Forms.HorizontalAlignment, ByVal ColumnHeaderCaption As String, ByVal Width As Integer, ByVal blnReadOnly As Boolean)

        '=====================================================================
        ' Procedure Name        : AddDataGridColumnStyle
        ' Parameters Passed     : ColumnName,DataGrid,DataSource,ColumnType,Alignment,ColumnHeaderCaption,Width,blnReadOnly 
        ' Returns               : 
        ' Purpose               : Sets the properties to the Column Style
        ' Description           :Assign ColumnProperty and add The Column property to the TableStyle
        ' Assumptions           :This function should be called after allthe properties are set 
        ' Dependencies          : 
        ' Author                : M.Kamal
        ' Created               : 18-Sept-2004 08:23 PM
        ' Revisions             : 
        '=====================================================================

        Try
            '---- Assign ColumnProperty and add The Column property to the TableStyle
            Select Case ColumnType
                Case enumColumnType.BoolColumn
                    mobjBoolColumn = New DataGridBoolColumn
                    mobjBoolColumn.Alignment = Alignment
                    mobjBoolColumn.HeaderText = ColumnHeaderCaption
                    mobjBoolColumn.MappingName = ColumnName
                    mobjBoolColumn.NullText = False
                    mobjBoolColumn.ReadOnly = blnReadOnly
                    If mblnAdjustRowWidth = False Then
                        mobjBoolColumn.Width = Width
                    Else
                        If SetDataGridTableStyle.RowHeadersVisible = True Then
                            mobjBoolColumn.Width = ((DataGrid.Width - DataGrid.RowHeaderWidth) / DataSource.Table.Columns.Count) - 2
                        Else
                            mobjBoolColumn.Width = (DataGrid.Width / DataSource.Table.Columns.Count) - 1
                        End If
                    End If
                    SetDataGridTableStyle.GridColumnStyles.Add(mobjBoolColumn)
                Case enumColumnType.TextBoxColumn
                    mobjTextColumn = New DataGridTextBoxColumn
                    mobjTextColumn.Alignment = Alignment
                    mobjTextColumn.HeaderText = ColumnHeaderCaption
                    mobjTextColumn.MappingName = ColumnName
                    mobjTextColumn.NullText = " "
                    mobjTextColumn.ReadOnly = blnReadOnly
                    If mblnAdjustRowWidth = False Then
                        mobjTextColumn.Width = Width
                    Else
                        If SetDataGridTableStyle.RowHeadersVisible = True Then
                            mobjTextColumn.Width = ((DataGrid.Width - DataGrid.RowHeaderWidth) / DataSource.Table.Columns.Count) - 2
                        Else
                            mobjTextColumn.Width = (DataGrid.Width / DataSource.Table.Columns.Count) - 1
                        End If
                    End If
                    SetDataGridTableStyle.GridColumnStyles.Add(mobjTextColumn)
            End Select

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------           
        End Try
    End Sub

    Public Sub AddDataGridColumnStyle(ByVal ColumnName As String, ByRef DataGrid As DataGrid, ByRef DataSource As DataView, ByVal ColumnType As enumColumnType, ByVal Alignment As System.Windows.Forms.HorizontalAlignment, ByVal ColumnHeaderCaption As String, ByVal Width As Integer, ByVal blnReadOnly As Boolean, ByVal ColumnCount As Integer)
        '=====================================================================
        ' Procedure Name        : AddDataGridColumnStyle
        ' Parameters Passed     : ColumnName,DataGrid,DataSource,ColumnType,Alignment,ColumnHeaderCaption,Width,blnReadOnly ,ColumnCount 
        ' Returns               : 
        ' Purpose               : Sets the properties to the Column Style
        ' Description           :Assign ColumnProperty and add The Column property to the TableStyle
        ' Assumptions           :This function should be called after allthe properties are set 
        ' Dependencies          : 
        ' Author                : M.Kamal
        ' Created               : 18-Sept-2004 08:23 PM
        ' Revisions             : 
        '=====================================================================
        Try
            '---- Assign ColumnProperty and add The Column property to the TableStyle
            Select Case ColumnType
                Case enumColumnType.BoolColumn
                    mobjBoolColumn = New DataGridBoolColumn
                    mobjBoolColumn.Alignment = Alignment
                    mobjBoolColumn.HeaderText = ColumnHeaderCaption
                    mobjBoolColumn.MappingName = ColumnName
                    mobjBoolColumn.NullText = False
                    mobjBoolColumn.ReadOnly = blnReadOnly
                    If mblnAdjustRowWidth = False Then
                        mobjBoolColumn.Width = Width
                    Else
                        If SetDataGridTableStyle.RowHeadersVisible = True Then
                            mobjBoolColumn.Width = ((DataGrid.Width - DataGrid.RowHeaderWidth) / ColumnCount) - 2
                        Else
                            mobjBoolColumn.Width = (DataGrid.Width / ColumnCount) - 1
                        End If
                    End If
                    SetDataGridTableStyle.GridColumnStyles.Add(mobjBoolColumn)
                Case enumColumnType.TextBoxColumn
                    mobjTextColumn = New DataGridTextBoxColumn
                    mobjTextColumn.Alignment = Alignment
                    mobjTextColumn.HeaderText = ColumnHeaderCaption
                    mobjTextColumn.MappingName = ColumnName
                    mobjTextColumn.NullText = " "
                    mobjTextColumn.ReadOnly = blnReadOnly
                    If mblnAdjustRowWidth = False Then
                        mobjTextColumn.Width = Width

                    Else
                        If SetDataGridTableStyle.RowHeadersVisible = True Then
                            mobjTextColumn.Width = ((DataGrid.Width - DataGrid.RowHeaderWidth) / ColumnCount) - 2
                        Else
                            mobjTextColumn.Width = (DataGrid.Width / ColumnCount) - 1
                        End If
                    End If
                    SetDataGridTableStyle.GridColumnStyles.Add(mobjTextColumn)
            End Select
            'DataGrid.TableStyles.Add(mobjDataGridStyle)

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------           
        End Try
    End Sub

    Public Sub AddDataGridColumnStyle(ByVal ColumnName As String, ByRef DataGrid As DataGrid, ByRef DataSource As DataView, ByVal ColumnType As enumColumnType, ByVal Alignment As System.Windows.Forms.HorizontalAlignment, ByVal ColumnHeaderCaption As String, ByVal blnReadOnly As Boolean)
        '=====================================================================
        ' Procedure Name        : AddDataGridColumnStyle
        ' Parameters Passed     : ColumnName,DataGrid,DataSource,ColumnType,Alignment,ColumnHeaderCaption,Width,blnReadOnly
        ' Returns               : 
        ' Purpose               : Sets the properties to the Column Style
        ' Description           :Assign ColumnProperty and add The Column property to the TableStyle
        ' Assumptions           :This function should be called after allthe properties are set 
        ' Dependencies          : 
        ' Author                : M.Kamal
        ' Created               : 18-Sept-2004 08:23 PM
        ' Revisions             : 
        '=====================================================================

        Try
            '---- Assign ColumnProperty and add The Column property to the TableStyle
            Select Case ColumnType
                Case enumColumnType.BoolColumn
                    mobjBoolColumn = New DataGridBoolColumn
                    mobjBoolColumn.Alignment = Alignment
                    mobjBoolColumn.HeaderText = ColumnHeaderCaption
                    mobjBoolColumn.MappingName = ColumnName
                    mobjBoolColumn.NullText = False
                    mobjBoolColumn.ReadOnly = blnReadOnly
                    If SetDataGridTableStyle.RowHeadersVisible = True Then
                        mobjBoolColumn.Width = ((DataGrid.Width - DataGrid.RowHeaderWidth) / DataSource.Table.Columns.Count) - 2
                    Else
                        mobjBoolColumn.Width = (DataGrid.Width / DataSource.Table.Columns.Count) - 1
                    End If
                    SetDataGridTableStyle.GridColumnStyles.Add(mobjBoolColumn)
                Case enumColumnType.TextBoxColumn
                    mobjTextColumn = New DataGridTextBoxColumn
                    mobjTextColumn.Alignment = Alignment
                    mobjTextColumn.HeaderText = ColumnHeaderCaption
                    mobjTextColumn.MappingName = ColumnName
                    mobjTextColumn.NullText = " "
                    mobjTextColumn.ReadOnly = blnReadOnly

                    If SetDataGridTableStyle.RowHeadersVisible = True Then
                        mobjTextColumn.Width = ((DataGrid.Width - DataGrid.RowHeaderWidth) / DataSource.Table.Columns.Count) - 2
                    Else
                        mobjTextColumn.Width = (DataGrid.Width / DataSource.Table.Columns.Count) - 1
                    End If
                    SetDataGridTableStyle.GridColumnStyles.Add(mobjTextColumn)
            End Select
            '  DataGrid.TableStyles.Add(mobjDataGridStyle)

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------           
        End Try
    End Sub

    Public Sub AddDataGridColumnStyle(ByVal ColumnName As String, ByRef DataGrid As DataGrid, ByRef DataSource As DataTable, ByVal ColumnType As enumColumnType, ByVal Alignment As System.Windows.Forms.HorizontalAlignment, ByVal ColumnHeaderCaption As String, ByVal Width As Integer, ByVal blnReadOnly As Boolean)
        '=====================================================================
        ' Procedure Name        : AddDataGridColumnStyle
        ' Parameters Passed     : ColumnName,DataGrid,DataSource,ColumnType,Alignment,ColumnHeaderCaption,Width,blnReadOnly
        ' Returns               : 
        ' Purpose               : Sets the properties to the Column Style
        ' Description           :Assign ColumnProperty and add The Column property to the TableStyle
        ' Assumptions           :This function should be called after allthe properties are set 
        ' Dependencies          : 
        ' Author                : M.Kamal
        ' Created               : 18-Sept-2004 08:23 PM
        ' Revisions             : 
        '=====================================================================
        Try
            '---- Assign ColumnProperty and add The Column property to the TableStyle
            Select Case ColumnType
                Case enumColumnType.BoolColumn
                    mobjBoolColumn = New DataGridBoolColumn
                    mobjBoolColumn.Alignment = Alignment
                    mobjBoolColumn.HeaderText = ColumnHeaderCaption
                    mobjBoolColumn.MappingName = ColumnName
                    mobjBoolColumn.NullText = False
                    mobjBoolColumn.ReadOnly = blnReadOnly
                    If mblnAdjustRowWidth = False Then
                        mobjBoolColumn.Width = Width
                    Else
                        If SetDataGridTableStyle.RowHeadersVisible = True Then
                            mobjBoolColumn.Width = ((DataGrid.Width - DataGrid.RowHeaderWidth) / DataSource.Columns.Count) - 2
                        Else
                            mobjBoolColumn.Width = (DataGrid.Width / DataSource.Columns.Count) - 1
                        End If
                    End If
                    SetDataGridTableStyle.GridColumnStyles.Add(mobjBoolColumn)
                Case enumColumnType.TextBoxColumn
                    mobjTextColumn = New DataGridTextBoxColumn

                    'If mobjTextColumn.DataGridTableStyle.DataGrid.CurrentRowIndex = -1 Then
                    '    mobjTextColumn.Alignment = HorizontalAlignment.Center
                    'Else
                    '    mobjTextColumn.Alignment = HorizontalAlignment.Right
                    'End If
                    mobjTextColumn.Alignment = Alignment
                    'mobjTextColumn.Alignment = HorizontalAlignment.Center
                    mobjTextColumn.HeaderText = ColumnHeaderCaption
                    mobjTextColumn.MappingName = ColumnName
                    mobjTextColumn.NullText = " "
                    mobjTextColumn.ReadOnly = blnReadOnly
                    If mblnAdjustRowWidth = False Then
                        mobjTextColumn.Width = Width

                    Else
                        If SetDataGridTableStyle.RowHeadersVisible = True Then
                            mobjTextColumn.Width = ((DataGrid.Width - DataGrid.RowHeaderWidth) / DataSource.Columns.Count) - 2
                        Else
                            mobjTextColumn.Width = (DataGrid.Width / DataSource.Columns.Count) - 1
                        End If
                    End If
                    SetDataGridTableStyle.GridColumnStyles.Add(mobjTextColumn)
            End Select
            'DataGrid.TableStyles.Add(mobjDataGridStyle)

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------           
        End Try
    End Sub

    Public Sub AddDataGridColumnStyle(ByVal ColumnName As String, ByRef DataGrid As DataGrid, ByRef DataSource As DataTable, ByVal ColumnType As enumColumnType, ByVal Alignment As System.Windows.Forms.HorizontalAlignment, ByVal ColumnHeaderCaption As String, ByVal Width As Integer, ByVal blnReadOnly As Boolean, ByVal ColDataType As ColumnDataType, ByVal AlignData As HorizontalAlignment)
        '=====================================================================
        ' Procedure Name        : AddDataGridColumnStyle
        ' Parameters Passed     : ColumnName,DataGrid,DataSource,ColumnType,Alignment,ColumnHeaderCaption,Width,blnReadOnly
        ' Returns               : 
        ' Purpose               : Sets the properties to the Column Style and display Header text and data in required alignment
        ' Description           :Assign ColumnProperty and add The Column property to the TableStyle
        ' Assumptions           :This function should be called after allthe properties are set 
        ' Dependencies          : 
        ' Author                : Deepak B.
        ' Created               : 2/4/06
        ' Revisions             : 
        '=====================================================================
        Try
            '---- Assign ColumnProperty and add The Column property to the TableStyle
            Select Case ColumnType
                Case enumColumnType.BoolColumn
                    mobjBoolColumn = New DataGridBoolColumn
                    mobjBoolColumn.Alignment = Alignment
                    mobjBoolColumn.HeaderText = ColumnHeaderCaption
                    mobjBoolColumn.MappingName = ColumnName
                    mobjBoolColumn.NullText = False
                    mobjBoolColumn.ReadOnly = blnReadOnly
                    If mblnAdjustRowWidth = False Then
                        mobjBoolColumn.Width = Width
                    Else
                        If SetDataGridTableStyle.RowHeadersVisible = True Then
                            mobjBoolColumn.Width = ((DataGrid.Width - DataGrid.RowHeaderWidth) / DataSource.Columns.Count) - 2
                        Else
                            mobjBoolColumn.Width = (DataGrid.Width / DataSource.Columns.Count) - 1
                        End If
                    End If
                    SetDataGridTableStyle.GridColumnStyles.Add(mobjBoolColumn)
                Case enumColumnType.TextBoxColumn
                    mobjClsDataGridTextBoxColumn = New clsDataGridTextBoxColumn(ColumnHeaderCaption, ColumnName, Width, DataSource, ColDataType)
                    'mobjTextColumn = New DataGridTextBoxColumn

                    mobjClsDataGridTextBoxColumn.Alignment = Alignment
                    'mobjTextColumn.Alignment = HorizontalAlignment.Center
                    mobjClsDataGridTextBoxColumn.HeaderText = ColumnHeaderCaption
                    mobjClsDataGridTextBoxColumn.MappingName = ColumnName
                    mobjClsDataGridTextBoxColumn.NullText = " "
                    mobjClsDataGridTextBoxColumn.ReadOnly = blnReadOnly
                    mobjClsDataGridTextBoxColumn.DataAlignment = AlignData
                    If mblnAdjustRowWidth = False Then
                        mobjClsDataGridTextBoxColumn.Width = Width

                    Else
                        If SetDataGridTableStyle.RowHeadersVisible = True Then
                            mobjClsDataGridTextBoxColumn.Width = ((DataGrid.Width - DataGrid.RowHeaderWidth) / DataSource.Columns.Count) - 2
                        Else
                            mobjClsDataGridTextBoxColumn.Width = (DataGrid.Width / DataSource.Columns.Count) - 1
                        End If
                    End If
                    SetDataGridTableStyle.GridColumnStyles.Add(mobjClsDataGridTextBoxColumn)
            End Select
            'DataGrid.TableStyles.Add(mobjDataGridStyle)

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------           
        End Try
    End Sub

    Public Sub AddDataGridColumnStyle(ByVal ColumnName As String, ByRef DataGrid As DataGrid, ByRef DataSource As DataTable, ByVal ColumnType As enumColumnType, ByVal Alignment As System.Windows.Forms.HorizontalAlignment, ByVal ColumnHeaderCaption As String, ByVal Width As Integer, ByVal blnReadOnly As Boolean, ByVal ColDataType As ColumnDataType, ByVal AlignData As HorizontalAlignment, ByVal intNumberOfCharacters As Integer, ByVal blnCheckNumberOfCharacters As Boolean, ByVal blnIsNumericValidationRequired As Boolean)
        '=====================================================================
        ' Procedure Name        : AddDataGridColumnStyle
        ' Parameters Passed     : ColumnName,DataGrid,DataSource,ColumnType,Alignment,ColumnHeaderCaption,Width,blnReadOnly
        ' Returns               : 
        ' Purpose               : Sets the properties to the Column Style and display Header text and data in required alignment
        ' Description           :Assign ColumnProperty and add The Column property to the TableStyle
        ' Assumptions           :This function should be called after allthe properties are set 
        ' Dependencies          : 
        ' Author                : Deepak B.
        ' Created               : 16.08.07
        ' Revisions             : 
        '=====================================================================
        Try
            '---- Assign ColumnProperty and add The Column property to the TableStyle
            Select Case ColumnType
                Case enumColumnType.BoolColumn
                    mobjBoolColumn = New DataGridBoolColumn
                    mobjBoolColumn.Alignment = Alignment
                    mobjBoolColumn.HeaderText = ColumnHeaderCaption
                    mobjBoolColumn.MappingName = ColumnName
                    mobjBoolColumn.NullText = False
                    mobjBoolColumn.ReadOnly = blnReadOnly
                    If mblnAdjustRowWidth = False Then
                        mobjBoolColumn.Width = Width
                    Else
                        If SetDataGridTableStyle.RowHeadersVisible = True Then
                            mobjBoolColumn.Width = ((DataGrid.Width - DataGrid.RowHeaderWidth) / DataSource.Columns.Count) - 2
                        Else
                            mobjBoolColumn.Width = (DataGrid.Width / DataSource.Columns.Count) - 1
                        End If
                    End If
                    SetDataGridTableStyle.GridColumnStyles.Add(mobjBoolColumn)
                Case enumColumnType.TextBoxColumn
                    'mobjClsDataGridTextBoxColumn = New clsDataGridTextBoxColumn(ColumnHeaderCaption, ColumnName, Width, DataSource, ColDataType)
                    mobjClsDataGridTextBoxColumn = New clsDataGridTextBoxColumn(intNumberOfCharacters, blnCheckNumberOfCharacters, blnIsNumericValidationRequired, False, False)
                    'mobjTextColumn = New DataGridTextBoxColumn

                    mobjClsDataGridTextBoxColumn.Alignment = Alignment
                    'mobjTextColumn.Alignment = HorizontalAlignment.Center
                    mobjClsDataGridTextBoxColumn.HeaderText = ColumnHeaderCaption
                    mobjClsDataGridTextBoxColumn.MappingName = ColumnName
                    mobjClsDataGridTextBoxColumn.NullText = " "
                    mobjClsDataGridTextBoxColumn.ReadOnly = blnReadOnly
                    mobjClsDataGridTextBoxColumn.DataAlignment = AlignData
                    If mblnAdjustRowWidth = False Then
                        mobjClsDataGridTextBoxColumn.Width = Width

                    Else
                        If SetDataGridTableStyle.RowHeadersVisible = True Then
                            mobjClsDataGridTextBoxColumn.Width = ((DataGrid.Width - DataGrid.RowHeaderWidth) / DataSource.Columns.Count) - 2
                        Else
                            mobjClsDataGridTextBoxColumn.Width = (DataGrid.Width / DataSource.Columns.Count) - 1
                        End If
                    End If
                    SetDataGridTableStyle.GridColumnStyles.Add(mobjClsDataGridTextBoxColumn)
            End Select
            'DataGrid.TableStyles.Add(mobjDataGridStyle)

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------           
        End Try
    End Sub

    'Public Sub AddDataGridColumnStyle(ByVal ColumnName As String, ByRef DataGrid1 As DataGrid, ByRef DataSource As DataTable, ByVal ColumnType As enumColumnType, ByVal Alignment As System.Windows.Forms.HorizontalAlignment, ByVal ColumnHeaderCaption As String, ByVal Width As Integer, ByVal blnReadOnly As Boolean, ByRef control As System.Windows.Forms.Control)

    '    '---- Assign ColumnProperty and add The Column property to the TableStyle
    '    Select Case ColumnType
    '        Case enumColumnType.BoolColumn
    '            mobjBoolColumn = New DataGridBoolColumn
    '            mobjBoolColumn.Alignment = Alignment
    '            mobjBoolColumn.HeaderText = ColumnHeaderCaption
    '            mobjBoolColumn.MappingName = ColumnName
    '            mobjBoolColumn.NullText = False
    '            mobjBoolColumn.ReadOnly = blnReadOnly
    '            If mblnAdjustRowWidth = False Then
    '                mobjBoolColumn.Width = Width
    '            Else
    '                If SetDataGridTableStyle.RowHeadersVisible = True Then
    '                    mobjBoolColumn.Width = ((DataGrid1.Width - DataGrid1.RowHeaderWidth) / DataSource.Columns.Count) - 2
    '                Else
    '                    mobjBoolColumn.Width = (DataGrid1.Width / DataSource.Columns.Count) - 1
    '                End If
    '            End If
    '            SetDataGridTableStyle.GridColumnStyles.Add(mobjBoolColumn)
    '        Case enumColumnType.TextBoxColumn
    '            mobjTextColumn = New DataGridTextBoxColumn
    '            mobjTextColumn.Alignment = Alignment
    '            mobjTextColumn.HeaderText = ColumnHeaderCaption
    '            mobjTextColumn.MappingName = ColumnName
    '            mobjTextColumn.NullText = " "
    '            mobjTextColumn.ReadOnly = blnReadOnly
    '            If mblnAdjustRowWidth = False Then
    '                mobjTextColumn.Width = Width

    '            Else
    '                If SetDataGridTableStyle.RowHeadersVisible = True Then
    '                    mobjTextColumn.Width = ((DataGrid1.Width - DataGrid1.RowHeaderWidth) / DataSource.Columns.Count) - 2
    '                Else
    '                    mobjTextColumn.Width = (DataGrid1.Width / DataSource.Columns.Count) - 1
    '                End If
    '            End If
    '            mobjTextColumn.TextBox.Controls.Add(control)
    '            mobjTextColumn.TextBox.Focus()
    '            'Dim hit As DataGrid.HitTestInfo
    '            'AddHandler DataGrid1.MouseDown, AddressOf func

    '            '   control.Text = DataSource.Rows(row).Item(col)
    '            'DataSource.Rows(0).Item(2) = control.Text
    '            control.Dock = DockStyle.Fill
    '            control.BringToFront()
    '            SetDataGridTableStyle.GridColumnStyles.Add(mobjTextColumn)
    '    End Select
    '    'DataGrid.TableStyles.Add(mobjDataGridStyle)
    'End Sub

    Public Sub AddDataGridColumnStyle(ByVal ColumnName As String, ByRef DataGrid As DataGrid, ByRef DataSource As DataTable, ByVal ColumnType As enumColumnType, ByVal Alignment As System.Windows.Forms.HorizontalAlignment, ByVal ColumnHeaderCaption As String, ByVal blnReadOnly As Boolean)
        '=====================================================================
        ' Procedure Name        : AddDataGridColumnStyle
        ' Parameters Passed     : ColumnName,DataGrid,DataSource,ColumnType,Alignment,ColumnHeaderCaption,blnReadOnly
        ' Returns               : 
        ' Purpose               : Sets the properties to the Column Style
        ' Description           :Assign ColumnProperty and add The Column property to the TableStyle
        ' Assumptions           :This function should be called after allthe properties are set 
        ' Dependencies          : 
        ' Author                : M.Kamal
        ' Created               : 18-Sept-2004 08:23 PM
        ' Revisions             : 
        '=====================================================================
        Try
            '---- Assign ColumnProperty and add The Column property to the TableStyle
            Select Case ColumnType
                Case enumColumnType.BoolColumn
                    mobjBoolColumn = New DataGridBoolColumn
                    mobjBoolColumn.Alignment = Alignment
                    mobjBoolColumn.HeaderText = ColumnHeaderCaption
                    mobjBoolColumn.MappingName = ColumnName
                    mobjBoolColumn.NullText = False
                    mobjBoolColumn.ReadOnly = blnReadOnly
                    If SetDataGridTableStyle.RowHeadersVisible = True Then
                        mobjBoolColumn.Width = ((DataGrid.Width - DataGrid.RowHeaderWidth) / DataSource.Columns.Count) - 2
                    Else
                        mobjBoolColumn.Width = (DataGrid.Width / DataSource.Columns.Count) - 1
                    End If
                    SetDataGridTableStyle.GridColumnStyles.Add(mobjBoolColumn)
                Case enumColumnType.TextBoxColumn
                    mobjTextColumn = New DataGridTextBoxColumn
                    mobjTextColumn.Alignment = Alignment
                    mobjTextColumn.HeaderText = ColumnHeaderCaption
                    mobjTextColumn.MappingName = ColumnName
                    mobjTextColumn.NullText = " "
                    mobjTextColumn.ReadOnly = blnReadOnly

                    If mblnAdjustRowWidth = False Then
                        'mobjTextColumn.Width = Width
                    Else
                        If SetDataGridTableStyle.RowHeadersVisible = True Then
                            mobjTextColumn.Width = ((DataGrid.Width - DataGrid.RowHeaderWidth) / DataSource.Columns.Count) - 2
                        Else
                            mobjTextColumn.Width = (DataGrid.Width / DataSource.Columns.Count) - 1
                        End If
                    End If

                    SetDataGridTableStyle.GridColumnStyles.Add(mobjTextColumn)
            End Select
            '  DataGrid.TableStyles.Add(mobjDataGridStyle)

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------           
        End Try
    End Sub

    'Public Sub AddDataGridColumnStyle(ByVal ColumnName As String, ByRef DataGrid As DataGrid, ByVal DataSource As ArrayList, ByVal Alignment As System.Windows.Forms.HorizontalAlignment, ByVal ColumnHeaderCaption As String, ByVal Width As Integer, ByVal blnReadOnly As Boolean, ByVal ColDataType As ColumnDataType, Optional ByVal AlignToRight As Boolean = False)
    '    '=====================================================================
    '    ' Procedure Name        : AddDataGridColumnStyle
    '    ' Parameters Passed     : ColumnName,DataGrid,DataSource,Alignment,ColumnHeaderCaption,Width,blnReadOnly 
    '    ' Returns               : 
    '    ' Purpose               : Sets the properties to the Column Style
    '    ' Description           : Assign ColumnProperty and add The Column property to the TableStyle
    '    ' Assumptions           :
    '    ' Dependencies          : 
    '    ' Author                : Deepak Bhati
    '    ' Created               : 24-Nov-2004 05:23 PM
    '    ' Revisions             : 
    '    '=====================================================================
    '    Try
    '        '---- Assign ColumnProperty and add The Column property to the TableStyle
    '        mobjClsDataGridTextBoxColumn = New clsDataGridTextBoxColumn(ColumnHeaderCaption, ColumnName, Width, DataSource, ColDataType, AlignToRight)
    '        'mobjClsDataGridTextBoxColumn = New clsDataGridTextBoxColumn(ColumnHeaderCaption, ColumnName, Width, ColDataType, AlignToRight)
    '        mobjClsDataGridTextBoxColumn.Alignment = Alignment
    '        mobjClsDataGridTextBoxColumn.NullText = " "
    '        mobjClsDataGridTextBoxColumn.ReadOnly = blnReadOnly

    '        If mblnAdjustRowWidth = False Then
    '            mobjClsDataGridTextBoxColumn.Width = Width
    '        End If

    '        SetDataGridTableStyle.GridColumnStyles.Add(mobjClsDataGridTextBoxColumn)

    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        'Error Handling and logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = ex.Message
    '        gobjErrorHandler.WriteErrorLog(ex)
    '        '---------------------------------------------------------
    '    Finally
    '        '---------------------------------------------------------
    '        'Writing Execution log
    '        If CONST_CREATE_EXECUTION_LOG = 1 Then
    '            gobjErrorHandler.WriteExecutionLog()
    '        End If
    '        '---------------------------------------------------------           
    '    End Try
    'End Sub

    Public Sub AddDataGridColumnStyle(ByVal ColumnName As String, ByRef DataGrid As DataGrid, ByVal DataSource As DataTable, ByVal Alignment As System.Windows.Forms.HorizontalAlignment, ByVal ColumnHeaderCaption As String, ByVal Width As Integer, ByVal blnReadOnly As Boolean, ByVal ColDataType As ColumnDataType, Optional ByVal AlignToRight As Boolean = False)
        '=====================================================================
        ' Procedure Name        : AddDataGridColumnStyle
        ' Parameters Passed     : ColumnName,DataGrid,DataSource,Alignment,ColumnHeaderCaption,Width,blnReadOnly 
        ' Returns               : 
        ' Purpose               : Sets the properties to the Column Style
        ' Description           : Assign ColumnProperty and add The Column property to the TableStyle
        ' Assumptions           :
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 24-Nov-2004 05:23 PM
        ' Revisions             : 
        '=====================================================================

        Try
            '---- Assign ColumnProperty and add The Column property to the TableStyle
            mobjClsDataGridTextBoxColumn = New clsDataGridTextBoxColumn(ColumnHeaderCaption, ColumnName, Width, DataSource, ColDataType, AlignToRight)
            'mobjClsDataGridTextBoxColumn = New clsDataGridTextBoxColumn(intNumberOfCharacters)
            mobjClsDataGridTextBoxColumn.Alignment = Alignment
            mobjClsDataGridTextBoxColumn.NullText = " "
            mobjClsDataGridTextBoxColumn.ReadOnly = blnReadOnly
            If mblnAdjustRowWidth = False Then
                mobjClsDataGridTextBoxColumn.Width = Width
            End If

            SetDataGridTableStyle.GridColumnStyles.Add(mobjClsDataGridTextBoxColumn)

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------           
        End Try
    End Sub

    Public Sub AddDataGridColumnStyle(ByVal ColumnName As String, ByRef DataGrid As DataGrid, ByVal DataSource As DataTable, ByVal Alignment As System.Windows.Forms.HorizontalAlignment, ByVal ColumnHeaderCaption As String, ByVal Width As Integer, ByVal blnReadOnly As Boolean, ByVal ColDataType As ColumnDataType, ByVal AlignData As HorizontalAlignment)
        '=====================================================================
        ' Procedure Name        : AddDataGridColumnStyle
        ' Parameters Passed     : ColumnName,DataGrid,DataSource,Alignment,ColumnHeaderCaption,Width,blnReadOnly 
        ' Returns               : 
        ' Purpose               : Sets the properties to the Column Style and display Header text and data in required alignment
        ' Description           : Assign ColumnProperty and add The Column property to the TableStyle
        ' Assumptions           :
        ' Dependencies          : 
        ' Author                : Deepak B.
        ' Created               : 2-April-2006 
        ' Revisions             : 
        '=====================================================================

        Try
            '---- Assign ColumnProperty and add The Column property to the TableStyle
            mobjClsDataGridTextBoxColumn = New clsDataGridTextBoxColumn(ColumnHeaderCaption, ColumnName, Width, DataSource, ColDataType)
            'mobjClsDataGridTextBoxColumn = New clsDataGridTextBoxColumn(intNumberOfCharacters)
            mobjClsDataGridTextBoxColumn.Alignment = Alignment
            mobjClsDataGridTextBoxColumn.NullText = " "
            mobjClsDataGridTextBoxColumn.ReadOnly = blnReadOnly
            mobjClsDataGridTextBoxColumn.DataAlignment = AlignData
            If mblnAdjustRowWidth = False Then
                mobjClsDataGridTextBoxColumn.Width = Width
            End If

            SetDataGridTableStyle.GridColumnStyles.Add(mobjClsDataGridTextBoxColumn)

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------           
        End Try
    End Sub

    Public Sub AddDataGridColumnStyle(ByVal ColumnName As String, ByRef DataGrid As DataGrid, ByVal DataSource As DataView, ByVal Alignment As System.Windows.Forms.HorizontalAlignment, ByVal ColumnHeaderCaption As String, ByVal Width As Integer, ByVal blnReadOnly As Boolean, ByVal ColDataType As ColumnDataType, ByVal AlignData As HorizontalAlignment)
        '=====================================================================
        ' Procedure Name        : AddDataGridColumnStyle
        ' Parameters Passed     : ColumnName,DataGrid,DataSource,Alignment,ColumnHeaderCaption,Width,blnReadOnly 
        ' Returns               : 
        ' Purpose               : Sets the properties to the Column Style and display Header text and data in required alignment
        ' Description           : Assign ColumnProperty and add The Column property to the TableStyle
        ' Assumptions           :
        ' Dependencies          : 
        ' Author                : Rahul B.
        ' Created               : 2-April-2006 
        ' Revisions             : 
        '=====================================================================

        Try
            '---- Assign ColumnProperty and add The Column property to the TableStyle
            mobjClsDataGridTextBoxColumn = New clsDataGridTextBoxColumn(ColumnHeaderCaption, ColumnName, Width, ColDataType)
            'mobjClsDataGridTextBoxColumn = New clsDataGridTextBoxColumn(intNumberOfCharacters)
            mobjClsDataGridTextBoxColumn.Alignment = Alignment
            mobjClsDataGridTextBoxColumn.NullText = " "
            mobjClsDataGridTextBoxColumn.ReadOnly = blnReadOnly
            mobjClsDataGridTextBoxColumn.DataAlignment = AlignData
            If mblnAdjustRowWidth = False Then
                mobjClsDataGridTextBoxColumn.Width = Width
            End If

            SetDataGridTableStyle.GridColumnStyles.Add(mobjClsDataGridTextBoxColumn)

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------           
        End Try
    End Sub

#End Region

#Region " Public/Private Shared Functions "

    Private Shared Sub NumericValidateGrid(ByRef objDataGridIn As DataGrid, ByVal objValidationDataIn() As structValidationData)  'ByVal ColumnIndicesToBeValidated() As Integer)
        '=====================================================================
        ' Procedure Name        : NumericValidateGrid
        ' Purpose               : To bind Event Handler of DataGrid for CurrentCellChanged
        ' Author                : Mangesh Shardul
        ' Created               : 30-April-2005
        ' Revisions             : 1
        '=====================================================================
        Try
            RemoveHandler objDataGridIn.CurrentCellChanged, AddressOf subCurrentCellChanged

            mobjValidationData = objValidationDataIn

            AddHandler objDataGridIn.CurrentCellChanged, AddressOf subCurrentCellChanged

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------
        End Try

    End Sub

    Private Shared Sub subCurrentCellChanged(ByVal sender As Object, ByVal e As EventArgs)
        '=====================================================================
        ' Procedure Name        : subCurrentCellChanged
        ' Purpose               : To handle the Current Cell Changed Event
        ' Author                : Mangesh Shardul
        ' Created               : 30-April-2005
        ' Revisions             : 1
        '=====================================================================
        Dim intCount As Integer
        Dim intColumnIndexToBeValidated As Integer
        Dim objValidationData As structValidationData

        Try
            RemoveHandler CType(sender, DataGrid).CurrentCellChanged, AddressOf subCurrentCellChanged

            For intCount = 0 To mobjValidationData.Length - 1
                objValidationData = mobjValidationData(intCount)

                If objValidationData.intColumnDataType = enumValidationType.Number Then
                    Call GridCellNumberValidator(CType(sender, DataGrid), objValidationData.intColumnIndex, objValidationData.intColumnDataType)
                ElseIf objValidationData.intColumnDataType = enumValidationType.Text Then
                    Call GridCellTextValidator(CType(sender, DataGrid), objValidationData.intColumnIndex, objValidationData.intColumnDataType)
                End If

            Next intCount

            AddHandler CType(sender, DataGrid).CurrentCellChanged, AddressOf subCurrentCellChanged

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------
        End Try
    End Sub

    Private Shared Function GridCellNumberValidator(ByRef DataGrid As Windows.forms.DataGrid, ByVal intColumnIndexToBeValidated As Integer, ByVal intValidationType As enumValidationType) As Boolean
        '=====================================================================
        ' Procedure Name        : GridCellNumberValidator
        ' Parameters Passed     : DataGrid by Reference, index of Column 
        ' Returns               : True or False
        ' Purpose               : To validate the data entered in the cell of DataGrid
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul 
        ' Created               : Saturday 30 April 2005 05:15 pm
        ' Revisions             : 1
        '=====================================================================
        Try
            If intValidationType = enumValidationType.Text Then
                Exit Function
            End If

            '''---Validation For Forward Navigation
            If Not DataGrid.CurrentCell.RowNumber = 0 Then
                If Not IsDBNull(DataGrid.Item(DataGrid.CurrentCell.RowNumber - 1, intColumnIndexToBeValidated)) Then
                    If IsNumeric(DataGrid.Item(DataGrid.CurrentCell.RowNumber - 1, intColumnIndexToBeValidated)) = False Then
                        gobjMessageAdapter.ShowMessage(constEnterOnlyNos)
                        Application.DoEvents()
                        DataGrid.CurrentCell = New DataGridCell(DataGrid.CurrentCell.RowNumber - 1, intColumnIndexToBeValidated)
                        Return True
                    End If
                End If
            End If

            '---Validation For Backward Navigation
            If DataGrid.CurrentCell.RowNumber < CType(DataGrid.DataSource, DataView).Count - 1 Then
                If Not IsDBNull(DataGrid.Item(DataGrid.CurrentCell.RowNumber + 1, intColumnIndexToBeValidated)) Then
                    If IsNumeric(DataGrid.Item(DataGrid.CurrentCell.RowNumber + 1, intColumnIndexToBeValidated)) = False Then
                        'MessageBox.Show("Enter only numbers.")170
                        gobjMessageAdapter.ShowMessage(constEnterOnlyNos)
                        Application.DoEvents()
                        DataGrid.CurrentCell = New DataGridCell(DataGrid.CurrentCell.RowNumber + 1, intColumnIndexToBeValidated)
                        Return True
                    End If
                End If
            End If

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            Return False
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------
        End Try
    End Function

    Private Shared Function GridCellTextValidator(ByRef objDataGrid As Windows.forms.DataGrid, ByVal intColumnIndexToBeValidated As Integer, ByVal intValidationType As enumValidationType) As Boolean
        '=====================================================================
        ' Procedure Name        : GridCellTextValidator
        ' Parameters Passed     : DataGrid by Reference, index of Column 
        ' Returns               : True or False
        ' Purpose               : To validate the data entered in the cell of DataGrid
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul 
        ' Created               : Tuesday 27-Mar-2007 03:25 pm
        ' Revisions             : 1
        '=====================================================================
        Dim strText As String
        Dim objDtDataSource As DataTable
        Dim intRowCounter As Integer
        Dim blnIsTextDuplicate As Boolean

        Try
            If intValidationType = enumValidationType.Number Then
                Exit Function
            End If

            '''---Validation For Forward Navigation
            If Not objDataGrid.CurrentCell.RowNumber = 0 Then
                If Not IsDBNull(objDataGrid.Item(objDataGrid.CurrentCell.RowNumber - 1, intColumnIndexToBeValidated)) Then
                    'Saruabh 17.07.07
                    'blnIsTextDuplicate = funcCheckDuplicateText(objDataGrid, intColumnIndexToBeValidated, objDataGrid.CurrentCell.RowNumber - 1)
                    'If blnIsTextDuplicate Then
                    '    'gobjMessageAdapter.ShowMessage("This text is already entered", "Unique Validation", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage)
                    '    Application.DoEvents()
                    '    objDataGrid.CurrentCell = New DataGridCell(objDataGrid.CurrentCell.RowNumber - 1, intColumnIndexToBeValidated)
                    '    Return True
                    'End If
                    'Saruabh 17.07.07
                End If
            End If

            '---Validation For Backward Navigation
            If objDataGrid.CurrentCell.RowNumber < CType(objDataGrid.DataSource, DataView).Count - 1 Then
                If Not IsDBNull(objDataGrid.Item(objDataGrid.CurrentCell.RowNumber + 1, intColumnIndexToBeValidated)) Then
                    'Saruabh 17.07.07
                    'blnIsTextDuplicate = funcCheckDuplicateText(objDataGrid, intColumnIndexToBeValidated, objDataGrid.CurrentCell.RowNumber + 1)
                    'If blnIsTextDuplicate Then
                    '    'gobjMessageAdapter.ShowMessage("This text is already entered", "Unique Validation", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage)
                    '    Application.DoEvents()
                    '    objDataGrid.CurrentCell = New DataGridCell(objDataGrid.CurrentCell.RowNumber + 1, intColumnIndexToBeValidated)
                    '    Return True
                    'End If
                    'Saruabh 17.07.07
                End If
            End If

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            Return False
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------
        End Try
    End Function

    Private Shared Function funcCheckDuplicateText(ByVal objDataGrid As DataGrid, ByVal intColumnIndexToBeValidated As Integer, ByVal intRowIndexToBeValidated As Integer) As Boolean
        '=====================================================================
        ' Procedure Name        : funcCheckDuplicateText
        ' Parameters Passed     : DataGrid, ColumnIndex, Navigation Direction
        ' Returns               : True or false
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 27-Mar-2007 03:45 pm
        ' Revisions             : 1
        '=====================================================================
        Dim objDtDataSource As DataTable
        Dim strText As String
        Dim blnIsTextDuplicate As Boolean
        Dim intRowCounter As Integer

        Try
            'If Not IsDBNull(objDataGrid.Item(intRowIndexToBeValidated, intColumnIndexToBeValidated)) Then
            strText = objDataGrid.Item(intRowIndexToBeValidated, intColumnIndexToBeValidated)
            'Else
            'strText = ""
            'End If

            blnIsTextDuplicate = False

            If TypeOf objDataGrid.DataSource Is DataTable Then
                objDtDataSource = CType(objDataGrid.DataSource, DataTable)
            ElseIf TypeOf objDataGrid.DataSource Is DataView Then
                objDtDataSource = CType(objDataGrid.DataSource, DataView).Table
            End If

            For intRowCounter = 0 To objDtDataSource.Rows.Count - 1
                If Not intRowCounter = intRowIndexToBeValidated Then
                    '---Perform Case Insensitive String comparison

                    'Added by Saurabh on 22 May 2007
                    If Not IsDBNull(objDtDataSource.Rows(intRowCounter).Item(intColumnIndexToBeValidated)) Then
                        'objDtDataSource.Rows(intRowCounter).Item(intColumnIndexToBeValidated) = ""
                        If UCase(CStr(objDtDataSource.Rows(intRowCounter).Item(intColumnIndexToBeValidated))) = UCase(strText) And strText.Trim() <> "" Then   'And condition added by pankaj on 26 MAy 07  And strText.Trim() <> "" 
                            '---entered text data already present in the DataGrid
                            blnIsTextDuplicate = True
                        End If
                    End If
                End If

            Next
          
            Return blnIsTextDuplicate

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            Return False
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------
        End Try
    End Function

#End Region

End Class


