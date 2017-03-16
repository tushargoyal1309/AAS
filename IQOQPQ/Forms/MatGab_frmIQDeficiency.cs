
using System.Data;
using System.Data.OleDb;

public class frmIQDeficiency : System.Windows.Forms.Form
{

	#Region " Module level Declarations "
	private bool mblnModeLockStatus;
	private int mintMode;
	private string mstrOledbConnectionString;
	private OleDbConnection mobjOleDBconnection;
	//Public mclsDBFunctions As New clsDatabaseFunctions

	private DataTable mObjDataTable;
	private DataTable mobjCADataTable;
	 mobjGridTableStyle;
	DataGridTableStyle mobjCAGridTableStyle = new DataGridTableStyle();
	DateTimePicker mdtpCorrectiveDate;
	private const  CONST_DateColumnNo = 4;
	private DataView mobjDataView = new DataView();

	private DataView mobjDataView1 = new DataView();
	//30.6.2010 by dinesh wagh
	//------------------------------------
	int mintRowIndex;
	int mintColumnIndex;
	private const  CONST_DetailsOfDeficiency_Size = 28;
	private const  CONST_CorrectiveAction_Size = 25;

	private const  CONST_ActionBy_Size = 25;
	private enum EnumColumns
	{
		DetailOfDeficiency = 1,
		CorrectiveAction = 2,
		ActionBy = 3
	}
	//---------------------------
	#End Region

	#Region " Windows Form Designer generated code "

	public frmIQDeficiency()
	{
		base.New();

		//This call is required by the Windows Form Designer.
		InitializeComponent();

		//Add any initialization after the InitializeComponent() call

	}

	public frmIQDeficiency(int intMode)
	{
		base.New();

		//This call is required by the Windows Form Designer.
		InitializeComponent();

		//Add any initialization after the InitializeComponent() call
		mintMode = intMode;

		//code added by : dinesh wagh on 25.7.2010
		//AS SAME FORM IS USE FOR ALL 3 MODE.
		//------------------------------------------------
		switch (mintMode) {
			case ENUM_IQOQPQ_STATUS.IQ:
				lblHeader.Text = "C.III  DEFICIENCIES FOUND AND CORRECTIVE ACTION ";
			case ENUM_IQOQPQ_STATUS.OQ:
				lblHeader.Text = "D.IV  DEFICIENCIES FOUND AND CORRECTIVE ACTION ";
			case ENUM_IQOQPQ_STATUS.PQ:
				lblHeader.Text = "E.III  DEFICIENCIES FOUND AND CORRECTIVE ACTION ";
		}
		//------------------------------------------------

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
	internal System.Windows.Forms.Panel Panel1;
	internal System.Windows.Forms.DataGrid dgDeficiency;
	internal System.Windows.Forms.DataGrid dgCompletedAccepted;
	internal System.Windows.Forms.Panel Panel2;
	internal System.Windows.Forms.PictureBox PictureBox1;
	[System.Diagnostics.DebuggerStepThrough()]
	private void InitializeComponent()
	{
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmIQDeficiency));
		this.lblHeader = new System.Windows.Forms.Label();
		this.Panel1 = new System.Windows.Forms.Panel();
		this.Panel2 = new System.Windows.Forms.Panel();
		this.PictureBox1 = new System.Windows.Forms.PictureBox();
		this.dgCompletedAccepted = new System.Windows.Forms.DataGrid();
		this.dgDeficiency = new System.Windows.Forms.DataGrid();
		this.Panel1.SuspendLayout();
		this.Panel2.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.dgCompletedAccepted).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dgDeficiency).BeginInit();
		this.SuspendLayout();
		//
		//lblHeader
		//
		this.lblHeader.BackColor = System.Drawing.Color.AliceBlue;
		this.lblHeader.Font = new System.Drawing.Font("Arial", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblHeader.Location = new System.Drawing.Point(35, 7);
		this.lblHeader.Name = "lblHeader";
		this.lblHeader.Size = new System.Drawing.Size(533, 18);
		this.lblHeader.TabIndex = 1;
		this.lblHeader.Text = "C.III  DEFICIENCIES FOUND AND CORRECTIVE ACTION ";
		this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//Panel1
		//
		this.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.Panel1.Controls.Add(this.Panel2);
		this.Panel1.Controls.Add(this.dgCompletedAccepted);
		this.Panel1.Controls.Add(this.dgDeficiency);
		this.Panel1.Dock = System.Windows.Forms.DockStyle.Top;
		this.Panel1.Location = new System.Drawing.Point(0, 0);
		this.Panel1.Name = "Panel1";
		this.Panel1.Size = new System.Drawing.Size(470, 528);
		this.Panel1.TabIndex = 12;
		//
		//Panel2
		//
		this.Panel2.BackColor = System.Drawing.Color.AliceBlue;
		this.Panel2.Controls.Add(this.PictureBox1);
		this.Panel2.Controls.Add(this.lblHeader);
		this.Panel2.Dock = System.Windows.Forms.DockStyle.Top;
		this.Panel2.Location = new System.Drawing.Point(0, 0);
		this.Panel2.Name = "Panel2";
		this.Panel2.Size = new System.Drawing.Size(468, 32);
		this.Panel2.TabIndex = 21;
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
		//dgCompletedAccepted
		//
		this.dgCompletedAccepted.BackgroundColor = System.Drawing.Color.AliceBlue;
		this.dgCompletedAccepted.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.dgCompletedAccepted.CaptionVisible = false;
		this.dgCompletedAccepted.DataMember = "";
		this.dgCompletedAccepted.HeaderForeColor = System.Drawing.SystemColors.ControlText;
		this.dgCompletedAccepted.Location = new System.Drawing.Point(69, 435);
		this.dgCompletedAccepted.Name = "dgCompletedAccepted";
		this.dgCompletedAccepted.ParentRowsVisible = false;
		this.dgCompletedAccepted.ReadOnly = true;
		this.dgCompletedAccepted.RowHeadersVisible = false;
		this.dgCompletedAccepted.Size = new System.Drawing.Size(454, 80);
		this.dgCompletedAccepted.TabIndex = 20;
		//
		//dgDeficiency
		//
		this.dgDeficiency.BackgroundColor = System.Drawing.Color.AliceBlue;
		this.dgDeficiency.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.dgDeficiency.CaptionVisible = false;
		this.dgDeficiency.DataMember = "";
		this.dgDeficiency.HeaderForeColor = System.Drawing.SystemColors.ControlText;
		this.dgDeficiency.Location = new System.Drawing.Point(8, 48);
		this.dgDeficiency.Name = "dgDeficiency";
		this.dgDeficiency.ParentRowsVisible = false;
		this.dgDeficiency.ReadOnly = true;
		this.dgDeficiency.RowHeadersVisible = false;
		this.dgDeficiency.Size = new System.Drawing.Size(576, 375);
		this.dgDeficiency.TabIndex = 18;
		//
		//frmIQDeficiency
		//
		this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
		this.AutoScroll = true;
		this.BackColor = System.Drawing.Color.AliceBlue;
		this.ClientSize = new System.Drawing.Size(470, 536);
		this.ControlBox = false;
		this.Controls.Add(this.Panel1);
		this.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		this.MaximizeBox = false;
		this.MinimizeBox = false;
		this.Name = "frmIQDeficiency";
		this.Tag = "2";
		this.Text = "Deficiency And Corrective Action Plan";
		this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
		this.Panel1.ResumeLayout(false);
		this.Panel2.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.dgCompletedAccepted).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dgDeficiency).EndInit();
		this.ResumeLayout(false);

	}

	#End Region

	#Region "Constants"

	private const string ConstSrNo = "SrNo";
	private const string ConstCompletedBy = "CompletedBy";
	private const string ConstAcceptedBy = "AcceptedBy";

	private const string ConstCompletedAcceptedByID = "CompletedAcceptedByID";
	private const string ConstDeficiencyDetails = "DeficiencyDetails";
	private const string ConstCorrectiveActionPlan = "CorrectiveActionPlan";
	private const string ConstCorrectiveActionBy = "CorrectiveActionBy";
	private const string ConstCorrectiveActionDate = "CorrectiveActionDate";

	private const string ConstDeficiencyID = "DeficiencyID";
	#End Region

	#Region " Form Events "

	private void  // ERROR: Handles clauses are not supported in C#
