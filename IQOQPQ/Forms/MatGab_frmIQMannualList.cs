
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms.DataGridColumnStyle;

public class frmIQMannualList : System.Windows.Forms.Form
{

	#Region " Module level Declarations "
	private bool mblnModeLockStatus;
	private string mstrOledbConnectionString;
	private OleDbConnection mobjOleDBconnection;
	//Public mclsDBFunctions As New clsDatabaseFunctions
	private DataView mobjDataView = new DataView();
	private DataTable mObjDataTable;
	DataGridTableStyle mobjGridTableStyle = new DataGridTableStyle();
	int mCurrentGridRowNo = 0;

	int mCurrentGridQuantity = 0;
	private enum enumMannualListing : int
	{
		SNo = 0,
		EquipmentName = 1,
		PartNo = 2,
		Quantity = 3,
		MannualID = 4
	}
	#End Region

	#Region " Windows Form Designer generated code "

	public frmIQMannualList()
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
	internal System.Windows.Forms.DataGrid dgManualList;
	internal System.Windows.Forms.Panel Panel2;
	internal System.Windows.Forms.PictureBox PictureBox1;
	[System.Diagnostics.DebuggerStepThrough()]
	private void InitializeComponent()
	{
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmIQMannualList));
		this.Label3 = new System.Windows.Forms.Label();
		this.Panel1 = new System.Windows.Forms.Panel();
		this.Panel2 = new System.Windows.Forms.Panel();
		this.PictureBox1 = new System.Windows.Forms.PictureBox();
		this.dgManualList = new System.Windows.Forms.DataGrid();
		this.Panel1.SuspendLayout();
		this.Panel2.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.dgManualList).BeginInit();
		this.SuspendLayout();
		//
		//Label3
		//
		this.Label3.BackColor = System.Drawing.Color.AliceBlue;
		this.Label3.Font = new System.Drawing.Font("Arial", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.Label3.Location = new System.Drawing.Point(35, 7);
		this.Label3.Name = "Label3";
		this.Label3.Size = new System.Drawing.Size(408, 18);
		this.Label3.TabIndex = 10;
		this.Label3.Text = "B.  Manual Listing";
		this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//Panel1
		//
		this.Panel1.BackColor = System.Drawing.Color.AliceBlue;
		this.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.Panel1.Controls.Add(this.Panel2);
		this.Panel1.Controls.Add(this.dgManualList);
		this.Panel1.Dock = System.Windows.Forms.DockStyle.Top;
		this.Panel1.Location = new System.Drawing.Point(0, 0);
		this.Panel1.Name = "Panel1";
		this.Panel1.Size = new System.Drawing.Size(502, 456);
		this.Panel1.TabIndex = 11;
		//
		//Panel2
		//
		this.Panel2.BackColor = System.Drawing.Color.AliceBlue;
		this.Panel2.Controls.Add(this.PictureBox1);
		this.Panel2.Controls.Add(this.Label3);
		this.Panel2.Dock = System.Windows.Forms.DockStyle.Top;
		this.Panel2.Location = new System.Drawing.Point(0, 0);
		this.Panel2.Name = "Panel2";
		this.Panel2.Size = new System.Drawing.Size(500, 32);
		this.Panel2.TabIndex = 19;
		//
		//PictureBox1
		//
		this.PictureBox1.Image = (System.Drawing.Image)resources.GetObject("PictureBox1.Image");
		this.PictureBox1.Location = new System.Drawing.Point(0, 0);
		this.PictureBox1.Name = "PictureBox1";
		this.PictureBox1.Size = new System.Drawing.Size(32, 32);
		this.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.PictureBox1.TabIndex = 11;
		this.PictureBox1.TabStop = false;
		//
		//dgManualList
		//
		this.dgManualList.BackgroundColor = System.Drawing.Color.AliceBlue;
		this.dgManualList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.dgManualList.CaptionVisible = false;
		this.dgManualList.DataMember = "";
		this.dgManualList.HeaderForeColor = System.Drawing.SystemColors.ControlText;
		this.dgManualList.Location = new System.Drawing.Point(8, 48);
		this.dgManualList.Name = "dgManualList";
		this.dgManualList.ParentRowsVisible = false;
		this.dgManualList.ReadOnly = true;
		this.dgManualList.RowHeadersVisible = false;
		this.dgManualList.Size = new System.Drawing.Size(576, 224);
		this.dgManualList.TabIndex = 18;
		//
		//frmIQMannualList
		//
		this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
		this.AutoScroll = true;
		this.BackColor = System.Drawing.Color.AliceBlue;
		this.ClientSize = new System.Drawing.Size(502, 386);
		this.ControlBox = false;
		this.Controls.Add(this.Panel1);
		this.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		this.MaximizeBox = false;
		this.MinimizeBox = false;
		this.Name = "frmIQMannualList";
		this.Tag = "4";
		this.Text = "Mannual Listing";
		this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
		this.Panel1.ResumeLayout(false);
		this.Panel2.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.dgManualList).EndInit();
		this.ResumeLayout(false);

	}

	#End Region

	#Region "Constants"
	private const string ConstSrNo = "SrNo";
	private const string ConstName = "Name";
	private const string ConstPartNo = "PartNo";
	private const string ConstQuantity = "Quantity";
		#End Region
	private const string ConstManualListID = "ManualListID";

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
				//dgManualList.CurrentCell() = New DataGridCell(0, 0)
				dgManualList.CurrentCell() = new DataGridCell(dgManualList.CurrentRowIndex + 1, 0);
				if (!funcSaveIQManualListData()) {
					throw new Exception("Error in Saving Manual List Data.");
				}
				dgManualList.TableStyles.Clear();
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
	//--- funcInitialize - To Initialize form and to get values for IQ Manual List from database and display them.
	//--- subCreateDataTable - To Create Columns in the Data Table.
	//--- funcGetIQManualListRecords - To Get IQ Manual List Records from Database into DataTable.
	//--- subFormatDataGrid - To format the Data Grid.
	//--- funcSaveIQManualListData - To Save the Entered Records into Database.
	//--- funcInsertIQManualListData - To Add/Insert New Manual List Data in Database.
	//--- funcUpdateIQManualListData - To Update Manual List Data in Database.
	//--- funcDeleteIQManualListData - To Delete Manual List Data from Database.

	private void funcInitialize()
	{
		//=====================================================================
		// Procedure Name        :   funcInitailize
		// Description           :   To Initialize form and to get values for IQ Manual List from database and display them.
		// Purpose               :   To Initialize form and to get values for IQ Manual List from database and display them.
		// Parameters Passed     :   None.
		// Returns               :   None.
		// Parameters Affected   :   None.
		// Assumptions           :
		// Dependencies          :
		// Author                :   Gitesh
		// Created               :   January, 2003 
		// Revisions             :
		//=====================================================================
		DataTable mobjTmpDt = new DataTable();
		int intCount;
		DataRow objDataRow;

		try {
			//mfrmManualLst = Me
			mObjDataTable = new DataTable("ManualList");

			//subCreateDataTable()

			mObjDataTable.Columns.Add(ConstSrNo);
			mObjDataTable.Columns.Add(ConstName);
			mObjDataTable.Columns.Add(ConstPartNo);
			mObjDataTable.Columns.Add(ConstQuantity, typeof(int));
			mObjDataTable.Columns.Add(ConstManualListID);

			mobjTmpDt = gobjDataAccess.funcGetIQManualListRecords();

			if (!mobjTmpDt == null) {
				if (!mobjTmpDt.Rows.Count == 0) {
					for (intCount = 0; intCount <= mobjTmpDt.Rows.Count - 1; intCount++) {
						objDataRow = mObjDataTable.NewRow;
						objDataRow.Item(ConstSrNo) = intCount + 1;
						// by pankaj on 6 Dec 07'CInt(mobjTmpDt.Rows.Item(intCount).Item("ManualListID"))
						objDataRow.Item(ConstName) = (string)mobjTmpDt.Rows.Item(intCount).Item("Name");
						objDataRow.Item(ConstPartNo) = (string)mobjTmpDt.Rows.Item(intCount).Item("PartNo");
						objDataRow.Item(ConstQuantity) = (string)mobjTmpDt.Rows.Item(intCount).Item("Quantity");
						objDataRow.Item(ConstManualListID) = (int)mobjTmpDt.Rows.Item(intCount).Item("ManualListID");
						mObjDataTable.Rows.Add(objDataRow);
					}
				}
			}

			if (IsNothing(mObjDataTable) == true) {
				throw new Exception("Error in Getting Equipment List Records.");
			} else {
				subFormatDataGrid();
			}
			//If funcGetIQManualListRecords() Then
			//    subFormatDataGrid()
			//Else
			//    Throw New Exception("Error in Getting Manual List Records.")
			//End If

			mblnModeLockStatus = gobjDataAccess.funcCheckModeLocked(ENUM_IQOQPQ_STATUS.IQ);
			if ((mblnModeLockStatus)) {
				dgManualList.ReadOnly = true;
			} else {
				dgManualList.ReadOnly = false;
			}
			if ((mObjDataTable.Rows.Count > 0)) {
				mCurrentGridQuantity = dgManualList.Item(0, 3);
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

			mObjDataTable.Columns.Add(new DataColumn("Name", typeof(string)));
			mObjDataTable.Columns.Add(new DataColumn("PartNo", typeof(string)));
			mObjDataTable.Columns.Add(new DataColumn("Quantity", typeof(string)));
			mObjDataTable.Columns.Add(new DataColumn("ManualListID", typeof(int)));

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = "Error in Creating Manual List Data-Table.";
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

	//Private Function funcGetIQManualListRecords() As Boolean
	//    '=====================================================================
	//    ' Procedure Name        :   funcGetIQManualListRecords
	//    ' Description           :   To Get IQ Manual List Records from Database into DataTable.
	//    ' Purpose               :   To Get IQ Manual List Records from Database into DataTable.
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
	//        'sql_string = "Select ManualListID ,Name ,PartNo , Quantity from IQManualList "

	//        ''reader_status = mclsDBFunctions.GetRecords(sql_string, mobjOleDBconnection, objReader)

	//        'If Not (reader_status) Then
	//        '    Throw New Exception("Error in Opening Connection during Getting Manual List Details.")
	//        'End If

	//        'rec_cnt = 1
	//        'While objReader.Read
	//        '    objDataRow = mObjDataTable.NewRow()

	//        '    objDataRow("SrNo") = rec_cnt
	//        '    objDataRow("Name") = CStr(objReader.Item("Name"))
	//        '    objDataRow("PartNo") = CStr(objReader.Item("PartNo"))
	//        '    objDataRow("Quantity") = CStr(objReader.Item("Quantity"))
	//        '    objDataRow("ManualListID") = Convert.ToInt32(objReader.Item("ManualListID"))

	//        '    mObjDataTable.Rows.Add(objDataRow)
	//        '    rec_cnt = rec_cnt + 1
	//        'End While
	//        'objReader.Close()

	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        'Error logging
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = "Error in Getting Manual List Records."
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
			dgManualList.TableStyles.Clear();

			mobjDataView.Table = mObjDataTable;
			mobjDataView.AllowNew = true;
			dgManualList.DataSource = mobjDataView;
			//dgManualList.ReadOnly = False

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

			mobjGridTableStyle.MappingName = "ManualList";

			objTextColumn = new DataGridTextBoxColumn();
			objTextColumn.MappingName = "SrNo";
			objTextColumn.HeaderText = "Sr.No.";
			objTextColumn.Width = 50;
			objTextColumn.ReadOnly = true;
			objTextColumn.NullText = "";
			objTextColumn.Alignment = HorizontalAlignment.Center;
			mobjGridTableStyle.GridColumnStyles.Add(objTextColumn);

			objTextColumn = new DataGridTextBoxColumn();
			objTextColumn.MappingName = "Name";
			objTextColumn.HeaderText = "Manual";
			objTextColumn.Width = 220;
			objTextColumn.ReadOnly = false;
			objTextColumn.NullText = "";
			mobjGridTableStyle.GridColumnStyles.Add(objTextColumn);

			objTextColumn = new DataGridTextBoxColumn();
			objTextColumn.MappingName = "PartNo";
			objTextColumn.HeaderText = "Part Number";
			objTextColumn.Width = 170;
			objTextColumn.ReadOnly = false;
			objTextColumn.NullText = "";
			objTextColumn.Alignment = HorizontalAlignment.Center;
			mobjGridTableStyle.GridColumnStyles.Add(objTextColumn);

			objTextColumn = new DataGridTextBoxColumn();
			objTextColumn.MappingName = "Quantity";
			objTextColumn.HeaderText = "Quantity";
			objTextColumn.Width = 130;
			objTextColumn.ReadOnly = false;
			objTextColumn.NullText = "";
			objTextColumn.Alignment = HorizontalAlignment.Center;
			mobjGridTableStyle.GridColumnStyles.Add(objTextColumn);

			objTextColumn = new DataGridTextBoxColumn();
			objTextColumn.MappingName = "ManualListID";
			objTextColumn.HeaderText = "ManualListID";
			objTextColumn.Width = 0;
			objTextColumn.ReadOnly = true;
			objTextColumn.NullText = "";
			mobjGridTableStyle.GridColumnStyles.Add(objTextColumn);

			mobjGridTableStyle.GridLineColor = Color.Black;
			dgManualList.TableStyles.Add(mobjGridTableStyle);

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = "Error in Formating Manual List Data-Grid.";
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

	public bool funcSaveIQManualListData()
	{
		//=====================================================================
		// Procedure Name        :   funcSaveIQManualListData
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
		int intManualListID;
		int temp_cnt;
		string strName;
		string strPartNo;
		string strQuantity;
		bool status = true;
		DataRow objDataRow;

		try {
			//If mObjDataTable.Rows.Count = 0 Then
			//    objDataRow = mObjDataTable.NewRow()
			//    objDataRow("SrNo") = dgManualList.Item(0, 0)
			//    objDataRow("Name") = dgManualList.Item(0, 1)
			//    objDataRow("PartNo") = dgManualList.Item(0, 2)
			//    objDataRow("Quantity") = dgManualList.Item(0, 3)
			//    objDataRow("ManualListID") = dgManualList.Item(0, 4)
			//    mObjDataTable.Rows.Add(objDataRow)
			//End If

			intRecordCount = mObjDataTable.Rows.Count;

			for (temp_cnt = 0; temp_cnt <= (intRecordCount - 1); temp_cnt++) {
				//--- To Check if Manual List ID is Null.
				if (IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("ManualListID").Ordinal))) {
					if ((IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("Name").Ordinal)) == false)) {
						//If IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("Name").Ordinal)) = False Then
						strName = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("Name").Ordinal);
						//End If

						//If IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("PartNo").Ordinal)) = False Then
						strPartNo = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("PartNo").Ordinal);
						//End If

						strQuantity = " ";
						if (IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("Quantity").Ordinal)) == false) {
							strQuantity = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("Quantity").Ordinal);
						}


						status = gobjDataAccess.funcInsertIQManualListData(strName, strPartNo, strQuantity);
						if (!(status)) {
							throw new Exception("Error in Saving Manual List Details.");
						}
					}
				} else {
					if (IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("Name").Ordinal)) | IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("PartNo").Ordinal)) | IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("Quantity").Ordinal))) {
						intManualListID = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("ManualListID").Ordinal);
						status = gobjDataAccess.funcDeleteIQManualListData(intManualListID);
						if (!(status)) {
							throw new Exception("Error in Deleting Manual List Details.");
						}
					} else {
						intManualListID = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("ManualListID").Ordinal);
						strName = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("Name").Ordinal);
						strPartNo = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("PartNo").Ordinal);
						strQuantity = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("Quantity").Ordinal);
						status = gobjDataAccess.funcUpdateIQManualListData(strName, strPartNo, strQuantity, intManualListID);
						if (!(status)) {
							throw new Exception("Error in Updating Manual List Details.");
						}
					}
				}
			}
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = "Error in Saving Manual List Details.";
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

	//Private Function funcInsertIQManualListData(ByVal strName As String, ByVal strPartNo As String, ByVal strQuantity As String) As Boolean
	//    '=====================================================================
	//    ' Procedure Name        :   funcInsertIQEquipmentListData
	//    ' Description           :   To Add/Insert New Manual List Data in Database.
	//    ' Purpose               :   To Add/Insert New Manual List Data in Database.
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
	//    Dim intManualListID As Integer

	//    Try
	//        'Status = mclsDBFunctions.OpenConnection(mobjOleDBconnection)
	//        If Not (Status) Then
	//            Throw New Exception("Error in Opening Connection during Saving Manual List Details.")
	//        End If

	//        '--- Generating Next Equipment ID. 
	//        'intManualListID = mclsDBFunctions.GetNextID("IQManualList", "ManualListID", mobjOleDBconnection)

	//        '---  Query for adding  data to EquipmentList
	//        str_sql = " Insert into IQManualList " & _
	//                  " (ManualListID ,Name ,PartNo ,Quantity) " & _
	//                  " values(?,?,?,?) "

	//        '--- Providing command object for EquimentList
	//        With objCommand
	//            .Connection = mobjOleDBconnection
	//            .CommandType = CommandType.Text
	//            .CommandText = str_sql
	//            .Parameters.Add("ManualListID", OleDbType.Numeric).Value = intManualListID
	//            .Parameters.Add("Name", OleDbType.VarChar, 50).Value = strName
	//            .Parameters.Add("PartNo", OleDbType.VarChar, 50).Value = strPartNo
	//            .Parameters.Add("Quantity", OleDbType.VarChar, 50).Value = strQuantity
	//            .ExecuteNonQuery()
	//        End With

	//        objCommand.Dispose()
	//        Status = True

	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        '--- Error logging
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = "Error in Saving Manual List Details."
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

	//Private Function funcUpdateIQManualListData(ByVal strName As String, ByVal strPartNo As String, ByVal strQuantity As String, ByVal intManualListID As Integer) As Boolean
	//    '=====================================================================
	//    ' Procedure Name        :   funcUpdateIQManualListData
	//    ' Description           :   To Update Manual List Data in Database.
	//    ' Purpose               :   To Update Manual List Data in Database.
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
	//            Throw New Exception("Error in Opening Connection during Updating Manual List Details.")
	//        End If

	//        '---  Query for adding  data to EquipmentList
	//        str_sql = " Update IQManualList " & _
	//                  " Set Name = ? ,PartNo = ? , Quantity = ? " & _
	//                  " where ManualListID = " & intManualListID & " "

	//        '--- Providing command object for EquimentList
	//        With objCommand
	//            .Connection = mobjOleDBconnection
	//            .CommandType = CommandType.Text
	//            .CommandText = str_sql
	//            .Parameters.Add("Name", OleDbType.VarChar, 250).Value = strName
	//            .Parameters.Add("PartNo", OleDbType.VarChar, 250).Value = strPartNo
	//            .Parameters.Add("Quantity", OleDbType.VarChar, 250).Value = strQuantity
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

	//Private Function funcDeleteIQManualListData(ByVal intManuaListID As Integer) As Boolean
	//    '=====================================================================
	//    ' Procedure Name        :   funcDeleteIQManualListData
	//    ' Description           :   To Delete Manual List Data from Database.
	//    ' Purpose               :   To Delete Manual List Data from Database.
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
	//            Throw New Exception("Error in Opening Connection during Deleting Manual List Details.")
	//        End If

	//        '--- Query to Delete from Database
	//        str_sql = " Delete * from IQManualList " & _
	//                  " where ManualListID = " & intManuaListID & " "

	//        'Status = mclsDBFunctions.AddORDeleteRecord(str_sql, mobjOleDBconnection)
	//        If (Status = False) Then
	//            MessageBox.Show("Problem in Deleting record")
	//        End If

	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        '--- Error logging
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = "Error in Deleting Manual List Details."
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

	private void  // ERROR: Handles clauses are not supported in C#
