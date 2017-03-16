
using System.Data;
using System.Data.OleDb;
using ErrorHandler.ErrorHandler;

public class frmOQTest : System.Windows.Forms.Form
{

	#Region " Module level Declarations "
	private bool mblnModeLockStatus;
	private string mstrOledbConnectionString;
	private OleDbConnection mobjOleDBconnection;
	//Private mclsDBFunctions As New clsDatabaseFunctions

	private const  CONST_Test1StartID = 1;
	private const  CONST_Test1EndID = 2;
	private const  CONST_Test2StartID = 3;
	private const  CONST_Test2EndID = 3;
	private const  CONST_Test3StartID = 4;

	private const  CONST_Test3EndID = 5;
	private const string ConstTestName = "TestName";
	private const string ConstDemoDate = "DemoDate";
	private const string ConstVerifiedDate = "VerifiedDate";
	private const string ConstObservation = "Observation";

	private const string ConstTestID = "TestID";
	private DataTable mobjTest1DataTable;
	private DataTable mobjTest2DataTable;
	private DataTable mobjTest3DataTable;
	 mobjTest1GridTableStyle;
	 mobjTest2GridTableStyle;

	DataGridTableStyle mobjTest3GridTableStyle = new DataGridTableStyle();
	//Private Enum ENUM_TestNos
	//    TestNo1 = 1
	//    TestNo2 = 2
	//    TestNo3 = 3
	//End Enum

	DateTimePicker mdtpDate;
	DateTimePicker mdtpDate2;
	DateTimePicker mdtpDate3;
	private const  CONST_DemoColumnNo = 2;

	private const  CONST_VerifyColumnNo = 3;
	//code added by ; dinesh wagh on 29.6.2010
	//---------------------------------------------
	int mintRowIndex1;
	int mintColumnIndex1;
	int mintRowIndex2;

	int mintColumnIndex2;
	bool mblnAvoidProcessing;
	private const  CONST_COMMENT_COLUMN_NO = 1;
	//----------------------------------------

	#End Region

	#Region " Windows Form Designer generated code "

