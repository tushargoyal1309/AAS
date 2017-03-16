using AAS203.Common;
using AAS203Library.Method;


public class frmStandardConcentration : System.Windows.Forms.Form
{


	#Region " Windows Form Designer generated code "

	public frmStandardConcentration()
	{
		base.New();

		//This call is required by the Windows Form Designer.
		InitializeComponent();

		//Add any initialization after the InitializeComponent() call

	}


	public frmStandardConcentration(int intIQOQtest)
	{
		//constructor overloaded by ; dinesh wagh on 2.2.2010

		base.New();

		//This call is required by the Windows Form Designer.
		InitializeComponent();

		//Add any initialization after the InitializeComponent() call

		mintIQOQPQtest = intIQOQtest;


	}

	//Public Sub New(ByVal intMethodMode As Integer)
	//    MyBase.New()

	//    'This call is required by the Windows Form Designer.
	//    InitializeComponent()

	//    'Add any initialization after the InitializeComponent() call
	//    OpenMethodMode = intMethodMode

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
	internal GradientPanel.CustomPanel CustomPanelMain;
	internal GradientPanel.CustomPanel CustomPanelBottom;
	internal GradientPanel.CustomPanel CustomPanelBottomTop;
	internal NETXP.Controls.XPButton btnHelp;
	internal NETXP.Controls.XPButton btnOk;
	internal NETXP.Controls.XPButton btnCancel;
	internal CodeIntellects.Office2003Controls.Office2003Header Office2003Header1;
	internal System.Windows.Forms.DataGrid dgStdConcentration;
	internal GradientPanel.CustomPanel CustomPanelTop;
	internal System.Windows.Forms.Label lblImpNotes;
	internal System.Windows.Forms.Label lblNote1;
	internal System.Windows.Forms.Label lblNote2;
	internal System.Windows.Forms.Label lblNote3;
	internal NETXP.Controls.XPButton btnAddNew;
	internal NETXP.Controls.XPButton btnChangeTiming;
	[System.Diagnostics.DebuggerStepThrough()]
	private void InitializeComponent()
	{
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmStandardConcentration));
		this.CustomPanelMain = new GradientPanel.CustomPanel();
		this.CustomPanelTop = new GradientPanel.CustomPanel();
		this.dgStdConcentration = new System.Windows.Forms.DataGrid();
		this.CustomPanelBottom = new GradientPanel.CustomPanel();
		this.btnChangeTiming = new NETXP.Controls.XPButton();
		this.CustomPanelBottomTop = new GradientPanel.CustomPanel();
		this.lblNote3 = new System.Windows.Forms.Label();
		this.lblNote2 = new System.Windows.Forms.Label();
		this.lblNote1 = new System.Windows.Forms.Label();
		this.lblImpNotes = new System.Windows.Forms.Label();
		this.btnOk = new NETXP.Controls.XPButton();
		this.btnCancel = new NETXP.Controls.XPButton();
		this.btnAddNew = new NETXP.Controls.XPButton();
		this.btnHelp = new NETXP.Controls.XPButton();
		this.Office2003Header1 = new CodeIntellects.Office2003Controls.Office2003Header();
		this.CustomPanelMain.SuspendLayout();
		this.CustomPanelTop.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.dgStdConcentration).BeginInit();
		this.CustomPanelBottom.SuspendLayout();
		this.CustomPanelBottomTop.SuspendLayout();
		this.SuspendLayout();
		//
		//CustomPanelMain
		//
		this.CustomPanelMain.BackColor = System.Drawing.Color.AliceBlue;
		this.CustomPanelMain.BackColor2 = System.Drawing.Color.AliceBlue;
		this.CustomPanelMain.Controls.Add(this.CustomPanelTop);
		this.CustomPanelMain.Controls.Add(this.CustomPanelBottom);
		this.CustomPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
		this.CustomPanelMain.Location = new System.Drawing.Point(0, 22);
		this.CustomPanelMain.Name = "CustomPanelMain";
		this.CustomPanelMain.Size = new System.Drawing.Size(404, 329);
		this.CustomPanelMain.TabIndex = 12;
		//
		//CustomPanelTop
		//
		this.CustomPanelTop.BackColor = System.Drawing.Color.Transparent;
		this.CustomPanelTop.BackColor2 = System.Drawing.Color.Transparent;
		this.CustomPanelTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.CustomPanelTop.Controls.Add(this.dgStdConcentration);
		this.CustomPanelTop.Dock = System.Windows.Forms.DockStyle.Fill;
		this.CustomPanelTop.Location = new System.Drawing.Point(0, 0);
		this.CustomPanelTop.Name = "CustomPanelTop";
		this.CustomPanelTop.Size = new System.Drawing.Size(404, 153);
		this.CustomPanelTop.TabIndex = 0;
		//
		//dgStdConcentration
		//
		this.dgStdConcentration.CaptionVisible = false;
		this.dgStdConcentration.DataMember = "";
		this.dgStdConcentration.HeaderForeColor = System.Drawing.SystemColors.ControlText;
		this.dgStdConcentration.Location = new System.Drawing.Point(16, 16);
		this.dgStdConcentration.Name = "dgStdConcentration";
		this.dgStdConcentration.Size = new System.Drawing.Size(376, 110);
		this.dgStdConcentration.TabIndex = 0;
		//
		//CustomPanelBottom
		//
		this.CustomPanelBottom.BackColor = System.Drawing.Color.Transparent;
		this.CustomPanelBottom.BackColor2 = System.Drawing.Color.Transparent;
		this.CustomPanelBottom.Controls.Add(this.btnChangeTiming);
		this.CustomPanelBottom.Controls.Add(this.CustomPanelBottomTop);
		this.CustomPanelBottom.Controls.Add(this.btnOk);
		this.CustomPanelBottom.Controls.Add(this.btnCancel);
		this.CustomPanelBottom.Controls.Add(this.btnAddNew);
		this.CustomPanelBottom.Controls.Add(this.btnHelp);
		this.CustomPanelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
		this.CustomPanelBottom.Location = new System.Drawing.Point(0, 153);
		this.CustomPanelBottom.Name = "CustomPanelBottom";
		this.CustomPanelBottom.Size = new System.Drawing.Size(404, 176);
		this.CustomPanelBottom.TabIndex = 8;
		//
		//btnChangeTiming
		//
		this.btnChangeTiming.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnChangeTiming.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnChangeTiming.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnChangeTiming.Location = new System.Drawing.Point(72, 128);
		this.btnChangeTiming.Name = "btnChangeTiming";
		this.btnChangeTiming.Size = new System.Drawing.Size(96, 32);
		this.btnChangeTiming.TabIndex = 11;
		this.btnChangeTiming.Text = "&Change Timing";
		//
		//CustomPanelBottomTop
		//
		this.CustomPanelBottomTop.BackColor = System.Drawing.Color.Transparent;
		this.CustomPanelBottomTop.BackColor2 = System.Drawing.Color.Transparent;
		this.CustomPanelBottomTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.CustomPanelBottomTop.Controls.Add(this.lblNote3);
		this.CustomPanelBottomTop.Controls.Add(this.lblNote2);
		this.CustomPanelBottomTop.Controls.Add(this.lblNote1);
		this.CustomPanelBottomTop.Controls.Add(this.lblImpNotes);
		this.CustomPanelBottomTop.Location = new System.Drawing.Point(0, 8);
		this.CustomPanelBottomTop.Name = "CustomPanelBottomTop";
		this.CustomPanelBottomTop.Size = new System.Drawing.Size(374, 112);
		this.CustomPanelBottomTop.TabIndex = 9;
		//
		//lblNote3
		//
		this.lblNote3.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblNote3.Location = new System.Drawing.Point(6, 82);
		this.lblNote3.Name = "lblNote3";
		this.lblNote3.Size = new System.Drawing.Size(344, 16);
		this.lblNote3.TabIndex = 3;
		this.lblNote3.Text = "3. Please enter different standard names";
		//
		//lblNote2
		//
		this.lblNote2.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblNote2.Location = new System.Drawing.Point(6, 57);
		this.lblNote2.Name = "lblNote2";
		this.lblNote2.Size = new System.Drawing.Size(344, 16);
		this.lblNote2.TabIndex = 2;
		this.lblNote2.Text = "2. Please enter the standards in increasing order only ";
		//
		//lblNote1
		//
		this.lblNote1.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblNote1.Location = new System.Drawing.Point(7, 32);
		this.lblNote1.Name = "lblNote1";
		this.lblNote1.Size = new System.Drawing.Size(360, 16);
		this.lblNote1.TabIndex = 1;
		this.lblNote1.Text = "1. In Standard Addition Method, first standard must be 0.0 conc.";
		//
		//lblImpNotes
		//
		this.lblImpNotes.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblImpNotes.Location = new System.Drawing.Point(8, 8);
		this.lblImpNotes.Name = "lblImpNotes";
		this.lblImpNotes.Size = new System.Drawing.Size(344, 16);
		this.lblImpNotes.TabIndex = 0;
		this.lblImpNotes.Text = "Important Notes :";
		//
		//btnOk
		//
		this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnOk.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnOk.Image = (System.Drawing.Image)resources.GetObject("btnOk.Image");
		this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnOk.Location = new System.Drawing.Point(176, 128);
		this.btnOk.Name = "btnOk";
		this.btnOk.Size = new System.Drawing.Size(86, 34);
		this.btnOk.TabIndex = 1;
		this.btnOk.Text = "&OK";
		//
		//btnCancel
		//
		this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnCancel.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnCancel.Image = (System.Drawing.Image)resources.GetObject("btnCancel.Image");
		this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnCancel.Location = new System.Drawing.Point(272, 128);
		this.btnCancel.Name = "btnCancel";
		this.btnCancel.Size = new System.Drawing.Size(86, 34);
		this.btnCancel.TabIndex = 2;
		this.btnCancel.Text = "&Cancel";
		//
		//btnAddNew
		//
		this.btnAddNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnAddNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnAddNew.Location = new System.Drawing.Point(221, 4);
		this.btnAddNew.Name = "btnAddNew";
		this.btnAddNew.Size = new System.Drawing.Size(136, 24);
		this.btnAddNew.TabIndex = 0;
		this.btnAddNew.Text = "Click to add Standard";
		this.btnAddNew.Visible = false;
		//
		//btnHelp
		//
		this.btnHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnHelp.Image = (System.Drawing.Image)resources.GetObject("btnHelp.Image");
		this.btnHelp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnHelp.Location = new System.Drawing.Point(272, 144);
		this.btnHelp.Name = "btnHelp";
		this.btnHelp.Size = new System.Drawing.Size(86, 34);
		this.btnHelp.TabIndex = 4;
		this.btnHelp.Text = "Help";
		this.btnHelp.Visible = false;
		//
		//Office2003Header1
		//
		this.Office2003Header1.BackColor = System.Drawing.SystemColors.Control;
		this.Office2003Header1.Dock = System.Windows.Forms.DockStyle.Top;
		this.Office2003Header1.Location = new System.Drawing.Point(0, 0);
		this.Office2003Header1.Name = "Office2003Header1";
		this.Office2003Header1.Size = new System.Drawing.Size(404, 22);
		this.Office2003Header1.TabIndex = 13;
		this.Office2003Header1.TitleFont = new System.Drawing.Font("Tahoma", 10f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.Office2003Header1.TitleText = "Standard Concentration";
		//
		//frmStandardConcentration
		//
		this.AcceptButton = this.btnOk;
		this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
		this.CancelButton = this.btnCancel;
		this.ClientSize = new System.Drawing.Size(404, 351);
		this.ControlBox = false;
		this.Controls.Add(this.CustomPanelMain);
		this.Controls.Add(this.Office2003Header1);
		this.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		this.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		this.MaximizeBox = false;
		this.MinimizeBox = false;
		this.Name = "frmStandardConcentration";
		this.ShowInTaskbar = false;
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Method ";
		this.TopMost = true;
		this.CustomPanelMain.ResumeLayout(false);
		this.CustomPanelTop.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.dgStdConcentration).EndInit();
		this.CustomPanelBottom.ResumeLayout(false);
		this.CustomPanelBottomTop.ResumeLayout(false);
		this.ResumeLayout(false);

	}

	#End Region

	#Region " Private Member Variables "

	private DataTable mobjDtStandards;

	private DataGridClass mobjDtStandardsDataGrid = new DataGridClass(ConstDataGridPropertiesFileName);
	private int mintMethodMode;
	private int mintRunNumberIndex;
	int intGridRowNo = 0;

	private bool mblnIsCancel = false;
		//added by ;dinesh wagh on 2.2.2010
	private int mintIQOQPQtest;


	#End Region

	#Region " Private Properties "

	//Private Property OpenMethodMode() As EnumMethodMode
	//    Get
	//        Return mintMethodMode
	//    End Get
	//    Set(ByVal Value As EnumMethodMode)
	//        mintMethodMode = Value
	//    End Set
	//End Property

	#End Region

	#Region " Private Constants "
	private const  ConstNumberOfCharactersInSampleNameColum = 10;
	private const  ConstColumnSrNo = "SrNo";
	private const  ConstColumnStandardName = "StandardName";
	private const  ConstColumnSamplerPos = "Sampler Pos";
	private const  ConstColumnConcentration = "Concentration";
	private const  ConstColumnRemove = "Remove";
	private const  ConstTitleSrNo = "Sr.No.";
	private const  ConstTitleStandardName = "Standard Name";
	private const  ConstTitleConcentration = "Concentrations";
	private const  ConstTitleRemove = "Remove";
	private const  ConstWidthSrNo = 55;
	private const  ConstWidthStandardName = 135;
	private const  ConstWidthConcentration = 135;
	private const  ConstParentFormLoad = "-Method";
	private const  ConstFormLoad = "-Method-Standard Concentration";
	//Private Const ConstWidthRemove = 58

	#End Region

	#Region " Form Events "

	private void  // ERROR: Handles clauses are not supported in C#
