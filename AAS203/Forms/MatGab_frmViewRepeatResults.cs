using AAS203Library;
using AAS203Library.Method;
using AAS203.Common;

public class frmViewRepeatResults : System.Windows.Forms.Form
{

	#Region " Windows Form Designer generated code "

	public frmViewRepeatResults()
	{
		base.New();

		//This call is required by the Windows Form Designer.
		InitializeComponent();

		//Add any initialization after the InitializeComponent() call

	}

	public frmViewRepeatResults(clsMethod objMethod, int intSelectedRunNumberIndex)
	{
		base.New();

		//This call is required by the Windows Form Designer.
		InitializeComponent();

		//Add any initialization after the InitializeComponent() call
		mobjclsMethod = objMethod;
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
	internal CodeIntellects.Office2003Controls.Office2003Header Office2003Header1;
	internal NETXP.Controls.XPButton btnOk;
	internal NETXP.Controls.XPButton btnDelete;
	internal GradientPanel.CustomPanel CustomPanel1;
	internal GridLayoutPanel.GridLayoutPanel RepeatResultsViewer;
	internal NETXP.Controls.XPButton btnPrint;
	[System.Diagnostics.DebuggerStepThrough()]
	private void InitializeComponent()
	{
		this.components = new System.ComponentModel.Container();
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmViewRepeatResults));
		this.Office2003Header1 = new CodeIntellects.Office2003Controls.Office2003Header();
		this.RepeatResultsViewer = new GridLayoutPanel.GridLayoutPanel(this.components);
		this.CustomPanel1 = new GradientPanel.CustomPanel();
		this.btnPrint = new NETXP.Controls.XPButton();
		this.btnDelete = new NETXP.Controls.XPButton();
		this.btnOk = new NETXP.Controls.XPButton();
		this.Office2003Header1.SuspendLayout();
		this.CustomPanel1.SuspendLayout();
		this.SuspendLayout();
		//
		//Office2003Header1
		//
		this.Office2003Header1.AutoScroll = true;
		this.Office2003Header1.BackColor = System.Drawing.Color.Transparent;
		this.Office2003Header1.Controls.Add(this.RepeatResultsViewer);
		this.Office2003Header1.Controls.Add(this.CustomPanel1);
		this.Office2003Header1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.Office2003Header1.Location = new System.Drawing.Point(0, 0);
		this.Office2003Header1.Name = "Office2003Header1";
		this.Office2003Header1.Size = new System.Drawing.Size(778, 391);
		this.Office2003Header1.TabIndex = 0;
		this.Office2003Header1.TitleFont = new System.Drawing.Font("Tahoma", 10f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.Office2003Header1.TitleText = "Repeat Results";
		//
		//RepeatResultsViewer
		//
		this.RepeatResultsViewer.AutoScroll = true;
		this.RepeatResultsViewer.ColumnCount = 1;
		this.RepeatResultsViewer.ControlHSpacing = 1;
		this.RepeatResultsViewer.ControlVSpacing = 1;
		this.RepeatResultsViewer.Dock = System.Windows.Forms.DockStyle.Fill;
		this.RepeatResultsViewer.ErrorText = "";
		this.RepeatResultsViewer.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.RepeatResultsViewer.Location = new System.Drawing.Point(0, 0);
		this.RepeatResultsViewer.Name = "RepeatResultsViewer";
		this.RepeatResultsViewer.SelectedIndex = 0;
		this.RepeatResultsViewer.ShowError = false;
		this.RepeatResultsViewer.SingleRowGrid = false;
		this.RepeatResultsViewer.Size = new System.Drawing.Size(778, 335);
		this.RepeatResultsViewer.TabIndex = 120;
		//
		//CustomPanel1
		//
		this.CustomPanel1.Controls.Add(this.btnPrint);
		this.CustomPanel1.Controls.Add(this.btnDelete);
		this.CustomPanel1.Controls.Add(this.btnOk);
		this.CustomPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
		this.CustomPanel1.Location = new System.Drawing.Point(0, 335);
		this.CustomPanel1.Name = "CustomPanel1";
		this.CustomPanel1.Size = new System.Drawing.Size(778, 56);
		this.CustomPanel1.TabIndex = 119;
		//
		//btnPrint
		//
		this.btnPrint.BackColor = System.Drawing.Color.Transparent;
		this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnPrint.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnPrint.Image = (System.Drawing.Image)resources.GetObject("btnPrint.Image");
		this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnPrint.Location = new System.Drawing.Point(210, 14);
		this.btnPrint.Name = "btnPrint";
		this.btnPrint.Size = new System.Drawing.Size(100, 36);
		this.btnPrint.TabIndex = 118;
		this.btnPrint.Text = "&Print";
		//
		//btnDelete
		//
		this.btnDelete.BackColor = System.Drawing.Color.Transparent;
		this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnDelete.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnDelete.ForeColor = System.Drawing.SystemColors.ControlText;
		this.btnDelete.Image = (System.Drawing.Image)resources.GetObject("btnDelete.Image");
		this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnDelete.Location = new System.Drawing.Point(339, 13);
		this.btnDelete.Name = "btnDelete";
		this.btnDelete.Size = new System.Drawing.Size(100, 38);
		this.btnDelete.TabIndex = 117;
		this.btnDelete.Text = "&Delete";
		//
		//btnOk
		//
		this.btnOk.BackColor = System.Drawing.Color.Transparent;
		this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnOk.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnOk.Image = (System.Drawing.Image)resources.GetObject("btnOk.Image");
		this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnOk.Location = new System.Drawing.Point(468, 13);
		this.btnOk.Name = "btnOk";
		this.btnOk.Size = new System.Drawing.Size(100, 36);
		this.btnOk.TabIndex = 116;
		this.btnOk.Text = "&OK";
		//
		//frmViewRepeatResults
		//
		this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
		this.ClientSize = new System.Drawing.Size(778, 391);
		this.Controls.Add(this.Office2003Header1);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		this.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		this.MaximizeBox = false;
		this.MinimizeBox = false;
		this.Name = "frmViewRepeatResults";
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "View Repeat Results";
		this.Office2003Header1.ResumeLayout(false);
		this.CustomPanel1.ResumeLayout(false);
		this.ResumeLayout(false);

	}

