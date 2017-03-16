using AAS203.Common;
using System.Data;
using System.Data.OleDb;
using System.IO;

public class frmActivityLog : System.Windows.Forms.Form
{

	#Region "Module level Declarations "
	private TreeNode mobjTreeNode = new TreeNode();
	private System.DateTime mdtActivityMaxDt;
	private System.DateTime mdtActivityStartDt;
	private System.DateTime mdtActivityEndDt;

	private bool mblnProcessing = false;
	private enum ENUM_RecordsReqd
	{
		InitialValues = 1,
		PreviousValues = 2,
		NextValues = 3
	}

	//--- Enum for the toolbar indexes 
	private enum EnumToolBarButtons
	{
		PreviousDate = 0,
		NextDate = 1,
		FileRetrieve = 3,
		AppClose = 5
	}

	//--- Enum for the image indices
	private enum EnumImageIndex
	{
		EnablePreviousDate = 0,
		EnableNextDate = 1,
		EnableFileRetrieve = 2,
		EnableClose = 3,
		DisableFileRetrieve = 5
	}

	#End Region

	#Region " Windows Form Designer generated code "

	public frmActivityLog()
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
	internal System.Windows.Forms.ImageList imglstActivitylog;
	internal System.Windows.Forms.ToolBar tlbrActivitylog;
	internal System.Windows.Forms.Label lblDateRange;
	internal System.Windows.Forms.ToolBarButton Previous;
	internal System.Windows.Forms.ToolBarButton btn_Next;
	internal System.Windows.Forms.ToolBarButton Separator;
	internal System.Windows.Forms.ToolBarButton FileRetrieve;
	internal System.Windows.Forms.ToolBarButton ToolBarButton1;
	internal System.Windows.Forms.ToolBarButton tlbClose;
	internal System.Windows.Forms.ImageList ImageList_TreeView;
	internal System.Windows.Forms.StatusBar StbrStatus;
	internal System.Windows.Forms.StatusBarPanel StatusBarPanel1;
	internal System.Windows.Forms.TreeView trvLogData;
	internal System.Windows.Forms.Splitter SplitterTreeView;
	internal System.Windows.Forms.Panel Panel1;
	internal System.Windows.Forms.ListView lstViewDetails;
	[System.Diagnostics.DebuggerStepThrough()]
	private void InitializeComponent()
	{
		this.components = new System.ComponentModel.Container();
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmActivityLog));
		this.tlbrActivitylog = new System.Windows.Forms.ToolBar();
		this.Previous = new System.Windows.Forms.ToolBarButton();
		this.btn_Next = new System.Windows.Forms.ToolBarButton();
		this.Separator = new System.Windows.Forms.ToolBarButton();
		this.FileRetrieve = new System.Windows.Forms.ToolBarButton();
		this.ToolBarButton1 = new System.Windows.Forms.ToolBarButton();
		this.tlbClose = new System.Windows.Forms.ToolBarButton();
		this.imglstActivitylog = new System.Windows.Forms.ImageList(this.components);
		this.lblDateRange = new System.Windows.Forms.Label();
		this.ImageList_TreeView = new System.Windows.Forms.ImageList(this.components);
		this.StbrStatus = new System.Windows.Forms.StatusBar();
		this.StatusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
		this.trvLogData = new System.Windows.Forms.TreeView();
		this.SplitterTreeView = new System.Windows.Forms.Splitter();
		this.Panel1 = new System.Windows.Forms.Panel();
		this.lstViewDetails = new System.Windows.Forms.ListView();
		((System.ComponentModel.ISupportInitialize)this.StatusBarPanel1).BeginInit();
		this.Panel1.SuspendLayout();
		this.SuspendLayout();
		//
		//tlbrActivitylog
		//
		this.tlbrActivitylog.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
		this.tlbrActivitylog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.tlbrActivitylog.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
			this.Previous,
			this.btn_Next,
			this.Separator,
			this.FileRetrieve,
			this.ToolBarButton1,
			this.tlbClose
		});
		this.tlbrActivitylog.DropDownArrows = true;
		this.tlbrActivitylog.ImageList = this.imglstActivitylog;
		this.tlbrActivitylog.Location = new System.Drawing.Point(0, 0);
		this.tlbrActivitylog.Name = "tlbrActivitylog";
		this.tlbrActivitylog.ShowToolTips = true;
		this.tlbrActivitylog.Size = new System.Drawing.Size(672, 38);
		this.tlbrActivitylog.TabIndex = 16;
		//
		//Previous
		//
		this.Previous.ImageIndex = 0;
		this.Previous.Tag = "Previous";
		this.Previous.ToolTipText = "Previous Log";
		//
		//btn_Next
		//
		this.btn_Next.ImageIndex = 1;
		this.btn_Next.Tag = "Next";
		this.btn_Next.ToolTipText = "Next Log";
		//
		//Separator
		//
		this.Separator.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
		this.Separator.Tag = "";
		this.Separator.Text = "FileRetrieve";
		//
		//FileRetrieve
		//
		this.FileRetrieve.Tag = "FileRetrieve";
		this.FileRetrieve.ToolTipText = "File Retrieve";
		//
		//ToolBarButton1
		//
		this.ToolBarButton1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
		//
		//tlbClose
		//
		this.tlbClose.ImageIndex = 3;
		this.tlbClose.Tag = "Close";
		this.tlbClose.ToolTipText = "Close";
		//
		//imglstActivitylog
		//
		this.imglstActivitylog.ImageSize = new System.Drawing.Size(25, 25);
		this.imglstActivitylog.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("imglstActivitylog.ImageStream");
		this.imglstActivitylog.TransparentColor = System.Drawing.Color.Transparent;
		//
		//lblDateRange
		//
		this.lblDateRange.Anchor = (System.Windows.Forms.AnchorStyles)System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.lblDateRange.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblDateRange.Location = new System.Drawing.Point(337, 6);
		this.lblDateRange.Name = "lblDateRange";
		this.lblDateRange.Size = new System.Drawing.Size(328, 28);
		this.lblDateRange.TabIndex = 21;
		this.lblDateRange.TextAlign = System.Drawing.ContentAlignment.BottomRight;
		//
		//ImageList_TreeView
		//
		this.ImageList_TreeView.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
		this.ImageList_TreeView.ImageSize = new System.Drawing.Size(16, 16);
		this.ImageList_TreeView.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("ImageList_TreeView.ImageStream");
		this.ImageList_TreeView.TransparentColor = System.Drawing.Color.Transparent;
		//
		//StbrStatus
		//
		this.StbrStatus.Cursor = System.Windows.Forms.Cursors.Help;
		this.StbrStatus.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.StbrStatus.Location = new System.Drawing.Point(0, 437);
		this.StbrStatus.Name = "StbrStatus";
		this.StbrStatus.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] { this.StatusBarPanel1 });
		this.StbrStatus.ShowPanels = true;
		this.StbrStatus.Size = new System.Drawing.Size(672, 24);
		this.StbrStatus.SizingGrip = false;
		this.StbrStatus.TabIndex = 25;
		this.StbrStatus.Text = "StatusBar1";
		//
		//StatusBarPanel1
		//
		this.StatusBarPanel1.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
		this.StatusBarPanel1.Text = "Shows extra information";
		this.StatusBarPanel1.Width = 672;
		//
		//trvLogData
		//
		this.trvLogData.BackColor = System.Drawing.Color.AliceBlue;
		this.trvLogData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.trvLogData.Dock = System.Windows.Forms.DockStyle.Left;
		this.trvLogData.ImageList = this.ImageList_TreeView;
		this.trvLogData.Location = new System.Drawing.Point(0, 38);
		this.trvLogData.Name = "trvLogData";
		this.trvLogData.Size = new System.Drawing.Size(216, 399);
		this.trvLogData.TabIndex = 27;
		//
		//SplitterTreeView
		//
		this.SplitterTreeView.BackColor = System.Drawing.Color.Gray;
		this.SplitterTreeView.Location = new System.Drawing.Point(216, 38);
		this.SplitterTreeView.Name = "SplitterTreeView";
		this.SplitterTreeView.Size = new System.Drawing.Size(2, 399);
		this.SplitterTreeView.TabIndex = 28;
		this.SplitterTreeView.TabStop = false;
		//
		//Panel1
		//
		this.Panel1.Controls.Add(this.lstViewDetails);
		this.Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.Panel1.Location = new System.Drawing.Point(218, 38);
		this.Panel1.Name = "Panel1";
		this.Panel1.Size = new System.Drawing.Size(454, 399);
		this.Panel1.TabIndex = 29;
		//
		//lstViewDetails
		//
		this.lstViewDetails.Activation = System.Windows.Forms.ItemActivation.OneClick;
		this.lstViewDetails.Anchor = (System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right;
		this.lstViewDetails.BackColor = System.Drawing.Color.AliceBlue;
		this.lstViewDetails.BorderStyle = System.Windows.Forms.BorderStyle.None;
		this.lstViewDetails.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lstViewDetails.ForeColor = System.Drawing.Color.Black;
		this.lstViewDetails.Location = new System.Drawing.Point(0, 0);
		this.lstViewDetails.Name = "lstViewDetails";
		this.lstViewDetails.Size = new System.Drawing.Size(452, 399);
		this.lstViewDetails.SmallImageList = this.ImageList_TreeView;
		this.lstViewDetails.TabIndex = 1;
		this.lstViewDetails.View = System.Windows.Forms.View.List;
		//
		//frmActivityLog
		//
		this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
		this.BackColor = System.Drawing.Color.AliceBlue;
		this.ClientSize = new System.Drawing.Size(672, 461);
		this.Controls.Add(this.Panel1);
		this.Controls.Add(this.SplitterTreeView);
		this.Controls.Add(this.trvLogData);
		this.Controls.Add(this.StbrStatus);
		this.Controls.Add(this.lblDateRange);
		this.Controls.Add(this.tlbrActivitylog);
		this.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.Name = "frmActivityLog";
		this.ShowInTaskbar = false;
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Activity log - History of all the acitivities";
		((System.ComponentModel.ISupportInitialize)this.StatusBarPanel1).EndInit();
		this.Panel1.ResumeLayout(false);
		this.ResumeLayout(false);

	}

	#End Region

	#Region " Form Events"

	private void  // ERROR: Handles clauses are not supported in C#
