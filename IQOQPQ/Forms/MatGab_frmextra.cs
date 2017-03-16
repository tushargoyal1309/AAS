
using System.Data;
using System.Data.OleDb;
using ErrorHandler.ErrorHandler;

public class frmextra : System.Windows.Forms.Form
{

	#Region " Windows Form Designer generated code "

	public frmextra()
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
	internal System.Windows.Forms.Panel Panel1;
	internal System.Windows.Forms.Panel Panel2;
	internal System.Windows.Forms.PictureBox PictureBox1;
	internal System.Windows.Forms.Label Label3;
	internal System.Windows.Forms.DataGrid DataGrid1;
	[System.Diagnostics.DebuggerStepThrough()]
	private void InitializeComponent()
	{
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmextra));
		this.Panel1 = new System.Windows.Forms.Panel();
		this.DataGrid1 = new System.Windows.Forms.DataGrid();
		this.Panel2 = new System.Windows.Forms.Panel();
		this.PictureBox1 = new System.Windows.Forms.PictureBox();
		this.Label3 = new System.Windows.Forms.Label();
		this.Panel1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.DataGrid1).BeginInit();
		this.Panel2.SuspendLayout();
		this.SuspendLayout();
		//
		//Panel1
		//
		this.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.Panel1.Controls.Add(this.DataGrid1);
		this.Panel1.Controls.Add(this.Panel2);
		this.Panel1.Dock = System.Windows.Forms.DockStyle.Top;
		this.Panel1.Location = new System.Drawing.Point(0, 0);
		this.Panel1.Name = "Panel1";
		this.Panel1.Size = new System.Drawing.Size(383, 456);
		this.Panel1.TabIndex = 13;
		//
		//DataGrid1
		//
		this.DataGrid1.DataMember = "";
		this.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
		this.DataGrid1.Location = new System.Drawing.Point(24, 64);
		this.DataGrid1.Name = "DataGrid1";
		this.DataGrid1.Size = new System.Drawing.Size(352, 224);
		this.DataGrid1.TabIndex = 20;
		//
		//Panel2
		//
		this.Panel2.BackColor = System.Drawing.Color.AliceBlue;
		this.Panel2.Controls.Add(this.PictureBox1);
		this.Panel2.Controls.Add(this.Label3);
		this.Panel2.Dock = System.Windows.Forms.DockStyle.Top;
		this.Panel2.Location = new System.Drawing.Point(0, 0);
		this.Panel2.Name = "Panel2";
		this.Panel2.Size = new System.Drawing.Size(381, 32);
		this.Panel2.TabIndex = 19;
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
		//Label3
		//
		this.Label3.BackColor = System.Drawing.Color.AliceBlue;
		this.Label3.Font = new System.Drawing.Font("Arial", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.Label3.Location = new System.Drawing.Point(35, 7);
		this.Label3.Name = "Label3";
		this.Label3.Size = new System.Drawing.Size(400, 18);
		this.Label3.TabIndex = 11;
		this.Label3.Text = "C.II  INSTALLATION QUALIFICATION  TESTS";
		this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//frmextra
		//
		this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
		this.AutoScroll = true;
		this.BackColor = System.Drawing.Color.AliceBlue;
		this.ClientSize = new System.Drawing.Size(383, 398);
		this.Controls.Add(this.Panel1);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		this.Name = "frmextra";
		this.ShowInTaskbar = false;
		this.Text = "frmextra";
		this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
		this.Panel1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.DataGrid1).EndInit();
		this.Panel2.ResumeLayout(false);
		this.ResumeLayout(false);

	}

	#End Region

	#Region " Module level Declarations "
	private ComboBox mobjCmbBox;
	private const  CONST_ConfirmColumnNo = 2;
	private const  CONST_NoOfTests = 5;

	private bool mblnModeLockStatus;
	private DataTable mObjDataTable;

	DataGridTableStyle mobjGridTableStyle = new DataGridTableStyle();
	private enum enumConfirmity : int
	{
		No = 0,
		Yes = 1
	}

	private struct mTest
	{
		public string mItem;
		public string RequirementCondition;
	}
	#End Region

	#Region " Form Events "
	private void  // ERROR: Handles clauses are not supported in C#
