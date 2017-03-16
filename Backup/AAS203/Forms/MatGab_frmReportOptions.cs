using AAS203.Common;
using AAS203Library.Method;

public class frmReportOptions : System.Windows.Forms.Form
{

	#Region " Windows Form Designer generated code "

	public frmReportOptions()
	{
		base.New();

		//This call is required by the Windows Form Designer.
		InitializeComponent();

		//Add any initialization after the InitializeComponent() call

	}

	public frmReportOptions(int intMethodMode, bool blnIsDataFilesMode, int intSelectedMethodID, int intSelectedRunNumber)
	{
		base.New();

		//This call is required by the Windows Form Designer.
		InitializeComponent();

		//Add any initialization after the InitializeComponent() call
		OpenMethodMode = intMethodMode;
		mblnIsDataFilesMode = blnIsDataFilesMode;
		mintSelectedRunNumber = intSelectedRunNumber;
		mintSelectedMethodID = intSelectedMethodID;

	}

	public frmReportOptions(int intMethodMode, bool blnIsDataFilesMode, int intSelectedMethodID, int intSelectedRunNumber, clsMethod objClsMethod)
	{
		base.New();

		//This call is required by the Windows Form Designer.
		InitializeComponent();

		//Add any initialization after the InitializeComponent() call
		OpenMethodMode = intMethodMode;
		mblnIsDataFilesMode = blnIsDataFilesMode;
		mintSelectedRunNumber = intSelectedRunNumber;
		mintSelectedMethodID = intSelectedMethodID;
		mobjClsMethod = new clsMethod();
		mobjClsMethod = objClsMethod;

	}

	//Public Sub New(ByVal intFlag As Integer)
	//    MyBase.New()

	//    'This call is required by the Windows Form Designer.
	//    InitializeComponent()

	//    'Add any initialization after the InitializeComponent() call
	//    mintFlag = intFlag