frmActivityLog_Load(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : frmAddUser_Load
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To load the Activity Log form.
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
trvLogData_AfterSelect(System.Object sender, System.Windows.Forms.TreeViewEventArgs e)
	{
		//=====================================================================
		// Procedure Name        : trvLogData_AfterSelect
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To view the log of particular selected date.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : Dec, 2006
		// Revisions             : 
		//=====================================================================
		string tag_data;
		string[] tag_type;
		CWaitCursor objWait = new CWaitCursor();
		try {
			if (mblnProcessing == true) {
				return;
			}
			mblnProcessing = true;

			//btnRetrive.Visible = False
			//tlbrActivitylog.Buttons.Item(3).Enabled = False
			tlbrActivitylog.Buttons.Item(EnumToolBarButtons.FileRetrieve).ImageIndex = EnumImageIndex.DisableFileRetrieve;

			if ((e.Action.ByKeyboard | e.Action.ByMouse)) {
				tag_data = e.Node.Tag;
				tag_type = tag_data.Split("|");

				if ((tag_type(0) == "DT")) {
					DateTime l_date;
					l_date = Convert.ToDateTime(tag_type(1));
					funcShowLogsForDate(l_date);
				} else if ((tag_type(0) == "MD")) {
					long l_log_id;
					l_log_id = Convert.ToInt64(tag_type(1));
					funcGetLogDetailsForModule(l_log_id);
				}
			}

		//----------------------------
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
			objWait.dispose();
			//---------------------------------------------------------
			mblnProcessing = false;
		}
	}

	private void btnPrevious_Click(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : btnPrevious_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To view the previous selected log details.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : Dec, 2006
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		try {
			funcGetActivityDateRange(ENUM_RecordsReqd.PreviousValues);
			lstViewDetails.Clear();
			trvLogData.Nodes.Clear();
			funcGetLogRecords();
			trvLogData.Nodes.Add(mobjTreeNode);

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
	//    General functions used for Activity Log.
	//--- funcInitialize - To Initialize the form and show all the activities from database.
	//--- funcGetLogRecords - To Get the Current Users from the database and display them.
	//--- funcGetModuleDetails - To Add Module Names to the Date Node.
	//--- funcGetLogDetailsForModule - To Show Activity Logs for the Module Clicked.
	//--- funcShowLogsForModule - To Show Logs Details for the Module Clicked.

	private void funcInitialize()
	{
		//=====================================================================
		// Procedure Name        :   funcInitialize
		// Description           :   To Initialize the form and show all the activities from database.
		// Purpose               :   To Initialize the form and show all the activities from database.
		// Parameters Passed     :   None.
		// Returns               :   None.
		// Parameters Affected   :   None.
		// Assumptions           :
		// Dependencies          :
		// Author                :   Saurabh S.
		// Created               :   05-01-2007 
		// Revisions             :
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();

		try {
			if (funcGetMaxActivityDate()) {
				funcGetActivityDateRange(ENUM_RecordsReqd.InitialValues);
			} else {
				return;
			}

			if (!funcGetLogRecords()) {
				throw new Exception("Error in Initialization.");
			}

			trvLogData.Nodes.Add(mobjTreeNode);

			tlbrActivitylog.Buttons.Item(EnumToolBarButtons.FileRetrieve).ImageIndex = EnumImageIndex.DisableFileRetrieve;

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error logging
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

	private bool funcGetLogRecords()
	{
		//=====================================================================
		// Procedure Name        :   funcGetLogRecords
		// Description           :   To Get the Current Users from the database and display them.
		// Purpose               :   To Get the Current Users from the database and display them.
		// Parameters Passed     :   None.
		// Returns               :   None.
		// Parameters Affected   :   None.
		// Assumptions           :
		// Dependencies          :
		// Author                :   Saurabh S.
		// Created               :   05-01-2007 
		// Revisions             :   
		//=====================================================================
		bool result;
		string str_sql;
		string str_sql1;
		OleDbConnection objOledbConnection;
		OleDbDataReader objReader;
		TreeNode objNode;
		CWaitCursor objWait = new CWaitCursor();

		mobjTreeNode.Nodes.Clear();
		mobjTreeNode.Text = "Activity Log";
		mobjTreeNode.Tag = "RT|";

		try {
			objOledbConnection = gOleDBConnection_LogBook;

			//--- Generating dynamic query for selection type
			str_sql = "Select ActivityLog.ActivityDateTime " + "From ActivityLog " + "Where ActivityLog.ActivityDateTime between " + "#" + FormatDateTime(mdtActivityStartDt.AddDays(-1), DateFormat.ShortDate) + "#" + " And " + "#" + FormatDateTime(mdtActivityEndDt.AddDays(1), DateFormat.ShortDate) + "# " + "Order by ActivityDateTime Desc ";


			result = gclsDBFunctions.OpenConnection(objOledbConnection);
			if (!(result)) {
				return false;
			}

			//--- Calling gfuncGetRecords to Get myreader populated with provided Query( strsqlServiceComments (Global String) Records
			gclsDBFunctions.GetRecords(str_sql, objOledbConnection, objReader);

			while (objReader.Read) {
				System.DateTime l_date;
				objNode = new TreeNode();
				if (!FormatDateTime(l_date, DateFormat.ShortDate) == FormatDateTime(objReader.Item("ActivityDateTime"), DateFormat.ShortDate)) {
					l_date = objReader.Item("ActivityDateTime");

					objNode.Tag = "DT|" + l_date.ToString();
					objNode.Text = l_date.ToString("MMM dd yyyy");

					objNode = funcGetModuleDetails(l_date, objNode);

					mobjTreeNode.Nodes.Add(objNode);
				}
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
			return false;
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

	private TreeNode funcGetModuleDetails(System.DateTime logdate, TreeNode objNode)
	{
		//=====================================================================
		// Procedure Name        :   funcGetModuleDetails
		// Description           :   To Add Module Names to the Date Node.
		// Purpose               :   To Add Module Names to the Date Node.
		// Parameters Passed     :   None.
		// Returns               :   None.
		// Parameters Affected   :   None.
		// Assumptions           :
		// Dependencies          :
		// Author                :   Saurabh S.
		// Created               :   05-01-2007
		// Revisions             :
		//=====================================================================
		bool result;
		string str_sql;
		string module_name;
		OleDbConnection objOledbConnection;
		OleDbDataReader objReaderModule;
		TreeNode objTrn;
		string str_connection;
		CWaitCursor objWait = new CWaitCursor();

		try {
			//--- Passing database name to clsstrConnString property
			str_connection = gclsDBFunctions.ConnectionString(CONSTSTR_LOGERRORDATABASENAME);
			objOledbConnection = new OleDbConnection(str_connection);

			str_sql = "Select ActivityLog.ActivityLogID ,ActivityLog.ModuleID ,Modules.ModuleName " + "from ActivityLog ,Modules " + "where ActivityLog.ActivityDateTime = CDate('" + logdate + "') " + "and ActivityLog.ModuleID = Modules.ModuleID ";

			result = gclsDBFunctions.OpenConnection(objOledbConnection);
			if (!(result)) {
				return objNode;
			}

			//--- Calling gfuncGetRecords to Get myreader populated with provided Query( strsqlServiceComments (Global String) Records
			gclsDBFunctions.GetRecords(str_sql, objOledbConnection, objReaderModule);

			while (objReaderModule.Read) {
				objTrn = new TreeNode();
				objTrn.Tag = "MD|" + objReaderModule.Item("ActivityLogID");
				objTrn.ImageIndex = 2;
				module_name = objReaderModule.Item("ModuleName");
				objTrn.Text = module_name;
				objNode.Nodes.Add(objTrn);
			}

			objReaderModule.Close();
			return objNode;

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			//---------------------------------------------------------
			return null;
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

	private bool funcGetLogDetailsForModule(long logId)
	{
		//=====================================================================
		// Procedure Name        :   funcGetLogDetailsForModule
		// Description           :   To Show Activity Logs for the Module Clicked.
		// Purpose               :   To Show Activity Logs for the Module Clicked.
		// Parameters Passed     :   None.
		// Returns               :   None.
		// Parameters Affected   :   None.
		// Assumptions           :
		// Dependencies          :
		// Author                :   Saurabh S.
		// Created               :   05-01-2007 
		// Revisions             :
		//=====================================================================
		bool result;
		string str_sql;
		long module_id;
		System.DateTime log_date;
		OleDb.OleDbDataReader objReader;
		CWaitCursor objWait = new CWaitCursor();

		//--- TO Collect Date and Module ID for the Log Selected.
		try {
			str_sql = "Select ActivityLog.ActivityDateTime ,ActivityLog.ModuleID " + "from ActivityLog where ActivityLog.ActivityLogID = " + logId + "";

			result = gclsDBFunctions.OpenConnection(gOleDBConnection_LogBook);
			if (!(result)) {
				return false;
			}

			//--- Calling gfuncGetRecords to Get myreader populated with provided Query( strsqlServiceComments (Global String) Records
			gclsDBFunctions.GetRecords(str_sql, gOleDBConnection_LogBook, objReader);

			while (objReader.Read) {
				log_date = Convert.ToDateTime(objReader.Item("ActivityDateTime"));
				module_id = Convert.ToInt64(objReader.Item("ModuleID"));
			}

			objReader.Close();

			result = funcShowLogsForModule(log_date, module_id);
			if (!(result)) {
				return false;
			}

			return true;

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
			if (!objWait == null) {
				objWait.Dispose();
			}
			//---------------------------------------------------------
		}

	}

	private bool funcShowLogsForModule(System.DateTime log_date, long module_id)
	{
		//=====================================================================
		// Procedure Name        :   funcShowLogsForModule
		// Description           :   To Show Logs Details for the Module Clicked.
		// Purpose               :   To Show Logs Details for the Module Clicked.
		// Parameters Passed     :   None.
		// Returns               :   None.
		// Parameters Affected   :   None.
		// Assumptions           :
		// Dependencies          :
		// Author                :   Saurabh S.
		// Created               :   05-01-2007 
		// Revisions             :
		//=====================================================================
		bool result;
		string str_sql;
		string strFile;
		OleDb.OleDbDataReader objReader;
		CWaitCursor objWait = new CWaitCursor();

		//--- TO Collect Activity Log Data.
		try {
			str_sql = "Select ActivityLog.ActivityLogID ,ActivityLog.ActivityDateTime ,ActivityLog.SessionID ,ActivityLog.UserID ,ActivityLog.ProcessName " + "from ActivityLog where ActivityLog.ActivityDateTime = CDate('" + log_date + "') and ActivityLog.ModuleID = " + module_id + " ";

			result = gclsDBFunctions.OpenConnection(gOleDBConnection_LogBook);
			if (!(result)) {
				return false;
			}

			//--- Calling gfuncGetRecords to Get myreader populated with provided Query( strsqlServiceComments (Global String) Records
			gclsDBFunctions.GetRecords(str_sql, gOleDBConnection_LogBook, objReader);

			//--- Initialising ListViewHeading Control
			lstViewDetails.View = View.Details;
			lstViewDetails.LabelEdit = false;
			lstViewDetails.FullRowSelect = true;
			lstViewDetails.Activation = ItemActivation.OneClick;
			lstViewDetails.Sorting = SortOrder.Ascending;
			lstViewDetails.MultiSelect = false;
			lstViewDetails.Clear();

			//Creating ListViewItem and passing value Selected  to Constructor 
			ListViewItem itemParent;

			//Adding columns Header To Control 
			lstViewDetails.Columns.Add("File", 30, HorizontalAlignment.Left);
			lstViewDetails.Columns.Add("ActivitLog ID", 0, HorizontalAlignment.Left);
			lstViewDetails.Columns.Add("User Name", 100, HorizontalAlignment.Left);
			lstViewDetails.Columns.Add("Date/Time", 150, HorizontalAlignment.Left);
			lstViewDetails.Columns.Add("Action", 100, HorizontalAlignment.Left);
			lstViewDetails.Columns.Add("Password Tried", 100, HorizontalAlignment.Left);


			while (objReader.Read) {
				string dt_date;
				string dtOnly_date;
				DateTime dtOnly_Time;
				long user_id;
				long activitylog_id;
				string user_name;
				string str_filelog;
				activitylog_id = Convert.ToInt64(objReader.Item("ActivityLogID"));
				dtOnly_date = Format(objReader.Item("ActivityDateTime"), "dd MMM yyyy");
				dtOnly_Time = FormatDateTime(Convert.ToDateTime(objReader.Item("ActivityDateTime")), DateFormat.ShortTime);
				dt_date = dtOnly_date + " " + dtOnly_Time;

				user_id = Convert.ToInt64(objReader.Item("UserID"));
				user_name = funcGetUserName(user_id);

				if ((funcCheckFileLogExist(activitylog_id, strFile))) {
					str_filelog = "YES";
				} else {
					str_filelog = "";
				}

				if (str_filelog == "yes") {
					itemParent = new ListViewItem(str_filelog, 1);
				} else {
					itemParent = new ListViewItem(str_filelog);
				}

				//Adding Subitems to ItemParent Object
				itemParent.SubItems.Add((string)objReader.Item("ActivityLogID"));
				itemParent.SubItems.Add(user_name);
				itemParent.SubItems.Add(dt_date);
				itemParent.SubItems.Add((string)objReader.Item("ProcessName"));

				//Adding ListviewItem(ItemParent)to ListViewDetails Control
				lstViewDetails.Items.Add(itemParent);

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
			return false;
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

	private bool funcShowLogsForDate(System.DateTime log_date)
	{
		//=====================================================================
		// Procedure Name        :   funcShowLogsForDate
		// Description           :   To Show Logs Details for all Modules on the selected Date.
		// Purpose               :   To Show Logs Details for all Modules on the selected Date.
		// Parameters Passed     :   None.
		// Returns               :   None.
		// Parameters Affected   :   None.
		// Assumptions           :
		// Dependencies          :
		// Author                :   Saurabh S.
		// Created               :   05-01-2007 
		// Revisions             :   
		//=====================================================================
		bool result;
		string str_sql;
		string strFile;
		OleDb.OleDbDataReader objReader;
		string dtDate;
		CWaitCursor objWait = new CWaitCursor();

		dtDate = FormatDateTime(log_date, DateFormat.ShortDate);
		//--- TO Collect Activity Log Data.

		try {
			str_sql = "select ActivityLog.ActivityLogID, ActivityLog.ActivityDateTime, ActivityLog.SessionID, ActivityLog.ModuleID, ActivityLog.UserID, ActivityLog.ProcessName, Modules.ModuleName, ActivityLog.PasswordTried " + "from ActivityLog INNER JOIN Modules ON ActivityLog.ModuleID = Modules.ModuleID " + "WHERE ActivityLog.ActivityDateTime  like  '" + dtDate + "%' and ActivityLog.ModuleID = Modules.ModuleID ";

			//--- Calling function to get Records. 
			gclsDBFunctions.GetRecords(str_sql, gOleDBConnection_LogBook, objReader);

			//--- Initialising ListViewHeading Control
			lstViewDetails.View = View.Details;
			lstViewDetails.LabelEdit = false;
			lstViewDetails.FullRowSelect = true;
			lstViewDetails.Activation = ItemActivation.OneClick;
			lstViewDetails.Sorting = SortOrder.Ascending;
			lstViewDetails.MultiSelect = false;
			lstViewDetails.Clear();

			//Creating ListViewItem and passing value Selected  to Constructor 
			ListViewItem itemParent;

			//Adding columns Header To Control 
			lstViewDetails.Columns.Add("File", 50, HorizontalAlignment.Left);
			lstViewDetails.Columns.Add("ActivityLog ID", 0, HorizontalAlignment.Left);
			lstViewDetails.Columns.Add("User Name", 100, HorizontalAlignment.Left);
			lstViewDetails.Columns.Add("Date/Time", 150, HorizontalAlignment.Left);
			lstViewDetails.Columns.Add("Action", 100, HorizontalAlignment.Left);
			lstViewDetails.Columns.Add("Mode Name", 100, HorizontalAlignment.Left);
			lstViewDetails.Columns.Add("Password Tried", 100, HorizontalAlignment.Left);


			while (objReader.Read) {
				string dt_date;
				string dtOnly_date;
				DateTime dtOnly_Time;
				long user_id;
				long activitylog_id;
				string user_name;
				string str_filelog;
				string password_tried;

				gobjCommProtocol.mobjCommdll.subTime_Delay(1);

				activitylog_id = Convert.ToInt64(objReader.Item("ActivitylogID"));

				dtOnly_date = Format(objReader.Item("ActivityDateTime"), "MMM dd yyyy");
				dtOnly_Time = FormatDateTime(Convert.ToDateTime(objReader.Item("ActivityDateTime")), DateFormat.ShortTime);
				dt_date = dtOnly_date + " " + dtOnly_Time;

				user_id = Convert.ToInt64(objReader.Item("UserID"));
				user_name = funcGetUserName(user_id);


				if ((funcCheckFileLogExist(activitylog_id, strFile))) {
					str_filelog = "YES";
				} else {
					str_filelog = "";
				}

				if (str_filelog == "YES") {
					str_filelog = "";
					itemParent = new ListViewItem(str_filelog, 0);
				} else {
					itemParent = new ListViewItem(str_filelog);
				}


				//Adding Subitems to ItemParent Object
				itemParent.SubItems.Add((string)objReader.Item("ActivityLogID"));
				itemParent.SubItems.Add(user_name);
				itemParent.SubItems.Add(dt_date);
				itemParent.SubItems.Add((string)objReader.Item("ProcessName"));
				itemParent.SubItems.Add((string)objReader.Item("ModuleName"));
				if (IsDBNull(objReader.Item("PasswordTried"))) {
				} else {
					itemParent.SubItems.Add((string)objReader.Item("PasswordTried"));
				}

				lstViewDetails.Items.Add(itemParent);
			}

			objReader.Close();

			return true;

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
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

	private string funcGetModuleName(long module_id)
	{
		//=====================================================================
		// Procedure Name        :   funcGetModuleName
		// Description           :   To Get Module Name from Database for the module id given.
		// Purpose               :   To Get Module Name from Database for the module id given.
		// Parameters Passed     :   None.
		// Returns               :   None.
		// Parameters Affected   :   None.
		// Assumptions           :
		// Dependencies          :
		// Author                :   Saurabh S.
		// Created               :   05-01-2007
		// Revisions             :
		//=====================================================================
		bool result;
		string str_sql;
		string module_name;
		OleDbConnection objOledbConnection;
		OleDb.OleDbDataReader objReader;
		CWaitCursor objWait = new CWaitCursor();
		try {
			//objOledbConnection = New OleDbConnection(mstrConnectionString)
			objOledbConnection = gOleDBConnection_LogBook;

			str_sql = "Select ModuleName " + "from Modules where ModuleID = " + module_id + "";

			result = gclsDBFunctions.OpenConnection(objOledbConnection);
			if (!(result)) {
				return module_name;
			}

			//--- Calling gfuncGetRecords to Get myreader populated with provided Query( strsqlServiceComments (Global String) Records
			gclsDBFunctions.GetRecords(str_sql, objOledbConnection, objReader);

			while (objReader.Read) {
				module_name = (string)objReader.Item("ModuleName");
			}

			objReader.Close();
			//objOledbConnection = Nothing

			return module_name;

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			//---------------------------------------------------------
			return "";
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

	private bool funcGetMaxActivityDate()
	{
		//=====================================================================
		// Procedure Name        :   funcGetMaxActivityDate
		// Description           :   To Get the Maximum Activity Log Date.
		// Purpose               :   To Get the Maximum Activity Log Date.
		// Parameters Passed     :   None.
		// Returns               :   None.
		// Parameters Affected   :   None.
		// Assumptions           :
		// Dependencies          :
		// Author                :   Saurabh S.
		// Created               :   05-01-2007
		// Revisions             :
		//=====================================================================
		bool result;
		string str_sql;
		OleDbConnection objOledbConnection;
		OleDbDataReader objReader;
		CWaitCursor objWait = new CWaitCursor();
		try {
			//objOledbConnection = New OleDbConnection(mstrConnectionString)
			objOledbConnection = gOleDBConnection_LogBook;

			//--- Generating dynamic query for selection. 
			str_sql = "Select max(ActivityLog.ActivityDateTime) " + "from ActivityLog ";

			result = gclsDBFunctions.OpenConnection(objOledbConnection);
			if (!(result)) {
				return false;
			}

			gclsDBFunctions.GetRecords(str_sql, objOledbConnection, objReader);

			while (objReader.Read) {
				System.DateTime l_date;
				if (!IsDBNull(objReader.Item(0))) {
					l_date = (System.DateTime)objReader.Item(0);

					mdtActivityMaxDt = l_date;
				} else {
					return false;
				}
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

	private bool funcGetActivityDateRange(int intCondition)
	{
		//=====================================================================
		// Procedure Name        :   funcGetActivityDateRange
		// Description           :   To Get the Date Range of Activity Logs.
		// Purpose               :   To Get the Date Range of Activity Logs.
		// Parameters Passed     :   None.
		// Returns               :   None.
		// Parameters Affected   :   None.
		// Assumptions           :
		// Dependencies          :
		// Author                :   Saurabh S.
		// Created               :   05-01-2007
		// Revisions             : 
		//=====================================================================
		TimeSpan interval = new TimeSpan(7, 0, 0, 0);
		CWaitCursor objWait = new CWaitCursor();
		try {
			switch (intCondition) {
				case ENUM_RecordsReqd.InitialValues:
					mdtActivityEndDt = mdtActivityMaxDt;

					mdtActivityStartDt = mdtActivityMaxDt.Subtract(interval);
				case ENUM_RecordsReqd.PreviousValues:
					mdtActivityEndDt = mdtActivityStartDt;

					mdtActivityStartDt = mdtActivityStartDt.Subtract(interval);
				case ENUM_RecordsReqd.NextValues:
					mdtActivityStartDt = mdtActivityEndDt;
					mdtActivityEndDt = mdtActivityEndDt.Add(interval);

					if ((mdtActivityEndDt >= mdtActivityMaxDt)) {
						mdtActivityEndDt = mdtActivityMaxDt;
						mdtActivityStartDt = mdtActivityMaxDt.Subtract(interval);
					}
			}

			lblDateRange.Text = "Date: " + Format(mdtActivityStartDt, "MMM dd yyyy") + " To " + Format(mdtActivityEndDt, "MMM dd yyyy");

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

	private string funcGetUserName(long user_id)
	{
		//=====================================================================
		// Procedure Name        :   funcGetUserName
		// Description           :   To Get User Name from Database for the user id given.
		// Purpose               :   To Get User Name from Database for the user id given.
		// Parameters Passed     :   None.
		// Returns               :   None.
		// Parameters Affected   :   None.
		// Assumptions           :
		// Dependencies          :
		// Author                :   Saurabh S.
		// Created               :   05-01-2007
		// Revisions             :
		//=====================================================================
		bool result;
		string str_sql;
		string user_name;
		OleDbDataReader objReader;
		CWaitCursor objWait = new CWaitCursor();


		try {
			str_sql = "Select UserName " + "from Users where UserID = " + user_id + "";

			//--- Calling gfuncGetRecords to Get myreader populated with provided Query( strsqlServiceComments (Global String) Records
			gclsDBFunctions.GetRecords(str_sql, gOleDBUserInfoConnection, objReader);

			while (objReader.Read) {
				user_name = (string)objReader.Item("UserName");
			}

			objReader.Close();

			return user_name;
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			//---------------------------------------------------------
			return "";
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

	private bool funcCheckFileLogExist(long activitylog_id, ref string strInFileName)
	{
		//=====================================================================
		// Procedure Name        :   funcCheckFileLogExist
		// Description           :   To check whether File Log Record exists.
		// Purpose               :   To check whether File Log Record exists.
		// Parameters Passed     :   None.
		// Returns               :   None.
		// Parameters Affected   :   None.
		// Assumptions           :
		// Dependencies          :
		// Author                :   Saurabh S.
		// Created               :   05-01-2007
		// Revisions             :
		//=====================================================================
		OleDbDataReader objReader;
		string str_sql;
		long intNoOfRecords;
		bool record_exists;
		string str_connection;
		OleDbConnection objOledbFileConnection;
		CWaitCursor objWait = new CWaitCursor();

		try {
			//--- Passing database name to clsstrConnString property
			str_connection = gclsDBFunctions.ConnectionString(CONSTSTR_LOGERRORDATABASENAME);
			objOledbFileConnection = new OleDbConnection(str_connection);

			if ((gclsDBFunctions.OpenConnection(objOledbFileConnection) == false)) {
				return false;
			}

			str_sql = "select * from FileLog where FileLog.ActivityLogID =" + activitylog_id + "";

			record_exists = gclsDBFunctions.GetRecords(str_sql, objOledbFileConnection, objReader);

			if (objReader.HasRows == false) {
				strInFileName = "";
				objReader.Close();
				return false;
			} else {
				while (objReader.Read) {
					strInFileName = objReader.Item("FileName");
				}

				objReader.Close();

			}

			return true;

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
			if (!objWait == null) {
				objWait.Dispose();
			}
			//---------------------------------------------------------

		}

	}

	private string funcGetFileLogFilePath(activitylog_id)
	{
		//=====================================================================
		// Procedure Name        :   funcGetFileLogFilePath
		// Description           :   To get saved File Path.
		// Purpose               :   To get saved File Path.
		// Parameters Passed     :   None.
		// Returns               :   None.
		// Parameters Affected   :   None.
		// Assumptions           :
		// Dependencies          :
		// Author                :   Saurabh S.
		// Created               :   05-01-2007
		// Revisions             :
		//=====================================================================
		OleDbDataReader objReader;
		string str_sql;
		string strFilePath;
		bool record_exists;
		string str_connection;
		OleDbConnection objOledbConnection;
		CWaitCursor objWait = new CWaitCursor();

		try {
			//--- Passing database name to clsstrConnString property
			str_connection = gclsDBFunctions.ConnectionString(CONSTSTR_LOGERRORDATABASENAME);
			objOledbConnection = new OleDbConnection(str_connection);

			if ((gclsDBFunctions.OpenConnection(objOledbConnection) == false)) {
				return false;
			}

			str_sql = "select FilePath from FileLog where FileLog.ActivityLogID =" + activitylog_id + "";

			gclsDBFunctions.GetRecords(str_sql, objOledbConnection, objReader);

			while (objReader.Read) {
				strFilePath = (string)objReader.Item("FilePath");
			}

			objReader.Close();

			return strFilePath;

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
			if (!objWait == null) {
				objWait.Dispose();
			}
			//---------------------------------------------------------
		}

	}

	private void  // ERROR: Handles clauses are not supported in C#
lstViewDetails_Click(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : lstViewDetails_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : List view to show the dates on which log was created.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saruabh S. 
		// Created               : Dec, 2006
		// Revisions             : 
		//=====================================================================
		string strFileName_Show;
		ListViewItem objlistItem = new ListViewItem();
		long lngActivityID;
		CWaitCursor objWait = new CWaitCursor();
		try {
			lstViewDetails.MultiSelect = true;
			objlistItem = lstViewDetails.SelectedItems.Item(0);
			lngActivityID = (long)objlistItem.SubItems(1).Text;
			if ((funcCheckFileLogExist(lngActivityID, strFileName_Show))) {
				StatusBarPanel1.Text = strFileName_Show;
				tlbrActivitylog.Buttons.Item(EnumToolBarButtons.FileRetrieve).ImageIndex = EnumImageIndex.EnableFileRetrieve;
			} else {
				StatusBarPanel1.Text = strFileName_Show;
				tlbrActivitylog.Buttons.Item(EnumToolBarButtons.FileRetrieve).ImageIndex = EnumImageIndex.DisableFileRetrieve;
			}
			objlistItem = null;
			lstViewDetails.Refresh();

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
			objWait.Dispose();
			//---------------------------------------------------------
		}

	}

	#End Region

	#Region "Global Functions"

	//--------------------------------------------------------
	//    Global functions used to insert into Activity Log and File Log.
	//--- funcInsertActivityLog - To Add / Insert a record in Activity Log table.
	//--- funcInsertFileLog - To Add / Insert a record in File Log table.

	private bool funcInsertActivityLog(long Session_ID, long User_ID, long Module_ID, string Log_desc)
	{
		//=====================================================================
		// Procedure Name        :   funcInsertActivityLog
		// Description           :   To Add / Insert a record in Activity Log table.
		// Purpose               :   To Add / Insert a record in Activity Log table.
		// Parameters Passed     :   None.
		// Returns               :   None.
		// Parameters Affected   :   None.
		// Assumptions           :
		// Dependencies          :
		// Author                :   Saurabh S.
		// Created               :   05-01-2007
		// Revisions             :
		//=====================================================================
		string str_sql;
		bool Status;
		OleDbCommand objcommand = new OleDbCommand();
		long Log_ID;
		CWaitCursor objWait = new CWaitCursor();
		try {
			Status = gclsDBFunctions.OpenConnection(gOleDBConnection_LogBook);
			if (!(Status)) {
				return false;
			}

			Log_ID = gclsDBFunctions.GetNextID("ActivityLog", "ActivityLogID", gOleDBConnection_LogBook);

			str_sql = "Insert into ActivityLog " + "(ActivityLogID ,SessionID ,ActivityDateTime ,UserID ,ProcessName ,ModuleID)" + " values(?,?,?,?,?,?)";

			//--- Providing command object for Infomaster
			 // ERROR: Not supported in C#: WithStatement


			objcommand.Dispose();
			return true;

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
			if (!objWait == null) {
				objWait.Dispose();
			}
			//---------------------------------------------------------
		}


	}

	private bool funcInsertFileLog(long ActivityLog_ID, string file_name, object file_data)
	{
		//=====================================================================
		// Procedure Name        :   funcInsertFileLog
		// Description           :   To Add / Insert a record in File Log table.
		// Purpose               :   To Add / Insert a record in File Log table.
		// Parameters Passed     :   None.
		// Returns               :   None.
		// Parameters Affected   :   None.
		// Assumptions           :
		// Dependencies          :
		// Author                :   Saurabh S.
		// Created               :   05-01-2007
		// Revisions             :
		//=====================================================================
		string str_sql;
		bool Status;
		OleDbCommand objcommand = new OleDbCommand();
		long FileLog_ID;
		CWaitCursor objWait = new CWaitCursor();
		try {
			Status = gclsDBFunctions.OpenConnection(gOleDBConnection_LogBook);
			if (!(Status)) {
				return false;
			}

			FileLog_ID = gclsDBFunctions.GetNextID("FileLogID", "FileLog", gOleDBConnection_LogBook);

			str_sql = "Insert into FileLog " + "(FileLogID ,ActivityLogID ,FileName ,FilePath )" + " values(?,?,?,?)";

			//--- Providing command object for Infomaster
			 // ERROR: Not supported in C#: WithStatement


			objcommand.Dispose();
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

	#Region " String/Byte Array conversion code "

	private byte[] funcStringToByte(string szString)
	{
		//=====================================================================
		// Procedure Name        : funcStringToByte
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To convert String to Byte.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saruabh S. 
		// Created               : Dec, 2006
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		int i;
		byte[] btRet = new byte[szString.Length - 2];

		try {
			if (szString.Length == 0) {
				return;
			}

			for (i = 0; i <= szString.Length - 1; i++) {
				btRet(i) = Asc(szString.Chars(i));
			}
			return btRet;

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

	private string funcByteToString(byte[] btBytes)
	{
		//=====================================================================
		// Procedure Name        : funcByteToString
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To convert the passed Bytes to String.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saruabh S. 
		// Created               : Dec, 2006
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		string szRet;
		int i;
		try {
			for (i = LBound(btBytes); i <= UBound(btBytes); i++) {
				szRet = szRet + Chr(btBytes(i));
			}
			return szRet;

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

	#Region " Toolbar"

	private void  // ERROR: Handles clauses are not supported in C#
tlbrActivitylog_ButtonClick(System.Object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
	{
		//=====================================================================
		// Procedure Name        : tlbrActivitylog_ButtonClick
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To initialise the buttons on Toolbar.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saruabh S. 
		// Created               : Dec, 2006
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		try {
			if (e.Button.ImageIndex > 4) {
				return;
			}

			switch (UCase(e.Button.Tag)) {

				case UCase("Next"):

					subNextDates();
				case UCase("Previous"):

					subPreviousDates();
				case UCase("FileRetrieve"):

					subFileRetrieve();
				case UCase("Close"):
					this.Close();
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

	private void subFileRetrieve()
	{
		//=====================================================================
		// Procedure Name        : subFileRetrieve
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To retrieve the encrypted file.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saruabh S. 
		// Created               : Dec, 2006
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();

		ListViewItem objlistItem;
		objlistItem = lstViewDetails.SelectedItems.Item(0);
		long lngActivityID = (int)objlistItem.SubItems(1).Text;
		SaveFileDialog objsfd = new SaveFileDialog();
		string strPath = Application.StartupPath;
		string strOrgFilePath = funcGetFileLogFilePath(lngActivityID);
		FileInfo objfileinfo = new FileInfo(strOrgFilePath);
		string strOrgFilename = objfileinfo.Name;
		string strOrgFileext = objfileinfo.Extension;

		try {
			objlistItem = lstViewDetails.FocusedItem;
			if (objfileinfo.Exists == false) {
				gobjMessageAdapter.ShowMessage(constFileNotFound);
				return;
			}

			//--- Show the save dialog to accept the file.
			objsfd.InitialDirectory = strPath;
			objsfd.RestoreDirectory = true;
			objsfd.Filter = "Files(*" + strOrgFileext + ")|*" + strOrgFileext;
			objsfd.FileName = strOrgFilename;

			if (objsfd.ShowDialog() == DialogResult.OK) {
				objfileinfo.CopyTo(objsfd.FileName, true);
				gobjMessageAdapter.ShowMessage(constFileRetrievedSuccessfully);
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
			//---------------------------------------------------------
		}

	}

	private void subNextDates()
	{
		//=====================================================================
		// Procedure Name        : subNextDates
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To show the logs of next dates.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saruabh S. 
		// Created               : Dec, 2006
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		try {
			funcGetActivityDateRange(ENUM_RecordsReqd.NextValues);
			lstViewDetails.Clear();
			trvLogData.Nodes.Clear();
			funcGetLogRecords();
			trvLogData.Nodes.Add(mobjTreeNode);

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

	private void subPreviousDates()
	{
		//=====================================================================
		// Procedure Name        : subPreviousDates
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To Load the data of previous date.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saruabh S. 
		// Created               : Dec, 2006
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		try {
			funcGetActivityDateRange(ENUM_RecordsReqd.PreviousValues);
			lstViewDetails.Clear();
			trvLogData.Nodes.Clear();
			funcGetLogRecords();
			trvLogData.Nodes.Add(mobjTreeNode);

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
