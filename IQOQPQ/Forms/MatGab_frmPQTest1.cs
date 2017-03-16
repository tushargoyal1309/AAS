using System.Data;
using System.Data.OleDb;
using System.Windows.Forms.DataGridColumnStyle;

public class frmPQTest1 : System.Windows.Forms.Form
{

	#Region " Module level Declarations "
	//Private mblnModeLockStatus As Boolean
	//Private mstrOledbConnectionString As String
	//Private mobjOleDBconnection As OleDbConnection
	//Private mclsDBFunctions As New clsDatabaseFunctions

	//Private mobjDataTable, mobjTestDataTable As DataTable
	//Dim mobjGridTableStyle, mobjTestGridTableStyle As New DataGridTableStyle

	//Private Const CONST_TestEndID = 5
	//Private Const CONST_TestStartID = 1
	private ComboBox mobjCmbBox;

	private const  CONST_ConfirmColumnNo = 2;
	//29.6.2010 by dinesh wagh
	//------------------------------------
	bool mblnAvoidProcessing;
	int mintRowIndex;
	int mintColumnIndex;
	//-------------------------------------




	#End Region

	#Region " Windows Form Designer generated code "

	public frmPQTest1()
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
	internal System.Windows.Forms.Label lblHeader1;
	internal System.Windows.Forms.Label lblHeader2;
	internal System.Windows.Forms.Label lblHeader3;
	internal System.Windows.Forms.Panel Panel1;
	internal System.Windows.Forms.DataGrid dgTest;
	internal System.Windows.Forms.Label lblTestingProcedure;
	internal System.Windows.Forms.Panel Panel2;
	internal System.Windows.Forms.PictureBox PictureBox1;
	internal System.Windows.Forms.Label Label1;
	internal System.Windows.Forms.Label lblppm;
	internal System.Windows.Forms.Label lblStdSolution;
	internal System.Windows.Forms.Label lblUserDefinedLamp;
	[System.Diagnostics.DebuggerStepThrough()]
	private void InitializeComponent()
	{
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmPQTest1));
		this.lblHeader3 = new System.Windows.Forms.Label();
		this.lblHeader2 = new System.Windows.Forms.Label();
		this.lblHeader1 = new System.Windows.Forms.Label();
		this.Panel1 = new System.Windows.Forms.Panel();
		this.lblppm = new System.Windows.Forms.Label();
		this.lblStdSolution = new System.Windows.Forms.Label();
		this.lblUserDefinedLamp = new System.Windows.Forms.Label();
		this.Label1 = new System.Windows.Forms.Label();
		this.Panel2 = new System.Windows.Forms.Panel();
		this.PictureBox1 = new System.Windows.Forms.PictureBox();
		this.lblTestingProcedure = new System.Windows.Forms.Label();
		this.dgTest = new System.Windows.Forms.DataGrid();
		this.Panel1.SuspendLayout();
		this.Panel2.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.dgTest).BeginInit();
		this.SuspendLayout();
		//
		//lblHeader3
		//
		this.lblHeader3.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblHeader3.ForeColor = System.Drawing.SystemColors.ControlText;
		this.lblHeader3.Location = new System.Drawing.Point(8, 240);
		this.lblHeader3.Name = "lblHeader3";
		this.lblHeader3.Size = new System.Drawing.Size(520, 35);
		this.lblHeader3.TabIndex = 9;
		this.lblHeader3.Text = "Performance testing data sheet shall be generated as per the requirement of respe" + "ctive instrument / equipment are attached herewith for above tests.";
		//
		//lblHeader2
		//
		this.lblHeader2.BackColor = System.Drawing.Color.AliceBlue;
		this.lblHeader2.Font = new System.Drawing.Font("Arial", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblHeader2.ForeColor = System.Drawing.SystemColors.ControlText;
		this.lblHeader2.Location = new System.Drawing.Point(8, 208);
		this.lblHeader2.Name = "lblHeader2";
		this.lblHeader2.Size = new System.Drawing.Size(368, 26);
		this.lblHeader2.TabIndex = 8;
		this.lblHeader2.Text = "PERFORMANCE TESTING PROCEDURE ";
		this.lblHeader2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//lblHeader1
		//
		this.lblHeader1.BackColor = System.Drawing.Color.AliceBlue;
		this.lblHeader1.Font = new System.Drawing.Font("Arial", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblHeader1.ForeColor = System.Drawing.SystemColors.ControlText;
		this.lblHeader1.Location = new System.Drawing.Point(35, 7);
		this.lblHeader1.Name = "lblHeader1";
		this.lblHeader1.Size = new System.Drawing.Size(557, 18);
		this.lblHeader1.TabIndex = 7;
		this.lblHeader1.Text = "E.II PERFORMANCE TESTING AND QUALIFICATION";
		this.lblHeader1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//Panel1
		//
		this.Panel1.BackColor = System.Drawing.Color.AliceBlue;
		this.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.Panel1.Controls.Add(this.lblppm);
		this.Panel1.Controls.Add(this.lblStdSolution);
		this.Panel1.Controls.Add(this.lblUserDefinedLamp);
		this.Panel1.Controls.Add(this.Label1);
		this.Panel1.Controls.Add(this.Panel2);
		this.Panel1.Controls.Add(this.lblTestingProcedure);
		this.Panel1.Controls.Add(this.dgTest);
		this.Panel1.Controls.Add(this.lblHeader2);
		this.Panel1.Controls.Add(this.lblHeader3);
		this.Panel1.Dock = System.Windows.Forms.DockStyle.Top;
		this.Panel1.Location = new System.Drawing.Point(0, 0);
		this.Panel1.Name = "Panel1";
		this.Panel1.Size = new System.Drawing.Size(736, 440);
		this.Panel1.TabIndex = 12;
		//
		//lblppm
		//
		this.lblppm.Location = new System.Drawing.Point(413, 40);
		this.lblppm.Name = "lblppm";
		this.lblppm.Size = new System.Drawing.Size(40, 16);
		this.lblppm.TabIndex = 24;
		this.lblppm.Text = "ppm";
		//
		//lblStdSolution
		//
		this.lblStdSolution.Location = new System.Drawing.Point(240, 40);
		this.lblStdSolution.Name = "lblStdSolution";
		this.lblStdSolution.Size = new System.Drawing.Size(120, 24);
		this.lblStdSolution.TabIndex = 23;
		this.lblStdSolution.Text = "Standard solution :";
		//
		//lblUserDefinedLamp
		//
		this.lblUserDefinedLamp.Location = new System.Drawing.Point(8, 40);
		this.lblUserDefinedLamp.Name = "lblUserDefinedLamp";
		this.lblUserDefinedLamp.Size = new System.Drawing.Size(152, 24);
		this.lblUserDefinedLamp.TabIndex = 22;
		this.lblUserDefinedLamp.Text = "Using user defined lamp :";
		//
		//Label1
		//
		this.Label1.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.Label1.Location = new System.Drawing.Point(8, 280);
		this.Label1.Name = "Label1";
		this.Label1.Size = new System.Drawing.Size(520, 18);
		this.Label1.TabIndex = 21;
		this.Label1.Text = "The Data sheet covers following points:";
		//
		//Panel2
		//
		this.Panel2.BackColor = System.Drawing.Color.AliceBlue;
		this.Panel2.Controls.Add(this.PictureBox1);
		this.Panel2.Controls.Add(this.lblHeader1);
		this.Panel2.Dock = System.Windows.Forms.DockStyle.Top;
		this.Panel2.Location = new System.Drawing.Point(0, 0);
		this.Panel2.Name = "Panel2";
		this.Panel2.Size = new System.Drawing.Size(734, 32);
		this.Panel2.TabIndex = 20;
		//
		//PictureBox1
		//
		this.PictureBox1.Image = (System.Drawing.Image)resources.GetObject("PictureBox1.Image");
		this.PictureBox1.Location = new System.Drawing.Point(0, 0);
		this.PictureBox1.Name = "PictureBox1";
		this.PictureBox1.Size = new System.Drawing.Size(32, 32);
		this.PictureBox1.TabIndex = 0;
		this.PictureBox1.TabStop = false;
		//
		//lblTestingProcedure
		//
		this.lblTestingProcedure.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblTestingProcedure.Location = new System.Drawing.Point(8, 304);
		this.lblTestingProcedure.Name = "lblTestingProcedure";
		this.lblTestingProcedure.Size = new System.Drawing.Size(528, 108);
		this.lblTestingProcedure.TabIndex = 19;
		this.lblTestingProcedure.Text = "Label1";
		//
		//dgTest
		//
		this.dgTest.BackgroundColor = System.Drawing.Color.AliceBlue;
		this.dgTest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.dgTest.CaptionVisible = false;
		this.dgTest.DataMember = "";
		this.dgTest.HeaderForeColor = System.Drawing.SystemColors.ControlText;
		this.dgTest.Location = new System.Drawing.Point(8, 68);
		this.dgTest.Name = "dgTest";
		this.dgTest.ParentRowsVisible = false;
		this.dgTest.ReadOnly = true;
		this.dgTest.RowHeadersVisible = false;
		this.dgTest.Size = new System.Drawing.Size(720, 128);
		this.dgTest.TabIndex = 18;
		//
		//frmPQTest1
		//
		this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
		this.AutoScroll = true;
		this.BackColor = System.Drawing.Color.AliceBlue;
		this.ClientSize = new System.Drawing.Size(736, 440);
		this.ControlBox = false;
		this.Controls.Add(this.Panel1);
		this.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		this.MaximizeBox = false;
		this.MinimizeBox = false;
		this.Name = "frmPQTest1";
		this.Text = "PERFORMANCE QUALIFICATION TEST";
		this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
		this.Panel1.ResumeLayout(false);
		this.Panel2.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.dgTest).EndInit();
		this.ResumeLayout(false);

	}

	#End Region

	#Region "Constants"
	private const string ConstTestName = "TestName";
	private const string ConstPurpose = "Purpose";
	private const string ConstConformity = "Conformity";
	private const string ConstComments = "Comments";

	private const string ConstTestID = "TestID";
	#End Region

	#Region " Form Events "
	private void  // ERROR: Handles clauses are not supported in C#
