using System.Data;
using System.Data.OleDb;
using System.Windows.Forms.DataGridColumnStyle;

public class frmPQTest2 : System.Windows.Forms.Form
{

	#Region " Module level Declarations "
	//Private mstrOledbConnectionString As String
	//Private mobjOleDBconnection As OleDbConnection
	//Private gclsDBFunctions As New clsDatabaseFunctions
	private DataTable objDataTable = new DataTable();
	//====Saurabh====
	private bool mblnModeLockStatus;
	private DataView mobjDataView = new DataView();
	//Private mObjDataTable As DataTable
	DateTimePicker mdtpPQTest1Date;
	private const  CONST_DateColumnNo = 9;
	public event  Test_IQOQPQ_Attachment1;
	//Saurabh  04.07.07
	private int intCounter = 0;
	//====Saurabh====

	#End Region

	#Region " Windows Form Designer generated code "

	public frmPQTest2()
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
	internal System.Windows.Forms.Label lblAttachment;
	internal System.Windows.Forms.Label lblTestName;
	internal System.Windows.Forms.Label lblMethod;
	internal System.Windows.Forms.Label lblPurpose;
	internal System.Windows.Forms.Label lblTestResults;
	internal System.Windows.Forms.Panel Panel1;
	internal System.Windows.Forms.DataGrid dgMethod;
	internal System.Windows.Forms.DataGrid dgTest;
	internal System.Windows.Forms.Label lblAcceptanceCriteria;
	internal System.Windows.Forms.Label lblSpecifiedBaselineResult;
	internal System.Windows.Forms.DataGridTableStyle DataGridTableStyle1;
	internal System.Windows.Forms.DataGridTextBoxColumn DataGridTextBoxColumn1;
	internal System.Windows.Forms.Panel Panel2;
	internal System.Windows.Forms.PictureBox PictureBox1;
	internal System.Windows.Forms.Label Label1;
	internal System.Windows.Forms.Label lblModelNo;
	internal NETXP.Controls.XPButton btnTest;
	[System.Diagnostics.DebuggerStepThrough()]
	private void InitializeComponent()
	{
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmPQTest2));
		this.lblTestResults = new System.Windows.Forms.Label();
		this.lblAttachment = new System.Windows.Forms.Label();
		this.lblMethod = new System.Windows.Forms.Label();
		this.lblPurpose = new System.Windows.Forms.Label();
		this.lblTestName = new System.Windows.Forms.Label();
		this.lblAcceptanceCriteria = new System.Windows.Forms.Label();
		this.lblHeader1 = new System.Windows.Forms.Label();
		this.Panel1 = new System.Windows.Forms.Panel();
		this.btnTest = new NETXP.Controls.XPButton();
		this.lblModelNo = new System.Windows.Forms.Label();
		this.Label1 = new System.Windows.Forms.Label();
		this.Panel2 = new System.Windows.Forms.Panel();
		this.PictureBox1 = new System.Windows.Forms.PictureBox();
		this.lblSpecifiedBaselineResult = new System.Windows.Forms.Label();
		this.dgTest = new System.Windows.Forms.DataGrid();
		this.dgMethod = new System.Windows.Forms.DataGrid();
		this.DataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
		this.DataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
		this.Panel1.SuspendLayout();
		this.Panel2.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.dgTest).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dgMethod).BeginInit();
		this.SuspendLayout();
		//
		//lblTestResults
		//
		this.lblTestResults.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblTestResults.ForeColor = System.Drawing.SystemColors.ControlText;
		this.lblTestResults.Location = new System.Drawing.Point(8, 360);
		this.lblTestResults.Name = "lblTestResults";
		this.lblTestResults.Size = new System.Drawing.Size(120, 18);
		this.lblTestResults.TabIndex = 18;
		this.lblTestResults.Text = "Test Results  :";
		//
		//lblAttachment
		//
		this.lblAttachment.BackColor = System.Drawing.Color.AliceBlue;
		this.lblAttachment.Font = new System.Drawing.Font("Times New Roman", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblAttachment.ForeColor = System.Drawing.SystemColors.ControlText;
		this.lblAttachment.Location = new System.Drawing.Point(480, 40);
		this.lblAttachment.Name = "lblAttachment";
		this.lblAttachment.Size = new System.Drawing.Size(104, 20);
		this.lblAttachment.TabIndex = 17;
		this.lblAttachment.Text = "Attachment I";
		//
		//lblMethod
		//
		this.lblMethod.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblMethod.ForeColor = System.Drawing.SystemColors.ControlText;
		this.lblMethod.Location = new System.Drawing.Point(8, 127);
		this.lblMethod.Name = "lblMethod";
		this.lblMethod.Size = new System.Drawing.Size(472, 18);
		this.lblMethod.TabIndex = 12;
		this.lblMethod.Text = "Method             :     Follow the steps given below after clicking on 'Test' bu" + "tton.";
		//
		//lblPurpose
		//
		this.lblPurpose.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblPurpose.ForeColor = System.Drawing.SystemColors.ControlText;
		this.lblPurpose.Location = new System.Drawing.Point(8, 103);
		this.lblPurpose.Name = "lblPurpose";
		this.lblPurpose.Size = new System.Drawing.Size(328, 18);
		this.lblPurpose.TabIndex = 11;
		this.lblPurpose.Text = "Purpose           :     To verify the system response.";
		//
		//lblTestName
		//
		this.lblTestName.AutoSize = true;
		this.lblTestName.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblTestName.ForeColor = System.Drawing.SystemColors.ControlText;
		this.lblTestName.Location = new System.Drawing.Point(8, 79);
		this.lblTestName.Name = "lblTestName";
		this.lblTestName.Size = new System.Drawing.Size(489, 17);
		this.lblTestName.TabIndex = 10;
		this.lblTestName.Text = "Test Name      :      Optimisation of AAS instrument with 5ppm Cu solution with A" + "A flame.";
		//
		//lblAcceptanceCriteria
		//
		this.lblAcceptanceCriteria.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblAcceptanceCriteria.ForeColor = System.Drawing.SystemColors.ControlText;
		this.lblAcceptanceCriteria.Location = new System.Drawing.Point(8, 328);
		this.lblAcceptanceCriteria.Name = "lblAcceptanceCriteria";
		this.lblAcceptanceCriteria.Size = new System.Drawing.Size(280, 16);
		this.lblAcceptanceCriteria.TabIndex = 8;
		this.lblAcceptanceCriteria.Text = "Acceptance Criteria  : 5ppm Copper solution :";
		//
		//lblHeader1
		//
		this.lblHeader1.BackColor = System.Drawing.Color.AliceBlue;
		this.lblHeader1.Font = new System.Drawing.Font("Arial", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblHeader1.ForeColor = System.Drawing.SystemColors.ControlText;
		this.lblHeader1.Location = new System.Drawing.Point(35, 7);
		this.lblHeader1.Name = "lblHeader1";
		this.lblHeader1.Size = new System.Drawing.Size(541, 18);
		this.lblHeader1.TabIndex = 7;
		this.lblHeader1.Text = "E.II PERFORMANCE TESTING AND QUALIFICATION";
		this.lblHeader1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//Panel1
		//
		this.Panel1.BackColor = System.Drawing.Color.AliceBlue;
		this.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.Panel1.Controls.Add(this.btnTest);
		this.Panel1.Controls.Add(this.lblModelNo);
		this.Panel1.Controls.Add(this.Label1);
		this.Panel1.Controls.Add(this.Panel2);
		this.Panel1.Controls.Add(this.lblSpecifiedBaselineResult);
		this.Panel1.Controls.Add(this.dgTest);
		this.Panel1.Controls.Add(this.dgMethod);
		this.Panel1.Controls.Add(this.lblAttachment);
		this.Panel1.Controls.Add(this.lblTestName);
		this.Panel1.Controls.Add(this.lblPurpose);
		this.Panel1.Controls.Add(this.lblMethod);
		this.Panel1.Controls.Add(this.lblAcceptanceCriteria);
		this.Panel1.Controls.Add(this.lblTestResults);
		this.Panel1.Dock = System.Windows.Forms.DockStyle.Top;
		this.Panel1.Location = new System.Drawing.Point(0, 0);
		this.Panel1.Name = "Panel1";
		this.Panel1.Size = new System.Drawing.Size(608, 510);
		this.Panel1.TabIndex = 12;
		//
		//btnTest
		//
		this.btnTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnTest.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnTest.Location = new System.Drawing.Point(264, 352);
		this.btnTest.Name = "btnTest";
		this.btnTest.Size = new System.Drawing.Size(104, 32);
		this.btnTest.TabIndex = 32;
		this.btnTest.Text = "Test";
		//
		//lblModelNo
		//
		this.lblModelNo.Font = new System.Drawing.Font("Times New Roman", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblModelNo.Location = new System.Drawing.Point(184, 40);
		this.lblModelNo.Name = "lblModelNo";
		this.lblModelNo.Size = new System.Drawing.Size(112, 24);
		this.lblModelNo.TabIndex = 31;
		//
		//Label1
		//
		this.Label1.Font = new System.Drawing.Font("Times New Roman", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.Label1.Location = new System.Drawing.Point(8, 40);
		this.Label1.Name = "Label1";
		this.Label1.Size = new System.Drawing.Size(192, 24);
		this.Label1.TabIndex = 29;
		this.Label1.Text = "Equipment / Instrument :";
		//
		//Panel2
		//
		this.Panel2.BackColor = System.Drawing.Color.AliceBlue;
		this.Panel2.Controls.Add(this.PictureBox1);
		this.Panel2.Controls.Add(this.lblHeader1);
		this.Panel2.Dock = System.Windows.Forms.DockStyle.Top;
		this.Panel2.Location = new System.Drawing.Point(0, 0);
		this.Panel2.Name = "Panel2";
		this.Panel2.Size = new System.Drawing.Size(606, 32);
		this.Panel2.TabIndex = 26;
		this.Panel2.TabStop = true;
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
		//lblSpecifiedBaselineResult
		//
		this.lblSpecifiedBaselineResult.AutoSize = true;
		this.lblSpecifiedBaselineResult.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblSpecifiedBaselineResult.ForeColor = System.Drawing.SystemColors.ControlText;
		this.lblSpecifiedBaselineResult.Location = new System.Drawing.Point(257, 328);
		this.lblSpecifiedBaselineResult.Name = "lblSpecifiedBaselineResult";
		this.lblSpecifiedBaselineResult.Size = new System.Drawing.Size(297, 16);
		this.lblSpecifiedBaselineResult.TabIndex = 25;
		this.lblSpecifiedBaselineResult.Text = "under optimized condition, it should produce Abs > 0.65";
		//
		//dgTest
		//
		this.dgTest.BackgroundColor = System.Drawing.Color.AliceBlue;
		this.dgTest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.dgTest.CaptionVisible = false;
		this.dgTest.DataMember = "";
		this.dgTest.HeaderForeColor = System.Drawing.SystemColors.ControlText;
		this.dgTest.Location = new System.Drawing.Point(8, 392);
		this.dgTest.Name = "dgTest";
		this.dgTest.ParentRowsVisible = false;
		this.dgTest.ReadOnly = true;
		this.dgTest.RowHeadersVisible = false;
		this.dgTest.Size = new System.Drawing.Size(568, 100);
		this.dgTest.TabIndex = 19;
		//
		//dgMethod
		//
		this.dgMethod.AllowNavigation = false;
		this.dgMethod.AllowSorting = false;
		this.dgMethod.AlternatingBackColor = System.Drawing.Color.AliceBlue;
		this.dgMethod.BackColor = System.Drawing.Color.AliceBlue;
		this.dgMethod.BackgroundColor = System.Drawing.Color.AliceBlue;
		this.dgMethod.BorderStyle = System.Windows.Forms.BorderStyle.None;
		this.dgMethod.CaptionVisible = false;
		this.dgMethod.ColumnHeadersVisible = false;
		this.dgMethod.DataMember = "";
		this.dgMethod.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
		this.dgMethod.HeaderForeColor = System.Drawing.SystemColors.ControlText;
		this.dgMethod.LinkColor = System.Drawing.Color.AliceBlue;
		this.dgMethod.Location = new System.Drawing.Point(8, 152);
		this.dgMethod.Name = "dgMethod";
		this.dgMethod.ParentRowsBackColor = System.Drawing.Color.AliceBlue;
		this.dgMethod.ParentRowsVisible = false;
		this.dgMethod.PreferredRowHeight = 14;
		this.dgMethod.ReadOnly = true;
		this.dgMethod.RowHeadersVisible = false;
		this.dgMethod.SelectionBackColor = System.Drawing.Color.AliceBlue;
		this.dgMethod.SelectionForeColor = System.Drawing.Color.AliceBlue;
		this.dgMethod.Size = new System.Drawing.Size(584, 168);
		this.dgMethod.TabIndex = 18;
		this.dgMethod.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] { this.DataGridTableStyle1 });
		//
		//DataGridTableStyle1
		//
		this.DataGridTableStyle1.AllowSorting = false;
		this.DataGridTableStyle1.AlternatingBackColor = System.Drawing.Color.AliceBlue;
		this.DataGridTableStyle1.BackColor = System.Drawing.Color.AliceBlue;
		this.DataGridTableStyle1.ColumnHeadersVisible = false;
		this.DataGridTableStyle1.DataGrid = this.dgMethod;
		this.DataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] { this.DataGridTextBoxColumn1 });
		this.DataGridTableStyle1.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
		this.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
		this.DataGridTableStyle1.MappingName = "";
		this.DataGridTableStyle1.PreferredColumnWidth = 535;
		this.DataGridTableStyle1.ReadOnly = true;
		this.DataGridTableStyle1.RowHeadersVisible = false;
		this.DataGridTableStyle1.SelectionBackColor = System.Drawing.Color.AliceBlue;
		this.DataGridTableStyle1.SelectionForeColor = System.Drawing.Color.AliceBlue;
		//
		//DataGridTextBoxColumn1
		//
		this.DataGridTextBoxColumn1.Format = "";
		this.DataGridTextBoxColumn1.FormatInfo = null;
		this.DataGridTextBoxColumn1.MappingName = "";
		this.DataGridTextBoxColumn1.ReadOnly = true;
		this.DataGridTextBoxColumn1.Width = 535;
		//
		//frmPQTest2
		//
		this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
		this.AutoScroll = true;
		this.BackColor = System.Drawing.Color.AliceBlue;
		this.ClientSize = new System.Drawing.Size(608, 424);
		this.ControlBox = false;
		this.Controls.Add(this.Panel1);
		this.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		this.MaximizeBox = false;
		this.MinimizeBox = false;
		this.Name = "frmPQTest2";
		this.Text = "PERFORMANCE QUALIFICATION TEST";
		this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
		this.Panel1.ResumeLayout(false);
		this.Panel2.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.dgTest).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dgMethod).EndInit();
		this.ResumeLayout(false);

	}

	#End Region

	#Region "Constants"
	private const string ConstFuel = "Fuel";
	private const string ConstSampleID = "SampleID";
	private const string ConstTestName = "TestName";
	private const string ConstWaveLength = "WaveLength";
	private const string ConstAbsorbance = "Absorbance";
	private const string ConstBurnerHeight = "BurnerHeight";
	private const string ConstLampCurrent = "LampCurrent";
	private const string ConstPMTVoltage = "PMTVoltage";
	private const string ConstSlitWidth = "SlitWidth";
	private const string ConstRemark = "Remark";

	private const string ConstDate = "Date";
	#End Region

	#Region " Form Events "

	private void  // ERROR: Handles clauses are not supported in C#
