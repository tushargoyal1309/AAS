using AAS203.Common;
using System.Data.OleDb;
using System.Data;

public class frmChangePassword : System.Windows.Forms.Form
{

	#Region " Windows Form Designer generated code "

	public frmChangePassword()
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
	internal System.Windows.Forms.GroupBox GroupBox1;
	internal System.Windows.Forms.TextBox txtPassword;
	internal System.Windows.Forms.Label Label1;
	internal System.Windows.Forms.Label Label2;
	internal System.Windows.Forms.Label lblUserName;
	internal System.Windows.Forms.TextBox txtPasswordconfirm;
	internal System.Windows.Forms.Label lblPasswordConfirm;
	internal System.Windows.Forms.PictureBox PictureBox1;
	internal System.Windows.Forms.PictureBox PictureBox2;
	internal NETXP.Controls.XPButton cmdCancel;
	internal NETXP.Controls.XPButton cmdSave;
	[System.Diagnostics.DebuggerStepThrough()]
	private void InitializeComponent()
	{
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmChangePassword));
		this.GroupBox1 = new System.Windows.Forms.GroupBox();
		this.cmdCancel = new NETXP.Controls.XPButton();
		this.cmdSave = new NETXP.Controls.XPButton();
		this.PictureBox2 = new System.Windows.Forms.PictureBox();
		this.PictureBox1 = new System.Windows.Forms.PictureBox();
		this.lblUserName = new System.Windows.Forms.Label();
		this.txtPasswordconfirm = new System.Windows.Forms.TextBox();
		this.lblPasswordConfirm = new System.Windows.Forms.Label();
		this.txtPassword = new System.Windows.Forms.TextBox();
		this.Label1 = new System.Windows.Forms.Label();
		this.Label2 = new System.Windows.Forms.Label();
		this.GroupBox1.SuspendLayout();
		this.SuspendLayout();
		//
		//GroupBox1
		//
		this.GroupBox1.Controls.Add(this.cmdCancel);
		this.GroupBox1.Controls.Add(this.cmdSave);
		this.GroupBox1.Controls.Add(this.PictureBox2);
		this.GroupBox1.Controls.Add(this.PictureBox1);
		this.GroupBox1.Controls.Add(this.lblUserName);
		this.GroupBox1.Controls.Add(this.txtPasswordconfirm);
		this.GroupBox1.Controls.Add(this.lblPasswordConfirm);
		this.GroupBox1.Controls.Add(this.txtPassword);
		this.GroupBox1.Controls.Add(this.Label1);
		this.GroupBox1.Controls.Add(this.Label2);
		this.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.GroupBox1.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.GroupBox1.Location = new System.Drawing.Point(0, 0);
		this.GroupBox1.Name = "GroupBox1";
		this.GroupBox1.Size = new System.Drawing.Size(360, 197);
		this.GroupBox1.TabIndex = 4;
		this.GroupBox1.TabStop = false;
		//
		//cmdCancel
		//
		this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.cmdCancel.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.cmdCancel.Image = (System.Drawing.Image)resources.GetObject("cmdCancel.Image");
		this.cmdCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.cmdCancel.Location = new System.Drawing.Point(244, 144);
		this.cmdCancel.Name = "cmdCancel";
		this.cmdCancel.Size = new System.Drawing.Size(100, 34);
		this.cmdCancel.TabIndex = 39;
		this.cmdCancel.Text = "&Cancel";
		//
		//cmdSave
		//
		this.cmdSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.cmdSave.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.cmdSave.Image = (System.Drawing.Image)resources.GetObject("cmdSave.Image");
		this.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.cmdSave.Location = new System.Drawing.Point(133, 144);
		this.cmdSave.Name = "cmdSave";
		this.cmdSave.Size = new System.Drawing.Size(100, 34);
		this.cmdSave.TabIndex = 38;
		this.cmdSave.Text = "&Save";
		//
		//PictureBox2
		//
		this.PictureBox2.BackColor = System.Drawing.Color.Gray;
		this.PictureBox2.Location = new System.Drawing.Point(56, 24);
		this.PictureBox2.Name = "PictureBox2";
		this.PictureBox2.Size = new System.Drawing.Size(300, 2);
		this.PictureBox2.TabIndex = 22;
		this.PictureBox2.TabStop = false;
		//
		//PictureBox1
		//
		this.PictureBox1.Image = (System.Drawing.Image)resources.GetObject("PictureBox1.Image");
		this.PictureBox1.Location = new System.Drawing.Point(6, 24);
		this.PictureBox1.Name = "PictureBox1";
		this.PictureBox1.Size = new System.Drawing.Size(48, 48);
		this.PictureBox1.TabIndex = 21;
		this.PictureBox1.TabStop = false;
		//
		//lblUserName
		//
		this.lblUserName.BackColor = System.Drawing.Color.White;
		this.lblUserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblUserName.Location = new System.Drawing.Point(162, 48);
		this.lblUserName.Name = "lblUserName";
		this.lblUserName.Size = new System.Drawing.Size(182, 21);
		this.lblUserName.TabIndex = 20;
		this.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//txtPasswordconfirm
		//
		this.txtPasswordconfirm.AutoSize = false;
		this.txtPasswordconfirm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txtPasswordconfirm.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.txtPasswordconfirm.Location = new System.Drawing.Point(162, 112);
		this.txtPasswordconfirm.Name = "txtPasswordconfirm";
		this.txtPasswordconfirm.PasswordChar = Microsoft.VisualBasic.ChrW(42);
		this.txtPasswordconfirm.Size = new System.Drawing.Size(182, 21);
		this.txtPasswordconfirm.TabIndex = 7;
		this.txtPasswordconfirm.Text = "";
		//
		//lblPasswordConfirm
		//
		this.lblPasswordConfirm.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblPasswordConfirm.Location = new System.Drawing.Point(46, 112);
		this.lblPasswordConfirm.Name = "lblPasswordConfirm";
		this.lblPasswordConfirm.Size = new System.Drawing.Size(112, 22);
		this.lblPasswordConfirm.TabIndex = 6;
		this.lblPasswordConfirm.Text = "Password Confirm :";
		this.lblPasswordConfirm.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		//
		//txtPassword
		//
		this.txtPassword.AutoSize = false;
		this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txtPassword.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.txtPassword.Location = new System.Drawing.Point(162, 80);
		this.txtPassword.Name = "txtPassword";
		this.txtPassword.PasswordChar = Microsoft.VisualBasic.ChrW(42);
		this.txtPassword.Size = new System.Drawing.Size(182, 21);
		this.txtPassword.TabIndex = 5;
		this.txtPassword.Text = "";
		//
		//Label1
		//
		this.Label1.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.Label1.Location = new System.Drawing.Point(78, 48);
		this.Label1.Name = "Label1";
		this.Label1.Size = new System.Drawing.Size(80, 22);
		this.Label1.TabIndex = 3;
		this.Label1.Text = "User Name :";
		this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		//
		//Label2
		//
		this.Label2.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.Label2.Location = new System.Drawing.Point(78, 80);
		this.Label2.Name = "Label2";
		this.Label2.Size = new System.Drawing.Size(80, 22);
		this.Label2.TabIndex = 2;
		this.Label2.Text = "Password :";
		this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		//
		//frmChangePassword
		//
		this.AcceptButton = this.cmdSave;
		this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
		this.BackColor = System.Drawing.Color.AliceBlue;
		this.CancelButton = this.cmdCancel;
		this.ClientSize = new System.Drawing.Size(360, 197);
		this.Controls.Add(this.GroupBox1);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		this.MaximizeBox = false;
		this.MinimizeBox = false;
		this.Name = "frmChangePassword";
		this.ShowInTaskbar = false;
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Change Password";
		this.GroupBox1.ResumeLayout(false);
		this.ResumeLayout(false);

	}

	#End Region

	#Region " Form Events"

	private void  // ERROR: Handles clauses are not supported in C#
