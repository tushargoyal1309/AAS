using CrystalDecisions.CrystalReports.Engine;
using System.Data;
using System.Data.OleDb;

public class Form1 : System.Windows.Forms.Form
{

	#Region " Windows Form Designer generated code "

	public Form1()
	{
		base.New();

		//This call is required by the Windows Form Designer.
		InitializeComponent();

		//Add any initialization after the InitializeComponent() call

	}

	//Form overrides dispose to clean up the component list.
	protected override void Dispose(bool disposing)
	{
		if (disposing) {
			if (!(components == null)) {
				components.Dispose();
			}
		}
		base.Dispose(disposing);
	}

	//Required by the Windows Form Designer

	private System.ComponentModel.IContainer components;
	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.  
	//Do not modify it using the code editor.
	internal System.Windows.Forms.Button btnPrint;
	//Friend WithEvents ColorSpaceDiagram1 As ColorSpaceDiagram.ColorSpaceDiagram
	internal System.Windows.Forms.Button Button1;
	internal AldysGraph.AldysGraph AldysGraph1;


	internal System.Windows.Forms.DataGrid DataGrid1;
	internal System.Windows.Forms.Button cmdDataset;
	internal System.Data.OleDb.OleDbDataAdapter OleDbDataAdapter1;
	internal System.Data.OleDb.OleDbConnection OleDbConnection2;
	internal System.Data.OleDb.OleDbCommand OleDbSelectCommand1;
	internal System.Data.OleDb.OleDbCommand OleDbInsertCommand1;
	internal System.Data.OleDb.OleDbCommand OleDbUpdateCommand1;
	internal System.Data.OleDb.OleDbCommand OleDbDeleteCommand1;
	internal AAS203.DataSet1 DataSet11;
	[System.Diagnostics.DebuggerStepThrough()]
	private void InitializeComponent()
	{
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Form1));
		this.btnPrint = new System.Windows.Forms.Button();
		this.Button1 = new System.Windows.Forms.Button();
		this.AldysGraph1 = new AldysGraph.AldysGraph();
		this.OleDbDataAdapter1 = new System.Data.OleDb.OleDbDataAdapter();
		this.OleDbConnection2 = new System.Data.OleDb.OleDbConnection();
		this.DataGrid1 = new System.Windows.Forms.DataGrid();
		this.cmdDataset = new System.Windows.Forms.Button();
		this.OleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
		this.OleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
		this.OleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
		this.OleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
		this.DataSet11 = new AAS203.DataSet1();
		((System.ComponentModel.ISupportInitialize)this.DataGrid1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.DataSet11).BeginInit();
		this.SuspendLayout();
		//
		//btnPrint
		//
		this.btnPrint.Location = new System.Drawing.Point(16, 40);
		this.btnPrint.Name = "btnPrint";
		this.btnPrint.Size = new System.Drawing.Size(120, 40);
		this.btnPrint.TabIndex = 0;
		this.btnPrint.Text = "Print";
		//
		//Button1
		//
		this.Button1.Location = new System.Drawing.Point(152, 40);
		this.Button1.Name = "Button1";
		this.Button1.Size = new System.Drawing.Size(120, 40);
		this.Button1.TabIndex = 3;
		this.Button1.Text = "Print2";
		//
		//AldysGraph1
		//
		this.AldysGraph1.AldysGraphCursor = null;
		this.AldysGraph1.AldysGraphPrintColor = System.Drawing.Color.Black;
		this.AldysGraph1.BackColor = System.Drawing.Color.LightGray;
		this.AldysGraph1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.AldysGraph1.GraphImage = null;
		this.AldysGraph1.Location = new System.Drawing.Point(200, 128);
		this.AldysGraph1.Name = "AldysGraph1";
		this.AldysGraph1.Size = new System.Drawing.Size(320, 176);
		this.AldysGraph1.TabIndex = 4;
		//
		//OleDbDataAdapter1
		//
		this.OleDbDataAdapter1.DeleteCommand = this.OleDbDeleteCommand1;
		this.OleDbDataAdapter1.InsertCommand = this.OleDbInsertCommand1;
		this.OleDbDataAdapter1.SelectCommand = this.OleDbSelectCommand1;
		this.OleDbDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] { new System.Data.Common.DataTableMapping("Table", "StdSampInfo", new System.Data.Common.DataColumnMapping[] {
			new System.Data.Common.DataColumnMapping("StdSamp", "StdSamp"),
			new System.Data.Common.DataColumnMapping("Weight", "Weight"),
			new System.Data.Common.DataColumnMapping("Volume", "Volume"),
			new System.Data.Common.DataColumnMapping("Dilution", "Dilution"),
			new System.Data.Common.DataColumnMapping("Abso", "Abso"),
			new System.Data.Common.DataColumnMapping("Conc", "Conc"),
			new System.Data.Common.DataColumnMapping("ConcUnit", "ConcUnit")
		}) });
		this.OleDbDataAdapter1.UpdateCommand = this.OleDbUpdateCommand1;
		//
		//OleDbConnection2
		//
		this.OleDbConnection2.ConnectionString = "Jet OLEDB:Global Partial Bulk Ops=2;Jet OLEDB:Registry Path=;Jet OLEDB:Database L" + "ocking Mode=0;Data Source=\"D:\\ALDYS\\Development\\AAS203\\Sachin\\AAS203\\AAS203\\bin\\" + "Database\\AASBusinessData.mdb\";Jet OLEDB:Engine Type=5;Provider=\"Microsoft.Jet.OL" + "EDB.4.0\";Jet OLEDB:System database=;Jet OLEDB:SFP=False;persist security info=Fa" + "lse;Extended Properties=;Mode=ReadWrite;Jet OLEDB:Encrypt Database=False;Jet OLE" + "DB:Create System Database=False;Jet OLEDB:Don't Copy Locale on Compact=False;Jet" + " OLEDB:Compact Without Replica Repair=False;User ID=Admin;Jet OLEDB:Global Bulk " + "Transactions=1";
		//
		//DataGrid1
		//
		this.DataGrid1.DataMember = "";
		this.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
		this.DataGrid1.Location = new System.Drawing.Point(40, 120);
		this.DataGrid1.Name = "DataGrid1";
		this.DataGrid1.Size = new System.Drawing.Size(456, 168);
		this.DataGrid1.TabIndex = 5;
		//
		//cmdDataset
		//
		this.cmdDataset.Location = new System.Drawing.Point(296, 48);
		this.cmdDataset.Name = "cmdDataset";
		this.cmdDataset.Size = new System.Drawing.Size(128, 40);
		this.cmdDataset.TabIndex = 6;
		this.cmdDataset.Text = "Fill Data";
		//
		//OleDbSelectCommand1
		//
		this.OleDbSelectCommand1.CommandText = "SELECT StdSamp, Weight, Volume, Dilution, Abso, Conc, ConcUnit FROM StdSampInfo";
		this.OleDbSelectCommand1.Connection = this.OleDbConnection2;
		//
		//OleDbInsertCommand1
		//
		this.OleDbInsertCommand1.CommandText = "INSERT INTO StdSampInfo(StdSamp, Weight, Volume, Dilution, Abso, Conc, ConcUnit) " + "VALUES (?, ?, ?, ?, ?, ?, ?)";
		this.OleDbInsertCommand1.Connection = this.OleDbConnection2;
		this.OleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("StdSamp", System.Data.OleDb.OleDbType.VarWChar, 50, "StdSamp"));
		this.OleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Weight", System.Data.OleDb.OleDbType.Double, 0, "Weight"));
		this.OleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Volume", System.Data.OleDb.OleDbType.Double, 0, "Volume"));
		this.OleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Dilution", System.Data.OleDb.OleDbType.Double, 0, "Dilution"));
		this.OleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Abso", System.Data.OleDb.OleDbType.Double, 0, "Abso"));
		this.OleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Conc", System.Data.OleDb.OleDbType.Double, 0, "Conc"));
		this.OleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ConcUnit", System.Data.OleDb.OleDbType.Double, 0, "ConcUnit"));
		//
		//OleDbUpdateCommand1
		//
		this.OleDbUpdateCommand1.CommandText = "UPDATE StdSampInfo SET StdSamp = ?, Weight = ?, Volume = ?, Dilution = ?, Abso = " + "?, Conc = ?, ConcUnit = ? WHERE (StdSamp = ?) AND (Abso = ? OR ? IS NULL AND Abs" + "o IS NULL) AND (Conc = ? OR ? IS NULL AND Conc IS NULL) AND (ConcUnit = ? OR ? I" + "S NULL AND ConcUnit IS NULL) AND (Dilution = ? OR ? IS NULL AND Dilution IS NULL" + ") AND (Volume = ? OR ? IS NULL AND Volume IS NULL) AND (Weight = ? OR ? IS NULL " + "AND Weight IS NULL)";
		this.OleDbUpdateCommand1.Connection = this.OleDbConnection2;
		this.OleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("StdSamp", System.Data.OleDb.OleDbType.VarWChar, 50, "StdSamp"));
		this.OleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Weight", System.Data.OleDb.OleDbType.Double, 0, "Weight"));
		this.OleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Volume", System.Data.OleDb.OleDbType.Double, 0, "Volume"));
		this.OleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Dilution", System.Data.OleDb.OleDbType.Double, 0, "Dilution"));
		this.OleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Abso", System.Data.OleDb.OleDbType.Double, 0, "Abso"));
		this.OleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Conc", System.Data.OleDb.OleDbType.Double, 0, "Conc"));
		this.OleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ConcUnit", System.Data.OleDb.OleDbType.Double, 0, "ConcUnit"));
		this.OleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_StdSamp", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, (byte)0, (byte)0, "StdSamp", System.Data.DataRowVersion.Original, null));
		this.OleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Abso", System.Data.OleDb.OleDbType.Double, 0, System.Data.ParameterDirection.Input, false, (byte)0, (byte)0, "Abso", System.Data.DataRowVersion.Original, null));
		this.OleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Abso1", System.Data.OleDb.OleDbType.Double, 0, System.Data.ParameterDirection.Input, false, (byte)0, (byte)0, "Abso", System.Data.DataRowVersion.Original, null));
		this.OleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Conc", System.Data.OleDb.OleDbType.Double, 0, System.Data.ParameterDirection.Input, false, (byte)0, (byte)0, "Conc", System.Data.DataRowVersion.Original, null));
		this.OleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Conc1", System.Data.OleDb.OleDbType.Double, 0, System.Data.ParameterDirection.Input, false, (byte)0, (byte)0, "Conc", System.Data.DataRowVersion.Original, null));
		this.OleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ConcUnit", System.Data.OleDb.OleDbType.Double, 0, System.Data.ParameterDirection.Input, false, (byte)0, (byte)0, "ConcUnit", System.Data.DataRowVersion.Original, null));
		this.OleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ConcUnit1", System.Data.OleDb.OleDbType.Double, 0, System.Data.ParameterDirection.Input, false, (byte)0, (byte)0, "ConcUnit", System.Data.DataRowVersion.Original, null));
		this.OleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Dilution", System.Data.OleDb.OleDbType.Double, 0, System.Data.ParameterDirection.Input, false, (byte)0, (byte)0, "Dilution", System.Data.DataRowVersion.Original, null));
		this.OleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Dilution1", System.Data.OleDb.OleDbType.Double, 0, System.Data.ParameterDirection.Input, false, (byte)0, (byte)0, "Dilution", System.Data.DataRowVersion.Original, null));
		this.OleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Volume", System.Data.OleDb.OleDbType.Double, 0, System.Data.ParameterDirection.Input, false, (byte)0, (byte)0, "Volume", System.Data.DataRowVersion.Original, null));
		this.OleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Volume1", System.Data.OleDb.OleDbType.Double, 0, System.Data.ParameterDirection.Input, false, (byte)0, (byte)0, "Volume", System.Data.DataRowVersion.Original, null));
		this.OleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Weight", System.Data.OleDb.OleDbType.Double, 0, System.Data.ParameterDirection.Input, false, (byte)0, (byte)0, "Weight", System.Data.DataRowVersion.Original, null));
		this.OleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Weight1", System.Data.OleDb.OleDbType.Double, 0, System.Data.ParameterDirection.Input, false, (byte)0, (byte)0, "Weight", System.Data.DataRowVersion.Original, null));
		//
		//OleDbDeleteCommand1
		//
		this.OleDbDeleteCommand1.CommandText = "DELETE FROM StdSampInfo WHERE (StdSamp = ?) AND (Abso = ? OR ? IS NULL AND Abso I" + "S NULL) AND (Conc = ? OR ? IS NULL AND Conc IS NULL) AND (ConcUnit = ? OR ? IS N" + "ULL AND ConcUnit IS NULL) AND (Dilution = ? OR ? IS NULL AND Dilution IS NULL) A" + "ND (Volume = ? OR ? IS NULL AND Volume IS NULL) AND (Weight = ? OR ? IS NULL AND" + " Weight IS NULL)";
		this.OleDbDeleteCommand1.Connection = this.OleDbConnection2;
		this.OleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_StdSamp", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, (byte)0, (byte)0, "StdSamp", System.Data.DataRowVersion.Original, null));
		this.OleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Abso", System.Data.OleDb.OleDbType.Double, 0, System.Data.ParameterDirection.Input, false, (byte)0, (byte)0, "Abso", System.Data.DataRowVersion.Original, null));
		this.OleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Abso1", System.Data.OleDb.OleDbType.Double, 0, System.Data.ParameterDirection.Input, false, (byte)0, (byte)0, "Abso", System.Data.DataRowVersion.Original, null));
		this.OleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Conc", System.Data.OleDb.OleDbType.Double, 0, System.Data.ParameterDirection.Input, false, (byte)0, (byte)0, "Conc", System.Data.DataRowVersion.Original, null));
		this.OleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Conc1", System.Data.OleDb.OleDbType.Double, 0, System.Data.ParameterDirection.Input, false, (byte)0, (byte)0, "Conc", System.Data.DataRowVersion.Original, null));
		this.OleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ConcUnit", System.Data.OleDb.OleDbType.Double, 0, System.Data.ParameterDirection.Input, false, (byte)0, (byte)0, "ConcUnit", System.Data.DataRowVersion.Original, null));
		this.OleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ConcUnit1", System.Data.OleDb.OleDbType.Double, 0, System.Data.ParameterDirection.Input, false, (byte)0, (byte)0, "ConcUnit", System.Data.DataRowVersion.Original, null));
		this.OleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Dilution", System.Data.OleDb.OleDbType.Double, 0, System.Data.ParameterDirection.Input, false, (byte)0, (byte)0, "Dilution", System.Data.DataRowVersion.Original, null));
		this.OleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Dilution1", System.Data.OleDb.OleDbType.Double, 0, System.Data.ParameterDirection.Input, false, (byte)0, (byte)0, "Dilution", System.Data.DataRowVersion.Original, null));
		this.OleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Volume", System.Data.OleDb.OleDbType.Double, 0, System.Data.ParameterDirection.Input, false, (byte)0, (byte)0, "Volume", System.Data.DataRowVersion.Original, null));
		this.OleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Volume1", System.Data.OleDb.OleDbType.Double, 0, System.Data.ParameterDirection.Input, false, (byte)0, (byte)0, "Volume", System.Data.DataRowVersion.Original, null));
		this.OleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Weight", System.Data.OleDb.OleDbType.Double, 0, System.Data.ParameterDirection.Input, false, (byte)0, (byte)0, "Weight", System.Data.DataRowVersion.Original, null));
		this.OleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Weight1", System.Data.OleDb.OleDbType.Double, 0, System.Data.ParameterDirection.Input, false, (byte)0, (byte)0, "Weight", System.Data.DataRowVersion.Original, null));
		//
		//DataSet11
		//
		this.DataSet11.DataSetName = "DataSet1";
		this.DataSet11.Locale = new System.Globalization.CultureInfo("en-US");
		//
		//Form1
		//
		this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
		this.ClientSize = new System.Drawing.Size(712, 373);
		this.Controls.Add(this.cmdDataset);
		this.Controls.Add(this.DataGrid1);
		this.Controls.Add(this.AldysGraph1);
		this.Controls.Add(this.Button1);
		this.Controls.Add(this.btnPrint);
		this.Name = "Form1";
		this.Text = "Form1";
		((System.ComponentModel.ISupportInitialize)this.DataGrid1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.DataSet11).EndInit();
		this.ResumeLayout(false);

	}

	#End Region

	private void  // ERROR: Handles clauses are not supported in C#
