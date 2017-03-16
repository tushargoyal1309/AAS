
using System.Data;
using System.Data.OleDb;
using ErrorHandler.ErrorHandler;

public class frmIQSpecification : System.Windows.Forms.Form
{

	#Region " Module level Declarations "
	private bool mblnModeLockStatus;
	private string mstrOledbConnectionString;
	private OleDbConnection mobjOleDBconnection;
	//Public mclsDBFunctions As New clsDatabaseFunctions
	private DataView mobjSpecificationDataView = new DataView();
	private DataView mobjAccessoryDataView = new DataView();
	private DataTable mObjDataTable;
	private DataTable mobjACDataTable;
	 mobjGridTableStyle;

	DataGridTableStyle mobjACGridTableStyle = new DataGridTableStyle();

	//30.6.2010 by dinesh wagh
	//----------------------------------------------
	int mintRowIndexInst;
	int mintColumnIndexInst;
	int mintRowIndexAccessory;
	int mintColumnIndexAccessory;
	private const  CONST_InstrumentTable_EquipmentName_Size = 20;
	private const  CONST_InstrumentTable_Manufacture_Size = 16;
	private const  CONST_AccessoryTable_Accessories_Size = 27;
	private const  CONST_AccessoryTable_Manufacturer_Size = 25;
	private enum EnumColumnsInstrument
	{
		EquipmentName = 1,
		Manufacture = 2
	}
	private enum EnumColumnsAccessory
	{
		Accessories = 1,
		Manufacturer = 2
	}
	//--------------------------



	#End Region

	#Region " Windows Form Designer generated code "

