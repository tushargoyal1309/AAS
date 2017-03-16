using AAS203.Common;
using AAS203Library.Method;
//'this is like headers file
//'class behind the form
public class frmSampleParameters : System.Windows.Forms.Form
{

	#Region " Windows Form Designer generated code "

	public frmSampleParameters()
	{
		base.New();

		//This call is required by the Windows Form Designer.
		InitializeComponent();

		//Add any initialization after the InitializeComponent() call

	}

	public frmSampleParameters(int intMethodMode, clsAnalysisSampleParametersCollection objPreviousSampParametersIn = null)
	{
		base.New();

		//This call is required by the Windows Form Designer.
		InitializeComponent();

		//Add any initialization after the InitializeComponent() call
		OpenMethodMode = intMethodMode;
		objPreviousSampParameters = objPreviousSampParametersIn;
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
	internal GradientPanel.CustomPanel CustomPanelMain;
	internal GradientPanel.CustomPanel CustomPanelTop;
	internal System.Windows.Forms.DataGrid dgSampleParameters;
	internal GradientPanel.CustomPanel CustomPanelBottom;
	internal GradientPanel.CustomPanel CustomPanelBottomTop;
	internal System.Windows.Forms.Label lblNote3;
	internal System.Windows.Forms.Label lblImpNotes;
	internal NETXP.Controls.XPButton btnHelp;
	internal NETXP.Controls.XPButton btnOk;
	internal NETXP.Controls.XPButton btnCancel;
	internal CodeIntellects.Office2003Controls.Office2003Header Office2003Header1;
	internal System.Windows.Forms.Label Label1;
	internal NETXP.Controls.XPButton btnChangeTiming;
	[System.Diagnostics.DebuggerStepThrough()]
	private void InitializeComponent()
	{
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmSampleParameters));
		this.CustomPanelMain = new GradientPanel.CustomPanel();
		this.CustomPanelTop = new GradientPanel.CustomPanel();
		this.dgSampleParameters = new System.Windows.Forms.DataGrid();
		this.CustomPanelBottom = new GradientPanel.CustomPanel();
		this.btnChangeTiming = new NETXP.Controls.XPButton();
		this.btnOk = new NETXP.Controls.XPButton();
		this.btnCancel = new NETXP.Controls.XPButton();
		this.CustomPanelBottomTop = new GradientPanel.CustomPanel();
		this.Label1 = new System.Windows.Forms.Label();
		this.lblNote3 = new System.Windows.Forms.Label();
		this.lblImpNotes = new System.Windows.Forms.Label();
		this.btnHelp = new NETXP.Controls.XPButton();
		this.Office2003Header1 = new CodeIntellects.Office2003Controls.Office2003Header();
		this.CustomPanelMain.SuspendLayout();
		this.CustomPanelTop.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.dgSampleParameters).BeginInit();
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
		this.CustomPanelMain.Size = new System.Drawing.Size(506, 401);
		this.CustomPanelMain.TabIndex = 14;
		//
		//CustomPanelTop
		//
		this.CustomPanelTop.BackColor = System.Drawing.Color.Transparent;
		this.CustomPanelTop.BackColor2 = System.Drawing.Color.Transparent;
		this.CustomPanelTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.CustomPanelTop.Controls.Add(this.dgSampleParameters);
		this.CustomPanelTop.Dock = System.Windows.Forms.DockStyle.Fill;
		this.CustomPanelTop.Location = new System.Drawing.Point(0, 0);
		this.CustomPanelTop.Name = "CustomPanelTop";
		this.CustomPanelTop.Size = new System.Drawing.Size(506, 257);
		this.CustomPanelTop.TabIndex = 10;
		//
		//dgSampleParameters
		//
		this.dgSampleParameters.CaptionVisible = false;
		this.dgSampleParameters.DataMember = "";
		this.dgSampleParameters.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.dgSampleParameters.HeaderForeColor = System.Drawing.SystemColors.ControlText;
		this.dgSampleParameters.Location = new System.Drawing.Point(9, 21);
		this.dgSampleParameters.Name = "dgSampleParameters";
		this.dgSampleParameters.PreferredColumnWidth = 100;
		this.dgSampleParameters.Size = new System.Drawing.Size(487, 202);
		this.dgSampleParameters.TabIndex = 0;
		//
		//CustomPanelBottom
		//
		this.CustomPanelBottom.BackColor = System.Drawing.Color.Transparent;
		this.CustomPanelBottom.BackColor2 = System.Drawing.Color.Transparent;
		this.CustomPanelBottom.Controls.Add(this.btnChangeTiming);
		this.CustomPanelBottom.Controls.Add(this.btnOk);
		this.CustomPanelBottom.Controls.Add(this.btnCancel);
		this.CustomPanelBottom.Controls.Add(this.CustomPanelBottomTop);
		this.CustomPanelBottom.Controls.Add(this.btnHelp);
		this.CustomPanelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
		this.CustomPanelBottom.Location = new System.Drawing.Point(0, 257);
		this.CustomPanelBottom.Name = "CustomPanelBottom";
		this.CustomPanelBottom.Size = new System.Drawing.Size(506, 144);
		this.CustomPanelBottom.TabIndex = 8;
		//
		//btnChangeTiming
		//
		this.btnChangeTiming.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnChangeTiming.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnChangeTiming.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnChangeTiming.Location = new System.Drawing.Point(16, 104);
		this.btnChangeTiming.Name = "btnChangeTiming";
		this.btnChangeTiming.Size = new System.Drawing.Size(96, 32);
		this.btnChangeTiming.TabIndex = 12;
		this.btnChangeTiming.Text = "&Change Timing";
		//
		//btnOk
		//
		this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
		this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnOk.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnOk.Image = (System.Drawing.Image)resources.GetObject("btnOk.Image");
		this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnOk.Location = new System.Drawing.Point(126, 102);
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
		this.btnCancel.Location = new System.Drawing.Point(230, 102);
		this.btnCancel.Name = "btnCancel";
		this.btnCancel.Size = new System.Drawing.Size(86, 34);
		this.btnCancel.TabIndex = 2;
		this.btnCancel.Text = "&Cancel";
		//
		//CustomPanelBottomTop
		//
		this.CustomPanelBottomTop.BackColor = System.Drawing.Color.Transparent;
		this.CustomPanelBottomTop.BackColor2 = System.Drawing.Color.Transparent;
		this.CustomPanelBottomTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.CustomPanelBottomTop.Controls.Add(this.Label1);
		this.CustomPanelBottomTop.Controls.Add(this.lblNote3);
		this.CustomPanelBottomTop.Controls.Add(this.lblImpNotes);
		this.CustomPanelBottomTop.Dock = System.Windows.Forms.DockStyle.Top;
		this.CustomPanelBottomTop.Location = new System.Drawing.Point(0, 0);
		this.CustomPanelBottomTop.Name = "CustomPanelBottomTop";
		this.CustomPanelBottomTop.Size = new System.Drawing.Size(506, 88);
		this.CustomPanelBottomTop.TabIndex = 9;
		//
		//Label1
		//
		this.Label1.Location = new System.Drawing.Point(8, 61);
		this.Label1.Name = "Label1";
		this.Label1.Size = new System.Drawing.Size(344, 16);
		this.Label1.TabIndex = 4;
		this.Label1.Text = "2. Name of the sample should be less than 10 characters.";
		//
		//lblNote3
		//
		this.lblNote3.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblNote3.Location = new System.Drawing.Point(8, 33);
		this.lblNote3.Name = "lblNote3";
		this.lblNote3.Size = new System.Drawing.Size(344, 16);
		this.lblNote3.TabIndex = 3;
		this.lblNote3.Text = "1. Please enter different sample names";
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
		//btnHelp
		//
		this.btnHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnHelp.Image = (System.Drawing.Image)resources.GetObject("btnHelp.Image");
		this.btnHelp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnHelp.Location = new System.Drawing.Point(264, 120);
		this.btnHelp.Name = "btnHelp";
		this.btnHelp.Size = new System.Drawing.Size(86, 34);
		this.btnHelp.TabIndex = 3;
		this.btnHelp.Text = "Help";
		this.btnHelp.Visible = false;
		//
		//Office2003Header1
		//
		this.Office2003Header1.BackColor = System.Drawing.SystemColors.Control;
		this.Office2003Header1.Dock = System.Windows.Forms.DockStyle.Top;
		this.Office2003Header1.Location = new System.Drawing.Point(0, 0);
		this.Office2003Header1.Name = "Office2003Header1";
		this.Office2003Header1.Size = new System.Drawing.Size(506, 22);
		this.Office2003Header1.TabIndex = 15;
		this.Office2003Header1.TitleFont = new System.Drawing.Font("Tahoma", 10f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.Office2003Header1.TitleText = " Sample Parameters";
		//
		//frmSampleParameters
		//
		this.AcceptButton = this.btnOk;
		this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
		this.CancelButton = this.btnCancel;
		this.ClientSize = new System.Drawing.Size(506, 423);
		this.ControlBox = false;
		this.Controls.Add(this.CustomPanelMain);
		this.Controls.Add(this.Office2003Header1);
		this.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		this.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		this.MaximizeBox = false;
		this.MinimizeBox = false;
		this.Name = "frmSampleParameters";
		this.ShowInTaskbar = false;
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Method";
		this.TopMost = true;
		this.CustomPanelMain.ResumeLayout(false);
		this.CustomPanelTop.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.dgSampleParameters).EndInit();
		this.CustomPanelBottom.ResumeLayout(false);
		this.CustomPanelBottomTop.ResumeLayout(false);
		this.ResumeLayout(false);

	}

	#End Region

	#Region " Private Member Variables "

	private DataTable mobjDtSample;
	private int mintMethodMode;
	private int mintRunNumberIndex;
	//Private mobjDataGridClass As DataGridClass
	private bool mblEnableCancel = true;
	private DataGridClass mobjDtSamplesDataGrid = new DataGridClass(ConstDataGridPropertiesFileName);
	private clsAnalysisSampleParametersCollection objPreviousSampParameters;
		#End Region
	private bool mblnIsCancel = false;

	#Region " Private Constants "
	private const  ConstNumberOfCharactersInWVDColumn = 11;
	private const  ConstNumberOfCharactersInSampleNameColumn = 10;
	private const  ConstColumnSrNo = "SrNo";
	private const  ConstColumnSampleName = "SampleName";
	private const  ConstColumnSamplerPos = "SamplerPos";
	private const  ConstColumnWeight = "Weight";
	private const  ConstColumnVolume = "Volume";
	private const  ConstColumnDilutionFactor = "DilutionFactor";
	private const  ConstTitleSrNo = "Sr.No.";
	private const  ConstTitleSampleName = "Sample Name ";
	private const  ConstTitleWeight = "Weight (gms)";
	private const  ConstTitleVolume = "Volume (ml)";
	private const  ConstTitleDilutionFactor = "Dilution Factor";
	private const double ConstDefaultValue = 1.0;
	private const  ConstDefaultSampleName = "Sample ";
	private const  ConstWidthSrNo = 40;
	private const  ConstNumberOfDefaultSamples = 25;
	private const  ConstWidthSampleName = 93;
	private const  ConstWidthWeight = 81;
	private const  ConstWidthVolume = 80;
	private const  ConstWidthDilutionFactor = 98;
	private const  ConstParentFormLoad = "-Method";
	private const  ConstFormLoad = "-Method-Sample Parameters";
	private enum EnumUnits
	{
		Ppm = 1,
		Percentage = 2
	}
	#End Region

	#Region " Private Properties "

	private EnumMethodMode OpenMethodMode {
		get { return mintMethodMode; }

		set { mintMethodMode = Value; }
	}
	public bool EnableBtnCancel {

		get { }
		set {
			mblEnableCancel = Value;
			if ((mblEnableCancel == false)) {
				btnCancel.Enabled = false;
			}


		}
	}

	#End Region

	#Region " Form Events "

	private void  // ERROR: Handles clauses are not supported in C#
