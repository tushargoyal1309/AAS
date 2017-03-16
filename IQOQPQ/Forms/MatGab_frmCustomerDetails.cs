
using System.Data;
using System.Data.OleDb;


//#############################################################
//1. Database and table should be ready
//2. Function to display stored data
//3. Function to insert tha data to database.
//4. Function to update the data.
//5. lock functionality
//#############################################################
//#############################################################
//You can refer/use object like color analysis
//
//#############################################################



public class frmCustomerDetails : System.Windows.Forms.Form
{

	#Region " Module level Declarations "

	private const  CONST_RecordID = 1;
	#End Region

	#Region " Windows Form Designer generated code "

	public frmCustomerDetails()
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
	internal System.Windows.Forms.Label lblName;
	internal System.Windows.Forms.Label lblAddress;
	internal System.Windows.Forms.Label lblAttention;
	internal System.Windows.Forms.Label lblPhone;
	internal System.Windows.Forms.Label lblFax;
	internal System.Windows.Forms.Label lblDoneBy;
	internal System.Windows.Forms.Label lblCompletionDate;
	internal System.Windows.Forms.TextBox txtName;
	internal System.Windows.Forms.TextBox txtAttention;
	internal System.Windows.Forms.TextBox txtAddress;
	internal System.Windows.Forms.TextBox txtPhone;
	internal System.Windows.Forms.TextBox txtFax;
	internal System.Windows.Forms.TextBox txtDoneBy;
	internal System.Windows.Forms.DateTimePicker dtpCompletionDate;
	internal System.Windows.Forms.Panel Panel2;
	internal System.Windows.Forms.PictureBox PictureBox1;
	[System.Diagnostics.DebuggerStepThrough()]
	private void InitializeComponent()
	{
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmCustomerDetails));
		this.Panel1 = new System.Windows.Forms.Panel();
		this.Panel2 = new System.Windows.Forms.Panel();
		this.PictureBox1 = new System.Windows.Forms.PictureBox();
		this.lblHeader = new System.Windows.Forms.Label();
		this.dtpCompletionDate = new System.Windows.Forms.DateTimePicker();
		this.txtDoneBy = new System.Windows.Forms.TextBox();
		this.txtFax = new System.Windows.Forms.TextBox();
		this.txtPhone = new System.Windows.Forms.TextBox();
		this.txtAddress = new System.Windows.Forms.TextBox();
		this.txtAttention = new System.Windows.Forms.TextBox();
		this.txtName = new System.Windows.Forms.TextBox();
		this.lblCompletionDate = new System.Windows.Forms.Label();
		this.lblDoneBy = new System.Windows.Forms.Label();
		this.lblFax = new System.Windows.Forms.Label();
		this.lblPhone = new System.Windows.Forms.Label();
		this.lblAttention = new System.Windows.Forms.Label();
		this.lblAddress = new System.Windows.Forms.Label();
		this.lblName = new System.Windows.Forms.Label();
		this.Panel1.SuspendLayout();
		this.Panel2.SuspendLayout();
		this.SuspendLayout();
		//
		//Panel1
		//
		this.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.Panel1.Controls.Add(this.Panel2);
		this.Panel1.Controls.Add(this.dtpCompletionDate);
		this.Panel1.Controls.Add(this.txtDoneBy);
		this.Panel1.Controls.Add(this.txtFax);
		this.Panel1.Controls.Add(this.txtPhone);
		this.Panel1.Controls.Add(this.txtAddress);
		this.Panel1.Controls.Add(this.txtAttention);
		this.Panel1.Controls.Add(this.txtName);
		this.Panel1.Controls.Add(this.lblCompletionDate);
		this.Panel1.Controls.Add(this.lblDoneBy);
		this.Panel1.Controls.Add(this.lblFax);
		this.Panel1.Controls.Add(this.lblPhone);
		this.Panel1.Controls.Add(this.lblAttention);
		this.Panel1.Controls.Add(this.lblAddress);
		this.Panel1.Controls.Add(this.lblName);
		this.Panel1.Dock = System.Windows.Forms.DockStyle.Top;
		this.Panel1.Font = new System.Drawing.Font("Arial", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.Panel1.Location = new System.Drawing.Point(0, 0);
		this.Panel1.Name = "Panel1";
		this.Panel1.Size = new System.Drawing.Size(392, 456);
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
		this.Panel2.Size = new System.Drawing.Size(390, 32);
		this.Panel2.TabIndex = 0;
		//
		//PictureBox1
		//
		this.PictureBox1.Image = (System.Drawing.Image)resources.GetObject("PictureBox1.Image");
		this.PictureBox1.Location = new System.Drawing.Point(0, 0);
		this.PictureBox1.Name = "PictureBox1";
		this.PictureBox1.Size = new System.Drawing.Size(32, 32);
		this.PictureBox1.TabIndex = 11;
		this.PictureBox1.TabStop = false;
		//
		//lblHeader
		//
		this.lblHeader.Font = new System.Drawing.Font("Arial", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblHeader.Location = new System.Drawing.Point(35, 7);
		this.lblHeader.Name = "lblHeader";
		this.lblHeader.Size = new System.Drawing.Size(376, 18);
		this.lblHeader.TabIndex = 0;
		this.lblHeader.Text = "Customer Details";
		this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//dtpCompletionDate
		//
		this.dtpCompletionDate.CalendarFont = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.dtpCompletionDate.CustomFormat = "dd-MMM-yyyy";
		this.dtpCompletionDate.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.dtpCompletionDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
		this.dtpCompletionDate.Location = new System.Drawing.Point(128, 360);
		this.dtpCompletionDate.Name = "dtpCompletionDate";
		this.dtpCompletionDate.Size = new System.Drawing.Size(120, 21);
		this.dtpCompletionDate.TabIndex = 7;
		this.dtpCompletionDate.Value = new System.DateTime(2004, 5, 18, 0, 0, 0, 0);
		//
		//txtDoneBy
		//
		this.txtDoneBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txtDoneBy.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.txtDoneBy.Location = new System.Drawing.Point(128, 328);
		this.txtDoneBy.MaxLength = 50;
		this.txtDoneBy.Name = "txtDoneBy";
		this.txtDoneBy.Size = new System.Drawing.Size(456, 21);
		this.txtDoneBy.TabIndex = 6;
		this.txtDoneBy.Text = "";
		//
		//txtFax
		//
		this.txtFax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txtFax.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.txtFax.Location = new System.Drawing.Point(128, 296);
		this.txtFax.MaxLength = 20;
		this.txtFax.Name = "txtFax";
		this.txtFax.Size = new System.Drawing.Size(456, 21);
		this.txtFax.TabIndex = 5;
		this.txtFax.Text = "";
		//
		//txtPhone
		//
		this.txtPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txtPhone.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.txtPhone.Location = new System.Drawing.Point(128, 264);
		this.txtPhone.MaxLength = 45;
		this.txtPhone.Name = "txtPhone";
		this.txtPhone.Size = new System.Drawing.Size(456, 21);
		this.txtPhone.TabIndex = 4;
		this.txtPhone.Text = "";
		//
		//txtAddress
		//
		this.txtAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txtAddress.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.txtAddress.Location = new System.Drawing.Point(128, 112);
		this.txtAddress.MaxLength = 100;
		this.txtAddress.Multiline = true;
		this.txtAddress.Name = "txtAddress";
		this.txtAddress.Size = new System.Drawing.Size(456, 104);
		this.txtAddress.TabIndex = 2;
		this.txtAddress.Text = "";
		//
		//txtAttention
		//
		this.txtAttention.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txtAttention.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.txtAttention.Location = new System.Drawing.Point(128, 232);
		this.txtAttention.MaxLength = 50;
		this.txtAttention.Name = "txtAttention";
		this.txtAttention.Size = new System.Drawing.Size(456, 21);
		this.txtAttention.TabIndex = 3;
		this.txtAttention.Text = "";
		//
		//txtName
		//
		this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txtName.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.txtName.Location = new System.Drawing.Point(128, 80);
		this.txtName.MaxLength = 50;
		this.txtName.Name = "txtName";
		this.txtName.Size = new System.Drawing.Size(456, 21);
		this.txtName.TabIndex = 1;
		this.txtName.Text = "";
		//
		//lblCompletionDate
		//
		this.lblCompletionDate.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblCompletionDate.Location = new System.Drawing.Point(8, 360);
		this.lblCompletionDate.Name = "lblCompletionDate";
		this.lblCompletionDate.Size = new System.Drawing.Size(112, 23);
		this.lblCompletionDate.TabIndex = 14;
		this.lblCompletionDate.Text = "Completion Date:";
		this.lblCompletionDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//lblDoneBy
		//
		this.lblDoneBy.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblDoneBy.Location = new System.Drawing.Point(8, 320);
		this.lblDoneBy.Name = "lblDoneBy";
		this.lblDoneBy.Size = new System.Drawing.Size(88, 40);
		this.lblDoneBy.TabIndex = 13;
		this.lblDoneBy.Text = "Installation Done By :";
		this.lblDoneBy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//lblFax
		//
		this.lblFax.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblFax.Location = new System.Drawing.Point(8, 296);
		this.lblFax.Name = "lblFax";
		this.lblFax.Size = new System.Drawing.Size(112, 23);
		this.lblFax.TabIndex = 12;
		this.lblFax.Text = "Fax:";
		this.lblFax.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//lblPhone
		//
		this.lblPhone.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblPhone.Location = new System.Drawing.Point(8, 264);
		this.lblPhone.Name = "lblPhone";
		this.lblPhone.Size = new System.Drawing.Size(112, 23);
		this.lblPhone.TabIndex = 11;
		this.lblPhone.Text = "Phone:";
		this.lblPhone.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//lblAttention
		//
		this.lblAttention.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblAttention.Location = new System.Drawing.Point(8, 224);
		this.lblAttention.Name = "lblAttention";
		this.lblAttention.Size = new System.Drawing.Size(112, 40);
		this.lblAttention.TabIndex = 10;
		this.lblAttention.Text = "Customer Representative:";
		this.lblAttention.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//lblAddress
		//
		this.lblAddress.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblAddress.Location = new System.Drawing.Point(8, 112);
		this.lblAddress.Name = "lblAddress";
		this.lblAddress.Size = new System.Drawing.Size(112, 23);
		this.lblAddress.TabIndex = 9;
		this.lblAddress.Text = "Address:";
		this.lblAddress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//lblName
		//
		this.lblName.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblName.Location = new System.Drawing.Point(8, 80);
		this.lblName.Name = "lblName";
		this.lblName.Size = new System.Drawing.Size(112, 23);
		this.lblName.TabIndex = 8;
		this.lblName.Text = "Customer Name:";
		this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//frmCustomerDetails
		//
		this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
		this.AutoScroll = true;
		this.BackColor = System.Drawing.Color.AliceBlue;
		this.ClientSize = new System.Drawing.Size(392, 440);
		this.ControlBox = false;
		this.Controls.Add(this.Panel1);
		this.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		this.MaximizeBox = false;
		this.MinimizeBox = false;
		this.Name = "frmCustomerDetails";
		this.Text = "Customer Details";
		this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
		this.Panel1.ResumeLayout(false);
		this.Panel2.ResumeLayout(false);
		this.ResumeLayout(false);

	}

	#End Region

	#Region " Form Events "

	private void  // ERROR: Handles clauses are not supported in C#
frmCustomerDetails_Load(System.Object sender, System.EventArgs e)
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
frmCustomerDetails_Closing(object sender, System.ComponentModel.CancelEventArgs e)
	{
		try {
			if (!funcSaveCustomerData()) {
				throw new Exception("Error in Saving Customer Details.");
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

	private void cmdCancel_Click(System.Object sender, System.EventArgs e)
	{

		try {
			this.Close();
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

	private void cmdOK_Click(System.Object sender, System.EventArgs e)
	{
		try {
			if (!funcSaveCustomerData()) {
				throw new Exception("Error in Saving Customer Details.");
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
		this.Close();
	}
	#End Region

	#Region " General Private functions "

	//--------------------------------------------------------
	//    General functions used for IQ Equipment Listing.
	//--- funcInitialize - To Initialize form and to get values for Customer Details from database and display them.
	//--- funcGetCustomerData - To Get Customer Detail Records from Database into DataTable.
	//--- funcGetCustomerDetails - To Get Customer Detail Records from Database into DataTable.
	//--- funcSaveCustomerData - To Save the Entered Records into Database.
	//--- funcInsertCustomerData - To Add/Insert New Customer Data in Database.
	//--- funcUpdateCustomerData - To Update Customer Data in Database.

	private void funcInitialize()
	{
		//=====================================================================
		// Procedure Name        :   funcInitailize
		// Description           :   To Initialize form and to get values for Customer Details from database and display them.
		// Purpose               :   To Initialize form and to get values for Customer Details from database and display them.
		// Parameters Passed     :   None.
		// Returns               :   None.
		// Parameters Affected   :   None.
		// Assumptions           :
		// Dependencies          :
		// Author                :   Gitesh
		// Created               :   February, 2003 
		// Revisions             :
		//=====================================================================
		//mfrmCustDetails = Me
		DataTable dtCustomerDetails = new DataTable();

		try {
			dtCustomerDetails = gobjDataAccess.GetCustomerDetails();
			if (dtCustomerDetails.Rows.Count > 0) {
				txtName.Text = (string)dtCustomerDetails.Rows.Item(0).Item("Name");
				txtAddress.Text = (string)dtCustomerDetails.Rows.Item(0).Item("Address") + "";
				txtAttention.Text = (string)dtCustomerDetails.Rows.Item(0).Item("Attention") + "";
				txtPhone.Text = (string)dtCustomerDetails.Rows.Item(0).Item("Phone") + "";
				txtFax.Text = (string)dtCustomerDetails.Rows.Item(0).Item("Fax") + "";
				txtDoneBy.Text = (string)dtCustomerDetails.Rows.Item(0).Item("DoneBy") + "";
				if (IsDBNull(dtCustomerDetails.Rows.Item(0).Item("CompleteDate")) == false) {
					dtpCompletionDate.Value = (System.DateTime)dtCustomerDetails.Rows.Item(0).Item("CompleteDate");
				} else {
					dtpCompletionDate.Value = DateTime.Today;
				}
			} else {
				//Throw New Exception("Error in Saving Customer Details.")
			}

			if (gobjDataAccess.funcCheckModeLocked(ENUM_IQOQPQ_STATUS.IQ)) {
				txtName.ReadOnly = true;
				txtAddress.ReadOnly = true;
				txtAttention.ReadOnly = true;
				txtPhone.ReadOnly = true;
				txtFax.ReadOnly = true;
				txtDoneBy.ReadOnly = true;
				dtpCompletionDate.Enabled = false;
				//Added by pankaj on 6.12.07
			} else {
				txtName.ReadOnly = false;
				txtAddress.ReadOnly = false;
				txtAttention.ReadOnly = false;
				txtPhone.ReadOnly = false;
				txtFax.ReadOnly = false;
				txtDoneBy.ReadOnly = false;
				dtpCompletionDate.Enabled = true;
				//Added by pankaj on 6.12.07
			}
		//If Not (funcGetCustomerData()) Then
		//    Throw New Exception("Error in Getting Customer Details Records.")
		//End If
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

	//Private Function funcGetCustomerData() As Boolean
	//    '=====================================================================
	//    ' Procedure Name        :   funcGetCustomerData
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

	//    Dim dtCustomerDetails As New DataTable

	//    Try
	//        dtCustomerDetails = gobjDataAccess.GetCustomerDetails()
	//        If dtCustomerDetails.Rows.Count > 0 Then
	//            txtName.Text = CStr(dtCustomerDetails.Rows.Item(0).Item("Name"))
	//            txtAddress.Text = CStr(dtCustomerDetails.Rows.Item(0).Item("Address") & "")
	//            txtAttention.Text = CStr(dtCustomerDetails.Rows.Item(0).Item("Attention") & "")
	//            txtPhone.Text = CStr(dtCustomerDetails.Rows.Item(0).Item("Phone") & "")
	//            txtFax.Text = CStr(dtCustomerDetails.Rows.Item(0).Item("Fax") & "")
	//            txtDoneBy.Text = CStr(dtCustomerDetails.Rows.Item(0).Item("DoneBy") & "")
	//            If IsDBNull(dtCustomerDetails.Rows.Item(0).Item("CompleteDate")) = False Then
	//                dtpCompletionDate.Value = CDate(dtCustomerDetails.Rows.Item(0).Item("CompleteDate"))
	//            Else
	//                dtpCompletionDate.Value = DateTime.Today
	//            End If
	//        Else
	//            Throw New Exception("Error in Saving Customer Details.")
	//        End If


	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        'Error logging
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = "Error in Getting Customer Details Data."
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

	//Private Function funcGetCustomerDetails() As Boolean
	//    '=====================================================================
	//    ' Procedure Name        :   funcGetCustomerDetails
	//    ' Description           :   To Get Customer Records from Database into DataTable.
	//    ' Purpose               :   To Get Customer Records from Database into DataTable.
	//    ' Parameters Passed     :   None.
	//    ' Returns               :   None.
	//    ' Parameters Affected   :   None.
	//    ' Assumptions           :
	//    ' Dependencies          :
	//    ' Author                :   
	//    ' Created               :   February, 2003 
	//    ' Revisions             :
	//    '=====================================================================

	//    Dim objReader As OleDbDataReader
	//    Dim sql_string As String
	//    Dim reader_status As Boolean

	//    Try
	//        'sql_string = "Select CustomerID ,Name ,Address ,Attention ,Phone ,Fax ,DoneBy ,CompleteDate from CustomerDetails where CustomerID = " & CONST_RecordID & " "

	//        'reader_status = gclsDBFunctions.GetRecords(sql_string, gOleDBIQOQPQConnection, objReader)

	//        If Not (reader_status) Then
	//            Throw New Exception("Error in Opening Connection during Getting Customer Details.")
	//        End If

	//        While objReader.Read
	//            txtName.Text = CStr(objReader.Item("Name") & "")
	//            txtAddress.Text = CStr(objReader.Item("Address") & "")
	//            txtAttention.Text = CStr(objReader.Item("Attention") & "")
	//            txtPhone.Text = CStr(objReader.Item("Phone") & "")
	//            txtFax.Text = CStr(objReader.Item("Fax") & "")
	//            txtDoneBy.Text = CStr(objReader.Item("DoneBy") & "")
	//            If IsDBNull(objReader.Item("CompleteDate")) = False Then
	//                dtpCompletionDate.Value = CDate(objReader.Item("CompleteDate"))
	//            Else
	//                dtpCompletionDate.Value = DateTime.Today
	//            End If
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
		// Author                :   Gitesh
		// Created               :   January, 2003 
		// Revisions             :
		//=====================================================================

		int intID;
		string strName;
		string strAddress;
		string strAttention;
		string strPhone;
		string strFax;
		string strDoneBy;
		DateTime dtCompleteDate;
		bool status = false;
		DataTable objdtCustomer = new DataTable();
		DataRow objRow;
		try {
			objdtCustomer.Columns.Add("Name");
			objdtCustomer.Columns.Add("Address");
			objdtCustomer.Columns.Add("Attention");
			objdtCustomer.Columns.Add("Phone");
			objdtCustomer.Columns.Add("Fax");
			objdtCustomer.Columns.Add("DoneBy");
			objdtCustomer.Columns.Add("CompleteDate");

			objRow = objdtCustomer.NewRow;
			//intID = CONST_RecordID
			if (txtName.Text == "") {
				txtName.Text = " ";
			}
			if (txtAddress.Text == "") {
				txtAddress.Text = " ";
			}
			if (txtAttention.Text == "") {
				txtAttention.Text = " ";
			}
			if (txtPhone.Text == "") {
				txtPhone.Text = " ";
			}
			if (txtFax.Text == "") {
				txtFax.Text = " ";
			}
			if (txtDoneBy.Text == "") {
				txtDoneBy.Text = " ";
			}

			objRow.Item("Name") = txtName.Text;
			objRow.Item("Address") = txtAddress.Text;
			objRow.Item("Attention") = txtAttention.Text;
			objRow.Item("Phone") = txtPhone.Text;
			objRow.Item("Fax") = txtFax.Text;
			objRow.Item("DoneBy") = txtDoneBy.Text;
			objRow.Item("CompleteDate") = dtpCompletionDate.Value;
			objdtCustomer.Rows.Add(objRow);
			status = gobjDataAccess.funcUpdateCustomerData(objdtCustomer);
			if (!(status)) {
				throw new Exception("Error in Updating Customer Details.");
			}

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = "Error in Updating Customer Details.";
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

	//Private Function funcInsertCustomerData(ByVal intID As Integer) As Boolean
	//    '=====================================================================
	//    ' Procedure Name        :   funcInsertCustomerData
	//    ' Description           :   To Add/Insert New Customer Record in Database.
	//    ' Purpose               :   To Add/Insert New Customer Record in Database.
	//    ' Parameters Passed     :   None.
	//    ' Returns               :   None.
	//    ' Parameters Affected   :   None.
	//    ' Assumptions           :
	//    ' Dependencies          :
	//    ' Author                :   Gitesh
	//    ' Created               :   February, 2003 
	//    ' Revisions             :
	//    '=====================================================================

	//    Dim Status As Boolean
	//    Dim str_sql As String
	//    Dim objCommand As New OleDbCommand

	//    Try
	//        'Status = gobjGeneralDatabaseFunctions.OpenConnection(gOledbConnectionObj)
	//        'If Not (Status) Then
	//        '    Throw New Exception("Error in Opening Connection during Saving Customer Details.")
	//        'End If

	//        '---  Query for adding  data to EquipmentList
	//        str_sql = " Insert into CustomerDetails " & _
	//                  " (CustomerID ,Name ) " & _
	//                  " values(?,?) "

	//        '--- Providing command object for EquimentList
	//        With objCommand
	//            .Connection = gOleDBIQOQPQConnection
	//            .CommandType = CommandType.Text
	//            .CommandText = str_sql
	//            .Parameters.Add("CustomerID", OleDbType.Numeric).Value = intID
	//            .Parameters.Add("Name", OleDbType.VarChar, 250).Value = ""
	//            .ExecuteNonQuery()
	//        End With

	//        objCommand.Dispose()
	//        Status = True

	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        '--- Error logging
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = "Error in Saving Customer Details."
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

	//Private Function funcUpdateCustomerData(ByVal intID As Integer, ByVal strName As String, ByVal strAddress As String, ByVal strAttention As String, ByVal strPhone As String, ByVal strFax As String, ByVal strDoneBy As String, ByVal dtCompleteDate As DateTime) As Boolean
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
	//    ' Created               :   February, 2003 
	//    ' Revisions             :
	//    '=====================================================================

	//    Dim Status As Boolean
	//    Dim str_sql As String
	//    Dim objCommand As New OleDbCommand

	//    Try
	//        'Status = gobjGeneralDatabaseFunctions.OpenConnection(gOledbConnectionObj)
	//        'If Not (Status) Then
	//        '    Throw New Exception("Error in Opening Connection during Updating Customer Details.")
	//        'End If

	//        '---  Query for adding  data to EquipmentList
	//        str_sql = " Update CustomerDetails " & _
	//                  " Set Name = ? ,Address= ? ,Attention = ? ,Phone = ? ,Fax = ? ,DoneBy = ? ,CompleteDate = ? " & _
	//                  " where CustomerID = " & intID & " "

	//        '--- Providing command object for EquimentList
	//        With objCommand
	//            .Connection = gOleDBIQOQPQConnection
	//            .CommandType = CommandType.Text
	//            .CommandText = str_sql
	//            .Parameters.Add("Name", OleDbType.VarChar, 250).Value = strName
	//            .Parameters.Add("Address", OleDbType.VarChar, 250).Value = strAddress
	//            .Parameters.Add("Attention", OleDbType.VarChar, 250).Value = strAttention
	//            .Parameters.Add("Phone", OleDbType.VarChar, 250).Value = strPhone
	//            .Parameters.Add("Fax", OleDbType.VarChar, 250).Value = strFax
	//            .Parameters.Add("DoneBy", OleDbType.VarChar, 250).Value = strDoneBy
	//            .Parameters.Add("CompleteDate", OleDbType.DBDate).Value = dtCompleteDate
	//            .ExecuteNonQuery()
	//        End With

	//        objCommand.Dispose()
	//        Status = True

	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        '--- Error logging
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = "Error in Updating Customer Details."
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