frmPQTest2_Load(object sender, System.EventArgs e)
	{
		try {
			//--- Initialize the UI
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
frmPQTest2_Closing(object sender, System.ComponentModel.CancelEventArgs e)
	{
		try {
			dgTest.CurrentCell() = (new DataGridCell(dgTest.CurrentRowIndex + 1, 0));
			if (!funcSavePQTest1Remarks()) {
				throw new Exception("Error in Saving Test Data.");
			}
			dgTest.TableStyles.Clear();

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

	private void cmdPerformTest_Click(System.Object sender, System.EventArgs e)
	{
		//--- Initialize the object
		//gobjValidationTest = New ValidationTestResults.ValidationTest

		//--- Perform the test and display the results on the screen
		//Call gsubPerfomTest(enumValidationTests.BaselineFlatnessTest)

		//'--- Save the result data in the database
		//Call funcUpdatePQTest1Data(enumValidationTests.BaselineFlatnessTest, _
		//                            gobjValidationTest.BaselineTest.Result, _
		//                            gobjValidationTest.BaselineTest.SpecifiedReading, "")

		//'--- Perform the test and display the results on the screen
		//Call gsubPerfomTest(enumValidationTests.NoiseTest)

		//'--- Save the result data in the database
		//Call funcUpdatePQTest1Data(enumValidationTests.NoiseTest, _
		//                            gobjValidationTest.NoiseTest.Result, _
		//                            gobjValidationTest.NoiseTest.SpecifiedReading, "")

		//--- Update the screen and results for the test.
		funcDisplayPQTest1();
	}

	#End Region

	#Region " General Private functions "

	//--------------------------------------------------------
	//    General functions used for IQ Tests Listing.
	//--- funcInitialize - To Initialize form and to get values for PQ Tests List from database and display them.
	//--- funcGetPQTest2Records - To Get PQ Test Records from Database and display them.
	//--- funcGetPQTest2Details - To Get PQ Test Records from Database for the given ID.
	//--- funcAssignValuesToControls - To Assign values to controls on form. 
	//--- funcSavePQTest2Data - To Save the Entered Records into Database.
	//--- funcGetObservationFromControls - To Get values from text box controls on form. 
	//--- funcGetDemoDateFromControls - To Get values from Date Time Picker controls on form. 
	//--- funcGetVerifiedDateFromControls - To Get values from Date Time Picker controls on form. 
	//--- funcInsertPQTest2Data - To Add/Insert New Test Data in Database.
	//--- funcUpdatePQTest2Data - To Update PQ Test Data in Database.
	//--- funcDeletePQTest2Data - To Delete PQ Test Data from Database.
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
			//mobjDataTable = New DataTable("TestProcedure")
			//mobjTestDataTable = New DataTable("Test")
			//Added by Pankaj on 19 May 2007
			lblModelNo.Text = gobjModelNo;
			//--- Display the Procedure for the test 
			subDisplayMethodInfo();

			//--- Display the result for the test
			funcDisplayPQTest1();

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

	private void dtpCorrectiveDate_ValueChanged(System.Object sender, System.EventArgs e)
	{
		dgTest(dgTest.CurrentCell.RowNumber, dgTest.CurrentCell.ColumnNumber) = mdtpPQTest1Date.Value;
	}

	private void subDisplayParameters()
	{
		try {
		//--- Get thye parameters form the file
		//Call funcGetBaselineTestParameters(gobjValidationTest)

		//'--- Get thye parameters form the file
		//Call funcGetNoiseTestParameters(gobjValidationTest)

		//lblSpecifiedBaselineResult.Text = "+/-" & gobjValidationTest.BaselineTest.SpecifiedReading & " Abs"
		//lblSpecifiedNoiseTestResult.Text = "+/-" & gobjValidationTest.NoiseTest.SpecifiedReading & " Abs"

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

	private bool funcDisplayPQTest1()
	{
		//=====================================================================
		// Procedure Name        :   funcDisplayPQTest1
		// Description           :   To Get PQ Test Records from Database and display them.
		// Purpose               :   To Get PQ Test Records from Database and display them.
		// Parameters Passed     :   None.
		// Returns               :   None.
		// Parameters Affected   :   None.
		// Assumptions           :
		// Dependencies          :
		// Author                :   
		// Created               :   January, 2003 
		// Revisions             :
		//=====================================================================
		//Dim objReader As OleDbDataReader
		//Dim objDataTable As DataTable
		DataRow objDataRow;
		int intCount = 0;
		DataTable mobjTmpDt = new DataTable();
		//Dim str_sql As String
		//Dim reader_status, record_exists As Boolean

		try {
			objDataTable = new DataTable("PQTest1Result");

			mdtpPQTest1Date = new DateTimePicker();


			//--- To Add Run-Time DateTime Picker Control
			mdtpPQTest1Date.ValueChanged += dtpCorrectiveDate_ValueChanged;
			dgTest.Controls.Add(mdtpPQTest1Date);
			mdtpPQTest1Date.Visible = false;
			mdtpPQTest1Date.Format = DateTimePickerFormat.Custom;
			mdtpPQTest1Date.CustomFormat = "dd-MMM-yyyy";


			//objDataTable.Columns.Add(New DataColumn("TestName", GetType(String)))
			objDataTable.Columns.Add(new DataColumn(ConstSampleID, typeof(int)));
			objDataTable.Columns.Add(new DataColumn(ConstAbsorbance, typeof(string)));
			objDataTable.Columns.Add(new DataColumn(ConstPMTVoltage, typeof(string)));
			objDataTable.Columns.Add(new DataColumn(ConstWaveLength, typeof(string)));
			objDataTable.Columns.Add(new DataColumn(ConstSlitWidth, typeof(string)));
			objDataTable.Columns.Add(new DataColumn(ConstBurnerHeight, typeof(string)));
			objDataTable.Columns.Add(new DataColumn(ConstFuel, typeof(string)));
			objDataTable.Columns.Add(new DataColumn(ConstLampCurrent, typeof(string)));
			objDataTable.Columns.Add(new DataColumn(ConstRemark, typeof(string)));
			objDataTable.Columns.Add(new DataColumn(ConstDate, typeof(string)));

			mobjTmpDt = gobjDataAccess.funcGetPQTest1Records();

			if (!mobjTmpDt == null) {
				if (!mobjTmpDt.Rows.Count == 0) {
					for (intCount = 0; intCount <= mobjTmpDt.Rows.Count - 1; intCount++) {
						objDataRow = objDataTable.NewRow;
						objDataRow.Item(ConstSampleID) = mobjTmpDt.Rows.Item(intCount).Item(ConstSampleID);

						if (IsDBNull(mobjTmpDt.Rows.Item(intCount).Item(ConstLampCurrent)) == true) {
							objDataRow.Item(ConstLampCurrent) = "";
						//ElseIf Trim(mobjTmpDt.Rows.Item(intCount).Item(ConstLampCurrent)) = "" Then
						//    objDataRow.Item(ConstLampCurrent) = ""
						} else {
							//objDataRow.Item(ConstLampCurrent) = Format(CDbl(mobjTmpDt.Rows.Item(intCount).Item(ConstLampCurrent)), "0.0")
							objDataRow.Item(ConstLampCurrent) = mobjTmpDt.Rows.Item(intCount).Item(ConstLampCurrent);
						}

						if (IsDBNull(mobjTmpDt.Rows.Item(intCount).Item(ConstPMTVoltage)) == true) {
							objDataRow.Item(ConstPMTVoltage) = "";
						} else {
							//objDataRow.Item(ConstPMTVoltage) = Format(CDbl(mobjTmpDt.Rows.Item(intCount).Item(ConstPMTVoltage)), "0.0")
							objDataRow.Item(ConstPMTVoltage) = mobjTmpDt.Rows.Item(intCount).Item(ConstPMTVoltage);
						}

						if (IsDBNull(mobjTmpDt.Rows.Item(intCount).Item(ConstWaveLength)) == true) {
							objDataRow.Item(ConstWaveLength) = "";
						} else {
							//objDataRow.Item(ConstWaveLength) = Format(CDbl(mobjTmpDt.Rows.Item(intCount).Item(ConstWaveLength)), "0.0")
							objDataRow.Item(ConstWaveLength) = mobjTmpDt.Rows.Item(intCount).Item(ConstWaveLength);
						}

						if (IsDBNull(mobjTmpDt.Rows.Item(intCount).Item(ConstSlitWidth)) == true) {
							objDataRow.Item(ConstSlitWidth) = "";
						} else {
							//objDataRow.Item(ConstSlitWidth) = Format(CDbl(mobjTmpDt.Rows.Item(intCount).Item(ConstSlitWidth)), "0.0")
							objDataRow.Item(ConstSlitWidth) = mobjTmpDt.Rows.Item(intCount).Item(ConstSlitWidth);
						}

						if (IsDBNull(mobjTmpDt.Rows.Item(intCount).Item(ConstFuel)) == true) {
							objDataRow.Item(ConstFuel) = "";
						} else {
							//objDataRow.Item(ConstFuel) = Format(CDbl(mobjTmpDt.Rows.Item(intCount).Item(ConstFuel)), "0.00")
							objDataRow.Item(ConstFuel) = mobjTmpDt.Rows.Item(intCount).Item(ConstFuel);
						}

						if (IsDBNull(mobjTmpDt.Rows.Item(intCount).Item(ConstAbsorbance)) == true) {
							objDataRow.Item(ConstAbsorbance) = "";
						} else {
							//objDataRow.Item(ConstAbsorbance) = Format(CDbl(mobjTmpDt.Rows.Item(intCount).Item(ConstAbsorbance)), "0.000")
							objDataRow.Item(ConstAbsorbance) = mobjTmpDt.Rows.Item(intCount).Item(ConstAbsorbance);
						}

						if (IsDBNull(mobjTmpDt.Rows.Item(intCount).Item(ConstBurnerHeight)) == true) {
							objDataRow.Item(ConstBurnerHeight) = "";
						} else {
							//objDataRow.Item(ConstBurnerHeight) = Format(CDbl(mobjTmpDt.Rows.Item(intCount).Item(ConstBurnerHeight)), "0.0")
							objDataRow.Item(ConstBurnerHeight) = mobjTmpDt.Rows.Item(intCount).Item(ConstBurnerHeight);
						}

						if (IsDBNull(mobjTmpDt.Rows.Item(intCount).Item(ConstRemark)) == true) {
							objDataRow.Item(ConstRemark) = "";
						} else {
							objDataRow.Item(ConstRemark) = mobjTmpDt.Rows.Item(intCount).Item(ConstRemark);
						}

						if (IsDBNull(mobjTmpDt.Rows.Item(intCount).Item(ConstDate)) == true) {
							objDataRow.Item(ConstDate) = "";
						} else {
							objDataRow.Item(ConstDate) = mobjTmpDt.Rows.Item(intCount).Item(ConstDate);
						}

						objDataTable.Rows.Add(objDataRow);
					}
				}
			}

			if (IsNothing(objDataTable) == true) {
				throw new Exception("Error in Getting Equipment List Records.");
			} else {
				subFormatTestDataGrid();
			}

			//str_sql = "Select * from PQTest where PQTestID = " & enumPQTest.PQ_Test1

			//If Not gclsDBFunctions.GetRecords(str_sql, gOleDBIQOQPQConnection, objReader) Then
			//    Return True
			//End If

			//While objReader.Read
			//    objDataRow = objDataTable.NewRow()

			//    If IsDBNull(objReader.Item("PQTestName")) = False Then
			//        objDataRow("TestName") = CStr(objReader.Item("PQTestName"))
			//    End If
			//    If IsDBNull(objReader.Item("PQAbsorbance")) = False Then
			//        objDataRow("Result") = Format(Val(objReader.Item("PQAbsorbance")), "#0.0000")
			//    End If
			//    If IsDBNull(objReader.Item("PQCriteria")) = False Then
			//        objDataRow("Criteria") = "�" & Format(Val(objReader.Item("PQCriteria")), "#0.0000")
			//    End If
			//    If IsDBNull(objReader.Item("PQComments")) = False Then
			//        objDataRow("Comments") = CStr(objReader.Item("PQComments"))
			//    End If
			//    objDataRow("TestID") = Val(objReader.Item("ValidationTestID") & "")

			//    objDataTable.Rows.Add(objDataRow)
			//End While

			//objReader.Close()

			//--- Display the data in the grid
			//Call subFormatTestDataGrid(objDataTable)

			if (gobjDataAccess.funcCheckModeLocked(ENUM_IQOQPQ_STATUS.PQ)) {
				dgTest.ReadOnly = true;
				btnTest.Enabled = false;
				//Added by Pankaj on 6.12.07
			} else {
				dgTest.ReadOnly = false;
				btnTest.Enabled = true;
			}

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = "Error in Getting Test Records.";
			gobjErrorHandler.WriteErrorLog(ex);
			return (false);
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//--- Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			//---------------------------------------------------------
		}
		return true;
	}

	private void subFormatTestDataGrid()
	{
		DataGridTextBoxColumn objTextColumn;
		DataView objDataView = new DataView();
		DataGridTableStyle objTestGridTableStyle = new DataGridTableStyle();

		try {
			dgTest.TableStyles.Clear();
			objDataView.Table = objDataTable;
			objDataView.AllowNew = false;
			dgTest.DataSource = objDataView;

			objTestGridTableStyle.RowHeadersVisible = false;
			objTestGridTableStyle.ResetAlternatingBackColor();
			objTestGridTableStyle.ResetBackColor();
			objTestGridTableStyle.ResetForeColor();
			objTestGridTableStyle.ResetGridLineColor();
			objTestGridTableStyle.BackColor = Color.AliceBlue;
			objTestGridTableStyle.GridLineColor = Color.SandyBrown;
			objTestGridTableStyle.HeaderBackColor = Color.FromArgb(205, 225, 250);
			objTestGridTableStyle.HeaderForeColor = Color.Black;
			objTestGridTableStyle.AlternatingBackColor = Color.AliceBlue;
			objTestGridTableStyle.AllowSorting = false;

			objTestGridTableStyle.MappingName = "PQTest1Result";
			objTextColumn = new DataGridTextBoxColumn();
			objTextColumn.MappingName = ConstSampleID;
			objTextColumn.HeaderText = "Sr. No.";
			objTextColumn.Width = 50;
			objTextColumn.ReadOnly = true;
			objTextColumn.NullText = "";
			objTextColumn.Alignment = HorizontalAlignment.Center;
			objTestGridTableStyle.GridColumnStyles.Add(objTextColumn);

			objTextColumn = new DataGridTextBoxColumn();
			objTextColumn.MappingName = ConstLampCurrent;
			objTextColumn.HeaderText = "Lamp current";
			//ConstLampCurrent
			objTextColumn.Width = 85;
			objTextColumn.ReadOnly = false;
			objTextColumn.NullText = "";
			objTextColumn.Alignment = HorizontalAlignment.Center;
			objTestGridTableStyle.GridColumnStyles.Add(objTextColumn);

			objTextColumn = new DataGridTextBoxColumn();
			objTextColumn.MappingName = ConstAbsorbance;
			objTextColumn.HeaderText = "Abs";
			objTextColumn.Width = 48;
			objTextColumn.ReadOnly = false;
			objTextColumn.NullText = "";
			objTextColumn.Alignment = HorizontalAlignment.Center;
			objTestGridTableStyle.GridColumnStyles.Add(objTextColumn);

			objTextColumn = new DataGridTextBoxColumn();
			objTextColumn.MappingName = ConstWaveLength;
			objTextColumn.HeaderText = "Wavelength";
			objTextColumn.Width = 77;
			objTextColumn.ReadOnly = false;
			objTextColumn.NullText = "";
			objTextColumn.Alignment = HorizontalAlignment.Center;
			objTestGridTableStyle.GridColumnStyles.Add(objTextColumn);

			objTextColumn = new DataGridTextBoxColumn();
			objTextColumn.MappingName = ConstSlitWidth;
			objTextColumn.HeaderText = "Slit width";
			//ConstSlitWidth
			objTextColumn.Width = 60;
			objTextColumn.ReadOnly = false;
			objTextColumn.NullText = "";
			objTextColumn.Alignment = HorizontalAlignment.Center;
			objTestGridTableStyle.GridColumnStyles.Add(objTextColumn);

			objTextColumn = new DataGridTextBoxColumn();
			objTextColumn.MappingName = ConstBurnerHeight;
			objTextColumn.HeaderText = "Burner height";
			//ConstBurnerHeight
			objTextColumn.Width = 85;
			objTextColumn.ReadOnly = false;
			objTextColumn.NullText = "";
			objTextColumn.Alignment = HorizontalAlignment.Center;
			objTestGridTableStyle.GridColumnStyles.Add(objTextColumn);

			objTextColumn = new DataGridTextBoxColumn();
			objTextColumn.MappingName = ConstFuel;
			objTextColumn.HeaderText = ConstFuel;
			objTextColumn.Width = 45;
			objTextColumn.ReadOnly = false;
			objTextColumn.NullText = "";
			objTextColumn.Alignment = HorizontalAlignment.Center;
			objTestGridTableStyle.GridColumnStyles.Add(objTextColumn);

			objTextColumn = new DataGridTextBoxColumn();
			objTextColumn.MappingName = ConstPMTVoltage;
			objTextColumn.HeaderText = "PMT voltage";
			//ConstPMTVoltage
			objTextColumn.Width = 75;
			objTextColumn.ReadOnly = false;
			objTextColumn.NullText = "";
			objTextColumn.Alignment = HorizontalAlignment.Center;
			objTestGridTableStyle.GridColumnStyles.Add(objTextColumn);


			objTextColumn = new DataGridTextBoxColumn();
			objTextColumn.MappingName = ConstRemark;
			objTextColumn.HeaderText = ConstRemark;
			objTextColumn.Width = 80;
			objTextColumn.ReadOnly = false;
			objTextColumn.NullText = "";
			objTextColumn.Alignment = HorizontalAlignment.Center;
			objTestGridTableStyle.GridColumnStyles.Add(objTextColumn);

			objTextColumn = new DataGridTextBoxColumn();
			objTextColumn.MappingName = ConstDate;
			objTextColumn.HeaderText = ConstDate;
			objTextColumn.Width = 70;
			//objTextColumn.Format = "dd-MMM-yyyy"
			objTextColumn.ReadOnly = false;
			objTextColumn.NullText = "";
			objTextColumn.Alignment = HorizontalAlignment.Center;
			objTestGridTableStyle.GridColumnStyles.Add(objTextColumn);


			//objTextColumn = New DataGridTextBoxColumn
			//objTextColumn.MappingName = "TestID"
			//objTextColumn.HeaderText = "TestID"
			//objTextColumn.Width = 0
			//objTextColumn.ReadOnly = True
			//objTextColumn.NullText = ""
			//objTestGridTableStyle.GridColumnStyles.Add(objTextColumn)

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

	public bool funcSavePQTest1Remarks()
	{
		//=====================================================================
		// Procedure Name        :   funcSavePQTest1Remarks
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
		int temp_cnt;
		int intValidationTestID;
		string strRemark;
		string strSampleID;
		bool status;
		string strPMTVoltage;
		string strWaveLength;
		string strSlitWidth;
		string strBurnerHeight;
		string strAbsorbance;
		string strLampCurrent;
		string strFuel;
		string strDate;
		DataView objDataView = new DataView();
		try {
			//--- Read the remarks from the grid and save in the database.
			//objDataView = dgTest.DataSource
			if (objDataTable == null)
				return true;
			if (objDataTable.Rows.Count <= 0)
				return true;


			for (temp_cnt = 0; temp_cnt <= objDataTable.Rows.Count - 1; temp_cnt++) {
				//strSampleID = objDataTable.Rows(temp_cnt).ItemArray.GetValue(objDataTable.Columns.Item("SampleID").Ordinal) 'code commented by : dinesh wagh on 15.6.2010

				//code added by : dinesh wagh on 15.6.2010
				//------------
				if (IsDBNull(objDataTable.Rows(temp_cnt).ItemArray.GetValue(objDataTable.Columns.Item("SampleID").Ordinal))) {
					return true;
				} else {
					strSampleID = objDataTable.Rows(temp_cnt).ItemArray.GetValue(objDataTable.Columns.Item("SampleID").Ordinal);
				}
				//---------

				if (IsDBNull(objDataTable.Rows(temp_cnt).ItemArray.GetValue(objDataTable.Columns.Item("Remark").Ordinal))) {
					strRemark = "OK";
				} else {
					strRemark = objDataTable.Rows(temp_cnt).ItemArray.GetValue(objDataTable.Columns.Item("Remark").Ordinal);
				}

				if (IsDBNull(objDataTable.Rows(temp_cnt).ItemArray.GetValue(objDataTable.Columns.Item("PMTVoltage").Ordinal))) {
					strPMTVoltage = "";
				} else {
					strPMTVoltage = objDataTable.Rows(temp_cnt).ItemArray.GetValue(objDataTable.Columns.Item("PMTVoltage").Ordinal);
				}

				if (IsDBNull(objDataTable.Rows(temp_cnt).ItemArray.GetValue(objDataTable.Columns.Item("WaveLength").Ordinal))) {
					strWaveLength = "";
				} else {
					strWaveLength = objDataTable.Rows(temp_cnt).ItemArray.GetValue(objDataTable.Columns.Item("WaveLength").Ordinal);
				}

				if (IsDBNull(objDataTable.Rows(temp_cnt).ItemArray.GetValue(objDataTable.Columns.Item("SlitWidth").Ordinal))) {
					strSlitWidth = "";
				} else {
					strSlitWidth = objDataTable.Rows(temp_cnt).ItemArray.GetValue(objDataTable.Columns.Item("SlitWidth").Ordinal);
				}

				if (IsDBNull(objDataTable.Rows(temp_cnt).ItemArray.GetValue(objDataTable.Columns.Item("BurnerHeight").Ordinal))) {
					strBurnerHeight = "";
				} else {
					strBurnerHeight = objDataTable.Rows(temp_cnt).ItemArray.GetValue(objDataTable.Columns.Item("BurnerHeight").Ordinal);
				}

				if (IsDBNull(objDataTable.Rows(temp_cnt).ItemArray.GetValue(objDataTable.Columns.Item("Fuel").Ordinal))) {
					strFuel = "";
				} else {
					strFuel = objDataTable.Rows(temp_cnt).ItemArray.GetValue(objDataTable.Columns.Item("Fuel").Ordinal);
				}

				if (IsDBNull(objDataTable.Rows(temp_cnt).ItemArray.GetValue(objDataTable.Columns.Item("LampCurrent").Ordinal))) {
					strLampCurrent = "";
				} else {
					strLampCurrent = objDataTable.Rows(temp_cnt).ItemArray.GetValue(objDataTable.Columns.Item("LampCurrent").Ordinal);
				}

				if (IsDBNull(objDataTable.Rows(temp_cnt).ItemArray.GetValue(objDataTable.Columns.Item("Absorbance").Ordinal))) {
					strAbsorbance = "";
				} else {
					strAbsorbance = objDataTable.Rows(temp_cnt).ItemArray.GetValue(objDataTable.Columns.Item("Absorbance").Ordinal);
				}

				if (IsDBNull(objDataTable.Rows(temp_cnt).ItemArray.GetValue(objDataTable.Columns.Item("Date").Ordinal))) {
					strDate = "";
				} else {
					strDate = objDataTable.Rows(temp_cnt).ItemArray.GetValue(objDataTable.Columns.Item("Date").Ordinal);
				}

				status = gobjDataAccess.funcUpdatePQTest1Records(strRemark, strPMTVoltage, strWaveLength, strSlitWidth, strBurnerHeight, strAbsorbance, strFuel, strLampCurrent, strDate, strSampleID);
				if (!(status)) {
					throw new Exception("Error in Updating PQTest1 Record Details.");
				}
				//Call funcUpdatePQTestRemark(Val(objDataView.Table.Rows.Item(temp_cnt).Item("TestID") & ""), CStr(objDataView.Table.Rows.Item(temp_cnt).Item("Comments") & ""))
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

	private bool funcUpdatePQTest1Data(int intValidationTestID, string strRemark, int intLampCurrent, double dblPMTVoltage, double dblWaveLength, double dblSlitWidth, double dblBurnerHeight, int intFuel, DateTime dtDate, double dblAbsorbance)
	{
		//=====================================================================
		// Procedure Name        :   funcUpdatePQTest1Data
		// Description           :   To Add/Insert New Test Data in Database.
		// Purpose               :   To Add/Insert New Test Data in Database.
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
			//If Not gclsDBFunctions.OpenConnection(gOleDBIQOQPQConnection) Then
			//    Throw New Exception("Error in Opening Connection during Saving Test Details.")
			//End If

			//---  Query for adding  data to Test
			str_sql = " Update PQTest Set" + " PQAbsorbance=?,PQCriteria=?,PQComments=? " + " Time=?,DistBySoapRing=?,ActualAbsorbance=? " + " RT=?,Absorbance=?, Date=? " + " Where  ValidationTestID=? and PQTestID=?";

			//--- Providing command object for Test
				//.Connection = gOleDBIQOQPQConnection
			 // ERROR: Not supported in C#: WithStatement


			objCommand.Dispose();
			return true;

		} catch (Exception ex) {
			//---------------------------------------------------------
			//--- Error logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = "Error in Saving Test Details.";
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

	private bool funcUpdatePQTestRemark(int intValidationTestID, string strRemark)
	{
		//=====================================================================
		// Procedure Name        :   funcUpdatePQTestRemark
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
			//If Not gclsDBFunctions.OpenConnection(gOleDBIQOQPQConnection) Then
			//    Throw New Exception("Error in Opening Connection during Updating Test Details.")
			//End If

			//---  Query to Update Data
			str_sql = " Update PQTest set " + " PQComments = ? " + " where ValidationTestID =" + intValidationTestID + " and PQTestID = " + enumPQTest.PQ_Test1 + " ";

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

	//Private Function funcDeletePQTest2Data(ByVal intTestID As Integer) As Boolean
	//    '=====================================================================
	//    ' Procedure Name        :   funcDeletePQTest2Data
	//    ' Description           :   To Delete Test Data from Database.
	//    ' Purpose               :   To Delete Test Data from Database.
	//    ' Parameters Passed     :   None.
	//    ' Returns               :   None.
	//    ' Parameters Affected   :   None.
	//    ' Assumptions           :
	//    ' Dependencies          :
	//    ' Author                :   Gitesh
	//    ' Created               :   January, 2003 
	//    ' Revisions             :
	//    '=====================================================================

	//    Dim Status As Boolean
	//    Dim str_sql As String

	//    Try
	//        Status = mclsDBFunctions.OpenConnection(mobjOleDBconnection)
	//        If Not (Status) Then
	//            Throw New Exception("Error in Opening Connection during Deleting Test Details.")
	//        End If

	//        '--- Query to Delete from Database
	//        str_sql = " Delete * from PQTest1 where PQTestID = " & intTestID & " "

	//        Status = mclsDBFunctions.AddORDeleteRecord(str_sql, mobjOleDBconnection)
	//        If (Status = False) Then
	//            Throw New Exception("Error in Deleting Test Details.")
	//        End If

	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        '--- Error logging
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = "Error in Deleting Test Details."
	//        gobjErrorHandler.WriteErrorLog(ex)
	//        Return (False)
	//        '---------------------------------------------------------
	//    Finally
	//        '---------------------------------------------------------
	//        '--- Writing Execution log
	//        If CONST_CREATE_EXECUTION_LOG = 1 Then
	//            gobjErrorHandler.WriteExecutionLog()
	//        End If
	//        '---------------------------------------------------------
	//    End Try

	//    Return Status

	//End Function

	private void subDisplayMethodInfo()
	{
		//=====================================================================
		// Procedure Name        :   subDisplayMethodInfo
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
		DataColumn objDataColumn;
		DataRow objDataRow;
		DataView objDataView = new DataView();
		DataTable objCADataTable = new DataTable();

		try {
			objCADataTable = new DataTable("PQTest11");
			objCADataTable.Columns.Add(new DataColumn("Name", typeof(string)));

			//--- Format thge method grid
			subFormatDataGrid(objCADataTable);

			objDataRow = objCADataTable.NewRow();
			//'objDataRow("Name") = "1) Switch on instrument, load method for (lamp should be mounted on turret). "
			objDataRow("Name") = "1) Load or create method for Copper. ";
			objCADataTable.Rows.Add(objDataRow);

			objDataRow = objCADataTable.NewRow();
			//'objDataRow("Name") = "2) Select 'Analysis' from menu, wavelength will be selected and latched."
			objDataRow("Name") = "2) Proceed for Analysis.";
			objCADataTable.Rows.Add(objDataRow);

			objDataRow = objCADataTable.NewRow();
			//'objDataRow("Name") = "3) Switch on th Air-Acetylene flame. Aspirate blank and adjust zero."
			//'objDataRow("Name") = "3) With AA flame aspirate blank to set zero absorbance (� 0.002)." 'code commented by ; dinesh wagh on 24.2.2010
			objDataRow("Name") = "3) With AA flame aspirate blank to set zero absorbance.";
			//code added by ; dinesh wagh on 24.2.2010
			objCADataTable.Rows.Add(objDataRow);

			objDataRow = objCADataTable.NewRow();
			//'objDataRow("Name") = "4) Select manual optimisation. Aspirate 'ppm' of solution and observe absorbance."
			objDataRow("Name") = "4) In manual optimisation, Aspirate '5ppm' Copper solution and observe the absorbance reading.";
			objCADataTable.Rows.Add(objDataRow);

			objDataRow = objCADataTable.NewRow();
			//'objDataRow("Name") = "5) Adjust burner height, horizontal position, angular position to get maximum absorbance"
			objDataRow("Name") = "5) Adjust height, horizontal position, angular position of the burner head to set maximum";
			objCADataTable.Rows.Add(objDataRow);

			objDataRow = objCADataTable.NewRow();
			objDataRow("Name") = "   absorbance value, if required adjust nebulizer also.";
			objCADataTable.Rows.Add(objDataRow);
			//code added by : dinesh wagh on 24.2.2010

			objDataRow = objCADataTable.NewRow();
			objDataRow("Name") = "6) After conducting the test and adjusting 5 ppm Cu to produce 0.65 abs, don't remove tube";
			objCADataTable.Rows.Add(objDataRow);

			objDataRow = objCADataTable.NewRow();
			objDataRow("Name") = "  from the solution and press return.";
			objCADataTable.Rows.Add(objDataRow);

			//code commented by ; dinesh wagh on 15.2.2010
			//----------------------------------------------------
			//'objDataRow = objCADataTable.NewRow()
			//'objDataRow("Name") = "7) Conduct the test 3 times."
			//'objCADataTable.Rows.Add(objDataRow)
			//---------------------------------------------------

			Application.DoEvents();
			//objDataRow = objCADataTable.NewRow()
			//objDataRow("Name") = "6 Gently press the bulb of flow meter so that fine ring of soap should develop."
			//objCADataTable.Rows.Add(objDataRow)

			//objDataRow = objCADataTable.NewRow()
			//objDataRow("Name") = "7. Measure the distance travel by the soap ring against time using stopwatch."
			//objCADataTable.Rows.Add(objDataRow)

			dgMethod.DataSource = objCADataTable;
			Application.DoEvents();

			//--- Display the specified values on the screen
			subDisplayParameters();

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = "Error in Creating Test Method Data-Table.";
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

	private void subFormatDataGrid(ref DataTable objDataTable)
	{
		DataGridTextBoxColumn objTextColumn;
		DataView objDataView = new DataView();
		DataGridTableStyle objGridTableStyle = new DataGridTableStyle();
		try {
			dgMethod.TableStyles.Clear();
			dgMethod.RowHeadersVisible = false;
			dgMethod.CaptionVisible = false;
			dgMethod.RowHeadersVisible = false;
			dgMethod.ParentRowsVisible = false;
			dgMethod.FlatMode = true;
			dgMethod.BorderStyle = BorderStyle.None;
			dgMethod.GridLineStyle = DataGridLineStyle.None;
			objDataView.Table = objDataTable;
			objDataView.AllowNew = false;
			dgMethod.DataSource = objDataView;
			dgMethod.ReadOnly = false;

			objGridTableStyle.RowHeadersVisible = false;
			objGridTableStyle.ResetAlternatingBackColor();
			objGridTableStyle.ResetBackColor();
			objGridTableStyle.ResetForeColor();
			objGridTableStyle.ResetGridLineColor();
			objGridTableStyle.BackColor = Color.AliceBlue;
			objGridTableStyle.HeaderBackColor = Color.LightSkyBlue;
			objGridTableStyle.HeaderForeColor = Color.Black;
			objGridTableStyle.AlternatingBackColor = Color.AliceBlue;
			objGridTableStyle.SelectionBackColor = Color.AliceBlue;
			objGridTableStyle.SelectionForeColor = Color.AliceBlue;
			objGridTableStyle.LinkColor = Color.AliceBlue;
			objGridTableStyle.AllowSorting = false;

			objGridTableStyle.MappingName = "PQTest11";

			objGridTableStyle.RowHeadersVisible = false;
			objGridTableStyle.ColumnHeadersVisible = false;
			objGridTableStyle.GridLineStyle = DataGridLineStyle.None;

			objTextColumn = new DataGridTextBoxColumn();
			objTextColumn.MappingName = "Name";
			objTextColumn.HeaderText = "";
			objTextColumn.Width = 535;
			objTextColumn.ReadOnly = true;
			objTextColumn.NullText = "";
			objGridTableStyle.GridColumnStyles.Add(objTextColumn);

			objGridTableStyle.GridLineColor = Color.LightBlue;
			dgMethod.TableStyles.Add(objGridTableStyle);

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = "Error in Formating Test Description - 1 Data-Grid.";
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
		//try catch added by ;dinesh wagh on 3.2.2010
		try {
			if (!(mblnModeLockStatus)) {
				objDataTable.Columns(0).ReadOnly = false;

				if (objDataTable.Rows.Count == 0) {
					objDataTable.Columns(0).DefaultValue = 1;
				} else {
					dgTest.Item(dgTest.CurrentRowIndex, 0) = dgTest.CurrentRowIndex + 1;
				}

				objDataTable.Columns(0).ReadOnly = true;
				if ((dgTest.CurrentCell.ColumnNumber == CONST_DateColumnNo)) {
					mdtpPQTest1Date.Top = dgTest.GetCurrentCellBounds().Top;
					mdtpPQTest1Date.Left = dgTest.GetCurrentCellBounds().Left;
					mdtpPQTest1Date.Width = dgTest.GetCurrentCellBounds().Width;
					mdtpPQTest1Date.Height = dgTest.GetCurrentCellBounds().Height;
					if ((dgTest.CurrentCell.RowNumber) > 0) {
						if (IsDBNull(dgTest(dgTest.CurrentCell.RowNumber, CONST_DateColumnNo)) == false) {
							mdtpPQTest1Date.Value = (System.DateTime)dgTest(dgTest.CurrentCell.RowNumber, CONST_DateColumnNo);
						} else {
							mdtpPQTest1Date.Value = DateTime.Today;
							dgTest(dgTest.CurrentCell.RowNumber, dgTest.CurrentCell.ColumnNumber) = mdtpPQTest1Date.Value;
						}
					} else {
						dgTest(dgTest.CurrentCell.RowNumber, dgTest.CurrentCell.ColumnNumber) = mdtpPQTest1Date.Value;
						//   mdtpCorrectiveDate.Value = DateTime.Today
					}
					mdtpPQTest1Date.Visible = true;
				} else {
					mdtpPQTest1Date.Width = 0;
					mdtpPQTest1Date.Visible = false;
				}
			}

			if (dgTest.CurrentRowIndex >= 10) {
				mobjDataView.AllowNew = false;
			}

		} catch (Exception ex) {
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
		} finally {
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
		}
	}

	private void  // ERROR: Handles clauses are not supported in C#
btnTest_Click(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : btnTest_Click
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : To communicate with the instrument and perform tests
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 04.07.07
		// Revisions             : 
		//=====================================================================
		//Dim lblTestStatus As Label
		//Dim dtParameters As DataTable
		try {
			btnTest.Enabled = false;
			if (objDataTable.Rows.Count == 3) {
				objDataTable.Rows.Clear();
				intCounter = 0;
			}
			if (intCounter < 3) {
				intCounter += 1;
				if (Test_IQOQPQ_Attachment1 != null) {
					Test_IQOQPQ_Attachment1(objDataTable, intCounter);
				}
				//, dtParameters)
			} else {
				intCounter = 1;
				objDataTable.Rows.Clear();
				if (Test_IQOQPQ_Attachment1 != null) {
					Test_IQOQPQ_Attachment1(objDataTable, intCounter);
				}
				//, dtParameters)
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
			//objWait.Dispose()
			btnTest.Enabled = true;
			//---------------------------------------------------------
		}
	}

}
