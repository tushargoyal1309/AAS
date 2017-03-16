
using System.Data;
using System.Data.OleDb;

public class frmIQApproval : System.Windows.Forms.Form
{

	#Region " Module level Declarations "
	private bool mblnModeLockStatus;
	private int mintMode;
	private DataView mobjDataView = new DataView();
	private DataTable mObjDataTable;
	DataGridTableStyle mobjGridTableStyle = new DataGridTableStyle();
	DateTimePicker mdtpCustDate;
		#End Region
	private const  CONST_DateColumnNo = 4;

	#Region " Windows Form Designer generated code "

	public frmIQApproval()
	{
		base.New();

		//This call is required by the Windows Form Designer.
		InitializeComponent();

		//Add any initialization after the InitializeComponent() call

	}

	public frmIQApproval(int intMode)
	{
		base.New();
		InitializeComponent();
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
	internal System.Windows.Forms.RichTextBox rchtxtIQApproval1;
	internal System.Windows.Forms.RichTextBox rchtxtIQApproval2;
	internal System.Windows.Forms.Label lblHeader3;
	internal System.Windows.Forms.Label lblSupplierHeading;
	internal System.Windows.Forms.Label lblCustomerHeading;
	internal System.Windows.Forms.Label lblName;
	internal System.Windows.Forms.TextBox txtName;
	internal System.Windows.Forms.Label lblDesignation;
	internal System.Windows.Forms.Label lblCompanyName;
	internal System.Windows.Forms.Label lblDate;
	internal System.Windows.Forms.TextBox txtDesignation;
	internal System.Windows.Forms.TextBox txtCompanyName;
	internal System.Windows.Forms.DateTimePicker dtpDate;
	internal System.Windows.Forms.TextBox txtSupplierID;
	internal System.Windows.Forms.TextBox txtJointFunctionalArea;
	internal System.Windows.Forms.Panel Panel1;
	internal System.Windows.Forms.DataGrid dgCustomer;
	internal System.Windows.Forms.Panel Panel2;
	internal System.Windows.Forms.Label lblHeader2;
	internal System.Windows.Forms.PictureBox PictureBox1;
	[System.Diagnostics.DebuggerStepThrough()]
	private void InitializeComponent()
	{
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmIQApproval));
		this.txtJointFunctionalArea = new System.Windows.Forms.TextBox();
		this.txtSupplierID = new System.Windows.Forms.TextBox();
		this.dtpDate = new System.Windows.Forms.DateTimePicker();
		this.txtCompanyName = new System.Windows.Forms.TextBox();
		this.txtDesignation = new System.Windows.Forms.TextBox();
		this.lblDate = new System.Windows.Forms.Label();
		this.lblCompanyName = new System.Windows.Forms.Label();
		this.lblDesignation = new System.Windows.Forms.Label();
		this.txtName = new System.Windows.Forms.TextBox();
		this.lblName = new System.Windows.Forms.Label();
		this.lblCustomerHeading = new System.Windows.Forms.Label();
		this.lblSupplierHeading = new System.Windows.Forms.Label();
		this.lblHeader3 = new System.Windows.Forms.Label();
		this.rchtxtIQApproval2 = new System.Windows.Forms.RichTextBox();
		this.rchtxtIQApproval1 = new System.Windows.Forms.RichTextBox();
		this.Panel1 = new System.Windows.Forms.Panel();
		this.Panel2 = new System.Windows.Forms.Panel();
		this.PictureBox1 = new System.Windows.Forms.PictureBox();
		this.lblHeader2 = new System.Windows.Forms.Label();
		this.dgCustomer = new System.Windows.Forms.DataGrid();
		this.Panel1.SuspendLayout();
		this.Panel2.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.dgCustomer).BeginInit();
		this.SuspendLayout();
		//
		//txtJointFunctionalArea
		//
		this.txtJointFunctionalArea.BackColor = System.Drawing.Color.White;
		this.txtJointFunctionalArea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txtJointFunctionalArea.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.txtJointFunctionalArea.Location = new System.Drawing.Point(128, 64);
		this.txtJointFunctionalArea.MaxLength = 40;
		this.txtJointFunctionalArea.Name = "txtJointFunctionalArea";
		this.txtJointFunctionalArea.Size = new System.Drawing.Size(432, 21);
		this.txtJointFunctionalArea.TabIndex = 19;
		this.txtJointFunctionalArea.Text = "";
		//
		//txtSupplierID
		//
		this.txtSupplierID.BackColor = System.Drawing.Color.AliceBlue;
		this.txtSupplierID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txtSupplierID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.txtSupplierID.Location = new System.Drawing.Point(16, 216);
		this.txtSupplierID.Name = "txtSupplierID";
		this.txtSupplierID.Size = new System.Drawing.Size(144, 22);
		this.txtSupplierID.TabIndex = 18;
		this.txtSupplierID.Text = "";
		this.txtSupplierID.Visible = false;
		//
		//dtpDate
		//
		this.dtpDate.CalendarMonthBackground = System.Drawing.Color.AliceBlue;
		this.dtpDate.CalendarTitleForeColor = System.Drawing.Color.AliceBlue;
		this.dtpDate.CustomFormat = "dd-MMM-yyyy";
		this.dtpDate.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
		this.dtpDate.Location = new System.Drawing.Point(452, 216);
		this.dtpDate.Name = "dtpDate";
		this.dtpDate.Size = new System.Drawing.Size(121, 21);
		this.dtpDate.TabIndex = 17;
		//
		//txtCompanyName
		//
		this.txtCompanyName.BackColor = System.Drawing.Color.AliceBlue;
		this.txtCompanyName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txtCompanyName.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.txtCompanyName.Location = new System.Drawing.Point(304, 216);
		this.txtCompanyName.MaxLength = 40;
		this.txtCompanyName.Name = "txtCompanyName";
		this.txtCompanyName.Size = new System.Drawing.Size(152, 22);
		this.txtCompanyName.TabIndex = 16;
		this.txtCompanyName.Text = "";
		//
		//txtDesignation
		//
		this.txtDesignation.BackColor = System.Drawing.Color.AliceBlue;
		this.txtDesignation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txtDesignation.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.txtDesignation.Location = new System.Drawing.Point(152, 216);
		this.txtDesignation.MaxLength = 40;
		this.txtDesignation.Name = "txtDesignation";
		this.txtDesignation.Size = new System.Drawing.Size(152, 22);
		this.txtDesignation.TabIndex = 15;
		this.txtDesignation.Text = "";
		//
		//lblDate
		//
		this.lblDate.BackColor = System.Drawing.Color.FromArgb((byte)205, (byte)225, (byte)250);
		this.lblDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblDate.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblDate.ForeColor = System.Drawing.SystemColors.ControlText;
		this.lblDate.Location = new System.Drawing.Point(453, 192);
		this.lblDate.Name = "lblDate";
		this.lblDate.Size = new System.Drawing.Size(120, 23);
		this.lblDate.TabIndex = 14;
		this.lblDate.Text = "Date";
		this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		//
		//lblCompanyName
		//
		this.lblCompanyName.BackColor = System.Drawing.Color.FromArgb((byte)205, (byte)225, (byte)250);
		this.lblCompanyName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblCompanyName.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblCompanyName.ForeColor = System.Drawing.SystemColors.ControlText;
		this.lblCompanyName.Location = new System.Drawing.Point(304, 192);
		this.lblCompanyName.Name = "lblCompanyName";
		this.lblCompanyName.Size = new System.Drawing.Size(152, 23);
		this.lblCompanyName.TabIndex = 13;
		this.lblCompanyName.Text = "Name of Company";
		this.lblCompanyName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		//
		//lblDesignation
		//
		this.lblDesignation.BackColor = System.Drawing.Color.FromArgb((byte)205, (byte)225, (byte)250);
		this.lblDesignation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblDesignation.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblDesignation.ForeColor = System.Drawing.SystemColors.ControlText;
		this.lblDesignation.Location = new System.Drawing.Point(152, 192);
		this.lblDesignation.Name = "lblDesignation";
		this.lblDesignation.Size = new System.Drawing.Size(152, 23);
		this.lblDesignation.TabIndex = 12;
		this.lblDesignation.Text = "Designation";
		this.lblDesignation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		//
		//txtName
		//
		this.txtName.BackColor = System.Drawing.Color.AliceBlue;
		this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txtName.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.txtName.Location = new System.Drawing.Point(8, 216);
		this.txtName.MaxLength = 40;
		this.txtName.Name = "txtName";
		this.txtName.Size = new System.Drawing.Size(144, 22);
		this.txtName.TabIndex = 11;
		this.txtName.Text = "";
		//
		//lblName
		//
		this.lblName.BackColor = System.Drawing.Color.FromArgb((byte)205, (byte)225, (byte)250);
		this.lblName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblName.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblName.ForeColor = System.Drawing.SystemColors.ControlText;
		this.lblName.Location = new System.Drawing.Point(8, 192);
		this.lblName.Name = "lblName";
		this.lblName.Size = new System.Drawing.Size(144, 23);
		this.lblName.TabIndex = 10;
		this.lblName.Text = "Name";
		this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		//
		//lblCustomerHeading
		//
		this.lblCustomerHeading.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblCustomerHeading.ForeColor = System.Drawing.SystemColors.ControlText;
		this.lblCustomerHeading.Location = new System.Drawing.Point(8, 248);
		this.lblCustomerHeading.Name = "lblCustomerHeading";
		this.lblCustomerHeading.Size = new System.Drawing.Size(368, 15);
		this.lblCustomerHeading.TabIndex = 9;
		this.lblCustomerHeading.Text = "Customer's Representative  - ";
		//
		//lblSupplierHeading
		//
		this.lblSupplierHeading.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblSupplierHeading.ForeColor = System.Drawing.SystemColors.ControlText;
		this.lblSupplierHeading.Location = new System.Drawing.Point(8, 168);
		this.lblSupplierHeading.Name = "lblSupplierHeading";
		this.lblSupplierHeading.Size = new System.Drawing.Size(368, 18);
		this.lblSupplierHeading.TabIndex = 8;
		this.lblSupplierHeading.Text = "Manufacturer's / Supplier's Representative - ";
		//
		//lblHeader3
		//
		this.lblHeader3.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblHeader3.Location = new System.Drawing.Point(8, 64);
		this.lblHeader3.Name = "lblHeader3";
		this.lblHeader3.Size = new System.Drawing.Size(120, 16);
		this.lblHeader3.TabIndex = 5;
		this.lblHeader3.Text = "Functional Area";
		this.lblHeader3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//rchtxtIQApproval2
		//
		this.rchtxtIQApproval2.AutoSize = true;
		this.rchtxtIQApproval2.BackColor = System.Drawing.Color.AliceBlue;
		this.rchtxtIQApproval2.BorderStyle = System.Windows.Forms.BorderStyle.None;
		this.rchtxtIQApproval2.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.rchtxtIQApproval2.Location = new System.Drawing.Point(8, 88);
		this.rchtxtIQApproval2.Name = "rchtxtIQApproval2";
		this.rchtxtIQApproval2.ReadOnly = true;
		this.rchtxtIQApproval2.Size = new System.Drawing.Size(547, 72);
		this.rchtxtIQApproval2.TabIndex = 4;
		this.rchtxtIQApproval2.Text = "RichTextBox1";
		//
		//rchtxtIQApproval1
		//
		this.rchtxtIQApproval1.AutoSize = true;
		this.rchtxtIQApproval1.BackColor = System.Drawing.Color.AliceBlue;
		this.rchtxtIQApproval1.BorderStyle = System.Windows.Forms.BorderStyle.None;
		this.rchtxtIQApproval1.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.rchtxtIQApproval1.Location = new System.Drawing.Point(8, 40);
		this.rchtxtIQApproval1.Name = "rchtxtIQApproval1";
		this.rchtxtIQApproval1.Size = new System.Drawing.Size(520, 16);
		this.rchtxtIQApproval1.TabIndex = 1;
		this.rchtxtIQApproval1.Text = "RichTextBox1";
		//
		//Panel1
		//
		this.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.Panel1.Controls.Add(this.Panel2);
		this.Panel1.Controls.Add(this.dgCustomer);
		this.Panel1.Controls.Add(this.txtJointFunctionalArea);
		this.Panel1.Controls.Add(this.lblHeader3);
		this.Panel1.Controls.Add(this.rchtxtIQApproval2);
		this.Panel1.Controls.Add(this.rchtxtIQApproval1);
		this.Panel1.Controls.Add(this.lblSupplierHeading);
		this.Panel1.Controls.Add(this.lblCustomerHeading);
		this.Panel1.Controls.Add(this.lblName);
		this.Panel1.Controls.Add(this.txtName);
		this.Panel1.Controls.Add(this.lblDesignation);
		this.Panel1.Controls.Add(this.lblCompanyName);
		this.Panel1.Controls.Add(this.lblDate);
		this.Panel1.Controls.Add(this.txtDesignation);
		this.Panel1.Controls.Add(this.txtCompanyName);
		this.Panel1.Controls.Add(this.dtpDate);
		this.Panel1.Controls.Add(this.txtSupplierID);
		this.Panel1.Dock = System.Windows.Forms.DockStyle.Top;
		this.Panel1.Location = new System.Drawing.Point(0, 0);
		this.Panel1.Name = "Panel1";
		this.Panel1.Size = new System.Drawing.Size(474, 510);
		this.Panel1.TabIndex = 11;
		//
		//Panel2
		//
		this.Panel2.BackColor = System.Drawing.Color.AliceBlue;
		this.Panel2.Controls.Add(this.PictureBox1);
		this.Panel2.Controls.Add(this.lblHeader2);
		this.Panel2.Dock = System.Windows.Forms.DockStyle.Top;
		this.Panel2.Location = new System.Drawing.Point(0, 0);
		this.Panel2.Name = "Panel2";
		this.Panel2.Size = new System.Drawing.Size(472, 32);
		this.Panel2.TabIndex = 20;
		//
		//PictureBox1
		//
		this.PictureBox1.Image = (System.Drawing.Image)resources.GetObject("PictureBox1.Image");
		this.PictureBox1.Location = new System.Drawing.Point(0, 0);
		this.PictureBox1.Name = "PictureBox1";
		this.PictureBox1.Size = new System.Drawing.Size(32, 32);
		this.PictureBox1.TabIndex = 2;
		this.PictureBox1.TabStop = false;
		//
		//lblHeader2
		//
		this.lblHeader2.BackColor = System.Drawing.Color.AliceBlue;
		this.lblHeader2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.lblHeader2.Font = new System.Drawing.Font("Arial", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblHeader2.ForeColor = System.Drawing.SystemColors.ControlText;
		this.lblHeader2.Location = new System.Drawing.Point(35, 7);
		this.lblHeader2.Name = "lblHeader2";
		this.lblHeader2.Size = new System.Drawing.Size(376, 18);
		this.lblHeader2.TabIndex = 1;
		this.lblHeader2.Text = "C. Approval";
		this.lblHeader2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//dgCustomer
		//
		this.dgCustomer.AllowSorting = false;
		this.dgCustomer.AlternatingBackColor = System.Drawing.Color.AliceBlue;
		this.dgCustomer.BackColor = System.Drawing.Color.LightSkyBlue;
		this.dgCustomer.BackgroundColor = System.Drawing.Color.AliceBlue;
		this.dgCustomer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.dgCustomer.CaptionBackColor = System.Drawing.Color.LightSkyBlue;
		this.dgCustomer.CaptionFont = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.dgCustomer.CaptionForeColor = System.Drawing.Color.AliceBlue;
		this.dgCustomer.CaptionVisible = false;
		this.dgCustomer.DataMember = "";
		this.dgCustomer.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.dgCustomer.HeaderForeColor = System.Drawing.SystemColors.ControlText;
		this.dgCustomer.Location = new System.Drawing.Point(8, 272);
		this.dgCustomer.Name = "dgCustomer";
		this.dgCustomer.ParentRowsVisible = false;
		this.dgCustomer.ReadOnly = true;
		this.dgCustomer.RowHeadersVisible = false;
		this.dgCustomer.Size = new System.Drawing.Size(565, 232);
		this.dgCustomer.TabIndex = 18;
		//
		//frmIQApproval
		//
		this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
		this.AutoScroll = true;
		this.BackColor = System.Drawing.Color.AliceBlue;
		this.ClientSize = new System.Drawing.Size(474, 386);
		this.ControlBox = false;
		this.Controls.Add(this.Panel1);
		this.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		this.MaximizeBox = false;
		this.MinimizeBox = false;
		this.Name = "frmIQApproval";
		this.Tag = "Installation Approval";
		this.Text = "Installation Approval";
		this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
		this.Panel1.ResumeLayout(false);
		this.Panel2.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.dgCustomer).EndInit();
		this.ResumeLayout(false);

	}

	#End Region

	#Region "Constants"

	private const string ConstSrNo = "SrNo";
	private const string ConstName = "Name";
	private const string ConstDesignation = "Designation";
	private const string ConstFunctionalArea = "FunctionalArea";
	private const string ConstCustDate = "CustDate";
	private const string ConstCustomerRepresentativeID = "CustomerRepresentativeID";

	#End Region

	#Region " Form Events "

	private void  // ERROR: Handles clauses are not supported in C#