frmIQDeficiency_Load(object sender, System.EventArgs e)
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
frmIQDeficiency_Closing(object sender, System.ComponentModel.CancelEventArgs e)
	{
		try {
			if (!(mblnModeLockStatus)) {
				dgDeficiency.CurrentCell() = (new DataGridCell(dgDeficiency.CurrentRowIndex + 1, 0));
				if (!funcSaveDeficiencyData()) {
					throw new Exception("Error in Saving Deficiency Corrective Action Data.");
				}
				dgDeficiency.TableStyles.Clear();

				//if condition removed on 29.3.2010
				//by dinesh wagh
				//If (mintMode = ENUM_IQOQPQ_STATUS.PQ) Then
				//Else
				dgCompletedAccepted.CurrentCell() = (new DataGridCell(dgCompletedAccepted.CurrentRowIndex + 1, 0));
				if (!funcSaveCompleteAcceptData()) {
					throw new Exception("Error in Saving Customer Representative Data.");
				}
				dgCompletedAccepted.TableStyles.Clear();
				//End If
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
	//    General functions used for Deficiency and Corrective Action.
	//--- funcInitialize - To Initialize form and to get values for Deficiency/Corrective Action and Completed/Accepted by Data from database and display them.
	//--- subCreateDeficiencyDataTable - To Create Columns in the Data Table.
	//--- funcGetDeficiencyRecords - To Get Deficiency/Corrective Action Records from Database into DataTable.
	//--- subFormatDeficiencyDataGrid - To format the Deficiency/Corrective Action Data Grid.
	//--- funcSaveDeficiencyData - To Save the Entered Records into Database.
	//--- funcInsertDeficiencyData - To Add/Insert New Deficiency/Corrective Action Data in Database.
	//--- funcUpdateDeficiencyData - To Update Deficiency/Corrective Action Data in Database.
	//--- funcDeleteDeficiencyData - To Delete Deficiency/Corrective Action Data from Database.

	//--- subCreateCompleteAcceptDataTable - To Create Columns in the Data Table.
	//--- funcGetCompleteAcceptRecords - To Get Completed/Accepted By Records from Database into DataTable.
	//--- subFormatCompleteAcceptDataGrid - To format the Completed/Accepted By Data Grid.
	//--- funcSaveCompleteAcceptData - To Save the Entered Records into Database.
	//--- funcInsertCompleteAcceptData - To Add/Insert New Completed/Accepted By Data in Database.
	//--- funcUpdateCompleteAcceptData - To Update Completed/Accepted By Data in Database.
	//--- funcDeleteCompleteAcceptData - To Delete Completed/Accepted By Action Data from Database.

	private void funcInitialize()
	{
		//=====================================================================
		// Procedure Name        :   funcInitailize
		// Description           :   To Initialize form and to get values for IQ Deficiency/Corrective Action and Completed/Accepted by Data from database and display them.
		// Purpose               :   To Initialize form and to get values for IQ Deficiency/Corrective Action and Completed/Accepted by Data from database and display them.
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
		int intCount;
		DataRow objDataRow;

		try {

			//mfrmIQDeficiency = Me
			//mfrmOQDeficiency = Me
			//mfrmPQDeficiency = Me

			mObjDataTable = new DataTable("DeficiencyAction");
			mdtpCorrectiveDate = new DateTimePicker();


			//--- To Add Run-Time DateTime Picker Control
			mdtpCorrectiveDate.ValueChanged += dtpCorrectiveDate_ValueChanged;
			dgDeficiency.Controls.Add(mdtpCorrectiveDate);
			mdtpCorrectiveDate.Visible = false;
			mdtpCorrectiveDate.Format = DateTimePickerFormat.Custom;
			mdtpCorrectiveDate.CustomFormat = "dd-MMM-yyyy";


			//code commented by ; dinesh wagh on 29.3.2010
			//purpose : for PQ shows the table.

			//If (mintMode = ENUM_IQOQPQ_STATUS.PQ) Then
			//    ' grpboxCompletAccept.Visible = False
			//    dgCompletedAccepted.Visible = False
			//Else

			mobjCADataTable = new DataTable("CompletedAcceptedBy");

			subCreateCompleteAcceptDataTable();

			objDtTmp = new DataTable();

			objDtTmp = gobjDataAccess.funcGetCompleteAcceptRecords(mintMode);

			if (!objDtTmp == null) {
				if (!objDtTmp.Rows.Count == 0) {
					for (intCount = 0; intCount <= objDtTmp.Rows.Count - 1; intCount++) {
						objDataRow = mobjCADataTable.NewRow;
						//objDataRow.Item(ConstSrNo) = CInt(objDtTmp.Rows.Item(intCount).Item("CompletedAcceptedByID"))
						//added by pankaj on 5 Dec 07
						objDataRow.Item(ConstSrNo) = intCount + 1;
						//CInt(objDtTmp.Rows.Item(intCount).Item("CompletedAcceptedByID"))
						//...
						objDataRow.Item(ConstCompletedBy) = (string)objDtTmp.Rows.Item(intCount).Item("CompletedBy");
						objDataRow.Item(ConstAcceptedBy) = (string)objDtTmp.Rows.Item(intCount).Item("AcceptedBy");
						objDataRow.Item(ConstCompletedAcceptedByID) = (string)objDtTmp.Rows.Item(intCount).Item("CompletedAcceptedByID");
						//uncomment by pankaj on 5 Dec 07
						mobjCADataTable.Rows.Add(objDataRow);
					}
				}
			}


			if (IsNothing(mobjCADataTable) == true) {
				throw new Exception("Error in Getting Equipment List Records.");
			} else {
				subFormatCompleteAcceptDataGrid();
			}

			//If funcGetCompleteAcceptRecords() Then
			//    subFormatCompleteAcceptDataGrid()
			//Else
			//    Throw New Exception("Error in Getting Completed/Accepted By Records.")
			//End If

			//End If


			objDtTmp = new DataTable();

			subCreateDeficiencyDataTable();

			objDtTmp = gobjDataAccess.funcGetDeficiencyRecords(mintMode);

			if (!objDtTmp == null) {
				if (!objDtTmp.Rows.Count == 0) {
					for (intCount = 0; intCount <= objDtTmp.Rows.Count - 1; intCount++) {
						objDataRow = mObjDataTable.NewRow;
						objDataRow.Item(ConstSrNo) = intCount + 1;
						//by Pankaj on 06 Dec 07'CInt(objDtTmp.Rows.Item(intCount).Item("DeficiencyCorrectiveActionPlanID"))
						objDataRow.Item(ConstDeficiencyDetails) = gfuncWordWrap((string)objDtTmp.Rows.Item(intCount).Item("Details"), CONST_DetailsOfDeficiency_Size);
						objDataRow.Item(ConstCorrectiveActionPlan) = gfuncWordWrap((string)objDtTmp.Rows.Item(intCount).Item("ActionPlan"), CONST_CorrectiveAction_Size);
						objDataRow.Item(ConstCorrectiveActionBy) = gfuncWordWrap((string)objDtTmp.Rows.Item(intCount).Item("CorrectiveActionOrBy"), CONST_ActionBy_Size);
						objDataRow.Item(ConstCorrectiveActionDate) = (System.DateTime)objDtTmp.Rows.Item(intCount).Item("CorrectiveActionDate");
						objDataRow.Item(ConstDeficiencyID) = (int)objDtTmp.Rows.Item(intCount).Item("DeficiencyCorrectiveActionPlanID");
						mObjDataTable.Rows.Add(objDataRow);
					}
				}
			}


			if (IsNothing(mObjDataTable) == true) {
				throw new Exception("Error in Getting Equipment List Records.");
			} else {
				subFormatDeficiencyDataGrid();
			}

			//If funcGetDeficiencyRecords() Then
			//    subFormatDeficiencyDataGrid()
			//Else
			//    Throw New Exception("Error in Getting Deficiency Corrective Action Records.")
			//End If

			mblnModeLockStatus = gobjDataAccess.funcCheckModeLocked(mintMode);
			if ((mblnModeLockStatus)) {
				dgCompletedAccepted.ReadOnly = true;
				dgDeficiency.ReadOnly = true;
			} else {
				dgCompletedAccepted.ReadOnly = false;
				dgDeficiency.ReadOnly = false;
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

	private void dtpCorrectiveDate_ValueChanged(System.Object sender, System.EventArgs e)
	{
		dgDeficiency(dgDeficiency.CurrentCell.RowNumber, dgDeficiency.CurrentCell.ColumnNumber) = mdtpCorrectiveDate.Value;
	}

	#Region "Deficiency/Corrective Action Functions"

	private void subCreateDeficiencyDataTable()
	{
		//=====================================================================
		// Procedure Name        :   subCreateDeficiencyDataTable
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

			mObjDataTable.Columns.Add(new DataColumn("DeficiencyDetails", typeof(string)));
			mObjDataTable.Columns.Add(new DataColumn("CorrectiveActionPlan", typeof(string)));
			mObjDataTable.Columns.Add(new DataColumn("CorrectiveActionBy", typeof(string)));
			mObjDataTable.Columns.Add(new DataColumn("CorrectiveActionDate", typeof(System.DateTime)));
			mObjDataTable.Columns.Add(new DataColumn("DeficiencyID", typeof(int)));
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = "Error in Creating Deficiency Corrective Action Data-Table.";
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

	//Private Function funcGetDeficiencyRecords() As Boolean
	//    '=====================================================================
	//    ' Procedure Name        :   funcGetDeficiencyRecords
	//    ' Description           :   To Get Deficiency/Corrective Action Records from Database into DataTable.
	//    ' Purpose               :   To Get Deficiency/Corrective Action Records from Database into DataTable.
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
	//        sql_string = " Select DeficiencyCorrectiveActionPlanID ,Details ,ActionPlan , CorrectiveActionDate ,CorrectiveActionOrBy " & _
	//                     " from DeficiencyCorrectiveActionPlan where CheckStatusIQOQPQ = " & mintMode & " "

	//        'reader_status = mclsDBFunctions.GetRecords(sql_string, mobjOleDBconnection, objReader)

	//        If Not (reader_status) Then
	//            Throw New Exception("Error in Opening Connection during Getting Deficiency Corrective Action Records.")
	//        End If

	//        rec_cnt = 1
	//        While objReader.Read
	//            objDataRow = mObjDataTable.NewRow()

	//            objDataRow("SrNo") = rec_cnt
	//            objDataRow("DeficiencyDetails") = CStr(objReader.Item("Details"))
	//            objDataRow("CorrectiveActionPlan") = CStr(objReader.Item("ActionPlan"))
	//            objDataRow("CorrectiveActionBy") = CStr(objReader.Item("CorrectiveActionOrBy"))
	//            If IsDBNull(objReader.Item("CorrectiveActionDate")) Then
	//            Else
	//                objDataRow("CorrectiveActionDate") = CDate(objReader.Item("CorrectiveActionDate"))
	//            End If
	//            'objDataRow("CorrectiveActionDate") = CDate(objReader.Item("CorrectiveActionDate"))
	//            objDataRow("DeficiencyID") = Convert.ToInt32(objReader.Item("DeficiencyCorrectiveActionPlanID"))

	//            mObjDataTable.Rows.Add(objDataRow)
	//            rec_cnt = rec_cnt + 1
	//        End While
	//        objReader.Close()

	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        'Error logging
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = "Error in Getting Deficiency Corrective Action Records."
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

	private void subFormatDeficiencyDataGrid()
	{
		DataGridTextBoxColumn objTextColumn;

		try {
			dgDeficiency.TableStyles.Clear();
			mobjDataView.Table = mObjDataTable;
			mobjDataView.AllowNew = true;
			dgDeficiency.DataSource = mobjDataView;
			//dgDeficiency.ReadOnly = False

			mobjGridTableStyle.PreferredRowHeight = 34;
			//9.7.2010 by dinesh wagh
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

			mobjGridTableStyle.MappingName = "DeficiencyAction";

			objTextColumn = new DataGridTextBoxColumn();
			objTextColumn.MappingName = "SrNo";
			objTextColumn.HeaderText = "Sr.No.";
			objTextColumn.Width = 40;
			objTextColumn.ReadOnly = true;
			objTextColumn.NullText = "";
			objTextColumn.Alignment = HorizontalAlignment.Center;
			mobjGridTableStyle.GridColumnStyles.Add(objTextColumn);

			objTextColumn = new DataGridTextBoxColumn();
			objTextColumn.TextBox.WordWrap = true;
			//16.4.2010
			objTextColumn.MappingName = "DeficiencyDetails";
			objTextColumn.HeaderText = "Deficiency Details";
			objTextColumn.Width = 150;
			objTextColumn.ReadOnly = false;
			objTextColumn.NullText = "";
			objTextColumn.Alignment = HorizontalAlignment.Left;
			mobjGridTableStyle.GridColumnStyles.Add(objTextColumn);

			objTextColumn = new DataGridTextBoxColumn();
			objTextColumn.TextBox.WordWrap = true;
			//16.4.2010
			objTextColumn.MappingName = "CorrectiveActionPlan";
			objTextColumn.HeaderText = "Corrective Action Plan with responsible person";
			objTextColumn.Width = 130;
			objTextColumn.ReadOnly = false;
			objTextColumn.NullText = "";
			objTextColumn.Alignment = HorizontalAlignment.Left;
			mobjGridTableStyle.GridColumnStyles.Add(objTextColumn);

			objTextColumn = new DataGridTextBoxColumn();
			objTextColumn.TextBox.WordWrap = true;
			//16.4.2010
			objTextColumn.MappingName = "CorrectiveActionBy";
			objTextColumn.HeaderText = "Corrective Action By";
			objTextColumn.Width = 120;
			objTextColumn.ReadOnly = false;
			objTextColumn.NullText = "";
			objTextColumn.Alignment = HorizontalAlignment.Left;
			mobjGridTableStyle.GridColumnStyles.Add(objTextColumn);

			objTextColumn = new DataGridTextBoxColumn();
			objTextColumn.MappingName = "CorrectiveActionDate";
			objTextColumn.HeaderText = "Corrective Action Date";
			objTextColumn.Width = 132;
			objTextColumn.Format = "dd-MMM-yyyy";
			objTextColumn.ReadOnly = false;
			objTextColumn.NullText = "";
			objTextColumn.Alignment = HorizontalAlignment.Center;
			mobjGridTableStyle.GridColumnStyles.Add(objTextColumn);

			objTextColumn = new DataGridTextBoxColumn();
			objTextColumn.MappingName = "DeficiencyID";
			objTextColumn.HeaderText = "DeficiencyID";
			objTextColumn.Width = 0;
			objTextColumn.ReadOnly = true;
			objTextColumn.NullText = "";
			mobjGridTableStyle.GridColumnStyles.Add(objTextColumn);

			mobjGridTableStyle.GridLineColor = Color.Black;
			dgDeficiency.TableStyles.Add(mobjGridTableStyle);
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = "Error in Formating Deficiecny Corrective Action Data-Grid.";
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

	public bool funcSaveDeficiencyData()
	{
		//=====================================================================
		// Procedure Name        :   funcSaveDeficiencyData
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
		int intDeficiencyID;
		int temp_cnt;
		string strDetails;
		string strActionPlan;
		string strActionBy;
		DateTime dtActionDate;
		bool status = true;

		try {
			dtActionDate = Now;
			//---24.01.11


			intRecordCount = mObjDataTable.Rows.Count;

			for (temp_cnt = 0; temp_cnt <= (intRecordCount - 1); temp_cnt++) {
				//--- To Check if Deficiency ID is Null.
				if (IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("DeficiencyID").Ordinal))) {

					if (IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("DeficiencyDetails").Ordinal)) == false) {
						strDetails = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("DeficiencyDetails").Ordinal);
						strDetails = strDetails.Replace(vbCrLf, " ");

						strActionPlan = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("CorrectiveActionPlan").Ordinal);
						strActionPlan = strActionPlan.Replace(vbCrLf, " ");

						strActionBy = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("CorrectiveActionBy").Ordinal);
						strActionBy = strActionBy.Replace(vbCrLf, " ");

						if (IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("CorrectiveActionDate").Ordinal)) == false) {
							dtActionDate = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("CorrectiveActionDate").Ordinal);
						}

						status = gobjDataAccess.funcInsertDeficiencyData(strDetails, strActionPlan, strActionBy, dtActionDate, mintMode);
						if (!(status)) {
							throw new Exception("Error in Saving Deficiency Corrective Action Details.");
						}
					}
				} else {
					if (IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("DeficiencyDetails").Ordinal)) | IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("CorrectiveActionPlan").Ordinal)) | IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("CorrectiveActionBy").Ordinal)) | IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("CorrectiveActionDate").Ordinal))) {
						intDeficiencyID = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("DeficiencyID").Ordinal);
						status = gobjDataAccess.funcDeleteDeficiencyData(intDeficiencyID, mintMode);
						if (!(status)) {
							throw new Exception("Error in Deleting Manual List Details.");
						}
					} else {
						if (IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("DeficiencyID").Ordinal)) == false) {
							intDeficiencyID = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("DeficiencyID").Ordinal);
						}

						strDetails = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("DeficiencyDetails").Ordinal);
						strActionPlan = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("CorrectiveActionPlan").Ordinal);
						strActionBy = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("CorrectiveActionBy").Ordinal);
						if (IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("CorrectiveActionDate").Ordinal))) {
						} else {
							dtActionDate = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("CorrectiveActionDate").Ordinal);
						}
						status = gobjDataAccess.funcUpdateDeficiencyData(strDetails, strActionPlan, strActionBy, dtActionDate, intDeficiencyID, mintMode);
						if (!(status)) {
							throw new Exception("Error in Updating Deficiency Corrective Action Details.");
						}
					}
				}
			}

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = "Error in Saving Deficiency Correction Action Details.";
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

	//Private Function funcInsertDeficiencyData(ByVal strDetails As String, ByVal strActionPlan As String, ByVal strActionBy As String, ByVal dtActionDate As DateTime) As Boolean
	//    '=====================================================================
	//    ' Procedure Name        :   funcInsertDeficiencyData
	//    ' Description           :   To Add/Insert New Deficiency/Corrective Action Data in Database.
	//    ' Purpose               :   To Add/Insert New Deficiency/Corrective Action Data in Database.
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
	//    Dim intDeficiencyID As Integer

	//    Try
	//        'Status = mclsDBFunctions.OpenConnection(mobjOleDBconnection)
	//        If Not (Status) Then
	//            Throw New Exception("Error in Opening Connection during Saving Deficiency Corrective Action Details.")
	//        End If

	//        '--- Generating Next Equipment ID. 
	//        'intDeficiencyID = mclsDBFunctions.GetNextID("DeficiencyCorrectiveActionPlan", "DeficiencyCorrectiveActionPlanID", mobjOleDBconnection)

	//        '---  Query for adding  data to EquipmentList
	//        str_sql = " Insert into DeficiencyCorrectiveActionPlan " & _
	//                  " (DeficiencyCorrectiveActionPlanID ,Details ,ActionPlan ,CorrectiveActionDate ,CorrectiveActionOrBy ,CheckStatusIQOQPQ) " & _
	//                  " values(?,?,?,?,?,?) "

	//        '--- Providing command object. 
	//        With objCommand
	//            .Connection = mobjOleDBconnection
	//            .CommandType = CommandType.Text
	//            .CommandText = str_sql
	//            .Parameters.Add("DeficiencyCorrectiveActionPlanID", OleDbType.Numeric).Value = intDeficiencyID
	//            .Parameters.Add("Details", OleDbType.VarChar, 50).Value = strDetails
	//            .Parameters.Add("ActionPlan", OleDbType.VarChar, 50).Value = strActionPlan
	//            .Parameters.Add("CorrectiveActionDate", OleDbType.DBDate).Value = dtActionDate
	//            .Parameters.Add("CorrectiveActionOrBy", OleDbType.VarChar, 50).Value = strActionBy
	//            .Parameters.Add("CheckStatusIQOQPQ", OleDbType.Single).Value = mintMode
	//            '.Parameters.Add("CheckStatusIQOQPQ", OleDbType.Single).Value = CSng(ENUM_IQOQPQ_STATUS.IQ)
	//            .ExecuteNonQuery()
	//        End With

	//        objCommand.Dispose()
	//        Status = True

	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        '--- Error logging
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = "Error in Saving Deficiency Correction Action Details."
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

	//Private Function funcUpdateDeficiencyData(ByVal strDetails As String, ByVal strActionPlan As String, ByVal strActionBy As String, ByVal dtActionDate As DateTime, ByVal intDeficiencyID As Integer) As Boolean
	//    '=====================================================================
	//    ' Procedure Name        :   funcUpdateDeficiencyData
	//    ' Description           :   To Update Deficiency/Corrective Action Data in Database.
	//    ' Purpose               :   To Update Deficiency/Corrective Action Data in Database.
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
	//            Throw New Exception("Error in Opening Connection during Updating Deficiency Correction Action Details.")
	//        End If

	//        '---  Query for adding  data to EquipmentList
	//        str_sql = " Update DeficiencyCorrectiveActionPlan " & _
	//                  " Set Details = ? ,ActionPlan = ? ,CorrectiveActionDate = ? ,CorrectiveActionOrBy = ? " & _
	//                  " where DeficiencyCorrectiveActionPlanID = " & intDeficiencyID & " and CheckStatusIQOQPQ = " & mintMode & "  "

	//        '--- Providing command object for EquimentList
	//        With objCommand
	//            .Connection = mobjOleDBconnection
	//            .CommandType = CommandType.Text
	//            .CommandText = str_sql
	//            .Parameters.Add("Details", OleDbType.VarChar, 250).Value = strDetails
	//            .Parameters.Add("ActionPlan", OleDbType.VarChar, 250).Value = strActionPlan
	//            .Parameters.Add("CorrectiveActionDate", OleDbType.DBDate).Value = dtActionDate
	//            .Parameters.Add("CorrectiveActionOrBy", OleDbType.VarChar, 250).Value = strActionBy
	//            .ExecuteNonQuery()
	//        End With

	//        objCommand.Dispose()
	//        Status = True

	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        '--- Error logging
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = "Error in Updating Deficiency Correction Action Details."
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

	//Private Function funcDeleteDeficiencyData(ByVal intDeficiencyID As Integer) As Boolean
	//    '=====================================================================
	//    ' Procedure Name        :   funcDeleteDeficiencyData
	//    ' Description           :   To Delete Deficiency/Corrective Action Data from Database.
	//    ' Purpose               :   To Delete Deficiency/Corrective Action Data from Database.
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
	//            Throw New Exception("Error in Opening Connection for Deleting Completed/Accepted By Details.")
	//        End If

	//        '--- Query to Delete from Database
	//        str_sql = " Delete * from DeficiencyCorrectiveActionPlan " & _
	//                  " where DeficiencyCorrectiveActionPlanID = " & intDeficiencyID & " and CheckStatusIQOQPQ = " & mintMode & " "

	//        'Status = mclsDBFunctions.AddORDeleteRecord(str_sql, mobjOleDBconnection)
	//        If (Status = False) Then
	//            Throw New Exception("Error in Deleting Completed/Accepted By Details.")
	//        End If

	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        '--- Error logging
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = "Error in Deleting Deficiency Corrective Action Details."
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
			// objDataColumn.AutoIncrement = True
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

	//Private Function funcGetCompleteAcceptRecords() As Boolean
	//    '=====================================================================
	//    ' Procedure Name        :   funcGetCompleteAcceptRecords
	//    ' Description           :   To Get Completed/Accepted By Records from Database into DataTable.
	//    ' Purpose               :   To Get Completed/Accepted By Records from Database into DataTable.
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
	//                     " from CompletedAcceptedBY where CheckStatusIQOQPQ = " & mintMode & " "

	//        'reader_status = mclsDBFunctions.GetRecords(sql_string, mobjOleDBconnection, objReader)

	//        If Not (reader_status) Then
	//            Throw New Exception("Error in Opening Connection during Getting Completed/Accepted By Details.")
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
			mobjDataView1.Table = mobjCADataTable;
			mobjDataView1.AllowNew = true;
			dgCompletedAccepted.DataSource = mobjDataView1;

			//dgCompletedAccepted.DataSource = mobjCADataTable
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

			//objTextColumn = New DataGridTextBoxColumn
			//objTextColumn.MappingName = "CompletedAcceptedByID"
			//objTextColumn.HeaderText = "CompletedAcceptedByID"
			//objTextColumn.Width = 0
			//objTextColumn.ReadOnly = True
			//objTextColumn.NullText = ""
			//objTextColumn.Alignment = HorizontalAlignment.Center
			//mobjCAGridTableStyle.GridColumnStyles.Add(objTextColumn)

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

	public bool funcSaveCompleteAcceptData()
	{
		//=====================================================================
		// Procedure Name        :   funcSaveCompleteAcceptData
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
					strCompletedBy = mobjCADataTable.Rows(temp_cnt).ItemArray.GetValue(mobjCADataTable.Columns.Item("CompletedBy").Ordinal);
					strAcceptedBy = mobjCADataTable.Rows(temp_cnt).ItemArray.GetValue(mobjCADataTable.Columns.Item("AcceptedBy").Ordinal);
					status = gobjDataAccess.funcInsertCompleteAcceptData(strCompletedBy, strAcceptedBy, mintMode);
					if (!(status)) {
						throw new Exception("Error in Saving Completed/Accepted By Details.");
					}
				} else {
					intCompleteAcceptID = mobjCADataTable.Rows(temp_cnt).ItemArray.GetValue(mobjCADataTable.Columns.Item("CompletedAcceptedByID").Ordinal);
					if (!(IsDBNull(mobjCADataTable.Rows(temp_cnt).ItemArray.GetValue(mobjCADataTable.Columns.Item("CompletedBy").Ordinal))))
						strCompletedBy = mobjCADataTable.Rows(temp_cnt).ItemArray.GetValue(mobjCADataTable.Columns.Item("CompletedBy").Ordinal);
					if (!(IsDBNull(mobjCADataTable.Rows(temp_cnt).ItemArray.GetValue(mobjCADataTable.Columns.Item("AcceptedBy").Ordinal))))
						strAcceptedBy = mobjCADataTable.Rows(temp_cnt).ItemArray.GetValue(mobjCADataTable.Columns.Item("AcceptedBy").Ordinal);
					status = gobjDataAccess.funcUpdateCompleteAcceptData(strCompletedBy, strAcceptedBy, intCompleteAcceptID, mintMode);
					if (!(status)) {
						throw new Exception("Error in Saving Completed/Accepted By Details.");
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

	//Private Function funcInsertCompleteAcceptData(ByVal strCompletedBy As String, ByVal strAcceptedBy As String) As Boolean
	//    '=====================================================================
	//    ' Procedure Name        :   funcInsertCompleteAcceptData
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
	//        'Status = mclsDBFunctions.OpenConnection(mobjOleDBconnection)
	//        If Not (Status) Then
	//            Throw New Exception("Error in Opening Connection during Saving Completed/Accepted By Details.")
	//        End If

	//        '--- Generating Next Equipment ID. 
	//        'intCompleteAcceptID = mclsDBFunctions.GetNextID("CompletedAcceptedBY", "CompletedAcceptedByID", mobjOleDBconnection)

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
	//            .Parameters.Add("CheckStatusIQOQPQ", OleDbType.Single).Value = mintMode
	//            '.Parameters.Add("CheckStatusIQOQPQ", OleDbType.Single).Value = CSng(ENUM_IQOQPQ_STATUS.IQ)
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

	//Private Function funcUpdateCompleteAcceptData(ByVal strCompletedBy As String, ByVal strAcceptedBy As String, ByVal intCompleteAcceptID As Integer) As Boolean
	//    '=====================================================================
	//    ' Procedure Name        :   funcUpdateCompleteAcceptData
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
	//        'Status = mclsDBFunctions.OpenConnection(mobjOleDBconnection)
	//        If Not (Status) Then
	//            Throw New Exception("Error in Opening Connection during Updating Completed/Accepted By Details.")
	//        End If

	//        '---  Query for adding  data 
	//        str_sql = " Update CompletedAcceptedBY " & _
	//                  " Set CompletedBy = ? ,AcceptedBy = ? " & _
	//                  " where CompletedAcceptedByID = " & intCompleteAcceptID & " and CheckStatusIQOQPQ = " & mintMode & " "

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

	//Private Function funcDeleteCompleteAcceptData(ByVal intCompleteAcceptID As Integer) As Boolean
	//    '=====================================================================
	//    ' Procedure Name        :   funcDeleteCompleteAcceptData
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
	//        'Status = mclsDBFunctions.OpenConnection(mobjOleDBconnection)
	//        If Not (Status) Then
	//            Throw New Exception("Error in Opening Connection during Deleting Completed/Accepted By Details.")
	//        End If

	//        '--- Query to Delete from Database
	//        str_sql = " Delete * from CompletedAcceptedBY " & _
	//                  " where CompletedAcceptedByID = " & intCompleteAcceptID & " and CheckStatusIQOQPQ = " & mintMode & " "

	//        'Status = mclsDBFunctions.AddORDeleteRecord(str_sql, mobjOleDBconnection)
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
dgDeficiency_CurrentCellChanged(object sender, System.EventArgs e)
	{
		int intWidth;
		DataView objDV;

		try {
			if (!(mblnModeLockStatus)) {
				mObjDataTable.Columns(0).ReadOnly = false;

				if (mObjDataTable.Rows.Count == 0) {
					mObjDataTable.Columns(0).DefaultValue = 1;
				} else {
					dgDeficiency.Item(dgDeficiency.CurrentRowIndex, 0) = dgDeficiency.CurrentRowIndex + 1;
				}

				mObjDataTable.Columns(0).ReadOnly = true;
				if ((dgDeficiency.CurrentCell.ColumnNumber == CONST_DateColumnNo)) {
					mdtpCorrectiveDate.Top = dgDeficiency.GetCurrentCellBounds().Top;
					mdtpCorrectiveDate.Left = dgDeficiency.GetCurrentCellBounds().Left;
					mdtpCorrectiveDate.Width = dgDeficiency.GetCurrentCellBounds().Width;
					mdtpCorrectiveDate.Height = dgDeficiency.GetCurrentCellBounds().Height;
					if ((dgDeficiency.CurrentCell.RowNumber) > 0) {
						if (IsDBNull(dgDeficiency(dgDeficiency.CurrentCell.RowNumber, CONST_DateColumnNo)) == false) {
							mdtpCorrectiveDate.Value = (System.DateTime)dgDeficiency(dgDeficiency.CurrentCell.RowNumber, CONST_DateColumnNo);
						} else {
							mdtpCorrectiveDate.Value = DateTime.Today;
							dgDeficiency(dgDeficiency.CurrentCell.RowNumber, dgDeficiency.CurrentCell.ColumnNumber) = mdtpCorrectiveDate.Value;
						}
					} else {
						dgDeficiency(dgDeficiency.CurrentCell.RowNumber, dgDeficiency.CurrentCell.ColumnNumber) = mdtpCorrectiveDate.Value;
						//   mdtpCorrectiveDate.Value = DateTime.Today
					}
					mdtpCorrectiveDate.Visible = true;
				} else {
					mdtpCorrectiveDate.Width = 0;
					mdtpCorrectiveDate.Visible = false;
				}
			}

			if (dgDeficiency.CurrentRowIndex >= 10) {
				mobjDataView.AllowNew = false;
			}

			//-------3.2.2010  by dinesh wagh
			if (mObjDataTable.Rows.Count == 0 & dgDeficiency.CurrentRowIndex != -1) {
				dgDeficiency.Item(0, 0) = 1;
			}
			//-------------


			//code added by ; dinesh wagh on 30.6.2010
			//---------------------------------------------------
			objDV = dgDeficiency.DataSource;

			switch (mintColumnIndex) {
				case EnumColumns.DetailOfDeficiency:
					intWidth = CONST_DetailsOfDeficiency_Size;
				case EnumColumns.CorrectiveAction:
					intWidth = CONST_CorrectiveAction_Size;
				case EnumColumns.ActionBy:
					intWidth = CONST_ActionBy_Size;
			}

			if (objDV.Count > 0 & objDV.Count > mintRowIndex) {

				if (mintColumnIndex == EnumColumns.DetailOfDeficiency | mintColumnIndex == EnumColumns.CorrectiveAction | mintColumnIndex == EnumColumns.ActionBy) {
					if (!IsDBNull(objDV(mintRowIndex).Row(mintColumnIndex))) {
						objDV(mintRowIndex).Row(mintColumnIndex) = gfuncWordWrap(objDV(mintRowIndex).Row(mintColumnIndex), intWidth);
						dgDeficiency.DataSource = objDV;
					}

				}
			}
			mintRowIndex = dgDeficiency.CurrentCell.RowNumber;
			mintColumnIndex = dgDeficiency.CurrentCell.ColumnNumber;
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

	private void  // ERROR: Handles clauses are not supported in C#
dgCompletedAccepted_CurrentCellChanged(object sender, System.EventArgs e)
	{
		try {
			mobjCADataTable.Columns(0).ReadOnly = false;

			if (mobjCADataTable.Rows.Count == 0) {
				mobjCADataTable.Columns(0).DefaultValue = 1;
			} else {
				dgCompletedAccepted.Item(dgCompletedAccepted.CurrentRowIndex, 0) = dgCompletedAccepted.CurrentRowIndex + 1;
			}

			mobjCADataTable.Columns(0).ReadOnly = true;
			if (dgCompletedAccepted.CurrentRowIndex >= 2) {
				mobjDataView1.AllowNew = false;
			}

			//-------16.6.2010  by dinesh wagh 
			if (mobjCADataTable.Rows.Count == 0 & dgCompletedAccepted.CurrentRowIndex != -1) {
				dgCompletedAccepted.Item(0, 0) = 1;
			}
		//-------------

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
Panel1_Paint(System.Object sender, System.Windows.Forms.PaintEventArgs e)
	{
	}
}
