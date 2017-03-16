
using System;
using System.Data;
using System.IO;
using System.Data.OleDb;
using vbAccelerator;
using vbAccelerator.Components.ListBarControl;

///Imports CrystalDecisions.CrystalReports.Engine
///Imports CrystalDecisions.Shared


public class frmMDI : System.Windows.Forms.Form
{

	#Region " Module level Declarations "

	private const  CONST_Use_TreeView = 1;
	private const  CONST_ModeLock = 0;
	private const  CONST_ModeUnLock = 7;
	Application AppObject;
	private const  CONST_RecordID = 1;

	private IO.Directory strPath;

	public PrintDialog objPrintDialog = new PrintDialog();
		//Saurabh 04.07.07
	private frmPQTest2 mfrmPQTest2 = new frmPQTest2();
	public event  Test_IQOQPQ_Attachment1;
	//Saurabh 04.07.07

		//Saurabh 07.07.07
	private frmPQTest3 mfrmPQTest3 = new frmPQTest3();
	public event  Test_IQOQPQ_AttachmentII;
	//Saurabh 07.07.07

		//Saurabh 09.07.07
	private frmPQTest4 mfrmPQTest4 = new frmPQTest4();
	public event  Test_IQOQPQ_AttachmentIII;
	//Saurabh 09.07.07

	public event  InstrumentType;
	//Saurabh 30.07.07

	private enum enumToolBarButtons
	{
		tlbtnLock = 0,
		tlbtnNext = 4,
		tlbtnPrevious = 2,
		tlbrPrint = 6,
		tlbrPrintAll = 7,
		tlbrExport = 8,
		tlbtnExit = 10
	}

	#End Region

	#Region " Windows Form Designer generated code "

	public frmMDI()
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
	internal System.Windows.Forms.MainMenu MainMenu1;
	internal System.Windows.Forms.StatusBar stsdQualification;
	internal System.Windows.Forms.ImageList ImageList1;
	internal System.Windows.Forms.Panel Panel2;
	internal System.Windows.Forms.ToolBar tlbrIQOQPQ;
	internal System.Windows.Forms.ToolBarButton tlbtnLock;
	internal System.Windows.Forms.ToolBarButton ToolBarButton4;
	internal System.Windows.Forms.ToolBarButton tlbtnPrevious;
	internal System.Windows.Forms.ToolBarButton ToolBarButton5;
	internal System.Windows.Forms.ToolBarButton tlbtnNext;
	internal System.Windows.Forms.ToolBarButton ToolBarButton6;
	internal System.Windows.Forms.ToolBarButton tlbtnReturn;
	internal System.Windows.Forms.TreeView tvwIQOQPQ;
	internal vbAccelerator.Components.ListBarControl.ListBar lstbarIQOQPQ;
	internal System.Windows.Forms.Splitter tvwSplitter;
	internal System.Windows.Forms.ToolBarButton tlbrPrint;
	internal System.Windows.Forms.ToolBarButton tlbrPrintAll;
	internal System.Windows.Forms.ToolBarButton ToolBarButton1;
	internal System.Drawing.Printing.PrintDocument PrintDocument1;
	internal System.Windows.Forms.PrintDialog PrintDialog1;
	internal System.Windows.Forms.StatusBarPanel StatusBarPanel1;
	internal System.Windows.Forms.ToolBarButton tlbrExport;
	internal System.Windows.Forms.ImageList ImageList2;
	internal System.Windows.Forms.MenuItem MenuItem5;
	internal System.Windows.Forms.MenuItem MenuItem10;
	internal System.Windows.Forms.MenuItem MenuItem14;
	internal System.Windows.Forms.MenuItem mnuIQMode;
	internal System.Windows.Forms.MenuItem mnuFile;
	internal System.Windows.Forms.MenuItem mnuOQMode;
	internal System.Windows.Forms.MenuItem mnuPQMode;
	internal System.Windows.Forms.MenuItem mnuLock;
	internal System.Windows.Forms.MenuItem mnuNext;
	internal System.Windows.Forms.MenuItem mnuPrevious;
	internal System.Windows.Forms.MenuItem mnuExit;
	internal System.Windows.Forms.MenuItem mnuEdit;
	internal System.Windows.Forms.MenuItem mnuPrint;
	internal System.Windows.Forms.MenuItem mnuPrintAll;
	internal System.Windows.Forms.MenuItem mnuExport;
	internal vbWindowsUI.VSNetMenuProvider VsNetMenuProvider;
	internal System.Windows.Forms.PrintPreviewDialog PrintPreviewDialog1;
	[System.Diagnostics.DebuggerStepThrough()]
	private void InitializeComponent()
	{
		this.components = new System.ComponentModel.Container();
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMDI));
		this.MainMenu1 = new System.Windows.Forms.MainMenu();
		this.mnuFile = new System.Windows.Forms.MenuItem();
		this.mnuIQMode = new System.Windows.Forms.MenuItem();
		this.mnuOQMode = new System.Windows.Forms.MenuItem();
		this.mnuPQMode = new System.Windows.Forms.MenuItem();
		this.MenuItem5 = new System.Windows.Forms.MenuItem();
		this.mnuLock = new System.Windows.Forms.MenuItem();
		this.mnuNext = new System.Windows.Forms.MenuItem();
		this.mnuPrevious = new System.Windows.Forms.MenuItem();
		this.MenuItem10 = new System.Windows.Forms.MenuItem();
		this.mnuExit = new System.Windows.Forms.MenuItem();
		this.mnuEdit = new System.Windows.Forms.MenuItem();
		this.mnuPrint = new System.Windows.Forms.MenuItem();
		this.mnuPrintAll = new System.Windows.Forms.MenuItem();
		this.MenuItem14 = new System.Windows.Forms.MenuItem();
		this.mnuExport = new System.Windows.Forms.MenuItem();
		this.stsdQualification = new System.Windows.Forms.StatusBar();
		this.StatusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
		this.ImageList1 = new System.Windows.Forms.ImageList(this.components);
		this.Panel2 = new System.Windows.Forms.Panel();
		this.tlbrIQOQPQ = new System.Windows.Forms.ToolBar();
		this.tlbtnLock = new System.Windows.Forms.ToolBarButton();
		this.ToolBarButton4 = new System.Windows.Forms.ToolBarButton();
		this.tlbtnPrevious = new System.Windows.Forms.ToolBarButton();
		this.ToolBarButton5 = new System.Windows.Forms.ToolBarButton();
		this.tlbtnNext = new System.Windows.Forms.ToolBarButton();
		this.ToolBarButton6 = new System.Windows.Forms.ToolBarButton();
		this.tlbrPrint = new System.Windows.Forms.ToolBarButton();
		this.tlbrPrintAll = new System.Windows.Forms.ToolBarButton();
		this.tlbrExport = new System.Windows.Forms.ToolBarButton();
		this.ToolBarButton1 = new System.Windows.Forms.ToolBarButton();
		this.tlbtnReturn = new System.Windows.Forms.ToolBarButton();
		this.tvwIQOQPQ = new System.Windows.Forms.TreeView();
		this.ImageList2 = new System.Windows.Forms.ImageList(this.components);
		this.lstbarIQOQPQ = new vbAccelerator.Components.ListBarControl.ListBar();
		this.tvwSplitter = new System.Windows.Forms.Splitter();
		this.PrintDocument1 = new System.Drawing.Printing.PrintDocument();
		this.PrintDialog1 = new System.Windows.Forms.PrintDialog();
		this.VsNetMenuProvider = new vbWindowsUI.VSNetMenuProvider(this.components);
		this.PrintPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
		((System.ComponentModel.ISupportInitialize)this.StatusBarPanel1).BeginInit();
		this.Panel2.SuspendLayout();
		this.SuspendLayout();
		//
		//MainMenu1
		//
		this.MainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
			this.mnuFile,
			this.mnuEdit
		});
		//
		//mnuFile
		//
		this.VsNetMenuProvider.SetImageIndex(this.mnuFile, -1);
		this.mnuFile.Index = 0;
		this.mnuFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
			this.mnuIQMode,
			this.mnuOQMode,
			this.mnuPQMode,
			this.MenuItem5,
			this.mnuLock,
			this.mnuNext,
			this.mnuPrevious,
			this.MenuItem10,
			this.mnuExit
		});
		this.mnuFile.OwnerDraw = true;
		this.mnuFile.Text = "&File";
		//
		//mnuIQMode
		//
		this.VsNetMenuProvider.SetImageIndex(this.mnuIQMode, 20);
		this.mnuIQMode.Index = 0;
		this.mnuIQMode.OwnerDraw = true;
		this.mnuIQMode.RadioCheck = true;
		this.mnuIQMode.Text = "&Installation Qualification";
		//
		//mnuOQMode
		//
		this.VsNetMenuProvider.SetImageIndex(this.mnuOQMode, 21);
		this.mnuOQMode.Index = 1;
		this.mnuOQMode.OwnerDraw = true;
		this.mnuOQMode.RadioCheck = true;
		this.mnuOQMode.Text = "&Operational Qualification";
		//
		//mnuPQMode
		//
		this.VsNetMenuProvider.SetImageIndex(this.mnuPQMode, 22);
		this.mnuPQMode.Index = 2;
		this.mnuPQMode.OwnerDraw = true;
		this.mnuPQMode.RadioCheck = true;
		this.mnuPQMode.Text = "Performance &Qualification";
		//
		//MenuItem5
		//
		this.VsNetMenuProvider.SetImageIndex(this.MenuItem5, -1);
		this.MenuItem5.Index = 3;
		this.MenuItem5.OwnerDraw = true;
		this.MenuItem5.Text = "-";
		//
		//mnuLock
		//
		this.VsNetMenuProvider.SetImageIndex(this.mnuLock, 7);
		this.mnuLock.Index = 4;
		this.mnuLock.OwnerDraw = true;
		this.mnuLock.Shortcut = System.Windows.Forms.Shortcut.CtrlL;
		this.mnuLock.Text = "&Lock";
		//
		//mnuNext
		//
		this.VsNetMenuProvider.SetImageIndex(this.mnuNext, 16);
		this.mnuNext.Index = 5;
		this.mnuNext.OwnerDraw = true;
		this.mnuNext.Shortcut = System.Windows.Forms.Shortcut.CtrlN;
		this.mnuNext.Text = "&Next";
		//
		//mnuPrevious
		//
		this.VsNetMenuProvider.SetImageIndex(this.mnuPrevious, 15);
		this.mnuPrevious.Index = 6;
		this.mnuPrevious.OwnerDraw = true;
		this.mnuPrevious.Shortcut = System.Windows.Forms.Shortcut.CtrlP;
		this.mnuPrevious.Text = "&Previous";
		//
		//MenuItem10
		//
		this.VsNetMenuProvider.SetImageIndex(this.MenuItem10, -1);
		this.MenuItem10.Index = 7;
		this.MenuItem10.OwnerDraw = true;
		this.MenuItem10.Text = "-";
		//
		//mnuExit
		//
		this.VsNetMenuProvider.SetImageIndex(this.mnuExit, 19);
		this.mnuExit.Index = 8;
		this.mnuExit.OwnerDraw = true;
		this.mnuExit.Text = "E&xit";
		//
		//mnuEdit
		//
		this.VsNetMenuProvider.SetImageIndex(this.mnuEdit, 1);
		this.mnuEdit.Index = 1;
		this.mnuEdit.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
			this.mnuPrint,
			this.mnuPrintAll,
			this.MenuItem14,
			this.mnuExport
		});
		this.mnuEdit.OwnerDraw = true;
		this.mnuEdit.Text = "&Edit";
		//
		//mnuPrint
		//
		this.VsNetMenuProvider.SetImageIndex(this.mnuPrint, -1);
		this.mnuPrint.Index = 0;
		this.mnuPrint.OwnerDraw = true;
		this.mnuPrint.Text = "&Print";
		this.mnuPrint.Visible = false;
		//
		//mnuPrintAll
		//
		this.VsNetMenuProvider.SetImageIndex(this.mnuPrintAll, 13);
		this.mnuPrintAll.Index = 1;
		this.mnuPrintAll.OwnerDraw = true;
		this.mnuPrintAll.Shortcut = System.Windows.Forms.Shortcut.CtrlA;
		this.mnuPrintAll.Text = "Print&All";
		//
		//MenuItem14
		//
		this.VsNetMenuProvider.SetImageIndex(this.MenuItem14, -1);
		this.MenuItem14.Index = 2;
		this.MenuItem14.OwnerDraw = true;
		this.MenuItem14.Text = "-";
		//
		//mnuExport
		//
		this.VsNetMenuProvider.SetImageIndex(this.mnuExport, 18);
		this.mnuExport.Index = 3;
		this.mnuExport.OwnerDraw = true;
		this.mnuExport.Shortcut = System.Windows.Forms.Shortcut.CtrlE;
		this.mnuExport.Text = "&Export";
		//
		//stsdQualification
		//
		this.stsdQualification.Location = new System.Drawing.Point(0, 501);
		this.stsdQualification.Name = "stsdQualification";
		this.stsdQualification.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] { this.StatusBarPanel1 });
		this.stsdQualification.ShowPanels = true;
		this.stsdQualification.Size = new System.Drawing.Size(804, 24);
		this.stsdQualification.TabIndex = 8;
		this.stsdQualification.Text = "StatusBar1";
		//
		//StatusBarPanel1
		//
		this.StatusBarPanel1.Icon = (System.Drawing.Icon)resources.GetObject("StatusBarPanel1.Icon");
		this.StatusBarPanel1.Text = "Displays Extra Information";
		this.StatusBarPanel1.Width = 800;
		//
		//ImageList1
		//
		this.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
		this.ImageList1.ImageSize = new System.Drawing.Size(25, 25);
		this.ImageList1.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("ImageList1.ImageStream");
		this.ImageList1.TransparentColor = System.Drawing.Color.Transparent;
		//
		//Panel2
		//
		this.Panel2.Controls.Add(this.tlbrIQOQPQ);
		this.Panel2.Dock = System.Windows.Forms.DockStyle.Top;
		this.Panel2.Location = new System.Drawing.Point(0, 0);
		this.Panel2.Name = "Panel2";
		this.Panel2.Size = new System.Drawing.Size(804, 34);
		this.Panel2.TabIndex = 19;
		//
		//tlbrIQOQPQ
		//
		this.tlbrIQOQPQ.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
		this.tlbrIQOQPQ.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
			this.tlbtnLock,
			this.ToolBarButton4,
			this.tlbtnPrevious,
			this.ToolBarButton5,
			this.tlbtnNext,
			this.ToolBarButton6,
			this.tlbrPrint,
			this.tlbrPrintAll,
			this.tlbrExport,
			this.ToolBarButton1,
			this.tlbtnReturn
		});
		this.tlbrIQOQPQ.ButtonSize = new System.Drawing.Size(25, 25);
		this.tlbrIQOQPQ.DropDownArrows = true;
		this.tlbrIQOQPQ.ImageList = this.ImageList1;
		this.tlbrIQOQPQ.Location = new System.Drawing.Point(0, 0);
		this.tlbrIQOQPQ.Name = "tlbrIQOQPQ";
		this.tlbrIQOQPQ.ShowToolTips = true;
		this.tlbrIQOQPQ.Size = new System.Drawing.Size(804, 37);
		this.tlbrIQOQPQ.TabIndex = 19;
		//
		//tlbtnLock
		//
		this.tlbtnLock.ImageIndex = 14;
		this.tlbtnLock.Tag = "0";
		this.tlbtnLock.ToolTipText = "Lock[CTRL+L]";
		//
		//ToolBarButton4
		//
		this.ToolBarButton4.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
		//
		//tlbtnPrevious
		//
		this.tlbtnPrevious.ImageIndex = 12;
		this.tlbtnPrevious.Tag = "2";
		this.tlbtnPrevious.ToolTipText = "Previous[CTRL+P]";
		//
		//ToolBarButton5
		//
		this.ToolBarButton5.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
		//
		//tlbtnNext
		//
		this.tlbtnNext.ImageIndex = 11;
		this.tlbtnNext.Tag = "4";
		this.tlbtnNext.ToolTipText = "Next[CTRL+N]";
		//
		//ToolBarButton6
		//
		this.ToolBarButton6.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
		//
		//tlbrPrint
		//
		this.tlbrPrint.ImageIndex = 13;
		this.tlbrPrint.Tag = "6";
		this.tlbrPrint.ToolTipText = "Print the current form";
		this.tlbrPrint.Visible = false;
		//
		//tlbrPrintAll
		//
		this.tlbrPrintAll.ImageIndex = 13;
		this.tlbrPrintAll.Tag = "7";
		this.tlbrPrintAll.ToolTipText = "Print all the forms[CTRL+A]";
		//
		//tlbrExport
		//
		this.tlbrExport.ImageIndex = 9;
		this.tlbrExport.Tag = "8";
		this.tlbrExport.ToolTipText = "Export[CTRL+E]";
		//
		//ToolBarButton1
		//
		this.ToolBarButton1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
		//
		//tlbtnReturn
		//
		this.tlbtnReturn.ImageIndex = 10;
		this.tlbtnReturn.Tag = "10";
		this.tlbtnReturn.ToolTipText = "Return To Main Screen[CTRL+X]";
		//
		//tvwIQOQPQ
		//
		this.tvwIQOQPQ.BackColor = System.Drawing.Color.AliceBlue;
		this.tvwIQOQPQ.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.tvwIQOQPQ.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.tvwIQOQPQ.FullRowSelect = true;
		this.tvwIQOQPQ.HideSelection = false;
		this.tvwIQOQPQ.HotTracking = true;
		this.tvwIQOQPQ.ImageIndex = 3;
		this.tvwIQOQPQ.ImageList = this.ImageList2;
		this.tvwIQOQPQ.Location = new System.Drawing.Point(56, 64);
		this.tvwIQOQPQ.Name = "tvwIQOQPQ";
		this.tvwIQOQPQ.SelectedImageIndex = 3;
		this.tvwIQOQPQ.Size = new System.Drawing.Size(192, 360);
		this.tvwIQOQPQ.TabIndex = 21;
		//
		//ImageList2
		//
		this.ImageList2.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
		this.ImageList2.ImageSize = new System.Drawing.Size(16, 16);
		this.ImageList2.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("ImageList2.ImageStream");
		this.ImageList2.TransparentColor = System.Drawing.Color.Transparent;
		//
		//lstbarIQOQPQ
		//
		this.lstbarIQOQPQ.AllowDragGroups = true;
		this.lstbarIQOQPQ.AllowDragItems = true;
		this.lstbarIQOQPQ.BackColor = System.Drawing.Color.AliceBlue;
		this.lstbarIQOQPQ.Cursor = System.Windows.Forms.Cursors.Hand;
		this.lstbarIQOQPQ.DrawStyle = vbAccelerator.Components.ListBarControl.ListBarDrawStyle.ListBarDrawStyleOfficeXP;
		this.lstbarIQOQPQ.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lstbarIQOQPQ.LargeImageList = null;
		this.lstbarIQOQPQ.Location = new System.Drawing.Point(272, 112);
		this.lstbarIQOQPQ.Name = "lstbarIQOQPQ";
		this.lstbarIQOQPQ.SelectOnMouseDown = false;
		this.lstbarIQOQPQ.Size = new System.Drawing.Size(150, 208);
		this.lstbarIQOQPQ.SmallImageList = null;
		this.lstbarIQOQPQ.TabIndex = 22;
		this.lstbarIQOQPQ.ToolTip = null;
		//
		//tvwSplitter
		//
		this.tvwSplitter.BackColor = System.Drawing.Color.AliceBlue;
		this.tvwSplitter.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.tvwSplitter.Location = new System.Drawing.Point(0, 34);
		this.tvwSplitter.Name = "tvwSplitter";
		this.tvwSplitter.Size = new System.Drawing.Size(5, 467);
		this.tvwSplitter.TabIndex = 23;
		this.tvwSplitter.TabStop = false;
		//
		//VsNetMenuProvider
		//
		this.VsNetMenuProvider.ImageList = this.ImageList1;
		//
		//PrintPreviewDialog1
		//
		this.PrintPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
		this.PrintPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
		this.PrintPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
		this.PrintPreviewDialog1.Document = this.PrintDocument1;
		this.PrintPreviewDialog1.Enabled = true;
		this.PrintPreviewDialog1.Icon = (System.Drawing.Icon)resources.GetObject("PrintPreviewDialog1.Icon");
		this.PrintPreviewDialog1.Location = new System.Drawing.Point(110, 110);
		this.PrintPreviewDialog1.MinimumSize = new System.Drawing.Size(375, 250);
		this.PrintPreviewDialog1.Name = "PrintPreviewDialog1";
		this.PrintPreviewDialog1.TransparencyKey = System.Drawing.Color.Empty;
		this.PrintPreviewDialog1.Visible = false;
		//
		//frmMDI
		//
		this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
		this.BackColor = System.Drawing.Color.AliceBlue;
		this.ClientSize = new System.Drawing.Size(804, 525);
		this.Controls.Add(this.tvwSplitter);
		this.Controls.Add(this.lstbarIQOQPQ);
		this.Controls.Add(this.tvwIQOQPQ);
		this.Controls.Add(this.Panel2);
		this.Controls.Add(this.stsdQualification);
		this.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
		this.IsMdiContainer = true;
		this.Menu = this.MainMenu1;
		this.Name = "frmMDI";
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "AAS203 - IQOQPQ";
		this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
		((System.ComponentModel.ISupportInitialize)this.StatusBarPanel1).EndInit();
		this.Panel2.ResumeLayout(false);
		this.ResumeLayout(false);

	}

	#End Region

	#Region " Form Events "

	#Region " Menus "

	private void  // ERROR: Handles clauses are not supported in C#