	//End Sub

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
	internal CodeIntellects.Office2003Controls.Office2003Header Office2003Header1;
	internal GradientPanel.CustomPanel CustomPanel1;
	internal System.Windows.Forms.GroupBox GroupBox1;
	internal System.Windows.Forms.GroupBox GroupBox2;
	internal NETXP.Controls.XPButton btnHelp;
	internal NETXP.Controls.XPButton btnOk;
	internal NETXP.Controls.XPButton btnCancel;
	internal System.Windows.Forms.TextBox txtReportFooter;
	internal System.Windows.Forms.TextBox txtReportHeader;
	internal System.Windows.Forms.Label lblReportFooter1;
	internal System.Windows.Forms.Label lblReportHeader1;
	internal System.Windows.Forms.CheckBox cbReportHeader;
	internal System.Windows.Forms.CheckBox cbInstrumentCondition;
	internal System.Windows.Forms.CheckBox cbAnalysisParameters;
	internal System.Windows.Forms.CheckBox cbMethodInfo;
	internal System.Windows.Forms.CheckBox cbStandards;
	internal System.Windows.Forms.CheckBox cbAbsorbance;
	internal System.Windows.Forms.CheckBox cbWeightVolumeDilution;
	internal System.Windows.Forms.Label lblHeading;
	[System.Diagnostics.DebuggerStepThrough()]
	private void InitializeComponent()
	{
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmReportOptions));
		this.Office2003Header1 = new CodeIntellects.Office2003Controls.Office2003Header();
		this.CustomPanel1 = new GradientPanel.CustomPanel();
		this.GroupBox2 = new System.Windows.Forms.GroupBox();
		this.txtReportFooter = new System.Windows.Forms.TextBox();
		this.txtReportHeader = new System.Windows.Forms.TextBox();
		this.lblReportFooter1 = new System.Windows.Forms.Label();
		this.lblReportHeader1 = new System.Windows.Forms.Label();
		this.GroupBox1 = new System.Windows.Forms.GroupBox();
		this.cbReportHeader = new System.Windows.Forms.CheckBox();
		this.cbInstrumentCondition = new System.Windows.Forms.CheckBox();
		this.cbAnalysisParameters = new System.Windows.Forms.CheckBox();
		this.cbMethodInfo = new System.Windows.Forms.CheckBox();
		this.cbStandards = new System.Windows.Forms.CheckBox();
		this.cbAbsorbance = new System.Windows.Forms.CheckBox();
		this.cbWeightVolumeDilution = new System.Windows.Forms.CheckBox();
		this.lblHeading = new System.Windows.Forms.Label();
		this.btnCancel = new NETXP.Controls.XPButton();
		this.btnOk = new NETXP.Controls.XPButton();
		this.btnHelp = new NETXP.Controls.XPButton();
		this.CustomPanel1.SuspendLayout();
		this.GroupBox2.SuspendLayout();
		this.GroupBox1.SuspendLayout();
		this.SuspendLayout();
		//
		//Office2003Header1
		//
		this.Office2003Header1.BackColor = System.Drawing.SystemColors.Control;
		this.Office2003Header1.Dock = System.Windows.Forms.DockStyle.Top;
		this.Office2003Header1.Location = new System.Drawing.Point(0, 0);
		this.Office2003Header1.Name = "Office2003Header1";
		this.Office2003Header1.Size = new System.Drawing.Size(404, 22);
		this.Office2003Header1.TabIndex = 0;
		this.Office2003Header1.TitleFont = new System.Drawing.Font("Tahoma", 10f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.Office2003Header1.TitleText = "Report Options";
		//
		//CustomPanel1
		//
		this.CustomPanel1.BackColor = System.Drawing.Color.Transparent;
		this.CustomPanel1.Controls.Add(this.GroupBox2);
		this.CustomPanel1.Controls.Add(this.GroupBox1);
		this.CustomPanel1.Controls.Add(this.btnCancel);
		this.CustomPanel1.Controls.Add(this.btnOk);
		this.CustomPanel1.Controls.Add(this.btnHelp);
		this.CustomPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.CustomPanel1.Location = new System.Drawing.Point(0, 22);
		this.CustomPanel1.Name = "CustomPanel1";
		this.CustomPanel1.Size = new System.Drawing.Size(404, 375);
		this.CustomPanel1.TabIndex = 1;
		//
		//GroupBox2
		//
		this.GroupBox2.Controls.Add(this.txtReportFooter);
		this.GroupBox2.Controls.Add(this.txtReportHeader);
		this.GroupBox2.Controls.Add(this.lblReportFooter1);
		this.GroupBox2.Controls.Add(this.lblReportHeader1);
		this.GroupBox2.Location = new System.Drawing.Point(8, 174);
		this.GroupBox2.Name = "GroupBox2";
		this.GroupBox2.Size = new System.Drawing.Size(390, 146);
		this.GroupBox2.TabIndex = 1;
		this.GroupBox2.TabStop = false;
		//
		//txtReportFooter
		//
		this.txtReportFooter.Enabled = false;
		this.txtReportFooter.Location = new System.Drawing.Point(8, 88);
		this.txtReportFooter.MaxLength = 45;
		this.txtReportFooter.Multiline = true;
		this.txtReportFooter.Name = "txtReportFooter";
		this.txtReportFooter.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
		this.txtReportFooter.Size = new System.Drawing.Size(374, 48);
		this.txtReportFooter.TabIndex = 9;
		this.txtReportFooter.Text = "";
		//
		//txtReportHeader
		//
		this.txtReportHeader.Enabled = false;
		this.txtReportHeader.Location = new System.Drawing.Point(8, 25);
		this.txtReportHeader.MaxLength = 40;
		this.txtReportHeader.Multiline = true;
		this.txtReportHeader.Name = "txtReportHeader";
		this.txtReportHeader.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
		this.txtReportHeader.Size = new System.Drawing.Size(374, 43);
		this.txtReportHeader.TabIndex = 8;
		this.txtReportHeader.Text = "";
		//
		//lblReportFooter1
		//
		this.lblReportFooter1.Location = new System.Drawing.Point(8, 74);
		this.lblReportFooter1.Name = "lblReportFooter1";
		this.lblReportFooter1.Size = new System.Drawing.Size(100, 16);
		this.lblReportFooter1.TabIndex = 1;
		this.lblReportFooter1.Text = "Report Footer";
		//
		//lblReportHeader1
		//
		this.lblReportHeader1.Location = new System.Drawing.Point(8, 10);
		this.lblReportHeader1.Name = "lblReportHeader1";
		this.lblReportHeader1.Size = new System.Drawing.Size(100, 14);
		this.lblReportHeader1.TabIndex = 0;
		this.lblReportHeader1.Text = "Report Header";
		//
		//GroupBox1
		//
		this.GroupBox1.BackColor = System.Drawing.Color.Transparent;
		this.GroupBox1.Controls.Add(this.cbReportHeader);
		this.GroupBox1.Controls.Add(this.cbInstrumentCondition);
		this.GroupBox1.Controls.Add(this.cbAnalysisParameters);
		this.GroupBox1.Controls.Add(this.cbMethodInfo);
		this.GroupBox1.Controls.Add(this.cbStandards);
		this.GroupBox1.Controls.Add(this.cbAbsorbance);
		this.GroupBox1.Controls.Add(this.cbWeightVolumeDilution);
		this.GroupBox1.Controls.Add(this.lblHeading);
		this.GroupBox1.Location = new System.Drawing.Point(8, 4);
		this.GroupBox1.Name = "GroupBox1";
		this.GroupBox1.Size = new System.Drawing.Size(390, 164);
		this.GroupBox1.TabIndex = 0;
		this.GroupBox1.TabStop = false;
		//
		//cbReportHeader
		//
		this.cbReportHeader.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.cbReportHeader.Location = new System.Drawing.Point(200, 70);
		this.cbReportHeader.Name = "cbReportHeader";
		this.cbReportHeader.Size = new System.Drawing.Size(176, 20);
		this.cbReportHeader.TabIndex = 6;
		this.cbReportHeader.Text = "&Report Header and Footer";
		//
		//cbInstrumentCondition
		//
		this.cbInstrumentCondition.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.cbInstrumentCondition.Location = new System.Drawing.Point(200, 39);
		this.cbInstrumentCondition.Name = "cbInstrumentCondition";
		this.cbInstrumentCondition.Size = new System.Drawing.Size(176, 20);
		this.cbInstrumentCondition.TabIndex = 5;
		this.cbInstrumentCondition.Text = "&Instrument Condition";
		//
		//cbAnalysisParameters
		//
		this.cbAnalysisParameters.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.cbAnalysisParameters.Location = new System.Drawing.Point(200, 100);
		this.cbAnalysisParameters.Name = "cbAnalysisParameters";
		this.cbAnalysisParameters.Size = new System.Drawing.Size(176, 20);
		this.cbAnalysisParameters.TabIndex = 7;
		this.cbAnalysisParameters.Text = "Analysis &Parameters";
		//
		//cbMethodInfo
		//
		this.cbMethodInfo.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.cbMethodInfo.Location = new System.Drawing.Point(18, 132);
		this.cbMethodInfo.Name = "cbMethodInfo";
		this.cbMethodInfo.Size = new System.Drawing.Size(160, 20);
		this.cbMethodInfo.TabIndex = 4;
		this.cbMethodInfo.Text = "&Method Info";
		//
		//cbStandards
		//
		this.cbStandards.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.cbStandards.Location = new System.Drawing.Point(18, 101);
		this.cbStandards.Name = "cbStandards";
		this.cbStandards.Size = new System.Drawing.Size(160, 20);
		this.cbStandards.TabIndex = 3;
		this.cbStandards.Text = "&Standards";
		//
		//cbAbsorbance
		//
		this.cbAbsorbance.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.cbAbsorbance.Location = new System.Drawing.Point(18, 70);
		this.cbAbsorbance.Name = "cbAbsorbance";
		this.cbAbsorbance.Size = new System.Drawing.Size(160, 20);
		this.cbAbsorbance.TabIndex = 2;
		this.cbAbsorbance.Text = "&Absorbance";
		//
		//cbWeightVolumeDilution
		//
		this.cbWeightVolumeDilution.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.cbWeightVolumeDilution.Location = new System.Drawing.Point(18, 39);
		this.cbWeightVolumeDilution.Name = "cbWeightVolumeDilution";
		this.cbWeightVolumeDilution.Size = new System.Drawing.Size(160, 20);
		this.cbWeightVolumeDilution.TabIndex = 1;
		this.cbWeightVolumeDilution.Text = "&Weight-Volume Dilution";
		//
		//lblHeading
		//
		this.lblHeading.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblHeading.Location = new System.Drawing.Point(8, 10);
		this.lblHeading.Name = "lblHeading";
		this.lblHeading.Size = new System.Drawing.Size(424, 14);
		this.lblHeading.TabIndex = 0;
		this.lblHeading.Text = "Please check the column names which are to be included on the report.";
		//
		//btnCancel
		//
		this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnCancel.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnCancel.Image = (System.Drawing.Image)resources.GetObject("btnCancel.Image");
		this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnCancel.Location = new System.Drawing.Point(216, 328);
		this.btnCancel.Name = "btnCancel";
		this.btnCancel.Size = new System.Drawing.Size(86, 34);
		this.btnCancel.TabIndex = 17;
		this.btnCancel.Text = "&Cancel";
		//
		//btnOk
		//
		this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
		this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnOk.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnOk.Image = (System.Drawing.Image)resources.GetObject("btnOk.Image");
		this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnOk.Location = new System.Drawing.Point(96, 328);
		this.btnOk.Name = "btnOk";
		this.btnOk.Size = new System.Drawing.Size(86, 34);
		this.btnOk.TabIndex = 16;
		this.btnOk.Text = "&OK";
		//
		//btnHelp
		//
		this.btnHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnHelp.Image = (System.Drawing.Image)resources.GetObject("btnHelp.Image");
		this.btnHelp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnHelp.Location = new System.Drawing.Point(6, 330);
		this.btnHelp.Name = "btnHelp";
		this.btnHelp.Size = new System.Drawing.Size(86, 34);
		this.btnHelp.TabIndex = 18;
		this.btnHelp.Text = "&Help";
		this.btnHelp.Visible = false;
		//
		//frmReportOptions
		//
		this.AcceptButton = this.btnOk;
		this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
		this.BackColor = System.Drawing.Color.AliceBlue;
		this.CancelButton = this.btnCancel;
		this.ClientSize = new System.Drawing.Size(404, 397);
		this.ControlBox = false;
		this.Controls.Add(this.CustomPanel1);
		this.Controls.Add(this.Office2003Header1);
		this.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		this.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		this.MaximizeBox = false;
		this.MinimizeBox = false;
		this.Name = "frmReportOptions";
		this.ShowInTaskbar = false;
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Method";
		this.CustomPanel1.ResumeLayout(false);
		this.GroupBox2.ResumeLayout(false);
		this.GroupBox1.ResumeLayout(false);
		this.ResumeLayout(false);

	}

	#End Region

	#Region " Class Member Variables "

	private EnumMethodMode mintOpenMethodMode;
	private int mintRunNumberIndex;
	private bool mblnIsDataFilesMode = false;
	private int mintSelectedMethodID;
	private int mintSelectedRunNumber;
	private clsMethod mobjClsMethod;
	public event  ReportOptionsChanged;

	#End Region

	#Region " Private Constants"
	private const  ConstDefaultFooter = "Note: All Standard Concentrations are in ppm";
	private const  ConstParentFormMethod = "-Method";
	private const  ConstParentFormDataFiles = "-DataFiles";
	private const  ConstFormLoadMethod = "-Method-Report Options";

	private const  ConstFormLoadDataFiles = "-DataFiles-Report Options";
	#End Region

	#Region " Private Properties "

	private EnumMethodMode OpenMethodMode {
		get { return mintOpenMethodMode; }
		set { mintOpenMethodMode = Value; }
	}

	#End Region

	#Region " Form Events "

	private void  // ERROR: Handles clauses are not supported in C#
