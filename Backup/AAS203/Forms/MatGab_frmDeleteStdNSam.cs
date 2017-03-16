using AAS203.Common;
using AAS203Library;
using AAS203Library.Method;

//'class behind the class.
public class frmDeleteStdNSam : System.Windows.Forms.Form
{

	#Region " Windows Form Designer generated code "

	public frmDeleteStdNSam()
	{
		base.New();

		//This call is required by the Windows Form Designer.
		InitializeComponent();

		//Add any initialization after the InitializeComponent() call

	}

	public frmDeleteStdNSam(ref clsMethod objMethodIn, int intSelectedRunNumberIndex)
	{
		base.New();

		//This call is required by the Windows Form Designer.
		InitializeComponent();

		//Add any initialization after the InitializeComponent() call
		mobjclsMethod = objMethodIn;
		mintSelectedRunNumberIndex = intSelectedRunNumberIndex;

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
	internal GradientPanel.CustomPanel CustomPanel1;
	internal NETXP.Controls.XPButton btnOk;
	internal System.Windows.Forms.DataGrid dgViewResults;
	[System.Diagnostics.DebuggerStepThrough()]
	private void InitializeComponent()
	{
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmDeleteStdNSam));
		this.CustomPanel1 = new GradientPanel.CustomPanel();
		this.btnOk = new NETXP.Controls.XPButton();
		this.dgViewResults = new System.Windows.Forms.DataGrid();
		this.CustomPanel1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.dgViewResults).BeginInit();
		this.SuspendLayout();
		//
		//CustomPanel1
		//
		this.CustomPanel1.BackColor = System.Drawing.Color.AliceBlue;
		this.CustomPanel1.Controls.Add(this.btnOk);
		this.CustomPanel1.Controls.Add(this.dgViewResults);
		this.CustomPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.CustomPanel1.Location = new System.Drawing.Point(0, 0);
		this.CustomPanel1.Name = "CustomPanel1";
		this.CustomPanel1.Size = new System.Drawing.Size(506, 301);
		this.CustomPanel1.TabIndex = 2;
		//
		//btnOk
		//
		this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnOk.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnOk.Image = (System.Drawing.Image)resources.GetObject("btnOk.Image");
		this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnOk.Location = new System.Drawing.Point(210, 259);
		this.btnOk.Name = "btnOk";
		this.btnOk.Size = new System.Drawing.Size(86, 34);
		this.btnOk.TabIndex = 2;
		this.btnOk.Text = "&OK";
		//
		//dgViewResults
		//
		this.dgViewResults.CaptionVisible = false;
		this.dgViewResults.DataMember = "";
		this.dgViewResults.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.dgViewResults.HeaderForeColor = System.Drawing.SystemColors.ControlText;
		this.dgViewResults.Location = new System.Drawing.Point(15, 11);
		this.dgViewResults.Name = "dgViewResults";
		this.dgViewResults.Size = new System.Drawing.Size(476, 240);
		this.dgViewResults.TabIndex = 0;
		//
		//frmDeleteStdNSam
		//
		this.AcceptButton = this.btnOk;
		this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
		this.ClientSize = new System.Drawing.Size(506, 301);
		this.Controls.Add(this.CustomPanel1);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		this.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		this.MaximizeBox = false;
		this.MinimizeBox = false;
		this.Name = "frmDeleteStdNSam";
		this.ShowInTaskbar = false;
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Delete Standards/Samples";
		this.CustomPanel1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.dgViewResults).EndInit();
		this.ResumeLayout(false);

	}

	#End Region

	#Region " Private Variables"

	private DataTable mobjDtStandards;
	private DataGridClass mobjDtStandardsDataGrid;
	private clsMethod mobjclsMethod;
	private int mintSelectedRunNumberIndex;
		#End Region
	private string strColumnAbsorbance = "Absorbance";

	#Region " Private Constants "

	private const  ConstColumnSrNo = "SrNo";
	private const  ConstColumnStandardName = "StandardName";
	private const  ConstColumnAbsorbance = "Absorbance";

	private const  ConstColumnNameEmission = "%Emission";
	private const  ConstColumnConcentration = "Concentration";
	private const  ConstColumnRemove = "Remove";

	private const  ConstColumnIsStandard = "IsStandard";
	private const  ConstTitleSrNo = "Sr.No.";
	private const  ConstTitleStandardName = "Standard Name";
	private const  ConstTitleAbsorbance = "Absorbance";

	private const  ConstTitleEmission = "Emission";
	private const  ConstTitleConcentration = "Concentrations";

	private const  ConstTitleRemove = "Remove";
	private const  ConstWidthSrNo = 55;
	private const  ConstWidthStandardName = 100;
	private const  ConstWidthAbsorbance = 120;
	private const  ConstWidthConcentration = 120;

	private const  ConstWidthRemove = 60;
	private const  ConstParentFormLoad = "-DataFiles";

	private const  ConstFormLoad = "-DataFiles-Delete Standard/Sample";
	#End Region

	#Region " Form Events "

	private void  // ERROR: Handles clauses are not supported in C#