btnPrint_Click(System.Object sender, System.EventArgs e)
	{
		clsPrintDocument objclsPrintDocument;
		DataTable objDtImagesList = new DataTable();
		ArrayList arrGraphControlsList = new ArrayList();
		clsReportingMode.structReportFormat objstructReportFormatIn = new clsReportingMode.structReportFormat();
		//Dim strPageHeader As String = " Test Page Header "
		clsPrintDocument.struHeaderString strPageHeader;
		string strPageText = " Test Page Text ";
		ArrayList objarrMoreTabularData = new ArrayList();
		DataTable objDt = new DataTable();
		DataColumn myDataColumn;
		DataRow myDataRow;
		int i;
		try {
			strPageHeader.TextString = " Test Page Header ";
			//+++++
			//for datatable and grid
			myDataColumn = new DataColumn();
			myDataColumn.DataType = System.Type.GetType("System.Int32");
			myDataColumn.ColumnName = "id";
			myDataColumn.ReadOnly = true;
			myDataColumn.Unique = true;
			objDt.Columns.Add(myDataColumn);


			myDataColumn = new DataColumn();
			myDataColumn.DataType = System.Type.GetType("System.String");
			myDataColumn.ColumnName = "ParentItem";
			myDataColumn.AutoIncrement = false;
			myDataColumn.Caption = "ParentItem";
			myDataColumn.ReadOnly = false;
			myDataColumn.Unique = false;
			objDt.Columns.Add(myDataColumn);

			DataColumn[] PrimaryKeyColumns = new DataColumn[-1];
			PrimaryKeyColumns(0) = objDt.Columns("id");
			objDt.PrimaryKey = PrimaryKeyColumns;

			for (i = 0; i <= 100; i++) {
				myDataRow = objDt.NewRow();
				myDataRow("id") = i;
				myDataRow("ParentItem") = "ParentItem " + i.ToString();
				objDt.Rows.Add(myDataRow);
			}

			objarrMoreTabularData.Add(objDt);
			//+++++

			//++++++
			//for graphs
			AldysGraph1.GetImageOfGraph();
			//Call ColorSpaceDiagram1.GetImageOfGraph()
			arrGraphControlsList.Add(this.AldysGraph1);
			//arrGraphControlsList.Add(Me.ColorSpaceDiagram1)
			//++++++

			objclsPrintDocument = funcSetPrintDocument(objstructReportFormatIn, strPageHeader, strPageText, arrGraphControlsList, objarrMoreTabularData, objDtImagesList, clsPrintDocument.enumReportType.CookBook);

			if (!IsNothing(objclsPrintDocument) == true) {
				if (objclsPrintDocument.PrintPreview() == true) {
					//If objclsPrintDocument.PrintToPrinter() = True Then
					objclsPrintDocument.Dispose();
					objclsPrintDocument = null;
				}
			}

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			//---------------------------------------------------------
		}
	}

	private void  // ERROR: Handles clauses are not supported in C#