frmPQTest1_Load(object sender, System.EventArgs e)
	{
		try {
			//--- Initialize the screen
			funcInitialize();
		} catch (Exception ex) {
		} finally {
			//---------------------------------------------------------
			//--- Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			//---------------------------------------------------------
		}
	}

	private void  // ERROR: Handles clauses are not supported in C#
frmPQTest1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
	{
		try {
			if (!gobjDataAccess.funcCheckModeLocked(ENUM_IQOQPQ_STATUS.PQ)) {
				dgTest.CurrentCell() = new DataGridCell(dgTest.CurrentRowIndex + 1, 0);
				if (!funcSavePQTest1Data()) {
					throw new Exception("Error in Saving Test Data.");
				}
				dgTest.TableStyles.Clear();
			}
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.ProcessError(ErrorHandler.ErrorHandler.EnumErrorType.Critical, ex);
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//--- Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			//---------------------------------------------------------
		}

	}
	#End Region

	#Region " General Private functions "

	//--------------------------------------------------------
	//    General functions used for IQ Tests Listing.
	//--- funcInitialize - To Initialize form and to get values for PQ Tests List from database and display them.
	//--- funcGetPQTest1Records - To Get PQ Test Records from Database and display them.
	//--- funcGetPQTest1Details - To Get PQ Test Records from Database for the given ID.
	//--- funcAssignValuesToControls - To Assign values to controls on form. 
	//--- funcSavePQTest1Data - To Save the Entered Records into Database.
	//--- funcGetObservationFromControls - To Get values from text box controls on form. 
	//--- funcGetDemoDateFromControls - To Get values from Date Time Picker controls on form. 
	//--- funcGetVerifiedDateFromControls - To Get values from Date Time Picker controls on form. 
	//--- funcInsertPQTest1Data - To Add/Insert New Test Data in Database.
	//--- funcUpdatePQTest1Data - To Update PQ Test Data in Database.
	//--- funcDeletePQTest1Data - To Delete PQ Test Data from Database.
	//--- subCreateDataTable - To Create Columns in the Data Table.
	//--- subFormatDataGrid - To format the Data Grid Display Testing Procedure.

	private void funcInitialize()
	{
		//=====================================================================
		// Procedure Name        :   funcInitailize
		// Description           :   To Initialize form and to get values for PQ Tests List from database and display them.
		// Purpose               :   To Initialize form and to get values for PQ Tests List from database and display them.
		// Parameters Passed     :   None.
		// Returns               :   None.
		// Parameters Affected   :   None.
		// Assumptions           :
		// Dependencies          :
		// Author                :   Gitesh
		// Created               :   January, 2003 
		// Revisions             :
		//=====================================================================


		try {
			mobjCmbBox = new ComboBox();
			mobjCmbBox.SelectedIndexChanged += CmbBox_SelectedIndexChanged;
			dgTest.Controls.Add(mobjCmbBox);
			mobjCmbBox.Visible = false;
			mobjCmbBox.BackColor = Color.AliceBlue;
			mobjCmbBox.DropDownStyle = ComboBoxStyle.DropDownList;
			//changed by sns on 21oct2004
			//mobjCmbBox.Items.Add("True")
			//mobjCmbBox.Items.Add("False")
			mobjCmbBox.Items.Add("YES");
			mobjCmbBox.Items.Add("NO");
			mobjCmbBox.Items.Add("N/A");

			//--- Display all the test information for their comformity
			funcDisplayPQTestConformity();
			subDisplayTestingProcedure();

			if (gobjDataAccess.funcCheckModeLocked(ENUM_IQOQPQ_STATUS.PQ)) {
				dgTest.ReadOnly = true;


			} else {
				dgTest.ReadOnly = false;
				mobjCmbBox.Enabled = true;
				//by Pankaj 06.12.07
			}


			//code added by:dinesh wgah on 1.2.2010
			//Purpose : To remove the label as it is not giving any 
			//Proper information.
			//--------------------------------------
			lblppm.Visible = false;
			lblStdSolution.Visible = false;
			lblUserDefinedLamp.Visible = false;
		//--------------------------------------


		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.ProcessError(ErrorHandler.ErrorHandler.EnumErrorType.Critical, ex);
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//--- Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			//---------------------------------------------------------
		}
	}

	private void CmbBox_SelectedIndexChanged(System.Object sender, System.EventArgs e)
	{
		dgTest(dgTest.CurrentCell.RowNumber, dgTest.CurrentCell.ColumnNumber) = mobjCmbBox.Text;
	}


	private bool funcDisplayPQTestConformity()
	{
		//Dim objReader As OleDbDataReader
		DataTable objDataTable;
		DataTable mobjTmpDt;
		DataRow objDataRow;
		int intCount;
		//Dim str_sql As String
		//Dim reader_status, record_exists As Boolean

		try {
			objDataTable = new DataTable("PQTest1");

			objDataTable.Columns.Add(new DataColumn("TestName", typeof(string)));
			objDataTable.Columns.Add(new DataColumn("Purpose", typeof(string)));
			objDataTable.Columns.Add(new DataColumn("Conformity", typeof(string)));
			objDataTable.Columns.Add(new DataColumn("Comments", typeof(string)));
			objDataTable.Columns.Add(new DataColumn("TestID", typeof(int)));

			mobjTmpDt = new DataTable();
			mobjTmpDt = gobjDataAccess.funcGetPQConfirmityRecords();

			if (!mobjTmpDt == null) {
				if (!mobjTmpDt.Rows.Count == 0) {
					for (intCount = 0; intCount <= mobjTmpDt.Rows.Count - 1; intCount++) {
						objDataRow = objDataTable.NewRow;
						//objDataRow.Item(ConstTestName) = CStr(mobjTmpDt.Rows.Item(intCount).Item("PQTestName")) '2.4.2010 by dinesh wagh
						objDataRow.Item(ConstTestName) = gfuncWordWrap((string)mobjTmpDt.Rows.Item(intCount).Item("PQTestName"), 50);
						//2.4.2010 by dinesh wagh
						//objDataRow.Item(ConstPurpose) = CStr(mobjTmpDt.Rows.Item(intCount).Item("PQPurpose")) '2.4.2010 by dinesh wagh
						objDataRow.Item(ConstPurpose) = gfuncWordWrap((string)mobjTmpDt.Rows.Item(intCount).Item("PQPurpose"), 40);
						//2.4.2010 by dinesh wagh
						objDataRow.Item(ConstConformity) = (mobjTmpDt.Rows.Item(intCount).Item("PQConformity"));
						//objDataRow.Item(ConstComments) = (mobjTmpDt.Rows.Item(intCount).Item("PQComments")) '2.4.2010 by dinesh wagh
						objDataRow.Item(ConstComments) = gfuncWordWrap((mobjTmpDt.Rows.Item(intCount).Item("PQComments")), 30);
						//2.4.2010 by dinesh wagh

						objDataRow.Item(ConstTestID) = (int)mobjTmpDt.Rows.Item(intCount).Item("PQTestID");
						objDataTable.Rows.Add(objDataRow);
					}
				}
			}

			if (IsNothing(objDataTable) == true) {
				throw new Exception("Error in Getting Equipment List Records.");

			} else {
				subFormatDataGrid(objDataTable);
			}


			//str_sql = "Select Distinct ValidationTestID, PQTestName, PQPurpose, PQConformity, PQComments " & _
			//            "From PQTest1 " & _
			//            "Group by ValidationTestID, PQTestName, PQPurpose, PQConformity, PQComments "

			//If Not gclsDBFunctions.GetRecords(str_sql, gOleDBIQOQPQConnection, objReader) Then
			//    Return True
			//End If

			//While objReader.Read
			//    objDataRow = objDataTable.NewRow()

			//    If IsDBNull(objReader.Item("PQTestName")) = False Then
			//        objDataRow("TestName") = CStr(objReader.Item("PQTestName"))
			//    End If
			//    If IsDBNull(objReader.Item("PQPurpose")) = False Then
			//        objDataRow("Purpose") = CStr(objReader.Item("PQPurpose"))
			//    End If
			//    objDataRow("Conformity") = CStr(objReader.Item("PQConformity"))

			//    If IsDBNull(objReader.Item("PQComments")) = False Then
			//        objDataRow("Comments") = CStr(objReader.Item("PQComments"))
			//    Else
			//        objDataRow("Comments") = " "
			//    End If
			//    objDataRow("TestID") = Val(objReader.Item("ValidationTestID") & "")

			//    objDataTable.Rows.Add(objDataRow)
			//End While

			//objReader.Close()

			//--- Display the data in the grid
			//Call subFormatDataGrid(objDataTable)

			if (gobjDataAccess.funcCheckModeLocked(ENUM_IQOQPQ_STATUS.PQ)) {
				mobjCmbBox.Width = 0;
				//by Pankaj 06.12.07
				mobjCmbBox.Enabled = false;
				//by Pankaj 06.12.07
				dgTest.ReadOnly = true;
			} else {
				mobjCmbBox.Enabled = true;
				//by Pankaj 06.12.07
				dgTest.ReadOnly = false;
			}

			return true;
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.ProcessError(ErrorHandler.ErrorHandler.EnumErrorType.Critical, ex);
			//---------------------------------------------------------
			return false;
		} finally {
			//---------------------------------------------------------
			//--- Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			//---------------------------------------------------------
		}
	}

	private void subFormatDataGrid(ref DataTable objDataTable)
	{
		DataGridTextBoxColumn objTextColumn;
		DataGridBoolColumn objBoolColumn;
		DataView objDataView = new DataView();
		DataGridTableStyle objTestGridTableStyle = new DataGridTableStyle();

		try {
			dgTest.TableStyles.Clear();
			objDataView.Table = objDataTable;
			objDataView.AllowNew = false;
			dgTest.DataSource = objDataView;

			objTestGridTableStyle.PreferredRowHeight = 34;
			//2.4.2010 by dinesh wagh

			objTestGridTableStyle.RowHeadersVisible = false;
			objTestGridTableStyle.ResetAlternatingBackColor();
			objTestGridTableStyle.ResetBackColor();
			objTestGridTableStyle.ResetForeColor();
			objTestGridTableStyle.ResetGridLineColor();
			objTestGridTableStyle.BackColor = Color.AliceBlue;
			objTestGridTableStyle.GridLineColor = Color.Black;
			objTestGridTableStyle.HeaderBackColor = Color.FromArgb(205, 225, 250);
			objTestGridTableStyle.HeaderForeColor = Color.Black;
			objTestGridTableStyle.AlternatingBackColor = Color.AliceBlue;
			objTestGridTableStyle.AllowSorting = false;

			objTestGridTableStyle.MappingName = "PQTest1";

			objTextColumn = new DataGridTextBoxColumn();
			objTextColumn.TextBox.WordWrap = true;
			//2.4.2010 by dinesh wagh
			objTextColumn.MappingName = "TestName";
			objTextColumn.HeaderText = "Performance Test";
			objTextColumn.Width = 300;
			//180 '2.4.2010 by dinesh wagh
			objTextColumn.ReadOnly = true;
			objTextColumn.NullText = "";
			objTestGridTableStyle.GridColumnStyles.Add(objTextColumn);

			objTextColumn = new DataGridTextBoxColumn();
			objTextColumn.TextBox.WordWrap = true;
			//2.4.2010 by dinesh wagh
			objTextColumn.MappingName = "Purpose";
			objTextColumn.HeaderText = "Purpose";
			objTextColumn.Width = 185;
			//170 '2.4.2010 by dinesh wagh
			objTextColumn.ReadOnly = true;
			objTextColumn.NullText = "";
			objTestGridTableStyle.GridColumnStyles.Add(objTextColumn);

			objTextColumn = new DataGridTextBoxColumn();
			objTextColumn.TextBox.WordWrap = true;
			//2.4.2010 by dinesh wagh
			objTextColumn.MappingName = "Conformity";
			objTextColumn.HeaderText = "Conformity";
			objTextColumn.Width = 70;
			//68 '2.4.2010 by dinesh wagh
			objTextColumn.ReadOnly = false;
			objTextColumn.NullText = "";
			objTextColumn.Alignment = HorizontalAlignment.Center;
			objTestGridTableStyle.GridColumnStyles.Add(objTextColumn);

			objTextColumn = new DataGridTextBoxColumn();
			objTextColumn.TextBox.WordWrap = true;
			//2.4.2010 by dinesh wagh
			objTextColumn.MappingName = "Comments";
			objTextColumn.HeaderText = "Comments";
			objTextColumn.Width = 160;
			objTextColumn.ReadOnly = false;
			objTextColumn.NullText = "";
			objTextColumn.Alignment = HorizontalAlignment.Center;
			objTestGridTableStyle.GridColumnStyles.Add(objTextColumn);

			objTextColumn = new DataGridTextBoxColumn();
			objTextColumn.TextBox.WordWrap = true;
			//2.4.2010 by dinesh wagh
			objTextColumn.MappingName = "TestID";
			objTextColumn.HeaderText = "TestID";
			objTextColumn.Width = 0;
			objTextColumn.ReadOnly = true;
			objTextColumn.NullText = "";
			objTestGridTableStyle.GridColumnStyles.Add(objTextColumn);

			objTestGridTableStyle.GridLineColor = Color.Black;
			dgTest.TableStyles.Add(objTestGridTableStyle);

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = "Error in Formating Test Data-Grid.";
			gobjErrorHandler.WriteErrorLog(ex);
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//--- Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			//---------------------------------------------------------
		}
	}

	public bool funcSavePQTest1Data()
	{
		//=====================================================================
		// Procedure Name        :   funcSavePQTest1Data
		// Description           :   To Save the Entered Records into Database.
		// Purpose               :   To Save the Entered Records into Database.
		// Parameters Passed     :   None.
		// Returns               :   None.
		// Parameters Affected   :   None.
		// Assumptions           :
		// Dependencies          :
		// Author                :   Gitesh
		// Created               :   January, 2003 
		// Revisions             :
		//=====================================================================
		int intCounter;
		DataView objDataView = new DataView();
		string strComment;
		//25.6.2010 by dinesh wagh

		try {
			objDataView = dgTest.DataSource;

			for (intCounter = 0; intCounter <= objDataView.Table.Rows.Count - 1; intCounter++) {
				if (IsDBNull(objDataView.Table.Rows(intCounter).Item("Comments")) == true) {
					objDataView.Table.Rows(intCounter).Item("Comments") = " ";
				}
				if (IsDBNull(objDataView.Table.Rows(intCounter).Item("Conformity")) == true) {
					objDataView.Table.Rows(intCounter).Item("Conformity") = " ";
				}


				//code added by ; dinesh wagh on 25.6.2010 
				//--------------
				strComment = objDataView.Table.Rows(intCounter).Item("Comments");
				strComment = strComment.Replace(vbCrLf, " ");
				//--------------------


				if (!gobjDataAccess.funcUpdatePQTestData(objDataView.Table.Rows(intCounter).Item("Conformity"), strComment, (int)objDataView.Table.Rows(intCounter).Item("TestID"))) {
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			return true;
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = "Error in Saving Test Details.";
			gobjErrorHandler.WriteErrorLog(ex);
			//---------------------------------------------------------
			return false;
		} finally {
			//---------------------------------------------------------
			//--- Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			//---------------------------------------------------------
		}

	}

	private bool funcUpdatePQTest1Data(int intTestID, string strComments, string strConformity)
	{
		//=====================================================================
		// Procedure Name        :   funcUpdatePQTest1Data
		// Description           :   To Update Test Data in Database.
		// Purpose               :   To Update Test Data in Database.
		// Parameters Passed     :   None.
		// Returns               :   None.
		// Parameters Affected   :   None.
		// Assumptions           :
		// Dependencies          :
		// Author                :   Gitesh
		// Created               :   January, 2003 
		// Revisions             :
		//=====================================================================
		string str_sql;
		OleDbCommand objCommand = new OleDbCommand();

		try {
			//---  Query to Update Data
			str_sql = " Update PQTest1 set " + " PQConformity = ? , PQComments = ? " + " where ValidationTestID = " + intTestID + " ";

			//--- Providing command object 
				//.Connection = gOleDBIQOQPQConnection
			 // ERROR: Not supported in C#: WithStatement

			objCommand.Dispose();

			return true;
		} catch (Exception ex) {
			//---------------------------------------------------------
			//--- Error logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = "Error in Updating Test Details.";
			gobjErrorHandler.WriteErrorLog(ex);
			return false;
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//--- Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			//---------------------------------------------------------
		}
	}

	private void subDisplayTestingProcedure()
	{
		//=====================================================================
		// Procedure Name        :   subCreateDataTable
		// Description           :   To Create Columns in the Data Table.
		// Purpose               :   To Create Columns in the Data Table.
		// Parameters Passed     :   None.
		// Returns               :   None.
		// Parameters Affected   :   None.
		// Assumptions           :
		// Dependencies          :
		// Author                :   Gitesh
		// Created               :   January, 2003 
		// Revisions             :
		//=====================================================================
		string strText;


		try {
			strText = "1. Equipment / Instrument" + vbCrLf + "2. Test Name" + vbCrLf + "3. Purpose" + vbCrLf + "4. Method" + vbCrLf + "5. Acceptance Criteria" + vbCrLf + "6. Observation" + vbCrLf + "7. Test Results";
			//Test Result removed on 23.3.2010 by dinesh wagh

			lblTestingProcedure.Text = strText;

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = "Error in Creating Test Procedure Data-Table.";
			gobjErrorHandler.WriteErrorLog(ex);
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//--- Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			//---------------------------------------------------------
		}
	}

	#End Region

	private void  // ERROR: Handles clauses are not supported in C#
dgTest_CurrentCellChanged(object sender, System.EventArgs e)
	{
		//try catch added by : dinesh wagh on 3.2.2010
		//code added by : dinesh wagh on 27.6.2010
		//-----------------------------------------------
		if (mblnAvoidProcessing == true)
			return;
		int intRowIndex;
		int intColumnIndex;
		string strString;
		//-------------------------------------

		try {
			if (!gobjDataAccess.funcCheckModeLocked(ENUM_IQOQPQ_STATUS.PQ)) {
				if ((dgTest.CurrentCell.ColumnNumber == CONST_ConfirmColumnNo)) {
					mobjCmbBox.Top = dgTest.GetCurrentCellBounds().Top;
					mobjCmbBox.Left = dgTest.GetCurrentCellBounds().Left;
					mobjCmbBox.Width = dgTest.GetCurrentCellBounds().Width;
					mobjCmbBox.Height = dgTest.GetCurrentCellBounds().Height;
					if ((dgTest.CurrentCell.RowNumber) > 0) {
						if (IsDBNull(dgTest(dgTest.CurrentCell.RowNumber, dgTest.CurrentCell.ColumnNumber)) == false) {
							object strval = dgTest(dgTest.CurrentCell.RowNumber, dgTest.CurrentCell.ColumnNumber);
							//If (strval = "TRUE") Then
							if ((strval == "YES")) {
								mobjCmbBox.SelectedIndex = 0;
							} else {
								mobjCmbBox.SelectedIndex = 1;
							}
						} else {
							mobjCmbBox.SelectedIndex = 0;
						}
					}
					mobjCmbBox.Visible = true;
				} else {
					mobjCmbBox.Width = 0;
					mobjCmbBox.Visible = false;
				}
			}


			//code added by : dinesh wagh on 27.6.2010
			//---------------------------------------------------------------------------

			intRowIndex = dgTest.CurrentCell.RowNumber;
			intColumnIndex = dgTest.CurrentCell.ColumnNumber;


			mblnAvoidProcessing = true;

			if (!IsDBNull(dgTest.Item(mintRowIndex, mintColumnIndex))) {
				if (mintColumnIndex == 3) {
					strString = dgTest.Item(mintRowIndex, mintColumnIndex);
					if (!(strString == "")) {
						strString = strString.Replace(vbCrLf, " ");
						dgTest.Item(mintRowIndex, mintColumnIndex) = gfuncWordWrap(strString, 28);
					}
				}
			}

			dgTest.CurrentCell = new DataGridCell(intRowIndex, intColumnIndex);

			mintRowIndex = dgTest.CurrentCell.RowNumber;
			mintColumnIndex = dgTest.CurrentCell.ColumnNumber;

			mblnAvoidProcessing = false;
		//------------------------------------------------------------------------
		} catch (Exception ex) {
			mblnAvoidProcessing = false;
			//30.6.2010 by dinesh wagh
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
		} finally {
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
		}
	}
}