frmViewResults_Load(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : frmViewResults_Load
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To initialize and load the form
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : 
		// Created               : 
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		int intCounter;
		DataRow objRow;
		int intCount;

		try {
			gobjMain.ShowProgressBar(gstrTitleInstrumentType + ConstFormLoad);
			//'for showing some instrument info.
			//Call funcLoadInitialData()
			if (!(mobjclsMethod == null)) {
				if (mobjclsMethod.OperationMode == EnumOperationMode.MODE_EMMISSION) {
					strColumnAbsorbance = ConstTitleEmission;
				} else {
					strColumnAbsorbance = ConstTitleAbsorbance;
				}
			}
			AddHandlers();
			//'for adding event to a control.
			//---add columns to the datatable
			mobjDtStandards = new DataTable();
			//'creat a new object for a datastructure.
			mobjDtStandards.Columns.Add(ConstColumnSrNo, typeof(int));
			mobjDtStandards.Columns.Add(ConstColumnStandardName, typeof(string));
			//mobjDtStandards.Columns.Add(ConstColumnAbsorbance, GetType(Double))
			//mobjDtStandards.Columns.Add(ConstColumnConcentration, GetType(Double))
			mobjDtStandards.Columns.Add(ConstColumnAbsorbance, typeof(string));
			//Added By Pankaj on 04 Jun 07
			mobjDtStandards.Columns.Add(ConstColumnConcentration, typeof(string));
			//Added By Pankaj on 04 07
			mobjDtStandards.Columns.Add(ConstColumnRemove, typeof(bool));
			mobjDtStandards.Columns.Add(ConstColumnIsStandard, typeof(bool));
			mobjDtStandardsDataGrid = new DataGridClass(ConstDataGridPropertiesFileName);
			mobjDtStandardsDataGrid.AllowNew = false;
			mobjDtStandardsDataGrid.AdjustColumnWidthToGrid = false;

			mobjDtStandardsDataGrid.AddDataGridColumnStyle(mobjDtStandards.Columns(ConstColumnSrNo).ColumnName, dgViewResults, mobjDtStandards, DataGridClass.enumColumnType.TextBoxColumn, HorizontalAlignment.Center, ConstTitleSrNo, ConstWidthSrNo, true, DataGridClass.ColumnDataType.Text, HorizontalAlignment.Center);
			mobjDtStandardsDataGrid.AddDataGridColumnStyle(mobjDtStandards.Columns(ConstColumnStandardName).ColumnName, dgViewResults, mobjDtStandards, DataGridClass.enumColumnType.TextBoxColumn, HorizontalAlignment.Center, ConstTitleStandardName, ConstWidthStandardName, false, DataGridClass.ColumnDataType.Text, HorizontalAlignment.Left);
			mobjDtStandardsDataGrid.AddDataGridColumnStyle(mobjDtStandards.Columns(ConstColumnAbsorbance).ColumnName, dgViewResults, mobjDtStandards, DataGridClass.enumColumnType.TextBoxColumn, HorizontalAlignment.Center, strColumnAbsorbance, ConstWidthAbsorbance, false, DataGridClass.ColumnDataType.Text, HorizontalAlignment.Center);
			mobjDtStandardsDataGrid.AddDataGridColumnStyle(mobjDtStandards.Columns(ConstColumnConcentration).ColumnName, dgViewResults, mobjDtStandards, DataGridClass.enumColumnType.TextBoxColumn, HorizontalAlignment.Center, ConstTitleConcentration, ConstWidthConcentration, false, DataGridClass.ColumnDataType.Text, HorizontalAlignment.Center);
			mobjDtStandardsDataGrid.AddDataGridColumnStyle(mobjDtStandards.Columns(ConstColumnRemove).ColumnName, dgViewResults, mobjDtStandards, DataGridClass.enumColumnType.BoolColumn, HorizontalAlignment.Center, ConstTitleRemove, ConstWidthRemove, true, DataGridClass.ColumnDataType.Text, HorizontalAlignment.Center);

			//---load initial data on screen
			funcLoadInitialData();

			//---bind datatable to the datagrid
			mobjDtStandardsDataGrid.SetDataGridProperties(dgViewResults, mobjDtStandards);

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
frmDeleteStdNSam_Closing(object sender, System.ComponentModel.CancelEventArgs e)
	{
		//=====================================================================
		// Procedure Name        : frmDeleteStdNSam_Closing
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : THIS IS USED TO close the form.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : 
		// Created               : 
		// Revisions             : 
		//=====================================================================
		//'note:
		//'this is called when user close the form.
		gobjMain.ShowRunTimeInfo(gstrTitleInstrumentType + ConstParentFormLoad);
	}

	#End Region

	#Region " Private Functions"

	private void AddHandlers()
	{
		//=====================================================================
		// Procedure Name        : AddHandlers
		// Parameters Passed     : 
		// Returns               : None
		// Purpose               :for adding a event to a control.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : 
		// Created               : 
		// Revisions             : praveen
		//=====================================================================
		//'note:
		//'this is called during a loading of a form.
		//add event handlers
		btnOk.Click += btnOk_Click;
		dgViewResults.MouseDown += subdgStdConcentrationListMouseDown;
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
		double dblConc;
		DataRow objRow;

		try {
			//---to add standard rows to the datatable
			//---Standards
			if (mobjDtStandards == null) {
				return;
			}
			if (mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex) == null) {
				return;
			}
			for (intCounter = 0; intCounter <= mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).StandardDataCollection.Count - 1; intCounter++) {
				objRow = mobjDtStandards.NewRow;
				objRow.Item(ConstColumnSrNo) = mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).StandardDataCollection.item(intCounter).StdNumber;
				objRow.Item(ConstColumnStandardName) = mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).StandardDataCollection.item(intCounter).StdName;

				//Saurabh To format the Abs value upto 3 decimal places 20.07.07
				objRow.Item(ConstColumnAbsorbance) = Format(mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).StandardDataCollection.item(intCounter).Abs, "0.000");
				//Saurabh To format the concentration value upto 2 decimal places 20.07.07

				//---commented on 27.03.09
				//'objRow.Item(ConstColumnConcentration) = Format(mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).StandardDataCollection.item(intCounter).Concentration, "0.00")
				//-------

				//---written on 27.03.09
				if (mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).AnalysisParameters.Unit == enumUnit.PPM) {
					objRow.Item(ConstColumnConcentration) = Format(mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).StandardDataCollection.item(intCounter).Concentration, "0.00");
				} else if (mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).AnalysisParameters.Unit == enumUnit.Percent) {
					objRow.Item(ConstColumnConcentration) = Format(mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).StandardDataCollection.item(intCounter).Concentration, "0.00");
				} else if (mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).AnalysisParameters.Unit == enumUnit.PPB) {
					objRow.Item(ConstColumnConcentration) = Format(mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).StandardDataCollection.item(intCounter).Concentration, "0.0000");
				}
				//---------

				objRow.Item(ConstColumnRemove) = false;
				objRow.Item(ConstColumnIsStandard) = true;
				mobjDtStandards.Rows.Add(objRow);
			}


			//---- Added by Mangesh on 10-May-2007

			//---to add sample rows to the datatable
			//---Samples
			for (intCounter = 0; intCounter <= mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).SampleDataCollection.Count - 1; intCounter++) {
				objRow = mobjDtStandards.NewRow;
				objRow.Item(ConstColumnSrNo) = mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).SampleDataCollection.item(intCounter).SampNumber;
				//objRow.Item(ConstColumnStandardName) = mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).SampleDataCollection.item(intCounter).SampleName
				objRow.Item(ConstColumnStandardName) = mobjclsMethod.SampleDataCollection.item(intCounter).SampleName;
				objRow.Item(ConstColumnAbsorbance) = Format(mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).SampleDataCollection.item(intCounter).Abs, "0.000");
				//objRow.Item(ConstColumnConcentration) = Format(mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).SampleDataCollection.item(intCounter).Conc, "0.000000")
				if (mobjclsMethod.StandardAddition == true) {
					dblConc = (string)mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).SampleDataCollection.item(intCounter).Conc;
				} else {
					dblConc = gobjclsStandardGraph.Get_Conc(mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).SampleDataCollection.item(intCounter).Abs, 0.0);
				}

				//----commented on 27.03.09
				///objRow.Item(ConstColumnConcentration) = Format(dblConc, "0.00")
				//------

				//----written on 27.03.09
				if (mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).AnalysisParameters.Unit == enumUnit.PPM) {
					objRow.Item(ConstColumnConcentration) = Format(dblConc, "0.00");
				} else if (mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).AnalysisParameters.Unit == enumUnit.Percent) {
					objRow.Item(ConstColumnConcentration) = Format(dblConc, "0.00");
				} else if (mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).AnalysisParameters.Unit == enumUnit.PPB) {
					objRow.Item(ConstColumnConcentration) = Format(dblConc, "0.0000");
				}
				//----------

				if (mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).SampleDataCollection.item(intCounter).Used) {
					objRow.Item(ConstColumnRemove) = false;
				} else {
					objRow.Item(ConstColumnRemove) = true;
				}
				//---------Added By Pankaj on 04 Jun 07 
				if ((double)objRow.Item(ConstColumnAbsorbance) == -1) {
					objRow.Item(ConstColumnAbsorbance) = " ";
					objRow.Item(ConstColumnConcentration) = " ";
				}
				//--------
				objRow.Item(ConstColumnIsStandard) = false;
				mobjDtStandards.Rows.Add(objRow);
			}
			mobjDtStandards.Columns.Item(ConstColumnSrNo).ReadOnly = true;
			mobjDtStandards.Columns.Item(ConstColumnStandardName).ReadOnly = true;
			mobjDtStandards.Columns.Item(ConstColumnConcentration).ReadOnly = true;
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

	private bool funcUpdataMethodCollection()
	{
		//=====================================================================
		// Procedure Name        : funcUpdataMethodCollection
		// Parameters Passed     : None
		// Returns               : True/False
		// Purpose               :  To remove the user selected Standards/Sample from Method
		// Description           : On mouse down Update the selected Standard/Sample
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : Wednesday, May 14, 2008
		// Revisions             : Sachin Dokhale
		//=====================================================================
		int intRowsCounter;
		int intMethodCounter;
		int intSampleCounter;
		int intStdCounter;
		bool blnIsSampleDeleted;

		try {
			for (intMethodCounter = 0; intMethodCounter <= gobjMethodCollection.Count - 1; intMethodCounter++) {
				//'make a counter up to a last data.
				if (mobjclsMethod.MethodID == gobjMethodCollection.item(intMethodCounter).MethodID) {
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			//remove selected standard or sample by using used flag

			for (intRowsCounter = 0; intRowsCounter <= mobjDtStandards.Rows.Count - 1; intRowsCounter++) {
				if (!mobjDtStandards.Rows.Item(intRowsCounter).Item(ConstColumnIsStandard)) {
					for (intSampleCounter = 0; intSampleCounter <= mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).SampleDataCollection.Count - 1; intSampleCounter++) {
						if (mobjDtStandards.Rows.Item(intRowsCounter).Item(ConstColumnSrNo) == mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).SampleDataCollection.item(intSampleCounter).SampNumber & Trim(mobjDtStandards.Rows.Item(intRowsCounter).Item(ConstColumnStandardName)) == Trim(mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).SampleDataCollection.item(intSampleCounter).SampleName)) {
							if (mobjDtStandards.Rows.Item(intRowsCounter).Item(ConstColumnRemove)) {
								if (mobjclsMethod.QuantitativeDataCollection.Count > mintSelectedRunNumberIndex) {
									mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).SampleDataCollection.item(intSampleCounter).Used = false;
								}
								if (gobjMethodCollection.item(intMethodCounter).QuantitativeDataCollection.Count > mintSelectedRunNumberIndex) {
									gobjMethodCollection.item(intMethodCounter).QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).SampleDataCollection.item(intSampleCounter).Used = false;
								}
							} else {
								if (mobjclsMethod.QuantitativeDataCollection.Count > mintSelectedRunNumberIndex) {
									mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).SampleDataCollection.item(intSampleCounter).Used = true;
								}
								if (gobjMethodCollection.item(intMethodCounter).QuantitativeDataCollection.Count > mintSelectedRunNumberIndex) {
									gobjMethodCollection.item(intMethodCounter).QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).SampleDataCollection.item(intSampleCounter).Used = true;
								}
							}
							//Saurabh 19.07.07 To check DBNull
							if (!IsDBNull(mobjDtStandards.Rows.Item(intRowsCounter).Item(ConstColumnAbsorbance))) {
								if (!Trim(mobjDtStandards.Rows.Item(intRowsCounter).Item(ConstColumnAbsorbance)) == "") {
									if (mobjclsMethod.QuantitativeDataCollection.Count > mintSelectedRunNumberIndex) {
										mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).SampleDataCollection.item(intSampleCounter).Abs = mobjDtStandards.Rows.Item(intRowsCounter).Item(ConstColumnAbsorbance);
									}
									if (gobjMethodCollection.item(intMethodCounter).QuantitativeDataCollection.Count > mintSelectedRunNumberIndex) {
										gobjMethodCollection.item(intMethodCounter).QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).SampleDataCollection.item(intSampleCounter).Abs = mobjDtStandards.Rows.Item(intRowsCounter).Item(ConstColumnAbsorbance);
									}
								}
							}
							//Saurabh 19.07.07 To check DBNull
						}
					}

				}
			}

			for (intRowsCounter = 0; intRowsCounter <= mobjDtStandards.Rows.Count - 1; intRowsCounter++) {
				if (mobjDtStandards.Rows.Item(intRowsCounter).Item(ConstColumnIsStandard) == true) {
					for (intStdCounter = 0; intStdCounter <= mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).StandardDataCollection.Count - 1; intStdCounter++) {
						if (mobjDtStandards.Rows.Item(intRowsCounter).Item(ConstColumnSrNo) == mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).StandardDataCollection.item(intStdCounter).StdNumber & Trim(mobjDtStandards.Rows.Item(intRowsCounter).Item(ConstColumnStandardName)) == Trim(mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).StandardDataCollection.item(intStdCounter).StdName)) {
							if (!IsDBNull(mobjDtStandards.Rows.Item(intRowsCounter).Item(ConstColumnAbsorbance))) {
								if (!Trim(mobjDtStandards.Rows.Item(intRowsCounter).Item(ConstColumnAbsorbance)) == "") {
									if (mobjclsMethod.QuantitativeDataCollection.Count > mintSelectedRunNumberIndex) {
										mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).StandardDataCollection.item(intStdCounter).Abs = mobjDtStandards.Rows.Item(intRowsCounter).Item(ConstColumnAbsorbance);
									}
									if (gobjMethodCollection.item(intMethodCounter).QuantitativeDataCollection.Count > mintSelectedRunNumberIndex) {
										gobjMethodCollection.item(intMethodCounter).QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).StandardDataCollection.item(intStdCounter).Abs = mobjDtStandards.Rows.Item(intRowsCounter).Item(ConstColumnAbsorbance);
									}
								}
							}
						}
					}
				}
			}

			//---save all methods to method collection
			funcSaveAllMethods(gobjMethodCollection);
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
			//---------------------------------------------------------
		}

	}

	private void btnOk_Click(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : btnOk_Click
		// Parameters Passed     : Object, EventArgs
		// Returns               : None
		// Purpose               : To remove the user selected Standards from Method
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 05-Apr-2007 04:05 pm
		// Revisions             : 
		//=====================================================================

		//'note;
		//'this is called when user click OK button.
		//'this will handle a OK button event.
		//'To remove the user selected Standards from Method

		//Dim intRowsCounter As Integer
		//Dim intMethodCounter As Integer
		//Dim intSampleCounter As Integer
		//Dim intStdCounter As Integer
		//Dim blnIsSampleDeleted As Boolean
		CWaitCursor objWait = new CWaitCursor();
		try {
			//For intMethodCounter = 0 To gobjMethodCollection.Count - 1
			//    ''make a counter up to a last data.
			//    If mobjclsMethod.MethodID = gobjMethodCollection.item(intMethodCounter).MethodID Then
			//        Exit For
			//    End If
			//Next

			//'remove selected standard or sample by using used flag

			//For intRowsCounter = 0 To mobjDtStandards.Rows.Count - 1
			//    If Not mobjDtStandards.Rows.Item(intRowsCounter).Item(ConstColumnIsStandard) Then
			//        For intSampleCounter = 0 To mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).SampleDataCollection.Count - 1
			//            If mobjDtStandards.Rows.Item(intRowsCounter).Item(ConstColumnSrNo) = mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).SampleDataCollection.item(intSampleCounter).SampNumber And _
			//                Trim(mobjDtStandards.Rows.Item(intRowsCounter).Item(ConstColumnStandardName)) = Trim(mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).SampleDataCollection.item(intSampleCounter).SampleName) Then
			//                If mobjDtStandards.Rows.Item(intRowsCounter).Item(ConstColumnRemove) Then
			//                    If mobjclsMethod.QuantitativeDataCollection.Count > mintSelectedRunNumberIndex Then
			//                        mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).SampleDataCollection.item(intSampleCounter).Used = False
			//                    End If
			//                    If gobjMethodCollection.item(intMethodCounter).QuantitativeDataCollection.Count > mintSelectedRunNumberIndex Then
			//                        gobjMethodCollection.item(intMethodCounter).QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).SampleDataCollection.item(intSampleCounter).Used = False
			//                    End If
			//                Else
			//                    If mobjclsMethod.QuantitativeDataCollection.Count > mintSelectedRunNumberIndex Then
			//                        mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).SampleDataCollection.item(intSampleCounter).Used = True
			//                    End If
			//                    If gobjMethodCollection.item(intMethodCounter).QuantitativeDataCollection.Count > mintSelectedRunNumberIndex Then
			//                        gobjMethodCollection.item(intMethodCounter).QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).SampleDataCollection.item(intSampleCounter).Used = True
			//                    End If
			//                End If
			//                'Saurabh 19.07.07 To check DBNull
			//                If Not IsDBNull(mobjDtStandards.Rows.Item(intRowsCounter).Item(ConstColumnAbsorbance)) Then
			//                    If Not Trim(mobjDtStandards.Rows.Item(intRowsCounter).Item(ConstColumnAbsorbance)) = "" Then
			//                        If mobjclsMethod.QuantitativeDataCollection.Count > mintSelectedRunNumberIndex Then
			//                            mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).SampleDataCollection.item(intSampleCounter).Abs = mobjDtStandards.Rows.Item(intRowsCounter).Item(ConstColumnAbsorbance)
			//                        End If
			//                        If gobjMethodCollection.item(intMethodCounter).QuantitativeDataCollection.Count > mintSelectedRunNumberIndex Then
			//                            gobjMethodCollection.item(intMethodCounter).QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).SampleDataCollection.item(intSampleCounter).Abs = mobjDtStandards.Rows.Item(intRowsCounter).Item(ConstColumnAbsorbance)
			//                        End If
			//                    End If
			//                End If
			//                'Saurabh 19.07.07 To check DBNull
			//            End If
			//        Next

			//    End If
			//Next intRowsCounter

			//For intRowsCounter = 0 To mobjDtStandards.Rows.Count - 1
			//    If mobjDtStandards.Rows.Item(intRowsCounter).Item(ConstColumnIsStandard) = True Then
			//        For intStdCounter = 0 To mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).StandardDataCollection.Count - 1
			//            If mobjDtStandards.Rows.Item(intRowsCounter).Item(ConstColumnSrNo) = mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).StandardDataCollection.item(intStdCounter).StdNumber And _
			//                Trim(mobjDtStandards.Rows.Item(intRowsCounter).Item(ConstColumnStandardName)) = Trim(mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).StandardDataCollection.item(intStdCounter).StdName) Then
			//                If Not IsDBNull(mobjDtStandards.Rows.Item(intRowsCounter).Item(ConstColumnAbsorbance)) Then
			//                    If Not Trim(mobjDtStandards.Rows.Item(intRowsCounter).Item(ConstColumnAbsorbance)) = "" Then
			//                        If mobjclsMethod.QuantitativeDataCollection.Count > mintSelectedRunNumberIndex Then
			//                            mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).StandardDataCollection.item(intStdCounter).Abs = mobjDtStandards.Rows.Item(intRowsCounter).Item(ConstColumnAbsorbance)
			//                        End If
			//                        If gobjMethodCollection.item(intMethodCounter).QuantitativeDataCollection.Count > mintSelectedRunNumberIndex Then
			//                            gobjMethodCollection.item(intMethodCounter).QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).StandardDataCollection.item(intStdCounter).Abs = mobjDtStandards.Rows.Item(intRowsCounter).Item(ConstColumnAbsorbance)
			//                        End If
			//                    End If
			//                End If
			//            End If
			//        Next
			//    End If
			//Next intRowsCounter

			//'---save all methods to method collection
			//Call funcSaveAllMethods(gobjMethodCollection)
			funcUpdataMethodCollection();
			this.DialogResult = DialogResult.OK;

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			this.DialogResult = DialogResult.Cancel;
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			//---------------------------------------------------------
			Application.DoEvents();
			objWait.Dispose();
		}
	}

	private void subdgStdConcentrationListMouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
	{
		//=====================================================================
		// Procedure Name        : subdgStdConcentrationListMouseDown
		// Parameters Passed     : Object,MouseEventArgs
		// Returns               : None
		// Purpose               : To remove the selected standard from datatable
		// Description           : On mouse down remove the selected standard
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : Wednesday, December 08, 2004
		// Revisions             : praveencheck 08.10.06
		//=====================================================================
		DataGrid.HitTestInfo hit;
		//'datagrid variable for holding a info.
		int intCounter;
		DataRow objRow;

		try {
			hit = dgViewResults.HitTest(e.X, e.Y);
			//'get a current info to be displayed.

			if (hit.Type == DataGrid.HitTestType.Cell) {
				mobjDtStandards.Columns.Item(ConstColumnConcentration).ReadOnly = true;
				switch (hit.Column) {
					case 4:
						if (mobjDtStandards.Rows.Item(hit.Row).Item(ConstColumnIsStandard)) {
							mobjDtStandards.Rows.Item(hit.Row).Item(ConstColumnRemove) = false;
						} else {
							mobjDtStandards.Rows.Item(hit.Row).Item(ConstColumnRemove) = !mobjDtStandards.Rows.Item(hit.Row).Item(ConstColumnRemove);
						}
					case 2:
					//Call funcUpdataMethodCollection()
					//mobjDtStandards.Columns.Item(ConstColumnConcentration).ReadOnly = False
					//If mobjDtStandards Is Nothing Then
					//    Exit Sub
					//End If
					//If mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex) Is Nothing Then
					//    Exit Sub
					//End If
					//Dim dblConc As Double
					//If mobjclsMethod.StandardAddition = True Then
					//    dblConc = CStr(mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).SampleDataCollection.item(intCounter).Conc)
					//Else
					//    dblConc = gobjclsStandardGraph.Get_Conc(mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).SampleDataCollection.item(intCounter).Abs, 0.0)
					//End If
					//mobjDtStandards.Rows.Item(hit.Row).Item(ConstColumnConcentration) = Format(dblConc, "0.00")
					//mobjDtStandards.Columns.Item(ConstColumnConcentration).ReadOnly = True
					//objRow.Item(ConstColumnConcentration) = Format(dblConc, "0.00")
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
			//---------------------------------------------------------
			Application.DoEvents();
		}
	}

	#End Region

}
