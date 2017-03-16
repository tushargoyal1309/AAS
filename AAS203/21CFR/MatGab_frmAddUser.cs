using AAS203.Common;
using System.Data;
using System.Data.OleDb;

public class frmAddUser : System.Windows.Forms.Form
{

	#Region " Module level Declarations "

	DataTable mobjDataTable = new DataTable("UserInfo");
	DataGridTableStyle mobjGridTableStyle = new DataGridTableStyle();

	LinkLabel mobjLinkLabel = new LinkLabel();
	private enum ENUM_ColumnNos
	{
		UserID = 0,
		UserName = 1,
		AliasName = 2,
		Password = 3,
		Active = 4,
		PasswordID = 5,
		Edit = 6
	}

	#End Region

	#Region " Windows Form Designer generated code "

	public frmAddUser()
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
	internal System.Windows.Forms.TextBox txtUserName;
	internal System.Windows.Forms.TextBox txtPassword;
	internal System.Windows.Forms.Label Label1;
	internal System.Windows.Forms.Label Label2;
	internal System.Windows.Forms.GroupBox GroupBox1;
	internal System.Windows.Forms.TextBox txtAliasName;
	internal System.Windows.Forms.Label lblAliasName;
	internal System.Windows.Forms.CheckBox chkActiveUser;
	internal System.Windows.Forms.TextBox txtUserID;
	internal System.Windows.Forms.DataGrid dgUserInfo;
	internal System.Windows.Forms.PictureBox PictureBox1;
	internal System.Windows.Forms.Label Label3;
	internal System.Windows.Forms.TextBox txtConfirmPassword;
	internal NETXP.Controls.XPButton cmdSave;
	internal NETXP.Controls.XPButton cmdCancel;
	[System.Diagnostics.DebuggerStepThrough()]
	private void InitializeComponent()
	{
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmAddUser));
		this.txtUserName = new System.Windows.Forms.TextBox();
		this.txtPassword = new System.Windows.Forms.TextBox();
		this.Label1 = new System.Windows.Forms.Label();
		this.Label2 = new System.Windows.Forms.Label();
		this.GroupBox1 = new System.Windows.Forms.GroupBox();
		this.cmdCancel = new NETXP.Controls.XPButton();
		this.cmdSave = new NETXP.Controls.XPButton();
		this.txtConfirmPassword = new System.Windows.Forms.TextBox();
		this.Label3 = new System.Windows.Forms.Label();
		this.txtUserID = new System.Windows.Forms.TextBox();
		this.chkActiveUser = new System.Windows.Forms.CheckBox();
		this.txtAliasName = new System.Windows.Forms.TextBox();
		this.lblAliasName = new System.Windows.Forms.Label();
		this.dgUserInfo = new System.Windows.Forms.DataGrid();
		this.PictureBox1 = new System.Windows.Forms.PictureBox();
		this.GroupBox1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.dgUserInfo).BeginInit();
		this.SuspendLayout();
		//
		//txtUserName
		//
		this.txtUserName.AutoSize = false;
		this.txtUserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txtUserName.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.txtUserName.Location = new System.Drawing.Point(136, 18);
		this.txtUserName.MaxLength = 40;
		this.txtUserName.Name = "txtUserName";
		this.txtUserName.Size = new System.Drawing.Size(232, 21);
		this.txtUserName.TabIndex = 0;
		this.txtUserName.Text = "";
		//
		//txtPassword
		//
		this.txtPassword.AutoSize = false;
		this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txtPassword.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.txtPassword.Location = new System.Drawing.Point(136, 90);
		this.txtPassword.MaxLength = 40;
		this.txtPassword.Name = "txtPassword";
		this.txtPassword.PasswordChar = Microsoft.VisualBasic.ChrW(42);
		this.txtPassword.Size = new System.Drawing.Size(232, 21);
		this.txtPassword.TabIndex = 2;
		this.txtPassword.Text = "";
		//
		//Label1
		//
		this.Label1.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.Label1.Location = new System.Drawing.Point(16, 22);
		this.Label1.Name = "Label1";
		this.Label1.Size = new System.Drawing.Size(112, 22);
		this.Label1.TabIndex = 3;
		this.Label1.Text = "User Name :";
		this.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
		//
		//Label2
		//
		this.Label2.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.Label2.Location = new System.Drawing.Point(16, 94);
		this.Label2.Name = "Label2";
		this.Label2.Size = new System.Drawing.Size(112, 22);
		this.Label2.TabIndex = 8;
		this.Label2.Text = "Password :";
		this.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
		//
		//GroupBox1
		//
		this.GroupBox1.Controls.Add(this.cmdCancel);
		this.GroupBox1.Controls.Add(this.cmdSave);
		this.GroupBox1.Controls.Add(this.txtConfirmPassword);
		this.GroupBox1.Controls.Add(this.Label3);
		this.GroupBox1.Controls.Add(this.txtUserID);
		this.GroupBox1.Controls.Add(this.chkActiveUser);
		this.GroupBox1.Controls.Add(this.txtAliasName);
		this.GroupBox1.Controls.Add(this.lblAliasName);
		this.GroupBox1.Controls.Add(this.txtUserName);
		this.GroupBox1.Controls.Add(this.txtPassword);
		this.GroupBox1.Controls.Add(this.Label1);
		this.GroupBox1.Controls.Add(this.Label2);
		this.GroupBox1.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.GroupBox1.Location = new System.Drawing.Point(62, 3);
		this.GroupBox1.Name = "GroupBox1";
		this.GroupBox1.Size = new System.Drawing.Size(378, 213);
		this.GroupBox1.TabIndex = 0;
		this.GroupBox1.TabStop = false;
		//
		//cmdCancel
		//
		this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.cmdCancel.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.cmdCancel.Image = (System.Drawing.Image)resources.GetObject("cmdCancel.Image");
		this.cmdCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.cmdCancel.Location = new System.Drawing.Point(264, 173);
		this.cmdCancel.Name = "cmdCancel";
		this.cmdCancel.Size = new System.Drawing.Size(100, 30);
		this.cmdCancel.TabIndex = 11;
		this.cmdCancel.Text = "&Cancel";
		//
		//cmdSave
		//
		this.cmdSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.cmdSave.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.cmdSave.Image = (System.Drawing.Image)resources.GetObject("cmdSave.Image");
		this.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.cmdSave.Location = new System.Drawing.Point(144, 173);
		this.cmdSave.Name = "cmdSave";
		this.cmdSave.Size = new System.Drawing.Size(100, 30);
		this.cmdSave.TabIndex = 10;
		this.cmdSave.Text = "&Save";
		//
		//txtConfirmPassword
		//
		this.txtConfirmPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txtConfirmPassword.Location = new System.Drawing.Point(136, 126);
		this.txtConfirmPassword.Name = "txtConfirmPassword";
		this.txtConfirmPassword.PasswordChar = Microsoft.VisualBasic.ChrW(42);
		this.txtConfirmPassword.Size = new System.Drawing.Size(232, 21);
		this.txtConfirmPassword.TabIndex = 3;
		this.txtConfirmPassword.Text = "";
		//
		//Label3
		//
		this.Label3.Location = new System.Drawing.Point(16, 130);
		this.Label3.Name = "Label3";
		this.Label3.Size = new System.Drawing.Size(112, 22);
		this.Label3.TabIndex = 9;
		this.Label3.Text = "Confirm Password :";
		this.Label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
		//
		//txtUserID
		//
		this.txtUserID.AutoSize = false;
		this.txtUserID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txtUserID.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.txtUserID.Location = new System.Drawing.Point(192, 152);
		this.txtUserID.Name = "txtUserID";
		this.txtUserID.Size = new System.Drawing.Size(130, 21);
		this.txtUserID.TabIndex = 4;
		this.txtUserID.Text = "UserID + PasswordID";
		this.txtUserID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
		this.txtUserID.Visible = false;
		//
		//chkActiveUser
		//
		this.chkActiveUser.Location = new System.Drawing.Point(16, 158);
		this.chkActiveUser.Name = "chkActiveUser";
		this.chkActiveUser.TabIndex = 3;
		this.chkActiveUser.Text = "Active User";
		//
		//txtAliasName
		//
		this.txtAliasName.AutoSize = false;
		this.txtAliasName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txtAliasName.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.txtAliasName.Location = new System.Drawing.Point(136, 54);
		this.txtAliasName.MaxLength = 40;
		this.txtAliasName.Name = "txtAliasName";
		this.txtAliasName.Size = new System.Drawing.Size(232, 21);
		this.txtAliasName.TabIndex = 1;
		this.txtAliasName.Text = "";
		//
		//lblAliasName
		//
		this.lblAliasName.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblAliasName.Location = new System.Drawing.Point(16, 58);
		this.lblAliasName.Name = "lblAliasName";
		this.lblAliasName.Size = new System.Drawing.Size(112, 22);
		this.lblAliasName.TabIndex = 7;
		this.lblAliasName.Text = "Alias Name :";
		this.lblAliasName.TextAlign = System.Drawing.ContentAlignment.TopRight;
		//
		//dgUserInfo
		//
		this.dgUserInfo.BackColor = System.Drawing.Color.AliceBlue;
		this.dgUserInfo.BackgroundColor = System.Drawing.Color.White;
		this.dgUserInfo.CaptionVisible = false;
		this.dgUserInfo.DataMember = "";
		this.dgUserInfo.GridLineColor = System.Drawing.Color.Gray;
		this.dgUserInfo.HeaderForeColor = System.Drawing.SystemColors.ControlText;
		this.dgUserInfo.Location = new System.Drawing.Point(8, 216);
		this.dgUserInfo.Name = "dgUserInfo";
		this.dgUserInfo.ParentRowsVisible = false;
		this.dgUserInfo.ReadOnly = true;
		this.dgUserInfo.Size = new System.Drawing.Size(432, 144);
		this.dgUserInfo.TabIndex = 1;
		//
		//PictureBox1
		//
		this.PictureBox1.Image = (System.Drawing.Image)resources.GetObject("PictureBox1.Image");
		this.PictureBox1.Location = new System.Drawing.Point(8, 16);
		this.PictureBox1.Name = "PictureBox1";
		this.PictureBox1.Size = new System.Drawing.Size(48, 48);
		this.PictureBox1.TabIndex = 15;
		this.PictureBox1.TabStop = false;
		//
		//frmAddUser
		//
		this.AcceptButton = this.cmdSave;
		this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
		this.BackColor = System.Drawing.Color.AliceBlue;
		this.CancelButton = this.cmdCancel;
		this.ClientSize = new System.Drawing.Size(450, 370);
		this.Controls.Add(this.PictureBox1);
		this.Controls.Add(this.dgUserInfo);
		this.Controls.Add(this.GroupBox1);
		this.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		this.MaximizeBox = false;
		this.MinimizeBox = false;
		this.Name = "frmAddUser";
		this.ShowInTaskbar = false;
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Add User";
		this.GroupBox1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.dgUserInfo).EndInit();
		this.ResumeLayout(false);

	}

	#End Region

	#Region " Form Events"

	private void  // ERROR: Handles clauses are not supported in C#
