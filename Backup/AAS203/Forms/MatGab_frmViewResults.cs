using AAS203.Common;
using AAS203Library.Method;

public class frmViewResults : System.Windows.Forms.Form
{

	#Region " Windows Form Designer generated code "

	public frmViewResults()
	{
		base.New();

		//This call is required by the Windows Form Designer.
		InitializeComponent();

		//Add any initialization after the InitializeComponent() call
		mblnIsAnalysisMode = true;
		mintSelectedRunNumber = 0;

	}

	public frmViewResults(bool blnIsAnalysisMode, int intSelectedMethodID, int intSelectedRunNumber, clsMethod objClsMethod)
	{
		base.New();

		//This call is required by the Windows Form Designer.
		InitializeComponent();

		//Add any initialization after the InitializeComponent() call
		mblnIsAnalysisMode = blnIsAnalysisMode;
		mintSelectedRunNumber = intSelectedRunNumber;
		mintSelectedMethodID = intSelectedMethodID;
		mobjClsMethod = objClsMethod.Clone;

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
	internal CodeIntellects.Office2003Controls.Office2003Header Office2003Header1;
	internal GradientPanel.CustomPanel CustomPanel1;
	internal System.Windows.Forms.DataGrid dgViewResults;
	internal NETXP.Controls.XPButton btnOk;
	[System.Diagnostics.DebuggerStepThrough()]
	private void InitializeComponent()
	{
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmViewResults));
		this.Office2003Header1 = new CodeIntellects.Office2003Controls.Office2003Header();
		this.CustomPanel1 = new GradientPanel.CustomPanel();
		this.btnOk = new NETXP.Controls.XPButton();
		this.dgViewResults = new System.Windows.Forms.DataGrid();
		this.CustomPanel1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.dgViewResults).BeginInit();
		this.SuspendLayout();
		//
		//Office2003Header1
		//
		this.Office2003Header1.BackColor = System.Drawing.SystemColors.Control;
		this.Office2003Header1.Dock = System.Windows.Forms.DockStyle.Top;
		this.Office2003Header1.Location = new System.Drawing.Point(0, 0);
		this.Office2003Header1.Name = "Office2003Header1";
		this.Office2003Header1.Size = new System.Drawing.Size(722, 20);
		this.Office2003Header1.TabIndex = 0;
		this.Office2003Header1.TitleFont = new System.Drawing.Font("Tahoma", 10f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.Office2003Header1.TitleText = "Standard/Sample Absorbance and Concentration";
		//
		//CustomPanel1
		//
		this.CustomPanel1.BackColor = System.Drawing.Color.AliceBlue;
		this.CustomPanel1.Controls.Add(this.btnOk);
		this.CustomPanel1.Controls.Add(this.dgViewResults);
		this.CustomPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.CustomPanel1.Location = new System.Drawing.Point(0, 0);
		this.CustomPanel1.Name = "CustomPanel1";
		this.CustomPanel1.Size = new System.Drawing.Size(722, 303);
		this.CustomPanel1.TabIndex = 1;
		//
		//btnOk
		//
		this.btnOk.Anchor = (System.Windows.Forms.AnchorStyles)System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnOk.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnOk.Image = (System.Drawing.Image)resources.GetObject("btnOk.Image");
		this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnOk.Location = new System.Drawing.Point(301, 260);
		this.btnOk.Name = "btnOk";
		this.btnOk.Size = new System.Drawing.Size(100, 36);
		this.btnOk.TabIndex = 2;
		this.btnOk.Text = "OK";
		//
		//dgViewResults
		//
		this.dgViewResults.Anchor = (System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right;
		this.dgViewResults.CaptionVisible = false;
		this.dgViewResults.DataMember = "";
		this.dgViewResults.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.dgViewResults.HeaderForeColor = System.Drawing.SystemColors.ControlText;
		this.dgViewResults.Location = new System.Drawing.Point(4, 24);
		this.dgViewResults.Name = "dgViewResults";
		this.dgViewResults.Size = new System.Drawing.Size(714, 229);
		this.dgViewResults.TabIndex = 0;
		//
		//frmViewResults
		//
		this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
		this.ClientSize = new System.Drawing.Size(722, 303);
		this.Controls.Add(this.Office2003Header1);
		this.Controls.Add(this.CustomPanel1);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		this.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		this.MaximizeBox = false;
		this.MinimizeBox = false;
		this.Name = "frmViewResults";
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "View Results";
		this.CustomPanel1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.dgViewResults).EndInit();
		this.ResumeLayout(false);

	}

	#End Region

	#Region " Private Class Member Variables "

	private DataTable mobjDtSample;
	private DataGridClass mobjDtSampleDataGridclass;
	private bool mblnIsAnalysisMode;
	private int mintRunNumberIndex;
	private int mintSelectedRunNumber;
	private int mintSelectedMethodID;

	private clsMethod mobjClsMethod = new clsMethod();
	#End Region

	#Region " Private Constants "

	private const  ConstFormLoadDataFiles = "-DataFiles-ViewResults";
	private const  ConstFormLoadAnalysis = "-Analysis-ViewResults";
	private const  ConstParentFormLoadDataFiles = "-DataFiles";

	private const  ConstParentFormLoadAnalysis = "-Analysis";
	//---Column Names Constants
	private const  ConstColumnSrNo = "SrNo";
	private const  ConstColumnSampleName = "SampleName";
	private const  ConstColumnWeight = "Weight";
	private const  ConstColumnVolume = "Volume";
	private const  ConstColumnDilutionFactor = "DilutionFactor";
	private const  ConstColumnAbs = "Abs";
	private const  ConstColumnEnergy = "% Emission";
	private const  ConstColumnConcInPPM = "ConcInPPM";
	//Private Const ConstColumnConcInPercentage = "ConcInPer"

	private const  ConstColumnTotalConc = "TotalConc";
	//---Column Captions Constants
	private const  ConstTitleSrNo = "Sr.No.";
	private const  ConstTitleSampleName = "Sample Name ";
	private const  ConstTitleWeight = "Weight (gms)";
	private const  ConstTitleVolume = "Volume (ml)";
	private const  ConstTitleDilutionFactor = "Dilution Factor";
	private const  ConstTitleAbs = "Abs";
	private const  ConstTitleEnergy = "% Emission";
	private const  ConstTitleConcInPPM = "Conc. (ppm)";

	private const  ConstTitleConcInPPB = "Conc. (ppb)";
	//Private Const ConstTitleConcInPercentage = "Conc. (%)"

	//---4.85  14.04.09
	//Private Const ConstTitleTotalConcInPPM = "Total Conc. (PPM)"
	//Private Const ConstTitleTotalConcInPercent = "Total Conc. (%)"
	//Private Const ConstTitleTotalConcInPPB = "Total Conc. (PPB)"
	//---4.85  14.04.09

	//---4.85  14.04.09
	private const  ConstTitleTotalConcInPPM = "Conc. in Sample (ppm)";
	private const  ConstTitleTotalConcInPercent = "Conc. in Sample (%)";
	private const  ConstTitleTotalConcInPPB = "Conc. in Sample (ppb)";
	//---4.85  14.04.09

	//---Column Default Values Constants
	private const  ConstDefaultValue = "1.0000";

	private const  ConstDefaultSampleName = "Sample ";
	//---Column Width Constants
	private const  ConstWidthSrNo = 50;
	private const  ConstWidthSampleName = 95;
		//95
	private const  ConstWidthWeight = 90;
		//95
	private const  ConstWidthVolume = 90;
	private const  ConstWidthDilutionFactor = 95;
	private const  ConstWidthAbs = 50;

	private const  ConstWidthEnergy = 80;
	private const  ConstWidthConcInPercentage = 90;
	private const  ConstWidthConcInPPM = 90;

	private const  ConstWidthConcInPPB = 90;
		//110
	private const  ConstWidthTotalConcInPercentage = 150;
		//110
	private const  ConstWidthTotalConcInPPM = 150;
		//110
	private const  ConstWidthTotalConcInPPB = 150;

	#End Region

	#Region " Form Load Events "

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

		//case	WM_INITDIALOG :
		//hbr  = CreateSolidBrush(RGB(0, 255,255));
		//hfont = CreateFont(-11, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "Arial");
		//SendDlgItemMessage(hwnd, IDOK, WM_SETFONT,(WPARAM) hfont, 0L);
		//SendDlgItemMessage(hwnd, IDC_RESULT, WM_SETFONT,(WPARAM) hfont, 0L);
		//SendDlgItemMessage(hwnd, IDC_RESULT, LB_SETTABSTOPS,(WPARAM) 7,(LPARAM) tabs);
		//SetAbsEmnWindow(hwnd);
		//InitShowResults(hwnd);
		//return TRUE;

		try {
			if (mblnIsAnalysisMode) {
				gobjMain.ShowProgressBar(gstrTitleInstrumentType + ConstFormLoadAnalysis);
			} else {
				gobjMain.ShowProgressBar(gstrTitleInstrumentType + ConstFormLoadDataFiles);
			}

			//Saurabh 01.08.07
			if (!IsNothing(mobjClsMethod)) {
				if (mobjClsMethod.OperationMode == EnumOperationMode.MODE_EMMISSION) {
					Office2003Header1.TitleText = "Standard/Sample Emission and Concentration";
				} else {
					Office2003Header1.TitleText = "Standard/Sample Absorbance and Concentration";
				}
			}
			//Saurabh 01.08.07
			//update data grid
			mobjDtSampleDataGridclass = new DataGridClass(ConstDataGridPropertiesFileName);
			mobjDtSampleDataGridclass.AllowNew = false;
			mobjDtSampleDataGridclass.AdjustColumnWidthToGrid = false;

			mobjDtSample = new DataTable();
			mobjDtSample.Columns.Add(ConstColumnSrNo);
			mobjDtSample.Columns.Add(ConstColumnSampleName);
			mobjDtSample.Columns.Add(ConstColumnWeight);
			mobjDtSample.Columns.Add(ConstColumnVolume);
			mobjDtSample.Columns.Add(ConstColumnDilutionFactor);
			if (mobjClsMethod.OperationMode == EnumOperationMode.MODE_EMMISSION) {
				mobjDtSample.Columns.Add(ConstColumnEnergy);
			} else {
				mobjDtSample.Columns.Add(ConstColumnAbs);
			}
			mobjDtSample.Columns.Add(ConstColumnConcInPPM);
			mobjDtSample.Columns.Add(ConstColumnTotalConc);

			if (mblnIsAnalysisMode) {
				mobjClsMethod = gobjNewMethod.Clone;
			}

			if (mblnIsAnalysisMode) {
				//---For Analysis Mode
				if (mobjClsMethod.QuantitativeDataCollection.Count > 0) {
					mintRunNumberIndex = mobjClsMethod.QuantitativeDataCollection.Count - 1;
				} else {
					mintRunNumberIndex = 0;
				}
			} else {
				//---For Data Files Mode
				mintRunNumberIndex = gfuncGetSelectedMethodRunNumberIndex(mintSelectedMethodID, mintSelectedRunNumber);
			}
			//Call InitShowResults()
			//Added by pankaj bamb on 21 Feb 08
			if (mblnIsAnalysisMode == true) {
				InitShowResults();
			} else {
				InitShowResultsForMethod();
			}
		//-------------------


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
			gobjMain.HideProgressBar();
			//---------------------------------------------------------
		}
	}

	private void  // ERROR: Handles clauses are not supported in C#