frmReportOptions_Load(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : frmReportOptions_Load
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To initialize and load the form
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : 05.10.06
		// Revisions             : 2
		// Revision By           : Mangesh S. on 28-Jan-2007
		// Revision for          : Changes in AAS203Library
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		int intCounter;

		try {
			if (mblnIsDataFilesMode == false) {
				gobjMain.ShowProgressBar(gstrTitleInstrumentType + ConstFormLoadMethod);
			} else {
				gobjMain.ShowProgressBar(gstrTitleInstrumentType + ConstFormLoadDataFiles);
			}

			SubAddHandlers();
			//'for adding a event to a control.


			if (mblnIsDataFilesMode == false) {
				//'get a method mode.
				if (!gobjNewMethod.ReportParameters == null) {
					OpenMethodMode = modGlobalConstants.EnumMethodMode.EditMode;
				} else {
					OpenMethodMode = modGlobalConstants.EnumMethodMode.NewMode;
					gobjNewMethod.ReportParameters = new clsReportParameters();
				}
			}

			//---to display initial report options on loading
			funcShowReportOptions();
			//Saurabh 10.07.07 To bring status form in front
			if (!IsInIQOQPQ) {
				gobjfrmStatus.Show();
			}
		//Saurabh


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
			gobjMain.HideProgressBar();
			//---------------------------------------------------------
		}
	}

	private void  // ERROR: Handles clauses are not supported in C#