frmextra_Load(object sender, System.EventArgs e)
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
frmextra_Closing(object sender, System.ComponentModel.CancelEventArgs e)
	{
		try {
			if (!(mblnModeLockStatus)) {
				DataGrid1.CurrentCell() = (new DataGridCell(DataGrid1.CurrentRowIndex + 1, 0));
				if (!funcSaveIQTestData()) {
					throw new Exception("Error in Saving IQ Tests Data.");
				}
				DataGrid1.TableStyles.Clear();
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


	#Region "Constant Test Data"

	private object funcFillStruct(ref mTest objstructTest, int testNo)
	{
		try {
			switch (testNo) {
				case 0:
					objstructTest.mItem = "Equipment Appearance Check";
					objstructTest.RequirementCondition = "No contamination ,Dirt,Deformation,Marks etc.Physical condition good ";
				case 1:
					objstructTest.mItem = "Parts Check";
					objstructTest.RequirementCondition = "Check with delivery Challan and confirm that parts are supplied as displayed";
				case 2:
					objstructTest.mItem = "Voltage Check";
					objstructTest.RequirementCondition = "Online UPS(1 KVA)Or \" Offline UPS with servo-stabliser is recommended " + "Check stablised voltage supply with digital volt meter and voltage should satisfy the specified value (230 VAC" + "+/- 5%).A very good Ground/Earth Connection with earth -neutral leakage less than 3 volts";
				case 3:
					objstructTest.mItem = "Installation Site Check";
					objstructTest.RequirementCondition = "Check and confirm the Following:" + "      1.Room Temperature of 25� C +/- 3� C. " + "2.Away from Direct Sunlight and Direct Air-Blow." + Space(79) + "3.No corrosive gases." + Space(30) + "4.Free from excessive dust and moisture ";
				case 4:
					objstructTest.mItem = "Equipment Connection Check";

					objstructTest.RequirementCondition = "Check the interconnection wiring and " + "connections between each instrument and accessories of the system .Ensure that there is no loose wiring" + " & connections .For Accessories :Ensure that proper types of tubings and fittings used. " + "Check Tubing connectuions for leak(using leak check solution)";
				case 5:
					objstructTest.mItem = "Certificate Functional Performance Check";

					objstructTest.RequirementCondition = "Check serial numbers indicated on test certificate and" + " ensure that it tallies with the equipments serial numbers ";
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

	#End Region

	#Region " General Private functions "

	//--------------------------------------------------------
	//    General functions used for IQ Tests Listing.
	//--- funcInitialize - To Initialize form and to get values for IQ Tests List from database and display them.
	//--- subCreateDataTable - To Create Columns in the Data Table.
	//--- funcGetIQTestRecords - To Get IQ Equipment List Records from Database into DataTable.
	//--- subFormatDataGrid - To format the Data Grid.
	//--- funcSaveIQTestData - To Save the Entered Records into Database.
	//--- funcInsertIQTestData - To Add/Insert New Test Data in Database.
	//--- funcUpdateIQTestData - To Update IQ Test Data in Database.
	//--- funcDeleteIQTestData - To Delete IQ Test Data from Database.

	private void funcInitialize()
	{
		//=====================================================================
		// Procedure Name        :   funcInitailize
		// Description           :   To Initialize form and to get values for IQ Equipment List from database and display them.
		// Purpose               :   To Initialize form and to get values for IQ Equipment List from database and display them.
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
			//mfrmTest = Me
			mObjDataTable = new DataTable("Test");
			///mobjCmbBox = New ComboBox

			//--- To Add Run-Time DateTime Picker Control
			///AddHandler mobjCmbBox.SelectedIndexChanged, AddressOf CmbBox_SelectedIndexChanged
			///DataGrid1.Controls.Add(mobjCmbBox)
			///mobjCmbBox.Visible = False
			///mobjCmbBox.BackColor = Color.FloralWhite
			///mobjCmbBox.DropDownStyle = ComboBoxStyle.DropDownList
			///mobjCmbBox.Items.Add("YES")
			///mobjCmbBox.Items.Add("NO")

			subCreateDataTable();

			if (funcGetIQTestRecords()) {
				subFormatDataGrid();
			} else {
				throw new Exception("Error in Getting IQ Test Records.");
			}

			mblnModeLockStatus = gobjDataAccess.funcCheckModeLocked(ENUM_IQOQPQ_STATUS.IQ);
		///If (mblnModeLockStatus) Then
		///    DataGrid1.ReadOnly = True
		///Else
		///    DataGrid1.ReadOnly = False
		///End If

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

	///Private Sub CmbBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
	///    DataGrid1(DataGrid1.CurrentCell.RowNumber, DataGrid1.CurrentCell.ColumnNumber) = mobjCmbBox.Text
	///End Sub

	private void subCreateDataTable()
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
			mObjDataTable.Columns.Add(new DataColumn("TestName", typeof(string)));
			mObjDataTable.Columns.Add(new DataColumn("PurposeOrCondition", typeof(string)));
			mObjDataTable.Columns.Add(new DataColumn("Confirmity", typeof(string)));
			mObjDataTable.Columns.Add(new DataColumn("Comments", typeof(string)));
			mObjDataTable.Columns.Add(new DataColumn("TestID", typeof(int)));
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = "Error in Creating IQ Test List Data-Table.";
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

	private bool funcGetIQTestRecords()
	{
		//=====================================================================
		// Procedure Name        :   funcGetIQTestRecords
		// Description           :   To Get IQ Test Records from Database into DataTable.
		// Purpose               :   To Get IQ Test Records from Database into DataTable.
		// Parameters Passed     :   None.
		// Returns               :   None.
		// Parameters Affected   :   None.
		// Assumptions           :
		// Dependencies          :
		// Author                :   
		// Created               :   January, 2003 
		// Revisions             :
		//=====================================================================

		OleDbDataReader objReader;
		DataRow objDataRow;
		string sql_string;
		bool reader_status;
		int intTableRecordCount;
		int temp_cnt;
		mTest ObjStructmTest = new mTest();

		try {
			//reader_status = gclsDBFunctions.GetRecords("Select * from Test where CheckStatusIQOQPQ = 1 ", gOleDBIQOQPQConnection, objReader)

			if (!(reader_status)) {
				throw new Exception("Error in Opening Connection during Getting IQ Test Details.");
			}

			//intTableRecordCount = gclsDBFunctions.GetNoOfRec(objReader)
			objReader.Close();

			if (intTableRecordCount <= 0) {
				for (temp_cnt = 0; temp_cnt <= (CONST_NoOfTests); temp_cnt++) {
					//Assigning Struct Object
					funcFillStruct(ObjStructmTest, temp_cnt);

					//Insert Item and Requirement and Condition                
					if (!(funcInsertIQTestData(ObjStructmTest.mItem, ObjStructmTest.RequirementCondition))) {
						throw new Exception("Error in Opening Connection during Getting IQ Test Details.");
					}
				}
			}

			sql_string = "Select TestID ,TestName ,PurposeOrCondition ,Confirmity ,Comments from Test where CheckStatusIQOQPQ = 1 ";

			//reader_status = gclsDBFunctions.GetRecords(sql_string, gOleDBIQOQPQConnection, objReader)

			if (!(reader_status)) {
				throw new Exception("Error in Opening Connection during Getting IQ Test Details.");
			}

			while (objReader.Read) {
				objDataRow = mObjDataTable.NewRow();

				objDataRow("TestName") = (string)objReader.Item("TestName");
				objDataRow("PurposeOrCondition") = (string)objReader.Item("PurposeOrCondition");
				objDataRow("Confirmity") = (string)objReader.Item("Confirmity") + " ";
				objDataRow("Comments") = (string)objReader.Item("Comments") + "";
				objDataRow("TestID") = Convert.ToInt32(objReader.Item("TestID"));

				mObjDataTable.Rows.Add(objDataRow);

			}
			mObjDataTable.AcceptChanges();
			objReader.Close();

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = "Error in Getting Equipment List Records.";
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

	private void subFormatDataGrid()
	{
		DataGridTextBoxColumn objTextColumn;
		DataView objDataView = new DataView();
		try {
			DataGrid1.TableStyles.Clear();
			objDataView.Table = mObjDataTable;
			objDataView.AllowNew = false;
			DataGrid1.DataSource = objDataView;
			DataGrid1.ReadOnly = false;

			mobjGridTableStyle.RowHeadersVisible = false;
			mobjGridTableStyle.ResetAlternatingBackColor();
			mobjGridTableStyle.ResetBackColor();
			mobjGridTableStyle.ResetForeColor();
			mobjGridTableStyle.ResetGridLineColor();
			mobjGridTableStyle.BackColor = Color.AliceBlue;
			mobjGridTableStyle.GridLineColor = Color.Black;
			mobjGridTableStyle.HeaderBackColor = Color.LightSkyBlue;
			mobjGridTableStyle.HeaderForeColor = Color.Black;
			mobjGridTableStyle.AlternatingBackColor = Color.AliceBlue;
			mobjGridTableStyle.AllowSorting = false;

			mobjGridTableStyle.MappingName = "Test";

			objTextColumn = new DataGridTextBoxColumn();
			objTextColumn.MappingName = "TestName";
			objTextColumn.HeaderText = "Item";
			objTextColumn.Width = 200;
			objTextColumn.ReadOnly = true;
			objTextColumn.NullText = "";
			mobjGridTableStyle.GridColumnStyles.Add(objTextColumn);

			objTextColumn = new DataGridTextBoxColumn();
			objTextColumn.MappingName = "PurposeOrCondition";
			objTextColumn.HeaderText = "Requirement Condition";
			objTextColumn.Width = 210;
			objTextColumn.ReadOnly = true;
			objTextColumn.NullText = "";
			mobjGridTableStyle.GridColumnStyles.Add(objTextColumn);

			objTextColumn = new DataGridTextBoxColumn();
			objTextColumn.MappingName = "Confirmity";
			objTextColumn.HeaderText = "Conformity";
			objTextColumn.Width = 60;
			objTextColumn.ReadOnly = false;
			objTextColumn.NullText = "";
			mobjGridTableStyle.GridColumnStyles.Add(objTextColumn);

			objTextColumn = new DataGridTextBoxColumn();
			objTextColumn.MappingName = "Comments";
			objTextColumn.HeaderText = "Comments";
			objTextColumn.Width = 100;
			objTextColumn.ReadOnly = false;
			objTextColumn.NullText = "";
			mobjGridTableStyle.GridColumnStyles.Add(objTextColumn);

			objTextColumn = new DataGridTextBoxColumn();
			objTextColumn.MappingName = "TestID";
			objTextColumn.HeaderText = "TestID";
			objTextColumn.Width = 0;
			objTextColumn.ReadOnly = true;
			objTextColumn.NullText = "";
			mobjGridTableStyle.GridColumnStyles.Add(objTextColumn);

			mobjGridTableStyle.GridLineColor = Color.Black;
			DataGrid1.TableStyles.Add(mobjGridTableStyle);
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = "Error in Formating IQ Test List Data-Grid.";
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

	public bool funcSaveIQTestData()
	{
		//=====================================================================
		// Procedure Name        :   funcSaveIQTestData
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

		int intRecordCount;
		int intTestID;
		int temp_cnt;
		string strComment;
		string strConfirmity;
		bool status = true;

		try {
			intRecordCount = mObjDataTable.Rows.Count;


			for (temp_cnt = 0; temp_cnt <= (intRecordCount - 1); temp_cnt++) {
				//--- To Check if Test ID is Null.

				if (IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("TestID").Ordinal))) {
				} else {
					intTestID = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("TestID").Ordinal);
					strComment = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("Comments").Ordinal);
					strConfirmity = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("Confirmity").Ordinal);
					status = funcUpdateIQTestData(strComment, strConfirmity, intTestID);
					if (!(status)) {
						throw new Exception("Error in Updating IQ Test Details.");
					}
				}
			}
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = "Error in Saving IQ Test Details.";
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

	private bool funcInsertIQTestData(string strTestName, string strPurpose)
	{
		//=====================================================================
		// Procedure Name        :   funcInsertIQTestData
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

		bool Status;
		string str_sql;
		string strConfirm;
		OleDbCommand objCommand = new OleDbCommand();
		int intTestID;

		try {
			strConfirm = "False";
			//Status = gclsDBFunctions.OpenConnection(gOleDBIQOQPQConnection)
			if (!(Status)) {
				throw new Exception("Error in Opening Connection during Saving IQ Test Details.");
			}

			//--- Generating Next Equipment ID. 
			//intTestID = gclsDBFunctions.GetNextID("Test", "TestID", gOleDBIQOQPQConnection)

			//---  Query for adding  data to Test
			str_sql = " Insert into Test " + " (TestID ,TestName ,PurposeOrCondition ,CheckStatusIQOQPQ ,Confirmity ,Comments) " + " values(?,?,?,?,?,?) ";

			//--- Providing command object for Test
				//.Connection = gOleDBIQOQPQConnection
			 // ERROR: Not supported in C#: WithStatement


			objCommand.Dispose();
			Status = true;

		} catch (Exception ex) {
			//---------------------------------------------------------
			//--- Error logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = "Error in Saving IQ Test Details.";
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

		return Status;

	}

	private bool funcUpdateIQTestData(string strComment, string strConfirmity, int intTestID)
	{
		//=====================================================================
		// Procedure Name        :   funcUpdateIQTestData
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

		bool Status;
		string str_sql;
		OleDbCommand objCommand = new OleDbCommand();

		try {
			//Status = gclsDBFunctions.OpenConnection(gOleDBIQOQPQConnection)
			if (!(Status)) {
				throw new Exception("Error in Opening Connection during Updating IQ Test Details.");
			}

			//---  Query for adding  data to Test            
			str_sql = " Update Test set " + "Confirmity = ? , Comments = ? " + " where TestID = " + intTestID + " " + " and CheckStatusIQOQPQ=1 ";

			//--- Providing command object for EquimentList
				//.Connection = gOleDBIQOQPQConnection
			 // ERROR: Not supported in C#: WithStatement


			objCommand.Dispose();
			Status = true;

		} catch (Exception ex) {
			//---------------------------------------------------------
			//--- Error logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = "Error in Updating IQ Test Details.";
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

		return Status;

	}

	private bool funcDeleteIQTestData(int intTestID)
	{
		//=====================================================================
		// Procedure Name        :   funcDeleteIQTestData
		// Description           :   To Delete Test Data from Database.
		// Purpose               :   To Delete Test Data from Database.
		// Parameters Passed     :   None.
		// Returns               :   None.
		// Parameters Affected   :   None.
		// Assumptions           :
		// Dependencies          :
		// Author                :   Gitesh
		// Created               :   January, 2003 
		// Revisions             :
		//=====================================================================

		bool Status;
		string str_sql;

		try {
			//Status = gclsDBFunctions.OpenConnection(gOleDBIQOQPQConnection)
			if (!(Status)) {
				throw new Exception("Error in Opening Connection during Deleting IQ Test Details.");
			}

			//--- Query to Delete from Database
			str_sql = " Delete * from Test where TestID = " + intTestID + " and and CheckStatusIQOQPQ = 1  ";

			//Status = gclsDBFunctions.AddORDeleteRecord(str_sql, gOleDBIQOQPQConnection)
			if ((Status == false)) {
				throw new Exception("Error in Deleting IQ Test Details.");
			}

		} catch (Exception ex) {
			//---------------------------------------------------------
			//--- Error logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = "Error in Deleting IQ Test Details.";
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

		return Status;

	}

	#End Region


	///Private Sub DataGrid1_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGrid1.CurrentCellChanged
	///    If Not (mblnModeLockStatus) Then
	///        If (DataGrid1.CurrentCell.ColumnNumber = CONST_ConfirmColumnNo) Then
	///            mobjCmbBox.Top = DataGrid1.GetCurrentCellBounds().Top
	///            mobjCmbBox.Left = DataGrid1.GetCurrentCellBounds().Left
	///            mobjCmbBox.Width = DataGrid1.GetCurrentCellBounds().Width
	///            mobjCmbBox.Height = DataGrid1.GetCurrentCellBounds().Height
	///            If (DataGrid1.CurrentCell.RowNumber) > 0 Then
	///                If IsDBNull(DataGrid1(DataGrid1.CurrentCell.RowNumber, DataGrid1.CurrentCell.ColumnNumber)) = False Then
	///                    Dim strval = DataGrid1(DataGrid1.CurrentCell.RowNumber, DataGrid1.CurrentCell.ColumnNumber)
	///                    'If (strval = "TRUE") Then
	///                    If (strval = "YES") Then
	///                        mobjCmbBox.SelectedIndex = 0
	///                    Else
	///                        mobjCmbBox.SelectedIndex = 1
	///                    End If
	///                Else
	///                    mobjCmbBox.SelectedIndex = 0
	///                End If
	///            End If
	///            mobjCmbBox.Visible = True
	///        Else
	///            mobjCmbBox.Width = 0
	///            mobjCmbBox.Visible = False
	///        End If
	///    End If
	///End Sub

}