frmAddUser_Load(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : frmAddUser_Load
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To load the Add User form.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saruabh S. 
		// Created               : Dec, 2006
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
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
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			if (!objWait == null) {
				objWait.Dispose();
			}
			//---------------------------------------------------------
		}

	}

	private void cmdCancel_Click(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : cmdCancel_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To cancel the form
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                :   Saruabh S. 
		// Created               :   Dec, 2006
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		try {
			this.DialogResult = DialogResult.Cancel;
			this.Close();

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			if (!objWait == null) {
				objWait.Dispose();
			}
			//---------------------------------------------------------
		}
	}

	private void cmdSave_Click(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : cmdSave_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To Save the User details added.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saruabh S. 
		// Created               : Dec, 2006
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		try {
			if (funcSaveNewUser()) {
				funcGetExistingUsers();
				subFormatDataGrid();
				//MessageBox.Show("User Successfully")
				txtUserName.Text = "";
				txtAliasName.Text = "";
				txtPassword.Text = "";
				txtConfirmPassword.Text = "";
				txtUserID.Text = "";
			}
		//Me.Close()

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			if (!objWait == null) {
				objWait.Dispose();
			}
			//---------------------------------------------------------
		}

	}

	private void  // ERROR: Handles clauses are not supported in C#
dgUserInfo_CurrentCellChanged(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : dgUserInfo_CurrentCellChanged
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To load the User details selected in the combo box.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saruabh S. 
		// Created               : Dec, 2006
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		try {
			// dgUserInfo.Select(dgUserInfo.CurrentCell.RowNumber())
			dgUserInfo.Refresh();

			if ((dgUserInfo.CurrentCell.ColumnNumber == ENUM_ColumnNos.Edit)) {
				mobjLinkLabel.Top = dgUserInfo.GetCurrentCellBounds().Top;
				mobjLinkLabel.Left = dgUserInfo.GetCurrentCellBounds().Left;
				mobjLinkLabel.Width = dgUserInfo.GetCurrentCellBounds().Width;
				mobjLinkLabel.Height = dgUserInfo.GetCurrentCellBounds().Height;
				mobjLinkLabel.Visible = true;
				mobjLinkLabel.Text = dgUserInfo(dgUserInfo.CurrentCell.RowNumber, ENUM_ColumnNos.Edit);
			} else {
				mobjLinkLabel.Width = 0;
				mobjLinkLabel.Visible = false;
			}
			//----Added By Pankaj 30  MAy 07
			SubEditGrid(dgUserInfo);
			dgUserInfo.Refresh();
			if (dgUserInfo.CurrentRowIndex >= 0) {
				dgUserInfo.Select(dgUserInfo.CurrentRowIndex);
			}
		//---------
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			if (!objWait == null) {
				objWait.Dispose();
			}
			//---------------------------------------------------------
		}
	}

	#End Region

	#Region " Private functions"

	//--------------------------------------------------------
	//    General functions used for Adding User.
	//--- funcInitialize  - To Initialize the form and show all the users present.
	//--- funcGetExistingUsers - To Get the Current Users from the database and display them.
	//--- subCreateDataTable -  To Create a Data Table and add Values in it.
	//--- subFormatDataGrid -  To Format Data Grid .
	//--- funcSaveNewUser - To Save Newly Created User.

	private void funcInitialize()
	{
		//=====================================================================
		// Procedure Name        :   funcInitialize
		// Description           :   To Initialize the form and show all the users present.
		// Purpose               :   To Initialize the form and show all the users present.
		// Parameters Passed     :   None.
		// Returns               :   None.
		// Parameters Affected   :   None.
		// Assumptions           :
		// Dependencies          :
		// Author                :   Gitesh
		// Created               :   January, 2003 
		// Revisions             :
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		try {
			chkActiveUser.Checked = true;
			txtUserName.Text = "";
			txtAliasName.Text = "";
			txtPassword.Text = "";
			txtConfirmPassword.Text = "";
			txtUserID.Text = "";

			//--- Passing database name to clsstrConnString property
			//mstrConnectionString = gclsDBFunctions.ConnectionString(CONST_USERINFO_DATABASENAME)

			//--- Passing connection string to Connection Object
			//mOledbConnection = New OleDbConnection(mstrConnectionString)

			mobjLinkLabel.Click += LinkLabel_Click;
			cmdCancel.Click += cmdCancel_Click;
			cmdSave.Click += cmdSave_Click;

			dgUserInfo.Controls.Add(mobjLinkLabel);
			mobjLinkLabel.Visible = false;

			subCreateDataTable();
			funcGetExistingUsers();
			subFormatDataGrid();

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			if (!objWait == null) {
				objWait.Dispose();
			}
			//---------------------------------------------------------
		}
	}

	private void LinkLabel_Click(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        :   LinkLabel_Click
		// Description           :   To Initialize the form and show all the users present.
		// Purpose               :   To Initialize the form and show all the users present.
		// Parameters Passed     :   None.
		// Returns               :   None.
		// Parameters Affected   :   None.
		// Assumptions           :
		// Dependencies          :
		// Author                :   Gitesh
		// Created               :   January, 2003 
		// Revisions             :
		//=====================================================================
		int row_no;
		string user_id;
		string password_id;
		CWaitCursor objWait = new CWaitCursor();
		try {
			row_no = dgUserInfo.CurrentCell.RowNumber();

			txtUserName.Text = dgUserInfo(row_no, ENUM_ColumnNos.UserName);
			txtAliasName.Text = dgUserInfo(row_no, ENUM_ColumnNos.AliasName);
			txtPassword.Text = dgUserInfo(row_no, ENUM_ColumnNos.Password);
			user_id = dgUserInfo(row_no, ENUM_ColumnNos.UserID);
			password_id = dgUserInfo(row_no, ENUM_ColumnNos.PasswordID);

			txtUserID.Text = user_id + " , " + password_id;
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			if (!objWait == null) {
				objWait.Dispose();
			}
			//---------------------------------------------------------
		}

	}

	private bool funcGetExistingUsers()
	{
		//=====================================================================
		// Procedure Name        :   funcGetExistingUsers
		// Description           :   To Get the Current Users from the database and display them.
		// Purpose               :   To Get the Current Users from the database and display them.
		// Parameters Passed     :   None.
		// Returns               :   None.
		// Parameters Affected   :   None.
		// Assumptions           :
		// Dependencies          :
		// Author                :   Gitesh
		// Created               :   January, 2003 
		// Revisions             :
		//=====================================================================
		bool result;
		string str_sql;
		OleDb.OleDbDataReader objReader;
		DataRow objDataRow;
		CWaitCursor objWait = new CWaitCursor();

		try {
			mobjDataTable.Clear();

			//--- Generating dynamic query for selection type
			str_sql = "Select Users.UserID ,Users.UserName ,Users.AliasName ,Users.Active ,Passwords.PasswordID ,Passwords.PasswordName  " + "from Users ,Passwords " + "where Users.UserID = Passwords.UserID ";

			//str_sql = "Select Users.UserID ,Users.UserName ,Users.AliasName ,Users.Active " & _
			//          "from Users "

			result = gclsDBFunctions.OpenConnection(gOleDBUserInfoConnection);
			if (!(result)) {
				return false;
			}

			//--- Calling gfuncGetRecords to Get myreader populated with provided Query( strsqlServiceComments (Global String) Records
			gclsDBFunctions.GetRecords(str_sql, gOleDBUserInfoConnection, objReader);

			string str_password;

			while (objReader.Read) {
				objDataRow = mobjDataTable.NewRow;
				objDataRow("UserName") = (string)objReader.Item("UserName");
				objDataRow("AliasName") = (string)objReader.Item("AliasName");
				objDataRow("Active") = (string)objReader.Item("Active");
				objDataRow("UserID") = (string)objReader.Item("UserID");
				objDataRow("PasswordID") = (string)objReader.Item("PasswordID");

				//--- To get encrypted password and decrypt and save it.
				str_password = (string)objReader.Item("PasswordName");
				objDataRow("PasswordName") = gfuncDecryptString(str_password);

				//objDataRow("PasswordName") = CStr(objReader.Item("PasswordName"))
				//objDataRow("Edit") = "Edit"

				mobjDataTable.Rows.Add(objDataRow);
			}

			objReader.Close();

			return true;
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			if (!objWait == null) {
				objWait.Dispose();
			}
			//---------------------------------------------------------
		}
	}

	private void subCreateDataTable()
	{
		//=====================================================================
		// Procedure Name        :   subCreateDataTable
		// Description           :   To Create a Data Table and add Values in it.
		// Purpose               :   To Create a Data Table and add Values in it.
		// Parameters Passed     :   None.
		// Returns               :   None.
		// Parameters Affected   :   None.
		// Assumptions           :
		// Dependencies          :
		// Author                :   Gitesh
		// Created               :   January , 2003 
		// Revisions             :
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		try {
			mobjDataTable.Columns.Add(new DataColumn("UserName", typeof(string)));
			mobjDataTable.Columns.Add(new DataColumn("AliasName", typeof(string)));
			mobjDataTable.Columns.Add(new DataColumn("Active", typeof(int)));
			mobjDataTable.Columns.Add(new DataColumn("UserID", typeof(int)));
			mobjDataTable.Columns.Add(new DataColumn("PasswordID", typeof(int)));
			mobjDataTable.Columns.Add(new DataColumn("PasswordName", typeof(string)));
		//mobjDataTable.Columns.Add(New DataColumn("Edit", GetType(String)))
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			if (!objWait == null) {
				objWait.Dispose();
			}
			//---------------------------------------------------------
		}

	}

	private void subFormatDataGrid()
	{
		//=====================================================================
		// Procedure Name        :   subFormatDataGrid
		// Description           :   To Format Data Grid .
		// Purpose               :   To Format Data Grid .
		// Parameters Passed     :   None.
		// Returns               :   None.
		// Parameters Affected   :   None.
		// Assumptions           :
		// Dependencies          :
		// Author                :   Gitesh
		// Created               :   January , 2003 
		// Revisions             :
		//=====================================================================
		DataGridTextBoxColumn objTextColumn;
		DataView objDataView = new DataView();
		CWaitCursor objWait = new CWaitCursor();
		try {
			dgUserInfo.TableStyles.Clear();
			objDataView.Table = mobjDataTable;
			objDataView.AllowNew = false;
			dgUserInfo.DataSource = objDataView;
			dgUserInfo.ReadOnly = true;
			// False Added By Pankaj 30 May 07


			mobjGridTableStyle = new DataGridTableStyle();

			mobjGridTableStyle.ResetAlternatingBackColor();
			mobjGridTableStyle.ResetBackColor();
			mobjGridTableStyle.ResetForeColor();
			mobjGridTableStyle.ResetGridLineColor();
			mobjGridTableStyle.BackColor = Color.White;
			mobjGridTableStyle.HeaderBackColor = Color.FromArgb(205, 225, 250);
			mobjGridTableStyle.HeaderForeColor = Color.Black;
			mobjGridTableStyle.AlternatingBackColor = Color.White;
			mobjGridTableStyle.AllowSorting = false;
			mobjGridTableStyle.ReadOnly = true;
			mobjGridTableStyle.MappingName = "UserInfo";
			mobjGridTableStyle.RowHeadersVisible = true;
			mobjGridTableStyle.RowHeaderWidth = 0.5;
			mobjGridTableStyle.SelectionBackColor = Color.Gray;
			mobjGridTableStyle.SelectionForeColor = Color.White;
			mobjGridTableStyle.GridLineColor = Color.Gray;


			objTextColumn = new DataGridTextBoxColumn();
			objTextColumn.MappingName = "UserID";
			objTextColumn.HeaderText = "User ID";
			objTextColumn.Width = 88;
			objTextColumn.NullText = "";
			objTextColumn.ReadOnly = true;
			objTextColumn.Alignment = HorizontalAlignment.Center;
			mobjGridTableStyle.GridColumnStyles.Add(objTextColumn);

			objTextColumn = new DataGridTextBoxColumn();
			objTextColumn.MappingName = "UserName";
			objTextColumn.HeaderText = "User Name";
			objTextColumn.Width = 120;
			objTextColumn.NullText = "";
			objTextColumn.ReadOnly = true;
			mobjGridTableStyle.GridColumnStyles.Add(objTextColumn);

			objTextColumn = new DataGridTextBoxColumn();
			objTextColumn.MappingName = "AliasName";
			objTextColumn.NullText = "";
			objTextColumn.HeaderText = "Alias Name";
			objTextColumn.Width = 120;
			objTextColumn.ReadOnly = true;
			mobjGridTableStyle.GridColumnStyles.Add(objTextColumn);

			objTextColumn = new DataGridTextBoxColumn();
			objTextColumn.MappingName = "PasswordName";
			objTextColumn.HeaderText = "Password";
			objTextColumn.Width = 0;
			objTextColumn.NullText = "";
			objTextColumn.ReadOnly = true;
			mobjGridTableStyle.GridColumnStyles.Add(objTextColumn);

			objTextColumn = new DataGridTextBoxColumn();
			objTextColumn.MappingName = "Active";
			objTextColumn.HeaderText = "Active";
			objTextColumn.Width = 85;
			objTextColumn.NullText = "";
			objTextColumn.ReadOnly = true;
			objTextColumn.Alignment = HorizontalAlignment.Center;
			mobjGridTableStyle.GridColumnStyles.Add(objTextColumn);

			objTextColumn = new DataGridTextBoxColumn();
			objTextColumn.MappingName = "PasswordID";
			objTextColumn.HeaderText = "PasswordID";
			objTextColumn.Width = 0;
			objTextColumn.ReadOnly = true;
			mobjGridTableStyle.GridColumnStyles.Add(objTextColumn);

			objTextColumn = new DataGridTextBoxColumn();
			objTextColumn.MappingName = "Edit";
			objTextColumn.HeaderText = "";
			objTextColumn.NullText = "";
			objTextColumn.Width = 50;
			objTextColumn.ReadOnly = true;

			mobjGridTableStyle.GridColumnStyles.Add(objTextColumn);
			mobjGridTableStyle.GridLineColor = Color.AliceBlue;
			dgUserInfo.TableStyles.Add(mobjGridTableStyle);
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			if (!objWait == null) {
				objWait.Dispose();
			}
			//---------------------------------------------------------
		}

	}

	private bool funcSaveNewUser()
	{
		//=====================================================================
		// Procedure Name        :   funcSaveNewUser
		// Description           :   To Save the newly created user/Edited User into database.
		// Purpose               :   To Save the newly created user/Edited User into database.
		// Parameters Passed     :   None.
		// Returns               :   None.
		// Parameters Affected   :   None.
		// Assumptions           :
		// Dependencies          :
		// Author                :   Gitesh
		// Created               :   February, 2003 
		// Revisions             :
		//=====================================================================
		string str_userid;
		CWaitCursor objWait = new CWaitCursor();

		try {
			if (txtUserName.Text == "" | txtPassword.Text == "") {
				gobjMessageAdapter.ShowMessage(constEnterUserNamePassword);
				return false;
				return;
			}
			if (txtConfirmPassword.Text == "") {
				gobjMessageAdapter.ShowMessage(constConfirmPassword);
				txtConfirmPassword.Focus();
				return false;
				return;
			}
			if (StrComp(txtPassword.Text, txtConfirmPassword.Text, CompareMethod.Text) != 0) {
				gobjMessageAdapter.ShowMessage(constInvalidPasswordConfirm);
				return false;
				return;
			}


			str_userid = txtUserID.Text;
			if (((str_userid == "") | (str_userid == null))) {
				if ((funcValidateUsers() == false)) {
					gobjMessageAdapter.ShowMessage(constUserExists);
					txtUserName.Focus();
					return false;
					return;
				}

				funcInsertNewUser();
			} else {
				funcUpdateUser();
			}
			return true;

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			if (!objWait == null) {
				objWait.Dispose();
			}
			//---------------------------------------------------------
		}

	}

	private bool funcValidateUsers()
	{
		//=====================================================================
		// Procedure Name        :   funcValidateUsers
		// Description           :   
		// Purpose               :   
		// Parameters Passed     :   None.
		// Returns               :   None.
		// Parameters Affected   :   None.
		// Assumptions           :
		// Dependencies          :
		// Author                :   Pankaj Bamb 
		// Created               :   30 May 2007 
		// Revisions             :
		//=====================================================================
		bool result;
		string str_sql;
		OleDb.OleDbDataReader objReader;
		try {
			//--- Generating dynamic query for selection type
			str_sql = "SELECT Count(Users.UserName) AS CountOfUserName" + " FROM Users where Users.UserName='" + txtUserName.Text.Trim() + "' ";

			result = gclsDBFunctions.OpenConnection(gOleDBUserInfoConnection);
			if (!(result)) {
				return false;
			}

			//--- Calling gfuncGetRecords to Get myreader populated with provided Query( strsqlServiceComments (Global String) Records
			gclsDBFunctions.GetRecords(str_sql, gOleDBUserInfoConnection, objReader);

			int intCountOfUserName = 0;

			if ((objReader.Read)) {
				intCountOfUserName = (int)objReader.Item("CountOfUserName");
			}
			objReader.Close();
			if (intCountOfUserName <= 0) {
				return true;
			}
			return false;
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			//---------------------------------------------------------
			return false;
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}

			//---------------------------------------------------------
		}
	}

	private bool funcInsertNewUser()
	{
		//=====================================================================
		// Procedure Name        :   funcInsertNewUser
		// Description           :   To Save the newly user created into database.
		// Purpose               :   To Save the newly user created into database.
		// Parameters Passed     :   None.
		// Returns               :   None.
		// Parameters Affected   :   None.
		// Assumptions           :
		// Dependencies          :
		// Author                :   Gitesh
		// Created               :   January, 2003 
		// Revisions             :
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		string str_sql;
		bool Status;
		OleDbCommand objCommand = new OleDbCommand();
		OleDbTransaction objTransaction;
		long user_id;
		long password_id;
		int active_value;

		try {
			Status = gclsDBFunctions.OpenConnection(gOleDBUserInfoConnection);
			if (!(Status)) {
				return false;
			}

			//--- Generating ID for User
			user_id = gclsDBFunctions.GetNextID("Users", "UserID", gOleDBUserInfoConnection);

			Status = gclsDBFunctions.OpenConnection(gOleDBUserInfoConnection);
			if (!(Status)) {
				return false;
			}

			password_id = gclsDBFunctions.GetNextID("Passwords", "PasswordID", gOleDBUserInfoConnection);
			if ((chkActiveUser.Checked == true)) {
				active_value = 1;
			} else {
				active_value = 0;
			}

			objTransaction = gOleDBUserInfoConnection.BeginTransaction();

			//---  Query for Insert into Users Table
			str_sql = "Insert into Users " + "(UserID ,UserName ,AliasName ,Active) " + " values(?,?,?,?)";

			//--- Providing command object for Users
			 // ERROR: Not supported in C#: WithStatement


			objCommand.Dispose();

			//-- To Encrypt the Password.
			string str_password;
			str_password = gfuncEncryptString(Trim(txtPassword.Text));

			//---  Query for Insert into Password Table
			str_sql = "Insert into Passwords  " + "(PasswordID ,UserID ,PasswordName) " + " values(?,?,?)";
			//" values(" & password_id & ", " & user_id & " ,'" & txtPassword.Text & "' )"

			//--- Providing command object for Users
			 // ERROR: Not supported in C#: WithStatement


			//.Parameters.Add("PasswordName", OleDbType.VarChar).Value = Trim(txtPassword.Text)
			objCommand.Dispose();
			objTransaction.Commit();
			return true;

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			if (!objWait == null) {
				objWait.Dispose();
			}
			//---------------------------------------------------------
		}

	}

	private bool funcUpdateUser()
	{
		//=====================================================================
		// Procedure Name        :   funcUpdateUser
		// Description           :   To Save the Edited user info into database.
		// Purpose               :   To Save the Edited user info into database.
		// Parameters Passed     :   None.
		// Returns               :   None.
		// Parameters Affected   :   None.
		// Assumptions           :
		// Dependencies          :
		// Author                :   Gitesh
		// Created               :   February, 2003 
		// Revisions             :
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		string str_sql;
		bool Status;
		OleDbCommand objCommand = new OleDbCommand();
		OleDbTransaction objTransaction;
		long user_id;
		long password_id;
		int active_value;
		string str_id;
		string[] arr_id;

		try {
			str_id = txtUserID.Text;
			arr_id = str_id.Split(",");
			user_id = Convert.ToInt64(arr_id(0));
			password_id = Convert.ToInt64(arr_id(1));

			Status = gclsDBFunctions.OpenConnection(gOleDBUserInfoConnection);
			if (!(Status)) {
				return false;
			}

			if ((chkActiveUser.Checked == true)) {
				active_value = 1;
			} else {
				active_value = 0;
			}

			objTransaction = gOleDBUserInfoConnection.BeginTransaction();

			//---  Query for Update Users Table
			str_sql = "Update Users " + "Set UserName = ? ,AliasName = ? ,Active = ? " + "where UserID = " + user_id + " ";

			//--- Providing command object for Users
			 // ERROR: Not supported in C#: WithStatement


			objCommand.Dispose();

			//--- To Encrypt the Password
			string str_password;
			str_password = gfuncEncryptString(Trim(txtPassword.Text));

			//--- Query for Update Passwords Table
			str_sql = "Update Passwords  " + "Set PasswordName = ? " + "where PasswordID = " + password_id + " and UserID = " + user_id + " ";

			//--- Providing command object for Users
			 // ERROR: Not supported in C#: WithStatement


			//.Parameters.Add("PasswordName", OleDbType.VarChar).Value = Trim(txtPassword.Text)
			objCommand.Dispose();
			objTransaction.Commit();
			return (true);

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			if (!objWait == null) {
				objWait.Dispose();
			}
			//---------------------------------------------------------
		}
	}

	private void SubEditGrid(DataGrid ObjDataGrid)
	{
		//=====================================================================
		// Procedure Name        :   SubEditGrid
		// Description           :   To Save the Edited user info into database.
		// Purpose               :   To Save the Edited user info into database.
		// Parameters Passed     :   None.
		// Returns               :   None.
		// Parameters Affected   :   None.
		// Assumptions           :
		// Dependencies          :
		// Author                :   Gitesh
		// Created               :   February, 2003 
		// Revisions             :
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		int row_no;
		string user_id;
		string password_id;


		try {
			row_no = dgUserInfo.CurrentCell.RowNumber();

			txtUserName.Text = dgUserInfo(row_no, ENUM_ColumnNos.UserName);
			txtAliasName.Text = dgUserInfo(row_no, ENUM_ColumnNos.AliasName);
			txtPassword.Text = dgUserInfo(row_no, ENUM_ColumnNos.Password);
			txtConfirmPassword.Text = dgUserInfo(row_no, ENUM_ColumnNos.Password);
			user_id = dgUserInfo(row_no, ENUM_ColumnNos.UserID);
			password_id = dgUserInfo(row_no, ENUM_ColumnNos.PasswordID);
			//--------Added By Pankaj 17 May 2007 4:33
			if ((dgUserInfo(row_no, ENUM_ColumnNos.Active) == 1)) {
				chkActiveUser.Checked = true;
			} else {
				chkActiveUser.Checked = false;
			}
			//---------
			txtUserID.Text = user_id + " , " + password_id;
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			if (!objWait == null) {
				objWait.Dispose();
			}
			//---------------------------------------------------------
		}

	}

	private void  // ERROR: Handles clauses are not supported in C#
