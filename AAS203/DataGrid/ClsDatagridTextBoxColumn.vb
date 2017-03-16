Option Explicit On 
Option Strict Off

Public Class clsDataGridTextBoxColumn
    Inherits System.Windows.Forms.DataGridTextBoxColumn
    '****************************************************************************************
    ' File Header
    ' File Name 		: ClsDatagridTextBoxColumn.vb
    ' Author			: Deepak Bhati
    ' Date/Time			: Wednesday, November 24, 2004
    ' Description		: This component is used to validate a required column 
    '****************************************************************************************

#Region " Class Variables "
    Private mblnAlignToRight As Boolean = False
    Private mColumnDataType As ColDataType
    Private mTextAlignment As HorizontalAlignment = HorizontalAlignment.Left
    Private mDrawText As New StringFormat
    Private mIntNumberOfCharacters As Integer
    Private mArrDataSource As New ArrayList
    Private mSeparator As System.Drawing.Color
    Private mdtDataSource As New DataTable
    Private mdvDataSource As New DataView
    Private mintDataSourceType As Integer
    Private mblnGroups As Boolean
    Private mArrGroups As New ArrayList
    Private mblnCheckNumberOfCharacters As Boolean = False
    Private mblnIsNumericValidationRequired As Boolean = False
#End Region

#Region " Public Enums, Structures, .. "

    Public Enum ColDataType
        Text = 1
        Color = 2
    End Enum

    Public Enum SourceType
        ArrayList = 1
        Datatable = 2
        DataView = 3
    End Enum

#End Region

#Region " Public Properties "
    Public Property NumberOfCharacters() As Integer
        Get
            Return mIntNumberOfCharacters
        End Get
        Set(ByVal Value As Integer)
            mIntNumberOfCharacters = Value
        End Set
    End Property

    Public Property DataAlignment() As HorizontalAlignment
        Get
            Return mTextAlignment
        End Get
        Set(ByVal Value As HorizontalAlignment)
            mTextAlignment = Value
            If mTextAlignment = HorizontalAlignment.Center Then
                mDrawText.Alignment = StringAlignment.Center
            ElseIf mTextAlignment = HorizontalAlignment.Right Then
                mDrawText.Alignment = StringAlignment.Far
            Else
                mDrawText.Alignment = StringAlignment.Near
            End If
        End Set
    End Property

    Public Property ColumnDataType() As ColDataType
        Get
            Return mColumnDataType
        End Get
        Set(ByVal Value As ColDataType)
            mColumnDataType = Value
        End Set
    End Property

    Public Property SeparatorColor() As System.Drawing.Color
        Get
            Return mSeparator
        End Get
        Set(ByVal Value As System.Drawing.Color)
            mSeparator = Value
        End Set
    End Property

    Public Property DataSourceType() As SourceType
        Get
            Return mintDataSourceType
        End Get
        Set(ByVal Value As SourceType)
            mintDataSourceType = Value
        End Set
    End Property

#End Region

#Region " Constructors "

    Public Sub New(ByVal intNumberOfCharacters As Integer, ByVal blnCheckNumberOfCharacters As Boolean, ByVal BlnNumericValidationRequired As Boolean, ByVal AlignToRight As Boolean, ByVal blnNothing As Boolean)
        mblnAlignToRight = AlignToRight
        NumberOfCharacters = intNumberOfCharacters
        mblnCheckNumberOfCharacters = blnCheckNumberOfCharacters
        mblnIsNumericValidationRequired = BlnNumericValidationRequired
    End Sub

    Public Sub New(ByVal headerText As String, ByVal mappingName As String, ByVal width As Integer, ByVal DataSource As ArrayList, ByVal ColDataTypeIn As ColDataType, Optional ByVal AlignToRight As Boolean = False)
        MyBase.HeaderText = headerText
        MyBase.MappingName = mappingName
        MyBase.Width = width
        mArrDataSource = DataSource
        ColumnDataType = ColDataTypeIn
        SeparatorColor = System.Drawing.Color.White
        DataSourceType = SourceType.ArrayList
        mblnAlignToRight = AlignToRight

    End Sub

    Public Sub New(ByVal headerText As String, ByVal mappingName As String, ByVal width As Integer, ByVal DataSource As DataTable, ByVal ColDataTypeIn As ColDataType, Optional ByVal AlignToRight As Boolean = False)
        MyBase.HeaderText = headerText
        MyBase.MappingName = mappingName
        MyBase.Width = width
        mdtDataSource = DataSource
        ColumnDataType = ColDataTypeIn
        SeparatorColor = System.Drawing.Color.LightGray
        DataSourceType = SourceType.Datatable
        mblnAlignToRight = AlignToRight
        'Me.HeaderText = Me.HeaderText & Space(1)

    End Sub

    Public Sub New(ByVal headerText As String, ByVal mappingName As String, ByVal width As Integer, ByVal ColDataTypeIn As ColDataType, Optional ByVal AlignToRight As Boolean = False)
        MyBase.HeaderText = headerText
        MyBase.MappingName = mappingName
        MyBase.Width = width
        ColumnDataType = ColDataTypeIn
        SeparatorColor = System.Drawing.Color.LightGray
        DataSourceType = 0
        mblnAlignToRight = AlignToRight
        'Me.HeaderText = Me.HeaderText & Space(1)

    End Sub