	public frmOQTest()
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
	internal System.Windows.Forms.Label lblHeader;
	internal System.Windows.Forms.Label lblHeader2;
	internal System.Windows.Forms.Label lblTestName1;
	internal System.Windows.Forms.Label lblPurpose1;
	internal System.Windows.Forms.Label lblPurpose3;
	internal System.Windows.Forms.Label lblTestName3;
	internal System.Windows.Forms.Label lblPurpose2;
	internal System.Windows.Forms.Label lblTestName2;
	internal System.Windows.Forms.Panel Panel1;
	internal System.Windows.Forms.DataGrid dgTest1;
	internal System.Windows.Forms.DataGrid dgTest2;
	internal System.Windows.Forms.DataGrid dgTest3;
	internal System.Windows.Forms.Panel Panel2;
	internal System.Windows.Forms.PictureBox PictureBox1;
	internal System.Windows.Forms.Label Label1;
	internal System.Windows.Forms.Label lblModelNo;
	[System.Diagnostics.DebuggerStepThrough()]
	private void InitializeComponent()
	{
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmOQTest));
		this.lblHeader = new System.Windows.Forms.Label();
		this.lblHeader2 = new System.Windows.Forms.Label();
		this.lblTestName1 = new System.Windows.Forms.Label();
		this.lblPurpose1 = new System.Windows.Forms.Label();
		this.lblPurpose3 = new System.Windows.Forms.Label();
		this.lblTestName3 = new System.Windows.Forms.Label();
		this.lblPurpose2 = new System.Windows.Forms.Label();
		this.lblTestName2 = new System.Windows.Forms.Label();
		this.Panel1 = new System.Windows.Forms.Panel();
		this.lblModelNo = new System.Windows.Forms.Label();
		this.Label1 = new System.Windows.Forms.Label();
		this.Panel2 = new System.Windows.Forms.Panel();
		this.PictureBox1 = new System.Windows.Forms.PictureBox();
		this.dgTest3 = new System.Windows.Forms.DataGrid();
		this.dgTest2 = new System.Windows.Forms.DataGrid();
		this.dgTest1 = new System.Windows.Forms.DataGrid();
		this.Panel1.SuspendLayout();
		this.Panel2.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.dgTest3).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dgTest2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dgTest1).BeginInit();
		this.SuspendLayout();
		//
		//lblHeader
		//
		this.lblHeader.BackColor = System.Drawing.Color.AliceBlue;
		this.lblHeader.Font = new System.Drawing.Font("Arial", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblHeader.Location = new System.Drawing.Point(35, 7);
		this.lblHeader.Name = "lblHeader";
		this.lblHeader.Size = new System.Drawing.Size(440, 18);
		this.lblHeader.TabIndex = 13;
		this.lblHeader.Text = "D.II OPERATIONAL QUALIFICATION  TESTS";
		this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//lblHeader2
		//
		this.lblHeader2.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblHeader2.Location = new System.Drawing.Point(8, 48);
		this.lblHeader2.Name = "lblHeader2";
		this.lblHeader2.Size = new System.Drawing.Size(528, 32);
		this.lblHeader2.TabIndex = 14;
		this.lblHeader2.Text = "If an Equipment / instrument consist of more than one module, this data sheet sha" + "ll be generated as per the requirement and shall be attached herewith.";
		//
		//lblTestName1
		//
		this.lblTestName1.Location = new System.Drawing.Point(8, 112);
		this.lblTestName1.Name = "lblTestName1";
		this.lblTestName1.Size = new System.Drawing.Size(264, 18);
		this.lblTestName1.TabIndex = 15;
		this.lblTestName1.Text = "Test Name : Instrument setup, menus, display";
		//
		//lblPurpose1
		//
		this.lblPurpose1.Location = new System.Drawing.Point(8, 136);
		this.lblPurpose1.Name = "lblPurpose1";
		this.lblPurpose1.Size = new System.Drawing.Size(392, 18);
		this.lblPurpose1.TabIndex = 16;
		this.lblPurpose1.Text = "Purpose      : Introduction and Familiarisation with routine operation.";
		//
		//lblPurpose3
		//
		this.lblPurpose3.Location = new System.Drawing.Point(8, 424);
		this.lblPurpose3.Name = "lblPurpose3";
		this.lblPurpose3.Size = new System.Drawing.Size(400, 18);
		this.lblPurpose3.TabIndex = 22;
		this.lblPurpose3.Text = "Purpose      : Introduction and Familiarisation with routine operation.";
		//
		//lblTestName3
		//
		this.lblTestName3.Location = new System.Drawing.Point(8, 400);
		this.lblTestName3.Name = "lblTestName3";
		this.lblTestName3.Size = new System.Drawing.Size(448, 18);
		this.lblTestName3.TabIndex = 21;
		this.lblTestName3.Text = "Test Name : Installation of HC Lamp and Acetylene or Nitrous Oxide Burner.";
		//
		//lblPurpose2
		//
		this.lblPurpose2.Location = new System.Drawing.Point(8, 288);
		this.lblPurpose2.Name = "lblPurpose2";
		this.lblPurpose2.Size = new System.Drawing.Size(400, 18);
		this.lblPurpose2.TabIndex = 25;
		this.lblPurpose2.Text = "Purpose      : Introduction and Familiarisation with routine operation.";
		//
		//lblTestName2
		//
		this.lblTestName2.Location = new System.Drawing.Point(8, 264);
		this.lblTestName2.Name = "lblTestName2";
		this.lblTestName2.Size = new System.Drawing.Size(264, 18);
		this.lblTestName2.TabIndex = 24;
		this.lblTestName2.Text = "Test Name : Basic Operation Procedure";
		//
		//Panel1
		//
		this.Panel1.BackColor = System.Drawing.Color.AliceBlue;
		this.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.Panel1.Controls.Add(this.lblModelNo);
		this.Panel1.Controls.Add(this.Label1);
		this.Panel1.Controls.Add(this.Panel2);
		this.Panel1.Controls.Add(this.dgTest3);
		this.Panel1.Controls.Add(this.dgTest2);
		this.Panel1.Controls.Add(this.dgTest1);
		this.Panel1.Controls.Add(this.lblHeader2);
		this.Panel1.Controls.Add(this.lblTestName1);
		this.Panel1.Controls.Add(this.lblPurpose1);
		this.Panel1.Controls.Add(this.lblTestName2);
		this.Panel1.Controls.Add(this.lblPurpose2);
		this.Panel1.Controls.Add(this.lblTestName3);
		this.Panel1.Controls.Add(this.lblPurpose3);
		this.Panel1.Dock = System.Windows.Forms.DockStyle.Top;
		this.Panel1.Location = new System.Drawing.Point(0, 0);
		this.Panel1.Name = "Panel1";
		this.Panel1.Size = new System.Drawing.Size(496, 560);
		this.Panel1.TabIndex = 90;
		//
		//lblModelNo
		//
		this.lblModelNo.Font = new System.Drawing.Font("Times New Roman", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblModelNo.Location = new System.Drawing.Point(192, 83);
		this.lblModelNo.Name = "lblModelNo";
		this.lblModelNo.Size = new System.Drawing.Size(176, 24);
		this.lblModelNo.TabIndex = 31;
		//
		//Label1
		//
		this.Label1.Font = new System.Drawing.Font("Times New Roman", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.Label1.Location = new System.Drawing.Point(8, 82);
		this.Label1.Name = "Label1";
		this.Label1.Size = new System.Drawing.Size(192, 24);
		this.Label1.TabIndex = 30;
		this.Label1.Text = "Equipment / Instrument :";
		//
		//Panel2
		//
		this.Panel2.BackColor = System.Drawing.Color.AliceBlue;
		this.Panel2.Controls.Add(this.PictureBox1);
		this.Panel2.Controls.Add(this.lblHeader);
		this.Panel2.Dock = System.Windows.Forms.DockStyle.Top;
		this.Panel2.Location = new System.Drawing.Point(0, 0);
		this.Panel2.Name = "Panel2";
		this.Panel2.Size = new System.Drawing.Size(494, 32);
		this.Panel2.TabIndex = 28;
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
		//dgTest3
		//
		this.dgTest3.BackgroundColor = System.Drawing.Color.AliceBlue;
		this.dgTest3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.dgTest3.CaptionVisible = false;
		this.dgTest3.DataMember = "";
		this.dgTest3.HeaderForeColor = System.Drawing.SystemColors.ControlText;
		this.dgTest3.Location = new System.Drawing.Point(8, 448);
		this.dgTest3.Name = "dgTest3";
		this.dgTest3.ParentRowsVisible = false;
		this.dgTest3.ReadOnly = true;
		this.dgTest3.RowHeadersVisible = false;
		this.dgTest3.Size = new System.Drawing.Size(568, 60);
		this.dgTest3.TabIndex = 27;
		//
		//dgTest2
		//
		this.dgTest2.BackgroundColor = System.Drawing.Color.AliceBlue;
		this.dgTest2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.dgTest2.CaptionVisible = false;
		this.dgTest2.DataMember = "";
		this.dgTest2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
		this.dgTest2.Location = new System.Drawing.Point(8, 312);
		this.dgTest2.Name = "dgTest2";
		this.dgTest2.ParentRowsVisible = false;
		this.dgTest2.ReadOnly = true;
		this.dgTest2.RowHeadersVisible = false;
		this.dgTest2.Size = new System.Drawing.Size(568, 73);
		this.dgTest2.TabIndex = 26;
		//
		//dgTest1
		//
		this.dgTest1.BackgroundColor = System.Drawing.Color.AliceBlue;
		this.dgTest1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.dgTest1.CaptionVisible = false;
		this.dgTest1.DataMember = "";
		this.dgTest1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
		this.dgTest1.Location = new System.Drawing.Point(8, 160);
		this.dgTest1.Name = "dgTest1";
		this.dgTest1.ParentRowsVisible = false;
		this.dgTest1.ReadOnly = true;
		this.dgTest1.RowHeadersVisible = false;
		this.dgTest1.Size = new System.Drawing.Size(568, 92);
		this.dgTest1.TabIndex = 18;
		//
		//frmOQTest
		//
		this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
		this.AutoScroll = true;
		this.BackColor = System.Drawing.Color.AliceBlue;
		this.ClientSize = new System.Drawing.Size(496, 560);
		this.ControlBox = false;
		this.Controls.Add(this.Panel1);
		this.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		this.MaximizeBox = false;
		this.MinimizeBox = false;
		this.Name = "frmOQTest";
		this.Text = "Operational Qualification Tests";
		this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
		this.Panel1.ResumeLayout(false);
		this.Panel2.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.dgTest3).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dgTest2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dgTest1).EndInit();
		this.ResumeLayout(false);

	}

	#End Region

	#Region " Form Events "
	private void  // ERROR: Handles clauses are not supported in C#