dgUserInfo_Click(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        :   dgUserInfo_Click
		// Description           :   To Save the Edited user info into database.
		// Purpose               :   To Save the Edited user info into database.
		// Parameters Passed     :   None.
		// Returns               :   None.
		// Parameters Affected   :   None.
		// Assumptions           :
		// Dependencies          :
		// Author                :   Saurabh
		// Created               :   05-01-2007
		// Revisions             :
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		try {
			SubEditGrid(dgUserInfo);
			//-----Added By Pankaj 30 May 07
			dgUserInfo.Refresh();
			if (dgUserInfo.CurrentRowIndex >= 0) {
				dgUserInfo.Select(dgUserInfo.CurrentRowIndex);
			}
		//-----

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			if (!objWait == null) {
				objWait.Dispose();
			}
			//---------------------------------------------------------
		}

	}

	private void  // ERROR: Handles clauses are not supported in C#
dgUserInfo_GotFocus(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        :   dgUserInfo_GotFocus
		// Description           :   To show the selected record in textboxes.
		// Purpose               :   To show the selected record in textboxes.
		// Parameters Passed     :   None.
		// Returns               :   None.
		// Parameters Affected   :   None.
		// Assumptions           :
		// Dependencies          :
		// Author                :   Saurabh
		// Revisions             :   05-01-2007
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		try {
			if (dgUserInfo.CurrentRowIndex >= 0) {
				//dgUserInfo.Select(dgUserInfo.CurrentRowIndex)
			}

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			if (!objWait == null) {
				objWait.Dispose();
			}
			//---------------------------------------------------------
		}

	}

	#End Region


}
