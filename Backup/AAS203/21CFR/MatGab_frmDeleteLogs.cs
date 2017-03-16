using AAS203.Common;
using System.Data;
using System.Data.OleDb;
using System.IO;


public class frmDeleteLogs : System.Windows.Forms.Form
{

	#Region "Module level Declarations "
	private string mstrConnectionString;
		#End Region
	private clsDatabaseFunctions mclsDBFunctions = new clsDatabaseFunctions();

	#Region " Windows Form Designer generated code "

	public frmDeleteLogs()
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
	internal System.Windows.Forms.PictureBox PictureBox2;
	internal System.Windows.Forms.PictureBox PictureBox1;
	internal System.Windows.Forms.DateTimePicker datetimepickTo;
	internal System.Windows.Forms.Label lblToDate;
	internal System.Windows.Forms.Label lblFromDate;
	internal NETXP.Controls.XPButton cmdOK;
	internal NETXP.Controls.XPButton cmdCancel;
	internal System.Windows.Forms.DateTimePicker datetimepickFrom1;
	internal System.Windows.Forms.DateTimePicker datetimepickFrom;
	[System.Diagnostics.DebuggerStepThrough()]
	private void InitializeComponent()
	{
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmDeleteLogs));
		this.PictureBox2 = new System.Windows.Forms.PictureBox();
		this.PictureBox1 = new System.Windows.Forms.PictureBox();
		this.datetimepickTo = new System.Windows.Forms.DateTimePicker();
		this.lblToDate = new System.Windows.Forms.Label();
		this.datetimepickFrom1 = new System.Windows.Forms.DateTimePicker();
		this.lblFromDate = new System.Windows.Forms.Label();
		this.cmdOK = new NETXP.Controls.XPButton();
		this.cmdCancel = new NETXP.Controls.XPButton();
		this.datetimepickFrom = new System.Windows.Forms.DateTimePicker();
		this.SuspendLayout();
		//
		//PictureBox2
		//
		this.PictureBox2.BackColor = System.Drawing.Color.Gray;
		this.PictureBox2.Location = new System.Drawing.Point(72, 16);
		this.PictureBox2.Name = "PictureBox2";
		this.PictureBox2.Size = new System.Drawing.Size(270, 2);
		this.PictureBox2.TabIndex = 31;
		this.PictureBox2.TabStop = false;
		//
		//PictureBox1
		//
		this.PictureBox1.BackColor = System.Drawing.Color.AliceBlue;
		this.PictureBox1.BackgroundImage = (System.Drawing.Image)resources.GetObject("PictureBox1.BackgroundImage");
		this.PictureBox1.Location = new System.Drawing.Point(16, 16);
		this.PictureBox1.Name = "PictureBox1";
		this.PictureBox1.Size = new System.Drawing.Size(48, 48);
		this.PictureBox1.TabIndex = 30;
		this.PictureBox1.TabStop = false;
		//
		//datetimepickTo
		//
		this.datetimepickTo.Cursor = System.Windows.Forms.Cursors.Hand;
		this.datetimepickTo.CustomFormat = "dd - MMM - yyyy";
		this.datetimepickTo.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.datetimepickTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
		this.datetimepickTo.Location = new System.Drawing.Point(208, 80);
		this.datetimepickTo.Name = "datetimepickTo";
		this.datetimepickTo.Size = new System.Drawing.Size(134, 21);
		this.datetimepickTo.TabIndex = 34;
		//
		//lblToDate
		//
		this.lblToDate.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblToDate.Location = new System.Drawing.Point(137, 82);
		this.lblToDate.Name = "lblToDate";
		this.lblToDate.Size = new System.Drawing.Size(64, 20);
		this.lblToDate.TabIndex = 35;
		this.lblToDate.Text = "To Date :";
		this.lblToDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		//
		//datetimepickFrom1
		//
		this.datetimepickFrom1.Cursor = System.Windows.Forms.Cursors.Hand;
		this.datetimepickFrom1.CustomFormat = "dd - MMM - yyyy";
		this.datetimepickFrom1.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.datetimepickFrom1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
		this.datetimepickFrom1.Location = new System.Drawing.Point(8, 136);
		this.datetimepickFrom1.Name = "datetimepickFrom1";
		this.datetimepickFrom1.Size = new System.Drawing.Size(32, 21);
		this.datetimepickFrom1.TabIndex = 32;
		this.datetimepickFrom1.Value = new System.DateTime(2009, 1, 2, 16, 38, 0, 0);
		this.datetimepickFrom1.Visible = false;
		//
		//lblFromDate
		//
		this.lblFromDate.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblFromDate.Location = new System.Drawing.Point(118, 44);
		this.lblFromDate.Name = "lblFromDate";
		this.lblFromDate.Size = new System.Drawing.Size(83, 16);
		this.lblFromDate.TabIndex = 33;
		this.lblFromDate.Text = "From Date :";
		this.lblFromDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		//
		//cmdOK
		//
		this.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.cmdOK.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.cmdOK.Image = (System.Drawing.Image)resources.GetObject("cmdOK.Image");
		this.cmdOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.cmdOK.Location = new System.Drawing.Point(130, 120);
		this.cmdOK.Name = "cmdOK";
		this.cmdOK.Size = new System.Drawing.Size(100, 34);
		this.cmdOK.TabIndex = 36;
		this.cmdOK.Text = "&Delete";
		//
		//cmdCancel
		//
		this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.cmdCancel.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.cmdCancel.Image = (System.Drawing.Image)resources.GetObject("cmdCancel.Image");
		this.cmdCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.cmdCancel.Location = new System.Drawing.Point(240, 120);
		this.cmdCancel.Name = "cmdCancel";
		this.cmdCancel.Size = new System.Drawing.Size(100, 34);
		this.cmdCancel.TabIndex = 37;
		this.cmdCancel.Text = "&Cancel";
		//
		//datetimepickFrom
		//
		this.datetimepickFrom.Cursor = System.Windows.Forms.Cursors.Hand;
		this.datetimepickFrom.CustomFormat = "dd - MMM - yyyy";
		this.datetimepickFrom.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.datetimepickFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
		this.datetimepickFrom.Location = new System.Drawing.Point(208, 42);
		this.datetimepickFrom.Name = "datetimepickFrom";
		this.datetimepickFrom.Size = new System.Drawing.Size(134, 21);
		this.datetimepickFrom.TabIndex = 38;
		//
		//frmDeleteLogs
		//
		this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
		this.BackColor = System.Drawing.Color.AliceBlue;
		this.CancelButton = this.cmdCancel;
		this.ClientSize = new System.Drawing.Size(346, 167);
		this.Controls.Add(this.datetimepickFrom);
		this.Controls.Add(this.cmdCancel);
		this.Controls.Add(this.cmdOK);
		this.Controls.Add(this.datetimepickTo);
		this.Controls.Add(this.lblToDate);
		this.Controls.Add(this.datetimepickFrom1);
		this.Controls.Add(this.lblFromDate);
		this.Controls.Add(this.PictureBox2);
		this.Controls.Add(this.PictureBox1);
		this.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		this.MaximizeBox = false;
		this.MinimizeBox = false;
		this.Name = "frmDeleteLogs";
		this.ShowInTaskbar = false;
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Delete Logs";
		this.ResumeLayout(false);

	}

	#End Region

	#Region "Form Events"

	private void  // ERROR: Handles clauses are not supported in C#
