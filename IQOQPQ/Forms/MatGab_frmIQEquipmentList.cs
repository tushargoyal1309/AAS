
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms.DataGridColumnStyle;

public class frmIQEquipmentList : System.Windows.Forms.Form
{

	#Region " Module level Declarations "
	private bool mblnModeLockStatus;
	//Private mstrOledbConnectionString As String
	//Private mobjOleDBconnection As OleDbConnection
	//Public mclsDBFunctions As New clsDatabaseFunctions

	private DataTable mObjDataTable;
	DataGridTableStyle mobjGridTableStyle = new DataGridTableStyle();

	DataView objDataView;
	//30.6.2010 by dinesh wagh
	//---------------------------------------------
	int mintRowIndex;
	int mintColumnIndex;
	private const  CONST_ModelColumnSize = 18;
	private const  CONST_InstSrNoColumnSize = 20;
	private const  CONST_CheckedByColumnSize = 20;

	private const  CONST_VerifiedByColumnSize = 23;
	//------------------------------------------

	//30.6.2010 by dinesh wagh
	private enum EnumColumns
	{
		SrNo = 0,
		Model = 1,
		InstSrNo = 2,
		CheckedBy = 3,
		VerifiedBy = 4
	}


	#End Region

	#Region "Constants"
	private const string ConstSrNo = "SrNo";
	private const string ConstEquipmentName = "EquipmentName";
	private const string ConstSerialNumber = "SerialNumber";
		#End Region
	private const string ConstEquipmentID = "EquipmentID";

	#Region " Windows Form Designer generated code "

