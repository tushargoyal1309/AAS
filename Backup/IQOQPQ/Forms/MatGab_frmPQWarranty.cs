using System.Data;
using System.Data.OleDb;

public class frmPQWarranty : System.Windows.Forms.Form
{

	#Region " Module level Declarations "
	private bool mblnModeLockStatus;
	private string mstrOledbConnectionString;
	private OleDbConnection mobjOleDBconnection;
	//Public mclsDBFunctions As New clsDatabaseFunctions
	private DataView mobjDataView = new DataView();
	private DataTable mobjCADataTable;
		#End Region
	DataGridTableStyle mobjCAGridTableStyle = new DataGridTableStyle();

	#Region " Windows Form Designer generated code "

	public frmPQWarranty()
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
	internal System.Windows.Forms.DataGrid dgCompletedAccepted;
	internal System.Windows.Forms.Panel Panel2;
	internal System.Windows.Forms.PictureBox PictureBox1;
	internal System.Windows.Forms.Label Label1;
	[System.Diagnostics.DebuggerStepThrough()]
	private void InitializeComponent()
	{
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmPQWarranty));
		this.lblHeader1 = new System.Windows.Forms.Label();
		this.lblHeader2 = new System.Windows.Forms.Label();
		this.lblHeader3 = new System.Windows.Forms.Label();
		this.Panel1 = new System.Windows.Forms.Panel();
		this.Panel2 = new System.Windows.Forms.Panel();
		this.PictureBox1 = new System.Windows.Forms.PictureBox();
		this.dgCompletedAccepted = new System.Windows.Forms.DataGrid();
		this.Label1 = new System.Windows.Forms.Label();
		this.Panel1.SuspendLayout();
		this.Panel2.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.dgCompletedAccepted).BeginInit();
		this.SuspendLayout();
		//
		//lblHeader1
		//
		this.lblHeader1.Font = new System.Drawing.Font("Arial", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblHeader1.ForeColor = System.Drawing.SystemColors.ControlText;
		this.lblHeader1.Location = new System.Drawing.Point(35, 7);
		this.lblHeader1.Name = "lblHeader1";
		this.lblHeader1.Size = new System.Drawing.Size(376, 18);
		this.lblHeader1.TabIndex = 1;
		this.lblHeader1.Text = "F. WARRANTY";
		this.lblHeader1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//lblHeader2
		//
		this.lblHeader2.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblHeader2.Location = new System.Drawing.Point(8, 40);
		this.lblHeader2.Name = "lblHeader2";
		this.lblHeader2.Size = new System.Drawing.Size(511, 40);
		this.lblHeader2.TabIndex = 2;
		this.lblHeader2.Text = "     Instruments supplied carry warranty of 12 months from the date of installati" + "on or 15 months from the date of supply whichever is earlier, against any manufa" + "cturing defects.";
		//
		//lblHeader3
		//
		this.lblHeader3.Location = new System.Drawing.Point(8, 88);
		this.lblHeader3.Name = "lblHeader3";
		this.lblHeader3.Size = new System.Drawing.Size(512, 40);
		this.lblHeader3.TabIndex = 3;
		this.lblHeader3.Text = "This warranty will not be applicable if the purchaser does not make payment, as p" + "er the terms of the contract.";
		//
		//Panel1
		//
		this.Panel1.BackColor = System.Drawing.Color.AliceBlue;
		this.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.Panel1.Controls.Add(this.Label1);
		this.Panel1.Controls.Add(this.Panel2);
		this.Panel1.Controls.Add(this.dgCompletedAccepted);
		this.Panel1.Controls.Add(this.lblHeader2);
		this.Panel1.Controls.Add(this.lblHeader3);
		this.Panel1.Dock = System.Windows.Forms.DockStyle.Top;
		this.Panel1.Location = new System.Drawing.Point(0, 0);
		this.Panel1.Name = "Panel1";
		this.Panel1.Size = new System.Drawing.Size(456, 456);
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
		this.Panel2.Size = new System.Drawing.Size(454, 32);
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
		//dgCompletedAccepted
		//
		this.dgCompletedAccepted.BackgroundColor = System.Drawing.Color.AliceBlue;
		this.dgCompletedAccepted.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.dgCompletedAccepted.CaptionVisible = false;
		this.dgCompletedAccepted.DataMember = "";
		this.dgCompletedAccepted.HeaderForeColor = System.Drawing.SystemColors.ControlText;
		this.dgCompletedAccepted.Location = new System.Drawing.Point(16, 172);
		this.dgCompletedAccepted.Name = "dgCompletedAccepted";
		this.dgCompletedAccepted.ParentRowsVisible = false;
		this.dgCompletedAccepted.ReadOnly = true;
		this.dgCompletedAccepted.RowHeadersVisible = false;
		this.dgCompletedAccepted.Size = new System.Drawing.Size(455, 104);
		this.dgCompletedAccepted.TabIndex = 18;
		//
		//Label1
		//
		this.Label1.Location = new System.Drawing.Point(8, 129);
		this.Label1.Name = "Label1";
		this.Label1.Size = new System.Drawing.Size(512, 30);
		this.Label1.TabIndex = 20;
		this.Label1.Text = "Warranty is not applicable for consumable parts such as D2 , Hallow Cathode Lamp " + "etc.";
		//
		//frmPQWarranty
		//
		this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
		this.AutoScroll = true;
		this.BackColor = System.Drawing.Color.AliceBlue;
		this.ClientSize = new System.Drawing.Size(456, 440);
		this.ControlBox = false;
		this.Controls.Add(this.Panel1);
		this.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		this.MaximizeBox = false;
		this.MinimizeBox = false;
		this.Name = "frmPQWarranty";
		this.Text = "Warranty";
		this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
		this.Panel1.ResumeLayout(false);
		this.Panel2.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.dgCompletedAccepted).EndInit();
		this.ResumeLayout(false);

	}

	#End Region

	#Region "Constants"
	private const string ConstSrNo = "SrNo";
	private const string ConstCompletedBy = "CompletedBy";
	private const string ConstAcceptedBy = "AcceptedBy";

	private const string ConstCompletedAcceptedByID = "CompletedAcceptedByID";
	#End Region

	#Region " Form Events "
	private void  // ERROR: Handles clauses are not supported in C#
