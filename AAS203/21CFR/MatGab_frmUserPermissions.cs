using AAS203.Common;
using System.Data;
using System.Data.OleDb;

public class frmUserPermissions : System.Windows.Forms.Form
{

	#Region "Module level Declarations "
	//Private mstrConnectionString As String
	//Private mclsDBFunctions As New clsDatabaseFunctions()
	//Private mOledbConnection As OleDb.OleDbConnection

	DataTable mobjDataTable = new DataTable("UserAccess");

	DataGridTableStyle mobjGridTableStyle = new DataGridTableStyle();
		#End Region
	bool mblnCmbSelectEvent = false;

	#Region " Windows Form Designer generated code "

	public frmUserPermissions()
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
	internal System.Windows.Forms.CheckBox chkAllAccesRights;
	internal System.Windows.Forms.DataGrid dgUserAccess;
	internal System.Windows.Forms.ComboBox cmbUserName;
	internal System.Windows.Forms.Label lblUserName;
	internal System.Windows.Forms.PictureBox PictureBox1;
	internal System.Windows.Forms.PictureBox PictureBox2;
	internal NETXP.Controls.XPButton cmdSave;
	internal NETXP.Controls.XPButton cmdCancel;
	[System.Diagnostics.DebuggerStepThrough()]
	private void InitializeComponent()
	{
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmUserPermissions));
		this.Panel1 = new System.Windows.Forms.Panel();
		this.cmdCancel = new NETXP.Controls.XPButton();
		this.cmdSave = new NETXP.Controls.XPButton();
		this.chkAllAccesRights = new System.Windows.Forms.CheckBox();
		this.dgUserAccess = new System.Windows.Forms.DataGrid();
		this.cmbUserName = new System.Windows.Forms.ComboBox();
		this.lblUserName = new System.Windows.Forms.Label();
		this.PictureBox1 = new System.Windows.Forms.PictureBox();
		this.PictureBox2 = new System.Windows.Forms.PictureBox();
		this.Panel1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.dgUserAccess).BeginInit();
		this.SuspendLayout();
		//
		//Panel1
		//
		this.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.Panel1.Controls.Add(this.cmdCancel);
		this.Panel1.Controls.Add(this.cmdSave);
		this.Panel1.Controls.Add(this.chkAllAccesRights);
		this.Panel1.Controls.Add(this.dgUserAccess);
		this.Panel1.Controls.Add(this.cmbUserName);
		this.Panel1.Controls.Add(this.lblUserName);
		this.Panel1.Controls.Add(this.PictureBox1);
		this.Panel1.Controls.Add(this.PictureBox2);
		this.Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.Panel1.Location = new System.Drawing.Point(0, 0);
		this.Panel1.Name = "Panel1";
		this.Panel1.Size = new System.Drawing.Size(378, 359);
		this.Panel1.TabIndex = 0;
		//
		//cmdCancel
		//
		this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.cmdCancel.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.cmdCancel.Image = (System.Drawing.Image)resources.GetObject("cmdCancel.Image");
		this.cmdCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.cmdCancel.Location = new System.Drawing.Point(270, 319);
		this.cmdCancel.Name = "cmdCancel";
		this.cmdCancel.Size = new System.Drawing.Size(100, 34);
		this.cmdCancel.TabIndex = 5;
		this.cmdCancel.Text = "&Cancel";
		//
		//cmdSave
		//
		this.cmdSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.cmdSave.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.cmdSave.Image = (System.Drawing.Image)resources.GetObject("cmdSave.Image");
		this.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.cmdSave.Location = new System.Drawing.Point(159, 319);
		this.cmdSave.Name = "cmdSave";
		this.cmdSave.Size = new System.Drawing.Size(100, 34);
		this.cmdSave.TabIndex = 4;
		this.cmdSave.Text = "&Save";
		//
		//chkAllAccesRights
		//
		this.chkAllAccesRights.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.chkAllAccesRights.Location = new System.Drawing.Point(144, 88);
		this.chkAllAccesRights.Name = "chkAllAccesRights";
		this.chkAllAccesRights.Size = new System.Drawing.Size(136, 24);
		this.chkAllAccesRights.TabIndex = 2;
		this.chkAllAccesRights.Text = "Admin Permissions";
		//
		//dgUserAccess
		//
		this.dgUserAccess.BackgroundColor = System.Drawing.Color.AliceBlue;
		this.dgUserAccess.CaptionVisible = false;
		this.dgUserAccess.DataMember = "";
		this.dgUserAccess.HeaderForeColor = System.Drawing.SystemColors.ControlText;
		this.dgUserAccess.Location = new System.Drawing.Point(6, 120);
		this.dgUserAccess.Name = "dgUserAccess";
		this.dgUserAccess.ParentRowsVisible = false;
		this.dgUserAccess.ReadOnly = true;
		this.dgUserAccess.RowHeadersVisible = false;
		this.dgUserAccess.Size = new System.Drawing.Size(364, 194);
		this.dgUserAccess.TabIndex = 3;
		//
		//cmbUserName
		//
		this.cmbUserName.Cursor = System.Windows.Forms.Cursors.Hand;
		this.cmbUserName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cmbUserName.Location = new System.Drawing.Point(160, 32);
		this.cmbUserName.Name = "cmbUserName";
		this.cmbUserName.Size = new System.Drawing.Size(208, 23);
		this.cmbUserName.TabIndex = 1;
		//
		//lblUserName
		//
		this.lblUserName.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblUserName.Location = new System.Drawing.Point(75, 35);
		this.lblUserName.Name = "lblUserName";
		this.lblUserName.Size = new System.Drawing.Size(80, 17);
		this.lblUserName.TabIndex = 28;
		this.lblUserName.Text = "User Name";
		//
		//PictureBox1
		//
		this.PictureBox1.BackColor = System.Drawing.Color.AliceBlue;
		this.PictureBox1.Image = (System.Drawing.Image)resources.GetObject("PictureBox1.Image");
		this.PictureBox1.Location = new System.Drawing.Point(5, 3);
		this.PictureBox1.Name = "PictureBox1";
		this.PictureBox1.Size = new System.Drawing.Size(48, 48);
		this.PictureBox1.TabIndex = 34;
		this.PictureBox1.TabStop = false;
		//
		//PictureBox2
		//
		this.PictureBox2.BackColor = System.Drawing.Color.Gray;
		this.PictureBox2.Location = new System.Drawing.Point(72, 16);
		this.PictureBox2.Name = "PictureBox2";
		this.PictureBox2.Size = new System.Drawing.Size(290, 2);
		this.PictureBox2.TabIndex = 35;
		this.PictureBox2.TabStop = false;
		//
		//frmUserPermissions
		//
		this.AcceptButton = this.cmdSave;
		this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
		this.BackColor = System.Drawing.Color.AliceBlue;
		this.CancelButton = this.cmdCancel;
		this.ClientSize = new System.Drawing.Size(378, 359);
		this.Controls.Add(this.Panel1);
		this.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		this.MaximizeBox = false;
		this.MinimizeBox = false;
		this.Name = "frmUserPermissions";
		this.ShowInTaskbar = false;
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "User Access Permissions";
		this.Panel1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.dgUserAccess).EndInit();
		this.ResumeLayout(false);

	}

	#End Region

	#Region "Form Events"

	private void  // ERROR: Handles clauses are not supported in C#