	public frmIQEquipmentList()
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
	internal System.Windows.Forms.Label lblHeader;
	internal System.Windows.Forms.DataGrid dgEquipmentList;
	internal System.Windows.Forms.Panel Panel2;
	internal System.Windows.Forms.PictureBox PictureBox1;
	internal System.Windows.Forms.Label lblSystem;
	internal System.Windows.Forms.Label lblAAS;
	internal System.Windows.Forms.Label lblModelNo;
	internal System.Windows.Forms.ComboBox cmbModelList;
	[System.Diagnostics.DebuggerStepThrough()]
	private void InitializeComponent()
	{
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmIQEquipmentList));
		this.Panel1 = new System.Windows.Forms.Panel();
		this.cmbModelList = new System.Windows.Forms.ComboBox();
		this.lblModelNo = new System.Windows.Forms.Label();
		this.lblAAS = new System.Windows.Forms.Label();
		this.lblSystem = new System.Windows.Forms.Label();
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
		this.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.Panel1.Controls.Add(this.cmbModelList);
		this.Panel1.Controls.Add(this.lblModelNo);
		this.Panel1.Controls.Add(this.lblAAS);
		this.Panel1.Controls.Add(this.lblSystem);
		this.Panel1.Controls.Add(this.lblHeader);
		this.Panel1.Controls.Add(this.Panel2);
		this.Panel1.Controls.Add(this.dgEquipmentList);
		this.Panel1.Dock = System.Windows.Forms.DockStyle.Top;
		this.Panel1.Location = new System.Drawing.Point(0, 0);
		this.Panel1.Name = "Panel1";
		this.Panel1.Size = new System.Drawing.Size(471, 456);
		this.Panel1.TabIndex = 10;
		//
		//cmbModelList
		//
		this.cmbModelList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cmbModelList.Items.AddRange(new object[] {
			"AA301",
			"AA303",
			"AA303D"
		});
		this.cmbModelList.Location = new System.Drawing.Point(408, 45);
		this.cmbModelList.Name = "cmbModelList";
		this.cmbModelList.Size = new System.Drawing.Size(80, 23);
		this.cmbModelList.TabIndex = 24;
		//
		//lblModelNo
		//
		this.lblModelNo.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblModelNo.Location = new System.Drawing.Point(344, 48);
		this.lblModelNo.Name = "lblModelNo";
		this.lblModelNo.Size = new System.Drawing.Size(64, 16);
		this.lblModelNo.TabIndex = 22;
		this.lblModelNo.Text = "Model No. ";
		//
		//lblAAS
		//
		this.lblAAS.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblAAS.Location = new System.Drawing.Point(80, 48);
		this.lblAAS.Name = "lblAAS";
		this.lblAAS.Size = new System.Drawing.Size(232, 16);
		this.lblAAS.TabIndex = 21;
		this.lblAAS.Text = "Atomic Absorption Spectrometer";
		//
		//lblSystem
		//
		this.lblSystem.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblSystem.Location = new System.Drawing.Point(8, 48);
		this.lblSystem.Name = "lblSystem";
		this.lblSystem.Size = new System.Drawing.Size(64, 16);
		this.lblSystem.TabIndex = 20;
		this.lblSystem.Text = "System   :";
		//
		//lblHeader
		//
		this.lblHeader.BackColor = System.Drawing.Color.AliceBlue;
		this.lblHeader.Font = new System.Drawing.Font("Arial", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblHeader.Location = new System.Drawing.Point(35, 7);
		this.lblHeader.Name = "lblHeader";
		this.lblHeader.Size = new System.Drawing.Size(376, 18);
		this.lblHeader.TabIndex = 10;
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
		this.Panel2.Size = new System.Drawing.Size(469, 32);
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
		//dgEquipmentList
		//
		this.dgEquipmentList.BackgroundColor = System.Drawing.Color.AliceBlue;
		this.dgEquipmentList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.dgEquipmentList.CaptionVisible = false;
		this.dgEquipmentList.DataMember = "";
		this.dgEquipmentList.HeaderForeColor = System.Drawing.SystemColors.ControlText;
		this.dgEquipmentList.Location = new System.Drawing.Point(8, 93);
		this.dgEquipmentList.Name = "dgEquipmentList";
		this.dgEquipmentList.ParentRowsVisible = false;
		this.dgEquipmentList.ReadOnly = true;
		this.dgEquipmentList.RowHeadersVisible = false;
		this.dgEquipmentList.Size = new System.Drawing.Size(576, 170);
		this.dgEquipmentList.TabIndex = 18;
		//
		//frmIQEquipmentList
		//
		this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
		this.AutoScroll = true;
		this.BackColor = System.Drawing.Color.AliceBlue;
		this.ClientSize = new System.Drawing.Size(471, 386);
		this.ControlBox = false;
		this.Controls.Add(this.Panel1);
		this.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		this.MaximizeBox = false;
		this.MinimizeBox = false;
		this.Name = "frmIQEquipmentList";
		this.Tag = "3";
		this.Text = "Equipment Listing";
		this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
		this.Panel1.ResumeLayout(false);
		this.Panel2.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.dgEquipmentList).EndInit();
		this.ResumeLayout(false);

	}

	#End Region

	#Region " Form Events "
	private void  // ERROR: Handles clauses are not supported in C#