#End Region

#Region " Overriden Private Functions "

    Protected Overloads Overrides Sub Edit(ByVal source As System.Windows.Forms.CurrencyManager, ByVal rowNum As Integer, ByVal bounds As System.Drawing.Rectangle, ByVal isReadOnly As Boolean, ByVal instantText As String, ByVal cellIsVisible As Boolean)
        MyBase.Edit(source, rowNum, bounds, [ReadOnly], instantText, cellIsVisible)
        MyBase.TextBox.TextAlign = mTextAlignment
        MyBase.TextBox.CharacterCasing = CharacterCasing.Normal
        If mblnCheckNumberOfCharacters = True Then
            MyBase.TextBox.MaxLength = NumberOfCharacters
        End If

    End Sub

    Protected Overloads Overrides Sub Paint(ByVal g As System.Drawing.Graphics, ByVal bounds As System.Drawing.Rectangle, ByVal source As System.Windows.Forms.CurrencyManager, ByVal rowNum As Integer, ByVal backBrush As System.Drawing.Brush, ByVal foreBrush As System.Drawing.Brush, ByVal alignToRight As Boolean)
        '=====================================================================
        ' Procedure Name        : Paint
        ' Parameters Passed     : graphics object,bounds ,source, rowNum,backBrush, foreBrush ,alignToRight 
        ' Returns               : None
        ' Purpose               : To paint the given column with given set of colors
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : Wednesday, November 24, 2004
        ' Revisions             : 
        '=====================================================================
        Dim intRowCount As Integer
        Dim objColor As New Color
        Dim objText As String
        Dim bgBrush As Brush, fgBrush As Brush

        Try

            If Me.DataGridTableStyle.DataGrid.IsSelected(rowNum) Then
                bgBrush = New SolidBrush(Me.DataGridTableStyle.SelectionBackColor)
                fgBrush = New SolidBrush(Me.DataGridTableStyle.SelectionForeColor)
            Else
                bgBrush = New SolidBrush(Me.DataGridTableStyle.BackColor)
                fgBrush = New SolidBrush(Me.DataGridTableStyle.ForeColor)
            End If

            g.FillRectangle(bgBrush, bounds)

            If IsDBNull(Me.GetColumnValueAtRow(source, rowNum)) Then
                objText = " "
            Else
                objText = Me.GetColumnValueAtRow(source, rowNum)
            End If

            Dim r As Rectangle = bounds
            r.Inflate(0, -1)

            Select Case mDrawText.Alignment
                Case StringAlignment.Far
                    g.DrawString(objText, MyBase.TextBox.Font, foreBrush, r.X + r.Width, r.Y, mDrawText)
                Case StringAlignment.Center
                    g.DrawString(objText, MyBase.TextBox.Font, foreBrush, r.X + (r.Width / 2), r.Y, mDrawText)
                Case Else
                    g.DrawString(objText, MyBase.TextBox.Font, foreBrush, r.X, r.Y, mDrawText)
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

#End Region

End Class