frmUserPermissions_Load(System.Object sender, System.EventArgs e)
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

	private void  // ERROR: Handles clauses are not supported in C#
chkAllAccesRights_CheckedChanged(System.Object sender, System.EventArgs e)
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
			if (chkAllAccesRights.Checked == true) {
				if (funcSelectAllAccess()) {
					dgUserAccess.ReadOnly = true;
				}
			} else {
				//If funcClearAllAccess() Then
				if (dgUserAccess.ReadOnly == true) {
					dgUserAccess.ReadOnly = false;
				}
				//End If
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
			if (funcSaveUserPermisssions()) {
				gobjMessageAdapter.ShowMessage(constUserPermissionsSaved);
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

	private void  // ERROR: Handles clauses are not supported in C#
cmbUserName_SelectedIndexChanged(object sender, System.EventArgs e)
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
			if (mblnCmbSelectEvent) {
				long user_id = Convert.ToInt64(cmbUserName.SelectedValue);
				funcClearAllAccess();
				funcGetAccessForUser();
				////---- Added by Sachin Dokhale.
				subFormatDataGrid();
				////-----
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

	#Region "Private functions"

	//--------------------------------------------------------
	//    General functions used for Adding User.
	//--- funcInitialize  - To Initialize the form and show all the users present in Combo Box.
	//--- funcGetExistingUsers - To Get the Current Users from the database and display them in ComboBox.
	//--- funcGetAccessForUser - To Get the Access Permissions for the Currently Selected User.
	//--- subCreateDataTable - To Create a Data Table and add Values in it.
	//--- subFormatDataGrid - To Format the DataGrid.
	//--- funcSaveUserPermisssions - To Save the User Permissions into the Database.
	//--- funcInsertData - To Add/Insert New User Access Record.
	//--- funcUpdateData - To Update User Access Record.
	//--- funcClearAllAccess - To Clear All Access Rights for the User.

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
			cmbUserName.Items.Clear();

			//--- Passing database name to clsstrConnString property
			//mstrConnectionString = gclsDBFunctions.ConnectionString(CONST_USERINFO_DATABASENAME)

			//--- Passing connection string to Connection Object
			//mOledbConnection = New OleDbConnection(mstrConnectionString)

			funcGetExistingUsers();
			subCreateDataTable();
			funcGetAllAccessValues();
			subFormatDataGrid();
			mblnCmbSelectEvent = true;
			cmdSave.Click += cmdSave_Click;
			cmdCancel.Click += cmdCancel_Click;
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
		OleDbDataAdapter objDataAdapter;
		OleDbCommand objCommand;
		OleDbDataReader objReader;
		DataSet ds = new DataSet();
		CWaitCursor objWait = new CWaitCursor();

		try {
			//--- Generating dynamic query for selection type
			str_sql = "Select UserID ,UserName " + "from Users where Active = 1 and UserID > 0 Order by UserName ";

			//result = gclsDBFunctions.OpenConnection(gOleDBUserInfoConnection)
			//If Not (result) Then
			//    Return False
			//End If

			objCommand = new OleDbCommand(str_sql, gOleDBUserInfoConnection);
			objDataAdapter = new OleDbDataAdapter(objCommand);
			objDataAdapter.Fill(ds, "Users");

			DataView objDV;
			objDV = new DataView(ds.Tables("Users"));

			cmbUserName.Items.Clear();
			cmbUserName.DataSource = objDV;
			cmbUserName.DisplayMember = "UserName";
			cmbUserName.ValueMember = "UserID";

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
		try {
			mobjDataTable.Columns.Add(new DataColumn("AccessID", typeof(int)));
			mobjDataTable.Columns.Add(new DataColumn("AccessName", typeof(string)));
			mobjDataTable.Columns.Add(new DataColumn("Rights", typeof(bool)));

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
			//objWait.Dispose()
			//---------------------------------------------------------
		}
	}

	private bool funcGetAllAccessValues()
	{
		//=====================================================================
		// Procedure Name        :   funcGetAllAccessValues
		// Description           :   To Get All the Access Permissions from the Access Master.
		// Purpose               :   To Get All the Access Permissions from the Access Master.
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
		long user_id;
		long access_id;
		CWaitCursor objWait = new CWaitCursor();
		try {
			str_sql = "Select AccessID ,Access " + "from AccessMaster where Suspend = 0 ORDER by AccessID ";

			//result = gclsDBFunctions.OpenConnection(gOleDBUserInfoConnection)
			//If Not (result) Then
			//    Return False
			//End If

			//--- Calling gfuncGetRecords to Get myreader populated with provided Query( strsqlServiceComments (Global String) Records
			gclsDBFunctions.GetRecords(str_sql, gOleDBUserInfoConnection, objReader);

			while (objReader.Read) {
				objDataRow = mobjDataTable.NewRow;
				objDataRow("AccessID") = Convert.ToInt32(objReader.Item("AccessID"));
				objDataRow("AccessName") = (string)objReader.Item("Access");
				mobjDataTable.Rows.Add(objDataRow);
			}

			objReader.Close();

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


		funcClearAllAccess();
		funcGetAccessForUser();

		//user_id = Convert.ToInt64(cmbUserName.SelectedValue)
		//For Each objDataRow In mobjDataTable.Rows
		//    access_id = objDataRow("AccessID")
		//    If funcValidateUserAccess(user_id, access_id) Then
		//        objDataRow("Rights") = True
		//    Else
		//        objDataRow("Rights") = False
		//    End If
		//Next

		return true;

	}

	private bool funcGetAccessForUser()
	{
		//=====================================================================
		// Procedure Name        :   funcGetAccessForUser
		// Description           :   To Get the Access Permissions for the Currently Selected User.
		// Purpose               :   To Get the Access Permissions for the Currently Selected User.
		// Parameters Passed     :   None.
		// Returns               :   None.
		// Parameters Affected   :   None.
		// Assumptions           :
		// Dependencies          :
		// Author                :   Gitesh
		// Created               :   January, 2003 
		// Revisions             :
		//=====================================================================
		long user_id;
		long access_id;
		DataRow objDataRow;
		CWaitCursor objWait = new CWaitCursor();

		//--- This flag is only used to check whther the user has all 
		//--- access wrigths and if he has it then the checdk box has to made
		//--- checked (used by nilesh)
		bool blnAllAcceswrigths;


		try {
			user_id = Convert.ToInt64(cmbUserName.SelectedValue);
			foreach ( objDataRow in mobjDataTable.Rows) {
				access_id = objDataRow("AccessID");
				if (funcValidateUserAccess(user_id, access_id)) {
					objDataRow("Rights") = true;
				//modified by kamal
				//if only last access is true it shows true fir all
				//    blnAllAcceswrigths = True
				} else {
					objDataRow("Rights") = false;
					//     blnAllAcceswrigths = False
				}
			}

			foreach ( objDataRow in mobjDataTable.Rows) {
				if (objDataRow("Rights") == false) {
					blnAllAcceswrigths = false;
					break; // TODO: might not be correct. Was : Exit For
				}
				blnAllAcceswrigths = true;
			}

			//--- Logic to check them
			if (blnAllAcceswrigths == true) {
				chkAllAccesRights.Checked = true;
				if (dgUserAccess.ReadOnly == false) {
					dgUserAccess.ReadOnly = true;
				}
			} else {
				chkAllAccesRights.Checked = false;
				if (dgUserAccess.ReadOnly == true) {
					dgUserAccess.ReadOnly = false;
				}
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

	private bool funcClearAllAccess()
	{
		//=====================================================================
		// Procedure Name        :   funcClearAllAccess 
		// Description           :   To Clear All Access Rights for the User.
		// Purpose               :   To Clear All Access Rights for the User.
		// Parameters Passed     :   None.
		// Returns               :   None.
		// Parameters Affected   :   None.
		// Assumptions           :
		// Dependencies          :
		// Author                :   Gitesh
		// Created               :   January, 2003 
		// Revisions             :
		//=====================================================================
		DataRow objDataRow;
		CWaitCursor objWait = new CWaitCursor();

		try {
			foreach ( objDataRow in mobjDataTable.Rows) {
				objDataRow("Rights") = false;
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

	private bool funcSelectAllAccess()
	{
		//=====================================================================
		// Procedure Name        :   funcClearAllAccess 
		// Description           :   To Select all Access wrigths Present in the List
		// Purpose               :   To Select all Access wrigths Present in the List
		// Parameters Passed     :   None.
		// Returns               :   None.
		// Parameters Affected   :   None.
		// Assumptions           :
		// Dependencies          :
		// Author                :   Nilesh Shirode
		// Created               :   27 June 2004 
		// Revisions             :
		//=====================================================================
		DataRow objDataRow;
		CWaitCursor objWait = new CWaitCursor();

		try {
			foreach ( objDataRow in mobjDataTable.Rows) {
				objDataRow("Rights") = true;
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
		DataGridBoolColumn objBoolColumn;
		DataView objDataView = new DataView();
		CWaitCursor objWait = new CWaitCursor();
		try {
			dgUserAccess.TableStyles.Clear();
			objDataView.Table = mobjDataTable;
			objDataView.AllowNew = false;
			dgUserAccess.DataSource = objDataView;
			dgUserAccess.ReadOnly = false;
			dgUserAccess.AllowSorting = false;


			mobjGridTableStyle = new DataGridTableStyle();
			mobjGridTableStyle.RowHeadersVisible = false;
			mobjGridTableStyle.ResetAlternatingBackColor();
			mobjGridTableStyle.ResetBackColor();
			mobjGridTableStyle.ResetForeColor();
			mobjGridTableStyle.ResetGridLineColor();
			mobjGridTableStyle.BackColor = Color.White;
			mobjGridTableStyle.GridLineColor = Color.Gray;
			mobjGridTableStyle.HeaderBackColor = Color.AliceBlue;
			mobjGridTableStyle.HeaderForeColor = Color.Black;
			mobjGridTableStyle.AlternatingBackColor = Color.White;
			mobjGridTableStyle.AllowSorting = false;
			mobjGridTableStyle.ReadOnly = false;

			mobjGridTableStyle.MappingName = "UserAccess";

			objTextColumn = new DataGridTextBoxColumn();
			objTextColumn.MappingName = "AccessID";
			objTextColumn.HeaderText = "Access ID";
			objTextColumn.Width = 0;
			objTextColumn.ReadOnly = true;
			mobjGridTableStyle.GridColumnStyles.Add(objTextColumn);

			objTextColumn = new DataGridTextBoxColumn();
			objTextColumn.MappingName = "AccessName";
			objTextColumn.HeaderText = "Access Name";
			//objTextColumn.Width = 150
			objTextColumn.Width = 260;
			//((dgUserAccess.Width / 2) + (dgUserAccess.Width / 4)) - 6
			objTextColumn.ReadOnly = true;
			mobjGridTableStyle.GridColumnStyles.Add(objTextColumn);

			objBoolColumn = new DataGridBoolColumn();
			objBoolColumn.MappingName = "Rights";
			objBoolColumn.HeaderText = "Permissions";
			objBoolColumn.Width = (dgUserAccess.Width / 4) - 8;
			objBoolColumn.ReadOnly = false;
			objBoolColumn.AllowNull = false;
			mobjGridTableStyle.GridColumnStyles.Add(objBoolColumn);

			//mobjGridTableStyle.GridLineColor = Color.LightBlue
			dgUserAccess.TableStyles.Add(mobjGridTableStyle);

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

	private bool funcSaveUserPermisssions()
	{
		//=====================================================================
		// Procedure Name        :   funcSaveUserPermisssions
		// Description           :   To Save the User Permissions into the Database.
		// Purpose               :   To Save the User Permissions into the Database.
		// Parameters Passed     :   None.
		// Returns               :   None.
		// Parameters Affected   :   None.
		// Assumptions           :
		// Dependencies          :
		// Author                :   Gitesh
		// Created               :   January, 2003 
		// Revisions             :
		//=====================================================================
		long user_id;
		long access_id;
		DataRow objDataRow;
		string user_rights;
		string str_sql;
		int rec_cnt;
		OleDbDataReader objReader;
		bool record_exists;
		CWaitCursor objWait = new CWaitCursor();

		try {
			user_id = Convert.ToInt64(cmbUserName.SelectedValue);
			rec_cnt = 0;
			foreach ( objDataRow in mobjDataTable.Rows) {
				access_id = objDataRow("AccessID");
				if ((objDataRow("Rights") == true)) {
					if (rec_cnt == 0) {
						user_rights = access_id.ToString();
					} else {
						user_rights = user_rights + "," + access_id.ToString();
					}
					rec_cnt = rec_cnt + 1;
				}
			}

		//MessageBox.Show(user_rights)

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



		try {
			if (!(gclsDBFunctions.OpenConnection(gOleDBUserInfoConnection))) {
				return false;
			}

			str_sql = "Select * from UserAccess where UserID = " + user_id + "";

			record_exists = gclsDBFunctions.RecordExists(str_sql, gOleDBUserInfoConnection);
			if (user_rights == null) {
				user_rights = "0";
			}
			if (record_exists) {
				funcUpdateData(user_id, user_rights);
			} else {
				funcInsertData(user_id, user_rights);
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

	private bool funcInsertData(long user_id, string user_rights)
	{
		//=====================================================================
		// Procedure Name        :   funcInsertData
		// Description           :   To Add/Insert New User Access Record.
		// Purpose               :   To Add/Insert New User Access Record.
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
		bool Status;
		string str_sql;
		OleDbCommand objCommand = new OleDbCommand();
		long useraccess_id;

		try {
			//Status = gclsDBFunctions.OpenConnection(gOleDBUserInfoConnection)
			//If Not (Status) Then
			//    Return False
			//End If

			//--- Generating ID for UserAccess
			useraccess_id = gclsDBFunctions.GetNextID("UserAccess", "UserAccessID", gOleDBUserInfoConnection);

			str_sql = "Insert into UserAccess " + " values(?,?,?)";

			//--- Providing command object for Infomaster
			 // ERROR: Not supported in C#: WithStatement


			objCommand.Dispose();
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

	private object funcUpdateData(long user_id, string user_rights)
	{
		//=====================================================================
		// Procedure Name        :   funcUpdateData
		// Description           :   To Update User Access Record.
		// Purpose               :   To Update User Access Record.
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
		bool Status;
		string strsqlMaster;
		OleDbCommand objCommand = new OleDbCommand();

		try {
			Status = gclsDBFunctions.OpenConnection(gOleDBUserInfoConnection);
			if (!(Status)) {
				return false;
			}

			strsqlMaster = "Update UserAccess set " + "UserAccess = ? " + "where UserID = " + user_id + "";

			//--- Providing command object for Infomaster
			 // ERROR: Not supported in C#: WithStatement


			objCommand.Dispose();
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

	#End Region

	#Region "User / Access Validation Functions"

	//--------------------------------------------------------
	//    General functions used for Adding User.
	//--- funcValidateUser - To Validate the User against the Password entered by him.
	//--- funcValidateUserAccess - To Validate the Access Rights to the User.

	private bool funcValidateUser(long user_id, string password)
	{
		//=====================================================================
		// Procedure Name        :   funcValidateUser 
		// Description           :   To Validate the User against the Password entered by him.
		// Purpose               :   To Validate the User against the Password entered by him.
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
		bool result = false;
		string str_sql;
		OleDb.OleDbDataReader objReader;
		long password_id;


		try {
			//--- Generating dynamic query for selection type

			str_sql = "Select PasswordID " + "from Passwords ,Users where Passwords.UserID = " + user_id + " and Passwords.Password = '" + password + "' " + "and Passwords.UserID = Users.UserID and Users.Active = 1 ";

			//result = gclsDBFunctions.OpenConnection(gOleDBUserInfoConnection)
			//If Not (result) Then
			//    result = False
			//    Return result
			//End If

			//--- Calling gfuncGetRecords to Get myreader populated with provided Query( strsqlServiceComments (Global String) Records
			if (!gclsDBFunctions.GetRecords(str_sql, gOleDBUserInfoConnection, objReader)) {
				result = false;
				return result;
			}

			while (objReader.Read) {
				password_id = Convert.ToInt64(objReader.Item("PasswordID"));
				result = true;
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

	private bool funcValidateUserAccess(long user_id, long access_id)
	{
		//=====================================================================
		// Procedure Name        :   funcValidateUserAccess 
		// Description           :   To Validate the Access Rights to the User.
		// Purpose               :   To Validate the Access Rights to the User.
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
		bool result = false;
		string str_sql;
		OleDb.OleDbDataReader objReader;
		string str_access;
		string[] arr_access;
		int rec_cnt;
		int temp_cnt;


		try {
			//--- Zero Code stands for Admin which has all rights.
			if ((user_id == 0)) {
				result = true;
				return result;
			}

			//--- Generating dynamic query for selection type
			str_sql = "Select UserAccess " + "from UserAccess , Users where UserAccess.UserID = " + user_id + "  and UserAccess.UserID = Users.UserID and Users.Active = 1 ";

			//result = gclsDBFunctions.OpenConnection(gOleDBUserInfoConnection)
			//If Not (result) Then
			//    result = False
			//    Return result
			//End If

			//--- Calling gfuncGetRecords to Get myreader populated with provided Query( strsqlServiceComments (Global String) Records
			if (!gclsDBFunctions.GetRecords(str_sql, gOleDBUserInfoConnection, objReader)) {
				result = false;
				return result;
			}

			while (objReader.Read) {
				str_access = objReader.Item("UserAccess");
			}
			objReader.Close();

			if ((str_access == "" | str_access == null)) {
				return false;
			}

			arr_access = str_access.Split(",");

			rec_cnt = arr_access.Length;
			result = false;
			for (temp_cnt = 0; temp_cnt <= (rec_cnt - 1); temp_cnt++) {
				long id = Convert.ToInt64(arr_access.GetValue(temp_cnt));
				if ((id == access_id)) {
					result = true;
					return result;
				}
			}

			return result;

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

	//Private Sub dgUserAccess_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgUserAccess.Click
	//    Dim objDataRow As DataRow
	//    Dim a As Integer = 0

	//    For Each objDataRow In dgUserAccess.DataSource.table.rows  'mobjDataTable.Rows
	//        'dgUserAccess.HitTestInfo.   
	//        If dgUserAccess.Item(a, 2) = False Then
	//            'If objDataRow("Rights") = False Then
	//            chkAllAccesRights.Checked = False
	//            Exit For
	//        End If
	//        a += 1
	//    Next
	//End Sub


}