frmReportOptions_Closing(object sender, System.ComponentModel.CancelEventArgs e)
	{
		//=====================================================================
		// Procedure Name        : frmReportOptions_Closing
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : this will handle a closing event of form.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : 05.10.06
		// Revisions             : 2
		// Revision By           : Mangesh S. on 28-Jan-2007
		// Revision for          : Changes in AAS203Library
		//=====================================================================
		try {
			if (mblnIsDataFilesMode == false) {
				//show status bar message
				gobjMain.ShowRunTimeInfo(gstrTitleInstrumentType + ConstParentFormMethod);
			} else {
				gobjMain.ShowRunTimeInfo(gstrTitleInstrumentType + ConstParentFormDataFiles);
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

	#End Region

	#Region " Private Functions "

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
		// Author                : Deepak Bhati
		// Created               : 05.10.06
		// Revisions             : 
		//=====================================================================
		try {
			//add event handler to buttons
			btnCancel.Click += btnCancel_Click;
			btnOk.Click += btnOk_Click;
			cbReportHeader.CheckedChanged += cbReportHeader_CheckedChanged;
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

	private void btnCancel_Click(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : btnCancel_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To close the form
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : 05.10.06
		// Revisions             : 
		//=====================================================================
		try {
			if (OpenMethodMode == modGlobalConstants.EnumMethodMode.NewMode) {
				gobjNewMethod.ReportParameters = null;
			}
			//Me.Close()
			this.DialogResult = DialogResult.Cancel;
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

	private void btnOk_Click(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : btnOk_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To send dialog result as ok
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak, Saurabh
		// Created               : 05.10.06
		// Revisions             : 
		//=====================================================================
		//'note:
		//'this is called when user click on OK button
		//'this first get all the current status from screen
		//'selected by user
		//'then store it in a method collection. 
		CWaitCursor objWait = new CWaitCursor();
		bool blnWeightVolumeDilution;
		bool blnAbsorbance;
		bool blnStandards;
		bool blnMethodInfo;
		bool blnAnalysisParameters;
		bool blnInstrumentCondition;
		bool blnReportHeader;
		bool blnReportFooter;
		bool blnDisplayReportDate;
		bool blnDisplayCompanyLogo;
		double dblLeftMargin;
		double dblTopMargin;
		double dblBottomMargin;
		string strReportHeader;
		string strReportFooter;
		int intCount;
		int intRunNumberIndex;
		try {
			//update temporary data structure
			if (cbWeightVolumeDilution.Checked == true) {
				blnWeightVolumeDilution = true;
			//'check for dilution
			} else {
				blnWeightVolumeDilution = false;
			}

			if (cbAbsorbance.Checked == true) {
				blnAbsorbance = true;
			//'check for abs
			} else {
				blnAbsorbance = false;
			}

			if (cbStandards.Checked == true) {
				blnStandards = true;
			} else {
				blnStandards = false;
			}

			if (cbMethodInfo.Checked == true) {
				blnMethodInfo = true;
			} else {
				blnMethodInfo = false;
			}

			if (cbAnalysisParameters.Checked == true) {
				blnAnalysisParameters = true;
			} else {
				blnAnalysisParameters = false;
			}

			if (cbInstrumentCondition.Checked == true) {
				blnInstrumentCondition = true;
			} else {
				blnInstrumentCondition = false;
			}

			if (cbReportHeader.Checked == true) {
				blnReportHeader = true;
				blnReportFooter = true;
			} else {
				blnReportHeader = false;
				blnReportFooter = false;
			}
			strReportHeader = Trim(txtReportHeader.Text);
			strReportFooter = Trim(txtReportFooter.Text);

			if (mblnIsDataFilesMode == false) {
				//---to save report options to object variables
				if (!gobjNewMethod.ReportParameters == null) {
					gobjNewMethod.ReportParameters.IsAbsorbance = blnAbsorbance;
					gobjNewMethod.ReportParameters.IsAnalysisParameters = blnAnalysisParameters;
					gobjNewMethod.ReportParameters.IsInstrumentCondition = blnInstrumentCondition;
					gobjNewMethod.ReportParameters.IsMethodInfo = blnMethodInfo;
					gobjNewMethod.ReportParameters.IsReportHeaderAndFooter = blnReportHeader;
					gobjNewMethod.ReportParameters.IsStandards = blnStandards;
					gobjNewMethod.ReportParameters.IsWeightVolumeDilution = blnWeightVolumeDilution;
					gobjNewMethod.ReportParameters.ReportFooter = strReportFooter;
					gobjNewMethod.ReportParameters.ReportHeader = strReportHeader;
				}

				//---update current method to method collection and save all methods
				for (intCount = gobjMethodCollection.Count - 1; intCount >= 0; intCount += -1) {
					if (gobjMethodCollection.item(intCount).MethodID == gobjNewMethod.MethodID) {
						gobjMethodCollection.item(intCount).ReportParameters = gobjNewMethod.ReportParameters.Clone;
						gobjMethodCollection.item(intCount).DateOfModification = DateTime.Now;
						funcSaveAllMethods(gobjMethodCollection);
						//'for saving a method collection.
						break; // TODO: might not be correct. Was : Exit For
					}
				}

			} else {
				//---Update Current Method in Method Collection
				for (intCount = 0; intCount <= gobjMethodCollection.Count - 1; intCount++) {

					if (gobjMethodCollection.item(intCount).MethodID == mintSelectedMethodID) {
						//--------12.04.09   4.85
						//'gobjMethodCollection.item(intCount).ReportParameters.IsAbsorbance = blnAbsorbance
						//'gobjMethodCollection.item(intCount).ReportParameters.IsAnalysisParameters = blnAnalysisParameters
						//'gobjMethodCollection.item(intCount).ReportParameters.IsInstrumentCondition = blnInstrumentCondition
						//'gobjMethodCollection.item(intCount).ReportParameters.IsMethodInfo = blnMethodInfo
						//'gobjMethodCollection.item(intCount).ReportParameters.IsReportHeaderAndFooter = blnReportHeader
						//'gobjMethodCollection.item(intCount).ReportParameters.IsStandards = blnStandards
						//'gobjMethodCollection.item(intCount).ReportParameters.IsWeightVolumeDilution = blnWeightVolumeDilution
						//'gobjMethodCollection.item(intCount).ReportParameters.ReportFooter = strReportFooter
						//'gobjMethodCollection.item(intCount).ReportParameters.ReportHeader = strReportHeader

						//'mobjClsMethod = gobjMethodCollection.item(intCount).Clone() 'Added By Pankaj  on 31 May 07
						//--------12.04.09   4.85


						//--------12.04.09   4.85
						int intSelectedRunNumberIndex;
						intSelectedRunNumberIndex = gfuncGetSelectedMethodRunNumberIndex(mintSelectedMethodID, mintSelectedRunNumber);

						gobjMethodCollection.item(intCount).QuantitativeDataCollection.Item(intSelectedRunNumberIndex).ReportParameters.IsAbsorbance = blnAbsorbance;
						gobjMethodCollection.item(intCount).QuantitativeDataCollection.Item(intSelectedRunNumberIndex).ReportParameters.IsAnalysisParameters = blnAnalysisParameters;
						gobjMethodCollection.item(intCount).QuantitativeDataCollection.Item(intSelectedRunNumberIndex).ReportParameters.IsInstrumentCondition = blnInstrumentCondition;
						gobjMethodCollection.item(intCount).QuantitativeDataCollection.Item(intSelectedRunNumberIndex).ReportParameters.IsMethodInfo = blnMethodInfo;
						gobjMethodCollection.item(intCount).QuantitativeDataCollection.Item(intSelectedRunNumberIndex).ReportParameters.IsReportHeaderAndFooter = blnReportHeader;
						gobjMethodCollection.item(intCount).QuantitativeDataCollection.Item(intSelectedRunNumberIndex).ReportParameters.IsStandards = blnStandards;
						gobjMethodCollection.item(intCount).QuantitativeDataCollection.Item(intSelectedRunNumberIndex).ReportParameters.IsWeightVolumeDilution = blnWeightVolumeDilution;
						gobjMethodCollection.item(intCount).QuantitativeDataCollection.Item(intSelectedRunNumberIndex).ReportParameters.ReportFooter = strReportFooter;
						gobjMethodCollection.item(intCount).QuantitativeDataCollection.Item(intSelectedRunNumberIndex).ReportParameters.ReportHeader = strReportHeader;

						//mobjClsMethod = gobjMethodCollection.item(intCount).Clone() 'Added By Pankaj  on 31 May 07
						//--------12.04.09   4.85

						//--------12.04.09   4.85
						if (ReportOptionsChanged != null) {
							ReportOptionsChanged(gobjMethodCollection.item(intCount).QuantitativeDataCollection.Item(intSelectedRunNumberIndex).ReportParameters);
						}
						//----
					}
				}

				//---save all methods
				funcSaveAllMethods(gobjMethodCollection);
			}

			this.DialogResult = DialogResult.OK;

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

	private void cbReportHeader_CheckedChanged(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : cbReportHeader_CheckedChanged
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To enable or disable Report Header
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 05.10.06
		// Revisions             :  
		//=====================================================================
		try {
			if (cbReportHeader.Checked == true) {
				txtReportHeader.Enabled = true;
				txtReportFooter.Enabled = true;
			} else {
				txtReportHeader.Enabled = false;
				txtReportFooter.Enabled = false;
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

	private bool funcShowReportOptions()
	{
		//=====================================================================
		// Procedure Name        : funcShowReportOptions
		// Parameters Passed     : None
		// Returns               : True or False
		// Purpose               : To display report options
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak B.
		// Created               : 09.10.06
		// Revisions             : 2
		// Revision By           : Mangesh S. on 28-Jan-2007
		// Revision for          : Changes in AAS203Library
		//=====================================================================
		try {
			//---display selected method report options on form
			if (mblnIsDataFilesMode == false) {
				if (OpenMethodMode == modGlobalConstants.EnumMethodMode.EditMode) {
					cbWeightVolumeDilution.Checked = gobjNewMethod.ReportParameters.IsWeightVolumeDilution;
					cbAnalysisParameters.Checked = gobjNewMethod.ReportParameters.IsAnalysisParameters;
					cbAbsorbance.Checked = gobjNewMethod.ReportParameters.IsAbsorbance;
					cbStandards.Checked = gobjNewMethod.ReportParameters.IsStandards;
					cbMethodInfo.Checked = gobjNewMethod.ReportParameters.IsMethodInfo;
					cbInstrumentCondition.Checked = gobjNewMethod.ReportParameters.IsInstrumentCondition;
					cbReportHeader.Checked = gobjNewMethod.ReportParameters.IsReportHeaderAndFooter;
					txtReportHeader.Text = gobjNewMethod.ReportParameters.ReportHeader;
					txtReportFooter.Text = gobjNewMethod.ReportParameters.ReportFooter;
				} else {
					//---display default report options
					cbWeightVolumeDilution.Checked = true;
					cbAnalysisParameters.Checked = true;
					cbAbsorbance.Checked = true;
					cbStandards.Checked = true;
					cbMethodInfo.Checked = false;
					cbInstrumentCondition.Checked = true;
					cbReportHeader.Checked = false;
					txtReportFooter.Text = ConstDefaultFooter;
				}
			} else {
				//---display report options selected method in datafile
				//-----4.85  12.04.09
				//'cbWeightVolumeDilution.Checked = mobjClsMethod.ReportParameters.IsWeightVolumeDilution
				//'cbAnalysisParameters.Checked = mobjClsMethod.ReportParameters.IsAnalysisParameters
				//'cbAbsorbance.Checked = mobjClsMethod.ReportParameters.IsAbsorbance
				//'cbStandards.Checked = mobjClsMethod.ReportParameters.IsStandards
				//'cbMethodInfo.Checked = mobjClsMethod.ReportParameters.IsMethodInfo
				//'cbInstrumentCondition.Checked = mobjClsMethod.ReportParameters.IsInstrumentCondition
				//'cbReportHeader.Checked = mobjClsMethod.ReportParameters.IsReportHeaderAndFooter
				//'txtReportHeader.Text = mobjClsMethod.ReportParameters.ReportHeader
				//'txtReportFooter.Text = mobjClsMethod.ReportParameters.ReportFooter
				//-----4.85  12.04.09

				//-----4.85  12.04.09
				int intSelectedRunNumberIndex;
				intSelectedRunNumberIndex = gfuncGetSelectedMethodRunNumberIndex(mintSelectedMethodID, mintSelectedRunNumber);

				cbWeightVolumeDilution.Checked = mobjClsMethod.QuantitativeDataCollection.Item(intSelectedRunNumberIndex).ReportParameters.IsWeightVolumeDilution;
				cbAnalysisParameters.Checked = mobjClsMethod.QuantitativeDataCollection.Item(intSelectedRunNumberIndex).ReportParameters.IsAnalysisParameters;
				cbAbsorbance.Checked = mobjClsMethod.QuantitativeDataCollection.Item(intSelectedRunNumberIndex).ReportParameters.IsAbsorbance;
				cbStandards.Checked = mobjClsMethod.QuantitativeDataCollection.Item(intSelectedRunNumberIndex).ReportParameters.IsStandards;
				cbMethodInfo.Checked = mobjClsMethod.QuantitativeDataCollection.Item(intSelectedRunNumberIndex).ReportParameters.IsMethodInfo;
				cbInstrumentCondition.Checked = mobjClsMethod.QuantitativeDataCollection.Item(intSelectedRunNumberIndex).ReportParameters.IsInstrumentCondition;
				cbReportHeader.Checked = mobjClsMethod.QuantitativeDataCollection.Item(intSelectedRunNumberIndex).ReportParameters.IsReportHeaderAndFooter;
				txtReportHeader.Text = mobjClsMethod.QuantitativeDataCollection.Item(intSelectedRunNumberIndex).ReportParameters.ReportHeader;
				txtReportFooter.Text = mobjClsMethod.QuantitativeDataCollection.Item(intSelectedRunNumberIndex).ReportParameters.ReportFooter;
				//-----4.85  12.04.09

			}
			if (!gobjNewMethod == null) {
				if (gobjNewMethod.OperationMode == EnumOperationMode.MODE_EMMISSION) {
					cbAbsorbance.Text = "Emission";
				}
			}

			return true;

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
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

	#End Region

}

