
using System.Data;
using System.Data.OleDb;
using ErrorHandler.ErrorHandler;

public class frmIQTest : System.Windows.Forms.Form
{

	#Region " Module level Declarations "
	private ComboBox mobjCmbBox;
	private const  CONST_ConfirmColumnNo = 2;
	private const  CONST_NoOfTests = 5;
	private bool mblnModeLockStatus;
	private string mstrOledbConnectionString;
	private OleDbConnection mobjOleDBconnection;
	//Public mclsDBFunctions As New clsDatabaseFunctions

	private DataTable mObjDataTable;

	DataGridTableStyle mobjGridTableStyle = new DataGridTableStyle();
	//code added by ; dinesh wagh on 27.6.2010
	//---------------------------------------------
	int mintRowIndex;
	int mintColumnIndex;
	bool mblnAvoidProcessing;
	private const  CONST_COMMENT_COLUMN_NO = 3;
	//----------------------------------------

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

	#Region " Windows Form Designer generated code "

	public frmIQTest()
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
	internal System.Windows.Forms.Label Label3;
	internal System.Windows.Forms.Panel Panel1;
	internal System.Windows.Forms.DataGrid dgTest;
	internal System.Windows.Forms.Panel Panel2;
	internal System.Windows.Forms.PictureBox PictureBox1;
	[System.Diagnostics.DebuggerStepThrough()]
	private void InitializeComponent()
	{
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmIQTest));
		this.Label3 = new System.Windows.Forms.Label();
		this.Panel1 = new System.Windows.Forms.Panel();
		this.Panel2 = new System.Windows.Forms.Panel();
		this.PictureBox1 = new System.Windows.Forms.PictureBox();
		this.dgTest = new System.Windows.Forms.DataGrid();
		this.Panel1.SuspendLayout();
		this.Panel2.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.dgTest).BeginInit();
		this.SuspendLayout();
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
		//Panel1
		//
		this.Panel1.AutoScroll = true;
		this.Panel1.BackColor = System.Drawing.Color.AliceBlue;
		this.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.Panel1.Controls.Add(this.Panel2);
		this.Panel1.Controls.Add(this.dgTest);
		this.Panel1.Dock = System.Windows.Forms.DockStyle.Top;
		this.Panel1.Location = new System.Drawing.Point(0, 0);
		this.Panel1.Name = "Panel1";
		this.Panel1.Size = new System.Drawing.Size(720, 576);
		this.Panel1.TabIndex = 12;
		//
		//Panel2
		//
		this.Panel2.AutoScroll = true;
		this.Panel2.BackColor = System.Drawing.Color.AliceBlue;
		this.Panel2.Controls.Add(this.PictureBox1);
		this.Panel2.Controls.Add(this.Label3);
		this.Panel2.Dock = System.Windows.Forms.DockStyle.Top;
		this.Panel2.Location = new System.Drawing.Point(0, 0);
		this.Panel2.Name = "Panel2";
		this.Panel2.Size = new System.Drawing.Size(718, 32);
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
		//dgTest
		//
		this.dgTest.BackgroundColor = System.Drawing.Color.AliceBlue;
		this.dgTest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.dgTest.CaptionVisible = false;
		this.dgTest.DataMember = "";
		this.dgTest.HeaderForeColor = System.Drawing.SystemColors.ControlText;
		this.dgTest.Location = new System.Drawing.Point(8, 48);
		this.dgTest.Name = "dgTest";
		this.dgTest.ParentRowsVisible = false;
		this.dgTest.ReadOnly = true;
		this.dgTest.RowHeadersVisible = false;
		this.dgTest.Size = new System.Drawing.Size(704, 520);
		this.dgTest.TabIndex = 18;
		//
		//frmIQTest
		//
		this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
		this.AutoScroll = true;
		this.BackColor = System.Drawing.Color.AliceBlue;
		this.ClientSize = new System.Drawing.Size(720, 584);
		this.ControlBox = false;
		this.Controls.Add(this.Panel1);
		this.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		this.MaximizeBox = false;
		this.MinimizeBox = false;
		this.Name = "frmIQTest";
		this.Text = "INSTALLATION QUALIFICATION TEST";
		this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
		this.Panel1.ResumeLayout(false);
		this.Panel2.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.dgTest).EndInit();
		this.ResumeLayout(false);

	}

	#End Region

	#Region "Constants"

	private const string ConstTestName = "TestName";
	private const string ConstPurposeOrCondition = "PurposeOrCondition";
	private const string ConstConfirmity = "Confirmity";
	private const string ConstComments = "Comments";

	private const string ConstTestID = "TestID";
	#End Region

	#Region " Form Events "

	private void  // ERROR: Handles clauses are not supported in C#