frmStandardConcentration_Load(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : frmStandardConcentration_Load
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

		//'note:
		//'this is is called when std concentration form is loaded 
		//'this is used to initialization of from

		CWaitCursor objWait = new CWaitCursor();
		int intCounter;
		DataRow objRow;
		int intCount;

		try {
			gobjMain.ShowProgressBar(gstrTitleInstrumentType + ConstFormLoad);
			//'show the current ststus of instrument on progressbar
			SubAddHandlers();
			//'add all the event 
			mobjDtStandards = new DataTable();

			//'this is code for grid control
			//'grid control is used for displaying a std name , contration etc on screen 
			//'in well fromated manner 
			mobjDtStandards.Columns.Add(ConstColumnSrNo, typeof(int));
			mobjDtStandards.Columns.Add(ConstColumnStandardName, typeof(string));
			mobjDtStandards.Columns.Add(ConstColumnConcentration, typeof(string));

			mobjDtStandards.Columns(ConstColumnConcentration).DefaultValue = DBNull.Value;

			mobjDtStandardsDataGrid.AllowNew = false;
			mobjDtStandardsDataGrid.AdjustColumnWidthToGrid = false;

			//by pankaj for autosampler
			if ((gstructAutoSampler.blnAutoSamplerInitialised == true)) {
				//'this is for auto sampler
				//'do  initialisation if auto sampler is present

				mobjDtStandardsDataGrid.AddDataGridColumnStyle(mobjDtStandards.Columns(ConstColumnSrNo).ColumnName, dgStdConcentration, mobjDtStandards, DataGridClass.enumColumnType.TextBoxColumn, HorizontalAlignment.Center, ConstTitleSrNo, ConstWidthSrNo, true, DataGridClass.ColumnDataType.Text, HorizontalAlignment.Center);
				mobjDtStandardsDataGrid.AddDataGridColumnStyle(mobjDtStandards.Columns(ConstColumnStandardName).ColumnName, dgStdConcentration, mobjDtStandards, DataGridClass.enumColumnType.TextBoxColumn, HorizontalAlignment.Center, ConstTitleStandardName, ConstWidthSrNo + ConstWidthSrNo, false, DataGridClass.ColumnDataType.Text, HorizontalAlignment.Left,
				ConstNumberOfCharactersInSampleNameColum, true, false);
				mobjDtStandardsDataGrid.AddDataGridColumnStyle(mobjDtStandards.Columns(ConstColumnConcentration).ColumnName, dgStdConcentration, mobjDtStandards, DataGridClass.enumColumnType.TextBoxColumn, HorizontalAlignment.Center, ConstTitleConcentration, ConstWidthSrNo + ConstWidthSrNo, false, DataGridClass.ColumnDataType.Text, HorizontalAlignment.Left,
				11, true, true);

				mobjDtStandards.Columns.Add(ConstColumnSamplerPos, typeof(string));
				mobjDtStandards.Columns(ConstColumnSamplerPos).DefaultValue = DBNull.Value;
				mobjDtStandardsDataGrid.AddDataGridColumnStyle(mobjDtStandards.Columns(ConstColumnSamplerPos).ColumnName, dgStdConcentration, mobjDtStandards, DataGridClass.enumColumnType.TextBoxColumn, HorizontalAlignment.Center, ConstColumnSamplerPos, ConstWidthSrNo + ConstWidthSrNo - 30, false, DataGridClass.ColumnDataType.Text, HorizontalAlignment.Left,
				2, true, true);

			} else {
				mobjDtStandardsDataGrid.AddDataGridColumnStyle(mobjDtStandards.Columns(ConstColumnSrNo).ColumnName, dgStdConcentration, mobjDtStandards, DataGridClass.enumColumnType.TextBoxColumn, HorizontalAlignment.Center, ConstTitleSrNo, ConstWidthSrNo, true, DataGridClass.ColumnDataType.Text, HorizontalAlignment.Center);
				mobjDtStandardsDataGrid.AddDataGridColumnStyle(mobjDtStandards.Columns(ConstColumnStandardName).ColumnName, dgStdConcentration, mobjDtStandards, DataGridClass.enumColumnType.TextBoxColumn, HorizontalAlignment.Center, ConstTitleStandardName, ConstWidthStandardName, false, DataGridClass.ColumnDataType.Text, HorizontalAlignment.Left,
				ConstNumberOfCharactersInSampleNameColum, true, false);
				mobjDtStandardsDataGrid.AddDataGridColumnStyle(mobjDtStandards.Columns(ConstColumnConcentration).ColumnName, dgStdConcentration, mobjDtStandards, DataGridClass.enumColumnType.TextBoxColumn, HorizontalAlignment.Center, ConstTitleConcentration, ConstWidthConcentration, false, DataGridClass.ColumnDataType.Text, HorizontalAlignment.Left,
				11, true, true);
				this.dgStdConcentration.Width = this.dgStdConcentration.Width - 30;
			}

			funcLoadInitialData();
			//'this is called to load some initial data.

			mobjDtStandardsDataGrid.SetDataGridProperties(dgStdConcentration, mobjDtStandards);
			//'set a data grid property




			//code commented by ; dinesh wagh on 2.2.2010
			//----------------------------------------------
			//'For intCount = gobjNewMethod.StandardDataCollection.Count + 1 To 15
			//'    Call subAddNewClicked(intCount)
			//'    ''add a data of maximum 15 std
			//'Next
			//------------------------------------------------

			//code added by ;dinesh wagh on 2.2.2010
			//Purpose : There is only one std required.Suggested by ; vck sir.
			//---------------------------------------------------------
			int intTotalStd;
			if (IsInIQOQPQ) {
				switch (mintIQOQPQtest) {
					case EnumIQOQPQtestId.ePQAtt1:
						intTotalStd = 1;
					default:
						intTotalStd = 15;
				}

				//15.2.2010 by dinesh wagh
				//---------------------
				lblNote2.Text = "1. Please enter the standards in increasing order only";
				lblNote3.Text = "2. Please enter different standard names";
				lblNote3.Location = lblNote2.Location;
				lblNote2.Location = lblNote1.Location;
				lblNote1.Visible = false;
			//--------------------------



			} else {
				intTotalStd = 15;
			}

			for (intCount = gobjNewMethod.StandardDataCollection.Count + 1; intCount <= intTotalStd; intCount++) {
				subAddNewClicked(intCount);
			}

			if (IsInIQOQPQ) {
				switch (mintIQOQPQtest) {
					case EnumIQOQPQtestId.ePQAtt1:
						if (mobjDtStandards.Rows.Count > 0) {
							mobjDtStandards.Rows(0).Item(ConstColumnConcentration) = "5";
						}
				}

			}

			//------------------------------------------------------------



			dgStdConcentration.Focus();
			mobjDtStandardsDataGrid.SetDataGridTableStyle.BeginEdit(dgStdConcentration.TableStyles.Item(0).GridColumnStyles(2), 0);
			//'setting grid property
			//Saurabh 10.07.07 To bring status form in front
			if (!IsInIQOQPQ) {
				gobjfrmStatus.Show();
				//'shows the status form
			}
			//Saurabh
			btnChangeTiming.Visible = gstructAutoSampler.blnAutoSamplerInitialised;
			//Added by pankaj for autosampler
		//'validated change timing button as par autosampler
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
frmStandardConcentration_Closing(object sender, System.ComponentModel.CancelEventArgs e)
	{
		//=====================================================================
		// Procedure Name        : frmStandardConcentration_Closing
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : to handle a closing event.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : 05.10.06
		// Revisions             : 2
		// Revision By           : Mangesh S. on 28-Jan-2007
		// Revision for          : Changes in AAS203Library
		//=====================================================================

		//when user close the form 

		if (mblnIsCancel == true) {
			e.Cancel = mblnIsCancel;
			mblnIsCancel = false;
			return;
		}
		gobjMain.ShowRunTimeInfo(gstrTitleInstrumentType + ConstParentFormLoad);
	}

	private void  // ERROR: Handles clauses are not supported in C#
frmStandardConcentration_Activated(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : frmStandardConcentration_Activated
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : to activated a form.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : 05.10.06
		// Revisions             : 2
		// Revision By           : Mangesh S. on 28-Jan-2007
		// Revision for          : Changes in AAS203Library
		//=====================================================================

		dgStdConcentration.Focus();
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
		// Author                : Deepak Bhati
		// Created               : 07.10.06
		// Revisions             : 
		//=====================================================================
		try {
			//'this function is used for adding a event 
			btnCancel.Click += btnCancel_Click;
			btnOk.Click += btnOk_Click;

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
			//'this is called when user click on cancel button
			gobjchkActiveMethod.CancelMethod = true;
			//Added By Pankaj 23 May 07
			mblnIsCancel = false;
			this.DialogResult = DialogResult.Cancel;
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			//---------------------------------------------------------
			mblnIsCancel = false;
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
		// Author                : Deepak Bhati
		// Created               : 05.10.06
		// Revisions             : 
		//=====================================================================
		//'note:
		//'this is called when user click on OK button
		//'in this step1 is to check for validation
		//'step 2 get data enterd by user to temp varible
		//'step3 now check for validation and bound that data to data structure

		//'validation
		//'std name should be unique
		//'check contration range


		CWaitCursor objWait = new CWaitCursor();
		int intCounter;
		double dblConcentration;
		clsAnalysisStdParameters objStandard;
		clsAnalysisStdParametersCollection objStandardCollection;
		bool blnDuplicateFound = false;
		int intCounter1;
		string strStdName;
		bool zeroFlag = false;
		try {
			////-----  Added by Sachin Dokhale
			//Check for dublicate Standard name
			blnDuplicateFound = false;
			for (intCounter = 0; intCounter <= mobjDtStandards.Rows.Count - 1; intCounter++) {
				strStdName = mobjDtStandards.Rows(intCounter).Item(1);
				for (intCounter1 = intCounter + 1; intCounter1 <= mobjDtStandards.Rows.Count - 1; intCounter1++) {
					if (strStdName == mobjDtStandards.Rows(intCounter1).Item(1)) {
						blnDuplicateFound = true;
						break; // TODO: might not be correct. Was : Exit For
					}
				}

				if (blnDuplicateFound == true) {
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			if (blnDuplicateFound == true) {
				mblnIsCancel = true;
				gobjMessageAdapter.ShowMessage("Duplicate standard name", "Standard name", MessageHandler.clsMessageHandler.enumMessageType.WarningMessage);
				Application.DoEvents();
				return;
			}

			//validate entered concentration is numeric or not
			for (intCounter = 0; intCounter <= mobjDtStandards.Rows.Count - 1; intCounter++) {
				if (!gfuncIsDBNull_Ext(mobjDtStandards.Rows(intCounter).Item(ConstColumnConcentration)) == true) {
					if (!IsNumeric(mobjDtStandards.Rows(intCounter).Item(ConstColumnConcentration)) == true) {
						gobjMessageAdapter.ShowMessage("Please enter proper data", "Numeric data required", MessageHandler.clsMessageHandler.enumMessageType.WarningMessage);
						Application.DoEvents();
						return;
					}
				} else {
					//Added by pankaj on 17 Aug 07 for handling null exceptions
					if ((intCounter == 0)) {
						gobjMessageAdapter.ShowMessage("Please enter data for first standard", "Numeric data required", MessageHandler.clsMessageHandler.enumMessageType.WarningMessage);
						Application.DoEvents();
						return;
					}
					//end
				}
			}

			////-----

			//----18.06.07
			//---Validate for First Blank (ZERO) Concentration
			if (intCounter == 0) {
				if (gfuncIsDBNull_Ext(mobjDtStandards.Rows(0).Item(ConstColumnConcentration))) {
					mblnIsCancel = true;
					gobjMessageAdapter.ShowMessage(constEnterStdConc);
					Application.DoEvents();
					return;
				}
			}

			if (!gobjNewMethod.StandardAddition) {
				if (Val(mobjDtStandards.Rows(0).Item(ConstColumnConcentration)) == 0.0) {
					mblnIsCancel = true;
					gobjMessageAdapter.ShowMessage(constFirstZeroStdConc);
					Application.DoEvents();
					return;
				}
			}

			objStandardCollection = new clsAnalysisStdParametersCollection();
			//update objstandard object with standard concentrations values
			for (intCounter = 0; intCounter <= mobjDtStandards.Rows.Count - 1; intCounter++) {
				if (Trim(mobjDtStandards.Rows(intCounter).Item(ConstColumnStandardName)) != "") {
					if ((!gfuncIsDBNull_Ext(mobjDtStandards.Rows(intCounter).Item(ConstColumnConcentration))) & (Convert.ToString(mobjDtStandards.Rows(intCounter).Item(ConstColumnConcentration)) != "")) {
						if (intCounter == 0) {
							objStandard = new clsAnalysisStdParameters();
							objStandard.StdNumber = (int)mobjDtStandards.Rows(intCounter).Item(ConstColumnSrNo);
							objStandard.StdName = (string)mobjDtStandards.Rows(intCounter).Item(ConstColumnStandardName);
							dblConcentration = (double)mobjDtStandards.Rows(intCounter).Item(ConstColumnConcentration);
							//'by Pankaj for autosampler on 10Sep 07
							if ((gstructAutoSampler.blnAutoSamplerInitialised == true)) {
								if (!gfuncIsDBNull_Ext(mobjDtStandards.Rows(intCounter).Item(ConstColumnSamplerPos))) {
									objStandard.PositionNumber = (int)mobjDtStandards.Rows(intCounter).Item(ConstColumnSamplerPos);
								} else {
									objStandard.PositionNumber = 0;
								}
							}
						} else {
							objStandard = new clsAnalysisStdParameters();
							objStandard.StdNumber = (int)mobjDtStandards.Rows(intCounter).Item(ConstColumnSrNo);
							objStandard.StdName = (string)mobjDtStandards.Rows(intCounter).Item(ConstColumnStandardName);
							//by Pankaj for autosampler on 10Sep 07
							if ((gstructAutoSampler.blnAutoSamplerInitialised == true)) {
								if (!gfuncIsDBNull_Ext(mobjDtStandards.Rows(intCounter).Item(ConstColumnSamplerPos))) {
									objStandard.PositionNumber = (int)mobjDtStandards.Rows(intCounter).Item(ConstColumnSamplerPos);
								} else {
									objStandard.PositionNumber = 0;
								}
							}
							//Added by pankaj on 21 Jan 08
							if (zeroFlag == true & (double)mobjDtStandards.Rows(intCounter).Item(ConstColumnConcentration) != 0) {
								gobjMessageAdapter.ShowMessage(constStdsInIncreasingOrder);
								return;
							}
							if ((double)mobjDtStandards.Rows(intCounter).Item(ConstColumnConcentration) == 0) {
								zeroFlag = true;
							}
							//---for ignore zero values
							//--------------To check the increasing order of standards-----------
							if (zeroFlag == false) {
								if (dblConcentration >= (double)mobjDtStandards.Rows(intCounter).Item(ConstColumnConcentration)) {
									mblnIsCancel = true;
									gobjMessageAdapter.ShowMessage(constStdsInIncreasingOrder);
									return;
								}
								dblConcentration = Val(mobjDtStandards.Rows(intCounter).Item(ConstColumnConcentration));
							}
						}

						//by pankaj on 21 Jan 08
						if (zeroFlag == false) {
							objStandard.Concentration = mobjDtStandards.Rows(intCounter).Item(ConstColumnConcentration);
							objStandardCollection.Add(objStandard);
						}

					}
				}
			}
			//------------Added By Pankaj on 11 Jun 07
			for (intCounter = 0; intCounter <= gobjNewMethod.StandardDataCollection.Count - 1; intCounter++) {
				if (gobjNewMethod.StandardDataCollection.Count > intCounter) {
					if (gobjNewMethod.StandardDataCollection.item(intCounter).Used == true) {
						objStandardCollection.item(intCounter).Used = true;
						objStandardCollection.item(intCounter).Abs = gobjNewMethod.StandardDataCollection.item(intCounter).Abs;
					}
				}
			}
			//-----------
			gobjNewMethod.StandardDataCollection.Clear();
			gobjNewMethod.StandardDataCollection = objStandardCollection.Clone();

			//---Update Current Method in Method Collection
			for (intCounter = 0; intCounter <= gobjMethodCollection.Count - 1; intCounter++) {
				if (gobjMethodCollection.item(intCounter).MethodID == gobjNewMethod.MethodID) {
					gobjMethodCollection.item(intCounter).StandardDataCollection = gobjNewMethod.StandardDataCollection.Clone();
					gobjMethodCollection.item(intCounter).DateOfModification = DateTime.Now;
				}
			}

			//---serialize method collection 
			//Added By Pankaj on 23 May 07 for adding method of inactive mode
			gobjchkActiveMethod.fillStdConcentration = true;
			//27.07.07
			if ((gobjchkActiveMethod.fillStdConcentration == true & gobjchkActiveMethod.CancelMethod == true & gobjchkActiveMethod.NewMethod == true)) {
				gobjchkActiveMethod.NewMethod = false;
				gobjchkActiveMethod.CancelMethod = false;
				gobjchkActiveMethod.fillStdConcentration = false;
				gobjNewMethod.Status = true;
				gobjchkActiveMethod.IsMethodAddedToCollectionInDisconnectedMode = true;
				gobjMethodCollection.Add(gobjNewMethod);
			}
			funcSaveAllMethods(gobjMethodCollection);

			//'save method with current value and data 

			this.DialogResult = DialogResult.OK;
			mblnIsCancel = false;
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			//---------------------------------------------------------
			mblnIsCancel = false;
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

	private void subAddNewClicked(int intCount)
	{
		//=====================================================================
		// Procedure Name        : subAddNewClicked
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To add new Standard
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : Monday, December 13, 2004
		// Revisions             : 08.10.06
		//=====================================================================
		DataRow objDrNewRow;

		//'note:
		//'this is used for adding new std 
		//'step 1: check for validation 
		//'step 2: modify data structure for adding new std


		try {
			btnOk.Enabled = true;
			objDrNewRow = mobjDtStandards.NewRow;
			mobjDtStandards.Constraints.Clear();
			objDrNewRow = mobjDtStandards.NewRow;
			objDrNewRow.Item(ConstColumnSrNo) = intCount;
			objDrNewRow.Item(ConstColumnStandardName) = "Std " + intCount;
			objDrNewRow.Item(ConstColumnConcentration) = DBNull.Value;
			//by Pankaj for autosampler on 10Sep 07
			if ((gstructAutoSampler.blnAutoSamplerInitialised == true)) {
				objDrNewRow.Item(ConstColumnSamplerPos) = intCount;
			}
			mobjDtStandards.Rows.Add(objDrNewRow);

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

	private bool funcLoadInitialData()
	{
		//=====================================================================
		// Procedure Name        : funcLoadInitialData
		// Parameters Passed     : None
		// Returns               : True or False
		// Purpose               : To load initial data
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : 08.10.06
		// Revisions             : 2
		// Revision By           : Mangesh S. on 28-Jan-2007
		// Revision for          : Changes in AAS203Library
		//=====================================================================
		int intCounter;
		DataRow objRow;
		//'note:
		//'this called during loading of the form.
		//'this used to load some initial data on screen.
		//'this will load to data from data structure.


		try {
			//18.06.07
			if (!gobjNewMethod.StandardDataCollection == null) {
				for (intCounter = 0; intCounter <= gobjNewMethod.StandardDataCollection.Count - 1; intCounter++) {
					if (!gobjNewMethod.StandardDataCollection.item(intCounter) == null) {
						objRow = mobjDtStandards.NewRow;
						objRow.Item(ConstColumnSrNo) = gobjNewMethod.StandardDataCollection.item(intCounter).StdNumber;
						objRow.Item(ConstColumnStandardName) = gobjNewMethod.StandardDataCollection.item(intCounter).StdName;
						if (gobjNewMethod.StandardDataCollection.item(intCounter).Concentration == 0.0) {
							objRow.Item(ConstColumnConcentration) = FormatNumber(0, 6);
						} else {
							objRow.Item(ConstColumnConcentration) = FormatNumber(gobjNewMethod.StandardDataCollection.item(intCounter).Concentration, 6);
						}
						if ((gstructAutoSampler.blnAutoSamplerInitialised == true)) {
							if ((gobjNewMethod.StandardDataCollection.item(intCounter).PositionNumber == -1)) {
								objRow.Item(ConstColumnSamplerPos) = gobjNewMethod.StandardDataCollection.item(intCounter).StdNumber;
							} else {
								objRow.Item(ConstColumnSamplerPos) = gobjNewMethod.StandardDataCollection.item(intCounter).PositionNumber;
							}
						}
						mobjDtStandards.Rows.Add(objRow);
					}
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

	private void  // ERROR: Handles clauses are not supported in C#
dgStdConcentration_CurrentCellChanged(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : dgStdConcentration_CurrentCellChanged
		// Parameters Passed     : Object, EventArgs
		// Returns               : True or False
		// Purpose               : check validation for new enterd value
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : 08.10.06
		// Revisions             : 2
		// Revision By           : Mangesh S. on 28-Jan-2007
		// Revision for          : Changes in AAS203Library
		//=====================================================================
		//'note:
		//'this called when user change or edit a current cell
		//'check validation for new enterd value
		//'if validated then accept it and modify the data structure

		try {
			if ((dgStdConcentration.CurrentCell.ColumnNumber == 2)) {
				//If Not IsDBNull(dgStdConcentration.Item(intGridRowNo, 2)) Then
				if (!gfuncIsDBNull_Ext(dgStdConcentration.Item(intGridRowNo, 2))) {
					if (Convert.ToString(dgStdConcentration.Item(intGridRowNo, 2)) == "") {
						dgStdConcentration.Item(intGridRowNo, 2) = DBNull.Value;
					} else if (!IsNumeric(dgStdConcentration.Item(intGridRowNo, 2))) {
						dgStdConcentration.Item(intGridRowNo, 2) = DBNull.Value;
					}
				}
			}
			intGridRowNo = dgStdConcentration.CurrentRowIndex;

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
dgStdConcentration_LostFocus(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : dgStdConcentration_LostFocus
		// Parameters Passed     : Object, EventArgs
		// Returns               : True or False
		// Purpose               : for handle a LostFocus Event.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : 08.10.06
		// Revisions             : 2
		// Revision By           : Mangesh S. on 28-Jan-2007
		// Revision for          : Changes in AAS203Library
		//=====================================================================
		//validate entered value of current cell
		dgStdConcentration_CurrentCellChanged(sender, e);
	}

	private void  // ERROR: Handles clauses are not supported in C#
btnChangeTiming_Click(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : btnChangeTiming_Click
		// Parameters Passed     : Object, EventArgs
		// Returns               : True or False
		// Purpose               : show change timing form
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : 08.10.06
		// Revisions             : 2
		// Revision By           : Mangesh S. on 28-Jan-2007
		// Revision for          : Changes in AAS203Library
		//=====================================================================
		//'note:
		//'this is called when user clicked on change timing button
		//'this will set a autosampler flag 
		//'and show change timing form.

		try {
			if ((gstructAutoSampler.blnCommunication == true)) {
				frmTimings objfrmtimings = new frmTimings();
				objfrmtimings.ShowDialog();
				//'show a dialog.
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

}