frmIQEquipmentList_Load(object sender, System.EventArgs e)
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
frmIQEquipmentList_Closing(object sender, System.ComponentModel.CancelEventArgs e)
	{
		try {
			if (!(mblnModeLockStatus)) {
				dgEquipmentList.CurrentCell() = (new DataGridCell(dgEquipmentList.CurrentRowIndex + 1, 0));
				if (!funcSaveIQEquipmentListData()) {
					throw new Exception("Error in Saving Equipment List Data.");
				}
				dgEquipmentList.TableStyles.Clear();
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
	//--- funcInitialize - To Initialize form and to get values for IQ Equipment List from database and display them.
	//--- subCreateDataTable - To Create Columns in the Data Table.
	//--- funcGetIQEquipmentListRecords - To Get IQ Equipment List Records from Database into DataTable.
	//--- subFormatDataGrid - To format the Data Grid.
	//--- funcSaveIQEquipmentListData - To Save the Entered Records into Database.
	//--- funcInsertIQEquipmentListData - To Add/Insert New Equipment List Data in Database.
	//--- funcUpdateIQEquipmentListData - To Update Equipment List Data in Database.
	//--- funcDeleteIQEquipmentListData - To Delete Equipment List Data from Database.

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
		//mfrmEqLst = Me
		//Dim objDataColumn As DataColumn
		int intRowCount;
		DataRow objDataRow;
		int intCount = 0;
		DataTable mobjTmpDt = new DataTable();

		try {
			//code commented by ; dinesh wagh on 15.2.2010
			//-----------------------------------------------------------
			//mObjDataTable = New DataTable("EquipmentList")
			//mObjDataTable.Columns.Add(ConstSrNo)
			//mObjDataTable.Columns.Add(ConstEquipmentName)
			//mObjDataTable.Columns.Add(ConstSerialNumber)
			//mObjDataTable.Columns.Add(ConstEquipmentID)
			//-------------------------------------------------------------

			//code added by  dinesh wagh on 15.2.2010
			//------------------------------------------------------
			DataColumn objDataColumn;
			objDataColumn = new DataColumn("SrNo", typeof(int));
			objDataColumn.ReadOnly = true;
			mObjDataTable = new DataTable("EquipmentList");
			mObjDataTable.Columns.Add(objDataColumn);
			mObjDataTable.Columns.Add(new DataColumn("EquipmentName", typeof(string)));
			mObjDataTable.Columns.Add(new DataColumn("SerialNumber", typeof(string)));
			mObjDataTable.Columns.Add(new DataColumn("CheckedBy", typeof(string)));
			mObjDataTable.Columns.Add(new DataColumn("VerifiedBy", typeof(string)));
			mObjDataTable.Columns.Add(new DataColumn("EquipmentID", typeof(int)));
			//------------------------------------------------------------------


			mobjTmpDt = gobjDataAccess.funcGetIQEquipmentListRecords();

			if (!mobjTmpDt == null) {
				if (!mobjTmpDt.Rows.Count == 0) {

					for (intCount = 0; intCount <= mobjTmpDt.Rows.Count - 1; intCount++) {

						//----------------
						//15.2.2010   by dinesh wagh
						objDataRow = mObjDataTable.NewRow;
						objDataRow.Item(ConstSrNo) = intCount + 1;
						//by pankaj on 6 Dec 07'CInt(mobjTmpDt.Rows.Item(intCount).Item("EquipmentListID"))
						objDataRow.Item(ConstEquipmentName) = gfuncWordWrap((string)mobjTmpDt.Rows.Item(intCount).Item("Name"), CONST_ModelColumnSize);
						//29.6.2010 by dinesh wagh to word wrap the text.
						objDataRow.Item(ConstSerialNumber) = gfuncWordWrap((string)mobjTmpDt.Rows.Item(intCount).Item("SerialNo"), CONST_InstSrNoColumnSize);
						//29.6.2010 by dinesh wagh to word wrap the text.
						objDataRow.Item("CheckedBy") = gfuncWordWrap((string)mobjTmpDt.Rows.Item(intCount).Item("CheckedBy"), CONST_CheckedByColumnSize);
						//29.6.2010 by dinesh wagh to word wrap the text.
						objDataRow.Item("VerifiedBy") = gfuncWordWrap((string)mobjTmpDt.Rows.Item(intCount).Item("VerifiedBy"), CONST_VerifiedByColumnSize);
						//29.6.2010 by dinesh wagh to word wrap the text.
						objDataRow.Item(ConstEquipmentID) = (int)mobjTmpDt.Rows.Item(intCount).Item("EquipmentListID");
						mObjDataTable.Rows.Add(objDataRow);
						if ((Convert.ToString(mobjTmpDt.Rows.Item(intCount).Item("ModelNO")) != "")) {
							if ((cmbModelList.Items.Contains(mobjTmpDt.Rows.Item(intCount).Item("ModelNO")))) {
								cmbModelList.Text = (string)mobjTmpDt.Rows.Item(intCount).Item("ModelNO");
							}
						}
						//----------------


						//code commented by  ; dinesh wagh on 15.2.2010
						//----------------------------------------------------------------------------
						//'objDataRow = mObjDataTable.NewRow
						///objDataRow.Item(ConstSrNo) = CInt(mobjTmpDt.Rows.Item(intCount).Item("EquipmentListID"))
						///Added by pankaj on 6 Dec 07
						//'objDataRow.Item(ConstSrNo) = intCount + 1
						//'objDataRow.Item(ConstEquipmentName) = CStr(mobjTmpDt.Rows.Item(intCount).Item("Name"))
						//'objDataRow.Item(ConstSerialNumber) = CStr(mobjTmpDt.Rows.Item(intCount).Item("SerialNo"))
						//'objDataRow.Item(ConstEquipmentID) = CInt(mobjTmpDt.Rows.Item(intCount).Item("EquipmentListID"))
						//'mObjDataTable.Rows.Add(objDataRow)
						//'If (Convert.ToString(mobjTmpDt.Rows.Item(intCount).Item("ModelNO")) <> "") Then
						//'    If (cmbModelList.Items.Contains(mobjTmpDt.Rows.Item(intCount).Item("ModelNO"))) Then
						//'        cmbModelList.Text = CStr(mobjTmpDt.Rows.Item(intCount).Item("ModelNO"))
						//'    End If
						//'End If
						//---------------------------------------------------

					}
				}
			}

			if (IsNothing(mObjDataTable) == true) {
				throw new Exception("Error in Getting Equipment List Records.");

			} else {
				subFormatDataGrid();
			}

			//mobjTmpDt = New DataTable
			mblnModeLockStatus = gobjDataAccess.funcCheckModeLocked(ENUM_IQOQPQ_STATUS.IQ);
			if ((mblnModeLockStatus)) {
				dgEquipmentList.ReadOnly = true;
				cmbModelList.Enabled = false;
				//Added by pankaj on 6.12.07
			} else {
				cmbModelList.Enabled = true;
				//Added by pankaj on 6.12.07
				dgEquipmentList.ReadOnly = false;
			}
			//Added By Pankaj Sat 19 MAy 07
			//If (cmbModelList.Text.Trim() = "") Then
			//    cmbModelList.SelectedIndex = 0
			//End If
			gobjModelNo = cmbModelList.Text;
		//------

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
		int intRowCount;
		DataRow objDataRow;
		try {
		//If mObjDataTable.Columns.Count <= 0 Then
		//objDataColumn = New DataColumn("SrNo", GetType(Integer))
		//objDataColumn.ReadOnly = True
		//mObjDataTable.Columns.Add(objDataColumn)

		//mObjDataTable.Columns.Add(New DataColumn("EquipmentName", GetType(String)))
		//mObjDataTable.Columns.Add(New DataColumn("SerialNumber", GetType(String)))
		//mObjDataTable.Columns.Add(New DataColumn("EquipmentID", GetType(Integer)))
		//End If
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

	//Private Function funcGetIQEquipmentListRecords() As Boolean
	//    '=====================================================================
	//    ' Procedure Name        :   funcGetIQEquipmentListRecords
	//    ' Description           :   To Get IQ Equipment List Records from Database into DataTable.
	//    ' Purpose               :   To Get IQ Equipment List Records from Database into DataTable.
	//    ' Parameters Passed     :   None.
	//    ' Returns               :   None.
	//    ' Parameters Affected   :   None.
	//    ' Assumptions           :
	//    ' Dependencies          :
	//    ' Author                :   
	//    ' Created               :   January, 2003 
	//    ' Revisions             :
	//    '=====================================================================

	//    'Dim objReader As OleDbDataReader
	//    Dim objDataRow As DataRow
	//    Dim sql_string As String
	//    'Dim reader_status As Boolean
	//    Dim rec_cnt As Integer
	//    Dim intRowCount As Integer

	//    Try
	//        sql_string = "Select EquipmentListID ,Name ,SerialNo from EquipmentList where CheckStatusIQOQPQ = 1 "

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
	//            objDataRow("EquipmentID") = Convert.ToInt32(objReader.Item("EquipmentListID"))
	//            mObjDataTable.Rows.Add(objDataRow)

	//            rec_cnt = rec_cnt + 1
	//        End While
	//        objReader.Close()

	//        'For intRowCount = rec_cnt To 10
	//        '    objDataRow = mObjDataTable.NewRow()
	//        '    objDataRow("SrNo") = rec_cnt
	//        '    objDataRow("EquipmentName") = ""
	//        '    objDataRow("SerialNumber") = ""
	//        '    objDataRow("EquipmentID") = intRowCount
	//        '    mObjDataTable.Rows.Add(objDataRow)
	//        'Next

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
		//Dim objTextColumn As DataGridTextBoxColumn '15.2.2010 by dinesh wagh

		//Dim objDataView As New DataView
		//Dim objDataView As New DataView(mObjDataTable)

		try {
			//code commented by ; dinesh wagh on 15.2.2010
			//-------------------------------------------------------------
			//'objDataView = New DataView
			//'dgEquipmentList.TableStyles.Clear()
			//'objDataView.Table = mObjDataTable
			///objDataView = mObjDataTable.DefaultView
			//'objDataView.AllowNew = True
			//'dgEquipmentList.DataSource = objDataView
			///dgEquipmentList.ReadOnly = False

			//'mobjGridTableStyle.RowHeadersVisible = False
			//'mobjGridTableStyle.ResetAlternatingBackColor()
			//'mobjGridTableStyle.ResetBackColor()
			//'mobjGridTableStyle.ResetForeColor()
			//'mobjGridTableStyle.ResetGridLineColor()
			//'mobjGridTableStyle.BackColor = Color.AliceBlue
			//'mobjGridTableStyle.GridLineColor = Color.Black
			//'mobjGridTableStyle.HeaderBackColor = Color.FromArgb(205, 225, 250)
			//'mobjGridTableStyle.HeaderForeColor = Color.Black
			//'mobjGridTableStyle.AlternatingBackColor = Color.AliceBlue
			//'mobjGridTableStyle.AllowSorting = False

			//'mobjGridTableStyle.MappingName = "EquipmentList"

			//'objTextColumn = New DataGridTextBoxColumn
			//'objTextColumn.MappingName = "SrNo"
			//'objTextColumn.HeaderText = "Sr.No."
			//'objTextColumn.Width = 50
			//'objTextColumn.ReadOnly = True
			//'objTextColumn.NullText = ""
			//'objTextColumn.Alignment = HorizontalAlignment.Center
			//'mobjGridTableStyle.GridColumnStyles.Add(objTextColumn)

			//'objTextColumn = New DataGridTextBoxColumn
			//'objTextColumn.MappingName = "EquipmentName"
			//'objTextColumn.HeaderText = "Equipment Name"
			//'objTextColumn.Width = 300
			//'ob    jTextColumn.ReadOnly = False
			//'objTextColumn.NullText = ""
			//'mobjGridTableStyle.GridColumnStyles.Add(objTextColumn)

			//'objTextColumn = New DataGridTextBoxColumn
			//'objTextColumn.MappingName = "SerialNumber"
			//'objTextColumn.HeaderText = "Instrument Serial No."
			//'objTextColumn.Width = 220
			//'objTextColumn.ReadOnly = False
			//'objTextColumn.NullText = ""
			//'objTextColumn.Alignment = HorizontalAlignment.Center
			//'mobjGridTableStyle.GridColumnStyles.Add(objTextColumn)

			//'objTextColumn = New DataGridTextBoxColumn
			//'objTextColumn.MappingName = "EquipmentID"
			//'objTextColumn.HeaderText = "EquipmentID"
			//'objTextColumn.Width = 0
			//'objTextColumn.ReadOnly = True
			//'objTextColumn.NullText = ""
			//'mobjGridTableStyle.GridColumnStyles.Add(objTextColumn)

			//'mobjGridTableStyle.GridLineColor = Color.Black
			//'dgEquipmentList.TableStyles.Add(mobjGridTableStyle)
			//-------------------------------------------------------------



			//code added by ; dinesh wagh on 15.2.2010
			//--------------------------------------------------------
			DataGridTextBoxColumn objTextColumn;
			DataView mobjDataView = new DataView();
			mobjDataView = new DataView();
			dgEquipmentList.TableStyles.Clear();
			mobjDataView.Table = mObjDataTable;
			mobjDataView.AllowNew = true;
			dgEquipmentList.DataSource = mobjDataView;
			//dgEquipmentList.ReadOnly = False
			mobjGridTableStyle.PreferredRowHeight = 34;
			//9.7.2010 by Dinesh Wagh

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
		//------------------------------------------------------


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

	public bool funcSaveIQEquipmentListData()
	{
		//=====================================================================
		// Procedure Name        :   funcSaveIQEquipmentListData
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

		//code commented by ; dinesh wagh on 15.2.2010
		//-------------------------------------------------------------------
		//'Dim intRecordCount, intEquipmentID, temp_cnt As Integer
		//'Dim strEquipmentName, strSerialNo As String
		//------------------------------------------------------------
		bool status = true;
		//mObjDataTable = New DataTable("EquipmentList")
		int intRecordCount;
		int intEquipmentID;
		int temp_cnt;
		string strEquipmentName;
		string strSerialNo;
		string strCheckedBy;
		string strVerifiedBy;
		try {
			//subCreateDataTable()
			//code commented by : dinesh wagh on 15.2.2010
			//-------------------------------------------------------------
			///'intRecordCount = mObjDataTable.Rows.Count
			///'For temp_cnt = 0 To (intRecordCount - 1)

			///'    '--- To Check if Equipment ID is Null.
			///'    'intEquipmentID = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("EquipmentID").Ordinal)
			///'    If IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("EquipmentID").Ordinal)) Then
			///'        If (IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("EquipmentName").Ordinal)) = False) Then
			///'            strEquipmentName = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("EquipmentName").Ordinal)
			///'            strSerialNo = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("SerialNumber").Ordinal)
			///'            status = gobjDataAccess.funcInsertIQEquipmentList(strEquipmentName, strSerialNo)
			///'            If Not (status) Then
			///'                Throw New Exception("Error in Saving Equipment List Details.")
			///'            End If
			///'        End If
			///'    Else
			///'        If IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("EquipmentName").Ordinal)) Or IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("SerialNumber").Ordinal)) Then
			///'            intEquipmentID = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("EquipmentID").Ordinal)
			///'            status = gobjDataAccess.funcDeleteIQEquipmentList(intEquipmentID)
			///'            If Not (status) Then
			///'                Throw New Exception("Error in Deleting Equipment List Details.")
			///'            End If
			///'        Else
			///'            intEquipmentID = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("EquipmentID").Ordinal)
			///'            strEquipmentName = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("EquipmentName").Ordinal)
			///'            strSerialNo = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("SerialNumber").Ordinal)
			///'            status = gobjDataAccess.funcUpdateIQEquipmentList(strEquipmentName, strSerialNo, intEquipmentID)
			///'            If Not (status) Then
			///'                Throw New Exception("Error in Updating Equipment List Details.")
			///'            End If
			///'        End If
			///'    End If
			///'Next
			//--------------------------------------------------
			//code added by ; dinesh wagh on 15.2.2010
			//------------------------------------------------------------
			intRecordCount = mObjDataTable.Rows.Count;

			for (temp_cnt = 0; temp_cnt <= (intRecordCount - 1); temp_cnt++) {
				strEquipmentName = "";
				strSerialNo = "";
				strCheckedBy = "";
				strVerifiedBy = "";
				//16.06.2010 by dinesh wagh to initialize the string
				//--- To Check if Equipment ID is Null.
				//intEquipmentID = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("EquipmentID").Ordinal)
				if (IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("EquipmentID").Ordinal))) {
					if (!(IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("EquipmentName").Ordinal))))
						strEquipmentName = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("EquipmentName").Ordinal);
					//16.6.2010 by dinesh wagh only Null is check before assinging value.
					if (!(IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("SerialNumber").Ordinal))))
						strSerialNo = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("SerialNumber").Ordinal);
					//16.6.2010 by dinesh wagh only Null is check before assinging value.
					if (!(IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("CheckedBy").Ordinal))))
						strCheckedBy = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("CheckedBy").Ordinal);
					//16.6.2010 by dinesh wagh only Null is check before assinging value.
					if (!(IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("VerifiedBy").Ordinal))))
						strVerifiedBy = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("VerifiedBy").Ordinal);
					//16.6.2010 by dinesh wagh only Null is check before assinging value.
					status = gobjDataAccess.funcInsertOQEquipmentListData(strEquipmentName, strSerialNo, strCheckedBy, strVerifiedBy, 1);
					if (!(status)) {
						throw new Exception("Error in Saving Equipment List Details.");
					}
				} else {
					if (IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("EquipmentName").Ordinal)) | IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("SerialNumber").Ordinal)) | IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("CheckedBy").Ordinal)) | IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("VerifiedBy").Ordinal))) {
						intEquipmentID = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("EquipmentID").Ordinal);
						status = gobjDataAccess.funcDeleteOQEquipmentListData(intEquipmentID, 1);
						if (!(status)) {
							throw new Exception("Error in Deleting Equipment List Details.");
						}
					} else {
						intEquipmentID = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("EquipmentID").Ordinal);
						strEquipmentName = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("EquipmentName").Ordinal);
						strEquipmentName = strEquipmentName.Replace(vbCrLf, " ");
						//29.6.2010 by dinesh wagh
						strSerialNo = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("SerialNumber").Ordinal);
						strSerialNo = strSerialNo.Replace(vbCrLf, " ");
						//29.6.2010 by dinesh wagh
						strCheckedBy = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("CheckedBy").Ordinal);
						strCheckedBy = strCheckedBy.Replace(vbCrLf, " ");
						//29.6.2010 by dinesh wagh
						strVerifiedBy = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("VerifiedBy").Ordinal);
						strVerifiedBy = strVerifiedBy.Replace(vbCrLf, " ");
						//29.6.2010 by dinesh wagh
						status = gobjDataAccess.funcUpdateOQEquipmentListData(strEquipmentName, strSerialNo, strCheckedBy, strVerifiedBy, intEquipmentID, 1);
						if (!(status)) {
							throw new Exception("Error in Updating Equipment List Details.");
						}
					}
				}
			}
		//---------------------------------------------
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
	//Private Function funcInsertIQEquipmentListData(ByVal strEquipmentName As String, ByVal strSerialNumber As String) As Boolean
	//    '=====================================================================
	//    ' Procedure Name        :   funcInsertIQEquipmentListData
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
	//        Status = mclsDBFunctions.OpenConnection(mobjOleDBconnection)
	//        If Not (Status) Then
	//            Throw New Exception("Error in Opening Connection during Saving Equipment List Details.")
	//        End If

	//        '--- Generating Next Equipment ID. 
	//        intEquipmentID = mclsDBFunctions.GetNextID("EquipmentList", "EquipmentListID", mobjOleDBconnection)

	//        '---  Query for adding  data to EquipmentList
	//        str_sql = " Insert into EquipmentList " & _
	//                  " (EquipmentListID ,Name ,SerialNo ,CheckStatusIQOQPQ) " & _
	//                  " values(?,?,?,?) "

	//        '--- Providing command object for EquimentList
	//        With objCommand
	//            .Connection = mobjOleDBconnection
	//            .CommandType = CommandType.Text
	//            .CommandText = str_sql
	//            .Parameters.Add("EquipmentListID", OleDbType.Numeric).Value = intEquipmentID
	//            .Parameters.Add("Name", OleDbType.VarChar, 50).Value = strEquipmentName
	//            .Parameters.Add("SerialNo", OleDbType.VarChar, 50).Value = strSerialNumber
	//.Parameters.Add("CheckStatusIQOQPQ", OleDbType.Single).Value = CSng(ENUM_IQOQPQ_STATUS.IQ)
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

	//Private Function funcUpdateIQEquipmentListData(ByVal strEquipmentName As String, ByVal strSerialNumber As String, ByVal intEquipmentID As Integer) As Boolean
	//    '=====================================================================
	//    ' Procedure Name        :   funcUpdateIQEquipmentListData
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
	//        Status = mclsDBFunctions.OpenConnection(mobjOleDBconnection)
	//        If Not (Status) Then
	//            Throw New Exception("Error in Opening Connection during Updating Equipment List Details.")
	//        End If

	//        '---  Query for adding  data to EquipmentList
	//        str_sql = " Update EquipmentList " & _
	//                  " Set Name = ? ,SerialNo = ? " & _
	//                  " where EquipmentListID = " & intEquipmentID & " and CheckStatusIQOQPQ = 1  "

	//        '--- Providing command object for EquimentList
	//        With objCommand
	//            .Connection = mobjOleDBconnection
	//            .CommandType = CommandType.Text
	//            .CommandText = str_sql
	//            .Parameters.Add("Name", OleDbType.VarChar, 250).Value = strEquipmentName
	//            .Parameters.Add("SerialNo", OleDbType.VarChar, 250).Value = strSerialNumber
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

	//Private Function funcDeleteIQEquipmentListData(ByVal intEquipmentID As Integer) As Boolean
	//    '=====================================================================
	//    ' Procedure Name        :   funcDeleteIQEquipmentListData
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
	//        Status = mclsDBFunctions.OpenConnection(mobjOleDBconnection)
	//        If Not (Status) Then
	//            Throw New Exception("Error in Opening Connection during Deleting Equipment List Details.")
	//        End If

	//        '--- Query to Delete from Database
	//        str_sql = " Delete * from EquipmentList " & _
	//                  " where EquipmentListID = " & intEquipmentID & " and CheckStatusIQOQPQ = 1  "

	//        Status = mclsDBFunctions.AddORDeleteRecord(str_sql, mobjOleDBconnection)
	//        If (Status = False) Then
	//            Throw New Exception("Error in Deleting Equipment List Details.")
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

	private void  // ERROR: Handles clauses are not supported in C#