btnPrint2_Click(System.Object sender, System.EventArgs e)
	{
		clsPrintDocument objclsPrintDocument;
		DataTable objDtImagesList = new DataTable();
		ArrayList arrGraphControlsList = new ArrayList();
		clsReportingMode.structReportFormat objstructReportFormatIn = new clsReportingMode.structReportFormat();
		//Dim strPageHeader As String = " Test Page Header "
		clsPrintDocument.struHeaderString strPageHeader = new clsPrintDocument.struHeaderString();
		string strPageText = " Test Page Text ";
		ArrayList objarrMoreTabularData = new ArrayList();
		try {
			strPageHeader.TextString = " Test Page Header ";
			objclsPrintDocument = funcSetPrintDocument(objstructReportFormatIn, strPageHeader, strPageText, arrGraphControlsList, objarrMoreTabularData, objDtImagesList, clsPrintDocument.enumReportType.CookBook);

			if (!IsNothing(objclsPrintDocument) == true) {
				if (objclsPrintDocument.PrintPreview() == true) {
					objclsPrintDocument.Dispose();
					objclsPrintDocument = null;
				}
			}

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			//---------------------------------------------------------
		}
	}



	private clsPrintDocument funcSetPrintDocument(clsReportingMode.structReportFormat objstructReportFormatIn, clsPrintDocument.struHeaderString strPageHeaderIn, string strPageTextIn, ArrayList arrGraphControlsListIn, ArrayList arrDtTablesListIn, DataTable objDtImagesListIn, clsPrintDocument.enumReportType intReportTypeIn)
	{
		//=====================================================================
		// Procedure Name        : funcSetPrintDocument
		// Parameters Passed     : As above
		// Returns               : True or false
		// Purpose               : To set the clsPrintDocument object
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul At Machine SOFT1
		// Created               : Monday, January 31, 2005
		// Revisions             : 1
		//=====================================================================
		int intCount;
		DataTable objDtTable2In;
		clsPrintDocument objclsPrintDocument = new clsPrintDocument();
		System.Drawing.Font FontStyles = this.DefaultFont;
		try {
			objstructReportFormatIn.IsDisplayCompanyLogo = true;
			objstructReportFormatIn.IsDisplayReportDate = true;
			objstructReportFormatIn.IsDisplayReportFooter = true;
			objstructReportFormatIn.IsDisplayReportTitle = true;
			objstructReportFormatIn.IsDisplaySecondReportTitle = true;
			objstructReportFormatIn.IsDisplaySubsequentPageHeader = true;
			objstructReportFormatIn.LogoAlignment = Left;
			objstructReportFormatIn.PageBottomMargin = 0.5;
			objstructReportFormatIn.PageLeftMargin = 0.32;
			objstructReportFormatIn.PageTopMargin = 1;
			objstructReportFormatIn.LogoFileName = "D:\\ALDYS\\AAS 203 Borland Windows SW\\win203.5\\BMP\\BMP\\CHEMITO.BMP";

			objclsPrintDocument.ReportFormat = objstructReportFormatIn;
			//objclsPrintDocument.PageHeader = strPageHeaderIn
			objclsPrintDocument.PageHeader = strPageHeaderIn;
			objclsPrintDocument.PageText = strPageTextIn;
			objclsPrintDocument.DisplayFont = this.DefaultFont;
			objclsPrintDocument.TableHeaderFont = FontStyles;
			objclsPrintDocument.ReportImageList = objDtImagesListIn;
			objclsPrintDocument.ReportType = intReportTypeIn;
			objclsPrintDocument.ReportLayoutType = clsPrintDocument.enumReportLayoutType.Portrate;

			//---Set Property ReportDataTables
			if (IsNothing(arrDtTablesListIn) == false) {
				objclsPrintDocument.ReportDataTables = new ArrayList();
				for (intCount = 0; intCount <= arrDtTablesListIn.Count - 1; intCount++) {
					objDtTable2In = arrDtTablesListIn.Item(intCount);
					if (IsNothing(objDtTable2In) == false) {
						objclsPrintDocument.ReportDataTables.Add(objDtTable2In);
					}
				}
			}

			//---Set Property ReportGraphControls
			if (IsNothing(arrGraphControlsListIn) == false) {
				objclsPrintDocument.ReportGraphControls = new ArrayList();
				for (intCount = 0; intCount <= arrGraphControlsListIn.Count - 1; intCount++) {
					if (IsNothing(arrGraphControlsListIn.Item(intCount)) == false) {
						objclsPrintDocument.ReportGraphControls.Add(arrGraphControlsListIn.Item(intCount));
					}
				}
			}

			return objclsPrintDocument;

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			return null;
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			if (!IsNothing(objclsPrintDocument) == true) {
				objclsPrintDocument.Dispose();
			}
			//---------------------------------------------------------
		}

	}



	private void  // ERROR: Handles clauses are not supported in C#
DataGrid1_Navigate(System.Object sender, System.Windows.Forms.NavigateEventArgs ne)
	{
	}

	private void  // ERROR: Handles clauses are not supported in C#
cmdDataset_Click(System.Object sender, System.EventArgs e)
	{
		DataSet1 DataSet_1 = new DataSet1();
		OleDbDataAdapter DataAdp = new OleDbDataAdapter();

		try {

			DataSet11 = new AAS203.DataSet1();
			//'Fill the dataset with the data retrieved.  The name of the table
			//'in the dataset must be the same as the table name in the report.
			OleDbDataAdapter1.Fill(DataSet11, "StdSampInfo");
			DataGrid1.SetDataBinding(DataSet11, "StdSampInfo");
			DataGrid1.Refresh();

		} catch (Exception ex) {
		}
	}
}
