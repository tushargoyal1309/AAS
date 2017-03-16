
using System.Data;
using System.Data.OleDb;
using ErrorHandler.ErrorHandler;

public class frmOQUserTraining : System.Windows.Forms.Form
{

	#Region " Module level Declarations "
	private bool mblnModeLockStatus;
	private string mstrOledbConnectionString;
	private OleDbConnection mobjOleDBconnection;
	//Public mclsDBFunctions As New clsDatabaseFunctions
	DateTimePicker mdtpUserDate;
	private DataView mobjDataView = new DataView();
	private DataTable mObjDataTable;
	private DataTable mobjCADataTable;
	 mobjGridTableStyle;

	DataGridTableStyle mobjCAGridTableStyle = new DataGridTableStyle();

	//29.6.2010 by dinesh wagh
	//-----------
	int mintRowIndex;
	int mintColumnIndex;
	bool mblnAvoidProcessing;
	//----------


	#End Region

	#Region " Windows Form Designer generated code "

	public frmOQUserTraining()
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
	internal System.Windows.Forms.Label lblHeader2;
	internal System.Windows.Forms.Label lblHeader1;
	internal System.Windows.Forms.Panel Panel1;
	internal System.Windows.Forms.DataGrid dgTraining;
	internal System.Windows.Forms.DataGrid dgUser;
	internal System.Windows.Forms.Panel Panel2;
	internal System.Windows.Forms.PictureBox PictureBox1;
	[System.Diagnostics.DebuggerStepThrough()]
	private void InitializeComponent()
	{
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmOQUserTraining));
		this.lblHeader2 = new System.Windows.Forms.Label();
		this.lblHeader1 = new System.Windows.Forms.Label();
		this.Panel1 = new System.Windows.Forms.Panel();
		this.Panel2 = new System.Windows.Forms.Panel();
		this.PictureBox1 = new System.Windows.Forms.PictureBox();
		this.dgUser = new System.Windows.Forms.DataGrid();
		this.dgTraining = new System.Windows.Forms.DataGrid();
		this.Panel1.SuspendLayout();
		this.Panel2.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.dgUser).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dgTraining).BeginInit();
		this.SuspendLayout();
		//
		//lblHeader2
		//
		this.lblHeader2.BackColor = System.Drawing.Color.AliceBlue;
		this.lblHeader2.Font = new System.Drawing.Font("Arial", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblHeader2.Location = new System.Drawing.Point(8, 320);
		this.lblHeader2.Name = "lblHeader2";
		this.lblHeader2.Size = new System.Drawing.Size(144, 20);
		this.lblHeader2.TabIndex = 12;
		this.lblHeader2.Text = "User Training - ";
		this.lblHeader2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//lblHeader1
		//
		this.lblHeader1.BackColor = System.Drawing.Color.AliceBlue;
		this.lblHeader1.Font = new System.Drawing.Font("Arial", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblHeader1.Location = new System.Drawing.Point(35, 7);
		this.lblHeader1.Name = "lblHeader1";
		this.lblHeader1.Size = new System.Drawing.Size(528, 18);
		this.lblHeader1.TabIndex = 11;
		this.lblHeader1.Text = "D.III OPERATIONAL USER TRAINING";
		this.lblHeader1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//Panel1
		//
		this.Panel1.AutoScroll = true;
		this.Panel1.BackColor = System.Drawing.Color.AliceBlue;
		this.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.Panel1.Controls.Add(this.Panel2);
		this.Panel1.Controls.Add(this.dgUser);
		this.Panel1.Controls.Add(this.dgTraining);
		this.Panel1.Controls.Add(this.lblHeader2);
		this.Panel1.Dock = System.Windows.Forms.DockStyle.Top;
		this.Panel1.Location = new System.Drawing.Point(0, 0);
		this.Panel1.Name = "Panel1";
		this.Panel1.Size = new System.Drawing.Size(680, 512);
		this.Panel1.TabIndex = 12;
		//
		//Panel2
		//
		this.Panel2.BackColor = System.Drawing.Color.AliceBlue;
		this.Panel2.Controls.Add(this.PictureBox1);
		this.Panel2.Controls.Add(this.lblHeader1);
		this.Panel2.Dock = System.Windows.Forms.DockStyle.Top;
		this.Panel2.Location = new System.Drawing.Point(0, 0);
		this.Panel2.Name = "Panel2";
		this.Panel2.Size = new System.Drawing.Size(678, 32);
		this.Panel2.TabIndex = 20;
		//
		//PictureBox1
		//
		this.PictureBox1.BackColor = System.Drawing.Color.AliceBlue;
		this.PictureBox1.Image = (System.Drawing.Image)resources.GetObject("PictureBox1.Image");
		this.PictureBox1.Location = new System.Drawing.Point(0, 0);
		this.PictureBox1.Name = "PictureBox1";
		this.PictureBox1.Size = new System.Drawing.Size(32, 32);
		this.PictureBox1.TabIndex = 0;
		this.PictureBox1.TabStop = false;
		//
		//dgUser
		//
		this.dgUser.BackgroundColor = System.Drawing.Color.AliceBlue;
		this.dgUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.dgUser.CaptionVisible = false;
		this.dgUser.DataMember = "";
		this.dgUser.HeaderForeColor = System.Drawing.SystemColors.ControlText;
		this.dgUser.Location = new System.Drawing.Point(8, 344);
		this.dgUser.Name = "dgUser";
		this.dgUser.ParentRowsVisible = false;
		this.dgUser.ReadOnly = true;
		this.dgUser.RowHeadersVisible = false;
		this.dgUser.Size = new System.Drawing.Size(640, 152);
		this.dgUser.TabIndex = 19;
		//
		//dgTraining
		//
		this.dgTraining.BackgroundColor = System.Drawing.Color.AliceBlue;
		this.dgTraining.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.dgTraining.CaptionVisible = false;
		this.dgTraining.DataMember = "";
		this.dgTraining.HeaderForeColor = System.Drawing.SystemColors.ControlText;
		this.dgTraining.Location = new System.Drawing.Point(8, 48);
		this.dgTraining.Name = "dgTraining";
		this.dgTraining.ParentRowsVisible = false;
		this.dgTraining.ReadOnly = true;
		this.dgTraining.RowHeadersVisible = false;
		this.dgTraining.Size = new System.Drawing.Size(640, 264);
		this.dgTraining.TabIndex = 18;
		//
		//frmOQUserTraining
		//
		this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
		this.AutoScroll = true;
		this.BackColor = System.Drawing.Color.AliceBlue;
		this.ClientSize = new System.Drawing.Size(680, 520);
		this.ControlBox = false;
		this.Controls.Add(this.Panel1);
		this.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		this.MaximizeBox = false;
		this.MinimizeBox = false;
		this.Name = "frmOQUserTraining";
		this.Text = "frmOQUserTraining";
		this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
		this.Panel1.ResumeLayout(false);
		this.Panel2.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.dgUser).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dgTraining).EndInit();
		this.ResumeLayout(false);

	}

	#End Region

	#Region "Constants"

	private const string ConstSrNo = "SrNo";
	private const string ConstTrainingType = "TrainingType";
	private const string ConstTrainingGiven = "TrainingGiven";
	private const string ConstTrainingComments = "TrainingComments";

	private const string ConstTrainingID = "TrainingID";
	private const string ConstUserName = "UserName";
	private const string ConstUserDate = "UserDate";

	private const string ConstUserID = "UserID";
	#End Region

	#Region " Form Events "
	private void  // ERROR: Handles clauses are not supported in C#
