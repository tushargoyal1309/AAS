using System.Data;
using System.Data.OleDb;
using System.Windows.Forms.DataGridColumnStyle;

public class frmPQTest4 : System.Windows.Forms.Form
{

	#Region " Module level Declarations "
	//Private mstrOledbConnectionString As String
	//Private mobjOleDBconnection As OleDbConnection
	//Private gclsDBFunctions As New clsDatabaseFunctions
	private DataTable objDataTable;
		//Saurabh  09.07.07
	private int intCounter = 0;
	public event  Test_IQOQPQ_AttachmentIII;
	//Saurabh  09.07.07
	#End Region

	#Region " Windows Form Designer generated code "

	public frmPQTest4()
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
	internal System.Windows.Forms.DataGridTableStyle DataGridTableStyle1;
	internal System.Windows.Forms.DataGridTextBoxColumn DataGridTextBoxColumn1;
	internal System.Windows.Forms.Panel Panel2;
	internal System.Windows.Forms.PictureBox PictureBox1;
	internal System.Windows.Forms.Label lblAcceptance;
	internal System.Windows.Forms.Label Label1;
	internal System.Windows.Forms.Label lblModelNo;
	internal NETXP.Controls.XPButton btnTest;
	internal System.Windows.Forms.Label Label2;
	[System.Diagnostics.DebuggerStepThrough()]
	private void InitializeComponent()
	{
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmPQTest4));
		this.lblTestResults = new System.Windows.Forms.Label();
		this.lblAttachment = new System.Windows.Forms.Label();
		this.lblMethod = new System.Windows.Forms.Label();
		this.lblPurpose = new System.Windows.Forms.Label();
		this.lblTestName = new System.Windows.Forms.Label();
		this.lblHeader1 = new System.Windows.Forms.Label();
		this.Panel1 = new System.Windows.Forms.Panel();
		this.Label2 = new System.Windows.Forms.Label();
		this.btnTest = new NETXP.Controls.XPButton();
		this.lblModelNo = new System.Windows.Forms.Label();
		this.Label1 = new System.Windows.Forms.Label();
		this.lblAcceptance = new System.Windows.Forms.Label();
		this.Panel2 = new System.Windows.Forms.Panel();
		this.PictureBox1 = new System.Windows.Forms.PictureBox();
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
		this.lblTestResults.Location = new System.Drawing.Point(8, 364);
		this.lblTestResults.Name = "lblTestResults";
		this.lblTestResults.Size = new System.Drawing.Size(120, 12);
		this.lblTestResults.TabIndex = 18;
		this.lblTestResults.Text = "Observations  :";
		this.lblTestResults.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//lblAttachment
		//
		this.lblAttachment.BackColor = System.Drawing.Color.AliceBlue;
		this.lblAttachment.Font = new System.Drawing.Font("Times New Roman", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblAttachment.ForeColor = System.Drawing.SystemColors.ControlText;
		this.lblAttachment.Location = new System.Drawing.Point(449, 40);
		this.lblAttachment.Name = "lblAttachment";
		this.lblAttachment.Size = new System.Drawing.Size(112, 20);
		this.lblAttachment.TabIndex = 17;
		this.lblAttachment.Text = "Attachment III";
		//
		//lblMethod
		//
		this.lblMethod.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblMethod.ForeColor = System.Drawing.SystemColors.ControlText;
		this.lblMethod.Location = new System.Drawing.Point(8, 115);
		this.lblMethod.Name = "lblMethod";
		this.lblMethod.Size = new System.Drawing.Size(450, 18);
		this.lblMethod.TabIndex = 12;
		this.lblMethod.Text = "Method             :     Follow the steps given below after clicking on 'Test' bu" + "tton.";
		//
		//lblPurpose
		//
		this.lblPurpose.AutoSize = true;
		this.lblPurpose.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblPurpose.ForeColor = System.Drawing.SystemColors.ControlText;
		this.lblPurpose.Location = new System.Drawing.Point(8, 91);
		this.lblPurpose.Name = "lblPurpose";
		this.lblPurpose.Size = new System.Drawing.Size(356, 17);
		this.lblPurpose.TabIndex = 11;
		this.lblPurpose.Text = "Purpose          :     To verify the calibration graph for curve fitting.";
		//
		//lblTestName
		//
		this.lblTestName.AutoSize = true;
		this.lblTestName.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblTestName.ForeColor = System.Drawing.SystemColors.ControlText;
		this.lblTestName.Location = new System.Drawing.Point(8, 67);
		this.lblTestName.Name = "lblTestName";
		this.lblTestName.Size = new System.Drawing.Size(516, 17);
		this.lblTestName.TabIndex = 10;
		this.lblTestName.Text = "Test Name     :     Calibration graph plotting for Cu, in the range 1ppm - 5ppm u" + "sing AA flame.";
		//
		//lblHeader1
		//
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
		this.Panel1.Controls.Add(this.Label2);
		this.Panel1.Controls.Add(this.btnTest);
		this.Panel1.Controls.Add(this.lblModelNo);
		this.Panel1.Controls.Add(this.Label1);
		this.Panel1.Controls.Add(this.lblAcceptance);
		this.Panel1.Controls.Add(this.Panel2);
		this.Panel1.Controls.Add(this.dgTest);
		this.Panel1.Controls.Add(this.dgMethod);
		this.Panel1.Controls.Add(this.lblAttachment);
		this.Panel1.Controls.Add(this.lblTestName);
		this.Panel1.Controls.Add(this.lblPurpose);
		this.Panel1.Controls.Add(this.lblMethod);
		this.Panel1.Controls.Add(this.lblTestResults);
		this.Panel1.Dock = System.Windows.Forms.DockStyle.Top;
		this.Panel1.Location = new System.Drawing.Point(0, 0);
		this.Panel1.Name = "Panel1";
		this.Panel1.Size = new System.Drawing.Size(574, 536);
		this.Panel1.TabIndex = 12;
		//
		//Label2
		//
		this.Label2.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.Label2.ForeColor = System.Drawing.SystemColors.ControlText;
		this.Label2.Location = new System.Drawing.Point(146, 311);
		this.Label2.Name = "Label2";
		this.Label2.Size = new System.Drawing.Size(400, 40);
		this.Label2.TabIndex = 35;
		this.Label2.Text = "In ratio metric method of curve fitting, the curve starts from origin and passes " + "through all points on graph with minimum error.";
		this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//btnTest
		//
		this.btnTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnTest.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnTest.Location = new System.Drawing.Point(168, 354);
		this.btnTest.Name = "btnTest";
		this.btnTest.Size = new System.Drawing.Size(104, 32);
		this.btnTest.TabIndex = 34;
		this.btnTest.Text = "Test";
		//
		//lblModelNo
		//
		this.lblModelNo.Font = new System.Drawing.Font("Times New Roman", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblModelNo.Location = new System.Drawing.Point(184, 40);
		this.lblModelNo.Name = "lblModelNo";
		this.lblModelNo.Size = new System.Drawing.Size(112, 24);
		this.lblModelNo.TabIndex = 33;
		//
		//Label1
		//
		this.Label1.Font = new System.Drawing.Font("Times New Roman", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.Label1.Location = new System.Drawing.Point(8, 40);
		this.Label1.Name = "Label1";
		this.Label1.Size = new System.Drawing.Size(192, 24);
		this.Label1.TabIndex = 28;
		this.Label1.Text = "Equipment / Instrument : ";
		//
		//lblAcceptance
		//
		this.lblAcceptance.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblAcceptance.ForeColor = System.Drawing.SystemColors.ControlText;
		this.lblAcceptance.Location = new System.Drawing.Point(8, 293);
		this.lblAcceptance.Name = "lblAcceptance";
		this.lblAcceptance.Size = new System.Drawing.Size(540, 24);
		this.lblAcceptance.TabIndex = 27;
		this.lblAcceptance.Text = "Acceptance Criteria :     Calibration graph is non linear in most of the cases,";
		this.lblAcceptance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//Panel2
		//
		this.Panel2.BackColor = System.Drawing.Color.AliceBlue;
		this.Panel2.Controls.Add(this.PictureBox1);
		this.Panel2.Controls.Add(this.lblHeader1);
		this.Panel2.Dock = System.Windows.Forms.DockStyle.Top;
		this.Panel2.Location = new System.Drawing.Point(0, 0);
		this.Panel2.Name = "Panel2";
		this.Panel2.Size = new System.Drawing.Size(572, 32);
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
		this.dgTest.Size = new System.Drawing.Size(410, 130);
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
		this.dgMethod.Location = new System.Drawing.Point(8, 136);
		this.dgMethod.Name = "dgMethod";
		this.dgMethod.ParentRowsBackColor = System.Drawing.Color.AliceBlue;
		this.dgMethod.ParentRowsVisible = false;
		this.dgMethod.PreferredRowHeight = 14;
		this.dgMethod.ReadOnly = true;
		this.dgMethod.RowHeadersVisible = false;
		this.dgMethod.SelectionBackColor = System.Drawing.Color.AliceBlue;
		this.dgMethod.SelectionForeColor = System.Drawing.Color.AliceBlue;
		this.dgMethod.Size = new System.Drawing.Size(568, 160);
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
		//frmPQTest4
		//
		this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
		this.AutoScroll = true;
		this.BackColor = System.Drawing.Color.AliceBlue;
		this.ClientSize = new System.Drawing.Size(574, 544);
		this.ControlBox = false;
		this.Controls.Add(this.Panel1);
		this.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		this.MaximizeBox = false;
		this.MinimizeBox = false;
		this.Name = "frmPQTest4";
		this.Text = "PERFORMANCE QUALIFICATION TEST";
		this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
		this.Panel1.ResumeLayout(false);
		this.Panel2.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.dgTest).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dgMethod).EndInit();
		this.ResumeLayout(false);

	}

	#End Region

	#Region " Constants"
	//Private Const ConstTestName As String = "TestName"
	//Private Const ConstSample As String = "Sample"
	private const string ConstAbsorbance = "Absorbance";
	//Private Const ConstTime As String = "Time"
	//Private Const ConstResult As String = "Result"
	//Private Const ConstCriteria As String = "Criteria"
	//Private Const ConstComments As String = "Comments"
	private const string ConstConcentration = "Concentration";

	private const string ConstSampleID = "Standard No";

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

			objDataTable.Columns.Add(new DataColumn(ConstSampleID, typeof(int)));
			objDataTable.Columns.Add(new DataColumn(ConstAbsorbance, typeof(string)));
			objDataTable.Columns.Add(new DataColumn(ConstConcentration, typeof(string)));

			mobjTmpDt = gobjDataAccess.funcGetPQTest3Records();

			if (!mobjTmpDt == null) {
				if (!mobjTmpDt.Rows.Count == 0) {
					for (intCount = 0; intCount <= mobjTmpDt.Rows.Count - 1; intCount++) {
						objDataRow = objDataTable.NewRow;
						objDataRow.Item(ConstSampleID) = mobjTmpDt.Rows.Item(intCount).Item(ConstSampleID);
						objDataRow.Item(ConstAbsorbance) = mobjTmpDt.Rows.Item(intCount).Item(ConstAbsorbance);
						objDataRow.Item(ConstConcentration) = mobjTmpDt.Rows.Item(intCount).Item(ConstConcentration);
						objDataTable.Rows.Add(objDataRow);
					}
				}
			}

			if (IsNothing(objDataTable) == true) {
				throw new Exception("Error in Getting Equipment List Records.");
			} else {
				subFormatTestDataGrid();
			}

			if (gobjDataAccess.funcCheckModeLocked(ENUM_IQOQPQ_STATUS.PQ)) {
				dgTest.ReadOnly = true;
				btnTest.Enabled = false;
				//Added by Pankaj on 6.12.07
			} else {
				dgTest.ReadOnly = false;
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
			objTestGridTableStyle.GridLineColor = Color.Black;
			objTestGridTableStyle.HeaderBackColor = Color.FromArgb(205, 225, 250);
			objTestGridTableStyle.HeaderForeColor = Color.Black;
			objTestGridTableStyle.AlternatingBackColor = Color.AliceBlue;
			objTestGridTableStyle.AllowSorting = false;

			objTestGridTableStyle.MappingName = "PQTest1Result";

			objTextColumn = new DataGridTextBoxColumn();
			objTextColumn.MappingName = ConstSampleID;
			objTextColumn.HeaderText = ConstSampleID;
			objTextColumn.Width = 130;
			objTextColumn.ReadOnly = false;
			objTextColumn.NullText = "";
			objTextColumn.Alignment = HorizontalAlignment.Center;
			objTestGridTableStyle.GridColumnStyles.Add(objTextColumn);

			objTextColumn = new DataGridTextBoxColumn();
			objTextColumn.MappingName = ConstAbsorbance;
			objTextColumn.HeaderText = ConstAbsorbance;
			objTextColumn.Width = 130;
			objTextColumn.ReadOnly = false;
			objTextColumn.NullText = "";
			objTextColumn.Alignment = HorizontalAlignment.Center;
			objTestGridTableStyle.GridColumnStyles.Add(objTextColumn);

			objTextColumn = new DataGridTextBoxColumn();
			objTextColumn.MappingName = ConstConcentration;
			objTextColumn.HeaderText = ConstConcentration;
			objTextColumn.Width = 130;
			objTextColumn.ReadOnly = false;
			objTextColumn.NullText = "";
			objTextColumn.Alignment = HorizontalAlignment.Center;
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
		int intSampleID;
		//Dim strSampleID As String
		//Dim strComments As String
		bool status;
		string strConcentration;
		string strAbsorbance;
		DataView objDataView = new DataView();
		string strTemp;
		try {
			//--- Read the remarks from the grid and save in the database.
			objDataView = dgTest.DataSource;
			if (objDataView.Table.Rows.Count <= 0) {
				return true;
			}

			for (temp_cnt = 0; temp_cnt <= objDataTable.Rows.Count - 1; temp_cnt++) {
				//intSampleID = objDataTable.Rows(temp_cnt).ItemArray.GetValue(objDataTable.Columns.Item("SampleID").Ordinal) '29.1.2010 by dinesh wagh
				intSampleID = objDataTable.Rows(temp_cnt).ItemArray.GetValue(objDataTable.Columns.Item("Standard No").Ordinal);
				//29.1.2010 by dinesh wagh

				//If IsDBNull(objDataTable.Rows(temp_cnt).ItemArray.GetValue(objDataTable.Columns.Item("SampleID").Ordinal)) Then
				//    intSample = 0
				//Else
				//    intSample = objDataTable.Rows(temp_cnt).ItemArray.GetValue(objDataTable.Columns.Item("Sample").Ordinal)
				//End If

				if (IsDBNull(objDataTable.Rows(temp_cnt).ItemArray.GetValue(objDataTable.Columns.Item("Absorbance").Ordinal))) {
					strAbsorbance = "";
				} else {
					strAbsorbance = objDataTable.Rows(temp_cnt).ItemArray.GetValue(objDataTable.Columns.Item("Absorbance").Ordinal);
				}

				if (IsDBNull(objDataTable.Rows(temp_cnt).ItemArray.GetValue(objDataTable.Columns.Item("Concentration").Ordinal))) {
					strConcentration = "";
				} else {
					strConcentration = objDataTable.Rows(temp_cnt).ItemArray.GetValue(objDataTable.Columns.Item("Concentration").Ordinal);
				}

				status = gobjDataAccess.funcUpdatePQTest3Records(intSampleID, strAbsorbance, strConcentration);
				if (!(status)) {
					throw new Exception("Error in Updating PQTest3 Record Details.");
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

	private bool funcUpdatePQTest1Data(int intValidationTestID, int intSample, int intAbsorbance, int intConcentration)
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
			str_sql = " Update PQTest Set" + " PeakArea=?,RT=?,ActualAbsorbance=? " + " Where  ValidationTestID=? and PQTestID=?";

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

	private bool funcUpdatePQTestRemark(int intValidationTestID, string strComments)
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
			str_sql = " Update PQTest1 set " + " PQComments = ? " + " where ValidationTestID =" + intValidationTestID + " and PQTestID = " + enumPQTest.PQ_Test1 + " ";

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
			objCADataTable = new DataTable("PQTest1");
			objCADataTable.Columns.Add(new DataColumn("Name", typeof(string)));

			//--- Format thge method grid
			subFormatDataGrid(objCADataTable);

			//================Modified by Saurabh========================

			//objDataRow = objCADataTable.NewRow()
			//objDataRow("Name") = "A. Chromatographic Condition - "
			//objCADataTable.Rows.Add(objDataRow)

			objDataRow = objCADataTable.NewRow();
			objDataRow("Name") = "1. Use solutions of different concentrations e.g. 1ppm, 2ppm, 3ppm, 4ppm, 5ppm standard.";
			objCADataTable.Rows.Add(objDataRow);

			objDataRow = objCADataTable.NewRow();
			objDataRow("Name") = "2. Aspirate the solutions in ascending order i.e. 1ppm, 2ppm, etc.";
			objCADataTable.Rows.Add(objDataRow);

			objDataRow = objCADataTable.NewRow();
			//'objDataRow("Name") = "3. The graph obtained should be linear passing through origin."
			objDataRow("Name") = "3. Calibration graph obtained is not linear curving towards x-axis from 4ppm onwards.";
			objCADataTable.Rows.Add(objDataRow);

			objDataRow = objCADataTable.NewRow();
			objDataRow("Name") = "4. After conducting the test take printout of calibration graph";
			objCADataTable.Rows.Add(objDataRow);

			objDataRow = objCADataTable.NewRow();
			objDataRow("Name") = " and then return to have printout of complete IQOQPQ.";
			objCADataTable.Rows.Add(objDataRow);

			//code added by ; dinesh wagh on 24.2.2010
			//----------------------------------------------------
			objDataRow = objCADataTable.NewRow;
			objDataRow("Name") = "5. After completion of test please take printout of Calibration Graph from the standard";
			objCADataTable.Rows.Add(objDataRow);

			objDataRow = objCADataTable.NewRow;
			objDataRow("Name") = "  graph window by clicking on print button & attach the document.";
			objCADataTable.Rows.Add(objDataRow);
			//----------------------------------------------------

			//objDataRow = objCADataTable.NewRow()
			//objDataRow("Name") = "4. Detector         : FID."
			//objCADataTable.Rows.Add(objDataRow)

			//objDataRow = objCADataTable.NewRow()
			//objDataRow("Name") = "5. Injection Volume : 1.0 Micro-liter."
			//objCADataTable.Rows.Add(objDataRow)

			//objDataRow = objCADataTable.NewRow()
			//objDataRow("Name") = "6 Temperature       : Oven-80 �C., Injector-150 �C., Detector-180 �C."
			//objCADataTable.Rows.Add(objDataRow)

			//objDataRow = objCADataTable.NewRow()
			//objDataRow("Name") = "7. Range            : 1000 or 10^2."
			//objCADataTable.Rows.Add(objDataRow)

			//objDataRow = objCADataTable.NewRow()
			//objDataRow("Name") = "8. Attenuation      : 512."
			//objCADataTable.Rows.Add(objDataRow)

			//objDataRow = objCADataTable.NewRow()
			//objDataRow("Name") = ""
			//objCADataTable.Rows.Add(objDataRow)

			//objDataRow = objCADataTable.NewRow()
			//objDataRow("Name") = "B. Preparation of standard solution : Make 5% of benzene solution in toluene."
			//objCADataTable.Rows.Add(objDataRow)

			//objDataRow = objCADataTable.NewRow()
			//objDataRow("Name") = "C. Inject 0.5 Micro liter of std. solution 5 replicates and record the chromatograms."
			//objCADataTable.Rows.Add(objDataRow)

			//objDataRow = objCADataTable.NewRow()
			//objDataRow("Name") = "D. Calculate the % RSD of the retention times of benzene from the 5 replicate injection."
			//objCADataTable.Rows.Add(objDataRow)

			//objDataRow = objCADataTable.NewRow()
			//objDataRow("Name") = "E. Calculate the % RSD of the peak areas of benzene from the 5 replicate injection"
			//objCADataTable.Rows.Add(objDataRow)

			//objDataRow = objCADataTable.NewRow()
			//objDataRow("Name") = "F. Calculate the average peak area of benzene from the 5 replicate injection."
			//objCADataTable.Rows.Add(objDataRow)

			//==================Modified by Saurbah=================

			dgMethod.DataSource = objCADataTable;

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

			objGridTableStyle.MappingName = "PQTest1";

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

	#Region " Constant Test Data"


	#End Region

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
		// Created               : 07.07.07
		// Revisions             : 
		//=====================================================================
		try {
			btnTest.Enabled = false;

			//code commented by : dinesh wagh on 24.6.2010
			//To remove the previous result and to load fresh result we have to clear all rows.: suggested by V.C.K
			//---------------------------------------------
			//If objDataTable.Rows.Count = 5 Then
			//    objDataTable.Rows.Clear()
			//    intCounter = 0
			//End If
			//If intCounter < 5 Then
			//    intCounter += 1
			//    RaiseEvent Test_IQOQPQ_AttachmentIII(objDataTable, intCounter)  ', dtParameters)
			//Else
			//    intCounter = 1
			//    objDataTable.Rows.Clear()
			//    RaiseEvent Test_IQOQPQ_AttachmentIII(objDataTable, intCounter)  ', dtParameters)
			//End If
			//------------------------------------------------


			//code added by ; dinesh wagh on 24.6.2010
			//To remove the previous result as new fresh results to be loaded at new analysis.
			//-------------------------------------
			intCounter = 1;
			objDataTable.Rows.Clear();
			if (Test_IQOQPQ_AttachmentIII != null) {
				Test_IQOQPQ_AttachmentIII(objDataTable, intCounter);
			}
			//, dtParameters)
		//-------------------------------------




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
