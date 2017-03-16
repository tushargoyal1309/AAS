using System.Data;
using System.Data.OleDb;
using System.Windows.Forms.DataGridColumnStyle;

public class frmPQTest9 : System.Windows.Forms.Form
{

	#Region " Module level Declarations "
	//Private mstrOledbConnectionString As String
	//Private mobjOleDBconnection As OleDbConnection
	//Private gclsDBFunctions As New clsDatabaseFunctions
		#End Region
	private DataTable objDataTable;

	#Region " Windows Form Designer generated code "

	public frmPQTest9()
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
	internal System.Windows.Forms.Label lblAcceptance;
	[System.Diagnostics.DebuggerStepThrough()]
	private void InitializeComponent()
	{
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmPQTest9));
		this.lblTestResults = new System.Windows.Forms.Label();
		this.lblAttachment = new System.Windows.Forms.Label();
		this.lblMethod = new System.Windows.Forms.Label();
		this.lblPurpose = new System.Windows.Forms.Label();
		this.lblTestName = new System.Windows.Forms.Label();
		this.lblAcceptanceCriteria = new System.Windows.Forms.Label();
		this.lblHeader1 = new System.Windows.Forms.Label();
		this.Panel1 = new System.Windows.Forms.Panel();
		this.lblAcceptance = new System.Windows.Forms.Label();
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
		this.lblTestResults.Size = new System.Drawing.Size(120, 12);
		this.lblTestResults.TabIndex = 18;
		this.lblTestResults.Text = "Observations  :";
		this.lblTestResults.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//lblAttachment
		//
		this.lblAttachment.BackColor = System.Drawing.Color.AliceBlue;
		this.lblAttachment.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblAttachment.ForeColor = System.Drawing.SystemColors.ControlText;
		this.lblAttachment.Location = new System.Drawing.Point(472, 32);
		this.lblAttachment.Name = "lblAttachment";
		this.lblAttachment.Size = new System.Drawing.Size(104, 20);
		this.lblAttachment.TabIndex = 17;
		this.lblAttachment.Text = "Attachment VIII";
		//
		//lblMethod
		//
		this.lblMethod.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblMethod.ForeColor = System.Drawing.SystemColors.ControlText;
		this.lblMethod.Location = new System.Drawing.Point(8, 88);
		this.lblMethod.Name = "lblMethod";
		this.lblMethod.Size = new System.Drawing.Size(450, 18);
		this.lblMethod.TabIndex = 12;
		this.lblMethod.Text = "Method            :  Thermionic Ionization detector  :";
		//
		//lblPurpose
		//
		this.lblPurpose.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblPurpose.ForeColor = System.Drawing.SystemColors.ControlText;
		this.lblPurpose.Location = new System.Drawing.Point(8, 64);
		this.lblPurpose.Name = "lblPurpose";
		this.lblPurpose.Size = new System.Drawing.Size(340, 18);
		this.lblPurpose.TabIndex = 11;
		this.lblPurpose.Text = "Purpose          :   To verify the reproducibility test for system.";
		//
		//lblTestName
		//
		this.lblTestName.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblTestName.ForeColor = System.Drawing.SystemColors.ControlText;
		this.lblTestName.Location = new System.Drawing.Point(8, 40);
		this.lblTestName.Name = "lblTestName";
		this.lblTestName.Size = new System.Drawing.Size(350, 18);
		this.lblTestName.TabIndex = 10;
		this.lblTestName.Text = "Test Name    :   Retention time and Area reproducibility test.";
		//
		//lblAcceptanceCriteria
		//
		this.lblAcceptanceCriteria.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblAcceptanceCriteria.ForeColor = System.Drawing.SystemColors.ControlText;
		this.lblAcceptanceCriteria.Location = new System.Drawing.Point(8, 300);
		this.lblAcceptanceCriteria.Name = "lblAcceptanceCriteria";
		this.lblAcceptanceCriteria.Size = new System.Drawing.Size(132, 12);
		this.lblAcceptanceCriteria.TabIndex = 8;
		this.lblAcceptanceCriteria.Text = "Acceptance Criteria  :";
		this.lblAcceptanceCriteria.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//lblHeader1
		//
		this.lblHeader1.Font = new System.Drawing.Font("Arial", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblHeader1.ForeColor = System.Drawing.SystemColors.ControlText;
		this.lblHeader1.Location = new System.Drawing.Point(35, 7);
		this.lblHeader1.Name = "lblHeader1";
		this.lblHeader1.Size = new System.Drawing.Size(541, 18);
		this.lblHeader1.TabIndex = 7;
		this.lblHeader1.Text = "E.II PERFORMANCE TESTING AND QUALIFICATION INSTALLATION ";
		this.lblHeader1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//Panel1
		//
		this.Panel1.BackColor = System.Drawing.Color.AliceBlue;
		this.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.Panel1.Controls.Add(this.lblAcceptance);
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
		this.Panel1.Size = new System.Drawing.Size(312, 510);
		this.Panel1.TabIndex = 12;
		//
		//lblAcceptance
		//
		this.lblAcceptance.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblAcceptance.ForeColor = System.Drawing.SystemColors.ControlText;
		this.lblAcceptance.Location = new System.Drawing.Point(8, 320);
		this.lblAcceptance.Name = "lblAcceptance";
		this.lblAcceptance.Size = new System.Drawing.Size(500, 12);
		this.lblAcceptance.TabIndex = 27;
		this.lblAcceptance.Text = "The % RSD of retention time of benzene from 5 replicate injection should be less " + "than 2 %";
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
		this.Panel2.Size = new System.Drawing.Size(310, 32);
		this.Panel2.TabIndex = 26;
		this.Panel2.TabStop = true;
		//
		//PictureBox1
		//
		this.PictureBox1.Image = (System.Drawing.Image)resources.GetObject("PictureBox1.Image");
		this.PictureBox1.Location = new System.Drawing.Point(0, 0);
		this.PictureBox1.Name = "PictureBox1";
		this.PictureBox1.Size = new System.Drawing.Size(30, 30);
		this.PictureBox1.TabIndex = 0;
		this.PictureBox1.TabStop = false;
		//
		//lblSpecifiedBaselineResult
		//
		this.lblSpecifiedBaselineResult.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblSpecifiedBaselineResult.ForeColor = System.Drawing.SystemColors.ControlText;
		this.lblSpecifiedBaselineResult.Location = new System.Drawing.Point(8, 340);
		this.lblSpecifiedBaselineResult.Name = "lblSpecifiedBaselineResult";
		this.lblSpecifiedBaselineResult.Size = new System.Drawing.Size(500, 12);
		this.lblSpecifiedBaselineResult.TabIndex = 25;
		this.lblSpecifiedBaselineResult.Text = "The % RSD of peak areas of benzene from 5 replicate injection should be less than" + " 2 %";
		this.lblSpecifiedBaselineResult.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//dgTest
		//
		this.dgTest.AlternatingBackColor = System.Drawing.Color.AliceBlue;
		this.dgTest.BackColor = System.Drawing.Color.AliceBlue;
		this.dgTest.BackgroundColor = System.Drawing.Color.AliceBlue;
		this.dgTest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.dgTest.CaptionVisible = false;
		this.dgTest.DataMember = "";
		this.dgTest.HeaderForeColor = System.Drawing.SystemColors.ControlText;
		this.dgTest.Location = new System.Drawing.Point(8, 380);
		this.dgTest.Name = "dgTest";
		this.dgTest.ParentRowsVisible = false;
		this.dgTest.ReadOnly = true;
		this.dgTest.RowHeadersVisible = false;
		this.dgTest.Size = new System.Drawing.Size(568, 130);
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
		this.dgMethod.Location = new System.Drawing.Point(8, 112);
		this.dgMethod.Name = "dgMethod";
		this.dgMethod.ParentRowsBackColor = System.Drawing.Color.AliceBlue;
		this.dgMethod.ParentRowsVisible = false;
		this.dgMethod.PreferredRowHeight = 14;
		this.dgMethod.ReadOnly = true;
		this.dgMethod.RowHeadersVisible = false;
		this.dgMethod.SelectionBackColor = System.Drawing.Color.AliceBlue;
		this.dgMethod.SelectionForeColor = System.Drawing.Color.AliceBlue;
		this.dgMethod.Size = new System.Drawing.Size(568, 180);
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
		//frmPQTest9
		//
		this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
		this.AutoScroll = true;
		this.BackColor = System.Drawing.Color.AliceBlue;
		this.ClientSize = new System.Drawing.Size(312, 424);
		this.ControlBox = false;
		this.Controls.Add(this.Panel1);
		this.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		this.MaximizeBox = false;
		this.MinimizeBox = false;
		this.Name = "frmPQTest9";
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
	//Private Const ConstTestName As String = "TestName"
	private const string ConstRT = "RT";
	private const string ConstPeakArea = "PeakArea";
	//Private Const ConstTime As String = "Time"
	//Private Const ConstResult As String = "Result"
	//Private Const ConstCriteria As String = "Criteria"
	//Private Const ConstComments As String = "Comments"

	private const string ConstTestID = "TestID";
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

			objDataTable.Columns.Add("RT");
			objDataTable.Columns.Add("PeakArea");
			objDataTable.Columns.Add("TestID");


			mobjTmpDt = gobjDataAccess.funcGetPQTest8Records();

			if (!mobjTmpDt == null) {
				if (!mobjTmpDt.Rows.Count == 0) {
					for (intCount = 0; intCount <= mobjTmpDt.Rows.Count - 1; intCount++) {
						objDataRow = objDataTable.NewRow;
						//If CInt(mobjTmpDt.Rows.Item(intCount).Item("ValidationTestID")) = 6 Then
						//    objDataRow.Item(ConstTestID) = "Average"
						//ElseIf CInt(mobjTmpDt.Rows.Item(intCount).Item("ValidationTestID")) = 7 Then
						//    objDataRow.Item(ConstTestID) = "% RSD"
						//ElseIf CInt(mobjTmpDt.Rows.Item(intCount).Item("ValidationTestID")) = 8 Then
						//    objDataRow.Item(ConstTestID) = "Results"
						//Else
						objDataRow.Item(ConstTestID) = mobjTmpDt.Rows.Item(intCount).Item("ValidationTestID");
						//End If

						objDataRow.Item(ConstRT) = Format(Val(mobjTmpDt.Rows.Item(intCount).Item("RT")), "#0.0");
						objDataRow.Item(ConstPeakArea) = Format(Val(mobjTmpDt.Rows.Item(intCount).Item("PeakArea")), "#0.0");
						objDataTable.Rows.Add(objDataRow);

					}
				}
			}

			if (IsNothing(objDataTable) == true) {
				throw new Exception("Error in Getting Equipment List Records.");
			} else {
				//objDataRow = objDataTable.NewRow
				//objDataRow.Item(ConstTestID) = "Average"
				//objDataRow.Item(ConstRT) = (mobjTmpDt.Rows.Item(0).Item("RT") + mobjTmpDt.Rows.Item(1).Item("RT") + mobjTmpDt.Rows.Item(2).Item("RT") & _
				//+mobjTmpDt.Rows.Item(3).Item("RT") + mobjTmpDt.Rows.Item(4).Item("RT")) / 5
				//objDataRow.Item(ConstPeakArea) = (mobjTmpDt.Rows.Item(0).Item("PeakArea") + mobjTmpDt.Rows.Item(1).Item("PeakArea") + mobjTmpDt.Rows.Item(2).Item("PeakArea") & _
				//+mobjTmpDt.Rows.Item(3).Item("PeakArea") + mobjTmpDt.Rows.Item(4).Item("PeakArea")) / 5
				//objDataTable.Rows.Add(objDataRow)

				//objDataRow = objDataTable.NewRow
				//objDataRow.Item(ConstTestID) = "% RSD"
				//objDataRow.Item(ConstRT) = 0
				//objDataRow.Item(ConstPeakArea) = 0
				//objDataTable.Rows.Add(objDataRow)

				//objDataRow = objDataTable.NewRow
				//objDataRow.Item(ConstTestID) = "Results"
				//objDataRow.Item(ConstRT) = 0
				//objDataRow.Item(ConstPeakArea) = 0
				//objDataTable.Rows.Add(objDataRow)

				subFormatTestDataGrid();
			}

			//str_sql = "Select * from PQTest1 where PQTestID = " & enumPQTest.PQ_Test1

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
			objTestGridTableStyle.HeaderBackColor = Color.LightSkyBlue;
			objTestGridTableStyle.HeaderForeColor = Color.Black;
			objTestGridTableStyle.AlternatingBackColor = Color.AliceBlue;
			objTestGridTableStyle.AllowSorting = false;

			objTestGridTableStyle.MappingName = "PQTest1Result";

			objTextColumn = new DataGridTextBoxColumn();
			objTextColumn.MappingName = "TestID";
			objTextColumn.HeaderText = "Injection no.";
			objTextColumn.Width = 130;
			objTextColumn.ReadOnly = true;
			objTextColumn.NullText = "";
			objTestGridTableStyle.GridColumnStyles.Add(objTextColumn);

			objTextColumn = new DataGridTextBoxColumn();
			objTextColumn.MappingName = "RT";
			objTextColumn.HeaderText = "Retention Time";
			objTextColumn.Width = 130;
			objTextColumn.ReadOnly = false;
			objTextColumn.NullText = "";
			objTestGridTableStyle.GridColumnStyles.Add(objTextColumn);

			objTextColumn = new DataGridTextBoxColumn();
			objTextColumn.MappingName = "PeakArea";
			objTextColumn.HeaderText = "Peak Area";
			objTextColumn.Width = 130;
			objTextColumn.ReadOnly = false;
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
		string strValidationTestID;
		bool status;
		double dblRT;
		double dblPeakArea;
		DataView objDataView = new DataView();
		string strTemp;
		try {
			//--- Read the remarks from the grid and save in the database.
			objDataView = dgTest.DataSource;
			if (objDataView.Table.Rows.Count <= 0) {
				return true;
			}

			for (temp_cnt = 0; temp_cnt <= objDataTable.Rows.Count - 1; temp_cnt++) {
				//If temp_cnt > 4 Then
				//    strTemp = objDataTable.Rows(temp_cnt).ItemArray.GetValue(objDataTable.Columns.Item("TestID").Ordinal)
				//    If strTemp = "Average" Then
				//        intValidationTestID = 6
				//    ElseIf strTemp = "% RSD" Then
				//        intValidationTestID = 7
				//    ElseIf strTemp = "Results" Then
				//        intValidationTestID = 8
				//    End If
				//Else
				strValidationTestID = objDataTable.Rows(temp_cnt).ItemArray.GetValue(objDataTable.Columns.Item("TestID").Ordinal);
				//End If

				if (IsDBNull(objDataTable.Rows(temp_cnt).ItemArray.GetValue(objDataTable.Columns.Item("RT").Ordinal))) {
					dblRT = 0;
				} else {
					dblRT = objDataTable.Rows(temp_cnt).ItemArray.GetValue(objDataTable.Columns.Item("RT").Ordinal);
				}

				if (IsDBNull(objDataTable.Rows(temp_cnt).ItemArray.GetValue(objDataTable.Columns.Item("PeakArea").Ordinal))) {
					dblPeakArea = 0;
				} else {
					dblPeakArea = objDataTable.Rows(temp_cnt).ItemArray.GetValue(objDataTable.Columns.Item("PeakArea").Ordinal);
				}

				status = gobjDataAccess.funcUpdatePQTest8Records(dblRT, dblPeakArea, strValidationTestID);
				if (!(status)) {
					throw new Exception("Error in Updating PQTest3 Record Details.");
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

	private bool funcUpdatePQTest1Data(int intValidationTestID, double dblResult, double dblSpecifiedCriteria, string strRemarks)
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
			str_sql = " Update PQTest1 Set" + " PQAbsorbance=?,PQCriteria=?,PQComments=? " + " Where  ValidationTestID=? and PQTestID=?";

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

			objDataRow = objCADataTable.NewRow();
			objDataRow("Name") = "A. Chromatographic Condition - ";
			//objCADataTable.Columns.Item(0) 
			objCADataTable.Rows.Add(objDataRow);

			objDataRow = objCADataTable.NewRow();
			objDataRow("Name") = "1. Column           : 5 % SE-30 S.S.Column size 4'x1/4'' OD,80/100 Mesh or Suitable Equivalent Capillary column.";
			objCADataTable.Rows.Add(objDataRow);

			objDataRow = objCADataTable.NewRow();
			objDataRow("Name") = "2. Carrier Gas      : Nitrogen.";
			objCADataTable.Rows.Add(objDataRow);

			objDataRow = objCADataTable.NewRow();
			objDataRow("Name") = "3. Flow Rate        : N2 - 30 ml/min, H2 - 30 ml/min, Air - 80 ml/min for capillary column flow, refer to the column manufacturer's instruction.";
			objCADataTable.Rows.Add(objDataRow);

			objDataRow = objCADataTable.NewRow();
			objDataRow("Name") = "4. Detector         : TID.";
			objCADataTable.Rows.Add(objDataRow);

			objDataRow = objCADataTable.NewRow();
			objDataRow("Name") = "5. Injection Volume : 1.0 Micro-liter. Use suitable split ratio for capillary system.";
			objCADataTable.Rows.Add(objDataRow);

			objDataRow = objCADataTable.NewRow();
			objDataRow("Name") = "6 Temperature       : Oven-190 �C., Injector-230 �C., Detector-270 �C.";
			objCADataTable.Rows.Add(objDataRow);

			objDataRow = objCADataTable.NewRow();
			objDataRow("Name") = "7. Range            : Current 3.2 nA on TID power supply unit.";
			objCADataTable.Rows.Add(objDataRow);

			objDataRow = objCADataTable.NewRow();
			objDataRow("Name") = "8. Attenuation      : 64.";
			objCADataTable.Rows.Add(objDataRow);

			objDataRow = objCADataTable.NewRow();
			objDataRow("Name") = "";
			objCADataTable.Rows.Add(objDataRow);

			objDataRow = objCADataTable.NewRow();
			objDataRow("Name") = "B. Preparation of standard solution : Make 2.0 ppm Methyl Parathion solution in isoctane.";
			objCADataTable.Rows.Add(objDataRow);

			objDataRow = objCADataTable.NewRow();
			objDataRow("Name") = "C. Inject 0.5 Micro liter of std. solution 5 replicates and record the chromatograms.";
			objCADataTable.Rows.Add(objDataRow);

			objDataRow = objCADataTable.NewRow();
			objDataRow("Name") = "D. Calculate the % RSD of the retention times of Methyl Parathion from the 5 replicate injection.";
			objCADataTable.Rows.Add(objDataRow);

			objDataRow = objCADataTable.NewRow();
			objDataRow("Name") = "E. Calculate the % RSD of the peak areas of Methyl Parathion from the 5 replicate injection.";
			objCADataTable.Rows.Add(objDataRow);

			objDataRow = objCADataTable.NewRow();
			objDataRow("Name") = "F. Calculate the average peak area of Methyl Parathion from the 5 replicate injection";
			objCADataTable.Rows.Add(objDataRow);

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

	#Region "Constant Test Data"


	#End Region

}
