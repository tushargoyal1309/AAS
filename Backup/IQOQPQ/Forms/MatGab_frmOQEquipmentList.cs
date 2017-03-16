
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms.DataGridColumnStyle;
using ErrorHandler.ErrorHandler;

public class frmOQEquipmentList : System.Windows.Forms.Form
{

	#Region " Module level Declarations "
	private bool mblnModeLockStatus;
	int mintMode;
	private string mstrOledbConnectionString;
	private OleDbConnection mobjOleDBconnection;
	//Public mclsDBFunctions As New clsDatabaseFunctions
	private DataView mobjDataView = new DataView();
	private DataTable mObjDataTable;
		#End Region
	DataGridTableStyle mobjGridTableStyle = new DataGridTableStyle();

	#Region " Windows Form Designer generated code "

	public frmOQEquipmentList()
	{
		base.New();

		//This call is required by the Windows Form Designer.
		InitializeComponent();

		//Add any initialization after the InitializeComponent() call

	}

	public frmOQEquipmentList(int intMode)
	{
		base.New();

		//This call is required by the Windows Form Designer.
		InitializeComponent();

		//Add any initialization after the InitializeComponent() call
		mintMode = intMode;
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
	internal System.Windows.Forms.DataGrid dgEquipmentList;
	internal System.Windows.Forms.Label lblHeader;
	internal System.Windows.Forms.Panel Panel2;
	internal System.Windows.Forms.PictureBox PictureBox1;
	[System.Diagnostics.DebuggerStepThrough()]
	private void InitializeComponent()
	{
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmOQEquipmentList));
		this.Panel1 = new System.Windows.Forms.Panel();
		this.lblHeader = new System.Windows.Forms.Label();
		this.Panel2 = new System.Windows.Forms.Panel();
		this.PictureBox1 = new System.Windows.Forms.PictureBox();
		this.dgEquipmentList = new System.Windows.Forms.DataGrid();
		this.Panel1.SuspendLayout();
		this.Panel2.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.dgEquipmentList).BeginInit();
		this.SuspendLayout();
		//
		//Panel1
		//
		this.Panel1.BackColor = System.Drawing.Color.AliceBlue;
		this.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.Panel1.Controls.Add(this.lblHeader);
		this.Panel1.Controls.Add(this.Panel2);
		this.Panel1.Controls.Add(this.dgEquipmentList);
		this.Panel1.Dock = System.Windows.Forms.DockStyle.Top;
		this.Panel1.Location = new System.Drawing.Point(0, 0);
		this.Panel1.Name = "Panel1";
		this.Panel1.Size = new System.Drawing.Size(488, 456);
		this.Panel1.TabIndex = 12;
		//
		//lblHeader
		//
		this.lblHeader.BackColor = System.Drawing.Color.AliceBlue;
		this.lblHeader.Font = new System.Drawing.Font("Arial", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblHeader.Location = new System.Drawing.Point(35, 7);
		this.lblHeader.Name = "lblHeader";
		this.lblHeader.Size = new System.Drawing.Size(500, 18);
		this.lblHeader.TabIndex = 19;
		this.lblHeader.Text = "A.  Equipment Listing";
		this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//Panel2
		//
		this.Panel2.BackColor = System.Drawing.Color.AliceBlue;
		this.Panel2.Controls.Add(this.PictureBox1);
		this.Panel2.Dock = System.Windows.Forms.DockStyle.Top;
		this.Panel2.Location = new System.Drawing.Point(0, 0);
		this.Panel2.Name = "Panel2";
		this.Panel2.Size = new System.Drawing.Size(486, 32);
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
		//dgEquipmentList
		//
		this.dgEquipmentList.BackgroundColor = System.Drawing.Color.AliceBlue;
		this.dgEquipmentList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.dgEquipmentList.CaptionVisible = false;
		this.dgEquipmentList.DataMember = "";
		this.dgEquipmentList.HeaderForeColor = System.Drawing.SystemColors.ControlText;
		this.dgEquipmentList.Location = new System.Drawing.Point(8, 48);
		this.dgEquipmentList.Name = "dgEquipmentList";
		this.dgEquipmentList.ParentRowsVisible = false;
		this.dgEquipmentList.ReadOnly = true;
		this.dgEquipmentList.RowHeadersVisible = false;
		this.dgEquipmentList.Size = new System.Drawing.Size(576, 224);
		this.dgEquipmentList.TabIndex = 18;
		//
		//frmOQEquipmentList
		//
		this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
		this.AutoScroll = true;
		this.BackColor = System.Drawing.Color.AliceBlue;
		this.ClientSize = new System.Drawing.Size(488, 424);
		this.ControlBox = false;
		this.Controls.Add(this.Panel1);
		this.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		this.MaximizeBox = false;
		this.MinimizeBox = false;
		this.Name = "frmOQEquipmentList";
		this.Text = "Equipment Listing";
		this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
		this.Panel1.ResumeLayout(false);
		this.Panel2.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.dgEquipmentList).EndInit();
		this.ResumeLayout(false);

	}

	#End Region

	#Region "Constants"
	private const string ConstSrNo = "SrNo";
	private const string ConstEquipmentName = "EquipmentName";
	private const string ConstSerialNumber = "SerialNumber";
	private const string ConstEquipmentID = "EquipmentID";
	private const string ConstCheckedBy = "CheckedBy";

	private const string ConstVerifiedBy = "VerifiedBy";
	#End Region

	#Region " Form Events "

	private void  // ERROR: Handles clauses are not supported in C#