dgEquipmentList_CurrentCellChanged(object sender, System.EventArgs e)
	{
		//try catch added by ; dinesh wagh on 3.2.2010

		int intWidth;
		DataView objDV;


		try {
			mObjDataTable.Columns(0).ReadOnly = false;
			if (mObjDataTable.Rows.Count == 0) {
				mObjDataTable.Columns(0).DefaultValue = 1;
			} else {
				dgEquipmentList.Item(dgEquipmentList.CurrentRowIndex, 0) = dgEquipmentList.CurrentRowIndex + 1;
			}

			mObjDataTable.Columns(0).ReadOnly = true;

			if (dgEquipmentList.CurrentRowIndex >= 10) {
				objDataView.AllowNew = false;
			}

			//-------3.2.2010    by dinesh wagh
			if (mObjDataTable.Rows.Count == 0 & dgEquipmentList.CurrentRowIndex != -1) {
				dgEquipmentList.Item(0, 0) = 1;
			}
			//-------------

			//--- 30.6.2010 by dinesh wagh
			objDV = dgEquipmentList.DataSource;

			switch (mintColumnIndex) {
				case EnumColumns.Model:
					intWidth = CONST_ModelColumnSize;
				case EnumColumns.InstSrNo:
					intWidth = CONST_InstSrNoColumnSize;
				case EnumColumns.CheckedBy:
					intWidth = CONST_CheckedByColumnSize;
				case EnumColumns.VerifiedBy:
					intWidth = CONST_VerifiedByColumnSize;
			}

			if (objDV.Count > 0 & objDV.Count > mintRowIndex) {
				if (mintColumnIndex != 0) {
					if (!IsDBNull(objDV(mintRowIndex).Row(mintColumnIndex))) {
						objDV(mintRowIndex).Row(mintColumnIndex) = gfuncWordWrap(objDV(mintRowIndex).Row(mintColumnIndex), intWidth);
						dgEquipmentList.DataSource = objDV;
					}
				}
			}
			mintRowIndex = dgEquipmentList.CurrentCell.RowNumber;
			mintColumnIndex = dgEquipmentList.CurrentCell.ColumnNumber;
		//-------




		//If IsDBNull(mObjDataTable.Rows(dgEquipmentList.CurrentRowIndex + 1).Item(1)) And _
		// IsDBNull(mObjDataTable.Rows(dgEquipmentList.CurrentRowIndex + 1).Item(2)) Then
		//    mObjDataTable.Rows(dgEquipmentList.CurrentRowIndex + 1).Item(0) = Nothing
		//End If

		} catch (Exception ex) {
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.ProcessError(ErrorHandler.ErrorHandler.EnumErrorType.Critical, ex);
		} finally {
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
		}

	}

	private void  // ERROR: Handles clauses are not supported in C#
cmbModelList_SelectedIndexChanged(System.Object sender, System.EventArgs e)
	{
		//try catch added by ; dinesh wagh on 3.2.2010
		try {
			gobjModelNo = cmbModelList.Text.ToString();
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