frmSampleParameters_Load(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : frmSampleParameters_Load
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To initialize and load the form
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak
		// Created               : 28.07.07
		// Revisions             : 
		// Revisions             : 0
		//=====================================================================
		//'note;
		//'this is called when sampler parameter form is loaded
		//'this is use to set some initialization over a form.
		CWaitCursor objWait = new CWaitCursor();
		int intCounter;
		DataRow objRow;
		int intNoOfSamples;
		bool blnNewParameter = true;
		try {
			//1. if object is not initialized then load default condition
			//2. if object is initialized then load object data
			gobjMain.ShowProgressBar(gstrTitleInstrumentType + ConstFormLoad);
			SubAddHandlers();
			SubDataGridSettings();
			//'set the grid intial setting

			if (!gobjNewMethod.SampleDataCollection == null) {
				OpenMethodMode = modGlobalConstants.EnumMethodMode.EditMode;
			//'open a method in a editable mode
			} else {
				OpenMethodMode = modGlobalConstants.EnumMethodMode.NewMode;
				//'open method in new creation mode
				gobjNewMethod.SampleDataCollection = new clsAnalysisSampleParametersCollection();
			}

			switch (OpenMethodMode) {
				case modGlobalConstants.EnumMethodMode.NewMode:
					//if first time this form is opened
					//if unit is only changed in parameters 
					for (intCounter = 0; intCounter <= ConstNumberOfDefaultSamples - 1; intCounter++) {
						objRow = mobjDtSample.NewRow;
						objRow.Item(ConstColumnSrNo) = intCounter + 1;
						//by Pankaj for autosampler on 10Sep 07
						if (gstructAutoSampler.blnAutoSamplerInitialised == true) {
							objRow.Item(ConstColumnSamplerPos) = intCounter + 1;
						}
						objRow.Item(ConstColumnSampleName) = ConstDefaultSampleName + intCounter + 1;
						objRow.Item(ConstColumnWeight) = ConstDefaultValue;
						if (!gobjNewMethod.AnalysisParameters == null) {
							if (gobjNewMethod.AnalysisParameters.Unit == EnumUnits.Percentage) {
								//objRow.Item(ConstColumnVolume) = 100
								//---changed by Deepak on 30.01.09 as per report from App. Lab
								objRow.Item(ConstColumnVolume) = 1;
							} else {
								objRow.Item(ConstColumnVolume) = ConstDefaultValue;
							}
						} else {
							objRow.Item(ConstColumnVolume) = ConstDefaultValue;
						}
						objRow.Item(ConstColumnDilutionFactor) = ConstDefaultValue;
						if (!mobjDtSample == null) {
							mobjDtSample.Rows.Add(objRow);
						}

					}

				case modGlobalConstants.EnumMethodMode.EditMode:
					if (!gobjNewMethod.AnalysisParameters == null) {
						intNoOfSamples = gobjNewMethod.AnalysisParameters.NumOfSamples;
					}
					funcLoadInitialData(intNoOfSamples);
			}

			mobjDtSamplesDataGrid.SetDataGridProperties(dgSampleParameters, mobjDtSample);
			///'this function will set the grid property 
			dgSampleParameters.Focus();
			mobjDtSamplesDataGrid.SetDataGridTableStyle.BeginEdit(dgSampleParameters.TableStyles.Item(0).GridColumnStyles(2), 0);
			//'setting grid
			if (!IsInIQOQPQ) {
				//'show the status form
				gobjfrmStatus.Show();
			}
			btnChangeTiming.Visible = gstructAutoSampler.blnAutoSamplerInitialised;
			//Added by pankaj for autosampler
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
frmSampleParameters_Closing(object sender, System.ComponentModel.CancelEventArgs e)
	{
		//=====================================================================
		// Procedure Name        : frmSampleParameters_Closing
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak
		// Created               : 28.07.07
		// Revisions             : 
		// Revisions             : 0
		//=====================================================================
		//'note:
		//'this is called when user close the form

		if (mblnIsCancel == true) {
			e.Cancel = mblnIsCancel;
			mblnIsCancel = false;
			return;
		}
		gobjMain.ShowRunTimeInfo(gstrTitleInstrumentType + ConstParentFormLoad);
	}

	private void SubDataGridSettings()
	{
		//=====================================================================
		// Procedure Name        : SubDataGridSettings
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : for setting data grid.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak
		// Created               : 28.07.07
		// Revisions             : 
		// Revisions             : 0
		//=====================================================================
		//'note:
		//'In this function set a grid for eg no of column , row
		//'name of column ,weight ,volume ect
		//'and validat this grid
		try {
			mobjDtSample = new DataTable();

			mobjDtSample.Columns.Clear();

			mobjDtSample.Columns.Add(ConstColumnSrNo, typeof(int));
			mobjDtSample.Columns.Add(ConstColumnSampleName, typeof(string));
			mobjDtSample.Columns.Add(ConstColumnWeight, typeof(double));
			mobjDtSample.Columns.Add(ConstColumnVolume, typeof(double));
			mobjDtSample.Columns.Add(ConstColumnDilutionFactor, typeof(double));

			mobjDtSample.Columns(ConstColumnWeight).DefaultValue = DBNull.Value;
			mobjDtSample.Columns(ConstColumnVolume).DefaultValue = DBNull.Value;
			mobjDtSample.Columns(ConstColumnDilutionFactor).DefaultValue = DBNull.Value;

			mobjDtSamplesDataGrid.AllowNew = false;
			mobjDtSamplesDataGrid.AdjustColumnWidthToGrid = false;

			mobjDtSamplesDataGrid.AddDataGridColumnStyle(mobjDtSample.Columns(0).ColumnName, dgSampleParameters, mobjDtSample, DataGridClass.enumColumnType.TextBoxColumn, HorizontalAlignment.Center, ConstTitleSrNo, ConstWidthSrNo, true, DataGridClass.ColumnDataType.Text, HorizontalAlignment.Center);
			mobjDtSamplesDataGrid.AddDataGridColumnStyle(mobjDtSample.Columns(1).ColumnName, dgSampleParameters, mobjDtSample, DataGridClass.enumColumnType.TextBoxColumn, HorizontalAlignment.Center, ConstTitleSampleName, ConstWidthSampleName, false, DataGridClass.ColumnDataType.Text, HorizontalAlignment.Left,
			ConstNumberOfCharactersInSampleNameColumn, true, false);
			mobjDtSamplesDataGrid.AddDataGridColumnStyle(mobjDtSample.Columns(2).ColumnName, dgSampleParameters, mobjDtSample, DataGridClass.enumColumnType.TextBoxColumn, HorizontalAlignment.Center, ConstTitleWeight, ConstWidthWeight, false, DataGridClass.ColumnDataType.Text, HorizontalAlignment.Center,
			ConstNumberOfCharactersInWVDColumn, true, true);
			mobjDtSamplesDataGrid.AddDataGridColumnStyle(mobjDtSample.Columns(3).ColumnName, dgSampleParameters, mobjDtSample, DataGridClass.enumColumnType.TextBoxColumn, HorizontalAlignment.Center, ConstTitleVolume, ConstWidthVolume, false, DataGridClass.ColumnDataType.Text, HorizontalAlignment.Center,
			ConstNumberOfCharactersInWVDColumn, true, true);
			mobjDtSamplesDataGrid.AddDataGridColumnStyle(mobjDtSample.Columns(4).ColumnName, dgSampleParameters, mobjDtSample, DataGridClass.enumColumnType.TextBoxColumn, HorizontalAlignment.Center, ConstTitleDilutionFactor, ConstWidthDilutionFactor, false, DataGridClass.ColumnDataType.Text, HorizontalAlignment.Center,
			ConstNumberOfCharactersInWVDColumn, true, true);
			if (gstructAutoSampler.blnAutoSamplerInitialised == true) {
				mobjDtSample.Columns.Add(ConstColumnSamplerPos, typeof(int));
				mobjDtSample.Columns(ConstColumnSamplerPos).DefaultValue = 0;
				mobjDtSamplesDataGrid.AddDataGridColumnStyle(mobjDtSample.Columns(5).ColumnName, dgSampleParameters, mobjDtSample, DataGridClass.enumColumnType.TextBoxColumn, HorizontalAlignment.Center, ConstColumnSamplerPos, ConstWidthDilutionFactor - 20, false, DataGridClass.ColumnDataType.Text, HorizontalAlignment.Center,
				2, true, true);
			} else {
				this.dgSampleParameters.Width = this.dgSampleParameters.Width - 70;
			}
			mobjDtSamplesDataGrid.SetDataGridProperties(dgSampleParameters, mobjDtSample);
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
		// Author                : Deepak
		// Created               : 05.10.06
		// Revisions             : 
		//=====================================================================
		try {
			//'this will add a event ot a control
			btnCancel.Click += btnCancel_Click;
			//'for eg if user click on cancel button then btnCancel_Click will called
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
		// Author                : Deepak
		// Created               : 05.10.06
		// Revisions             : 
		//=====================================================================
		try {
			//'this is called when user click on cancel button
			if (OpenMethodMode == modGlobalConstants.EnumMethodMode.NewMode) {
				gobjNewMethod.SampleDataCollection = null;
			}

			//Me.Close()
			this.DialogResult = DialogResult.Cancel;
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
		// Author                : Deepak
		// Created               : 05.10.06
		// Revisions             : 
		//=====================================================================

		//'note:
		//'this is called when user clicked on OK button
		//'step1: check a validation for input value
		//'for eg there should be unique data
		//'step2: store it in a temp variable
		//'step3:and then bound it proper data structure



		CWaitCursor objWait = new CWaitCursor();
		int intCounter;
		clsAnalysisSampleParameters objClsSampleParameters;
		clsAnalysisSampleParametersCollection objSamplesCollection;

		try {
			//---18.06.07
			objSamplesCollection = new clsAnalysisSampleParametersCollection();
			string strSampleName;
			int intCounter1;
			bool blnDuplicateFound;

			////-----  Added by Sachin Dokhale
			blnDuplicateFound = false;
			for (intCounter = 0; intCounter <= mobjDtSample.Rows.Count - 1; intCounter++) {
				strSampleName = mobjDtSample.Rows(intCounter).Item(1);
				for (intCounter1 = intCounter + 1; intCounter1 <= mobjDtSample.Rows.Count - 1; intCounter1++) {
					if (strSampleName == mobjDtSample.Rows(intCounter1).Item(1)) {
						blnDuplicateFound = true;
						break; // TODO: might not be correct. Was : Exit For
					}
				}

				if (blnDuplicateFound == true) {
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			if (blnDuplicateFound == true) {
				//gobjMessageAdapter.ShowMessage(constInputProperData)
				mblnIsCancel = true;
				//'check for duplicate name
				gobjMessageAdapter.ShowMessage("Duplicate Sample name", "Sample name", MessageHandler.clsMessageHandler.enumMessageType.WarningMessage);
				Application.DoEvents();
				return;
			}

			//For intCounter = 0 To mobjDtSample.Rows.Count - 1
			//    If IsNumeric(mobjDtSample.Rows(intCounter).Item(ConstColumnWeight)) And _
			//    IsNumeric(mobjDtSample.Rows(intCounter).Item(ConstColumnVolume)) And _
			//    IsNumeric(mobjDtSample.Rows(intCounter).Item(ConstColumnDilutionFactor)) Then
			//    Else
			//        gobjMessageAdapter.ShowMessage("Please enter proper data", "Numeric data required", MessageHandler.clsMessageHandler.enumMessageType.WarningMessage)
			//        Application.DoEvents()
			//        Exit Sub
			//    End If
			//Next

			////-----
			for (intCounter = 0; intCounter <= mobjDtSample.Rows.Count - 1; intCounter++) {
				if (Trim(mobjDtSample.Rows(intCounter).Item(ConstColumnSampleName)) != "" & !IsDBNull(mobjDtSample.Rows(intCounter).Item(ConstColumnWeight)) & !IsDBNull(mobjDtSample.Rows(intCounter).Item(ConstColumnVolume)) & !IsDBNull(mobjDtSample.Rows(intCounter).Item(ConstColumnDilutionFactor))) {
					if (IsNumeric(Trim(mobjDtSample.Rows(intCounter).Item(ConstColumnWeight))) & IsNumeric(Trim(mobjDtSample.Rows(intCounter).Item(ConstColumnVolume))) & IsNumeric(Trim(mobjDtSample.Rows(intCounter).Item(ConstColumnDilutionFactor)))) {
						objClsSampleParameters = new clsAnalysisSampleParameters();
						objClsSampleParameters.SampNumber = mobjDtSample.Rows(intCounter).Item(ConstColumnSrNo);
						//'here storing a data in to a data structure object.
						objClsSampleParameters.SampleName = mobjDtSample.Rows(intCounter).Item(ConstColumnSampleName);
						objClsSampleParameters.Weight = mobjDtSample.Rows(intCounter).Item(ConstColumnWeight);
						objClsSampleParameters.Volume = mobjDtSample.Rows(intCounter).Item(ConstColumnVolume);
						objClsSampleParameters.DilutionFactor = mobjDtSample.Rows(intCounter).Item(ConstColumnDilutionFactor);
						//by Pankaj for autosampler on 10Sep 07
						if ((gstructAutoSampler.blnAutoSamplerInitialised == true)) {
							objClsSampleParameters.SampPosNumber = mobjDtSample.Rows(intCounter).Item(ConstColumnSamplerPos);
						}
						objSamplesCollection.Add(objClsSampleParameters);
					} else {
						mblnIsCancel = true;
						gobjMessageAdapter.ShowMessage(constInputProperData);
						Application.DoEvents();
						//'allow application to perfrom its panding work
						return;
					}
				} else {
					mblnIsCancel = true;
					gobjMessageAdapter.ShowMessage(constInputProperData);
					//'show inproper data messag
					Application.DoEvents();
					//'allow application to perfrom its panding work
					return;
				}
			}
			//For intRunNo As Integer = 0 To gobjNewMethod.QuantitativeDataCollection.Count - 1
			for (intCounter = 0; intCounter <= gobjNewMethod.SampleDataCollection.Count - 1; intCounter++) {
				if (gobjNewMethod.SampleDataCollection.Count > intCounter) {
					if (gobjNewMethod.SampleDataCollection.item(intCounter).Used == true) {
						objSamplesCollection.item(intCounter).Used = true;
						//If gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCounter).Abs <> -1.0 Then
						objSamplesCollection.item(intCounter).Abs = gobjNewMethod.SampleDataCollection.item(intCounter).Abs;
						//End If
					}
				}
			}
			//Next
			gobjNewMethod.SampleDataCollection.Clear();
			gobjNewMethod.SampleDataCollection = objSamplesCollection.Clone();

			//---Update Current Method in Method Collection
			for (intCounter = gobjMethodCollection.Count - 1; intCounter >= 0; intCounter += -1) {
				if (gobjMethodCollection.item(intCounter).MethodID == gobjNewMethod.MethodID) {
					//If (gobjMethodCollection.item(intCounter).QuantitativeDataCollection.Count >= gobjNewMethod.QuantitativeDataCollection.Count) Then
					gobjMethodCollection.item(intCounter).SampleDataCollection = gobjNewMethod.SampleDataCollection.Clone();
					gobjMethodCollection.item(intCounter).DateOfModification = DateTime.Now;
					//Else
					//gobjMethodCollection.item(intCounter).QuantitativeDataCollection.Add(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex))
					//gobjMethodCollection.item(intCounter).DateOfModification = DateTime.Now
					//End If
					funcSaveAllMethods(gobjMethodCollection);
					//'for saving a method with current data
					//'this saved method is later be used in analysis.
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			//---serialize method collection 
			//Call funcSerialize(ConstMethodsFileName, gobjMethodCollection)


			this.DialogResult = DialogResult.OK;
			mblnIsCancel = false;
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			mblnIsCancel = false;
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

	private bool funcLoadInitialData(int intNoOfSamples)
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
		// Created               : 28.07.07
		// Revisions             : 0
		//=====================================================================
		int intCounter;
		DataRow objRow;
		int intInitialCount;
		//'note:
		//'this function is used for intial setup of form
		//'in this we show a current info like sampler name etc
		//'into a grid



		try {
			if (gobjNewMethod.SampleDataCollection.Count >= intNoOfSamples) {
				for (intCounter = 0; intCounter <= gobjNewMethod.SampleDataCollection.Count - 1; intCounter++) {
					objRow = mobjDtSample.NewRow;
					objRow.Item(ConstColumnSrNo) = gobjNewMethod.SampleDataCollection.item(intCounter).SampNumber;
					objRow.Item(ConstColumnSampleName) = gobjNewMethod.SampleDataCollection.item(intCounter).SampleName;
					//by Pankaj for autosampler on 10Sep 07
					if (gstructAutoSampler.blnAutoSamplerInitialised == true) {
						if ((gobjNewMethod.SampleDataCollection.item(intCounter).SampPosNumber == -1)) {
							objRow.Item(ConstColumnSamplerPos) = intCounter + 1;
						} else {
							objRow.Item(ConstColumnSamplerPos) = gobjNewMethod.SampleDataCollection.item(intCounter).SampPosNumber;
						}
					}

					if (gobjNewMethod.SampleDataCollection.item(intCounter).Weight == 0.0) {
						objRow.Item(ConstColumnWeight) = DBNull.Value;
					} else {
						objRow.Item(ConstColumnWeight) = FormatNumber(gobjNewMethod.SampleDataCollection.item(intCounter).Weight, 6);
					}

					if (gobjNewMethod.SampleDataCollection.item(intCounter).Volume == 0.0) {
						objRow.Item(ConstColumnVolume) = DBNull.Value;
					} else {
						objRow.Item(ConstColumnVolume) = FormatNumber(gobjNewMethod.SampleDataCollection.item(intCounter).Volume, 6);
					}

					if (gobjNewMethod.SampleDataCollection.item(intCounter).DilutionFactor == 0.0) {
						objRow.Item(ConstColumnDilutionFactor) = DBNull.Value;
					} else {
						objRow.Item(ConstColumnDilutionFactor) = FormatNumber(gobjNewMethod.SampleDataCollection.item(intCounter).DilutionFactor, 6);
					}

					mobjDtSample.Rows.Add(objRow);
				}
				if (intNoOfSamples > gobjNewMethod.SampleDataCollection.Count) {
					for (intCounter = gobjNewMethod.SampleDataCollection.Count; intCounter <= intNoOfSamples - 1; intCounter++) {
						objRow = mobjDtSample.NewRow;
						objRow.Item(ConstColumnSrNo) = intCounter + 1;
						objRow.Item(ConstColumnSampleName) = ConstDefaultSampleName + intCounter + 1;
						//by Pankaj for autosampler on 10Sep 07
						if ((gstructAutoSampler.blnAutoSamplerInitialised == true)) {
							objRow.Item(ConstColumnSamplerPos) = intCounter + 1;
						}
						objRow.Item(ConstColumnWeight) = ConstDefaultValue;
						objRow.Item(ConstColumnVolume) = ConstDefaultValue;
						objRow.Item(ConstColumnDilutionFactor) = ConstDefaultValue;
						mobjDtSample.Rows.Add(objRow);
					}
				}
			} else {
				if (intNoOfSamples < gobjNewMethod.SampleDataCollection.Count) {
					for (intCounter = 0; intCounter <= intNoOfSamples - 1; intCounter++) {
						objRow = mobjDtSample.NewRow;
						objRow.Item(ConstColumnSrNo) = gobjNewMethod.SampleDataCollection.item(intCounter).SampNumber;
						objRow.Item(ConstColumnSampleName) = gobjNewMethod.SampleDataCollection.item(intCounter).SampleName;
						if ((gstructAutoSampler.blnAutoSamplerInitialised == true)) {
							objRow.Item(ConstColumnSamplerPos) = gobjNewMethod.SampleDataCollection.item(intCounter).SampPosNumber;
							if ((gobjNewMethod.SampleDataCollection.item(intCounter).SampPosNumber == -1)) {
								objRow.Item(ConstColumnSamplerPos) = intCounter + 1;
							}
						}

						if (gobjNewMethod.SampleDataCollection.item(intCounter).Weight == 0.0) {
							objRow.Item(ConstColumnWeight) = DBNull.Value;
						} else {
							objRow.Item(ConstColumnWeight) = FormatNumber(gobjNewMethod.SampleDataCollection.item(intCounter).Weight, 6);
						}

						if (gobjNewMethod.SampleDataCollection.item(intCounter).Volume == 0.0) {
							objRow.Item(ConstColumnVolume) = DBNull.Value;
						} else {
							objRow.Item(ConstColumnVolume) = FormatNumber(gobjNewMethod.SampleDataCollection.item(intCounter).Volume, 6);
						}

						if (gobjNewMethod.SampleDataCollection.item(intCounter).DilutionFactor == 0.0) {
							objRow.Item(ConstColumnDilutionFactor) = DBNull.Value;
						} else {
							objRow.Item(ConstColumnDilutionFactor) = FormatNumber(gobjNewMethod.SampleDataCollection.item(intCounter).DilutionFactor, 6);
						}

						mobjDtSample.Rows.Add(objRow);
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

	#End Region

	#Region "Commented Code"
	//Private Sub frmSampleParameters_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
	//    '=====================================================================
	//    ' Procedure Name        : frmSampleParameters_Load
	//    ' Parameters Passed     : Object,EventArgs
	//    ' Returns               : None
	//    ' Purpose               : To initialize and load the form
	//    ' Description           : 
	//    ' Assumptions           : 
	//    ' Dependencies          : 
	//    ' Author                : Saurabh
	//    ' Created               : 05.10.06
	//    ' Revisions             : Deepak
	//    ' Revisions             : 3
	//    ' Revision By           : Mangesh S. on 28-Jan-2007
	//    ' Revision for          : Changes in AAS203Library
	//    '=====================================================================
	//    Dim objWait As New CWaitCursor
	//    Dim intCounter As Integer
	//    Dim objRow As DataRow
	//    Dim intNoOfSamples As Integer
	//    Dim blnNewParameter As Boolean = True
	//    Try
	//        'mobjDataGridClass = New DataGridClass(ConstDataGridPropertiesFileName)
	//        If gobjchkActiveMethod.NewMethod = True And gobjchkActiveMethod.CancelMethod = True Then
	//            OpenMethodMode = modGlobalConstants.EnumMethodMode.NewMode
	//        End If

	//        gobjMain.ShowProgressBar(ConstFormLoad)
	//        SubAddHandlers()
	//        mobjDtSample = New DataTable

	//        mobjDtSample.Columns.Clear()

	//        mobjDtSample.Columns.Add(ConstColumnSrNo, GetType(Integer))
	//        mobjDtSample.Columns.Add(ConstColumnSampleName, GetType(String))
	//        mobjDtSample.Columns.Add(ConstColumnWeight, GetType(Double))
	//        mobjDtSample.Columns.Add(ConstColumnVolume, GetType(Double))
	//        mobjDtSample.Columns.Add(ConstColumnDilutionFactor, GetType(Double))

	//        mobjDtSample.Columns(ConstColumnWeight).DefaultValue = DBNull.Value
	//        mobjDtSample.Columns(ConstColumnVolume).DefaultValue = DBNull.Value
	//        mobjDtSample.Columns(ConstColumnDilutionFactor).DefaultValue = DBNull.Value
	//        mobjDtSample.Columns(ConstColumnSampleName).MaxLength = 10

	//        mobjDtSamplesDataGrid.AllowNew = False
	//        mobjDtSamplesDataGrid.AdjustColumnWidthToGrid = False

	//        mobjDtSamplesDataGrid.AddDataGridColumnStyle(mobjDtSample.Columns(0).ColumnName, dgSampleParameters, mobjDtSample, DataGridClass.enumColumnType.TextBoxColumn, HorizontalAlignment.Center, ConstTitleSrNo, ConstWidthSrNo, True, DataGridClass.ColumnDataType.Text, HorizontalAlignment.Center)
	//        mobjDtSamplesDataGrid.AddDataGridColumnStyle(mobjDtSample.Columns(1).ColumnName, dgSampleParameters, mobjDtSample, DataGridClass.enumColumnType.TextBoxColumn, HorizontalAlignment.Center, ConstTitleSampleName, ConstWidthSampleName, False, DataGridClass.ColumnDataType.Text, HorizontalAlignment.Left)
	//        mobjDtSamplesDataGrid.AddDataGridColumnStyle(mobjDtSample.Columns(2).ColumnName, dgSampleParameters, mobjDtSample, DataGridClass.enumColumnType.TextBoxColumn, HorizontalAlignment.Center, ConstTitleWeight, ConstWidthWeight, False, DataGridClass.ColumnDataType.Text, HorizontalAlignment.Center)
	//        mobjDtSamplesDataGrid.AddDataGridColumnStyle(mobjDtSample.Columns(3).ColumnName, dgSampleParameters, mobjDtSample, DataGridClass.enumColumnType.TextBoxColumn, HorizontalAlignment.Center, ConstTitleVolume, ConstWidthVolume, False, DataGridClass.ColumnDataType.Text, HorizontalAlignment.Center)
	//        mobjDtSamplesDataGrid.AddDataGridColumnStyle(mobjDtSample.Columns(4).ColumnName, dgSampleParameters, mobjDtSample, DataGridClass.enumColumnType.TextBoxColumn, HorizontalAlignment.Center, ConstTitleDilutionFactor, ConstWidthDilutionFactor, False, DataGridClass.ColumnDataType.Text, HorizontalAlignment.Center)
	//        mobjDtSamplesDataGrid.SetDataGridProperties(dgSampleParameters, mobjDtSample)

	//        If OpenMethodMode = modGlobalConstants.EnumMethodMode.NewMode Then
	//            'Saurabh Commented 19.07.07
	//            '//----- Added by Sachin Dokhale 
	//            'If Not objPreviousSampParameters Is Nothing Then
	//            '    If objPreviousSampParameters.Count > 0 Then
	//            '        If gobjMessageAdapter.ShowMessage("Load Previous Sample Parameters ? ", "Previous Sample Parameter", MessageHandler.clsMessageHandler.enumMessageType.QuestionMessage) = True Then
	//            '            For intCounter = 0 To objPreviousSampParameters.Count - 1
	//            '                objRow = mobjDtSample.NewRow
	//            '                objRow.Item(ConstColumnSrNo) = intCounter + 1
	//            '                objRow.Item(ConstColumnSampleName) = objPreviousSampParameters(intCounter).SampleName
	//            '                objRow.Item(ConstColumnWeight) = objPreviousSampParameters(intCounter).Weight
	//            '                objRow.Item(ConstColumnVolume) = objPreviousSampParameters(intCounter).Volume
	//            '                objRow.Item(ConstColumnDilutionFactor) = objPreviousSampParameters(intCounter).DilutionFactor
	//            '                mobjDtSample.Rows.Add(objRow)
	//            '                blnNewParameter = False
	//            '            Next intCounter
	//            '        End If
	//            '    End If
	//            'End If
	//            'Saurabh Commented 19.07.07
	//            If blnNewParameter = True Then
	//                '//-----
	//                intNoOfSamples = gobjNewMethod.AnalysisParameters.NumOfSamples
	//                If intNoOfSamples = 0 Then '27.07.07 Deepak
	//                    intNoOfSamples = ConstNumberOfDefaultSamples
	//                End If
	//                If intNoOfSamples > 0 Then
	//                    For intCounter = 0 To intNoOfSamples - 1
	//                        objRow = mobjDtSample.NewRow
	//                        objRow.Item(ConstColumnSrNo) = intCounter + 1
	//                        objRow.Item(ConstColumnSampleName) = ConstDefaultSampleName & intCounter + 1
	//                        objRow.Item(ConstColumnWeight) = ConstDefaultValue
	//                        '------------------Added By Pankaj 11 May 07 6
	//                        If gobjNewMethod.AnalysisParameters.Unit > 1 Then
	//                            objRow.Item(ConstColumnVolume) = 100
	//                        Else
	//                            objRow.Item(ConstColumnVolume) = ConstDefaultValue
	//                        End If
	//                        '----------------
	//                        'objRow.Item(ConstColumnVolume) = ConstDefaultValue
	//                        objRow.Item(ConstColumnDilutionFactor) = ConstDefaultValue
	//                        mobjDtSample.Rows.Add(objRow)
	//                    Next intCounter
	//                End If
	//            End If
	//            'End If
	//            '----------------------------------Saurabh-------------------------------
	//        Else
	//            intNoOfSamples = gobjNewMethod.AnalysisParameters.NumOfSamples
	//            Call funcLoadInitialData(intNoOfSamples)
	//        End If

	//        Call mobjDtSamplesDataGrid.SetDataGridProperties(dgSampleParameters, mobjDtSample)

	//        dgSampleParameters.Focus()
	//        mobjDtSamplesDataGrid.SetDataGridTableStyle.BeginEdit(dgSampleParameters.TableStyles.Item(0).GridColumnStyles(2), 0)

	//        '----------------------------------Saurabh-------------------------------


	//        '''----------------------------ORIGINAL-------------------------------------------
	//        '''intNoOfSamples = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfSamples

	//        '''If intNoOfSamples > 0 Then
	//        '''    For intCounter = 0 To intNoOfSamples - 1
	//        '''        objRow = mobjDtSample.NewRow
	//        '''        objRow.Item(ConstColumnSrNo) = intCounter + 1
	//        '''        objRow.Item(ConstColumnSampleName) = ConstDefaultSampleName & intCounter + 1
	//        '''        objRow.Item(ConstColumnWeight) = ConstDefaultValue
	//        '''        objRow.Item(ConstColumnVolume) = ConstDefaultValue
	//        '''        objRow.Item(ConstColumnDilutionFactor) = ConstDefaultValue
	//        '''        mobjDtSample.Rows.Add(objRow)
	//        '''    Next intCounter
	//        '''End If

	//        ''''If OpenMethodMode = modGlobalConstants.EnumMethodMode.EditMode Then
	//        '''Call funcLoadInitialData(mobjDtSample)
	//        ''''End If

	//        '''----------------------------ORIGINAL-------------------------------------------

	//        'Saurabh 10.07.07 To bring status form in front
	//        If Not IsInIQOQPQ Then
	//            gobjfrmStatus.Show()
	//        End If
	//        'Saurabh

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
	//        objWait.Dispose()
	//        gobjMain.HideProgressBar()
	//        '---------------------------------------------------------
	//    End Try
	//End Sub

	//Private Function funcLoadInitialData(ByVal intNoOfSamples As Integer) As Boolean
	//    'Private Function funcLoadInitialData(ByRef objDtSample As DataTable) As Boolean
	//    '=====================================================================
	//    ' Procedure Name        : funcLoadInitialData
	//    ' Parameters Passed     : None
	//    ' Returns               : True or False
	//    ' Purpose               : To load initial data
	//    ' Description           : 
	//    ' Assumptions           : 
	//    ' Dependencies          : 
	//    ' Author                : Deepak Bhati
	//    ' Created               : 08.10.06
	//    ' Revisions             : 2
	//    ' Revision By           : Mangesh S. on 28-Jan-2007
	//    ' Revision for          : Changes in AAS203Library
	//    '=====================================================================
	//    '---------------------------------------Saurabh--------------------------------
	//    Dim intCounter As Integer
	//    Dim objRow As DataRow
	//    Dim intInitialCount As Integer

	//    Try
	//        '---18.06.07
	//        intInitialCount = CInt(gobjNewMethod.SampleDataCollection.Count)

	//        If intNoOfSamples > intInitialCount Then
	//            For intCounter = 0 To intInitialCount - 1
	//                objRow = mobjDtSample.NewRow
	//                objRow.Item(ConstColumnSrNo) = gobjNewMethod.SampleDataCollection.item(intCounter).SampNumber
	//                objRow.Item(ConstColumnSampleName) = gobjNewMethod.SampleDataCollection.item(intCounter).SampleName

	//                If gobjNewMethod.SampleDataCollection.item(intCounter).Weight = 0.0 Then
	//                    objRow.Item(ConstColumnWeight) = DBNull.Value
	//                Else
	//                    objRow.Item(ConstColumnWeight) = FormatNumber(gobjNewMethod.SampleDataCollection.item(intCounter).Weight, 6)
	//                End If

	//                If gobjNewMethod.SampleDataCollection.item(intCounter).Volume = 0.0 Then
	//                    objRow.Item(ConstColumnVolume) = DBNull.Value
	//                Else
	//                    'objRow.Item(ConstColumnVolume) = FormatNumber(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCounter).Volume, 6)
	//                    '------------------Added By Pankaj 11 May 07 6
	//                    'If gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.Unit = 2 And FormatNumber(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCounter).Volume, 6) < 100 Then
	//                    'objRow.Item(ConstColumnVolume) = 100 * FormatNumber(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCounter).Volume, 6)
	//                    'Else
	//                    objRow.Item(ConstColumnVolume) = FormatNumber(gobjNewMethod.SampleDataCollection.item(intCounter).Volume, 6)
	//                    'End If
	//                    '----------------

	//                End If

	//                If gobjNewMethod.SampleDataCollection.item(intCounter).DilutionFactor = 0.0 Then
	//                    objRow.Item(ConstColumnDilutionFactor) = DBNull.Value
	//                Else
	//                    objRow.Item(ConstColumnDilutionFactor) = FormatNumber(gobjNewMethod.SampleDataCollection.item(intCounter).DilutionFactor, 6)
	//                End If

	//                mobjDtSample.Rows.Add(objRow)
	//            Next

	//            For intCounter = intInitialCount To intNoOfSamples - 1
	//                objRow = mobjDtSample.NewRow
	//                objRow.Item(ConstColumnSrNo) = intCounter + 1
	//                objRow.Item(ConstColumnSampleName) = ConstDefaultSampleName & intCounter + 1
	//                objRow.Item(ConstColumnWeight) = ConstDefaultValue
	//                objRow.Item(ConstColumnVolume) = ConstDefaultValue
	//                objRow.Item(ConstColumnDilutionFactor) = ConstDefaultValue
	//                mobjDtSample.Rows.Add(objRow)
	//            Next

	//        ElseIf intNoOfSamples < intInitialCount Then

	//            For intCounter = 0 To intNoOfSamples - 1
	//                objRow = mobjDtSample.NewRow
	//                objRow.Item(ConstColumnSrNo) = gobjNewMethod.SampleDataCollection.item(intCounter).SampNumber
	//                objRow.Item(ConstColumnSampleName) = gobjNewMethod.SampleDataCollection.item(intCounter).SampleName

	//                If gobjNewMethod.SampleDataCollection.item(intCounter).Weight = 0.0 Then
	//                    objRow.Item(ConstColumnWeight) = DBNull.Value
	//                Else
	//                    objRow.Item(ConstColumnWeight) = FormatNumber(gobjNewMethod.SampleDataCollection.item(intCounter).Weight, 6)
	//                End If

	//                If gobjNewMethod.SampleDataCollection.item(intCounter).Volume = 0.0 Then
	//                    objRow.Item(ConstColumnVolume) = DBNull.Value
	//                Else
	//                    '------------------Added By Pankaj 11 May 07 6
	//                    'If gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.Unit = 2 And FormatNumber(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCounter).Volume, 6) < 100 Then
	//                    '    objRow.Item(ConstColumnVolume) = 100 * FormatNumber(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCounter).Volume, 6)
	//                    'Else
	//                    objRow.Item(ConstColumnVolume) = FormatNumber(gobjNewMethod.SampleDataCollection.item(intCounter).Volume, 6)
	//                    'End If
	//                    '----------------

	//                    'objRow.Item(ConstColumnVolume) = FormatNumber(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCounter).Volume, 6)
	//                End If

	//                If gobjNewMethod.SampleDataCollection.item(intCounter).DilutionFactor = 0.0 Then
	//                    objRow.Item(ConstColumnDilutionFactor) = DBNull.Value
	//                Else
	//                    objRow.Item(ConstColumnDilutionFactor) = FormatNumber(gobjNewMethod.SampleDataCollection.item(intCounter).DilutionFactor, 6)
	//                End If

	//                mobjDtSample.Rows.Add(objRow)
	//            Next
	//        Else
	//            For intCounter = 0 To intInitialCount - 1
	//                objRow = mobjDtSample.NewRow
	//                objRow.Item(ConstColumnSrNo) = gobjNewMethod.SampleDataCollection.item(intCounter).SampNumber
	//                objRow.Item(ConstColumnSampleName) = gobjNewMethod.SampleDataCollection.item(intCounter).SampleName

	//                If gobjNewMethod.SampleDataCollection.item(intCounter).Weight = 0.0 Then
	//                    objRow.Item(ConstColumnWeight) = DBNull.Value
	//                Else
	//                    objRow.Item(ConstColumnWeight) = FormatNumber(gobjNewMethod.SampleDataCollection.item(intCounter).Weight, 6)
	//                End If

	//                If gobjNewMethod.SampleDataCollection.item(intCounter).Volume = 0.0 Then
	//                    objRow.Item(ConstColumnVolume) = DBNull.Value
	//                Else
	//                    '------------------Added By Pankaj 11 May 07 6
	//                    'If gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.Unit = 2 And FormatNumber(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCounter).Volume, 6) < 100 Then
	//                    '    objRow.Item(ConstColumnVolume) = 100 * FormatNumber(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCounter).Volume, 6)
	//                    'Else
	//                    objRow.Item(ConstColumnVolume) = FormatNumber(gobjNewMethod.SampleDataCollection.item(intCounter).Volume, 6)
	//                    'End If
	//                    '----------------


	//                End If

	//                If gobjNewMethod.SampleDataCollection.item(intCounter).DilutionFactor = 0.0 Then
	//                    objRow.Item(ConstColumnDilutionFactor) = DBNull.Value
	//                Else
	//                    objRow.Item(ConstColumnDilutionFactor) = FormatNumber(gobjNewMethod.SampleDataCollection.item(intCounter).DilutionFactor, 6)
	//                End If

	//                mobjDtSample.Rows.Add(objRow)
	//            Next
	//        End If

	//        Return True
	//        '---------------------------------------Saurabh--------------------------------

	//        '''--------------------------------------Original----------------------------------------
	//        '''Dim intCounter As Integer
	//        '''Dim objRow As DataRow

	//        '''Try
	//        '''    For intCounter = 0 To gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.Count - 1
	//        '''        objDtSample.Rows.Item(intCounter).Item(ConstColumnSrNo) = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCounter).SampNumber
	//        '''        objDtSample.Rows.Item(intCounter).Item(ConstColumnSampleName) = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCounter).SampleName
	//        '''        objDtSample.Rows.Item(intCounter).Item(ConstColumnWeight) = FormatNumber(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCounter).Weight, 4)
	//        '''        objDtSample.Rows.Item(intCounter).Item(ConstColumnVolume) = FormatNumber(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCounter).Volume, 4)
	//        '''        objDtSample.Rows.Item(intCounter).Item(ConstColumnDilutionFactor) = FormatNumber(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCounter).DilutionFactor, 4)
	//        '''    Next

	//        '''    Return True
	//        '''--------------------------------------Original----------------------------------------

	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        'Error Handling and logging
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = ex.Message
	//        gobjErrorHandler.WriteErrorLog(ex)
	//        Return False
	//        '---------------------------------------------------------
	//    Finally
	//        '---------------------------------------------------------
	//        'Writing Execution log
	//        If CONST_CREATE_EXECUTION_LOG = 1 Then
	//            gobjErrorHandler.WriteExecutionLog()
	//        End If
	//        '---------------------------------------------------------
	//    End Try
	//End Function

	//Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
	//    '=====================================================================
	//    ' Procedure Name        : btnOk_Click
	//    ' Parameters Passed     : Object,EventArgs
	//    ' Returns               : None
	//    ' Purpose               : To send dialog result as ok
	//    ' Description           : 
	//    ' Assumptions           : 
	//    ' Dependencies          : 
	//    ' Author                : Deepak
	//    ' Created               : 05.10.06
	//    ' Revisions             : 
	//    '=====================================================================
	//    Dim objWait As New CWaitCursor
	//    Dim intCounter As Integer
	//    Dim objClsSampleParameters As clsAnalysisSampleParameters
	//    Dim objSamplesCollection As clsAnalysisSampleParametersCollection

	//    Try
	//        objSamplesCollection = New clsAnalysisSampleParametersCollection

	//        For intCounter = 0 To mobjDtSample.Rows.Count - 1
	//            If Trim(mobjDtSample.Rows(intCounter).Item(ConstColumnSampleName)) <> "" And Not IsDBNull(mobjDtSample.Rows(intCounter).Item(ConstColumnWeight)) And Not IsDBNull(mobjDtSample.Rows(intCounter).Item(ConstColumnVolume)) And Not IsDBNull(mobjDtSample.Rows(intCounter).Item(ConstColumnDilutionFactor)) Then
	//                If IsNumeric(Trim(mobjDtSample.Rows(intCounter).Item(ConstColumnWeight))) And IsNumeric(Trim(mobjDtSample.Rows(intCounter).Item(ConstColumnVolume))) And IsNumeric(Trim(mobjDtSample.Rows(intCounter).Item(ConstColumnDilutionFactor))) Then
	//                    objClsSampleParameters = New clsAnalysisSampleParameters
	//                    objClsSampleParameters.SampNumber = mobjDtSample.Rows(intCounter).Item(ConstColumnSrNo)
	//                    objClsSampleParameters.SampleName = mobjDtSample.Rows(intCounter).Item(ConstColumnSampleName)
	//                    objClsSampleParameters.Weight = mobjDtSample.Rows(intCounter).Item(ConstColumnWeight)
	//                    objClsSampleParameters.Volume = mobjDtSample.Rows(intCounter).Item(ConstColumnVolume)
	//                    objClsSampleParameters.DilutionFactor = mobjDtSample.Rows(intCounter).Item(ConstColumnDilutionFactor)

	//                    objSamplesCollection.Add(objClsSampleParameters)
	//                Else
	//                    gobjMessageAdapter.ShowMessage(constInputProperData)
	//                    Application.DoEvents()
	//                    Exit Sub
	//                End If
	//            Else
	//                gobjMessageAdapter.ShowMessage(constInputProperData)
	//                Application.DoEvents()
	//                Exit Sub
	//            End If
	//        Next
	//        'For intRunNo As Integer = 0 To gobjNewMethod.QuantitativeDataCollection.Count - 1
	//        For intCounter = 0 To gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.Count - 1
	//            If gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.Count > intCounter Then
	//                If gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCounter).Used = True Then
	//                    objSamplesCollection.item(intCounter).Used = True
	//                    'If gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCounter).Abs <> -1.0 Then
	//                    objSamplesCollection.item(intCounter).Abs = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCounter).Abs
	//                    'End If
	//            End If
	//            End If
	//        Next
	//        'Next
	//        gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.Clear()
	//        gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection = objSamplesCollection.Clone()

	//        '---Update Current Method in Method Collection
	//        For intCounter = 0 To gobjMethodCollection.Count - 1
	//            If gobjMethodCollection.item(intCounter).MethodID = gobjNewMethod.MethodID Then
	//                If (gobjMethodCollection.item(intCounter).QuantitativeDataCollection.Count >= gobjNewMethod.QuantitativeDataCollection.Count) Then
	//                    gobjMethodCollection.item(intCounter).QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.Clone()
	//                    gobjMethodCollection.item(intCounter).DateOfModification = DateTime.Now
	//                Else
	//                    'gobjMethodCollection.item(intCounter).QuantitativeDataCollection.Add(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex))
	//                    'gobjMethodCollection.item(intCounter).DateOfModification = DateTime.Now
	//                End If

	//            End If
	//        Next

	//        '---serialize method collection 
	//        'Call funcSerialize(ConstMethodsFileName, gobjMethodCollection)

	//        Call funcSaveAllMethods(gobjMethodCollection)


	//        Me.DialogResult = DialogResult.OK

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
	//        If Not objWait Is Nothing Then
	//            objWait.Dispose()
	//        End If
	//        '---------------------------------------------------------
	//    End Try
	//End Sub

	//Private Function funcLoadInitialData(ByVal intNoOfSamples As Integer) As Boolean
	//    'Private Function funcLoadInitialData(ByRef objDtSample As DataTable) As Boolean
	//    '=====================================================================
	//    ' Procedure Name        : funcLoadInitialData
	//    ' Parameters Passed     : None
	//    ' Returns               : True or False
	//    ' Purpose               : To load initial data
	//    ' Description           : 
	//    ' Assumptions           : 
	//    ' Dependencies          : 
	//    ' Author                : Deepak Bhati
	//    ' Created               : 08.10.06
	//    ' Revisions             : 2
	//    ' Revision By           : Mangesh S. on 28-Jan-2007
	//    ' Revision for          : Changes in AAS203Library
	//    '=====================================================================
	//    '---------------------------------------Saurabh--------------------------------
	//    Dim intCounter As Integer
	//    Dim objRow As DataRow
	//    Dim intInitialCount As Integer

	//    Try
	//        intInitialCount = CInt(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.Count)

	//        If intNoOfSamples > intInitialCount Then
	//            For intCounter = 0 To intInitialCount - 1
	//                objRow = mobjDtSample.NewRow
	//                objRow.Item(ConstColumnSrNo) = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCounter).SampNumber
	//                objRow.Item(ConstColumnSampleName) = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCounter).SampleName

	//                If gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCounter).Weight = 0.0 Then
	//                    objRow.Item(ConstColumnWeight) = DBNull.Value
	//                Else
	//                    objRow.Item(ConstColumnWeight) = FormatNumber(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCounter).Weight, 6)
	//                End If

	//                If gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCounter).Volume = 0.0 Then
	//                    objRow.Item(ConstColumnVolume) = DBNull.Value
	//                Else
	//                    'objRow.Item(ConstColumnVolume) = FormatNumber(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCounter).Volume, 6)
	//                    '------------------Added By Pankaj 11 May 07 6
	//                    'If gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.Unit = 2 And FormatNumber(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCounter).Volume, 6) < 100 Then
	//                    'objRow.Item(ConstColumnVolume) = 100 * FormatNumber(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCounter).Volume, 6)
	//                    'Else
	//                    objRow.Item(ConstColumnVolume) = FormatNumber(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCounter).Volume, 6)
	//                    'End If
	//                    '----------------

	//                End If

	//                If gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCounter).DilutionFactor = 0.0 Then
	//                    objRow.Item(ConstColumnDilutionFactor) = DBNull.Value
	//                Else
	//                    objRow.Item(ConstColumnDilutionFactor) = FormatNumber(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCounter).DilutionFactor, 6)
	//                End If

	//                mobjDtSample.Rows.Add(objRow)
	//            Next

	//            For intCounter = intInitialCount To intNoOfSamples - 1
	//                objRow = mobjDtSample.NewRow
	//                objRow.Item(ConstColumnSrNo) = intCounter + 1
	//                objRow.Item(ConstColumnSampleName) = ConstDefaultSampleName & intCounter + 1
	//                objRow.Item(ConstColumnWeight) = ConstDefaultValue
	//                objRow.Item(ConstColumnVolume) = ConstDefaultValue
	//                objRow.Item(ConstColumnDilutionFactor) = ConstDefaultValue
	//                mobjDtSample.Rows.Add(objRow)
	//            Next

	//        ElseIf intNoOfSamples < intInitialCount Then

	//            For intCounter = 0 To intNoOfSamples - 1
	//                objRow = mobjDtSample.NewRow
	//                objRow.Item(ConstColumnSrNo) = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCounter).SampNumber
	//                objRow.Item(ConstColumnSampleName) = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCounter).SampleName

	//                If gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCounter).Weight = 0.0 Then
	//                    objRow.Item(ConstColumnWeight) = DBNull.Value
	//                Else
	//                    objRow.Item(ConstColumnWeight) = FormatNumber(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCounter).Weight, 6)
	//                End If

	//                If gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCounter).Volume = 0.0 Then
	//                    objRow.Item(ConstColumnVolume) = DBNull.Value
	//                Else
	//                    '------------------Added By Pankaj 11 May 07 6
	//                    'If gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.Unit = 2 And FormatNumber(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCounter).Volume, 6) < 100 Then
	//                    '    objRow.Item(ConstColumnVolume) = 100 * FormatNumber(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCounter).Volume, 6)
	//                    'Else
	//                        objRow.Item(ConstColumnVolume) = FormatNumber(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCounter).Volume, 6)
	//                    'End If
	//                    '----------------

	//                    'objRow.Item(ConstColumnVolume) = FormatNumber(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCounter).Volume, 6)
	//                End If

	//                If gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCounter).DilutionFactor = 0.0 Then
	//                    objRow.Item(ConstColumnDilutionFactor) = DBNull.Value
	//                Else
	//                    objRow.Item(ConstColumnDilutionFactor) = FormatNumber(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCounter).DilutionFactor, 6)
	//                End If

	//                mobjDtSample.Rows.Add(objRow)
	//            Next
	//        Else
	//            For intCounter = 0 To intInitialCount - 1
	//                objRow = mobjDtSample.NewRow
	//                objRow.Item(ConstColumnSrNo) = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCounter).SampNumber
	//                objRow.Item(ConstColumnSampleName) = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCounter).SampleName

	//                If gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCounter).Weight = 0.0 Then
	//                    objRow.Item(ConstColumnWeight) = DBNull.Value
	//                Else
	//                    objRow.Item(ConstColumnWeight) = FormatNumber(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCounter).Weight, 6)
	//                End If

	//                If gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCounter).Volume = 0.0 Then
	//                    objRow.Item(ConstColumnVolume) = DBNull.Value
	//                Else
	//                    '------------------Added By Pankaj 11 May 07 6
	//                    'If gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.Unit = 2 And FormatNumber(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCounter).Volume, 6) < 100 Then
	//                    '    objRow.Item(ConstColumnVolume) = 100 * FormatNumber(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCounter).Volume, 6)
	//                    'Else
	//                        objRow.Item(ConstColumnVolume) = FormatNumber(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCounter).Volume, 6)
	//                    'End If
	//                    '----------------


	//                End If

	//                If gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCounter).DilutionFactor = 0.0 Then
	//                    objRow.Item(ConstColumnDilutionFactor) = DBNull.Value
	//                Else
	//                    objRow.Item(ConstColumnDilutionFactor) = FormatNumber(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCounter).DilutionFactor, 6)
	//                End If

	//                mobjDtSample.Rows.Add(objRow)
	//            Next
	//        End If

	//        Return True
	//        '---------------------------------------Saurabh--------------------------------

	//        '''--------------------------------------Original----------------------------------------
	//        '''Dim intCounter As Integer
	//        '''Dim objRow As DataRow

	//        '''Try
	//        '''    For intCounter = 0 To gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.Count - 1
	//        '''        objDtSample.Rows.Item(intCounter).Item(ConstColumnSrNo) = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCounter).SampNumber
	//        '''        objDtSample.Rows.Item(intCounter).Item(ConstColumnSampleName) = gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCounter).SampleName
	//        '''        objDtSample.Rows.Item(intCounter).Item(ConstColumnWeight) = FormatNumber(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCounter).Weight, 4)
	//        '''        objDtSample.Rows.Item(intCounter).Item(ConstColumnVolume) = FormatNumber(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCounter).Volume, 4)
	//        '''        objDtSample.Rows.Item(intCounter).Item(ConstColumnDilutionFactor) = FormatNumber(gobjNewMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(intCounter).DilutionFactor, 4)
	//        '''    Next

	//        '''    Return True
	//        '''--------------------------------------Original----------------------------------------

	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        'Error Handling and logging
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = ex.Message
	//        gobjErrorHandler.WriteErrorLog(ex)
	//        Return False
	//        '---------------------------------------------------------
	//    Finally
	//        '---------------------------------------------------------
	//        'Writing Execution log
	//        If CONST_CREATE_EXECUTION_LOG = 1 Then
	//            gobjErrorHandler.WriteExecutionLog()
	//        End If
	//        '---------------------------------------------------------
	//    End Try
	//End Function


	#End Region

	private void  // ERROR: Handles clauses are not supported in C#
btnChangeTiming_Click(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : btnChangeTiming_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To change the time of autosampler
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak
		// Created               : 05.10.06
		// Revisions             : 
		//=====================================================================
		//'note:
		//'this is called when user clicked on change timing button
		//'this is used for autosampler
		//'this will show a change timing dialog box.


		try {
			if ((gstructAutoSampler.blnCommunication == true)) {
				frmTimings objfrmtimings = new frmTimings();
				objfrmtimings.ShowDialog();
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

}