frmViewResults_Closing(object sender, System.ComponentModel.CancelEventArgs e)
	{
		//=====================================================================
		// Procedure Name        : frmViewResults_Closing
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 01-Feb-2007 08:25 pm
		// Revisions             : 1
		//=====================================================================
		if (mblnIsAnalysisMode) {
			gobjMain.ShowRunTimeInfo(gstrTitleInstrumentType + ConstParentFormLoadAnalysis);
		} else {
			gobjMain.ShowRunTimeInfo(gstrTitleInstrumentType + ConstParentFormLoadDataFiles);
		}
	}

	private void  // ERROR: Handles clauses are not supported in C#
btnOk_Click(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : btnOk_Click
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 01-Feb-2007 08:25 pm
		// Revisions             : 1
		//=====================================================================
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
			//---------------------------------------------------------
		}
	}

	#End Region

	#Region " Private functions "

	private void InitShowResults()
	{
		//=====================================================================
		// Procedure Name        : InitShowResults
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 01-Feb-2007 08:35 pm
		// Revisions             : 1
		//=====================================================================


		//void InitShowResults(HWND hwnd)
		//{
		//	SAMPDATA		*samp=NULL;
		//	STDDATA		    *std=NULL;
		//	BOOL			unit=FALSE;
		//	char			str[256]="";
		//	char			str1[80]="";
		//	int	i;
		//	HDC		hdc;

		//	unit=Method->QuantData->Param.Unit;
		//	
		//   If (unit) Then
		//	{
		//		
		//		SetWindowText(GetDlgItem(hwnd, IDC_TCONC1), (LPCSTR) "Total Conc in ppm");
		//		SetWindowText(GetDlgItem(hwnd, IDC_TCONC), (LPCSTR) "Conc in ppm");
		//	}
		//   Else
		//	{
		//		SetWindowText(GetDlgItem(hwnd, IDC_TCONC1), (LPCSTR) "Total Conc in %");
		//		SetWindowText(GetDlgItem(hwnd, IDC_TCONC), (LPCSTR) "Conc in ppm");
		//	}
		//	SendMessage(GetDlgItem(hwnd,IDC_RESULT), LB_RESETCONTENT, 0, 0L);
		//	std=Method->QuantData->StdTopData;
		//	i=1;
		//	hdc = GetDC(hwnd);

		//   While (std! = NULL)
		//	{
		//		if (std->Data.Abs>-0.2 && std->Data.Used)
		//		{
		//			strcpy(str1,""); strcpy(str,"");
		//			sprintf(str,"%-2d\t", i);
		//			sprintf(str1,"%s\t", std->Data.Std_Name);
		//			strcat(str, str1);
		//			sprintf(str1,"   -\t" );
		//			strcat(str, str1);
		//			sprintf(str1,"   -\t" );
		//			strcat(str, str1);
		//			sprintf(str1,"   -\t" );
		//			strcat(str, str1);
		//			if (Method->Mode==MODE_EMISSION)
		//				sprintf(str1,"%-4.1f %%\t", std->Data.Abs);
		//           Else
		//			{
		//				StoreAbsAccurate(std->Data.Abs,str1);  
		//				strcat(str1,"\t");
		//				//sprintf(str1,"%-4.3f\t",std->Data.Abs);
		//			}
		//			strcat(str, str1);
		//			StoreResultAccurate(std->Data.Conc, str1, Method->QuantData->Param.No_Decimals);
		//			strcat(str, str1); strcat(str,"\t");
		//			SendMessage(GetDlgItem(hwnd,IDC_RESULT), LB_ADDSTRING, 0, (DWORD) (LPSTR) str);
		//			i++;
		//		}
		//		std=std->next;
		//	}

		//	samp=Method->QuantData->SampTopData;

		//   While (samp! = NULL)
		//	{
		//		if (samp->Data.Abs>-0.2 && samp->Data.Used)
		//		{
		//			strcpy(str1,""); strcpy(str,"");
		//			sprintf(str,"%-2d\t",  samp->Data.SampNo);
		//			sprintf(str1,"%-s\t", samp->Data.Samp_Name);
		//			strcat(str, str1);
		//			sprintf(str1,"%-7.4f\t",samp->Data.Weight );
		//			strcat(str, str1);
		//			sprintf(str1,"%-7.4f\t",samp->Data.Volume);
		//			strcat(str, str1);
		//			sprintf(str1,"%-7.4f\t",samp->Data.Dil_Fact);
		//			strcat(str, str1);
		//#If STD_ADDN Then
		//				if(Method->QuantData->Param.Std_Addn)
		//					sprintf(str1,"-\t", samp->Data.Abs);
		//				else
		//				{
		//					if (Method->Mode==MODE_EMISSION)
		//						sprintf(str1,"%-4.1f %%\t", samp->Data.Abs);
		//					else
		//					{
		//						StoreAbsAccurate(samp->Data.Abs,str1);
		//						strcat(str1,"\t");
		//						
		//					}
		//				}
		//#Else
		//				if (Method->Mode==MODE_EMISSION)
		//					sprintf(str1,"%-4.1f %%\t", samp->Data.Abs);
		//                                Else
		//					sprintf(str1,"%-4.3f\t",samp->Data.Abs );
		//#End If

		//			strcat(str, str1);

		//#If STD_ADDN Then
		//			if(Method->QuantData->Param.Std_Addn)
		//				sprintf(str1,"-\t", samp->Data.Abs);
		//			else
		//				StoreResultAccurate(samp->Data.Conc, str1, Method->QuantData->Param.No_Decimals);
		//#Else
		//				StoreResultAccurate(samp->Data.Conc, str1, Method->QuantData->Param.No_Decimals);
		//#End If
		//			strcat(str, str1); strcat(str,"\t");
		//			StoreResultAccurate(Get_percent(samp->Data.Conc, samp->Data.Weight,
		//								samp->Data.Volume,samp->Data.Dil_Fact,
		//								Method->QuantData->Param.Unit,
		//								Method->QuantData->Param.No_Decimals
		//								),
		//			str1, Method->QuantData->Param.No_Decimals);

		//			strcat(str, str1);
		//			SendMessage(GetDlgItem(hwnd,IDC_RESULT), LB_ADDSTRING, 0, (DWORD) (LPSTR) str);
		//			i++;
		//		}
		//		samp=samp->next;
		//	}
		//	ReleaseDC(hwnd, hdc); 
		//}

		Common.CWaitCursor objWaitCursor = new Common.CWaitCursor();

		AAS203Library.Method.clsAnalysisStdParameters std;
		AAS203Library.Method.clsAnalysisSampleParameters samp;
		AAS203Library.Method.clsAnalysisSampleParameters sampParant;
		int i;
		int minCnt;
		int unit = 0;
		string str;
		string str1;
		DataRow objDrNewRow;
		double dblConc;
		int intNoOfDecimalPlaces;
		try {
			if (IsNothing(mobjClsMethod.QuantitativeDataCollection)) {
				return;
			}

			if (mobjClsMethod.QuantitativeDataCollection.Count == 0) {
				return;
			}

			unit = mobjClsMethod.AnalysisParameters.Unit;
			//1 = PPM  And 2 = %
			intNoOfDecimalPlaces = (int)mobjClsMethod.AnalysisParameters.NumOfDecimalPlaces;


			mobjDtSampleDataGridclass.AddDataGridColumnStyle(ConstColumnSrNo, dgViewResults, mobjDtSample, DataGridClass.enumColumnType.TextBoxColumn, HorizontalAlignment.Center, ConstTitleSrNo, ConstWidthSrNo, true);
			mobjDtSampleDataGridclass.AddDataGridColumnStyle(ConstColumnSampleName, dgViewResults, mobjDtSample, DataGridClass.enumColumnType.TextBoxColumn, HorizontalAlignment.Left, ConstTitleSampleName, ConstWidthSampleName, true);
			mobjDtSampleDataGridclass.AddDataGridColumnStyle(ConstColumnWeight, dgViewResults, mobjDtSample, DataGridClass.enumColumnType.TextBoxColumn, HorizontalAlignment.Center, ConstTitleWeight, ConstWidthWeight, true);
			mobjDtSampleDataGridclass.AddDataGridColumnStyle(ConstColumnVolume, dgViewResults, mobjDtSample, DataGridClass.enumColumnType.TextBoxColumn, HorizontalAlignment.Center, ConstTitleVolume, ConstWidthVolume, true);
			mobjDtSampleDataGridclass.AddDataGridColumnStyle(ConstColumnDilutionFactor, dgViewResults, mobjDtSample, DataGridClass.enumColumnType.TextBoxColumn, HorizontalAlignment.Center, ConstTitleDilutionFactor, ConstWidthDilutionFactor, true);
			if (mobjClsMethod.OperationMode == EnumOperationMode.MODE_EMMISSION) {
				mobjDtSampleDataGridclass.AddDataGridColumnStyle(ConstColumnEnergy, dgViewResults, mobjDtSample, DataGridClass.enumColumnType.TextBoxColumn, HorizontalAlignment.Center, ConstTitleEnergy, ConstWidthEnergy, true);
			} else {
				mobjDtSampleDataGridclass.AddDataGridColumnStyle(ConstColumnAbs, dgViewResults, mobjDtSample, DataGridClass.enumColumnType.TextBoxColumn, HorizontalAlignment.Center, ConstTitleAbs, ConstWidthAbs, true);
			}

			//---commented on 27.03.09
			//'mobjDtSampleDataGridclass.AddDataGridColumnStyle(ConstColumnConcInPPM, dgViewResults, mobjDtSample, DataGridClass.enumColumnType.TextBoxColumn, HorizontalAlignment.Center, ConstTitleConcInPPM, ConstWidthConcInPPM, True)
			//-------------

			//---written on 27.03.09
			if (unit == enumUnit.PPB) {
				mobjDtSampleDataGridclass.AddDataGridColumnStyle(ConstColumnConcInPPM, dgViewResults, mobjDtSample, DataGridClass.enumColumnType.TextBoxColumn, HorizontalAlignment.Center, ConstTitleConcInPPB, ConstWidthConcInPPB, true);
			} else {
				mobjDtSampleDataGridclass.AddDataGridColumnStyle(ConstColumnConcInPPM, dgViewResults, mobjDtSample, DataGridClass.enumColumnType.TextBoxColumn, HorizontalAlignment.Center, ConstTitleConcInPPM, ConstWidthConcInPPM, true);
			}
			//----------------

			//commented on 27.03.09
			//---Unit is PPM
			//'If unit = 1 Then
			//'    mobjDtSampleDataGridclass.AddDataGridColumnStyle(ConstColumnTotalConc, dgViewResults, mobjDtSample, DataGridClass.enumColumnType.TextBoxColumn, HorizontalAlignment.Center, ConstTitleTotalConcInPPM, ConstWidthTotalConcInPPM, True)
			//'Else
			//'    '---Unit is %
			//'    mobjDtSampleDataGridclass.AddDataGridColumnStyle(ConstColumnTotalConc, dgViewResults, mobjDtSample, DataGridClass.enumColumnType.TextBoxColumn, HorizontalAlignment.Center, ConstTitleTotalConcInPercent, ConstWidthTotalConcInPercentage, True)
			//'End If

			//written on 27.03.09
			if (unit == enumUnit.PPM) {
				mobjDtSampleDataGridclass.AddDataGridColumnStyle(ConstColumnTotalConc, dgViewResults, mobjDtSample, DataGridClass.enumColumnType.TextBoxColumn, HorizontalAlignment.Center, ConstTitleTotalConcInPPM, ConstWidthTotalConcInPPM, true);
			} else if (unit == enumUnit.Percent) {
				mobjDtSampleDataGridclass.AddDataGridColumnStyle(ConstColumnTotalConc, dgViewResults, mobjDtSample, DataGridClass.enumColumnType.TextBoxColumn, HorizontalAlignment.Center, ConstTitleTotalConcInPercent, ConstWidthTotalConcInPercentage, true);
			} else if (unit == enumUnit.PPB) {
				mobjDtSampleDataGridclass.AddDataGridColumnStyle(ConstColumnTotalConc, dgViewResults, mobjDtSample, DataGridClass.enumColumnType.TextBoxColumn, HorizontalAlignment.Center, ConstTitleTotalConcInPPB, ConstWidthTotalConcInPPB, true);
			}
			//-----------

			i = 0;
			// add Standard collection data into data table to print object
			for (i = 0; i <= mobjClsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.Count - 1; i++) {
				std = mobjClsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(i);

				if ((std.Abs > -0.2 & std.Used)) {
					objDrNewRow = mobjDtSample.NewRow;

					if (!std.StdName == "") {
						objDrNewRow.Item(ConstColumnSampleName) = std.StdName;
					} else {
						objDrNewRow.Item(ConstColumnSampleName) = ConstDefaultSampleName;
					}

					objDrNewRow.Item(ConstColumnSrNo) = i + 1;
					objDrNewRow.Item(ConstColumnSampleName) = std.StdName;
					objDrNewRow.Item(ConstColumnWeight) = "";
					objDrNewRow.Item(ConstColumnVolume) = "";
					objDrNewRow.Item(ConstColumnDilutionFactor) = "";
					objDrNewRow.Item(ConstColumnConcInPPM) = FormatNumber(std.Concentration, intNoOfDecimalPlaces);
					objDrNewRow.Item(ConstColumnTotalConc) = "";

					if ((mobjClsMethod.OperationMode == EnumOperationMode.MODE_EMMISSION)) {
						//sprintf(str1,"%-4.1f %%\t", std->Data.Abs);
						// Set the format of decimal point to the data for emission
						objDrNewRow.Item(ConstColumnEnergy) = FormatNumber(std.Abs, CONST_Format_Value_Emission);
					} else {
						// Set the format of decimal point to the data 
						//StoreAbsAccurate(std->Data.Abs,str1);  
						//strcat(str1,"\t");
						objDrNewRow.Item(ConstColumnAbs) = FormatNumber(std.Abs, CONST_Format_Value_Absorbance);
					}
					//StoreResultAccurate(std->Data.Conc, str1, Method->QuantData->Param.No_Decimals);

					mobjDtSample.Rows.Add(objDrNewRow);
				}

			}

			i = 0;
			// add Sasmple collection data into data table to print object
			////----- Modified by Sachin Dokhale
			//For i = 0 To mobjClsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.Count - 1
			if (mobjClsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.Count < mobjClsMethod.SampleDataCollection.Count) {
				minCnt = mobjClsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.Count;
			} else {
				minCnt = mobjClsMethod.SampleDataCollection.Count;
			}
			//For i = 0 To mobjClsMethod.SampleDataCollection.Count - 1'comment by pankaj on 23 Mar 08
			// by pankaj on 23 Mar08 to handle index exception
			for (i = 0; i <= mobjClsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.Count - 1; i++) {

				samp = mobjClsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(i);
				//sampParant = mobjClsMethod.SampleDataCollection.item(i)'comment by pankaj on 23 Mar 08
				if ((samp.Abs > -0.2 & samp.Used)) {
					if (i < mobjClsMethod.SampleDataCollection.Count) {
						sampParant = mobjClsMethod.SampleDataCollection.item(i);
						//added by pankaj on 23 Mar 08
					}
					objDrNewRow = mobjDtSample.NewRow;

					str1 = "";
					str = "";
					objDrNewRow.Item(ConstColumnSrNo) = i + 1;
					objDrNewRow.Item(ConstColumnSampleName) = sampParant.SampleName;
					objDrNewRow.Item(ConstColumnWeight) = Format(sampParant.Weight, "0.000");
					objDrNewRow.Item(ConstColumnVolume) = Format(sampParant.Volume, "0.000");
					objDrNewRow.Item(ConstColumnDilutionFactor) = Format(sampParant.DilutionFactor, "0.000");
					if (mobjClsMethod.OperationMode == EnumOperationMode.MODE_EMMISSION) {
						objDrNewRow.Item(ConstColumnEnergy) = FormatNumber(samp.Abs, CONST_Format_Value_Emission);
					} else {
						objDrNewRow.Item(ConstColumnAbs) = FormatNumber(samp.Abs, CONST_Format_Value_Absorbance);
					}
					////-----    added by Sachin Dokhale on 19.05.07
					//dblConc = Format(gobjclsStandardGraph.Get_Conc(samp.Abs, 0.0), "0.000")
					if (mobjClsMethod.StandardAddition == true) {
						// Set the Conc. data for Standard Addition
						dblConc = samp.Conc;
					} else {
						// Get the Conc. data from giver Abs 
						dblConc = gobjclsStandardGraph.Get_Conc(samp.Abs, 0.0);
					}
					////----

					objDrNewRow.Item(ConstColumnConcInPPM) = FormatNumber(dblConc, intNoOfDecimalPlaces);

					double dblConcInPercent;
					double dblConcInPpm;
					// Cal. Conc. data into percentage
					dblConcInPercent = (dblConc * sampParant.Volume * sampParant.DilutionFactor * Math.Pow(10, -6)) / sampParant.Weight;
					//---following line is added by deepak on 18.08.07
					dblConcInPpm = (dblConc * sampParant.Volume * sampParant.DilutionFactor) / sampParant.Weight;
					dblConcInPercent = dblConcInPercent * 100;

					//27.03.09
					// if unit in PPM the uses Conc. else use percentage of Conc.
					//'If unit = 1 Then
					//'    '---Unit is PPM
					//'    'objDrNewRow.Item(ConstColumnConcInPercentage) = dblConc
					//'    'objDrNewRow.Item(ConstColumnTotalConc) = FormatNumber(dblConc, intNoOfDecimalPlaces)
					//'    '---following line is added by deepak on 18.08.07
					//'    objDrNewRow.Item(ConstColumnTotalConc) = FormatNumber(dblConcInPpm, intNoOfDecimalPlaces)
					//'Else
					//'    '---Unit is Percentage
					//'    'objDrNewRow.Item(ConstColumnConcInPercentage) = dblConcInPercent
					//'    objDrNewRow.Item(ConstColumnTotalConc) = FormatNumber(dblConcInPercent, intNoOfDecimalPlaces)
					//'End If
					//--------------

					//27.03.09
					if (unit == enumUnit.PPM) {
						objDrNewRow.Item(ConstColumnTotalConc) = FormatNumber(dblConcInPpm, intNoOfDecimalPlaces);
					} else if (unit == enumUnit.Percent) {
						objDrNewRow.Item(ConstColumnTotalConc) = FormatNumber(dblConcInPercent, intNoOfDecimalPlaces);
					} else if (unit == enumUnit.PPB) {
						objDrNewRow.Item(ConstColumnTotalConc) = FormatNumber(dblConcInPpm, intNoOfDecimalPlaces);
					}
					//----------------

					// add into data table of selected Run no
					mobjDtSample.Rows.Add(objDrNewRow);
				}
			}
			// set Data ViewResult property 
			mobjDtSampleDataGridclass.SetDataGridProperties(dgViewResults, mobjDtSample);

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
			objWaitCursor.Dispose();
			//---------------------------------------------------------
		}
	}

	private void InitShowResultsForMethod()
	{
		//=====================================================================
		// Procedure Name        : InitShowResultsForMethod
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : for Method show values form run number
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : pankaj h. bamb
		// Created               : 21-Feb-2008 
		// Revisions             : 1
		//=====================================================================


		//void InitShowResults(HWND hwnd)
		//{
		//	SAMPDATA		*samp=NULL;
		//	STDDATA		    *std=NULL;
		//	BOOL			unit=FALSE;
		//	char			str[256]="";
		//	char			str1[80]="";
		//	int	i;
		//	HDC		hdc;

		//	unit=Method->QuantData->Param.Unit;
		//	
		//   If (unit) Then
		//	{
		//		
		//		SetWindowText(GetDlgItem(hwnd, IDC_TCONC1), (LPCSTR) "Total Conc in ppm");
		//		SetWindowText(GetDlgItem(hwnd, IDC_TCONC), (LPCSTR) "Conc in ppm");
		//	}
		//   Else
		//	{
		//		SetWindowText(GetDlgItem(hwnd, IDC_TCONC1), (LPCSTR) "Total Conc in %");
		//		SetWindowText(GetDlgItem(hwnd, IDC_TCONC), (LPCSTR) "Conc in ppm");
		//	}
		//	SendMessage(GetDlgItem(hwnd,IDC_RESULT), LB_RESETCONTENT, 0, 0L);
		//	std=Method->QuantData->StdTopData;
		//	i=1;
		//	hdc = GetDC(hwnd);

		//   While (std! = NULL)
		//	{
		//		if (std->Data.Abs>-0.2 && std->Data.Used)
		//		{
		//			strcpy(str1,""); strcpy(str,"");
		//			sprintf(str,"%-2d\t", i);
		//			sprintf(str1,"%s\t", std->Data.Std_Name);
		//			strcat(str, str1);
		//			sprintf(str1,"   -\t" );
		//			strcat(str, str1);
		//			sprintf(str1,"   -\t" );
		//			strcat(str, str1);
		//			sprintf(str1,"   -\t" );
		//			strcat(str, str1);
		//			if (Method->Mode==MODE_EMISSION)
		//				sprintf(str1,"%-4.1f %%\t", std->Data.Abs);
		//           Else
		//			{
		//				StoreAbsAccurate(std->Data.Abs,str1);  
		//				strcat(str1,"\t");
		//				//sprintf(str1,"%-4.3f\t",std->Data.Abs);
		//			}
		//			strcat(str, str1);
		//			StoreResultAccurate(std->Data.Conc, str1, Method->QuantData->Param.No_Decimals);
		//			strcat(str, str1); strcat(str,"\t");
		//			SendMessage(GetDlgItem(hwnd,IDC_RESULT), LB_ADDSTRING, 0, (DWORD) (LPSTR) str);
		//			i++;
		//		}
		//		std=std->next;
		//	}

		//	samp=Method->QuantData->SampTopData;

		//   While (samp! = NULL)
		//	{
		//		if (samp->Data.Abs>-0.2 && samp->Data.Used)
		//		{
		//			strcpy(str1,""); strcpy(str,"");
		//			sprintf(str,"%-2d\t",  samp->Data.SampNo);
		//			sprintf(str1,"%-s\t", samp->Data.Samp_Name);
		//			strcat(str, str1);
		//			sprintf(str1,"%-7.4f\t",samp->Data.Weight );
		//			strcat(str, str1);
		//			sprintf(str1,"%-7.4f\t",samp->Data.Volume);
		//			strcat(str, str1);
		//			sprintf(str1,"%-7.4f\t",samp->Data.Dil_Fact);
		//			strcat(str, str1);
		//#If STD_ADDN Then
		//				if(Method->QuantData->Param.Std_Addn)
		//					sprintf(str1,"-\t", samp->Data.Abs);
		//				else
		//				{
		//					if (Method->Mode==MODE_EMISSION)
		//						sprintf(str1,"%-4.1f %%\t", samp->Data.Abs);
		//					else
		//					{
		//						StoreAbsAccurate(samp->Data.Abs,str1);
		//						strcat(str1,"\t");
		//						
		//					}
		//				}
		//#Else
		//				if (Method->Mode==MODE_EMISSION)
		//					sprintf(str1,"%-4.1f %%\t", samp->Data.Abs);
		//                                Else
		//					sprintf(str1,"%-4.3f\t",samp->Data.Abs );
		//#End If

		//			strcat(str, str1);

		//#If STD_ADDN Then
		//			if(Method->QuantData->Param.Std_Addn)
		//				sprintf(str1,"-\t", samp->Data.Abs);
		//			else
		//				StoreResultAccurate(samp->Data.Conc, str1, Method->QuantData->Param.No_Decimals);
		//#Else
		//				StoreResultAccurate(samp->Data.Conc, str1, Method->QuantData->Param.No_Decimals);
		//#End If
		//			strcat(str, str1); strcat(str,"\t");
		//			StoreResultAccurate(Get_percent(samp->Data.Conc, samp->Data.Weight,
		//								samp->Data.Volume,samp->Data.Dil_Fact,
		//								Method->QuantData->Param.Unit,
		//								Method->QuantData->Param.No_Decimals
		//								),
		//			str1, Method->QuantData->Param.No_Decimals);

		//			strcat(str, str1);
		//			SendMessage(GetDlgItem(hwnd,IDC_RESULT), LB_ADDSTRING, 0, (DWORD) (LPSTR) str);
		//			i++;
		//		}
		//		samp=samp->next;
		//	}
		//	ReleaseDC(hwnd, hdc); 
		//}

		Common.CWaitCursor objWaitCursor = new Common.CWaitCursor();

		AAS203Library.Method.clsAnalysisStdParameters std;
		AAS203Library.Method.clsAnalysisSampleParameters samp;
		//Dim sampParant As AAS203Library.Method.clsAnalysisSampleParameters
		int i;
		int unit = 0;
		string str;
		string str1;
		DataRow objDrNewRow;
		double dblConc;
		int intNoOfDecimalPlaces;
		try {
			if (IsNothing(mobjClsMethod.QuantitativeDataCollection)) {
				return;
			}

			if (mobjClsMethod.QuantitativeDataCollection.Count == 0) {
				return;
			}

			//unit = mobjClsMethod.AnalysisParameters.Unit 'by pankaj
			unit = mobjClsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.Unit;
			//by pankaj on 21 feb 08
			//1 = PPM  And 2 = %
			//intNoOfDecimalPlaces = CInt(mobjClsMethod.AnalysisParameters.NumOfDecimalPlaces)
			intNoOfDecimalPlaces = (int)mobjClsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).AnalysisParameters.NumOfDecimalPlaces;


			mobjDtSampleDataGridclass.AddDataGridColumnStyle(ConstColumnSrNo, dgViewResults, mobjDtSample, DataGridClass.enumColumnType.TextBoxColumn, HorizontalAlignment.Center, ConstTitleSrNo, ConstWidthSrNo, true);
			mobjDtSampleDataGridclass.AddDataGridColumnStyle(ConstColumnSampleName, dgViewResults, mobjDtSample, DataGridClass.enumColumnType.TextBoxColumn, HorizontalAlignment.Left, ConstTitleSampleName, ConstWidthSampleName, true);
			mobjDtSampleDataGridclass.AddDataGridColumnStyle(ConstColumnWeight, dgViewResults, mobjDtSample, DataGridClass.enumColumnType.TextBoxColumn, HorizontalAlignment.Center, ConstTitleWeight, ConstWidthWeight, true);
			mobjDtSampleDataGridclass.AddDataGridColumnStyle(ConstColumnVolume, dgViewResults, mobjDtSample, DataGridClass.enumColumnType.TextBoxColumn, HorizontalAlignment.Center, ConstTitleVolume, ConstWidthVolume, true);
			mobjDtSampleDataGridclass.AddDataGridColumnStyle(ConstColumnDilutionFactor, dgViewResults, mobjDtSample, DataGridClass.enumColumnType.TextBoxColumn, HorizontalAlignment.Center, ConstTitleDilutionFactor, ConstWidthDilutionFactor, true);
			if (mobjClsMethod.OperationMode == EnumOperationMode.MODE_EMMISSION) {
				mobjDtSampleDataGridclass.AddDataGridColumnStyle(ConstColumnEnergy, dgViewResults, mobjDtSample, DataGridClass.enumColumnType.TextBoxColumn, HorizontalAlignment.Center, ConstTitleEnergy, ConstWidthEnergy, true);
			} else {
				mobjDtSampleDataGridclass.AddDataGridColumnStyle(ConstColumnAbs, dgViewResults, mobjDtSample, DataGridClass.enumColumnType.TextBoxColumn, HorizontalAlignment.Center, ConstTitleAbs, ConstWidthAbs, true);
			}
			//---commented on 27.03.09
			//mobjDtSampleDataGridclass.AddDataGridColumnStyle(ConstColumnConcInPPM, dgViewResults, mobjDtSample, DataGridClass.enumColumnType.TextBoxColumn, HorizontalAlignment.Center, ConstTitleConcInPPM, ConstWidthConcInPPM, True)
			//-----

			//---written on 27.03.09
			if (unit == enumUnit.PPB) {
				mobjDtSampleDataGridclass.AddDataGridColumnStyle(ConstColumnConcInPPM, dgViewResults, mobjDtSample, DataGridClass.enumColumnType.TextBoxColumn, HorizontalAlignment.Center, ConstTitleConcInPPB, ConstWidthConcInPPB, true);
			} else {
				mobjDtSampleDataGridclass.AddDataGridColumnStyle(ConstColumnConcInPPM, dgViewResults, mobjDtSample, DataGridClass.enumColumnType.TextBoxColumn, HorizontalAlignment.Center, ConstTitleConcInPPM, ConstWidthConcInPPM, true);
			}
			//----------------

			//'--- 27.03.09
			//'---Unit is PPM
			//'If unit = 1 Then
			//'    mobjDtSampleDataGridclass.AddDataGridColumnStyle(ConstColumnTotalConc, dgViewResults, mobjDtSample, DataGridClass.enumColumnType.TextBoxColumn, HorizontalAlignment.Center, ConstTitleTotalConcInPPM, ConstWidthTotalConcInPPM, True)
			//'Else
			//'    '---Unit is %
			//'    mobjDtSampleDataGridclass.AddDataGridColumnStyle(ConstColumnTotalConc, dgViewResults, mobjDtSample, DataGridClass.enumColumnType.TextBoxColumn, HorizontalAlignment.Center, ConstTitleTotalConcInPercent, ConstWidthTotalConcInPercentage, True)
			//'End If


			//written on 27.03.09
			if (unit == enumUnit.PPM) {
				mobjDtSampleDataGridclass.AddDataGridColumnStyle(ConstColumnTotalConc, dgViewResults, mobjDtSample, DataGridClass.enumColumnType.TextBoxColumn, HorizontalAlignment.Center, ConstTitleTotalConcInPPM, ConstWidthTotalConcInPPM, true);
			} else if (unit == enumUnit.Percent) {
				mobjDtSampleDataGridclass.AddDataGridColumnStyle(ConstColumnTotalConc, dgViewResults, mobjDtSample, DataGridClass.enumColumnType.TextBoxColumn, HorizontalAlignment.Center, ConstTitleTotalConcInPercent, ConstWidthTotalConcInPercentage, true);
			} else if (unit == enumUnit.PPB) {
				mobjDtSampleDataGridclass.AddDataGridColumnStyle(ConstColumnTotalConc, dgViewResults, mobjDtSample, DataGridClass.enumColumnType.TextBoxColumn, HorizontalAlignment.Center, ConstTitleTotalConcInPPB, ConstWidthTotalConcInPPB, true);
			}
			//-----------


			i = 0;
			// add Standard collection data into data table to print object
			for (i = 0; i <= mobjClsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.Count - 1; i++) {
				std = mobjClsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).StandardDataCollection.item(i);

				if ((std.Abs > -0.2 & std.Used)) {
					objDrNewRow = mobjDtSample.NewRow;

					if (!std.StdName == "") {
						objDrNewRow.Item(ConstColumnSampleName) = std.StdName;
					} else {
						objDrNewRow.Item(ConstColumnSampleName) = ConstDefaultSampleName;
					}

					objDrNewRow.Item(ConstColumnSrNo) = i + 1;
					objDrNewRow.Item(ConstColumnSampleName) = std.StdName;
					objDrNewRow.Item(ConstColumnWeight) = "";
					objDrNewRow.Item(ConstColumnVolume) = "";
					objDrNewRow.Item(ConstColumnDilutionFactor) = "";
					objDrNewRow.Item(ConstColumnConcInPPM) = FormatNumber(std.Concentration, intNoOfDecimalPlaces);
					objDrNewRow.Item(ConstColumnTotalConc) = "";

					if ((mobjClsMethod.OperationMode == EnumOperationMode.MODE_EMMISSION)) {
						//sprintf(str1,"%-4.1f %%\t", std->Data.Abs);
						// Set the format of decimal point to the data for emission
						objDrNewRow.Item(ConstColumnEnergy) = FormatNumber(std.Abs, CONST_Format_Value_Emission);
					} else {
						// Set the format of decimal point to the data 
						//StoreAbsAccurate(std->Data.Abs,str1);  
						//strcat(str1,"\t");
						objDrNewRow.Item(ConstColumnAbs) = FormatNumber(std.Abs, CONST_Format_Value_Absorbance);
					}
					//StoreResultAccurate(std->Data.Conc, str1, Method->QuantData->Param.No_Decimals);

					mobjDtSample.Rows.Add(objDrNewRow);
				}

			}

			i = 0;
			// add Sasmple collection data into data table to print object
			////----- Modified by Sachin Dokhale
			for (i = 0; i <= mobjClsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.Count - 1; i++) {
				//For i = 0 To mobjClsMethod.SampleDataCollection.Count - 1 'comment by pankaj on 21 feb 08
				samp = mobjClsMethod.QuantitativeDataCollection.Item(mintRunNumberIndex).SampleDataCollection.item(i);
				//sampParant = mobjClsMethod.SampleDataCollection.item(i)
				if ((samp.Abs > -0.2 & samp.Used)) {
					objDrNewRow = mobjDtSample.NewRow;

					str1 = "";
					str = "";
					objDrNewRow.Item(ConstColumnSrNo) = i + 1;
					//objDrNewRow.Item(ConstColumnSampleName) = sampParant.SampleName
					//objDrNewRow.Item(ConstColumnWeight) = Format(sampParant.Weight, "0.000")
					//objDrNewRow.Item(ConstColumnVolume) = Format(sampParant.Volume, "0.000")
					//objDrNewRow.Item(ConstColumnDilutionFactor) = Format(sampParant.DilutionFactor, "0.000")
					//Added by Pankaj  on 21 Feb 08
					objDrNewRow.Item(ConstColumnSampleName) = samp.SampleName;
					objDrNewRow.Item(ConstColumnWeight) = Format(samp.Weight, "0.000");
					objDrNewRow.Item(ConstColumnVolume) = Format(samp.Volume, "0.000");
					objDrNewRow.Item(ConstColumnDilutionFactor) = Format(samp.DilutionFactor, "0.000");

					if (mobjClsMethod.OperationMode == EnumOperationMode.MODE_EMMISSION) {
						objDrNewRow.Item(ConstColumnEnergy) = FormatNumber(samp.Abs, CONST_Format_Value_Emission);
					} else {
						objDrNewRow.Item(ConstColumnAbs) = FormatNumber(samp.Abs, CONST_Format_Value_Absorbance);
					}
					////-----    added by Sachin Dokhale on 19.05.07
					//dblConc = Format(gobjclsStandardGraph.Get_Conc(samp.Abs, 0.0), "0.000")
					if (mobjClsMethod.StandardAddition == true) {
						// Set the Conc. data for Standard Addition
						dblConc = samp.Conc;
					} else {
						// Get the Conc. data from giver Abs 
						dblConc = gobjclsStandardGraph.Get_Conc(samp.Abs, 0.0);
					}
					////----

					objDrNewRow.Item(ConstColumnConcInPPM) = FormatNumber(dblConc, intNoOfDecimalPlaces);

					double dblConcInPercent;
					double dblConcInPpm;
					// Cal. Conc. data into percentage
					//dblConcInPercent = (dblConc * sampParant.Volume * sampParant.DilutionFactor * Math.Pow(10, -6)) / sampParant.Weight
					//'---following line is added by deepak on 18.08.07
					//dblConcInPpm = (dblConc * sampParant.Volume * sampParant.DilutionFactor) / sampParant.Weight

					dblConcInPercent = (dblConc * samp.Volume * samp.DilutionFactor * Math.Pow(10, -6)) / samp.Weight;
					//---following line is added by deepak on 18.08.07
					dblConcInPpm = (dblConc * samp.Volume * samp.DilutionFactor) / samp.Weight;
					//----------------

					dblConcInPercent = dblConcInPercent * 100;

					//---27.03.09
					// if unit in PPM the uses Conc. else use percentage of Conc.
					//'If unit = 1 Then
					//'    '---Unit is PPM
					//'    'objDrNewRow.Item(ConstColumnConcInPercentage) = dblConc
					//'    'objDrNewRow.Item(ConstColumnTotalConc) = FormatNumber(dblConc, intNoOfDecimalPlaces)
					//'    '---following line is added by deepak on 18.08.07
					//'    objDrNewRow.Item(ConstColumnTotalConc) = FormatNumber(dblConcInPpm, intNoOfDecimalPlaces)
					//'Else
					//'    '---Unit is Percentage
					//'    'objDrNewRow.Item(ConstColumnConcInPercentage) = dblConcInPercent
					//'    objDrNewRow.Item(ConstColumnTotalConc) = FormatNumber(dblConcInPercent, intNoOfDecimalPlaces)
					//'End If
					//------

					//---27.03.09
					if (unit == enumUnit.PPM) {
						objDrNewRow.Item(ConstColumnTotalConc) = FormatNumber(dblConcInPpm, intNoOfDecimalPlaces);
					} else if (unit == enumUnit.Percent) {
						objDrNewRow.Item(ConstColumnTotalConc) = FormatNumber(dblConcInPercent, intNoOfDecimalPlaces);
					} else if (unit == enumUnit.PPB) {
						objDrNewRow.Item(ConstColumnTotalConc) = FormatNumber(dblConcInPpm, intNoOfDecimalPlaces);
					}
					//-------------


					//sprintf(str,"%-2d\t",  samp->Data.SampNo);
					//sprintf(str1,"%-s\t", samp->Data.Samp_Name);
					//strcat(str, str1);
					//sprintf(str1,"%-7.4f\t",samp->Data.Weight );
					//strcat(str, str1);
					//sprintf(str1,"%-7.4f\t",samp->Data.Volume);
					//strcat(str, str1);
					//sprintf(str1,"%-7.4f\t",samp->Data.Dil_Fact);
					//strcat(str, str1);
					//#If STD_ADDN Then
					//    if(Method->QuantData->Param.Std_Addn)
					//		sprintf(str1,"-\t", samp->Data.Abs);
					//	else
					//	{
					//		if (Method->Mode==MODE_EMISSION)
					//			sprintf(str1,"%-4.1f %%\t", samp->Data.Abs);
					//		else
					//		{
					//			StoreAbsAccurate(samp->Data.Abs,str1);
					//			strcat(str1,"\t");
					//			}
					//	}
					//#Else
					//	if (Method->Mode==MODE_EMISSION)
					//		sprintf(str1,"%-4.1f %%\t", samp->Data.Abs);
					//   Else
					//    	sprintf(str1,"%-4.3f\t",samp->Data.Abs );
					//#End If
					//strcat(str, str1);
					//#If STD_ADDN Then
					//    if(Method->QuantData->Param.Std_Addn)
					//	    sprintf(str1,"-\t", samp->Data.Abs);
					//    else
					//	    StoreResultAccurate(samp->Data.Conc, str1, Method->QuantData->Param.No_Decimals);
					//#Else
					//    StoreResultAccurate(samp->Data.Conc, str1, Method->QuantData->Param.No_Decimals);
					//#End If
					//strcat(str, str1); strcat(str,"\t");
					//StoreResultAccurate(Get_percent(samp->Data.Conc, samp->Data.Weight,
					//					samp->Data.Volume,samp->Data.Dil_Fact,
					//					Method->QuantData->Param.Unit,
					//					Method->QuantData->Param.No_Decimals
					//					),
					//str1, Method->QuantData->Param.No_Decimals);
					//strcat(str, str1);
					//SendMessage(GetDlgItem(hwnd,IDC_RESULT), LB_ADDSTRING, 0, (DWORD) (LPSTR) str);

					// add into data table of selected Run no
					mobjDtSample.Rows.Add(objDrNewRow);
				}
			}
			// set Data ViewResult property 
			mobjDtSampleDataGridclass.SetDataGridProperties(dgViewResults, mobjDtSample);

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
			objWaitCursor.Dispose();
			//---------------------------------------------------------
		}
	}

	#End Region

}