frmDeleteLogs_Load(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : frmDeleteLogs_Load
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To load the Delete Logs form.
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
		// Purpose               : To close the Delete Logs form.
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

	private void cmdOK_Click(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : cmdOK_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To delete the logs between the selected date.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saruabh S. 
		// Created               : Dec, 2006
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();

		try {
			if (funcDeleteLogRecords()) {
				gobjMessageAdapter.ShowMessage(constLogDeletedSuccessfully);
			}
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

	#Region "Private functions"

	//--------------------------------------------------------
	//    General functions used for Log Deletion.
	//--- funcInitialize  - To Initialize the form and show by default date as today.
	//--- funcDeleteLogRecords - To ask user for sure deletion and call a function to delete records from the database.

	private void funcInitialize()
	{
		//=====================================================================
		// Procedure Name        :   funcInitialize
		// Description           :   To Initialize the form and show by default date as today.
		// Purpose               :   To Initialize the form and show by default date as today.
		// Parameters Passed     :   None.
		// Returns               :   None.
		// Parameters Affected   :   None.
		// Assumptions           :
		// Dependencies          :
		// Author                :   Gitesh
		// Created               :   January, 2003 
		// Revisions             :
		//=====================================================================
		CWaitcursor objWait = new CWaitcursor();
		try {
			//--- Passing database name to clsstrConnString property
			mstrConnectionString = mclsDBFunctions.ConnectionString(CONSTSTR_LOGERRORDATABASENAME);

			//--- Passing connection string to Connection Object
			gOleDBConnection_LogBook = new OleDbConnection(mstrConnectionString);

			//--- To Set the CustomFormat string for Date.
			datetimepickFrom.CustomFormat = "dd-MMM-yyyy";
			datetimepickFrom.Format = DateTimePickerFormat.Custom;
			datetimepickTo.CustomFormat = "dd-MMM-yyyy";
			datetimepickTo.Format = DateTimePickerFormat.Custom;

			cmdOK.Click += cmdOK_Click;
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

	private bool funcDeleteLogRecords()
	{
		//=====================================================================
		// Procedure Name        :   funcDeleteLogRecords
		// Description           :   To ask user for sure deletion and call a function to delete records from the database.
		// Purpose               :   To ask user for sure deletion and call a function to delete records from the database.
		// Parameters Passed     :   None.
		// Returns               :   None.
		// Parameters Affected   :   None.
		// Assumptions           :
		// Dependencies          :
		// Author                :   Gitesh
		// Created               :   January, 2003 
		// Revisions             :   Nilesh Shirode June 16 2004
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		System.DateTime fromdate;
		System.DateTime todate;
		string str_GetFileNamesql;
		string str_DeleteFileSql;
		bool delete_result;
		OleDbDataReader objReader;


		DataTable objDataTable = new DataTable();
		DataColumn objColumn;
		DataRow objRow;
		int intRowCount;

		string str_DeleteFilePath;
		string str_DeleteFileRecord;
		string lng_ActivityLogID;

		try {
			funcDeleteLogRecords = false;

			if ((gobjMessageAdapter.ShowMessage(constDeleteLogs) == true)) {
				fromdate = datetimepickFrom.Value;
				todate = datetimepickTo.Value;

				str_GetFileNamesql = "Select FileLog.FilePath,ActivityLog.ActivityLogID " + "From ActivityLog,FileLog " + "Where ActivityLog.ActivityLogID = FileLog.ActivityLogID And ActivityLog.ActivityDateTime between " + "#" + FormatDateTime(fromdate.AddDays(-1), DateFormat.ShortDate) + "#" + " And " + "#" + FormatDateTime(todate.AddDays(1), DateFormat.ShortDate) + "# " + "Order by ActivityDateTime Desc ";

				//--- Add columns to the datatabel
				objColumn = new DataColumn("FilePath");
				objDataTable.Columns.Add(objColumn);
				objColumn = new DataColumn("ActivityLogID");
				objDataTable.Columns.Add(objColumn);

				objReader = mclsDBFunctions.GetRecords(str_GetFileNamesql, gOleDBConnection_LogBook);

				while (objReader.Read) {
					str_DeleteFilePath = objReader.Item("FilePath");
					lng_ActivityLogID = objReader.Item("ActivityLogID");

					if (File.Exists(str_DeleteFilePath) == true) {
						File.Delete(str_DeleteFilePath);
					}

					objRow = objDataTable.NewRow;

					//--- Add the datarows to  the tabel
					objRow.Item("FilePath") = str_DeleteFilePath;
					objRow.Item("ActivityLogID") = lng_ActivityLogID;

					objDataTable.Rows.Add(objRow);

					//objReader.NextResult()
					objRow = null;
				}
				objReader.Close();

				for (intRowCount = 0; intRowCount <= objDataTable.Rows.Count - 1; intRowCount++) {
					lng_ActivityLogID = objDataTable.Rows.Item(intRowCount).Item("ActivityLogID");

					str_DeleteFileSql = "Delete " + "From ActivityLog " + "Where ActivityLog.ActivityLogID = " + lng_ActivityLogID + "";

					if (!mclsDBFunctions.AddORDeleteRecord(str_DeleteFileSql, gOleDBConnection_LogBook)) {
						throw new Exception("Records Not Deleted");
					}

					str_DeleteFileSql = "Delete " + "From FileLog " + "Where FileLog.ActivityLogID = " + lng_ActivityLogID + "";

					if (!mclsDBFunctions.AddORDeleteRecord(str_DeleteFileSql, gOleDBConnection_LogBook)) {
						throw new Exception("Records Not Deleted");
					}
				}
				funcDeleteLogs();
				objDataTable.Dispose();
				funcDeleteLogRecords = true;
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
	private bool funcDeleteLogs()
	{
		//=====================================================================
		// Procedure Name        :   funcDeleteLogRecords
		// Description           :   To ask user for sure deletion and call a function to delete records from the database.
		// Purpose               :   To ask user for sure deletion and call a function to delete records from the database.
		// Parameters Passed     :   None.
		// Returns               :   success flag.
		// Parameters Affected   :   None.
		// Assumptions           :
		// Dependencies          :
		// Author                :  Pankaj Bamb
		// Created               :  23 May , 2007 
		// Revisions             :  
		//=====================================================================

		System.DateTime fromdate;
		System.DateTime todate;
		string str_DeleteFileSql;
		bool delete_result;

		try {
			funcDeleteLogs = false;

			fromdate = datetimepickFrom.Value;
			todate = datetimepickTo.Value;

			str_DeleteFileSql = "Delete * " + "From ActivityLog " + "Where ActivityLog.ActivityDateTime between " + "#" + FormatDateTime(((System.DateTime)fromdate.ToShortDateString()).AddMilliseconds(1), DateFormat.GeneralDate) + "#" + " And " + "#" + FormatDateTime(((System.DateTime)todate.ToShortDateString()).AddDays(1).AddMilliseconds(-1), DateFormat.GeneralDate) + "# " + " ";
			if (!mclsDBFunctions.AddORDeleteRecord(str_DeleteFileSql, gOleDBConnection_LogBook)) {
				throw new Exception("Records Not Deleted");
			}

			funcDeleteLogs = true;

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
			//---------------------------------------------------------
		}

	}

	#End Region

}