frmOQEquipmentList_Load(object sender, System.EventArgs e)
	{
		try {
			if ((mintMode == ENUM_IQOQPQ_STATUS.OQ)) {
				//mfrmOQEquipmentList = Me
				subAssignTextForOQ();
			} else if ((mintMode == ENUM_IQOQPQ_STATUS.PQ)) {
				//mfrmPQEquipmentList = Me
				subAssignTextForPQ();
			}

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
frmOQEquipmentList_Closing(object sender, System.ComponentModel.CancelEventArgs e)
	{
		try {
			if (!(mblnModeLockStatus)) {
				dgEquipmentList.CurrentCell() = (new DataGridCell(dgEquipmentList.CurrentRowIndex + 1, 0));
				if (!funcSaveEquipmentListData()) {
					throw new Exception("Error in Saving Equipment List Data.");
				}
				dgEquipmentList.TableStyles.Clear();
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

	private void  // ERROR: Handles clauses are not supported in C#
dgEquipmentList_CurrentCellChanged(object sender, System.EventArgs e)
	{
		mObjDataTable.Columns(0).ReadOnly = false;
		if (mObjDataTable.Rows.Count == 0) {
			mObjDataTable.Columns(0).DefaultValue = 1;
		} else {
			dgEquipmentList.Item(dgEquipmentList.CurrentRowIndex, 0) = dgEquipmentList.CurrentRowIndex + 1;
		}

		mObjDataTable.Columns(0).ReadOnly = true;
		if (dgEquipmentList.CurrentRowIndex >= 10) {
			mobjDataView.AllowNew = false;
		}
	}

	#End Region

	#Region "Text for OQ/PQ Headers"
	private void subAssignTextForOQ()
	{
		lblHeader.Text = "D.I  Equipment Listing";
	}
	private void subAssignTextForPQ()
	{
		lblHeader.Text = "E.I  Equipment Listing";
	}
	#End Region

	#Region " General Private functions "

	//--------------------------------------------------------
	//    General functions used for OQ / PQ Equipment Listing.
	//--- funcInitialize - To Initialize form and to get values for OQ / PQ Equipment List from database and display them.
	//--- subCreateDataTable - To Create Columns in the Data Table.
	//--- funcGetEquipmentListRecords - To Get OQ/PQ Equipment List Records from Database into DataTable.
	//--- subFormatDataGrid - To format the Data Grid.
	//--- funcSaveEquipmentListData - To Save the Entered Records into Database.
	//--- funcInsertEquipmentListData - To Add/Insert New Equipment List Data in Database.
	//--- funcUpdateEquipmentListData - To Update Equipment List Data in Database.
	//--- funcDeleteEquipmentListData - To Delete Equipment List Data from Database.

	private void funcInitialize()
	{
		//=====================================================================
		// Procedure Name        :   funcInitailize
		// Description           :   To Initialize form and to get values for OQ/PQ Equipment List from database and display them.
		// Purpose               :   To Initialize form and to get values for OQ/PQ Equipment List from database and display them.
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
			mObjDataTable = new DataTable("EquipmentList");

			subCreateDataTable();

			//code added by ; dinesh wagh on 15.2.2010
			//--------------------------------------
			mintMode = 1;
			//---------------------------------------


			mobjTmpDt = gobjDataAccess.funcGetOQEquipmentListRecords(mintMode);

			if (!mobjTmpDt == null) {
				if (!mobjTmpDt.Rows.Count == 0) {
					for (intCount = 0; intCount <= mobjTmpDt.Rows.Count - 1; intCount++) {
						objDataRow = mObjDataTable.NewRow;
						objDataRow.Item(ConstSrNo) = intCount + 1;
						//by pankaj on 6 Dec 07'CInt(mobjTmpDt.Rows.Item(intCount).Item("EquipmentListID"))
						objDataRow.Item(ConstEquipmentName) = gfuncWordWrap((string)mobjTmpDt.Rows.Item(intCount).Item("Name"), 20);
						//29.6.2010 by dinesh wagh to word wrap the text.
						objDataRow.Item(ConstSerialNumber) = gfuncWordWrap((string)mobjTmpDt.Rows.Item(intCount).Item("SerialNo"), 20);
						//29.6.2010 by dinesh wagh to word wrap the text.
						objDataRow.Item(ConstCheckedBy) = gfuncWordWrap((string)mobjTmpDt.Rows.Item(intCount).Item("CheckedBy"), 20);
						//29.6.2010 by dinesh wagh to word wrap the text.
						objDataRow.Item(ConstVerifiedBy) = gfuncWordWrap((string)mobjTmpDt.Rows.Item(intCount).Item("VerifiedBy"), 20);
						//29.6.2010 by dinesh wagh to word wrap the text.
						objDataRow.Item(ConstEquipmentID) = (int)mobjTmpDt.Rows.Item(intCount).Item("EquipmentListID");
						mObjDataTable.Rows.Add(objDataRow);
					}
				}
			}

			if (IsNothing(mObjDataTable) == true) {
				throw new Exception("Error in Getting Equipment List Records.");

			} else {
				subFormatDataGrid();
			}

			//If funcGetEquipmentListRecords() Then
			//    subFormatDataGrid()
			//Else
			//    Throw New Exception("Error in Getting Equipment List Records.")
			//End If

			mblnModeLockStatus = gobjDataAccess.funcCheckModeLocked(mintMode);
			if ((mblnModeLockStatus)) {
				dgEquipmentList.ReadOnly = true;
			} else {
				dgEquipmentList.ReadOnly = false;
			}

			dgEquipmentList.ReadOnly = true;
			//code added by ; dinesh wagh on 15.2.2010


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
		DataColumn objDataColumn;

		try {
			objDataColumn = new DataColumn("SrNo", typeof(int));
			objDataColumn.ReadOnly = true;
			// objDataColumn.AutoIncrement = True
			mObjDataTable.Columns.Add(objDataColumn);

			mObjDataTable.Columns.Add(new DataColumn("EquipmentName", typeof(string)));
			mObjDataTable.Columns.Add(new DataColumn("SerialNumber", typeof(string)));
			mObjDataTable.Columns.Add(new DataColumn("CheckedBy", typeof(string)));
			mObjDataTable.Columns.Add(new DataColumn("VerifiedBy", typeof(string)));
			mObjDataTable.Columns.Add(new DataColumn("EquipmentID", typeof(int)));

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = "Error in Creating Equipment List Data-Table.";
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

	//Private Function funcGetEquipmentListRecords() As Boolean
	//    '=====================================================================
	//    ' Procedure Name        :   funcGetEquipmentListRecords
	//    ' Description           :   To Get OQ/PQ Equipment List Records from Database into DataTable.
	//    ' Purpose               :   To Get OQ/PQ Equipment List Records from Database into DataTable.
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
	//        sql_string = "Select EquipmentListID ,Name ,SerialNo ,CheckedBy , VerifiedBy from EquipmentList where CheckStatusIQOQPQ = " & mintMode & " "

	//        'reader_status = mclsDBFunctions.GetRecords(sql_string, mobjOleDBconnection, objReader)

	//        If Not (reader_status) Then
	//            Throw New Exception("Error in Opening Connection during Getting Equipment List Details.")
	//        End If

	//        rec_cnt = 1
	//        While objReader.Read
	//            objDataRow = mObjDataTable.NewRow()

	//            objDataRow("SrNo") = rec_cnt
	//            objDataRow("EquipmentName") = CStr(objReader.Item("Name"))
	//            objDataRow("SerialNumber") = CStr(objReader.Item("SerialNo"))
	//            objDataRow("CheckedBy") = objReader.Item("CheckedBy")
	//            objDataRow("VerifiedBy") = objReader.Item("VerifiedBy")
	//            objDataRow("EquipmentID") = Convert.ToInt32(objReader.Item("EquipmentListID"))

	//            mObjDataTable.Rows.Add(objDataRow)
	//            rec_cnt = rec_cnt + 1
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

		try {
			dgEquipmentList.TableStyles.Clear();
			mobjDataView.Table = mObjDataTable;
			mobjDataView.AllowNew = true;
			dgEquipmentList.DataSource = mobjDataView;
			//dgEquipmentList.ReadOnly = False

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
			mobjGridTableStyle.PreferredRowHeight = 34;
			//29.6.2010 by dinesh wagh.
			mobjGridTableStyle.MappingName = "EquipmentList";

			objTextColumn = new DataGridTextBoxColumn();
			objTextColumn.MappingName = "SrNo";
			objTextColumn.HeaderText = "Sr.No.";
			objTextColumn.Width = 40;
			objTextColumn.ReadOnly = true;
			objTextColumn.NullText = "";
			objTextColumn.Alignment = HorizontalAlignment.Center;
			mobjGridTableStyle.GridColumnStyles.Add(objTextColumn);

			objTextColumn = new DataGridTextBoxColumn();
			objTextColumn.MappingName = "EquipmentName";
			objTextColumn.HeaderText = "Model";
			objTextColumn.Width = 120;
			objTextColumn.ReadOnly = false;
			objTextColumn.NullText = "";
			objTextColumn.Alignment = HorizontalAlignment.Left;
			mobjGridTableStyle.GridColumnStyles.Add(objTextColumn);

			objTextColumn = new DataGridTextBoxColumn();
			objTextColumn.MappingName = "SerialNumber";
			objTextColumn.HeaderText = "Instrument Serial No.";
			objTextColumn.Width = 120;
			objTextColumn.ReadOnly = false;
			objTextColumn.NullText = "";
			objTextColumn.Alignment = HorizontalAlignment.Center;
			mobjGridTableStyle.GridColumnStyles.Add(objTextColumn);

			objTextColumn = new DataGridTextBoxColumn();
			objTextColumn.MappingName = "CheckedBy";
			objTextColumn.HeaderText = "Checked By";
			objTextColumn.Width = 140;
			objTextColumn.ReadOnly = false;
			objTextColumn.NullText = "";
			objTextColumn.Alignment = HorizontalAlignment.Left;
			mobjGridTableStyle.GridColumnStyles.Add(objTextColumn);

			objTextColumn = new DataGridTextBoxColumn();
			objTextColumn.MappingName = "VerifiedBy";
			objTextColumn.HeaderText = "Verified By";
			objTextColumn.Width = 150;
			objTextColumn.ReadOnly = false;
			objTextColumn.NullText = "";
			objTextColumn.Alignment = HorizontalAlignment.Left;
			mobjGridTableStyle.GridColumnStyles.Add(objTextColumn);

			objTextColumn = new DataGridTextBoxColumn();
			objTextColumn.MappingName = "EquipmentID";
			objTextColumn.HeaderText = "EquipmentID";
			objTextColumn.Width = 0;
			objTextColumn.ReadOnly = true;
			objTextColumn.NullText = "";
			mobjGridTableStyle.GridColumnStyles.Add(objTextColumn);

			mobjGridTableStyle.GridLineColor = Color.Black;
			dgEquipmentList.TableStyles.Add(mobjGridTableStyle);
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = "Error in Formating Equipment List Data-Grid.";
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

	public bool funcSaveEquipmentListData()
	{
		//=====================================================================
		// Procedure Name        :   funcSaveEquipmentListData
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
		int intEquipmentID;
		int temp_cnt;
		string strEquipmentName;
		string strSerialNo;
		string strCheckedBy;
		string strVerifiedBy;
		bool status = true;

		try {
			intRecordCount = mObjDataTable.Rows.Count;

			for (temp_cnt = 0; temp_cnt <= (intRecordCount - 1); temp_cnt++) {
				//--- To Check if Equipment ID is Null.
				//intEquipmentID = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("EquipmentID").Ordinal)
				if (IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("EquipmentID").Ordinal))) {
					if ((IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("EquipmentName").Ordinal)) == false)) {
						strEquipmentName = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("EquipmentName").Ordinal);
						strEquipmentName = strEquipmentName.Replace(vbCrLf, " ");
						//code added by : dinesh wagh on 29.6.2010
						strSerialNo = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("SerialNumber").Ordinal);
						strSerialNo = strSerialNo.Replace(vbCrLf, " ");
						//code added by : dinesh wagh on 29.6.2010
						strCheckedBy = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("CheckedBy").Ordinal);
						strCheckedBy = strCheckedBy.Replace(vbCrLf, " ");
						//code added by : dinesh wagh on 29.6.2010
						strVerifiedBy = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("VerifiedBy").Ordinal);
						strVerifiedBy = strVerifiedBy.Replace(vbCrLf, " ");
						//code added by : dinesh wagh on 29.6.2010
						status = gobjDataAccess.funcInsertOQEquipmentListData(strEquipmentName, strSerialNo, strCheckedBy, strVerifiedBy, mintMode);
						if (!(status)) {
							throw new Exception("Error in Saving Equipment List Details.");
						}
					}
				} else {
					if (IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("EquipmentName").Ordinal)) | IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("SerialNumber").Ordinal)) | IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("CheckedBy").Ordinal)) | IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("VerifiedBy").Ordinal))) {
						intEquipmentID = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("EquipmentID").Ordinal);
						status = gobjDataAccess.funcDeleteOQEquipmentListData(intEquipmentID, mintMode);
						if (!(status)) {
							throw new Exception("Error in Deleting Equipment List Details.");
						}

					} else {
						intEquipmentID = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("EquipmentID").Ordinal);
						strEquipmentName = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("EquipmentName").Ordinal);
						strEquipmentName = strEquipmentName.Replace(vbCrLf, " ");
						//code added by : dinesh wagh on 29.6.2010
						strSerialNo = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("SerialNumber").Ordinal);
						strSerialNo = strSerialNo.Replace(vbCrLf, " ");
						//code added by : dinesh wagh on 29.6.2010
						strCheckedBy = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("CheckedBy").Ordinal);
						strCheckedBy = strCheckedBy.Replace(vbCrLf, " ");
						//code added by : dinesh wagh on 29.6.2010
						strVerifiedBy = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("VerifiedBy").Ordinal);
						strVerifiedBy = strVerifiedBy.Replace(vbCrLf, " ");
						//code added by : dinesh wagh on 29.6.2010
						status = gobjDataAccess.funcUpdateOQEquipmentListData(strEquipmentName, strSerialNo, strCheckedBy, strVerifiedBy, intEquipmentID, mintMode);
						if (!(status)) {
							throw new Exception("Error in Updating Equipment List Details.");
						}
					}
				}
			}

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = "Error in Saving Equipment List Details.";
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

	//Private Function funcInsertEquipmentListData(ByVal strEquipmentName As String, ByVal strSerialNumber As String, ByVal strCheckedBy As String, ByVal strVerifiedBy As String) As Boolean
	//    '=====================================================================
	//    ' Procedure Name        :   funcInsertEquipmentListData
	//    ' Description           :   To Add/Insert New Equipment List Data in Database.
	//    ' Purpose               :   To Add/Insert New Equipment List Data in Database.
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
	//    Dim intEquipmentID As Integer

	//    Try
	//        'Status = mclsDBFunctions.OpenConnection(mobjOleDBconnection)
	//        If Not (Status) Then
	//            Throw New Exception("Error in Opening Connection during Saving Equipment List Details.")
	//        End If

	//        '--- Generating Next Equipment ID. 
	//        'intEquipmentID = mclsDBFunctions.GetNextID("EquipmentList", "EquipmentListID", mobjOleDBconnection)

	//        '---  Query for adding  data to EquipmentList
	//        str_sql = " Insert into EquipmentList " & _
	//                  " (EquipmentListID ,Name ,SerialNo ,CheckedBy , VerifiedBy ,CheckStatusIQOQPQ) " & _
	//                  " values(?,?,?,?,?,?) "

	//        '--- Providing command object for EquimentList
	//        With objCommand
	//            .Connection = mobjOleDBconnection
	//            .CommandType = CommandType.Text
	//            .CommandText = str_sql
	//            .Parameters.Add("EquipmentListID", OleDbType.Numeric).Value = intEquipmentID
	//            .Parameters.Add("Name", OleDbType.VarChar, 50).Value = strEquipmentName
	//            .Parameters.Add("SerialNo", OleDbType.VarChar, 50).Value = strSerialNumber
	//            .Parameters.Add("CheckedBy", OleDbType.VarChar, 50).Value = strCheckedBy
	//            .Parameters.Add("VerifiedBy", OleDbType.VarChar, 50).Value = strVerifiedBy
	//            .Parameters.Add("CheckStatusIQOQPQ", OleDbType.Single).Value = mintMode
	//            .ExecuteNonQuery()
	//        End With

	//        objCommand.Dispose()
	//        Status = True

	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        '--- Error logging
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = "Error in Saving Equipment List Details."
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

	//Private Function funcUpdateEquipmentListData(ByVal strEquipmentName As String, ByVal strSerialNumber As String, ByVal strCheckedBy As String, ByVal strVerifiedBy As String, ByVal intEquipmentID As Integer) As Boolean
	//    '=====================================================================
	//    ' Procedure Name        :   funcUpdateEquipmentListData
	//    ' Description           :   To Update Equipment List Data in Database.
	//    ' Purpose               :   To Update Equipment List Data in Database.
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
	//            Throw New Exception("Error in Opening Connection during Updating Equipment List Details.")
	//        End If

	//        '---  Query for adding  data to EquipmentList
	//        str_sql = " Update EquipmentList " & _
	//                  " Set Name = ? ,SerialNo = ? ,CheckedBy = ? ,VerifiedBy =? " & _
	//                  " where EquipmentListID = " & intEquipmentID & " and CheckStatusIQOQPQ = " & mintMode & "  "

	//        '--- Providing command object for EquimentList
	//        With objCommand
	//            .Connection = mobjOleDBconnection
	//            .CommandType = CommandType.Text
	//            .CommandText = str_sql
	//            .Parameters.Add("Name", OleDbType.VarChar, 250).Value = strEquipmentName
	//            .Parameters.Add("SerialNo", OleDbType.VarChar, 250).Value = strSerialNumber
	//            .Parameters.Add("CheckedBy", OleDbType.VarChar, 250).Value = strCheckedBy
	//            .Parameters.Add("VerifiedBy", OleDbType.VarChar, 250).Value = strVerifiedBy
	//            .ExecuteNonQuery()
	//        End With

	//        objCommand.Dispose()
	//        Status = True

	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        '--- Error logging
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = "Error in Updating Equipment List Details."
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

	//Private Function funcDeleteEquipmentListData(ByVal intEquipmentID As Integer) As Boolean
	//    '=====================================================================
	//    ' Procedure Name        :   funcDeleteEquipmentListData
	//    ' Description           :   To Delete Equipment List Data from Database.
	//    ' Purpose               :   To Delete Equipment List Data from Database.
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
	//            Throw New Exception("Error in Opening Connection during Deleting Equipment List Details.")
	//        End If

	//        '--- Query to Delete from Database
	//        str_sql = " Delete * from EquipmentList " & _
	//                  " where EquipmentListID = " & intEquipmentID & " and CheckStatusIQOQPQ = " & mintMode & "  "

	//        'Status = mclsDBFunctions.AddORDeleteRecord(str_sql, mobjOleDBconnection)
	//        If (Status = False) Then
	//            MessageBox.Show("Problem in Deleting record")
	//        End If

	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        '--- Error logging
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = "Error in Deleting Equipment List Details."
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

}
