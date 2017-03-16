Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data
Imports System.Data.OleDb

Public Class Form1
    Inherits System.Windows.Forms.Form

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
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    'Friend WithEvents ColorSpaceDiagram1 As ColorSpaceDiagram.ColorSpaceDiagram
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents AldysGraph1 As AldysGraph.AldysGraph
    
    Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid

    Friend WithEvents cmdDataset As System.Windows.Forms.Button
    Friend WithEvents OleDbDataAdapter1 As System.Data.OleDb.OleDbDataAdapter
    Friend WithEvents OleDbConnection2 As System.Data.OleDb.OleDbConnection
    Friend WithEvents OleDbSelectCommand1 As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbInsertCommand1 As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbUpdateCommand1 As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbDeleteCommand1 As System.Data.OleDb.OleDbCommand
    Friend WithEvents DataSet11 As AAS203.DataSet1
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Form1))
        Me.btnPrint = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.AldysGraph1 = New AldysGraph.AldysGraph
        Me.OleDbDataAdapter1 = New System.Data.OleDb.OleDbDataAdapter
        Me.OleDbConnection2 = New System.Data.OleDb.OleDbConnection
        Me.DataGrid1 = New System.Windows.Forms.DataGrid
        Me.cmdDataset = New System.Windows.Forms.Button
        Me.OleDbSelectCommand1 = New System.Data.OleDb.OleDbCommand
        Me.OleDbInsertCommand1 = New System.Data.OleDb.OleDbCommand
        Me.OleDbUpdateCommand1 = New System.Data.OleDb.OleDbCommand
        Me.OleDbDeleteCommand1 = New System.Data.OleDb.OleDbCommand
        Me.DataSet11 = New AAS203.DataSet1
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataSet11, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(16, 40)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(120, 40)
        Me.btnPrint.TabIndex = 0
        Me.btnPrint.Text = "Print"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(152, 40)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(120, 40)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "Print2"
        '
        'AldysGraph1
        '
        Me.AldysGraph1.AldysGraphCursor = Nothing
        Me.AldysGraph1.AldysGraphPrintColor = System.Drawing.Color.Black
        Me.AldysGraph1.BackColor = System.Drawing.Color.LightGray
        Me.AldysGraph1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AldysGraph1.GraphImage = Nothing
        Me.AldysGraph1.Location = New System.Drawing.Point(200, 128)
        Me.AldysGraph1.Name = "AldysGraph1"
        Me.AldysGraph1.Size = New System.Drawing.Size(320, 176)
        Me.AldysGraph1.TabIndex = 4
        '
        'OleDbDataAdapter1
        '
        Me.OleDbDataAdapter1.DeleteCommand = Me.OleDbDeleteCommand1
        Me.OleDbDataAdapter1.InsertCommand = Me.OleDbInsertCommand1
        Me.OleDbDataAdapter1.SelectCommand = Me.OleDbSelectCommand1
        Me.OleDbDataAdapter1.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "StdSampInfo", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("StdSamp", "StdSamp"), New System.Data.Common.DataColumnMapping("Weight", "Weight"), New System.Data.Common.DataColumnMapping("Volume", "Volume"), New System.Data.Common.DataColumnMapping("Dilution", "Dilution"), New System.Data.Common.DataColumnMapping("Abso", "Abso"), New System.Data.Common.DataColumnMapping("Conc", "Conc"), New System.Data.Common.DataColumnMapping("ConcUnit", "ConcUnit")})})
        Me.OleDbDataAdapter1.UpdateCommand = Me.OleDbUpdateCommand1
        '
        'OleDbConnection2
        '
        Me.OleDbConnection2.ConnectionString = "Jet OLEDB:Global Partial Bulk Ops=2;Jet OLEDB:Registry Path=;Jet OLEDB:Database L" & _
        "ocking Mode=0;Data Source=""D:\ALDYS\Development\AAS203\Sachin\AAS203\AAS203\bin\" & _
        "Database\AASBusinessData.mdb"";Jet OLEDB:Engine Type=5;Provider=""Microsoft.Jet.OL" & _
        "EDB.4.0"";Jet OLEDB:System database=;Jet OLEDB:SFP=False;persist security info=Fa" & _
        "lse;Extended Properties=;Mode=ReadWrite;Jet OLEDB:Encrypt Database=False;Jet OLE" & _
        "DB:Create System Database=False;Jet OLEDB:Don't Copy Locale on Compact=False;Jet" & _
        " OLEDB:Compact Without Replica Repair=False;User ID=Admin;Jet OLEDB:Global Bulk " & _
        "Transactions=1"
        '
        'DataGrid1
        '
        Me.DataGrid1.DataMember = ""
        Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid1.Location = New System.Drawing.Point(40, 120)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.Size = New System.Drawing.Size(456, 168)
        Me.DataGrid1.TabIndex = 5
        '
        'cmdDataset
        '
        Me.cmdDataset.Location = New System.Drawing.Point(296, 48)
        Me.cmdDataset.Name = "cmdDataset"
        Me.cmdDataset.Size = New System.Drawing.Size(128, 40)
        Me.cmdDataset.TabIndex = 6
        Me.cmdDataset.Text = "Fill Data"
        '
        'OleDbSelectCommand1
        '
        Me.OleDbSelectCommand1.CommandText = "SELECT StdSamp, Weight, Volume, Dilution, Abso, Conc, ConcUnit FROM StdSampInfo"
        Me.OleDbSelectCommand1.Connection = Me.OleDbConnection2
        '
        'OleDbInsertCommand1
        '
        Me.OleDbInsertCommand1.CommandText = "INSERT INTO StdSampInfo(StdSamp, Weight, Volume, Dilution, Abso, Conc, ConcUnit) " & _
        "VALUES (?, ?, ?, ?, ?, ?, ?)"
        Me.OleDbInsertCommand1.Connection = Me.OleDbConnection2
        Me.OleDbInsertCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("StdSamp", System.Data.OleDb.OleDbType.VarWChar, 50, "StdSamp"))
        Me.OleDbInsertCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Weight", System.Data.OleDb.OleDbType.Double, 0, "Weight"))
        Me.OleDbInsertCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Volume", System.Data.OleDb.OleDbType.Double, 0, "Volume"))
        Me.OleDbInsertCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Dilution", System.Data.OleDb.OleDbType.Double, 0, "Dilution"))
        Me.OleDbInsertCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Abso", System.Data.OleDb.OleDbType.Double, 0, "Abso"))
        Me.OleDbInsertCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Conc", System.Data.OleDb.OleDbType.Double, 0, "Conc"))
        Me.OleDbInsertCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("ConcUnit", System.Data.OleDb.OleDbType.Double, 0, "ConcUnit"))
        '
        'OleDbUpdateCommand1
        '
        Me.OleDbUpdateCommand1.CommandText = "UPDATE StdSampInfo SET StdSamp = ?, Weight = ?, Volume = ?, Dilution = ?, Abso = " & _
        "?, Conc = ?, ConcUnit = ? WHERE (StdSamp = ?) AND (Abso = ? OR ? IS NULL AND Abs" & _
        "o IS NULL) AND (Conc = ? OR ? IS NULL AND Conc IS NULL) AND (ConcUnit = ? OR ? I" & _
        "S NULL AND ConcUnit IS NULL) AND (Dilution = ? OR ? IS NULL AND Dilution IS NULL" & _
        ") AND (Volume = ? OR ? IS NULL AND Volume IS NULL) AND (Weight = ? OR ? IS NULL " & _
        "AND Weight IS NULL)"
        Me.OleDbUpdateCommand1.Connection = Me.OleDbConnection2
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("StdSamp", System.Data.OleDb.OleDbType.VarWChar, 50, "StdSamp"))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Weight", System.Data.OleDb.OleDbType.Double, 0, "Weight"))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Volume", System.Data.OleDb.OleDbType.Double, 0, "Volume"))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Dilution", System.Data.OleDb.OleDbType.Double, 0, "Dilution"))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Abso", System.Data.OleDb.OleDbType.Double, 0, "Abso"))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Conc", System.Data.OleDb.OleDbType.Double, 0, "Conc"))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("ConcUnit", System.Data.OleDb.OleDbType.Double, 0, "ConcUnit"))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_StdSamp", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "StdSamp", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Abso", System.Data.OleDb.OleDbType.Double, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Abso", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Abso1", System.Data.OleDb.OleDbType.Double, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Abso", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Conc", System.Data.OleDb.OleDbType.Double, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Conc", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Conc1", System.Data.OleDb.OleDbType.Double, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Conc", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_ConcUnit", System.Data.OleDb.OleDbType.Double, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ConcUnit", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_ConcUnit1", System.Data.OleDb.OleDbType.Double, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ConcUnit", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Dilution", System.Data.OleDb.OleDbType.Double, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Dilution", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Dilution1", System.Data.OleDb.OleDbType.Double, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Dilution", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Volume", System.Data.OleDb.OleDbType.Double, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Volume", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Volume1", System.Data.OleDb.OleDbType.Double, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Volume", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Weight", System.Data.OleDb.OleDbType.Double, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Weight", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Weight1", System.Data.OleDb.OleDbType.Double, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Weight", System.Data.DataRowVersion.Original, Nothing))
        '
        'OleDbDeleteCommand1
        '
        Me.OleDbDeleteCommand1.CommandText = "DELETE FROM StdSampInfo WHERE (StdSamp = ?) AND (Abso = ? OR ? IS NULL AND Abso I" & _
        "S NULL) AND (Conc = ? OR ? IS NULL AND Conc IS NULL) AND (ConcUnit = ? OR ? IS N" & _
        "ULL AND ConcUnit IS NULL) AND (Dilution = ? OR ? IS NULL AND Dilution IS NULL) A" & _
        "ND (Volume = ? OR ? IS NULL AND Volume IS NULL) AND (Weight = ? OR ? IS NULL AND" & _
        " Weight IS NULL)"
        Me.OleDbDeleteCommand1.Connection = Me.OleDbConnection2
        Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_StdSamp", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "StdSamp", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Abso", System.Data.OleDb.OleDbType.Double, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Abso", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Abso1", System.Data.OleDb.OleDbType.Double, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Abso", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Conc", System.Data.OleDb.OleDbType.Double, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Conc", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Conc1", System.Data.OleDb.OleDbType.Double, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Conc", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_ConcUnit", System.Data.OleDb.OleDbType.Double, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ConcUnit", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_ConcUnit1", System.Data.OleDb.OleDbType.Double, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ConcUnit", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Dilution", System.Data.OleDb.OleDbType.Double, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Dilution", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Dilution1", System.Data.OleDb.OleDbType.Double, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Dilution", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Volume", System.Data.OleDb.OleDbType.Double, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Volume", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Volume1", System.Data.OleDb.OleDbType.Double, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Volume", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Weight", System.Data.OleDb.OleDbType.Double, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Weight", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Weight1", System.Data.OleDb.OleDbType.Double, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Weight", System.Data.DataRowVersion.Original, Nothing))
        '
        'DataSet11
        '
        Me.DataSet11.DataSetName = "DataSet1"
        Me.DataSet11.Locale = New System.Globalization.CultureInfo("en-US")
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(712, 373)
        Me.Controls.Add(Me.cmdDataset)
        Me.Controls.Add(Me.DataGrid1)
        Me.Controls.Add(Me.AldysGraph1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnPrint)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataSet11, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Dim objclsPrintDocument As clsPrintDocument
        Dim objDtImagesList As New DataTable
        Dim arrGraphControlsList As New ArrayList
        Dim objstructReportFormatIn As New clsReportingMode.structReportFormat
        'Dim strPageHeader As String = " Test Page Header "
        Dim strPageHeader As clsPrintDocument.struHeaderString
        Dim strPageText As String = " Test Page Text "
        Dim objarrMoreTabularData As New ArrayList
        Dim objDt As DataTable = New DataTable
        Dim myDataColumn As DataColumn
        Dim myDataRow As DataRow
        Dim i As Integer
        Try
            strPageHeader.TextString = " Test Page Header "
            '+++++
            'for datatable and grid
            myDataColumn = New DataColumn
            myDataColumn.DataType = System.Type.GetType("System.Int32")
            myDataColumn.ColumnName = "id"
            myDataColumn.ReadOnly = True
            myDataColumn.Unique = True
            objDt.Columns.Add(myDataColumn)


            myDataColumn = New DataColumn
            myDataColumn.DataType = System.Type.GetType("System.String")
            myDataColumn.ColumnName = "ParentItem"
            myDataColumn.AutoIncrement = False
            myDataColumn.Caption = "ParentItem"
            myDataColumn.ReadOnly = False
            myDataColumn.Unique = False
            objDt.Columns.Add(myDataColumn)

            Dim PrimaryKeyColumns(0) As DataColumn
            PrimaryKeyColumns(0) = objDt.Columns("id")
            objDt.PrimaryKey = PrimaryKeyColumns

            For i = 0 To 100
                myDataRow = objDt.NewRow()
                myDataRow("id") = i
                myDataRow("ParentItem") = "ParentItem " + i.ToString()
                objDt.Rows.Add(myDataRow)
            Next i

            objarrMoreTabularData.Add(objDt)
            '+++++

            '++++++
            'for graphs
            Call AldysGraph1.GetImageOfGraph()
            'Call ColorSpaceDiagram1.GetImageOfGraph()
            arrGraphControlsList.Add(Me.AldysGraph1)
            'arrGraphControlsList.Add(Me.ColorSpaceDiagram1)
            '++++++

            objclsPrintDocument = funcSetPrintDocument(objstructReportFormatIn, strPageHeader, strPageText, _
                       arrGraphControlsList, objarrMoreTabularData, _
                       objDtImagesList, clsPrintDocument.enumReportType.CookBook)

            If Not IsNothing(objclsPrintDocument) = True Then
                If objclsPrintDocument.PrintPreview() = True Then
                    'If objclsPrintDocument.PrintToPrinter() = True Then
                    objclsPrintDocument.Dispose()
                    objclsPrintDocument = Nothing
                End If
            End If

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

    Private Sub btnPrint2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim objclsPrintDocument As clsPrintDocument
        Dim objDtImagesList As New DataTable
        Dim arrGraphControlsList As New ArrayList
        Dim objstructReportFormatIn As New clsReportingMode.structReportFormat
        'Dim strPageHeader As String = " Test Page Header "
        Dim strPageHeader As New clsPrintDocument.struHeaderString
        Dim strPageText As String = " Test Page Text "
        Dim objarrMoreTabularData As New ArrayList
        Try
            strPageHeader.TextString = " Test Page Header "
            objclsPrintDocument = funcSetPrintDocument(objstructReportFormatIn, strPageHeader, strPageText, _
                       arrGraphControlsList, objarrMoreTabularData, _
                       objDtImagesList, clsPrintDocument.enumReportType.CookBook)

            If Not IsNothing(objclsPrintDocument) = True Then
                If objclsPrintDocument.PrintPreview() = True Then
                    objclsPrintDocument.Dispose()
                    objclsPrintDocument = Nothing
                End If
            End If

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



    Private Function funcSetPrintDocument(ByVal objstructReportFormatIn As clsReportingMode.structReportFormat, _
                  ByVal strPageHeaderIn As clsPrintDocument.struHeaderString, _
                  ByVal strPageTextIn As String, _
                  ByVal arrGraphControlsListIn As ArrayList, _
                  ByVal arrDtTablesListIn As ArrayList, _
                  ByVal objDtImagesListIn As DataTable, _
                  ByVal intReportTypeIn As clsPrintDocument.enumReportType) As clsPrintDocument
        '=====================================================================
        ' Procedure Name        : funcSetPrintDocument
        ' Parameters Passed     : As above
        ' Returns               : True or false
        ' Purpose               : To set the clsPrintDocument object
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul At Machine SOFT1
        ' Created               : Monday, January 31, 2005
        ' Revisions             : 1
        '=====================================================================
        Dim intCount As Integer
        Dim objDtTable2In As DataTable
        Dim objclsPrintDocument As New clsPrintDocument
        Dim FontStyles As System.Drawing.Font = Me.DefaultFont
        Try
            objstructReportFormatIn.IsDisplayCompanyLogo = True
            objstructReportFormatIn.IsDisplayReportDate = True
            objstructReportFormatIn.IsDisplayReportFooter = True
            objstructReportFormatIn.IsDisplayReportTitle = True
            objstructReportFormatIn.IsDisplaySecondReportTitle = True
            objstructReportFormatIn.IsDisplaySubsequentPageHeader = True
            objstructReportFormatIn.LogoAlignment = Left
            objstructReportFormatIn.PageBottomMargin = 0.5
            objstructReportFormatIn.PageLeftMargin = 0.32
            objstructReportFormatIn.PageTopMargin = 1
            objstructReportFormatIn.LogoFileName = "D:\ALDYS\AAS 203 Borland Windows SW\win203.5\BMP\BMP\CHEMITO.BMP"

            objclsPrintDocument.ReportFormat = objstructReportFormatIn
            'objclsPrintDocument.PageHeader = strPageHeaderIn
            objclsPrintDocument.PageHeader = strPageHeaderIn
            objclsPrintDocument.PageText = strPageTextIn
            objclsPrintDocument.DisplayFont = Me.DefaultFont
            objclsPrintDocument.TableHeaderFont = FontStyles
            objclsPrintDocument.ReportImageList = objDtImagesListIn
            objclsPrintDocument.ReportType = intReportTypeIn
            objclsPrintDocument.ReportLayoutType = clsPrintDocument.enumReportLayoutType.Portrate

            '---Set Property ReportDataTables
            If IsNothing(arrDtTablesListIn) = False Then
                objclsPrintDocument.ReportDataTables = New ArrayList
                For intCount = 0 To arrDtTablesListIn.Count - 1
                    objDtTable2In = arrDtTablesListIn.Item(intCount)
                    If IsNothing(objDtTable2In) = False Then
                        objclsPrintDocument.ReportDataTables.Add(objDtTable2In)
                    End If
                Next intCount
            End If

            '---Set Property ReportGraphControls
            If IsNothing(arrGraphControlsListIn) = False Then
                objclsPrintDocument.ReportGraphControls = New ArrayList
                For intCount = 0 To arrGraphControlsListIn.Count - 1
                    If IsNothing(arrGraphControlsListIn.Item(intCount)) = False Then
                        objclsPrintDocument.ReportGraphControls.Add(arrGraphControlsListIn.Item(intCount))
                    End If
                Next intCount
            End If

            Return objclsPrintDocument

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            Return Nothing
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            If Not IsNothing(objclsPrintDocument) = True Then
                objclsPrintDocument.Dispose()
            End If
            '---------------------------------------------------------
        End Try

    End Function


    Private Sub DataGrid1_Navigate(ByVal sender As System.Object, ByVal ne As System.Windows.Forms.NavigateEventArgs) Handles DataGrid1.Navigate

    End Sub

    Private Sub cmdDataset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDataset.Click
        Dim DataSet_1 As New DataSet1
        Dim DataAdp As New OleDbDataAdapter
        Try


            DataSet11 = New AAS203.DataSet1
            ''Fill the dataset with the data retrieved.  The name of the table
            ''in the dataset must be the same as the table name in the report.
            OleDbDataAdapter1.Fill(DataSet11, "StdSampInfo")
            DataGrid1.SetDataBinding(DataSet11, "StdSampInfo")
            DataGrid1.Refresh()
        Catch ex As Exception

        End Try
    End Sub
End Class