frmIQApproval_Load(System.Object sender, System.EventArgs e)
	{
		try {
			funcInitialize();
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
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


	private void  // ERROR: Handles clauses are not supported in C#
frmIQApproval_Closing(object sender, System.ComponentModel.CancelEventArgs e)
	{
		try {
			if (!(mblnModeLockStatus)) {
				if (!funcSaveSupplierData()) {
					throw new Exception("Error in Saving Manufacturer/Supplier Representative Data.");
				}
				dgCustomer.CurrentCell() = (new DataGridCell(dgCustomer.CurrentRowIndex + 1, 0));
				if (!funcSaveCustomerData()) {
					throw new Exception("Error in Saving Customer Representative Data.");
				}
				dgCustomer.TableStyles.Clear();
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
	//    General functions used for Approval.
	//--- funcInitialize - To Initialize form and to get values for Approval from database and display them.
	//--- funcGetSupplierRecords - To Get Manufacturer / Supplier Records from Database.
	//--- subCreateDataTable - To Create Columns in the Data Table.
	//--- funcGetCustomerRecords - To Get Customer Records from Database into DataTable.
	//--- subFormatDataGrid - To format the Data Grid.
	//--- funcSaveSupplierData - To Save the Entered Records into Database.
	//--- funcSaveCustomerData - To Save the Entered Records into Database.
	//--- funcInsertSupplierData - To Add/Insert New Supplier Data in Database.
	//--- funcUpdateSupplierData - To Update Supplier Data in Database.
	//--- funcDeleteSupplierData - To Delete Supplier Data from Database.
	//--- funcInsertCustomerData - To Add/Insert New Customer Data in Database.
	//--- funcUpdateCustomerData - To Update Customer Data in Database.
	//--- funcDeleteCustomerData - To Delete Customer Data from Database.

	private void funcInitialize()
	{
		//=====================================================================
		// Procedure Name        :   funcInitailize
		// Description           :   To Initialize form and to get values for Approval from database and display them.
		// Purpose               :   To Initialize form and to get values for Approval from database and display them.
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
			switch (mintMode) {
				case ENUM_IQOQPQ_STATUS.IQ:
					//mfrmIQApproval = Me

					funcAprovalTextFormatForIQ();
				case ENUM_IQOQPQ_STATUS.OQ:
					//mfrmOQApproval = Me

					funcAprovalTextFormatForOQ();
				case ENUM_IQOQPQ_STATUS.PQ:
					//mfrmPQApproval = Me
					funcAprovalTextFormatForPQ();
			}

			//--- To clear Text Fields
			txtName.Text = "";
			txtSupplierID.Text = "";
			txtCompanyName.Text = "";
			txtDesignation.Text = "";
			txtJointFunctionalArea.Text = "";

			mdtpCustDate = new DateTimePicker();

			mdtpCustDate.ValueChanged += dtpCustDate_ValueChanged;
			dgCustomer.Controls.Add(mdtpCustDate);
			mdtpCustDate.Visible = false;
			mdtpCustDate.Format = DateTimePickerFormat.Custom;
			mdtpCustDate.CustomFormat = "dd-MMM-yyyy";

			objDtTmp = new DataTable();

			objDtTmp = gobjDataAccess.funcGetSupplierRecords(mintMode);

			if (!objDtTmp == null) {
				if (!objDtTmp.Rows.Count == 0) {
					txtName.Text = (string)objDtTmp.Rows.Item(0).Item("Name");
					txtSupplierID.Text = (string)objDtTmp.Rows.Item(0).Item("ManufacturerRepresentativeID");
					txtCompanyName.Text = (string)objDtTmp.Rows.Item(0).Item("Company");
					txtDesignation.Text = (string)objDtTmp.Rows.Item(0).Item("Designation");
					txtJointFunctionalArea.Text = (string)objDtTmp.Rows.Item(0).Item("JointFunctionalArea");
					//dtpDate.Value = CDate(objDtTmp.Rows.Item(0).Item("ManDate"))
				}
			} else {
				throw new Exception("Error in Getting Manufacturer/Supplier Representative Records.");
			}
			//If Not funcGetSupplierRecords() Then
			//    Throw New Exception("Error in Getting Manufacturer/Supplier Representative Records.")
			//End If

			mObjDataTable = new DataTable("CustomerRepresentative");
			subCreateCustomerDataTable();
			objDtTmp = new DataTable();

			objDtTmp = gobjDataAccess.funcGetCustomerRecords(mintMode);

			if (!objDtTmp == null) {
				if (!objDtTmp.Rows.Count == 0) {
					for (intCount = 0; intCount <= objDtTmp.Rows.Count - 1; intCount++) {
						objDataRow = mObjDataTable.NewRow;
						//objDataRow.Item(ConstSrNo) = CInt(objDtTmp.Rows.Item(intCount).Item("CustomerRepresentativeID"))
						//Added by pankaj on 6 Dec 07
						objDataRow.Item(ConstSrNo) = intCount + 1;
						//CInt(objDtTmp.Rows.Item(intCount).Item("CustomerRepresentativeID"))
						//--------
						objDataRow.Item(ConstName) = (string)objDtTmp.Rows.Item(intCount).Item("Name");
						objDataRow.Item(ConstDesignation) = (string)objDtTmp.Rows.Item(intCount).Item("Designation");
						objDataRow.Item(ConstFunctionalArea) = (string)objDtTmp.Rows.Item(intCount).Item("FunctionalArea");
						objDataRow.Item(ConstCustDate) = (System.DateTime)objDtTmp.Rows.Item(intCount).Item("CustDate");
						objDataRow.Item(ConstCustomerRepresentativeID) = (int)objDtTmp.Rows.Item(intCount).Item("CustomerRepresentativeID");
						mObjDataTable.Rows.Add(objDataRow);
					}
				}
			}


			if (IsNothing(mObjDataTable) == true) {
				throw new Exception("Error in Getting Equipment List Records.");
			} else {
				subFormatCustomerDataGrid();
			}
			//If funcGetCustomerRecords() Then
			//    subFormatCustomerDataGrid()
			//Else
			//    Throw New Exception("Error in Getting Customer Representative Data.")
			//End If

			mblnModeLockStatus = gobjDataAccess.funcCheckModeLocked(mintMode);
			if ((mblnModeLockStatus)) {
				dgCustomer.ReadOnly = true;
				txtJointFunctionalArea.ReadOnly = true;
				txtCompanyName.ReadOnly = true;
				txtDesignation.ReadOnly = true;
				txtName.ReadOnly = true;
				dtpDate.Enabled = false;
				mdtpCustDate.Enabled = false;
				//added by pankaj on 6 Dec 07
				mdtpCustDate.Width = 0;
			} else {
				dgCustomer.ReadOnly = false;
				txtJointFunctionalArea.ReadOnly = false;
				txtCompanyName.ReadOnly = false;
				txtDesignation.ReadOnly = false;
				txtName.ReadOnly = false;
				dtpDate.Enabled = true;
				mdtpCustDate.Enabled = true;
				//added by pankaj on 6 Dec 07
			}
		} catch (Exception ex) {
			//---------------------------------------------------------
			//--- Error logging
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

	private void dtpCustDate_ValueChanged(System.Object sender, System.EventArgs e)
	{
		//try catch added by ; dinesh wagh on 3.2.2010
		try {
			dgCustomer(dgCustomer.CurrentCell.RowNumber, dgCustomer.CurrentCell.ColumnNumber) = mdtpCustDate.Value;
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

	#Region "Customer Records Functions"

	private void subCreateCustomerDataTable()
	{
		//=====================================================================
		// Procedure Name        :   subCreateCustomerDataTable
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
			mObjDataTable.Columns.Add(new DataColumn("Designation", typeof(string)));
			mObjDataTable.Columns.Add(new DataColumn("FunctionalArea", typeof(string)));
			mObjDataTable.Columns.Add(new DataColumn("CustDate", typeof(System.DateTime)));
			mObjDataTable.Columns.Add(new DataColumn("CustomerRepresentativeID", typeof(int)));
		} catch (Exception ex) {
			//---------------------------------------------------------
			//--- Error logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = "Unable to Create Customer Representative Data Table.";
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

	//Private Function funcGetCustomerRecords() As Boolean
	//    '=====================================================================
	//    ' Procedure Name        :   funcGetCustomerRecords
	//    ' Description           :   To Get Customer Records from Database into DataTable.
	//    ' Purpose               :   To Get Customer Records from Database into DataTable.
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
	//        sql_string = "Select CustomerRepresentativeID ,Name ,Designation ,FunctionalArea ,CustDate from CustomerRepresentative where CheckStatusIQOQPQ = " & mintMode & " "

	//        'reader_status = gclsDBFunctions.GetRecords(sql_string, gOleDBIQOQPQConnection, objReader)

	//        If Not (reader_status) Then
	//            Return False
	//        End If

	//        rec_cnt = 1
	//        While objReader.Read
	//            objDataRow = mObjDataTable.NewRow()

	//            objDataRow("SrNo") = rec_cnt
	//            objDataRow("Name") = CStr(objReader.Item("Name"))
	//            objDataRow("Designation") = CStr(objReader.Item("Designation"))
	//            objDataRow("FunctionalArea") = CStr(objReader.Item("FunctionalArea"))
	//            If IsDBNull(objReader.Item("CustDate")) Then
	//            Else
	//                objDataRow("CustDate") = CDate(objReader.Item("CustDate"))
	//            End If
	//            objDataRow("CustomerRepresentativeID") = Convert.ToInt32(objReader.Item("CustomerRepresentativeID"))

	//            mObjDataTable.Rows.Add(objDataRow)
	//            rec_cnt = rec_cnt + 1
	//        End While
	//        objReader.Close()

	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        '--- Error logging
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = "Error in Getting Customer Representative Records."
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

	//    Return True
	//End Function

	private void subFormatCustomerDataGrid()
	{
		DataGridTextBoxColumn objTextColumn;

		try {
			dgCustomer.TableStyles.Clear();
			mobjDataView.Table = mObjDataTable;
			mobjDataView.AllowNew = true;
			dgCustomer.DataSource = mobjDataView;
			//dgCustomer.ReadOnly = False

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

			mobjGridTableStyle.MappingName = "CustomerRepresentative";

			objTextColumn = new DataGridTextBoxColumn();
			objTextColumn.MappingName = "SrNo";
			objTextColumn.HeaderText = "Sr.No.";
			objTextColumn.Width = 40;
			objTextColumn.ReadOnly = true;
			objTextColumn.NullText = "";
			objTextColumn.Alignment = HorizontalAlignment.Center;
			mobjGridTableStyle.GridColumnStyles.Add(objTextColumn);

			objTextColumn = new DataGridTextBoxColumn();
			objTextColumn.MappingName = "Name";
			objTextColumn.HeaderText = "Name";
			objTextColumn.Width = 150;
			objTextColumn.ReadOnly = false;
			objTextColumn.NullText = "";
			objTextColumn.Alignment = HorizontalAlignment.Center;
			mobjGridTableStyle.GridColumnStyles.Add(objTextColumn);

			objTextColumn = new DataGridTextBoxColumn();
			objTextColumn.MappingName = "Designation";
			objTextColumn.HeaderText = "Designation";
			objTextColumn.Width = 150;
			objTextColumn.ReadOnly = false;
			objTextColumn.NullText = "";
			objTextColumn.Alignment = HorizontalAlignment.Center;
			mobjGridTableStyle.GridColumnStyles.Add(objTextColumn);

			objTextColumn = new DataGridTextBoxColumn();
			objTextColumn.MappingName = "FunctionalArea";
			objTextColumn.HeaderText = "Functional Area";
			objTextColumn.Width = 140;
			objTextColumn.ReadOnly = false;
			objTextColumn.NullText = "";
			objTextColumn.Alignment = HorizontalAlignment.Center;
			mobjGridTableStyle.GridColumnStyles.Add(objTextColumn);

			objTextColumn = new DataGridTextBoxColumn();
			objTextColumn.MappingName = "CustDate";
			objTextColumn.HeaderText = "Date";
			objTextColumn.Width = 80;
			objTextColumn.Format = "dd-MMM-yyyy";
			objTextColumn.ReadOnly = false;
			objTextColumn.NullText = "";
			objTextColumn.Alignment = HorizontalAlignment.Center;
			mobjGridTableStyle.GridColumnStyles.Add(objTextColumn);

			objTextColumn = new DataGridTextBoxColumn();
			objTextColumn.MappingName = "CustomerRepresentativeID";
			objTextColumn.HeaderText = "CustomerRepresentativeID";
			objTextColumn.Width = 0;
			objTextColumn.ReadOnly = true;
			objTextColumn.NullText = "";
			mobjGridTableStyle.GridColumnStyles.Add(objTextColumn);

			mobjGridTableStyle.GridLineColor = Color.Black;
			dgCustomer.TableStyles.Add(mobjGridTableStyle);

		} catch (Exception ex) {
			//---------------------------------------------------------
			//--- Error logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = "Unable To Format Data - Grid For Customer Representative Data.";
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

	//Private Function funcSaveCustomerData() As Boolean
	//    '=====================================================================
	//    ' Procedure Name        :   funcSaveCustomerData
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

	//    Dim intRecordCount, intCustomerID, temp_cnt As Integer
	//    Dim strName, strDesignation, strFunctionalArea As String
	//    Dim dtCustDate As DateTime
	//    Dim status As Boolean = True

	//    Try
	//        intRecordCount = mObjDataTable.Rows.Count

	//        For temp_cnt = 0 To (intRecordCount - 1)
	//            '--- To Check if Customer ID is Null.
	//            If IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("CustomerRepresentativeID").Ordinal)) Then
	//                If (IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("Name").Ordinal)) = False) Then
	//                    strName = CStr(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("Name").Ordinal))
	//                    If IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("Designation").Ordinal)) Then

	//                    Else
	//                        strDesignation = CStr(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("Designation").Ordinal))
	//                    End If
	//                    If IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("FunctionalArea").Ordinal)) Then
	//                    Else
	//                        strFunctionalArea = CStr(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("FunctionalArea").Ordinal))
	//                    End If
	//                    If IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("CustDate").Ordinal)) Then
	//                    Else
	//                        dtCustDate = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("CustDate").Ordinal)
	//                    End If
	//                    status = funcInsertCustomerData(strName, strDesignation, strFunctionalArea, dtCustDate)
	//                    If Not (status) Then
	//                        Throw New Exception("Error in Saving Customer Representative Data.")
	//                    End If
	//                End If
	//            Else
	//                If IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("Name").Ordinal)) Then
	//                    'Delete function if reqd.
	//                Else
	//                    intCustomerID = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("CustomerRepresentativeID").Ordinal)
	//                    strName = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("Name").Ordinal)
	//                    strDesignation = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("Designation").Ordinal)
	//                    strFunctionalArea = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("FunctionalArea").Ordinal)
	//                    If IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("CustDate").Ordinal)) Then
	//                    Else
	//                        dtCustDate = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("CustDate").Ordinal)
	//                    End If
	//                    status = funcUpdateCustomerData(strName, strDesignation, strFunctionalArea, dtCustDate, intCustomerID)
	//                    If Not (status) Then
	//                        Throw New Exception("Error in Updating Customer Representative Data.")
	//                    End If
	//                End If
	//            End If
	//        Next

	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        '--- Error logging
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = "Error in Saving Customer Representative Records."
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


	public bool funcSaveCustomerData()
	{
		//=====================================================================
		// Procedure Name        :   funcSaveCustomerData
		// Description           :   To Save the Entered Records into Database.
		// Purpose               :   To Save the Entered Records into Database.
		// Parameters Passed     :   None.
		// Returns               :   None.
		// Parameters Affected   :   None.
		// Assumptions           :
		// Dependencies          :
		// Author                :   M.Kamal
		// Created               :   May, 20,2004 
		// Revisions             :
		//=====================================================================

		int intRecordCount;
		int intCustomerID;
		int temp_cnt;
		string strName;
		string strDesignation;
		string strFunctionalArea;
		DateTime dtCustDate;
		bool status = true;

		try {
			dtCustDate = Now;
			intRecordCount = mObjDataTable.Rows.Count;

			for (temp_cnt = 0; temp_cnt <= (intRecordCount - 1); temp_cnt++) {
				//--- To Check if Customer ID is Null.
				if (IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("CustomerRepresentativeID").Ordinal))) {
					if ((IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("Name").Ordinal)) == false)) {
						strName = (string)mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("Name").Ordinal);
						strDesignation = (string)mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("Designation").Ordinal);
						strFunctionalArea = (string)mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("FunctionalArea").Ordinal);
						if (IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("CustDate").Ordinal)) == false) {
							dtCustDate = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("CustDate").Ordinal);
						}
						status = gobjDataAccess.funcInsertCustomerData(strName, strDesignation, strFunctionalArea, dtCustDate, mintMode);
						if (!(status)) {
							throw new Exception("Error in Saving Customer Representative Data.");
						}
					}
				} else {
					if (IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("Name").Ordinal)) | IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("Designation").Ordinal)) | IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("FunctionalArea").Ordinal)) | IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("CustDate").Ordinal))) {
						//Delete function if reqd.
						intCustomerID = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("CustomerRepresentativeID").Ordinal);
						status = gobjDataAccess.funcDeleteCustomerData(intCustomerID, mintMode);
						if (!(status)) {
							throw new Exception("Error in Deleting Customer Details.");
						}

					} else {
						intCustomerID = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("CustomerRepresentativeID").Ordinal);
						strName = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("Name").Ordinal);
						strDesignation = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("Designation").Ordinal);
						strFunctionalArea = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("FunctionalArea").Ordinal);
						if (IsDBNull(mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("CustDate").Ordinal))) {
							dtCustDate = mObjDataTable.Rows(temp_cnt).ItemArray.GetValue(mObjDataTable.Columns.Item("CustDate").Ordinal);
						}
						status = gobjDataAccess.funcUpdateCustomerDataApproval(strName, strDesignation, strFunctionalArea, dtCustDate, intCustomerID, mintMode);
						if (!(status)) {
							throw new Exception("Error in Updating Customer Representative Data.");
						}
					}
				}
			}

		} catch (Exception ex) {
			//---------------------------------------------------------
			//--- Error logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = "Error in Saving Customer Representative Records.";
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

	//Private Function funcInsertCustomerData(ByVal strName As String, ByVal strDesignation As String, ByVal strFunctionalArea As String, ByVal dtCustDate As DateTime) As Boolean
	//    '=====================================================================
	//    ' Procedure Name        :   funcInsertCustomerData
	//    ' Description           :   To Add/Insert New Customer Data in Database.
	//    ' Purpose               :   To Add/Insert New Customer Data in Database.
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
	//    Dim intCustomerID As Integer

	//    Try

	//        '--- Generating Next Customer ID. 
	//        'intCustomerID = gclsDBFunctions.GetNextID("CustomerRepresentative", "CustomerRepresentativeID", gOleDBIQOQPQConnection)

	//        '---  Query for adding  data 
	//        str_sql = " Insert into CustomerRepresentative " & _
	//                  " (CustomerRepresentativeID ,Name ,Designation ,CustDate ,CheckStatusIQOQPQ ,FunctionalArea) " & _
	//                  " values(" & intCustomerID & ", '" & strName & "','" & strDesignation & "','" & dtCustDate & "'," & mintMode & ",'" & strFunctionalArea & "') "
	//        '" values(?,?,?,?,?,?) "

	//        '--- Providing command object for EquimentList
	//        With objCommand
	//            '.Connection = gOleDBIQOQPQConnection
	//            .CommandType = CommandType.Text
	//            .CommandText = str_sql
	//            '.Parameters.Add("CustomerRepresentativeID", OleDbType.Numeric).Value = intCustomerID
	//            '.Parameters.Add("Name", OleDbType.VarChar, 50).Value = strName
	//            '.Parameters.Add("Designation", OleDbType.VarChar, 50).Value = strDesignation
	//            '.Parameters.Add("CustDate", OleDbType.DBDate).Value = dtCustDate
	//            '.Parameters.Add("FunctionalArea", OleDbType.VarChar, 50).Value = strFunctionalArea
	//            '.Parameters.Add("CheckStatusIQOQPQ", OleDbType.Single).Value = mintMode
	//            .ExecuteNonQuery()
	//        End With

	//        objCommand.Dispose()
	//        Status = True

	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        'Error logging
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = "Error in Saving Customer Representative Data."
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

	//Private Function funcUpdateCustomerData(ByVal strName As String, ByVal strDesignation As String, ByVal strFunctionalArea As String, ByVal dtCustDate As DateTime, ByVal intCustomerID As Integer) As Boolean
	//    '=====================================================================
	//    ' Procedure Name        :   funcUpdateCustomerData
	//    ' Description           :   To Update Customer Data in Database.
	//    ' Purpose               :   To Update Customer Data in Database.
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

	//        '---  Query for Updating data 
	//        str_sql = " Update CustomerRepresentative " & _
	//                  " Set Name = ? ,Designation = ? ,FunctionalArea =? ,CustDate = ? " & _
	//                  " where CustomerRepresentativeID = " & intCustomerID & " and CheckStatusIQOQPQ = " & mintMode & "  "

	//        '--- Providing command object for EquimentList
	//        With objCommand
	//            '.Connection = gOleDBIQOQPQConnection
	//            .CommandType = CommandType.Text
	//            .CommandText = str_sql
	//            .Parameters.Add("Name", OleDbType.VarChar, 50).Value = strName
	//            .Parameters.Add("Designation", OleDbType.VarChar, 50).Value = strDesignation
	//            .Parameters.Add("FunctionalArea", OleDbType.VarChar, 50).Value = strFunctionalArea
	//            .Parameters.Add("CustDate", OleDbType.DBDate).Value = dtCustDate
	//            .ExecuteNonQuery()
	//        End With

	//        objCommand.Dispose()
	//        Status = True

	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        'Error logging
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = "Error in Updating Customer Representative Records."
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

	//Private Function funcDeleteCustomerData(ByVal intCustomerID As Integer) As Boolean
	//    '=====================================================================
	//    ' Procedure Name        :   funcDeleteCustomerData
	//    ' Description           :   To Delete Customer Data from Database.
	//    ' Purpose               :   To Delete Customer Data from Database.
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

	//        '--- Query to Delete from Database
	//        str_sql = " Delete * from CustomerRepresentative " & _
	//                  " where CustomerRepresentativeID = " & intCustomerID & " and CheckStatusIQOQPQ = " & mintMode & "  "

	//        'Status = gclsDBFunctions.AddORDeleteRecord(str_sql, gOleDBIQOQPQConnection)
	//        If (Status = False) Then
	//            Throw New Exception("Error in Deleting Customer Representative Data.")
	//        End If

	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        'Error logging
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = "Error in Deleting Customer Representative Data."
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

	#Region "Supplier Records Functions"

	//Private Function funcGetSupplierRecords() As Boolean
	//    '=====================================================================
	//    ' Procedure Name        :   funcGetSupplierRecords
	//    ' Description           :   To Get Supplier Records from Database into DataTable.
	//    ' Purpose               :   To Get Supplier Records from Database into DataTable.
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
	//    Dim sql_string As String
	//    Dim reader_status As Boolean

	//    Try
	//        sql_string = "Select ManufacturerRepresentativeID ,Name ,Designation ,Company ,ManDate ,JointFunctionalArea from ManufacturerRepresentative where CheckStatusIQOQPQ = " & mintMode & " "

	//        'reader_status = gclsDBFunctions.GetRecords(sql_string, gOleDBIQOQPQConnection, objReader)

	//        If Not (reader_status) Then
	//            Throw New Exception("Error in Getting Manufacturer/Supplier Representative Data.")
	//        End If

	//        While objReader.Read()
	//            txtSupplierID.Text = CStr(objReader.Item("ManufacturerRepresentativeID"))
	//            txtName.Text = CStr(objReader.Item("Name"))
	//            txtDesignation.Text = CStr(objReader.Item("Designation"))
	//            txtCompanyName.Text = CStr(objReader.Item("Company"))
	//            dtpDate.Value = CDate(objReader.Item("ManDate"))
	//            txtJointFunctionalArea.Text = CStr(objReader.Item("JointFunctionalArea"))
	//        End While
	//        objReader.Close()

	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        'Error logging
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = ex.Message
	//        gobjErrorHandler.WriteErrorLog(ex)
	//        '---------------------------------------------------------           
	//        Return False
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

	public bool funcSaveSupplierData()
	{
		//=====================================================================
		// Procedure Name        :   funcSaveSupplierData
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
		int intSupplierID;
		int temp_cnt;
		string strName;
		string strDesignation;
		string strCompany;
		string strFunctionalArea;
		DateTime dtManDate;
		bool status = true;

		try {
			//--- To Check if Supplier ID is Null.
			if ((IsDBNull(txtSupplierID.Text) | txtSupplierID.Text == "")) {
				if ((txtName.Text == "")) {
				} else {
					strName = txtName.Text;
					strDesignation = txtDesignation.Text;
					strCompany = txtCompanyName.Text;
					dtManDate = dtpDate.Value;
					strFunctionalArea = txtJointFunctionalArea.Text;
					status = gobjDataAccess.funcInsertSupplierData(strName, strDesignation, strCompany, dtManDate, strFunctionalArea, mintMode);
					if (!(status)) {
						throw new Exception("Error in Saving Supplier Data.");
					}
				}
			} else {
				if (txtName.Text == "") {
				//Delete function if reqd.
				} else {
					intSupplierID = Convert.ToInt32(txtSupplierID.Text);
					strName = txtName.Text;
					strDesignation = txtDesignation.Text;
					strCompany = txtCompanyName.Text;
					dtManDate = dtpDate.Value;
					strFunctionalArea = txtJointFunctionalArea.Text;
					status = gobjDataAccess.funcUpdateSupplierData(strName, strDesignation, strCompany, dtManDate, strFunctionalArea, intSupplierID, mintMode);
					if (!(status)) {
						throw new Exception("Error in Updating Supplier Data.");
					}
				}
			}

		} catch (Exception ex) {
			//---------------------------------------------------------
			//--- Error logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = "Unable To Save Records in ManufacturerRepresentative table.";
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

		return status;

	}

	//Private Function funcInsertSupplierData(ByVal strName As String, ByVal strDesignation As String, ByVal strCompany As String, ByVal dtManDate As DateTime, ByVal strFunctionalArea As String) As Boolean
	//    '=====================================================================
	//    ' Procedure Name        :   funcInsertSupplierData
	//    ' Description           :   To Add/Insert New Supplier Data in Database.
	//    ' Purpose               :   To Add/Insert New Supplier Data in Database.
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
	//    Dim intSupplierID As Integer

	//    Try

	//        '--- Generating Next Customer ID. 
	//        'intSupplierID = gclsDBFunctions.GetNextID("ManufacturerRepresentative", "ManufacturerRepresentativeID", gOleDBIQOQPQConnection)

	//        '---  Query for adding  data 
	//        str_sql = " Insert into ManufacturerRepresentative " & _
	//                  " (ManufacturerRepresentativeID ,Name ,Designation ,Company ,ManDate ,JointFunctionalArea ,CheckStatusIQOQPQ) " & _
	//                  " values(" & intSupplierID & " ,'" & strName & "','" & strDesignation & "','" & strCompany & "','" & dtManDate & "' ,'" & strFunctionalArea & "' ," & mintMode & ") "

	//        '" values(?,?,?,?,?,?,?) "

	//        '--- Providing command object for EquimentList
	//        With objCommand
	//            '.Connection = gOleDBIQOQPQConnection
	//            .CommandType = CommandType.Text
	//            .CommandText = str_sql
	//            '.Parameters.Add("ManufacturerRepresentativeID", OleDbType.Numeric).Value = intSupplierID
	//            '.Parameters.Add("Name", OleDbType.VarChar, 50).Value = strName
	//            '.Parameters.Add("Designation", OleDbType.VarChar, 50).Value = strDesignation
	//            '.Parameters.Add("Company", OleDbType.VarChar, 50).Value = strCompany
	//            '.Parameters.Add("ManDate", OleDbType.DBDate).Value = dtManDate
	//            '.Parameters.Add("JointFunctionalArea", OleDbType.VarChar, 50).Value = strFunctionalArea
	//            '.Parameters.Add("CheckStatusIQOQPQ", OleDbType.Single).Value = mintMode
	//            .ExecuteNonQuery()
	//        End With

	//        objCommand.Dispose()
	//        Status = True

	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        'Error logging
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = "Records Could Not be Inserted."
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

	//Private Function funcUpdateSupplierData(ByVal strName As String, ByVal strDesignation As String, ByVal strCompany As String, ByVal dtManDate As DateTime, ByVal strFunctionalArea As String, ByVal intSupplierID As Integer) As Boolean
	//    '=====================================================================
	//    ' Procedure Name        :   funcUpdateSupplierData
	//    ' Description           :   To Update Supplier Data in Database.
	//    ' Purpose               :   To Update Supplier Data in Database.
	//    ' Parameters Passed     :   None.
	//    ' Returns               :   None.
	//    ' Parameters Affected   :   None.
	//    ' Assumptions           :
	//    ' Dependencies          :
	//    ' Author                :   Gitesh
	//    ' Created               :   January, 2003 
	//    ' Revisions             :
	//    '=====================================================================
	//    Dim str_sql As String
	//    Dim objCommand As New OleDbCommand
	//    Try
	//        '---  Query for Updating data 
	//        str_sql = " Update ManufacturerRepresentative " & _
	//                  " Set Name = ? ,Designation = ? ,Company = ? ,JointFunctionalArea =? ,ManDate = ? " & _
	//                  " where ManufacturerRepresentativeID = " & intSupplierID & " and CheckStatusIQOQPQ = " & mintMode & "  "

	//        '--- Providing command object for EquimentList
	//        With objCommand
	//            '.Connection = gOleDBIQOQPQConnection
	//            .CommandType = CommandType.Text
	//            .CommandText = str_sql
	//            .Parameters.Add("Name", OleDbType.VarChar, 250).Value = strName
	//            .Parameters.Add("Designation", OleDbType.VarChar, 250).Value = strDesignation
	//            .Parameters.Add("Company", OleDbType.VarChar, 250).Value = strCompany
	//            .Parameters.Add("JointFunctionalArea", OleDbType.VarChar, 250).Value = strFunctionalArea
	//            .Parameters.Add("ManDate", OleDbType.DBDate).Value = dtManDate
	//            .ExecuteNonQuery()
	//        End With

	//        objCommand.Dispose()

	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        'Error logging
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = "Records Could Not be Updated."
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

	//End Function

	//Private Function funcDeleteSupplierData(ByVal intSupplierID As Integer) As Boolean
	//    '=====================================================================
	//    ' Procedure Name        :   funcDeleteSupplierData
	//    ' Description           :   To Delete Supplier Data from Database.
	//    ' Purpose               :   To Delete Supplier Data from Database.
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
	//        '--- Query to Delete from Database
	//        str_sql = " Delete * from ManufacturerRepresentative " & _
	//                  " where ManufacturerRepresentativeID = " & intSupplierID & " and CheckStatusIQOQPQ = " & mintMode & "  "

	//        'Status = gclsDBFunctions.AddORDeleteRecord(str_sql, gOleDBIQOQPQConnection)
	//        If (Status = False) Then
	//            Throw New Exception("Error in Deleting Manufacturer/Supplier Representative Data.")
	//        End If

	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        'Error Handling and logging
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = "Records Could Not be Deleted."
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

	#Region "Text for Screen"

	#Region "TextFormat for IQ"

	private void funcAprovalTextFormatForIQ()
	{
		//try catch added by ; dinesh wagh on 3.2.2010
		try {
			//lblHeader1.Text = "C. INSTALLATION QUALIFICATION"
			lblHeader2.Text = "C. Approval";

			rchtxtIQApproval1.Multiline = true;

			//Assigning Text To rchtxtIQApproval1
			rchtxtIQApproval1.Text = "This Approval of Installation Qualification protocol will be responsibility of" + " following -: ";
			//Assigning Text To rchtxtIQApproval2
			rchtxtIQApproval2.Text = "Study data has determined that the system described in this document either meets all criteria " + "outlined in this Installation Qualification protocol, or exceptional conditions have been identified " + "and documentation included. Exceptional conditions, if any, have been addressed. The system is " + "ready for specified usage.";

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

	#Region "TextFormat for OQ"
	private void funcAprovalTextFormatForOQ()
	{
		//try catch added by ; dinesh wagh on 3.2.2010

		try {
			//lblHeader1.Text = "D. OPERATIONAL QUALIFICATION"
			lblHeader2.Text = "D. Approval";

			rchtxtIQApproval1.Multiline = true;

			//Assigning Text To rchtxtIQApproval1
			rchtxtIQApproval1.Text = "This Approval of Operational Qualification protocol will be responsibility of " + " following -: ";
			//Assigning Text To rchtxtIQApproval2
			rchtxtIQApproval2.Text = "Study data has determined that the system described in this document either meets all criteria " + "outlined in this Operational Qualification protocol, or exceptional conditions have been identified " + "and documentation included. Exceptional conditions, if any, have been addressed. The system is " + " ready for specified usage.";

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

	#Region "TextFormat for PQ"
	private void funcAprovalTextFormatForPQ()
	{
		//try catch added by ; dinesh wagh on 3.2.2010
		try {
			//lblHeader1.Text = "E. PERFORMANCE QUALIFICATION"
			lblHeader2.Text = "E. Approval";

			rchtxtIQApproval1.Multiline = true;

			//Assigning Text To rchtxtIQApproval1
			rchtxtIQApproval1.Text = "This Approval of Performance Qualification protocol will be responsibility of " + " following -: ";
			//Assigning Text To rchtxtIQApproval2
			rchtxtIQApproval2.Text = "Study data has determined that the system described in this document either meets all criteria " + "outlined in this Performance Qualification protocol, or exceptional conditions have been identified " + "and documentation included. Exceptional conditions, if any, have been addressed. The system is " + " ready for specified usage.";

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

	#End Region

	private void  // ERROR: Handles clauses are not supported in C#
dgCustomer_CurrentCellChanged(object sender, System.EventArgs e)
	{
		//try catch added b y : dinesh wagh on 3.2.2010
		try {
			if (!(mblnModeLockStatus)) {
				mObjDataTable.Columns(0).ReadOnly = false;

				if (mObjDataTable.Rows.Count == 0) {
					mObjDataTable.Columns(0).DefaultValue = 1;
				} else {
					dgCustomer.Item(dgCustomer.CurrentRowIndex, 0) = dgCustomer.CurrentRowIndex + 1;
				}

				mObjDataTable.Columns(0).ReadOnly = true;

				if ((dgCustomer.CurrentCell.ColumnNumber == CONST_DateColumnNo)) {
					mdtpCustDate.Top = dgCustomer.GetCurrentCellBounds().Top;
					mdtpCustDate.Left = dgCustomer.GetCurrentCellBounds().Left;
					mdtpCustDate.Width = dgCustomer.GetCurrentCellBounds().Width;
					mdtpCustDate.Height = dgCustomer.GetCurrentCellBounds().Height;


					if ((dgCustomer.CurrentCell.RowNumber) > 0) {
						if (IsDBNull(dgCustomer(dgCustomer.CurrentCell.RowNumber, CONST_DateColumnNo)) == false) {
							mdtpCustDate.Value = Format((System.DateTime)dgCustomer(dgCustomer.CurrentCell.RowNumber, CONST_DateColumnNo), "dd-MMM-yyyy");
						} else {
							mdtpCustDate.Value = Format(DateTime.Today, "dd-MMM-yyyy");
							dgCustomer(dgCustomer.CurrentCell.RowNumber, dgCustomer.CurrentCell.ColumnNumber) = mdtpCustDate.Value;
						}
					} else {
						dgCustomer(dgCustomer.CurrentCell.RowNumber, dgCustomer.CurrentCell.ColumnNumber) = mdtpCustDate.Value;
					}
					mdtpCustDate.Visible = true;
				} else {
					mdtpCustDate.Width = 0;
					mdtpCustDate.Visible = false;
				}
			}

			if (dgCustomer.CurrentRowIndex >= 10) {
				mobjDataView.AllowNew = false;
			}


			//-------3.2.2010
			if (mObjDataTable.Rows.Count == 0 & dgCustomer.CurrentRowIndex != -1) {
				dgCustomer.Item(0, 0) = 1;
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
dgCustomer_GotFocus(object sender, System.EventArgs e)
	{
		//try catch added by ; dinesh wagh on 3.2.2010
		try {
			mdtpCustDate.Visible = false;
		// dgCustomer.CurrentCell = New DataGridCell(dgCustomer.CurrentCell.RowNumber, 0)
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
dgCustomer_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
	{
		//try catch added by ; dinesh wagh on 3.2.2010
		try {
			if ((dgCustomer.CurrentCell.ColumnNumber == CONST_DateColumnNo)) {
				mdtpCustDate.Visible = true;
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