	#End Region

	#Region " Private Class Member Valriables "

	private clsMethod mobjclsMethod;
	private int mintSelectedRunNumberIndex;
	private RepeatResultsControl[] mobjRepeatResultsControlArray;
	private int mIntSelectedStdOrSplNo;
	private int mIntSelectedRepeatNo;
	private bool mBlnIsStandard;
	private RepeatResultsControl mobjRepeatResultsControl;
		#End Region
	ArrayList marrControls = new ArrayList();

	#Region " Form Load and Events Handling Functions "

	private void  // ERROR: Handles clauses are not supported in C#
frmViewRepeatResults_Load(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : frmViewRepeatResults_Load
		// Parameters Passed     : object, eventArgs
		// Returns               : None
		// Purpose               : 
		// Description           : To initialize and display repeat result calculations
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 10-Mar-2007 11:35 pm
		// Revisions             : 1
		//=====================================================================
		int maxsamp;

		try {
			//---find number of samples analyzed
			maxsamp = clsStandardGraph.FindSamplesAnalysed(mobjclsMethod, mintSelectedRunNumberIndex);
			if (maxsamp > 0) {
				//---set display properties of repeats
				RepeatResultsViewer.ColumnCount = 1;
				RepeatResultsViewer.ControlHSpacing = 0;
				RepeatResultsViewer.ControlVSpacing = 0;
				RepeatResultsViewer.ShowError = false;
				RepeatResultsViewer.BringToFront();

				 // ERROR: Not supported in C#: ReDimStatement

				//---display repeat result calculations on screen
				Init_Repeat_Screen(maxsamp);
			}

			int intcount;
			for (intcount = 1; intcount <= 15; intcount++) {
				marrControls.Add(intcount);
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

	private void  // ERROR: Handles clauses are not supported in C#
frmViewRepeatResults_Resize(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : frmViewRepeatResults_Resize
		// Parameters Passed     : object, eventArgs
		// Returns               : None
		// Purpose               : 
		// Description           : to set width of each repeat result control
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 
		// Revisions             : 0
		//=====================================================================
		try {
			//---to set width of each repeat result control
			if (!IsNothing(mobjRepeatResultsControlArray)) {
				RepeatResultsControl objRepeatResultsControl;
				foreach ( objRepeatResultsControl in mobjRepeatResultsControlArray) {
					objRepeatResultsControl.Width = RepeatResultsViewer.Width - 20;
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
		}
	}

	private void  // ERROR: Handles clauses are not supported in C#
btnDelete_click(object sender, EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : btnDelete_click
		// Parameters Passed     : Object, EventArgs
		// Returns               : None
		// Purpose               : 
		// Description           : To delete selected repeat control 
		//                         from controls collection
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : 22.07.07
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		RepeatResultsControl objRepeatResultsParameter;
		int Count;
		int Count1;
		AAS203Library.Method.clsAnalysisSampleParametersCollection cursamp;
		AAS203Library.Method.clsAnalysisStdParametersCollection curstd;
		int intCounter;
		int i;
		bool blnFoundObject = false;
		int maxsamp;
		int intIndexOfRepeatResultControl;
		int intSampleIndex;
		int intStdIndex;

		try {
			//---to delete sample repeat
			if (mBlnIsStandard == false) {
				for (Count = 0; Count <= mobjRepeatResultsControlArray.Length - 1; Count++) {
					if (!(mobjRepeatResultsControlArray(Count).AnalysisParameter == null)) {
						if (mobjRepeatResultsControlArray(Count).AnalysisParameter.SampNumber == (int)mIntSelectedStdOrSplNo) {
							objRepeatResultsParameter = mobjRepeatResultsControlArray(Count);
							//---get the index of repeat result control which is to be deleted
							intIndexOfRepeatResultControl = Count;
							break; // TODO: might not be correct. Was : Exit For
						}
					}
				}

				if (!objRepeatResultsParameter == null) {
					for (Count = 0; Count <= mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).SampleDataCollection.Count - 1; Count++) {
						if (mIntSelectedStdOrSplNo == mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).SampleDataCollection.item(Count).SampNumber) {
							for (Count1 = 0; Count1 <= mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).SampleDataCollection.item(Count).AbsRepeat.AbsRepeatData.Count - 1; Count1++) {
								if (!mIntSelectedRepeatNo == 0) {
									if (mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).SampleDataCollection.item(Count).AbsRepeat.AbsRepeatData.item(mIntSelectedRepeatNo - 1).Used == true) {
										//---delete (logical) the selected repeat result control
										mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).SampleDataCollection.item(Count).AbsRepeat.AbsRepeatData.item(mIntSelectedRepeatNo - 1).Used = false;
										intSampleIndex = Count;

										cursamp = mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).SampleDataCollection.Clone;
										maxsamp = clsStandardGraph.FindSamplesAnalysed(mobjclsMethod, mintSelectedRunNumberIndex);
										RepeatResultsViewer.RemoveControls();
										//---display/ refresh repeat result controls on screen
										Init_Repeat_Screen(maxsamp);
										blnFoundObject = true;
										break; // TODO: might not be correct. Was : Exit For
									}
								}
							}
							if (blnFoundObject == true) {
								break; // TODO: might not be correct. Was : Exit For
							}
						}
					}

					if (!(cursamp == null)) {
						if ((cursamp.item(Count1).Used)) {
							if (!(objRepeatResultsParameter == null)) {
								//---display statistical calculations
								objRepeatResultsParameter.ShowStatistic(cursamp.item(Count1).AbsRepeat.BasicStat, false, false);
								objRepeatResultsParameter.ShowStatistic(cursamp.item(Count1).AbsRepeat.BasicStat, false, true);
							}
						}
					}
					//---refresh sample controls array
					funcRefreshControls_Sample(mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).SampleDataCollection.item(intSampleIndex));

				}
			} else {
				//---to delete std. repeat
				for (Count = 0; Count <= mobjRepeatResultsControlArray.Length - 1; Count++) {
					if (!(mobjRepeatResultsControlArray(Count).StandardAnalysisParameter == null)) {
						if (mobjRepeatResultsControlArray(Count).StandardAnalysisParameter.StdNumber == (int)mIntSelectedStdOrSplNo) {
							objRepeatResultsParameter = mobjRepeatResultsControlArray(Count);
							break; // TODO: might not be correct. Was : Exit For
						}
					}
				}

				if (!objRepeatResultsParameter == null) {
					for (Count = 0; Count <= mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).StandardDataCollection.Count - 1; Count++) {
						if (mIntSelectedStdOrSplNo == mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).StandardDataCollection.item(Count).StdNumber) {
							for (Count1 = 0; Count1 <= mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).StandardDataCollection.item(Count).AbsRepeat.AbsRepeatData.Count - 1; Count1++) {
								if (!mIntSelectedRepeatNo == 0) {
									if (mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).StandardDataCollection.item(Count).AbsRepeat.AbsRepeatData.item(mIntSelectedRepeatNo - 1).Used == true) {
										//---delete (logical) selected standard
										mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).StandardDataCollection.item(Count).AbsRepeat.AbsRepeatData.item(mIntSelectedRepeatNo - 1).Used = false;
										intStdIndex = Count;

										curstd = mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).StandardDataCollection.Clone;
										RepeatResultsViewer.RemoveControls();
										//---refresh repeat result screen
										Init_Repeat_Screen(maxsamp);
										blnFoundObject = true;
										break; // TODO: might not be correct. Was : Exit For
									}
								}
							}
							if (blnFoundObject == true) {
								break; // TODO: might not be correct. Was : Exit For
							}
						}
					}


					if (!(curstd == null)) {
						if ((curstd.item(Count1).Used)) {
							if (!(objRepeatResultsParameter == null)) {
								//---show statistical calculations
								objRepeatResultsParameter.ShowStatistic(curstd.item(Count1).AbsRepeat.BasicStat, false, false);
							}
						}
					}
				}
				//---refresh standard array
				funcRefreshControls_Std(mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).StandardDataCollection.item(intStdIndex));
			}

			Application.DoEvents();
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
			if (!objWait == null) {
				objWait.Dispose();
			}
		}
	}

	private void  // ERROR: Handles clauses are not supported in C#