frmOQUserTraining_Load(object sender, System.EventArgs e)
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
frmOQUserTraining_Closing(object sender, System.ComponentModel.CancelEventArgs e)
	{
		try {
			if (!(mblnModeLockStatus)) {
				dgTraining.CurrentCell() = (new DataGridCell(dgTraining.CurrentRowIndex + 1, 0));
				if (!funcSaveOQUserTrainingData()) {
					throw new Exception("Error in Saving User Training Data.");
				}
				dgTraining.TableStyles.Clear();

				dgUser.CurrentCell() = (new DataGridCell(dgUser.CurrentRowIndex + 1, 0));
				if (!funcSaveOQUserData()) {
					throw new Exception("Error in Saving User Details.");
				}
				dgUser.TableStyles.Clear();
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
	//    General functions used for OQ User and User Training.
	//--- funcInitialize - To Initialize form and to get values for OQ User and User Training Data from database and display them.
	//--- subCreateUserTrainingDataTable - To Create Columns in the Data Table.
	//--- funcGetOQUserTrainingRecords - To Get OQ User Training Records from Database into DataTable.
	//--- subFormatUserTrainingDataGrid - To format the User Training data in Data Grid.
	//--- funcSaveOQUserTrainingData - To Save the Entered Records into Database.
	//--- funcInsertOQUserTrainingData - To Add/Insert New User Training Data in Database.
	//--- funcUpdateOQUserTrainingData - To Update User Training Data in Database.
	//--- funcDeleteOQUserTrainingData - To Delete User Training Data from Database.

	//--- subCreateUserDataTable - To Create Columns in the Data Table.
	//--- funcGetOQUserRecords - To Get OQ User Records from Database into DataTable.
	//--- subFormatUserDataGrid - To format the User data into Data Grid.
	//--- funcSaveOQUserData - To Save the Entered Records into Database.
	//--- funcInsertOQUserData - To Add/Insert New User Data in Database.
	//--- funcUpdateOQUserData - To Update User Data in Database.
	//--- funcDeleteOQUserData - To Delete User Action Data from Database.

	private void dtpUserDate_ValueChanged(System.Object sender, System.EventArgs e)
	{
		dgUser(dgUser.CurrentCell.RowNumber, dgUser.CurrentCell.ColumnNumber) = mdtpUserDate.Value;
	}


	private void funcInitialize()
	{
		//=====================================================================
		// Procedure Name        :   funcInitailize
		// Description           :   To Initialize form and to get values for OQ User and User Training Data from database and display them.
		// Purpose               :   To Initialize form and to get values for OQ User and User Training Data from database and display them.
		// Parameters Passed     :   None.
		// Returns               :   None.
		// Parameters Affected   :   None.
		// Assumptions           :
		// Dependencies          :
		// Author                :   Gitesh
		// Created               :   January, 2003 
		// Revisions             : Pankaj 03 May 07
		//=====================================================================
		int intCount = 0;
		DataTable mobjTmpDt;
		DataRow objDataRow;

		try {
			//mfrmUserTraining = Me
			mObjDataTable = new DataTable("OQUserTraining");
			mobjCADataTable = new DataTable("OQUser");

			mdtpUserDate = new DateTimePicker();

			//--- Initialising Connection String
			//mstrOledbConnectionString = mclsDBFunctions.ConnectionString(CONST_IQOQPQ_DATABASENAME)

			//--- Initialising Connection 
			mobjOleDBconnection = new OleDbConnection(mstrOledbConnectionString);

			mdtpUserDate.ValueChanged += dtpUserDate_ValueChanged;
			dgUser.Controls.Add(mdtpUserDate);
			mdtpUserDate.Visible = false;
			mdtpUserDate.Format = DateTimePickerFormat.Custom;
			mdtpUserDate.CustomFormat = "dd-MMM-yyyy";

			mObjDataTable.Columns.Add("SrNo");
			mObjDataTable.Columns.Add("TrainingType");
			mObjDataTable.Columns.Add("TrainingGiven");
			mObjDataTable.Columns.Add("TrainingComments");
			mObjDataTable.Columns.Add("TrainingID");

			//subCreateUserTrainingDataTable()

			//If funcGetPQTest2Records() Then
			//    subFormatUserTrainingDataGrid()
			//Else
			//    Throw New Exception("Error in Getting User Training Records.")
			//End If

			subCreateUserDataTable();

			mobjTmpDt = new DataTable();
			mobjTmpDt = gobjDataAccess.funcGetOQUserTrainingRecords();

			if (!mobjTmpDt == null) {
				if (!mobjTmpDt.Rows.Count == 0) {
					for (intCount = 0; intCount <= mobjTmpDt.Rows.Count - 1; intCount++) {
						objDataRow = mObjDataTable.NewRow;
						objDataRow.Item(ConstSrNo) = (int)mobjTmpDt.Rows.Item(intCount).Item("TrainingID");

						//objDataRow.Item(ConstTrainingType) = CStr(mobjTmpDt.Rows.Item(intCount).Item("TrainingType"))'2.4.2010 by dinesh wagh
						objDataRow.Item(ConstTrainingType) = gfuncWordWrap((string)mobjTmpDt.Rows.Item(intCount).Item("TrainingType"), 45);
						//2.4.2010 by dinesh wagh

						//Condition added by pankaj on 30 May 07

						if ((IsDBNull(mobjTmpDt.Rows.Item(intCount).Item("TrainingGiven")))) {
							objDataRow.Item(ConstTrainingGiven) = (string)"";
						} else {
							objDataRow.Item(ConstTrainingGiven) = gfuncWordWrap((string)mobjTmpDt.Rows.Item(intCount).Item("TrainingGiven"), 32);
							//29.6.2010 by dinesh wagh
						}

						if ((IsDBNull(mobjTmpDt.Rows.Item(intCount).Item("TrainingComments")))) {
							objDataRow.Item(ConstTrainingComments) = (string)"";
						} else {
							//objDataRow.Item(ConstTrainingComments) = CStr(mobjTmpDt.Rows.Item(intCount).Item("TrainingComments")) '2.4.2010 by dinesh wagh
							objDataRow.Item(ConstTrainingComments) = gfuncWordWrap((string)mobjTmpDt.Rows.Item(intCount).Item("TrainingComments"), 28);
							//2.4.2010 by dinesh wagh
						}


						objDataRow.Item(ConstTrainingID) = (int)mobjTmpDt.Rows.Item(intCount).Item("TrainingID");
						mObjDataTable.Rows.Add(objDataRow);

					}
				}
			}

			if (IsNothing(mObjDataTable) == true) {
				throw new Exception("Error in Getting Equipment List Records.");
			} else {
				subFormatUserTrainingDataGrid();
			}

			mobjTmpDt = new DataTable();
			mobjTmpDt = gobjDataAccess.funcGetOQUserRecords();

			if (!mobjTmpDt == null) {
				if (!mobjTmpDt.Rows.Count == 0) {

					for (intCount = 0; intCount <= mobjTmpDt.Rows.Count - 1; intCount++) {
						objDataRow = mobjCADataTable.NewRow;
						objDataRow.Item(ConstSrNo) = intCount + 1;
						// by Pankaj on 6 Dec 07'CInt(mobjTmpDt.Rows.Item(intCount).Item("UserID"))
						objDataRow.Item(ConstUserName) = (string)mobjTmpDt.Rows.Item(intCount).Item("UserName");
						objDataRow.Item(ConstUserDate) = (string)mobjTmpDt.Rows.Item(intCount).Item("UserDate");
						objDataRow.Item(ConstUserID) = (int)mobjTmpDt.Rows.Item(intCount).Item("UserID");
						mobjCADataTable.Rows.Add(objDataRow);

					}
				}
			}

			if (IsNothing(mobjCADataTable) == true) {
				throw new Exception("Error in Getting Equipment List Records.");
			} else {
				subFormatUserDataGrid();
			}

			//If funcGetOQUserRecords() Then
			//    subFormatUserDataGrid()
			//Else
			//    Throw New Exception("Error in Getting User Records.")
			//End If

			mblnModeLockStatus = gobjDataAccess.funcCheckModeLocked(ENUM_IQOQPQ_STATUS.OQ);
			if ((mblnModeLockStatus)) {
				dgTraining.ReadOnly = true;
				dgUser.ReadOnly = true;
			} else {
				dgTraining.ReadOnly = false;
				dgUser.ReadOnly = false;
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

	#Region "User Training Functions"

	private void subCreateUserTrainingDataTable()
	{
		//=====================================================================
		// Procedure Name        :   subCreateUserTrainingDataTable
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

		try {
			objDataColumn = new DataColumn("SrNo", typeof(int));
			objDataColumn.ReadOnly = true;
			objDataColumn.AutoIncrement = false;
			mObjDataTable.Columns.Add(objDataColumn);

			mObjDataTable.Columns.Add(new DataColumn("TrainingType", typeof(string)));
			mObjDataTable.Columns.Add(new DataColumn("TrainingGiven", typeof(string)));
			mObjDataTable.Columns.Add(new DataColumn("TrainingComments", typeof(string)));
			mObjDataTable.Columns.Add(new DataColumn("TrainingID", typeof(int)));

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = "Error in Creating User Training Data-Table.";
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

	//Private Function funcGetPQTest2Records() As Boolean
	//    '=====================================================================
	//    ' Procedure Name        :   funcGetPQTest2Records
	//    ' Description           :   To Get PQ Test Records from Database and display them.
	//    ' Purpose               :   To Get PQ Test Records from Database and display them.
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
	//    Dim str_sql As String
	//    Dim reader_status, record_exists As Boolean
	//    Dim testID, temp_cnt As Integer
	//    Dim strTraingType, strTrainingGiven, strComments As String

	//    Try
	//        For temp_cnt = 1 To 6
	//            testID = temp_cnt

	//            str_sql = "Select * from OQUserTraining where TrainingID = " & testID & ""
	//            'record_exists = mclsDBFunctions.RecordExists(str_sql, mobjOleDBconnection)
	//            If record_exists Then
	//                If Not (funcGetOQUserTrainingRecords(testID)) Then
	//                    Throw New Exception("Error in Getting Test Details.")
	//                End If
	//            Else
	//                strTraingType = funcGetTrainingType(testID)
	//                strTrainingGiven = ""
	//                strComments = ""
	//                If funcInsertOQUserTrainingData(testID, strTraingType, strTrainingGiven, strComments) Then
	//                    If Not (funcGetOQUserTrainingRecords(testID)) Then
	//                        Throw New Exception("Error in Getting Test Details.")
	//                    End If
	//                Else
	//                    Throw New Exception("Error in Saving Test Details.")
	//                End If
	//            End If
	//        Next
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

	//Private Function funcGetOQUserTrainingRecords(ByVal inttestId As Integer) As Boolean
	//    '=====================================================================
	//    ' Procedure Name        :   funcGetOQUserTrainingRecords
	//    ' Description           :   To Get OQ User Training Records from Database into DataTable.
	//    ' Purpose               :   To Get OQ User Training Records from Database into DataTable.
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
	//    Dim sql_string, str_date As String
	//    Dim reader_status As Boolean
	//    Dim rec_cnt As Integer
	//    Dim dt_Corrective As Date

	//    Try
	//        sql_string = " Select TrainingType ,TrainingGiven , TrainingComments " & _
	//                     " from OQUserTraining where TrainingID = " & inttestId & " "

	//        'reader_status = mclsDBFunctions.GetRecords(sql_string, mobjOleDBconnection, objReader)

	//        If Not (reader_status) Then
	//            Throw New Exception("Error in Opening Connection during Getting User Training Details.")
	//        End If

	//        rec_cnt = 1
	//        While objReader.Read
	//            objDataRow = mObjDataTable.NewRow()

	//            objDataRow("SrNo") = inttestId
	//            objDataRow("TrainingType") = CStr(objReader.Item("TrainingType"))
	//            If IsDBNull(objReader.Item("TrainingGiven")) = False Then
	//                objDataRow("TrainingGiven") = CStr(objReader.Item("TrainingGiven"))
	//            Else
	//                objDataRow("TrainingGiven") = ""
	//            End If
	//            If IsDBNull(objReader.Item("TrainingComments")) = False Then
	//                objDataRow("TrainingComments") = CStr(objReader.Item("TrainingComments"))
	//            Else
	//                objDataRow("TrainingComments") = ""
	//            End If
	//            objDataRow("TrainingID") = inttestId

	//            mObjDataTable.Rows.Add(objDataRow)
	//            rec_cnt = rec_cnt + 1
	//        End While
	//        objReader.Close()

	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        'Error logging
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = "Error in Getting User Training Records."
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

	private void subFormatUserTrainingDataGrid()
	{
		DataGridTextBoxColumn objTextColumn;
		DataView objDataView = new DataView();

		try {
			dgTraining.TableStyles.Clear();
			objDataView.Table = mObjDataTable;
			objDataView.AllowNew = false;
			dgTraining.DataSource = objDataView;

			mobjGridTableStyle.PreferredRowHeight = 34;
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

			mobjGridTableStyle.MappingName = "OQUserTraining";

			objTextColumn = new DataGridTextBoxColumn();

			objTextColumn.MappingName = "SrNo";
			objTextColumn.HeaderText = "Sr.No.";
			objTextColumn.Width = 50;
			//40 by dinesh wagh 2.4.2010
			objTextColumn.ReadOnly = true;
			objTextColumn.NullText = "";
			objTextColumn.Alignment = HorizontalAlignment.Center;

			mobjGridTableStyle.GridColumnStyles.Add(objTextColumn);

			objTextColumn = new DataGridTextBoxColumn();
			objTextColumn.MappingName = "TrainingType";
			objTextColumn.HeaderText = "Type of Training";
			objTextColumn.Width = 250;
			//210
			objTextColumn.ReadOnly = true;
			objTextColumn.NullText = "";
			mobjGridTableStyle.GridColumnStyles.Add(objTextColumn);

			objTextColumn = new DataGridTextBoxColumn();
			objTextColumn.MappingName = "TrainingGiven";
			objTextColumn.HeaderText = "Check";
			objTextColumn.Width = 175;
			objTextColumn.ReadOnly = false;
			objTextColumn.NullText = "";
			//objTextColumn.Alignment = HorizontalAlignment.Center '29.6.2010 by dinesh wagh

			mobjGridTableStyle.GridColumnStyles.Add(objTextColumn);

			objTextColumn = new DataGridTextBoxColumn();
			objTextColumn.MappingName = "TrainingComments";
			objTextColumn.HeaderText = "Training Comments";
			objTextColumn.Width = 160;
			//155 '2.4.2010 by dinesh wagh
			objTextColumn.ReadOnly = false;
			objTextColumn.NullText = "";
			//objTextColumn.Alignment = HorizontalAlignment.Center '29.6.2010 by dinesh wagh

			mobjGridTableStyle.GridColumnStyles.Add(objTextColumn);
			objTextColumn = new DataGridTextBoxColumn();
			objTextColumn.MappingName = "TrainingID";
			objTextColumn.HeaderText = "TrainingID";
			objTextColumn.Width = 0;
			objTextColumn.ReadOnly = true;
			objTextColumn.NullText = "";

			mobjGridTableStyle.GridColumnStyles.Add(objTextColumn);

			mobjGridTableStyle.GridLineColor = Color.Black;
			dgTraining.TableStyles.Add(mobjGridTableStyle);

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = "Error in Formating User Training Data-Grid.";
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

	public bool funcSaveOQUserTrainingData()
	{
		//=====================================================================
		// Procedure Name        :   funcSaveOQUserTrainingData
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
		int intUserTrainingID;
		int temp_cnt;
		string strTrainingType;
		string strTrainingGiven;
		string strTrainingComments;
		bool status = true;

		try {
			intRecordCount = mObjDataTable.Rows.Count;

			for (temp_cnt = 0; temp_cnt <= (intRecordCount - 1); temp_cnt++) {
				//--- To Check if Training ID is Null.
				//If IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("TrainingID").Ordinal)) Then
				//    strTrainingType = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("TrainingType").Ordinal)
				//    strTrainingGiven = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("TrainingGiven").Ordinal)
				//    strTrainingComments = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("TrainingComments").Ordinal)

				//    status = funcInsertOQUserTrainingData(temp_cnt + 1, strTrainingType, strTrainingGiven, strTrainingComments)
				//    If Not (status) Then
				//        Throw New Exception("Error in Saving User Training Details.")
				//    End If
				//Else
				intUserTrainingID = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("TrainingID").Ordinal);
				strTrainingType = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("TrainingType").Ordinal);
				strTrainingType = strTrainingType.Replace(vbCrLf, " ");
				//29.6.2010 by dinesh wagh

				if (!(IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("TrainingGiven").Ordinal)))) {
					strTrainingGiven = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("TrainingGiven").Ordinal);
					strTrainingGiven = strTrainingGiven.Replace(vbCrLf, " ");
					//29.6.2010 by dinesh wagh
				} else {
					strTrainingGiven = "";
				}

				if (!(IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("TrainingComments").Ordinal)))) {
					strTrainingComments = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("TrainingComments").Ordinal);
					strTrainingComments = strTrainingComments.Replace(vbCrLf, " ");
					//29.6.2010 by dinesh wagh
				} else {
					strTrainingComments = "";
				}

				status = gobjDataAccess.funcUpdateOQUserTrainingData(strTrainingType, strTrainingGiven, strTrainingComments, intUserTrainingID);
				if (!(status)) {
					throw new Exception("Error in Updating User Training Details.");
				}
				//End If
			}

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = "Error in Saving User Training Details.";
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

	//Private Function funcInsertOQUserTrainingData(ByVal intUserTrainingID As Integer, ByVal strTrainingType As String, ByVal strTrainingGiven As String, ByVal strTrainingComments As String) As Boolean
	//    '=====================================================================
	//    ' Procedure Name        :   funcInsertOQUserTrainingData
	//    ' Description           :   To Add/Insert New User Training Data in Database.
	//    ' Purpose               :   To Add/Insert New User Training Data in Database.
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
	//            Throw New Exception("Error in Opening Connection during Saving User Training Details.")
	//        End If

	//        '--- Generating Next User Training ID. 
	//        'intUserTrainingID = mclsDBFunctions.GetNextID("OQUserTraining", "TrainingID", mobjOleDBconnection)

	//        '---  Query for adding  data to EquipmentList
	//        str_sql = " Insert into OQUserTraining " & _
	//                  " (TrainingID ,TrainingType ,TrainingGiven ,TrainingComments) " & _
	//                  " values(?,?,?,?) "

	//        '--- Providing command object. 
	//        With objCommand
	//            .Connection = mobjOleDBconnection
	//            .CommandType = CommandType.Text
	//            .CommandText = str_sql
	//            .Parameters.Add("TrainingID", OleDbType.Numeric).Value = intUserTrainingID
	//            .Parameters.Add("TrainingType", OleDbType.VarChar, 250).Value = strTrainingType
	//            .Parameters.Add("TrainingGiven", OleDbType.VarChar, 250).Value = strTrainingGiven
	//            .Parameters.Add("TrainingComments", OleDbType.VarChar, 250).Value = strTrainingComments
	//            .ExecuteNonQuery()
	//        End With

	//        objCommand.Dispose()
	//        Status = True

	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        '--- Error logging
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = "Error in Saving User Training Details."
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

	//Private Function funcUpdateOQUserTrainingData(ByVal strTrainingType As String, ByVal strTrainingGiven As String, ByVal strTrainingComments As String, ByVal intUserTrainingID As Integer) As Boolean
	//    '=====================================================================
	//    ' Procedure Name        :   funcUpdateOQUserTrainingData
	//    ' Description           :   To Update User Training Data in Database.
	//    ' Purpose               :   To Update User Training Data in Database.
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
	//            Throw New Exception("Error in Opening Connection during Updating User Training Details.")
	//        End If

	//        '---  Query for adding  data  
	//        str_sql = " Update OQUserTraining " & _
	//                  " Set TrainingType = ? ,TrainingGiven = ? ,TrainingComments = ? " & _
	//                  " where TrainingID = " & intUserTrainingID & " "

	//        '--- Providing command object for EquimentList
	//        With objCommand
	//            .Connection = mobjOleDBconnection
	//            .CommandType = CommandType.Text
	//            .CommandText = str_sql
	//            .Parameters.Add("TrainingType", OleDbType.VarChar, 250).Value = strTrainingType
	//            .Parameters.Add("TrainingGiven", OleDbType.VarChar, 250).Value = strTrainingGiven
	//            .Parameters.Add("TrainingComments", OleDbType.VarChar, 250).Value = strTrainingComments
	//            .ExecuteNonQuery()
	//        End With

	//        objCommand.Dispose()
	//        Status = True

	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        '--- Error logging
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = "Error in Updating User Training Details."
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

	//Private Function funcDeleteOQUserTrainigData(ByVal intUserTrainingID As Integer) As Boolean
	//    '=====================================================================
	//    ' Procedure Name        :   funcDeleteOQUserTrainigData
	//    ' Description           :   To Delete User Training Data from Database.
	//    ' Purpose               :   To Delete User Training Data from Database.
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
	//            Throw New Exception("Error in Opening Connection during Deleting User Training Details.")
	//        End If

	//        '--- Query to Delete from Database
	//        str_sql = " Delete * from OQUserTraining " & _
	//                  " where TrainingID = " & intUserTrainingID & " "

	//        'Status = mclsDBFunctions.AddORDeleteRecord(str_sql, mobjOleDBconnection)
	//        If (Status = False) Then
	//            MessageBox.Show("Problem in Deleting record")
	//        End If

	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        '--- Error logging
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = "Error in Deleting User Training Details."
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

	#Region "User Functions"

	private void subCreateUserDataTable()
	{
		//=====================================================================
		// Procedure Name        :   subCreateUserDataTable
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

		try {
			objDataColumn = new DataColumn("SrNo", typeof(int));
			objDataColumn.ReadOnly = true;
			//objDataColumn.AutoIncrement = True
			//  objDataColumn.AutoIncrementSeed = 1
			//  objDataColumn.AutoIncrementStep = 1
			mobjCADataTable.Columns.Add(objDataColumn);

			mobjCADataTable.Columns.Add(new DataColumn("UserName", typeof(string)));
			mobjCADataTable.Columns.Add(new DataColumn("UserDate", typeof(System.DateTime)));
			mobjCADataTable.Columns.Add(new DataColumn("UserID", typeof(int)));

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = "Error in Creating User Details Data-Table.";
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

	//Private Function funcGetOQUserRecords() As Boolean
	//    '=====================================================================
	//    ' Procedure Name        :   funcGetOQUserRecords
	//    ' Description           :   To Get OQ User Records from Database into DataTable.
	//    ' Purpose               :   To Get OQ User Records from Database into DataTable.
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
	//    Dim rec_cnt As Integer

	//    Try
	//        sql_string = " Select UserID ,UserName ,UserDate " & _
	//                     " from OQUser "

	//        'reader_status = mclsDBFunctions.GetRecords(sql_string, mobjOleDBconnection, objReader)

	//        If Not (reader_status) Then
	//            Throw New Exception("Error in Opening Connection during Getting User Details.")
	//        End If

	//        rec_cnt = 1
	//        While objReader.Read
	//            objDataRow = mobjCADataTable.NewRow()

	//            objDataRow("SrNo") = rec_cnt
	//            objDataRow("UserName") = CStr(objReader.Item("UserName"))
	//            If IsDBNull(objReader.Item("UserDate")) Then
	//            Else
	//                objDataRow("UserDate") = CDate(objReader.Item("UserDate"))
	//            End If
	//            'objDataRow("UserDate") = CDate(objReader.Item("UserDate"))
	//            objDataRow("UserID") = Convert.ToInt32(objReader.Item("UserID"))

	//            mobjCADataTable.Rows.Add(objDataRow)
	//            rec_cnt = rec_cnt + 1
	//        End While
	//        objReader.Close()

	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        'Error logging
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = "Error in Getting User Details Records."
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

	private void subFormatUserDataGrid()
	{
		DataGridTextBoxColumn objTextColumn;

		try {
			dgUser.TableStyles.Clear();
			mobjDataView.Table = mobjCADataTable;
			mobjDataView.AllowNew = true;
			dgUser.DataSource = mobjDataView;
			//dgUser.ReadOnly = False

			mobjCAGridTableStyle.RowHeadersVisible = false;
			mobjCAGridTableStyle.ResetAlternatingBackColor();
			mobjCAGridTableStyle.ResetBackColor();
			mobjCAGridTableStyle.ResetForeColor();
			mobjCAGridTableStyle.ResetGridLineColor();
			mobjCAGridTableStyle.BackColor = Color.AliceBlue;
			mobjCAGridTableStyle.GridLineColor = Color.Black;
			mobjCAGridTableStyle.HeaderBackColor = Color.FromArgb(205, 225, 250);
			mobjCAGridTableStyle.HeaderForeColor = Color.Black;
			mobjCAGridTableStyle.AlternatingBackColor = Color.AliceBlue;
			mobjCAGridTableStyle.AllowSorting = false;

			mobjCAGridTableStyle.MappingName = "OQUser";

			objTextColumn = new DataGridTextBoxColumn();
			objTextColumn.MappingName = "SrNo";
			objTextColumn.HeaderText = "Sr.No.";
			objTextColumn.Width = 50;
			objTextColumn.ReadOnly = true;
			objTextColumn.NullText = "";
			objTextColumn.Alignment = HorizontalAlignment.Center;
			mobjCAGridTableStyle.GridColumnStyles.Add(objTextColumn);

			objTextColumn = new DataGridTextBoxColumn();
			objTextColumn.MappingName = "UserName";
			objTextColumn.HeaderText = "User Name";
			objTextColumn.Width = 410;
			//380 2.4.2010 by dinesh wagh
			objTextColumn.ReadOnly = false;
			objTextColumn.NullText = "";
			mobjCAGridTableStyle.GridColumnStyles.Add(objTextColumn);

			objTextColumn = new DataGridTextBoxColumn();
			objTextColumn.MappingName = "UserDate";
			objTextColumn.HeaderText = "Date";
			objTextColumn.Width = 175;
			//150 2.4.2010 by dinesh wagh
			objTextColumn.ReadOnly = false;
			objTextColumn.Format = "dd-MMM-yyyy";
			objTextColumn.NullText = "";
			objTextColumn.Alignment = HorizontalAlignment.Center;
			mobjCAGridTableStyle.GridColumnStyles.Add(objTextColumn);

			objTextColumn = new DataGridTextBoxColumn();
			objTextColumn.MappingName = "UserID";
			objTextColumn.HeaderText = "UserID";
			objTextColumn.Width = 0;
			objTextColumn.ReadOnly = true;
			objTextColumn.NullText = "";
			mobjCAGridTableStyle.GridColumnStyles.Add(objTextColumn);

			mobjCAGridTableStyle.GridLineColor = Color.Black;
			dgUser.TableStyles.Add(mobjCAGridTableStyle);

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = "Error in Formating User Details Data-Grid.";
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

	public bool funcSaveOQUserData()
	{
		//=====================================================================
		// Procedure Name        :   funcSaveOQUserData
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
		int intUserID;
		int temp_cnt;
		string strUserName;
		System.DateTime dtUserDate;
		bool status = true;

		try {
			intRecordCount = mobjCADataTable.Rows.Count;

			for (temp_cnt = 0; temp_cnt <= (intRecordCount - 1); temp_cnt++) {
				//--- To Check if Completed / Accepted ID is Null.
				if (IsDBNull(mobjCADataTable.Rows(temp_cnt).ItemArray.GetValue(mobjCADataTable.Columns.Item("UserID").Ordinal))) {
					strUserName = mobjCADataTable.Rows(temp_cnt).ItemArray.GetValue(mobjCADataTable.Columns.Item("UserName").Ordinal);
					dtUserDate = (System.DateTime)mobjCADataTable.Rows(temp_cnt).ItemArray.GetValue(mobjCADataTable.Columns.Item("UserDate").Ordinal);
					status = gobjDataAccess.funcInsertOQUserData(strUserName, dtUserDate);
					if (!(status)) {
						throw new Exception("Error in Saving User Details.");
					}

				} else {
					if (IsDBNull(mobjCADataTable.Rows(temp_cnt).ItemArray.GetValue(mobjCADataTable.Columns.Item("UserName").Ordinal)) | IsDBNull(mobjCADataTable.Rows(temp_cnt).ItemArray.GetValue(mobjCADataTable.Columns.Item("UserDate").Ordinal))) {
						intUserID = mobjCADataTable.Rows(temp_cnt).ItemArray.GetValue(mobjCADataTable.Columns.Item("UserID").Ordinal);
						status = gobjDataAccess.funcDeleteOQUserData(intUserID);
						if (!(status)) {
							throw new Exception("Error in Deleting User Details.");
						}


					} else {
						intUserID = mobjCADataTable.Rows(temp_cnt).ItemArray.GetValue(mobjCADataTable.Columns.Item("UserID").Ordinal);
						strUserName = mobjCADataTable.Rows(temp_cnt).ItemArray.GetValue(mobjCADataTable.Columns.Item("UserName").Ordinal);
						dtUserDate = mobjCADataTable.Rows(temp_cnt).ItemArray.GetValue(mobjCADataTable.Columns.Item("UserDate").Ordinal);
						status = gobjDataAccess.funcUpdateOQUserData(strUserName, dtUserDate, intUserID);
						if (!(status)) {
							throw new Exception("Error in Updating User Details.");
						}
					}
				}
			}

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = "Error in Saving User Details.";
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

	//Private Function funcInsertOQUserData(ByVal strUserName As String, ByVal dtUserDate As Date) As Boolean
	//    '=====================================================================
	//    ' Procedure Name        :   funcInsertOQUserData
	//    ' Description           :   To Add/Insert New User Data in Database.
	//    ' Purpose               :   To Add/Insert New User Data in Database.
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
	//    Dim intUserID As Integer

	//    Try
	//        'Status = mclsDBFunctions.OpenConnection(mobjOleDBconnection)
	//        If Not (Status) Then
	//            Throw New Exception("Error in Opening Connection during Saving User Details.")
	//        End If

	//        '--- Generating Next User ID. 
	//        'intUserID = mclsDBFunctions.GetNextID("OQUser", "UserID", mobjOleDBconnection)

	//        '---  Query for adding  data to EquipmentList
	//        str_sql = " Insert into OQUser " & _
	//                  " (UserID ,UserName ,UserDate) " & _
	//                  " values(?,?,?) "

	//        '--- Providing command object. 
	//        With objCommand
	//            .Connection = mobjOleDBconnection
	//            .CommandType = CommandType.Text
	//            .CommandText = str_sql
	//            .Parameters.Add("UserID", OleDbType.Numeric).Value = intUserID
	//            .Parameters.Add("UserName", OleDbType.VarChar, 50).Value = strUserName
	//            .Parameters.Add("UserDate", OleDbType.DBDate).Value = dtUserDate
	//            .ExecuteNonQuery()
	//        End With

	//        objCommand.Dispose()
	//        Status = True

	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        '--- Error logging
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = "Error in Saving User Details."
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

	//Private Function funcUpdateOQUserData(ByVal strUserName As String, ByVal dtUserDate As String, ByVal intUserID As Integer) As Boolean
	//    '=====================================================================
	//    ' Procedure Name        :   funcUpdateOQUserData
	//    ' Description           :   To Update User Data in Database.
	//    ' Purpose               :   To Update User Data in Database.
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
	//            Throw New Exception("Error in Opening Connection during Updating User Details.")
	//        End If

	//        '---  Query for adding  data 
	//        str_sql = " Update OQUser " & _
	//                  " Set UserName = ? ,UserDate = ? " & _
	//                  " where UserID = " & intUserID & " "

	//        '--- Providing command object  
	//        With objCommand
	//            .Connection = mobjOleDBconnection
	//            .CommandType = CommandType.Text
	//            .CommandText = str_sql
	//            .Parameters.Add("UserName", OleDbType.VarChar, 250).Value = strUserName
	//            .Parameters.Add("UserDate", OleDbType.DBDate).Value = dtUserDate
	//            .ExecuteNonQuery()
	//        End With

	//        objCommand.Dispose()
	//        Status = True

	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        '--- Error logging
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = "Error in Updating User Details."
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

	//Private Function funcDeleteOQUserData(ByVal intUserID As Integer) As Boolean
	//    '=====================================================================
	//    ' Procedure Name        :   funcDeleteOQUserData
	//    ' Description           :   To Delete User Data from Database.
	//    ' Purpose               :   To Delete User Data from Database.
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
	//            Throw New Exception("Error in Opening Connection during Deleting User Details.")
	//        End If

	//        '--- Query to Delete from Database
	//        str_sql = " Delete * from OQUser " & _
	//                  " where UserID = " & intUserID & " "

	//        'Status = mclsDBFunctions.AddORDeleteRecord(str_sql, mobjOleDBconnection)
	//        If (Status = False) Then
	//            Throw New Exception("Error in Deleting User Details.")
	//        End If

	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        '--- Error logging
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = "Error in Deleting User Details."
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

	#End Region

	private void  // ERROR: Handles clauses are not supported in C#
dgUser_CurrentCellChanged(object sender, System.EventArgs e)
	{
		try {
			if (!(mblnModeLockStatus)) {
				mobjCADataTable.Columns(0).ReadOnly = false;
				dgUser.Item(dgUser.CurrentRowIndex, 0) = dgUser.CurrentRowIndex + 1;
				mobjCADataTable.Columns(0).ReadOnly = true;
				if ((dgUser.CurrentCell.ColumnNumber == 2)) {
					mdtpUserDate.Top = dgUser.GetCurrentCellBounds().Top;
					mdtpUserDate.Left = dgUser.GetCurrentCellBounds().Left;
					mdtpUserDate.Width = dgUser.GetCurrentCellBounds().Width;
					mdtpUserDate.Height = dgUser.GetCurrentCellBounds().Height;


					if ((dgUser.CurrentCell.RowNumber) > 0) {
						if (IsDBNull(dgUser(dgUser.CurrentCell.RowNumber, 2)) == false) {
							mdtpUserDate.Value = Format((System.DateTime)dgUser(dgUser.CurrentCell.RowNumber, 2), "dd - MMM - yyyy");
						} else {
							mdtpUserDate.Value = Format(DateTime.Today, "dd-MMM-yyyy");
							dgUser(dgUser.CurrentCell.RowNumber, dgUser.CurrentCell.ColumnNumber) = mdtpUserDate.Value;
						}
					} else {
						dgUser(dgUser.CurrentCell.RowNumber, dgUser.CurrentCell.ColumnNumber) = mdtpUserDate.Value;
					}
					mdtpUserDate.Visible = true;
				} else {
					mdtpUserDate.Width = 0;
					mdtpUserDate.Visible = false;
				}
			}
			//user changed to 6. by dinesh wagh Suggested by : V.C.K on 9.7.2010
			if (dgUser.CurrentRowIndex >= 6) {
				mobjDataView.AllowNew = false;
			}

		} catch (Exception ex) {
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = "Error in Formating User Training Data-Grid.";
			gobjErrorHandler.WriteErrorLog(ex);
		} finally {
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
		}
	}
	#Region "Constant Test Data"

	private string funcGetTrainingType(int testNo)
	{
		string strtestName;

		switch (testNo) {
			case 1:
				strtestName = "Instrument Setup";
			case 2:
				strtestName = "Basic operation of Main Menu";
			case 3:
				strtestName = "System operation & condition of operation (parameter setting and operation)";
			case 4:
				strtestName = "Basic trouble shooting and maintenance";
			case 5:
				strtestName = "Controlling system for external accessories(if any)";
			case 6:
				strtestName = "Operational training and demonstration";
			default:
				strtestName = "";
		}

		return strtestName;

	}
	#End Region

	private void  // ERROR: Handles clauses are not supported in C#
dgTraining_CurrentCellChanged(object sender, System.EventArgs e)
	{
		//new sub added by : dinesh wagh on 29.6.2010
		//to wrap the text as soon as user entered the text.
		if (mblnAvoidProcessing == true)
			return;
		int intRowIndex;
		int intColumnIndex;
		string strString;
		try {
			intRowIndex = dgTraining.CurrentCell.RowNumber;
			intColumnIndex = dgTraining.CurrentCell.ColumnNumber;
			mblnAvoidProcessing = true;
			if (!IsDBNull(dgTraining.Item(mintRowIndex, mintColumnIndex))) {
				if (mintColumnIndex == 2 | mintColumnIndex == 3) {
					strString = dgTraining.Item(mintRowIndex, mintColumnIndex);
					if (!(strString == "")) {
						strString = strString.Replace(vbCrLf, " ");
						dgTraining.Item(mintRowIndex, mintColumnIndex) = gfuncWordWrap(strString, 32);
					}
				}
			}
			dgTraining.CurrentCell = new DataGridCell(intRowIndex, intColumnIndex);
			mintRowIndex = dgTraining.CurrentCell.RowNumber;
			mintColumnIndex = dgTraining.CurrentCell.ColumnNumber;
			mblnAvoidProcessing = false;
		} catch (Exception ex) {
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = "Error in Formating User Training Data-Grid.";
			gobjErrorHandler.WriteErrorLog(ex);
		} finally {
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
		}
	}
}