mnuIQMode_Click(System.Object sender, System.EventArgs e)
	{
		try {
			funcDisplayChildForm(ENUM_IQ_Modes.IQ_CustomerDetails);
			subCheckMenuClicked(ENUM_IQOQPQ_STATUS.IQ);
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
		// gobjErrorHandler.ProcessError(ErrorHandler.ErrorHandler.EnumErrorType.Critical, ex)
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

	private void  // ERROR: Handles clauses are not supported in C#
mnuOQMode_Click1(object sender, System.EventArgs e)
	{
		try {
			funcDisplayChildForm(ENUM_OQ_Modes.OQ_Approval);
			subCheckMenuClicked(ENUM_IQOQPQ_STATUS.OQ);
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
		// gobjErrorHandler.ProcessError(ErrorHandler.ErrorHandler.EnumErrorType.Critical, ex)
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

	private void  // ERROR: Handles clauses are not supported in C#
mnuPQMode_Click1(object sender, System.EventArgs e)
	{
		try {
			funcDisplayChildForm(ENUM_PQ_Modes.PQ_Approval);
			subCheckMenuClicked(ENUM_IQOQPQ_STATUS.PQ);
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
		// gobjErrorHandler.ProcessError(ErrorHandler.ErrorHandler.EnumErrorType.Critical, ex)
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

	private void  // ERROR: Handles clauses are not supported in C#
mnuExit_Click1(object sender, System.EventArgs e)
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

	private void  // ERROR: Handles clauses are not supported in C#
mnuExport_Click(object sender, System.EventArgs e)
	{
		try {
			///'--- Writing to Activity Log
			//If (gstructApplicationSettings.Enable21CFR = 1) Then
			//    '--- Check for activity authentication
			//    If Not funcCheckActivityAuthentication(enumActivityAuthentication.Export, gstructUserDetails.Access) Then
			//        Return
			//    End If

			//    gfuncInsertActivityLog(EnumModules.IQOQPQ, "IQOQPQ Files Exported")
			//End If

			funcShowSameForm(tvwIQOQPQ.SelectedNode.Tag);
			//Flag used for Exporting all(True) and single(false)
			subExportFiles(false);
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
		// gobjErrorHandler.ProcessError(ErrorHandler.ErrorHandler.EnumErrorType.Critical, ex)
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

	private void  // ERROR: Handles clauses are not supported in C#
mnuLock_Click(object sender, System.EventArgs e)
	{
		try {
			funcLockCurrentMode();
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
mnuNext_Click(object sender, System.EventArgs e)
	{
		try {
			funcGetShowNextForm();
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
mnuPrevious_Click(object sender, System.EventArgs e)
	{
		try {
			funcGetShowPreviousForm();
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
mnuPrint_Click(object sender, System.EventArgs e)
	{
		try {
			funcShowSameForm(tvwIQOQPQ.SelectedNode.Tag);
		//Flag used for Printing all(True) and single(false)

		//--- Writing to Activity Log
		//If (gstructApplicationSettings.Enable21CFR = 1) Then
		//    '--- Check for activity authentication
		//    If Not funcCheckActivityAuthentication(enumActivityAuthentication.Print, gstructUserDetails.Access) Then
		//        Return
		//    End If

		//    gfuncInsertActivityLog(EnumModules.IQOQPQ, "IQOQPQ File Printed")
		//End If

		//Call gfuncPrintIQOQPQ(tvwIQOQPQ.SelectedNode.Tag, False)

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
		// gobjErrorHandler.ProcessError(ErrorHandler.ErrorHandler.EnumErrorType.Critical, ex)
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

	private void  // ERROR: Handles clauses are not supported in C#
mnuPrintAll_Click(object sender, System.EventArgs e)
	{
		try {
			///'--- Writing to Activity Log
			///If (gstructApplicationSettings.Enable21CFR = 1) Then
			///    '--- Check for activity authentication
			///    If Not funcCheckActivityAuthentication(enumActivityAuthentication.Print, gstructUserDetails.Access) Then
			///        Return
			///    End If

			///    gfuncInsertActivityLog(EnumModules.IQOQPQ, "IQOQPQ Files Printed")
			///End If

			//code added by ; dinesh wagh on 8.4.2010
			//purpose : to save all data if we directly close the mdi form
			//------------------------------------------
			subCloseAllChildForm();
			funcDisplayChildForm(tvwIQOQPQ.SelectedNode.Tag);
			//------------------------------


			funcShowSameForm(tvwIQOQPQ.SelectedNode.Tag);

			gfuncPrintAll();

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
		// gobjErrorHandler.ProcessError(ErrorHandler.ErrorHandler.EnumErrorType.Critical, ex)
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

	#Region " Other Events "

	private void  // ERROR: Handles clauses are not supported in C#
Form1_Load(System.Object sender, System.EventArgs e)
	{
		try {
			//--- Initialize the Error logs
			gsubErrorHandlerInitialization(gobjErrorHandler);

			funcInitialize();
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

	private void cmdNext_Click(System.Object sender, System.EventArgs e)
	{
		try {
			funcGetShowNextForm();
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

	private void cmdPrevious_Click(System.Object sender, System.EventArgs e)
	{
		try {
			funcGetShowPreviousForm();
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

	private void cmdLock_Click(System.Object sender, System.EventArgs e)
	{
		try {
			funcLockCurrentMode();
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

	#Region " TreeView Events "

	private void  // ERROR: Handles clauses are not supported in C#
tvwIQOQPQ_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
	{
		try {
			if (funcDisplayChildForm(tvwIQOQPQ.SelectedNode.Tag) == false) {
				Application.DoEvents();
			}


		} catch (System.Configuration.ConfigurationException ex1) {

		} catch (Exception ex) {
		}


	}

	private void  // ERROR: Handles clauses are not supported in C#
tvwSplitter_DoubleClick(object sender, System.EventArgs e)
	{
		try {
			tvwIQOQPQ.Width = 192;
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

	#Region " ListBar Events "
	private void lstbarIQOQPQ_ItemClicked(System.Object sender, vbAccelerator.Components.ListBarControl.ItemClickedEventArgs e)
	{
		try {
			funcDisplayChildForm(e.Item.Tag);
			Application.DoEvents();
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

	#Region "ToolBar Events"

	private void  // ERROR: Handles clauses are not supported in C#
tlbrIQOQPQ_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
	{
		try {
			Point ptButton;
			ptButton.X = e.X;
			ptButton.Y = e.Y;
			funcDisplayOnStatusbar(ptButton);
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
tlbrIQOQPQ_MouseLeave(object sender, System.EventArgs e)
	{
		try {
			StatusBarPanel1.Text = "";
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
tlbrIQOQPQ_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
	{
		try {
			switch (e.Button.Tag) {
				case enumToolBarButtons.tlbtnLock:
					funcLockCurrentMode();
				case enumToolBarButtons.tlbtnNext:
					funcGetShowNextForm();
				case enumToolBarButtons.tlbtnPrevious:
					funcGetShowPreviousForm();

				case enumToolBarButtons.tlbrPrint:
				///'--- Writing to Activity Log
				///If (gstructApplicationSettings.Enable21CFR = 1) Then
				///    '--- Check for activity authentication
				///    If Not funcCheckActivityAuthentication(enumActivityAuthentication.Print, gstructUserDetails.Access) Then
				///        Return
				///    End If

				///    gfuncInsertActivityLog(EnumModules.IQOQPQ, "IQOQPQ File Printed")
				///End If
				//Call funcShowSameForm(tvwIQOQPQ.SelectedNode.Tag)
				//Flag used for Printing all(True) and single(false)

				///Call gfuncPrintIQOQPQ(tvwIQOQPQ.SelectedNode.Tag, False)

				case enumToolBarButtons.tlbrExport:

					///'--- Writing to Activity Log
					///If (gstructApplicationSettings.Enable21CFR = 1) Then
					///    '--- Check for activity authentication
					///    If Not funcCheckActivityAuthentication(enumActivityAuthentication.Export, gstructUserDetails.Access) Then
					///        Return
					///    End If

					///    gfuncInsertActivityLog(EnumModules.IQOQPQ, "IQOQPQ Files Exported")
					///End If
					mnuExport_Click(mnuExport, new EventArgs());
				//Call funcShowSameForm(tvwIQOQPQ.SelectedNode.Tag)
				//Flag used for Exporting all(True) and single(false)
				///Call subExportFiles(False)
				case enumToolBarButtons.tlbrPrintAll:

					///'--- Writing to Activity Log
					///If (gstructApplicationSettings.Enable21CFR = 1) Then
					///    '--- Check for activity authentication
					///    If Not funcCheckActivityAuthentication(enumActivityAuthentication.Print, gstructUserDetails.Access) Then
					///        Return
					///    End If

					///    gfuncInsertActivityLog(EnumModules.IQOQPQ, "IQOQPQ Files Printed")
					///End If

					mnuPrintAll_Click(mnuPrintAll, new EventArgs());
				//Call funcShowSameForm(tvwIQOQPQ.SelectedNode.Tag)

				///Call gfuncPrintAll()

				case enumToolBarButtons.tlbtnExit:
					this.Close();
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

	#End Region

	#End Region

	#Region " General Private functions "

	//--------------------------------------------------------
	//    General functions used for IQOQPQ
	//--- funcInitialize - To Initialize form and to fill records in Tree View control and display them.
	//--- funcCreateNode - To Add a node with name passed to it to the TreeNode object passed.
	//--- funcUpdateStatusBar - To Update Status Bar and displa the Name which is passed to it.
	//--- funcMakeActiveForm - To Close Previous Forms and make IQOQPQ form Active.

	private void funcInitialize()
	{
		//=====================================================================
		// Procedure Name        :   funcInitailize
		// Description           :   To Initialize form and to fill records in Tree View control and display them.
		// Purpose               :   To Initialize form and to fill records in Tree View control and display them.
		// Parameters Passed     :   None.
		// Returns               :   None.
		// Parameters Affected   :   None.
		// Assumptions           :
		// Dependencies          :
		// Author                :   
		// Created               :   January , 2003 
		// Revisions             :
		//=====================================================================
		try {
			//--- Create the connection to the IQOQPQ database
			//If Not gfuncCreateIQOQPQConnection() Then
			//    Me.Close()
			//End If
			string strInstrumentType;

			//Saurabh 30.07.07 to get the Instrument Type 
			if (InstrumentType != null) {
				InstrumentType(strInstrumentType);
			}
			this.Text = strInstrumentType + " IQOQPQ";
			//Saurabh 30.07.07 to get the Instrument Type 

			if (CONST_Use_TreeView == 1) {
				funcGetTreeViewNodes();
			} else {
				funcGetListBarItems();
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

	#Region "Functions Related to TreeView"

	private object funcGetTreeViewNodes()
	{
		//=====================================================================
		// Procedure Name        :   funcGetTreeViewNodes
		// Description           :   To fill records in Tree View control and display them.
		// Purpose               :   To fill records in Tree View control and display them.
		// Parameters Passed     :   None.
		// Returns               :   None.
		// Parameters Affected   :   None.
		// Assumptions           :
		// Dependencies          :
		// Author                :   
		// Created               :   January , 2003 
		// Revisions             :
		//=====================================================================
		try {
			lstbarIQOQPQ.Visible = false;
			//Forcing Tree View To always appear to the left of screen
			tvwIQOQPQ.Anchor = AnchorStyles.Left;
			tvwIQOQPQ.Dock = DockStyle.Left;
			tvwSplitter.Visible = true;
			tvwSplitter.Location = new Point(tvwIQOQPQ.Left + tvwIQOQPQ.Width, tvwIQOQPQ.Top);

			//--- Installation Qualification (IQ)
			TreeNode nodeInstallation = new TreeNode("Installation Qualification");
			nodeInstallation.ImageIndex = 4;
			//Saurabh
			nodeInstallation.SelectedImageIndex = 4;
			//Saurabh
			tvwIQOQPQ.Nodes.Add(nodeInstallation);
			nodeInstallation.Tag = ENUM_IQOQPQ_STATUS.IQ;
			tvwIQOQPQ.HotTracking = true;

			//--- To Add Sub-Nodes for IQ.
			funcCreateNode("Customer Details", ENUM_IQ_Modes.IQ_CustomerDetails, nodeInstallation);
			funcCreateNode("Equipment Listing", ENUM_IQ_Modes.IQ_EquipmentList, nodeInstallation);
			funcCreateNode("Manual Listing", ENUM_IQ_Modes.IQ_ManualList, nodeInstallation);
			funcCreateNode("Approval", ENUM_IQ_Modes.IQ_Approval, nodeInstallation);
			//funcCreateNode("Specification Of Instruments", ENUM_IQ_Modes.IQ_Specifications, nodeInstallation) 'commented by ; dinesh wagh on 4.4.2010
			funcCreateNode("Instrument Details", ENUM_IQ_Modes.IQ_Specifications, nodeInstallation);
			//added by ; dinesh wagh on 4.4.2010
			funcCreateNode("Tests", ENUM_IQ_Modes.IQ_Tests, nodeInstallation);
			funcCreateNode("Deficiencies Found & Corrective Action ", ENUM_IQ_Modes.IQ_Deficiency, nodeInstallation);

			//--- Operational Qualification (OQ)
			TreeNode nodeOperational = new TreeNode("Operational Qualification");
			nodeOperational.ImageIndex = 5;
			//Saurabh
			nodeOperational.SelectedImageIndex = 5;
			//Saurabh
			tvwIQOQPQ.Nodes.Add(nodeOperational);
			nodeOperational.Tag = ENUM_IQOQPQ_STATUS.OQ;
			tvwIQOQPQ.HotTracking = true;

			//--- To Add Sub-Nodes for OQ.
			funcCreateNode("Approval", ENUM_OQ_Modes.OQ_Approval, nodeOperational);
			funcCreateNode("Equipment Listing", ENUM_OQ_Modes.OQ_EquipmentList, nodeOperational);
			funcCreateNode("Test - 1", ENUM_OQ_Modes.OQ_Test1, nodeOperational);
			funcCreateNode("Test - 2", ENUM_OQ_Modes.OQ_Test2, nodeOperational);
			funcCreateNode("Training", ENUM_OQ_Modes.OQ_UserTraining, nodeOperational);
			funcCreateNode("Deficiencies Found & Corrective Action ", ENUM_OQ_Modes.OQ_Deficiency, nodeOperational);

			//--- Performance Qualification (PQ)
			TreeNode nodePerformance = new TreeNode("Performance Qualification");
			nodePerformance.ImageIndex = 6;
			//Saurabh
			nodePerformance.SelectedImageIndex = 6;
			//Saurabh
			tvwIQOQPQ.Nodes.Add(nodePerformance);
			nodePerformance.Tag = ENUM_IQOQPQ_STATUS.PQ;
			tvwIQOQPQ.HotTracking = true;

			//--- To Add Sub-Nodes for PQ.
			funcCreateNode("Approval", ENUM_PQ_Modes.PQ_Approval, nodePerformance);
			funcCreateNode("Equipment Listing", ENUM_PQ_Modes.PQ_EquipmentList, nodePerformance);
			funcCreateNode("Test", ENUM_PQ_Modes.PQ_Test, nodePerformance);
			funcCreateNode("Attachment-1", ENUM_PQ_Modes.PQ_Attachment1, nodePerformance);
			funcCreateNode("Attachment-2", ENUM_PQ_Modes.PQ_Attachment2, nodePerformance);
			funcCreateNode("Attachment-3", ENUM_PQ_Modes.PQ_Attachment3, nodePerformance);
			//================Modified by Saurabh======================
			//funcCreateNode("Attachment-4", ENUM_PQ_Modes.PQ_Attachment4, nodePerformance)
			//funcCreateNode("Attachment-5", ENUM_PQ_Modes.PQ_Attachment5, nodePerformance)
			//funcCreateNode("Attachment-6", ENUM_PQ_Modes.PQ_Attachment6, nodePerformance)
			//funcCreateNode("Attachment-7", ENUM_PQ_Modes.PQ_Attachment7, nodePerformance)
			//funcCreateNode("Attachment-8", ENUM_PQ_Modes.PQ_Attachment8, nodePerformance)
			//funcCreateNode("Attachment-9", ENUM_PQ_Modes.PQ_Attachment9, nodePerformance)
			//================Modified by Saurabh======================
			funcCreateNode("Deficiencies Found & Corrective Action ", ENUM_PQ_Modes.PQ_Deficiency, nodePerformance);
			funcCreateNode("Warranty", ENUM_PQ_Modes.PQ_Warranty, nodePerformance);

			funcDisplayChildForm(ENUM_IQ_Modes.IQ_CustomerDetails);

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

	private object funcCreateNode(string strName, int intTag, ref TreeNode ObjParent)
	{
		//=====================================================================
		// Procedure Name        :   funcCreateNode
		// Description           :   To Add a node with name passed to it to the TreeNode object passed.
		// Purpose               :   To Add a node with name passed to it to the TreeNode object passed.
		// Parameters Passed     :   Name of Node and Reference Node.
		// Returns               :   None.
		// Parameters Affected   :   None.
		// Assumptions           :
		// Dependencies          :
		// Author                :   
		// Created               :   January , 2003 
		// Revisions             :
		//=====================================================================
		try {
			TreeNode objChildNode = new TreeNode(strName);

			ObjParent.Nodes.Add(objChildNode);
			objChildNode.Tag = intTag;

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

	private bool funcShowSelectedNode(string TagValue)
	{
		//=====================================================================
		// Procedure Name        :   funcShowSelectedNode
		// Description           :   To HighLight the Selected Node.
		// Purpose               :   To HighLight the Selected Node.
		// Parameters Passed     :   Tag of the Node.
		// Returns               :   None.
		// Parameters Affected   :   None.
		// Assumptions           :
		// Dependencies          :
		// Author                :   
		// Created               :   January , 2003 
		// Revisions             :
		//=====================================================================
		bool blnResult = true;
		string strNodeTag;
		TreeNode objNode = new TreeNode();
		int intCounter;
		try {
			//--- FOR IQ
			if (blnResult) {
				foreach ( objNode in tvwIQOQPQ.Nodes(0).Nodes) {
					strNodeTag = (string)objNode.Tag() + "";
					if ((strNodeTag == TagValue)) {
						tvwIQOQPQ.SelectedNode() = objNode;
						blnResult = false;
						break; // TODO: might not be correct. Was : Exit For
					}
				}
				//for intCounter=0 to tvwIQOQPQ.Nodes(0).Nodes.    
			}
			//--- FOR OQ
			if (blnResult) {
				foreach ( objNode in tvwIQOQPQ.Nodes(1).Nodes) {
					strNodeTag = (string)objNode.Tag() + "";
					if ((strNodeTag == TagValue)) {
						tvwIQOQPQ.SelectedNode() = objNode;
						blnResult = false;
						break; // TODO: might not be correct. Was : Exit For
					}
				}
			}
			//--- FOR PQ
			if (blnResult) {
				foreach ( objNode in tvwIQOQPQ.Nodes(2).Nodes) {
					strNodeTag = (string)objNode.Tag() + "";
					if ((strNodeTag == TagValue)) {
						tvwIQOQPQ.SelectedNode() = objNode;
						blnResult = false;
						break; // TODO: might not be correct. Was : Exit For
					}
				}
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

	#End Region

	#Region "Functions Related to ListBar"

	private object funcGetListBarItems()
	{
		//=====================================================================
		// Procedure Name        :   funcGetListBarItems
		// Description           :   To fill records in ListBar control and display them.
		// Purpose               :   To fill records in ListBar control and display them.
		// Parameters Passed     :   None.
		// Returns               :   None.
		// Parameters Affected   :   None.
		// Assumptions           :
		// Dependencies          :
		// Author                :   Gitesh
		// Created               :   February, 2003 
		// Revisions             :
		//=====================================================================
		try {
			tvwIQOQPQ.Visible = false;
			//Forcing Tree View To always appear to the left of screen
			lstbarIQOQPQ.Anchor = AnchorStyles.Left;
			lstbarIQOQPQ.Dock = DockStyle.Left;
			lstbarIQOQPQ.Visible = true;
			lstbarIQOQPQ.Location = new Point(tvwIQOQPQ.Left + tvwIQOQPQ.Width, tvwIQOQPQ.Top);
			lstbarIQOQPQ.Groups.Clear();

			lstbarIQOQPQ.Anchor = AnchorStyles.Left;
			lstbarIQOQPQ.Dock = DockStyle.Left;
			//tvwSplitter.Visible = True
			//tvwSplitter.Location = New Point(tvwIQOQPQ.Left + tvwIQOQPQ.Width, tvwIQOQPQ.Top)

			//--- Installation Qualification (IQ)
			ListBarGroup grpInstallation = new ListBarGroup("Installation Qualification");
			grpInstallation.Tag = ENUM_IQOQPQ_STATUS.IQ;
			grpInstallation.BackColor = Color.Linen;
			lstbarIQOQPQ.Groups.Add(grpInstallation);

			//--- To Add Items for IQ.
			funcAddItemToGroup("Equipment Listing", ENUM_IQ_Modes.IQ_EquipmentList, grpInstallation);
			funcAddItemToGroup("Mannual Listing", ENUM_IQ_Modes.IQ_ManualList, grpInstallation);
			funcAddItemToGroup("Approval", ENUM_IQ_Modes.IQ_Approval, grpInstallation);
			funcAddItemToGroup("Instrument & Accessories Specification", ENUM_IQ_Modes.IQ_Specifications, grpInstallation);
			funcAddItemToGroup("Tests", ENUM_IQ_Modes.IQ_Tests, grpInstallation);
			funcAddItemToGroup("Deficiencies & Corrective Action Plan", ENUM_IQ_Modes.IQ_Deficiency, grpInstallation);

			//--- Operational Qualification (OQ)
			ListBarGroup grpOperational = new ListBarGroup("Operational Qualification");
			grpOperational.Tag = ENUM_IQOQPQ_STATUS.OQ;
			lstbarIQOQPQ.Groups.Add(grpOperational);

			//--- To Add Items for OQ.
			funcAddItemToGroup("Approval", ENUM_OQ_Modes.OQ_Approval, grpOperational);
			funcAddItemToGroup("Equipment Listing", ENUM_OQ_Modes.OQ_EquipmentList, grpOperational);
			funcAddItemToGroup("Test - 1", ENUM_OQ_Modes.OQ_Test1, grpOperational);
			funcAddItemToGroup("Test - 2", ENUM_OQ_Modes.OQ_Test2, grpOperational);
			funcAddItemToGroup("Training", ENUM_OQ_Modes.OQ_UserTraining, grpOperational);
			funcAddItemToGroup("Deficiencies & Corrective Action Plan", ENUM_OQ_Modes.OQ_Deficiency, grpOperational);

			//--- Performance Qualification (PQ)
			ListBarGroup grpPerformance = new ListBarGroup("Performance Qualification");
			grpPerformance.Tag = ENUM_IQOQPQ_STATUS.PQ;
			lstbarIQOQPQ.Groups.Add(grpPerformance);

			//--- To Add Items for PQ.
			funcAddItemToGroup("Approval", ENUM_PQ_Modes.PQ_Approval, grpPerformance);
			funcAddItemToGroup("Equipment Listing", ENUM_PQ_Modes.PQ_EquipmentList, grpPerformance);
			funcAddItemToGroup("Test", ENUM_PQ_Modes.PQ_Test, grpPerformance);
			funcAddItemToGroup("Attachment-1", ENUM_PQ_Modes.PQ_Attachment1, grpPerformance);
			funcAddItemToGroup("Attachment-2", ENUM_PQ_Modes.PQ_Attachment2, grpPerformance);
			funcAddItemToGroup("Attachment-3", ENUM_PQ_Modes.PQ_Attachment3, grpPerformance);
			//funcAddItemToGroup("Attachment-4", ENUM_PQ_Modes.PQ_Attachment4, grpPerformance)
			//funcAddItemToGroup("Attachment-5", ENUM_PQ_Modes.PQ_Attachment5, grpPerformance)
			funcAddItemToGroup("Deficiencies & Corrective Action Plan", ENUM_PQ_Modes.PQ_Deficiency, grpPerformance);
			funcAddItemToGroup("Warranty", ENUM_PQ_Modes.PQ_Warranty, grpPerformance);

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

	private object funcAddItemToGroup(string strName, int intTag, ref ListBarGroup ObjParentGroup)
	{
		//=====================================================================
		// Procedure Name        :   funcAddItemToGroup
		// Description           :   To Add a node with name passed to it to the ListBar Group passed.
		// Purpose               :   To Add a node with name passed to it to the ListBar Group passed.
		// Parameters Passed     :   Name of Item and Reference Group.
		// Returns               :   None.
		// Parameters Affected   :   None.
		// Assumptions           :
		// Dependencies          :
		// Author                :   
		// Created               :   January , 2003 
		// Revisions             :
		//=====================================================================
		try {
			ListBarItem objItem = new ListBarItem(strName);
			objItem.Tag = intTag;

			ObjParentGroup.Items.Add(objItem);
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

	#Region "Functions Related to Form Display"

	private bool funcShowChildForms(Form objChildFormIn)
	{
		try {
			//mobjChildForm = objChildFormIn
			if (!this.ActiveMdiChild == null) {
				this.ActiveMdiChild.Close();
				//Me.ActiveMdiChild.Dispose()
			}
			objChildFormIn.MdiParent = this;
			//CustomPanelMain.Controls.Add(objChildFormIn)
			this.ActivateMdiChild(objChildFormIn);
			//objChildFormIn.Dock = DockStyle.Fill
			objChildFormIn.BringToFront();
			objChildFormIn.Show();

		} catch (Exception ex) {
		}

	}

	private bool funcDisplayChildForm(int intTagValue)
	{
		string strTag;
		string strSelectedItemText;
		///Dim mfrmPQTest2 As New frmPQTest2
		try {
			funcMakeActiveForm();
			if (CONST_Use_TreeView == 1) {
				funcShowSelectedNode(intTagValue);
				strSelectedItemText = tvwIQOQPQ.SelectedNode.Text;
			} else {
				strSelectedItemText = lstbarIQOQPQ.SelectedGroup.SelectedItem.Caption;
			}


			switch (intTagValue) {
				case ENUM_IQOQPQ_STATUS.IQ:
				case ENUM_IQ_Modes.IQ_CustomerDetails:
				case ENUM_IQ_Modes.IQ_Approval:
				case ENUM_IQ_Modes.IQ_Deficiency:
				case ENUM_IQ_Modes.IQ_EquipmentList:
				case ENUM_IQ_Modes.IQ_ManualList:
				case ENUM_IQ_Modes.IQ_Specifications:
				case ENUM_IQ_Modes.IQ_Tests:
					//tvwIQOQPQ.SelectedImageIndex = 4        'Saurabh
					if (gobjDataAccess.funcCheckModeLocked(ENUM_IQOQPQ_STATUS.IQ)) {
						//------to check mode is lock or unlock and change the icon in toolbar
						tlbrIQOQPQ.Buttons(0).ImageIndex = CONST_ModeLock;
					} else {
						tlbrIQOQPQ.Buttons(0).ImageIndex = CONST_ModeUnLock;
					}
				case ENUM_IQOQPQ_STATUS.OQ:
				case ENUM_OQ_Modes.OQ_Approval:
				case ENUM_OQ_Modes.OQ_Deficiency:
				case ENUM_OQ_Modes.OQ_EquipmentList:
				case ENUM_OQ_Modes.OQ_Test1:
				case ENUM_OQ_Modes.OQ_Test2:
				case ENUM_OQ_Modes.OQ_UserTraining:
					//tvwIQOQPQ.SelectedImageIndex = 5        'Saurabh
					if (gobjDataAccess.funcCheckModeLocked(ENUM_IQOQPQ_STATUS.OQ)) {
						//------to check mode is lock or unlock and change the icon in toolbar
						tlbrIQOQPQ.Buttons(0).ImageIndex = CONST_ModeLock;
					} else {
						tlbrIQOQPQ.Buttons(0).ImageIndex = CONST_ModeUnLock;
					}
				case ENUM_IQOQPQ_STATUS.PQ:
				case ENUM_PQ_Modes.PQ_Approval:
				case ENUM_PQ_Modes.PQ_Attachment1:
				case ENUM_PQ_Modes.PQ_Attachment2:
				case ENUM_PQ_Modes.PQ_Attachment3:
				case ENUM_PQ_Modes.PQ_Deficiency:
				case ENUM_PQ_Modes.PQ_EquipmentList:
				case ENUM_PQ_Modes.PQ_Test:
				case ENUM_PQ_Modes.PQ_Warranty:
					//tvwIQOQPQ.SelectedImageIndex = 6        'Saurabh
					if (gobjDataAccess.funcCheckModeLocked(ENUM_IQOQPQ_STATUS.PQ)) {
						//------to check mode is lock or unlock and change the icon in toolbar
						tlbrIQOQPQ.Buttons(0).ImageIndex = CONST_ModeLock;
					} else {
						tlbrIQOQPQ.Buttons(0).ImageIndex = CONST_ModeUnLock;

					}
			}

			switch (intTagValue) {

				//--- IQ Mode is selected
				case ENUM_IQOQPQ_STATUS.IQ:
					strTag = (string)0 + "," + (string)ENUM_IQ_Modes.IQ_CustomerDetails + "" + "," + (string)ENUM_IQ_Modes.IQ_EquipmentList + "";
					frmCustomerDetails mfrmCustDetails = new frmCustomerDetails();
					mfrmCustDetails.MdiParent = this;
					mfrmCustDetails.Tag = strTag;
					//funcShowChildForms(mfrmCustDetails)
					mfrmCustDetails.Show();
					if (this.tvwIQOQPQ.Height > mfrmCustDetails.Panel1.Height) {
						mfrmCustDetails.Panel1.Height = this.tvwIQOQPQ.Height - 5;
					}
					mfrmCustDetails.Refresh();
					funcUpdateStatusBar("Installation Qualification : " + strSelectedItemText);

					subCheckMenuClicked(ENUM_IQOQPQ_STATUS.IQ);
				//--- "IQ Customer Details" 
				case ENUM_IQ_Modes.IQ_CustomerDetails:
					strTag = (string)0 + "," + (string)ENUM_IQ_Modes.IQ_CustomerDetails + "" + "," + (string)ENUM_IQ_Modes.IQ_EquipmentList + "";
					frmCustomerDetails mfrmCustDetails = new frmCustomerDetails();
					mfrmCustDetails.MdiParent = this;
					mfrmCustDetails.Tag = strTag;
					//funcShowChildForms(mfrmCustDetails)
					mfrmCustDetails.Show();
					if (this.tvwIQOQPQ.Height > mfrmCustDetails.Panel1.Height) {
						mfrmCustDetails.Panel1.Height = this.tvwIQOQPQ.Height - 5;
					}
					mfrmCustDetails.Refresh();
					funcUpdateStatusBar("Installation Qualification : " + strSelectedItemText);

					subCheckMenuClicked(ENUM_IQOQPQ_STATUS.IQ);
				//--- "IQ Equipment Listing" 
				case ENUM_IQ_Modes.IQ_EquipmentList:
					strTag = (string)ENUM_IQ_Modes.IQ_CustomerDetails + "" + "," + (string)ENUM_IQ_Modes.IQ_EquipmentList + "" + "," + (string)ENUM_IQ_Modes.IQ_ManualList + "";
					frmIQEquipmentList mfrmEqLst = new frmIQEquipmentList();
					mfrmEqLst.MdiParent = this;
					mfrmEqLst.Tag = strTag;
					//funcShowChildForms(mfrmEqLst)
					mfrmEqLst.Show();
					if (this.tvwIQOQPQ.Height > mfrmEqLst.Panel1.Height) {
						mfrmEqLst.Panel1.Height = this.tvwIQOQPQ.Height - 5;
					}
					funcUpdateStatusBar("Installation Qualification : " + strSelectedItemText);

					subCheckMenuClicked(ENUM_IQOQPQ_STATUS.IQ);
				//--- "IQ Manual Listing" 
				case ENUM_IQ_Modes.IQ_ManualList:
					strTag = (string)ENUM_IQ_Modes.IQ_EquipmentList + "" + "," + (string)ENUM_IQ_Modes.IQ_ManualList + "" + "," + (string)ENUM_IQ_Modes.IQ_Approval + "";
					frmIQMannualList mfrmManualLst = new frmIQMannualList();
					mfrmManualLst.MdiParent = this;
					mfrmManualLst.Tag = strTag;
					mfrmManualLst.Show();
					if (this.tvwIQOQPQ.Height > mfrmManualLst.Panel1.Height) {
						mfrmManualLst.Panel1.Height = this.tvwIQOQPQ.Height - 5;
					}
					funcUpdateStatusBar("Installation Qualification : " + strSelectedItemText);

					subCheckMenuClicked(ENUM_IQOQPQ_STATUS.IQ);
				//--- "IQ Approval" 
				case ENUM_IQ_Modes.IQ_Approval:
					strTag = (string)ENUM_IQ_Modes.IQ_ManualList + "" + "," + (string)ENUM_IQ_Modes.IQ_Approval + "" + "," + (string)ENUM_IQ_Modes.IQ_Specifications + "";
					frmIQApproval mfrmIQApproval = new frmIQApproval(ENUM_IQOQPQ_STATUS.IQ);
					mfrmIQApproval.MdiParent = this;
					mfrmIQApproval.Tag = strTag;
					mfrmIQApproval.Show();
					if (this.tvwIQOQPQ.Height > mfrmIQApproval.Panel1.Height) {
						mfrmIQApproval.Panel1.Height = this.tvwIQOQPQ.Height - 5;
					}
					funcUpdateStatusBar("Installation Qualification : " + strSelectedItemText);

					subCheckMenuClicked(ENUM_IQOQPQ_STATUS.IQ);
				//--- "IQ Instrument & Accessories Specification"
				case ENUM_IQ_Modes.IQ_Specifications:
					strTag = (string)ENUM_IQ_Modes.IQ_Approval + "" + "," + (string)ENUM_IQ_Modes.IQ_Specifications + "" + "," + (string)ENUM_IQ_Modes.IQ_Tests + "";
					frmIQSpecification mfrmSpecification = new frmIQSpecification();
					mfrmSpecification.MdiParent = this;
					mfrmSpecification.Tag = strTag;
					mfrmSpecification.Show();
					if (this.tvwIQOQPQ.Height > mfrmSpecification.Panel1.Height) {
						mfrmSpecification.Panel1.Height = this.tvwIQOQPQ.Height - 5;
					}
					funcUpdateStatusBar("Installation Qualification : " + strSelectedItemText);

					subCheckMenuClicked(ENUM_IQOQPQ_STATUS.IQ);
				//--- "IQ Tests"
				case ENUM_IQ_Modes.IQ_Tests:
					strTag = (string)ENUM_IQ_Modes.IQ_Specifications + "" + "," + (string)ENUM_IQ_Modes.IQ_Tests + "" + "," + (string)ENUM_IQ_Modes.IQ_Deficiency + "";
					frmIQTest mfrmTest = new frmIQTest();
					// frmextra  
					mfrmTest.MdiParent = this;
					mfrmTest.Tag = strTag;
					mfrmTest.Show();
					if (this.tvwIQOQPQ.Height > mfrmTest.Panel1.Height) {
						mfrmTest.Panel1.Height = this.tvwIQOQPQ.Height - 5;
					}
					funcUpdateStatusBar("Installation Qualification : " + strSelectedItemText);

					subCheckMenuClicked(ENUM_IQOQPQ_STATUS.IQ);
				//--- "IQ Deficiencies & Corrective Action Plan"
				case ENUM_IQ_Modes.IQ_Deficiency:
					strTag = (string)ENUM_IQ_Modes.IQ_Tests + "" + "," + (string)ENUM_IQ_Modes.IQ_Deficiency + "" + "," + (string)ENUM_OQ_Modes.OQ_Approval + "";
					frmIQDeficiency mfrmIQDeficiency = new frmIQDeficiency(ENUM_IQOQPQ_STATUS.IQ);
					mfrmIQDeficiency.MdiParent = this;
					mfrmIQDeficiency.Tag = strTag;
					mfrmIQDeficiency.Show();
					if (this.tvwIQOQPQ.Height > mfrmIQDeficiency.Panel1.Height) {
						mfrmIQDeficiency.Panel1.Height = this.tvwIQOQPQ.Height - 5;
					}
					funcUpdateStatusBar("Installation Qualification : " + strSelectedItemText);

					subCheckMenuClicked(ENUM_IQOQPQ_STATUS.IQ);
				//--- OQ Mode is selected
				case ENUM_IQOQPQ_STATUS.OQ:

					strTag = (string)ENUM_IQ_Modes.IQ_Deficiency + "" + "," + (string)ENUM_OQ_Modes.OQ_Approval + "" + "," + (string)ENUM_OQ_Modes.OQ_EquipmentList + "";
					frmIQApproval mfrmOQApproval = new frmIQApproval(ENUM_IQOQPQ_STATUS.OQ);
					mfrmOQApproval.MdiParent = this;
					mfrmOQApproval.Tag = strTag;
					mfrmOQApproval.Show();
					if (this.tvwIQOQPQ.Height > mfrmOQApproval.Panel1.Height) {
						mfrmOQApproval.Panel1.Height = this.tvwIQOQPQ.Height - 5;
					}
					funcUpdateStatusBar("Operational Qualification : " + strSelectedItemText);

					subCheckMenuClicked(ENUM_IQOQPQ_STATUS.OQ);
				//--- "OQ Approval"
				case ENUM_OQ_Modes.OQ_Approval:
					strTag = (string)ENUM_IQ_Modes.IQ_Deficiency + "" + "," + (string)ENUM_OQ_Modes.OQ_Approval + "" + "," + (string)ENUM_OQ_Modes.OQ_EquipmentList + "";
					frmIQApproval mfrmOQApproval = new frmIQApproval(ENUM_IQOQPQ_STATUS.OQ);
					mfrmOQApproval.MdiParent = this;
					mfrmOQApproval.Tag = strTag;
					mfrmOQApproval.Show();
					if (this.tvwIQOQPQ.Height > mfrmOQApproval.Panel1.Height) {
						mfrmOQApproval.Panel1.Height = this.tvwIQOQPQ.Height - 5;
					}
					funcUpdateStatusBar("Operational Qualification : " + strSelectedItemText);

					subCheckMenuClicked(ENUM_IQOQPQ_STATUS.OQ);
				//--- "OQ Equipment List"
				case ENUM_OQ_Modes.OQ_EquipmentList:
					strTag = (string)ENUM_OQ_Modes.OQ_Approval + "" + "," + (string)ENUM_OQ_Modes.OQ_EquipmentList + "" + "," + (string)ENUM_OQ_Modes.OQ_Test1 + "";
					frmOQEquipmentList mfrmOQEquipmentList = new frmOQEquipmentList(ENUM_IQOQPQ_STATUS.OQ);
					mfrmOQEquipmentList.MdiParent = this;
					mfrmOQEquipmentList.Tag = strTag;
					mfrmOQEquipmentList.Show();
					if (this.tvwIQOQPQ.Height > mfrmOQEquipmentList.Panel1.Height) {
						mfrmOQEquipmentList.Panel1.Height = this.tvwIQOQPQ.Height - 5;
					}
					funcUpdateStatusBar("Operational Qualification : " + strSelectedItemText);

					subCheckMenuClicked(ENUM_IQOQPQ_STATUS.OQ);
				//--- "OQ Test1"
				case ENUM_OQ_Modes.OQ_Test1:
					strTag = (string)ENUM_OQ_Modes.OQ_EquipmentList + "" + "," + (string)ENUM_OQ_Modes.OQ_Test1 + "" + "," + (string)ENUM_OQ_Modes.OQ_Test2 + "";
					frmOQTest mfrmOQTest = new frmOQTest();
					mfrmOQTest.MdiParent = this;
					mfrmOQTest.Tag = strTag;
					mfrmOQTest.Show();
					if (this.tvwIQOQPQ.Height > mfrmOQTest.Panel1.Height) {
						mfrmOQTest.Panel1.Height = this.tvwIQOQPQ.Height - 5;
					}
					funcUpdateStatusBar("Operational Qualification : " + strSelectedItemText);

					subCheckMenuClicked(ENUM_IQOQPQ_STATUS.OQ);
				//--- "OQ Test2"
				case ENUM_OQ_Modes.OQ_Test2:
					strTag = (string)ENUM_OQ_Modes.OQ_Test1 + "" + "," + (string)ENUM_OQ_Modes.OQ_Test2 + "" + "," + (string)ENUM_OQ_Modes.OQ_UserTraining + "";
					frmOQTest2 mfrmOQTest2 = new frmOQTest2();
					mfrmOQTest2.MdiParent = this;
					mfrmOQTest2.Tag = strTag;
					mfrmOQTest2.Show();
					if (this.tvwIQOQPQ.Height > mfrmOQTest2.Panel1.Height) {
						mfrmOQTest2.Panel1.Height = this.tvwIQOQPQ.Height - 5;
					}
					funcUpdateStatusBar("Operational Qualification : " + strSelectedItemText);

					subCheckMenuClicked(ENUM_IQOQPQ_STATUS.OQ);
				//--- "OQ User Training"
				case ENUM_OQ_Modes.OQ_UserTraining:
					strTag = (string)ENUM_OQ_Modes.OQ_Test2 + "" + "," + (string)ENUM_OQ_Modes.OQ_UserTraining + "" + "," + (string)ENUM_OQ_Modes.OQ_Deficiency + "";
					frmOQUserTraining mfrmUserTraining = new frmOQUserTraining();
					mfrmUserTraining.MdiParent = this;
					mfrmUserTraining.Tag = strTag;
					mfrmUserTraining.Show();
					if (this.tvwIQOQPQ.Height > mfrmUserTraining.Panel1.Height) {
						mfrmUserTraining.Panel1.Height = this.tvwIQOQPQ.Height - 5;
					}
					funcUpdateStatusBar("Operational Qualification : " + strSelectedItemText);

					subCheckMenuClicked(ENUM_IQOQPQ_STATUS.OQ);
				//--- "OQ Deficiency & Corrective Action"
				case ENUM_OQ_Modes.OQ_Deficiency:
					strTag = (string)ENUM_OQ_Modes.OQ_UserTraining + "" + "," + (string)ENUM_OQ_Modes.OQ_Deficiency + "" + "," + (string)ENUM_PQ_Modes.PQ_Approval + "";
					frmIQDeficiency mfrmOQDeficiency = new frmIQDeficiency(ENUM_IQOQPQ_STATUS.OQ);
					mfrmOQDeficiency.MdiParent = this;
					mfrmOQDeficiency.Tag = strTag;
					mfrmOQDeficiency.Show();
					if (this.tvwIQOQPQ.Height > mfrmOQDeficiency.Panel1.Height) {
						mfrmOQDeficiency.Panel1.Height = this.tvwIQOQPQ.Height - 5;
					}
					funcUpdateStatusBar("Operational Qualification : " + strSelectedItemText);

					subCheckMenuClicked(ENUM_IQOQPQ_STATUS.OQ);
				//--- PQ Mode is selected 
				case ENUM_IQOQPQ_STATUS.PQ:
					strTag = (string)ENUM_OQ_Modes.OQ_Deficiency + "" + "," + (string)ENUM_PQ_Modes.PQ_Approval + "" + "," + (string)ENUM_PQ_Modes.PQ_EquipmentList + "";
					frmIQApproval mfrmPQApproval = new frmIQApproval(ENUM_IQOQPQ_STATUS.PQ);
					mfrmPQApproval.MdiParent = this;
					mfrmPQApproval.Tag = strTag;
					mfrmPQApproval.Show();
					if (this.tvwIQOQPQ.Height > mfrmPQApproval.Panel1.Height) {
						mfrmPQApproval.Panel1.Height = this.tvwIQOQPQ.Height - 5;
					}
					funcUpdateStatusBar("Performance Qualification :  " + strSelectedItemText);

					subCheckMenuClicked(ENUM_IQOQPQ_STATUS.PQ);
				//--- "PQ Approval"
				case ENUM_PQ_Modes.PQ_Approval:
					strTag = (string)ENUM_OQ_Modes.OQ_Deficiency + "" + "," + (string)ENUM_PQ_Modes.PQ_Approval + "" + "," + (string)ENUM_PQ_Modes.PQ_EquipmentList + "";
					frmIQApproval mfrmPQApproval = new frmIQApproval(ENUM_IQOQPQ_STATUS.PQ);
					mfrmPQApproval.MdiParent = this;
					mfrmPQApproval.Tag = strTag;
					mfrmPQApproval.Show();
					if (this.tvwIQOQPQ.Height > mfrmPQApproval.Panel1.Height) {
						mfrmPQApproval.Panel1.Height = this.tvwIQOQPQ.Height - 5;
					}
					funcUpdateStatusBar("Performance Qualification :  " + strSelectedItemText);

					subCheckMenuClicked(ENUM_IQOQPQ_STATUS.PQ);
				//--- "PQ Equipment Listing"
				case ENUM_PQ_Modes.PQ_EquipmentList:
					strTag = (string)ENUM_PQ_Modes.PQ_Approval + "" + "," + (string)ENUM_PQ_Modes.PQ_EquipmentList + "" + "," + (string)ENUM_PQ_Modes.PQ_Test + "";
					frmOQEquipmentList mfrmPQEquipmentList = new frmOQEquipmentList(ENUM_IQOQPQ_STATUS.PQ);
					mfrmPQEquipmentList.MdiParent = this;
					mfrmPQEquipmentList.Tag = strTag;
					mfrmPQEquipmentList.Show();
					if (this.tvwIQOQPQ.Height > mfrmPQEquipmentList.Panel1.Height) {
						mfrmPQEquipmentList.Panel1.Height = this.tvwIQOQPQ.Height - 5;
					}
					funcUpdateStatusBar("Performance Qualification : " + strSelectedItemText);

					subCheckMenuClicked(ENUM_IQOQPQ_STATUS.PQ);
				//--- "PQ Tests"
				case ENUM_PQ_Modes.PQ_Test:
					strTag = (string)ENUM_PQ_Modes.PQ_EquipmentList + "" + "," + (string)ENUM_PQ_Modes.PQ_Test + "" + "," + (string)ENUM_PQ_Modes.PQ_Attachment1 + "";
					frmPQTest1 mfrmPQTest1 = new frmPQTest1();
					mfrmPQTest1.MdiParent = this;
					mfrmPQTest1.Tag = strTag;
					mfrmPQTest1.Show();
					if (this.tvwIQOQPQ.Height > mfrmPQTest1.Panel1.Height) {
						mfrmPQTest1.Panel1.Height = this.tvwIQOQPQ.Height - 5;
					}

					funcUpdateStatusBar("Performance Qualification : " + strSelectedItemText);

					subCheckMenuClicked(ENUM_IQOQPQ_STATUS.PQ);
				//--- "PQ Attachment1"
				case ENUM_PQ_Modes.PQ_Attachment1:
					strTag = (string)ENUM_PQ_Modes.PQ_Test + "" + "," + (string)ENUM_PQ_Modes.PQ_Attachment1 + "" + "," + (string)ENUM_PQ_Modes.PQ_Attachment2 + "";
					//Dim mfrmPQTest2 As New frmPQTest2      'Saurabh change the object to module level
					mfrmPQTest2 = new frmPQTest2();
					Application.DoEvents();
					mfrmPQTest2.MdiParent = this;
					mfrmPQTest2.Tag = strTag;
					mfrmPQTest2.Show();
					Application.DoEvents();

					if (this.tvwIQOQPQ.Height > mfrmPQTest2.Panel1.Height) {
						mfrmPQTest2.Panel1.Height = this.tvwIQOQPQ.Height - 5;
					}

					funcUpdateStatusBar("Performance Qualification : " + strSelectedItemText);

					subCheckMenuClicked(ENUM_IQOQPQ_STATUS.PQ);
				//--- "PQ Attachment2"
				case ENUM_PQ_Modes.PQ_Attachment2:
					strTag = (string)ENUM_PQ_Modes.PQ_Attachment1 + "" + "," + (string)ENUM_PQ_Modes.PQ_Attachment2 + "" + "," + (string)ENUM_PQ_Modes.PQ_Attachment3 + "";
					//Dim mfrmPQTest3 As New frmPQTest3
					mfrmPQTest3 = new frmPQTest3();
					mfrmPQTest3.MdiParent = this;
					mfrmPQTest3.Tag = strTag;
					mfrmPQTest3.Show();
					if (this.tvwIQOQPQ.Height > mfrmPQTest3.Panel1.Height) {
						mfrmPQTest3.Panel1.Height = this.tvwIQOQPQ.Height - 5;
					}
					funcUpdateStatusBar("Performance Qualification : " + strSelectedItemText);

					subCheckMenuClicked(ENUM_IQOQPQ_STATUS.PQ);
				//--- "PQ Attachment3"
				case ENUM_PQ_Modes.PQ_Attachment3:
					strTag = (string)ENUM_PQ_Modes.PQ_Attachment2 + "" + "," + (string)ENUM_PQ_Modes.PQ_Attachment3 + "" + "," + (string)ENUM_PQ_Modes.PQ_Deficiency + "";
					//Dim mfrmPQTest4 As New frmPQTest4
					mfrmPQTest4 = new frmPQTest4();
					mfrmPQTest4.MdiParent = this;
					mfrmPQTest4.Tag = strTag;
					mfrmPQTest4.Show();
					if (this.tvwIQOQPQ.Height > mfrmPQTest4.Panel1.Height) {
						mfrmPQTest4.Panel1.Height = this.tvwIQOQPQ.Height - 5;
					}
					funcUpdateStatusBar("Performance Qualification : " + strSelectedItemText);

					subCheckMenuClicked(ENUM_IQOQPQ_STATUS.PQ);
				//--- "PQ Attachment4"
				//Case ENUM_PQ_Modes.PQ_Attachment4
				//    strTag = CStr(ENUM_PQ_Modes.PQ_Attachment3 & "") + "," + CStr(ENUM_PQ_Modes.PQ_Attachment4 & "") + "," + CStr(ENUM_PQ_Modes.PQ_Attachment5 & "")
				//    Dim mfrmPQTest5 As New frmPQTest5
				//    mfrmPQTest5.MdiParent = Me
				//    mfrmPQTest5.Tag = strTag
				//    mfrmPQTest5.Show()
				//    If Me.tvwIQOQPQ.Height > mfrmPQTest5.Panel1.Height Then
				//        mfrmPQTest5.Panel1.Height = Me.tvwIQOQPQ.Height - 5
				//    End If

				//    funcUpdateStatusBar("Performance Qualification : " + strSelectedItemText)
				//    subCheckMenuClicked(ENUM_IQOQPQ_STATUS.PQ)

				//    '--- "PQ Attachment5"
				//Case ENUM_PQ_Modes.PQ_Attachment5
				//    strTag = CStr(ENUM_PQ_Modes.PQ_Attachment4 & "") + "," + CStr(ENUM_PQ_Modes.PQ_Attachment5 & "") + "," + CStr(ENUM_PQ_Modes.PQ_Deficiency & "")
				//    Dim mfrmPQTest6 As New frmPQTest6
				//    mfrmPQTest6.MdiParent = Me
				//    mfrmPQTest6.Tag = strTag
				//    mfrmPQTest6.Show()
				//    If Me.tvwIQOQPQ.Height > mfrmPQTest6.Panel1.Height Then
				//        mfrmPQTest6.Panel1.Height = Me.tvwIQOQPQ.Height - 5
				//    End If
				//    funcUpdateStatusBar("Performance Qualification : " + strSelectedItemText)
				//    subCheckMenuClicked(ENUM_IQOQPQ_STATUS.PQ)

				//    '--- "PQ Attachment6"
				//Case ENUM_PQ_Modes.PQ_Attachment6
				//    strTag = CStr(ENUM_PQ_Modes.PQ_Attachment5 & "") + "," + CStr(ENUM_PQ_Modes.PQ_Attachment6 & "") + "," + CStr(ENUM_PQ_Modes.PQ_Attachment7 & "")
				//    Dim mfrmPQTest7 As New frmPQTest7
				//    mfrmPQTest7.MdiParent = Me
				//    mfrmPQTest7.Tag = strTag
				//    mfrmPQTest7.Show()
				//    If Me.tvwIQOQPQ.Height > mfrmPQTest7.Panel1.Height Then
				//        mfrmPQTest7.Panel1.Height = Me.tvwIQOQPQ.Height - 5
				//    End If
				//    funcUpdateStatusBar("Performance Qualification : " + strSelectedItemText)
				//    subCheckMenuClicked(ENUM_IQOQPQ_STATUS.PQ)

				//    '--- "PQ Attachment7"
				//Case ENUM_PQ_Modes.PQ_Attachment7
				//    strTag = CStr(ENUM_PQ_Modes.PQ_Attachment6 & "") + "," + CStr(ENUM_PQ_Modes.PQ_Attachment7 & "") + "," + CStr(ENUM_PQ_Modes.PQ_Attachment8 & "")
				//    Dim mfrmPQTest8 As New frmPQTest8
				//    mfrmPQTest8.MdiParent = Me
				//    mfrmPQTest8.Tag = strTag
				//    mfrmPQTest8.Show()
				//    If Me.tvwIQOQPQ.Height > mfrmPQTest8.Panel1.Height Then
				//        mfrmPQTest8.Panel1.Height = Me.tvwIQOQPQ.Height - 5
				//    End If
				//    funcUpdateStatusBar("Performance Qualification : " + strSelectedItemText)
				//    subCheckMenuClicked(ENUM_IQOQPQ_STATUS.PQ)

				//    '--- "PQ Attachment8"
				//Case ENUM_PQ_Modes.PQ_Attachment8
				//    strTag = CStr(ENUM_PQ_Modes.PQ_Attachment7 & "") + "," + CStr(ENUM_PQ_Modes.PQ_Attachment8 & "") + "," + CStr(ENUM_PQ_Modes.PQ_Attachment9 & "")
				//    Dim mfrmPQTest9 As New frmPQTest9
				//    mfrmPQTest9.MdiParent = Me
				//    mfrmPQTest9.Tag = strTag
				//    mfrmPQTest9.Show()
				//    If Me.tvwIQOQPQ.Height > mfrmPQTest9.Panel1.Height Then
				//        mfrmPQTest9.Panel1.Height = Me.tvwIQOQPQ.Height - 5
				//    End If
				//    funcUpdateStatusBar("Performance Qualification : " + strSelectedItemText)
				//    subCheckMenuClicked(ENUM_IQOQPQ_STATUS.PQ)

				//    '--- "PQ Attachment9"
				//Case ENUM_PQ_Modes.PQ_Attachment9
				//    strTag = CStr(ENUM_PQ_Modes.PQ_Attachment8 & "") + "," + CStr(ENUM_PQ_Modes.PQ_Attachment9 & "") + "," + CStr(ENUM_PQ_Modes.PQ_Deficiency & "")
				//    Dim mfrmPQTest10 As New frmPQTest10
				//    mfrmPQTest10.MdiParent = Me
				//    mfrmPQTest10.Tag = strTag
				//    mfrmPQTest10.Show()
				//    If Me.tvwIQOQPQ.Height > mfrmPQTest10.Panel1.Height Then
				//        mfrmPQTest10.Panel1.Height = Me.tvwIQOQPQ.Height - 5
				//    End If
				//    funcUpdateStatusBar("Performance Qualification : " + strSelectedItemText)
				//    subCheckMenuClicked(ENUM_IQOQPQ_STATUS.PQ)

				//    '--- "PQ Deficiency and Corrective Action"
				case ENUM_PQ_Modes.PQ_Deficiency:
					strTag = (string)ENUM_PQ_Modes.PQ_Attachment3 + "" + "," + (string)ENUM_PQ_Modes.PQ_Deficiency + "" + "," + (string)ENUM_PQ_Modes.PQ_Warranty + "";
					frmIQDeficiency mfrmPQDeficiency = new frmIQDeficiency(ENUM_IQOQPQ_STATUS.PQ);
					mfrmPQDeficiency.MdiParent = this;
					mfrmPQDeficiency.Tag = strTag;
					mfrmPQDeficiency.Show();
					if (this.tvwIQOQPQ.Height > mfrmPQDeficiency.Panel1.Height) {
						mfrmPQDeficiency.Panel1.Height = this.tvwIQOQPQ.Height - 5;
					}
					funcUpdateStatusBar("Performance Qualification : " + strSelectedItemText);

					subCheckMenuClicked(ENUM_IQOQPQ_STATUS.PQ);
				//--- "PQ Warranty"
				case ENUM_PQ_Modes.PQ_Warranty:
					strTag = (string)ENUM_PQ_Modes.PQ_Deficiency + "" + "," + (string)ENUM_PQ_Modes.PQ_Warranty + "" + "," + (string)0 + "";
					frmPQWarranty mfrmWarranty = new frmPQWarranty();
					mfrmWarranty.MdiParent = this;
					mfrmWarranty.Tag = strTag;
					mfrmWarranty.Show();
					if (this.tvwIQOQPQ.Height > mfrmWarranty.Panel1.Height) {
						mfrmWarranty.Panel1.Height = this.tvwIQOQPQ.Height - 5;
					}
					funcUpdateStatusBar("Performance Qualification : " + strSelectedItemText);
					subCheckMenuClicked(ENUM_IQOQPQ_STATUS.PQ);
			}
			return true;
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			gobjErrorHandler.ProcessError(ErrorHandler.ErrorHandler.EnumErrorType.Critical, ex);
			return false;
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

	private bool funcShowSameForm(int intTagValue)
	{
		Form frm = new Form();
		try {
			switch (intTagValue) {
				//--- IQ Mode is selected
				//--- "IQ Customer Details" 


				case ENUM_IQ_Modes.IQ_CustomerDetails:
				//mfrmCustDetails.funcSaveCustomerData()
				//--- "IQ Equipment Listing" 
				case ENUM_IQ_Modes.IQ_EquipmentList:
				//mfrmEqLst.dgEquipmentList.CurrentCell() = (New DataGridCell(mfrmEqLst.dgEquipmentList.CurrentRowIndex + 1, 0))
				//mfrmEqLst.funcSaveIQEquipmentListData()

				//--- "IQ Manual Listing" 
				case ENUM_IQ_Modes.IQ_ManualList:
				//mfrmManualLst.dgManualList.CurrentCell() = New DataGridCell(mfrmManualLst.dgManualList.CurrentRowIndex + 1, 0)
				//mfrmManualLst.funcSaveIQManualListData()
				//--- "IQ Approval" 
				case ENUM_IQ_Modes.IQ_Approval:
				//mfrmIQApproval.dgCustomer.CurrentCell() = (New DataGridCell(mfrmIQApproval.dgCustomer.CurrentRowIndex + 1, 0))
				//mfrmIQApproval.funcSaveCustomerData()
				//mfrmIQApproval.funcSaveSupplierData()

				//--- "IQ Instrument & Accessories Specification"
				case ENUM_IQ_Modes.IQ_Specifications:
				//mfrmSpecification.dgSpecification.CurrentCell() = (New DataGridCell(mfrmSpecification.dgSpecification.CurrentRowIndex + 1, 0))
				//mfrmSpecification.funcSaveIQSpecificationData()
				//mfrmSpecification.dgAccessory.CurrentCell() = (New DataGridCell(mfrmSpecification.dgAccessory.CurrentRowIndex + 1, 0))
				//mfrmSpecification.funcSaveIQAccessoryData()

				//--- "IQ Tests"
				case ENUM_IQ_Modes.IQ_Tests:
				//mfrmTest.dgTest.CurrentCell() = (New DataGridCell(mfrmTest.dgTest.CurrentRowIndex + 1, 0))
				//mfrmTest.funcSaveIQTestData()
				//--- "IQ Deficiencies & Corrective Action Plan"
				case ENUM_IQ_Modes.IQ_Deficiency:
				//mfrmIQDeficiency.dgCompletedAccepted.CurrentCell() = (New DataGridCell(mfrmIQDeficiency.dgCompletedAccepted.CurrentRowIndex + 1, 0))
				//mfrmIQDeficiency.funcSaveCompleteAcceptData()
				//mfrmIQDeficiency.dgDeficiency.CurrentCell() = (New DataGridCell(mfrmIQDeficiency.dgDeficiency.CurrentRowIndex + 1, 0))
				//mfrmIQDeficiency.funcSaveDeficiencyData()
				//--- OQ Mode is selected
				//--- "OQ Approval"

				case ENUM_OQ_Modes.OQ_Approval:
				//mfrmOQApproval.funcSaveSupplierData()
				//mfrmOQApproval.dgCustomer.CurrentCell() = (New DataGridCell(mfrmOQApproval.dgCustomer.CurrentRowIndex + 1, 0))
				//mfrmOQApproval.funcSaveCustomerData()

				//--- "OQ Equipment List"
				case ENUM_OQ_Modes.OQ_EquipmentList:
				//mfrmOQEquipmentList.dgEquipmentList.CurrentCell() = (New DataGridCell(mfrmOQEquipmentList.dgEquipmentList.CurrentRowIndex + 1, 0))
				//mfrmOQEquipmentList.funcSaveEquipmentListData()

				//--- "OQ Test1"
				case ENUM_OQ_Modes.OQ_Test1:
				//mfrmOQTest.dgTest1.CurrentCell() = (New DataGridCell(mfrmOQTest.dgTest1.CurrentRowIndex + 1, 0))
				//mfrmOQTest.funcSaveOQTest1Data(1)
				//mfrmOQTest.dgTest2.CurrentCell() = (New DataGridCell(mfrmOQTest.dgTest2.CurrentRowIndex + 1, 0))
				//mfrmOQTest.funcSaveOQTest1Data(2)
				//mfrmOQTest.dgTest3.CurrentCell() = (New DataGridCell(mfrmOQTest.dgTest3.CurrentRowIndex + 1, 0))
				//mfrmOQTest.funcSaveOQTest1Data(3)

				//--- "OQ Test2"
				case ENUM_OQ_Modes.OQ_Test2:
				//mfrmOQTest2.dgTest1.CurrentCell() = (New DataGridCell(mfrmOQTest2.dgTest1.CurrentRowIndex + 1, 0))
				//mfrmOQTest2.funcSaveOQTest2Data(1)
				//mfrmOQTest2.dgTest2.CurrentCell() = (New DataGridCell(mfrmOQTest2.dgTest2.CurrentRowIndex + 1, 0))
				//mfrmOQTest2.funcSaveOQTest2Data(2)
				//mfrmOQTest2.dgTest3.CurrentCell() = (New DataGridCell(mfrmOQTest2.dgTest3.CurrentRowIndex + 1, 0))
				//mfrmOQTest2.funcSaveOQTest2Data(3)
				//--- "OQ User Training"
				case ENUM_OQ_Modes.OQ_UserTraining:
				//mfrmUserTraining.dgTraining.CurrentCell() = (New DataGridCell(mfrmUserTraining.dgTraining.CurrentRowIndex + 1, 0))
				//mfrmUserTraining.funcSaveOQUserTrainingData()
				//mfrmUserTraining.dgUser.CurrentCell() = (New DataGridCell(mfrmUserTraining.dgUser.CurrentRowIndex + 1, 0))
				//mfrmUserTraining.funcSaveOQUserData()

				//--- "OQ Deficiency & Corrective Action"

				case ENUM_OQ_Modes.OQ_Deficiency:
				//mfrmOQDeficiency.dgDeficiency.CurrentCell() = (New DataGridCell(mfrmOQDeficiency.dgDeficiency.CurrentRowIndex + 1, 0))
				//mfrmOQDeficiency.funcSaveDeficiencyData()
				//mfrmOQDeficiency.dgCompletedAccepted.CurrentCell() = (New DataGridCell(mfrmOQDeficiency.dgCompletedAccepted.CurrentRowIndex + 1, 0))
				//mfrmOQDeficiency.funcSaveCompleteAcceptData()
				//--- PQ Mode is selected 
				//--- "PQ Approval"

				case ENUM_PQ_Modes.PQ_Approval:
				//mfrmPQApproval.dgCustomer.CurrentCell() = (New DataGridCell(mfrmPQApproval.dgCustomer.CurrentRowIndex + 1, 0))
				//mfrmPQApproval.funcSaveCustomerData()
				//mfrmPQApproval.funcSaveSupplierData()

				//--- "PQ Equipment Listing"

				case ENUM_PQ_Modes.PQ_EquipmentList:
				//mfrmPQEquipmentList.dgEquipmentList.CurrentCell() = (New DataGridCell(mfrmPQEquipmentList.dgEquipmentList.CurrentRowIndex + 1, 0))
				//mfrmPQEquipmentList.funcSaveEquipmentListData()

				//--- "PQ Tests"

				case ENUM_PQ_Modes.PQ_Test:
				///mfrmPQTest1.dgTest.CurrentCell() = (New DataGridCell(mfrmPQTest1.dgTest.CurrentRowIndex + 1, 0))
				///mfrmPQTest1.funcSavePQTest1Data()

				//--- "PQ Attachment1"

				case ENUM_PQ_Modes.PQ_Attachment1:
				///mfrmPQTest2.dgTest.CurrentCell() = (New DataGridCell(mfrmPQTest2.dgTest.CurrentRowIndex + 1, 0))
				//mfrmPQTest2.funcSavePQTest2Data()
				//--- "PQ Attachment2"
				case ENUM_PQ_Modes.PQ_Attachment2:
				///mfrmPQTest3.dgTest.CurrentCell() = (New DataGridCell(mfrmPQTest3.dgTest.CurrentRowIndex + 1, 0))
				//mfrmPQTest3.funcSavePQTest3Data()

				//--- "PQ Attachment3"
				case ENUM_PQ_Modes.PQ_Attachment3:
				///mfrmPQTest4.dgTest.CurrentCell() = (New DataGridCell(mfrmPQTest4.dgTest.CurrentRowIndex + 1, 0))
				//mfrmPQTest4.funcSavePQTest4Data()

				//--- "PQ Attachment4"
				//Case ENUM_PQ_Modes.PQ_Attachment4
				//--- "PQ Attachment5"
				//Case ENUM_PQ_Modes.PQ_Attachment5

				///mfrmPQTest6.dgTest.CurrentCell() = (New DataGridCell(mfrmPQTest6.dgTest.CurrentRowIndex + 1, 0))
				//mfrmPQTest6.funcSavePQTest6Data()

				//--- "PQ Deficiency and Corrective Action"

				case ENUM_PQ_Modes.PQ_Deficiency:
				///mfrmPQDeficiency.dgDeficiency.CurrentCell() = (New DataGridCell(mfrmPQDeficiency.dgDeficiency.CurrentRowIndex + 1, 0))
				///mfrmPQDeficiency.funcSaveDeficiencyData()

				//--- "PQ Warranty"
				case ENUM_PQ_Modes.PQ_Warranty:
				///mfrmWarranty.dgCompletedAccepted.CurrentCell() = (New DataGridCell(mfrmWarranty.dgCompletedAccepted.CurrentRowIndex + 1, 0))

				///mfrmWarranty.funcSavePQCompleteAcceptData()

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

	private object funcGetShowNextForm()
	{
		//=====================================================================
		// Procedure Name        :   funcGetShowNextForm
		// Description           :   To Show Next Form.
		// Purpose               :   To Show Next Form.
		// Parameters Passed     :   Name of text to be displayed in Status Bar.
		// Returns               :   None.
		// Parameters Affected   :   None.
		// Assumptions           :
		// Dependencies          :
		// Author                :   
		// Created               :   January , 2003 
		// Revisions             :
		//=====================================================================
		string strFormTag;
		string[] arrTag;
		try {
			tlbtnNext.Enabled = false;
			strFormTag = this.ActiveMdiChild.Tag;
			arrTag = strFormTag.Split(",");
			if (IsDBNull(arrTag(2)) == false) {
				if ((arrTag(2) != (string)0)) {
					funcDisplayChildForm(arrTag(2));
				}
			}
			tlbtnNext.Enabled = true;

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
		// gobjErrorHandler.ProcessError(ErrorHandler.ErrorHandler.EnumErrorType.Critical, ex)
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

	private object funcGetShowPreviousForm()
	{
		//=====================================================================
		// Procedure Name        :   funcGetShowPreviousForm
		// Description           :   To Show Previous Form.
		// Purpose               :   To Show Previous Form.
		// Parameters Passed     :   Name of text to be displayed in Status Bar.
		// Returns               :   None.
		// Parameters Affected   :   None.
		// Assumptions           :
		// Dependencies          :
		// Author                :   
		// Created               :   January , 2003 
		// Revisions             :
		//=====================================================================
		string strFormTag;
		string[] arrTag;
		try {
			tlbtnPrevious.Enabled = false;
			strFormTag = this.ActiveMdiChild.Tag;
			arrTag = strFormTag.Split(",");
			if (IsDBNull(arrTag(0)) == false) {
				if ((arrTag(0) != (string)0)) {
					funcDisplayChildForm(arrTag(0));
				}
			}
			tlbtnPrevious.Enabled = true;

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
		// gobjErrorHandler.ProcessError(ErrorHandler.ErrorHandler.EnumErrorType.Critical, ex)
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

	#Region "Functions Related for Menu/StatusBar "
	private void funcUpdateStatusBar(string str)
	{
		//=====================================================================
		// Procedure Name        :   funcUpdateStatusBar
		// Description           :   To Update Status Bar and displa the Name which is passed to it.
		// Purpose               :   To Update Status Bar and displa the Name which is passed to it.
		// Parameters Passed     :   Name of text to be displayed in Status Bar.
		// Returns               :   None.
		// Parameters Affected   :   None.
		// Assumptions           :
		// Dependencies          :
		// Author                :   Gitesh
		// Created               :   January , 2003 
		// Revisions             :
		//=====================================================================
		try {
			stsdQualification.Text = str;
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
	private void subCheckMenuClicked(int intMode)
	{
		//=====================================================================
		// Procedure Name        :   subCheckMenuClicked
		// Description           :   To Check / Enable Appropriate Menu when Clicked. 
		// Purpose               :   To Check / Enable Appropriate Menu when Clicked.
		// Parameters Passed     :   None.
		// Returns               :   None.
		// Parameters Affected   :   None.
		// Assumptions           :
		// Dependencies          :
		// Author                :   Gitesh
		// Created               :   February, 2004 
		// Revisions             :
		//=====================================================================
		try {
			switch ((intMode)) {
				case ENUM_IQOQPQ_STATUS.IQ:
					mnuIQMode.Checked = true;
					mnuOQMode.Checked = false;
					mnuPQMode.Checked = false;

					mnuIQMode.RadioCheck = true;
					mnuOQMode.RadioCheck = false;
					mnuPQMode.RadioCheck = false;
					break; // TODO: might not be correct. Was : Exit Select

				case ENUM_IQOQPQ_STATUS.OQ:
					mnuIQMode.Checked = false;
					mnuOQMode.Checked = true;
					mnuPQMode.Checked = false;

					mnuIQMode.RadioCheck = false;
					mnuOQMode.RadioCheck = true;
					mnuPQMode.RadioCheck = false;
					break; // TODO: might not be correct. Was : Exit Select

				case ENUM_IQOQPQ_STATUS.PQ:
					mnuIQMode.Checked = false;
					mnuOQMode.Checked = false;
					mnuPQMode.Checked = true;

					mnuIQMode.RadioCheck = false;
					mnuOQMode.RadioCheck = false;
					mnuPQMode.RadioCheck = true;
					break; // TODO: might not be correct. Was : Exit Select

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
	#End Region

	private void funcMakeActiveForm()
	{
		//=====================================================================
		// Procedure Name        :   funcMakeActiveForm
		// Description           :   To Close Previous Forms and make IQOQPQ form Active.
		// Purpose               :   To Close Previous Forms and make IQOQPQ form Active.
		// Parameters Passed     :   Name of text to be displayed in Status Bar.
		// Returns               :   None.
		// Parameters Affected   :   None.
		// Assumptions           :
		// Dependencies          :
		// Author                :   
		// Created               :   January , 2003 
		// Revisions             :
		//=====================================================================

		//---To Close all previous opened child form.
		int intCountForm;
		try {
			Form frmAct = new Form();

			frmAct = this;
			//.ActiveForm()
			Application.DoEvents();
			Form frmobj = new Form();
			foreach ( frmobj in frmAct.MdiChildren) {
				//If Not Me.ActiveMdiChild Is Nothing Then
				//    Me.ActiveMdiChild.Close()
				//    'Me.ActiveMdiChild.Dispose()
				//End If
				frmobj.Close();
				Application.DoEvents();
			}
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			gobjErrorHandler.ProcessError(ErrorHandler.ErrorHandler.EnumErrorType.Critical, ex);
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

	private object funcLockCurrentMode()
	{
		//=====================================================================
		// Procedure Name        :   funcLockCurrentMode
		// Description           :   To Lock the current Mode.
		// Purpose               :   To Lock the current Mode.
		// Parameters Passed     :   None.
		// Returns               :   None.
		// Parameters Affected   :   None.
		// Assumptions           :
		// Dependencies          :
		// Author                :   Gitesh
		// Created               :   February , 2003 
		// Revisions             :
		//=====================================================================
		string strFormTag;
		string strMode;
		string strModeName;
		int intMode;
		string[] arrTag;

		try {
			strFormTag = this.ActiveMdiChild.Tag;
			arrTag = strFormTag.Split(",");
			if (IsDBNull(arrTag(1)) == false) {
				strMode = arrTag(1).Chars(0);
				switch (Val(Trim(strMode) + "")) {
					case ENUM_IQOQPQ_STATUS.IQ:
						intMode = ENUM_IQOQPQ_STATUS.IQ;
						strModeName = "Installation Qualification";
					case ENUM_IQOQPQ_STATUS.OQ:
						intMode = ENUM_IQOQPQ_STATUS.OQ;
						strModeName = "Operational Qualification";
					case ENUM_IQOQPQ_STATUS.PQ:
						intMode = ENUM_IQOQPQ_STATUS.PQ;
						strModeName = "Performance Qualification";
					default:
						intMode = 0;
						strModeName = "";
						throw new Exception("Selected Mode is of Unrecognised Format");
				}
			}

			if (gobjMessageAdapter.ShowMessage("Do you really want to lock " + strModeName + "? " + vbCrLf + vbCrLf + "Note: Once the mode is locked, it will not be editable.", "Lock Mode", MessageHandler.clsMessageHandler.enumMessageType.QuestionMessage) == true) {
				if (!(gobjDataAccess.funcUpdateModeLockStatus(intMode))) {
					//gfuncShowMessage("Error", "Error in locking current mode status.", EnumMessageType.Information)
					gobjMessageAdapter.ShowMessage(constErrorLockingModeStatus);
				} else {
					gobjMessageAdapter.ShowMessage(strModeName + " mode has been locked permanently.", "Locking Result", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage);
				}
			}
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			gobjErrorHandler.ProcessError(ErrorHandler.ErrorHandler.EnumErrorType.Critical, ex);
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

	private void subExportFiles(bool blnFlag)
	{
		Stream objStream;
		SaveFileDialog objIQOQPQ = new SaveFileDialog();
		try {
			objIQOQPQ.InitialDirectory = strPath.GetCurrentDirectory.ToString + "\\IQOQPQ";
			objIQOQPQ.Filter = "Text Files(*.rtf)|*.rtf";
			objIQOQPQ.RestoreDirectory = true;

			if (objIQOQPQ.ShowDialog() == DialogResult.OK) {
				//Call gfuncPrintExportIQOQPQ(tvwIQOQPQ.SelectedNode.Tag, blnFlag, True, objIQOQPQ.FileName)
				gfuncExportAll(objIQOQPQ.FileName);
			}

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
		// gobjErrorHandler.ProcessError(ErrorHandler.ErrorHandler.EnumErrorType.Critical, ex)
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

	private object funcDisplayOnStatusbar(Point ptButtonIn)
	{
		try {
			//Comparing with mouse Coordinate for
			//Displaying Message
			if (ptButtonIn.X > tlbrIQOQPQ.Buttons(enumToolBarButtons.tlbtnLock).Rectangle.Left & ptButtonIn.X < tlbrIQOQPQ.Buttons(enumToolBarButtons.tlbtnLock).Rectangle.Right) {
				StatusBarPanel1.Text = "Lock : To lock the current qualification";
			} else if (ptButtonIn.X > tlbrIQOQPQ.Buttons(enumToolBarButtons.tlbtnNext).Rectangle.Left & ptButtonIn.X < tlbrIQOQPQ.Buttons(enumToolBarButtons.tlbtnNext).Rectangle.Right) {
				StatusBarPanel1.Text = "Next : To display next form ";
			} else if (ptButtonIn.X > tlbrIQOQPQ.Buttons(enumToolBarButtons.tlbtnExit).Rectangle.Left & ptButtonIn.X < tlbrIQOQPQ.Buttons(enumToolBarButtons.tlbtnExit).Rectangle.Right) {
				StatusBarPanel1.Text = "Exit: Return to Main Screen";
			} else if (ptButtonIn.X > tlbrIQOQPQ.Buttons(enumToolBarButtons.tlbtnPrevious).Rectangle.Left & ptButtonIn.X < tlbrIQOQPQ.Buttons(enumToolBarButtons.tlbtnPrevious).Rectangle.Right) {
				StatusBarPanel1.Text = "Previous : To display previous form";
			} else if (ptButtonIn.X > tlbrIQOQPQ.Buttons(enumToolBarButtons.tlbrPrint).Rectangle.Left & ptButtonIn.X < tlbrIQOQPQ.Buttons(enumToolBarButtons.tlbrPrint).Rectangle.Right) {
				StatusBarPanel1.Text = "Print : To print the selected form";
			} else if (ptButtonIn.X > tlbrIQOQPQ.Buttons(enumToolBarButtons.tlbrExport).Rectangle.Left & ptButtonIn.X < tlbrIQOQPQ.Buttons(enumToolBarButtons.tlbrExport).Rectangle.Right) {
				StatusBarPanel1.Text = "Export : To export the all the forms";
			} else if (ptButtonIn.X > tlbrIQOQPQ.Buttons(enumToolBarButtons.tlbrPrintAll).Rectangle.Left & ptButtonIn.X < tlbrIQOQPQ.Buttons(enumToolBarButtons.tlbrPrintAll).Rectangle.Right) {
				StatusBarPanel1.Text = "PrintAll : To print all the forms simultaneously";
			} else {
				StatusBarPanel1.Text = "";
			}

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
		// gobjErrorHandler.ProcessError(ErrorHandler.ErrorHandler.EnumErrorType.Critical, ex)
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



	private void  // ERROR: Handles clauses are not supported in C#
mnuFile_Click(System.Object sender, System.EventArgs e)
	{
	}

	//Private Sub mfrmPQTest(ByRef lblTestStatus As System.Windows.Forms.Label) Handles mfrmPQTest2.Return2IQOQPQ
	//    Try
	//        MsgBox("Saurabh")
	//        RaiseEvent Test_IQOQPQ_Attachment1(lblTestStatus)   ', dtParameters)  

	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        'Error Handling and logging
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = ex.Message
	//        gobjErrorHandler.WriteErrorLog(ex)
	//        '---------------------------------------------------------
	//    Finally
	//        '---------------------------------------------------------
	//        'Writing Execution log
	//        If CONST_CREATE_EXECUTION_LOG = 1 Then
	//            gobjErrorHandler.WriteExecutionLog()
	//        End If
	//        'objWait.Dispose()
	//        '---------------------------------------------------------
	//    End Try
	//End Sub

	private void  // ERROR: Handles clauses are not supported in C#
mfrmPQTest2_Test_IQOQPQ_Attachment1(ref DataTable dtParameters, int intCounter)
	{

		try {
			if (Test_IQOQPQ_Attachment1 != null) {
				Test_IQOQPQ_Attachment1(dtParameters, intCounter);
			}
			//, dtParameters)  

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

	private void  // ERROR: Handles clauses are not supported in C#
mfrmPQTest3_Test_IQOQPQ_AttachmentII(ref DataTable dtParameters, int intCounter)
	{

		try {
			if (Test_IQOQPQ_AttachmentII != null) {
				Test_IQOQPQ_AttachmentII(dtParameters, intCounter);
			}
			//, dtParameters)  

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

	private void  // ERROR: Handles clauses are not supported in C#
mfrmPQTest4_Test_IQOQPQ_AttachmentIII(ref DataTable dtParameters, int intCounter)
	{

		try {
			if (Test_IQOQPQ_AttachmentIII != null) {
				Test_IQOQPQ_AttachmentIII(dtParameters, intCounter);
			}
			//, dtParameters)  

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

	private void  // ERROR: Handles clauses are not supported in C#
frmMDI_Closed(object sender, System.EventArgs e)
	{
		//code added by ; dinesh wagh on 5.4.2010
		//purpose : to save all data if we directly close the mdi form
		//------------------------------------------
		try {
			subCloseAllChildForm();
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

	private void subCloseAllChildForm()
	{
		//SubProcedure added by ; dinesh wagh on 8.4.2010
		//Purpose : To close all the form.
		try {
			Form frmAct = new Form();
			frmAct = this;
			Application.DoEvents();
			Form frmobj = new Form();
			foreach ( frmobj in frmAct.MdiChildren) {
				frmobj.Close();
				Application.DoEvents();
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