frmOQTest_Load(object sender, System.EventArgs e)
	{
		try {
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
frmOQTest_Closing(object sender, System.ComponentModel.CancelEventArgs e)
	{
		try {
			if (!(mblnModeLockStatus)) {
				dgTest1.CurrentCell() = (new DataGridCell(dgTest1.CurrentRowIndex + 1, 0));
				if (!funcSaveOQTest1Data(ENUM_TestNos.TestNo1)) {
					throw new Exception("Error in Saving OQ Test Data.");
				}
				dgTest1.TableStyles.Clear();

				dgTest2.CurrentCell() = (new DataGridCell(dgTest2.CurrentRowIndex + 1, 0));
				if (!funcSaveOQTest1Data(ENUM_TestNos.TestNo2)) {
					throw new Exception("Error in Saving OQ Test Data.");
				}
				dgTest2.TableStyles.Clear();

				dgTest3.CurrentCell() = (new DataGridCell(dgTest3.CurrentRowIndex + 1, 0));
				if (!funcSaveOQTest1Data(ENUM_TestNos.TestNo3)) {
					throw new Exception("Error in Saving OQ Test Data.");
				}
				dgTest3.TableStyles.Clear();
			}
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.ProcessError(EnumErrorType.Critical, ex);
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
	//--- funcInitialize - To Initialize form and to get values for OQ Tests List from database and display them.
	//--- funcGetOQTest1Records - To Get OQ Test Records from Database and display them.
	//--- funcGetOQTest1Details - To Get OQ Test Records from Database for the given ID.
	//--- funcAssignValuesToControls - To Assign values to controls on form. 
	//--- funcSaveOQTest1Data - To Save the Entered Records into Database.
	//--- funcGetObservationFromControls - To Get values from text box controls on form. 
	//--- funcGetDemoDateFromControls - To Get values from Date Time Picker controls on form. 
	//--- funcGetVerifiedDateFromControls - To Get values from Date Time Picker controls on form. 
	//--- funcInsertOQTest1Data - To Add/Insert New Test Data in Database.
	//--- funcUpdateOQTest1Data - To Update OTest Data in Database.
	//--- funcDeleteOQTest1Data - To Delete OQ Test Data from Database.

	private void funcInitialize()
	{
		//=====================================================================
		// Procedure Name        :   funcInitailize
		// Description           :   To Initialize form and to get values for OQ Tests List from database and display them.
		// Purpose               :   To Initialize form and to get values for OQ Tests List from database and display them.
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
			//mfrmOQTest = Me
			//Added by Pankaj on 19 May 2007
			lblModelNo.Text = gobjModelNo;
			mobjTest1DataTable = new DataTable("Test1");
			mobjTest2DataTable = new DataTable("Test2");
			mobjTest3DataTable = new DataTable("Test3");

			mdtpDate = new DateTimePicker();
			mdtpDate2 = new DateTimePicker();
			mdtpDate3 = new DateTimePicker();

			//--- To Add Run-Time DateTime Picker Control
			//AddHandler mdtpDate.ValueChanged, AddressOf dtpDate_ValueChanged '30.6.2010 by dinesh wagh
			mdtpDate.LostFocus += dtpDate_LostFocus;
			//30.6.2010 by dinesh wagh


			dgTest1.Controls.Add(mdtpDate);
			mdtpDate.Visible = false;
			mdtpDate.Format = DateTimePickerFormat.Custom;
			mdtpDate.CustomFormat = "dd-MMM-yyyy";

			//AddHandler mdtpDate2.ValueChanged, AddressOf dtpDate2_ValueChanged '30.6.2010 by dinesh wagh
			mdtpDate2.LostFocus += dtpDate2_LostFocus;
			//30.6.2010 by dinesh wagh





			dgTest2.Controls.Add(mdtpDate2);
			mdtpDate2.Visible = false;
			mdtpDate2.Format = DateTimePickerFormat.Custom;
			mdtpDate2.CustomFormat = "dd-MMM-yyyy";

			//AddHandler mdtpDate3.ValueChanged, AddressOf dtpDate3_ValueChanged '30.6.2010 by dinesh wagh
			mdtpDate3.LostFocus += dtpDate3_LostFocus;
			//30.6.2010 by dinesh wagh

			dgTest3.Controls.Add(mdtpDate3);
			mdtpDate3.Visible = false;
			mdtpDate3.Format = DateTimePickerFormat.Custom;
			mdtpDate3.CustomFormat = "dd-MMM-yyyy";

			subCreateDataTable(mobjTest1DataTable);
			subCreateDataTable(mobjTest2DataTable);
			subCreateDataTable(mobjTest3DataTable);

			if (funcGetOQTest1Records(ENUM_TestNos.TestNo1)) {
				subFormatDataGrid(mobjTest1GridTableStyle, dgTest1, mobjTest1DataTable);
			} else {
				throw new Exception("Error in Getting Test Records.");
			}

			if (funcGetOQTest1Records(ENUM_TestNos.TestNo2)) {
				subFormatDataGrid(mobjTest2GridTableStyle, dgTest2, mobjTest2DataTable);
			} else {
				throw new Exception("Error in Getting Test Records.");
			}

			if (funcGetOQTest1Records(ENUM_TestNos.TestNo3)) {
				subFormatDataGrid(mobjTest3GridTableStyle, dgTest3, mobjTest3DataTable);
			} else {
				throw new Exception("Error in Getting Test Records.");
			}

			mblnModeLockStatus = gobjDataAccess.funcCheckModeLocked(ENUM_IQOQPQ_STATUS.OQ);
			if ((mblnModeLockStatus)) {
				dgTest1.ReadOnly = true;
				dgTest2.ReadOnly = true;
				dgTest3.ReadOnly = true;
			} else {
				dgTest1.ReadOnly = false;
				dgTest2.ReadOnly = false;
				dgTest3.ReadOnly = false;
			}
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.ProcessError(EnumErrorType.Critical, ex);
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

	private void dtpDate_LostFocus(System.Object sender, System.EventArgs e)
	{
		//sub name change by : dinesh wagh on 30.6.2010
		try {
			dgTest1(dgTest1.CurrentCell.RowNumber, dgTest1.CurrentCell.ColumnNumber) = mdtpDate.Value;
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

	private void dtpDate2_LostFocus(System.Object sender, System.EventArgs e)
	{
		//Sub name change by dinesh wagh on 30.6.2010
		try {
			dgTest2(dgTest2.CurrentCell.RowNumber, dgTest2.CurrentCell.ColumnNumber) = mdtpDate2.Value;
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

	private void dtpDate3_LostFocus(System.Object sender, System.EventArgs e)
	{
		//sub name change by : dinesh wagh on 30.6.2010
		try {
			dgTest3(dgTest3.CurrentCell.RowNumber, dgTest3.CurrentCell.ColumnNumber) = mdtpDate3.Value;
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

	private void subCreateDataTable(ref DataTable objDataTable)
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

		try {
			objDataTable.Columns.Add(new DataColumn("TestName", typeof(string)));
			objDataTable.Columns.Add(new DataColumn("Observation", typeof(string)));
			objDataTable.Columns.Add(new DataColumn("DemoDate", typeof(System.DateTime)));
			objDataTable.Columns.Add(new DataColumn("VerifiedDate", typeof(System.DateTime)));
			objDataTable.Columns.Add(new DataColumn("TestID", typeof(int)));

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = "Error in Creating Test Data-Table.";
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

	private bool funcGetOQTest1Records(int testnos)
	{
		//=====================================================================
		// Procedure Name        :   funcGetOQTest1Records
		// Description           :   To Get OQ Test Records from Database and display them.
		// Purpose               :   To Get OQ Test Records from Database and display them.
		// Parameters Passed     :   None.
		// Returns               :   None.
		// Parameters Affected   :   None.
		// Assumptions           :
		// Dependencies          :
		// Author                :   
		// Created               :   January, 2003 
		// Revisions             :
		//=====================================================================

		DataRow objDataRow;
		int testID;
		int temp_cnt;
		int intTestStartID;
		int intTestEndID;
		//Dim intRowCount As Integer
		int intCount = 0;
		DataTable mobjTmpDt;
		object intCharConst = 37;

		try {
			switch (testnos) {
				case ENUM_TestNos.TestNo1:
					intTestStartID = CONST_Test1StartID;

					intTestEndID = CONST_Test1EndID;
				case ENUM_TestNos.TestNo2:
					intTestStartID = CONST_Test2StartID;

					intTestEndID = CONST_Test2EndID;
				case ENUM_TestNos.TestNo3:
					intTestStartID = CONST_Test3StartID;

					intTestEndID = CONST_Test3EndID;
				default:
					intTestStartID = 0;
					intTestEndID = 0;
			}

			for (temp_cnt = intTestStartID; temp_cnt <= intTestEndID; temp_cnt++) {
				testID = temp_cnt;

				switch (testnos) {
					case ENUM_TestNos.TestNo1:
						mobjTmpDt = new DataTable();
						mobjTmpDt = gobjDataAccess.funcGetOQTest1Records(testID);

						if (!mobjTmpDt == null) {
							if (!mobjTmpDt.Rows.Count == 0) {
								for (intCount = 0; intCount <= mobjTmpDt.Rows.Count - 1; intCount++) {
									objDataRow = mobjTest1DataTable.NewRow;
									objDataRow.Item(ConstTestName) = gfuncWordWrap((string)mobjTmpDt.Rows.Item(intCount).Item("OQTestName"), intCharConst);
									//5.4.2010
									objDataRow.Item(ConstObservation) = gfuncWordWrap((mobjTmpDt.Rows.Item(intCount).Item("OQObservation")), intCharConst);
									//5.4.2010
									objDataRow.Item(ConstDemoDate) = (System.DateTime)mobjTmpDt.Rows.Item(intCount).Item("OQDemoDate");
									objDataRow.Item(ConstVerifiedDate) = (System.DateTime)mobjTmpDt.Rows.Item(intCount).Item("OQVerifiedDate");
									objDataRow.Item(ConstTestID) = testID;
									mobjTest1DataTable.Rows.Add(objDataRow);

								}
							}
						} else {
							throw new Exception("Error in Getting Test Details.");

						}
					//If Not (funcGetOQTest1Details(testID, mobjTest1DataTable)) Then
					//    Throw New Exception("Error in Getting Test Details.")
					//End If
					case ENUM_TestNos.TestNo2:

						mobjTmpDt = new DataTable();
						mobjTmpDt = gobjDataAccess.funcGetOQTest1Records(testID);

						if (!mobjTmpDt == null) {
							if (!mobjTmpDt.Rows.Count == 0) {
								for (intCount = 0; intCount <= mobjTmpDt.Rows.Count - 1; intCount++) {
									objDataRow = mobjTest2DataTable.NewRow;
									objDataRow.Item(ConstTestName) = gfuncWordWrap((string)mobjTmpDt.Rows.Item(intCount).Item("OQTestName"), intCharConst);
									//5.4.2010
									objDataRow.Item(ConstObservation) = gfuncWordWrap((string)mobjTmpDt.Rows.Item(intCount).Item("OQObservation"), intCharConst);
									//5.4.2010
									objDataRow.Item(ConstDemoDate) = (string)mobjTmpDt.Rows.Item(intCount).Item("OQDemoDate");
									objDataRow.Item(ConstVerifiedDate) = (string)mobjTmpDt.Rows.Item(intCount).Item("OQVerifiedDate");
									objDataRow.Item(ConstTestID) = testID;
									mobjTest2DataTable.Rows.Add(objDataRow);

								}
							}

						}
					//If Not (funcGetOQTest1Details(testID, mobjTest2DataTable)) Then
					//    Throw New Exception("Error in Getting Test Details.")
					//End If
					case ENUM_TestNos.TestNo3:

						mobjTmpDt = new DataTable();
						mobjTmpDt = gobjDataAccess.funcGetOQTest1Records(testID);

						if (!mobjTmpDt == null) {
							if (!mobjTmpDt.Rows.Count == 0) {
								for (intCount = 0; intCount <= mobjTmpDt.Rows.Count - 1; intCount++) {
									objDataRow = mobjTest3DataTable.NewRow;
									objDataRow.Item(ConstTestName) = gfuncWordWrap((string)mobjTmpDt.Rows.Item(intCount).Item("OQTestName"), intCharConst);
									objDataRow.Item(ConstObservation) = gfuncWordWrap((string)mobjTmpDt.Rows.Item(intCount).Item("OQObservation"), intCharConst);
									objDataRow.Item(ConstDemoDate) = (string)mobjTmpDt.Rows.Item(intCount).Item("OQDemoDate");
									objDataRow.Item(ConstVerifiedDate) = (string)mobjTmpDt.Rows.Item(intCount).Item("OQVerifiedDate");
									objDataRow.Item(ConstTestID) = testID;
									mobjTest3DataTable.Rows.Add(objDataRow);

								}
							}

						}
					//If Not (funcGetOQTest1Details(testID, mobjTest3DataTable)) Then
					//    Throw New Exception("Error in Getting Test Details.")
					//End If
				}
				//Else
				//Dim strTestName As String
				//Dim dtToday As DateTime = DateTime.Today

				//strTestName = funcGetStdTestName(testID)
				//If funcInsertOQTest1Data(testID, strTestName) Then
				//    Select Case testnos
				//        Case ENUM_TestNos.TestNo1
				//            If Not (funcGetOQTest1Details(testID, mobjTest1DataTable)) Then
				//                Throw New Exception("Error in Getting Test Details.")
				//            End If
				//        Case ENUM_TestNos.TestNo2
				//            If Not (funcGetOQTest1Details(testID, mobjTest2DataTable)) Then
				//                Throw New Exception("Error in Getting Test Details.")
				//            End If
				//        Case ENUM_TestNos.TestNo3
				//            If Not (funcGetOQTest1Details(testID, mobjTest3DataTable)) Then
				//                Throw New Exception("Error in Getting Test Details.")
				//            End If
				//    End Select
				//Else
				//    Throw New Exception("Error in Saving Test Details.")
				//End If
				//End If
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

	//Private Function funcGetOQTest1Details(ByVal testID As Integer, ByRef objDataTable As DataTable) As Boolean
	//    '=====================================================================
	//    ' Procedure Name        :   funcGetOQTest1Details
	//    ' Description           :   To Get OQ Test Records from Database for the given ID.
	//    ' Purpose               :   To Get OQ Test Records from Database for the given ID.
	//    ' Parameters Passed     :   None.
	//    ' Returns               :   None.
	//    ' Parameters Affected   :   None.
	//    ' Assumptions           :
	//    ' Dependencies          :
	//    ' Author                :   
	//    ' Created               :   January, 2003 
	//    ' Revisions             :
	//    '=====================================================================

	//    Dim objReader As OleDbDataReader
	//    Dim str_sql, strTestName, strObservation As String
	//    Dim dtDemo, dtVerified As DateTime
	//    Dim reader_status As Boolean
	//    Dim objDataRow As DataRow

	//    Try
	//        str_sql = "Select OQTestName ,OQObservation ,OQDemoDate ,OQVerifiedDate from OQTest where OQTestID = " & testID & " "
	//        'reader_status = mclsDBFunctions.GetRecords(str_sql, mobjOleDBconnection, objReader)

	//        If Not (reader_status) Then
	//            Throw New Exception("Error in Opening Connection during Getting Test Details.")
	//        End If

	//        While objReader.Read
	//            objDataRow = objDataTable.NewRow()

	//            objDataRow("TestName") = CStr(objReader.Item("OQTestName"))

	//            If IsDBNull(objReader.Item("OQObservation")) = False Then
	//                objDataRow("Observation") = CStr(objReader.Item("OQObservation"))
	//            End If
	//            If IsDBNull(objReader.Item("OQDemoDate")) = False Then
	//                objDataRow("DemoDate") = CDate(objReader.Item("OQDemoDate"))
	//            Else
	//                objDataRow("DemoDate") = DateTime.Today
	//            End If
	//            If IsDBNull(objReader.Item("OQVerifiedDate")) = False Then
	//                objDataRow("VerifiedDate") = CDate(objReader.Item("OQVerifiedDate"))
	//            Else
	//                objDataRow("VerifiedDate") = DateTime.Today
	//            End If
	//            objDataRow("TestID") = testID

	//            objDataTable.Rows.Add(objDataRow)
	//        End While

	//        objReader.Close()
	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        'Error logging
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = "Error in Getting Test Records."
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
	//    Return True
	//End Function

	private void subFormatDataGrid(ref DataGridTableStyle objGridTableStyle, ref DataGrid dg, DataTable objDataTable)
	{
		DataGridTextBoxColumn objTextColumn;
		DataView objDataView = new DataView();
		try {
			dg.TableStyles.Clear();
			objDataView.Table = objDataTable;
			objDataView.AllowNew = false;
			dg.DataSource = objDataView;
			//dg.ReadOnly = False

			//----------------------------------'5.4.2010
			if (dg.Name == "dgTest2") {
				objGridTableStyle.PreferredRowHeight = 49;
			} else if (dg.Name == "dgTest1") {
				objGridTableStyle.PreferredRowHeight = 34;
			}
			//----------------------------------



			objGridTableStyle.RowHeadersVisible = false;
			objGridTableStyle.ResetAlternatingBackColor();
			objGridTableStyle.ResetBackColor();
			objGridTableStyle.ResetForeColor();
			objGridTableStyle.ResetGridLineColor();
			objGridTableStyle.BackColor = Color.AliceBlue;
			objGridTableStyle.GridLineColor = Color.Black;
			objGridTableStyle.HeaderBackColor = Color.FromArgb(205, 225, 250);
			objGridTableStyle.HeaderForeColor = Color.Black;
			objGridTableStyle.AlternatingBackColor = Color.AliceBlue;

			objGridTableStyle.AllowSorting = false;

			objGridTableStyle.MappingName = objDataTable.TableName;

			objTextColumn = new DataGridTextBoxColumn();
			objTextColumn.TextBox.WordWrap = true;
			//5.4.2010 by dinesh wagh
			objTextColumn.MappingName = "TestName";
			objTextColumn.HeaderText = "Test";
			objTextColumn.Width = 228;
			objTextColumn.ReadOnly = true;
			objTextColumn.NullText = "";
			objGridTableStyle.GridColumnStyles.Add(objTextColumn);

			objTextColumn = new DataGridTextBoxColumn();
			objTextColumn.TextBox.WordWrap = true;
			//5.4.2010 by dinesh wagh
			objTextColumn.MappingName = "Observation";
			objTextColumn.HeaderText = "Observation";
			objTextColumn.Width = 175;
			objTextColumn.ReadOnly = false;
			objTextColumn.NullText = "";
			objGridTableStyle.GridColumnStyles.Add(objTextColumn);

			objTextColumn = new DataGridTextBoxColumn();
			objTextColumn.MappingName = "DemoDate";
			objTextColumn.HeaderText = "Demo. Date";
			objTextColumn.Width = 80;
			objTextColumn.Format = "dd-MMM-yyyy";
			objTextColumn.ReadOnly = false;
			objTextColumn.NullText = "";
			objTextColumn.Alignment = HorizontalAlignment.Center;
			objGridTableStyle.GridColumnStyles.Add(objTextColumn);

			objTextColumn = new DataGridTextBoxColumn();
			objTextColumn.MappingName = "VerifiedDate";
			objTextColumn.HeaderText = "Verified Date";
			objTextColumn.Width = 80;
			objTextColumn.Format = "dd-MMM-yyyy";
			objTextColumn.ReadOnly = false;
			objTextColumn.NullText = "";
			objTextColumn.Alignment = HorizontalAlignment.Center;
			objGridTableStyle.GridColumnStyles.Add(objTextColumn);

			objTextColumn = new DataGridTextBoxColumn();
			objTextColumn.MappingName = "TestID";
			objTextColumn.HeaderText = "TestID";
			objTextColumn.Width = 0;
			objTextColumn.ReadOnly = true;
			objTextColumn.NullText = "";
			objGridTableStyle.GridColumnStyles.Add(objTextColumn);

			objGridTableStyle.GridLineColor = Color.Black;
			dg.TableStyles.Add(objGridTableStyle);
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

	public bool funcSaveOQTest1Data(int testnos)
	{
		//=====================================================================
		// Procedure Name        :   funcSaveOQTest1Data
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

		int intTestID;
		int temp_cnt;
		int intTestStartID;
		int intTestEndID;
		string strObservation;
		DateTime dtDemo;
		DateTime dtVerified;
		bool status = true;

		try {
			switch (testnos) {
				case ENUM_TestNos.TestNo1:
					intTestStartID = CONST_Test1StartID;

					intTestEndID = CONST_Test1EndID;
				case ENUM_TestNos.TestNo2:
					intTestStartID = CONST_Test2StartID;

					intTestEndID = CONST_Test2EndID;
				case ENUM_TestNos.TestNo3:
					intTestStartID = CONST_Test3StartID;

					intTestEndID = CONST_Test3EndID;
				default:
					intTestStartID = 0;
					intTestEndID = 0;
			}

			for (temp_cnt = intTestStartID; temp_cnt <= intTestEndID; temp_cnt++) {
				intTestID = temp_cnt;
				strObservation = funcGetObservationFromControls(intTestID, testnos);
				dtDemo = funcGetDemoDateFromControls(intTestID, testnos);
				dtVerified = funcGetVerifiedDateFromControls(intTestID, testnos);
				status = gobjDataAccess.funcUpdateOQTest1Data(intTestID, strObservation, dtDemo, dtVerified);
				if (!(status)) {
					throw new Exception("Error in Updating Test Details.");
				}
			}

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = "Error in Saving Test Details.";
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
		return status;

	}

	private string funcGetObservationFromControls(int testID, int testnos)
	{
		//=====================================================================
		// Procedure Name        :   funcAssignValues
		// Description           :   To Get values from text box controls on form. 
		// Purpose               :   To Get values from text box controls on form. 
		// Parameters Passed     :   None.
		// Returns               :   None.
		// Parameters Affected   :   None.
		// Assumptions           :
		// Dependencies          :
		// Author                :   
		// Created               :   January, 2003 
		// Revisions             :
		//=====================================================================
		string strObservation;
		DataRow objDataRow;

		try {
			switch (testnos) {
				case ENUM_TestNos.TestNo1:
					foreach ( objDataRow in mobjTest1DataTable.Rows) {
						if ((objDataRow.ItemArray.GetValue(mobjTest1DataTable.Columns("TestID").Ordinal) == testID)) {
							if (IsDBNull(objDataRow.ItemArray.GetValue(mobjTest1DataTable.Columns("Observation").Ordinal)) == false) {
								strObservation = objDataRow.ItemArray.GetValue(mobjTest1DataTable.Columns("Observation").Ordinal);
								strObservation = strObservation.Replace(vbCrLf, " ");
								//29.6.2010 by dinesh wagh
								break; // TODO: might not be correct. Was : Exit For
							} else {
								strObservation = "";
							}
						}
					}

				case ENUM_TestNos.TestNo2:
					foreach ( objDataRow in mobjTest2DataTable.Rows) {
						if ((objDataRow.ItemArray.GetValue(mobjTest2DataTable.Columns("TestID").Ordinal) == testID)) {
							if (IsDBNull(objDataRow.ItemArray.GetValue(mobjTest2DataTable.Columns("Observation").Ordinal)) == false) {
								strObservation = objDataRow.ItemArray.GetValue(mobjTest2DataTable.Columns("Observation").Ordinal);
								strObservation = strObservation.Replace(vbCrLf, " ");
								//29.6.2010 by dinesh wagh
								break; // TODO: might not be correct. Was : Exit For
							} else {
								strObservation = "";
							}
						}
					}

				case ENUM_TestNos.TestNo3:
					foreach ( objDataRow in mobjTest3DataTable.Rows) {
						if ((objDataRow.ItemArray.GetValue(mobjTest3DataTable.Columns("TestID").Ordinal) == testID)) {
							if (IsDBNull(objDataRow.ItemArray.GetValue(mobjTest3DataTable.Columns("Observation").Ordinal)) == false) {
								strObservation = objDataRow.ItemArray.GetValue(mobjTest3DataTable.Columns("Observation").Ordinal);
								strObservation = strObservation.Replace(vbCrLf, " ");
								//29.6.2010 by dinesh wagh
								break; // TODO: might not be correct. Was : Exit For
							} else {
								strObservation = "";
							}
						}
					}

				default:
			}
		} catch (Exception ex) {
			//---------------------------------------------------------
			//--- Error logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = "Error in Getting Test Observation Details.";
			gobjErrorHandler.WriteErrorLog(ex);
			return "";
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//--- Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			//---------------------------------------------------------
		}
		return strObservation;
	}

	private System.DateTime funcGetDemoDateFromControls(int testID, int testnos)
	{
		//=====================================================================
		// Procedure Name        :   funcGetDemoDateFromControls
		// Description           :   To Get values from Date Time Picker controls on form. 
		// Purpose               :   To Get values from Date Time Picker controls on form. 
		// Parameters Passed     :   None.
		// Returns               :   None.
		// Parameters Affected   :   None.
		// Assumptions           :
		// Dependencies          :
		// Author                :   
		// Created               :   January, 2003 
		// Revisions             :
		//=====================================================================
		System.DateTime dtDemo;
		DataRow objDataRow;

		try {
			switch (testnos) {
				case ENUM_TestNos.TestNo1:
					foreach ( objDataRow in mobjTest1DataTable.Rows) {
						if ((objDataRow.ItemArray.GetValue(mobjTest1DataTable.Columns("TestID").Ordinal) == testID)) {
							if (IsDBNull(objDataRow.ItemArray.GetValue(mobjTest1DataTable.Columns("DemoDate").Ordinal)) == false) {
								dtDemo = objDataRow.ItemArray.GetValue(mobjTest1DataTable.Columns("DemoDate").Ordinal);
								break; // TODO: might not be correct. Was : Exit For
							} else {
								dtDemo = DateTime.Today;
							}
						}
					}

				case ENUM_TestNos.TestNo2:
					foreach ( objDataRow in mobjTest2DataTable.Rows) {
						if ((objDataRow.ItemArray.GetValue(mobjTest2DataTable.Columns("TestID").Ordinal) == testID)) {
							if (IsDBNull(objDataRow.ItemArray.GetValue(mobjTest2DataTable.Columns("DemoDate").Ordinal)) == false) {
								dtDemo = objDataRow.ItemArray.GetValue(mobjTest2DataTable.Columns("DemoDate").Ordinal);
								break; // TODO: might not be correct. Was : Exit For
							} else {
								dtDemo = DateTime.Today;
							}
						}
					}

				case ENUM_TestNos.TestNo3:
					foreach ( objDataRow in mobjTest3DataTable.Rows) {
						if ((objDataRow.ItemArray.GetValue(mobjTest3DataTable.Columns("TestID").Ordinal) == testID)) {
							if (IsDBNull(objDataRow.ItemArray.GetValue(mobjTest3DataTable.Columns("DemoDate").Ordinal)) == false) {
								dtDemo = objDataRow.ItemArray.GetValue(mobjTest3DataTable.Columns("DemoDate").Ordinal);
								break; // TODO: might not be correct. Was : Exit For
							} else {
								dtDemo = DateTime.Today;
							}
						}
					}

				default:
			}
		} catch (Exception ex) {
			//---------------------------------------------------------
			//--- Error logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = "Error in Getting Test Demonstrated Date Details.";
			gobjErrorHandler.WriteErrorLog(ex);
			return DateTime.Today;
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//--- Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			//---------------------------------------------------------
		}
		return dtDemo;
	}

	private System.DateTime funcGetVerifiedDateFromControls(int testID, int testnos)
	{
		//=====================================================================
		// Procedure Name        :   funcGetVerifiedDateFromControls
		// Description           :   To Get values from Date Time Picker controls on form. 
		// Purpose               :   To Get values from Date Time Picker controls on form. 
		// Parameters Passed     :   None.
		// Returns               :   None.
		// Parameters Affected   :   None.
		// Assumptions           :
		// Dependencies          :
		// Author                :   
		// Created               :   January, 2003 
		// Revisions             :
		//=====================================================================
		System.DateTime dtVerified;
		DataRow objDataRow;

		try {
			switch (testnos) {
				case ENUM_TestNos.TestNo1:
					foreach ( objDataRow in mobjTest1DataTable.Rows) {
						if ((objDataRow.ItemArray.GetValue(mobjTest1DataTable.Columns("TestID").Ordinal) == testID)) {
							if (IsDBNull(objDataRow.ItemArray.GetValue(mobjTest1DataTable.Columns("VerifiedDate").Ordinal)) == false) {
								dtVerified = objDataRow.ItemArray.GetValue(mobjTest1DataTable.Columns("VerifiedDate").Ordinal);
								break; // TODO: might not be correct. Was : Exit For
							} else {
								dtVerified = DateTime.Today;
							}
						}
					}

				case ENUM_TestNos.TestNo2:
					foreach ( objDataRow in mobjTest2DataTable.Rows) {
						if ((objDataRow.ItemArray.GetValue(mobjTest2DataTable.Columns("TestID").Ordinal) == testID)) {
							if (IsDBNull(objDataRow.ItemArray.GetValue(mobjTest2DataTable.Columns("VerifiedDate").Ordinal)) == false) {
								dtVerified = objDataRow.ItemArray.GetValue(mobjTest2DataTable.Columns("VerifiedDate").Ordinal);
								break; // TODO: might not be correct. Was : Exit For
							} else {
								dtVerified = DateTime.Today;
							}
						}
					}

				case ENUM_TestNos.TestNo3:
					foreach ( objDataRow in mobjTest3DataTable.Rows) {
						if ((objDataRow.ItemArray.GetValue(mobjTest3DataTable.Columns("TestID").Ordinal) == testID)) {
							if (IsDBNull(objDataRow.ItemArray.GetValue(mobjTest3DataTable.Columns("VerifiedDate").Ordinal)) == false) {
								dtVerified = objDataRow.ItemArray.GetValue(mobjTest3DataTable.Columns("VerifiedDate").Ordinal);
								break; // TODO: might not be correct. Was : Exit For
							} else {
								dtVerified = DateTime.Today;
							}
						}
					}

				default:
			}
		} catch (Exception ex) {
			//---------------------------------------------------------
			//--- Error logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = "Error in Getting Test Verified Date Details.";
			gobjErrorHandler.WriteErrorLog(ex);
			return DateTime.Today;
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//--- Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			//---------------------------------------------------------
		}
		return dtVerified;
	}

	//Private Function funcInsertOQTest1Data(ByVal intTestID As Integer, ByVal strTestName As String) As Boolean
	//    '=====================================================================
	//    ' Procedure Name        :   funcInsertOQTest1Data
	//    ' Description           :   To Add/Insert New Test Data in Database.
	//    ' Purpose               :   To Add/Insert New Test Data in Database.
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
	//    Dim objCommand As New OleDbCommand

	//    Try

	//        'Status = mclsDBFunctions.OpenConnection(mobjOleDBconnection)
	//        If Not (Status) Then
	//            Throw New Exception("Error in Opening Connection during Saving Test Details.")
	//        End If

	//        '---  Query for adding  data to Test
	//        str_sql = " Insert into OQTest " & _
	//                  " (OQTestID ,OQTestName) " & _
	//                  " values(?,?) "

	//        '--- Providing command object for Test
	//        With objCommand
	//            .Connection = mobjOleDBconnection
	//            .CommandType = CommandType.Text
	//            .CommandText = str_sql
	//            .Parameters.Add("OQTestID", OleDbType.Numeric).Value = intTestID
	//            .Parameters.Add("OQTestName", OleDbType.VarChar, 350).Value = strTestName
	//            .ExecuteNonQuery()
	//        End With

	//        objCommand.Dispose()
	//        Status = True

	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        '--- Error logging
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = "Error in Saving Test Details."
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

	//Private Function funcUpdateOQTest1Data(ByVal intTestID As Integer, ByVal strObservation As String, ByVal dtDemo As Date, ByVal dtVerified As Date) As Boolean
	//    '=====================================================================
	//    ' Procedure Name        :   funcUpdateOQTest1Data
	//    ' Description           :   To Update Test Data in Database.
	//    ' Purpose               :   To Update Test Data in Database.
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
	//    Dim objCommand As New OleDbCommand

	//    Try
	//        'Status = mclsDBFunctions.OpenConnection(mobjOleDBconnection)
	//        If Not (Status) Then
	//            Throw New Exception("Error in Opening Connection during Updating Test Details.")
	//        End If

	//        '---  Query to Update Data
	//        str_sql = " Update OQTest set " & _
	//                  " OQObservation = ? , OQDemoDate = ? ,OQVerifiedDate =? " & _
	//                  " where OQTestID = " & intTestID & " "

	//        '--- Providing command object 
	//        With objCommand
	//            .Connection = mobjOleDBconnection
	//            .CommandType = CommandType.Text
	//            .CommandText = str_sql
	//            .Parameters.Add("OQObservation", OleDbType.VarChar, 250).Value = strObservation
	//            .Parameters.Add("OQDemoDate", OleDbType.DBDate).Value = dtDemo
	//            .Parameters.Add("OQVerifiedDate", OleDbType.DBDate).Value = dtVerified
	//            .ExecuteNonQuery()
	//        End With

	//        objCommand.Dispose()
	//        Status = True

	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        '--- Error logging
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = "Error in Updating Test Details."
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

	//Private Function funcDeleteOQTest1Data(ByVal intTestID As Integer) As Boolean
	//    '=====================================================================
	//    ' Procedure Name        :   funcDeleteOQTest1Data
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
	//        'Status = mclsDBFunctions.OpenConnection(mobjOleDBconnection)
	//        If Not (Status) Then
	//            Throw New Exception("Error in Opening Connection during Deleting Test Details.")
	//        End If

	//        '--- Query to Delete from Database
	//        str_sql = " Delete * from OQTest where OQTestID = " & intTestID & " "

	//        'Status = mclsDBFunctions.AddORDeleteRecord(str_sql, mobjOleDBconnection)
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

	#End Region

	#Region "Constant Test Data"

	private string funcGetStdTestName(int testNo)
	{
		string testName;
		try {
			switch (testNo) {
				case 1:
					testName = "Power Up Instruments";
				case 2:
					testName = "Preview keyboard,status,menus,Display";
				case 3:
					testName = "Preview instrument settings and mode of operation";
				case 4:
					testName = "Preview position of sample and reference cuvette";
				case 5:
					testName = "Preview procedure of placing cuvette into cuvette-holder";
				default:
					testName = "";
			}
			return testName;
		} catch (Exception ex) {
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			return "";
		} finally {
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
		}
	}

	#End Region

	private void  // ERROR: Handles clauses are not supported in C#
dgTest1_CurrentCellChanged(object sender, System.EventArgs e)
	{
		//code added by : dinesh wagh on 29.6.2010
		//-----------------------------------------------
		if (mblnAvoidProcessing == true)
			return;
		int intRowIndex;
		int intColumnIndex;
		string strString;
		//-------------------------------------

		try {
			if (!(mblnModeLockStatus)) {
				if (((dgTest1.CurrentCell.ColumnNumber == CONST_DemoColumnNo) | (dgTest1.CurrentCell.ColumnNumber == CONST_VerifyColumnNo))) {
					mdtpDate.Top = dgTest1.GetCurrentCellBounds().Top;
					mdtpDate.Left = dgTest1.GetCurrentCellBounds().Left;
					mdtpDate.Width = dgTest1.GetCurrentCellBounds().Width;
					mdtpDate.Height = dgTest1.GetCurrentCellBounds().Height;
					if ((dgTest1.CurrentCell.RowNumber) > 0) {
						if (IsDBNull(dgTest1(dgTest1.CurrentCell.RowNumber, dgTest1.CurrentCell.ColumnNumber)) == false) {
							mdtpDate.Value = (System.DateTime)dgTest1(dgTest1.CurrentCell.RowNumber, dgTest1.CurrentCell.ColumnNumber);
						} else {
							mdtpDate.Value = DateTime.Today;
						}
					}
					mdtpDate.Visible = true;
				} else {
					mdtpDate.Width = 0;
					mdtpDate.Visible = false;
				}
			}

			//code added by : dinesh wagh on 29.6.2010
			//---------------------------------------------------------------------------

			intRowIndex = dgTest1.CurrentCell.RowNumber;
			intColumnIndex = dgTest1.CurrentCell.ColumnNumber;

			mblnAvoidProcessing = true;

			if (!IsDBNull(dgTest1.Item(mintRowIndex1, mintColumnIndex1))) {
				if (mintColumnIndex1 == CONST_COMMENT_COLUMN_NO) {
					strString = dgTest1.Item(mintRowIndex1, mintColumnIndex1);
					if (!(strString == "")) {
						strString = strString.Replace(vbCrLf, " ");
						dgTest1.Item(mintRowIndex1, mintColumnIndex1) = gfuncWordWrap(strString, 32);
					}
				}
			}

			dgTest1.CurrentCell = new DataGridCell(intRowIndex, intColumnIndex);

			mintRowIndex1 = dgTest1.CurrentCell.RowNumber;
			mintColumnIndex1 = dgTest1.CurrentCell.ColumnNumber;
			mblnAvoidProcessing = false;
		//------------------------------------------------------------------------
		} catch (Exception ex) {
			mblnAvoidProcessing = false;
			//27.6.2010 by dinesh wagh on 29.6.2010
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
dgTest2_CurrentCellChanged(object sender, System.EventArgs e)
	{
		//code added by : dinesh wagh on 29.6.2010
		//-----------------------------------------------
		if (mblnAvoidProcessing == true)
			return;
		int intRowIndex;
		int intColumnIndex;
		string strString;
		//-------------------------------------

		try {
			if (!(mblnModeLockStatus)) {
				if (((dgTest2.CurrentCell.ColumnNumber == CONST_DemoColumnNo) | (dgTest2.CurrentCell.ColumnNumber == CONST_VerifyColumnNo))) {
					mdtpDate2.Top = dgTest2.GetCurrentCellBounds().Top;
					mdtpDate2.Left = dgTest2.GetCurrentCellBounds().Left;
					mdtpDate2.Width = dgTest2.GetCurrentCellBounds().Width;
					mdtpDate2.Height = dgTest2.GetCurrentCellBounds().Height;
					if ((dgTest2.CurrentCell.RowNumber) > 0) {
						if (IsDBNull(dgTest2(dgTest2.CurrentCell.RowNumber, dgTest2.CurrentCell.ColumnNumber)) == false) {
							mdtpDate2.Value = (System.DateTime)dgTest2(dgTest2.CurrentCell.RowNumber, dgTest2.CurrentCell.ColumnNumber);
						} else {
							mdtpDate2.Value = DateTime.Today;
						}
					}
					mdtpDate2.Visible = true;
				} else {
					mdtpDate2.Width = 0;
					mdtpDate2.Visible = false;
				}
			}

			//code added by : dinesh wagh on 29.6.2010
			//---------------------------------------------------------------------------

			intRowIndex = dgTest2.CurrentCell.RowNumber;
			intColumnIndex = dgTest2.CurrentCell.ColumnNumber;

			mblnAvoidProcessing = true;

			if (!IsDBNull(dgTest2.Item(mintRowIndex2, mintColumnIndex2))) {
				if (mintColumnIndex2 == CONST_COMMENT_COLUMN_NO) {
					strString = dgTest2.Item(mintRowIndex2, mintColumnIndex2);
					if (!(strString == "")) {
						strString = strString.Replace(vbCrLf, " ");
						dgTest2.Item(mintRowIndex2, mintColumnIndex2) = gfuncWordWrap(strString, 32);
					}
				}
			}

			dgTest2.CurrentCell = new DataGridCell(intRowIndex, intColumnIndex);

			mintRowIndex2 = dgTest2.CurrentCell.RowNumber;
			mintColumnIndex2 = dgTest2.CurrentCell.ColumnNumber;
			mblnAvoidProcessing = false;
		//------------------------------------------------------------------------
		} catch (Exception ex) {
			mblnAvoidProcessing = false;
			//29.6.2010
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
dgTest3_CurrentCellChanged(object sender, System.EventArgs e)
	{
		try {
			if (!(mblnModeLockStatus)) {
				if (((dgTest3.CurrentCell.ColumnNumber == CONST_DemoColumnNo) | (dgTest3.CurrentCell.ColumnNumber == CONST_VerifyColumnNo))) {
					mdtpDate3.Top = dgTest3.GetCurrentCellBounds().Top;
					mdtpDate3.Left = dgTest3.GetCurrentCellBounds().Left;
					mdtpDate3.Width = dgTest3.GetCurrentCellBounds().Width;
					mdtpDate3.Height = dgTest3.GetCurrentCellBounds().Height;
					if ((dgTest3.CurrentCell.RowNumber) > 0) {
						if (IsDBNull(dgTest3(dgTest3.CurrentCell.RowNumber, dgTest3.CurrentCell.ColumnNumber)) == false) {
							mdtpDate3.Value = (System.DateTime)dgTest3(dgTest3.CurrentCell.RowNumber, dgTest3.CurrentCell.ColumnNumber);
						} else {
							mdtpDate3.Value = DateTime.Today;
						}
					}
					mdtpDate3.Visible = true;
				} else {
					mdtpDate3.Width = 0;
					mdtpDate3.Visible = false;
				}
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
}