frmIQMannualList_Load(object sender, System.EventArgs e)
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
frmIQMannualList_Closing(object sender, System.ComponentModel.CancelEventArgs e)
	{
		try {
			if (!(mblnModeLockStatus)) {
				dgTest.CurrentCell() = (new DataGridCell(dgTest.CurrentRowIndex + 1, 0));
				if (!funcSaveIQTestData()) {
					throw new Exception("Error in Saving IQ Tests Data.");
				}
				dgTest.TableStyles.Clear();
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
		// Description           :   To Initialize form and to get values for IQ Test Data from database and display them.
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
		DataTable mobjTmpDt;
		int intCount;
		DataRow objDataRow;

		try {
			//mfrmTest = Me
			mObjDataTable = new DataTable("Test");
			mobjCmbBox = new ComboBox();

			//--- To Add Run-Time DateTime Picker Control
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

			subCreateDataTable();

			mobjTmpDt = new DataTable();

			mobjTmpDt = gobjDataAccess.funcGetIQTestRecords();

			if (!mobjTmpDt == null) {
				if (!mobjTmpDt.Rows.Count == 0) {
					for (intCount = 0; intCount <= mobjTmpDt.Rows.Count - 1; intCount++) {
						objDataRow = mObjDataTable.NewRow;
						//objDataRow.Item(ConstTestName) = CStr(mobjTmpDt.Rows.Item(intCount).Item("TestName")) '2.4.2010
						objDataRow.Item(ConstTestName) = gfuncWordWrap((string)mobjTmpDt.Rows.Item(intCount).Item("TestName"), 25);
						//2.4.2010
						//objDataRow.Item(ConstPurposeOrCondition) = CStr(mobjTmpDt.Rows.Item(intCount).Item("PurposeOrCondition")) '2.4.2010
						objDataRow.Item(ConstPurposeOrCondition) = gfuncWordWrap((string)mobjTmpDt.Rows.Item(intCount).Item("PurposeOrCondition"), 60);
						//2.4.2010

						objDataRow.Item(ConstConfirmity) = (string)mobjTmpDt.Rows.Item(intCount).Item("Confirmity");
						if ((IsDBNull(mobjTmpDt.Rows.Item(intCount).Item("Comments")))) {
							objDataRow.Item(ConstComments) = "";
						} else {
							//objDataRow.Item(ConstComments) = CStr(mobjTmpDt.Rows.Item(intCount).Item("Comments")) '2.4.2010
							objDataRow.Item(ConstComments) = gfuncWordWrap((string)mobjTmpDt.Rows.Item(intCount).Item("Comments"), 18);
							//2.4.2010
						}
						objDataRow.Item(ConstTestID) = (int)mobjTmpDt.Rows.Item(intCount).Item("TestID");
						mObjDataTable.Rows.Add(objDataRow);

					}
				}
			}

			if (IsNothing(mObjDataTable) == true) {
				throw new Exception("Error in Getting Equipment List Records.");

			} else {
				subFormatDataGrid();
			}

			//If funcGetIQTestRecords() Then
			//    subFormatDataGrid()
			//Else
			//    Throw New Exception("Error in Getting IQ Test Records.")
			//End If

			mblnModeLockStatus = gobjDataAccess.funcCheckModeLocked(ENUM_IQOQPQ_STATUS.IQ);
			if ((mblnModeLockStatus)) {
				dgTest.ReadOnly = true;
			} else {
				dgTest.ReadOnly = false;
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

	private void CmbBox_SelectedIndexChanged(System.Object sender, System.EventArgs e)
	{
		//try catch added by ; dinesh wagh on 3.2.2010
		try {
			dgTest(dgTest.CurrentCell.RowNumber, dgTest.CurrentCell.ColumnNumber) = mobjCmbBox.Text;
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

	//Private Function funcGetIQTestRecords() As Boolean
	//    '=====================================================================
	//    ' Procedure Name        :   funcGetIQTestRecords
	//    ' Description           :   To Get IQ Test Records from Database into DataTable.
	//    ' Purpose               :   To Get IQ Test Records from Database into DataTable.
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
	//    Dim objDataRow As DataRow
	//    Dim sql_string As String
	//    Dim reader_status As Boolean
	//    Dim intTableRecordCount, temp_cnt As Integer
	//    Dim ObjStructmTest As New mTest

	//    Try
	//        'reader_status = mclsDBFunctions.GetRecords("Select * from Test where CheckStatusIQOQPQ = 1 ", mobjOleDBconnection, objReader)

	//        If Not (reader_status) Then
	//            Throw New Exception("Error in Opening Connection during Getting IQ Test Details.")
	//        End If

	//        'intTableRecordCount = mclsDBFunctions.GetNoOfRec(objReader)
	//        objReader.Close()

	//        If intTableRecordCount <= 0 Then
	//            For temp_cnt = 0 To (CONST_NoOfTests)
	//                'Assigning Struct Object
	//                Call funcFillStruct(ObjStructmTest, temp_cnt)

	//                'Insert Item and Requirement and Condition                
	//                If Not (funcInsertIQTestData(ObjStructmTest.mItem, ObjStructmTest.RequirementCondition)) Then
	//                    Throw New Exception("Error in Opening Connection during Getting IQ Test Details.")
	//                End If
	//            Next
	//        End If

	//        sql_string = "Select TestID ,TestName ,PurposeOrCondition ,Confirmity ,Comments from Test where CheckStatusIQOQPQ = 1 "

	//        'reader_status = mclsDBFunctions.GetRecords(sql_string, mobjOleDBconnection, objReader)

	//        If Not (reader_status) Then
	//            Throw New Exception("Error in Opening Connection during Getting IQ Test Details.")
	//        End If

	//        While objReader.Read
	//            objDataRow = mObjDataTable.NewRow()

	//            objDataRow("TestName") = CStr(objReader.Item("TestName"))
	//            objDataRow("PurposeOrCondition") = CStr(objReader.Item("PurposeOrCondition"))
	//            objDataRow("Confirmity") = CStr(objReader.Item("Confirmity")) & " "
	//            objDataRow("Comments") = CStr(objReader.Item("Comments")) & ""
	//            objDataRow("TestID") = Convert.ToInt32(objReader.Item("TestID"))

	//            mObjDataTable.Rows.Add(objDataRow)
	//        End While
	//        objReader.Close()

	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        'Error logging
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = "Error in Getting Equipment List Records."
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

	private void subFormatDataGrid()
	{
		DataGridTextBoxColumn objTextColumn;
		DataView objDataView = new DataView();
		try {
			dgTest.TableStyles.Clear();
			objDataView.Table = mObjDataTable;
			objDataView.AllowNew = false;
			dgTest.DataSource = objDataView;
			//dgTest.ReadOnly = False
			mobjGridTableStyle.PreferredRowHeight = 100;
			//2.4.2010 by dinesh wagh
			mobjGridTableStyle.RowHeadersVisible = false;
			mobjGridTableStyle.ResetAlternatingBackColor();
			mobjGridTableStyle.ResetBackColor();
			mobjGridTableStyle.ResetForeColor();
			mobjGridTableStyle.ResetGridLineColor();
			mobjGridTableStyle.BackColor = Color.AliceBlue;
			mobjGridTableStyle.GridLineColor = Color.Black;
			mobjGridTableStyle.HeaderBackColor = Color.FromArgb(205, 225, 250);
			mobjGridTableStyle.HeaderForeColor = Color.Black;
			mobjGridTableStyle.AlternatingBackColor = Color.AliceBlue;
			mobjGridTableStyle.AllowSorting = false;

			mobjGridTableStyle.MappingName = "Test";

			objTextColumn = new DataGridTextBoxColumn();
			objTextColumn.TextBox.WordWrap = true;
			//2.4.2010 by dinesh wagh
			objTextColumn.MappingName = "TestName";
			objTextColumn.HeaderText = "Item";
			objTextColumn.Width = 150;
			//200 '2.4.2010 by dinesh wagh
			objTextColumn.ReadOnly = true;
			objTextColumn.NullText = "";
			mobjGridTableStyle.GridColumnStyles.Add(objTextColumn);

			objTextColumn = new DataGridTextBoxColumn();
			objTextColumn.TextBox.WordWrap = true;
			//2.4.2010 by dinesh wagh
			objTextColumn.MappingName = "PurposeOrCondition";
			objTextColumn.HeaderText = "Requirement Condition";
			objTextColumn.Width = 350;
			//210  on 2.4.2010 by dinesh wagh
			objTextColumn.ReadOnly = true;
			objTextColumn.NullText = "";
			mobjGridTableStyle.GridColumnStyles.Add(objTextColumn);

			objTextColumn = new DataGridTextBoxColumn();
			objTextColumn.TextBox.WordWrap = true;
			//2.4.2010 by dinesh wagh
			objTextColumn.MappingName = "Confirmity";
			objTextColumn.HeaderText = "Conformity";
			objTextColumn.Width = 70;
			objTextColumn.ReadOnly = false;
			objTextColumn.NullText = "";
			mobjGridTableStyle.GridColumnStyles.Add(objTextColumn);

			objTextColumn = new DataGridTextBoxColumn();
			objTextColumn.TextBox.WordWrap = true;
			//2.4.2010 by dinesh wagh
			objTextColumn.MappingName = "Comments";
			objTextColumn.HeaderText = "Comments";
			objTextColumn.Width = 110;
			//90 by dinesh wagh 2.4.2010
			objTextColumn.ReadOnly = false;
			objTextColumn.NullText = "";
			mobjGridTableStyle.GridColumnStyles.Add(objTextColumn);

			objTextColumn = new DataGridTextBoxColumn();
			objTextColumn.TextBox.WordWrap = true;
			//2.4.2010 by dinesh wagh
			objTextColumn.MappingName = "TestID";
			objTextColumn.HeaderText = "TestID";
			objTextColumn.Width = 0;
			objTextColumn.ReadOnly = true;
			objTextColumn.NullText = "";
			mobjGridTableStyle.GridColumnStyles.Add(objTextColumn);

			mobjGridTableStyle.GridLineColor = Color.Black;
			dgTest.TableStyles.Add(mobjGridTableStyle);
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

					if (IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("Comments").Ordinal))) {
						strComment = "";
					} else {
						strComment = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("Comments").Ordinal);
						strComment = strComment.Replace(vbCrLf, " ");
						//24.6.2010 by dinesh wagh to make the string which has no vbcrlf.
					}
					if (IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("Confirmity").Ordinal))) {
						strConfirmity = "";
					} else {
						strConfirmity = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("Confirmity").Ordinal);
					}

					// strConfirmity = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("Confirmity").Ordinal)
					status = gobjDataAccess.funcUpdateIQTestData(strComment, strConfirmity, intTestID);
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

	//Private Function funcInsertIQTestData(ByVal strTestName As String, ByVal strPurpose As String) As Boolean
	//    '=====================================================================
	//    ' Procedure Name        :   funcInsertIQTestData
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
	//    Dim str_sql, strConfirm As String
	//    Dim objCommand As New OleDbCommand
	//    Dim intTestID As Integer

	//    Try
	//        strConfirm = "False"
	//        'Status = mclsDBFunctions.OpenConnection(mobjOleDBconnection)
	//        If Not (Status) Then
	//            Throw New Exception("Error in Opening Connection during Saving IQ Test Details.")
	//        End If

	//        '--- Generating Next Equipment ID. 
	//        'intTestID = mclsDBFunctions.GetNextID("Test", "TestID", mobjOleDBconnection)

	//        '---  Query for adding  data to Test
	//        str_sql = " Insert into Test " & _
	//                  " (TestID ,TestName ,PurposeOrCondition ,CheckStatusIQOQPQ ,Confirmity ,Comments) " & _
	//                  " values(?,?,?,?,?,?) "

	//        '--- Providing command object for Test
	//        With objCommand
	//            .Connection = mobjOleDBconnection
	//            .CommandType = CommandType.Text
	//            .CommandText = str_sql
	//            .Parameters.Add("TestID", OleDbType.Numeric).Value = intTestID
	//            .Parameters.Add("TestName", OleDbType.WChar).Value = strTestName
	//            .Parameters.Add("PurposeOrCondition", OleDbType.VarChar, 350).Value = strPurpose
	//            .Parameters.Add("CheckStatusIQOQPQ", OleDbType.Single).Value = CSng(ENUM_IQOQPQ_STATUS.IQ)
	//            .Parameters.Add("Confirmity", OleDbType.VarChar, 350).Value = strConfirm & " "
	//            .Parameters.Add("Comments", OleDbType.VarChar, 350).Value = strConfirm & " "
	//            .ExecuteNonQuery()
	//        End With

	//        objCommand.Dispose()
	//        Status = True

	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        '--- Error logging
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = "Error in Saving IQ Test Details."
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

	//Private Function funcUpdateIQTestData(ByVal strComment As String, ByVal strConfirmity As String, ByVal intTestID As Integer) As Boolean
	//    '=====================================================================
	//    ' Procedure Name        :   funcUpdateIQTestData
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
	//            Throw New Exception("Error in Opening Connection during Updating IQ Test Details.")
	//        End If

	//        '---  Query for adding  data to Test            
	//        str_sql = " Update Test set " & _
	//                  "Confirmity = ? , Comments = ? " & _
	//                  " where TestID = " & intTestID & " " & _
	//                  " and CheckStatusIQOQPQ=1 "

	//        '--- Providing command object for EquimentList
	//        With objCommand
	//            .Connection = mobjOleDBconnection
	//            .CommandType = CommandType.Text
	//            .CommandText = str_sql
	//            .Parameters.Add("Confirmity", OleDbType.VarChar, 250).Value = strConfirmity
	//            .Parameters.Add("Comments", OleDbType.VarChar, 250).Value = strComment
	//            .ExecuteNonQuery()
	//        End With

	//        objCommand.Dispose()
	//        Status = True

	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        '--- Error logging
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = "Error in Updating IQ Test Details."
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

	//Private Function funcDeleteIQTestData(ByVal intTestID As Integer) As Boolean
	//    '=====================================================================
	//    ' Procedure Name        :   funcDeleteIQTestData
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
	//            Throw New Exception("Error in Opening Connection during Deleting IQ Test Details.")
	//        End If

	//        '--- Query to Delete from Database
	//        str_sql = " Delete * from Test where TestID = " & intTestID & " and and CheckStatusIQOQPQ = 1  "

	//        'Status = mclsDBFunctions.AddORDeleteRecord(str_sql, mobjOleDBconnection)
	//        If (Status = False) Then
	//            Throw New Exception("Error in Deleting IQ Test Details.")
	//        End If

	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        '--- Error logging
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = "Error in Deleting IQ Test Details."
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

	private object funcFillStruct(ref mTest objstructTest, int testNo)
	{
		//try catch added by ; dinesh wagh on 3.2.2010

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
			if (!(mblnModeLockStatus)) {
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
				if (mintColumnIndex == CONST_COMMENT_COLUMN_NO) {
					strString = dgTest.Item(mintRowIndex, mintColumnIndex);
					if (!(strString == "")) {
						strString = strString.Replace(vbCrLf, " ");
						dgTest.Item(mintRowIndex, mintColumnIndex) = gfuncWordWrap(strString, 18);
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
			//27.6.2010 by dinesh wagh on 27.6.2010
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