dgManualList_CurrentCellChanged(object sender, System.EventArgs e)
	{

		try {

			mObjDataTable.Columns(0).ReadOnly = false;

			if (mObjDataTable.Rows.Count == 0) {
				mObjDataTable.Columns(0).DefaultValue = 1;
			} else {
				if ((dgManualList.CurrentRowIndex != -1)) {
					dgManualList.Item(dgManualList.CurrentRowIndex, 0) = dgManualList.CurrentRowIndex + 1;
				}
			}

			mObjDataTable.Columns(0).ReadOnly = true;

			if (dgManualList.CurrentRowIndex >= 10) {
				mobjDataView.AllowNew = false;
			}
			//'Added By Pankaj on Sat 19 May 07 5:37
			//If (mCurrentGridRowNo <> -1) Then
			//    If (Convert.ToString(dgManualList.Item(mCurrentGridRowNo, 3)).Trim() <> "") And Not IsDBNull(dgManualList.Item(mCurrentGridRowNo, 3)) Then
			//        If Not (IsNumeric(dgManualList.Item(mCurrentGridRowNo, 3))) Then
			//            dgManualList.Item(mCurrentGridRowNo, 3) = mCurrentGridQuantity
			//        End If
			//    End If
			//End If

			//mCurrentGridRowNo = dgManualList.CurrentRowIndex
			//If (dgManualList.CurrentRowIndex <> -1) Then  'Condition added by PAnkaj 30 May 07
			//    If Not (IsDBNull(dgManualList.Item(dgManualList.CurrentRowIndex, 3))) Then
			//        mCurrentGridQuantity = dgManualList.Item(dgManualList.CurrentRowIndex, 3)
			//    Else
			//        mCurrentGridQuantity = 0
			//    End If
			//End If


			//-------15.2.2010    by dinesh wagh
			if (mObjDataTable.Rows.Count == 0 & dgManualList.CurrentRowIndex != -1) {
				dgManualList.Item(0, 0) = 1;
			}
		//-------------


		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.ProcessError(ErrorHandler.ErrorHandler.EnumErrorType.Critical, ex);
			//---------------------------------------------------------
		}
	}


	private void  // ERROR: Handles clauses are not supported in C#
frmIQMannualList_Closed(object sender, System.EventArgs e)
	{
	}
}