btnOk_Click(object sender, EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : btnOk_Click
		// Parameters Passed     : Object, EventArgs
		// Returns               : None
		// Purpose               : 
		// Description           : To close the form
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 09-May-2007 02:25 pm
		// Revisions             : Deepak on 16.10.08
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		int intCount;
		AAS203Library.Method.clsAnalysisStdParameters std;
		AAS203Library.Method.clsAnalysisSampleParameters samp;
		double valAbs;
		double valConc;

		try {
			for (intCount = 0; intCount <= mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).StandardDataCollection.Count - 1; intCount++) {
				std = mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).StandardDataCollection.item(intCount);
				valAbs = std.AbsRepeat.BasicStat.ZAvg(0);
				std.Abs = valAbs;
			}

			for (intCount = 0; intCount <= mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).SampleDataCollection.Count - 1; intCount++) {
				samp = mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).SampleDataCollection.item(intCount);
				valAbs = samp.AbsRepeat.BasicStat.ZAvg(0);
				valConc = samp.AbsRepeat.BasicStat.ZAvg(1);
				samp.Abs = valAbs;
				samp.Conc = valConc;
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
			//---------------------------------------------------------
			if (!objWait == null) {
				objWait.Dispose();
			}
		}
	}

	#End Region

	#Region " Private Functions "

	private void Init_Repeat_Screen(int page)
	{
		//=====================================================================
		// Procedure Name        : Init_Repeat_Screen
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 10-Mar-2007 11:35 pm
		// Revisions             : 1
		//=====================================================================


		//---- ORIGINAL CODE

		//void	Init_Repeat_Screen(HWND hwnd, int page)
		//{
		//	STDDATA 		*curstd=NULL;
		//	SAMPDATA 	*cursamp=NULL;

		//	int	i=0,j;

		//	curstd  =	Method->QuantData->StdTopData;
		//	cursamp =	Method->QuantData->SampTopData;
		//	ClrDispRepInfoStd(hwnd );
		//	i=0;
		//   While (curstd)
		//	{
		//       If (i >= page) Then
		//			break;
		//		/*  if (curstd->Data.Used)*/
		//		i++;
		//		curstd=curstd->next;
		//	}
		//	if (i<page && curstd==NULL)
		//	{
		//       While (cursamp)
		//		{
		//           If (i >= page) Then
		//				break;
		//			/*if (cursamp->Data.Used)*/
		//			i++;
		//			cursamp=cursamp->next;
		//		}
		//	}
		//	i=0; //page%3;
		//   While (curstd)
		//	{
		//		if (curstd==CurStd)
		//			break;
		//		if (curstd->Data.Used)
		//		{
		//			DisplayRepeatInfoStd(hwnd, curstd, i);
		//			i++;
		//		}
		//       If (i > 2) Then
		//			break;
		//		curstd=curstd->next;
		//	}
		//	while(i<3 &&cursamp )
		//	{
		//#If STD_ADDN Then
		//			if (cursamp==CurSamp)
		//				break;
		//#End If
		//		if (cursamp->Data.Used)
		//		{
		//			DisplayRepeatInfoSamp(hwnd, cursamp, i);
		//			i++;
		//		}
		//       If (i > 2) Then
		//			break;
		//       #If STD_ADDN Then
		//			if(Method->QuantData->Param.Std_Addn)
		//				break;
		//       #End If
		//		cursamp=cursamp->next;
		//	}
		//   If (i < 3) Then
		//	{
		//		for(; i<3; i++)
		//			for(j=0; j<NOOFITEMS;j++)
		//				ShowWindow1(GetDlgItem(hwnd,IDC_SAMPNAME+i*NOOFITEMS+j), FALSE);
		//	}
		//}

		int i;
		int j;
		int intCounter;
		AAS203Library.Method.clsAnalysisStdParametersCollection curstd;
		AAS203Library.Method.clsAnalysisSampleParametersCollection cursamp;

		try {
			//---get current stadards and samples
			curstd = mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).StandardDataCollection.Clone;
			cursamp = mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).SampleDataCollection.Clone;

			for (intCounter = 0; intCounter <= curstd.Count - 1; intCounter++) {
				if ((curstd.item(intCounter).Used)) {
					//---added by deepak on 22.07.07
					//---perform basic statistics calculations
					clsBasicStatistics.CalculateBasicStats(curstd(intCounter).AbsRepeat);
					//---added by deepak on 22.07.07
					//---display repeat calculation result
					DisplayRepeatInfoStd(curstd.item(intCounter), i);
					//i += 1
				}
			}


			//If clsBasicStatistics.CalculateBasicStats(objSample.AbsRepeat) Then
			//    objSample.Abs = objSample.AbsRepeat.BasicStat.ZAvg(0)
			//    cursamp(0).Abs()
			//End If

			for (intCounter = 0; intCounter <= cursamp.Count - 1; intCounter++) {
				if ((cursamp.item(intCounter).Used)) {
					//objSample.Abs = objSample.AbsRepeat.BasicStat.ZAvg(0)
					//---perform basic statistics calculations
					clsBasicStatistics.CalculateBasicStats(cursamp(intCounter).AbsRepeat);
					cursamp(intCounter).Abs = cursamp(intCounter).AbsRepeat.BasicStat.ZAvg(0);
					//---display repeat calculation result
					DisplayRepeatInfoSamp(cursamp.item(intCounter), i);
					//i += 1
				}
			}
			//---display grid on screen
			RepeatResultsViewer.ShowGrid();
		//AddHandler RepeatResultsViewer.ControlClicked, AddressOf objRepeatResultsControl_RepeatResultClick
		//AddHandler mobjRepeatResultsControl.RepeatResultClick, AddressOf objRepeatResultsControl_RepeatResultClick
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

	private void DisplayRepeatInfoStd(Method.clsAnalysisStdParameters curstd, ref int i)
	{
		//=====================================================================
		// Procedure Name        : DisplayRepeatInfoStd
		// Parameters Passed     : StandardInfo
		// Returns               : None
		// Purpose               : 
		// Description           : Initialize control for each repeat and add it 
		//                         to controls collection
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 10-Mar-2007 01:25 pm
		// Revisions             : 1
		//=====================================================================


		//void	DisplayRepeatInfoStd(HWND hwnd, STDDATA *curstd, int i)
		//{
		//	int	j=0;
		//	char	str[40]="";
		//	ABSREPEATDATA	*rpt=NULL;
		//	j=0;
		//   If (curstd) Then
		//	{
		//		sprintf(str,"%-2d",curstd->Data.StdNo);
		//		ShowWindow1(GetDlgItem(hwnd,IDC_SAMPNAME+i*NOOFITEMS+j), TRUE);
		//		SetWindowText(GetDlgItem(hwnd, IDC_SAMPNAME+i*NOOFITEMS+j), str); j++;
		//		ShowWindow1(GetDlgItem(hwnd,IDC_SAMPNAME+i*NOOFITEMS+j), TRUE);
		//		SetWindowText(GetDlgItem(hwnd, IDC_SAMPNAME+i*NOOFITEMS+j), curstd->Data.Std_Name);j++;
		//		j++;
		//		if (curstd->Data.AbsRepeat)
		//		{
		//			rpt = curstd->Data.AbsRepeat->RptDataTop;
		//                While (rpt)
		//			{
		//				if (Method->Mode==MODE_EMISSION)
		//					sprintf(str,"%-4.1f",rpt->Abs);
		//                    Else
		//				{
		//					StoreAbsAccurate(rpt->Abs,str);
		//					//sprintf(str,"%-4.3f",rpt->Abs);
		//				}
		//				ShowWindow1(GetDlgItem(hwnd,IDC_SAMPNAME+i*NOOFITEMS+j), TRUE);
		//				SetDlgItemText(hwnd, IDC_SAMPNAME+i*NOOFITEMS+j, str); j++;
		//				rpt=rpt->next;
		//			}
		//			for(; j<NOOFITEMS-6; j++)
		//				ShowWindow1(GetDlgItem(hwnd,IDC_SAMPNAME+i*NOOFITEMS+j), FALSE);
		//			j+=2;
		//			for(; j<NOOFITEMS-2; j++)
		//				ShowWindow1(GetDlgItem(hwnd,IDC_SAMPNAME+i*NOOFITEMS+j), FALSE);
		//			ShowStatistic(hwnd, &(curstd->Data.AbsRepeat->Data), i, TRUE);
		//		}
		//	}
		//}

		int j;
		string str;

		Method.clsAbsRepeatDataCollection rpt;
		int intCounter;

		try {
			if (!IsNothing(curstd)) {
				//---Initialize control for each repeat
				RepeatResultsControl objRepeatResultsControl = new RepeatResultsControl();
				//Dim objRepeatResultsControl As New GridLayoutPanel.RepeatResultsControl
				objRepeatResultsControl.StandardNumber = curstd.StdNumber;
				//objRepeatResultsControl.StandardName = curstd.StdName 
				//---changed on 30.01.09 as per document received from app.lab 

				//---27.03.09
				//'objRepeatResultsControl.StandardName = curstd.StdName & Space(2) & "(Conc : " & FormatNumber(curstd.Concentration, 2) & " )"
				objRepeatResultsControl.StandardName = curstd.StdName + Space(2) + "(Conc : " + FormatNumber(curstd.Concentration, 4) + " )";
				//----

				objRepeatResultsControl.lstConcStats.Visible = false;
				objRepeatResultsControl.lblConc.Visible = false;
				objRepeatResultsControl.lblConcStats.Visible = false;
				objRepeatResultsControl.RemoveOption.Visible = false;
				objRepeatResultsControl.IsStandard = true;

				//---02.12.07
				//objRepeatResultsControl.Dock = DockStyle.To
				//objRepeatResultsControl.AutoScroll = True

				//---add handler for each control item clicked
				objRepeatResultsControl.RepeatItemClick += SubRepeatResultsControl_RepeatResultClick;
				if ((mobjclsMethod.OperationMode == EnumOperationMode.MODE_EMMISSION)) {
					objRepeatResultsControl.lblAbs.Text = "Emission";
					//---added by deepak on 22.07.07
					objRepeatResultsControl.lblAbsStats.Text = "Statistics on Emission";
				} else {
					objRepeatResultsControl.lblAbs.Text = "Abs";
					//---added by deepak on 22.07.07
					objRepeatResultsControl.lblAbsStats.Text = "Statistics on Abs";
				}

				if (!IsNothing(curstd.AbsRepeat)) {
					rpt = curstd.AbsRepeat.AbsRepeatData;
					j = 1;
					for (intCounter = 0; intCounter <= rpt.Count - 1; intCounter++) {
						//22.07.07
						if (rpt.item(intCounter).Used == true) {
							//---format absorbance according to the mode
							if ((mobjclsMethod.OperationMode == EnumOperationMode.MODE_EMMISSION)) {
								str = FormatNumber(rpt.item(intCounter).Abs, 1);
							} else {
								str = FormatNumber(rpt.item(intCounter).Abs, 3);
							}
							//---set abs value in control
							objRepeatResultsControl.FindNSetValueInControl(str, j);
							//Call objRepeatResultsControl.FindNSet2ndValueInControl(str, j)
							j += 1;
						}
					}
					//---make control visible on/off 
					//+ clsStandardGraph.MAXREPEAT
					for (j = j; j <= clsStandardGraph.MAXREPEAT; j++) {
						objRepeatResultsControl.FindNSetControlVisible(j, false);
					}
					//---make second control for conc. visible on/off 
					//+ clsStandardGraph.MAXREPEAT
					for (j = 1; j <= clsStandardGraph.MAXREPEAT; j++) {
						objRepeatResultsControl.FindNSet2ndControlVisible(j, false);
					}
					//---display statistics
					objRepeatResultsControl.ShowStatistic(curstd.AbsRepeat.BasicStat, true, false);

					objRepeatResultsControl.StandardAnalysisParameter = curstd;
					//22.07.07
					objRepeatResultsControl.Width = RepeatResultsViewer.Width - 20;
					mobjRepeatResultsControlArray(i) = objRepeatResultsControl;
					RepeatResultsViewer.GetControls(mobjRepeatResultsControlArray);
					i += 1;
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
		}
	}

	private void DisplayRepeatInfoSamp(Method.clsAnalysisSampleParameters cursamp, ref int i)
	{
		//=====================================================================
		// Procedure Name        : DisplayRepeatInfoSamp
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : 
		// Description           : Initialize control for each repeat and add it 
		//                         to controls collection
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 10-Mar-2007 05:55 pm
		// Revisions             : 1
		//=====================================================================


		//void	DisplayRepeatInfoSamp(HWND hwnd, SAMPDATA *cursamp, int i)
		//{
		//	int	j=0, k;
		//	char	str[40]="";
		//	ABSREPEATDATA	*rpt=NULL;
		//	j=0;
		//   If (cursamp) Then
		//	{
		//		sprintf(str,"%-2d",cursamp->Data.SampNo);
		//		ShowWindow1(GetDlgItem(hwnd,IDC_SAMPNAME+i*NOOFITEMS+j), TRUE);
		//		SetWindowText(GetDlgItem(hwnd, IDC_SAMPNAME+i*NOOFITEMS+j), str);
		//		j++;
		//		ShowWindow1(GetDlgItem(hwnd,IDC_SAMPNAME+i*NOOFITEMS+j), TRUE);
		//		SetWindowText(GetDlgItem(hwnd, IDC_SAMPNAME+i*NOOFITEMS+j), cursamp->Data.Samp_Name);
		//		j++;
		//		ShowWindow1(GetDlgItem(hwnd,IDC_SAMPNAME+i*NOOFITEMS+j), TRUE);
		//		j++;
		//       #If STD_ADDN Then
		//			if(Method->QuantData->Param.Std_Addn)
		//			{
		//				k=j;
		//				ShowWindow1(GetDlgItem(hwnd,IDC_SAMPNAME+i*NOOFITEMS+j), TRUE);
		//				SetDlgItemText(hwnd, IDC_SAMPNAME+i*NOOFITEMS+j, "");
		//				j++;
		//				for(; j<k+15; j++)
		//					ShowWindow1(GetDlgItem(hwnd,IDC_SAMPNAME+i*NOOFITEMS+j), FALSE);
		//				ShowWindow1(GetDlgItem(hwnd,IDC_SAMPNAME+i*NOOFITEMS+j), TRUE);
		//				j++;
		//				k=j;
		//				StoreResultAccurate(Get_percent(Method->QuantData->SampTopData->Data.Conc,
		//												  Method->QuantData->SampTopData->Data.Weight,
		//												  Method->QuantData->SampTopData->Data.Volume,
		//												  Method->QuantData->SampTopData->Data.Dil_Fact,
		//												  Method->QuantData->Param.Unit,
		//												  Method->QuantData->Param.No_Decimals),str,
		//												  Method->QuantData->Param.No_Decimals);
		//				ShowWindow1(GetDlgItem(hwnd,IDC_SAMPNAME+i*NOOFITEMS+j), TRUE);
		//				SetDlgItemText(hwnd, IDC_SAMPNAME+i*NOOFITEMS+j, str);
		//				j++;
		//				for(; j<k+17; j++)
		//					ShowWindow1(GetDlgItem(hwnd,IDC_SAMPNAME+i*NOOFITEMS+j), FALSE);
		//			}
		//       #Else
		//           Else
		//			{
		//       #End If
		//		    if (cursamp->Data.AbsRepeat)
		//		    {
		//				rpt = cursamp->Data.AbsRepeat->RptDataTop;
		//				k=j;
		//               While (rpt)
		//				{
		//					if (Method->Mode==MODE_EMISSION)
		//						sprintf(str,"%-4.1f",rpt->Abs);
		//                    Else
		//					{
		//						StoreAbsAccurate(rpt->Abs,str);
		//						//sprintf(str,"%-4.3f",rpt->Abs);
		//					}
		//					ShowWindow1(GetDlgItem(hwnd,IDC_SAMPNAME+i*NOOFITEMS+j), TRUE);
		//					SetDlgItemText(hwnd, IDC_SAMPNAME+i*NOOFITEMS+j, str); j++;
		//					rpt=rpt->next;
		//				}
		//				for(; j<k+15; j++)
		//					ShowWindow1(GetDlgItem(hwnd,IDC_SAMPNAME+i*NOOFITEMS+j), FALSE);
		//				ShowWindow1(GetDlgItem(hwnd,IDC_SAMPNAME+i*NOOFITEMS+j), TRUE);
		//				j++;
		//				k=j;
		//				rpt = cursamp->Data.AbsRepeat->RptDataTop;
		//               While (rpt)
		//				{
		//					StoreResultAccurate(rpt->Conc, str,
		//					Method->QuantData->Param.No_Decimals);
		//					ShowWindow1(GetDlgItem(hwnd,IDC_SAMPNAME+i*NOOFITEMS+j), TRUE);
		//					SetDlgItemText(hwnd, IDC_SAMPNAME+i*NOOFITEMS+j, str);
		//					j++;
		//					rpt=rpt->next;
		//				}
		//				for(; j<k+15; j++)
		//					ShowWindow1(GetDlgItem(hwnd,IDC_SAMPNAME+i*NOOFITEMS+j), FALSE);
		//				ShowWindow1(GetDlgItem(hwnd,IDC_SAMPNAME+i*NOOFITEMS+j), TRUE);
		//				j+=2;
		//				ShowWindow1(GetDlgItem(hwnd,IDC_SAMPNAME+i*NOOFITEMS+j), TRUE);
		//				ShowStatistic(hwnd, &(cursamp->Data.AbsRepeat->Data), i, TRUE);
		//				ShowStatistic(hwnd, &(cursamp->Data.AbsRepeat->Data), i, FALSE);
		//			}
		//       #If STD_ADDN Then
		//		    }
		//       #End If
		//}

		int j;
		int k;
		string str;
		Method.clsAbsRepeatDataCollection rpt;
		int intCounter;


		try {
			j = 0;
			if (!IsNothing(cursamp)) {
				//---intialize control for new sample repeat
				RepeatResultsControl objRepeatResultsControl = new RepeatResultsControl();
				//Dim objRepeatResultsControl As New GridLayoutPanel.RepeatResultsControl
				objRepeatResultsControl.StandardNumber = cursamp.SampNumber;
				objRepeatResultsControl.StandardName = cursamp.SampleName;
				objRepeatResultsControl.lstConcStats.Visible = true;
				objRepeatResultsControl.lblConc.Visible = true;
				objRepeatResultsControl.lblConcStats.Visible = true;
				objRepeatResultsControl.IsStandard = false;

				//---02.12.07
				//objRepeatResultsControl.AutoScroll = True
				//objRepeatResultsControl.Dock = DockStyle.Fill

				//---add handler for control click
				objRepeatResultsControl.RepeatItemClick += SubRepeatResultsControl_RepeatResultClick;
				if ((mobjclsMethod.OperationMode == EnumOperationMode.MODE_EMMISSION)) {
					objRepeatResultsControl.lblAbs.Text = "Emission";
					//---added by deepak on 22.07.07
					objRepeatResultsControl.lblAbsStats.Text = "Statistics on Emission";
				} else {
					objRepeatResultsControl.lblAbs.Text = "Abs";
					//---added by deepak on 22.07.07
					objRepeatResultsControl.lblAbsStats.Text = "Statistics on Abs";
				}
				if (mobjclsMethod.StandardAddition) {
					k = j;
				//ShowWindow1(GetDlgItem(hwnd,IDC_SAMPNAME+i*NOOFITEMS+j), TRUE);
				//SetDlgItemText(hwnd, IDC_SAMPNAME+i*NOOFITEMS+j, "");
				//j+=1
				//for(; j<k+15; j++)
				//   ShowWindow1(GetDlgItem(hwnd,IDC_SAMPNAME+i*NOOFITEMS+j), FALSE);
				//ShowWindow1(GetDlgItem(hwnd,IDC_SAMPNAME+i*NOOFITEMS+j), TRUE);
				//j+=1
				//k=j
				//StoreResultAccurate(Get_percent(Method->QuantData->SampTopData->Data.Conc,
				//                                Method->QuantData->SampTopData->Data.Weight,
				//								 Method->QuantData->SampTopData->Data.Volume,
				//								 Method->QuantData->SampTopData->Data.Dil_Fact,
				//								 Method->QuantData->Param.Unit,
				//								 Method->QuantData->Param.No_Decimals),str,
				//								 Method->QuantData->Param.No_Decimals);
				//ShowWindow1(GetDlgItem(hwnd,IDC_SAMPNAME+i*NOOFITEMS+j), TRUE);
				//SetDlgItemText(hwnd, IDC_SAMPNAME+i*NOOFITEMS+j, str);
				//j+=1
				//for(; j<k+17; j++)
				//   ShowWindow1(GetDlgItem(hwnd,IDC_SAMPNAME+i*NOOFITEMS+j), FALSE);

				} else {
					//'If Not IsNothing(cursamp.AbsRepeat) Then
					//'    rpt = cursamp.AbsRepeat.AbsRepeatData
					//'    j = 1
					//'    For intCounter = 0 To rpt.Count - 1
					//'        If (mobjclsMethod.OperationMode = EnumOperationMode.MODE_EMMISSION) Then
					//'            str = FormatNumber(rpt.item(intCounter).Abs, 2)
					//'        Else
					//'            str = FormatNumber(rpt.item(intCounter).Abs, 4)
					//'        End If
					//'        Call objRepeatResultsControl.FindNSetValueInControl(str, j)
					//'        j += 1
					//'    Next
					//'    For j = j To clsStandardGraph.MAXREPEAT + clsStandardGraph.MAXREPEAT
					//'        Call objRepeatResultsControl.FindNSetControlVisible(j, False)
					//'    Next
					//'    objRepeatResultsControl.ShowStatistic(cursamp.AbsRepeat.BasicStat, i, True)
					//'    objRepeatResultsControl.Dock = DockStyle.Bottom
					//'    RepeatResultsViewer.Controls.Add(objRepeatResultsControl)
					//'End If

					if (!IsNothing(cursamp.AbsRepeat)) {
						rpt = cursamp.AbsRepeat.AbsRepeatData;
						j = 1;
						k = j;

						//---format abs values according to the type of mode
						for (intCounter = 0; intCounter <= rpt.Count - 1; intCounter++) {
							if (rpt.item(intCounter).Used == true) {
								if ((mobjclsMethod.OperationMode == EnumOperationMode.MODE_EMMISSION)) {
									str = FormatNumber(rpt.item(intCounter).Abs, 1);
								} else {
									str = FormatNumber(rpt.item(intCounter).Abs, 3);
								}

								//---set abs value in control
								objRepeatResultsControl.FindNSetValueInControl(str, j);
								//Call objRepeatResultsControl.FindNSet2ndValueInControl(str, j)
								j += 1;
							}
						}

						//For j = j To clsStandardGraph.MAXREPEAT '+ clsStandardGraph.MAXREPEAT
						//    Call objRepeatResultsControl.FindNSetControlVisible(j, False)
						//    ' Call objRepeatResultsControl.FindNSet2ndControlVisible(j, False)
						//Next
						j = 1;
						//---set value of concentration in second control
						for (intCounter = 0; intCounter <= rpt.Count - 1; intCounter++) {
							if (rpt.item(intCounter).Used == true) {
								//str = FormatNumber(rpt.item(intCounter).Concentration, 2) ' code commented by : dinesh wagh on 8.3.2009
								str = rpt.item(intCounter).Concentration;
								// code added by : dinesh wagh on 8.3.2009

								objRepeatResultsControl.FindNSet2ndValueInControl(str, j, mobjclsMethod.AnalysisParameters.NumOfDecimalPlaces);
								//---08.03.09

								// Call objRepeatResultsControl.FindNSet2ndValueInControl(str, j)
								j += 1;
							}
						}

						//---make visible on/off both controls(abs and conc)
						//+ clsStandardGraph.MAXREPEAT
						for (j = j; j <= clsStandardGraph.MAXREPEAT; j++) {
							objRepeatResultsControl.FindNSetControlVisible(j, false);
							objRepeatResultsControl.FindNSet2ndControlVisible(j, false);
							Application.DoEvents();
						}

						//---display statistics
						objRepeatResultsControl.ShowStatistic(cursamp.AbsRepeat.BasicStat, false, false);
						objRepeatResultsControl.ShowStatistic(cursamp.AbsRepeat.BasicStat, false, true);

						objRepeatResultsControl.Width = RepeatResultsViewer.Width - 20;
						objRepeatResultsControl.AnalysisParameter = cursamp;
						mobjRepeatResultsControlArray(i) = objRepeatResultsControl;
						mIntSelectedStdOrSplNo = objRepeatResultsControl.AnalysisParameter.SampNumber;
						//mobjRepeatResultsControl = objRepeatResultsControl
						RepeatResultsViewer.GetControls(mobjRepeatResultsControlArray);
						i += 1;
					}
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
		}
	}

	private void SubRepeatResultsControl_RepeatResultClick(int StandardOrSampleNumber, int RepeatNumber, bool IsStandard, ref Control.ControlCollection ctrls)
	{
		//=====================================================================
		// Procedure Name        : objRepeatResultsControl_RepeatResultClick
		// Parameters Passed     : StandardNumber,RepeatNumber,IsStandard,ctrls
		// Returns               : None
		// Purpose               : 
		// Description           : Alter tags of all repeat controls
		//                         after deletion according to current array
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : 26.07.07
		// Revisions             : 1
		//=====================================================================
		Control cntrl;
		int intTextBoxIndex = 1;
		int intTextBoxConcIndex = 1;
		int intCount;
		int intUsedCount;

		try {
			//---get standard or sample count
			if (IsStandard == true) {
				for (intCount = 0; intCount <= mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).StandardDataCollection.item(StandardOrSampleNumber - 1).AbsRepeat.AbsRepeatData.Count - 1; intCount++) {
					if (mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).StandardDataCollection.item(StandardOrSampleNumber - 1).AbsRepeat.AbsRepeatData.item(intCount).Used == true) {
						intUsedCount = intUsedCount + 1;
					}
				}
			} else {
				for (intCount = 0; intCount <= mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).SampleDataCollection.item(StandardOrSampleNumber - 1).AbsRepeat.AbsRepeatData.Count - 1; intCount++) {
					if (mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).SampleDataCollection.item(StandardOrSampleNumber - 1).AbsRepeat.AbsRepeatData.item(intCount).Used == true) {
						intUsedCount = intUsedCount + 1;
					}
				}
			}

			//---arrange array of tags according to stadard/sample deletion
			if (IsStandard == true) {
				marrControls.Clear();
				for (intCount = 0; intCount <= mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).StandardDataCollection.item(StandardOrSampleNumber - 1).AbsRepeat.AbsRepeatData.Count - 1; intCount++) {
					if (mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).StandardDataCollection.item(StandardOrSampleNumber - 1).AbsRepeat.AbsRepeatData.item(intCount).Used == true) {
						marrControls.Add(intCount + 1);
					}
				}
			} else {
				marrControls.Clear();
				for (intCount = 0; intCount <= mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).SampleDataCollection.item(StandardOrSampleNumber - 1).AbsRepeat.AbsRepeatData.Count - 1; intCount++) {
					if (mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).SampleDataCollection.item(StandardOrSampleNumber - 1).AbsRepeat.AbsRepeatData.item(intCount).Used == true) {
						marrControls.Add(intCount + 1);
					}
				}
			}

			//---assign new tags to stadard/sample repeat controls
			if (IsStandard == true) {
				for (intCount = 0; intCount <= intUsedCount - 1; intCount++) {
					foreach ( cntrl in ctrls) {
						if (cntrl is TextBox) {
							if (cntrl.Name == "TextBox" + intTextBoxIndex) {
								cntrl.Tag = marrControls(intTextBoxIndex - 1);
								intTextBoxIndex = intTextBoxIndex + 1;
								break; // TODO: might not be correct. Was : Exit For
							}
						}
					}
				}
			} else {
				for (intCount = 0; intCount <= intUsedCount - 1; intCount++) {
					foreach ( cntrl in ctrls) {
						if (cntrl is TextBox) {
							if (cntrl.Name == "TextBox" + intTextBoxIndex) {
								cntrl.Tag = marrControls(intTextBoxIndex - 1);
								intTextBoxIndex = intTextBoxIndex + 1;
								break; // TODO: might not be correct. Was : Exit For
							}
						}
					}
				}
				//---assign new tags to sample conc. repeat controls
				for (intCount = 0; intCount <= intUsedCount - 1; intCount++) {
					foreach ( cntrl in ctrls) {
						if (cntrl is TextBox) {
							if (cntrl.Name == "TextBoxConc" + intTextBoxConcIndex) {
								cntrl.Tag = marrControls(intTextBoxConcIndex - 1);
								intTextBoxConcIndex = intTextBoxConcIndex + 1;
								break; // TODO: might not be correct. Was : Exit For
							}
						}
					}
				}
			}

			mIntSelectedStdOrSplNo = StandardOrSampleNumber;
			mIntSelectedRepeatNo = RepeatNumber;
			mBlnIsStandard = IsStandard;
		//MessageBox.Show(mIntSelectedRepeatNo)
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

	private bool funcRefreshControls_Sample(clsAnalysisSampleParameters sample)
	{
		//=====================================================================
		// Procedure Name        : funcRefreshControls_Sample
		// Parameters Passed     : sample
		// Returns               : None
		// Purpose               : 
		// Description           : To refresh array of tags for sample repeat controls
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : 26.07.07
		// Revisions             : 1
		//=====================================================================
		int intCount;
		int intTextBoxIndex = 1;

		try {
			marrControls.Clear();
			for (intCount = 0; intCount <= sample.AbsRepeat.AbsRepeatData.Count - 1; intCount++) {
				if (sample.AbsRepeat.AbsRepeatData.item(intCount).Used == true) {
					marrControls.Add(intCount + 1);
				}
			}
			return false;
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

	private bool funcRefreshControls_Std(clsAnalysisStdParameters std)
	{
		//=====================================================================
		// Procedure Name        : funcRefreshControls_Std
		// Parameters Passed     : std
		// Returns               : None
		// Purpose               : 
		// Description           : To refresh array of tags for std repeat controls
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : 26.07.07
		// Revisions             : 1
		//=====================================================================
		int intCount;
		int intTextBoxIndex = 1;

		try {
			marrControls.Clear();
			for (intCount = 0; intCount <= std.AbsRepeat.AbsRepeatData.Count - 1; intCount++) {
				if (std.AbsRepeat.AbsRepeatData.item(intCount).Used == true) {
					marrControls.Add(intCount + 1);
				}
			}
			return false;
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

	private void  // ERROR: Handles clauses are not supported in C#
btnPrint_Click(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : btnPrint_Click
		// Parameters Passed     : Object, EventArgs
		// Returns               : None
		// Purpose               : 
		// Description           : To print repeat results
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 04-Aug-2007
		// Revisions             : 1
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		clsDataFileReport objclsDataFileReport;
		//update data structure

		try {
			//code added by ; dinesh wagh on 24.6.2010
			//Print function will work for any condition.For 21CFR it will authenticate the user first.
			//-------------------------------------------------------
			if ((gstructSettings.Enable21CFR == true)) {
				if (!funcCheckActivityAuthentication(enumActivityAuthentication.Print, gstructUserDetails.Access)) {
					return;
				}
			}

			objclsDataFileReport = new clsDataFileReport();
			objclsDataFileReport.MethodID = mobjclsMethod.MethodID;
			objclsDataFileReport.RunNumber = mobjclsMethod.QuantitativeDataCollection(mintSelectedRunNumberIndex).RunNumber;
			objclsDataFileReport.DefaultFont = this.DefaultFont;
			objclsDataFileReport.funcEditDataRepeatResult(mobjclsMethod);
		//-------------------------------------------


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
			objclsDataFileReport = null;
			if (!objWait == null) {
				objWait.Dispose();
			}
		}
	}

}