	public frmIQSpecification()
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
	internal System.Windows.Forms.Label lblAccessory;
	internal System.Windows.Forms.Label lblSpecification;
	internal System.Windows.Forms.Panel Panel1;
	internal System.Windows.Forms.DataGrid dgSpecification;
	internal System.Windows.Forms.DataGrid dgAccessory;
	internal System.Windows.Forms.Panel Panel2;
	internal System.Windows.Forms.PictureBox PictureBox1;
	internal System.Windows.Forms.Label Label1;
	internal System.Windows.Forms.Label lblModelNo;
	[System.Diagnostics.DebuggerStepThrough()]
	private void InitializeComponent()
	{
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmIQSpecification));
		this.lblAccessory = new System.Windows.Forms.Label();
		this.lblSpecification = new System.Windows.Forms.Label();
		this.Panel1 = new System.Windows.Forms.Panel();
		this.lblModelNo = new System.Windows.Forms.Label();
		this.Label1 = new System.Windows.Forms.Label();
		this.Panel2 = new System.Windows.Forms.Panel();
		this.PictureBox1 = new System.Windows.Forms.PictureBox();
		this.dgAccessory = new System.Windows.Forms.DataGrid();
		this.dgSpecification = new System.Windows.Forms.DataGrid();
		this.Panel1.SuspendLayout();
		this.Panel2.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.dgAccessory).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dgSpecification).BeginInit();
		this.SuspendLayout();
		//
		//lblAccessory
		//
		this.lblAccessory.BackColor = System.Drawing.Color.AliceBlue;
		this.lblAccessory.Font = new System.Drawing.Font("Arial", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblAccessory.Location = new System.Drawing.Point(8, 255);
		this.lblAccessory.Name = "lblAccessory";
		this.lblAccessory.Size = new System.Drawing.Size(504, 18);
		this.lblAccessory.TabIndex = 12;
		this.lblAccessory.Text = "Accessory to above Equipment/Instrument:";
		this.lblAccessory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//lblSpecification
		//
		this.lblSpecification.BackColor = System.Drawing.Color.AliceBlue;
		this.lblSpecification.Font = new System.Drawing.Font("Arial", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblSpecification.Location = new System.Drawing.Point(35, 7);
		this.lblSpecification.Name = "lblSpecification";
		this.lblSpecification.Size = new System.Drawing.Size(528, 18);
		this.lblSpecification.TabIndex = 11;
		this.lblSpecification.Text = "C.I  INSTRUMENT DETAILS";
		this.lblSpecification.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//Panel1
		//
		this.Panel1.BackColor = System.Drawing.Color.AliceBlue;
		this.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.Panel1.Controls.Add(this.lblModelNo);
		this.Panel1.Controls.Add(this.Label1);
		this.Panel1.Controls.Add(this.lblSpecification);
		this.Panel1.Controls.Add(this.Panel2);
		this.Panel1.Controls.Add(this.dgAccessory);
		this.Panel1.Controls.Add(this.dgSpecification);
		this.Panel1.Controls.Add(this.lblAccessory);
		this.Panel1.Dock = System.Windows.Forms.DockStyle.Top;
		this.Panel1.Location = new System.Drawing.Point(0, 0);
		this.Panel1.Name = "Panel1";
		this.Panel1.Size = new System.Drawing.Size(422, 456);
		this.Panel1.TabIndex = 12;
		//
		//lblModelNo
		//
		this.lblModelNo.Font = new System.Drawing.Font("Times New Roman", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblModelNo.Location = new System.Drawing.Point(200, 39);
		this.lblModelNo.Name = "lblModelNo";
		this.lblModelNo.Size = new System.Drawing.Size(104, 32);
		this.lblModelNo.TabIndex = 22;
		//
		//Label1
		//
		this.Label1.Font = new System.Drawing.Font("Times New Roman", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.Label1.Location = new System.Drawing.Point(8, 40);
		this.Label1.Name = "Label1";
		this.Label1.Size = new System.Drawing.Size(200, 32);
		this.Label1.TabIndex = 21;
		this.Label1.Text = "Identification  :  Thermo  -";
		//
		//Panel2
		//
		this.Panel2.BackColor = System.Drawing.Color.AliceBlue;
		this.Panel2.Controls.Add(this.PictureBox1);
		this.Panel2.Dock = System.Windows.Forms.DockStyle.Top;
		this.Panel2.Location = new System.Drawing.Point(0, 0);
		this.Panel2.Name = "Panel2";
		this.Panel2.Size = new System.Drawing.Size(420, 32);
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
		//dgAccessory
		//
		this.dgAccessory.AlternatingBackColor = System.Drawing.Color.AliceBlue;
		this.dgAccessory.BackColor = System.Drawing.Color.AliceBlue;
		this.dgAccessory.BackgroundColor = System.Drawing.Color.AliceBlue;
		this.dgAccessory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.dgAccessory.CaptionVisible = false;
		this.dgAccessory.DataMember = "";
		this.dgAccessory.HeaderBackColor = System.Drawing.Color.LightSkyBlue;
		this.dgAccessory.HeaderForeColor = System.Drawing.SystemColors.ControlText;
		this.dgAccessory.Location = new System.Drawing.Point(8, 283);
		this.dgAccessory.Name = "dgAccessory";
		this.dgAccessory.ParentRowsBackColor = System.Drawing.Color.AliceBlue;
		this.dgAccessory.ParentRowsVisible = false;
		this.dgAccessory.ReadOnly = true;
		this.dgAccessory.RowHeadersVisible = false;
		this.dgAccessory.Size = new System.Drawing.Size(576, 168);
		this.dgAccessory.TabIndex = 19;
		//
		//dgSpecification
		//
		this.dgSpecification.BackgroundColor = System.Drawing.Color.AliceBlue;
		this.dgSpecification.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.dgSpecification.CaptionVisible = false;
		this.dgSpecification.DataMember = "";
		this.dgSpecification.HeaderForeColor = System.Drawing.SystemColors.ControlText;
		this.dgSpecification.Location = new System.Drawing.Point(8, 75);
		this.dgSpecification.Name = "dgSpecification";
		this.dgSpecification.ParentRowsVisible = false;
		this.dgSpecification.ReadOnly = true;
		this.dgSpecification.RowHeadersVisible = false;
		this.dgSpecification.Size = new System.Drawing.Size(576, 168);
		this.dgSpecification.TabIndex = 18;
		//
		//frmIQSpecification
		//
		this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
		this.AutoScroll = true;
		this.BackColor = System.Drawing.Color.AliceBlue;
		this.ClientSize = new System.Drawing.Size(422, 370);
		this.ControlBox = false;
		this.Controls.Add(this.Panel1);
		this.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		this.MaximizeBox = false;
		this.MinimizeBox = false;
		this.Name = "frmIQSpecification";
		this.Tag = "5";
		this.Text = "Specification Of Instrument";
		this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
		this.Panel1.ResumeLayout(false);
		this.Panel2.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.dgAccessory).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dgSpecification).EndInit();
		this.ResumeLayout(false);

	}

	#End Region

	#Region "Constants"

	private const string ConstSrNo = "SrNo";
	private const string ConstIQEquipmentName = "IQEquipmentName";
	private const string ConstIQManufacturer = "IQManufacturer";
	private const string ConstIQSerialNo = "IQSerialNo";
	private const string ConstIQSize = "IQSize";
	private const string ConstIQMainpowerSupply = "IQMainpowerSupply";

	private const string ConstIQSpecificationID = "IQSpecificationID";
	private const string ConstName = "Name";
	private const string ConstManufacturer = "Manufacturer";
	private const string ConstSerialNo = "SerialNo";
	private const string ConstSpecification = "Specification";

	private const string ConstIQAccessoryID = "IQAccessoryID";
	#End Region

	#Region " Form Events "

	private void  // ERROR: Handles clauses are not supported in C#
frmIQSpecification_Load(object sender, System.EventArgs e)
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
frmIQSpecification_Closing(object sender, System.ComponentModel.CancelEventArgs e)
	{
		try {
			if (!(mblnModeLockStatus)) {
				dgSpecification.CurrentCell() = (new DataGridCell(dgSpecification.CurrentRowIndex + 1, 0));
				if (!funcSaveIQSpecificationData()) {
					throw new Exception("Error in Saving IQ Specification Data.");
				}
				dgSpecification.TableStyles.Clear();

				dgAccessory.CurrentCell() = (new DataGridCell(dgAccessory.CurrentRowIndex + 1, 0));
				if (!funcSaveIQAccessoryData()) {
					throw new Exception("Error in Saving IQ Accessory Data.");
				}
				dgAccessory.TableStyles.Clear();
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
	//--- funcInitialize - To Initialize form and to get values for IQ Specification and Accessory Data from database and display them.
	//--- subCreateSpecificationDataTable - To Create Columns in the Data Table.
	//--- funcGetIQSpecificationRecords - To Get IQ Specification Records from Database into DataTable.
	//--- subFormatSpecificationDataGrid - To format the Specification Data Grid.
	//--- funcSaveIQSpecificationData - To Save the Entered Records into Database.
	//--- funcInsertIQSpecificationData - To Add/Insert New Specification Data in Database.
	//--- funcUpdateIQSpecificationData - To Update Specification Data in Database.
	//--- funcDeleteIQSpecificationData - To Delete Specification Data from Database.

	//--- subCreateAccessoryDataTable - To Create Columns in the Data Table.
	//--- funcGetIQAccessoryRecords - To Get IQ Accessory Records from Database into DataTable.
	//--- subFormatAccessoryDataGrid - To format the Accessory Data Grid.
	//--- funcSaveIQAccessoryData - To Save the Entered Records into Database.
	//--- funcInsertIQAccessoryData - To Add/Insert New Accessory Data in Database.
	//--- funcUpdateIQAccessoryData - To Update Accessory Data in Database.
	//--- funcDeleteIQAccessoryData - To Delete Accessory Data from Database.

	private void funcInitialize()
	{
		//=====================================================================
		// Procedure Name        :   funcInitailize
		// Description           :   To Initialize form and to get values for IQ Specification and Accessory Data from database and display them.
		// Purpose               :   To Initialize form and to get values for IQ Specification and Accessory Data from database and display them.
		// Parameters Passed     :   None.
		// Returns               :   None.
		// Parameters Affected   :   None.
		// Assumptions           :
		// Dependencies          :
		// Author                :   Gitesh
		// Created               :   January, 2003 
		// Revisions             :
		//=====================================================================

		DataTable objDtTmp;
		DataRow objDataRow;
		int intCount;

		try {
			//mfrmSpecification = Me
			//Added By Pankaj on Sat 19 May 07 3:24 
			lblModelNo.Text = gobjModelNo.ToString();
			//----------
			mObjDataTable = new DataTable("IQSpecification");

			//mObjDataTable.Columns.Add("SrNo")
			//mObjDataTable.Columns.Add("IQEquipmentName")
			//mObjDataTable.Columns.Add("IQManufacturer")
			//mObjDataTable.Columns.Add("IQSerialNo")
			//mObjDataTable.Columns.Add("IQSize")
			//mObjDataTable.Columns.Add("IQMainpowerSupply")
			//mObjDataTable.Columns.Add("IQSpecificationID")

			mobjACDataTable = new DataTable("IQAccessory");

			//mobjACDataTable.Columns.Add("SrNo")
			//mobjACDataTable.Columns.Add("Name")
			//mobjACDataTable.Columns.Add("Manufacturer")
			//mobjACDataTable.Columns.Add("SerialNo")
			//mobjACDataTable.Columns.Add("Specification")
			//mobjACDataTable.Columns.Add("IQAccessoryID")

			subCreateSpecificationDataTable();

			objDtTmp = new DataTable();

			objDtTmp = gobjDataAccess.funcGetIQSpecificationRecords();

			if (!objDtTmp == null) {
				if (!objDtTmp.Rows.Count == 0) {
					for (intCount = 0; intCount <= objDtTmp.Rows.Count - 1; intCount++) {
						objDataRow = mObjDataTable.NewRow;
						objDataRow.Item(ConstSrNo) = intCount + 1;
						//by pankaj on 6 Dec 07'CInt(objDtTmp.Rows.Item(intCount).Item("IQSpecificationID"))
						objDataRow.Item(ConstIQEquipmentName) = gfuncWordWrap((string)objDtTmp.Rows.Item(intCount).Item("IQEquipmentName"), CONST_InstrumentTable_EquipmentName_Size);
						//24.6.2010 by dinesh wagh
						objDataRow.Item(ConstIQManufacturer) = gfuncWordWrap((string)objDtTmp.Rows.Item(intCount).Item("IQManufacturer"), CONST_InstrumentTable_Manufacture_Size);
						//24.6.2010 by dinesh wagh
						objDataRow.Item(ConstIQSerialNo) = (string)objDtTmp.Rows.Item(intCount).Item("IQSerialNo");
						objDataRow.Item(ConstIQSize) = (string)objDtTmp.Rows.Item(intCount).Item("IQSize");
						objDataRow.Item(ConstIQMainpowerSupply) = (string)objDtTmp.Rows.Item(intCount).Item("IQMainpowerSupply");
						objDataRow.Item(ConstIQSpecificationID) = (int)objDtTmp.Rows.Item(intCount).Item("IQSpecificationID");
						mObjDataTable.Rows.Add(objDataRow);

					}
				}
			}


			if (IsNothing(mObjDataTable) == true) {
				throw new Exception("Error in Getting IQ Specification Records.");
			} else {
				subFormatSpecificationDataGrid();
			}


			//If funcGetIQSpecificationRecords() Then
			//    subFormatSpecificationDataGrid()
			//Else
			//    Throw New Exception("Error in Getting IQ Specification Records.")
			//End If

			subCreateAccessoryDataTable();

			objDtTmp = new DataTable();

			objDtTmp = gobjDataAccess.funcGetIQAccessoryRecords();

			if (!objDtTmp == null) {
				if (!objDtTmp.Rows.Count == 0) {
					for (intCount = 0; intCount <= objDtTmp.Rows.Count - 1; intCount++) {
						objDataRow = mobjACDataTable.NewRow;
						objDataRow.Item(ConstSrNo) = (int)objDtTmp.Rows.Item(intCount).Item("IQAccessoryID");
						objDataRow.Item(ConstName) = gfuncWordWrap((string)objDtTmp.Rows.Item(intCount).Item("Name"), CONST_AccessoryTable_Accessories_Size);
						//by dinesh wagh on 25.6.2010
						objDataRow.Item(ConstManufacturer) = gfuncWordWrap((string)objDtTmp.Rows.Item(intCount).Item("Manufacturer"), CONST_AccessoryTable_Manufacturer_Size);
						//by dinesh wagh on 25.6.2010
						objDataRow.Item(ConstSerialNo) = (string)objDtTmp.Rows.Item(intCount).Item("SerialNo");
						objDataRow.Item(ConstSpecification) = (string)objDtTmp.Rows.Item(intCount).Item("Specification");
						objDataRow.Item(ConstIQAccessoryID) = (int)objDtTmp.Rows.Item(intCount).Item("IQAccessoryID");
						mobjACDataTable.Rows.Add(objDataRow);
					}
				}
			}


			if (IsNothing(mobjACDataTable) == true) {
				throw new Exception("Error in Getting IQ Accessory Records.");
			} else {
				subFormatAccessoryDataGrid();
			}


			//If funcGetIQAccessoryRecords() Then
			//    subFormatAccessoryDataGrid()
			//Else
			//    Throw New Exception("Error in Getting IQ Accessory Records.")
			//End If
			mblnModeLockStatus = gobjDataAccess.funcCheckModeLocked(ENUM_IQOQPQ_STATUS.IQ);
			if ((mblnModeLockStatus)) {
				dgSpecification.ReadOnly = true;
				dgAccessory.ReadOnly = true;
			} else {
				dgSpecification.ReadOnly = false;
				dgAccessory.ReadOnly = false;
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

	#Region "IQ Specification Functions"

	private void subCreateSpecificationDataTable()
	{
		//=====================================================================
		// Procedure Name        :   subCreateSpecificationDataTable
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
			mObjDataTable.Columns.Add(objDataColumn);

			mObjDataTable.Columns.Add(new DataColumn("IQEquipmentName", typeof(string)));
			mObjDataTable.Columns.Add(new DataColumn("IQManufacturer", typeof(string)));
			mObjDataTable.Columns.Add(new DataColumn("IQSerialNo", typeof(string)));
			mObjDataTable.Columns.Add(new DataColumn("IQSize", typeof(string)));
			mObjDataTable.Columns.Add(new DataColumn("IQMainpowerSupply", typeof(string)));
			mObjDataTable.Columns.Add(new DataColumn("IQSpecificationID", typeof(int)));
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = "Error in Creating IQ Specification Data-Table.";
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

	//Private Function funcGetIQSpecificationRecords() As Boolean
	//    '=====================================================================
	//    ' Procedure Name        :   funcGetIQSpecificationRecords
	//    ' Description           :   To Get IQ Specification Records from Database into DataTable.
	//    ' Purpose               :   To Get IQ Specification Records from Database into DataTable.
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
	//        '--- Initialising Connection 
	//        'mobjOleDBconnection = New OleDbConnection(mstrOledbConnectionString)

	//        sql_string = "Select IQSpecificationID ,IQEquipmentName ,IQManufacturer , IQSerialNo ,IQSize ,IQMainpowerSupply " & _
	//                     "from IQSpecification "

	//        'sql_string = " Select IQAccessoryID ,Name ,Manufacturer ,SerialNo ,Specification from IQAccessory "

	//        'mclsDBFunctions.OpenConnection(mobjOleDBconnection)

	//        'reader_status = mclsDBFunctions.GetRecords(sql_string, mobjOleDBconnection, objReader)

	//        If Not (reader_status) Then
	//            Throw New Exception("Error in Opening Connection during Getting IQ Specification Details.")
	//        End If

	//        rec_cnt = 1
	//        While objReader.Read
	//            objDataRow = mObjDataTable.NewRow()
	//            objDataRow("SrNo") = rec_cnt
	//            objDataRow("IQEquipmentName") = CStr(objReader.Item("IQEquipmentName"))
	//            objDataRow("IQManufacturer") = CStr(objReader.Item("IQManufacturer"))
	//            objDataRow("IQSerialNo") = CStr(objReader.Item("IQSerialNo"))
	//            objDataRow("IQSize") = CStr(objReader.Item("IQSize"))
	//            objDataRow("IQMainpowerSupply") = CStr(objReader.Item("IQMainpowerSupply"))
	//            objDataRow("IQSpecificationID") = Convert.ToInt32(objReader.Item("IQSpecificationID"))

	//            mObjDataTable.Rows.Add(objDataRow)
	//            rec_cnt = rec_cnt + 1
	//        End While
	//        objReader.Close()
	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        'Error logging
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = "Error in Getting IQ Specification Records."
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

	private void subFormatSpecificationDataGrid()
	{
		DataGridTextBoxColumn objTextColumn;

		try {
			dgSpecification.TableStyles.Clear();
			mobjSpecificationDataView.Table = mObjDataTable;
			mobjSpecificationDataView.AllowNew = true;
			dgSpecification.DataSource = mobjSpecificationDataView;


			//dgSpecification.ReadOnly = False

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
			//9.7.2010 by dinesh wagh


			mobjGridTableStyle.MappingName = "IQSpecification";
			objTextColumn = new DataGridTextBoxColumn();
			objTextColumn.MappingName = "SrNo";
			objTextColumn.HeaderText = "Sr.No.";
			objTextColumn.Width = 40;
			objTextColumn.ReadOnly = true;
			objTextColumn.NullText = "";
			objTextColumn.Alignment = HorizontalAlignment.Center;
			mobjGridTableStyle.GridColumnStyles.Add(objTextColumn);

			objTextColumn = new DataGridTextBoxColumn();
			objTextColumn.MappingName = "IQEquipmentName";
			objTextColumn.HeaderText = "Equipment Name";
			//objTextColumn.Width = 160 'code commented by ; dinesh wagh on 25.2.2010
			objTextColumn.Width = 118;
			objTextColumn.TextBox.WordWrap = true;
			//24.6.2010 by dinesh wagh to show text word wrap.
			objTextColumn.ReadOnly = false;
			objTextColumn.NullText = "";
			mobjGridTableStyle.GridColumnStyles.Add(objTextColumn);

			objTextColumn = new DataGridTextBoxColumn();
			objTextColumn.MappingName = "IQManufacturer";
			objTextColumn.HeaderText = "Manufacturer";
			//objTextColumn.Width = 150 'code commented by ; dinesh wagh on 25.2.2010
			objTextColumn.Width = 108;
			objTextColumn.TextBox.WordWrap = true;
			//24.6.2010 by dinesh wagh to show text word wrap.
			objTextColumn.ReadOnly = false;
			objTextColumn.NullText = "";
			mobjGridTableStyle.GridColumnStyles.Add(objTextColumn);

			objTextColumn = new DataGridTextBoxColumn();
			objTextColumn.MappingName = "IQSerialNo";
			objTextColumn.HeaderText = "Serial No";
			objTextColumn.Width = 60;
			objTextColumn.ReadOnly = false;
			objTextColumn.NullText = "";
			objTextColumn.Alignment = HorizontalAlignment.Center;
			mobjGridTableStyle.GridColumnStyles.Add(objTextColumn);

			objTextColumn = new DataGridTextBoxColumn();
			objTextColumn.MappingName = "IQSize";
			objTextColumn.HeaderText = "Size";
			//objTextColumn.Width = 50 'code commented by ; dinesh wagh on 25.2.2010
			objTextColumn.Width = 128;
			//code added by ; dinesh wagh on 25.2.2010
			objTextColumn.ReadOnly = false;
			objTextColumn.NullText = "";
			objTextColumn.Alignment = HorizontalAlignment.Center;
			mobjGridTableStyle.GridColumnStyles.Add(objTextColumn);

			objTextColumn = new DataGridTextBoxColumn();
			objTextColumn.MappingName = "IQMainpowerSupply";
			objTextColumn.HeaderText = "Mains Power Supply";
			objTextColumn.Width = 118;
			objTextColumn.ReadOnly = false;
			objTextColumn.NullText = "";
			mobjGridTableStyle.GridColumnStyles.Add(objTextColumn);

			objTextColumn = new DataGridTextBoxColumn();
			objTextColumn.MappingName = "IQSpecificationID";
			objTextColumn.HeaderText = "SpecificationID";
			objTextColumn.Width = 0;
			objTextColumn.ReadOnly = true;
			objTextColumn.NullText = "";
			mobjGridTableStyle.GridColumnStyles.Add(objTextColumn);

			mobjGridTableStyle.GridLineColor = Color.Black;
			dgSpecification.TableStyles.Add(mobjGridTableStyle);
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = "Error in Formating IQ Specification Data-Grid.";
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

	public bool funcSaveIQSpecificationData()
	{
		//=====================================================================
		// Procedure Name        :   funcSaveIQSpecificationData
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
		int intSpecificationID;
		int temp_cnt;
		string strEquipmentName;
		string strManufacturer;
		string strSerialNo;
		string strSize;
		string strMainPowerSupply;
		bool status = true;


		try {
			intRecordCount = mObjDataTable.Rows.Count;

			for (temp_cnt = 0; temp_cnt <= intRecordCount - 1; temp_cnt++) {
				//--- To Check if Specification ID is Null.
				if (IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("IQSpecificationID").Ordinal))) {
					//If IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("IQEquipmentName").Ordinal)) = False Then
					strEquipmentName = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("IQEquipmentName").Ordinal);
					//End If

					strEquipmentName = strEquipmentName.Replace(vbCrLf, " ");
					//24.6.2010 by dinesh wagh
					strManufacturer = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("IQManufacturer").Ordinal);
					strManufacturer = strManufacturer.Replace(vbCrLf, " ");
					//24.6.2010 by dinesh wagh
					//If IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("IQSerialNo").Ordinal)) = False Then
					strSerialNo = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("IQSerialNo").Ordinal);
					//End If

					//If IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("IQSize").Ordinal)) = False Then
					strSize = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("IQSize").Ordinal);
					//End If

					//If IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("IQMainpowerSupply").Ordinal)) = False Then
					strMainPowerSupply = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("IQMainpowerSupply").Ordinal);
					//End If

					status = gobjDataAccess.funcInsertIQSpecificationData(strEquipmentName, strManufacturer, strSerialNo, strSize, strMainPowerSupply);
					if (!(status)) {
						throw new Exception("Error in Saving IQ Specification Details.");
					}
				} else {
					if (IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("IQEquipmentName").Ordinal)) | IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("IQManufacturer").Ordinal)) | IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("IQSerialNo").Ordinal)) | IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("IQSize").Ordinal)) | IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("IQMainpowerSupply").Ordinal))) {
						intSpecificationID = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("IQSpecificationID").Ordinal);
						status = gobjDataAccess.funcDeleteIQSpecificationData(intSpecificationID);
						if (!(status)) {
							throw new Exception("Error in Deleting Manual List Details.");
						}

					} else {
						intSpecificationID = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("IQSpecificationID").Ordinal);
						strEquipmentName = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("IQEquipmentName").Ordinal);
						strEquipmentName = strEquipmentName.Replace(vbCrLf, " ");
						//24.6.2010 by dinesh wagh
						strManufacturer = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("IQManufacturer").Ordinal);
						strManufacturer = strManufacturer.Replace(vbCrLf, " ");
						//24.6.2010 by dinesh wagh
						strSerialNo = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("IQSerialNo").Ordinal);
						strSize = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("IQSize").Ordinal);
						strMainPowerSupply = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("IQMainpowerSupply").Ordinal);

						status = gobjDataAccess.funcUpdateIQSpecificationData(strEquipmentName, strManufacturer, strSerialNo, strSize, strMainPowerSupply, intSpecificationID);
						if (!(status)) {
							throw new Exception("Error in Updating IQ Specification Details.");
						}
					}
				}
			}
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = "Error in Saving IQ Specification Details.";
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

	//Private Function funcInsertIQSpecificationData(ByVal strEquipmentName As String, ByVal strManufacturer As String, ByVal strSerialNo As String, ByVal strSize As String, ByVal strMainPowerSupply As String) As Boolean
	//    '=====================================================================
	//    ' Procedure Name        :   funcInsertIQSpecificationData
	//    ' Description           :   To Add/Insert New Specification Data in Database.
	//    ' Purpose               :   To Add/Insert New Specification Data in Database.
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
	//    Dim intSpecificationID As Integer

	//    Try
	//        'Status = mclsDBFunctions.OpenConnection(mobjOleDBconnection)
	//        If Not (Status) Then
	//            Throw New Exception("Error in Opening Connection during Saving IQ Specification Details.")
	//        End If

	//        '--- Generating Next Equipment ID. 
	//        'intSpecificationID = mclsDBFunctions.GetNextID("IQSpecification", "IQSpecificationID", mobjOleDBconnection)

	//        '---  Query for adding  data to EquipmentList
	//        str_sql = " Insert into IQSpecification " & _
	//                  " (IQSpecificationID, IQEquipmentName ,IQManufacturer ,IQSerialNo ,IQSize ,IQMainpowerSupply) " & _
	//                  " values(?,?,?,?,?,?) "

	//        '--- Providing command object. 
	//        With objCommand
	//            .Connection = mobjOleDBconnection
	//            .CommandType = CommandType.Text
	//            .CommandText = str_sql
	//            .Parameters.Add("IQSpecificationID", OleDbType.Numeric).Value = intSpecificationID
	//            .Parameters.Add("IQEquipmentName", OleDbType.VarChar, 50).Value = strEquipmentName
	//            .Parameters.Add("IQManufacturer", OleDbType.VarChar, 50).Value = strManufacturer
	//            .Parameters.Add("IQSerialNo", OleDbType.VarChar, 50).Value = strSerialNo
	//            .Parameters.Add("IQSize", OleDbType.VarChar, 50).Value = strSize
	//            .Parameters.Add("IQMainpowerSupply", OleDbType.VarChar, 50).Value = strMainPowerSupply
	//            .ExecuteNonQuery()
	//        End With

	//        objCommand.Dispose()
	//        Status = True

	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        '--- Error logging
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = "Error in Saving IQ Specification Details."
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

	//Private Function funcUpdateIQSpecificationData(ByVal strEquipmentName As String, ByVal strManufacturer As String, ByVal strSerialNo As String, ByVal strSize As String, ByVal strMainPowerSupply As String, ByVal intSpecificationID As Integer) As Boolean
	//    '=====================================================================
	//    ' Procedure Name        :   funcUpdateIQSpecificationData
	//    ' Description           :   To Update Specification Data in Database.
	//    ' Purpose               :   To Update Specification Data in Database.
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
	//            Throw New Exception("Error in Opening Connection during Updating IQ Specification Details.")
	//        End If

	//        '---  Query for adding  data to EquipmentList
	//        str_sql = " Update IQSpecification " & _
	//                  " Set IQEquipmentName = ? ,IQManufacturer = ? ,IQSerialNo = ? ,IQSize = ? ,IQMainpowerSupply = ? " & _
	//                  " where IQSpecificationID = " & intSpecificationID & "  "

	//        '--- Providing command object for EquimentList
	//        With objCommand
	//            .Connection = mobjOleDBconnection
	//            .CommandType = CommandType.Text
	//            .CommandText = str_sql
	//            .Parameters.Add("IQEquipmentName", OleDbType.VarChar, 250).Value = strEquipmentName
	//            .Parameters.Add("IQManufacturer", OleDbType.VarChar, 250).Value = strManufacturer
	//            .Parameters.Add("IQSerialNo", OleDbType.VarChar, 250).Value = strSerialNo
	//            .Parameters.Add("IQSize", OleDbType.VarChar, 250).Value = strSize
	//            .Parameters.Add("IQMainpowerSupply", OleDbType.VarChar, 250).Value = strMainPowerSupply
	//            .ExecuteNonQuery()
	//        End With

	//        objCommand.Dispose()
	//        Status = True

	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        '--- Error logging
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = "Error in Updating IQ Specification Details."
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

	//Private Function funcDeleteIQSpecificationData(ByVal intSpecificationID As Integer) As Boolean
	//    '=====================================================================
	//    ' Procedure Name        :   funcDeleteIQSpecificationData
	//    ' Description           :   To Delete Specification Data from Database.
	//    ' Purpose               :   To Delete Specification Data from Database.
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
	//            Throw New Exception("Error in Opening Connection during Deleting IQ Specification Details.")
	//        End If

	//        '--- Query to Delete from Database
	//        str_sql = " Delete * from IQSpecification " & _
	//                  " where IQSpecificationID = " & intSpecificationID & " "

	//        'Status = mclsDBFunctions.AddORDeleteRecord(str_sql, mobjOleDBconnection)
	//        If (Status = False) Then
	//            Throw New Exception("Error in Deleting IQ Specification Details.")
	//        End If

	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        '--- Error logging
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = "Error in Deleting IQ Specification Details."
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

	#Region "Accessory Functions"

	private void subCreateAccessoryDataTable()
	{
		//=====================================================================
		// Procedure Name        :   subCreateAccessoryDataTable
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
			mobjACDataTable.Columns.Add(objDataColumn);

			mobjACDataTable.Columns.Add(new DataColumn("Name", typeof(string)));
			mobjACDataTable.Columns.Add(new DataColumn("Manufacturer", typeof(string)));
			mobjACDataTable.Columns.Add(new DataColumn("SerialNo", typeof(string)));
			mobjACDataTable.Columns.Add(new DataColumn("Specification", typeof(string)));
			mobjACDataTable.Columns.Add(new DataColumn("IQAccessoryID", typeof(int)));
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = "Error in Creating Accessories List Data-Table.";
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

	//Private Function funcGetIQAccessoryRecords() As Boolean
	//    '=====================================================================
	//    ' Procedure Name        :   funcGetIQAccessoryRecords
	//    ' Description           :   To Get IQ Accessory Records from Database into DataTable.
	//    ' Purpose               :   To Get IQ Accessory Records from Database into DataTable.
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
	//        sql_string = " Select IQAccessoryID ,Name ,Manufacturer ,SerialNo ,Specification " & _
	//                     " from IQAccessory "

	//        'reader_status = mclsDBFunctions.GetRecords(sql_string, mobjOleDBconnection, objReader)

	//        If Not (reader_status) Then
	//            Throw New Exception("Error in Opening Connection during Getting IQ Accessory List Details.")
	//        End If

	//        rec_cnt = 1
	//        While objReader.Read
	//            objDataRow = mobjACDataTable.NewRow()

	//            objDataRow("SrNo") = rec_cnt
	//            objDataRow("Name") = CStr(objReader.Item("Name"))
	//            objDataRow("Manufacturer") = objReader.Item("Manufacturer")
	//            objDataRow("SerialNo") = objReader.Item("SerialNo")
	//            objDataRow("Specification") = objReader.Item("Specification")
	//            objDataRow("IQAccessoryID") = Convert.ToInt32(objReader.Item("IQAccessoryID"))

	//            mobjACDataTable.Rows.Add(objDataRow)
	//            rec_cnt = rec_cnt + 1
	//        End While
	//        objReader.Close()

	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        'Error logging
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = "Error in Getting IQ Accessory List Records."
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

	private void subFormatAccessoryDataGrid()
	{
		DataGridTextBoxColumn objTextColumn;

		try {
			dgAccessory.TableStyles.Clear();
			mobjAccessoryDataView.Table = mobjACDataTable;
			mobjAccessoryDataView.AllowNew = true;
			dgAccessory.DataSource = mobjAccessoryDataView;
			//dgAccessory.ReadOnly = False

			mobjACGridTableStyle.RowHeadersVisible = false;
			mobjACGridTableStyle.ResetAlternatingBackColor();
			mobjACGridTableStyle.ResetBackColor();
			mobjACGridTableStyle.ResetForeColor();
			mobjACGridTableStyle.ResetGridLineColor();
			mobjACGridTableStyle.BackColor = Color.AliceBlue;
			mobjACGridTableStyle.GridLineColor = Color.Black;
			mobjACGridTableStyle.HeaderBackColor = Color.FromArgb(205, 225, 250);
			mobjACGridTableStyle.HeaderForeColor = Color.Black;
			mobjACGridTableStyle.AlternatingBackColor = Color.AliceBlue;
			mobjACGridTableStyle.AllowSorting = false;
			mobjACGridTableStyle.PreferredRowHeight = 34;
			//9.7.2010 by dinesh wagh
			mobjACGridTableStyle.MappingName = "IQAccessory";

			objTextColumn = new DataGridTextBoxColumn();
			objTextColumn.MappingName = "SrNo";
			objTextColumn.HeaderText = "Sr.No.";
			objTextColumn.Width = 40;
			objTextColumn.ReadOnly = true;
			objTextColumn.NullText = "";
			objTextColumn.Alignment = HorizontalAlignment.Center;
			mobjACGridTableStyle.GridColumnStyles.Add(objTextColumn);

			objTextColumn = new DataGridTextBoxColumn();
			objTextColumn.MappingName = "Name";
			objTextColumn.HeaderText = "Accessories";
			objTextColumn.Width = 160;
			objTextColumn.TextBox.WordWrap = true;
			//24.6.2010 by dinesh wagh
			objTextColumn.ReadOnly = false;
			objTextColumn.NullText = "";
			//objTextColumn.Alignment = HorizontalAlignment.Center
			mobjACGridTableStyle.GridColumnStyles.Add(objTextColumn);

			objTextColumn = new DataGridTextBoxColumn();
			objTextColumn.MappingName = "Manufacturer";
			objTextColumn.HeaderText = "Manufacturer";
			objTextColumn.Width = 150;
			objTextColumn.TextBox.WordWrap = true;
			//24.6.2010 by dinesh wagh
			objTextColumn.ReadOnly = false;
			objTextColumn.NullText = "";
			//objTextColumn.Alignment = HorizontalAlignment.Center
			mobjACGridTableStyle.GridColumnStyles.Add(objTextColumn);

			objTextColumn = new DataGridTextBoxColumn();
			objTextColumn.MappingName = "SerialNo";
			objTextColumn.HeaderText = "Serial No";
			objTextColumn.Width = 80;
			objTextColumn.ReadOnly = false;
			objTextColumn.NullText = "";
			objTextColumn.Alignment = HorizontalAlignment.Center;
			mobjACGridTableStyle.GridColumnStyles.Add(objTextColumn);

			objTextColumn = new DataGridTextBoxColumn();
			objTextColumn.MappingName = "Specification";
			//objTextColumn.HeaderText = "Specification" '4.4.2010 by dinesh wagh
			objTextColumn.HeaderText = "Mains Power Supply";
			//4.4.2010 by dinesh wagh
			objTextColumn.Width = 142;
			objTextColumn.ReadOnly = false;
			objTextColumn.NullText = "";
			//objTextColumn.Alignment = HorizontalAlignment.Center
			mobjACGridTableStyle.GridColumnStyles.Add(objTextColumn);

			objTextColumn = new DataGridTextBoxColumn();
			objTextColumn.MappingName = "IQAccessoryID";
			objTextColumn.HeaderText = "IQAccessoryID";
			objTextColumn.Width = 0;
			objTextColumn.ReadOnly = true;
			objTextColumn.NullText = "";
			mobjACGridTableStyle.GridColumnStyles.Add(objTextColumn);

			mobjACGridTableStyle.GridLineColor = Color.Black;
			dgAccessory.TableStyles.Add(mobjACGridTableStyle);
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = "Error in Formating IQ Accessory List Data-Grid.";
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

	//Private Function funcSaveIQAccessoryData() As Boolean
	//    '=====================================================================
	//    ' Procedure Name        :   funcSaveIQAccessoryData
	//    ' Description           :   To Save the Entered Records into Database.
	//    ' Purpose               :   To Save the Entered Records into Database.
	//    ' Parameters Passed     :   None.
	//    ' Returns               :   None.
	//    ' Parameters Affected   :   None.
	//    ' Assumptions           :
	//    ' Dependencies          :
	//    ' Author                :   Gitesh
	//    ' Created               :   January, 2003 
	//    ' Revisions             :
	//    '=====================================================================

	//    Dim intRecordCount, intAccessoryID, temp_cnt As Integer
	//    Dim strName, strManufacturer, strSerialNo, strSpecification As String
	//    Dim status As Boolean = True

	//    Try
	//        intRecordCount = mobjACDataTable.Rows.Count

	//        For temp_cnt = 0 To (intRecordCount - 1)
	//            '--- To Check if Completed / Accepted ID is Null.
	//            If IsDBNull(mobjACDataTable.Rows(temp_cnt).ItemArray.GetValue(mobjACDataTable.Columns.Item("IQAccessoryID").Ordinal)) Then
	//                strName = mobjACDataTable.Rows(temp_cnt).ItemArray.GetValue(mobjACDataTable.Columns.Item("Name").Ordinal)
	//                If IsDBNull(mobjACDataTable.Rows(temp_cnt).ItemArray.GetValue(mobjACDataTable.Columns.Item("Manufacturer").Ordinal)) = False Then
	//                    strManufacturer = mobjACDataTable.Rows(temp_cnt).ItemArray.GetValue(mobjACDataTable.Columns.Item("Manufacturer").Ordinal)
	//                End If
	//                If IsDBNull(mobjACDataTable.Rows(temp_cnt).ItemArray.GetValue(mobjACDataTable.Columns.Item("SerialNo").Ordinal)) = False Then
	//                    strSerialNo = mobjACDataTable.Rows(temp_cnt).ItemArray.GetValue(mobjACDataTable.Columns.Item("SerialNo").Ordinal)
	//                End If
	//                If IsDBNull(mobjACDataTable.Rows(temp_cnt).ItemArray.GetValue(mobjACDataTable.Columns.Item("Specification").Ordinal)) = False Then
	//                    strSpecification = mobjACDataTable.Rows(temp_cnt).ItemArray.GetValue(mobjACDataTable.Columns.Item("Specification").Ordinal)
	//                End If
	//                status = funcInsertIQAccessoryData(strName, strManufacturer, strSerialNo, strSpecification)
	//                If Not (status) Then
	//                    Throw New Exception("Error in Saving IQ Accessory List Details.")
	//                End If
	//            Else
	//                intAccessoryID = mobjACDataTable.Rows(temp_cnt).ItemArray.GetValue(mobjACDataTable.Columns.Item("IQAccessoryID").Ordinal)
	//                strName = mobjACDataTable.Rows(temp_cnt).ItemArray.GetValue(mobjACDataTable.Columns.Item("Name").Ordinal)
	//                If IsDBNull(mobjACDataTable.Rows(temp_cnt).ItemArray.GetValue(mobjACDataTable.Columns.Item("Manufacturer").Ordinal)) = False Then
	//                    strManufacturer = mobjACDataTable.Rows(temp_cnt).ItemArray.GetValue(mobjACDataTable.Columns.Item("Manufacturer").Ordinal)
	//                End If
	//                If IsDBNull(mobjACDataTable.Rows(temp_cnt).ItemArray.GetValue(mobjACDataTable.Columns.Item("SerialNo").Ordinal)) = False Then
	//                    strSerialNo = mobjACDataTable.Rows(temp_cnt).ItemArray.GetValue(mobjACDataTable.Columns.Item("SerialNo").Ordinal)
	//                End If
	//                If IsDBNull(mobjACDataTable.Rows(temp_cnt).ItemArray.GetValue(mobjACDataTable.Columns.Item("Specification").Ordinal)) = False Then
	//                    strSpecification = mobjACDataTable.Rows(temp_cnt).ItemArray.GetValue(mobjACDataTable.Columns.Item("Specification").Ordinal)
	//                Else
	//                    strSpecification = ""
	//                End If
	//                status = funcUpdateIQAccessoryData(strName, strManufacturer, strSerialNo, strSpecification, intAccessoryID)
	//                If Not (status) Then
	//                    Throw New Exception("Error in Updating IQ Accessory List Details.")
	//                End If
	//            End If
	//        Next
	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        'Error logging
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = "Error in Saving IQ Accessory List Details."
	//        gobjErrorHandler.WriteErrorLog(ex)
	//        '---------------------------------------------------------
	//    Finally
	//        '---------------------------------------------------------
	//        '--- Writing Execution log
	//        If CONST_CREATE_EXECUTION_LOG = 1 Then
	//            gobjErrorHandler.WriteExecutionLog()
	//        End If
	//        '---------------------------------------------------------
	//    End Try
	//    Return status

	//End Function

	public bool funcSaveIQAccessoryData()
	{
		//=====================================================================
		// Procedure Name        :   funcSaveIQAccessoryData
		// Description           :   To Save the Entered Records into Database.
		// Purpose               :   To Save the Entered Records into Database.
		// Parameters Passed     :   None.
		// Returns               :   None.
		// Parameters Affected   :   None.
		// Assumptions           :
		// Dependencies          :
		// Author                :   M.Kamal
		// Created               :   20-May-2004
		// Revisions             :
		//=====================================================================

		int intRecordCount;
		int intAccessoryID;
		int temp_cnt;
		string strName;
		string strManufacturer;
		string strSerialNo;
		string strSpecification;
		bool status = true;

		try {
			intRecordCount = mobjACDataTable.Rows.Count;

			for (temp_cnt = 0; temp_cnt <= (intRecordCount - 1); temp_cnt++) {
				//--- To Check if Completed / Accepted ID is Null.
				if (IsDBNull(mobjACDataTable.Rows(temp_cnt).ItemArray.GetValue(mobjACDataTable.Columns.Item("IQAccessoryID").Ordinal))) {
					strName = mobjACDataTable.Rows(temp_cnt).ItemArray.GetValue(mobjACDataTable.Columns.Item("Name").Ordinal);
					strName = strName.Replace(vbCrLf, " ");
					//25.6.2010 by dinesh wagh
					strManufacturer = mobjACDataTable.Rows(temp_cnt).ItemArray.GetValue(mobjACDataTable.Columns.Item("Manufacturer").Ordinal);
					strManufacturer = strManufacturer.Replace(vbCrLf, " ");
					//25.6.2010 by dinesh wagh
					strSerialNo = mobjACDataTable.Rows(temp_cnt).ItemArray.GetValue(mobjACDataTable.Columns.Item("SerialNo").Ordinal);
					strSpecification = mobjACDataTable.Rows(temp_cnt).ItemArray.GetValue(mobjACDataTable.Columns.Item("Specification").Ordinal);
					status = gobjDataAccess.funcInsertIQAccessoryData(strName, strManufacturer, strSerialNo, strSpecification);
					if (!(status)) {
						throw new Exception("Error in Saving IQ Accessory List Details.");
					}
				} else {
					if (IsDBNull(mobjACDataTable.Rows(temp_cnt).ItemArray.GetValue(mobjACDataTable.Columns.Item("Name").Ordinal)) | IsDBNull(mobjACDataTable.Rows(temp_cnt).ItemArray.GetValue(mobjACDataTable.Columns.Item("Manufacturer").Ordinal)) | IsDBNull(mobjACDataTable.Rows(temp_cnt).ItemArray.GetValue(mobjACDataTable.Columns.Item("SerialNo").Ordinal)) | IsDBNull(mobjACDataTable.Rows(temp_cnt).ItemArray.GetValue(mobjACDataTable.Columns.Item("Specification").Ordinal))) {
						intAccessoryID = mobjACDataTable.Rows(temp_cnt).ItemArray.GetValue(mobjACDataTable.Columns.Item("IQAccessoryID").Ordinal);
						status = gobjDataAccess.funcDeleteIQAccessoryData(intAccessoryID);
						if (!(status)) {
							throw new Exception("Error in Deleting Manual List Details.");
						}
					} else {
						intAccessoryID = mobjACDataTable.Rows(temp_cnt).ItemArray.GetValue(mobjACDataTable.Columns.Item("IQAccessoryID").Ordinal);
						strName = mobjACDataTable.Rows(temp_cnt).ItemArray.GetValue(mobjACDataTable.Columns.Item("Name").Ordinal);
						strName = strName.Replace(vbCrLf, " ");
						//25.6.2010 by dinesh wagh
						strManufacturer = mobjACDataTable.Rows(temp_cnt).ItemArray.GetValue(mobjACDataTable.Columns.Item("Manufacturer").Ordinal);
						strManufacturer = strManufacturer.Replace(vbCrLf, " ");
						//25.6.2010 by dinesh wagh
						strSerialNo = mobjACDataTable.Rows(temp_cnt).ItemArray.GetValue(mobjACDataTable.Columns.Item("SerialNo").Ordinal);
						strSpecification = mobjACDataTable.Rows(temp_cnt).ItemArray.GetValue(mobjACDataTable.Columns.Item("Specification").Ordinal);
						status = gobjDataAccess.funcUpdateIQAccessoryData(strName, strManufacturer, strSerialNo, strSpecification, intAccessoryID);
						if (!(status)) {
							throw new Exception("Error in Updating IQ Accessory List Details.");
						}
					}
				}
			}
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = "Error in Saving IQ Accessory List Details.";
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

	//Private Function funcInsertIQAccessoryData(ByVal strName As String, ByVal strManufacturer As String, ByVal strSerialNo As String, ByVal strSpecification As String) As Boolean
	//    '=====================================================================
	//    ' Procedure Name        :   funcInsertIQAccessoryData
	//    ' Description           :   To Add/Insert New Accessory Data in Database.
	//    ' Purpose               :   To Add/Insert New Accessory Data in Database.
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
	//    Dim intAccessoryID As Integer

	//    Try
	//        'Status = mclsDBFunctions.OpenConnection(mobjOleDBconnection)
	//        If Not (Status) Then
	//            Throw New Exception("Error in Opening Connection during Saving IQ Accessory List Details.")
	//        End If

	//        '--- Generating Next ID. 
	//        'intAccessoryID = mclsDBFunctions.GetNextID("IQAccessory", "IQAccessoryID", mobjOleDBconnection)

	//        '---  Query for adding  data 
	//        str_sql = " Insert into IQAccessory " & _
	//                  " (Name ,Manufacturer ,SerialNo ,Specification ,IQAccessoryID) " & _
	//                  " values('" & strName & "','" & strManufacturer & "','" & strSerialNo & "','" & strSpecification & "'," & intAccessoryID & ") "
	//        '" values(?,?,?,?,?) "

	//        '--- Providing command object. 
	//        With objCommand
	//            .Connection = mobjOleDBconnection
	//            .CommandType = CommandType.Text
	//            .CommandText = str_sql
	//            '.Parameters.Add("IQAccessoryID", OleDbType.Numeric).Value = intAccessoryID
	//            '.Parameters.Add("Name", OleDbType.VarChar, 50).Value = strName
	//            '.Parameters.Add("Manufacturer", OleDbType.VarChar, 50).Value = strManufacturer
	//            '.Parameters.Add("SerialNo", OleDbType.VarChar, 50).Value = strSerialNo
	//            '.Parameters.Add("Specification", OleDbType.VarChar, 50).Value = strSpecification
	//            .ExecuteNonQuery()
	//        End With

	//        objCommand.Dispose()
	//        Status = True

	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        '--- Error logging
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = "Error in Saving IQ Accessory List Details."
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

	//Private Function funcUpdateIQAccessoryData(ByVal strName As String, ByVal strManufacturer As String, ByVal strSerialNo As String, ByVal strSpecification As String, ByVal intAccessoryID As Integer) As Boolean
	//    '=====================================================================
	//    ' Procedure Name        :   funcUpdateIQAccessoryData
	//    ' Description           :   To Update Accessory Data in Database.
	//    ' Purpose               :   To Update Accessory Data in Database.
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
	//            Throw New Exception("Error in Opening Connection during Updating IQ Accessory List Details.")
	//        End If

	//        '---  Query for adding  data 
	//        str_sql = " Update IQAccessory " & _
	//                  " Set Name = ? ,Manufacturer = ? ,SerialNo = ? ,Specification = ? " & _
	//                  " where IQAccessoryID = " & intAccessoryID & " "

	//        '--- Providing command object  
	//        With objCommand
	//            .Connection = mobjOleDBconnection
	//            .CommandType = CommandType.Text
	//            .CommandText = str_sql
	//            .Parameters.Add("Name", OleDbType.VarChar, 250).Value = strName
	//            .Parameters.Add("Manufacturer", OleDbType.VarChar, 250).Value = strManufacturer
	//            .Parameters.Add("SerialNo", OleDbType.VarChar, 250).Value = strSerialNo
	//            .Parameters.Add("Specification", OleDbType.VarChar, 250).Value = strSpecification
	//            .ExecuteNonQuery()
	//        End With

	//        objCommand.Dispose()
	//        Status = True

	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        '--- Error logging
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = "Error in Updating IQ Accessory List Details."
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

	//Private Function funcDeleteIQAccessoryData(ByVal intAccessoryID As Integer) As Boolean
	//    '=====================================================================
	//    ' Procedure Name        :   funcDeleteIQAccessoryData
	//    ' Description           :   To Delete Accessory Data from Database.
	//    ' Purpose               :   To Delete Accessory Data from Database.
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
	//            Throw New Exception("Error in Opening Connection during Deleting IQ Accessory List Details.")
	//        End If

	//        '--- Query to Delete from Database
	//        str_sql = " Delete * from IQAccessory " & _
	//                  " where IQAccessoryID = " & intAccessoryID & " "

	//        'Status = mclsDBFunctions.AddORDeleteRecord(str_sql, mobjOleDBconnection)
	//        If (Status = False) Then
	//            Throw New Exception("Error in Deleting IQ Accessory List Details.")
	//        End If

	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        '--- Error logging
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = "Error in Deleting IQ Accessory List Details."
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
dgSpecification_CurrentCellChanged(object sender, System.EventArgs e)
	{
		DataView objDV;
		int intWidth;

		//try catch added by : dinesh wagh on 3.2.2010
		try {
			mObjDataTable.Columns(0).ReadOnly = false;
			if (mObjDataTable.Rows.Count == 0) {
				mObjDataTable.Columns(0).DefaultValue = 1;
			} else {
				dgSpecification.Item(dgSpecification.CurrentRowIndex, 0) = dgSpecification.CurrentRowIndex + 1;
			}

			//Else
			//dgSpecification.Item(0, 0) = 1
			//End If
			mObjDataTable.Columns(0).ReadOnly = true;
			if (dgSpecification.CurrentRowIndex >= 6) {
				mobjSpecificationDataView.AllowNew = false;
			}

			//-------16.6.2010  by dinesh wagh 
			if (mObjDataTable.Rows.Count == 0 & dgSpecification.CurrentRowIndex != -1) {
				dgSpecification.Item(0, 0) = 1;
			}
			//-------------
			//30.6.2010 by dinesh wagh
			//------------------------------------------
			objDV = dgSpecification.DataSource;

			switch (mintColumnIndexInst) {
				case EnumColumnsInstrument.EquipmentName:
					intWidth = CONST_InstrumentTable_EquipmentName_Size;
				case EnumColumnsInstrument.Manufacture:
					intWidth = CONST_InstrumentTable_Manufacture_Size;
			}

			if (objDV.Count > 0 & objDV.Count > mintRowIndexInst) {
				if (mintColumnIndexInst == EnumColumnsInstrument.EquipmentName | mintColumnIndexInst == EnumColumnsInstrument.Manufacture) {
					if (!IsDBNull(objDV(mintRowIndexInst).Row(mintColumnIndexInst))) {
						objDV(mintRowIndexInst).Row(mintColumnIndexInst) = gfuncWordWrap(objDV(mintRowIndexInst).Row(mintColumnIndexInst), intWidth);
						dgSpecification.DataSource = objDV;
					}
				}
			}
			mintRowIndexInst = dgSpecification.CurrentCell.RowNumber;
			mintColumnIndexInst = dgSpecification.CurrentCell.ColumnNumber;
		//-----------------------------------------------------------------
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

	private void  // ERROR: Handles clauses are not supported in C#
dgAccessory_CurrentCellChanged(object sender, System.EventArgs e)
	{
		//try catch added by  : dinesh wagh on 3.2.2010
		DataView objDV;
		int intWidth;

		try {
			mobjACDataTable.Columns(0).ReadOnly = false;
			//If mObjDataTable.Rows.Count = 0 Then
			//by pankaj on 7.12.07
			if (mobjACDataTable.Rows.Count == 0) {
				//mObjDataTable.Columns(0).DefaultValue = 1
				mobjACDataTable.Columns(0).DefaultValue = 1;
				//by pankaj on 7.12.07
			} else {
				dgAccessory.Item(dgAccessory.CurrentRowIndex, 0) = dgAccessory.CurrentRowIndex + 1;
			}

			mobjACDataTable.Columns(0).ReadOnly = true;
			if (dgAccessory.CurrentRowIndex >= 6) {
				mobjAccessoryDataView.AllowNew = false;
			}

			//-------16.6.2010  by dinesh wagh 
			if (mobjACDataTable.Rows.Count == 0 & dgAccessory.CurrentRowIndex != -1) {
				dgAccessory.Item(0, 0) = 1;
			}
			//------------

			//30.6.2010 by dinesh wagh
			//--------------------------------
			objDV = dgAccessory.DataSource;
			switch (mintColumnIndexAccessory) {
				case EnumColumnsAccessory.Accessories:
					intWidth = CONST_AccessoryTable_Accessories_Size;
				case EnumColumnsAccessory.Manufacturer:
					intWidth = CONST_AccessoryTable_Manufacturer_Size;
			}
			if (objDV.Count > 0 & objDV.Count > mintRowIndexAccessory) {
				if (mintColumnIndexAccessory == EnumColumnsAccessory.Accessories | mintColumnIndexAccessory == EnumColumnsAccessory.Manufacturer) {
					if (!IsDBNull(objDV(mintRowIndexAccessory).Row(mintColumnIndexAccessory))) {
						objDV(mintRowIndexAccessory).Row(mintColumnIndexAccessory) = gfuncWordWrap(objDV(mintRowIndexAccessory).Row(mintColumnIndexAccessory), intWidth);
						dgAccessory.DataSource = objDV;
					}
				}
			}
			mintRowIndexAccessory = dgAccessory.CurrentCell.RowNumber;
			mintColumnIndexAccessory = dgAccessory.CurrentCell.ColumnNumber;
		//---------------------------------
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