frmPQWarranty_Load(object sender, System.EventArgs e)
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
frmPQWarranty_Closing(object sender, System.ComponentModel.CancelEventArgs e)
	{
		try {
			if (!(mblnModeLockStatus)) {
				dgCompletedAccepted.CurrentCell() = (new DataGridCell(dgCompletedAccepted.CurrentRowIndex + 1, 0));
				if (!funcSavePQCompleteAcceptData()) {
					throw new Exception("Error in Saving Completed/Accepted By Data.");
				}
				dgCompletedAccepted.TableStyles.Clear();
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
	//    General functions used for IQ Equipment Listing.
	//--- funcInitialize - To Initialize form and to get values for PQ Completed/Accepted by Data from database and display them.
	//--- subCreateCompleteAcceptDataTable - To Create Columns in the Data Table.
	//--- funcGetPQCompleteAcceptRecords - To Get PQ Completed/Accepted By Records from Database into DataTable.
	//--- subFormatCompleteAcceptDataGrid - To format the Completed/Accepted By Data Grid.
	//--- funcSavePQCompleteAcceptData - To Save the Entered Records into Database.
	//--- funcInsertPQCompleteAcceptData - To Add/Insert New Completed/Accepted By Data in Database.
	//--- funcUpdatePQCompleteAcceptData - To Update Completed/Accepted By Data in Database.
	//--- funcDeletePQCompleteAcceptData - To Delete Completed/Accepted By Action Data from Database.

	private void funcInitialize()
	{
		//=====================================================================
		// Procedure Name        :   funcInitailize
		// Description           :   To Initialize form and to get values for PQ Completed/Accepted by Data from database and display them.
		// Purpose               :   To Initialize form and to get values for PQ Completed/Accepted by Data from database and display them.
		// Parameters Passed     :   None.
		// Returns               :   None.
		// Parameters Affected   :   None.
		// Assumptions           :
		// Dependencies          :
		// Author                :   Gitesh
		// Created               :   January, 2003 
		// Revisions             :
		//=====================================================================
		int intRowCount;
		DataRow objDataRow;
		int intCount = 0;
		DataTable mobjTmpDt = new DataTable();

		try {
			//mfrmWarranty = Me
			mobjCADataTable = new DataTable("CompletedAcceptedBy");

			//--- Initialising Connection String
			//mstrOledbConnectionString = mclsDBFunctions.ConnectionString(CONST_IQOQPQ_DATABASENAME)

			//--- Initialising Connection 
			//mobjOleDBconnection = New OleDbConnection(mstrOledbConnectionString)

			subCreateCompleteAcceptDataTable();

			mobjTmpDt = gobjDataAccess.funcGetPQCompleteAcceptRecords();

			if (!mobjTmpDt == null) {
				if (!mobjTmpDt.Rows.Count == 0) {
					for (intCount = 0; intCount <= mobjTmpDt.Rows.Count - 1; intCount++) {
						objDataRow = mobjCADataTable.NewRow;
						objDataRow.Item(ConstSrNo) = intCount + 1;
						//by Pankaj on 6 Dec 07'CInt(mobjTmpDt.Rows.Item(intCount).Item("CompletedAcceptedByID"))
						objDataRow.Item(ConstCompletedBy) = (string)mobjTmpDt.Rows.Item(intCount).Item("CompletedBy");
						objDataRow.Item(ConstAcceptedBy) = (string)mobjTmpDt.Rows.Item(intCount).Item("AcceptedBy");
						objDataRow.Item(ConstCompletedAcceptedByID) = (int)mobjTmpDt.Rows.Item(intCount).Item("CompletedAcceptedByID");
						mobjCADataTable.Rows.Add(objDataRow);

					}
				}
			}

			if (IsNothing(mobjCADataTable) == true) {
				throw new Exception("Error in Getting Completed/Accepted By Records.");

			} else {
				subFormatCompleteAcceptDataGrid();
			}

			//If funcGetPQCompleteAcceptRecords() Then
			//    subFormatCompleteAcceptDataGrid()
			//Else
			//    Throw New Exception("Error in Getting Completed/Accepted By Records.")
			//End If

			mblnModeLockStatus = gobjDataAccess.funcCheckModeLocked(ENUM_IQOQPQ_STATUS.PQ);
			if ((mblnModeLockStatus)) {
				dgCompletedAccepted.ReadOnly = true;
			} else {
				dgCompletedAccepted.ReadOnly = false;
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

	#Region "Completed/Accepted By Functions"

	private void subCreateCompleteAcceptDataTable()
	{
		//=====================================================================
		// Procedure Name        :   subCreateCompleteAcceptDataTable
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
			mobjCADataTable.Columns.Add(objDataColumn);

			mobjCADataTable.Columns.Add(new DataColumn("CompletedBy", typeof(string)));
			mobjCADataTable.Columns.Add(new DataColumn("AcceptedBy", typeof(string)));
			mobjCADataTable.Columns.Add(new DataColumn("CompletedAcceptedByID", typeof(int)));

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = "Error in Creating Completed/Accepted By Data-Table.";
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

	//Private Function funcGetPQCompleteAcceptRecords() As Boolean
	//    '=====================================================================
	//    ' Procedure Name        :   funcGetPQCompleteAcceptRecords
	//    ' Description           :   To Get PQ Completed/Accepted By Records from Database into DataTable.
	//    ' Purpose               :   To Get PQ Completed/Accepted By Records from Database into DataTable.
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
	//        sql_string = " Select CompletedAcceptedByID ,CompletedBy ,AcceptedBy " & _
	//                     " from CompletedAcceptedBY where CheckStatusIQOQPQ = " & ENUM_IQOQPQ_STATUS.PQ & ""

	//        reader_status = mclsDBFunctions.GetRecords(sql_string, mobjOleDBconnection, objReader)

	//        If Not (reader_status) Then
	//            Return False
	//        End If

	//        rec_cnt = 1
	//        While objReader.Read
	//            objDataRow = mobjCADataTable.NewRow()

	//            objDataRow("SrNo") = rec_cnt
	//            objDataRow("CompletedBy") = CStr(objReader.Item("CompletedBy"))
	//            objDataRow("AcceptedBy") = CStr(objReader.Item("AcceptedBy"))
	//            objDataRow("CompletedAcceptedByID") = Convert.ToInt32(objReader.Item("CompletedAcceptedByID"))

	//            mobjCADataTable.Rows.Add(objDataRow)
	//            rec_cnt = rec_cnt + 1
	//        End While
	//        objReader.Close()

	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        'Error logging
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = "Error in Getting Completed/Accepted By Records."
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

	private void subFormatCompleteAcceptDataGrid()
	{
		DataGridTextBoxColumn objTextColumn;

		try {
			dgCompletedAccepted.TableStyles.Clear();
			mobjDataView.Table = mobjCADataTable;
			mobjDataView.AllowNew = true;
			dgCompletedAccepted.DataSource = mobjDataView;
			//dgCompletedAccepted.ReadOnly = False

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

			mobjCAGridTableStyle.MappingName = "CompletedAcceptedBy";

			objTextColumn = new DataGridTextBoxColumn();
			objTextColumn.MappingName = "SrNo";
			objTextColumn.HeaderText = "Sr.No.";
			objTextColumn.Width = 50;
			objTextColumn.ReadOnly = true;
			objTextColumn.NullText = "";
			objTextColumn.Alignment = HorizontalAlignment.Center;
			mobjCAGridTableStyle.GridColumnStyles.Add(objTextColumn);

			objTextColumn = new DataGridTextBoxColumn();
			objTextColumn.MappingName = "CompletedBy";
			objTextColumn.HeaderText = "Completed By";
			objTextColumn.Width = 200;
			objTextColumn.ReadOnly = false;
			objTextColumn.NullText = "";
			objTextColumn.Alignment = HorizontalAlignment.Center;
			mobjCAGridTableStyle.GridColumnStyles.Add(objTextColumn);

			objTextColumn = new DataGridTextBoxColumn();
			objTextColumn.MappingName = "AcceptedBy";
			objTextColumn.HeaderText = "Accepted By";
			objTextColumn.Width = 200;
			objTextColumn.ReadOnly = false;
			objTextColumn.NullText = "";
			objTextColumn.Alignment = HorizontalAlignment.Center;
			mobjCAGridTableStyle.GridColumnStyles.Add(objTextColumn);

			objTextColumn = new DataGridTextBoxColumn();
			objTextColumn.MappingName = "CompletedAcceptedByID";
			objTextColumn.HeaderText = "CompletedAcceptedByID";
			objTextColumn.Width = 0;
			objTextColumn.ReadOnly = true;
			objTextColumn.NullText = "";
			mobjCAGridTableStyle.GridColumnStyles.Add(objTextColumn);

			mobjCAGridTableStyle.GridLineColor = Color.Black;
			dgCompletedAccepted.TableStyles.Add(mobjCAGridTableStyle);

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = "Error in Formating Completed/Accepted By Data-Grid.";
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

	public bool funcSavePQCompleteAcceptData()
	{
		//=====================================================================
		// Procedure Name        :   funcSavePQCompleteAcceptData
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
		int intCompleteAcceptID;
		int temp_cnt;
		string strCompletedBy;
		string strAcceptedBy;
		bool status = true;

		try {
			intRecordCount = mobjCADataTable.Rows.Count;

			for (temp_cnt = 0; temp_cnt <= (intRecordCount - 1); temp_cnt++) {
				//--- To Check if Completed / Accepted ID is Null.
				if (IsDBNull(mobjCADataTable.Rows(temp_cnt).ItemArray.GetValue(mobjCADataTable.Columns.Item("CompletedAcceptedByID").Ordinal))) {
					if (IsDBNull(mobjCADataTable.Rows(temp_cnt).ItemArray.GetValue(mobjCADataTable.Columns.Item("CompletedBy").Ordinal)) == false) {
						strCompletedBy = mobjCADataTable.Rows(temp_cnt).ItemArray.GetValue(mobjCADataTable.Columns.Item("CompletedBy").Ordinal);
					}
					if (IsDBNull(mobjCADataTable.Rows(temp_cnt).ItemArray.GetValue(mobjCADataTable.Columns.Item("AcceptedBy").Ordinal)) == false) {
						strAcceptedBy = mobjCADataTable.Rows(temp_cnt).ItemArray.GetValue(mobjCADataTable.Columns.Item("AcceptedBy").Ordinal);
					}
					if ((strCompletedBy == "" & strAcceptedBy == "")) {
					} else {
						status = gobjDataAccess.funcInsertPQCompleteAcceptData(strCompletedBy, strAcceptedBy);
						if (!(status)) {
							throw new Exception("Error in Saving Completed/Accepted By Details.");
						}
					}
				} else {
					intCompleteAcceptID = mobjCADataTable.Rows(temp_cnt).ItemArray.GetValue(mobjCADataTable.Columns.Item("CompletedAcceptedByID").Ordinal);
					if (IsDBNull(mobjCADataTable.Rows(temp_cnt).ItemArray.GetValue(mobjCADataTable.Columns.Item("CompletedBy").Ordinal)) == false) {
						strCompletedBy = mobjCADataTable.Rows(temp_cnt).ItemArray.GetValue(mobjCADataTable.Columns.Item("CompletedBy").Ordinal);
					}
					if (IsDBNull(mobjCADataTable.Rows(temp_cnt).ItemArray.GetValue(mobjCADataTable.Columns.Item("AcceptedBy").Ordinal)) == false) {
						strAcceptedBy = mobjCADataTable.Rows(temp_cnt).ItemArray.GetValue(mobjCADataTable.Columns.Item("AcceptedBy").Ordinal);
					}
					status = gobjDataAccess.funcUpdatePQCompleteAcceptData(strCompletedBy, strAcceptedBy, intCompleteAcceptID);
					if (!(status)) {
						throw new Exception("Error in Updating Completed/Accepted By Details.");
					}
				}
			}
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = "Error in Saving Completed/Accepted By Details.";
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

	//Private Function funcInsertPQCompleteAcceptData(ByVal strCompletedBy As String, ByVal strAcceptedBy As String) As Boolean
	//    '=====================================================================
	//    ' Procedure Name        :   funcInsertPQCompleteAcceptData
	//    ' Description           :   To Add/Insert New Completed/Accepted By Data in Database.
	//    ' Purpose               :   To Add/Insert New Completed/Accepted By Data in Database.
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
	//    Dim intCompleteAcceptID As Integer

	//    Try
	//        Status = mclsDBFunctions.OpenConnection(mobjOleDBconnection)
	//        If Not (Status) Then
	//            Throw New Exception("Error in Opening Connection during Saving Test Details.")
	//        End If

	//        '--- Generating Next Equipment ID. 
	//        intCompleteAcceptID = mclsDBFunctions.GetNextID("CompletedAcceptedBY", "CompletedAcceptedByID", mobjOleDBconnection)

	//        '---  Query for adding  data to EquipmentList
	//        str_sql = " Insert into CompletedAcceptedBY " & _
	//                  " (CompletedAcceptedByID ,CompletedBy ,AcceptedBy ,CheckStatusIQOQPQ) " & _
	//                  " values(?,?,?,?) "

	//        '--- Providing command object. 
	//        With objCommand
	//            .Connection = mobjOleDBconnection
	//            .CommandType = CommandType.Text
	//            .CommandText = str_sql
	//            .Parameters.Add("CompletedAcceptedByID", OleDbType.Numeric).Value = intCompleteAcceptID
	//            .Parameters.Add("CompletedBy", OleDbType.VarChar, 50).Value = strCompletedBy
	//            .Parameters.Add("AcceptedBy", OleDbType.VarChar, 50).Value = strAcceptedBy
	//            .Parameters.Add("CheckStatusIQOQPQ", OleDbType.Single).Value = CSng(ENUM_IQOQPQ_STATUS.PQ)
	//            .ExecuteNonQuery()
	//        End With

	//        objCommand.Dispose()
	//        Status = True

	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        '--- Error logging
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = "Error in Saving Completed/Accepted By Details."
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

	//Private Function funcUpdatePQCompleteAcceptData(ByVal strCompletedBy As String, ByVal strAcceptedBy As String, ByVal intCompleteAcceptID As Integer) As Boolean
	//    '=====================================================================
	//    ' Procedure Name        :   funcUpdatePQCompleteAcceptData
	//    ' Description           :   To Update Completed/Accepted By Data in Database.
	//    ' Purpose               :   To Update Completed/Accepted By Data in Database.
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
	//        Status = mclsDBFunctions.OpenConnection(mobjOleDBconnection)
	//        If Not (Status) Then
	//            Throw New Exception("Error in Opening Connection during Updating Test Details.")
	//        End If

	//        '---  Query for adding  data 
	//        str_sql = " Update CompletedAcceptedBY " & _
	//                  " Set CompletedBy = ? ,AcceptedBy = ? " & _
	//                  " where CompletedAcceptedByID = " & intCompleteAcceptID & " and CheckStatusIQOQPQ = " & ENUM_IQOQPQ_STATUS.PQ & "  "

	//        '--- Providing command object  
	//        With objCommand
	//            .Connection = mobjOleDBconnection
	//            .CommandType = CommandType.Text
	//            .CommandText = str_sql
	//            .Parameters.Add("CompletedBy", OleDbType.VarChar, 250).Value = strCompletedBy
	//            .Parameters.Add("AcceptedBy", OleDbType.VarChar, 250).Value = strAcceptedBy
	//            .ExecuteNonQuery()
	//        End With

	//        objCommand.Dispose()
	//        Status = True

	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        '--- Error logging
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = "Error in Updating Completed/Accepted By Details."
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

	//Private Function funcDeletePQCompleteAcceptData(ByVal intCompleteAcceptID As Integer) As Boolean
	//    '=====================================================================
	//    ' Procedure Name        :   funcDeletePQCompleteAcceptData
	//    ' Description           :   To Delete Completed/Accepted By Data from Database.
	//    ' Purpose               :   To Delete Completed/Accepted By Data from Database.
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
	//            Throw New Exception("Error in Opening Connection during Deleting Completed/Accepted By Details.")
	//        End If

	//        '--- Query to Delete from Database
	//        str_sql = " Delete * from CompletedAcceptedBY " & _
	//                  " where CompletedAcceptedByID = " & intCompleteAcceptID & " and CheckStatusIQOQPQ = " & ENUM_IQOQPQ_STATUS.PQ & " "

	//        Status = mclsDBFunctions.AddORDeleteRecord(str_sql, mobjOleDBconnection)
	//        If (Status = False) Then
	//            Throw New Exception("Error in Deleting Completed/Accepted By Details.")
	//        End If

	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        '--- Error logging
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = "Error in Deleting Completed/Accepted By Details."
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
dgCompletedAccepted_CurrentCellChanged(object sender, System.EventArgs e)
	{
		mobjCADataTable.Columns(0).ReadOnly = false;
		if (mobjCADataTable.Rows.Count == 0) {
			mobjCADataTable.Columns(0).DefaultValue = 1;
		} else {
			dgCompletedAccepted.Item(dgCompletedAccepted.CurrentRowIndex, 0) = dgCompletedAccepted.CurrentRowIndex + 1;
		}

		mobjCADataTable.Columns(0).ReadOnly = true;
		if (dgCompletedAccepted.CurrentRowIndex >= 2) {
			mobjDataView.AllowNew = false;
		}
	}

}
