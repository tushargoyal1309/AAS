using AAS203.Common;
using System.Text;
using System.Data.OleDb;
public class frmLogin : System.Windows.Forms.Form
{

	#Region "Module Level Declarations"
		#End Region
	private bool mblnLogin;

	#Region " Windows Form Designer generated code "

	public frmLogin()
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
	internal System.Windows.Forms.Label Label1;
	internal System.Windows.Forms.ComboBox cmbLoginName;
	internal System.Windows.Forms.Label Label2;
	internal System.Windows.Forms.TextBox txtPassword;
	internal NETXP.Controls.XPButton btnLogin;
	internal NETXP.Controls.XPButton btnCancel;
	internal CodeIntellects.Office2003Controls.Office2003Header Office2003Header1;
	[System.Diagnostics.DebuggerStepThrough()]
	private void InitializeComponent()
	{
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmLogin));
		this.Label1 = new System.Windows.Forms.Label();
		this.cmbLoginName = new System.Windows.Forms.ComboBox();
		this.Label2 = new System.Windows.Forms.Label();
		this.txtPassword = new System.Windows.Forms.TextBox();
		this.btnCancel = new NETXP.Controls.XPButton();
		this.btnLogin = new NETXP.Controls.XPButton();
		this.Office2003Header1 = new CodeIntellects.Office2003Controls.Office2003Header();
		this.SuspendLayout();
		//
		//Label1
		//
		this.Label1.BackColor = System.Drawing.Color.Transparent;
		this.Label1.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.Label1.ForeColor = System.Drawing.Color.Black;
		this.Label1.Location = new System.Drawing.Point(74, 54);
		this.Label1.Name = "Label1";
		this.Label1.Size = new System.Drawing.Size(80, 17);
		this.Label1.TabIndex = 0;
		this.Label1.Text = "User Name :";
		this.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
		//
		//cmbLoginName
		//
		this.cmbLoginName.BackColor = System.Drawing.Color.White;
		this.cmbLoginName.Cursor = System.Windows.Forms.Cursors.Hand;
		this.cmbLoginName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cmbLoginName.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.cmbLoginName.ForeColor = System.Drawing.Color.Black;
		this.cmbLoginName.Location = new System.Drawing.Point(164, 48);
		this.cmbLoginName.Name = "cmbLoginName";
		this.cmbLoginName.Size = new System.Drawing.Size(196, 23);
		this.cmbLoginName.TabIndex = 0;
		//
		//Label2
		//
		this.Label2.BackColor = System.Drawing.Color.Transparent;
		this.Label2.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.Label2.ForeColor = System.Drawing.Color.Black;
		this.Label2.Location = new System.Drawing.Point(74, 82);
		this.Label2.Name = "Label2";
		this.Label2.Size = new System.Drawing.Size(80, 17);
		this.Label2.TabIndex = 0;
		this.Label2.Text = "Password :";
		this.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
		//
		//txtPassword
		//
		this.txtPassword.BackColor = System.Drawing.Color.White;
		this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txtPassword.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.txtPassword.ForeColor = System.Drawing.Color.Black;
		this.txtPassword.Location = new System.Drawing.Point(164, 80);
		this.txtPassword.MaxLength = 50;
		this.txtPassword.Name = "txtPassword";
		this.txtPassword.PasswordChar = Microsoft.VisualBasic.ChrW(42);
		this.txtPassword.Size = new System.Drawing.Size(196, 21);
		this.txtPassword.TabIndex = 1;
		this.txtPassword.Text = "";
		//
		//btnCancel
		//
		this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnCancel.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnCancel.Image = (System.Drawing.Image)resources.GetObject("btnCancel.Image");
		this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnCancel.Location = new System.Drawing.Point(260, 128);
		this.btnCancel.Name = "btnCancel";
		this.btnCancel.Size = new System.Drawing.Size(100, 34);
		this.btnCancel.TabIndex = 3;
		this.btnCancel.Text = "&Cancel";
		//
		//btnLogin
		//
		this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnLogin.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnLogin.Image = (System.Drawing.Image)resources.GetObject("btnLogin.Image");
		this.btnLogin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnLogin.Location = new System.Drawing.Point(155, 128);
		this.btnLogin.Name = "btnLogin";
		this.btnLogin.Size = new System.Drawing.Size(100, 34);
		this.btnLogin.TabIndex = 2;
		this.btnLogin.Text = "&Login";
		//
		//Office2003Header1
		//
		this.Office2003Header1.BackColor = System.Drawing.SystemColors.Control;
		this.Office2003Header1.Dock = System.Windows.Forms.DockStyle.Top;
		this.Office2003Header1.Location = new System.Drawing.Point(0, 0);
		this.Office2003Header1.Name = "Office2003Header1";
		this.Office2003Header1.Size = new System.Drawing.Size(382, 22);
		this.Office2003Header1.TabIndex = 4;
		this.Office2003Header1.TitleFont = new System.Drawing.Font("Tahoma", 10f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.Office2003Header1.TitleText = "Login Authentication";
		//
		//frmLogin
		//
		this.AcceptButton = this.btnLogin;
		this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
		this.BackColor = System.Drawing.Color.AliceBlue;
		this.CancelButton = this.btnCancel;
		this.ClientSize = new System.Drawing.Size(382, 178);
		this.ControlBox = false;
		this.Controls.Add(this.Office2003Header1);
		this.Controls.Add(this.btnLogin);
		this.Controls.Add(this.btnCancel);
		this.Controls.Add(this.txtPassword);
		this.Controls.Add(this.cmbLoginName);
		this.Controls.Add(this.Label1);
		this.Controls.Add(this.Label2);
		this.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.ForeColor = System.Drawing.Color.Black;
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		this.MaximizeBox = false;
		this.MinimizeBox = false;
		this.Name = "frmLogin";
		this.ShowInTaskbar = false;
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.TopMost = true;
		this.ResumeLayout(false);

	}

	#End Region

	#Region "Form Events"

	private void  // ERROR: Handles clauses are not supported in C#