frmChangePassword_Load(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : frmChangePassword_Load
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To load the Change Password form
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saruabh S. 
		// Created               : Dec, 2006
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		try {
			SubAddHandlers();
			if (funcGetExistingUserName() == false) {
				//'gFuncShowMessage("Note...", "Problem in retreiving the Active AdminUser", EnumMessageType.Information)
				return;
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

	#Region " Private Functions"

	private void SubAddHandlers()
	{
		//=====================================================================
		// Procedure Name        : SubAddHandlers
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : To add handlers
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S.
		// Created               : 01.01.07
		// Revisions             : 
		//=====================================================================
		cmdCancel.Click += cmdCancel_Click;
		cmdSave.Click += cmdSave_Click;

	}

	private bool funcGetExistingUserName()
	{
		//=====================================================================
		// Procedure Name        :   funcGetExistingUserName
		// Description           :   To Get the Current Users from the database and display them.
		// Purpose               :   To Get the Current Users from the database and display them.
		// Parameters Passed     :   None.
		// Returns               :   None.
		// Parameters Affected   :   None.
		// Assumptions           :
		// Dependencies          :
		// Author                :   Saruabh S. 
		// Created               :   Dec, 2006
		// Revisions             :
		//=====================================================================
		bool result;
		string str_sql;
		OleDb.OleDbDataReader objReader;
		DataRow objDataRow;
		CWaitCursor objwait = new CWaitCursor();

		try {
			//--- Generating dynamic query for selection type
			str_sql = "Select Users.UserName " + "from Users " + "where Users.UserID = " + gstructUserDetails.UserID + " ";

			result = gclsDBFunctions.OpenConnection(gOleDBUserInfoConnection);
			if (!(result)) {
				return false;
			}

			//--- Calling gfuncGetRecords to Get myreader populated with provided Query( strsqlServiceComments (Global String) Records
			gclsDBFunctions.GetRecords(str_sql, gOleDBUserInfoConnection, objReader);

			objReader.Read();

			string str_password;

			lblUserName.Text = (string)objReader.Item("UserName");

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
			if (!objwait == null) {
				objwait.Dispose();
			}
			//---------------------------------------------------------
		}

	}

	private bool funcUpdateUserPassword()
	{
		//=====================================================================
		// Procedure Name        :   funcUpdateUserPassword
		// Description           :   To Save the Edited user Password into database.
		// Purpose               :   To Save the Edited user Password into database.
		// Parameters Passed     :   None.
		// Returns               :   None.
		// Parameters Affected   :   None.
		// Assumptions           :
		// Dependencies          :
		// Author                :   Saruabh S. 
		// Created               :   Dec, 2006
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

			if (gobjMessageAdapter.ShowMessage(constPasswordChange) == true) {
				if (StrComp(txtPassword.Text, txtPasswordconfirm.Text, CompareMethod.Text) != 0) {
					gobjMessageAdapter.ShowMessage(constInvalidPasswordConfirm);
					break; // TODO: might not be correct. Was : Exit Try
				}

				user_id = Convert.ToInt64(gstructUserDetails.UserID);

				//Status = gclsDBFunctions.OpenConnection(gOleDBUserInfoConnection)
				//If Not (Status) Then
				//    Return False
				//End If

				objTransaction = gOleDBUserInfoConnection.BeginTransaction();

				//--- To Encrypt the Password
				string str_password;
				str_password = gfuncEncryptString(Trim(txtPassword.Text));

				//--- Query for Update Passwords Table
				str_sql = "Update Passwords  " + "Set PasswordName = ? " + "where PasswordID = " + password_id + " and UserID = " + user_id + " ";

				//--- Providing command object for Users
				 // ERROR: Not supported in C#: WithStatement


				objCommand.Dispose();
				objTransaction.Commit();
				return (true);
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

	private void cmdSave_Click(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : cmdSave_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To Save the change password
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saruabh S. 
		// Created               : Dec, 2006
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		try {
			if (!funcUpdateUserPassword()) {
				//'gFuncShowMessage("Note...", "Problem in retreiving the active AdminUser", EnumMessageType.Information)
				return;
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

	#End Region

}