btnLogin_Click(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : btnLogin_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To validate the user.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saruabh S. 
		// Created               : Dec, 2006
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		long lngUserID;
		string strPassword;
		int intCounter;
		int intUserList;
		string strAccess;
		string[] strSplittedAcess;
		string strSQL;
		OleDb.OleDbDataReader objReader;
		OleDb.OleDbDataReader objReaderAccess;

		try {
			this.TopMost = false;
			if (!cmbLoginName.Text == "") {
				lngUserID = Convert.ToInt64(cmbLoginName.SelectedValue);
				strPassword = txtPassword.Text;
				if (gfuncValidateUser(lngUserID, strPassword)) {
					gstructUserDetails.Access = new ArrayList();
					strSQL = "Select * From UserAccess Where UserID=" + lngUserID;
					//--- Calling gfuncGetRecords to Get myreader populated with provided Query( strsqlServiceComments (Global String) Records
					if (gclsDBFunctions.GetRecords(strSQL, gOleDBUserInfoConnection, objReader)) {
						while (objReader.Read) {
							strAccess = Convert.ToString(objReader.Item("UserAccess"));
						}
						objReader.Close();

						if (Len(strAccess) > 0) {
							strSplittedAcess = strAccess.Split(",");
							for (intCounter = 0; intCounter <= strSplittedAcess.Length - 1; intCounter++) {
								gstructUserDetails.Access.Add(Convert.ToInt64(strSplittedAcess(intCounter)));
							}
						}
					}
					gstructUserDetails.UserID = lngUserID;
					gstructUserDetails.UserName = Trim(cmbLoginName.Text);
					gstructUserDetails.UserPassword = Trim(txtPassword.Text);

					LoginSuccessfull = true;
					this.DialogResult = DialogResult.OK;
				} else {
					gstructUserDetails.UserID = lngUserID;
					gstructUserDetails.UserName = Trim(cmbLoginName.Text);
					gfuncInsertActivityLog(EnumModules.Login, "Login failed", strPassword);
					gobjMessageAdapter.ShowMessage(constIncorrectPassword);
					LoginSuccessfull = false;
					txtPassword.Text = "";
					this.DialogResult = DialogResult.None;
				}
			} else {
				gobjMessageAdapter.ShowMessage(constUserNotSelected);
				this.DialogResult = DialogResult.None;
			}
			this.TopMost = true;

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
frmLogin_Activated(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : frmLogin_Activated
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To activate the Login form.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saruabh S. 
		// Created               : Dec, 2006
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		try {
			txtPassword.Focus();

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
frmLogin_Load(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : frmLogin_Load
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To load the Login form.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saruabh S. 
		// Created               : Dec, 2006
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		try {
			LoginSuccessfull = false;
			funcInitialize();
			txtPassword.Focus();

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

	#Region "Private functions"

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
		// Created               :   March, 2003 
		// Revisions             :
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		try {
			cmbLoginName.Items.Clear();
			funcGetExistingUsers();

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
		// Created               :   March, 2003 
		// Revisions             :
		//=====================================================================
		bool result;
		string str_sql;
		OleDbDataAdapter objDataAdapter;
		OleDbCommand objCommand;
		OleDbDataReader objReader;
		DataSet ds = new DataSet();
		string strUserName;
		int intUserId;
		CWaitCursor objWait = new CWaitCursor();

		try {
			//--- Generating dynamic query for selection type
			str_sql = "Select UserID ,UserName " + "from Users where Active = 1 ";
			objCommand = new OleDbCommand(str_sql, gOleDBUserInfoConnection);
			objDataAdapter = new OleDbDataAdapter(objCommand);
			objDataAdapter.Fill(ds, "Users");

			DataView objDV;
			objDV = new DataView(ds.Tables("Users"));

			cmbLoginName.Items.Clear();
			cmbLoginName.DataSource = objDV;
			cmbLoginName.DisplayMember = "UserName";
			cmbLoginName.ValueMember = "UserID";

			if (cmbLoginName.Items.Count != 0) {
				//---commented mdf by kamal & sns  on 13 oct 2004
				intUserId = (int)gstructUserDetails.UserID;
				cmbLoginName.SelectedValue = intUserId;
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
		return true;

	}

	#End Region

	#Region "Property"
	private bool LoginSuccessfull {
		get { return mblnLogin; }
		set { mblnLogin = Value; }
	}
	#End Region


	private void  // ERROR: Handles clauses are not supported in C#
btnCancel_Click(System.Object sender, System.EventArgs e)
	{
		this.DialogResult = DialogResult.Cancel;
	}

}
